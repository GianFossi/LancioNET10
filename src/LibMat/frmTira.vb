Option Strict On
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports Routbase1
Public Class frmTira
    Inherits System.Windows.Forms.Form
#Region "Codice generato dalla finestra di progettazione Windows Form "
    Public Sub New()
        Me.New(True)
    End Sub
    ' Construct controls separately from database initialization for Windows UI checks.
    Friend Sub New(initializeData As Boolean)
        MyBase.New()
        'Chiamata richiesta dalla progettazione Windows Form.
        Inizializzando = True
        InitializeComponent()
        Inizializzando = False
        If initializeData Then Inizializza()
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
    Public WithEvents _Text1_7 As System.Windows.Forms.TextBox
    Public WithEvents Command1 As System.Windows.Forms.Button
    Public WithEvents _Text1_6 As System.Windows.Forms.TextBox
    Public WithEvents _Text1_5 As System.Windows.Forms.TextBox
    Public WithEvents _Text1_4 As System.Windows.Forms.TextBox
    Public WithEvents _Text1_3 As System.Windows.Forms.TextBox
    Public WithEvents _Text1_2 As System.Windows.Forms.TextBox
    Public WithEvents _Text1_1 As System.Windows.Forms.TextBox
    Public WithEvents cmbDN As System.Windows.Forms.ComboBox
    Public WithEvents _Text1_0 As System.Windows.Forms.TextBox
    Public WithEvents cmbxFil As System.Windows.Forms.ComboBox
    Public WithEvents _Label1_6 As System.Windows.Forms.Label
    Public WithEvents _Label1_9 As System.Windows.Forms.Label
    Public WithEvents _Label1_8 As System.Windows.Forms.Label
    Public WithEvents _Label1_7 As System.Windows.Forms.Label
    Public WithEvents _Label1_5 As System.Windows.Forms.Label
    Public WithEvents _Label1_4 As System.Windows.Forms.Label
    Public WithEvents _Label1_3 As System.Windows.Forms.Label
    Public WithEvents _Label1_2 As System.Windows.Forms.Label
    Public WithEvents _Label1_1 As System.Windows.Forms.Label
    Public WithEvents _Label1_0 As System.Windows.Forms.Label
    Public Label1 As New System.Collections.Generic.Dictionary(Of Integer, Label)
    Public Text1 As New System.Collections.Generic.Dictionary(Of Integer, TextBox)
    'NOTA: la routine seguente è richiesta dalla progettazione Windows Form.
    'Può essere modificata utilizzando la finestra di progettazione Windows Form.
    'Non modificarla mediante l'editor di codice.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmTira))
        Me.components = New System.ComponentModel.Container()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
        Me.ToolTip1.Active = True
        Me._Text1_7 = New System.Windows.Forms.TextBox
        Me.Command1 = New System.Windows.Forms.Button
        Me._Text1_6 = New System.Windows.Forms.TextBox
        Me._Text1_5 = New System.Windows.Forms.TextBox
        Me._Text1_4 = New System.Windows.Forms.TextBox
        Me._Text1_3 = New System.Windows.Forms.TextBox
        Me._Text1_2 = New System.Windows.Forms.TextBox
        Me._Text1_1 = New System.Windows.Forms.TextBox
        Me.cmbDN = New System.Windows.Forms.ComboBox
        Me._Text1_0 = New System.Windows.Forms.TextBox
        Me.cmbxFil = New System.Windows.Forms.ComboBox
        Me._Label1_6 = New System.Windows.Forms.Label
        Me._Label1_9 = New System.Windows.Forms.Label
        Me._Label1_8 = New System.Windows.Forms.Label
        Me._Label1_7 = New System.Windows.Forms.Label
        Me._Label1_5 = New System.Windows.Forms.Label
        Me._Label1_4 = New System.Windows.Forms.Label
        Me._Label1_3 = New System.Windows.Forms.Label
        Me._Label1_2 = New System.Windows.Forms.Label
        Me._Label1_1 = New System.Windows.Forms.Label
        Me._Label1_0 = New System.Windows.Forms.Label
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Text = "Libreria tiranti"
        Me.ClientSize = New System.Drawing.Size(331, 197)
        Me.Location = New System.Drawing.Point(318, 286)
        Me.ControlBox = False
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.Enabled = True
        Me.KeyPreview = False
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowInTaskbar = True
        Me.HelpButton = False
        Me.WindowState = System.Windows.Forms.FormWindowState.Normal
        Me.Name = "frmTira"
        Me._Text1_7.AutoSize = False
        Me._Text1_7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me._Text1_7.Size = New System.Drawing.Size(80, 20)
        Me._Text1_7.Location = New System.Drawing.Point(163, 174)
        Me._Text1_7.Multiline = True
        Me._Text1_7.TabIndex = 19
        Me._Text1_7.Text = "Text1"
        Me._Text1_7.AcceptsReturn = True
        Me._Text1_7.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_7.CausesValidation = True
        Me._Text1_7.Enabled = True
        Me._Text1_7.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_7.HideSelection = True
        Me._Text1_7.ReadOnly = False
        Me._Text1_7.MaxLength = 0
        Me._Text1_7.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_7.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me._Text1_7.TabStop = True
        Me._Text1_7.Visible = True
        Me._Text1_7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._Text1_7.Name = "_Text1_7"
        Me.Command1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Command1.Text = "OK"
        Me.Command1.Size = New System.Drawing.Size(46, 20)
        Me.Command1.Location = New System.Drawing.Point(279, 171)
        Me.Command1.TabIndex = 18
        Me.Command1.BackColor = System.Drawing.SystemColors.Control
        Me.Command1.CausesValidation = True
        Me.Command1.Enabled = True
        Me.Command1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command1.TabStop = True
        Me.Command1.Name = "Command1"
        Me._Text1_6.AutoSize = False
        Me._Text1_6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me._Text1_6.Size = New System.Drawing.Size(80, 20)
        Me._Text1_6.Location = New System.Drawing.Point(163, 154)
        Me._Text1_6.Multiline = True
        Me._Text1_6.TabIndex = 17
        Me._Text1_6.Text = "Text1"
        Me._Text1_6.AcceptsReturn = True
        Me._Text1_6.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_6.CausesValidation = True
        Me._Text1_6.Enabled = True
        Me._Text1_6.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_6.HideSelection = True
        Me._Text1_6.ReadOnly = False
        Me._Text1_6.MaxLength = 0
        Me._Text1_6.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_6.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me._Text1_6.TabStop = True
        Me._Text1_6.Visible = True
        Me._Text1_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._Text1_6.Name = "_Text1_6"
        Me._Text1_5.AutoSize = False
        Me._Text1_5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me._Text1_5.Size = New System.Drawing.Size(80, 20)
        Me._Text1_5.Location = New System.Drawing.Point(163, 135)
        Me._Text1_5.Multiline = True
        Me._Text1_5.TabIndex = 16
        Me._Text1_5.Text = "Text1"
        Me._Text1_5.AcceptsReturn = True
        Me._Text1_5.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_5.CausesValidation = True
        Me._Text1_5.Enabled = True
        Me._Text1_5.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_5.HideSelection = True
        Me._Text1_5.ReadOnly = False
        Me._Text1_5.MaxLength = 0
        Me._Text1_5.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_5.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me._Text1_5.TabStop = True
        Me._Text1_5.Visible = True
        Me._Text1_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._Text1_5.Name = "_Text1_5"
        Me._Text1_4.AutoSize = False
        Me._Text1_4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me._Text1_4.Size = New System.Drawing.Size(80, 20)
        Me._Text1_4.Location = New System.Drawing.Point(163, 116)
        Me._Text1_4.Multiline = True
        Me._Text1_4.TabIndex = 15
        Me._Text1_4.Text = "Text1"
        Me._Text1_4.AcceptsReturn = True
        Me._Text1_4.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_4.CausesValidation = True
        Me._Text1_4.Enabled = True
        Me._Text1_4.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_4.HideSelection = True
        Me._Text1_4.ReadOnly = False
        Me._Text1_4.MaxLength = 0
        Me._Text1_4.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_4.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me._Text1_4.TabStop = True
        Me._Text1_4.Visible = True
        Me._Text1_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._Text1_4.Name = "_Text1_4"
        Me._Text1_3.AutoSize = False
        Me._Text1_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me._Text1_3.Size = New System.Drawing.Size(80, 20)
        Me._Text1_3.Location = New System.Drawing.Point(163, 96)
        Me._Text1_3.Multiline = True
        Me._Text1_3.TabIndex = 14
        Me._Text1_3.Text = "Text1"
        Me._Text1_3.AcceptsReturn = True
        Me._Text1_3.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_3.CausesValidation = True
        Me._Text1_3.Enabled = True
        Me._Text1_3.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_3.HideSelection = True
        Me._Text1_3.ReadOnly = False
        Me._Text1_3.MaxLength = 0
        Me._Text1_3.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_3.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me._Text1_3.TabStop = True
        Me._Text1_3.Visible = True
        Me._Text1_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._Text1_3.Name = "_Text1_3"
        Me._Text1_2.AutoSize = False
        Me._Text1_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me._Text1_2.Size = New System.Drawing.Size(80, 20)
        Me._Text1_2.Location = New System.Drawing.Point(163, 77)
        Me._Text1_2.Multiline = True
        Me._Text1_2.TabIndex = 13
        Me._Text1_2.Text = "Text1"
        Me._Text1_2.AcceptsReturn = True
        Me._Text1_2.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_2.CausesValidation = True
        Me._Text1_2.Enabled = True
        Me._Text1_2.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_2.HideSelection = True
        Me._Text1_2.ReadOnly = False
        Me._Text1_2.MaxLength = 0
        Me._Text1_2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_2.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me._Text1_2.TabStop = True
        Me._Text1_2.Visible = True
        Me._Text1_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._Text1_2.Name = "_Text1_2"
        Me._Text1_1.AutoSize = False
        Me._Text1_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me._Text1_1.Size = New System.Drawing.Size(80, 20)
        Me._Text1_1.Location = New System.Drawing.Point(163, 58)
        Me._Text1_1.Multiline = True
        Me._Text1_1.TabIndex = 12
        Me._Text1_1.Text = "Text1"
        Me._Text1_1.AcceptsReturn = True
        Me._Text1_1.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_1.CausesValidation = True
        Me._Text1_1.Enabled = True
        Me._Text1_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_1.HideSelection = True
        Me._Text1_1.ReadOnly = False
        Me._Text1_1.MaxLength = 0
        Me._Text1_1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_1.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me._Text1_1.TabStop = True
        Me._Text1_1.Visible = True
        Me._Text1_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._Text1_1.Name = "_Text1_1"
        Me.cmbDN.Size = New System.Drawing.Size(80, 20)
        Me.cmbDN.Location = New System.Drawing.Point(163, 20)
        Me.cmbDN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDN.TabIndex = 11
        Me.cmbDN.BackColor = System.Drawing.SystemColors.Window
        Me.cmbDN.CausesValidation = True
        Me.cmbDN.Enabled = True
        Me.cmbDN.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbDN.IntegralHeight = True
        Me.cmbDN.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbDN.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbDN.Sorted = False
        Me.cmbDN.TabStop = True
        Me.cmbDN.Visible = True
        Me.cmbDN.Name = "cmbDN"
        Me._Text1_0.AutoSize = False
        Me._Text1_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me._Text1_0.Size = New System.Drawing.Size(80, 20)
        Me._Text1_0.Location = New System.Drawing.Point(163, 39)
        Me._Text1_0.Multiline = True
        Me._Text1_0.TabIndex = 10
        Me._Text1_0.Text = "Text1"
        Me._Text1_0.AcceptsReturn = True
        Me._Text1_0.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_0.CausesValidation = True
        Me._Text1_0.Enabled = True
        Me._Text1_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_0.HideSelection = True
        Me._Text1_0.ReadOnly = False
        Me._Text1_0.MaxLength = 0
        Me._Text1_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_0.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me._Text1_0.TabStop = True
        Me._Text1_0.Visible = True
        Me._Text1_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._Text1_0.Name = "_Text1_0"
        Me.cmbxFil.Size = New System.Drawing.Size(169, 21)
        Me.cmbxFil.Location = New System.Drawing.Point(163, 0)
        Me.cmbxFil.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbxFil.TabIndex = 0
        Me.cmbxFil.BackColor = System.Drawing.SystemColors.Window
        Me.cmbxFil.CausesValidation = True
        Me.cmbxFil.Enabled = True
        Me.cmbxFil.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbxFil.IntegralHeight = True
        Me.cmbxFil.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbxFil.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbxFil.Sorted = False
        Me.cmbxFil.TabStop = True
        Me.cmbxFil.Visible = True
        Me.cmbxFil.Name = "cmbxFil"
        Me._Label1_6.Text = "Passo filetto [mm]"
        Me._Label1_6.Size = New System.Drawing.Size(152, 20)
        Me._Label1_6.Location = New System.Drawing.Point(6, 174)
        Me._Label1_6.TabIndex = 20
        Me._Label1_6.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me._Label1_6.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_6.Enabled = True
        Me._Label1_6.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_6.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_6.UseMnemonic = True
        Me._Label1_6.Visible = True
        Me._Label1_6.AutoSize = False
        Me._Label1_6.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me._Label1_6.Name = "_Label1_6"
        Me._Label1_9.Text = "Diametro nocciolo (mm)"
        Me._Label1_9.Size = New System.Drawing.Size(152, 20)
        Me._Label1_9.Location = New System.Drawing.Point(6, 58)
        Me._Label1_9.TabIndex = 9
        Me._Label1_9.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me._Label1_9.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_9.Enabled = True
        Me._Label1_9.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_9.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_9.UseMnemonic = True
        Me._Label1_9.Visible = True
        Me._Label1_9.AutoSize = False
        Me._Label1_9.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me._Label1_9.Name = "_Label1_9"
        Me._Label1_8.Text = "Diametro nominale (mm)"
        Me._Label1_8.Size = New System.Drawing.Size(152, 20)
        Me._Label1_8.Location = New System.Drawing.Point(6, 39)
        Me._Label1_8.TabIndex = 8
        Me._Label1_8.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me._Label1_8.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_8.Enabled = True
        Me._Label1_8.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_8.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_8.UseMnemonic = True
        Me._Label1_8.Visible = True
        Me._Label1_8.AutoSize = False
        Me._Label1_8.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me._Label1_8.Name = "_Label1_8"
        Me._Label1_7.Text = "Diametro foro"
        Me._Label1_7.Size = New System.Drawing.Size(152, 20)
        Me._Label1_7.Location = New System.Drawing.Point(6, 154)
        Me._Label1_7.TabIndex = 7
        Me._Label1_7.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me._Label1_7.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_7.Enabled = True
        Me._Label1_7.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_7.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_7.UseMnemonic = True
        Me._Label1_7.Visible = True
        Me._Label1_7.AutoSize = False
        Me._Label1_7.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me._Label1_7.Name = "_Label1_7"
        Me._Label1_5.Text = "Spaziatura radiale esterno"
        Me._Label1_5.Size = New System.Drawing.Size(152, 20)
        Me._Label1_5.Location = New System.Drawing.Point(6, 135)
        Me._Label1_5.TabIndex = 6
        Me._Label1_5.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me._Label1_5.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_5.Enabled = True
        Me._Label1_5.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_5.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_5.UseMnemonic = True
        Me._Label1_5.Visible = True
        Me._Label1_5.AutoSize = False
        Me._Label1_5.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me._Label1_5.Name = "_Label1_5"
        Me._Label1_4.Text = "Spaziatura radiale interno"
        Me._Label1_4.Size = New System.Drawing.Size(152, 20)
        Me._Label1_4.Location = New System.Drawing.Point(6, 116)
        Me._Label1_4.TabIndex = 5
        Me._Label1_4.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me._Label1_4.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_4.Enabled = True
        Me._Label1_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_4.UseMnemonic = True
        Me._Label1_4.Visible = True
        Me._Label1_4.AutoSize = False
        Me._Label1_4.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me._Label1_4.Name = "_Label1_4"
        Me._Label1_3.Text = "Spaziatura circonferenziale"
        Me._Label1_3.Size = New System.Drawing.Size(152, 20)
        Me._Label1_3.Location = New System.Drawing.Point(6, 96)
        Me._Label1_3.TabIndex = 4
        Me._Label1_3.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me._Label1_3.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_3.Enabled = True
        Me._Label1_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_3.UseMnemonic = True
        Me._Label1_3.Visible = True
        Me._Label1_3.AutoSize = False
        Me._Label1_3.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me._Label1_3.Name = "_Label1_3"
        Me._Label1_2.Text = "Chiave"
        Me._Label1_2.Size = New System.Drawing.Size(152, 20)
        Me._Label1_2.Location = New System.Drawing.Point(6, 77)
        Me._Label1_2.TabIndex = 3
        Me._Label1_2.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me._Label1_2.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_2.Enabled = True
        Me._Label1_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_2.UseMnemonic = True
        Me._Label1_2.Visible = True
        Me._Label1_2.AutoSize = False
        Me._Label1_2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me._Label1_2.Name = "_Label1_2"
        Me._Label1_1.Text = "Diametro nominale"
        Me._Label1_1.Size = New System.Drawing.Size(152, 20)
        Me._Label1_1.Location = New System.Drawing.Point(6, 20)
        Me._Label1_1.TabIndex = 2
        Me._Label1_1.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me._Label1_1.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_1.Enabled = True
        Me._Label1_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_1.UseMnemonic = True
        Me._Label1_1.Visible = True
        Me._Label1_1.AutoSize = False
        Me._Label1_1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me._Label1_1.Name = "_Label1_1"
        Me._Label1_0.Text = "Tipo di tirante"
        Me._Label1_0.Size = New System.Drawing.Size(152, 20)
        Me._Label1_0.Location = New System.Drawing.Point(6, 0)
        Me._Label1_0.TabIndex = 1
        Me._Label1_0.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me._Label1_0.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_0.Enabled = True
        Me._Label1_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_0.UseMnemonic = True
        Me._Label1_0.Visible = True
        Me._Label1_0.AutoSize = False
        Me._Label1_0.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me._Label1_0.Name = "_Label1_0"
        Me.Controls.Add(_Text1_7)
        Me.Controls.Add(Command1)
        Me.Controls.Add(_Text1_6)
        Me.Controls.Add(_Text1_5)
        Me.Controls.Add(_Text1_4)
        Me.Controls.Add(_Text1_3)
        Me.Controls.Add(_Text1_2)
        Me.Controls.Add(_Text1_1)
        Me.Controls.Add(cmbDN)
        Me.Controls.Add(_Text1_0)
        Me.Controls.Add(cmbxFil)
        Me.Controls.Add(_Label1_6)
        Me.Controls.Add(_Label1_9)
        Me.Controls.Add(_Label1_8)
        Me.Controls.Add(_Label1_7)
        Me.Controls.Add(_Label1_5)
        Me.Controls.Add(_Label1_4)
        Me.Controls.Add(_Label1_3)
        Me.Controls.Add(_Label1_2)
        Me.Controls.Add(_Label1_1)
        Me.Controls.Add(_Label1_0)
        Me.Label1.Add(6, _Label1_6)
        Me.Label1.Add(9, _Label1_9)
        Me.Label1.Add(8, _Label1_8)
        Me.Label1.Add(7, _Label1_7)
        Me.Label1.Add(5, _Label1_5)
        Me.Label1.Add(4, _Label1_4)
        Me.Label1.Add(3, _Label1_3)
        Me.Label1.Add(2, _Label1_2)
        Me.Label1.Add(1, _Label1_1)
        Me.Label1.Add(0, _Label1_0)
        Me.Text1.Add(7, _Text1_7)
        Me.Text1.Add(6, _Text1_6)
        Me.Text1.Add(5, _Text1_5)
        Me.Text1.Add(4, _Text1_4)
        Me.Text1.Add(3, _Text1_3)
        Me.Text1.Add(2, _Text1_2)
        Me.Text1.Add(1, _Text1_1)
        Me.Text1.Add(0, _Text1_0)
        For Each control In Text1.Values
            AddHandler control.KeyDown, AddressOf Text1_KeyDown
        Next
        For Each control In Text1.Values
            AddHandler control.KeyPress, AddressOf Text1_KeyPress
        Next
        For Each control In Text1.Values
            AddHandler control.KeyUp, AddressOf Text1_KeyUp
        Next

    End Sub
