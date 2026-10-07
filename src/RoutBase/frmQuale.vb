Option Strict Off
Option Explicit On 
Imports RoutBase1
Public Class frmQuale
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
        InitializeComponent()
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
    Public WithEvents HScroll1 As System.Windows.Forms.HScrollBar
    Public WithEvents VScroll1 As System.Windows.Forms.VScrollBar
    Public WithEvents _Option1_0 As System.Windows.Forms.RadioButton
    Public WithEvents Picture1 As System.Windows.Forms.Panel
    Public WithEvents _Command1_2 As System.Windows.Forms.Button
    Public WithEvents _Command1_1 As System.Windows.Forms.Button
    Public WithEvents _Command1_0 As System.Windows.Forms.Button
    Public Command1 As New System.Collections.Generic.Dictionary(Of Integer, Button)
    Public Option1 As New System.Collections.Generic.Dictionary(Of Integer, RadioButton)
    'NOTA: la routine seguente è richiesta dalla progettazione Windows Form.
    'Può essere modificata utilizzando la finestra di progettazione Windows Form.
    'Non modificarla mediante l'editor di codice.
    Friend WithEvents Picture2 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.HScroll1 = New System.Windows.Forms.HScrollBar
        Me.VScroll1 = New System.Windows.Forms.VScrollBar
        Me.Picture1 = New System.Windows.Forms.Panel
        Me._Option1_0 = New System.Windows.Forms.RadioButton
        Me._Command1_2 = New System.Windows.Forms.Button
        Me._Command1_1 = New System.Windows.Forms.Button
        Me._Command1_0 = New System.Windows.Forms.Button
        Me.Picture2 = New System.Windows.Forms.Label
        Me.Picture1.SuspendLayout()
        Me.SuspendLayout()
        '
        'HScroll1
        '
        Me.HScroll1.Cursor = System.Windows.Forms.Cursors.Default
        Me.HScroll1.LargeChange = 1
        Me.HScroll1.Location = New System.Drawing.Point(8, 72)
        Me.HScroll1.Maximum = 32767
        Me.HScroll1.Name = "HScroll1"
        Me.HScroll1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HScroll1.Size = New System.Drawing.Size(241, 17)
        Me.HScroll1.TabIndex = 5
        Me.HScroll1.TabStop = True
        '
        'VScroll1
        '
        Me.VScroll1.Cursor = System.Windows.Forms.Cursors.Default
        Me.VScroll1.LargeChange = 1
        Me.VScroll1.Location = New System.Drawing.Point(248, 40)
        Me.VScroll1.Maximum = 32767
        Me.VScroll1.Name = "VScroll1"
        Me.VScroll1.Size = New System.Drawing.Size(17, 33)
        Me.VScroll1.TabIndex = 4
        Me.VScroll1.TabStop = True
        '
        'Picture1
        '
        Me.Picture1.BackColor = System.Drawing.SystemColors.Control
        Me.Picture1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Picture1.Controls.Add(Me._Option1_0)
        Me.Picture1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Picture1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Picture1.Location = New System.Drawing.Point(8, 40)
        Me.Picture1.Name = "Picture1"
        Me.Picture1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Picture1.Size = New System.Drawing.Size(241, 33)
        Me.Picture1.TabIndex = 3
        Me.Picture1.TabStop = True
        '
        '_Option1_0
        '
        Me._Option1_0.BackColor = System.Drawing.SystemColors.Control
        Me._Option1_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option1_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Option1.Add(0, Me._Option1_0)
        Me._Option1_0.Location = New System.Drawing.Point(16, 0)
        Me._Option1_0.Name = "_Option1_0"
        Me._Option1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option1_0.Size = New System.Drawing.Size(223, 20)
        Me._Option1_0.TabIndex = 6
        Me._Option1_0.TabStop = True
        Me._Option1_0.Text = "Option1"
        '
        '_Command1_2
        '
        Me._Command1_2.BackColor = System.Drawing.SystemColors.Control
        Me._Command1_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._Command1_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command1.Add(2, Me._Command1_2)
        Me._Command1_2.Location = New System.Drawing.Point(171, 88)
        Me._Command1_2.Name = "_Command1_2"
        Me._Command1_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Command1_2.Size = New System.Drawing.Size(73, 25)
        Me._Command1_2.TabIndex = 2
        Me._Command1_2.Text = "Help"
        '
        '_Command1_1
        '
        Me._Command1_1.BackColor = System.Drawing.SystemColors.Control
        Me._Command1_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._Command1_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command1.Add(1, Me._Command1_1)
        Me._Command1_1.Location = New System.Drawing.Point(96, 88)
        Me._Command1_1.Name = "_Command1_1"
        Me._Command1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Command1_1.Size = New System.Drawing.Size(73, 25)
        Me._Command1_1.TabIndex = 1
        Me._Command1_1.Text = "Cancel"
        '
        '_Command1_0
        '
        Me._Command1_0.BackColor = System.Drawing.SystemColors.Control
        Me._Command1_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Command1_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command1.Add(0, Me._Command1_0)
        Me._Command1_0.Location = New System.Drawing.Point(8, 88)
        Me._Command1_0.Name = "_Command1_0"
        Me._Command1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Command1_0.Size = New System.Drawing.Size(81, 25)
        Me._Command1_0.TabIndex = 0
        Me._Command1_0.Text = "OK"
        '
        'Command1
        '
        '
        'Option1
        '
        '
        'Picture2
        '
        Me.Picture2.Location = New System.Drawing.Point(8, 0)
        Me.Picture2.Name = "Picture2"
        Me.Picture2.Size = New System.Drawing.Size(256, 40)
        Me.Picture2.TabIndex = 6
        Me.Picture2.Text = "Label1"
        '
        'frmQuale
        '
        Me.AcceptButton = Me._Command1_0
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(270, 118)
        Me.ControlBox = False
        Me.Controls.Add(Me.Picture2)
        Me.Controls.Add(Me.HScroll1)
        Me.Controls.Add(Me.VScroll1)
        Me.Controls.Add(Me.Picture1)
        Me.Controls.Add(Me._Command1_2)
        Me.Controls.Add(Me._Command1_1)
        Me.Controls.Add(Me._Command1_0)
        Me.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Location = New System.Drawing.Point(2, 22)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmQuale"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Form1"
        Me.Picture1.ResumeLayout(False)
        For Each control In Command1.Values
            AddHandler control.Click, AddressOf Command1_Click
        Next
        For Each control In Option1.Values
            AddHandler control.CheckedChanged, AddressOf Option1_CheckedChanged
        Next
        Me.ResumeLayout(False)

    End Sub
