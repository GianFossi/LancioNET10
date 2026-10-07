Option Strict Off
Option Explicit On
Imports System.Data
Imports Microsoft.Data.SqlClient
Imports routbase1
Friend Class DbaseSelle
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
    Public WithEvents cmdRibs As System.Windows.Forms.Button
    Public WithEvents cmdCancel As System.Windows.Forms.Button
    Public WithEvents Command1 As System.Windows.Forms.Button
    Public WithEvents Command2 As System.Windows.Forms.Button
    Public WithEvents Command3 As System.Windows.Forms.Button
    Public WithEvents Frame2 As System.Windows.Forms.GroupBox
    Public WithEvents _Image1_3 As System.Windows.Forms.PictureBox
    Public WithEvents _Image1_2 As System.Windows.Forms.PictureBox
    Public WithEvents _Image1_1 As System.Windows.Forms.PictureBox
    Public WithEvents _Image1_0 As System.Windows.Forms.PictureBox
    Public WithEvents Frame1 As System.Windows.Forms.GroupBox
    Public WithEvents Command4 As System.Windows.Forms.Button
    Public WithEvents _Text1_36 As System.Windows.Forms.TextBox
    Public WithEvents _Text1_35 As System.Windows.Forms.TextBox
    Public WithEvents _Text1_34 As System.Windows.Forms.TextBox
    Public WithEvents _Text1_33 As System.Windows.Forms.TextBox
    Public WithEvents _Text1_31 As System.Windows.Forms.TextBox
    Public WithEvents _Text1_32 As System.Windows.Forms.TextBox
    Public WithEvents _Text1_30 As System.Windows.Forms.TextBox
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
    Public WithEvents _Text1_19 As System.Windows.Forms.TextBox
    Public WithEvents _Text1_18 As System.Windows.Forms.TextBox
    Public WithEvents _Text1_17 As System.Windows.Forms.TextBox
    Public WithEvents _Text1_16 As System.Windows.Forms.TextBox
    Public WithEvents _Text1_15 As System.Windows.Forms.TextBox
    Public WithEvents _Text1_13 As System.Windows.Forms.TextBox
    Public WithEvents _Text1_12 As System.Windows.Forms.TextBox
    Public WithEvents _Text1_11 As System.Windows.Forms.TextBox
    Public WithEvents _Text1_10 As System.Windows.Forms.TextBox
    Public WithEvents _Text1_9 As System.Windows.Forms.TextBox
    Public WithEvents _Text1_8 As System.Windows.Forms.TextBox
    Public WithEvents _Text1_7 As System.Windows.Forms.TextBox
    Public WithEvents _Text1_6 As System.Windows.Forms.TextBox
    Public WithEvents _Text1_5 As System.Windows.Forms.TextBox
    Public WithEvents _Text1_14 As System.Windows.Forms.TextBox
    Public WithEvents _Text1_4 As System.Windows.Forms.TextBox
    Public WithEvents _Text1_3 As System.Windows.Forms.TextBox
    Public WithEvents _Text1_2 As System.Windows.Forms.TextBox
    Public WithEvents _Text1_1 As System.Windows.Forms.TextBox
    Public WithEvents _Text1_0 As System.Windows.Forms.TextBox
    Public WithEvents Shape1 As System.Windows.Forms.Label
    Public WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents _Label1_35 As System.Windows.Forms.Label
    Public WithEvents _Label1_36 As System.Windows.Forms.Label
    Public WithEvents _Label1_34 As System.Windows.Forms.Label
    Public WithEvents _Label1_33 As System.Windows.Forms.Label
    Public WithEvents _Label1_31 As System.Windows.Forms.Label
    Public WithEvents _Label1_32 As System.Windows.Forms.Label
    Public WithEvents _Label1_30 As System.Windows.Forms.Label
    Public WithEvents _Label1_29 As System.Windows.Forms.Label
    Public WithEvents _Label1_28 As System.Windows.Forms.Label
    Public WithEvents _Label1_27 As System.Windows.Forms.Label
    Public WithEvents _Label1_26 As System.Windows.Forms.Label
    Public WithEvents _Label1_25 As System.Windows.Forms.Label
    Public WithEvents _Label1_24 As System.Windows.Forms.Label
    Public WithEvents _Label1_23 As System.Windows.Forms.Label
    Public WithEvents _Label1_22 As System.Windows.Forms.Label
    Public WithEvents _Label1_21 As System.Windows.Forms.Label
    Public WithEvents _Label1_20 As System.Windows.Forms.Label
    Public WithEvents _Label1_19 As System.Windows.Forms.Label
    Public WithEvents _Label1_18 As System.Windows.Forms.Label
    Public WithEvents _Label1_17 As System.Windows.Forms.Label
    Public WithEvents _Label1_16 As System.Windows.Forms.Label
    Public WithEvents _Label1_15 As System.Windows.Forms.Label
    Public WithEvents _Label1_13 As System.Windows.Forms.Label
    Public WithEvents _Label1_12 As System.Windows.Forms.Label
    Public WithEvents _Label1_11 As System.Windows.Forms.Label
    Public WithEvents _Label1_10 As System.Windows.Forms.Label
    Public WithEvents _Label1_9 As System.Windows.Forms.Label
    Public WithEvents _Label1_8 As System.Windows.Forms.Label
    Public WithEvents _Label1_7 As System.Windows.Forms.Label
    Public WithEvents _Label1_6 As System.Windows.Forms.Label
    Public WithEvents _Label1_5 As System.Windows.Forms.Label
    Public WithEvents _Label1_14 As System.Windows.Forms.Label
    Public WithEvents _Label1_4 As System.Windows.Forms.Label
    Public WithEvents _Label1_3 As System.Windows.Forms.Label
    Public WithEvents _Label1_2 As System.Windows.Forms.Label
    Public WithEvents _Label1_1 As System.Windows.Forms.Label
    Public WithEvents _Label1_0 As System.Windows.Forms.Label
    Public Image1 As New System.Collections.Generic.Dictionary(Of Integer, PictureBox)
    Public Label1 As New System.Collections.Generic.Dictionary(Of Integer, Label)
    Public Text1 As New System.Collections.Generic.Dictionary(Of Integer, TextBox)
    'NOTA: la routine seguente è richiesta dalla progettazione Windows Form.
    'Può essere modificata utilizzando la finestra di progettazione Windows Form.
    'Non modificarla mediante l'editor di codice.
    Friend WithEvents cmdFirst As System.Windows.Forms.Button
    Friend WithEvents cmdPrevious As System.Windows.Forms.Button
    Friend WithEvents cmdLast As System.Windows.Forms.Button
    Friend WithEvents cmdNext As System.Windows.Forms.Button
    Friend WithEvents txtData As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(DbaseSelle))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Check1 = New System.Windows.Forms.CheckBox
        Me.cmdRibs = New System.Windows.Forms.Button
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.Frame2 = New System.Windows.Forms.GroupBox
        Me.txtData = New System.Windows.Forms.TextBox
        Me.cmdNext = New System.Windows.Forms.Button
        Me.cmdLast = New System.Windows.Forms.Button
        Me.cmdPrevious = New System.Windows.Forms.Button
        Me.cmdFirst = New System.Windows.Forms.Button
        Me.Command1 = New System.Windows.Forms.Button
        Me.Command2 = New System.Windows.Forms.Button
        Me.Command3 = New System.Windows.Forms.Button
        Me.Frame1 = New System.Windows.Forms.GroupBox
        Me._Image1_3 = New System.Windows.Forms.PictureBox
        Me._Image1_2 = New System.Windows.Forms.PictureBox
        Me._Image1_1 = New System.Windows.Forms.PictureBox
        Me._Image1_0 = New System.Windows.Forms.PictureBox
        Me.Command4 = New System.Windows.Forms.Button
        Me._Text1_36 = New System.Windows.Forms.TextBox
        Me._Text1_35 = New System.Windows.Forms.TextBox
        Me._Text1_34 = New System.Windows.Forms.TextBox
        Me._Text1_33 = New System.Windows.Forms.TextBox
        Me._Text1_31 = New System.Windows.Forms.TextBox
        Me._Text1_32 = New System.Windows.Forms.TextBox
        Me._Text1_30 = New System.Windows.Forms.TextBox
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
        Me._Text1_19 = New System.Windows.Forms.TextBox
        Me._Text1_18 = New System.Windows.Forms.TextBox
        Me._Text1_17 = New System.Windows.Forms.TextBox
        Me._Text1_16 = New System.Windows.Forms.TextBox
        Me._Text1_15 = New System.Windows.Forms.TextBox
        Me._Text1_13 = New System.Windows.Forms.TextBox
        Me._Text1_12 = New System.Windows.Forms.TextBox
        Me._Text1_11 = New System.Windows.Forms.TextBox
        Me._Text1_10 = New System.Windows.Forms.TextBox
        Me._Text1_9 = New System.Windows.Forms.TextBox
        Me._Text1_8 = New System.Windows.Forms.TextBox
        Me._Text1_7 = New System.Windows.Forms.TextBox
        Me._Text1_6 = New System.Windows.Forms.TextBox
        Me._Text1_5 = New System.Windows.Forms.TextBox
        Me._Text1_14 = New System.Windows.Forms.TextBox
        Me._Text1_4 = New System.Windows.Forms.TextBox
        Me._Text1_3 = New System.Windows.Forms.TextBox
        Me._Text1_2 = New System.Windows.Forms.TextBox
        Me._Text1_1 = New System.Windows.Forms.TextBox
        Me._Text1_0 = New System.Windows.Forms.TextBox
        Me.Shape1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me._Label1_35 = New System.Windows.Forms.Label
        Me._Label1_36 = New System.Windows.Forms.Label
        Me._Label1_34 = New System.Windows.Forms.Label
        Me._Label1_33 = New System.Windows.Forms.Label
        Me._Label1_31 = New System.Windows.Forms.Label
        Me._Label1_32 = New System.Windows.Forms.Label
        Me._Label1_30 = New System.Windows.Forms.Label
        Me._Label1_29 = New System.Windows.Forms.Label
        Me._Label1_28 = New System.Windows.Forms.Label
        Me._Label1_27 = New System.Windows.Forms.Label
        Me._Label1_26 = New System.Windows.Forms.Label
        Me._Label1_25 = New System.Windows.Forms.Label
        Me._Label1_24 = New System.Windows.Forms.Label
        Me._Label1_23 = New System.Windows.Forms.Label
        Me._Label1_22 = New System.Windows.Forms.Label
        Me._Label1_21 = New System.Windows.Forms.Label
        Me._Label1_20 = New System.Windows.Forms.Label
        Me._Label1_19 = New System.Windows.Forms.Label
        Me._Label1_18 = New System.Windows.Forms.Label
        Me._Label1_17 = New System.Windows.Forms.Label
        Me._Label1_16 = New System.Windows.Forms.Label
        Me._Label1_15 = New System.Windows.Forms.Label
        Me._Label1_13 = New System.Windows.Forms.Label
        Me._Label1_12 = New System.Windows.Forms.Label
        Me._Label1_11 = New System.Windows.Forms.Label
        Me._Label1_10 = New System.Windows.Forms.Label
        Me._Label1_9 = New System.Windows.Forms.Label
        Me._Label1_8 = New System.Windows.Forms.Label
        Me._Label1_7 = New System.Windows.Forms.Label
        Me._Label1_6 = New System.Windows.Forms.Label
        Me._Label1_5 = New System.Windows.Forms.Label
        Me._Label1_14 = New System.Windows.Forms.Label
        Me._Label1_4 = New System.Windows.Forms.Label
        Me._Label1_3 = New System.Windows.Forms.Label
        Me._Label1_2 = New System.Windows.Forms.Label
        Me._Label1_1 = New System.Windows.Forms.Label
        Me._Label1_0 = New System.Windows.Forms.Label
        Me.Frame2.SuspendLayout()
        Me.Frame1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Check1
        '
        Me.Check1.BackColor = System.Drawing.SystemColors.Control
        Me.Check1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Check1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Check1.Location = New System.Drawing.Point(272, 240)
        Me.Check1.Name = "Check1"
        Me.Check1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Check1.Size = New System.Drawing.Size(57, 17)
        Me.Check1.TabIndex = 83
        '
        'cmdRibs
        '
        Me.cmdRibs.BackColor = System.Drawing.SystemColors.Control
        Me.cmdRibs.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdRibs.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdRibs.Location = New System.Drawing.Point(336, 352)
        Me.cmdRibs.Name = "cmdRibs"
        Me.cmdRibs.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdRibs.Size = New System.Drawing.Size(97, 41)
        Me.cmdRibs.TabIndex = 82
        Me.cmdRibs.Text = "Ribs / Fori"
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCancel.Location = New System.Drawing.Point(128, 528)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCancel.Size = New System.Drawing.Size(81, 41)
        Me.cmdCancel.TabIndex = 81
        Me.cmdCancel.Text = "Cancel"
        '
        'Frame2
        '
        Me.Frame2.BackColor = System.Drawing.SystemColors.Control
        Me.Frame2.Controls.Add(Me.txtData)
        Me.Frame2.Controls.Add(Me.cmdNext)
        Me.Frame2.Controls.Add(Me.cmdLast)
        Me.Frame2.Controls.Add(Me.cmdPrevious)
        Me.Frame2.Controls.Add(Me.cmdFirst)
        Me.Frame2.Controls.Add(Me.Command1)
        Me.Frame2.Controls.Add(Me.Command2)
        Me.Frame2.Controls.Add(Me.Command3)
        Me.Frame2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame2.Location = New System.Drawing.Point(0, 400)
        Me.Frame2.Name = "Frame2"
        Me.Frame2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame2.Size = New System.Drawing.Size(432, 120)
        Me.Frame2.TabIndex = 77
        Me.Frame2.TabStop = False
        Me.Frame2.Text = "Gestione DataBase Selle"
        '
        'txtData
        '
        Me.txtData.Location = New System.Drawing.Point(128, 16)
        Me.txtData.Name = "txtData"
        Me.txtData.Size = New System.Drawing.Size(184, 20)
        Me.txtData.TabIndex = 85
        Me.txtData.Text = "TextBox1"
        '
        'cmdNext
        '
        Me.cmdNext.Location = New System.Drawing.Point(320, 16)
        Me.cmdNext.Name = "cmdNext"
        Me.cmdNext.Size = New System.Drawing.Size(48, 24)
        Me.cmdNext.TabIndex = 84
        Me.cmdNext.Text = "Next"
        '
        'cmdLast
        '
        Me.cmdLast.Location = New System.Drawing.Point(376, 16)
        Me.cmdLast.Name = "cmdLast"
        Me.cmdLast.Size = New System.Drawing.Size(48, 24)
        Me.cmdLast.TabIndex = 83
        Me.cmdLast.Text = "Last"
        '
        'cmdPrevious
        '
        Me.cmdPrevious.Location = New System.Drawing.Point(64, 16)
        Me.cmdPrevious.Name = "cmdPrevious"
        Me.cmdPrevious.Size = New System.Drawing.Size(56, 24)
        Me.cmdPrevious.TabIndex = 82
        Me.cmdPrevious.Text = "Previous"
        '
        'cmdFirst
        '
        Me.cmdFirst.Location = New System.Drawing.Point(8, 16)
        Me.cmdFirst.Name = "cmdFirst"
        Me.cmdFirst.Size = New System.Drawing.Size(48, 24)
        Me.cmdFirst.TabIndex = 81
        Me.cmdFirst.Text = "First"
        '
        'Command1
        '
        Me.Command1.BackColor = System.Drawing.SystemColors.Control
        Me.Command1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command1.Location = New System.Drawing.Point(304, 64)
        Me.Command1.Name = "Command1"
        Me.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command1.Size = New System.Drawing.Size(44, 48)
        Me.Command1.TabIndex = 80
        Me.Command1.Text = "ALL DB"
        '
        'Command2
        '
        Me.Command2.BackColor = System.Drawing.SystemColors.Control
        Me.Command2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command2.Location = New System.Drawing.Point(360, 64)
        Me.Command2.Name = "Command2"
        Me.Command2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command2.Size = New System.Drawing.Size(64, 48)
        Me.Command2.TabIndex = 79
        Me.Command2.Text = "NUOVA RICERCA"
        '
        'Command3
        '
        Me.Command3.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(192, Byte))
        Me.Command3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command3.Location = New System.Drawing.Point(144, 40)
        Me.Command3.Name = "Command3"
        Me.Command3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command3.Size = New System.Drawing.Size(158, 17)
        Me.Command3.TabIndex = 78
        Me.Command3.Text = "SOLO LETTURA"
        '
        'Frame1
        '
        Me.Frame1.BackColor = System.Drawing.SystemColors.Control
        Me.Frame1.Controls.Add(Me._Image1_3)
        Me.Frame1.Controls.Add(Me._Image1_2)
        Me.Frame1.Controls.Add(Me._Image1_1)
        Me.Frame1.Controls.Add(Me._Image1_0)
        Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame1.Location = New System.Drawing.Point(336, 0)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame1.Size = New System.Drawing.Size(97, 345)
        Me.Frame1.TabIndex = 76
        Me.Frame1.TabStop = False
        Me.Frame1.Text = "TipoRinf T e I"
        '
        '_Image1_3
        '
        Me._Image1_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._Image1_3.Image = CType(resources.GetObject("_Image1_3.Image"), System.Drawing.Image)
        Me.Image1.Add(3, Me._Image1_3)
        Me._Image1_3.Location = New System.Drawing.Point(8, 256)
        Me._Image1_3.Name = "_Image1_3"
        Me._Image1_3.Size = New System.Drawing.Size(79, 79)
        Me._Image1_3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me._Image1_3.TabIndex = 0
        Me._Image1_3.TabStop = False
        '
        '_Image1_2
        '
        Me._Image1_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._Image1_2.Image = CType(resources.GetObject("_Image1_2.Image"), System.Drawing.Image)
        Me.Image1.Add(2, Me._Image1_2)
        Me._Image1_2.Location = New System.Drawing.Point(8, 176)
        Me._Image1_2.Name = "_Image1_2"
        Me._Image1_2.Size = New System.Drawing.Size(79, 79)
        Me._Image1_2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me._Image1_2.TabIndex = 1
        Me._Image1_2.TabStop = False
        '
        '_Image1_1
        '
        Me._Image1_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._Image1_1.Image = CType(resources.GetObject("_Image1_1.Image"), System.Drawing.Image)
        Me.Image1.Add(1, Me._Image1_1)
        Me._Image1_1.Location = New System.Drawing.Point(8, 96)
        Me._Image1_1.Name = "_Image1_1"
        Me._Image1_1.Size = New System.Drawing.Size(79, 79)
        Me._Image1_1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me._Image1_1.TabIndex = 2
        Me._Image1_1.TabStop = False
        '
        '_Image1_0
        '
        Me._Image1_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Image1_0.Image = CType(resources.GetObject("_Image1_0.Image"), System.Drawing.Image)
        Me.Image1.Add(0, Me._Image1_0)
        Me._Image1_0.Location = New System.Drawing.Point(8, 16)
        Me._Image1_0.Name = "_Image1_0"
        Me._Image1_0.Size = New System.Drawing.Size(79, 79)
        Me._Image1_0.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me._Image1_0.TabIndex = 3
        Me._Image1_0.TabStop = False
        '
        'Command4
        '
        Me.Command4.BackColor = System.Drawing.SystemColors.Control
        Me.Command4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command4.Location = New System.Drawing.Point(224, 528)
        Me.Command4.Name = "Command4"
        Me.Command4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command4.Size = New System.Drawing.Size(41, 41)
        Me.Command4.TabIndex = 75
        Me.Command4.Text = "OK"
        '
        '_Text1_36
        '
        Me._Text1_36.AcceptsReturn = True
        Me._Text1_36.AutoSize = False
        Me._Text1_36.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_36.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_36.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text1.Add(36, Me._Text1_36)
        Me._Text1_36.Location = New System.Drawing.Point(273, 365)
        Me._Text1_36.MaxLength = 0
        Me._Text1_36.Name = "_Text1_36"
        Me._Text1_36.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_36.Size = New System.Drawing.Size(54, 19)
        Me._Text1_36.TabIndex = 36
        Me._Text1_36.Text = ""
        '
        '_Text1_35
        '
        Me._Text1_35.AcceptsReturn = True
        Me._Text1_35.AutoSize = False
        Me._Text1_35.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_35.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_35.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text1.Add(35, Me._Text1_35)
        Me._Text1_35.Location = New System.Drawing.Point(273, 345)
        Me._Text1_35.MaxLength = 0
        Me._Text1_35.Name = "_Text1_35"
        Me._Text1_35.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_35.Size = New System.Drawing.Size(54, 19)
        Me._Text1_35.TabIndex = 35
        Me._Text1_35.Text = ""
        '
        '_Text1_34
        '
        Me._Text1_34.AcceptsReturn = True
        Me._Text1_34.AutoSize = False
        Me._Text1_34.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_34.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_34.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text1.Add(34, Me._Text1_34)
        Me._Text1_34.Location = New System.Drawing.Point(107, 365)
        Me._Text1_34.MaxLength = 0
        Me._Text1_34.Name = "_Text1_34"
        Me._Text1_34.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_34.Size = New System.Drawing.Size(54, 19)
        Me._Text1_34.TabIndex = 33
        Me._Text1_34.Text = ""
        '
        '_Text1_33
        '
        Me._Text1_33.AcceptsReturn = True
        Me._Text1_33.AutoSize = False
        Me._Text1_33.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_33.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_33.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text1.Add(33, Me._Text1_33)
        Me._Text1_33.Location = New System.Drawing.Point(107, 345)
        Me._Text1_33.MaxLength = 0
        Me._Text1_33.Name = "_Text1_33"
        Me._Text1_33.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_33.Size = New System.Drawing.Size(54, 19)
        Me._Text1_33.TabIndex = 32
        Me._Text1_33.Text = ""
        '
        '_Text1_31
        '
        Me._Text1_31.AcceptsReturn = True
        Me._Text1_31.AutoSize = False
        Me._Text1_31.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_31.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_31.Enabled = False
        Me._Text1_31.ForeColor = System.Drawing.Color.Red
        Me.Text1.Add(31, Me._Text1_31)
        Me._Text1_31.Location = New System.Drawing.Point(107, 293)
        Me._Text1_31.MaxLength = 0
        Me._Text1_31.Name = "_Text1_31"
        Me._Text1_31.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_31.Size = New System.Drawing.Size(54, 19)
        Me._Text1_31.TabIndex = 15
        Me._Text1_31.Text = ""
        '
        '_Text1_32
        '
        Me._Text1_32.AcceptsReturn = True
        Me._Text1_32.AutoSize = False
        Me._Text1_32.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_32.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_32.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text1.Add(32, Me._Text1_32)
        Me._Text1_32.Location = New System.Drawing.Point(273, 326)
        Me._Text1_32.MaxLength = 0
        Me._Text1_32.Name = "_Text1_32"
        Me._Text1_32.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_32.Size = New System.Drawing.Size(54, 19)
        Me._Text1_32.TabIndex = 34
        Me._Text1_32.Text = ""
        '
        '_Text1_30
        '
        Me._Text1_30.AcceptsReturn = True
        Me._Text1_30.AutoSize = False
        Me._Text1_30.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_30.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_30.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text1.Add(30, Me._Text1_30)
        Me._Text1_30.Location = New System.Drawing.Point(274, 293)
        Me._Text1_30.MaxLength = 0
        Me._Text1_30.Name = "_Text1_30"
        Me._Text1_30.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_30.Size = New System.Drawing.Size(54, 19)
        Me._Text1_30.TabIndex = 31
        Me._Text1_30.Text = ""
        '
        '_Text1_29
        '
        Me._Text1_29.AcceptsReturn = True
        Me._Text1_29.AutoSize = False
        Me._Text1_29.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_29.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_29.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text1.Add(29, Me._Text1_29)
        Me._Text1_29.Location = New System.Drawing.Point(274, 258)
        Me._Text1_29.MaxLength = 0
        Me._Text1_29.Name = "_Text1_29"
        Me._Text1_29.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_29.Size = New System.Drawing.Size(54, 19)
        Me._Text1_29.TabIndex = 30
        Me._Text1_29.Text = ""
        '
        '_Text1_28
        '
        Me._Text1_28.AcceptsReturn = True
        Me._Text1_28.AutoSize = False
        Me._Text1_28.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_28.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_28.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text1.Add(28, Me._Text1_28)
        Me._Text1_28.Location = New System.Drawing.Point(274, 240)
        Me._Text1_28.MaxLength = 0
        Me._Text1_28.Name = "_Text1_28"
        Me._Text1_28.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_28.Size = New System.Drawing.Size(54, 19)
        Me._Text1_28.TabIndex = 29
        Me._Text1_28.Text = ""
        '
        '_Text1_27
        '
        Me._Text1_27.AcceptsReturn = True
        Me._Text1_27.AutoSize = False
        Me._Text1_27.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_27.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_27.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text1.Add(27, Me._Text1_27)
        Me._Text1_27.Location = New System.Drawing.Point(274, 222)
        Me._Text1_27.MaxLength = 0
        Me._Text1_27.Name = "_Text1_27"
        Me._Text1_27.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_27.Size = New System.Drawing.Size(54, 19)
        Me._Text1_27.TabIndex = 28
        Me._Text1_27.Text = ""
        '
        '_Text1_26
        '
        Me._Text1_26.AcceptsReturn = True
        Me._Text1_26.AutoSize = False
        Me._Text1_26.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_26.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_26.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text1.Add(26, Me._Text1_26)
        Me._Text1_26.Location = New System.Drawing.Point(274, 204)
        Me._Text1_26.MaxLength = 0
        Me._Text1_26.Name = "_Text1_26"
        Me._Text1_26.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_26.Size = New System.Drawing.Size(54, 19)
        Me._Text1_26.TabIndex = 27
        Me._Text1_26.Text = ""
        '
        '_Text1_25
        '
        Me._Text1_25.AcceptsReturn = True
        Me._Text1_25.AutoSize = False
        Me._Text1_25.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_25.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_25.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text1.Add(25, Me._Text1_25)
        Me._Text1_25.Location = New System.Drawing.Point(274, 186)
        Me._Text1_25.MaxLength = 0
        Me._Text1_25.Name = "_Text1_25"
        Me._Text1_25.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_25.Size = New System.Drawing.Size(54, 19)
        Me._Text1_25.TabIndex = 26
        Me._Text1_25.Text = ""
        '
        '_Text1_24
        '
        Me._Text1_24.AcceptsReturn = True
        Me._Text1_24.AutoSize = False
        Me._Text1_24.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_24.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_24.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text1.Add(24, Me._Text1_24)
        Me._Text1_24.Location = New System.Drawing.Point(274, 168)
        Me._Text1_24.MaxLength = 0
        Me._Text1_24.Name = "_Text1_24"
        Me._Text1_24.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_24.Size = New System.Drawing.Size(54, 19)
        Me._Text1_24.TabIndex = 25
        Me._Text1_24.Text = ""
        '
        '_Text1_23
        '
        Me._Text1_23.AcceptsReturn = True
        Me._Text1_23.AutoSize = False
        Me._Text1_23.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_23.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_23.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text1.Add(23, Me._Text1_23)
        Me._Text1_23.Location = New System.Drawing.Point(274, 150)
        Me._Text1_23.MaxLength = 0
        Me._Text1_23.Name = "_Text1_23"
        Me._Text1_23.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_23.Size = New System.Drawing.Size(54, 19)
        Me._Text1_23.TabIndex = 24
        Me._Text1_23.Text = ""
        '
        '_Text1_22
        '
        Me._Text1_22.AcceptsReturn = True
        Me._Text1_22.AutoSize = False
        Me._Text1_22.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_22.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_22.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text1.Add(22, Me._Text1_22)
        Me._Text1_22.Location = New System.Drawing.Point(274, 132)
        Me._Text1_22.MaxLength = 0
        Me._Text1_22.Name = "_Text1_22"
        Me._Text1_22.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_22.Size = New System.Drawing.Size(54, 19)
        Me._Text1_22.TabIndex = 23
        Me._Text1_22.Text = ""
        '
        '_Text1_21
        '
        Me._Text1_21.AcceptsReturn = True
        Me._Text1_21.AutoSize = False
        Me._Text1_21.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_21.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_21.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text1.Add(21, Me._Text1_21)
        Me._Text1_21.Location = New System.Drawing.Point(274, 114)
        Me._Text1_21.MaxLength = 0
        Me._Text1_21.Name = "_Text1_21"
        Me._Text1_21.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_21.Size = New System.Drawing.Size(54, 19)
        Me._Text1_21.TabIndex = 22
        Me._Text1_21.Text = ""
        '
        '_Text1_20
        '
        Me._Text1_20.AcceptsReturn = True
        Me._Text1_20.AutoSize = False
        Me._Text1_20.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_20.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_20.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text1.Add(20, Me._Text1_20)
        Me._Text1_20.Location = New System.Drawing.Point(274, 96)
        Me._Text1_20.MaxLength = 0
        Me._Text1_20.Name = "_Text1_20"
        Me._Text1_20.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_20.Size = New System.Drawing.Size(54, 19)
        Me._Text1_20.TabIndex = 21
        Me._Text1_20.Text = ""
        '
        '_Text1_19
        '
        Me._Text1_19.AcceptsReturn = True
        Me._Text1_19.AutoSize = False
        Me._Text1_19.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_19.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_19.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text1.Add(19, Me._Text1_19)
        Me._Text1_19.Location = New System.Drawing.Point(274, 78)
        Me._Text1_19.MaxLength = 0
        Me._Text1_19.Name = "_Text1_19"
        Me._Text1_19.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_19.Size = New System.Drawing.Size(54, 19)
        Me._Text1_19.TabIndex = 20
        Me._Text1_19.Text = ""
        '
        '_Text1_18
        '
        Me._Text1_18.AcceptsReturn = True
        Me._Text1_18.AutoSize = False
        Me._Text1_18.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_18.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_18.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text1.Add(18, Me._Text1_18)
        Me._Text1_18.Location = New System.Drawing.Point(274, 60)
        Me._Text1_18.MaxLength = 0
        Me._Text1_18.Name = "_Text1_18"
        Me._Text1_18.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_18.Size = New System.Drawing.Size(54, 19)
        Me._Text1_18.TabIndex = 19
        Me._Text1_18.Text = ""
        '
        '_Text1_17
        '
        Me._Text1_17.AcceptsReturn = True
        Me._Text1_17.AutoSize = False
        Me._Text1_17.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_17.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_17.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text1.Add(17, Me._Text1_17)
        Me._Text1_17.Location = New System.Drawing.Point(274, 42)
        Me._Text1_17.MaxLength = 0
        Me._Text1_17.Name = "_Text1_17"
        Me._Text1_17.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_17.Size = New System.Drawing.Size(54, 19)
        Me._Text1_17.TabIndex = 18
        Me._Text1_17.Text = ""
        '
        '_Text1_16
        '
        Me._Text1_16.AcceptsReturn = True
        Me._Text1_16.AutoSize = False
        Me._Text1_16.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_16.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_16.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text1.Add(16, Me._Text1_16)
        Me._Text1_16.Location = New System.Drawing.Point(274, 24)
        Me._Text1_16.MaxLength = 0
        Me._Text1_16.Name = "_Text1_16"
        Me._Text1_16.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_16.Size = New System.Drawing.Size(54, 19)
        Me._Text1_16.TabIndex = 17
        Me._Text1_16.Text = ""
        '
        '_Text1_15
        '
        Me._Text1_15.AcceptsReturn = True
        Me._Text1_15.AutoSize = False
        Me._Text1_15.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_15.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_15.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text1.Add(15, Me._Text1_15)
        Me._Text1_15.Location = New System.Drawing.Point(274, 8)
        Me._Text1_15.MaxLength = 0
        Me._Text1_15.Name = "_Text1_15"
        Me._Text1_15.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_15.Size = New System.Drawing.Size(54, 19)
        Me._Text1_15.TabIndex = 16
        Me._Text1_15.Text = ""
        '
        '_Text1_13
        '
        Me._Text1_13.AcceptsReturn = True
        Me._Text1_13.AutoSize = False
        Me._Text1_13.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_13.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_13.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text1.Add(13, Me._Text1_13)
        Me._Text1_13.Location = New System.Drawing.Point(107, 246)
        Me._Text1_13.MaxLength = 0
        Me._Text1_13.Name = "_Text1_13"
        Me._Text1_13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_13.Size = New System.Drawing.Size(54, 19)
        Me._Text1_13.TabIndex = 13
        Me._Text1_13.Text = ""
        '
        '_Text1_12
        '
        Me._Text1_12.AcceptsReturn = True
        Me._Text1_12.AutoSize = False
        Me._Text1_12.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_12.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_12.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text1.Add(12, Me._Text1_12)
        Me._Text1_12.Location = New System.Drawing.Point(107, 228)
        Me._Text1_12.MaxLength = 0
        Me._Text1_12.Name = "_Text1_12"
        Me._Text1_12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_12.Size = New System.Drawing.Size(54, 19)
        Me._Text1_12.TabIndex = 12
        Me._Text1_12.Text = ""
        '
        '_Text1_11
        '
        Me._Text1_11.AcceptsReturn = True
        Me._Text1_11.AutoSize = False
        Me._Text1_11.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_11.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_11.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text1.Add(11, Me._Text1_11)
        Me._Text1_11.Location = New System.Drawing.Point(107, 210)
        Me._Text1_11.MaxLength = 0
        Me._Text1_11.Name = "_Text1_11"
        Me._Text1_11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_11.Size = New System.Drawing.Size(54, 19)
        Me._Text1_11.TabIndex = 11
        Me._Text1_11.Text = ""
        '
        '_Text1_10
        '
        Me._Text1_10.AcceptsReturn = True
        Me._Text1_10.AutoSize = False
        Me._Text1_10.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_10.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_10.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text1.Add(10, Me._Text1_10)
        Me._Text1_10.Location = New System.Drawing.Point(107, 192)
        Me._Text1_10.MaxLength = 0
        Me._Text1_10.Name = "_Text1_10"
        Me._Text1_10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_10.Size = New System.Drawing.Size(54, 19)
        Me._Text1_10.TabIndex = 10
        Me._Text1_10.Text = ""
        '
        '_Text1_9
        '
        Me._Text1_9.AcceptsReturn = True
        Me._Text1_9.AutoSize = False
        Me._Text1_9.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_9.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_9.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text1.Add(9, Me._Text1_9)
        Me._Text1_9.Location = New System.Drawing.Point(107, 174)
        Me._Text1_9.MaxLength = 0
        Me._Text1_9.Name = "_Text1_9"
        Me._Text1_9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_9.Size = New System.Drawing.Size(54, 19)
        Me._Text1_9.TabIndex = 9
        Me._Text1_9.Text = ""
        '
        '_Text1_8
        '
        Me._Text1_8.AcceptsReturn = True
        Me._Text1_8.AutoSize = False
        Me._Text1_8.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_8.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_8.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text1.Add(8, Me._Text1_8)
        Me._Text1_8.Location = New System.Drawing.Point(107, 156)
        Me._Text1_8.MaxLength = 0
        Me._Text1_8.Name = "_Text1_8"
        Me._Text1_8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_8.Size = New System.Drawing.Size(54, 19)
        Me._Text1_8.TabIndex = 8
        Me._Text1_8.Text = ""
        '
        '_Text1_7
        '
        Me._Text1_7.AcceptsReturn = True
        Me._Text1_7.AutoSize = False
        Me._Text1_7.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_7.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_7.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text1.Add(7, Me._Text1_7)
        Me._Text1_7.Location = New System.Drawing.Point(107, 138)
        Me._Text1_7.MaxLength = 0
        Me._Text1_7.Name = "_Text1_7"
        Me._Text1_7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_7.Size = New System.Drawing.Size(54, 19)
        Me._Text1_7.TabIndex = 7
        Me._Text1_7.Text = ""
        '
        '_Text1_6
        '
        Me._Text1_6.AcceptsReturn = True
        Me._Text1_6.AutoSize = False
        Me._Text1_6.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_6.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_6.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text1.Add(6, Me._Text1_6)
        Me._Text1_6.Location = New System.Drawing.Point(107, 120)
        Me._Text1_6.MaxLength = 0
        Me._Text1_6.Name = "_Text1_6"
        Me._Text1_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_6.Size = New System.Drawing.Size(54, 19)
        Me._Text1_6.TabIndex = 6
        Me._Text1_6.Text = ""
        '
        '_Text1_5
        '
        Me._Text1_5.AcceptsReturn = True
        Me._Text1_5.AutoSize = False
        Me._Text1_5.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_5.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_5.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text1.Add(5, Me._Text1_5)
        Me._Text1_5.Location = New System.Drawing.Point(107, 102)
        Me._Text1_5.MaxLength = 0
        Me._Text1_5.Name = "_Text1_5"
        Me._Text1_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_5.Size = New System.Drawing.Size(54, 19)
        Me._Text1_5.TabIndex = 5
        Me._Text1_5.Text = ""
        '
        '_Text1_14
        '
        Me._Text1_14.AcceptsReturn = True
        Me._Text1_14.AutoSize = False
        Me._Text1_14.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_14.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_14.Enabled = False
        Me._Text1_14.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text1.Add(14, Me._Text1_14)
        Me._Text1_14.Location = New System.Drawing.Point(107, 264)
        Me._Text1_14.MaxLength = 0
        Me._Text1_14.Name = "_Text1_14"
        Me._Text1_14.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_14.Size = New System.Drawing.Size(54, 19)
        Me._Text1_14.TabIndex = 14
        Me._Text1_14.Text = ""
        '
        '_Text1_4
        '
        Me._Text1_4.AcceptsReturn = True
        Me._Text1_4.AutoSize = False
        Me._Text1_4.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_4.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_4.Enabled = False
        Me._Text1_4.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text1.Add(4, Me._Text1_4)
        Me._Text1_4.Location = New System.Drawing.Point(107, 84)
        Me._Text1_4.MaxLength = 0
        Me._Text1_4.Name = "_Text1_4"
        Me._Text1_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_4.Size = New System.Drawing.Size(54, 19)
        Me._Text1_4.TabIndex = 4
        Me._Text1_4.Text = ""
        '
        '_Text1_3
        '
        Me._Text1_3.AcceptsReturn = True
        Me._Text1_3.AutoSize = False
        Me._Text1_3.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_3.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_3.Enabled = False
        Me._Text1_3.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text1.Add(3, Me._Text1_3)
        Me._Text1_3.Location = New System.Drawing.Point(107, 66)
        Me._Text1_3.MaxLength = 0
        Me._Text1_3.Name = "_Text1_3"
        Me._Text1_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_3.Size = New System.Drawing.Size(54, 19)
        Me._Text1_3.TabIndex = 3
        Me._Text1_3.Text = ""
        '
        '_Text1_2
        '
        Me._Text1_2.AcceptsReturn = True
        Me._Text1_2.AutoSize = False
        Me._Text1_2.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_2.Enabled = False
        Me._Text1_2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text1.Add(2, Me._Text1_2)
        Me._Text1_2.Location = New System.Drawing.Point(107, 48)
        Me._Text1_2.MaxLength = 0
        Me._Text1_2.Name = "_Text1_2"
        Me._Text1_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_2.Size = New System.Drawing.Size(54, 19)
        Me._Text1_2.TabIndex = 2
        Me._Text1_2.Text = ""
        '
        '_Text1_1
        '
        Me._Text1_1.AcceptsReturn = True
        Me._Text1_1.AutoSize = False
        Me._Text1_1.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_1.Enabled = False
        Me._Text1_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text1.Add(1, Me._Text1_1)
        Me._Text1_1.Location = New System.Drawing.Point(107, 30)
        Me._Text1_1.MaxLength = 0
        Me._Text1_1.Name = "_Text1_1"
        Me._Text1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_1.Size = New System.Drawing.Size(54, 19)
        Me._Text1_1.TabIndex = 1
        Me._Text1_1.Text = ""
        '
        '_Text1_0
        '
        Me._Text1_0.AcceptsReturn = True
        Me._Text1_0.AutoSize = False
        Me._Text1_0.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_0.Enabled = False
        Me._Text1_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text1.Add(0, Me._Text1_0)
        Me._Text1_0.Location = New System.Drawing.Point(107, 8)
        Me._Text1_0.MaxLength = 0
        Me._Text1_0.Name = "_Text1_0"
        Me._Text1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_0.Size = New System.Drawing.Size(54, 19)
        Me._Text1_0.TabIndex = 0
        Me._Text1_0.Text = ""
        '
        'Shape1
        '
        Me.Shape1.BackColor = System.Drawing.Color.Transparent
        Me.Shape1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Shape1.Location = New System.Drawing.Point(4, 318)
        Me.Shape1.Name = "Shape1"
        Me.Shape1.Size = New System.Drawing.Size(329, 72)
        Me.Shape1.TabIndex = 84
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.ForeColor = System.Drawing.Color.Yellow
        Me.Label2.Location = New System.Drawing.Point(23, 323)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(82, 16)
        Me.Label2.TabIndex = 74
        Me.Label2.Text = "Base Superiore"
        '
        '_Label1_35
        '
        Me._Label1_35.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_35.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_35.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Add(35, Me._Label1_35)
        Me._Label1_35.Location = New System.Drawing.Point(168, 345)
        Me._Label1_35.Name = "_Label1_35"
        Me._Label1_35.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_35.Size = New System.Drawing.Size(89, 17)
        Me._Label1_35.TabIndex = 73
        Me._Label1_35.Text = "NumBolts (totali)"
        '
        '_Label1_36
        '
        Me._Label1_36.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_36.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_36.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Add(36, Me._Label1_36)
        Me._Label1_36.Location = New System.Drawing.Point(168, 365)
        Me._Label1_36.Name = "_Label1_36"
        Me._Label1_36.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_36.Size = New System.Drawing.Size(89, 17)
        Me._Label1_36.TabIndex = 72
        Me._Label1_36.Text = "DiamFori/Asole"
        '
        '_Label1_34
        '
        Me._Label1_34.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_34.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_34.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Add(34, Me._Label1_34)
        Me._Label1_34.Location = New System.Drawing.Point(7, 365)
        Me._Label1_34.Name = "_Label1_34"
        Me._Label1_34.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_34.Size = New System.Drawing.Size(89, 17)
        Me._Label1_34.TabIndex = 71
        Me._Label1_34.Text = "DisrForiCor"
        '
        '_Label1_33
        '
        Me._Label1_33.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_33.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_33.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Add(33, Me._Label1_33)
        Me._Label1_33.Location = New System.Drawing.Point(7, 345)
        Me._Label1_33.Name = "_Label1_33"
        Me._Label1_33.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_33.Size = New System.Drawing.Size(89, 17)
        Me._Label1_33.TabIndex = 70
        Me._Label1_33.Text = "DistForiLun"
        '
        '_Label1_31
        '
        Me._Label1_31.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_31.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_31.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Add(31, Me._Label1_31)
        Me._Label1_31.Location = New System.Drawing.Point(7, 293)
        Me._Label1_31.Name = "_Label1_31"
        Me._Label1_31.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_31.Size = New System.Drawing.Size(89, 17)
        Me._Label1_31.TabIndex = 69
        Me._Label1_31.Text = "Diametro Attuale"
        '
        '_Label1_32
        '
        Me._Label1_32.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_32.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_32.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Add(32, Me._Label1_32)
        Me._Label1_32.Location = New System.Drawing.Point(168, 326)
        Me._Label1_32.Name = "_Label1_32"
        Me._Label1_32.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_32.Size = New System.Drawing.Size(89, 17)
        Me._Label1_32.TabIndex = 68
        Me._Label1_32.Text = "H totale sella"
        '
        '_Label1_30
        '
        Me._Label1_30.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_30.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_30.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Add(30, Me._Label1_30)
        Me._Label1_30.Location = New System.Drawing.Point(168, 293)
        Me._Label1_30.Name = "_Label1_30"
        Me._Label1_30.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_30.Size = New System.Drawing.Size(104, 17)
        Me._Label1_30.TabIndex = 67
        Me._Label1_30.Text = "LungAsola (CL/CL)"
        '
        '_Label1_29
        '
        Me._Label1_29.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_29.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_29.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Add(29, Me._Label1_29)
        Me._Label1_29.Location = New System.Drawing.Point(168, 258)
        Me._Label1_29.Name = "_Label1_29"
        Me._Label1_29.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_29.Size = New System.Drawing.Size(89, 17)
        Me._Label1_29.TabIndex = 66
        Me._Label1_29.Text = "SorAngSel"
        '
        '_Label1_28
        '
        Me._Label1_28.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_28.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_28.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Add(28, Me._Label1_28)
        Me._Label1_28.Location = New System.Drawing.Point(168, 240)
        Me._Label1_28.Name = "_Label1_28"
        Me._Label1_28.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_28.Size = New System.Drawing.Size(89, 17)
        Me._Label1_28.TabIndex = 65
        Me._Label1_28.Text = "Fianchi dritti"
        '
        '_Label1_27
        '
        Me._Label1_27.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_27.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_27.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Add(27, Me._Label1_27)
        Me._Label1_27.Location = New System.Drawing.Point(168, 228)
        Me._Label1_27.Name = "_Label1_27"
        Me._Label1_27.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_27.Size = New System.Drawing.Size(89, 17)
        Me._Label1_27.TabIndex = 64
        Me._Label1_27.Text = "TipoRinf"
        '
        '_Label1_26
        '
        Me._Label1_26.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_26.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_26.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Add(26, Me._Label1_26)
        Me._Label1_26.Location = New System.Drawing.Point(168, 210)
        Me._Label1_26.Name = "_Label1_26"
        Me._Label1_26.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_26.Size = New System.Drawing.Size(89, 17)
        Me._Label1_26.TabIndex = 63
        Me._Label1_26.Text = "DiamFori/Asole"
        '
        '_Label1_25
        '
        Me._Label1_25.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_25.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_25.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Add(25, Me._Label1_25)
        Me._Label1_25.Location = New System.Drawing.Point(168, 192)
        Me._Label1_25.Name = "_Label1_25"
        Me._Label1_25.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_25.Size = New System.Drawing.Size(89, 17)
        Me._Label1_25.TabIndex = 62
        Me._Label1_25.Text = "NumBolts (totali)"
        '
        '_Label1_24
        '
        Me._Label1_24.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_24.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_24.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Add(24, Me._Label1_24)
        Me._Label1_24.Location = New System.Drawing.Point(168, 174)
        Me._Label1_24.Name = "_Label1_24"
        Me._Label1_24.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_24.Size = New System.Drawing.Size(89, 17)
        Me._Label1_24.TabIndex = 61
        Me._Label1_24.Text = "SizeBolts"
        '
        '_Label1_23
        '
        Me._Label1_23.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_23.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_23.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Add(23, Me._Label1_23)
        Me._Label1_23.Location = New System.Drawing.Point(168, 156)
        Me._Label1_23.Name = "_Label1_23"
        Me._Label1_23.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_23.Size = New System.Drawing.Size(89, 17)
        Me._Label1_23.TabIndex = 60
        Me._Label1_23.Text = "Peso"
        '
        '_Label1_22
        '
        Me._Label1_22.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_22.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_22.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Add(22, Me._Label1_22)
        Me._Label1_22.Location = New System.Drawing.Point(168, 132)
        Me._Label1_22.Name = "_Label1_22"
        Me._Label1_22.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_22.Size = New System.Drawing.Size(89, 17)
        Me._Label1_22.TabIndex = 59
        Me._Label1_22.Text = "SpessBase"
        '
        '_Label1_21
        '
        Me._Label1_21.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_21.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_21.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Add(21, Me._Label1_21)
        Me._Label1_21.Location = New System.Drawing.Point(168, 114)
        Me._Label1_21.Name = "_Label1_21"
        Me._Label1_21.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_21.Size = New System.Drawing.Size(89, 17)
        Me._Label1_21.TabIndex = 58
        Me._Label1_21.Text = "SpessRibs"
        '
        '_Label1_20
        '
        Me._Label1_20.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_20.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_20.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Add(20, Me._Label1_20)
        Me._Label1_20.Location = New System.Drawing.Point(168, 96)
        Me._Label1_20.Name = "_Label1_20"
        Me._Label1_20.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_20.Size = New System.Drawing.Size(89, 17)
        Me._Label1_20.TabIndex = 57
        Me._Label1_20.Text = "SpessPezza"
        '
        '_Label1_19
        '
        Me._Label1_19.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_19.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_19.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Add(19, Me._Label1_19)
        Me._Label1_19.Location = New System.Drawing.Point(168, 78)
        Me._Label1_19.Name = "_Label1_19"
        Me._Label1_19.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_19.Size = New System.Drawing.Size(89, 17)
        Me._Label1_19.TabIndex = 56
        Me._Label1_19.Text = "SpessCost"
        '
        '_Label1_18
        '
        Me._Label1_18.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_18.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_18.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Add(18, Me._Label1_18)
        Me._Label1_18.Location = New System.Drawing.Point(168, 60)
        Me._Label1_18.Name = "_Label1_18"
        Me._Label1_18.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_18.Size = New System.Drawing.Size(89, 17)
        Me._Label1_18.TabIndex = 55
        Me._Label1_18.Text = "DistRib3"
        '
        '_Label1_17
        '
        Me._Label1_17.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_17.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_17.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Add(17, Me._Label1_17)
        Me._Label1_17.Location = New System.Drawing.Point(168, 42)
        Me._Label1_17.Name = "_Label1_17"
        Me._Label1_17.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_17.Size = New System.Drawing.Size(89, 17)
        Me._Label1_17.TabIndex = 54
        Me._Label1_17.Text = "DistRib2"
        '
        '_Label1_16
        '
        Me._Label1_16.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_16.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_16.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Add(16, Me._Label1_16)
        Me._Label1_16.Location = New System.Drawing.Point(168, 24)
        Me._Label1_16.Name = "_Label1_16"
        Me._Label1_16.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_16.Size = New System.Drawing.Size(89, 17)
        Me._Label1_16.TabIndex = 53
        Me._Label1_16.Text = "DistRib1"
        '
        '_Label1_15
        '
        Me._Label1_15.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_15.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_15.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Add(15, Me._Label1_15)
        Me._Label1_15.Location = New System.Drawing.Point(168, 8)
        Me._Label1_15.Name = "_Label1_15"
        Me._Label1_15.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_15.Size = New System.Drawing.Size(105, 17)
        Me._Label1_15.TabIndex = 52
        Me._Label1_15.Text = "NumRibs (un lato)"
        '
        '_Label1_13
        '
        Me._Label1_13.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_13.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Add(13, Me._Label1_13)
        Me._Label1_13.Location = New System.Drawing.Point(7, 246)
        Me._Label1_13.Name = "_Label1_13"
        Me._Label1_13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_13.Size = New System.Drawing.Size(89, 17)
        Me._Label1_13.TabIndex = 51
        Me._Label1_13.Text = "DistForiCor (G)"
        '
        '_Label1_12
        '
        Me._Label1_12.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_12.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Add(12, Me._Label1_12)
        Me._Label1_12.Location = New System.Drawing.Point(7, 228)
        Me._Label1_12.Name = "_Label1_12"
        Me._Label1_12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_12.Size = New System.Drawing.Size(89, 17)
        Me._Label1_12.TabIndex = 50
        Me._Label1_12.Text = "DistForiLun (C)"
        '
        '_Label1_11
        '
        Me._Label1_11.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_11.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Add(11, Me._Label1_11)
        Me._Label1_11.Location = New System.Drawing.Point(7, 210)
        Me._Label1_11.Name = "_Label1_11"
        Me._Label1_11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_11.Size = New System.Drawing.Size(89, 17)
        Me._Label1_11.TabIndex = 49
        Me._Label1_11.Text = "LarghPezza (F')"
        '
        '_Label1_10
        '
        Me._Label1_10.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_10.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Add(10, Me._Label1_10)
        Me._Label1_10.Location = New System.Drawing.Point(7, 192)
        Me._Label1_10.Name = "_Label1_10"
        Me._Label1_10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_10.Size = New System.Drawing.Size(97, 17)
        Me._Label1_10.TabIndex = 48
        Me._Label1_10.Text = "LarghRinfShell (F)"
        '
        '_Label1_9
        '
        Me._Label1_9.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_9.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Add(9, Me._Label1_9)
        Me._Label1_9.Location = New System.Drawing.Point(7, 174)
        Me._Label1_9.Name = "_Label1_9"
        Me._Label1_9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_9.Size = New System.Drawing.Size(105, 17)
        Me._Label1_9.TabIndex = 47
        Me._Label1_9.Text = "LarghRinfBase (E')"
        '
        '_Label1_8
        '
        Me._Label1_8.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_8.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Add(8, Me._Label1_8)
        Me._Label1_8.Location = New System.Drawing.Point(7, 156)
        Me._Label1_8.Name = "_Label1_8"
        Me._Label1_8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_8.Size = New System.Drawing.Size(89, 17)
        Me._Label1_8.TabIndex = 46
        Me._Label1_8.Text = "LarghBase (E)"
        '
        '_Label1_7
        '
        Me._Label1_7.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_7.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Add(7, Me._Label1_7)
        Me._Label1_7.Location = New System.Drawing.Point(7, 138)
        Me._Label1_7.Name = "_Label1_7"
        Me._Label1_7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_7.Size = New System.Drawing.Size(89, 17)
        Me._Label1_7.TabIndex = 45
        Me._Label1_7.Text = "LunghBase"
        '
        '_Label1_6
        '
        Me._Label1_6.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_6.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Add(6, Me._Label1_6)
        Me._Label1_6.Location = New System.Drawing.Point(7, 120)
        Me._Label1_6.Name = "_Label1_6"
        Me._Label1_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_6.Size = New System.Drawing.Size(97, 17)
        Me._Label1_6.TabIndex = 44
        Me._Label1_6.Text = "LunghCostola (B)"
        '
        '_Label1_5
        '
        Me._Label1_5.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_5.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Add(5, Me._Label1_5)
        Me._Label1_5.Location = New System.Drawing.Point(7, 102)
        Me._Label1_5.Name = "_Label1_5"
        Me._Label1_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_5.Size = New System.Drawing.Size(89, 17)
        Me._Label1_5.TabIndex = 43
        Me._Label1_5.Text = "Altezza (A)"
        '
        '_Label1_14
        '
        Me._Label1_14.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_14.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_14.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Add(14, Me._Label1_14)
        Me._Label1_14.Location = New System.Drawing.Point(7, 264)
        Me._Label1_14.Name = "_Label1_14"
        Me._Label1_14.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_14.Size = New System.Drawing.Size(89, 17)
        Me._Label1_14.TabIndex = 42
        Me._Label1_14.Text = "Diametro"
        '
        '_Label1_4
        '
        Me._Label1_4.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Add(4, Me._Label1_4)
        Me._Label1_4.Location = New System.Drawing.Point(7, 84)
        Me._Label1_4.Name = "_Label1_4"
        Me._Label1_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_4.Size = New System.Drawing.Size(89, 17)
        Me._Label1_4.TabIndex = 41
        Me._Label1_4.Text = "DN"
        '
        '_Label1_3
        '
        Me._Label1_3.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Add(3, Me._Label1_3)
        Me._Label1_3.Location = New System.Drawing.Point(7, 66)
        Me._Label1_3.Name = "_Label1_3"
        Me._Label1_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_3.Size = New System.Drawing.Size(89, 17)
        Me._Label1_3.TabIndex = 40
        Me._Label1_3.Text = "SemplicePortante"
        '
        '_Label1_2
        '
        Me._Label1_2.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Add(2, Me._Label1_2)
        Me._Label1_2.Location = New System.Drawing.Point(7, 48)
        Me._Label1_2.Name = "_Label1_2"
        Me._Label1_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_2.Size = New System.Drawing.Size(89, 17)
        Me._Label1_2.TabIndex = 39
        Me._Label1_2.Text = "Serie"
        '
        '_Label1_1
        '
        Me._Label1_1.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Add(1, Me._Label1_1)
        Me._Label1_1.Location = New System.Drawing.Point(7, 30)
        Me._Label1_1.Name = "_Label1_1"
        Me._Label1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_1.Size = New System.Drawing.Size(89, 17)
        Me._Label1_1.TabIndex = 38
        Me._Label1_1.Text = "Standard"
        '
        '_Label1_0
        '
        Me._Label1_0.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Add(0, Me._Label1_0)
        Me._Label1_0.Location = New System.Drawing.Point(7, 8)
        Me._Label1_0.Name = "_Label1_0"
        Me._Label1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_0.Size = New System.Drawing.Size(89, 17)
        Me._Label1_0.TabIndex = 37
        Me._Label1_0.Text = "ID"
        '
        'DbaseSelle
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(192, Byte))
        Me.ClientSize = New System.Drawing.Size(439, 570)
        Me.Controls.Add(Me.Check1)
        Me.Controls.Add(Me.cmdRibs)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.Frame2)
        Me.Controls.Add(Me.Frame1)
        Me.Controls.Add(Me.Command4)
        Me.Controls.Add(Me._Text1_36)
        Me.Controls.Add(Me._Text1_35)
        Me.Controls.Add(Me._Text1_34)
        Me.Controls.Add(Me._Text1_33)
        Me.Controls.Add(Me._Text1_31)
        Me.Controls.Add(Me._Text1_32)
        Me.Controls.Add(Me._Text1_30)
        Me.Controls.Add(Me._Text1_29)
        Me.Controls.Add(Me._Text1_28)
        Me.Controls.Add(Me._Text1_27)
        Me.Controls.Add(Me._Text1_26)
        Me.Controls.Add(Me._Text1_25)
        Me.Controls.Add(Me._Text1_24)
        Me.Controls.Add(Me._Text1_23)
        Me.Controls.Add(Me._Text1_22)
        Me.Controls.Add(Me._Text1_21)
        Me.Controls.Add(Me._Text1_20)
        Me.Controls.Add(Me._Text1_19)
        Me.Controls.Add(Me._Text1_18)
        Me.Controls.Add(Me._Text1_17)
        Me.Controls.Add(Me._Text1_16)
        Me.Controls.Add(Me._Text1_15)
        Me.Controls.Add(Me._Text1_13)
        Me.Controls.Add(Me._Text1_12)
        Me.Controls.Add(Me._Text1_11)
        Me.Controls.Add(Me._Text1_10)
        Me.Controls.Add(Me._Text1_9)
        Me.Controls.Add(Me._Text1_8)
        Me.Controls.Add(Me._Text1_7)
        Me.Controls.Add(Me._Text1_6)
        Me.Controls.Add(Me._Text1_5)
        Me.Controls.Add(Me._Text1_14)
        Me.Controls.Add(Me._Text1_4)
        Me.Controls.Add(Me._Text1_3)
        Me.Controls.Add(Me._Text1_2)
        Me.Controls.Add(Me._Text1_1)
        Me.Controls.Add(Me._Text1_0)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me._Label1_35)
        Me.Controls.Add(Me._Label1_36)
        Me.Controls.Add(Me._Label1_34)
        Me.Controls.Add(Me._Label1_33)
        Me.Controls.Add(Me._Label1_31)
        Me.Controls.Add(Me._Label1_32)
        Me.Controls.Add(Me._Label1_30)
        Me.Controls.Add(Me._Label1_29)
        Me.Controls.Add(Me._Label1_28)
        Me.Controls.Add(Me._Label1_27)
        Me.Controls.Add(Me._Label1_26)
        Me.Controls.Add(Me._Label1_25)
        Me.Controls.Add(Me._Label1_24)
        Me.Controls.Add(Me._Label1_23)
        Me.Controls.Add(Me._Label1_22)
        Me.Controls.Add(Me._Label1_21)
        Me.Controls.Add(Me._Label1_20)
        Me.Controls.Add(Me._Label1_19)
        Me.Controls.Add(Me._Label1_18)
        Me.Controls.Add(Me._Label1_17)
        Me.Controls.Add(Me._Label1_16)
        Me.Controls.Add(Me._Label1_15)
        Me.Controls.Add(Me._Label1_13)
        Me.Controls.Add(Me._Label1_12)
        Me.Controls.Add(Me._Label1_11)
        Me.Controls.Add(Me._Label1_10)
        Me.Controls.Add(Me._Label1_9)
        Me.Controls.Add(Me._Label1_8)
        Me.Controls.Add(Me._Label1_7)
        Me.Controls.Add(Me._Label1_6)
        Me.Controls.Add(Me._Label1_5)
        Me.Controls.Add(Me._Label1_14)
        Me.Controls.Add(Me._Label1_4)
        Me.Controls.Add(Me._Label1_3)
        Me.Controls.Add(Me._Label1_2)
        Me.Controls.Add(Me._Label1_1)
        Me.Controls.Add(Me._Label1_0)
        Me.Controls.Add(Me.Shape1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DbaseSelle"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "DataBaseSelle"
        Me.Frame2.ResumeLayout(False)
        Me.Frame1.ResumeLayout(False)



        Me.ResumeLayout(False)

    End Sub
#End Region
#Region "Supporto aggiornamento "
    Private Shared m_vb6FormDefInstance As DbaseSelle
    Private Shared m_InitializingDefInstance As Boolean
    Public Shared Property DefInstance() As DbaseSelle
        Get
            If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
                m_InitializingDefInstance = True
                m_vb6FormDefInstance = New DbaseSelle
                m_InitializingDefInstance = False
            End If
            DefInstance = m_vb6FormDefInstance
        End Get
        Set(ByVal Value As DbaseSelle)
            m_vb6FormDefInstance = Value
        End Set
    End Property
#End Region
    Public dBase As Boolean
    Private SalvaDb As Boolean
    Private RecSelle1, RecSelle, Std As DataTable
    Private j, i, Corrente, Quanti As Short
    Private Cambiata, Storta As Boolean
    Private Diametro As Single
    Private sempor, Scelta, CI As String
    Private dvSelle1 As DataView
    Private Inizializzando As Boolean
    Private Sub Check1_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Check1.CheckStateChanged
        If Inizializzando Then Exit Sub
        CType(Membro, Sella).Storta = Check1.CheckState = 0
    End Sub

    Private Sub cmdRibs_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdRibs.Click
        If Not dBase Then carica()
        FormRibs.DefInstance.ShowDialog()
    End Sub
    Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
        'AllDb
        'Data1.Refresh()
        'Data1.Recordset.MoveLast()
        'Data1.Recordset.MoveFirst()
        'Quanti = Data1.Recordset.RecordCount
        'Data1.Text = Quanti & " records"
    End Sub
    Private Sub Command2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command2.Click
        'NuovaRic
        Close()
    End Sub
    Private Sub Command4_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command4.Click
        If Quanti <= 0 Then Exit Sub
        If sempor <> Text1(3).Text Or Text1(28).Text = "S" And Storta = False Or Text1(28).Text = "D" And Storta = True Then
            MsgBox("Il tipo sella scelto e' diverso da quello del DB : usiamo DB!")
            cambio()
            Exit Sub
        End If
        CType(Membro, Sella).RegistraTutto()
        Nfori(1) = Val(Text1(25).Text)
        Nfori(2) = Val(Text1(35).Text)
        'If Nfori(1) \ 2 > 3 Or Nfori(2) \ 2 > 3 Then
        FormRibs.DefInstance.ShowDialog()
        Me.Close()
    End Sub
    Private Sub Command3_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command3.Click
        'SoloLettura
        SalvaDb = Not SalvaDb
        If SalvaDb Then
            Command3.Text = "LETTURA E SCRITTURA"
            Command3.BackColor = System.Drawing.ColorTranslator.FromOle(&HFF)
        Else
            Command3.BackColor = System.Drawing.ColorTranslator.FromOle(&H8000000F)
            Command3.Text = "SOLO LETTURA"
        End If
    End Sub
    'UPGRADE_WARNING: Form evento DbaseSelle.Activate presenta un nuovo comportamento. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup2065"'
    Private Sub DbaseSelle_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
        Dim DiaMin, DiaMax, distmin As Single
        Dim Pos As Integer
        Dim dist As Single
        'Me.Move 100, 600
        With CType(Membro, Sella)
            If .CI Then CI = "C" Else CI = "I"
            If .sempor Then sempor = "SEM" Else sempor = "POR"
            If Diametro = 0 Then Diametro = .Diametro
            Text1(31).Text = CStr(Diametro)
            DiaMin = Diametro - 50 : DiaMax = Diametro + 50
            If FormDati.Combo1.SelectedIndex = 0 Then
                Scelta = "Tiporinf = '" & CI & "'" & " and SemplicePortante = '" & sempor & "'"
            Else
                Scelta = "Tiporinf = '" & CI & "'" & " and SemplicePortante = '" & sempor & "'" & " and Standard = " & FormDati.Combo1.SelectedIndex
            End If
        End With
        If Not dBase Then
            carica()
            Quanti = 1
            cambio()
            Exit Sub
        End If
        Dim cString As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & Inizio.Archdir & "\Selle.mdb" & ";Persist Security Info=False"
        Dim cnSelle As SqlConnection = New SqlConnection(cString)
        Dim cmd As SqlDataAdapter = New SqlDataAdapter("SELECT * FROM Catalogo WHERE listindex = " & Str(Math.Max(0, FormDati.Combo1.SelectedIndex - 1)), cnSelle)
        RecSelle = New DataTable
        cmd.Fill(RecSelle)
        Dim r As DataRow
        r = RecSelle.Rows(0)
        Dim Tabella As String = r("Tabella")
        cmd.SelectCommand = New SqlCommand("SELECT * FROM " + Tabella, cnSelle)
        cmd.Fill(RecSelle)
        'db = Funzioni.MyWorkspace.OpenDatabase(Monitor.Motore.Inizio.Archdir & "\Selle.mdb", False, True)
        '        RecSelle = db.OpenRecordset("SELECT * FROM Catalogo WHERE listindex = " & Str(Max6(0, FormDati.Combo1.SelectedIndex - 1)))
        'RecSelle = db.OpenRecordset("SELECT * FROM " + RecSelle.Fields("Tabella").Value)
        cmd.SelectCommand = New SqlCommand("SELECT * FROM catalogo", cnSelle)
        cmd.Fill(Std)
        'Std = db.OpenRecordset("SELECT * FROM catalogo")
        Dim dvSelle As DataView = New DataView(RecSelle)
        dvSelle.RowFilter = Scelta
        'RecSelle.Filter = Scelta
        'RecSelle = RecSelle.OpenRecordset()
        dvSelle1 = New DataView(RecSelle)
        dvSelle1.RowFilter = Scelta
        dvSelle1.RowFilter = "Diametro >= " & DiaMin & " and Diametro <= " & DiaMax
        'RecSelle.Filter = "Diametro >= " & DiaMin & " and Diametro <= " & DiaMax
        'RecSelle1 = RecSelle.OpenRecordset()
        If dvSelle1.Count = 0 Then
            If dvSelle.Count = 0 Then
                MsgBox("Problema")
                Exit Sub
            Else
                distmin = clsTrigon.Infinito
                Dim drv As DataRowView
                For Each drv In dvSelle
                    dist = System.Math.Abs(Diametro - CSng(drv("Diametro")))
                    If dist < distmin Then
                        distmin = dist
                        Pos = CInt(drv("iD"))
                    End If
                Next
                Scelta = "ID=" & Str(Pos)
                dvSelle1 = New DataView(RecSelle)
                dvSelle1.RowFilter = Scelta
            End If
        End If
        'If RecSelle1.RecordCount = 0 Then
        'If RecSelle.RecordCount = 0 Then
        '    MsgBox("Problema")
        '    Exit Sub
        'Else
        '    distmin = clsTrigon.Infinito
        '    Do Until RecSelle.EOF
        'dist = System.Math.Abs(Diametro - RecSelle.Fields("Diametro").Value)
        'If dist < distmin Then
        'distmin = dist
        'Pos = RecSelle.Fields("iD").Value
        'End If
        'RecSelle.MoveNext()
        '    Loop
        'Scelta = "ID=" & Str(Pos)
        'RecSelle.Filter = Scelta
        'RecSelle1 = RecSelle.OpenRecordset()
        'End If
        'End If
        '        Data1.Recordset = RecSelle1
        'UPGRADE_ISSUE: Data proprietà Data1.Recordset non è stato aggiornato. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup2069"'
        Quanti = dvSelle1.Count
        'Quanti = Data1.Recordset.RecordCount
        'If Quanti = 0 Then GoTo trovati
        'Data1.Recordset.MoveLast()
        'Quanti = Data1.Recordset.RecordCount
        'Data1.Recordset.MoveFirst()
        'trovati:
        'Quanti = Data1.Recordset.RecordCount
        Corrente = 0 : If Quanti = 0 Then Corrente = -1
        txtData.Text = Str(Corrente + 1) + " di" + Str(Quanti) + " records"
        'Data1.Text = Quanti & " records"
        'cambio
    End Sub


    Private Sub DbaseSelle_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Dim DiaMax, DiaMin As Integer
        Me.SetBounds(GlobalRoutines.TwipsToPixelsX(100), GlobalRoutines.TwipsToPixelsY(600), 0, 0, System.Windows.Forms.BoundsSpecified.X Or System.Windows.Forms.BoundsSpecified.Y)
        Frame2.Visible = dBase
        Text1(0).Visible = dBase
        Label1(0).Visible = dBase
        Text1(1).Visible = dBase
        Label1(1).Visible = dBase
        Text1(4).Visible = dBase
        Label1(4).Visible = dBase
        Text1(11).Visible = dBase
        Label1(11).Visible = dBase
        Text1(12).Visible = dBase
        Label1(12).Visible = dBase
        Text1(13).Visible = dBase
        Label1(13).Visible = dBase
        Text1(14).Visible = dBase
        Label1(14).Visible = dBase
        Text1(16).Visible = dBase
        Label1(16).Visible = dBase
        Text1(17).Visible = dBase
        Label1(17).Visible = dBase
        Text1(18).Visible = dBase
        Label1(18).Visible = dBase
        Text1(23).Visible = dBase
        Label1(23).Visible = dBase
        Text1(24).Visible = dBase
        Label1(24).Visible = dBase
        Text1(25).Visible = dBase
        Label1(25).Visible = dBase
        Text1(26).Visible = dBase
        Label1(26).Visible = dBase
        Text1(28).Visible = dBase
        Check1.Visible = Not dBase
        Text1(30).Visible = dBase
        Label1(30).Visible = dBase
        Text1(31).Visible = dBase
        Label1(31).Visible = dBase
        Text1(33).Visible = dBase
        Label1(33).Visible = dBase
        Text1(34).Visible = dBase
        Label1(34).Visible = dBase
        Text1(35).Visible = dBase
        Label1(35).Visible = dBase
        Text1(36).Visible = dBase
        Label1(36).Visible = dBase
        DbaseFatto = False
        Quanti = 0
        Text1(0).Top = GlobalRoutines.TwipsToPixelsY(120)
        Text1(0).Left = GlobalRoutines.TwipsToPixelsX(1600)
        Text1(0).Width = GlobalRoutines.TwipsToPixelsX(800)
        Text1(0).Height = GlobalRoutines.TwipsToPixelsY(255)
        Label1(0).Top = GlobalRoutines.TwipsToPixelsY(120)
        Label1(0).Left = GlobalRoutines.TwipsToPixelsX(100)
        Label1(0).Width = GlobalRoutines.TwipsToPixelsX(1350)
        Label1(0).Height = GlobalRoutines.TwipsToPixelsY(255)
        DiaMax = GlobalRoutines.TwipsToPixelsY(50)
        For j = 1 To 14
            Text1(j).Top = Text1(0).Top + Text1(0).Height * j '+ DiaMax
            Text1(j).Left = (Text1(0).Left)
            Text1(j).Width = (Text1(0).Width)
            Text1(j).Height = (Text1(0).Height)
            Label1(j).Top = (Text1(j).Top)
            Label1(j).Left = (Label1(0).Left)
            Label1(j).Width = (Label1(0).Width)
            Label1(j).Height = (Label1(0).Height)
        Next
        DiaMin = Text1(0).Left + Text1(0).Width + GlobalRoutines.TwipsToPixelsX(200)
        i = DiaMin + Text1(0).Left - Label1(0).Left
        For j = 15 To 30
            Text1(j).Top = Text1(0).Top + Text1(0).Height * (j - 15) '- DiaMax * (j - 15 > 0)
            Text1(j).Left = (i)
            Text1(j).Width = (Text1(0).Width)
            Text1(j).Height = (Text1(0).Height)
            Label1(j).Top = (Text1(j).Top)
            Label1(j).Left = (DiaMin)
            Label1(j).Width = (Label1(0).Width)
            Label1(j).Height = (Label1(0).Height)
        Next
        Check1.Top = Text1(28).Top
        Check1.Left = Text1(28).Left
    End Sub
    Private Sub cambio()
        If Quanti <= 0 Then Exit Sub
        Dim Vero As Boolean
        If Text1(3).Text = "POR" Then Vero = True Else Vero = False
        For i = 32 To 36
            Text1(i).Visible = Vero
            Label1(i).Visible = Vero
        Next
        Label2.Visible = Vero
        Shape1.Visible = Vero
        If Not dBase Then Exit Sub
        If Vero Then
            Text1(32).Text = Str(Val(Text1(5).Text) * 2)
            Text1(33).Text = Text1(12).Text
            Text1(34).Text = Text1(13).Text
            Text1(35).Text = Text1(25).Text
            Text1(36).Text = Text1(26).Text
        End If
        Storta = False
        If Text1(28).Text = "S" Then Storta = True
        Dim r As DataRow
        Dim v As DataRowView
        For i = 0 To Std.Rows.Count - 1
            r = Std.Rows(i)
            v = dvSelle1.Item(Corrente)
            If CInt(r("ID")) = CInt(v("Standard")) Then
                Text1(1).Text = CStr(r("Standard"))
                Exit For
            End If
        Next
        'Std.MoveFirst()
        'Do While Not Std.EOF
        'If Std.Fields("iD").Value = Data1.Recordset.Fields("Standard").Value Then
        '    Text1(1).Text = Std.Fields("Standard").Value
        '    Exit Do
        'End If
        'Std.MoveNext()
        'Loop
    End Sub
    Private Sub DbaseSelle_Closed(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Closed
        RecSelle.Dispose()
        RecSelle1.Dispose()
        Std.Dispose()
    End Sub
    Private Sub carica()
        Const StrForm As String = "####"
        With CType(Membro, Sella)
            Text1(1).Text = .StandardStr
            Text1(2).Text = Str(.Serie)
            If .sempor Then Text1(3).Text = "SEM" Else Text1(3).Text = "POR"
            Text1(5).Text = Microsoft.VisualBasic.Strings.Format(.Altezza, StrForm)
            Text1(6).Text = Microsoft.VisualBasic.Strings.Format(.Larghezza, StrForm)
            Text1(7).Text = Microsoft.VisualBasic.Strings.Format(.LungBase, StrForm)
            Text1(8).Text = Microsoft.VisualBasic.Strings.Format(.LargBase, StrForm)
            Text1(9).Text = Microsoft.VisualBasic.Strings.Format(.LargRinfBase, StrForm)
            Text1(10).Text = Microsoft.VisualBasic.Strings.Format(.LargRinfShell, StrForm)
            Text1(15).Text = Str(.nribs)
            Text1(16).Text = Microsoft.VisualBasic.Strings.Format(.DistRib1)
            Text1(17).Text = Microsoft.VisualBasic.Strings.Format(.DistRib2)
            Text1(18).Text = Microsoft.VisualBasic.Strings.Format(.DistRib3)
            Text1(19).Text = Microsoft.VisualBasic.Strings.Format(.SpCost, StrForm)
            Text1(20).Text = Microsoft.VisualBasic.Strings.Format(.SpRinf, StrForm)
            Text1(21).Text = Microsoft.VisualBasic.Strings.Format(.SpRibs, StrForm)
            Text1(22).Text = Microsoft.VisualBasic.Strings.Format(.SpesBase, StrForm)
            If .CI Then Text1(27).Text = "C" Else Text1(27).Text = "I"
            Text1(29).Text = Microsoft.VisualBasic.Strings.Format(.SorAngSel, StrForm)
            Text1(32).Text = Microsoft.VisualBasic.Strings.Format(.AltSopra + .Altezza, StrForm)
            If .Storta Then Check1.CheckState = System.Windows.Forms.CheckState.Unchecked Else Check1.CheckState = System.Windows.Forms.CheckState.Checked
        End With
    End Sub
    Private Sub cmdFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFirst.Click
        If Quanti = 0 Then Exit Sub
        Corrente = 0
        txtData.Text = Str(Corrente + 1) + " di" + Str(Quanti) + " records"
        cambio()
    End Sub
    Private Sub cmdPrevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrevious.Click
        If Quanti = 0 Then Exit Sub
        Corrente = Corrente - 1
        If Corrente < 0 Then Corrente = 0
        txtData.Text = Str(Corrente + 1) + " di" + Str(Quanti) + " records"
        cambio()
    End Sub
    Private Sub cmdNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNext.Click
        If Quanti = 0 Then Exit Sub
        Corrente = Corrente + 1
        If Corrente > Quanti - 1 Then Corrente = Quanti - 1
        txtData.Text = Str(Corrente + 1) + " di" + Str(Quanti) + " records"
        cambio()
    End Sub
    Private Sub cmdLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLast.Click
        If Quanti = 0 Then Exit Sub
        Corrente = Quanti - 1
        txtData.Text = Str(Corrente + 1) + " di" + Str(Quanti) + " records"
        cambio()
    End Sub
End Class