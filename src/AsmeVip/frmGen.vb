Option Strict Off
Option Explicit On
Friend Class frmGen
	Inherits System.Windows.Forms.Form
#Region "Codice generato dalla finestra di progettazione Windows Form "
	Public Sub New()
		MyBase.New()
        'If m_vb6FormDefInstance Is Nothing Then
        '       If m_InitializingDefInstance Then
        '       m_vb6FormDefInstance = Me
        '       Else
        '           Try
        'La prima istanza creata per il form di avvio rappresenta l'istanza predefinita.
        '      If System.Reflection.Assembly.GetExecutingAssembly.EntryPoint.DeclaringType Is Me.GetType Then
        '     m_vb6FormDefInstance = Me
        '    End If
        '       Catch
        '  End Try
        ' End If
        'End If
        'Chiamata richiesta dalla progettazione Windows Form.
        Inizializzando = True
        InitializeComponent()
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
    Public WithEvents chkPIverif As System.Windows.Forms.CheckBox
    Public WithEvents cmbMetodoPI As System.Windows.Forms.ComboBox
    Public WithEvents chkHTVert As System.Windows.Forms.CheckBox
    Public WithEvents cmbSpecial As System.Windows.Forms.ComboBox
    Public WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents Frame1 As System.Windows.Forms.GroupBox
    Public WithEvents chKDiversi As System.Windows.Forms.CheckBox
    Public WithEvents chkPI As System.Windows.Forms.CheckBox
    Public WithEvents _cmbCode_3 As System.Windows.Forms.ComboBox
    Public WithEvents _Label1_24 As System.Windows.Forms.Label
    Public WithEvents _Label1_55 As System.Windows.Forms.Label
    Public WithEvents _Frames_2 As System.Windows.Forms.GroupBox
    Public WithEvents _Text1_32 As System.Windows.Forms.TextBox
    Public WithEvents _Text1_31 As System.Windows.Forms.TextBox
    Public WithEvents _Check1_2 As System.Windows.Forms.CheckBox
    Public WithEvents _Text1_29 As System.Windows.Forms.TextBox
    Public WithEvents _Text1_28 As System.Windows.Forms.TextBox
    Public WithEvents _Text1_27 As System.Windows.Forms.TextBox
    Public WithEvents _Text1_26 As System.Windows.Forms.TextBox
    Public WithEvents _Text1_25 As System.Windows.Forms.TextBox
    Public WithEvents _Text1_24 As System.Windows.Forms.TextBox
    Public WithEvents _Text1_23 As System.Windows.Forms.TextBox
    Public WithEvents _Text1_22 As System.Windows.Forms.TextBox
    Public WithEvents _Text1_21 As System.Windows.Forms.TextBox
    Public WithEvents _Text1_20 As System.Windows.Forms.TextBox
    Public WithEvents _cmbVessMat_2 As System.Windows.Forms.ComboBox
    Public WithEvents _cmbCode_2 As System.Windows.Forms.ComboBox
    Public WithEvents _Text1_30 As System.Windows.Forms.TextBox
    Public WithEvents _Label1_25 As System.Windows.Forms.Label
    Public WithEvents _Label1_23 As System.Windows.Forms.Label
    Public WithEvents _Label1_35 As System.Windows.Forms.Label
    Public WithEvents _Label1_34 As System.Windows.Forms.Label
    Public WithEvents _Label1_33 As System.Windows.Forms.Label
    Public WithEvents _Label1_32 As System.Windows.Forms.Label
    Public WithEvents _Label1_31 As System.Windows.Forms.Label
    Public WithEvents _Label1_30 As System.Windows.Forms.Label
    Public WithEvents _Label1_29 As System.Windows.Forms.Label
    Public WithEvents _Label1_28 As System.Windows.Forms.Label
    Public WithEvents _Label1_21 As System.Windows.Forms.Label
    Public WithEvents _Label1_20 As System.Windows.Forms.Label
    Public WithEvents _Label1_19 As System.Windows.Forms.Label
    Public WithEvents _Label1_18 As System.Windows.Forms.Label
    Public WithEvents _Label1_17 As System.Windows.Forms.Label
    Public WithEvents _Label1_16 As System.Windows.Forms.Label
    Public WithEvents _Label1_2 As System.Windows.Forms.Label
    Public WithEvents _Frames_1 As System.Windows.Forms.GroupBox
    Public WithEvents _NLati_2 As System.Windows.Forms.RadioButton
    Public WithEvents _NLati_1 As System.Windows.Forms.RadioButton
    Public WithEvents Command1 As System.Windows.Forms.Button
    Public WithEvents ChkMAWP As System.Windows.Forms.CheckBox
    Public WithEvents cmbLoadCase As System.Windows.Forms.ComboBox
    Public WithEvents cmbUnit As System.Windows.Forms.ComboBox
    Public WithEvents txtItem As System.Windows.Forms.TextBox
    Public WithEvents _Text1_12 As System.Windows.Forms.TextBox
    Public WithEvents _Text1_11 As System.Windows.Forms.TextBox
    Public WithEvents _Text1_10 As System.Windows.Forms.TextBox
    Public WithEvents _cmbCode_1 As System.Windows.Forms.ComboBox
    Public WithEvents _cmbVessMat_1 As System.Windows.Forms.ComboBox
    Public WithEvents _Text1_0 As System.Windows.Forms.TextBox
    Public WithEvents _Text1_1 As System.Windows.Forms.TextBox
    Public WithEvents _Text1_2 As System.Windows.Forms.TextBox
    Public WithEvents _Text1_3 As System.Windows.Forms.TextBox
    Public WithEvents _Text1_4 As System.Windows.Forms.TextBox
    Public WithEvents _Text1_5 As System.Windows.Forms.TextBox
    Public WithEvents _Text1_6 As System.Windows.Forms.TextBox
    Public WithEvents _Text1_7 As System.Windows.Forms.TextBox
    Public WithEvents _Text1_8 As System.Windows.Forms.TextBox
    Public WithEvents _Text1_9 As System.Windows.Forms.TextBox
    Public WithEvents _Check1_1 As System.Windows.Forms.CheckBox
    Public WithEvents _Label1_26 As System.Windows.Forms.Label
    Public WithEvents _Label1_22 As System.Windows.Forms.Label
    Public WithEvents _Label1_1 As System.Windows.Forms.Label
    Public WithEvents _Label1_0 As System.Windows.Forms.Label
    Public WithEvents _Label1_3 As System.Windows.Forms.Label
    Public WithEvents _Label1_4 As System.Windows.Forms.Label
    Public WithEvents _Label1_5 As System.Windows.Forms.Label
    Public WithEvents _Label1_6 As System.Windows.Forms.Label
    Public WithEvents _Label1_7 As System.Windows.Forms.Label
    Public WithEvents _Label1_8 As System.Windows.Forms.Label
    Public WithEvents _Label1_9 As System.Windows.Forms.Label
    Public WithEvents _Label1_10 As System.Windows.Forms.Label
    Public WithEvents _Label1_11 As System.Windows.Forms.Label
    Public WithEvents _Label1_12 As System.Windows.Forms.Label
    Public WithEvents _Label1_13 As System.Windows.Forms.Label
    Public WithEvents _Label1_14 As System.Windows.Forms.Label
    Public WithEvents _Label1_15 As System.Windows.Forms.Label
    Public WithEvents _Frames_0 As System.Windows.Forms.GroupBox
    Public WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents lblLati As System.Windows.Forms.Label
    Public WithEvents lblLC As System.Windows.Forms.Label
    Public WithEvents lblUnit As System.Windows.Forms.Label
    Public WithEvents _lblItem_16 As System.Windows.Forms.Label
    'NOTA: la routine seguente è richiesta dalla progettazione Windows Form.
    'Può essere modificata utilizzando la finestra di progettazione Windows Form.
    'Non modificarla mediante l'editor di codice.
    Friend WithEvents _txtNbLC_1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents _txtNb_1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents _txtNbLC_2 As System.Windows.Forms.NumericUpDown
    Friend WithEvents _txtNb_2 As System.Windows.Forms.NumericUpDown
    Friend WithEvents _txtNb_3 As System.Windows.Forms.NumericUpDown
    Friend WithEvents PulsPI As System.Windows.Forms.Button
    Friend WithEvents HelpProvider1 As System.Windows.Forms.HelpProvider
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.chkPIverif = New System.Windows.Forms.CheckBox
        Me.cmbMetodoPI = New System.Windows.Forms.ComboBox
        Me.chkHTVert = New System.Windows.Forms.CheckBox
        Me.Frame1 = New System.Windows.Forms.GroupBox
        Me.cmbSpecial = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.chKDiversi = New System.Windows.Forms.CheckBox
        Me.chkPI = New System.Windows.Forms.CheckBox
        Me._Frames_2 = New System.Windows.Forms.GroupBox
        Me._txtNb_3 = New System.Windows.Forms.NumericUpDown
        Me._cmbCode_3 = New System.Windows.Forms.ComboBox
        Me._Label1_24 = New System.Windows.Forms.Label
        Me._Label1_55 = New System.Windows.Forms.Label
        Me._Frames_1 = New System.Windows.Forms.GroupBox
        Me._txtNb_2 = New System.Windows.Forms.NumericUpDown
        Me._txtNbLC_2 = New System.Windows.Forms.NumericUpDown
        Me._Text1_32 = New System.Windows.Forms.TextBox
        Me._Text1_31 = New System.Windows.Forms.TextBox
        Me._Check1_2 = New System.Windows.Forms.CheckBox
        Me._Text1_29 = New System.Windows.Forms.TextBox
        Me._Text1_28 = New System.Windows.Forms.TextBox
        Me._Text1_27 = New System.Windows.Forms.TextBox
        Me._Text1_26 = New System.Windows.Forms.TextBox
        Me._Text1_25 = New System.Windows.Forms.TextBox
        Me._Text1_24 = New System.Windows.Forms.TextBox
        Me._Text1_23 = New System.Windows.Forms.TextBox
        Me._Text1_22 = New System.Windows.Forms.TextBox
        Me._Text1_21 = New System.Windows.Forms.TextBox
        Me._Text1_20 = New System.Windows.Forms.TextBox
        Me._cmbVessMat_2 = New System.Windows.Forms.ComboBox
        Me._cmbCode_2 = New System.Windows.Forms.ComboBox
        Me._Text1_30 = New System.Windows.Forms.TextBox
        Me._Label1_25 = New System.Windows.Forms.Label
        Me._Label1_23 = New System.Windows.Forms.Label
        Me._Label1_35 = New System.Windows.Forms.Label
        Me._Label1_34 = New System.Windows.Forms.Label
        Me._Label1_33 = New System.Windows.Forms.Label
        Me._Label1_32 = New System.Windows.Forms.Label
        Me._Label1_31 = New System.Windows.Forms.Label
        Me._Label1_30 = New System.Windows.Forms.Label
        Me._Label1_29 = New System.Windows.Forms.Label
        Me._Label1_28 = New System.Windows.Forms.Label
        Me._Label1_21 = New System.Windows.Forms.Label
        Me._Label1_20 = New System.Windows.Forms.Label
        Me._Label1_19 = New System.Windows.Forms.Label
        Me._Label1_18 = New System.Windows.Forms.Label
        Me._Label1_17 = New System.Windows.Forms.Label
        Me._Label1_16 = New System.Windows.Forms.Label
        Me._Label1_2 = New System.Windows.Forms.Label
        Me._NLati_2 = New System.Windows.Forms.RadioButton
        Me._NLati_1 = New System.Windows.Forms.RadioButton
        Me.Command1 = New System.Windows.Forms.Button
        Me.ChkMAWP = New System.Windows.Forms.CheckBox
        Me.cmbLoadCase = New System.Windows.Forms.ComboBox
        Me.cmbUnit = New System.Windows.Forms.ComboBox
        Me.txtItem = New System.Windows.Forms.TextBox
        Me._Frames_0 = New System.Windows.Forms.GroupBox
        Me._txtNb_1 = New System.Windows.Forms.NumericUpDown
        Me._txtNbLC_1 = New System.Windows.Forms.NumericUpDown
        Me._Text1_12 = New System.Windows.Forms.TextBox
        Me._Text1_11 = New System.Windows.Forms.TextBox
        Me._Text1_10 = New System.Windows.Forms.TextBox
        Me._cmbCode_1 = New System.Windows.Forms.ComboBox
        Me._cmbVessMat_1 = New System.Windows.Forms.ComboBox
        Me._Text1_0 = New System.Windows.Forms.TextBox
        Me._Text1_1 = New System.Windows.Forms.TextBox
        Me._Text1_2 = New System.Windows.Forms.TextBox
        Me._Text1_3 = New System.Windows.Forms.TextBox
        Me._Text1_4 = New System.Windows.Forms.TextBox
        Me._Text1_5 = New System.Windows.Forms.TextBox
        Me._Text1_6 = New System.Windows.Forms.TextBox
        Me._Text1_7 = New System.Windows.Forms.TextBox
        Me._Text1_8 = New System.Windows.Forms.TextBox
        Me._Text1_9 = New System.Windows.Forms.TextBox
        Me._Check1_1 = New System.Windows.Forms.CheckBox
        Me._Label1_26 = New System.Windows.Forms.Label
        Me._Label1_22 = New System.Windows.Forms.Label
        Me._Label1_1 = New System.Windows.Forms.Label
        Me._Label1_0 = New System.Windows.Forms.Label
        Me._Label1_3 = New System.Windows.Forms.Label
        Me._Label1_4 = New System.Windows.Forms.Label
        Me._Label1_5 = New System.Windows.Forms.Label
        Me._Label1_6 = New System.Windows.Forms.Label
        Me._Label1_7 = New System.Windows.Forms.Label
        Me._Label1_8 = New System.Windows.Forms.Label
        Me._Label1_9 = New System.Windows.Forms.Label
        Me._Label1_10 = New System.Windows.Forms.Label
        Me._Label1_11 = New System.Windows.Forms.Label
        Me._Label1_12 = New System.Windows.Forms.Label
        Me._Label1_13 = New System.Windows.Forms.Label
        Me._Label1_14 = New System.Windows.Forms.Label
        Me._Label1_15 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.lblLati = New System.Windows.Forms.Label
        Me.lblLC = New System.Windows.Forms.Label
        Me.lblUnit = New System.Windows.Forms.Label
        Me._lblItem_16 = New System.Windows.Forms.Label
        Me.PulsPI = New System.Windows.Forms.Button
        Me.HelpProvider1 = New System.Windows.Forms.HelpProvider
        Me.Frame1.SuspendLayout()
        Me._Frames_2.SuspendLayout()
        CType(Me._txtNb_3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me._Frames_1.SuspendLayout()
        CType(Me._txtNb_2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._txtNbLC_2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me._Frames_0.SuspendLayout()
        CType(Me._txtNb_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._txtNbLC_1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'chkPIverif
        '
        Me.chkPIverif.BackColor = System.Drawing.SystemColors.Control
        Me.chkPIverif.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkPIverif.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkPIverif.Location = New System.Drawing.Point(8, 86)
        Me.chkPIverif.Name = "chkPIverif"
        Me.chkPIverif.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkPIverif.Size = New System.Drawing.Size(146, 17)
        Me.chkPIverif.TabIndex = 101
        Me.chkPIverif.Text = "Hydr.Test  verifications"
        '
        'cmbMetodoPI
        '
        Me.cmbMetodoPI.BackColor = System.Drawing.SystemColors.Window
        Me.cmbMetodoPI.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbMetodoPI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMetodoPI.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbMetodoPI.Location = New System.Drawing.Point(225, 38)
        Me.cmbMetodoPI.Name = "cmbMetodoPI"
        Me.cmbMetodoPI.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbMetodoPI.Size = New System.Drawing.Size(136, 21)
        Me.cmbMetodoPI.TabIndex = 94
        Me.cmbMetodoPI.Visible = False
        '
        'chkHTVert
        '
        Me.chkHTVert.BackColor = System.Drawing.SystemColors.Control
        Me.chkHTVert.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkHTVert.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkHTVert.Location = New System.Drawing.Point(8, 54)
        Me.chkHTVert.Name = "chkHTVert"
        Me.chkHTVert.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkHTVert.Size = New System.Drawing.Size(185, 17)
        Me.chkHTVert.TabIndex = 92
        Me.chkHTVert.Text = "Hydr.Test in vertical position"
        '
        'Frame1
        '
        Me.Frame1.BackColor = System.Drawing.SystemColors.Control
        Me.Frame1.Controls.Add(Me.cmbSpecial)
        Me.Frame1.Controls.Add(Me.Label2)
        Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame1.Location = New System.Drawing.Point(208, 56)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame1.Size = New System.Drawing.Size(329, 65)
        Me.Frame1.TabIndex = 89
        Me.Frame1.TabStop = False
        '
        'cmbSpecial
        '
        Me.cmbSpecial.BackColor = System.Drawing.SystemColors.Window
        Me.cmbSpecial.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbSpecial.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbSpecial.Location = New System.Drawing.Point(128, 16)
        Me.cmbSpecial.Name = "cmbSpecial"
        Me.cmbSpecial.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbSpecial.Size = New System.Drawing.Size(193, 21)
        Me.cmbSpecial.TabIndex = 91
        Me.cmbSpecial.Text = "Combo1"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(8, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(112, 41)
        Me.Label2.TabIndex = 90
        Me.Label2.Text = "Special requirements for reinforcement of the openings"
        '
        'chKDiversi
        '
        Me.chKDiversi.BackColor = System.Drawing.SystemColors.Control
        Me.chKDiversi.Cursor = System.Windows.Forms.Cursors.Default
        Me.chKDiversi.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chKDiversi.Location = New System.Drawing.Point(8, 70)
        Me.chKDiversi.Name = "chKDiversi"
        Me.chKDiversi.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chKDiversi.Size = New System.Drawing.Size(201, 17)
        Me.chKDiversi.TabIndex = 88
        Me.chKDiversi.Text = "Non uniform Design Temperatures"
        '
        'chkPI
        '
        Me.chkPI.BackColor = System.Drawing.SystemColors.Control
        Me.chkPI.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkPI.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkPI.Location = New System.Drawing.Point(8, 40)
        Me.chkPI.Name = "chkPI"
        Me.chkPI.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkPI.Size = New System.Drawing.Size(146, 17)
        Me.chkPI.TabIndex = 87
        Me.chkPI.Text = "Hydr.Test  calculations"
        '
        '_Frames_2
        '
        Me._Frames_2.BackColor = System.Drawing.SystemColors.Control
        Me._Frames_2.Controls.Add(Me._txtNb_3)
        Me._Frames_2.Controls.Add(Me._cmbCode_3)
        Me._Frames_2.Controls.Add(Me._Label1_24)
        Me._Frames_2.Controls.Add(Me._Label1_55)
        Me._Frames_2.ForeColor = System.Drawing.Color.Red
        Me._Frames_2.Location = New System.Drawing.Point(0, 512)
        Me._Frames_2.Name = "_Frames_2"
        Me._Frames_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Frames_2.Size = New System.Drawing.Size(483, 41)
        Me._Frames_2.TabIndex = 79
        Me._Frames_2.TabStop = False
        Me._Frames_2.Text = "Between the two sides"
        '
        '_txtNb_3
        '
        Me._txtNb_3.Location = New System.Drawing.Point(400, 16)
        Me._txtNb_3.Name = "_txtNb_3"
        Me._txtNb_3.Size = New System.Drawing.Size(72, 20)
        Me._txtNb_3.TabIndex = 97
        Me._txtNb_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        '_cmbCode_3
        '
        Me._cmbCode_3.BackColor = System.Drawing.SystemColors.Window
        Me._cmbCode_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmbCode_3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me._cmbCode_3.ForeColor = System.Drawing.SystemColors.WindowText
        Me._cmbCode_3.Location = New System.Drawing.Point(144, 16)
        Me._cmbCode_3.Name = "_cmbCode_3"
        Me._cmbCode_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmbCode_3.Size = New System.Drawing.Size(121, 21)
        Me._cmbCode_3.TabIndex = 95
        '
        '_Label1_24
        '
        Me._Label1_24.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_24.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_24.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_24.Location = New System.Drawing.Point(8, 17)
        Me._Label1_24.Name = "_Label1_24"
        Me._Label1_24.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_24.Size = New System.Drawing.Size(121, 17)
        Me._Label1_24.TabIndex = 96
        Me._Label1_24.Text = "Design according to:"
        '
        '_Label1_55
        '
        Me._Label1_55.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_55.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_55.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_55.Location = New System.Drawing.Point(272, 17)
        Me._Label1_55.Name = "_Label1_55"
        Me._Label1_55.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_55.Size = New System.Drawing.Size(121, 17)
        Me._Label1_55.TabIndex = 82
        Me._Label1_55.Text = "Number of members"
        '
        '_Frames_1
        '
        Me._Frames_1.BackColor = System.Drawing.SystemColors.Control
        Me._Frames_1.Controls.Add(Me._txtNb_2)
        Me._Frames_1.Controls.Add(Me._txtNbLC_2)
        Me._Frames_1.Controls.Add(Me._Text1_32)
        Me._Frames_1.Controls.Add(Me._Text1_31)
        Me._Frames_1.Controls.Add(Me._Check1_2)
        Me._Frames_1.Controls.Add(Me._Text1_29)
        Me._Frames_1.Controls.Add(Me._Text1_28)
        Me._Frames_1.Controls.Add(Me._Text1_27)
        Me._Frames_1.Controls.Add(Me._Text1_26)
        Me._Frames_1.Controls.Add(Me._Text1_25)
        Me._Frames_1.Controls.Add(Me._Text1_24)
        Me._Frames_1.Controls.Add(Me._Text1_23)
        Me._Frames_1.Controls.Add(Me._Text1_22)
        Me._Frames_1.Controls.Add(Me._Text1_21)
        Me._Frames_1.Controls.Add(Me._Text1_20)
        Me._Frames_1.Controls.Add(Me._cmbVessMat_2)
        Me._Frames_1.Controls.Add(Me._cmbCode_2)
        Me._Frames_1.Controls.Add(Me._Text1_30)
        Me._Frames_1.Controls.Add(Me._Label1_25)
        Me._Frames_1.Controls.Add(Me._Label1_23)
        Me._Frames_1.Controls.Add(Me._Label1_35)
        Me._Frames_1.Controls.Add(Me._Label1_34)
        Me._Frames_1.Controls.Add(Me._Label1_33)
        Me._Frames_1.Controls.Add(Me._Label1_32)
        Me._Frames_1.Controls.Add(Me._Label1_31)
        Me._Frames_1.Controls.Add(Me._Label1_30)
        Me._Frames_1.Controls.Add(Me._Label1_29)
        Me._Frames_1.Controls.Add(Me._Label1_28)
        Me._Frames_1.Controls.Add(Me._Label1_21)
        Me._Frames_1.Controls.Add(Me._Label1_20)
        Me._Frames_1.Controls.Add(Me._Label1_19)
        Me._Frames_1.Controls.Add(Me._Label1_18)
        Me._Frames_1.Controls.Add(Me._Label1_17)
        Me._Frames_1.Controls.Add(Me._Label1_16)
        Me._Frames_1.Controls.Add(Me._Label1_2)
        Me._Frames_1.ForeColor = System.Drawing.Color.Red
        Me._Frames_1.Location = New System.Drawing.Point(0, 320)
        Me._Frames_1.Name = "_Frames_1"
        Me._Frames_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Frames_1.Size = New System.Drawing.Size(537, 193)
        Me._Frames_1.TabIndex = 45
        Me._Frames_1.TabStop = False
        Me._Frames_1.Text = "Tube side"
        '
        '_txtNb_2
        '
        Me._txtNb_2.Location = New System.Drawing.Point(400, 152)
        Me._txtNb_2.Name = "_txtNb_2"
        Me._txtNb_2.Size = New System.Drawing.Size(56, 20)
        Me._txtNb_2.TabIndex = 100
        Me._txtNb_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        '_txtNbLC_2
        '
        Me._txtNbLC_2.Location = New System.Drawing.Point(192, 72)
        Me._txtNbLC_2.Name = "_txtNbLC_2"
        Me._txtNbLC_2.Size = New System.Drawing.Size(72, 20)
        Me._txtNbLC_2.TabIndex = 99
        Me._txtNbLC_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        '_Text1_32
        '
        Me._Text1_32.AcceptsReturn = True
        Me._Text1_32.AutoSize = False
        Me._Text1_32.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_32.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_32.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_32.Location = New System.Drawing.Point(192, 168)
        Me._Text1_32.MaxLength = 0
        Me._Text1_32.Name = "_Text1_32"
        Me._Text1_32.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_32.Size = New System.Drawing.Size(73, 20)
        Me._Text1_32.TabIndex = 97
        Me._Text1_32.Text = ""
        '
        '_Text1_31
        '
        Me._Text1_31.AcceptsReturn = True
        Me._Text1_31.AutoSize = False
        Me._Text1_31.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_31.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_31.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_31.Location = New System.Drawing.Point(456, 16)
        Me._Text1_31.MaxLength = 0
        Me._Text1_31.Name = "_Text1_31"
        Me._Text1_31.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_31.Size = New System.Drawing.Size(73, 20)
        Me._Text1_31.TabIndex = 86
        Me._Text1_31.Text = ""
        '
        '_Check1_2
        '
        Me._Check1_2.BackColor = System.Drawing.SystemColors.Control
        Me._Check1_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._Check1_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Check1_2.Location = New System.Drawing.Point(8, 132)
        Me._Check1_2.Name = "_Check1_2"
        Me._Check1_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Check1_2.Size = New System.Drawing.Size(201, 17)
        Me._Check1_2.TabIndex = 61
        Me._Check1_2.Text = "Design under external pressure"
        '
        '_Text1_29
        '
        Me._Text1_29.AcceptsReturn = True
        Me._Text1_29.AutoSize = False
        Me._Text1_29.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_29.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_29.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_29.Location = New System.Drawing.Point(192, 152)
        Me._Text1_29.MaxLength = 0
        Me._Text1_29.Name = "_Text1_29"
        Me._Text1_29.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_29.Size = New System.Drawing.Size(73, 20)
        Me._Text1_29.TabIndex = 59
        Me._Text1_29.Text = ""
        '
        '_Text1_28
        '
        Me._Text1_28.AcceptsReturn = True
        Me._Text1_28.AutoSize = False
        Me._Text1_28.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_28.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_28.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_28.Location = New System.Drawing.Point(480, 131)
        Me._Text1_28.MaxLength = 0
        Me._Text1_28.Name = "_Text1_28"
        Me._Text1_28.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_28.Size = New System.Drawing.Size(49, 20)
        Me._Text1_28.TabIndex = 58
        Me._Text1_28.Text = ""
        '
        '_Text1_27
        '
        Me._Text1_27.AcceptsReturn = True
        Me._Text1_27.AutoSize = False
        Me._Text1_27.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_27.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_27.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_27.Location = New System.Drawing.Point(320, 131)
        Me._Text1_27.MaxLength = 0
        Me._Text1_27.Name = "_Text1_27"
        Me._Text1_27.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_27.Size = New System.Drawing.Size(49, 20)
        Me._Text1_27.TabIndex = 57
        Me._Text1_27.Text = ""
        '
        '_Text1_26
        '
        Me._Text1_26.AcceptsReturn = True
        Me._Text1_26.AutoSize = False
        Me._Text1_26.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_26.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_26.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_26.Location = New System.Drawing.Point(456, 112)
        Me._Text1_26.MaxLength = 0
        Me._Text1_26.Name = "_Text1_26"
        Me._Text1_26.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_26.Size = New System.Drawing.Size(73, 20)
        Me._Text1_26.TabIndex = 56
        Me._Text1_26.Text = ""
        '
        '_Text1_25
        '
        Me._Text1_25.AcceptsReturn = True
        Me._Text1_25.AutoSize = False
        Me._Text1_25.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_25.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_25.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_25.Location = New System.Drawing.Point(192, 112)
        Me._Text1_25.MaxLength = 0
        Me._Text1_25.Name = "_Text1_25"
        Me._Text1_25.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_25.Size = New System.Drawing.Size(73, 20)
        Me._Text1_25.TabIndex = 55
        Me._Text1_25.Text = ""
        '
        '_Text1_24
        '
        Me._Text1_24.AcceptsReturn = True
        Me._Text1_24.AutoSize = False
        Me._Text1_24.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_24.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_24.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_24.Location = New System.Drawing.Point(456, 93)
        Me._Text1_24.MaxLength = 0
        Me._Text1_24.Name = "_Text1_24"
        Me._Text1_24.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_24.Size = New System.Drawing.Size(73, 20)
        Me._Text1_24.TabIndex = 54
        Me._Text1_24.Text = ""
        '
        '_Text1_23
        '
        Me._Text1_23.AcceptsReturn = True
        Me._Text1_23.AutoSize = False
        Me._Text1_23.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_23.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_23.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_23.Location = New System.Drawing.Point(192, 93)
        Me._Text1_23.MaxLength = 0
        Me._Text1_23.Name = "_Text1_23"
        Me._Text1_23.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_23.Size = New System.Drawing.Size(73, 20)
        Me._Text1_23.TabIndex = 53
        Me._Text1_23.Text = ""
        '
        '_Text1_22
        '
        Me._Text1_22.AcceptsReturn = True
        Me._Text1_22.AutoSize = False
        Me._Text1_22.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_22.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_22.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_22.Location = New System.Drawing.Point(456, 55)
        Me._Text1_22.MaxLength = 0
        Me._Text1_22.Name = "_Text1_22"
        Me._Text1_22.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_22.Size = New System.Drawing.Size(73, 20)
        Me._Text1_22.TabIndex = 51
        Me._Text1_22.Text = ""
        '
        '_Text1_21
        '
        Me._Text1_21.AcceptsReturn = True
        Me._Text1_21.AutoSize = False
        Me._Text1_21.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_21.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_21.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_21.Location = New System.Drawing.Point(192, 55)
        Me._Text1_21.MaxLength = 0
        Me._Text1_21.Name = "_Text1_21"
        Me._Text1_21.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_21.Size = New System.Drawing.Size(73, 20)
        Me._Text1_21.TabIndex = 50
        Me._Text1_21.Text = ""
        '
        '_Text1_20
        '
        Me._Text1_20.AcceptsReturn = True
        Me._Text1_20.AutoSize = False
        Me._Text1_20.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_20.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_20.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_20.Location = New System.Drawing.Point(192, 36)
        Me._Text1_20.MaxLength = 0
        Me._Text1_20.Name = "_Text1_20"
        Me._Text1_20.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_20.Size = New System.Drawing.Size(73, 20)
        Me._Text1_20.TabIndex = 49
        Me._Text1_20.Text = ""
        '
        '_cmbVessMat_2
        '
        Me._cmbVessMat_2.BackColor = System.Drawing.SystemColors.Window
        Me._cmbVessMat_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmbVessMat_2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me._cmbVessMat_2.ForeColor = System.Drawing.SystemColors.WindowText
        Me._cmbVessMat_2.Location = New System.Drawing.Point(408, 36)
        Me._cmbVessMat_2.Name = "_cmbVessMat_2"
        Me._cmbVessMat_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmbVessMat_2.Size = New System.Drawing.Size(121, 21)
        Me._cmbVessMat_2.TabIndex = 48
        '
        '_cmbCode_2
        '
        Me._cmbCode_2.BackColor = System.Drawing.SystemColors.Window
        Me._cmbCode_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmbCode_2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me._cmbCode_2.ForeColor = System.Drawing.SystemColors.WindowText
        Me._cmbCode_2.Location = New System.Drawing.Point(144, 15)
        Me._cmbCode_2.Name = "_cmbCode_2"
        Me._cmbCode_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmbCode_2.Size = New System.Drawing.Size(121, 21)
        Me._cmbCode_2.TabIndex = 47
        '
        '_Text1_30
        '
        Me._Text1_30.AcceptsReturn = True
        Me._Text1_30.AutoSize = False
        Me._Text1_30.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_30.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_30.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_30.Location = New System.Drawing.Point(456, 72)
        Me._Text1_30.MaxLength = 0
        Me._Text1_30.Name = "_Text1_30"
        Me._Text1_30.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_30.Size = New System.Drawing.Size(73, 20)
        Me._Text1_30.TabIndex = 46
        Me._Text1_30.Text = ""
        '
        '_Label1_25
        '
        Me._Label1_25.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_25.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_25.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_25.Location = New System.Drawing.Point(8, 169)
        Me._Label1_25.Name = "_Label1_25"
        Me._Label1_25.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_25.Size = New System.Drawing.Size(169, 17)
        Me._Label1_25.TabIndex = 98
        Me._Label1_25.Text = "Joint efficiency"
        '
        '_Label1_23
        '
        Me._Label1_23.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_23.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_23.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_23.Location = New System.Drawing.Point(272, 16)
        Me._Label1_23.Name = "_Label1_23"
        Me._Label1_23.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_23.Size = New System.Drawing.Size(152, 17)
        Me._Label1_23.TabIndex = 85
        Me._Label1_23.Text = "Corrosion allowance"
        '
        '_Label1_35
        '
        Me._Label1_35.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_35.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_35.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_35.Location = New System.Drawing.Point(272, 152)
        Me._Label1_35.Name = "_Label1_35"
        Me._Label1_35.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_35.Size = New System.Drawing.Size(121, 17)
        Me._Label1_35.TabIndex = 78
        Me._Label1_35.Text = "Number of members"
        '
        '_Label1_34
        '
        Me._Label1_34.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_34.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_34.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_34.Location = New System.Drawing.Point(8, 153)
        Me._Label1_34.Name = "_Label1_34"
        Me._Label1_34.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_34.Size = New System.Drawing.Size(177, 17)
        Me._Label1_34.TabIndex = 77
        Me._Label1_34.Text = "Relative density of contained fluid"
        '
        '_Label1_33
        '
        Me._Label1_33.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_33.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_33.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_33.Location = New System.Drawing.Point(376, 134)
        Me._Label1_33.Name = "_Label1_33"
        Me._Label1_33.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_33.Size = New System.Drawing.Size(105, 17)
        Me._Label1_33.TabIndex = 76
        Me._Label1_33.Text = "Coinc.Temp."
        '
        '_Label1_32
        '
        Me._Label1_32.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_32.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_32.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_32.Location = New System.Drawing.Point(216, 134)
        Me._Label1_32.Name = "_Label1_32"
        Me._Label1_32.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_32.Size = New System.Drawing.Size(97, 17)
        Me._Label1_32.TabIndex = 75
        Me._Label1_32.Text = "Ext.Press."
        '
        '_Label1_31
        '
        Me._Label1_31.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_31.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_31.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_31.Location = New System.Drawing.Point(272, 114)
        Me._Label1_31.Name = "_Label1_31"
        Me._Label1_31.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_31.Size = New System.Drawing.Size(153, 17)
        Me._Label1_31.TabIndex = 74
        Me._Label1_31.Text = "Coincident Pressure"
        '
        '_Label1_30
        '
        Me._Label1_30.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_30.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_30.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_30.Location = New System.Drawing.Point(8, 114)
        Me._Label1_30.Name = "_Label1_30"
        Me._Label1_30.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_30.Size = New System.Drawing.Size(177, 17)
        Me._Label1_30.TabIndex = 73
        Me._Label1_30.Text = "Minimum Des.Temp."
        '
        '_Label1_29
        '
        Me._Label1_29.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_29.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_29.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_29.Location = New System.Drawing.Point(272, 94)
        Me._Label1_29.Name = "_Label1_29"
        Me._Label1_29.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_29.Size = New System.Drawing.Size(153, 17)
        Me._Label1_29.TabIndex = 72
        Me._Label1_29.Text = "Coincident Pressure"
        '
        '_Label1_28
        '
        Me._Label1_28.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_28.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_28.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_28.Location = New System.Drawing.Point(8, 94)
        Me._Label1_28.Name = "_Label1_28"
        Me._Label1_28.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_28.Size = New System.Drawing.Size(177, 17)
        Me._Label1_28.TabIndex = 71
        Me._Label1_28.Text = "Minimum Des.Temp."
        '
        '_Label1_21
        '
        Me._Label1_21.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_21.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_21.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_21.Location = New System.Drawing.Point(8, 76)
        Me._Label1_21.Name = "_Label1_21"
        Me._Label1_21.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_21.Size = New System.Drawing.Size(161, 17)
        Me._Label1_21.TabIndex = 70
        Me._Label1_21.Text = "Nb. of low temp. conditions"
        '
        '_Label1_20
        '
        Me._Label1_20.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_20.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_20.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_20.Location = New System.Drawing.Point(272, 56)
        Me._Label1_20.Name = "_Label1_20"
        Me._Label1_20.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_20.Size = New System.Drawing.Size(153, 17)
        Me._Label1_20.TabIndex = 69
        Me._Label1_20.Text = "Design Temperature"
        '
        '_Label1_19
        '
        Me._Label1_19.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_19.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_19.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_19.Location = New System.Drawing.Point(8, 56)
        Me._Label1_19.Name = "_Label1_19"
        Me._Label1_19.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_19.Size = New System.Drawing.Size(177, 17)
        Me._Label1_19.TabIndex = 68
        Me._Label1_19.Text = "Design Pressure"
        '
        '_Label1_18
        '
        Me._Label1_18.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_18.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_18.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_18.Location = New System.Drawing.Point(8, 37)
        Me._Label1_18.Name = "_Label1_18"
        Me._Label1_18.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_18.Size = New System.Drawing.Size(169, 17)
        Me._Label1_18.TabIndex = 67
        Me._Label1_18.Text = "Vessel Inner dia."
        '
        '_Label1_17
        '
        Me._Label1_17.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_17.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_17.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_17.Location = New System.Drawing.Point(272, 37)
        Me._Label1_17.Name = "_Label1_17"
        Me._Label1_17.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_17.Size = New System.Drawing.Size(128, 17)
        Me._Label1_17.TabIndex = 66
        Me._Label1_17.Text = "Vessel material"
        '
        '_Label1_16
        '
        Me._Label1_16.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_16.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_16.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_16.Location = New System.Drawing.Point(8, 16)
        Me._Label1_16.Name = "_Label1_16"
        Me._Label1_16.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_16.Size = New System.Drawing.Size(121, 17)
        Me._Label1_16.TabIndex = 65
        Me._Label1_16.Text = "Design according to:"
        '
        '_Label1_2
        '
        Me._Label1_2.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_2.Location = New System.Drawing.Point(272, 75)
        Me._Label1_2.Name = "_Label1_2"
        Me._Label1_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_2.Size = New System.Drawing.Size(153, 17)
        Me._Label1_2.TabIndex = 64
        Me._Label1_2.Text = "Test Pressure"
        '
        '_NLati_2
        '
        Me._NLati_2.BackColor = System.Drawing.SystemColors.Control
        Me._NLati_2.Checked = True
        Me._NLati_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._NLati_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._NLati_2.Location = New System.Drawing.Point(136, 24)
        Me._NLati_2.Name = "_NLati_2"
        Me._NLati_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._NLati_2.Size = New System.Drawing.Size(33, 17)
        Me._NLati_2.TabIndex = 44
        Me._NLati_2.TabStop = True
        Me._NLati_2.Text = "2"
        '
        '_NLati_1
        '
        Me._NLati_1.BackColor = System.Drawing.SystemColors.Control
        Me._NLati_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._NLati_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._NLati_1.Location = New System.Drawing.Point(104, 24)
        Me._NLati_1.Name = "_NLati_1"
        Me._NLati_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._NLati_1.Size = New System.Drawing.Size(33, 17)
        Me._NLati_1.TabIndex = 43
        Me._NLati_1.TabStop = True
        Me._NLati_1.Text = "1"
        '
        'Command1
        '
        Me.Command1.BackColor = System.Drawing.SystemColors.Control
        Me.Command1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command1.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Command1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command1.Location = New System.Drawing.Point(496, 528)
        Me.Command1.Name = "Command1"
        Me.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command1.Size = New System.Drawing.Size(40, 25)
        Me.Command1.TabIndex = 41
        Me.Command1.Text = "OK"
        '
        'ChkMAWP
        '
        Me.ChkMAWP.BackColor = System.Drawing.SystemColors.Control
        Me.ChkMAWP.Cursor = System.Windows.Forms.Cursors.Default
        Me.ChkMAWP.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ChkMAWP.Location = New System.Drawing.Point(387, 40)
        Me.ChkMAWP.Name = "ChkMAWP"
        Me.ChkMAWP.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ChkMAWP.Size = New System.Drawing.Size(145, 17)
        Me.ChkMAWP.TabIndex = 40
        Me.ChkMAWP.Text = "MAWP calculations"
        '
        'cmbLoadCase
        '
        Me.cmbLoadCase.BackColor = System.Drawing.SystemColors.Window
        Me.cmbLoadCase.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbLoadCase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLoadCase.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbLoadCase.Location = New System.Drawing.Point(136, 0)
        Me.cmbLoadCase.Name = "cmbLoadCase"
        Me.cmbLoadCase.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbLoadCase.Size = New System.Drawing.Size(121, 21)
        Me.cmbLoadCase.TabIndex = 38
        '
        'cmbUnit
        '
        Me.cmbUnit.BackColor = System.Drawing.SystemColors.Window
        Me.cmbUnit.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbUnit.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbUnit.Location = New System.Drawing.Point(408, 19)
        Me.cmbUnit.Name = "cmbUnit"
        Me.cmbUnit.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbUnit.Size = New System.Drawing.Size(121, 21)
        Me.cmbUnit.TabIndex = 34
        '
        'txtItem
        '
        Me.txtItem.AcceptsReturn = True
        Me.txtItem.AutoSize = False
        Me.txtItem.BackColor = System.Drawing.SystemColors.Window
        Me.txtItem.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtItem.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtItem.Location = New System.Drawing.Point(456, 0)
        Me.txtItem.MaxLength = 0
        Me.txtItem.Name = "txtItem"
        Me.txtItem.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtItem.Size = New System.Drawing.Size(73, 20)
        Me.txtItem.TabIndex = 32
        Me.txtItem.Text = "Text1"
        '
        '_Frames_0
        '
        Me._Frames_0.BackColor = System.Drawing.SystemColors.Control
        Me._Frames_0.Controls.Add(Me._txtNb_1)
        Me._Frames_0.Controls.Add(Me._txtNbLC_1)
        Me._Frames_0.Controls.Add(Me._Text1_12)
        Me._Frames_0.Controls.Add(Me._Text1_11)
        Me._Frames_0.Controls.Add(Me._Text1_10)
        Me._Frames_0.Controls.Add(Me._cmbCode_1)
        Me._Frames_0.Controls.Add(Me._cmbVessMat_1)
        Me._Frames_0.Controls.Add(Me._Text1_0)
        Me._Frames_0.Controls.Add(Me._Text1_1)
        Me._Frames_0.Controls.Add(Me._Text1_2)
        Me._Frames_0.Controls.Add(Me._Text1_3)
        Me._Frames_0.Controls.Add(Me._Text1_4)
        Me._Frames_0.Controls.Add(Me._Text1_5)
        Me._Frames_0.Controls.Add(Me._Text1_6)
        Me._Frames_0.Controls.Add(Me._Text1_7)
        Me._Frames_0.Controls.Add(Me._Text1_8)
        Me._Frames_0.Controls.Add(Me._Text1_9)
        Me._Frames_0.Controls.Add(Me._Check1_1)
        Me._Frames_0.Controls.Add(Me._Label1_26)
        Me._Frames_0.Controls.Add(Me._Label1_22)
        Me._Frames_0.Controls.Add(Me._Label1_1)
        Me._Frames_0.Controls.Add(Me._Label1_0)
        Me._Frames_0.Controls.Add(Me._Label1_3)
        Me._Frames_0.Controls.Add(Me._Label1_4)
        Me._Frames_0.Controls.Add(Me._Label1_5)
        Me._Frames_0.Controls.Add(Me._Label1_6)
        Me._Frames_0.Controls.Add(Me._Label1_7)
        Me._Frames_0.Controls.Add(Me._Label1_8)
        Me._Frames_0.Controls.Add(Me._Label1_9)
        Me._Frames_0.Controls.Add(Me._Label1_10)
        Me._Frames_0.Controls.Add(Me._Label1_11)
        Me._Frames_0.Controls.Add(Me._Label1_12)
        Me._Frames_0.Controls.Add(Me._Label1_13)
        Me._Frames_0.Controls.Add(Me._Label1_14)
        Me._Frames_0.Controls.Add(Me._Label1_15)
        Me._Frames_0.ForeColor = System.Drawing.Color.Red
        Me._Frames_0.Location = New System.Drawing.Point(0, 128)
        Me._Frames_0.Name = "_Frames_0"
        Me._Frames_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Frames_0.Size = New System.Drawing.Size(537, 193)
        Me._Frames_0.TabIndex = 0
        Me._Frames_0.TabStop = False
        Me._Frames_0.Text = "Shell side"
        '
        '_txtNb_1
        '
        Me._txtNb_1.Location = New System.Drawing.Point(376, 152)
        Me._txtNb_1.Name = "_txtNb_1"
        Me._txtNb_1.Size = New System.Drawing.Size(80, 20)
        Me._txtNb_1.TabIndex = 102
        Me._txtNb_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        '_txtNbLC_1
        '
        Me._txtNbLC_1.Location = New System.Drawing.Point(192, 72)
        Me._txtNbLC_1.Name = "_txtNbLC_1"
        Me._txtNbLC_1.Size = New System.Drawing.Size(72, 20)
        Me._txtNbLC_1.TabIndex = 101
        Me._txtNbLC_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        '_Text1_12
        '
        Me._Text1_12.AcceptsReturn = True
        Me._Text1_12.AutoSize = False
        Me._Text1_12.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_12.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_12.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_12.Location = New System.Drawing.Point(192, 168)
        Me._Text1_12.MaxLength = 0
        Me._Text1_12.Name = "_Text1_12"
        Me._Text1_12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_12.Size = New System.Drawing.Size(73, 20)
        Me._Text1_12.TabIndex = 99
        Me._Text1_12.Text = ""
        '
        '_Text1_11
        '
        Me._Text1_11.AcceptsReturn = True
        Me._Text1_11.AutoSize = False
        Me._Text1_11.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_11.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_11.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_11.Location = New System.Drawing.Point(456, 16)
        Me._Text1_11.MaxLength = 0
        Me._Text1_11.Name = "_Text1_11"
        Me._Text1_11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_11.Size = New System.Drawing.Size(73, 20)
        Me._Text1_11.TabIndex = 84
        Me._Text1_11.Text = ""
        '
        '_Text1_10
        '
        Me._Text1_10.AcceptsReturn = True
        Me._Text1_10.AutoSize = False
        Me._Text1_10.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_10.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_10.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_10.Location = New System.Drawing.Point(456, 74)
        Me._Text1_10.MaxLength = 0
        Me._Text1_10.Name = "_Text1_10"
        Me._Text1_10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_10.Size = New System.Drawing.Size(73, 20)
        Me._Text1_10.TabIndex = 37
        Me._Text1_10.Text = ""
        '
        '_cmbCode_1
        '
        Me._cmbCode_1.BackColor = System.Drawing.SystemColors.Window
        Me._cmbCode_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmbCode_1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me._cmbCode_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me._cmbCode_1.Location = New System.Drawing.Point(144, 16)
        Me._cmbCode_1.Name = "_cmbCode_1"
        Me._cmbCode_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmbCode_1.Size = New System.Drawing.Size(121, 21)
        Me._cmbCode_1.TabIndex = 16
        '
        '_cmbVessMat_1
        '
        Me._cmbVessMat_1.BackColor = System.Drawing.SystemColors.Window
        Me._cmbVessMat_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmbVessMat_1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me._cmbVessMat_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me._cmbVessMat_1.Location = New System.Drawing.Point(408, 36)
        Me._cmbVessMat_1.Name = "_cmbVessMat_1"
        Me._cmbVessMat_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmbVessMat_1.Size = New System.Drawing.Size(121, 21)
        Me._cmbVessMat_1.TabIndex = 15
        '
        '_Text1_0
        '
        Me._Text1_0.AcceptsReturn = True
        Me._Text1_0.AutoSize = False
        Me._Text1_0.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_0.Location = New System.Drawing.Point(192, 36)
        Me._Text1_0.MaxLength = 0
        Me._Text1_0.Name = "_Text1_0"
        Me._Text1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_0.Size = New System.Drawing.Size(73, 20)
        Me._Text1_0.TabIndex = 14
        Me._Text1_0.Text = ""
        '
        '_Text1_1
        '
        Me._Text1_1.AcceptsReturn = True
        Me._Text1_1.AutoSize = False
        Me._Text1_1.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_1.Location = New System.Drawing.Point(192, 55)
        Me._Text1_1.MaxLength = 0
        Me._Text1_1.Name = "_Text1_1"
        Me._Text1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_1.Size = New System.Drawing.Size(73, 20)
        Me._Text1_1.TabIndex = 13
        Me._Text1_1.Text = ""
        '
        '_Text1_2
        '
        Me._Text1_2.AcceptsReturn = True
        Me._Text1_2.AutoSize = False
        Me._Text1_2.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_2.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_2.Location = New System.Drawing.Point(456, 55)
        Me._Text1_2.MaxLength = 0
        Me._Text1_2.Name = "_Text1_2"
        Me._Text1_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_2.Size = New System.Drawing.Size(73, 20)
        Me._Text1_2.TabIndex = 12
        Me._Text1_2.Text = ""
        '
        '_Text1_3
        '
        Me._Text1_3.AcceptsReturn = True
        Me._Text1_3.AutoSize = False
        Me._Text1_3.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_3.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_3.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_3.Location = New System.Drawing.Point(192, 93)
        Me._Text1_3.MaxLength = 0
        Me._Text1_3.Name = "_Text1_3"
        Me._Text1_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_3.Size = New System.Drawing.Size(73, 20)
        Me._Text1_3.TabIndex = 9
        Me._Text1_3.Text = ""
        '
        '_Text1_4
        '
        Me._Text1_4.AcceptsReturn = True
        Me._Text1_4.AutoSize = False
        Me._Text1_4.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_4.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_4.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_4.Location = New System.Drawing.Point(456, 93)
        Me._Text1_4.MaxLength = 0
        Me._Text1_4.Name = "_Text1_4"
        Me._Text1_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_4.Size = New System.Drawing.Size(73, 20)
        Me._Text1_4.TabIndex = 8
        Me._Text1_4.Text = ""
        '
        '_Text1_5
        '
        Me._Text1_5.AcceptsReturn = True
        Me._Text1_5.AutoSize = False
        Me._Text1_5.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_5.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_5.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_5.Location = New System.Drawing.Point(192, 112)
        Me._Text1_5.MaxLength = 0
        Me._Text1_5.Name = "_Text1_5"
        Me._Text1_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_5.Size = New System.Drawing.Size(73, 20)
        Me._Text1_5.TabIndex = 7
        Me._Text1_5.Text = ""
        '
        '_Text1_6
        '
        Me._Text1_6.AcceptsReturn = True
        Me._Text1_6.AutoSize = False
        Me._Text1_6.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_6.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_6.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_6.Location = New System.Drawing.Point(456, 112)
        Me._Text1_6.MaxLength = 0
        Me._Text1_6.Name = "_Text1_6"
        Me._Text1_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_6.Size = New System.Drawing.Size(73, 20)
        Me._Text1_6.TabIndex = 6
        Me._Text1_6.Text = ""
        '
        '_Text1_7
        '
        Me._Text1_7.AcceptsReturn = True
        Me._Text1_7.AutoSize = False
        Me._Text1_7.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_7.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_7.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_7.Location = New System.Drawing.Point(320, 131)
        Me._Text1_7.MaxLength = 0
        Me._Text1_7.Name = "_Text1_7"
        Me._Text1_7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_7.Size = New System.Drawing.Size(49, 20)
        Me._Text1_7.TabIndex = 5
        Me._Text1_7.Text = ""
        '
        '_Text1_8
        '
        Me._Text1_8.AcceptsReturn = True
        Me._Text1_8.AutoSize = False
        Me._Text1_8.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_8.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_8.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_8.Location = New System.Drawing.Point(480, 131)
        Me._Text1_8.MaxLength = 0
        Me._Text1_8.Name = "_Text1_8"
        Me._Text1_8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_8.Size = New System.Drawing.Size(49, 20)
        Me._Text1_8.TabIndex = 4
        Me._Text1_8.Text = ""
        '
        '_Text1_9
        '
        Me._Text1_9.AcceptsReturn = True
        Me._Text1_9.AutoSize = False
        Me._Text1_9.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_9.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_9.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_9.Location = New System.Drawing.Point(192, 152)
        Me._Text1_9.MaxLength = 0
        Me._Text1_9.Name = "_Text1_9"
        Me._Text1_9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_9.Size = New System.Drawing.Size(73, 20)
        Me._Text1_9.TabIndex = 3
        Me._Text1_9.Text = ""
        '
        '_Check1_1
        '
        Me._Check1_1.BackColor = System.Drawing.SystemColors.Control
        Me._Check1_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._Check1_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Check1_1.Location = New System.Drawing.Point(8, 132)
        Me._Check1_1.Name = "_Check1_1"
        Me._Check1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Check1_1.Size = New System.Drawing.Size(201, 17)
        Me._Check1_1.TabIndex = 1
        Me._Check1_1.Text = "Design under external pressure"
        '
        '_Label1_26
        '
        Me._Label1_26.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_26.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_26.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_26.Location = New System.Drawing.Point(8, 169)
        Me._Label1_26.Name = "_Label1_26"
        Me._Label1_26.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_26.Size = New System.Drawing.Size(169, 17)
        Me._Label1_26.TabIndex = 100
        Me._Label1_26.Text = "Joint efficiency"
        '
        '_Label1_22
        '
        Me._Label1_22.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_22.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_22.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_22.Location = New System.Drawing.Point(272, 16)
        Me._Label1_22.Name = "_Label1_22"
        Me._Label1_22.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_22.Size = New System.Drawing.Size(144, 17)
        Me._Label1_22.TabIndex = 83
        Me._Label1_22.Text = "Corrosion allowance"
        '
        '_Label1_1
        '
        Me._Label1_1.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_1.Location = New System.Drawing.Point(272, 75)
        Me._Label1_1.Name = "_Label1_1"
        Me._Label1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_1.Size = New System.Drawing.Size(153, 17)
        Me._Label1_1.TabIndex = 36
        Me._Label1_1.Text = "Test Pressure"
        '
        '_Label1_0
        '
        Me._Label1_0.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_0.Location = New System.Drawing.Point(8, 16)
        Me._Label1_0.Name = "_Label1_0"
        Me._Label1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_0.Size = New System.Drawing.Size(121, 17)
        Me._Label1_0.TabIndex = 31
        Me._Label1_0.Text = "Design according to:"
        '
        '_Label1_3
        '
        Me._Label1_3.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_3.Location = New System.Drawing.Point(272, 37)
        Me._Label1_3.Name = "_Label1_3"
        Me._Label1_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_3.Size = New System.Drawing.Size(105, 17)
        Me._Label1_3.TabIndex = 30
        Me._Label1_3.Text = "Vessel material"
        '
        '_Label1_4
        '
        Me._Label1_4.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_4.Location = New System.Drawing.Point(8, 37)
        Me._Label1_4.Name = "_Label1_4"
        Me._Label1_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_4.Size = New System.Drawing.Size(169, 17)
        Me._Label1_4.TabIndex = 29
        Me._Label1_4.Text = "Vessel Inner dia."
        '
        '_Label1_5
        '
        Me._Label1_5.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_5.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_5.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_5.Location = New System.Drawing.Point(8, 56)
        Me._Label1_5.Name = "_Label1_5"
        Me._Label1_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_5.Size = New System.Drawing.Size(177, 17)
        Me._Label1_5.TabIndex = 28
        Me._Label1_5.Text = "Design Pressure"
        '
        '_Label1_6
        '
        Me._Label1_6.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_6.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_6.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_6.Location = New System.Drawing.Point(272, 56)
        Me._Label1_6.Name = "_Label1_6"
        Me._Label1_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_6.Size = New System.Drawing.Size(153, 17)
        Me._Label1_6.TabIndex = 27
        Me._Label1_6.Text = "Design Temperature"
        '
        '_Label1_7
        '
        Me._Label1_7.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_7.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_7.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_7.Location = New System.Drawing.Point(8, 76)
        Me._Label1_7.Name = "_Label1_7"
        Me._Label1_7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_7.Size = New System.Drawing.Size(161, 17)
        Me._Label1_7.TabIndex = 26
        Me._Label1_7.Text = "Nb. of low temp. conditions"
        '
        '_Label1_8
        '
        Me._Label1_8.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_8.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_8.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_8.Location = New System.Drawing.Point(8, 94)
        Me._Label1_8.Name = "_Label1_8"
        Me._Label1_8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_8.Size = New System.Drawing.Size(177, 17)
        Me._Label1_8.TabIndex = 25
        Me._Label1_8.Text = "Minimum Des.Temp."
        '
        '_Label1_9
        '
        Me._Label1_9.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_9.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_9.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_9.Location = New System.Drawing.Point(272, 94)
        Me._Label1_9.Name = "_Label1_9"
        Me._Label1_9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_9.Size = New System.Drawing.Size(153, 17)
        Me._Label1_9.TabIndex = 24
        Me._Label1_9.Text = "Coincident Pressure"
        '
        '_Label1_10
        '
        Me._Label1_10.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_10.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_10.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_10.Location = New System.Drawing.Point(8, 114)
        Me._Label1_10.Name = "_Label1_10"
        Me._Label1_10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_10.Size = New System.Drawing.Size(177, 17)
        Me._Label1_10.TabIndex = 23
        Me._Label1_10.Text = "Minimum Des.Temp."
        '
        '_Label1_11
        '
        Me._Label1_11.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_11.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_11.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_11.Location = New System.Drawing.Point(272, 114)
        Me._Label1_11.Name = "_Label1_11"
        Me._Label1_11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_11.Size = New System.Drawing.Size(153, 17)
        Me._Label1_11.TabIndex = 22
        Me._Label1_11.Text = "Coincident Pressure"
        '
        '_Label1_12
        '
        Me._Label1_12.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_12.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_12.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_12.Location = New System.Drawing.Point(216, 134)
        Me._Label1_12.Name = "_Label1_12"
        Me._Label1_12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_12.Size = New System.Drawing.Size(97, 17)
        Me._Label1_12.TabIndex = 21
        Me._Label1_12.Text = "Ext.Press."
        '
        '_Label1_13
        '
        Me._Label1_13.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_13.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_13.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_13.Location = New System.Drawing.Point(376, 134)
        Me._Label1_13.Name = "_Label1_13"
        Me._Label1_13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_13.Size = New System.Drawing.Size(105, 17)
        Me._Label1_13.TabIndex = 20
        Me._Label1_13.Text = "Coinc.Temp."
        '
        '_Label1_14
        '
        Me._Label1_14.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_14.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_14.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_14.Location = New System.Drawing.Point(8, 153)
        Me._Label1_14.Name = "_Label1_14"
        Me._Label1_14.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_14.Size = New System.Drawing.Size(177, 17)
        Me._Label1_14.TabIndex = 19
        Me._Label1_14.Text = "Relative density of contained fluid"
        '
        '_Label1_15
        '
        Me._Label1_15.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_15.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_15.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_15.Location = New System.Drawing.Point(272, 153)
        Me._Label1_15.Name = "_Label1_15"
        Me._Label1_15.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_15.Size = New System.Drawing.Size(177, 17)
        Me._Label1_15.TabIndex = 18
        Me._Label1_15.Text = "Number of members"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(171, 41)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(46, 19)
        Me.Label3.TabIndex = 93
        Me.Label3.Text = "Method:"
        Me.Label3.Visible = False
        '
        'lblLati
        '
        Me.lblLati.BackColor = System.Drawing.SystemColors.Control
        Me.lblLati.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblLati.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLati.Location = New System.Drawing.Point(0, 24)
        Me.lblLati.Name = "lblLati"
        Me.lblLati.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblLati.Size = New System.Drawing.Size(89, 17)
        Me.lblLati.TabIndex = 42
        Me.lblLati.Text = "Number of sides"
        '
        'lblLC
        '
        Me.lblLC.BackColor = System.Drawing.SystemColors.Control
        Me.lblLC.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblLC.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLC.Location = New System.Drawing.Point(0, 0)
        Me.lblLC.Name = "lblLC"
        Me.lblLC.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblLC.Size = New System.Drawing.Size(105, 17)
        Me.lblLC.TabIndex = 39
        Me.lblLC.Text = "Load Case"
        '
        'lblUnit
        '
        Me.lblUnit.BackColor = System.Drawing.SystemColors.Control
        Me.lblUnit.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblUnit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblUnit.Location = New System.Drawing.Point(272, 20)
        Me.lblUnit.Name = "lblUnit"
        Me.lblUnit.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblUnit.Size = New System.Drawing.Size(105, 17)
        Me.lblUnit.TabIndex = 35
        Me.lblUnit.Text = "Unit system"
        '
        '_lblItem_16
        '
        Me._lblItem_16.BackColor = System.Drawing.SystemColors.Control
        Me._lblItem_16.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblItem_16.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblItem_16.Location = New System.Drawing.Point(272, 0)
        Me._lblItem_16.Name = "_lblItem_16"
        Me._lblItem_16.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblItem_16.Size = New System.Drawing.Size(153, 17)
        Me._lblItem_16.TabIndex = 33
        Me._lblItem_16.Text = "Item number"
        '
        'PulsPI
        '
        Me.PulsPI.Location = New System.Drawing.Point(160, 84)
        Me.PulsPI.Name = "PulsPI"
        Me.PulsPI.Size = New System.Drawing.Size(28, 28)
        Me.PulsPI.TabIndex = 102
        Me.PulsPI.Text = "Off"
        '
        'HelpProvider1
        '
        Me.HelpProvider1.HelpNamespace = "bin\AsmeVip.chm"
        '
        'frmGen
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.CancelButton = Me.Command1
        Me.ClientSize = New System.Drawing.Size(537, 554)
        Me.Controls.Add(Me.PulsPI)
        Me.Controls.Add(Me.chkPIverif)
        Me.Controls.Add(Me.cmbMetodoPI)
        Me.Controls.Add(Me.chkHTVert)
        Me.Controls.Add(Me.Frame1)
        Me.Controls.Add(Me.chKDiversi)
        Me.Controls.Add(Me.chkPI)
        Me.Controls.Add(Me._Frames_2)
        Me.Controls.Add(Me._Frames_1)
        Me.Controls.Add(Me._NLati_2)
        Me.Controls.Add(Me.txtItem)
        Me.Controls.Add(Me._NLati_1)
        Me.Controls.Add(Me.Command1)
        Me.Controls.Add(Me.ChkMAWP)
        Me.Controls.Add(Me.cmbLoadCase)
        Me.Controls.Add(Me.cmbUnit)
        Me.Controls.Add(Me._Frames_0)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblLati)
        Me.Controls.Add(Me.lblLC)
        Me.Controls.Add(Me.lblUnit)
        Me.Controls.Add(Me._lblItem_16)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.HelpButton = True
        Me.Location = New System.Drawing.Point(3, 23)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmGen"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "Dati generali"
        Me.Frame1.ResumeLayout(False)
        Me._Frames_2.ResumeLayout(False)
        CType(Me._txtNb_3, System.ComponentModel.ISupportInitialize).EndInit()
        Me._Frames_1.ResumeLayout(False)
        CType(Me._txtNb_2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._txtNbLC_2, System.ComponentModel.ISupportInitialize).EndInit()
        Me._Frames_0.ResumeLayout(False)
        CType(Me._txtNb_1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._txtNbLC_1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
#End Region
#Region "Supporto aggiornamento "
    '  Private Shared m_vb6FormDefInstance As frmGen
    '  Private Shared m_InitializingDefInstance As Boolean
    '  Public Shared Property DefInstance() As frmGen
    '      Get
    '          If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
    '              m_InitializingDefInstance = True
    '              m_vb6FormDefInstance = New frmGen
    '              m_InitializingDefInstance = False
    '          End If
    '          DefInstance = m_vb6FormDefInstance
    '      End Get
    '      Set(ByVal Value As frmGen)
    '          m_vb6FormDefInstance = Value
    '      End Set
    '  End Property
#End Region
    Private Inizializzando As Boolean
    Friend ReadOnly Property Check1(ByVal i As Short) As CheckBox
        Get
            Select Case i
                Case 1 : Return _Check1_1
                Case 2 : Return _Check1_2
                Case Else : Return Nothing
            End Select
        End Get
    End Property
    Public Sub Inizializza()
        Top = GlobalRoutines.TwipsToPixelsY(660)
        Left = GlobalRoutines.TwipsToPixelsX(2835)
        FillDatiGenerali()
        cmbSpecial.Items.Add("None")
        cmbSpecial.Items.Add("100% of vessel thk. reinforced")
        Label1(12).Visible = Config(1).Vacuum
        Label1(13).Visible = Config(1).Vacuum
        Text1(7).Visible = Config(1).Vacuum
        Text1(8).Visible = Config(1).Vacuum
        Label1(12 + 20).Visible = Config(2).Vacuum
        Label1(13 + 20).Visible = Config(2).Vacuum
        Text1(7 + 20).Visible = Config(2).Vacuum
        Text1(8 + 20).Visible = Config(2).Vacuum
        If Config(0).VerifPI = 1 Then
            If Not Config(0).VerificandoPI = 0 Then PulsPI.Text = "On" Else PulsPI.Text = "Off"
            Me.PulsPI_Click(Me, New EventArgs)
            AggChkPI()
        Else
            PulsPI.Visible = False
        End If
        txtItem.Enabled = clsInizio.LavoriSciolti
        If Config(0).SpecialRinf < 0 Or Config(0).SpecialRinf > 1 Then Config(0).SpecialRinf = 0
        cmbSpecial.SelectedIndex = Config(0).SpecialRinf
        txtNbLC_TextChanged(1, True)
        txtNbLC_TextChanged(2, True)
        HelpProvider1.HelpNamespace = RadiceHelp
    End Sub
    Private Sub Check1_CheckStateChanged(ByVal Index As Short)
        Config(Index).Vacuum = (Check1(Index).CheckState = 1)
        Label1(12 + (Index - 1) * 20).Visible = Config(Index).Vacuum
        Label1(13 + (Index - 1) * 20).Visible = Config(Index).Vacuum
        Text1(7 + (Index - 1) * 20).Visible = Config(Index).Vacuum
        Text1(8 + (Index - 1) * 20).Visible = Config(Index).Vacuum
        If Config(Index).Vacuum Then
            If Config(Index).pxExt = 0 Then
                Config(Index).pxExt = 0.103
            End If
        End If
    End Sub
    Private Sub chKDiversi_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chKDiversi.CheckStateChanged
        If Inizializzando Then Exit Sub
        Config(0).DiverseTemp = chKDiversi.CheckState
    End Sub
    Private Sub chkHTVert_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkHTVert.CheckStateChanged
        If Inizializzando Then Exit Sub
        Config(0).HTTestVert = chkHTVert.CheckState
    End Sub
    Private Sub ChkMAWP_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ChkMAWP.CheckStateChanged
        If Inizializzando Then Exit Sub
        Config(0).CalcMAWP = ChkMAWP.CheckState
    End Sub
    Private Sub chkPI_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkPI.CheckStateChanged
        If Inizializzando Then Exit Sub
        Config(0).CalcPI = chkPI.CheckState
        AggChkPI()
    End Sub
    Private Sub AggChkPI()
        Dim k, j As Short
        Dim O As wn_flan
        If Config(0).CalcPI = 0 Then
            For k = 1 To 3
                For j = 1 To Config(k).Ninvolucri
                    If Involucr(k, j).IndObject > -1 Then
                        If Involucr(k, j).Tipo = 5 Then
                            O = objMemb(Involucr(k, j).IndObject)
                            If Not O Is Nothing Then
                                If O.TipCalc = 3 Then O.TipCalc = 2
                            End If
                        End If
                    End If
                Next
            Next
            chkHTVert.Visible = False
            chkPIverif.Visible = False
            Label3.Visible = False
            cmbMetodoPI.Visible = False
            PulsPI.Visible = False
            Config(0).VerifPI = 0
            Config(0).VerificandoPI = 0
            VerificandoPI = False
        Else
            chkHTVert.Visible = True
            chkPIverif.Visible = True
            Label3.Visible = True
            cmbMetodoPI.Visible = True
        End If
    End Sub
    Private Sub chkPIverif_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkPIverif.CheckStateChanged
        If Inizializzando Then Exit Sub
        Config(0).VerifPI = CShort(chkPIverif.CheckState)
        PulsPI.Visible = Config(0).VerifPI = 1
        If Config(0).VerifPI = 1 Then
            If Not Config(0).VerificandoPI = 0 Then PulsPI.Text = "On" Else PulsPI.Text = "Off"
            Me.PulsPI_Click(Me, New EventArgs)
        Else
            Config(0).VerificandoPI = 0
        End If
        VerificandoPI = CBool(Config(0).VerificandoPI)
    End Sub
    Friend ReadOnly Property cmbCode(ByVal i As Short) As ComboBox
        Get
            Select Case i
                Case 1 : Return _cmbCode_1
                Case 2 : Return _cmbCode_2
                Case 3 : Return _cmbCode_3
                Case Else : Return Nothing
            End Select
        End Get
    End Property
    'UPGRADE_WARNING: L'evento cmbCode.SelectedIndexChanged può essere generato quando il form è inizializzato. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup2075"'
    Private Sub cmbCode_SelectedIndexChanged(ByVal Index As Short)
        Config(Index).DC = cmbCode(Index).SelectedIndex
        Select Case Config(Index).DC
            Case 0 To 5, 9 To 11
                Select Case Index
                    Case 1
                        Label1(5).Text = "Design Pressure"
                        Label1(6).Text = "Design Temperature"
                        Label1(8).Text = "Minimum Des. Temperature"
                        Label1(10).Text = "Minimum Des. Temperature"
                    Case 2
                        Label1(19).Text = "Design Pressure"
                        Label1(20).Text = "Design Temperature"
                        Label1(28).Text = "Minimum Des. Temperature"
                        Label1(30).Text = "Minimum Des. Temperature"
                End Select
                mioApert.Check1.Enabled = True
            Case 6 To 8
                div = 2
                Select Case Index
                    Case 1
                        Label1(5).Text = "Calculation Pressure"
                        Label1(6).Text = "Calculation Temperature"
                        Label1(8).Text = "Minimum Calc. Temperature"
                        Label1(10).Text = "Minimum Calc. Temperature"
                    Case 2
                        Label1(19).Text = "Calculation Pressure"
                        Label1(20).Text = "Calculation Temperature"
                        Label1(28).Text = "Minimum Calc. Temperature"
                        Label1(30).Text = "Minimum Calc. Temperature"
                End Select
                mioApert.Check1.CheckState = System.Windows.Forms.CheckState.Checked
                mioApert.Check1.Enabled = False
        End Select
        ModifiedData = True
        AggMetodo()
    End Sub
    Private Sub cmbLoadCase_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbLoadCase.SelectedIndexChanged
        If Inizializzando Then Exit Sub
        Config(0).lkStr = cmbLoadCase.SelectedItem
        If Config(0).VerifPI = 1 Then
            If cmbLoadCase.SelectedIndex = 2 Then PulsPI.Text = "On" Else PulsPI.Text = "Off"
        End If
        ModifiedData = True
    End Sub
    Private Sub cmbMetodoPI_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbMetodoPI.SelectedIndexChanged
        If Inizializzando Then Exit Sub
        Config(0).MetodoPI = cmbMetodoPI.SelectedIndex
        If Config(0).MetodoPI = 1 Then
            ChkMAWP.CheckState = System.Windows.Forms.CheckState.Checked
            ChkMAWP.Enabled = False
        Else
            ChkMAWP.Enabled = True
        End If
    End Sub
    Private Sub cmbSpecial_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbSpecial.SelectedIndexChanged
        If Inizializzando Then Exit Sub
        Config(0).SpecialRinf = cmbSpecial.SelectedIndex
    End Sub
    Private Sub cmbUnit_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbUnit.SelectedIndexChanged
        If Inizializzando Then Exit Sub
        Dim Dimen, i As Short
        Try
            Config(0).US = cmbUnit.SelectedIndex
            AdjUnit()
            AggDatiTesto()
            Try
                Dimen = UBound(objMemb)
            Catch
                Exit Sub
            End Try
            For i = 1 To Dimen
                objMemb(i).UniMis = Config(0).US
            Next
        Catch e As Exception
            MessageBox.Show(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Friend ReadOnly Property cmbVessMat(ByVal i As Short) As ComboBox
        Get
            Select Case i
                Case 1 : Return _cmbVessMat_1
                Case 2 : Return _cmbVessMat_2
                Case Else : Return Nothing
            End Select
        End Get
    End Property
    Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
        Dim n As Short
        n = 1 : If Config(0).NumeroLati > 1 Then n = 2
        Hide()
        Aggiorna()
        Me.Close()
    End Sub
    Friend ReadOnly Property NLati(ByVal i As Short) As RadioButton
        Get
            Select Case i
                Case 1 : Return _NLati_1
                Case 2 : Return _NLati_2
                Case Else : Return Nothing
            End Select
        End Get
    End Property
    Public Sub NLati_CheckedChanged(ByVal Index As Short, ByVal Checked As Boolean)
        If Inizializzando Then Exit Sub
        If Checked Then
            Dim n As Short
            Dim Testo As String
            n = Index : If n = 2 Then n = 3
            If n = 1 And (Config(2).Ninvolucri > 0 Or Config(3).Ninvolucri) > 0 Then
                Testo = "Così facendo andranno persi i dati relativi|"
                Testo = Testo & "alle membrature sul secondo e terzo lato.||Continuare ?"
                Testo = clsInizio.ConvertiCr(Testo)
                If MessageBox.Show(Testo, "AsmeVip", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = System.Windows.Forms.DialogResult.No Then Exit Sub
            End If
            Config(0).NumeroLati = n
            _Frames_1.Visible = n = 3
            _Frames_2.Visible = n = 3
            If n = 1 Then
                _Frames_0.Text = ""
                Command1.Top = _Frames_0.Top + 8 + _Frames_0.Height
                UnLato = True
            Else
                _Frames_0.Text = "Lato Mantello"
                _Frames_1.Text = "Lato Tubi"
                _Frames_2.Text = "Fra i due"
                Command1.Top = _Frames_2.Top + 8 + _Frames_2.Height
                UnLato = False
            End If
            Height = Command1.Top + Command1.Height + 40
            DatiInputC(1)
        End If
    End Sub
    Private Sub Text1_TextChanged(ByVal Index As Short)
        If Inizializzando Then Exit Sub
        Dim KL, Ind As Short
        Ind = Index Mod 20
        If Index < 20 Then KL = 1 Else KL = 2
        Try
            Select Case Ind
                Case 0 : Config(KL).di = GlobalRoutines.ValVir(Text1(Index).Text) / kLength
                Case 1 : Config(KL).p0x = GlobalRoutines.ValVir(Text1(Index).Text) / kPress
                Case 2 : Config(KL).tdx = (GlobalRoutines.ValVir(Text1(Index).Text) - kTemp32) / kTemp
                Case 3 : Config(KL).tdxMDMT(0) = (GlobalRoutines.ValVir(Text1(Index).Text) - kTemp32) / kTemp
                Case 4 : Config(KL).pdxMDMT(0) = (GlobalRoutines.ValVir(Text1(Index).Text) - kTemp32) / kTemp
                Case 5 : Config(KL).tdxMDMT(1) = (GlobalRoutines.ValVir(Text1(Index).Text) - kTemp32) / kTemp
                Case 6 : Config(KL).pdxMDMT(1) = (GlobalRoutines.ValVir(Text1(Index).Text) - kTemp32) / kTemp
                Case 7 : Config(KL).pxExt = GlobalRoutines.ValVir(Text1(Index).Text) / kPress
                Case 8 : Config(KL).txExt = (GlobalRoutines.ValVir(Text1(Index).Text) - kTemp32) / kTemp
                Case 9 : Config(KL).DensFluido = GlobalRoutines.ValVir(Text1(Index).Text)
                Case 10 : Config(KL).pxTest = GlobalRoutines.ValVir(Text1(Index).Text) / kPress
                Case 11 : Config(KL).Corr = GlobalRoutines.ValVir(Text1(Index).Text) / kLength
                Case 12 : Config(KL).Efficienza = GlobalRoutines.ValVir(Text1(Index).Text)
            End Select
        Catch e As Exception
            MessageBox.Show(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Friend ReadOnly Property Label1(ByVal i As Short) As Label
        Get
            Select Case i
                Case 0 : Return _Label1_0
                Case 1 : Return _Label1_1
                Case 2 : Return _Label1_2
                Case 3 : Return _Label1_3
                Case 4 : Return _Label1_4
                Case 5 : Return _Label1_5
                Case 6 : Return _Label1_6
                Case 7 : Return _Label1_7
                Case 8 : Return _Label1_8
                Case 9 : Return _Label1_9
                Case 10 : Return _Label1_10
                Case 11 : Return _Label1_11
                Case 12 : Return _Label1_12
                Case 13 : Return _Label1_13
                Case 14 : Return _Label1_14
                Case 15 : Return _Label1_15
                Case 16 : Return _Label1_16
                Case 17 : Return _Label1_17
                Case 18 : Return _Label1_18
                Case 19 : Return _Label1_19
                Case 20 : Return _Label1_20
                Case 21 : Return _Label1_21
                Case 22 : Return _Label1_22
                Case 23 : Return _Label1_23
                Case 24 : Return _Label1_24
                Case 25 : Return _Label1_25
                Case 26 : Return _Label1_26
                Case 28 : Return _Label1_28
                Case 29 : Return _Label1_29
                Case 30 : Return _Label1_30
                Case 31 : Return _Label1_31
                Case 32 : Return _Label1_32
                Case 33 : Return _Label1_33
                Case 34 : Return _Label1_34
                Case 35 : Return _Label1_35
                Case 55 : Return _Label1_55
                Case Else : Return Nothing
            End Select
        End Get
    End Property
    Friend ReadOnly Property Text1(ByVal i As Short) As TextBox
        Get
            Select Case i
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
                Case 10 : Return _Text1_10
                Case 11 : Return _Text1_11
                Case 12 : Return _Text1_12
                Case 20 : Return _Text1_20
                Case 21 : Return _Text1_21
                Case 22 : Return _Text1_22
                Case 23 : Return _Text1_23
                Case 24 : Return _Text1_24
                Case 25 : Return _Text1_25
                Case 26 : Return _Text1_26
                Case 27 : Return _Text1_27
                Case 28 : Return _Text1_28
                Case 29 : Return _Text1_29
                Case 30 : Return _Text1_30
                Case 31 : Return _Text1_31
                Case 32 : Return _Text1_32
                Case Else : Return Nothing
            End Select
        End Get
    End Property
    Private Sub txtItem_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtItem.TextChanged
        If Inizializzando Then Exit Sub
        Config(0).Item = txtItem.Text
    End Sub
    Friend ReadOnly Property txtNb(ByVal i As Short) As NumericUpDown
        Get
            Select Case i
                Case 1 : Return _txtNb_1
                Case 2 : Return _txtNb_2
                Case 3 : Return _txtNb_3
                Case Else : Return Nothing
            End Select
        End Get
    End Property
    Private Sub txtNb_TextChanged(ByVal Index As Short)
        If Inizializzando Then Exit Sub
        Dim n, k As Short
        n = txtNb(Index).Value
        If n > Config(Index).Ninvolucri Then
            Ridimensiona(n)
            For k = Config(Index).Ninvolucri + 1 To n
                Introduci(Index, k)
            Next
            Config(Index).Ninvolucri = n
            AggDatiGenerali()
        ElseIf n < Config(Index).Ninvolucri Then
            Dim Testo As String = clsInizio.ConvertiCr("Per eliminare una membratura:|selezionarla sulla struttura e accedere|al menu 'Elimina'")
            Dim Titolo As String = "Eliminazione membratura"
            MessageBox.Show(Testo, Titolo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtNb(Index).Value = Config(Index).Ninvolucri
        End If
    End Sub
    Friend ReadOnly Property txtNbLC(ByVal i As Short) As NumericUpDown
        Get
            Select Case i
                Case 1 : Return _txtNbLC_1
                Case 2 : Return _txtNbLC_2
                Case Else : Return Nothing
            End Select
        End Get
    End Property
    Private Sub txtNbLC_TextChanged(ByVal Index As Short, Optional ByVal Init As Boolean = False)
        If Inizializzando Then Exit Sub
        Dim Vecchio As Short
        Vecchio = Config(Index).NMWDT
        If Not Init Then Config(Index).NMWDT = txtNbLC(Index).Value
        Select Case Config(Index).NMWDT
            Case 0
                Label1(8 + (Index - 1) * 20).Visible = False
                Label1(9 + (Index - 1) * 20).Visible = False
                Label1(10 + (Index - 1) * 20).Visible = False
                Label1(11 + (Index - 1) * 20).Visible = False
                Text1(3 + (Index - 1) * 20).Visible = False
                Text1(4 + (Index - 1) * 20).Visible = False
                Text1(5 + (Index - 1) * 20).Visible = False
                Text1(6 + (Index - 1) * 20).Visible = False
            Case 1
                If Vecchio = 0 Then AggMWDTdata(Index)
                Label1(8 + (Index - 1) * 20).Visible = True
                Label1(9 + (Index - 1) * 20).Visible = True
                Label1(10 + (Index - 1) * 20).Visible = False
                Label1(11 + (Index - 1) * 20).Visible = False
                Text1(3 + (Index - 1) * 20).Visible = True
                Text1(4 + (Index - 1) * 20).Visible = True
                Text1(5 + (Index - 1) * 20).Visible = False
                Text1(6 + (Index - 1) * 20).Visible = False
            Case 2
                If Vecchio = 0 Then AggMWDTdata(Index)
                Label1(8 + (Index - 1) * 20).Visible = True
                Label1(9 + (Index - 1) * 20).Visible = True
                Label1(10 + (Index - 1) * 20).Visible = True
                Label1(11 + (Index - 1) * 20).Visible = True
                Text1(3 + (Index - 1) * 20).Visible = True
                Text1(4 + (Index - 1) * 20).Visible = True
                Text1(5 + (Index - 1) * 20).Visible = True
                Text1(6 + (Index - 1) * 20).Visible = True
        End Select
    End Sub

    Private Sub PulsPI_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PulsPI.Click
        If PulsPI.Text = "On" Then
            PulsPI.Text = "Off"
            PulsPI.BackColor = Color.FromKnownColor(KnownColor.Control)
            VerificandoPI = False
            cmbLoadCase.SelectedIndex = 0
        Else
            PulsPI.Text = "On"
            PulsPI.BackColor = Color.FromKnownColor(KnownColor.Gold)
            VerificandoPI = True
            cmbLoadCase.SelectedIndex = 2
        End If
        Config(0).VerificandoPI = CShort(VerificandoPI)
        CondizioniCorrose = 1 + CShort(VerificandoPI)
    End Sub

    Private Sub _Check1_1_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Check1_1.CheckStateChanged
        Check1_CheckStateChanged(1)
    End Sub

    Private Sub _Check1_2_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Check1_2.CheckStateChanged
        Check1_CheckStateChanged(2)
    End Sub

    Private Sub _NLati_1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _NLati_1.CheckedChanged
        NLati_CheckedChanged(1, sender.Checked)
    End Sub

    Private Sub _NLati_2_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _NLati_2.CheckedChanged
        NLati_CheckedChanged(2, sender.Checked)
    End Sub

    Private Sub _cmbCode_1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmbCode_1.SelectedIndexChanged
        cmbCode_SelectedIndexChanged(1)
    End Sub

    Private Sub _cmbCode_2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmbCode_2.SelectedIndexChanged
        cmbCode_SelectedIndexChanged(2)
    End Sub

    Private Sub _cmbCode_3_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmbCode_3.SelectedIndexChanged
        cmbCode_SelectedIndexChanged(3)
    End Sub

    Private Sub _cmbVessMat_1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmbVessMat_1.SelectedIndexChanged
        Config(1).mv = _cmbVessMat_1.SelectedIndex
    End Sub

    Private Sub _cmbVessMat_2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmbVessMat_2.SelectedIndexChanged
        Config(2).mv = _cmbVessMat_2.SelectedIndex
    End Sub

    Private Sub _txtNb_1_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtNb_1.ValueChanged
        txtNb_TextChanged(1)
    End Sub

    Private Sub _txtNb_2_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtNb_2.ValueChanged
        txtNb_TextChanged(2)
    End Sub

    Private Sub _txtNb_3_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtNb_3.ValueChanged
        txtNb_TextChanged(3)
    End Sub

    Private Sub _txtNbLC_1_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtNbLC_1.ValueChanged
        txtNbLC_TextChanged(1)
    End Sub

    Private Sub _txtNbLC_2_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtNbLC_2.ValueChanged
        txtNbLC_TextChanged(2)
    End Sub

    Private Sub _Text1_0_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Text1_0.TextChanged
        Text1_TextChanged(0)
    End Sub
    Private Sub _Text1_1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Text1_1.TextChanged
        Text1_TextChanged(1)
    End Sub
    Private Sub _Text1_2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Text1_2.TextChanged
        Text1_TextChanged(2)
    End Sub
    Private Sub _Text1_3_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Text1_3.TextChanged
        Text1_TextChanged(3)
    End Sub
    Private Sub _Text1_4_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Text1_4.TextChanged
        Text1_TextChanged(4)
    End Sub
    Private Sub _Text1_5_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Text1_5.TextChanged
        Text1_TextChanged(5)
    End Sub
    Private Sub _Text1_6_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Text1_6.TextChanged
        Text1_TextChanged(6)
    End Sub
    Private Sub _Text1_7_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Text1_7.TextChanged
        Text1_TextChanged(7)
    End Sub
    Private Sub _Text1_8_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Text1_8.TextChanged
        Text1_TextChanged(8)
    End Sub
    Private Sub _Text1_9_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Text1_9.TextChanged
        Text1_TextChanged(9)
    End Sub
    Private Sub _Text1_10_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Text1_10.TextChanged
        Text1_TextChanged(10)
    End Sub
    Private Sub _Text1_11_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Text1_11.TextChanged
        Text1_TextChanged(11)
    End Sub
    Private Sub _Text1_12_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Text1_12.TextChanged
        Text1_TextChanged(12)
    End Sub
    Private Sub _Text1_20_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Text1_20.TextChanged
        Text1_TextChanged(20)
    End Sub
    Private Sub _Text1_21_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Text1_21.TextChanged
        Text1_TextChanged(21)
    End Sub
    Private Sub _Text1_22_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Text1_22.TextChanged
        Text1_TextChanged(22)
    End Sub
    Private Sub _Text1_23_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Text1_23.TextChanged
        Text1_TextChanged(23)
    End Sub
    Private Sub _Text1_24_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Text1_24.TextChanged
        Text1_TextChanged(24)
    End Sub
    Private Sub _Text1_25_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Text1_25.TextChanged
        Text1_TextChanged(25)
    End Sub
    Private Sub _Text1_26_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Text1_26.TextChanged
        Text1_TextChanged(26)
    End Sub
    Private Sub _Text1_27_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Text1_27.TextChanged
        Text1_TextChanged(27)
    End Sub
    Private Sub _Text1_28_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Text1_28.TextChanged
        Text1_TextChanged(28)
    End Sub
    Private Sub _Text1_29_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Text1_29.TextChanged
        Text1_TextChanged(29)
    End Sub
    Private Sub _Text1_30_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Text1_30.TextChanged
        Text1_TextChanged(30)
    End Sub
    Private Sub _Text1_31_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Text1_31.TextChanged
        Text1_TextChanged(31)
    End Sub
    Private Sub _Text1_32_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Text1_32.TextChanged
        Text1_TextChanged(32)
    End Sub

    Private Sub cmbUnit_ValueMemberChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbUnit.ValueMemberChanged

    End Sub
End Class