#End Region
    Public iCurr As Short
    Private TextArr() As System.Windows.Forms.Control
    Private Inizializzando As Boolean
    Private Sub cmbDN_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbDN.SelectedIndexChanged
        Tirante.DN = CStr(cmbDN.SelectedItem) 'Text
        If Tirante.DN.Trim.Length > 0 Then Aggiorna()
    End Sub
    Private Sub cmbxFil_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbxFil.SelectedIndexChanged
        If Inizializzando Then Exit Sub
        Dim testo As String
        Dim n As Short
        Tirante.Xfil = CShort(cmbxFil.SelectedIndex + 1)
        Tirante.Apri()
        AggDN()
        If Not Tirante.CercaDN(f:=Me) Then Tirante.Cerca("Dnom")
        cmbDN.Enabled = True
        If iCurr = 0 Then iCurr = 1
        cmbDN.SelectedIndex = iCurr - 1
        cmbDN_SelectedIndexChanged(cmbDN, New System.EventArgs)
        testo = Label1(6).Text
        n = CShort(InStr(testo, "["))
        Select Case cmbxFil.SelectedIndex + 1
            Case 1, 3
                testo = testo.Substring(0, n - 1) & "[mm]"
            Case 2, 4
                testo = testo.Substring(0, n - 1) & "[UNC]"
        End Select
        Label1(6).Text = testo
    End Sub
    Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
        Check()
        Tirante.Transfer()
        Me.Close()
    End Sub
    Private Sub frmTira_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
        Aggiorna()
        ' AppActivate(Text)
    End Sub
    Private Sub Inizializza()
        Dim i As Short
        Dim j As Integer
        Nc = 7
        ReDim TextArr(Nc)
        For i = 0 To Nc : TextArr(i) = Text1(i) : Next
        cmbxFil.Items.Clear()
        If Tirante.Tipi Is Nothing Then Tirante.Apri()
        For j = 0 To Tirante.Tipi.Rows.Count - 1
            cmbxFil.Items.Add(Tirante.Tipi.Rows(j)("Descrizione"))
        Next j
        cmbDN.Enabled = False
        Tirante.Apri()
        AggDN()
        If Tirante.Xfil < 1 Or Tirante.Xfil > cmbxFil.Items.Count Then Tirante.Xfil = 1
        cmbxFil.SelectedIndex = Tirante.Xfil - 1
        Aggiorna()
        cmbxFil.Enabled = True
        cmbDN.Enabled = True
        'cmbDN.SelectedIndex = 0
    End Sub
    Private Sub Aggiorna()
        Dim j As Short
        Dim strDN As String
        '        Tirante.ListaR.Sort = "DN"
        For j = 0 To CShort(Tirante.ListaR.Count - 1)
            strDN = CStr(Tirante.ListaR(j)("DN")).Trim
            ' If strDN.Substring(0, strDN.Length - 2).Trim = Tirante.DN.Trim Then Exit For
            If strDN = Tirante.DN.Trim Then Exit For
        Next
        If j > CShort(Tirante.ListaR.Count - 1) Then j = 0
        Tirante.drv = Tirante.ListaR(j)
        Retri()
        Tirante.Transfer()
    End Sub
    Private Sub Text1_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs)
        Dim KeyCode As Keys = eventArgs.KeyCode
        Dim Shift As Integer = eventArgs.KeyData \ &H10000
        Dim Index As Short = IndexedControls.IndexOf(Text1, CType(eventSender, TextBox))
        If KeyCode = System.Windows.Forms.Keys.Return Then KeyCode = System.Windows.Forms.Keys.Down
    End Sub
    Private Sub Text1_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs)
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        Dim Index As Short = IndexedControls.IndexOf(Text1, CType(eventSender, TextBox))
        If KeyAscii = System.Windows.Forms.Keys.Return Then KeyAscii = 0
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
        Stop
    End Sub
    Private Sub Text1_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs)
        Dim KeyCode As Short = CShort(eventArgs.KeyCode)
        Dim Shift As Integer = eventArgs.KeyData \ &H10000
        Dim Index As Short = IndexedControls.IndexOf(Text1, CType(eventSender, TextBox))
        Call TrattaCar(Index, KeyCode, (Text1(Index)), TextArr, Nc)
    End Sub
    Private Sub Check()
        Dim Autorizz As Boolean
        Dim Sigla As String = ""
        If System.Math.Abs(Funzioni.ValVir(Text1(0).Text) - Tirante.Dnom) > clsTrigon.TOLER Then
            GoTo Dom
        ElseIf System.Math.Abs(Funzioni.ValVir(Text1(1).Text) - Tirante.Diam) > clsTrigon.TOLER Then
            GoTo Dom
        ElseIf System.Math.Abs(Funzioni.ValVir(Text1(2).Text) - Tirante.Chia) > clsTrigon.TOLER Then
            GoTo Dom
        ElseIf System.Math.Abs(Funzioni.ValVir(Text1(3).Text) - Tirante.BSmin) > clsTrigon.TOLER Then
            GoTo Dom
        ElseIf System.Math.Abs(Funzioni.ValVir(Text1(4).Text) - Tirante.Rmin) > clsTrigon.TOLER Then
            GoTo Dom
        ElseIf System.Math.Abs(Funzioni.ValVir(Text1(5).Text) - Tirante.Emin) > clsTrigon.TOLER Then
            GoTo Dom
        ElseIf System.Math.Abs(Funzioni.ValVir(Text1(6).Text) - Tirante.foro) > clsTrigon.TOLER Then
            GoTo Dom
        End If
        Exit Sub
