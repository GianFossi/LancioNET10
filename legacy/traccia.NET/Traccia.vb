Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports System.Drawing
Friend Class frmTraccia
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
    Public WithEvents cmdElim As System.Windows.Forms.Button
    Public WithEvents _Pagina_7 As AxThreed.AxSSRibbon
	Public WithEvents cmdFull As AxThreed.AxSSCommand
	Public WithEvents StatusBar1 As AxMSComctlLib.AxStatusBar
	Public WithEvents _cmdTraccia_4 As System.Windows.Forms.Button
    Public WithEvents pctRisult As System.Windows.Forms.Panel
	Public WithEvents _cmdTraccia_2 As System.Windows.Forms.Button
    Public WithEvents comboTask As System.Windows.Forms.ComboBox
    Public WithEvents Minimizzatore As AxMinimizzatore.AxMinimizza
	Public WithEvents ListSelect As System.Windows.Forms.ListBox
	Public WithEvents _Check1_0 As System.Windows.Forms.CheckBox
	Public WithEvents cmdTipPass As System.Windows.Forms.Button
	Public WithEvents Timer2 As System.Windows.Forms.Timer
	Public WithEvents _Combo2_0 As System.Windows.Forms.ComboBox
	Public WithEvents Timer1 As System.Windows.Forms.Timer
	Public WithEvents _Pix_0 As System.Windows.Forms.PictureBox
    Public WithEvents Frame1 As System.Windows.Forms.Panel
	Public WithEvents _Text2_0 As System.Windows.Forms.TextBox
	Public WithEvents _Text1_0 As System.Windows.Forms.TextBox
	Public WithEvents _Combo1_0 As System.Windows.Forms.ComboBox
	Public WithEvents CommonDialog1 As AxMSComDlg.AxCommonDialog
	Public WithEvents _yCombo1_0 As System.Windows.Forms.PictureBox
	Public WithEvents _yCombo2_0 As System.Windows.Forms.PictureBox
	Public WithEvents cDummy As System.Windows.Forms.Label
	Public WithEvents _Label2_0 As System.Windows.Forms.Label
	Public WithEvents _Label1_0 As System.Windows.Forms.Label
    Public WithEvents _Pagina_0 As AxThreed.AxSSRibbon
	Public WithEvents _Pagina_1 As AxThreed.AxSSRibbon
	Public WithEvents _Pagina_2 As AxThreed.AxSSRibbon
	Public WithEvents _Pagina_3 As AxThreed.AxSSRibbon
	Public WithEvents _Pagina_4 As AxThreed.AxSSRibbon
	Public WithEvents cmdZoom As AxThreed.AxSSRibbon
	Public WithEvents _Pagina_5 As AxThreed.AxSSRibbon
	Public WithEvents _Pagina_6 As AxThreed.AxSSRibbon
	Public WithEvents _Pagina_8 As AxThreed.AxSSRibbon
	Public WithEvents Check1 As Microsoft.VisualBasic.Compatibility.VB6.CheckBoxArray
	Public WithEvents Combo1 As Microsoft.VisualBasic.Compatibility.VB6.ComboBoxArray
	Public WithEvents Combo2 As Microsoft.VisualBasic.Compatibility.VB6.ComboBoxArray
	Public WithEvents Label1 As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	Public WithEvents Label2 As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	Public WithEvents Pagina As AxSSRibbonArray.AxSSRibbonArray
	Public WithEvents Pix As Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray
	Public WithEvents Salva As Microsoft.VisualBasic.Compatibility.VB6.ButtonArray
	Public WithEvents Text1 As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
	Public WithEvents Text2 As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
	Public WithEvents cmdTraccia As Microsoft.VisualBasic.Compatibility.VB6.ButtonArray
	Public WithEvents yCombo1 As Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray
	Public WithEvents yCombo2 As Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray
	Public WithEvents mnuAree As System.Windows.Forms.MenuItem
	Public WithEvents mnuTipo As System.Windows.Forms.MenuItem
	Public WithEvents mnuFact As System.Windows.Forms.MenuItem
	Public WithEvents mnuPref As System.Windows.Forms.MenuItem
	Public WithEvents mnuTogli As System.Windows.Forms.MenuItem
	Public WithEvents mnuCambia As System.Windows.Forms.MenuItem
	Public WithEvents mnuToglTi As System.Windows.Forms.MenuItem
	Public WithEvents mnuDimen As System.Windows.Forms.MenuItem
	Public WithEvents mnuRuota As System.Windows.Forms.MenuItem
	Public WithEvents mnuRuotaGen As System.Windows.Forms.MenuItem
	Public WithEvents mnuVista As System.Windows.Forms.MenuItem
	Public MainMenu1 As System.Windows.Forms.MainMenu
	'NOTA: la routine seguente è richiesta dalla progettazione Windows Form.
	'Può essere modificata utilizzando la finestra di progettazione Windows Form.
	'Non modificarla mediante l'editor di codice.
    Public WithEvents panPicture1 As System.Windows.Forms.Panel
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmTraccia))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmdElim = New System.Windows.Forms.Button
        Me._Pagina_7 = New AxThreed.AxSSRibbon
        Me.cmdFull = New AxThreed.AxSSCommand
        Me.StatusBar1 = New AxMSComctlLib.AxStatusBar
        Me.pctRisult = New System.Windows.Forms.Panel
        Me._cmdTraccia_4 = New System.Windows.Forms.Button
        Me._cmdTraccia_2 = New System.Windows.Forms.Button
        Me.comboTask = New System.Windows.Forms.ComboBox
        Me.panPicture1 = New System.Windows.Forms.Panel
        Me.ListSelect = New System.Windows.Forms.ListBox
        Me._Check1_0 = New System.Windows.Forms.CheckBox
        Me.cmdTipPass = New System.Windows.Forms.Button
        Me._Combo2_0 = New System.Windows.Forms.ComboBox
        Me._Pix_0 = New System.Windows.Forms.PictureBox
        Me.Frame1 = New System.Windows.Forms.Panel
        Me._Text2_0 = New System.Windows.Forms.TextBox
        Me._Text1_0 = New System.Windows.Forms.TextBox
        Me._Combo1_0 = New System.Windows.Forms.ComboBox
        Me.CommonDialog1 = New AxMSComDlg.AxCommonDialog
        Me._yCombo1_0 = New System.Windows.Forms.PictureBox
        Me._yCombo2_0 = New System.Windows.Forms.PictureBox
        Me.cDummy = New System.Windows.Forms.Label
        Me._Label2_0 = New System.Windows.Forms.Label
        Me._Label1_0 = New System.Windows.Forms.Label
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me._Pagina_0 = New AxThreed.AxSSRibbon
        Me._Pagina_1 = New AxThreed.AxSSRibbon
        Me._Pagina_2 = New AxThreed.AxSSRibbon
        Me._Pagina_3 = New AxThreed.AxSSRibbon
        Me._Pagina_4 = New AxThreed.AxSSRibbon
        Me.cmdZoom = New AxThreed.AxSSRibbon
        Me._Pagina_5 = New AxThreed.AxSSRibbon
        Me._Pagina_6 = New AxThreed.AxSSRibbon
        Me._Pagina_8 = New AxThreed.AxSSRibbon
        Me.Check1 = New Microsoft.VisualBasic.Compatibility.VB6.CheckBoxArray(Me.components)
        Me.Combo1 = New Microsoft.VisualBasic.Compatibility.VB6.ComboBoxArray(Me.components)
        Me.Combo2 = New Microsoft.VisualBasic.Compatibility.VB6.ComboBoxArray(Me.components)
        Me.Label1 = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        Me.Label2 = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        Me.Pagina = New AxSSRibbonArray.AxSSRibbonArray(Me.components)
        Me.Pix = New Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray(Me.components)
        Me.Salva = New Microsoft.VisualBasic.Compatibility.VB6.ButtonArray(Me.components)
        Me.Text1 = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(Me.components)
        Me.Text2 = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(Me.components)
        Me.cmdTraccia = New Microsoft.VisualBasic.Compatibility.VB6.ButtonArray(Me.components)
        Me.yCombo1 = New Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray(Me.components)
        Me.yCombo2 = New Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray(Me.components)
        Me.MainMenu1 = New System.Windows.Forms.MainMenu
        Me.mnuPref = New System.Windows.Forms.MenuItem
        Me.mnuAree = New System.Windows.Forms.MenuItem
        Me.mnuTipo = New System.Windows.Forms.MenuItem
        Me.mnuFact = New System.Windows.Forms.MenuItem
        Me.mnuVista = New System.Windows.Forms.MenuItem
        Me.mnuTogli = New System.Windows.Forms.MenuItem
        Me.mnuCambia = New System.Windows.Forms.MenuItem
        Me.mnuToglTi = New System.Windows.Forms.MenuItem
        Me.mnuDimen = New System.Windows.Forms.MenuItem
        Me.mnuRuota = New System.Windows.Forms.MenuItem
        Me.mnuRuotaGen = New System.Windows.Forms.MenuItem
        CType(Me._Pagina_7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdFull, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StatusBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pctRisult.SuspendLayout()
        Me.panPicture1.SuspendLayout()
        CType(Me.CommonDialog1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._Pagina_0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._Pagina_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._Pagina_2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._Pagina_3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._Pagina_4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdZoom, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._Pagina_5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._Pagina_6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._Pagina_8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Check1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Combo2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Pagina, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Pix, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Salva, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Text1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Text2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdTraccia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.yCombo1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.yCombo2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdElim
        '
        Me.cmdElim.BackColor = System.Drawing.SystemColors.Control
        Me.cmdElim.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdElim.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdElim.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdElim.Location = New System.Drawing.Point(464, 0)
        Me.cmdElim.Name = "cmdElim"
        Me.cmdElim.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdElim.Size = New System.Drawing.Size(145, 21)
        Me.cmdElim.TabIndex = 39
        Me.cmdElim.Text = "Elimina dati finali"
        '
        '_Pagina_7
        '
        Me.Pagina.SetIndex(Me._Pagina_7, CType(7, Short))
        Me._Pagina_7.Location = New System.Drawing.Point(568, 32)
        Me._Pagina_7.Name = "_Pagina_7"
        Me._Pagina_7.OcxState = CType(resources.GetObject("_Pagina_7.OcxState"), System.Windows.Forms.AxHost.State)
        Me._Pagina_7.Size = New System.Drawing.Size(40, 53)
        Me._Pagina_7.TabIndex = 36
        '
        'cmdFull
        '
        Me.cmdFull.Location = New System.Drawing.Point(424, 0)
        Me.cmdFull.Name = "cmdFull"
        Me.cmdFull.OcxState = CType(resources.GetObject("cmdFull.OcxState"), System.Windows.Forms.AxHost.State)
        Me.cmdFull.Size = New System.Drawing.Size(25, 25)
        Me.cmdFull.TabIndex = 25
        '
        'StatusBar1
        '
        Me.StatusBar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.StatusBar1.Location = New System.Drawing.Point(0, 469)
        Me.StatusBar1.Name = "StatusBar1"
        Me.StatusBar1.OcxState = CType(resources.GetObject("StatusBar1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.StatusBar1.Size = New System.Drawing.Size(678, 17)
        Me.StatusBar1.TabIndex = 21
        '
        'pctRisult
        '
        Me.pctRisult.BackColor = System.Drawing.SystemColors.Control
        Me.pctRisult.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pctRisult.Controls.Add(Me._cmdTraccia_4)
        Me.pctRisult.Cursor = System.Windows.Forms.Cursors.Default
        Me.pctRisult.Font = New System.Drawing.Font("Courier New", 7.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pctRisult.ForeColor = System.Drawing.SystemColors.ControlText
        Me.pctRisult.Location = New System.Drawing.Point(560, 264)
        Me.pctRisult.Name = "pctRisult"
        Me.pctRisult.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.pctRisult.Size = New System.Drawing.Size(113, 193)
        Me.pctRisult.TabIndex = 20
        Me.pctRisult.TabStop = True
        '
        '_cmdTraccia_4
        '
        Me._cmdTraccia_4.BackColor = System.Drawing.SystemColors.Control
        Me._cmdTraccia_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdTraccia_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdTraccia.SetIndex(Me._cmdTraccia_4, CType(4, Short))
        Me._cmdTraccia_4.Location = New System.Drawing.Point(50, 0)
        Me._cmdTraccia_4.Name = "_cmdTraccia_4"
        Me._cmdTraccia_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdTraccia_4.Size = New System.Drawing.Size(60, 17)
        Me._cmdTraccia_4.TabIndex = 32
        Me._cmdTraccia_4.Text = "Aggiorna"
        '
        '_cmdTraccia_2
        '
        Me._cmdTraccia_2.BackColor = System.Drawing.SystemColors.Control
        Me._cmdTraccia_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdTraccia_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdTraccia.SetIndex(Me._cmdTraccia_2, CType(2, Short))
        Me._cmdTraccia_2.Location = New System.Drawing.Point(620, 168)
        Me._cmdTraccia_2.Name = "_cmdTraccia_2"
        Me._cmdTraccia_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdTraccia_2.Size = New System.Drawing.Size(56, 21)
        Me._cmdTraccia_2.TabIndex = 19
        Me._cmdTraccia_2.Text = "D.Interno"
        '
        'comboTask
        '
        Me.comboTask.BackColor = System.Drawing.SystemColors.Window
        Me.comboTask.Cursor = System.Windows.Forms.Cursors.Default
        Me.comboTask.Font = New System.Drawing.Font("Courier New", 7.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.comboTask.ForeColor = System.Drawing.SystemColors.WindowText
        Me.comboTask.Location = New System.Drawing.Point(440, 90)
        Me.comboTask.Name = "comboTask"
        Me.comboTask.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.comboTask.Size = New System.Drawing.Size(87, 20)
        Me.comboTask.TabIndex = 9
        Me.comboTask.Text = "comboTask"
        Me.comboTask.Visible = False
        '
        'panPicture1
        '
        Me.panPicture1.BackColor = System.Drawing.SystemColors.Control
        Me.panPicture1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.panPicture1.Controls.Add(Me.ListSelect)
        Me.panPicture1.Controls.Add(Me._Check1_0)
        Me.panPicture1.Controls.Add(Me.cmdTipPass)
        Me.panPicture1.Controls.Add(Me._Combo2_0)
        Me.panPicture1.Controls.Add(Me._Pix_0)
        Me.panPicture1.Controls.Add(Me.Frame1)
        Me.panPicture1.Controls.Add(Me._Text2_0)
        Me.panPicture1.Controls.Add(Me._Text1_0)
        Me.panPicture1.Controls.Add(Me._Combo1_0)
        Me.panPicture1.Controls.Add(Me.CommonDialog1)
        Me.panPicture1.Controls.Add(Me._yCombo1_0)
        Me.panPicture1.Controls.Add(Me._yCombo2_0)
        Me.panPicture1.Controls.Add(Me.cDummy)
        Me.panPicture1.Controls.Add(Me._Label2_0)
        Me.panPicture1.Controls.Add(Me._Label1_0)
        Me.panPicture1.Cursor = System.Windows.Forms.Cursors.Default
        Me.panPicture1.Font = New System.Drawing.Font("Courier New", 7.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.panPicture1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.panPicture1.Location = New System.Drawing.Point(8, 26)
        Me.panPicture1.Name = "panPicture1"
        Me.panPicture1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.panPicture1.Size = New System.Drawing.Size(608, 433)
        Me.panPicture1.TabIndex = 0
        Me.panPicture1.TabStop = True
        '
        'ListSelect
        '
        Me.ListSelect.BackColor = System.Drawing.SystemColors.Window
        Me.ListSelect.Cursor = System.Windows.Forms.Cursors.Default
        Me.ListSelect.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ListSelect.ItemHeight = 12
        Me.ListSelect.Location = New System.Drawing.Point(88, 240)
        Me.ListSelect.Name = "ListSelect"
        Me.ListSelect.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ListSelect.Size = New System.Drawing.Size(113, 40)
        Me.ListSelect.TabIndex = 45
        Me.ListSelect.Visible = False
        '
        '_Check1_0
        '
        Me._Check1_0.BackColor = System.Drawing.SystemColors.Control
        Me._Check1_0.Checked = True
        Me._Check1_0.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me._Check1_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Check1_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Check1.SetIndex(Me._Check1_0, CType(0, Short))
        Me._Check1_0.Location = New System.Drawing.Point(328, 72)
        Me._Check1_0.Name = "_Check1_0"
        Me._Check1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Check1_0.Size = New System.Drawing.Size(129, 20)
        Me._Check1_0.TabIndex = 42
        Me._Check1_0.Visible = False
        '
        'cmdTipPass
        '
        Me.cmdTipPass.BackColor = System.Drawing.SystemColors.Control
        Me.cmdTipPass.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdTipPass.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdTipPass.Location = New System.Drawing.Point(326, 115)
        Me.cmdTipPass.Name = "cmdTipPass"
        Me.cmdTipPass.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdTipPass.Size = New System.Drawing.Size(128, 20)
        Me.cmdTipPass.TabIndex = 41
        Me.cmdTipPass.TabStop = False
        Me.cmdTipPass.Text = "command"
        '
        '_Combo2_0
        '
        Me._Combo2_0.BackColor = System.Drawing.SystemColors.Window
        Me._Combo2_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Combo2_0.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me._Combo2_0.Enabled = False
        Me._Combo2_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Combo2.SetIndex(Me._Combo2_0, CType(0, Short))
        Me._Combo2_0.Location = New System.Drawing.Point(328, 0)
        Me._Combo2_0.Name = "_Combo2_0"
        Me._Combo2_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Combo2_0.Size = New System.Drawing.Size(128, 20)
        Me._Combo2_0.TabIndex = 4
        Me._Combo2_0.TabStop = False
        Me._Combo2_0.Visible = False
        '
        '_Pix_0
        '
        Me._Pix_0.BackColor = System.Drawing.SystemColors.Window
        Me._Pix_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._Pix_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Pix_0.Font = New System.Drawing.Font("Courier New", 7.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Pix_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Pix.SetIndex(Me._Pix_0, CType(0, Short))
        Me._Pix_0.Location = New System.Drawing.Point(88, 152)
        Me._Pix_0.Name = "_Pix_0"
        Me._Pix_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Pix_0.Size = New System.Drawing.Size(89, 57)
        Me._Pix_0.TabIndex = 33
        Me._Pix_0.TabStop = False
        Me._Pix_0.Visible = False
        '
        'Frame1
        '
        Me.Frame1.BackColor = System.Drawing.SystemColors.Window
        Me.Frame1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Frame1.Font = New System.Drawing.Font("Courier New", 7.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Frame1.Location = New System.Drawing.Point(16, 16)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame1.Size = New System.Drawing.Size(89, 89)
        Me.Frame1.TabIndex = 26
        Me.Frame1.Text = "Frame1"
        Me.Frame1.Visible = False
        '
        '_Text2_0
        '
        Me._Text2_0.AcceptsReturn = True
        Me._Text2_0.AutoSize = False
        Me._Text2_0.BackColor = System.Drawing.SystemColors.Window
        Me._Text2_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text2_0.Enabled = False
        Me._Text2_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text2.SetIndex(Me._Text2_0, CType(0, Short))
        Me._Text2_0.Location = New System.Drawing.Point(242, 48)
        Me._Text2_0.MaxLength = 0
        Me._Text2_0.Name = "_Text2_0"
        Me._Text2_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text2_0.Size = New System.Drawing.Size(88, 21)
        Me._Text2_0.TabIndex = 13
        Me._Text2_0.Text = ""
        Me._Text2_0.Visible = False
        '
        '_Text1_0
        '
        Me._Text1_0.AcceptsReturn = True
        Me._Text1_0.AutoSize = False
        Me._Text1_0.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_0.Enabled = False
        Me._Text1_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text1.SetIndex(Me._Text1_0, CType(0, Short))
        Me._Text1_0.Location = New System.Drawing.Point(329, 50)
        Me._Text1_0.MaxLength = 0
        Me._Text1_0.Multiline = True
        Me._Text1_0.Name = "_Text1_0"
        Me._Text1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_0.Size = New System.Drawing.Size(128, 21)
        Me._Text1_0.TabIndex = 2
        Me._Text1_0.Text = ""
        Me._Text1_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me._Text1_0.Visible = False
        '
        '_Combo1_0
        '
        Me._Combo1_0.BackColor = System.Drawing.SystemColors.Window
        Me._Combo1_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Combo1_0.Enabled = False
        Me._Combo1_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Combo1.SetIndex(Me._Combo1_0, CType(0, Short))
        Me._Combo1_0.Location = New System.Drawing.Point(328, 20)
        Me._Combo1_0.Name = "_Combo1_0"
        Me._Combo1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Combo1_0.Size = New System.Drawing.Size(128, 20)
        Me._Combo1_0.TabIndex = 1
        Me._Combo1_0.TabStop = False
        Me._Combo1_0.Visible = False
        '
        'CommonDialog1
        '
        Me.CommonDialog1.ContainingControl = Me
        Me.CommonDialog1.Enabled = True
        Me.CommonDialog1.Location = New System.Drawing.Point(500, 152)
        Me.CommonDialog1.Name = "CommonDialog1"
        Me.CommonDialog1.OcxState = CType(resources.GetObject("CommonDialog1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.CommonDialog1.Size = New System.Drawing.Size(26, 26)
        Me.CommonDialog1.TabIndex = 46
        '
        '_yCombo1_0
        '
        Me._yCombo1_0.BackColor = System.Drawing.SystemColors.Control
        Me._yCombo1_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._yCombo1_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._yCombo1_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.yCombo1.SetIndex(Me._yCombo1_0, CType(0, Short))
        Me._yCombo1_0.Location = New System.Drawing.Point(336, 232)
        Me._yCombo1_0.Name = "_yCombo1_0"
        Me._yCombo1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._yCombo1_0.Size = New System.Drawing.Size(120, 21)
        Me._yCombo1_0.TabIndex = 44
        Me._yCombo1_0.TabStop = False
        Me._yCombo1_0.Visible = False
        '
        '_yCombo2_0
        '
        Me._yCombo2_0.BackColor = System.Drawing.SystemColors.Control
        Me._yCombo2_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._yCombo2_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._yCombo2_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.yCombo2.SetIndex(Me._yCombo2_0, CType(0, Short))
        Me._yCombo2_0.Location = New System.Drawing.Point(336, 200)
        Me._yCombo2_0.Name = "_yCombo2_0"
        Me._yCombo2_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._yCombo2_0.Size = New System.Drawing.Size(120, 22)
        Me._yCombo2_0.TabIndex = 43
        Me._yCombo2_0.TabStop = False
        Me._yCombo2_0.Visible = False
        '
        'cDummy
        '
        Me.cDummy.BackColor = System.Drawing.SystemColors.Control
        Me.cDummy.Cursor = System.Windows.Forms.Cursors.Default
        Me.cDummy.Font = New System.Drawing.Font("Courier New", 7.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cDummy.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cDummy.Location = New System.Drawing.Point(224, 136)
        Me.cDummy.Name = "cDummy"
        Me.cDummy.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cDummy.Size = New System.Drawing.Size(41, 25)
        Me.cDummy.TabIndex = 23
        Me.cDummy.Text = "Label4"
        Me.cDummy.Visible = False
        '
        '_Label2_0
        '
        Me._Label2_0.BackColor = System.Drawing.Color.Cyan
        Me._Label2_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._Label2_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_0.Enabled = False
        Me._Label2_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label2.SetIndex(Me._Label2_0, CType(0, Short))
        Me._Label2_0.Location = New System.Drawing.Point(371, 91)
        Me._Label2_0.Name = "_Label2_0"
        Me._Label2_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_0.Size = New System.Drawing.Size(41, 21)
        Me._Label2_0.TabIndex = 5
        Me._Label2_0.Visible = False
        '
        '_Label1_0
        '
        Me._Label1_0.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._Label1_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_0.Enabled = False
        Me._Label1_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.SetIndex(Me._Label1_0, CType(0, Short))
        Me._Label1_0.Location = New System.Drawing.Point(11, 91)
        Me._Label1_0.Name = "_Label1_0"
        Me._Label1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_0.Size = New System.Drawing.Size(172, 21)
        Me._Label1_0.TabIndex = 3
        Me._Label1_0.Text = "Label1"
        Me._Label1_0.Visible = False
        '
        'Timer2
        '
        Me.Timer2.Interval = 20
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 500
        '
        '_Pagina_0
        '
        Me.Pagina.SetIndex(Me._Pagina_0, CType(0, Short))
        Me._Pagina_0.Location = New System.Drawing.Point(0, 0)
        Me._Pagina_0.Name = "_Pagina_0"
        Me._Pagina_0.OcxState = CType(resources.GetObject("_Pagina_0.OcxState"), System.Windows.Forms.AxHost.State)
        Me._Pagina_0.Size = New System.Drawing.Size(64, 21)
        Me._Pagina_0.TabIndex = 12
        '
        '_Pagina_1
        '
        Me.Pagina.SetIndex(Me._Pagina_1, CType(1, Short))
        Me._Pagina_1.Location = New System.Drawing.Point(64, 0)
        Me._Pagina_1.Name = "_Pagina_1"
        Me._Pagina_1.OcxState = CType(resources.GetObject("_Pagina_1.OcxState"), System.Windows.Forms.AxHost.State)
        Me._Pagina_1.Size = New System.Drawing.Size(64, 21)
        Me._Pagina_1.TabIndex = 15
        '
        '_Pagina_2
        '
        Me.Pagina.SetIndex(Me._Pagina_2, CType(2, Short))
        Me._Pagina_2.Location = New System.Drawing.Point(128, 0)
        Me._Pagina_2.Name = "_Pagina_2"
        Me._Pagina_2.OcxState = CType(resources.GetObject("_Pagina_2.OcxState"), System.Windows.Forms.AxHost.State)
        Me._Pagina_2.Size = New System.Drawing.Size(56, 21)
        Me._Pagina_2.TabIndex = 16
        '
        '_Pagina_3
        '
        Me.Pagina.SetIndex(Me._Pagina_3, CType(3, Short))
        Me._Pagina_3.Location = New System.Drawing.Point(240, 0)
        Me._Pagina_3.Name = "_Pagina_3"
        Me._Pagina_3.OcxState = CType(resources.GetObject("_Pagina_3.OcxState"), System.Windows.Forms.AxHost.State)
        Me._Pagina_3.Size = New System.Drawing.Size(40, 21)
        Me._Pagina_3.TabIndex = 17
        '
        '_Pagina_4
        '
        Me.Pagina.SetIndex(Me._Pagina_4, CType(4, Short))
        Me._Pagina_4.Location = New System.Drawing.Point(280, 0)
        Me._Pagina_4.Name = "_Pagina_4"
        Me._Pagina_4.OcxState = CType(resources.GetObject("_Pagina_4.OcxState"), System.Windows.Forms.AxHost.State)
        Me._Pagina_4.Size = New System.Drawing.Size(33, 21)
        Me._Pagina_4.TabIndex = 18
        '
        'cmdZoom
        '
        Me.cmdZoom.Location = New System.Drawing.Point(392, 0)
        Me.cmdZoom.Name = "cmdZoom"
        Me.cmdZoom.OcxState = CType(resources.GetObject("cmdZoom.OcxState"), System.Windows.Forms.AxHost.State)
        Me.cmdZoom.Size = New System.Drawing.Size(25, 25)
        Me.cmdZoom.TabIndex = 24
        '
        '_Pagina_5
        '
        Me.Pagina.SetIndex(Me._Pagina_5, CType(5, Short))
        Me._Pagina_5.Location = New System.Drawing.Point(314, 0)
        Me._Pagina_5.Name = "_Pagina_5"
        Me._Pagina_5.OcxState = CType(resources.GetObject("_Pagina_5.OcxState"), System.Windows.Forms.AxHost.State)
        Me._Pagina_5.Size = New System.Drawing.Size(33, 21)
        Me._Pagina_5.TabIndex = 34
        '
        '_Pagina_6
        '
        Me.Pagina.SetIndex(Me._Pagina_6, CType(6, Short))
        Me._Pagina_6.Location = New System.Drawing.Point(348, 0)
        Me._Pagina_6.Name = "_Pagina_6"
        Me._Pagina_6.OcxState = CType(resources.GetObject("_Pagina_6.OcxState"), System.Windows.Forms.AxHost.State)
        Me._Pagina_6.Size = New System.Drawing.Size(33, 21)
        Me._Pagina_6.TabIndex = 35
        '
        '_Pagina_8
        '
        Me.Pagina.SetIndex(Me._Pagina_8, CType(8, Short))
        Me._Pagina_8.Location = New System.Drawing.Point(184, 0)
        Me._Pagina_8.Name = "_Pagina_8"
        Me._Pagina_8.OcxState = CType(resources.GetObject("_Pagina_8.OcxState"), System.Windows.Forms.AxHost.State)
        Me._Pagina_8.Size = New System.Drawing.Size(56, 21)
        Me._Pagina_8.TabIndex = 37
        '
        'Check1
        '
        '
        'Combo1
        '
        '
        'Combo2
        '
        '
        'Label1
        '
        '
        'Label2
        '
        '
        'Pagina
        '
        '
        'Salva
        '
        '
        'Text1
        '
        '
        'Text2
        '
        '
        'cmdTraccia
        '
        '
        'MainMenu1
        '
        Me.MainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuPref, Me.mnuVista})
        '
        'mnuPref
        '
        Me.mnuPref.Index = 0
        Me.mnuPref.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuAree, Me.mnuTipo, Me.mnuFact})
        Me.mnuPref.Text = "Preferenze"
        '
        'mnuAree
        '
        Me.mnuAree.Index = 0
        Me.mnuAree.Text = "Aree di Lavoro"
        '
        'mnuTipo
        '
        Me.mnuTipo.Index = 1
        Me.mnuTipo.Text = "Tipo di Lavori"
        '
        'mnuFact
        '
        Me.mnuFact.Index = 2
        Me.mnuFact.Text = "Fattore strategia"
        '
        'mnuVista
        '
        Me.mnuVista.Index = 1
        Me.mnuVista.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuTogli, Me.mnuCambia, Me.mnuToglTi, Me.mnuDimen, Me.mnuRuota, Me.mnuRuotaGen})
        Me.mnuVista.Text = "mnuVista"
        Me.mnuVista.Visible = False
        '
        'mnuTogli
        '
        Me.mnuTogli.Index = 0
        Me.mnuTogli.Text = "mnuTogli"
        '
        'mnuCambia
        '
        Me.mnuCambia.Index = 1
        Me.mnuCambia.Text = "mnuCambia"
        '
        'mnuToglTi
        '
        Me.mnuToglTi.Index = 2
        Me.mnuToglTi.Text = "mnuToglTi"
        '
        'mnuDimen
        '
        Me.mnuDimen.Index = 3
        Me.mnuDimen.Text = "mnuDimen"
        '
        'mnuRuota
        '
        Me.mnuRuota.Index = 4
        Me.mnuRuota.Text = "mnuRuota"
        '
        'mnuRuotaGen
        '
        Me.mnuRuotaGen.Index = 5
        Me.mnuRuotaGen.Text = "mnuRuotaGen"
        '
        'frmTraccia
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 12)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(678, 486)
        Me.Controls.Add(Me.cmdElim)
        Me.Controls.Add(Me._Pagina_7)
        Me.Controls.Add(Me.cmdFull)
        Me.Controls.Add(Me.StatusBar1)
        Me.Controls.Add(Me.pctRisult)
        Me.Controls.Add(Me._cmdTraccia_2)
        Me.Controls.Add(Me.comboTask)
        Me.Controls.Add(Me.panPicture1)
        Me.Controls.Add(Me._Pagina_0)
        Me.Controls.Add(Me._Pagina_1)
        Me.Controls.Add(Me._Pagina_2)
        Me.Controls.Add(Me._Pagina_3)
        Me.Controls.Add(Me._Pagina_4)
        Me.Controls.Add(Me.cmdZoom)
        Me.Controls.Add(Me._Pagina_5)
        Me.Controls.Add(Me._Pagina_6)
        Me.Controls.Add(Me._Pagina_8)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 7.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.HelpButton = True
        Me.Location = New System.Drawing.Point(2, 54)
        Me.MaximizeBox = False
        Me.Menu = Me.MainMenu1
        Me.MinimizeBox = False
        Me.Name = "frmTraccia"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "TRACCIA"
        CType(Me._Pagina_7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdFull, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StatusBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pctRisult.ResumeLayout(False)
        Me.panPicture1.ResumeLayout(False)
        CType(Me.CommonDialog1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._Pagina_0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._Pagina_1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._Pagina_2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._Pagina_3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._Pagina_4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdZoom, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._Pagina_5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._Pagina_6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._Pagina_8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Check1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Combo2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Pagina, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Pix, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Salva, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Text1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Text2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdTraccia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.yCombo1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.yCombo2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
#End Region 
    Public Sub mnuAree_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuAree.Popup
        mnuAree_Click(eventSender, eventArgs)
    End Sub
    Public Sub mnuCambia_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuCambia.Popup
        mnuCambia_Click(eventSender, eventArgs)
    End Sub
    Public Sub mnuCambia_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuCambia.Click
    End Sub

    Public Sub mnuDimen_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuDimen.Popup
        mnuDimen_Click(eventSender, eventArgs)
    End Sub
    Public Sub mnuDimen_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuDimen.Click
    End Sub

    Public Sub mnuFact_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuFact.Popup
        mnuFact_Click(eventSender, eventArgs)
    End Sub
    Public Sub mnuFact_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuFact.Click
    End Sub

    Public Sub mnuRuota_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuRuota.Popup
        mnuRuota_Click(eventSender, eventArgs)
    End Sub
    Public Sub mnuRuota_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuRuota.Click
    End Sub

    Public Sub mnuRuotaGen_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuRuotaGen.Popup
        mnuRuotaGen_Click(eventSender, eventArgs)
    End Sub
    Public Sub mnuRuotaGen_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuRuotaGen.Click
    End Sub

    Public Sub mnuTipo_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuTipo.Popup
        mnuTipo_Click(eventSender, eventArgs)
    End Sub
    Public Sub mnuTipo_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuTipo.Click
    End Sub

    Public Sub mnuTogli_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuTogli.Popup
        mnuTogli_Click(eventSender, eventArgs)
    End Sub
    Public Sub mnuTogli_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuTogli.Click
    End Sub

    Public Sub mnuToglTi_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuToglTi.Popup
        mnuToglTi_Click(eventSender, eventArgs)
    End Sub
    Public Sub mnuToglTi_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuToglTi.Click
    End Sub

    Private Sub Pagina_ClickEvent(ByVal eventSender As System.Object, ByVal eventArgs As AxThreed.ISSRICtrlEvents_ClickEvent) Handles Pagina.ClickEvent
    End Sub
    Private Sub Picture1_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles panPicture1.MouseDown
    End Sub
    Private Sub Picture1_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles panPicture1.MouseMove
    End Sub

    Private Sub Picture1_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles panPicture1.MouseUp
    End Sub

    Private Sub Rpristina_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
    End Sub

    Private Sub Salva_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Salva.Click
        Dim Index As Short = Salva.GetIndex(eventSender)
    End Sub
    'UPGRADE_WARNING: L'evento Text2.TextChanged può essere generato quando il form è inizializzato. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup2075"'
    Private Sub Text2_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Text2.TextChanged
        Dim Index As Short = Text2.GetIndex(eventSender)
        If Not Aggiornando Then VariatiDati = True
    End Sub

    Private Sub Timer1_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Timer1.Tick
    End Sub

    Public Function ControllaDati1() As Short
    End Function





    Private Sub Timer2_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Timer2.Tick
    End Sub
End Class