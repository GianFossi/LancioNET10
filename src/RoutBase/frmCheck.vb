Option Strict On
Option Explicit On 
Imports System.Windows.Forms
Public Class frmCheck
    Inherits System.Windows.Forms.Form
#Region "Codice generato dalla finestra di progettazione Windows Form "
    Public Sub New()
        MyBase.New()
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
    Public WithEvents _Command1_0 As System.Windows.Forms.Button
    Public WithEvents _Command1_1 As System.Windows.Forms.Button
    Public WithEvents _Command1_2 As System.Windows.Forms.Button
    Public WithEvents VScroll1 As System.Windows.Forms.VScrollBar
    Public WithEvents HScroll1 As System.Windows.Forms.HScrollBar
    Public WithEvents _Text1_0 As System.Windows.Forms.TextBox
    Public WithEvents _Check1_0 As System.Windows.Forms.CheckBox
    Public WithEvents Picture1 As System.Windows.Forms.Panel
    Public Check1 As New System.Collections.Generic.Dictionary(Of Integer, CheckBox)
    Public Command1 As New System.Collections.Generic.Dictionary(Of Integer, Button)
    Public Text1 As New System.Collections.Generic.Dictionary(Of Integer, TextBox)
    'NOTA: la routine seguente è richiesta dalla progettazione Windows Form.
    'Può essere modificata utilizzando la finestra di progettazione Windows Form.
    'Non modificarla mediante l'editor di codice.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me._Command1_0 = New System.Windows.Forms.Button
        Me._Command1_1 = New System.Windows.Forms.Button
        Me._Command1_2 = New System.Windows.Forms.Button
        Me.VScroll1 = New System.Windows.Forms.VScrollBar
        Me.HScroll1 = New System.Windows.Forms.HScrollBar
        Me.Picture1 = New System.Windows.Forms.Panel
        Me._Text1_0 = New System.Windows.Forms.TextBox
        Me._Check1_0 = New System.Windows.Forms.CheckBox
        Me.Picture1.SuspendLayout()
        Me.SuspendLayout()
        '
        '_Command1_0
        '
        Me._Command1_0.BackColor = System.Drawing.SystemColors.Control
        Me._Command1_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Command1_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command1.Add(0, Me._Command1_0)
        Me._Command1_0.Location = New System.Drawing.Point(160, 56)
        Me._Command1_0.Name = "_Command1_0"
        Me._Command1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Command1_0.Size = New System.Drawing.Size(73, 25)
        Me._Command1_0.TabIndex = 7
        Me._Command1_0.Text = "OK"
        '
        '_Command1_1
        '
        Me._Command1_1.BackColor = System.Drawing.SystemColors.Control
        Me._Command1_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._Command1_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command1.Add(1, Me._Command1_1)
        Me._Command1_1.Location = New System.Drawing.Point(232, 56)
        Me._Command1_1.Name = "_Command1_1"
        Me._Command1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Command1_1.Size = New System.Drawing.Size(73, 25)
        Me._Command1_1.TabIndex = 6
        Me._Command1_1.Text = "Cancel"
        '
        '_Command1_2
        '
        Me._Command1_2.BackColor = System.Drawing.SystemColors.Control
        Me._Command1_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._Command1_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command1.Add(2, Me._Command1_2)
        Me._Command1_2.Location = New System.Drawing.Point(304, 56)
        Me._Command1_2.Name = "_Command1_2"
        Me._Command1_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Command1_2.Size = New System.Drawing.Size(73, 25)
        Me._Command1_2.TabIndex = 5
        Me._Command1_2.Text = "Help"
        '
        'VScroll1
        '
        Me.VScroll1.Cursor = System.Windows.Forms.Cursors.Default
        Me.VScroll1.LargeChange = 1
        Me.VScroll1.Location = New System.Drawing.Point(376, 0)
        Me.VScroll1.Maximum = 32767
        Me.VScroll1.Name = "VScroll1"
        Me.VScroll1.Size = New System.Drawing.Size(17, 33)
        Me.VScroll1.TabIndex = 4
        Me.VScroll1.TabStop = True
        '
        'HScroll1
        '
        Me.HScroll1.Cursor = System.Windows.Forms.Cursors.Default
        Me.HScroll1.LargeChange = 1
        Me.HScroll1.Location = New System.Drawing.Point(8, 32)
        Me.HScroll1.Maximum = 32767
        Me.HScroll1.Name = "HScroll1"
        Me.HScroll1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HScroll1.Size = New System.Drawing.Size(369, 17)
        Me.HScroll1.TabIndex = 3
        Me.HScroll1.TabStop = True
        '
        'Picture1
        '
        Me.Picture1.BackColor = System.Drawing.SystemColors.Control
        Me.Picture1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Picture1.Controls.Add(Me._Text1_0)
        Me.Picture1.Controls.Add(Me._Check1_0)
        Me.Picture1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Picture1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Picture1.Location = New System.Drawing.Point(8, 0)
        Me.Picture1.Name = "Picture1"
        Me.Picture1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Picture1.Size = New System.Drawing.Size(369, 33)
        Me.Picture1.TabIndex = 0
        Me.Picture1.TabStop = True
        '
        '_Text1_0
        '
        Me._Text1_0.AcceptsReturn = True
        Me._Text1_0.AutoSize = False
        Me._Text1_0.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text1.Add(0, Me._Text1_0)
        Me._Text1_0.Location = New System.Drawing.Point(24, 4)
        Me._Text1_0.MaxLength = 0
        Me._Text1_0.Name = "_Text1_0"
        Me._Text1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_0.Size = New System.Drawing.Size(337, 20)
        Me._Text1_0.TabIndex = 2
        Me._Text1_0.Text = ""
        '
        '_Check1_0
        '
        Me._Check1_0.BackColor = System.Drawing.SystemColors.Control
        Me._Check1_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Check1_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Check1.Add(0, Me._Check1_0)
        Me._Check1_0.Location = New System.Drawing.Point(7, 4)
        Me._Check1_0.Name = "_Check1_0"
        Me._Check1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Check1_0.Size = New System.Drawing.Size(17, 17)
        Me._Check1_0.TabIndex = 1
        '
        'Check1
        '
        '
        'Command1
        '
        '
        'frmCheck
        '
        Me.AcceptButton = Me._Command1_0
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(398, 87)
        Me.ControlBox = False
        Me.Controls.Add(Me._Command1_0)
        Me.Controls.Add(Me._Command1_1)
        Me.Controls.Add(Me._Command1_2)
        Me.Controls.Add(Me.VScroll1)
        Me.Controls.Add(Me.HScroll1)
        Me.Controls.Add(Me.Picture1)
        Me.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Location = New System.Drawing.Point(2, 22)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCheck"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Form1"
        Me.Picture1.ResumeLayout(False)
        For Each control In Check1.Values
            AddHandler control.CheckStateChanged, AddressOf Check1_CheckStateChanged
        Next
        For Each control In Command1.Values
            AddHandler control.Click, AddressOf Command1_Click
        Next

        Me.ResumeLayout(False)

    End Sub
