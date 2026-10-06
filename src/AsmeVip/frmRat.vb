Option Strict On
Option Explicit On
Public Class frmRat
    Inherits System.Windows.Forms.Form
#Region "Codice generato dalla finestra di progettazione Windows Form "
    Public Sub New()
        MyBase.New()
        'Chiamata richiesta dalla progettazione Windows Form.
        InitializeComponent()
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
    Public WithEvents _TextCil_4 As System.Windows.Forms.TextBox
    Public WithEvents _TextCil_3 As System.Windows.Forms.TextBox
    Public WithEvents _TextCil_2 As System.Windows.Forms.TextBox
    Public WithEvents _TextCil_0 As System.Windows.Forms.TextBox
    Public WithEvents cmbCil As System.Windows.Forms.ComboBox
    Public WithEvents cmdCil As System.Windows.Forms.Button
    Public WithEvents _LabelCil_6 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_5 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_4 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_2 As System.Windows.Forms.Label
    Public WithEvents _LabelCil_1 As System.Windows.Forms.Label
    Public WithEvents Frames As System.Windows.Forms.GroupBox
    'NOTA: la routine seguente è richiesta dalla progettazione Windows Form.
    'Può essere modificata utilizzando la finestra di progettazione Windows Form.
    'Non modificarla mediante l'editor di codice.
    Friend WithEvents HelpProvider1 As System.Windows.Forms.HelpProvider
    Friend WithEvents chkAgganciato As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmRat))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.chkAgganciato = New System.Windows.Forms.CheckBox
        Me.Frames = New System.Windows.Forms.GroupBox
        Me.Command1 = New System.Windows.Forms.Button
        Me._TextCil_4 = New System.Windows.Forms.TextBox
        Me._TextCil_3 = New System.Windows.Forms.TextBox
        Me._TextCil_2 = New System.Windows.Forms.TextBox
        Me._TextCil_0 = New System.Windows.Forms.TextBox
        Me.cmbCil = New System.Windows.Forms.ComboBox
        Me.cmdCil = New System.Windows.Forms.Button
        Me._LabelCil_6 = New System.Windows.Forms.Label
        Me._LabelCil_5 = New System.Windows.Forms.Label
        Me._LabelCil_4 = New System.Windows.Forms.Label
        Me._LabelCil_2 = New System.Windows.Forms.Label
        Me._LabelCil_1 = New System.Windows.Forms.Label
        Me.HelpProvider1 = New System.Windows.Forms.HelpProvider
        Me.Frames.SuspendLayout()
        Me.SuspendLayout()
        '
        'chkAgganciato
        '
        Me.chkAgganciato.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkAgganciato.ForeColor = System.Drawing.SystemColors.ControlText
        Me.HelpProvider1.SetHelpKeyword(Me.chkAgganciato, "Tipi.htm#Materiale")
        Me.HelpProvider1.SetHelpNavigator(Me.chkAgganciato, System.Windows.Forms.HelpNavigator.Topic)
        Me.chkAgganciato.Location = New System.Drawing.Point(192, 30)
        Me.chkAgganciato.Name = "chkAgganciato"
        Me.HelpProvider1.SetShowHelp(Me.chkAgganciato, True)
        Me.chkAgganciato.TabIndex = 55
        Me.chkAgganciato.Text = "bound to library"
        Me.ToolTip1.SetToolTip(Me.chkAgganciato, "determina se il materiale è agganciato alla libreria o se è definito localmente")
        '
        'Frames
        '
        Me.Frames.BackColor = System.Drawing.SystemColors.Control
        Me.Frames.Controls.Add(Me.Command1)
        Me.Frames.Controls.Add(Me._TextCil_4)
        Me.Frames.Controls.Add(Me._TextCil_3)
        Me.Frames.Controls.Add(Me._TextCil_2)
        Me.Frames.Controls.Add(Me._TextCil_0)
        Me.Frames.Controls.Add(Me.cmbCil)
        Me.Frames.Controls.Add(Me.cmdCil)
        Me.Frames.Controls.Add(Me._LabelCil_6)
        Me.Frames.Controls.Add(Me._LabelCil_5)
        Me.Frames.Controls.Add(Me._LabelCil_4)
        Me.Frames.Controls.Add(Me._LabelCil_2)
        Me.Frames.Controls.Add(Me._LabelCil_1)
        Me.Frames.Controls.Add(Me.chkAgganciato)
        Me.Frames.ForeColor = System.Drawing.Color.Blue
        Me.Frames.Location = New System.Drawing.Point(0, 0)
        Me.Frames.Name = "Frames"
        Me.Frames.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frames.Size = New System.Drawing.Size(320, 168)
        Me.Frames.TabIndex = 0
        Me.Frames.TabStop = False
        '
        'Command1
        '
        Me.Command1.BackColor = System.Drawing.SystemColors.Control
        Me.Command1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command1.Location = New System.Drawing.Point(272, 136)
        Me.Command1.Name = "Command1"
        Me.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command1.Size = New System.Drawing.Size(41, 25)
        Me.Command1.TabIndex = 12
        Me.Command1.Text = "OK"
        '
        '_TextCil_4
        '
        Me._TextCil_4.AcceptsReturn = True
        Me._TextCil_4.AutoSize = False
        Me._TextCil_4.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_4.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_4.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_4.Location = New System.Drawing.Point(192, 136)
        Me._TextCil_4.MaxLength = 0
        Me._TextCil_4.Name = "_TextCil_4"
        Me._TextCil_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_4.Size = New System.Drawing.Size(73, 20)
        Me._TextCil_4.TabIndex = 6
        Me._TextCil_4.Text = "Text1"
        '
        '_TextCil_3
        '
        Me._TextCil_3.AcceptsReturn = True
        Me._TextCil_3.AutoSize = False
        Me._TextCil_3.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_3.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_3.Enabled = False
        Me._TextCil_3.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_3.Location = New System.Drawing.Point(192, 112)
        Me._TextCil_3.MaxLength = 0
        Me._TextCil_3.Name = "_TextCil_3"
        Me._TextCil_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_3.Size = New System.Drawing.Size(73, 20)
        Me._TextCil_3.TabIndex = 5
        Me._TextCil_3.Text = "Text1"
        '
        '_TextCil_2
        '
        Me._TextCil_2.AcceptsReturn = True
        Me._TextCil_2.AutoSize = False
        Me._TextCil_2.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_2.Enabled = False
        Me._TextCil_2.ForeColor = System.Drawing.SystemColors.WindowText
        Me._TextCil_2.Location = New System.Drawing.Point(192, 88)
        Me._TextCil_2.MaxLength = 0
        Me._TextCil_2.Name = "_TextCil_2"
        Me._TextCil_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TextCil_2.Size = New System.Drawing.Size(73, 20)
        Me._TextCil_2.TabIndex = 4
        Me._TextCil_2.Text = "Text1"
        '
        '_TextCil_0
        '
        Me._TextCil_0.AcceptsReturn = True
        Me._TextCil_0.AutoSize = False
        Me._TextCil_0.BackColor = System.Drawing.SystemColors.Window
        Me._TextCil_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TextCil_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HelpProvider1.SetHelpKeyword(Me._TextCil_0, "Tipi.htm#Materiale")
        Me.HelpProvider1.SetHelpNavigator(Me._TextCil_0, System.Windows.Forms.HelpNavigator.Topic)
        Me._TextCil_0.Location = New System.Drawing.Point(96, 12)
        Me._TextCil_0.MaxLength = 0
        Me._TextCil_0.Name = "_TextCil_0"
        Me._TextCil_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HelpProvider1.SetShowHelp(Me._TextCil_0, True)
        Me._TextCil_0.Size = New System.Drawing.Size(169, 20)
        Me._TextCil_0.TabIndex = 3
        Me._TextCil_0.Text = ""
        '
        'cmbCil
        '
        Me.cmbCil.BackColor = System.Drawing.SystemColors.Window
        Me.cmbCil.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbCil.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCil.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbCil.Location = New System.Drawing.Point(192, 64)
        Me.cmbCil.Name = "cmbCil"
        Me.cmbCil.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbCil.Size = New System.Drawing.Size(73, 21)
        Me.cmbCil.TabIndex = 2
        '
        'cmdCil
        '
        Me.cmdCil.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCil.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCil.ForeColor = System.Drawing.SystemColors.ControlText
        Me.HelpProvider1.SetHelpKeyword(Me.cmdCil, "Tipi.htm#Materiale")
        Me.HelpProvider1.SetHelpNavigator(Me.cmdCil, System.Windows.Forms.HelpNavigator.Topic)
        Me.cmdCil.Image = CType(resources.GetObject("cmdCil.Image"), System.Drawing.Image)
        Me.cmdCil.Location = New System.Drawing.Point(272, 12)
        Me.cmdCil.Name = "cmdCil"
        Me.cmdCil.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HelpProvider1.SetShowHelp(Me.cmdCil, True)
        Me.cmdCil.Size = New System.Drawing.Size(20, 20)
        Me.cmdCil.TabIndex = 1
        Me.cmdCil.TabStop = False
        Me.cmdCil.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        '_LabelCil_6
        '
        Me._LabelCil_6.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_6.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_6.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_6.Location = New System.Drawing.Point(8, 136)
        Me._LabelCil_6.Name = "_LabelCil_6"
        Me._LabelCil_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_6.Size = New System.Drawing.Size(177, 17)
        Me._LabelCil_6.TabIndex = 11
        Me._LabelCil_6.Tag = "kPress"
        Me._LabelCil_6.Text = "Allowable pressure [psi]"
        '
        '_LabelCil_5
        '
        Me._LabelCil_5.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_5.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_5.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_5.Location = New System.Drawing.Point(8, 112)
        Me._LabelCil_5.Name = "_LabelCil_5"
        Me._LabelCil_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_5.Size = New System.Drawing.Size(177, 17)
        Me._LabelCil_5.TabIndex = 10
        Me._LabelCil_5.Tag = "kPress"
        Me._LabelCil_5.Text = "Design pressure [psi]"
        '
        '_LabelCil_4
        '
        Me._LabelCil_4.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_4.Location = New System.Drawing.Point(8, 88)
        Me._LabelCil_4.Name = "_LabelCil_4"
        Me._LabelCil_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_4.Size = New System.Drawing.Size(161, 17)
        Me._LabelCil_4.TabIndex = 9
        Me._LabelCil_4.Tag = "kTemp"
        Me._LabelCil_4.Text = "Design temperature [°F]"
        '
        '_LabelCil_2
        '
        Me._LabelCil_2.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.HelpProvider1.SetHelpKeyword(Me._LabelCil_2, "Tipi.htm#Materiale")
        Me.HelpProvider1.SetHelpNavigator(Me._LabelCil_2, System.Windows.Forms.HelpNavigator.Topic)
        Me._LabelCil_2.Location = New System.Drawing.Point(8, 12)
        Me._LabelCil_2.Name = "_LabelCil_2"
        Me._LabelCil_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HelpProvider1.SetShowHelp(Me._LabelCil_2, True)
        Me._LabelCil_2.Size = New System.Drawing.Size(169, 17)
        Me._LabelCil_2.TabIndex = 8
        Me._LabelCil_2.Text = "Flange Material"
        '
        '_LabelCil_1
        '
        Me._LabelCil_1.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_1.Location = New System.Drawing.Point(8, 64)
        Me._LabelCil_1.Name = "_LabelCil_1"
        Me._LabelCil_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_1.Size = New System.Drawing.Size(105, 17)
        Me._LabelCil_1.TabIndex = 7
        Me._LabelCil_1.Text = "Rating"
        '
        'frmRat
        '
        Me.AcceptButton = Me.Command1
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(322, 168)
        Me.Controls.Add(Me.Frames)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.HelpButton = True
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmRat"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Calcolo Rating Flange ANSI B16.5"
        Me.Frames.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
