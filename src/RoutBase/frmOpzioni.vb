Option Strict On
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports RoutBase1
Friend Class frmOpzioni
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
	Public WithEvents Command1 As System.Windows.Forms.Button
	Public WithEvents drvList As System.Windows.Forms.ComboBox
	Public WithEvents dirList As System.Windows.Forms.ListBox
	Public WithEvents filList As System.Windows.Forms.ListBox
	Public WithEvents Text2 As System.Windows.Forms.TextBox
	Public WithEvents Text3 As System.Windows.Forms.TextBox
	Public WithEvents Text4 As System.Windows.Forms.TextBox
	Public WithEvents Text5 As System.Windows.Forms.TextBox
	Public WithEvents Text6 As System.Windows.Forms.TextBox
	Public WithEvents Text7 As System.Windows.Forms.TextBox
	Public WithEvents Direct As System.Windows.Forms.TextBox
    'NOTA: la routine seguente è richiesta dalla progettazione Windows Form.
	'Può essere modificata utilizzando la finestra di progettazione Windows Form.
	'Non modificarla mediante l'editor di codice.
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton3 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton4 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton5 As System.Windows.Forms.RadioButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Command1 = New System.Windows.Forms.Button
        Me.drvList = New System.Windows.Forms.ComboBox
        Me.dirList = New System.Windows.Forms.ListBox
        Me.filList = New System.Windows.Forms.ListBox
        Me.Text2 = New System.Windows.Forms.TextBox
        Me.Text3 = New System.Windows.Forms.TextBox
        Me.Text4 = New System.Windows.Forms.TextBox
        Me.Text5 = New System.Windows.Forms.TextBox
        Me.Text6 = New System.Windows.Forms.TextBox
        Me.Text7 = New System.Windows.Forms.TextBox
        Me.Direct = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.RadioButton5 = New System.Windows.Forms.RadioButton
        Me.RadioButton4 = New System.Windows.Forms.RadioButton
        Me.RadioButton3 = New System.Windows.Forms.RadioButton
        Me.RadioButton2 = New System.Windows.Forms.RadioButton
        Me.RadioButton1 = New System.Windows.Forms.RadioButton
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Command1
        '
        Me.Command1.BackColor = System.Drawing.SystemColors.Control
        Me.Command1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command1.Location = New System.Drawing.Point(376, 207)
        Me.Command1.Name = "Command1"
        Me.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command1.Size = New System.Drawing.Size(57, 25)
        Me.Command1.TabIndex = 15
        Me.Command1.Text = "OK"
        '
        'drvList
        '
        Me.drvList.BackColor = System.Drawing.SystemColors.Window
        Me.drvList.Cursor = System.Windows.Forms.Cursors.Default
        Me.drvList.ForeColor = System.Drawing.SystemColors.WindowText
        Me.drvList.Location = New System.Drawing.Point(306, 2)
        Me.drvList.Name = "drvList"
        Me.drvList.Size = New System.Drawing.Size(129, 21)
        Me.drvList.TabIndex = 9
        '
        'dirList
        '
        Me.dirList.BackColor = System.Drawing.SystemColors.Window
        Me.dirList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.dirList.Cursor = System.Windows.Forms.Cursors.Default
        Me.dirList.ForeColor = System.Drawing.SystemColors.WindowText
        Me.dirList.IntegralHeight = False
        Me.dirList.Location = New System.Drawing.Point(304, 32)
        Me.dirList.Name = "dirList"
        Me.dirList.Size = New System.Drawing.Size(129, 135)
        Me.dirList.TabIndex = 8
        '
        'filList
        '
        Me.filList.BackColor = System.Drawing.SystemColors.Window
        Me.filList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.filList.Cursor = System.Windows.Forms.Cursors.Default
        Me.filList.ForeColor = System.Drawing.SystemColors.WindowText
        Me.filList.Location = New System.Drawing.Point(176, 0)
        Me.filList.Name = "filList"
        Me.drvList.DropDownStyle = ComboBoxStyle.DropDownList
        Me.filList.Size = New System.Drawing.Size(121, 158)
        Me.filList.TabIndex = 7
        '
        'Text2
        '
        Me.Text2.AcceptsReturn = True
        Me.Text2.AutoSize = False
        Me.Text2.BackColor = System.Drawing.SystemColors.Window
        Me.Text2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Text2.Enabled = False
        Me.Text2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text2.Location = New System.Drawing.Point(40, 24)
        Me.Text2.MaxLength = 0
        Me.Text2.Name = "Text2"
        Me.Text2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text2.Size = New System.Drawing.Size(121, 19)
        Me.Text2.TabIndex = 6
        Me.Text2.Text = "Lavori sciolti"
        '
        'Text3
        '
        Me.Text3.AcceptsReturn = True
        Me.Text3.AutoSize = False
        Me.Text3.BackColor = System.Drawing.SystemColors.Window
        Me.Text3.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Text3.Enabled = False
        Me.Text3.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text3.Location = New System.Drawing.Point(40, 44)
        Me.Text3.MaxLength = 0
        Me.Text3.Name = "Text3"
        Me.Text3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text3.Size = New System.Drawing.Size(121, 19)
        Me.Text3.TabIndex = 5
        Me.Text3.Text = "Lavori di commessa"
        '
        'Text4
        '
        Me.Text4.AcceptsReturn = True
        Me.Text4.AutoSize = False
        Me.Text4.BackColor = System.Drawing.SystemColors.Window
        Me.Text4.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Text4.Enabled = False
        Me.Text4.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text4.Location = New System.Drawing.Point(40, 84)
        Me.Text4.MaxLength = 0
        Me.Text4.Name = "Text4"
        Me.Text4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text4.Size = New System.Drawing.Size(121, 19)
        Me.Text4.TabIndex = 4
        Me.Text4.Text = "Archivi"
        '
        'Text5
        '
        Me.Text5.AcceptsReturn = True
        Me.Text5.AutoSize = False
        Me.Text5.BackColor = System.Drawing.SystemColors.Window
        Me.Text5.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Text5.Enabled = False
        Me.Text5.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text5.Location = New System.Drawing.Point(40, 64)
        Me.Text5.MaxLength = 0
        Me.Text5.Name = "Text5"
        Me.Text5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text5.Size = New System.Drawing.Size(121, 19)
        Me.Text5.TabIndex = 3
        Me.Text5.Text = "Eseguibili"
        '
        'Text6
        '
        Me.Text6.AcceptsReturn = True
        Me.Text6.AutoSize = False
        Me.Text6.BackColor = System.Drawing.SystemColors.Window
        Me.Text6.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Text6.Enabled = False
        Me.Text6.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text6.Location = New System.Drawing.Point(40, 104)
        Me.Text6.MaxLength = 0
        Me.Text6.Name = "Text6"
        Me.Text6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text6.Size = New System.Drawing.Size(121, 19)
        Me.Text6.TabIndex = 2
        Me.Text6.Text = "Data Base Storico"
        Me.Text6.Visible = False
        '
        'Text7
        '
        Me.Text7.AcceptsReturn = True
        Me.Text7.AutoSize = False
        Me.Text7.BackColor = System.Drawing.Color.White
        Me.Text7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Text7.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Text7.Enabled = False
        Me.Text7.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text7.Location = New System.Drawing.Point(8, 0)
        Me.Text7.MaxLength = 0
        Me.Text7.Name = "Text7"
        Me.Text7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text7.Size = New System.Drawing.Size(152, 13)
        Me.Text7.TabIndex = 1
        Me.Text7.Text = "Scelta directories:"
        Me.Text7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Direct
        '
        Me.Direct.AcceptsReturn = True
        Me.Direct.AutoSize = False
        Me.Direct.BackColor = System.Drawing.SystemColors.Window
        Me.Direct.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Direct.Enabled = False
        Me.Direct.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Direct.Location = New System.Drawing.Point(8, 176)
        Me.Direct.MaxLength = 0
        Me.Direct.Name = "Direct"
        Me.Direct.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Direct.Size = New System.Drawing.Size(424, 22)
        Me.Direct.TabIndex = 0
        Me.Direct.Text = "Text8"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RadioButton5)
        Me.GroupBox1.Controls.Add(Me.RadioButton4)
        Me.GroupBox1.Controls.Add(Me.RadioButton3)
        Me.GroupBox1.Controls.Add(Me.RadioButton2)
        Me.GroupBox1.Controls.Add(Me.RadioButton1)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 16)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(32, 110)
        Me.GroupBox1.TabIndex = 16
        Me.GroupBox1.TabStop = False
        '
        'RadioButton5
        '
        Me.RadioButton5.Location = New System.Drawing.Point(10, 88)
        Me.RadioButton5.Name = "RadioButton5"
        Me.RadioButton5.Size = New System.Drawing.Size(16, 16)
        Me.RadioButton5.TabIndex = 4
        Me.RadioButton5.Visible = False
        '
        'RadioButton4
        '
        Me.RadioButton4.Location = New System.Drawing.Point(10, 69)
        Me.RadioButton4.Name = "RadioButton4"
        Me.RadioButton4.Size = New System.Drawing.Size(16, 16)
        Me.RadioButton4.TabIndex = 3
        '
        'RadioButton3
        '
        Me.RadioButton3.Location = New System.Drawing.Point(10, 50)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(16, 16)
        Me.RadioButton3.TabIndex = 2
        '
        'RadioButton2
        '
        Me.RadioButton2.Location = New System.Drawing.Point(10, 31)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(16, 16)
        Me.RadioButton2.TabIndex = 1
        '
        'RadioButton1
        '
        Me.RadioButton1.Location = New System.Drawing.Point(10, 12)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(16, 16)
        Me.RadioButton1.TabIndex = 0
        '
        'frmOpzioni
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(439, 234)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Command1)
        Me.Controls.Add(Me.drvList)
        Me.Controls.Add(Me.dirList)
        Me.Controls.Add(Me.filList)
        Me.Controls.Add(Me.Text2)
        Me.Controls.Add(Me.Text3)
        Me.Controls.Add(Me.Text4)
        Me.Controls.Add(Me.Text5)
        Me.Controls.Add(Me.Text6)
        Me.Controls.Add(Me.Text7)
        Me.Controls.Add(Me.Direct)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.HelpButton = True
        Me.Location = New System.Drawing.Point(2, 21)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmOpzioni"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Scelta Aree di lavoro"
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
#End Region 
#Region "Supporto aggiornamento "
	Private Shared m_vb6FormDefInstance As frmOpzioni
	Private Shared m_InitializingDefInstance As Boolean
	Public Shared Property DefInstance() As frmOpzioni
		Get
			If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
				m_InitializingDefInstance = True
				m_vb6FormDefInstance = New frmOpzioni()
				m_InitializingDefInstance = False
			End If
			DefInstance = m_vb6FormDefInstance
		End Get
		Set
			m_vb6FormDefInstance = Value
		End Set
	End Property