#End Region
    Public Motore As RoutBase1.clsMotore
    Friend Ninput As Short
    Public Tit As String
    Public Aiuto As String
    Public IDH As Integer
    Public strIDH As String
    Public Nfin As Short
    Public NonMostrare As Boolean
    Friend Gia As Boolean
    Public chkCancel As Boolean
    Private LeftCheckOld As Single
    Private LeftTextOld As Single
    Private TopCheckOld As Single
    Private TopTextOld As Single
    Event OKClick()
    Event CancelClick()
    Event CheckClick(ByRef indice As Short)
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

    'UPGRADE_WARNING: L'evento Check1.CheckStateChanged può essere generato quando il form è inizializzato. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup2075"'
    Private Sub Check1_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Dim Index As Short = IndexedControls.IndexOf(Check1, CType(eventSender, CheckBox))
        Risult(Index + 1) = Check1(Index).CheckState = CheckState.Checked
        If Gia Then
            Select Case Nfin
                Case 0
                Case Else : RaiseEvent CheckClick(CShort(Index + 1))
            End Select
        End If
    End Sub

    Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Dim Index As Short = IndexedControls.IndexOf(Command1, CType(eventSender, Button))
        Select Case Index
            Case 0
                If Nfin > 0 Then
                    RaiseEvent OKClick()
                Else
                    Hide()
                End If
                Gia = False
            Case 1
                If Nfin > 0 Then
                    RaiseEvent CancelClick()
                Else
                    chkCancel = True : Hide()
                End If
                Gia = False
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
    Public Sub Aggiorna()
        Dim NewLargeChange As Short
        Dim i As Short
        Dim MaxLength As Single
        Dim dW, M, dH As Single
        Dim NewWidth, NewHeight As Single
        Dim MM As Single
        If Gia Then Exit Sub
        LeftTextOld = Text1(0).Left
        TopTextOld = Text1(0).Top
        LeftCheckOld = Check1(0).Left
        TopCheckOld = Check1(0).Top
        Text = Tit
        Text1(0).Text = Strin(1)
        Try
            Dim gPicture1 As Graphics = Picture1.CreateGraphics
            MaxLength = gPicture1.MeasureString(Strin(1), Picture1.Font).Width
            For i = 1 To CShort(Ninput - 1)
                IndexedControls.AddClone(Check1, i)
                AddHandler Check1(i).CheckStateChanged, AddressOf Check1_CheckStateChanged
                IndexedControls.AddClone(Text1, i)
                Check1(i).Top = Check1(CShort(i - 1)).Top + Text1(CShort(i - 1)).Height
                Text1(i).Top = Text1(CShort(i - 1)).Top + Text1(CShort(i - 1)).Height
                Text1(i).Text = Strin(i + 1)
                M = gPicture1.MeasureString(Strin(i + 1), Picture1.Font).Width
                If M > MaxLength Then MaxLength = M
                If Risult(i + 1) Then
                    Check1(i).CheckState = CheckState.Checked
                Else
                    Check1(i).CheckState = CheckState.Unchecked
                End If
                Check1(i).Visible = True
                Text1(i).Visible = True
            Next
            gPicture1.Dispose()
            If Risult(1) Then
                Check1(0).CheckState = CheckState.Checked
            Else
                Check1(0).CheckState = CheckState.Unchecked
            End If
            M = MaxLength
            If M <= Text1(0).Width Then
                NewWidth = M : If NewWidth < 3 * Command1(0).Width Then NewWidth = 3 * Command1(0).Width
                HScroll1.Visible = False
            Else
                NewWidth = M
                If NewWidth + Width - Text1(0).Width + Left > System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width Then
                    NewWidth = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width - (Width - Text1(0).Width + Left)
                End If
                HScroll1.Visible = False
            End If
            dW = Text1(0).Width - NewWidth
            For i = 0 To CShort(Ninput - 1)
                Text1(i).Width = CInt(NewWidth)
            Next
            Picture1.Width = CInt(Picture1.Width - dW)
            VScroll1.Left = CInt(VScroll1.Left - dW)
            HScroll1.Width = CInt(HScroll1.Width - dW)
            Width = CInt(Width - dW)
            For i = 0 To 2
                Command1(i).Left = CInt(Command1(i).Left - dW)
            Next
            MM = Text1(CShort(Ninput - 1)).Top + Text1(CShort(Ninput - 1)).Height
            If MM <= Picture1.ClientRectangle.Height Then
                NewHeight = MM
                VScroll1.Visible = False
            Else
                NewHeight = CSng(Picture1.Top + MM + Command1(0).Top - (Picture1.Top + Picture1.Height) + Command1(0).Height + Trigon.TwipsToPixelsX(200))
                If HScroll1.Visible Then NewHeight = NewHeight + HScroll1.Height
                If NewHeight > System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height - Trigon.TwipsToPixelsY(400) Then
                    NewHeight = CSng(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height - (NewHeight - MM) - Trigon.TwipsToPixelsY(400))
                Else
                    NewHeight = MM
                    VScroll1.Visible = False
                End If
            End If
            dH = Picture1.ClientRectangle.Height - NewHeight
            Picture1.Height = CInt(Picture1.Height - dH)
            VScroll1.Height = CInt(VScroll1.Height - dH)
            HScroll1.Top = CInt(HScroll1.Top - dH)
            For i = 0 To 2
                Command1(i).Top = CInt(Command1(i).Top - dH)
                If Not HScroll1.Visible Then Command1(i).Top = CInt(Command1(i).Top - HScroll1.Height)
            Next
            Height = SystemInformation.CaptionHeight + Command1(0).Top + Command1(0).Height + 2 * SystemInformation.Border3DSize.Height + 8 ' CInt(Height - dH)
            If HScroll1.Visible Then
                HScroll1.Minimum = CInt(NewWidth)
                HScroll1.Maximum = CInt(M + HScroll1.LargeChange - 1)
                HScroll1.Value = HScroll1.Minimum
                HScroll1.SmallChange = CInt((M - NewWidth) ^ 2 / M)
                NewLargeChange = CShort((M - NewWidth) / 2)
                HScroll1.Maximum = HScroll1.Maximum + NewLargeChange - HScroll1.LargeChange
                HScroll1.LargeChange = NewLargeChange
            End If
            If VScroll1.Visible Then
                VScroll1.Minimum = CInt(NewHeight)
                VScroll1.Maximum = CInt(MM + VScroll1.LargeChange - 1)
                VScroll1.Value = VScroll1.Minimum
                VScroll1.SmallChange = CInt((MM - NewHeight) ^ 2 / MM)
                NewLargeChange = CShort((MM - NewHeight) / 2)
                VScroll1.Maximum = VScroll1.Maximum + NewLargeChange - VScroll1.LargeChange
                VScroll1.LargeChange = NewLargeChange
            End If
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
        Gia = True
        If Aiuto Is Nothing Then Aiuto = ""
        If strIDH Is Nothing Then strIDH = ""
        If Aiuto.Trim.Length = 0 And strIDH.Length = 0 Then Command1(2).Visible = False
    End Sub
    Private Sub HScroll1_Change(ByVal newScrollValue As Integer)
        Dim delta As Single
        Dim i As Short
        delta = newScrollValue - HScroll1.Minimum
        For i = 0 To CShort(Ninput - 1)
            Check1(i).Left = CInt(LeftCheckOld - delta)
            Text1(i).Left = CInt(LeftTextOld - delta)
        Next
    End Sub
    Private Sub VScroll1_Change(ByVal newScrollValue As Integer)
        Dim delta As Single
        Dim i As Short
        delta = newScrollValue - VScroll1.Minimum
        Check1(0).Top = CInt(TopCheckOld - delta)
        Text1(0).Top = CInt(TopTextOld - delta)
        For i = 1 To CShort(Ninput - 1)
            Check1(i).Top = (Check1(CShort(i - 1)).Top + Text1(CShort(i - 1)).Height)
            Text1(i).Top = Text1(CShort(i - 1)).Top + Text1(CShort(i - 1)).Height
        Next
    End Sub
    Public Property pRisult(ByVal i As Short) As Boolean
        Get
            pRisult = Risult(i)
        End Get
        Set(ByVal Value As Boolean)
            Try
                Risult(i) = Value
            Catch e As Exception
                MsgBox(e.Message + vbCrLf + e.StackTrace)
            End Try
        End Set
    End Property
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
    Private Sub frmCheck_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    End Sub
End Class