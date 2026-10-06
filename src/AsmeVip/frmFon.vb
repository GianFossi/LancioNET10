Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class frmFon
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
					If System.Reflection.Assembly.GetExecutingAssembly.EntryPoint.DeclaringType Is Me.GetType Then
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
    Public WithEvents Check1 As System.Windows.Forms.CheckBox
    Public WithEvents _cmbCil_2 As System.Windows.Forms.ComboBox
    Public WithEvents _TextCil_17 As System.Windows.Forms.TextBox
    Public WithEvents _cmdCil_6 As System.Windows.Forms.Button
    Public WithEvents _TextCil_16 As System.Windows.Forms.TextBox
    Public WithEvents _TextCil_15 As System.Windows.Forms.TextBox
    Public WithEvents _cmdCil_5 As System.Windows.Forms.Button
    Public WithEvents _TextCil_14 As System.Windows.Forms.TextBox
    Public WithEvents _cmdCil_4 As System.Windows.Forms.Button
    Public WithEvents _TextCil_13 As System.Windows.Forms.TextBox
    Public WithEvents Command2 As System.Windows.Forms.Button
    Public WithEvents _TextCil_12 As System.Windows.Forms.TextBox
    Public WithEvents _TextCil_11 As System.Windows.Forms.TextBox
    Public WithEvents _TextCil_2 As System.Windows.Forms.TextBox
    Public WithEvents _cmdCil_3 As System.Windows.Forms.Button
    Public WithEvents _TextCil_1 As System.Windows.Forms.TextBox
    Public WithEvents Command1 As System.Windows.Forms.Button
    Public WithEvents _TextCil_6 As System.Windows.Forms.TextBox
    Public WithEvents _TextCil_4 As System.Windows.Forms.TextBox
    Public WithEvents _TextCil_3 As System.Windows.Forms.TextBox
    Public WithEvents _cmbCil_1 As System.Windows.Forms.ComboBox
    Public WithEvents _cmbCil_0 As System.Windows.Forms.ComboBox
    Public WithEvents _TextCil_5 As System.Windows.Forms.TextBox
    Public WithEvents _TextCil_7 As System.Windows.Forms.TextBox
    Public WithEvents _TextCil_8 As System.Windows.Forms.TextBox
    Public WithEvents _TextCil_10 As System.Windows.Forms.TextBox
    Public WithEvents _cmdCil_0 As System.Windows.Forms.Button
    Public WithEvents _cmdCil_1 As System.Windows.Forms.Button
    Public WithEvents _cmdCil_2 As System.Windows.Forms.Button
    Public WithEvents _LabelCil_19 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_18 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_17 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_16 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_15 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_14 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_13 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_4 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_3 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_8 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_6 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_5 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_2 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_1 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_0 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_7 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_9 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_10 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_11 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_12 As System.Windows.Forms.Label
    Public WithEvents Frames As System.Windows.Forms.GroupBox
    'NOTA: la routine seguente è richiesta dalla progettazione Windows Form.
    'Può essere modificata utilizzando la finestra di progettazione Windows Form.
    'Non modificarla mediante l'editor di codice.
    Friend WithEvents _TextCil_9 As System.Windows.Forms.NumericUpDown
    Friend WithEvents HelpProvider1 As System.Windows.Forms.HelpProvider
    Friend WithEvents chkAgganciato As System.Windows.Forms.CheckBox
    Friend WithEvents cmbMat As System.Windows.Forms.ComboBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmFon))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me._cmdCil_6 = New System.Windows.Forms.Button
        Me._cmdCil_5 = New System.Windows.Forms.Button
        Me._cmdCil_4 = New System.Windows.Forms.Button
        Me.chkAgganciato = New System.Windows.Forms.CheckBox
        Me.Frames = New System.Windows.Forms.GroupBox
        Me._TextCil_17 = New System.Windows.Forms.TextBox
        Me._TextCil_13 = New System.Windows.Forms.TextBox
        Me._TextCil_10 = New System.Windows.Forms.TextBox
        Me._TextCil_8 = New System.Windows.Forms.TextBox
        Me._TextCil_9 = New System.Windows.Forms.NumericUpDown
        Me.Check1 = New System.Windows.Forms.CheckBox
        Me._cmbCil_2 = New System.Windows.Forms.ComboBox
        Me._TextCil_16 = New System.Windows.Forms.TextBox
        Me._TextCil_15 = New System.Windows.Forms.TextBox
        Me._TextCil_14 = New System.Windows.Forms.TextBox
        Me.Command2 = New System.Windows.Forms.Button
        Me._TextCil_12 = New System.Windows.Forms.TextBox
        Me._TextCil_11 = New System.Windows.Forms.TextBox
        Me._TextCil_2 = New System.Windows.Forms.TextBox
        Me._cmdCil_3 = New System.Windows.Forms.Button
        Me._TextCil_1 = New System.Windows.Forms.TextBox
        Me.Command1 = New System.Windows.Forms.Button
        Me._TextCil_6 = New System.Windows.Forms.TextBox
        Me._TextCil_4 = New System.Windows.Forms.TextBox
        Me._TextCil_3 = New System.Windows.Forms.TextBox
        Me._cmbCil_1 = New System.Windows.Forms.ComboBox
        Me._cmbCil_0 = New System.Windows.Forms.ComboBox
        Me._TextCil_5 = New System.Windows.Forms.TextBox
        Me._TextCil_7 = New System.Windows.Forms.TextBox
        Me._cmdCil_0 = New System.Windows.Forms.Button
        Me._cmdCil_1 = New System.Windows.Forms.Button
        Me._cmdCil_2 = New System.Windows.Forms.Button
        Me._LabelCil_19 = New System.Windows.Forms.Label
        Me._LabelCil_18 = New System.Windows.Forms.Label
        Me._LabelCil_17 = New System.Windows.Forms.Label
        Me._LabelCil_16 = New System.Windows.Forms.Label
        Me._LabelCil_15 = New System.Windows.Forms.Label
        Me._LabelCil_14 = New System.Windows.Forms.Label
        Me._LabelCil_13 = New System.Windows.Forms.Label
        Me._LabelCil_4 = New System.Windows.Forms.Label
        Me._LabelCil_3 = New System.Windows.Forms.Label
        Me._LabelCil_8 = New System.Windows.Forms.Label
        Me._LabelCil_6 = New System.Windows.Forms.Label
        Me._LabelCil_5 = New System.Windows.Forms.Label
        Me._LabelCil_2 = New System.Windows.Forms.Label
        Me._LabelCil_1 = New System.Windows.Forms.Label
        Me._LabelCil_0 = New System.Windows.Forms.Label
        Me._LabelCil_7 = New System.Windows.Forms.Label
        Me._LabelCil_9 = New System.Windows.Forms.Label
        Me._LabelCil_10 = New System.Windows.Forms.Label
        Me._LabelCil_11 = New System.Windows.Forms.Label
        Me._LabelCil_12 = New System.Windows.Forms.Label
        Me.HelpProvider1 = New System.Windows.Forms.HelpProvider
        Me.cmbMat = New System.Windows.Forms.ComboBox
        Me.Frames.SuspendLayout()
        CType(Me._TextCil_9, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        '_cmdCil_6
        '
        Me._cmdCil_6.BackColor = System.Drawing.SystemColors.Control
        Me._cmdCil_6.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdCil_6.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdCil_6.Image = CType(resources.GetObject("_cmdCil_6.Image"), System.Drawing.Image)
        Me._cmdCil_6.Location = New System.Drawing.Point(272, 376)
        Me._cmdCil_6.Name = "_cmdCil_6"
        Me._cmdCil_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdCil_6.Size = New System.Drawing.Size(20, 20)
        Me._cmdCil_6.TabIndex = 48
        Me._cmdCil_6.TabStop = False
        Me._cmdCil_6.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me._cmdCil_6, "Riporta i valori del lato mantello e del lato tubi")
        Me._cmdCil_6.Visible = False
        '
        '_cmdCil_5
        '
        Me._cmdCil_5.BackColor = System.Drawing.SystemColors.Control
        Me._cmdCil_5.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdCil_5.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdCil_5.Image = CType(resources.GetObject("_cmdCil_5.Image"), System.Drawing.Image)
        Me._cmdCil_5.Location = New System.Drawing.Point(272, 336)
        Me._cmdCil_5.Name = "_cmdCil_5"
        Me._cmdCil_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdCil_5.Size = New System.Drawing.Size(20, 20)
        Me._cmdCil_5.TabIndex = 43
        Me._cmdCil_5.TabStop = False
        Me._cmdCil_5.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me._cmdCil_5, "Riporta il valore definito per l'apparecchio")
        '
        '_cmdCil_4
        '
        Me._cmdCil_4.BackColor = System.Drawing.SystemColors.Control
        Me._cmdCil_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdCil_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdCil_4.Image = CType(resources.GetObject("_cmdCil_4.Image"), System.Drawing.Image)
        Me._cmdCil_4.Location = New System.Drawing.Point(272, 432)
        Me._cmdCil_4.Name = "_cmdCil_4"
        Me._cmdCil_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdCil_4.Size = New System.Drawing.Size(20, 20)
        Me._cmdCil_4.TabIndex = 40
        Me._cmdCil_4.TabStop = False
        Me._cmdCil_4.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me._cmdCil_4, "Riporta il valore definito per l'apparecchio")
        '
        'chkAgganciato
        '
        Me.chkAgganciato.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkAgganciato.ForeColor = System.Drawing.SystemColors.ControlText
        Me.HelpProvider1.SetHelpKeyword(Me.chkAgganciato, "Tipi.htm#Materiale")
        Me.HelpProvider1.SetHelpNavigator(Me.chkAgganciato, System.Windows.Forms.HelpNavigator.Topic)
        Me.chkAgganciato.Location = New System.Drawing.Point(160, 72)
        Me.chkAgganciato.Name = "chkAgganciato"
        Me.HelpProvider1.SetShowHelp(Me.chkAgganciato, True)
        Me.chkAgganciato.TabIndex = 55
        Me.chkAgganciato.Text = "bound to library"
        Me.ToolTip1.SetToolTip(Me.chkAgganciato, "determina se il materiale è agganciato alla libreria o se è definito localmente")
        '
        'Frames
        '
        Me.Frames.BackColor = System.Drawing.SystemColors.Control
        Me.Frames.Controls.Add(Me.cmbMat)
        Me.Frames.Controls.Add(Me._TextCil_17)
        Me.Frames.Controls.Add(Me._TextCil_13)
        Me.Frames.Controls.Add(Me._TextCil_10)
        Me.Frames.Controls.Add(Me._TextCil_8)
        Me.Frames.Controls.Add(Me._TextCil_9)
        Me.Frames.Controls.Add(Me.Check1)
        Me.Frames.Controls.Add(Me._cmbCil_2)
        Me.Frames.Controls.Add(Me._cmdCil_6)
        Me.Frames.Controls.Add(Me._TextCil_16)
        Me.Frames.Controls.Add(Me._TextCil_15)
        Me.Frames.Controls.Add(Me._cmdCil_5)
        Me.Frames.Controls.Add(Me._TextCil_14)
        Me.Frames.Controls.Add(Me._cmdCil_4)
        Me.Frames.Controls.Add(Me.Command2)
        Me.Frames.Controls.Add(Me._TextCil_12)
        Me.Frames.Controls.Add(Me._TextCil_11)
        Me.Frames.Controls.Add(Me._TextCil_2)
        Me.Frames.Controls.Add(Me._cmdCil_3)
        Me.Frames.Controls.Add(Me._TextCil_1)
        Me.Frames.Controls.Add(Me.Command1)
        Me.Frames.Controls.Add(Me._TextCil_6)
        Me.Frames.Controls.Add(Me._TextCil_4)
        Me.Frames.Controls.Add(Me._TextCil_3)
        Me.Frames.Controls.Add(Me._cmbCil_1)
        Me.Frames.Controls.Add(Me._cmbCil_0)
        Me.Frames.Controls.Add(Me._TextCil_5)
        Me.Frames.Controls.Add(Me._TextCil_7)
        Me.Frames.Controls.Add(Me._cmdCil_0)
        Me.Frames.Controls.Add(Me._cmdCil_1)
        Me.Frames.Controls.Add(Me._cmdCil_2)
        Me.Frames.Controls.Add(Me._LabelCil_19)
        Me.Frames.Controls.Add(Me._LabelCil_18)
        Me.Frames.Controls.Add(Me._LabelCil_17)
        Me.Frames.Controls.Add(Me._LabelCil_16)
        Me.Frames.Controls.Add(Me._LabelCil_15)
        Me.Frames.Controls.Add(Me._LabelCil_14)
        Me.Frames.Controls.Add(Me._LabelCil_13)
        Me.Frames.Controls.Add(Me._LabelCil_4)
        Me.Frames.Controls.Add(Me._LabelCil_3)
        Me.Frames.Controls.Add(Me._LabelCil_8)
        Me.Frames.Controls.Add(Me._LabelCil_6)
        Me.Frames.Controls.Add(Me._LabelCil_5)
        Me.Frames.Controls.Add(Me._LabelCil_2)
        Me.Frames.Controls.Add(Me._LabelCil_1)
        Me.Frames.Controls.Add(Me._LabelCil_0)
        Me.Frames.Controls.Add(Me._LabelCil_7)
        Me.Frames.Controls.Add(Me._LabelCil_9)
        Me.Frames.Controls.Add(Me._LabelCil_10)
        Me.Frames.Controls.Add(Me._LabelCil_11)
        Me.Frames.Controls.Add(Me._LabelCil_12)
        Me.Frames.Controls.Add(Me.chkAgganciato)
        Me.Frames.ForeColor = System.Drawing.Color.Blue
        Me.Frames.Location = New System.Drawing.Point(0, 0)
        Me.Frames.Name = "Frames"
        Me.Frames.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frames.Size = New System.Drawing.Size(329, 552)
        Me.Frames.TabIndex = 0
        Me.Frames.TabStop = False
        '
        '_TextCil_17
        '
        Me._TextCil_17.AcceptsReturn = True
        Me._TextCil_17.AutoSize = False
        Me._TextCil_17.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_17.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_17.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_17.Location = New System.Drawing.Point(192, 480)
        Me._TextCil_17.MaxLength = 0
        Me._TextCil_17.Name = "_TextCil_17"
        Me._TextCil_17.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_17.Size = New System.Drawing.Size(73, 20)
        Me._TextCil_17.TabIndex = 49
        Me._TextCil_17.Text = "Text1"
        '
        '_TextCil_13
        '
        Me._TextCil_13.AcceptsReturn = True
        Me._TextCil_13.AutoSize = False
        Me._TextCil_13.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_13.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_13.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_13.Location = New System.Drawing.Point(192, 432)
        Me._TextCil_13.MaxLength = 0
        Me._TextCil_13.Name = "_TextCil_13"
        Me._TextCil_13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_13.Size = New System.Drawing.Size(73, 20)
        Me._TextCil_13.TabIndex = 39
        Me._TextCil_13.Text = "Text1"
        '
        '_TextCil_10
        '
        Me._TextCil_10.AcceptsReturn = True
        Me._TextCil_10.AutoSize = False
        Me._TextCil_10.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_10.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_10.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_10.Location = New System.Drawing.Point(192, 408)
        Me._TextCil_10.MaxLength = 0
        Me._TextCil_10.Name = "_TextCil_10"
        Me._TextCil_10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_10.Size = New System.Drawing.Size(73, 20)
        Me._TextCil_10.TabIndex = 13
        Me._TextCil_10.Text = "Text1"
        '
        '_TextCil_8
        '
        Me._TextCil_8.AcceptsReturn = True
        Me._TextCil_8.AutoSize = False
        Me._TextCil_8.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_8.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_8.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_8.Location = New System.Drawing.Point(192, 240)
        Me._TextCil_8.MaxLength = 0
        Me._TextCil_8.Name = "_TextCil_8"
        Me._TextCil_8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_8.Size = New System.Drawing.Size(73, 20)
        Me._TextCil_8.TabIndex = 9
        Me._TextCil_8.Text = "Text1"
        '
        '_TextCil_9
        '
        Me._TextCil_9.Location = New System.Drawing.Point(192, 456)
        Me._TextCil_9.Name = "_TextCil_9"
        Me._TextCil_9.Size = New System.Drawing.Size(72, 20)
        Me._TextCil_9.TabIndex = 53
        Me._TextCil_9.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Check1
        '
        Me.Check1.BackColor = System.Drawing.SystemColors.Control
        Me.Check1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Check1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Check1.Location = New System.Drawing.Point(8, 504)
        Me.Check1.Name = "Check1"
        Me.Check1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Check1.Size = New System.Drawing.Size(177, 17)
        Me.Check1.TabIndex = 52
        Me.Check1.Text = "Cold spun"
        Me.Check1.Visible = False
        '
        '_cmbCil_2
        '
        Me._cmbCil_2.BackColor = System.Drawing.SystemColors.Window
        Me._cmbCil_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmbCil_2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me._cmbCil_2.ForeColor = System.Drawing.SystemColors.WindowText
        Me._cmbCil_2.Location = New System.Drawing.Point(120, 96)
        Me._cmbCil_2.Name = "_cmbCil_2"
        Me._cmbCil_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmbCil_2.Size = New System.Drawing.Size(145, 21)
        Me._cmbCil_2.TabIndex = 51
        Me._cmbCil_2.Visible = False
        '
        '_TextCil_16
        '
        Me._TextCil_16.AcceptsReturn = True
        Me._TextCil_16.AutoSize = False
        Me._TextCil_16.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_16.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_16.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_16.Location = New System.Drawing.Point(192, 384)
        Me._TextCil_16.MaxLength = 0
        Me._TextCil_16.Name = "_TextCil_16"
        Me._TextCil_16.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_16.Size = New System.Drawing.Size(73, 20)
        Me._TextCil_16.TabIndex = 46
        Me._TextCil_16.Text = "Text1"
        Me._TextCil_16.Visible = False
        '
        '_TextCil_15
        '
        Me._TextCil_15.AcceptsReturn = True
        Me._TextCil_15.AutoSize = False
        Me._TextCil_15.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_15.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_15.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_15.Location = New System.Drawing.Point(192, 360)
        Me._TextCil_15.MaxLength = 0
        Me._TextCil_15.Name = "_TextCil_15"
        Me._TextCil_15.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_15.Size = New System.Drawing.Size(73, 20)
        Me._TextCil_15.TabIndex = 44
        Me._TextCil_15.Text = "Text1"
        Me._TextCil_15.Visible = False
        '
        '_TextCil_14
        '
        Me._TextCil_14.AcceptsReturn = True
        Me._TextCil_14.AutoSize = False
        Me._TextCil_14.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_14.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_14.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_14.Location = New System.Drawing.Point(192, 336)
        Me._TextCil_14.MaxLength = 0
        Me._TextCil_14.Name = "_TextCil_14"
        Me._TextCil_14.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_14.Size = New System.Drawing.Size(73, 20)
        Me._TextCil_14.TabIndex = 42
        Me._TextCil_14.Text = "Text1"
        '
        'Command2
        '
        Me.Command2.BackColor = System.Drawing.SystemColors.Control
        Me.Command2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command2.Location = New System.Drawing.Point(224, 520)
        Me.Command2.Name = "Command2"
        Me.Command2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command2.Size = New System.Drawing.Size(48, 25)
        Me.Command2.TabIndex = 37
        Me.Command2.TabStop = False
        Me.Command2.Text = "Cancel"
        '
        '_TextCil_12
        '
        Me._TextCil_12.AcceptsReturn = True
        Me._TextCil_12.AutoSize = False
        Me._TextCil_12.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_12.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_12.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_12.Location = New System.Drawing.Point(192, 312)
        Me._TextCil_12.MaxLength = 0
        Me._TextCil_12.Name = "_TextCil_12"
        Me._TextCil_12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_12.Size = New System.Drawing.Size(73, 20)
        Me._TextCil_12.TabIndex = 12
        Me._TextCil_12.Text = "Text1"
        '
        '_TextCil_11
        '
        Me._TextCil_11.AcceptsReturn = True
        Me._TextCil_11.AutoSize = False
        Me._TextCil_11.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_11.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_11.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_11.Location = New System.Drawing.Point(192, 288)
        Me._TextCil_11.MaxLength = 0
        Me._TextCil_11.Name = "_TextCil_11"
        Me._TextCil_11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_11.Size = New System.Drawing.Size(73, 20)
        Me._TextCil_11.TabIndex = 11
        Me._TextCil_11.Text = "Text1"
        '
        '_TextCil_2
        '
        Me._TextCil_2.AcceptsReturn = True
        Me._TextCil_2.AutoSize = False
        Me._TextCil_2.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_2.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_2.Location = New System.Drawing.Point(192, 264)
        Me._TextCil_2.MaxLength = 0
        Me._TextCil_2.Name = "_TextCil_2"
        Me._TextCil_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_2.Size = New System.Drawing.Size(73, 20)
        Me._TextCil_2.TabIndex = 10
        Me._TextCil_2.Text = "Text1"
        '
        '_cmdCil_3
        '
        Me._cmdCil_3.BackColor = System.Drawing.SystemColors.Control
        Me._cmdCil_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdCil_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdCil_3.Image = CType(resources.GetObject("_cmdCil_3.Image"), System.Drawing.Image)
        Me._cmdCil_3.Location = New System.Drawing.Point(272, 168)
        Me._cmdCil_3.Name = "_cmdCil_3"
        Me._cmdCil_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdCil_3.Size = New System.Drawing.Size(20, 20)
        Me._cmdCil_3.TabIndex = 32
        Me._cmdCil_3.TabStop = False
        Me._cmdCil_3.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        '_TextCil_1
        '
        Me._TextCil_1.AcceptsReturn = True
        Me._TextCil_1.AutoSize = False
        Me._TextCil_1.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_1.Location = New System.Drawing.Point(192, 168)
        Me._TextCil_1.MaxLength = 0
        Me._TextCil_1.Name = "_TextCil_1"
        Me._TextCil_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_1.Size = New System.Drawing.Size(73, 20)
        Me._TextCil_1.TabIndex = 6
        Me._TextCil_1.Text = "Text1"
        '
        'Command1
        '
        Me.Command1.BackColor = System.Drawing.SystemColors.Control
        Me.Command1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command1.Location = New System.Drawing.Point(277, 520)
        Me.Command1.Name = "Command1"
        Me.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command1.Size = New System.Drawing.Size(44, 25)
        Me.Command1.TabIndex = 31
        Me.Command1.TabStop = False
        Me.Command1.Text = "OK"
        '
        '_TextCil_6
        '
        Me._TextCil_6.AcceptsReturn = True
        Me._TextCil_6.AutoSize = False
        Me._TextCil_6.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_6.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_6.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_6.Location = New System.Drawing.Point(192, 192)
        Me._TextCil_6.MaxLength = 0
        Me._TextCil_6.Name = "_TextCil_6"
        Me._TextCil_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_6.Size = New System.Drawing.Size(73, 20)
        Me._TextCil_6.TabIndex = 7
        Me._TextCil_6.Text = "Text1"
        '
        '_TextCil_4
        '
        Me._TextCil_4.AcceptsReturn = True
        Me._TextCil_4.AutoSize = False
        Me._TextCil_4.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_4.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_4.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_4.Location = New System.Drawing.Point(192, 120)
        Me._TextCil_4.MaxLength = 0
        Me._TextCil_4.Name = "_TextCil_4"
        Me._TextCil_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_4.Size = New System.Drawing.Size(73, 20)
        Me._TextCil_4.TabIndex = 4
        Me._TextCil_4.Text = "Text1"
        '
        '_TextCil_3
        '
        Me._TextCil_3.AcceptsReturn = True
        Me._TextCil_3.AutoSize = False
        Me._TextCil_3.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_3.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_3.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_3.Location = New System.Drawing.Point(192, 96)
        Me._TextCil_3.MaxLength = 0
        Me._TextCil_3.Name = "_TextCil_3"
        Me._TextCil_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_3.Size = New System.Drawing.Size(73, 20)
        Me._TextCil_3.TabIndex = 3
        Me._TextCil_3.Text = "Text1"
        '
        '_cmbCil_1
        '
        Me._cmbCil_1.BackColor = System.Drawing.SystemColors.Window
        Me._cmbCil_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmbCil_1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me._cmbCil_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me._cmbCil_1.Location = New System.Drawing.Point(144, 32)
        Me._cmbCil_1.Name = "_cmbCil_1"
        Me._cmbCil_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmbCil_1.Size = New System.Drawing.Size(177, 21)
        Me._cmbCil_1.TabIndex = 2
        '
        '_cmbCil_0
        '
        Me._cmbCil_0.BackColor = System.Drawing.SystemColors.Window
        Me._cmbCil_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmbCil_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._cmbCil_0.Location = New System.Drawing.Point(144, 8)
        Me._cmbCil_0.Name = "_cmbCil_0"
        Me._cmbCil_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmbCil_0.Size = New System.Drawing.Size(177, 21)
        Me._cmbCil_0.TabIndex = 1
        Me._cmbCil_0.Text = "cmbCil"
        '
        '_TextCil_5
        '
        Me._TextCil_5.AcceptsReturn = True
        Me._TextCil_5.AutoSize = False
        Me._TextCil_5.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_5.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_5.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_5.Location = New System.Drawing.Point(192, 144)
        Me._TextCil_5.MaxLength = 0
        Me._TextCil_5.Name = "_TextCil_5"
        Me._TextCil_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_5.Size = New System.Drawing.Size(73, 20)
        Me._TextCil_5.TabIndex = 5
        Me._TextCil_5.Text = "Text1"
        '
        '_TextCil_7
        '
        Me._TextCil_7.AcceptsReturn = True
        Me._TextCil_7.AutoSize = False
        Me._TextCil_7.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_7.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_7.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_7.Location = New System.Drawing.Point(192, 216)
        Me._TextCil_7.MaxLength = 0
        Me._TextCil_7.Name = "_TextCil_7"
        Me._TextCil_7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_7.Size = New System.Drawing.Size(73, 20)
        Me._TextCil_7.TabIndex = 8
        Me._TextCil_7.Text = "Text1"
        '
        '_cmdCil_0
        '
        Me._cmdCil_0.BackColor = System.Drawing.SystemColors.Control
        Me._cmdCil_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdCil_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.HelpProvider1.SetHelpKeyword(Me._cmdCil_0, "Tipi.htm#Materiale")
        Me.HelpProvider1.SetHelpNavigator(Me._cmdCil_0, System.Windows.Forms.HelpNavigator.Topic)
        Me._cmdCil_0.Image = CType(resources.GetObject("_cmdCil_0.Image"), System.Drawing.Image)
        Me._cmdCil_0.Location = New System.Drawing.Point(272, 56)
        Me._cmdCil_0.Name = "_cmdCil_0"
        Me._cmdCil_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HelpProvider1.SetShowHelp(Me._cmdCil_0, True)
        Me._cmdCil_0.Size = New System.Drawing.Size(20, 20)
        Me._cmdCil_0.TabIndex = 16
        Me._cmdCil_0.TabStop = False
        Me._cmdCil_0.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        '_cmdCil_1
        '
        Me._cmdCil_1.BackColor = System.Drawing.SystemColors.Control
        Me._cmdCil_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdCil_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdCil_1.Image = CType(resources.GetObject("_cmdCil_1.Image"), System.Drawing.Image)
        Me._cmdCil_1.Location = New System.Drawing.Point(272, 192)
        Me._cmdCil_1.Name = "_cmdCil_1"
        Me._cmdCil_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdCil_1.Size = New System.Drawing.Size(20, 20)
        Me._cmdCil_1.TabIndex = 15
        Me._cmdCil_1.TabStop = False
        Me._cmdCil_1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        '_cmdCil_2
        '
        Me._cmdCil_2.BackColor = System.Drawing.SystemColors.Control
        Me._cmdCil_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdCil_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdCil_2.Image = CType(resources.GetObject("_cmdCil_2.Image"), System.Drawing.Image)
        Me._cmdCil_2.Location = New System.Drawing.Point(272, 216)
        Me._cmdCil_2.Name = "_cmdCil_2"
        Me._cmdCil_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdCil_2.Size = New System.Drawing.Size(20, 20)
        Me._cmdCil_2.TabIndex = 14
        Me._cmdCil_2.TabStop = False
        Me._cmdCil_2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        '_LabelCil_19
        '
        Me._LabelCil_19.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_19.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_19.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_19.Location = New System.Drawing.Point(8, 480)
        Me._LabelCil_19.Name = "_LabelCil_19"
        Me._LabelCil_19.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_19.Size = New System.Drawing.Size(177, 17)
        Me._LabelCil_19.TabIndex = 50
        Me._LabelCil_19.Tag = "kLength"
        Me._LabelCil_19.Text = "Minimum thickness (mm)"
        '
        '_LabelCil_18
        '
        Me._LabelCil_18.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_18.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_18.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_18.Location = New System.Drawing.Point(8, 384)
        Me._LabelCil_18.Name = "_LabelCil_18"
        Me._LabelCil_18.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_18.Size = New System.Drawing.Size(177, 17)
        Me._LabelCil_18.TabIndex = 47
        Me._LabelCil_18.Tag = "kPress"
        Me._LabelCil_18.Text = "Design pressure (external)"
        Me._LabelCil_18.Visible = False
        '
        '_LabelCil_17
        '
        Me._LabelCil_17.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_17.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_17.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_17.Location = New System.Drawing.Point(8, 360)
        Me._LabelCil_17.Name = "_LabelCil_17"
        Me._LabelCil_17.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_17.Size = New System.Drawing.Size(177, 17)
        Me._LabelCil_17.TabIndex = 45
        Me._LabelCil_17.Tag = "kPress"
        Me._LabelCil_17.Text = "Design pressure (internal)"
        Me._LabelCil_17.Visible = False
        '
        '_LabelCil_16
        '
        Me._LabelCil_16.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_16.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_16.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_16.Location = New System.Drawing.Point(8, 336)
        Me._LabelCil_16.Name = "_LabelCil_16"
        Me._LabelCil_16.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_16.Size = New System.Drawing.Size(177, 17)
        Me._LabelCil_16.TabIndex = 41
        Me._LabelCil_16.Tag = "kTemp"
        Me._LabelCil_16.Text = "Design temperature"
        '
        '_LabelCil_15
        '
        Me._LabelCil_15.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_15.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_15.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_15.Location = New System.Drawing.Point(8, 432)
        Me._LabelCil_15.Name = "_LabelCil_15"
        Me._LabelCil_15.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_15.Size = New System.Drawing.Size(177, 17)
        Me._LabelCil_15.TabIndex = 38
        Me._LabelCil_15.Text = "Relative density of contained fluid"
        '
        '_LabelCil_14
        '
        Me._LabelCil_14.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_14.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_14.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_14.Location = New System.Drawing.Point(8, 312)
        Me._LabelCil_14.Name = "_LabelCil_14"
        Me._LabelCil_14.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_14.Size = New System.Drawing.Size(177, 17)
        Me._LabelCil_14.TabIndex = 36
        Me._LabelCil_14.Tag = "kLength"
        Me._LabelCil_14.Text = "Inside Shell Diameter"
        '
        '_LabelCil_13
        '
        Me._LabelCil_13.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_13.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_13.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_13.Location = New System.Drawing.Point(8, 288)
        Me._LabelCil_13.Name = "_LabelCil_13"
        Me._LabelCil_13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_13.Size = New System.Drawing.Size(177, 17)
        Me._LabelCil_13.TabIndex = 35
        Me._LabelCil_13.Tag = "kLength"
        Me._LabelCil_13.Text = "Inside Knuckle Radius"
        '
        '_LabelCil_4
        '
        Me._LabelCil_4.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_4.Location = New System.Drawing.Point(8, 264)
        Me._LabelCil_4.Name = "_LabelCil_4"
        Me._LabelCil_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_4.Size = New System.Drawing.Size(177, 17)
        Me._LabelCil_4.TabIndex = 34
        Me._LabelCil_4.Tag = "kLength"
        Me._LabelCil_4.Text = "Ins. Crown/Sph. Radius"
        '
        '_LabelCil_3
        '
        Me._LabelCil_3.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_3.Location = New System.Drawing.Point(8, 168)
        Me._LabelCil_3.Name = "_LabelCil_3"
        Me._LabelCil_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_3.Size = New System.Drawing.Size(177, 17)
        Me._LabelCil_3.TabIndex = 33
        Me._LabelCil_3.Tag = "kPress"
        Me._LabelCil_3.Text = "Ultimate Strength"
        '
        '_LabelCil_8
        '
        Me._LabelCil_8.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_8.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_8.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_8.Location = New System.Drawing.Point(8, 192)
        Me._LabelCil_8.Name = "_LabelCil_8"
        Me._LabelCil_8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_8.Size = New System.Drawing.Size(177, 17)
        Me._LabelCil_8.TabIndex = 30
        Me._LabelCil_8.Tag = "kPress"
        Me._LabelCil_8.Text = "Allowable stress @ room"
        '
        '_LabelCil_6
        '
        Me._LabelCil_6.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_6.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_6.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_6.Location = New System.Drawing.Point(8, 120)
        Me._LabelCil_6.Name = "_LabelCil_6"
        Me._LabelCil_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_6.Size = New System.Drawing.Size(177, 17)
        Me._LabelCil_6.TabIndex = 29
        Me._LabelCil_6.Tag = "kLength"
        Me._LabelCil_6.Text = "Clad or WO thk."
        '
        '_LabelCil_5
        '
        Me._LabelCil_5.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_5.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_5.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_5.Location = New System.Drawing.Point(8, 96)
        Me._LabelCil_5.Name = "_LabelCil_5"
        Me._LabelCil_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_5.Size = New System.Drawing.Size(177, 17)
        Me._LabelCil_5.TabIndex = 28
        Me._LabelCil_5.Text = "Joint efficiency"
        '
        '_LabelCil_2
        '
        Me._LabelCil_2.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.HelpProvider1.SetHelpKeyword(Me._LabelCil_2, "Tipi.htm#Materiale")
        Me.HelpProvider1.SetHelpNavigator(Me._LabelCil_2, System.Windows.Forms.HelpNavigator.Topic)
        Me._LabelCil_2.Location = New System.Drawing.Point(8, 56)
        Me._LabelCil_2.Name = "_LabelCil_2"
        Me._LabelCil_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HelpProvider1.SetShowHelp(Me._LabelCil_2, True)
        Me._LabelCil_2.Size = New System.Drawing.Size(169, 17)
        Me._LabelCil_2.TabIndex = 27
        Me._LabelCil_2.Text = "Head Material"
        '
        '_LabelCil_1
        '
        Me._LabelCil_1.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_1.Location = New System.Drawing.Point(8, 32)
        Me._LabelCil_1.Name = "_LabelCil_1"
        Me._LabelCil_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_1.Size = New System.Drawing.Size(105, 17)
        Me._LabelCil_1.TabIndex = 26
        Me._LabelCil_1.Text = "Head geometry"
        '
        '_LabelCil_0
        '
        Me._LabelCil_0.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_0.Location = New System.Drawing.Point(8, 8)
        Me._LabelCil_0.Name = "_LabelCil_0"
        Me._LabelCil_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_0.Size = New System.Drawing.Size(121, 17)
        Me._LabelCil_0.TabIndex = 25
        Me._LabelCil_0.Text = "Head identification"
        '
        '_LabelCil_7
        '
        Me._LabelCil_7.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_7.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_7.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_7.Location = New System.Drawing.Point(8, 144)
        Me._LabelCil_7.Name = "_LabelCil_7"
        Me._LabelCil_7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_7.Size = New System.Drawing.Size(177, 17)
        Me._LabelCil_7.TabIndex = 24
        Me._LabelCil_7.Tag = "kLength"
        Me._LabelCil_7.Text = "Corrosion allowance"
        '
        '_LabelCil_9
        '
        Me._LabelCil_9.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_9.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_9.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_9.Location = New System.Drawing.Point(8, 216)
        Me._LabelCil_9.Name = "_LabelCil_9"
        Me._LabelCil_9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_9.Size = New System.Drawing.Size(177, 17)
        Me._LabelCil_9.TabIndex = 23
        Me._LabelCil_9.Tag = "kPress"
        Me._LabelCil_9.Text = "Allowable stress @ temp"
        '
        '_LabelCil_10
        '
        Me._LabelCil_10.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_10.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_10.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_10.Location = New System.Drawing.Point(8, 240)
        Me._LabelCil_10.Name = "_LabelCil_10"
        Me._LabelCil_10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_10.Size = New System.Drawing.Size(177, 17)
        Me._LabelCil_10.TabIndex = 22
        Me._LabelCil_10.Tag = "kLength"
        Me._LabelCil_10.Text = "Inside Depth"
        '
        '_LabelCil_11
        '
        Me._LabelCil_11.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_11.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_11.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_11.Location = New System.Drawing.Point(8, 456)
        Me._LabelCil_11.Name = "_LabelCil_11"
        Me._LabelCil_11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_11.Size = New System.Drawing.Size(177, 17)
        Me._LabelCil_11.TabIndex = 21
        Me._LabelCil_11.Text = "Number of openings"
        '
        '_LabelCil_12
        '
        Me._LabelCil_12.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_12.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_12.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_12.Location = New System.Drawing.Point(8, 408)
        Me._LabelCil_12.Name = "_LabelCil_12"
        Me._LabelCil_12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_12.Size = New System.Drawing.Size(177, 17)
        Me._LabelCil_12.TabIndex = 20
        Me._LabelCil_12.Tag = "kLength"
        Me._LabelCil_12.Text = "Hydrostatic depth"
        '
        'cmbMat
        '
        Me.cmbMat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMat.Location = New System.Drawing.Point(88, 56)
        Me.cmbMat.Name = "cmbMat"
        Me.cmbMat.Size = New System.Drawing.Size(176, 21)
        Me.cmbMat.TabIndex = 56
        '
        'frmFon
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(330, 552)
        Me.Controls.Add(Me.Frames)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.HelpButton = True
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmFon"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "Dati Fondo"
        Me.Frames.ResumeLayout(False)
        CType(Me._TextCil_9, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
#End Region 
#Region "Supporto aggiornamento "
	Private Shared m_vb6FormDefInstance As frmFon
	Private Shared m_InitializingDefInstance As Boolean
	Public Shared Property DefInstance() As frmFon
		Get
			If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
				m_InitializingDefInstance = True
				m_vb6FormDefInstance = New frmFon()
				m_InitializingDefInstance = False
			End If
			DefInstance = m_vb6FormDefInstance
		End Get
		Set
			m_vb6FormDefInstance = Value
		End Set
	End Property
#End Region 
    Public Cancel As Boolean
    Private Inizializzando As Boolean
    Private Sub Inizializza()
        Dim indice As Short
        Dim m As LibMat.MaterialeNew1 = Nothing
        Top = GlobalRoutines.TwipsToPixelsY(660)
        Left = GlobalRoutines.TwipsToPixelsX(2835)
        _cmbCil_0.Items.Clear()
        _cmbCil_0.Items.Add("Shell Bonnet  ")
        _cmbCil_0.Items.Add("Channel Bonnet")
        _cmbCil_0.Items.Add("Other (write)")
        _cmbCil_1.Items.Clear()
        _cmbCil_1.Items.Add("Ellipsoidal Head : D/2h=2.0  ") '1
        _cmbCil_1.Items.Add("Ellipsoidal Head : D/2h<>2.0 ") '2
        _cmbCil_1.Items.Add("Torisph.Head : r=0.06L & L=Do") '3
        _cmbCil_1.Items.Add("Kloepper     : r=0.10L & L=Do") '4
        _cmbCil_1.Items.Add("Korbbogen :r=0.154Do;L=0.80Do") '5
        _cmbCil_1.Items.Add("Torispherical Head : r>0.06L ") '6 (era 4)
        _cmbCil_1.Items.Add("Emispherical Head            ") '7 (era 5)
        _cmbCil_1.Items.Add("Calotta sferica              ") '8 (era 6)
        AggVisible(Involucr(kLato, jInvolucr).ms)
        If kLato = 3 Then
            LabelCil(17).Visible = True
            LabelCil(18).Visible = True
            _TextCil_15.Visible = True
            _TextCil_16.Visible = True
            _cmdCil_6.Visible = True
        End If
        _LabelCil_9.Visible = Not VerificandoPI
        _TextCil_7.Visible = Not VerificandoPI
        _cmdCil_2.Visible = Not VerificandoPI
        _LabelCil_3.Visible = Not VerificandoPI
        _TextCil_1.Visible = Not VerificandoPI
        _cmdCil_3.Visible = Not VerificandoPI
        _LabelCil_15.Visible = Not VerificandoPI
        _TextCil_13.Visible = Not VerificandoPI
        _cmdCil_4.Visible = Not VerificandoPI
        Popola(cmbMat)
        If VerificandoPI Then _LabelCil_8.Text = "Allowable stress in H.T."
        If div = 2 Then
            _LabelCil_3.Visible = True : _TextCil_1.Visible = True : _cmdCil_3.Visible = True
            _LabelCil_3.Text = "Design stress for buckling"
            TestGroupCombo(_cmbCil_2, _LabelCil_8, _LabelCil_9)
            indice = Involucr(kLato, jInvolucr).indice(1 - 1)
            If indice > 0 Then m = Matdim(indice)
            If Not m Is Nothing Then
                Check1.Visible = VB.Left(m.EUMatGroup, 1) = "8"
                If Involucr(kLato, jInvolucr).Dati(5 - 4) < 0 Or Involucr(kLato, jInvolucr).Dati(5 - 4) > 1 Then Involucr(kLato, jInvolucr).Dati(5 - 4) = 0
                Check1.CheckState = Involucr(kLato, jInvolucr).Dati(5 - 4)
            End If
        End If
        HelpProvider1.HelpNamespace = RadiceHelp
    End Sub
    Friend ReadOnly Property TextCil(ByVal i As Short) As TextBox
        Get
            Select Case i
                Case 1 : Return _TextCil_1
                Case 2 : Return _TextCil_2
                Case 3 : Return _TextCil_3
                Case 4 : Return _TextCil_4
                Case 5 : Return _TextCil_5
                Case 6 : Return _TextCil_6
                Case 7 : Return _TextCil_7
                Case 8 : Return _TextCil_8
                    '               Case 9 : Return _TextCil_9
                Case 10 : Return _TextCil_10
                Case 11 : Return _TextCil_11
                Case 12 : Return _TextCil_12
                Case 13 : Return _TextCil_13
                Case 14 : Return _TextCil_14
                Case 15 : Return _TextCil_15
                Case 16 : Return _TextCil_16
                Case 17 : Return _TextCil_17
                Case Else : Return Nothing
            End Select
        End Get
    End Property
    Public ReadOnly Property LabelCil(ByVal i As Short) As Label
        Get
            Select Case i
                Case 0 : Return _LabelCil_0
                Case 1 : Return _LabelCil_1
                Case 2 : Return _LabelCil_2
                Case 3 : Return _LabelCil_3
                Case 4 : Return _LabelCil_4
                Case 5 : Return _LabelCil_5
                Case 6 : Return _LabelCil_6
                Case 7 : Return _LabelCil_7
                Case 8 : Return _LabelCil_8
                Case 9 : Return _LabelCil_9
                Case 10 : Return _LabelCil_10
                Case 11 : Return _LabelCil_11
                Case 12 : Return _LabelCil_12
                Case 13 : Return _LabelCil_13
                Case 14 : Return _LabelCil_14
                Case 15 : Return _LabelCil_15
                Case 16 : Return _LabelCil_16
                Case 17 : Return _LabelCil_17
                Case 18 : Return _LabelCil_18
                Case 19 : Return _LabelCil_19
                Case Else : Return Nothing
            End Select
        End Get
    End Property
    Private Sub _cmbCil_0_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmbCil_0.TextChanged
        If Inizializzando Then Exit Sub
        Involucr(kLato, jInvolucr).Mark = Trim(_cmbCil_0.Text)
    End Sub

    Private Sub _cmbCil_0_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmbCil_0.SelectedIndexChanged
        cmbCil_SelectedIndexChanged(0)
    End Sub

    Private Sub _cmbCil_1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmbCil_1.SelectedIndexChanged
        cmbCil_SelectedIndexChanged(1)
    End Sub

    Private Sub _cmbCil_2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmbCil_2.SelectedIndexChanged
        cmbCil_SelectedIndexChanged(2)
    End Sub
    Private Sub Check1_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Check1.CheckStateChanged
        Involucr(kLato, jInvolucr).Dati(5 - 4) = Check1.CheckState
    End Sub
    Friend ReadOnly Property cmbCil(ByVal i As Short) As ComboBox
        Get
            Select Case i
                Case 0 : Return _cmbCil_0
                Case 1 : Return _cmbCil_1
                Case 2 : Return _cmbCil_2
                Case Else : Return Nothing
            End Select
        End Get
    End Property
    Friend ReadOnly Property cmdCil(ByVal i As Short) As Button
        Get
            Select Case i
                Case 0 : Return _cmdCil_0
                Case 1 : Return _cmdCil_1
                Case 2 : Return _cmdCil_2
                Case 3 : Return _cmdCil_3
                Case 4 : Return _cmdCil_4
                Case 5 : Return _cmdCil_5
                Case 6 : Return _cmdCil_6
                Case Else : Return Nothing
            End Select
        End Get
    End Property
    Private Sub cmbCil_SelectedIndexChanged(ByVal Index As Short)
        If Inizializzando Then Exit Sub
        Select Case Index
            Case 0 'identification
                Involucr(kLato, jInvolucr).Mark = _cmbCil_0.Text
            Case 1 'tipo
                If Involucr(kLato, jInvolucr).ms <> cmbCil(Index).SelectedIndex + 1 Then
                    Involucr(kLato, jInvolucr).ms = cmbCil(Index).SelectedIndex + 1
                    HTStr = cmbCil(Index).Text
                    AggVisible(Involucr(kLato, jInvolucr).ms)
                    AggRapporti()
                    AggDatiFon(kLato, jInvolucr)
                End If
        End Select
    End Sub
    Private Sub _cmdCil_0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmdCil_0.Click
        cmdCil_Click(0)
    End Sub
    Private Sub _cmdCil_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmdCil_1.Click
        cmdCil_Click(1)
    End Sub
    Private Sub _cmdCil_2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmdCil_2.Click
        cmdCil_Click(2)
    End Sub
    Private Sub _cmdCil_3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmdCil_3.Click
        cmdCil_Click(3)
    End Sub
    Private Sub _cmdCil_4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmdCil_4.Click
        cmdCil_Click(4)
    End Sub
    Private Sub _cmdCil_5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmdCil_5.Click
        cmdCil_Click(5)
    End Sub
    Private Sub _cmdCil_6_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmdCil_6.Click
        cmdCil_Click(6)
    End Sub
    Private Sub cmdCil_Click(ByVal Index As Short)
        Select Case Index
            Case 0 : SelMat()
                PostSelMat(cmbMat, Involucr(kLato, jInvolucr).indice(0))
                SubAmm()
            Case 1, 2, 3
                SubAmm()
            Case 4 : _TextCil_13.Text = GlobalRoutines.myStr(Config(kLato).DensFluido, 6 - IncrVirgola, 1 + IncrVirgola, 0)
            Case 5
                _TextCil_14.Text = GlobalRoutines.myStr((TempDes() - 32) / 1.8, 6 - IncrVirgola, 1 + IncrVirgola, 0)
            Case 6
                _TextCil_15.Text = GlobalRoutines.myStr(Config(2).p0x, 6 - IncrVirgola, 1 + IncrVirgola, 0)
                _TextCil_16.Text = GlobalRoutines.myStr(Config(1).p0x, 6 - IncrVirgola, 1 + IncrVirgola, 0)
        End Select
        Exit Sub
    End Sub
    Private Sub SubAmm()
        Dim td1 As Single
        Call Ammiss(jInvolucr)
        If div = 2 Then
            _TextCil_6.Text = GlobalRoutines.myStr(Involucr(kLato, jInvolucr).Shydr * kPress, 6 - IncrVirgola, 1 + IncrVirgola, 0)
            _TextCil_7.Text = GlobalRoutines.myStr(Involucr(kLato, jInvolucr).St * kPress, 6 - IncrVirgola, 1 + IncrVirgola, 0)
        Else
            If VerificandoPI Then
                _TextCil_6.Text = GlobalRoutines.myStr(Involucr(kLato, jInvolucr).Shydr * kPress, 6 - IncrVirgola, 1 + IncrVirgola, 0)
            Else
                _TextCil_6.Text = GlobalRoutines.myStr(Involucr(kLato, jInvolucr).S0 * kPress, 6 - IncrVirgola, 1 + IncrVirgola, 0)
                _TextCil_7.Text = GlobalRoutines.myStr(Involucr(kLato, jInvolucr).St * kPress, 6 - IncrVirgola, 1 + IncrVirgola, 0)
                td1 = TempDes()
                If div = 2 Then
                    Involucr(kLato, jInvolucr).Dati(4 - 4) = EUfb(td1)
                    _TextCil_1.Text = GlobalRoutines.myStr(Involucr(kLato, jInvolucr).Dati(4 - 4) * kPress, 6 - IncrVirgola, 1 + IncrVirgola, 0)
                Else
                    Involucr(kLato, jInvolucr).SU = Matdim(Involucr(kLato, jInvolucr).indice(1 - 1)).UltStrength(TempDes)
                    '  Involucr(kLato, jInvolucr).SU = Involucr(kLato, jInvolucr).SU / mpa
                    _TextCil_1.Text = GlobalRoutines.myStr(Involucr(kLato, jInvolucr).SU * kPress, 6 - IncrVirgola, 1 + IncrVirgola, 0)
                End If
            End If
        End If
    End Sub
    Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
        ' Select Case Involucr(kLato, jInvolucr).ms
        '     Case 1: Involucr(kLato, jInvolucr).L0 = 0.85 * Involucr(kLato, jInvolucr).di
        '             Involucr(kLato, jInvolucr).R0 = 0.16 * Involucr(kLato, jInvolucr).di
        '     Case 5:
        ' End Select
        Cancel = False
        Hide()
    End Sub

    Private Sub Command2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command2.Click
        Cancel = True
        Hide()
    End Sub
    Private Sub _TextCil_1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_1.TextChanged
        TextCil_TextChanged(1)
    End Sub
    Private Sub _TextCil_2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_2.TextChanged
        TextCil_TextChanged(2)
    End Sub
    Private Sub _TextCil_3_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_3.TextChanged
        TextCil_TextChanged(3)
    End Sub
    Private Sub _TextCil_4_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_4.TextChanged
        TextCil_TextChanged(4)
    End Sub
    Private Sub _TextCil_5_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_5.TextChanged
        TextCil_TextChanged(5)
    End Sub
    Private Sub _TextCil_6_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_6.TextChanged
        TextCil_TextChanged(6)
    End Sub
    Private Sub _TextCil_7_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_7.TextChanged
        TextCil_TextChanged(7)
    End Sub
    Private Sub _TextCil_8_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_8.TextChanged
        TextCil_TextChanged(8)
    End Sub
    Private Sub _TextCil_9_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_9.TextChanged
        TextCil_TextChanged(9)
    End Sub
    Private Sub _TextCil_10_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_10.TextChanged
        TextCil_TextChanged(10)
    End Sub
    Private Sub _TextCil_12_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_12.TextChanged
        TextCil_TextChanged(12)
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
    Private Sub TextCil_TextChanged(ByVal Index As Short)
        If Inizializzando Then Exit Sub
        With Involucr(kLato, jInvolucr)
            Select Case Index
                Case 1
                    If div = 2 Then
                        .Dati(4 - 4) = GlobalRoutines.ValVir(TextCil(Index).Text) / kPress
                    Else
                        .SU = GlobalRoutines.ValVir(TextCil(Index).Text) / kPress
                    End If
                Case 2 : .L0 = GlobalRoutines.ValVir(TextCil(Index).Text) / kLength
                    If .ms = 6 Or .ms = 7 Or .ms = 8 Then
                        AggRapporti()
                        _TextCil_8.Text = GlobalRoutines.myStr(.H0 * kLength, 5, 3, False)
                    End If
                Case 3 : .ES = GlobalRoutines.ValVir(TextCil(Index).Text)
                Case 4 : .OS = GlobalRoutines.ValVir(TextCil(Index).Text) / kLength
                Case 5 : .cs = GlobalRoutines.ValVir(TextCil(Index).Text) / kLength
                Case 6
                    If VerificandoPI Or div = 2 Then
                        .Shydr = GlobalRoutines.ValVir(TextCil(Index).Text) / kPress
                    Else
                        .S0 = GlobalRoutines.ValVir(TextCil(Index).Text) / kPress
                    End If
                Case 7 : .St = GlobalRoutines.ValVir(TextCil(Index).Text) / kPress
                Case 8 : .H0 = GlobalRoutines.ValVir(TextCil(Index).Text) / kLength
                    'Case 9 : VariaBocc(Val(TextCil(Index).Text))
                Case 10 : .HydrDepth = GlobalRoutines.ValVir(TextCil(Index).Text) / kLength
                Case 11 : .R0 = GlobalRoutines.ValVir(TextCil(Index).Text) / kLength
                    If .ms = 6 Then
                        AggRapporti()
                        _TextCil_8.Text = GlobalRoutines.myStr(.H0, 5, 3, False) / kLength
                    End If
                Case 12 : .di = GlobalRoutines.ValVir(TextCil(Index).Text) / kLength
                    AggRapporti()
                    _TextCil_2.Text = GlobalRoutines.myStr(.L0 * kLength, 5, 2, False)
                    _TextCil_8.Text = GlobalRoutines.myStr(.H0 * kLength, 5, 3, False)
                    _TextCil_11.Text = GlobalRoutines.myStr(.R0 * kLength, 5, 3, False)
                Case 13 : .DensFluido = GlobalRoutines.ValVir(TextCil(Index).Text)
                Case 14 : .Destemp = (GlobalRoutines.ValVir(TextCil(Index).Text) - kTemp32) / kTemp
                Case 15 : .PressInt = GlobalRoutines.ValVir(TextCil(Index).Text) / kPress
                Case 16 : .PressExt = GlobalRoutines.ValVir(TextCil(Index).Text) / kPress
                Case 17 : .Spess = GlobalRoutines.ValVir(TextCil(Index).Text) / kLength
            End Select
        End With
    End Sub
    Public Sub AggVisible(ByRef m As Short)
        '_TextCil_8.Visible = True
        _LabelCil_4.Visible = True : _TextCil_2.Visible = True
        _LabelCil_13.Visible = True : _TextCil_11.Visible = True
        _TextCil_2.Enabled = True
        _TextCil_11.Enabled = True
        Select Case m
            Case 1, 3, 4, 5 : _TextCil_8.Enabled = False
                _TextCil_2.Enabled = False
                _TextCil_11.Enabled = False
            Case 2 : _LabelCil_4.Visible = False : _TextCil_2.Visible = False
                _LabelCil_13.Visible = False : _TextCil_11.Visible = False
                _TextCil_8.Enabled = True
            Case 6 : _TextCil_8.Enabled = False
            Case 7 : _TextCil_8.Enabled = False
                _LabelCil_13.Visible = False : _TextCil_11.Visible = False
            Case 8 : _TextCil_8.Enabled = False
                _LabelCil_13.Visible = False : _TextCil_11.Visible = False
                LabelCil(14).Text = "Diam. calotta"
        End Select
    End Sub
    Private Sub AggRapporti()
        Dim a, b As Single
        With Involucr(kLato, jInvolucr)
            On Error Resume Next
            Select Case .ms
                Case 1 'ellittico 2:1 (o pseudoellittico FBM)
                    .L0 = 0.85 * .di
                    .R0 = 0.16 * .di
                    .H0 = .di / 4
                Case 2 'ellittico
                Case 3 'torosferico .06 'R-sqr(R^2-2rR-Rc^2+2rRc)
                    .L0 = .di
                    .R0 = 0.06 * .di
                    .H0 = (1 - System.Math.Sqrt(1 - 0.12 - 0.5 ^ 2 + 0.06)) * .di
                Case 4 'torosferico .10 'R-sqr(R^2-2rR-Rc^2+2rRc) Kloepper
                    .L0 = .di
                    .R0 = 0.1 * .di
                    .H0 = (1 - System.Math.Sqrt(1 - 0.2 - 0.5 ^ 2 + 0.1)) * .di
                Case 5 'torosferico .154 'R-sqr(R^2-2rR-Rc^2+2rRc) Korbbogen
                    .L0 = 0.8 * .di
                    .R0 = 0.154 * .di
                    .H0 = (0.8 - System.Math.Sqrt(0.8 ^ 2 - 0.154 * 1.6 - 0.5 ^ 2 + 0.154)) * .di
                Case 6 'torosferico
                    a = .L0 / .di
                    b = .R0 / .di
                    .H0 = (a - System.Math.Sqrt(a * a - 2 * a * b - 0.5 ^ 2 + b)) * .di
                Case 7 'emisferico
                    .H0 = .L0 - System.Math.Sqrt(.L0 ^ 2 - (.di / 2) ^ 2)
                Case 8 'calotta
                    .H0 = .L0 - System.Math.Sqrt(.L0 ^ 2 - (.di / 2) ^ 2)
            End Select
        End With
    End Sub
    Private Sub _TextCil_14_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_14.Leave
        AvvertiDT()
    End Sub
    Private Sub chkAgganciato_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkAgganciato.CheckedChanged
        Matdim(Involucr(kLato, jInvolucr).indice(0)).Agganciato = chkAgganciato.Checked
        ModifiedData = True
    End Sub
    Private Sub frmFon_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        AggiornaLabels(Me, 19)
    End Sub
    Private Sub cmbMat_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbMat.SelectedIndexChanged
        Dim nuovoSelect As Short
        SelPopMat(cmbMat, Involucr(kLato, jInvolucr).indice(0), True, nuovoSelect)
        If nuovoSelect > -1 Then cmbMat.SelectedIndex = nuovoSelect
        Involucr(kLato, jInvolucr).MATE = Matdim(Involucr(kLato, jInvolucr).indice(0)).MatStr
        chkAgganciato.Checked = Matdim(Involucr(kLato, jInvolucr).indice(0)).Agganciato
    End Sub
    Private Sub _TextCil_9_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_9.ValueChanged
        VariaBocc(_TextCil_9.Value)
    End Sub
End Class