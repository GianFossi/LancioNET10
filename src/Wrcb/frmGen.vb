Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class frmGen
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
    Public WithEvents _Combo1_16 As System.Windows.Forms.ComboBox
	Public WithEvents _Combo1_15 As System.Windows.Forms.ComboBox
	Public WithEvents _Combo1_14 As System.Windows.Forms.ComboBox
	Public WithEvents _Combo1_0 As System.Windows.Forms.ComboBox
	Public WithEvents _Combo1_13 As System.Windows.Forms.ComboBox
	Public WithEvents _Combo1_12 As System.Windows.Forms.ComboBox
	Public WithEvents _Combo1_11 As System.Windows.Forms.ComboBox
	Public WithEvents _Combo1_10 As System.Windows.Forms.ComboBox
    Public WithEvents cmdCancel As System.Windows.Forms.Button
	Public WithEvents cmdOK As System.Windows.Forms.Button
	Public WithEvents _Combo1_3 As System.Windows.Forms.ComboBox
	Public WithEvents _Text1_2 As System.Windows.Forms.TextBox
	Public WithEvents _Text1_1 As System.Windows.Forms.TextBox
	Public WithEvents _Label1_0 As System.Windows.Forms.Label
    Public WithEvents _Label1_16 As System.Windows.Forms.Label
	Public WithEvents _Label1_15 As System.Windows.Forms.Label
	Public WithEvents _Label1_14 As System.Windows.Forms.Label
	Public WithEvents _Label1_13 As System.Windows.Forms.Label
	Public WithEvents _Label1_12 As System.Windows.Forms.Label
	Public WithEvents _Label1_11 As System.Windows.Forms.Label
	Public WithEvents _Label1_10 As System.Windows.Forms.Label
    Public WithEvents _Label1_3 As System.Windows.Forms.Label
	Public WithEvents _Label1_2 As System.Windows.Forms.Label
	Public WithEvents _Label1_1 As System.Windows.Forms.Label
    'NOTA: la routine seguente è richiesta dalla progettazione Windows Form.
	'Può essere modificata utilizzando la finestra di progettazione Windows Form.
	'Non modificarla mediante l'editor di codice.
    Friend WithEvents lblCodice As System.Windows.Forms.Label
    Friend WithEvents cmbCodice As System.Windows.Forms.ComboBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me._Combo1_16 = New System.Windows.Forms.ComboBox
        Me._Combo1_15 = New System.Windows.Forms.ComboBox
        Me._Combo1_14 = New System.Windows.Forms.ComboBox
        Me._Combo1_0 = New System.Windows.Forms.ComboBox
        Me._Combo1_13 = New System.Windows.Forms.ComboBox
        Me._Combo1_12 = New System.Windows.Forms.ComboBox
        Me._Combo1_11 = New System.Windows.Forms.ComboBox
        Me._Combo1_10 = New System.Windows.Forms.ComboBox
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdOK = New System.Windows.Forms.Button
        Me._Combo1_3 = New System.Windows.Forms.ComboBox
        Me._Text1_2 = New System.Windows.Forms.TextBox
        Me._Text1_1 = New System.Windows.Forms.TextBox
        Me._Label1_0 = New System.Windows.Forms.Label
        Me._Label1_16 = New System.Windows.Forms.Label
        Me._Label1_15 = New System.Windows.Forms.Label
        Me._Label1_14 = New System.Windows.Forms.Label
        Me._Label1_13 = New System.Windows.Forms.Label
        Me._Label1_12 = New System.Windows.Forms.Label
        Me._Label1_11 = New System.Windows.Forms.Label
        Me._Label1_10 = New System.Windows.Forms.Label
        Me._Label1_3 = New System.Windows.Forms.Label
        Me._Label1_2 = New System.Windows.Forms.Label
        Me._Label1_1 = New System.Windows.Forms.Label
        Me.lblCodice = New System.Windows.Forms.Label
        Me.cmbCodice = New System.Windows.Forms.ComboBox
        Me.SuspendLayout()
        '
        '_Combo1_16
        '
        Me._Combo1_16.BackColor = System.Drawing.SystemColors.Window
        Me._Combo1_16.Cursor = System.Windows.Forms.Cursors.Default
        Me._Combo1_16.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me._Combo1_16.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Combo1_16.Location = New System.Drawing.Point(152, 264)
        Me._Combo1_16.Name = "_Combo1_16"
        Me._Combo1_16.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Combo1_16.Size = New System.Drawing.Size(184, 21)
        Me._Combo1_16.TabIndex = 30
        '
        '_Combo1_15
        '
        Me._Combo1_15.BackColor = System.Drawing.SystemColors.Window
        Me._Combo1_15.Cursor = System.Windows.Forms.Cursors.Default
        Me._Combo1_15.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me._Combo1_15.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Combo1_15.Location = New System.Drawing.Point(152, 240)
        Me._Combo1_15.Name = "_Combo1_15"
        Me._Combo1_15.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Combo1_15.Size = New System.Drawing.Size(55, 21)
        Me._Combo1_15.TabIndex = 29
        '
        '_Combo1_14
        '
        Me._Combo1_14.BackColor = System.Drawing.SystemColors.Window
        Me._Combo1_14.Cursor = System.Windows.Forms.Cursors.Default
        Me._Combo1_14.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me._Combo1_14.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Combo1_14.Location = New System.Drawing.Point(152, 216)
        Me._Combo1_14.Name = "_Combo1_14"
        Me._Combo1_14.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Combo1_14.Size = New System.Drawing.Size(184, 21)
        Me._Combo1_14.TabIndex = 28
        '
        '_Combo1_0
        '
        Me._Combo1_0.BackColor = System.Drawing.SystemColors.Window
        Me._Combo1_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Combo1_0.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me._Combo1_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Combo1_0.Location = New System.Drawing.Point(152, 192)
        Me._Combo1_0.Name = "_Combo1_0"
        Me._Combo1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Combo1_0.Size = New System.Drawing.Size(55, 21)
        Me._Combo1_0.TabIndex = 36
        '
        '_Combo1_13
        '
        Me._Combo1_13.BackColor = System.Drawing.SystemColors.Window
        Me._Combo1_13.Cursor = System.Windows.Forms.Cursors.Default
        Me._Combo1_13.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me._Combo1_13.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Combo1_13.Location = New System.Drawing.Point(152, 168)
        Me._Combo1_13.Name = "_Combo1_13"
        Me._Combo1_13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Combo1_13.Size = New System.Drawing.Size(55, 21)
        Me._Combo1_13.TabIndex = 27
        '
        '_Combo1_12
        '
        Me._Combo1_12.BackColor = System.Drawing.SystemColors.Window
        Me._Combo1_12.Cursor = System.Windows.Forms.Cursors.Default
        Me._Combo1_12.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me._Combo1_12.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Combo1_12.Location = New System.Drawing.Point(153, 144)
        Me._Combo1_12.Name = "_Combo1_12"
        Me._Combo1_12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Combo1_12.Size = New System.Drawing.Size(184, 21)
        Me._Combo1_12.TabIndex = 26
        '
        '_Combo1_11
        '
        Me._Combo1_11.BackColor = System.Drawing.SystemColors.Window
        Me._Combo1_11.Cursor = System.Windows.Forms.Cursors.Default
        Me._Combo1_11.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me._Combo1_11.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Combo1_11.Location = New System.Drawing.Point(152, 120)
        Me._Combo1_11.Name = "_Combo1_11"
        Me._Combo1_11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Combo1_11.Size = New System.Drawing.Size(184, 21)
        Me._Combo1_11.TabIndex = 25
        '
        '_Combo1_10
        '
        Me._Combo1_10.BackColor = System.Drawing.SystemColors.Window
        Me._Combo1_10.Cursor = System.Windows.Forms.Cursors.Default
        Me._Combo1_10.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me._Combo1_10.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Combo1_10.Location = New System.Drawing.Point(152, 96)
        Me._Combo1_10.Name = "_Combo1_10"
        Me._Combo1_10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Combo1_10.Size = New System.Drawing.Size(184, 21)
        Me._Combo1_10.TabIndex = 24
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCancel.Location = New System.Drawing.Point(289, 334)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCancel.Size = New System.Drawing.Size(49, 25)
        Me.cmdCancel.TabIndex = 35
        Me.cmdCancel.Text = "Cancel"
        '
        'cmdOK
        '
        Me.cmdOK.BackColor = System.Drawing.SystemColors.Control
        Me.cmdOK.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdOK.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdOK.Location = New System.Drawing.Point(233, 334)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdOK.Size = New System.Drawing.Size(49, 25)
        Me.cmdOK.TabIndex = 34
        Me.cmdOK.Text = "OK"
        '
        '_Combo1_3
        '
        Me._Combo1_3.BackColor = System.Drawing.SystemColors.Window
        Me._Combo1_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._Combo1_3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me._Combo1_3.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Combo1_3.Location = New System.Drawing.Point(152, 48)
        Me._Combo1_3.Name = "_Combo1_3"
        Me._Combo1_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Combo1_3.Size = New System.Drawing.Size(184, 21)
        Me._Combo1_3.TabIndex = 18
        '
        '_Text1_2
        '
        Me._Text1_2.AcceptsReturn = True
        Me._Text1_2.AutoSize = False
        Me._Text1_2.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_2.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_2.Location = New System.Drawing.Point(152, 24)
        Me._Text1_2.MaxLength = 0
        Me._Text1_2.Name = "_Text1_2"
        Me._Text1_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_2.Size = New System.Drawing.Size(37, 24)
        Me._Text1_2.TabIndex = 17
        Me._Text1_2.Text = ""
        '
        '_Text1_1
        '
        Me._Text1_1.AcceptsReturn = True
        Me._Text1_1.AutoSize = False
        Me._Text1_1.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_1.Location = New System.Drawing.Point(152, 0)
        Me._Text1_1.MaxLength = 0
        Me._Text1_1.Name = "_Text1_1"
        Me._Text1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_1.Size = New System.Drawing.Size(37, 24)
        Me._Text1_1.TabIndex = 16
        Me._Text1_1.Text = ""
        '
        '_Label1_0
        '
        Me._Label1_0.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_0.Location = New System.Drawing.Point(0, 192)
        Me._Label1_0.Name = "_Label1_0"
        Me._Label1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_0.Size = New System.Drawing.Size(144, 19)
        Me._Label1_0.TabIndex = 37
        Me._Label1_0.Text = "Effetto di fondo automatico"
        '
        '_Label1_16
        '
        Me._Label1_16.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_16.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_16.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_16.Location = New System.Drawing.Point(0, 264)
        Me._Label1_16.Name = "_Label1_16"
        Me._Label1_16.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_16.Size = New System.Drawing.Size(144, 19)
        Me._Label1_16.TabIndex = 14
        Me._Label1_16.Text = "Convenzione sulla somma"
        '
        '_Label1_15
        '
        Me._Label1_15.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_15.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_15.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_15.Location = New System.Drawing.Point(0, 240)
        Me._Label1_15.Name = "_Label1_15"
        Me._Label1_15.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_15.Size = New System.Drawing.Size(152, 19)
        Me._Label1_15.TabIndex = 13
        Me._Label1_15.Text = "Note esplicative nel rapporto"
        '
        '_Label1_14
        '
        Me._Label1_14.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_14.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_14.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_14.Location = New System.Drawing.Point(0, 216)
        Me._Label1_14.Name = "_Label1_14"
        Me._Label1_14.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_14.Size = New System.Drawing.Size(144, 19)
        Me._Label1_14.TabIndex = 12
        Me._Label1_14.Text = "Messaggistica"
        '
        '_Label1_13
        '
        Me._Label1_13.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_13.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_13.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_13.Location = New System.Drawing.Point(0, 168)
        Me._Label1_13.Name = "_Label1_13"
        Me._Label1_13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_13.Size = New System.Drawing.Size(144, 19)
        Me._Label1_13.TabIndex = 11
        Me._Label1_13.Text = "Tagli da riportare al piede"
        '
        '_Label1_12
        '
        Me._Label1_12.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_12.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_12.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_12.Location = New System.Drawing.Point(0, 144)
        Me._Label1_12.Name = "_Label1_12"
        Me._Label1_12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_12.Size = New System.Drawing.Size(128, 19)
        Me._Label1_12.TabIndex = 10
        Me._Label1_12.Text = "Metodo di calcolo"
        '
        '_Label1_11
        '
        Me._Label1_11.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_11.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_11.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_11.Location = New System.Drawing.Point(0, 120)
        Me._Label1_11.Name = "_Label1_11"
        Me._Label1_11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_11.Size = New System.Drawing.Size(136, 19)
        Me._Label1_11.TabIndex = 9
        Me._Label1_11.Text = "Carichi esterni"
        '
        '_Label1_10
        '
        Me._Label1_10.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_10.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_10.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_10.Location = New System.Drawing.Point(0, 96)
        Me._Label1_10.Name = "_Label1_10"
        Me._Label1_10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_10.Size = New System.Drawing.Size(144, 19)
        Me._Label1_10.TabIndex = 8
        Me._Label1_10.Text = "Sistema di misura"
        '
        '_Label1_3
        '
        Me._Label1_3.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_3.Location = New System.Drawing.Point(0, 48)
        Me._Label1_3.Name = "_Label1_3"
        Me._Label1_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_3.Size = New System.Drawing.Size(144, 19)
        Me._Label1_3.TabIndex = 2
        Me._Label1_3.Text = "Tipo di analisi"
        '
        '_Label1_2
        '
        Me._Label1_2.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_2.Location = New System.Drawing.Point(0, 24)
        Me._Label1_2.Name = "_Label1_2"
        Me._Label1_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_2.Size = New System.Drawing.Size(128, 19)
        Me._Label1_2.TabIndex = 1
        Me._Label1_2.Text = "N° base di casi di carico"
        '
        '_Label1_1
        '
        Me._Label1_1.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_1.Location = New System.Drawing.Point(0, 0)
        Me._Label1_1.Name = "_Label1_1"
        Me._Label1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_1.Size = New System.Drawing.Size(208, 19)
        Me._Label1_1.TabIndex = 0
        Me._Label1_1.Text = "N° di bocchelli"
        '
        'lblCodice
        '
        Me.lblCodice.Location = New System.Drawing.Point(0, 72)
        Me.lblCodice.Name = "lblCodice"
        Me.lblCodice.Size = New System.Drawing.Size(136, 24)
        Me.lblCodice.TabIndex = 38
        Me.lblCodice.Text = "Codice applicabile"
        '
        'cmbCodice
        '
        Me.cmbCodice.Location = New System.Drawing.Point(152, 72)
        Me.cmbCodice.Name = "cmbCodice"
        Me.cmbCodice.Size = New System.Drawing.Size(184, 21)
        Me.cmbCodice.TabIndex = 39
        '
        'frmGen
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(343, 392)
        Me.ControlBox = False
        Me.Controls.Add(Me.cmbCodice)
        Me.Controls.Add(Me.lblCodice)
        Me.Controls.Add(Me._Combo1_16)
        Me.Controls.Add(Me._Combo1_15)
        Me.Controls.Add(Me._Combo1_14)
        Me.Controls.Add(Me._Combo1_0)
        Me.Controls.Add(Me._Combo1_13)
        Me.Controls.Add(Me._Combo1_12)
        Me.Controls.Add(Me._Combo1_11)
        Me.Controls.Add(Me._Combo1_10)
        Me.Controls.Add(Me._Text1_2)
        Me.Controls.Add(Me._Text1_1)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me._Combo1_3)
        Me.Controls.Add(Me._Label1_0)
        Me.Controls.Add(Me._Label1_16)
        Me.Controls.Add(Me._Label1_15)
        Me.Controls.Add(Me._Label1_14)
        Me.Controls.Add(Me._Label1_13)
        Me.Controls.Add(Me._Label1_12)
        Me.Controls.Add(Me._Label1_11)
        Me.Controls.Add(Me._Label1_10)
        Me.Controls.Add(Me._Label1_3)
        Me.Controls.Add(Me._Label1_2)
        Me.Controls.Add(Me._Label1_1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Location = New System.Drawing.Point(4, 24)
        Me.Name = "frmGen"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "WRCB - Dati generali"
        Me.ResumeLayout(False)

    End Sub
#End Region 
#Region "Supporto aggiornamento "
	Private Shared m_vb6FormDefInstance As frmGen
	Private Shared m_InitializingDefInstance As Boolean
	Public Shared Property DefInstance() As frmGen
		Get
			If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
				m_InitializingDefInstance = True
				m_vb6FormDefInstance = New frmGen()
				m_InitializingDefInstance = False
			End If
			DefInstance = m_vb6FormDefInstance
		End Get
		Set
			m_vb6FormDefInstance = Value
		End Set
	End Property
#End Region 
    Public OK As Boolean
    Private Inizializzando As Boolean
    Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
        OK = False
        Hide()
    End Sub
    Private Sub cmdOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOK.Click
        Dim i As Short
        objWRCB.Ridimens()
        For i = 1 To Config.NBocch
            If Geom(i).Casi = 0 Then Geom(i).Casi = Config.Casi
        Next
        OK = True
        Hide()
    End Sub
    Private Sub Combo1_SelectedIndexChanged(ByVal Index As Integer)
        If Inizializzando Then Exit Sub
        Dim Testo As String
        Select Case Index
            Case 0
                Config.EndEffect = -Combo1(Index).SelectedIndex
            Case 3 'tipo di analisi
                Config.Analisi = Combo1(Index).SelectedIndex
                If Config.Analisi > 0 Then Combo1(11).SelectedIndex = 0
                If Config.Analisi > 0 And Me.Visible Then
                    Testo = "E' stato scelto un tipo di analisi diverso da" & vbCrLf
                    Testo = Testo & "'Shell Analysis Only'. Tale scelta è fortemente sconsigliata."
                    MsgBox(Testo, MsgBoxStyle.Information)
                End If
            Case 10 'sistema di misura
                Config.UnitSis = Combo1(Index).SelectedIndex
            Case 11
                Config.Chart = Combo1(Index).SelectedIndex + 1
            Case 12 'regola
                Config.WRC297 = Combo1(Index).SelectedIndex + 1
                Select Case Config.WRC297
                    Case 1, 2
                        Config.ConvSumm = 1
                        Combo1(16).Visible = False
                        _Label1_16.Visible = False
                    Case 3, 4
                        Combo1(16).Visible = True
                        _Label1_16.Visible = True
                End Select
            Case 13 'riporto al piede
                Config.Reduced = Combo1(Index).SelectedIndex
            Case 14 'messagistica
                Config.Verbose = Combo1(Index).SelectedIndex
            Case 15 'note
                Config.Note = -Combo1(Index).SelectedIndex
            Case 16 'convenzione della somma
                Config.ConvSumm = Combo1(Index).SelectedIndex + 1
            Case 17 'ammissibili
                Config.Ammiss = Combo1(Index).SelectedIndex
        End Select
    End Sub
    Private ReadOnly Property Combo1(ByVal i As Integer) As ComboBox
        Get
            Select Case i
                Case 0 : Return _Combo1_0
                Case 3 : Return _Combo1_3
                Case 10 : Return _Combo1_10
                Case 11 : Return _Combo1_11
                Case 12 : Return _Combo1_12
                Case 13 : Return _Combo1_13
                Case 14 : Return _Combo1_14
                Case 15 : Return _Combo1_15
                Case 16 : Return _Combo1_16
                Case Else : Return Nothing
            End Select
        End Get
    End Property
    Private ReadOnly Property Text1(ByVal i As Integer) As TextBox
        Get
            Select Case i
                Case 2 : Return _Text1_2
                Case 1 : Return _Text1_1
                Case Else : Return Nothing
            End Select
        End Get
    End Property
    Private Sub frmGen_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Dim k, k1 As Short
        Dim Csv As String = ""
        Dim Riga As String
        k = 1
        Do
            k1 = k
            Riga = ExtLoads(k1, Csv)
            If k1 = 0 Or VB.Left(Riga, 1) = "." Then Exit Do
            Combo1(11).Items.Add(Riga)
            k = k + 1
        Loop
        Combo1(0).Items.Add("NO")
        Combo1(0).Items.Add("SI")
        Combo1(14).Items.Add("Laconica")
        Combo1(14).Items.Add("Verbosa ")
        Combo1(3).Items.Add(" Shell Analysis Only    ")
        Combo1(3).Items.Add(" Shell & Nozzle Analysis")
        Combo1(3).Items.Add(" Nozzle Analysis Only   ")
        Combo1(10).Items.Add("SI       : [mm],[N] ,[°C],[MPa]")
        Combo1(10).Items.Add("Technical: [mm],[Kg],[°C],[ata]")
        Combo1(10).Items.Add("Imperial : [mm],[lb],[°F],[psi]")
        Combo1(12).Items.Add("WRCB 107         ")
        Combo1(12).Items.Add("WRCB 107/WRCB 297")
        Combo1(12).Items.Add("107/BS5500 App.G ")
        Combo1(12).Items.Add("BS5500 App.G ")
        Combo1(16).Items.Add("WRCB 107   ")
        Combo1(16).Items.Add("BS5500 App.G ")
        Combo1(13).Items.Add("NO")
        Combo1(13).Items.Add("SI")
        Combo1(15).Items.Add("NO")
        Combo1(15).Items.Add("SI")
        Dim s As String() = Monitor.Motore.Inizio.CodiciCalc
        For k = 0 To s.GetUpperBound(0)
            cmbCodice.Items.Add(s(k))
        Next
        'Stringa(1) = "Nø di bocchelli"
        Text1(1).Text = globalRoutines.myStr(CSng(Config.NBocch), 3, 0, True)
        'Stringa(2) = "Nø base di casi di carico"
        Text1(2).Text = globalRoutines.myStr(CSng(Config.Casi), 3, 0, True)
        'Stringa(3) = "Tipo di analisi"
        If Config.EndEffect Then Combo1(0).SelectedIndex = 1 Else Combo1(0).SelectedIndex = 0
        Combo1(3).SelectedIndex = Config.Analisi
        'Stringa(10) = "Sistema di misura"
        Combo1(10).SelectedIndex = Config.UnitSis
        'Stringa(11) = "Carichi esterni"
        Combo1(11).SelectedIndex = Config.Chart - 1 'ExtLoads(Config.Chart, Csv$)
        'Stringa(12) = "Metodo di calcolo"
        Combo1(12).SelectedIndex = Config.WRC297 - 1
        'Stringa(13) = "Tagli da riportare al piede"
        Combo1(13).SelectedIndex = Config.Reduced
        'Stringa(14) = "Messaggistica"
        If Config.Verbose <> 0 Then Config.Verbose = 1
        Combo1(14).SelectedIndex = Config.Verbose
        'Stringa(15) = "Note esplicative nel rapporto"
        Combo1(15).SelectedIndex = -Config.Note
        'Stringa(16) = "Convenzione sulla somma"
        Combo1(16).SelectedIndex = Config.ConvSumm - 1
        cmbCodice.SelectedIndex = Config.DC
    End Sub
    Private Sub Text1_TextChanged(ByVal Index As Integer)
        If Inizializzando Then Exit Sub
        Dim a As String
        Try
            Select Case Index
                Case 1 : Config.NBocch = GlobaLroutines.ValVir(Text1(Index).Text)
                Case 2
                    Config.Casi = GlobaLroutines.ValVir(Text1(Index).Text)
                    If Config.Casi > 6 Then
                        a = " E' ammesso un numero massimo|"
                        a = a & "di sei casi di carico    |"
                        MsgBox(Monitor.clsInizio.ConvertiCr(a), MsgBoxStyle.Information + MsgBoxStyle.OKOnly)
                        Text1(Index).Text = "6"
                    End If
                    If Config.Casi < 1 Then Text1(Index).Text = "1"
            End Select
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub

    Private Sub cmbCodice_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbCodice.SelectedIndexChanged
        Config.DC = cmbCodice.SelectedIndex
    End Sub

    Private Sub _Combo1_0_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Combo1_0.SelectedIndexChanged
        Combo1_SelectedIndexChanged(0)
    End Sub

    Private Sub _Combo1_10_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Combo1_10.SelectedIndexChanged
        Combo1_SelectedIndexChanged(10)
    End Sub

    Private Sub _Combo1_11_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Combo1_11.SelectedIndexChanged
        Combo1_SelectedIndexChanged(11)
    End Sub

    Private Sub _Combo1_12_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Combo1_12.SelectedIndexChanged
        Combo1_SelectedIndexChanged(12)
    End Sub

    Private Sub _Combo1_13_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Combo1_13.SelectedIndexChanged
        Combo1_SelectedIndexChanged(13)
    End Sub

    Private Sub _Combo1_14_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Combo1_14.SelectedIndexChanged
        Combo1_SelectedIndexChanged(14)
    End Sub

    Private Sub _Combo1_15_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Combo1_15.SelectedIndexChanged
        Combo1_SelectedIndexChanged(15)
    End Sub

    Private Sub _Combo1_16_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Combo1_16.SelectedIndexChanged
        Combo1_SelectedIndexChanged(16)
    End Sub

    Private Sub _Combo1_3_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Combo1_3.SelectedIndexChanged
        Combo1_SelectedIndexChanged(3)
    End Sub

    Private Sub _Text1_1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Text1_1.TextChanged
        Text1_TextChanged(1)
    End Sub

    Private Sub _Text1_2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Text1_2.TextChanged
        Text1_TextChanged(2)
    End Sub
End Class