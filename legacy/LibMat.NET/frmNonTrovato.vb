Public Class frmNonTrovato
    Inherits System.Windows.Forms.Form
    Public rsCandidati As DataTable
    Public dvCandidati As DataView
    Public T1a As DataRowView
    Public Nuovo As Boolean
    Public RowIndex As Integer
    Private Inizializzando As Boolean

#Region " Codice generato da Progettazione Windows Form "

    Public Sub New()
        MyBase.New()
        Inizializzando = True
        'Chiamata richiesta da Progettazione Windows Form.
        InitializeComponent()
        Inizializzando = False
        'Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent()
        Inizializza()
    End Sub
    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub
    'Richiesto da Progettazione Windows Form
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura che segue è richiesta da Progettazione Windows Form.
    'Può essere modificata in Progettazione Windows Form.  
    'Non modificarla nell'editor del codice.
    Friend WithEvents Candidati As System.Windows.Forms.DataGrid
    Friend WithEvents txtSpec As System.Windows.Forms.TextBox
    Friend WithEvents txtGrade As System.Windows.Forms.TextBox
    Friend WithEvents txtUNS As System.Windows.Forms.TextBox
    Friend WithEvents txtClass As System.Windows.Forms.TextBox
    Friend WithEvents txtSize As System.Windows.Forms.TextBox
    Friend WithEvents txtNotes As System.Windows.Forms.TextBox
    Friend WithEvents cmdSelez As System.Windows.Forms.Button
    Friend WithEvents cmdNuovo As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DataGridTextBoxColumn1 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn2 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn3 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn4 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn5 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn6 As System.Windows.Forms.DataGridTextBoxColumn
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Candidati = New System.Windows.Forms.DataGrid
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle
        Me.DataGridTextBoxColumn1 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn2 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn3 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn4 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn5 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn6 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.txtSpec = New System.Windows.Forms.TextBox
        Me.txtGrade = New System.Windows.Forms.TextBox
        Me.txtUNS = New System.Windows.Forms.TextBox
        Me.txtClass = New System.Windows.Forms.TextBox
        Me.txtSize = New System.Windows.Forms.TextBox
        Me.txtNotes = New System.Windows.Forms.TextBox
        Me.cmdSelez = New System.Windows.Forms.Button
        Me.cmdNuovo = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        CType(Me.Candidati, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Candidati
        '
        Me.Candidati.DataMember = ""
        Me.Candidati.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.Candidati.Location = New System.Drawing.Point(16, 80)
        Me.Candidati.Name = "Candidati"
        Me.Candidati.PreferredColumnWidth = 90
        Me.Candidati.ReadOnly = True
        Me.Candidati.Size = New System.Drawing.Size(584, 168)
        Me.Candidati.TabIndex = 0
        Me.Candidati.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.DataGrid = Me.Candidati
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DataGridTextBoxColumn1, Me.DataGridTextBoxColumn2, Me.DataGridTextBoxColumn3, Me.DataGridTextBoxColumn4, Me.DataGridTextBoxColumn5, Me.DataGridTextBoxColumn6})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = ""
        '
        'DataGridTextBoxColumn1
        '
        Me.DataGridTextBoxColumn1.Format = ""
        Me.DataGridTextBoxColumn1.FormatInfo = Nothing
        Me.DataGridTextBoxColumn1.MappingName = "Materiale"
        Me.DataGridTextBoxColumn1.Width = 160
        '
        'DataGridTextBoxColumn2
        '
        Me.DataGridTextBoxColumn2.Format = ""
        Me.DataGridTextBoxColumn2.FormatInfo = Nothing
        Me.DataGridTextBoxColumn2.MappingName = "Grade"
        Me.DataGridTextBoxColumn2.Width = 60
        '
        'DataGridTextBoxColumn3
        '
        Me.DataGridTextBoxColumn3.Format = ""
        Me.DataGridTextBoxColumn3.FormatInfo = Nothing
        Me.DataGridTextBoxColumn3.MappingName = "UNS"
        Me.DataGridTextBoxColumn3.Width = 60
        '
        'DataGridTextBoxColumn4
        '
        Me.DataGridTextBoxColumn4.Format = ""
        Me.DataGridTextBoxColumn4.FormatInfo = Nothing
        Me.DataGridTextBoxColumn4.MappingName = "Class"
        Me.DataGridTextBoxColumn4.Width = 75
        '
        'DataGridTextBoxColumn5
        '
        Me.DataGridTextBoxColumn5.Format = ""
        Me.DataGridTextBoxColumn5.FormatInfo = Nothing
        Me.DataGridTextBoxColumn5.MappingName = "Size"
        Me.DataGridTextBoxColumn5.Width = 75
        '
        'DataGridTextBoxColumn6
        '
        Me.DataGridTextBoxColumn6.Format = ""
        Me.DataGridTextBoxColumn6.FormatInfo = Nothing
        Me.DataGridTextBoxColumn6.MappingName = "Notes"
        Me.DataGridTextBoxColumn6.Width = 150
        '
        'txtSpec
        '
        Me.txtSpec.BackColor = System.Drawing.Color.White
        Me.txtSpec.Enabled = False
        Me.txtSpec.Location = New System.Drawing.Point(16, 48)
        Me.txtSpec.Name = "txtSpec"
        Me.txtSpec.Size = New System.Drawing.Size(144, 20)
        Me.txtSpec.TabIndex = 1
        Me.txtSpec.Text = "TextBox1"
        '
        'txtGrade
        '
        Me.txtGrade.BackColor = System.Drawing.Color.White
        Me.txtGrade.Enabled = False
        Me.txtGrade.Location = New System.Drawing.Point(168, 48)
        Me.txtGrade.Name = "txtGrade"
        Me.txtGrade.Size = New System.Drawing.Size(56, 20)
        Me.txtGrade.TabIndex = 2
        Me.txtGrade.Text = "lblGrade"
        '
        'txtUNS
        '
        Me.txtUNS.BackColor = System.Drawing.Color.White
        Me.txtUNS.Enabled = False
        Me.txtUNS.Location = New System.Drawing.Point(232, 48)
        Me.txtUNS.Name = "txtUNS"
        Me.txtUNS.Size = New System.Drawing.Size(56, 20)
        Me.txtUNS.TabIndex = 3
        Me.txtUNS.Text = "TextBox2"
        '
        'txtClass
        '
        Me.txtClass.BackColor = System.Drawing.Color.White
        Me.txtClass.Enabled = False
        Me.txtClass.Location = New System.Drawing.Point(296, 48)
        Me.txtClass.Name = "txtClass"
        Me.txtClass.Size = New System.Drawing.Size(72, 20)
        Me.txtClass.TabIndex = 4
        Me.txtClass.Text = "TextBox1"
        '
        'txtSize
        '
        Me.txtSize.BackColor = System.Drawing.Color.White
        Me.txtSize.Enabled = False
        Me.txtSize.Location = New System.Drawing.Point(376, 48)
        Me.txtSize.Name = "txtSize"
        Me.txtSize.Size = New System.Drawing.Size(72, 20)
        Me.txtSize.TabIndex = 5
        Me.txtSize.Text = "TextBox1"
        '
        'txtNotes
        '
        Me.txtNotes.BackColor = System.Drawing.Color.White
        Me.txtNotes.Enabled = False
        Me.txtNotes.Location = New System.Drawing.Point(456, 48)
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.Size = New System.Drawing.Size(144, 20)
        Me.txtNotes.TabIndex = 6
        Me.txtNotes.Text = "TextBox1"
        '
        'cmdSelez
        '
        Me.cmdSelez.Location = New System.Drawing.Point(616, 80)
        Me.cmdSelez.Name = "cmdSelez"
        Me.cmdSelez.Size = New System.Drawing.Size(160, 32)
        Me.cmdSelez.TabIndex = 7
        Me.cmdSelez.Text = "Assumi selezionato"
        '
        'cmdNuovo
        '
        Me.cmdNuovo.Location = New System.Drawing.Point(616, 120)
        Me.cmdNuovo.Name = "cmdNuovo"
        Me.cmdNuovo.Size = New System.Drawing.Size(160, 32)
        Me.cmdNuovo.TabIndex = 8
        Me.cmdNuovo.Text = "Crea nuovo materiale"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(16, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(776, 32)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Il materiale dell'aggiornamento ASME sotto rappresentato non ha trovato un corris" & _
        "pondente esatto nel presesistente database di Lancio. I possibili candidati a ra" & _
        "ppresentarlo sono elencati nella griglia di dati. Sceglerne uno o ordinare la cr" & _
        "eazione di un nuovo materiale."
        '
        'frmNonTrovato
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(800, 276)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdNuovo)
        Me.Controls.Add(Me.cmdSelez)
        Me.Controls.Add(Me.txtNotes)
        Me.Controls.Add(Me.txtSize)
        Me.Controls.Add(Me.txtClass)
        Me.Controls.Add(Me.txtUNS)
        Me.Controls.Add(Me.txtGrade)
        Me.Controls.Add(Me.txtSpec)
        Me.Controls.Add(Me.Candidati)
        Me.Name = "frmNonTrovato"
        Me.Text = "Candidati possibili"
        CType(Me.Candidati, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region
    Private Sub Inizializza()
        'Me.DataGridTextBoxColumn1.Width = 150
        'Me.DataGridTextBoxColumn2.Width = 60
        'Me.DataGridTextBoxColumn3.Width = 60
        'Me.DataGridTextBoxColumn6.Width = 150
    End Sub

    Private Sub Candidati_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Candidati.Click
        ' Me.Candidati.CurrentRowIndex()

    End Sub

    Private Sub cmdSelez_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelez.Click
        Nuovo = False
        RowIndex = Me.Candidati.CurrentRowIndex
        Hide()
    End Sub

    Private Sub cmdNuovo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNuovo.Click
        Nuovo = True
        Hide()
    End Sub

    Private Sub frmNonTrovato_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        Try
            Me.Candidati.SetDataBinding(dvCandidati, "")
            Me.Candidati.TableStyles(0).GridColumnStyles(0).Width = 150
            Me.Candidati.TableStyles(0).GridColumnStyles(1).Width = 60
            Me.Candidati.TableStyles(0).GridColumnStyles(2).Width = 60
            Me.Candidati.TableStyles(0).GridColumnStyles(5).Width = 150
            Me.Candidati.Width = 150 + 60 + 60 + 75 + 75 + 150 + 30
            Me.txtSpec.Text = CStr(T1a(CampoSN))
            If Not CampoTG Is Nothing Then Me.txtGrade.Text = CStr(T1a(CampoTG))
            Me.txtClass.Text = CStr(T1a(CampoCl))
            Me.txtSize.Text = CStr(T1a(CampoSi))
            Me.txtUNS.Text = CStr(T1a(CampoAU))
            Me.txtNotes.Text = CStr(T1a("Notes"))
        Catch ex As Exception
            MsgBox(ex.Message + vbCrLf + ex.StackTrace)
        End Try
    End Sub
End Class
