Option Strict Off
Option Explicit On 
Imports System.Windows.forms
Friend Class frmTEMA
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
    Public WithEvents _Tre_8 As System.Windows.Forms.Button
	Public WithEvents _Tre_7 As System.Windows.Forms.Button
	Public WithEvents _Tre_6 As System.Windows.Forms.Button
	Public WithEvents _Tre_5 As System.Windows.Forms.Button
	Public WithEvents _Tre_4 As System.Windows.Forms.Button
	Public WithEvents _Tre_3 As System.Windows.Forms.Button
	Public WithEvents _Tre_2 As System.Windows.Forms.Button
	Public WithEvents _Tre_1 As System.Windows.Forms.Button
	Public WithEvents _Tre_0 As System.Windows.Forms.Button
    Public WithEvents Frame3D3 As Panel
    Public WithEvents _Due_7 As System.Windows.Forms.Button
    Public WithEvents _Due_6 As System.Windows.Forms.Button
    Public WithEvents _Due_5 As System.Windows.Forms.Button
    Public WithEvents _Due_4 As System.Windows.Forms.Button
    Public WithEvents _Due_3 As System.Windows.Forms.Button
    Public WithEvents _Due_2 As System.Windows.Forms.Button
    Public WithEvents _Due_1 As System.Windows.Forms.Button
    Public WithEvents _Due_0 As System.Windows.Forms.Button
    Public WithEvents _Uno_5 As System.Windows.Forms.Button
    Public WithEvents _Uno_4 As System.Windows.Forms.Button
    Public WithEvents _Uno_3 As System.Windows.Forms.Button
    Public WithEvents _Uno_2 As System.Windows.Forms.Button
    Public WithEvents _Uno_1 As System.Windows.Forms.Button
    Public WithEvents _Uno_0 As System.Windows.Forms.Button
    Public WithEvents Command1 As System.Windows.Forms.Button
    Public WithEvents _pctFig_2 As System.Windows.Forms.PictureBox
    Public WithEvents _pctFig_1 As System.Windows.Forms.PictureBox
    Public WithEvents _pctFig_0 As System.Windows.Forms.PictureBox
    Public WithEvents Frame3D1 As Panel
    Public WithEvents Frame3D2 As Panel
    Public WithEvents _lblLettera_2 As System.Windows.Forms.Label
    Public WithEvents _lblLettera_1 As System.Windows.Forms.Label
    Public WithEvents _lblLettera_0 As System.Windows.Forms.Label
    Public WithEvents _lblSpiega_2 As System.Windows.Forms.Label
    Public WithEvents _lblSpiega_1 As System.Windows.Forms.Label
    Public WithEvents _lblSpiega_0 As System.Windows.Forms.Label
    Public Due As New System.Collections.Generic.Dictionary(Of Integer, Button)
    Public Tre As New System.Collections.Generic.Dictionary(Of Integer, Button)
    Public Uno As New System.Collections.Generic.Dictionary(Of Integer, Button)
    Public lblLettera As New System.Collections.Generic.Dictionary(Of Integer, Label)
    Public lblSpiega As New System.Collections.Generic.Dictionary(Of Integer, Label)
    Public pctFig As New System.Collections.Generic.Dictionary(Of Integer, PictureBox)
    'NOTA: la routine seguente è richiesta dalla progettazione Windows Form.
    'Può essere modificata utilizzando la finestra di progettazione Windows Form.
    'Non modificarla mediante l'editor di codice.
    Friend WithEvents cmd1Up As System.Windows.Forms.Button
    Friend WithEvents cmd2Up As System.Windows.Forms.Button
    Friend WithEvents cmd3Up As System.Windows.Forms.Button
    Friend WithEvents cmd1Down As System.Windows.Forms.Button
    Friend WithEvents cmd2Down As System.Windows.Forms.Button
    Friend WithEvents cmd3Down As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmTEMA))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me._Tre_8 = New System.Windows.Forms.Button
        Me._Tre_7 = New System.Windows.Forms.Button
        Me._Tre_6 = New System.Windows.Forms.Button
        Me._Tre_5 = New System.Windows.Forms.Button
        Me._Tre_4 = New System.Windows.Forms.Button
        Me._Tre_3 = New System.Windows.Forms.Button
        Me._Tre_2 = New System.Windows.Forms.Button
        Me._Tre_1 = New System.Windows.Forms.Button
        Me._Tre_0 = New System.Windows.Forms.Button
        Me.Frame3D3 = New System.Windows.Forms.Panel
        Me._Due_7 = New System.Windows.Forms.Button
        Me._Due_6 = New System.Windows.Forms.Button
        Me._Due_5 = New System.Windows.Forms.Button
        Me._Due_4 = New System.Windows.Forms.Button
        Me._Due_3 = New System.Windows.Forms.Button
        Me._Due_2 = New System.Windows.Forms.Button
        Me._Due_1 = New System.Windows.Forms.Button
        Me._Due_0 = New System.Windows.Forms.Button
        Me._Uno_5 = New System.Windows.Forms.Button
        Me._Uno_4 = New System.Windows.Forms.Button
        Me._Uno_3 = New System.Windows.Forms.Button
        Me._Uno_2 = New System.Windows.Forms.Button
        Me._Uno_1 = New System.Windows.Forms.Button
        Me._Uno_0 = New System.Windows.Forms.Button
        Me.Command1 = New System.Windows.Forms.Button
        Me._pctFig_2 = New System.Windows.Forms.PictureBox
        Me._pctFig_1 = New System.Windows.Forms.PictureBox
        Me._pctFig_0 = New System.Windows.Forms.PictureBox
        Me.Frame3D1 = New System.Windows.Forms.Panel
        Me.Frame3D2 = New System.Windows.Forms.Panel
        Me._lblLettera_2 = New System.Windows.Forms.Label
        Me._lblLettera_1 = New System.Windows.Forms.Label
        Me._lblLettera_0 = New System.Windows.Forms.Label
        Me._lblSpiega_2 = New System.Windows.Forms.Label
        Me._lblSpiega_1 = New System.Windows.Forms.Label
        Me._lblSpiega_0 = New System.Windows.Forms.Label
        Me.cmd1Up = New System.Windows.Forms.Button
        Me.cmd2Up = New System.Windows.Forms.Button
        Me.cmd3Up = New System.Windows.Forms.Button
        Me.cmd1Down = New System.Windows.Forms.Button
        Me.cmd2Down = New System.Windows.Forms.Button
        Me.cmd3Down = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        '_Tre_8
        '
        Me._Tre_8.BackColor = System.Drawing.SystemColors.Control
        Me._Tre_8.Cursor = System.Windows.Forms.Cursors.Default
        Me._Tre_8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Tre.Add(8, Me._Tre_8)
        Me._Tre_8.Location = New System.Drawing.Point(520, 310)
        Me._Tre_8.Name = "_Tre_8"
        Me._Tre_8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Tre_8.Size = New System.Drawing.Size(31, 31)
        Me._Tre_8.TabIndex = 35
        Me._Tre_8.Text = "-"
        '
        '_Tre_7
        '
        Me._Tre_7.BackColor = System.Drawing.SystemColors.Control
        Me._Tre_7.Cursor = System.Windows.Forms.Cursors.Default
        Me._Tre_7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Tre.Add(7, Me._Tre_7)
        Me._Tre_7.Location = New System.Drawing.Point(480, 310)
        Me._Tre_7.Name = "_Tre_7"
        Me._Tre_7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Tre_7.Size = New System.Drawing.Size(31, 31)
        Me._Tre_7.TabIndex = 34
        Me._Tre_7.Text = "W"
        '
        '_Tre_6
        '
        Me._Tre_6.BackColor = System.Drawing.SystemColors.Control
        Me._Tre_6.Cursor = System.Windows.Forms.Cursors.Default
        Me._Tre_6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Tre.Add(6, Me._Tre_6)
        Me._Tre_6.Location = New System.Drawing.Point(440, 310)
        Me._Tre_6.Name = "_Tre_6"
        Me._Tre_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Tre_6.Size = New System.Drawing.Size(31, 31)
        Me._Tre_6.TabIndex = 33
        Me._Tre_6.Text = "U"
        '
        '_Tre_5
        '
        Me._Tre_5.BackColor = System.Drawing.SystemColors.Control
        Me._Tre_5.Cursor = System.Windows.Forms.Cursors.Default
        Me._Tre_5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Tre.Add(5, Me._Tre_5)
        Me._Tre_5.Location = New System.Drawing.Point(520, 270)
        Me._Tre_5.Name = "_Tre_5"
        Me._Tre_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Tre_5.Size = New System.Drawing.Size(31, 31)
        Me._Tre_5.TabIndex = 32
        Me._Tre_5.Text = "T"
        '
        '_Tre_4
        '
        Me._Tre_4.BackColor = System.Drawing.SystemColors.Control
        Me._Tre_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._Tre_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Tre.Add(4, Me._Tre_4)
        Me._Tre_4.Location = New System.Drawing.Point(480, 270)
        Me._Tre_4.Name = "_Tre_4"
        Me._Tre_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Tre_4.Size = New System.Drawing.Size(31, 31)
        Me._Tre_4.TabIndex = 31
        Me._Tre_4.Text = "S"
        '
        '_Tre_3
        '
        Me._Tre_3.BackColor = System.Drawing.SystemColors.Control
        Me._Tre_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._Tre_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Tre.Add(3, Me._Tre_3)
        Me._Tre_3.Location = New System.Drawing.Point(440, 270)
        Me._Tre_3.Name = "_Tre_3"
        Me._Tre_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Tre_3.Size = New System.Drawing.Size(31, 31)
        Me._Tre_3.TabIndex = 30
        Me._Tre_3.Text = "P"
        '
        '_Tre_2
        '
        Me._Tre_2.BackColor = System.Drawing.SystemColors.Control
        Me._Tre_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._Tre_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Tre.Add(2, Me._Tre_2)
        Me._Tre_2.Location = New System.Drawing.Point(520, 230)
        Me._Tre_2.Name = "_Tre_2"
        Me._Tre_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Tre_2.Size = New System.Drawing.Size(31, 31)
        Me._Tre_2.TabIndex = 29
        Me._Tre_2.Text = "N"
        '
        '_Tre_1
        '
        Me._Tre_1.BackColor = System.Drawing.SystemColors.Control
        Me._Tre_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._Tre_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Tre.Add(1, Me._Tre_1)
        Me._Tre_1.Location = New System.Drawing.Point(480, 230)
        Me._Tre_1.Name = "_Tre_1"
        Me._Tre_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Tre_1.Size = New System.Drawing.Size(31, 31)
        Me._Tre_1.TabIndex = 28
        Me._Tre_1.Text = "M"
        '
        '_Tre_0
        '
        Me._Tre_0.BackColor = System.Drawing.SystemColors.Control
        Me._Tre_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Tre_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Tre.Add(0, Me._Tre_0)
        Me._Tre_0.Location = New System.Drawing.Point(440, 230)
        Me._Tre_0.Name = "_Tre_0"
        Me._Tre_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Tre_0.Size = New System.Drawing.Size(31, 31)
        Me._Tre_0.TabIndex = 27
        Me._Tre_0.Text = "L"
        '
        'Frame3D3
        '
        Me.Frame3D3.BackColor = System.Drawing.SystemColors.Control
        Me.Frame3D3.Location = New System.Drawing.Point(430, 220)
        Me.Frame3D3.Name = "Frame3D3"
        Me.Frame3D3.Size = New System.Drawing.Size(131, 131)
        Me.Frame3D3.TabIndex = 26
        '
        '_Due_7
        '
        Me._Due_7.BackColor = System.Drawing.SystemColors.Control
        Me._Due_7.Cursor = System.Windows.Forms.Cursors.Default
        Me._Due_7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Due.Add(7, Me._Due_7)
        Me._Due_7.Location = New System.Drawing.Point(340, 270)
        Me._Due_7.Name = "_Due_7"
        Me._Due_7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Due_7.Size = New System.Drawing.Size(31, 31)
        Me._Due_7.TabIndex = 23
        Me._Due_7.Text = "-"
        '
        '_Due_6
        '
        Me._Due_6.BackColor = System.Drawing.SystemColors.Control
        Me._Due_6.Cursor = System.Windows.Forms.Cursors.Default
        Me._Due_6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Due.Add(6, Me._Due_6)
        Me._Due_6.Location = New System.Drawing.Point(300, 270)
        Me._Due_6.Name = "_Due_6"
        Me._Due_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Due_6.Size = New System.Drawing.Size(31, 31)
        Me._Due_6.TabIndex = 22
        Me._Due_6.Text = "X"
        '
        '_Due_5
        '
        Me._Due_5.BackColor = System.Drawing.SystemColors.Control
        Me._Due_5.Cursor = System.Windows.Forms.Cursors.Default
        Me._Due_5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Due.Add(5, Me._Due_5)
        Me._Due_5.Location = New System.Drawing.Point(260, 270)
        Me._Due_5.Name = "_Due_5"
        Me._Due_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Due_5.Size = New System.Drawing.Size(31, 31)
        Me._Due_5.TabIndex = 21
        Me._Due_5.Text = "K"
        '
        '_Due_4
        '
        Me._Due_4.BackColor = System.Drawing.SystemColors.Control
        Me._Due_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._Due_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Due.Add(4, Me._Due_4)
        Me._Due_4.Location = New System.Drawing.Point(220, 270)
        Me._Due_4.Name = "_Due_4"
        Me._Due_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Due_4.Size = New System.Drawing.Size(31, 31)
        Me._Due_4.TabIndex = 20
        Me._Due_4.Text = "J"
        '
        '_Due_3
        '
        Me._Due_3.BackColor = System.Drawing.SystemColors.Control
        Me._Due_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._Due_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Due.Add(3, Me._Due_3)
        Me._Due_3.Location = New System.Drawing.Point(340, 230)
        Me._Due_3.Name = "_Due_3"
        Me._Due_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Due_3.Size = New System.Drawing.Size(31, 31)
        Me._Due_3.TabIndex = 19
        Me._Due_3.Text = "H"
        '
        '_Due_2
        '
        Me._Due_2.BackColor = System.Drawing.SystemColors.Control
        Me._Due_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._Due_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Due.Add(2, Me._Due_2)
        Me._Due_2.Location = New System.Drawing.Point(300, 230)
        Me._Due_2.Name = "_Due_2"
        Me._Due_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Due_2.Size = New System.Drawing.Size(31, 31)
        Me._Due_2.TabIndex = 18
        Me._Due_2.Text = "G"
        '
        '_Due_1
        '
        Me._Due_1.BackColor = System.Drawing.SystemColors.Control
        Me._Due_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._Due_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Due.Add(1, Me._Due_1)
        Me._Due_1.Location = New System.Drawing.Point(260, 230)
        Me._Due_1.Name = "_Due_1"
        Me._Due_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Due_1.Size = New System.Drawing.Size(31, 31)
        Me._Due_1.TabIndex = 17
        Me._Due_1.Text = "F"
        '
        '_Due_0
        '
        Me._Due_0.BackColor = System.Drawing.SystemColors.Control
        Me._Due_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Due_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Due.Add(0, Me._Due_0)
        Me._Due_0.Location = New System.Drawing.Point(220, 230)
        Me._Due_0.Name = "_Due_0"
        Me._Due_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Due_0.Size = New System.Drawing.Size(31, 31)
        Me._Due_0.TabIndex = 16
        Me._Due_0.Text = "E"
        '
        '_Uno_5
        '
        Me._Uno_5.BackColor = System.Drawing.SystemColors.Control
        Me._Uno_5.Cursor = System.Windows.Forms.Cursors.Default
        Me._Uno_5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Uno.Add(5, Me._Uno_5)
        Me._Uno_5.Location = New System.Drawing.Point(120, 270)
        Me._Uno_5.Name = "_Uno_5"
        Me._Uno_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Uno_5.Size = New System.Drawing.Size(31, 31)
        Me._Uno_5.TabIndex = 15
        Me._Uno_5.Text = "-"
        '
        '_Uno_4
        '
        Me._Uno_4.BackColor = System.Drawing.SystemColors.Control
        Me._Uno_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._Uno_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Uno.Add(4, Me._Uno_4)
        Me._Uno_4.Location = New System.Drawing.Point(80, 270)
        Me._Uno_4.Name = "_Uno_4"
        Me._Uno_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Uno_4.Size = New System.Drawing.Size(31, 31)
        Me._Uno_4.TabIndex = 14
        Me._Uno_4.Text = "D"
        '
        '_Uno_3
        '
        Me._Uno_3.BackColor = System.Drawing.SystemColors.Control
        Me._Uno_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._Uno_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Uno.Add(3, Me._Uno_3)
        Me._Uno_3.Location = New System.Drawing.Point(40, 270)
        Me._Uno_3.Name = "_Uno_3"
        Me._Uno_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Uno_3.Size = New System.Drawing.Size(31, 31)
        Me._Uno_3.TabIndex = 13
        Me._Uno_3.Text = "N"
        '
        '_Uno_2
        '
        Me._Uno_2.BackColor = System.Drawing.SystemColors.Control
        Me._Uno_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._Uno_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Uno.Add(2, Me._Uno_2)
        Me._Uno_2.Location = New System.Drawing.Point(120, 230)
        Me._Uno_2.Name = "_Uno_2"
        Me._Uno_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Uno_2.Size = New System.Drawing.Size(31, 31)
        Me._Uno_2.TabIndex = 12
        Me._Uno_2.Text = "C"
        '
        '_Uno_1
        '
        Me._Uno_1.BackColor = System.Drawing.SystemColors.Control
        Me._Uno_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._Uno_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Uno.Add(1, Me._Uno_1)
        Me._Uno_1.Location = New System.Drawing.Point(80, 230)
        Me._Uno_1.Name = "_Uno_1"
        Me._Uno_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Uno_1.Size = New System.Drawing.Size(31, 31)
        Me._Uno_1.TabIndex = 11
        Me._Uno_1.Text = "B"
        '
        '_Uno_0
        '
        Me._Uno_0.BackColor = System.Drawing.SystemColors.Control
        Me._Uno_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Uno_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Uno.Add(0, Me._Uno_0)
        Me._Uno_0.Location = New System.Drawing.Point(40, 230)
        Me._Uno_0.Name = "_Uno_0"
        Me._Uno_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Uno_0.Size = New System.Drawing.Size(31, 31)
        Me._Uno_0.TabIndex = 10
        Me._Uno_0.Text = "A"
        '
        'Command1
        '
        Me.Command1.BackColor = System.Drawing.SystemColors.Control
        Me.Command1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command1.Location = New System.Drawing.Point(230, 320)
        Me.Command1.Name = "Command1"
        Me.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command1.Size = New System.Drawing.Size(121, 31)
        Me.Command1.TabIndex = 6
        Me.Command1.Text = "&OK"
        '
        '_pctFig_2
        '
        Me._pctFig_2.BackColor = System.Drawing.SystemColors.Window
        Me._pctFig_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._pctFig_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._pctFig_2.ForeColor = System.Drawing.SystemColors.WindowText
        Me._pctFig_2.Image = CType(resources.GetObject("_pctFig_2.Image"), System.Drawing.Image)
        Me.pctFig.Add(2, Me._pctFig_2)
        Me._pctFig_2.Location = New System.Drawing.Point(400, 0)
        Me._pctFig_2.Name = "_pctFig_2"
        Me._pctFig_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._pctFig_2.Size = New System.Drawing.Size(181, 171)
        Me._pctFig_2.TabIndex = 2
        Me._pctFig_2.TabStop = False
        '
        '_pctFig_1
        '
        Me._pctFig_1.BackColor = System.Drawing.SystemColors.Window
        Me._pctFig_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._pctFig_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._pctFig_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me._pctFig_1.Image = CType(resources.GetObject("_pctFig_1.Image"), System.Drawing.Image)
        Me.pctFig.Add(1, Me._pctFig_1)
        Me._pctFig_1.Location = New System.Drawing.Point(180, 0)
        Me._pctFig_1.Name = "_pctFig_1"
        Me._pctFig_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._pctFig_1.Size = New System.Drawing.Size(221, 171)
        Me._pctFig_1.TabIndex = 1
        Me._pctFig_1.TabStop = False
        '
        '_pctFig_0
        '
        Me._pctFig_0.BackColor = System.Drawing.SystemColors.Window
        Me._pctFig_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._pctFig_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._pctFig_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._pctFig_0.Image = CType(resources.GetObject("_pctFig_0.Image"), System.Drawing.Image)
        Me.pctFig.Add(0, Me._pctFig_0)
        Me._pctFig_0.Location = New System.Drawing.Point(0, 0)
        Me._pctFig_0.Name = "_pctFig_0"
        Me._pctFig_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._pctFig_0.Size = New System.Drawing.Size(181, 171)
        Me._pctFig_0.TabIndex = 0
        Me._pctFig_0.TabStop = False
        '
        'Frame3D1
        '
        Me.Frame3D1.BackColor = System.Drawing.SystemColors.Control
        Me.Frame3D1.Location = New System.Drawing.Point(30, 220)
        Me.Frame3D1.Name = "Frame3D1"
        Me.Frame3D1.Size = New System.Drawing.Size(131, 91)
        Me.Frame3D1.TabIndex = 24
        '
        'Frame3D2
        '
        Me.Frame3D2.BackColor = System.Drawing.SystemColors.Control
        Me.Frame3D2.Location = New System.Drawing.Point(210, 220)
        Me.Frame3D2.Name = "Frame3D2"
        Me.Frame3D2.Size = New System.Drawing.Size(171, 91)
        Me.Frame3D2.TabIndex = 25
        '
        '_lblLettera_2
        '
        Me._lblLettera_2.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(192, Byte))
        Me._lblLettera_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._lblLettera_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLettera_2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblLettera.Add(2, Me._lblLettera_2)
        Me._lblLettera_2.Location = New System.Drawing.Point(400, 170)
        Me._lblLettera_2.Name = "_lblLettera_2"
        Me._lblLettera_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLettera_2.Size = New System.Drawing.Size(31, 51)
        Me._lblLettera_2.TabIndex = 9
        Me._lblLettera_2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        '_lblLettera_1
        '
        Me._lblLettera_1.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(192, Byte))
        Me._lblLettera_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._lblLettera_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLettera_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblLettera.Add(1, Me._lblLettera_1)
        Me._lblLettera_1.Location = New System.Drawing.Point(180, 170)
        Me._lblLettera_1.Name = "_lblLettera_1"
        Me._lblLettera_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLettera_1.Size = New System.Drawing.Size(31, 51)
        Me._lblLettera_1.TabIndex = 8
        Me._lblLettera_1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        '_lblLettera_0
        '
        Me._lblLettera_0.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(192, Byte))
        Me._lblLettera_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._lblLettera_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLettera_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblLettera.Add(0, Me._lblLettera_0)
        Me._lblLettera_0.Location = New System.Drawing.Point(0, 170)
        Me._lblLettera_0.Name = "_lblLettera_0"
        Me._lblLettera_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLettera_0.Size = New System.Drawing.Size(31, 51)
        Me._lblLettera_0.TabIndex = 7
        Me._lblLettera_0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        '_lblSpiega_2
        '
        Me._lblSpiega_2.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(192, Byte))
        Me._lblSpiega_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._lblSpiega_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblSpiega_2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblSpiega.Add(2, Me._lblSpiega_2)
        Me._lblSpiega_2.Location = New System.Drawing.Point(430, 170)
        Me._lblSpiega_2.Name = "_lblSpiega_2"
        Me._lblSpiega_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblSpiega_2.Size = New System.Drawing.Size(131, 51)
        Me._lblSpiega_2.TabIndex = 5
        '
        '_lblSpiega_1
        '
        Me._lblSpiega_1.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(192, Byte))
        Me._lblSpiega_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._lblSpiega_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblSpiega_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblSpiega.Add(1, Me._lblSpiega_1)
        Me._lblSpiega_1.Location = New System.Drawing.Point(210, 170)
        Me._lblSpiega_1.Name = "_lblSpiega_1"
        Me._lblSpiega_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblSpiega_1.Size = New System.Drawing.Size(171, 51)
        Me._lblSpiega_1.TabIndex = 4
        '
        '_lblSpiega_0
        '
        Me._lblSpiega_0.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(192, Byte))
        Me._lblSpiega_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._lblSpiega_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblSpiega_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblSpiega.Add(0, Me._lblSpiega_0)
        Me._lblSpiega_0.Location = New System.Drawing.Point(30, 170)
        Me._lblSpiega_0.Name = "_lblSpiega_0"
        Me._lblSpiega_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblSpiega_0.Size = New System.Drawing.Size(131, 51)
        Me._lblSpiega_0.TabIndex = 3
        '
        'Due
        '
        '
        'Tre
        '
        '
        'Uno
        '
        '
        'cmd1Up
        '
        Me.cmd1Up.BackColor = System.Drawing.SystemColors.Control
        Me.cmd1Up.Image = CType(resources.GetObject("cmd1Up.Image"), System.Drawing.Image)
        Me.cmd1Up.Location = New System.Drawing.Point(161, 170)
        Me.cmd1Up.Name = "cmd1Up"
        Me.cmd1Up.Size = New System.Drawing.Size(20, 25)
        Me.cmd1Up.TabIndex = 36
        '
        'cmd2Up
        '
        Me.cmd2Up.BackColor = System.Drawing.SystemColors.Control
        Me.cmd2Up.Image = CType(resources.GetObject("cmd2Up.Image"), System.Drawing.Image)
        Me.cmd2Up.Location = New System.Drawing.Point(381, 170)
        Me.cmd2Up.Name = "cmd2Up"
        Me.cmd2Up.Size = New System.Drawing.Size(20, 25)
        Me.cmd2Up.TabIndex = 37
        '
        'cmd3Up
        '
        Me.cmd3Up.BackColor = System.Drawing.SystemColors.Control
        Me.cmd3Up.Image = CType(resources.GetObject("cmd3Up.Image"), System.Drawing.Image)
        Me.cmd3Up.Location = New System.Drawing.Point(562, 170)
        Me.cmd3Up.Name = "cmd3Up"
        Me.cmd3Up.Size = New System.Drawing.Size(20, 25)
        Me.cmd3Up.TabIndex = 38
        '
        'cmd1Down
        '
        Me.cmd1Down.BackColor = System.Drawing.SystemColors.Control
        Me.cmd1Down.Image = CType(resources.GetObject("cmd1Down.Image"), System.Drawing.Image)
        Me.cmd1Down.Location = New System.Drawing.Point(161, 196)
        Me.cmd1Down.Name = "cmd1Down"
        Me.cmd1Down.Size = New System.Drawing.Size(20, 25)
        Me.cmd1Down.TabIndex = 39
        '
        'cmd2Down
        '
        Me.cmd2Down.BackColor = System.Drawing.SystemColors.Control
        Me.cmd2Down.Image = CType(resources.GetObject("cmd2Down.Image"), System.Drawing.Image)
        Me.cmd2Down.Location = New System.Drawing.Point(381, 196)
        Me.cmd2Down.Name = "cmd2Down"
        Me.cmd2Down.Size = New System.Drawing.Size(20, 25)
        Me.cmd2Down.TabIndex = 40
        '
        'cmd3Down
        '
        Me.cmd3Down.BackColor = System.Drawing.SystemColors.Control
        Me.cmd3Down.Image = CType(resources.GetObject("cmd3Down.Image"), System.Drawing.Image)
        Me.cmd3Down.Location = New System.Drawing.Point(562, 196)
        Me.cmd3Down.Name = "cmd3Down"
        Me.cmd3Down.Size = New System.Drawing.Size(20, 25)
        Me.cmd3Down.TabIndex = 41
        '
        'frmTEMA
        '
        Me.AcceptButton = Me.Command1
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.ClientSize = New System.Drawing.Size(581, 353)
        Me.ControlBox = False
        Me.Controls.Add(Me.cmd3Down)
        Me.Controls.Add(Me.cmd2Down)
        Me.Controls.Add(Me.cmd1Down)
        Me.Controls.Add(Me.cmd3Up)
        Me.Controls.Add(Me.cmd2Up)
        Me.Controls.Add(Me.cmd1Up)
        Me.Controls.Add(Me._Tre_8)
        Me.Controls.Add(Me._Tre_7)
        Me.Controls.Add(Me._Tre_6)
        Me.Controls.Add(Me._Tre_5)
        Me.Controls.Add(Me._Tre_4)
        Me.Controls.Add(Me._Tre_3)
        Me.Controls.Add(Me._Tre_2)
        Me.Controls.Add(Me._Tre_1)
        Me.Controls.Add(Me._Tre_0)
        Me.Controls.Add(Me.Frame3D3)
        Me.Controls.Add(Me._Due_7)
        Me.Controls.Add(Me._Due_6)
        Me.Controls.Add(Me._Due_5)
        Me.Controls.Add(Me._Due_4)
        Me.Controls.Add(Me._Due_3)
        Me.Controls.Add(Me._Due_2)
        Me.Controls.Add(Me._Due_1)
        Me.Controls.Add(Me._Due_0)
        Me.Controls.Add(Me._Uno_5)
        Me.Controls.Add(Me._Uno_4)
        Me.Controls.Add(Me._Uno_3)
        Me.Controls.Add(Me._Uno_2)
        Me.Controls.Add(Me._Uno_1)
        Me.Controls.Add(Me._Uno_0)
        Me.Controls.Add(Me.Command1)
        Me.Controls.Add(Me._pctFig_2)
        Me.Controls.Add(Me._pctFig_1)
        Me.Controls.Add(Me._pctFig_0)
        Me.Controls.Add(Me.Frame3D1)
        Me.Controls.Add(Me.Frame3D2)
        Me.Controls.Add(Me._lblLettera_2)
        Me.Controls.Add(Me._lblLettera_1)
        Me.Controls.Add(Me._lblLettera_0)
        Me.Controls.Add(Me._lblSpiega_2)
        Me.Controls.Add(Me._lblSpiega_1)
        Me.Controls.Add(Me._lblSpiega_0)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.ForeColor = System.Drawing.SystemColors.WindowText
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Location = New System.Drawing.Point(25, 36)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTEMA"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Classe TEMA"
        For Each control In Due.Values
            AddHandler control.Click, AddressOf Due_Click
        Next
        For Each control In Tre.Values
            AddHandler control.Click, AddressOf Tre_Click
        Next
        For Each control In Uno.Values
            AddHandler control.Click, AddressOf Uno_Click
        Next



        Me.ResumeLayout(False)

    End Sub