Dom:
        If MsgBox("Vuoi aggiornare la libreria con i valori inseriti manualmente?", CType(MsgBoxStyle.YesNo + MsgBoxStyle.Question, MsgBoxStyle)) = MsgBoxResult.Yes Then
            If Monitor.Motore Is Nothing Then
                Autorizz = False
            Else
                Autorizz = RoutBase2.Motore2.Autorizzazione("MAT", Sigla, Monitor.Motore)
            End If
            If Autorizz Then
                With Tirante
                    .drv.BeginEdit()
                    .drv("Dnom") = Funzioni.ValVir(Text1(0).Text)
                    .drv("Diam") = Funzioni.ValVir(Text1(1).Text)
                    .drv("Chia") = Funzioni.ValVir(Text1(2).Text)
                    .drv("BSmin") = Funzioni.ValVir(Text1(3).Text)
                    .drv("Rmin") = Funzioni.ValVir(Text1(4).Text)
                    .drv("Emin") = Funzioni.ValVir(Text1(5).Text)
                    .drv("foro") = Funzioni.ValVir(Text1(6).Text)
                    .drv("Passo") = Funzioni.ValVir(Text1(7).Text)
                    .drv.EndEdit()
                    Tirante.Transfer()
                End With
            Else
                Retri()
            End If
        Else
            Retri()
        End If
    End Sub
    Private Sub Retri()
        Try
            With Tirante
                Text1(0).Text = Funzioni.myStr(CSng(.drv("Dnom")), 5, 2, 0)
                Text1(1).Text = Funzioni.myStr(CSng(.drv("Diam")), 5, 2, 0)
                Text1(2).Text = Funzioni.myStr(CSng(.drv("Chia")), 5, 2, 0)
                Text1(3).Text = Funzioni.myStr(CSng(.drv("BSmin")), 5, 2, 0)
                Text1(4).Text = Funzioni.myStr(CSng(.drv("Rmin")), 5, 2, 0)
                Text1(5).Text = Funzioni.myStr(CSng(.drv("Emin")), 5, 2, 0)
                Text1(6).Text = Funzioni.myStr(CSng(.drv("foro")), 5, 2, 0)
                Select Case .Xfil
                    Case 1, 3
                        Text1(7).Text = Funzioni.myStr(CSng(.drv("Passo")), 5, 2, 0)
                    Case 2, 4
                        Text1(7).Text = Str(.drv("Passo"))
                End Select
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message + vbCrLf + ex.StackTrace)
        End Try
    End Sub
    Public Function Preleva(ByRef i As Short) As Boolean
        Preleva = True
        Try
            With Tirante
                .Apri()
                If i > .ListaR.Count Then Return False
                .drv = .ListaR(i - 1)
                .Transfer()
            End With
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Function
    Private Sub AggDN()
        Dim i As Integer
        cmbDN.Items.Clear()
        For i = 0 To Tirante.ListaR.Count - 1
            cmbDN.Items.Add(Tirante.ListaR(i)("DN"))
        Next
    End Sub
End Class