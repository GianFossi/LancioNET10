Option Strict On
Option Explicit On
Friend Class Apert
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
    Public WithEvents cmdClrarR As System.Windows.Forms.Button
    Public WithEvents _Frames_2 As System.Windows.Forms.GroupBox
	Public WithEvents cmdEscludi As System.Windows.Forms.Button
    Public WithEvents cmdCalc As System.Windows.Forms.Button
	Public WithEvents cmdDati As System.Windows.Forms.Button
	Public WithEvents _Frames_1 As System.Windows.Forms.GroupBox
	Public WithEvents Timer1 As System.Windows.Forms.Timer
	Public WithEvents Text1 As System.Windows.Forms.TextBox
	Public WithEvents Check1 As System.Windows.Forms.CheckBox
	Public WithEvents cmdVisTutto As System.Windows.Forms.Button
	Public WithEvents cmdClear As System.Windows.Forms.Button
	Public WithEvents cmdVisual As System.Windows.Forms.Button
    Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents _Frames_0 As System.Windows.Forms.GroupBox
    Public WithEvents mnuApri As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuSalva As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuChiudi As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuEsci As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuFile As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuTuttiDati As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuDatiGen As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuGeomTutti As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuGeomUno As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuAmmTutti As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuAmmUno As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuCarTutti As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuCarUno As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuDati As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuCalcTutti As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuCalcUno As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuCalcoli As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuLibr As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuStLibr As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuOpzioni As System.Windows.Forms.ToolStripMenuItem
	Public MainMenu1 As System.Windows.Forms.MenuStrip
	'NOTA: la routine seguente è richiesta dalla progettazione Windows Form.
	'Può essere modificata utilizzando la finestra di progettazione Windows Form.
	'Non modificarla mediante l'editor di codice.
    Friend WithEvents lstRapp As System.Windows.Forms.ListView
    Friend WithEvents lstRes As System.Windows.Forms.ListView
    Friend WithEvents lstNoz As System.Windows.Forms.ListView
    Friend WithEvents StatusBar1 As System.Windows.Forms.StatusStrip
    Friend WithEvents StatusBarPanel1 As Global.LancioMigration.LegacyStatusLabel
    Friend WithEvents StatusBarPanel2 As Global.LancioMigration.LegacyStatusLabel
    Friend WithEvents StatusBarPanel3 As Global.LancioMigration.LegacyStatusLabel
    Friend WithEvents mnuSaveAs As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents MenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuItem3 As System.Windows.Forms.ToolStripMenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Apert))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me._Frames_2 = New System.Windows.Forms.GroupBox
        Me.lstRes = New System.Windows.Forms.ListView
        Me.ColumnHeader4 = New System.Windows.Forms.ColumnHeader
        Me.cmdClrarR = New System.Windows.Forms.Button
        Me._Frames_1 = New System.Windows.Forms.GroupBox
        Me.lstNoz = New System.Windows.Forms.ListView
        Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader2 = New System.Windows.Forms.ColumnHeader
        Me.cmdEscludi = New System.Windows.Forms.Button
        Me.cmdCalc = New System.Windows.Forms.Button
        Me.cmdDati = New System.Windows.Forms.Button
        Me._Frames_0 = New System.Windows.Forms.GroupBox
        Me.lstRapp = New System.Windows.Forms.ListView
        Me.ColumnHeader3 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader5 = New System.Windows.Forms.ColumnHeader
        Me.Text1 = New System.Windows.Forms.TextBox
        Me.Check1 = New System.Windows.Forms.CheckBox
        Me.cmdVisTutto = New System.Windows.Forms.Button
        Me.cmdClear = New System.Windows.Forms.Button
        Me.cmdVisual = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.MainMenu1 = New System.Windows.Forms.MenuStrip
        Me.mnuFile = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuApri = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuSalva = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuSaveAs = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuChiudi = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuEsci = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuDati = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuTuttiDati = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuDatiGen = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuGeomTutti = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuGeomUno = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuAmmTutti = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuAmmUno = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuCarTutti = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuCarUno = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuCalcoli = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuCalcTutti = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuCalcUno = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuOpzioni = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuLibr = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuStLibr = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuItem2 = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuItem3 = New System.Windows.Forms.ToolStripMenuItem
        Me.StatusBar1 = New System.Windows.Forms.StatusStrip
        Me.StatusBarPanel1 = New Global.LancioMigration.LegacyStatusLabel
        Me.StatusBarPanel2 = New Global.LancioMigration.LegacyStatusLabel
        Me.StatusBarPanel3 = New Global.LancioMigration.LegacyStatusLabel
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me._Frames_2.SuspendLayout()
        Me._Frames_1.SuspendLayout()
        Me._Frames_0.SuspendLayout()
        Me.SuspendLayout()
        '
        '_Frames_2
        '
        Me._Frames_2.BackColor = System.Drawing.SystemColors.Control
        Me._Frames_2.Controls.Add(Me.lstRes)
        Me._Frames_2.Controls.Add(Me.cmdClrarR)
        Me._Frames_2.ForeColor = System.Drawing.Color.Yellow
        Me._Frames_2.Location = New System.Drawing.Point(198, 256)
        Me._Frames_2.Name = "_Frames_2"
        Me._Frames_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Frames_2.Size = New System.Drawing.Size(482, 320)
        Me._Frames_2.TabIndex = 10
        Me._Frames_2.TabStop = False
        Me._Frames_2.Text = "Risultati del calcolo"
        Me._Frames_2.Visible = False
        '
        'lstRes
        '
        Me.lstRes.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader4})
        Me.lstRes.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lstRes.Location = New System.Drawing.Point(8, 48)
        Me.lstRes.MultiSelect = False
        Me.lstRes.Name = "lstRes"
        Me.lstRes.Size = New System.Drawing.Size(464, 264)
        Me.lstRes.TabIndex = 12
        Me.lstRes.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Width = 456
        '
        'cmdClrarR
        '
        Me.cmdClrarR.BackColor = System.Drawing.SystemColors.Control
        Me.cmdClrarR.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdClrarR.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdClrarR.Location = New System.Drawing.Point(8, 16)
        Me.cmdClrarR.Name = "cmdClrarR"
        Me.cmdClrarR.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdClrarR.Size = New System.Drawing.Size(57, 25)
        Me.cmdClrarR.TabIndex = 11
        Me.cmdClrarR.Text = "Clear"
        '
        '_Frames_1
        '
        Me._Frames_1.BackColor = System.Drawing.SystemColors.Control
        Me._Frames_1.Controls.Add(Me.lstNoz)
        Me._Frames_1.Controls.Add(Me.cmdEscludi)
        Me._Frames_1.Controls.Add(Me.cmdCalc)
        Me._Frames_1.Controls.Add(Me.cmdDati)
        Me._Frames_1.ForeColor = System.Drawing.Color.Yellow
        Me._Frames_1.Location = New System.Drawing.Point(0, 0)
        Me._Frames_1.Name = "_Frames_1"
        Me._Frames_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Frames_1.Size = New System.Drawing.Size(201, 576)
        Me._Frames_1.TabIndex = 5
        Me._Frames_1.TabStop = False
        Me._Frames_1.Text = "Lista aperture"
        Me._Frames_1.Visible = False
        '
        'lstNoz
        '
        Me.lstNoz.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.lstNoz.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lstNoz.Location = New System.Drawing.Point(8, 48)
        Me.lstNoz.MultiSelect = False
        Me.lstNoz.Name = "lstNoz"
        Me.lstNoz.Size = New System.Drawing.Size(184, 520)
        Me.lstNoz.TabIndex = 10
        Me.lstNoz.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Width = 90
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Width = 90
        '
        'cmdEscludi
        '
        Me.cmdEscludi.BackColor = System.Drawing.SystemColors.Control
        Me.cmdEscludi.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdEscludi.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdEscludi.Location = New System.Drawing.Point(9, 16)
        Me.cmdEscludi.Name = "cmdEscludi"
        Me.cmdEscludi.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdEscludi.Size = New System.Drawing.Size(73, 25)
        Me.cmdEscludi.TabIndex = 9
        Me.cmdEscludi.Text = "Inclusioni"
        '
        'cmdCalc
        '
        Me.cmdCalc.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCalc.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCalc.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCalc.Location = New System.Drawing.Point(136, 16)
        Me.cmdCalc.Name = "cmdCalc"
        Me.cmdCalc.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCalc.Size = New System.Drawing.Size(57, 25)
        Me.cmdCalc.TabIndex = 7
        Me.cmdCalc.Text = "Calcola"
        '
        'cmdDati
        '
        Me.cmdDati.BackColor = System.Drawing.SystemColors.Control
        Me.cmdDati.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdDati.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdDati.Location = New System.Drawing.Point(80, 16)
        Me.cmdDati.Name = "cmdDati"
        Me.cmdDati.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdDati.Size = New System.Drawing.Size(57, 25)
        Me.cmdDati.TabIndex = 6
        Me.cmdDati.Text = "Dati"
        '
        '_Frames_0
        '
        Me._Frames_0.BackColor = System.Drawing.SystemColors.Control
        Me._Frames_0.Controls.Add(Me.lstRapp)
        Me._Frames_0.Controls.Add(Me.Text1)
        Me._Frames_0.Controls.Add(Me.Check1)
        Me._Frames_0.Controls.Add(Me.cmdVisTutto)
        Me._Frames_0.Controls.Add(Me.cmdClear)
        Me._Frames_0.Controls.Add(Me.cmdVisual)
        Me._Frames_0.Controls.Add(Me.Label1)
        Me._Frames_0.ForeColor = System.Drawing.Color.Yellow
        Me._Frames_0.Location = New System.Drawing.Point(198, 0)
        Me._Frames_0.Name = "_Frames_0"
        Me._Frames_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Frames_0.Size = New System.Drawing.Size(482, 256)
        Me._Frames_0.TabIndex = 0
        Me._Frames_0.TabStop = False
        Me._Frames_0.Text = "Composizione rapporto"
        Me._Frames_0.Visible = False
        '
        'lstRapp
        '
        Me.lstRapp.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader3, Me.ColumnHeader5})
        Me.lstRapp.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lstRapp.Location = New System.Drawing.Point(8, 88)
        Me.lstRapp.MultiSelect = False
        Me.lstRapp.Name = "lstRapp"
        Me.lstRapp.Size = New System.Drawing.Size(464, 160)
        Me.lstRapp.TabIndex = 17
        Me.lstRapp.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Width = 220
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Width = 236
        '
        'Text1
        '
        Me.Text1.AcceptsReturn = True
        Me.Text1.AutoSize = False
        Me.Text1.BackColor = System.Drawing.SystemColors.Window
        Me.Text1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Text1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text1.Location = New System.Drawing.Point(40, 64)
        Me.Text1.MaxLength = 0
        Me.Text1.Name = "Text1"
        Me.Text1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text1.Size = New System.Drawing.Size(297, 19)
        Me.Text1.TabIndex = 15
        Me.Text1.Text = "Text1"
        '
        'Check1
        '
        Me.Check1.BackColor = System.Drawing.SystemColors.Control
        Me.Check1.Checked = True
        Me.Check1.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me.Check1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Check1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Check1.Location = New System.Drawing.Point(8, 42)
        Me.Check1.Name = "Check1"
        Me.Check1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Check1.Size = New System.Drawing.Size(217, 25)
        Me.Check1.TabIndex = 14
        Me.Check1.Text = "Con indice e intestazioni"
        '
        'cmdVisTutto
        '
        Me.cmdVisTutto.BackColor = System.Drawing.SystemColors.Control
        Me.cmdVisTutto.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdVisTutto.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdVisTutto.Location = New System.Drawing.Point(152, 16)
        Me.cmdVisTutto.Name = "cmdVisTutto"
        Me.cmdVisTutto.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdVisTutto.Size = New System.Drawing.Size(89, 25)
        Me.cmdVisTutto.TabIndex = 13
        Me.cmdVisTutto.Text = "Vis. tutto"
        '
        'cmdClear
        '
        Me.cmdClear.BackColor = System.Drawing.SystemColors.Control
        Me.cmdClear.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdClear.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdClear.Location = New System.Drawing.Point(8, 16)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdClear.Size = New System.Drawing.Size(57, 25)
        Me.cmdClear.TabIndex = 2
        Me.cmdClear.Text = "Clear"
        '
        'cmdVisual
        '
        Me.cmdVisual.BackColor = System.Drawing.SystemColors.Control
        Me.cmdVisual.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdVisual.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdVisual.Location = New System.Drawing.Point(64, 16)
        Me.cmdVisual.Name = "cmdVisual"
        Me.cmdVisual.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdVisual.Size = New System.Drawing.Size(89, 25)
        Me.cmdVisual.TabIndex = 1
        Me.cmdVisual.Text = "Visualizza"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(8, 66)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(33, 17)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "File: "
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 2000
        '
        'MainMenu1
        '
        Me.MainMenu1.Items.AddRange(New System.Windows.Forms.ToolStripMenuItem() {Me.mnuFile, Me.mnuDati, Me.mnuCalcoli, Me.mnuOpzioni, Me.MenuItem1})
        '
        'mnuFile
        '

        Me.mnuFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripMenuItem() {Me.mnuApri, Me.mnuSalva, Me.mnuSaveAs, Me.mnuChiudi, Me.mnuEsci})
        Me.mnuFile.Text = "File"
        '
        'mnuApri
        '

        Me.mnuApri.Text = "Apri"
        '
        'mnuSalva
        '

        Me.mnuSalva.Text = "Salva"
        '
        'mnuSaveAs
        '

        Me.mnuSaveAs.Text = "Salva come..."
        '
        'mnuChiudi
        '

        Me.mnuChiudi.Text = "Chiudi"
        '
        'mnuEsci
        '

        Me.mnuEsci.Text = "Esci"
        '
        'mnuDati
        '

        Me.mnuDati.DropDownItems.AddRange(New System.Windows.Forms.ToolStripMenuItem() {Me.mnuTuttiDati, Me.mnuDatiGen, Me.mnuGeomTutti, Me.mnuGeomUno, Me.mnuAmmTutti, Me.mnuAmmUno, Me.mnuCarTutti, Me.mnuCarUno})
        Me.mnuDati.Text = "Dati"
        '
        'mnuTuttiDati
        '

        Me.mnuTuttiDati.Text = "Tutti i dati"
        '
        'mnuDatiGen
        '

        Me.mnuDatiGen.Text = "Dati generali"
        '
        'mnuGeomTutti
        '

        Me.mnuGeomTutti.Text = "Geometria tutti"
        '
        'mnuGeomUno
        '

        Me.mnuGeomUno.Text = "Geometria uno"
        '
        'mnuAmmTutti
        '

        Me.mnuAmmTutti.Text = "Ammissibili tutti"
        '
        'mnuAmmUno
        '

        Me.mnuAmmUno.Text = "Ammissibili uno"
        '
        'mnuCarTutti
        '

        Me.mnuCarTutti.Text = "Carichi tutti"
        '
        'mnuCarUno
        '

        Me.mnuCarUno.Text = "Carichi uno"
        '
        'mnuCalcoli
        '

        Me.mnuCalcoli.DropDownItems.AddRange(New System.Windows.Forms.ToolStripMenuItem() {Me.mnuCalcTutti, Me.mnuCalcUno})
        Me.mnuCalcoli.Text = "Calcoli"
        '
        'mnuCalcTutti
        '

        Me.mnuCalcTutti.Text = "Calcola tutti"
        '
        'mnuCalcUno
        '

        Me.mnuCalcUno.Text = "Calcola uno"
        '
        'mnuOpzioni
        '

        Me.mnuOpzioni.DropDownItems.AddRange(New System.Windows.Forms.ToolStripMenuItem() {Me.mnuLibr, Me.mnuStLibr})
        Me.mnuOpzioni.Text = "Opzioni"
        '
        'mnuLibr
        '

        Me.mnuLibr.Text = "Librerie carichi standard"
        '
        'mnuStLibr
        '

        Me.mnuStLibr.Text = "Stampa delle librerie"
        '
        'MenuItem1
        '

        Me.MenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripMenuItem() {Me.MenuItem2, Me.MenuItem3})
        Me.MenuItem1.Text = "?"
        '
        'MenuItem2
        '

        Me.MenuItem2.Text = "Guida"
        '
        'MenuItem3
        '

        Me.MenuItem3.Text = "Informazioni"
        '
        'StatusBar1
        '
        Me.StatusBar1.Location = New System.Drawing.Point(0, 573)
        Me.StatusBar1.Name = "StatusBar1"
        Me.StatusBar1.Items.AddRange(New Global.LancioMigration.LegacyStatusLabel() {Me.StatusBarPanel1, Me.StatusBarPanel2, Me.StatusBarPanel3})
        Me.StatusBar1.Size = New System.Drawing.Size(678, 16)
        Me.StatusBar1.TabIndex = 11
        '
        'StatusBarPanel1
        '
        Me.StatusBarPanel1.Spring = True
        Me.StatusBarPanel1.Text = "Area di lavoro:"
        Me.StatusBarPanel1.Width = 579
        '
        'StatusBarPanel2
        '
        Me.StatusBarPanel2.AutoSize = True
        Me.StatusBarPanel2.Text = "Prev.:"
        Me.StatusBarPanel2.Width = 44
        '
        'StatusBarPanel3
        '
        Me.StatusBarPanel3.AutoSize = True
        Me.StatusBarPanel3.Text = "Item:"
        Me.StatusBarPanel3.Width = 39
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(0, 8)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(672, 560)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 18
        Me.PictureBox1.TabStop = False
        '
        'Apert
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.ClientSize = New System.Drawing.Size(678, 589)
        Me.Controls.Add(Me.StatusBar1)
        Me.Controls.Add(Me._Frames_2)
        Me.Controls.Add(Me._Frames_1)
        Me.Controls.Add(Me._Frames_0)
        Me.Controls.Add(Me.PictureBox1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Location = New System.Drawing.Point(11, 49)
        Me.MainMenuStrip = Me.MainMenu1
        Me.Controls.Add(Me.MainMenu1)
        Me.Name = "Apert"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "WRCB - Carichi locali su aperture"
        Me._Frames_2.ResumeLayout(False)
        Me._Frames_1.ResumeLayout(False)
        Me._Frames_0.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
#End Region 
#Region "Supporto aggiornamento "
	Private Shared m_vb6FormDefInstance As Apert
	Private Shared m_InitializingDefInstance As Boolean
	Public Shared Property DefInstance() As Apert
		Get
			If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
				m_InitializingDefInstance = True
				m_vb6FormDefInstance = New Apert()
				m_InitializingDefInstance = False
			End If
			DefInstance = m_vb6FormDefInstance
		End Get
		Set
			m_vb6FormDefInstance = Value
		End Set
	End Property
#End Region
    Private Inizializzando As Boolean
    Private GeomUno As String
    Private AmmUno As String
    Private CarUno As String
    Private CalcUno As String
    Private Res As Boolean
    Private oldSize As Size
    Private Const msgText As String = "Prego selezionare un bocchello dalla lista delle aperture"
    Private Sub Check1_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Check1.CheckStateChanged
        If Inizializzando Then Exit Sub
        If Check1.CheckState = CheckState.Checked Then
            Template = "HeadNotNoz"
            cmdVisual.Enabled = True
        Else
            Template = "HEADER"
            cmdVisual.Enabled = False
        End If
    End Sub

    Private Sub cmdCalc_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCalc.Click
        Dim Res As Boolean
        If iB = 0 Then
            cmdCalc.Enabled = False
        Else
            Res = Esegui(iB)
        End If
    End Sub

    Private Sub cmdClear_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClear.Click
        Dim Testo As String
        Static Gia As Boolean
        If Config.Verbose > 0 And Not objWRCB.Sciolto And Not Gia Then
            Testo = "Procedendo, si annulleranno anche|"
            Testo = Testo & "gli eventuali risultati ottenuti|"
            Testo = Testo & "da AsmeVip.| Si vuole procedere comunque?"
            Gia = True
            If MsgBox(Monitor.Motore.Inizio.ConvertiCr(Testo), MsgBoxStyle.Question Or MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        End If
        CloseioutS(lstRapp)
    End Sub
    Private Sub cmdClrarR_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClrarR.Click
        lstRes.Items.Clear()
    End Sub

    Private Sub cmdDati_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdDati.Click
        Dim Res As Boolean
        If iB = 0 Then
            cmdDati.Enabled = False
        Else
            Res = SubGeom()
            If Res Then Res = AggiornaAllow()
            If Res Then Res = SubCarichi()
        End If
    End Sub

    Private Sub cmdEscludi_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdEscludi.Click
        Escludi()
    End Sub

    Private Sub cmdVisTutto_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdVisTutto.Click
        Visualizza()
    End Sub

    Private Sub cmdVisual_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdVisual.Click
        '   Dim Ext As String
        'icome = Trim(icome)
        'If Len(icome) > 0 Then
        '   Ext = Left(icome, Len(icome) - 4) + ".WRS"
        'Else
        '   Ext = Trim(Monitor.clsInizio.Datidir) + "\WRCBST.WRS"
        'End If
        If Stub Is Nothing Then If Not Visualizza() Then Exit Sub
        VisualCap()
    End Sub

    Private Sub Apert_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Dim Testo As String
        Text1.Text = ""
        GeomUno = mnuGeomUno.Text
        AmmUno = mnuAmmUno.Text
        CarUno = mnuCarUno.Text
        CalcUno = mnuCalcUno.Text
        If objWRCB.Sciolto Then
            'Top = 0
            'Left = 0
            'Height = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height
            'Width = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width
        Else
            Top = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height - Height
            Left = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width - Width
        End If
        '   Call Prelimin
        '    Libreria
        AggiornaApert()
        '    Ridimensiona MaxNozAct
        If Not objWRCB.Sciolto Then
            mnuApri.Enabled = False
            mnuSalva.Enabled = True
            mnuChiudi.Enabled = False
            mnuEsci.Text = "Chiudi e torna ad AsmeVip"
            _Frames_1.Visible = True
            _Frames_0.Visible = True
            _Frames_2.Visible = True
            PictureBox1.Visible = False
            TitoloDoc()
            If IO.File.Exists(objWRCB.commessa) Then
                Testo = "Esiste la registrazione di un precedente|"
                Testo = Testo & "salvataggio dati WRCB per questa commessa.|"
                Testo = Testo & "Vuoi caricare i dati salvati?"
                If MsgBox(Monitor.Motore.Inizio.ConvertiCr(Testo), MsgBoxStyle.Question Or MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    LeggiW(False)
                End If
            End If
            AggAlbero()
        End If
        Check1.CheckState = System.Windows.Forms.CheckState.Unchecked
        Text = Text & " (" & globalRoutines.StringaInformativaProgramma(myAssembly) & ")"
        If Not objWRCB.Sciolto Then objWRCB.lstRapp = Me.lstRapp
        oldSize = New Size(Size.Width, Size.Height)
    End Sub
    Private Sub Apert_Closed(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Closed
        ChiudeFile()
        If Not objWRCB.Sciolto Then
            If Not Monitor.Motore.Problem.FileStream Is Nothing Then
                Monitor.Motore.Problem.FineRapp()
                objWRCB.FileScambio = FileSt
            Else
                objWRCB.FileScambio = ""
            End If
        End If
        Monitor.Motore.Ammazza("WRCB")
        objWRCB = Nothing
        Monitor = Nothing
    End Sub
    Public Sub mnuAmmTutti_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuAmmTutti.DropDownOpening
        mnuAmmTutti_Click(eventSender, eventArgs)
    End Sub
    Public Sub mnuAmmTutti_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuAmmTutti.Click
        For iB = 1 To Config.NBocch
            If Geom(iB).Incluso > 0 Then
                Res = AggiornaAllow()
                If Not Res Then Exit For
            End If
        Next
        iB = 0
    End Sub

    Public Sub mnuAmmUno_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuAmmUno.DropDownOpening
        mnuAmmUno_Click(eventSender, eventArgs)
    End Sub
    Public Sub mnuAmmUno_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuAmmUno.Click
        Dim Res As Boolean
        If iB = 0 Then
            MsgBox(msgText, MsgBoxStyle.Critical, "WRCB")
        Else
            Res = AggiornaAllow()
        End If
    End Sub

    Public Sub mnuApri_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuApri.DropDownOpening
        mnuApri_Click(eventSender, eventArgs)
    End Sub
    Public Sub mnuApri_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuApri.Click
        Dim Res As Boolean
        Res = ApriLeggi()
    End Sub
    Public Sub mnuCalcTutti_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuCalcTutti.DropDownOpening
        mnuCalcTutti_Click(eventSender, eventArgs)
    End Sub
    Public Sub mnuCalcTutti_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuCalcTutti.Click
        Dim Res As Boolean
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        Res = Esegui(0)
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
    End Sub

    Public Sub mnuCalcUno_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuCalcUno.DropDownOpening
        mnuCalcUno_Click(eventSender, eventArgs)
    End Sub
    Public Sub mnuCalcUno_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuCalcUno.Click
        Dim Res As Boolean
        If iB = 0 Then
            MsgBox(msgText, MsgBoxStyle.Critical, "WRCB")
        Else
            Res = Esegui(iB)
        End If
    End Sub

    Public Sub mnuCarTutti_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuCarTutti.DropDownOpening
        mnuCarTutti_Click(eventSender, eventArgs)
    End Sub
    Public Sub mnuCarTutti_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuCarTutti.Click
        For iB = 1 To Config.NBocch
            If Geom(iB).Incluso > 0 Then
                Res = SubCarichi()
                If Not Res Then Exit For
            End If
        Next
        iB = 0
    End Sub

    Public Sub mnuCarUno_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuCarUno.DropDownOpening
        mnuCarUno_Click(eventSender, eventArgs)
    End Sub
    Public Sub mnuCarUno_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuCarUno.Click
        Dim Res As Boolean
        If iB = 0 Then
            MsgBox(msgText, MsgBoxStyle.Critical, "WRCB")
        Else
            Res = SubCarichi()
        End If
    End Sub

    Public Sub mnuChiudi_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuChiudi.DropDownOpening
        mnuChiudi_Click(eventSender, eventArgs)
    End Sub
    Public Sub mnuChiudi_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuChiudi.Click
        ChiudeFile()
    End Sub

    Public Sub mnuDatiGen_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuDatiGen.DropDownOpening
        mnuDatiGen_Click(eventSender, eventArgs)
    End Sub
    Public Sub mnuDatiGen_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuDatiGen.Click
        SubConfig()
    End Sub

    Public Sub mnuEsci_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuEsci.DropDownOpening
        mnuEsci_Click(eventSender, eventArgs)
    End Sub
    Public Sub mnuEsci_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuEsci.Click
        Monitor.Motore.Ammazza("WRCB")
        If Not Monitor Is Nothing Then
            Monitor.Dispose()
            Monitor = Nothing
        End If
        Dispose()
    End Sub

    Public Sub mnuGeomTutti_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuGeomTutti.DropDownOpening
        mnuGeomTutti_Click(eventSender, eventArgs)
    End Sub
    Public Sub mnuGeomTutti_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuGeomTutti.Click
        For iB = 1 To Config.NBocch
            If Geom(iB).Incluso > 0 Then
                Res = SubGeom()
                If Not Res Then Exit For
            End If
        Next
        iB = 0
    End Sub

    Public Sub mnuGeomUno_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuGeomUno.DropDownOpening
        mnuGeomUno_Click(eventSender, eventArgs)
    End Sub
    Public Sub mnuGeomUno_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuGeomUno.Click
        Dim Res As Boolean
        If iB = 0 Then
            MsgBox(msgText, MsgBoxStyle.Critical, "WRCB")
        Else
            Res = SubGeom()
        End If
    End Sub

    Public Sub mnuLibr_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuLibr.DropDownOpening
        mnuLibr_Click(eventSender, eventArgs)
    End Sub
    Public Sub mnuLibr_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuLibr.Click
        Library()
    End Sub

    Public Sub mnuSalva_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuSalva.DropDownOpening
        mnuSalva_Click(eventSender, eventArgs)
    End Sub
    Public Sub mnuSalva_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuSalva.Click
        ApriScrivi()
        ModifiedData = False
    End Sub

    Public Sub mnuStLibr_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuStLibr.DropDownOpening
        mnuStLibr_Click(eventSender, eventArgs)
    End Sub
    Public Sub mnuStLibr_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuStLibr.Click
        _Frames_0.Visible = True
        StamTutteLib()
    End Sub

    Public Sub mnuTuttiDati_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuTuttiDati.DropDownOpening
        mnuTuttiDati_Click(eventSender, eventArgs)
    End Sub
    Public Sub mnuTuttiDati_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuTuttiDati.Click
        SubConfig()
        mnuGeomTutti_Click(mnuGeomTutti, New System.EventArgs)
        If Not Res Then Exit Sub
        mnuAmmTutti_Click(mnuAmmTutti, New System.EventArgs)
        If Not Res Then Exit Sub
        mnuCarTutti_Click(mnuCarTutti, New System.EventArgs)
    End Sub
    Private Sub Timer1_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Timer1.Tick
        If iB = 0 And Not mnuGeomUno.Text = GeomUno Then
            mnuGeomUno.Text = GeomUno
            mnuAmmUno.Text = AmmUno
            mnuCarUno.Text = CarUno
            mnuCalcUno.Text = CalcUno
        End If
    End Sub

    Private Sub mnuSaveAs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSaveAs.Click
        ApriScriviCome()
        ModifiedData = False
    End Sub

    Private Sub lstNoz_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstNoz.Click
        iB = CShort(lstNoz.SelectedItems(0).Index + 1)
        mnuGeomUno.Text = "Geometria " & Trim(Geom(iB).Mark)
        mnuAmmUno.Text = "Ammissibili " & Trim(Geom(iB).Mark)
        mnuCarUno.Text = "Carichi " & Trim(Geom(iB).Mark)
        mnuCalcUno.Text = "Calcola " & Trim(Geom(iB).Mark)
        cmdCalc.Enabled = True
        cmdDati.Enabled = True

    End Sub
    Private Sub Apert_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        If Inizializzando Then Exit Sub
        If oldSize.Height = 0 Then Exit Sub
        Dim dH As Integer = Size.Height - oldSize.Height
        _Frames_1.Height = _Frames_1.Height + dH
        _Frames_2.Height = _Frames_2.Height + dH
        lstNoz.Height = lstNoz.Height + dH
        lstRes.Height = lstRes.Height + dH
        Dim dW As Integer = Size.Width - oldSize.Width
        _Frames_0.Width = _Frames_0.Width + dW
        _Frames_2.Width = _Frames_2.Width + dW
        lstRes.Width = lstRes.Width + dW
        lstRapp.Width = lstRapp.Width + dW
        lstRapp.Columns(1).Width = lstRapp.Columns(1).Width + dW
        PictureBox1.Height = PictureBox1.Height + dH
        PictureBox1.Width = PictureBox1.Width + dW
        oldSize = New Size(Size.Width, Size.Height)
    End Sub
    Private Sub MenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem2.Click
        Help.ShowHelp(Me, RadiceHelp, HelpNavigator.TableOfContents)
    End Sub
    Private Sub MenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem3.Click
        Monitor.Motore.Informazioni(Me, myAssembly)
    End Sub

    Private Sub Apert_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        Monitor.Motore.Problem = Monitor.Motore.Problems("WRCB").Problem
        Monitor.Motore.About = Monitor.Motore.Problems("WRCB").About

    End Sub
End Class