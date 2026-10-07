Option Strict Off
Option Explicit On
Imports RoutBase1
Friend Class frmDiaf
    Inherits System.Windows.Forms.Form
#Region "Codice generato dalla finestra di progettazione Windows Form "
    Public Sub New()
        MyBase.New()
        'Chiamata richiesta dalla progettazione Windows Form.
        InitializeComponent()
        '        Inizializza()
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
    Public WithEvents _Command1_2 As System.Windows.Forms.Button
    Private cmdCil As ButtonArray
    Public WithEvents _cmdCil_0 As System.Windows.Forms.Button
    Public WithEvents _Text1_35 As System.Windows.Forms.TextBox
    Public WithEvents _Text1_34 As System.Windows.Forms.TextBox
    Public WithEvents _Text1_33 As System.Windows.Forms.TextBox
    Public WithEvents _Text1_32 As System.Windows.Forms.TextBox
    Public WithEvents _Text1_31 As System.Windows.Forms.TextBox
    Public WithEvents _Text1_30 As System.Windows.Forms.TextBox
    Public WithEvents _Text1_29 As System.Windows.Forms.TextBox
    Public WithEvents _Text1_28 As System.Windows.Forms.TextBox
    Public WithEvents _Text1_27 As System.Windows.Forms.TextBox
    Public WithEvents _Text1_26 As System.Windows.Forms.TextBox
    Public WithEvents _Text1_25 As System.Windows.Forms.TextBox
    Public WithEvents _Text1_24 As System.Windows.Forms.TextBox
    Public WithEvents _Text1_23 As System.Windows.Forms.TextBox
    Public WithEvents _Text1_22 As System.Windows.Forms.TextBox
    Public WithEvents _Command1_1 As System.Windows.Forms.Button
    Public WithEvents _Command1_0 As System.Windows.Forms.Button
    Public WithEvents _Text1_21 As System.Windows.Forms.TextBox
    Public WithEvents _Text1_20 As System.Windows.Forms.TextBox
    Public WithEvents _Text1_19 As System.Windows.Forms.TextBox
    Public WithEvents _Text1_18 As System.Windows.Forms.TextBox
    Public WithEvents _Text1_17 As System.Windows.Forms.TextBox
    Public WithEvents _Text1_16 As System.Windows.Forms.TextBox
    Public WithEvents _Text1_15 As System.Windows.Forms.TextBox
    Public WithEvents _Text1_14 As System.Windows.Forms.TextBox
    Public WithEvents _Text1_13 As System.Windows.Forms.TextBox
    Public WithEvents _Text1_12 As System.Windows.Forms.TextBox
    Public WithEvents _Text1_11 As System.Windows.Forms.TextBox
    Public WithEvents _Text1_10 As System.Windows.Forms.TextBox
    Public WithEvents _Text1_9 As System.Windows.Forms.TextBox
    Public WithEvents _Text1_8 As System.Windows.Forms.TextBox
    Public WithEvents _Text1_7 As System.Windows.Forms.TextBox
    Public WithEvents _Text1_6 As System.Windows.Forms.TextBox
    Public WithEvents _Text1_5 As System.Windows.Forms.TextBox
    Public WithEvents _Text1_4 As System.Windows.Forms.TextBox
    Public WithEvents _Text1_3 As System.Windows.Forms.TextBox
    Public WithEvents _Text1_2 As System.Windows.Forms.TextBox
    Public WithEvents _Text1_1 As System.Windows.Forms.TextBox
    Public WithEvents _Text1_0 As System.Windows.Forms.TextBox
    Public WithEvents _Label2_30 As System.Windows.Forms.Label
    Public WithEvents _Label2_29 As System.Windows.Forms.Label
    Public WithEvents _Label2_28 As System.Windows.Forms.Label
    Public WithEvents _Label2_27 As System.Windows.Forms.Label
    Public WithEvents _Label1_35 As System.Windows.Forms.Label
    Public WithEvents _Label1_34 As System.Windows.Forms.Label
    Public WithEvents _Label1_33 As System.Windows.Forms.Label
    Public WithEvents _Label1_32 As System.Windows.Forms.Label
    Public WithEvents _Label1_31 As System.Windows.Forms.Label
    Public WithEvents _Label1_30 As System.Windows.Forms.Label
    Public WithEvents _Label1_29 As System.Windows.Forms.Label
    Public WithEvents _Label2_26 As System.Windows.Forms.Label
    Public WithEvents _Label2_25 As System.Windows.Forms.Label
    Public WithEvents _Label2_24 As System.Windows.Forms.Label
    Public WithEvents _Label2_23 As System.Windows.Forms.Label
    Public WithEvents _Label2_22 As System.Windows.Forms.Label
    Public WithEvents _Label1_28 As System.Windows.Forms.Label
    Public WithEvents _Label1_27 As System.Windows.Forms.Label
    Public WithEvents _Label1_26 As System.Windows.Forms.Label
    Public WithEvents _Label1_25 As System.Windows.Forms.Label
    Public WithEvents _Label1_24 As System.Windows.Forms.Label
    Public WithEvents _Label1_23 As System.Windows.Forms.Label
    Public WithEvents _Label1_22 As System.Windows.Forms.Label
    Public WithEvents _Label2_21 As System.Windows.Forms.Label
    Public WithEvents _Label2_20 As System.Windows.Forms.Label
    Public WithEvents _Label2_19 As System.Windows.Forms.Label
    Public WithEvents _Label2_18 As System.Windows.Forms.Label
    Public WithEvents _Label2_17 As System.Windows.Forms.Label
    Public WithEvents _Label2_16 As System.Windows.Forms.Label
    Public WithEvents _Label2_15 As System.Windows.Forms.Label
    Public WithEvents _Label2_14 As System.Windows.Forms.Label
    Public WithEvents _Label2_13 As System.Windows.Forms.Label
    Public WithEvents _Label2_12 As System.Windows.Forms.Label
    Public WithEvents _Label2_11 As System.Windows.Forms.Label
    Public WithEvents _Label2_10 As System.Windows.Forms.Label
    Public WithEvents _Label2_9 As System.Windows.Forms.Label
    Public WithEvents _Label2_8 As System.Windows.Forms.Label
    Public WithEvents _Label2_7 As System.Windows.Forms.Label
    Public WithEvents _Label2_6 As System.Windows.Forms.Label
    Public WithEvents _Label2_5 As System.Windows.Forms.Label
    Public WithEvents _Label2_4 As System.Windows.Forms.Label
    Public WithEvents _Label2_3 As System.Windows.Forms.Label
    Public WithEvents _Label2_2 As System.Windows.Forms.Label
    Public WithEvents _Label2_1 As System.Windows.Forms.Label
    Public WithEvents _Label2_0 As System.Windows.Forms.Label
    Public WithEvents _Label1_21 As System.Windows.Forms.Label
    Public WithEvents _Label1_20 As System.Windows.Forms.Label
    Public WithEvents _Label1_19 As System.Windows.Forms.Label
    Public WithEvents _Label1_18 As System.Windows.Forms.Label
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
    Friend WithEvents chkAgganciatoD As System.Windows.Forms.CheckBox
    Friend WithEvents chkAgganciatoB As System.Windows.Forms.CheckBox
    Friend WithEvents chkAgganciatoC As System.Windows.Forms.CheckBox
    Friend WithEvents chkAgganciatoF As System.Windows.Forms.CheckBox
    Friend WithEvents chkAgganciatoW As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmDiaf))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me._Command1_2 = New System.Windows.Forms.Button
        Me._cmdCil_0 = New System.Windows.Forms.Button
        Me._Text1_35 = New System.Windows.Forms.TextBox
        Me._Text1_34 = New System.Windows.Forms.TextBox
        Me._Text1_33 = New System.Windows.Forms.TextBox
        Me._Text1_32 = New System.Windows.Forms.TextBox
        Me._Text1_31 = New System.Windows.Forms.TextBox
        Me._Text1_30 = New System.Windows.Forms.TextBox
        Me._Text1_29 = New System.Windows.Forms.TextBox
        Me._Text1_28 = New System.Windows.Forms.TextBox
        Me._Text1_27 = New System.Windows.Forms.TextBox
        Me._Text1_26 = New System.Windows.Forms.TextBox
        Me._Text1_25 = New System.Windows.Forms.TextBox
        Me._Text1_24 = New System.Windows.Forms.TextBox
        Me._Text1_23 = New System.Windows.Forms.TextBox
        Me._Text1_22 = New System.Windows.Forms.TextBox
        Me._Command1_1 = New System.Windows.Forms.Button
        Me._Command1_0 = New System.Windows.Forms.Button
        Me._Text1_21 = New System.Windows.Forms.TextBox
        Me._Text1_20 = New System.Windows.Forms.TextBox
        Me._Text1_19 = New System.Windows.Forms.TextBox
        Me._Text1_18 = New System.Windows.Forms.TextBox
        Me._Text1_17 = New System.Windows.Forms.TextBox
        Me._Text1_16 = New System.Windows.Forms.TextBox
        Me._Text1_15 = New System.Windows.Forms.TextBox
        Me._Text1_14 = New System.Windows.Forms.TextBox
        Me._Text1_13 = New System.Windows.Forms.TextBox
        Me._Text1_12 = New System.Windows.Forms.TextBox
        Me._Text1_11 = New System.Windows.Forms.TextBox
        Me._Text1_10 = New System.Windows.Forms.TextBox
        Me._Text1_9 = New System.Windows.Forms.TextBox
        Me._Text1_8 = New System.Windows.Forms.TextBox
        Me._Text1_7 = New System.Windows.Forms.TextBox
        Me._Text1_6 = New System.Windows.Forms.TextBox
        Me._Text1_5 = New System.Windows.Forms.TextBox
        Me._Text1_4 = New System.Windows.Forms.TextBox
        Me._Text1_3 = New System.Windows.Forms.TextBox
        Me._Text1_2 = New System.Windows.Forms.TextBox
        Me._Text1_1 = New System.Windows.Forms.TextBox
        Me._Text1_0 = New System.Windows.Forms.TextBox
        Me._Label2_30 = New System.Windows.Forms.Label
        Me._Label2_29 = New System.Windows.Forms.Label
        Me._Label2_28 = New System.Windows.Forms.Label
        Me._Label2_27 = New System.Windows.Forms.Label
        Me._Label1_35 = New System.Windows.Forms.Label
        Me._Label1_34 = New System.Windows.Forms.Label
        Me._Label1_33 = New System.Windows.Forms.Label
        Me._Label1_32 = New System.Windows.Forms.Label
        Me._Label1_31 = New System.Windows.Forms.Label
        Me._Label1_30 = New System.Windows.Forms.Label
        Me._Label1_29 = New System.Windows.Forms.Label
        Me._Label2_26 = New System.Windows.Forms.Label
        Me._Label2_25 = New System.Windows.Forms.Label
        Me._Label2_24 = New System.Windows.Forms.Label
        Me._Label2_23 = New System.Windows.Forms.Label
        Me._Label2_22 = New System.Windows.Forms.Label
        Me._Label1_28 = New System.Windows.Forms.Label
        Me._Label1_27 = New System.Windows.Forms.Label
        Me._Label1_26 = New System.Windows.Forms.Label
        Me._Label1_25 = New System.Windows.Forms.Label
        Me._Label1_24 = New System.Windows.Forms.Label
        Me._Label1_23 = New System.Windows.Forms.Label
        Me._Label1_22 = New System.Windows.Forms.Label
        Me._Label2_21 = New System.Windows.Forms.Label
        Me._Label2_20 = New System.Windows.Forms.Label
        Me._Label2_19 = New System.Windows.Forms.Label
        Me._Label2_18 = New System.Windows.Forms.Label
        Me._Label2_17 = New System.Windows.Forms.Label
        Me._Label2_16 = New System.Windows.Forms.Label
        Me._Label2_15 = New System.Windows.Forms.Label
        Me._Label2_14 = New System.Windows.Forms.Label
        Me._Label2_13 = New System.Windows.Forms.Label
        Me._Label2_12 = New System.Windows.Forms.Label
        Me._Label2_11 = New System.Windows.Forms.Label
        Me._Label2_10 = New System.Windows.Forms.Label
        Me._Label2_9 = New System.Windows.Forms.Label
        Me._Label2_8 = New System.Windows.Forms.Label
        Me._Label2_7 = New System.Windows.Forms.Label
        Me._Label2_6 = New System.Windows.Forms.Label
        Me._Label2_5 = New System.Windows.Forms.Label
        Me._Label2_4 = New System.Windows.Forms.Label
        Me._Label2_3 = New System.Windows.Forms.Label
        Me._Label2_2 = New System.Windows.Forms.Label
        Me._Label2_1 = New System.Windows.Forms.Label
        Me._Label2_0 = New System.Windows.Forms.Label
        Me._Label1_21 = New System.Windows.Forms.Label
        Me._Label1_20 = New System.Windows.Forms.Label
        Me._Label1_19 = New System.Windows.Forms.Label
        Me._Label1_18 = New System.Windows.Forms.Label
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
        Me.chkAgganciatoD = New System.Windows.Forms.CheckBox
        Me.chkAgganciatoB = New System.Windows.Forms.CheckBox
        Me.chkAgganciatoC = New System.Windows.Forms.CheckBox
        Me.chkAgganciatoF = New System.Windows.Forms.CheckBox
        Me.chkAgganciatoW = New System.Windows.Forms.CheckBox
        Me.SuspendLayout()
        '
        '_Command1_2
        '
        Me._Command1_2.BackColor = System.Drawing.SystemColors.Control
        Me._Command1_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._Command1_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Command1_2.Image = CType(resources.GetObject("_Command1_2.Image"), System.Drawing.Image)
        Me._Command1_2.Location = New System.Drawing.Point(344, 424)
        Me._Command1_2.Name = "_Command1_2"
        Me._Command1_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Command1_2.Size = New System.Drawing.Size(39, 33)
        Me._Command1_2.TabIndex = 106
        Me._Command1_2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me._Command1_2, "Copia i dati ottenuti dal calcolo appena eseguito")
        '
        '_cmdCil_0
        '
        Me._cmdCil_0.BackColor = System.Drawing.SystemColors.Control
        Me._cmdCil_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdCil_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdCil_0.Image = CType(resources.GetObject("_cmdCil_0.Image"), System.Drawing.Image)
        Me._cmdCil_0.Location = New System.Drawing.Point(208, 8)
        Me._cmdCil_0.Name = "_cmdCil_0"
        Me._cmdCil_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdCil_0.Size = New System.Drawing.Size(20, 20)
        Me._cmdCil_0.TabIndex = 105
        Me._cmdCil_0.TabStop = False
        Me._cmdCil_0.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        '_Text1_35
        '
        Me._Text1_35.AcceptsReturn = True
        Me._Text1_35.AutoSize = False
        Me._Text1_35.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_35.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_35.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_35.Location = New System.Drawing.Point(0, 0)
        Me._Text1_35.MaxLength = 0
        Me._Text1_35.Name = "_Text1_35"
        Me._Text1_35.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_35.Size = New System.Drawing.Size(113, 25)
        Me._Text1_35.TabIndex = 100
        Me._Text1_35.Text = "Text1"
        '
        '_Text1_34
        '
        Me._Text1_34.AcceptsReturn = True
        Me._Text1_34.AutoSize = False
        Me._Text1_34.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_34.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_34.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_34.Location = New System.Drawing.Point(0, 0)
        Me._Text1_34.MaxLength = 0
        Me._Text1_34.Name = "_Text1_34"
        Me._Text1_34.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_34.Size = New System.Drawing.Size(113, 25)
        Me._Text1_34.TabIndex = 99
        Me._Text1_34.Text = "Text1"
        '
        '_Text1_33
        '
        Me._Text1_33.AcceptsReturn = True
        Me._Text1_33.AutoSize = False
        Me._Text1_33.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_33.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_33.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_33.Location = New System.Drawing.Point(0, 0)
        Me._Text1_33.MaxLength = 0
        Me._Text1_33.Name = "_Text1_33"
        Me._Text1_33.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_33.Size = New System.Drawing.Size(113, 25)
        Me._Text1_33.TabIndex = 98
        Me._Text1_33.Text = "Text1"
        '
        '_Text1_32
        '
        Me._Text1_32.AcceptsReturn = True
        Me._Text1_32.AutoSize = False
        Me._Text1_32.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_32.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_32.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_32.Location = New System.Drawing.Point(0, 0)
        Me._Text1_32.MaxLength = 0
        Me._Text1_32.Name = "_Text1_32"
        Me._Text1_32.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_32.Size = New System.Drawing.Size(113, 25)
        Me._Text1_32.TabIndex = 97
        Me._Text1_32.Text = "Text1"
        '
        '_Text1_31
        '
        Me._Text1_31.AcceptsReturn = True
        Me._Text1_31.AutoSize = False
        Me._Text1_31.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_31.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_31.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_31.Location = New System.Drawing.Point(360, 136)
        Me._Text1_31.MaxLength = 0
        Me._Text1_31.Name = "_Text1_31"
        Me._Text1_31.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_31.Size = New System.Drawing.Size(113, 25)
        Me._Text1_31.TabIndex = 92
        Me._Text1_31.Text = "Text1"
        '
        '_Text1_30
        '
        Me._Text1_30.AcceptsReturn = True
        Me._Text1_30.AutoSize = False
        Me._Text1_30.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_30.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_30.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_30.Location = New System.Drawing.Point(320, 224)
        Me._Text1_30.MaxLength = 0
        Me._Text1_30.Name = "_Text1_30"
        Me._Text1_30.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_30.Size = New System.Drawing.Size(113, 25)
        Me._Text1_30.TabIndex = 91
        Me._Text1_30.Text = "Text1"
        '
        '_Text1_29
        '
        Me._Text1_29.AcceptsReturn = True
        Me._Text1_29.AutoSize = False
        Me._Text1_29.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_29.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_29.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_29.Location = New System.Drawing.Point(376, 264)
        Me._Text1_29.MaxLength = 0
        Me._Text1_29.Name = "_Text1_29"
        Me._Text1_29.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_29.Size = New System.Drawing.Size(113, 25)
        Me._Text1_29.TabIndex = 88
        Me._Text1_29.Text = "Text1"
        '
        '_Text1_28
        '
        Me._Text1_28.AcceptsReturn = True
        Me._Text1_28.AutoSize = False
        Me._Text1_28.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_28.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_28.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_28.Location = New System.Drawing.Point(40, 24)
        Me._Text1_28.MaxLength = 0
        Me._Text1_28.Name = "_Text1_28"
        Me._Text1_28.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_28.Size = New System.Drawing.Size(113, 25)
        Me._Text1_28.TabIndex = 87
        Me._Text1_28.Text = "Text1"
        '
        '_Text1_27
        '
        Me._Text1_27.AcceptsReturn = True
        Me._Text1_27.AutoSize = False
        Me._Text1_27.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_27.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_27.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_27.Location = New System.Drawing.Point(344, 88)
        Me._Text1_27.MaxLength = 0
        Me._Text1_27.Name = "_Text1_27"
        Me._Text1_27.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_27.Size = New System.Drawing.Size(113, 25)
        Me._Text1_27.TabIndex = 86
        Me._Text1_27.Text = "Text1"
        '
        '_Text1_26
        '
        Me._Text1_26.AcceptsReturn = True
        Me._Text1_26.AutoSize = False
        Me._Text1_26.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_26.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_26.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_26.Location = New System.Drawing.Point(320, 88)
        Me._Text1_26.MaxLength = 0
        Me._Text1_26.Name = "_Text1_26"
        Me._Text1_26.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_26.Size = New System.Drawing.Size(113, 25)
        Me._Text1_26.TabIndex = 85
        Me._Text1_26.Text = "Text1"
        '
        '_Text1_25
        '
        Me._Text1_25.AcceptsReturn = True
        Me._Text1_25.AutoSize = False
        Me._Text1_25.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_25.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_25.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_25.Location = New System.Drawing.Point(296, 80)
        Me._Text1_25.MaxLength = 0
        Me._Text1_25.Name = "_Text1_25"
        Me._Text1_25.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_25.Size = New System.Drawing.Size(113, 25)
        Me._Text1_25.TabIndex = 84
        Me._Text1_25.Text = "Text1"
        '
        '_Text1_24
        '
        Me._Text1_24.AcceptsReturn = True
        Me._Text1_24.AutoSize = False
        Me._Text1_24.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_24.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_24.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_24.Location = New System.Drawing.Point(272, 96)
        Me._Text1_24.MaxLength = 0
        Me._Text1_24.Name = "_Text1_24"
        Me._Text1_24.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_24.Size = New System.Drawing.Size(113, 25)
        Me._Text1_24.TabIndex = 83
        Me._Text1_24.Text = "Text1"
        '
        '_Text1_23
        '
        Me._Text1_23.AcceptsReturn = True
        Me._Text1_23.AutoSize = False
        Me._Text1_23.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_23.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_23.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_23.Location = New System.Drawing.Point(272, 64)
        Me._Text1_23.MaxLength = 0
        Me._Text1_23.Name = "_Text1_23"
        Me._Text1_23.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_23.Size = New System.Drawing.Size(113, 25)
        Me._Text1_23.TabIndex = 82
        Me._Text1_23.Text = "Text1"
        '
        '_Text1_22
        '
        Me._Text1_22.AcceptsReturn = True
        Me._Text1_22.AutoSize = False
        Me._Text1_22.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_22.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_22.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_22.Location = New System.Drawing.Point(272, 32)
        Me._Text1_22.MaxLength = 0
        Me._Text1_22.Name = "_Text1_22"
        Me._Text1_22.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_22.Size = New System.Drawing.Size(113, 25)
        Me._Text1_22.TabIndex = 81
        Me._Text1_22.Text = "Text1"
        '
        '_Command1_1
        '
        Me._Command1_1.BackColor = System.Drawing.SystemColors.Control
        Me._Command1_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._Command1_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Command1_1.Location = New System.Drawing.Point(494, 427)
        Me._Command1_1.Name = "_Command1_1"
        Me._Command1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Command1_1.Size = New System.Drawing.Size(87, 25)
        Me._Command1_1.TabIndex = 67
        Me._Command1_1.Text = "Esci"
        '
        '_Command1_0
        '
        Me._Command1_0.BackColor = System.Drawing.SystemColors.Control
        Me._Command1_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Command1_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Command1_0.Location = New System.Drawing.Point(400, 427)
        Me._Command1_0.Name = "_Command1_0"
        Me._Command1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Command1_0.Size = New System.Drawing.Size(87, 25)
        Me._Command1_0.TabIndex = 66
        Me._Command1_0.Text = "Calcola"
        '
        '_Text1_21
        '
        Me._Text1_21.AcceptsReturn = True
        Me._Text1_21.AutoSize = False
        Me._Text1_21.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_21.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_21.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_21.Location = New System.Drawing.Point(344, 136)
        Me._Text1_21.MaxLength = 0
        Me._Text1_21.Name = "_Text1_21"
        Me._Text1_21.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_21.Size = New System.Drawing.Size(113, 25)
        Me._Text1_21.TabIndex = 43
        Me._Text1_21.Text = "Text1"
        '
        '_Text1_20
        '
        Me._Text1_20.AcceptsReturn = True
        Me._Text1_20.AutoSize = False
        Me._Text1_20.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_20.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_20.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_20.Location = New System.Drawing.Point(296, 128)
        Me._Text1_20.MaxLength = 0
        Me._Text1_20.Name = "_Text1_20"
        Me._Text1_20.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_20.Size = New System.Drawing.Size(113, 25)
        Me._Text1_20.TabIndex = 42
        Me._Text1_20.Text = "Text1"
        '
        '_Text1_19
        '
        Me._Text1_19.AcceptsReturn = True
        Me._Text1_19.AutoSize = False
        Me._Text1_19.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_19.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_19.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_19.Location = New System.Drawing.Point(272, 136)
        Me._Text1_19.MaxLength = 0
        Me._Text1_19.Name = "_Text1_19"
        Me._Text1_19.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_19.Size = New System.Drawing.Size(113, 25)
        Me._Text1_19.TabIndex = 41
        Me._Text1_19.Text = "Text1"
        '
        '_Text1_18
        '
        Me._Text1_18.AcceptsReturn = True
        Me._Text1_18.AutoSize = False
        Me._Text1_18.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_18.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_18.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_18.Location = New System.Drawing.Point(256, 144)
        Me._Text1_18.MaxLength = 0
        Me._Text1_18.Name = "_Text1_18"
        Me._Text1_18.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_18.Size = New System.Drawing.Size(113, 25)
        Me._Text1_18.TabIndex = 40
        Me._Text1_18.Text = "Text1"
        '
        '_Text1_17
        '
        Me._Text1_17.AcceptsReturn = True
        Me._Text1_17.AutoSize = False
        Me._Text1_17.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_17.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_17.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_17.Location = New System.Drawing.Point(288, 168)
        Me._Text1_17.MaxLength = 0
        Me._Text1_17.Name = "_Text1_17"
        Me._Text1_17.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_17.Size = New System.Drawing.Size(113, 25)
        Me._Text1_17.TabIndex = 39
        Me._Text1_17.Text = "Text1"
        '
        '_Text1_16
        '
        Me._Text1_16.AcceptsReturn = True
        Me._Text1_16.AutoSize = False
        Me._Text1_16.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_16.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_16.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_16.Location = New System.Drawing.Point(248, 144)
        Me._Text1_16.MaxLength = 0
        Me._Text1_16.Name = "_Text1_16"
        Me._Text1_16.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_16.Size = New System.Drawing.Size(113, 25)
        Me._Text1_16.TabIndex = 38
        Me._Text1_16.Text = "Text1"
        '
        '_Text1_15
        '
        Me._Text1_15.AcceptsReturn = True
        Me._Text1_15.AutoSize = False
        Me._Text1_15.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_15.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_15.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_15.Location = New System.Drawing.Point(272, 144)
        Me._Text1_15.MaxLength = 0
        Me._Text1_15.Name = "_Text1_15"
        Me._Text1_15.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_15.Size = New System.Drawing.Size(113, 25)
        Me._Text1_15.TabIndex = 37
        Me._Text1_15.Text = "Text1"
        '
        '_Text1_14
        '
        Me._Text1_14.AcceptsReturn = True
        Me._Text1_14.AutoSize = False
        Me._Text1_14.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_14.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_14.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_14.Location = New System.Drawing.Point(248, 136)
        Me._Text1_14.MaxLength = 0
        Me._Text1_14.Name = "_Text1_14"
        Me._Text1_14.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_14.Size = New System.Drawing.Size(113, 25)
        Me._Text1_14.TabIndex = 36
        Me._Text1_14.Text = "Text1"
        '
        '_Text1_13
        '
        Me._Text1_13.AcceptsReturn = True
        Me._Text1_13.AutoSize = False
        Me._Text1_13.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_13.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_13.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_13.Location = New System.Drawing.Point(264, 128)
        Me._Text1_13.MaxLength = 0
        Me._Text1_13.Name = "_Text1_13"
        Me._Text1_13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_13.Size = New System.Drawing.Size(113, 25)
        Me._Text1_13.TabIndex = 35
        Me._Text1_13.Text = "Text1"
        '
        '_Text1_12
        '
        Me._Text1_12.AcceptsReturn = True
        Me._Text1_12.AutoSize = False
        Me._Text1_12.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_12.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_12.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_12.Location = New System.Drawing.Point(288, 144)
        Me._Text1_12.MaxLength = 0
        Me._Text1_12.Name = "_Text1_12"
        Me._Text1_12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_12.Size = New System.Drawing.Size(113, 25)
        Me._Text1_12.TabIndex = 34
        Me._Text1_12.Text = "Text1"
        '
        '_Text1_11
        '
        Me._Text1_11.AcceptsReturn = True
        Me._Text1_11.AutoSize = False
        Me._Text1_11.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_11.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_11.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_11.Location = New System.Drawing.Point(304, 144)
        Me._Text1_11.MaxLength = 0
        Me._Text1_11.Name = "_Text1_11"
        Me._Text1_11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_11.Size = New System.Drawing.Size(113, 25)
        Me._Text1_11.TabIndex = 33
        Me._Text1_11.Text = "Text1"
        '
        '_Text1_10
        '
        Me._Text1_10.AcceptsReturn = True
        Me._Text1_10.AutoSize = False
        Me._Text1_10.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_10.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_10.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_10.Location = New System.Drawing.Point(256, 144)
        Me._Text1_10.MaxLength = 0
        Me._Text1_10.Name = "_Text1_10"
        Me._Text1_10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_10.Size = New System.Drawing.Size(113, 25)
        Me._Text1_10.TabIndex = 32
        Me._Text1_10.Text = "Text1"
        '
        '_Text1_9
        '
        Me._Text1_9.AcceptsReturn = True
        Me._Text1_9.AutoSize = False
        Me._Text1_9.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_9.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_9.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_9.Location = New System.Drawing.Point(264, 152)
        Me._Text1_9.MaxLength = 0
        Me._Text1_9.Name = "_Text1_9"
        Me._Text1_9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_9.Size = New System.Drawing.Size(113, 25)
        Me._Text1_9.TabIndex = 31
        Me._Text1_9.Text = "Text1"
        '
        '_Text1_8
        '
        Me._Text1_8.AcceptsReturn = True
        Me._Text1_8.AutoSize = False
        Me._Text1_8.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_8.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_8.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_8.Location = New System.Drawing.Point(304, 152)
        Me._Text1_8.MaxLength = 0
        Me._Text1_8.Name = "_Text1_8"
        Me._Text1_8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_8.Size = New System.Drawing.Size(113, 25)
        Me._Text1_8.TabIndex = 30
        Me._Text1_8.Text = "Text1"
        '
        '_Text1_7
        '
        Me._Text1_7.AcceptsReturn = True
        Me._Text1_7.AutoSize = False
        Me._Text1_7.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_7.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_7.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_7.Location = New System.Drawing.Point(304, 144)
        Me._Text1_7.MaxLength = 0
        Me._Text1_7.Name = "_Text1_7"
        Me._Text1_7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_7.Size = New System.Drawing.Size(113, 25)
        Me._Text1_7.TabIndex = 29
        Me._Text1_7.Text = "Text1"
        '
        '_Text1_6
        '
        Me._Text1_6.AcceptsReturn = True
        Me._Text1_6.AutoSize = False
        Me._Text1_6.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_6.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_6.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_6.Location = New System.Drawing.Point(240, 152)
        Me._Text1_6.MaxLength = 0
        Me._Text1_6.Name = "_Text1_6"
        Me._Text1_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_6.Size = New System.Drawing.Size(113, 25)
        Me._Text1_6.TabIndex = 28
        Me._Text1_6.Text = "Text1"
        '
        '_Text1_5
        '
        Me._Text1_5.AcceptsReturn = True
        Me._Text1_5.AutoSize = False
        Me._Text1_5.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_5.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_5.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_5.Location = New System.Drawing.Point(208, 152)
        Me._Text1_5.MaxLength = 0
        Me._Text1_5.Name = "_Text1_5"
        Me._Text1_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_5.Size = New System.Drawing.Size(113, 25)
        Me._Text1_5.TabIndex = 27
        Me._Text1_5.Text = "Text1"
        '
        '_Text1_4
        '
        Me._Text1_4.AcceptsReturn = True
        Me._Text1_4.AutoSize = False
        Me._Text1_4.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_4.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_4.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_4.Location = New System.Drawing.Point(280, 168)
        Me._Text1_4.MaxLength = 0
        Me._Text1_4.Name = "_Text1_4"
        Me._Text1_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_4.Size = New System.Drawing.Size(113, 25)
        Me._Text1_4.TabIndex = 26
        Me._Text1_4.Text = "Text1"
        '
        '_Text1_3
        '
        Me._Text1_3.AcceptsReturn = True
        Me._Text1_3.AutoSize = False
        Me._Text1_3.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_3.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_3.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_3.Location = New System.Drawing.Point(312, 184)
        Me._Text1_3.MaxLength = 0
        Me._Text1_3.Name = "_Text1_3"
        Me._Text1_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_3.Size = New System.Drawing.Size(113, 25)
        Me._Text1_3.TabIndex = 25
        Me._Text1_3.Text = "Text1"
        '
        '_Text1_2
        '
        Me._Text1_2.AcceptsReturn = True
        Me._Text1_2.AutoSize = False
        Me._Text1_2.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_2.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_2.Location = New System.Drawing.Point(272, 176)
        Me._Text1_2.MaxLength = 0
        Me._Text1_2.Name = "_Text1_2"
        Me._Text1_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_2.Size = New System.Drawing.Size(113, 25)
        Me._Text1_2.TabIndex = 24
        Me._Text1_2.Text = "Text1"
        '
        '_Text1_1
        '
        Me._Text1_1.AcceptsReturn = True
        Me._Text1_1.AutoSize = False
        Me._Text1_1.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_1.Location = New System.Drawing.Point(208, 256)
        Me._Text1_1.MaxLength = 0
        Me._Text1_1.Name = "_Text1_1"
        Me._Text1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_1.Size = New System.Drawing.Size(113, 25)
        Me._Text1_1.TabIndex = 23
        Me._Text1_1.Text = "Text1"
        '
        '_Text1_0
        '
        Me._Text1_0.AcceptsReturn = True
        Me._Text1_0.AutoSize = False
        Me._Text1_0.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_0.Location = New System.Drawing.Point(208, 224)
        Me._Text1_0.MaxLength = 0
        Me._Text1_0.Name = "_Text1_0"
        Me._Text1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_0.Size = New System.Drawing.Size(113, 25)
        Me._Text1_0.TabIndex = 22
        Me._Text1_0.Text = "Text1"
        '
        '_Label2_30
        '
        Me._Label2_30.BackColor = System.Drawing.SystemColors.Control
        Me._Label2_30.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._Label2_30.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_30.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label2_30.Location = New System.Drawing.Point(0, 0)
        Me._Label2_30.Name = "_Label2_30"
        Me._Label2_30.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_30.Size = New System.Drawing.Size(81, 33)
        Me._Label2_30.TabIndex = 104
        Me._Label2_30.Text = "Label2"
        '
        '_Label2_29
        '
        Me._Label2_29.BackColor = System.Drawing.SystemColors.Control
        Me._Label2_29.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._Label2_29.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_29.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label2_29.Location = New System.Drawing.Point(0, 0)
        Me._Label2_29.Name = "_Label2_29"
        Me._Label2_29.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_29.Size = New System.Drawing.Size(81, 33)
        Me._Label2_29.TabIndex = 103
        Me._Label2_29.Text = "Label2"
        '
        '_Label2_28
        '
        Me._Label2_28.BackColor = System.Drawing.SystemColors.Control
        Me._Label2_28.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._Label2_28.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_28.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label2_28.Location = New System.Drawing.Point(0, 0)
        Me._Label2_28.Name = "_Label2_28"
        Me._Label2_28.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_28.Size = New System.Drawing.Size(81, 33)
        Me._Label2_28.TabIndex = 102
        Me._Label2_28.Text = "Label2"
        '
        '_Label2_27
        '
        Me._Label2_27.BackColor = System.Drawing.SystemColors.Control
        Me._Label2_27.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._Label2_27.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_27.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label2_27.Location = New System.Drawing.Point(0, 0)
        Me._Label2_27.Name = "_Label2_27"
        Me._Label2_27.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_27.Size = New System.Drawing.Size(81, 33)
        Me._Label2_27.TabIndex = 101
        Me._Label2_27.Text = "Label2"
        '
        '_Label1_35
        '
        Me._Label1_35.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_35.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._Label1_35.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_35.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_35.Location = New System.Drawing.Point(0, 0)
        Me._Label1_35.Name = "_Label1_35"
        Me._Label1_35.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_35.Size = New System.Drawing.Size(153, 25)
        Me._Label1_35.TabIndex = 96
        Me._Label1_35.Text = "Label1"
        '
        '_Label1_34
        '
        Me._Label1_34.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_34.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._Label1_34.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_34.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_34.Location = New System.Drawing.Point(0, 0)
        Me._Label1_34.Name = "_Label1_34"
        Me._Label1_34.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_34.Size = New System.Drawing.Size(153, 25)
        Me._Label1_34.TabIndex = 95
        Me._Label1_34.Text = "Label1"
        '
        '_Label1_33
        '
        Me._Label1_33.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_33.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._Label1_33.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_33.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_33.Location = New System.Drawing.Point(0, 0)
        Me._Label1_33.Name = "_Label1_33"
        Me._Label1_33.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_33.Size = New System.Drawing.Size(153, 25)
        Me._Label1_33.TabIndex = 94
        Me._Label1_33.Text = "Label1"
        '
        '_Label1_32
        '
        Me._Label1_32.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_32.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._Label1_32.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_32.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_32.Location = New System.Drawing.Point(0, 0)
        Me._Label1_32.Name = "_Label1_32"
        Me._Label1_32.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_32.Size = New System.Drawing.Size(153, 25)
        Me._Label1_32.TabIndex = 93
        Me._Label1_32.Text = "Label1"
        '
        '_Label1_31
        '
        Me._Label1_31.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_31.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._Label1_31.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_31.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_31.Location = New System.Drawing.Point(224, 112)
        Me._Label1_31.Name = "_Label1_31"
        Me._Label1_31.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_31.Size = New System.Drawing.Size(153, 25)
        Me._Label1_31.TabIndex = 90
        Me._Label1_31.Text = "Label1"
        '
        '_Label1_30
        '
        Me._Label1_30.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_30.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._Label1_30.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_30.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_30.Location = New System.Drawing.Point(240, 176)
        Me._Label1_30.Name = "_Label1_30"
        Me._Label1_30.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_30.Size = New System.Drawing.Size(153, 25)
        Me._Label1_30.TabIndex = 89
        Me._Label1_30.Text = "Label1"
        '
        '_Label1_29
        '
        Me._Label1_29.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_29.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._Label1_29.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_29.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_29.Location = New System.Drawing.Point(240, 200)
        Me._Label1_29.Name = "_Label1_29"
        Me._Label1_29.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_29.Size = New System.Drawing.Size(153, 25)
        Me._Label1_29.TabIndex = 80
        Me._Label1_29.Text = "Label1"
        '
        '_Label2_26
        '
        Me._Label2_26.BackColor = System.Drawing.SystemColors.Control
        Me._Label2_26.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._Label2_26.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_26.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label2_26.Location = New System.Drawing.Point(384, 312)
        Me._Label2_26.Name = "_Label2_26"
        Me._Label2_26.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_26.Size = New System.Drawing.Size(81, 33)
        Me._Label2_26.TabIndex = 79
        Me._Label2_26.Text = "Label2"
        '
        '_Label2_25
        '
        Me._Label2_25.BackColor = System.Drawing.SystemColors.Control
        Me._Label2_25.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._Label2_25.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_25.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label2_25.Location = New System.Drawing.Point(288, 336)
        Me._Label2_25.Name = "_Label2_25"
        Me._Label2_25.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_25.Size = New System.Drawing.Size(81, 33)
        Me._Label2_25.TabIndex = 78
        Me._Label2_25.Text = "Label2"
        '
        '_Label2_24
        '
        Me._Label2_24.BackColor = System.Drawing.SystemColors.Control
        Me._Label2_24.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._Label2_24.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_24.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label2_24.Location = New System.Drawing.Point(240, 336)
        Me._Label2_24.Name = "_Label2_24"
        Me._Label2_24.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_24.Size = New System.Drawing.Size(81, 33)
        Me._Label2_24.TabIndex = 77
        Me._Label2_24.Text = "Label2"
        '
        '_Label2_23
        '
        Me._Label2_23.BackColor = System.Drawing.SystemColors.Control
        Me._Label2_23.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._Label2_23.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_23.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label2_23.Location = New System.Drawing.Point(232, 312)
        Me._Label2_23.Name = "_Label2_23"
        Me._Label2_23.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_23.Size = New System.Drawing.Size(81, 33)
        Me._Label2_23.TabIndex = 76
        Me._Label2_23.Text = "Label2"
        '
        '_Label2_22
        '
        Me._Label2_22.BackColor = System.Drawing.SystemColors.Control
        Me._Label2_22.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._Label2_22.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_22.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label2_22.Location = New System.Drawing.Point(224, 296)
        Me._Label2_22.Name = "_Label2_22"
        Me._Label2_22.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_22.Size = New System.Drawing.Size(81, 33)
        Me._Label2_22.TabIndex = 75
        Me._Label2_22.Text = "Label2"
        '
        '_Label1_28
        '
        Me._Label1_28.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_28.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._Label1_28.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_28.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_28.Location = New System.Drawing.Point(0, 0)
        Me._Label1_28.Name = "_Label1_28"
        Me._Label1_28.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_28.Size = New System.Drawing.Size(153, 25)
        Me._Label1_28.TabIndex = 74
        Me._Label1_28.Text = "Label1"
        '
        '_Label1_27
        '
        Me._Label1_27.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_27.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._Label1_27.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_27.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_27.Location = New System.Drawing.Point(0, 0)
        Me._Label1_27.Name = "_Label1_27"
        Me._Label1_27.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_27.Size = New System.Drawing.Size(153, 25)
        Me._Label1_27.TabIndex = 73
        Me._Label1_27.Text = "Label1"
        '
        '_Label1_26
        '
        Me._Label1_26.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_26.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._Label1_26.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_26.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_26.Location = New System.Drawing.Point(0, 0)
        Me._Label1_26.Name = "_Label1_26"
        Me._Label1_26.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_26.Size = New System.Drawing.Size(153, 25)
        Me._Label1_26.TabIndex = 72
        Me._Label1_26.Text = "Label1"
        '
        '_Label1_25
        '
        Me._Label1_25.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_25.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._Label1_25.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_25.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_25.Location = New System.Drawing.Point(0, 0)
        Me._Label1_25.Name = "_Label1_25"
        Me._Label1_25.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_25.Size = New System.Drawing.Size(153, 25)
        Me._Label1_25.TabIndex = 71
        Me._Label1_25.Text = "Label1"
        '
        '_Label1_24
        '
        Me._Label1_24.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_24.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._Label1_24.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_24.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_24.Location = New System.Drawing.Point(0, 0)
        Me._Label1_24.Name = "_Label1_24"
        Me._Label1_24.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_24.Size = New System.Drawing.Size(153, 25)
        Me._Label1_24.TabIndex = 70
        Me._Label1_24.Text = "Label1"
        '
        '_Label1_23
        '
        Me._Label1_23.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_23.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._Label1_23.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_23.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_23.Location = New System.Drawing.Point(0, 0)
        Me._Label1_23.Name = "_Label1_23"
        Me._Label1_23.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_23.Size = New System.Drawing.Size(153, 25)
        Me._Label1_23.TabIndex = 69
        Me._Label1_23.Text = "Label1"
        '
        '_Label1_22
        '
        Me._Label1_22.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_22.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._Label1_22.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_22.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_22.Location = New System.Drawing.Point(0, 0)
        Me._Label1_22.Name = "_Label1_22"
        Me._Label1_22.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_22.Size = New System.Drawing.Size(153, 25)
        Me._Label1_22.TabIndex = 68
        Me._Label1_22.Text = "Label1"
        '
        '_Label2_21
        '
        Me._Label2_21.BackColor = System.Drawing.SystemColors.Control
        Me._Label2_21.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._Label2_21.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_21.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label2_21.Location = New System.Drawing.Point(120, 112)
        Me._Label2_21.Name = "_Label2_21"
        Me._Label2_21.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_21.Size = New System.Drawing.Size(81, 33)
        Me._Label2_21.TabIndex = 65
        Me._Label2_21.Text = "Label2"
        '
        '_Label2_20
        '
        Me._Label2_20.BackColor = System.Drawing.SystemColors.Control
        Me._Label2_20.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._Label2_20.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_20.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label2_20.Location = New System.Drawing.Point(112, 136)
        Me._Label2_20.Name = "_Label2_20"
        Me._Label2_20.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_20.Size = New System.Drawing.Size(81, 33)
        Me._Label2_20.TabIndex = 64
        Me._Label2_20.Text = "Label2"
        '
        '_Label2_19
        '
        Me._Label2_19.BackColor = System.Drawing.SystemColors.Control
        Me._Label2_19.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._Label2_19.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_19.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label2_19.Location = New System.Drawing.Point(0, 0)
        Me._Label2_19.Name = "_Label2_19"
        Me._Label2_19.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_19.Size = New System.Drawing.Size(81, 33)
        Me._Label2_19.TabIndex = 63
        Me._Label2_19.Text = "Label2"
        '
        '_Label2_18
        '
        Me._Label2_18.BackColor = System.Drawing.SystemColors.Control
        Me._Label2_18.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._Label2_18.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_18.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label2_18.Location = New System.Drawing.Point(0, 0)
        Me._Label2_18.Name = "_Label2_18"
        Me._Label2_18.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_18.Size = New System.Drawing.Size(81, 33)
        Me._Label2_18.TabIndex = 62
        Me._Label2_18.Text = "Label2"
        '
        '_Label2_17
        '
        Me._Label2_17.BackColor = System.Drawing.SystemColors.Control
        Me._Label2_17.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._Label2_17.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_17.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label2_17.Location = New System.Drawing.Point(0, 0)
        Me._Label2_17.Name = "_Label2_17"
        Me._Label2_17.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_17.Size = New System.Drawing.Size(81, 33)
        Me._Label2_17.TabIndex = 61
        Me._Label2_17.Text = "Label2"
        '
        '_Label2_16
        '
        Me._Label2_16.BackColor = System.Drawing.SystemColors.Control
        Me._Label2_16.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._Label2_16.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_16.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label2_16.Location = New System.Drawing.Point(0, 0)
        Me._Label2_16.Name = "_Label2_16"
        Me._Label2_16.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_16.Size = New System.Drawing.Size(81, 33)
        Me._Label2_16.TabIndex = 60
        Me._Label2_16.Text = "Label2"
        '
        '_Label2_15
        '
        Me._Label2_15.BackColor = System.Drawing.SystemColors.Control
        Me._Label2_15.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._Label2_15.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_15.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label2_15.Location = New System.Drawing.Point(0, 0)
        Me._Label2_15.Name = "_Label2_15"
        Me._Label2_15.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_15.Size = New System.Drawing.Size(81, 33)
        Me._Label2_15.TabIndex = 59
        Me._Label2_15.Text = "Label2"
        '
        '_Label2_14
        '
        Me._Label2_14.BackColor = System.Drawing.SystemColors.Control
        Me._Label2_14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._Label2_14.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_14.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label2_14.Location = New System.Drawing.Point(0, 0)
        Me._Label2_14.Name = "_Label2_14"
        Me._Label2_14.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_14.Size = New System.Drawing.Size(81, 33)
        Me._Label2_14.TabIndex = 58
        Me._Label2_14.Text = "Label2"
        '
        '_Label2_13
        '
        Me._Label2_13.BackColor = System.Drawing.SystemColors.Control
        Me._Label2_13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._Label2_13.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_13.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label2_13.Location = New System.Drawing.Point(0, 0)
        Me._Label2_13.Name = "_Label2_13"
        Me._Label2_13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_13.Size = New System.Drawing.Size(81, 33)
        Me._Label2_13.TabIndex = 57
        Me._Label2_13.Text = "Label2"
        '
        '_Label2_12
        '
        Me._Label2_12.BackColor = System.Drawing.SystemColors.Control
        Me._Label2_12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._Label2_12.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_12.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label2_12.Location = New System.Drawing.Point(0, 0)
        Me._Label2_12.Name = "_Label2_12"
        Me._Label2_12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_12.Size = New System.Drawing.Size(81, 33)
        Me._Label2_12.TabIndex = 56
        Me._Label2_12.Text = "Label2"
        '
        '_Label2_11
        '
        Me._Label2_11.BackColor = System.Drawing.SystemColors.Control
        Me._Label2_11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._Label2_11.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_11.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label2_11.Location = New System.Drawing.Point(0, 0)
        Me._Label2_11.Name = "_Label2_11"
        Me._Label2_11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_11.Size = New System.Drawing.Size(81, 33)
        Me._Label2_11.TabIndex = 55
        Me._Label2_11.Text = "Label2"
        '
        '_Label2_10
        '
        Me._Label2_10.BackColor = System.Drawing.SystemColors.Control
        Me._Label2_10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._Label2_10.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_10.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label2_10.Location = New System.Drawing.Point(0, 0)
        Me._Label2_10.Name = "_Label2_10"
        Me._Label2_10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_10.Size = New System.Drawing.Size(81, 33)
        Me._Label2_10.TabIndex = 54
        Me._Label2_10.Text = "Label2"
        '
        '_Label2_9
        '
        Me._Label2_9.BackColor = System.Drawing.SystemColors.Control
        Me._Label2_9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._Label2_9.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_9.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label2_9.Location = New System.Drawing.Point(0, 0)
        Me._Label2_9.Name = "_Label2_9"
        Me._Label2_9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_9.Size = New System.Drawing.Size(81, 33)
        Me._Label2_9.TabIndex = 53
        Me._Label2_9.Text = "Label2"
        '
        '_Label2_8
        '
        Me._Label2_8.BackColor = System.Drawing.SystemColors.Control
        Me._Label2_8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._Label2_8.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_8.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label2_8.Location = New System.Drawing.Point(0, 0)
        Me._Label2_8.Name = "_Label2_8"
        Me._Label2_8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_8.Size = New System.Drawing.Size(81, 33)
        Me._Label2_8.TabIndex = 52
        Me._Label2_8.Text = "Label2"
        '
        '_Label2_7
        '
        Me._Label2_7.BackColor = System.Drawing.SystemColors.Control
        Me._Label2_7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._Label2_7.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_7.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label2_7.Location = New System.Drawing.Point(0, 0)
        Me._Label2_7.Name = "_Label2_7"
        Me._Label2_7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_7.Size = New System.Drawing.Size(81, 33)
        Me._Label2_7.TabIndex = 51
        Me._Label2_7.Text = "Label2"
        '
        '_Label2_6
        '
        Me._Label2_6.BackColor = System.Drawing.SystemColors.Control
        Me._Label2_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._Label2_6.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_6.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label2_6.Location = New System.Drawing.Point(0, 0)
        Me._Label2_6.Name = "_Label2_6"
        Me._Label2_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_6.Size = New System.Drawing.Size(81, 33)
        Me._Label2_6.TabIndex = 50
        Me._Label2_6.Text = "Label2"
        '
        '_Label2_5
        '
        Me._Label2_5.BackColor = System.Drawing.SystemColors.Control
        Me._Label2_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._Label2_5.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_5.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label2_5.Location = New System.Drawing.Point(0, 0)
        Me._Label2_5.Name = "_Label2_5"
        Me._Label2_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_5.Size = New System.Drawing.Size(81, 33)
        Me._Label2_5.TabIndex = 49
        Me._Label2_5.Text = "Label2"
        '
        '_Label2_4
        '
        Me._Label2_4.BackColor = System.Drawing.SystemColors.Control
        Me._Label2_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._Label2_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label2_4.Location = New System.Drawing.Point(0, 0)
        Me._Label2_4.Name = "_Label2_4"
        Me._Label2_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_4.Size = New System.Drawing.Size(81, 33)
        Me._Label2_4.TabIndex = 48
        Me._Label2_4.Text = "Label2"
        '
        '_Label2_3
        '
        Me._Label2_3.BackColor = System.Drawing.SystemColors.Control
        Me._Label2_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._Label2_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label2_3.Location = New System.Drawing.Point(0, 0)
        Me._Label2_3.Name = "_Label2_3"
        Me._Label2_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_3.Size = New System.Drawing.Size(81, 33)
        Me._Label2_3.TabIndex = 47
        Me._Label2_3.Text = "Label2"
        '
        '_Label2_2
        '
        Me._Label2_2.BackColor = System.Drawing.SystemColors.Control
        Me._Label2_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._Label2_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label2_2.Location = New System.Drawing.Point(0, 0)
        Me._Label2_2.Name = "_Label2_2"
        Me._Label2_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_2.Size = New System.Drawing.Size(81, 33)
        Me._Label2_2.TabIndex = 46
        Me._Label2_2.Text = "Label2"
        '
        '_Label2_1
        '
        Me._Label2_1.BackColor = System.Drawing.SystemColors.Control
        Me._Label2_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._Label2_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label2_1.Location = New System.Drawing.Point(0, 0)
        Me._Label2_1.Name = "_Label2_1"
        Me._Label2_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_1.Size = New System.Drawing.Size(81, 33)
        Me._Label2_1.TabIndex = 45
        Me._Label2_1.Text = "Label2"
        '
        '_Label2_0
        '
        Me._Label2_0.BackColor = System.Drawing.SystemColors.Control
        Me._Label2_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._Label2_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label2_0.Location = New System.Drawing.Point(240, 288)
        Me._Label2_0.Name = "_Label2_0"
        Me._Label2_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_0.Size = New System.Drawing.Size(81, 33)
        Me._Label2_0.TabIndex = 44
        Me._Label2_0.Text = "Label2"
        '
        '_Label1_21
        '
        Me._Label1_21.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_21.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._Label1_21.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_21.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_21.Location = New System.Drawing.Point(0, 0)
        Me._Label1_21.Name = "_Label1_21"
        Me._Label1_21.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_21.Size = New System.Drawing.Size(153, 25)
        Me._Label1_21.TabIndex = 21
        Me._Label1_21.Text = "Label1"
        '
        '_Label1_20
        '
        Me._Label1_20.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_20.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._Label1_20.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_20.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_20.Location = New System.Drawing.Point(0, 0)
        Me._Label1_20.Name = "_Label1_20"
        Me._Label1_20.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_20.Size = New System.Drawing.Size(153, 25)
        Me._Label1_20.TabIndex = 20
        Me._Label1_20.Text = "Label1"
        '
        '_Label1_19
        '
        Me._Label1_19.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_19.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._Label1_19.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_19.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_19.Location = New System.Drawing.Point(0, 0)
        Me._Label1_19.Name = "_Label1_19"
        Me._Label1_19.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_19.Size = New System.Drawing.Size(153, 25)
        Me._Label1_19.TabIndex = 19
        Me._Label1_19.Text = "Label1"
        '
        '_Label1_18
        '
        Me._Label1_18.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_18.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._Label1_18.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_18.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_18.Location = New System.Drawing.Point(0, 0)
        Me._Label1_18.Name = "_Label1_18"
        Me._Label1_18.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_18.Size = New System.Drawing.Size(153, 25)
        Me._Label1_18.TabIndex = 18
        Me._Label1_18.Text = "Label1"
        '
        '_Label1_17
        '
        Me._Label1_17.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_17.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._Label1_17.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_17.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_17.Location = New System.Drawing.Point(0, 0)
        Me._Label1_17.Name = "_Label1_17"
        Me._Label1_17.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_17.Size = New System.Drawing.Size(153, 25)
        Me._Label1_17.TabIndex = 17
        Me._Label1_17.Text = "Label1"
        '
        '_Label1_16
        '
        Me._Label1_16.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_16.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._Label1_16.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_16.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_16.Location = New System.Drawing.Point(0, 0)
        Me._Label1_16.Name = "_Label1_16"
        Me._Label1_16.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_16.Size = New System.Drawing.Size(153, 25)
        Me._Label1_16.TabIndex = 16
        Me._Label1_16.Text = "Label1"
        '
        '_Label1_15
        '
        Me._Label1_15.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_15.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._Label1_15.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_15.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_15.Location = New System.Drawing.Point(0, 0)
        Me._Label1_15.Name = "_Label1_15"
        Me._Label1_15.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_15.Size = New System.Drawing.Size(153, 25)
        Me._Label1_15.TabIndex = 15
        Me._Label1_15.Text = "Label1"
        '
        '_Label1_14
        '
        Me._Label1_14.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._Label1_14.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_14.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_14.Location = New System.Drawing.Point(0, 0)
        Me._Label1_14.Name = "_Label1_14"
        Me._Label1_14.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_14.Size = New System.Drawing.Size(153, 25)
        Me._Label1_14.TabIndex = 14
        Me._Label1_14.Text = "Label1"
        '
        '_Label1_13
        '
        Me._Label1_13.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._Label1_13.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_13.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_13.Location = New System.Drawing.Point(216, 184)
        Me._Label1_13.Name = "_Label1_13"
        Me._Label1_13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_13.Size = New System.Drawing.Size(153, 25)
        Me._Label1_13.TabIndex = 13
        Me._Label1_13.Text = "Label1"
        '
        '_Label1_12
        '
        Me._Label1_12.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._Label1_12.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_12.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_12.Location = New System.Drawing.Point(208, 144)
        Me._Label1_12.Name = "_Label1_12"
        Me._Label1_12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_12.Size = New System.Drawing.Size(153, 25)
        Me._Label1_12.TabIndex = 12
        Me._Label1_12.Text = "Label1"
        '
        '_Label1_11
        '
        Me._Label1_11.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._Label1_11.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_11.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_11.Location = New System.Drawing.Point(216, 120)
        Me._Label1_11.Name = "_Label1_11"
        Me._Label1_11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_11.Size = New System.Drawing.Size(153, 25)
        Me._Label1_11.TabIndex = 11
        Me._Label1_11.Text = "Label1"
        '
        '_Label1_10
        '
        Me._Label1_10.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._Label1_10.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_10.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_10.Location = New System.Drawing.Point(208, 80)
        Me._Label1_10.Name = "_Label1_10"
        Me._Label1_10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_10.Size = New System.Drawing.Size(153, 25)
        Me._Label1_10.TabIndex = 10
        Me._Label1_10.Text = "Label1"
        '
        '_Label1_9
        '
        Me._Label1_9.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._Label1_9.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_9.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_9.Location = New System.Drawing.Point(16, 0)
        Me._Label1_9.Name = "_Label1_9"
        Me._Label1_9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_9.Size = New System.Drawing.Size(153, 25)
        Me._Label1_9.TabIndex = 9
        Me._Label1_9.Text = "Label1"
        '
        '_Label1_8
        '
        Me._Label1_8.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._Label1_8.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_8.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_8.Location = New System.Drawing.Point(32, 312)
        Me._Label1_8.Name = "_Label1_8"
        Me._Label1_8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_8.Size = New System.Drawing.Size(153, 25)
        Me._Label1_8.TabIndex = 8
        Me._Label1_8.Text = "Label1"
        '
        '_Label1_7
        '
        Me._Label1_7.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._Label1_7.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_7.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_7.Location = New System.Drawing.Point(8, 272)
        Me._Label1_7.Name = "_Label1_7"
        Me._Label1_7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_7.Size = New System.Drawing.Size(34, 15)
        Me._Label1_7.TabIndex = 7
        Me._Label1_7.Text = "Label1"
        '
        '_Label1_6
        '
        Me._Label1_6.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._Label1_6.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_6.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_6.Location = New System.Drawing.Point(16, 216)
        Me._Label1_6.Name = "_Label1_6"
        Me._Label1_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_6.Size = New System.Drawing.Size(153, 25)
        Me._Label1_6.TabIndex = 6
        Me._Label1_6.Text = "Label1"
        '
        '_Label1_5
        '
        Me._Label1_5.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._Label1_5.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_5.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_5.Location = New System.Drawing.Point(24, 184)
        Me._Label1_5.Name = "_Label1_5"
        Me._Label1_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_5.Size = New System.Drawing.Size(153, 25)
        Me._Label1_5.TabIndex = 5
        Me._Label1_5.Text = "Label1"
        '
        '_Label1_4
        '
        Me._Label1_4.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._Label1_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_4.Location = New System.Drawing.Point(24, 136)
        Me._Label1_4.Name = "_Label1_4"
        Me._Label1_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_4.Size = New System.Drawing.Size(153, 25)
        Me._Label1_4.TabIndex = 4
        Me._Label1_4.Text = "Label1"
        '
        '_Label1_3
        '
        Me._Label1_3.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._Label1_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_3.Location = New System.Drawing.Point(0, 112)
        Me._Label1_3.Name = "_Label1_3"
        Me._Label1_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_3.Size = New System.Drawing.Size(153, 25)
        Me._Label1_3.TabIndex = 3
        Me._Label1_3.Text = "Label1"
        '
        '_Label1_2
        '
        Me._Label1_2.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._Label1_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_2.Location = New System.Drawing.Point(8, 80)
        Me._Label1_2.Name = "_Label1_2"
        Me._Label1_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_2.Size = New System.Drawing.Size(153, 25)
        Me._Label1_2.TabIndex = 2
        Me._Label1_2.Text = "Label1"
        '
        '_Label1_1
        '
        Me._Label1_1.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._Label1_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_1.Location = New System.Drawing.Point(8, 40)
        Me._Label1_1.Name = "_Label1_1"
        Me._Label1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_1.Size = New System.Drawing.Size(153, 25)
        Me._Label1_1.TabIndex = 1
        Me._Label1_1.Text = "Label1"
        '
        '_Label1_0
        '
        Me._Label1_0.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._Label1_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_0.Location = New System.Drawing.Point(24, 360)
        Me._Label1_0.Name = "_Label1_0"
        Me._Label1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_0.Size = New System.Drawing.Size(153, 25)
        Me._Label1_0.TabIndex = 0
        Me._Label1_0.Text = "Label1"
        '
        'chkAgganciatoD
        '
        Me.chkAgganciatoD.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkAgganciatoD.ForeColor = System.Drawing.SystemColors.ControlText
        Me.HelpProvider1.SetHelpKeyword(Me.chkAgganciatoD, "Tipi.htm#Materiale")
        Me.HelpProvider1.SetHelpNavigator(Me.chkAgganciatoD, System.Windows.Forms.HelpNavigator.Topic)
        Me.chkAgganciatoD.Location = New System.Drawing.Point(528, 8)
        Me.chkAgganciatoD.Name = "chkAgganciatoD"
        Me.HelpProvider1.SetShowHelp(Me.chkAgganciatoD, True)
        Me.chkAgganciatoD.Size = New System.Drawing.Size(56, 24)
        Me.chkAgganciatoD.TabIndex = 342
        Me.chkAgganciatoD.Text = "bound"
        Me.ToolTip1.SetToolTip(Me.chkAgganciatoD, "determina se il materiale è agganciato alla libreria o se è definito localmente")
        '
        'chkAgganciatoB
        '
        Me.chkAgganciatoB.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkAgganciatoB.ForeColor = System.Drawing.SystemColors.ControlText
        Me.HelpProvider1.SetHelpKeyword(Me.chkAgganciatoB, "Tipi.htm#Materiale")
        Me.HelpProvider1.SetHelpNavigator(Me.chkAgganciatoB, System.Windows.Forms.HelpNavigator.Topic)
        Me.chkAgganciatoB.Location = New System.Drawing.Point(528, 40)
        Me.chkAgganciatoB.Name = "chkAgganciatoB"
        Me.HelpProvider1.SetShowHelp(Me.chkAgganciatoB, True)
        Me.chkAgganciatoB.Size = New System.Drawing.Size(56, 24)
        Me.chkAgganciatoB.TabIndex = 343
        Me.chkAgganciatoB.Text = "bound"
        Me.ToolTip1.SetToolTip(Me.chkAgganciatoB, "determina se il materiale è agganciato alla libreria o se è definito localmente")
        '
        'chkAgganciatoC
        '
        Me.chkAgganciatoC.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkAgganciatoC.ForeColor = System.Drawing.SystemColors.ControlText
        Me.HelpProvider1.SetHelpKeyword(Me.chkAgganciatoC, "Tipi.htm#Materiale")
        Me.HelpProvider1.SetHelpNavigator(Me.chkAgganciatoC, System.Windows.Forms.HelpNavigator.Topic)
        Me.chkAgganciatoC.Location = New System.Drawing.Point(528, 72)
        Me.chkAgganciatoC.Name = "chkAgganciatoC"
        Me.HelpProvider1.SetShowHelp(Me.chkAgganciatoC, True)
        Me.chkAgganciatoC.Size = New System.Drawing.Size(56, 24)
        Me.chkAgganciatoC.TabIndex = 344
        Me.chkAgganciatoC.Text = "bound"
        Me.ToolTip1.SetToolTip(Me.chkAgganciatoC, "determina se il materiale è agganciato alla libreria o se è definito localmente")
        '
        'chkAgganciatoF
        '
        Me.chkAgganciatoF.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkAgganciatoF.ForeColor = System.Drawing.SystemColors.ControlText
        Me.HelpProvider1.SetHelpKeyword(Me.chkAgganciatoF, "Tipi.htm#Materiale")
        Me.HelpProvider1.SetHelpNavigator(Me.chkAgganciatoF, System.Windows.Forms.HelpNavigator.Topic)
        Me.chkAgganciatoF.Location = New System.Drawing.Point(536, 104)
        Me.chkAgganciatoF.Name = "chkAgganciatoF"
        Me.HelpProvider1.SetShowHelp(Me.chkAgganciatoF, True)
        Me.chkAgganciatoF.Size = New System.Drawing.Size(56, 24)
        Me.chkAgganciatoF.TabIndex = 345
        Me.chkAgganciatoF.Text = "bound"
        Me.ToolTip1.SetToolTip(Me.chkAgganciatoF, "determina se il materiale è agganciato alla libreria o se è definito localmente")
        '
        'chkAgganciatoW
        '
        Me.chkAgganciatoW.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkAgganciatoW.ForeColor = System.Drawing.SystemColors.ControlText
        Me.HelpProvider1.SetHelpKeyword(Me.chkAgganciatoW, "Tipi.htm#Materiale")
        Me.HelpProvider1.SetHelpNavigator(Me.chkAgganciatoW, System.Windows.Forms.HelpNavigator.Topic)
        Me.chkAgganciatoW.Location = New System.Drawing.Point(528, 144)
        Me.chkAgganciatoW.Name = "chkAgganciatoW"
        Me.HelpProvider1.SetShowHelp(Me.chkAgganciatoW, True)
        Me.chkAgganciatoW.Size = New System.Drawing.Size(56, 24)
        Me.chkAgganciatoW.TabIndex = 346
        Me.chkAgganciatoW.Text = "bound"
        Me.ToolTip1.SetToolTip(Me.chkAgganciatoW, "determina se il materiale è agganciato alla libreria o se è definito localmente")
        '
        'frmDiaf
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(599, 466)
        Me.Controls.Add(Me.chkAgganciatoW)
        Me.Controls.Add(Me.chkAgganciatoF)
        Me.Controls.Add(Me.chkAgganciatoC)
        Me.Controls.Add(Me.chkAgganciatoB)
        Me.Controls.Add(Me.chkAgganciatoD)
        Me.Controls.Add(Me._Command1_2)
        Me.Controls.Add(Me._cmdCil_0)
        Me.Controls.Add(Me._Text1_35)
        Me.Controls.Add(Me._Text1_34)
        Me.Controls.Add(Me._Text1_33)
        Me.Controls.Add(Me._Text1_32)
        Me.Controls.Add(Me._Text1_31)
        Me.Controls.Add(Me._Text1_30)
        Me.Controls.Add(Me._Text1_29)
        Me.Controls.Add(Me._Text1_28)
        Me.Controls.Add(Me._Text1_27)
        Me.Controls.Add(Me._Text1_26)
        Me.Controls.Add(Me._Text1_25)
        Me.Controls.Add(Me._Text1_24)
        Me.Controls.Add(Me._Text1_23)
        Me.Controls.Add(Me._Text1_22)
        Me.Controls.Add(Me._Command1_1)
        Me.Controls.Add(Me._Command1_0)
        Me.Controls.Add(Me._Text1_21)
        Me.Controls.Add(Me._Text1_20)
        Me.Controls.Add(Me._Text1_19)
        Me.Controls.Add(Me._Text1_18)
        Me.Controls.Add(Me._Text1_17)
        Me.Controls.Add(Me._Text1_16)
        Me.Controls.Add(Me._Text1_15)
        Me.Controls.Add(Me._Text1_14)
        Me.Controls.Add(Me._Text1_13)
        Me.Controls.Add(Me._Text1_12)
        Me.Controls.Add(Me._Text1_11)
        Me.Controls.Add(Me._Text1_10)
        Me.Controls.Add(Me._Text1_9)
        Me.Controls.Add(Me._Text1_8)
        Me.Controls.Add(Me._Text1_7)
        Me.Controls.Add(Me._Text1_6)
        Me.Controls.Add(Me._Text1_5)
        Me.Controls.Add(Me._Text1_4)
        Me.Controls.Add(Me._Text1_3)
        Me.Controls.Add(Me._Text1_2)
        Me.Controls.Add(Me._Text1_1)
        Me.Controls.Add(Me._Text1_0)
        Me.Controls.Add(Me._Label2_30)
        Me.Controls.Add(Me._Label2_29)
        Me.Controls.Add(Me._Label2_28)
        Me.Controls.Add(Me._Label2_27)
        Me.Controls.Add(Me._Label1_35)
        Me.Controls.Add(Me._Label1_34)
        Me.Controls.Add(Me._Label1_33)
        Me.Controls.Add(Me._Label1_32)
        Me.Controls.Add(Me._Label1_31)
        Me.Controls.Add(Me._Label1_30)
        Me.Controls.Add(Me._Label1_29)
        Me.Controls.Add(Me._Label2_26)
        Me.Controls.Add(Me._Label2_25)
        Me.Controls.Add(Me._Label2_24)
        Me.Controls.Add(Me._Label2_23)
        Me.Controls.Add(Me._Label2_22)
        Me.Controls.Add(Me._Label1_28)
        Me.Controls.Add(Me._Label1_27)
        Me.Controls.Add(Me._Label1_26)
        Me.Controls.Add(Me._Label1_25)
        Me.Controls.Add(Me._Label1_24)
        Me.Controls.Add(Me._Label1_23)
        Me.Controls.Add(Me._Label1_22)
        Me.Controls.Add(Me._Label2_21)
        Me.Controls.Add(Me._Label2_20)
        Me.Controls.Add(Me._Label2_19)
        Me.Controls.Add(Me._Label2_18)
        Me.Controls.Add(Me._Label2_17)
        Me.Controls.Add(Me._Label2_16)
        Me.Controls.Add(Me._Label2_15)
        Me.Controls.Add(Me._Label2_14)
        Me.Controls.Add(Me._Label2_13)
        Me.Controls.Add(Me._Label2_12)
        Me.Controls.Add(Me._Label2_11)
        Me.Controls.Add(Me._Label2_10)
        Me.Controls.Add(Me._Label2_9)
        Me.Controls.Add(Me._Label2_8)
        Me.Controls.Add(Me._Label2_7)
        Me.Controls.Add(Me._Label2_6)
        Me.Controls.Add(Me._Label2_5)
        Me.Controls.Add(Me._Label2_4)
        Me.Controls.Add(Me._Label2_3)
        Me.Controls.Add(Me._Label2_2)
        Me.Controls.Add(Me._Label2_1)
        Me.Controls.Add(Me._Label2_0)
        Me.Controls.Add(Me._Label1_21)
        Me.Controls.Add(Me._Label1_20)
        Me.Controls.Add(Me._Label1_19)
        Me.Controls.Add(Me._Label1_18)
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
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.HelpButton = True
        Me.Location = New System.Drawing.Point(218, 100)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDiaf"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Dati diaframma elastico"
        Me.ResumeLayout(False)

    End Sub