#End Region 
#Region "Supporto aggiornamento "
	Private Shared m_vb6FormDefInstance As frmTEMA
	Private Shared m_InitializingDefInstance As Boolean
	Public Shared Property DefInstance() As frmTEMA
		Get
			If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
				m_InitializingDefInstance = True
				m_vb6FormDefInstance = New frmTEMA()
				m_InitializingDefInstance = False
			End If
			DefInstance = m_vb6FormDefInstance
		End Get
		Set
			m_vb6FormDefInstance = Value
		End Set
	End Property
#End Region 
    Dim Spiega(3, 9) As String
    Dim Lettera(3, 9) As Char
    Dim Figura(3, 9) As String
    Dim iScelta(3) As Short
	
	Private Sub AggiorPic(ByRef i As Short)
		Dim j As Short
		j = i - 1
		pctFig(j).Image = System.Drawing.Image.FromFile(Figura(i, iScelta(i)))
		lblSpiega(j).Text = Spiega(i, iScelta(i))
		lblLettera(j).Text = Lettera(i, iScelta(i))
		pctFig(j).Refresh()
		lblSpiega(j).Refresh()
		lblLettera(j).Refresh()
	End Sub
	
	Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
		Dim i As Short
        For i = 1 To 3 : DataSheet.DatiSh0.TEMALetter(i) = Lettera(i, iScelta(i)) : Next
        frmTEMA.DefInstance.Hide()
        DataSheet.DatiSh0.FBMLetter = "C"
        If DataSheet.DatiSh0.TEMALetter(1) = "D" Then DataSheet.DatiSh0.FBMLetter = "D"
        If DataSheet.DatiSh0.TEMALetter(2) = "K" Then DataSheet.DatiSh0.FBMLetter = "E"
        mioApert.TEMA.Text = DataSheet.DatiSh0.TEMALetter(1) & DataSheet.DatiSh0.TEMALetter(2) & DataSheet.DatiSh0.TEMALetter(3)
    End Sub

    Private Sub Due_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Dim Index As Short = IndexedControls.IndexOf(Due, eventSender)
        iScelta(2) = Index + 1
        Call AggiorPic(2)

    End Sub

    Private Sub frmTEMA_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Dim j, i, ifl As Short
        ifl = FreeFile()
        FileOpen(ifl, RTrim(Monitor.Motore.Inizio.Archdir) & "\TEMATY.DAT", OpenMode.Input)
        For i = 1 To 3
            For j = 1 To 9
                Input(ifl, Lettera(i, j))
                Input(ifl, Spiega(i, j))
                Input(ifl, Figura(i, j))
                Figura(i, j) = RTrim(Monitor.Motore.Inizio.Archdir) & "\" & Figura(i, j)
            Next j
        Next i
        FileClose(ifl)
        For i = 1 To 3
            For j = 1 To 9
                If DataSheet.DatiSh0.TEMALetter(i) = Lettera(i, j) Then GoTo Cont
            Next