#End Region
#Region "Supporto aggiornamento "
    Private Shared m_vb6FormDefInstance As frmQuale
    Private Shared m_InitializingDefInstance As Boolean
    Public Shared Property DefInstance() As frmQuale
        Get
            If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
                m_InitializingDefInstance = True
                m_vb6FormDefInstance = New frmQuale
                m_InitializingDefInstance = False
            End If
            DefInstance = m_vb6FormDefInstance
        End Get
        Set(ByVal Value As frmQuale)
            m_vb6FormDefInstance = Value
        End Set
    End Property
#End Region
    Public Motore As RoutBase1.clsMotore
    Friend Ninput As Short
    Public Tit As String
    Public Aiuto As String
    Friend Strin() As String
    Public Nfin As Short
    Public NonMostrare As Boolean
    Friend Gia As Boolean
    Public CarFissi As Boolean
    Private gPicture1 As System.Drawing.Graphics
    Private gPicture2 As System.Drawing.Graphics
    Public iQ As Short
    Public iQuale As Short
    Public Testo As String
    Public IDH As Integer
    Public strIDH As String
    Private LeftOptOld As Single
    Private TopOptOld As Single
    Event OKClick()
    Event OptClick(ByRef n As Short, ByRef indice As Short)
    Event CancelClick()
    Public WriteOnly Property pStrin(ByVal i As Short) As String
        Set(ByVal Value As String)
            Strin(i) = Value
        End Set
    End Property
    Public Property pNinput() As Short
        Get
            pNinput = Ninput
        End Get
        Set(ByVal Value As Short)
            Ninput = Value
            If Ninput > 0 Then ReDim Strin(Ninput)
        End Set
    End Property
    Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Dim Index As Short = IndexedControls.IndexOf(Command1, eventSender)
        Select Case Index
            Case 0
                If Nfin > 0 Then
                    RaiseEvent OKClick()
                Else
                    Hide()
                End If
            Case 1
                If Nfin > 0 Then
                    RaiseEvent OKClick()
                Else
                    iQuale = 0
                    Hide()
                End If
            Case 2
                If Aiuto.Trim.Length = 0 Then
                    MsgBox("Non ci sono informazioni disponibili")
                ElseIf InStr(Aiuto, "\") > 0 Then
                    If IDH > 0 Then
                        Motore.RetrHelp(Aiuto, Me, "", IDH)
                    Else
                        Motore.RetrHelp(Aiuto, Me, "", strIDH)
                    End If
                Else
                    MsgBox(Aiuto)
                End If
        End Select
    End Sub

    'UPGRADE_WARNING: Form evento frmQuale.Activate presenta un nuovo comportamento. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup2065"'
    Private Sub frmQuale_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
        If NonMostrare And Nfin > 0 Then Visible = False
        'FIXIT: Sostituire la funzione "Trim" con la funzione "Trim$"                              FixIT90210ae-R9757-R1B8ZE
        If Len(Trim(Aiuto)) = 0 Then Command1(2).Visible = False
    End Sub

    'UPGRADE_NOTE: HScroll1.Change è stato modificato da evento a routine. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup2010"'
    'UPGRADE_WARNING: HScrollBar evento HScroll1.Change presenta un nuovo comportamento. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup2065"'
    Private Sub HScroll1_Change(ByVal newScrollValue As Integer)
        Dim delta As Single
        Dim i As Short
        delta = newScrollValue - HScroll1.Minimum
        For i = 0 To Ninput - 1
            Option1(i).Left = LeftOptOld - delta
        Next
    End Sub

    'UPGRADE_WARNING: L'evento Option1.CheckedChanged può essere generato quando il form è inizializzato. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup2075"'
    Private Sub Option1_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        If eventSender.Checked Then
            Dim Index As Short = IndexedControls.IndexOf(Option1, eventSender)
            If Not Option1(Index).Enabled Then Exit Sub
            iQuale = Index + 1
            iQ = iQuale
            If Nfin > 0 Then RaiseEvent OptClick(Nfin, iQuale)
        End If
    End Sub

    'UPGRADE_NOTE: VScroll1.Change è stato modificato da evento a routine. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup2010"'
    'UPGRADE_WARNING: VScrollBar evento VScroll1.Change presenta un nuovo comportamento. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup2065"'
    Private Sub VScroll1_Change(ByVal newScrollValue As Integer)
        Dim delta As Single
        Dim i As Short
        delta = newScrollValue - VScroll1.Minimum
        Option1(0).Top = TopOptOld - delta
        For i = 1 To Ninput - 1
            Option1(i).Top = Option1(i - 1).Top + Option1(i - 1).Height
        Next
    End Sub

    Private Sub EspandHeight(ByRef MM As Single, ByRef NewHeight As Single)
        Dim dH, HFin As Single
        Dim i As Short
        If Ninput = 0 Then
            MM = 0
        Else
            MM = Option1(Ninput - 1).Top + Option1(Ninput - 1).Height
        End If
        If MM <= Picture1.ClientRectangle.Height Then
            NewHeight = Picture1.ClientRectangle.Height
            VScroll1.Visible = False
        Else
            NewHeight = MM
            HFin = Picture1.Top + NewHeight + Command1(0).Top - (Picture1.Top + Picture1.Height) + Command1(0).Height + Trigon.TwipsToPixelsY(200)
            If HScroll1.Visible Then HFin = HFin + HScroll1.Height + Trigon.TwipsToPixelsY(100)
            If HFin > System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height - Trigon.TwipsToPixelsX(1000) Then
                NewHeight = NewHeight - (HFin - System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height - Trigon.TwipsToPixelsX(1000))
                HFin = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height - Trigon.TwipsToPixelsX(1000)
            Else
                ' NewHeight = MM
                VScroll1.Visible = False
            End If
        End If
        dH = Picture1.ClientRectangle.Height - NewHeight
        Picture1.Height = Picture1.Height - dH
        VScroll1.Height = VScroll1.Height - dH
        HScroll1.Top = Picture1.Top + Picture1.Height + Trigon.TwipsToPixelsX(50)
        'If Len(Testo) = 0 Then Height = Height - Picture2.Height - 200
        For i = 0 To 2
            If HScroll1.Visible Then
                Command1(i).Top = VScroll1.Top + VScroll1.Height
            Else
                Command1(i).Top = Picture1.Top + Picture1.Height + Trigon.TwipsToPixelsX(150)
            End If
        Next
        Height = Command1(0).Top + Command1(0).Height + Trigon.TwipsToPixelsX(500)
        'If HScroll1.Visible Then Height = Height + HScroll1.Height + 100
    End Sub

    Private Sub MinMax(ByRef M As Single, ByRef NewWidth As Single, ByRef MM As Single, ByRef NewHeight As Single)
        Dim NewLargeChange As Short
        If HScroll1.Visible Then
            HScroll1.Minimum = NewWidth
            HScroll1.Maximum = (M + HScroll1.LargeChange - 1)
            HScroll1.Value = HScroll1.Minimum
            HScroll1.SmallChange = (M - NewWidth) ^ 2 / M
            NewLargeChange = (M - NewWidth) / 2
            HScroll1.Maximum = HScroll1.Maximum + NewLargeChange - HScroll1.LargeChange
            HScroll1.LargeChange = NewLargeChange
        End If
        If VScroll1.Visible Then
            VScroll1.Minimum = NewHeight
            VScroll1.Maximum = (MM + VScroll1.LargeChange - 1)
            VScroll1.Value = VScroll1.Minimum
            VScroll1.SmallChange = (MM - NewHeight) ^ 2 / MM
            NewLargeChange = (MM - NewHeight) / 2
            VScroll1.Maximum = VScroll1.Maximum + NewLargeChange - VScroll1.LargeChange
            VScroll1.LargeChange = NewLargeChange
        End If
    End Sub

    Private Sub Carica(ByRef M As Single)
        Dim MaxLength As Single
        Dim i As Short
        If Ninput = 0 Then Exit Sub
        Option1(0).Text = Strin(1)
        If CarFissi Then Option1(0).Font = New Font("Courier New", 10)
        gPicture1 = Graphics.FromHwnd(Picture1.Handle)
        MaxLength = gPicture1.MeasureString(Strin(1), Picture1.Font).Width
        For i = 1 To Ninput - 1
            IndexedControls.AddClone(Option1, i)
            AddHandler Option1(i).CheckedChanged, AddressOf Option1_CheckedChanged
            If CarFissi Then Option1(i).Font = New Font("Courier New", 10)
            Option1(i).Top = Option1(i - 1).Top + Option1(i - 1).Height
            Option1(i).Text = Strin(i + 1)
            Option1(i).Visible = True
            M = gPicture1.MeasureString(Strin(i + 1), Picture1.Font).Width
            If M > MaxLength Then MaxLength = M
        Next
        M = MaxLength + Trigon.TwipsToPixelsY(500)
        gPicture1.Dispose()
    End Sub

    Private Sub EspandOpt(ByRef M As Single, ByRef NewWidth As Single)
        Dim dW As Single
        Dim i As Short
        If M <= Option1(0).Width Then
            NewWidth = M
            If NewWidth < 3 * Command1(0).Width Then NewWidth = 3 * Command1(0).Width
            HScroll1.Visible = False
        Else
            NewWidth = M
            If NewWidth + Width - (Option1(0).Width + Left) > System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width Then
                NewWidth = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width - (Width - Option1(0).Width + Left)
            Else
                HScroll1.Visible = False
            End If
        End If
        dW = Option1(0).Width - NewWidth
        For i = 0 To Ninput - 1
            Option1(i).Width = NewWidth
        Next
        Picture1.Width = CInt(Picture1.Width - dW)
        VScroll1.Left = CInt(VScroll1.Left - dW)
        HScroll1.Width = CInt(HScroll1.Width - dW)
        Width = CInt(Width - dW)
    End Sub
    Public Sub Rinfresca()
        Option1(iQ - 1).Checked = True
    End Sub
    Public Sub Costruisci()
        Dim M, MM As Single
        Dim NewWidth, NewHeight As Single
        If Gia Then Exit Sub
        LeftOptOld = Option1(0).Left
        TopOptOld = Option1(0).Top
        If Len(Tit) > 0 Then Text = Tit
        If Len(Testo) = 0 Then
            Picture2.Width = 0
            Picture2.Height = 0
            Picture2.Visible = False
        Else
            Picture2.Visible = True
            If CarFissi Then Picture2.Font = New Font("Courier New", 10)
            gPicture2 = Picture2.CreateGraphics ' Graphics.FromHwnd(Picture2.Handle)
            Picture2.Height = gPicture2.MeasureString(Testo, Picture2.Font).Height + 8
            Picture2.Width = gPicture2.MeasureString(Testo, Picture2.Font).Width + 8
            'gPicture2.Clear(System.Drawing.Color.White)
            'Dim brush As New Drawing.SolidBrush(Color.Black)
            'gPicture2.DrawString(Testo, Picture2.Font, brush, 0, 0)
            Picture2.Text = Testo
            gPicture2.Dispose()
        End If
        Carica(M)
        If Picture2.Width > M Then M = Picture2.Width
        EspandOpt(M, NewWidth)
        Picture1.Top = 0
        VScroll1.Top = 0
        If Len(Testo) > 0 Then
            Picture1.Top = Picture2.Height + Trigon.TwipsToPixelsX(100)
            VScroll1.Top = Picture2.Height + Trigon.TwipsToPixelsY(100)
        End If
        EspandHeight(MM, NewHeight)
        MinMax(M, NewWidth, MM, NewHeight)
        On Error Resume Next
        If iQ And Ninput > 0 Then
            Option1(iQ - 1).Enabled = False
            Option1(iQ - 1).Checked = True
            Option1(iQ - 1).Enabled = True
            iQuale = iQ
        End If
        If Ninput = 0 Then
            Option1(0).Visible = False
            Picture1.Visible = False
        End If
        On Error GoTo 0
        Gia = True
    End Sub
    Private Sub HScroll1_Scroll(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.ScrollEventArgs) Handles HScroll1.Scroll
        Select Case eventArgs.Type
            Case System.Windows.Forms.ScrollEventType.EndScroll
                HScroll1_Change(eventArgs.NewValue)
        End Select
    End Sub
    Private Sub VScroll1_Scroll(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.ScrollEventArgs) Handles VScroll1.Scroll
        Select Case eventArgs.Type
            Case System.Windows.Forms.ScrollEventType.EndScroll
                VScroll1_Change(eventArgs.NewValue)
        End Select
    End Sub
End Class