Option Strict Off
Option Explicit On
Friend Class DataShe1
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
	Public WithEvents TipoP As System.Windows.Forms.PictureBox
	Public WithEvents Toller As System.Windows.Forms.ComboBox
	Public WithEvents TextBWG As System.Windows.Forms.TextBox
	Public WithEvents ClasseTEMA As System.Windows.Forms.ComboBox
	Public WithEvents cmdPHTubi As System.Windows.Forms.Button
	Public WithEvents cmdPHMant As System.Windows.Forms.Button
	Public WithEvents ProvIdrTubi As System.Windows.Forms.TextBox
	Public WithEvents ProvIdrMant As System.Windows.Forms.TextBox
	Public WithEvents TexItem As System.Windows.Forms.TextBox
	Public WithEvents Cliente As System.Windows.Forms.TextBox
	Public WithEvents TexImp As System.Windows.Forms.TextBox
	Public WithEvents TexServ As System.Windows.Forms.TextBox
	Public WithEvents _ComboM_5 As System.Windows.Forms.ComboBox
	Public WithEvents _ComboT_3 As System.Windows.Forms.ComboBox
	Public WithEvents _ComboM_3 As System.Windows.Forms.ComboBox
	Public WithEvents _ComboT_2 As System.Windows.Forms.ComboBox
	Public WithEvents _ComboM_2 As System.Windows.Forms.ComboBox
	Public WithEvents _ComboT_1 As System.Windows.Forms.ComboBox
	Public WithEvents _ComboT_0 As System.Windows.Forms.ComboBox
	Public WithEvents _ComboM_1 As System.Windows.Forms.ComboBox
	Public WithEvents _ComboM_0 As System.Windows.Forms.ComboBox
	Public WithEvents Indietro As System.Windows.Forms.Button
	Public WithEvents Avanti As System.Windows.Forms.Button
	Public WithEvents _Option1_2 As System.Windows.Forms.RadioButton
	Public WithEvents _Option1_1 As System.Windows.Forms.RadioButton
	Public WithEvents _Option1_0 As System.Windows.Forms.RadioButton
	Public WithEvents Frame1 As System.Windows.Forms.GroupBox
    Public WithEvents Command3D2 As System.Windows.Forms.Button 'AxThreed.AxSSCommand
    Public WithEvents Command3D1 As System.Windows.Forms.Button 'AxThreed.AxSSCommand
    Public WithEvents _ValorM_5 As System.windows.forms.TextBox
    Public WithEvents _ValorM_16 As System.windows.forms.TextBox
    Public WithEvents _ValorM_15 As System.windows.forms.TextBox
    Public WithEvents _ValorM_14 As System.windows.forms.TextBox
    Public WithEvents _ValorM_13 As System.windows.forms.TextBox
    Public WithEvents _ValorM_12 As System.windows.forms.TextBox
    Public WithEvents _ValorT_11 As System.windows.forms.TextBox
    Public WithEvents _ValorM_11 As System.windows.forms.TextBox
    Public WithEvents _ValorT_10 As System.windows.forms.TextBox
    Public WithEvents _ValorT_9 As System.windows.forms.TextBox
    Public WithEvents _ValorM_10 As System.windows.forms.TextBox
    Public WithEvents _ValorM_9 As System.windows.forms.TextBox
    Public WithEvents _ValorT_7 As System.windows.forms.TextBox
    Public WithEvents _ValorT_6 As System.windows.forms.TextBox
    Public WithEvents _ValorT_5 As System.windows.forms.TextBox
    Public WithEvents _ValorT_4 As System.windows.forms.TextBox
    Public WithEvents _ValorT_3 As System.windows.forms.TextBox
    Public WithEvents _ValorM_7 As System.windows.forms.TextBox
    Public WithEvents _ValorM_6 As System.windows.forms.TextBox
    Public WithEvents _ValorM_4 As System.windows.forms.TextBox
    Public WithEvents _ValorM_3 As System.windows.forms.TextBox
    Public WithEvents _ValorT_2 As System.windows.forms.TextBox
    Public WithEvents _ValorT_1 As System.windows.forms.TextBox
    Public WithEvents _ValorM_2 As System.windows.forms.TextBox
    Public WithEvents _ValorM_1 As System.windows.forms.TextBox
    Public WithEvents _ValorT_0 As System.windows.forms.TextBox
    Public WithEvents _ValorM_0 As System.windows.forms.TextBox
    Public WithEvents _ValorT_8 As System.windows.forms.TextBox
    Public WithEvents _ValorM_8 As System.windows.forms.TextBox
    Public WithEvents _LabFlui_20 As System.Windows.Forms.Label
    Public WithEvents _LabFlui_16 As System.Windows.Forms.Label
    Public WithEvents _LabFlui_19 As System.Windows.Forms.Label
    Public WithEvents Label10 As System.Windows.Forms.Label
    Public WithEvents Label9 As System.Windows.Forms.Label
    Public WithEvents Label8 As System.Windows.Forms.Label
    Public WithEvents LabTEMA As System.Windows.Forms.Label
    Public WithEvents LabClie As System.Windows.Forms.Label
    Public WithEvents LabImp As System.Windows.Forms.Label
    Public WithEvents TEMA As System.Windows.Forms.Label
    Public WithEvents LabITEM As System.Windows.Forms.Label
    Public WithEvents Label7 As System.Windows.Forms.Label
    Public WithEvents _LabFlui_18 As System.Windows.Forms.Label
    Public WithEvents _LabFlui_17 As System.Windows.Forms.Label
    Public WithEvents _LabFlui_15 As System.Windows.Forms.Label
    Public WithEvents _LabFlui_14 As System.Windows.Forms.Label
    Public WithEvents _LabFlui_13 As System.Windows.Forms.Label
    Public WithEvents Label6 As System.Windows.Forms.Label
    Public WithEvents _LabFlui_12 As System.Windows.Forms.Label
    Public WithEvents _LabFlui_11 As System.Windows.Forms.Label
    Public WithEvents _LabFlui_10 As System.Windows.Forms.Label
    Public WithEvents _LabFlui_9 As System.Windows.Forms.Label
    Public WithEvents _LabFlui_8 As System.Windows.Forms.Label
    Public WithEvents _LabFlui_7 As System.Windows.Forms.Label
    Public WithEvents _LabFlui_6 As System.Windows.Forms.Label
    Public WithEvents Label5 As System.Windows.Forms.Label
    Public WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents Label4 As System.Windows.Forms.Label
    Public WithEvents _LabFlui_5 As System.Windows.Forms.Label
    Public WithEvents _LabFlui_4 As System.Windows.Forms.Label
    Public WithEvents _LabFlui_3 As System.Windows.Forms.Label
    Public WithEvents _LabFlui_2 As System.Windows.Forms.Label
    Public WithEvents _LabFlui_1 As System.Windows.Forms.Label
    Public WithEvents _LabFlui_0 As System.Windows.Forms.Label
    Public WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents LabServ As System.Windows.Forms.Label
    Public ComboM As New System.Collections.Generic.Dictionary(Of Integer, ComboBox)
    Public ComboT As New System.Collections.Generic.Dictionary(Of Integer, ComboBox)
    Public LabFlui As New System.Collections.Generic.Dictionary(Of Integer, Label)
    Public Option1 As New System.Collections.Generic.Dictionary(Of Integer, RadioButton)
    Public ValorM As New System.Collections.Generic.Dictionary(Of Integer, TextBox)
    Public ValorT As New System.Collections.Generic.Dictionary(Of Integer, TextBox)
    'NOTA: la routine seguente è richiesta dalla progettazione Windows Form.
    'Può essere modificata utilizzando la finestra di progettazione Windows Form.
    'Non modificarla mediante l'editor di codice.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(DataShe1))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.TipoP = New System.Windows.Forms.PictureBox
        Me.Toller = New System.Windows.Forms.ComboBox
        Me.TextBWG = New System.Windows.Forms.TextBox
        Me.ClasseTEMA = New System.Windows.Forms.ComboBox
        Me.cmdPHTubi = New System.Windows.Forms.Button
        Me.cmdPHMant = New System.Windows.Forms.Button
        Me.ProvIdrTubi = New System.Windows.Forms.TextBox
        Me.ProvIdrMant = New System.Windows.Forms.TextBox
        Me.TexItem = New System.Windows.Forms.TextBox
        Me.Cliente = New System.Windows.Forms.TextBox
        Me.TexImp = New System.Windows.Forms.TextBox
        Me.TexServ = New System.Windows.Forms.TextBox
        Me._ComboM_5 = New System.Windows.Forms.ComboBox
        Me._ComboT_3 = New System.Windows.Forms.ComboBox
        Me._ComboM_3 = New System.Windows.Forms.ComboBox
        Me._ComboT_2 = New System.Windows.Forms.ComboBox
        Me._ComboM_2 = New System.Windows.Forms.ComboBox
        Me._ComboT_1 = New System.Windows.Forms.ComboBox
        Me._ComboT_0 = New System.Windows.Forms.ComboBox
        Me._ComboM_1 = New System.Windows.Forms.ComboBox
        Me._ComboM_0 = New System.Windows.Forms.ComboBox
        Me.Indietro = New System.Windows.Forms.Button
        Me.Avanti = New System.Windows.Forms.Button
        Me.Frame1 = New System.Windows.Forms.GroupBox
        Me._Option1_2 = New System.Windows.Forms.RadioButton
        Me._Option1_1 = New System.Windows.Forms.RadioButton
        Me._Option1_0 = New System.Windows.Forms.RadioButton
        Me.Command3D2 = New System.Windows.Forms.Button
        Me.Command3D1 = New System.Windows.Forms.Button
        Me._ValorM_5 = New System.windows.forms.TextBox
        Me._ValorM_16 = New System.windows.forms.TextBox
        Me._ValorM_15 = New System.windows.forms.TextBox
        Me._ValorM_14 = New System.windows.forms.TextBox
        Me._ValorM_13 = New System.windows.forms.TextBox
        Me._ValorM_12 = New System.windows.forms.TextBox
        Me._ValorT_11 = New System.windows.forms.TextBox
        Me._ValorM_11 = New System.windows.forms.TextBox
        Me._ValorT_10 = New System.windows.forms.TextBox
        Me._ValorT_9 = New System.windows.forms.TextBox
        Me._ValorM_10 = New System.windows.forms.TextBox
        Me._ValorM_9 = New System.windows.forms.TextBox
        Me._ValorT_7 = New System.windows.forms.TextBox
        Me._ValorT_6 = New System.windows.forms.TextBox
        Me._ValorT_5 = New System.windows.forms.TextBox
        Me._ValorT_4 = New System.windows.forms.TextBox
        Me._ValorT_3 = New System.windows.forms.TextBox
        Me._ValorM_7 = New System.windows.forms.TextBox
        Me._ValorM_6 = New System.windows.forms.TextBox
        Me._ValorM_4 = New System.windows.forms.TextBox
        Me._ValorM_3 = New System.windows.forms.TextBox
        Me._ValorT_2 = New System.windows.forms.TextBox
        Me._ValorT_1 = New System.windows.forms.TextBox
        Me._ValorM_2 = New System.windows.forms.TextBox
        Me._ValorM_1 = New System.windows.forms.TextBox
        Me._ValorT_0 = New System.windows.forms.TextBox
        Me._ValorM_0 = New System.windows.forms.TextBox
        Me._ValorT_8 = New System.windows.forms.TextBox
        Me._ValorM_8 = New System.windows.forms.TextBox
        Me._LabFlui_20 = New System.Windows.Forms.Label
        Me._LabFlui_16 = New System.Windows.Forms.Label
        Me._LabFlui_19 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.LabTEMA = New System.Windows.Forms.Label
        Me.LabClie = New System.Windows.Forms.Label
        Me.LabImp = New System.Windows.Forms.Label
        Me.TEMA = New System.Windows.Forms.Label
        Me.LabITEM = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me._LabFlui_18 = New System.Windows.Forms.Label
        Me._LabFlui_17 = New System.Windows.Forms.Label
        Me._LabFlui_15 = New System.Windows.Forms.Label
        Me._LabFlui_14 = New System.Windows.Forms.Label
        Me._LabFlui_13 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me._LabFlui_12 = New System.Windows.Forms.Label
        Me._LabFlui_11 = New System.Windows.Forms.Label
        Me._LabFlui_10 = New System.Windows.Forms.Label
        Me._LabFlui_9 = New System.Windows.Forms.Label
        Me._LabFlui_8 = New System.Windows.Forms.Label
        Me._LabFlui_7 = New System.Windows.Forms.Label
        Me._LabFlui_6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me._LabFlui_5 = New System.Windows.Forms.Label
        Me._LabFlui_4 = New System.Windows.Forms.Label
        Me._LabFlui_3 = New System.Windows.Forms.Label
        Me._LabFlui_2 = New System.Windows.Forms.Label
        Me._LabFlui_1 = New System.Windows.Forms.Label
        Me._LabFlui_0 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.LabServ = New System.Windows.Forms.Label
        Me.Frame1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TipoP
        '
        Me.TipoP.BackColor = System.Drawing.SystemColors.Window
        Me.TipoP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TipoP.Cursor = System.Windows.Forms.Cursors.Default
        Me.TipoP.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TipoP.Location = New System.Drawing.Point(170, 404)
        Me.TipoP.Name = "TipoP"
        Me.TipoP.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TipoP.Size = New System.Drawing.Size(31, 21)
        Me.TipoP.TabIndex = 91
        Me.TipoP.TabStop = False
        '
        'Toller
        '
        Me.Toller.BackColor = System.Drawing.SystemColors.Window
        Me.Toller.Cursor = System.Windows.Forms.Cursors.Default
        Me.Toller.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Toller.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Toller.Location = New System.Drawing.Point(400, 384)
        Me.Toller.Name = "Toller"
        Me.Toller.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Toller.Size = New System.Drawing.Size(51, 21)
        Me.Toller.TabIndex = 89
        Me.Toller.TabStop = False
        '
        'TextBWG
        '
        Me.TextBWG.AcceptsReturn = True
        Me.TextBWG.AutoSize = False
        Me.TextBWG.BackColor = System.Drawing.SystemColors.Window
        Me.TextBWG.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBWG.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextBWG.Enabled = False
        Me.TextBWG.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TextBWG.Location = New System.Drawing.Point(310, 384)
        Me.TextBWG.MaxLength = 0
        Me.TextBWG.Name = "TextBWG"
        Me.TextBWG.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TextBWG.Size = New System.Drawing.Size(31, 21)
        Me.TextBWG.TabIndex = 87
        Me.TextBWG.TabStop = False
        Me.TextBWG.Text = ""
        Me.TextBWG.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ClasseTEMA
        '
        Me.ClasseTEMA.BackColor = System.Drawing.SystemColors.Window
        Me.ClasseTEMA.Cursor = System.Windows.Forms.Cursors.Default
        Me.ClasseTEMA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ClasseTEMA.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ClasseTEMA.Location = New System.Drawing.Point(100, 364)
        Me.ClasseTEMA.Name = "ClasseTEMA"
        Me.ClasseTEMA.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ClasseTEMA.Size = New System.Drawing.Size(51, 21)
        Me.ClasseTEMA.TabIndex = 84
        Me.ClasseTEMA.TabStop = False
        '
        'cmdPHTubi
        '
        Me.cmdPHTubi.BackColor = System.Drawing.SystemColors.Control
        Me.cmdPHTubi.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdPHTubi.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdPHTubi.Location = New System.Drawing.Point(410, 260)
        Me.cmdPHTubi.Name = "cmdPHTubi"
        Me.cmdPHTubi.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdPHTubi.Size = New System.Drawing.Size(41, 21)
        Me.cmdPHTubi.TabIndex = 82
        Me.cmdPHTubi.TabStop = False
        Me.cmdPHTubi.Text = "&Val"
        '
        'cmdPHMant
        '
        Me.cmdPHMant.BackColor = System.Drawing.SystemColors.Control
        Me.cmdPHMant.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdPHMant.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdPHMant.Location = New System.Drawing.Point(280, 260)
        Me.cmdPHMant.Name = "cmdPHMant"
        Me.cmdPHMant.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdPHMant.Size = New System.Drawing.Size(41, 21)
        Me.cmdPHMant.TabIndex = 81
        Me.cmdPHMant.TabStop = False
        Me.cmdPHMant.Text = "&Val"
        '
        'ProvIdrTubi
        '
        Me.ProvIdrTubi.AcceptsReturn = True
        Me.ProvIdrTubi.AutoSize = False
        Me.ProvIdrTubi.BackColor = System.Drawing.SystemColors.Window
        Me.ProvIdrTubi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ProvIdrTubi.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.ProvIdrTubi.Enabled = False
        Me.ProvIdrTubi.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ProvIdrTubi.Location = New System.Drawing.Point(320, 260)
        Me.ProvIdrTubi.MaxLength = 0
        Me.ProvIdrTubi.Name = "ProvIdrTubi"
        Me.ProvIdrTubi.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ProvIdrTubi.Size = New System.Drawing.Size(91, 21)
        Me.ProvIdrTubi.TabIndex = 17
        Me.ProvIdrTubi.Tag = "Code"
        Me.ProvIdrTubi.Text = "As per Code"
        '
        'ProvIdrMant
        '
        Me.ProvIdrMant.AcceptsReturn = True
        Me.ProvIdrMant.AutoSize = False
        Me.ProvIdrMant.BackColor = System.Drawing.SystemColors.Window
        Me.ProvIdrMant.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ProvIdrMant.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.ProvIdrMant.Enabled = False
        Me.ProvIdrMant.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ProvIdrMant.Location = New System.Drawing.Point(190, 260)
        Me.ProvIdrMant.MaxLength = 0
        Me.ProvIdrMant.Name = "ProvIdrMant"
        Me.ProvIdrMant.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ProvIdrMant.Size = New System.Drawing.Size(91, 21)
        Me.ProvIdrMant.TabIndex = 16
        Me.ProvIdrMant.Tag = "Code"
        Me.ProvIdrMant.Text = "As per Code"
        '
        'TexItem
        '
        Me.TexItem.AcceptsReturn = True
        Me.TexItem.AutoSize = False
        Me.TexItem.BackColor = System.Drawing.SystemColors.Window
        Me.TexItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TexItem.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TexItem.Enabled = False
        Me.TexItem.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TexItem.Location = New System.Drawing.Point(190, 0)
        Me.TexItem.MaxLength = 0
        Me.TexItem.Name = "TexItem"
        Me.TexItem.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TexItem.Size = New System.Drawing.Size(121, 21)
        Me.TexItem.TabIndex = 74
        Me.TexItem.Text = ""
        '
        'Cliente
        '
        Me.Cliente.AcceptsReturn = True
        Me.Cliente.AutoSize = False
        Me.Cliente.BackColor = System.Drawing.SystemColors.Window
        Me.Cliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Cliente.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Cliente.Enabled = False
        Me.Cliente.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Cliente.Location = New System.Drawing.Point(190, 20)
        Me.Cliente.MaxLength = 0
        Me.Cliente.Name = "Cliente"
        Me.Cliente.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Cliente.Size = New System.Drawing.Size(261, 21)
        Me.Cliente.TabIndex = 73
        Me.Cliente.Text = ""
        '
        'TexImp
        '
        Me.TexImp.AcceptsReturn = True
        Me.TexImp.AutoSize = False
        Me.TexImp.BackColor = System.Drawing.SystemColors.Window
        Me.TexImp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TexImp.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TexImp.Enabled = False
        Me.TexImp.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TexImp.Location = New System.Drawing.Point(190, 40)
        Me.TexImp.MaxLength = 0
        Me.TexImp.Name = "TexImp"
        Me.TexImp.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TexImp.Size = New System.Drawing.Size(261, 21)
        Me.TexImp.TabIndex = 72
        Me.TexImp.Text = ""
        '
        'TexServ
        '
        Me.TexServ.AcceptsReturn = True
        Me.TexServ.AutoSize = False
        Me.TexServ.BackColor = System.Drawing.SystemColors.Window
        Me.TexServ.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TexServ.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TexServ.Enabled = False
        Me.TexServ.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TexServ.Location = New System.Drawing.Point(190, 60)
        Me.TexServ.MaxLength = 0
        Me.TexServ.Name = "TexServ"
        Me.TexServ.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TexServ.Size = New System.Drawing.Size(261, 21)
        Me.TexServ.TabIndex = 71
        Me.TexServ.Text = ""
        '
        '_ComboM_5
        '
        Me._ComboM_5.BackColor = System.Drawing.SystemColors.Window
        Me._ComboM_5.Cursor = System.Windows.Forms.Cursors.Default
        Me._ComboM_5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me._ComboM_5.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ComboM.Add(5, Me._ComboM_5)
        Me._ComboM_5.Location = New System.Drawing.Point(260, 404)
        Me._ComboM_5.Name = "_ComboM_5"
        Me._ComboM_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._ComboM_5.Size = New System.Drawing.Size(191, 21)
        Me._ComboM_5.TabIndex = 0
        Me._ComboM_5.TabStop = False
        '
        '_ComboT_3
        '
        Me._ComboT_3.BackColor = System.Drawing.SystemColors.Window
        Me._ComboT_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._ComboT_3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me._ComboT_3.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ComboT.Add(3, Me._ComboT_3)
        Me._ComboT_3.Location = New System.Drawing.Point(380, 220)
        Me._ComboT_3.Name = "_ComboT_3"
        Me._ComboT_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._ComboT_3.Size = New System.Drawing.Size(71, 21)
        Me._ComboT_3.TabIndex = 68
        Me._ComboT_3.TabStop = False
        '
        '_ComboM_3
        '
        Me._ComboM_3.BackColor = System.Drawing.SystemColors.Window
        Me._ComboM_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._ComboM_3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me._ComboM_3.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ComboM.Add(3, Me._ComboM_3)
        Me._ComboM_3.Location = New System.Drawing.Point(250, 220)
        Me._ComboM_3.Name = "_ComboM_3"
        Me._ComboM_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._ComboM_3.Size = New System.Drawing.Size(71, 21)
        Me._ComboM_3.TabIndex = 67
        Me._ComboM_3.TabStop = False
        '
        '_ComboT_2
        '
        Me._ComboT_2.BackColor = System.Drawing.SystemColors.Window
        Me._ComboT_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._ComboT_2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me._ComboT_2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ComboT.Add(2, Me._ComboT_2)
        Me._ComboT_2.Location = New System.Drawing.Point(320, 364)
        Me._ComboT_2.Name = "_ComboT_2"
        Me._ComboT_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._ComboT_2.Size = New System.Drawing.Size(131, 21)
        Me._ComboT_2.TabIndex = 61
        Me._ComboT_2.TabStop = False
        '
        '_ComboM_2
        '
        Me._ComboM_2.BackColor = System.Drawing.SystemColors.Window
        Me._ComboM_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._ComboM_2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me._ComboM_2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ComboM.Add(2, Me._ComboM_2)
        Me._ComboM_2.Location = New System.Drawing.Point(190, 364)
        Me._ComboM_2.Name = "_ComboM_2"
        Me._ComboM_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._ComboM_2.Size = New System.Drawing.Size(131, 21)
        Me._ComboM_2.TabIndex = 60
        Me._ComboM_2.TabStop = False
        '
        '_ComboT_1
        '
        Me._ComboT_1.BackColor = System.Drawing.SystemColors.Window
        Me._ComboT_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._ComboT_1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me._ComboT_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ComboT.Add(1, Me._ComboT_1)
        Me._ComboT_1.Location = New System.Drawing.Point(380, 280)
        Me._ComboT_1.Name = "_ComboT_1"
        Me._ComboT_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._ComboT_1.Size = New System.Drawing.Size(71, 21)
        Me._ComboT_1.TabIndex = 56
        Me._ComboT_1.TabStop = False
        '
        '_ComboT_0
        '
        Me._ComboT_0.BackColor = System.Drawing.SystemColors.Window
        Me._ComboT_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._ComboT_0.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me._ComboT_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ComboT.Add(0, Me._ComboT_0)
        Me._ComboT_0.Location = New System.Drawing.Point(320, 280)
        Me._ComboT_0.Name = "_ComboT_0"
        Me._ComboT_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._ComboT_0.Size = New System.Drawing.Size(61, 21)
        Me._ComboT_0.TabIndex = 55
        Me._ComboT_0.TabStop = False
        '
        '_ComboM_1
        '
        Me._ComboM_1.BackColor = System.Drawing.SystemColors.Window
        Me._ComboM_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._ComboM_1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me._ComboM_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ComboM.Add(1, Me._ComboM_1)
        Me._ComboM_1.Location = New System.Drawing.Point(250, 280)
        Me._ComboM_1.Name = "_ComboM_1"
        Me._ComboM_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._ComboM_1.Size = New System.Drawing.Size(71, 21)
        Me._ComboM_1.TabIndex = 54
        Me._ComboM_1.TabStop = False
        '
        '_ComboM_0
        '
        Me._ComboM_0.BackColor = System.Drawing.SystemColors.Window
        Me._ComboM_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._ComboM_0.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me._ComboM_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ComboM.Add(0, Me._ComboM_0)
        Me._ComboM_0.Location = New System.Drawing.Point(190, 280)
        Me._ComboM_0.Name = "_ComboM_0"
        Me._ComboM_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._ComboM_0.Size = New System.Drawing.Size(61, 21)
        Me._ComboM_0.TabIndex = 32
        Me._ComboM_0.TabStop = False
        '
        'Indietro
        '
        Me.Indietro.BackColor = System.Drawing.SystemColors.Control
        Me.Indietro.Cursor = System.Windows.Forms.Cursors.Default
        Me.Indietro.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Indietro.Location = New System.Drawing.Point(160, 454)
        Me.Indietro.Name = "Indietro"
        Me.Indietro.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Indietro.Size = New System.Drawing.Size(71, 21)
        Me.Indietro.TabIndex = 30
        Me.Indietro.Text = "&Indietro"
        '
        'Avanti
        '
        Me.Avanti.BackColor = System.Drawing.SystemColors.Control
        Me.Avanti.Cursor = System.Windows.Forms.Cursors.Default
        Me.Avanti.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Avanti.Location = New System.Drawing.Point(90, 454)
        Me.Avanti.Name = "Avanti"
        Me.Avanti.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Avanti.Size = New System.Drawing.Size(71, 21)
        Me.Avanti.TabIndex = 29
        Me.Avanti.Text = "&Avanti"
        '
        'Frame1
        '
        Me.Frame1.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(0, Byte))
        Me.Frame1.Controls.Add(Me._Option1_2)
        Me.Frame1.Controls.Add(Me._Option1_1)
        Me.Frame1.Controls.Add(Me._Option1_0)
        Me.Frame1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Frame1.Location = New System.Drawing.Point(230, 424)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame1.Size = New System.Drawing.Size(221, 51)
        Me.Frame1.TabIndex = 45
        Me.Frame1.TabStop = False
        Me.Frame1.Text = "Sistema di misura"
        '
        '_Option1_2
        '
        Me._Option1_2.BackColor = System.Drawing.SystemColors.Window
        Me._Option1_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option1_2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Option1.Add(2, Me._Option1_2)
        Me._Option1_2.Location = New System.Drawing.Point(152, 20)
        Me._Option1_2.Name = "_Option1_2"
        Me._Option1_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option1_2.Size = New System.Drawing.Size(59, 21)
        Me._Option1_2.TabIndex = 48
        Me._Option1_2.Text = "SI"
        '
        '_Option1_1
        '
        Me._Option1_1.BackColor = System.Drawing.SystemColors.Window
        Me._Option1_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option1_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Option1.Add(1, Me._Option1_1)
        Me._Option1_1.Location = New System.Drawing.Point(80, 20)
        Me._Option1_1.Name = "_Option1_1"
        Me._Option1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option1_1.Size = New System.Drawing.Size(61, 21)
        Me._Option1_1.TabIndex = 47
        Me._Option1_1.Text = "British"
        '
        '_Option1_0
        '
        Me._Option1_0.BackColor = System.Drawing.SystemColors.Window
        Me._Option1_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option1_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Option1.Add(0, Me._Option1_0)
        Me._Option1_0.Location = New System.Drawing.Point(10, 20)
        Me._Option1_0.Name = "_Option1_0"
        Me._Option1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option1_0.Size = New System.Drawing.Size(51, 21)
        Me._Option1_0.TabIndex = 46
        Me._Option1_0.Text = "Tecn"
        '
        'Command3D2
        '
        Me.Command3D2.Image = CType(resources.GetObject("Command3D2.Image"), System.Drawing.Image)
        Me.Command3D2.Location = New System.Drawing.Point(200, 404)
        Me.Command3D2.Name = "Command3D2"
        Me.Command3D2.Size = New System.Drawing.Size(21, 21)
        Me.Command3D2.TabIndex = 90
        '
        'Command3D1
        '
        Me.Command3D1.Image = CType(resources.GetObject("Command3D1.Image"), System.Drawing.Image)
        Me.Command3D1.Location = New System.Drawing.Point(340, 384)
        Me.Command3D1.Name = "Command3D1"
        Me.Command3D1.Size = New System.Drawing.Size(21, 21)
        Me.Command3D1.TabIndex = 86
        '
        '_ValorM_5
        '
        Me.ValorM.Add(5, Me._ValorM_5)
        Me._ValorM_5.Location = New System.Drawing.Point(250, 200)
        Me._ValorM_5.Name = "_ValorM_5"
        Me._ValorM_5.Size = New System.Drawing.Size(131, 21)
        Me._ValorM_5.TabIndex = 11
        '
        '_ValorM_16
        '
        Me.ValorM.Add(16, Me._ValorM_16)
        Me._ValorM_16.Location = New System.Drawing.Point(90, 404)
        Me._ValorM_16.Name = "_ValorM_16"
        Me._ValorM_16.Size = New System.Drawing.Size(51, 21)
        Me._ValorM_16.TabIndex = 27
        '
        '_ValorM_15
        '
        Me.ValorM.Add(15, Me._ValorM_15)
        Me._ValorM_15.Location = New System.Drawing.Point(110, 424)
        Me._ValorM_15.Name = "_ValorM_15"
        Me._ValorM_15.Size = New System.Drawing.Size(51, 21)
        Me._ValorM_15.TabIndex = 28
        '
        '_ValorM_14
        '
        Me.ValorM.Add(14, Me._ValorM_14)
        Me._ValorM_14.Location = New System.Drawing.Point(240, 384)
        Me._ValorM_14.Name = "_ValorM_14"
        Me._ValorM_14.Size = New System.Drawing.Size(41, 21)
        Me._ValorM_14.TabIndex = 26
        '
        '_ValorM_13
        '
        Me.ValorM.Add(13, Me._ValorM_13)
        Me._ValorM_13.Location = New System.Drawing.Point(140, 384)
        Me._ValorM_13.Name = "_ValorM_13"
        Me._ValorM_13.Size = New System.Drawing.Size(51, 21)
        Me._ValorM_13.TabIndex = 25
        '
        '_ValorM_12
        '
        Me.ValorM.Add(12, Me._ValorM_12)
        Me._ValorM_12.Location = New System.Drawing.Point(50, 384)
        Me._ValorM_12.Name = "_ValorM_12"
        Me._ValorM_12.Size = New System.Drawing.Size(41, 21)
        Me._ValorM_12.TabIndex = 24
        '
        '_ValorT_11
        '
        Me.ValorT.Add(11, Me._ValorT_11)
        Me._ValorT_11.Location = New System.Drawing.Point(320, 300)
        Me._ValorT_11.Name = "_ValorT_11"
        Me._ValorT_11.Size = New System.Drawing.Size(131, 21)
        Me._ValorT_11.TabIndex = 19
        '
        '_ValorM_11
        '
        Me.ValorM.Add(11, Me._ValorM_11)
        Me._ValorM_11.Location = New System.Drawing.Point(190, 300)
        Me._ValorM_11.Name = "_ValorM_11"
        Me._ValorM_11.Size = New System.Drawing.Size(131, 21)
        Me._ValorM_11.TabIndex = 18
        '
        '_ValorT_10
        '
        Me.ValorT.Add(10, Me._ValorT_10)
        Me._ValorT_10.Location = New System.Drawing.Point(380, 320)
        Me._ValorT_10.Name = "_ValorT_10"
        Me._ValorT_10.Size = New System.Drawing.Size(71, 21)
        Me._ValorT_10.TabIndex = 23
        '
        '_ValorT_9
        '
        Me.ValorT.Add(9, Me._ValorT_9)
        Me._ValorT_9.Location = New System.Drawing.Point(320, 320)
        Me._ValorT_9.Name = "_ValorT_9"
        Me._ValorT_9.Size = New System.Drawing.Size(61, 21)
        Me._ValorT_9.TabIndex = 22
        '
        '_ValorM_10
        '
        Me.ValorM.Add(10, Me._ValorM_10)
        Me._ValorM_10.Location = New System.Drawing.Point(250, 320)
        Me._ValorM_10.Name = "_ValorM_10"
        Me._ValorM_10.Size = New System.Drawing.Size(71, 21)
        Me._ValorM_10.TabIndex = 21
        '
        '_ValorM_9
        '
        Me.ValorM.Add(9, Me._ValorM_9)
        Me._ValorM_9.Location = New System.Drawing.Point(190, 320)
        Me._ValorM_9.Name = "_ValorM_9"
        Me._ValorM_9.Size = New System.Drawing.Size(61, 21)
        Me._ValorM_9.TabIndex = 20
        '
        '_ValorT_7
        '
        Me.ValorT.Add(7, Me._ValorT_7)
        Me._ValorT_7.Location = New System.Drawing.Point(320, 240)
        Me._ValorT_7.Name = "_ValorT_7"
        Me._ValorT_7.Size = New System.Drawing.Size(131, 21)
        Me._ValorT_7.TabIndex = 15
        '
        '_ValorT_6
        '
        Me.ValorT.Add(6, Me._ValorT_6)
        Me._ValorT_6.Location = New System.Drawing.Point(320, 220)
        Me._ValorT_6.Name = "_ValorT_6"
        Me._ValorT_6.Size = New System.Drawing.Size(61, 21)
        Me._ValorT_6.TabIndex = 13
        '
        '_ValorT_5
        '
        Me.ValorT.Add(5, Me._ValorT_5)
        Me._ValorT_5.Location = New System.Drawing.Point(330, 200)
        Me._ValorT_5.Name = "_ValorT_5"
        Me._ValorT_5.Size = New System.Drawing.Size(121, 21)
        Me._ValorT_5.TabIndex = 53
        Me._ValorT_5.Visible = False
        '
        '_ValorT_4
        '
        Me.ValorT.Add(4, Me._ValorT_4)
        Me._ValorT_4.Location = New System.Drawing.Point(320, 180)
        Me._ValorT_4.Name = "_ValorT_4"
        Me._ValorT_4.Size = New System.Drawing.Size(131, 21)
        Me._ValorT_4.TabIndex = 10
        '
        '_ValorT_3
        '
        Me.ValorT.Add(3, Me._ValorT_3)
        Me._ValorT_3.Location = New System.Drawing.Point(320, 160)
        Me._ValorT_3.Name = "_ValorT_3"
        Me._ValorT_3.Size = New System.Drawing.Size(131, 21)
        Me._ValorT_3.TabIndex = 8
        '
        '_ValorM_7
        '
        Me.ValorM.Add(7, Me._ValorM_7)
        Me._ValorM_7.Location = New System.Drawing.Point(190, 240)
        Me._ValorM_7.Name = "_ValorM_7"
        Me._ValorM_7.Size = New System.Drawing.Size(131, 21)
        Me._ValorM_7.TabIndex = 14
        '
        '_ValorM_6
        '
        Me.ValorM.Add(6, Me._ValorM_6)
        Me._ValorM_6.Location = New System.Drawing.Point(190, 220)
        Me._ValorM_6.Name = "_ValorM_6"
        Me._ValorM_6.Size = New System.Drawing.Size(61, 21)
        Me._ValorM_6.TabIndex = 12
        '
        '_ValorM_4
        '
        Me.ValorM.Add(4, Me._ValorM_4)
        Me._ValorM_4.Location = New System.Drawing.Point(190, 180)
        Me._ValorM_4.Name = "_ValorM_4"
        Me._ValorM_4.Size = New System.Drawing.Size(131, 21)
        Me._ValorM_4.TabIndex = 9
        '
        '_ValorM_3
        '
        Me.ValorM.Add(3, Me._ValorM_3)
        Me._ValorM_3.Location = New System.Drawing.Point(190, 160)
        Me._ValorM_3.Name = "_ValorM_3"
        Me._ValorM_3.Size = New System.Drawing.Size(131, 21)
        Me._ValorM_3.TabIndex = 7
        '
        '_ValorT_2
        '
        Me.ValorT.Add(2, Me._ValorT_2)
        Me._ValorT_2.Location = New System.Drawing.Point(320, 140)
        Me._ValorT_2.Name = "_ValorT_2"
        Me._ValorT_2.Size = New System.Drawing.Size(131, 21)
        Me._ValorT_2.TabIndex = 6
        '
        '_ValorT_1
        '
        Me.ValorT.Add(1, Me._ValorT_1)
        Me._ValorT_1.Location = New System.Drawing.Point(320, 120)
        Me._ValorT_1.Name = "_ValorT_1"
        Me._ValorT_1.Size = New System.Drawing.Size(131, 21)
        Me._ValorT_1.TabIndex = 4
        '
        '_ValorM_2
        '
        Me.ValorM.Add(2, Me._ValorM_2)
        Me._ValorM_2.Location = New System.Drawing.Point(190, 140)
        Me._ValorM_2.Name = "_ValorM_2"
        Me._ValorM_2.Size = New System.Drawing.Size(131, 21)
        Me._ValorM_2.TabIndex = 5
        '
        '_ValorM_1
        '
        Me.ValorM.Add(1, Me._ValorM_1)
        Me._ValorM_1.Location = New System.Drawing.Point(190, 120)
        Me._ValorM_1.Name = "_ValorM_1"
        Me._ValorM_1.Size = New System.Drawing.Size(131, 21)
        Me._ValorM_1.TabIndex = 3
        '
        '_ValorT_0
        '
        Me.ValorT.Add(0, Me._ValorT_0)
        Me._ValorT_0.Location = New System.Drawing.Point(320, 100)
        Me._ValorT_0.Name = "_ValorT_0"
        Me._ValorT_0.Size = New System.Drawing.Size(131, 21)
        Me._ValorT_0.TabIndex = 2
        '
        '_ValorM_0
        '
        Me.ValorM.Add(0, Me._ValorM_0)
        Me._ValorM_0.Location = New System.Drawing.Point(190, 100)
        Me._ValorM_0.Name = "_ValorM_0"
        Me._ValorM_0.Size = New System.Drawing.Size(131, 21)
        Me._ValorM_0.TabIndex = 1
        '
        '_ValorT_8
        '
        Me.ValorT.Add(8, Me._ValorT_8)
        Me._ValorT_8.Location = New System.Drawing.Point(322, 340)
        Me._ValorT_8.Name = "_ValorT_8"
        Me._ValorT_8.Size = New System.Drawing.Size(131, 21)
        Me._ValorT_8.TabIndex = 93
        '
        '_ValorM_8
        '
        Me.ValorM.Add(8, Me._ValorM_8)
        Me._ValorM_8.Location = New System.Drawing.Point(192, 340)
        Me._ValorM_8.Name = "_ValorM_8"
        Me._ValorM_8.Size = New System.Drawing.Size(131, 21)
        Me._ValorM_8.TabIndex = 94
        Me._ValorM_8.Visible = False
        '
        '_LabFlui_20
        '
        Me._LabFlui_20.BackColor = System.Drawing.SystemColors.Window
        Me._LabFlui_20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._LabFlui_20.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabFlui_20.ForeColor = System.Drawing.SystemColors.WindowText
        Me.LabFlui.Add(20, Me._LabFlui_20)
        Me._LabFlui_20.Location = New System.Drawing.Point(0, 340)
        Me._LabFlui_20.Name = "_LabFlui_20"
        Me._LabFlui_20.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabFlui_20.Size = New System.Drawing.Size(191, 21)
        Me._LabFlui_20.TabIndex = 92
        Me._LabFlui_20.Text = "Numero di passaggi"
        '
        '_LabFlui_16
        '
        Me._LabFlui_16.BackColor = System.Drawing.SystemColors.Window
        Me._LabFlui_16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._LabFlui_16.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabFlui_16.ForeColor = System.Drawing.SystemColors.WindowText
        Me.LabFlui.Add(16, Me._LabFlui_16)
        Me._LabFlui_16.Location = New System.Drawing.Point(30, 424)
        Me._LabFlui_16.Name = "_LabFlui_16"
        Me._LabFlui_16.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabFlui_16.Size = New System.Drawing.Size(81, 21)
        Me._LabFlui_16.TabIndex = 66
        Me._LabFlui_16.Text = "Lungh. (mm)"
        '
        '_LabFlui_19
        '
        Me._LabFlui_19.BackColor = System.Drawing.SystemColors.Window
        Me._LabFlui_19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._LabFlui_19.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabFlui_19.ForeColor = System.Drawing.SystemColors.WindowText
        Me.LabFlui.Add(19, Me._LabFlui_19)
        Me._LabFlui_19.Location = New System.Drawing.Point(220, 404)
        Me._LabFlui_19.Name = "_LabFlui_19"
        Me._LabFlui_19.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabFlui_19.Size = New System.Drawing.Size(41, 21)
        Me._LabFlui_19.TabIndex = 36
        Me._LabFlui_19.Text = "Giunto"
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.SystemColors.Window
        Me.Label10.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label10.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label10.Location = New System.Drawing.Point(360, 384)
        Me.Label10.Name = "Label10"
        Me.Label10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label10.Size = New System.Drawing.Size(41, 21)
        Me.Label10.TabIndex = 88
        Me.Label10.Text = "Toller."
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.SystemColors.Window
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label9.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label9.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label9.Location = New System.Drawing.Point(280, 384)
        Me.Label9.Name = "Label9"
        Me.Label9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label9.Size = New System.Drawing.Size(31, 21)
        Me.Label9.TabIndex = 85
        Me.Label9.Text = "BWG"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.Window
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label8.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label8.Location = New System.Drawing.Point(0, 364)
        Me.Label8.Name = "Label8"
        Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label8.Size = New System.Drawing.Size(101, 21)
        Me.Label8.TabIndex = 83
        Me.Label8.Text = "Classe TEMA"
        '
        'LabTEMA
        '
        Me.LabTEMA.BackColor = System.Drawing.SystemColors.Window
        Me.LabTEMA.Cursor = System.Windows.Forms.Cursors.Default
        Me.LabTEMA.ForeColor = System.Drawing.SystemColors.WindowText
        Me.LabTEMA.Location = New System.Drawing.Point(310, 0)
        Me.LabTEMA.Name = "LabTEMA"
        Me.LabTEMA.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LabTEMA.Size = New System.Drawing.Size(71, 21)
        Me.LabTEMA.TabIndex = 80
        Me.LabTEMA.Text = "Tipo TEMA"
        '
        'LabClie
        '
        Me.LabClie.BackColor = System.Drawing.SystemColors.Window
        Me.LabClie.Cursor = System.Windows.Forms.Cursors.Default
        Me.LabClie.ForeColor = System.Drawing.SystemColors.WindowText
        Me.LabClie.Location = New System.Drawing.Point(130, 20)
        Me.LabClie.Name = "LabClie"
        Me.LabClie.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LabClie.Size = New System.Drawing.Size(41, 21)
        Me.LabClie.TabIndex = 79
        Me.LabClie.Text = "Cliente"
        '
        'LabImp
        '
        Me.LabImp.BackColor = System.Drawing.SystemColors.Window
        Me.LabImp.Cursor = System.Windows.Forms.Cursors.Default
        Me.LabImp.ForeColor = System.Drawing.SystemColors.WindowText
        Me.LabImp.Location = New System.Drawing.Point(130, 40)
        Me.LabImp.Name = "LabImp"
        Me.LabImp.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LabImp.Size = New System.Drawing.Size(51, 21)
        Me.LabImp.TabIndex = 78
        Me.LabImp.Text = "Impianto"
        '
        'TEMA
        '
        Me.TEMA.BackColor = System.Drawing.SystemColors.Window
        Me.TEMA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TEMA.Cursor = System.Windows.Forms.Cursors.Default
        Me.TEMA.Enabled = False
        Me.TEMA.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TEMA.Location = New System.Drawing.Point(390, 0)
        Me.TEMA.Name = "TEMA"
        Me.TEMA.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TEMA.Size = New System.Drawing.Size(61, 21)
        Me.TEMA.TabIndex = 76
        Me.TEMA.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'LabITEM
        '
        Me.LabITEM.BackColor = System.Drawing.SystemColors.Window
        Me.LabITEM.Cursor = System.Windows.Forms.Cursors.Default
        Me.LabITEM.ForeColor = System.Drawing.SystemColors.WindowText
        Me.LabITEM.Location = New System.Drawing.Point(130, 0)
        Me.LabITEM.Name = "LabITEM"
        Me.LabITEM.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LabITEM.Size = New System.Drawing.Size(61, 21)
        Me.LabITEM.TabIndex = 75
        Me.LabITEM.Text = "ITEM"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(0, Byte))
        Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label7.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label7.Location = New System.Drawing.Point(0, 454)
        Me.Label7.Name = "Label7"
        Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label7.Size = New System.Drawing.Size(81, 21)
        Me.Label7.TabIndex = 31
        Me.Label7.Text = "Pagina 2 / 3"
        '
        '_LabFlui_18
        '
        Me._LabFlui_18.BackColor = System.Drawing.SystemColors.Window
        Me._LabFlui_18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._LabFlui_18.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabFlui_18.ForeColor = System.Drawing.SystemColors.WindowText
        Me.LabFlui.Add(18, Me._LabFlui_18)
        Me._LabFlui_18.Location = New System.Drawing.Point(140, 404)
        Me._LabFlui_18.Name = "_LabFlui_18"
        Me._LabFlui_18.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabFlui_18.Size = New System.Drawing.Size(31, 21)
        Me._LabFlui_18.TabIndex = 70
        Me._LabFlui_18.Text = "Tipo"
        '
        '_LabFlui_17
        '
        Me._LabFlui_17.BackColor = System.Drawing.SystemColors.Window
        Me._LabFlui_17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._LabFlui_17.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabFlui_17.ForeColor = System.Drawing.SystemColors.WindowText
        Me.LabFlui.Add(17, Me._LabFlui_17)
        Me._LabFlui_17.Location = New System.Drawing.Point(30, 404)
        Me._LabFlui_17.Name = "_LabFlui_17"
        Me._LabFlui_17.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabFlui_17.Size = New System.Drawing.Size(61, 21)
        Me._LabFlui_17.TabIndex = 69
        Me._LabFlui_17.Text = "Pas (mm)"
        '
        '_LabFlui_15
        '
        Me._LabFlui_15.BackColor = System.Drawing.SystemColors.Window
        Me._LabFlui_15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._LabFlui_15.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabFlui_15.ForeColor = System.Drawing.SystemColors.WindowText
        Me.LabFlui.Add(15, Me._LabFlui_15)
        Me._LabFlui_15.Location = New System.Drawing.Point(190, 384)
        Me._LabFlui_15.Name = "_LabFlui_15"
        Me._LabFlui_15.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabFlui_15.Size = New System.Drawing.Size(51, 21)
        Me._LabFlui_15.TabIndex = 65
        Me._LabFlui_15.Text = "Sp (mm)"
        '
        '_LabFlui_14
        '
        Me._LabFlui_14.BackColor = System.Drawing.SystemColors.Window
        Me._LabFlui_14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._LabFlui_14.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabFlui_14.ForeColor = System.Drawing.SystemColors.WindowText
        Me.LabFlui.Add(14, Me._LabFlui_14)
        Me._LabFlui_14.Location = New System.Drawing.Point(90, 384)
        Me._LabFlui_14.Name = "_LabFlui_14"
        Me._LabFlui_14.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabFlui_14.Size = New System.Drawing.Size(51, 21)
        Me._LabFlui_14.TabIndex = 64
        Me._LabFlui_14.Text = "D (mm)"
        '
        '_LabFlui_13
        '
        Me._LabFlui_13.BackColor = System.Drawing.SystemColors.Window
        Me._LabFlui_13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._LabFlui_13.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabFlui_13.ForeColor = System.Drawing.SystemColors.WindowText
        Me.LabFlui.Add(13, Me._LabFlui_13)
        Me._LabFlui_13.Location = New System.Drawing.Point(30, 384)
        Me._LabFlui_13.Name = "_LabFlui_13"
        Me._LabFlui_13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabFlui_13.Size = New System.Drawing.Size(21, 21)
        Me._LabFlui_13.TabIndex = 63
        Me._LabFlui_13.Text = "N°"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.Window
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label6.Location = New System.Drawing.Point(0, 384)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(31, 61)
        Me.Label6.TabIndex = 62
        Me.Label6.Text = "TUBI"
        '
        '_LabFlui_12
        '
        Me._LabFlui_12.BackColor = System.Drawing.SystemColors.Window
        Me._LabFlui_12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._LabFlui_12.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabFlui_12.ForeColor = System.Drawing.SystemColors.WindowText
        Me.LabFlui.Add(12, Me._LabFlui_12)
        Me._LabFlui_12.Location = New System.Drawing.Point(150, 364)
        Me._LabFlui_12.Name = "_LabFlui_12"
        Me._LabFlui_12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabFlui_12.Size = New System.Drawing.Size(41, 21)
        Me._LabFlui_12.TabIndex = 59
        Me._LabFlui_12.Text = "Codice"
        '
        '_LabFlui_11
        '
        Me._LabFlui_11.BackColor = System.Drawing.SystemColors.Window
        Me._LabFlui_11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._LabFlui_11.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabFlui_11.ForeColor = System.Drawing.SystemColors.WindowText
        Me.LabFlui.Add(11, Me._LabFlui_11)
        Me._LabFlui_11.Location = New System.Drawing.Point(0, 300)
        Me._LabFlui_11.Name = "_LabFlui_11"
        Me._LabFlui_11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabFlui_11.Size = New System.Drawing.Size(191, 21)
        Me._LabFlui_11.TabIndex = 58
        Me._LabFlui_11.Text = "Efficienza di saldatura"
        '
        '_LabFlui_10
        '
        Me._LabFlui_10.BackColor = System.Drawing.SystemColors.Window
        Me._LabFlui_10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._LabFlui_10.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabFlui_10.ForeColor = System.Drawing.SystemColors.WindowText
        Me.LabFlui.Add(10, Me._LabFlui_10)
        Me._LabFlui_10.Location = New System.Drawing.Point(0, 320)
        Me._LabFlui_10.Name = "_LabFlui_10"
        Me._LabFlui_10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabFlui_10.Size = New System.Drawing.Size(191, 21)
        Me._LabFlui_10.TabIndex = 57
        Me._LabFlui_10.Text = "Corrosione interna/esterna (mm)"
        '
        '_LabFlui_9
        '
        Me._LabFlui_9.BackColor = System.Drawing.SystemColors.Window
        Me._LabFlui_9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._LabFlui_9.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabFlui_9.ForeColor = System.Drawing.SystemColors.WindowText
        Me.LabFlui.Add(9, Me._LabFlui_9)
        Me._LabFlui_9.Location = New System.Drawing.Point(0, 280)
        Me._LabFlui_9.Name = "_LabFlui_9"
        Me._LabFlui_9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabFlui_9.Size = New System.Drawing.Size(191, 21)
        Me._LabFlui_9.TabIndex = 44
        Me._LabFlui_9.Text = "PWHT  /  Esame RX"
        '
        '_LabFlui_8
        '
        Me._LabFlui_8.BackColor = System.Drawing.SystemColors.Window
        Me._LabFlui_8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._LabFlui_8.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabFlui_8.ForeColor = System.Drawing.SystemColors.WindowText
        Me.LabFlui.Add(8, Me._LabFlui_8)
        Me._LabFlui_8.Location = New System.Drawing.Point(40, 260)
        Me._LabFlui_8.Name = "_LabFlui_8"
        Me._LabFlui_8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabFlui_8.Size = New System.Drawing.Size(151, 21)
        Me._LabFlui_8.TabIndex = 52
        Me._LabFlui_8.Text = "di prova idraulica"
        '
        '_LabFlui_7
        '
        Me._LabFlui_7.BackColor = System.Drawing.SystemColors.Window
        Me._LabFlui_7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._LabFlui_7.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabFlui_7.ForeColor = System.Drawing.SystemColors.WindowText
        Me.LabFlui.Add(7, Me._LabFlui_7)
        Me._LabFlui_7.Location = New System.Drawing.Point(40, 240)
        Me._LabFlui_7.Name = "_LabFlui_7"
        Me._LabFlui_7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabFlui_7.Size = New System.Drawing.Size(151, 21)
        Me._LabFlui_7.TabIndex = 51
        Me._LabFlui_7.Text = "di esercizio"
        '
        '_LabFlui_6
        '
        Me._LabFlui_6.BackColor = System.Drawing.SystemColors.Window
        Me._LabFlui_6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._LabFlui_6.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabFlui_6.ForeColor = System.Drawing.SystemColors.WindowText
        Me.LabFlui.Add(6, Me._LabFlui_6)
        Me._LabFlui_6.Location = New System.Drawing.Point(40, 220)
        Me._LabFlui_6.Name = "_LabFlui_6"
        Me._LabFlui_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabFlui_6.Size = New System.Drawing.Size(151, 21)
        Me._LabFlui_6.TabIndex = 50
        Me._LabFlui_6.Text = "di progetto / vuoto"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.Window
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label5.Location = New System.Drawing.Point(0, 220)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(41, 61)
        Me.Label5.TabIndex = 49
        Me.Label5.Text = "PRES- SIONI (barg)"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Window
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label2.Location = New System.Drawing.Point(190, 80)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(131, 21)
        Me.Label2.TabIndex = 34
        Me.Label2.Text = "MANTELLO"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Window
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label3.Location = New System.Drawing.Point(320, 80)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(131, 21)
        Me.Label3.TabIndex = 35
        Me.Label3.Text = "TUBI"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Window
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label4.Location = New System.Drawing.Point(0, 100)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(41, 121)
        Me.Label4.TabIndex = 43
        Me.Label4.Text = "TEM- PERA- TURE (°C)"
        '
        '_LabFlui_5
        '
        Me._LabFlui_5.BackColor = System.Drawing.SystemColors.Window
        Me._LabFlui_5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._LabFlui_5.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabFlui_5.ForeColor = System.Drawing.SystemColors.WindowText
        Me.LabFlui.Add(5, Me._LabFlui_5)
        Me._LabFlui_5.Location = New System.Drawing.Point(40, 200)
        Me._LabFlui_5.Name = "_LabFlui_5"
        Me._LabFlui_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabFlui_5.Size = New System.Drawing.Size(151, 21)
        Me._LabFlui_5.TabIndex = 42
        Me._LabFlui_5.Text = "Piastra tubiera (progetto)"
        '
        '_LabFlui_4
        '
        Me._LabFlui_4.BackColor = System.Drawing.SystemColors.Window
        Me._LabFlui_4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._LabFlui_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabFlui_4.ForeColor = System.Drawing.SystemColors.WindowText
        Me.LabFlui.Add(4, Me._LabFlui_4)
        Me._LabFlui_4.Location = New System.Drawing.Point(40, 180)
        Me._LabFlui_4.Name = "_LabFlui_4"
        Me._LabFlui_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabFlui_4.Size = New System.Drawing.Size(151, 21)
        Me._LabFlui_4.TabIndex = 41
        Me._LabFlui_4.Text = "Avviamento lato mantello"
        '
        '_LabFlui_3
        '
        Me._LabFlui_3.BackColor = System.Drawing.SystemColors.Window
        Me._LabFlui_3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._LabFlui_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabFlui_3.ForeColor = System.Drawing.SystemColors.WindowText
        Me.LabFlui.Add(3, Me._LabFlui_3)
        Me._LabFlui_3.Location = New System.Drawing.Point(40, 160)
        Me._LabFlui_3.Name = "_LabFlui_3"
        Me._LabFlui_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabFlui_3.Size = New System.Drawing.Size(151, 21)
        Me._LabFlui_3.TabIndex = 40
        Me._LabFlui_3.Text = "Avviamento lato tubi"
        '
        '_LabFlui_2
        '
        Me._LabFlui_2.BackColor = System.Drawing.SystemColors.Window
        Me._LabFlui_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._LabFlui_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabFlui_2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.LabFlui.Add(2, Me._LabFlui_2)
        Me._LabFlui_2.Location = New System.Drawing.Point(40, 140)
        Me._LabFlui_2.Name = "_LabFlui_2"
        Me._LabFlui_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabFlui_2.Size = New System.Drawing.Size(151, 21)
        Me._LabFlui_2.TabIndex = 39
        Me._LabFlui_2.Text = "di esercizio (parete)"
        '
        '_LabFlui_1
        '
        Me._LabFlui_1.BackColor = System.Drawing.SystemColors.Window
        Me._LabFlui_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._LabFlui_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabFlui_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.LabFlui.Add(1, Me._LabFlui_1)
        Me._LabFlui_1.Location = New System.Drawing.Point(40, 120)
        Me._LabFlui_1.Name = "_LabFlui_1"
        Me._LabFlui_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabFlui_1.Size = New System.Drawing.Size(151, 21)
        Me._LabFlui_1.TabIndex = 38
        Me._LabFlui_1.Text = "di progetto"
        '
        '_LabFlui_0
        '
        Me._LabFlui_0.BackColor = System.Drawing.SystemColors.Window
        Me._LabFlui_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._LabFlui_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabFlui_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me.LabFlui.Add(0, Me._LabFlui_0)
        Me._LabFlui_0.Location = New System.Drawing.Point(40, 100)
        Me._LabFlui_0.Name = "_LabFlui_0"
        Me._LabFlui_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabFlui_0.Size = New System.Drawing.Size(151, 21)
        Me._LabFlui_0.TabIndex = 37
        Me._LabFlui_0.Text = "Minima di progetto"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Window
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label1.Location = New System.Drawing.Point(0, 80)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(191, 21)
        Me.Label1.TabIndex = 33
        Me.Label1.Text = "LATO"
        '
        'LabServ
        '
        Me.LabServ.BackColor = System.Drawing.SystemColors.Window
        Me.LabServ.Cursor = System.Windows.Forms.Cursors.Default
        Me.LabServ.ForeColor = System.Drawing.SystemColors.WindowText
        Me.LabServ.Location = New System.Drawing.Point(130, 60)
        Me.LabServ.Name = "LabServ"
        Me.LabServ.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LabServ.Size = New System.Drawing.Size(51, 21)
        Me.LabServ.TabIndex = 77
        Me.LabServ.Text = "Servizio"
        '
        'ComboM
        '
        '
        'ComboT
        '
        '
        'Option1
        '
        '
        'ValorM
        '
        '
        'ValorT
        '
        '
        'DataShe1
        '
        Me.AcceptButton = Me.Avanti
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.ClientSize = New System.Drawing.Size(457, 477)
        Me.Controls.Add(Me.TipoP)
        Me.Controls.Add(Me.Toller)
        Me.Controls.Add(Me.TextBWG)
        Me.Controls.Add(Me.ClasseTEMA)
        Me.Controls.Add(Me.cmdPHTubi)
        Me.Controls.Add(Me.cmdPHMant)
        Me.Controls.Add(Me.ProvIdrTubi)
        Me.Controls.Add(Me.ProvIdrMant)
        Me.Controls.Add(Me.TexItem)
        Me.Controls.Add(Me.Cliente)
        Me.Controls.Add(Me.TexImp)
        Me.Controls.Add(Me.TexServ)
        Me.Controls.Add(Me._ComboM_5)
        Me.Controls.Add(Me._ComboT_3)
        Me.Controls.Add(Me._ComboM_3)
        Me.Controls.Add(Me._ComboT_2)
        Me.Controls.Add(Me._ComboM_2)
        Me.Controls.Add(Me._ComboT_1)
        Me.Controls.Add(Me._ComboT_0)
        Me.Controls.Add(Me._ComboM_1)
        Me.Controls.Add(Me._ComboM_0)
        Me.Controls.Add(Me.Indietro)
        Me.Controls.Add(Me.Avanti)
        Me.Controls.Add(Me.Frame1)
        Me.Controls.Add(Me.Command3D2)
        Me.Controls.Add(Me.Command3D1)
        Me.Controls.Add(Me._ValorM_5)
        Me.Controls.Add(Me._ValorM_16)
        Me.Controls.Add(Me._ValorM_15)
        Me.Controls.Add(Me._ValorM_14)
        Me.Controls.Add(Me._ValorM_13)
        Me.Controls.Add(Me._ValorM_12)
        Me.Controls.Add(Me._ValorT_11)
        Me.Controls.Add(Me._ValorM_11)
        Me.Controls.Add(Me._ValorT_10)
        Me.Controls.Add(Me._ValorT_9)
        Me.Controls.Add(Me._ValorM_10)
        Me.Controls.Add(Me._ValorM_9)
        Me.Controls.Add(Me._ValorT_7)
        Me.Controls.Add(Me._ValorT_6)
        Me.Controls.Add(Me._ValorT_5)
        Me.Controls.Add(Me._ValorT_4)
        Me.Controls.Add(Me._ValorT_3)
        Me.Controls.Add(Me._ValorM_7)
        Me.Controls.Add(Me._ValorM_6)
        Me.Controls.Add(Me._ValorM_4)
        Me.Controls.Add(Me._ValorM_3)
        Me.Controls.Add(Me._ValorT_2)
        Me.Controls.Add(Me._ValorT_1)
        Me.Controls.Add(Me._ValorM_2)
        Me.Controls.Add(Me._ValorM_1)
        Me.Controls.Add(Me._ValorT_0)
        Me.Controls.Add(Me._ValorM_0)
        Me.Controls.Add(Me._ValorT_8)
        Me.Controls.Add(Me._ValorM_8)
        Me.Controls.Add(Me._LabFlui_20)
        Me.Controls.Add(Me._LabFlui_16)
        Me.Controls.Add(Me._LabFlui_19)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.LabTEMA)
        Me.Controls.Add(Me.LabClie)
        Me.Controls.Add(Me.LabImp)
        Me.Controls.Add(Me.TEMA)
        Me.Controls.Add(Me.LabITEM)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me._LabFlui_18)
        Me.Controls.Add(Me._LabFlui_17)
        Me.Controls.Add(Me._LabFlui_15)
        Me.Controls.Add(Me._LabFlui_14)
        Me.Controls.Add(Me._LabFlui_13)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me._LabFlui_12)
        Me.Controls.Add(Me._LabFlui_11)
        Me.Controls.Add(Me._LabFlui_10)
        Me.Controls.Add(Me._LabFlui_9)
        Me.Controls.Add(Me._LabFlui_8)
        Me.Controls.Add(Me._LabFlui_7)
        Me.Controls.Add(Me._LabFlui_6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me._LabFlui_5)
        Me.Controls.Add(Me._LabFlui_4)
        Me.Controls.Add(Me._LabFlui_3)
        Me.Controls.Add(Me._LabFlui_2)
        Me.Controls.Add(Me._LabFlui_1)
        Me.Controls.Add(Me._LabFlui_0)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LabServ)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.ForeColor = System.Drawing.SystemColors.WindowText
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Location = New System.Drawing.Point(172, 23)
        Me.Name = "DataShe1"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Foglio dati - Dati di progetto"
        Me.Frame1.ResumeLayout(False)
        For Each control In ComboM.Values
            AddHandler control.SelectedIndexChanged, AddressOf ComboM_SelectedIndexChanged
        Next
        For Each control In ComboT.Values
            AddHandler control.SelectedIndexChanged, AddressOf ComboT_SelectedIndexChanged
        Next

        For Each control In Option1.Values
            AddHandler control.CheckedChanged, AddressOf Option1_CheckedChanged
        Next
        For Each control In ValorM.Values
            AddHandler control.TextChanged, AddressOf ValorM_Change
        Next
        For Each control In ValorT.Values
            AddHandler control.TextChanged, AddressOf ValorT_Change
        Next
        Me.ResumeLayout(False)

    End Sub
