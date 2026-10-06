Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class frmBWG
    Inherits System.Windows.Forms.Form
#Region "Codice generato dalla finestra di progettazione Windows Form "
    Public Sub New()
        MyBase.New()
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
    Public WithEvents List2 As System.Windows.Forms.ListBox
    Public WithEvents Combo1 As System.Windows.Forms.ComboBox
    Public WithEvents _Frame1_2 As System.Windows.Forms.GroupBox
    Public WithEvents _Option1_2 As System.Windows.Forms.RadioButton
    Public WithEvents _Option1_1 As System.Windows.Forms.RadioButton
    Public WithEvents _Option1_0 As System.Windows.Forms.RadioButton
    Public WithEvents _Frame1_1 As System.Windows.Forms.GroupBox
    Public WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents _Frame1_0 As System.Windows.Forms.GroupBox
    Public WithEvents Command1 As System.Windows.Forms.Button
    Public WithEvents List1 As System.Windows.Forms.ListBox
    Public WithEvents _Label1_2 As System.Windows.Forms.Label
    Public WithEvents _Label1_1 As System.Windows.Forms.Label
    Public WithEvents _Label1_0 As System.Windows.Forms.Label
    'NOTA: la routine seguente è richiesta dalla progettazione Windows Form.
    'Può essere modificata utilizzando la finestra di progettazione Windows Form.
    'Non modificarla mediante l'editor di codice.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me._Frame1_0 = New System.Windows.Forms.GroupBox
        Me.List2 = New System.Windows.Forms.ListBox
        Me._Frame1_2 = New System.Windows.Forms.GroupBox
        Me.Combo1 = New System.Windows.Forms.ComboBox
        Me._Frame1_1 = New System.Windows.Forms.GroupBox
        Me._Option1_2 = New System.Windows.Forms.RadioButton
        Me._Option1_1 = New System.Windows.Forms.RadioButton
        Me._Option1_0 = New System.Windows.Forms.RadioButton
        Me.Label2 = New System.Windows.Forms.Label
        Me.Command1 = New System.Windows.Forms.Button
        Me.List1 = New System.Windows.Forms.ListBox
        Me._Label1_2 = New System.Windows.Forms.Label
        Me._Label1_1 = New System.Windows.Forms.Label
        Me._Label1_0 = New System.Windows.Forms.Label
        Me._Frame1_0.SuspendLayout()
        Me._Frame1_2.SuspendLayout()
        Me._Frame1_1.SuspendLayout()
        Me.SuspendLayout()
        '
        '_Frame1_0
        '
        Me._Frame1_0.BackColor = System.Drawing.SystemColors.Control
        Me._Frame1_0.Controls.Add(Me.List2)
        Me._Frame1_0.Controls.Add(Me._Frame1_2)
        Me._Frame1_0.Controls.Add(Me._Frame1_1)
        Me._Frame1_0.Controls.Add(Me.Label2)
        Me._Frame1_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Frame1_0.Location = New System.Drawing.Point(200, 8)
        Me._Frame1_0.Name = "_Frame1_0"
        Me._Frame1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Frame1_0.Size = New System.Drawing.Size(201, 177)
        Me._Frame1_0.TabIndex = 5
        Me._Frame1_0.TabStop = False
        Me._Frame1_0.Text = "Raccomandazione RCB-2.21"
        '
        'List2
        '
        Me.List2.BackColor = System.Drawing.SystemColors.Window
        Me.List2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.List2.Cursor = System.Windows.Forms.Cursors.Default
        Me.List2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.List2.Location = New System.Drawing.Point(144, 129)
        Me.List2.Name = "List2"
        Me.List2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.List2.Size = New System.Drawing.Size(41, 28)
        Me.List2.TabIndex = 12
        '
        '_Frame1_2
        '
        Me._Frame1_2.BackColor = System.Drawing.SystemColors.Control
        Me._Frame1_2.Controls.Add(Me.Combo1)
        Me._Frame1_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Frame1_2.Location = New System.Drawing.Point(8, 120)
        Me._Frame1_2.Name = "_Frame1_2"
        Me._Frame1_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Frame1_2.Size = New System.Drawing.Size(129, 49)
        Me._Frame1_2.TabIndex = 10
        Me._Frame1_2.TabStop = False
        Me._Frame1_2.Text = "Diametro del tubo"
        '
        'Combo1
        '
        Me.Combo1.BackColor = System.Drawing.SystemColors.Window
        Me.Combo1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Combo1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Combo1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Combo1.Location = New System.Drawing.Point(16, 19)
        Me.Combo1.Name = "Combo1"
        Me.Combo1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Combo1.Size = New System.Drawing.Size(81, 21)
        Me.Combo1.TabIndex = 11
        '
        '_Frame1_1
        '
        Me._Frame1_1.BackColor = System.Drawing.SystemColors.Control
        Me._Frame1_1.Controls.Add(Me._Option1_2)
        Me._Frame1_1.Controls.Add(Me._Option1_1)
        Me._Frame1_1.Controls.Add(Me._Option1_0)
        Me._Frame1_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Frame1_1.Location = New System.Drawing.Point(8, 24)
        Me._Frame1_1.Name = "_Frame1_1"
        Me._Frame1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Frame1_1.Size = New System.Drawing.Size(177, 81)
        Me._Frame1_1.TabIndex = 6
        Me._Frame1_1.TabStop = False
        Me._Frame1_1.Text = "Tipo di materiale"
        '
        '_Option1_2
        '
        Me._Option1_2.BackColor = System.Drawing.SystemColors.Control
        Me._Option1_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option1_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Option1_2.Location = New System.Drawing.Point(8, 56)
        Me._Option1_2.Name = "_Option1_2"
        Me._Option1_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option1_2.Size = New System.Drawing.Size(161, 17)
        Me._Option1_2.TabIndex = 9
        Me._Option1_2.TabStop = True
        Me._Option1_2.Text = "Altre leghe"
        '
        '_Option1_1
        '
        Me._Option1_1.BackColor = System.Drawing.SystemColors.Control
        Me._Option1_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option1_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Option1_1.Location = New System.Drawing.Point(8, 40)
        Me._Option1_1.Name = "_Option1_1"
        Me._Option1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option1_1.Size = New System.Drawing.Size(161, 17)
        Me._Option1_1.TabIndex = 8
        Me._Option1_1.TabStop = True
        Me._Option1_1.Text = "Acciaio al C e Alluminio"
        '
        '_Option1_0
        '
        Me._Option1_0.BackColor = System.Drawing.SystemColors.Control
        Me._Option1_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option1_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Option1_0.Location = New System.Drawing.Point(8, 24)
        Me._Option1_0.Name = "_Option1_0"
        Me._Option1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option1_0.Size = New System.Drawing.Size(161, 17)
        Me._Option1_0.TabIndex = 7
        Me._Option1_0.TabStop = True
        Me._Option1_0.Text = "Rame e leghe di rame"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(0, Byte))
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label2.Location = New System.Drawing.Point(144, 112)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(41, 15)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "BWG"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Command1
        '
        Me.Command1.BackColor = System.Drawing.SystemColors.Control
        Me.Command1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command1.Location = New System.Drawing.Point(10, 168)
        Me.Command1.Name = "Command1"
        Me.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command1.Size = New System.Drawing.Size(181, 21)
        Me.Command1.TabIndex = 4
        Me.Command1.Text = "&OK"
        '
        'List1
        '
        Me.List1.BackColor = System.Drawing.SystemColors.Window
        Me.List1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.List1.Cursor = System.Windows.Forms.Cursors.Default
        Me.List1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.List1.Location = New System.Drawing.Point(10, 30)
        Me.List1.Name = "List1"
        Me.List1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.List1.Size = New System.Drawing.Size(181, 132)
        Me.List1.TabIndex = 3
        '
        '_Label1_2
        '
        Me._Label1_2.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(0, Byte))
        Me._Label1_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._Label1_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_2.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Label1_2.Location = New System.Drawing.Point(120, 10)
        Me._Label1_2.Name = "_Label1_2"
        Me._Label1_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_2.Size = New System.Drawing.Size(71, 21)
        Me._Label1_2.TabIndex = 2
        Me._Label1_2.Text = "Sp. (mm)"
        Me._Label1_2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        '_Label1_1
        '
        Me._Label1_1.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(0, Byte))
        Me._Label1_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._Label1_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Label1_1.Location = New System.Drawing.Point(50, 10)
        Me._Label1_1.Name = "_Label1_1"
        Me._Label1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_1.Size = New System.Drawing.Size(71, 21)
        Me._Label1_1.TabIndex = 1
        Me._Label1_1.Text = "Sp. (in)"
        Me._Label1_1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        '_Label1_0
        '
        Me._Label1_0.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(0, Byte))
        Me._Label1_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._Label1_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Label1_0.Location = New System.Drawing.Point(10, 10)
        Me._Label1_0.Name = "_Label1_0"
        Me._Label1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_0.Size = New System.Drawing.Size(41, 21)
        Me._Label1_0.TabIndex = 0
        Me._Label1_0.Text = "BWG"
        Me._Label1_0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'BWG
        '
        Me.AcceptButton = Me.Command1
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.ClientSize = New System.Drawing.Size(410, 197)
        Me.ControlBox = False
        Me.Controls.Add(Me._Frame1_0)
        Me.Controls.Add(Me.Command1)
        Me.Controls.Add(Me.List1)
        Me.Controls.Add(Me._Label1_2)
        Me.Controls.Add(Me._Label1_1)
        Me.Controls.Add(Me._Label1_0)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.ForeColor = System.Drawing.SystemColors.WindowText
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Location = New System.Drawing.Point(214, 92)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "BWG"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Scelta BWG"
        Me._Frame1_0.ResumeLayout(False)
        Me._Frame1_2.ResumeLayout(False)
        Me._Frame1_1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
