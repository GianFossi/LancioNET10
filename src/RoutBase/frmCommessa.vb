Option Strict On
Option Explicit On 
Imports System.io
Imports System.Windows
Friend Class frmCommessa
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
    Public WithEvents _Text1_2 As System.Windows.Forms.TextBox
    Public WithEvents _Command4_3 As System.Windows.Forms.Button
    Public WithEvents _Command4_2 As System.Windows.Forms.Button
    Public WithEvents _Text1_0 As System.Windows.Forms.TextBox
    Public WithEvents _Command4_1 As System.Windows.Forms.Button
    Public WithEvents _Command4_0 As System.Windows.Forms.Button
    Public WithEvents _Combo1_1 As System.Windows.Forms.ComboBox
    Public WithEvents Command3 As System.Windows.Forms.Button
    Public WithEvents Command1 As System.Windows.Forms.Button
    Public WithEvents _Text1_1 As System.Windows.Forms.TextBox
    Public WithEvents _Combo1_0 As System.Windows.Forms.ComboBox
    Public WithEvents _Label2_4 As System.Windows.Forms.Label
    Public WithEvents _Label2_3 As System.Windows.Forms.Label
    Public WithEvents _Label2_2 As System.Windows.Forms.Label
    Public WithEvents _Label2_1 As System.Windows.Forms.Label
    Public WithEvents _Label2_0 As System.Windows.Forms.Label
    'NOTA: la routine seguente è richiesta dalla progettazione Windows Form.
    'Può essere modificata utilizzando la finestra di progettazione Windows Form.
    'Non modificarla mediante l'editor di codice.
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtFile As System.Windows.Forms.TextBox
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmCommessa))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me._Command4_3 = New System.Windows.Forms.Button
        Me._Command4_2 = New System.Windows.Forms.Button
        Me._Command4_1 = New System.Windows.Forms.Button
        Me._Command4_0 = New System.Windows.Forms.Button
        Me._Text1_2 = New System.Windows.Forms.TextBox
        Me._Text1_0 = New System.Windows.Forms.TextBox
        Me._Combo1_1 = New System.Windows.Forms.ComboBox
        Me.Command3 = New System.Windows.Forms.Button
        Me.Command1 = New System.Windows.Forms.Button
        Me._Text1_1 = New System.Windows.Forms.TextBox
        Me._Combo1_0 = New System.Windows.Forms.ComboBox
        Me._Label2_4 = New System.Windows.Forms.Label
        Me._Label2_3 = New System.Windows.Forms.Label
        Me._Label2_2 = New System.Windows.Forms.Label
        Me._Label2_1 = New System.Windows.Forms.Label
        Me._Label2_0 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.RadioButton2 = New System.Windows.Forms.RadioButton
        Me.RadioButton1 = New System.Windows.Forms.RadioButton
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtFile = New System.Windows.Forms.TextBox
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        '_Command4_3
        '
        Me._Command4_3.BackColor = System.Drawing.SystemColors.Control
        Me._Command4_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._Command4_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Command4_3.Image = CType(resources.GetObject("_Command4_3.Image"), System.Drawing.Image)
        Me._Command4_3.Location = New System.Drawing.Point(248, 87)
        Me._Command4_3.Name = "_Command4_3"
        Me._Command4_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Command4_3.Size = New System.Drawing.Size(20, 20)
        Me._Command4_3.TabIndex = 14
        Me.ToolTip1.SetToolTip(Me._Command4_3, "Elimina l'item attualmente selezionato")
        '
        '_Command4_2
        '
        Me._Command4_2.BackColor = System.Drawing.SystemColors.Control
        Me._Command4_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._Command4_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Command4_2.Image = CType(resources.GetObject("_Command4_2.Image"), System.Drawing.Image)
        Me._Command4_2.Location = New System.Drawing.Point(240, 8)
        Me._Command4_2.Name = "_Command4_2"
        Me._Command4_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Command4_2.Size = New System.Drawing.Size(20, 20)
        Me._Command4_2.TabIndex = 13
        Me.ToolTip1.SetToolTip(Me._Command4_2, "Elimina permanentemente la commessa selezionata dal job attivo")
        '
        '_Command4_1
        '
        Me._Command4_1.BackColor = System.Drawing.SystemColors.Control
        Me._Command4_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._Command4_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Command4_1.Image = CType(resources.GetObject("_Command4_1.Image"), System.Drawing.Image)
        Me._Command4_1.Location = New System.Drawing.Point(224, 87)
        Me._Command4_1.Name = "_Command4_1"
        Me._Command4_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Command4_1.Size = New System.Drawing.Size(20, 20)
        Me._Command4_1.TabIndex = 10
        Me.ToolTip1.SetToolTip(Me._Command4_1, "Introduce un nuovo item")
        '
        '_Command4_0
        '
        Me._Command4_0.BackColor = System.Drawing.SystemColors.Control
        Me._Command4_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Command4_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Command4_0.Image = CType(resources.GetObject("_Command4_0.Image"), System.Drawing.Image)
        Me._Command4_0.Location = New System.Drawing.Point(216, 8)
        Me._Command4_0.Name = "_Command4_0"
        Me._Command4_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Command4_0.Size = New System.Drawing.Size(20, 20)
        Me._Command4_0.TabIndex = 9
        Me.ToolTip1.SetToolTip(Me._Command4_0, "Introduce una nuova commessa nel job attivo")
        '
        '_Text1_2
        '
        Me._Text1_2.AcceptsReturn = True
        Me._Text1_2.AutoSize = False
        Me._Text1_2.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_2.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_2.Location = New System.Drawing.Point(112, 32)
        Me._Text1_2.MaxLength = 0
        Me._Text1_2.Name = "_Text1_2"
        Me._Text1_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_2.Size = New System.Drawing.Size(289, 19)
        Me._Text1_2.TabIndex = 15
        Me._Text1_2.Text = ""
        '
        '_Text1_0
        '
        Me._Text1_0.AcceptsReturn = True
        Me._Text1_0.AutoSize = False
        Me._Text1_0.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_0.Enabled = False
        Me._Text1_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_0.Location = New System.Drawing.Point(112, 114)
        Me._Text1_0.MaxLength = 0
        Me._Text1_0.Name = "_Text1_0"
        Me._Text1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_0.Size = New System.Drawing.Size(109, 19)
        Me._Text1_0.TabIndex = 12
        Me._Text1_0.Text = ""
        '
        '_Combo1_1
        '
        Me._Combo1_1.BackColor = System.Drawing.SystemColors.Window
        Me._Combo1_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._Combo1_1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me._Combo1_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Combo1_1.Location = New System.Drawing.Point(112, 88)
        Me._Combo1_1.Name = "_Combo1_1"
        Me._Combo1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Combo1_1.Size = New System.Drawing.Size(109, 21)
        Me._Combo1_1.TabIndex = 8
        '
        'Command3
        '
        Me.Command3.BackColor = System.Drawing.SystemColors.Control
        Me.Command3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command3.Location = New System.Drawing.Point(360, 138)
        Me.Command3.Name = "Command3"
        Me.Command3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command3.Size = New System.Drawing.Size(48, 28)
        Me.Command3.TabIndex = 7
        Me.Command3.Text = "Cancel"
        '
        'Command1
        '
        Me.Command1.BackColor = System.Drawing.SystemColors.Control
        Me.Command1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command1.Location = New System.Drawing.Point(423, 138)
        Me.Command1.Name = "Command1"
        Me.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command1.Size = New System.Drawing.Size(37, 28)
        Me.Command1.TabIndex = 3
        Me.Command1.Text = "OK"
        '
        '_Text1_1
        '
        Me._Text1_1.AcceptsReturn = True
        Me._Text1_1.AutoSize = False
        Me._Text1_1.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_1.Location = New System.Drawing.Point(112, 52)
        Me._Text1_1.MaxLength = 0
        Me._Text1_1.Name = "_Text1_1"
        Me._Text1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_1.Size = New System.Drawing.Size(289, 19)
        Me._Text1_1.TabIndex = 1
        Me._Text1_1.Text = ""
        '
        '_Combo1_0
        '
        Me._Combo1_0.BackColor = System.Drawing.SystemColors.Window
        Me._Combo1_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Combo1_0.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me._Combo1_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Combo1_0.Location = New System.Drawing.Point(112, 9)
        Me._Combo1_0.Name = "_Combo1_0"
        Me._Combo1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Combo1_0.Size = New System.Drawing.Size(96, 21)
        Me._Combo1_0.TabIndex = 0
        '
        '_Label2_4
        '
        Me._Label2_4.BackColor = System.Drawing.SystemColors.Control
        Me._Label2_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label2_4.Location = New System.Drawing.Point(8, 32)
        Me._Label2_4.Name = "_Label2_4"
        Me._Label2_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_4.Size = New System.Drawing.Size(96, 20)
        Me._Label2_4.TabIndex = 16
        Me._Label2_4.Text = "Oggetto"
        '
        '_Label2_3
        '
        Me._Label2_3.BackColor = System.Drawing.SystemColors.Control
        Me._Label2_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label2_3.Location = New System.Drawing.Point(8, 114)
        Me._Label2_3.Name = "_Label2_3"
        Me._Label2_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_3.Size = New System.Drawing.Size(111, 14)
        Me._Label2_3.TabIndex = 11
        Me._Label2_3.Text = "Disegno d'assieme"
        '
        '_Label2_2
        '
        Me._Label2_2.BackColor = System.Drawing.SystemColors.Control
        Me._Label2_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label2_2.Location = New System.Drawing.Point(8, 88)
        Me._Label2_2.Name = "_Label2_2"
        Me._Label2_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_2.Size = New System.Drawing.Size(79, 17)
        Me._Label2_2.TabIndex = 6
        Me._Label2_2.Text = "Apparecchio"
        '
        '_Label2_1
        '
        Me._Label2_1.BackColor = System.Drawing.SystemColors.Control
        Me._Label2_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label2_1.Location = New System.Drawing.Point(9, 52)
        Me._Label2_1.Name = "_Label2_1"
        Me._Label2_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_1.Size = New System.Drawing.Size(96, 20)
        Me._Label2_1.TabIndex = 5
        Me._Label2_1.Text = "Cliente "
        '
        '_Label2_0
        '
        Me._Label2_0.BackColor = System.Drawing.SystemColors.Control
        Me._Label2_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label2_0.Location = New System.Drawing.Point(9, 9)
        Me._Label2_0.Name = "_Label2_0"
        Me._Label2_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_0.Size = New System.Drawing.Size(145, 28)
        Me._Label2_0.TabIndex = 4
        Me._Label2_0.Text = "Commessa"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RadioButton2)
        Me.GroupBox1.Controls.Add(Me.RadioButton1)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 144)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(112, 56)
        Me.GroupBox1.TabIndex = 17
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Asse apparecchio"
        '
        'RadioButton2
        '
        Me.RadioButton2.Location = New System.Drawing.Point(8, 32)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(101, 16)
        Me.RadioButton2.TabIndex = 1
        Me.RadioButton2.Text = "Verticale"
        '
        'RadioButton1
        '
        Me.RadioButton1.Location = New System.Drawing.Point(8, 16)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(92, 16)
        Me.RadioButton1.TabIndex = 0
        Me.RadioButton1.Text = "Orizzontale"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(280, 88)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 16)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "Numero"
        '
        'txtFile
        '
        Me.txtFile.Location = New System.Drawing.Point(344, 88)
        Me.txtFile.Name = "txtFile"
        Me.txtFile.Size = New System.Drawing.Size(56, 20)
        Me.txtFile.TabIndex = 19
        Me.txtFile.Text = "TextBox1"
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'frmCommessa
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(471, 224)
        Me.ControlBox = False
        Me.Controls.Add(Me.txtFile)
        Me.Controls.Add(Me._Text1_2)
        Me.Controls.Add(Me._Text1_0)
        Me.Controls.Add(Me._Text1_1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me._Command4_3)
        Me.Controls.Add(Me._Command4_2)
        Me.Controls.Add(Me._Command4_1)
        Me.Controls.Add(Me._Command4_0)
        Me.Controls.Add(Me._Combo1_1)
        Me.Controls.Add(Me.Command3)
        Me.Controls.Add(Me.Command1)
        Me.Controls.Add(Me._Combo1_0)
        Me.Controls.Add(Me._Label2_4)
        Me.Controls.Add(Me._Label2_3)
        Me.Controls.Add(Me._Label2_2)
        Me.Controls.Add(Me._Label2_1)
        Me.Controls.Add(Me._Label2_0)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Location = New System.Drawing.Point(263, 302)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCommessa"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Anagrafica Commessa/Apparecchio"
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
#End Region 
    Public Cancel As Boolean
    Public job As clsjob
	Public propComm As String 'proposta di default
	Public propItem As String 'proposta di default
	Public Visual As Boolean
    Private FileData As String
    Private Inizializzando As Boolean
    Private Sub AggiorAsse()
        Select Case job.Comm.Asse
            Case "V"
                RadioButton2.Checked = True
            Case Else
                RadioButton1.Checked = True
        End Select
    End Sub
    Private ReadOnly Property Combo1(ByVal i As Short) As ComboBox
        Get
            Select Case i
                Case 0 : Return _Combo1_0
                Case 1 : Return _Combo1_1
            End Select
        End Get
    End Property
    Private Sub Combo1_SelectedIndexChanged(ByVal Index As Short)
        Dim vInd, i As Short
        If Inizializzando Then Exit Sub
        Try
            Select Case Index
                Case 0
                    vInd = CShort(Combo1(Index).SelectedIndex)
                    If vInd > -1 Then job.RetrieveCom(CShort(vInd + 1))
                    If job.Comm.Ind.Count() = 1 And job.Comm.Ind.Item(1).Data.Assieme.Length = 0 Then
                        propItem = "E-101"
                        AggiorItem(True)
                    Else
                        AggItem()
                    End If
                    If Len(propItem) > 0 Then
                        For i = 0 To CShort(Combo1(1).Items.Count - 1)
                            If CStr(Combo1(1).Items(i)).Trim = propItem Then
                                Combo1(1).SelectedIndex = i
                                propItem = ""
                                Exit For
                            End If
                        Next
                    Else
                        vInd = job.Comm.indice
                        If vInd > job.Comm.NumAs Then vInd = job.Comm.NumAs
                        If vInd = 0 Then vInd = 1
                        Combo1(1).SelectedIndex = vInd - 1
                    End If
                    AggiorAsse()
                Case 1
                    job.Comm.indice = CShort(Combo1(Index).SelectedIndex + 1)
                    _Text1_0.Text = job.Comm.Arch.Trim & "." & job.Comm.Ind.Item(job.Comm.indice).Data.File
                    _Text1_1.Text = job.Comm.Clie
                    txtFile.Text = job.Comm.Ind.Item(job.Comm.indice).Data.File
            End Select
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
        'OK
        If Trim(job.Comm.Arch) = "" Then '13-5-99
            Cancel = True
            Exit Sub
        End If
        Cancel = False
        job.Comm.CheckPath()
        job.Comm.SalvaCom()
        job.Salva()
        Me.Close()
    End Sub
    Private Sub Command3_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command3.Click
        'Cancel
        Cancel = True
        Me.Close()
    End Sub
    Private Sub Command4_Click(ByVal Index As Short)
        Dim Nome As String = ""
        Dim s As Object
        Dim V As ValoriComm
        Dim NomeF, Path As String
        Dim i As Short
        Select Case Index
            Case 0 : AggComm()
            Case 1 : AggiorItem(True)
            Case 2 'elimina commessa
                If MsgBox("Prego confermare l'eliminazione della commessa " & job.Comm.Arch & vbCrLf & "e di tutti i dati associati", CType(MsgBoxStyle.Question + MsgBoxStyle.YesNo, MsgBoxStyle)) = MsgBoxResult.No Then Exit Sub
                Path = job.Motore.Inizio.Workdir & "\" & job.Comm.Arch
                Dim di As New DirectoryInfo(Path)
                Dim fi() As FileInfo = di.GetFiles("*.*")
                Nome = Dir(Nome)
                For i = 0 To CShort(UBound(fi))
                    Nome = fi(i).Name
                    Kill(Path & "\" & Nome)
                Next
                Do While job.Comm.Ind.Count() > 0
                    job.Comm.Ind.remove(1)
                Loop
                On Error Resume Next
                RmDir(Path)
                On Error GoTo 0
                job.Rimuovi((job.Comm.Arch))
                job.RetrieveCom(1)
                'job.Comm.indice = 1
                'job.Comm.NumAs = 1
                'job.Comm.SalvaCom
                job.Salva()
                AggCombo()
                On Error Resume Next
                Combo1(0).SelectedIndex = 0
                On Error GoTo 0
            Case 3 'elimina item
                If MsgBox("Prego confermare l'eliminazione dell'item " + Combo1(1).Text + " e di tutti i dati associati", _
                    MsgBoxStyle.Question Or MsgBoxStyle.YesNo, "Gestione distinta") = MsgBoxResult.No Then Exit Sub
                Path = job.Motore.Inizio.Workdir & "\" & job.Comm.Arch
                Dim di As New DirectoryInfo(Path)
                Dim fi() As FileInfo = di.GetFiles(job.Comm.Ind.Item(Combo1(1).SelectedIndex + 1).Data.File & ".*")
                For i = 0 To CShort(UBound(fi))
                    Kill(Path & "\" & fi(i).name)
                Next
                job.Comm.Ind.remove(Combo1(1).SelectedIndex + 1)
                job.Comm.SalvaCom()
                AggItem()
                On Error Resume Next
                Combo1(1).SelectedIndex = 0
                On Error GoTo 0
        End Select
    End Sub
    Private Sub frmCommessa_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
        If Not Visual Then Command1_Click(Command1, New System.EventArgs)
    End Sub
    Public Sub Inizializza()
        Dim i As Short
        AggCombo()
        If Len(propComm) > 0 Then
            If Combo1(0).Items.Count = 0 Then
                AggComm()
            Else
                For i = 0 To CShort(Combo1(0).Items.Count - 1)
                    If CStr(Combo1(0).Items(i)).Trim = propComm Then
                        Combo1(0).SelectedIndex = i
                        GoTo Cont
                    End If
                Next
                AggComm()
            End If
        Else
            If Combo1(0).Items.Count > 0 Then
                Combo1(0).SelectedIndex = 0
            Else
                AggComm()
            End If
        End If
Cont:
        Text = "Anagrafica Commessa (Contratto " & job.Contratto.Trim & ")"
    End Sub
    Private Sub AggCombo()
        Dim i As Short
        Combo1(0).Items.Clear()
        Try
            For i = 1 To CShort(job.Coll.Count())
                Combo1(0).Items.Add(job.Coll.Item(i).TextData)
            Next
        Catch e As Exception
            MessageBox.Show(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Private Sub AggItem()
        Dim i As Short
        With job.Comm
            _Text1_1.Text = .Clie
            _Text1_2.Text = .Oggetto
            Combo1(1).Items.Clear()
            For i = 1 To CShort(.Ind.Count())
                If .Ind.Item(i).Data.Assieme.Length = 0 Then
                    propItem = "E-00" + i.ToString
                    .Ind.Item(i).Data.Assieme = propItem
                End If
                Combo1(1).Items.Add(.Ind.Item(i).Data.Assieme)
            Next
        End With
    End Sub
    Private Sub AggComm()
        Dim co, Nome As String
        Dim i As Integer
        co = propComm
        If Len(co) < 6 Then co = job.Contratto & "xx"
Rif:    Nome = InputBox("N° Commessa", "Inserimento nuova commessa", co)
        If Len(Trim(Nome)) = 0 Then Exit Sub
        If Len(Nome) <> 6 Then
            MsgBox("Il N° di commessa deve essere di sei caratteri", CType(MsgBoxStyle.Information + MsgBoxStyle.OKOnly, MsgBoxStyle))
            GoTo Rif
        End If
        For i = 1 To job.Coll.Count()
            If job.Coll.Item(i).TextData = Nome Then
                MsgBox("La Commessa " & Nome & " esiste già")
                job.RetrieveCom(CShort(i))
                Exit Sub
            End If
        Next
        job.AggiungiCom(Nome)
        AggCombo()
        For i = 0 To Combo1(0).Items.Count - 1
            If CStr(Combo1(0).Items(i)) = Nome Then
                Combo1(0).SelectedIndex = i
                Exit For
            End If
        Next

    End Sub
    Public Sub AggiorItem(ByRef Visual As Boolean)
        Dim Nome As String
        Dim V As ValoriComm
        Dim NomeF As String
        Dim i As Short
        If Visual Then
            Nome = propItem ' InputBox("Nome Item", "Inserimento nuovo item", propItem)
        Else
            Nome = propItem
        End If
        If Len(Trim(Nome)) = 0 Then
            MsgBox("Non è accettabile un nome bianco")
            Exit Sub
        End If
        For i = 1 To CShort(job.Comm.Ind.Count())
            If job.Comm.Ind.Item(i).Data.Assieme.Trim = Nome.Trim Then
                If Visual Then MsgBox("L'item " & Nome & " esiste già", MsgBoxStyle.Information)
                Combo1(1).SelectedIndex = i - 1
                Exit Sub
            End If
        Next
Rif1:   NomeF = "000" ' InputBox("N° Disegno", "Inserimento nuovo item", "000")
        'NomeF = Trim(NomeF)
        'If Len(NomeF) = 0 Then Exit Sub
        'If Len(NomeF) <> 3 Then
        'MsgBox("Il numero dell'assieme deve essere di tre caratteri", MsgBoxStyle.Information)
        'GoTo Rif1
        'End If
        For i = 1 To CShort(job.Comm.Ind.Count())
            If job.Comm.Ind.Item(i).Data.File = NomeF Then
                MsgBox("Il numero " & NomeF & " esiste già" & _
                "e corrisponde all'apparecchio " & job.Comm.Ind.Item(i).Data.Assieme, MsgBoxStyle.Information)
                Combo1(1).SelectedIndex = i - 1
                Exit Sub
            End If
        Next
        V = New ValoriComm
        V.Assieme = Nome
        V.File = NomeF
        If job.Comm.Ind.Count() = 1 And job.Comm.Ind.Item(1).Data.Assieme Is Nothing Then
            job.Comm.Ind(1).Data = V
        Else
            job.Comm.Ind.Add(V)
        End If
        job.Comm.NumAs = CShort(job.Comm.Ind.Count())
        AggItem()
        Combo1(1).SelectedIndex = job.Comm.Ind.Count() - 1
    End Sub
    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked Then job.Comm.Asse = "V"
    End Sub
    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked Then job.Comm.Asse = "H"
    End Sub

    Private Sub txtFile_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtFile.Validating
        Dim Num As String = txtFile.Text.Trim
        If Num.Length <> 3 Then
            e.Cancel = True
            txtFile.Select(0, txtFile.Text.Length)
            ErrorProvider1.SetError(txtFile, "il Numero deve essere una stringa di tre caratteri numerici")
            Exit Sub
        End If
        Dim i As Short
        For i = 1 To CShort(job.Comm.Ind.Count())
            If job.Comm.Ind.Item(i).Data.File = Num Then
                Dim testo As String = "Il numero " & Num & " esiste già" & _
                "e corrisponde all'apparecchio " & job.Comm.Ind.Item(i).Data.Assieme
                txtFile.Select(0, txtFile.Text.Length)
                ErrorProvider1.SetError(txtFile, testo)
                e.Cancel = True
                Exit Sub
            End If
        Next
    End Sub

    Private Sub txtFile_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFile.Validated
        ErrorProvider1.SetError(txtFile, "")
        job.Comm.Ind.Item(job.Comm.indice).Data.File = txtFile.Text
        _Text1_0.Text = job.Comm.Arch.Trim & "." & job.Comm.Ind.Item(job.Comm.indice).Data.File
    End Sub

    Private Sub _Combo1_0_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Combo1_0.SelectedIndexChanged
        Combo1_SelectedIndexChanged(0)
    End Sub

    Private Sub _Combo1_1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Combo1_1.SelectedIndexChanged
        Combo1_SelectedIndexChanged(1)
    End Sub

    Private Sub _Command4_0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Command4_0.Click
        Command4_Click(0)
    End Sub

    Private Sub _Command4_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Command4_1.Click
        Command4_Click(1)
    End Sub

    Private Sub _Command4_2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Command4_2.Click
        Command4_Click(2)
    End Sub

    Private Sub _Command4_3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Command4_3.Click
        Command4_Click(3)
    End Sub

    Private Sub _Text1_1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Text1_1.TextChanged
        job.Comm.Clie = _Text1_1.Text.Trim
    End Sub

    Private Sub _Text1_2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Text1_2.TextChanged
        job.Comm.Oggetto = _Text1_2.Text.Trim
    End Sub
End Class