#End Region 
#Region "Supporto aggiornamento "
	Private Shared m_vb6FormDefInstance As DataShe1
	Private Shared m_InitializingDefInstance As Boolean
	Public Shared Property DefInstance() As DataShe1
		Get
			If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
				m_InitializingDefInstance = True
				m_vb6FormDefInstance = New DataShe1()
				m_InitializingDefInstance = False
			End If
			DefInstance = m_vb6FormDefInstance
		End Get
		Set
			m_vb6FormDefInstance = Value
		End Set
	End Property
#End Region 
	Private Sub Avanti_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Avanti.Click
		Hide()
		DataShe2.DefInstance.Show()
	End Sub
	
	'UPGRADE_WARNING: L'evento ClasseTEMA.SelectedIndexChanged può essere generato quando il form è inizializzato. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup2075"'
	Private Sub ClasseTEMA_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ClasseTEMA.SelectedIndexChanged
		If ClasseTEMA.SelectedIndex = 0 Then
            If DataSheet.DatiPrg.CodiceM > 10 Then DataSheet.DatiPrg.CodiceM = DataSheet.DatiPrg.CodiceM \ 10
            If DataSheet.DatiPrg.CodiceT > 10 Then DataSheet.DatiPrg.CodiceT = DataSheet.DatiPrg.CodiceT \ 10
        Else
            If DataSheet.DatiPrg.CodiceM > 10 Then
                DataSheet.DatiPrg.CodiceM = (DataSheet.DatiPrg.CodiceM \ 10) * 10 + ClasseTEMA.SelectedIndex
            Else
                DataSheet.DatiPrg.CodiceM = 10 * DataSheet.DatiPrg.CodiceM + ClasseTEMA.SelectedIndex
            End If
            If DataSheet.DatiPrg.CodiceT > 10 Then
                DataSheet.DatiPrg.CodiceT = (DataSheet.DatiPrg.CodiceT \ 10) * 10 + ClasseTEMA.SelectedIndex
            Else
                DataSheet.DatiPrg.CodiceT = 10 * DataSheet.DatiPrg.CodiceT + ClasseTEMA.SelectedIndex
            End If
        End If
    End Sub

    Private Sub cmdPHMant_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdPHMant.Click
        If InStr(cmdPHMant.Text, "V") Then
            ProvIdrMant.Enabled = True
            ProvIdrMant.Text = "0"
            ProvIdrMant.Tag = "Val"
            ProvIdrMant.Focus()
            cmdPHMant.Text = "&Code"
        Else
            ProvIdrMant.Enabled = False
            ProvIdrMant.Text = "As per Code"
            ProvIdrMant.Tag = "Code"
            cmdPHMant.Text = "&Val"
        End If
    End Sub

    Private Sub cmdPHTubi_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdPHTubi.Click
        If InStr(cmdPHTubi.Text, "V") Then
            cmdPHTubi.Text = "&Code"
            ProvIdrTubi.Enabled = True
            ProvIdrTubi.Text = "0"
            ProvIdrTubi.Tag = "Val"
            ProvIdrTubi.Focus()
        Else
            ProvIdrTubi.Enabled = False
            ProvIdrTubi.Text = "As per Code"
            ProvIdrTubi.Tag = "Code"
            cmdPHTubi.Text = "&Val"
        End If

    End Sub

    'UPGRADE_WARNING: L'evento ComboM.SelectedIndexChanged può essere generato quando il form è inizializzato. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup2075"'
    Private Sub ComboM_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Dim Index As Short = IndexedControls.IndexOf(ComboM, eventSender)
        Dim dummy As Short
        Select Case Index
            Case 0 'PHWT
                DataSheet.DatiSh0.PHWTMant = ComboM(Index).SelectedIndex
            Case 1 'RX
                DataSheet.DatiSh0.RXMant = ComboM(Index).SelectedIndex
            Case 2 'Codice
                If ClasseTEMA.SelectedIndex = 0 Then
                    DataSheet.DatiPrg.CodiceM = ComboM(Index).SelectedIndex + 1
                Else
                    DataSheet.DatiPrg.CodiceM = 10 * (ComboM(Index).SelectedIndex + 1) + ClasseTEMA.SelectedIndex + 1
                End If
            Case 3 'Vacuum
                Select Case ComboM(Index).SelectedIndex
                    Case 0 'No
                        If ComboT(Index).SelectedIndex = 0 Then
                            DataSheet.DatiPrg.Vacuum = 0
                        ElseIf ComboT(Index).SelectedIndex = 10 Then
                            DataSheet.DatiPrg.Vacuum = 2
                        Else
                            DataSheet.DatiPrg.Vacuum = 20 + ComboT(Index).SelectedIndex
                        End If
                    Case 10 'Full
                        If ComboT(Index).SelectedIndex = 0 Then
                            DataSheet.DatiPrg.Vacuum = 1
                        ElseIf ComboT(Index).SelectedIndex = 10 Then
                            DataSheet.DatiPrg.Vacuum = 3
                        Else
                            DataSheet.DatiPrg.Vacuum = 30 + ComboT(Index).SelectedIndex
                            dummy = 3 + ComboM(Index).SelectedIndex
                            If dummy > DataSheet.DatiPrg.Vacuum Then DataSheet.DatiPrg.Vacuum = dummy
                        End If
                    Case Else
                        If ComboT(Index).SelectedIndex = 0 Then
                            DataSheet.DatiPrg.Vacuum = 10 + ComboM(Index).SelectedIndex
                        ElseIf ComboT(Index).SelectedIndex = 10 Then
                            DataSheet.DatiPrg.Vacuum = 3
                        Else
                            DataSheet.DatiPrg.Vacuum = 30 + ComboT(Index).SelectedIndex
                            dummy = 30 + ComboM(Index).SelectedIndex
                            If dummy > DataSheet.DatiPrg.Vacuum Then DataSheet.DatiPrg.Vacuum = dummy
                        End If
                End Select
            Case 5 'giunto
                DataSheet.DatiPrg.TubiInform.TipoG = ComboM(Index).SelectedIndex * 10
                If ComboM(Index).SelectedIndex = 1 Or ComboM(Index).SelectedIndex = 2 Then
                    SaldMand.DefInstance.ShowDialog()
                End If
        End Select

    End Sub

    'UPGRADE_WARNING: L'evento ComboT.SelectedIndexChanged può essere generato quando il form è inizializzato. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup2075"'
    Private Sub ComboT_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Dim Index As Short = IndexedControls.IndexOf(ComboT, eventSender)
        Dim dummy As Short
        Select Case Index
            Case 0 'PHWT
                DataSheet.DatiSh0.PHWTTubi = ComboT(Index).SelectedIndex
            Case 1 'RX
                DataSheet.DatiSh0.RXTubi = ComboT(Index).SelectedIndex
            Case 2 'Codice
                If ClasseTEMA.SelectedIndex = 0 Then
                    DataSheet.DatiPrg.CodiceT = ComboT(Index).SelectedIndex + 1
                Else
                    DataSheet.DatiPrg.CodiceT = 10 * (ComboT(Index).SelectedIndex + 1) + ClasseTEMA.SelectedIndex + 1
                End If
            Case 3 'Vacuum
                Select Case ComboT(Index).SelectedIndex
                    Case 0 'No
                        If ComboM(Index).SelectedIndex = 0 Then
                            DataSheet.DatiPrg.Vacuum = 0
                        ElseIf ComboM(Index).SelectedIndex = 10 Then
                            DataSheet.DatiPrg.Vacuum = 1
                        Else
                            DataSheet.DatiPrg.Vacuum = 10 + ComboM(Index).SelectedIndex
                        End If
                    Case 10 'Full
                        If ComboM(Index).SelectedIndex = 0 Then
                            DataSheet.DatiPrg.Vacuum = 2
                        ElseIf ComboM(Index).SelectedIndex = 10 Then
                            DataSheet.DatiPrg.Vacuum = 3
                        Else
                            DataSheet.DatiPrg.Vacuum = 30 + ComboM(Index).SelectedIndex
                            dummy = 30 + ComboT(Index).SelectedIndex
                            If dummy > DataSheet.DatiPrg.Vacuum Then DataSheet.DatiPrg.Vacuum = dummy
                        End If
                    Case Else
                        If ComboM(Index).SelectedIndex = 0 Then
                            DataSheet.DatiPrg.Vacuum = 20 + ComboT(Index).SelectedIndex
                        ElseIf ComboM(Index).SelectedIndex = 10 Then
                            DataSheet.DatiPrg.Vacuum = 3
                        Else
                            DataSheet.DatiPrg.Vacuum = 30 + ComboM(Index).SelectedIndex
                            dummy = 30 + ComboT(Index).SelectedIndex
                            If dummy > DataSheet.DatiPrg.Vacuum Then DataSheet.DatiPrg.Vacuum = dummy
                        End If
                End Select
        End Select

    End Sub

    Private Sub Command3D1_ClickEvent(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command3D1.Click
        Dim objBWG As LibMat.clsBWG
        objBWG = New LibMat.clsBWG
        objBWG.DoveMotore = Monitor.Motore
        With objBWG
            .TipoMat = DataSheet.DatiPrg.TubiInform.TipoMat
            .Diam = Val(DataShe1.DefInstance.ValorM(13).Text)
            .Spess = Val(DataShe1.DefInstance.ValorM(14).Text)
            .TextBWG = DataShe1.DefInstance.TextBWG.Text
            .BWG = Val(.TextBWG)
            .UniMis = DataSheet.DatiPrg.UniMis
            .Mostra()
            DataSheet.DatiPrg.TubiInform.Diam = .Diam
            DataShe1.DefInstance.ValorM(13).Text = Str(.Diam)
            DataSheet.DatiPrg.TubiInform.Spess = .Spess
            DataShe1.DefInstance.ValorM(14).Text = Str(.Spess)
            DataSheet.DatiPrg.TubiInform.BWG = .BWG
            DataShe1.DefInstance.TextBWG.Text = .TextBWG
        End With
        objBWG = Nothing
    End Sub

    Private Sub Command3D2_ClickEvent(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command3D2.Click
        frmTipoP.DefInstance.ShowDialog()
    End Sub

    Private Sub DataShe1_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        ValorM(9).Text = "0" 'corr interna
        ValorM(10).Text = "0" 'corr esterna
        ValorT(9).Text = "0" 'corr interna
        ValorT(10).Text = "0" 'corr esterna
    End Sub

    Private Sub Indietro_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Indietro.Click
        Hide()
        DataShee.DefInstance.Show()
    End Sub

    'UPGRADE_WARNING: L'evento Option1.CheckedChanged può essere generato quando il form è inizializzato. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup2075"'
    Private Sub Option1_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        If eventSender.Checked Then
            Dim Index As Short = IndexedControls.IndexOf(Option1, eventSender)
            DataShee.DefInstance.Option1(Index).Checked = True
        End If
    End Sub

    'UPGRADE_WARNING: L'evento ProvIdrMant.TextChanged può essere generato quando il form è inizializzato. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup2075"'
    Private Sub ProvIdrMant_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ProvIdrMant.TextChanged
        DataSheet.DatiPrg.PHyMant = Val(ProvIdrMant.Text)

    End Sub

    'UPGRADE_WARNING: L'evento ProvIdrTubi.TextChanged può essere generato quando il form è inizializzato. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup2075"'
    Private Sub ProvIdrTubi_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ProvIdrTubi.TextChanged
        DataSheet.DatiPrg.PHyTubi = Val(ProvIdrTubi.Text)

    End Sub

    'UPGRADE_WARNING: L'evento Toller.SelectedIndexChanged può essere generato quando il form è inizializzato. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup2075"'
    Private Sub Toller_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Toller.SelectedIndexChanged
        DataSheet.DatiPrg.TubiInform.Toller = Toller.SelectedIndex
    End Sub

    Private Sub ValorM_Change(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Dim Index As Short = IndexedControls.IndexOf(ValorM, eventSender)
        Dim Valor As Single
        Valor = Val(DataShe1.DefInstance.ValorM(Index).Text)
        Select Case Index
            Case 0 : DataSheet.DatiSh0.TempMantMin = Valor
            Case 1 : DataSheet.DatiPrg.TempMant = Valor
            Case 2 : DataSheet.DatiSh0.TempMantEse = Valor
            Case 3 : DataSheet.DatiSh0.TempMantStTubi = Valor
            Case 4 : DataSheet.DatiSh0.TempMantStMant = Valor
            Case 5 : DataSheet.DatiSh0.TempProgPiastra = Valor
            Case 6 : DataSheet.DatiPrg.PressMant = Valor
            Case 7 : DataSheet.DatiSh0.PressMantEse = Valor
            Case 8 : DataSheet.DatiPrg.NPassMant = Valor
            Case 9 : DataSheet.DatiPrg.CorrMant = Valor
            Case 10 : DataSheet.DatiPrg.CorrExtMant = Valor
            Case 11 : DataSheet.DatiPrg.EffMant = Valor
            Case 12 : DataSheet.DatiPrg.TubiInform.Numero = Valor
            Case 13 : DataSheet.DatiPrg.TubiInform.Diam = Valor
            Case 14 : DataSheet.DatiPrg.TubiInform.Spess = Valor
            Case 15 : DataSheet.DatiPrg.TubiInform.Lungh = Valor
            Case 16 : DataSheet.DatiPrg.TubiInform.Pitch = Valor
        End Select
    End Sub

    Private Sub ValorT_Change(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Dim Index As Short = IndexedControls.IndexOf(ValorT, eventSender)
        Dim Valor As Single
        Valor = Val(DataShe1.DefInstance.ValorT(Index).Text)
        Select Case Index
            Case 0 : DataSheet.DatiSh0.TempTubiMin = Valor
            Case 1 : DataSheet.DatiPrg.TempTubi = Valor
            Case 2 : DataSheet.DatiSh0.TempTubiEse = Valor
            Case 3 : DataSheet.DatiSh0.TempTubiStTubi = Valor
            Case 4 : DataSheet.DatiSh0.TempTubiStMant = Valor
            Case 6 : DataSheet.DatiPrg.PressTubi = Valor
            Case 7 : DataSheet.DatiSh0.PressTubiEse = Valor
            Case 8 : DataSheet.DatiPrg.NPassTubi = Valor
            Case 9 : DataSheet.DatiPrg.CorrTubi = Valor
            Case 10 : DataSheet.DatiPrg.CorrExtTubi = Valor
            Case 11 : DataSheet.DatiPrg.EffTubi = Valor
        End Select

    End Sub
End Class