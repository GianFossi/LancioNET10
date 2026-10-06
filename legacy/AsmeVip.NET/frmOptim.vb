Option Strict Off
Option Explicit On
Friend Class frmOptim
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
    Public WithEvents _txtMin_11 As System.Windows.Forms.TextBox
    Public WithEvents Break As System.Windows.Forms.Button
    Public WithEvents _txtMin_10 As System.Windows.Forms.TextBox
    Public WithEvents _cmdScelta_1 As System.Windows.Forms.Button
    Public WithEvents _cmdScelta_0 As System.Windows.Forms.Button
    Public WithEvents _txtMin_9 As System.Windows.Forms.TextBox
    Public WithEvents _txtMin_8 As System.Windows.Forms.TextBox
    Public WithEvents _txtMin_7 As System.Windows.Forms.TextBox
    Public WithEvents _txtMin_6 As System.Windows.Forms.TextBox
    Public WithEvents _txtMin_5 As System.Windows.Forms.TextBox
    Public WithEvents _txtIncr_9 As System.Windows.Forms.TextBox
    Public WithEvents _txtIncr_8 As System.Windows.Forms.TextBox
    Public WithEvents _txtIncr_7 As System.Windows.Forms.TextBox
    Public WithEvents _txtIncr_6 As System.Windows.Forms.TextBox
    Public WithEvents _txtIncr_5 As System.Windows.Forms.TextBox
    Public WithEvents Annulla As System.Windows.Forms.Button
    Public WithEvents _Label2_12 As System.Windows.Forms.Label
    Public WithEvents _Label2_11 As System.Windows.Forms.Label
    Public WithEvents _Label2_10 As System.Windows.Forms.Label
    Public WithEvents _Label1_5 As System.Windows.Forms.Label
    Public WithEvents _Label1_4 As System.Windows.Forms.Label
    Public WithEvents _Label2_9 As System.Windows.Forms.Label
    Public WithEvents _Label2_8 As System.Windows.Forms.Label
    Public WithEvents _Label2_7 As System.Windows.Forms.Label
    Public WithEvents _Label2_6 As System.Windows.Forms.Label
    Public WithEvents _Label2_5 As System.Windows.Forms.Label
    Public WithEvents _Label3_7 As System.Windows.Forms.Label
    Public WithEvents _Label3_6 As System.Windows.Forms.Label
    Public WithEvents _Label3_5 As System.Windows.Forms.Label
    Public WithEvents _Label3_4 As System.Windows.Forms.Label
    Public WithEvents Frame2 As System.Windows.Forms.GroupBox
    Public WithEvents chkEscludiSez1 As System.Windows.Forms.CheckBox
    Public WithEvents cmdCancel As System.Windows.Forms.Button
    Public WithEvents cmdVai As System.Windows.Forms.Button
    Public WithEvents _txtMax_4 As System.Windows.Forms.TextBox
    Public WithEvents _txtMax_3 As System.Windows.Forms.TextBox
    Public WithEvents _txtMax_2 As System.Windows.Forms.TextBox
    Public WithEvents _txtMax_1 As System.Windows.Forms.TextBox
    Public WithEvents _txtIncr_4 As System.Windows.Forms.TextBox
    Public WithEvents _txtIncr_3 As System.Windows.Forms.TextBox
    Public WithEvents _txtIncr_2 As System.Windows.Forms.TextBox
    Public WithEvents _txtIncr_1 As System.Windows.Forms.TextBox
    Public WithEvents _txtMax_0 As System.Windows.Forms.TextBox
    Public WithEvents _txtIncr_0 As System.Windows.Forms.TextBox
    Public WithEvents _txtMin_4 As System.Windows.Forms.TextBox
    Public WithEvents _txtMin_3 As System.Windows.Forms.TextBox
    Public WithEvents _txtMin_2 As System.Windows.Forms.TextBox
    Public WithEvents _txtMin_1 As System.Windows.Forms.TextBox
    Public WithEvents _txtMin_0 As System.Windows.Forms.TextBox
    Public WithEvents _Label3_3 As System.Windows.Forms.Label
    Public WithEvents _Label3_2 As System.Windows.Forms.Label
    Public WithEvents _Label3_1 As System.Windows.Forms.Label
    Public WithEvents _Label3_0 As System.Windows.Forms.Label
    Public WithEvents _Label2_4 As System.Windows.Forms.Label
    Public WithEvents _Label2_3 As System.Windows.Forms.Label
    Public WithEvents _Label2_2 As System.Windows.Forms.Label
    Public WithEvents _Label2_1 As System.Windows.Forms.Label
    Public WithEvents _Label2_0 As System.Windows.Forms.Label
    Public WithEvents _Label1_2 As System.Windows.Forms.Label
    Public WithEvents _Label1_1 As System.Windows.Forms.Label
    Public WithEvents _Label1_0 As System.Windows.Forms.Label
    Public WithEvents Frame1 As System.Windows.Forms.GroupBox
    'NOTA: la routine seguente è richiesta dalla progettazione Windows Form.
    'Può essere modificata utilizzando la finestra di progettazione Windows Form.
    'Non modificarla mediante l'editor di codice.
    Friend WithEvents HelpProvider1 As System.Windows.Forms.HelpProvider
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmOptim))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Frame2 = New System.Windows.Forms.GroupBox
        Me._txtMin_11 = New System.Windows.Forms.TextBox
        Me.Break = New System.Windows.Forms.Button
        Me._txtMin_10 = New System.Windows.Forms.TextBox
        Me._cmdScelta_1 = New System.Windows.Forms.Button
        Me._cmdScelta_0 = New System.Windows.Forms.Button
        Me._txtMin_9 = New System.Windows.Forms.TextBox
        Me._txtMin_8 = New System.Windows.Forms.TextBox
        Me._txtMin_7 = New System.Windows.Forms.TextBox
        Me._txtMin_6 = New System.Windows.Forms.TextBox
        Me._txtMin_5 = New System.Windows.Forms.TextBox
        Me._txtIncr_9 = New System.Windows.Forms.TextBox
        Me._txtIncr_8 = New System.Windows.Forms.TextBox
        Me._txtIncr_7 = New System.Windows.Forms.TextBox
        Me._txtIncr_6 = New System.Windows.Forms.TextBox
        Me._txtIncr_5 = New System.Windows.Forms.TextBox
        Me.Annulla = New System.Windows.Forms.Button
        Me._Label2_12 = New System.Windows.Forms.Label
        Me._Label2_11 = New System.Windows.Forms.Label
        Me._Label2_10 = New System.Windows.Forms.Label
        Me._Label1_5 = New System.Windows.Forms.Label
        Me._Label1_4 = New System.Windows.Forms.Label
        Me._Label2_9 = New System.Windows.Forms.Label
        Me._Label2_8 = New System.Windows.Forms.Label
        Me._Label2_7 = New System.Windows.Forms.Label
        Me._Label2_6 = New System.Windows.Forms.Label
        Me._Label2_5 = New System.Windows.Forms.Label
        Me._Label3_7 = New System.Windows.Forms.Label
        Me._Label3_6 = New System.Windows.Forms.Label
        Me._Label3_5 = New System.Windows.Forms.Label
        Me._Label3_4 = New System.Windows.Forms.Label
        Me.Frame1 = New System.Windows.Forms.GroupBox
        Me.chkEscludiSez1 = New System.Windows.Forms.CheckBox
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdVai = New System.Windows.Forms.Button
        Me._txtMax_4 = New System.Windows.Forms.TextBox
        Me._txtMax_3 = New System.Windows.Forms.TextBox
        Me._txtMax_2 = New System.Windows.Forms.TextBox
        Me._txtMax_1 = New System.Windows.Forms.TextBox
        Me._txtIncr_4 = New System.Windows.Forms.TextBox
        Me._txtIncr_3 = New System.Windows.Forms.TextBox
        Me._txtIncr_2 = New System.Windows.Forms.TextBox
        Me._txtIncr_1 = New System.Windows.Forms.TextBox
        Me._txtMax_0 = New System.Windows.Forms.TextBox
        Me._txtIncr_0 = New System.Windows.Forms.TextBox
        Me._txtMin_4 = New System.Windows.Forms.TextBox
        Me._txtMin_3 = New System.Windows.Forms.TextBox
        Me._txtMin_2 = New System.Windows.Forms.TextBox
        Me._txtMin_1 = New System.Windows.Forms.TextBox
        Me._txtMin_0 = New System.Windows.Forms.TextBox
        Me._Label3_3 = New System.Windows.Forms.Label
        Me._Label3_2 = New System.Windows.Forms.Label
        Me._Label3_1 = New System.Windows.Forms.Label
        Me._Label3_0 = New System.Windows.Forms.Label
        Me._Label2_4 = New System.Windows.Forms.Label
        Me._Label2_3 = New System.Windows.Forms.Label
        Me._Label2_2 = New System.Windows.Forms.Label
        Me._Label2_1 = New System.Windows.Forms.Label
        Me._Label2_0 = New System.Windows.Forms.Label
        Me._Label1_2 = New System.Windows.Forms.Label
        Me._Label1_1 = New System.Windows.Forms.Label
        Me._Label1_0 = New System.Windows.Forms.Label
        Me.HelpProvider1 = New System.Windows.Forms.HelpProvider
        Me.Frame2.SuspendLayout()
        Me.Frame1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Frame2
        '
        Me.Frame2.BackColor = System.Drawing.SystemColors.Control
        Me.Frame2.Controls.Add(Me._txtMin_11)
        Me.Frame2.Controls.Add(Me.Break)
        Me.Frame2.Controls.Add(Me._txtMin_10)
        Me.Frame2.Controls.Add(Me._cmdScelta_1)
        Me.Frame2.Controls.Add(Me._cmdScelta_0)
        Me.Frame2.Controls.Add(Me._txtMin_9)
        Me.Frame2.Controls.Add(Me._txtMin_8)
        Me.Frame2.Controls.Add(Me._txtMin_7)
        Me.Frame2.Controls.Add(Me._txtMin_6)
        Me.Frame2.Controls.Add(Me._txtMin_5)
        Me.Frame2.Controls.Add(Me._txtIncr_9)
        Me.Frame2.Controls.Add(Me._txtIncr_8)
        Me.Frame2.Controls.Add(Me._txtIncr_7)
        Me.Frame2.Controls.Add(Me._txtIncr_6)
        Me.Frame2.Controls.Add(Me._txtIncr_5)
        Me.Frame2.Controls.Add(Me.Annulla)
        Me.Frame2.Controls.Add(Me._Label2_12)
        Me.Frame2.Controls.Add(Me._Label2_11)
        Me.Frame2.Controls.Add(Me._Label2_10)
        Me.Frame2.Controls.Add(Me._Label1_5)
        Me.Frame2.Controls.Add(Me._Label1_4)
        Me.Frame2.Controls.Add(Me._Label2_9)
        Me.Frame2.Controls.Add(Me._Label2_8)
        Me.Frame2.Controls.Add(Me._Label2_7)
        Me.Frame2.Controls.Add(Me._Label2_6)
        Me.Frame2.Controls.Add(Me._Label2_5)
        Me.Frame2.Controls.Add(Me._Label3_7)
        Me.Frame2.Controls.Add(Me._Label3_6)
        Me.Frame2.Controls.Add(Me._Label3_5)
        Me.Frame2.Controls.Add(Me._Label3_4)
        Me.Frame2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame2.Location = New System.Drawing.Point(0, 224)
        Me.Frame2.Name = "Frame2"
        Me.Frame2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame2.Size = New System.Drawing.Size(433, 289)
        Me.Frame2.TabIndex = 29
        Me.Frame2.TabStop = False
        Me.Frame2.Text = "Risultati"
        '
        '_txtMin_11
        '
        Me._txtMin_11.AcceptsReturn = True
        Me._txtMin_11.AutoSize = False
        Me._txtMin_11.BackColor = System.Drawing.SystemColors.Window
        Me._txtMin_11.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtMin_11.Enabled = False
        Me._txtMin_11.ForeColor = System.Drawing.SystemColors.WindowText
        Me._txtMin_11.Location = New System.Drawing.Point(152, 261)
        Me._txtMin_11.MaxLength = 0
        Me._txtMin_11.Name = "_txtMin_11"
        Me._txtMin_11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtMin_11.Size = New System.Drawing.Size(73, 19)
        Me._txtMin_11.TabIndex = 59
        Me._txtMin_11.Text = ""
        '
        'Break
        '
        Me.Break.BackColor = System.Drawing.SystemColors.Control
        Me.Break.Cursor = System.Windows.Forms.Cursors.Default
        Me.Break.Enabled = False
        Me.Break.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Break.Location = New System.Drawing.Point(352, 232)
        Me.Break.Name = "Break"
        Me.Break.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Break.Size = New System.Drawing.Size(73, 41)
        Me.Break.TabIndex = 57
        Me.Break.Text = "Break"
        '
        '_txtMin_10
        '
        Me._txtMin_10.AcceptsReturn = True
        Me._txtMin_10.AutoSize = False
        Me._txtMin_10.BackColor = System.Drawing.SystemColors.Window
        Me._txtMin_10.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtMin_10.Enabled = False
        Me._txtMin_10.ForeColor = System.Drawing.SystemColors.WindowText
        Me._txtMin_10.Location = New System.Drawing.Point(152, 240)
        Me._txtMin_10.MaxLength = 0
        Me._txtMin_10.Name = "_txtMin_10"
        Me._txtMin_10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtMin_10.Size = New System.Drawing.Size(73, 19)
        Me._txtMin_10.TabIndex = 56
        Me._txtMin_10.Text = ""
        '
        '_cmdScelta_1
        '
        Me._cmdScelta_1.BackColor = System.Drawing.SystemColors.Control
        Me._cmdScelta_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdScelta_1.Enabled = False
        Me._cmdScelta_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdScelta_1.Image = CType(resources.GetObject("_cmdScelta_1.Image"), System.Drawing.Image)
        Me._cmdScelta_1.Location = New System.Drawing.Point(288, 176)
        Me._cmdScelta_1.Name = "_cmdScelta_1"
        Me._cmdScelta_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdScelta_1.Size = New System.Drawing.Size(41, 57)
        Me._cmdScelta_1.TabIndex = 54
        Me._cmdScelta_1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        '_cmdScelta_0
        '
        Me._cmdScelta_0.BackColor = System.Drawing.SystemColors.Control
        Me._cmdScelta_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdScelta_0.Enabled = False
        Me._cmdScelta_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdScelta_0.Image = CType(resources.GetObject("_cmdScelta_0.Image"), System.Drawing.Image)
        Me._cmdScelta_0.Location = New System.Drawing.Point(168, 176)
        Me._cmdScelta_0.Name = "_cmdScelta_0"
        Me._cmdScelta_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdScelta_0.Size = New System.Drawing.Size(41, 57)
        Me._cmdScelta_0.TabIndex = 53
        Me._cmdScelta_0.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        '_txtMin_9
        '
        Me._txtMin_9.AcceptsReturn = True
        Me._txtMin_9.AutoSize = False
        Me._txtMin_9.BackColor = System.Drawing.SystemColors.Window
        Me._txtMin_9.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtMin_9.Enabled = False
        Me._txtMin_9.ForeColor = System.Drawing.SystemColors.WindowText
        Me._txtMin_9.Location = New System.Drawing.Point(152, 48)
        Me._txtMin_9.MaxLength = 0
        Me._txtMin_9.Name = "_txtMin_9"
        Me._txtMin_9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtMin_9.Size = New System.Drawing.Size(73, 19)
        Me._txtMin_9.TabIndex = 40
        Me._txtMin_9.Text = ""
        '
        '_txtMin_8
        '
        Me._txtMin_8.AcceptsReturn = True
        Me._txtMin_8.AutoSize = False
        Me._txtMin_8.BackColor = System.Drawing.SystemColors.Window
        Me._txtMin_8.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtMin_8.Enabled = False
        Me._txtMin_8.ForeColor = System.Drawing.SystemColors.WindowText
        Me._txtMin_8.Location = New System.Drawing.Point(152, 72)
        Me._txtMin_8.MaxLength = 0
        Me._txtMin_8.Name = "_txtMin_8"
        Me._txtMin_8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtMin_8.Size = New System.Drawing.Size(73, 19)
        Me._txtMin_8.TabIndex = 39
        Me._txtMin_8.Text = ""
        '
        '_txtMin_7
        '
        Me._txtMin_7.AcceptsReturn = True
        Me._txtMin_7.AutoSize = False
        Me._txtMin_7.BackColor = System.Drawing.SystemColors.Window
        Me._txtMin_7.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtMin_7.Enabled = False
        Me._txtMin_7.ForeColor = System.Drawing.SystemColors.WindowText
        Me._txtMin_7.Location = New System.Drawing.Point(152, 96)
        Me._txtMin_7.MaxLength = 0
        Me._txtMin_7.Name = "_txtMin_7"
        Me._txtMin_7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtMin_7.Size = New System.Drawing.Size(73, 19)
        Me._txtMin_7.TabIndex = 38
        Me._txtMin_7.Text = ""
        '
        '_txtMin_6
        '
        Me._txtMin_6.AcceptsReturn = True
        Me._txtMin_6.AutoSize = False
        Me._txtMin_6.BackColor = System.Drawing.SystemColors.Window
        Me._txtMin_6.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtMin_6.Enabled = False
        Me._txtMin_6.ForeColor = System.Drawing.SystemColors.WindowText
        Me._txtMin_6.Location = New System.Drawing.Point(152, 120)
        Me._txtMin_6.MaxLength = 0
        Me._txtMin_6.Name = "_txtMin_6"
        Me._txtMin_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtMin_6.Size = New System.Drawing.Size(73, 19)
        Me._txtMin_6.TabIndex = 37
        Me._txtMin_6.Text = ""
        '
        '_txtMin_5
        '
        Me._txtMin_5.AcceptsReturn = True
        Me._txtMin_5.AutoSize = False
        Me._txtMin_5.BackColor = System.Drawing.SystemColors.Window
        Me._txtMin_5.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtMin_5.Enabled = False
        Me._txtMin_5.ForeColor = System.Drawing.SystemColors.WindowText
        Me._txtMin_5.Location = New System.Drawing.Point(152, 144)
        Me._txtMin_5.MaxLength = 0
        Me._txtMin_5.Name = "_txtMin_5"
        Me._txtMin_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtMin_5.Size = New System.Drawing.Size(73, 19)
        Me._txtMin_5.TabIndex = 36
        Me._txtMin_5.Text = ""
        '
        '_txtIncr_9
        '
        Me._txtIncr_9.AcceptsReturn = True
        Me._txtIncr_9.AutoSize = False
        Me._txtIncr_9.BackColor = System.Drawing.SystemColors.Window
        Me._txtIncr_9.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtIncr_9.Enabled = False
        Me._txtIncr_9.ForeColor = System.Drawing.SystemColors.WindowText
        Me._txtIncr_9.Location = New System.Drawing.Point(272, 48)
        Me._txtIncr_9.MaxLength = 0
        Me._txtIncr_9.Name = "_txtIncr_9"
        Me._txtIncr_9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtIncr_9.Size = New System.Drawing.Size(65, 19)
        Me._txtIncr_9.TabIndex = 35
        Me._txtIncr_9.Text = ""
        '
        '_txtIncr_8
        '
        Me._txtIncr_8.AcceptsReturn = True
        Me._txtIncr_8.AutoSize = False
        Me._txtIncr_8.BackColor = System.Drawing.SystemColors.Window
        Me._txtIncr_8.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtIncr_8.Enabled = False
        Me._txtIncr_8.ForeColor = System.Drawing.SystemColors.WindowText
        Me._txtIncr_8.Location = New System.Drawing.Point(272, 72)
        Me._txtIncr_8.MaxLength = 0
        Me._txtIncr_8.Name = "_txtIncr_8"
        Me._txtIncr_8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtIncr_8.Size = New System.Drawing.Size(65, 19)
        Me._txtIncr_8.TabIndex = 34
        Me._txtIncr_8.Text = ""
        '
        '_txtIncr_7
        '
        Me._txtIncr_7.AcceptsReturn = True
        Me._txtIncr_7.AutoSize = False
        Me._txtIncr_7.BackColor = System.Drawing.SystemColors.Window
        Me._txtIncr_7.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtIncr_7.Enabled = False
        Me._txtIncr_7.ForeColor = System.Drawing.SystemColors.WindowText
        Me._txtIncr_7.Location = New System.Drawing.Point(272, 96)
        Me._txtIncr_7.MaxLength = 0
        Me._txtIncr_7.Name = "_txtIncr_7"
        Me._txtIncr_7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtIncr_7.Size = New System.Drawing.Size(65, 19)
        Me._txtIncr_7.TabIndex = 33
        Me._txtIncr_7.Text = ""
        '
        '_txtIncr_6
        '
        Me._txtIncr_6.AcceptsReturn = True
        Me._txtIncr_6.AutoSize = False
        Me._txtIncr_6.BackColor = System.Drawing.SystemColors.Window
        Me._txtIncr_6.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtIncr_6.Enabled = False
        Me._txtIncr_6.ForeColor = System.Drawing.SystemColors.WindowText
        Me._txtIncr_6.Location = New System.Drawing.Point(272, 120)
        Me._txtIncr_6.MaxLength = 0
        Me._txtIncr_6.Name = "_txtIncr_6"
        Me._txtIncr_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtIncr_6.Size = New System.Drawing.Size(65, 19)
        Me._txtIncr_6.TabIndex = 32
        Me._txtIncr_6.Text = ""
        '
        '_txtIncr_5
        '
        Me._txtIncr_5.AcceptsReturn = True
        Me._txtIncr_5.AutoSize = False
        Me._txtIncr_5.BackColor = System.Drawing.SystemColors.Window
        Me._txtIncr_5.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtIncr_5.Enabled = False
        Me._txtIncr_5.ForeColor = System.Drawing.SystemColors.WindowText
        Me._txtIncr_5.Location = New System.Drawing.Point(272, 144)
        Me._txtIncr_5.MaxLength = 0
        Me._txtIncr_5.Name = "_txtIncr_5"
        Me._txtIncr_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtIncr_5.Size = New System.Drawing.Size(65, 19)
        Me._txtIncr_5.TabIndex = 31
        Me._txtIncr_5.Text = ""
        '
        'Annulla
        '
        Me.Annulla.BackColor = System.Drawing.SystemColors.Control
        Me.Annulla.Cursor = System.Windows.Forms.Cursors.Default
        Me.Annulla.Enabled = False
        Me.Annulla.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Annulla.Location = New System.Drawing.Point(352, 176)
        Me.Annulla.Name = "Annulla"
        Me.Annulla.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Annulla.Size = New System.Drawing.Size(73, 41)
        Me.Annulla.TabIndex = 30
        Me.Annulla.Text = "Annulla"
        '
        '_Label2_12
        '
        Me._Label2_12.BackColor = System.Drawing.SystemColors.Control
        Me._Label2_12.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_12.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label2_12.Location = New System.Drawing.Point(24, 261)
        Me._Label2_12.Name = "_Label2_12"
        Me._Label2_12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_12.Size = New System.Drawing.Size(105, 17)
        Me._Label2_12.TabIndex = 60
        Me._Label2_12.Text = "Fattore d'uso attuale"
        '
        '_Label2_11
        '
        Me._Label2_11.BackColor = System.Drawing.SystemColors.Control
        Me._Label2_11.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_11.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label2_11.Location = New System.Drawing.Point(24, 240)
        Me._Label2_11.Name = "_Label2_11"
        Me._Label2_11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_11.Size = New System.Drawing.Size(105, 17)
        Me._Label2_11.TabIndex = 55
        Me._Label2_11.Text = "Fattore d'uso minimo"
        '
        '_Label2_10
        '
        Me._Label2_10.BackColor = System.Drawing.SystemColors.Control
        Me._Label2_10.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_10.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label2_10.Location = New System.Drawing.Point(32, 192)
        Me._Label2_10.Name = "_Label2_10"
        Me._Label2_10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_10.Size = New System.Drawing.Size(105, 17)
        Me._Label2_10.TabIndex = 52
        Me._Label2_10.Text = "La vostra scelta:"
        '
        '_Label1_5
        '
        Me._Label1_5.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_5.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_5.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_5.Location = New System.Drawing.Point(152, 24)
        Me._Label1_5.Name = "_Label1_5"
        Me._Label1_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_5.Size = New System.Drawing.Size(97, 17)
        Me._Label1_5.TabIndex = 51
        Me._Label1_5.Text = "Margine massimo"
        '
        '_Label1_4
        '
        Me._Label1_4.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_4.Location = New System.Drawing.Point(272, 24)
        Me._Label1_4.Name = "_Label1_4"
        Me._Label1_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_4.Size = New System.Drawing.Size(73, 17)
        Me._Label1_4.TabIndex = 50
        Me._Label1_4.Text = "Peso minimo"
        '
        '_Label2_9
        '
        Me._Label2_9.BackColor = System.Drawing.SystemColors.Control
        Me._Label2_9.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_9.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label2_9.Location = New System.Drawing.Point(16, 48)
        Me._Label2_9.Name = "_Label2_9"
        Me._Label2_9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_9.Size = New System.Drawing.Size(129, 17)
        Me._Label2_9.TabIndex = 49
        Me._Label2_9.Text = "Raggi interni ginocchi"
        '
        '_Label2_8
        '
        Me._Label2_8.BackColor = System.Drawing.SystemColors.Control
        Me._Label2_8.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_8.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label2_8.Location = New System.Drawing.Point(16, 72)
        Me._Label2_8.Name = "_Label2_8"
        Me._Label2_8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_8.Size = New System.Drawing.Size(129, 17)
        Me._Label2_8.TabIndex = 48
        Me._Label2_8.Text = "Lunghezza colletti"
        '
        '_Label2_7
        '
        Me._Label2_7.BackColor = System.Drawing.SystemColors.Control
        Me._Label2_7.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_7.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label2_7.Location = New System.Drawing.Point(16, 96)
        Me._Label2_7.Name = "_Label2_7"
        Me._Label2_7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_7.Size = New System.Drawing.Size(129, 17)
        Me._Label2_7.TabIndex = 47
        Me._Label2_7.Text = "Numero di onde"
        '
        '_Label2_6
        '
        Me._Label2_6.BackColor = System.Drawing.SystemColors.Control
        Me._Label2_6.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_6.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label2_6.Location = New System.Drawing.Point(16, 120)
        Me._Label2_6.Name = "_Label2_6"
        Me._Label2_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_6.Size = New System.Drawing.Size(129, 17)
        Me._Label2_6.TabIndex = 46
        Me._Label2_6.Text = "Altezza pareti verticali"
        '
        '_Label2_5
        '
        Me._Label2_5.BackColor = System.Drawing.SystemColors.Control
        Me._Label2_5.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_5.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label2_5.Location = New System.Drawing.Point(16, 144)
        Me._Label2_5.Name = "_Label2_5"
        Me._Label2_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_5.Size = New System.Drawing.Size(129, 17)
        Me._Label2_5.TabIndex = 45
        Me._Label2_5.Text = "Spessore"
        '
        '_Label3_7
        '
        Me._Label3_7.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(128, Byte), CType(0, Byte))
        Me._Label3_7.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label3_7.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label3_7.Location = New System.Drawing.Point(384, 48)
        Me._Label3_7.Name = "_Label3_7"
        Me._Label3_7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label3_7.Size = New System.Drawing.Size(33, 17)
        Me._Label3_7.TabIndex = 44
        Me._Label3_7.Text = " [mm]"
        '
        '_Label3_6
        '
        Me._Label3_6.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(128, Byte), CType(0, Byte))
        Me._Label3_6.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label3_6.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label3_6.Location = New System.Drawing.Point(384, 72)
        Me._Label3_6.Name = "_Label3_6"
        Me._Label3_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label3_6.Size = New System.Drawing.Size(33, 17)
        Me._Label3_6.TabIndex = 43
        Me._Label3_6.Text = " [mm]"
        '
        '_Label3_5
        '
        Me._Label3_5.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(128, Byte), CType(0, Byte))
        Me._Label3_5.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label3_5.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label3_5.Location = New System.Drawing.Point(384, 120)
        Me._Label3_5.Name = "_Label3_5"
        Me._Label3_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label3_5.Size = New System.Drawing.Size(33, 17)
        Me._Label3_5.TabIndex = 42
        Me._Label3_5.Text = " [mm]"
        '
        '_Label3_4
        '
        Me._Label3_4.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(128, Byte), CType(0, Byte))
        Me._Label3_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label3_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label3_4.Location = New System.Drawing.Point(384, 144)
        Me._Label3_4.Name = "_Label3_4"
        Me._Label3_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label3_4.Size = New System.Drawing.Size(33, 17)
        Me._Label3_4.TabIndex = 41
        Me._Label3_4.Text = " [mm]"
        '
        'Frame1
        '
        Me.Frame1.BackColor = System.Drawing.SystemColors.Control
        Me.Frame1.Controls.Add(Me.chkEscludiSez1)
        Me.Frame1.Controls.Add(Me.cmdCancel)
        Me.Frame1.Controls.Add(Me.cmdVai)
        Me.Frame1.Controls.Add(Me._txtMax_4)
        Me.Frame1.Controls.Add(Me._txtMax_3)
        Me.Frame1.Controls.Add(Me._txtMax_2)
        Me.Frame1.Controls.Add(Me._txtMax_1)
        Me.Frame1.Controls.Add(Me._txtIncr_4)
        Me.Frame1.Controls.Add(Me._txtIncr_3)
        Me.Frame1.Controls.Add(Me._txtIncr_2)
        Me.Frame1.Controls.Add(Me._txtIncr_1)
        Me.Frame1.Controls.Add(Me._txtMax_0)
        Me.Frame1.Controls.Add(Me._txtIncr_0)
        Me.Frame1.Controls.Add(Me._txtMin_4)
        Me.Frame1.Controls.Add(Me._txtMin_3)
        Me.Frame1.Controls.Add(Me._txtMin_2)
        Me.Frame1.Controls.Add(Me._txtMin_1)
        Me.Frame1.Controls.Add(Me._txtMin_0)
        Me.Frame1.Controls.Add(Me._Label3_3)
        Me.Frame1.Controls.Add(Me._Label3_2)
        Me.Frame1.Controls.Add(Me._Label3_1)
        Me.Frame1.Controls.Add(Me._Label3_0)
        Me.Frame1.Controls.Add(Me._Label2_4)
        Me.Frame1.Controls.Add(Me._Label2_3)
        Me.Frame1.Controls.Add(Me._Label2_2)
        Me.Frame1.Controls.Add(Me._Label2_1)
        Me.Frame1.Controls.Add(Me._Label2_0)
        Me.Frame1.Controls.Add(Me._Label1_2)
        Me.Frame1.Controls.Add(Me._Label1_1)
        Me.Frame1.Controls.Add(Me._Label1_0)
        Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame1.Location = New System.Drawing.Point(0, 0)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame1.Size = New System.Drawing.Size(433, 217)
        Me.Frame1.TabIndex = 0
        Me.Frame1.TabStop = False
        Me.Frame1.Text = "Limiti della ricerca"
        '
        'chkEscludiSez1
        '
        Me.chkEscludiSez1.BackColor = System.Drawing.SystemColors.Control
        Me.chkEscludiSez1.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkEscludiSez1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkEscludiSez1.Location = New System.Drawing.Point(16, 184)
        Me.chkEscludiSez1.Name = "chkEscludiSez1"
        Me.chkEscludiSez1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkEscludiSez1.Size = New System.Drawing.Size(105, 17)
        Me.chkEscludiSez1.TabIndex = 61
        Me.chkEscludiSez1.Text = "Escludi sezione 1"
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCancel.Location = New System.Drawing.Point(304, 176)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCancel.Size = New System.Drawing.Size(57, 33)
        Me.cmdCancel.TabIndex = 58
        Me.cmdCancel.Text = "Cancel"
        '
        'cmdVai
        '
        Me.cmdVai.BackColor = System.Drawing.SystemColors.Control
        Me.cmdVai.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdVai.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdVai.Location = New System.Drawing.Point(368, 176)
        Me.cmdVai.Name = "cmdVai"
        Me.cmdVai.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdVai.Size = New System.Drawing.Size(57, 33)
        Me.cmdVai.TabIndex = 28
        Me.cmdVai.Text = "OK"
        '
        '_txtMax_4
        '
        Me._txtMax_4.AcceptsReturn = True
        Me._txtMax_4.AutoSize = False
        Me._txtMax_4.BackColor = System.Drawing.SystemColors.Window
        Me._txtMax_4.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtMax_4.ForeColor = System.Drawing.SystemColors.WindowText
        Me._txtMax_4.Location = New System.Drawing.Point(304, 144)
        Me._txtMax_4.MaxLength = 0
        Me._txtMax_4.Name = "_txtMax_4"
        Me._txtMax_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtMax_4.Size = New System.Drawing.Size(65, 19)
        Me._txtMax_4.TabIndex = 18
        Me._txtMax_4.Text = "Text1"
        '
        '_txtMax_3
        '
        Me._txtMax_3.AcceptsReturn = True
        Me._txtMax_3.AutoSize = False
        Me._txtMax_3.BackColor = System.Drawing.SystemColors.Window
        Me._txtMax_3.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtMax_3.ForeColor = System.Drawing.SystemColors.WindowText
        Me._txtMax_3.Location = New System.Drawing.Point(304, 120)
        Me._txtMax_3.MaxLength = 0
        Me._txtMax_3.Name = "_txtMax_3"
        Me._txtMax_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtMax_3.Size = New System.Drawing.Size(65, 19)
        Me._txtMax_3.TabIndex = 17
        Me._txtMax_3.Text = "Text1"
        '
        '_txtMax_2
        '
        Me._txtMax_2.AcceptsReturn = True
        Me._txtMax_2.AutoSize = False
        Me._txtMax_2.BackColor = System.Drawing.SystemColors.Window
        Me._txtMax_2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtMax_2.ForeColor = System.Drawing.SystemColors.WindowText
        Me._txtMax_2.Location = New System.Drawing.Point(304, 96)
        Me._txtMax_2.MaxLength = 0
        Me._txtMax_2.Name = "_txtMax_2"
        Me._txtMax_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtMax_2.Size = New System.Drawing.Size(65, 19)
        Me._txtMax_2.TabIndex = 16
        Me._txtMax_2.Text = "Text1"
        '
        '_txtMax_1
        '
        Me._txtMax_1.AcceptsReturn = True
        Me._txtMax_1.AutoSize = False
        Me._txtMax_1.BackColor = System.Drawing.SystemColors.Window
        Me._txtMax_1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtMax_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me._txtMax_1.Location = New System.Drawing.Point(304, 72)
        Me._txtMax_1.MaxLength = 0
        Me._txtMax_1.Name = "_txtMax_1"
        Me._txtMax_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtMax_1.Size = New System.Drawing.Size(65, 19)
        Me._txtMax_1.TabIndex = 15
        Me._txtMax_1.Text = "Text1"
        '
        '_txtIncr_4
        '
        Me._txtIncr_4.AcceptsReturn = True
        Me._txtIncr_4.AutoSize = False
        Me._txtIncr_4.BackColor = System.Drawing.SystemColors.Window
        Me._txtIncr_4.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtIncr_4.ForeColor = System.Drawing.SystemColors.WindowText
        Me._txtIncr_4.Location = New System.Drawing.Point(232, 144)
        Me._txtIncr_4.MaxLength = 0
        Me._txtIncr_4.Name = "_txtIncr_4"
        Me._txtIncr_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtIncr_4.Size = New System.Drawing.Size(65, 19)
        Me._txtIncr_4.TabIndex = 14
        Me._txtIncr_4.Text = "Text1"
        '
        '_txtIncr_3
        '
        Me._txtIncr_3.AcceptsReturn = True
        Me._txtIncr_3.AutoSize = False
        Me._txtIncr_3.BackColor = System.Drawing.SystemColors.Window
        Me._txtIncr_3.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtIncr_3.ForeColor = System.Drawing.SystemColors.WindowText
        Me._txtIncr_3.Location = New System.Drawing.Point(232, 120)
        Me._txtIncr_3.MaxLength = 0
        Me._txtIncr_3.Name = "_txtIncr_3"
        Me._txtIncr_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtIncr_3.Size = New System.Drawing.Size(65, 19)
        Me._txtIncr_3.TabIndex = 13
        Me._txtIncr_3.Text = "Text1"
        '
        '_txtIncr_2
        '
        Me._txtIncr_2.AcceptsReturn = True
        Me._txtIncr_2.AutoSize = False
        Me._txtIncr_2.BackColor = System.Drawing.SystemColors.Window
        Me._txtIncr_2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtIncr_2.ForeColor = System.Drawing.SystemColors.WindowText
        Me._txtIncr_2.Location = New System.Drawing.Point(232, 96)
        Me._txtIncr_2.MaxLength = 0
        Me._txtIncr_2.Name = "_txtIncr_2"
        Me._txtIncr_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtIncr_2.Size = New System.Drawing.Size(65, 19)
        Me._txtIncr_2.TabIndex = 12
        Me._txtIncr_2.Text = "Text1"
        '
        '_txtIncr_1
        '
        Me._txtIncr_1.AcceptsReturn = True
        Me._txtIncr_1.AutoSize = False
        Me._txtIncr_1.BackColor = System.Drawing.SystemColors.Window
        Me._txtIncr_1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtIncr_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me._txtIncr_1.Location = New System.Drawing.Point(232, 72)
        Me._txtIncr_1.MaxLength = 0
        Me._txtIncr_1.Name = "_txtIncr_1"
        Me._txtIncr_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtIncr_1.Size = New System.Drawing.Size(65, 19)
        Me._txtIncr_1.TabIndex = 11
        Me._txtIncr_1.Text = "Text1"
        '
        '_txtMax_0
        '
        Me._txtMax_0.AcceptsReturn = True
        Me._txtMax_0.AutoSize = False
        Me._txtMax_0.BackColor = System.Drawing.SystemColors.Window
        Me._txtMax_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtMax_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._txtMax_0.Location = New System.Drawing.Point(304, 48)
        Me._txtMax_0.MaxLength = 0
        Me._txtMax_0.Name = "_txtMax_0"
        Me._txtMax_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtMax_0.Size = New System.Drawing.Size(65, 19)
        Me._txtMax_0.TabIndex = 10
        Me._txtMax_0.Text = "Text1"
        '
        '_txtIncr_0
        '
        Me._txtIncr_0.AcceptsReturn = True
        Me._txtIncr_0.AutoSize = False
        Me._txtIncr_0.BackColor = System.Drawing.SystemColors.Window
        Me._txtIncr_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtIncr_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._txtIncr_0.Location = New System.Drawing.Point(232, 48)
        Me._txtIncr_0.MaxLength = 0
        Me._txtIncr_0.Name = "_txtIncr_0"
        Me._txtIncr_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtIncr_0.Size = New System.Drawing.Size(65, 19)
        Me._txtIncr_0.TabIndex = 9
        Me._txtIncr_0.Text = "Text1"
        '
        '_txtMin_4
        '
        Me._txtMin_4.AcceptsReturn = True
        Me._txtMin_4.AutoSize = False
        Me._txtMin_4.BackColor = System.Drawing.SystemColors.Window
        Me._txtMin_4.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtMin_4.ForeColor = System.Drawing.SystemColors.WindowText
        Me._txtMin_4.Location = New System.Drawing.Point(152, 144)
        Me._txtMin_4.MaxLength = 0
        Me._txtMin_4.Name = "_txtMin_4"
        Me._txtMin_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtMin_4.Size = New System.Drawing.Size(73, 19)
        Me._txtMin_4.TabIndex = 8
        Me._txtMin_4.Text = "Text1"
        '
        '_txtMin_3
        '
        Me._txtMin_3.AcceptsReturn = True
        Me._txtMin_3.AutoSize = False
        Me._txtMin_3.BackColor = System.Drawing.SystemColors.Window
        Me._txtMin_3.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtMin_3.ForeColor = System.Drawing.SystemColors.WindowText
        Me._txtMin_3.Location = New System.Drawing.Point(152, 120)
        Me._txtMin_3.MaxLength = 0
        Me._txtMin_3.Name = "_txtMin_3"
        Me._txtMin_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtMin_3.Size = New System.Drawing.Size(73, 19)
        Me._txtMin_3.TabIndex = 7
        Me._txtMin_3.Text = "Text1"
        '
        '_txtMin_2
        '
        Me._txtMin_2.AcceptsReturn = True
        Me._txtMin_2.AutoSize = False
        Me._txtMin_2.BackColor = System.Drawing.SystemColors.Window
        Me._txtMin_2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtMin_2.ForeColor = System.Drawing.SystemColors.WindowText
        Me._txtMin_2.Location = New System.Drawing.Point(152, 96)
        Me._txtMin_2.MaxLength = 0
        Me._txtMin_2.Name = "_txtMin_2"
        Me._txtMin_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtMin_2.Size = New System.Drawing.Size(73, 19)
        Me._txtMin_2.TabIndex = 6
        Me._txtMin_2.Text = "Text1"
        '
        '_txtMin_1
        '
        Me._txtMin_1.AcceptsReturn = True
        Me._txtMin_1.AutoSize = False
        Me._txtMin_1.BackColor = System.Drawing.SystemColors.Window
        Me._txtMin_1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtMin_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me._txtMin_1.Location = New System.Drawing.Point(152, 72)
        Me._txtMin_1.MaxLength = 0
        Me._txtMin_1.Name = "_txtMin_1"
        Me._txtMin_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtMin_1.Size = New System.Drawing.Size(73, 19)
        Me._txtMin_1.TabIndex = 5
        Me._txtMin_1.Text = "Text1"
        '
        '_txtMin_0
        '
        Me._txtMin_0.AcceptsReturn = True
        Me._txtMin_0.AutoSize = False
        Me._txtMin_0.BackColor = System.Drawing.SystemColors.Window
        Me._txtMin_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtMin_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._txtMin_0.Location = New System.Drawing.Point(152, 48)
        Me._txtMin_0.MaxLength = 0
        Me._txtMin_0.Name = "_txtMin_0"
        Me._txtMin_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtMin_0.Size = New System.Drawing.Size(73, 19)
        Me._txtMin_0.TabIndex = 1
        Me._txtMin_0.Text = "Text1"
        '
        '_Label3_3
        '
        Me._Label3_3.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(128, Byte), CType(0, Byte))
        Me._Label3_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label3_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label3_3.Location = New System.Drawing.Point(384, 144)
        Me._Label3_3.Name = "_Label3_3"
        Me._Label3_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label3_3.Size = New System.Drawing.Size(33, 17)
        Me._Label3_3.TabIndex = 27
        Me._Label3_3.Text = " [mm]"
        '
        '_Label3_2
        '
        Me._Label3_2.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(128, Byte), CType(0, Byte))
        Me._Label3_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label3_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label3_2.Location = New System.Drawing.Point(384, 120)
        Me._Label3_2.Name = "_Label3_2"
        Me._Label3_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label3_2.Size = New System.Drawing.Size(33, 17)
        Me._Label3_2.TabIndex = 26
        Me._Label3_2.Text = " [mm]"
        '
        '_Label3_1
        '
        Me._Label3_1.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(128, Byte), CType(0, Byte))
        Me._Label3_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label3_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label3_1.Location = New System.Drawing.Point(384, 72)
        Me._Label3_1.Name = "_Label3_1"
        Me._Label3_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label3_1.Size = New System.Drawing.Size(33, 17)
        Me._Label3_1.TabIndex = 25
        Me._Label3_1.Text = " [mm]"
        '
        '_Label3_0
        '
        Me._Label3_0.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(128, Byte), CType(0, Byte))
        Me._Label3_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label3_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label3_0.Location = New System.Drawing.Point(384, 48)
        Me._Label3_0.Name = "_Label3_0"
        Me._Label3_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label3_0.Size = New System.Drawing.Size(33, 17)
        Me._Label3_0.TabIndex = 24
        Me._Label3_0.Text = " [mm]"
        '
        '_Label2_4
        '
        Me._Label2_4.BackColor = System.Drawing.SystemColors.Control
        Me._Label2_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label2_4.Location = New System.Drawing.Point(16, 144)
        Me._Label2_4.Name = "_Label2_4"
        Me._Label2_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_4.Size = New System.Drawing.Size(129, 17)
        Me._Label2_4.TabIndex = 23
        Me._Label2_4.Text = "Spessore"
        '
        '_Label2_3
        '
        Me._Label2_3.BackColor = System.Drawing.SystemColors.Control
        Me._Label2_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label2_3.Location = New System.Drawing.Point(16, 120)
        Me._Label2_3.Name = "_Label2_3"
        Me._Label2_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_3.Size = New System.Drawing.Size(129, 17)
        Me._Label2_3.TabIndex = 22
        Me._Label2_3.Text = "Altezza pareti verticali"
        '
        '_Label2_2
        '
        Me._Label2_2.BackColor = System.Drawing.SystemColors.Control
        Me._Label2_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label2_2.Location = New System.Drawing.Point(16, 96)
        Me._Label2_2.Name = "_Label2_2"
        Me._Label2_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_2.Size = New System.Drawing.Size(129, 17)
        Me._Label2_2.TabIndex = 21
        Me._Label2_2.Text = "Numero di onde"
        '
        '_Label2_1
        '
        Me._Label2_1.BackColor = System.Drawing.SystemColors.Control
        Me._Label2_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label2_1.Location = New System.Drawing.Point(16, 72)
        Me._Label2_1.Name = "_Label2_1"
        Me._Label2_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_1.Size = New System.Drawing.Size(129, 17)
        Me._Label2_1.TabIndex = 20
        Me._Label2_1.Text = "Lunghezza colletti"
        '
        '_Label2_0
        '
        Me._Label2_0.BackColor = System.Drawing.SystemColors.Control
        Me._Label2_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label2_0.Location = New System.Drawing.Point(16, 48)
        Me._Label2_0.Name = "_Label2_0"
        Me._Label2_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_0.Size = New System.Drawing.Size(129, 17)
        Me._Label2_0.TabIndex = 19
        Me._Label2_0.Text = "Raggi interni ginocchi"
        '
        '_Label1_2
        '
        Me._Label1_2.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_2.Location = New System.Drawing.Point(304, 24)
        Me._Label1_2.Name = "_Label1_2"
        Me._Label1_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_2.Size = New System.Drawing.Size(100, 17)
        Me._Label1_2.TabIndex = 4
        Me._Label1_2.Text = "Valore massimo"
        '
        '_Label1_1
        '
        Me._Label1_1.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_1.Location = New System.Drawing.Point(232, 24)
        Me._Label1_1.Name = "_Label1_1"
        Me._Label1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_1.Size = New System.Drawing.Size(73, 17)
        Me._Label1_1.TabIndex = 3
        Me._Label1_1.Text = "Incremento"
        '
        '_Label1_0
        '
        Me._Label1_0.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_0.Location = New System.Drawing.Point(152, 24)
        Me._Label1_0.Name = "_Label1_0"
        Me._Label1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_0.Size = New System.Drawing.Size(73, 17)
        Me._Label1_0.TabIndex = 2
        Me._Label1_0.Text = "Valore minimo"
        '
        'frmOptim
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(437, 515)
        Me.Controls.Add(Me.Frame2)
        Me.Controls.Add(Me.Frame1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.HelpButton = True
        Me.Location = New System.Drawing.Point(4, 23)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmOptim"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "Ricerca del dilatatore ottimale"
        Me.Frame2.ResumeLayout(False)
        Me.Frame1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
#End Region 
#Region "Supporto aggiornamento "
	Private Shared m_vb6FormDefInstance As frmOptim
	Private Shared m_InitializingDefInstance As Boolean
	Public Shared Property DefInstance() As frmOptim
		Get
			If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
				m_InitializingDefInstance = True
				m_vb6FormDefInstance = New frmOptim()
				m_InitializingDefInstance = False
			End If
			DefInstance = m_vb6FormDefInstance
		End Get
		Set
			m_vb6FormDefInstance = Value
		End Set
	End Property
#End Region 
	Public Breackato As Boolean
	Public Cancellato As Boolean
    Public Scelta As Short
    Private Inizializzando As Boolean
    Private Sub Inizializza()
        HelpProvider1.HelpNamespace = RadiceHelp

    End Sub
    Private Sub Annulla_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Annulla.Click
        Scelta = -1
        Hide()
    End Sub
    Private Sub Break_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Break.Click
        Breackato = True
    End Sub
    Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
        Cancellato = True
        Hide()
    End Sub
    Private Sub cmdVai_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdVai.Click
        Cancellato = False
        Hide()
    End Sub

    Private Sub _cmdScelta_0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmdScelta_0.Click
        Scelta = 0
        Hide()
    End Sub

    Private Sub _cmdScelta_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmdScelta_1.Click
        Scelta = 1
        Hide()
    End Sub
    Friend ReadOnly Property txtIncr(ByVal i As Short) As TextBox
        Get
            Select Case i
                Case 0 : Return _txtIncr_0
                Case 1 : Return _txtIncr_1
                Case 2 : Return _txtIncr_2
                Case 3 : Return _txtIncr_3
                Case 4 : Return _txtIncr_4
                Case 5 : Return _txtIncr_5
                Case 6 : Return _txtIncr_6
                Case 7 : Return _txtIncr_7
                Case 8 : Return _txtIncr_8
                Case 9 : Return _txtIncr_9
                Case Else : Return Nothing
            End Select
        End Get
    End Property
    Friend ReadOnly Property txtMax(ByVal i As Short) As TextBox
        Get
            Select Case i
                Case 0 : Return _txtMax_0
                Case 1 : Return _txtMax_1
                Case 2 : Return _txtMax_2
                Case 3 : Return _txtMax_3
                Case 4 : Return _txtMax_4
                Case Else : Return Nothing
            End Select
        End Get
    End Property
    Friend ReadOnly Property txtMin(ByVal i As Short) As TextBox
        Get
            Select Case i
                Case 0 : Return _txtMin_0
                Case 1 : Return _txtMin_1
                Case 2 : Return _txtMin_2
                Case 3 : Return _txtMin_3
                Case 4 : Return _txtMin_4
                Case 5 : Return _txtMin_5
                Case 6 : Return _txtMin_6
                Case 7 : Return _txtMin_7
                Case 8 : Return _txtMin_8
                Case 9 : Return _txtMin_9
                Case 10 : Return _txtMin_10
                Case 11 : Return _txtMin_11
                Case Else : Return Nothing
            End Select
        End Get
    End Property
End Class