Option Strict Off
Option Explicit On 
Imports System.IO
Imports RoutBase1
Friend Class frmDistinta
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
        Inizializzando = True
        InitializeComponent()
        Inizializzando = False
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
	Public WithEvents PictHelp As System.Windows.Forms.PictureBox
    Public WithEvents _Combo1_0 As System.Windows.Forms.ComboBox
	Public WithEvents _Combo1_1 As System.Windows.Forms.ComboBox
	Public WithEvents txtPeso As System.Windows.Forms.TextBox
    Public WithEvents _Label2_0 As System.Windows.Forms.Label
	Public WithEvents _Label2_1 As System.Windows.Forms.Label
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents _Label2_2 As System.Windows.Forms.Label
	Public WithEvents Frame3 As System.Windows.Forms.GroupBox
    Public WithEvents Frame2 As System.Windows.Forms.GroupBox
	Public WithEvents cmdFori As System.Windows.Forms.Button
	Public WithEvents cmdCreaPrototipo As System.Windows.Forms.Button
	Public WithEvents chkListaCompleta As System.Windows.Forms.CheckBox
	Public WithEvents cmdSezioni As System.Windows.Forms.Button
	Public WithEvents cmdCreaDaProto As System.Windows.Forms.Button
	Public WithEvents RigrGr As System.Windows.Forms.Button
	Public WithEvents cmdRiordina As System.Windows.Forms.Button
    Public WithEvents Frame1 As System.Windows.Forms.GroupBox
    Public WithEvents Listj As System.Windows.Forms.ListBox
    Public WithEvents Label1 As System.Windows.Forms.Label
	Public Combo1 As New System.Collections.Generic.Dictionary(Of Integer, ComboBox)
	Public Label2 As New System.Collections.Generic.Dictionary(Of Integer, Label)
	Public WithEvents mnuFileNew As System.Windows.Forms.MenuItem
	Public WithEvents mnuFileOpen As System.Windows.Forms.MenuItem
	Public WithEvents mnuFileClose As System.Windows.Forms.MenuItem
	Public WithEvents mnuFileExit As System.Windows.Forms.MenuItem
	Public WithEvents mnuFile As System.Windows.Forms.MenuItem
	Public WithEvents mnuAggImm As System.Windows.Forms.MenuItem
	Public WithEvents mnuVerboso As System.Windows.Forms.MenuItem
	Public WithEvents mnuPref As System.Windows.Forms.MenuItem
	Public WithEvents mnuHelpContents As System.Windows.Forms.MenuItem
    Public WithEvents mnuHelpBar1 As System.Windows.Forms.MenuItem
	Public WithEvents mnuHelpAbout As System.Windows.Forms.MenuItem
	Public WithEvents mnuHelp As System.Windows.Forms.MenuItem
	Public MainMenu1 As System.Windows.Forms.MainMenu
	'NOTA: la routine seguente è richiesta dalla progettazione Windows Form.
	'Può essere modificata utilizzando la finestra di progettazione Windows Form.
	'Non modificarla mediante l'editor di codice.
    Friend WithEvents pictAssieme As System.Windows.Forms.PictureBox
    Public WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmdHelpnonCB As System.Windows.Forms.Button
    Friend WithEvents pictVirtual As System.Windows.Forms.Panel
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents cmdPeso As System.Windows.Forms.Button
    Friend WithEvents cmdEdit As System.Windows.Forms.Button
    Friend WithEvents cmdIns As System.Windows.Forms.Button
    Friend WithEvents cmdCanc As System.Windows.Forms.Button
    Friend WithEvents cmdDuplica As System.Windows.Forms.Button
    Friend WithEvents cmdStam As System.Windows.Forms.Button
    Friend WithEvents Frame4 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdGrande As System.Windows.Forms.Button
    Friend WithEvents cmdZoom As System.Windows.Forms.Button
    Friend WithEvents cmdAuto As System.Windows.Forms.Button
    Friend WithEvents cmdAcad As System.Windows.Forms.Button
    Friend WithEvents mnuSalva As System.Windows.Forms.MenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmDistinta))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmdCreaPrototipo = New System.Windows.Forms.Button
        Me.cmdSezioni = New System.Windows.Forms.Button
        Me.RigrGr = New System.Windows.Forms.Button
        Me.cmdRiordina = New System.Windows.Forms.Button
        Me.cmdEdit = New System.Windows.Forms.Button
        Me.cmdIns = New System.Windows.Forms.Button
        Me.cmdCanc = New System.Windows.Forms.Button
        Me.cmdDuplica = New System.Windows.Forms.Button
        Me.cmdGrande = New System.Windows.Forms.Button
        Me.cmdZoom = New System.Windows.Forms.Button
        Me.cmdAuto = New System.Windows.Forms.Button
        Me.PictHelp = New System.Windows.Forms.PictureBox
        Me.Frame3 = New System.Windows.Forms.GroupBox
        Me.cmdPeso = New System.Windows.Forms.Button
        Me._Combo1_0 = New System.Windows.Forms.ComboBox
        Me._Combo1_1 = New System.Windows.Forms.ComboBox
        Me.txtPeso = New System.Windows.Forms.TextBox
        Me._Label2_0 = New System.Windows.Forms.Label
        Me._Label2_1 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me._Label2_2 = New System.Windows.Forms.Label
        Me.Frame2 = New System.Windows.Forms.GroupBox
        Me.Frame1 = New System.Windows.Forms.GroupBox
        Me.cmdStam = New System.Windows.Forms.Button
        Me.cmdFori = New System.Windows.Forms.Button
        Me.chkListaCompleta = New System.Windows.Forms.CheckBox
        Me.cmdCreaDaProto = New System.Windows.Forms.Button
        Me.Listj = New System.Windows.Forms.ListBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.MainMenu1 = New System.Windows.Forms.MainMenu
        Me.mnuFile = New System.Windows.Forms.MenuItem
        Me.mnuFileNew = New System.Windows.Forms.MenuItem
        Me.mnuFileOpen = New System.Windows.Forms.MenuItem
        Me.mnuFileClose = New System.Windows.Forms.MenuItem
        Me.mnuFileExit = New System.Windows.Forms.MenuItem
        Me.mnuPref = New System.Windows.Forms.MenuItem
        Me.mnuAggImm = New System.Windows.Forms.MenuItem
        Me.mnuVerboso = New System.Windows.Forms.MenuItem
        Me.mnuHelp = New System.Windows.Forms.MenuItem
        Me.mnuHelpContents = New System.Windows.Forms.MenuItem
        Me.mnuHelpBar1 = New System.Windows.Forms.MenuItem
        Me.mnuHelpAbout = New System.Windows.Forms.MenuItem
        Me.pictAssieme = New System.Windows.Forms.PictureBox
        Me.pictVirtual = New System.Windows.Forms.Panel
        Me.cmdHelpnonCB = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.ListView1 = New System.Windows.Forms.ListView
        Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader2 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader3 = New System.Windows.Forms.ColumnHeader
        Me.Frame4 = New System.Windows.Forms.GroupBox
        Me.cmdAcad = New System.Windows.Forms.Button
        Me.mnuSalva = New System.Windows.Forms.MenuItem
        Me.Frame3.SuspendLayout()
        Me.Frame2.SuspendLayout()
        Me.Frame1.SuspendLayout()
        Me.pictVirtual.SuspendLayout()
        Me.Frame4.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdCreaPrototipo
        '
        Me.cmdCreaPrototipo.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCreaPrototipo.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCreaPrototipo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCreaPrototipo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCreaPrototipo.Location = New System.Drawing.Point(87, 80)
        Me.cmdCreaPrototipo.Name = "cmdCreaPrototipo"
        Me.cmdCreaPrototipo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCreaPrototipo.Size = New System.Drawing.Size(111, 21)
        Me.cmdCreaPrototipo.TabIndex = 20
        Me.cmdCreaPrototipo.Text = "Crea Prototipo"
        Me.ToolTip1.SetToolTip(Me.cmdCreaPrototipo, "Salva le modifiche e ritorna alla maschera di gestione delle commesse")
        '
        'cmdSezioni
        '
        Me.cmdSezioni.BackColor = System.Drawing.SystemColors.Control
        Me.cmdSezioni.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdSezioni.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSezioni.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdSezioni.Location = New System.Drawing.Point(86, 38)
        Me.cmdSezioni.Name = "cmdSezioni"
        Me.cmdSezioni.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdSezioni.Size = New System.Drawing.Size(111, 21)
        Me.cmdSezioni.TabIndex = 18
        Me.cmdSezioni.Text = "Definisci sezioni"
        Me.ToolTip1.SetToolTip(Me.cmdSezioni, "Definisce le sezioni da eseguire nel disegno")
        '
        'RigrGr
        '
        Me.RigrGr.BackColor = System.Drawing.SystemColors.Control
        Me.RigrGr.Cursor = System.Windows.Forms.Cursors.Default
        Me.RigrGr.Enabled = False
        Me.RigrGr.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RigrGr.ForeColor = System.Drawing.SystemColors.ControlText
        Me.RigrGr.Location = New System.Drawing.Point(8, 16)
        Me.RigrGr.Name = "RigrGr"
        Me.RigrGr.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.RigrGr.Size = New System.Drawing.Size(73, 21)
        Me.RigrGr.TabIndex = 9
        Me.RigrGr.Text = "Grezzi"
        Me.ToolTip1.SetToolTip(Me.RigrGr, "Rigenera la lista dei materiali grezzi")
        Me.RigrGr.Visible = False
        '
        'cmdRiordina
        '
        Me.cmdRiordina.BackColor = System.Drawing.SystemColors.Control
        Me.cmdRiordina.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdRiordina.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdRiordina.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdRiordina.Location = New System.Drawing.Point(8, 38)
        Me.cmdRiordina.Name = "cmdRiordina"
        Me.cmdRiordina.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdRiordina.Size = New System.Drawing.Size(73, 21)
        Me.cmdRiordina.TabIndex = 8
        Me.cmdRiordina.Text = "Riordina"
        Me.ToolTip1.SetToolTip(Me.cmdRiordina, "Riordina la distinta per posizione a disegno")
        '
        'cmdEdit
        '
        Me.cmdEdit.Image = CType(resources.GetObject("cmdEdit.Image"), System.Drawing.Image)
        Me.cmdEdit.Location = New System.Drawing.Point(8, 16)
        Me.cmdEdit.Name = "cmdEdit"
        Me.cmdEdit.Size = New System.Drawing.Size(40, 40)
        Me.cmdEdit.TabIndex = 36
        Me.ToolTip1.SetToolTip(Me.cmdEdit, "Selezionare una posizione della lista e poi premere qui per editare.(Oppure doppi" & _
        "o click su posizione)")
        '
        'cmdIns
        '
        Me.cmdIns.Image = CType(resources.GetObject("cmdIns.Image"), System.Drawing.Image)
        Me.cmdIns.Location = New System.Drawing.Point(56, 16)
        Me.cmdIns.Name = "cmdIns"
        Me.cmdIns.Size = New System.Drawing.Size(40, 40)
        Me.cmdIns.TabIndex = 38
        Me.ToolTip1.SetToolTip(Me.cmdIns, "Premere qui per inserire una nuova membratura")
        '
        'cmdCanc
        '
        Me.cmdCanc.Image = CType(resources.GetObject("cmdCanc.Image"), System.Drawing.Image)
        Me.cmdCanc.Location = New System.Drawing.Point(104, 16)
        Me.cmdCanc.Name = "cmdCanc"
        Me.cmdCanc.Size = New System.Drawing.Size(40, 40)
        Me.cmdCanc.TabIndex = 39
        Me.ToolTip1.SetToolTip(Me.cmdCanc, "Selezionare una posizione della lista e poi premere|qui per eliminarla")
        '
        'cmdDuplica
        '
        Me.cmdDuplica.Image = CType(resources.GetObject("cmdDuplica.Image"), System.Drawing.Image)
        Me.cmdDuplica.Location = New System.Drawing.Point(152, 16)
        Me.cmdDuplica.Name = "cmdDuplica"
        Me.cmdDuplica.Size = New System.Drawing.Size(40, 40)
        Me.cmdDuplica.TabIndex = 40
        Me.ToolTip1.SetToolTip(Me.cmdDuplica, "Selezionare una posizione e premere qui per duplicarla")
        '
        'cmdGrande
        '
        Me.cmdGrande.BackColor = System.Drawing.SystemColors.Control
        Me.cmdGrande.Image = CType(resources.GetObject("cmdGrande.Image"), System.Drawing.Image)
        Me.cmdGrande.Location = New System.Drawing.Point(104, 16)
        Me.cmdGrande.Name = "cmdGrande"
        Me.cmdGrande.Size = New System.Drawing.Size(24, 24)
        Me.cmdGrande.TabIndex = 24
        Me.ToolTip1.SetToolTip(Me.cmdGrande, "Ripristina la vista completa")
        Me.cmdGrande.Visible = False
        '
        'cmdZoom
        '
        Me.cmdZoom.BackColor = System.Drawing.SystemColors.Control
        Me.cmdZoom.Image = CType(resources.GetObject("cmdZoom.Image"), System.Drawing.Image)
        Me.cmdZoom.Location = New System.Drawing.Point(72, 16)
        Me.cmdZoom.Name = "cmdZoom"
        Me.cmdZoom.Size = New System.Drawing.Size(24, 24)
        Me.cmdZoom.TabIndex = 23
        Me.ToolTip1.SetToolTip(Me.cmdZoom, "Consente di ritagliare una finestra di zoom")
        Me.cmdZoom.Visible = False
        '
        'cmdAuto
        '
        Me.cmdAuto.BackColor = System.Drawing.SystemColors.Control
        Me.cmdAuto.Image = CType(resources.GetObject("cmdAuto.Image"), System.Drawing.Image)
        Me.cmdAuto.Location = New System.Drawing.Point(40, 16)
        Me.cmdAuto.Name = "cmdAuto"
        Me.cmdAuto.Size = New System.Drawing.Size(24, 24)
        Me.cmdAuto.TabIndex = 22
        Me.ToolTip1.SetToolTip(Me.cmdAuto, "Attiva/disattiva la disegnazione automatica durante l'editing delle membrature")
        '
        'PictHelp
        '
        Me.PictHelp.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(128, Byte))
        Me.PictHelp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictHelp.Cursor = System.Windows.Forms.Cursors.Default
        Me.PictHelp.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PictHelp.ForeColor = System.Drawing.SystemColors.WindowText
        Me.PictHelp.Location = New System.Drawing.Point(256, 384)
        Me.PictHelp.Name = "PictHelp"
        Me.PictHelp.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.PictHelp.Size = New System.Drawing.Size(73, 33)
        Me.PictHelp.TabIndex = 2
        Me.PictHelp.TabStop = False
        Me.PictHelp.Visible = False
        '
        'Frame3
        '
        Me.Frame3.BackColor = System.Drawing.SystemColors.Control
        Me.Frame3.Controls.Add(Me.cmdPeso)
        Me.Frame3.Controls.Add(Me._Combo1_0)
        Me.Frame3.Controls.Add(Me._Combo1_1)
        Me.Frame3.Controls.Add(Me.txtPeso)
        Me.Frame3.Controls.Add(Me._Label2_0)
        Me.Frame3.Controls.Add(Me._Label2_1)
        Me.Frame3.Controls.Add(Me.Label3)
        Me.Frame3.Controls.Add(Me._Label2_2)
        Me.Frame3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame3.Location = New System.Drawing.Point(0, 408)
        Me.Frame3.Name = "Frame3"
        Me.Frame3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame3.Size = New System.Drawing.Size(225, 112)
        Me.Frame3.TabIndex = 21
        Me.Frame3.TabStop = False
        Me.Frame3.Text = "Dati globali"
        '
        'cmdPeso
        '
        Me.cmdPeso.Image = CType(resources.GetObject("cmdPeso.Image"), System.Drawing.Image)
        Me.cmdPeso.Location = New System.Drawing.Point(128, 56)
        Me.cmdPeso.Name = "cmdPeso"
        Me.cmdPeso.Size = New System.Drawing.Size(24, 24)
        Me.cmdPeso.TabIndex = 35
        '
        '_Combo1_0
        '
        Me._Combo1_0.BackColor = System.Drawing.SystemColors.Window
        Me._Combo1_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Combo1_0.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me._Combo1_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Combo1.Add(0, Me._Combo1_0)
        Me._Combo1_0.Location = New System.Drawing.Point(89, 16)
        Me._Combo1_0.Name = "_Combo1_0"
        Me._Combo1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Combo1_0.Size = New System.Drawing.Size(127, 22)
        Me._Combo1_0.TabIndex = 32
        '
        '_Combo1_1
        '
        Me._Combo1_1.BackColor = System.Drawing.SystemColors.Window
        Me._Combo1_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._Combo1_1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me._Combo1_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Combo1.Add(1, Me._Combo1_1)
        Me._Combo1_1.Location = New System.Drawing.Point(89, 34)
        Me._Combo1_1.Name = "_Combo1_1"
        Me._Combo1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Combo1_1.Size = New System.Drawing.Size(127, 22)
        Me._Combo1_1.TabIndex = 31
        '
        'txtPeso
        '
        Me.txtPeso.AcceptsReturn = True
        Me.txtPeso.AutoSize = False
        Me.txtPeso.BackColor = System.Drawing.SystemColors.Window
        Me.txtPeso.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPeso.Enabled = False
        Me.txtPeso.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtPeso.Location = New System.Drawing.Point(48, 56)
        Me.txtPeso.MaxLength = 0
        Me.txtPeso.Name = "txtPeso"
        Me.txtPeso.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtPeso.Size = New System.Drawing.Size(49, 18)
        Me.txtPeso.TabIndex = 23
        Me.txtPeso.Text = ""
        Me.txtPeso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        '_Label2_0
        '
        Me._Label2_0.BackColor = System.Drawing.SystemColors.Control
        Me._Label2_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Add(0, Me._Label2_0)
        Me._Label2_0.Location = New System.Drawing.Point(8, 16)
        Me._Label2_0.Name = "_Label2_0"
        Me._Label2_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_0.Size = New System.Drawing.Size(73, 19)
        Me._Label2_0.TabIndex = 34
        Me._Label2_0.Text = "Commessa"
        '
        '_Label2_1
        '
        Me._Label2_1.BackColor = System.Drawing.SystemColors.Control
        Me._Label2_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Add(1, Me._Label2_1)
        Me._Label2_1.Location = New System.Drawing.Point(8, 35)
        Me._Label2_1.Name = "_Label2_1"
        Me._Label2_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_1.Size = New System.Drawing.Size(73, 19)
        Me._Label2_1.TabIndex = 33
        Me._Label2_1.Text = "Apparecchio"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(104, 56)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(17, 17)
        Me.Label3.TabIndex = 24
        Me.Label3.Text = "kg"
        '
        '_Label2_2
        '
        Me._Label2_2.BackColor = System.Drawing.SystemColors.Control
        Me._Label2_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Add(2, Me._Label2_2)
        Me._Label2_2.Location = New System.Drawing.Point(8, 56)
        Me._Label2_2.Name = "_Label2_2"
        Me._Label2_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_2.Size = New System.Drawing.Size(41, 19)
        Me._Label2_2.TabIndex = 22
        Me._Label2_2.Text = "Peso"
        '
        'Frame2
        '
        Me.Frame2.BackColor = System.Drawing.SystemColors.Control
        Me.Frame2.Controls.Add(Me.cmdDuplica)
        Me.Frame2.Controls.Add(Me.cmdCanc)
        Me.Frame2.Controls.Add(Me.cmdIns)
        Me.Frame2.Controls.Add(Me.cmdEdit)
        Me.Frame2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame2.Location = New System.Drawing.Point(224, 408)
        Me.Frame2.Name = "Frame2"
        Me.Frame2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame2.Size = New System.Drawing.Size(305, 64)
        Me.Frame2.TabIndex = 11
        Me.Frame2.TabStop = False
        Me.Frame2.Text = "Operazioni su posizione"
        '
        'Frame1
        '
        Me.Frame1.BackColor = System.Drawing.SystemColors.Control
        Me.Frame1.Controls.Add(Me.cmdStam)
        Me.Frame1.Controls.Add(Me.cmdFori)
        Me.Frame1.Controls.Add(Me.cmdCreaPrototipo)
        Me.Frame1.Controls.Add(Me.chkListaCompleta)
        Me.Frame1.Controls.Add(Me.cmdSezioni)
        Me.Frame1.Controls.Add(Me.cmdCreaDaProto)
        Me.Frame1.Controls.Add(Me.RigrGr)
        Me.Frame1.Controls.Add(Me.cmdRiordina)
        Me.Frame1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame1.Location = New System.Drawing.Point(528, 408)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame1.Size = New System.Drawing.Size(345, 112)
        Me.Frame1.TabIndex = 7
        Me.Frame1.TabStop = False
        Me.Frame1.Text = "Operazioni globali"
        '
        'cmdStam
        '
        Me.cmdStam.Image = CType(resources.GetObject("cmdStam.Image"), System.Drawing.Image)
        Me.cmdStam.Location = New System.Drawing.Point(296, 16)
        Me.cmdStam.Name = "cmdStam"
        Me.cmdStam.Size = New System.Drawing.Size(40, 40)
        Me.cmdStam.TabIndex = 28
        '
        'cmdFori
        '
        Me.cmdFori.BackColor = System.Drawing.SystemColors.Control
        Me.cmdFori.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdFori.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdFori.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdFori.Location = New System.Drawing.Point(200, 16)
        Me.cmdFori.Name = "cmdFori"
        Me.cmdFori.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdFori.Size = New System.Drawing.Size(95, 21)
        Me.cmdFori.TabIndex = 27
        Me.cmdFori.Text = "Ricalc. fori"
        '
        'chkListaCompleta
        '
        Me.chkListaCompleta.BackColor = System.Drawing.SystemColors.Control
        Me.chkListaCompleta.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkListaCompleta.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkListaCompleta.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkListaCompleta.Location = New System.Drawing.Point(8, 60)
        Me.chkListaCompleta.Name = "chkListaCompleta"
        Me.chkListaCompleta.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkListaCompleta.Size = New System.Drawing.Size(121, 17)
        Me.chkListaCompleta.TabIndex = 19
        Me.chkListaCompleta.Text = "Lista completa"
        '
        'cmdCreaDaProto
        '
        Me.cmdCreaDaProto.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCreaDaProto.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCreaDaProto.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCreaDaProto.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCreaDaProto.Location = New System.Drawing.Point(86, 16)
        Me.cmdCreaDaProto.Name = "cmdCreaDaProto"
        Me.cmdCreaDaProto.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCreaDaProto.Size = New System.Drawing.Size(111, 21)
        Me.cmdCreaDaProto.TabIndex = 10
        Me.cmdCreaDaProto.Text = "Crea da Prototipo"
        '
        'Listj
        '
        Me.Listj.BackColor = System.Drawing.SystemColors.Window
        Me.Listj.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Listj.Cursor = System.Windows.Forms.Cursors.Default
        Me.Listj.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Listj.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Listj.ItemHeight = 14
        Me.Listj.Location = New System.Drawing.Point(290, 0)
        Me.Listj.Name = "Listj"
        Me.Listj.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Listj.Size = New System.Drawing.Size(31, 128)
        Me.Listj.TabIndex = 1
        Me.Listj.Visible = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Window
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label1.Location = New System.Drawing.Point(24, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(141, 91)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Distinta vuota"
        Me.Label1.Visible = False
        '
        'Combo1
        '
        '
        'MainMenu1
        '
        Me.MainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuFile, Me.mnuPref, Me.mnuHelp})
        '
        'mnuFile
        '
        Me.mnuFile.Index = 0
        Me.mnuFile.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuFileNew, Me.mnuFileOpen, Me.mnuSalva, Me.mnuFileClose, Me.mnuFileExit})
        Me.mnuFile.Text = "&File"
        '
        'mnuFileNew
        '
        Me.mnuFileNew.Enabled = False
        Me.mnuFileNew.Index = 0
        Me.mnuFileNew.Shortcut = System.Windows.Forms.Shortcut.CtrlN
        Me.mnuFileNew.Text = "Nu&ovo"
        '
        'mnuFileOpen
        '
        Me.mnuFileOpen.Enabled = False
        Me.mnuFileOpen.Index = 1
        Me.mnuFileOpen.Shortcut = System.Windows.Forms.Shortcut.CtrlO
        Me.mnuFileOpen.Text = "&Apri"
        '
        'mnuFileClose
        '
        Me.mnuFileClose.Enabled = False
        Me.mnuFileClose.Index = 3
        Me.mnuFileClose.Text = "C&hiudi"
        '
        'mnuFileExit
        '
        Me.mnuFileExit.Index = 4
        Me.mnuFileExit.Text = "Es&ci"
        '
        'mnuPref
        '
        Me.mnuPref.Index = 1
        Me.mnuPref.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuAggImm, Me.mnuVerboso})
        Me.mnuPref.Text = "&Preferenze"
        '
        'mnuAggImm
        '
        Me.mnuAggImm.Index = 0
        Me.mnuAggImm.Text = "Aggiornamento immediato"
        '
        'mnuVerboso
        '
        Me.mnuVerboso.Index = 1
        Me.mnuVerboso.Text = "Esecuzione verbosa"
        '
        'mnuHelp
        '
        Me.mnuHelp.Index = 2
        Me.mnuHelp.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuHelpContents, Me.mnuHelpBar1, Me.mnuHelpAbout})
        Me.mnuHelp.Text = "&?"
        '
        'mnuHelpContents
        '
        Me.mnuHelpContents.Index = 0
        Me.mnuHelpContents.Text = "&Sommario"
        '
        'mnuHelpBar1
        '
        Me.mnuHelpBar1.Index = 1
        Me.mnuHelpBar1.Text = "-"
        '
        'mnuHelpAbout
        '
        Me.mnuHelpAbout.Index = 2
        Me.mnuHelpAbout.Text = "&Informazioni su MyApp..."
        '
        'pictAssieme
        '
        Me.pictAssieme.BackColor = System.Drawing.SystemColors.Window
        Me.pictAssieme.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pictAssieme.Location = New System.Drawing.Point(392, 8)
        Me.pictAssieme.Name = "pictAssieme"
        Me.pictAssieme.Size = New System.Drawing.Size(480, 392)
        Me.pictAssieme.TabIndex = 27
        Me.pictAssieme.TabStop = False
        '
        'pictVirtual
        '
        Me.pictVirtual.Controls.Add(Me.cmdHelpnonCB)
        Me.pictVirtual.Controls.Add(Me.Label4)
        Me.pictVirtual.Location = New System.Drawing.Point(408, 56)
        Me.pictVirtual.Name = "pictVirtual"
        Me.pictVirtual.Size = New System.Drawing.Size(440, 320)
        Me.pictVirtual.TabIndex = 31
        '
        'cmdHelpnonCB
        '
        Me.cmdHelpnonCB.BackColor = System.Drawing.SystemColors.Control
        Me.cmdHelpnonCB.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdHelpnonCB.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdHelpnonCB.Location = New System.Drawing.Point(264, 256)
        Me.cmdHelpnonCB.Name = "cmdHelpnonCB"
        Me.cmdHelpnonCB.Size = New System.Drawing.Size(96, 32)
        Me.cmdHelpnonCB.TabIndex = 32
        Me.cmdHelpnonCB.Text = "Help"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Red
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(32, 96)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(377, 129)
        Me.Label4.TabIndex = 31
        Me.Label4.Text = "Questa area è normalmente destinata a contenere il disegno dell'apparecchio. Essa" & _
        " è però vuota quando la distinta dell'apparecchio non prevede il calcolo delle p" & _
        "osizioni relative delle membrature."
        '
        'ListView1
        '
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3})
        Me.ListView1.FullRowSelect = True
        Me.ListView1.Location = New System.Drawing.Point(0, 0)
        Me.ListView1.MultiSelect = False
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(384, 400)
        Me.ListView1.TabIndex = 32
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Pos"
        Me.ColumnHeader1.Width = 40
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Descrizione"
        Me.ColumnHeader2.Width = 220
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Materiale"
        Me.ColumnHeader3.Width = 120
        '
        'Frame4
        '
        Me.Frame4.BackColor = System.Drawing.SystemColors.Control
        Me.Frame4.Controls.Add(Me.cmdGrande)
        Me.Frame4.Controls.Add(Me.cmdZoom)
        Me.Frame4.Controls.Add(Me.cmdAuto)
        Me.Frame4.Controls.Add(Me.cmdAcad)
        Me.Frame4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame4.Location = New System.Drawing.Point(224, 472)
        Me.Frame4.Name = "Frame4"
        Me.Frame4.Size = New System.Drawing.Size(304, 48)
        Me.Frame4.TabIndex = 42
        Me.Frame4.TabStop = False
        Me.Frame4.Text = "Operazioni sul disegno"
        '
        'cmdAcad
        '
        Me.cmdAcad.BackColor = System.Drawing.SystemColors.Control
        Me.cmdAcad.Image = CType(resources.GetObject("cmdAcad.Image"), System.Drawing.Image)
        Me.cmdAcad.Location = New System.Drawing.Point(8, 16)
        Me.cmdAcad.Name = "cmdAcad"
        Me.cmdAcad.Size = New System.Drawing.Size(24, 24)
        Me.cmdAcad.TabIndex = 21
        '
        'mnuSalva
        '
        Me.mnuSalva.Index = 2
        Me.mnuSalva.Text = "Salva"
        '
        'frmDistinta
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 12)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(873, 523)
        Me.Controls.Add(Me.Frame4)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.pictAssieme)
        Me.Controls.Add(Me.pictVirtual)
        Me.Controls.Add(Me.Frame1)
        Me.Controls.Add(Me.PictHelp)
        Me.Controls.Add(Me.Frame3)
        Me.Controls.Add(Me.Frame2)
        Me.Controls.Add(Me.Listj)
        Me.Controls.Add(Me.Label1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 7.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.SystemColors.WindowText
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.HelpButton = True
        Me.Location = New System.Drawing.Point(2, 39)
        Me.MaximizeBox = False
        Me.Menu = Me.MainMenu1
        Me.MinimizeBox = False
        Me.Name = "frmDistinta"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Distinta"
        Me.Frame3.ResumeLayout(False)
        Me.Frame2.ResumeLayout(False)
        Me.Frame1.ResumeLayout(False)
        For Each control In Combo1.Values
            AddHandler control.TextChanged, AddressOf Combo1_TextChanged
        Next

        Me.pictVirtual.ResumeLayout(False)
        Me.Frame4.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
#End Region 
#Region "Supporto aggiornamento "
	Private Shared m_vb6FormDefInstance As frmDistinta
	Private Shared m_InitializingDefInstance As Boolean
	Public Shared Property DefInstance() As frmDistinta
		Get
			If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
				m_InitializingDefInstance = True
				m_vb6FormDefInstance = New frmDistinta()
				m_InitializingDefInstance = False
			End If
			DefInstance = m_vb6FormDefInstance
		End Get
		Set
			m_vb6FormDefInstance = Value
		End Set
	End Property
#End Region
    Private PySezMin, PySezMax As Single
    Private xAsse As Single
    Private Attivandosi As Boolean
    Private Inizializzando As Boolean
    Private pictHeight, pictWidth As Single
    Private pictHeight1, pictWidth1 As Single
    Private pictHsave, pictWsave As Single
    Private pictTop, pictLeft As Single
    Private xTop, yTop As Single
    Private xBot, yBot As Single
    Private fr2L, fr1L, fr3L, fr4L As Single
    Private frT, fr4T, FormHeight As Single
    Private Zooming As Boolean
    Private Autom, Grande As Boolean
    Private Sub cmdCreaDaProto_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCreaDaProto.Click
        Dim FileProto, Radix As String
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        Apparecchio.ScaricaApparecchio()
        Apparecchio.Delete()
        Funzioni.iAPRn.Close()
        Radix = RTrim(Monitor.Motore.Inizio.Archdir) & "\PROTO\" & ProtoTyp
        FileProto = Radix & "\000.APR"
        FileCopy(FileProto, FileAPR)
        Funzioni.iAPRn = New FileStream(FileAPR, FileMode.Open)
        GeneraApparecchio()
        AggLista()
        Funzioni.DisGeneral()
        Try
            FileCopy(Radix & "\000.INP", FunzLibgra.FileDes("INP"))
            FileCopy(Radix & "\000.ADU", FunzLibgra.FileDes("ADU"))
            FileCopy(Radix & "\000.TRK", FunzLibgra.FileDes("TRK"))
            FileCopy(Radix & "\000.DES", FunzLibgra.FileDes("DES"))
            FileCopy(Radix & "\000.WMF", FunzLibgra.FileDes("WMF"))
        Catch e As Exception
        End Try
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub cmdFori_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdFori.Click
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        TogliFS()
        AggLista()
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
    End Sub
    Private Sub cmdHelpNonCB_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Monitor.Motore.RetrHelp(RadiceHelp, Me, "", "FinestraIniziale.htm#NoDisegno")
    End Sub
    Public Sub mnuAggImm_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuAggImm.Popup
        mnuAggImm_Click(eventSender, eventArgs)
    End Sub
    Public Sub mnuAggImm_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuAggImm.Click
        mnuAggImm.Checked = Not mnuAggImm.Checked
        AggiornamentoAutomatico = mnuAggImm.Checked
    End Sub
    Public Sub mnuHelpAbout_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuHelpAbout.Popup
        mnuHelpAbout_Click(eventSender, eventArgs)
    End Sub
    Public Sub mnuHelpAbout_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuHelpAbout.Click
        MsgBox("Inserire il codice per la finestra informazioni su...")
        '  frmAbout.Show vbModal
    End Sub
    Public Sub mnuHelpContents_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuHelpContents.Popup
        mnuHelpContents_Click(eventSender, eventArgs)
    End Sub
    Public Sub mnuHelpContents_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuHelpContents.Click
        Help.ShowHelpIndex(Me, RadiceHelp)
    End Sub
    Public Sub mnuFileClose_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuFileClose.Popup
        mnuFileClose_Click(eventSender, eventArgs)
    End Sub
    Public Sub mnuFileClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuFileClose.Click
        MsgBox("Inserire il codice per il menu Chiudi.")
    End Sub
    Public Sub mnuFileExit_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuFileExit.Popup
        mnuFileExit_Click(eventSender, eventArgs)
    End Sub
    Public Sub mnuFileExit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuFileExit.Click
        Me.Close() 'frmDistinta
    End Sub

    Public Sub mnuFileNew_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuFileNew.Popup
        mnuFileNew_Click(eventSender, eventArgs)
    End Sub
    Public Sub mnuFileNew_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuFileNew.Click
        MsgBox("Inserire il codice per il menu Nuovo.")
    End Sub

    Public Sub mnuFileOpen_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuFileOpen.Popup
        mnuFileOpen_Click(eventSender, eventArgs)
    End Sub
    Public Sub mnuFileOpen_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuFileOpen.Click
        MsgBox("Inserire il codice per il menu Apri.")
    End Sub
    Private Sub DrawPos(ByRef Ind As Membratura, ByRef x As Single, ByRef y As Single)
        Dim Testo As String
        Dim GenMem As clsGenMem
        If Ind Is Nothing Then
            PictHelp.Visible = False
            Exit Sub
        End If
        GenMem = Ind.GenMem
        Testo = Str(GenMem.PosDis) & " " & RTrim(GenMem.Denom)
        Testo = Testo & "|" & "x=" & Microsoft.VisualBasic.Strings.Format(GenMem.posizione.Origine.X, "#####.0")
        Testo = Testo & "|" & "y=" & Microsoft.VisualBasic.Strings.Format(GenMem.posizione.Origine.y, "#####.0")
        Testo = Testo & "|" & "z=" & Microsoft.VisualBasic.Strings.Format(GenMem.posizione.Origine.Z, "#####.0")
        Funzioni.DisRut.DisplayHelp(PictHelp, pictAssieme, Testo, x, y, False)
    End Sub
    Private Sub chkListaCompleta_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkListaCompleta.CheckStateChanged
        AggLista()
    End Sub
    Private Sub cmdCreaPrototipo_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCreaPrototipo.Click
        If Len(ProtoTyp) > 0 Then
            'If MsgBox("Esiste già un prototipo per questo apparecchio. Vuoi procedere comunque?", vbQuestion + vbYesNo, "PPSM") = vbNo Then Exit Sub
            If MostraAiuto(IDHG.IDH_PROTO_ESISTEGIA, ChiaviMess.MessQuestion + ChiaviMess.MessYesNo) = ChiaviMess.Messno Then Exit Sub
        End If
        Funzioni.CreaProtoTyp = True
        Me.Close() 'frmDistinta
    End Sub
    Private Sub cmdRiordina_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdRiordina.Click
        Riordina()
    End Sub
    Private Sub cmdSezioni_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdSezioni.Click
        CercaY(PySezMin, PySezMax, 1)
        EditSezioni1(0)
    End Sub
    Private Sub CercaY(ByRef ySezMin As Single, ByRef ySezMax As Single, ByRef isez As Short)
        Dim s As spot
        Dim g As clsGenMem
        Dim O As Membratura
        Dim i, ii As Short
        Dim x, yMaxAct, yMinAct As Single
        ySezMax = -clsTrigon.Infinito
        ySezMin = clsTrigon.Infinito
        Try
            For i = 0 To Apparecchio.Elementi.Count - 1
                O = Apparecchio.Elementi(i)
                g = O.GenMem
                For ii = 1 To g.Segnalini.Count()
                    s = g.Segnalini(ii - 1)
                    If s.Sezione = isez Then
                        Select Case s.Tipo
                            Case 1
                                yMaxAct = s.Quadro.TopLeft.y : yMinAct = s.Quadro.Botrigt.y
                            Case 2
                                yMaxAct = s.spicchio.Origin.y + s.spicchio.RG * _
                       GlobalRoutines.Minimo(Math.Sin(GlobalRoutines.arco( _
                                             s.spicchio.Direct.X, s.spicchio.Direct.y)), _
                                             Math.Sin(GlobalRoutines.arco( _
                                             s.spicchio.Direct.X, s.spicchio.Direct.y) + s.spicchio.Alfa / 2), _
                                             Math.Sin(GlobalRoutines.arco( _
                                             s.spicchio.Direct.X, s.spicchio.Direct.y) - s.spicchio.Alfa / 2))
                                yMinAct = s.spicchio.Origin.y + s.spicchio.RG * _
                       GlobalRoutines.Massimo(Math.Sin(GlobalRoutines.arco( _
                                            s.spicchio.Direct.X, s.spicchio.Direct.y)), _
                                            Math.Sin(GlobalRoutines.arco( _
                                            s.spicchio.Direct.X, s.spicchio.Direct.y) + s.spicchio.Alfa / 2), _
                                            Math.Sin(GlobalRoutines.arco( _
                                            s.spicchio.Direct.X, s.spicchio.Direct.y) - s.spicchio.Alfa / 2))
                        End Select
                        If yMaxAct < yMinAct Then GlobalRoutines.SWAP(yMaxAct, yMinAct)
                        If yMaxAct > ySezMax Then ySezMax = yMaxAct
                        If yMinAct < ySezMin Then ySezMin = yMinAct
                    End If
                Next ii
            Next i
            If ySezMax = -clsTrigon.Infinito Then
                ySezMax = 0
                Funzioni.DisRut.MouseToWorld(x, ySezMax)
            End If
            If ySezMin = clsTrigon.Infinito Then
                ySezMin = Me.pictAssieme.ClientRectangle.Height
                Funzioni.DisRut.MouseToWorld(x, ySezMin)
            End If
            Funzioni.DisRut.WorldToMouse(x, ySezMin)
            Funzioni.DisRut.WorldToMouse(x, ySezMax)
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Private Sub Combo1_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Dim Index As Short = IndexedControls.IndexOf(Combo1, eventSender)
        Dim i As Short
        If Not Combo1(Index).Enabled Then Exit Sub
        Apparecchio.ScaricaApparecchio()
        Apparecchio.Delete()
        Funzioni.iAPRn.Close() : Funzioni.iAPRn = Nothing
        Select Case Index
            Case 0
                job.RetrieveCom(Index + 1)
                Combo1(1).Items.Clear()
                For i = 1 To job.Comm.Ind.Count
                    Combo1(1).Items.Add(Trim(job.Comm.Ind.Item(i).Data.Assieme) & "/" & Trim(job.Comm.Ind.Item(i).Data.File))
                Next
                Combo1(1).SelectedIndex = 0
            Case 1
                job.Comm.indice = Index + 1
        End Select
        FileAPR = FunzLibgra.FileDes("APR") ' Trim(Inizio.Workdir) + "\" + job.Comm.Arch + "\" + job.Comm.Ind(job.Comm.indice).File + ".APR"
        Funzioni.iAPRn = New FileStream(FileAPR, FileMode.OpenOrCreate)
        GeneraApparecchio()
        AggLista()
    End Sub
    Private Sub frmDistinta_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
        If NonDisegnare Then Exit Sub
        If Not Autom Then Exit Sub
        If Not Funzioni.OKfrmDati Then Exit Sub
        If Attivandosi Then Exit Sub
        Attivandosi = True
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        Funzioni.DisRut.DoveDisegno = pictAssieme
        Funzioni.DisRut.SH = 0
        Funzioni.DisGeneral()
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        Attivandosi = False
    End Sub
    Private Sub Inizializza()
        Dim i As Short
        LeggiPref()
        pictAssieme.Visible = True
        pictVirtual.Visible = False
        If Not job.Comm Is Nothing Then
            If Not job.Comm.CalcBaric Then
                cmdCreaDaProto.Enabled = False
                cmdSezioni.Enabled = False
                cmdFori.Enabled = False
                cmdCreaPrototipo.Enabled = False
                pictAssieme.Visible = False
                pictVirtual.Visible = True
            End If
        End If
        pictHeight = pictAssieme.ClientRectangle.Height
        pictWidth = pictAssieme.ClientRectangle.Width
        pictHeight1 = pictAssieme.Height
        pictWidth1 = pictAssieme.Width
        pictTop = pictAssieme.Top
        pictLeft = pictAssieme.Left
        fr1L = Frame1.Left
        fr2L = Frame2.Left
        fr3L = Frame3.Left
        fr4L = Frame4.Left
        frT = Frame3.Top
        fr4T = Frame4.Top
        FormHeight = ClientRectangle.Height
        AggLista()
        For i = 1 To job.Coll.Count
            Combo1(0).Items.Add(Trim(job.Coll.Item(i).TextData))
        Next
        For i = 1 To job.Comm.Ind.Count
            Combo1(1).Items.Add(Trim(job.Comm.Ind.Item(i).Data.Assieme) & "/" & Trim(job.Comm.Ind.Item(i).Data.File))
        Next
        Combo1(0).Enabled = False
        Combo1(1).Enabled = False
        For i = 0 To job.Coll.Count - 1
            If Combo1(0).Items(i) = job.Comm.Arch.Trim Then
                Combo1(0).SelectedIndex = i
            End If
        Next
        For i = 0 To job.Comm.Ind.Count - 1
            If InStr(Combo1(1).Items(i), job.Comm.Ind.Item(job.Comm.indice).Data.Assieme.Trim) > 0 Then
                Combo1(1).SelectedIndex = i
            End If
        Next
        Combo1(0).Enabled = True
        Combo1(1).Enabled = True
        cmdCreaDaProto.Enabled = Len(ProtoTyp) > 0
    End Sub
    Private Sub frmDistinta_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseMove
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim x As Single = eventArgs.X
        Dim y As Single = eventArgs.Y
        PictHelp.Visible = False
    End Sub
    Private Sub frmDistinta_Closed(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Closed
        Distinta = False
        ScriviPref()
    End Sub

    Public Sub mnuVerboso_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuVerboso.Popup
        mnuVerboso_Click(eventSender, eventArgs)
    End Sub
    Public Sub mnuVerboso_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuVerboso.Click
        With mnuVerboso
            .Checked = Not .Checked
            Verboso = .Checked
        End With
    End Sub
    Private Sub pictAssieme_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles pictAssieme.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim x As Single = eventArgs.X
        Dim y As Single = eventArgs.Y
        If EditingSezioni Then
            EditSezioni1(xAsse)
        ElseIf Zooming Then
            xTop = x
            yTop = y
            xBot = x
            yBot = y
        End If
    End Sub
    Private Sub MostraSezioni(ByRef X As Single, ByRef Y As Single)
        If SecondaVolta Then Nascondi(xAsse)
        SecondaVolta = True
        Nascondi(X)
        xAsse = X
    End Sub
    Private Sub Nascondi(ByVal X As Single)
        Dim Pstart As Point = New Point(X, PySezMax)
        Dim Pend As Point = New Point(X, PySezMin)
        Pend = pictAssieme.PointToScreen(Pend)
        Pstart = pictAssieme.PointToScreen(Pstart)
        ControlPaint.DrawReversibleLine(Pstart, Pend, Color.White)
    End Sub
    Private Sub pictAssieme_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles pictAssieme.MouseMove
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim x As Single = eventArgs.X
        Dim y As Single = eventArgs.Y
        Dim i As Membratura
        Try
            If EditingSezioni Then
                MostraSezioni(x, y)
            ElseIf Button = 1 And Zooming Then '1 sinistro,2 destro, 4 centro, 0 nessuno
                Dim r As New Rectangle(xTop, yTop, xBot - xTop, yBot - yTop)
                r = pictAssieme.RectangleToScreen(r)
                ControlPaint.DrawReversibleFrame(r, Color.White, FrameStyle.Dashed)
                xBot = x : yBot = y
                r = New Rectangle(xTop, yTop, xBot - xTop, yBot - yTop)
                r = pictAssieme.RectangleToScreen(r)
                ControlPaint.DrawReversibleFrame(r, Color.White, FrameStyle.Dashed)
            Else
                If Not Autom Then Exit Sub
                Funzioni.DisRut.MouseToWorld(x, y)
                i = CercaPos(x, y)
                DrawPos(i, x, y)
            End If
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Private Sub pictAssieme_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles pictAssieme.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim x As Single = eventArgs.X
        Dim y As Single = eventArgs.Y
        If Zooming Then
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
            Dim b As SolidBrush = New SolidBrush(Color.FromArgb(200, 255, 255)) 'colorino di sfondo dello zoom
            If xBot < xTop Then GlobalRoutines.SWAP(xBot, xTop)
            If yBot < yTop Then GlobalRoutines.SWAP(yBot, yTop)
            With Funzioni.DisRut
                .MouseToWorld(xTop, yTop)
                .MouseToWorld(xBot, yBot)
                If Not .Scala(xTop, xBot, yBot, yTop) Then Exit Sub
                .PennaFill = b
                .quadrato(xTop, yBot, xBot, yTop, 0, 0, True)
                .quadrato(xTop, yBot, xBot, yTop, 0, 0, False)
            End With
            Editing = True
            Disegno(2, 1, Apparecchio)
            Editing = False
            pictAssieme.Refresh()
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        End If
    End Sub
    Private Sub RigrGr_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles RigrGr.Click
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        RigrGrezzi()
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
    End Sub
    Public Sub AggLista()
        Dim j As Short
        Dim l As ListViewItem
        Listj.Items.Clear()
        ListView1.Items.Clear()
        Try
            If Apparecchio Is Nothing Then
                NoDistinta()
            ElseIf Apparecchio.Elementi.Count() < 2 Then
                NoDistinta()
            Else
                SiDistinta()
                'Listj.Items.Add("0")
                For j = 1 To Apparecchio.Elementi.Count()
                    With CType(Apparecchio.Elementi(j - 1).GenMem, clsGenMem)
                        If chkListaCompleta.CheckState = 1 Then
                            l = ListView1.Items.Add(GlobalRoutines.myStr(.PosDis, 3, 0, True))
                            l.SubItems.Add(CStr(.Denom).Trim)
                            l.SubItems.Add(CStr(.Materiale).Trim)
                            Listj.Items.Add(Str(j))
                        Else
                            Select Case .Tipo
                                Case 0, -96, -15
                                    l = Nothing
                                Case -31, -32, -33, 25, -38 '(Raggruppamenti fascio)
                                    l = ListView1.Items.Add(GlobalRoutines.myStr(.PosDis, 3, 0, True))
                                    l.SubItems.Add(CStr(.Denom).Trim)
                                    l.SubItems.Add(CStr(.Materiale).Trim)
                                    Listj.Items.Add(Str(j))
                                    j = j + .Appesi.Count
                                Case Else
                                    l = ListView1.Items.Add(GlobalRoutines.myStr(.PosDis, 3, 0, True))
                                    l.SubItems.Add(CStr(.Denom).Trim)
                                    l.SubItems.Add(CStr(.Materiale).Trim)
                                    Listj.Items.Add(Str(j - 1))
                            End Select
                            If .Tipo < 0 And Not l Is Nothing Then l.ForeColor = System.Drawing.Color.Red
                        End If
                    End With
                Next
                If ListView1.Items.Count = 0 Then
                    NoDistinta()
                End If
            End If
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Private Sub NoDistinta()
        ListView1.Visible = False
        Label1.Visible = True
    End Sub
    Private Sub SiDistinta()
        ListView1.Visible = True
        Label1.Visible = False
    End Sub
    Public Sub Riordina()
        Dim j, k As Short
        Dim m As Membratura
        Dim keyk As String
        Dim keyj As String
        Dim n As Membratura
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
Rif:
        For j = 1 To Apparecchio.Elementi.Count()
            For k = j + 1 To Apparecchio.Elementi.Count()
                If Apparecchio.Elementi(j - 1).GenMem.PosDis > Apparecchio.Elementi(k - 1).GenMem.PosDis And _
                   Apparecchio.Elementi(j - 1).GenMem.Tipo > 0 And Apparecchio.Elementi(k - 1).GenMem.Tipo > 0 Then
                    m = Apparecchio.Elementi(j - 1)
                    n = Apparecchio.Elementi(k - 1)
                    keyk = n.GenMem.Denom
                    keyj = m.GenMem.Denom
                    Apparecchio.Elementi.remove(keyk) ' j
                    Apparecchio.Elementi.Add(n, keyk, keyj) ' k - 1    '+ 1
                    Do
                        k = k + 1
                        If k - 1 > Apparecchio.Elementi.Count() Then Exit Do
                        n = Apparecchio.Elementi(k - 1)
                        If n.GenMem.Tipo > 0 Then Exit Do
                        keyk = n.GenMem.Denom
                        Apparecchio.Elementi.remove(keyk) ' j
                        Apparecchio.Elementi.Add(n, keyk, keyj) ' k - 1    '+ 1
                    Loop
                    GoTo Rif
                End If
            Next
        Next
        AggLista()
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
    End Sub
    Public Sub RigrGrezzi()
        '  Dim g As clsGrezzo1, i As Integer
        '  apparecchio.ClearGrezzi
        '  For i = 2 To apparecchio.Elementi.Count
        '     apparecchio.Elementi(i).CalcGrezzi
        '     For Each g In apparecchio.Elementi(i).GenMem.grezzi
        '         apparecchio.grezzi.Add g
        '     Next
        '  Next
    End Sub
    Private Sub LeggiPref()
        With Monitor.Motore.Inizio
            AggiornamentoAutomatico = (.ReadIniFile("", SezPref, "AggiornamentoAutomatico") = "Si")
            mnuAggImm.Checked = AggiornamentoAutomatico
            Verboso = (.ReadIniFile("", SezPref, "Verboso") = "Si")
            mnuVerboso.Checked = Verboso
        End With
    End Sub
    Private Sub AbilitBot(ByRef b As Boolean)
        Frame1.Enabled = b
        Frame2.Enabled = b
        Frame3.Enabled = b
    End Sub
    Private Sub ListView1_AfterLabelEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.LabelEditEventArgs) Handles ListView1.AfterLabelEdit
        Dim Ind As Short
        Ind = Val(Listj.Items(ListView1.SelectedItems(0).Index))
        Apparecchio.Elementi(Ind + 1).GenMem.PosDis = Val(e.Label)
    End Sub
    Private Sub ListView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.DoubleClick
        cmdEdit_Click(Me, New System.EventArgs)   '4-3-99
    End Sub
    Private Sub cmdPeso_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdPeso.Click
        Apparecchio.BaricGen()
        txtPeso.Text = GlobalRoutines.FormatS("######", Apparecchio.peso)
    End Sub
    Private Sub cmdEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdEdit.Click
        Dim iRes, Ind As Short
        Dim CAD As Boolean
        Dim l As ListViewItem
        NonDisegnare = True
        Zooming = False
        CAD = DisAcad
        DisAcad = False
        PictHelp.Visible = False
        NonDisegnare = False
        If ListView1.SelectedItems.Count = 0 Then
            GlobalRoutines.PlaySoundFile(Monitor.Motore.Inizio.Archdir + "\Errore.WAV")
            MostraAiuto(IDHG.IDH_ERR_NOITEMSELECTED)
        Else
            l = ListView1.SelectedItems(0)
            Ind = Val(Listj.Items(l.Index))
            If Ind > -1 Then
                Editing = True
                iRes = EditaPos(Apparecchio.Elementi(Ind))
                Editing = False
                AggLista()
                'ListView1.Items(l.Key).selected = True
                'ListView1.SelectedItem.EnsureVisible()
                l.EnsureVisible()
                ' If cmdAuto Then Funzioni.DisGeneral
            Else
                GlobalRoutines.PlaySoundFile(Monitor.Motore.Inizio.Archdir + "\Errore.WAV")
            End If
        End If
        DisAcad = CAD
        Apparecchio.Salvato = False
    End Sub

    Private Sub cmdIns_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdIns.Click
        Dim iRes As Short
        Dim CAD As Boolean
        PictHelp.Visible = False
        CAD = DisAcad
        DisAcad = False
        iRes = Funzioni.NuovaPosN
        '     If iRes = 1 Then Exit Sub
        AggLista()
        DisAcad = CAD
        Apparecchio.Salvato = False
    End Sub

    Private Sub cmdCanc_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCanc.Click
        Dim Ind As Short
        Dim l As Short
        Dim Index As Short
        PictHelp.Visible = False
        'Ind = Val(Listj.List(Grid1.Row)) 'Grid1.Row
        l = ListView1.SelectedIndices(0)
        Ind = Val(Listj.Items(l)) 'Grid1.Row
        If Ind > 0 Then
            Index = l - 1
            If Index < 0 Then Index = 0
            CancPosN(Ind)
            AggLista()
            ListView1.Items(Index).Selected = True
            ListView1.Items(Index).EnsureVisible()
            If Autom Then Funzioni.DisGeneral()
        Else
            GlobalRoutines.PlaySoundFile(Monitor.Motore.Inizio.Archdir + "\Errore.WAV")
        End If
        Apparecchio.Salvato = False
    End Sub
    Private Sub cmdDuplica_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdDuplica.Click
        Dim iRes, Ind As Short
        Dim NuovInd As Short
        Dim CAD As Boolean
        CAD = DisAcad
        DisAcad = False
        NonDisegnare = True
        Zooming = False
        PictHelp.Visible = False
        NonDisegnare = False
        'Ind = Val(Listj.List(Grid1.Row))
        Ind = Val(Listj.Items(ListView1.SelectedIndices(0)))
        If Ind > 0 Then
            Editing = True
            Duplicando = True
            NuovInd = DuplicaPos(Apparecchio.Elementi(Ind))
            Duplicando = False
            iRes = EditaPos(Apparecchio.Elementi(NuovInd))
            Editing = False
            AggLista()
            'If cmdAuto Then Funzioni.DisGeneral
        Else
            GlobalRoutines.PlaySoundFile(Monitor.Motore.Inizio.Archdir + "\Errore.WAV")
        End If
        DisAcad = CAD
    End Sub
    Private Sub cmdStam_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdStam.Click
        StampaDistinta()
    End Sub
    Friend Sub cmdAcad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAcad.Click
        DisAcad = Not DisAcad
        If Not DisAcad Then
            Funzioni.DisRut.ChiudiPRI()
            Monitor.AcadDis = Nothing
        End If
    End Sub
    Private Sub cmdAuto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAuto.Click
        If Not cmdAuto.Enabled Then Exit Sub
        Autom = Not Autom
        If Autom Then
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
            Funzioni.DisRut.DoveDisegno = pictAssieme
            Funzioni.DisRut.SH = 0
            Funzioni.DisGeneral()
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        End If
        cmdZoom.Visible = Autom
        cmdGrande.Visible = Autom
    End Sub
    Private Sub cmdGrande_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGrande.Click
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        Grande = Not Grande
        If Grande Then
            WindowState = FormWindowState.Maximized
            pictAssieme.Top = 0 : pictAssieme.Left = 0
            pictAssieme.Width = ClientRectangle.Width
            pictAssieme.Height = ClientRectangle.Height - Frame1.Height
            pictWsave = pictWidth : pictHsave = pictHeight
            pictWidth = pictAssieme.ClientRectangle.Width
            pictHeight = pictAssieme.ClientRectangle.Height
            ListView1.Visible = False
            Autom = True
            cmdAuto.Visible = False
            ToolTip1.SetToolTip(cmdGrande, "Premere per rimpicciolire il riquadro del disegno")
            Frame1.Top = pictAssieme.Height
            Frame2.Top = Frame1.Top
            Frame3.Top = Frame1.Top
            Frame4.Top = Frame2.Top + Frame2.Height
        Else
            WindowState = FormWindowState.Normal
            pictWidth = pictWsave : pictHeight = pictHsave
            pictAssieme.Top = pictTop : pictAssieme.Left = pictLeft
            pictAssieme.Width = pictWidth1
            pictAssieme.Height = pictHeight1
            ListView1.Visible = True
            cmdAuto.Visible = True
            ToolTip1.SetToolTip(cmdGrande, "Per ingrandire il riquadro del disegno")
            Frame1.Top = frT
            Frame2.Top = frT
            Frame3.Top = frT
            Frame1.Left = fr1L
            Frame2.Left = fr2L
            Frame3.Left = fr3L
            Frame4.Top = fr4T
            Frame4.Left = fr4L
        End If
        Funzioni.DisRut.DoveDisegno = pictAssieme
        Funzioni.DisRut.SH = 0
        Funzioni.DisRut.SW = 0
        Funzioni.DisGeneral()
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
    End Sub
    Private Sub cmdZoom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdZoom.Click
        Dim Testo As String
        Zooming = Not Zooming
        If Zooming Then
            PictHelp.Visible = False
            ToolTip1.SetToolTip(cmdZoom, "Premere per smettere di zoomare")
            cmdGrande.Visible = False
            Autom = True
        Else
            cmdGrande.Visible = True
            Testo = "Premere qui per zoommare, poi "
            Testo = Testo & "ritagliare una finestra sul disegno"
            ToolTip1.SetToolTip(cmdZoom, Testo)
            If Not NonDisegnare Then
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
                Funzioni.DisGeneral()
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            End If
        End If
        AbilitBot(Not Zooming)
    End Sub
    Private Sub mnuSalva_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSalva.Click
        Apparecchio.ScaricaApparecchio(False)
    End Sub
End Class