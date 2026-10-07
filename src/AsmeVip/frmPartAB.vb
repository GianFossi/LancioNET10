Option Strict Off
Option Explicit On
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.common
Friend Class frmPartAB
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
                    If System.Reflection.Assembly.GetExecutingAssembly.EntryPoint IsNot Nothing AndAlso System.Reflection.Assembly.GetExecutingAssembly.EntryPoint.DeclaringType Is Me.GetType Then
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
    Public WithEvents Text3 As System.Windows.Forms.TextBox
    Public WithEvents Text2 As System.Windows.Forms.TextBox
    Public WithEvents Text1 As System.Windows.Forms.TextBox
    Public WithEvents _Picture1_0 As System.Windows.Forms.PictureBox
    Public WithEvents _Picture1_1 As System.Windows.Forms.PictureBox
    Public WithEvents _Picture1_2 As System.Windows.Forms.PictureBox
    Public WithEvents Command5 As System.Windows.Forms.Button
    Public WithEvents Command2 As System.Windows.Forms.Button
    Public WithEvents Command1 As System.Windows.Forms.Button
    Public WithEvents Txt2 As System.Windows.Forms.TextBox
    Public WithEvents Txt1 As System.Windows.Forms.TextBox
    Public WithEvents Label12 As System.Windows.Forms.Label
    Public WithEvents Label11 As System.Windows.Forms.Label
    Public WithEvents Label10 As System.Windows.Forms.Label
    Public WithEvents Label9 As System.Windows.Forms.Label
    Public WithEvents Label8 As System.Windows.Forms.Label
    Public WithEvents Label7 As System.Windows.Forms.Label
    Public WithEvents Label4 As System.Windows.Forms.Label
    Public WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents Labl6 As System.Windows.Forms.Label
    Public WithEvents Labl5 As System.Windows.Forms.Label
    Public WithEvents Labl4 As System.Windows.Forms.Label
    Public WithEvents Labl3 As System.Windows.Forms.Label
    Public WithEvents Labl2 As System.Windows.Forms.Label
    Public WithEvents Labl1 As System.Windows.Forms.Label
    'NOTA: la routine seguente è richiesta dalla progettazione Windows Form.
    'Può essere modificata utilizzando la finestra di progettazione Windows Form.
    'Non modificarla mediante l'editor di codice.
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmPartAB))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Text3 = New System.Windows.Forms.TextBox
        Me.Text2 = New System.Windows.Forms.TextBox
        Me.Text1 = New System.Windows.Forms.TextBox
        Me._Picture1_0 = New System.Windows.Forms.PictureBox
        Me._Picture1_1 = New System.Windows.Forms.PictureBox
        Me._Picture1_2 = New System.Windows.Forms.PictureBox
        Me.Command5 = New System.Windows.Forms.Button
        Me.Command2 = New System.Windows.Forms.Button
        Me.Command1 = New System.Windows.Forms.Button
        Me.Txt2 = New System.Windows.Forms.TextBox
        Me.Txt1 = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Labl6 = New System.Windows.Forms.Label
        Me.Labl5 = New System.Windows.Forms.Label
        Me.Labl4 = New System.Windows.Forms.Label
        Me.Labl3 = New System.Windows.Forms.Label
        Me.Labl2 = New System.Windows.Forms.Label
        Me.Labl1 = New System.Windows.Forms.Label
        Me.ListView1 = New System.Windows.Forms.ListView
        Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader2 = New System.Windows.Forms.ColumnHeader
        Me.SuspendLayout()
        '
        'Text3
        '
        Me.Text3.AcceptsReturn = True
        Me.Text3.AutoSize = False
        Me.Text3.BackColor = System.Drawing.SystemColors.Window
        Me.Text3.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Text3.Enabled = False
        Me.Text3.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text3.Location = New System.Drawing.Point(368, 280)
        Me.Text3.MaxLength = 0
        Me.Text3.Name = "Text3"
        Me.Text3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text3.Size = New System.Drawing.Size(57, 19)
        Me.Text3.TabIndex = 28
        Me.Text3.Text = "Text3"
        '
        'Text2
        '
        Me.Text2.AcceptsReturn = True
        Me.Text2.AutoSize = False
        Me.Text2.BackColor = System.Drawing.SystemColors.Window
        Me.Text2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Text2.Enabled = False
        Me.Text2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text2.Location = New System.Drawing.Point(368, 256)
        Me.Text2.MaxLength = 0
        Me.Text2.Name = "Text2"
        Me.Text2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text2.Size = New System.Drawing.Size(57, 19)
        Me.Text2.TabIndex = 27
        Me.Text2.Text = "Text2"
        '
        'Text1
        '
        Me.Text1.AcceptsReturn = True
        Me.Text1.AutoSize = False
        Me.Text1.BackColor = System.Drawing.SystemColors.Window
        Me.Text1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Text1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text1.Location = New System.Drawing.Point(328, 304)
        Me.Text1.MaxLength = 0
        Me.Text1.Name = "Text1"
        Me.Text1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text1.Size = New System.Drawing.Size(97, 19)
        Me.Text1.TabIndex = 24
        Me.Text1.Text = "Text1"
        '
        '_Picture1_0
        '
        Me._Picture1_0.BackColor = System.Drawing.SystemColors.Control
        Me._Picture1_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._Picture1_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Picture1_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Picture1_0.Image = CType(resources.GetObject("_Picture1_0.Image"), System.Drawing.Image)
        Me._Picture1_0.Location = New System.Drawing.Point(16, 24)
        Me._Picture1_0.Name = "_Picture1_0"
        Me._Picture1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Picture1_0.Size = New System.Drawing.Size(321, 81)
        Me._Picture1_0.TabIndex = 17
        Me._Picture1_0.TabStop = False
        Me._Picture1_0.Visible = False
        '
        '_Picture1_1
        '
        Me._Picture1_1.BackColor = System.Drawing.SystemColors.Control
        Me._Picture1_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._Picture1_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._Picture1_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Picture1_1.Image = CType(resources.GetObject("_Picture1_1.Image"), System.Drawing.Image)
        Me._Picture1_1.Location = New System.Drawing.Point(16, 24)
        Me._Picture1_1.Name = "_Picture1_1"
        Me._Picture1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Picture1_1.Size = New System.Drawing.Size(321, 81)
        Me._Picture1_1.TabIndex = 16
        Me._Picture1_1.TabStop = False
        Me._Picture1_1.Visible = False
        '
        '_Picture1_2
        '
        Me._Picture1_2.BackColor = System.Drawing.SystemColors.Control
        Me._Picture1_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._Picture1_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._Picture1_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Picture1_2.Image = CType(resources.GetObject("_Picture1_2.Image"), System.Drawing.Image)
        Me._Picture1_2.Location = New System.Drawing.Point(16, 24)
        Me._Picture1_2.Name = "_Picture1_2"
        Me._Picture1_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Picture1_2.Size = New System.Drawing.Size(321, 81)
        Me._Picture1_2.TabIndex = 14
        Me._Picture1_2.TabStop = False
        Me._Picture1_2.Visible = False
        '
        'Command5
        '
        Me.Command5.BackColor = System.Drawing.SystemColors.Control
        Me.Command5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command5.Location = New System.Drawing.Point(232, 336)
        Me.Command5.Name = "Command5"
        Me.Command5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command5.Size = New System.Drawing.Size(121, 25)
        Me.Command5.TabIndex = 12
        Me.Command5.Text = "Dati Pass-Partition"
        '
        'Command2
        '
        Me.Command2.BackColor = System.Drawing.SystemColors.Control
        Me.Command2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command2.Location = New System.Drawing.Point(360, 336)
        Me.Command2.Name = "Command2"
        Me.Command2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command2.Size = New System.Drawing.Size(65, 25)
        Me.Command2.TabIndex = 9
        Me.Command2.Text = "&Annulla"
        '
        'Command1
        '
        Me.Command1.BackColor = System.Drawing.SystemColors.Control
        Me.Command1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command1.Location = New System.Drawing.Point(432, 336)
        Me.Command1.Name = "Command1"
        Me.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command1.Size = New System.Drawing.Size(65, 25)
        Me.Command1.TabIndex = 4
        Me.Command1.Text = "&Ok"
        '
        'Txt2
        '
        Me.Txt2.AcceptsReturn = True
        Me.Txt2.AutoSize = False
        Me.Txt2.BackColor = System.Drawing.SystemColors.Window
        Me.Txt2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Txt2.Enabled = False
        Me.Txt2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Txt2.Location = New System.Drawing.Point(296, 152)
        Me.Txt2.MaxLength = 0
        Me.Txt2.Name = "Txt2"
        Me.Txt2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Txt2.Size = New System.Drawing.Size(97, 19)
        Me.Txt2.TabIndex = 2
        Me.Txt2.Text = "0"
        '
        'Txt1
        '
        Me.Txt1.AcceptsReturn = True
        Me.Txt1.AutoSize = False
        Me.Txt1.BackColor = System.Drawing.SystemColors.Window
        Me.Txt1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Txt1.Enabled = False
        Me.Txt1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Txt1.Location = New System.Drawing.Point(296, 128)
        Me.Txt1.MaxLength = 0
        Me.Txt1.Name = "Txt1"
        Me.Txt1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Txt1.Size = New System.Drawing.Size(97, 19)
        Me.Txt1.TabIndex = 1
        Me.Txt1.Text = "0"
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.SystemColors.Control
        Me.Label12.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label12.Location = New System.Drawing.Point(368, 232)
        Me.Label12.Name = "Label12"
        Me.Label12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label12.Size = New System.Drawing.Size(136, 17)
        Me.Label12.TabIndex = 26
        Me.Label12.Text = "Spessore minimo TEMA :"
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.SystemColors.Control
        Me.Label11.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(224, 232)
        Me.Label11.Name = "Label11"
        Me.Label11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label11.Size = New System.Drawing.Size(121, 17)
        Me.Label11.TabIndex = 25
        Me.Label11.Text = "Tipo materiale"
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.SystemColors.Control
        Me.Label10.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(440, 304)
        Me.Label10.Name = "Label10"
        Me.Label10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label10.Size = New System.Drawing.Size(41, 17)
        Me.Label10.TabIndex = 23
        Me.Label10.Text = "Label10"
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.SystemColors.Control
        Me.Label9.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(224, 304)
        Me.Label9.Name = "Label9"
        Me.Label9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label9.Size = New System.Drawing.Size(105, 17)
        Me.Label9.TabIndex = 22
        Me.Label9.Text = "Spessore assunto :"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.Control
        Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(224, 280)
        Me.Label8.Name = "Label8"
        Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label8.Size = New System.Drawing.Size(152, 17)
        Me.Label8.TabIndex = 21
        Me.Label8.Text = "Spessore minimo di calcolo :"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.Control
        Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(440, 280)
        Me.Label7.Name = "Label7"
        Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label7.Size = New System.Drawing.Size(41, 17)
        Me.Label7.TabIndex = 20
        Me.Label7.Text = "Label7"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(440, 256)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(41, 17)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "Label4"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(224, 256)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(136, 17)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "Spessore minimo TEMA :"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(16, 112)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(193, 17)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "Tabella RCB-9.132"
        '
        'Labl6
        '
        Me.Labl6.BackColor = System.Drawing.SystemColors.Control
        Me.Labl6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Labl6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Labl6.Location = New System.Drawing.Point(408, 152)
        Me.Labl6.Name = "Labl6"
        Me.Labl6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Labl6.Size = New System.Drawing.Size(41, 17)
        Me.Labl6.TabIndex = 8
        Me.Labl6.Text = "Label6"
        '
        'Labl5
        '
        Me.Labl5.BackColor = System.Drawing.SystemColors.Control
        Me.Labl5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Labl5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Labl5.Location = New System.Drawing.Point(408, 128)
        Me.Labl5.Name = "Labl5"
        Me.Labl5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Labl5.Size = New System.Drawing.Size(41, 17)
        Me.Labl5.TabIndex = 7
        Me.Labl5.Text = "Label5"
        '
        'Labl4
        '
        Me.Labl4.BackColor = System.Drawing.SystemColors.Control
        Me.Labl4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Labl4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Labl4.Location = New System.Drawing.Point(224, 200)
        Me.Labl4.Name = "Labl4"
        Me.Labl4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Labl4.Size = New System.Drawing.Size(193, 17)
        Me.Labl4.TabIndex = 6
        Me.Labl4.Text = "Corrispondente valore di B"
        '
        'Labl3
        '
        Me.Labl3.BackColor = System.Drawing.SystemColors.Control
        Me.Labl3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Labl3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Labl3.Location = New System.Drawing.Point(224, 176)
        Me.Labl3.Name = "Labl3"
        Me.Labl3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Labl3.Size = New System.Drawing.Size(185, 17)
        Me.Labl3.TabIndex = 5
        Me.Labl3.Text = "Valore calcolato di a/b"
        '
        'Labl2
        '
        Me.Labl2.BackColor = System.Drawing.SystemColors.Control
        Me.Labl2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Labl2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Labl2.Location = New System.Drawing.Point(224, 152)
        Me.Labl2.Name = "Labl2"
        Me.Labl2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Labl2.Size = New System.Drawing.Size(65, 17)
        Me.Labl2.TabIndex = 3
        Me.Labl2.Text = "Valore di b"
        '
        'Labl1
        '
        Me.Labl1.BackColor = System.Drawing.SystemColors.Control
        Me.Labl1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Labl1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Labl1.Location = New System.Drawing.Point(224, 128)
        Me.Labl1.Name = "Labl1"
        Me.Labl1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Labl1.Size = New System.Drawing.Size(65, 17)
        Me.Labl1.TabIndex = 0
        Me.Labl1.Text = "Valore di a"
        '
        'ListView1
        '
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.ListView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ListView1.Location = New System.Drawing.Point(8, 136)
        Me.ListView1.MultiSelect = False
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(184, 128)
        Me.ListView1.TabIndex = 29
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "a/b"
        Me.ColumnHeader1.Width = 90
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "B"
        Me.ColumnHeader2.Width = 90
        '
        'frmPartAB
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(502, 372)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.Text3)
        Me.Controls.Add(Me.Text2)
        Me.Controls.Add(Me.Text1)
        Me.Controls.Add(Me._Picture1_0)
        Me.Controls.Add(Me._Picture1_1)
        Me.Controls.Add(Me._Picture1_2)
        Me.Controls.Add(Me.Command5)
        Me.Controls.Add(Me.Command2)
        Me.Controls.Add(Me.Command1)
        Me.Controls.Add(Me.Txt2)
        Me.Controls.Add(Me.Txt1)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Labl6)
        Me.Controls.Add(Me.Labl5)
        Me.Controls.Add(Me.Labl4)
        Me.Controls.Add(Me.Labl3)
        Me.Controls.Add(Me.Labl2)
        Me.Controls.Add(Me.Labl1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.HelpButton = True
        Me.Location = New System.Drawing.Point(4, 23)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPartAB"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowInTaskbar = False
        Me.Text = "AsmeVip - Pass partition plates"
        Me.ResumeLayout(False)

    End Sub
#End Region
#Region "Supporto aggiornamento "
    Private Shared m_vb6FormDefInstance As frmPartAB
    Private Shared m_InitializingDefInstance As Boolean
    Public Shared Property DefInstance() As frmPartAB
        Get
            If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
                m_InitializingDefInstance = True
                m_vb6FormDefInstance = New frmPartAB
                m_InitializingDefInstance = False
            End If
            DefInstance = m_vb6FormDefInstance
        End Get
        Set(ByVal Value As frmPartAB)
            m_vb6FormDefInstance = Value
        End Set
    End Property
#End Region
    Private objPart As wn_Part
    Private Inizializzando As Boolean
    Private Sub Inizializza()
        aggiorna_label()
    End Sub
    Public Sub Calcola(ByRef str_a As String, ByRef str_b As String)
        Dim asub As Single
        Dim i As Short
        Dim val_a, val_b As Single
        Dim b_calcolato As Single
        Dim str_val_a1 As String = ""
        Dim str_val_a2 As String = ""
        Dim str_val_b1 As String = ""
        Dim str_val_b2 As String = ""
        Dim val_b1, val_a1, val_a2 As Single
        Dim val_b2 As Single
        Dim list_tmp As Single
        Dim str_list_tmp As String = ""
        Dim Stringa(1) As String
        Stringa(0) = "Carbon Steel"
        Stringa(1) = "Alloy Steel"
        If str_a = "" Then
            str_a = "0"
        End If
        If str_b = "" Then
            str_b = "0"
        End If
        val_a = GlobalRoutines.ValVir(str_a)
        val_b = GlobalRoutines.ValVir(str_b)
        If val_a = 0 Or val_b = 0 Then
            Labl3.Text = "I valori immessi non sono validi"
            Exit Sub
        End If
        asub = val_a / val_b
        Labl3.Text = "Valore di a/b : " & GlobalRoutines.myStr(asub, 2, 5, 0)
        'Calcolo dell'interpolazione tra i valori
        'Ciclo attraverso tutti i valori contenuti
        'nella ListBox per ricercare un intervallo in cui sia conpreso
        'il mio valore calcolato di a/b
        For i = 1 To 7
            str_list_tmp = ListView1.Items(i - 1).Text
            'Se il valore ottenuto dalla tabella è Infinito allora
            'setto il valore calcolato dalla tabella a un numero enorme che
            'rappresenta appunto Infinito
            If str_list_tmp = "Infinito" Then
                list_tmp = 2147483152
            Else
                list_tmp = GlobalRoutines.ValVir(ListView1.Items(i - 1).Text)
            End If
            If list_tmp > asub Then
                If i = 1 Then
                    str_val_a1 = "0"
                    str_val_b1 = "0"
                Else
                    str_val_a1 = ListView1.Items(i - 2).Text
                    str_val_b1 = ListView1.Items(i - 2).SubItems(1).Text
                End If
                str_val_a2 = ListView1.Items(i - 1).Text
                str_val_b2 = ListView1.Items(i - 1).SubItems(1).Text
                Exit For
            End If
        Next
        'Esegue una sorta di Clipping dei valori calcolati nell'intervallo specificato
        'dalla tabella

        If asub < GlobalRoutines.ValVir(ListView1.Items(0).Text) Then
            b_calcolato = GlobalRoutines.ValVir(ListView1.Items(0).SubItems(1).Text)
        ElseIf asub > GlobalRoutines.ValVir(ListView1.Items(5).Text) Then
            b_calcolato = GlobalRoutines.ValVir(ListView1.Items(6).SubItems(1).Text)
        ElseIf str_val_a1 = "0" Then
            b_calcolato = GlobalRoutines.ValVir(ListView1.Items(0).SubItems(1).Text)
        Else
            val_a1 = GlobalRoutines.ValVir(str_val_a1)
            val_b1 = GlobalRoutines.ValVir(str_val_b1)
            val_a2 = GlobalRoutines.ValVir(str_val_a2)
            val_b2 = GlobalRoutines.ValVir(str_val_b2)
            b_calcolato = val_b1 + ((asub - val_a1) * ((val_b2 - val_b1) / (val_a2 - val_a1)))
        End If
        'Mostra il risultato a video
        Labl4.Text = "Valore di B : " & GlobalRoutines.myStr(b_calcolato, 2, 5, 0)
        'Setta le variabili globali
        With objPart
            .Valore_b = b_calcolato
            ' If Config(0).US = 2 Then
            '.tmp_shell_diameter = .Shell_Diameter
            'Else
                .tmp_shell_diameter = .Shell_Diameter / inc
            'End If
            If .tmp_shell_diameter < 24 And .tipo_Materiale = .Carbon_Steel Then .t_tema = 3 / 8
            If .tmp_shell_diameter < 24 And .tipo_Materiale = .Alloy_Material Then .t_tema = 1 / 4
            If .tmp_shell_diameter > 24 And .tipo_Materiale = .Carbon_Steel Then .t_tema = 1 / 2
            If .tmp_shell_diameter > 24 And .tipo_Materiale = .Alloy_Material Then .t_tema = 3 / 8
            .t = .dimensione_b * System.Math.Sqrt(.design_pressure * .Valore_b / (1.5 * .allowable_stress)) + 2 * .corrosion
            Label12.Text = Stringa(.tipo_Materiale)
            Text2.Text = GlobalRoutines.myStr(.t_tema * inc * kLength, 3, 2, False)
            Text3.Text = GlobalRoutines.myStr(.t * kLength, 3, 3, False)
        End With
    End Sub
    Public Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
        Me.Close()
        objPart.Stampa()
    End Sub
    Private Sub Command2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command2.Click
        Me.Close()
    End Sub
    'UPGRADE_WARNING: Form evento frmPartAB.Activate presenta un nuovo comportamento. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup2065"'
    Public Sub frmPartAB_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
        Dim db As OleDbConnection
        Dim mytab As New DataTable
        Dim valo As ListViewItem ' MSComctlLib.ListItem
        Dim i As Short
        'Settaggio delle Option Box
        If objPart Is Nothing Then objPart = objMemb(Involucr(kLato, jInvolucr).IndObject)
        _Picture1_0.Visible = False
        _Picture1_1.Visible = False
        _Picture1_2.Visible = False
        With objPart
            Text1.Text = GlobalRoutines.myStr(Involucr(kLato, jInvolucr).Spess * kLength, 3, 2, False)
            aggiorna_label()
            .AggTAbelle()
            Dim MyFile As String = Monitor.Motore.Inizio.Archdir & "\tabelle.mdb"
            Try
                Dim cString As String = Conn & MyFile & ConnFine
                db = New OleDbConnection(cString)
            Catch e As Exception
                MessageBox.Show("File " & MyFile & "; errore:" & e.Message & vbCrLf & e.StackTrace)
                Exit Sub
            End Try
            Dim cmd As OleDbDataAdapter = New OleDbDataAdapter("SELECT * FROM " & .tabella, db)
            cmd.Fill(mytab)
            ListView1.Items.Clear()
            Dim dv As DataView = New DataView(mytab)
            For i = 0 To dv.Count - 1
                valo = ListView1.Items.Add(dv(i)("a_fratto_b"))
                valo.SubItems.Add(dv(i)("b"))
            Next
            Txt1.Text = GlobalRoutines.myStr(.dimensione_a * kLength, 4, 3, 0)
            Txt2.Text = GlobalRoutines.myStr(.dimensione_b * kLength, 4, 3, 0)
            Select Case .pass_partition
                Case 0 : _Picture1_0.Visible = True
                Case 1 : _Picture1_0.Visible = True
                Case 2 : _Picture1_0.Visible = True
            End Select
            Calcola(Txt1.Text, Txt2.Text)
        End With
    End Sub
    Private Sub frmPartAB_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        'Centra le picture Box nel form
        objPart = objMemb(Involucr(kLato, jInvolucr).IndObject)
        With objPart
            _Picture1_0.Left = Width / 2 - _Picture1_0.Width / 2
            _Picture1_1.Left = Width / 2 - _Picture1_1.Width / 2
            _Picture1_2.Left = Width / 2 - _Picture1_2.Width / 2
        End With
    End Sub
    Private Sub Text1_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Text1.TextChanged
        If Inizializzando Then Exit Sub
        Involucr(kLato, jInvolucr).Spess = GlobalRoutines.ValVir(Text1.Text * kLength)
    End Sub
    Private Sub Txt1_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Txt1.Enter
        objPart.inserimento = objPart.personalizzato
    End Sub
    Private Sub Txt1_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles Txt1.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        'Se il tasto premuto è una virgola allora setta la variabile di controllo
        'If KeyAscii = Asc(".") Then
        '  virgola = True
        'End If
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub
    Private Sub Txt2_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Txt2.Enter
        objPart.inserimento = objPart.personalizzato
    End Sub
    Private Sub Txt2_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles Txt2.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        'Se il tasto premuto è una virgola allora setta la variabile di controllo
        'If KeyAscii = Asc(".") Then
        '  virgola = True
        'End If
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub
    Private Sub Command5_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command5.Click
        frmDatiPart.DefInstance.Show()
    End Sub
    Private Sub aggiorna_label()
        With objPart
            If Config(0).US < 2 Then
                Label4.Text = "mm"
                Label7.Text = "mm"
                Label10.Text = "mm"
                Labl5.Text = "mm"
                Labl6.Text = "mm"
            Else
                Label4.Text = "in"
                Label7.Text = "in"
                Label10.Text = "in"
                Labl5.Text = "in"
                Labl6.Text = "in"
            End If
        End With
    End Sub
    Private Sub ListView1_ItemActivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.ItemActivate
        Dim i As ListViewItem = ListView1.SelectedItems(0)
        objPart.Valore_b = GlobalRoutines.ValVir(i.SubItems(1).Text)
        objPart.Valore_asub = GlobalRoutines.ValVir(i.Text)
        objPart.inserimento = objPart.Standard
    End Sub
End Class