Option Strict Off
Option Explicit On
Public Class frmStiff
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
    Public WithEvents Command1 As System.Windows.Forms.Button
    Public WithEvents Command2 As System.Windows.Forms.Button
    Public WithEvents _TextCil_3 As System.Windows.Forms.TextBox
    Public WithEvents _TextCil_2 As System.Windows.Forms.TextBox
    Public WithEvents _TextCil_1 As System.Windows.Forms.TextBox
    Public WithEvents _TextCil_0 As System.Windows.Forms.TextBox
    Public WithEvents Combo1 As System.Windows.Forms.ComboBox
    Public WithEvents Picture1 As System.Windows.Forms.PictureBox
    Public WithEvents _LabelCil_4 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_3 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_2 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_1 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_0 As System.Windows.Forms.Label
    'NOTA: la routine seguente è richiesta dalla progettazione Windows Form.
    'Può essere modificata utilizzando la finestra di progettazione Windows Form.
    'Non modificarla mediante l'editor di codice.
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmStiff))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Command1 = New System.Windows.Forms.Button
        Me.Command2 = New System.Windows.Forms.Button
        Me._TextCil_3 = New System.Windows.Forms.TextBox
        Me._TextCil_2 = New System.Windows.Forms.TextBox
        Me._TextCil_1 = New System.Windows.Forms.TextBox
        Me._TextCil_0 = New System.Windows.Forms.TextBox
        Me.Combo1 = New System.Windows.Forms.ComboBox
        Me.Picture1 = New System.Windows.Forms.PictureBox
        Me._LabelCil_4 = New System.Windows.Forms.Label
        Me._LabelCil_3 = New System.Windows.Forms.Label
        Me._LabelCil_2 = New System.Windows.Forms.Label
        Me._LabelCil_1 = New System.Windows.Forms.Label
        Me._LabelCil_0 = New System.Windows.Forms.Label
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.SuspendLayout()
        '
        'Command1
        '
        Me.Command1.BackColor = System.Drawing.SystemColors.Control
        Me.Command1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command1.Location = New System.Drawing.Point(200, 209)
        Me.Command1.Name = "Command1"
        Me.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command1.Size = New System.Drawing.Size(49, 25)
        Me.Command1.TabIndex = 12
        Me.Command1.TabStop = False
        Me.Command1.Text = "OK"
        '
        'Command2
        '
        Me.Command2.BackColor = System.Drawing.SystemColors.Control
        Me.Command2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command2.Location = New System.Drawing.Point(200, 184)
        Me.Command2.Name = "Command2"
        Me.Command2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command2.Size = New System.Drawing.Size(49, 25)
        Me.Command2.TabIndex = 11
        Me.Command2.TabStop = False
        Me.Command2.Text = "Cancel"
        '
        '_TextCil_3
        '
        Me._TextCil_3.AcceptsReturn = True
        Me._TextCil_3.AutoSize = False
        Me._TextCil_3.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_3.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_3.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_3.Location = New System.Drawing.Point(112, 104)
        Me._TextCil_3.MaxLength = 0
        Me._TextCil_3.Name = "_TextCil_3"
        Me._TextCil_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_3.Size = New System.Drawing.Size(89, 21)
        Me._TextCil_3.TabIndex = 8
        Me._TextCil_3.Text = "Text1"
        '
        '_TextCil_2
        '
        Me._TextCil_2.AcceptsReturn = True
        Me._TextCil_2.AutoSize = False
        Me._TextCil_2.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_2.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_2.Location = New System.Drawing.Point(112, 80)
        Me._TextCil_2.MaxLength = 0
        Me._TextCil_2.Name = "_TextCil_2"
        Me._TextCil_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_2.Size = New System.Drawing.Size(89, 21)
        Me._TextCil_2.TabIndex = 7
        Me._TextCil_2.Text = "Text1"
        '
        '_TextCil_1
        '
        Me._TextCil_1.AcceptsReturn = True
        Me._TextCil_1.AutoSize = False
        Me._TextCil_1.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_1.Location = New System.Drawing.Point(112, 56)
        Me._TextCil_1.MaxLength = 0
        Me._TextCil_1.Name = "_TextCil_1"
        Me._TextCil_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_1.Size = New System.Drawing.Size(89, 21)
        Me._TextCil_1.TabIndex = 6
        Me._TextCil_1.Text = "Text1"
        '
        '_TextCil_0
        '
        Me._TextCil_0.AcceptsReturn = True
        Me._TextCil_0.AutoSize = False
        Me._TextCil_0.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_0.Location = New System.Drawing.Point(112, 32)
        Me._TextCil_0.MaxLength = 0
        Me._TextCil_0.Name = "_TextCil_0"
        Me._TextCil_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_0.Size = New System.Drawing.Size(89, 21)
        Me._TextCil_0.TabIndex = 5
        Me._TextCil_0.Text = "Text1"
        '
        'Combo1
        '
        Me.Combo1.BackColor = System.Drawing.SystemColors.Window
        Me.Combo1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Combo1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Combo1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Combo1.Location = New System.Drawing.Point(112, 8)
        Me.Combo1.Name = "Combo1"
        Me.Combo1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Combo1.Size = New System.Drawing.Size(113, 21)
        Me.Combo1.TabIndex = 1
        '
        'Picture1
        '
        Me.Picture1.BackColor = System.Drawing.SystemColors.Control
        Me.Picture1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Picture1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Picture1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Picture1.Location = New System.Drawing.Point(264, 0)
        Me.Picture1.Name = "Picture1"
        Me.Picture1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Picture1.Size = New System.Drawing.Size(256, 240)
        Me.Picture1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.Picture1.TabIndex = 0
        Me.Picture1.TabStop = False
        '
        '_LabelCil_4
        '
        Me._LabelCil_4.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_4.Location = New System.Drawing.Point(8, 104)
        Me._LabelCil_4.Name = "_LabelCil_4"
        Me._LabelCil_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_4.Size = New System.Drawing.Size(89, 17)
        Me._LabelCil_4.TabIndex = 10
        Me._LabelCil_4.Text = "Spessore, tw1"
        '
        '_LabelCil_3
        '
        Me._LabelCil_3.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_3.Location = New System.Drawing.Point(8, 80)
        Me._LabelCil_3.Name = "_LabelCil_3"
        Me._LabelCil_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_3.Size = New System.Drawing.Size(89, 17)
        Me._LabelCil_3.TabIndex = 9
        Me._LabelCil_3.Text = "Spessore, tw"
        '
        '_LabelCil_2
        '
        Me._LabelCil_2.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_2.Location = New System.Drawing.Point(8, 56)
        Me._LabelCil_2.Name = "_LabelCil_2"
        Me._LabelCil_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_2.Size = New System.Drawing.Size(89, 17)
        Me._LabelCil_2.TabIndex = 4
        Me._LabelCil_2.Text = "Larghezza, w"
        '
        '_LabelCil_1
        '
        Me._LabelCil_1.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_1.Location = New System.Drawing.Point(8, 32)
        Me._LabelCil_1.Name = "_LabelCil_1"
        Me._LabelCil_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_1.Size = New System.Drawing.Size(89, 17)
        Me._LabelCil_1.TabIndex = 3
        Me._LabelCil_1.Text = "Altezza, h"
        '
        '_LabelCil_0
        '
        Me._LabelCil_0.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_0.Location = New System.Drawing.Point(8, 8)
        Me._LabelCil_0.Name = "_LabelCil_0"
        Me._LabelCil_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_0.Size = New System.Drawing.Size(89, 17)
        Me._LabelCil_0.TabIndex = 2
        Me._LabelCil_0.Text = "Tipo"
        '
        'ImageList1
        '
        Me.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth4Bit
        Me.ImageList1.ImageSize = New System.Drawing.Size(256, 240)
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        '
        'frmStiff
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(522, 245)
        Me.Controls.Add(Me.Command1)
        Me.Controls.Add(Me.Command2)
        Me.Controls.Add(Me._TextCil_3)
        Me.Controls.Add(Me._TextCil_2)
        Me.Controls.Add(Me._TextCil_1)
        Me.Controls.Add(Me._TextCil_0)
        Me.Controls.Add(Me.Combo1)
        Me.Controls.Add(Me.Picture1)
        Me.Controls.Add(Me._LabelCil_4)
        Me.Controls.Add(Me._LabelCil_3)
        Me.Controls.Add(Me._LabelCil_2)
        Me.Controls.Add(Me._LabelCil_1)
        Me.Controls.Add(Me._LabelCil_0)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Location = New System.Drawing.Point(4, 23)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmStiff"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "Anelli di rinforzo"
        Me.ResumeLayout(False)

    End Sub
