Option Strict Off
Option Explicit On
Friend Class frmShowForm
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
	Public WithEvents pctShow As System.Windows.Forms.PictureBox
	Public WithEvents pctForm As System.Windows.Forms.PictureBox
    Public WithEvents cmdCambia As System.Windows.Forms.Button
	Public WithEvents cmbScelta As System.Windows.Forms.ComboBox
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents framSpicchi As System.Windows.Forms.Panel
	Public WithEvents cmdOK As System.Windows.Forms.Button
    Public WithEvents _txtOid_4 As System.Windows.Forms.TextBox
	Public WithEvents _txtOid_3 As System.Windows.Forms.TextBox
	Public WithEvents _txtOid_2 As System.Windows.Forms.TextBox
	Public WithEvents _txtOid_1 As System.Windows.Forms.TextBox
	Public WithEvents _txtOid_0 As System.Windows.Forms.TextBox
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents framOid As System.Windows.Forms.GroupBox
	Public WithEvents txtOid As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
	'NOTA: la routine seguente è richiesta dalla progettazione Windows Form.
	'Può essere modificata utilizzando la finestra di progettazione Windows Form.
	'Non modificarla mediante l'editor di codice.
    Friend WithEvents txtNumSal As System.Windows.Forms.NumericUpDown
    Friend WithEvents TabStrip1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmdHelp = New System.Windows.Forms.Button
        Me.pctShow = New System.Windows.Forms.PictureBox
        Me.pctForm = New System.Windows.Forms.PictureBox
        Me.framSpicchi = New System.Windows.Forms.Panel
        Me.cmdCambia = New System.Windows.Forms.Button
        Me.cmbScelta = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmdOK = New System.Windows.Forms.Button
        Me.framOid = New System.Windows.Forms.GroupBox
        Me.txtNumSal = New System.Windows.Forms.NumericUpDown
        Me._txtOid_4 = New System.Windows.Forms.TextBox
        Me._txtOid_3 = New System.Windows.Forms.TextBox
        Me._txtOid_2 = New System.Windows.Forms.TextBox
        Me._txtOid_1 = New System.Windows.Forms.TextBox
        Me._txtOid_0 = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtOid = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(Me.components)
        Me.TabStrip1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.framSpicchi.SuspendLayout()
        Me.framOid.SuspendLayout()
        CType(Me.txtNumSal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtOid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdHelp
        '
        Me.cmdHelp.BackColor = System.Drawing.SystemColors.Control
        Me.cmdHelp.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdHelp.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdHelp.Location = New System.Drawing.Point(568, 480)
        Me.cmdHelp.Name = "cmdHelp"
        Me.cmdHelp.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdHelp.Size = New System.Drawing.Size(57, 25)
        Me.cmdHelp.TabIndex = 17
        Me.cmdHelp.Text = "Help"
        '
        'pctShow
        '
        Me.pctShow.BackColor = System.Drawing.SystemColors.Window
        Me.pctShow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pctShow.Cursor = System.Windows.Forms.Cursors.Default
        Me.pctShow.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pctShow.ForeColor = System.Drawing.SystemColors.WindowText
        Me.pctShow.Location = New System.Drawing.Point(8, 24)
        Me.pctShow.Name = "pctShow"
        Me.pctShow.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.pctShow.Size = New System.Drawing.Size(617, 401)
        Me.pctShow.TabIndex = 16
        Me.pctShow.TabStop = False
        Me.pctShow.Visible = False
        '
        'pctForm
        '
        Me.pctForm.BackColor = System.Drawing.SystemColors.Window
        Me.pctForm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pctForm.Cursor = System.Windows.Forms.Cursors.Default
        Me.pctForm.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pctForm.ForeColor = System.Drawing.SystemColors.WindowText
        Me.pctForm.Location = New System.Drawing.Point(8, 24)
        Me.pctForm.Name = "pctForm"
        Me.pctForm.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.pctForm.Size = New System.Drawing.Size(617, 401)
        Me.pctForm.TabIndex = 15
        Me.pctForm.TabStop = False
        '
        'framSpicchi
        '
        Me.framSpicchi.BackColor = System.Drawing.SystemColors.Control
        Me.framSpicchi.Controls.Add(Me.cmdCambia)
        Me.framSpicchi.Controls.Add(Me.cmbScelta)
        Me.framSpicchi.Controls.Add(Me.Label1)
        Me.framSpicchi.Cursor = System.Windows.Forms.Cursors.Default
        Me.framSpicchi.ForeColor = System.Drawing.SystemColors.ControlText
        Me.framSpicchi.Location = New System.Drawing.Point(160, 448)
        Me.framSpicchi.Name = "framSpicchi"
        Me.framSpicchi.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.framSpicchi.Size = New System.Drawing.Size(385, 33)
        Me.framSpicchi.TabIndex = 1
        Me.framSpicchi.Text = "Frame1"
        '
        'cmdCambia
        '
        Me.cmdCambia.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCambia.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCambia.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCambia.Location = New System.Drawing.Point(248, 0)
        Me.cmdCambia.Name = "cmdCambia"
        Me.cmdCambia.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCambia.Size = New System.Drawing.Size(129, 25)
        Me.cmdCambia.TabIndex = 3
        Me.cmdCambia.Text = "Cambia N° spicchi"
        '
        'cmbScelta
        '
        Me.cmbScelta.BackColor = System.Drawing.SystemColors.Window
        Me.cmbScelta.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbScelta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbScelta.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbScelta.Location = New System.Drawing.Point(176, 3)
        Me.cmbScelta.Name = "cmbScelta"
        Me.cmbScelta.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbScelta.Size = New System.Drawing.Size(65, 21)
        Me.cmbScelta.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(40, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(129, 17)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Tipo di tracciatura scelta"
        '
        'cmdOK
        '
        Me.cmdOK.BackColor = System.Drawing.SystemColors.Control
        Me.cmdOK.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdOK.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdOK.Location = New System.Drawing.Point(568, 448)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdOK.Size = New System.Drawing.Size(57, 25)
        Me.cmdOK.TabIndex = 0
        Me.cmdOK.Text = "OK"
        '
        'framOid
        '
        Me.framOid.BackColor = System.Drawing.SystemColors.Control
        Me.framOid.Controls.Add(Me.txtNumSal)
        Me.framOid.Controls.Add(Me._txtOid_4)
        Me.framOid.Controls.Add(Me._txtOid_3)
        Me.framOid.Controls.Add(Me._txtOid_2)
        Me.framOid.Controls.Add(Me._txtOid_1)
        Me.framOid.Controls.Add(Me._txtOid_0)
        Me.framOid.Controls.Add(Me.Label2)
        Me.framOid.ForeColor = System.Drawing.SystemColors.ControlText
        Me.framOid.Location = New System.Drawing.Point(160, 440)
        Me.framOid.Name = "framOid"
        Me.framOid.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.framOid.Size = New System.Drawing.Size(401, 121)
        Me.framOid.TabIndex = 5
        Me.framOid.TabStop = False
        Me.framOid.Text = "Scelta lamieramento per il conoide"
        Me.framOid.Visible = False
        '
        'txtNumSal
        '
        Me.txtNumSal.Location = New System.Drawing.Point(336, 80)
        Me.txtNumSal.Maximum = New Decimal(New Integer() {2, 0, 0, 0})
        Me.txtNumSal.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.txtNumSal.Name = "txtNumSal"
        Me.txtNumSal.Size = New System.Drawing.Size(48, 20)
        Me.txtNumSal.TabIndex = 14
        Me.txtNumSal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtNumSal.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        '_txtOid_4
        '
        Me._txtOid_4.AcceptsReturn = True
        Me._txtOid_4.AutoSize = False
        Me._txtOid_4.BackColor = System.Drawing.SystemColors.Window
        Me._txtOid_4.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtOid_4.Enabled = False
        Me._txtOid_4.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtOid.SetIndex(Me._txtOid_4, CType(4, Short))
        Me._txtOid_4.Location = New System.Drawing.Point(8, 95)
        Me._txtOid_4.MaxLength = 0
        Me._txtOid_4.Name = "_txtOid_4"
        Me._txtOid_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtOid_4.Size = New System.Drawing.Size(281, 19)
        Me._txtOid_4.TabIndex = 10
        Me._txtOid_4.Text = "Text1"
        '
        '_txtOid_3
        '
        Me._txtOid_3.AcceptsReturn = True
        Me._txtOid_3.AutoSize = False
        Me._txtOid_3.BackColor = System.Drawing.SystemColors.Window
        Me._txtOid_3.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtOid_3.Enabled = False
        Me._txtOid_3.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtOid.SetIndex(Me._txtOid_3, CType(3, Short))
        Me._txtOid_3.Location = New System.Drawing.Point(8, 75)
        Me._txtOid_3.MaxLength = 0
        Me._txtOid_3.Name = "_txtOid_3"
        Me._txtOid_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtOid_3.Size = New System.Drawing.Size(281, 19)
        Me._txtOid_3.TabIndex = 9
        Me._txtOid_3.Text = "Text1"
        '
        '_txtOid_2
        '
        Me._txtOid_2.AcceptsReturn = True
        Me._txtOid_2.AutoSize = False
        Me._txtOid_2.BackColor = System.Drawing.SystemColors.Window
        Me._txtOid_2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtOid_2.Enabled = False
        Me._txtOid_2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtOid.SetIndex(Me._txtOid_2, CType(2, Short))
        Me._txtOid_2.Location = New System.Drawing.Point(8, 56)
        Me._txtOid_2.MaxLength = 0
        Me._txtOid_2.Name = "_txtOid_2"
        Me._txtOid_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtOid_2.Size = New System.Drawing.Size(281, 19)
        Me._txtOid_2.TabIndex = 8
        Me._txtOid_2.Text = "Text1"
        '
        '_txtOid_1
        '
        Me._txtOid_1.AcceptsReturn = True
        Me._txtOid_1.AutoSize = False
        Me._txtOid_1.BackColor = System.Drawing.SystemColors.Window
        Me._txtOid_1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtOid_1.Enabled = False
        Me._txtOid_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtOid.SetIndex(Me._txtOid_1, CType(1, Short))
        Me._txtOid_1.Location = New System.Drawing.Point(8, 36)
        Me._txtOid_1.MaxLength = 0
        Me._txtOid_1.Name = "_txtOid_1"
        Me._txtOid_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtOid_1.Size = New System.Drawing.Size(281, 19)
        Me._txtOid_1.TabIndex = 7
        Me._txtOid_1.Text = "Text1"
        '
        '_txtOid_0
        '
        Me._txtOid_0.AcceptsReturn = True
        Me._txtOid_0.AutoSize = False
        Me._txtOid_0.BackColor = System.Drawing.SystemColors.Window
        Me._txtOid_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtOid_0.Enabled = False
        Me._txtOid_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtOid.SetIndex(Me._txtOid_0, CType(0, Short))
        Me._txtOid_0.Location = New System.Drawing.Point(8, 16)
        Me._txtOid_0.MaxLength = 0
        Me._txtOid_0.Name = "_txtOid_0"
        Me._txtOid_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtOid_0.Size = New System.Drawing.Size(281, 19)
        Me._txtOid_0.TabIndex = 6
        Me._txtOid_0.Text = "Text1"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(304, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(81, 33)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Numero saldature:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'TabStrip1
        '
        Me.TabStrip1.Controls.Add(Me.TabPage1)
        Me.TabStrip1.Controls.Add(Me.TabPage2)
        Me.TabStrip1.Location = New System.Drawing.Point(0, 0)
        Me.TabStrip1.Name = "TabStrip1"
        Me.TabStrip1.SelectedIndex = 0
        Me.TabStrip1.Size = New System.Drawing.Size(632, 432)
        Me.TabStrip1.TabIndex = 18
        '
        'TabPage1
        '
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(624, 406)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Risultati"
        '
        'TabPage2
        '
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(624, 406)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Disegno"
        '
        'frmShowForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(632, 566)
        Me.ControlBox = False
        Me.Controls.Add(Me.cmdHelp)
        Me.Controls.Add(Me.pctShow)
        Me.Controls.Add(Me.pctForm)
        Me.Controls.Add(Me.framSpicchi)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.framOid)
        Me.Controls.Add(Me.TabStrip1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Location = New System.Drawing.Point(4, 23)
        Me.Name = "frmShowForm"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "Lamieramento"
        Me.framSpicchi.ResumeLayout(False)
        Me.framOid.ResumeLayout(False)
        CType(Me.txtNumSal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtOid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
#End Region 
#Region "Supporto aggiornamento "
	Private Shared m_vb6FormDefInstance As frmShowForm
	Private Shared m_InitializingDefInstance As Boolean
	Public Shared Property DefInstance() As frmShowForm
		Get
			If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
				m_InitializingDefInstance = True
				m_vb6FormDefInstance = New frmShowForm()
				m_InitializingDefInstance = False
			End If
			DefInstance = m_vb6FormDefInstance
		End Get
		Set
			m_vb6FormDefInstance = Value
		End Set
	End Property
#End Region 
    Public CarHeight, CarWidth As Single
    Public Risult As Short
    Public grafics As Drawing.Graphics
    Public CurrentX As Single, CurrentY As Single
    Public myPen As Pen, myBrush As Brush, myFont As Font, myBrushW As Brush
    Public Sub Scrivi(ByRef t As String, Optional ByRef y As Single = -1, Optional ByRef x As Single = -1, Optional ByRef Mode As Integer = -1, Optional ByRef PunVir As Boolean = False)
        Static Dim sx, sY As Single
        Dim xx, yy, txtlength As Single
        Dim Cont As Boolean
        With pctForm
            txtlength = grafics.MeasureString(t, myFont).Width
            If Not PunVir Then
                If y > -1 Then
                    CurrentY = y * CarHeight
                    Cont = False
                Else
                    Cont = True
                End If
            End If
            If x > -1 And Not PunVir Then CurrentX = x * CarWidth
            If Cont And Not PunVir Then
                CurrentX = sx
                CurrentY = sY
            End If
            If Mode > -1 Then
                If PunVir Then
                    If Mode = 1 Then
                        xx = CurrentX
                        yy = CurrentY
                        grafics.FillRectangle(myBrush, xx, yy, txtlength * CarWidth, CarHeight)
                        grafics.DrawRectangle(myPen, xx, yy, txtlength * CarWidth, CarHeight)    'pctForm.Line (xx, yy) - ((xx + Len(t) * CarWidth), (yy + 1)), QBColor(12), BF
                        'CurrentX = xx
                        'CurrentY = yy
                    End If
                Else
                    If Mode = 1 Then
                        If Cont Then
                            xx = sx / CarWidth
                            yy = sY / CarHeight
                        Else
                            xx = x
                            yy = y
                        End If
                        grafics.FillRectangle(myBrush, xx * CarWidth, yy * CarHeight, txtlength * CarWidth, (yy + 1) * CarHeight)
                        'pctForm.Line (xx * CarWidth, yy * CarHeight) - ((xx + Len(t)) * CarWidth, (yy + 1) * CarHeight), QBColor(12), BF
                        grafics.DrawRectangle(myPen, xx * CarWidth, yy * CarHeight, txtlength * CarWidth, (yy + 1) * CarHeight)
                        CurrentX = xx * CarWidth
                        CurrentY = yy * CarHeight
                    End If
                End If
            End If
            If Not PunVir Then
                sx = CurrentX + txtlength
                sY = CurrentY
                grafics.DrawString(t, myFont, myBrushW, CurrentX, CurrentY)
                CurrentX = 0
                CurrentY = CurrentY + CarHeight
            Else
                grafics.DrawString(t, myFont, myBrushW, CurrentX, CurrentY)
                CurrentX = CurrentX + txtlength
            End If
        End With
    End Sub

    Private Sub cmdCambia_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCambia.Click
        Risult = -1
        Hide()
    End Sub
    Private Sub cmdHelp_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdHelp.Click
        Motore.RetrHelp(RadiceHelp, Me, "", "SpicShow.htm#SpicFon")
    End Sub
    Private Sub cmdOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOK.Click
        Risult = cmbScelta.SelectedIndex
        Hide()
    End Sub
    Private Sub frmShowForm_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Dim i As Short
        cmbScelta.Items.Clear()
        For i = 0 To 5
            cmbScelta.Items.Add(Str(i))
        Next
    End Sub

    Private Sub TabStrip1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabStrip1.Click
        pctForm.Visible = TabStrip1.SelectedIndex = 0
        pctShow.Visible = TabStrip1.SelectedIndex = 1

    End Sub
End Class