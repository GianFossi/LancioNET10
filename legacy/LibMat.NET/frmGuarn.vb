Option Strict On
Option Explicit On 
Imports System.Data
Imports System.Data.OleDb
Imports System.Drawing
Imports System.Drawing.Imaging
Friend Class frmGuarn
    Inherits System.Windows.Forms.Form
    Private gPicture(8) As Drawing.Graphics
#Region "Codice generato dalla finestra di progettazione Windows Form "
    Public Sub New()
        MyBase.New()
        Dim j As Short
        'Chiamata richiesta dalla progettazione Windows Form.
        IsInitializing = True
        InitializeComponent()
        For j = 0 To 8
            gPicture(j) = Graphics.FromHwnd(Picture1(j).Handle)
        Next
        IsInitializing = False
        Inizializza()
    End Sub
    'Il form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
    Protected Overloads Overrides Sub Dispose(ByVal Disposing As Boolean)
        Dim j As Integer
        If Disposing Then
            If Not components Is Nothing Then
                components.Dispose()
            End If
            For j = 0 To 8
                gPicture(j).dispose()
            Next
        End If
        MyBase.Dispose(Disposing)
    End Sub
    'Richiesto dalla progettazione Windows Form
    Private components As System.ComponentModel.IContainer
    Public ToolTip1 As System.Windows.Forms.ToolTip
    Public WithEvents _Text1_7 As System.Windows.Forms.TextBox
    Public WithEvents _Text1_6 As System.Windows.Forms.TextBox
    Public WithEvents Command1 As System.Windows.Forms.Button
    Public WithEvents _Text1_2 As System.Windows.Forms.TextBox
    Public WithEvents _Text1_1 As System.Windows.Forms.TextBox
    Public WithEvents _Text1_0 As System.Windows.Forms.TextBox
    Public WithEvents cmbTipo As System.Windows.Forms.ComboBox
    Public WithEvents cmbClass As System.Windows.Forms.ComboBox
    Public WithEvents _Label2_7 As System.Windows.Forms.Label
    Public WithEvents _Label2_6 As System.Windows.Forms.Label
    Public WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents _Label2_2 As System.Windows.Forms.Label
    Public WithEvents _Label2_1 As System.Windows.Forms.Label
    Public WithEvents _Label2_0 As System.Windows.Forms.Label
    Public WithEvents _Label1_1 As System.Windows.Forms.Label
    Public WithEvents _Label1_0 As System.Windows.Forms.Label
    Public WithEvents Label1 As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    Public WithEvents Label2 As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    Public WithEvents Picture1 As Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray
    Public WithEvents Text1 As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
    'NOTA: la routine seguente è richiesta dalla progettazione Windows Form.
    'Può essere modificata utilizzando la finestra di progettazione Windows Form.
    'Non modificarla mediante l'editor di codice.
    Friend WithEvents SSFrame11 As System.Windows.Forms.GroupBox
    Public WithEvents _Text1_5 As System.Windows.Forms.TextBox
    Public WithEvents _Text1_4 As System.Windows.Forms.TextBox
    Public WithEvents _Text1_3 As System.Windows.Forms.TextBox
    Public WithEvents Picture2 As System.Windows.Forms.PictureBox
    Public WithEvents _Label2_5 As System.Windows.Forms.Label
    Public WithEvents _Label2_4 As System.Windows.Forms.Label
    Public WithEvents _Label2_3 As System.Windows.Forms.Label
    Friend WithEvents SSFrame10 As System.Windows.Forms.GroupBox
    Public WithEvents _Picture1_8 As System.Windows.Forms.PictureBox
    Public WithEvents _Picture1_7 As System.Windows.Forms.PictureBox
    Public WithEvents _Picture1_6 As System.Windows.Forms.PictureBox
    Public WithEvents _Picture1_5 As System.Windows.Forms.PictureBox
    Public WithEvents _Picture1_4 As System.Windows.Forms.PictureBox
    Public WithEvents _Picture1_3 As System.Windows.Forms.PictureBox
    Public WithEvents _Picture1_2 As System.Windows.Forms.PictureBox
    Public WithEvents _Picture1_1 As System.Windows.Forms.PictureBox
    Public WithEvents _Picture1_0 As System.Windows.Forms.PictureBox
    Public WithEvents _SSRibbon1_8 As System.Windows.Forms.Button 'AxThreed.AxSSRibbon
    Public WithEvents _SSRibbon1_7 As System.Windows.Forms.Button 'AxThreed.AxSSRibbon
    Public WithEvents _SSRibbon1_6 As System.Windows.Forms.Button 'AxThreed.AxSSRibbon
    Public WithEvents _SSRibbon1_5 As System.Windows.Forms.Button 'AxThreed.AxSSRibbon
    Public WithEvents _SSRibbon1_4 As System.Windows.Forms.Button 'AxThreed.AxSSRibbon
    Public WithEvents _SSRibbon1_3 As System.Windows.Forms.Button 'AxThreed.AxSSRibbon
    Public WithEvents _SSRibbon1_2 As System.Windows.Forms.Button 'AxThreed.AxSSRibbon
    Public WithEvents _SSRibbon1_1 As System.Windows.Forms.Button 'AxThreed.AxSSRibbon
    Public WithEvents _SSRibbon1_0 As System.Windows.Forms.Button ' AxThreed.AxSSRibbon
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmGuarn))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me._Text1_7 = New System.Windows.Forms.TextBox
        Me._Text1_6 = New System.Windows.Forms.TextBox
        Me.Command1 = New System.Windows.Forms.Button
        Me._Text1_2 = New System.Windows.Forms.TextBox
        Me._Text1_1 = New System.Windows.Forms.TextBox
        Me._Text1_0 = New System.Windows.Forms.TextBox
        Me.cmbTipo = New System.Windows.Forms.ComboBox
        Me.cmbClass = New System.Windows.Forms.ComboBox
        Me._Label2_7 = New System.Windows.Forms.Label
        Me._Label2_6 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me._Label2_2 = New System.Windows.Forms.Label
        Me._Label2_1 = New System.Windows.Forms.Label
        Me._Label2_0 = New System.Windows.Forms.Label
        Me._Label1_1 = New System.Windows.Forms.Label
        Me._Label1_0 = New System.Windows.Forms.Label
        Me.Label1 = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        Me.Label2 = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        Me.Picture1 = New Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray(Me.components)
        Me._Picture1_8 = New System.Windows.Forms.PictureBox
        Me._Picture1_7 = New System.Windows.Forms.PictureBox
        Me._Picture1_6 = New System.Windows.Forms.PictureBox
        Me._Picture1_5 = New System.Windows.Forms.PictureBox
        Me._Picture1_4 = New System.Windows.Forms.PictureBox
        Me._Picture1_3 = New System.Windows.Forms.PictureBox
        Me._Picture1_2 = New System.Windows.Forms.PictureBox
        Me._Picture1_1 = New System.Windows.Forms.PictureBox
        Me._Picture1_0 = New System.Windows.Forms.PictureBox
        Me._SSRibbon1_8 = New System.Windows.Forms.Button
        Me._SSRibbon1_7 = New System.Windows.Forms.Button
        Me._SSRibbon1_6 = New System.Windows.Forms.Button
        Me._SSRibbon1_5 = New System.Windows.Forms.Button
        Me._SSRibbon1_4 = New System.Windows.Forms.Button
        Me._SSRibbon1_3 = New System.Windows.Forms.Button
        Me._SSRibbon1_2 = New System.Windows.Forms.Button
        Me._SSRibbon1_1 = New System.Windows.Forms.Button
        Me._SSRibbon1_0 = New System.Windows.Forms.Button
        Me.Text1 = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(Me.components)
        Me._Text1_5 = New System.Windows.Forms.TextBox
        Me._Text1_4 = New System.Windows.Forms.TextBox
        Me._Text1_3 = New System.Windows.Forms.TextBox
        Me.SSFrame11 = New System.Windows.Forms.GroupBox
        Me.Picture2 = New System.Windows.Forms.PictureBox
        Me._Label2_5 = New System.Windows.Forms.Label
        Me._Label2_4 = New System.Windows.Forms.Label
        Me._Label2_3 = New System.Windows.Forms.Label
        Me.SSFrame10 = New System.Windows.Forms.GroupBox
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Picture1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Text1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SSFrame11.SuspendLayout()
        Me.SSFrame10.SuspendLayout()
        Me.SuspendLayout()
        '
        '_Text1_7
        '
        Me._Text1_7.AcceptsReturn = True
        Me._Text1_7.AutoSize = False
        Me._Text1_7.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_7.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_7.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text1.SetIndex(Me._Text1_7, CType(7, Short))
        Me._Text1_7.Location = New System.Drawing.Point(198, 224)
        Me._Text1_7.MaxLength = 0
        Me._Text1_7.Name = "_Text1_7"
        Me._Text1_7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_7.Size = New System.Drawing.Size(139, 30)
        Me._Text1_7.TabIndex = 41
        Me._Text1_7.Text = "Text1"
        Me._Text1_7.Visible = False
        '
        '_Text1_6
        '
        Me._Text1_6.AcceptsReturn = True
        Me._Text1_6.AutoSize = False
        Me._Text1_6.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_6.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_6.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text1.SetIndex(Me._Text1_6, CType(6, Short))
        Me._Text1_6.Location = New System.Drawing.Point(198, 192)
        Me._Text1_6.MaxLength = 0
        Me._Text1_6.Name = "_Text1_6"
        Me._Text1_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_6.Size = New System.Drawing.Size(139, 30)
        Me._Text1_6.TabIndex = 39
        Me._Text1_6.Text = "Text1"
        Me._Text1_6.Visible = False
        '
        'Command1
        '
        Me.Command1.BackColor = System.Drawing.SystemColors.Control
        Me.Command1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command1.Location = New System.Drawing.Point(79, 336)
        Me.Command1.Name = "Command1"
        Me.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command1.Size = New System.Drawing.Size(186, 49)
        Me.Command1.TabIndex = 29
        Me.Command1.Text = "Approvato"
        '
        '_Text1_2
        '
        Me._Text1_2.AcceptsReturn = True
        Me._Text1_2.AutoSize = False
        Me._Text1_2.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_2.Enabled = False
        Me._Text1_2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text1.SetIndex(Me._Text1_2, CType(2, Short))
        Me._Text1_2.Location = New System.Drawing.Point(198, 158)
        Me._Text1_2.MaxLength = 0
        Me._Text1_2.Name = "_Text1_2"
        Me._Text1_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_2.Size = New System.Drawing.Size(139, 30)
        Me._Text1_2.TabIndex = 28
        Me._Text1_2.Text = "Text1"
        '
        '_Text1_1
        '
        Me._Text1_1.AcceptsReturn = True
        Me._Text1_1.AutoSize = False
        Me._Text1_1.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_1.Enabled = False
        Me._Text1_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text1.SetIndex(Me._Text1_1, CType(1, Short))
        Me._Text1_1.Location = New System.Drawing.Point(198, 78)
        Me._Text1_1.MaxLength = 0
        Me._Text1_1.Multiline = True
        Me._Text1_1.Name = "_Text1_1"
        Me._Text1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_1.Size = New System.Drawing.Size(139, 30)
        Me._Text1_1.TabIndex = 27
        Me._Text1_1.Text = "Text1"
        Me._Text1_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        '_Text1_0
        '
        Me._Text1_0.AcceptsReturn = True
        Me._Text1_0.AutoSize = False
        Me._Text1_0.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_0.Enabled = False
        Me._Text1_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text1.SetIndex(Me._Text1_0, CType(0, Short))
        Me._Text1_0.Location = New System.Drawing.Point(198, 46)
        Me._Text1_0.MaxLength = 0
        Me._Text1_0.Multiline = True
        Me._Text1_0.Name = "_Text1_0"
        Me._Text1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_0.Size = New System.Drawing.Size(139, 30)
        Me._Text1_0.TabIndex = 26
        Me._Text1_0.Text = "Text1"
        Me._Text1_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmbTipo
        '
        Me.cmbTipo.BackColor = System.Drawing.SystemColors.Window
        Me.cmbTipo.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbTipo.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbTipo.Location = New System.Drawing.Point(144, 19)
        Me.cmbTipo.Name = "cmbTipo"
        Me.cmbTipo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbTipo.Size = New System.Drawing.Size(495, 21)
        Me.cmbTipo.TabIndex = 11
        Me.cmbTipo.Text = "cmbTipo"
        '
        'cmbClass
        '
        Me.cmbClass.BackColor = System.Drawing.SystemColors.Window
        Me.cmbClass.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbClass.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbClass.Location = New System.Drawing.Point(144, 0)
        Me.cmbClass.Name = "cmbClass"
        Me.cmbClass.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbClass.Size = New System.Drawing.Size(495, 21)
        Me.cmbClass.TabIndex = 10
        Me.cmbClass.Text = "cmbClass"
        '
        '_Label2_7
        '
        Me._Label2_7.BackColor = System.Drawing.SystemColors.Control
        Me._Label2_7.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.SetIndex(Me._Label2_7, CType(7, Short))
        Me._Label2_7.Location = New System.Drawing.Point(8, 224)
        Me._Label2_7.Name = "_Label2_7"
        Me._Label2_7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_7.Size = New System.Drawing.Size(184, 30)
        Me._Label2_7.TabIndex = 42
        Me._Label2_7.Text = "Torus radius       [mm]"
        Me._Label2_7.Visible = False
        '
        '_Label2_6
        '
        Me._Label2_6.BackColor = System.Drawing.SystemColors.Control
        Me._Label2_6.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.SetIndex(Me._Label2_6, CType(6, Short))
        Me._Label2_6.Location = New System.Drawing.Point(8, 192)
        Me._Label2_6.Name = "_Label2_6"
        Me._Label2_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_6.Size = New System.Drawing.Size(184, 30)
        Me._Label2_6.TabIndex = 40
        Me._Label2_6.Text = "Seal weld, ID     [mm]"
        Me._Label2_6.Visible = False
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(8, 112)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(321, 41)
        Me.Label3.TabIndex = 38
        Me.Label3.Text = "N.B. Ove applicabile, sarà possibile modificare i valori standard di m e Y sopra " & _
        "riportati, fornendo i nuovi valori nella pagina 3 della finestra dei dati di cal" & _
        "colo della flangiatura."
        '
        '_Label2_2
        '
        Me._Label2_2.BackColor = System.Drawing.SystemColors.Control
        Me._Label2_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.SetIndex(Me._Label2_2, CType(2, Short))
        Me._Label2_2.Location = New System.Drawing.Point(6, 158)
        Me._Label2_2.Name = "_Label2_2"
        Me._Label2_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_2.Size = New System.Drawing.Size(184, 30)
        Me._Label2_2.TabIndex = 25
        Me._Label2_2.Text = "Basic Width,           b0"
        '
        '_Label2_1
        '
        Me._Label2_1.BackColor = System.Drawing.SystemColors.Control
        Me._Label2_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.SetIndex(Me._Label2_1, CType(1, Short))
        Me._Label2_1.Location = New System.Drawing.Point(6, 80)
        Me._Label2_1.Name = "_Label2_1"
        Me._Label2_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_1.Size = New System.Drawing.Size(193, 30)
        Me._Label2_1.TabIndex = 24
        Me._Label2_1.Text = "Min Seating Stress, Y"
        '
        '_Label2_0
        '
        Me._Label2_0.BackColor = System.Drawing.SystemColors.Control
        Me._Label2_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.SetIndex(Me._Label2_0, CType(0, Short))
        Me._Label2_0.Location = New System.Drawing.Point(8, 46)
        Me._Label2_0.Name = "_Label2_0"
        Me._Label2_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_0.Size = New System.Drawing.Size(193, 30)
        Me._Label2_0.TabIndex = 23
        Me._Label2_0.Text = "Gasket factor,          m"
        '
        '_Label1_1
        '
        Me._Label1_1.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.SetIndex(Me._Label1_1, CType(1, Short))
        Me._Label1_1.Location = New System.Drawing.Point(0, 19)
        Me._Label1_1.Name = "_Label1_1"
        Me._Label1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_1.Size = New System.Drawing.Size(145, 20)
        Me._Label1_1.TabIndex = 22
        Me._Label1_1.Text = "  Dimensioni / Materiale"
        '
        '_Label1_0
        '
        Me._Label1_0.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.SetIndex(Me._Label1_0, CType(0, Short))
        Me._Label1_0.Location = New System.Drawing.Point(0, 0)
        Me._Label1_0.Name = "_Label1_0"
        Me._Label1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_0.Size = New System.Drawing.Size(130, 20)
        Me._Label1_0.TabIndex = 21
        Me._Label1_0.Text = "  Tipo di guarnizione"
        '
        '_Picture1_8
        '
        Me._Picture1_8.BackColor = System.Drawing.SystemColors.Control
        Me._Picture1_8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._Picture1_8.Cursor = System.Windows.Forms.Cursors.Default
        Me._Picture1_8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Picture1.SetIndex(Me._Picture1_8, CType(8, Short))
        Me._Picture1_8.Location = New System.Drawing.Point(8, 464)
        Me._Picture1_8.Name = "_Picture1_8"
        Me._Picture1_8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Picture1_8.Size = New System.Drawing.Size(231, 59)
        Me._Picture1_8.TabIndex = 77
        Me._Picture1_8.TabStop = False
        Me._Picture1_8.Tag = "6"
        '
        '_Picture1_7
        '
        Me._Picture1_7.BackColor = System.Drawing.SystemColors.Control
        Me._Picture1_7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._Picture1_7.Cursor = System.Windows.Forms.Cursors.Default
        Me._Picture1_7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Picture1.SetIndex(Me._Picture1_7, CType(7, Short))
        Me._Picture1_7.Location = New System.Drawing.Point(8, 408)
        Me._Picture1_7.Name = "_Picture1_7"
        Me._Picture1_7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Picture1_7.Size = New System.Drawing.Size(231, 59)
        Me._Picture1_7.TabIndex = 76
        Me._Picture1_7.TabStop = False
        Me._Picture1_7.Tag = "5"
        '
        '_Picture1_6
        '
        Me._Picture1_6.BackColor = System.Drawing.SystemColors.Control
        Me._Picture1_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._Picture1_6.Cursor = System.Windows.Forms.Cursors.Default
        Me._Picture1_6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Picture1.SetIndex(Me._Picture1_6, CType(6, Short))
        Me._Picture1_6.Location = New System.Drawing.Point(8, 352)
        Me._Picture1_6.Name = "_Picture1_6"
        Me._Picture1_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Picture1_6.Size = New System.Drawing.Size(231, 59)
        Me._Picture1_6.TabIndex = 75
        Me._Picture1_6.TabStop = False
        Me._Picture1_6.Tag = "4"
        '
        '_Picture1_5
        '
        Me._Picture1_5.BackColor = System.Drawing.SystemColors.Control
        Me._Picture1_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._Picture1_5.Cursor = System.Windows.Forms.Cursors.Default
        Me._Picture1_5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Picture1.SetIndex(Me._Picture1_5, CType(5, Short))
        Me._Picture1_5.Location = New System.Drawing.Point(8, 296)
        Me._Picture1_5.Name = "_Picture1_5"
        Me._Picture1_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Picture1_5.Size = New System.Drawing.Size(231, 59)
        Me._Picture1_5.TabIndex = 74
        Me._Picture1_5.TabStop = False
        Me._Picture1_5.Tag = "3"
        '
        '_Picture1_4
        '
        Me._Picture1_4.BackColor = System.Drawing.SystemColors.Control
        Me._Picture1_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._Picture1_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._Picture1_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Picture1.SetIndex(Me._Picture1_4, CType(4, Short))
        Me._Picture1_4.Location = New System.Drawing.Point(8, 240)
        Me._Picture1_4.Name = "_Picture1_4"
        Me._Picture1_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Picture1_4.Size = New System.Drawing.Size(231, 59)
        Me._Picture1_4.TabIndex = 73
        Me._Picture1_4.TabStop = False
        Me._Picture1_4.Tag = "2"
        '
        '_Picture1_3
        '
        Me._Picture1_3.BackColor = System.Drawing.SystemColors.Control
        Me._Picture1_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._Picture1_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._Picture1_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Picture1.SetIndex(Me._Picture1_3, CType(3, Short))
        Me._Picture1_3.Location = New System.Drawing.Point(8, 184)
        Me._Picture1_3.Name = "_Picture1_3"
        Me._Picture1_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Picture1_3.Size = New System.Drawing.Size(231, 59)
        Me._Picture1_3.TabIndex = 72
        Me._Picture1_3.TabStop = False
        Me._Picture1_3.Tag = "1d"
        '
        '_Picture1_2
        '
        Me._Picture1_2.BackColor = System.Drawing.SystemColors.Control
        Me._Picture1_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._Picture1_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._Picture1_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Picture1.SetIndex(Me._Picture1_2, CType(2, Short))
        Me._Picture1_2.Location = New System.Drawing.Point(8, 128)
        Me._Picture1_2.Name = "_Picture1_2"
        Me._Picture1_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Picture1_2.Size = New System.Drawing.Size(231, 59)
        Me._Picture1_2.TabIndex = 71
        Me._Picture1_2.TabStop = False
        Me._Picture1_2.Tag = "1c"
        '
        '_Picture1_1
        '
        Me._Picture1_1.BackColor = System.Drawing.SystemColors.Control
        Me._Picture1_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._Picture1_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._Picture1_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Picture1.SetIndex(Me._Picture1_1, CType(1, Short))
        Me._Picture1_1.Location = New System.Drawing.Point(8, 72)
        Me._Picture1_1.Name = "_Picture1_1"
        Me._Picture1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Picture1_1.Size = New System.Drawing.Size(231, 59)
        Me._Picture1_1.TabIndex = 70
        Me._Picture1_1.TabStop = False
        Me._Picture1_1.Tag = "1b"
        '
        '_Picture1_0
        '
        Me._Picture1_0.BackColor = System.Drawing.SystemColors.Control
        Me._Picture1_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._Picture1_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Picture1_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Picture1.SetIndex(Me._Picture1_0, CType(0, Short))
        Me._Picture1_0.Location = New System.Drawing.Point(8, 16)
        Me._Picture1_0.Name = "_Picture1_0"
        Me._Picture1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Picture1_0.Size = New System.Drawing.Size(231, 59)
        Me._Picture1_0.TabIndex = 69
        Me._Picture1_0.TabStop = False
        Me._Picture1_0.Tag = "1a"
        '
        '_SSRibbon1_8
        '
        Me._SSRibbon1_8.Location = New System.Drawing.Point(248, 472)
        Me._SSRibbon1_8.Name = "_SSRibbon1_8"
        Me._SSRibbon1_8.Size = New System.Drawing.Size(40, 40)
        Me._SSRibbon1_8.TabIndex = 86
        '
        '_SSRibbon1_7
        '
        Me._SSRibbon1_7.Location = New System.Drawing.Point(248, 416)
        Me._SSRibbon1_7.Name = "_SSRibbon1_7"
        Me._SSRibbon1_7.Size = New System.Drawing.Size(40, 40)
        Me._SSRibbon1_7.TabIndex = 85
        '
        '_SSRibbon1_6
        '
        Me._SSRibbon1_6.Location = New System.Drawing.Point(248, 360)
        Me._SSRibbon1_6.Name = "_SSRibbon1_6"
        Me._SSRibbon1_6.Size = New System.Drawing.Size(40, 40)
        Me._SSRibbon1_6.TabIndex = 84
        '
        '_SSRibbon1_5
        '
        Me._SSRibbon1_5.Location = New System.Drawing.Point(248, 304)
        Me._SSRibbon1_5.Name = "_SSRibbon1_5"
        Me._SSRibbon1_5.Size = New System.Drawing.Size(40, 40)
        Me._SSRibbon1_5.TabIndex = 83
        '
        '_SSRibbon1_4
        '
        Me._SSRibbon1_4.Location = New System.Drawing.Point(248, 248)
        Me._SSRibbon1_4.Name = "_SSRibbon1_4"
        Me._SSRibbon1_4.Size = New System.Drawing.Size(40, 40)
        Me._SSRibbon1_4.TabIndex = 82
        '
        '_SSRibbon1_3
        '
        Me._SSRibbon1_3.Location = New System.Drawing.Point(248, 192)
        Me._SSRibbon1_3.Name = "_SSRibbon1_3"
        Me._SSRibbon1_3.Size = New System.Drawing.Size(40, 40)
        Me._SSRibbon1_3.TabIndex = 81
        '
        '_SSRibbon1_2
        '
        Me._SSRibbon1_2.Location = New System.Drawing.Point(248, 136)
        Me._SSRibbon1_2.Name = "_SSRibbon1_2"
        Me._SSRibbon1_2.Size = New System.Drawing.Size(40, 40)
        Me._SSRibbon1_2.TabIndex = 80
        '
        '_SSRibbon1_1
        '
        Me._SSRibbon1_1.Location = New System.Drawing.Point(248, 80)
        Me._SSRibbon1_1.Name = "_SSRibbon1_1"
        Me._SSRibbon1_1.Size = New System.Drawing.Size(40, 40)
        Me._SSRibbon1_1.TabIndex = 79
        '
        '_SSRibbon1_0
        '
        Me._SSRibbon1_0.Location = New System.Drawing.Point(248, 24)
        Me._SSRibbon1_0.Name = "_SSRibbon1_0"
        Me._SSRibbon1_0.Size = New System.Drawing.Size(40, 40)
        Me._SSRibbon1_0.TabIndex = 78
        '
        'Text1
        '
        '
        '_Text1_5
        '
        Me._Text1_5.AcceptsReturn = True
        Me._Text1_5.AutoSize = False
        Me._Text1_5.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_5.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_5.Enabled = False
        Me._Text1_5.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text1.SetIndex(Me._Text1_5, CType(5, Short))
        Me._Text1_5.Location = New System.Drawing.Point(180, 265)
        Me._Text1_5.MaxLength = 0
        Me._Text1_5.Multiline = True
        Me._Text1_5.Name = "_Text1_5"
        Me._Text1_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_5.Size = New System.Drawing.Size(99, 30)
        Me._Text1_5.TabIndex = 55
        Me._Text1_5.Text = "Text1"
        Me._Text1_5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        '_Text1_4
        '
        Me._Text1_4.AcceptsReturn = True
        Me._Text1_4.AutoSize = False
        Me._Text1_4.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_4.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_4.Enabled = False
        Me._Text1_4.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text1.SetIndex(Me._Text1_4, CType(4, Short))
        Me._Text1_4.Location = New System.Drawing.Point(180, 233)
        Me._Text1_4.MaxLength = 0
        Me._Text1_4.Multiline = True
        Me._Text1_4.Name = "_Text1_4"
        Me._Text1_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_4.Size = New System.Drawing.Size(99, 30)
        Me._Text1_4.TabIndex = 53
        Me._Text1_4.Text = "Text1"
        Me._Text1_4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        '_Text1_3
        '
        Me._Text1_3.AcceptsReturn = True
        Me._Text1_3.AutoSize = False
        Me._Text1_3.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_3.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_3.Enabled = False
        Me._Text1_3.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text1.SetIndex(Me._Text1_3, CType(3, Short))
        Me._Text1_3.Location = New System.Drawing.Point(180, 201)
        Me._Text1_3.MaxLength = 0
        Me._Text1_3.Multiline = True
        Me._Text1_3.Name = "_Text1_3"
        Me._Text1_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_3.Size = New System.Drawing.Size(99, 30)
        Me._Text1_3.TabIndex = 51
        Me._Text1_3.Text = "Text1"
        Me._Text1_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'SSFrame11
        '
        Me.SSFrame11.Controls.Add(Me._Text1_5)
        Me.SSFrame11.Controls.Add(Me._Text1_4)
        Me.SSFrame11.Controls.Add(Me._Text1_3)
        Me.SSFrame11.Controls.Add(Me.Picture2)
        Me.SSFrame11.Controls.Add(Me._Label2_5)
        Me.SSFrame11.Controls.Add(Me._Label2_4)
        Me.SSFrame11.Controls.Add(Me._Label2_3)
        Me.SSFrame11.Location = New System.Drawing.Point(32, 272)
        Me.SSFrame11.Name = "SSFrame11"
        Me.SSFrame11.Size = New System.Drawing.Size(296, 320)
        Me.SSFrame11.TabIndex = 50
        Me.SSFrame11.TabStop = False
        Me.SSFrame11.Text = "Lens type gaskets"
        '
        'Picture2
        '
        Me.Picture2.BackColor = System.Drawing.SystemColors.Control
        Me.Picture2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Picture2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Picture2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Picture2.Image = CType(resources.GetObject("Picture2.Image"), System.Drawing.Image)
        Me.Picture2.Location = New System.Drawing.Point(12, 25)
        Me.Picture2.Name = "Picture2"
        Me.Picture2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Picture2.Size = New System.Drawing.Size(273, 169)
        Me.Picture2.TabIndex = 50
        Me.Picture2.TabStop = False
        '
        '_Label2_5
        '
        Me._Label2_5.BackColor = System.Drawing.SystemColors.Control
        Me._Label2_5.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_5.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label2_5.Location = New System.Drawing.Point(12, 265)
        Me._Label2_5.Name = "_Label2_5"
        Me._Label2_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_5.Size = New System.Drawing.Size(153, 30)
        Me._Label2_5.TabIndex = 56
        Me._Label2_5.Text = "Radius R (mm)"
        '
        '_Label2_4
        '
        Me._Label2_4.BackColor = System.Drawing.SystemColors.Control
        Me._Label2_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label2_4.Location = New System.Drawing.Point(12, 233)
        Me._Label2_4.Name = "_Label2_4"
        Me._Label2_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_4.Size = New System.Drawing.Size(153, 30)
        Me._Label2_4.TabIndex = 54
        Me._Label2_4.Text = "Height (mm)"
        '
        '_Label2_3
        '
        Me._Label2_3.BackColor = System.Drawing.SystemColors.Control
        Me._Label2_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label2_3.Location = New System.Drawing.Point(12, 201)
        Me._Label2_3.Name = "_Label2_3"
        Me._Label2_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_3.Size = New System.Drawing.Size(153, 30)
        Me._Label2_3.TabIndex = 52
        Me._Label2_3.Text = "Alfa (deg.)"
        '
        'SSFrame10
        '
        Me.SSFrame10.Controls.Add(Me._Picture1_8)
        Me.SSFrame10.Controls.Add(Me._Picture1_7)
        Me.SSFrame10.Controls.Add(Me._Picture1_6)
        Me.SSFrame10.Controls.Add(Me._Picture1_5)
        Me.SSFrame10.Controls.Add(Me._Picture1_4)
        Me.SSFrame10.Controls.Add(Me._Picture1_3)
        Me.SSFrame10.Controls.Add(Me._Picture1_2)
        Me.SSFrame10.Controls.Add(Me._Picture1_1)
        Me.SSFrame10.Controls.Add(Me._Picture1_0)
        Me.SSFrame10.Controls.Add(Me._SSRibbon1_8)
        Me.SSFrame10.Controls.Add(Me._SSRibbon1_7)
        Me.SSFrame10.Controls.Add(Me._SSRibbon1_6)
        Me.SSFrame10.Controls.Add(Me._SSRibbon1_5)
        Me.SSFrame10.Controls.Add(Me._SSRibbon1_4)
        Me.SSFrame10.Controls.Add(Me._SSRibbon1_3)
        Me.SSFrame10.Controls.Add(Me._SSRibbon1_2)
        Me.SSFrame10.Controls.Add(Me._SSRibbon1_1)
        Me.SSFrame10.Controls.Add(Me._SSRibbon1_0)
        Me.SSFrame10.Location = New System.Drawing.Point(344, 48)
        Me.SSFrame10.Name = "SSFrame10"
        Me.SSFrame10.Size = New System.Drawing.Size(296, 520)
        Me.SSFrame10.TabIndex = 69
        Me.SSFrame10.TabStop = False
        Me.SSFrame10.Text = "Facings"
        '
        'frmGuarn
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(641, 586)
        Me.ControlBox = False
        Me.Controls.Add(Me._Text1_7)
        Me.Controls.Add(Me._Text1_6)
        Me.Controls.Add(Me._Text1_2)
        Me.Controls.Add(Me._Text1_1)
        Me.Controls.Add(Me._Text1_0)
        Me.Controls.Add(Me.Command1)
        Me.Controls.Add(Me.cmbTipo)
        Me.Controls.Add(Me.cmbClass)
        Me.Controls.Add(Me._Label2_7)
        Me.Controls.Add(Me._Label2_6)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me._Label2_2)
        Me.Controls.Add(Me._Label2_1)
        Me.Controls.Add(Me._Label2_0)
        Me.Controls.Add(Me._Label1_1)
        Me.Controls.Add(Me._Label1_0)
        Me.Controls.Add(Me.SSFrame11)
        Me.Controls.Add(Me.SSFrame10)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Location = New System.Drawing.Point(1, 21)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmGuarn"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Libreria guarnizioni"
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Picture1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Text1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SSFrame11.ResumeLayout(False)
        Me.SSFrame10.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