#End Region
    Public objBWG As clsBWG
    Private Inizializzando As Boolean
    Private Sub CambiaList2()
        Dim i, j As Short
        List2.Visible = True
        Label2.Visible = True
        i = Combo1.SelectedIndex
        If i < 0 Then Exit Sub
        j = objBWG.TipoMat
        'If j < 2 Then If j = 0 Then j = 1 Else j = 0
        Call FillList2(i, j)
    End Sub
    Private Sub Combo1_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Combo1.SelectedIndexChanged
        objBWG.Diam = objBWG.DiamSt(Combo1.SelectedIndex)
        Call CambiaList2()
    End Sub
    Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
        Hide()
        ' DatiPrg(0).TubiInform.Diam = Val(DataShe1.ValorM(13))
        ' DatiPrg(0).TubiInform.Spess = Val(DataShe1.ValorM(14))
        ' DatiPrg(0).TubiInform.BWG = Val(DataShe1.TextBWG.Text)
    End Sub
    Private Sub FillList2(ByRef i As Short, ByRef k As Short)
        Dim j As Short
        List2.Items.Clear()
        If objBWG.RCB221(i, k, 0) = 0 Then
            List2.Items.Add("--")
        Else
            For j = 0 To 3
                If objBWG.RCB221(i, k, j) = 0 Then Exit For
                List2.Items.Add(Str(objBWG.RCB221(i, k, j)))
            Next
        End If
    End Sub
    Private Sub BWG_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
        Dim BWG As String
        Dim Spmm As Single
        Dim n, i As Short
        Dim Spin As Single
        Dim SP, Sp1 As String
        Dim Dist As Single
        Dim imin As Short
        List2.Visible = False
        Label2.Visible = False
        List1.Items.Clear()
        For i = 0 To UBound(objBWG.SpBWG, 1)
            BWG = objBWG.SpBWG(i, 1).ToString
            SP = objBWG.SpBWG(i, 0).ToString
            Spin = objBWG.SpBWG(i, 0)
            Spmm = Spin * 25.4
            Sp1 = Spmm.ToString
            'n = InStr(Sp1, ".") : l = Len(Sp1)
            'If l > n + 3 Then Sp1 = Sp1.Substring(0, n + 3)
            List1.Items.Add(BWG & Chr(9) & " " & SP & Chr(9) & "  " & Sp1)
        Next
        If objBWG.BWG > 0 Then
            For i = 0 To List1.Items.Count - 1
                If Val(CStr(List1.Items(i)).Substring(0, 3)) = objBWG.BWG Then
                    List1.SelectedIndex = i
                    Exit For
                End If
            Next
        End If
        Combo1.Items.Clear()
        For i = 0 To UBound(objBWG.DiamInch)
            Combo1.Items.Add(objBWG.DiamInch(i))
            If System.Math.Abs(objBWG.DiamSt(i) - objBWG.Diam) < 0.1 Then
                Combo1.SelectedIndex = i
                Call FillList2(i, (objBWG.TipoMat))
            End If
        Next
        Option1(objBWG.TipoMat).Checked = True
        Dist = 1000
        For i = 0 To List1.Items.Count - 1
            n = CStr(List1.Items(i)).IndexOf(Chr(9)) - 1
            SP = CStr(List1.Items(i)).Substring(n + 1)
            n = SP.IndexOf(Chr(9)) - 1
            SP = SP.Substring(n + 1)
            Spmm = Funzioni.ValVir(SP)
            If (Spmm - objBWG.Spess) ^ 2 < Dist Then
                Dist = (Spmm - objBWG.Spess) ^ 2
                imin = i
            End If
        Next
        BWG = CStr(List1.Items(imin)).Substring(0, 2)
        For i = 0 To List2.Items.Count - 1
            If CStr(List2.Items(i)).Trim = BWG.Trim Then
                List2.SelectedIndex = i
                Exit For
            End If
        Next
        If Combo1.SelectedIndex = -1 Then Combo1.SelectedIndex = 0
    End Sub
    Private Sub List1_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles List1.SelectedIndexChanged
        If Inizializzando Then Exit Sub
        objBWG.Spess = objBWG.SpBWG(List1.SelectedIndex, 0)
        objBWG.TextBWG = CStr(List1.SelectedItem).Substring(0, 3)
        objBWG.BWG = Val(objBWG.TextBWG)
    End Sub
    Private Sub List2_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles List2.SelectedIndexChanged
        If Inizializzando Then Exit Sub
        Dim BWG, i As Short
        BWG = Val(CStr(List2.SelectedItem))
        If BWG = 0 Then Exit Sub
        For i = 0 To List1.Items.Count - 1
            If Val(CStr(List1.Items(i)).Substring(0, 3)) = BWG Then
                List1.SelectedIndex = i
                Exit Sub
            End If
        Next

    End Sub
    Private Sub Option1_CheckedChanged(ByVal Index As Short)
        If Option1(Index).Checked Then
            objBWG.TipoMat = Index
            Call CambiaList2()
        End If
    End Sub
    Private Function Option1(ByVal Index As Short) As RadioButton
        Select Case Index
            Case 0 : Return _Option1_0
            Case 1 : Return _Option1_1
            Case 2 : Return _Option1_2
            Case Else : Return Nothing
        End Select
    End Function
    Private Sub _Option1_0_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Option1_0.CheckedChanged
        Option1_CheckedChanged(0)
    End Sub
    Private Sub _Option1_1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Option1_1.CheckedChanged
        Option1_CheckedChanged(1)
    End Sub
    Private Sub _Option1_2_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Option1_2.CheckedChanged
        Option1_CheckedChanged(2)
    End Sub
End Class