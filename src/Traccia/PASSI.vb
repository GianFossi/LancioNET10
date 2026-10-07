Option Strict Off
Option Explicit On
Friend Class PASSI
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
	Public WithEvents _Picture1_0 As System.Windows.Forms.PictureBox
	Public WithEvents _Picture1_11 As System.Windows.Forms.PictureBox
	Public WithEvents _Picture1_10 As System.Windows.Forms.PictureBox
	Public WithEvents _Picture1_9 As System.Windows.Forms.PictureBox
	Public WithEvents _Picture1_8 As System.Windows.Forms.PictureBox
	Public WithEvents _Picture1_7 As System.Windows.Forms.PictureBox
	Public WithEvents _Picture1_6 As System.Windows.Forms.PictureBox
	Public WithEvents _Picture1_4 As System.Windows.Forms.PictureBox
	Public WithEvents _Picture1_5 As System.Windows.Forms.PictureBox
	Public WithEvents _Picture1_3 As System.Windows.Forms.PictureBox
	Public WithEvents _Picture1_2 As System.Windows.Forms.PictureBox
	Public WithEvents _Picture1_1 As System.Windows.Forms.PictureBox
    'NOTA: la routine seguente è richiesta dalla progettazione Windows Form.
	'Può essere modificata utilizzando la finestra di progettazione Windows Form.
	'Non modificarla mediante l'editor di codice.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(PASSI))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me._Picture1_0 = New System.Windows.Forms.PictureBox
        Me._Picture1_11 = New System.Windows.Forms.PictureBox
        Me._Picture1_10 = New System.Windows.Forms.PictureBox
        Me._Picture1_9 = New System.Windows.Forms.PictureBox
        Me._Picture1_8 = New System.Windows.Forms.PictureBox
        Me._Picture1_7 = New System.Windows.Forms.PictureBox
        Me._Picture1_6 = New System.Windows.Forms.PictureBox
        Me._Picture1_4 = New System.Windows.Forms.PictureBox
        Me._Picture1_5 = New System.Windows.Forms.PictureBox
        Me._Picture1_3 = New System.Windows.Forms.PictureBox
        Me._Picture1_2 = New System.Windows.Forms.PictureBox
        Me._Picture1_1 = New System.Windows.Forms.PictureBox
        Me.SuspendLayout()
        '
        '_Picture1_0
        '
        Me._Picture1_0.BackColor = System.Drawing.SystemColors.Control
        Me._Picture1_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._Picture1_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Picture1_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Picture1_0.Image = CType(resources.GetObject("_Picture1_0.Image"), System.Drawing.Image)
        Me._Picture1_0.Location = New System.Drawing.Point(0, 0)
        Me._Picture1_0.Name = "_Picture1_0"
        Me._Picture1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Picture1_0.Size = New System.Drawing.Size(120, 100)
        Me._Picture1_0.TabIndex = 11
        Me._Picture1_0.TabStop = False
        '
        '_Picture1_11
        '
        Me._Picture1_11.BackColor = System.Drawing.SystemColors.Control
        Me._Picture1_11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._Picture1_11.Cursor = System.Windows.Forms.Cursors.Default
        Me._Picture1_11.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Picture1_11.Image = CType(resources.GetObject("_Picture1_11.Image"), System.Drawing.Image)
        Me._Picture1_11.Location = New System.Drawing.Point(360, 200)
        Me._Picture1_11.Name = "_Picture1_11"
        Me._Picture1_11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Picture1_11.Size = New System.Drawing.Size(115, 95)
        Me._Picture1_11.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me._Picture1_11.TabIndex = 10
        Me._Picture1_11.TabStop = False
        '
        '_Picture1_10
        '
        Me._Picture1_10.BackColor = System.Drawing.SystemColors.Control
        Me._Picture1_10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._Picture1_10.Cursor = System.Windows.Forms.Cursors.Default
        Me._Picture1_10.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Picture1_10.Image = CType(resources.GetObject("_Picture1_10.Image"), System.Drawing.Image)
        Me._Picture1_10.Location = New System.Drawing.Point(240, 200)
        Me._Picture1_10.Name = "_Picture1_10"
        Me._Picture1_10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Picture1_10.Size = New System.Drawing.Size(115, 95)
        Me._Picture1_10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me._Picture1_10.TabIndex = 9
        Me._Picture1_10.TabStop = False
        '
        '_Picture1_9
        '
        Me._Picture1_9.BackColor = System.Drawing.SystemColors.Control
        Me._Picture1_9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._Picture1_9.Cursor = System.Windows.Forms.Cursors.Default
        Me._Picture1_9.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Picture1_9.Image = CType(resources.GetObject("_Picture1_9.Image"), System.Drawing.Image)
        Me._Picture1_9.Location = New System.Drawing.Point(120, 200)
        Me._Picture1_9.Name = "_Picture1_9"
        Me._Picture1_9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Picture1_9.Size = New System.Drawing.Size(115, 95)
        Me._Picture1_9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me._Picture1_9.TabIndex = 8
        Me._Picture1_9.TabStop = False
        '
        '_Picture1_8
        '
        Me._Picture1_8.BackColor = System.Drawing.SystemColors.Control
        Me._Picture1_8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._Picture1_8.Cursor = System.Windows.Forms.Cursors.Default
        Me._Picture1_8.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Picture1_8.Image = CType(resources.GetObject("_Picture1_8.Image"), System.Drawing.Image)
        Me._Picture1_8.Location = New System.Drawing.Point(0, 200)
        Me._Picture1_8.Name = "_Picture1_8"
        Me._Picture1_8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Picture1_8.Size = New System.Drawing.Size(115, 95)
        Me._Picture1_8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me._Picture1_8.TabIndex = 7
        Me._Picture1_8.TabStop = False
        '
        '_Picture1_7
        '
        Me._Picture1_7.BackColor = System.Drawing.SystemColors.Control
        Me._Picture1_7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._Picture1_7.Cursor = System.Windows.Forms.Cursors.Default
        Me._Picture1_7.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Picture1_7.Image = CType(resources.GetObject("_Picture1_7.Image"), System.Drawing.Image)
        Me._Picture1_7.Location = New System.Drawing.Point(360, 100)
        Me._Picture1_7.Name = "_Picture1_7"
        Me._Picture1_7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Picture1_7.Size = New System.Drawing.Size(115, 95)
        Me._Picture1_7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me._Picture1_7.TabIndex = 6
        Me._Picture1_7.TabStop = False
        '
        '_Picture1_6
        '
        Me._Picture1_6.BackColor = System.Drawing.SystemColors.Control
        Me._Picture1_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._Picture1_6.Cursor = System.Windows.Forms.Cursors.Default
        Me._Picture1_6.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Picture1_6.Image = CType(resources.GetObject("_Picture1_6.Image"), System.Drawing.Image)
        Me._Picture1_6.Location = New System.Drawing.Point(240, 100)
        Me._Picture1_6.Name = "_Picture1_6"
        Me._Picture1_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Picture1_6.Size = New System.Drawing.Size(115, 95)
        Me._Picture1_6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me._Picture1_6.TabIndex = 5
        Me._Picture1_6.TabStop = False
        '
        '_Picture1_4
        '
        Me._Picture1_4.BackColor = System.Drawing.SystemColors.Control
        Me._Picture1_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._Picture1_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._Picture1_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Picture1_4.Image = CType(resources.GetObject("_Picture1_4.Image"), System.Drawing.Image)
        Me._Picture1_4.Location = New System.Drawing.Point(0, 100)
        Me._Picture1_4.Name = "_Picture1_4"
        Me._Picture1_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Picture1_4.Size = New System.Drawing.Size(115, 95)
        Me._Picture1_4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me._Picture1_4.TabIndex = 4
        Me._Picture1_4.TabStop = False
        '
        '_Picture1_5
        '
        Me._Picture1_5.BackColor = System.Drawing.SystemColors.Control
        Me._Picture1_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._Picture1_5.Cursor = System.Windows.Forms.Cursors.Default
        Me._Picture1_5.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Picture1_5.Image = CType(resources.GetObject("_Picture1_5.Image"), System.Drawing.Image)
        Me._Picture1_5.Location = New System.Drawing.Point(120, 100)
        Me._Picture1_5.Name = "_Picture1_5"
        Me._Picture1_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Picture1_5.Size = New System.Drawing.Size(115, 95)
        Me._Picture1_5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me._Picture1_5.TabIndex = 3
        Me._Picture1_5.TabStop = False
        '
        '_Picture1_3
        '
        Me._Picture1_3.BackColor = System.Drawing.SystemColors.Control
        Me._Picture1_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._Picture1_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._Picture1_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Picture1_3.Image = CType(resources.GetObject("_Picture1_3.Image"), System.Drawing.Image)
        Me._Picture1_3.Location = New System.Drawing.Point(360, 0)
        Me._Picture1_3.Name = "_Picture1_3"
        Me._Picture1_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Picture1_3.Size = New System.Drawing.Size(115, 95)
        Me._Picture1_3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me._Picture1_3.TabIndex = 2
        Me._Picture1_3.TabStop = False
        '
        '_Picture1_2
        '
        Me._Picture1_2.BackColor = System.Drawing.SystemColors.Control
        Me._Picture1_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._Picture1_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._Picture1_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Picture1_2.Image = CType(resources.GetObject("_Picture1_2.Image"), System.Drawing.Image)
        Me._Picture1_2.Location = New System.Drawing.Point(240, 0)
        Me._Picture1_2.Name = "_Picture1_2"
        Me._Picture1_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Picture1_2.Size = New System.Drawing.Size(115, 95)
        Me._Picture1_2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me._Picture1_2.TabIndex = 1
        Me._Picture1_2.TabStop = False
        '
        '_Picture1_1
        '
        Me._Picture1_1.BackColor = System.Drawing.SystemColors.Control
        Me._Picture1_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._Picture1_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._Picture1_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Picture1_1.Image = CType(resources.GetObject("_Picture1_1.Image"), System.Drawing.Image)
        Me._Picture1_1.Location = New System.Drawing.Point(120, 0)
        Me._Picture1_1.Name = "_Picture1_1"
        Me._Picture1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Picture1_1.Size = New System.Drawing.Size(115, 95)
        Me._Picture1_1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me._Picture1_1.TabIndex = 0
        Me._Picture1_1.TabStop = False
        '
        'PASSI
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(478, 298)
        Me.Controls.Add(Me._Picture1_0)
        Me.Controls.Add(Me._Picture1_11)
        Me.Controls.Add(Me._Picture1_10)
        Me.Controls.Add(Me._Picture1_9)
        Me.Controls.Add(Me._Picture1_8)
        Me.Controls.Add(Me._Picture1_7)
        Me.Controls.Add(Me._Picture1_6)
        Me.Controls.Add(Me._Picture1_4)
        Me.Controls.Add(Me._Picture1_5)
        Me.Controls.Add(Me._Picture1_3)
        Me.Controls.Add(Me._Picture1_2)
        Me.Controls.Add(Me._Picture1_1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Location = New System.Drawing.Point(2, 18)
        Me.MaximizeBox = False
        Me.Name = "PASSI"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowInTaskbar = False
        Me.Text = "Passi Lato Tubi"
        Me.ResumeLayout(False)

    End Sub
#End Region 
#Region "Supporto aggiornamento "
	Private Shared m_vb6FormDefInstance As PASSI
	Private Shared m_InitializingDefInstance As Boolean
	Public Shared Property DefInstance() As PASSI
		Get
			If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
				m_InitializingDefInstance = True
				m_vb6FormDefInstance = New PASSI()
				m_InitializingDefInstance = False
			End If
			DefInstance = m_vb6FormDefInstance
		End Get
		Set
			m_vb6FormDefInstance = Value
		End Set
	End Property
#End Region 
	Public indice As Short
	Private Sub PASSI_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		'   Dim p As Picture, i As Integer
		'   For i = 0 To Picture1.Count
		'       SavePicture Picture1(i), "C:\Pic" + Trim(Str(i)) + ".BMP"
		'   Next
	End Sub
    Private Sub Picture1_Click(ByVal Index As Short)
        indice = Index
        Hide()
    End Sub
    Private Sub Picture1_MouseMove(ByVal Index As Short)
        Dim i As Short
        For i = 0 To 11
            If i = Index Then
                Picture1(i).BorderStyle = System.Windows.Forms.BorderStyle.None
            Else
                Picture1(i).BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            End If
        Next i
    End Sub
    Friend ReadOnly Property Picture1(ByVal i As Short) As PictureBox
        Get
            Select Case i
                Case 0 : Return _Picture1_0
                Case 1 : Return _Picture1_1
                Case 2 : Return _Picture1_2
                Case 3 : Return _Picture1_3
                Case 4 : Return _Picture1_4
                Case 5 : Return _Picture1_5
                Case 6 : Return _Picture1_6
                Case 7 : Return _Picture1_7
                Case 8 : Return _Picture1_8
                Case 9 : Return _Picture1_9
                Case 10 : Return _Picture1_10
                Case 11 : Return _Picture1_11
                Case Else : Return Nothing
            End Select
        End Get
    End Property

    Private Sub _Picture1_0_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles _Picture1_0.MouseMove
        Picture1_MouseMove(0)
    End Sub
    Private Sub _Picture1_1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles _Picture1_1.MouseMove
        Picture1_MouseMove(1)
    End Sub
    Private Sub _Picture1_2_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles _Picture1_2.MouseMove
        Picture1_MouseMove(2)
    End Sub
    Private Sub _Picture1_3_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles _Picture1_3.MouseMove
        Picture1_MouseMove(3)
    End Sub
    Private Sub _Picture1_4_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles _Picture1_4.MouseMove
        Picture1_MouseMove(4)
    End Sub
    Private Sub _Picture1_5_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles _Picture1_5.MouseMove
        Picture1_MouseMove(5)
    End Sub
    Private Sub _Picture1_6_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles _Picture1_6.MouseMove
        Picture1_MouseMove(6)
    End Sub
    Private Sub _Picture1_7_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles _Picture1_7.MouseMove
        Picture1_MouseMove(7)
    End Sub
    Private Sub _Picture1_8_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles _Picture1_8.MouseMove
        Picture1_MouseMove(8)
    End Sub
    Private Sub _Picture1_9_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles _Picture1_9.MouseMove
        Picture1_MouseMove(9)
    End Sub
    Private Sub _Picture1_10_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles _Picture1_10.MouseMove
        Picture1_MouseMove(10)
    End Sub
    Private Sub _Picture1_11_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles _Picture1_11.MouseMove
        Picture1_MouseMove(11)
    End Sub
    'WWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWW
    Private Sub _Picture1_0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Picture1_0.Click
        Picture1_Click(0)
    End Sub
    Private Sub _Picture1_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Picture1_1.Click
        Picture1_Click(1)
    End Sub
    Private Sub _Picture1_2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Picture1_2.Click
        Picture1_Click(2)
    End Sub
    Private Sub _Picture1_3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Picture1_3.Click
        Picture1_Click(3)
    End Sub
    Private Sub _Picture1_4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Picture1_4.Click
        Picture1_Click(4)
    End Sub
    Private Sub _Picture1_5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Picture1_5.Click
        Picture1_Click(5)
    End Sub
    Private Sub _Picture1_6_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Picture1_6.Click
        Picture1_Click(6)
    End Sub
    Private Sub _Picture1_7_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Picture1_7.Click
        Picture1_Click(7)
    End Sub
    Private Sub _Picture1_8_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Picture1_8.Click
        Picture1_Click(8)
    End Sub
    Private Sub _Picture1_9_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Picture1_9.Click
        Picture1_Click(9)
    End Sub
    Private Sub _Picture1_10_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Picture1_10.Click
        Picture1_Click(10)
    End Sub
    Private Sub _Picture1_11_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Picture1_11.Click
        Picture1_Click(11)
    End Sub
End Class