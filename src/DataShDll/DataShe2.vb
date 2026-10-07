Option Strict Off
Option Explicit On
Friend Class DataShe2
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
	Public WithEvents _Mater_27 As System.Windows.Forms.TextBox
	Public WithEvents _Mater_26 As System.Windows.Forms.TextBox
	Public WithEvents _Mater_25 As System.Windows.Forms.TextBox
	Public WithEvents _Mater_24 As System.Windows.Forms.TextBox
	Public WithEvents _Mater_23 As System.Windows.Forms.TextBox
	Public WithEvents _Mater_22 As System.Windows.Forms.TextBox
	Public WithEvents _Mater_21 As System.Windows.Forms.TextBox
	Public WithEvents _Mater_20 As System.Windows.Forms.TextBox
	Public WithEvents _Mater_19 As System.Windows.Forms.TextBox
	Public WithEvents _Mater_18 As System.Windows.Forms.TextBox
	Public WithEvents _Mater_17 As System.Windows.Forms.TextBox
	Public WithEvents _Mater_16 As System.Windows.Forms.TextBox
	Public WithEvents _Mater_15 As System.Windows.Forms.TextBox
	Public WithEvents _Mater_14 As System.Windows.Forms.TextBox
	Public WithEvents _Mater_13 As System.Windows.Forms.TextBox
	Public WithEvents _Mater_12 As System.Windows.Forms.TextBox
	Public WithEvents _Mater_11 As System.Windows.Forms.TextBox
	Public WithEvents _Mater_10 As System.Windows.Forms.TextBox
	Public WithEvents _Mater_9 As System.Windows.Forms.TextBox
	Public WithEvents _Mater_8 As System.Windows.Forms.TextBox
	Public WithEvents _Mater_7 As System.Windows.Forms.TextBox
	Public WithEvents _Mater_6 As System.Windows.Forms.TextBox
	Public WithEvents _Mater_5 As System.Windows.Forms.TextBox
	Public WithEvents _Mater_4 As System.Windows.Forms.TextBox
	Public WithEvents _Mater_3 As System.Windows.Forms.TextBox
	Public WithEvents _Mater_2 As System.Windows.Forms.TextBox
	Public WithEvents _Mater_1 As System.Windows.Forms.TextBox
	Public WithEvents _Mater_0 As System.Windows.Forms.TextBox
	Public WithEvents TexServ As System.Windows.Forms.TextBox
	Public WithEvents TexImp As System.Windows.Forms.TextBox
	Public WithEvents Cliente As System.Windows.Forms.TextBox
	Public WithEvents TexItem As System.Windows.Forms.TextBox
	Public WithEvents Indietro As System.Windows.Forms.Button
	Public WithEvents Avanti As System.Windows.Forms.Button
    Public WithEvents _cmdMater_26 As System.windows.forms.Button
    Public WithEvents _cmdMater_25 As System.windows.forms.Button
    Public WithEvents _cmdMater_24 As System.windows.forms.Button
    Public WithEvents _cmdMater_23 As System.windows.forms.Button
    Public WithEvents _cmdMater_22 As System.windows.forms.Button
    Public WithEvents _cmdMater_21 As System.windows.forms.Button
    Public WithEvents _cmdMater_20 As System.windows.forms.Button
    Public WithEvents _cmdMater_19 As System.windows.forms.Button
    Public WithEvents _cmdMater_18 As System.windows.forms.Button
    Public WithEvents _cmdMater_17 As System.windows.forms.Button
    Public WithEvents _cmdMater_16 As System.windows.forms.Button
    Public WithEvents _cmdMater_15 As System.windows.forms.Button
    Public WithEvents _cmdMater_14 As System.windows.forms.Button
    Public WithEvents _cmdMater_13 As System.windows.forms.Button
    Public WithEvents _cmdMater_12 As System.windows.forms.Button
    Public WithEvents _cmdMater_11 As System.windows.forms.Button
    Public WithEvents _cmdMater_10 As System.windows.forms.Button
    Public WithEvents _cmdMater_9 As System.windows.forms.Button
    Public WithEvents _cmdMater_8 As System.windows.forms.Button
    Public WithEvents _cmdMater_7 As System.windows.forms.Button
    Public WithEvents _cmdMater_6 As System.windows.forms.Button
    Public WithEvents _cmdMater_5 As System.windows.forms.Button
    Public WithEvents _cmdMater_4 As System.windows.forms.Button
    Public WithEvents _cmdMater_3 As System.windows.forms.Button
    Public WithEvents _cmdMater_2 As System.windows.forms.Button
    Public WithEvents _cmdMater_1 As System.windows.forms.Button
    Public WithEvents _cmdMater_0 As System.windows.forms.Button
    Public WithEvents LabServ As System.Windows.Forms.Label
    Public WithEvents LabITEM As System.Windows.Forms.Label
    Public WithEvents TEMA As System.Windows.Forms.Label
    Public WithEvents LabImp As System.Windows.Forms.Label
    Public WithEvents LabClie As System.Windows.Forms.Label
    Public WithEvents LabTEMA As System.Windows.Forms.Label
    Public WithEvents _LabFlui_26 As System.Windows.Forms.Label
    Public WithEvents _LabFlui_25 As System.Windows.Forms.Label
    Public WithEvents _LabFlui_24 As System.Windows.Forms.Label
    Public WithEvents _LabFlui_23 As System.Windows.Forms.Label
    Public WithEvents _LabFlui_22 As System.Windows.Forms.Label
    Public WithEvents _Label0_4 As System.Windows.Forms.Label
    Public WithEvents _LabFlui_21 As System.Windows.Forms.Label
    Public WithEvents _LabFlui_20 As System.Windows.Forms.Label
    Public WithEvents _Label0_3 As System.Windows.Forms.Label
    Public WithEvents _LabFlui_19 As System.Windows.Forms.Label
    Public WithEvents _LabFlui_18 As System.Windows.Forms.Label
    Public WithEvents _LabFlui_17 As System.Windows.Forms.Label
    Public WithEvents _Label0_2 As System.Windows.Forms.Label
    Public WithEvents _LabFlui_16 As System.Windows.Forms.Label
    Public WithEvents _LabFlui_15 As System.Windows.Forms.Label
    Public WithEvents _LabFlui_14 As System.Windows.Forms.Label
    Public WithEvents _Label0_1 As System.Windows.Forms.Label
    Public WithEvents _LabFlui_13 As System.Windows.Forms.Label
    Public WithEvents _LabFlui_12 As System.Windows.Forms.Label
    Public WithEvents _LabFlui_11 As System.Windows.Forms.Label
    Public WithEvents _LabFlui_10 As System.Windows.Forms.Label
    Public WithEvents _LabFlui_9 As System.Windows.Forms.Label
    Public WithEvents _LabFlui_8 As System.Windows.Forms.Label
    Public WithEvents _LabFlui_7 As System.Windows.Forms.Label
    Public WithEvents _LabFlui_6 As System.Windows.Forms.Label
    Public WithEvents _Label0_6 As System.Windows.Forms.Label
    Public WithEvents _LabFlui_5 As System.Windows.Forms.Label
    Public WithEvents _LabFlui_4 As System.Windows.Forms.Label
    Public WithEvents _LabFlui_3 As System.Windows.Forms.Label
    Public WithEvents _LabFlui_2 As System.Windows.Forms.Label
    Public WithEvents _LabFlui_1 As System.Windows.Forms.Label
    Public WithEvents _LabFlui_0 As System.Windows.Forms.Label
    Public LabFlui As New System.Collections.Generic.Dictionary(Of Integer, Label)
    Public Label0 As New System.Collections.Generic.Dictionary(Of Integer, Label)
    Public Mater As New System.Collections.Generic.Dictionary(Of Integer, TextBox)
    Public cmdMater As New System.Collections.Generic.Dictionary(Of Integer, Button)
    'NOTA: la routine seguente è richiesta dalla progettazione Windows Form.
    'Può essere modificata utilizzando la finestra di progettazione Windows Form.
    'Non modificarla mediante l'editor di codice.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(DataShe2))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me._Mater_27 = New System.Windows.Forms.TextBox
        Me._Mater_26 = New System.Windows.Forms.TextBox
        Me._Mater_25 = New System.Windows.Forms.TextBox
        Me._Mater_24 = New System.Windows.Forms.TextBox
        Me._Mater_23 = New System.Windows.Forms.TextBox
        Me._Mater_22 = New System.Windows.Forms.TextBox
        Me._Mater_21 = New System.Windows.Forms.TextBox
        Me._Mater_20 = New System.Windows.Forms.TextBox
        Me._Mater_19 = New System.Windows.Forms.TextBox
        Me._Mater_18 = New System.Windows.Forms.TextBox
        Me._Mater_17 = New System.Windows.Forms.TextBox
        Me._Mater_16 = New System.Windows.Forms.TextBox
        Me._Mater_15 = New System.Windows.Forms.TextBox
        Me._Mater_14 = New System.Windows.Forms.TextBox
        Me._Mater_13 = New System.Windows.Forms.TextBox
        Me._Mater_12 = New System.Windows.Forms.TextBox
        Me._Mater_11 = New System.Windows.Forms.TextBox
        Me._Mater_10 = New System.Windows.Forms.TextBox
        Me._Mater_9 = New System.Windows.Forms.TextBox
        Me._Mater_8 = New System.Windows.Forms.TextBox
        Me._Mater_7 = New System.Windows.Forms.TextBox
        Me._Mater_6 = New System.Windows.Forms.TextBox
        Me._Mater_5 = New System.Windows.Forms.TextBox
        Me._Mater_4 = New System.Windows.Forms.TextBox
        Me._Mater_3 = New System.Windows.Forms.TextBox
        Me._Mater_2 = New System.Windows.Forms.TextBox
        Me._Mater_1 = New System.Windows.Forms.TextBox
        Me._Mater_0 = New System.Windows.Forms.TextBox
        Me.TexServ = New System.Windows.Forms.TextBox
        Me.TexImp = New System.Windows.Forms.TextBox
        Me.Cliente = New System.Windows.Forms.TextBox
        Me.TexItem = New System.Windows.Forms.TextBox
        Me.Indietro = New System.Windows.Forms.Button
        Me.Avanti = New System.Windows.Forms.Button
        Me._cmdMater_26 = New System.Windows.Forms.Button
        Me._cmdMater_25 = New System.Windows.Forms.Button
        Me._cmdMater_24 = New System.Windows.Forms.Button
        Me._cmdMater_23 = New System.Windows.Forms.Button
        Me._cmdMater_22 = New System.Windows.Forms.Button
        Me._cmdMater_21 = New System.Windows.Forms.Button
        Me._cmdMater_20 = New System.Windows.Forms.Button
        Me._cmdMater_19 = New System.Windows.Forms.Button
        Me._cmdMater_18 = New System.Windows.Forms.Button
        Me._cmdMater_17 = New System.Windows.Forms.Button
        Me._cmdMater_16 = New System.Windows.Forms.Button
        Me._cmdMater_15 = New System.Windows.Forms.Button
        Me._cmdMater_14 = New System.Windows.Forms.Button
        Me._cmdMater_13 = New System.Windows.Forms.Button
        Me._cmdMater_12 = New System.Windows.Forms.Button
        Me._cmdMater_11 = New System.Windows.Forms.Button
        Me._cmdMater_10 = New System.Windows.Forms.Button
        Me._cmdMater_9 = New System.Windows.Forms.Button
        Me._cmdMater_8 = New System.Windows.Forms.Button
        Me._cmdMater_7 = New System.Windows.Forms.Button
        Me._cmdMater_6 = New System.Windows.Forms.Button
        Me._cmdMater_5 = New System.Windows.Forms.Button
        Me._cmdMater_4 = New System.Windows.Forms.Button
        Me._cmdMater_3 = New System.Windows.Forms.Button
        Me._cmdMater_2 = New System.Windows.Forms.Button
        Me._cmdMater_1 = New System.Windows.Forms.Button
        Me._cmdMater_0 = New System.Windows.Forms.Button
        Me.LabServ = New System.Windows.Forms.Label
        Me.LabITEM = New System.Windows.Forms.Label
        Me.TEMA = New System.Windows.Forms.Label
        Me.LabImp = New System.Windows.Forms.Label
        Me.LabClie = New System.Windows.Forms.Label
        Me.LabTEMA = New System.Windows.Forms.Label
        Me._LabFlui_26 = New System.Windows.Forms.Label
        Me._LabFlui_25 = New System.Windows.Forms.Label
        Me._LabFlui_24 = New System.Windows.Forms.Label
        Me._LabFlui_23 = New System.Windows.Forms.Label
        Me._LabFlui_22 = New System.Windows.Forms.Label
        Me._Label0_4 = New System.Windows.Forms.Label
        Me._LabFlui_21 = New System.Windows.Forms.Label
        Me._LabFlui_20 = New System.Windows.Forms.Label
        Me._Label0_3 = New System.Windows.Forms.Label
        Me._LabFlui_19 = New System.Windows.Forms.Label
        Me._LabFlui_18 = New System.Windows.Forms.Label
        Me._LabFlui_17 = New System.Windows.Forms.Label
        Me._Label0_2 = New System.Windows.Forms.Label
        Me._LabFlui_16 = New System.Windows.Forms.Label
        Me._LabFlui_15 = New System.Windows.Forms.Label
        Me._LabFlui_14 = New System.Windows.Forms.Label
        Me._Label0_1 = New System.Windows.Forms.Label
        Me._LabFlui_13 = New System.Windows.Forms.Label
        Me._LabFlui_12 = New System.Windows.Forms.Label
        Me._LabFlui_11 = New System.Windows.Forms.Label
        Me._LabFlui_10 = New System.Windows.Forms.Label
        Me._LabFlui_9 = New System.Windows.Forms.Label
        Me._LabFlui_8 = New System.Windows.Forms.Label
        Me._LabFlui_7 = New System.Windows.Forms.Label
        Me._LabFlui_6 = New System.Windows.Forms.Label
        Me._Label0_6 = New System.Windows.Forms.Label
        Me._LabFlui_5 = New System.Windows.Forms.Label
        Me._LabFlui_4 = New System.Windows.Forms.Label
        Me._LabFlui_3 = New System.Windows.Forms.Label
        Me._LabFlui_2 = New System.Windows.Forms.Label
        Me._LabFlui_1 = New System.Windows.Forms.Label
        Me._LabFlui_0 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        '_Mater_27
        '
        Me._Mater_27.AcceptsReturn = True
        Me._Mater_27.AutoSize = False
        Me._Mater_27.BackColor = System.Drawing.SystemColors.Window
        Me._Mater_27.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._Mater_27.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Mater_27.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Mater.Add(27, Me._Mater_27)
        Me._Mater_27.Location = New System.Drawing.Point(430, 340)
        Me._Mater_27.MaxLength = 0
        Me._Mater_27.Name = "_Mater_27"
        Me._Mater_27.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Mater_27.Size = New System.Drawing.Size(171, 21)
        Me._Mater_27.TabIndex = 98
        Me._Mater_27.Text = "Text1"
        Me._Mater_27.Visible = False
        '
        '_Mater_26
        '
        Me._Mater_26.AcceptsReturn = True
        Me._Mater_26.AutoSize = False
        Me._Mater_26.BackColor = System.Drawing.SystemColors.Window
        Me._Mater_26.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._Mater_26.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Mater_26.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Mater.Add(26, Me._Mater_26)
        Me._Mater_26.Location = New System.Drawing.Point(430, 320)
        Me._Mater_26.MaxLength = 0
        Me._Mater_26.Name = "_Mater_26"
        Me._Mater_26.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Mater_26.Size = New System.Drawing.Size(171, 21)
        Me._Mater_26.TabIndex = 74
        Me._Mater_26.Text = "Text1"
        '
        '_Mater_25
        '
        Me._Mater_25.AcceptsReturn = True
        Me._Mater_25.AutoSize = False
        Me._Mater_25.BackColor = System.Drawing.SystemColors.Window
        Me._Mater_25.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._Mater_25.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Mater_25.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Mater.Add(25, Me._Mater_25)
        Me._Mater_25.Location = New System.Drawing.Point(430, 300)
        Me._Mater_25.MaxLength = 0
        Me._Mater_25.Name = "_Mater_25"
        Me._Mater_25.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Mater_25.Size = New System.Drawing.Size(171, 21)
        Me._Mater_25.TabIndex = 73
        Me._Mater_25.Text = "Text1"
        '
        '_Mater_24
        '
        Me._Mater_24.AcceptsReturn = True
        Me._Mater_24.AutoSize = False
        Me._Mater_24.BackColor = System.Drawing.SystemColors.Window
        Me._Mater_24.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._Mater_24.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Mater_24.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Mater.Add(24, Me._Mater_24)
        Me._Mater_24.Location = New System.Drawing.Point(430, 280)
        Me._Mater_24.MaxLength = 0
        Me._Mater_24.Name = "_Mater_24"
        Me._Mater_24.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Mater_24.Size = New System.Drawing.Size(171, 21)
        Me._Mater_24.TabIndex = 72
        Me._Mater_24.Text = "Text1"
        '
        '_Mater_23
        '
        Me._Mater_23.AcceptsReturn = True
        Me._Mater_23.AutoSize = False
        Me._Mater_23.BackColor = System.Drawing.SystemColors.Window
        Me._Mater_23.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._Mater_23.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Mater_23.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Mater.Add(23, Me._Mater_23)
        Me._Mater_23.Location = New System.Drawing.Point(430, 260)
        Me._Mater_23.MaxLength = 0
        Me._Mater_23.Name = "_Mater_23"
        Me._Mater_23.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Mater_23.Size = New System.Drawing.Size(171, 21)
        Me._Mater_23.TabIndex = 71
        Me._Mater_23.Text = "Text1"
        '
        '_Mater_22
        '
        Me._Mater_22.AcceptsReturn = True
        Me._Mater_22.AutoSize = False
        Me._Mater_22.BackColor = System.Drawing.SystemColors.Window
        Me._Mater_22.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._Mater_22.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Mater_22.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Mater.Add(22, Me._Mater_22)
        Me._Mater_22.Location = New System.Drawing.Point(430, 240)
        Me._Mater_22.MaxLength = 0
        Me._Mater_22.Name = "_Mater_22"
        Me._Mater_22.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Mater_22.Size = New System.Drawing.Size(171, 21)
        Me._Mater_22.TabIndex = 70
        Me._Mater_22.Text = "Text1"
        '
        '_Mater_21
        '
        Me._Mater_21.AcceptsReturn = True
        Me._Mater_21.AutoSize = False
        Me._Mater_21.BackColor = System.Drawing.SystemColors.Window
        Me._Mater_21.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._Mater_21.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Mater_21.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Mater.Add(21, Me._Mater_21)
        Me._Mater_21.Location = New System.Drawing.Point(430, 220)
        Me._Mater_21.MaxLength = 0
        Me._Mater_21.Name = "_Mater_21"
        Me._Mater_21.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Mater_21.Size = New System.Drawing.Size(171, 21)
        Me._Mater_21.TabIndex = 69
        Me._Mater_21.Text = "Text1"
        '
        '_Mater_20
        '
        Me._Mater_20.AcceptsReturn = True
        Me._Mater_20.AutoSize = False
        Me._Mater_20.BackColor = System.Drawing.SystemColors.Window
        Me._Mater_20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._Mater_20.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Mater_20.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Mater.Add(20, Me._Mater_20)
        Me._Mater_20.Location = New System.Drawing.Point(430, 200)
        Me._Mater_20.MaxLength = 0
        Me._Mater_20.Name = "_Mater_20"
        Me._Mater_20.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Mater_20.Size = New System.Drawing.Size(171, 21)
        Me._Mater_20.TabIndex = 68
        Me._Mater_20.Text = "Text1"
        '
        '_Mater_19
        '
        Me._Mater_19.AcceptsReturn = True
        Me._Mater_19.AutoSize = False
        Me._Mater_19.BackColor = System.Drawing.SystemColors.Window
        Me._Mater_19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._Mater_19.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Mater_19.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Mater.Add(19, Me._Mater_19)
        Me._Mater_19.Location = New System.Drawing.Point(430, 180)
        Me._Mater_19.MaxLength = 0
        Me._Mater_19.Name = "_Mater_19"
        Me._Mater_19.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Mater_19.Size = New System.Drawing.Size(171, 21)
        Me._Mater_19.TabIndex = 67
        Me._Mater_19.Text = "Text1"
        '
        '_Mater_18
        '
        Me._Mater_18.AcceptsReturn = True
        Me._Mater_18.AutoSize = False
        Me._Mater_18.BackColor = System.Drawing.SystemColors.Window
        Me._Mater_18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._Mater_18.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Mater_18.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Mater.Add(18, Me._Mater_18)
        Me._Mater_18.Location = New System.Drawing.Point(430, 160)
        Me._Mater_18.MaxLength = 0
        Me._Mater_18.Name = "_Mater_18"
        Me._Mater_18.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Mater_18.Size = New System.Drawing.Size(171, 21)
        Me._Mater_18.TabIndex = 66
        Me._Mater_18.Text = "Text1"
        '
        '_Mater_17
        '
        Me._Mater_17.AcceptsReturn = True
        Me._Mater_17.AutoSize = False
        Me._Mater_17.BackColor = System.Drawing.SystemColors.Window
        Me._Mater_17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._Mater_17.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Mater_17.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Mater.Add(17, Me._Mater_17)
        Me._Mater_17.Location = New System.Drawing.Point(430, 140)
        Me._Mater_17.MaxLength = 0
        Me._Mater_17.Name = "_Mater_17"
        Me._Mater_17.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Mater_17.Size = New System.Drawing.Size(171, 21)
        Me._Mater_17.TabIndex = 65
        Me._Mater_17.Text = "Text1"
        '
        '_Mater_16
        '
        Me._Mater_16.AcceptsReturn = True
        Me._Mater_16.AutoSize = False
        Me._Mater_16.BackColor = System.Drawing.SystemColors.Window
        Me._Mater_16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._Mater_16.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Mater_16.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Mater.Add(16, Me._Mater_16)
        Me._Mater_16.Location = New System.Drawing.Point(430, 120)
        Me._Mater_16.MaxLength = 0
        Me._Mater_16.Name = "_Mater_16"
        Me._Mater_16.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Mater_16.Size = New System.Drawing.Size(171, 21)
        Me._Mater_16.TabIndex = 64
        Me._Mater_16.Text = "Text1"
        '
        '_Mater_15
        '
        Me._Mater_15.AcceptsReturn = True
        Me._Mater_15.AutoSize = False
        Me._Mater_15.BackColor = System.Drawing.SystemColors.Window
        Me._Mater_15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._Mater_15.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Mater_15.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Mater.Add(15, Me._Mater_15)
        Me._Mater_15.Location = New System.Drawing.Point(430, 100)
        Me._Mater_15.MaxLength = 0
        Me._Mater_15.Name = "_Mater_15"
        Me._Mater_15.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Mater_15.Size = New System.Drawing.Size(171, 21)
        Me._Mater_15.TabIndex = 63
        Me._Mater_15.Text = "Text1"
        '
        '_Mater_14
        '
        Me._Mater_14.AcceptsReturn = True
        Me._Mater_14.AutoSize = False
        Me._Mater_14.BackColor = System.Drawing.SystemColors.Window
        Me._Mater_14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._Mater_14.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Mater_14.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Mater.Add(14, Me._Mater_14)
        Me._Mater_14.Location = New System.Drawing.Point(430, 80)
        Me._Mater_14.MaxLength = 0
        Me._Mater_14.Name = "_Mater_14"
        Me._Mater_14.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Mater_14.Size = New System.Drawing.Size(171, 21)
        Me._Mater_14.TabIndex = 62
        Me._Mater_14.Text = "Text1"
        '
        '_Mater_13
        '
        Me._Mater_13.AcceptsReturn = True
        Me._Mater_13.AutoSize = False
        Me._Mater_13.BackColor = System.Drawing.SystemColors.Window
        Me._Mater_13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._Mater_13.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Mater_13.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Mater.Add(13, Me._Mater_13)
        Me._Mater_13.Location = New System.Drawing.Point(120, 340)
        Me._Mater_13.MaxLength = 0
        Me._Mater_13.Name = "_Mater_13"
        Me._Mater_13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Mater_13.Size = New System.Drawing.Size(171, 21)
        Me._Mater_13.TabIndex = 61
        Me._Mater_13.Text = "Text1"
        '
        '_Mater_12
        '
        Me._Mater_12.AcceptsReturn = True
        Me._Mater_12.AutoSize = False
        Me._Mater_12.BackColor = System.Drawing.SystemColors.Window
        Me._Mater_12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._Mater_12.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Mater_12.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Mater.Add(12, Me._Mater_12)
        Me._Mater_12.Location = New System.Drawing.Point(120, 320)
        Me._Mater_12.MaxLength = 0
        Me._Mater_12.Name = "_Mater_12"
        Me._Mater_12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Mater_12.Size = New System.Drawing.Size(171, 21)
        Me._Mater_12.TabIndex = 60
        Me._Mater_12.Text = "Text1"
        '
        '_Mater_11
        '
        Me._Mater_11.AcceptsReturn = True
        Me._Mater_11.AutoSize = False
        Me._Mater_11.BackColor = System.Drawing.SystemColors.Window
        Me._Mater_11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._Mater_11.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Mater_11.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Mater.Add(11, Me._Mater_11)
        Me._Mater_11.Location = New System.Drawing.Point(120, 300)
        Me._Mater_11.MaxLength = 0
        Me._Mater_11.Name = "_Mater_11"
        Me._Mater_11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Mater_11.Size = New System.Drawing.Size(171, 21)
        Me._Mater_11.TabIndex = 59
        Me._Mater_11.Text = "Text1"
        '
        '_Mater_10
        '
        Me._Mater_10.AcceptsReturn = True
        Me._Mater_10.AutoSize = False
        Me._Mater_10.BackColor = System.Drawing.SystemColors.Window
        Me._Mater_10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._Mater_10.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Mater_10.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Mater.Add(10, Me._Mater_10)
        Me._Mater_10.Location = New System.Drawing.Point(120, 280)
        Me._Mater_10.MaxLength = 0
        Me._Mater_10.Name = "_Mater_10"
        Me._Mater_10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Mater_10.Size = New System.Drawing.Size(171, 21)
        Me._Mater_10.TabIndex = 58
        Me._Mater_10.Text = "Text1"
        '
        '_Mater_9
        '
        Me._Mater_9.AcceptsReturn = True
        Me._Mater_9.AutoSize = False
        Me._Mater_9.BackColor = System.Drawing.SystemColors.Window
        Me._Mater_9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._Mater_9.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Mater_9.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Mater.Add(9, Me._Mater_9)
        Me._Mater_9.Location = New System.Drawing.Point(120, 260)
        Me._Mater_9.MaxLength = 0
        Me._Mater_9.Name = "_Mater_9"
        Me._Mater_9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Mater_9.Size = New System.Drawing.Size(171, 21)
        Me._Mater_9.TabIndex = 57
        Me._Mater_9.Text = "Text1"
        '
        '_Mater_8
        '
        Me._Mater_8.AcceptsReturn = True
        Me._Mater_8.AutoSize = False
        Me._Mater_8.BackColor = System.Drawing.SystemColors.Window
        Me._Mater_8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._Mater_8.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Mater_8.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Mater.Add(8, Me._Mater_8)
        Me._Mater_8.Location = New System.Drawing.Point(120, 240)
        Me._Mater_8.MaxLength = 0
        Me._Mater_8.Name = "_Mater_8"
        Me._Mater_8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Mater_8.Size = New System.Drawing.Size(171, 21)
        Me._Mater_8.TabIndex = 56
        Me._Mater_8.Text = "Text1"
        '
        '_Mater_7
        '
        Me._Mater_7.AcceptsReturn = True
        Me._Mater_7.AutoSize = False
        Me._Mater_7.BackColor = System.Drawing.SystemColors.Window
        Me._Mater_7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._Mater_7.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Mater_7.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Mater.Add(7, Me._Mater_7)
        Me._Mater_7.Location = New System.Drawing.Point(120, 220)
        Me._Mater_7.MaxLength = 0
        Me._Mater_7.Name = "_Mater_7"
        Me._Mater_7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Mater_7.Size = New System.Drawing.Size(171, 21)
        Me._Mater_7.TabIndex = 55
        Me._Mater_7.Text = "Text1"
        '
        '_Mater_6
        '
        Me._Mater_6.AcceptsReturn = True
        Me._Mater_6.AutoSize = False
        Me._Mater_6.BackColor = System.Drawing.SystemColors.Window
        Me._Mater_6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._Mater_6.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Mater_6.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Mater.Add(6, Me._Mater_6)
        Me._Mater_6.Location = New System.Drawing.Point(120, 200)
        Me._Mater_6.MaxLength = 0
        Me._Mater_6.Name = "_Mater_6"
        Me._Mater_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Mater_6.Size = New System.Drawing.Size(171, 21)
        Me._Mater_6.TabIndex = 54
        Me._Mater_6.Text = "Text1"
        '
        '_Mater_5
        '
        Me._Mater_5.AcceptsReturn = True
        Me._Mater_5.AutoSize = False
        Me._Mater_5.BackColor = System.Drawing.SystemColors.Window
        Me._Mater_5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._Mater_5.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Mater_5.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Mater.Add(5, Me._Mater_5)
        Me._Mater_5.Location = New System.Drawing.Point(120, 180)
        Me._Mater_5.MaxLength = 0
        Me._Mater_5.Name = "_Mater_5"
        Me._Mater_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Mater_5.Size = New System.Drawing.Size(171, 21)
        Me._Mater_5.TabIndex = 53
        Me._Mater_5.Text = "Text1"
        '
        '_Mater_4
        '
        Me._Mater_4.AcceptsReturn = True
        Me._Mater_4.AutoSize = False
        Me._Mater_4.BackColor = System.Drawing.SystemColors.Window
        Me._Mater_4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._Mater_4.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Mater_4.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Mater.Add(4, Me._Mater_4)
        Me._Mater_4.Location = New System.Drawing.Point(120, 160)
        Me._Mater_4.MaxLength = 0
        Me._Mater_4.Name = "_Mater_4"
        Me._Mater_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Mater_4.Size = New System.Drawing.Size(171, 21)
        Me._Mater_4.TabIndex = 52
        Me._Mater_4.Text = "Text1"
        '
        '_Mater_3
        '
        Me._Mater_3.AcceptsReturn = True
        Me._Mater_3.AutoSize = False
        Me._Mater_3.BackColor = System.Drawing.SystemColors.Window
        Me._Mater_3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._Mater_3.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Mater_3.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Mater.Add(3, Me._Mater_3)
        Me._Mater_3.Location = New System.Drawing.Point(120, 140)
        Me._Mater_3.MaxLength = 0
        Me._Mater_3.Name = "_Mater_3"
        Me._Mater_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Mater_3.Size = New System.Drawing.Size(171, 21)
        Me._Mater_3.TabIndex = 51
        Me._Mater_3.Text = "Text1"
        '
        '_Mater_2
        '
        Me._Mater_2.AcceptsReturn = True
        Me._Mater_2.AutoSize = False
        Me._Mater_2.BackColor = System.Drawing.SystemColors.Window
        Me._Mater_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._Mater_2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Mater_2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Mater.Add(2, Me._Mater_2)
        Me._Mater_2.Location = New System.Drawing.Point(120, 120)
        Me._Mater_2.MaxLength = 0
        Me._Mater_2.Name = "_Mater_2"
        Me._Mater_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Mater_2.Size = New System.Drawing.Size(171, 21)
        Me._Mater_2.TabIndex = 50
        Me._Mater_2.Text = "Text1"
        '
        '_Mater_1
        '
        Me._Mater_1.AcceptsReturn = True
        Me._Mater_1.AutoSize = False
        Me._Mater_1.BackColor = System.Drawing.SystemColors.Window
        Me._Mater_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._Mater_1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Mater_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Mater.Add(1, Me._Mater_1)
        Me._Mater_1.Location = New System.Drawing.Point(120, 100)
        Me._Mater_1.MaxLength = 0
        Me._Mater_1.Name = "_Mater_1"
        Me._Mater_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Mater_1.Size = New System.Drawing.Size(171, 21)
        Me._Mater_1.TabIndex = 49
        Me._Mater_1.Text = "Text1"
        '
        '_Mater_0
        '
        Me._Mater_0.AcceptsReturn = True
        Me._Mater_0.AutoSize = False
        Me._Mater_0.BackColor = System.Drawing.SystemColors.Window
        Me._Mater_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._Mater_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Mater_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Mater.Add(0, Me._Mater_0)
        Me._Mater_0.Location = New System.Drawing.Point(120, 80)
        Me._Mater_0.MaxLength = 0
        Me._Mater_0.Name = "_Mater_0"
        Me._Mater_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Mater_0.Size = New System.Drawing.Size(171, 21)
        Me._Mater_0.TabIndex = 48
        Me._Mater_0.Text = "Text1"
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
        Me.TexServ.Location = New System.Drawing.Point(360, 60)
        Me.TexServ.MaxLength = 0
        Me.TexServ.Name = "TexServ"
        Me.TexServ.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TexServ.Size = New System.Drawing.Size(261, 21)
        Me.TexServ.TabIndex = 41
        Me.TexServ.Text = ""
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
        Me.TexImp.Location = New System.Drawing.Point(360, 40)
        Me.TexImp.MaxLength = 0
        Me.TexImp.Name = "TexImp"
        Me.TexImp.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TexImp.Size = New System.Drawing.Size(261, 21)
        Me.TexImp.TabIndex = 40
        Me.TexImp.Text = ""
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
        Me.Cliente.Location = New System.Drawing.Point(360, 20)
        Me.Cliente.MaxLength = 0
        Me.Cliente.Name = "Cliente"
        Me.Cliente.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Cliente.Size = New System.Drawing.Size(261, 21)
        Me.Cliente.TabIndex = 39
        Me.Cliente.Text = ""
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
        Me.TexItem.Location = New System.Drawing.Point(360, 0)
        Me.TexItem.MaxLength = 0
        Me.TexItem.Name = "TexItem"
        Me.TexItem.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TexItem.Size = New System.Drawing.Size(121, 21)
        Me.TexItem.TabIndex = 38
        Me.TexItem.Text = ""
        '
        'Indietro
        '
        Me.Indietro.BackColor = System.Drawing.SystemColors.Control
        Me.Indietro.Cursor = System.Windows.Forms.Cursors.Default
        Me.Indietro.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Indietro.Location = New System.Drawing.Point(90, 390)
        Me.Indietro.Name = "Indietro"
        Me.Indietro.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Indietro.Size = New System.Drawing.Size(71, 21)
        Me.Indietro.TabIndex = 11
        Me.Indietro.Text = "Indietro"
        '
        'Avanti
        '
        Me.Avanti.BackColor = System.Drawing.SystemColors.Control
        Me.Avanti.Cursor = System.Windows.Forms.Cursors.Default
        Me.Avanti.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Avanti.Location = New System.Drawing.Point(10, 390)
        Me.Avanti.Name = "Avanti"
        Me.Avanti.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Avanti.Size = New System.Drawing.Size(71, 21)
        Me.Avanti.TabIndex = 10
        Me.Avanti.Text = "Avanti"
        '
        '_cmdMater_26
        '
        Me._cmdMater_26.Image = CType(resources.GetObject("_cmdMater_26.Image"), System.Drawing.Image)
        Me.cmdMater.Add(26, Me._cmdMater_26)
        Me._cmdMater_26.Location = New System.Drawing.Point(600, 320)
        Me._cmdMater_26.Name = "_cmdMater_26"
        Me._cmdMater_26.Size = New System.Drawing.Size(21, 21)
        Me._cmdMater_26.TabIndex = 0
        '
        '_cmdMater_25
        '
        Me._cmdMater_25.Image = CType(resources.GetObject("_cmdMater_25.Image"), System.Drawing.Image)
        Me.cmdMater.Add(25, Me._cmdMater_25)
        Me._cmdMater_25.Location = New System.Drawing.Point(600, 300)
        Me._cmdMater_25.Name = "_cmdMater_25"
        Me._cmdMater_25.Size = New System.Drawing.Size(21, 21)
        Me._cmdMater_25.TabIndex = 1
        '
        '_cmdMater_24
        '
        Me._cmdMater_24.Image = CType(resources.GetObject("_cmdMater_24.Image"), System.Drawing.Image)
        Me.cmdMater.Add(24, Me._cmdMater_24)
        Me._cmdMater_24.Location = New System.Drawing.Point(600, 280)
        Me._cmdMater_24.Name = "_cmdMater_24"
        Me._cmdMater_24.Size = New System.Drawing.Size(21, 21)
        Me._cmdMater_24.TabIndex = 2
        '
        '_cmdMater_23
        '
        Me._cmdMater_23.Image = CType(resources.GetObject("_cmdMater_23.Image"), System.Drawing.Image)
        Me.cmdMater.Add(23, Me._cmdMater_23)
        Me._cmdMater_23.Location = New System.Drawing.Point(600, 260)
        Me._cmdMater_23.Name = "_cmdMater_23"
        Me._cmdMater_23.Size = New System.Drawing.Size(21, 21)
        Me._cmdMater_23.TabIndex = 3
        '
        '_cmdMater_22
        '
        Me._cmdMater_22.Image = CType(resources.GetObject("_cmdMater_22.Image"), System.Drawing.Image)
        Me.cmdMater.Add(22, Me._cmdMater_22)
        Me._cmdMater_22.Location = New System.Drawing.Point(600, 240)
        Me._cmdMater_22.Name = "_cmdMater_22"
        Me._cmdMater_22.Size = New System.Drawing.Size(21, 21)
        Me._cmdMater_22.TabIndex = 97
        '
        '_cmdMater_21
        '
        Me._cmdMater_21.Image = CType(resources.GetObject("_cmdMater_21.Image"), System.Drawing.Image)
        Me.cmdMater.Add(21, Me._cmdMater_21)
        Me._cmdMater_21.Location = New System.Drawing.Point(600, 220)
        Me._cmdMater_21.Name = "_cmdMater_21"
        Me._cmdMater_21.Size = New System.Drawing.Size(21, 21)
        Me._cmdMater_21.TabIndex = 96
        '
        '_cmdMater_20
        '
        Me._cmdMater_20.Image = CType(resources.GetObject("_cmdMater_20.Image"), System.Drawing.Image)
        Me.cmdMater.Add(20, Me._cmdMater_20)
        Me._cmdMater_20.Location = New System.Drawing.Point(600, 200)
        Me._cmdMater_20.Name = "_cmdMater_20"
        Me._cmdMater_20.Size = New System.Drawing.Size(21, 21)
        Me._cmdMater_20.TabIndex = 95
        '
        '_cmdMater_19
        '
        Me._cmdMater_19.Image = CType(resources.GetObject("_cmdMater_19.Image"), System.Drawing.Image)
        Me.cmdMater.Add(19, Me._cmdMater_19)
        Me._cmdMater_19.Location = New System.Drawing.Point(600, 180)
        Me._cmdMater_19.Name = "_cmdMater_19"
        Me._cmdMater_19.Size = New System.Drawing.Size(21, 21)
        Me._cmdMater_19.TabIndex = 94
        '
        '_cmdMater_18
        '
        Me._cmdMater_18.Image = CType(resources.GetObject("_cmdMater_18.Image"), System.Drawing.Image)
        Me.cmdMater.Add(18, Me._cmdMater_18)
        Me._cmdMater_18.Location = New System.Drawing.Point(600, 160)
        Me._cmdMater_18.Name = "_cmdMater_18"
        Me._cmdMater_18.Size = New System.Drawing.Size(21, 21)
        Me._cmdMater_18.TabIndex = 93
        '
        '_cmdMater_17
        '
        Me._cmdMater_17.Image = CType(resources.GetObject("_cmdMater_17.Image"), System.Drawing.Image)
        Me.cmdMater.Add(17, Me._cmdMater_17)
        Me._cmdMater_17.Location = New System.Drawing.Point(600, 140)
        Me._cmdMater_17.Name = "_cmdMater_17"
        Me._cmdMater_17.Size = New System.Drawing.Size(21, 21)
        Me._cmdMater_17.TabIndex = 92
        '
        '_cmdMater_16
        '
        Me._cmdMater_16.Image = CType(resources.GetObject("_cmdMater_16.Image"), System.Drawing.Image)
        Me.cmdMater.Add(16, Me._cmdMater_16)
        Me._cmdMater_16.Location = New System.Drawing.Point(600, 120)
        Me._cmdMater_16.Name = "_cmdMater_16"
        Me._cmdMater_16.Size = New System.Drawing.Size(21, 21)
        Me._cmdMater_16.TabIndex = 91
        '
        '_cmdMater_15
        '
        Me._cmdMater_15.Image = CType(resources.GetObject("_cmdMater_15.Image"), System.Drawing.Image)
        Me.cmdMater.Add(15, Me._cmdMater_15)
        Me._cmdMater_15.Location = New System.Drawing.Point(600, 100)
        Me._cmdMater_15.Name = "_cmdMater_15"
        Me._cmdMater_15.Size = New System.Drawing.Size(21, 21)
        Me._cmdMater_15.TabIndex = 90
        '
        '_cmdMater_14
        '
        Me._cmdMater_14.Image = CType(resources.GetObject("_cmdMater_14.Image"), System.Drawing.Image)
        Me.cmdMater.Add(14, Me._cmdMater_14)
        Me._cmdMater_14.Location = New System.Drawing.Point(600, 80)
        Me._cmdMater_14.Name = "_cmdMater_14"
        Me._cmdMater_14.Size = New System.Drawing.Size(21, 21)
        Me._cmdMater_14.TabIndex = 89
        '
        '_cmdMater_13
        '
        Me._cmdMater_13.Image = CType(resources.GetObject("_cmdMater_13.Image"), System.Drawing.Image)
        Me.cmdMater.Add(13, Me._cmdMater_13)
        Me._cmdMater_13.Location = New System.Drawing.Point(290, 340)
        Me._cmdMater_13.Name = "_cmdMater_13"
        Me._cmdMater_13.Size = New System.Drawing.Size(21, 21)
        Me._cmdMater_13.TabIndex = 88
        '
        '_cmdMater_12
        '
        Me._cmdMater_12.Image = CType(resources.GetObject("_cmdMater_12.Image"), System.Drawing.Image)
        Me.cmdMater.Add(12, Me._cmdMater_12)
        Me._cmdMater_12.Location = New System.Drawing.Point(290, 320)
        Me._cmdMater_12.Name = "_cmdMater_12"
        Me._cmdMater_12.Size = New System.Drawing.Size(21, 21)
        Me._cmdMater_12.TabIndex = 87
        '
        '_cmdMater_11
        '
        Me._cmdMater_11.Image = CType(resources.GetObject("_cmdMater_11.Image"), System.Drawing.Image)
        Me.cmdMater.Add(11, Me._cmdMater_11)
        Me._cmdMater_11.Location = New System.Drawing.Point(290, 300)
        Me._cmdMater_11.Name = "_cmdMater_11"
        Me._cmdMater_11.Size = New System.Drawing.Size(21, 21)
        Me._cmdMater_11.TabIndex = 86
        '
        '_cmdMater_10
        '
        Me._cmdMater_10.Image = CType(resources.GetObject("_cmdMater_10.Image"), System.Drawing.Image)
        Me.cmdMater.Add(10, Me._cmdMater_10)
        Me._cmdMater_10.Location = New System.Drawing.Point(290, 280)
        Me._cmdMater_10.Name = "_cmdMater_10"
        Me._cmdMater_10.Size = New System.Drawing.Size(21, 21)
        Me._cmdMater_10.TabIndex = 85
        '
        '_cmdMater_9
        '
        Me._cmdMater_9.Image = CType(resources.GetObject("_cmdMater_9.Image"), System.Drawing.Image)
        Me.cmdMater.Add(9, Me._cmdMater_9)
        Me._cmdMater_9.Location = New System.Drawing.Point(290, 260)
        Me._cmdMater_9.Name = "_cmdMater_9"
        Me._cmdMater_9.Size = New System.Drawing.Size(21, 21)
        Me._cmdMater_9.TabIndex = 84
        '
        '_cmdMater_8
        '
        Me._cmdMater_8.Image = CType(resources.GetObject("_cmdMater_8.Image"), System.Drawing.Image)
        Me.cmdMater.Add(8, Me._cmdMater_8)
        Me._cmdMater_8.Location = New System.Drawing.Point(290, 240)
        Me._cmdMater_8.Name = "_cmdMater_8"
        Me._cmdMater_8.Size = New System.Drawing.Size(21, 21)
        Me._cmdMater_8.TabIndex = 83
        '
        '_cmdMater_7
        '
        Me._cmdMater_7.Image = CType(resources.GetObject("_cmdMater_7.Image"), System.Drawing.Image)
        Me.cmdMater.Add(7, Me._cmdMater_7)
        Me._cmdMater_7.Location = New System.Drawing.Point(290, 220)
        Me._cmdMater_7.Name = "_cmdMater_7"
        Me._cmdMater_7.Size = New System.Drawing.Size(21, 21)
        Me._cmdMater_7.TabIndex = 82
        '
        '_cmdMater_6
        '
        Me._cmdMater_6.Image = CType(resources.GetObject("_cmdMater_6.Image"), System.Drawing.Image)
        Me.cmdMater.Add(6, Me._cmdMater_6)
        Me._cmdMater_6.Location = New System.Drawing.Point(290, 200)
        Me._cmdMater_6.Name = "_cmdMater_6"
        Me._cmdMater_6.Size = New System.Drawing.Size(21, 21)
        Me._cmdMater_6.TabIndex = 81
        '
        '_cmdMater_5
        '
        Me._cmdMater_5.Image = CType(resources.GetObject("_cmdMater_5.Image"), System.Drawing.Image)
        Me.cmdMater.Add(5, Me._cmdMater_5)
        Me._cmdMater_5.Location = New System.Drawing.Point(290, 180)
        Me._cmdMater_5.Name = "_cmdMater_5"
        Me._cmdMater_5.Size = New System.Drawing.Size(21, 21)
        Me._cmdMater_5.TabIndex = 80
        '
        '_cmdMater_4
        '
        Me._cmdMater_4.Image = CType(resources.GetObject("_cmdMater_4.Image"), System.Drawing.Image)
        Me.cmdMater.Add(4, Me._cmdMater_4)
        Me._cmdMater_4.Location = New System.Drawing.Point(290, 160)
        Me._cmdMater_4.Name = "_cmdMater_4"
        Me._cmdMater_4.Size = New System.Drawing.Size(21, 21)
        Me._cmdMater_4.TabIndex = 79
        '
        '_cmdMater_3
        '
        Me._cmdMater_3.Image = CType(resources.GetObject("_cmdMater_3.Image"), System.Drawing.Image)
        Me.cmdMater.Add(3, Me._cmdMater_3)
        Me._cmdMater_3.Location = New System.Drawing.Point(290, 140)
        Me._cmdMater_3.Name = "_cmdMater_3"
        Me._cmdMater_3.Size = New System.Drawing.Size(21, 21)
        Me._cmdMater_3.TabIndex = 78
        '
        '_cmdMater_2
        '
        Me._cmdMater_2.Image = CType(resources.GetObject("_cmdMater_2.Image"), System.Drawing.Image)
        Me.cmdMater.Add(2, Me._cmdMater_2)
        Me._cmdMater_2.Location = New System.Drawing.Point(290, 120)
        Me._cmdMater_2.Name = "_cmdMater_2"
        Me._cmdMater_2.Size = New System.Drawing.Size(21, 21)
        Me._cmdMater_2.TabIndex = 77
        '
        '_cmdMater_1
        '
        Me._cmdMater_1.Image = CType(resources.GetObject("_cmdMater_1.Image"), System.Drawing.Image)
        Me.cmdMater.Add(1, Me._cmdMater_1)
        Me._cmdMater_1.Location = New System.Drawing.Point(290, 100)
        Me._cmdMater_1.Name = "_cmdMater_1"
        Me._cmdMater_1.Size = New System.Drawing.Size(21, 21)
        Me._cmdMater_1.TabIndex = 76
        '
        '_cmdMater_0
        '
        Me._cmdMater_0.Image = CType(resources.GetObject("_cmdMater_0.Image"), System.Drawing.Image)
        Me.cmdMater.Add(0, Me._cmdMater_0)
        Me._cmdMater_0.Location = New System.Drawing.Point(290, 80)
        Me._cmdMater_0.Name = "_cmdMater_0"
        Me._cmdMater_0.Size = New System.Drawing.Size(21, 21)
        Me._cmdMater_0.TabIndex = 75
        '
        'LabServ
        '
        Me.LabServ.BackColor = System.Drawing.SystemColors.Window
        Me.LabServ.Cursor = System.Windows.Forms.Cursors.Default
        Me.LabServ.ForeColor = System.Drawing.SystemColors.WindowText
        Me.LabServ.Location = New System.Drawing.Point(300, 60)
        Me.LabServ.Name = "LabServ"
        Me.LabServ.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LabServ.Size = New System.Drawing.Size(51, 21)
        Me.LabServ.TabIndex = 47
        Me.LabServ.Text = "Servizio"
        '
        'LabITEM
        '
        Me.LabITEM.BackColor = System.Drawing.SystemColors.Window
        Me.LabITEM.Cursor = System.Windows.Forms.Cursors.Default
        Me.LabITEM.ForeColor = System.Drawing.SystemColors.WindowText
        Me.LabITEM.Location = New System.Drawing.Point(300, 0)
        Me.LabITEM.Name = "LabITEM"
        Me.LabITEM.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LabITEM.Size = New System.Drawing.Size(61, 21)
        Me.LabITEM.TabIndex = 46
        Me.LabITEM.Text = "ITEM"
        '
        'TEMA
        '
        Me.TEMA.BackColor = System.Drawing.SystemColors.Window
        Me.TEMA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TEMA.Cursor = System.Windows.Forms.Cursors.Default
        Me.TEMA.Enabled = False
        Me.TEMA.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TEMA.Location = New System.Drawing.Point(560, 0)
        Me.TEMA.Name = "TEMA"
        Me.TEMA.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TEMA.Size = New System.Drawing.Size(61, 21)
        Me.TEMA.TabIndex = 45
        Me.TEMA.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'LabImp
        '
        Me.LabImp.BackColor = System.Drawing.SystemColors.Window
        Me.LabImp.Cursor = System.Windows.Forms.Cursors.Default
        Me.LabImp.ForeColor = System.Drawing.SystemColors.WindowText
        Me.LabImp.Location = New System.Drawing.Point(300, 40)
        Me.LabImp.Name = "LabImp"
        Me.LabImp.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LabImp.Size = New System.Drawing.Size(51, 21)
        Me.LabImp.TabIndex = 44
        Me.LabImp.Text = "Impianto"
        '
        'LabClie
        '
        Me.LabClie.BackColor = System.Drawing.SystemColors.Window
        Me.LabClie.Cursor = System.Windows.Forms.Cursors.Default
        Me.LabClie.ForeColor = System.Drawing.SystemColors.WindowText
        Me.LabClie.Location = New System.Drawing.Point(300, 20)
        Me.LabClie.Name = "LabClie"
        Me.LabClie.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LabClie.Size = New System.Drawing.Size(41, 21)
        Me.LabClie.TabIndex = 43
        Me.LabClie.Text = "Cliente"
        '
        'LabTEMA
        '
        Me.LabTEMA.BackColor = System.Drawing.SystemColors.Window
        Me.LabTEMA.Cursor = System.Windows.Forms.Cursors.Default
        Me.LabTEMA.ForeColor = System.Drawing.SystemColors.WindowText
        Me.LabTEMA.Location = New System.Drawing.Point(480, 0)
        Me.LabTEMA.Name = "LabTEMA"
        Me.LabTEMA.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LabTEMA.Size = New System.Drawing.Size(71, 21)
        Me.LabTEMA.TabIndex = 42
        Me.LabTEMA.Text = "Tipo TEMA"
        '
        '_LabFlui_26
        '
        Me._LabFlui_26.BackColor = System.Drawing.SystemColors.Window
        Me._LabFlui_26.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._LabFlui_26.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabFlui_26.ForeColor = System.Drawing.SystemColors.WindowText
        Me.LabFlui.Add(26, Me._LabFlui_26)
        Me._LabFlui_26.Location = New System.Drawing.Point(310, 320)
        Me._LabFlui_26.Name = "_LabFlui_26"
        Me._LabFlui_26.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabFlui_26.Size = New System.Drawing.Size(121, 21)
        Me._LabFlui_26.TabIndex = 12
        Me._LabFlui_26.Text = "Supporti"
        '
        '_LabFlui_25
        '
        Me._LabFlui_25.BackColor = System.Drawing.SystemColors.Window
        Me._LabFlui_25.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._LabFlui_25.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabFlui_25.ForeColor = System.Drawing.SystemColors.WindowText
        Me.LabFlui.Add(25, Me._LabFlui_25)
        Me._LabFlui_25.Location = New System.Drawing.Point(350, 300)
        Me._LabFlui_25.Name = "_LabFlui_25"
        Me._LabFlui_25.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabFlui_25.Size = New System.Drawing.Size(81, 21)
        Me._LabFlui_25.TabIndex = 13
        Me._LabFlui_25.Tag = "4"
        Me._LabFlui_25.Text = "Bocch. l.mant"
        '
        '_LabFlui_24
        '
        Me._LabFlui_24.BackColor = System.Drawing.SystemColors.Window
        Me._LabFlui_24.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._LabFlui_24.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabFlui_24.ForeColor = System.Drawing.SystemColors.WindowText
        Me.LabFlui.Add(24, Me._LabFlui_24)
        Me._LabFlui_24.Location = New System.Drawing.Point(350, 280)
        Me._LabFlui_24.Name = "_LabFlui_24"
        Me._LabFlui_24.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabFlui_24.Size = New System.Drawing.Size(81, 21)
        Me._LabFlui_24.TabIndex = 15
        Me._LabFlui_24.Tag = "4"
        Me._LabFlui_24.Text = "Bocch. l. tubi"
        '
        '_LabFlui_23
        '
        Me._LabFlui_23.BackColor = System.Drawing.SystemColors.Window
        Me._LabFlui_23.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._LabFlui_23.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabFlui_23.ForeColor = System.Drawing.SystemColors.WindowText
        Me.LabFlui.Add(23, Me._LabFlui_23)
        Me._LabFlui_23.Location = New System.Drawing.Point(350, 260)
        Me._LabFlui_23.Name = "_LabFlui_23"
        Me._LabFlui_23.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabFlui_23.Size = New System.Drawing.Size(81, 21)
        Me._LabFlui_23.TabIndex = 16
        Me._LabFlui_23.Tag = "4"
        Me._LabFlui_23.Text = "Casse - P.T."
        '
        '_LabFlui_22
        '
        Me._LabFlui_22.BackColor = System.Drawing.SystemColors.Window
        Me._LabFlui_22.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._LabFlui_22.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabFlui_22.ForeColor = System.Drawing.SystemColors.WindowText
        Me.LabFlui.Add(22, Me._LabFlui_22)
        Me._LabFlui_22.Location = New System.Drawing.Point(350, 240)
        Me._LabFlui_22.Name = "_LabFlui_22"
        Me._LabFlui_22.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabFlui_22.Size = New System.Drawing.Size(81, 21)
        Me._LabFlui_22.TabIndex = 17
        Me._LabFlui_22.Tag = "4"
        Me._LabFlui_22.Text = "Coperchi"
        '
        '_Label0_4
        '
        Me._Label0_4.BackColor = System.Drawing.SystemColors.Window
        Me._Label0_4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._Label0_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label0_4.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label0.Add(4, Me._Label0_4)
        Me._Label0_4.Location = New System.Drawing.Point(310, 240)
        Me._Label0_4.Name = "_Label0_4"
        Me._Label0_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label0_4.Size = New System.Drawing.Size(41, 81)
        Me._Label0_4.TabIndex = 18
        Me._Label0_4.Text = "Guar- nizioni"
        '
        '_LabFlui_21
        '
        Me._LabFlui_21.BackColor = System.Drawing.SystemColors.Window
        Me._LabFlui_21.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._LabFlui_21.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabFlui_21.ForeColor = System.Drawing.SystemColors.WindowText
        Me.LabFlui.Add(21, Me._LabFlui_21)
        Me._LabFlui_21.Location = New System.Drawing.Point(350, 220)
        Me._LabFlui_21.Name = "_LabFlui_21"
        Me._LabFlui_21.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabFlui_21.Size = New System.Drawing.Size(81, 21)
        Me._LabFlui_21.TabIndex = 19
        Me._LabFlui_21.Tag = "3"
        Me._LabFlui_21.Text = "Coperchi"
        '
        '_LabFlui_20
        '
        Me._LabFlui_20.BackColor = System.Drawing.SystemColors.Window
        Me._LabFlui_20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._LabFlui_20.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabFlui_20.ForeColor = System.Drawing.SystemColors.WindowText
        Me.LabFlui.Add(20, Me._LabFlui_20)
        Me._LabFlui_20.Location = New System.Drawing.Point(350, 200)
        Me._LabFlui_20.Name = "_LabFlui_20"
        Me._LabFlui_20.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabFlui_20.Size = New System.Drawing.Size(81, 21)
        Me._LabFlui_20.TabIndex = 20
        Me._LabFlui_20.Tag = "3"
        Me._LabFlui_20.Text = "Corpo"
        '
        '_Label0_3
        '
        Me._Label0_3.BackColor = System.Drawing.SystemColors.Window
        Me._Label0_3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._Label0_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label0_3.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label0.Add(3, Me._Label0_3)
        Me._Label0_3.Location = New System.Drawing.Point(310, 200)
        Me._Label0_3.Name = "_Label0_3"
        Me._Label0_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label0_3.Size = New System.Drawing.Size(41, 41)
        Me._Label0_3.TabIndex = 21
        Me._Label0_3.Tag = "3"
        Me._Label0_3.Text = "Bulloni Dadi"
        '
        '_LabFlui_19
        '
        Me._LabFlui_19.BackColor = System.Drawing.SystemColors.Window
        Me._LabFlui_19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._LabFlui_19.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabFlui_19.ForeColor = System.Drawing.SystemColors.WindowText
        Me.LabFlui.Add(19, Me._LabFlui_19)
        Me._LabFlui_19.Location = New System.Drawing.Point(350, 180)
        Me._LabFlui_19.Name = "_LabFlui_19"
        Me._LabFlui_19.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabFlui_19.Size = New System.Drawing.Size(81, 21)
        Me._LabFlui_19.TabIndex = 37
        Me._LabFlui_19.Tag = "2"
        '
        '_LabFlui_18
        '
        Me._LabFlui_18.BackColor = System.Drawing.SystemColors.Window
        Me._LabFlui_18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._LabFlui_18.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabFlui_18.ForeColor = System.Drawing.SystemColors.WindowText
        Me.LabFlui.Add(18, Me._LabFlui_18)
        Me._LabFlui_18.Location = New System.Drawing.Point(350, 160)
        Me._LabFlui_18.Name = "_LabFlui_18"
        Me._LabFlui_18.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabFlui_18.Size = New System.Drawing.Size(81, 21)
        Me._LabFlui_18.TabIndex = 36
        Me._LabFlui_18.Tag = "2"
        Me._LabFlui_18.Text = "Casse"
        '
        '_LabFlui_17
        '
        Me._LabFlui_17.BackColor = System.Drawing.SystemColors.Window
        Me._LabFlui_17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._LabFlui_17.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabFlui_17.ForeColor = System.Drawing.SystemColors.WindowText
        Me.LabFlui.Add(17, Me._LabFlui_17)
        Me._LabFlui_17.Location = New System.Drawing.Point(350, 140)
        Me._LabFlui_17.Name = "_LabFlui_17"
        Me._LabFlui_17.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabFlui_17.Size = New System.Drawing.Size(81, 21)
        Me._LabFlui_17.TabIndex = 35
        Me._LabFlui_17.Tag = "2"
        Me._LabFlui_17.Text = "Mantello"
        '
        '_Label0_2
        '
        Me._Label0_2.BackColor = System.Drawing.SystemColors.Window
        Me._Label0_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._Label0_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label0_2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label0.Add(2, Me._Label0_2)
        Me._Label0_2.Location = New System.Drawing.Point(310, 140)
        Me._Label0_2.Name = "_Label0_2"
        Me._Label0_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label0_2.Size = New System.Drawing.Size(41, 61)
        Me._Label0_2.TabIndex = 34
        Me._Label0_2.Text = "Flange"
        '
        '_LabFlui_16
        '
        Me._LabFlui_16.BackColor = System.Drawing.SystemColors.Window
        Me._LabFlui_16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._LabFlui_16.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabFlui_16.ForeColor = System.Drawing.SystemColors.WindowText
        Me.LabFlui.Add(16, Me._LabFlui_16)
        Me._LabFlui_16.Location = New System.Drawing.Point(350, 120)
        Me._LabFlui_16.Name = "_LabFlui_16"
        Me._LabFlui_16.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabFlui_16.Size = New System.Drawing.Size(81, 21)
        Me._LabFlui_16.TabIndex = 33
        Me._LabFlui_16.Tag = "1"
        Me._LabFlui_16.Text = "Forgiati"
        '
        '_LabFlui_15
        '
        Me._LabFlui_15.BackColor = System.Drawing.SystemColors.Window
        Me._LabFlui_15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._LabFlui_15.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabFlui_15.ForeColor = System.Drawing.SystemColors.WindowText
        Me.LabFlui.Add(15, Me._LabFlui_15)
        Me._LabFlui_15.Location = New System.Drawing.Point(350, 100)
        Me._LabFlui_15.Name = "_LabFlui_15"
        Me._LabFlui_15.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabFlui_15.Size = New System.Drawing.Size(81, 21)
        Me._LabFlui_15.TabIndex = 32
        Me._LabFlui_15.Tag = "1"
        Me._LabFlui_15.Text = "Tubi"
        '
        '_LabFlui_14
        '
        Me._LabFlui_14.BackColor = System.Drawing.SystemColors.Window
        Me._LabFlui_14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._LabFlui_14.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabFlui_14.ForeColor = System.Drawing.SystemColors.WindowText
        Me.LabFlui.Add(14, Me._LabFlui_14)
        Me._LabFlui_14.Location = New System.Drawing.Point(350, 80)
        Me._LabFlui_14.Name = "_LabFlui_14"
        Me._LabFlui_14.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabFlui_14.Size = New System.Drawing.Size(81, 21)
        Me._LabFlui_14.TabIndex = 31
        Me._LabFlui_14.Tag = "1"
        Me._LabFlui_14.Text = "Lamiere"
        '
        '_Label0_1
        '
        Me._Label0_1.BackColor = System.Drawing.SystemColors.Window
        Me._Label0_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._Label0_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label0_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label0.Add(1, Me._Label0_1)
        Me._Label0_1.Location = New System.Drawing.Point(310, 80)
        Me._Label0_1.Name = "_Label0_1"
        Me._Label0_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label0_1.Size = New System.Drawing.Size(41, 61)
        Me._Label0_1.TabIndex = 30
        Me._Label0_1.Text = "Bocch lato mant."
        '
        '_LabFlui_13
        '
        Me._LabFlui_13.BackColor = System.Drawing.SystemColors.Window
        Me._LabFlui_13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._LabFlui_13.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabFlui_13.ForeColor = System.Drawing.SystemColors.WindowText
        Me.LabFlui.Add(13, Me._LabFlui_13)
        Me._LabFlui_13.Location = New System.Drawing.Point(40, 340)
        Me._LabFlui_13.Name = "_LabFlui_13"
        Me._LabFlui_13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabFlui_13.Size = New System.Drawing.Size(81, 21)
        Me._LabFlui_13.TabIndex = 29
        Me._LabFlui_13.Tag = "6"
        Me._LabFlui_13.Text = "Forgiati"
        '
        '_LabFlui_12
        '
        Me._LabFlui_12.BackColor = System.Drawing.SystemColors.Window
        Me._LabFlui_12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._LabFlui_12.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabFlui_12.ForeColor = System.Drawing.SystemColors.WindowText
        Me.LabFlui.Add(12, Me._LabFlui_12)
        Me._LabFlui_12.Location = New System.Drawing.Point(40, 320)
        Me._LabFlui_12.Name = "_LabFlui_12"
        Me._LabFlui_12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabFlui_12.Size = New System.Drawing.Size(81, 21)
        Me._LabFlui_12.TabIndex = 28
        Me._LabFlui_12.Tag = "6"
        Me._LabFlui_12.Text = "Tubi"
        '
        '_LabFlui_11
        '
        Me._LabFlui_11.BackColor = System.Drawing.SystemColors.Window
        Me._LabFlui_11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._LabFlui_11.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabFlui_11.ForeColor = System.Drawing.SystemColors.WindowText
        Me.LabFlui.Add(11, Me._LabFlui_11)
        Me._LabFlui_11.Location = New System.Drawing.Point(40, 300)
        Me._LabFlui_11.Name = "_LabFlui_11"
        Me._LabFlui_11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabFlui_11.Size = New System.Drawing.Size(81, 21)
        Me._LabFlui_11.TabIndex = 27
        Me._LabFlui_11.Tag = "6"
        Me._LabFlui_11.Text = "Lamiere"
        '
        '_LabFlui_10
        '
        Me._LabFlui_10.BackColor = System.Drawing.SystemColors.Window
        Me._LabFlui_10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._LabFlui_10.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabFlui_10.ForeColor = System.Drawing.SystemColors.WindowText
        Me.LabFlui.Add(10, Me._LabFlui_10)
        Me._LabFlui_10.Location = New System.Drawing.Point(0, 280)
        Me._LabFlui_10.Name = "_LabFlui_10"
        Me._LabFlui_10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabFlui_10.Size = New System.Drawing.Size(121, 21)
        Me._LabFlui_10.TabIndex = 26
        Me._LabFlui_10.Text = "Distanziali"
        '
        '_LabFlui_9
        '
        Me._LabFlui_9.BackColor = System.Drawing.SystemColors.Window
        Me._LabFlui_9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._LabFlui_9.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabFlui_9.ForeColor = System.Drawing.SystemColors.WindowText
        Me.LabFlui.Add(9, Me._LabFlui_9)
        Me._LabFlui_9.Location = New System.Drawing.Point(0, 260)
        Me._LabFlui_9.Name = "_LabFlui_9"
        Me._LabFlui_9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabFlui_9.Size = New System.Drawing.Size(121, 21)
        Me._LabFlui_9.TabIndex = 25
        Me._LabFlui_9.Text = "Tiranti"
        '
        '_LabFlui_8
        '
        Me._LabFlui_8.BackColor = System.Drawing.SystemColors.Window
        Me._LabFlui_8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._LabFlui_8.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabFlui_8.ForeColor = System.Drawing.SystemColors.WindowText
        Me.LabFlui.Add(8, Me._LabFlui_8)
        Me._LabFlui_8.Location = New System.Drawing.Point(0, 240)
        Me._LabFlui_8.Name = "_LabFlui_8"
        Me._LabFlui_8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabFlui_8.Size = New System.Drawing.Size(121, 21)
        Me._LabFlui_8.TabIndex = 24
        Me._LabFlui_8.Text = "Diaframmi"
        '
        '_LabFlui_7
        '
        Me._LabFlui_7.BackColor = System.Drawing.SystemColors.Window
        Me._LabFlui_7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._LabFlui_7.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabFlui_7.ForeColor = System.Drawing.SystemColors.WindowText
        Me.LabFlui.Add(7, Me._LabFlui_7)
        Me._LabFlui_7.Location = New System.Drawing.Point(0, 220)
        Me._LabFlui_7.Name = "_LabFlui_7"
        Me._LabFlui_7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabFlui_7.Size = New System.Drawing.Size(121, 21)
        Me._LabFlui_7.TabIndex = 23
        Me._LabFlui_7.Text = "Piastre tubiere"
        '
        '_LabFlui_6
        '
        Me._LabFlui_6.BackColor = System.Drawing.SystemColors.Window
        Me._LabFlui_6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._LabFlui_6.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabFlui_6.ForeColor = System.Drawing.SystemColors.WindowText
        Me.LabFlui.Add(6, Me._LabFlui_6)
        Me._LabFlui_6.Location = New System.Drawing.Point(0, 200)
        Me._LabFlui_6.Name = "_LabFlui_6"
        Me._LabFlui_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabFlui_6.Size = New System.Drawing.Size(121, 21)
        Me._LabFlui_6.TabIndex = 22
        Me._LabFlui_6.Text = "Camicie"
        '
        '_Label0_6
        '
        Me._Label0_6.BackColor = System.Drawing.SystemColors.Window
        Me._Label0_6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._Label0_6.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label0_6.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label0.Add(6, Me._Label0_6)
        Me._Label0_6.Location = New System.Drawing.Point(0, 300)
        Me._Label0_6.Name = "_Label0_6"
        Me._Label0_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label0_6.Size = New System.Drawing.Size(41, 61)
        Me._Label0_6.TabIndex = 14
        Me._Label0_6.Text = "Bocch lato tubi"
        '
        '_LabFlui_5
        '
        Me._LabFlui_5.BackColor = System.Drawing.SystemColors.Window
        Me._LabFlui_5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._LabFlui_5.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabFlui_5.ForeColor = System.Drawing.SystemColors.WindowText
        Me.LabFlui.Add(5, Me._LabFlui_5)
        Me._LabFlui_5.Location = New System.Drawing.Point(0, 180)
        Me._LabFlui_5.Name = "_LabFlui_5"
        Me._LabFlui_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabFlui_5.Size = New System.Drawing.Size(121, 21)
        Me._LabFlui_5.TabIndex = 9
        Me._LabFlui_5.Text = "Giunto elastico"
        '
        '_LabFlui_4
        '
        Me._LabFlui_4.BackColor = System.Drawing.SystemColors.Window
        Me._LabFlui_4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._LabFlui_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabFlui_4.ForeColor = System.Drawing.SystemColors.WindowText
        Me.LabFlui.Add(4, Me._LabFlui_4)
        Me._LabFlui_4.Location = New System.Drawing.Point(0, 160)
        Me._LabFlui_4.Name = "_LabFlui_4"
        Me._LabFlui_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabFlui_4.Size = New System.Drawing.Size(121, 21)
        Me._LabFlui_4.TabIndex = 8
        Me._LabFlui_4.Text = "Setti cassa"
        '
        '_LabFlui_3
        '
        Me._LabFlui_3.BackColor = System.Drawing.SystemColors.Window
        Me._LabFlui_3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._LabFlui_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabFlui_3.ForeColor = System.Drawing.SystemColors.WindowText
        Me.LabFlui.Add(3, Me._LabFlui_3)
        Me._LabFlui_3.Location = New System.Drawing.Point(0, 140)
        Me._LabFlui_3.Name = "_LabFlui_3"
        Me._LabFlui_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabFlui_3.Size = New System.Drawing.Size(121, 21)
        Me._LabFlui_3.TabIndex = 7
        Me._LabFlui_3.Text = "Coperchi cassa"
        '
        '_LabFlui_2
        '
        Me._LabFlui_2.BackColor = System.Drawing.SystemColors.Window
        Me._LabFlui_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._LabFlui_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabFlui_2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.LabFlui.Add(2, Me._LabFlui_2)
        Me._LabFlui_2.Location = New System.Drawing.Point(0, 120)
        Me._LabFlui_2.Name = "_LabFlui_2"
        Me._LabFlui_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabFlui_2.Size = New System.Drawing.Size(121, 21)
        Me._LabFlui_2.TabIndex = 6
        Me._LabFlui_2.Text = "Cassa"
        '
        '_LabFlui_1
        '
        Me._LabFlui_1.BackColor = System.Drawing.SystemColors.Window
        Me._LabFlui_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._LabFlui_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabFlui_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.LabFlui.Add(1, Me._LabFlui_1)
        Me._LabFlui_1.Location = New System.Drawing.Point(0, 100)
        Me._LabFlui_1.Name = "_LabFlui_1"
        Me._LabFlui_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabFlui_1.Size = New System.Drawing.Size(121, 21)
        Me._LabFlui_1.TabIndex = 5
        Me._LabFlui_1.Text = "Mantello"
        '
        '_LabFlui_0
        '
        Me._LabFlui_0.BackColor = System.Drawing.SystemColors.Window
        Me._LabFlui_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._LabFlui_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabFlui_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me.LabFlui.Add(0, Me._LabFlui_0)
        Me._LabFlui_0.Location = New System.Drawing.Point(0, 80)
        Me._LabFlui_0.Name = "_LabFlui_0"
        Me._LabFlui_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabFlui_0.Size = New System.Drawing.Size(121, 21)
        Me._LabFlui_0.TabIndex = 4
        Me._LabFlui_0.Text = "Tubi"
        '
        'cmdMater
        '
        '
        'DataShe2
        '
        Me.AcceptButton = Me.Avanti
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.ClientSize = New System.Drawing.Size(628, 436)
        Me.ControlBox = False
        Me.Controls.Add(Me._Mater_27)
        Me.Controls.Add(Me._Mater_26)
        Me.Controls.Add(Me._Mater_25)
        Me.Controls.Add(Me._Mater_24)
        Me.Controls.Add(Me._Mater_23)
        Me.Controls.Add(Me._Mater_22)
        Me.Controls.Add(Me._Mater_21)
        Me.Controls.Add(Me._Mater_20)
        Me.Controls.Add(Me._Mater_19)
        Me.Controls.Add(Me._Mater_18)
        Me.Controls.Add(Me._Mater_17)
        Me.Controls.Add(Me._Mater_16)
        Me.Controls.Add(Me._Mater_15)
        Me.Controls.Add(Me._Mater_14)
        Me.Controls.Add(Me._Mater_13)
        Me.Controls.Add(Me._Mater_12)
        Me.Controls.Add(Me._Mater_11)
        Me.Controls.Add(Me._Mater_10)
        Me.Controls.Add(Me._Mater_9)
        Me.Controls.Add(Me._Mater_8)
        Me.Controls.Add(Me._Mater_7)
        Me.Controls.Add(Me._Mater_6)
        Me.Controls.Add(Me._Mater_5)
        Me.Controls.Add(Me._Mater_4)
        Me.Controls.Add(Me._Mater_3)
        Me.Controls.Add(Me._Mater_2)
        Me.Controls.Add(Me._Mater_1)
        Me.Controls.Add(Me._Mater_0)
        Me.Controls.Add(Me.TexServ)
        Me.Controls.Add(Me.TexImp)
        Me.Controls.Add(Me.Cliente)
        Me.Controls.Add(Me.TexItem)
        Me.Controls.Add(Me.Indietro)
        Me.Controls.Add(Me.Avanti)
        Me.Controls.Add(Me._cmdMater_26)
        Me.Controls.Add(Me._cmdMater_25)
        Me.Controls.Add(Me._cmdMater_24)
        Me.Controls.Add(Me._cmdMater_23)
        Me.Controls.Add(Me._cmdMater_22)
        Me.Controls.Add(Me._cmdMater_21)
        Me.Controls.Add(Me._cmdMater_20)
        Me.Controls.Add(Me._cmdMater_19)
        Me.Controls.Add(Me._cmdMater_18)
        Me.Controls.Add(Me._cmdMater_17)
        Me.Controls.Add(Me._cmdMater_16)
        Me.Controls.Add(Me._cmdMater_15)
        Me.Controls.Add(Me._cmdMater_14)
        Me.Controls.Add(Me._cmdMater_13)
        Me.Controls.Add(Me._cmdMater_12)
        Me.Controls.Add(Me._cmdMater_11)
        Me.Controls.Add(Me._cmdMater_10)
        Me.Controls.Add(Me._cmdMater_9)
        Me.Controls.Add(Me._cmdMater_8)
        Me.Controls.Add(Me._cmdMater_7)
        Me.Controls.Add(Me._cmdMater_6)
        Me.Controls.Add(Me._cmdMater_5)
        Me.Controls.Add(Me._cmdMater_4)
        Me.Controls.Add(Me._cmdMater_3)
        Me.Controls.Add(Me._cmdMater_2)
        Me.Controls.Add(Me._cmdMater_1)
        Me.Controls.Add(Me._cmdMater_0)
        Me.Controls.Add(Me.LabServ)
        Me.Controls.Add(Me.LabITEM)
        Me.Controls.Add(Me.TEMA)
        Me.Controls.Add(Me.LabImp)
        Me.Controls.Add(Me.LabClie)
        Me.Controls.Add(Me.LabTEMA)
        Me.Controls.Add(Me._LabFlui_26)
        Me.Controls.Add(Me._LabFlui_25)
        Me.Controls.Add(Me._LabFlui_24)
        Me.Controls.Add(Me._LabFlui_23)
        Me.Controls.Add(Me._LabFlui_22)
        Me.Controls.Add(Me._Label0_4)
        Me.Controls.Add(Me._LabFlui_21)
        Me.Controls.Add(Me._LabFlui_20)
        Me.Controls.Add(Me._Label0_3)
        Me.Controls.Add(Me._LabFlui_19)
        Me.Controls.Add(Me._LabFlui_18)
        Me.Controls.Add(Me._LabFlui_17)
        Me.Controls.Add(Me._Label0_2)
        Me.Controls.Add(Me._LabFlui_16)
        Me.Controls.Add(Me._LabFlui_15)
        Me.Controls.Add(Me._LabFlui_14)
        Me.Controls.Add(Me._Label0_1)
        Me.Controls.Add(Me._LabFlui_13)
        Me.Controls.Add(Me._LabFlui_12)
        Me.Controls.Add(Me._LabFlui_11)
        Me.Controls.Add(Me._LabFlui_10)
        Me.Controls.Add(Me._LabFlui_9)
        Me.Controls.Add(Me._LabFlui_8)
        Me.Controls.Add(Me._LabFlui_7)
        Me.Controls.Add(Me._LabFlui_6)
        Me.Controls.Add(Me._Label0_6)
        Me.Controls.Add(Me._LabFlui_5)
        Me.Controls.Add(Me._LabFlui_4)
        Me.Controls.Add(Me._LabFlui_3)
        Me.Controls.Add(Me._LabFlui_2)
        Me.Controls.Add(Me._LabFlui_1)
        Me.Controls.Add(Me._LabFlui_0)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.ForeColor = System.Drawing.SystemColors.WindowText
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Location = New System.Drawing.Point(19, 119)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DataShe2"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Foglio dati - Materiali"



        For Each control In cmdMater.Values
            AddHandler control.Click, AddressOf cmdMater_ClickEvent
        Next
        Me.ResumeLayout(False)

    End Sub
