Option Strict On
Option Explicit On
Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary
Friend Class frmDis3D
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
    Public WithEvents cmdHelp As System.Windows.Forms.Button
    Public WithEvents txtLungh As System.Windows.Forms.TextBox
    Public WithEvents txtFile As System.Windows.Forms.TextBox
    Public WithEvents cmdFile As System.Windows.Forms.Button
    Public WithEvents cmdCancel As System.Windows.Forms.Button
    '	Public WithEvents ProgressBar1 As AxMSComctlLib.AxProgressBar
    Public WithEvents cmdProcedi As System.Windows.Forms.Button
    Public WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents Label4 As System.Windows.Forms.Label
    Public WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents Label1 As System.Windows.Forms.Label
    'NOTA: la routine seguente è richiesta dalla progettazione Windows Form.
    'Può essere modificata utilizzando la finestra di progettazione Windows Form.
    'Non modificarla mediante l'editor di codice.
    Friend WithEvents CommonDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmdHelp = New System.Windows.Forms.Button
        Me.txtLungh = New System.Windows.Forms.TextBox
        Me.txtFile = New System.Windows.Forms.TextBox
        Me.cmdFile = New System.Windows.Forms.Button
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdProcedi = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.CommonDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.SuspendLayout()
        '
        'cmdHelp
        '
        Me.cmdHelp.BackColor = System.Drawing.SystemColors.Control
        Me.cmdHelp.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdHelp.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdHelp.Location = New System.Drawing.Point(256, 152)
        Me.cmdHelp.Name = "cmdHelp"
        Me.cmdHelp.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdHelp.Size = New System.Drawing.Size(53, 25)
        Me.cmdHelp.TabIndex = 9
        Me.cmdHelp.Text = "Help"
        '
        'txtLungh
        '
        Me.txtLungh.AcceptsReturn = True
        Me.txtLungh.AutoSize = False
        Me.txtLungh.BackColor = System.Drawing.SystemColors.Window
        Me.txtLungh.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtLungh.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtLungh.Location = New System.Drawing.Point(120, 58)
        Me.txtLungh.MaxLength = 0
        Me.txtLungh.Name = "txtLungh"
        Me.txtLungh.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtLungh.Size = New System.Drawing.Size(173, 17)
        Me.txtLungh.TabIndex = 8
        Me.txtLungh.Text = ""
        '
        'txtFile
        '
        Me.txtFile.AcceptsReturn = True
        Me.txtFile.AutoSize = False
        Me.txtFile.BackColor = System.Drawing.SystemColors.Window
        Me.txtFile.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtFile.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtFile.Location = New System.Drawing.Point(4, 36)
        Me.txtFile.MaxLength = 0
        Me.txtFile.Name = "txtFile"
        Me.txtFile.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtFile.Size = New System.Drawing.Size(289, 19)
        Me.txtFile.TabIndex = 6
        Me.txtFile.Text = ""
        '
        'cmdFile
        '
        Me.cmdFile.BackColor = System.Drawing.SystemColors.Control
        Me.cmdFile.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdFile.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdFile.Location = New System.Drawing.Point(296, 37)
        Me.cmdFile.Name = "cmdFile"
        Me.cmdFile.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdFile.Size = New System.Drawing.Size(17, 17)
        Me.cmdFile.TabIndex = 5
        Me.cmdFile.Text = "..."
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCancel.Location = New System.Drawing.Point(128, 152)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCancel.Size = New System.Drawing.Size(53, 25)
        Me.cmdCancel.TabIndex = 4
        Me.cmdCancel.Text = "Cancel"
        '
        'cmdProcedi
        '
        Me.cmdProcedi.BackColor = System.Drawing.SystemColors.Control
        Me.cmdProcedi.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdProcedi.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdProcedi.Location = New System.Drawing.Point(192, 152)
        Me.cmdProcedi.Name = "cmdProcedi"
        Me.cmdProcedi.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdProcedi.Size = New System.Drawing.Size(57, 25)
        Me.cmdProcedi.TabIndex = 1
        Me.cmdProcedi.Text = "Procedi"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(0, 88)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(144, 17)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Numero tubi:"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(4, 60)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(113, 17)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "lunghezza Tubo : "
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(0, 108)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(136, 17)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Avanzamento : "
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(8, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(133, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Selezionare il file di Input:"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(0, 128)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(312, 16)
        Me.ProgressBar1.TabIndex = 11
        '
        'frmDis3D
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(315, 182)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.cmdHelp)
        Me.Controls.Add(Me.txtLungh)
        Me.Controls.Add(Me.txtFile)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdFile)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdProcedi)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Location = New System.Drawing.Point(4, 24)
        Me.Name = "frmDis3D"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "Generazione disegno 3D"
        Me.ResumeLayout(False)

    End Sub
#End Region
#Region "Supporto aggiornamento "
    Private Shared m_vb6FormDefInstance As frmDis3D
    Private Shared m_InitializingDefInstance As Boolean
    Public Shared Property DefInstance() As frmDis3D
        Get
            If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
                m_InitializingDefInstance = True
                m_vb6FormDefInstance = New frmDis3D
                m_InitializingDefInstance = False
            End If
            DefInstance = m_vb6FormDefInstance
        End Get
        Set(ByVal Value As frmDis3D)
            m_vb6FormDefInstance = Value
        End Set
    End Property
