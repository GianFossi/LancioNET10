Option Strict Off
Option Explicit On
Friend Class frmGrid
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
    Public WithEvents Text1 As System.Windows.Forms.TextBox
	Public WithEvents cmdCancel As System.Windows.Forms.Button
	Public WithEvents cmdOK As System.Windows.Forms.Button
	Public WithEvents Griglia As AxMSFlexGridLib.AxMSFlexGrid
	Public WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents Label1 As System.Windows.Forms.Label
	'NOTA: la routine seguente è richiesta dalla progettazione Windows Form.
	'Può essere modificata utilizzando la finestra di progettazione Windows Form.
	'Non modificarla mediante l'editor di codice.
    Friend WithEvents UpDown1 As System.Windows.Forms.NumericUpDown
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmGrid))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Text1 = New System.Windows.Forms.TextBox
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdOK = New System.Windows.Forms.Button
        Me.Griglia = New AxMSFlexGridLib.AxMSFlexGrid
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.UpDown1 = New System.Windows.Forms.NumericUpDown
        CType(Me.Griglia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Text1
        '
        Me.Text1.AcceptsReturn = True
        Me.Text1.AutoSize = False
        Me.Text1.BackColor = System.Drawing.SystemColors.Window
        Me.Text1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Text1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Text1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text1.Location = New System.Drawing.Point(24, 272)
        Me.Text1.MaxLength = 0
        Me.Text1.Name = "Text1"
        Me.Text1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text1.Size = New System.Drawing.Size(57, 20)
        Me.Text1.TabIndex = 3
        Me.Text1.Text = ""
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCancel.Location = New System.Drawing.Point(104, 264)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCancel.Size = New System.Drawing.Size(57, 25)
        Me.cmdCancel.TabIndex = 2
        Me.cmdCancel.Text = "Cancel"
        '
        'cmdOK
        '
        Me.cmdOK.BackColor = System.Drawing.SystemColors.Control
        Me.cmdOK.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdOK.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdOK.Location = New System.Drawing.Point(176, 264)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdOK.Size = New System.Drawing.Size(57, 25)
        Me.cmdOK.TabIndex = 1
        Me.cmdOK.Text = "OK"
        '
        'Griglia
        '
        Me.Griglia.Location = New System.Drawing.Point(16, 32)
        Me.Griglia.Name = "Griglia"
        Me.Griglia.OcxState = CType(resources.GetObject("Griglia.OcxState"), System.Windows.Forms.AxHost.State)
        Me.Griglia.Size = New System.Drawing.Size(217, 177)
        Me.Griglia.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(16, 216)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(217, 41)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "N.B.: Oggetti con coordinate x e y entrambe nulle sono considerati come inesisten" & _
        "ti."
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Yellow
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label1.Location = New System.Drawing.Point(16, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(129, 17)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "N° di oggetti"
        '
        'UpDown1
        '
        Me.UpDown1.Location = New System.Drawing.Point(176, 8)
        Me.UpDown1.Name = "UpDown1"
        Me.UpDown1.Size = New System.Drawing.Size(48, 20)
        Me.UpDown1.TabIndex = 8
        '
        'frmGrid
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(250, 298)
        Me.ControlBox = False
        Me.Controls.Add(Me.UpDown1)
        Me.Controls.Add(Me.Text1)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.Griglia)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Location = New System.Drawing.Point(2, 22)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmGrid"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "Form1"
        CType(Me.Griglia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
#End Region 
#Region "Supporto aggiornamento "
	Private Shared m_vb6FormDefInstance As frmGrid
	Private Shared m_InitializingDefInstance As Boolean
	Public Shared Property DefInstance() As frmGrid
		Get
			If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
				m_InitializingDefInstance = True
				m_vb6FormDefInstance = New frmGrid()
				m_InitializingDefInstance = False
			End If
			DefInstance = m_vb6FormDefInstance
		End Get
		Set
			m_vb6FormDefInstance = Value
		End Set
	End Property
#End Region 
	Private Nelem As Short
	Private Inret() As Short
	Private NinRet As Short
	Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
		frmGrid.DefInstance.Hide()
	End Sub
    Private Sub cmdOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOK.Click
        Registra()
        Hide()
        SubTraccia(0)
    End Sub
    Private Sub frmGrid_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Dim k, j, i As Short
        Dim delta As Single
        Select Case frmTracciat.DefInstance.FuoriLayOut
            Case 3 : Nelem = DaTos(iDat).ntira
                VediRet()
                For j = 1 To Nelem
                    For k = j + 1 To Nelem
                        If Inret(k) And Not Inret(j) Then
                            For i = 0 To 3
                                GlobalRoutines.SWAP(DaTos(iDat).td(i, j), DaTos(iDat).td(i, k))
                            Next
                        End If
                    Next
                Next
                UpDown1.Minimum = NinRet
            Case 4 : Nelem = DaTos(iDat).Nrod
            Case 6 : Nelem = DaTos(iDat).ISEAL
            Case 7 : UpDown1.Visible = False
        End Select
        Pagina()
        Text1.Enabled = False
        '      If frmTracciat.FuoriLayOut = 3 Then
        '         Griglia.Col = 0
        '         For j = 1 To NinRet
        '            Griglia.Row = j
        '            Griglia.Text = Griglia.Text + " (Ret.)"
        '         Next
        '      End If
        Griglia.Row = 1
        Griglia.Col = Griglia.Cols - 1
        delta = VB6.TwipsToPixelsX(50) + Griglia.Cols * VB6.TwipsToPixelsX(Griglia.CellWidth + 30) - Griglia.Width
        Griglia.Width = Griglia.Width + delta
        Width = Width + delta
        cmdOK.Left = cmdOK.Left + delta
        cmdCancel.Left = cmdCancel.Left + delta
        Griglia.Col = 1
        UpDown1.Text = Str(Nelem)
        '    Text1.Enabled = True
    End Sub

    Private Sub Griglia_ClickEvent(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Griglia.ClickEvent
        Dim Testo As String
        If Text1.Enabled Then Exit Sub
        Text1.Enabled = True
        Text1.Visible = True
        Text1.Width = VB6.TwipsToPixelsX(Griglia.CellWidth)
        Text1.Top = Griglia.Top + VB6.TwipsToPixelsX(Griglia.CellTop)
        Text1.Left = Griglia.Left + VB6.TwipsToPixelsX(Griglia.CellLeft)
        Testo = Griglia.Text
        Text1.Text = Testo
    End Sub
    Private Sub Griglia_EnterCell(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Griglia.EnterCell
        Dim Testo As String
        If Not Text1.Enabled Then Exit Sub
        Text1.Visible = True
        Testo = Griglia.Text
        Text1.Width = VB6.TwipsToPixelsX(Griglia.CellWidth)
        Text1.Top = Griglia.Top + VB6.TwipsToPixelsX(Griglia.CellTop)
        Text1.Left = Griglia.Left + VB6.TwipsToPixelsX(Griglia.CellLeft)
        Text1.Text = Testo
    End Sub

    Private Sub Griglia_LeaveCell(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Griglia.LeaveCell
        Dim ColInput As Short
        Dim x, y As Single
        Dim Rvec, R, diro As Single
        If Not Text1.Enabled Then Exit Sub
        If Len(Text1.Text) Then Griglia.Text = Text1.Text
        Select Case frmTracciat.DefInstance.FuoriLayOut
            Case 3
            Case 4
                '  Text1.Enabled = False
                ColInput = Griglia.Col
                Select Case ColInput
                    Case 1 'x
                        x = Val(Griglia.Text)
                        Griglia.Col = 2
                        y = Val(Griglia.Text)
                        Rvec = System.Math.Sqrt(y * y + Val(Text1.Text) ^ 2)
                        If Rvec < 0.1 Then GoTo Cont
                        R = 180 / Math.PI * GlobalRoutines.arco(x / Rvec, y / Rvec)
                        Griglia.Col = 3
                        Griglia.Text = GlobalRoutines.myStr(R, 5, 2, False)
                    Case 2 'y
                        y = Val(Griglia.Text)
                        Griglia.Col = 1
                        x = Val(Griglia.Text)
                        Rvec = System.Math.Sqrt(x * x + Val(Text1.Text) ^ 2)
                        If Rvec < 0.1 Then GoTo Cont
                        R = 180 / Math.PI * GlobalRoutines.arco(x / Rvec, y / Rvec)
                        Griglia.Col = 3
                        Griglia.Text = GlobalRoutines.myStr(R, 5, 2, False)
                    Case 3 'Anomalia
                        R = Val(Griglia.Text)
                        Griglia.Col = 1
                        x = Val(Griglia.Text)
                        Griglia.Col = 2
                        y = Val(Griglia.Text)
                        '             R = Val(Text1.Text)
                        Rvec = System.Math.Sqrt(x * x + y * y)
                        If Rvec < 0.1 Then
                            Griglia.Col = 4
                            diro = Val(Griglia.Text)
                            Rvec = DaTos(iDat).di1 / 2 - diro / 2
                        End If
                        x = Rvec * System.Math.Cos(R / 180 * Math.PI) : y = Rvec * System.Math.Sin(R / 180 * Math.PI)
                        If System.Math.Abs(x) < 0.1 Then x = 0
                        If System.Math.Abs(y) < 0.1 Then y = 0
                        Griglia.Col = 1
                        Griglia.Text = GlobalRoutines.myStr(x, 5, 2, False)
                        Griglia.Col = 2
                        Griglia.Text = GlobalRoutines.myStr(y, 5, 2, False)
                End Select
Cont:           Griglia.Col = ColInput
                Text1.Enabled = True
        End Select
    End Sub
    Private Sub Griglia_Scroll(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Griglia.Scroll
        Text1.Visible = False
    End Sub

    Private Sub Text1_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles Text1.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Select Case KeyAscii
            Case System.Windows.Forms.Keys.Return
                If Griglia.Col < Griglia.Cols - 1 Then
                    Griglia.Col = Griglia.Col + 1
                ElseIf Griglia.Row < Griglia.Rows - 1 Then
                    Griglia.Row = Griglia.Row + 1
                    Griglia.Col = 1
                Else
                    Griglia.Col = 1
                    Griglia.Row = 1
                End If
            Case System.Windows.Forms.Keys.Up
                If Griglia.Row > UpDown1.Minimum Then Griglia.Row = Griglia.Row - 1
            Case System.Windows.Forms.Keys.Down
                If Griglia.Row < Griglia.Rows - 1 Then Griglia.Row = Griglia.Row + 1
            Case System.Windows.Forms.Keys.Left
                If Griglia.Col > 1 Then Griglia.Col = Griglia.Col - 1
            Case System.Windows.Forms.Keys.Right
                If Griglia.Col < Griglia.Cols - 1 Then Griglia.Col = Griglia.Col + 1
        End Select
    End Sub

    Private Sub Pagina()
        Dim i, k As Short
        Dim delta As Single
        Dim Testo As String
        Static Gia As Boolean
        Text1.Enabled = False
        If Gia Then
            Registra()
        Else
            Gia = True
        End If
        With Griglia
            Select Case frmTracciat.DefInstance.FuoriLayOut
                Case 3 'tirante
                    If Nelem < 1 Then Nelem = 1
                    Text = "Tiranti (n°" & Str(Nelem) & ")"
                    .Rows = Nelem + 1
                    .Cols = 4
                    .Row = 0
                    .Col = 1 : .Text = "x"
                    .Col = 2 : .Text = "y"
                    .Col = 3 : .Text = "Diametro"
                    For i = 1 To .Rows - 1
                        .Row = i
                        For k = 1 To 3
                            .Col = k
                            .Text = GlobalRoutines.myStr(DaTos(iDat).td(k, i), 5, 2, False)
                        Next k
                        .Col = 0 : Testo = Str(i)
                        If frmTracciat.DefInstance.FuoriLayOut = 3 Then
                            If i <= NinRet Then
                                Testo = Testo & " (Ret.)"
                            End If
                        End If
                        .Text = Testo
                    Next i
                Case 4 'tondo
                    If Nelem < 1 Then Nelem = 1
                    Text = "Tondi (n°" & Str(Nelem) & ")"
                    .Rows = Nelem + 1
                    .Cols = 5
                    .Row = 0
                    .Col = 1 : .Text = "x"
                    .Col = 2 : .Text = "y"
                    .Col = 3 : .Text = "Anomalia"
                    .Col = 4 : .Text = "Diametro"
                    For i = 1 To .Rows - 1
                        .Row = i
                        For k = 1 To 4
                            .Col = k
                            If k = 3 Then
                                .Text = GlobalRoutines.myStr(180 / Math.PI * DaTos(iDat).runn(k, i), 5, 2, False)
                            Else
                                .Text = GlobalRoutines.myStr(DaTos(iDat).runn(k, i), 5, 2, False)
                            End If
                        Next k
                        .Col = 0
                        .Text = Str(i)
                    Next i
                Case 6 'S.S.
                    If Nelem < 1 Then Nelem = 1
                    Text = "Sealing Strips (n°" & Str(Nelem) & ")"
                    .Rows = Nelem + 1
                    .Cols = 8
                    .Row = 0
                    .Col = 1 : .Text = "x   =  "
                    .Col = 2 : .Text = "y   =  "
                    .Col = 3 : .Text = "sp  =  "
                    .Col = 4 : .Text = "gap =  "
                    .Col = 5 : .Text = "h   =  "
                    .Col = 6 : .Text = "l   =  "
                    .Col = 7 : .Text = "alfa=  "
                    For i = 1 To .Rows - 1
                        .Row = i
                        For k = 1 To 7
                            .Col = k
                            If k = 7 Then
                                .Text = GlobalRoutines.myStr(180 / Math.PI * DaTos(iDat).seal(k, i), 5, 2, False)
                            Else
                                .Text = GlobalRoutines.myStr(DaTos(iDat).seal(k, i), 5, 2, False)
                            End If
                        Next k
                        .Col = 0
                        .Text = Str(i)
                    Next i
                Case 7
                    Text = "Tagli diaframmi"
                    .Rows = 2
                    Select Case DaTos(iDat).dt(32)
                        Case 0, 1, 5 : .Cols = 3
                        Case Else : .Cols = 5
                    End Select
                    .Row = 0
                    For i = 1 To .Cols - 1
                        .Col = i : .Text = "Dist/CL" & Str(i)
                    Next
                    .Row = 1
                    For k = 1 To .Cols - 1
                        .Col = k
                        .Text = GlobalRoutines.myStr(DaTos(iDat).tagli(k), 5, 2, False)
                    Next k
            End Select
        End With
        UpDown1.Text = Str(Nelem)
        'Griglia.Col = 1
        'Text1.Enabled = True
        'Griglia_EnterCell
    End Sub
    Private Sub VediRet()
        Dim j, k As Short
        Dim isek, H, jti As Short
        ReDim Inret(Nelem)
        Dim xtub, ytub As Single
        NinRet = 0
        For jti = 1 To DaTos(iDat).ntira
            If DaTos(iDat).td(1, jti) <> 0 Or DaTos(iDat).td(2, jti) <> 0 Then
                qualy(DaTos(iDat).td(1, jti), DaTos(iDat).td(2, jti), xtub, ytub, isek, H, j, k)
                If FuoriReticolo = 0 Then
                    Inret(jti) = True
                    NinRet = NinRet + 1
                End If
            End If
        Next jti
    End Sub
    Private Sub Registra()
        Dim i, k As Short
        Text1.Enabled = False
        Griglia.Col = 0
        With Griglia
            Select Case frmTracciat.DefInstance.FuoriLayOut
                Case 3 'tirante
                    DaTos(iDat).ntira = UpDown1.Value
                    For i = 1 To .Rows - 1
                        .Row = i
                        For k = 1 To 3
                            .Col = k
                            DaTos(iDat).td(k, i) = Val(.Text)
                        Next k
                    Next i
                Case 4
                    DaTos(iDat).Nrod = UpDown1.Value
                    DaTos(iDat).dt(36) = DaTos(iDat).Nrod
                    For i = 1 To .Rows - 1
                        .Row = i
                        For k = 1 To 4
                            .Col = k
                            If k = 3 Then
                                DaTos(iDat).runn(k, i) = Math.PI / 180 * Val(.Text)
                            Else
                                DaTos(iDat).runn(k, i) = Val(.Text)
                            End If
                        Next k
                    Next i
                Case 6 'SS
                    DaTos(iDat).ISEAL = UpDown1.Value
                    DaTos(iDat).dt(35) = DaTos(iDat).ISEAL
                    For i = 1 To .Rows - 1
                        .Row = i
                        For k = 1 To 7
                            .Col = k
                            If k = 7 Then
                                DaTos(iDat).seal(k, i) = Math.PI / 180 * Val(.Text)
                            Else
                                DaTos(iDat).seal(k, i) = Val(.Text)
                            End If
                        Next k
                        If DaTos(iDat).seal(10, i) = 0 Then DaTos(iDat).seal(10, i) = -1
                    Next i
                Case 7 'tagli
                    .Row = i
                    On Error Resume Next
                    For k = 1 To 4
                        .Col = k
                        DaTos(iDat).tagli(k) = Val(.Text)
                    Next k
                    On Error GoTo 0
            End Select
        End With

    End Sub
    Private Sub UpDown1_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles UpDown1.ValueChanged
        Nelem = UpDown1.Value
        Pagina()
    End Sub
End Class