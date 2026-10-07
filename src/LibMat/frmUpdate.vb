Option Strict On
Option Explicit On 
Imports System.Data
Imports System.Data.OleDb
Friend Class frmUpdate
    Inherits System.Windows.Forms.Form
#Region "Codice generato dalla finestra di progettazione Windows Form "
    Public Sub New()
        Me.New(True)
    End Sub
    ' Construct controls separately from database initialization for Windows UI checks.
    Friend Sub New(initializeData As Boolean)
        MyBase.New()
        If m_vb6FormDefInstance Is Nothing Then
            If m_InitializingDefInstance Then
                m_vb6FormDefInstance = Me
            Else
                Try
                    'La prima istanza creata per il form di avvio rappresenta l'istanza predefinita.
                    If System.Reflection.Assembly.GetExecutingAssembly.EntryPoint IsNot Nothing AndAlso System.Reflection.Assembly.GetExecutingAssembly.EntryPoint.DeclaringType Is Me.GetType Then
                        m_vb6FormDefInstance = Me
                    End If
                Catch
                End Try
            End If
        End If
        'Chiamata richiesta dalla progettazione Windows Form.
        InitializeComponent()
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
    Public WithEvents cmdEU As System.Windows.Forms.Button
    Public WithEvents cmdNote As System.Windows.Forms.Button
    Public WithEvents _chkScelta_0 As System.Windows.Forms.CheckBox
    Public WithEvents Command2 As System.Windows.Forms.Button
    Public WithEvents _cmdCil_1 As System.Windows.Forms.Button
    Public WithEvents _txtLibmat_1 As System.Windows.Forms.TextBox
    Public WithEvents _cmdCil_0 As System.Windows.Forms.Button
    Public WithEvents _txtLibmat_0 As System.Windows.Forms.TextBox
    Public WithEvents Command1 As System.Windows.Forms.Button
    Public WithEvents _chkScelta_25 As System.Windows.Forms.CheckBox
    Public WithEvents _chkScelta_24 As System.Windows.Forms.CheckBox
    Public WithEvents _chkScelta_23 As System.Windows.Forms.CheckBox
    Public WithEvents _chkScelta_22 As System.Windows.Forms.CheckBox
    Public WithEvents _chkScelta_21 As System.Windows.Forms.CheckBox
    Public WithEvents _chkScelta_8 As System.Windows.Forms.CheckBox
    Public WithEvents _chkScelta_6 As System.Windows.Forms.CheckBox
    Public WithEvents _chkScelta_4 As System.Windows.Forms.CheckBox
    Public WithEvents _chkScelta_7 As System.Windows.Forms.CheckBox
    Public WithEvents _chkScelta_2 As System.Windows.Forms.CheckBox
    Public WithEvents _chkScelta_1 As System.Windows.Forms.CheckBox
    Public WithEvents _Label3_1 As System.Windows.Forms.Label
    Public WithEvents _Label3_0 As System.Windows.Forms.Label
    Public WithEvents _Label2_3 As System.Windows.Forms.Label
    Public WithEvents _Label2_2 As System.Windows.Forms.Label
    Public WithEvents _Label2_1 As System.Windows.Forms.Label
    Public WithEvents _Label2_0 As System.Windows.Forms.Label
    Public WithEvents Label1 As System.Windows.Forms.Label
    Public Label2 As New System.Collections.Generic.Dictionary(Of Integer, Label)
    Public Label3 As New System.Collections.Generic.Dictionary(Of Integer, Label)
    Public chkScelta As New System.Collections.Generic.Dictionary(Of Integer, CheckBox)
    Public cmdCil As New System.Collections.Generic.Dictionary(Of Integer, Button)
    Public txtLibmat As New System.Collections.Generic.Dictionary(Of Integer, TextBox)
    'NOTA: la routine seguente è richiesta dalla progettazione Windows Form.
    'Può essere modificata utilizzando la finestra di progettazione Windows Form.
    'Non modificarla mediante l'editor di codice.
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents CommonDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents txtSource As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents chkRinnovo As System.Windows.Forms.CheckBox
    Friend WithEvents txticod As System.Windows.Forms.TextBox
    Friend WithEvents txti As System.Windows.Forms.TextBox
    Friend WithEvents txtTotal As System.Windows.Forms.TextBox
    Friend WithEvents txtMat As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmUpdate))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmdEU = New System.Windows.Forms.Button
        Me.cmdNote = New System.Windows.Forms.Button
        Me._chkScelta_0 = New System.Windows.Forms.CheckBox
        Me.Command2 = New System.Windows.Forms.Button
        Me._cmdCil_1 = New System.Windows.Forms.Button
        Me._txtLibmat_1 = New System.Windows.Forms.TextBox
        Me._cmdCil_0 = New System.Windows.Forms.Button
        Me._txtLibmat_0 = New System.Windows.Forms.TextBox
        Me.Command1 = New System.Windows.Forms.Button
        Me._chkScelta_25 = New System.Windows.Forms.CheckBox
        Me._chkScelta_24 = New System.Windows.Forms.CheckBox
        Me._chkScelta_23 = New System.Windows.Forms.CheckBox
        Me._chkScelta_22 = New System.Windows.Forms.CheckBox
        Me._chkScelta_21 = New System.Windows.Forms.CheckBox
        Me._chkScelta_8 = New System.Windows.Forms.CheckBox
        Me._chkScelta_6 = New System.Windows.Forms.CheckBox
        Me._chkScelta_4 = New System.Windows.Forms.CheckBox
        Me._chkScelta_7 = New System.Windows.Forms.CheckBox
        Me._chkScelta_2 = New System.Windows.Forms.CheckBox
        Me._chkScelta_1 = New System.Windows.Forms.CheckBox
        Me._Label3_1 = New System.Windows.Forms.Label
        Me._Label3_0 = New System.Windows.Forms.Label
        Me._Label2_3 = New System.Windows.Forms.Label
        Me._Label2_2 = New System.Windows.Forms.Label
        Me._Label2_1 = New System.Windows.Forms.Label
        Me._Label2_0 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.CommonDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.RadioButton1 = New System.Windows.Forms.RadioButton
        Me.RadioButton2 = New System.Windows.Forms.RadioButton
        Me.txtSource = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.chkRinnovo = New System.Windows.Forms.CheckBox
        Me.txticod = New System.Windows.Forms.TextBox
        Me.txti = New System.Windows.Forms.TextBox
        Me.txtTotal = New System.Windows.Forms.TextBox
        Me.txtMat = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'cmdEU
        '
        Me.cmdEU.BackColor = System.Drawing.SystemColors.Control
        Me.cmdEU.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdEU.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdEU.Location = New System.Drawing.Point(168, 336)
        Me.cmdEU.Name = "cmdEU"
        Me.cmdEU.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdEU.Size = New System.Drawing.Size(65, 33)
        Me.cmdEU.TabIndex = 26
        Me.cmdEU.Text = "EU"
        '
        'cmdNote
        '
        Me.cmdNote.BackColor = System.Drawing.SystemColors.Control
        Me.cmdNote.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdNote.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdNote.Location = New System.Drawing.Point(240, 336)
        Me.cmdNote.Name = "cmdNote"
        Me.cmdNote.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdNote.Size = New System.Drawing.Size(65, 33)
        Me.cmdNote.TabIndex = 25
        Me.cmdNote.Text = "Note"
        '
        '_chkScelta_0
        '
        Me._chkScelta_0.BackColor = System.Drawing.SystemColors.Control
        Me._chkScelta_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._chkScelta_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkScelta.Add(0, Me._chkScelta_0)
        Me._chkScelta_0.Location = New System.Drawing.Point(328, 216)
        Me._chkScelta_0.Name = "_chkScelta_0"
        Me._chkScelta_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._chkScelta_0.Size = New System.Drawing.Size(113, 17)
        Me._chkScelta_0.TabIndex = 24
        Me._chkScelta_0.Text = "Note (tutte)"
        '
        'Command2
        '
        Me.Command2.BackColor = System.Drawing.SystemColors.Control
        Me.Command2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command2.Location = New System.Drawing.Point(312, 336)
        Me.Command2.Name = "Command2"
        Me.Command2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command2.Size = New System.Drawing.Size(65, 33)
        Me.Command2.TabIndex = 23
        Me.Command2.Text = "Pulizia"
        '
        '_cmdCil_1
        '
        Me._cmdCil_1.BackColor = System.Drawing.SystemColors.Control
        Me._cmdCil_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdCil_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdCil_1.Image = CType(resources.GetObject("_cmdCil_1.Image"), System.Drawing.Image)
        Me.cmdCil.Add(1, Me._cmdCil_1)
        Me._cmdCil_1.Location = New System.Drawing.Point(440, 272)
        Me._cmdCil_1.Name = "_cmdCil_1"
        Me._cmdCil_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdCil_1.Size = New System.Drawing.Size(20, 20)
        Me._cmdCil_1.TabIndex = 22
        Me._cmdCil_1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        '_txtLibmat_1
        '
        Me._txtLibmat_1.AcceptsReturn = True
        Me._txtLibmat_1.AutoSize = False
        Me._txtLibmat_1.BackColor = System.Drawing.SystemColors.Window
        Me._txtLibmat_1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtLibmat_1.Enabled = False
        Me._txtLibmat_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtLibmat.Add(1, Me._txtLibmat_1)
        Me._txtLibmat_1.Location = New System.Drawing.Point(128, 272)
        Me._txtLibmat_1.MaxLength = 0
        Me._txtLibmat_1.Name = "_txtLibmat_1"
        Me._txtLibmat_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtLibmat_1.Size = New System.Drawing.Size(305, 19)
        Me._txtLibmat_1.TabIndex = 20
        Me._txtLibmat_1.Text = "Text1"
        '
        '_cmdCil_0
        '
        Me._cmdCil_0.BackColor = System.Drawing.SystemColors.Control
        Me._cmdCil_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdCil_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdCil_0.Image = CType(resources.GetObject("_cmdCil_0.Image"), System.Drawing.Image)
        Me.cmdCil.Add(0, Me._cmdCil_0)
        Me._cmdCil_0.Location = New System.Drawing.Point(440, 248)
        Me._cmdCil_0.Name = "_cmdCil_0"
        Me._cmdCil_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdCil_0.Size = New System.Drawing.Size(20, 20)
        Me._cmdCil_0.TabIndex = 19
        Me._cmdCil_0.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        '_txtLibmat_0
        '
        Me._txtLibmat_0.AcceptsReturn = True
        Me._txtLibmat_0.AutoSize = False
        Me._txtLibmat_0.BackColor = System.Drawing.SystemColors.Window
        Me._txtLibmat_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtLibmat_0.Enabled = False
        Me._txtLibmat_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtLibmat.Add(0, Me._txtLibmat_0)
        Me._txtLibmat_0.Location = New System.Drawing.Point(128, 248)
        Me._txtLibmat_0.MaxLength = 0
        Me._txtLibmat_0.Name = "_txtLibmat_0"
        Me._txtLibmat_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtLibmat_0.Size = New System.Drawing.Size(305, 19)
        Me._txtLibmat_0.TabIndex = 17
        Me._txtLibmat_0.Text = "Text1"
        '
        'Command1
        '
        Me.Command1.BackColor = System.Drawing.SystemColors.Control
        Me.Command1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command1.Location = New System.Drawing.Point(392, 336)
        Me.Command1.Name = "Command1"
        Me.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command1.Size = New System.Drawing.Size(65, 33)
        Me.Command1.TabIndex = 16
        Me.Command1.Text = "Esegui"
        '
        '_chkScelta_25
        '
        Me._chkScelta_25.BackColor = System.Drawing.SystemColors.Control
        Me._chkScelta_25.Cursor = System.Windows.Forms.Cursors.Default
        Me._chkScelta_25.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkScelta.Add(25, Me._chkScelta_25)
        Me._chkScelta_25.Location = New System.Drawing.Point(376, 96)
        Me._chkScelta_25.Name = "_chkScelta_25"
        Me._chkScelta_25.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._chkScelta_25.Size = New System.Drawing.Size(73, 17)
        Me._chkScelta_25.TabIndex = 15
        Me._chkScelta_25.Text = "Tutti"
        '
        '_chkScelta_24
        '
        Me._chkScelta_24.BackColor = System.Drawing.SystemColors.Control
        Me._chkScelta_24.Cursor = System.Windows.Forms.Cursors.Default
        Me._chkScelta_24.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkScelta.Add(24, Me._chkScelta_24)
        Me._chkScelta_24.Location = New System.Drawing.Point(280, 96)
        Me._chkScelta_24.Name = "_chkScelta_24"
        Me._chkScelta_24.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._chkScelta_24.Size = New System.Drawing.Size(73, 17)
        Me._chkScelta_24.TabIndex = 14
        Me._chkScelta_24.Text = "Tutti"
        '
        '_chkScelta_23
        '
        Me._chkScelta_23.BackColor = System.Drawing.SystemColors.Control
        Me._chkScelta_23.Cursor = System.Windows.Forms.Cursors.Default
        Me._chkScelta_23.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkScelta.Add(23, Me._chkScelta_23)
        Me._chkScelta_23.Location = New System.Drawing.Point(144, 216)
        Me._chkScelta_23.Name = "_chkScelta_23"
        Me._chkScelta_23.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._chkScelta_23.Size = New System.Drawing.Size(113, 17)
        Me._chkScelta_23.TabIndex = 11
        Me._chkScelta_23.Text = "Bulloneria"
        '
        '_chkScelta_22
        '
        Me._chkScelta_22.BackColor = System.Drawing.SystemColors.Control
        Me._chkScelta_22.Cursor = System.Windows.Forms.Cursors.Default
        Me._chkScelta_22.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkScelta.Add(22, Me._chkScelta_22)
        Me._chkScelta_22.Location = New System.Drawing.Point(144, 120)
        Me._chkScelta_22.Name = "_chkScelta_22"
        Me._chkScelta_22.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._chkScelta_22.Size = New System.Drawing.Size(113, 17)
        Me._chkScelta_22.TabIndex = 10
        Me._chkScelta_22.Text = "metalli non ferrosi"
        '
        '_chkScelta_21
        '
        Me._chkScelta_21.BackColor = System.Drawing.SystemColors.Control
        Me._chkScelta_21.Cursor = System.Windows.Forms.Cursors.Default
        Me._chkScelta_21.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkScelta.Add(21, Me._chkScelta_21)
        Me._chkScelta_21.Location = New System.Drawing.Point(144, 96)
        Me._chkScelta_21.Name = "_chkScelta_21"
        Me._chkScelta_21.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._chkScelta_21.Size = New System.Drawing.Size(120, 17)
        Me._chkScelta_21.TabIndex = 9
        Me._chkScelta_21.Text = "acciai e leghe di Fe"
        '
        '_chkScelta_8
        '
        Me._chkScelta_8.BackColor = System.Drawing.SystemColors.Control
        Me._chkScelta_8.Cursor = System.Windows.Forms.Cursors.Default
        Me._chkScelta_8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkScelta.Add(8, Me._chkScelta_8)
        Me._chkScelta_8.Location = New System.Drawing.Point(8, 216)
        Me._chkScelta_8.Name = "_chkScelta_8"
        Me._chkScelta_8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._chkScelta_8.Size = New System.Drawing.Size(113, 17)
        Me._chkScelta_8.TabIndex = 7
        Me._chkScelta_8.Text = "Bulloneria"
        '
        '_chkScelta_6
        '
        Me._chkScelta_6.BackColor = System.Drawing.SystemColors.Control
        Me._chkScelta_6.Cursor = System.Windows.Forms.Cursors.Default
        Me._chkScelta_6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkScelta.Add(6, Me._chkScelta_6)
        Me._chkScelta_6.Location = New System.Drawing.Point(8, 192)
        Me._chkScelta_6.Name = "_chkScelta_6"
        Me._chkScelta_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._chkScelta_6.Size = New System.Drawing.Size(113, 17)
        Me._chkScelta_6.TabIndex = 6
        Me._chkScelta_6.Text = "Pipes"
        '
        '_chkScelta_4
        '
        Me._chkScelta_4.BackColor = System.Drawing.SystemColors.Control
        Me._chkScelta_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._chkScelta_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkScelta.Add(4, Me._chkScelta_4)
        Me._chkScelta_4.Location = New System.Drawing.Point(8, 168)
        Me._chkScelta_4.Name = "_chkScelta_4"
        Me._chkScelta_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._chkScelta_4.Size = New System.Drawing.Size(113, 17)
        Me._chkScelta_4.TabIndex = 5
        Me._chkScelta_4.Text = "Tubi scambiatori"
        '
        '_chkScelta_7
        '
        Me._chkScelta_7.BackColor = System.Drawing.SystemColors.Control
        Me._chkScelta_7.Cursor = System.Windows.Forms.Cursors.Default
        Me._chkScelta_7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkScelta.Add(7, Me._chkScelta_7)
        Me._chkScelta_7.Location = New System.Drawing.Point(8, 144)
        Me._chkScelta_7.Name = "_chkScelta_7"
        Me._chkScelta_7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._chkScelta_7.Size = New System.Drawing.Size(113, 17)
        Me._chkScelta_7.TabIndex = 4
        Me._chkScelta_7.Text = "Forgiati"
        '
        '_chkScelta_2
        '
        Me._chkScelta_2.BackColor = System.Drawing.SystemColors.Control
        Me._chkScelta_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._chkScelta_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkScelta.Add(2, Me._chkScelta_2)
        Me._chkScelta_2.Location = New System.Drawing.Point(8, 120)
        Me._chkScelta_2.Name = "_chkScelta_2"
        Me._chkScelta_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._chkScelta_2.Size = New System.Drawing.Size(113, 17)
        Me._chkScelta_2.TabIndex = 3
        Me._chkScelta_2.Text = "Lam. SS e speciali"
        '
        '_chkScelta_1
        '
        Me._chkScelta_1.BackColor = System.Drawing.SystemColors.Control
        Me._chkScelta_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._chkScelta_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkScelta.Add(1, Me._chkScelta_1)
        Me._chkScelta_1.Location = New System.Drawing.Point(8, 96)
        Me._chkScelta_1.Name = "_chkScelta_1"
        Me._chkScelta_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._chkScelta_1.Size = New System.Drawing.Size(113, 17)
        Me._chkScelta_1.TabIndex = 2
        Me._chkScelta_1.Text = "Lamiere acciai C"
        '
        '_Label3_1
        '
        Me._Label3_1.BackColor = System.Drawing.SystemColors.Control
        Me._Label3_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label3_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Add(1, Me._Label3_1)
        Me._Label3_1.Location = New System.Drawing.Point(8, 272)
        Me._Label3_1.Name = "_Label3_1"
        Me._Label3_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label3_1.Size = New System.Drawing.Size(113, 17)
        Me._Label3_1.TabIndex = 21
        Me._Label3_1.Text = "DB di aggiornamento"
        '
        '_Label3_0
        '
        Me._Label3_0.BackColor = System.Drawing.SystemColors.Control
        Me._Label3_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label3_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Add(0, Me._Label3_0)
        Me._Label3_0.Location = New System.Drawing.Point(8, 248)
        Me._Label3_0.Name = "_Label3_0"
        Me._Label3_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label3_0.Size = New System.Drawing.Size(120, 17)
        Me._Label3_0.TabIndex = 18
        Me._Label3_0.Text = "DB materiali di Lancio"
        '
        '_Label2_3
        '
        Me._Label2_3.BackColor = System.Drawing.SystemColors.Control
        Me._Label2_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_3.ForeColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(64, Byte), CType(0, Byte))
        Me.Label2.Add(3, Me._Label2_3)
        Me._Label2_3.Location = New System.Drawing.Point(384, 64)
        Me._Label2_3.Name = "_Label2_3"
        Me._Label2_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_3.Size = New System.Drawing.Size(65, 17)
        Me._Label2_3.TabIndex = 13
        Me._Label2_3.Text = "Rottura"
        '
        '_Label2_2
        '
        Me._Label2_2.BackColor = System.Drawing.SystemColors.Control
        Me._Label2_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_2.ForeColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(64, Byte), CType(0, Byte))
        Me.Label2.Add(2, Me._Label2_2)
        Me._Label2_2.Location = New System.Drawing.Point(288, 64)
        Me._Label2_2.Name = "_Label2_2"
        Me._Label2_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_2.Size = New System.Drawing.Size(65, 17)
        Me._Label2_2.TabIndex = 12
        Me._Label2_2.Text = "Snervamento"
        '
        '_Label2_1
        '
        Me._Label2_1.BackColor = System.Drawing.SystemColors.Control
        Me._Label2_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_1.ForeColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(64, Byte), CType(0, Byte))
        Me.Label2.Add(1, Me._Label2_1)
        Me._Label2_1.Location = New System.Drawing.Point(168, 64)
        Me._Label2_1.Name = "_Label2_1"
        Me._Label2_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_1.Size = New System.Drawing.Size(65, 17)
        Me._Label2_1.TabIndex = 8
        Me._Label2_1.Text = "Amm. div.2"
        '
        '_Label2_0
        '
        Me._Label2_0.BackColor = System.Drawing.SystemColors.Control
        Me._Label2_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_0.ForeColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(64, Byte), CType(0, Byte))
        Me.Label2.Add(0, Me._Label2_0)
        Me._Label2_0.Location = New System.Drawing.Point(32, 64)
        Me._Label2_0.Name = "_Label2_0"
        Me._Label2_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_0.Size = New System.Drawing.Size(65, 17)
        Me._Label2_0.TabIndex = 1
        Me._Label2_0.Text = "Amm. div.1"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(8, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(449, 41)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Questa procedura deve essere eseguita solo da personale esperto."
        '
        'chkScelta
        '
        '
        'cmdCil
        '
        '
        'CheckBox1
        '
        Me.CheckBox1.Location = New System.Drawing.Point(8, 336)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(144, 24)
        Me.CheckBox1.TabIndex = 28
        Me.CheckBox1.Text = "Ricerca su pagina/Riga"
        '
        'RadioButton1
        '
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Location = New System.Drawing.Point(16, 296)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(168, 16)
        Me.RadioButton1.TabIndex = 29
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "ASME British"
        '
        'RadioButton2
        '
        Me.RadioButton2.Location = New System.Drawing.Point(16, 312)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(152, 16)
        Me.RadioButton2.TabIndex = 30
        Me.RadioButton2.Text = "ASME metriche"
        '
        'txtSource
        '
        Me.txtSource.Location = New System.Drawing.Point(280, 296)
        Me.txtSource.Name = "txtSource"
        Me.txtSource.Size = New System.Drawing.Size(152, 20)
        Me.txtSource.TabIndex = 31
        Me.txtSource.Text = "TextBox1"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(184, 296)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 16)
        Me.Label4.TabIndex = 32
        Me.Label4.Text = "Source"
        '
        'chkRinnovo
        '
        Me.chkRinnovo.Location = New System.Drawing.Point(168, 312)
        Me.chkRinnovo.Name = "chkRinnovo"
        Me.chkRinnovo.Size = New System.Drawing.Size(264, 16)
        Me.chkRinnovo.TabIndex = 33
        Me.chkRinnovo.Text = "Rinnovo valori"
        '
        'txticod
        '
        Me.txticod.Location = New System.Drawing.Point(144, 160)
        Me.txticod.Name = "txticod"
        Me.txticod.Size = New System.Drawing.Size(40, 20)
        Me.txticod.TabIndex = 34
        Me.txticod.Text = "TextBox1"
        '
        'txti
        '
        Me.txti.Location = New System.Drawing.Point(216, 160)
        Me.txti.Name = "txti"
        Me.txti.Size = New System.Drawing.Size(40, 20)
        Me.txti.TabIndex = 35
        Me.txti.Text = "TextBox1"
        '
        'txtTotal
        '
        Me.txtTotal.Location = New System.Drawing.Point(272, 160)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Size = New System.Drawing.Size(40, 20)
        Me.txtTotal.TabIndex = 36
        Me.txtTotal.Text = "TextBox1"
        '
        'txtMat
        '
        Me.txtMat.Location = New System.Drawing.Point(144, 184)
        Me.txtMat.Name = "txtMat"
        Me.txtMat.Size = New System.Drawing.Size(168, 20)
        Me.txtMat.TabIndex = 37
        Me.txtMat.Text = "TextBox1"
        '
        'frmUpdate
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(464, 373)
        Me.Controls.Add(Me.txtMat)
        Me.Controls.Add(Me.txtTotal)
        Me.Controls.Add(Me.txti)
        Me.Controls.Add(Me.txticod)
        Me.Controls.Add(Me.chkRinnovo)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtSource)
        Me.Controls.Add(Me.RadioButton1)
        Me.Controls.Add(Me._txtLibmat_1)
        Me.Controls.Add(Me._txtLibmat_0)
        Me.Controls.Add(Me.RadioButton2)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.cmdEU)
        Me.Controls.Add(Me.cmdNote)
        Me.Controls.Add(Me._chkScelta_0)
        Me.Controls.Add(Me.Command2)
        Me.Controls.Add(Me._cmdCil_1)
        Me.Controls.Add(Me._cmdCil_0)
        Me.Controls.Add(Me.Command1)
        Me.Controls.Add(Me._chkScelta_25)
        Me.Controls.Add(Me._chkScelta_24)
        Me.Controls.Add(Me._chkScelta_23)
        Me.Controls.Add(Me._chkScelta_22)
        Me.Controls.Add(Me._chkScelta_21)
        Me.Controls.Add(Me._chkScelta_8)
        Me.Controls.Add(Me._chkScelta_6)
        Me.Controls.Add(Me._chkScelta_4)
        Me.Controls.Add(Me._chkScelta_7)
        Me.Controls.Add(Me._chkScelta_2)
        Me.Controls.Add(Me._chkScelta_1)
        Me.Controls.Add(Me._Label3_1)
        Me.Controls.Add(Me._Label3_0)
        Me.Controls.Add(Me._Label2_3)
        Me.Controls.Add(Me._Label2_2)
        Me.Controls.Add(Me._Label2_1)
        Me.Controls.Add(Me._Label2_0)
        Me.Controls.Add(Me.Label1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Location = New System.Drawing.Point(4, 23)
        Me.Name = "frmUpdate"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "Aggiornamento materiali"


        For Each control In chkScelta.Values
            AddHandler control.CheckStateChanged, AddressOf chkScelta_CheckStateChanged
        Next
        For Each control In cmdCil.Values
            AddHandler control.Click, AddressOf cmdCil_Click
        Next
        For Each control In cmdCil.Values
            AddHandler control.DockChanged, AddressOf cmdCil_DockChanged
        Next

        Me.ResumeLayout(False)

    End Sub
#End Region
#Region "Supporto aggiornamento "
    Private Shared m_vb6FormDefInstance As frmUpdate
    Private Shared m_InitializingDefInstance As Boolean
    Public Shared Property DefInstance() As frmUpdate
        Get
            If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
                m_InitializingDefInstance = True
                m_vb6FormDefInstance = New frmUpdate
                m_InitializingDefInstance = False
            End If
            DefInstance = m_vb6FormDefInstance
        End Get
        Set(ByVal Value As frmUpdate)
            m_vb6FormDefInstance = Value
        End Set
    End Property
#End Region
    Private chk(25) As Short
    Public Mat As MaterialeNew1
    Public newmode As Boolean
    'UPGRADE_WARNING: L'evento chkScelta.CheckStateChanged può essere generato quando il form è inizializzato. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup2075"'
    Private Sub chkScelta_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Dim Index As Short = IndexedControls.IndexOf(chkScelta, CType(eventSender, CheckBox))
        chk(Index) = CShort(chkScelta(Index).CheckState)
        If Index < 8 And Index > 1 Then chk(Index + 10) = chk(Index)
    End Sub
    Private Sub cmdCil_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Dim Index As Short = IndexedControls.IndexOf(cmdCil, CType(eventSender, Button))
        With CommonDialog1
            .Filter = "Data Base di Access (*.mdb)|*.mdb"
            .InitialDirectory = Monitor.Motore.Inizio.Archdir
            .ShowDialog()
            txtLibmat(Index).Text = .FileName
        End With
    End Sub
    Private Sub cmdEU_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdEU.Click
        FileMate = txtLibmat(0).Text
        '    AggEU 1, 130
        '   AggEU 2, 622
        '    AggEU 4, 675
        '    AggEU 7, 787
        AggEU(8, 319)
    End Sub
    Private Sub cmdNote_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdNote.Click
        AggiustaNote()
    End Sub
    Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
        Dim i As Short
        FileAsme = txtLibmat(1).Text
        FileMate = txtLibmat(0).Text
        txtSource_Leave(Me, New EventArgs)
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        For i = 1 To 25 ' 1 To 25
            If chk(i) = 1 Then
                UpDateASME(i, newmode)
            End If
        Next
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
    End Sub
    Private Sub Command2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command2.Click
        Dim r As OleDbDataReader
        Dim c As New DataTable
        FileMate = txtLibmat(0).Text
        If Len(Dir(FileMate)) = 0 Then
            Monitor.Motore.MostraAiuto(RoutBase1.clsInizio.IDHS.IDH_UPASME_NODBMATE)
            Exit Sub
        End If
        Dim cString As String = Conn & FileMate & ConnFine
        MatBase = New OleDbConnection(cString)
        Try
            MatBase.Open()
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
        Dim cmd As OleDbCommand = New OleDbCommand("SELECT * FROM [Caract Orfane]", MatBase)
        r = cmd.ExecuteReader
        If r.HasRows Then
            Dim MatBase1 As New OleDbConnection(cString)
            Dim cmdc As OleDbDataAdapter = New OleDbDataAdapter("SELECT * From Caract", MatBase1)
            cmdc.Fill(c)
            Dim CB As OleDbCommandBuilder = New OleDbCommandBuilder(cmdc)
            Dim dvc As DataView = New DataView(c)
            dvc.Sort = "ID"
            Dim iFoundC As Integer
            While r.Read
                iFoundC = dvc.Find(r.GetInt32(0))
                If iFoundC > -1 Then
                    dvc.Delete(iFoundC)
                Else
                    Stop
                End If
            End While
            cmdc.Update(c)
        End If
        r.Close()
        cmd = New OleDbCommand("SELECT * FROM [Valori Orfani]", MatBase)
        r = cmd.ExecuteReader
        c = New DataTable
        If r.HasRows Then
            Dim MatBase1 As New OleDbConnection(cString)
            Dim cmdc As OleDbDataAdapter = New OleDbDataAdapter("SELECT * From Valori", MatBase1)
            cmdc.Fill(c)
            Dim CB As OleDbCommandBuilder = New OleDbCommandBuilder(cmdc)
            Dim dvc As DataView = New DataView(c)
            dvc.Sort = "ID"
            Dim iFoundC As Integer
            While r.Read
                iFoundC = dvc.Find(r.GetInt32(0))
                If iFoundC > -1 Then
                    dvc.Delete(iFoundC)
                Else
                    Stop
                End If
            End While
            cmdc.Update(c)
        End If
        r.Close()
        MatBase.Close()
    End Sub
    Private Sub Inizializza()
        txtLibmat(0).Text = Monitor.Motore.Inizio.Archdir & "\Mat200400.mdb"
        txtLibmat(1).Text = Monitor.Motore.Inizio.Archdir & "\ASMEmetric06.mdb"
        CaricaGenerale("DatiGenerali")
        Dim s As String = DatiGenerali("Source")
        If s = "" Then s = "ASME II-D 2006"
        Me.txtSource.Text = s
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        newmode = CheckBox1.Checked
    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        Metrico = RadioButton2.Checked
    End Sub

    Private Sub txtSource_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSource.Leave
        Sorgente = txtSource.Text
        Monitor.Motore.Inizio.WriteIniFile(Monitor.Motore.Inizio.Archdir + "\UpDateASME.ini", _
        "DatiGenerali", "Source", Sorgente)
    End Sub

    Private Sub chkRinnovo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkRinnovo.Click
        rinnovo = chkRinnovo.Checked
    End Sub

    Private Sub cmdCil_DockChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub
End Class