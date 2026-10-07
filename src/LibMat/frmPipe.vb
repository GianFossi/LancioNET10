Option Strict On
Option Explicit On
Imports System.Data
Imports System.Data.OleDb
Friend Class frmPipe
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
    Public WithEvents cmdHelp As System.Windows.Forms.Button
    Public WithEvents cmdCancel As System.Windows.Forms.Button
    Public WithEvents List1 As System.Windows.Forms.ListBox
    Public WithEvents cmdOK As System.Windows.Forms.Button
    Public WithEvents lstSpess As System.Windows.Forms.ListBox
    Public WithEvents lstSchedula As System.Windows.Forms.ListBox
    Public WithEvents txtDiam As System.Windows.Forms.TextBox
    Public WithEvents cmbDN As System.Windows.Forms.ComboBox
    Public WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents mnuModifica As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuPrima As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuDopo As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuCancella As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents miomenu As System.Windows.Forms.ToolStripMenuItem
    Public MainMenu1 As System.Windows.Forms.MenuStrip
    'NOTA: la routine seguente è richiesta dalla progettazione Windows Form.
    'Può essere modificata utilizzando la finestra di progettazione Windows Form.
    'Non modificarla mediante l'editor di codice.
    Friend WithEvents mioContesto As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents popModifica As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents popPrima As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents popDopo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents popCancella As System.Windows.Forms.ToolStripMenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmdHelp = New System.Windows.Forms.Button
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.List1 = New System.Windows.Forms.ListBox
        Me.cmdOK = New System.Windows.Forms.Button
        Me.lstSpess = New System.Windows.Forms.ListBox
        Me.mioContesto = New System.Windows.Forms.ContextMenuStrip
        Me.popModifica = New System.Windows.Forms.ToolStripMenuItem
        Me.popPrima = New System.Windows.Forms.ToolStripMenuItem
        Me.popDopo = New System.Windows.Forms.ToolStripMenuItem
        Me.popCancella = New System.Windows.Forms.ToolStripMenuItem
        Me.lstSchedula = New System.Windows.Forms.ListBox
        Me.txtDiam = New System.Windows.Forms.TextBox
        Me.cmbDN = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.MainMenu1 = New System.Windows.Forms.MenuStrip
        Me.miomenu = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuModifica = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuPrima = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuDopo = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuCancella = New System.Windows.Forms.ToolStripMenuItem
        Me.SuspendLayout()
        '
        'cmdHelp
        '
        Me.cmdHelp.BackColor = System.Drawing.SystemColors.Control
        Me.cmdHelp.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdHelp.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdHelp.Location = New System.Drawing.Point(168, 152)
        Me.cmdHelp.Name = "cmdHelp"
        Me.cmdHelp.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdHelp.Size = New System.Drawing.Size(58, 20)
        Me.cmdHelp.TabIndex = 10
        Me.cmdHelp.Text = "Help"
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCancel.Location = New System.Drawing.Point(168, 176)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCancel.Size = New System.Drawing.Size(58, 20)
        Me.cmdCancel.TabIndex = 9
        Me.cmdCancel.Text = "Annulla"
        '
        'List1
        '
        Me.List1.BackColor = System.Drawing.SystemColors.Window
        Me.List1.Cursor = System.Windows.Forms.Cursors.Default
        Me.List1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.List1.Location = New System.Drawing.Point(152, 39)
        Me.List1.Name = "List1"
        Me.List1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.List1.Size = New System.Drawing.Size(40, 17)
        Me.List1.TabIndex = 6
        Me.List1.Visible = False
        '
        'cmdOK
        '
        Me.cmdOK.BackColor = System.Drawing.SystemColors.Control
        Me.cmdOK.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdOK.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdOK.Location = New System.Drawing.Point(168, 200)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdOK.Size = New System.Drawing.Size(58, 20)
        Me.cmdOK.TabIndex = 5
        Me.cmdOK.Text = "OK"
        '
        'lstSpess
        '
        Me.lstSpess.BackColor = System.Drawing.SystemColors.Window
        Me.lstSpess.ContextMenuStrip = Me.mioContesto
        Me.lstSpess.Cursor = System.Windows.Forms.Cursors.Default
        Me.lstSpess.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lstSpess.Location = New System.Drawing.Point(68, 39)
        Me.lstSpess.Name = "lstSpess"
        Me.lstSpess.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lstSpess.Size = New System.Drawing.Size(52, 160)
        Me.lstSpess.TabIndex = 4
        '
        'mioContesto
        '
        Me.mioContesto.Items.AddRange(New System.Windows.Forms.ToolStripMenuItem() {Me.popModifica, Me.popPrima, Me.popDopo, Me.popCancella})
        '
        'popModifica
        '

        Me.popModifica.Text = "Modifica"
        '
        'popPrima
        '

        Me.popPrima.Text = "Inserisci prima"
        '
        'popDopo
        '

        Me.popDopo.Text = "Inserisci dopo"
        '
        'popCancella
        '

        Me.popCancella.Text = "Cancella"
        '
        'lstSchedula
        '
        Me.lstSchedula.BackColor = System.Drawing.SystemColors.Window
        Me.lstSchedula.ContextMenuStrip = Me.mioContesto
        Me.lstSchedula.Cursor = System.Windows.Forms.Cursors.Default
        Me.lstSchedula.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lstSchedula.Location = New System.Drawing.Point(12, 39)
        Me.lstSchedula.Name = "lstSchedula"
        Me.lstSchedula.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lstSchedula.Size = New System.Drawing.Size(52, 160)
        Me.lstSchedula.TabIndex = 3
        '
        'txtDiam
        '
        Me.txtDiam.AcceptsReturn = True
        Me.txtDiam.AutoSize = False
        Me.txtDiam.BackColor = System.Drawing.SystemColors.Window
        Me.txtDiam.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDiam.Enabled = False
        Me.txtDiam.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtDiam.Location = New System.Drawing.Point(124, 0)
        Me.txtDiam.MaxLength = 0
        Me.txtDiam.Name = "txtDiam"
        Me.txtDiam.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtDiam.Size = New System.Drawing.Size(60, 20)
        Me.txtDiam.TabIndex = 1
        Me.txtDiam.Text = "txtDiam"
        '
        'cmbDN
        '
        Me.cmbDN.BackColor = System.Drawing.SystemColors.Window
        Me.cmbDN.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbDN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDN.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbDN.Location = New System.Drawing.Point(0, 0)
        Me.cmbDN.Name = "cmbDN"
        Me.cmbDN.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbDN.Size = New System.Drawing.Size(119, 21)
        Me.cmbDN.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(67, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(88, 20)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Spessore (mm)"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(12, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(52, 20)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Schedula"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Yellow
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(192, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(32, 20)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "(mm)"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'MainMenu1
        '
        Me.MainMenu1.Items.AddRange(New System.Windows.Forms.ToolStripMenuItem() {Me.miomenu})
        '
        'miomenu
        '

        Me.miomenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripMenuItem() {Me.mnuModifica, Me.mnuPrima, Me.mnuDopo, Me.mnuCancella})
        Me.miomenu.Text = "Azioni"
        Me.miomenu.Visible = False
        '
        'mnuModifica
        '

        Me.mnuModifica.Text = "Modifica"
        '
        'mnuPrima
        '

        Me.mnuPrima.Text = "Inserisci prima"
        '
        'mnuDopo
        '

        Me.mnuDopo.Text = "Inserisci dopo"
        '
        'mnuCancella
        '

        Me.mnuCancella.Text = "Cancella"
        '
        'frmPipe
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(227, 225)
        Me.ControlBox = False
        Me.Controls.Add(Me.cmdHelp)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.List1)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.lstSpess)
        Me.Controls.Add(Me.lstSchedula)
        Me.Controls.Add(Me.txtDiam)
        Me.Controls.Add(Me.cmbDN)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Location = New System.Drawing.Point(318, 82)
        Me.MainMenuStrip = Me.MainMenu1
        Me.Controls.Add(Me.MainMenu1)
        Me.Name = "frmPipe"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Libreria piping"
        Me.ResumeLayout(False)

    End Sub
