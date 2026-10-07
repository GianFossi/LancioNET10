Option Strict On
Option Explicit On
Imports RoutBase1
Imports System.Data
Imports System.Data.OleDb
Friend Class frmDati
	Inherits System.Windows.Forms.Form
#Region "Codice generato dalla finestra di progettazione Windows Form "
	Public Sub New()
		MyBase.New()
        'Chiamata richiesta dalla progettazione Windows Form.
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmDati))
        Inizializzando = True
        InitializeComponent()
        Librerie = New ButtonArray(Me, Frame1, "_librerie")
        _librerie_0 = Librerie.AddNewTextBox(False)
        _librerie_0.Image = CType(resources.GetObject("cmdPrezzo.Image"), System.Drawing.Image)
        _librerie_0.Location = New System.Drawing.Point(280, 39)
        _librerie_0.Size = New System.Drawing.Size(24, 24)
        Inizializzando = False
        Inizializza()
    End Sub
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
    Public WithEvents _Option2_0 As System.Windows.Forms.RadioButton
    Public WithEvents _Option2_1 As System.Windows.Forms.RadioButton
    Public WithEvents Frame5 As System.Windows.Forms.GroupBox
    Public WithEvents lstLE As System.Windows.Forms.ListBox
    Public WithEvents cmbLE As System.Windows.Forms.ComboBox
    Public WithEvents _txtPsp_14 As System.Windows.Forms.TextBox
    Public WithEvents _txtPsp_13 As System.Windows.Forms.TextBox
    Public WithEvents _txtPsp_12 As System.Windows.Forms.TextBox
    Public WithEvents _txtPsp_11 As System.Windows.Forms.TextBox
    Public WithEvents _txtPsp_10 As System.Windows.Forms.TextBox
    Public WithEvents _txtPsp_9 As System.Windows.Forms.TextBox
    Public WithEvents _txtPsp_8 As System.Windows.Forms.TextBox
    Public WithEvents _txtPsp_7 As System.Windows.Forms.TextBox
    Public WithEvents _txtPsp_6 As System.Windows.Forms.TextBox
    Public WithEvents _txtPsp_5 As System.Windows.Forms.TextBox
    Public WithEvents _txtPsp_4 As System.Windows.Forms.TextBox
    Public WithEvents _txtPsp_3 As System.Windows.Forms.TextBox
    Public WithEvents _txtPsp_2 As System.Windows.Forms.TextBox
    Public WithEvents _txtPsp_1 As System.Windows.Forms.TextBox
    Public WithEvents _txtPsp_0 As System.Windows.Forms.TextBox
    Public WithEvents _lblPsp_14 As System.Windows.Forms.Label
    Public WithEvents _lblPsp_13 As System.Windows.Forms.Label
    Public WithEvents _lblPsp_12 As System.Windows.Forms.Label
    Public WithEvents _lblPsp_11 As System.Windows.Forms.Label
    Public WithEvents _lblPsp_10 As System.Windows.Forms.Label
    Public WithEvents _lblPsp_9 As System.Windows.Forms.Label
    Public WithEvents _lblPsp_8 As System.Windows.Forms.Label
    Public WithEvents _lblPsp_7 As System.Windows.Forms.Label
    Public WithEvents _lblPsp_6 As System.Windows.Forms.Label
    Public WithEvents _lblPsp_5 As System.Windows.Forms.Label
    Public WithEvents _lblPsp_2 As System.Windows.Forms.Label
    Public WithEvents _lblPsp_1 As System.Windows.Forms.Label
    Public WithEvents _lblPsp_0 As System.Windows.Forms.Label
    Public WithEvents _lblPsp_3 As System.Windows.Forms.Label
    Public WithEvents _lblPsp_4 As System.Windows.Forms.Label
    Public WithEvents Frame2 As System.Windows.Forms.GroupBox
    Public WithEvents Label4 As System.Windows.Forms.Label
    Public WithEvents Frame8 As System.Windows.Forms.GroupBox
    Public WithEvents Combo1 As System.Windows.Forms.ComboBox
    Public WithEvents _txtMat_1 As System.Windows.Forms.TextBox
    Public WithEvents _lblMat_1 As System.Windows.Forms.Label
    Public WithEvents Frame7 As System.Windows.Forms.Panel
    Public WithEvents cmdAggiorna As System.Windows.Forms.Button
    Public WithEvents cmdCancel As System.Windows.Forms.Button
    Public WithEvents cmdOK As System.Windows.Forms.Button
    Public WithEvents FramePict As System.Windows.Forms.Panel
    Public WithEvents PictHelp As System.Windows.Forms.PictureBox
    Public WithEvents cmbTipo As System.Windows.Forms.ComboBox
    Public WithEvents lstFinoA As System.Windows.Forms.ListBox
    Public WithEvents cmbFinoA As System.Windows.Forms.ComboBox
    Public WithEvents cmbLato As System.Windows.Forms.ComboBox
    Public WithEvents lstSuChi As System.Windows.Forms.ListBox
    Public WithEvents cmbPredef As System.Windows.Forms.ComboBox
    Public WithEvents _cmbCodPos_4 As System.Windows.Forms.ComboBox
    Public WithEvents _cmbCodPos_3 As System.Windows.Forms.ComboBox
    Public WithEvents _cmbCodPos_2 As System.Windows.Forms.ComboBox
    Public WithEvents _cmbCodPos_1 As System.Windows.Forms.ComboBox
    Public WithEvents _cmbCodPos_0 As System.Windows.Forms.ComboBox
    Public WithEvents cmbSuChi As System.Windows.Forms.ComboBox
    Public WithEvents lblFinoA As System.Windows.Forms.Label
    Public WithEvents lblLato As System.Windows.Forms.Label
    Public WithEvents lblPredef As System.Windows.Forms.Label
    Public WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents _lblSuChi_4 As System.Windows.Forms.Label
    Public WithEvents _lblSuChi_3 As System.Windows.Forms.Label
    Public WithEvents _lblSuChi_2 As System.Windows.Forms.Label
    Public WithEvents _lblSuChi_0 As System.Windows.Forms.Label
    Public WithEvents _lblSuChi_1 As System.Windows.Forms.Label
    Public WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents Frame4 As System.Windows.Forms.GroupBox
    Public WithEvents txtNot As System.Windows.Forms.TextBox
    Public WithEvents txtDes As System.Windows.Forms.TextBox
    Public WithEvents txtQta As System.Windows.Forms.TextBox
    Public WithEvents txtPos As System.Windows.Forms.TextBox
    Public WithEvents lblNot As System.Windows.Forms.Label
    Public WithEvents lblDes As System.Windows.Forms.Label
    Public WithEvents lblQta As System.Windows.Forms.Label
    Public WithEvents _lblPos_0 As System.Windows.Forms.Label
    Public WithEvents Frame3 As System.Windows.Forms.GroupBox
    Public WithEvents txtDen As System.Windows.Forms.TextBox
    Public WithEvents _cmbParaO_0 As System.Windows.Forms.ComboBox
    Public WithEvents option3 As System.Windows.Forms.CheckBox
    Public WithEvents option1 As System.Windows.Forms.CheckBox
    Public WithEvents _cmbPara_0 As System.Windows.Forms.ComboBox
    Public WithEvents _txtPara_0 As System.Windows.Forms.TextBox
    Public WithEvents _lblPara_0 As System.Windows.Forms.Label
    Public WithEvents Frame1 As System.Windows.Forms.GroupBox
    Public WithEvents _txtMat_0 As System.Windows.Forms.TextBox
    Public WithEvents Direzione As System.Windows.Forms.ComboBox
    Public WithEvents Frame6 As System.Windows.Forms.GroupBox
    Public WithEvents txtTipo As System.Windows.Forms.Label
    Public WithEvents lblTipo As System.Windows.Forms.Label
    Public WithEvents lblDen As System.Windows.Forms.Label
    Public WithEvents _lblMat_0 As System.Windows.Forms.Label
    Public Option2 As New System.Collections.Generic.Dictionary(Of Integer, RadioButton)
    Public txtMat As New System.Collections.Generic.Dictionary(Of Integer, TextBox)
    Public txtPsp As New System.Collections.Generic.Dictionary(Of Integer, TextBox)
    'NOTA: la routine seguente è richiesta dalla progettazione Windows Form.
    'Può essere modificata utilizzando la finestra di progettazione Windows Form.
    'Non modificarla mediante l'editor di codice.
    Friend WithEvents DBCmbTipo As System.Windows.Forms.ComboBox
    Friend WithEvents Picture1 As System.Windows.Forms.PictureBox
    Friend WithEvents _cmdMat_1 As System.Windows.Forms.Button
    Friend WithEvents _cmdMat_0 As System.Windows.Forms.Button
    Friend WithEvents cmdSvil As System.Windows.Forms.Button
    Friend WithEvents cmdPrezzo As System.Windows.Forms.Button
    Friend WithEvents cmdZoom As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmDati))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me._cmdMat_1 = New System.Windows.Forms.Button
        Me._cmdMat_0 = New System.Windows.Forms.Button
        Me.cmdPrezzo = New System.Windows.Forms.Button
        Me.cmdSvil = New System.Windows.Forms.Button
        Me.cmdZoom = New System.Windows.Forms.Button
        Me.Frame5 = New System.Windows.Forms.GroupBox
        Me._Option2_0 = New System.Windows.Forms.RadioButton
        Me._Option2_1 = New System.Windows.Forms.RadioButton
        Me.Frame2 = New System.Windows.Forms.GroupBox
        Me.lstLE = New System.Windows.Forms.ListBox
        Me.cmbLE = New System.Windows.Forms.ComboBox
        Me._txtPsp_14 = New System.Windows.Forms.TextBox
        Me._txtPsp_13 = New System.Windows.Forms.TextBox
        Me._txtPsp_12 = New System.Windows.Forms.TextBox
        Me._txtPsp_11 = New System.Windows.Forms.TextBox
        Me._txtPsp_10 = New System.Windows.Forms.TextBox
        Me._txtPsp_9 = New System.Windows.Forms.TextBox
        Me._txtPsp_8 = New System.Windows.Forms.TextBox
        Me._txtPsp_7 = New System.Windows.Forms.TextBox
        Me._txtPsp_6 = New System.Windows.Forms.TextBox
        Me._txtPsp_5 = New System.Windows.Forms.TextBox
        Me._txtPsp_4 = New System.Windows.Forms.TextBox
        Me._txtPsp_3 = New System.Windows.Forms.TextBox
        Me._txtPsp_2 = New System.Windows.Forms.TextBox
        Me._txtPsp_1 = New System.Windows.Forms.TextBox
        Me._txtPsp_0 = New System.Windows.Forms.TextBox
        Me._lblPsp_14 = New System.Windows.Forms.Label
        Me._lblPsp_13 = New System.Windows.Forms.Label
        Me._lblPsp_12 = New System.Windows.Forms.Label
        Me._lblPsp_11 = New System.Windows.Forms.Label
        Me._lblPsp_10 = New System.Windows.Forms.Label
        Me._lblPsp_9 = New System.Windows.Forms.Label
        Me._lblPsp_8 = New System.Windows.Forms.Label
        Me._lblPsp_7 = New System.Windows.Forms.Label
        Me._lblPsp_6 = New System.Windows.Forms.Label
        Me._lblPsp_5 = New System.Windows.Forms.Label
        Me._lblPsp_2 = New System.Windows.Forms.Label
        Me._lblPsp_1 = New System.Windows.Forms.Label
        Me._lblPsp_0 = New System.Windows.Forms.Label
        Me._lblPsp_3 = New System.Windows.Forms.Label
        Me._lblPsp_4 = New System.Windows.Forms.Label
        Me.Frame8 = New System.Windows.Forms.GroupBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Combo1 = New System.Windows.Forms.ComboBox
        Me.Frame7 = New System.Windows.Forms.Panel
        Me._lblMat_1 = New System.Windows.Forms.Label
        Me._txtMat_1 = New System.Windows.Forms.TextBox
        Me.FramePict = New System.Windows.Forms.Panel
        Me.cmdAggiorna = New System.Windows.Forms.Button
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdOK = New System.Windows.Forms.Button
        Me.PictHelp = New System.Windows.Forms.PictureBox
        Me.cmbTipo = New System.Windows.Forms.ComboBox
        Me.Frame4 = New System.Windows.Forms.GroupBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.lstFinoA = New System.Windows.Forms.ListBox
        Me.cmbFinoA = New System.Windows.Forms.ComboBox
        Me.cmbLato = New System.Windows.Forms.ComboBox
        Me.lstSuChi = New System.Windows.Forms.ListBox
        Me.cmbPredef = New System.Windows.Forms.ComboBox
        Me._cmbCodPos_4 = New System.Windows.Forms.ComboBox
        Me._cmbCodPos_3 = New System.Windows.Forms.ComboBox
        Me._cmbCodPos_2 = New System.Windows.Forms.ComboBox
        Me._cmbCodPos_1 = New System.Windows.Forms.ComboBox
        Me._cmbCodPos_0 = New System.Windows.Forms.ComboBox
        Me.cmbSuChi = New System.Windows.Forms.ComboBox
        Me.lblFinoA = New System.Windows.Forms.Label
        Me.lblLato = New System.Windows.Forms.Label
        Me.lblPredef = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me._lblSuChi_4 = New System.Windows.Forms.Label
        Me._lblSuChi_3 = New System.Windows.Forms.Label
        Me._lblSuChi_2 = New System.Windows.Forms.Label
        Me._lblSuChi_0 = New System.Windows.Forms.Label
        Me._lblSuChi_1 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Frame3 = New System.Windows.Forms.GroupBox
        Me.txtNot = New System.Windows.Forms.TextBox
        Me.txtDes = New System.Windows.Forms.TextBox
        Me.txtQta = New System.Windows.Forms.TextBox
        Me.txtPos = New System.Windows.Forms.TextBox
        Me.lblNot = New System.Windows.Forms.Label
        Me.lblDes = New System.Windows.Forms.Label
        Me.lblQta = New System.Windows.Forms.Label
        Me._lblPos_0 = New System.Windows.Forms.Label
        Me.txtDen = New System.Windows.Forms.TextBox
        Me.Frame1 = New System.Windows.Forms.GroupBox
        Me._cmbParaO_0 = New System.Windows.Forms.ComboBox
        Me.option3 = New System.Windows.Forms.CheckBox
        Me.option1 = New System.Windows.Forms.CheckBox
        Me._cmbPara_0 = New System.Windows.Forms.ComboBox
        Me._txtPara_0 = New System.Windows.Forms.TextBox
        Me._lblPara_0 = New System.Windows.Forms.Label
        Me._txtMat_0 = New System.Windows.Forms.TextBox
        Me.Frame6 = New System.Windows.Forms.GroupBox
        Me.Direzione = New System.Windows.Forms.ComboBox
        Me.txtTipo = New System.Windows.Forms.Label
        Me.lblTipo = New System.Windows.Forms.Label
        Me.lblDen = New System.Windows.Forms.Label
        Me._lblMat_0 = New System.Windows.Forms.Label
        Me.DBCmbTipo = New System.Windows.Forms.ComboBox
        Me.Picture1 = New System.Windows.Forms.PictureBox
        Me.Frame5.SuspendLayout()
        Me.Frame2.SuspendLayout()
        Me.Frame8.SuspendLayout()
        Me.Frame7.SuspendLayout()
        Me.FramePict.SuspendLayout()
        Me.Frame4.SuspendLayout()
        Me.Frame3.SuspendLayout()
        Me.Frame1.SuspendLayout()
        Me.Frame6.SuspendLayout()
        Me.SuspendLayout()
        '
        '_cmdMat_1
        '
        Me._cmdMat_1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me._cmdMat_1.Image = CType(resources.GetObject("_cmdMat_1.Image"), System.Drawing.Image)
        Me._cmdMat_1.Location = New System.Drawing.Point(304, 5)
        Me._cmdMat_1.Name = "_cmdMat_1"
        Me._cmdMat_1.Size = New System.Drawing.Size(22, 22)
        Me._cmdMat_1.TabIndex = 94
        Me.ToolTip1.SetToolTip(Me._cmdMat_1, "Premere qui per accedere alla libreria materiali")
        '
        '_cmdMat_0
        '
        Me._cmdMat_0.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me._cmdMat_0.Image = CType(resources.GetObject("_cmdMat_0.Image"), System.Drawing.Image)
        Me._cmdMat_0.Location = New System.Drawing.Point(300, 0)
        Me._cmdMat_0.Name = "_cmdMat_0"
        Me._cmdMat_0.Size = New System.Drawing.Size(22, 22)
        Me._cmdMat_0.TabIndex = 99
        Me.ToolTip1.SetToolTip(Me._cmdMat_0, "Premere qui per accedere alla libreria materiali")
        '
        'cmdPrezzo
        '
        Me.cmdPrezzo.BackColor = System.Drawing.SystemColors.Control
        Me.cmdPrezzo.Image = CType(resources.GetObject("cmdPrezzo.Image"), System.Drawing.Image)
        Me.cmdPrezzo.Location = New System.Drawing.Point(64, 80)
        Me.cmdPrezzo.Name = "cmdPrezzo"
        Me.cmdPrezzo.Size = New System.Drawing.Size(24, 24)
        Me.cmdPrezzo.TabIndex = 104
        Me.ToolTip1.SetToolTip(Me.cmdPrezzo, "Elabora i costi di approvvigionamento")
        '
        'cmdSvil
        '
        Me.cmdSvil.BackColor = System.Drawing.SystemColors.Control
        Me.cmdSvil.Image = CType(resources.GetObject("cmdSvil.Image"), System.Drawing.Image)
        Me.cmdSvil.Location = New System.Drawing.Point(64, 56)
        Me.cmdSvil.Name = "cmdSvil"
        Me.cmdSvil.Size = New System.Drawing.Size(24, 24)
        Me.cmdSvil.TabIndex = 103
        Me.ToolTip1.SetToolTip(Me.cmdSvil, "Elabora il lamieramento, se applicabile, e calcola il peso lordo")
        '
        'cmdZoom
        '
        Me.cmdZoom.BackColor = System.Drawing.SystemColors.Control
        Me.cmdZoom.Image = CType(resources.GetObject("cmdZoom.Image"), System.Drawing.Image)
        Me.cmdZoom.Location = New System.Drawing.Point(8, 4)
        Me.cmdZoom.Name = "cmdZoom"
        Me.cmdZoom.Size = New System.Drawing.Size(24, 24)
        Me.cmdZoom.TabIndex = 105
        Me.ToolTip1.SetToolTip(Me.cmdZoom, "definizione di una finestra di zoom sul disegno")
        '
        'Frame5
        '
        Me.Frame5.BackColor = System.Drawing.SystemColors.Control
        Me.Frame5.Controls.Add(Me._Option2_0)
        Me.Frame5.Controls.Add(Me._Option2_1)
        Me.Frame5.Font = New System.Drawing.Font("Arial", 8.4!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame5.Location = New System.Drawing.Point(0, 224)
        Me.Frame5.Name = "Frame5"
        Me.Frame5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame5.Size = New System.Drawing.Size(145, 57)
        Me.Frame5.TabIndex = 80
        Me.Frame5.TabStop = False
        Me.Frame5.Text = "Rappresentazione"
        '
        '_Option2_0
        '
        Me._Option2_0.BackColor = System.Drawing.SystemColors.Control
        Me._Option2_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option2_0.Font = New System.Drawing.Font("Arial", 8.4!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Option2_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Option2.Add(0, Me._Option2_0)
        Me._Option2_0.Location = New System.Drawing.Point(16, 16)
        Me._Option2_0.Name = "_Option2_0"
        Me._Option2_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option2_0.Size = New System.Drawing.Size(73, 17)
        Me._Option2_0.TabIndex = 82
        Me._Option2_0.TabStop = True
        Me._Option2_0.Text = "In vista"
        '
        '_Option2_1
        '
        Me._Option2_1.BackColor = System.Drawing.SystemColors.Control
        Me._Option2_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option2_1.Font = New System.Drawing.Font("Arial", 8.4!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Option2_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Option2.Add(1, Me._Option2_1)
        Me._Option2_1.Location = New System.Drawing.Point(16, 32)
        Me._Option2_1.Name = "_Option2_1"
        Me._Option2_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option2_1.Size = New System.Drawing.Size(81, 17)
        Me._Option2_1.TabIndex = 81
        Me._Option2_1.TabStop = True
        Me._Option2_1.Text = "In sezione"
        '
        'Frame2
        '
        Me.Frame2.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(128, Byte))
        Me.Frame2.Controls.Add(Me.cmdPrezzo)
        Me.Frame2.Controls.Add(Me.cmdSvil)
        Me.Frame2.Controls.Add(Me.lstLE)
        Me.Frame2.Controls.Add(Me.cmbLE)
        Me.Frame2.Controls.Add(Me._txtPsp_14)
        Me.Frame2.Controls.Add(Me._txtPsp_13)
        Me.Frame2.Controls.Add(Me._txtPsp_12)
        Me.Frame2.Controls.Add(Me._txtPsp_11)
        Me.Frame2.Controls.Add(Me._txtPsp_10)
        Me.Frame2.Controls.Add(Me._txtPsp_9)
        Me.Frame2.Controls.Add(Me._txtPsp_8)
        Me.Frame2.Controls.Add(Me._txtPsp_7)
        Me.Frame2.Controls.Add(Me._txtPsp_6)
        Me.Frame2.Controls.Add(Me._txtPsp_5)
        Me.Frame2.Controls.Add(Me._txtPsp_4)
        Me.Frame2.Controls.Add(Me._txtPsp_3)
        Me.Frame2.Controls.Add(Me._txtPsp_2)
        Me.Frame2.Controls.Add(Me._txtPsp_1)
        Me.Frame2.Controls.Add(Me._txtPsp_0)
        Me.Frame2.Controls.Add(Me._lblPsp_14)
        Me.Frame2.Controls.Add(Me._lblPsp_13)
        Me.Frame2.Controls.Add(Me._lblPsp_12)
        Me.Frame2.Controls.Add(Me._lblPsp_11)
        Me.Frame2.Controls.Add(Me._lblPsp_10)
        Me.Frame2.Controls.Add(Me._lblPsp_9)
        Me.Frame2.Controls.Add(Me._lblPsp_8)
        Me.Frame2.Controls.Add(Me._lblPsp_7)
        Me.Frame2.Controls.Add(Me._lblPsp_6)
        Me.Frame2.Controls.Add(Me._lblPsp_5)
        Me.Frame2.Controls.Add(Me._lblPsp_2)
        Me.Frame2.Controls.Add(Me._lblPsp_1)
        Me.Frame2.Controls.Add(Me._lblPsp_0)
        Me.Frame2.Controls.Add(Me._lblPsp_3)
        Me.Frame2.Controls.Add(Me._lblPsp_4)
        Me.Frame2.Font = New System.Drawing.Font("Arial", 8.4!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame2.Location = New System.Drawing.Point(0, 224)
        Me.Frame2.Name = "Frame2"
        Me.Frame2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame2.Size = New System.Drawing.Size(401, 105)
        Me.Frame2.TabIndex = 9
        Me.Frame2.TabStop = False
        Me.Frame2.Text = "Calcolo pesi e costi"
        '
        'lstLE
        '
        Me.lstLE.BackColor = System.Drawing.SystemColors.Window
        Me.lstLE.Cursor = System.Windows.Forms.Cursors.Default
        Me.lstLE.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lstLE.ItemHeight = 14
        Me.lstLE.Location = New System.Drawing.Point(336, 32)
        Me.lstLE.Name = "lstLE"
        Me.lstLE.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lstLE.Size = New System.Drawing.Size(25, 18)
        Me.lstLE.TabIndex = 101
        Me.lstLE.Visible = False
        '
        'cmbLE
        '
        Me.cmbLE.BackColor = System.Drawing.SystemColors.Window
        Me.cmbLE.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbLE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLE.DropDownWidth = 160
        Me.cmbLE.Font = New System.Drawing.Font("Arial", 8.4!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbLE.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbLE.Location = New System.Drawing.Point(320, 8)
        Me.cmbLE.Name = "cmbLE"
        Me.cmbLE.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbLE.Size = New System.Drawing.Size(73, 22)
        Me.cmbLE.TabIndex = 99
        '
        '_txtPsp_14
        '
        Me._txtPsp_14.AcceptsReturn = True
        Me._txtPsp_14.AutoSize = False
        Me._txtPsp_14.BackColor = System.Drawing.SystemColors.Window
        Me._txtPsp_14.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtPsp_14.Font = New System.Drawing.Font("Arial", 8.4!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._txtPsp_14.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtPsp.Add(14, Me._txtPsp_14)
        Me._txtPsp_14.Location = New System.Drawing.Point(352, 80)
        Me._txtPsp_14.MaxLength = 0
        Me._txtPsp_14.Multiline = True
        Me._txtPsp_14.Name = "_txtPsp_14"
        Me._txtPsp_14.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtPsp_14.Size = New System.Drawing.Size(41, 19)
        Me._txtPsp_14.TabIndex = 39
        Me._txtPsp_14.Tag = ""
        Me._txtPsp_14.Text = "Text1"
        Me._txtPsp_14.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        '_txtPsp_13
        '
        Me._txtPsp_13.AcceptsReturn = True
        Me._txtPsp_13.AutoSize = False
        Me._txtPsp_13.BackColor = System.Drawing.SystemColors.Window
        Me._txtPsp_13.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtPsp_13.Font = New System.Drawing.Font("Arial", 8.4!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._txtPsp_13.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtPsp.Add(13, Me._txtPsp_13)
        Me._txtPsp_13.Location = New System.Drawing.Point(352, 64)
        Me._txtPsp_13.MaxLength = 0
        Me._txtPsp_13.Multiline = True
        Me._txtPsp_13.Name = "_txtPsp_13"
        Me._txtPsp_13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtPsp_13.Size = New System.Drawing.Size(41, 19)
        Me._txtPsp_13.TabIndex = 38
        Me._txtPsp_13.Tag = ""
        Me._txtPsp_13.Text = "Text1"
        Me._txtPsp_13.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        '_txtPsp_12
        '
        Me._txtPsp_12.AcceptsReturn = True
        Me._txtPsp_12.AutoSize = False
        Me._txtPsp_12.BackColor = System.Drawing.SystemColors.Window
        Me._txtPsp_12.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtPsp_12.Font = New System.Drawing.Font("Arial", 8.4!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._txtPsp_12.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtPsp.Add(12, Me._txtPsp_12)
        Me._txtPsp_12.Location = New System.Drawing.Point(352, 48)
        Me._txtPsp_12.MaxLength = 0
        Me._txtPsp_12.Multiline = True
        Me._txtPsp_12.Name = "_txtPsp_12"
        Me._txtPsp_12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtPsp_12.Size = New System.Drawing.Size(41, 19)
        Me._txtPsp_12.TabIndex = 37
        Me._txtPsp_12.Tag = ""
        Me._txtPsp_12.Text = "Text1"
        Me._txtPsp_12.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        '_txtPsp_11
        '
        Me._txtPsp_11.AcceptsReturn = True
        Me._txtPsp_11.AutoSize = False
        Me._txtPsp_11.BackColor = System.Drawing.SystemColors.Window
        Me._txtPsp_11.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtPsp_11.Font = New System.Drawing.Font("Arial", 8.4!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._txtPsp_11.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtPsp.Add(11, Me._txtPsp_11)
        Me._txtPsp_11.Location = New System.Drawing.Point(184, 80)
        Me._txtPsp_11.MaxLength = 0
        Me._txtPsp_11.Multiline = True
        Me._txtPsp_11.Name = "_txtPsp_11"
        Me._txtPsp_11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtPsp_11.Size = New System.Drawing.Size(41, 19)
        Me._txtPsp_11.TabIndex = 31
        Me._txtPsp_11.Tag = ""
        Me._txtPsp_11.Text = "Text1"
        Me._txtPsp_11.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        '_txtPsp_10
        '
        Me._txtPsp_10.AcceptsReturn = True
        Me._txtPsp_10.AutoSize = False
        Me._txtPsp_10.BackColor = System.Drawing.SystemColors.Window
        Me._txtPsp_10.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtPsp_10.Font = New System.Drawing.Font("Arial", 8.4!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._txtPsp_10.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtPsp.Add(10, Me._txtPsp_10)
        Me._txtPsp_10.Location = New System.Drawing.Point(136, 80)
        Me._txtPsp_10.MaxLength = 0
        Me._txtPsp_10.Multiline = True
        Me._txtPsp_10.Name = "_txtPsp_10"
        Me._txtPsp_10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtPsp_10.Size = New System.Drawing.Size(41, 19)
        Me._txtPsp_10.TabIndex = 30
        Me._txtPsp_10.Tag = ""
        Me._txtPsp_10.Text = "Text1"
        Me._txtPsp_10.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        '_txtPsp_9
        '
        Me._txtPsp_9.AcceptsReturn = True
        Me._txtPsp_9.AutoSize = False
        Me._txtPsp_9.BackColor = System.Drawing.SystemColors.Window
        Me._txtPsp_9.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtPsp_9.Font = New System.Drawing.Font("Arial", 8.4!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._txtPsp_9.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtPsp.Add(9, Me._txtPsp_9)
        Me._txtPsp_9.Location = New System.Drawing.Point(88, 80)
        Me._txtPsp_9.MaxLength = 0
        Me._txtPsp_9.Multiline = True
        Me._txtPsp_9.Name = "_txtPsp_9"
        Me._txtPsp_9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtPsp_9.Size = New System.Drawing.Size(41, 19)
        Me._txtPsp_9.TabIndex = 29
        Me._txtPsp_9.Tag = ""
        Me._txtPsp_9.Text = "Text1"
        Me._txtPsp_9.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        '_txtPsp_8
        '
        Me._txtPsp_8.AcceptsReturn = True
        Me._txtPsp_8.AutoSize = False
        Me._txtPsp_8.BackColor = System.Drawing.SystemColors.Window
        Me._txtPsp_8.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtPsp_8.Font = New System.Drawing.Font("Arial", 8.4!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._txtPsp_8.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtPsp.Add(8, Me._txtPsp_8)
        Me._txtPsp_8.Location = New System.Drawing.Point(184, 64)
        Me._txtPsp_8.MaxLength = 0
        Me._txtPsp_8.Multiline = True
        Me._txtPsp_8.Name = "_txtPsp_8"
        Me._txtPsp_8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtPsp_8.Size = New System.Drawing.Size(41, 19)
        Me._txtPsp_8.TabIndex = 26
        Me._txtPsp_8.Tag = ""
        Me._txtPsp_8.Text = "Text1"
        Me._txtPsp_8.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        '_txtPsp_7
        '
        Me._txtPsp_7.AcceptsReturn = True
        Me._txtPsp_7.AutoSize = False
        Me._txtPsp_7.BackColor = System.Drawing.SystemColors.Window
        Me._txtPsp_7.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtPsp_7.Font = New System.Drawing.Font("Arial", 8.4!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._txtPsp_7.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtPsp.Add(7, Me._txtPsp_7)
        Me._txtPsp_7.Location = New System.Drawing.Point(136, 64)
        Me._txtPsp_7.MaxLength = 0
        Me._txtPsp_7.Multiline = True
        Me._txtPsp_7.Name = "_txtPsp_7"
        Me._txtPsp_7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtPsp_7.Size = New System.Drawing.Size(41, 19)
        Me._txtPsp_7.TabIndex = 25
        Me._txtPsp_7.Tag = ""
        Me._txtPsp_7.Text = "Text1"
        Me._txtPsp_7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        '_txtPsp_6
        '
        Me._txtPsp_6.AcceptsReturn = True
        Me._txtPsp_6.AutoSize = False
        Me._txtPsp_6.BackColor = System.Drawing.SystemColors.Window
        Me._txtPsp_6.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtPsp_6.Font = New System.Drawing.Font("Arial", 8.4!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._txtPsp_6.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtPsp.Add(6, Me._txtPsp_6)
        Me._txtPsp_6.Location = New System.Drawing.Point(88, 64)
        Me._txtPsp_6.MaxLength = 0
        Me._txtPsp_6.Multiline = True
        Me._txtPsp_6.Name = "_txtPsp_6"
        Me._txtPsp_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtPsp_6.Size = New System.Drawing.Size(41, 19)
        Me._txtPsp_6.TabIndex = 24
        Me._txtPsp_6.Tag = ""
        Me._txtPsp_6.Text = "Text1"
        Me._txtPsp_6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        '_txtPsp_5
        '
        Me._txtPsp_5.AcceptsReturn = True
        Me._txtPsp_5.AutoSize = False
        Me._txtPsp_5.BackColor = System.Drawing.SystemColors.Window
        Me._txtPsp_5.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtPsp_5.Font = New System.Drawing.Font("Arial", 8.4!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._txtPsp_5.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtPsp.Add(5, Me._txtPsp_5)
        Me._txtPsp_5.Location = New System.Drawing.Point(184, 48)
        Me._txtPsp_5.MaxLength = 0
        Me._txtPsp_5.Multiline = True
        Me._txtPsp_5.Name = "_txtPsp_5"
        Me._txtPsp_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtPsp_5.Size = New System.Drawing.Size(41, 19)
        Me._txtPsp_5.TabIndex = 21
        Me._txtPsp_5.Tag = ""
        Me._txtPsp_5.Text = "Text1"
        Me._txtPsp_5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        '_txtPsp_4
        '
        Me._txtPsp_4.AcceptsReturn = True
        Me._txtPsp_4.AutoSize = False
        Me._txtPsp_4.BackColor = System.Drawing.SystemColors.Window
        Me._txtPsp_4.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtPsp_4.Font = New System.Drawing.Font("Arial", 8.4!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._txtPsp_4.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtPsp.Add(4, Me._txtPsp_4)
        Me._txtPsp_4.Location = New System.Drawing.Point(136, 48)
        Me._txtPsp_4.MaxLength = 0
        Me._txtPsp_4.Multiline = True
        Me._txtPsp_4.Name = "_txtPsp_4"
        Me._txtPsp_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtPsp_4.Size = New System.Drawing.Size(41, 19)
        Me._txtPsp_4.TabIndex = 20
        Me._txtPsp_4.Tag = ""
        Me._txtPsp_4.Text = "Text1"
        Me._txtPsp_4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        '_txtPsp_3
        '
        Me._txtPsp_3.AcceptsReturn = True
        Me._txtPsp_3.AutoSize = False
        Me._txtPsp_3.BackColor = System.Drawing.SystemColors.Window
        Me._txtPsp_3.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtPsp_3.Font = New System.Drawing.Font("Arial", 8.4!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._txtPsp_3.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtPsp.Add(3, Me._txtPsp_3)
        Me._txtPsp_3.Location = New System.Drawing.Point(88, 48)
        Me._txtPsp_3.MaxLength = 0
        Me._txtPsp_3.Multiline = True
        Me._txtPsp_3.Name = "_txtPsp_3"
        Me._txtPsp_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtPsp_3.Size = New System.Drawing.Size(41, 19)
        Me._txtPsp_3.TabIndex = 19
        Me._txtPsp_3.Tag = ""
        Me._txtPsp_3.Text = "Text1"
        Me._txtPsp_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        '_txtPsp_2
        '
        Me._txtPsp_2.AcceptsReturn = True
        Me._txtPsp_2.AutoSize = False
        Me._txtPsp_2.BackColor = System.Drawing.SystemColors.Window
        Me._txtPsp_2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtPsp_2.Font = New System.Drawing.Font("Arial", 8.4!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._txtPsp_2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtPsp.Add(2, Me._txtPsp_2)
        Me._txtPsp_2.Location = New System.Drawing.Point(184, 32)
        Me._txtPsp_2.MaxLength = 0
        Me._txtPsp_2.Multiline = True
        Me._txtPsp_2.Name = "_txtPsp_2"
        Me._txtPsp_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtPsp_2.Size = New System.Drawing.Size(41, 19)
        Me._txtPsp_2.TabIndex = 13
        Me._txtPsp_2.Tag = ""
        Me._txtPsp_2.Text = "Text1"
        Me._txtPsp_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        '_txtPsp_1
        '
        Me._txtPsp_1.AcceptsReturn = True
        Me._txtPsp_1.AutoSize = False
        Me._txtPsp_1.BackColor = System.Drawing.SystemColors.Window
        Me._txtPsp_1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtPsp_1.Font = New System.Drawing.Font("Arial", 8.4!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._txtPsp_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtPsp.Add(1, Me._txtPsp_1)
        Me._txtPsp_1.Location = New System.Drawing.Point(136, 32)
        Me._txtPsp_1.MaxLength = 0
        Me._txtPsp_1.Multiline = True
        Me._txtPsp_1.Name = "_txtPsp_1"
        Me._txtPsp_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtPsp_1.Size = New System.Drawing.Size(41, 19)
        Me._txtPsp_1.TabIndex = 12
        Me._txtPsp_1.Tag = ""
        Me._txtPsp_1.Text = "Text1"
        Me._txtPsp_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        '_txtPsp_0
        '
        Me._txtPsp_0.AcceptsReturn = True
        Me._txtPsp_0.AutoSize = False
        Me._txtPsp_0.BackColor = System.Drawing.SystemColors.Window
        Me._txtPsp_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtPsp_0.Font = New System.Drawing.Font("Arial", 8.4!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._txtPsp_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtPsp.Add(0, Me._txtPsp_0)
        Me._txtPsp_0.Location = New System.Drawing.Point(88, 32)
        Me._txtPsp_0.MaxLength = 0
        Me._txtPsp_0.Multiline = True
        Me._txtPsp_0.Name = "_txtPsp_0"
        Me._txtPsp_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtPsp_0.Size = New System.Drawing.Size(41, 19)
        Me._txtPsp_0.TabIndex = 11
        Me._txtPsp_0.Tag = ""
        Me._txtPsp_0.Text = "Text1"
        Me._txtPsp_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        '_lblPsp_14
        '
        Me._lblPsp_14.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(128, Byte))
        Me._lblPsp_14.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblPsp_14.Font = New System.Drawing.Font("Arial", 8.4!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblPsp_14.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblPsp_14.Location = New System.Drawing.Point(232, 8)
        Me._lblPsp_14.Name = "_lblPsp_14"
        Me._lblPsp_14.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblPsp_14.Size = New System.Drawing.Size(81, 17)
        Me._lblPsp_14.TabIndex = 100
        Me._lblPsp_14.Text = "Lavoraz. esterna"
        '
        '_lblPsp_13
        '
        Me._lblPsp_13.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(128, Byte))
        Me._lblPsp_13.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblPsp_13.Font = New System.Drawing.Font("Arial", 8.4!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblPsp_13.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblPsp_13.Location = New System.Drawing.Point(280, 80)
        Me._lblPsp_13.Name = "_lblPsp_13"
        Me._lblPsp_13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblPsp_13.Size = New System.Drawing.Size(81, 17)
        Me._lblPsp_13.TabIndex = 36
        Me._lblPsp_13.Text = "Costo "
        '
        '_lblPsp_12
        '
        Me._lblPsp_12.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(128, Byte))
        Me._lblPsp_12.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblPsp_12.Font = New System.Drawing.Font("Arial", 8.4!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblPsp_12.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblPsp_12.Location = New System.Drawing.Point(280, 64)
        Me._lblPsp_12.Name = "_lblPsp_12"
        Me._lblPsp_12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblPsp_12.Size = New System.Drawing.Size(81, 17)
        Me._lblPsp_12.TabIndex = 35
        Me._lblPsp_12.Text = "Peso lordo tot."
        '
        '_lblPsp_11
        '
        Me._lblPsp_11.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(128, Byte))
        Me._lblPsp_11.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblPsp_11.Font = New System.Drawing.Font("Arial", 8.4!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblPsp_11.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblPsp_11.Location = New System.Drawing.Point(280, 48)
        Me._lblPsp_11.Name = "_lblPsp_11"
        Me._lblPsp_11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblPsp_11.Size = New System.Drawing.Size(104, 17)
        Me._lblPsp_11.TabIndex = 34
        Me._lblPsp_11.Text = "Peso netto tot."
        '
        '_lblPsp_10
        '
        Me._lblPsp_10.BackColor = System.Drawing.Color.FromArgb(CType(224, Byte), CType(224, Byte), CType(224, Byte))
        Me._lblPsp_10.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblPsp_10.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblPsp_10.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblPsp_10.Location = New System.Drawing.Point(232, 80)
        Me._lblPsp_10.Name = "_lblPsp_10"
        Me._lblPsp_10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblPsp_10.Size = New System.Drawing.Size(40, 17)
        Me._lblPsp_10.TabIndex = 32
        Me._lblPsp_10.Text = "EUR/Kg"
        Me._lblPsp_10.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        '_lblPsp_9
        '
        Me._lblPsp_9.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(128, Byte))
        Me._lblPsp_9.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblPsp_9.Font = New System.Drawing.Font("Arial", 8.4!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblPsp_9.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblPsp_9.Location = New System.Drawing.Point(8, 80)
        Me._lblPsp_9.Name = "_lblPsp_9"
        Me._lblPsp_9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblPsp_9.Size = New System.Drawing.Size(49, 17)
        Me._lblPsp_9.TabIndex = 28
        Me._lblPsp_9.Text = "Costi"
        '
        '_lblPsp_8
        '
        Me._lblPsp_8.BackColor = System.Drawing.Color.FromArgb(CType(224, Byte), CType(224, Byte), CType(224, Byte))
        Me._lblPsp_8.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblPsp_8.Font = New System.Drawing.Font("Arial", 8.4!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblPsp_8.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblPsp_8.Location = New System.Drawing.Point(232, 64)
        Me._lblPsp_8.Name = "_lblPsp_8"
        Me._lblPsp_8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblPsp_8.Size = New System.Drawing.Size(41, 17)
        Me._lblPsp_8.TabIndex = 27
        Me._lblPsp_8.Text = "Kg"
        Me._lblPsp_8.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        '_lblPsp_7
        '
        Me._lblPsp_7.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(128, Byte))
        Me._lblPsp_7.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblPsp_7.Font = New System.Drawing.Font("Arial", 8.4!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblPsp_7.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblPsp_7.Location = New System.Drawing.Point(8, 64)
        Me._lblPsp_7.Name = "_lblPsp_7"
        Me._lblPsp_7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblPsp_7.Size = New System.Drawing.Size(81, 17)
        Me._lblPsp_7.TabIndex = 23
        Me._lblPsp_7.Text = "Peso lordo"
        '
        '_lblPsp_6
        '
        Me._lblPsp_6.BackColor = System.Drawing.Color.FromArgb(CType(224, Byte), CType(224, Byte), CType(224, Byte))
        Me._lblPsp_6.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblPsp_6.Font = New System.Drawing.Font("Arial", 8.4!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblPsp_6.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblPsp_6.Location = New System.Drawing.Point(232, 48)
        Me._lblPsp_6.Name = "_lblPsp_6"
        Me._lblPsp_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblPsp_6.Size = New System.Drawing.Size(41, 17)
        Me._lblPsp_6.TabIndex = 22
        Me._lblPsp_6.Text = "Kg"
        Me._lblPsp_6.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        '_lblPsp_5
        '
        Me._lblPsp_5.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(128, Byte))
        Me._lblPsp_5.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblPsp_5.Font = New System.Drawing.Font("Arial", 8.4!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblPsp_5.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblPsp_5.Location = New System.Drawing.Point(8, 48)
        Me._lblPsp_5.Name = "_lblPsp_5"
        Me._lblPsp_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblPsp_5.Size = New System.Drawing.Size(81, 17)
        Me._lblPsp_5.TabIndex = 18
        Me._lblPsp_5.Text = "Peso netto"
        '
        '_lblPsp_2
        '
        Me._lblPsp_2.BackColor = System.Drawing.Color.FromArgb(CType(224, Byte), CType(224, Byte), CType(224, Byte))
        Me._lblPsp_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblPsp_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblPsp_2.Location = New System.Drawing.Point(184, 16)
        Me._lblPsp_2.Name = "_lblPsp_2"
        Me._lblPsp_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblPsp_2.Size = New System.Drawing.Size(41, 13)
        Me._lblPsp_2.TabIndex = 17
        Me._lblPsp_2.Text = " M. riv2"
        '
        '_lblPsp_1
        '
        Me._lblPsp_1.BackColor = System.Drawing.Color.FromArgb(CType(224, Byte), CType(224, Byte), CType(224, Byte))
        Me._lblPsp_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblPsp_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblPsp_1.Location = New System.Drawing.Point(136, 16)
        Me._lblPsp_1.Name = "_lblPsp_1"
        Me._lblPsp_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblPsp_1.Size = New System.Drawing.Size(41, 13)
        Me._lblPsp_1.TabIndex = 16
        Me._lblPsp_1.Text = " M. riv1"
        '
        '_lblPsp_0
        '
        Me._lblPsp_0.BackColor = System.Drawing.Color.FromArgb(CType(224, Byte), CType(224, Byte), CType(224, Byte))
        Me._lblPsp_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblPsp_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblPsp_0.Location = New System.Drawing.Point(88, 16)
        Me._lblPsp_0.Name = "_lblPsp_0"
        Me._lblPsp_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblPsp_0.Size = New System.Drawing.Size(41, 14)
        Me._lblPsp_0.TabIndex = 15
        Me._lblPsp_0.Text = "M. base"
        '
        '_lblPsp_3
        '
        Me._lblPsp_3.BackColor = System.Drawing.Color.FromArgb(CType(224, Byte), CType(224, Byte), CType(224, Byte))
        Me._lblPsp_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblPsp_3.Font = New System.Drawing.Font("Arial", 8.4!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblPsp_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblPsp_3.Location = New System.Drawing.Point(232, 32)
        Me._lblPsp_3.Name = "_lblPsp_3"
        Me._lblPsp_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblPsp_3.Size = New System.Drawing.Size(41, 17)
        Me._lblPsp_3.TabIndex = 14
        Me._lblPsp_3.Text = " Kg/m3"
        '
        '_lblPsp_4
        '
        Me._lblPsp_4.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(128, Byte))
        Me._lblPsp_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblPsp_4.Font = New System.Drawing.Font("Arial", 8.4!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblPsp_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblPsp_4.Location = New System.Drawing.Point(8, 32)
        Me._lblPsp_4.Name = "_lblPsp_4"
        Me._lblPsp_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblPsp_4.Size = New System.Drawing.Size(81, 17)
        Me._lblPsp_4.TabIndex = 10
        Me._lblPsp_4.Text = "Peso specifico"
        '
        'Frame8
        '
        Me.Frame8.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(128, Byte))
        Me.Frame8.Controls.Add(Me.Label4)
        Me.Frame8.Font = New System.Drawing.Font("Arial", 8.4!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame8.Location = New System.Drawing.Point(0, 120)
        Me.Frame8.Name = "Frame8"
        Me.Frame8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame8.Size = New System.Drawing.Size(401, 105)
        Me.Frame8.TabIndex = 95
        Me.Frame8.TabStop = False
        Me.Frame8.Text = "Calcolo pesi e costi"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(128, Byte))
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(16, 24)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(360, 72)
        Me.Label4.TabIndex = 96
        Me.Label4.Text = "Questa posizione rappresenta un sottoassieme. Pertanto i pesi e costi saranno ana" & _
        "lizzati sui suoi particolari."
        '
        'Combo1
        '
        Me.Combo1.BackColor = System.Drawing.SystemColors.Window
        Me.Combo1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Combo1.Font = New System.Drawing.Font("Arial", 8.4!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Combo1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Combo1.Location = New System.Drawing.Point(96, 80)
        Me.Combo1.Name = "Combo1"
        Me.Combo1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Combo1.Size = New System.Drawing.Size(226, 22)
        Me.Combo1.TabIndex = 94
        Me.Combo1.Text = "Combo1"
        '
        'Frame7
        '
        Me.Frame7.BackColor = System.Drawing.SystemColors.Control
        Me.Frame7.Controls.Add(Me._cmdMat_1)
        Me.Frame7.Controls.Add(Me._lblMat_1)
        Me.Frame7.Controls.Add(Me._txtMat_1)
        Me.Frame7.Cursor = System.Windows.Forms.Cursors.Default
        Me.Frame7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame7.Location = New System.Drawing.Point(296, 416)
        Me.Frame7.Name = "Frame7"
        Me.Frame7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame7.Size = New System.Drawing.Size(329, 119)
        Me.Frame7.TabIndex = 90
        '
        '_lblMat_1
        '
        Me._lblMat_1.BackColor = System.Drawing.SystemColors.Window
        Me._lblMat_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._lblMat_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblMat_1.Font = New System.Drawing.Font("Arial", 8.4!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblMat_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me._lblMat_1.Location = New System.Drawing.Point(0, 5)
        Me._lblMat_1.Name = "_lblMat_1"
        Me._lblMat_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblMat_1.Size = New System.Drawing.Size(89, 21)
        Me._lblMat_1.TabIndex = 93
        Me._lblMat_1.Text = "Materiale culla"
        '
        '_txtMat_1
        '
        Me._txtMat_1.AcceptsReturn = True
        Me._txtMat_1.AutoSize = False
        Me._txtMat_1.BackColor = System.Drawing.SystemColors.Window
        Me._txtMat_1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtMat_1.Font = New System.Drawing.Font("Arial", 8.4!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._txtMat_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtMat.Add(1, Me._txtMat_1)
        Me._txtMat_1.Location = New System.Drawing.Point(92, 5)
        Me._txtMat_1.MaxLength = 0
        Me._txtMat_1.Name = "_txtMat_1"
        Me._txtMat_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtMat_1.Size = New System.Drawing.Size(203, 21)
        Me._txtMat_1.TabIndex = 91
        Me._txtMat_1.TabStop = False
        Me._txtMat_1.Text = "Text1"
        '
        'FramePict
        '
        Me.FramePict.BackColor = System.Drawing.SystemColors.Control
        Me.FramePict.Controls.Add(Me.cmdZoom)
        Me.FramePict.Controls.Add(Me.cmdAggiorna)
        Me.FramePict.Controls.Add(Me.cmdCancel)
        Me.FramePict.Controls.Add(Me.cmdOK)
        Me.FramePict.Cursor = System.Windows.Forms.Cursors.Default
        Me.FramePict.Font = New System.Drawing.Font("Arial", 8.4!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FramePict.ForeColor = System.Drawing.SystemColors.WindowText
        Me.FramePict.Location = New System.Drawing.Point(400, 360)
        Me.FramePict.Name = "FramePict"
        Me.FramePict.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.FramePict.Size = New System.Drawing.Size(331, 33)
        Me.FramePict.TabIndex = 70
        Me.FramePict.TabStop = True
        '
        'cmdAggiorna
        '
        Me.cmdAggiorna.BackColor = System.Drawing.SystemColors.Control
        Me.cmdAggiorna.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdAggiorna.Font = New System.Drawing.Font("Arial", 8.4!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAggiorna.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdAggiorna.Location = New System.Drawing.Point(40, 8)
        Me.cmdAggiorna.Name = "cmdAggiorna"
        Me.cmdAggiorna.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdAggiorna.Size = New System.Drawing.Size(65, 17)
        Me.cmdAggiorna.TabIndex = 103
        Me.cmdAggiorna.Text = "Aggiorna"
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCancel.Font = New System.Drawing.Font("Arial", 8.4!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCancel.Location = New System.Drawing.Point(176, 8)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCancel.Size = New System.Drawing.Size(49, 17)
        Me.cmdCancel.TabIndex = 78
        Me.cmdCancel.Text = "Cancel"
        '
        'cmdOK
        '
        Me.cmdOK.BackColor = System.Drawing.SystemColors.Control
        Me.cmdOK.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdOK.Font = New System.Drawing.Font("Arial", 8.4!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOK.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdOK.Location = New System.Drawing.Point(120, 8)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdOK.Size = New System.Drawing.Size(41, 17)
        Me.cmdOK.TabIndex = 72
        Me.cmdOK.Text = "OK"
        '
        'PictHelp
        '
        Me.PictHelp.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
        Me.PictHelp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictHelp.Cursor = System.Windows.Forms.Cursors.Default
        Me.PictHelp.Font = New System.Drawing.Font("Arial", 8.4!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PictHelp.ForeColor = System.Drawing.SystemColors.WindowText
        Me.PictHelp.Location = New System.Drawing.Point(680, 368)
        Me.PictHelp.Name = "PictHelp"
        Me.PictHelp.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.PictHelp.Size = New System.Drawing.Size(57, 33)
        Me.PictHelp.TabIndex = 69
        Me.PictHelp.TabStop = False
        Me.PictHelp.Visible = False
        '
        'cmbTipo
        '
        Me.cmbTipo.BackColor = System.Drawing.SystemColors.Window
        Me.cmbTipo.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipo.Font = New System.Drawing.Font("Arial", 8.4!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipo.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbTipo.Location = New System.Drawing.Point(96, 48)
        Me.cmbTipo.Name = "cmbTipo"
        Me.cmbTipo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbTipo.Size = New System.Drawing.Size(225, 22)
        Me.cmbTipo.TabIndex = 58
        Me.cmbTipo.TabStop = False
        '
        'Frame4
        '
        Me.Frame4.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(255, Byte))
        Me.Frame4.Controls.Add(Me.Label3)
        Me.Frame4.Controls.Add(Me.lstFinoA)
        Me.Frame4.Controls.Add(Me.cmbFinoA)
        Me.Frame4.Controls.Add(Me.cmbLato)
        Me.Frame4.Controls.Add(Me.lstSuChi)
        Me.Frame4.Controls.Add(Me.cmbPredef)
        Me.Frame4.Controls.Add(Me._cmbCodPos_4)
        Me.Frame4.Controls.Add(Me._cmbCodPos_3)
        Me.Frame4.Controls.Add(Me._cmbCodPos_2)
        Me.Frame4.Controls.Add(Me._cmbCodPos_1)
        Me.Frame4.Controls.Add(Me._cmbCodPos_0)
        Me.Frame4.Controls.Add(Me.cmbSuChi)
        Me.Frame4.Controls.Add(Me.lblFinoA)
        Me.Frame4.Controls.Add(Me.lblLato)
        Me.Frame4.Controls.Add(Me.lblPredef)
        Me.Frame4.Controls.Add(Me.Label2)
        Me.Frame4.Controls.Add(Me._lblSuChi_4)
        Me.Frame4.Controls.Add(Me._lblSuChi_3)
        Me.Frame4.Controls.Add(Me._lblSuChi_2)
        Me.Frame4.Controls.Add(Me._lblSuChi_0)
        Me.Frame4.Controls.Add(Me._lblSuChi_1)
        Me.Frame4.Controls.Add(Me.Label1)
        Me.Frame4.Font = New System.Drawing.Font("Arial", 8.4!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame4.Location = New System.Drawing.Point(400, 224)
        Me.Frame4.Name = "Frame4"
        Me.Frame4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame4.Size = New System.Drawing.Size(337, 137)
        Me.Frame4.TabIndex = 50
        Me.Frame4.TabStop = False
        Me.Frame4.Text = "Posizionamento"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Red
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.4!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(8, 40)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(216, 40)
        Me.Label3.TabIndex = 77
        Me.Label3.Text = "Questo posizionamento non è ammesso. Si consiglia di riportare la membratura sull" & _
        "'origine."
        Me.Label3.Visible = False
        '
        'lstFinoA
        '
        Me.lstFinoA.BackColor = System.Drawing.SystemColors.Window
        Me.lstFinoA.Cursor = System.Windows.Forms.Cursors.Default
        Me.lstFinoA.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lstFinoA.ItemHeight = 14
        Me.lstFinoA.Location = New System.Drawing.Point(240, 64)
        Me.lstFinoA.Name = "lstFinoA"
        Me.lstFinoA.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lstFinoA.Size = New System.Drawing.Size(49, 18)
        Me.lstFinoA.TabIndex = 107
        Me.lstFinoA.Visible = False
        '
        'cmbFinoA
        '
        Me.cmbFinoA.BackColor = System.Drawing.SystemColors.Window
        Me.cmbFinoA.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbFinoA.Font = New System.Drawing.Font("Arial", 8.4!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbFinoA.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbFinoA.Location = New System.Drawing.Point(56, 80)
        Me.cmbFinoA.Name = "cmbFinoA"
        Me.cmbFinoA.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbFinoA.Size = New System.Drawing.Size(273, 22)
        Me.cmbFinoA.TabIndex = 106
        Me.cmbFinoA.Text = "Combo1"
        '
        'cmbLato
        '
        Me.cmbLato.BackColor = System.Drawing.SystemColors.Window
        Me.cmbLato.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbLato.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLato.Font = New System.Drawing.Font("Arial", 8.4!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbLato.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbLato.Location = New System.Drawing.Point(224, 104)
        Me.cmbLato.Name = "cmbLato"
        Me.cmbLato.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbLato.Size = New System.Drawing.Size(105, 22)
        Me.cmbLato.TabIndex = 105
        '
        'lstSuChi
        '
        Me.lstSuChi.BackColor = System.Drawing.SystemColors.Window
        Me.lstSuChi.Cursor = System.Windows.Forms.Cursors.Default
        Me.lstSuChi.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lstSuChi.ItemHeight = 14
        Me.lstSuChi.Location = New System.Drawing.Point(256, 72)
        Me.lstSuChi.Name = "lstSuChi"
        Me.lstSuChi.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lstSuChi.Size = New System.Drawing.Size(49, 18)
        Me.lstSuChi.TabIndex = 97
        Me.lstSuChi.Visible = False
        '
        'cmbPredef
        '
        Me.cmbPredef.BackColor = System.Drawing.SystemColors.Window
        Me.cmbPredef.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbPredef.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPredef.Font = New System.Drawing.Font("Arial", 8.4!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPredef.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbPredef.Location = New System.Drawing.Point(224, 40)
        Me.cmbPredef.Name = "cmbPredef"
        Me.cmbPredef.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbPredef.Size = New System.Drawing.Size(105, 22)
        Me.cmbPredef.TabIndex = 74
        Me.cmbPredef.Visible = False
        '
        '_cmbCodPos_4
        '
        Me._cmbCodPos_4.BackColor = System.Drawing.SystemColors.Window
        Me._cmbCodPos_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmbCodPos_4.Font = New System.Drawing.Font("Arial", 8.4!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._cmbCodPos_4.ForeColor = System.Drawing.SystemColors.WindowText
        Me._cmbCodPos_4.Location = New System.Drawing.Point(96, 104)
        Me._cmbCodPos_4.Name = "_cmbCodPos_4"
        Me._cmbCodPos_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmbCodPos_4.Size = New System.Drawing.Size(81, 22)
        Me._cmbCodPos_4.TabIndex = 63
        Me._cmbCodPos_4.TabStop = False
        Me._cmbCodPos_4.Text = "Combo1"
        '
        '_cmbCodPos_3
        '
        Me._cmbCodPos_3.BackColor = System.Drawing.SystemColors.Window
        Me._cmbCodPos_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmbCodPos_3.Font = New System.Drawing.Font("Arial", 8.4!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._cmbCodPos_3.ForeColor = System.Drawing.SystemColors.WindowText
        Me._cmbCodPos_3.Location = New System.Drawing.Point(96, 88)
        Me._cmbCodPos_3.Name = "_cmbCodPos_3"
        Me._cmbCodPos_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmbCodPos_3.Size = New System.Drawing.Size(81, 22)
        Me._cmbCodPos_3.TabIndex = 62
        Me._cmbCodPos_3.TabStop = False
        Me._cmbCodPos_3.Text = "Combo1"
        '
        '_cmbCodPos_2
        '
        Me._cmbCodPos_2.BackColor = System.Drawing.SystemColors.Window
        Me._cmbCodPos_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmbCodPos_2.Font = New System.Drawing.Font("Arial", 8.4!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._cmbCodPos_2.ForeColor = System.Drawing.SystemColors.WindowText
        Me._cmbCodPos_2.Location = New System.Drawing.Point(96, 72)
        Me._cmbCodPos_2.Name = "_cmbCodPos_2"
        Me._cmbCodPos_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmbCodPos_2.Size = New System.Drawing.Size(81, 22)
        Me._cmbCodPos_2.TabIndex = 61
        Me._cmbCodPos_2.TabStop = False
        Me._cmbCodPos_2.Text = "Combo1"
        '
        '_cmbCodPos_1
        '
        Me._cmbCodPos_1.BackColor = System.Drawing.SystemColors.Window
        Me._cmbCodPos_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmbCodPos_1.Font = New System.Drawing.Font("Arial", 8.4!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._cmbCodPos_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me._cmbCodPos_1.Location = New System.Drawing.Point(96, 56)
        Me._cmbCodPos_1.Name = "_cmbCodPos_1"
        Me._cmbCodPos_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmbCodPos_1.Size = New System.Drawing.Size(81, 22)
        Me._cmbCodPos_1.TabIndex = 60
        Me._cmbCodPos_1.TabStop = False
        Me._cmbCodPos_1.Text = "Combo1"
        '
        '_cmbCodPos_0
        '
        Me._cmbCodPos_0.BackColor = System.Drawing.SystemColors.Window
        Me._cmbCodPos_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmbCodPos_0.Font = New System.Drawing.Font("Arial", 8.4!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._cmbCodPos_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._cmbCodPos_0.Location = New System.Drawing.Point(96, 40)
        Me._cmbCodPos_0.Name = "_cmbCodPos_0"
        Me._cmbCodPos_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmbCodPos_0.Size = New System.Drawing.Size(81, 22)
        Me._cmbCodPos_0.TabIndex = 59
        Me._cmbCodPos_0.TabStop = False
        Me._cmbCodPos_0.Text = "Combo1"
        '
        'cmbSuChi
        '
        Me.cmbSuChi.BackColor = System.Drawing.SystemColors.Window
        Me.cmbSuChi.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbSuChi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSuChi.Font = New System.Drawing.Font("Arial", 8.4!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSuChi.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbSuChi.Location = New System.Drawing.Point(56, 16)
        Me.cmbSuChi.Name = "cmbSuChi"
        Me.cmbSuChi.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbSuChi.Size = New System.Drawing.Size(273, 22)
        Me.cmbSuChi.TabIndex = 52
        '
        'lblFinoA
        '
        Me.lblFinoA.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(255, Byte))
        Me.lblFinoA.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblFinoA.Font = New System.Drawing.Font("Arial", 8.4!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFinoA.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblFinoA.Location = New System.Drawing.Point(8, 80)
        Me.lblFinoA.Name = "lblFinoA"
        Me.lblFinoA.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblFinoA.Size = New System.Drawing.Size(49, 17)
        Me.lblFinoA.TabIndex = 108
        Me.lblFinoA.Text = "fino a:"
        '
        'lblLato
        '
        Me.lblLato.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(255, Byte))
        Me.lblLato.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblLato.Font = New System.Drawing.Font("Arial", 8.4!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLato.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLato.Location = New System.Drawing.Point(176, 104)
        Me.lblLato.Name = "lblLato"
        Me.lblLato.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblLato.Size = New System.Drawing.Size(41, 17)
        Me.lblLato.TabIndex = 104
        Me.lblLato.Text = "Lato"
        '
        'lblPredef
        '
        Me.lblPredef.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(255, Byte))
        Me.lblPredef.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblPredef.Font = New System.Drawing.Font("Arial", 8.4!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPredef.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblPredef.Location = New System.Drawing.Point(176, 40)
        Me.lblPredef.Name = "lblPredef"
        Me.lblPredef.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblPredef.Size = New System.Drawing.Size(65, 17)
        Me.lblPredef.TabIndex = 73
        Me.lblPredef.Text = "Predefiniti"
        Me.lblPredef.Visible = False
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.4!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(8, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(209, 17)
        Me.Label2.TabIndex = 76
        Me.Label2.Text = "(Membratura secondaria)"
        Me.Label2.Visible = False
        '
        '_lblSuChi_4
        '
        Me._lblSuChi_4.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(255, Byte))
        Me._lblSuChi_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblSuChi_4.Font = New System.Drawing.Font("Arial", 8.4!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblSuChi_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblSuChi_4.Location = New System.Drawing.Point(8, 104)
        Me._lblSuChi_4.Name = "_lblSuChi_4"
        Me._lblSuChi_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblSuChi_4.Size = New System.Drawing.Size(76, 17)
        Me._lblSuChi_4.TabIndex = 57
        Me._lblSuChi_4.Text = "DirTraversa"
        '
        '_lblSuChi_3
        '
        Me._lblSuChi_3.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(255, Byte))
        Me._lblSuChi_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblSuChi_3.Font = New System.Drawing.Font("Arial", 8.4!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblSuChi_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblSuChi_3.Location = New System.Drawing.Point(8, 88)
        Me._lblSuChi_3.Name = "_lblSuChi_3"
        Me._lblSuChi_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblSuChi_3.Size = New System.Drawing.Size(76, 17)
        Me._lblSuChi_3.TabIndex = 56
        Me._lblSuChi_3.Text = "DirDiritta"
        '
        '_lblSuChi_2
        '
        Me._lblSuChi_2.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(255, Byte))
        Me._lblSuChi_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblSuChi_2.Font = New System.Drawing.Font("Arial", 8.4!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblSuChi_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblSuChi_2.Location = New System.Drawing.Point(8, 72)
        Me._lblSuChi_2.Name = "_lblSuChi_2"
        Me._lblSuChi_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblSuChi_2.Size = New System.Drawing.Size(76, 17)
        Me._lblSuChi_2.TabIndex = 55
        Me._lblSuChi_2.Text = "Raggio"
        '
        '_lblSuChi_0
        '
        Me._lblSuChi_0.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(255, Byte))
        Me._lblSuChi_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblSuChi_0.Font = New System.Drawing.Font("Arial", 8.4!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblSuChi_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblSuChi_0.Location = New System.Drawing.Point(8, 40)
        Me._lblSuChi_0.Name = "_lblSuChi_0"
        Me._lblSuChi_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblSuChi_0.Size = New System.Drawing.Size(76, 17)
        Me._lblSuChi_0.TabIndex = 54
        Me._lblSuChi_0.Text = "Quota"
        '
        '_lblSuChi_1
        '
        Me._lblSuChi_1.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(255, Byte))
        Me._lblSuChi_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblSuChi_1.Font = New System.Drawing.Font("Arial", 8.4!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblSuChi_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblSuChi_1.Location = New System.Drawing.Point(8, 56)
        Me._lblSuChi_1.Name = "_lblSuChi_1"
        Me._lblSuChi_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblSuChi_1.Size = New System.Drawing.Size(76, 17)
        Me._lblSuChi_1.TabIndex = 53
        Me._lblSuChi_1.Text = "Anomalia"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(255, Byte))
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.4!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(8, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(49, 17)
        Me.Label1.TabIndex = 51
        Me.Label1.Text = "rispetto a:"
        '
        'Frame3
        '
        Me.Frame3.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(128, Byte), CType(255, Byte))
        Me.Frame3.Controls.Add(Me.txtNot)
        Me.Frame3.Controls.Add(Me.txtDes)
        Me.Frame3.Controls.Add(Me.txtQta)
        Me.Frame3.Controls.Add(Me.txtPos)
        Me.Frame3.Controls.Add(Me.lblNot)
        Me.Frame3.Controls.Add(Me.lblDes)
        Me.Frame3.Controls.Add(Me.lblQta)
        Me.Frame3.Controls.Add(Me._lblPos_0)
        Me.Frame3.Font = New System.Drawing.Font("Arial", 8.4!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame3.ForeColor = System.Drawing.Color.Black
        Me.Frame3.Location = New System.Drawing.Point(0, 328)
        Me.Frame3.Name = "Frame3"
        Me.Frame3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame3.Size = New System.Drawing.Size(401, 65)
        Me.Frame3.TabIndex = 40
        Me.Frame3.TabStop = False
        Me.Frame3.Text = "Dati distinta e descrizione estesa"
        '
        'txtNot
        '
        Me.txtNot.AcceptsReturn = True
        Me.txtNot.AutoSize = False
        Me.txtNot.BackColor = System.Drawing.SystemColors.Window
        Me.txtNot.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtNot.Font = New System.Drawing.Font("Arial", 8.4!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNot.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtNot.Location = New System.Drawing.Point(184, 40)
        Me.txtNot.MaxLength = 0
        Me.txtNot.Name = "txtNot"
        Me.txtNot.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtNot.Size = New System.Drawing.Size(211, 19)
        Me.txtNot.TabIndex = 48
        Me.txtNot.Text = "Text1"
        '
        'txtDes
        '
        Me.txtDes.AcceptsReturn = True
        Me.txtDes.AutoSize = False
        Me.txtDes.BackColor = System.Drawing.SystemColors.Window
        Me.txtDes.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDes.Font = New System.Drawing.Font("Arial", 8.4!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDes.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtDes.Location = New System.Drawing.Point(184, 16)
        Me.txtDes.MaxLength = 0
        Me.txtDes.Name = "txtDes"
        Me.txtDes.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtDes.Size = New System.Drawing.Size(211, 19)
        Me.txtDes.TabIndex = 46
        Me.txtDes.Text = "Text1"
        '
        'txtQta
        '
        Me.txtQta.AcceptsReturn = True
        Me.txtQta.AutoSize = False
        Me.txtQta.BackColor = System.Drawing.SystemColors.Window
        Me.txtQta.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtQta.Font = New System.Drawing.Font("Arial", 8.4!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQta.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtQta.Location = New System.Drawing.Point(72, 40)
        Me.txtQta.MaxLength = 0
        Me.txtQta.Name = "txtQta"
        Me.txtQta.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtQta.Size = New System.Drawing.Size(35, 19)
        Me.txtQta.TabIndex = 44
        Me.txtQta.Text = "Text1"
        '
        'txtPos
        '
        Me.txtPos.AcceptsReturn = True
        Me.txtPos.AutoSize = False
        Me.txtPos.BackColor = System.Drawing.SystemColors.Window
        Me.txtPos.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPos.Font = New System.Drawing.Font("Arial", 8.4!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPos.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtPos.Location = New System.Drawing.Point(72, 16)
        Me.txtPos.MaxLength = 0
        Me.txtPos.Name = "txtPos"
        Me.txtPos.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtPos.Size = New System.Drawing.Size(35, 19)
        Me.txtPos.TabIndex = 42
        Me.txtPos.Text = "Text1"
        '
        'lblNot
        '
        Me.lblNot.BackColor = System.Drawing.SystemColors.Window
        Me.lblNot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblNot.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblNot.Font = New System.Drawing.Font("Arial", 8.4!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNot.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblNot.Location = New System.Drawing.Point(120, 40)
        Me.lblNot.Name = "lblNot"
        Me.lblNot.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblNot.Size = New System.Drawing.Size(57, 17)
        Me.lblNot.TabIndex = 47
        Me.lblNot.Text = "Note"
        '
        'lblDes
        '
        Me.lblDes.BackColor = System.Drawing.SystemColors.Window
        Me.lblDes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDes.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblDes.Font = New System.Drawing.Font("Arial", 8.4!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDes.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblDes.Location = New System.Drawing.Point(120, 16)
        Me.lblDes.Name = "lblDes"
        Me.lblDes.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblDes.Size = New System.Drawing.Size(57, 17)
        Me.lblDes.TabIndex = 45
        Me.lblDes.Text = "Descrizione"
        '
        'lblQta
        '
        Me.lblQta.BackColor = System.Drawing.SystemColors.Window
        Me.lblQta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblQta.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblQta.Font = New System.Drawing.Font("Arial", 8.4!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblQta.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblQta.Location = New System.Drawing.Point(8, 40)
        Me.lblQta.Name = "lblQta"
        Me.lblQta.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblQta.Size = New System.Drawing.Size(57, 17)
        Me.lblQta.TabIndex = 43
        Me.lblQta.Text = "N° pezzi"
        '
        '_lblPos_0
        '
        Me._lblPos_0.BackColor = System.Drawing.SystemColors.Window
        Me._lblPos_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._lblPos_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblPos_0.Font = New System.Drawing.Font("Arial", 8.4!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblPos_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._lblPos_0.Location = New System.Drawing.Point(8, 16)
        Me._lblPos_0.Name = "_lblPos_0"
        Me._lblPos_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblPos_0.Size = New System.Drawing.Size(57, 17)
        Me._lblPos_0.TabIndex = 41
        Me._lblPos_0.Text = "Pos. a dis."
        '
        'txtDen
        '
        Me.txtDen.AcceptsReturn = True
        Me.txtDen.AutoSize = False
        Me.txtDen.BackColor = System.Drawing.SystemColors.Window
        Me.txtDen.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDen.Font = New System.Drawing.Font("Arial", 8.4!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDen.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtDen.Location = New System.Drawing.Point(96, 24)
        Me.txtDen.MaxLength = 0
        Me.txtDen.Name = "txtDen"
        Me.txtDen.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtDen.Size = New System.Drawing.Size(225, 21)
        Me.txtDen.TabIndex = 7
        Me.txtDen.TabStop = False
        Me.txtDen.Text = ""
        '
        'Frame1
        '
        Me.Frame1.BackColor = System.Drawing.Color.Cyan
        Me.Frame1.Controls.Add(Me._cmbParaO_0)
        Me.Frame1.Controls.Add(Me.option3)
        Me.Frame1.Controls.Add(Me.option1)
        Me.Frame1.Controls.Add(Me._cmbPara_0)
        Me.Frame1.Controls.Add(Me._txtPara_0)
        Me.Frame1.Controls.Add(Me._lblPara_0)
        Me.Frame1.Font = New System.Drawing.Font("Arial", 8.4!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame1.Location = New System.Drawing.Point(0, 120)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame1.Size = New System.Drawing.Size(321, 104)
        Me.Frame1.TabIndex = 3
        Me.Frame1.TabStop = False
        Me.Frame1.Text = "Parametri geometrici [mm]"
        '
        '_cmbParaO_0
        '
        Me._cmbParaO_0.BackColor = System.Drawing.SystemColors.Window
        Me._cmbParaO_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmbParaO_0.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me._cmbParaO_0.Font = New System.Drawing.Font("Arial", 8.4!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._cmbParaO_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._cmbParaO_0.Location = New System.Drawing.Point(200, 72)
        Me._cmbParaO_0.Name = "_cmbParaO_0"
        Me._cmbParaO_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmbParaO_0.Size = New System.Drawing.Size(105, 22)
        Me._cmbParaO_0.TabIndex = 87
        Me._cmbParaO_0.Visible = False
        '
        'option3
        '
        Me.option3.BackColor = System.Drawing.Color.Cyan
        Me.option3.Cursor = System.Windows.Forms.Cursors.Default
        Me.option3.Font = New System.Drawing.Font("Arial", 8.4!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.option3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.option3.Location = New System.Drawing.Point(8, 32)
        Me.option3.Name = "option3"
        Me.option3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.option3.Size = New System.Drawing.Size(181, 19)
        Me.option3.TabIndex = 86
        Me.option3.Text = "la suddetta è cieca"
        Me.option3.Visible = False
        '
        'option1
        '
        Me.option1.BackColor = System.Drawing.Color.Cyan
        Me.option1.Cursor = System.Windows.Forms.Cursors.Default
        Me.option1.Font = New System.Drawing.Font("Arial", 8.4!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.option1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.option1.Location = New System.Drawing.Point(8, 16)
        Me.option1.Name = "option1"
        Me.option1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.option1.Size = New System.Drawing.Size(181, 19)
        Me.option1.TabIndex = 85
        Me.option1.Text = "con flangia accoppiata"
        Me.option1.Visible = False
        '
        '_cmbPara_0
        '
        Me._cmbPara_0.BackColor = System.Drawing.SystemColors.Window
        Me._cmbPara_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmbPara_0.Font = New System.Drawing.Font("Arial", 8.4!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._cmbPara_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._cmbPara_0.Location = New System.Drawing.Point(200, 96)
        Me._cmbPara_0.Name = "_cmbPara_0"
        Me._cmbPara_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmbPara_0.Size = New System.Drawing.Size(105, 22)
        Me._cmbPara_0.TabIndex = 79
        Me._cmbPara_0.Text = "cmbpara"
        Me._cmbPara_0.Visible = False
        '
        '_txtPara_0
        '
        Me._txtPara_0.AcceptsReturn = True
        Me._txtPara_0.AutoSize = False
        Me._txtPara_0.BackColor = System.Drawing.SystemColors.Window
        Me._txtPara_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtPara_0.Font = New System.Drawing.Font("Arial", 8.4!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._txtPara_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._txtPara_0.Location = New System.Drawing.Point(200, 16)
        Me._txtPara_0.MaxLength = 0
        Me._txtPara_0.Multiline = True
        Me._txtPara_0.Name = "_txtPara_0"
        Me._txtPara_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtPara_0.Size = New System.Drawing.Size(81, 19)
        Me._txtPara_0.TabIndex = 5
        Me._txtPara_0.Text = "Text1"
        Me._txtPara_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        '_lblPara_0
        '
        Me._lblPara_0.BackColor = System.Drawing.Color.Cyan
        Me._lblPara_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblPara_0.Font = New System.Drawing.Font("Arial", 8.4!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblPara_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblPara_0.Location = New System.Drawing.Point(8, 16)
        Me._lblPara_0.Name = "_lblPara_0"
        Me._lblPara_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblPara_0.Size = New System.Drawing.Size(177, 17)
        Me._lblPara_0.TabIndex = 4
        Me._lblPara_0.Text = "Label1"
        '
        '_txtMat_0
        '
        Me._txtMat_0.AcceptsReturn = True
        Me._txtMat_0.AutoSize = False
        Me._txtMat_0.BackColor = System.Drawing.SystemColors.Window
        Me._txtMat_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtMat_0.Font = New System.Drawing.Font("Arial", 8.4!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._txtMat_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtMat.Add(0, Me._txtMat_0)
        Me._txtMat_0.Location = New System.Drawing.Point(96, 0)
        Me._txtMat_0.MaxLength = 0
        Me._txtMat_0.Name = "_txtMat_0"
        Me._txtMat_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtMat_0.Size = New System.Drawing.Size(203, 21)
        Me._txtMat_0.TabIndex = 0
        Me._txtMat_0.TabStop = False
        Me._txtMat_0.Text = "Text1"
        '
        'Frame6
        '
        Me.Frame6.BackColor = System.Drawing.SystemColors.Control
        Me.Frame6.Controls.Add(Me.Direzione)
        Me.Frame6.Font = New System.Drawing.Font("Arial", 8.4!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame6.Location = New System.Drawing.Point(144, 224)
        Me.Frame6.Name = "Frame6"
        Me.Frame6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame6.Size = New System.Drawing.Size(177, 57)
        Me.Frame6.TabIndex = 83
        Me.Frame6.TabStop = False
        Me.Frame6.Text = "Direzione"
        '
        'Direzione
        '
        Me.Direzione.BackColor = System.Drawing.SystemColors.Window
        Me.Direzione.Cursor = System.Windows.Forms.Cursors.Default
        Me.Direzione.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Direzione.Font = New System.Drawing.Font("Arial", 8.4!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Direzione.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Direzione.Location = New System.Drawing.Point(24, 24)
        Me.Direzione.Name = "Direzione"
        Me.Direzione.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Direzione.Size = New System.Drawing.Size(129, 22)
        Me.Direzione.TabIndex = 84
        '
        'txtTipo
        '
        Me.txtTipo.BackColor = System.Drawing.Color.White
        Me.txtTipo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtTipo.Cursor = System.Windows.Forms.Cursors.Default
        Me.txtTipo.Font = New System.Drawing.Font("Arial", 8.4!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTipo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtTipo.Location = New System.Drawing.Point(96, 48)
        Me.txtTipo.Name = "txtTipo"
        Me.txtTipo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtTipo.Size = New System.Drawing.Size(225, 21)
        Me.txtTipo.TabIndex = 33
        Me.txtTipo.Text = "Tipo membratura"
        '
        'lblTipo
        '
        Me.lblTipo.BackColor = System.Drawing.SystemColors.Window
        Me.lblTipo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTipo.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblTipo.Font = New System.Drawing.Font("Arial", 8.4!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipo.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblTipo.Location = New System.Drawing.Point(0, 48)
        Me.lblTipo.Name = "lblTipo"
        Me.lblTipo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblTipo.Size = New System.Drawing.Size(94, 21)
        Me.lblTipo.TabIndex = 8
        Me.lblTipo.Text = "Tipo membratura"
        '
        'lblDen
        '
        Me.lblDen.BackColor = System.Drawing.SystemColors.Window
        Me.lblDen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDen.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblDen.Font = New System.Drawing.Font("Arial", 8.4!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDen.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblDen.Location = New System.Drawing.Point(0, 24)
        Me.lblDen.Name = "lblDen"
        Me.lblDen.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblDen.Size = New System.Drawing.Size(94, 21)
        Me.lblDen.TabIndex = 6
        Me.lblDen.Text = "Denominazione"
        '
        '_lblMat_0
        '
        Me._lblMat_0.BackColor = System.Drawing.SystemColors.Window
        Me._lblMat_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._lblMat_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblMat_0.Font = New System.Drawing.Font("Arial", 8.4!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblMat_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._lblMat_0.Location = New System.Drawing.Point(0, 0)
        Me._lblMat_0.Name = "_lblMat_0"
        Me._lblMat_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblMat_0.Size = New System.Drawing.Size(94, 21)
        Me._lblMat_0.TabIndex = 2
        Me._lblMat_0.Text = "Materiale"
        '
        'txtMat
        '
        '
        'txtPsp
        '
        '
        'DBCmbTipo
        '
        Me.DBCmbTipo.Location = New System.Drawing.Point(96, 48)
        Me.DBCmbTipo.Name = "DBCmbTipo"
        Me.DBCmbTipo.Size = New System.Drawing.Size(224, 21)
        Me.DBCmbTipo.TabIndex = 97
        Me.DBCmbTipo.Text = "DBcmbTipo"
        '
        'Picture1
        '
        Me.Picture1.BackColor = System.Drawing.Color.White
        Me.Picture1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Picture1.Location = New System.Drawing.Point(328, 0)
        Me.Picture1.Name = "Picture1"
        Me.Picture1.Size = New System.Drawing.Size(408, 224)
        Me.Picture1.TabIndex = 98
        Me.Picture1.TabStop = False
        '
        'frmDati
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 12)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(739, 602)
        Me.Controls.Add(Me._cmdMat_0)
        Me.Controls.Add(Me.Picture1)
        Me.Controls.Add(Me.DBCmbTipo)
        Me.Controls.Add(Me.Frame5)
        Me.Controls.Add(Me.Frame2)
        Me.Controls.Add(Me.Combo1)
        Me.Controls.Add(Me.Frame7)
        Me.Controls.Add(Me.FramePict)
        Me.Controls.Add(Me.PictHelp)
        Me.Controls.Add(Me.cmbTipo)
        Me.Controls.Add(Me.Frame4)
        Me.Controls.Add(Me.Frame3)
        Me.Controls.Add(Me.txtDen)
        Me.Controls.Add(Me._txtMat_0)
        Me.Controls.Add(Me.Frame1)
        Me.Controls.Add(Me.Frame6)
        Me.Controls.Add(Me.txtTipo)
        Me.Controls.Add(Me.lblTipo)
        Me.Controls.Add(Me.lblDen)
        Me.Controls.Add(Me._lblMat_0)
        Me.Controls.Add(Me.Frame8)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.HelpButton = True
        Me.Location = New System.Drawing.Point(5, 81)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDati"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Form1"
        Me.Frame5.ResumeLayout(False)
        Me.Frame2.ResumeLayout(False)
        Me.Frame8.ResumeLayout(False)
        Me.Frame7.ResumeLayout(False)
        Me.FramePict.ResumeLayout(False)
        Me.Frame4.ResumeLayout(False)
        Me.Frame3.ResumeLayout(False)
        Me.Frame1.ResumeLayout(False)
        Me.Frame6.ResumeLayout(False)

        For Each control In txtMat.Values
            AddHandler control.MouseDown, AddressOf txtMat_MouseDown
        Next
        For Each control In txtMat.Values
            AddHandler control.MouseMove, AddressOf txtMat_MouseMove
        Next
        For Each control In txtPsp.Values
            AddHandler control.TextChanged, AddressOf txtPsp_TextChanged
        Next
        For Each control In txtPsp.Values
            AddHandler control.Enter, AddressOf txtPsp_Enter
        Next
        For Each control In txtPsp.Values
            AddHandler control.KeyDown, AddressOf txtPsp_KeyDown
        Next
        For Each control In txtPsp.Values
            AddHandler control.KeyPress, AddressOf txtPsp_KeyPress
        Next
        For Each control In txtPsp.Values
            AddHandler control.KeyUp, AddressOf txtPsp_KeyUp
        Next
        For Each control In txtPsp.Values
            AddHandler control.MouseDown, AddressOf txtPsp_MouseDown
        Next
        Me.ResumeLayout(False)

    End Sub
#End Region
    Public WithEvents _lblPsp_15 As System.Windows.Forms.Label
    Friend txtPara As TextArray
    Friend cmbPara, cmbParaO, cmbCodPos, lstCodPos As ComboArray
    Friend lblPara As LabelArray
    Private Inizializzando, KeyPressed As Boolean
    Private MyDatabase As OleDbConnection
    Private cmd As OleDbDataAdapter
    Private MyTable As DataTable
    Private QuoVec() As String = {"0", "0", "0", "0", "0"}
    Private Testo, CodPos As String
    '------------------------------------
    Private xBot, xTop, yTop, yBot As Single
    Private IndCodPos As Short
    Private GiaAttiva As Boolean
    Private NoRidisegna As Boolean
    Private GiaSpecial As Boolean
    Private SelectedTipo As Boolean
    Private Predefiniti(,) As String
    Private Abilitato, ClickManuale As Boolean
    Private TextArr As ControlArray
    Private TextArs() As System.Windows.Forms.Control
    Private LblArr() As System.Windows.Forms.Control
    Private EnaTxtPara, CamTxtPara As Boolean
    Private nArr As Short
    Private AltroClick As Boolean
    Private db As OleDbConnection
    Private cmddb As OleDbDataAdapter
    Private cmddbT As OleDbDataAdapter
    Private InTesti As Boolean
    Private vList As Short
    Private lblLeft As Single
    Private myData As DataSet
    Private Zooming As Boolean
    Private WithEvents _librerie_0 As arrButton
    Private Librerie As ButtonArray
    Private Sub Inizializza()
        Dim MyFile As String ', UserName As String, PassWord As String
        Dim i As Short
        ReDim TextArs(22)
        txtPara = New TextArray(Me, Frame1, "_txtPara")
        cmbPara = New ComboArray(Me, Frame1, "_cmbPara")
        cmbPara(0).Visible = False
        cmbParaO = New ComboArray(Me, Frame1, "_cmbParaO")
        cmbParaO(0).Visible = False
        cmbCodPos = New ComboArray(Me, Frame4, "_cmbCodPos")
        cmbCodPos.AddNew(_cmbCodPos_1)
        cmbCodPos.AddNew(_cmbCodPos_2)
        cmbCodPos.AddNew(_cmbCodPos_3)
        cmbCodPos.AddNew(_cmbCodPos_4)
        For i = 0 To 4
            cmbCodPos(i).Visible = False
        Next
        lstCodPos = New ComboArray(Me, Frame4, "_cmbCodPos", "_lstCodPos_0")
        lstCodPos.AddNew(_cmbCodPos_1, "_lstCodPos_1")
        lstCodPos.AddNew(_cmbCodPos_2, "_lstCodPos_2")
        lstCodPos.AddNew(_cmbCodPos_3, "_lstCodPos_3")
        lstCodPos.AddNew(_cmbCodPos_4, "_lstCodPos_4")
        lblPara = New LabelArray(Me, Frame1, "_lblPara")
        TextArr = New ControlArray
        For i = 0 To 14
            TextArs(i) = txtPsp(i)
        Next
        If IUNL < 6 Then
            MyFile = RTrim(Inizio.Archdir) & "\SuChi.MDB"
            MyDatabase = New OleDbConnection(Conn & MyFile & ConnFine) ' Funzioni.MyWorkspace.OpenDatabase(MyFile, False, True)
        End If
        Frame8.Top = Frame2.Top
        Frame8.Visible = False
        lblLeft = _lblPsp_3.Left
        cmbLato.Items.Add("non def.")
        cmbLato.Items.Add("Mantello")
        cmbLato.Items.Add("Tubi")
        cmbLato.Items.Add("fra i due")
        cmbLato.Items.Add("Esterno")
        _lblPsp_15 = New System.Windows.Forms.Label
        Frame2.Controls.Add(_lblPsp_15)
        _lblPsp_15.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(128, Byte))
        _lblPsp_15.Cursor = System.Windows.Forms.Cursors.Default
        _lblPsp_15.Font = New System.Drawing.Font("Arial", 8.4!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        _lblPsp_15.ForeColor = System.Drawing.SystemColors.ControlText
        _lblPsp_15.Width = _lblPsp_11.Width
        _lblPsp_15.Height = _lblPsp_11.Height
        _lblPsp_15.BackColor = _lblPsp_11.BackColor
        _lblPsp_15.Left = _lblPsp_11.Left ' lblLeft
        _lblPsp_15.Top = CInt(cmbLE.Top + cmbLE.Height + GlobalRoutines.TwipsToPixelsX(40)) '_lblPsp_10.Top
        _lblPsp_15.Text = "Costo LE (kEUR)"
    End Sub
    Public Sub Combo_TextChanged(ByVal Nome As String)
        If Inizializzando Then Exit Sub
        Dim s() As String = Nome.Split(CChar("_"))
        Dim Textnum As String = s(1)
        Dim Index As Short = CShort(s(2))
        Dim i As Short
        Select Case Textnum
            Case "lstCodPos"
                Try
                    If CStr(lstCodPos(Index).Tag) = "NN" Then Exit Sub
                    cmbCodPos(Index).Text = lstCodPos(Index).Text
                    If CStr(lstCodPos(Index).Tag) = "F" Then Exit Sub
                    If lstCodPos(Index).SelectedIndex = -1 Then
                        Testo = Space(3)
                        For i = 0 To CShort(lstCodPos(Index).Items.Count - 1)
                            If CStr(lstCodPos(Index).Items(i)).IndexOf("Scr") > 0 Then Testo = "Scr" : Exit For
                        Next
                    Else
                        Testo = CStr(lstCodPos(Index).SelectedItem)
                    End If
                    'If Not Testo.Substring(0, 3).Equals("Scr") And Not Abilitato Then
                    'MsgBox("Questi codici non devono essere modificati manualmente", MsgBoxStyle.Exclamation)
                    'lstCodPos(Index).Tag = "F"
                    'lstCodPos(Index).Text = Testo
                    'lstCodPos(Index).Tag = "T"
                    'Exit Sub
                    'End If
                Catch e As Exception
                    MsgBox(e.Message + vbCrLf + e.StackTrace)
                End Try
        End Select
    End Sub
    Public Sub Combo_Enter(ByVal Nome As String)
        Dim s() As String = Nome.Split(CChar("_"))
        Dim Textnum As String = s(1)
        Dim Index As Short = CShort(s(2))
        Select Case Textnum
            Case "lstCodPos"
                ' If lstCodPos(Index).Text.Length > 2 Then
                ' If Not lstCodPos(Index).Text.Substring(0, 3) = "Scr" Then
                ' lstCodPos(Index).SelectionLength = 0
                ' Else
                '     lstCodPos(Index).Text = "   "
                ' End If
                ' Else
                ' lstCodPos(Index).Text = "   "
                ' End If
        End Select
    End Sub
    Public Sub Combo_Validating(ByVal Name As String, ByVal e As System.ComponentModel.CancelEventArgs)
        Dim s() As String = Name.Split(CChar("_"))
        Dim Textnum As String = s(1)
        Dim Index As Short = CShort(s(2))
        Select Case Textnum
            Case "lstCodPos"
                lstCodPos(Index).Tag = "T"
                If KeyPressed Then cmbCodPos(Index).Text = lstCodPos(Index).Text
                ' Testo = cmbCodPos(Index).Text.PadRight(3)
                ' If Not Testo.Substring(0, 3).Equals("Scr") And Not Abilitato Then
                ' MsgBox("Questi codici non devono essere modificati manualmente", MsgBoxStyle.Exclamation)
                ' e.Cancel = True
                ' Abilitato = True
                ' End If
                ' End If
        End Select
    End Sub
    Public Sub Combo_KeyPress(ByVal Name As String, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim KeyAscii As Keys = CType(Val(e.KeyChar), Keys)
        Dim s() As String = Name.Split(CChar("_"))
        Dim Textnum As String = s(1)
        Dim Index As Short = CShort(s(2))
        Select Case Textnum
            Case "lstCodPos"
                If KeyAscii = System.Windows.Forms.Keys.Return Then
                    '  KeyAscii = 0
                    '  Stop
                    '  Combo_Leave(cmbCodPos.Item(Index), New System.EventArgs)
                Else
                    KeyPressed = True
                    Testo = cmbCodPos(Index).Text.PadRight(3)
                    If Not Testo.Substring(0, 3).Equals("Scr") And Not IsNumeric(Testo) And Not Abilitato Then
                        MsgBox("Questi codici non devono essere modificati manualmente", MsgBoxStyle.Exclamation)
                        e.Handled = True
                        Abilitato = True
                    End If
                    lstCodPos(Index).Tag = "NN"
                End If
                'If KeyAscii = 0 Then
                'e.Handled = True
                'End If
        End Select
    End Sub
    'Private Sub cmbCodPos_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
    'Dim Index As Short = cmbCodPos.GetIndex(CType(eventSender, ComboBox))
    '   Static QuoVec(4) As String
    '   Static Testo, CodPos As String
    '   If Not cmbCodPos(Index).Tag = "T" Then Exit Sub
    '   cmbCodPos(Index).Tag = "F"
    '   SostitCmb()
    '   cmbCodPos(Index).Tag = "T"
    '   If cmbCodPos(Index).Text = QuoVec(Index) Then Exit Sub '7-5-99
    '   With Membro.GenMem.posizione
    '       Select Case Index
    '           Case 0
    '   .Quota = cmbCodPos(Index).Text
    '           Case 1
    '   Testo = UCase(CStr(cmbCodPos(Index).SelectedItem).Substring(0, 2))
    '   CodPos = cmbCodPos(Index).Text
    '   If Testo = "XD" Or Testo = "ZD" And Not CodPos.Substring(0, 1) = "S" Then CodPos = CodPos & Testo
    '   cmbCodPos(Index).Tag = "F"
    '   cmbCodPos(Index).Text = CodPos
    '   cmbCodPos(Index).Tag = "T"
    '   .Anomal = CodPos
    '           Case 2
    '   .Raggio = cmbCodPos(Index).Text
    '           Case 3
    '   .DirDiritta = cmbCodPos(Index).Text
    '           Case 4
    '   .DirTraversa = cmbCodPos(Index).Text
    '       End Select
    '   End With
    '   QuoVec(Index) = cmbCodPos(Index).Text '7-5-99
    '   Ridisegna()
    ' End Sub
    Private Sub cmbFinoA_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbFinoA.SelectedIndexChanged
        Static SuChiVec As Short
        If Inizializzando Then Exit Sub
        PosizMemb(SuChiVec, cmbFinoA, lstFinoA, 2)
        CalcolaLunghezza()
    End Sub
    Private Sub cmbLato_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbLato.SelectedIndexChanged
        If Inizializzando Then Exit Sub
        Membro.GenMem.Lato = CShort(cmbLato.SelectedIndex)
    End Sub
    Private Sub cmbLE_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbLE.SelectedIndexChanged
        If Inizializzando Then Exit Sub
        Membro.GenMem.MF = CStr(lstLE.Items(cmbLE.SelectedIndex))
        If txtPsp.Count > 15 Then
            Select Case Membro.GenMem.MF
                Case "--"
                    txtPsp(15).Visible = False
                    _lblPsp_15.Visible = False
                Case "PE" 'placcatura per esplosione
                    txtPsp(15).Visible = True
                    _lblPsp_15.Visible = True
                Case "PC" 'placcatura per colaminazione
                    txtPsp(15).Visible = True
                    _lblPsp_15.Visible = True
                Case "FD" 'completa a disegno
                    txtPsp(15).Visible = False
                    _lblPsp_15.Visible = False
                Case "FC" 'completa a catalogo
                    txtPsp(15).Visible = False
                    _lblPsp_15.Visible = False
                Case "FF" 'formatura fondi
                    txtPsp(15).Visible = True
                    _lblPsp_15.Visible = True
                Case "CA" 'calandratura
                    txtPsp(15).Visible = True
                    _lblPsp_15.Visible = True
                Case "LM" 'lavorazione meccanica
                    txtPsp(15).Visible = True
                    _lblPsp_15.Visible = True
                Case "LE" 'a dis con mat in conto lavori
                    txtPsp(15).Visible = True
                    _lblPsp_15.Visible = True
                Case "TP" 'piegatura forcine
            End Select
        End If
        EnaTxtPsp()
        AggTxtPsp()
    End Sub
    Public Sub Combo_Click(ByVal Nome As String)
        Dim s() As String = Nome.Split(CChar("_"))
        Dim Textnum As String = s(1)
        Dim Index As Short = CShort(s(2))
        Select Case Textnum
            Case "lstCodPos"
                lstCodPos(Index).Tag = "T"
                KeyPressed = False
        End Select
    End Sub
    Public Sub Combo_SelectedIndexChanged(ByVal Nome As String)
        Dim s() As String = Nome.Split(CChar("_"))
        Dim Textnum As String = s(1)
        Dim Index As Short = CShort(s(2))
        Dim Fascio As Fascio
        Dim Tubi As Tubi
        If Inizializzando Then Exit Sub
        AltroClick = True
        Select Case Textnum
            Case "cmbPara"
                Select Case Membro.GenMem.Tipo
                    Case 8, 9
                        Select Case Index
                            Case 2
                                CType(Membro, Tubi).Tolleranza = CShort(cmbPara(Index).SelectedIndex + 1)
                            Case 4
                                Stop
                                '                                CType(Membro, Tubi).TipoFascio = cmbPara(Index).SelectedIndex + 1
                        End Select
                    Case -8, -9
                        Tubi = CType(Membro, Tubi)
                        Select Case Index
                            Case 2
                                Tubi.Tolleranza = CShort(cmbPara(Index).SelectedIndex + 1)
                                Fascio = Apparecchio.CercaFascio(Tubi)
                                VariaFascio(Fascio)
                            Case 4
                                Stop
                                'Tubi.TipoFascio = CShort(cmbPara(Index).SelectedIndex + 1)
                        End Select
                    Case 26
                        Fascio = CType(Membro, Fascio)
                        Select Case Index
                            Case 2
                                Fascio.Tubi_Renamed.Tolleranza = CShort(cmbPara(Index).SelectedIndex + 1)
                                VariaFascio(Fascio)
                            Case 4
                                Fascio.TipoFascio = CShort(cmbPara(Index).SelectedIndex + 1)
                                Select Case Fascio.TipoFascio
                                    Case 1, 2
                                        Fascio.Tubi_Renamed.GenMem.Tipo = -8
                                    Case 3, 4
                                        Fascio.Tubi_Renamed.GenMem.Tipo = -9
                                End Select
                        End Select
                    Case 19, -19
                        With CType(Membro, Diaframma)
                            Select Case Index
                                Case 1
                                    .ClassTEMA = CShort(cmbPara(Index).SelectedIndex + 1)
                                Case 2
                                    .TipoDiafr = CShort(cmbPara(Index).SelectedIndex + 1)
                                Case 3
                                    .SottoTipo = CShort(cmbPara(Index).SelectedIndex + 1)
                                Case 12
                                    .DirezVert = cmbPara(Index).SelectedIndex = 1
                            End Select
                        End With
                End Select
                If Not InTesti Then Membro.Variato = True
                If Not InTesti Then
                    System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
                    MembroLeggi(Membro, Inizio.DiscoRam, 0)
                    Ridisegna()
                    System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
                End If
                AggTxtPsp()
            Case "cmbParaO"
                Select Case System.Math.Abs(Membro.GenMem.Tipo)
                    Case 25
                        With CType(Membro, Sella)
                            Select Case Index
                                Case 0 'Serie
                                    Dim ser As Integer = .Serie
                                    .Serie = CInt(Val(cmbParaO(Index).Text))
                                    If Not ser = .Serie Then GeomPara()
                                Case 1 'SemPor
                                    .sempor = cmbParaO(Index).SelectedIndex = 0
                                Case 10 'FixMob
                                    .FixSlid = cmbParaO(Index).SelectedIndex = 0
                                Case 11 'CI
                                    .CI = cmbParaO(Index).SelectedIndex = 0
                            End Select
                        End With
                End Select
            Case "lstCodPos"
                If CStr(lstCodPos(Index).Tag) = "NN" Then Exit Sub
                cmbCodPos(Index).SelectedIndex = lstCodPos(Index).SelectedIndex
                If CStr(lstCodPos(Index).Tag) = "F" Then Exit Sub
                AltroClick = True
                Testo = cmbCodPos(IndCodPos).Text
                If Testo.Length > 2 Then
                    If Testo.Substring(0, 3) = "Scr" Then
                        lstCodPos(Index).Tag = "NN"
                        lstCodPos(Index).Text = Testo
                        lstCodPos(IndCodPos).SelectionLength = Testo.Length
                        lstCodPos(Index).Tag = "T"
                    End If
                End If
                If lstCodPos(Index).Text = QuoVec(Index) Then Exit Sub '7-5-99
                If Not (Testo.Substring(0, 3) = "Scr") And ClickManuale Then SuperPosN()
                If Not InTesti Then Membro.Variato = True
                With Membro.GenMem.posizione
                    Select Case Index
                        Case 0
                            .Quota = lstCodPos(Index).Text
                        Case 1
                            Testo = UCase(CStr(lstCodPos(Index).SelectedItem).Substring(0, 2))
                            CodPos = lstCodPos(Index).Text
                            If Testo = "XD" Or Testo = "ZD" And Not CodPos.Substring(0, 1) = "S" Then CodPos = CodPos & Testo
                            lstCodPos(Index).Tag = "F"
                            lstCodPos(Index).Text = CodPos
                            lstCodPos(Index).Tag = "T"
                            .Anomal = CodPos
                        Case 2
                            .Raggio = lstCodPos(Index).Text
                        Case 3
                            .DirDiritta = lstCodPos(Index).Text
                        Case 4
                            .DirTraversa = lstCodPos(Index).Text
                    End Select
                End With
                QuoVec(Index) = lstCodPos(Index).Text '7-5-99
                Ridisegna()
                Picture1.Refresh()
                ' lstCodPos(Index).Tag = "NN"
                ' lstCodPos(Index).SelectedIndex = -1
                ' lstCodPos(Index).SelectedIndex = -1
                ' lstCodPos(Index).Text = cmbCodPos(Index).Text
                ' lstCodPos(Index).Tag = "T"
                Abilitato = False
        End Select
    End Sub
    Private Sub cmbPredef_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbPredef.TextChanged
        If Inizializzando Then Exit Sub
        If Not InTesti Then Membro.Variato = True
        Ridisegna()
    End Sub
    Private Sub cmbPredef_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbPredef.SelectedIndexChanged
        Dim i As Short
        If Inizializzando Then Exit Sub
        If Not cmbPredef.Enabled Then Exit Sub
        If Not InTesti Then Membro.Variato = True
        For i = 0 To 4
            lstCodPos(i).Tag = "F"
            lstCodPos(i).Text = Predefiniti(cmbPredef.SelectedIndex + 1, i + 1)
        Next
        SpostaaSinistra()
        For i = 0 To 4 : lstCodPos(i).Tag = "T" : Next
        Abilitato = True
        SuperPosN()
        Abilitato = False
        AltroClick = True
        'Ridisegna
    End Sub
    Private Sub cmbSuChi_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbSuChi.SelectedIndexChanged
        Static SuChiVec As Short '7-5-99
        If Inizializzando Then Exit Sub
        PosizMemb(SuChiVec, cmbSuChi, lstSuChi, 1)
    End Sub
    Private Sub cmbTipo_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbTipo.SelectedIndexChanged 'Aggiorna
        Dim Vecchio As Short
        If Inizializzando Then Exit Sub
        If Not cmbTipo.Enabled Then Exit Sub
        AltroClick = True
        If Not InTesti Then Membro.Variato = True
        If ClickManuale Then SelectedTipo = True
        If Not cmbTipo.SelectedIndex = vList Then
            cmbTipo.Enabled = False
            Select Case Membro.GenMem.Tipo
                Case 6, 7
                    Membro.GenMem.Tipo = CShort(6 + cmbTipo.SelectedIndex)
                    Ammazza()
                    GeomPara()
                Case 8, 9
                    Membro.GenMem.Tipo = CShort(8 + cmbTipo.SelectedIndex)
                    Ammazza()
                    GeomPara()
                Case 26
                    CType(Membro, Fascio).Tubi_Renamed.GenMem.Tipo = CShort(-(8 + cmbTipo.SelectedIndex))
                    Ammazza()
                    GeomPara()
                Case 3, 4, 5
                    Membro.GenMem.Tipo = CShort(3 + cmbTipo.SelectedIndex)
                    Ammazza()
                    GeomPara()
                Case 11, 12, 16
                    Vecchio = Membro.SottoTipo
                    Membro.SottoTipo = CShort(1 + cmbTipo.SelectedIndex)
                    If Vecchio <> Membro.SottoTipo Then
                        Ammazza()
                        cmbSuChi_SelectedIndexChanged(cmbSuChi, New System.EventArgs)
                        GeomPara()
                    End If
                Case 10
                    With CType(Membro, clsBocch)
                        Vecchio = .TipoF
                        .TipoF = CShort(1 + cmbTipo.SelectedIndex)
                        If Vecchio <> .TipoF Then
                            Ammazza()
                            .Appendi(0)
                            GeomPara()
                            If Not .TipoF = 1 Then .DiamScarpa = 0
                            If Not .TipoF = 2 Then .DiamRinf = 0
                        End If
                    End With
                Case 14
                    With CType(Membro, clsNonStd)
                        Vecchio = .TipoF
                        .TipoF = CShort(1 + cmbTipo.SelectedIndex)
                        If Vecchio <> .TipoF Then
                            Ammazza()
                            .Appendi(0)
                            GeomPara()
                            If Not .TipoF = 1 Then .DiamScarpa = 0
                            If Not .TipoF = 2 Then .DiamRinf = 0
                        End If
                    End With
                Case 13
                    CType(Membro, clsTirante).Tipo = cmbTipo.Text.Substring(0, 1)
                Case 17
                    Vecchio = Membro.TipoS
                    Membro.TipoS = CShort(1 + cmbTipo.SelectedIndex)
                    If Vecchio <> Membro.TipoS Then
                        Ammazza()
                        GeomPara()
                    End If
                Case 18
                    With CType(Membro, Dilat)
                        Vecchio = .SottoTipo
                        .SottoTipo = CShort(1 + cmbTipo.SelectedIndex)
                        If Vecchio <> .SottoTipo Then
                            Ammazza()
                            GeomPara()
                            .Appendi(0)
                        End If
                    End With
                Case 21
                    With CType(Membro, Curva)
                        Vecchio = .TipoS
                        .TipoS = CShort(cmbTipo.SelectedIndex)
                        If Vecchio <> Membro.TipoS Then
                            Ammazza()
                            cmbSuChi_SelectedIndexChanged(cmbSuChi, New System.EventArgs)
                            GeomPara()
                        End If
                    End With
                Case 37
                    CType(Membro, Raggrupp).Numero = CShort(1 + cmbTipo.SelectedIndex)
            End Select
            cmbTipo.Enabled = True
        End If
        vList = CShort(cmbTipo.SelectedIndex)
    End Sub
    Private Sub cmbTipo_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbTipo.Enter
        'AltroClick = True
    End Sub
    Private Sub cmdAggiorna_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdAggiorna.Click
        Dim t As System.Windows.Forms.TextBox
        Dim i As Short
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        Enabled = False
        For Each t In txtPara
            If IsNumeric(t.Tag) Then RegTxtPara(CShort(t.Tag))
        Next t
        SuperAggiorna()
        CamTxtPara = False
        Enabled = True
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
    End Sub
    Private Sub cmdAggiorna_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles cmdAggiorna.MouseDown
        'Dim Button As Short = eventArgs.Button \ &H100000
        'Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim x As Single = eventArgs.X
        Dim y As Single = eventArgs.Y
        AltroClick = True
    End Sub
    Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
        Hide()
        Scarica()
        Funzioni.OKfrmDati = False
        GiaAttiva = False
    End Sub
    Private Sub Scarica()
        Dim i As Short
        Librerie(0).Visible = False
        txtPara(0).Enabled = True
        _lblMat_0.Visible = True
        _txtMat_0.Visible = True
        _cmdMat_0.Visible = True
        cmdSvil.Visible = False
        _lblPsp_3.Left = CInt(lblLeft)
        _lblPsp_6.Left = CInt(lblLeft)
        _lblPsp_8.Left = CInt(lblLeft)
        _lblPsp_10.Left = CInt(lblLeft)
        txtPsp(9).Visible = True
        _lblPsp_10.Visible = True
        cmdPrezzo.Visible = True
        VediLordi(True)
        txtPara(0).Enabled = True
        cmbParaO(0).Width = CInt(GlobalRoutines.TwipsToPixelsX(1572))
        cmbParaO(0).Visible = False
        cmbPara(0).Visible = False
        Secondaria(False)
        Frame8.Visible = False
        Frame2.Visible = True
        option1.Visible = False
        option3.Visible = False
        'Option2(0).Visible = False
        'Option2(1).Visible = False
        lblPara(0).Visible = True
        txtPara(0).Visible = True
        Frame5.Visible = True
        Frame6.Visible = True
        Label3.Visible = False
        lblPredef.Visible = False
        cmbPredef.Visible = False
        ToolTip1.SetToolTip(Librerie(0), "")
        For i = 0 To 4
            lblSuchi(i).Visible = True
            lstCodPos(i).Visible = True
        Next
        For i = 1 To CShort(lblPara.Count - 1)
            lblPara.UnLoad(1)
        Next i
        For i = 1 To CShort(txtPara.Count - 1)
            txtPara.UnLoad(1)
        Next i
        For i = 1 To CShort(cmbPara.Count - 1)
            cmbPara.UnLoad(1)
        Next i
        For i = 1 To CShort(Librerie.Count - 1)
            Librerie.UnLoad(i)
        Next
        GiaSpecial = False
        Try
            UnloadtxtPsp(15)
            _lblPsp_15.Visible = False
        Catch e As Exception
        End Try
        AggUnit(1)
    End Sub
    Private Sub cmdCancel_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles cmdCancel.MouseDown
        'Dim Button As Short = eventArgs.Button \ &H100000
        'Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim x As Single = eventArgs.X
        Dim y As Single = eventArgs.Y
        AltroClick = True
    End Sub
    Private Sub cmdMatClick(ByVal Index As Short)
        Dim Mat As LibMat.clsMatCompos
        Dim TipoMatV As Short
        Dim O As Membratura
        Dim i, Code As Short
        Dim TipoS As LibMat.TipoRivestimento
        Dim Capt As String
        If Not InTesti Then Membro.Variato = True
        Code = 1
        Try
            TipoMatV = Membro.TipoMat
            Mat = New LibMat.clsMatCompos
            Mat.DoveMotore = Monitor.Motore
            Mat.TipoCompos = CType(Membro.TipoMat - 1, LibMat.TipoRivestimento)
            Select Case Index
                Case 0
                    Mat.Mat(1).Indmat = Membro.GenMem.Indmat1
                    Mat.Mat(2).Indmat = Membro.GenMem.IndMat2
                Case 1
                    Select Case System.Math.Abs(Membro.GenMem.Tipo)
                        Case 25
                            Mat.Mat(1).Indmat = CShort(CType(Membro, Sella).IndMatRinf)
                        Case Else
                            MsgBox("caso non previsto in frmdati_cmdMat")
                            Exit Sub
                    End Select
            End Select
            ScegliClassiPossibili(Mat)
            Capt = Me.Text
            TipoS = LibMat.TipoRivestimento.Nessuno
            Call Mat.Scelta(0, Inizio.Archdir, Capt, TipoS)
            Select Case Index
                Case 0
                    Membro.TipoMat = CShort(Mat.TipoCompos + 1)
                    With Membro.GenMem
                        .Indmat1 = Mat.Mat(1).Indmat
                        .IndMat2 = Mat.Mat(2).Indmat
                        .Classe1 = Mat.Mat(1).Classe
                        .Classe2 = Mat.Mat(2).Classe
                        .Mater = Mat
                        .PesoSp1 = Mat.Mat(1).PSP * EXP9
                        .PesoSp2 = Mat.Mat(2).PSP * EXP9
                        .LireKg1 = Mat.Mat(1).prezzo(.Param, Mat.Mat(1).Classe, Inizio.Archdir, Inizio.DiscoTem, Code)
                        .LireKg2 = Mat.Mat(2).prezzo(.Param2, Mat.Mat(2).Classe, Inizio.Archdir, Inizio.DiscoTem, Code)
                    End With
                    Ammazza()
                    MembroLeggi(Membro, Inizio.DiscoRam, 0)
                    GeomPara()
                    'Stop
                    'AggTxtPsp()
                    If CType(Membro.GenMem.Appesi, OggList).Count > 0 Then
                        Select Case Membro.GenMem.Tipo
                            Case 31, 32, 33, 37, 25, -19, 19
                                With Membro.GenMem
                                    For i = 1 To CShort(CType(.Appesi, OggList).Count)
                                        O = CType(.Appesi(i - 1), Membratura)
                                        O.TipoMat = CShort(Mat.TipoCompos + 1)
                                        Dim gMem As clsGenMem = O.GenMem
                                        gMem.Indmat1 = Mat.Mat(1).Indmat
                                        gMem.IndMat2 = Mat.Mat(2).Indmat
                                        gMem.Classe1 = Mat.Mat(1).Classe
                                        gMem.Classe2 = Mat.Mat(2).Classe
                                        gMem.Mater = Mat
                                        gMem.PesoSp1 = Mat.Mat(1).PSP * EXP9
                                        gMem.PesoSp2 = Mat.Mat(2).PSP * EXP9
                                        gMem.LireKg1 = Mat.Mat(1).prezzo(.Param, Mat.Mat(1).Classe, Inizio.Archdir, Inizio.DiscoTem, Code)
                                        gMem.LireKg2 = Mat.Mat(2).prezzo(.Param2, Mat.Mat(2).Classe, Inizio.Archdir, Inizio.DiscoTem, Code)
                                        gMem.Materiale = .Materiale
                                        O.CalcGrezzi()
                                    Next
                                End With
                        End Select
                    End If
                Case 1
                    Select Case System.Math.Abs(Membro.GenMem.Tipo)
                        Case 25
                            CType(Membro, Sella).IndMatRinf = Mat.Mat(1).Indmat
                        Case Else
                    End Select
            End Select
            txtMat(Index).Text = Mat.testo
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Private Sub cmdOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOK.Click
        Dim j As Short
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        Membro.GenMem.Materiale = txtMat(0).Text
        NonDisegnare = True
        cmdAggiorna_Click(cmdAggiorna, New System.EventArgs)
        NonDisegnare = False
        If Not Membro.Convalida Then
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default : Exit Sub
        End If
        If CamTxtPara Then
            Try
                For j = 0 To CShort(txtPara.Count - 1)
                    If txtPara(j).Visible Then RegTxtPara(j)
                Next
            Catch e As Exception
                MsgBox(e.Message + vbCrLf + e.StackTrace)
            End Try
        End If
        If IUNL = 5 Then
            If Membro.GenMem.Tipo > 0 Then
                Set4Dir(Membro, CShort((Me.Direzione.SelectedIndex)), Me.Option2(1).Checked)
                Membro.GenMem.posizione.DirTraversa = "Up"
                Membro.GenMem.posizione.Quota = "Ne"
                Membro.GenMem.posizione.Anomal = "N."
                Membro.GenMem.posizione.Raggio = "N."
            End If
        End If
        Hide()
        Scarica()
        Funzioni.OKfrmDati = True
        GiaAttiva = False
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
    End Sub
    Private Sub cmdOK_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles cmdOK.MouseDown
        ' Dim Button As Short = eventArgs.Button \ &H100000
        ' Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim x As Single = eventArgs.X
        Dim y As Single = eventArgs.Y
        AltroClick = True
    End Sub
    Private Sub Direzione_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Direzione.SelectedIndexChanged
        AltroClick = True
    End Sub
    Private Sub frmDati_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
        If Not GiaAttiva Then
            GiaAttiva = True
            Attiva()
        End If
    End Sub
    Private Sub frmDati_Paint(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        '      If Not GiaAttiva Then
        '      GiaAttiva = True
        '      Attiva()
        '      End If
    End Sub
    Private Sub frmDati_Closing(ByVal eventSender As System.Object, ByVal eventArgs As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Dim Cancel As Boolean = eventArgs.Cancel
        If IUNL < 6 Then MyDatabase.Close()
        eventArgs.Cancel = Cancel
    End Sub
    Public Sub GeomPara()
        Dim i, Tipo, Nf, ini As Short
        Dim j As Short
        If Inizializzando Then Exit Sub
        EnaTxtPara = False : ClickManuale = False
        Tipo = System.Math.Abs(Membro.GenMem.Tipo)
        Tipi(Tipo)
        InTesti = True
        If IUNL < 5 Then
            _lblPsp_1.Visible = Membro.GenMem.IndMat2 > 0
            _lblPsp_2.Visible = Membro.GenMem.IndMat3 > 0
            EnaTxtPsp()
            AggTxtPsp()
        Else
            Frame2.Visible = False
            Picture1.Visible = False
        End If
        ReDim LblArr(22) '5-5-99
        Testi(Tipo, Nf)
        nArr = Nf
        ini = 1
        If Not Membro.GenMem.Tipo = 25 Then
            ReDim LblArr(nArr)
            Select Case Membro.GenMem.Tipo 'aggiorna
                Case -10, 10, 14
                    ' Set TextArr(0) = txtPara(0)
                    option1.Text = "con flangia accoppiata"
                    LblArr(0) = option1
                    TextArr(0) = option1
                    'option3.Top = option1.Top + 1.1 * option1.Height
                    TextArr(1) = option3
                    LblArr(1) = option3
                    nArr = CShort(nArr + 1)
                    ReDim Preserve LblArr(nArr)
                    ini = 2
                Case Else
                    TextArr(0) = txtPara(0)
                    LblArr(0) = lblPara(0)
            End Select
            For i = ini To nArr
                Select Case Membro.GenMem.Tipo 'aggiorna
                    Case 8, 9, 26, -8, -9
                        Select Case i
                            Case 2, 4
                                TextArr(i) = cmbPara(i)
                            Case Else
                                TextArr(i) = txtPara(i)
                        End Select
                        LblArr(i) = lblPara(i)
                    Case 19, -19
                        Select Case i
                            Case 1, 2, 3, 12
                                TextArr(i) = cmbPara(i)
                            Case Else
                                TextArr(i) = txtPara(i)
                        End Select
                        LblArr(i) = lblPara(i)
                    Case 10, 14, -10, -14
                        TextArr(i) = txtPara(i - 1)
                        LblArr(i) = lblPara(i - 1)
                    Case 25
                        TextArr(i) = txtPara(i) '6-5-99
                        LblArr(i) = lblPara(i) '6-5-99
                        '            già fatto ( Selle)
                    Case Else
                        TextArr(i) = txtPara(i)
                        LblArr(i) = lblPara(i)
                End Select
            Next
            For i = CShort(Nf + 1) To nArr
                TextArr(i).Visible = False
                LblArr(i).Visible = False
            Next
            Select Case System.Math.Abs(Membro.GenMem.Tipo)
                Case 14
                    For i = nArr To 24
                        txtPara(i).Visible = False
                        lblPara(i).Visible = False
                    Next
                Case 16
                    For i = CShort(nArr + 1) To 24
                        txtPara(i).Visible = False
                        lblPara(i).Visible = False
                    Next
                Case 18
                    For i = CShort(nArr + 1) To 21
                        txtPara(i).Visible = False
                        lblPara(i).Visible = False
                    Next
            End Select
        End If
        EnaTesti(ini, nArr)
        Special(Tipo)
        If Membro.GenMem.Tipo = 25 Then '8-5-99
            Frame1.Visible = True
            Frame7.Height = CInt(GlobalRoutines.TwipsToPixelsY(465))
            Frame7.Visible = True
            Frame7.Left = 0
            Frame7.Width = CInt(GlobalRoutines.TwipsToPixelsX(4920))
            Frame7.Top = CInt(lblTipo.Top + lblTipo.Height + GlobalRoutines.TwipsToPixelsY(30))
            'Frame7.Height = 30 + txtMat(1).Height * 1.5 + Image1(0).Height
            'For i = 0 To 3: Image1(i).Top = 500: Next
            txtDen.Text = Membro.GenMem.Denom
            Frame1.Height = CInt(LblArr(nArr).Top + LblArr(nArr).Height * 1.5)
            Frame1.Top = Frame7.Top + Frame7.Height
        Else
            Combo1.Visible = False
            Frame1.Visible = True
            Frame7.Visible = False
            Frame1.Height = CInt(LblArr(nArr).Top + LblArr(nArr).Height * 1.5)
            Frame1.Top = CInt(lblTipo.Top + GlobalRoutines.TwipsToPixelsY(30) + lblTipo.Height)
            txtDen.Text = Membro.GenMem.Denom
        End If
        If IUNL < 5 Then
            Picture1.Height = Frame1.Top + Frame1.Height
            Frame2.Top = CInt(Frame1.Top + Frame1.Height + GlobalRoutines.TwipsToPixelsY(50))
            Frame8.Top = Frame2.Top
            Frame3.Top = Frame2.Top + Frame2.Height
            Height = Frame3.Top + Frame3.Height + Height - ClientRectangle.Height
            FramePict.Top = FramePict.Top + Frame2.Top - Frame4.Top
            Frame4.Top = Frame2.Top
            txtPos.Text = Str(Membro.GenMem.PosDis)
            txtQta.Text = Str(Membro.GenMem.Qta)
            txtDes.Text = Membro.GenMem.Dimensioni
            txtNot.Text = Membro.GenMem.Note
            Frame5.Visible = False
            Frame6.Visible = False
            If Not job.Comm Is Nothing Then If Not CBool(job.Comm.CalcBaric) Then Exit Sub
        Else
            Frame5.Visible = (Membro.GenMem.Tipo > 0) And IUNL < 6
            Frame6.Visible = (Membro.GenMem.Tipo > 0) And IUNL < 6
            Frame3.Visible = False
            Frame4.Visible = False
            cmdZoom.Visible = False
            cmdAggiorna.Visible = False
            cmdCancel.Visible = False
            Frame5.Top = CInt(Frame1.Top + Frame1.Height + GlobalRoutines.TwipsToPixelsY(50))
            'Frame5.Height = 855
            'Frame5.Width = 2175
            Frame6.Top = Frame5.Top
            FramePict.Left = Frame1.Left
            If jRec = 0 Then
                FramePict.Top = CInt(Frame5.Top + Frame5.Height + GlobalRoutines.TwipsToPixelsY(50))
            Else
                FramePict.Top = CInt(Frame5.Top + GlobalRoutines.TwipsToPixelsY(50))
            End If
            Height = CInt(FramePict.Top + FramePict.Height + GlobalRoutines.TwipsToPixelsY(400))
            Width = CInt(Frame1.Left + Frame1.Width + GlobalRoutines.TwipsToPixelsX(100))
            Option2(1).Checked = True
            Direzione.Items.Clear()
            Direzione.Items.Add("Verso l'alto")
            Direzione.Items.Add("Verso il basso")
            Direzione.Items.Add("Verso destra")
            Direzione.Items.Add("Verso sinistra")
            Direzione.Items.Add("Contro il foglio")
            Direzione.Items.Add("Verso l'osservatore")
            Direzione.SelectedIndex = 0
        End If
        EnaTxtPara = True : ClickManuale = True
        InTesti = False
    End Sub
    Private Sub SpostaaSinistra()
        Dim Testo As String
        Dim Recv, Rec As clsGenMem
        Dim Membrov As Membratura = Nothing
        Rec = Membro.GenMem
        Recv = Rec.posizione.SuChi.GenMem
        Select Case System.Math.Abs(Recv.Tipo)
            Case 1, 2
                Select Case System.Math.Abs(Rec.Tipo)
                    Case 21
                        lstCodPos(1).Text = lstCodPos(4).Text
                End Select
            Case 6
                Select Case System.Math.Abs(Rec.Tipo)
                    Case 1
                        lstCodPos(0).Text = lstCodPos(2).Text
                End Select
            Case 11
                Select Case System.Math.Abs(Rec.Tipo)
                    Case 6 : lstCodPos(0).Text = lstCodPos(2).Text
                    Case 3, 4, 5
                        lstCodPos(0).Text = lstCodPos(2).Text
                End Select
            Case 12
                Select Case System.Math.Abs(Rec.Tipo)
                    Case 3, 4, 5
                        lstCodPos(1).Text = lstCodPos(0).Text
                    Case 34
                        Select Case Membrov.SottoTipo
                            Case 3, 7 : lstCodPos(0).Text = lstCodPos(1).Text
                        End Select
                    Case 6
                        Testo = lstCodPos(2).Text
                        lstCodPos(2).Text = lstCodPos(1).Text
                        lstCodPos(1).Text = lstCodPos(0).Text
                        lstCodPos(0).Text = Testo
                End Select
        End Select
    End Sub
    Public Sub GenMemInText()
        Dim i As Short
        Dim Recv, Rec As clsGenMem
        Rec = Membro.GenMem
        Recv = Rec.posizione.SuChi.GenMem
        For i = 0 To 4 : lstCodPos(i).Tag = "F" : Next
        lstCodPos(0).Text = Rec.posizione.Quota
        lstCodPos(1).Text = Rec.posizione.Anomal
        lstCodPos(2).Text = Rec.posizione.Raggio
        lstCodPos(3).Text = Rec.posizione.DirDiritta
        lstCodPos(4).Text = Rec.posizione.DirTraversa
        SpostaaSinistra()
        For i = 0 To 4 : lstCodPos(i).Tag = "T" : Next
    End Sub
    Private Sub frmDati_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseMove
        ' Dim Button As Short = eventArgs.Button \ &H100000
        ' Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim x As Single = eventArgs.X
        Dim y As Single = eventArgs.Y
        PictHelp.Visible = False
    End Sub
    Public Sub Button_Click(ByVal Nome As String)
        Dim s() As String = Nome.Split(CChar("_"))
        Dim Textnum As String = s(1)
        Dim Index As Short = CShort(s(2))
        Dim Vecchio As Short
        Dim File As String
        Dim i As Short
        Try
            With Membro
                Select Case System.Math.Abs(CType(.GenMem, clsGenMem).Tipo)
                    Case 6, 7
                        With CType(Membro, Cono)
                            Select Case Index
                                Case 0
                                    .StandardG.Scelta(Inizio.Archdir, Inizio.DiscoTem)
                                    TextArr(0).Text = .StandardG.Diam.ToString
                                    RegTxtPara(0)
                                    TextArr(6).Text = .StandardG.Spess.ToString
                                    RegTxtPara(6)
                                Case 1
                                    .StandardP.Scelta(Inizio.Archdir, Inizio.DiscoTem)
                                    TextArr(3).Text = .StandardP.Diam.ToString
                                    RegTxtPara(3)
                            End Select
                        End With
                    Case 2, 21
                        CType(.StandardPip, LibMat.clsPipe).Scelta(Inizio.Archdir, Inizio.DiscoTem)
                        TextArr(0).Text = CType(.StandardPip, LibMat.clsPipe).Diam.ToString
                        RegTxtPara(0)
                        TextArr(1).Text = CType(.StandardPip, LibMat.clsPipe).Spess.ToString
                        RegTxtPara(1)
                    Case 10
                        With CType(Membro, clsBocch)
                            globFlangia = .Standard
                            globFlangia.Scelta(Inizio.DiscoTem, True)
                            .DiamInt = globFlangia.DiamInt
                            Ammazza()
                            If Not .Pad Is Nothing Then
                                .Pad.DiamExt = Int(2 * globFlangia.DiamTr)
                            End If
                        End With
                        GeomPara()
                        '           TextArr(2).Text = .Standard.DiamInt
                        '           TextArr(3).Text = .Standard.Altezza
                    Case 14
                        With CType(Membro, clsNonStd)
                            .Pipe.Scelta()
                            .DiamExt = .Pipe.Diam
                            .DiamInt = .DiamExt - 2 * .Pipe.Spess
                            If .TipoF = 4 Then
                                globFlangia = .Standard
                                .Standard.Scelta(Inizio.DiscoTem)
                                .SpessFl = .Standard.Spessore
                                .DiamFl = .Standard.DiamExt
                                .BoltCir = .Standard.BC
                                .B3 = .Standard.DiaFori
                                .LC = .Standard.NumBolts
                            End If
                        End With
                        Ammazza()
                        GeomPara()
                    Case 12
                        For i = 0 To CShort(txtPara.Count - 1)
                            If txtPara(i).Visible Then RegTxtPara(i)
                        Next
                        With CType(Membro, Piastrone)
                            .AG = 0
                            .TG = 0
                            Call .SovraMet()
                            TextArr(nArr - 1).Text = .AG.ToString
                            RegTxtPara(CShort(nArr - 1))
                            TextArr(nArr).Text = .TG.ToString
                            RegTxtPara(nArr)
                        End With
                    Case 13
                        CType(Membro, clsTirante).StandardTir.Scelta(Inizio.Archdir, Inizio.DiscoTem)
                        TextArr(0).Text = CType(Membro, clsTirante).StandardTir.DN
                        RegTxtPara(0)
                        AggMetrica()
                    Case 18
                        With CType(Membro, Dilat)
                            Select Case Index
                                Case 0 'materiale collare
                                    If .MatColl Is Nothing Then .MatColl = New LibMat.MaterialeNew1
                                    .MatColl.Scelta(0, Inizio.Archdir, Inizio.DiscoTem)
                                    For i = 0 To nArr
                                        If Val(TextArr(i).Tag) = 18 Then
                                            TextArr(i).Text = .MatColl.MatStr
                                            RegTxtPara(i)
                                        End If
                                    Next
                                Case 1 'materiale anelli
                                    If .MatAnel Is Nothing Then .MatAnel = New LibMat.MaterialeNew1
                                    .MatAnel.Scelta(0, Inizio.Archdir, Inizio.DiscoTem)
                                    For i = 0 To nArr
                                        If Val(TextArr(i).Tag) = 19 Then
                                            TextArr(i).Text = .MatAnel.MatStr
                                            RegTxtPara(i)
                                        End If
                                    Next
                                Case 2 'materiale bulloni
                                    If .MatBull Is Nothing Then .MatBull = New LibMat.MaterialeNew1
                                    .MatBull.Scelta(LibMat.ClasseMateriale.Bulloneria, Inizio.Archdir, Inizio.DiscoTem)
                                    For i = 0 To nArr
                                        If Val(TextArr(i).Tag) = 20 Then
                                            TextArr(i).Text = .MatBull.MatStr
                                            RegTxtPara(i)
                                        End If
                                    Next
                            End Select
                        End With
                    Case 26
                        With CType(Membro, Fascio)
                            File = FunzLibgra.FileDes("INP")
                            If .LayOut Is Nothing Then
                                .LayOut = New traccia.clsTracciatura
                                .LayOut.DoveMotore = Motore
                                .LayOut.DoveRoutines = Funzioni.DisRut
                                Funzioni.DisRut.Init200((Inizio.Archdir))
                            End If
                            .LeggiDT()
                            .Genera(File)
                            .LayOut.Esegui(1, File)
                            txtPara(7).Text = .FileTrac
                            .LayOut.Scrivi()
                            .LeggiDT(1)
                        End With
                        GeomPara()
                        RegTxtPara(7)
                    Case 19
                        With CType(Membro, Diaframma)
                            Select Case Index
                                Case 0
                                    .Unsupported()
                                    txtPara(4).Text = Str(.Spessore)
                                    RegTxtPara(4)
                                Case 1
                                    .NumDiaf()
                            End Select
                        End With
                    Case 25
                        DbaseSelle.DefInstance.dBase = Index = 0
                        DbaseSelle.DefInstance.ShowDialog()
                        CType(Membro, Sella).PrSeFinDil(11)
                    Case 28
                        With CType(Membro, clsGuarniz)
                            Vecchio = .StandardGua.Class
                            .StandardGua.Scelta(Inizio.Archdir, Inizio.DiscoTem)
                            TextArr(0).Text = .StandardGua.ClassS
                            RegTxtPara(0)
                            TextArr(1).Text = .StandardGua.TipoS
                            RegTxtPara(1)
                            If Vecchio <> .StandardGua.Class Then
                                .StringDIME()
                                .StringNOTE()
                                GeomPara()
                            End If
                        End With
                End Select
            End With
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Private Sub Option1_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles option1.CheckStateChanged 'Aggiorna
        If Inizializzando Then Exit Sub
        Select Case System.Math.Abs(Membro.GenMem.Tipo)
            Case 10 'ma per 14 qualcosa di diverso
                With CType(Membro, clsBocch)
                    .Accoppiata = option1.CheckState = 1
                    If Not .Accoppiata Then
                        .Cieca = False
                        option3.CheckState = System.Windows.Forms.CheckState.Unchecked
                        option3.Visible = False
                    Else
                        option3.Visible = True
                    End If
                End With
            Case 14 'ma per 14 qualcosa di diverso
                With CType(Membro, clsBocch)
                    .Accoppiata = option1.CheckState = 1
                    If Not .Accoppiata Then
                        .Cieca = False
                        option3.CheckState = System.Windows.Forms.CheckState.Unchecked
                        option3.Visible = False
                    Else
                        option3.Visible = True
                    End If
                End With
            Case 3, 4, 5
                CType(Membro, Fondo).ForoCentrale = option1.CheckState = 1
                GeomPara()
        End Select
        If Not InTesti Then Membro.Variato = True
    End Sub
    Private Sub Option3_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles option3.CheckStateChanged
        If Inizializzando Then Exit Sub
        Select Case System.Math.Abs(Membro.GenMem.Tipo)
            Case 10 'ma per 14 qualcosa di diverso
                CType(Membro, clsBocch).Cieca = option1.CheckState = 1
                If Not InTesti Then Membro.Variato = True
            Case 14  'ma per 14 qualcosa di diverso
                CType(Membro, clsNonStd).Cieca = option1.CheckState = 1
                If Not InTesti Then Membro.Variato = True
        End Select
    End Sub
    Private Sub Picture1_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles Picture1.MouseDown
        Dim Button As MouseButtons = eventArgs.Button  '\ &H100000
        ' Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        If Button = MouseButtons.Left And Zooming Then
            xTop = eventArgs.X
            yTop = eventArgs.Y
            xBot = xTop
            yBot = yTop
        End If
    End Sub
    Private Sub Picture1_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles Picture1.MouseMove
        Dim Button As MouseButtons = eventArgs.Button
        'Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim x As Single = eventArgs.X
        Dim y As Single = eventArgs.Y
        PictHelp.Visible = False
        If Button = MouseButtons.Left And Zooming Then
            Dim r As New Rectangle(CInt(xTop), CInt(yTop), CInt(xBot - xTop), CInt(yBot - yTop))
            r = Picture1.RectangleToScreen(r)
            ControlPaint.DrawReversibleFrame(r, Color.White, FrameStyle.Dashed)
            xBot = x : yBot = y
            r = New Rectangle(CInt(xTop), CInt(yTop), CInt(xBot - xTop), CInt(yBot - yTop))
            r = Picture1.RectangleToScreen(r)
            ControlPaint.DrawReversibleFrame(r, Color.White, FrameStyle.Dashed)
        End If
    End Sub
    Private Sub Picture1_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles Picture1.MouseUp
        Dim Button As MouseButtons = eventArgs.Button
        'Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        If Button = MouseButtons.Left And Zooming Then
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
            Dim b As SolidBrush = New SolidBrush(Color.FromArgb(200, 255, 255)) 'colorino di sfondo dello zoom
            If xBot < xTop Then GlobalRoutines.SWAP(xBot, xTop)
            If yBot < yTop Then GlobalRoutines.SWAP(yBot, yTop)
            With Funzioni.DisRut
                .MouseToWorld(xTop, yTop)
                .MouseToWorld(xBot, yBot)
                If Not .Scala(xTop, xBot, yBot, yTop) Then Exit Sub
                .PennaFill = b
                .quadrato(xTop, yBot, xBot, yTop, 0, 0, True)
                .quadrato(xTop, yBot, xBot, yTop, 0, 0, False)
            End With
            Editing = True
            Disegno(2, 1, ApparProv)
            Editing = False
            Picture1.Refresh()
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        End If
    End Sub
    Private Sub txtDen_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtDen.TextChanged
        If Inizializzando Then Exit Sub
        Me.Text = "Membratura: " & txtDen.Text
    End Sub
    Public Sub AggSuChi()
        Dim Elem As clsGenMem
        Dim i, j As Short
        If IUNL = 6 Then Exit Sub
        Try
            cmbSuChi.Items.Clear()
            lstSuChi.Items.Clear()
            cmbFinoA.Items.Clear()
            lstFinoA.Items.Clear()
            cmbFinoA.Items.Add("Non specificato")
            lstFinoA.Items.Add("0")
            For j = 1 To CShort(Apparecchio.Elementi.Count)
                Elem = CType(Apparecchio.Elementi(j - 1), Membratura).GenMem
                If System.Math.Abs(Elem.Tipo) < 96 And Not Elem.Parent Is Membro And Elem.PosDis > 0 Or j = 1 Then
                    cmbSuChi.Items.Add(Str(Elem.PosDis) & " | " & Elem.Denom)
                    lstSuChi.Items.Add(Str(j))
                    If Membro.GenMem.Tipo = 1 Then
                        cmbFinoA.Items.Add(Str(Elem.PosDis) & " | " & Elem.Denom)
                        lstFinoA.Items.Add(Str(j))
                    End If
                End If
            Next
            For i = 1 To CShort(Apparecchio.Elementi.Count)
                If Apparecchio.Elementi(i - 1) Is Membro.GenMem.posizione.SuChi Then
                    For j = 0 To CShort(lstSuChi.Items.Count - 1)
                        If CShort(lstSuChi.Items(j)) = i Then
                            cmbSuChi.SelectedIndex = j
                            Exit For
                        End If
                    Next
                    Exit For
                End If
            Next
            If Membro.GenMem.Tipo = 1 Then
                If Membro.GenMem.posizione.ForoSecondario Is Nothing Then
                    cmbFinoA.SelectedIndex = 0
                Else
                    For i = 1 To CShort(Apparecchio.Elementi.Count)
                        If Apparecchio.Elementi(i - 1) Is Membro.GenMem.posizione.ForoSecondario Then
                            For j = 1 To CShort(lstFinoA.Items.Count - 1)
                                If CShort(lstFinoA.Items(j)) = i Then
                                    cmbFinoA.SelectedIndex = j
                                    Exit For
                                End If
                            Next
                            Exit For
                        End If
                    Next
                End If
            End If
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Private Sub Ammazza()
        Dim i As Short
        GiaSpecial = False
        Librerie.RemoveAll(1)
        lblPara.RemoveAll(1)
        TextArr.RemoveAll(1)
        For i = 1 To CShort(lblPara.Count - 1)
            lblPara(i).Visible = False
            TextArr(i).Visible = False
        Next
        For i = 1 To CShort(Librerie.Count - 1)
            Librerie(i).Visible = False
        Next
    End Sub
    Private Sub txtDen_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles txtDen.MouseDown
        'Dim Button As Short = eventArgs.Button \ &H100000
        'Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        AltroClick = True
    End Sub
    Private Sub txtDen_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles txtDen.MouseMove
        'Dim Button As Short = eventArgs.Button \ &H100000
        'Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        PictHelp.Visible = False
    End Sub
    Private Sub txtDes_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtDes.TextChanged
        If Inizializzando Then Exit Sub
        Membro.GenMem.Dimensioni = txtDes.Text
        If Not InTesti Then Membro.Variato = True
    End Sub
    Private Sub txtDes_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles txtDes.MouseDown
        ' Dim Button As Short = eventArgs.Button \ &H100000
        ' Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        AltroClick = True
    End Sub
    Private Sub txtMat_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs)
        'Dim Button As Short = eventArgs.Button \ &H100000
        'Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        AltroClick = True
    End Sub
    Private Sub txtMat_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs)
        'Dim Button As Short = eventArgs.Button \ &H100000
        'Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        PictHelp.Visible = False
    End Sub
    Private Sub txtNot_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtNot.TextChanged
        If Inizializzando Then Exit Sub
        Membro.GenMem.Note = txtNot.Text
        If Not InTesti Then Membro.Variato = True
    End Sub
    Private Sub txtNot_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles txtNot.MouseDown
        'Dim Button As Short = eventArgs.Button \ &H100000
        'Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        AltroClick = True
    End Sub
    Public Sub Text_Changed(ByVal Nome As String)
        If Inizializzando Then Exit Sub
        Dim s() As String = Nome.Split(CChar("_"))
        Dim Textnum As String = s(1)
        Dim Index As Short = CShort(s(2))
        CamTxtPara = True
        If Not InTesti Then Membro.Variato = True
        'AltroClick = False
        Select Case CType(Membro.GenMem, clsGenMem).Tipo
            Case 6, 7
                Select Case Index
                    Case 7, 8
                        RegTxtPara(Index)
                End Select
        End Select
    End Sub
    Public Sub Text_Enter(ByVal Nome As String)
        Dim s() As String = Nome.Split(CChar("_"))
        Dim Textnum As String = s(1)
        Dim Index As Short = CShort(s(2))
        'AltroClick = False
    End Sub
    Private Sub Text_KeyDown(ByVal Nome As String, ByVal eventArgs As System.Windows.Forms.KeyEventArgs)
        'Dim KeyCode As Short = eventArgs.KeyCode
        'Dim Shift As Short = eventArgs.KeyData \ &H10000
        Dim s() As String = Nome.Split(CChar("_"))
        Dim Textnum As String = s(1)
        Dim Index As Short = CShort(s(2))
        'If KeyCode = vbKeyReturn Then KeyCode = vbKeyDown
    End Sub
    Public Sub Text_KeyPress(ByVal Nome As String, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs)
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        Dim s() As String = Nome.Split(CChar("_"))
        Dim Textnum As String = s(1)
        Dim Index As Short = CShort(s(2))
        If KeyAscii = System.Windows.Forms.Keys.Return Then
            KeyAscii = 0
            Text_Leave(Nome)
        End If
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub
    Public Sub Text_KeyUp(ByVal Nome As String, ByVal eventArgs As System.Windows.Forms.KeyEventArgs)
        Dim KeyCode As Short = CShort(eventArgs.KeyCode)
        'Dim Shift As Short = eventArgs.KeyData \ &H10000
        Dim s() As String = Nome.Split(CChar("_"))
        Dim Textnum As String = s(1)
        Dim Index As Short = CShort(s(2))
        Call TrattaCar(Index, KeyCode, txtPara(Index), TextArr, nArr)
    End Sub
    Public Sub Text_Leave(ByVal Nome As String)
        Dim s() As String = Nome.Split(CChar("_"))
        Dim Textnum As String = s(1)
        Dim Index As Short = CShort(s(2))
        If Not EnaTxtPara Then Exit Sub
        If Not CamTxtPara Or Not AltroClick Then Exit Sub
        If Not AggiornamentoAutomatico Then Exit Sub
        AggiornaPara(Index)
        CamTxtPara = False
    End Sub
    Public Sub Text_MouseDown(ByVal Nome As String, ByVal eventArgs As System.Windows.Forms.MouseEventArgs)
        'Dim Button As Short = eventArgs.Button \ &H100000
        'Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        'Dim x As Single = LegacyUiUnits.PixelsToTwipsX(eventArgs.X)
        'Dim y As Single = LegacyUiUnits.PixelsToTwipsY(eventArgs.Y)
        Dim s() As String = Nome.Split(CChar("_"))
        Dim Textnum As String = s(1)
        Dim Index As Short = CShort(s(2))
        AltroClick = True
    End Sub
    Private Sub txtPos_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtPos.TextChanged
        If Inizializzando Then Exit Sub
        Membro.GenMem.PosDis = CShort(Val(txtPos.Text))
    End Sub
    Private Sub txtPos_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtPos.Leave
        If Not CheckPos(CShort(Val(txtPos.Text))) Then
            MsgBox("La posizione digitata (" & txtPos.Text & ") è già occupata", MsgBoxStyle.Exclamation)
            Membro.GenMem.PosDis = Funzioni.SetPosizN
            txtPos.Text = Str(Membro.GenMem.PosDis)
        End If
    End Sub
    Private Sub txtPos_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles txtPos.MouseDown
        'Dim Button As Short = eventArgs.Button \ &H100000
        'Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        AltroClick = True
    End Sub
    Private Sub txtPsp_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        If Inizializzando Then Exit Sub
        Dim Index As Short = IndexedControls.IndexOf(txtPsp, CType(eventSender, TextBox))
        Dim i As Short
        Dim g As clsGenMem
        If Not txtPsp(Index).Enabled Or Not txtPsp(Index).Visible Then Exit Sub
        If Not InTesti Then Membro.Variato = True
        g = Membro.GenMem
        With g
            Select Case Index
                Case 0 '.PesoSp1 = GlobalRoutines.ValVir(txtPsp(Index).Text) * EXP9
                    Membro.Pesi()
                Case 1 '.PesoSp2 = GlobalRoutines.ValVir(txtPsp(Index).Text) * EXP9
                    Membro.Pesi()
                Case 2 '.PesoSp3 = GlobalRoutines.ValVir(txtPsp(Index).Text) * EXP9
                    Membro.Pesi()
                Case 3 : .Pnet0 = GlobalRoutines.ValVir(txtPsp(Index).Text) ' * EXP9
                    If Trim(g.MF) = "FL" Then
                        .LireTot1 = .LireKg1 * .Pnet0
                        LireTot(g)
                        txtPsp(14).Text = LTrim(Str(.LireTot / 1000000.0#))
                    Else
                    End If
                Case 4 : .Pnet1 = GlobalRoutines.ValVir(txtPsp(Index).Text) '* EXP9
                    If Trim(g.MF) = "FL" Then
                        .LireTot2 = .LireKg2 * .Pnet1
                        LireTot(g)
                        txtPsp(14).Text = LTrim(Str(.LireTot / 1000000.0#))
                    Else
                    End If
                Case 5 ': .PesoSp1 = GlobalRoutines.ValVir(txtPsp(Index).Text) * EXP9
                Case 6 : .plor0 = GlobalRoutines.ValVir(txtPsp(Index).Text) '* EXP9
                    If Trim(g.MF) = "FL" Then
                    Else
                        .LireTot1 = .LireKg1 * .plor0
                        LireTot(g)
                        txtPsp(14).Text = LTrim(Str(.LireTot / 1000000.0#))
                    End If
                Case 7 : .Plor1 = GlobalRoutines.ValVir(txtPsp(Index).Text) '* EXP9
                    If Trim(g.MF) = "FL" Then
                    Else
                        .LireTot2 = .LireKg2 * .Plor1
                        LireTot(g)
                        txtPsp(14).Text = LTrim(Str(.LireTot / 1000000.0#))
                    End If
                Case 8 ': .PesoSp1 = GlobalRoutines.ValVir(txtPsp(Index).Text) * EXP9
                Case 9 : .LireKg1 = GlobalRoutines.ValVir(txtPsp(Index).Text) ' * EXP9
                    If Trim(g.MF) = "FL" Then
                        .LireTot1 = .LireKg1 * .Pnet0
                    Else
                        .LireTot1 = .LireKg1 * .plor0
                    End If
                    LireTot(g)
                    AggTxtPsp14()
                Case 10 : .LireKg2 = GlobalRoutines.ValVir(txtPsp(Index).Text) ' * EXP9
                    If Trim(g.MF) = "FL" Then
                        .LireTot2 = .LireKg2 * .Pnet1
                    Else
                        .LireTot2 = .LireKg2 * .Plor1
                    End If
                    LireTot(g)
                    AggTxtPsp14()
                Case 11 ': .LireKg3 = GlobalRoutines.ValVir(txtPsp(Index).Text)
                Case 12
                Case 13
                Case 14 : Dim p As Single = GlobalRoutines.ValVir(txtPsp(Index).Text)
                    If _lblPsp_13.Text = "Costo (kEUR)" Then
                        .LireTot = p * 1000
                    Else
                        .LireTot = p
                    End If
                Case 15 : .LireLETot = GlobalRoutines.ValVir(txtPsp(Index).Text)
                    LireTot(g)
            End Select
        End With
        Try
            For i = 0 To 15
                If i <> Index Then txtPsp(i).Enabled = False
            Next
        Catch
        End Try
        txtPsp(Index).Tag = "s"
        AggTxtPsp()
        txtPsp(Index).Tag = ""
        Try
            For i = 0 To 15
                txtPsp(i).Enabled = True
            Next
        Catch
        End Try
        If Not AltroClick Then txtPsp(Index).Focus()
        AltroClick = False
    End Sub
    Private Sub LireTot(ByVal g As clsGenMem)
        With g
            If Trim(g.MF) = "FC" Or Trim(g.MF) = "FD" Then
                '  .LireTot = .LireTot1 + .LireTot2 + .LireLETot * 1000000#
                .LireTot = CSng(.LireLETot * 1000000.0#)
                .LireTot1 = 0
                .LireTot2 = 0
            Else
                .LireTot = CSng(.LireTot1 + .LireTot2 + .LireLETot * 1000000.0#)
            End If
        End With
    End Sub
    Private Sub AggTxtPsp()
        If Inizializzando Then Exit Sub
        If Not CStr(txtPsp(0).Tag) = "s" Then txtPsp(0).Text = (Membro.GenMem.PesoSp1 / EXP9).ToString
        If Not CStr(txtPsp(1).Tag) = "s" Then txtPsp(1).Text = (Membro.GenMem.PesoSp2 / EXP9).ToString
        If Not CStr(txtPsp(2).Tag) = "s" Then txtPsp(2).Text = (Membro.GenMem.PesoSp3 / EXP9).ToString
        If Not CStr(txtPsp(3).Tag) = "s" Then txtPsp(3).Text = Membro.GenMem.Pnet0.ToString
        If Not CStr(txtPsp(4).Tag) = "s" Then txtPsp(4).Text = Membro.GenMem.Pnet1.ToString
        If Not CStr(txtPsp(5).Tag) = "s" Then txtPsp(5).Text = "" '  txtPsp(5).Text = LTrim$(Str$(ctype(Membro.Genmem,clsGenmem).Pnet2  ))
        If Not CStr(txtPsp(6).Tag) = "s" Then txtPsp(6).Text = Membro.GenMem.plor0.ToString
        If Not CStr(txtPsp(7).Tag) = "s" Then txtPsp(7).Text = Membro.GenMem.Plor1.ToString
        If Not CStr(txtPsp(8).Tag) = "s" Then txtPsp(8).Text = "" '  txtPsp(8).Text = LTrim$(Str$(ctype(Membro.Genmem,clsGenmem).Plor2  ))
        If Not CStr(txtPsp(9).Tag) = "s" Then txtPsp(9).Text = Membro.GenMem.LireKg1.ToString
        If Not CStr(txtPsp(10).Tag) = "s" Then txtPsp(10).Text = Membro.GenMem.LireKg2.ToString
        If Not CStr(txtPsp(11).Tag) = "s" Then txtPsp(11).Text = "" '  txtPsp(11).Text = LTrim$(Str$(ctype(Membro.Genmem,clsGenmem).LireKg3))
        If Not CStr(txtPsp(12).Tag) = "s" Then txtPsp(12).Text = (Membro.GenMem.Pnet0 + Membro.GenMem.Pnet1).ToString
        If Not CStr(txtPsp(13).Tag) = "s" Then txtPsp(13).Text = (Membro.GenMem.plor0 + Membro.GenMem.Plor1).ToString
        If Not CStr(txtPsp(14).Tag) = "s" Then AggTxtPsp14()
        Try
            If Not CStr(txtPsp(15).Tag) = "s" Then txtPsp(15).Text = Membro.GenMem.LireLETot.ToString
        Catch e As Exception
        End Try
    End Sub
    Private Sub EnaTxtPsp()
        Dim i As Short
        For i = 0 To 3
            txtPsp(CShort(0 + 3 * i)).Enabled = True
            txtPsp(CShort(1 + 3 * i)).Enabled = Membro.GenMem.IndMat2 > 0
            txtPsp(CShort(2 + 3 * i)).Enabled = Membro.GenMem.IndMat3 > 0
            txtPsp(CShort(0 + 3 * i)).Visible = True
            txtPsp(CShort(1 + 3 * i)).Visible = Membro.GenMem.IndMat2 > 0
            txtPsp(CShort(2 + 3 * i)).Visible = Membro.GenMem.IndMat3 > 0
        Next
        If Membro.GenMem.IndMat2 = 0 Then
            _lblPsp_3.Left = _lblPsp_1.Left
            _lblPsp_6.Left = _lblPsp_1.Left
            _lblPsp_8.Left = _lblPsp_1.Left
            _lblPsp_10.Left = _lblPsp_1.Left
        ElseIf Membro.GenMem.IndMat3 = 0 Then
            _lblPsp_3.Left = _lblPsp_2.Left
            _lblPsp_6.Left = _lblPsp_2.Left
            _lblPsp_8.Left = _lblPsp_2.Left
            _lblPsp_10.Left = _lblPsp_2.Left
        End If
        For i = 0 To 11
            If Not txtPsp(i).Visible Then txtPsp(i).Text = ""
        Next
        _lblPsp_7.BackColor = _lblPsp_11.BackColor
        _lblPsp_12.BackColor = _lblPsp_11.BackColor
        Select Case Membro.GenMem.MF
            Case "--"
                PrezzoCorpo(False)
                VediLordi(True)
                Membro.GenMem.LireLETot = 0
                Membro.GenMem.LireTot = Membro.GenMem.LireTot1 + Membro.GenMem.LireTot2
            Case "FL"
                PrezzoCorpo(False)
                VediLordi(True)
                Membro.GenMem.LireLETot = 0
                Membro.GenMem.LireTot = Membro.GenMem.LireTot1 + Membro.GenMem.LireTot2
                _lblPsp_7.BackColor = System.Drawing.Color.Lime
                _lblPsp_12.BackColor = System.Drawing.Color.Lime
            Case "PE" 'placcatura per esplosione
                PrezzoCorpo(True)
                VediLordi(True)
            Case "PC" 'placcatura per colaminazione
                PrezzoCorpo(True)
                VediLordi(True)
            Case "FD" 'completa a disegno
                VediLordi(False)
                PrezzoCorpo(True)
                Membro.GenMem.LireTot1 = 0
                Membro.GenMem.LireTot2 = 0
            Case "FC" 'completa a catalogo
                VediLordi(False)
                PrezzoCorpo(True)
            Case "FF" 'formatura fondi
                VediLordi(True)
                PrezzoCorpo(True)
            Case "CA" 'calandratura
                VediLordi(True)
                PrezzoCorpo(True)
            Case "LM" 'lavorazione meccanica
                VediLordi(True)
                PrezzoCorpo(True)
            Case "LE" 'a dis con mat in conto lavori
                VediLordi(True)
                PrezzoCorpo(True)
            Case "TP" 'piegatura forcine
                VediLordi(True)
                PrezzoCorpo(True)
        End Select
    End Sub
    Private Sub PrezzoCorpo(ByRef si As Boolean)
        If si Then
            Try
1:              LoadtxtPsp(15)
            Catch
                txtPsp(15).Visible = True
            Finally
                txtPsp(15).Text = Microsoft.VisualBasic.Strings.Format(Membro.GenMem.LireLETot, "##0.00")
            End Try
            txtPsp(15).Top = cmbLE.Top + cmbLE.Height 'txtPsp(11).Top
            txtPsp(15).Left = cmbLE.Left + cmbLE.Width - txtPsp(15).Width ' txtPsp(11).Left
            '   On Error Resume Next
            txtPsp(15).Visible = True
            txtPsp(15).Enabled = True
            _lblPsp_15.Visible = True
            If Membro.GenMem.MF = "FC" Or Membro.GenMem.MF = "FD" Then
                _lblPsp_9.Visible = False
                txtPsp(9).Visible = False 'Costo M.base
                txtPsp(10).Visible = False 'Costo Riv.1
                txtPsp(11).Visible = False 'Costo Riv.2
                _lblPsp_10.Visible = False
                cmdPrezzo.Visible = False
            End If
        Else
            Membro.GenMem.LireLETot = 0
            If txtPsp.Count = 16 Then
3:              txtPsp(15).Visible = False
4:              _lblPsp_15.Visible = False
            End If
            _lblPsp_9.Visible = True
            txtPsp(9).Visible = True
            txtPsp(10).Visible = Membro.GenMem.IndMat2 > 0
            txtPsp(11).Visible = Membro.GenMem.IndMat3 > 0
            _lblPsp_10.Visible = True
            cmdPrezzo.Visible = True
        End If
    End Sub
    Private Function CheckPos(ByRef NPos As Short) As Boolean
        Dim n As OggList.NodeP = Apparecchio.Elementi.nodeHead.Next
        Dim m As Membratura
        While Not n Is Nothing
            m = CType(n.TextData, Membratura)
            If Not n.TextData Is Membro Then
                If m.GenMem.PosDis = NPos Then
                    If Not (Membro.GenMem.Tipo = 26 Or m.GenMem.Tipo = 26) Then
                        CheckPos = False : Exit Function
                    End If
                End If
            End If
            n = n.Next
        End While
        CheckPos = True
    End Function
    Private Sub txtPsp_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Dim Index As Short = IndexedControls.IndexOf(txtPsp, CType(eventSender, TextBox))
        Dim f As Foratura
        Dim t As Piastrone
        Dim n As Integer
        Dim d As Diaframma
        Static Gia As Boolean
        If Gia Then
            Gia = False
            Exit Sub
        End If
        Select Case Index
            Case 15 'lire LE
                Select Case Membro.GenMem.Tipo
                    Case 12
                        t = CType(Membro, Piastrone)
                        f = Apparecchio.CercaForiPiastra(t)
                        If Not f Is Nothing Then
                            With frmForature.DefInstance
                                .Text1(0).Text = Str(f.GenMem.Qta)
                                .Text1(1).Text = GlobalRoutines.myStr((f.DiamFor), 3, 2, 0)
                                .Text1(2).Text = GlobalRoutines.myStr((f.Profon), 4, 0, 0)
                                .Text1(3).Text = GlobalRoutines.myStr(f.Profon * f.GenMem.Qta / 1000, 4, 0, 0)
                                .Text1(4).Text = "?"
                                .Text1(5).Text = GlobalRoutines.myStr((t.GenMem.LireLETot), 3, 1, 0)
                                .ShowDialog()
                                If .OK Then
                                    t.GenMem.LireLETot = GlobalRoutines.ValVir(.Text1(5).Text)
                                    txtPsp(15).Text = .Text1(5).Text
                                    n = InStr(t.GenMem.Note, " (metri")
                                    If n > 0 Then t.GenMem.Note = t.GenMem.Note.Substring(0, n - 1)
                                    t.GenMem.Note = t.GenMem.Note & " (metri forati " & .Text1(3).Text & ")"
                                    txtNot.Text = t.GenMem.Note
                                End If
                            End With
                            frmForature.DefInstance.Dispose()
                        End If
                    Case 19, -19
                        d = CType(Membro, Diaframma)
                        With frmForature.DefInstance
                            n = d.NumForiA * d.NumTipoA + d.NumForiB * d.NumTipoB
                            .Text1(0).Text = Str(n)
                            .Text1(1).Text = GlobalRoutines.myStr((d.Diamfori), 3, 2, 0)
                            .Text1(2).Text = GlobalRoutines.myStr((d.Spessore), 4, 0, 0)
                            .Text1(3).Text = GlobalRoutines.myStr(d.Spessore * n / 1000, 4, 0, 0)
                            .Text1(4).Text = "?"
                            .Text1(5).Text = GlobalRoutines.myStr((d.GenMem.LireLETot), 3, 1, 0)
                            .ShowDialog()
                            If .OK Then
                                d.GenMem.LireLETot = GlobalRoutines.ValVir(.Text1(5).Text)
                                txtPsp(15).Text = .Text1(5).Text
                                n = InStr(d.GenMem.Note, " (metri")
                                If n > 0 Then d.GenMem.Note = d.GenMem.Note.Substring(0, n - 1)
                                d.GenMem.Note = d.GenMem.Note & " (metri forati " & .Text1(3).Text & ")"
                                txtNot.Text = d.GenMem.Note
                            End If
                        End With
                        frmForature.DefInstance.Dispose()
                End Select
                Gia = True
        End Select
    End Sub

    Private Sub txtPsp_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs)
        Dim KeyCode As Integer = eventArgs.KeyCode
        'Dim Shift As Short = eventArgs.KeyData \ &H10000
        'Dim Index As Short = IndexedControls.IndexOf(txtPsp, eventSender)
        If KeyCode = System.Windows.Forms.Keys.Return Then KeyCode = System.Windows.Forms.Keys.Down
    End Sub
    Private Sub txtPsp_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs)
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        Dim Index As Short = IndexedControls.IndexOf(txtPsp, CType(eventSender, TextBox))
        If KeyAscii = System.Windows.Forms.Keys.Return Then KeyAscii = 0
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub
    Private Sub txtPsp_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs)
        Dim KeyCode As Short = CShort(eventArgs.KeyCode)
        '  Dim Shift As Short = eventArgs.KeyData \ &H10000
        Dim Index As Short = IndexedControls.IndexOf(txtPsp, CType(eventSender, TextBox))
        Call TrattaCar(Index, KeyCode, (txtPsp(Index)), TextArs, 14)
    End Sub

    Private Sub txtPsp_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs)
        'Dim Button As Short = eventArgs.Button \ &H100000
        'Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        AltroClick = True
    End Sub
    Private Sub txtQta_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtQta.TextChanged
        If Inizializzando Then Exit Sub
        Membro.GenMem.Qta = CShort(GlobalRoutines.ValVir(txtQta.Text))
    End Sub
    Private Sub Tipi(ByRef Tipo As Short) 'aggiorna
        Dim i As Short
        DBCmbTipo.Visible = False
        lblTipo.Text = "Tipo membratura"
        Select Case Tipo
            Case 1 : txtTipo.Text = "CILINDRO"
                txtTipo.Visible = True
                cmbTipo.Visible = False
            Case 2 : txtTipo.Text = "TRONCHETTO"
                txtTipo.Visible = True
                cmbTipo.Visible = False
            Case 3, 4, 5
                cmbTipo.Items.Clear()
                cmbTipo.Items.Add("FONDO ELLITTICO")
                cmbTipo.Items.Add("FONDO TOROSFERICO")
                cmbTipo.Items.Add("FONDO EMISFERICO")
                txtTipo.Visible = False
                cmbTipo.Visible = True
                cmbTipo.SelectedIndex = Tipo - 3
            Case 6, 7
                cmbTipo.Items.Clear()
                If CType(Membro, Cono).Fitting Then
                    cmbTipo.Items.Add("RIDUZ.ECCENTRICA")
                    cmbTipo.Items.Add("RIDUZ.CONCENTRICA")
                Else
                    cmbTipo.Items.Add("CONOIDE")
                    cmbTipo.Items.Add("CONO")
                End If
                txtTipo.Visible = False
                cmbTipo.Visible = True
                cmbTipo.SelectedIndex = Tipo - 6
            Case 8, 9
                cmbTipo.Items.Clear()
                cmbTipo.Items.Add("TUBI DIRITTI")
                cmbTipo.Items.Add("TUBI AD U")
                txtTipo.Visible = False
                cmbTipo.Visible = True
                cmbTipo.SelectedIndex = Tipo - 8
            Case 10
                cmbTipo.Items.Clear()
                cmbTipo.Items.Add("DA FORGIATO CON SCARPA")
                cmbTipo.Items.Add("DA FORGIATO AUTORINFORZATO")
                cmbTipo.Items.Add("STANDARD CON RINFORZO")
                cmbTipo.Items.Add("STANDARD SENZA RINFORZO")
                cmbTipo.Items.Add("FLANGIA SOLA")
                txtTipo.Visible = False
                cmbTipo.Visible = True
                cmbTipo.SelectedIndex = Membro.TipoF - 1
            Case 14
                cmbTipo.Items.Clear()
                cmbTipo.Items.Add("CON SCARPA")
                cmbTipo.Items.Add("AUTORINFORZATO")
                cmbTipo.Items.Add("con pezza di rinforzo")
                cmbTipo.Items.Add("STANDARD SENZA RINFORZO")
                txtTipo.Visible = False
                cmbTipo.Visible = True
                cmbTipo.SelectedIndex = Membro.TipoF - 1
            Case 11
                cmbTipo.Items.Clear()
                cmbTipo.Items.Add("Gradino maschio")
                cmbTipo.Items.Add("Gradino femmina")
                cmbTipo.Items.Add("Flangione rovescio")
                cmbTipo.Items.Add("Flangione bicodolo")
                txtTipo.Visible = False
                cmbTipo.Visible = True
                cmbTipo.SelectedIndex = Membro.SottoTipo - 1
            Case 12
                cmbTipo.Items.Clear()
                cmbTipo.Items.Add("2 codoli esterni")
                cmbTipo.Items.Add("1 int. / 1 est.")
                cmbTipo.Items.Add("saldata LM + bulloni")
                cmbTipo.Items.Add("senza cod., gr.Sx/Dx")
                cmbTipo.Items.Add("s.cod. e 1/2 gr.a Sx")
                cmbTipo.Items.Add("sandwitch+collar blt")
                cmbTipo.Items.Add("saldata LC + bulloni")
                txtTipo.Visible = False
                cmbTipo.Visible = True
                cmbTipo.SelectedIndex = Membro.SottoTipo - 1
            Case 13 : txtTipo.Text = "TIRANTI"
                txtTipo.Visible = False
                cmbTipo.Visible = True
                cmbTipo.Items.Clear()
                cmbTipo.Items.Add("PRIGIONIERO")
                cmbTipo.Items.Add("TIRANTE")
            Case 16
                cmbTipo.Items.Clear()
                cmbTipo.Items.Add("Calotta")
                cmbTipo.Items.Add("Disco")
                cmbTipo.Items.Add("Fondo piano raccordato")
                txtTipo.Visible = False
                cmbTipo.Visible = True
                If Membro.SottoTipo = 0 Or Membro.SottoTipo > 3 Then Membro.SottoTipo = 1
                cmbTipo.SelectedIndex = Membro.SottoTipo - 1
            Case 17
                cmbTipo.Items.Clear()
                cmbTipo.Items.Add("Anello cilindrato")
                cmbTipo.Items.Add("Anello a spicchi")
                cmbTipo.Items.Add("Anello da quadrotto")
                cmbTipo.Items.Add("Anello da quadrotto con rec.")
                cmbTipo.Items.Add("Anello per rinforzo bocchello")
                txtTipo.Visible = False
                cmbTipo.Visible = True
                cmbTipo.SelectedIndex = Membro.TipoS - 1
            Case 18
                cmbTipo.Items.Clear()
                cmbTipo.Items.Add("Flued   (TEMA), constant thk.")
                cmbTipo.Items.Add("Flanged (TEMA), constant thk.")
                cmbTipo.Items.Add("EJMA, not-reinforced")
                cmbTipo.Items.Add("EJMA, with integral rings")
                cmbTipo.Items.Add("EJMA, with bolted rings")
                cmbTipo.Items.Add("Flued (TEMA), non uniform thks.")
                If IUNL < 5 Then cmbTipo.Items.Add("Rigidezza fornita manualmente")
                txtTipo.Visible = False
                cmbTipo.Visible = True
                cmbTipo.SelectedIndex = Membro.SottoTipo - 1
            Case 19 : txtTipo.Text = "SET DI DIAFRAMMI"
                txtTipo.Visible = True
                cmbTipo.Visible = False
            Case 21
                cmbTipo.Items.Clear()
                cmbTipo.Items.Add("CURVA A GUSCI")
                cmbTipo.Items.Add("CURVA A SPICCHI")
                txtTipo.Visible = False
                cmbTipo.Visible = True
                cmbTipo.SelectedIndex = Membro.TipoS
            Case 25 : lblTipo.Text = "Standard"
                cmbTipo.Visible = False
                txtTipo.Visible = False
                DBCmbTipo.Visible = False
                DBCmbTipo.Top = cmbTipo.Top
                Dim cString As String = Conn & Inizio.Archdir & "\Selle.mdb" & ConnFine
                Dim cnConn As OleDbConnection = New OleDbConnection(cString)
                Dim cmd As OleDbDataAdapter = New OleDbDataAdapter("SELECT * FROM Catalogo", cnConn)
                myData = New DataSet("Tipi")
                cmd.Fill(myData)
                DBCmbTipo.DataSource = myData
                Combo1.Top = cmbTipo.Top
                Combo1.Visible = True
                Combo1.Items.Clear()
                Combo1.Items.Add("Tutti")
                For i = 0 To CShort(myData.Tables(0).Rows.Count - 1)
                    '         Do While Not myData.Recordset.EOF
                    Combo1.Items.Add(myData.Tables(0).Rows(i)("Standard"))
                    '       Data1.Recordset.MoveNext()
                    '      Loop
                Next
                Combo1.SelectedIndex = 0
                txtTipo.Text = "SELLA"
                '5-5-99
            Case 26 : txtTipo.Text = "FASCIO TUBIERO"
                txtTipo.Visible = True
                cmbTipo.Visible = False
            Case 28 : txtTipo.Text = "GUARNIZIONE"
                txtTipo.Visible = True
                cmbTipo.Visible = False
            Case 31 : txtTipo.Text = "SET di SEALING STRIPS"
                txtTipo.Visible = True
                cmbTipo.Visible = False
            Case 32 : txtTipo.Text = "SET di TIRANTI FASCIO"
                txtTipo.Visible = True
                cmbTipo.Visible = False
            Case 33 : txtTipo.Text = "SET di TONDI di SCORR."
                txtTipo.Visible = True
                cmbTipo.Visible = False
            Case 34 : txtTipo.Text = "TEGOLA"
                txtTipo.Visible = True
                cmbTipo.Visible = False
            Case 37 : txtTipo.Text = "Setti per fascio a U"
                txtTipo.Visible = True
                If CType(Membro, Raggrupp).TestaCoda = 1 Then
                    cmbTipo.Items.Clear()
                    cmbTipo.Items.Add("Setti di testa")
                    cmbTipo.Items.Add("Setti di coda")
                    cmbTipo.Visible = True
                    cmbTipo.SelectedIndex = CType(Membro, Raggrupp).Numero - 1
                Else
                    cmbTipo.Visible = False
                End If
        End Select
    End Sub
    Private Sub Testi(ByRef Tipo As Short, ByRef Nf As Short) 'aggiorna
        Dim i, ifl As Short
        Dim Riga(11) As String
        Dim Dummy As String
        Dim O As Membratura
        Dim Tubi As New Tubi
        Dim TipoFascio As Short
        Dim Table As New DataTable
        Dim j As Short
        Dim tableCat As New DataTable
        Dim lMembro As New Fondo
        Try
            'InTesti = True
            Select Case Tipo
                Case 3, 4, 5
                    lMembro = CType(Membro, Fondo)
                    option1.Visible = True
                    option1.Text = "con foro centrale"
                    txtPara(0).Text = LTrim(Str(lMembro.Diametro))
                    lblPara(0).Text = "Diametro interno"
4001:               lblPara.Load(1)
                    lblPara(1).Text = "Spessore"
4002:               txtPara.Load(1)
                    txtPara(1).Text = LTrim(Str(lMembro.SpessBase))
4003:               lblPara.Load(2)
4004:               txtPara.Load(2)
                    Select Case Tipo
                        Case 3, 4 : lblPara(2).Text = "Altezza piedritto"
                            txtPara(2).Text = LTrim(Str(lMembro.Piedritto))
                        Case 5 : lblPara(2).Text = "H piedritto negativo"
                            txtPara(2).Text = LTrim(Str(lMembro.Piedritto))
                    End Select
                    Nf = 2
                    If lMembro.TipoMat > 1 Then
                        lblPara(0).Text = lblPara(0).Text & " (nudo)"
                        lblPara(1).Text = lblPara(1).Text & " base"
                        Nf = 3
                        lblPara.Load(Nf)
                        lblPara(Nf).Text = "Spessore rivestimento"
                        txtPara.Load(Nf)
                        txtPara(Nf).Text = LTrim(Str(lMembro.SpessRive))
                    End If
                    If Tipo = 3 Then
                        Nf = CShort(Nf + 1)
                        lblPara.Load(Nf)
                        lblPara(Nf).Text = "Rapporto raggio/diametro"
                        txtPara.Load(Nf)
                        If lMembro.kRapporto = 0 Then lMembro.kRapporto = 0.85
                        txtPara(Nf).Text = LTrim(GlobalRoutines.myStr(lMembro.kRapporto, 1, 3, 0))
                    End If
                    If lMembro.ForoCentrale Then
                        Nf = CShort(Nf + 1)
                        lblPara.Load(Nf)
                        lblPara(Nf).Text = "Diametro foro centrale"
                        txtPara.Load(Nf)
                        txtPara(Nf).Text = LTrim(GlobalRoutines.myStr(lMembro.Dcal, 4, 2, 0))
                    Else
                        If Nf + 1 < txtPara.Count - 1 Then
                            lblPara(Nf + 1).Visible = False
                            txtPara(Nf + 1).Visible = False
                        End If
                    End If
                Case 1, 2, 34
                    Dim lMembroC As Cilindro = CType(Membro, Cilindro)
                    If Tipo = 2 Then
                        lblPara(0).Text = "Diametro esterno"
                    Else
                        lblPara(0).Text = "Diametro interno"
                    End If
                    txtPara(0).Text = LTrim(Str(lMembroC.Diametro))
                    lblPara.Load(1)
                    lblPara(1).Text = "Spessore"
                    txtPara.Load(1)
                    txtPara(1).Text = LTrim(Str(lMembroC.SpessBase))
                    lblPara.Load(2)
                    txtPara.Load(2)
                    Select Case Tipo
                        Case 1, 2 : lblPara(2).Text = "Lunghezza"
                            txtPara(2).Text = LTrim(Str(lMembroC.Lunghezza))
                    End Select
                    Nf = 2
                    If lMembroC.TipoMat > 1 Then
                        lblPara(0).Text = lblPara(0).Text & " (nudo)"
                        lblPara(1).Text = lblPara(1).Text & " base"
                        Nf = 3
5:                      lblPara.Load(Nf)
                        lblPara(Nf).Text = "Spessore rivestimento"
6:                      txtPara.Load(Nf)
                        txtPara(Nf).Text = LTrim(Str(lMembroC.SpessRive))
                    End If
                    If Tipo = 34 Then
                        Nf = CShort(Nf + 1)
7:                      lblPara.Load(Nf)
                        lblPara(Nf).Text = "Apertura al centro [°]"
8:                      txtPara.Load(Nf)
                        txtPara(Nf).Text = LTrim(Str(lMembroC.AngTegola))
                    End If
                    If System.Math.Abs(Tipo) = 2 Or System.Math.Abs(Tipo) = 1 Then
                        If RandaPossibile(CType(lMembro, Fondo)) Then
                            Nf = CShort(Nf + 1)
219:                        lblPara.Load(Nf)
                            lblPara(Nf).Text = "Raggio randa"
2110:                       txtPara.Load(Nf)
                            txtPara(Nf).Text = LTrim(Str(lMembroC.Randa))
                        Else
                            lMembroC.Randa = 0
                        End If
                    End If
                Case 8, 9, 26
                    Select Case Tipo
                        Case 8, 9 : Tubi = CType(Membro, Tubi)
                        Case 26
                            If CType(Membro, Fascio).Tubi_Renamed Is Nothing Then
                                CType(Membro, Fascio).Tubi_Renamed = New Tubi
                                CType(Membro, Fascio).Tubi_Renamed.GenMem.Tipo = -8
                                cmbTipo.Enabled = False
                                Tipi(8)
                                cmbTipo.Enabled = True
                            End If
                            Tubi = CType(Membro, Fascio).Tubi_Renamed
                            TipoFascio = CType(Membro, Fascio).TipoFascio
                            _lblMat_0.Visible = False
                            _txtMat_0.Visible = False
                            _cmdMat_0.Visible = False
                    End Select
                    lblPara(0).Text = "Diametro esterno tubo"
                    txtPara(0).Text = LTrim(Str(Tubi.DiamExt))
11:                 lblPara.Load(1)
                    lblPara(1).Text = "Spessore tubo"
12:                 txtPara.Load(1)
                    txtPara(1).Text = LTrim(Str(Tubi.Spessore))
13:                 lblPara.Load(2)
                    lblPara(2).Text = "Tolleranza"
14:                 cmbPara.Load(2)
                    cmbPara(2).Items.Add("MW")
                    cmbPara(2).Items.Add("AW")
                    If Tubi.Tolleranza <= 0 Then Tubi.Tolleranza = 1
                    If Tubi.Tolleranza > 2 Then Tubi.Tolleranza = 1
                    cmbPara(2).SelectedIndex = Tubi.Tolleranza - 1
15:                 lblPara.Load(3)
                    lblPara(3).Text = "Lunghezza"
                    If Tipo = 9 Or (Tipo = 26 And TipoFascio > 2) Then
                        lblPara(3).Text = "Lungh.dir.netta"
                    End If
16:                 txtPara.Load(3)
                    txtPara(3).Text = LTrim(Str(Tubi.Lunghezza))
17:                 lblPara.Load(4)
                    lblPara(4).Text = "Tipo di fascio"
18:                 cmbPara.Load(4)
                    cmbPara(4).Items.Clear()
                    cmbPara(4).Items.Add("Teste fisse")
                    cmbPara(4).Items.Add("Testa flottante")
                    cmbPara(4).Items.Add("Tubi a U")
                    cmbPara(4).Items.Add("Tubi a fontana")
                    If Tipo = 26 Then
                        If CType(Membro, Fascio).TipoFascio = 0 Then CType(Membro, Fascio).TipoFascio = 1
                        cmbPara(4).SelectedIndex = CType(Membro, Fascio).TipoFascio - 1
                    Else
                        cmbPara(4).Tag = "nv"
                    End If
19:                 lblPara.Load(5)
                    lblPara(5).Text = "OTL"
21:                 txtPara.Load(5)
                    txtPara(5).Text = LTrim(Str(Tubi.OTL))
22:                 lblPara.Load(6)
                    lblPara(6).Text = "Numero tubi"
                    If Tipo = 9 Or (Tipo = 26 And TipoFascio > 2) Then
                        lblPara(6).Text = "Numero forcelle"
                    End If
23:                 txtPara.Load(6)
                    txtPara(6).Text = LTrim(Str(Tubi.NumeroTubi))
                    Nf = 6
                    'cmbTipo.ListIndex = Abs(ctype(Membro.Genmem,clsGenmem).Tipo) - 8
                    If Tipo = 26 Then
231:                    lblPara.Load(7)
                        lblPara(7).Text = "Tracciatura"
232:                    txtPara.Load(7)
                        If IO.File.Exists(CType(Membro, Fascio).FileTrac) Then
                            txtPara(7).Text = CType(Membro, Fascio).FileTrac
                        Else
                            txtPara(7).Text = "Assente"
                        End If
                        If txtPara(7).Left = txtPara(0).Left Then
                            txtPara(7).Left = CInt(txtPara(7).Left - 1.5 * txtPara(7).Width)
                            txtPara(7).Width = CInt(2.5 * txtPara(7).Width)
                        End If
                        txtPara(7).Tag = "ne"
                        txtPara(7).BringToFront()
                        Nf = 7
                    End If
                Case 6, 7
                    Dim lMembroC As Cono = CType(Membro, Grafica.Cono)
                    lblPara(0).Text = "Diametro maggiore"
                    txtPara(0).Text = LTrim(Str(lMembroC.Dgran))
24:                 lblPara.Load(1)
                    lblPara(1).Text = "Raggio raccordo"
25:                 txtPara.Load(1)
                    txtPara(1).Text = LTrim(Str(lMembroC.RagG))
26:                 lblPara.Load(2)
                    lblPara(2).Text = "Altezza piedritto"
27:                 txtPara.Load(2)
                    txtPara(2).Text = LTrim(Str(lMembroC.PiedG))
28:                 lblPara.Load(3)
                    lblPara(3).Text = "Diametro minore"
29:                 txtPara.Load(3)
                    txtPara(3).Text = LTrim(Str(lMembroC.Dpicc))
30:                 lblPara.Load(4)
                    lblPara(4).Text = "Raggio raccordo"
31:                 txtPara.Load(4)
                    txtPara(4).Text = LTrim(Str(lMembroC.RagP))
32:                 lblPara.Load(5)
                    lblPara(5).Text = "Altezza piedritto"
33:                 txtPara.Load(5)
                    txtPara(5).Text = LTrim(Str(lMembroC.PiedP))
34:                 lblPara.Load(6)
                    lblPara(6).Text = "Spessore base"
35:                 txtPara.Load(6)
                    txtPara(6).Text = GlobalRoutines.myStr(lMembroC.SpessBase, 4, 1, 0)
                    Nf = 6
                    If Not lMembroC.Fitting Then
                        Nf = 7
36:                     lblPara.Load(7)
37:                     txtPara.Load(7)
                        txtPara(7).Text = GlobalRoutines.myStr(lMembroC.AlfaCon, 3, 2, 0)
                        If Tipo = 6 Then
                            lblPara(7).Text = "Apertura  [°]"
                        Else
                            lblPara(7).Text = "Semiapertura  [°]"
                            Nf = CShort(Nf + 1)
38:                         lblPara.Load(Nf)
                            lblPara(Nf).Text = "Altezza totale"
39:                         txtPara.Load(Nf)
                            txtPara(Nf).Text = GlobalRoutines.myStr(lMembroC.Altezza, 5, 0, 0)
                        End If
                    End If
                    If lMembroC.Fitting Then
                        Nf = CShort(Nf + 1)
2238:                   lblPara.Load(Nf)
                        lblPara(Nf).Text = "Altezza totale"
2239:                   txtPara.Load(Nf)
                        txtPara(Nf).Text = GlobalRoutines.myStr(lMembroC.Altezza, 5, 0, 0)
                        lblPara(1).Tag = "nv"
                        txtPara(1).Tag = "nv"
                        lblPara(2).Tag = "nv"
                        txtPara(2).Tag = "nv"
                        lblPara(4).Tag = "nv"
                        txtPara(4).Tag = "nv"
                        lblPara(5).Tag = "nv"
                        txtPara(5).Tag = "nv"
                    End If
                    If lMembroC.TipoMat > 1 Then
                        Nf = CShort(Nf + 1)
40:                     lblPara.Load(Nf)
                        lblPara(Nf).Text = "Spessore rivestimento"
41:                     txtPara.Load(Nf)
                        txtPara(Nf).Text = LTrim(Str(lMembroC.SpessRive))
                    End If
                Case 10
                    Dim lMembroC As clsBocch = CType(Membro, clsBocch)
42:                 lblPara.Load(1)
                    lblPara(1).Text = "Diametro interno"
43:                 txtPara.Load(1)
                    txtPara(1).Text = LTrim(Str(lMembroC.DiamInt))
                    lblPara(0).Visible = False
                    txtPara(0).Visible = False
                    If CType(lMembroc.GenMem, clsGenMem).Tipo < 0 Then
                        option1.Visible = False
                        option3.Visible = False
                    Else
                        option1.Visible = True
                        option3.Visible = lMembroC.Accoppiata
                        option1.CheckState = CType(lMembroC.Accoppiata, CheckState)
                        option3.CheckState = CType(lMembroC.Cieca, CheckState)
                    End If
44:                 lblPara.Load(2)
                    lblPara(2).Text = "Sporgenza"
45:                 txtPara.Load(2)
                    txtPara(2).Text = LTrim(Str(lMembroC.Sporgenza))
46:                 lblPara.Load(3)
                    lblPara(3).Text = "Raggio randa"
47:                 txtPara.Load(3)
                    txtPara(3).Text = LTrim(Str(lMembroC.Randa))
                    Nf = 3
                    Select Case lMembroC.TipoF
                        Case 1
                            Nf = 5
48:                         lblPara.Load(4)
                            lblPara(4).Text = "Diametro scarpa"
49:                         txtPara.Load(4)
                            txtPara(4).Text = LTrim(Str(lMembroC.DiamScarpa))
50:                         lblPara.Load(5)
                            lblPara(5).Text = "Spessore scarpa"
51:                         txtPara.Load(5)
                            txtPara(5).Text = LTrim(Str(lMembroC.SpesScarpa))
                        Case 2
                            Nf = 5
52:                         lblPara.Load(4)
                            lblPara(4).Text = "Diametro rinforzo"
53:                         txtPara.Load(4)
                            txtPara(4).Text = LTrim(Str(lMembroC.DiamRinf))
54:                         lblPara.Load(5)
                            lblPara(5).Text = "Altezza rinforzo"
55:                         txtPara.Load(5)
                            txtPara(5).Text = LTrim(Str(lMembroC.AltzRinf))
                        Case 3
                            Nf = 5
56:                         lblPara.Load(4)
                            lblPara(4).Text = "Diametro rinforzo"
57:                         txtPara.Load(4)
                            If lMembroC.Pad Is Nothing Then lMembroC.CercaPadAppeso()
                            txtPara(4).Text = LTrim(Str(lMembroC.Pad.DiamExt))
58:                         lblPara.Load(5)
                            lblPara(5).Text = "Spessore rinforzo"
59:                         txtPara.Load(5)
                            If lMembroC.Pad Is Nothing Then lMembroC.CercaPadAppeso()
                            txtPara(5).Text = LTrim(Str(lMembroC.Pad.Spess))
                        Case 4
                        Case 5
                            lblPara(1).Tag = "nv"
                            lblPara(2).Tag = "nv"
                            lblPara(3).Tag = "nv"
                            txtPara(1).Tag = "nv"
                            txtPara(2).Tag = "nv"
                            txtPara(3).Tag = "nv"
                    End Select
                Case 11
                    Dim lMembroC As Flangione = CType(Membro, Flangione)
                    lblPara(0).Text = "Diametro esterno"
                    txtPara(0).Text = LTrim(Str(lMembroC.DiamExt))
60:                 lblPara.Load(1)
                    lblPara(1).Text = "Diametro interno"
61:                 txtPara.Load(1)
                    txtPara(1).Text = LTrim(Str(lMembroC.DiamInt))
62:                 lblPara.Load(2)
                    lblPara(2).Text = "Spessore flangione"
63:                 txtPara.Load(2)
                    txtPara(2).Text = LTrim(Str(lMembroC.SpessBase))
64:                 lblPara.Load(3)
                    lblPara(3).Text = "Diametro gradino"
65:                 txtPara.Load(3)
                    txtPara(3).Text = LTrim(Str(lMembroC.DiamGra))
66:                 lblPara.Load(4)
                    lblPara(4).Text = "Spessore gradino"
67:                 txtPara.Load(4)
                    txtPara(4).Text = LTrim(Str(lMembroC.SpessGra))
68:                 lblPara.Load(5)
                    lblPara(5).Text = "Spessore minimo codolo"
69:                 txtPara.Load(5)
                    txtPara(5).Text = LTrim(Str(lMembroC.g0))
70:                 lblPara.Load(6)
                    lblPara(6).Text = "Spessore massimo codolo"
71:                 txtPara.Load(6)
                    txtPara(6).Text = LTrim(Str(lMembroC.g1))
72:                 lblPara.Load(7)
                    lblPara(7).Text = "Altezza codolo"
73:                 txtPara.Load(7)
                    txtPara(7).Text = LTrim(Str(lMembroC.H))
                    Nf = 7
                    If lMembroC.SottoTipo = 4 Then
                        Nf = 12
                        For i = 3 To 7 : lblPara(i).Text = lblPara(i).Text & " l.1" : Next
74:                     lblPara.Load(8)
                        lblPara(8).Text = "Diametro gradino l.2"
75:                     txtPara.Load(8)
                        txtPara(8).Text = LTrim(Str(lMembroC.DiamGra2))
76:                     lblPara.Load(9)
                        lblPara(9).Text = "Spessore gradino l.2"
77:                     txtPara.Load(9)
                        txtPara(9).Text = LTrim(Str(lMembroC.SpessGra2))
78:                     lblPara.Load(10)
                        lblPara(10).Text = "Spessore minimo codolo l.2"
79:                     txtPara.Load(10)
                        txtPara(10).Text = LTrim(Str(lMembroC.g02))
80:                     lblPara.Load(11)
                        lblPara(11).Text = "Spessore massimo codolo l.2"
81:                     txtPara.Load(11)
                        txtPara(11).Text = LTrim(Str(lMembroC.g12))
82:                     lblPara.Load(12)
                        lblPara(12).Text = "Altezza codolo l.2"
83:                     txtPara.Load(12)
                        txtPara(12).Text = LTrim(Str(lMembroC.H2))
                    End If
                    If lMembro.TipoMat > 1 Then
                        Nf = CShort(Nf + 1)
84:                     lblPara.Load(Nf)
                        lblPara(Nf).Text = "Spessore rivestimento"
85:                     txtPara.Load(Nf)
                        txtPara(Nf).Text = LTrim(Str(lMembroC.SpessRive))
                    End If
                Case 12
                    Dim lMembroC As Piastrone = CType(Membro, Piastrone)
                    lblPara(0).Text = "Diametro esterno"
                    txtPara(0).Text = LTrim(Str(lMembroC.DiamExt))
86:                 lblPara.Load(1)
                    lblPara(1).Text = "Spessore Base"
87:                 txtPara.Load(1)
                    txtPara(1).Text = LTrim(Str(lMembroC.SpessBase))
                    ifl = CShort(FreeFile())
                    FileOpen(ifl, RTrim(Inizio.Archdir) & "\PIAS12.DAT", OpenMode.Input, , OpenShare.Shared)
                    Select Case lMembroC.SottoTipo
                        Case 1
                            For i = 4 To 7 : Riga(i) = LineInput(ifl) : Next
                            Nf = 5
                            'Stringa1$(4) = "Altezza cod.tube-side" 'H1
                            'Stringa1$(5) = "Spessore per detto   " 'B1
                            'Stringa1$(6) = "Altezza cod.shel-side" 'H2
                            'Stringa1$(7) = "Spessore per detto  "  'B2
                        Case 2
                            For i = 4 To 7 : Dummy = LineInput(ifl) : Next
                            For i = 4 To 9 : Riga(i) = LineInput(ifl) : Next
                            Nf = 7
                            'Stringa1$(4) = "Altezza cod.tube-side" 'H1
                            'Stringa1$(5) = "Spessore per detto   " 'B1
                            'Stringa1$(6) = "Altezza cod.shel-side" 'H2
                            'Stringa1$(7) = "Spessore per detto  "  'B2
                            'Stringa1$(8) = "Diam.int.del detto  "  'B3
                            'Stringa1$(9) = "Sp. estens.  piastra"  'H3
                        Case 3
                            For i = 4 To 7 : Dummy = LineInput(ifl) : Next
                            For i = 4 To 9 : Dummy = LineInput(ifl) : Next
                            For i = 4 To 11 : Riga(i) = LineInput(ifl) : Next
                            Nf = 9
                            'Stringa1$(4) = "Diam.gr.int.tube-side" 'B1
                            'Stringa1$(5) = "Profondit… per detto"  'H1
                            'Stringa1$(6) = "Altezza cod.shel-side" 'H2
                            'Stringa1$(7) = "Spessore per detto  "  'B2
                            'Stringa1$(8) = "Diam.int.del detto  "  'B3
                            'Stringa1$(9) = "Spess. est.  piastra"  'H3
                            'Stringa1$(10) = "Diam.gr.est.tube-side" 'B4
                            'Stringa1$(11) = "Profondit… per detto"  'H4
                        Case 4, 6
                            For i = 4 To 7 : Dummy = LineInput(ifl) : Next
                            For i = 4 To 9 : Dummy = LineInput(ifl) : Next
                            For i = 4 To 11 : Dummy = LineInput(ifl) : Next
                            For i = 4 To 7 : Riga(i) = LineInput(ifl) : Next
                            Nf = 5
                            'Stringa1$(4) = "Diam.int.gradino 1" 'H1
                            'Stringa1$(5) = "Profondita' detto " 'B1
                            'Stringa1$(6) = "Diam.int.gradino 2" 'H2
                            'Stringa1$(7) = "Profondita' detto"  'B2
                        Case 5
                            For i = 4 To 7 : Dummy = LineInput(ifl) : Next
                            For i = 4 To 9 : Dummy = LineInput(ifl) : Next
                            For i = 4 To 11 : Dummy = LineInput(ifl) : Next
                            For i = 4 To 7 : Dummy = LineInput(ifl) : Next
                            For i = 4 To 7 : Riga(i) = LineInput(ifl) : Next
                            Nf = 5
                        Case 7
                            For i = 4 To 7 : Dummy = LineInput(ifl) : Next
                            For i = 4 To 9 : Dummy = LineInput(ifl) : Next
                            For i = 4 To 11 : Dummy = LineInput(ifl) : Next
                            For i = 4 To 7 : Dummy = LineInput(ifl) : Next
                            For i = 4 To 7 : Dummy = LineInput(ifl) : Next
                            For i = 4 To 11 : Riga(i) = LineInput(ifl) : Next
                            Nf = 9
                    End Select
                    FileClose(ifl)
                    For i = 2 To Nf
88:                     lblPara.Load(i)
                        lblPara(i).Text = Riga(i + 2)
89:                     txtPara.Load(i)
                    Next
                    With lMembroC
                        Select Case .SottoTipo
                            Case 1
                                txtPara(2).Text = LTrim(GlobalRoutines.myStr(.H1, 8, 0, 0))
                                '       txtPara(3).Text = myStr((.DiamExt - .B1) / 2, 8, 0, 0)
                                txtPara(3).Text = LTrim(GlobalRoutines.myStr(.B1, 8, 0, 0))
                                txtPara(4).Text = LTrim(GlobalRoutines.myStr(.H2, 8, 0, 0))
                                '       txtPara(5).Text = myStr((.DiamExt - .B2) / 2, 8, 0, 0)
                                txtPara(5).Text = LTrim(GlobalRoutines.myStr(.B2, 8, 0, 0))
                            Case 2
                                txtPara(2).Text = LTrim(GlobalRoutines.myStr(.H1, 8, 0, 0))
                                '       txtPara(3).Text = myStr((.DiamExt - .B1) / 2, 8, 0, 0)
                                txtPara(3).Text = LTrim(GlobalRoutines.myStr(.B1, 8, 0, 0))
                                txtPara(4).Text = LTrim(GlobalRoutines.myStr(.H2, 8, 0, 0))
                                '       txtPara(5).Text = myStr((.B3 - .B2) / 2, 8, 0, 0)
                                '       txtPara(6).Text = myStr(.B2, 8, 0, 0)
                                txtPara(5).Text = LTrim(GlobalRoutines.myStr(.B2, 8, 0, 0))
                                txtPara(6).Text = LTrim(GlobalRoutines.myStr(.B3, 8, 0, 0))
                                '          txtPara(7).Text = myStr(.SpessBase - .H3 + .H2, 8, 0, 0)
                                txtPara(7).Text = LTrim(GlobalRoutines.myStr(.H3, 8, 0, 0))
                            Case 3, 7
                                txtPara(2).Text = LTrim(GlobalRoutines.myStr(.B1, 8, 0, 0))
                                txtPara(3).Text = LTrim(GlobalRoutines.myStr(.H1, 8, 0, 0))
                                txtPara(4).Text = LTrim(GlobalRoutines.myStr(.H2, 8, 0, 0))
                                '          txtPara(5).Text = myStr((.B3 - .B2) / 2, 8, 0, 0)
                                txtPara(5).Text = LTrim(GlobalRoutines.myStr(.B2, 8, 0, 0))
                                '          txtPara(6).Text = myStr(.B2, 8, 0, 0)
                                txtPara(6).Text = LTrim(GlobalRoutines.myStr(.B3, 8, 0, 0))
                                '          txtPara(7).Text = myStr(.SpessBase - .H3 - .H1, 8, 0, 0)
                                txtPara(7).Text = LTrim(GlobalRoutines.myStr(.H3, 8, 0, 0))
                                txtPara(8).Text = LTrim(GlobalRoutines.myStr(.B4, 8, 0, 0))
                                txtPara(9).Text = LTrim(GlobalRoutines.myStr(.H4, 8, 0, 0))
                            Case 4, 5, 6
                                txtPara(2).Text = LTrim(GlobalRoutines.myStr(.B1, 8, 0, 0))
                                txtPara(3).Text = LTrim(GlobalRoutines.myStr(.H1, 8, 0, 0))
                                txtPara(4).Text = LTrim(GlobalRoutines.myStr(.B2, 8, 0, 0))
                                txtPara(5).Text = LTrim(GlobalRoutines.myStr(.H2, 8, 0, 0))
                        End Select
                    End With
                    Nf = CShort(Nf + 1)
90:                 lblPara.Load(Nf)
                    lblPara(Nf).Text = "Larghezza cava"
91:                 txtPara.Load(Nf)
                    txtPara(Nf).Text = LTrim(Str(lMembroC.LargCava))
                    Nf = CShort(Nf + 1)
92:                 lblPara.Load(Nf)
                    lblPara(Nf).Text = "Profondità cava"
93:                 txtPara.Load(Nf)
                    txtPara(Nf).Text = LTrim(Str(lMembroC.ProfCava))
                    If lMembro.TipoMat > 1 Then
                        Nf = CShort(Nf + 1)
94:                     lblPara.Load(Nf)
                        lblPara(Nf).Text = "Spessore rivestimento"
95:                     txtPara.Load(Nf)
                        txtPara(Nf).Text = LTrim(Str(lMembro.SpessRive))
                    End If
                    Nf = CShort(Nf + 1)
96:                 lblPara.Load(Nf)
                    lblPara(Nf).Text = "Diametro lordo"
97:                 txtPara.Load(Nf)
                    txtPara(Nf).Text = LTrim(Str(lMembroC.AG))
                    Nf = CShort(Nf + 1)
98:                 lblPara.Load(Nf)
                    lblPara(Nf).Text = "Spessore lordo"
99:                 txtPara.Load(Nf)
                    txtPara(Nf).Text = LTrim(Str(lMembroC.TG))
                Case 13
                    Dim lMembroC As clsTirante = CType(Membro, clsTirante)
                    lblPara(0).Text = "Diametro nominale"
                    txtPara(0).Text = lMembroC.Standardtir.DN
100:                lblPara.Load(1)
                    lblPara(1).Text = "Filettatura"
101:                txtPara.Load(1)
                    AggMetrica()
102:                lblPara.Load(2)
                    lblPara(2).Text = "Lunghezza"
103:                txtPara.Load(2)
                    txtPara(2).Text = LTrim(Str(lMembroC.Lunghezza))
104:                lblPara.Load(3)
                    lblPara(3).Text = "Diametro scarico"
105:                txtPara.Load(3)
                    txtPara(3).Text = LTrim(Str(lMembroC.DiamScar))
106:                lblPara.Load(4)
                    lblPara(4).Text = "Lunghezza scaricata"
107:                txtPara.Load(4)
                    txtPara(4).Text = LTrim(Str(lMembroC.LunScar))
108:                lblPara.Load(5)
                    lblPara(5).Text = "Numero dadi"
109:                txtPara.Load(5)
                    txtPara(5).Text = LTrim(Str(lMembroC.nDadi))
110:                lblPara.Load(6)
                    lblPara(6).Text = "Diametro d'istallazione"
111:                txtPara.Load(6)
                    txtPara(6).Text = LTrim(Str(lMembroC.Dinst))
                    Nf = 6
                    cmbTipo.SelectedIndex = -CShort(lMembroC.Tipo = "T")
                Case 14, 16
                    If Tipo = 14 Then
                        lblPara(0).Visible = False
                        txtPara(0).Visible = False
                        ' option1.Top = lblPara(0).Top
                        option1.Visible = False ' Tipo = 14
                    End If
                    For i = 1 To 24
112:                    txtPara.Load(i)
113:                    lblPara.Load(i)
                    Next
                    Select Case Tipo
                        Case 14 : CType(Membro, clsNonStd).PrSeFinDil(Nf)
                        Case 16 : CType(Membro, CalDisc).PrSeFinDil(Nf)
                    End Select
                Case 15, -15, 23, -23
                    lblTipo.Visible = False
                    cmbTipo.Visible = False
                    lblPara(0).Text = "Lunghezza"
                    txtPara(0).Text = LTrim(Str(Membro.Lunghezza))
                    i = CShort(i + 1)
                    If System.Math.Abs(Tipo) = 15 Then
                        lblPara.Load(i)
                        lblPara(i).Text = "Larghezza"
                        txtPara.Load(i)
                        txtPara(i).Text = LTrim(Str(Membro.Larghezza))
                        i = CShort(i + 1)
                    End If
                    lblPara.Load(i)
                    lblPara(i).Text = "Spessore"
                    If System.Math.Abs(Tipo) = 23 Then lblPara(i).Text = "Diametro"
                    txtPara.Load(i)
                    txtPara(i).Text = LTrim(Str(Membro.Spessore))
                    Nf = i
                Case 17
                    Dim lMembroC As Anello = CType(Membro, Anello)
                    lblPara(0).Text = "Diametro esterno"
                    txtPara(0).Text = LTrim(Str(lMembroC.DiamExt))
                    lblPara.Load(1)
                    lblPara(1).Text = "Diametro interno"
                    txtPara.Load(1)
                    txtPara(1).Text = LTrim(Str(lMembroC.DiamInt))
                    lblPara.Load(2)
                    lblPara(2).Text = "Spessore"
                    txtPara.Load(2)
                    txtPara(2).Text = LTrim(Str(lMembroC.Spess))
                    Nf = 2
                    If lMembroC.TipoS = 5 Then
122:                    lblPara.Load(3)
                        lblPara(3).Text = "Diametro mantello"
123:                    txtPara.Load(3)
                        txtPara(3).Text = LTrim(Str(lMembroC.Dmant))
                        Nf = 3
                    End If
                Case 18
                    For i = 1 To 21
124:                    txtPara.Load(i)
125:                    lblPara.Load(i)
                    Next
                    CType(Membro, Dilat).PrSeFinDil(Nf)
                Case 25
                    Dim lMembroC As Sella = CType(Membro, Sella)
                    If lMembroC.Standardsel < 1 Then lMembroC.Standardsel = 1
                    db = New OleDbConnection(Conn & Monitor.Motore.Inizio.Archdir & "\Selle.mdb" & ConnFine)
                    Dim SQL As String
                    If lMembroC.Standardsel > 0 Then
                        SQL = "SELECT * FROM Catalogo WHERE Listindex =" & Str(lMembroC.Standardsel - 1)
                    Else
                        SQL = "SELECT * FROM Catalogo"
                    End If
                    cmddb = New OleDbDataAdapter(SQL, db)
                    cmddb.Fill(tableCat)
                    cmddbT = New OleDbDataAdapter("SELECT * FROM " + CStr(tableCat.Rows(0)("tabvar")) + " ORDER BY Ordine", db)
                    cmddbT.Fill(Table) '= db.OpenRecordset("SELECT * FROM " + tableCat.Fields("tabvar") + " ORDER BY Ordine") '5-5-99
                    For i = 1 To 22 '6-5-99
2124:                   txtPara.Load(i)
2125:                   lblPara.Load(i)
                    Next
                    For i = 0 To CShort(Table.Rows.Count - 1)
1241:                   '  If i > 0 Then Load lblPara(i)
                        lblPara(i).Text = CStr(Table.Rows(i)("Label"))
                        Select Case CStr(Table.Rows(i)("Tipo"))
                            Case "T" ' testo
1251:                           '        If i > 0 Then Load txtPara(i)
                                TextArr(i) = txtPara(i)
                            Case "O" ' combo obbligato
1252:                           If i > 0 Then
                                    cmbParaO.Load(i)
                                    'Load txtPara(i)
                                End If
                                TextArr(i) = cmbParaO(i)
                                txtPara(i).Visible = False
                                ComboFill(Table, tableCat)
                                Select Case i
                                    Case 0
                                        For j = 0 To CShort(cmbParaO(i).Items.Count - 1)
                                            If GlobalRoutines.ValVir(CStr(cmbParaO(i).Items(j))) = lMembroC.Serie Then
                                                cmbParaO(i).SelectedIndex = j
                                                Exit For
                                            End If
                                        Next
                                    Case 1
                                        cmbParaO(i).SelectedIndex = CInt(lMembroC.sempor) + 1
                                    Case 10
                                        cmbParaO(i).SelectedIndex = CInt(lMembroC.FixSlid) + 1
                                    Case 11
                                        cmbParaO(i).SelectedIndex = CInt(lMembroC.CI) + 1
                                End Select
                            Case "C" 'combo libero
1253:                           If i > 0 Then cmbPara.Load(i)
                                TextArr(i) = cmbPara(i)
                                txtPara(i).Visible = False
                                ComboFill(Table, tableCat)
                        End Select
                        LblArr(i) = lblPara(i)
                        i = CShort(i + 1)
                    Next i
                    Table.Dispose()
                    db.Dispose()
                    Nf = CShort(i - 1)
                    lMembroC.PrSeFinDil(Nf)
                Case 19, -19
                    Dim lMembroC As Diaframma = CType(Membro, Diaframma)
                    lblPara(0).Text = "Diametro esterno"
                    txtPara(0).Text = LTrim(Str(lMembroC.DiamExt))
126:                lblPara.Load(1)
                    lblPara(1).Text = "Classe TEMA"
127:                cmbPara.Load(1)
                    cmbPara(1).Items.Clear()
                    cmbPara(1).Items.Add("R")
                    cmbPara(1).Items.Add("C")
                    cmbPara(1).Items.Add("B")
                    If lMembroC.ClassTEMA = 0 Then lMembroC.ClassTEMA = 1
                    cmbPara(1).SelectedIndex = lMembroC.ClassTEMA - 1
128:                lblPara.Load(2)
                    lblPara(2).Text = "Tipo Diaframmi"
129:                cmbPara.Load(2)
                    cmbPara(2).Items.Clear()
                    For i = 1 To 6
                        cmbPara(2).Items.Add(lMembroC.TipiP(i))
                    Next
                    If lMembroC.TipoDiafr = 0 Then lMembroC.TipoDiafr = 1
                    cmbPara(2).SelectedIndex = lMembroC.TipoDiafr - 1
130:                lblPara.Load(3)
                    lblPara(3).Text = "SottoTipo 1° diafr."
131:                cmbPara.Load(3)
                    lMembroC.ListTipi()
                    If lMembroC.SottoTipo = 0 Then lMembroC.SottoTipo = 1
                    cmbPara(3).SelectedIndex = lMembroC.SottoTipo - 1
132:                lblPara.Load(4)
                    lblPara(4).Text = "Spessore"
133:                txtPara.Load(4)
                    txtPara(4).Text = LTrim(Str(lMembroC.Spessore))
134:                lblPara.Load(5)
                    lblPara(5).Text = "Passo diaframmi"
135:                txtPara.Load(5)
                    txtPara(5).Text = LTrim(Str(lMembroC.Passo))
136:                lblPara.Load(6)
                    lblPara(6).Text = "Passo 1° diafr."
137:                txtPara.Load(6)
                    txtPara(6).Text = LTrim(Str(lMembroC.Passo1))
138:                lblPara.Load(7)
                    lblPara(7).Text = "Percentuale di taglio"
139:                txtPara.Load(7)
                    txtPara(7).Text = LTrim(Str(lMembroC.Percento))
                    If CType(lMembro.GenMem, clsGenMem).Tipo < 0 Then
140:                    lblPara.Load(8)
                        lblPara(8).Text = "Numero diaframmi"
141:                    txtPara.Load(8)
                        txtPara(8).Text = LTrim(Str(lMembroC.NumDiafr))
                        Nf = 8
                    Else
142:                    lblPara.Load(8)
                        lblPara(8).Text = "Numero diafr. tipo A"
143:                    txtPara.Load(8)
                        txtPara(8).Text = LTrim(Str(lMembroC.NumTipoA))
144:                    lblPara.Load(9)
                        lblPara(9).Text = "Numero diafr. tipo B"
145:                    txtPara.Load(9)
                        txtPara(9).Text = LTrim(Str(lMembroC.NumTipoB))
146:                    lblPara.Load(10)
                        lblPara(10).Text = "Numero fori"
147:                    txtPara.Load(10)
                        txtPara(10).Text = LTrim(Str(lMembroC.NumFori))
148:                    lblPara.Load(11)
                        lblPara(11).Text = "Diametro fori"
149:                    txtPara.Load(11)
                        txtPara(11).Text = LTrim(Str(lMembroC.Diamfori))
1491:                   lblPara.Load(12)
                        lblPara(12).Text = "Direzione tagli"
1492:                   cmbPara.Load(12)
                        cmbPara(12).Items.Clear()
                        cmbPara(12).Items.Add("Orizzontale")
                        cmbPara(12).Items.Add("Verticale")
                        If lMembroC.DirezVert Then cmbPara(12).SelectedIndex = 1 Else cmbPara(12).SelectedIndex = 0
                        Nf = 12
                    End If
                Case 28
                    With CType(Membro, clsGuarniz)
                        lblPara(0).Text = "Tipo guarnizione"
                        txtPara(0).Text = LTrim(.StandardGua.ClassS)
                        lblPara.Load(1)
                        lblPara(1).Text = "Materiale/dimensioni"
                        txtPara.Load(1)
                        txtPara(1).Text = LTrim(.StandardGua.TipoS)
                        lblPara.Load(2)
                        lblPara(2).Text = "Diametro medio"
                        txtPara.Load(2)
                        txtPara(2).Text = LTrim(Str(.DiamMed))
                        lblPara.Load(3)
                        lblPara(3).Text = "Larghezza"
                        txtPara.Load(3)
                        txtPara(3).Text = LTrim(Str(.Largh))
                        lblPara.Load(4)
                        lblPara(4).Text = "Spessore"
                        txtPara.Load(4)
                        txtPara(4).Text = .Spess.ToString
                        Nf = 4
                        If .StandardGua.Tipo = 7 Then 'spirotallic
                            Nf = 7
                            lblPara.Load(5)
                            lblPara(5).Text = "Larghezza anello esterno"
                            txtPara.Load(5)
                            txtPara(5).Text = LTrim(Str(.LarghExt))
                            lblPara.Load(6)
                            lblPara(6).Text = "Larghezza anello interno"
                            txtPara.Load(6)
                            txtPara(6).Text = LTrim(Str(.LarghInt))
                            lblPara.Load(7)
                            lblPara(7).Text = "Spessore anello/i"
                            txtPara.Load(7)
                            txtPara(7).Text = LTrim(Str(.SpessAn))
                        End If
                    End With
                Case 32, -32, 33, -33 'set di tondi rods
                    Dim lMembroC As Raggrupp = CType(Membro, Raggrupp)
                    Select Case Tipo
                        Case 32, -32 : lblPara(0).Text = "Diametro tondi"
                        Case 33, -33 : lblPara(0).Text = "Diametro rods"
                    End Select
                    txtPara(0).Text = LTrim(Str(lMembroC.DiamExt))
164:                lblPara.Load(1)
                    lblPara(1).Text = "Lunghezza max"
165:                txtPara.Load(1)
                    txtPara(1).Text = LTrim(Str(lMembroC.Lunghezza))
1641:               lblPara.Load(2)
                    lblPara(2).Text = "Numero"
166:                txtPara.Load(2)
                    txtPara(2).Text = LTrim(Str(lMembroC.Numero))
                    Nf = 2
                Case 31, -31 'set di S.S.
                    Dim lMembroC As Raggrupp = CType(Membro, Raggrupp)
                    lblPara(0).Text = "Spessore S.S."
                    txtPara(0).Text = LTrim(Str(lMembroC.Spessore))
167:                lblPara.Load(1)
                    lblPara(1).Text = "Lunghezza max"
168:                txtPara.Load(1)
                    txtPara(1).Text = LTrim(Str(lMembroC.Lunghezza))
169:                lblPara.Load(2)
                    lblPara(2).Text = "Larghezza"
170:                txtPara.Load(2)
                    txtPara(2).Text = LTrim(Str(lMembroC.Larghezza))
171:                lblPara.Load(3)
                    lblPara(3).Text = "Numero"
172:                txtPara.Load(3)
                    txtPara(3).Text = LTrim(Str(lMembroC.Numero))
                    Nf = 3
                Case 21 'curve
                    Dim lMembroC As Curva = CType(Membro, Curva)
                    If lMembroC.TipoS = 0 Then
                        lblPara(0).Text = "Diametro esterno"
                    Else
                        lblPara(0).Text = "Diametro interno"
                    End If
                    txtPara(0).Text = LTrim(Str(lMembroC.Diametro))
2201:               lblPara.Load(1)
                    lblPara(1).Text = "Spessore"
2202:               txtPara.Load(1)
                    txtPara(1).Text = LTrim(Str(lMembroC.SpessBase))
2203:               lblPara.Load(2)
                    lblPara(2).Text = "Apertura"
2204:               txtPara.Load(2)
                    txtPara(2).Text = LTrim(Str(lMembroC.Apertura))
2205:               lblPara.Load(3)
                    lblPara(3).Text = "Raggio"
2206:               txtPara.Load(3)
                    txtPara(3).Text = LTrim(Str(lMembroC.Raggio))
                    Nf = 3
                    If lMembroC.TipoS = 1 Then
2207:                   lblPara.Load(4)
                        lblPara(4).Text = "N° spicchi"
2208:                   txtPara.Load(4)
                        txtPara(4).Text = LTrim(Str(lMembroC.Numero))
                        Nf = 4
                    End If
                Case 37
                    lblPara(0).Text = "Spessore"
                    txtPara(0).Text = LTrim(Str(Membro.Spessore))
            End Select
            ' InTesti = False
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Private Sub ComboFill(ByVal Table As DataTable, ByVal tableCat As DataTable)
        Dim table1 As New DataTable
        Dim tabserie As New DataTable
        Dim i As Short
        If Not CStr(Table.Rows(0)("Lista")) = "Nullo" Then
            CType(TextArr(i), ComboBox).Items.Clear()
            Dim lcmd As New OleDbDataAdapter("SELECT * FROM " + CStr(Table.Rows(0)("Lista")), db)
            lcmd.Fill(table1) '= db.OpenRecordset("SELECT * FROM " + Table.Fields("Lista"))
            For i = 0 To CShort(table1.Rows.Count - 1)
                CType(TextArr(i), ComboBox).Items.Add(CStr(table1.Rows(i)("Tipo")))
            Next
            table1.Dispose()
        Else
            Dim SQL As String
            If CType(Membro, Sella).StandardSEl > 0 Then
                SQL = "SELECT DISTINCT Serie FROM " + CStr(tableCat.Rows(0)("Tabella")) + " WHERE Standard =" + CType(Membro, Sella).Standard.ToString
            Else
                SQL = "SELECT DISTINCT Serie FROM " + CStr(tableCat.Rows(0)("Tabella"))
            End If
            Dim lcmd As New OleDbDataAdapter(SQL, db)
            lcmd.Fill(tabserie)
            CType(TextArr(i), ComboBox).Items.Clear()
            For i = 0 To CShort(tabserie.Rows.Count - 1)
                CType(TextArr(i), ComboBox).Items.Add(tabserie.Rows(i)("Serie"))
            Next
            tabserie.Dispose()
        End If
    End Sub
    Private Sub EnaTesti(ByRef ini As Short, ByRef Nf As Short)
        Dim i As Short
        Try
            If LblArr(0) Is Nothing Then
                TextArr(0).Top = LblArr(1).Top
            Else
                TextArr(0).Top = LblArr(0).Top
            End If
            If option1.Visible And Not (System.Math.Abs(Membro.GenMem.Tipo) = 10 Or System.Math.Abs(Membro.GenMem.Tipo) = 14) Then
                TextArr(0).Top = option1.Top + option1.Height
                LblArr(0).Top = option1.Top + option1.Height
            End If
            TextArr(0).TabIndex = 1
            If Not TextArr(0) Is option1 Then TextArr(0).Visible = True
        Catch
        End Try
        For i = ini To Nf
            LblArr(i).Top = CInt(LblArr(i - 1).Top + 1.1 * LblArr(i - 1).Height)
            TextArr(i).Top = CInt(TextArr(i - 1).Top + 1.1 * LblArr(i - 1).Height)
            LblArr(i).Enabled = True
            LblArr(i).Visible = True
            If Not CStr(TextArr(i).Tag) = "nv" Then
                TextArr(i).Enabled = True
                TextArr(i).Visible = True
            Else
                TextArr(i).Visible = False
                LblArr(i).Visible = False
            End If
            If CStr(TextArr(i).Tag) = "ne" Then TextArr(i).Enabled = False
            TextArr(i).TabIndex = i + 1
        Next
    End Sub
    Private Sub Special(ByRef Tipo As Short) 'aggiorna
        Dim j, i, k As Short
        If GiaSpecial Then Exit Sub
        On Error GoTo ErrSpec
        Select Case Tipo
            Case 2, 13, 28, 21
                If Not GiaSpecial Then
                    GiaSpecial = True
                End If
                Librerie(0).Top = TextArr(0).Top
                Librerie(0).Left = TextArr(0).Left + TextArr(0).Width
                Librerie.Load(1)
                Librerie(1).Top = TextArr(1).Top
                Librerie(1).Left = TextArr(1).Left + TextArr(1).Width
                Librerie(0).Visible = True
                Librerie(1).Visible = True
                Librerie(0).Enabled = True
                Librerie(1).Enabled = True
                TextArr(0).Enabled = False
                TextArr(1).Enabled = False
            Case 6, 7
                If CType(Membro, Cono).Fitting Then
                    If Not GiaSpecial Then
                        GiaSpecial = True
                    End If
                    Librerie(0).Top = TextArr(0).Top
                    Librerie(0).Left = TextArr(0).Left + TextArr(0).Width
                    Librerie.Load(1)
                    Librerie(1).Top = TextArr(3).Top
                    Librerie(1).Left = TextArr(3).Left + TextArr(3).Width
                    Librerie(0).Visible = True
                    Librerie(1).Visible = True
                    Librerie(0).Enabled = True
                    Librerie(1).Enabled = True
                End If
            Case 19
                If Not GiaSpecial Then
                    GiaSpecial = True
                End If
                Librerie(0).Top = CInt(GlobalRoutines.TwipsToPixelsY(LegacyUiUnits.PixelsToTwipsY(TextArr(4).Top)))
                Librerie(0).Left = CInt(GlobalRoutines.TwipsToPixelsX(LegacyUiUnits.PixelsToTwipsX(TextArr(4).Left) + LegacyUiUnits.PixelsToTwipsX(TextArr(4).Width)))
                If Membro.GenMem.Tipo = -19 Then
                    Librerie.Load(1)
                    Librerie(1).Top = TextArr(8).Top
                    Librerie(1).Left = TextArr(8).Left + TextArr(8).Width
                End If
                Librerie(0).Visible = True
                If Membro.GenMem.Tipo = -19 Then Librerie(1).Visible = True
                Librerie(0).Enabled = True
                If Membro.GenMem.Tipo = -19 Then Librerie(1).Enabled = True
            Case 10, 26
                If Not GiaSpecial Then
                    GiaSpecial = True
                End If
                If Tipo = 10 Then i = 2 Else i = 7
                Librerie(0).Top = TextArr(i).Top
                Librerie(0).Left = TextArr(i).Left + TextArr(i).Width
                Librerie(0).Visible = True
                Librerie(0).Enabled = True
                If Tipo = 10 Then
                    If CType(Membro, clsBocch).GenMem.Tipo = -10 Then
                        Librerie(0).Visible = False
                    End If
                End If
            Case 14
                If Not GiaSpecial Then GiaSpecial = True
                Librerie(0).Top = TextArr(4).Top
                Librerie(0).Left = TextArr(4).Left + TextArr(4).Width
                Librerie(0).Enabled = True
                Librerie(0).Visible = True
                For i = 1 To 6
                    Librerie.Load(i)
                    If i = 1 Then
                        Librerie(i).Top = TextArr(5).Top
                        Librerie(i).Left = TextArr(5).Left + TextArr(5).Width
                        Librerie(i).Enabled = True
                        Librerie(i).Visible = True
                    Else
                        For k = 1 To nArr
                            j = CShort(Val(txtPara(k).Tag)) 'Esp
                            If j = i + 9 Then
                                Librerie(i).Top = TextArr(k).Top
                                Librerie(i).Left = TextArr(k).Left + TextArr(k).Width
                                Librerie(i).Enabled = True
                                Librerie(i).Visible = True
                            End If
                        Next
                    End If
                Next
            Case 12
                If Not GiaSpecial Then GiaSpecial = True
                Librerie(0).Top = TextArr(nArr - 1).Top
                Librerie(0).Left = TextArr(nArr - 1).Left + TextArr(nArr - 1).Width
                On Error Resume Next
                Librerie.Load(1)
                On Error GoTo 0
                Librerie(1).Top = TextArr(nArr).Top
                Librerie(1).Left = TextArr(nArr).Left + TextArr(nArr).Width
                Librerie(0).Visible = True
                Librerie(1).Visible = True
                Librerie(0).Enabled = True
                Librerie(1).Enabled = True
            Case 18
                For i = 0 To nArr
                    Select Case Val(TextArr(i).Tag)
                        Case 18
                            If Not GiaSpecial Then GiaSpecial = True
                            Librerie(0).Top = TextArr(i).Top
                            Librerie(0).Left = TextArr(i).Left + TextArr(i).Width
                            Librerie(0).Visible = True
                            Librerie(0).Enabled = True
                            ' TextArr(i) = ""
                            ' If Not Membro.MatAnel Is Nothing Then TextArr(i) = Membro.MatAnel.matstr
                        Case 19
                            Librerie.Load(1)
                            Librerie(1).Top = TextArr(i).Top
                            Librerie(1).Left = TextArr(i).Left + TextArr(i).Width
                            Librerie(1).Visible = True
                            Librerie(1).Enabled = True
                            'TextArr(i) = ""
                            'If Not Membro.MatColl Is Nothing Then TextArr(i) = Membro.MatColl.matstr
                        Case 20
                            Librerie.Load(2)
                            Librerie(2).Top = TextArr(i).Top
                            Librerie(2).Left = TextArr(i).Left + TextArr(i).Width
                            Librerie(2).Visible = True
                            Librerie(2).Enabled = True
                            'TextArr(i) = ""
                            'If Not Membro.MatBull Is Nothing Then TextArr(i) = Membro.MatBull.matstr
                    End Select
                Next
            Case 25
                If Not GiaSpecial Then GiaSpecial = True
                Librerie(0).Top = TextArr(0).Top
                TextArr(0).Width = CInt(GlobalRoutines.TwipsToPixelsX(1000)) 'TextArr(0).Width - TextArr(0).Height
                Librerie(0).Left = TextArr(0).Left + TextArr(0).Width
                Librerie(0).Enabled = True
                Librerie(0).Visible = True
                ToolTip1.SetToolTip(Librerie(0), "Richiama la libreria delle selle standard")
                Librerie.Load(1)
                TextArr(4).Width = CInt(GlobalRoutines.TwipsToPixelsX(1000)) 'TextArr(0).Width - TextArr(0).Height
                Librerie(1).Top = TextArr(4).Top
                Librerie(1).Left = TextArr(4).Left + TextArr(4).Width
                Librerie(1).Visible = True
                Librerie(1).Enabled = True
                ToolTip1.SetToolTip(Librerie(1), "Fornisce maggiori dettagli")
        End Select
        On Error GoTo 0
        Exit Sub
ErrSpec: If Err.Number = 360 Then
            Select Case Erl()
                Case 100, 101, 103, 104, 114
                    Librerie(1).Visible = True
                Case 102
                    Librerie(i).Visible = True
                Case 105
                    Librerie(2).Visible = True
            End Select
            Resume Next
        Else
            MsgBox(ErrorToString() & "in Special" & Str(Err.Number))
            Resume Next
        End If
    End Sub
    Private Sub AggMetrica()
        Select Case CType(Membro, clsTirante).StandardTir.Xfil
            Case 1 : txtPara(1).Text = "Metrica"
            Case 2 : txtPara(1).Text = "ANSI"
            Case 3 : txtPara(1).Text = "Metrica (Pilgrim)"
            Case 4 : txtPara(1).Text = "ANSI (Pilgrim)"
            Case Else : txtPara(1).Text = "Metrica"
                CType(Membro, clsTirante).StandardTir.Xfil = 1
        End Select
    End Sub
    Public Sub SuperPosN(Optional ByRef carica As Boolean = False)
        Dim Res As Boolean, i As Short
        If IUNL > 4 Then Exit Sub
        Res = SetCoordN()
        With Membro.GenMem.posizione
            .Quota = cmbCodPos(0).Text
            .Anomal = cmbCodPos(1).Text
            .Raggio = cmbCodPos(2).Text
            .DirDiritta = cmbCodPos(3).Text
            .DirTraversa = cmbCodPos(4).Text
        End With
        GenMemInText()
        If Not carica Then
            If cmbSuChi.SelectedIndex > -1 Then i = CShort(GlobalRoutines.ValVir(CStr(lstSuChi.Items(cmbSuChi.SelectedIndex)))) Else i = 1
            Membro.GenMem.posizione.SuChi = CType(Apparecchio.Elementi(i - 1), Membratura)
        End If
        AggCoordN(Membro.GenMem) ', Apparecchio 'aggiornare anche gli appesi
        If Membro.GenMem.Tipo < 0 Then
            cmbSuChi.Visible = False
            Label2.Visible = True
        End If
    End Sub
    Private Sub txtTipo_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles txtTipo.MouseDown
        'Dim Button As Short = eventArgs.Button \ &H100000
        'Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        'Dim x As Single = LegacyUiUnits.PixelsToTwipsX(eventArgs.X)
        'Dim y As Single = LegacyUiUnits.PixelsToTwipsY(eventArgs.Y)
        AltroClick = True
    End Sub
    Private Function SetCoordN() As Boolean
        Dim Recv, Rec As clsGenMem
        Dim Membrov As Membratura
        Rec = Membro.GenMem
        Recv = Rec.posizione.SuChi.GenMem
        Membrov = Rec.posizione.SuChi
        SetCoordN = True
        'Abilitato = True
        'GoSub InLineaPiu
        'Abilitato = False
        Select Case System.Math.Abs(Recv.Tipo)
            '--------------------------------------------------------------
        Case 0
                ''       If Lav(0).CalcBaric Then
                ''            Call Selez(5, False, 1)
                ''       Else
                ''            GoSub InLineaPiu
                ''            Exit Function
                ''       End If
                '------------------------------------------------------------------------
            Case 1, 34 ' su Cilindri
                Select Case System.Math.Abs(Rec.Tipo)
                    '           Case 0, 13:        Print "Err.imp.SetCoord": End
                    '           Case 1, 18, 34:    Call Selez(2, False, 1)    'cilindro o dilatatore o tegola su cilindro
                    '           Case 2:            Call Selez(2, False, 2)    'Tubo su cilindro
                Case 3, 4, 5, 16, 18
                        FonSuCil() 'Fondi su cilindro
                    Case 6
                        OidSuCil(Rec)  'Conoide su cilindro
                    Case 7
                        ConSuCil(Rec) 'Cono su cilindro
                    Case 10
                        BocSuCil(Recv)
                    Case 14
                        ForgSuCil() 'bocchello son standard
                    Case 21
                        CurSuCil() 'curva su tronchetto
                    Case 25
                        SelSuCil() 'sella su cilindro
                    Case 36
                        InLineaPiu2() 'Belts
                    Case 11
                        FlanSuCil(Rec) 'flangioni su cilindri
                    Case 12
                        If Not PiasCil() Then SetCoordN = False 'piastre su cilindri
                    Case Else : SetStop(Rec, Recv)
                End Select
                '-----------------------------------------------------------------
            Case 2
                Select Case System.Math.Abs(Rec.Tipo)
                    Case 21
                        CurSuCil() 'curva su tronchetto
                End Select
                '----------------------------------------------------------------------
            Case 3, 4, 5, 16
                Select Case System.Math.Abs(Rec.Tipo)
                    '           Case 0, 3, 4, 5, 13:   Print "Err.imp.SetCoord": End
                    '8-5-99 Case 1, 10, 14:        GoSub BocFon           'Cilindro e bocchello su fondo
                Case 10, 14
                        BocFon()  'bocchello su fondo
                    Case 2 : SetStop(Rec, Recv) 'Tubo su fondo
                    Case 6 : SetStop(Rec, Recv) 'Conoide
                    Case 7
                        ConSuFon(Rec, Recv) 'Cono su fondo
                    Case 11, 12
                        InLineaMeno() 'Flangioni e piastre su fondi
                    Case Else : SetStop(Rec, Recv)
                End Select
                '---------------------------------------------------------------
            Case 6, 7 'su conoidi e Coni
                Select Case System.Math.Abs(Rec.Tipo)
                    Case 0, 13 : SetStop(Rec, Recv)
                    Case 1
                        CilSuCO(Rec, Recv)
                        '           Case 10, 14:         Call Selez(2, False, 1) 'Cilindri e bocchelli su coni
                    Case 3, 4, 5, 16
                        FonSuCil()  'Fondi su Coni
                    Case 7
                        ConSuCil(Rec)  'Coni su coni
                    Case 11
                        FlanSuCil(Rec)
                    Case 12
                        If Not PiasCil() Then SetCoordN = False : Exit Function
                        PiasCon(Recv)  'Piastre/flangioni su coni
                    Case 25
                        SelSuCil()
                        '           Case 34:             Call Selez(2, True, 7)  'tegola
                    Case Else : SetStop(Rec, Recv)
                End Select
                '-------------------------------------------------------------
            Case 8
                Select Case System.Math.Abs(Rec.Tipo)
                    Case 31, 32, 33 'SS,tondi,rods
                        DiafTub(Rec)
                    Case 12
                        TubiDir(Rec)  'su Tubi diritti
                    Case Else
                        DiafTub(Rec)
                End Select
            Case 9
                Select Case System.Math.Abs(Rec.Tipo)
                    Case 31, 32, 33 'SS,tondi,rods
                        DiafTub(Rec)
                    Case 12
                        DiafTub(Rec)
                End Select
            Case 26
                Select Case System.Math.Abs(Rec.Tipo)
                    Case 12
                        TubiDir(Rec)  'su Tubi diritti
                    Case 8, 9
                        InLineaPiu()
                    Case Else : MsgBox("Impossibile tipo " & Str(Rec.Tipo) & "su fasci")
                End Select
                '-------------------------------------------------------------
            Case 10
                Select Case System.Math.Abs(Rec.Tipo)
                    Case 2
                        InLineaMeno()
                        '         Case 10:    Call Selez(2, False, 1)    'cilindro o dilatatore o tegola su cilindro
                End Select
                '-------------------------------------------------------------
            Case 11, 12 'su Flangioni,Piastre
                Select Case System.Math.Abs(Rec.Tipo)
                    Case 1, 3, 4, 5, 16, 34
                        If Not Cil1112(Rec, Recv, Membrov) Then SetCoordN = False 'Cilindri,fondi su flangioni e piastre
                    Case 6
                        OidSuPia(Rec, Recv)
                    Case 7
                        ConSuFon(Rec, Recv) 'coni su flangioni e piastre
                    Case 10
                        Boc1112(Recv, Membrov) 'Bocchelli su flangioni  e piastre
                        '        Case 14:                     Call Selez(8, False, 1) 'bocch non std su flangioni e piastre
                    Case 12
                        PiasFla(Rec)  'Piastre su flangioni
                    Case 11
                        FlanFla(Rec, Recv, Membrov) 'Flangioni su flangioni e Piastre
                    Case 8, 9, 13, 26
                        TirSuFla(Rec, Recv, Membrov) 'Tiranti e tubi su flangioni e piastre
                    Case 28
                        GuarnizFla(Rec, Recv, Membrov) 'Guarnizioni su flangioni e piastre
                    Case 37
                        InLineaMeno()
                        'Case 26:                     GoSub FasSuPia
                End Select
                '-------------------------------------------------------------
            Case 18 'su dilatatori
                '     Call Selez(2, False, 1)
                '-----------------------------------------------------------------
            Case 21
                Select Case System.Math.Abs(Rec.Tipo)
                    Case 1, 2
                        FonSuCil() 'tronchetto su curva
                End Select
                '----------------------------------------------------------------------
            Case 28 'Guarnizioni
                Select Case System.Math.Abs(Rec.Tipo)
                    Case 11 ' Flangioni
                        If Membro.SottoTipo < 4 Then
                            cmbCodPos(0).Text = "Far " 'cmbCodPos(0).Text
                            cmbCodPos(3).Text = "=-" 'cmbCodPos(3).Text
                        Else
                            '                Call Selez(24, False, 1)
                            CPiu()
                        End If
                    Case 10, 14 'Bocchelli
                        cmbCodPos(0).Text = "Far " 'cmbCodPos(0).Text
                        cmbCodPos(3).Text = "=-" 'cmbCodPos(3).Text
                    Case 12 'Piastre su guarnizioni
                        Select Case Membro.SottoTipo
                            Case 1, 2
                                NoPiasGuar(Rec)
                            Case 3 : cmbCodPos(3).Text = "=+"
                            Case 4
                                Piastra6()
                            Case 5 : cmbCodPos(3).Text = "=+"
                            Case 6
                                Piastra6()
                        End Select
                End Select
                '-------------------------------------------------------------------
                '   Case 13: Call Selez(2, True, 1)  'Tiranti
                '------------------------------------------------------------------
            Case Else : SetStop(Rec, Recv)
        End Select
        '               Rec.posizione.quota = cmbCodPos(0).Text
        '               Rec.posizione.Anomal = cmbCodPos(1).Text
        '               Rec.posizione.Raggio = cmbCodPos(2).Text
        '               Rec.posizione.DirDiritta = cmbCodPos(3).Text
        '               Rec.posizione.DirTraversa = cmbCodPos(4).Text
    End Function
    '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    Private Sub InLineaPiu()
        cmbCodPos(0).Text = "Near End"
        InLineaPiu2()
    End Sub
    Private Sub InLineaPiu2()
        cmbCodPos(1).Text = "N.A."
        InLineaPiu1()
    End Sub
    Private Sub InLineaPiu1()
        cmbCodPos(2).Text = "N.A."
        InLineaPiu3()
    End Sub
    Private Sub InLineaPiu3()
        cmbCodPos(3).Text = "=+"
        cmbCodPos(4).Text = "Auto"
    End Sub
    Private Sub InLineaMeno()
        InLineaPiu()
        cmbCodPos(3).Text = "=-"
    End Sub
    Private Sub InLineaMeno1()
        InLineaPiu1()
        cmbCodPos(3).Text = "=-"
    End Sub
    Private Sub InLineaMeno3()
        InLineaPiu3()
        cmbCodPos(3).Text = "=-"
    End Sub
    Private Function NoPiasGuar(ByVal Rec As clsGenMem) As Boolean
        NoPiasGuar = False
        MsgBox(" Questo tipo di piastra non ammette guarnizioni o flangioni", MsgBoxStyle.Information)
        Rec.Ind = -Rec.Ind ' : SetCoordN = False : Exit Function
    End Function
    Private Sub CPiu()
        If Mid(cmbCodPos(0).Text, 6, 1) = "C" Then
            cmbCodPos(3).Text = "=+"
        Else
            cmbCodPos(3).Text = "=-"
        End If
    End Sub
    Private Sub Cmeno()
        If Mid(cmbCodPos(0).Text, 6, 1) = "C" Then
            cmbCodPos(3).Text = "=-"
        Else
            cmbCodPos(3).Text = "=+"
        End If
    End Sub
    Private Sub Piastra6()
        '                Call Selez(13, False, 1)
        CPiu()
    End Sub
    Private Sub Piastra6a()
        '                Call Selez(13, False, 1)
        Cmeno()
    End Sub
    Private Function CilPias(ByVal Rec As clsGenMem, ByVal Membrov As Membratura) As Boolean
        CilPias = True
        Select Case Membrov.SottoTipo
            Case 4, 5, 6 : CilPias = False
            Case 1, 2
                Cmeno()
            Case 3, 7
                If System.Math.Abs(Rec.Tipo) = 34 Then
                    cmbCodPos(1).Text = cmbCodPos(0).Text
                    cmbCodPos(0).Text = "N.A."
                    cmbCodPos(3).Text = "=+"
                Else
                    cmbCodPos(3).Text = "=+"
                    cmbCodPos(0).Text = "Lato Mantello"
                End If
        End Select
    End Function
    Private Function PiasCil() As Boolean
        PiasCil = True
        Select Case Membro.SottoTipo
            Case 4, 5, 6 : PiasCil = False
            Case 1, 2 ' jAlg = 10
                Selez10()
            Case 3, 7
                If cmbCodPos(0).Text.Substring(0, 1) = "N" Then
                    InLineaPiu1()
                Else
                    InLineaMeno1()
                End If
        End Select
    End Function
    Private Sub Selez10()
        '                Call Selez(jAlg, False, 1)
        If cmbCodPos(0).Text.Substring(0, 2) = "Ne" Then
            If Mid(cmbCodPos(1).Text, 6, 1) = "C" Then
                InLineaMeno3()
            Else
                InLineaPiu3()
            End If
        Else
            If Mid(cmbCodPos(1).Text, 6, 1) = "C" Then
                InLineaPiu1()
            Else
                InLineaMeno1()
            End If
        End If
    End Sub
    Private Sub PiasCon(ByVal Recv As clsGenMem)
        'If Mid(Recv.posizione.Raggio, 6, 1) = "P" Then
        If cmbCodPos(0).Text.Substring(0, 2) = "Ne" Then
            cmbCodPos(2).Text = "Lato Grande"
        Else
            cmbCodPos(2).Text = "Lato Piccolo"
        End If
    End Sub
    Private Sub DomSenzaHub(ByVal Rec As clsGenMem, ByVal x As Short)
        Dim Stringa(2) As String
        Dim x1, x2 As Short
        x1 = 2 : If Val(Rec.posizione.Raggio) <> 0 Then x1 = 1
        Stringa(1) = HelpStringa(151) '"Giunzione lap-joint"
        Stringa(2) = HelpStringa(152) '"Giunzione set-on"
        x = Monitor.Motore.Quale(2, HelpStringa(153), Stringa, "", x1)
    End Sub
    Private Sub SetCorrez(ByVal Correz As Single)
        Select Case cmbCodPos(0).Text.Substring(0, 2) '3
            Case Is = "Ne" : cmbCodPos(2).Text = Str(Correz)
            Case Is = "Fa" : cmbCodPos(2).Text = Str(-Correz)
            Case Else
                MsgBox("Caso n p.in SetCoord" & cmbCodPos(0).Text)
        End Select '3
    End Sub
    Private Sub ConSuCil(ByVal Rec As clsGenMem)
        '             Call Selez(11, False, 1)
        If Mid(cmbCodPos(1).Text, 6, 1) = "G" Then Rec.posizione.NearFar = "N" Else Rec.posizione.NearFar = Chr(70)
        If cmbCodPos(0).Text.Substring(0, 1) = Rec.posizione.NearFar.Substring(0, 1) Then
            InLineaMeno1()
        Else
            InLineaPiu1()
        End If
    End Sub
    Private Sub Orienta(ByVal Rec As clsGenMem)
        If Mid(cmbCodPos(0).Text, 6, 1) = "G" Then
            Rec.posizione.NearFar = "N"
            InLineaMeno3()
        Else
            Rec.posizione.NearFar = "F"
            InLineaPiu3()
        End If
    End Sub
    Private Sub Orienta1(ByVal Rec As clsGenMem)
        If Mid(cmbCodPos(0).Text, 6, 1) = "G" Then
            Rec.posizione.NearFar = "N"
            If Mid(cmbCodPos(1).Text, 6, 1) = "C" Then
                InLineaMeno3()
            Else
                InLineaPiu3()
            End If
        Else
            Rec.posizione.NearFar = "F"
            If Mid(cmbCodPos(1).Text, 6, 1) = "C" Then
                InLineaPiu3()
            Else
                InLineaMeno3()
            End If
        End If
    End Sub
    Private Sub OidSuPia(ByVal Rec As clsGenMem, ByVal Recv As clsGenMem)
        Dim Testo As String
        If System.Math.Abs(Recv.Tipo) = 11 Then
            '  cmbCodPos(0).Text = cmbCodPos(2).Text
            '                Call Selez(17, False, 2) 'Conoidi su flangioni
            Orienta(Rec)
            'cmbCodPos(1).Text = "+N"
            cmbCodPos(2).Text = cmbCodPos(0).Text
            cmbCodPos(0).Text = "N.A."
        Else
            Testo = cmbCodPos(2).Text
            cmbCodPos(2).Text = cmbCodPos(1).Text
            cmbCodPos(1).Text = cmbCodPos(0).Text
            cmbCodPos(0).Text = Testo
            '                Call Selez(18, False, 2) 'Conoidi su piastre
            Orienta1(Rec)
            Testo = cmbCodPos(2).Text
            cmbCodPos(2).Text = cmbCodPos(0).Text
            cmbCodPos(0).Text = cmbCodPos(1).Text
            cmbCodPos(1).Text = Testo
        End If
    End Sub
    Private Sub ConSuFon(ByVal Rec As clsGenMem, ByVal Recv As clsGenMem)
        If System.Math.Abs(Recv.Tipo) = 12 Then
            cmbCodPos(1).Text = cmbCodPos(0).Text
            '             Call Selez(18, True, 1)
            Orienta1(Rec)
            cmbCodPos(0).Text = cmbCodPos(1).Text
        Else
            cmbCodPos(0).Text = cmbCodPos(1).Text
            '             Call Selez(17, True, 1)
            Orienta(Rec)
            'cmbCodPos(2).Text = cmbCodPos(0).Text
            cmbCodPos(0).Text = "N.A."
        End If
    End Sub
    Private Sub FlanSuCil(ByVal Rec As clsGenMem)
        Dim x As Short
        Dim Correz As Single
        With CType(Membro, Flangione)
            If .SottoTipo = 4 Then
                ' jAlg = 23
                Selez10()
            End If ' Else Call Selez(9, True, 2)
            If .SottoTipo < 4 Then
                If cmbCodPos(0).Text.Substring(0, 1) = "N" Then
                    InLineaMeno1()
                Else
                    InLineaPiu1()
                End If
            End If
            If .H = 0 And (.SottoTipo < 4 Or .SottoTipo = 4 And Mid(cmbCodPos(1).Text, 6, 1) = "C") Then 'flangione senza hub
                DomSenzaHub(Rec, x)
                If x = 1 Then ' giunzione lap-joint
                    If .SottoTipo = 1 Or .SottoTipo = 4 Then 'Gradino maschio
                        Correz = .SpessBase + .SpessGra
                    Else
                        Correz = .SpessBase - .SpessGra
                    End If
                    SetCorrez(Correz)
                End If
            End If
            If .H2 = 0 And .SottoTipo = 4 And Mid(cmbCodPos(1).Text, 6, 1) = "M" Then 'flangione senza hub
                DomSenzaHub(Rec, x)
                If x = 1 Then ' giunzione lap-joint
                    Correz = Membro.SpessBase + .SpessGra2
                    SetCorrez(Correz)
                End If
            End If
        End With
    End Sub
    Private Sub CilSuCO(ByVal Rec As clsGenMem, ByVal Recv As clsGenMem)
        Select Case System.Math.Abs(Recv.Tipo)
            Case 6 'cilindri su conoidi
                cmbCodPos(0).Text = cmbCodPos(2).Text
                '                   Call Selez(17, False, 2) 'Conoidi su flangioni
                Orienta(Rec)
                cmbCodPos(2).Text = cmbCodPos(0).Text
                cmbCodPos(0).Text = "N.A."
            Case 7
                ConSuCil(Rec)  'cilindri su coni
        End Select
    End Sub
    Private Sub OidSuCil(ByVal Rec As clsGenMem)
        '              Call Selez(16, False, 1)
        If Mid(cmbCodPos(2).Text, 6, 1) = "G" Then
            Rec.posizione.NearFar = "N"
            If cmbCodPos(0).Text.Substring(0, 1) = "F" Then
                InLineaPiu3()
            Else
                InLineaMeno3()
            End If
        Else
            Rec.posizione.NearFar = "F"
            If cmbCodPos(0).Text.Substring(0, 1) = "F" Then
                InLineaMeno3()
            Else
                InLineaPiu3()
            End If
        End If
    End Sub
    Private Sub BocSuCil(ByVal Recv As clsGenMem)
        Dim Correz As Single
        If Membro.TipoF < 5 Then 'bocchello con flangia
            Select Case Membro.Standard.K3
                Case 1, 2, 3, 4
                    ForgSuCil() 'Bocchello su cilindro,sella su cilindro
                Case Else : MsgBox("Caso 10 n p")
            End Select
        Else 'Flangia da sola
            Select Case Membro.Standard.K3
                Case 2 'slip-on
                    Correz = Membro.Standard.Altezza
                    '                       Call Selez(2, True, 6)
                    SetCorrez(Correz)
                Case Else : MsgBox("Caso 10 a n p")
            End Select
            If Membro.Randa = 0 Then
                Select Case Membro.GenMem.posizione.Raggio
                    Case "Re"
                        Membro.Randa = Recv.Parent.Diametro / 2 + Recv.Parent.Spessore
                    Case Else
                        Membro.Randa = Recv.Parent.Diametro / 2
                End Select
            End If
        End If
    End Sub
    Private Function Cil1112(ByVal Rec As clsGenMem, ByVal Recv As clsGenMem, ByVal Membrov As Membratura) As Boolean
        Dim x As Short
        Cil1112 = True
        If System.Math.Abs(Recv.Tipo) = 12 Then 'cilindri su piastre
            'Call LookTipoPiastra(Recv.Dati(), Look)finoqui
            If Not CilPias(Rec, Membrov) Then Cil1112 = False
        ElseIf System.Math.Abs(Recv.Tipo) = 11 Then  'cilindri su flangioni
            If Membrov.SottoTipo < 4 Then
                InLineaMeno()
                If CType(Membrov, Flangione).H = 0 Then
                    'GoSub DomSenzaHub
                    'cmbCodPos(2).Text = Str$(x)
                End If
            Else
                '                    Call Selez(24, False, 2)
                Cmeno()
                If CType(Membrov, Flangione).H = 0 And Mid(cmbCodPos(0).Text, 6, 1) = "C" Or _
                   CType(Membrov, Flangione).H2 = 0 And Mid(cmbCodPos(0).Text, 6, 1) = "M" Then
                    DomSenzaHub(Rec, x)
                    cmbCodPos(2).Text = Str(x)
                End If
            End If
        End If
    End Function
    Private Sub BocFon() 'Call Selez(4, False, 1)
        Membro.SpostLat = GlobalRoutines.ValVir(cmbCodPos(0).Text)
    End Sub
    Private Sub BocPiastra()
        '  Call Selez(3, False, 1)
        cmbCodPos(3).Text = "Na"
        cmbCodPos(4).Text = "Auto"
    End Sub
    Private Sub Boc1112(ByVal Recv As clsGenMem, ByVal Membrov As Membratura)
        If System.Math.Abs(Recv.Tipo) = 12 Then
            '                 Call LookTipoPiastra(Recv.Dati(), Look)
            Select Case Membrov.SottoTipo
                Case 5 ' Call Selez(8, False, 1)              'coperchio piano
                Case Else
                    BocPiastra()
            End Select
        Else
            BocPiastra()
        End If
    End Sub
    Private Sub CurSuCil()
        cmbCodPos(4).Text = cmbCodPos(1).Text
        cmbCodPos(1).Text = "N.A."
    End Sub
    Private Sub PiasFla(ByVal Rec As clsGenMem)
        'Call LookTipoPiastra(Rec.Dati(), Look)
        Select Case Membro.SottoTipo
            Case 1, 2
                NoPiasGuar(Rec)
            Case 3, 7 : cmbCodPos(3).Text = "=+"
            Case 4
                Piastra6()
            Case 6
                Piastra6()
        End Select
    End Sub
    Private Sub FlanFla(ByVal Rec As clsGenMem, ByVal Recv As clsGenMem, ByVal Membrov As Membratura)
        If System.Math.Abs(Recv.Tipo) = 11 Then 'flangioni su flangioni
            cmbCodPos(3).Text = "=-"
        Else 'flangioni su piastre
            'Call LookTipoPiastra(Recv.Dati(), Look)
            Select Case Membrov.SottoTipo
                Case 1, 2
                    NoPiasGuar(Rec)
                Case 3 : cmbCodPos(3).Text = "=+"
                Case 4, 5, 6
                    Piastra6()
            End Select
        End If
    End Sub
    Private Sub TirSuFla(ByVal Rec As clsGenMem, ByVal Recv As clsGenMem, ByVal Membrov As Membratura)
        If Len(RTrim(cmbCodPos(0).Text)) = 0 Then InLineaPiu()
        If System.Math.Abs(Recv.Tipo) = 12 Then
            'caso del coperchio piano: orientazione dei bulloni
            If Membrov.SottoTipo = 5 And Not (System.Math.Abs(Rec.Tipo) = 8 Or System.Math.Abs(Rec.Tipo) = 9 Or System.Math.Abs(Rec.Tipo) = 26) Then cmbCodPos(3).Text = "=-" Else cmbCodPos(3).Text = "=+"
        End If
        If System.Math.Abs(Recv.Tipo) = 12 And (System.Math.Abs(Rec.Tipo) = 8 Or System.Math.Abs(Rec.Tipo) = 9 Or System.Math.Abs(Rec.Tipo) = 26) Then
            Select Case Membrov.SottoTipo
                Case 7 'saldato lato cassa
                    ' If Mid$(cmbCodPos(1).Text, 6, 1) = "C" Then
                    InLineaMeno3()
                Case Else
                    InLineaPiu3()
            End Select
        Else
            '             Acttit% = 1: If Abs(Rec.Tipo) < 13 Then Acttit% = 2
            '             Call Selez(6, False, Acctit%)
        End If
    End Sub
    Private Sub GuarnizFla(ByVal Rec As clsGenMem, ByVal Recv As clsGenMem, ByVal Membrov As Membratura)
        If Len(RTrim(cmbCodPos(0).Text)) = 0 Then InLineaPiu()
        If System.Math.Abs(Recv.Tipo) = 12 Then 'guarnizioni su piastre
            cmbCodPos(3).Text = "=-"
            Select Case Membrov.SottoTipo
                Case 1, 2
                    NoPiasGuar(Rec)
                Case 3, 7 : cmbCodPos(3).Text = "=-"
                Case 4, 6
                    Piastra6a()
            End Select
        End If
        If System.Math.Abs(Recv.Tipo) = 11 Then 'guarnizioni su flangioni
            If Membrov.SottoTipo = 4 Then
                cmbCodPos(3).Text = "=-"
                Cmeno()
            End If
        End If
    End Sub
    Private Sub FonSuCil()
        If cmbCodPos(0).Text.Length > 0 Then
            If cmbCodPos(0).Text.Substring(0, 1) = "N" Then
                InLineaMeno1()
            Else
                InLineaPiu1()
            End If
        Else
            InLineaPiu1()
        End If
    End Sub
    Private Sub ForgSuCil()
        cmbCodPos(4).Text = "Auto"
    End Sub
    Private Sub SelSuCil()
        InLineaPiu1()
        cmbCodPos(1).Text = "-N"
    End Sub
    Private Sub DiafTub(ByVal Rec As clsGenMem)
        cmbCodPos(3).Text = "=+"
        TubiDir(Rec)
    End Sub
    Private Sub TubiDir(ByVal Rec As clsGenMem)
        Select Case Rec.Parent.SottoTipo
            Case 7
                Select Case cmbCodPos(1).Text.Substring(0, 2)
                    Case Is = "Ne" : cmbCodPos(3).Text = "=-"
                    Case Is = "Fa" : cmbCodPos(3).Text = "=+"
                End Select
            Case Else
                Select Case cmbCodPos(1).Text.Substring(0, 2)
                    Case Is = "Ne" : cmbCodPos(3).Text = "=+"
                    Case Is = "Fa" : cmbCodPos(3).Text = "=-"
                End Select
        End Select
    End Sub
    Private Sub SetStop(ByVal Rec As clsGenMem, ByVal Recv As clsGenMem)
        'If AddDistinta = 103 Then Return
        Dim Testo As String = HelpStringa(154) + Space$(1) + RTrim$(Rec.Denom) + HelpStringa(155) + Str$(Rec.Tipo)
        Testo = Testo + HelpStringa(156) + Space$(1) + RTrim$(Recv.Denom) + HelpStringa(155) + Str$(Recv.Tipo)
        Testo = Testo + HelpStringa(157) + Space$(1) + RTrim$(Rec.Denom) + HelpStringa(158)
        MsgBox(Inizio.ConvertiCr(Testo))
        Rec.posizione.SuChi = CType(Apparecchio.Elementi(0), Membratura)
    End Sub
    Private Sub AggPosSpaN(ByRef Rec As clsGenMem, ByRef Recv As clsGenMem)
        If Rec.posizione.Quota.Trim.Length = 0 Then Rec.posizione.Quota = "Ne"
        cmbCodPos(0).Text = Rec.posizione.Quota
        If Rec.posizione.Anomal.Trim.Length = 0 Then Rec.posizione.Anomal = "N."
        cmbCodPos(1).Text = Rec.posizione.Anomal
        If Rec.posizione.Raggio.Trim.Length = 0 Then Rec.posizione.Raggio = "N."
        cmbCodPos(2).Text = Rec.posizione.Raggio
        If Rec.posizione.DirDiritta.Trim.Length = 0 Then Rec.posizione.DirDiritta = "=+"
        cmbCodPos(3).Text = Rec.posizione.DirDiritta
        If Rec.posizione.DirTraversa.Trim.Length = 0 Then Rec.posizione.DirTraversa = "Au"
        cmbCodPos(4).Text = Rec.posizione.DirTraversa
    End Sub
    Private Sub Ridisegna()
        Dim j, ifl, jfin, jn As Short
        Dim Appar As New clsApparecchio
        Dim Ogg As Membratura
        If job Is Nothing Then Exit Sub
        If Not job.Comm Is Nothing Then If job.Comm.CalcBaric = 0 Then Exit Sub
        If IUNL > 4 Or NoRidisegna Then Exit Sub
        ' cmdOK.Enabled = False
        '  Librerie(0).Enabled = False
        If SelectedTipo Then
            SelectedTipo = False
            'txtPara(1).SetFocus '4-3-99 certe volte funziona con (0) e con 1 NO.
            Try
                txtPara(1).Focus()
            Catch
            End Try
        End If
        If Membro.GenMem.posizione.SuChi Is Nothing Then Exit Sub
        Appar.Add(Membro.GenMem.posizione.SuChi)
        Appar.Add(Membro)
        Dim n As OggList.NodeP = Apparecchio.Elementi.nodeHead.Next
        While Not n Is Nothing
            Ogg = CType(n.TextData, Membratura)
            If Ogg.GenMem.posizione.SuChi Is Membro Then
                Appar.Add(Ogg)
            End If
            n = n.Next
        End While
        AggCoordN(Membro.GenMem.posizione.SuChi.GenMem, Appar)
        If sezioni Is Nothing Then sezioni = New clsSezioni
        sezvec = sezioni.Clone
        LungPip = 1
        Funzioni.DisRut.DoveDisegno = Picture1
        Funzioni.DisRut.SH = 0
        Disegno(4, 1, Appar)
        If Not Monitor.Smetti Then Disegno(2, 1, Appar)
        Monitor.Smetti = False
        sezioni = sezvec
    End Sub
    Private Sub RegTxtPara(ByRef Index As Short)
        Dim Dum As Single
        Dim gGen As clsGenMem = Membro.GenMem
        Dim Valore As Single = GlobalRoutines.ValVir(txtPara(Index).Text)
        Select Case gGen.Tipo
            Case -1 '7-5-99 pezza rinforzo sella
                Select Case Index
                    Case 0
                        CType(Membro, Cilindro).Diametro = Valore
                    Case 1
                        CType(Membro, Cilindro).SpessBase = Valore
                    Case 2
                        CType(Membro, Cilindro).Lunghezza = Valore
                End Select
            Case 1, 2, -2
                Select Case Index
                    Case 0
                        CType(Membro, Cilindro).Diametro = Valore
                    Case 1
                        CType(Membro, Cilindro).SpessBase = Valore
                    Case 2
                        CType(Membro, Cilindro).Lunghezza = Valore
                    Case 3
                        If CType(Membro, Cilindro).TipoMat > 1 Then
                            CType(Membro, Cilindro).SpessRive = Valore
                        Else
                            CType(Membro, Cilindro).Randa = Valore
                        End If
                    Case 4
                        CType(Membro, Cilindro).Randa = Valore
                End Select
            Case 3
                Select Case Index
                    Case 0
                        CType(Membro, Fondo).Diametro = Valore
                    Case 1
                        CType(Membro, Fondo).SpessBase = Valore
                    Case 2
                        CType(Membro, Fondo).Piedritto = Valore
                    Case 3
                        If CType(Membro, Fondo).TipoMat > 1 Then
                            CType(Membro, Fondo).SpessRive = Valore
                        Else
                            CType(Membro, Fondo).kRapporto = Valore
                        End If
                    Case 4
                        CType(Membro, Fondo).kRapporto = Valore
                    Case 5
                        CType(Membro, Fondo).Dcal = Valore
                End Select
            Case 4
                Select Case Index
                    Case 0
                        CType(Membro, Fondo).Diametro = Valore
                    Case 1
                        CType(Membro, Fondo).SpessBase = Valore
                    Case 2
                        CType(Membro, Fondo).Piedritto = Valore
                    Case 3
                        CType(Membro, Fondo).SpessRive = Valore
                    Case 4
                        CType(Membro, Fondo).Dcal = Valore
                End Select
            Case 5
                Select Case Index
                    Case 0
                        CType(Membro, Fondo).Diametro = Valore
                    Case 1
                        CType(Membro, Fondo).SpessBase = Valore
                    Case 2
                        CType(Membro, Fondo).Piedritto = Valore
                    Case 3
                        CType(Membro, Fondo).SpessRive = Valore
                    Case 4
                        CType(Membro, Fondo).Dcal = Valore
                End Select
            Case 8, 9, 26, -8, -9
                Dim Tubi As Tubi
                Dim Fascio As Fascio
                Select Case gGen.Tipo
                    Case 8, 9 : Tubi = CType(Membro, Tubi)
                        Fascio = Nothing
                    Case -8, -9 : Tubi = CType(Membro, Tubi)
                        Fascio = Apparecchio.CercaFascio(Tubi)
                    Case 26
                        Tubi = CType(Membro, Fascio).Tubi_Renamed
                        Fascio = CType(Membro, Fascio)
                End Select
                Select Case Index
                    Case 0 : Tubi.DiamExt = Valore
                    Case 1 : Tubi.Spessore = Valore
                    Case 3 : Tubi.Lunghezza = Valore
                    Case 5 : Tubi.OTL = Valore
                    Case 6 : Tubi.NumeroTubi = CShort(Valore)
                End Select
                VariaFascio(Fascio)
            Case 6, 7
                Select Case Index
                    Case 0
                        CType(Membro, Cono).Dgran = Valore
                    Case 1
                        CType(Membro, Cono).RagG = Valore
                    Case 2
                        CType(Membro, Cono).PiedG = Valore
                    Case 3
                        CType(Membro, Cono).Dpicc = Valore
                    Case 4
                        CType(Membro, Cono).RagP = Valore
                    Case 5
                        CType(Membro, Cono).PiedP = Valore
                    Case 6
                        CType(Membro, Cono).SpessBase = Valore
                        If CType(Membro, Cono).Fitting Then
                            CType(Membro, Cono).RagG = 3 * CType(Membro, Cono).SpessBase
                            CType(Membro, Cono).RagP = CType(Membro, Cono).RagG
                            CType(Membro, Cono).PiedG = CType(Membro, Cono).RagG
                            CType(Membro, Cono).PiedP = CType(Membro, Cono).PiedG
                        End If
                    Case 7
                        If CType(Membro, Cono).Fitting Then
                            CType(Membro, Cono).Altezza = Valore
                            CType(Membro, Cono).AlfaCon = 0
                            CType(Membro, Cono).Calcoli0()
                        Else
                            CType(Membro, Cono).AlfaCon = Valore
                            CType(Membro, Cono).Altezza = 0
                            CType(Membro, Cono).Calcoli0()
                            Try
                                If gGen.Tipo = 7 Then txtPara(8).Text = GlobalRoutines.myStr(CType(Membro, Cono).Altezza, 5, 0, 0)
                            Catch
                            End Try
                        End If
                    Case 8
                        If CType(Membro, Cono).Fitting Then
                            CType(Membro, Cono).SpessRive = Valore
                        ElseIf gGen.Tipo = 7 Then
                            If Valore > 0 Then
                                CType(Membro, Cono).Altezza = Valore
                                CType(Membro, Cono).AlfaCon = 0
                                CType(Membro, Cono).Calcoli0()
                                txtPara(7).Text = GlobalRoutines.myStr(CType(Membro, Cono).AlfaCon, 3, 2, 0)
                            End If
                        Else
                            CType(Membro, Cono).SpessRive = Valore
                        End If
                    Case 9
                        CType(Membro, Cono).SpessRive = Valore
                End Select
            Case 10, -10
                Select Case Index
                    Case 1
                        CType(Membro, clsBocch).DiamInt = Valore
                        CType(Membro, clsBocch).SetTronchetto()
                    Case 2
                        CType(Membro, clsBocch).Sporgenza = Valore
                        If CType(Membro, clsBocch).SetTronchetto Then SuperPosN()
                    Case 3
                        CType(Membro, clsBocch).Randa = Valore
                    Case 4
                        Select Case CType(Membro, clsBocch).TipoF
                            Case 1
                                CType(Membro, clsBocch).DiamScarpa = Valore
                            Case 2
                                CType(Membro, clsBocch).DiamRinf = Valore
                            Case 3
                                If CType(Membro, clsBocch).Pad Is Nothing Then CType(Membro, clsBocch).CercaPadAppeso()
                                CType(Membro, clsBocch).Pad.DiamExt = Valore
                                CType(Membro, clsBocch).SetPad()
                        End Select
                    Case 5
                        Select Case CType(Membro, clsBocch).TipoF
                            Case 1
                                CType(Membro, clsBocch).SpesScarpa = Valore
                            Case 2
                                CType(Membro, clsBocch).AltzRinf = Valore
                            Case 3
                                If CType(Membro, clsBocch).Pad Is Nothing Then CType(Membro, clsBocch).CercaPadAppeso()
                                CType(Membro, clsBocch).Pad.Spess = Valore
                                CType(Membro, clsBocch).SetPad()
                        End Select
                End Select
            Case 11
                Select Case Index
                    Case 0
                        CType(Membro, Flangione).DiamExt = Valore
                    Case 1
                        CType(Membro, Flangione).DiamInt = Valore
                    Case 2
                        CType(Membro, Flangione).SpessBase = Valore
                    Case 3
                        CType(Membro, Flangione).DiamGra = Valore
                    Case 4
                        CType(Membro, Flangione).SpessGra = Valore
                    Case 5
                        CType(Membro, Flangione).g0 = Valore
                    Case 6
                        CType(Membro, Flangione).g1 = Valore
                    Case 7
                        CType(Membro, Flangione).H = Valore
                    Case 13
                        CType(Membro, Flangione).SpessRive = Valore
                End Select
                If CType(Membro, Flangione).SottoTipo = 4 Then
                    Select Case Index
                        Case 8
                            CType(Membro, Flangione).DiamGra2 = Valore
                        Case 9
                            CType(Membro, Flangione).SpessGra2 = Valore
                        Case 10
                            CType(Membro, Flangione).g02 = Valore
                        Case 11
                            CType(Membro, Flangione).g12 = Valore
                        Case 12
                            CType(Membro, Flangione).H2 = Valore
                    End Select
                Else
                    If Index = 8 Then CType(Membro, Flangione).SpessRive = Valore
                End If
            Case 12
                With CType(Membro, Piastrone)
                    Select Case Index
                        Case 0
                            .DiamExt = Valore
                        Case 1
                            .SpessBase = Valore
                        Case 2
                            Select Case .SottoTipo
                                Case 1, 2
                                    .H1 = Valore
                                Case 3, 4, 5, 6, 7
                                    .B1 = Valore
                            End Select
                        Case 3
                            Select Case .SottoTipo
                                Case 1, 2
                                    .B1 = Valore
                                Case 3, 4, 5, 6, 7
                                    .H1 = Valore
                            End Select
                        Case 4
                            Select Case .SottoTipo
                                Case 1, 2, 3, 7
                                    .H2 = Valore
                                Case 4, 5, 6
                                    .B2 = Valore
                            End Select
                        Case 5
                            Select Case .SottoTipo
                                Case 1, 2, 3, 7
                                    .B2 = Valore
                                Case 4, 5, 6
                                    .H2 = Valore
                            End Select
                        Case 6
                            Select Case .SottoTipo
                                Case 1, 4, 5, 6
                                    .LargCava = Valore
                                Case 2, 3, 7
                                    .B3 = Valore
                            End Select
                        Case 7
                            Select Case .SottoTipo
                                Case 1, 4, 5, 6
                                    .ProfCava = Valore
                                Case 2, 3, 7
                                    .H3 = Valore
                            End Select
                        Case 8
                            Select Case .SottoTipo
                                Case 1, 4, 5, 6
                                    If .TipoMat > 1 Then
                                        .SpessRive = Valore
                                    Else
                                        .AG = Valore
                                    End If
                                Case 2
                                    .LargCava = Valore
                                Case 3, 7
                                    .B4 = Valore
                            End Select
                        Case 9
                            Select Case .SottoTipo
                                Case 1, 4, 5, 6
                                    If .TipoMat > 1 Then
                                        .AG = Valore
                                    Else
                                        .TG = Valore
                                    End If
                                Case 2
                                    .ProfCava = Valore
                                Case 3, 7
                                    .H4 = Valore
                            End Select
                        Case 10
                            Select Case .SottoTipo
                                Case 1, 4, 5, 6
                                    If .TipoMat > 1 Then
                                        .TG = Valore
                                    End If
                                Case 2
                                    If .TipoMat > 1 Then
                                        .SpessRive = Valore
                                    Else
                                        .AG = Valore
                                    End If
                                Case 3, 7
                                    .LargCava = Valore
                            End Select
                        Case 11
                            Select Case .SottoTipo
                                Case 2
                                    If .TipoMat > 1 Then
                                        .AG = Valore
                                    Else
                                        .TG = Valore
                                    End If
                                Case 3, 7
                                    .ProfCava = Valore
                            End Select
                        Case 12
                            Select Case .SottoTipo
                                Case 2
                                    If .TipoMat > 1 Then
                                        .TG = Valore
                                    End If
                                Case 3, 7
                                    If .TipoMat > 1 Then
                                        .SpessRive = Valore
                                    Else
                                        .AG = Valore
                                    End If
                            End Select
                        Case 13
                            Select Case .SottoTipo
                                Case 3, 7
                                    If .TipoMat > 1 Then
                                        .AG = Valore
                                    Else
                                        .TG = Valore
                                    End If
                            End Select
                        Case 14
                            Select Case .SottoTipo
                                Case 3, 7
                                    If .TipoMat > 1 Then
                                        .TG = Valore
                                    End If
                            End Select
                    End Select
                    If .SottoTipo = 5 Or .SottoTipo = 6 Then
                        If .B1 < .B2 Then
                            Dum = .B1
                            .B1 = .B2
                            .B2 = Dum
                            Dum = .H1
                            .H1 = .H2
                            .H2 = Dum
                        End If
                    End If
                End With
            Case 13, -13
                Select Case Index
                    Case 2
                        CType(Membro, clsTirante).Lunghezza = Valore
                    Case 3
                        CType(Membro, clsTirante).DiamScar = Valore
                    Case 4
                        CType(Membro, clsTirante).LunScar = Valore
                    Case 5
                        CType(Membro, clsTirante).nDadi = CShort(Valore)
                    Case 6
                        CType(Membro, clsTirante).Dinst = Valore
                End Select
            Case 17, -17
                Select Case Index
                    Case 0
                        CType(Membro, Anello).DiamExt = Valore
                    Case 1
                        CType(Membro, Anello).DiamInt = Valore
                    Case 2
                        CType(Membro, Anello).Spess = Valore
                    Case 3
                        CType(Membro, Anello).Dmant = Valore
                End Select
            Case 15, -15
                Select Case Index
                    Case 0
                        CType(Membro, Striscia).Lunghezza = Valore
                    Case 1
                        CType(Membro, Striscia).Larghezza = Valore
                    Case 2
                        CType(Membro, Striscia).Spessore = Valore
                End Select
            Case 23, -23
                Select Case Index
                    Case 0
                        CType(Membro, Tondo).Lunghezza = Valore
                    Case 1
                        CType(Membro, Tondo).Diametro = Valore
                End Select
            Case 14
                CType(Membro, clsNonStd).Registra(Index)
            Case 16
                CType(Membro, CalDisc).Registra(Index)
            Case 18
                CType(Membro, Dilat).Registra(Index)
            Case 25
                CType(Membro, Sella).Registra(Index)
            Case 21
                Select Case Index
                    Case 0
                        CType(Membro, Curva).Diametro = Valore
                    Case 1
                        CType(Membro, Curva).SpessBase = Valore
                    Case 2
                        CType(Membro, Curva).Apertura = Valore
                    Case 3
                        CType(Membro, Curva).Raggio = Valore
                    Case 4
                        CType(Membro, Curva).Numero = CShort(Valore)
                End Select
            Case 19, -19
                Select Case Index
                    Case 0
                        CType(Membro, Diaframma).DiamExt = Valore
                    Case 4
                        CType(Membro, Diaframma).Spessore = Valore
                    Case 5
                        CType(Membro, Diaframma).Passo = Valore
                    Case 6
                        CType(Membro, Diaframma).Passo1 = Valore
                    Case 7
                        CType(Membro, Diaframma).Percento = Valore
                    Case 8
                        If gGen.Tipo < 0 Then
                            CType(Membro, Diaframma).NumDiafr = CShort(Valore)
                            CType(Membro, Diaframma).NumTipoA = CShort(CType(Membro, Diaframma).NumDiafr \ 2)
                            CType(Membro, Diaframma).NumTipoB = CType(Membro, Diaframma).NumDiafr - CType(Membro, Diaframma).NumTipoA
                        Else
                            CType(Membro, Diaframma).NumTipoA = CShort(Valore)
                        End If
                    Case 9
                        CType(Membro, Diaframma).NumTipoB = CShort(Valore)
                    Case 10
                        CType(Membro, Diaframma).NumFori = CShort(Valore)
                    Case 11
                        CType(Membro, Diaframma).Diamfori = Valore
                End Select
            Case 28, -28
                With CType(Membro, clsGuarniz)
                    Select Case Index
                        Case 2
                            .DiamMed = Valore
                        Case 3
                            .Largh = Valore
                        Case 4
                            .Spess = Valore
                        Case 5
                            .LarghExt = Valore
                        Case 6
                            .LarghInt = Valore
                        Case 7
                            .SpessAn = Valore
                    End Select
                End With
            Case 34
                With CType(Membro, Cilindro)
                    Select Case Index
                        Case 0
                            .Diametro = Valore
                        Case 1
                            .SpessBase = Valore
                        Case 2
                            .Lunghezza = Valore
                        Case 3
                            .SpessRive = Valore
                        Case 4
                            .AngTegola = Valore
                    End Select
                End With
            Case 31, -31
                With CType(Membro, Raggrupp)
                    Select Case Index
                        Case 0
                            .Spessore = Valore
                        Case 1
                            .Lunghezza = Valore
                        Case 2
                            .Larghezza = Valore
                        Case 3
                            .Numero = CShort(Valore)
                    End Select
                End With
            Case 32, 33, -32, -33
                With CType(Membro, Raggrupp)
                    Select Case Index
                        Case 0
                            .DiamExt = Valore
                        Case 1
                            .Lunghezza = Valore
                        Case 2
                            .Numero = CShort(Valore)
                    End Select
                End With
            Case 37
                Select Case Index
                    Case 0
                        CType(Membro, Raggrupp).Spessore = Valore
                End Select
            Case Else
                'If gGen.Tipo = -1 Then '7-5-99
                MsgBox("Tipo non catalogato  : " & gGen.Tipo & " ?")
                Exit Sub
                'End If
        End Select

    End Sub
    Private Sub Attiva()
        Dim i, Unit As Short
        Dim gGen As clsGenMem
        Dim vis As Boolean
        Try
            gGen = Membro.GenMem
            Text = "Membratura: " & gGen.Denom
            vList = -1
            If IUNL < 6 Then
                txtMat(0).Text = gGen.Materiale
            End If
            If IUNL >= 5 Then
                _lblMat_0.Visible = False : _txtMat_0.Visible = False : _cmdMat_0.Visible = False
                If jRec > 0 Then
                    lblDen.Visible = False : txtDen.Visible = False
                End If
            End If
            Select Case gGen.Tipo
                Case 3, 4, 5, 17
                    cmdSvil.Visible = True
                Case 6, 7
                    If Not CType(Membro, Cono).Fitting Then cmdSvil.Visible = True
                Case 26
                    Frame8.Visible = True
                    Frame2.Visible = False
            End Select
            For i = 0 To 14 : txtPsp(i).Enabled = False : Next
            If Not frmMadre Is Nothing Then Posiziona(frmMadre, Me)
            MembroLeggi(Membro, Inizio.DiscoRam, 0)
            GeomPara()
            AggSuChi()
            Ridisegna()
            '---------------------------------------------------
            If gGen.Tipo < 0 Then Secondaria(True)
            '   Ridisegna
            CamTxtPara = False '7-5-99
            If Not job Is Nothing Then
                If Not job.Comm Is Nothing Then
                    If job.Comm.CalcBaric = 0 Then
                        cmdZoom.Visible = False
                        Frame4.Visible = False
                        Picture1.Visible = False
                        FramePict.Width = CInt(GlobalRoutines.TwipsToPixelsX(3525))
                        Width = FramePict.Left + FramePict.Width
                    End If
                End If
            End If
            RiempCmbLE()
            Unit = gGen.Unit
            AggUnit(Unit)
            gGen.Unit = Unit
            If IUNL < 6 Then
                gGen = gGen
                If AccordoDS(gGen) Then
                    If gGen.Tipo = 26 Then
                        If Not CType(Membro, Fascio).Tubi_Renamed Is Nothing Then
                            CType(Membro, Fascio).Tubi_Renamed.GenMem.LeggiMat(CType(Membro, Fascio).Tubi_Renamed.TipoMat)
                        End If
                    Else
                        gGen.LeggiMat(gGen.Parent.TipoMat)
                        Membro.StringMATE()
                        txtMat(0).Text = gGen.Materiale
                    End If
                End If
            End If
            If gGen.Lato < 0 Or gGen.Lato > 4 Then gGen.Lato = 0
            cmbLato.SelectedIndex = gGen.Lato
            If Not gGen.posizione.SuChi Is Nothing Then
                vis = (gGen.Tipo = 1) And Not (gGen.posizione.SuChi.GenMem.Tipo = 0)
            Else
                vis = False
            End If
            lblFinoA.Visible = vis
            cmbFinoA.Visible = vis
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Private Sub Secondaria(ByRef l As Boolean)
        Dim i As Short
        cmbSuChi.Visible = Not l
        Label2.Visible = l
        For i = 0 To 4
            lstCodPos(i).Visible = Not l
        Next
        _lblSuChi_0.Visible = Not l
        _lblSuChi_1.Visible = Not l
        _lblSuChi_2.Visible = Not l
        _lblSuChi_3.Visible = Not l
        _lblSuChi_4.Visible = Not l
        If l Then
            Dim gGen As clsGenMem = Membro.GenMem
            If gGen.Lato = 0 Then
                Dim gGenP As clsGenMem = gGen.posizione.SuChi.GenMem
                gGen.Lato = gGenP.Lato
            End If
        End If
    End Sub
    Private Sub RiempCmbLE()
        Dim Table As New DataTable
        Dim Tipo As Short
        Dim i As Short
        Dim Campo As String
        Dim agg As Boolean
        Dim FileMate As String
        If IUNL = 6 Then Exit Sub
        FileMate = Monitor.Motore.MatFile
        If Len(FileMate) = 0 Then
            MsgBox("Database materiali non trovato")
            Exit Sub
        End If
        Try
            db = New OleDbConnection(Conn & FileMate & ConnFine)
            cmddb = New OleDbDataAdapter("SELECT * FROM LavorEst ORDER BY Codice", db)
            Table = New DataTable
            cmddb.Fill(Table) '= db.OpenRecordset("SELECT * FROM LavorEst ORDER BY Codice")
            Dim dvTable As DataView = New DataView(Table)
            Tipo = System.Math.Abs(Membro.GenMem.Tipo)
            If (Tipo = 6 Or Tipo = 7) Then
                If CType(Membro, Cono).Fitting Then Tipo = CShort(Tipo + 40)
            End If
            cmbLE.Visible = True
            _lblPsp_14.Visible = True
            cmbLE.Items.Clear()
            lstLE.Items.Clear()
            Select Case Tipo
                Case 0
                    cmbLE.Visible = False
                    _lblPsp_14.Visible = False
                Case Else
                    Dim Filtro As String = ""
                    For i = 3 To CShort(Table.Columns.Count - 2)
                        Campo = Table.Columns(i).Caption
                        Filtro = Filtro & Campo & "=" & Str(Tipo) & " OR " & Campo & "=999" & " OR "
                    Next
                    Campo = Table.Columns(Table.Columns.Count - 1).Caption
                    Filtro = Filtro & Campo & "=" & Str(Tipo) & " OR " & Campo & "=999"
                    dvTable.RowFilter = Filtro
                    Dim ii As Integer
                    For ii = 0 To dvTable.Count - 1
                        agg = True
                        For i = 3 To CShort(Table.Columns.Count - 1)
                            If Not IsDBNull(dvTable(ii)(i)) Then
                                If CShort(dvTable(ii)(i)) = -Tipo Then
                                    agg = False
                                    Exit For
                                End If
                            End If
                        Next
                        If agg Then
                            lstLE.Items.Add(dvTable(ii)("Codice"))
                            cmbLE.Items.Add(dvTable(ii)("Descrizione"))
                        End If
                    Next
            End Select
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        Finally
            Table.Dispose()
            db.Dispose()
        End Try
        AggiornaCmbLE()
    End Sub
    Private Sub AggiornaCmbLE()
        Dim i As Short
        If cmbLE.Items.Count = 0 Then
            'MsgBox "cmbLE 0"
            Exit Sub
        End If
        For i = 0 To CShort(cmbLE.Items.Count - 1)
            If CStr(lstLE.Items(i)) = Membro.GenMem.MF Then
                cmbLE.SelectedIndex = i
                Exit Sub
            End If
        Next
        cmbLE.SelectedIndex = 0
    End Sub
    Private Sub VediLordi(ByRef vedi As Boolean)
        _lblPsp_7.Visible = vedi
        _lblPsp_8.Visible = vedi
        _lblPsp_12.Visible = vedi
        txtPsp(6).Visible = vedi
        txtPsp(7).Visible = vedi And Membro.GenMem.IndMat2 > 0
        txtPsp(8).Visible = vedi And Membro.GenMem.IndMat3 > 0
        txtPsp(13).Visible = vedi
    End Sub
    Public Sub AggTxtPsp14()
        Dim p As Single
        If Inizializzando Then Exit Sub
        p = Membro.GenMem.LireTot
        If p > 1000000.0 Then
            _lblPsp_13.Text = "Costo (kEUR)"
            txtPsp(14).Text = GlobalRoutines.FormatS("######", p / 1000.0)
        Else
            _lblPsp_13.Text = "Costo (EUR)"
            txtPsp(14).Text = GlobalRoutines.FormatS("######", p)
        End If
    End Sub
    Private Sub AggiornaPara(ByRef Index As Short)
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        RegTxtPara(Index)
        SuperAggiorna()
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
    End Sub
    Public Sub SuperAggiorna()
        Try
            MembroLeggi(Membro, Inizio.DiscoRam, 0)
            Exit Sub
            GeomPara()
            txtDes.Text = Membro.GenMem.Dimensioni
            Ridisegna()
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Private Sub VariaFascio(ByRef Fascio As Fascio)
        If Fascio Is Nothing Then Exit Sub
        If InTesti Then Exit Sub
        With Fascio
            If Len(Trim(.FileTrac)) < 2 Then Exit Sub
            If UCase(.FileTrac.Substring(0, 2)) = "AS" Then Exit Sub 'assente
            File = FunzLibgra.FileDes("INP") 'Trim(Inizio.Workdir) + "\" + job.Comm.Arch + "\" + job.Comm.Ind(job.Comm.indice).File + ".INP"
            If .LayOut Is Nothing Then
                .LayOut = New traccia.clsTracciatura
                .LayOut.DoveMotore = Motore
                .LayOut.DoveRoutines = Funzioni.DisRut
                Funzioni.DisRut.Init200((Inizio.Archdir))
            End If
            .Genera(File)
            .LayOut.Esegui(3, File)
            .LayOut.SuperRMT(Fascio.Tubi_Renamed.GenMem.MaterNome(1), _
                             Fascio.Tubi_Renamed.GenMem.PesoSp1, True)
            '.LayOut.Scrivi() inutile: già fatto prima
        End With
    End Sub

    Private Sub AggUnit(ByRef Unit As Short)
        If Not (Unit = 1 Or Unit = 2) Then Unit = 1 : Exit Sub
        If Unit = 1 Then
            _lblPsp_7.Text = "Peso lordo"
            _lblPsp_8.Text = "Kg"
        Else
            _lblPsp_7.Text = "Lung.lorda"
            _lblPsp_8.Text = "m"
        End If
    End Sub

    Private Sub PosizMemb(ByRef SuChiVec As Short, ByRef cmb As System.Windows.Forms.ComboBox, ByRef lst As System.Windows.Forms.ListBox, ByRef Modo As Short)
        Dim i, j As Short
        Dim TipoSottoS As String = ""
        Dim TipoSopraS As String = ""
        Dim TipoSottoM As String = ""
        Dim TipoSopraM As String = ""
        Dim TipoVS As String = ""
        Dim Testo As String = ""
        Dim SQL As String = ""
        Dim jPred As Short
        If Not cmb.Enabled Then Exit Sub
        AltroClick = True
        Label3.Visible = False
        If Not InTesti Then Membro.Variato = True
        If cmb.SelectedIndex > -1 Then i = CShort(Val(CStr(lst.Items(cmb.SelectedIndex)))) Else i = 1
        If i = 0 Then Exit Sub
        Try
            Select Case Modo
                Case 1
                    Membro.GenMem.posizione.SuChi = CType(Apparecchio.Elementi(i - 1), Membratura)
                    TipoSottoS = CType(Membro.GenMem.posizione.SuChi.GenMem, clsGenMem).Tipo.ToString
                Case 2
                    Membro.GenMem.posizione.ForoSecondario = CType(Apparecchio.Elementi(i - 1), Membratura)
                    TipoSottoS = CType(Membro.GenMem.posizione.ForoSecondario.GenMem, clsGenMem).Tipo.ToString
            End Select
            TipoSopraS = Membro.GenMem.Tipo.ToString
            If System.Math.Abs(Val(TipoSottoS)) = 11 Or System.Math.Abs(Val(TipoSottoS)) = 12 Then
                SQLStd(SQL, TipoSopraS, TipoSottoS)
                If MyTable.Rows.Count = 0 Then
                    TipoSottoM = "-" + TipoSottoS
                    Select Case Modo
                        Case 1
                            If Membro.GenMem.posizione.SuChi.SottoTipo = 0 Then Membro.GenMem.posizione.SuChi.SottoTipo = 1
                            TipoVS = Str(Membro.GenMem.posizione.SuChi.SottoTipo)
                        Case 2
                            If Membro.GenMem.posizione.ForoSecondario.SottoTipo = 0 Then Membro.GenMem.posizione.ForoSecondario.SottoTipo = 1
                            TipoVS = Str(Membro.GenMem.posizione.ForoSecondario.SottoTipo)
                    End Select
                    SQL1(SQL, TipoSopraS, TipoSottoS, TipoSottoM, TipoVS)
                End If
            ElseIf System.Math.Abs(Val(TipoSopraS)) = 11 Or System.Math.Abs(Val(TipoSopraS)) = 12 Then
                SQLStd(SQL, TipoSopraS, TipoSottoS)
                If MyTable.Rows.Count = 0 Then
                    TipoSopraM = "-" + TipoSopraS
                    If Membro.SottoTipo = 0 Then Membro.SottoTipo = 1
                    TipoVS = Str(Membro.SottoTipo)
                    SQL2(SQL, TipoSopraS, TipoSottoS, TipoSopraM, TipoVS)
                End If
            Else
                SQLStd(SQL, TipoSopraS, TipoSottoS)
            End If
            'On Error Resume Next '6-5-99
            If Not MyTable.Rows.Count = 1 Then
                Testo = "Errore di unicità" & vbCrLf
                Testo = Testo & "RecordCount=" & Str(MyTable.Rows.Count) & vbCrLf
                Testo = Testo & "sopra:" + Membro.GenMem.Denom + " " + TipoSopraS + " " + TipoSopraM + vbCrLf
                Select Case Modo
                    Case 1
                        Testo = Testo & "sotto:" + CType(Membro.GenMem.posizione.SuChi.GenMem, clsGenMem).Denom + " " + TipoSottoS + " " + TipoSottoM + vbCrLf
                    Case 2
                        Testo = Testo & "sotto:" + CType(Membro.GenMem.posizione.ForoSecondario.GenMem, clsGenMem).Denom + " " + TipoSottoS + " " + TipoSottoM + vbCrLf
                End Select
                TipoVS = Testo & "sottotipo: " & TipoVS
                MsgBox(Testo)
                Exit Sub
            End If
            Select Case Modo
                Case 1
                    For i = 0 To 4
                        lblSuchi(CShort(i)).Visible = CBool(MyTable.Rows(0)(i))
                        lstCodPos(i).Visible = CBool(MyTable.Rows(0)(i))
                    Next
                    Select Case CStr(MyTable.Rows(0)("TabValori")).Substring(0, 3)
                        Case "Imp"
                            ' MsgBox("Collegamento impossibile")
                            Label3.Visible = True
                            Exit Sub
                        Case "Nul"
                            GenMemInText()
                            SuperPosN()
                            'setcoord +testo in genmem + aggiorna(calcolo)
                            Exit Sub
                        Case Else
                            If (Val(TipoSottoS) = 6 Or Val(TipoSottoS) = 7) And Val(TipoSopraS) = 10 Then
                                If CType(Membro.GenMem.posizione.SuChi, Cono).Fitting Then
                                    MsgBox("Collegamento impossibile")
                                    Label3.Visible = True
                                    Exit Sub
                                End If
                            End If
                    End Select
                Case 2
                    Select Case CStr(MyTable.Rows(0)("TabValori")).Substring(0, 3)
                        Case "Nul"
                        Case Else
                            MsgBox("Collegamento impossibile")
                            cmbFinoA.SelectedIndex = 0
                    End Select
                    Exit Sub
            End Select
            Dim lcmd As New OleDbDataAdapter("SELECT * FROM " & CStr(MyTable.Rows(0)("TabValori")), MyDatabase)
            MyTable = New DataTable
            lcmd.Fill(MyTable)
            For i = 1 To 9 Step 2
                lblSuchi(CShort(i \ 2)).Text = MyTable.Columns(i).Caption
                cmbCodPos(i \ 2).Items.Clear() : lstCodPos(i \ 2).Items.Clear()
            Next
            ReDim Predefiniti(10, 5)
            Dim Pos As String = CStr(cmb.SelectedItem)
            i = CShort(Pos.IndexOf("|"))
            Pos = Pos.Substring(i + 1).Trim
            AggPosSpaN(Membro.GenMem, CType(Apparecchio.Elementi(Pos), Membratura).GenMem)
            lblPredef.Visible = False
            cmbPredef.Visible = False
            cmbPredef.Items.Clear()
            For i = 0 To CShort(MyTable.Rows.Count - 1)
                If Not IsDBNull(MyTable.Rows(i)(1)) Then
                    If CStr(MyTable.Rows(i)(1)).ToUpper = "FINE" Then
                        AddHlp(i)
                    ElseIf CStr(MyTable.Rows(i)(1)).Substring(0, 1) = "+" Then
                        AddPredef(i, jPred)
                    Else
                        AddCtl(i)
                    End If
                Else
                    AddCtl(i)
                End If
            Next
            If jPred = 0 Then AddPrecedente(jPred)
            NoRidisegna = False
            'If Caricamento Then cmbPredef.Enabled = False
            cmbPredef.Enabled = False
            If Not Editing Then
                cmbPredef.SelectedIndex = cmbPredef.Items.Count - 1
            Else
                cmbPredef.SelectedIndex = 0
            End If
            cmbPredef.Enabled = True
            SuperPosN(True)
            If SuChiVec <> cmb.SelectedIndex Then Ridisegna() '7-5-99
            SuChiVec = CShort(cmb.SelectedIndex) '7-5-99
            If (System.Math.Abs(Val(TipoSopraS)) = 1 Or System.Math.Abs(Val(TipoSopraS)) = 2) And Val(TipoSottoS) > 0 And Val(TipoSottoS) < 6 Then
                cmb.Enabled = False
                Ammazza()
                GeomPara()
                cmb.Enabled = True
            End If
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Private Sub AddCtl(ByVal i As Short)
        Dim j As Short
        For j = 1 To 9 Step 2
            If Not (IsDBNull(MyTable.Rows(i)(j)) Or IsDBNull(MyTable.Rows(i)(j + 1))) Then
                If CStr(MyTable.Rows(i)(j + 1)).Trim.Length > 0 Then
                    cmbCodPos(j \ 2).Items.Add(MyTable.Rows(i)(j))
                    lstCodPos(j \ 2).Items.Add(MyTable.Rows(i)(j + 1)) 'invertito con quelllo di sopra
                End If
            End If
        Next
    End Sub
    Private Sub AddPrecedente(ByRef jPred As Short)
        Dim i As Short
        lblPredef.Visible = True
        cmbPredef.Visible = True
        cmbPredef.Items.Add("Precedente")
        jPred = CShort(jPred + 1)
        For i = 0 To 4
            Predefiniti(jPred, i + 1) = cmbCodPos(i).Text
        Next
    End Sub
    Private Sub AddPredef(ByVal i As Short, ByRef jPred As Short)
        Dim j As Integer
        If jPred > 0 Then AddPrecedente(jPred)
        cmbPredef.Items.Add(CStr(MyTable.Rows(i)(1)).Substring(CStr(MyTable.Rows(i)(1)).Length - 2))
        jPred = CShort(jPred + 1)
        For j = 2 To 10 Step 2
            If Not IsDBNull(MyTable.Rows(i)(j)) Then Predefiniti(jPred, CInt(j / 2)) = CStr(MyTable.Rows(i)(j))
        Next
    End Sub
    Private Sub AddHlp(ByVal i As Short)
        Dim j As Short
        For j = 1 To 9 Step 2
            If Not IsDBNull(MyTable.Rows(i)(j + 1)) Then
                ToolTip1.SetToolTip(lblSuchi(CShort(j \ 2)), CStr(MyTable.Rows(i)(j + 1)))
            End If
        Next
    End Sub
    Private Sub SQLStd(ByVal SQL As String, ByVal TipoSopraS As String, ByVal TipoSottoS As String)
        TipoSottoS = Math.Abs(Val(TipoSottoS)).ToString
        TipoSopraS = Math.Abs(Val(TipoSopraS)).ToString
        SQL = "SELECT Quota, Raggio, Anomal, DirDiritta, DirTraversa, TabValori, ID FROM CrossTable WHERE "
        SQL = SQL & "(T1>-1 And S1>-1) And "
        SQL = SQL & "(T1 =" & TipoSottoS & " Or T2 ="
        SQL = SQL & TipoSottoS & " Or T3 ="
        SQL = SQL & TipoSottoS & " Or T4 ="
        SQL = SQL & TipoSottoS & " Or T5 =" & TipoSottoS & ") "
        SQL = SQL & "And (S1 = " & TipoSopraS
        SQL = SQL & " Or S2 =" & TipoSopraS
        SQL = SQL & " Or S3 =" & TipoSopraS
        SQL = SQL & " Or S4 =" & TipoSopraS
        SQL = SQL & " Or S5 =" & TipoSopraS & ");"
        cmd = New OleDbDataAdapter(SQL, MyDatabase)
        MyTable = New DataTable
        cmd.Fill(MyTable)
    End Sub
    Private Sub SQL1(ByVal SQL As String, ByVal TipoSopraS As String, ByVal TipoSottoS As String, ByVal TipoSottoM As String, ByVal TipoVS As String)
        SQL = "SELECT Quota, Raggio, Anomal, DirDiritta, DirTraversa, TabValori, ID FROM CrossTable WHERE "
        SQL = SQL & "(T1 =" & TipoSottoM & " And (T2 ="
        SQL = SQL & TipoVS & " Or T3 ="
        SQL = SQL & TipoVS & " Or T4 ="
        SQL = SQL & TipoVS & " Or T5 =" & TipoSottoS & ")) "
        SQL = SQL & "And (S1 = " & TipoSopraS
        SQL = SQL & " Or S2 =" & TipoSopraS
        SQL = SQL & " Or S3 =" & TipoSopraS
        SQL = SQL & " Or S4 =" & TipoSopraS
        SQL = SQL & " Or S5 =" & TipoSopraS & ");"
        cmd = New OleDbDataAdapter(SQL, MyDatabase)
        MyTable = New DataTable
        cmd.Fill(MyTable)
        If MyTable.Rows.Count < 1 Then SQLStd(SQL, TipoSopraS, TipoSottoS)
    End Sub
    Private Sub SQL2(ByVal SQL As String, ByVal TipoSopraS As String, ByVal TipoSottoS As String, ByVal TipoSopraM As String, ByVal TipoVS As String)
        SQL = "SELECT Quota, Raggio, Anomal, DirDiritta, DirTraversa, TabValori, ID FROM CrossTable WHERE "
        SQL = SQL & "(T1 =" & TipoSottoS & " Or T2 ="
        SQL = SQL & TipoSottoS & " Or T3 ="
        SQL = SQL & TipoSottoS & " Or T4 ="
        SQL = SQL & TipoSottoS & " Or T5 =" & TipoSottoS & ") "
        SQL = SQL & "And (S1 = " & TipoSopraM
        SQL = SQL & " And (S2 =" & TipoVS
        SQL = SQL & " Or S3 =" & TipoVS
        SQL = SQL & " Or S4 =" & TipoVS
        SQL = SQL & " Or S5 =" & TipoVS & "));"
        cmd = New OleDbDataAdapter(SQL, MyDatabase)
        MyTable = New DataTable
        cmd.Fill(MyTable)
        If MyTable.Rows.Count < 1 Then SQLStd(SQL, TipoSopraS, TipoSottoS)
    End Sub
    Private Sub CalcolaLunghezza()
        Dim RecA, RecB As clsGenMem
        Dim Base As Single
        Dim Rec As clsGenMem
        Dim Lungh As Single
        Select Case cmbFinoA.SelectedIndex
            Case 0
                txtPara(2).BackColor = System.Drawing.Color.White
                txtPara(2).Enabled = True
                Exit Sub
            Case Else
                txtPara(2).BackColor = System.Drawing.Color.Yellow
                txtPara(2).Enabled = False
        End Select
        Rec = Membro.GenMem
        RecA = CType(Rec.posizione.SuChi.GenMem, clsGenMem)
        RecB = CType(Rec.posizione.ForoSecondario.GenMem, clsGenMem)
        If System.Math.Abs(1 - System.Math.Abs(RecA.posizione.CosDiritta.ProdScalar((RecB.posizione.CosDiritta)))) > 0.001 Then
            MsgBox("la membratura di inzio e quella di fine non sono parallele")
            cmbFinoA.SelectedIndex = 0
            Exit Sub
        End If
        Base = RecA.posizione.CosDiritta.ProdScalar((RecB.posizione.Origine)) - RecA.posizione.CosDiritta.ProdScalar((RecA.posizione.Origine))
        Lungh = Base - (Rec.posizione.CosDiritta.ProdScalar((Rec.posizione.Origine)) - Rec.posizione.CosDiritta.ProdScalar((RecA.posizione.Origine)))
        Select Case RecB.Tipo
            Case 11 'flangioni
                GoTo Incompleto
            Case 12 'piastroni
                Select Case CType(RecB.Parent, Piastrone).SottoTipo
                    Case 1
                        GoTo Incompleto
                    Case 2
                        GoTo Incompleto
                    Case 3
                        Lungh = Lungh - CType(RecB.Parent, Piastrone).H2 - CType(RecB.Parent, Piastrone).Spessore
                    Case Else
                        GoTo Incompleto
                End Select
            Case Else
                GoTo Incompleto
        End Select
        txtPara(2).Text = GlobalRoutines.myStr(Lungh, 5, 2, 0)
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Membro.Lunghezza. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
        Membro.Lunghezza = Lungh
        Exit Sub
Incompleto:
        MsgBox("Da programmare in CalcolaLunghezza")
        cmbFinoA.SelectedIndex = 0
    End Sub
    Private Sub frmDati_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Disposed
        If Not IsNothing(myData) Then myData.Dispose()
    End Sub
    Private Sub DBCmbTipo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles DBCmbTipo.Click
        Dim Vecchio As Integer
        Dim i As Integer
        i = DBCmbTipo.SelectedIndex
        With CType(Membro, Sella)
            Vecchio = .StandardSEl
            Dim r As DataRow = myData.Tables(0).Rows(i)
            .StandardSEl = CInt(r("ListIndex")) + 1
            If Not .StandardSEl = Vecchio Then .AltriDati()
        End With
    End Sub
    Private Sub _cmdMat_1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _cmdMat_1.Click
        cmdMatClick(1)
    End Sub

    Private Sub _cmdMat_0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _cmdMat_0.Click
        cmdMatClick(0)
    End Sub

    Private Sub cmdPrezzo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdPrezzo.Click
        Dim Mat As LibMat.clsMatCompos ', Code As Integer
        Dim Unit As Short
        Dim prezzo As Single
        Dim inum As Short
        Dim pID As Integer
        Dim Code As Short
        Dim Param As Single
        Mat = New LibMat.clsMatCompos
        Mat.DoveMotore = Monitor.Motore
        Mat.TipoCompos = CType(CShort(Membro.TipoMat) - 1, LibMat.TipoRivestimento)
        Mat.Mat(1).Indmat = Membro.GenMem.Indmat1
        Mat.Mat(2).Indmat = Membro.GenMem.IndMat2
        Code = Membro.Code7
        Param = Membro.Param1
        If Membro.GenMem.MF = "FL" And Membro.GenMem.Classe1 = 7 Then
            Mat.Mat(1).MostraPrezzi(prezzo, 2, inum, pID, Code, Param)
        Else
            Unit = Membro.GenMem.Unit
            If Unit < 1 Or Unit > 2 Then Unit = 1
            Mat.Mat(1).MostraPrezzi(prezzo, Unit, inum, pID, Code, Param)
            Membro.GenMem.Unit = Unit
            AggUnit(Unit)
        End If
        Membro.GenMem.prezzoID = pID
        pID = 0
        Mat.Mat(2).MostraPrezzi(prezzo, 1, inum, pID, Code, Param)
        Membro.GenMem.prezzoID2 = pID
        Membro.Variato = True
        ForzaPrezzo = True
        MembroLeggi(Membro, Inizio.DiscoRam, 0)
        ForzaPrezzo = False
        AggTxtPsp()
    End Sub
    Private Sub cmdSvil_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSvil.Click
        Membro.Mostrasviluppi()
        AggTxtPsp()
    End Sub
    Private Sub cmdZoom_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdZoom.Click
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        Zooming = Not Zooming
        Frame4.Enabled = Not Zooming
        If Membro.GenMem.Tipo = 25 Then '8-5-99
            Frame7.Enabled = Not Zooming
        Else
            Frame1.Enabled = Not Zooming
        End If
        If Not Zooming Then
            ToolTip1.SetToolTip(cmdZoom, "Premere qui per zoommare, poi ritagliare una finestra sul disegno.")
            Ridisegna()
        Else
            ToolTip1.SetToolTip(cmdZoom, "Premere per smettere di zoommare")
        End If
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub cmdZoom_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cmdZoom.MouseDown
        AltroClick = True
    End Sub

    Private Sub Frame1_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Frame1.MouseHover
        PictHelp.Visible = False
    End Sub
    Private Sub Frame2_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Frame2.MouseHover
        PictHelp.Visible = False
    End Sub
    Private Sub Frame3_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Frame3.MouseHover
        PictHelp.Visible = False
    End Sub
    Private Sub Frame4_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Frame4.MouseHover
        PictHelp.Visible = False
    End Sub
    Private ReadOnly Property lblSuchi(ByVal i As Short) As Label
        Get
            Select Case i
                Case 0 : Return _lblSuChi_0
                Case 1 : Return _lblSuChi_1
                Case 2 : Return _lblSuChi_2
                Case 3 : Return _lblSuChi_3
                Case 4 : Return _lblSuChi_4
            End Select
        End Get
    End Property
    Public Sub Combo_MouseDown(ByVal Nome As String)
        If Inizializzando Then Exit Sub
        Dim s() As String = Nome.Split(CChar("_"))
        Dim Textnum As String = s(1)
        Dim Index As Short = CShort(s(2))
        Select Case Textnum
            Case "lstCodPos"
                IndCodPos = Index
                Abilitato = False
                If Not InTesti Then Membro.Variato = True
        End Select
    End Sub
    Private Sub txtDen_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtDen.Validating
        If Inizializzando Then Exit Sub
        Dim gm As clsGenMem = Membro.GenMem
        If Not InTesti Then Membro.Variato = True
        If gm.keyG Is Nothing Then Exit Sub
        If gm.keyG = "" Then Exit Sub
        If Not Apparecchio.Elementi.Cambiakey(gm.keyG, txtDen.Text) Then
            Text = "Membratura: " & gm.Denom
            e.Cancel = True
        Else
            gm.Denom = txtDen.Text
            gm.keyG = txtDen.Text
        End If
    End Sub

    Private Sub LoadtxtPsp(index As Integer)
        IndexedControls.AddClone(txtPsp, index)
        AddHandler txtPsp(index).TextChanged, AddressOf txtPsp_TextChanged
        AddHandler txtPsp(index).Enter, AddressOf txtPsp_Enter
        AddHandler txtPsp(index).KeyDown, AddressOf txtPsp_KeyDown
        AddHandler txtPsp(index).KeyPress, AddressOf txtPsp_KeyPress
        AddHandler txtPsp(index).KeyUp, AddressOf txtPsp_KeyUp
        AddHandler txtPsp(index).MouseDown, AddressOf txtPsp_MouseDown
    End Sub
    Private Sub UnloadtxtPsp(index As Integer)
        Dim control = txtPsp(index)
        txtPsp.Remove(index)
        control.Dispose()
    End Sub
End Class
