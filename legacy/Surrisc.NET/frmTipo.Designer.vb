<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmTipo
#Region "Codice generato da Progettazione Windows Form "
	<System.Diagnostics.DebuggerNonUserCode()> Public Sub New()
		MyBase.New()
        'Chiamata richiesta dalla progettazione Windows Form.
        Inizializzando = True
        InitializeComponent()
        Inizializzando = False
	End Sub
	'Il form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
	<System.Diagnostics.DebuggerNonUserCode()> Protected Overloads Overrides Sub Dispose(ByVal Disposing As Boolean)
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
    Public WithEvents Command1 As System.Windows.Forms.Button
    Public WithEvents _Label2_1 As System.Windows.Forms.Label
	Public WithEvents _Label1_1 As System.Windows.Forms.Label
	Public WithEvents _Label2_0 As System.Windows.Forms.Label
	Public WithEvents _Label1_0 As System.Windows.Forms.Label
	Public WithEvents Label1 As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	Public WithEvents Label2 As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	Public WithEvents Text1 As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
    'NOTA: la routine seguente è richiesta dalla progettazione Windows Form.
    'Può essere modificata utilizzando la finestra di progettazione Windows Form.
    'Non modificarla mediante l'editor di codice.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Command1 = New System.Windows.Forms.Button
        Me._Label2_1 = New System.Windows.Forms.Label
        Me._Label1_1 = New System.Windows.Forms.Label
        Me._Label2_0 = New System.Windows.Forms.Label
        Me._Label1_0 = New System.Windows.Forms.Label
        Me.Label1 = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        Me.Label2 = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        Me.Text1 = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(Me.components)
        Me._UpDown1_0 = New System.Windows.Forms.NumericUpDown
        Me._UpDown1_1 = New System.Windows.Forms.NumericUpDown
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.TabPage3 = New System.Windows.Forms.TabPage
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Text1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._UpDown1_0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._UpDown1_1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Command1
        '
        Me.Command1.BackColor = System.Drawing.SystemColors.Control
        Me.Command1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command1.Location = New System.Drawing.Point(384, 400)
        Me.Command1.Name = "Command1"
        Me.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command1.Size = New System.Drawing.Size(57, 25)
        Me.Command1.TabIndex = 2
        Me.Command1.Text = "OK"
        Me.Command1.UseVisualStyleBackColor = False
        '
        '_Label2_1
        '
        Me._Label2_1.BackColor = System.Drawing.SystemColors.Control
        Me._Label2_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.SetIndex(Me._Label2_1, CType(1, Short))
        Me._Label2_1.Location = New System.Drawing.Point(208, 392)
        Me._Label2_1.Name = "_Label2_1"
        Me._Label2_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_1.Size = New System.Drawing.Size(137, 25)
        Me._Label2_1.TabIndex = 8
        Me._Label2_1.Text = "Label2"
        '
        '_Label1_1
        '
        Me._Label1_1.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.SetIndex(Me._Label1_1, CType(1, Short))
        Me._Label1_1.Location = New System.Drawing.Point(8, 392)
        Me._Label1_1.Name = "_Label1_1"
        Me._Label1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_1.Size = New System.Drawing.Size(113, 33)
        Me._Label1_1.TabIndex = 6
        Me._Label1_1.Text = "N° di cross nella zona acciecata all'interno"
        '
        '_Label2_0
        '
        Me._Label2_0.BackColor = System.Drawing.SystemColors.Control
        Me._Label2_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.SetIndex(Me._Label2_0, CType(0, Short))
        Me._Label2_0.Location = New System.Drawing.Point(208, 368)
        Me._Label2_0.Name = "_Label2_0"
        Me._Label2_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_0.Size = New System.Drawing.Size(137, 25)
        Me._Label2_0.TabIndex = 5
        Me._Label2_0.Text = "Label2"
        '
        '_Label1_0
        '
        Me._Label1_0.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.SetIndex(Me._Label1_0, CType(0, Short))
        Me._Label1_0.Location = New System.Drawing.Point(8, 368)
        Me._Label1_0.Name = "_Label1_0"
        Me._Label1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_0.Size = New System.Drawing.Size(113, 17)
        Me._Label1_0.TabIndex = 3
        Me._Label1_0.Text = "N° di cross del gas"
        '
        'Text1
        '
        '
        '_UpDown1_0
        '
        Me._UpDown1_0.Location = New System.Drawing.Point(136, 368)
        Me._UpDown1_0.Name = "_UpDown1_0"
        Me._UpDown1_0.Size = New System.Drawing.Size(40, 20)
        Me._UpDown1_0.TabIndex = 11
        Me._UpDown1_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        '_UpDown1_1
        '
        Me._UpDown1_1.Location = New System.Drawing.Point(136, 400)
        Me._UpDown1_1.Name = "_UpDown1_1"
        Me._UpDown1_1.Size = New System.Drawing.Size(40, 20)
        Me._UpDown1_1.TabIndex = 12
        Me._UpDown1_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(456, 360)
        Me.TabControl1.TabIndex = 13
        '
        'TabPage1
        '
        Me.TabPage1.BackgroundImage = Global.Surrisc.My.Resources.Resources.A8
        Me.TabPage1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(448, 334)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "1 passo"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.BackgroundImage = Global.Surrisc.My.Resources.Resources.B6
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(448, 334)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "1 passo con cieco"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'TabPage3
        '
        Me.TabPage3.BackgroundImage = Global.Surrisc.My.Resources.Resources.C8
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(448, 334)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "2 passi"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'frmTipo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(457, 434)
        Me.ControlBox = False
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me._UpDown1_1)
        Me.Controls.Add(Me._UpDown1_0)
        Me.Controls.Add(Me.Command1)
        Me.Controls.Add(Me._Label2_1)
        Me.Controls.Add(Me._Label1_1)
        Me.Controls.Add(Me._Label2_0)
        Me.Controls.Add(Me._Label1_0)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Location = New System.Drawing.Point(4, 24)
        Me.Name = "frmTipo"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "Configurazione"
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Text1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._UpDown1_0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._UpDown1_1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents _UpDown1_0 As System.Windows.Forms.NumericUpDown
    Friend WithEvents _UpDown1_1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
#End Region 
End Class