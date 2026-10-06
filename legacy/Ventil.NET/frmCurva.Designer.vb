<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmCurva
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
	Public CommonDialog1Open As System.Windows.Forms.OpenFileDialog
    Public WithEvents cmdDWG As System.Windows.Forms.Button
	Public WithEvents cmdSalva As System.Windows.Forms.Button
	Public WithEvents cmdWord As System.Windows.Forms.Button
	Public WithEvents Frame2 As System.Windows.Forms.GroupBox
	Public WithEvents _Option1_1 As System.Windows.Forms.RadioButton
	Public WithEvents _Option1_0 As System.Windows.Forms.RadioButton
	Public WithEvents Frame1 As System.Windows.Forms.GroupBox
	Public WithEvents Picture1 As System.Windows.Forms.PictureBox
    Public WithEvents _mnuFile_0 As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents _mnuFile_1 As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents _mnuFile_2 As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents _mnuFile_3 As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents _mnuFile_4 As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuFile0 As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents _mnuAzioni_0 As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents _mnuAzioni_1 As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents _mnuAzioni_2 As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents _mnuAzioni_3 As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents _mnuAzioni_4 As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents _mnuAzioni_5 As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuAzioni0 As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents _mnpref_0 As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents _mnpref_1 As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents _mnpref_2 As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuPref0 As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents _mnuHelp_0 As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuHelp0 As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents MainMenu1 As System.Windows.Forms.MenuStrip
	'NOTA: la routine seguente è richiesta dalla progettazione Windows Form.
	'Può essere modificata utilizzando la finestra di progettazione Windows Form.
	'Non modificarla mediante l'editor di codice.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCurva))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmdSalva = New System.Windows.Forms.Button
        Me.CommonDialog1Open = New System.Windows.Forms.OpenFileDialog
        Me.Frame2 = New System.Windows.Forms.GroupBox
        Me.cmdDWG = New System.Windows.Forms.Button
        Me.cmdWord = New System.Windows.Forms.Button
        Me.Frame1 = New System.Windows.Forms.GroupBox
        Me._Option1_1 = New System.Windows.Forms.RadioButton
        Me._Option1_0 = New System.Windows.Forms.RadioButton
        Me.Picture1 = New System.Windows.Forms.PictureBox
        Me._mnpref_0 = New System.Windows.Forms.ToolStripMenuItem
        Me._mnpref_1 = New System.Windows.Forms.ToolStripMenuItem
        Me._mnpref_2 = New System.Windows.Forms.ToolStripMenuItem
        Me._mnuAzioni_0 = New System.Windows.Forms.ToolStripMenuItem
        Me._mnuAzioni_1 = New System.Windows.Forms.ToolStripMenuItem
        Me._mnuAzioni_2 = New System.Windows.Forms.ToolStripMenuItem
        Me._mnuAzioni_3 = New System.Windows.Forms.ToolStripMenuItem
        Me._mnuAzioni_4 = New System.Windows.Forms.ToolStripMenuItem
        Me._mnuAzioni_5 = New System.Windows.Forms.ToolStripMenuItem
        Me._mnuFile_0 = New System.Windows.Forms.ToolStripMenuItem
        Me._mnuFile_1 = New System.Windows.Forms.ToolStripMenuItem
        Me._mnuFile_2 = New System.Windows.Forms.ToolStripMenuItem
        Me._mnuFile_3 = New System.Windows.Forms.ToolStripMenuItem
        Me._mnuFile_4 = New System.Windows.Forms.ToolStripMenuItem
        Me._mnuHelp_0 = New System.Windows.Forms.ToolStripMenuItem
        Me.MainMenu1 = New System.Windows.Forms.MenuStrip
        Me.mnuFile0 = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuAzioni0 = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuPref0 = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuHelp0 = New System.Windows.Forms.ToolStripMenuItem
        Me.CommonDialog1Save = New System.Windows.Forms.SaveFileDialog
        Me.Frame2.SuspendLayout()
        Me.Frame1.SuspendLayout()
        CType(Me.Picture1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MainMenu1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdSalva
        '
        Me.cmdSalva.BackColor = System.Drawing.SystemColors.Control
        Me.cmdSalva.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdSalva.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdSalva.Image = CType(resources.GetObject("cmdSalva.Image"), System.Drawing.Image)
        Me.cmdSalva.Location = New System.Drawing.Point(8, 15)
        Me.cmdSalva.Name = "cmdSalva"
        Me.cmdSalva.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdSalva.Size = New System.Drawing.Size(25, 25)
        Me.cmdSalva.TabIndex = 6
        Me.cmdSalva.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.cmdSalva, "Salva come immagine il grafico delle curve caratteristiche")
        Me.cmdSalva.UseVisualStyleBackColor = False
        '
        'Frame2
        '
        Me.Frame2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Frame2.BackColor = System.Drawing.SystemColors.Control
        Me.Frame2.Controls.Add(Me.cmdDWG)
        Me.Frame2.Controls.Add(Me.cmdSalva)
        Me.Frame2.Controls.Add(Me.cmdWord)
        Me.Frame2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame2.Location = New System.Drawing.Point(352, 296)
        Me.Frame2.Name = "Frame2"
        Me.Frame2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame2.Size = New System.Drawing.Size(118, 50)
        Me.Frame2.TabIndex = 4
        Me.Frame2.TabStop = False
        '
        'cmdDWG
        '
        Me.cmdDWG.BackColor = System.Drawing.SystemColors.Control
        Me.cmdDWG.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdDWG.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdDWG.Image = CType(resources.GetObject("cmdDWG.Image"), System.Drawing.Image)
        Me.cmdDWG.Location = New System.Drawing.Point(72, 15)
        Me.cmdDWG.Name = "cmdDWG"
        Me.cmdDWG.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdDWG.Size = New System.Drawing.Size(25, 25)
        Me.cmdDWG.TabIndex = 7
        Me.cmdDWG.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdDWG.UseVisualStyleBackColor = False
        '
        'cmdWord
        '
        Me.cmdWord.BackColor = System.Drawing.SystemColors.Control
        Me.cmdWord.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdWord.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdWord.Image = CType(resources.GetObject("cmdWord.Image"), System.Drawing.Image)
        Me.cmdWord.Location = New System.Drawing.Point(40, 15)
        Me.cmdWord.Name = "cmdWord"
        Me.cmdWord.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdWord.Size = New System.Drawing.Size(25, 25)
        Me.cmdWord.TabIndex = 5
        Me.cmdWord.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdWord.UseVisualStyleBackColor = False
        '
        'Frame1
        '
        Me.Frame1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Frame1.BackColor = System.Drawing.SystemColors.Control
        Me.Frame1.Controls.Add(Me._Option1_1)
        Me.Frame1.Controls.Add(Me._Option1_0)
        Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame1.Location = New System.Drawing.Point(16, 296)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame1.Size = New System.Drawing.Size(121, 57)
        Me.Frame1.TabIndex = 1
        Me.Frame1.TabStop = False
        Me.Frame1.Text = "Tipo di Grafico"
        '
        '_Option1_1
        '
        Me._Option1_1.BackColor = System.Drawing.SystemColors.Control
        Me._Option1_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option1_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Option1_1.Location = New System.Drawing.Point(8, 32)
        Me._Option1_1.Name = "_Option1_1"
        Me._Option1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option1_1.Size = New System.Drawing.Size(105, 17)
        Me._Option1_1.TabIndex = 3
        Me._Option1_1.TabStop = True
        Me._Option1_1.Text = "Pressione totale"
        Me._Option1_1.UseVisualStyleBackColor = False
        '
        '_Option1_0
        '
        Me._Option1_0.BackColor = System.Drawing.SystemColors.Control
        Me._Option1_0.Checked = True
        Me._Option1_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option1_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Option1_0.Location = New System.Drawing.Point(8, 16)
        Me._Option1_0.Name = "_Option1_0"
        Me._Option1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option1_0.Size = New System.Drawing.Size(105, 17)
        Me._Option1_0.TabIndex = 2
        Me._Option1_0.TabStop = True
        Me._Option1_0.Text = "Pressione statica"
        Me._Option1_0.UseVisualStyleBackColor = False
        '
        'Picture1
        '
        Me.Picture1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Picture1.BackColor = System.Drawing.SystemColors.Window
        Me.Picture1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Picture1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Picture1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Picture1.Location = New System.Drawing.Point(16, 32)
        Me.Picture1.Name = "Picture1"
        Me.Picture1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Picture1.Size = New System.Drawing.Size(457, 257)
        Me.Picture1.TabIndex = 0
        Me.Picture1.TabStop = False
        '
        '_mnpref_0
        '
        Me._mnpref_0.Name = "_mnpref_0"
        Me._mnpref_0.Size = New System.Drawing.Size(206, 22)
        Me._mnpref_0.Text = "Correlazioni nuove"
        '
        '_mnpref_1
        '
        Me._mnpref_1.Name = "_mnpref_1"
        Me._mnpref_1.Size = New System.Drawing.Size(206, 22)
        Me._mnpref_1.Text = "Correzione rumore..."
        '
        '_mnpref_2
        '
        Me._mnpref_2.Name = "_mnpref_2"
        Me._mnpref_2.Size = New System.Drawing.Size(206, 22)
        Me._mnpref_2.Text = "Correzione rendimento..."
        '
        '_mnuAzioni_0
        '
        Me._mnuAzioni_0.Name = "_mnuAzioni_0"
        Me._mnuAzioni_0.Size = New System.Drawing.Size(199, 22)
        Me._mnuAzioni_0.Text = "Dati"
        '
        '_mnuAzioni_1
        '
        Me._mnuAzioni_1.Name = "_mnuAzioni_1"
        Me._mnuAzioni_1.Size = New System.Drawing.Size(199, 22)
        Me._mnuAzioni_1.Text = "Selezione ventilatore"
        '
        '_mnuAzioni_2
        '
        Me._mnuAzioni_2.Name = "_mnuAzioni_2"
        Me._mnuAzioni_2.Size = New System.Drawing.Size(199, 22)
        Me._mnuAzioni_2.Text = "Curve di funzionamento"
        '
        '_mnuAzioni_3
        '
        Me._mnuAzioni_3.Name = "_mnuAzioni_3"
        Me._mnuAzioni_3.Size = New System.Drawing.Size(199, 22)
        Me._mnuAzioni_3.Text = "Calcolo teorico"
        '
        '_mnuAzioni_4
        '
        Me._mnuAzioni_4.Name = "_mnuAzioni_4"
        Me._mnuAzioni_4.Size = New System.Drawing.Size(199, 22)
        Me._mnuAzioni_4.Text = "Grafici"
        '
        '_mnuAzioni_5
        '
        Me._mnuAzioni_5.Name = "_mnuAzioni_5"
        Me._mnuAzioni_5.Size = New System.Drawing.Size(199, 22)
        Me._mnuAzioni_5.Text = "Aggiungi a DB"
        '
        '_mnuFile_0
        '
        Me._mnuFile_0.Name = "_mnuFile_0"
        Me._mnuFile_0.Size = New System.Drawing.Size(151, 22)
        Me._mnuFile_0.Text = "Nuovo"
        '
        '_mnuFile_1
        '
        Me._mnuFile_1.Name = "_mnuFile_1"
        Me._mnuFile_1.Size = New System.Drawing.Size(151, 22)
        Me._mnuFile_1.Text = "Apri"
        '
        '_mnuFile_2
        '
        Me._mnuFile_2.Name = "_mnuFile_2"
        Me._mnuFile_2.Size = New System.Drawing.Size(151, 22)
        Me._mnuFile_2.Text = "Salva"
        '
        '_mnuFile_3
        '
        Me._mnuFile_3.Name = "_mnuFile_3"
        Me._mnuFile_3.Size = New System.Drawing.Size(151, 22)
        Me._mnuFile_3.Text = "Salva come..."
        '
        '_mnuFile_4
        '
        Me._mnuFile_4.Name = "_mnuFile_4"
        Me._mnuFile_4.Size = New System.Drawing.Size(151, 22)
        Me._mnuFile_4.Text = "Esci"
        '
        '_mnuHelp_0
        '
        Me._mnuHelp_0.Name = "_mnuHelp_0"
        Me._mnuHelp_0.Size = New System.Drawing.Size(152, 22)
        Me._mnuHelp_0.Text = "Guida di Ventil"
        '
        'MainMenu1
        '
        Me.MainMenu1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuFile0, Me.mnuAzioni0, Me.mnuPref0, Me.mnuHelp0})
        Me.MainMenu1.Location = New System.Drawing.Point(0, 0)
        Me.MainMenu1.Name = "MainMenu1"
        Me.MainMenu1.Size = New System.Drawing.Size(494, 24)
        Me.MainMenu1.TabIndex = 5
        '
        'mnuFile0
        '
        Me.mnuFile0.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._mnuFile_0, Me._mnuFile_1, Me._mnuFile_2, Me._mnuFile_3, Me._mnuFile_4})
        Me.mnuFile0.Name = "mnuFile0"
        Me.mnuFile0.Size = New System.Drawing.Size(35, 20)
        Me.mnuFile0.Text = "File"
        '
        'mnuAzioni0
        '
        Me.mnuAzioni0.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._mnuAzioni_0, Me._mnuAzioni_1, Me._mnuAzioni_2, Me._mnuAzioni_3, Me._mnuAzioni_4, Me._mnuAzioni_5})
        Me.mnuAzioni0.Name = "mnuAzioni0"
        Me.mnuAzioni0.Size = New System.Drawing.Size(47, 20)
        Me.mnuAzioni0.Text = "Azioni"
        '
        'mnuPref0
        '
        Me.mnuPref0.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._mnpref_0, Me._mnpref_1, Me._mnpref_2})
        Me.mnuPref0.Name = "mnuPref0"
        Me.mnuPref0.Size = New System.Drawing.Size(72, 20)
        Me.mnuPref0.Text = "Preferenze"
        '
        'mnuHelp0
        '
        Me.mnuHelp0.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._mnuHelp_0})
        Me.mnuHelp0.Name = "mnuHelp0"
        Me.mnuHelp0.Size = New System.Drawing.Size(24, 20)
        Me.mnuHelp0.Text = "?"
        '
        'frmCurva
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(494, 364)
        Me.Controls.Add(Me.Frame2)
        Me.Controls.Add(Me.Frame1)
        Me.Controls.Add(Me.Picture1)
        Me.Controls.Add(Me.MainMenu1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.HelpButton = True
        Me.Location = New System.Drawing.Point(10, 48)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCurva"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "Generazione curve di funzionamento ventilatori"
        Me.Frame2.ResumeLayout(False)
        Me.Frame1.ResumeLayout(False)
        CType(Me.Picture1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MainMenu1.ResumeLayout(False)
        Me.MainMenu1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CommonDialog1Save As System.Windows.Forms.SaveFileDialog
#End Region 
End Class