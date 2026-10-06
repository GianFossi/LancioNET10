Option Strict On
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports System.io
Imports System.Windows
Imports System.Reflection
Imports RoutBase1
Friend Class frmProblem
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
    Public WithEvents cmdElim As System.Windows.Forms.Button
    Public WithEvents _Text1_5 As System.Windows.Forms.TextBox
    Public WithEvents chkIntest As System.Windows.Forms.CheckBox
    Public WithEvents _Text1_2 As System.Windows.Forms.TextBox
    Public WithEvents StampaCompleta As System.Windows.Forms.CheckBox
    Public WithEvents _Text1_4 As System.Windows.Forms.TextBox
    Public WithEvents _Text1_1 As System.Windows.Forms.TextBox
    Public WithEvents _Label2_5 As System.Windows.Forms.Label
    Public WithEvents _Label2_4 As System.Windows.Forms.Label
    Public WithEvents _Label2_2 As System.Windows.Forms.Label
    Public WithEvents _Label2_1 As System.Windows.Forms.Label
    Public WithEvents _Label2_0 As System.Windows.Forms.Label
    Public WithEvents Label1 As System.Windows.Forms.Label
    'NOTA: la routine seguente è richiesta dalla progettazione Windows Form.
    'Può essere modificata utilizzando la finestra di progettazione Windows Form.
    'Non modificarla mediante l'editor di codice.
    Friend WithEvents txtProg As System.Windows.Forms.TextBox
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Public WithEvents cmdOK As System.Windows.Forms.Button
    Public WithEvents cmdOpen As System.Windows.Forms.Button
    Public WithEvents cmdCancel As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmProblem))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmdOpen = New System.Windows.Forms.Button
        Me.cmdElim = New System.Windows.Forms.Button
        Me._Text1_5 = New System.Windows.Forms.TextBox
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.chkIntest = New System.Windows.Forms.CheckBox
        Me._Text1_2 = New System.Windows.Forms.TextBox
        Me.StampaCompleta = New System.Windows.Forms.CheckBox
        Me.cmdOK = New System.Windows.Forms.Button
        Me._Text1_4 = New System.Windows.Forms.TextBox
        Me._Text1_1 = New System.Windows.Forms.TextBox
        Me._Label2_5 = New System.Windows.Forms.Label
        Me._Label2_4 = New System.Windows.Forms.Label
        Me._Label2_2 = New System.Windows.Forms.Label
        Me._Label2_1 = New System.Windows.Forms.Label
        Me._Label2_0 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtProg = New System.Windows.Forms.TextBox
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.SuspendLayout()
        '
        'cmdOpen
        '
        Me.cmdOpen.BackColor = System.Drawing.SystemColors.Control
        Me.cmdOpen.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdOpen.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdOpen.Image = CType(resources.GetObject("cmdOpen.Image"), System.Drawing.Image)
        Me.cmdOpen.Location = New System.Drawing.Point(304, 112)
        Me.cmdOpen.Name = "cmdOpen"
        Me.cmdOpen.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdOpen.Size = New System.Drawing.Size(24, 24)
        Me.cmdOpen.TabIndex = 4
        Me.ToolTip1.SetToolTip(Me.cmdOpen, "Apri un progetto esistente od un nuovo progetto")
        '
        'cmdElim
        '
        Me.cmdElim.BackColor = System.Drawing.SystemColors.Control
        Me.cmdElim.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdElim.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdElim.Image = CType(resources.GetObject("cmdElim.Image"), System.Drawing.Image)
        Me.cmdElim.Location = New System.Drawing.Point(336, 112)
        Me.cmdElim.Name = "cmdElim"
        Me.cmdElim.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdElim.Size = New System.Drawing.Size(25, 25)
        Me.cmdElim.TabIndex = 16
        Me.cmdElim.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        '_Text1_5
        '
        Me._Text1_5.AcceptsReturn = True
        Me._Text1_5.AutoSize = False
        Me._Text1_5.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_5.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_5.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_5.Location = New System.Drawing.Point(166, 234)
        Me._Text1_5.MaxLength = 0
        Me._Text1_5.Name = "_Text1_5"
        Me._Text1_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_5.Size = New System.Drawing.Size(231, 21)
        Me._Text1_5.TabIndex = 14
        Me._Text1_5.Text = ""
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCancel.Location = New System.Drawing.Point(359, 275)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCancel.Size = New System.Drawing.Size(50, 21)
        Me.cmdCancel.TabIndex = 13
        Me.cmdCancel.Text = "Cancel"
        '
        'chkIntest
        '
        Me.chkIntest.BackColor = System.Drawing.SystemColors.Control
        Me.chkIntest.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkIntest.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkIntest.Location = New System.Drawing.Point(168, 285)
        Me.chkIntest.Name = "chkIntest"
        Me.chkIntest.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkIntest.Size = New System.Drawing.Size(177, 17)
        Me.chkIntest.TabIndex = 12
        Me.chkIntest.Text = "Rapporto con intestazione"
        '
        '_Text1_2
        '
        Me._Text1_2.AcceptsReturn = True
        Me._Text1_2.AutoSize = False
        Me._Text1_2.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_2.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_2.Location = New System.Drawing.Point(168, 168)
        Me._Text1_2.MaxLength = 0
        Me._Text1_2.Name = "_Text1_2"
        Me._Text1_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_2.Size = New System.Drawing.Size(231, 21)
        Me._Text1_2.TabIndex = 2
        Me._Text1_2.Text = ""
        '
        'StampaCompleta
        '
        Me.StampaCompleta.BackColor = System.Drawing.SystemColors.Control
        Me.StampaCompleta.Cursor = System.Windows.Forms.Cursors.Default
        Me.StampaCompleta.ForeColor = System.Drawing.SystemColors.ControlText
        Me.StampaCompleta.Location = New System.Drawing.Point(168, 269)
        Me.StampaCompleta.Name = "StampaCompleta"
        Me.StampaCompleta.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StampaCompleta.Size = New System.Drawing.Size(137, 20)
        Me.StampaCompleta.TabIndex = 11
        Me.StampaCompleta.TabStop = False
        Me.StampaCompleta.Text = "Stampa completa"
        '
        'cmdOK
        '
        Me.cmdOK.BackColor = System.Drawing.SystemColors.Control
        Me.cmdOK.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdOK.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdOK.Location = New System.Drawing.Point(420, 275)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdOK.Size = New System.Drawing.Size(31, 21)
        Me.cmdOK.TabIndex = 5
        Me.cmdOK.Text = "OK"
        '
        '_Text1_4
        '
        Me._Text1_4.AcceptsReturn = True
        Me._Text1_4.AutoSize = False
        Me._Text1_4.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_4.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_4.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_4.Location = New System.Drawing.Point(168, 202)
        Me._Text1_4.MaxLength = 0
        Me._Text1_4.Name = "_Text1_4"
        Me._Text1_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_4.Size = New System.Drawing.Size(231, 21)
        Me._Text1_4.TabIndex = 3
        Me._Text1_4.Text = ""
        '
        '_Text1_1
        '
        Me._Text1_1.AcceptsReturn = True
        Me._Text1_1.AutoSize = False
        Me._Text1_1.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_1.Location = New System.Drawing.Point(168, 140)
        Me._Text1_1.MaxLength = 0
        Me._Text1_1.Name = "_Text1_1"
        Me._Text1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_1.Size = New System.Drawing.Size(281, 21)
        Me._Text1_1.TabIndex = 1
        Me._Text1_1.Text = ""
        '
        '_Label2_5
        '
        Me._Label2_5.BackColor = System.Drawing.SystemColors.Control
        Me._Label2_5.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_5.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label2_5.Location = New System.Drawing.Point(18, 234)
        Me._Label2_5.Name = "_Label2_5"
        Me._Label2_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_5.Size = New System.Drawing.Size(141, 21)
        Me._Label2_5.TabIndex = 15
        Me._Label2_5.Text = "Progettista"
        '
        '_Label2_4
        '
        Me._Label2_4.BackColor = System.Drawing.SystemColors.Control
        Me._Label2_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label2_4.Location = New System.Drawing.Point(18, 202)
        Me._Label2_4.Name = "_Label2_4"
        Me._Label2_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_4.Size = New System.Drawing.Size(141, 21)
        Me._Label2_4.TabIndex = 10
        Me._Label2_4.Text = "Immatricolazione rapporto"
        '
        '_Label2_2
        '
        Me._Label2_2.BackColor = System.Drawing.SystemColors.Control
        Me._Label2_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label2_2.Location = New System.Drawing.Point(20, 170)
        Me._Label2_2.Name = "_Label2_2"
        Me._Label2_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_2.Size = New System.Drawing.Size(141, 21)
        Me._Label2_2.TabIndex = 9
        Me._Label2_2.Text = "Item"
        '
        '_Label2_1
        '
        Me._Label2_1.BackColor = System.Drawing.SystemColors.Control
        Me._Label2_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label2_1.Location = New System.Drawing.Point(20, 140)
        Me._Label2_1.Name = "_Label2_1"
        Me._Label2_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_1.Size = New System.Drawing.Size(141, 21)
        Me._Label2_1.TabIndex = 8
        Me._Label2_1.Text = "Cliente e Impianto"
        '
        '_Label2_0
        '
        Me._Label2_0.BackColor = System.Drawing.SystemColors.Control
        Me._Label2_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label2_0.Location = New System.Drawing.Point(20, 110)
        Me._Label2_0.Name = "_Label2_0"
        Me._Label2_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_0.Size = New System.Drawing.Size(141, 21)
        Me._Label2_0.TabIndex = 7
        Me._Label2_0.Text = "Nome del progetto"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(20, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(421, 81)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Label1"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txtProg
        '
        Me.txtProg.Enabled = False
        Me.txtProg.Location = New System.Drawing.Point(168, 112)
        Me.txtProg.Name = "txtProg"
        Me.txtProg.Size = New System.Drawing.Size(128, 20)
        Me.txtProg.TabIndex = 19
        Me.txtProg.Text = ""
        '
        'frmProblem
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(471, 319)
        Me.ControlBox = False
        Me.Controls.Add(Me.txtProg)
        Me.Controls.Add(Me._Text1_5)
        Me.Controls.Add(Me._Text1_2)
        Me.Controls.Add(Me._Text1_4)
        Me.Controls.Add(Me._Text1_1)
        Me.Controls.Add(Me.cmdElim)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.chkIntest)
        Me.Controls.Add(Me.cmdOpen)
        Me.Controls.Add(Me.StampaCompleta)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me._Label2_5)
        Me.Controls.Add(Me._Label2_4)
        Me.Controls.Add(Me._Label2_2)
        Me.Controls.Add(Me._Label2_1)
        Me.Controls.Add(Me._Label2_0)
        Me.Controls.Add(Me.Label1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Location = New System.Drawing.Point(263, 302)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmProblem"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Dati generali"
        Me.ResumeLayout(False)

    End Sub
#End Region 
#Region "Supporto aggiornamento "
    'Private Shared m_vb6FormDefInstance As frmProblem
    'Private Shared m_InitializingDefInstance As Boolean
    'Public Shared Property DefInstance() As frmProblem
    '		Get
    '			If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
    '				m_InitializingDefInstance = True
    '				m_vb6FormDefInstance = New frmProblem()
    '				m_InitializingDefInstance = False
    '			End If
    '			DefInstance = m_vb6FormDefInstance
    '		End Get
    '		Set
    '			m_vb6FormDefInstance = Value
    '		End Set
    '	End Property
#End Region 
	'Private Commessa As String
    Public Motore As clsMotore
	Private FileData As String
    Friend OK As Boolean
    Private Ext0 As String
    Private Dentro As Boolean
    Private Inizializzando As Boolean
    Event Cambio(ByRef f As String)
	Event Lost(ByRef f As String)
    Event SaveData(ByRef f As String)
    Event Uccidi(ByRef f As String)
    Event Sonda(ByRef f As String)
	Event Rifiuto()
    Event NuovoLav(ByRef f As String)
    Private Sub chkIntest_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkIntest.CheckStateChanged
        Motore.Problem.Intest = CShort(chkIntest.CheckState)
    End Sub
    Private Sub cmdElim_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdElim.Click
        If FileData.Trim.Length = 0 Then
            MessageBox.Show("Non vi è alcun progetto selezionato da poter eliminare", "LancioNET", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        If Not MsgBox("Vuoi veramente eliminare il file " & FileData & "?", CType(MsgBoxStyle.YesNo + MsgBoxStyle.Question, MsgBoxStyle), "Lancio") = MsgBoxResult.Yes Then Exit Sub
        RaiseEvent Uccidi(FileData)
        Motore.Problem.OrdineFile -= 1
        ScegliIlPrimo()
    End Sub
    Private Sub cmdOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOK.Click
        If OK Then CambioFile()
        If FileData = "" Then
            MsgBox("Non è stato selezionato un nome di commessa/progetto valido")
            Exit Sub
        End If
        ' RaiseEvent SaveData(FileData)
        Dentro = False
        OK = True
        Hide()
    End Sub
    Private Sub cmdOpen_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOpen.Click
        Dim Nome As String
        Try
            If Motore.Problem.nonSciolto Then
                OpenFileDialog1.InitialDirectory = Motore.Inizio.Workdir
            Else
                OpenFileDialog1.InitialDirectory = Motore.Inizio.Datidir
            End If
            OpenFileDialog1.CheckFileExists = False
            OpenFileDialog1.AddExtension = True
            If OpenFileDialog1.ShowDialog() = Forms.DialogResult.Cancel Then Exit Sub
            Nome = OpenFileDialog1.FileName
            If Motore.Problem.nonSciolto Then
                Motore.Inizio.Workdir = System.IO.Path.GetDirectoryName(Nome)
            Else
                Motore.Inizio.Datidir = System.IO.Path.GetDirectoryName(Nome)
            End If
            txtProg.Text = System.IO.Path.GetFileNameWithoutExtension(Nome)
            FileData = Nome
            If IO.File.Exists(FileData) Then
                SondaFile()
            Else
                Motore.Problem.ClientPlant = "________"
                Motore.Problem.Item = "_______"
                Aggiorna()
                RaiseEvent NuovoLav(FileData)
                MsgBox("E' stato introdotto il nuovo lavoro " & FileData, MsgBoxStyle.Information)
            End If
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
        RaiseEvent Rifiuto()
        Me.Hide()
        Dentro = False
        OK = False
    End Sub
    Private Sub AggProblem()
        Dim Testo, Calcolo As String
        Dim Ext1 As String
        Try
            Dim aDescrAttr As AssemblyDescriptionAttribute() = CType(AssemblyDescriptionAttribute.GetCustomAttributes _
                                (Motore.AssemblyOriginale, GetType(AssemblyDescriptionAttribute)), AssemblyDescriptionAttribute())
            Ext1 = Motore.Problem.Extension
            Ext0 = Ext1.Substring(Ext1.Length - 3, 3) ' VB.Right(Ext1, 3)
            Calcolo = Motore.Problem.TipoFile
            If Calcolo.Length = 0 Then Calcolo = "Calcolo "
            If Not Calcolo.Substring(Calcolo.Length - 1, 1) = " " Then Calcolo &= " "
            OpenFileDialog1.Filter = Calcolo & Ext0 & " (*" & Ext1 & ")|*" & Ext1
            OpenFileDialog1.DefaultExt = Ext0
            Testo = RTrim(aDescrAttr(0).Description) & vbCrLf & vbCrLf
            Testo = Testo & Trigon.StringaInformativaProgramma(Motore.AssemblyOriginale) ' "Program " & Motore.About.ProgName & ", " & Motore.About.ProgVers & "  " & Motore.About.ProgDate & vbCrLf
            Label1.Text = Testo
            Vecchio = True
            Aggiorna()
            txtProg.Text = Motore.Problem.Commessa
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Private Sub Aggiorna()
        _Text1_1.Text = Motore.Problem.ClientPlant
        _Text1_2.Text = Motore.Problem.Item
        _Text1_4.Text = Motore.Problem.Doc
        _Text1_5.Text = Motore.Problem.Author
    End Sub
    Private Sub Annulla()
        _Text1_1.Text = ""
        _Text1_2.Text = ""
        _Text1_4.Text = ""
        _Text1_5.Text = ""
    End Sub
    Private Sub frmProblem_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        If Motore Is Nothing Then '7-5-99
            MsgBox("Motore non attivo in Routbase1.frmProblem")
            Exit Sub
        End If
        Select Case Motore.Modo
            Case 1
                _Text1_2.Enabled = False
                _Text1_4.Enabled = False
                _Label2_2.Enabled = False
                _Label2_4.Enabled = False
                StampaCompleta.Enabled = False
                chkIntest.Enabled = False
            Case 2
                _Text1_4.Enabled = False
                _Label2_4.Enabled = False
                StampaCompleta.Enabled = False
                chkIntest.Enabled = False
            Case 3
                StampaCompleta.Enabled = False
                chkIntest.Enabled = False
                cmdOpen.Enabled = False
        End Select
        AggProblem()
    End Sub
    Private Sub StampaCompleta_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles StampaCompleta.CheckStateChanged
        Motore.Problem.StampaTutto = CShort(StampaCompleta.CheckState)
    End Sub
    Friend Sub SondaFile()
        Dim Base As String
        Dim Commessa As String = Me.txtProg.Text.Trim
        If Motore.Problem.nonSciolto Then Base = RTrim(Motore.Inizio.Workdir) Else Base = RTrim(Motore.Inizio.Datidir)
        Dim NewFile As String = Base & "\" & Commessa & Motore.Problem.Extension
        If IO.File.Exists(NewFile) Then
            FileData = NewFile
            RaiseEvent Sonda(FileData)
            Motore.Problem.Commessa = Me.txtProg.Text.Trim
            Aggiorna()
            OK = True
        Else
            Annulla()
            txtProg.Text = ""
            OK = False
        End If
    End Sub
    Friend Sub CambioFile()
        Dim NewFile, Base As String, valido As Boolean
        OK = False
        Motore.Problem.Commessa = Me.txtProg.Text.Trim
        If Motore.Problem.Commessa.Length = 0 Then Exit Sub
        valido = True
        If Motore.Problem.Commessa.Length = 0 Then valido = False
        If valido Then valido = Motore.Problem.Commessa.IndexOfAny(IO.Path.InvalidPathChars) = -1
        If valido Then valido = Motore.Problem.Commessa.IndexOf(IO.Path.VolumeSeparatorChar) = -1
        If Not valido Then
            MsgBox("Il nome fornito per la commessa non è valido", , "Lancio")
            Motore.Problem.Commessa = ""
            Exit Sub
        End If
        If Motore.Problem.nonSciolto Then Base = RTrim(Motore.Inizio.Workdir) Else Base = RTrim(Motore.Inizio.Datidir)
        NewFile = Base & "\" & RTrim(Motore.Problem.Commessa) & Motore.Problem.Extension
        OK = True
        'If NewFile = FileData Then Exit Sub
        If IO.File.Exists(NewFile) Then
            FileData = NewFile
            RaiseEvent SaveData(FileData)
            RaiseEvent Lost(FileData)
        Else
            Dim Risp As MsgBoxResult = MsgBox("Vuoi introdurre il nuovo lavoro " & txtProg.Text & "?", _
             CType(MsgBoxStyle.Question Or MsgBoxStyle.YesNo, MsgBoxStyle), "Lancio")
            If Risp = MsgBoxResult.Yes Then
                FileData = NewFile
                RaiseEvent NuovoLav(FileData)
                RaiseEvent Lost(FileData)
            End If
        End If
        AggProblem()
    End Sub

    Private Sub _Text1_1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Text1_1.TextChanged
        If Inizializzando Then Exit Sub
        Motore.Problem.ClientPlant = _Text1_1.Text
    End Sub
    Private Sub _Text1_2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Text1_2.TextChanged
        If Inizializzando Then Exit Sub
        Motore.Problem.Item = _Text1_2.Text
    End Sub
    Private Sub _Text1_4_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Text1_4.TextChanged
        If Inizializzando Then Exit Sub
        Motore.Problem.Doc = _Text1_4.Text
    End Sub
    Private Sub _Text1_5_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Text1_5.TextChanged
        If Inizializzando Then Exit Sub
        Motore.Problem.Author = _Text1_5.Text
    End Sub
    Private Sub txtProg_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtProg.TextChanged
        'SondaFile()
        'OK = False
    End Sub
    Friend Sub ScegliIlPrimo()
        Dim InitialDir As String
        Dim f As FileInfo
        If Motore.Problem.nonSciolto Then
            InitialDir = Motore.Inizio.Workdir
        Else
            InitialDir = Motore.Inizio.Datidir
        End If
        Dim dir As New DirectoryInfo(InitialDir)
        Do
            Try
                f = dir.GetFiles("*." & Ext0)(Motore.Problem.OrdineFile)
            Catch
                txtProg.Text = ""
                Dentro = True
                Exit Sub
            End Try
            Motore.Problem.OrdineFile += 1
            FileData = f.Name
            If IO.Path.GetExtension(FileData) = "." & Ext0 Then Exit Do
        Loop
        txtProg.Text = IO.Path.GetFileNameWithoutExtension(FileData)
    End Sub
    Private Sub frmProblem_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        If Dentro Then Exit Sub
        If txtProg.Text.Length = 0 Then
            ScegliIlPrimo()
        End If
        SondaFile()
        Dentro = True
    End Sub

    Private Sub txtProg_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtProg.KeyPress
        ' Dim s As String
        ' If "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789".IndexOf(e.KeyChar) = -1 Then
        ' Motore.MostraAiuto(2100, mioTitolo:=Trigon.FormatS(HelpStringa(2100), e.KeyChar))
        ' e.Handled = True
        ' End If
    End Sub
End Class