#End Region
    Public PrRat As Single
    Public k, n As Short
    Public Pdes, Tdes As Single
    Public Rati As Short
    Public MatGr As String
    Private Sub Inizializza()
        Top = 50 ' GlobalRoutines.TwipsToPixelsY(660)
        Left = 200 ' GlobalRoutines.TwipsToPixelsX(2835)
        cmbCil.Items.Clear()
        cmbCil.Items.Add(" 150")
        cmbCil.Items.Add(" 300")
        cmbCil.Items.Add(" 400")
        cmbCil.Items.Add(" 600")
        cmbCil.Items.Add(" 900")
        cmbCil.Items.Add("1500")
        cmbCil.Items.Add("2500")
    End Sub
    Private Sub cmbCil_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbCil.SelectedIndexChanged
        Rati = CShort(GlobalRoutines.ValVir(cmbCil.Text))
        If Rati > 0 And Tdes > 0 And Not Matdim(Nozzles(k, n).IndexF) Is Nothing Then
            PrRat = Matdim(Nozzles(k, n).IndexF).LegRat(Tdes, Rati, MatGr)
            _TextCil_4.Text = GlobalRoutines.myStr(PrRat, 5, 2, 0)
        End If
        Nozzles(kLato, kNozzle).Rati = Rati
    End Sub
    Private Sub cmdCil_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCil.Click
        MatdimScelta(Nozzles(k, n).IndexF, 7, k, , n)
        _TextCil_0.Text = Matdim(Nozzles(k, n).IndexF).MatStr
        If Rati > 0 And Tdes > 0 Then
            PrRat = Matdim(Nozzles(k, n).IndexF).LegRat(Tdes, Rati, MatGr)
            _TextCil_4.Text = GlobalRoutines.myStr(PrRat, 5, 2, 0)
        End If
        '   Nozzles(kLato, kNozzle).RecIndF = Mat.Indmat
    End Sub

    Public Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
        If Not Matdim(Nozzles(k, n).IndexF) Is Nothing Then MatGr = CStr(Matdim(Nozzles(k, n).IndexF).MatGroup)
        Hide()
    End Sub
    Public ReadOnly Property LabelCil(ByVal i As Short) As Label
        Get
            Select Case i
                Case 1 : Return _LabelCil_1
                Case 2 : Return _LabelCil_2
                Case 4 : Return _LabelCil_4
                Case 5 : Return _LabelCil_5
                Case 6 : Return _LabelCil_6
                Case Else : Return Nothing
            End Select
        End Get
    End Property

    'UPGRADE_WARNING: Form evento frmRat.Activate presenta un nuovo comportamento. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup2065"'
    Public Sub frmRat_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
        Dim i As Short
        For i = 0 To CShort(cmbCil.Items.Count - 1)
            If GlobalRoutines.ValVir(CStr(cmbCil.Items(i))) = Rati Then
                cmbCil.SelectedIndex = i
                Exit For
            End If
        Next
        _TextCil_2.Text = GlobalRoutines.myStr(Tdes * kTemp + kTemp32, 5, 2, 0)
        _TextCil_3.Text = GlobalRoutines.myStr(Pdes * kPress, 5, 2, 0)
        If Not Matdim(Nozzles(k, n).IndexF) Is Nothing Then
            '       If Mat.Indmat > 0 Or Not Mat.Agganciato Then Mat.RecupMat(clsInizio.Archdir)
            _TextCil_0.Text = Matdim(Nozzles(k, n).IndexF).MatStr
        End If
        If Rati > 0 And Tdes > 0 And Not Matdim(Nozzles(k, n).IndexF) Is Nothing Then
            PrRat = Matdim(Nozzles(k, n).IndexF).LegRat(Tdes, Rati, MatGr)
            chkAgganciato.Checked = Matdim(Nozzles(k, n).IndexF).Agganciato
        End If
        _TextCil_4.Text = GlobalRoutines.myStr(PrRat, 5, 2, 0)
        AggiornaLabels(Me, 7)
    End Sub
    Private Sub _TextCil_4_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TextCil_4.TextChanged
        PrRat = GlobalRoutines.ValVir(_TextCil_4.Text)
    End Sub

    Private Sub chkAgganciato_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkAgganciato.CheckedChanged
        If Not Matdim(Nozzles(k, n).IndexF) Is Nothing Then
            Matdim(Nozzles(k, n).IndexF).Agganciato = chkAgganciato.Checked
        End If
    End Sub
End Class