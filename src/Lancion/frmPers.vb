Option Strict On
Option Explicit On 
Imports System.io
Friend Class frmPers
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
	Public WithEvents _Picture1_1 As System.Windows.Forms.PictureBox
	Public WithEvents Command2 As System.Windows.Forms.Button
	Public WithEvents Command1 As System.Windows.Forms.Button
    Public WithEvents _Picture1_0 As System.Windows.Forms.PictureBox
	Public WithEvents txtAzienda As System.Windows.Forms.TextBox
    Public WithEvents _Label2_1 As System.Windows.Forms.Label
	Public WithEvents _Label2_0 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents Picture1 As Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray
    'NOTA: la routine seguente è richiesta dalla progettazione Windows Form.
	'Può essere modificata utilizzando la finestra di progettazione Windows Form.
	'Non modificarla mediante l'editor di codice.
    Friend WithEvents NumericUpDown1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents NumericUpDown2 As System.Windows.Forms.NumericUpDown
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmdHelp = New System.Windows.Forms.Button
        Me._Picture1_1 = New System.Windows.Forms.PictureBox
        Me.Command2 = New System.Windows.Forms.Button
        Me.Command1 = New System.Windows.Forms.Button
        Me._Picture1_0 = New System.Windows.Forms.PictureBox
        Me.txtAzienda = New System.Windows.Forms.TextBox
        Me._Label2_1 = New System.Windows.Forms.Label
        Me._Label2_0 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Picture1 = New Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray(Me.components)
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown
        Me.NumericUpDown2 = New System.Windows.Forms.NumericUpDown
        CType(Me.Picture1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdHelp
        '
        Me.cmdHelp.BackColor = System.Drawing.SystemColors.Control
        Me.cmdHelp.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdHelp.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdHelp.Location = New System.Drawing.Point(240, 320)
        Me.cmdHelp.Name = "cmdHelp"
        Me.cmdHelp.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdHelp.Size = New System.Drawing.Size(73, 25)
        Me.cmdHelp.TabIndex = 10
        Me.cmdHelp.Text = "Help"
        '
        '_Picture1_1
        '
        Me._Picture1_1.BackColor = System.Drawing.SystemColors.Control
        Me._Picture1_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._Picture1_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._Picture1_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Picture1.SetIndex(Me._Picture1_1, CType(1, Short))
        Me._Picture1_1.Location = New System.Drawing.Point(136, 160)
        Me._Picture1_1.Name = "_Picture1_1"
        Me._Picture1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Picture1_1.Size = New System.Drawing.Size(248, 72)
        Me._Picture1_1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me._Picture1_1.TabIndex = 8
        Me._Picture1_1.TabStop = False
        '
        'Command2
        '
        Me.Command2.BackColor = System.Drawing.SystemColors.Control
        Me.Command2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command2.Location = New System.Drawing.Point(320, 320)
        Me.Command2.Name = "Command2"
        Me.Command2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command2.Size = New System.Drawing.Size(73, 25)
        Me.Command2.TabIndex = 6
        Me.Command2.Text = "Cancel"
        '
        'Command1
        '
        Me.Command1.BackColor = System.Drawing.SystemColors.Control
        Me.Command1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command1.Location = New System.Drawing.Point(400, 320)
        Me.Command1.Name = "Command1"
        Me.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command1.Size = New System.Drawing.Size(65, 25)
        Me.Command1.TabIndex = 5
        Me.Command1.Text = "OK"
        '
        '_Picture1_0
        '
        Me._Picture1_0.BackColor = System.Drawing.SystemColors.Control
        Me._Picture1_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._Picture1_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Picture1_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Picture1.SetIndex(Me._Picture1_0, CType(0, Short))
        Me._Picture1_0.Location = New System.Drawing.Point(136, 80)
        Me._Picture1_0.Name = "_Picture1_0"
        Me._Picture1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Picture1_0.Size = New System.Drawing.Size(320, 72)
        Me._Picture1_0.TabIndex = 3
        Me._Picture1_0.TabStop = False
        '
        'txtAzienda
        '
        Me.txtAzienda.AcceptsReturn = True
        Me.txtAzienda.AutoSize = False
        Me.txtAzienda.BackColor = System.Drawing.SystemColors.Window
        Me.txtAzienda.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtAzienda.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtAzienda.Location = New System.Drawing.Point(136, 0)
        Me.txtAzienda.MaxLength = 0
        Me.txtAzienda.Name = "txtAzienda"
        Me.txtAzienda.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtAzienda.Size = New System.Drawing.Size(321, 25)
        Me.txtAzienda.TabIndex = 1
        Me.txtAzienda.Text = ""
        '
        '_Label2_1
        '
        Me._Label2_1.BackColor = System.Drawing.SystemColors.Control
        Me._Label2_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label2_1.Location = New System.Drawing.Point(8, 168)
        Me._Label2_1.Name = "_Label2_1"
        Me._Label2_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_1.Size = New System.Drawing.Size(73, 17)
        Me._Label2_1.TabIndex = 9
        Me._Label2_1.Text = "Indirizzo"
        '
        '_Label2_0
        '
        Me._Label2_0.BackColor = System.Drawing.SystemColors.Control
        Me._Label2_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label2_0.Location = New System.Drawing.Point(8, 88)
        Me._Label2_0.Name = "_Label2_0"
        Me._Label2_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_0.Size = New System.Drawing.Size(73, 17)
        Me._Label2_0.TabIndex = 2
        Me._Label2_0.Text = "Logo"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(8, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(113, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nome Azienda"
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.Location = New System.Drawing.Point(112, 104)
        Me.NumericUpDown1.Maximum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Size = New System.Drawing.Size(16, 20)
        Me.NumericUpDown1.TabIndex = 11
        '
        'NumericUpDown2
        '
        Me.NumericUpDown2.Location = New System.Drawing.Point(112, 184)
        Me.NumericUpDown2.Maximum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumericUpDown2.Name = "NumericUpDown2"
        Me.NumericUpDown2.Size = New System.Drawing.Size(16, 20)
        Me.NumericUpDown2.TabIndex = 12
        '
        'frmPers
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(470, 363)
        Me.ControlBox = False
        Me.Controls.Add(Me.NumericUpDown2)
        Me.Controls.Add(Me.NumericUpDown1)
        Me.Controls.Add(Me.cmdHelp)
        Me.Controls.Add(Me._Picture1_1)
        Me.Controls.Add(Me.Command2)
        Me.Controls.Add(Me.Command1)
        Me.Controls.Add(Me._Picture1_0)
        Me.Controls.Add(Me.txtAzienda)
        Me.Controls.Add(Me._Label2_1)
        Me.Controls.Add(Me._Label2_0)
        Me.Controls.Add(Me.Label1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPers"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "Personalizzazione Azienda"
        CType(Me.Picture1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
#End Region 
#Region "Supporto aggiornamento "
	Private Shared m_vb6FormDefInstance As frmPers
	Private Shared m_InitializingDefInstance As Boolean
	Public Shared Property DefInstance() As frmPers
		Get
			If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
				m_InitializingDefInstance = True
				m_vb6FormDefInstance = New frmPers()
				m_InitializingDefInstance = False
			End If
			DefInstance = m_vb6FormDefInstance
		End Get
		Set
			m_vb6FormDefInstance = Value
		End Set
	End Property
#End Region 
	Private Immagini(10) As String
	Private Indirizzi(10) As String
    Private jj, j, i As Integer
	
	Private Sub cmdhelp_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdhelp.Click
        Help.ShowHelp(Me, RadiceHelp, HelpNavigator.Topic, "mnuPref.htm#Pers")
	End Sub
	
	Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
        With Monitor.Motore.Inizio
            .WriteIniFile("", "Azienda", "Firma", txtAzienda.Text)
            .WriteIniFile("", "Azienda", "Logo", Immagini(j))
            .WriteIniFile("", "Azienda", "Indirizzo", Indirizzi(jj))
        End With
        Me.Close()
    End Sub
    Private Sub Command2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command2.Click
        Me.Close()
    End Sub
    Private Sub frmPers_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Dim LogoFile As String
        Dim IndirFile As String
        Dim di As New DirectoryInfo(Monitor.Motore.Inizio.Archdir)
        Dim fi() As FileInfo = di.GetFiles("logo*.BMP")
        Try
            For i = 0 To UBound(fi)
                Immagini(i) = fi(i).Name
            Next
            i = i - 1
            LogoFile = Monitor.Motore.Inizio.ReadIniFile("", "Azienda", "Logo")
            IndirFile = Monitor.Motore.Inizio.ReadIniFile("", "Azienda", "Indirizzo")
            txtAzienda.Text = Monitor.Motore.Inizio.Firma
            If Len(LogoFile) > 0 Then
                For j = 0 To i
                    If Trim(LogoFile) = Trim(Immagini(j)) Then GoTo Cont
                Next
                j = 0
Cont:           If j > 0 Then
                    Picture1(0).Image = System.Drawing.Image.FromFile(Monitor.Motore.Inizio.Archdir & "\" & LogoFile)
                Else
                    j = 0
                    Picture1(0).Image = System.Drawing.Image.FromFile(Monitor.Motore.Inizio.Archdir & "\" & Immagini(j))
                End If
            Else
                j = 0
            End If
            If i < 0 Then Exit Sub
            NumericUpDown1.Maximum = i
            NumericUpDown1.Value = j
            i = 0
            di = New DirectoryInfo(Monitor.Motore.Inizio.Archdir)
            fi = di.GetFiles("indir*.BMP")
            For i = 0 To UBound(fi)
                Indirizzi(i) = fi(i).Name
            Next
            i = i - 1
            If i < 0 Then Exit Sub
            If Len(IndirFile) > 0 Then
                For jj = 0 To i
                    If Trim(IndirFile) = Trim(Indirizzi(jj)) Then GoTo Cont1
                Next
                jj = 0
Cont1:          If jj > 0 Then
                    Picture1(1).Image = System.Drawing.Image.FromFile(Monitor.Motore.Inizio.Archdir & "\" & IndirFile)
                Else
                    jj = 0
                    Picture1(1).Image = System.Drawing.Image.FromFile(Monitor.Motore.Inizio.Archdir & "\" & Indirizzi(jj))
                End If
            Else
                jj = 0
            End If
            If i = 0 Then Exit Sub
            NumericUpDown2.Maximum = i
            NumericUpDown2.Value = jj
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Private Sub NumericUpDown1_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles NumericUpDown1.ValueChanged
        j = CInt(NumericUpDown1.Value)
        Picture1(0).Image = System.Drawing.Image.FromFile(Monitor.Motore.Inizio.Archdir & "\" & Immagini(j))
    End Sub

    Private Sub NumericUpDown2_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles NumericUpDown2.ValueChanged
        jj = CInt(NumericUpDown2.Value)
        Picture1(1).Image = System.Drawing.Image.FromFile(Monitor.Motore.Inizio.Archdir & "\" & Indirizzi(jj))

    End Sub
End Class