#End Region 
#Region "Supporto aggiornamento "
	Private Shared m_vb6FormDefInstance As DataShe2
	Private Shared m_InitializingDefInstance As Boolean
	Public Shared Property DefInstance() As DataShe2
		Get
			If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
				m_InitializingDefInstance = True
				m_vb6FormDefInstance = New DataShe2()
				m_InitializingDefInstance = False
			End If
			DefInstance = m_vb6FormDefInstance
		End Get
		Set
			m_vb6FormDefInstance = Value
		End Set
	End Property
#End Region 
    Private Mat As LibMat.clsMatCompos
	Private Sub DisplayMat(ByRef Index As Short)
		Dim i, iC As Short
		Dim Ind(9) As Short
		Classe = 0 : For i = 0 To 9 : Ind(i) = 0 : Next 
		Select Case Index
			Case 0 'tubes
				Ind(3) = 1 'Classe = 4
			Case 1, 2, 3 'shells,covers,channels
				Ind(0) = 1 : Ind(1) = 1 : Ind(6) = 1
			Case 4, 8 'setti cassa  diaframmi
				Ind(0) = 1 : Ind(1) = 1
			Case 5, 6, 11, 14 'expansion joint  ,belts,lam.bocch
				Ind(0) = 1 : Ind(1) = 1
			Case 7, 13, 16, 17, 18 'P.T. fucinati per bocchelli,falnge
				Ind(6) = 1 'Classe = 7
			Case 9 'Tiranti
				Ind(2) = 1
			Case 10 'distanziali
				Ind(4) = 1
			Case 12, 15 'pipes
				Ind(5) = 1
			Case 20, 21 'tiranti /dati
				Ind(7) = 1
			Case 22, 23, 24, 25 'guarnizioni
				Ind(9) = 1
			Case 26 'supporti
				Ind(0) = 1
		End Select
		iC = DisplayCl(Index, Ind)
	End Sub
    Private Sub cmdMater_ClickEvent(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Dim Index As Short = IndexedControls.IndexOf(cmdMater, eventSender)
        Call DisplayMat(Index)
        ModifiedData = True
    End Sub
    Private Function DisplayCl(ByRef Index As Short, ByRef Ind() As Short) As Short
        Dim Index2, Index1, TipoS As Short
        Dim Capt As String
        'Dim Mater As material
        Dim i As Short
        Dim Cod As String
        Indexx = Index
        On Error GoTo ErrDisp
        Index1 = Val(LabFlui(Index).Tag)
        Capt = "Scelta materiali - "
        If Index1 Then Capt = Capt & Label0(Index1).Text & " - "
        Capt = Capt & LabFlui(Index).Text
        Select Case Indexx
            Case 0 : TipoS = 0
            Case 1, 2, 3, 11, 14, 13, 16, 17, 18, 12, 15 : TipoS = 1
            Case 4, 5, 6, 8, 9, 10, 20, 21, 22, 23, 24, 25, 26 : TipoS = 2
            Case 7 : TipoS = 3
        End Select
        Index1 = Indexx \ 7
        Index2 = Indexx Mod 7
        For i = 0 To 9
            Mat.IndAdd(Ind(i), i)
        Next
        Mat.TipoCompos = DataSheet.DatiS1(Index1).MateInform(Index2).Tipo
        Mat.Mat(1).Indmat = DataSheet.DatiS1(Index1).MateInform(Index2).Ind1
        Mat.Mat(2).Indmat = DataSheet.DatiS1(Index1).MateInform(Index2).Ind2
        Mat.Mat(3).Indmat = DataSheet.DatiS1(Index1).MateInform(Index2).Ind3
        If Mat.Mat(1).Indmat Then
            Mat.Mat(1).RecupMat(Monitor.Motore.Inizio.Archdir)
            Mat.Classe = Mat.Mat(1).Classe
        Else
            Mat.Classe = 0
        End If
        Call Mat.Scelta(0, Monitor.Motore.Inizio.Archdir, Capt, TipoS)
        DataSheet.DatiS1(Index1).MateInform(Index2).Tipo = Mat.TipoCompos
        DataShe2.DefInstance.Mater(Indexx).Text = Mat.testo
        DataSheet.DatiS1(Index1).MateInform(Index2).Ind1 = Mat.Mat(1).Indmat
        DataSheet.DatiS1(Index1).MateInform(Index2).Tipo = Mat.TipoCompos
        DataSheet.DatiS1(Index1).MateInform(Index2).Ind2 = Mat.Mat(2).Indmat 'matind(1).indice(List1(1).ListIndex + 1)
        DataSheet.DatiS1(Index1).MateInform(Index2).Ind3 = Mat.Mat(3).Indmat 'matind(1).indice(List1(1).ListIndex + 1)
ExDCl:
        Exit Function
ErrDisp:
        If MsgBox(ErrorToString() & " in DisplayCl", MsgBoxStyle.RetryCancel) = MsgBoxResult.Retry Then Resume Next Else Resume ExDCl
    End Function

    Private Sub DataShe2_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Mat = New LibMat.clsMatCompos
    End Sub

    Private Sub Indietro_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Indietro.Click
        Call Registra()
        'UPGRADE_NOTE: È possibile che l'oggetto Mat non venga eliminato finché non venga raccolto nel Garbage Collector. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1029"'
        Mat = Nothing
        Hide()
        DataShee.DefInstance.Show()
    End Sub

    Private Sub Registra()
        Dim i, j As Short
        For i = 0 To 3
            For j = i * 7 To i * 7 + 6
                DataSheet.DatiS1(i).MateInform(j - DataSheet.DatiS1(i).FirstIndex).Descr = DataShe2.DefInstance.Mater(j).Text
            Next
        Next

    End Sub
End Class