#End Region
    Private Clickato As Boolean
    Public objDiaf As wn_Diaf
    Private ReadOnly Property Command1(ByVal i As Short) As Button
        Get
            Select Case i
                Case 0 : Return _Command1_0
                Case 1 : Return _Command1_1
                Case 3 : Return _Command1_2
                Case Else : Return Nothing
            End Select
        End Get
    End Property
    Public Sub Button_Click(ByVal Nome As String)
        Dim s() As String = Nome.Split(CChar("_"))
        Dim Textnum As String = s(1)
        Dim Index As Short = CShort(s(2))
        Recupera()
        With objDiaf
            Select Case Index
                Case 3 'materiale cassa/flangia
                    .SceltaFlange()
                Case 6 'materiale cover
                    .SceltaCover()
                Case 9 ''bolt
                    .SceltaBolt()
                Case 14 'diaf
                    .SceltaDiaf()
                Case 19 'materiale saldatura
                    .SceltaWeld()
            End Select
        End With
        Aggiorna()
    End Sub
    Private ReadOnly Property Label1(ByVal i As Short) As Label
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
                Case 27 : Return _Label1_27
                Case 28 : Return _Label1_28
                Case 29 : Return _Label1_29
                Case 30 : Return _Label1_30
                Case 31 : Return _Label1_31
                Case 32 : Return _Label1_32
                Case 33 : Return _Label1_33
                Case 34 : Return _Label1_34
                Case 35 : Return _Label1_35
                Case Else : Return Nothing
            End Select
        End Get
    End Property
    Private ReadOnly Property Text1(ByVal i As Short) As TextBox
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
                Case 13 : Return _Text1_13
                Case 14 : Return _Text1_14
                Case 15 : Return _Text1_15
                Case 16 : Return _Text1_16
                Case 17 : Return _Text1_17
                Case 18 : Return _Text1_18
                Case 19 : Return _Text1_19
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
                Case 33 : Return _Text1_33
                Case 34 : Return _Text1_34
                Case 35 : Return _Text1_35
                Case Else : Return Nothing
            End Select
        End Get
    End Property
    Private ReadOnly Property Label2(ByVal i As Short) As Label
        Get
            Select Case i
                Case 0 : Return _Label2_0
                Case 1 : Return _Label2_1
                Case 2 : Return _Label2_2
                Case 3 : Return _Label2_3
                Case 4 : Return _Label2_4
                Case 5 : Return _Label2_5
                Case 6 : Return _Label2_6
                Case 7 : Return _Label2_7
                Case 8 : Return _Label2_8
                Case 9 : Return _Label2_9
                Case 10 : Return _Label2_10
                Case 11 : Return _Label2_11
                Case 12 : Return _Label2_12
                Case 13 : Return _Label2_13
                Case 14 : Return _Label2_14
                Case 15 : Return _Label2_15
                Case 16 : Return _Label2_16
                Case 17 : Return _Label2_17
                Case 18 : Return _Label2_18
                Case 19 : Return _Label2_19
                Case 20 : Return _Label2_20
                Case 21 : Return _Label2_21
                Case 22 : Return _Label2_22
                Case 23 : Return _Label2_23
                Case 24 : Return _Label2_24
                Case 25 : Return _Label2_25
                Case 26 : Return _Label2_26
                Case 27 : Return _Label2_27
                Case 28 : Return _Label2_28
                Case 29 : Return _Label2_29
                Case 30 : Return _Label2_30
                Case Else : Return Nothing
            End Select
        End Get
    End Property
    Private Sub Command1_Click(ByVal Index As Short)
        Dim Testo As String = ""
        With objDiaf
            Select Case Index
                Case 0 'Calcola
                    If Not Clickato Then
                        Testo = "Non hai richiesto il riversamento dei risultati" & vbCrLf
                        Testo = Testo & "del calcolo del coperchio." & vbCrLf
                        Testo = Testo & "Vuoi farlo ora?"
                        If MessageBox.Show(Testo, "AsmeVip", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then Call Clicka()
                    End If
                    Recupera()
                    .Calcolo()
                    .Stampa()
                Case 1 'OK
                    Recupera()
                    Hide()
                    Dispose()
                Case 2
                    Call Clicka()
            End Select
        End With
    End Sub
    Private Sub Clicka()
        objDiaf.Riversa()
        Aggiorna()
        Clickato = True
    End Sub
    'UPGRADE_WARNING: Form evento frmDiaf.Activate presenta un nuovo comportamento. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup2065"'
    Private Sub frmDiaf_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
        Aggiorna()
    End Sub
    Public Sub Inizializza()
        Dim rit As Short
        Dim x, y As Single
        Dim ag As Single
        cmdCil = New ButtonArray(Me, Me, "_cmdCil")
        'Dimensioni form
        Me.Top = GlobalRoutines.TwipsToPixelsY(100)
        Me.Left = GlobalRoutines.TwipsToPixelsX(500)
        '    Me.Width = 9100
        '    Me.Height = 7400
        'Dimensioni form
        frmMsgDiaf.DefInstance.Top = GlobalRoutines.TwipsToPixelsY(4500)
        frmMsgDiaf.DefInstance.Left = GlobalRoutines.TwipsToPixelsX(3500)
        'Dimensione e posizionamento label
        x = 50 : y = 100
        For rit = 0 To 18
            Label1(rit).Left = GlobalRoutines.TwipsToPixelsX(y)
            Label1(rit).Top = GlobalRoutines.TwipsToPixelsY(x)
            Label1(rit).Height = GlobalRoutines.TwipsToPixelsY(300)
            Label1(rit).Width = GlobalRoutines.TwipsToPixelsX(2700)
            Label1(rit).BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D

            x = x + 350
        Next
        x = 50 : y = 5500
        For rit = 19 To 35
            Label1(rit).Left = GlobalRoutines.TwipsToPixelsX(y)
            Label1(rit).Top = GlobalRoutines.TwipsToPixelsY(x)
            Label1(rit).Height = GlobalRoutines.TwipsToPixelsY(300)
            Label1(rit).Width = GlobalRoutines.TwipsToPixelsX(2700)
            Label1(rit).BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            x = x + 350
        Next
        'Dimensionamento label4
        x = 50 : y = 100
        For rit = 0 To 14
            Select Case rit
                Case 3, 5, 7, 11
                    x = x + 350
            End Select
            Label2(rit).Left = GlobalRoutines.TwipsToPixelsX(y + 3500)
            Label2(rit).Top = GlobalRoutines.TwipsToPixelsY(x)
            Label2(rit).Height = GlobalRoutines.TwipsToPixelsY(300)
            Label2(rit).Width = GlobalRoutines.TwipsToPixelsX(850)
            Label2(rit).BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            x = x + 350
        Next
        x = 400 : y = 5500
        For rit = 15 To 30
            ' Select Case rit
            '      Case 16
            '          x = x + 450
            '   End Select
            Label2(rit).Left = GlobalRoutines.TwipsToPixelsX(y + 3500)
            Label2(rit).Top = GlobalRoutines.TwipsToPixelsY(x)
            Label2(rit).Height = GlobalRoutines.TwipsToPixelsY(300)
            Label2(rit).Width = GlobalRoutines.TwipsToPixelsX(850)
            Label2(rit).BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            x = x + 350
        Next
        'Dimensione e posizionamento text
        x = 50 : y = 2450
        For rit = 0 To 18
            Select Case rit
                Case 3, 6, 9, 14
                    ag = 610
                Case Else
                    ag = 0
            End Select
            Text1(rit).Left = GlobalRoutines.TwipsToPixelsX(y)
            Text1(rit).Top = GlobalRoutines.TwipsToPixelsY(x)
            Text1(rit).Height = GlobalRoutines.TwipsToPixelsY(300)
            Text1(rit).Width = GlobalRoutines.TwipsToPixelsX(1100 + ag)
            Text1(rit).Text = ""
            x = x + 350
            Select Case rit
                Case 3, 6, 9, 14
                    cmdCil.Load(rit)
                    cmdCil(rit).Top = Text1(rit).Top
                    cmdCil(rit).Left = Text1(rit).Left + Text1(rit).Width
                    cmdCil(rit).Visible = True
            End Select
            Select Case rit
                Case 14 'diaframma
                    chkAgganciatoD.Left = cmdCil(rit).Left + cmdCil(rit).Width
                    chkAgganciatoD.Top = cmdCil(rit).Top
                    chkAgganciatoD.Checked = Matdim(objDiaf.pindiceD).Agganciato
                Case 9 'bulloni
                    chkAgganciatoB.Left = cmdCil(rit).Left + cmdCil(rit).Width
                    chkAgganciatoB.Top = cmdCil(rit).Top
                    chkAgganciatoB.Checked = Matdim(objDiaf.pindiceB).Agganciato
                Case 6 'coperchio
                    chkAgganciatoC.Left = cmdCil(rit).Left + cmdCil(rit).Width
                    chkAgganciatoC.Top = cmdCil(rit).Top
                    chkAgganciatoC.Checked = Matdim(objDiaf.pindiceC).Agganciato
                Case 3 'cassa / flangia
                    chkAgganciatoF.Left = cmdCil(rit).Left + cmdCil(rit).Width
                    chkAgganciatoF.Top = cmdCil(rit).Top
                    chkAgganciatoF.Checked = Matdim(objDiaf.pindiceF).Agganciato
            End Select
        Next
        x = 50 : y = 7850
        For rit = 19 To 35
            Select Case rit
                Case 19 : ag = 610
                Case Else : ag = 0
            End Select
            Text1(rit).Left = GlobalRoutines.TwipsToPixelsX(y)
            Text1(rit).Top = GlobalRoutines.TwipsToPixelsY(x)
            Text1(rit).Height = GlobalRoutines.TwipsToPixelsY(300)
            Text1(rit).Width = GlobalRoutines.TwipsToPixelsX(1100 + ag)
            Text1(rit).Text = ""
            Select Case rit
                Case 19
                    cmdCil.Load(rit)
                    cmdCil(rit).Top = Text1(rit).Top
                    cmdCil(rit).Left = Text1(rit).Left + Text1(rit).Width
                    cmdCil(rit).Visible = True
                    chkAgganciatoW.Left = cmdCil(rit).Left + cmdCil(rit).Width
                    chkAgganciatoW.Top = cmdCil(rit).Top
                    chkAgganciatoW.Checked = Matdim(objDiaf.pindiceW).Agganciato
            End Select
            x = x + 350
        Next
        ''10 'Impostazione delle diciture label1
        cmdCil(0).Visible = False
        Label1(0).Text = "Pressione di progetto"
        Label1(1).Text = "Pressione di Prova"
        Label1(2).Text = "Temperatura di progetto"
        Label1(3).Text = "Materiale Cassa"
        Label1(4).Text = "Ammissibile a temp.Cassa"
        Label1(5).Text = "Ammissibille amb. Cassa"
        Label1(6).Text = "Materiale Coperchio"
        Label1(7).Text = "Ammissibile a temp.Coperchio"
        Label1(8).Text = "Ammissibille amb. Coperchio"
        Label1(9).Text = "Materiale Bulloni"
        Label1(10).Text = "Ammissibile a temp.Bulloni"
        Label1(11).Text = "Ammissibile Bull. in P.I."
        Label1(12).Text = "Snervamento minimo a temp."
        Label1(13).Text = "Snervamento minimo ambiente"
        Label1(14).Text = "Materiale Diaframma"
        Label1(15).Text = "Ammissibile a temp.Diaframma"
        Label1(16).Text = "Ammissibille amb. Diaframma"
        Label1(17).Text = "Modulo elastico a temp.Diaf."
        Label1(18).Text = "Modulo elastico amb. Diaf."
        Label1(19).Text = "Materiale Saldatura"
        Label1(20).Text = "Ammissibile a temp.Saldatura"
        Label1(21).Text = "Ammissibille amb. Saldatura"
        Label1(22).Text = "Diametro interno Cassa"
        Label1(23).Text = "Diametro max Diaframma"
        Label1(24).Text = "Spessore Periferico Diaframma"
        Label1(25).Text = "Spessore al centro Diaframma"
        Label1(26).Text = "Largh.appoggio Diaframma"
        Label1(27).Text = "Diametro centro bulloni"
        Label1(28).Text = "Diametro nocciolo bulloni"
        Label1(29).Text = "N° bulloni"
        Label1(30).Text = "Dimensione saldatura"
        Label1(31).Text = "Sovraspessore corrosione"
        Label1(32).Text = "Spessore min.al centro Cop."
        Label1(33).Text = "Spessore min.in periferia Cop."
        Label1(34).Text = "Coefficiente dilat. Cassa"
        Label1(35).Text = "Coefficiente dilat. Diaframma"
        For rit = 0 To 30
            Select Case rit
                Case 2
                    Label2(rit).Text = UnitTemp
                Case 0, 1
                    Label2(rit).Text = UnitPress
                Case 3 To 10
                    Label2(rit).Text = UnitPress
                Case 13, 14
                    Label2(rit).Text = UnitPress
                Case 11, 12, 15, 16
                    Label2(rit).Text = UnitPress
                Case 17 To 23
                    Label2(rit).Text = UnitLength
                Case 24
                    Label2(rit).Text = "--"
                Case 25, 26, 27, 28
                    Label2(rit).Text = UnitLength
                Case 29, 30
                    Label2(rit).Text = "1/" & UnitTemp
            End Select
        Next
        'Label1(12).Visible = False: Label2(9).Visible = False: Text1(12).Visible = False
        'Label1(13).Visible = False: Label2(10).Visible = False: Text1(13).Visible = False
        Label1(33).Visible = False : Label2(28).Visible = False : Text1(33).Visible = False
        Width = chkAgganciatoW.Left + chkAgganciatoW.Width + 12
        HelpProvider1.HelpNamespace = RadiceHelp
    End Sub

    Private Sub Recupera()
        With objDiaf
            .DFP = GlobalRoutines.ValVir(Text1(0).Text) * psi / kPress 'pressione di progetto
            .DFPHydr = GlobalRoutines.ValVir(Text1(1).Text) * psi / kPress 'pressione di prova
            .DFt = (GlobalRoutines.ValVir(Text1(2).Text) - kTemp32) / kTemp 'temperatura di progetto
            .DFCover = Text1(6).Text
            .DFFlange = Text1(3).Text
            .DFBolt = Text1(9).Text
            .DFDiaf = Text1(14).Text
            .DFweld = Text1(19).Text
            .DFsab = GlobalRoutines.ValVir(Text1(10).Text) * psi / kPress 'bulloni
            .DFsabo = GlobalRoutines.ValVir(Text1(11).Text) * psi / kPress 'bulloni
            .DFsydo = GlobalRoutines.ValVir(Text1(12).Text) * psi / kPress 'Sy min
            .DFsydi = GlobalRoutines.ValVir(Text1(13).Text) * psi / kPress 'Sy min
            .DFsac = GlobalRoutines.ValVir(Text1(4).Text) * psi / kPress 'cassa
            .DFsaco = GlobalRoutines.ValVir(Text1(5).Text) * psi / kPress 'cassa
            .DFsad = GlobalRoutines.ValVir(Text1(15).Text) * psi / kPress 'diaframma
            .DFsado = GlobalRoutines.ValVir(Text1(16).Text) * psi / kPress 'diaframma
            .DFso = GlobalRoutines.ValVir(Text1(7).Text) * psi / kPress 'coperchio
            .DFsb = GlobalRoutines.ValVir(Text1(8).Text) * psi / kPress 'coperchio
            .DFsaw = GlobalRoutines.ValVir(Text1(20).Text) * psi / kPress 'saldatura
            .DFsawo = GlobalRoutines.ValVir(Text1(21).Text) * psi / kPress 'saldatura
            .DFid = GlobalRoutines.ValVir(Text1(34).Text) / 1.8 * kTemp 'coefficente dilatazione cassa
            .DFisi = GlobalRoutines.ValVir(Text1(35).Text) / 1.8 * kTemp 'coefficente dilatazione diaframma
            .DFdi = GlobalRoutines.ValVir(Text1(22).Text) / inc / kLength 'interno cassa
            .DFg = GlobalRoutines.ValVir(Text1(23).Text) / inc / kLength 'diametro ext.diaf.ela
            .DFb = GlobalRoutines.ValVir(Text1(26).Text) / inc / kLength 'larghezza app.diaframma
            .DFt2 = GlobalRoutines.ValVir(Text1(24).Text) / inc / kLength 'spessore perif.diaframma
            .DFt1 = GlobalRoutines.ValVir(Text1(25).Text) / inc / kLength 'spessore al centro
            .DFa = GlobalRoutines.ValVir(Text1(30).Text) / inc / kLength 'dimensione saldatura
            .DFdb = GlobalRoutines.ValVir(Text1(28).Text) / inc / kLength 'diametro nocciolo bulloni
            .DFnb = GlobalRoutines.ValVir(Text1(29).Text) 'numero bulloni
            .DFbc = GlobalRoutines.ValVir(Text1(27).Text) / inc / kLength 'diametro centro bulloni
            .DFc = GlobalRoutines.ValVir(Text1(31).Text) / inc / kLength 'corrosione
            .DFtc1 = GlobalRoutines.ValVir(Text1(32).Text) / inc / kLength 'Spessore cop. al centro
            .DFtc2 = GlobalRoutines.ValVir(Text1(33).Text) / inc / kLength 'Spessore cop.periferia
            .DFed = GlobalRoutines.ValVir(Text1(17).Text) / kPress * psi
            .DFes = GlobalRoutines.ValVir(Text1(18).Text) / kPress * psi
        End With
    End Sub

    Private Sub Aggiorna()
        With objDiaf
            Text1(0).Text = GlobalRoutines.myStr(.DFP * kPress / psi, 6 - IncrVirgola, 1 + IncrVirgola, 0)  'pressione di progetto
            Text1(1).Text = GlobalRoutines.myStr(.DFPHydr * kPress / psi, 6 - IncrVirgola, 1 + IncrVirgola, 0)  'pressione di prova
            Text1(2).Text = GlobalRoutines.myStr(.DFt * kTemp + kTemp32, 5, 2, False) 'temperatura di progetto
            Text1(3).Text = .DFFlange
            Text1(4).Text = GlobalRoutines.myStr(.DFsac * kPress / psi, 6 - IncrVirgola, 1 + IncrVirgola, 0)  'cassa
            Text1(5).Text = GlobalRoutines.myStr(.DFsaco * kPress / psi, 6 - IncrVirgola, 1 + IncrVirgola, 0)  'cassa
            Text1(6).Text = .DFCover
            Text1(7).Text = GlobalRoutines.myStr(.DFso * kPress / psi, 6 - IncrVirgola, 1 + IncrVirgola, 0)  'coperchio
            Text1(8).Text = GlobalRoutines.myStr(.DFsb * kPress / psi, 6 - IncrVirgola, 1 + IncrVirgola, 0)  'coperchio
            Text1(9).Text = .DFBolt
            Text1(10).Text = GlobalRoutines.myStr(.DFsab * kPress / psi, 6 - IncrVirgola, 1 + IncrVirgola, 0)  'bulloni
            Text1(11).Text = GlobalRoutines.myStr(.DFsabo * kPress / psi, 6 - IncrVirgola, 1 + IncrVirgola, 0) 'bulloni
            Text1(12).Text = GlobalRoutines.myStr(.DFsydo * kPress / psi, 6 - IncrVirgola, 1 + IncrVirgola, 0)  'bulloni
            Text1(13).Text = GlobalRoutines.myStr(.DFsydi * kPress / psi, 6 - IncrVirgola, 1 + IncrVirgola, 0)  'bulloni
            Text1(14).Text = .DFDiaf
            Text1(15).Text = GlobalRoutines.myStr(.DFsad * kPress / psi, 6 - IncrVirgola, 1 + IncrVirgola, 0)  'diaframma
            Text1(16).Text = GlobalRoutines.myStr(.DFsado * kPress / psi, 6 - IncrVirgola, 1 + IncrVirgola, 0)  'diaframma
            Text1(17).Text = Format(.DFed * kPress / psi, FormExp)
            Text1(18).Text = Format(.DFes * kPress / psi, FormExp)
            Text1(19).Text = .DFweld
            Text1(20).Text = GlobalRoutines.myStr(.DFsaw * kPress / psi, 6 - IncrVirgola, 1 + IncrVirgola, 0)  'saldatura
            Text1(21).Text = GlobalRoutines.myStr(.DFsawo * kPress / psi, 6 - IncrVirgola, 1 + IncrVirgola, 0)  'saldatura
            Text1(22).Text = GlobalRoutines.myStr(.DFdi * kLength * inc, 5, 2, False) 'interno cassa
            Text1(23).Text = GlobalRoutines.myStr(.DFg * kLength * inc, 5, 2, False) 'diametro ext.diaf.ela
            Text1(24).Text = GlobalRoutines.myStr(.DFt2 * kLength * inc, 5, 2, False) 'spessore perif.diaframma
            Text1(25).Text = GlobalRoutines.myStr(.DFt1 * kLength * inc, 5, 2, False) 'spessore al centro
            Text1(26).Text = GlobalRoutines.myStr(.DFb * kLength * inc, 5, 2, False) 'larghezza app.diaframma
            Text1(27).Text = GlobalRoutines.myStr(.DFbc * kLength * inc, 5, 2, False) 'diametro centro bulloni
            Text1(28).Text = GlobalRoutines.myStr(.DFdb * kLength * inc, 5, 2, False) 'diametro nocciolo bulloni
            Text1(29).Text = GlobalRoutines.myStr(.DFnb, 4, 0, True) 'numero bulloni
            Text1(30).Text = GlobalRoutines.myStr(.DFa * kLength * inc, 5, 2, False) 'dimensione saldatura
            Text1(31).Text = GlobalRoutines.myStr(.DFc * kLength * inc, 5, 2, False) 'corrosione
            Text1(32).Text = GlobalRoutines.myStr(.DFtc1 * kLength * inc, 5, 2, False) 'Spessore cop. al centro
            Text1(33).Text = GlobalRoutines.myStr(.DFtc2 * kLength * inc, 5, 2, False) 'Spessore cop.periferia
            Text1(34).Text = Format(.DFid * 1.8 / kTemp, FormExp) 'coefficente dilatazione cassa
            Text1(35).Text = Format(.DFisi * 1.8 / kTemp, FormExp) 'coefficente dilatazione diaframma
        End With
    End Sub

    Private Sub _Command1_0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Command1_0.Click
        Command1_Click(0)
    End Sub

    Private Sub _Command1_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Command1_1.Click
        Command1_Click(1)
    End Sub

    Private Sub _Command1_2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Command1_2.Click
        Command1_Click(2)
    End Sub

    Private Sub chkAgganciatoW_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkAgganciatoW.CheckedChanged
        Matdim(objDiaf.pindiceW).Agganciato = chkAgganciatoW.Checked
        ModifiedData = True
    End Sub
    Private Sub chkAgganciatoD_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkAgganciatoD.CheckedChanged
        Matdim(objDiaf.pindiceD).Agganciato = chkAgganciatoD.Checked
        ModifiedData = True
    End Sub
    Private Sub chkAgganciatoB_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkAgganciatoB.CheckedChanged
        Matdim(objDiaf.pindiceB).Agganciato = chkAgganciatoB.Checked
        ModifiedData = True
    End Sub
    Private Sub chkAgganciatoC_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkAgganciatoC.CheckedChanged
        Matdim(objDiaf.pindiceC).Agganciato = chkAgganciatoC.Checked
        ModifiedData = True
    End Sub
    Private Sub chkAgganciatoF_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkAgganciatoF.CheckedChanged
        Matdim(objDiaf.pindiceF).Agganciato = chkAgganciatoF.Checked
        ModifiedData = True
    End Sub
End Class