#End Region
    Private nFile As Short
    Private Pipe As piping
    Private iCurr As Short
    Private Table As DataTable
    Private cmd As OleDbDataAdapter
    Private dv As DataView
    Private drv As DataRowView
    Private Variato As Boolean
    Private Sub cmbDN_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbDN.SelectedIndexChanged
        Dim i As Short
        List1.SelectedIndex = cmbDN.SelectedIndex
        iCurr = CShort(cmbDN.SelectedIndex) ' + 1)
        lstSchedula.Items.Clear()
        lstSpess.Items.Clear()
        Select Case Tubo.Standard
            Case 0
                txtDiam.Text = Str(drv("DiamExt"))
                For i = 3 To CShort(Table.Columns.Count - 1)
                    If CSng(drv(i)) > 0 Then
                        lstSchedula.Items.Add(Table.Columns(i).Caption)
                        lstSpess.Items.Add(Str(drv(i)))
                    End If
                Next
            Case 1
                txtDiam.Text = Pipe.Diam
                For i = 1 To 20
                    If Asc(Pipe.Sch(i)) < 33 Then Exit For
                    lstSchedula.Items.Add(Pipe.Sch(i))
                    lstSpess.Items.Add(Pipe.Spess(i))
                Next
        End Select
        lstSchedula.Items.Add("NS")
        lstSpess.Items.Add(CStr(Tubo.Spess))
    End Sub
    Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub
    Private Sub cmdHelp_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdHelp.Click
        Help.ShowHelp(Me, RadiceHelp, HelpNavigator.Topic, "LibrPip.htm")
    End Sub

    Public Sub cmdOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOK.Click
        If lstSchedula.Text = "" Then
            MsgBox("Pregasi selezionare uno spessore o una schedula", MsgBoxStyle.Critical, "Libreria piping")
            Exit Sub
        End If
        Select Case Tubo.Standard
            Case 0
                Tubo.DN = CStr(drv("DN"))
                Tubo.Diam = Funzioni.ValVir(CStr(drv("DiamExt")))
                Tubo.Schedula = lstSchedula.Text
                Tubo.Spess = Funzioni.ValVir(lstSpess.Text)
            Case 1
                Tubo.DN = Pipe.DN
                Tubo.Diam = Funzioni.ValVir(Pipe.Diam)
                Tubo.Schedula = lstSchedula.Text
                Tubo.Spess = Funzioni.ValVir(lstSpess.Text)
                If iCurr > 0 And Variato Then
                    FilePut(nFile, Pipe, iCurr)
                    Variato = False
                End If
        End Select
        Me.Close()
    End Sub
    Private Sub frmPipe_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
        AppActivate(Text)
    End Sub
    Private Sub Inizializza()
        Apri()
        AggcmbDN()
        Cerca()
        AggcmbDNText()
    End Sub
    Private Sub Apri()
        Select Case Tubo.Standard
            Case 0
                If Not IniziaBase() Then Exit Sub
                Try
                    cmd = New OleDbDataAdapter("SELECT * FROM PipingB3610", MatBase)
                    Table = New DataTable
                    cmd.Fill(Table)
                    dv = Table.DefaultView
                Catch e As Exception
                    MsgBox(e.Message + vbCrLf + e.StackTrace)
                End Try
            Case 1
                nFile = CShort(FreeFile())
                FileOpen(nFile, Archdir.Trim & "\piping.new", OpenMode.Random, , OpenShare.Shared, Len(Pipe))
        End Select
    End Sub
    Public Sub Cerca()
        Dim i As Integer
        Dim Minimo As Single
        Dim indice(30) As Short
        Dim iCurr1 As Short
        Dim j As Short
        Dim Logical As Boolean
        Minimo = RoutBase1.clsTrigon.Infinito
        Select Case Tubo.Standard
            Case 0
                Try
                    With Table
                        i = 0
                        Logical = Not (Tubo.DN Is Nothing Or Tubo.Schedula Is Nothing)
                        If Logical Then Logical = Tubo.Schedula.Trim.Length > 0 And Tubo.DN.Trim.Length > 0
                        If Logical Then
                            If Asc(Tubo.DN) < 32 Then Tubo.DN = ""
                            If Asc(Tubo.Schedula) < 32 Then Tubo.Schedula = ""
                            'dv.Sort = "DN"
                            For j = 0 To CShort(dv.Count - 1)
                                If CStr(dv(j)("DN")).Trim = Tubo.DN.Trim Then Exit For
                            Next
                            If j > CShort(dv.Count - 1) Then j = 0
                            iCurr = CShort(j + 1)
                            cmbDN.SelectedIndex = iCurr - 1
                            For i = 0 To lstSchedula.Items.Count - 1
                                indice(i) = CShort(i)
                                If Tubo.Schedula.Trim = CStr(lstSchedula.Items(i)) Then iCurr1 = CShort(i) : Exit For
                            Next
                        Else
                            Do
                                i = i + 1
                                If (Tubo.Diam - CSng(dv(i)("DiamExt"))) ^ 2 < Minimo Then
                                    Minimo = CSng((Tubo.Diam - CSng(dv(i)("DiamExt"))) ^ 2)
                                    iCurr = CShort(i)
                                End If
                            Loop While i < dv.Count - 1
                            Tubo.DN = CStr(dv(iCurr)("DN"))
                            Minimo = RoutBase1.clsTrigon.Infinito
                            For i = 3 To CShort(.Columns.Count - 1)
                                If CSng(dv(iCurr)(i)) > 0 Then
                                    indice(i) = j
                                    j = CShort(j + 1)
                                End If
                                If CSng(dv(iCurr)(i)) > 0 And (Tubo.Spess - CSng(dv(iCurr)(i))) ^ 2 < Minimo Then
                                    Minimo = CSng((Tubo.Spess - CSng(dv(iCurr)(i))) ^ 2)
                                    iCurr1 = CShort(i)
                                End If
                            Next
                            Tubo.Schedula = .Columns(iCurr1).Caption
                        End If
                    End With
                Catch e As Exception
                    MsgBox(e.Message + vbCrLf + e.StackTrace)
                End Try
            Case 1
                i = 0
                Do
                    i = CShort(i + 1)
                    FileGet(nFile, CType(Pipe, piping), i)
                    If EOF(nFile) Then Exit Do
                    If (Tubo.Diam - Funzioni.ValVir(Pipe.Diam)) ^ 2 < Minimo Then
                        Minimo = CSng((Tubo.Diam - Funzioni.ValVir(Pipe.Diam)) ^ 2)
                        iCurr = CShort(i)
                    End If
                Loop
                FileGet(nFile, CType(Pipe, piping), iCurr)
                Tubo.DN = Pipe.DN
                Minimo = RoutBase1.clsTrigon.Infinito
                For i = 1 To 20
                    If (Tubo.Spess - Funzioni.ValVir(Pipe.Spess(i))) ^ 2 < Minimo Then Minimo = CSng((Tubo.Spess - Funzioni.ValVir(Pipe.Spess(i))) ^ 2) : iCurr1 = CShort(i)
                Next
                Tubo.Schedula = Pipe.Sch(iCurr1)
        End Select
        cmbDN.SelectedIndex = iCurr ' - 1
        Select Case Tubo.Standard
            Case 0
                lstSchedula.SelectedIndex = indice(iCurr1)
            Case 1
                lstSchedula.SelectedIndex = iCurr1 - 1
        End Select
        ' cmdOK_Click
    End Sub
    Private Sub AggcmbDN()
        Dim i As Integer
        Dim DN As String = ""
        i = 0
        cmbDN.Items.Clear()
        List1.Items.Clear()
        Do
            i = i + 1
            Select Case Tubo.Standard
                Case 0
                    DN = CStr(dv(i - 1)("DN"))
                    If i >= dv.Count Then Exit Do
                Case 1
                    FileGet(nFile, CType(Pipe, piping), i)
                    If EOF(nFile) Then Exit Do
                    DN = Pipe.DN
            End Select
            cmbDN.Items.Add(DN)
            List1.Items.Add(i.ToString)
        Loop
    End Sub
    Private Sub AggcmbDNText()
        Dim i As Short
        For i = 0 To CShort(cmbDN.Items.Count - 1)
            If Tubo.DN = CStr(cmbDN.Items(i)) Then
                cmbDN.SelectedIndex = i
                Exit For
            End If
        Next
    End Sub
    Private Sub frmPipe_Closing(ByVal eventSender As System.Object, ByVal eventArgs As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Dim Cancel As Boolean = eventArgs.Cancel
        Select Case Tubo.Standard
            Case 0 : Table.Dispose()
            Case 1 : FileClose(nFile)
        End Select
        eventArgs.Cancel = Cancel
    End Sub
    Private Sub List1_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles List1.SelectedIndexChanged
        Select Case Tubo.Standard
            Case 0
                iCurr = CShort(Val(List1.Text) - 1)
                ' iFound = dv.Find(iCurr)
                drv = dv(iCurr) ' - 1)
            Case 1
                If iCurr > 0 And Variato Then
                    FilePut(nFile, Pipe, iCurr)
                    Variato = False
                End If
                iCurr = CShort(Val(List1.Text))
                FileGet(nFile, CType(Pipe, piping), iCurr)
        End Select
    End Sub
    Private Sub lstSchedula_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lstSchedula.SelectedIndexChanged
        If Not lstSchedula.Enabled Then Exit Sub
        lstSpess.Enabled = False
        lstSpess.SelectedIndex = lstSchedula.SelectedIndex
        lstSpess.Enabled = True
    End Sub
    Private Sub lstSchedula_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles lstSchedula.MouseDown
        Dim Button As Short = CShort(eventArgs.Button \ &H100000)
        Dim Shift As Short = CShort(System.Windows.Forms.Control.ModifierKeys \ &H10000)
        If Tubo.Standard = 0 Then Exit Sub
        If Button = 2 Then
            lstSchedula_SelectedIndexChanged(lstSchedula, New System.EventArgs)
            'UPGRADE_ISSUE: Form metodo frmPipe.DropDownOpeningMenu non è stato aggiornato. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup2064"'
            'PopupMenu(miomenu)
        End If
    End Sub
    'UPGRADE_WARNING: L'evento lstSpess.SelectedIndexChanged può essere generato quando il form è inizializzato. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup2075"'
    Private Sub lstSpess_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lstSpess.SelectedIndexChanged
        If Not lstSpess.Enabled Then Exit Sub
        lstSchedula.Enabled = False
        lstSchedula.SelectedIndex = lstSpess.SelectedIndex
        lstSchedula.Enabled = True
    End Sub
    Private Sub lstSpess_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles lstSpess.MouseDown
        Dim Button As Short = CShort(eventArgs.Button \ &H100000)
        Dim Shift As Short = CShort(System.Windows.Forms.Control.ModifierKeys \ &H10000)
        If Tubo.Standard = 0 Then Exit Sub
        If Button = 2 Then
            lstSpess_SelectedIndexChanged(lstSpess, New System.EventArgs)
            'UPGRADE_ISSUE: Form metodo frmPipe.DropDownOpeningMenu non è stato aggiornato. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup2064"'
            'PopupMenu(miomenu)
        End If
    End Sub
    Public Sub mnuCancella_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuCancella.DropDownOpening
        mnuCancella_Click(eventSender, eventArgs)
    End Sub
    Public Sub mnuCancella_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuCancella.Click
        Dim i As Short
        For i = CShort(lstSchedula.SelectedIndex + 1) To 19
            Pipe.Sch(i) = Pipe.Sch(i + 1)
            Pipe.Spess(i) = Pipe.Spess(i + 1)
        Next
        Pipe.Sch(20) = "" : Pipe.Spess(20) = CStr(0)
        Variato = True
        cmbDN_SelectedIndexChanged(cmbDN, New System.EventArgs)
    End Sub
    Public Sub mnuDopo_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuDopo.DropDownOpening
        mnuDopo_Click(eventSender, eventArgs)
    End Sub
    Public Sub mnuDopo_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuDopo.Click
        Dim i As Short
        If lstSchedula.SelectedIndex = lstSchedula.Items.Count - 1 Then Exit Sub
        If lstSchedula.SelectedIndex > 18 Then
            MsgBox("Non c'è più posto")
            Exit Sub
        End If
        For i = 20 To CShort(lstSchedula.SelectedIndex + 3) Step -1
            Pipe.Sch(i) = Pipe.Sch(i - 1)
            Pipe.Spess(i) = Pipe.Spess(i - 1)
        Next
        lstSchedula.SelectedIndex = lstSchedula.SelectedIndex + 1
        Pipe.Sch(lstSchedula.SelectedIndex + 1) = "?"
        Pipe.Spess(lstSchedula.SelectedIndex + 1) = CStr(0)
        mnuModifica_Click(mnuModifica, New System.EventArgs)
    End Sub
    Public Sub mnuModifica_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuModifica.DropDownOpening
        mnuModifica_Click(eventSender, eventArgs)
    End Sub
    Public Sub mnuModifica_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuModifica.Click
        Dim l As Short
        l = CShort(lstSchedula.SelectedIndex)
        If l = lstSchedula.Items.Count - 1 Then Exit Sub
        If l < 0 Then
            MsgBox("Pregasi selezionare uno spessore o una schedula", MsgBoxStyle.Critical, "Libreria piping")
            Exit Sub
        End If
        Pipe.Sch(l + 1) = InputBox("Correggere la Schedula", "Modifica libreria piping", Pipe.Sch(l + 1))
        If Len(Trim(Pipe.Sch(l + 1))) = 0 Then
            Exit Sub
        Else
            Variato = True
            cmbDN_SelectedIndexChanged(cmbDN, New System.EventArgs)
            lstSchedula.SelectedIndex = l
        End If
        Pipe.Spess(l + 1) = InputBox("Correggere lo spessore", "Modifica libreria piping", Pipe.Spess(l + 1))
        If Len(Trim(Pipe.Spess(l + 1))) = 0 Then Exit Sub
        Variato = True
        cmbDN_SelectedIndexChanged(cmbDN, New System.EventArgs)
        lstSchedula.SelectedIndex = l
    End Sub
    Public Sub mnuPrima_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuPrima.DropDownOpening
        mnuPrima_Click(eventSender, eventArgs)
    End Sub
    Public Sub mnuPrima_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuPrima.Click
        Dim i As Short
        For i = 20 To CShort(lstSchedula.SelectedIndex + 1) Step -1
            Pipe.Sch(i) = Pipe.Sch(i - 1)
            Pipe.Spess(i) = Pipe.Spess(i - 1)
        Next
        Pipe.Sch(lstSchedula.SelectedIndex + 1) = "?"
        Pipe.Spess(lstSchedula.SelectedIndex + 1) = CStr(0)
        mnuModifica_Click(mnuModifica, New System.EventArgs)
    End Sub

    Private Sub popModifica_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles popModifica.Click
        mnuModifica_Click(sender, e)
    End Sub

    Private Sub popPrima_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles popPrima.Click
        mnuPrima_Click(sender, e)
    End Sub

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click

    End Sub

    Private Sub popDopo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles popDopo.Click
        mnuDopo_Click(sender, e)
    End Sub

    Private Sub popCancella_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles popCancella.Click
        mnuCancella_Click(sender, e)
    End Sub
End Class