#End Region
    Private ifl As Short
    Private MyDatabase As OleDbConnection
    Private Classi, Tipi As DataTable
    Private Formule As DataTable
    Private drvF, drvC As DataRowView
    Private prIsinitializing As Boolean
    Public Property IsInitializing() As Boolean
        Get
            Return prIsinitializing
        End Get
        Set(ByVal Value As Boolean)
            prIsinitializing = Value
        End Set
    End Property
    Private Sub cmbClass_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbClass.SelectedIndexChanged
        If IsInitializing Then Exit Sub
        Dim i, j As Short
        drvC = Classi.DefaultView(cmbClass.SelectedIndex)
        For j = 0 To 8
            gPicture(j).Clear(Color.White)
            SSRibbon1(j).Enabled = False
            SSRibbon1(j).BackColor = SystemColors.Control
        Next
        For i = 3 To 17 Step 2
            If Not IsDBNull(drvC(i)) Then
                If Len(RTrim(CStr(drvC(i)))) > 0 Then
                    For j = 0 To 8
                        If RTrim(CStr(Picture1(j).Tag)) = RTrim(CStr(drvC(i))) Then
                            Dim bitmap As New Metafile(Archdir & "\" & RTrim(CStr(Picture1(j).Tag)) & ".WMF")
                            gPicture(j).DrawImage(bitmap, 0, 0, Picture1(j).Width, Picture1(j).Height)
                            SSRibbon1(j).Enabled = True
                            SSRibbon1(j).BackColor = System.Drawing.Color.Brown
                            SSRibbon1(j).Tag = Str(drvC(i + 1))
                        End If
                    Next
                End If
            End If
        Next
        cmbTipo.Items.Clear()
        Dim cmdT As OleDbDataAdapter = New OleDbDataAdapter("SELECT * FROM " & CStr(drvC(2)), MyDatabase)
        Tipi = New DataTable
        cmdT.Fill(Tipi)
        For j = 0 To CShort(Tipi.Rows.Count - 1)
            cmbTipo.Items.Add(Tipi.Rows(j)(1))
        Next
        If Guarniz.Tipo = 0 Then Guarniz.Tipo = 1
Rifai:  Try
            cmbTipo.SelectedIndex = Guarniz.Tipo - 1
        Catch e As Exception
            If Guarniz.Tipo > 1 Then
                Guarniz.Tipo = CShort(Guarniz.Tipo - 1)
                GoTo Rifai
            End If
        End Try
    End Sub
    Private Sub cmbTipo_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbTipo.SelectedIndexChanged
        If IsInitializing Then Exit Sub
        Dim i As Short
        Dim drv As DataRowView = Tipi.DefaultView(cmbTipo.SelectedIndex)
        Text1(0).Text = Format(Funzioni.ValVir(CStr(drv(2))), "#0.00")
        Text1(1).Text = CStr(drv(3))
        If Guarniz.Face = 0 Then Guarniz.Face = 1
        If cmbClass.SelectedIndex = 0 And cmbTipo.SelectedIndex >= 1 And cmbTipo.SelectedIndex <= 3 Then
            SSFrame10.Visible = False
            SSFrame11.Visible = True
            SSFrame11.BringToFront()
            If Guarniz.Alfa <= 0 Then Guarniz.Alfa = 20
            If Guarniz.Radius <= 0 Then Guarniz.Radius = 500
            If Guarniz.Height <= 0 Then Guarniz.Height = 12
            Text1(3).Text = Format(Guarniz.Alfa, "###.#")
            Text1(4).Text = Format(Guarniz.Height, "###.#")
            Text1(5).Text = Format(Guarniz.Radius, "#####.#")
        Else
            SSFrame10.Visible = True
            SSFrame11.Visible = False
            SSFrame10.BringToFront()
            If SSRibbon1(CShort(Guarniz.Face - 1)).Enabled Then
                Pigia(CShort(Guarniz.Face - 1))
            Else
                For i = 0 To 8
                    If SSRibbon1(i).Enabled Then
                        Pigia(i) 'SSRibbon1(i)._Value = True
                        Guarniz.Face = CShort(i + 1)
                        Exit Sub
                    End If
                Next
                Text1(2).Text = ""
            End If
            Label2(6).Visible = cmbClass.SelectedIndex > 13
            Text1(6).Visible = cmbClass.SelectedIndex > 13
            Label2(7).Visible = cmbClass.SelectedIndex = 15
            Text1(7).Visible = cmbClass.SelectedIndex = 15
            Text1(6).Text = Format(Guarniz.Height, "#####.#")
            Text1(7).Text = Format(Guarniz.Radius, "###.#")
            'Refresh()
        End If
    End Sub
    Public Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
        Guarniz.[Class] = CShort(cmbClass.SelectedIndex + 1)
        Guarniz.ClassS = cmbClass.Text
        Guarniz.Tipo = CShort(cmbTipo.SelectedIndex + 1)
        Guarniz.TipoS = cmbTipo.Text
        Guarniz.m = Funzioni.ValVir(Text1(0).Text)
        Guarniz.y = Funzioni.ValVir(Text1(1).Text)
        Guarniz.Formula = CShort(drvF(1))
        Guarniz.FormulaS = CStr(drvF(2))
        Formule.Dispose()
        Tipi.Dispose()
        Classi.Dispose()
        MyDatabase.Dispose()
        Dispose()
    End Sub
    Private Sub Inizializza()
        Dim i As Integer
        Dim MyFile As String = Archdir.Trim & "\WN5\Gasket.MDB"
        Dim cString As String = Conn & MyFile & ConnFine
        MyDatabase = New OleDbConnection(cString)
        Dim cmdF As OleDbDataAdapter = New OleDbDataAdapter("SELECT * FROM Formule", MyDatabase)
        Formule = New DataTable
        cmdF.Fill(Formule)
        Dim cmdC As OleDbDataAdapter = New OleDbDataAdapter("SELECT * FROM Classi", MyDatabase)
        Classi = New DataTable
        cmdC.Fill(Classi)
        For i = 0 To Classi.Rows.Count - 1
            cmbClass.Items.Add(Classi.Rows(i)(1))
        Next
        If Guarniz.[Class] = 0 Then Guarniz.[Class] = 1
        cmbClass.SelectedIndex = Guarniz.[Class] - 1
    End Sub
    Private Sub Text1_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Text1.TextChanged
        Dim Index As Short = Text1.GetIndex(CType(eventSender, TextBox))
        Select Case Index
            Case 3 : Guarniz.Alfa = Funzioni.ValVir(Text1(Index).Text)
            Case 4, 6 : Guarniz.Height = Funzioni.ValVir(Text1(Index).Text)
            Case 5, 7 : Guarniz.Radius = Funzioni.ValVir(Text1(Index).Text)
        End Select
    End Sub
    Private Sub _Picture1_0_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles _Picture1_0.Paint
        Dim i As Short
        For i = 3 To 17 Step 2
            If Not IsDBNull(drvC(i)) Then
                If Len(RTrim(CStr(drvC(i)))) > 0 Then
                    If RTrim(CStr(_Picture1_0.Tag)) = RTrim(CStr(drvC(i))) Then
                        Dim bitmap As New Metafile(Archdir & "\" & RTrim(CStr(_Picture1_0.Tag)) & ".WMF")
                        e.Graphics.DrawImage(bitmap, 0, 0, _Picture1_0.Width, _Picture1_0.Height)
                        _SSRibbon1_0.Enabled = True
                        If Guarniz.Face = 1 Then
                            _SSRibbon1_0.BackColor = System.Drawing.Color.Red
                        Else
                            _SSRibbon1_0.BackColor = System.Drawing.Color.Brown
                        End If
                        _SSRibbon1_0.Tag = Str(drvC(i + 1))
                    End If
                End If
            End If
        Next
    End Sub
    Private Sub _Picture1_1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles _Picture1_1.Paint
        Dim i As Short
        For i = 3 To 17 Step 2
            If Not IsDBNull(drvC(i)) Then
                If Len(RTrim(CStr(drvC(i)))) > 0 Then
                    If RTrim(CStr(_Picture1_1.Tag)) = RTrim(CStr(drvC(i))) Then
                        Dim bitmap As New Metafile(Archdir & "\" & RTrim(CStr(_Picture1_1.Tag)) & ".WMF")
                        e.Graphics.DrawImage(bitmap, 0, 0, _Picture1_1.Width, _Picture1_1.Height)
                        _SSRibbon1_1.Enabled = True
                        If Guarniz.Face = 2 Then
                            _SSRibbon1_1.BackColor = System.Drawing.Color.Red
                        Else
                            _SSRibbon1_1.BackColor = System.Drawing.Color.Brown
                        End If
                        _SSRibbon1_1.Tag = Str(drvC(i + 1))
                    End If
                End If
            End If
        Next
    End Sub
    Private Sub _Picture1_2_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles _Picture1_2.Paint
        Dim i As Short
        For i = 3 To 17 Step 2
            If Not IsDBNull(drvC(i)) Then
                If Len(RTrim(CStr(drvC(i)))) > 0 Then
                    If RTrim(CStr(_Picture1_2.Tag)) = RTrim(CStr(drvC(i))) Then
                        Dim bitmap As New Metafile(Archdir & "\" & RTrim(CStr(_Picture1_2.Tag)) & ".WMF")
                        e.Graphics.DrawImage(bitmap, 0, 0, _Picture1_2.Width, _Picture1_2.Height)
                        _SSRibbon1_2.Enabled = True
                        If Guarniz.Face = 3 Then
                            _SSRibbon1_2.BackColor = System.Drawing.Color.Red
                        Else
                            _SSRibbon1_2.BackColor = System.Drawing.Color.Brown
                        End If
                        _SSRibbon1_2.Tag = Str(drvC(i + 1))
                    End If
                End If
            End If
        Next
    End Sub
    Private Sub _Picture1_3_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles _Picture1_3.Paint
        Dim i As Short
        For i = 3 To 17 Step 2
            If Not IsDBNull(drvC(i)) Then
                If Len(RTrim(CStr(drvC(i)))) > 0 Then
                    If RTrim(CStr(_Picture1_3.Tag)) = RTrim(CStr(drvC(i))) Then
                        Dim bitmap As New Metafile(Archdir & "\" & RTrim(CStr(_Picture1_3.Tag)) & ".WMF")
                        e.Graphics.DrawImage(bitmap, 0, 0, _Picture1_3.Width, _Picture1_3.Height)
                        _SSRibbon1_3.Enabled = True
                        If Guarniz.Face = 4 Then
                            _SSRibbon1_3.BackColor = System.Drawing.Color.Red
                        Else
                            _SSRibbon1_3.BackColor = System.Drawing.Color.Brown
                        End If
                        _SSRibbon1_3.Tag = Str(drvC(i + 1))
                    End If
                End If
            End If
        Next
    End Sub
    Private Sub _Picture1_4_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles _Picture1_4.Paint
        Dim i As Short
        For i = 3 To 17 Step 2
            If Not IsDBNull(drvC(i)) Then
                If Len(RTrim(CStr(drvC(i)))) > 0 Then
                    If RTrim(CStr(_Picture1_4.Tag)) = RTrim(CStr(drvC(i))) Then
                        Dim bitmap As New Metafile(Archdir & "\" & RTrim(CStr(_Picture1_4.Tag)) & ".WMF")
                        e.Graphics.DrawImage(bitmap, 0, 0, _Picture1_4.Width, _Picture1_4.Height)
                        _SSRibbon1_4.Enabled = True
                        If Guarniz.Face = 5 Then
                            _SSRibbon1_4.BackColor = System.Drawing.Color.Red
                        Else
                            _SSRibbon1_4.BackColor = System.Drawing.Color.Brown
                        End If
                        _SSRibbon1_4.Tag = Str(drvC(i + 1))
                    End If
                End If
            End If
        Next
    End Sub
    Private Sub _Picture1_5_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles _Picture1_5.Paint
        Dim i As Short
        For i = 3 To 17 Step 2
            If Not IsDBNull(drvC(i)) Then
                If Len(RTrim(CStr(drvC(i)))) > 0 Then
                    If RTrim(CStr(_Picture1_5.Tag)) = RTrim(CStr(drvC(i))) Then
                        Dim bitmap As New Metafile(Archdir & "\" & RTrim(CStr(_Picture1_5.Tag)) & ".WMF")
                        e.Graphics.DrawImage(bitmap, 0, 0, _Picture1_5.Width, _Picture1_5.Height)
                        _SSRibbon1_5.Enabled = True
                        If Guarniz.Face = 6 Then
                            _SSRibbon1_5.BackColor = System.Drawing.Color.Red
                        Else
                            _SSRibbon1_5.BackColor = System.Drawing.Color.Brown
                        End If
                        _SSRibbon1_5.Tag = Str(drvC(i + 1))
                    End If
                End If
            End If
        Next
    End Sub
    Private Sub _Picture1_6_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles _Picture1_6.Paint
        Dim i As Short
        For i = 3 To 17 Step 2
            If Not IsDBNull(drvC(i)) Then
                If Len(RTrim(CStr(drvC(i)))) > 0 Then
                    If RTrim(CStr(_Picture1_6.Tag)) = RTrim(CStr(drvC(i))) Then
                        Dim bitmap As New Metafile(Archdir & "\" & RTrim(CStr(_Picture1_6.Tag)) & ".WMF")
                        e.Graphics.DrawImage(bitmap, 0, 0, _Picture1_6.Width, _Picture1_6.Height)
                        _SSRibbon1_6.Enabled = True
                        If Guarniz.Face = 7 Then
                            _SSRibbon1_6.BackColor = System.Drawing.Color.Red
                        Else
                            _SSRibbon1_6.BackColor = System.Drawing.Color.Brown
                        End If
                        _SSRibbon1_6.Tag = Str(drvC(i + 1))
                    End If
                End If
            End If
        Next
    End Sub
    Private Sub _Picture1_7_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles _Picture1_7.Paint
        Dim i As Short
        For i = 3 To 17 Step 2
            If Not IsDBNull(drvC(i)) Then
                If Len(RTrim(CStr(drvC(i)))) > 0 Then
                    If RTrim(CStr(_Picture1_7.Tag)) = RTrim(CStr(drvC(i))) Then
                        Dim bitmap As New Metafile(Archdir & "\" & RTrim(CStr(_Picture1_7.Tag)) & ".WMF")
                        e.Graphics.DrawImage(bitmap, 0, 0, _Picture1_7.Width, _Picture1_7.Height)
                        _SSRibbon1_7.Enabled = True
                        If Guarniz.Face = 8 Then
                            _SSRibbon1_7.BackColor = System.Drawing.Color.Red
                        Else
                            _SSRibbon1_7.BackColor = System.Drawing.Color.Brown
                        End If
                        _SSRibbon1_7.Tag = Str(drvC(i + 1))
                    End If
                End If
            End If
        Next
    End Sub
    Private Sub _Picture1_8_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles _Picture1_8.Paint
        Dim i As Short
        For i = 3 To 17 Step 2
            If Not IsDBNull(drvC(i)) Then
                If Len(RTrim(CStr(drvC(i)))) > 0 Then
                    If RTrim(CStr(_Picture1_8.Tag)) = RTrim(CStr(drvC(i))) Then
                        Dim bitmap As New Metafile(Archdir & "\" & RTrim(CStr(_Picture1_8.Tag)) & ".WMF")
                        e.Graphics.DrawImage(bitmap, 0, 0, _Picture1_8.Width, _Picture1_8.Height)
                        _SSRibbon1_8.Enabled = True
                        If Guarniz.Face = 9 Then
                            _SSRibbon1_8.BackColor = System.Drawing.Color.Red
                        Else
                            _SSRibbon1_8.BackColor = System.Drawing.Color.Brown
                        End If
                        _SSRibbon1_8.Tag = Str(drvC(i + 1))
                    End If
                End If
            End If
        Next
    End Sub
    Private Sub Pigia(ByVal i As Short)
        Dim j As Short
        For j = 0 To 8
            If SSRibbon1(j).Enabled Then SSRibbon1(j).BackColor = Color.Brown
        Next
        SSRibbon1(i).BackColor = Color.Red
        drvF = Formule.DefaultView(CInt(Val(SSRibbon1(i).Tag) - 1))
        Text1(2).Text = CStr(drvF(2))
        Guarniz.Face = CShort(i + 1)
    End Sub
    Private Sub SSRibbon1_Click(ByVal Index As Short)
        Pigia(Index)
    End Sub
    Private Function SSRibbon1(ByVal Index As Short) As Button
        Select Case Index
            Case 0 : Return _SSRibbon1_0
            Case 1 : Return _SSRibbon1_1
            Case 2 : Return _SSRibbon1_2
            Case 3 : Return _SSRibbon1_3
            Case 4 : Return _SSRibbon1_4
            Case 5 : Return _SSRibbon1_5
            Case 6 : Return _SSRibbon1_6
            Case 7 : Return _SSRibbon1_7
            Case 8 : Return _SSRibbon1_8
            Case Else : Return Nothing
        End Select
    End Function
    Private Sub _SSRibbon1_0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _SSRibbon1_0.Click
        SSRibbon1_Click(0)
    End Sub
    Private Sub _SSRibbon1_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _SSRibbon1_1.Click
        SSRibbon1_Click(1)
    End Sub
    Private Sub _SSRibbon1_2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _SSRibbon1_2.Click
        SSRibbon1_Click(2)
    End Sub
    Private Sub _SSRibbon1_3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _SSRibbon1_3.Click
        SSRibbon1_Click(3)
    End Sub
    Private Sub _SSRibbon1_4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _SSRibbon1_4.Click
        SSRibbon1_Click(4)
    End Sub
    Private Sub _SSRibbon1_5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _SSRibbon1_5.Click
        SSRibbon1_Click(5)
    End Sub
    Private Sub _SSRibbon1_6_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _SSRibbon1_6.Click
        SSRibbon1_Click(6)
    End Sub
    Private Sub _SSRibbon1_7_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _SSRibbon1_7.Click
        SSRibbon1_Click(7)
    End Sub
    Private Sub _SSRibbon1_8_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _SSRibbon1_8.Click
        SSRibbon1_Click(8)
    End Sub
End Class