#End Region 
	Public EsitoPrintInizio As Boolean
    Public Motore As clsMotore
    Private Sub frmOpzioni_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Dim i As Short
        For Each driveInfo In IO.DriveInfo.GetDrives()
            Dim label = If(driveInfo.IsReady, driveInfo.VolumeLabel, "")
            drvList.Items.Add(driveInfo.Name & " [" & label & "]")
        Next
        RadioButton2.Checked = True
        ShowDirectory(Motore.Inizio.Workdir)
        Direct.Text = Motore.Inizio.Workdir
        For i = 0 To CShort(drvList.Items.Count - 1)
            If InStr(CStr(drvList.Items(i)), "RAM") > 0 Then
                Motore.Inizio.DiscoRam = VB.Left(CStr(drvList.Items(i)), 2) & "\"
                Exit For
            End If
        Next
        RadioButton1.Enabled = True
        RadioButton2.Enabled = True
        RadioButton3.Enabled = True
        RadioButton4.Enabled = True
        RadioButton5.Enabled = Abilitato
        drvList.Enabled = True
        Direct.Visible = True
    End Sub
    Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
        EsitoPrintInizio = Motore.Inizio.PrintInizio()
        Hide()
    End Sub

    Private Sub DirList_Change(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles dirList.DoubleClick
        ' Update File listbox to sync with Dir listbox.
        If dirList.SelectedItem Is Nothing Then Return
        ShowDirectory(CStr(dirList.SelectedItem))
    End Sub
    Private Sub DirList_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles dirList.Leave
        If dirList.SelectedItem IsNot Nothing Then DirList_Change(eventSender, eventArgs)
    End Sub
    Private Sub DrvList_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles drvList.SelectedIndexChanged
        If drvList.SelectedItem IsNot Nothing AndAlso Motore IsNot Nothing Then ShowDirectory(CStr(drvList.SelectedItem).Substring(0, 3))
    End Sub
    Private Sub RadioButton1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked Then
            GiaFatto = False : GiaFattoB = False
            Direct.Text = Motore.Inizio.Datidir
        End If
    End Sub
    Private Sub RadioButton2_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked Then
            Dim n1, i, n2 As Short
            Dim drive As String
            GiaFatto = False : GiaFattoB = False
            Direct.Text = Motore.Inizio.Workdir
            drive = VB.Left(Motore.Inizio.Workdir, 2)
            For i = 0 To CShort(drvList.Items.Count - 1)
                If InStr(CStr(drvList.Items(i)), drive) > 0 Then
                    n1 = CShort(InStr(CStr(drvList.Items(i)), "["))
                    n2 = CShort(InStr(CStr(drvList.Items(i)), "]"))
                    If n1 = 0 Or n2 = 0 Then Exit For
                    Motore.Inizio.DBFdir = Mid(CStr(drvList.Items(i)), n1 + 1, n2 - n1 - 1)
                    Exit Sub
                End If
            Next
            Motore.Inizio.DBFdir = "UNC sconosciuto"
        End If
    End Sub
    Private Sub RadioButton3_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton3.CheckedChanged
        If RadioButton3.Checked Then
            GiaFatto = False : GiaFattoB = False
            Direct.Text = Motore.Inizio.Basedir
        End If
    End Sub
    Private Sub RadioButton4_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton4.CheckedChanged
        If RadioButton4.Checked Then
            GiaFatto = False : GiaFattoB = False
            Direct.Text = Motore.Inizio.Archdir
        End If
    End Sub
    Private Sub RadioButton5_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton5.CheckedChanged
        If RadioButton5.Checked Then
            GiaFatto = False : GiaFattoB = False
            Direct.Text = Motore.Inizio.DBFdir
        End If
    End Sub
    Private CurrentDirectory As String
    Private Sub ShowDirectory(directory As String)
        Try
            Dim fullPath = IO.Path.GetFullPath(directory)
            Dim directories = IO.Directory.GetDirectories(fullPath)
            Dim files = IO.Directory.GetFiles(fullPath)
            CurrentDirectory = fullPath
            dirList.Items.Clear()
            Dim parent = IO.Directory.GetParent(fullPath)
            If parent IsNot Nothing Then dirList.Items.Add(parent.FullName)
            dirList.Items.AddRange(directories)
            filList.Items.Clear()
            filList.Items.AddRange(files.Select(Function(f) IO.Path.GetFileName(f)).ToArray())
            If Motore IsNot Nothing Then
                If RadioButton1.Checked Then
                    Motore.Inizio.Datidir = CurrentDirectory
                ElseIf RadioButton2.Checked Then
                    Motore.Inizio.Workdir = CurrentDirectory
                ElseIf RadioButton3.Checked Then
                    Motore.Inizio.Basedir = CurrentDirectory
                ElseIf RadioButton4.Checked Then
                    Motore.Inizio.Archdir = CurrentDirectory
                ElseIf RadioButton5.Checked Then
                    Motore.Inizio.DBFdir = CurrentDirectory
                End If
            End If
            Direct.Text = fullPath
        Catch ex As Exception When TypeOf ex Is IO.IOException OrElse TypeOf ex Is UnauthorizedAccessException OrElse TypeOf ex Is ArgumentException
            MessageBox.Show(ex.Message, "Cartella non accessibile")
        End Try
    End Sub
End Class