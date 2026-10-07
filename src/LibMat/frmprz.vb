Option Strict On
Option Explicit On
Imports System.Data
Imports System.Data.OleDb
Imports VB = Microsoft.VisualBasic
Friend Class frmprz
    Inherits System.Windows.Forms.Form
#Region "Codice generato dalla finestra di progettazione Windows Form "
    Public Sub New()
        MyBase.New()
        '  If m_vb6FormDefInstance Is Nothing Then
        '  If m_InitializingDefInstance Then
        '  m_vb6FormDefInstance = Me
        '  Else
        '      Try
        '  'La prima istanza creata per il form di avvio rappresenta l'istanza predefinita.
        '  If System.Reflection.Assembly.GetExecutingAssembly.EntryPoint IsNot Nothing AndAlso System.Reflection.Assembly.GetExecutingAssembly.EntryPoint.DeclaringType Is Me.GetType Then
        '  m_vb6FormDefInstance = Me
        '  End If
        '      Catch
        '  End Try
        '  End If
        '  End If
        'Chiamata richiesta dalla progettazione Windows Form.
        InitializeComponent()
        'Inizializza()
    End Sub
    'Il form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
    Protected Overloads Overrides Sub Dispose(ByVal Disposing As Boolean)
        If Disposing Then
            If Not components Is Nothing Then
                components.Dispose()
            End If
            UpDown1.RemoveAll()
        End If
        MyBase.Dispose(Disposing)
    End Sub
    'Richiesto dalla progettazione Windows Form
    Private components As System.ComponentModel.IContainer
    Public ToolTip1 As System.Windows.Forms.ToolTip
    Public WithEvents cmddelNot As System.Windows.Forms.Button
    Public WithEvents txtNote As System.Windows.Forms.TextBox
    Public WithEvents chkComp As System.Windows.Forms.CheckBox
    Public WithEvents cmdGo As System.Windows.Forms.Button
    Public WithEvents cmbMatExc As System.Windows.Forms.ComboBox
    Public WithEvents cmdExcel As System.Windows.Forms.Button
    Public WithEvents _cmdNew_0 As System.Windows.Forms.Button
    Public WithEvents _cmdCut_0 As System.Windows.Forms.Button
    Public WithEvents _cmdMemo_0 As System.Windows.Forms.Button
    Public WithEvents _Combo1_0 As System.Windows.Forms.ComboBox
    Public WithEvents cmdUnit As System.Windows.Forms.Button
    Public WithEvents _ttFirma_0 As System.Windows.Forms.TextBox
    Public WithEvents _ttPrezzo2_0 As System.Windows.Forms.TextBox
    Public WithEvents _ttForn_0 As System.Windows.Forms.TextBox
    Public WithEvents _ttData_0 As System.Windows.Forms.TextBox
    Public WithEvents Command1 As System.Windows.Forms.Button
    Public WithEvents _ttPrezzo_0 As System.Windows.Forms.TextBox
    Public WithEvents _lblScorri_0 As System.Windows.Forms.Label
    Public WithEvents Label6 As System.Windows.Forms.Label
    Public WithEvents lblPrezzo2 As System.Windows.Forms.Label
    Public WithEvents lblPrezzo As System.Windows.Forms.Label
    Public WithEvents Label5 As System.Windows.Forms.Label
    Public WithEvents _lblUniMis2_0 As System.Windows.Forms.Label
    Public WithEvents Label4 As System.Windows.Forms.Label
    Public WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents _lblUniMis_0 As System.Windows.Forms.Label
    Public WithEvents _lblParam_0 As System.Windows.Forms.Label
    'NOTA: la routine seguente è richiesta dalla progettazione Windows Form.
    'Può essere modificata utilizzando la finestra di progettazione Windows Form.
    'Non modificarla mediante l'editor di codice.
    Public WithEvents cmdSavNot As System.Windows.Forms.Button
    Friend WithEvents _UpDown_0 As System.Windows.Forms.NumericUpDown
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmprz))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me._cmdNew_0 = New System.Windows.Forms.Button
        Me._cmdCut_0 = New System.Windows.Forms.Button
        Me._cmdMemo_0 = New System.Windows.Forms.Button
        Me._lblScorri_0 = New System.Windows.Forms.Label
        Me.cmddelNot = New System.Windows.Forms.Button
        Me.cmdSavNot = New System.Windows.Forms.Button
        Me.txtNote = New System.Windows.Forms.TextBox
        Me.chkComp = New System.Windows.Forms.CheckBox
        Me.cmdGo = New System.Windows.Forms.Button
        Me.cmbMatExc = New System.Windows.Forms.ComboBox
        Me.cmdExcel = New System.Windows.Forms.Button
        Me._Combo1_0 = New System.Windows.Forms.ComboBox
        Me.cmdUnit = New System.Windows.Forms.Button
        Me._ttFirma_0 = New System.Windows.Forms.TextBox
        Me._ttPrezzo2_0 = New System.Windows.Forms.TextBox
        Me._ttForn_0 = New System.Windows.Forms.TextBox
        Me._ttData_0 = New System.Windows.Forms.TextBox
        Me.Command1 = New System.Windows.Forms.Button
        Me._ttPrezzo_0 = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.lblPrezzo2 = New System.Windows.Forms.Label
        Me.lblPrezzo = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me._lblUniMis2_0 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me._lblUniMis_0 = New System.Windows.Forms.Label
        Me._lblParam_0 = New System.Windows.Forms.Label
        Me._UpDown_0 = New System.Windows.Forms.NumericUpDown
        CType(Me._UpDown_0, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        '_cmdNew_0
        '
        Me._cmdNew_0.BackColor = System.Drawing.SystemColors.Control
        Me._cmdNew_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdNew_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdNew_0.Image = CType(resources.GetObject("_cmdNew_0.Image"), System.Drawing.Image)
        Me._cmdNew_0.Location = New System.Drawing.Point(648, 64)
        Me._cmdNew_0.Name = "_cmdNew_0"
        Me._cmdNew_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdNew_0.Size = New System.Drawing.Size(20, 20)
        Me._cmdNew_0.TabIndex = 21
        Me._cmdNew_0.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me._cmdNew_0, "Crea un nuovo record")
        Me._cmdNew_0.UseVisualStyleBackColor = False
        '
        '_cmdCut_0
        '
        Me._cmdCut_0.BackColor = System.Drawing.SystemColors.Control
        Me._cmdCut_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdCut_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdCut_0.Image = CType(resources.GetObject("_cmdCut_0.Image"), System.Drawing.Image)
        Me._cmdCut_0.Location = New System.Drawing.Point(624, 64)
        Me._cmdCut_0.Name = "_cmdCut_0"
        Me._cmdCut_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdCut_0.Size = New System.Drawing.Size(20, 20)
        Me._cmdCut_0.TabIndex = 20
        Me._cmdCut_0.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me._cmdCut_0, "Elimina il record corrente")
        Me._cmdCut_0.UseVisualStyleBackColor = False
        '
        '_cmdMemo_0
        '
        Me._cmdMemo_0.BackColor = System.Drawing.SystemColors.Control
        Me._cmdMemo_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdMemo_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdMemo_0.Image = CType(resources.GetObject("_cmdMemo_0.Image"), System.Drawing.Image)
        Me._cmdMemo_0.Location = New System.Drawing.Point(600, 64)
        Me._cmdMemo_0.Name = "_cmdMemo_0"
        Me._cmdMemo_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdMemo_0.Size = New System.Drawing.Size(20, 20)
        Me._cmdMemo_0.TabIndex = 19
        Me._cmdMemo_0.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me._cmdMemo_0, "Visualizza le note")
        Me._cmdMemo_0.UseVisualStyleBackColor = False
        '
        '_lblScorri_0
        '
        Me._lblScorri_0.BackColor = System.Drawing.SystemColors.Control
        Me._lblScorri_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblScorri_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblScorri_0.Location = New System.Drawing.Point(704, 64)
        Me._lblScorri_0.Name = "_lblScorri_0"
        Me._lblScorri_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblScorri_0.Size = New System.Drawing.Size(49, 17)
        Me._lblScorri_0.TabIndex = 26
        Me._lblScorri_0.Text = "Label7"
        Me.ToolTip1.SetToolTip(Me._lblScorri_0, "Mostra il n° del record attivo")
        Me._lblScorri_0.Visible = False
        '
        'cmddelNot
        '
        Me.cmddelNot.BackColor = System.Drawing.SystemColors.Control
        Me.cmddelNot.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmddelNot.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmddelNot.Image = CType(resources.GetObject("cmddelNot.Image"), System.Drawing.Image)
        Me.cmddelNot.Location = New System.Drawing.Point(456, 8)
        Me.cmddelNot.Name = "cmddelNot"
        Me.cmddelNot.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmddelNot.Size = New System.Drawing.Size(17, 17)
        Me.cmddelNot.TabIndex = 29
        Me.cmddelNot.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.cmddelNot, "Elimina la visualizzazione delle note. Se si elimina la visualizzazione delle not" & _
                "e o si visualizza una nuova nota senza salvare, ogni modifica verrà persa.")
        Me.cmddelNot.UseVisualStyleBackColor = False
        Me.cmddelNot.Visible = False
        '
        'cmdSavNot
        '
        Me.cmdSavNot.BackColor = System.Drawing.SystemColors.Control
        Me.cmdSavNot.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdSavNot.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdSavNot.Image = CType(resources.GetObject("cmdSavNot.Image"), System.Drawing.Image)
        Me.cmdSavNot.Location = New System.Drawing.Point(432, 8)
        Me.cmdSavNot.Name = "cmdSavNot"
        Me.cmdSavNot.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdSavNot.Size = New System.Drawing.Size(17, 17)
        Me.cmdSavNot.TabIndex = 30
        Me.cmdSavNot.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.cmdSavNot, "Salva nel database le modifiche al testo della nota")
        Me.cmdSavNot.UseVisualStyleBackColor = False
        Me.cmdSavNot.Visible = False
        '
        'txtNote
        '
        Me.txtNote.AcceptsReturn = True
        Me.txtNote.BackColor = System.Drawing.SystemColors.Window
        Me.txtNote.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtNote.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtNote.Location = New System.Drawing.Point(0, 80)
        Me.txtNote.MaxLength = 0
        Me.txtNote.Multiline = True
        Me.txtNote.Name = "txtNote"
        Me.txtNote.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtNote.Size = New System.Drawing.Size(481, 73)
        Me.txtNote.TabIndex = 28
        Me.txtNote.Visible = False
        '
        'chkComp
        '
        Me.chkComp.BackColor = System.Drawing.SystemColors.Control
        Me.chkComp.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkComp.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkComp.Location = New System.Drawing.Point(216, 0)
        Me.chkComp.Name = "chkComp"
        Me.chkComp.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkComp.Size = New System.Drawing.Size(80, 25)
        Me.chkComp.TabIndex = 27
        Me.chkComp.Text = "Composito"
        Me.chkComp.UseVisualStyleBackColor = False
        Me.chkComp.Visible = False
        '
        'cmdGo
        '
        Me.cmdGo.BackColor = System.Drawing.SystemColors.Control
        Me.cmdGo.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdGo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdGo.Location = New System.Drawing.Point(672, 8)
        Me.cmdGo.Name = "cmdGo"
        Me.cmdGo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdGo.Size = New System.Drawing.Size(25, 17)
        Me.cmdGo.TabIndex = 25
        Me.cmdGo.Text = "Go"
        Me.cmdGo.UseVisualStyleBackColor = False
        Me.cmdGo.Visible = False
        '
        'cmbMatExc
        '
        Me.cmbMatExc.BackColor = System.Drawing.SystemColors.Window
        Me.cmbMatExc.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbMatExc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMatExc.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbMatExc.Location = New System.Drawing.Point(488, 8)
        Me.cmbMatExc.Name = "cmbMatExc"
        Me.cmbMatExc.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbMatExc.Size = New System.Drawing.Size(177, 21)
        Me.cmbMatExc.TabIndex = 24
        Me.cmbMatExc.Visible = False
        '
        'cmdExcel
        '
        Me.cmdExcel.BackColor = System.Drawing.SystemColors.Control
        Me.cmdExcel.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdExcel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdExcel.Location = New System.Drawing.Point(400, 8)
        Me.cmdExcel.Name = "cmdExcel"
        Me.cmdExcel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdExcel.Size = New System.Drawing.Size(80, 25)
        Me.cmdExcel.TabIndex = 23
        Me.cmdExcel.Text = "Aggiorna da Excel"
        Me.cmdExcel.UseVisualStyleBackColor = False
        Me.cmdExcel.Visible = False
        '
        '_Combo1_0
        '
        Me._Combo1_0.BackColor = System.Drawing.SystemColors.Window
        Me._Combo1_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Combo1_0.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me._Combo1_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Combo1_0.Location = New System.Drawing.Point(72, 64)
        Me._Combo1_0.Name = "_Combo1_0"
        Me._Combo1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Combo1_0.Size = New System.Drawing.Size(73, 21)
        Me._Combo1_0.TabIndex = 17
        Me._Combo1_0.Visible = False
        '
        'cmdUnit
        '
        Me.cmdUnit.BackColor = System.Drawing.SystemColors.Control
        Me.cmdUnit.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdUnit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdUnit.Location = New System.Drawing.Point(304, 8)
        Me.cmdUnit.Name = "cmdUnit"
        Me.cmdUnit.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdUnit.Size = New System.Drawing.Size(80, 25)
        Me.cmdUnit.TabIndex = 16
        Me.cmdUnit.Text = "Cambia unità"
        Me.cmdUnit.UseVisualStyleBackColor = False
        '
        '_ttFirma_0
        '
        Me._ttFirma_0.AcceptsReturn = True
        Me._ttFirma_0.BackColor = System.Drawing.SystemColors.Window
        Me._ttFirma_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._ttFirma_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._ttFirma_0.Location = New System.Drawing.Point(560, 64)
        Me._ttFirma_0.MaxLength = 0
        Me._ttFirma_0.Name = "_ttFirma_0"
        Me._ttFirma_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._ttFirma_0.Size = New System.Drawing.Size(33, 20)
        Me._ttFirma_0.TabIndex = 12
        Me._ttFirma_0.Text = "Text1"
        '
        '_ttPrezzo2_0
        '
        Me._ttPrezzo2_0.AcceptsReturn = True
        Me._ttPrezzo2_0.BackColor = System.Drawing.SystemColors.Window
        Me._ttPrezzo2_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._ttPrezzo2_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._ttPrezzo2_0.Location = New System.Drawing.Point(264, 64)
        Me._ttPrezzo2_0.MaxLength = 0
        Me._ttPrezzo2_0.Name = "_ttPrezzo2_0"
        Me._ttPrezzo2_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._ttPrezzo2_0.Size = New System.Drawing.Size(65, 20)
        Me._ttPrezzo2_0.TabIndex = 10
        Me._ttPrezzo2_0.Text = "Text1"
        '
        '_ttForn_0
        '
        Me._ttForn_0.AcceptsReturn = True
        Me._ttForn_0.BackColor = System.Drawing.SystemColors.Window
        Me._ttForn_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._ttForn_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._ttForn_0.Location = New System.Drawing.Point(464, 64)
        Me._ttForn_0.MaxLength = 0
        Me._ttForn_0.Name = "_ttForn_0"
        Me._ttForn_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._ttForn_0.Size = New System.Drawing.Size(89, 20)
        Me._ttForn_0.TabIndex = 9
        Me._ttForn_0.Text = "Text1"
        '
        '_ttData_0
        '
        Me._ttData_0.AcceptsReturn = True
        Me._ttData_0.BackColor = System.Drawing.SystemColors.Window
        Me._ttData_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._ttData_0.Enabled = False
        Me._ttData_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._ttData_0.Location = New System.Drawing.Point(384, 64)
        Me._ttData_0.MaxLength = 0
        Me._ttData_0.Name = "_ttData_0"
        Me._ttData_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._ttData_0.Size = New System.Drawing.Size(73, 20)
        Me._ttData_0.TabIndex = 6
        Me._ttData_0.Text = "Text1"
        '
        'Command1
        '
        Me.Command1.BackColor = System.Drawing.SystemColors.Control
        Me.Command1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command1.Location = New System.Drawing.Point(656, 40)
        Me.Command1.Name = "Command1"
        Me.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command1.Size = New System.Drawing.Size(45, 20)
        Me.Command1.TabIndex = 4
        Me.Command1.Text = "OK"
        Me.Command1.UseVisualStyleBackColor = False
        '
        '_ttPrezzo_0
        '
        Me._ttPrezzo_0.AcceptsReturn = True
        Me._ttPrezzo_0.BackColor = System.Drawing.SystemColors.Window
        Me._ttPrezzo_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._ttPrezzo_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._ttPrezzo_0.Location = New System.Drawing.Point(152, 64)
        Me._ttPrezzo_0.MaxLength = 0
        Me._ttPrezzo_0.Name = "_ttPrezzo_0"
        Me._ttPrezzo_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._ttPrezzo_0.Size = New System.Drawing.Size(69, 20)
        Me._ttPrezzo_0.TabIndex = 1
        Me._ttPrezzo_0.Text = "Text1"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.Control
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(72, 48)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(73, 17)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "Label6"
        Me.Label6.Visible = False
        '
        'lblPrezzo2
        '
        Me.lblPrezzo2.BackColor = System.Drawing.SystemColors.Control
        Me.lblPrezzo2.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblPrezzo2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblPrezzo2.Location = New System.Drawing.Point(264, 40)
        Me.lblPrezzo2.Name = "lblPrezzo2"
        Me.lblPrezzo2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblPrezzo2.Size = New System.Drawing.Size(89, 25)
        Me.lblPrezzo2.TabIndex = 15
        Me.lblPrezzo2.Text = "Label6"
        '
        'lblPrezzo
        '
        Me.lblPrezzo.BackColor = System.Drawing.SystemColors.Control
        Me.lblPrezzo.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblPrezzo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblPrezzo.Location = New System.Drawing.Point(152, 40)
        Me.lblPrezzo.Name = "lblPrezzo"
        Me.lblPrezzo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblPrezzo.Size = New System.Drawing.Size(89, 25)
        Me.lblPrezzo.TabIndex = 14
        Me.lblPrezzo.Text = "Prezzo su peso lordo"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(568, 40)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(25, 17)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "F.to"
        '
        '_lblUniMis2_0
        '
        Me._lblUniMis2_0.BackColor = System.Drawing.SystemColors.Control
        Me._lblUniMis2_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblUniMis2_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblUniMis2_0.Location = New System.Drawing.Point(336, 64)
        Me._lblUniMis2_0.Name = "_lblUniMis2_0"
        Me._lblUniMis2_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblUniMis2_0.Size = New System.Drawing.Size(41, 20)
        Me._lblUniMis2_0.TabIndex = 11
        Me._lblUniMis2_0.Text = "Label5"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(480, 40)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(57, 17)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Fornitore"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(376, 40)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(96, 17)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Data inserimento"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Yellow
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(0, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(211, 20)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Label2"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Yellow
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(0, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(211, 20)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Label1"
        '
        '_lblUniMis_0
        '
        Me._lblUniMis_0.BackColor = System.Drawing.SystemColors.Control
        Me._lblUniMis_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblUniMis_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblUniMis_0.Location = New System.Drawing.Point(224, 64)
        Me._lblUniMis_0.Name = "_lblUniMis_0"
        Me._lblUniMis_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblUniMis_0.Size = New System.Drawing.Size(34, 20)
        Me._lblUniMis_0.TabIndex = 2
        Me._lblUniMis_0.Text = " €/kg"
        '
        '_lblParam_0
        '
        Me._lblParam_0.BackColor = System.Drawing.SystemColors.Control
        Me._lblParam_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblParam_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblParam_0.Location = New System.Drawing.Point(6, 64)
        Me._lblParam_0.Name = "_lblParam_0"
        Me._lblParam_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblParam_0.Size = New System.Drawing.Size(141, 20)
        Me._lblParam_0.TabIndex = 0
        Me._lblParam_0.Text = "Label1"
        '
        '_UpDown_0
        '
        Me._UpDown_0.Location = New System.Drawing.Point(672, 64)
        Me._UpDown_0.Name = "_UpDown_0"
        Me._UpDown_0.Size = New System.Drawing.Size(22, 20)
        Me._UpDown_0.TabIndex = 31
        '
        'frmprz
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightPink
        Me.ClientSize = New System.Drawing.Size(773, 173)
        Me.ControlBox = False
        Me.Controls.Add(Me._UpDown_0)
        Me.Controls.Add(Me.cmdSavNot)
        Me.Controls.Add(Me.cmddelNot)
        Me.Controls.Add(Me.txtNote)
        Me.Controls.Add(Me._ttFirma_0)
        Me.Controls.Add(Me._ttPrezzo2_0)
        Me.Controls.Add(Me._ttForn_0)
        Me.Controls.Add(Me._ttData_0)
        Me.Controls.Add(Me._ttPrezzo_0)
        Me.Controls.Add(Me.chkComp)
        Me.Controls.Add(Me.cmdGo)
        Me.Controls.Add(Me.cmbMatExc)
        Me.Controls.Add(Me.cmdExcel)
        Me.Controls.Add(Me._cmdNew_0)
        Me.Controls.Add(Me._cmdCut_0)
        Me.Controls.Add(Me._cmdMemo_0)
        Me.Controls.Add(Me._Combo1_0)
        Me.Controls.Add(Me.cmdUnit)
        Me.Controls.Add(Me.Command1)
        Me.Controls.Add(Me._lblScorri_0)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.lblPrezzo2)
        Me.Controls.Add(Me.lblPrezzo)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me._lblUniMis2_0)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me._lblUniMis_0)
        Me.Controls.Add(Me._lblParam_0)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Location = New System.Drawing.Point(206, 211)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmprz"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Tabelle prezzi unitari"
        CType(Me._UpDown_0, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region
    '0 mostra tutte le unità
    '1 mostra L/Kg lordo
    '2 mostra unità alternativa
    Public Unit As Short
    Public PushOK As Boolean
    Public linum As Short
    Public linum2 As Short
    Private BackColore As Color
    Private m As LibMat.MaterialeNew1
    Private cmdT(30) As OleDbDataAdapter
    Private custCBT(30) As OleDbCommandBuilder
    Friend lblParam As RoutBase4.LabelArray
    Friend lblScorri As RoutBase4.LabelArray
    Friend lblUniMis As RoutBase4.LabelArray
    Friend lblUniMis2 As RoutBase4.LabelArray
    Friend cmdCut As RoutBase4.ButtonArray
    Friend cmdMemo As RoutBase4.ButtonArray
    Friend Combo1 As RoutBase4.ComboArray
    Friend cmdNew As RoutBase4.ButtonArray
    Friend ttPrezzo As RoutBase4.TextArray
    Friend ttData As RoutBase4.TextArray
    Friend ttFirma As RoutBase4.TextArray
    Friend ttForn As RoutBase4.TextArray
    Friend ttPrezzo2 As RoutBase4.TextArray
    Friend UpDown1 As RoutBase4.UpDownArray
    Private Sub chkComp_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkComp.CheckStateChanged
        Riempi()
    End Sub
    Public Sub Text_Enter(ByVal Nome As String)
        Dim s() As String = Nome.Split(CChar("_"))
        Dim Textnum As String = s(1)
        Dim Index As Short = CShort(s(2))
        Select Case Textnum
            Case "ttForn"
                iprezzi = Index + 1
            Case "ttFirma"
                iprezzi = Index + 1
            Case "ttData"
                iprezzi = Index + 1
            Case "ttPreszzo2"
                iprezzi = Index + 1
            Case "ttPreszzo"
                iprezzi = Index + 1
        End Select
    End Sub
    Private Sub cmbMatExc_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbMatExc.SelectedIndexChanged
        cmdGo.Visible = True
    End Sub
    Public Sub Button_Click(ByVal Nome As String)
        Dim s() As String = Nome.Split(CChar("_"))
        Dim Textnum As String = s(1)
        Dim Index As Short = CShort(s(2))
        Select Case Textnum
            Case "cmdCut"
                Try
                    iprezzi = Index + 1
                    Dim testo As String
                    If txtNote.Visible Then
                        testo = "Operazione non consentita poiché la visualizzazione" & vbCrLf
                        testo = testo & "delle note è attiva. Se si vuole procedere bisogna " & vbCrLf
                        testo = testo & "prima eliminare il riquadro di visualizzazione delle" & vbCrLf
                        testo = testo & "note."
                        MsgBox(testo, CType(MsgBoxStyle.Information + MsgBoxStyle.OkOnly, MsgBoxStyle))
                    End If
                    testo = "Sei sicuro di voler eliminare permanentemente questa registrazione?"
                    If MsgBox(testo, CType(MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.DefaultButton2, MsgBoxStyle), "Prezzi materiali") = MsgBoxResult.No Then Exit Sub
                    iflpd(Index + 1).Delete()
                    cmdT(Index + 1).Update(iflpt(Index + 1))
                    'iflpt(Index + 1).AcceptChanges()
                    If iflp(Index + 1).Count < 2 Then
                        cmdCut(Index).Visible = False
                        UpDown1(Index).Visible = False
                    End If
                    iflpd(Index + 1) = iflp(Index + 1)(0)
                    Aggiornatesto(Index)
                    AggScorri(Index)
                    AggTxt(Index)
                Catch e As Exception
                    MessageBox.Show(e.Message + vbCrLf + e.StackTrace)
                End Try
            Case "cmdNew"
                iprezzi = Index + 1
                AggiungiNuovo(CShort(Index + 1))
                cmdCut(Index).Visible = True
                UpDown1(Index).Visible = True
                AggScorri(Index)
                AggTxt(Index)
            Case "cmdMemo"
                iprezzi = Index + 1
                With txtNote
                    .Visible = True
                    .Left = lblParam(Index).Left
                    .Top = lblParam(Index).Top + lblParam(Index).Height
                    .Tag = Str(Index)
                    If .Top + .Height > ClientRectangle.Height Then .Top = .Top - .Height - lblParam(Index).Height
                    Aggiornatesto(Index)
                    .BringToFront()
                    cmddelNot.Top = CInt(.Top + 4 * SystemInformation.Border3DSize.Height)
                    cmddelNot.Left = CInt(.Left + .Width + 2 * SystemInformation.Border3DSize.Width)
                    cmddelNot.Visible = True
                    cmddelNot.BringToFront()
                    cmdSavNot.Top = CInt(.Top + 8 * SystemInformation.Border3DSize.Height + cmddelNot.Height)
                    cmdSavNot.Left = CInt(.Left + .Width + 2 * SystemInformation.Border3DSize.Width)
                    cmdSavNot.Visible = True
                    cmdSavNot.BringToFront()
                End With
        End Select
    End Sub
    Private Sub cmddelNot_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmddelNot.Click
        iprezzi = CShort(Val(txtNote.Tag))
        AggiornaNote()
        txtNote.Visible = False
        cmddelNot.Visible = False
        cmdSavNot.Visible = False
    End Sub
    Private Sub cmdExcel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdExcel.Click
        Dim Mat As clsMat
        ApriPrezzi() 'wPrezzi, connPrezzi
        Mat = FormMat.Item(FormMat.Count()).TextData
        FormPrezzi = New frmprz
        FormPrezzi.Inizializza()
        Select Case Mat.MatSolo.Classe
            Case ClasseMateriale.LamiereCS, ClasseMateriale.LamiereSS : AggiornaXLS("PLATES") ' Aggiornaplates() 'connPrezzi'Doc
            Case ClasseMateriale.TubiScambio : AggiornaXLS("TUBES") ' Aggiornatubes()
            Case ClasseMateriale.Fucinati
                Flange = MsgBox("Flange standard?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes
                If Flange Then
                    AggiornaXLS("FLAN") 'AggiornaFlan()
                Else
                    Elbows = MsgBox("Elbows?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes
                    '     If Elbows Then AggiornaElbw() Else AggiornaForg()
                    If Elbows Then AggiornaXLS("ELBW") Else AggiornaXLS("FORG")
                End If
            Case ClasseMateriale.FormaturaFondiEllittici : AggiornaXLS("ELLHEADS") 'AggiornaEllHeads()
                cmdGo.Visible = True
            Case ClasseMateriale.FormaturaFondiEmisferici : AggiornaXLS("HEMHEADS") 'AggiornaHemHeads()
                cmdGo.Visible = True
            Case ClasseMateriale.Calandratura : AggiornaXLS("CALANDR") 'AggiornaCalandr()
                cmdGo.Visible = True
        End Select
        FormPrezzi.Close()
        FormPrezzi.Dispose()
    End Sub
    Private Sub cmdGo_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdGo.Click
        Dim Mat As clsMat
        Mat = FormMat.Item(FormMat.Count()).TextData
        Select Case Mat.MatSolo.Classe
            Case ClasseMateriale.LamiereCS, ClasseMateriale.LamiereSS : GoPlates() 'connPrezzi'Doc
            Case ClasseMateriale.TubiScambio : GoTubes()
            Case ClasseMateriale.Fucinati
                If Flange Then
                    GoFlan()
                ElseIf Elbows Then
                    GoElbw()
                Else
                    GoForg()
                End If
            Case ClasseMateriale.FormaturaFondiEllittici : GoEll()
            Case ClasseMateriale.FormaturaFondiEmisferici : GoHem()
            Case ClasseMateriale.Calandratura : GoCal()
        End Select
    End Sub
    Private Sub cmdUnit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdUnit.Click
        If Unit = 1 Then Unit = 2 Else Unit = 1
        Prezzo12()
    End Sub
    Public Sub Combo_SelectedIndexChanged(ByVal Nome As String)
        Dim s() As String = Nome.Split(CChar("_"))
        Dim Textnum As String = s(1)
        Dim Index As Short = CShort(s(2))
        iprezzi = Index + 1
        Aggiorna(CShort(Index + 1))
    End Sub
    Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
        Dim m As LibMat.MaterialeNew1
        Dim i As Short
        Try
            m = MatElem()
            If m Is Nothing Then Exit Sub
            For i = 1 To NumParam
                AggDB(CShort(i - 1))
                cmdT(i).Update(iflpt(i))
            Next
        Catch e As Exception
            MessageBox.Show(e.Message + vbCrLf + e.StackTrace)
        End Try
        PushOK = True
        Hide()
    End Sub
    Public Sub Inizializza()
        UpDown1 = New RoutBase4.UpDownArray(Me, Me, "_UpDown")
        lblParam = New RoutBase4.LabelArray(Me, Me, "_lblParam")
        lblScorri = New RoutBase4.LabelArray(Me, Me, "_lblScorri")
        lblUniMis = New RoutBase4.LabelArray(Me, Me, "_lblUniMis")
        lblUniMis2 = New RoutBase4.LabelArray(Me, Me, "_lblUniMis2")
        Combo1 = New RoutBase4.ComboArray(Me, Me, "_Combo1")
        cmdCut = New RoutBase4.ButtonArray(Me, Me, "_cmdCut")
        cmdMemo = New RoutBase4.ButtonArray(Me, Me, "_cmdMemo")
        cmdNew = New RoutBase4.ButtonArray(Me, Me, "_cmdNew")
        ttPrezzo = New RoutBase4.TextArray(Me, Me, "_ttPrezzo")
        ttData = New RoutBase4.TextArray(Me, Me, "_ttData")
        ttFirma = New RoutBase4.TextArray(Me, Me, "_ttFirma")
        ttForn = New RoutBase4.TextArray(Me, Me, "_ttForn")
        ttPrezzo2 = New RoutBase4.TextArray(Me, Me, "_ttPrezzo2")
        BackColore = ttPrezzo(0).BackColor
        m = MatElem()
        If m Is Nothing Then Exit Sub
        IniziaBase()
        If m.Classe = 0 Then m.RecupMat(Archdir)
        If m.Indmat = 0 And m.Classe < 11 Then
            Me.Close()
            Exit Sub
        End If
        Select Case m.Classe
            Case ClasseMateriale.LamiereCS, ClasseMateriale.Fucinati : chkComp.Visible = True
        End Select
        ParametriPrezzo(m.Classe)
        If m.Classe < 11 Then
            Label2.Text = frmMater.DefInstance.Option3D1(CShort(m.Classe - 1)).Text
            Label1.Text = m.MatStr
        Else
            Label2.Text = frmMater.DefInstance.optLE(CShort(m.Classe - 11)).Text
            Label1.Text = ""
        End If
        Riempi()
    End Sub
    Private Sub frmprz_Closed(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Closed
        tbClassi.Dispose()
        tableparam.Dispose()
        If Not TableParamSc Is Nothing Then TableParamSc.Dispose()
    End Sub
    Private Sub Prezzo12()
        Dim i As Short
        For i = 1 To NumParam
            Select Case Unit
                Case 1
                    If ttPrezzo2.Count > i - 1 Then
                        ttPrezzo2(CShort(i - 1)).BackColor = System.Drawing.Color.Lime
                        ttPrezzo2(CShort(i - 1)).Enabled = False
                    End If
                    If ttPrezzo.Count > i - 1 Then
                        ttPrezzo(CShort(i - 1)).BackColor = BackColore
                        ttPrezzo(CShort(i - 1)).Enabled = True
                    End If
                Case 2
                    If ttPrezzo.Count > i - 1 Then
                        ttPrezzo(CShort(i - 1)).BackColor = System.Drawing.Color.Lime
                        ttPrezzo(CShort(i - 1)).Enabled = False
                    End If
                    If ttPrezzo2.Count > i - 1 Then
                        ttPrezzo2(CShort(i - 1)).BackColor = BackColore
                        ttPrezzo2(CShort(i - 1)).Enabled = True
                    End If
            End Select
        Next
    End Sub

    Private Sub Aggiorna(ByRef ii As Short)
        Dim t As DataTable
        Dim tt As DataView
        Static Filtrato(40) As Boolean
        Dim i0, i1 As Short
        Dim i, j, ij As Short
        Dim P2 As String
        i0 = 1 : i1 = NumParam
        If ii > 0 Then
            i0 = ii
            i1 = ii
        End If
        Try
            For i = i0 To i1
                iprezzi = i
                If Filtrato(i) Then
                    t = New DataTable
                    cmdT(i).Fill(t)
                    tt = New DataView(t)
                Else
                    tt = iflp(i)
                    t = iflpt(i)
                End If
                Filtrato(i) = False
                If m.Classe = ClasseMateriale.Fucinati Then
                    tt.RowFilter = "Codice = " & Codici(i).ToString
                    Filtrato(i) = True
                End If
                If NumParamSc > 0 Then
                    P2 = Funzioni.ConvertiVirgola(Combo1(CShort(i - 1)).Text)
                    Dim Filtro As String = "(Parametro2-" & P2 & ")/" & P2 & "<0.05 AND " + _
                                           "(Parametro2-" & P2 & ")/" & P2 & ">-0.05"
                    If tt.RowFilter.Length > 0 Then
                        tt.RowFilter = tt.RowFilter & " AND " & Filtro
                    Else
                        tt.RowFilter = Filtro
                    End If
                    Filtrato(i) = True
                End If
                iflp(i) = tt
                iflpt(i) = t
                If tt.Count = 0 Then
                    AggiungiNuovo(i)
                ElseIf tt.Count > 1 Then
                    Dim Filtro As String = "Prezzolkg>0"
                    Dim OldFiltro As String = tt.RowFilter
                    If OldFiltro.Length > 0 Then
                        tt.RowFilter = OldFiltro & " AND " & Filtro
                    Else
                        tt.RowFilter = Filtro
                    End If
                    If tt.Count > 0 Then
                        tt.RowFilter = OldFiltro
                        tt.Sort = "prezzolkg"
                        Dim Righe() As DataRowView = tt.FindRows(0)
                        For ij = CShort(UBound(Righe)) To 0 Step -1
                            Righe(ij).Delete()
                        Next ij
                    End If
                End If
                cmdT(i).Update(iflpt(i))
                'iflpt(i).AcceptChanges()
            Next
            If ii = 0 Or ii = 1 Then
                iprezzi = 1
                AggTxt(0)
                cmdCut(0).Visible = iflp(1).Count > 1
                UpDown1(0).Visible = iflp(1).Count > 1
                lblScorri(0).Visible = iflp(1).Count > 1
                j = CShort(iflp(1).Count)
                iflpd(iprezzi) = iflp(iprezzi)(j - 1)
                lblScorri(0).Text = j.ToString & "/" & j.ToString
                ' BindingContext(iflp(iprezzi)).Position = j - 1
            Else
                iprezzi = ii
                Dim ik As Short = CShort(ii - 1)
                ttPrezzo.Load(ik) : lblUniMis.Load(ik)
                lblUniMis(ik).Text = lblUniMis(0).Text
                ttData.Load(ik)
                ttForn.Load(ik)
                'ttForn(ik).DataBindings.Add(New Binding("Text", iflp(ik + 1), "Fornitore"))
                ttFirma.Load(ik)
                ttPrezzo2.Load(ik) : ttPrezzo2(ik).Visible = False
                AggTxt(ik)
                cmdCut.Load(ik)
                cmdCut(ik).Visible = iflp(ii).Count > 1
                UpDown1.Load(ik)
                UpDown1(ik).Visible = iflp(ii).Count > 1
                lblScorri.Load(ik)
                lblScorri(ik).Visible = iflp(ii).Count > 1
                j = CShort(iflp(ii).Count)
                iflpd(iprezzi) = iflp(iprezzi)(j - 1)
                lblScorri(ik).Text = j.ToString & "/" & j.ToString
                ' BindingContext(iflp(ii)).Position = j - 1
            End If
            i0 = 2 : i1 = NumParam
            If ii > 0 Then
                i0 = ii : i1 = ii
            End If
            For i = i0 To i1
                iprezzi = i
                ' sbagliato: si presuppone che siano in fila e uno per ogni valore del parametro
                Dim ik As Short = CShort(i - 1)
                ttPrezzo.Load(ik) : lblUniMis.Load(ik)
                lblUniMis(ik).Text = lblUniMis(0).Text
                If i = linum Then
                    ttPrezzo(ik).BackColor = Color.Yellow
                    lblUniMis(ik).BackColor = Color.Yellow
                End If
                If i > 1 Then ttPrezzo(ik).Top = ttPrezzo(CShort(i - 2)).Top + ttPrezzo(CShort(i - 2)).Height
                If i > 1 Then lblUniMis(ik).Top = lblUniMis(CShort(i - 2)).Top + lblUniMis(CShort(i - 2)).Height
                If i > 1 Then ttPrezzo(ik).Visible = True : lblUniMis(ik).Visible = True
                If Not CStr(tbClassi.Rows(0)("unitAlt")) = "-" Then
                    ttPrezzo2.Load(ik)
                    If i > 1 Then ttPrezzo2(ik).Top = ttPrezzo2(CShort(i - 2)).Top + ttPrezzo2(CShort(i - 2)).Height
                    lblUniMis2.Load(ik)
                    If i > 1 Then lblUniMis2(ik).Top = lblUniMis2(CShort(i - 2)).Top + lblUniMis2(CShort(i - 2)).Height
                    lblUniMis2(ik).Text = lblUniMis2(0).Text
                    If i > 1 Then ttPrezzo2(ik).Visible = True : lblUniMis2(ik).Visible = True
                    If i = linum Then
                        ttPrezzo2(ik).BackColor = Color.Yellow
                        lblUniMis2(ik).BackColor = Color.Yellow
                    End If
                End If
                ttData.Load(ik)
                If i > 1 Then ttData(ik).Top = ttData(CShort(i - 2)).Top + ttData(CShort(i - 2)).Height
                ttData(ik).Visible = True
                ttForn.Load(ik)
                'ttForn(ik).DataBindings.Add(New Binding("Text", iflp(ik + 1), "Fornitore"))
                If i > 1 Then ttForn(ik).Top = ttForn(CShort(i - 2)).Top + ttForn(CShort(i - 2)).Height
                ttForn(ik).Visible = True
                ttFirma.Load(ik)
                If i > 1 Then ttFirma(ik).Top = ttFirma(CShort(i - 2)).Top + ttFirma(CShort(i - 2)).Height
                ttFirma(ik).Visible = True
                If i = linum Then
                    ttData(ik).BackColor = Color.Yellow
                    ttForn(ik).BackColor = Color.Yellow
                    ttFirma(ik).BackColor = Color.Yellow
                End If
                AggTxt(ik)
                cmdMemo.Load(ik)
                If i > 1 Then cmdMemo(ik).Top = ttFirma(ik).Top
                cmdMemo(ik).Visible = True
                cmdNew.Load(ik)
                If i > 1 Then cmdNew(ik).Top = ttFirma(ik).Top
                cmdNew(ik).Visible = True
                cmdCut.Load(ik)
                If i > 1 Then cmdCut(ik).Top = ttFirma(ik).Top
                cmdCut(ik).Visible = iflp(i).Count > 1
                UpDown1.Load(ik)
                If i > 1 Then UpDown1(ik).Top = ttFirma(ik).Top
                UpDown1(ik).Visible = iflp(i).Count > 1
                lblScorri.Load(ik)
                If i > 1 Then lblScorri(ik).Top = ttFirma(ik).Top
                lblScorri(ik).Visible = iflp(i).Count > 1
                j = CShort(iflp(i).Count)
                If j > 0 Then
                    iflpd(iprezzi) = iflp(iprezzi)(j - 1)
                    lblScorri(ik).Text = j.ToString & "/" & j.ToString
                    ' BindingContext(iflp(ik)).Position = j - 1
                Else
                    Stop
                End If
            Next
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
        Prezzo12()
        cmdUnit.Visible = (m.Classe = ClasseMateriale.TubiScambio And Unit > 0)
    End Sub
    Private Sub RiempiCombo(ByRef c As System.Windows.Forms.ComboBox, ByVal Index As Short, ByRef T As DataTable)
        Dim i As Short
        c.Items.Clear()
        Dim dvT As New DataView(T)
        For i = 0 To CShort(dvT.Count - 1)
            c.Items.Add(dvT(i)("Numero"))
        Next i
        For i = 0 To CShort(c.Items.Count - 1)
            c.SelectedIndex = i
            If Funzioni.ValVir(ttPrezzo(Index).Text) > 0 Then Exit Sub
        Next
        If i = c.Items.Count Then c.SelectedIndex = 0
    End Sub

    Friend Sub AggTxt(ByRef i As Short)
        Try
            If IsDBNull(iflpd(i + 1)("prezzolkg")) Then
                ttPrezzo(i).Text = ""
            Else
                ttPrezzo(i).Text = Format(CSng(iflpd(i + 1)("prezzolkg")), "####.000") 'Str$(prezzo.prezzo(1))
            End If
            ttData(i).Text = Format(iflpd(i + 1)("Datarev"), "dd/MM/yy")
            If IsDBNull(iflpd(i + 1)("Fornitore")) Then
                ttForn(i).Text = ""
            Else
                ttForn(i).Text = CStr(iflpd(i + 1)("Fornitore"))
            End If
            If IsDBNull(iflpd(i + 1)("Firmato")) Then
                ttFirma(i).Text = ""
            Else
                ttFirma(i).Text = CStr(iflpd(i + 1)("Firmato"))
            End If
            If Not CStr(tbClassi.Rows(0)("unitAlt")) = "-" Then
                If IsDBNull(iflpd(i + 1)("PrezzoAlt")) Then
                    ttPrezzo2(i).Text = "0"
                Else
                    ttPrezzo2(i).Text = Format(CSng(iflpd(i + 1)("PrezzoAlt")), "####.000")
                End If
            End If
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Private Sub AggiungiNuovo(ByRef i As Short)
        iflp(i).RowFilter = ""
        Dim drv As DataRowView = iflp(i).AddNew()
        Dim Sigla As String = ""
        RoutBase2.Motore2.Autorizzazione("MAT", Sigla, Monitor.Motore)
        drv("Parametro") = Paramv(i)
        If NumParamSc > 0 Then
            drv("Parametro2") = Funzioni.ValVir(Combo1(CShort(i - 1)).Text)
        End If
        Select Case m.Classe
            Case ClasseMateriale.LamiereCS To ClasseMateriale.Riporti
                drv("PrezzoLkg") = 1
                drv("PrezzoUni") = 0
            Case ClasseMateriale.FormaturaFondiEllittici To ClasseMateriale.Calandratura
                drv("PrezzoLkg") = 0
                drv("PrezzoUni") = 1
        End Select
        drv("IdMat") = m.Indmat
        drv("Datarev") = Now
        drv("Fornitore") = "ACME"
        drv("Firmato") = Sigla
        If m.Classe = ClasseMateriale.Fucinati Then drv("Codice") = Codici(i)
        Select Case m.Classe
            Case ClasseMateriale.LamiereCS
                If chkComp.CheckState = CheckState.Checked Then
                    drv("Tipo") = 1
                    drv("SpessRive") = 3
                    drv("NoteMie") = String.Format(Monitor.Motore.HelpStringaG(11053), m.MatStr.Trim, Paramv(i))
                Else
                    drv("Tipo") = 0
                    drv("NoteMie") = String.Format(Monitor.Motore.HelpStringaG(11052), m.MatStr.Trim, Paramv(i))
                End If
            Case ClasseMateriale.LamiereSS
                drv("NoteMie") = String.Format(Monitor.Motore.HelpStringaG(11054), m.MatStr.Trim, Paramv(i))
            Case ClasseMateriale.Tondi
                drv("NoteMie") = Monitor.Motore.HelpStringaG(11055)
            Case ClasseMateriale.TubiScambio
                drv("NoteMie") = String.Format(Monitor.Motore.HelpStringaG(11056), m.MatStr.Trim)
            Case ClasseMateriale.Distanziali
                drv("NoteMie") = Monitor.Motore.HelpStringaG(11057)
            Case ClasseMateriale.TubiPiping
                drv("NoteMie") = Monitor.Motore.HelpStringaG(11058)
            Case ClasseMateriale.Fucinati
                drv("NoteMie") = String.Format(Monitor.Motore.HelpStringaG(11059), m.MatStr.Trim)
            Case ClasseMateriale.Bulloneria
                drv("NoteMie") = Monitor.Motore.HelpStringaG(11060)
            Case ClasseMateriale.Riporti
                drv("NoteMie") = Monitor.Motore.HelpStringaG(11061)
            Case ClasseMateriale.FormaturaFondiEllittici
                drv("NoteMie") = Monitor.Motore.HelpStringaG(11062)
            Case ClasseMateriale.FormaturaFondiEmisferici
                drv("NoteMie") = Monitor.Motore.HelpStringaG(11063)
            Case ClasseMateriale.Calandratura
                drv("NoteMie") = Monitor.Motore.HelpStringaG(11064)
        End Select

        drv.EndEdit()
        iflpd(i) = drv
    End Sub
    Friend Sub AggDB(ByRef i As Short)
        Dim drv As DataRowView = iflpd(i + 1)
        Try
            drv.BeginEdit()
            drv("Fornitore") = ttForn(i).Text
            drv("Firmato") = ttFirma(i).Text
            If CSng(drv("prezzolkg")) <> Funzioni.ValVir(ttPrezzo(i).Text) Then
                drv("Datarev") = Now
                drv("prezzolkg") = Funzioni.ValVir(ttPrezzo(i).Text)
            End If
            drv.EndEdit()
            If Not CStr(tbClassi.Rows(0)("unitAlt")) = "-" Then
                drv.BeginEdit()
                drv("Firmato") = ttFirma(i).Text
                drv("Fornitore") = ttForn(i).Text
                If IsDBNull(drv("PrezzoAlt")) Then
                    drv("PrezzoAlt") = Funzioni.ValVir(ttPrezzo2(i).Text)
                    drv("Datarev") = Now
                ElseIf CSng(drv("PrezzoAlt")) <> Funzioni.ValVir(ttPrezzo2(i).Text) Then
                    drv("PrezzoAlt") = Funzioni.ValVir(ttPrezzo2(i).Text)
                    drv("Datarev") = Now
                End If
                drv.EndEdit()
            End If
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Friend Sub AggScorri(ByRef Index As Short)
        Dim n As Integer
        n = iflp(Index + 1).Count
        If n > 1 Then
            lblScorri(Index).Text = (NumeroRiga(iflpd(Index + 1), iflp(Index + 1)) + 1).ToString & "/" & n.ToString
            lblScorri(Index).Visible = True
        Else
            lblScorri(Index).Visible = False
        End If
    End Sub
    Public Sub Riempi()
        Dim T As DataTable
        Dim Criterio As String
        Dim i As Integer
        Dim Table1 As New DataTable
        Dim TableParam1 As New DataTable
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        Try
            If NumParam = 1 Then
                cmdT(1) = New OleDbDataAdapter("SELECT * FROM " + CStr(tbClassi.Rows(0)("tabClasPr")) + " WHERE IdMat = " + Str(m.Indmat) + " ORDER BY DataRev DESC", MatBase)
                custCBT(1) = New OleDbCommandBuilder(cmdT(1))
                T = New DataTable
                cmdT(1).Fill(T)
                Dim dvT As DataView = New DataView(T)
                iflp(1) = dvT
                iprezzi = 1
                If dvT.Count > 0 Then iflpd(1) = iflp(1)(0)
                iflpt(1) = T
                lblParam(0).Visible = False
                Labels()
            Else
                If m.Classe = ClasseMateriale.Fucinati Then
                    Dim cmdT1 As OleDbDataAdapter = New OleDbDataAdapter("SELECT * FROM Classi WHERE Codice = " & CInt(m.Classe), MatBase)
                    Table1 = New DataTable
                    cmdT1.Fill(Table1)
                    Dim cmdTP As OleDbDataAdapter = New OleDbDataAdapter("SELECT * FROM " + CStr(tbClassi.Rows(0)("tabParametri")) + " ORDER BY Ordine", MatBase)
                    TableParam1 = New DataTable
                    cmdTP.Fill(TableParam1)
                End If
                For i = 1 To NumParam
                    cmdT(i) = New OleDbDataAdapter("SELECT * FROM " + CStr(tbClassi.Rows(0)("tabClasPr")) + " WHERE Parametro = " + Funzioni.ConvertiVirgola(Paramv(i).ToString) + " AND IdMat = " + m.Indmat.ToString + " ORDER BY DataRev DESC", MatBase)
                    custCBT(i) = New OleDbCommandBuilder(cmdT(i))
                    T = New DataTable
                    cmdT(i).Fill(T)
                    Dim dvT As DataView = New DataView(T)
                    If m.Classe = ClasseMateriale.Fucinati Then
                        dvT.RowFilter = "Codice = " & CStr(TableParam1.Rows(i - 1)("Codice")) '+ "'"
                    Else
                        dvT.RowFilter = ""
                    End If
                    Select Case m.Classe
                        Case ClasseMateriale.LamiereCS, ClasseMateriale.Fucinati
                            If chkComp.CheckState = 0 Then
                                Criterio = "(Tipo=0 OR Tipo IS NULL)"
                            Else
                                Criterio = "Tipo>0"
                            End If
                            If dvT.RowFilter.Length > 0 Then
                                dvT.RowFilter = dvT.RowFilter & " AND " & Criterio
                            Else
                                dvT.RowFilter = Criterio
                            End If
                    End Select
                    iflp(i) = dvT
                    iflpt(i) = T
                    iprezzi = i
                    If dvT.Count > 0 Then iflpd(i) = iflp(i)(0)
                Next
                If m.Classe = ClasseMateriale.Fucinati Then
                    TableParam1.Dispose()
                    Table1.Dispose()
                End If
                If NumParamSc > 0 Then
                    Combo1(0).Visible = True
                    Combo1(0).BringToFront()
                    Label6.Visible = True
                    Label6.Text = CStr(tbClassi.Rows(0)("NomeParSc"))
                    RiempiCombo(Combo1(0), 0, TableParamSc)
                    Combo1(0).SelectedIndex = linum2 - 1
                End If
                lblParam(0).Text = Param(1)
                lblParam(0).Visible = True
                ttPrezzo(0).Visible = True
                ttPrezzo(0).BringToFront()
                If NumParamSc > 0 Then
                    Combo1(0).Visible = True
                    Combo1(0).BringToFront()
                    RiempiCombo(Combo1(0), 0, TableParamSc)
                    Combo1(0).SelectedIndex = linum2 - 1
                End If
                For i = 2 To NumParam
                    lblParam.Load(CShort(i - 1))
                    lblParam(CShort(i - 1)).Text = Param(i)
                    lblParam(CShort(i - 1)).Top = lblParam(CShort(i - 2)).Top + lblParam(CShort(i - 2)).Height
                    lblParam(CShort(i - 1)).Visible = True
                    If NumParamSc > 0 Then
                        Combo1.Load(CShort(i - 1))
                        Combo1(CShort(i - 1)).Top = lblParam(CShort(i - 1)).Top
                        Combo1(CShort(i - 1)).Visible = True
                        Combo1(CShort(i - 1)).BringToFront()
                        RiempiCombo(Combo1(CShort(i - 1)), CShort(i - 1), TableParamSc)
                        Combo1(CShort(i - 1)).SelectedIndex = linum2 - 1
                    End If
                Next
                If linum > 0 Then lblParam(CShort(linum - 1)).BackColor = Color.Yellow
                Labels()
                Height = SystemInformation.CaptionHeight + 6 * SystemInformation.Border3DSize.Height + lblParam(CShort(NumParam - 1)).Top + lblParam(CShort(NumParam - 1)).Height
            End If
            If NumParamSc = 0 Then Aggiorna(0)
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
    End Sub
    Private Sub Labels()
        Dim i As Integer
        lblPrezzo.Text = CStr(tbClassi.Rows(0)("PrezzoPr"))
        If CStr(tbClassi.Rows(0)("unitAlt")) = "-" Then
            lblPrezzo2.Visible = False
            ttPrezzo2(0).Visible = False
            lblUniMis2(0).Visible = False
        Else
            lblPrezzo2.Text = CStr(tbClassi.Rows(0)("PrezzoAlt"))
            lblUniMis2(0).Text = CStr(tbClassi.Rows(0)("unitAlt"))
            For i = 2 To NumParam
                lblUniMis2.Load(CShort(i - 1))
                lblUniMis2(CShort(i - 1)).Text = CStr(tbClassi.Rows(0)("unitAlt"))
            Next
        End If
    End Sub
    Private Sub GoPlates()
        Dim prezzi As New DataTable
        Dim Criterio, Par As String
        Dim i As Integer
        Dim testo As String
        Dim Classe As ClasseMateriale
        Dim Ind1 As Short, Ind2 As Short
        Dim TipoCompos As TipoRivestimento
        Dim drv As DataRowView
        If InStr(cmbMatExc.Text, "+") > 0 Then
            Dim Mat As clsMatCompos = New clsMatCompos
            Mat.Scelta(0)
            If Mat.Indmat = 0 Then Exit Sub
            Classe = Mat.Classe
            Ind1 = Mat.Indmat
            Ind2 = Mat.Mat(2).Indmat
            TipoCompos = Mat.TipoCompos
        Else
            Dim Mat As MaterialeNew1 = New MaterialeNew1
            Mat.Scelta(0)
            If Mat.Indmat = 0 Then Exit Sub
            Classe = Mat.Classe
            Ind1 = Mat.Indmat
            Ind2 = 0
            TipoCompos = 0
        End If
        ParametriPrezzo(Classe)
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        Dim cmd As OleDbDataAdapter = New OleDbDataAdapter("SELECT * FROM PLATES WHERE MATERIAL='" & cmbMatExc.Text & "'", connPrezzi)
        cmd.Fill(rstLinked)
        Dim cmdpr As OleDbDataAdapter = New OleDbDataAdapter("SELECT * FROM " + CStr(tbClassi.Rows(0)("tabClasPr")) + " WHERE IdMat = " + Str(Ind1), MatBase)
        cmdpr.MissingSchemaAction = MissingSchemaAction.AddWithKey
        cmdpr.Fill(prezzi)
        Dim custCBpr As OleDbCommandBuilder = New OleDbCommandBuilder(cmdpr)
        Dim dvpr As DataView = New DataView(prezzi)
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        For i = 0 To rstLinked.Rows.Count - 1
            Try
                Par = Str(SubClasse(Classe, CSng(rstLinked.Rows(i)("THK")), 0))
                Criterio = "PrezzoLkg = " & CStr(rstLinked.Rows(i)("LIRE/kg"))
                Criterio = Criterio & " AND Fornitore = '" + CStr(rstLinked.Rows(i)("SUPPLIER")) + "'"
                Criterio = Criterio & " AND Parametro = " & Par
                Criterio = Criterio & " AND DataRev = #" & CStr(rstLinked.Rows(i)("Date")) & "#"
                Criterio = Criterio & " AND SpessBase = " & CStr(rstLinked.Rows(i)("THK"))
                Criterio = Criterio & " AND Lungh = " & CStr(rstLinked.Rows(i)("Length"))
                Criterio = Criterio & " AND Largh = " & CStr(rstLinked.Rows(i)("Width"))
                If Ind2 > 0 Then
                    Criterio = Criterio & " AND IdMat2 = " & Ind2.ToString
                    Criterio = Criterio & " AND SpessRive = " & CStr(rstLinked.Rows(i)("CLAD THK"))
                End If
                dvpr.RowFilter = Criterio
                If dvpr.Count > 0 Then
                    testo = "Risulta che l'operazione di caricamento è già stata effettuata su questi dati. Vuoi continuare?"
                    If MsgBox(testo, CType(MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.DefaultButton2, MsgBoxStyle)) = MsgBoxResult.No Then Exit For
                End If
                drv = dvpr.AddNew()
                drv("SpessBase") = rstLinked.Rows(i)("THK")
                drv("Lungh") = rstLinked.Rows(i)("Length")
                drv("Largh") = rstLinked.Rows(i)("Width")
                drv("IdMat") = Ind1
                drv("Datarev") = rstLinked.Rows(i)("Date") '14/06/98
                drv("Parametro") = Funzioni.ValVir(Par) 'Paramv(i)
                drv("Fornitore") = CStr(rstLinked.Rows(i)("SUPPLIER")).Substring(0, prezzi.Columns("Fornitore").MaxLength)
                drv("prezzolkg") = rstLinked.Rows(i)("LIRE/kg")
                drv("Firmato") = "XXX"
                testo = "Materiale:" & cmbMatExc.Text & vbCrLf
                testo = testo & "Numero di lamiere:" & Str(rstLinked.Rows(i)("No")) & vbCrLf
                If Not IsDBNull(rstLinked.Rows(i)("Width")) And Not IsDBNull(rstLinked.Rows(i)("Length")) Then
                    If CSng(rstLinked.Rows(i)("Width")) * CSng(rstLinked.Rows(i)("Length")) > 0 Then
                        If CSng(rstLinked.Rows(i)("CLAD THK")) > 0 Then
                            testo = testo & "Larhezza x Lunghezza x sp:" & Str(rstLinked.Rows(i)("Width")) & " x" & Str(rstLinked.Rows(i)("Length")) & " x" & Str(rstLinked.Rows(i)("THK")) & " +" & Str(rstLinked.Rows(i)("CLAD THK")) & vbCrLf
                            drv("SpessRive") = rstLinked.Rows(i)("CLAD THK")
                            drv("Tipo") = TipoCompos
                            drv("IdMat2") = Ind2
                        Else
                            testo = testo & "Larghezza x Lunghezza x sp:" & Str(rstLinked.Rows(i)("Width")) & " x" & Str(rstLinked.Rows(i)("Length")) & " x" & Str(rstLinked.Rows(i)("THK")) & vbCrLf
                        End If
                    Else
                        If CSng(rstLinked.Rows(i)("CLAD THK")) > 0 Then
                            testo = testo & "Spessore:" & Str(rstLinked.Rows(i)("THK")) & " +" & Str(rstLinked.Rows(i)("CLAD THK")) & vbCrLf
                            drv("SpessRive") = rstLinked.Rows(i)("CLAD THK")
                            drv("Tipo") = TipoCompos
                            drv("IdMat2") = Ind2
                        Else
                            testo = testo & "Spessore:" & Str(rstLinked.Rows(i)("THK")) & vbCrLf
                        End If
                    End If
                End If
                If Len(Trim(CStr(rstLinked.Rows(i)("ADDITIONAL REQUIREMENTS")))) > 0 Then
                    testo = testo & "REQUISITI ADDIZIONALI: " + CStr(rstLinked.Rows(i)("ADDITIONAL REQUIREMENTS")) + vbCrLf
                End If
                testo = testo & "Tempo di fornitura" & Str(rstLinked.Rows(i)("Delivery")) & " giorni" & vbCrLf
                testo = testo & CStr(rstLinked.Rows(i)("F16"))
                drv("NoteMie") = testo
                drv.EndEdit()
            Catch e As Exception
                MsgBox(e.Message & vbCrLf & e.StackTrace)
            End Try
        Next i
        cmdpr.Update(prezzi)
        cmbMatExc.Items.RemoveAt(cmbMatExc.SelectedIndex)
        cmbMatExc.SelectedIndex = 0
        cmdGo.Visible = False
    End Sub
    Private Sub GoEll()
        Dim Mat As LibMat.MaterialeNew1
        Dim prezzi As New DataTable
        Dim Criterio, Par As String
        Dim i As Integer
        Dim testo, Par2 As String
        Dim drv As DataRowView
        Mat = FormMat.Item(1).TextData.MatSolo
        ParametriPrezzo(Mat.Classe)
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        Dim cmd As OleDbDataAdapter = New OleDbDataAdapter("SELECT * FROM ELLHEADS", connPrezzi)
        cmd.Fill(rstLinked)
        Dim cmdpr As OleDbDataAdapter = New OleDbDataAdapter("SELECT * FROM " + CStr(tbClassi.Rows(0)("tabClasPr")) + " WHERE IdMat = " + Str(Mat.Indmat), connPrezzi)
        cmdpr.MissingSchemaAction = MissingSchemaAction.AddWithKey
        cmdpr.Fill(prezzi)
        Dim custCBpr As OleDbCommandBuilder = New OleDbCommandBuilder(cmdpr)
        Dim dvpr As DataView = New DataView(prezzi)
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        For i = 0 To rstLinked.Rows.Count - 1
            Try
                Par = Str(SubClasse(Mat.Classe, CSng(rstLinked.Rows(i)("ID")), 0))
                Par2 = Str(SubClasse2(Mat.Classe, CSng(rstLinked.Rows(i)("MAF"))))
                Criterio = "PrezzoLkg = " & CStr(rstLinked.Rows(i)("LireKg"))
                Criterio = Criterio & " AND Fornitore = '" + CStr(rstLinked.Rows(i)("SUPPLIER")) + "'"
                Criterio = Criterio & " AND Parametro = " & Par
                Criterio = Criterio & " AND DataRev = #" & CStr(rstLinked.Rows(i)("Date")) & "#"
                Criterio = Criterio & " AND Parametro2 = " & Par2
                dvpr.RowFilter = Criterio
                If dvpr.Count > 0 Then
                    testo = "Risulta che l'operazione di caricamento è già stata effettuata su questi dati. Vuoi continuare?"
                    If MsgBox(testo, CType(MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.DefaultButton2, MsgBoxStyle)) = MsgBoxResult.No Then Exit For
                End If
                drv = dvpr.AddNew()
                drv("SpessPar") = rstLinked.Rows(i)("THK")
                drv("MAF") = rstLinked.Rows(i)("MAF")
                drv("Diametro") = rstLinked.Rows(i)("ID")
                drv("CLAD") = rstLinked.Rows(i)("CLAD")
                drv("h") = rstLinked.Rows(i)("h")
                drv("PesoNetto") = rstLinked.Rows(i)("Each")
                drv("From") = rstLinked.Rows(i)("By")
                drv("To") = rstLinked.Rows(i)("To")
                'prezzi!IdMat = Mat.Indmat
                drv("Datarev") = rstLinked.Rows(i)("Date")
                drv("Parametro") = Funzioni.ValVir(Par)
                drv("Parametro2") = Funzioni.ValVir(Par2)
                drv("Fornitore") = CStr(rstLinked.Rows(i)("SUPPLIER")).Substring(0, prezzi.Columns("Fornitore").MaxLength)
                drv("prezzolkg") = rstLinked.Rows(i)("LireKg")
                drv("PrezzoAlt") = rstLinked.Rows(i)("TOTALC")
                drv("HeatTr") = rstLinked.Rows(i)("HEATT")
                drv("Tipo") = rstLinked.Rows(i)("Form")
                drv("Firmato") = "XXX"
                testo = "Materiale:" & Trim(CStr(rstLinked.Rows(i)("MATERIAL"))) & vbCrLf
                testo = testo & "Numero di fondi:" & Str(rstLinked.Rows(i)("n")) & "; ID" & Str(rstLinked.Rows(i)("ID")) & ", M.A.F." & Str(rstLinked.Rows(i)("MAF")) & vbCrLf
                testo = testo & "Colletto" & Str(rstLinked.Rows(i)("h")) & " spessore di partenza" & Str(rstLinked.Rows(i)("THK")) & vbCrLf
                testo = testo & "Peso Netto (cad.):" & Funzioni.myStr(CSng(rstLinked.Rows(i)("Each")), 6, 0, 0) & " Kg" & vbCrLf
                testo = testo & "Tipo formatura: " + CStr(rstLinked.Rows(i)("Form")) + vbCrLf
                If IsDBNull(rstLinked.Rows(i)("HEATT")) Then
                    testo = testo & "TT: Non def." & vbCrLf
                Else
                    testo = testo & "TT: " + CStr(rstLinked.Rows(i)("HEATT")) + vbCrLf
                End If
                If Len(Trim(CStr(rstLinked.Rows(i)("ADDITIONAL REQ")))) > 0 Then
                    testo = testo & "REQUISITI ADDIZIONALI: " + CStr(rstLinked.Rows(i)("ADDITIONAL REQ")) + vbCrLf
                End If
                If Not IsDBNull(rstLinked.Rows(i)("Delivery")) Then
                    testo = testo & "Tempo di fornitura" & Str(rstLinked.Rows(i)("Delivery")) & " giorni" & vbCrLf
                End If
                If IsDBNull(rstLinked.Rows(i)("By")) Then
                    testo = testo & "Mat. fornito: ?" & vbCrLf
                Else
                    testo = testo & "Mat. fornito: " + CStr(rstLinked.Rows(i)("By")) + vbCrLf
                End If
                testo = testo & "Mat. ritornato: " + CStr(rstLinked.Rows(i)("To")) + vbCrLf
                If Not IsDBNull(rstLinked.Rows(i)("notes")) Then
                    testo = testo & CStr(rstLinked.Rows(i)("notes"))
                End If
                drv("NoteMie") = testo
                drv.EndEdit()
            Catch e As Exception
                MsgBox(e.Message & vbCrLf & e.StackTrace)
            End Try
ResThk: Next i
        cmdpr.Update(prezzi)
    End Sub
    Private Sub GoTubes()
        Dim prezzi As New DataTable
        Dim Criterio, Par As String
        Dim i As Integer
        Dim Ind1, Ind2 As Short
        Dim testo As String
        Dim Classe As ClasseMateriale
        Dim drv As DataRowView
        If InStr(cmbMatExc.Text, "+") > 0 Then
            Dim Mat As clsMatCompos = New clsMatCompos
            Mat.Scelta(0)
            Ind1 = Mat.Mat(1).Indmat
            If Ind1 = 0 Then Exit Sub
            Ind2 = Mat.Mat(2).Indmat
            Classe = Mat.Classe
        Else
            Dim Mat As MaterialeNew1 = New MaterialeNew1
            Mat.Scelta(0)
            Ind1 = Mat.Indmat
            If Ind1 = 0 Then Exit Sub
            Ind2 = 0
            Classe = Mat.Classe
        End If
        ParametriPrezzo(Classe)
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        Dim cmd As OleDbDataAdapter = New OleDbDataAdapter("SELECT * FROM TUBES WHERE MATERIAL='" & cmbMatExc.Text & "'", connPrezzi)
        cmd.Fill(rstLinked)
        Dim cmdpr As OleDbDataAdapter = New OleDbDataAdapter("SELECT * FROM " + CStr(tbClassi.Rows(0)("tabClasPr")) + " WHERE IdMat = " + Str(Ind1), MatBase)
        cmdpr.MissingSchemaAction = MissingSchemaAction.AddWithKey
        cmdpr.Fill(prezzi)
        Dim custCBpr As OleDbCommandBuilder = New OleDbCommandBuilder(cmdpr)
        Dim dvpr As DataView = New DataView(prezzi)
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        For i = 0 To rstLinked.Rows.Count - 1
            Try
                Par = Str(SubClasse(Classe, CSng(rstLinked.Rows(i)("OD")), 0))
                Criterio = "PrezzoLkg = " & CStr(rstLinked.Rows(i)("LIRE/kg"))
                Criterio = Criterio & " AND Fornitore = '" + CStr(rstLinked.Rows(i)("SUPPLIER")) + "'"
                Criterio = Criterio & " AND Parametro = " & Par
                Criterio = Criterio & " AND DataRev = #" & CStr(rstLinked.Rows(i)("Date")) & "#"
                dvpr.RowFilter = Criterio
                If dvpr.Count > 0 Then
                    testo = "Risulta che l'operazione di caricamento è già stata effettuata su questi dati. Vuoi continuare?"
                    If MsgBox(testo, CType(MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.DefaultButton2, MsgBoxStyle)) = MsgBoxResult.No Then Exit For
                End If
                drv = dvpr.AddNew()
                drv("IdMat") = Ind1
                drv("Datarev") = rstLinked.Rows(i)("Date") '14/06/98
                drv("Parametro") = Funzioni.ValVir(Par) 'Paramv(i)
                drv("Parametro2") = rstLinked.Rows(i)("THK")
                drv("Fornitore") = CStr(rstLinked.Rows(i)("SUPPLIER")).Substring(0, prezzi.Columns("Fornitore").MaxLength)
                drv("prezzolkg") = rstLinked.Rows(i)("LIRE/kg")
                drv("PrezzoAlt") = rstLinked.Rows(i)("LIRE/m")
                drv("Firmato") = "XXX"
                testo = "Materiale:" & cmbMatExc.Text & vbCrLf
                testo = testo & "Numero di pezzi:" & CStr(rstLinked.Rows(i)("N#OF PIECES")) & " (Lunghezza:" & Str(rstLinked.Rows(i)("Length")) & ")" & vbCrLf
                testo = testo & "Tolleranza: " + CStr(rstLinked.Rows(i)("TOL#")) + " ;tipo: " + CStr(rstLinked.Rows(i)("SMLS/WLD ")) + vbCrLf
                If Len(Trim(CStr(rstLinked.Rows(i)("ADDITIONAL REQ")))) > 0 Then
                    testo = testo & "REQUISITI ADDIZIONALI: " + CStr(rstLinked.Rows(i)("ADDITIONAL REQ")) + vbCrLf
                End If
                testo = testo & "Tempo di fornitura" & CStr(rstLinked.Rows(i)("Deliv")) & " giorni" & vbCrLf
                testo = testo & CStr(rstLinked.Rows(i)("notes"))
                drv("NoteMie") = testo
                drv.EndEdit()
            Catch e As Exception
                MsgBox(e.Message & vbCrLf & e.StackTrace)
            End Try
        Next i
        cmdpr.Update(prezzi)
        cmbMatExc.Items.RemoveAt(cmbMatExc.SelectedIndex)
        cmbMatExc.SelectedIndex = 0
        cmdGo.Visible = False
    End Sub
    Private Sub GoForg()
        Dim prezzi As New DataTable
        Dim Criterio, Par As String
        Dim i As Integer
        Dim TipoCompos As TipoRivestimento
        Dim testo As String, Mat1, Mat2 As String
        Dim SP As Single
        Dim Ind1, Ind2 As Short
        Dim Classe As ClasseMateriale
        Dim drv As DataRowView
        If InStr(cmbMatExc.Text, "+") > 0 Then
            Dim Mat As clsMatCompos = New clsMatCompos
            Mat.Scelta(0)
            Ind1 = Mat.Indmat
            If Ind1 = 0 Then Exit Sub
            Ind2 = Mat.Mat(2).Indmat
            Mat2 = Mat.Mat(2).MatStr
            Classe = Mat.Classe
            Mat1 = Mat.Mat(1).MatStr
            TipoCompos = Mat.TipoCompos
        Else
            Dim Mat As MaterialeNew1 = New MaterialeNew1
            Mat.Scelta(0)
            Ind1 = Mat.Indmat
            If Ind1 = 0 Then Exit Sub
            Ind2 = 0
            Mat2 = ""
            Classe = Mat.Classe
            Mat1 = Mat.MatStr
            TipoCompos = TipoRivestimento.Nessuno
        End If
        ParametriPrezzo(Classe)
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        Dim cmd As OleDbDataAdapter = New OleDbDataAdapter("SELECT * FROM FORG WHERE MATERIAL='" & cmbMatExc.Text & "'", connPrezzi)
        cmd.Fill(rstLinked)
        Dim cmdpr As OleDbDataAdapter = New OleDbDataAdapter("SELECT * FROM " + CStr(tbClassi.Rows(0)("tabClasPr")) + " WHERE IdMat = " + Str(Ind1), MatBase)
        cmdpr.MissingSchemaAction = MissingSchemaAction.AddWithKey
        cmdpr.Fill(prezzi)
        Dim custCBpr As OleDbCommandBuilder = New OleDbCommandBuilder(cmdpr)
        Dim dvpr As DataView = New DataView(prezzi)
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        For i = 0 To rstLinked.Rows.Count - 1
            Try
                Par = Str(SubClasse(Classe, CSng(rstLinked.Rows(i)("GROSS")), 1))
                Criterio = "PrezzoLkg=" & Str(rstLinked.Rows(i)("GROSSC"))
                Criterio = Criterio & " AND Fornitore='" + CStr(rstLinked.Rows(i)("SUPPLIER")) + "'"
                Criterio = Criterio & " AND Parametro=" & Par
                Criterio = Criterio & " AND DataRev=#" & Str(rstLinked.Rows(i)("Date")) & "#"
                If InStr(cmbMatExc.Text, "+") > 0 Then
                    Criterio = Criterio & " AND IdMat2=" & Str(Ind2)
                    Criterio = Criterio & " AND SpessRive=" & Str(rstLinked.Rows(i)("THK"))
                End If
                dvpr.RowFilter = Criterio
                If dvpr.Count > 0 Then
                    testo = "Risulta che l'operazione di caricamento è già stata effettuata su questi dati. Vuoi continuare?"
                    If MsgBox(testo, CType(MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.DefaultButton2, MsgBoxStyle)) = MsgBoxResult.No Then Exit For
                End If
                drv = dvpr.AddNew()
                Select Case CStr(rstLinked.Rows(i)("Type"))
                    Case "CONE"
                        GoTo ResThk
                    Case "COURSE"
                        drv("Codice") = 5
                    Case "FLAT COVER"
                        drv("Codice") = 2
                    Case "GIRTH FLANGE"
                        drv("Codice") = 7
                    Case "HUB"
                        drv("Codice") = 6
                    Case "RING"
                        drv("Codice") = 1
                    Case "TUBESHEET"
                        drv("Codice") = 8
                    Case Else
                        GoTo ResThk
                End Select
                drv("IdMat") = Ind1
                drv("Datarev") = rstLinked.Rows(i)("Date") '14/06/98
                drv("Parametro") = Funzioni.ValVir(Par) 'Paramv(i)
                drv("Fornitore") = CStr(rstLinked.Rows(i)("SUPPLIER")).Substring(0, prezzi.Columns("Fornitore").MaxLength)
                drv("prezzolkg") = rstLinked.Rows(i)("GROSSC")
                drv("PrezzoAlt") = rstLinked.Rows(i)("NETC")
                drv("PrezzoUni") = rstLinked.Rows(i)("COST(ML)")
                drv("PesoGrosso") = rstLinked.Rows(i)("GROSS")
                drv("PesoNetto") = rstLinked.Rows(i)("NET")
                drv("ODiam") = rstLinked.Rows(i)("OD")
                drv("IDiam") = rstLinked.Rows(i)("ID")
                drv("h") = rstLinked.Rows(i)("h")
                drv("Firmato") = "XXX"
                testo = "Materiale:" & cmbMatExc.Text & vbCrLf
                If InStr(cmbMatExc.Text, "+") > 0 Then
                    If IsDBNull(rstLinked.Rows(i)("THK")) Then
                        SP = 0
                    Else
                        SP = CSng(rstLinked.Rows(i)("THK"))
                    End If
                    testo = testo & "Placcato " & Trim(Mat2) & " sp." & Str(SP) & vbCrLf
                    drv("SpessRive") = SP
                    drv("Tipo") = TipoCompos
                    drv("IdMat2") = Ind2
                End If
                testo = testo & "Numero di pezzi:" & Str(rstLinked.Rows(i)("N#OF PIECES")) & " (Costo unitario: " & Str(rstLinked.Rows(i)("COST(ML)")) & ")" & vbCrLf
                If IsDBNull(rstLinked.Rows(i)("ID")) Then
                    testo = testo & "Diam.est.:" & Str(rstLinked.Rows(i)("OD")) & ",H:" & Str(rstLinked.Rows(i)("h")) & vbCrLf
                Else
                    If CInt(rstLinked.Rows(i)("ID")) = 0 Then
                        testo = testo & "Diam.est.:" & Str(rstLinked.Rows(i)("OD")) & ",H:" & Str(rstLinked.Rows(i)("h")) & vbCrLf
                    Else
                        testo = testo & "Diam.est.:" & Str(rstLinked.Rows(i)("OD")) & ",Diam.int.:" & Str(rstLinked.Rows(i)("ID")) & ",H:" & Str(rstLinked.Rows(i)("h")) & vbCrLf
                    End If
                End If
                If Len(Trim(CStr(rstLinked.Rows(i)("ADDITIONAL REQ")))) > 0 Then
                    testo = testo & "REQUISITI ADDIZIONALI: " + CStr(rstLinked.Rows(i)("ADDITIONAL REQ")) + vbCrLf
                End If
                If Not IsDBNull(rstLinked.Rows(i)("Delivery")) Then
                    testo = testo & "Tempo di fornitura" & Str(rstLinked.Rows(i)("Delivery")) & " giorni" & vbCrLf
                End If
                testo = testo & CStr(rstLinked.Rows(i)("notes"))
                drv("NoteMie") = testo
                drv.EndEdit()
            Catch e As Exception
                MsgBox(e.Message & vbCrLf & e.StackTrace)
            End Try
ResThk: Next i
        cmdpr.Update(prezzi)
        cmbMatExc.Items.RemoveAt(cmbMatExc.SelectedIndex)
        cmbMatExc.SelectedIndex = 0
        cmdGo.Visible = False
    End Sub
    Private Sub GoFlan()
        Dim prezzi As New DataTable
        Dim Par As String
        Dim i As Integer, TipoCompos As TipoRivestimento
        Dim testo As String, Mat1, Mat2 As String
        Dim Ind1, Ind2 As Short, Classe As ClasseMateriale
        Dim drv As DataRowView
        If InStr(cmbMatExc.Text, "+") > 0 Then
            Dim Mat As clsMatCompos = New clsMatCompos
            Mat.Scelta(0)
            Ind1 = Mat.Indmat
            If Ind1 = 0 Then Exit Sub
            Ind2 = Mat.Mat(2).Indmat
            Mat2 = Mat.Mat(2).MatStr
            Classe = Mat.Classe
            Mat1 = Mat.Mat(1).MatStr
            TipoCompos = Mat.TipoCompos
        Else
            Dim Mat As MaterialeNew1 = New MaterialeNew1
            Mat.Scelta(0)
            Ind1 = Mat.Indmat
            If Ind1 = 0 Then Exit Sub
            Ind2 = 0
            Mat2 = ""
            Classe = Mat.Classe
            Mat1 = Mat.MatStr
            TipoCompos = 0
        End If
        ParametriPrezzo(Classe)
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        Dim cmd As OleDbDataAdapter = New OleDbDataAdapter("SELECT * FROM FLAN WHERE MATERIAL='" & cmbMatExc.Text & "'", connPrezzi)
        cmd.Fill(rstLinked)
        Dim cmdpr As OleDbDataAdapter = New OleDbDataAdapter("SELECT * FROM " + CStr(tbClassi.Rows(0)("tabClasPr")) + " WHERE IdMat = " + Str(Ind1), MatBase)
        cmdpr.MissingSchemaAction = MissingSchemaAction.AddWithKey
        cmdpr.Fill(prezzi)
        Dim custCBpr As OleDbCommandBuilder = New OleDbCommandBuilder(cmdpr)
        Dim dvpr As DataView = New DataView(prezzi)
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        For i = 0 To rstLinked.Rows.Count - 1
            Try
                Par = Str(SubClasse(Classe, CSng(rstLinked.Rows(i)("NPS")), 3))
                '      Criterio = "PrezzoLkg=" + Str$(![GROSSC])
                '      Criterio = Criterio + " AND Fornitore='" + !SUPPLIER + "'"
                '      Criterio = Criterio + " AND Parametro=" + Par
                '      Criterio = Criterio + " AND DataRev=#" + Str(!Date) + "#"
                '      If InStr(cmbMatExc, "+") > 0 Then
                '         Criterio = Criterio + " AND IdMat2=" + Str$(Mat.Mat(2).Indmat)
                '         Criterio = Criterio + " AND SpessRive=" + Str$(!THK)
                '      End If
                '      prezzi.FindFirst Criterio
                '      If Not prezzi.NoMatch Then
                '         testo = "Risulta che l'operazione di caricamento è già stata effettuata su questi dati. Vuoi continuare?"
                '         If MsgBox(testo, vbYesNo + vbQuestion + vbDefaultButton2) = vbNo Then Exit Do
                '      End If
                drv = dvpr.AddNew()
                Select Case CStr(rstLinked.Rows(i)("Type")).Substring(0, 2)
                    Case "BL"
                        drv("Codice") = 4
                    Case "LW"
                        drv("Codice") = 3
                    Case "WN"
                        drv("Codice") = 4
                    Case Else
                        GoTo ResThk
                End Select
                drv("IdMat") = Ind1
                drv("Datarev") = rstLinked.Rows(i)("Date") '14/06/98
                drv("Parametro") = Funzioni.ValVir(Par) 'Paramv(i)
                drv("Fornitore") = CStr(rstLinked.Rows(i)("SUPPLIER")).Substring(0, prezzi.Columns("Fornitore").MaxLength)
                If CInt(rstLinked.Rows(i)("GROSSC")) = 0 Then drv("prezzolkg") = 99999 Else drv("prezzolkg") = rstLinked.Rows(i)("GROSSC")
                drv("PrezzoAlt") = rstLinked.Rows(i)("NETC")
                drv("PrezzoUni") = rstLinked.Rows(i)("COST")
                drv("PesoGrosso") = rstLinked.Rows(i)("GROSS")
                drv("PesoNetto") = rstLinked.Rows(i)("NET")
                drv("ODiam") = rstLinked.Rows(i)("NPS")
                drv("IDiam") = rstLinked.Rows(i)("rtg")
                drv("h") = 0.0#
                drv("Firmato") = "XXX"
                testo = "Materiale:" & cmbMatExc.Text & vbCrLf
                '      If InStr(cmbMatExc, "+") > 0 Then
                '         If IsNull(!THK) Then
                '            SP = 0
                '         Else
                '            SP = !THK
                '         End If
                '         testo = testo + "Placcato " + Trim(Mat.Mat(2).MatStr) + " sp." + Str$(SP) + vbCrLf
                '         prezzi!SpessRive = SP
                '         prezzi!Tipo = Mat.TipoCompos
                '         prezzi!IdMat2 = Mat.Mat(2).Indmat
                '      End If
                testo = testo & "Numero di pezzi:" & Str(rstLinked.Rows(i)("PIECES")) & " (Costo unitario: " & Str(rstLinked.Rows(i)("COST")) & ")" & vbCrLf
                testo = testo & "DN " & Str(rstLinked.Rows(i)("NPS")) & "in. Rtg." & Str(rstLinked.Rows(i)("rtg")) & "# tipo " + CStr(rstLinked.Rows(i)("Type")) + vbCrLf
                If Len(Trim(CStr(rstLinked.Rows(i)("ADDITIONAL REQ")))) > 0 Then
                    testo = testo & "REQUISITI ADDIZIONALI: " + CStr(rstLinked.Rows(i)("ADDITIONAL REQ")) + vbCrLf
                End If
                If Not IsDBNull(rstLinked.Rows(i)("Deliv")) Then
                    testo = testo & "Tempo di fornitura" & Str(rstLinked.Rows(i)("Deliv")) & " giorni" & vbCrLf
                End If
                testo = testo & CStr(rstLinked.Rows(i)("notes"))
                drv("NoteMie") = testo
                drv.EndEdit()
            Catch e As Exception
                MsgBox(e.Message & vbCrLf & e.StackTrace)
            End Try
ResThk: Next i
        cmdpr.Update(prezzi)
        cmbMatExc.Items.RemoveAt(cmbMatExc.SelectedIndex)
        cmbMatExc.SelectedIndex = 0
        cmdGo.Visible = False
    End Sub
    Private Sub GoElbw()
        Dim prezzi As New DataTable
        Dim Par As String
        Dim i As Integer
        Dim testo As String
        Dim Mat As MaterialeNew1 = New MaterialeNew1
        Dim drv As DataRowView
        Mat.Scelta(0)
        If Mat.Indmat = 0 Then Exit Sub
        ParametriPrezzo(Mat.Classe)
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        Dim cmd As OleDbDataAdapter = New OleDbDataAdapter("SELECT * FROM ELBW WHERE MATERIAL='" & cmbMatExc.Text & "'", connPrezzi)
        cmd.Fill(rstLinked)
        Dim cmdpr As OleDbDataAdapter = New OleDbDataAdapter("SELECT * FROM " + CStr(tbClassi.Rows(0)("tabClasPr")) + " WHERE IdMat = " + Str(Mat.Indmat), MatBase)
        cmdpr.MissingSchemaAction = MissingSchemaAction.AddWithKey
        cmdpr.Fill(prezzi)
        Dim custCBpr As OleDbCommandBuilder = New OleDbCommandBuilder(cmdpr)
        Dim dvpr As DataView = New DataView(prezzi)
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        For i = 0 To rstLinked.Rows.Count - 1
            Try
                Par = Str(SubClasse(Mat.Classe, CSng(CSng(rstLinked.Rows(i)("OD")) / 25.5), 9))
                drv = dvpr.AddNew()
                drv("Codice") = 9
                drv("IdMat") = Mat.Indmat
                drv("Datarev") = rstLinked.Rows(i)("Date") '14/06/98
                drv("Parametro") = Funzioni.ValVir(Par) 'Paramv(i)
                drv("Fornitore") = CStr(rstLinked.Rows(i)("SUPPLIER")).Substring(0, prezzi.Columns("Fornitore").MaxLength)
                drv("prezzolkg") = rstLinked.Rows(i)("LIRE/kg")
                drv("prezzolkg") = rstLinked.Rows(i)("LIRE/kg")
                drv("PrezzoUni") = CSng(CSng(rstLinked.Rows(i)("LIRE/EACH")) / 1000000.0#)
                drv("PesoGrosso") = rstLinked.Rows(i)("Each")
                drv("PesoNetto") = rstLinked.Rows(i)("Each")
                drv("ODiam") = CSng(CSng(rstLinked.Rows(i)("OD")) / 25.4)
                drv("IDiam") = rstLinked.Rows(i)("THK")
                drv("h") = Funzioni.ValVir(CStr(rstLinked.Rows(i)("Alfa")))
                drv("RsuD") = 1.5
                drv("Firmato") = "XXX"
                testo = "Materiale:" & cmbMatExc.Text & vbCrLf
                testo = testo & "Numero di pezzi:" & Str(rstLinked.Rows(i)("PIECES")) & " (Costo unitario: " & Str(CSng(rstLinked.Rows(i)("LIRE/EACH")) / 1000000.0#) & ")" & vbCrLf
                testo = testo & "DN " & Str(CSng(rstLinked.Rows(i)("OD")) / 25.4) & "in. thk." & Str(rstLinked.Rows(i)("THK")) & "mm. R/D=1.5 " & vbCrLf
                If Len(Trim(CStr(rstLinked.Rows(i)("ADDITIONAL REQ")))) > 0 Then
                    testo = testo & "REQUISITI ADDIZIONALI: " + CStr(rstLinked.Rows(i)("ADDITIONAL REQ")) + vbCrLf
                End If
                If Not IsDBNull(rstLinked.Rows(i)("Delivery")) Then
                    testo = testo & "Tempo di fornitura" & Str(rstLinked.Rows(i)("Delivery")) & " giorni" & vbCrLf
                End If
                testo = testo & CStr(rstLinked.Rows(i)("notes"))
                drv("NoteMie") = testo
                drv.EndEdit()
            Catch e As Exception
                MsgBox(e.Message & vbCrLf & e.StackTrace)
            End Try
ResThk: Next i
        cmdpr.Update(prezzi)
        cmbMatExc.Items.RemoveAt(cmbMatExc.SelectedIndex)
        cmbMatExc.SelectedIndex = 0
        cmdGo.Visible = False
    End Sub
    Public Sub Aggiornatesto(ByRef Index As Short)
        If Not txtNote.Visible Then Exit Sub
        If IsDBNull(iflpd(Index + 1)("NoteMie")) Then
            txtNote.Text = ""
        Else
            txtNote.Text = CStr(iflpd(Index + 1)("NoteMie")) '!NOTE
        End If
    End Sub
    Public Sub AggiornaNote()
        If Not txtNote.Visible Then Exit Sub
        Dim drv As DataRowView = iflpd(iprezzi)
        drv.BeginEdit()
        drv("NoteMie") = txtNote.Text
        drv.EndEdit()
    End Sub
    Private Sub GoHem()
        Dim Mat As LibMat.MaterialeNew1
        Dim prezzi As New DataTable
        Dim Criterio, Par As String
        Dim i As Integer
        Dim testo, Par2 As String
        Dim drv As DataRowView
        Mat = FormMat.Item(1).TextData.MatSolo
        ParametriPrezzo(Mat.Classe)
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        Dim cmd As OleDbDataAdapter = New OleDbDataAdapter("SELECT * FROM HEMHEADS", connPrezzi)
        cmd.Fill(rstLinked)
        Dim cmdpr As OleDbDataAdapter = New OleDbDataAdapter("SELECT * FROM " + CStr(tbClassi.Rows(0)("tabClasPr")), MatBase)
        cmdpr.MissingSchemaAction = MissingSchemaAction.AddWithKey
        cmdpr.Fill(prezzi)
        Dim custCBpr As OleDbCommandBuilder = New OleDbCommandBuilder(cmdpr)
        Dim dvpr As DataView = New DataView(prezzi)
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        For i = 0 To rstLinked.Rows.Count - 1
            Try
                Par = Str(SubClasse(Mat.Classe, CSng(rstLinked.Rows(i)("ID")), 0))
                Par2 = Str(SubClasse2(Mat.Classe, CSng(rstLinked.Rows(i)("MAF"))))
                Criterio = "PrezzoLkg=" & Str(rstLinked.Rows(i)("LireKg"))
                Criterio = Criterio & " AND Fornitore='" + CStr(rstLinked.Rows(i)("SUPPLIER")) + "'"
                Criterio = Criterio & " AND Parametro=" & Par
                Criterio = Criterio & " AND DataRev=#" & Str(rstLinked.Rows(i)("Date")) & "#"
                Criterio = Criterio & " AND Parametro2=" & Par2
                dvpr.RowFilter = Criterio
                If dvpr.Count > 0 Then
                    testo = "Risulta che l'operazione di caricamento è già stata effettuata su questi dati. Vuoi continuare?"
                    If MsgBox(testo, CType(MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.DefaultButton2, MsgBoxStyle)) = MsgBoxResult.No Then Exit For
                End If
                drv = dvpr.AddNew()
                drv("SpessPar") = rstLinked.Rows(i)("THK")
                drv("MAF") = rstLinked.Rows(i)("MAF")
                drv("Diametro") = rstLinked.Rows(i)("ID")
                drv("CLAD") = rstLinked.Rows(i)("CLAD")
                drv("h") = rstLinked.Rows(i)("h")
                drv("PesoNetto") = rstLinked.Rows(i)("Each")
                drv("From") = rstLinked.Rows(i)("By")
                drv("To") = rstLinked.Rows(i)("To")
                'prezzi!IdMat = Mat.Indmat
                drv("Datarev") = rstLinked.Rows(i)("Date")
                drv("Parametro") = Funzioni.ValVir(Par)
                drv("Parametro2") = Funzioni.ValVir(Par2)
                drv("Fornitore") = CStr(rstLinked.Rows(i)("SUPPLIER")).Substring(0, prezzi.Columns("Fornitore").MaxLength)
                drv("prezzolkg") = rstLinked.Rows(i)("LireKg")
                drv("PrezzoAlt") = rstLinked.Rows(i)("TOTALC")
                drv("HeatTr") = CStr(rstLinked.Rows(i)("HT")).Substring(0, 10)
                drv("Tipo") = rstLinked.Rows(i)("Form")
                drv("Firmato") = "XXX"
                testo = "Materiale:" & Trim(CStr(rstLinked.Rows(i)("MATERIAL"))) & vbCrLf
                testo = testo & "Numero di fondi:" & Str(rstLinked.Rows(i)("n")) & "; ID" & Str(rstLinked.Rows(i)("ID")) & ", M.A.F." & Str(rstLinked.Rows(i)("MAF")) & vbCrLf
                testo = testo & "Colletto" & Str(rstLinked.Rows(i)("h")) & " spessore di partenza" & Str(rstLinked.Rows(i)("THK")) & vbCrLf
                testo = testo & "Peso Netto (cad.):" & Funzioni.myStr(CSng(rstLinked.Rows(i)("Each")), 6, 0, 0) & " Kg" & vbCrLf
                testo = testo & "Tipo formatura: " + CStr(rstLinked.Rows(i)("Form")) + vbCrLf
                If IsDBNull(rstLinked.Rows(i)("HT")) Then
                    testo = testo & "TT: Non def." & vbCrLf
                Else
                    testo = testo & "TT: " + CStr(rstLinked.Rows(i)("HT")) + vbCrLf
                End If
                If Len(Trim(CStr(rstLinked.Rows(i)("ADDITIONAL REQ")))) > 0 Then
                    testo = testo & "REQUISITI ADDIZIONALI: " + CStr(rstLinked.Rows(i)("ADDITIONAL REQ")) + vbCrLf
                End If
                If Not IsDBNull(rstLinked.Rows(i)("Deliv")) Then
                    testo = testo & "Tempo di fornitura" & Str(rstLinked.Rows(i)("Deliv")) & " giorni" & vbCrLf
                End If
                If IsDBNull(rstLinked.Rows(i)("By")) Then
                    testo = testo & "Mat. fornito: ?" & vbCrLf
                Else
                    testo = testo & "Mat. fornito: " + CStr(rstLinked.Rows(i)("By")) + vbCrLf
                End If
                If IsDBNull(rstLinked.Rows(i)("To")) Then
                    testo = testo & "Mat. ritornato: ?" & vbCrLf
                Else
                    testo = testo & "Mat. ritornato: " + CStr(rstLinked.Rows(i)("To")) + vbCrLf
                End If
                If Not IsDBNull(rstLinked.Rows(i)("notes")) Then
                    testo = testo & CStr(rstLinked.Rows(i)("notes"))
                End If
                drv("NoteMie") = testo
                drv.EndEdit()
            Catch e As Exception
                MsgBox(e.Message & vbCrLf & e.StackTrace)
            End Try
ResThk: Next i
        cmdpr.Update(prezzi)
    End Sub
    Private Sub GoCal()
        Dim Mat As LibMat.MaterialeNew1
        Dim prezzi As New DataTable
        Dim Criterio, Par As String
        Dim i As Integer
        Dim testo, Par2 As String
        Dim drv As DataRowView
        Mat = FormMat.Item(1).TextData.MatSolo
        ParametriPrezzo(Mat.Classe)
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        Dim cmd As OleDbDataAdapter = New OleDbDataAdapter("SELECT * FROM CALANDR", connPrezzi)
        cmd.Fill(rstLinked)
        Dim cmdpr As OleDbDataAdapter = New OleDbDataAdapter("SELECT * FROM " + CStr(tbClassi.Rows(0)("tabClasPr")), MatBase)
        cmdpr.MissingSchemaAction = MissingSchemaAction.AddWithKey
        cmdpr.Fill(prezzi)
        Dim custCBpr As OleDbCommandBuilder = New OleDbCommandBuilder(cmdpr)
        Dim dvpr As DataView = New DataView(prezzi)
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        For i = 0 To rstLinked.Rows.Count - 1
            Try
                Par = Str(SubClasse(Mat.Classe, CSng(rstLinked.Rows(i)("ID")), 0))
                Par2 = Str(SubClasse2(Mat.Classe, CSng(rstLinked.Rows(i)("THK"))))
                Criterio = "PrezzoLkg=" & Str(rstLinked.Rows(i)("LireKg"))
                Criterio = Criterio & " AND Fornitore='" + CStr(rstLinked.Rows(i)("SUPPLIER")) + "'"
                Criterio = Criterio & " AND Parametro=" & Par
                Criterio = Criterio & " AND DataRev=#" & Str(rstLinked.Rows(i)("Date")) & "#"
                Criterio = Criterio & " AND Parametro2=" & Par2
                dvpr.RowFilter = Criterio
                If dvpr.Count > 0 Then
                    testo = "Risulta che l'operazione di caricamento è già stata effettuata su questi dati. Vuoi continuare?"
                    If MsgBox(testo, CType(MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.DefaultButton2, MsgBoxStyle)) = MsgBoxResult.No Then Exit For
                End If
                drv = dvpr.AddNew()
                drv("Spessore") = rstLinked.Rows(i)("THK")
                drv("Diametro") = rstLinked.Rows(i)("ID")
                drv("Lunghezza") = rstLinked.Rows(i)("Length")
                drv("PesoNetto") = rstLinked.Rows(i)("PESO")
                'prezzi!IdMat = Mat.Indmat
                drv("Datarev") = rstLinked.Rows(i)("Date")
                drv("Parametro") = Funzioni.ValVir(Par)
                drv("Parametro2") = Funzioni.ValVir(Par2)
                drv("Fornitore") = CStr(rstLinked.Rows(i)("SUPPLIER")).Substring(0, prezzi.Columns("Fornitore").MaxLength)
                drv("prezzolkg") = rstLinked.Rows(i)("LireKg")
                drv("PrezzoAlt") = rstLinked.Rows(i)("Each")
                drv("Tipo") = rstLinked.Rows(i)("HC")
                drv("Firmato") = "XXX"
                testo = "Materiale:" & Trim(CStr(rstLinked.Rows(i)("MATERIAL"))) & vbCrLf
                testo = testo & "Numero di fondi:" & Str(rstLinked.Rows(i)("No")) & "; ID" & Str(rstLinked.Rows(i)("ID")) & ", Sp." & Str(rstLinked.Rows(i)("THK")) & vbCrLf
                testo = testo & "Peso Netto (cad.):" & Funzioni.myStr(CSng(rstLinked.Rows(i)("PESO")), 6, 0, 0) & " Kg" & vbCrLf
                If IsDBNull(rstLinked.Rows(i)("HC")) Then
                    testo = testo & "Tipo calandratura: ?" & vbCrLf
                Else
                    testo = testo & "Tipo calandratura: " + CStr(rstLinked.Rows(i)("HC")) + vbCrLf
                End If
                testo = testo & "Saldatura lungitudinale:" + CStr(rstLinked.Rows(i)("S_LONG")) + vbCrLf
                testo = testo & "UT+MT su saldatura:" + CStr(rstLinked.Rows(i)("UT_MT")) + vbCrLf
                testo = testo & "TRornitura cianfrini:" + CStr(rstLinked.Rows(i)("TORN_SM")) + vbCrLf
                testo = testo & "Tempo di fornitura" & " ? " & " giorni" & vbCrLf
                If Not IsDBNull(rstLinked.Rows(i)("notes")) Then
                    testo = testo & CStr(rstLinked.Rows(i)("notes"))
                End If
                drv("NoteMie") = testo
                drv.EndEdit()
            Catch e As Exception
                MsgBox(e.Message & vbCrLf & e.StackTrace)
            End Try
ResThk: Next i
        cmdpr.Update(prezzi)
    End Sub
    Public Sub Combo_Enter(ByVal Nome As String)
        Dim s() As String = Nome.Split(CChar("_"))
        Dim Textnum As String = s(1)
        Dim Index As Short = CShort(s(2))
        iprezzi = Index + 1
    End Sub
    Public Sub Button_Enter(ByVal Nome As String)
        Dim s() As String = Nome.Split(CChar("_"))
        Dim Textnum As String = s(1)
        Dim Index As Short = CShort(s(2))
        Select Case Textnum
            Case "cmdCut"
                iprezzi = Index + 1
            Case "cmdNew"
                iprezzi = Index + 1
            Case "cmdMemo"
                iprezzi = Index + 1
        End Select
    End Sub
    Private Sub cmdSavNot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSavNot.Click
        AggiornaNote()
    End Sub
    Public Sub UpDown_ButtonDown(ByVal Nome As String)
        '    Private Sub UpDown1_DownClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles UpDown1.DownClick
        Dim s() As String = Nome.Split(CChar("_"))
        Dim Textnum As String = s(1)
        Dim Index As Short = CShort(s(2))
        iprezzi = Index + 1
        AggiornaNote()
        Dim Row As Integer = NumeroRiga(iflpd(Index + 1), iflp(Index + 1))
        AggDB(Index)
        If Row = 0 Then
            iflpd(Index + 1) = iflp(Index + 1)(iflp(Index + 1).Count - 1)
            '  BindingContext(iflp(Index + 1)).Position = iflp(Index + 1).Count - 1
        Else
            iflpd(Index + 1) = iflp(Index + 1)(Row - 1)
            'BindingContext(iflp(Index + 1)).Position -= 1
        End If
        Aggiornatesto(Index)
        AggScorri(Index)
        AggTxt(Index)
    End Sub
    Public Sub UpDown_ButtonUp(ByVal Nome As String)
        Dim s() As String = Nome.Split(CChar("_"))
        Dim Textnum As String = s(1)
        Dim Index As Short = CShort(s(2))
        iprezzi = Index + 1
        AggiornaNote()
        Dim Row As Integer = NumeroRiga(iflpd(Index + 1), iflp(Index + 1))
        AggDB(Index)
        If Row = iflp(Index + 1).Count - 1 Then
            iflpd(Index + 1) = iflp(Index + 1)(0)
            ' BindingContext(iflp(Index + 1)).Position = 0
        Else
            iflpd(Index + 1) = iflp(Index + 1)(Row + 1)
            ' BindingContext(iflp(Index + 1)).Position += 1
        End If
        Aggiornatesto(Index)
        AggScorri(Index)
        AggTxt(Index)
    End Sub
End Class
