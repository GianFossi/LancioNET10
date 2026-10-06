Option Strict Off
Option Explicit On
Friend Class frmGridn
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
    Public WithEvents cmdCancel As System.Windows.Forms.Button
    Public WithEvents cmdOK As System.Windows.Forms.Button
    Public WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents Label1 As System.Windows.Forms.Label
    'NOTA: la routine seguente è richiesta dalla progettazione Windows Form.
    'Può essere modificata utilizzando la finestra di progettazione Windows Form.
    'Non modificarla mediante l'editor di codice.
    Friend WithEvents UpDown1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DataGridTextBoxColumn1 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn2 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents Grid As System.Windows.Forms.DataGrid
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdOK = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.UpDown1 = New System.Windows.Forms.NumericUpDown
        Me.Grid = New System.Windows.Forms.DataGrid
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle
        Me.DataGridTextBoxColumn1 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn2 = New System.Windows.Forms.DataGridTextBoxColumn
        CType(Me.UpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        'Grid
        '
        Me.Grid.DataMember = ""
        Me.Grid.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.Grid.Location = New System.Drawing.Point(16, 32)
        Me.Grid.Name = "Grid"
        Me.Grid.Size = New System.Drawing.Size(208, 176)
        Me.Grid.TabIndex = 9
        Me.Grid.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.DataGrid = Me.Grid
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DataGridTextBoxColumn1, Me.DataGridTextBoxColumn2})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = ""
        '
        'DataGridTextBoxColumn1
        '
        Me.DataGridTextBoxColumn1.Format = ""
        Me.DataGridTextBoxColumn1.FormatInfo = Nothing
        Me.DataGridTextBoxColumn1.HeaderText = "a"
        Me.DataGridTextBoxColumn1.MappingName = ""
        Me.DataGridTextBoxColumn1.Width = 75
        '
        'DataGridTextBoxColumn2
        '
        Me.DataGridTextBoxColumn2.Format = ""
        Me.DataGridTextBoxColumn2.FormatInfo = Nothing
        Me.DataGridTextBoxColumn2.HeaderText = "b"
        Me.DataGridTextBoxColumn2.MappingName = ""
        Me.DataGridTextBoxColumn2.Width = 75
        '
        'frmGridn
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(250, 298)
        Me.ControlBox = False
        Me.Controls.Add(Me.Grid)
        Me.Controls.Add(Me.UpDown1)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Location = New System.Drawing.Point(2, 22)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmGridn"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "Form1"
        CType(Me.UpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
#End Region
#Region "Supporto aggiornamento "
    Private Shared m_vb6FormDefInstance As frmGridn
    Private Shared m_InitializingDefInstance As Boolean
    Public Shared Property DefInstance() As frmGridn
        Get
            If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
                m_InitializingDefInstance = True
                m_vb6FormDefInstance = New frmGridn
                m_InitializingDefInstance = False
            End If
            DefInstance = m_vb6FormDefInstance
        End Get
        Set(ByVal Value As frmGridn)
            m_vb6FormDefInstance = Value
        End Set
    End Property
#End Region
    Private WithEvents tGriglia As DataTable
    Private dview As DataView
    Private VecchiaCella As DataGridCell
    Private Nelem As Short
    Private Inret() As Short
    Private NinRet As Short
    Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
        Hide()
    End Sub
    Private Sub cmdOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOK.Click
        Registra()
        Hide()
        SubTraccia(0)
    End Sub
    Private Sub frmGrid_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Dim k, j, i As Short
        Dim delta As Single
        Select Case MainForm.FuoriLayOut
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
        Try
            tGriglia = New DataTable("Griglia")
            Pagina()
            dview = New DataView(tGriglia)
            dview.AllowNew = False
            dview.AllowDelete = False
            dview.AllowEdit = True
            Grid.SetDataBinding(dview, "")
            delta = GlobalRoutines.TwipsToPixelsX(50) + tGriglia.Columns.Count * (Grid.PreferredColumnWidth + 2) - Grid.Width
            Grid.Width = Grid.Width + delta
            Width = Width + delta
            cmdOK.Left = cmdOK.Left + delta
            cmdCancel.Left = cmdCancel.Left + delta
            UpDown1.Text = Str(Nelem)
        Catch e As Exception
            MsgBox(e.Message & e.StackTrace)
        End Try
    End Sub
    Private Sub Pagina()
        Dim i As Short
        Dim Testo As String
        Static Gia As Boolean
        If Gia Then
            Registra()
        Else
            Gia = True
        End If
        With tGriglia
            .Clear()
            .Columns.Clear()
            .Rows.Clear()
            Try
                Select Case MainForm.FuoriLayOut
                    Case 3 'tirante
                        If Nelem < 1 Then Nelem = 1
                        Text = "Tiranti (n°" & Str(Nelem) & ")"
                        .Columns.Add(" ", Type.GetType("System.String"))
                        .Columns.Add("x", Type.GetType("System.Single"))
                        .Columns.Add("y", Type.GetType("System.Single"))
                        .Columns.Add("Diametro", Type.GetType("System.Single"))
                        For i = 1 To Nelem
                            Testo = i.ToString
                            If MainForm.FuoriLayOut = 3 Then
                                If i <= NinRet Then
                                    Testo = Testo & " (Ret.)"
                                End If
                            End If
                            .Rows.Add(New Object() {Testo, DaTos(iDat).td(1, i), DaTos(iDat).td(2, i), DaTos(iDat).td(3, i)})
                        Next i
                    Case 4 'tondo
                        If Nelem < 1 Then Nelem = 1
                        Text = "Tondi (n°" & Str(Nelem) & ")"
                        .Columns.Add(" ", Type.GetType("System.String"))
                        .Columns.Add("x", Type.GetType("System.Single"))
                        .Columns.Add("y", Type.GetType("System.Single"))
                        .Columns.Add("Anomalia", Type.GetType("System.Single"))
                        .Columns.Add("Diametro", Type.GetType("System.Single"))
                        For i = 1 To Nelem
                            .Rows.Add(New Object() {i.ToString, DaTos(iDat).runn(1, i), _
                                                                DaTos(iDat).runn(2, i), _
                                                180 / Math.PI * DaTos(iDat).runn(3, i), _
                                                                DaTos(iDat).runn(4, i)})
                        Next i
                    Case 6 'S.S.
                        If Nelem < 1 Then Nelem = 1
                        Text = "Sealing Strips (n°" & Str(Nelem) & ")"
                        .Columns.Add(" ", Type.GetType("System.String"))
                        .Columns.Add("x   =  ", Type.GetType("System.Single"))
                        .Columns.Add("y   =  ", Type.GetType("System.Single"))
                        .Columns.Add("sp  =  ", Type.GetType("System.Single"))
                        .Columns.Add("gap =  ", Type.GetType("System.Single"))
                        .Columns.Add("h   =  ", Type.GetType("System.Single"))
                        .Columns.Add("l   =  ", Type.GetType("System.Single"))
                        .Columns.Add("alfa=  ", Type.GetType("System.Single"))
                        For i = 1 To Nelem
                            .Rows.Add(New Object() {i.ToString, DaTos(iDat).seal(1, i), _
                                                                DaTos(iDat).seal(2, i), _
                                                                DaTos(iDat).seal(3, i), _
                                                                DaTos(iDat).seal(4, i), _
                                                                DaTos(iDat).seal(5, i), _
                                                                DaTos(iDat).seal(6, i), _
                                                180 / Math.PI * DaTos(iDat).seal(7, i)})
                        Next i
                    Case 7
                        Text = "Tagli diaframmi"
                        .Columns.Add(" ", Type.GetType("System.String"))
                        .Columns.Add("Dist/CL 1", Type.GetType("System.Single"))
                        .Columns.Add("Dist/CL 2", Type.GetType("System.Single"))
                        Select Case DaTos(iDat).dt(32)
                            Case 0, 1, 5
                                .Rows.Add(New Object() {"", DaTos(iDat).tagli(1), _
                                                            DaTos(iDat).tagli(2)})
                            Case Else
                                .Columns.Add("Dist/CL 3", Type.GetType("System.Single"))
                                .Columns.Add("Dist/CL 4", Type.GetType("System.Single"))
                                .Rows.Add(New Object() {"", DaTos(iDat).tagli(1), _
                                                            DaTos(iDat).tagli(2), _
                                                            DaTos(iDat).tagli(3), _
                                                            DaTos(iDat).tagli(4)})
                        End Select
                End Select
            Catch e As Exception
                MsgBox(e.Message & e.StackTrace)
            End Try
        End With
        UpDown1.Text = Str(Nelem)
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
        With tGriglia
            Select Case MainForm.FuoriLayOut
                Case 3 'tirante
                    DaTos(iDat).ntira = UpDown1.Value
                    For i = 1 To .Rows.Count
                        For k = 1 To 3
                            DaTos(iDat).td(k, i) = .Rows(i - 1)(k)
                        Next k
                    Next i
                Case 4
                    DaTos(iDat).Nrod = UpDown1.Value
                    DaTos(iDat).dt(36) = DaTos(iDat).Nrod
                    For i = 1 To .Rows.Count
                        For k = 1 To 4
                            If k = 3 Then
                                DaTos(iDat).runn(k, i) = Math.PI / 180 * .Rows(i - 1)(k)
                            Else
                                DaTos(iDat).runn(k, i) = .Rows(i - 1)(k)
                            End If
                        Next k
                    Next i
                Case 6 'SS
                    DaTos(iDat).ISEAL = UpDown1.Value
                    DaTos(iDat).dt(35) = DaTos(iDat).ISEAL
                    For i = 1 To .Rows.Count
                        For k = 1 To 7
                            If k = 7 Then
                                DaTos(iDat).seal(k, i) = Math.PI / 180 * .Rows(i - 1)(k)
                            Else
                                DaTos(iDat).seal(k, i) = .Rows(i - 1)(k)
                            End If
                        Next k
                        If DaTos(iDat).seal(10, i) = 0 Then DaTos(iDat).seal(10, i) = -1
                    Next i
                Case 7 'tagli
                    For k = 1 To .Columns.Count - 1
                        DaTos(iDat).tagli(k) = .Rows(i - 1)(k)
                    Next k
            End Select
        End With
    End Sub
    Private Sub UpDown1_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles UpDown1.ValueChanged
        Nelem = UpDown1.Value
        Pagina()
    End Sub
    Private Sub Grid_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Grid.CurrentCellChanged
        Dim ColInput, RowInput As Integer
        Dim x, y As Single
        Dim Rvec, R, diro As Single
        If Not VecchiaCella.RowNumber = -1 Then
            Select Case MainForm.FuoriLayOut
                Case 3
                Case 4
                    ColInput = VecchiaCella.ColumnNumber
                    RowInput = VecchiaCella.RowNumber
                    Select Case ColInput
                        Case 1, 2 'x
                            x = GlobalRoutines.ValVir(tGriglia.Rows(RowInput)(1))
                            y = GlobalRoutines.ValVir(tGriglia.Rows(RowInput)(2))
                            Rvec = System.Math.Sqrt(y * y + x * x)
                            If Rvec > 0.1 Then
                                R = 180 / Math.PI * GlobalRoutines.arco(x / Rvec, y / Rvec)
                                tGriglia.Rows(RowInput)(3) = GlobalRoutines.myStr(R, 5, 2, False)
                            End If
                        Case 3 'Anomalia
                            R = GlobalRoutines.ValVir(tGriglia.Rows(RowInput)(3))
                            x = GlobalRoutines.ValVir(tGriglia.Rows(RowInput)(1))
                            y = GlobalRoutines.ValVir(tGriglia.Rows(RowInput)(2))
                            Rvec = System.Math.Sqrt(x * x + y * y)
                            If Rvec < 0.1 Then
                                diro = GlobalRoutines.ValVir(tGriglia.Rows(RowInput)(4))
                                Rvec = DaTos(iDat).di1 / 2 - diro / 2
                            End If
                            x = Rvec * System.Math.Cos(R / 180 * Math.PI) : y = Rvec * System.Math.Sin(R / 180 * Math.PI)
                            If System.Math.Abs(x) < 0.1 Then x = 0
                            If System.Math.Abs(y) < 0.1 Then y = 0
                            tGriglia.Rows(RowInput)(1) = GlobalRoutines.myStr(x, 5, 2, False)
                            tGriglia.Rows(RowInput)(2) = GlobalRoutines.myStr(y, 5, 2, False)
                    End Select
            End Select
        End If
        VecchiaCella = Grid.CurrentCell
    End Sub

    Private Sub frmGridn_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        VecchiaCella.RowNumber = -1
    End Sub

    Private Sub frmGridn_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        dview.Dispose()
        tGriglia.Dispose()
    End Sub
End Class