#End Region
    Private numtubi As Integer
    Private Lungtubo As Single
    Private Cad As RoutBase1.Auto_CAD
    Private RecoRb2 As typrecB2
    Public NomeFileRB2 As String
    Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
        Hide()
    End Sub
    Private Sub cmdFile_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdFile.Click
        CommonDialog1.Filter = "File Input (*.RB2)|*.RB2|"
        CommonDialog1.InitialDirectory = System.IO.Path.GetDirectoryName(NomeFileRB2)
        CommonDialog1.ShowDialog()
        txtFile.Text = CommonDialog1.FileName
        If Not System.IO.File.Exists(txtFile.Text) Then Exit Sub
        NomeFileRB2 = txtFile.Text
        '
        'Apre il file coo e lo carica nelle strutture
        '   File = FreeFile
        '   Open nomeFileCoo For Input As #File
        '   Rb2 = FreeFile
        '   Open Left(nomeFileCoo, Len(nomeFileCoo) - 3) + "RB2" For Random As #Rb2 Len = Len(RecoRb2)
        '   Conto = 0
        '   i = 0
        '
        '   Do While Not EOF(File)
        '      Input #File, Temp
        '      Riga = Splitta(Temp)
        '      If Conto > 0 Then           'salta la prima riga perchè è l'intestazione
        '         ReDim Preserve FileCoo(Conto)           'Conto - 1 perchè voglio partire da 0 e la primo volta chee passa qui il conto è già a 1
        '         FileCoo(Conto).x1 = GlobalRoutines.ValVir(Riga(1))
        '         FileCoo(Conto).y1 = GlobalRoutines.ValVir(Riga(2))
        '         FileCoo(Conto).x2 = GlobalRoutines.ValVir(Riga(3))
        '         FileCoo(Conto).y2 = GlobalRoutines.ValVir(Riga(4))
        '         For j = 1 To Len(Rb2) \ Len(RecoRb2)
        '            Get #Rb2, j, RecoRb2
        '            If GlobalRoutines.ValVir(RecoRb2.Sigla) = Conto Then Exit For
        '         Next
        '         Debug.Print GlobalRoutines.ValVir(RecoRb2.Sigla); RecoRb2.Utubo.P0.x; RecoRb2.Utubo.P0.y; RecoRb2.Utubo.p1.x; RecoRb2.Utubo.p1.y; RecoRb2.Altezza; RecoRb2.Raggio
        '         Debug.Print FileMto(Conto).numero; FileCoo(Conto).x1; FileCoo(Conto).y1; FileCoo(Conto).x2; FileCoo(Conto).y2; FileMto(Conto).ExtraLung; FileMto(Conto).Raggio
        '      End If
        '      Conto = Conto + 1
        '   Loop
        '   Close #File
    End Sub
    Private Sub cmdHelp_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdHelp.Click
        Help.ShowHelp(Me, RadiceHelp, HelpNavigator.Topic, HelpTopic(IDH_HID_AUTOCAD1))
    End Sub
    Private Sub cmdProcedi_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdProcedi.Click
        'GeneraTubo 1, 1, 800, 85
        Dim i As Integer
        Dim nrec As Integer
        Dim Nome As String
        'Dim FileCoo(1070) As Object
        Try
            Cad = New RoutBase1.Auto_CAD
            cmdProcedi.Enabled = False
            cmdHelp.Enabled = False
            cmdCancel.Text = "Cancel"
            ProgressBar1.Minimum = 0
            Dim fs As New FileStream(gencommes.Trim + ".RB2", FileMode.Open)
            Dim bf As New BinaryFormatter
            Franco.Manici.nRB2 = CType(bf.Deserialize(fs), RoutBase1.OggList)
            fs.Close()
            nrec = Franco.Manici.nRB2.Count ' CInt(LOF(Rb2) \ Len(RecoRb2))
            ProgressBar1.Maximum = nrec 'UBound(FileMto)
            For i = 1 To nrec ' UBound(FileMto)
                RecoRb2 = CType(Franco.Manici.nRB2.ItemAt(i), typrecB2)
                Cad.GeneraTubo(Str(i), "A", Lungtubo + RecoRb2.Altezza, RecoRb2.Raggio, DaTos(iDat).dtubo)
                Nome = Trim(Str(i))
                Cad.inserisciBlocco(Nome, i, RecoRb2.Utubo.P0, RecoRb2.Utubo.p1, RecoRb2.Raggio)
                Label2.Text = "Numero Tubi : " & i & " di " & nrec
                System.Windows.Forms.Application.DoEvents()
                ProgressBar1.Value = i
            Next
            ChiuB2()
            cmdProcedi.Enabled = True
            cmdHelp.Enabled = True
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
        cmdCancel.Text = "OK"
    End Sub
    Private Sub frmDis3D_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        NomeFileRB2 = Trim(gencommes) & ".RB2"
        txtFile.Text = NomeFileRB2
    End Sub
    'UPGRADE_WARNING: L'evento txtLungh.TextChanged può essere generato quando il form è inizializzato. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup2075"'
    Private Sub txtLungh_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtLungh.TextChanged
        Lungtubo = CSng(GlobalRoutines.ValVir(txtLungh.Text))
    End Sub
End Class