#End Region
#Region "Supporto aggiornamento "
    Private Shared m_vb6FormDefInstance As frmStiff
    Private Shared m_InitializingDefInstance As Boolean
    Public Shared Property DefInstance() As frmStiff
        Get
            If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
                m_InitializingDefInstance = True
                m_vb6FormDefInstance = New frmStiff()
                m_InitializingDefInstance = False
            End If
            DefInstance = m_vb6FormDefInstance
        End Get
        Set(ByVal value As frmStiff)
            m_vb6FormDefInstance = Value
        End Set
    End Property
#End Region
    Friend TagImageList1() As String = {"UG-30(a)", _
                                        "UG-30(b)", _
                                        "UG-30(c)", _
                                        "UG-30(d)", _
                                        "UG-30(e)"}
    Private Inizializzando As Boolean
    Private Sub Combo1_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Combo1.SelectedIndexChanged
        Dim i As Short
        If Inizializzando Then Exit Sub
        i = Combo1.SelectedIndex
        '   Involucr(kLato, jInvolucr).Dati3 = i
        Picture1.Image = ImageList1.Images(i + 1)
        _LabelCil_2.Visible = Not i = 4
        _TextCil_1.Visible = Not i = 4
        _LabelCil_4.Visible = Not i = 4
        _TextCil_3.Visible = Not i = 4
    End Sub
    Private Sub Inizializza()
        Dim i, n As Short
        n = ImageList1.Images.Count - 1
        For i = 1 To n
            Combo1.Items.Add(TagImageList1(i - 1))
        Next
        With Involucr(kLato, jInvolucr)
            If .Dati3 < 0 Or .Dati3 > n Then .Dati3 = 0
            Combo1.SelectedIndex = .Dati3
            _TextCil_0.Text = Format(.Dati1 * kLength, FormTemp)
            _TextCil_1.Text = Format(.Dati(4 - 4) * kLength, FormTemp)
            _TextCil_2.Text = Format(.Dati2 * kLength, FormTemp)
            _TextCil_3.Text = Format(.Dati(5 - 4) * kLength, FormTemp)
        End With
        _LabelCil_0.Text = _LabelCil_0.Text + " " + UnitLength
        _LabelCil_1.Text = _LabelCil_1.Text + " " + UnitLength
        _LabelCil_2.Text = _LabelCil_2.Text + " " + UnitLength
        _LabelCil_3.Text = _LabelCil_3.Text + " " + UnitLength
    End Sub
    Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
        With Involucr(kLato, jInvolucr)
            .Dati3 = Combo1.SelectedIndex
            .Dati1 = GlobalRoutines.ValVir(_TextCil_0.Text) / kLength
            .Dati(4 - 4) = GlobalRoutines.ValVir(_TextCil_1.Text) / kLength
            .Dati2 = GlobalRoutines.ValVir(_TextCil_2.Text) / kLength
            .Dati(5 - 4) = GlobalRoutines.ValVir(_TextCil_3.Text) / kLength
        End With
        Hide()
    End Sub

    Private Sub Command2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command2.Click
        Hide()
    End Sub
    Friend Function TagImages(ByVal Tag As String) As Image
        Dim i As Integer
        For i = 0 To ImageList1.Images.Count - 1
            If TagImageList1(i) = Tag Then Return ImageList1.Images(i + 1)
        Next
        Return Nothing
    End Function
End Class