Cont:
            If j = 10 Then
                Select Case i
                    Case 1 : iScelta(i) = 6
                    Case 2 : iScelta(i) = 8
                    Case 3 : iScelta(i) = 9
                End Select
            Else
                iScelta(i) = j
            End If
        Next
        For i = 1 To 3
            Call AggiorPic(i)
        Next
    End Sub
    Private Sub Tre_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Dim Index As Short = IndexedControls.IndexOf(Tre, eventSender)
        iScelta(3) = Index + 1
        Call AggiorPic(3)
    End Sub
    Private Sub Uno_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Dim Index As Short = IndexedControls.IndexOf(Uno, eventSender)
        iScelta(1) = Index + 1
        Call AggiorPic(1)
    End Sub
    Private Sub cmd1Up_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd1Up.Click
        iScelta(1) = iScelta(1) - 1
        If iScelta(1) < 1 Then iScelta(1) = 6
        Call AggiorPic(1)
    End Sub
    Private Sub cmd2Up_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd2Up.Click
        iScelta(2) = iScelta(2) - 1
        If iScelta(2) < 1 Then iScelta(2) = 8
        Call AggiorPic(2)
    End Sub
    Private Sub cmd3Up_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd3Up.Click
        iScelta(3) = iScelta(3) - 1
        If iScelta(3) < 1 Then iScelta(3) = 9
        Call AggiorPic(3)

    End Sub

    Private Sub cmd1Down_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd1Down.Click
        iScelta(1) = iScelta(1) + 1
        If iScelta(1) > 6 Then iScelta(1) = 1
        Call AggiorPic(1)

    End Sub

    Private Sub cmd2Down_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd2Down.Click
        iScelta(2) = iScelta(2) + 1
        If iScelta(2) > 8 Then iScelta(2) = 1
        Call AggiorPic(2)

    End Sub

    Private Sub cmd3Down_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd3Down.Click
        iScelta(3) = iScelta(3) + 1
        If iScelta(3) > 9 Then iScelta(3) = 1
        Call AggiorPic(3)

    End Sub
End Class