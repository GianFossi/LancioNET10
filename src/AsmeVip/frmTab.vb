Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports RoutBase1
Friend Class frmTab
	Inherits System.Windows.Forms.Form
#Region "Codice generato dalla finestra di progettazione Windows Form "
	Public Sub New()
		MyBase.New()
        'If m_vb6FormDefInstance Is Nothing Then
        '      If m_InitializingDefInstance Then
        '     m_vb6FormDefInstance = Me
        '    Else
        '       Try
        '  'La prima istanza creata per il form di avvio rappresenta l'istanza predefinita.
        ' If System.Reflection.Assembly.GetExecutingAssembly.EntryPoint.DeclaringType Is Me.GetType Then
        'm_vb6FormDefInstance = Me
        'End If
        '    Catch
        'End Try
        'End If
        'End If
        'Chiamata richiesta dalla progettazione Windows Form.
        Inizializzando = True
        InitializeComponent()
        Inizializza()
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
	Public WithEvents TipoCalc As System.Windows.Forms.TextBox
	Public WithEvents txtTipo As System.Windows.Forms.TextBox
	Public WithEvents txtMemb As System.Windows.Forms.TextBox
	Public WithEvents cmdCancel As System.Windows.Forms.Button
	Public WithEvents cmdAperture As System.Windows.Forms.Button
	Public WithEvents cmdPIDes As System.Windows.Forms.Button
	Public WithEvents cmdRota As System.Windows.Forms.Button
	Public WithEvents cmdCalc As System.Windows.Forms.Button
	Public WithEvents cmdOk As System.Windows.Forms.Button
	Public WithEvents optOptim As System.Windows.Forms.Button
    Public WithEvents NonValido As System.Windows.Forms.TextBox
    Public WithEvents _Valore_0 As System.Windows.Forms.TextBox
    Public WithEvents Picture1 As System.Windows.Forms.Panel
    Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
    'NOTA: la routine seguente è richiesta dalla progettazione Windows Form.
	'Può essere modificata utilizzando la finestra di progettazione Windows Form.
	'Non modificarla mediante l'editor di codice.
    Friend WithEvents HelpProvider1 As System.Windows.Forms.HelpProvider
    Friend WithEvents _Variabile_0 As System.Windows.Forms.RichTextBox
    Friend WithEvents _Descrizione_0 As System.Windows.Forms.RichTextBox
    Friend WithEvents _Dimensioni_0 As System.Windows.Forms.RichTextBox
    Friend WithEvents Schedario As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Public WithEvents _Opt_0 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmTab))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmdPIDes = New System.Windows.Forms.Button
        Me.optOptim = New System.Windows.Forms.Button
        Me.TipoCalc = New System.Windows.Forms.TextBox
        Me.txtTipo = New System.Windows.Forms.TextBox
        Me.txtMemb = New System.Windows.Forms.TextBox
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdAperture = New System.Windows.Forms.Button
        Me.cmdRota = New System.Windows.Forms.Button
        Me.cmdCalc = New System.Windows.Forms.Button
        Me.cmdOk = New System.Windows.Forms.Button
        Me.Picture1 = New System.Windows.Forms.Panel
        Me._Dimensioni_0 = New System.Windows.Forms.RichTextBox
        Me._Descrizione_0 = New System.Windows.Forms.RichTextBox
        Me._Variabile_0 = New System.Windows.Forms.RichTextBox
        Me.NonValido = New System.Windows.Forms.TextBox
        Me._Opt_0 = New System.Windows.Forms.Button
        Me._Valore_0 = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.HelpProvider1 = New System.Windows.Forms.HelpProvider
        Me.Schedario = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.Picture1.SuspendLayout()
        Me.Schedario.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdPIDes
        '
        Me.cmdPIDes.BackColor = System.Drawing.SystemColors.Control
        Me.cmdPIDes.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdPIDes.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdPIDes.Location = New System.Drawing.Point(232, 440)
        Me.cmdPIDes.Name = "cmdPIDes"
        Me.cmdPIDes.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdPIDes.Size = New System.Drawing.Size(81, 25)
        Me.cmdPIDes.TabIndex = 50
        Me.cmdPIDes.Text = "P.I+Design"
        Me.ToolTip1.SetToolTip(Me.cmdPIDes, "Questa operazione è possibile solo nei calcoli di verifica")
        Me.cmdPIDes.Visible = False
        '
        'optOptim
        '
        Me.optOptim.BackColor = System.Drawing.SystemColors.Control
        Me.optOptim.Cursor = System.Windows.Forms.Cursors.Default
        Me.optOptim.ForeColor = System.Drawing.SystemColors.ControlText
        Me.HelpProvider1.SetHelpKeyword(Me.optOptim, "GrFucPag1.htm#SuperOtt")
        Me.HelpProvider1.SetHelpNavigator(Me.optOptim, System.Windows.Forms.HelpNavigator.Topic)
        Me.optOptim.Image = CType(resources.GetObject("optOptim.Image"), System.Drawing.Image)
        Me.optOptim.Location = New System.Drawing.Point(480, 312)
        Me.optOptim.Name = "optOptim"
        Me.optOptim.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HelpProvider1.SetShowHelp(Me.optOptim, True)
        Me.optOptim.Size = New System.Drawing.Size(40, 26)
        Me.optOptim.TabIndex = 63
        Me.optOptim.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.optOptim, "Calcolo dell'ottimo economico")
        '
        'TipoCalc
        '
        Me.TipoCalc.AcceptsReturn = True
        Me.TipoCalc.AutoSize = False
        Me.TipoCalc.BackColor = System.Drawing.SystemColors.Window
        Me.TipoCalc.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TipoCalc.Enabled = False
        Me.TipoCalc.Font = New System.Drawing.Font("Arial", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TipoCalc.ForeColor = System.Drawing.Color.FromArgb(CType(128, Byte), CType(0, Byte), CType(0, Byte))
        Me.TipoCalc.Location = New System.Drawing.Point(288, 24)
        Me.TipoCalc.MaxLength = 0
        Me.TipoCalc.Name = "TipoCalc"
        Me.TipoCalc.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TipoCalc.Size = New System.Drawing.Size(257, 25)
        Me.TipoCalc.TabIndex = 62
        Me.TipoCalc.Text = " Calcolo a pressione interna"
        Me.TipoCalc.Visible = False
        '
        'txtTipo
        '
        Me.txtTipo.AcceptsReturn = True
        Me.txtTipo.AutoSize = False
        Me.txtTipo.BackColor = System.Drawing.SystemColors.Window
        Me.txtTipo.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTipo.Enabled = False
        Me.txtTipo.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtTipo.Location = New System.Drawing.Point(288, 0)
        Me.txtTipo.MaxLength = 0
        Me.txtTipo.Name = "txtTipo"
        Me.txtTipo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtTipo.Size = New System.Drawing.Size(257, 25)
        Me.txtTipo.TabIndex = 61
        Me.txtTipo.Text = "Text1"
        '
        'txtMemb
        '
        Me.txtMemb.AcceptsReturn = True
        Me.txtMemb.AutoSize = False
        Me.txtMemb.BackColor = System.Drawing.SystemColors.Window
        Me.txtMemb.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtMemb.Enabled = False
        Me.txtMemb.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtMemb.Location = New System.Drawing.Point(88, 0)
        Me.txtMemb.MaxLength = 0
        Me.txtMemb.Name = "txtMemb"
        Me.txtMemb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtMemb.Size = New System.Drawing.Size(153, 25)
        Me.txtMemb.TabIndex = 59
        Me.txtMemb.Text = "Text1"
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCancel.Location = New System.Drawing.Point(448, 440)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCancel.Size = New System.Drawing.Size(64, 25)
        Me.cmdCancel.TabIndex = 53
        Me.cmdCancel.Text = "Cancel"
        '
        'cmdAperture
        '
        Me.cmdAperture.BackColor = System.Drawing.SystemColors.Control
        Me.cmdAperture.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdAperture.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdAperture.Location = New System.Drawing.Point(152, 440)
        Me.cmdAperture.Name = "cmdAperture"
        Me.cmdAperture.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdAperture.Size = New System.Drawing.Size(81, 25)
        Me.cmdAperture.TabIndex = 51
        Me.cmdAperture.Text = "Aperture"
        '
        'cmdRota
        '
        Me.cmdRota.BackColor = System.Drawing.SystemColors.Control
        Me.cmdRota.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdRota.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdRota.Location = New System.Drawing.Point(312, 440)
        Me.cmdRota.Name = "cmdRota"
        Me.cmdRota.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdRota.Size = New System.Drawing.Size(73, 25)
        Me.cmdRota.TabIndex = 49
        Me.cmdRota.Text = "Rotazione"
        '
        'cmdCalc
        '
        Me.cmdCalc.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCalc.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCalc.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCalc.Location = New System.Drawing.Point(384, 440)
        Me.cmdCalc.Name = "cmdCalc"
        Me.cmdCalc.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCalc.Size = New System.Drawing.Size(64, 25)
        Me.cmdCalc.TabIndex = 48
        Me.cmdCalc.Text = "Verifica"
        '
        'cmdOk
        '
        Me.cmdOk.BackColor = System.Drawing.SystemColors.Control
        Me.cmdOk.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdOk.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdOk.Location = New System.Drawing.Point(512, 440)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdOk.Size = New System.Drawing.Size(41, 25)
        Me.cmdOk.TabIndex = 34
        Me.cmdOk.Text = "OK"
        '
        'Picture1
        '
        Me.Picture1.BackColor = System.Drawing.SystemColors.Control
        Me.Picture1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Picture1.Controls.Add(Me._Dimensioni_0)
        Me.Picture1.Controls.Add(Me._Descrizione_0)
        Me.Picture1.Controls.Add(Me._Variabile_0)
        Me.Picture1.Controls.Add(Me.optOptim)
        Me.Picture1.Controls.Add(Me.NonValido)
        Me.Picture1.Controls.Add(Me._Opt_0)
        Me.Picture1.Controls.Add(Me._Valore_0)
        Me.Picture1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Picture1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Picture1.Location = New System.Drawing.Point(8, 8)
        Me.Picture1.Name = "Picture1"
        Me.Picture1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Picture1.Size = New System.Drawing.Size(544, 344)
        Me.Picture1.TabIndex = 12
        Me.Picture1.TabStop = True
        '
        '_Dimensioni_0
        '
        Me._Dimensioni_0.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me._Dimensioni_0.Location = New System.Drawing.Point(280, 0)
        Me._Dimensioni_0.Name = "_Dimensioni_0"
        Me._Dimensioni_0.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
        Me._Dimensioni_0.Size = New System.Drawing.Size(37, 26)
        Me._Dimensioni_0.TabIndex = 66
        Me._Dimensioni_0.Text = "RichTextBox1"
        '
        '_Descrizione_0
        '
        Me._Descrizione_0.BackColor = System.Drawing.Color.Yellow
        Me._Descrizione_0.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me._Descrizione_0.Location = New System.Drawing.Point(36, 0)
        Me._Descrizione_0.Name = "_Descrizione_0"
        Me._Descrizione_0.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
        Me._Descrizione_0.Size = New System.Drawing.Size(246, 26)
        Me._Descrizione_0.TabIndex = 65
        Me._Descrizione_0.Text = "RichTextBox1"
        '
        '_Variabile_0
        '
        Me._Variabile_0.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me._Variabile_0.Location = New System.Drawing.Point(0, 0)
        Me._Variabile_0.Name = "_Variabile_0"
        Me._Variabile_0.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
        Me._Variabile_0.Size = New System.Drawing.Size(37, 26)
        Me._Variabile_0.TabIndex = 64
        Me._Variabile_0.Text = "RichTextBox1"
        '
        'NonValido
        '
        Me.NonValido.AcceptsReturn = True
        Me.NonValido.AutoSize = False
        Me.NonValido.BackColor = System.Drawing.SystemColors.Window
        Me.NonValido.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.NonValido.Enabled = False
        Me.NonValido.Font = New System.Drawing.Font("Arial", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NonValido.ForeColor = System.Drawing.Color.FromArgb(CType(128, Byte), CType(0, Byte), CType(0, Byte))
        Me.NonValido.Location = New System.Drawing.Point(280, 312)
        Me.NonValido.MaxLength = 0
        Me.NonValido.Name = "NonValido"
        Me.NonValido.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.NonValido.Size = New System.Drawing.Size(144, 25)
        Me.NonValido.TabIndex = 52
        Me.NonValido.Text = " Verifica non valida"
        Me.NonValido.Visible = False
        '
        '_Opt_0
        '
        Me._Opt_0.BackColor = System.Drawing.SystemColors.Control
        Me._Opt_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Opt_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Opt_0.Location = New System.Drawing.Point(424, 0)
        Me._Opt_0.Name = "_Opt_0"
        Me._Opt_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Opt_0.Size = New System.Drawing.Size(56, 26)
        Me._Opt_0.TabIndex = 47
        Me._Opt_0.TabStop = False
        Me._Opt_0.Visible = False
        '
        '_Valore_0
        '
        Me._Valore_0.AcceptsReturn = True
        Me._Valore_0.AutoSize = False
        Me._Valore_0.BackColor = System.Drawing.SystemColors.Window
        Me._Valore_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Valore_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Valore_0.Location = New System.Drawing.Point(318, 0)
        Me._Valore_0.MaxLength = 0
        Me._Valore_0.Name = "_Valore_0"
        Me._Valore_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Valore_0.Size = New System.Drawing.Size(105, 26)
        Me._Valore_0.TabIndex = 1
        Me._Valore_0.Text = "Text1"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(248, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(33, 17)
        Me.Label2.TabIndex = 60
        Me.Label2.Text = "Tipo:"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(8, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(73, 17)
        Me.Label1.TabIndex = 58
        Me.Label1.Text = "Membratura:"
        '
        'HelpProvider1
        '
        Me.HelpProvider1.HelpNamespace = "bin\AsmeVip.chm"
        '
        'Schedario
        '
        Me.Schedario.Controls.Add(Me.TabPage1)
        Me.Schedario.Location = New System.Drawing.Point(0, 48)
        Me.Schedario.Name = "Schedario"
        Me.Schedario.SelectedIndex = 0
        Me.Schedario.Size = New System.Drawing.Size(568, 384)
        Me.Schedario.TabIndex = 63
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Picture1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(560, 358)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "TabPage1"
        '
        'frmTab
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(570, 472)
        Me.Controls.Add(Me.Schedario)
        Me.Controls.Add(Me.TipoCalc)
        Me.Controls.Add(Me.txtTipo)
        Me.Controls.Add(Me.txtMemb)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdAperture)
        Me.Controls.Add(Me.cmdPIDes)
        Me.Controls.Add(Me.cmdRota)
        Me.Controls.Add(Me.cmdCalc)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.HelpButton = True
        Me.HelpProvider1.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.TableOfContents)
        Me.Location = New System.Drawing.Point(3, 23)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTab"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HelpProvider1.SetShowHelp(Me, True)
        Me.Text = "AsmeVip - Calcolo Flangioni / anelli fucinati / coperchi piani"
        Me.Picture1.ResumeLayout(False)
        Me.Schedario.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
#End Region 
    Private Inizializzando As Boolean
    Friend Variabile As rtfArray
    Friend Descrizione As rtfArray
    Friend Dimensioni As rtfArray
    Friend Valore As TextArray
    Friend Opt As ButtonArray
    Public Fatto, Accoppiato As wn_flan
    Public AccoppiatoPT As wn_PT
    Public Finito As Boolean
    Public Esci, cmdCliccato As Boolean
    Public OK, GiaDetto As Boolean
    Public VisualTipo As Short
    Public Compensazione As Boolean
    Private O As wn_flan
    Private Aperture As Boolean
    Private pagpag As String
    Private NonAzzerare, ScrivendoValore As Boolean
    Private pagmax, indiceMon As Short
    Private ValMon As Single
    Private Merito, MerOpt As Single
    Private hOpt, GOpt, g1Opt, hLoc As Single
    Private Stadio, iRig As Short
    Private g1, hHub, g0, g As Single
    Private Sub Inizializza()
        Variabile = New rtfArray(Me, Picture1, "_Variabile")
        Descrizione = New rtfArray(Me, Picture1, "_Descrizione")
        Dimensioni = New rtfArray(Me, Picture1, "_Dimensioni")
        Valore = New TextArray(Me, Picture1, "_Valore")
        Opt = New ButtonArray(Me, Picture1, "_Opt")
        Dim i, k, ifl As Short
        Dim Riga As String = ""
        Dim P0 As Single
        Try
            For i = 1 To 11
                Variabile.Load(i)
                Variabile(i).Top = 26 * i
                Descrizione.Load(i)
                Descrizione(i).Top = 26 * i
                Dimensioni.Load(i)
                Dimensioni(i).Top = 26 * i
                Valore.Load(i)
                Valore(i).Top = 26 * i

            Next
            For k = 0 To 1
                For i = 0 To 11
                    Opt.Load(i + k * 20)
                    Opt(i + k * 20).Top = Dimensioni(i).Top
                    If k = 1 Then Opt(i + k * 20).Left = Opt(i).Left + Opt(i).Width
                    Opt(i + k * 20).Visible = False
                Next
            Next
            If jInvolucr = 0 Then
                'If Involucr(kLato, Nozzles(kLato, kNozzle).InvolucroSU).IndObject > 0 Then
                'O = CType(objMemb(Involucr(kLato, Nozzles(kLato, kNozzle).InvolucroSU).IndObject), wn_flan)
                'questo funziona nel caso di un bocchello su un coperchio piano
                'Ma neanche per sogno
                'Else
                O = CType(objMemb(Nozzles(kLato, kNozzle).IndObject), wn_flan)
                'End If
            Else
                O = CType(objMemb(Involucr(kLato, jInvolucr).IndObject), wn_flan)
            End If
            With O
                If jInvolucr > 0 And kNozzle = 0 Or jInvolucr = 0 And kNozzle > 0 Then
                    If jInvolucr > 0 Then
                        txtMemb.Text = Involucr(kLato, jInvolucr).Mark
                    Else
                        txtMemb.Text = Nozzles(kLato, kNozzle).Mark
                    End If
                    ifl = FreeFile()
                    FileOpen(ifl, Trim(clsInizio.Archdir) & "\WN5\WNLJ01.DAT", OpenMode.Input)
                    For i = 1 To .Mem.LOOSE + 2
                        Riga = LineInput(ifl)
                    Next
                    FileClose(ifl)
                    txtTipo.Text = Riga
                Else
                    txtMemb.Text = Nozzles(kLato, kNozzle).Mark
                    txtTipo.Text = "OPENING ON FLAT HEAD"
                End If
                cmdAperture.Visible = (.Mem.LOOSE = 4 And Involucr(kLato, jInvolucr).Fine >= Involucr(kLato, jInvolucr).inizio)
                If jInvolucr = 0 Then
                    AggiustaHydr(kLato, 0, kNozzle, P0, VerificandoPI)
                    jInvolucr = 0
                Else
                    AggiustaHydr(kLato, jInvolucr, 0, P0, VerificandoPI)
                End If
                .Mp(1) = P0
                .Mp(2) = TempDes()
                .Zp(1) = P0 * psi
                .Zp(2) = TempDes() * 1.8 + 32
                .pagina = 1
                If .TipCalc = 1 Then cmdPIDes.Enabled = False
            End With
            If Config(0).CalcPI = 0 Or jInvolucr = 0 Then cmdPIDes.Visible = False
        Catch e As Exception
            MessageBox.Show(e.Message + vbCrLf + e.StackTrace)
        End Try
        cmdCliccato = False
        HelpProvider1.HelpNamespace = RadiceHelp
    End Sub
    Public Sub SetPagina(ByRef mode As Short)
        If jInvolucr = 0 Then
            O = CType(objMemb(Nozzles(kLato, kNozzle).IndObject), wn_flan)
        Else
            O = CType(objMemb(Involucr(kLato, jInvolucr).IndObject), wn_flan)
        End If
        With O
            cmdAperture.Enabled = True
            cmdPIDes.Enabled = True
            cmdRota.Enabled = True
            cmdCalc.Enabled = True
            cmdCancel.Enabled = True
            Select Case .Mem.File
                Case ".ljf" : pagmax = 7
                Case ".wnf" : pagmax = 9
                    If .Mem.LOOSE = 5 Or .Mem.LOOSE = 6 Then
                        cmdAperture.Enabled = False
                        cmdPIDes.Enabled = False
                        cmdRota.Enabled = False
                    End If
                Case ".REV" : pagmax = 10
                Case ".A14" : pagmax = 7
                Case ".ljf" : pagmax = 7
                Case ".A15" : pagmax = 6
                Case ".cob" : pagmax = 4
                    cmdAperture.Enabled = False
                    cmdPIDes.Enabled = False
                    cmdRota.Enabled = False
                    '  cmdCalc.Enabled = False
                    cmdCancel.Enabled = True
                Case ".cop"
                    If .Zp(32) > 0 Then pagmax = 7
                    If .Zp(32) = 0 Then pagmax = 6
            End Select
            If .pagina < 1 Then .pagina = 1
            If .pagina > pagmax Then .pagina = pagmax
            If .Mem.File = ".wnf" Or .Mem.File = ".ljf" Then
                Select Case .pagina
                    Case 1
                        .kkk = 0
                        .WWW = 1
                        .FFF = 11
                    Case 2
                        .kkk = 0
                        .WWW = 12
                        .FFF = 22
                    Case 3
                        .kkk = 0
                        .WWW = 23
                        .FFF = 32
                    Case 4
                        .kkk = 0
                        .WWW = 33
                        .FFF = 39
                    Case 5
                        .kkk = 0
                        .WWW = 43
                        .FFF = 53
                End Select
                If .Mem.LOOSE = -1 Or .Mem.LOOSE = 2 Then
                    If .pagina = 6 Then
                        .kkk = 0
                        .WWW = 54
                        .FFF = 62
                    End If
                    If .pagina = 7 Then
                        .kkk = 0
                        .WWW = 63
                        .FFF = 72
                        If .Mp(195) > 0 Then .FFF = 73
                    End If
                Else
                    If .pagina = 6 Then
                        .kkk = 0
                        .WWW = 54
                        .FFF = 64
                    End If
                    If .pagina = 7 Then
                        .kkk = 0
                        .WWW = 65
                        .FFF = 74
                    End If
                    If .pagina = 8 Then
                        .kkk = 0
                        .WWW = 75
                        .FFF = 82
                    End If
                    If .pagina = 9 Then
                        .kkk = 0
                        .WWW = 83
                        .FFF = 89
                    End If
                End If
            ElseIf .Mem.File = ".REV" Then
                Select Case .pagina
                    Case 1
                        .kkk = 0
                        .WWW = 1
                        .FFF = 11
                    Case 2
                        .kkk = 0
                        .WWW = 12
                        .FFF = 21
                    Case 3
                        .kkk = 0
                        .WWW = 23
                        .FFF = 32
                    Case 4
                        .kkk = 0
                        .WWW = 34
                        .FFF = 39
                    Case 5
                        .kkk = 0
                        .WWW = 43
                        .FFF = 53
                    Case 6
                        .kkk = 0
                        .WWW = 54
                        .FFF = 64
                    Case 7
                        .kkk = 0
                        .WWW = 65
                        .FFF = 74
                    Case 8
                        .kkk = 0
                        .WWW = 75
                        .FFF = 78
                    Case 9
                        .kkk = 0
                        .WWW = 79
                        .FFF = 86
                    Case 10
                        .kkk = 0
                        .WWW = 87
                        .FFF = 93
                End Select
            ElseIf .Mem.File = ".A14" Then
                Select Case .pagina
                    Case 1
                        .kkk = 0
                        .WWW = 1
                        .FFF = 11
                    Case 2
                        .kkk = 0
                        .WWW = 12
                        .FFF = 18
                    Case 3
                        .kkk = 0
                        .WWW = 19
                        .FFF = 27
                    Case 4
                        .kkk = 0
                        .WWW = 28
                        .FFF = 37
                    Case 5
                        .kkk = 0
                        .WWW = 38
                        .FFF = 47
                    Case 6
                        .kkk = 0
                        .WWW = 48
                        .FFF = 56
                    Case 7
                        .kkk = 0
                        .WWW = 57
                        .FFF = 66
                End Select
            ElseIf .Mem.File = ".A15" Then
                Select Case .pagina
                    Case 1
                        .kkk = 0
                        .WWW = 1
                        .FFF = 8
                    Case 2
                        .kkk = 0
                        .WWW = 12
                        .FFF = 18
                    Case 3
                        .kkk = 0
                        .WWW = 19
                        .FFF = 27
                    Case 4
                        .kkk = 0
                        .WWW = 38
                        .FFF = 47
                    Case 5
                        .kkk = 0
                        .WWW = 48
                        .FFF = 56
                    Case 6
                        .kkk = 0
                        .WWW = 57
                        .FFF = 66
                End Select
            ElseIf .Mem.File = ".cop" Then
                If .pagina = 1 Then
                    .kkk = 0
                    .WWW = 1
                    .FFF = 5
                End If
                If .pagina = 2 Then
                    .kkk = 0
                    .WWW = 12
                    .FFF = 21
                End If
                If .pagina = 3 Then
                    .kkk = 0
                    .WWW = 171
                    .FFF = 180
                End If
                If .pagina = 4 Then
                    .kkk = 0
                    .WWW = 33
                    .FFF = 39
                End If
                If .pagina = 5 Then
                    .kkk = 0
                    .WWW = 43
                    .FFF = 53
                End If
                If .pagina = 6 Then
                    .kkk = 0
                    .WWW = 121
                    .FFF = 131
                End If
                If .pagina = 7 Then
                    .kkk = 0
                    .WWW = 169
                    .FFF = 170
                End If
            ElseIf .Mem.File = ".cob" Then
                If .Mem.LOOSE = -1 Or .Mem.LOOSE = 2 Then
                    If .pagina = 1 Then
                        .kkk = 0
                        .WWW = 121
                        .FFF = 132
                    End If
                    If .pagina = 2 Then
                        .kkk = 0
                        .WWW = 133
                        .FFF = 137
                    End If
                    If .pagina = 3 Then
                        .kkk = 0
                        .WWW = 138
                        .FFF = 144
                    End If
                    If .pagina = 4 Then
                        .kkk = 0
                        .WWW = 145
                        .FFF = 152
                    End If
                Else
                    If .pagina = 1 Then
                        .kkk = 4
                        .WWW = 137
                        .FFF = 148
                    End If
                    If .pagina = 2 Then
                        .kkk = 0
                        .WWW = 149
                        .FFF = 153
                    End If
                    If .pagina = 3 Then
                        .kkk = 0
                        .WWW = 154
                        .FFF = 160
                    End If
                    If .pagina = 4 Then
                        .kkk = 0
                        .WWW = 161
                        .FFF = 168
                    End If
                End If
            End If
            If mode = 0 Then Exit Sub
            Schedario.Tag = "-1"
            Schedario.SelectedIndex = .pagina - 1
            Schedario.Tag = "0"
            pagpag = Chr(64 + .pagina)
            If .Mem.File = ".ljf" Then
                If .Mem.LOOSE = -1 And .Zp(7) < 0 Then pagpag = pagpag & "sl"
                If .Mem.LOOSE = 2 And .Mp(195) = 1 Then pagpag = pagpag & "fh"
                If .Mem.LOOSE = 2 And .Mp(195) = 2 Then pagpag = pagpag & "fk"
                If .Mem.LOOSE = 2 And .Mp(195) = 0 Then pagpag = pagpag & "op"
            End If
            VerifErr()
            NonAzzerare = True
            ScrivendoValore = True
            Carica(pagpag + .Mem.File)
            ScrivendoValore = False
            NonAzzerare = False
            AggiornaTab()
        End With
    End Sub
    Private Sub Carica(ByRef Fwn As String, Optional ByRef Index As Short = 0)
        Dim ifl, i, k As Short
        Dim a As String
        Dim DIME As String = ""
        Dim Var As String = ""
        Dim Des As String = ""
        Dim Valor As String = ""
        Dim n, indice As Short
        For i = 0 To 11
            For k = 0 To 1
                Opt(i + 20 * k).Visible = False
            Next
        Next
        ifl = FreeFile()
        FileOpen(ifl, Trim(clsInizio.Archdir) & "\WN5\" & Fwn, OpenMode.Input, , OpenShare.Shared)
        iRig = 0
        Do
            If EOF(ifl) Then Exit Do
            a = LineInput(ifl)
            If Len(a) < 3 Then a = Space(2)
            If a.Substring(0, 1) = "f" Then Exit Do
            iRig += 1
            Select Case iRig
                Case 2 'Programma
                    If Mid(a, 2, 1) = "$" Then
                        Mid(a, 2, 1) = " "
                        'a = FormatS(a, AboutProg.Code)
                    End If
                Case 3 'Codice
                Case 5 'Regola
                Case Is >= 9
                    With O
                        indice = iRig - 9 + .WWW
                        If iRig <= 20 And indice <= .FFF Then
                            a = VB.Right(a, Len(a) - 1)
                            n = InStr(a, "³")
                            If n > 0 Then
                                Var = VB.Left(a, n - 1)
                                a = VB.Right(a, Len(a) - n)
                                n = InStr(a, "³")
                                Des = VB.Left(a, n - 1)
                                a = VB.Right(a, Len(a) - n)
                                n = InStr(a, "³")
                                DIME = VB.Left(a, n - 1)
                                a = VB.Right(a, Len(a) - n)
                            Else
                                Des = ""
                                'iRig1 = iRig1 - 1
                            End If
                            If (Var = "MT1" Or Var = "Mp1") And Config(0).NMWDT = 0 Then Des = ""
                            If (Var = "MT2" Or Var = "Mp2") And Config(0).NMWDT < 2 Then Des = ""
                            If Trim(Var) = "Nm" And .CRUSH = 0 Then Des = ""
                            If .Mem.File = ".cob" Then
                                If Nozzles(kLato, kNozzle).Tipo = "OPEN" Then
                                    If Var = "de " Or Var = "Tn " Or Var = "tn " Or Var = "Cn " Or Var = "Sna" Or Var = "Sno" Then Des = ""
                                    If Var = "trn" Or Var = "h  " Or Var = "H  " Then Des = ""
                                    If Var = "di " Then Des = "Inside diameter of the opening"
                                End If
                            End If
                            Var = .NVARIp(indice)
                            If Var Is Nothing Then Var = ""
                            If Des.Trim.Length > 0 And Var.Trim.Length > 0 Then
                                Sub1720(indice)
                            End If
                            If ScrivendoValore Then
                                If Des.Trim.Length > 0 Then
                                    Visibile(iRig - 9, True)
                                    Assegna(Var, Variabile(iRig - 9))
                                    Assegna(DIME.Trim, Dimensioni(iRig - 9))
                                    HelpProvider1.SetHelpKeyword(Dimensioni(iRig - 9), Monitor.HelpTopic(.PosVARIp(indice).ToString))
                                    HelpProvider1.SetHelpNavigator(Dimensioni(iRig - 9), HelpNavigator.Topic)
                                    HelpProvider1.SetShowHelp(Dimensioni(iRig - 9), True)
                                    HelpProvider1.SetHelpKeyword(Variabile(iRig - 9), Monitor.HelpTopic(.PosVARIp(indice).ToString))
                                    HelpProvider1.SetHelpNavigator(Variabile(iRig - 9), HelpNavigator.Topic)
                                    HelpProvider1.SetShowHelp(Variabile(iRig - 9), True)
                                    HelpProvider1.SetHelpKeyword(Descrizione(iRig - 9), Monitor.HelpTopic(.PosVARIp(indice).ToString))
                                    HelpProvider1.SetHelpNavigator(Descrizione(iRig - 9), HelpNavigator.Topic)
                                    HelpProvider1.SetShowHelp(Descrizione(iRig - 9), True)
                                    If Var.Trim.Length > 0 Then
                                        ScriviValore(indice, iRig - 9)
                                        NonAzzerare = True
                                        Select Case .TVARIp(indice)
                                            Case "D"
                                                Dim ii As Short = 23 : If O.LoadCond = 1 Then ii = 172
                                                Assegna(GlobalRoutines.FormatS(Des, .Zp(ii) * 1.5), Descrizione(iRig - 9))
                                            Case "E"
                                                If Des.IndexOf("#") > -1 Then
                                                    Dim ii As Short = 23 : If O.LoadCond = 1 Then ii = 172
                                                    Assegna(GlobalRoutines.FormatS(Des, .Zp(ii)), Descrizione(iRig - 9))
                                                Else
                                                    Assegna(Des, Descrizione(iRig - 9))
                                                End If
                                            Case Else
                                                Assegna(Des, Descrizione(iRig - 9))
                                        End Select
                                        If InStr(.CVARIp(indice), "-") > 0 Then
                                            Valore(iRig - 9).Enabled = False
                                            Descrizione(iRig - 9).BackColor = System.Drawing.ColorTranslator.FromOle(QBColor(15))
                                        Else
                                            Valore(iRig - 9).Enabled = True
                                            Descrizione(iRig - 9).BackColor = System.Drawing.ColorTranslator.FromOle(QBColor(14))
                                        End If
                                        If InStr(.CVARIp(indice), "*") > 0 Then
                                            Valore(iRig - 9).ForeColor = System.Drawing.ColorTranslator.FromOle(QBColor(4))
                                            Valore(iRig - 9).BackColor = System.Drawing.ColorTranslator.FromOle(QBColor(11))
                                        Else
                                            Valore(iRig - 9).ForeColor = System.Drawing.ColorTranslator.FromOle(QBColor(0))
                                            Valore(iRig - 9).BackColor = System.Drawing.ColorTranslator.FromOle(QBColor(15))
                                        End If
                                    Else
                                        Valore(iRig - 9).Text = ""
                                        Valore(iRig - 9).Enabled = False
                                        Assegna(Des, Descrizione(iRig - 9))
                                        Descrizione(iRig - 9).BackColor = System.Drawing.ColorTranslator.FromOle(QBColor(15))
                                    End If
                                Else
                                    Visibile(iRig - 9, False)
                                End If
                            Else
                                '  If iRig - 9 = Index Then Exit Do
                            End If
                        Else
                            Visibile(iRig - 9, False)
                        End If
                    End With
            End Select
        Loop  'WEND
        FileClose(ifl)
    End Sub
    Private Sub cmdAperture_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdAperture.Click
        Aperture = True
        With O
            .Supercont(0)
            If .Mem.Conforme = "SI" Then
                cmdOk.Enabled = True
            Else
                cmdOk.Enabled = False
                CloseioutS((mioApert.lstRapp))
            End If
            Valore(0).Text = GlobalRoutines.myStr(.Mp(119), 3, 2, 0)
        End With
    End Sub
    Public Sub cmdCalc_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCalc.Click
        With O
            If cmdCliccato Then
                If Not cmdCalc.Text = "Continua" Then .AzzeraConferme()
            End If
            cmdCliccato = True
            Attivazione()
            If VerificandoPI Then
                .Carichi(1, 0)
                .qbflan = 0
                .SupCalcola()
                If .qbflan = 0 Then
                    .pagina = 9
                    .Stampa(False)
                End If
                SetPagina(1)
            ElseIf .TipCalc = 3 Then
1810:           Select Case Stadio
                    Case 0
                        Stadio = 1
                        If Not .RilBull1 Then If .qbflan = 1 Or .qbflan = 5 Then Stadio = 0 : Exit Sub Else cmdCancel_Click(cmdCancel, New System.EventArgs)
                        TipoCalc.Text = "Calcolo a pressione di progetto"
                        cmdCalc.Text = "Continua"
                        HelpProvider1.SetHelpNavigator(cmdCalc, HelpNavigator.Topic)
                        HelpProvider1.SetHelpKeyword(cmdCalc, Monitor.HelpTopic(6031))
                        HelpProvider1.SetShowHelp(cmdCalc, True)
                        cmdOk.Enabled = False
                    Case 1
                        Stadio = 2
                        Select Case .CalcolaProgetto
                            Case 0 : cmdCancel_Click(cmdCancel, New System.EventArgs)
                            Case 1 : Stadio = 0 : GoTo 1810
                            Case -1
                                cmdOk.Enabled = True
                                cmdCalc.Visible = False
                                If Config(kLato).NMWDT > 0 Then .CalcMinTemp()
                        End Select
                    Case 2
                        Stadio = 0
                        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto O.qbflan. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                        If .qbflan = 0 Then
                            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto O.pagina. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                            .pagina = 9
                            '.Stampa
                            'If Config(0).CalcMAWP Then .CalcMAWP
                            SetPagina(1)
                        End If
                End Select
            Else
                .Carichi(0, 0)
                .qbflan = 0
                .SupCalcola() 'GoSub 6000 riesegui tutto il calcolo
                If .qbflan = 0 Then
                    .pagina = 9
                    .Stampa(False)
                    If Not (.Mem.LOOSE = 5 Or .Mem.LOOSE = 6) Then
                        If .wntorc(0) Then .Stampato(1, False) '((WmHI))
                    End If
                    If Not Monitor.Motore.Problem.FileStream Is Nothing Then
                        If Config(0).CalcMAWP And Not VerificandoPI Then .CalcMAWP()
                        If Config(kLato).NMWDT > 0 And Not VerificandoPI Then .CalcMinTemp()
                        .pagina = 9
                    End If
                End If
                SetPagina(1)
            End If
        End With
    End Sub

    Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
        OK = False
        Hide()
        ' AppActivate mioAPert.Caption
        Fatto = O
        If Fatto.Mem.File = ".cob" Then Fatto.Mem.File = ".cop"
        Finito = True
    End Sub
    Public Sub cmdOk_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOk.Click
        Dim k, j, i As Short
        Dim Tuttok As Boolean
        Dim Max1, Max2 As Single
        Dim Primo, Secon As Boolean
        Dim iPr As Short
        OK = True
        Fatto = O
        If Fatto.Mem.File = ".cob" And Not Esci Then
            Fatto.Mem.File = ".cop"
            Fatto.pagina = 1
            SetPagina(1)
            Exit Sub
        End If
        Hide()
        If Fatto.Mem.File = ".A14" Or Fatto.Mem.File = ".A15" Then
            Finito = True
            Exit Sub
        End If
        j = Involucr(kLato, jInvolucr).AccoppJ
        k = Involucr(kLato, jInvolucr).AccoppK
        If j > 0 And k > 0 Then
            If Involucr(k, j).Tipo = 6 Then
                AccoppPT(k, j)
                Finito = True
                Exit Sub
            End If
            Accoppiato = objMemb(Involucr(k, j).IndObject)
            Dim CalcolatoAccoppiato As Boolean = Accoppiato.Mp(33) > 0 And Accoppiato.Mp(40) > 0
            CalcolatoAccoppiato = CalcolatoAccoppiato And Accoppiato.Mp(34) > 0 And Accoppiato.Mp(41) > 0
            CalcolatoAccoppiato = CalcolatoAccoppiato And Not Maggiore(Accoppiato.Mp(40), Accoppiato.Mp(33)) And Not Maggiore(Accoppiato.Mp(41), Accoppiato.Mp(34))
            If CalcolatoAccoppiato Then
                Tuttok = Uguale(Fatto.Mp(33), Accoppiato.Mp(33))
                Tuttok = Tuttok And Uguale(Fatto.Mp(34), Accoppiato.Mp(34)) 'gli imposti sono uguali tra l'uno e l'altro
                If Not Tuttok Then
                    Max1 = Fatto.Mp(33)
                    If Maggiore(Fatto.Mp(40), Max1) Then Max1 = Fatto.Mp(40)
                    If Maggiore(Accoppiato.Mp(33), Max1) Then Max1 = Accoppiato.Mp(33)
                    If Maggiore(Accoppiato.Mp(40), Max1) Then Max1 = Accoppiato.Mp(40)
                    Max2 = Fatto.Mp(34)
                    If Maggiore(Fatto.Mp(41), Max2) Then Max2 = Fatto.Mp(41)
                    If Maggiore(Accoppiato.Mp(34), Max2) Then Max2 = Accoppiato.Mp(34)
                    If Maggiore(Accoppiato.Mp(41), Max2) Then Max2 = Accoppiato.Mp(41)
                    Primo = Minore(Fatto.Mp(33), Max1) Or Minore(Fatto.Mp(34), Max2)
                    Secon = Minore(Accoppiato.Mp(33), Max1) Or Minore(Accoppiato.Mp(34), Max2)
                    iPr = 2
                    If Primo Or Secon Then WarnWm(Primo, Secon, k, j, iPr)
                    If Primo Then
                        Fatto.Mp(33) = Max1 : Fatto.Mp(34) = Max2
                        Fatto.Zp(33) = Max1 / NIUT : Fatto.Zp(34) = Max2 / NIUT
                    End If
                    If Secon Then
                        Accoppiato.Mp(33) = Max1 : Accoppiato.Mp(34) = Max2
                        Accoppiato.Zp(33) = Max1 / NIUT : Accoppiato.Zp(34) = Max2 / NIUT
                    End If
                End If
            Else
                Primo = True
                WarnWm(Primo, Secon, k, j, 3)
                If Not Primo Then Exit Sub
            End If
            Accoppiato.Mem.TIR = Fatto.Mem.TIR
            Accoppiato.Mem.XFil = Fatto.Mem.XFil
            Accoppiato.Zp(4) = Fatto.Zp(4)
            Accoppiato.Mp(4) = Fatto.Mp(4)
            If Not (Accoppiato.Mem.LOOSE = 5 Or Accoppiato.Mem.LOOSE = 6) Then
                For i = 12 To 21
                    If Not (i = 17 Or i = 19) Then
                        Accoppiato.Zp(i) = Fatto.Zp(i)
                        Accoppiato.Mp(i) = Fatto.Mp(i)
                    End If
                Next
            End If
        Else
                Accoppiato = Nothing
            End If
            If j > 0 And k > 0 And kLato = k Then
                'ricopia tutti i dati se uno dei due è un coperchio o se l'altro non è ancora stato compilato
                If ((Accoppiato.Mem.LOOSE = 4 Or Fatto.Mem.LOOSE = 4) And Accoppiato.Mem.LOOSE <> Fatto.Mem.LOOSE) Or Accoppiato.Zp(9) = 0 Then
                    For i = 1 To 46
                        If i <> 3 Or Accoppiato.Mp(3) < Fatto.Mp(4) Then
                            ' non ricopia il diam est (A) a meno che esso non sia inferiore
                            ' al cerchio bulloni (C)
                            Accoppiato.Zp(i) = Fatto.Zp(i)
                            Accoppiato.Mp(i) = Fatto.Mp(i)
                        End If
                    Next
                    For i = 161 To 163
                        Accoppiato.Zp(i) = Fatto.Zp(i)
                        Accoppiato.Mp(i) = Fatto.Mp(i)
                    Next
                    For i = 182 To 185
                        Accoppiato.Zp(i) = Fatto.Zp(i)
                        Accoppiato.Mp(i) = Fatto.Mp(i)
                    Next
                End If
            End If
            If Fatto.Mem.File = ".cob" Then Fatto.Mem.File = ".cop"
            Finito = True
            If (O.Mem.LOOSE = 4 And Involucr(kLato, jInvolucr).Fine >= Involucr(kLato, jInvolucr).inizio) Then
                If Not Aperture Then cmdAperture_Click(cmdAperture, New System.EventArgs)
            End If
    End Sub
    Private Sub WarnWm(ByRef Primo As Boolean, ByRef Secon As Boolean, _
    ByVal k As Short, ByVal j As Short, ByVal iPr As Short)
        Dim uu As String
        Dim Testo As String = ""
        Dim Aiuto As String = ""
        Dim Strin(3) As String
        Dim i33 As Short = 33
        Dim i34 As Short = 34
        Dim i40 As Short = 40
        Dim i41 As Short = 41
        Dim Codici As ChiaviMess = ChiaviMess.MessYesNo Or ChiaviMess.MessQuestion Or ChiaviMess.MessHelpButton
        If iPr = 1 Then
            i40 = 193
            i41 = 194
        End If
        Strin(1) = " in prova idraulica.|"
        Strin(2) = " in esercizio.|"
        Strin(3) = "|"
        If iPr = 3 Then
            Testo = "La membratura " & Involucr(k, j).Mark.Trim & ", accoppiata alla memmbratura|"
            Testo = Testo & "appena calcolata, non risulta essere stata ancora calcolata,|"
            Testo = Testo & "per quanto si evince dai valori sotto riportati.|"
            Aiuto = "AvvCaricoImposto.htm#MembrNonCalc"
        Else
            Codici = ChiaviMess.MessOkOnly Or ChiaviMess.MessInformation Or ChiaviMess.MessHelpButton
            Aiuto = "AvvCaricoImposto.htm#PrimoOrSecon"
            If Primo And Secon Then
                Testo = "La presente membratura " & Involucr(kLato, jInvolucr).Mark.Trim
                Testo = Testo & "|e la membratura accoppiata " & Trim(Involucr(k, j).Mark)
                Testo = Testo & "|devono entrambe essere ricalcolate in quanto"
                Testo = Testo & "|i tiri Wm1 e Wm2 dei tiranti a comune non sono"
                Testo = Testo & "|congruenti"
                Aiuto = "AvvCaricoImposto.htm#PrimoSecon"
            ElseIf Primo Then
                Testo = "La presente membratura " & Involucr(kLato, jInvolucr).Mark.Trim
                Testo = Testo & "|deve essere ricalcolata in quanto i tiri"
                Testo = Testo & "|Wm1 e Wm2 dei tiranti a comune con la|membratura "
                Testo = Testo & Trim(Involucr(k, j).Mark) & " non corrispondono"
                Testo = Testo & "|al calcolo di quest'ultima "
            ElseIf Secon Then
                Testo = "La membratura " & Involucr(k, j).Mark.Trim
                Testo = Testo & " deve essere|ricalcolata in quanto i tiri"
                Testo = Testo & "|Wm1 e Wm2 dei tiranti a comune con la presente|membratura "
                Testo = Testo & Trim(Involucr(kLato, jInvolucr).Mark) & " non corrispondono"
                Testo = Testo & "|al calcolo di quest'ultima "
            End If
        End If
        Testo = Testo & Strin(iPr) & "        (Valori in k" & UnitForce & ")|"
        Testo = Testo & "|          Membratura presente   Membratura accoppiata"
        Testo = Testo & "|Wm1 calc  " & GlobalRoutines.myStr(Fatto.Mp(i40) * kForce / 1000, 14, 1, 0) _
                                      & GlobalRoutines.myStr(Accoppiato.Mp(i40) * kForce / 1000, 20, 1, 0)
        If iPr > 1 Then _
        Testo = Testo & "|Wm1 imp.  " & GlobalRoutines.myStr(Fatto.Mp(i33) * kForce / 1000, 14, 1, 0) _
                                      & GlobalRoutines.myStr(Accoppiato.Mp(i33) * kForce / 1000, 20, 1, 0)
        Testo = Testo & "|Wm2 calc  " & GlobalRoutines.myStr(Fatto.Mp(i41) * kForce / 1000, 14, 1, 0) _
                                      & GlobalRoutines.myStr(Accoppiato.Mp(i41) * kForce / 1000, 20, 1, 0)
        If iPr > 1 Then _
        Testo = Testo & "|Wm2 imp.  " & GlobalRoutines.myStr(Fatto.Mp(i34) * kForce / 1000, 14, 1, 0) _
                                      & GlobalRoutines.myStr(Accoppiato.Mp(i34) * kForce / 1000, 20, 1, 0)
        uu = Testo
        If iPr = 3 Then
            Testo = Testo & "|Si vuole che siano corretti i dati della membratura da ricalcolare? "
            Testo = Testo & "|N.B.: Nell'affermativa saranno anche omogeneizzati i dati geometrici."
        ElseIf Primo And Secon Then
        Else
            Codici = ChiaviMess.MessYesNo Or ChiaviMess.MessQuestion Or ChiaviMess.MessHelpButton
            Testo = Testo & "|Si vuole che siano riportati i carichi imposti sulla membratura da ricalcolare? "
        End If
        Dim junk As ChiaviMess = ChiaviMess.Messno
        If Not ContinuoAuto Then
            junk = Monitor.Motore.Messaggio(clsInizio.ConvertiCr(Testo), _
                     Codici, _
                     "AsmeVip -" & Involucr(kLato, jInvolucr).Mark.Trim, RadiceHelp, Aiuto, True)
        Else
            junk = ChiaviMess.MessSi
            PrintlstRes(uu)
        End If
        If junk = ChiaviMess.Messno Then Primo = False : Secon = False
        If Primo And Secon Then Primo = False : Secon = False
    End Sub
    Private Sub cmdPIDes_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdPIDes.Click
        MessageBox.Show("cmdPIDes Lavori in corso")
        'With objMemb(Involucr(kLato, jInvolucr).IndObject)
        '        .RilBull
        '        If .qbflan = 0 Then
        '           .pagina = 9
        '           '.Stampa
        '           'If Config(0).CalcMAWP Then .CalcMAWP
        '           'If Config(kLato).NMWDT > 0 Then .CalcMinTemp
        '           SetPagina 1
        '        End If
        'End With
    End Sub

    Private Sub cmdRota_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdRota.Click
        Dim Z0 As Single
        Dim j, Rotaz, rapp As Single
        With O
            .wnrota(Rotaz, Z0, j, rapp, True)
            .Mp(200) = rapp
            Stamparo("Rotazione flangia")
        End With
    End Sub
    Private Sub Attivata()
        If Compensazione Then Exit Sub
        SetPagina(1)
        Attivazione()
        VerifAccopp()
    End Sub
    Private Sub VerifAccopp()
        Dim Testo, Testo1 As String
        Dim i As Short
        If Not (Involucr(kLato, jInvolucr).Tipo = 5) Then Exit Sub
        Dim j As Short = Involucr(kLato, jInvolucr).AccoppJ
        Dim k As Short = Involucr(kLato, jInvolucr).AccoppK
        If j = 0 Or k = 0 Then Exit Sub
        If Not (Involucr(k, j).Tipo = 5) Then Exit Sub
        Dim QuestaFlangia As wn_flan = CType(objMemb(Involucr(kLato, jInvolucr).IndObject), wn_flan)
        Dim QuellaFlangia As wn_flan = CType(objMemb(Involucr(k, j).IndObject), wn_flan)
        If QuellaFlangia.Mp(4) <> QuestaFlangia.Mp(4) Then
            Testo = "Il cerchio tiranti del fucinato " & Involucr(kLato, jInvolucr).Mark.Trim & " attualmente selezionato" & vbCrLf
            Testo = Testo & QuestaFlangia.Mp(4).ToString("(####0.## mm)") & "non corrisponde al cerchio del fucinato accoppiato" & vbCrLf
            Testo = Testo & Involucr(k, j).Mark.Trim & "."
            Testo1 = Testo + " Vuoi uguagliare il primo al secondo ?" & vbCrLf
            Testo1 = Testo1 & "N.B.: In caso di risposta affermativa saranno uguagliati anche" & vbCrLf
            Testo1 = Testo1 & "tutti i rimanenti dati geometrici relativi ai tiranti."
            If Not ContinuoAuto Then
                If MessageBox.Show(Me, Testo1, "AsmeVip - Grandi Fucinati", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                    QuestaFlangia.Mp(4) = QuellaFlangia.Mp(4)
                    QuestaFlangia.Zp(4) = QuellaFlangia.Zp(4)
                    For i = 13 To 21
                        QuestaFlangia.Mp(i) = QuellaFlangia.Mp(i)
                        QuestaFlangia.Zp(i) = QuellaFlangia.Zp(i)
                    Next
                    QuestaFlangia.Mem.XFil = QuellaFlangia.Mem.XFil
                    QuestaFlangia.Mem.TIR = QuellaFlangia.Mem.TIR
                End If
            Else
                nIndent = 6
                PrintlstRes(Testo1)
                nIndent = 0
            End If
        ElseIf QuellaFlangia.Mem.TIR <> QuestaFlangia.Mem.TIR Or _
               QuellaFlangia.Mp(13) <> QuestaFlangia.Mp(13) Or _
               QuellaFlangia.Mem.XFil <> QuestaFlangia.Mem.XFil Then
            For i = 13 To 21
                QuestaFlangia.Mp(i) = QuellaFlangia.Mp(i)
                QuestaFlangia.Zp(i) = QuellaFlangia.Zp(i)
            Next
            QuestaFlangia.Mem.XFil = QuellaFlangia.Mem.XFil
            QuestaFlangia.Mem.TIR = QuellaFlangia.Mem.TIR
        End If
        If QuellaFlangia.Mp(5) <> QuestaFlangia.Mp(5) Then
            Testo = "Il diametro medio guarnizione del fucinato " & Involucr(kLato, jInvolucr).Mark.Trim & " attualmente selezionato" & vbCrLf
            Testo = Testo & QuestaFlangia.Mp(5).ToString("(#####.## mm)") & "non corrisponde alla guarnizione del fucinato accoppiato" & vbCrLf
            Testo = Testo & Involucr(k, j).Mark.Trim & "."
            Testo1 = Testo + " Vuoi uguagliare il primo al secondo ?" & vbCrLf
            Testo1 = Testo1 & "N.B.: In caso di risposta affermativa saranno uguagliati anche" & vbCrLf
            Testo1 = Testo1 & "tutti i rimanenti dati geometrici relativi alla guarnizione."
            If ContinuoAuto Then
                nIndent = 6
                PrintlstRes(Testo1)
                nIndent = 0
            Else
                If MessageBox.Show(Me, Testo1, "AsmeVip - Grandi Fucinati", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                    QuestaFlangia.Mp(5) = QuellaFlangia.Mp(5)
                    QuestaFlangia.Zp(5) = QuellaFlangia.Zp(5)
                    For i = 26 To 31
                        QuestaFlangia.Mp(i) = QuellaFlangia.Mp(i)
                        QuestaFlangia.Zp(i) = QuellaFlangia.Zp(i)
                    Next
                End If
            End If
        Else
            For i = 26 To 31
                QuestaFlangia.Mp(i) = QuellaFlangia.Mp(i)
                QuestaFlangia.Zp(i) = QuellaFlangia.Zp(i)
            Next
        End If
    End Sub
    Private Sub AggiornaTab()
        Dim i As Short
        Dim t As TabPage
        Try
            Schedario.Enabled = False
            Schedario.TabPages.Clear()
            Schedario.Enabled = True
            For i = 1 To pagmax
                t = New TabPage("Pag." & i.ToString)
                Schedario.TabPages.Add(t)
            Next
            Attivazione()
            Schedario.Tag = "-1"
            Schedario.SelectedIndex = O.pagina - 1
            Schedario.Tag = "0"
            Picture1.Parent = Schedario.SelectedTab
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Private Sub Assegna(ByVal t As String, ByVal c As arrRTF)
        Try
            If t Is Nothing Then
                c.Text = ""
            ElseIf t.IndexOf("{"c) > -1 Then
                c.Rtf = t
            Else
                c.Text = t
            End If
        Catch e As Exception
            MessageBox.Show(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Private Sub frmTab_Closed(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Closed
        Finito = True
    End Sub
    Public Sub Button_Click(ByVal Nome As String)
        Dim s() As String = Nome.Split(CChar("_"))
        Dim Textnum As String = s(1)
        Dim Index As Short = CShort(s(2))
        Dim i, Ind As Short
        Dim g As LibMat.clsGuarn
        Dim BSmin, cB As Single
        Dim nt As Short
        Dim SpessMin, hr, hrmin As Single
        Dim Testo As String
        i = Index Mod 20
        With O
            Ind = i + .WWW
            Select Case Opt(Index).Tag
                Case "0"
                    .CambioUnita(Ind)
                    Assegna(.UVARIp(Ind).Trim, Dimensioni(i))
                    Dim eraAbilitato As Boolean = Valore(i).Enabled
                    Valore(i).Enabled = False
                    ScriviValore(Ind, i)
                    If eraAbilitato Then Valore(i).Enabled = True
                Case "1" 'libreria guarnizioni
                    .AzzeraImposti()
                    g = New LibMat.clsGuarn
                    ' Modifica = True
                    g.Class = .Mp(161)
                    g.Tipo = .Mp(162)
                    g.Face = .Mp(163)
                    g.Formula = .Zp(31)
                    g.Alfa = .Mp(201)
                    g.Radius = .Mp(202)
                    g.Height = .Mp(203)
                    g.Scelta((clsInizio.Archdir), (clsInizio.DiscoTem))
                    .AggiornaGuar(g)
                    g = Nothing
                    ScrivendoValore = True
                    Carica(pagpag + .Mem.File)
                    ScrivendoValore = False
                Case "3"
                    .Traversini()
                    SetPagina(1)
                Case "4" 'ottimizzazione tiranti
                    .AzzeraImposti()
                    .OptimTir()
                    If Not .qbflan = 1 Then
                        ScrivendoValore = True
                        Carica(pagpag + .Mem.File)
                        ScrivendoValore = False
                    End If
                Case "5" 'massimizzazione tiranti
                    .AzzeraImposti()
                    BSmin = .Mp(20)
                    cB = .Mp(4)
                    nt = Int(cB * pi / BSmin)
                    .Mp(13) = nt
                    ScrivendoValore = True
                    Carica(pagpag + .Mem.File)
                    ScrivendoValore = False
                Case "6" 'ammissibili
                    .AzzeraImposti()
                    AggiornaAmmiss(Ind, True)
                    ScrivendoValore = True
                    Carica(pagpag + .Mem.File)
                    ScrivendoValore = False
                    '------------------------------------------------------------
                Case "2" 'ricerca spessore flangia minimo
                    SpessoreMinimo()
                Case "8" 'ottimizzazione hr
                    If (.Zp(82) + .Zp(11) > .Zp(9) And .Mp(195) = 1) Or (.Zp(78) > .Zp(23) And .Mp(195) = 2) Then
                        Testo = "   Non è stato assunto uno spessore di flangia" & vbCrLf
                        Testo = Testo & "compatibile con il minimo di calcolo." & vbCrLf
                        Testo = Testo & "Confrontare Pag. 1 con Pag .7"
                        MessageBox.Show(Me, Testo)
                        Exit Sub
                    End If
                    SpessMin = 1.0E+20
                    For hr = -.Mp(9) / 2 To .Mp(9) / 2 Step .Mp(9) / 100
                        .Mp(125) = hr
                        .Zp(125) = hr / inc
                        If .Mp(195) = 2 Then .Mp(9) = 0
                        .ljflan()
                        If .Mp(195) = 1 Then
                            If .Zp(82) < SpessMin Then
                                SpessMin = .Zp(82) : hrmin = hr
                            End If
                        Else
                            If .Zp(9) < SpessMin Then
                                SpessMin = .Zp(9) : hrmin = hr
                            End If
                        End If
                    Next
                    .Mp(125) = hrmin
                    .Zp(125) = hrmin / inc
                    .ljflan()
                    .pagina = 1
                    Schedario.SelectedIndex = .pagina - 1
                Case "7" 'richiamo tiranti
                    .AzzeraImposti()
                    .RichiaTir()
                    ScrivendoValore = True
                    Carica(pagpag + .Mem.File)
                    ScrivendoValore = False
            End Select
        End With
    End Sub
    Private Sub optOptim_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles optOptim.Click
        Dim n, b, c, tLoc As Single
        Dim nIter As Integer
        Dim DF, Gmax, cB, hTot As Single
        Dim Testo As String
        Dim Iter As Integer
        Dim hHub1, hHub0, hHub2 As Single
        Dim g11, g10, g12 As Single
        Dim Gstep, Gmin, Factorg1 As Single
        Dim g10a, Factorg2, g11a As Single
        Dim Gmaxa, Gmina As Single
        Dim Gactorg1, Gactorg2 As Single
        Dim Finezza As Short
        Dim mp3, mp9, mp4 As Single
        InterrompiMAWP = False
        MerOpt = 1.0E+20
        Dim counter As Short
        With O
            .AzzeraConferme()
            n = .Mp(26)
            b = .Mp(6)
            g0 = .Mp(7)
            c = .Mp(11)
            '    p                B             g0
            If .Mp(1) <= 0 Or b = 0 Or g0 = 0 Then
                MostraAiuto(IDH_MANCAGEOMFLANGIA)
                Exit Sub
            End If
            'ammissibili
            If .Mp(22) <= 0 Or .Mp(23) <= 0 Or .Mp(24) <= 0 Or .Mp(25) <= 0 Then
                MostraAiuto(IDH_MANCAAMMISS)
                Exit Sub
            End If
            '    classe guarn    formula           N
            If .Mp(161) = 0 Or .Mp(31) = 0 Or .Mp(31) > 1 And n = 0 Then
                MostraAiuto(IDH_MANCAGUARNIZ)
                Exit Sub
            End If
            .SuperOtt = True
            nIter = 6 * 6 * 6
            hHub0 = Int(1.5 * g0 + 0.5)
            If hHub0 < 25 Then hHub0 = 25
            hHub1 = 5 * g0
            hHub2 = Int((hHub1 - hHub0) / 5)
            hHub1 = hHub0 + 6 * hHub2
            Factorg1 = 0
            Factorg2 = 0
            Gactorg1 = 0
            Gactorg2 = 0
            mp9 = .Mp(9)
            mp3 = .Mp(3)
            mp4 = .Mp(4)
            For Finezza = 1 To 3
                hTot = 1.0E+20
                Testo = "Ricerca della soluzione ottima" & vbCrLf
                Testo = Testo & "Passo" & Str(Finezza) & " di 3"
                g1Opt = .Mp(8)
                hOpt = .Mp(10)
                GOpt = .Mp(5)
                hHub = .Mp(10)
                Monitor.Motore.ProgrInizio(Testo, "Ottimizzazione flangia")
                Iter = 0
                counter = hHub1
                For hHub = hHub0 To counter Step hHub2
                    hLoc = 1.0E+20
                    .Mp(10) = hHub
                    .Zp(10) = hHub / inc
                    g10a = g0
                    g11a = g0 + hHub / 3
                    g10 = Int(g10a + Factorg1 * (g11a - g10a))
                    g11 = Int(g11a - Factorg2 * (g11a - g10a))
                    g12 = Int((g11 - g10) / 5) + 1
                    g11 = g10 + 6 * g12
                    For g1 = g10 To g11 Step g12
                        If (g1 - g0) * 3 > hHub Then
                            Iter = Iter + 6 * (Int(g11 - g1) / g12) + 1
                            Exit For
                        End If
                        g = b + 2 * c + n
                        .Mp(8) = g1
                        .Zp(8) = g1 / inc
                        .Mp(5) = g
                        .Zp(5) = g / inc
                        .Mp(9) = 0
                        .Zp(9) = 0
                        .Mp(3) = 0
                        .Zp(3) = 0
                        .Mp(4) = 0
                        .Zp(4) = 0
                        .AzzeraImposti()
                        .OptimTir()
                        'SpessoreMinimo
                        If .qbflan = -99 Then
                            GoTo FinePrematura
                        End If
                        If .Mp(9) + .Mp(10) < hLoc Then hLoc = .Mp(9) + .Mp(10)
                        Check()
                        cB = .Mp(4)
                        DF = .Mp(15)
                        Gmaxa = cB - DF - n ' - 15
                        If Gmaxa < g + 10 Then Gmaxa = g + 10
                        tLoc = 1.0E+20
                        Gmina = g + 5
                        Gmin = Int(Gmina + Gactorg1 * (Gmaxa - Gmina))
                        Gmax = Int(Gmaxa - Gactorg2 * (Gmaxa - Gmina))
                        Gstep = Int((Gmax - Gmin) / 5) + 1
                        Gmax = Gmin + 6 * Gstep
                        For g = Gmin To Gmax Step Gstep
                            .Mp(5) = g
                            .Zp(5) = g / inc
                            .Mp(9) = 0
                            .Zp(9) = 0
                            .Mp(3) = 0
                            .Zp(3) = 0
                            .Mp(4) = 0
                            .Zp(4) = 0
                            .AzzeraImposti()
                            .OptimTir()
                            'SpessoreMinimo
                            If .qbflan = -99 Then Exit Sub
                            If .Mp(9) + .Mp(10) < hLoc Then hLoc = .Mp(9) + .Mp(10)
                            If .Mp(9) > tLoc Then
                                Iter = Iter + Int((Gmax - g) / Gstep) + 1
                                Gactorg2 = (Gmax - g) / 4 / (Gmax - Gmin)
                                Exit For
                            End If
                            tLoc = .Mp(9)
                            Check()
                            Iter = Iter + 1
                            Monitor.Motore.Avanzamento = 100.0# * Iter / nIter
                            System.Windows.Forms.Application.DoEvents()
                            If InterrompiMAWP Then Exit For
                        Next
                        If InterrompiMAWP Then GoTo FinePrematura
                    Next
                    If hLoc > hTot Then
                        Iter = Iter + 36 * Int((hHub1 - hHub) / hHub2)
                        Monitor.Motore.Avanzamento = 100.0# * Iter / nIter
                        hHub1 = hHub
                        Exit For
                    End If
                    hTot = hLoc
                    If InterrompiMAWP Then GoTo FinePrematura
                Next
                hHub0 = Int(hHub0 + (hOpt - hHub0) / 4)
                hHub1 = Int(hHub1 + (hOpt - hHub1) / 4)
                hHub2 = Int((hHub1 - hHub0) / 5) + 1
                hHub1 = hHub0 + 6 * hHub2
                Factorg1 = (g1Opt - g10) / 4 / (g11 - g10)
                Factorg2 = (g11 - g1Opt) / 4 / (g11 - g10)
                Gactorg1 = (GOpt - Gmin) / 4 / (Gmax - Gmin)
                Gactorg2 = (Gmax - GOpt) / 4 / (Gmax - Gmin)
                Monitor.Motore.Avanzamento = 101
                Monitor.Motore.ProgrAmmazza()
                System.Windows.Forms.Application.DoEvents()
                If InterrompiMAWP Then GoTo FinePrematura
            Next
            .Mp(8) = g1Opt
            .Zp(8) = g1Opt / inc
            .Mp(5) = GOpt
            .Zp(5) = GOpt / inc
            .Mp(9) = 0
            .Zp(9) = 0
            .Mp(10) = hOpt
            .Zp(10) = hOpt / inc
            .Mp(3) = 0
            .Zp(3) = 0
            .Mp(4) = 0
            .Zp(4) = 0
            .AzzeraImposti()
            .OptimTir()
            Exit Sub
FinePrematura:
            Monitor.Motore.Avanzamento = 101
            Monitor.Motore.ProgrAmmazza()
            .Mp(8) = g1Opt
            .Zp(8) = g1Opt / inc
            .Mp(10) = hOpt
            .Zp(10) = hOpt / inc
            .Mp(5) = GOpt
            .Zp(5) = GOpt / inc
            If .qbflan > -99 Then
                .Mp(9) = 0
                .Zp(9) = 0
                .Mp(3) = 0
                .Zp(3) = 0
                .Mp(4) = 0
                .Zp(4) = 0
                .AzzeraImposti()
                .OptimTir()
            Else
                .Mp(9) = mp9
                .Mp(3) = mp3
                .Mp(4) = mp4
            End If
            'SpessoreMinimo
            .SuperOtt = False
        End With
        Exit Sub
    End Sub
    Private Sub Check()
        With O
            Merito = (.Mp(3) ^ 2 - .Mp(6) ^ 2) * (.Mp(9) + .Mp(10))
            If Merito < MerOpt Then
                MerOpt = Merito
                hOpt = hHub
                GOpt = g
                g1Opt = g1
            End If
        End With
    End Sub
    Public Sub Text_Changed(ByVal Nome As String)
        Dim s() As String = Nome.Split(CChar("_"))
        Dim Textnum As String = s(1)
        Dim Index As Short = CShort(s(2))
        Dim indice As Short
        Dim Cod As String
        If Not Valore(Index).Enabled Then Exit Sub
        Try
            With O
                If Not ScrivendoValore Then Carica(pagpag + .Mem.File, Index)
                indice = .PosVARIp(Index + .WWW)
                ' If Not NonAzzerare Then .AzzeraImposti()
                If .LoadCond = 1 Then
                    Select Case indice
                        Case 22, 23 : indice = 172
                        Case 24, 25
                            If Not (O.Mem.LOOSE = 5 Or O.Mem.LOOSE = 6) Then indice = 171
                        Case 34 : indice = 194
                        Case 33 : indice = 193
                        Case 122, 123 : indice = 181
                        Case 141, 142 : indice = indice + 179 - 141
                    End Select
                ElseIf .LoadCond = 2 Then
                    Select Case indice
                        Case 22, 23 : indice = indice + 175 - 22
                        Case 24, 25
                            If Not (O.Mem.LOOSE = 5 Or O.Mem.LOOSE = 6) Then indice = indice + 173 - 24
                        Case 122, 123 : indice = indice + 177 - 122
                        Case 141, 142 : indice = indice + 179 - 141
                    End Select
                End If
                Cod = UCase(Trim(.CVARIp(Index + .WWW)))
                If Len(Cod) > 1 Then
                    If InStr(Cod, "*") > 0 Then
                        Cod = VB.Left(Cod, 1)
                    Else
                        Cod = Mid(Cod, 2, 1)
                    End If
                End If
                Select Case Cod
                    Case "A"
                        .Zp(indice) = GlobalRoutines.ValVir(Valore(Index).Text)
                        .Mp(indice) = GlobalRoutines.ValVir(Valore(Index).Text) / psi
                    Case "B"
                        .Zp(indice) = GlobalRoutines.ValVir(Valore(Index).Text)
                        .Mp(indice) = (Val(Valore(Index).Text) - 32) / 1.8
                    Case "C"
                        .Zp(indice) = GlobalRoutines.ValVir(Valore(Index).Text) / inc
                        .Mp(indice) = GlobalRoutines.ValVir(Valore(Index).Text)
                    Case "S"
                        .Mem.TIR = Valore(Index).Text
                    Case "D"
                        .Mp(indice) = GlobalRoutines.ValVir(Valore(Index).Text)
                        .Zp(indice) = GlobalRoutines.ValVir(Valore(Index).Text) * psi
                    Case "E"
                        .Mp(indice) = GlobalRoutines.ValVir(Valore(Index).Text)
                        .Zp(indice) = GlobalRoutines.ValVir(Valore(Index).Text) * 1.8 + 32
                    Case "F"
                        .Zp(indice) = GlobalRoutines.ValVir(Valore(Index).Text) 'libbre
                        .Mp(indice) = GlobalRoutines.ValVir(Valore(Index).Text) * NIUT
                    Case "G"
                        .Zp(indice) = GlobalRoutines.ValVir(Valore(Index).Text) / inc ^ 2 'area
                        .Mp(indice) = GlobalRoutines.ValVir(Valore(Index).Text)
                    Case "H"
                        .Zp(indice) = GlobalRoutines.ValVir(Valore(Index).Text) / inc ^ 3 'mm^3
                        .Mp(indice) = GlobalRoutines.ValVir(Valore(Index).Text)
                    Case "I"
                        .Zp(indice) = GlobalRoutines.ValVir(Valore(Index).Text) * inc '1/mm
                        .Mp(indice) = GlobalRoutines.ValVir(Valore(Index).Text)
                    Case "J"
                        .Zp(indice) = GlobalRoutines.ValVir(Valore(Index).Text) 'lb.in
                        .Mp(indice) = GlobalRoutines.ValVir(Valore(Index).Text) * NIUT * inc
                    Case "K"
                        .Zp(indice) = GlobalRoutines.ValVir(Valore(Index).Text)
                        .Mp(indice) = GlobalRoutines.ValVir(Valore(Index).Text) * inc
                    Case "N"
                        .Zp(indice) = GlobalRoutines.ValVir(Valore(Index).Text)
                        .Mp(indice) = GlobalRoutines.ValVir(Valore(Index).Text)
                    Case Else ' .Zp(indice) = GlobaLroutines.ValVir(Valore(Index))
                End Select
            End With
        Catch e As Exception
            MessageBox.Show(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Private Function CercaRiga(ByRef PosVar As Short) As Short
        Dim i As Short
        With O
            For i = .WWW To .FFF
                If .PosVARIp(i) = PosVar Then
                    CercaRiga = i - .WWW
                    Exit Function
                End If
            Next
            CercaRiga = -1
        End With
    End Function
    Public Sub VerifErr()
        Dim i As Short
        Dim NonVal, Log1 As Boolean
        Dim n As Short
        With O
            NonValido.Visible = False
            cmdOk.Enabled = True
            .Mem.Conforme = "SI"
            If .pagina > 1 Then
                For i = .WWW To .FFF
                    .Ind = i
                    n = InStr(.CVARIp(.Ind), "*")
                    If n > 0 Then .CVARIp(.Ind) = VB.Left(.CVARIp(.Ind), n - 1)
                Next
            End If
            'ERRORI FLANGIA
            If .Mem.LOOSE = -1 Or .Mem.LOOSE = 2 Then
                If .pagina = 7 And .Zp(82) + .Zp(11) > .Zp(9) And .Mp(195) = 1 Then VerNonVal()
                If .pagina = 7 And .Zp(78) > .Zp(23) And .Mp(195) = 0 Then VerNonVal()
                If .pagina = 2 And (((.Zp(16) > .Zp(17)) And .Zp(17) <> 0) Or ((.Zp(18) > .Zp(19)) And .Zp(19) <> 0) Or ((.Zp(20) > .Zp(21)) And .Zp(21) <> 0)) Then
                    VerNonVal()
                End If
                Error1()
            ElseIf .Mem.LOOSE = 5 Then
                If .pagina = 7 Then
                    If NonVal Then VerNonVal()
                End If
            ElseIf .Mem.LOOSE = 6 Then
                If .pagina = 6 Then
                    If NonVal Then VerNonVal()
                End If
            Else
                If (.pagina = 9 And .Mem.LOOSE < 7) Or (.Mem.LOOSE = 7 And .pagina = 10) Then
                    If NonVal Then VerNonVal()
                End If
                If .pagina = 2 And (((.Zp(16) > .Zp(17)) And .Zp(17) <> 0) Or ((.Zp(18) > .Zp(19)) And .Zp(19) <> 0) Or ((.Zp(20) > .Zp(21)) And .Zp(21) <> 0)) Then
                    VerNonVal()
                End If
                Error1()
            End If
            'ERRORI COPERCHIO PIANO
            If .Mem.File = ".wnf" Or .Mem.File = ".ljf" Or .Mem.File = ".cob" Then Exit Sub
            If .Mp(128) > .Mp(119) Then
                VerNonVal()
                .Ind = .IndPos(119)
                n = InStr(.CVARIp(.Ind), "*")
                If n = 0 Then .CVARIp(.Ind) = .CVARIp(.Ind) + "*"
            End If
            If .Zp(119) <> 0 And .PosVARIp(i) = 119 Then
                Log1 = (.Zp(119) < .Zp(128))
                If .Mp(121) > 0 Then 'prof.cava>0
                    If .Mp(30) <= 3.0! Then
                        Log1 = Log1 Or (.Zp(119) < .Zp(132))
                    Else
                        Log1 = Log1 Or (.Zp(119) < .Zp(131))
                    End If
                End If
                If Log1 Then VerNonVal()
            End If
            If .Mem.Conforme = "NO" Then cmdOk.Enabled = False
            Exit Sub
        End With
    End Sub
    Private Sub Error1()
        Dim n As Integer
        With O
            If .pagina = 3 And .CRUSH And (.Mp(27) > .Mp(26) And .Mp(27) <> 0) Then
                VerNonVal()
                .Ind = .IndPos(27)
                n = InStr(.CVARIp(.Ind), "*")
                If n = 0 Then .CVARIp(.Ind) = .CVARIp(.Ind) + "*"
            End If
            If .pagina = 5 And (.Zp(45) > .Zp(46) And .Zp(45) <> 0) Then
                VerNonVal()
                .Ind = .IndPos(48)
                n = InStr(.CVARIp(.Ind), "*")
                If n = 0 Then .CVARIp(.Ind) = .CVARIp(.Ind) + "*"
            End If
        End With
    End Sub
    Private Sub VerNonVal()
        With O
            NonValido.Visible = True
            .Mem.Conforme = "NO"
            If .TipCalc = 3 And Stadio = 1 Then Stadio = 0
            If .TipCalc = 3 And Stadio = 2 Then Stadio = 1
        End With
    End Sub
    Sub Sub1720(ByRef Ind As Short)
        Dim IndLoc, Log1, k As Short
        With O
            IndLoc = Ind - .WWW
            k = 0
            Try
                HelpProvider1.SetShowHelp(Opt(IndLoc + k * 20), False)
                HelpProvider1.SetHelpNavigator(Opt(IndLoc + k * 20), HelpNavigator.Topic)
                If .TVARIp(Ind) = "C" Or .TVARIp(Ind) = "X" Then
                    Opt(IndLoc + k * 20).Visible = True
                    Opt(IndLoc + k * 20).Text = "UniMis"
                    Opt(IndLoc + k * 20).Tag = "0"
                    HelpProvider1.SetHelpKeyword(Opt(IndLoc + k * 20), "GrFucPag3.htm#6020")
                    HelpProvider1.SetShowHelp(Opt(IndLoc + k * 20), True)
                    ToolTip1.SetToolTip(Opt(IndLoc + k * 20), "Cambia le unità di misura di temperature e pressioni")
                    k = 1
                End If
                Log1 = (.Mem.LOOSE < 5 Or .Mem.LOOSE > 6)
                If .PosVARIp(Ind) = 28 And Log1 Then
                    Opt(IndLoc + k * 20).Visible = True
                    Opt(IndLoc + k * 20).Text = "Guarn."
                    Opt(IndLoc + k * 20).Tag = "1"
                    HelpProvider1.SetHelpKeyword(Opt(IndLoc + k * 20), Monitor.HelpTopic("6021"))
                    HelpProvider1.SetShowHelp(Opt(IndLoc + k * 20), True)
                    ToolTip1.SetToolTip(Opt(IndLoc + k * 20), "Richiama la libreria delle guarnizioni")
                    k = 1
                ElseIf .PosVARIp(Ind) = 9 Then  'ricerca prova idr.
                    Opt(IndLoc + k * 20).Visible = True
                    Opt(IndLoc + k * 20).Text = "Sp.min."
                    Opt(IndLoc + k * 20).Tag = "2"
                    HelpProvider1.SetHelpKeyword(Opt(IndLoc + k * 20), "GrFucPag1.htm#Spmin")
                    HelpProvider1.SetShowHelp(Opt(IndLoc + k * 20), True)
                    ToolTip1.SetToolTip(Opt(IndLoc + k * 20), "Calcola lo spessore minimo richiesto per il fucinato")
                    k = 1
                ElseIf .PosVARIp(Ind) = 32 And Log1 Then  'traversini
                    Opt(IndLoc + k * 20).Visible = True
                    Opt(IndLoc + k * 20).Text = "Travers."
                    Opt(IndLoc + k * 20).Tag = "3"
                    HelpProvider1.SetHelpKeyword(Opt(IndLoc + k * 20), "GrFucPag4.htm")
                    HelpProvider1.SetShowHelp(Opt(IndLoc + k * 20), True)
                    ToolTip1.SetToolTip(Opt(IndLoc + k * 20), "Permette di specificare la geometria dei traversini")
                    k = 1
                ElseIf .PosVARIp(Ind) = 12 And Log1 Then  'ottimizzazione tiranti
                    Opt(IndLoc + k * 20).Visible = True
                    Opt(IndLoc + k * 20).Text = "OptimTir"
                    Opt(IndLoc + k * 20).Tag = "4"
                    HelpProvider1.SetShowHelp(Opt(IndLoc + k * 20), True)
                    HelpProvider1.SetHelpKeyword(Opt(IndLoc + k * 20), "GrFucPag2.htm#OptimTir")
                    ToolTip1.SetToolTip(Opt(IndLoc + k * 20), "Calcola il numero e diametro dei tiranti che minimizza il diametro esterno del flangione")
                    k = 1
                    Opt(IndLoc + k * 20).Visible = True
                    Opt(IndLoc + k * 20).Text = "Libr.Tir"
                    Opt(IndLoc + k * 20).Tag = "7"
                    HelpProvider1.SetShowHelp(Opt(IndLoc + k * 20), True)
                    HelpProvider1.SetHelpKeyword(Opt(IndLoc + k * 20), "GrFucPag2.htm#LibrTir")
                    ToolTip1.SetToolTip(Opt(IndLoc + k * 20), "Richiama la libreria dei tiranti")
                ElseIf .PosVARIp(Ind) = 13 And Log1 Then  'massimizzazione tiranti
                    Opt(IndLoc + k * 20).Visible = True
                    Opt(IndLoc + k * 20).Text = "MaxTir"
                    Opt(IndLoc + k * 20).Tag = "5"
                    HelpProvider1.SetShowHelp(Opt(IndLoc + k * 20), True)
                    HelpProvider1.SetHelpKeyword(Opt(IndLoc + k * 20), "GrFucPag2.htm#MaxTir")
                    ToolTip1.SetToolTip(Opt(IndLoc + k * 20), "Calcola il numero massimo di tiranti che possono essere istallati nel cerchio dato")
                    k = 1
                ElseIf .PosVARIp(Ind) >= 22 And .PosVARIp(Ind) <= 25 Or .PosVARIp(Ind) = 122 Or .PosVARIp(Ind) = 123 Or .PosVARIp(Ind) = 141 Or .PosVARIp(Ind) = 142 Then
                    If Not (O.Mem.LOOSE = 5 Or O.Mem.LOOSE = 6) Then
                        Opt(IndLoc + k * 20).Visible = True
                        Opt(IndLoc + k * 20).Text = "Ammiss."
                        Opt(IndLoc + k * 20).Tag = "6"
                        HelpProvider1.SetHelpKeyword(Opt(IndLoc + k * 20), Monitor.HelpTopic("6027"))
                        HelpProvider1.SetShowHelp(Opt(IndLoc + k * 20), True)
                        ToolTip1.SetToolTip(Opt(IndLoc + k * 20), "Calcola le tensioni ammissibili")
                        k = 1
                    End If
                ElseIf .PosVARIp(Ind) = 125 And .Mem.LOOSE = 2 And .Mp(195) > 0 Then  'ottimizzazione hr per fl.fl.
                    Opt(IndLoc + k * 20).Visible = True
                    Opt(IndLoc + k * 20).Text = "Ottim."
                    Opt(IndLoc + k * 20).Tag = "8"
                    HelpProvider1.SetHelpKeyword(Opt(IndLoc + k * 20), "")
                    HelpProvider1.SetShowHelp(Opt(IndLoc + k * 20), True)
                    ToolTip1.SetToolTip(Opt(IndLoc + k * 20), "Calcola l'impostazione ottimale della calotta sferica sul flangione del fondo flottante")
                    k = 1
                ElseIf .pagina = 5 And (.Zp(33) = 0 Or .Zp(34) = 0) And Log1 Then
                End If
            Catch e As Exception
                MessageBox.Show(e.Message + vbCrLf + e.StackTrace)
            End Try
        End With
    End Sub
    Public Sub ScriviValore(ByRef indice As Short, ByRef i As Short)
        Dim PosIndice, n As Short
        Dim b As Boolean
        NonAzzerare = True
        '        ScrivendoValore = True
        With O
            PosIndice = .PosVARIp(indice)
            n = 2 : b = False
            If InStr(.CVARIp(indice), "N") > 0 And Not PosIndice = 30 Then
                n = 5 : b = False
            End If
            If .LoadCond = 1 Then
                Select Case PosIndice
                    Case 22, 23 : PosIndice = 172
                    Case 24, 25
                        If Not (O.Mem.LOOSE = 5 Or O.Mem.LOOSE = 6) Then PosIndice = 171
                    Case 34 : PosIndice = 194
                    Case 33 : PosIndice = 193
                    Case 122, 123 : PosIndice = 181
                    Case 141, 142 : PosIndice = PosIndice + 179 - 141
                End Select
            ElseIf .LoadCond = 2 Then
                Select Case PosIndice
                    Case 22, 23 : PosIndice = PosIndice + 175 - 22
                    Case 24, 25
                        If Not (O.Mem.LOOSE = 5 Or O.Mem.LOOSE = 6) Then PosIndice = PosIndice + 173 - 24
                    Case 122, 123 : PosIndice = PosIndice + 177 - 122
                    Case 141, 142 : PosIndice = PosIndice + 179 - 141
                End Select
            End If
            Select Case .TVARIp(indice)
                Case "A", "N"
                    Valore(i).Text = GlobalRoutines.myStr(.Mp(PosIndice), 10, n, b)
                Case "X"
                    Valore(i).Text = GlobalRoutines.myStr(.Mp(PosIndice), 10, n, b)
                Case "B"
                    Valore(i).Text = GlobalRoutines.myStr(.Zp(PosIndice), 10, n, b)
                Case "C"
                    Valore(i).Text = GlobalRoutines.myStr(.Zp(PosIndice), 10, n, b)
                Case "S"
                    Valore(i).Text = .Mem.TIR
                Case "D"
                    Valore(i).Text = GlobalRoutines.myStr(.Zp(PosIndice), 10, n, b)
                Case "E"
                    Valore(i).Text = GlobalRoutines.myStr(.Zp(PosIndice), 10, n, b)
            End Select
        End With
        NonAzzerare = False
    End Sub

    Private Sub Visibile(ByRef i As Short, ByRef b As Boolean)
        Dim iRiga As Short
        Try
            If Not Valore(i) Is Nothing Then
                Variabile(i).Visible = b
                Descrizione(i).Visible = b
                Dimensioni(i).Visible = b
                Valore(i).Visible = b
                iRiga = CercaRiga(29) 'nubbin
                With O
                    If iRiga > -1 Then
                        If .Zp(31) = 2 Or .Zp(31) = 3 Or .Zp(31) = 4 Then
                            If .Mp(29) = 0 Then
                                .Mp(29) = 3
                                .Zp(29) = .Mp(29) / inc
                                Variabile(iRiga).Visible = True
                                Descrizione(iRiga).Visible = True
                                Dimensioni(iRiga).Visible = True
                                Valore(iRiga).Visible = True
                            End If
                        Else
                            .Mp(29) = 0
                            .Zp(29) = 0
                            Variabile(iRiga).Visible = False
                            Descrizione(iRiga).Visible = False
                            Dimensioni(iRiga).Visible = False
                            Valore(iRiga).Visible = False
                        End If
                    End If
                End With
            End If
            If Not b Then
                If Not Opt(i) Is Nothing Then
                    Opt(i).Visible = b
                    'Opt.UnLoad(i)
                End If
                If Not Opt(i + 20) Is Nothing Then
                    Opt(i + 20).Visible = b
                    'Opt.UnLoad(i + 20)
                End If
            End If
        Catch e As Exception
            MessageBox.Show(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub

    Public Sub CalcAutom()
        If Config(0).CalcPI = 1 Then
            cmdCliccato = False
            cmdCalc_Click(cmdCalc, New System.EventArgs)
        Else
            cmdPIDes_Click(cmdPIDes, New System.EventArgs)
        End If
    End Sub
    Public Sub Text_Enter(ByVal Nome As String)
        Dim s() As String = Nome.Split(CChar("_"))
        Dim Textnum As String = s(1)
        Dim Index As Short = CShort(s(2))
        With O
            indiceMon = .PosVARIp(Index + .WWW)
            ValMon = GlobalRoutines.ValVir(Valore(Index).Text)
        End With
    End Sub
    Public Sub Text_Leave(ByVal Nome As String)
        Dim s() As String = Nome.Split(CChar("_"))
        Dim Textnum As String = s(1)
        Dim Index As Short = CShort(s(2))
        Dim indice As Short
        With O
            indice = .PosVARIp(Index + .WWW)
            If indice = indiceMon Then
                If GlobalRoutines.ValVir(Valore(Index).Text) <> ValMon Then
                    Select Case indice
                        Case 1 To 15, 186, 22 To 26, 28 To 30, 32
                            .AzzeraImposti()
                    End Select
                End If
            End If
        End With
        indiceMon = -1
    End Sub
    Private Sub SpessoreMinimo()
        Dim icount As Short
        Dim SpessV As Single
        With O
            ' Modifica = True
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto O.Mp. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            .Mp(9) = 0
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto O.Zp. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            .Zp(9) = 0
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto O.qbflan. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            .qbflan = 0
            '        Debug.Print .LoadCond
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto O.LoadCond. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto O.Carichi. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            .Carichi(.LoadCond, 0)
            Do
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto O.Mp. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                SpessV = .Mp(9) : icount = icount + 1
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto O.Calcola. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                Call .Calcola()
                If .qbflan = -99 Then
                    .GiaCalc = False : Exit Sub
                End If
            Loop While .qbflan = 4 Or System.Math.Abs(SpessV - .Mp(9)) > 1 And icount < 10
            .GiaCalc = .Calcolo
            If Not .qbflan = 1 And Not .SuperOtt Then
                .pagina = 1
                Call SetPagina(1)
            End If
        End With
    End Sub
    Private Sub AggiornaAmmiss(ByRef Ind As Short, ByRef Forza As Boolean)
        Dim indice As Short
        Dim Sba, sbo As Single
        Dim sca, Sco As Single
        Dim Sna, Sno As Single
        Dim Sfa, Sfo As Single
        With O
            indice = .PosVARIp(Ind)
            'i seguenti cinque erano remmati
            .Mp(171) = 0
            .Mp(172) = 0
            .Mp(173) = 0
            .Mp(174) = 0
            .Mp(175) = 0
            .Mp(176) = 0
            .Mp(177) = 0
            .Mp(178) = 0
            .Mp(181) = 0
            'in zero va l'nn del bocchello
            .Ammiss(kNozzle, Sfa, Sfo, Sba, sbo, sca, Sco, Sna, Sno, indice, True, Forza)
            If .LoadCond = 1 Then
                Select Case indice
                    Case 22, 23 : indice = 172
                    Case 24, 25
                        If Not (O.Mem.LOOSE = 5 Or O.Mem.LOOSE = 6) Then indice = 171
                    Case 122, 123 : indice = 181
                    Case 141, 142 : indice = indice + 179 - 141
                End Select
            ElseIf .LoadCond = 2 Then
                Select Case indice
                    Case 22, 23 : indice = indice + 175 - 22
                    Case 24, 25
                        If Not (O.Mem.LOOSE = 5 Or O.Mem.LOOSE = 6) Then indice = indice + 173 - 24
                    Case 122, 123 : indice = indice + 177 - 122
                    Case 141, 142 : indice = indice + 179 - 141
                End Select
            End If
            Select Case indice
                Case 172
                    .Mp(indice) = Sfa
                    .Zp(indice) = .Mp(indice) / mpa
                Case 171
                    .Mp(indice) = Sba
                    .Zp(indice) = .Mp(indice) / mpa
                Case 181
                    .Mp(indice) = sca
                    .Zp(indice) = .Mp(indice) / mpa
                Case 175, 176
                    .Mp(175) = Sfa
                    .Zp(175) = .Mp(175) / mpa
                    .Mp(176) = Sfo
                    .Zp(176) = .Mp(176) / mpa
                Case 173, 174
                    .Mp(173) = Sba
                    .Zp(173) = .Mp(173) / mpa
                    .Mp(174) = sbo
                    .Zp(174) = .Mp(174) / mpa
                Case 141
                    .Mp(141) = Sna
                    .Zp(141) = .Mp(141) / mpa
                    .Mp(142) = Sno
                    .Zp(142) = .Mp(142) / mpa
                Case 177, 178
                    .Mp(177) = sca
                    .Zp(177) = .Mp(177) / mpa
                    .Mp(178) = Sco
                    .Zp(178) = .Mp(178) / mpa
                Case 179, 180
                    .Mp(179) = Sna
                    .Zp(179) = .Mp(179) / mpa
                    .Mp(180) = Sno
                    .Zp(180) = .Mp(180) / mpa
            End Select
        End With
    End Sub
    Private Sub SupAggiornaAmmiss()
        If O.Mem.LOOSE = 5 Or O.Mem.LOOSE = 6 Then
            AggiornaAmmiss(13, False)
        ElseIf O.Mem.LOOSE = 4 And Compensazione Then
            AggiornaAmmiss(30, False)
        Else
            AggiornaAmmiss(23, False)
            AggiornaAmmiss(25, False)
        End If
    End Sub

    Private Sub Attivazione()
        Finito = False
        If Compensazione Then
            optOptim.Visible = False
            Exit Sub
        End If
        NonAzzerare = True
        SupAggiornaAmmiss()
        With O
            Select Case VisualTipo
                Case 0 : TipoCalc.Visible = False
                Case 1 : TipoCalc.Visible = True
                    TipoCalc.Text = "Calcolo a pressione interna"
                Case 2 : TipoCalc.Visible = True
                    TipoCalc.Text = "Calcolo a pressione esterna"
                    .pagina = 1
            End Select
            If .TipCalc = 3 Or VerificandoPI Then
                If VisualTipo < 2 Then If Not .RilBull0 Then cmdCancel_Click(cmdCancel, New System.EventArgs)
                If VerificandoPI Then
                    TipoCalc.Text = "Verifiche di resistenza in P.I."
                Else
                    If Stadio = 0 Then TipoCalc.Text = "Calcolo in prova idraulica"
                    If Stadio >= 1 Then TipoCalc.Text = "Calcolo a pressione di progetto"
                End If
                cmdPIDes.Visible = False
                cmdRota.Visible = False
                cmdAperture.Visible = False
                cmdCalc.Text = "Calcola"
                HelpProvider1.SetHelpNavigator(cmdCalc, HelpNavigator.Topic)
                HelpProvider1.SetHelpKeyword(cmdCalc, Monitor.HelpTopic(6032))
                HelpProvider1.SetShowHelp(cmdCalc, True)
            Else
                .Carichi(2, 0) '.LoadCond = 2
            End If
            optOptim.Visible = .TipCalc = 1 And (.Mem.LOOSE = 0 Or .Mem.LOOSE = 3) And jInvolucr > 0
        End With
        NonAzzerare = False
    End Sub
    Private Sub AccoppPT(ByRef k As Short, ByRef j As Short)
        Dim Tuttok, TuttokPI As Boolean
        Dim Max2, Max1 As Single
        Dim Primo, Secon As Boolean
        Dim iPr As Short
        AccoppiatoPT = objMemb(Involucr(k, j).IndObject)
        Dim CalcolatoAccoppiato As Boolean = AccoppiatoPT.FlDati(16) > 0
        If CalcolatoAccoppiato Then
            Tuttok = Uguale(Fatto.Zp(33), AccoppiatoPT.FlDati(15))
            Tuttok = Tuttok And Uguale(Fatto.Zp(34), AccoppiatoPT.FlDati(16))
            If Not Tuttok Then
                Max1 = Fatto.Zp(33)
                If Fatto.Zp(40) > Max2 Then Max2 = Fatto.Zp(40)
                If AccoppiatoPT.FlDati(15) > Max2 Then Max2 = AccoppiatoPT.FlDati(15)
                Max2 = Fatto.Zp(34)
                If Fatto.Zp(41) > Max2 Then Max2 = Fatto.Zp(41)
                If AccoppiatoPT.FlDati(16) > Max2 Then Max2 = AccoppiatoPT.FlDati(16)
            End If
            'TuttokPI = True
            'If Config(0).CalcPI = 1 Then
            'TuttokPI = Uguale(Fatto.Zp(194), AccoppiatoPT.FlDati(18))
            'If Not TuttokPI Then
            '     Max2PI = Fatto.Zp(194)
            '      If AccoppiatoPT.FlDati(18) > Max2PI Then Max2PI = AccoppiatoPT.FlDati(18)
            '   End If
            'End If
            If Not Tuttok Then
                Primo = Fatto.Zp(33) < Max1 Or Fatto.Zp(34) < Max2
                Secon = AccoppiatoPT.FlDati(15) < Max1 Or AccoppiatoPT.FlDati(16) < Max2
                iPr = 2
                If Primo Or Secon Then
                    WarnWm1(Primo, Secon, k, j, iPr)
                    If Primo Then
                        Fatto.Mp(33) = Max1 * NIUT : Fatto.Mp(34) = Max2 * NIUT
                        Fatto.Zp(33) = Max1 : Fatto.Zp(34) = Max2
                    ElseIf Secon Then
                        AccoppiatoPT.FlDati(15) = Max1
                        AccoppiatoPT.FlDati(16) = Max2
                    End If
                End If
            End If
            '            If Not TuttokPI Then
            'Primo = Fatto.Zp(194) < Max2PI
            'Secon = AccoppiatoPT.FlDati(18) < Max2PI
            'iPr = 1
            ' If Primo Or Secon Then
            '  WarnWm1(Primo, Secon, k, j, iPr)
            '   If Primo Then
            '        Fatto.Zp(194) = Max2PI
            '     ElseIf Secon Then
            '          AccoppiatoPT.FlDati(18) = Max2PI
            '       End If
            '    End If
            'End If
        Else
            Primo = True
            WarnWm1(Primo, Secon, k, j, 3)
            If Not Primo Then Exit Sub
        End If
    End Sub
    Private Sub WarnWm1(ByRef Primo As Boolean, ByRef Secon As Boolean, ByVal k As Short, ByVal j As Short, ByVal iPr As Short)
        Dim uu As String
        Dim Testo As String = ""
        Dim Aiuto As String = ""
        Dim Strin(3) As String
        Strin(1) = " in prova idraulica.|"
        Strin(2) = " in esercizio.|"
        Strin(3) = "|"
        Dim i33 As Short = 33
        Dim i34 As Short = 34
        Dim i40 As Short = 40
        Dim i41 As Short = 41
        Dim Codici As ChiaviMess = ChiaviMess.MessYesNo Or ChiaviMess.MessQuestion Or ChiaviMess.MessHelpButton
        If iPr = 1 Then
            i40 = 193
            i41 = 194
        End If
        If iPr = 3 Then
            Testo = "La membratura " & Involucr(k, j).Mark.Trim & ", accoppiata alla memmbratura|"
            Testo = Testo & "appena calcolata, non risulta essere stata ancora calcolata,|"
            Testo = Testo & "per quanto si evince dai valori sotto riportati.|"
            Aiuto = "AvvCaricoImposto.htm#MembrNonCalc"
        Else
            Codici = ChiaviMess.MessOkOnly Or ChiaviMess.MessInformation Or ChiaviMess.MessHelpButton
            Aiuto = "AvvCaricoImposto.htm#PrimoOrSecon"
            If Primo And Secon Then
                Testo = "La presente membratura " & Trim(Involucr(kLato, jInvolucr).Mark)
                Testo = Testo & "|e la membratura accoppiata " & Trim(Involucr(k, j).Mark)
                Testo = Testo & "|devono entrambe essere ricalcolate in quanto"
                Testo = Testo & "|il tiro Wm2 dei tiranti a comune non è congruente"
                Aiuto = "AvvCaricoImposto.htm#PrimoSecon"
            ElseIf Primo Then
                Testo = "La presente membratura " & Trim(Involucr(kLato, jInvolucr).Mark)
                Testo = Testo & "|deve essere ricalcolata in quanto il tiro"
                Testo = Testo & "|Wm2 dei tiranti a comune con la|membratura "
                Testo = Testo & Trim(Involucr(k, j).Mark) & " non corrisponde"
                Testo = Testo & "|al calcolo di quest'ultima "
            ElseIf Secon Then
                Testo = "La membratura " & Trim(Involucr(k, j).Mark)
                Testo = Testo & " deve essere|ricalcolata in quanto il tiro"
                Testo = Testo & "|Wm2 dei tiranti a comune con la presente|membratura "
                Testo = Testo & Trim(Involucr(kLato, jInvolucr).Mark) & " non corrisponde"
                Testo = Testo & "|al calcolo di quest'ultima "
            End If
        End If
        Testo = Testo & Strin(iPr) & "        (Valori in k" & UnitForce & ")|"
        Testo = Testo & "|          Membratura presente   Membratura accoppiata"
        Testo = Testo & "|Wm1 calc  " & GlobalRoutines.myStr(Fatto.Mp(i40) * kForce / 1000, 14, 1, 0) _
                                      & New String(" "c, 20) & "--" 'GlobalRoutines.myStr(Accoppiato.Mp(i40) * kForce / 1000, 20, 1, 0)
        If iPr > 1 Then _
        Testo = Testo & "|Wm1 imp.  " & GlobalRoutines.myStr(Fatto.Mp(i33) * kForce / 1000, 14, 1, 0) _
                                      & GlobalRoutines.myStr(AccoppiatoPT.FlDati(15) * NIUT * kForce / 1000, 20, 1, 0)
        Testo = Testo & "|Wm2 calc  " & GlobalRoutines.myStr(Fatto.Mp(i41) * kForce / 1000, 14, 1, 0) _
                                      & New String(" "c, 20) & "--" 'GlobalRoutines.myStr(Accoppiato.Mp(i41) * kForce / 1000, 20, 1, 0)
        If iPr > 1 Then _
        Testo = Testo & "|Wm2 imp.  " & GlobalRoutines.myStr(Fatto.Mp(i34) * kForce / 1000, 14, 1, 0) _
                                      & GlobalRoutines.myStr(AccoppiatoPT.FlDati(16) * NIUT * kForce / 1000, 20, 1, 0)
        uu = Testo
        If iPr = 3 Then
            Testo = Testo & "|Si vuole che sia corretto i dati della membratura da ricalcolare? "
            '   Testo = Testo & "|N.B.: Nell'affermativa saranno anche omogeneizzati i dati geometrici."
        ElseIf Primo And Secon Then
        Else
            Codici = ChiaviMess.MessYesNo Or ChiaviMess.MessQuestion Or ChiaviMess.MessHelpButton
            Testo = Testo & "|Si vuole che siano riportati i carichi imposti sulla membratura da ricalcolare? "
        End If
        Dim junk As ChiaviMess = ChiaviMess.Messno
        If Not ContinuoAuto Then
            junk = Monitor.Motore.Messaggio(clsInizio.ConvertiCr(Testo), _
                     Codici, _
                     "AsmeVip -" & Involucr(kLato, jInvolucr).Mark.Trim, RadiceHelp, Aiuto, True)
        Else
            junk = ChiaviMess.MessSi
            PrintlstRes(uu)
        End If
        If junk = ChiaviMess.Messno Then Primo = False : Secon = False
        If Primo And Secon Then Primo = False : Secon = False
    End Sub
    Private Sub frmTab_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Attivata()
    End Sub
    Private Sub Schedario_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Schedario.SelectedIndexChanged
        If Inizializzando Then Exit Sub
        With Schedario
            If Not .Enabled Then Exit Sub
            If .SelectedIndex + 1 = 1 And O.TipCalc = 1 And (O.Mem.LOOSE = 0 Or O.Mem.LOOSE = 3) _
            And jInvolucr > 0 And Not StoCalcolandoTutto Then
                optOptim.Visible = True
            Else
                optOptim.Visible = False
            End If
            If .Tag = "-1" Then Exit Sub
            O.pagina = .SelectedIndex + 1
            HelpProvider1.SetHelpNavigator(Schedario, HelpNavigator.Topic)
            HelpProvider1.SetHelpKeyword(Schedario, Monitor.HelpTopic(6000 + .SelectedIndex + 1))
            HelpProvider1.SetShowHelp(Schedario, True)
            HelpProvider1.SetHelpNavigator(Picture1, HelpNavigator.Topic)
            HelpProvider1.SetHelpKeyword(Picture1, Monitor.HelpTopic(6000 + .SelectedIndex + 1))
            HelpProvider1.SetShowHelp(Picture1, True)
        End With
        O.Carichi(O.LoadCond, 0)
        SetPagina(1)
    End Sub
End Class