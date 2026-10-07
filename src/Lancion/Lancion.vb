Option Strict On
Option Explicit On
Imports System.Diagnostics
Imports System.ComponentModel
Imports RoutBase1
Imports RoutBase1.clsInizio
Imports System.Data
Imports System.Data.OleDb
Friend Class Form1
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
    Public WithEvents Timer1 As System.Windows.Forms.Timer
    Public WithEvents Command3 As System.Windows.Forms.Button
    Public WithEvents Command2 As System.Windows.Forms.Button
    Public WithEvents cmdExit As System.Windows.Forms.Button
    Public WithEvents Text1 As System.Windows.Forms.TextBox
    Public WithEvents Combo1 As System.Windows.Forms.ComboBox
    Public mnuGuida As New System.Collections.Generic.Dictionary(Of Integer, ToolStripMenuItem)
    Public mnuStamLib As New System.Collections.Generic.Dictionary(Of Integer, ToolStripMenuItem)
    Public mnuTerm As New System.Collections.Generic.Dictionary(Of Integer, ToolStripMenuItem)
    Public mnuUltAgg As New System.Collections.Generic.Dictionary(Of Integer, ToolStripMenuItem)
    Public mnuUt As New System.Collections.Generic.Dictionary(Of Integer, ToolStripMenuItem)
    Public WithEvents _mnuTerm_0 As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents _mnuTerm_1 As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents _mnuTerm_2 As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents _mnuTerm_3 As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents _mnuTerm_4 As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents _mnuTerm_5 As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuTerm0 As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mecMantelli As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mecBocchelli As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mecSelle As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mecOrecchie As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mecSerraggio As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mecConi As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mecBreLoc As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuCalc As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuTracciature As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuPPSM As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuTrac As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents terPetrol As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents terAcqua As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuPPgas As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuVentilatori As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuTermo As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuMateriali As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuFlange As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuTiranti As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuPiping As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuGuarn As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuTubi As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuLibrerie As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuAree As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuTipLav As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuPW As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuPersAz As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents _mnuUltAgg_0 As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents _mnuUltAgg_1 As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuStdPip As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuOpzLibr As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuPref As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents _mnuUt_0 As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuASME As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents _mnuStamLib_0 As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents _mnuStamLib_1 As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuStamLibr As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuRegole As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuUt0 As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents _mnuGuida_0 As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents _mnuGuida_1 As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuGuide As System.Windows.Forms.ToolStripMenuItem
    Public MainMenu1 As System.Windows.Forms.MenuStrip
    'NOTA: la routine seguente è richiesta dalla progettazione Windows Form.
    'Può essere modificata utilizzando la finestra di progettazione Windows Form.
    'Non modificarla mediante l'editor di codice.
    Friend WithEvents mnuUtDis As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdAFC As System.Windows.Forms.Button
    Friend WithEvents cmdST As System.Windows.Forms.Button
    Friend WithEvents cmdWHB As System.Windows.Forms.Button
    Friend WithEvents cmdWPS As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents HelpProvider1 As System.Windows.Forms.HelpProvider
    Friend WithEvents mnuAvvio As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuItem4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuItem5 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuItem6 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuItem7 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuItem8 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuItem9 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuItem10 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuItem11 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuItem12 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuItem13 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuItem14 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuItem15 As System.Windows.Forms.ToolStripMenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Form1))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Command3 = New System.Windows.Forms.Button
        Me.Command2 = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.Text1 = New System.Windows.Forms.TextBox
        Me.Combo1 = New System.Windows.Forms.ComboBox
        Me.cmdAFC = New System.Windows.Forms.Button
        Me.cmdST = New System.Windows.Forms.Button
        Me.cmdWHB = New System.Windows.Forms.Button
        Me.cmdWPS = New System.Windows.Forms.Button
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me._mnuGuida_0 = New System.Windows.Forms.ToolStripMenuItem
        Me._mnuGuida_1 = New System.Windows.Forms.ToolStripMenuItem
        Me._mnuStamLib_0 = New System.Windows.Forms.ToolStripMenuItem
        Me._mnuStamLib_1 = New System.Windows.Forms.ToolStripMenuItem
        Me._mnuTerm_0 = New System.Windows.Forms.ToolStripMenuItem
        Me._mnuTerm_1 = New System.Windows.Forms.ToolStripMenuItem
        Me._mnuTerm_2 = New System.Windows.Forms.ToolStripMenuItem
        Me._mnuTerm_3 = New System.Windows.Forms.ToolStripMenuItem
        Me._mnuTerm_4 = New System.Windows.Forms.ToolStripMenuItem
        Me._mnuTerm_5 = New System.Windows.Forms.ToolStripMenuItem
        Me._mnuUltAgg_0 = New System.Windows.Forms.ToolStripMenuItem
        Me._mnuUltAgg_1 = New System.Windows.Forms.ToolStripMenuItem
        Me._mnuUt_0 = New System.Windows.Forms.ToolStripMenuItem
        Me.MainMenu1 = New System.Windows.Forms.MenuStrip
        Me.mnuTerm0 = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuCalc = New System.Windows.Forms.ToolStripMenuItem
        Me.mecMantelli = New System.Windows.Forms.ToolStripMenuItem
        Me.mecBocchelli = New System.Windows.Forms.ToolStripMenuItem
        Me.mecSelle = New System.Windows.Forms.ToolStripMenuItem
        Me.mecOrecchie = New System.Windows.Forms.ToolStripMenuItem
        Me.mecSerraggio = New System.Windows.Forms.ToolStripMenuItem
        Me.mecConi = New System.Windows.Forms.ToolStripMenuItem
        Me.mecBreLoc = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuTrac = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuTracciature = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuPPSM = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuTermo = New System.Windows.Forms.ToolStripMenuItem
        Me.terPetrol = New System.Windows.Forms.ToolStripMenuItem
        Me.terAcqua = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuPPgas = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuVentilatori = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuLibrerie = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuMateriali = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuFlange = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuTiranti = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuPiping = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuGuarn = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuTubi = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuPref = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuAree = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuTipLav = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuPW = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuPersAz = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuOpzLibr = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuStdPip = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuAvvio = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuUt0 = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuASME = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuStamLibr = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuRegole = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuUtDis = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuGuide = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuItem2 = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuItem3 = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuItem4 = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuItem5 = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuItem6 = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuItem7 = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuItem8 = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuItem9 = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuItem10 = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuItem11 = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuItem12 = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuItem13 = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuItem14 = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuItem15 = New System.Windows.Forms.ToolStripMenuItem
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.HelpProvider1 = New System.Windows.Forms.HelpProvider
        Me.SuspendLayout()
        '
        'Command3
        '
        Me.Command3.AccessibleDescription = resources.GetString("Command3.AccessibleDescription")
        Me.Command3.AccessibleName = resources.GetString("Command3.AccessibleName")
        Me.Command3.Anchor = CType(resources.GetObject("Command3.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.Command3.BackColor = System.Drawing.SystemColors.Control
        Me.Command3.BackgroundImage = CType(resources.GetObject("Command3.BackgroundImage"), System.Drawing.Image)
        Me.Command3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command3.Dock = CType(resources.GetObject("Command3.Dock"), System.Windows.Forms.DockStyle)
        Me.Command3.Enabled = CType(resources.GetObject("Command3.Enabled"), Boolean)
        Me.Command3.FlatStyle = CType(resources.GetObject("Command3.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.Command3.Font = CType(resources.GetObject("Command3.Font"), System.Drawing.Font)
        Me.Command3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.HelpProvider1.SetHelpKeyword(Me.Command3, resources.GetString("Command3.HelpKeyword"))
        Me.HelpProvider1.SetHelpNavigator(Me.Command3, CType(resources.GetObject("Command3.HelpNavigator"), System.Windows.Forms.HelpNavigator))
        Me.HelpProvider1.SetHelpString(Me.Command3, resources.GetString("Command3.HelpString"))
        Me.Command3.Image = CType(resources.GetObject("Command3.Image"), System.Drawing.Image)
        Me.Command3.ImageAlign = CType(resources.GetObject("Command3.ImageAlign"), System.Drawing.ContentAlignment)
        Me.Command3.ImageIndex = CType(resources.GetObject("Command3.ImageIndex"), Integer)
        Me.Command3.ImeMode = CType(resources.GetObject("Command3.ImeMode"), System.Windows.Forms.ImeMode)
        Me.Command3.Location = CType(resources.GetObject("Command3.Location"), System.Drawing.Point)
        Me.Command3.Name = "Command3"
        Me.Command3.RightToLeft = CType(resources.GetObject("Command3.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.HelpProvider1.SetShowHelp(Me.Command3, CType(resources.GetObject("Command3.ShowHelp"), Boolean))
        Me.Command3.Size = CType(resources.GetObject("Command3.Size"), System.Drawing.Size)
        Me.Command3.TabIndex = CType(resources.GetObject("Command3.TabIndex"), Integer)
        Me.Command3.Text = resources.GetString("Command3.Text")
        Me.Command3.TextAlign = CType(resources.GetObject("Command3.TextAlign"), System.Drawing.ContentAlignment)
        Me.ToolTip1.SetToolTip(Me.Command3, resources.GetString("Command3.ToolTip"))
        Me.Command3.Visible = CType(resources.GetObject("Command3.Visible"), Boolean)
        '
        'Command2
        '
        Me.Command2.AccessibleDescription = resources.GetString("Command2.AccessibleDescription")
        Me.Command2.AccessibleName = resources.GetString("Command2.AccessibleName")
        Me.Command2.Anchor = CType(resources.GetObject("Command2.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.Command2.BackColor = System.Drawing.SystemColors.Control
        Me.Command2.BackgroundImage = CType(resources.GetObject("Command2.BackgroundImage"), System.Drawing.Image)
        Me.Command2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command2.Dock = CType(resources.GetObject("Command2.Dock"), System.Windows.Forms.DockStyle)
        Me.Command2.Enabled = CType(resources.GetObject("Command2.Enabled"), Boolean)
        Me.Command2.FlatStyle = CType(resources.GetObject("Command2.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.Command2.Font = CType(resources.GetObject("Command2.Font"), System.Drawing.Font)
        Me.Command2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.HelpProvider1.SetHelpKeyword(Me.Command2, resources.GetString("Command2.HelpKeyword"))
        Me.HelpProvider1.SetHelpNavigator(Me.Command2, CType(resources.GetObject("Command2.HelpNavigator"), System.Windows.Forms.HelpNavigator))
        Me.HelpProvider1.SetHelpString(Me.Command2, resources.GetString("Command2.HelpString"))
        Me.Command2.Image = CType(resources.GetObject("Command2.Image"), System.Drawing.Image)
        Me.Command2.ImageAlign = CType(resources.GetObject("Command2.ImageAlign"), System.Drawing.ContentAlignment)
        Me.Command2.ImageIndex = CType(resources.GetObject("Command2.ImageIndex"), Integer)
        Me.Command2.ImeMode = CType(resources.GetObject("Command2.ImeMode"), System.Windows.Forms.ImeMode)
        Me.Command2.Location = CType(resources.GetObject("Command2.Location"), System.Drawing.Point)
        Me.Command2.Name = "Command2"
        Me.Command2.RightToLeft = CType(resources.GetObject("Command2.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.HelpProvider1.SetShowHelp(Me.Command2, CType(resources.GetObject("Command2.ShowHelp"), Boolean))
        Me.Command2.Size = CType(resources.GetObject("Command2.Size"), System.Drawing.Size)
        Me.Command2.TabIndex = CType(resources.GetObject("Command2.TabIndex"), Integer)
        Me.Command2.Text = resources.GetString("Command2.Text")
        Me.Command2.TextAlign = CType(resources.GetObject("Command2.TextAlign"), System.Drawing.ContentAlignment)
        Me.ToolTip1.SetToolTip(Me.Command2, resources.GetString("Command2.ToolTip"))
        Me.Command2.Visible = CType(resources.GetObject("Command2.Visible"), Boolean)
        '
        'cmdExit
        '
        Me.cmdExit.AccessibleDescription = resources.GetString("cmdExit.AccessibleDescription")
        Me.cmdExit.AccessibleName = resources.GetString("cmdExit.AccessibleName")
        Me.cmdExit.Anchor = CType(resources.GetObject("cmdExit.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.BackColor = System.Drawing.SystemColors.Control
        Me.cmdExit.BackgroundImage = CType(resources.GetObject("cmdExit.BackgroundImage"), System.Drawing.Image)
        Me.cmdExit.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdExit.Dock = CType(resources.GetObject("cmdExit.Dock"), System.Windows.Forms.DockStyle)
        Me.cmdExit.Enabled = CType(resources.GetObject("cmdExit.Enabled"), Boolean)
        Me.cmdExit.FlatStyle = CType(resources.GetObject("cmdExit.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.cmdExit.Font = CType(resources.GetObject("cmdExit.Font"), System.Drawing.Font)
        Me.cmdExit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.HelpProvider1.SetHelpKeyword(Me.cmdExit, resources.GetString("cmdExit.HelpKeyword"))
        Me.HelpProvider1.SetHelpNavigator(Me.cmdExit, CType(resources.GetObject("cmdExit.HelpNavigator"), System.Windows.Forms.HelpNavigator))
        Me.HelpProvider1.SetHelpString(Me.cmdExit, resources.GetString("cmdExit.HelpString"))
        Me.cmdExit.Image = CType(resources.GetObject("cmdExit.Image"), System.Drawing.Image)
        Me.cmdExit.ImageAlign = CType(resources.GetObject("cmdExit.ImageAlign"), System.Drawing.ContentAlignment)
        Me.cmdExit.ImageIndex = CType(resources.GetObject("cmdExit.ImageIndex"), Integer)
        Me.cmdExit.ImeMode = CType(resources.GetObject("cmdExit.ImeMode"), System.Windows.Forms.ImeMode)
        Me.cmdExit.Location = CType(resources.GetObject("cmdExit.Location"), System.Drawing.Point)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.RightToLeft = CType(resources.GetObject("cmdExit.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.HelpProvider1.SetShowHelp(Me.cmdExit, CType(resources.GetObject("cmdExit.ShowHelp"), Boolean))
        Me.cmdExit.Size = CType(resources.GetObject("cmdExit.Size"), System.Drawing.Size)
        Me.cmdExit.TabIndex = CType(resources.GetObject("cmdExit.TabIndex"), Integer)
        Me.cmdExit.Text = resources.GetString("cmdExit.Text")
        Me.cmdExit.TextAlign = CType(resources.GetObject("cmdExit.TextAlign"), System.Drawing.ContentAlignment)
        Me.ToolTip1.SetToolTip(Me.cmdExit, resources.GetString("cmdExit.ToolTip"))
        Me.cmdExit.Visible = CType(resources.GetObject("cmdExit.Visible"), Boolean)
        '
        'Text1
        '
        Me.Text1.AcceptsReturn = True
        Me.Text1.AccessibleDescription = resources.GetString("Text1.AccessibleDescription")
        Me.Text1.AccessibleName = resources.GetString("Text1.AccessibleName")
        Me.Text1.Anchor = CType(resources.GetObject("Text1.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.Text1.AutoSize = CType(resources.GetObject("Text1.AutoSize"), Boolean)
        Me.Text1.BackColor = System.Drawing.Color.White
        Me.Text1.BackgroundImage = CType(resources.GetObject("Text1.BackgroundImage"), System.Drawing.Image)
        Me.Text1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Text1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Text1.Dock = CType(resources.GetObject("Text1.Dock"), System.Windows.Forms.DockStyle)
        Me.Text1.Enabled = CType(resources.GetObject("Text1.Enabled"), Boolean)
        Me.Text1.Font = CType(resources.GetObject("Text1.Font"), System.Drawing.Font)
        Me.Text1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HelpProvider1.SetHelpKeyword(Me.Text1, resources.GetString("Text1.HelpKeyword"))
        Me.HelpProvider1.SetHelpNavigator(Me.Text1, CType(resources.GetObject("Text1.HelpNavigator"), System.Windows.Forms.HelpNavigator))
        Me.HelpProvider1.SetHelpString(Me.Text1, resources.GetString("Text1.HelpString"))
        Me.Text1.ImeMode = CType(resources.GetObject("Text1.ImeMode"), System.Windows.Forms.ImeMode)
        Me.Text1.Location = CType(resources.GetObject("Text1.Location"), System.Drawing.Point)
        Me.Text1.MaxLength = CType(resources.GetObject("Text1.MaxLength"), Integer)
        Me.Text1.Multiline = CType(resources.GetObject("Text1.Multiline"), Boolean)
        Me.Text1.Name = "Text1"
        Me.Text1.PasswordChar = CType(resources.GetObject("Text1.PasswordChar"), Char)
        Me.Text1.RightToLeft = CType(resources.GetObject("Text1.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.Text1.ScrollBars = CType(resources.GetObject("Text1.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.HelpProvider1.SetShowHelp(Me.Text1, CType(resources.GetObject("Text1.ShowHelp"), Boolean))
        Me.Text1.Size = CType(resources.GetObject("Text1.Size"), System.Drawing.Size)
        Me.Text1.TabIndex = CType(resources.GetObject("Text1.TabIndex"), Integer)
        Me.Text1.Text = resources.GetString("Text1.Text")
        Me.Text1.TextAlign = CType(resources.GetObject("Text1.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.ToolTip1.SetToolTip(Me.Text1, resources.GetString("Text1.ToolTip"))
        Me.Text1.Visible = CType(resources.GetObject("Text1.Visible"), Boolean)
        Me.Text1.WordWrap = CType(resources.GetObject("Text1.WordWrap"), Boolean)
        '
        'Combo1
        '
        Me.Combo1.AccessibleDescription = resources.GetString("Combo1.AccessibleDescription")
        Me.Combo1.AccessibleName = resources.GetString("Combo1.AccessibleName")
        Me.Combo1.Anchor = CType(resources.GetObject("Combo1.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.Combo1.BackColor = System.Drawing.SystemColors.Window
        Me.Combo1.BackgroundImage = CType(resources.GetObject("Combo1.BackgroundImage"), System.Drawing.Image)
        Me.Combo1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Combo1.Dock = CType(resources.GetObject("Combo1.Dock"), System.Windows.Forms.DockStyle)
        Me.Combo1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Combo1.Enabled = CType(resources.GetObject("Combo1.Enabled"), Boolean)
        Me.Combo1.Font = CType(resources.GetObject("Combo1.Font"), System.Drawing.Font)
        Me.Combo1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.HelpProvider1.SetHelpKeyword(Me.Combo1, resources.GetString("Combo1.HelpKeyword"))
        Me.HelpProvider1.SetHelpNavigator(Me.Combo1, CType(resources.GetObject("Combo1.HelpNavigator"), System.Windows.Forms.HelpNavigator))
        Me.HelpProvider1.SetHelpString(Me.Combo1, resources.GetString("Combo1.HelpString"))
        Me.Combo1.ImeMode = CType(resources.GetObject("Combo1.ImeMode"), System.Windows.Forms.ImeMode)
        Me.Combo1.IntegralHeight = CType(resources.GetObject("Combo1.IntegralHeight"), Boolean)
        Me.Combo1.ItemHeight = CType(resources.GetObject("Combo1.ItemHeight"), Integer)
        Me.Combo1.Location = CType(resources.GetObject("Combo1.Location"), System.Drawing.Point)
        Me.Combo1.MaxDropDownItems = CType(resources.GetObject("Combo1.MaxDropDownItems"), Integer)
        Me.Combo1.MaxLength = CType(resources.GetObject("Combo1.MaxLength"), Integer)
        Me.Combo1.Name = "Combo1"
        Me.Combo1.RightToLeft = CType(resources.GetObject("Combo1.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.HelpProvider1.SetShowHelp(Me.Combo1, CType(resources.GetObject("Combo1.ShowHelp"), Boolean))
        Me.Combo1.Size = CType(resources.GetObject("Combo1.Size"), System.Drawing.Size)
        Me.Combo1.TabIndex = CType(resources.GetObject("Combo1.TabIndex"), Integer)
        Me.Combo1.Text = resources.GetString("Combo1.Text")
        Me.ToolTip1.SetToolTip(Me.Combo1, resources.GetString("Combo1.ToolTip"))
        Me.Combo1.Visible = CType(resources.GetObject("Combo1.Visible"), Boolean)
        '
        'cmdAFC
        '
        Me.cmdAFC.AccessibleDescription = resources.GetString("cmdAFC.AccessibleDescription")
        Me.cmdAFC.AccessibleName = resources.GetString("cmdAFC.AccessibleName")
        Me.cmdAFC.Anchor = CType(resources.GetObject("cmdAFC.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.cmdAFC.BackgroundImage = CType(resources.GetObject("cmdAFC.BackgroundImage"), System.Drawing.Image)
        Me.cmdAFC.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdAFC.Dock = CType(resources.GetObject("cmdAFC.Dock"), System.Windows.Forms.DockStyle)
        Me.cmdAFC.Enabled = CType(resources.GetObject("cmdAFC.Enabled"), Boolean)
        Me.cmdAFC.FlatStyle = CType(resources.GetObject("cmdAFC.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.cmdAFC.Font = CType(resources.GetObject("cmdAFC.Font"), System.Drawing.Font)
        Me.HelpProvider1.SetHelpKeyword(Me.cmdAFC, resources.GetString("cmdAFC.HelpKeyword"))
        Me.HelpProvider1.SetHelpNavigator(Me.cmdAFC, CType(resources.GetObject("cmdAFC.HelpNavigator"), System.Windows.Forms.HelpNavigator))
        Me.HelpProvider1.SetHelpString(Me.cmdAFC, resources.GetString("cmdAFC.HelpString"))
        Me.cmdAFC.Image = CType(resources.GetObject("cmdAFC.Image"), System.Drawing.Image)
        Me.cmdAFC.ImageAlign = CType(resources.GetObject("cmdAFC.ImageAlign"), System.Drawing.ContentAlignment)
        Me.cmdAFC.ImageIndex = CType(resources.GetObject("cmdAFC.ImageIndex"), Integer)
        Me.cmdAFC.ImeMode = CType(resources.GetObject("cmdAFC.ImeMode"), System.Windows.Forms.ImeMode)
        Me.cmdAFC.Location = CType(resources.GetObject("cmdAFC.Location"), System.Drawing.Point)
        Me.cmdAFC.Name = "cmdAFC"
        Me.cmdAFC.RightToLeft = CType(resources.GetObject("cmdAFC.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.HelpProvider1.SetShowHelp(Me.cmdAFC, CType(resources.GetObject("cmdAFC.ShowHelp"), Boolean))
        Me.cmdAFC.Size = CType(resources.GetObject("cmdAFC.Size"), System.Drawing.Size)
        Me.cmdAFC.TabIndex = CType(resources.GetObject("cmdAFC.TabIndex"), Integer)
        Me.cmdAFC.Text = resources.GetString("cmdAFC.Text")
        Me.cmdAFC.TextAlign = CType(resources.GetObject("cmdAFC.TextAlign"), System.Drawing.ContentAlignment)
        Me.ToolTip1.SetToolTip(Me.cmdAFC, resources.GetString("cmdAFC.ToolTip"))
        Me.cmdAFC.Visible = CType(resources.GetObject("cmdAFC.Visible"), Boolean)
        '
        'cmdST
        '
        Me.cmdST.AccessibleDescription = resources.GetString("cmdST.AccessibleDescription")
        Me.cmdST.AccessibleName = resources.GetString("cmdST.AccessibleName")
        Me.cmdST.Anchor = CType(resources.GetObject("cmdST.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.cmdST.BackgroundImage = CType(resources.GetObject("cmdST.BackgroundImage"), System.Drawing.Image)
        Me.cmdST.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdST.Dock = CType(resources.GetObject("cmdST.Dock"), System.Windows.Forms.DockStyle)
        Me.cmdST.Enabled = CType(resources.GetObject("cmdST.Enabled"), Boolean)
        Me.cmdST.FlatStyle = CType(resources.GetObject("cmdST.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.cmdST.Font = CType(resources.GetObject("cmdST.Font"), System.Drawing.Font)
        Me.HelpProvider1.SetHelpKeyword(Me.cmdST, resources.GetString("cmdST.HelpKeyword"))
        Me.HelpProvider1.SetHelpNavigator(Me.cmdST, CType(resources.GetObject("cmdST.HelpNavigator"), System.Windows.Forms.HelpNavigator))
        Me.HelpProvider1.SetHelpString(Me.cmdST, resources.GetString("cmdST.HelpString"))
        Me.cmdST.Image = CType(resources.GetObject("cmdST.Image"), System.Drawing.Image)
        Me.cmdST.ImageAlign = CType(resources.GetObject("cmdST.ImageAlign"), System.Drawing.ContentAlignment)
        Me.cmdST.ImageIndex = CType(resources.GetObject("cmdST.ImageIndex"), Integer)
        Me.cmdST.ImeMode = CType(resources.GetObject("cmdST.ImeMode"), System.Windows.Forms.ImeMode)
        Me.cmdST.Location = CType(resources.GetObject("cmdST.Location"), System.Drawing.Point)
        Me.cmdST.Name = "cmdST"
        Me.cmdST.RightToLeft = CType(resources.GetObject("cmdST.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.HelpProvider1.SetShowHelp(Me.cmdST, CType(resources.GetObject("cmdST.ShowHelp"), Boolean))
        Me.cmdST.Size = CType(resources.GetObject("cmdST.Size"), System.Drawing.Size)
        Me.cmdST.TabIndex = CType(resources.GetObject("cmdST.TabIndex"), Integer)
        Me.cmdST.Text = resources.GetString("cmdST.Text")
        Me.cmdST.TextAlign = CType(resources.GetObject("cmdST.TextAlign"), System.Drawing.ContentAlignment)
        Me.ToolTip1.SetToolTip(Me.cmdST, resources.GetString("cmdST.ToolTip"))
        Me.cmdST.Visible = CType(resources.GetObject("cmdST.Visible"), Boolean)
        '
        'cmdWHB
        '
        Me.cmdWHB.AccessibleDescription = resources.GetString("cmdWHB.AccessibleDescription")
        Me.cmdWHB.AccessibleName = resources.GetString("cmdWHB.AccessibleName")
        Me.cmdWHB.Anchor = CType(resources.GetObject("cmdWHB.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.cmdWHB.BackgroundImage = CType(resources.GetObject("cmdWHB.BackgroundImage"), System.Drawing.Image)
        Me.cmdWHB.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdWHB.Dock = CType(resources.GetObject("cmdWHB.Dock"), System.Windows.Forms.DockStyle)
        Me.cmdWHB.Enabled = CType(resources.GetObject("cmdWHB.Enabled"), Boolean)
        Me.cmdWHB.FlatStyle = CType(resources.GetObject("cmdWHB.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.cmdWHB.Font = CType(resources.GetObject("cmdWHB.Font"), System.Drawing.Font)
        Me.HelpProvider1.SetHelpKeyword(Me.cmdWHB, resources.GetString("cmdWHB.HelpKeyword"))
        Me.HelpProvider1.SetHelpNavigator(Me.cmdWHB, CType(resources.GetObject("cmdWHB.HelpNavigator"), System.Windows.Forms.HelpNavigator))
        Me.HelpProvider1.SetHelpString(Me.cmdWHB, resources.GetString("cmdWHB.HelpString"))
        Me.cmdWHB.Image = CType(resources.GetObject("cmdWHB.Image"), System.Drawing.Image)
        Me.cmdWHB.ImageAlign = CType(resources.GetObject("cmdWHB.ImageAlign"), System.Drawing.ContentAlignment)
        Me.cmdWHB.ImageIndex = CType(resources.GetObject("cmdWHB.ImageIndex"), Integer)
        Me.cmdWHB.ImeMode = CType(resources.GetObject("cmdWHB.ImeMode"), System.Windows.Forms.ImeMode)
        Me.cmdWHB.Location = CType(resources.GetObject("cmdWHB.Location"), System.Drawing.Point)
        Me.cmdWHB.Name = "cmdWHB"
        Me.cmdWHB.RightToLeft = CType(resources.GetObject("cmdWHB.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.HelpProvider1.SetShowHelp(Me.cmdWHB, CType(resources.GetObject("cmdWHB.ShowHelp"), Boolean))
        Me.cmdWHB.Size = CType(resources.GetObject("cmdWHB.Size"), System.Drawing.Size)
        Me.cmdWHB.TabIndex = CType(resources.GetObject("cmdWHB.TabIndex"), Integer)
        Me.cmdWHB.Text = resources.GetString("cmdWHB.Text")
        Me.cmdWHB.TextAlign = CType(resources.GetObject("cmdWHB.TextAlign"), System.Drawing.ContentAlignment)
        Me.ToolTip1.SetToolTip(Me.cmdWHB, resources.GetString("cmdWHB.ToolTip"))
        Me.cmdWHB.Visible = CType(resources.GetObject("cmdWHB.Visible"), Boolean)
        '
        'cmdWPS
        '
        Me.cmdWPS.AccessibleDescription = resources.GetString("cmdWPS.AccessibleDescription")
        Me.cmdWPS.AccessibleName = resources.GetString("cmdWPS.AccessibleName")
        Me.cmdWPS.Anchor = CType(resources.GetObject("cmdWPS.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.cmdWPS.BackgroundImage = CType(resources.GetObject("cmdWPS.BackgroundImage"), System.Drawing.Image)
        Me.cmdWPS.Dock = CType(resources.GetObject("cmdWPS.Dock"), System.Windows.Forms.DockStyle)
        Me.cmdWPS.Enabled = CType(resources.GetObject("cmdWPS.Enabled"), Boolean)
        Me.cmdWPS.FlatStyle = CType(resources.GetObject("cmdWPS.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.cmdWPS.Font = CType(resources.GetObject("cmdWPS.Font"), System.Drawing.Font)
        Me.HelpProvider1.SetHelpKeyword(Me.cmdWPS, resources.GetString("cmdWPS.HelpKeyword"))
        Me.HelpProvider1.SetHelpNavigator(Me.cmdWPS, CType(resources.GetObject("cmdWPS.HelpNavigator"), System.Windows.Forms.HelpNavigator))
        Me.HelpProvider1.SetHelpString(Me.cmdWPS, resources.GetString("cmdWPS.HelpString"))
        Me.cmdWPS.Image = CType(resources.GetObject("cmdWPS.Image"), System.Drawing.Image)
        Me.cmdWPS.ImageAlign = CType(resources.GetObject("cmdWPS.ImageAlign"), System.Drawing.ContentAlignment)
        Me.cmdWPS.ImageIndex = CType(resources.GetObject("cmdWPS.ImageIndex"), Integer)
        Me.cmdWPS.ImeMode = CType(resources.GetObject("cmdWPS.ImeMode"), System.Windows.Forms.ImeMode)
        Me.cmdWPS.Location = CType(resources.GetObject("cmdWPS.Location"), System.Drawing.Point)
        Me.cmdWPS.Name = "cmdWPS"
        Me.cmdWPS.RightToLeft = CType(resources.GetObject("cmdWPS.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.HelpProvider1.SetShowHelp(Me.cmdWPS, CType(resources.GetObject("cmdWPS.ShowHelp"), Boolean))
        Me.cmdWPS.Size = CType(resources.GetObject("cmdWPS.Size"), System.Drawing.Size)
        Me.cmdWPS.TabIndex = CType(resources.GetObject("cmdWPS.TabIndex"), Integer)
        Me.cmdWPS.Text = resources.GetString("cmdWPS.Text")
        Me.cmdWPS.TextAlign = CType(resources.GetObject("cmdWPS.TextAlign"), System.Drawing.ContentAlignment)
        Me.ToolTip1.SetToolTip(Me.cmdWPS, resources.GetString("cmdWPS.ToolTip"))
        Me.cmdWPS.Visible = CType(resources.GetObject("cmdWPS.Visible"), Boolean)
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 1000
        '
        'mnuGuida
        '
        '
        '_mnuGuida_0
        '
        Me._mnuGuida_0.Enabled = CType(resources.GetObject("_mnuGuida_0.Enabled"), Boolean)
        Me.mnuGuida.Add(0, Me._mnuGuida_0)

        Me._mnuGuida_0.ShortcutKeys = CType(System.Convert.ToInt32(resources.GetObject("_mnuGuida_0.Shortcut")), System.Windows.Forms.Keys)
        Me._mnuGuida_0.ShowShortcutKeys = CType(resources.GetObject("_mnuGuida_0.ShowShortcut"), Boolean)
        Me._mnuGuida_0.Text = resources.GetString("_mnuGuida_0.Text")
        Me._mnuGuida_0.Visible = CType(resources.GetObject("_mnuGuida_0.Visible"), Boolean)
        '
        '_mnuGuida_1
        '
        Me._mnuGuida_1.Enabled = CType(resources.GetObject("_mnuGuida_1.Enabled"), Boolean)
        Me.mnuGuida.Add(1, Me._mnuGuida_1)

        Me._mnuGuida_1.ShortcutKeys = CType(System.Convert.ToInt32(resources.GetObject("_mnuGuida_1.Shortcut")), System.Windows.Forms.Keys)
        Me._mnuGuida_1.ShowShortcutKeys = CType(resources.GetObject("_mnuGuida_1.ShowShortcut"), Boolean)
        Me._mnuGuida_1.Text = resources.GetString("_mnuGuida_1.Text")
        Me._mnuGuida_1.Visible = CType(resources.GetObject("_mnuGuida_1.Visible"), Boolean)
        '
        'mnuStamLib
        '
        '
        '_mnuStamLib_0
        '
        Me._mnuStamLib_0.Enabled = CType(resources.GetObject("_mnuStamLib_0.Enabled"), Boolean)
        Me.mnuStamLib.Add(0, Me._mnuStamLib_0)

        Me._mnuStamLib_0.ShortcutKeys = CType(System.Convert.ToInt32(resources.GetObject("_mnuStamLib_0.Shortcut")), System.Windows.Forms.Keys)
        Me._mnuStamLib_0.ShowShortcutKeys = CType(resources.GetObject("_mnuStamLib_0.ShowShortcut"), Boolean)
        Me._mnuStamLib_0.Text = resources.GetString("_mnuStamLib_0.Text")
        Me._mnuStamLib_0.Visible = CType(resources.GetObject("_mnuStamLib_0.Visible"), Boolean)
        '
        '_mnuStamLib_1
        '
        Me._mnuStamLib_1.Enabled = CType(resources.GetObject("_mnuStamLib_1.Enabled"), Boolean)
        Me.mnuStamLib.Add(1, Me._mnuStamLib_1)

        Me._mnuStamLib_1.ShortcutKeys = CType(System.Convert.ToInt32(resources.GetObject("_mnuStamLib_1.Shortcut")), System.Windows.Forms.Keys)
        Me._mnuStamLib_1.ShowShortcutKeys = CType(resources.GetObject("_mnuStamLib_1.ShowShortcut"), Boolean)
        Me._mnuStamLib_1.Text = resources.GetString("_mnuStamLib_1.Text")
        Me._mnuStamLib_1.Visible = CType(resources.GetObject("_mnuStamLib_1.Visible"), Boolean)
        '
        'mnuTerm
        '
        '
        '_mnuTerm_0
        '
        Me._mnuTerm_0.Enabled = CType(resources.GetObject("_mnuTerm_0.Enabled"), Boolean)
        Me.mnuTerm.Add(0, Me._mnuTerm_0)

        Me._mnuTerm_0.ShortcutKeys = CType(System.Convert.ToInt32(resources.GetObject("_mnuTerm_0.Shortcut")), System.Windows.Forms.Keys)
        Me._mnuTerm_0.ShowShortcutKeys = CType(resources.GetObject("_mnuTerm_0.ShowShortcut"), Boolean)
        Me._mnuTerm_0.Text = resources.GetString("_mnuTerm_0.Text")
        Me._mnuTerm_0.Visible = CType(resources.GetObject("_mnuTerm_0.Visible"), Boolean)
        '
        '_mnuTerm_1
        '
        Me._mnuTerm_1.Enabled = CType(resources.GetObject("_mnuTerm_1.Enabled"), Boolean)
        Me.mnuTerm.Add(1, Me._mnuTerm_1)

        Me._mnuTerm_1.ShortcutKeys = CType(System.Convert.ToInt32(resources.GetObject("_mnuTerm_1.Shortcut")), System.Windows.Forms.Keys)
        Me._mnuTerm_1.ShowShortcutKeys = CType(resources.GetObject("_mnuTerm_1.ShowShortcut"), Boolean)
        Me._mnuTerm_1.Text = resources.GetString("_mnuTerm_1.Text")
        Me._mnuTerm_1.Visible = CType(resources.GetObject("_mnuTerm_1.Visible"), Boolean)
        '
        '_mnuTerm_2
        '
        Me._mnuTerm_2.Enabled = CType(resources.GetObject("_mnuTerm_2.Enabled"), Boolean)
        Me.mnuTerm.Add(2, Me._mnuTerm_2)

        Me._mnuTerm_2.ShortcutKeys = CType(System.Convert.ToInt32(resources.GetObject("_mnuTerm_2.Shortcut")), System.Windows.Forms.Keys)
        Me._mnuTerm_2.ShowShortcutKeys = CType(resources.GetObject("_mnuTerm_2.ShowShortcut"), Boolean)
        Me._mnuTerm_2.Text = resources.GetString("_mnuTerm_2.Text")
        Me._mnuTerm_2.Visible = CType(resources.GetObject("_mnuTerm_2.Visible"), Boolean)
        '
        '_mnuTerm_3
        '
        Me._mnuTerm_3.Enabled = CType(resources.GetObject("_mnuTerm_3.Enabled"), Boolean)
        Me.mnuTerm.Add(3, Me._mnuTerm_3)

        Me._mnuTerm_3.ShortcutKeys = CType(System.Convert.ToInt32(resources.GetObject("_mnuTerm_3.Shortcut")), System.Windows.Forms.Keys)
        Me._mnuTerm_3.ShowShortcutKeys = CType(resources.GetObject("_mnuTerm_3.ShowShortcut"), Boolean)
        Me._mnuTerm_3.Text = resources.GetString("_mnuTerm_3.Text")
        Me._mnuTerm_3.Visible = CType(resources.GetObject("_mnuTerm_3.Visible"), Boolean)
        '
        '_mnuTerm_4
        '
        Me._mnuTerm_4.Enabled = CType(resources.GetObject("_mnuTerm_4.Enabled"), Boolean)
        Me.mnuTerm.Add(4, Me._mnuTerm_4)

        Me._mnuTerm_4.ShortcutKeys = CType(System.Convert.ToInt32(resources.GetObject("_mnuTerm_4.Shortcut")), System.Windows.Forms.Keys)
        Me._mnuTerm_4.ShowShortcutKeys = CType(resources.GetObject("_mnuTerm_4.ShowShortcut"), Boolean)
        Me._mnuTerm_4.Text = resources.GetString("_mnuTerm_4.Text")
        Me._mnuTerm_4.Visible = CType(resources.GetObject("_mnuTerm_4.Visible"), Boolean)
        '
        '_mnuTerm_5
        '
        Me._mnuTerm_5.Enabled = CType(resources.GetObject("_mnuTerm_5.Enabled"), Boolean)
        Me.mnuTerm.Add(5, Me._mnuTerm_5)

        Me._mnuTerm_5.ShortcutKeys = CType(System.Convert.ToInt32(resources.GetObject("_mnuTerm_5.Shortcut")), System.Windows.Forms.Keys)
        Me._mnuTerm_5.ShowShortcutKeys = CType(resources.GetObject("_mnuTerm_5.ShowShortcut"), Boolean)
        Me._mnuTerm_5.Text = resources.GetString("_mnuTerm_5.Text")
        Me._mnuTerm_5.Visible = CType(resources.GetObject("_mnuTerm_5.Visible"), Boolean)
        '
        'mnuUltAgg
        '
        '
        '_mnuUltAgg_0
        '
        Me._mnuUltAgg_0.Enabled = CType(resources.GetObject("_mnuUltAgg_0.Enabled"), Boolean)
        Me.mnuUltAgg.Add(0, Me._mnuUltAgg_0)

        Me._mnuUltAgg_0.ShortcutKeys = CType(System.Convert.ToInt32(resources.GetObject("_mnuUltAgg_0.Shortcut")), System.Windows.Forms.Keys)
        Me._mnuUltAgg_0.ShowShortcutKeys = CType(resources.GetObject("_mnuUltAgg_0.ShowShortcut"), Boolean)
        Me._mnuUltAgg_0.Text = resources.GetString("_mnuUltAgg_0.Text")
        Me._mnuUltAgg_0.Visible = CType(resources.GetObject("_mnuUltAgg_0.Visible"), Boolean)
        '
        '_mnuUltAgg_1
        '
        Me._mnuUltAgg_1.Enabled = CType(resources.GetObject("_mnuUltAgg_1.Enabled"), Boolean)
        Me.mnuUltAgg.Add(1, Me._mnuUltAgg_1)

        Me._mnuUltAgg_1.ShortcutKeys = CType(System.Convert.ToInt32(resources.GetObject("_mnuUltAgg_1.Shortcut")), System.Windows.Forms.Keys)
        Me._mnuUltAgg_1.ShowShortcutKeys = CType(resources.GetObject("_mnuUltAgg_1.ShowShortcut"), Boolean)
        Me._mnuUltAgg_1.Text = resources.GetString("_mnuUltAgg_1.Text")
        Me._mnuUltAgg_1.Visible = CType(resources.GetObject("_mnuUltAgg_1.Visible"), Boolean)
        '
        'mnuUt
        '
        '
        '_mnuUt_0
        '
        Me._mnuUt_0.Enabled = CType(resources.GetObject("_mnuUt_0.Enabled"), Boolean)
        Me.mnuUt.Add(0, Me._mnuUt_0)

        Me._mnuUt_0.ShortcutKeys = CType(System.Convert.ToInt32(resources.GetObject("_mnuUt_0.Shortcut")), System.Windows.Forms.Keys)
        Me._mnuUt_0.ShowShortcutKeys = CType(resources.GetObject("_mnuUt_0.ShowShortcut"), Boolean)
        Me._mnuUt_0.Text = resources.GetString("_mnuUt_0.Text")
        Me._mnuUt_0.Visible = CType(resources.GetObject("_mnuUt_0.Visible"), Boolean)
        '
        'MainMenu1
        '
        Me.MainMenu1.Items.AddRange(New System.Windows.Forms.ToolStripMenuItem() {Me.mnuTerm0, Me.mnuCalc, Me.mnuTrac, Me.mnuTermo, Me.mnuLibrerie, Me.mnuPref, Me.mnuUt0, Me.mnuGuide})
        Me.MainMenu1.RightToLeft = CType(resources.GetObject("MainMenu1.RightToLeft"), System.Windows.Forms.RightToLeft)
        '
        'mnuTerm0
        '
        Me.mnuTerm0.Enabled = CType(resources.GetObject("mnuTerm0.Enabled"), Boolean)

        Me.mnuTerm0.DropDownItems.AddRange(New System.Windows.Forms.ToolStripMenuItem() {Me._mnuTerm_0, Me._mnuTerm_1, Me._mnuTerm_2, Me._mnuTerm_3, Me._mnuTerm_4, Me._mnuTerm_5})
        Me.mnuTerm0.ShortcutKeys = CType(System.Convert.ToInt32(resources.GetObject("mnuTerm0.Shortcut")), System.Windows.Forms.Keys)
        Me.mnuTerm0.ShowShortcutKeys = CType(resources.GetObject("mnuTerm0.ShowShortcut"), Boolean)
        Me.mnuTerm0.Text = resources.GetString("mnuTerm0.Text")
        Me.mnuTerm0.Visible = CType(resources.GetObject("mnuTerm0.Visible"), Boolean)
        '
        'mnuCalc
        '
        Me.mnuCalc.Enabled = CType(resources.GetObject("mnuCalc.Enabled"), Boolean)

        Me.mnuCalc.DropDownItems.AddRange(New System.Windows.Forms.ToolStripMenuItem() {Me.mecMantelli, Me.mecBocchelli, Me.mecSelle, Me.mecOrecchie, Me.mecSerraggio, Me.mecConi, Me.mecBreLoc})
        Me.mnuCalc.ShortcutKeys = CType(System.Convert.ToInt32(resources.GetObject("mnuCalc.Shortcut")), System.Windows.Forms.Keys)
        Me.mnuCalc.ShowShortcutKeys = CType(resources.GetObject("mnuCalc.ShowShortcut"), Boolean)
        Me.mnuCalc.Text = resources.GetString("mnuCalc.Text")
        Me.mnuCalc.Visible = CType(resources.GetObject("mnuCalc.Visible"), Boolean)
        '
        'mecMantelli
        '
        Me.mecMantelli.Enabled = CType(resources.GetObject("mecMantelli.Enabled"), Boolean)

        Me.mecMantelli.ShortcutKeys = CType(System.Convert.ToInt32(resources.GetObject("mecMantelli.Shortcut")), System.Windows.Forms.Keys)
        Me.mecMantelli.ShowShortcutKeys = CType(resources.GetObject("mecMantelli.ShowShortcut"), Boolean)
        Me.mecMantelli.Text = resources.GetString("mecMantelli.Text")
        Me.mecMantelli.Visible = CType(resources.GetObject("mecMantelli.Visible"), Boolean)
        '
        'mecBocchelli
        '
        Me.mecBocchelli.Enabled = CType(resources.GetObject("mecBocchelli.Enabled"), Boolean)

        Me.mecBocchelli.ShortcutKeys = CType(System.Convert.ToInt32(resources.GetObject("mecBocchelli.Shortcut")), System.Windows.Forms.Keys)
        Me.mecBocchelli.ShowShortcutKeys = CType(resources.GetObject("mecBocchelli.ShowShortcut"), Boolean)
        Me.mecBocchelli.Text = resources.GetString("mecBocchelli.Text")
        Me.mecBocchelli.Visible = CType(resources.GetObject("mecBocchelli.Visible"), Boolean)
        '
        'mecSelle
        '
        Me.mecSelle.Enabled = CType(resources.GetObject("mecSelle.Enabled"), Boolean)

        Me.mecSelle.ShortcutKeys = CType(System.Convert.ToInt32(resources.GetObject("mecSelle.Shortcut")), System.Windows.Forms.Keys)
        Me.mecSelle.ShowShortcutKeys = CType(resources.GetObject("mecSelle.ShowShortcut"), Boolean)
        Me.mecSelle.Text = resources.GetString("mecSelle.Text")
        Me.mecSelle.Visible = CType(resources.GetObject("mecSelle.Visible"), Boolean)
        '
        'mecOrecchie
        '
        Me.mecOrecchie.Enabled = CType(resources.GetObject("mecOrecchie.Enabled"), Boolean)

        Me.mecOrecchie.ShortcutKeys = CType(System.Convert.ToInt32(resources.GetObject("mecOrecchie.Shortcut")), System.Windows.Forms.Keys)
        Me.mecOrecchie.ShowShortcutKeys = CType(resources.GetObject("mecOrecchie.ShowShortcut"), Boolean)
        Me.mecOrecchie.Text = resources.GetString("mecOrecchie.Text")
        Me.mecOrecchie.Visible = CType(resources.GetObject("mecOrecchie.Visible"), Boolean)
        '
        'mecSerraggio
        '
        Me.mecSerraggio.Enabled = CType(resources.GetObject("mecSerraggio.Enabled"), Boolean)

        Me.mecSerraggio.ShortcutKeys = CType(System.Convert.ToInt32(resources.GetObject("mecSerraggio.Shortcut")), System.Windows.Forms.Keys)
        Me.mecSerraggio.ShowShortcutKeys = CType(resources.GetObject("mecSerraggio.ShowShortcut"), Boolean)
        Me.mecSerraggio.Text = resources.GetString("mecSerraggio.Text")
        Me.mecSerraggio.Visible = CType(resources.GetObject("mecSerraggio.Visible"), Boolean)
        '
        'mecConi
        '
        Me.mecConi.Enabled = CType(resources.GetObject("mecConi.Enabled"), Boolean)

        Me.mecConi.ShortcutKeys = CType(System.Convert.ToInt32(resources.GetObject("mecConi.Shortcut")), System.Windows.Forms.Keys)
        Me.mecConi.ShowShortcutKeys = CType(resources.GetObject("mecConi.ShowShortcut"), Boolean)
        Me.mecConi.Text = resources.GetString("mecConi.Text")
        Me.mecConi.Visible = CType(resources.GetObject("mecConi.Visible"), Boolean)
        '
        'mecBreLoc
        '
        Me.mecBreLoc.Enabled = CType(resources.GetObject("mecBreLoc.Enabled"), Boolean)

        Me.mecBreLoc.ShortcutKeys = CType(System.Convert.ToInt32(resources.GetObject("mecBreLoc.Shortcut")), System.Windows.Forms.Keys)
        Me.mecBreLoc.ShowShortcutKeys = CType(resources.GetObject("mecBreLoc.ShowShortcut"), Boolean)
        Me.mecBreLoc.Text = resources.GetString("mecBreLoc.Text")
        Me.mecBreLoc.Visible = CType(resources.GetObject("mecBreLoc.Visible"), Boolean)
        '
        'mnuTrac
        '
        Me.mnuTrac.Enabled = CType(resources.GetObject("mnuTrac.Enabled"), Boolean)

        Me.mnuTrac.DropDownItems.AddRange(New System.Windows.Forms.ToolStripMenuItem() {Me.mnuTracciature, Me.mnuPPSM})
        Me.mnuTrac.ShortcutKeys = CType(System.Convert.ToInt32(resources.GetObject("mnuTrac.Shortcut")), System.Windows.Forms.Keys)
        Me.mnuTrac.ShowShortcutKeys = CType(resources.GetObject("mnuTrac.ShowShortcut"), Boolean)
        Me.mnuTrac.Text = resources.GetString("mnuTrac.Text")
        Me.mnuTrac.Visible = CType(resources.GetObject("mnuTrac.Visible"), Boolean)
        '
        'mnuTracciature
        '
        Me.mnuTracciature.Enabled = CType(resources.GetObject("mnuTracciature.Enabled"), Boolean)

        Me.mnuTracciature.ShortcutKeys = CType(System.Convert.ToInt32(resources.GetObject("mnuTracciature.Shortcut")), System.Windows.Forms.Keys)
        Me.mnuTracciature.ShowShortcutKeys = CType(resources.GetObject("mnuTracciature.ShowShortcut"), Boolean)
        Me.mnuTracciature.Text = resources.GetString("mnuTracciature.Text")
        Me.mnuTracciature.Visible = CType(resources.GetObject("mnuTracciature.Visible"), Boolean)
        '
        'mnuPPSM
        '
        Me.mnuPPSM.Enabled = CType(resources.GetObject("mnuPPSM.Enabled"), Boolean)

        Me.mnuPPSM.ShortcutKeys = CType(System.Convert.ToInt32(resources.GetObject("mnuPPSM.Shortcut")), System.Windows.Forms.Keys)
        Me.mnuPPSM.ShowShortcutKeys = CType(resources.GetObject("mnuPPSM.ShowShortcut"), Boolean)
        Me.mnuPPSM.Text = resources.GetString("mnuPPSM.Text")
        Me.mnuPPSM.Visible = CType(resources.GetObject("mnuPPSM.Visible"), Boolean)
        '
        'mnuTermo
        '
        Me.mnuTermo.Enabled = CType(resources.GetObject("mnuTermo.Enabled"), Boolean)

        Me.mnuTermo.DropDownItems.AddRange(New System.Windows.Forms.ToolStripMenuItem() {Me.terPetrol, Me.terAcqua, Me.mnuPPgas, Me.mnuVentilatori})
        Me.mnuTermo.ShortcutKeys = CType(System.Convert.ToInt32(resources.GetObject("mnuTermo.Shortcut")), System.Windows.Forms.Keys)
        Me.mnuTermo.ShowShortcutKeys = CType(resources.GetObject("mnuTermo.ShowShortcut"), Boolean)
        Me.mnuTermo.Text = resources.GetString("mnuTermo.Text")
        Me.mnuTermo.Visible = CType(resources.GetObject("mnuTermo.Visible"), Boolean)
        '
        'terPetrol
        '
        Me.terPetrol.Enabled = CType(resources.GetObject("terPetrol.Enabled"), Boolean)

        Me.terPetrol.ShortcutKeys = CType(System.Convert.ToInt32(resources.GetObject("terPetrol.Shortcut")), System.Windows.Forms.Keys)
        Me.terPetrol.ShowShortcutKeys = CType(resources.GetObject("terPetrol.ShowShortcut"), Boolean)
        Me.terPetrol.Text = resources.GetString("terPetrol.Text")
        Me.terPetrol.Visible = CType(resources.GetObject("terPetrol.Visible"), Boolean)
        '
        'terAcqua
        '
        Me.terAcqua.Enabled = CType(resources.GetObject("terAcqua.Enabled"), Boolean)

        Me.terAcqua.ShortcutKeys = CType(System.Convert.ToInt32(resources.GetObject("terAcqua.Shortcut")), System.Windows.Forms.Keys)
        Me.terAcqua.ShowShortcutKeys = CType(resources.GetObject("terAcqua.ShowShortcut"), Boolean)
        Me.terAcqua.Text = resources.GetString("terAcqua.Text")
        Me.terAcqua.Visible = CType(resources.GetObject("terAcqua.Visible"), Boolean)
        '
        'mnuPPgas
        '
        Me.mnuPPgas.Enabled = CType(resources.GetObject("mnuPPgas.Enabled"), Boolean)

        Me.mnuPPgas.ShortcutKeys = CType(System.Convert.ToInt32(resources.GetObject("mnuPPgas.Shortcut")), System.Windows.Forms.Keys)
        Me.mnuPPgas.ShowShortcutKeys = CType(resources.GetObject("mnuPPgas.ShowShortcut"), Boolean)
        Me.mnuPPgas.Text = resources.GetString("mnuPPgas.Text")
        Me.mnuPPgas.Visible = CType(resources.GetObject("mnuPPgas.Visible"), Boolean)
        '
        'mnuVentilatori
        '
        Me.mnuVentilatori.Enabled = CType(resources.GetObject("mnuVentilatori.Enabled"), Boolean)

        Me.mnuVentilatori.ShortcutKeys = CType(System.Convert.ToInt32(resources.GetObject("mnuVentilatori.Shortcut")), System.Windows.Forms.Keys)
        Me.mnuVentilatori.ShowShortcutKeys = CType(resources.GetObject("mnuVentilatori.ShowShortcut"), Boolean)
        Me.mnuVentilatori.Text = resources.GetString("mnuVentilatori.Text")
        Me.mnuVentilatori.Visible = CType(resources.GetObject("mnuVentilatori.Visible"), Boolean)
        '
        'mnuLibrerie
        '
        Me.mnuLibrerie.Enabled = CType(resources.GetObject("mnuLibrerie.Enabled"), Boolean)

        Me.mnuLibrerie.DropDownItems.AddRange(New System.Windows.Forms.ToolStripMenuItem() {Me.mnuMateriali, Me.mnuFlange, Me.mnuTiranti, Me.mnuPiping, Me.mnuGuarn, Me.mnuTubi})
        Me.mnuLibrerie.ShortcutKeys = CType(System.Convert.ToInt32(resources.GetObject("mnuLibrerie.Shortcut")), System.Windows.Forms.Keys)
        Me.mnuLibrerie.ShowShortcutKeys = CType(resources.GetObject("mnuLibrerie.ShowShortcut"), Boolean)
        Me.mnuLibrerie.Text = resources.GetString("mnuLibrerie.Text")
        Me.mnuLibrerie.Visible = CType(resources.GetObject("mnuLibrerie.Visible"), Boolean)
        '
        'mnuMateriali
        '
        Me.mnuMateriali.Enabled = CType(resources.GetObject("mnuMateriali.Enabled"), Boolean)

        Me.mnuMateriali.ShortcutKeys = CType(System.Convert.ToInt32(resources.GetObject("mnuMateriali.Shortcut")), System.Windows.Forms.Keys)
        Me.mnuMateriali.ShowShortcutKeys = CType(resources.GetObject("mnuMateriali.ShowShortcut"), Boolean)
        Me.mnuMateriali.Text = resources.GetString("mnuMateriali.Text")
        Me.mnuMateriali.Visible = CType(resources.GetObject("mnuMateriali.Visible"), Boolean)
        '
        'mnuFlange
        '
        Me.mnuFlange.Enabled = CType(resources.GetObject("mnuFlange.Enabled"), Boolean)

        Me.mnuFlange.ShortcutKeys = CType(System.Convert.ToInt32(resources.GetObject("mnuFlange.Shortcut")), System.Windows.Forms.Keys)
        Me.mnuFlange.ShowShortcutKeys = CType(resources.GetObject("mnuFlange.ShowShortcut"), Boolean)
        Me.mnuFlange.Text = resources.GetString("mnuFlange.Text")
        Me.mnuFlange.Visible = CType(resources.GetObject("mnuFlange.Visible"), Boolean)
        '
        'mnuTiranti
        '
        Me.mnuTiranti.Enabled = CType(resources.GetObject("mnuTiranti.Enabled"), Boolean)

        Me.mnuTiranti.ShortcutKeys = CType(System.Convert.ToInt32(resources.GetObject("mnuTiranti.Shortcut")), System.Windows.Forms.Keys)
        Me.mnuTiranti.ShowShortcutKeys = CType(resources.GetObject("mnuTiranti.ShowShortcut"), Boolean)
        Me.mnuTiranti.Text = resources.GetString("mnuTiranti.Text")
        Me.mnuTiranti.Visible = CType(resources.GetObject("mnuTiranti.Visible"), Boolean)
        '
        'mnuPiping
        '
        Me.mnuPiping.Enabled = CType(resources.GetObject("mnuPiping.Enabled"), Boolean)

        Me.mnuPiping.ShortcutKeys = CType(System.Convert.ToInt32(resources.GetObject("mnuPiping.Shortcut")), System.Windows.Forms.Keys)
        Me.mnuPiping.ShowShortcutKeys = CType(resources.GetObject("mnuPiping.ShowShortcut"), Boolean)
        Me.mnuPiping.Text = resources.GetString("mnuPiping.Text")
        Me.mnuPiping.Visible = CType(resources.GetObject("mnuPiping.Visible"), Boolean)
        '
        'mnuGuarn
        '
        Me.mnuGuarn.Enabled = CType(resources.GetObject("mnuGuarn.Enabled"), Boolean)

        Me.mnuGuarn.ShortcutKeys = CType(System.Convert.ToInt32(resources.GetObject("mnuGuarn.Shortcut")), System.Windows.Forms.Keys)
        Me.mnuGuarn.ShowShortcutKeys = CType(resources.GetObject("mnuGuarn.ShowShortcut"), Boolean)
        Me.mnuGuarn.Text = resources.GetString("mnuGuarn.Text")
        Me.mnuGuarn.Visible = CType(resources.GetObject("mnuGuarn.Visible"), Boolean)
        '
        'mnuTubi
        '
        Me.mnuTubi.Enabled = CType(resources.GetObject("mnuTubi.Enabled"), Boolean)

        Me.mnuTubi.ShortcutKeys = CType(System.Convert.ToInt32(resources.GetObject("mnuTubi.Shortcut")), System.Windows.Forms.Keys)
        Me.mnuTubi.ShowShortcutKeys = CType(resources.GetObject("mnuTubi.ShowShortcut"), Boolean)
        Me.mnuTubi.Text = resources.GetString("mnuTubi.Text")
        Me.mnuTubi.Visible = CType(resources.GetObject("mnuTubi.Visible"), Boolean)
        '
        'mnuPref
        '
        Me.mnuPref.Enabled = CType(resources.GetObject("mnuPref.Enabled"), Boolean)

        Me.mnuPref.DropDownItems.AddRange(New System.Windows.Forms.ToolStripMenuItem() {Me.mnuAree, Me.mnuTipLav, Me.mnuPW, Me.mnuPersAz, Me.mnuOpzLibr, Me.mnuAvvio})
        Me.mnuPref.ShortcutKeys = CType(System.Convert.ToInt32(resources.GetObject("mnuPref.Shortcut")), System.Windows.Forms.Keys)
        Me.mnuPref.ShowShortcutKeys = CType(resources.GetObject("mnuPref.ShowShortcut"), Boolean)
        Me.mnuPref.Text = resources.GetString("mnuPref.Text")
        Me.mnuPref.Visible = CType(resources.GetObject("mnuPref.Visible"), Boolean)
        '
        'mnuAree
        '
        Me.mnuAree.Enabled = CType(resources.GetObject("mnuAree.Enabled"), Boolean)

        Me.mnuAree.ShortcutKeys = CType(System.Convert.ToInt32(resources.GetObject("mnuAree.Shortcut")), System.Windows.Forms.Keys)
        Me.mnuAree.ShowShortcutKeys = CType(resources.GetObject("mnuAree.ShowShortcut"), Boolean)
        Me.mnuAree.Text = resources.GetString("mnuAree.Text")
        Me.mnuAree.Visible = CType(resources.GetObject("mnuAree.Visible"), Boolean)
        '
        'mnuTipLav
        '
        Me.mnuTipLav.Enabled = CType(resources.GetObject("mnuTipLav.Enabled"), Boolean)

        Me.mnuTipLav.ShortcutKeys = CType(System.Convert.ToInt32(resources.GetObject("mnuTipLav.Shortcut")), System.Windows.Forms.Keys)
        Me.mnuTipLav.ShowShortcutKeys = CType(resources.GetObject("mnuTipLav.ShowShortcut"), Boolean)
        Me.mnuTipLav.Text = resources.GetString("mnuTipLav.Text")
        Me.mnuTipLav.Visible = CType(resources.GetObject("mnuTipLav.Visible"), Boolean)
        '
        'mnuPW
        '
        Me.mnuPW.Enabled = CType(resources.GetObject("mnuPW.Enabled"), Boolean)

        Me.mnuPW.ShortcutKeys = CType(System.Convert.ToInt32(resources.GetObject("mnuPW.Shortcut")), System.Windows.Forms.Keys)
        Me.mnuPW.ShowShortcutKeys = CType(resources.GetObject("mnuPW.ShowShortcut"), Boolean)
        Me.mnuPW.Text = resources.GetString("mnuPW.Text")
        Me.mnuPW.Visible = CType(resources.GetObject("mnuPW.Visible"), Boolean)
        '
        'mnuPersAz
        '
        Me.mnuPersAz.Enabled = CType(resources.GetObject("mnuPersAz.Enabled"), Boolean)

        Me.mnuPersAz.ShortcutKeys = CType(System.Convert.ToInt32(resources.GetObject("mnuPersAz.Shortcut")), System.Windows.Forms.Keys)
        Me.mnuPersAz.ShowShortcutKeys = CType(resources.GetObject("mnuPersAz.ShowShortcut"), Boolean)
        Me.mnuPersAz.Text = resources.GetString("mnuPersAz.Text")
        Me.mnuPersAz.Visible = CType(resources.GetObject("mnuPersAz.Visible"), Boolean)
        '
        'mnuOpzLibr
        '
        Me.mnuOpzLibr.Enabled = CType(resources.GetObject("mnuOpzLibr.Enabled"), Boolean)

        Me.mnuOpzLibr.DropDownItems.AddRange(New System.Windows.Forms.ToolStripMenuItem() {Me._mnuUltAgg_0, Me._mnuUltAgg_1, Me.mnuStdPip})
        Me.mnuOpzLibr.ShortcutKeys = CType(System.Convert.ToInt32(resources.GetObject("mnuOpzLibr.Shortcut")), System.Windows.Forms.Keys)
        Me.mnuOpzLibr.ShowShortcutKeys = CType(resources.GetObject("mnuOpzLibr.ShowShortcut"), Boolean)
        Me.mnuOpzLibr.Text = resources.GetString("mnuOpzLibr.Text")
        Me.mnuOpzLibr.Visible = CType(resources.GetObject("mnuOpzLibr.Visible"), Boolean)
        '
        'mnuStdPip
        '
        Me.mnuStdPip.Enabled = CType(resources.GetObject("mnuStdPip.Enabled"), Boolean)

        Me.mnuStdPip.ShortcutKeys = CType(System.Convert.ToInt32(resources.GetObject("mnuStdPip.Shortcut")), System.Windows.Forms.Keys)
        Me.mnuStdPip.ShowShortcutKeys = CType(resources.GetObject("mnuStdPip.ShowShortcut"), Boolean)
        Me.mnuStdPip.Text = resources.GetString("mnuStdPip.Text")
        Me.mnuStdPip.Visible = CType(resources.GetObject("mnuStdPip.Visible"), Boolean)
        '
        'mnuAvvio
        '
        Me.mnuAvvio.Enabled = CType(resources.GetObject("mnuAvvio.Enabled"), Boolean)

        Me.mnuAvvio.ShortcutKeys = CType(System.Convert.ToInt32(resources.GetObject("mnuAvvio.Shortcut")), System.Windows.Forms.Keys)
        Me.mnuAvvio.ShowShortcutKeys = CType(resources.GetObject("mnuAvvio.ShowShortcut"), Boolean)
        Me.mnuAvvio.Text = resources.GetString("mnuAvvio.Text")
        Me.mnuAvvio.Visible = CType(resources.GetObject("mnuAvvio.Visible"), Boolean)
        '
        'mnuUt0
        '
        Me.mnuUt0.Enabled = CType(resources.GetObject("mnuUt0.Enabled"), Boolean)

        Me.mnuUt0.DropDownItems.AddRange(New System.Windows.Forms.ToolStripMenuItem() {Me._mnuUt_0, Me.mnuASME, Me.mnuStamLibr, Me.mnuRegole, Me.mnuUtDis})
        Me.mnuUt0.ShortcutKeys = CType(System.Convert.ToInt32(resources.GetObject("mnuUt0.Shortcut")), System.Windows.Forms.Keys)
        Me.mnuUt0.ShowShortcutKeys = CType(resources.GetObject("mnuUt0.ShowShortcut"), Boolean)
        Me.mnuUt0.Text = resources.GetString("mnuUt0.Text")
        Me.mnuUt0.Visible = CType(resources.GetObject("mnuUt0.Visible"), Boolean)
        '
        'mnuASME
        '
        Me.mnuASME.Enabled = CType(resources.GetObject("mnuASME.Enabled"), Boolean)

        Me.mnuASME.ShortcutKeys = CType(System.Convert.ToInt32(resources.GetObject("mnuASME.Shortcut")), System.Windows.Forms.Keys)
        Me.mnuASME.ShowShortcutKeys = CType(resources.GetObject("mnuASME.ShowShortcut"), Boolean)
        Me.mnuASME.Text = resources.GetString("mnuASME.Text")
        Me.mnuASME.Visible = CType(resources.GetObject("mnuASME.Visible"), Boolean)
        '
        'mnuStamLibr
        '
        Me.mnuStamLibr.Enabled = CType(resources.GetObject("mnuStamLibr.Enabled"), Boolean)

        Me.mnuStamLibr.DropDownItems.AddRange(New System.Windows.Forms.ToolStripMenuItem() {Me._mnuStamLib_0, Me._mnuStamLib_1})
        Me.mnuStamLibr.ShortcutKeys = CType(System.Convert.ToInt32(resources.GetObject("mnuStamLibr.Shortcut")), System.Windows.Forms.Keys)
        Me.mnuStamLibr.ShowShortcutKeys = CType(resources.GetObject("mnuStamLibr.ShowShortcut"), Boolean)
        Me.mnuStamLibr.Text = resources.GetString("mnuStamLibr.Text")
        Me.mnuStamLibr.Visible = CType(resources.GetObject("mnuStamLibr.Visible"), Boolean)
        '
        'mnuRegole
        '
        Me.mnuRegole.Enabled = CType(resources.GetObject("mnuRegole.Enabled"), Boolean)

        Me.mnuRegole.ShortcutKeys = CType(System.Convert.ToInt32(resources.GetObject("mnuRegole.Shortcut")), System.Windows.Forms.Keys)
        Me.mnuRegole.ShowShortcutKeys = CType(resources.GetObject("mnuRegole.ShowShortcut"), Boolean)
        Me.mnuRegole.Text = resources.GetString("mnuRegole.Text")
        Me.mnuRegole.Visible = CType(resources.GetObject("mnuRegole.Visible"), Boolean)
        '
        'mnuUtDis
        '
        Me.mnuUtDis.Enabled = CType(resources.GetObject("mnuUtDis.Enabled"), Boolean)

        Me.mnuUtDis.ShortcutKeys = CType(System.Convert.ToInt32(resources.GetObject("mnuUtDis.Shortcut")), System.Windows.Forms.Keys)
        Me.mnuUtDis.ShowShortcutKeys = CType(resources.GetObject("mnuUtDis.ShowShortcut"), Boolean)
        Me.mnuUtDis.Text = resources.GetString("mnuUtDis.Text")
        Me.mnuUtDis.Visible = CType(resources.GetObject("mnuUtDis.Visible"), Boolean)
        '
        'mnuGuide
        '
        Me.mnuGuide.Enabled = CType(resources.GetObject("mnuGuide.Enabled"), Boolean)

        Me.mnuGuide.DropDownItems.AddRange(New System.Windows.Forms.ToolStripMenuItem() {Me._mnuGuida_0, Me._mnuGuida_1, Me.MenuItem1})
        Me.mnuGuide.ShortcutKeys = CType(System.Convert.ToInt32(resources.GetObject("mnuGuide.Shortcut")), System.Windows.Forms.Keys)
        Me.mnuGuide.ShowShortcutKeys = CType(resources.GetObject("mnuGuide.ShowShortcut"), Boolean)
        Me.mnuGuide.Text = resources.GetString("mnuGuide.Text")
        Me.mnuGuide.Visible = CType(resources.GetObject("mnuGuide.Visible"), Boolean)
        '
        'MenuItem1
        '
        Me.MenuItem1.Enabled = CType(resources.GetObject("MenuItem1.Enabled"), Boolean)

        Me.MenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripMenuItem() {Me.MenuItem2, Me.MenuItem3, Me.MenuItem4, Me.MenuItem5, Me.MenuItem6, Me.MenuItem7, Me.MenuItem8, Me.MenuItem9, Me.MenuItem10, Me.MenuItem11, Me.MenuItem12, Me.MenuItem13, Me.MenuItem14, Me.MenuItem15})
        Me.MenuItem1.ShortcutKeys = CType(System.Convert.ToInt32(resources.GetObject("MenuItem1.Shortcut")), System.Windows.Forms.Keys)
        Me.MenuItem1.ShowShortcutKeys = CType(resources.GetObject("MenuItem1.ShowShortcut"), Boolean)
        Me.MenuItem1.Text = resources.GetString("MenuItem1.Text")
        Me.MenuItem1.Visible = CType(resources.GetObject("MenuItem1.Visible"), Boolean)
        '
        'MenuItem2
        '
        Me.MenuItem2.Enabled = CType(resources.GetObject("MenuItem2.Enabled"), Boolean)

        Me.MenuItem2.ShortcutKeys = CType(System.Convert.ToInt32(resources.GetObject("MenuItem2.Shortcut")), System.Windows.Forms.Keys)
        Me.MenuItem2.ShowShortcutKeys = CType(resources.GetObject("MenuItem2.ShowShortcut"), Boolean)
        Me.MenuItem2.Text = resources.GetString("MenuItem2.Text")
        Me.MenuItem2.Visible = CType(resources.GetObject("MenuItem2.Visible"), Boolean)
        '
        'MenuItem3
        '
        Me.MenuItem3.Enabled = CType(resources.GetObject("MenuItem3.Enabled"), Boolean)

        Me.MenuItem3.ShortcutKeys = CType(System.Convert.ToInt32(resources.GetObject("MenuItem3.Shortcut")), System.Windows.Forms.Keys)
        Me.MenuItem3.ShowShortcutKeys = CType(resources.GetObject("MenuItem3.ShowShortcut"), Boolean)
        Me.MenuItem3.Text = resources.GetString("MenuItem3.Text")
        Me.MenuItem3.Visible = CType(resources.GetObject("MenuItem3.Visible"), Boolean)
        '
        'MenuItem4
        '
        Me.MenuItem4.Enabled = CType(resources.GetObject("MenuItem4.Enabled"), Boolean)

        Me.MenuItem4.ShortcutKeys = CType(System.Convert.ToInt32(resources.GetObject("MenuItem4.Shortcut")), System.Windows.Forms.Keys)
        Me.MenuItem4.ShowShortcutKeys = CType(resources.GetObject("MenuItem4.ShowShortcut"), Boolean)
        Me.MenuItem4.Text = resources.GetString("MenuItem4.Text")
        Me.MenuItem4.Visible = CType(resources.GetObject("MenuItem4.Visible"), Boolean)
        '
        'MenuItem5
        '
        Me.MenuItem5.Enabled = CType(resources.GetObject("MenuItem5.Enabled"), Boolean)

        Me.MenuItem5.ShortcutKeys = CType(System.Convert.ToInt32(resources.GetObject("MenuItem5.Shortcut")), System.Windows.Forms.Keys)
        Me.MenuItem5.ShowShortcutKeys = CType(resources.GetObject("MenuItem5.ShowShortcut"), Boolean)
        Me.MenuItem5.Text = resources.GetString("MenuItem5.Text")
        Me.MenuItem5.Visible = CType(resources.GetObject("MenuItem5.Visible"), Boolean)
        '
        'MenuItem6
        '
        Me.MenuItem6.Enabled = CType(resources.GetObject("MenuItem6.Enabled"), Boolean)

        Me.MenuItem6.ShortcutKeys = CType(System.Convert.ToInt32(resources.GetObject("MenuItem6.Shortcut")), System.Windows.Forms.Keys)
        Me.MenuItem6.ShowShortcutKeys = CType(resources.GetObject("MenuItem6.ShowShortcut"), Boolean)
        Me.MenuItem6.Text = resources.GetString("MenuItem6.Text")
        Me.MenuItem6.Visible = CType(resources.GetObject("MenuItem6.Visible"), Boolean)
        '
        'MenuItem7
        '
        Me.MenuItem7.Enabled = CType(resources.GetObject("MenuItem7.Enabled"), Boolean)

        Me.MenuItem7.ShortcutKeys = CType(System.Convert.ToInt32(resources.GetObject("MenuItem7.Shortcut")), System.Windows.Forms.Keys)
        Me.MenuItem7.ShowShortcutKeys = CType(resources.GetObject("MenuItem7.ShowShortcut"), Boolean)
        Me.MenuItem7.Text = resources.GetString("MenuItem7.Text")
        Me.MenuItem7.Visible = CType(resources.GetObject("MenuItem7.Visible"), Boolean)
        '
        'MenuItem8
        '
        Me.MenuItem8.Enabled = CType(resources.GetObject("MenuItem8.Enabled"), Boolean)

        Me.MenuItem8.ShortcutKeys = CType(System.Convert.ToInt32(resources.GetObject("MenuItem8.Shortcut")), System.Windows.Forms.Keys)
        Me.MenuItem8.ShowShortcutKeys = CType(resources.GetObject("MenuItem8.ShowShortcut"), Boolean)
        Me.MenuItem8.Text = resources.GetString("MenuItem8.Text")
        Me.MenuItem8.Visible = CType(resources.GetObject("MenuItem8.Visible"), Boolean)
        '
        'MenuItem9
        '
        Me.MenuItem9.Enabled = CType(resources.GetObject("MenuItem9.Enabled"), Boolean)

        Me.MenuItem9.ShortcutKeys = CType(System.Convert.ToInt32(resources.GetObject("MenuItem9.Shortcut")), System.Windows.Forms.Keys)
        Me.MenuItem9.ShowShortcutKeys = CType(resources.GetObject("MenuItem9.ShowShortcut"), Boolean)
        Me.MenuItem9.Text = resources.GetString("MenuItem9.Text")
        Me.MenuItem9.Visible = CType(resources.GetObject("MenuItem9.Visible"), Boolean)
        '
        'MenuItem10
        '
        Me.MenuItem10.Enabled = CType(resources.GetObject("MenuItem10.Enabled"), Boolean)

        Me.MenuItem10.ShortcutKeys = CType(System.Convert.ToInt32(resources.GetObject("MenuItem10.Shortcut")), System.Windows.Forms.Keys)
        Me.MenuItem10.ShowShortcutKeys = CType(resources.GetObject("MenuItem10.ShowShortcut"), Boolean)
        Me.MenuItem10.Text = resources.GetString("MenuItem10.Text")
        Me.MenuItem10.Visible = CType(resources.GetObject("MenuItem10.Visible"), Boolean)
        '
        'MenuItem11
        '
        Me.MenuItem11.Enabled = CType(resources.GetObject("MenuItem11.Enabled"), Boolean)

        Me.MenuItem11.ShortcutKeys = CType(System.Convert.ToInt32(resources.GetObject("MenuItem11.Shortcut")), System.Windows.Forms.Keys)
        Me.MenuItem11.ShowShortcutKeys = CType(resources.GetObject("MenuItem11.ShowShortcut"), Boolean)
        Me.MenuItem11.Text = resources.GetString("MenuItem11.Text")
        Me.MenuItem11.Visible = CType(resources.GetObject("MenuItem11.Visible"), Boolean)
        '
        'MenuItem12
        '
        Me.MenuItem12.Enabled = CType(resources.GetObject("MenuItem12.Enabled"), Boolean)

        Me.MenuItem12.ShortcutKeys = CType(System.Convert.ToInt32(resources.GetObject("MenuItem12.Shortcut")), System.Windows.Forms.Keys)
        Me.MenuItem12.ShowShortcutKeys = CType(resources.GetObject("MenuItem12.ShowShortcut"), Boolean)
        Me.MenuItem12.Text = resources.GetString("MenuItem12.Text")
        Me.MenuItem12.Visible = CType(resources.GetObject("MenuItem12.Visible"), Boolean)
        '
        'MenuItem13
        '
        Me.MenuItem13.Enabled = CType(resources.GetObject("MenuItem13.Enabled"), Boolean)

        Me.MenuItem13.ShortcutKeys = CType(System.Convert.ToInt32(resources.GetObject("MenuItem13.Shortcut")), System.Windows.Forms.Keys)
        Me.MenuItem13.ShowShortcutKeys = CType(resources.GetObject("MenuItem13.ShowShortcut"), Boolean)
        Me.MenuItem13.Text = resources.GetString("MenuItem13.Text")
        Me.MenuItem13.Visible = CType(resources.GetObject("MenuItem13.Visible"), Boolean)
        '
        'MenuItem14
        '
        Me.MenuItem14.Enabled = CType(resources.GetObject("MenuItem14.Enabled"), Boolean)

        Me.MenuItem14.ShortcutKeys = CType(System.Convert.ToInt32(resources.GetObject("MenuItem14.Shortcut")), System.Windows.Forms.Keys)
        Me.MenuItem14.ShowShortcutKeys = CType(resources.GetObject("MenuItem14.ShowShortcut"), Boolean)
        Me.MenuItem14.Text = resources.GetString("MenuItem14.Text")
        Me.MenuItem14.Visible = CType(resources.GetObject("MenuItem14.Visible"), Boolean)
        '
        'MenuItem15
        '
        Me.MenuItem15.Enabled = CType(resources.GetObject("MenuItem15.Enabled"), Boolean)

        Me.MenuItem15.ShortcutKeys = CType(System.Convert.ToInt32(resources.GetObject("MenuItem15.Shortcut")), System.Windows.Forms.Keys)
        Me.MenuItem15.ShowShortcutKeys = CType(resources.GetObject("MenuItem15.ShowShortcut"), Boolean)
        Me.MenuItem15.Text = resources.GetString("MenuItem15.Text")
        Me.MenuItem15.Visible = CType(resources.GetObject("MenuItem15.Visible"), Boolean)
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.Filter = resources.GetString("OpenFileDialog1.Filter")
        Me.OpenFileDialog1.Title = resources.GetString("OpenFileDialog1.Title")
        '
        'HelpProvider1
        '
        Me.HelpProvider1.HelpNamespace = resources.GetString("HelpProvider1.HelpNamespace")
        '
        'Form1
        '
        Me.AccessibleDescription = resources.GetString("$this.AccessibleDescription")
        Me.AccessibleName = resources.GetString("$this.AccessibleName")
        Me.AutoScaleBaseSize = CType(resources.GetObject("$this.AutoScaleBaseSize"), System.Drawing.Size)
        Me.AutoScroll = CType(resources.GetObject("$this.AutoScroll"), Boolean)
        Me.AutoScrollMargin = CType(resources.GetObject("$this.AutoScrollMargin"), System.Drawing.Size)
        Me.AutoScrollMinSize = CType(resources.GetObject("$this.AutoScrollMinSize"), System.Drawing.Size)
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = CType(resources.GetObject("$this.ClientSize"), System.Drawing.Size)
        Me.Controls.Add(Me.cmdWPS)
        Me.Controls.Add(Me.cmdWHB)
        Me.Controls.Add(Me.cmdST)
        Me.Controls.Add(Me.cmdAFC)
        Me.Controls.Add(Me.Command3)
        Me.Controls.Add(Me.Command2)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.Text1)
        Me.Controls.Add(Me.Combo1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Enabled = CType(resources.GetObject("$this.Enabled"), Boolean)
        Me.Font = CType(resources.GetObject("$this.Font"), System.Drawing.Font)
        Me.ForeColor = System.Drawing.SystemColors.WindowText
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.HelpButton = True
        Me.HelpProvider1.SetHelpKeyword(Me, resources.GetString("$this.HelpKeyword"))
        Me.HelpProvider1.SetHelpNavigator(Me, CType(resources.GetObject("$this.HelpNavigator"), System.Windows.Forms.HelpNavigator))
        Me.HelpProvider1.SetHelpString(Me, resources.GetString("$this.HelpString"))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.ImeMode = CType(resources.GetObject("$this.ImeMode"), System.Windows.Forms.ImeMode)
        Me.KeyPreview = True
        Me.Location = CType(resources.GetObject("$this.Location"), System.Drawing.Point)
        Me.MaximizeBox = False
        Me.MaximumSize = CType(resources.GetObject("$this.MaximumSize"), System.Drawing.Size)
        Me.MainMenuStrip = Me.MainMenu1
        Me.Controls.Add(Me.MainMenu1)
        Me.MinimizeBox = False
        Me.MinimumSize = CType(resources.GetObject("$this.MinimumSize"), System.Drawing.Size)
        Me.Name = "Form1"
        Me.RightToLeft = CType(resources.GetObject("$this.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.HelpProvider1.SetShowHelp(Me, CType(resources.GetObject("$this.ShowHelp"), Boolean))
        Me.StartPosition = CType(resources.GetObject("$this.StartPosition"), System.Windows.Forms.FormStartPosition)
        Me.Text = resources.GetString("$this.Text")
        Me.ToolTip1.SetToolTip(Me, resources.GetString("$this.ToolTip"))
        For Each control In mnuGuida.Values
            AddHandler control.DropDownOpening, AddressOf mnuGuida_Popup
        Next
        For Each control In mnuGuida.Values
            AddHandler control.Click, AddressOf mnuGuida_Click
        Next
        For Each control In mnuStamLib.Values
            AddHandler control.DropDownOpening, AddressOf mnuStamLib_Popup
        Next
        For Each control In mnuStamLib.Values
            AddHandler control.Click, AddressOf mnuStamLib_Click
        Next
        For Each control In mnuTerm.Values
        Next
        For Each control In mnuTerm.Values
            AddHandler control.Click, AddressOf mnuTerm_Click
        Next
        For Each control In mnuUltAgg.Values
            AddHandler control.DropDownOpening, AddressOf mnuUltAgg_Popup
        Next
        For Each control In mnuUltAgg.Values
            AddHandler control.Click, AddressOf mnuUltAgg_Click
        Next
        For Each control In mnuUt.Values
            AddHandler control.DropDownOpening, AddressOf mnuUt_Popup
        Next
        For Each control In mnuUt.Values
            AddHandler control.Click, AddressOf mnuUt_Click
        Next
        Me.ResumeLayout(False)

    End Sub
#End Region
#Region "Supporto aggiornamento "
    Private Shared m_vb6FormDefInstance As Form1
    Private Shared m_InitializingDefInstance As Boolean
    Public Shared Property DefInstance() As Form1
        Get
            If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
                m_InitializingDefInstance = True
                m_vb6FormDefInstance = New Form1
                m_InitializingDefInstance = False
            End If
            DefInstance = m_vb6FormDefInstance
        End Get
        Set(ByVal Value As Form1)
            m_vb6FormDefInstance = Value
        End Set
    End Property
#End Region
    Private Declare Sub Sleep Lib "kernel32" (ByVal dwMilliseconds As Integer)
    Private Risul As String
    Public Sub cmdExit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdExit.Click
        Hide()
        Timer1.Enabled = False
        System.Windows.Forms.Application.DoEvents()
        Dispose()
    End Sub
    Private Sub Combo1_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Combo1.SelectedIndexChanged
        Dim Num As String
        Dim iVolta As Short
        Dim localOpen As Boolean
        On Error GoTo ErrCombo
        If GiafattoB Then Exit Sub
        GiaFatto = False : GiafattoB = False ': GiaFattoA = False
        If ErrCommesse Then
            Utente.Nome = "non definito"
            Num = "01"
        Else
            If MyDatabase Is Nothing Then
                MyDatabase = New OleDbConnection(Conn & MyFile & ConnFine)
                localOpen = True
            End If
            cmd = New OleDbDataAdapter("SELECT * FROM Utenti WHERE Utente = '" & Trim(Combo1.Text) & "'", MyDatabase)
            cmd.Fill(MyTable)
            CB = New OleDbCommandBuilder(cmd)
            Utente.Nome = CStr(MyTable.Rows(0)("Utente"))
            MostraPW()
            If Convalidato = 0 Then Exit Sub
            Num = CInt((MyTable.Rows(0)("IDNumber"))).ToString
            MyTable.Dispose()
            If Num.Length = 1 Then Num = "0" & Num Else Num = Num.Substring(Num.Length - 2, 2)
        End If
        With Monitor.Motore.Inizio
            .WriteIniFile("", "Utente", "Utente", Utente.Nome)
            .ImmedStam = CShort(Combo1.SelectedIndex + 1)
            .Utente = Utente.Nome
            If .TipoStam < 1 Or .TipoStam > 3 Then .TipoStam = 1
        End With
        If localOpen Then
            MyDatabase.Dispose()
        End If
        Exit Sub
ErrCombo:
        If Err.Number = 53 And iVolta = 0 Then
            MsgBox("Combo1_Click" & ErrorToString())
            Resume Next
        ElseIf Erl() = 200 Then
            Resume Next
        Else
            MsgBox("Combo1_Click" & ErrorToString())
            Resume Next
        End If
    End Sub
    Private Sub Command2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command2.Click
        Dim nUtente As String
        Dim ID As Short
        Dim localOpen As Boolean
        If ErrCommesse Then Exit Sub
        If MyDatabase Is Nothing Then
            localOpen = True
            MyDatabase = New OleDbConnection(Conn & MyFile & ConnFine)
        End If
        Form2.DefInstance.NuovoUtente = True
        Form2.DefInstance.ShowDialog()
        If Convalidato = 0 Then GoTo Fine
        nUtente = Form2.DefInstance.Text1.Text
        cmd = New OleDbDataAdapter("SELECT * FROM Utenti WHERE Utente like " & Chr(34) & nUtente & Chr(34), MyDatabase)
        cmd.Fill(MyTable)
        If MyTable.Rows.Count > 0 Then
            MyTable.Dispose()
            MsgBox("l'utente " & nUtente & " è già registrato", MsgBoxStyle.Critical)
            GoTo Fine
        End If
        MyTable.Dispose()
        cmd = New OleDbDataAdapter("SELECT * FROM Utenti ORDER By IDNumber", MyDatabase)
        cmd.Fill(MyTable)
        CB = New OleDbCommandBuilder(cmd)
        Dim dvMyTable As New DataView(MyTable)
        ID = CShort(dvMyTable(dvMyTable.Count - 1)("IDNumber"))
        Dim drv As DataRowView = dvMyTable.AddNew
        drv("Utente") = nUtente
        drv("IDNumber") = ID + 1
        drv.EndEdit()
        cmd.Update(MyTable)
        MyTable.AcceptChanges()
        AggCombo()
        GiafattoB = True
        UtStan()
Fine:
        Form2.DefInstance.Close()
        If localOpen Then
            MyDatabase.Dispose()
        End If
    End Sub

    Private Sub Command3_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command3.Click
        Dim Strin() As String
        Dim i, iQ As Short
        Dim localOpen As Boolean
        If ErrCommesse Then Exit Sub
        If MyDatabase Is Nothing Then
            localOpen = True
            MyDatabase = New OleDbConnection(Conn & MyFile & ConnFine)
        End If
        cmd = New OleDbDataAdapter("SELECT * FROM Utenti ORDER By Utente", MyDatabase)
        cmd.Fill(MyTable)
        CB = New OleDbCommandBuilder(cmd)
        ReDim Strin(MyTable.Rows.Count)
        For i = 0 To CShort(MyTable.Rows.Count - 1)
            Strin(i + 1) = CStr(MyTable.Rows(i)("Utente"))
        Next
        iQ = Monitor.Motore.Quale(CShort((MyTable.Rows.Count)), "Eliminazione Utente", Strin, "", 0)
        If MsgBox("Si conferma la cancellazione di " & CStr(MyTable.Rows(iQ - 1)("Utente")) & "?", CType(MsgBoxStyle.Question + MsgBoxStyle.YesNo, MsgBoxStyle), "Lancio") = MsgBoxResult.Yes Then
            MyTable.DefaultView.Delete(iQ - 1)
            cmd.Update(MyTable)
        End If
        AggCombo()
        GiafattoB = True
        UtStan()
        If localOpen Then
            MyTable.Dispose()
            cmd.Dispose()
            MyDatabase.Dispose()
        End If
    End Sub
    Private Sub Form1_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
        If NonValido Then cmdExit_Click(cmdExit, New System.EventArgs) : Exit Sub
        If (UBound(Diagnostics.Process.GetProcessesByName(Diagnostics.Process.GetCurrentProcess.ProcessName)) > 0) Then
            MsgBox("Esiste già un'istanza in esecuzione di Lancio", MsgBoxStyle.Critical, "Lancio")
            cmdExit_Click(cmdExit, New System.EventArgs)
            Exit Sub
        End If
        Features()
        If Not Convalidato = 0 Or Not Monitor.Motore.Inizio.InRete Then
            If Not Monitor.Motore.Inizio.InRete Then
                Command2.Visible = False
                Command3.Visible = False
                Combo1.Visible = False
                Text1.Visible = False
            End If
            Exit Sub
        End If
        Convalida()
    End Sub
    Private Sub Form1_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Dim iRec As Short
        Dim Task, Testo As String
        Dim Param, drive As String
        Dim iErr As Short
        Dim ifl As Short
        If Monitor Is Nothing Then Exit Sub
        ErrCommesse = False
        With Monitor.Motore.Inizio
            If .InRete Then
                Try
                    MyFile = RTrim(.Archdir) & "\Gestione\Commesse.MDB"
                    MyDatabase = New OleDbConnection(Conn & MyFile & ConnFine)
                Catch
                    Testo = "Non è possibile aprire in lettura il file " & MyFile & "." & vbCrLf
                    Testo = Testo & "E' possibile che vi siano stati degli errori di istallazione." & vbCrLf
                    Testo = Testo & "E' possibile che il file <System>\LANCIO.INI contenga dati erronei." & vbCrLf
                    Testo = Testo & "Nel caso di istallazione autonoma l'esecuzione può continuare, anche se senza accesso al modulo Gest." & vbCrLf
                    Testo = Testo & "(Errore n°:" & Str(Err.Number) & "; " & Err.Description & ")"
                    MsgBox(Testo, MsgBoxStyle.Information)
                    '    LanProg(6).Visible = False
                    Command2.Visible = False
                    Command3.Visible = False
                    ErrCommesse = True
                End Try
                AggCombo()
                Try
                    UtStan()
                Catch
                    MsgBox(ErrorToString() & " (" & Str(Err.Number) & "," & Str(Erl()) & ")")
                    NonValido = True
                    Exit Sub
                End Try
                If Convalidato = 0 Then
                    NonValido = True
                    Exit Sub
                End If
            Else
                mnuPW.Enabled = False
            End If
            Try
                If Not EsitoStd = 3 And Not .ReadIniFile("", "Avvio", "Commesse") = "No" And MyDatabase Is Nothing Then
                    MyFile = RTrim(.Archdir) & "\Gestione\Commesse.MDB"
                    MyDatabase = New OleDbConnection(Conn & MyFile & ConnFine)
                End If
            Catch
            End Try
        End With
        Try
            If Not MyDatabase Is Nothing Then
                If Not MyTable Is Nothing Then MyTable.Dispose()
                MyDatabase.Dispose()
            End If
        Catch
            Testo = "Non è possibile aprire in lettura il file " & MyFile & "." & vbCrLf
            Testo = Testo & "E' possibile che vi siano stati degli errori di istallazione." & vbCrLf
            Testo = Testo & "E' possibile che il file <System>\LANCIO.INI contenga dati erronei." & vbCrLf
            Testo = Testo & "Nel caso di istallazione autonoma l'esecuzione può continuare, anche se senza accesso al modulo Gest." & vbCrLf
            Testo = Testo & "(Errore n°:" & Str(Err.Number) & "; " & Err.Description & ")"
            MsgBox(Testo, MsgBoxStyle.Information)
            ' LanProg(6).Visible = False
            Command2.Visible = False
            Command3.Visible = False
            ErrCommesse = True
        End Try
    End Sub
    Public Sub mecBocchelli_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mecBocchelli.DropDownOpening
        mecBocchelli_Click(eventSender, eventArgs)
    End Sub
    Public Sub mecBocchelli_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mecBocchelli.Click
        LanciaProg(1)
    End Sub

    Public Sub mecBreLoc_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mecBreLoc.DropDownOpening
        mecBreLoc_Click(eventSender, eventArgs)
    End Sub
    Public Sub mecBreLoc_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mecBreLoc.Click
        LanciaProg(21)
    End Sub

    Public Sub mecConi_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mecConi.DropDownOpening
        mecConi_Click(eventSender, eventArgs)
    End Sub
    Public Sub mecConi_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mecConi.Click
        LanciaProg(18)
    End Sub
    Public Sub mecMantelli_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mecMantelli.DropDownOpening
        mecMantelli_Click(eventSender, eventArgs)
    End Sub
    Public Sub mecMantelli_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mecMantelli.Click
        LanciaProg(3)
    End Sub
    Public Sub mecOrecchie_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mecOrecchie.DropDownOpening
        mecOrecchie_Click(eventSender, eventArgs)
    End Sub
    Public Sub mecOrecchie_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mecOrecchie.Click
        LanciaProg(16)
    End Sub
    Public Sub mecSelle_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mecSelle.DropDownOpening
        mecSelle_Click(eventSender, eventArgs)
    End Sub
    Public Sub mecSelle_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mecSelle.Click
        objBSDD = New Saddles.clsBSDD
        objBSDD.DoveMotore = Monitor.Motore
        objBSDD.DoveRoutines = Routines
        objBSDD.Esegui(0, "")
    End Sub
    Public Sub mecSerraggio_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mecSerraggio.DropDownOpening
        mecSerraggio_Click(eventSender, eventArgs)
    End Sub
    Public Sub mecSerraggio_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mecSerraggio.Click
        LanciaProg(17)
    End Sub
    Public Sub mnuAree_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuAree.DropDownOpening
        mnuAree_Click(eventSender, eventArgs)
    End Sub
    Public Sub mnuAree_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuAree.Click
        If Not Monitor.Motore.Aree(Abilitato) Then cmdExit_Click(cmdExit, New System.EventArgs)
    End Sub

    Public Sub mnuASME_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuASME.DropDownOpening
        mnuASME_Click(eventSender, eventArgs)
    End Sub
    Public Sub mnuASME_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuASME.Click
        Dim Mat As LibMat.MaterialeNew1
        If MsgBox("Assumo che tu sappia esattamente che cosa stai facendo.", MsgBoxStyle.OKCancel, "Lancio") = MsgBoxResult.Cancel Then Exit Sub
        Mat = New LibMat.MaterialeNew1
        Mat.SuperUpDate()
    End Sub

    Public Sub mnuFlange_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuFlange.DropDownOpening
        mnuFlange_Click(eventSender, eventArgs)
    End Sub
    Public Sub mnuFlange_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuFlange.Click
        Dim Flangia As Grafica.Flangia
        Me.Cursor.Current = System.Windows.Forms.Cursors.AppStarting
        Try
            Flangia = New Grafica.Flangia
            Flangia.DoveMotore = Monitor.Motore
            Me.Cursor.Current = System.Windows.Forms.Cursors.Default
            'fatto nel'inizializzazioneFlangia.K1 = 1 : Flangia.K2 = 1 : Flangia.K3 = 1 : Flangia.Facing = 1
            Flangia.Scelta(Monitor.Motore.Inizio.DiscoRam)
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub

    Public Sub mnuGuarn_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuGuarn.DropDownOpening
        mnuGuarn_Click(eventSender, eventArgs)
    End Sub
    Public Sub mnuGuarn_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuGuarn.Click
        Dim Mat As LibMat.clsGuarn
        Mat = New LibMat.clsGuarn
        Mat.Scelta(Monitor.Motore.Inizio.Archdir, Monitor.Motore.Inizio.DiscoTem)
    End Sub

    Public Sub mnuGuida_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        mnuGuida_Click(eventSender, eventArgs)
    End Sub
    Public Sub mnuGuida_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Dim Index As Short = IndexedControls.IndexOf(mnuGuida, CType(eventSender, ToolStripMenuItem))
        Dim Rad As String
        Dim Desc, Versione, Disc As String
        Dim VersionInfo As System.Diagnostics.FileVersionInfo
        Rad = System.IO.Path.GetDirectoryName(RadiceHelp) & "\"
        Select Case Index
            Case 0
                Help.ShowHelp(Me, RadiceHelp, HelpNavigator.TableOfContents)
            Case 1
                VersionInfo = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location)
                Versione = VersionInfo.FileMajorPart & "." & VersionInfo.FileMinorPart & "." & VersionInfo.FileBuildPart & "." & VersionInfo.FilePrivatePart
                Desc = "Ambiente di gestione di applicazioni utilizzate per la progettazione di apparecchi di scambio termico e recipienti a pressione."
                Disc = "Gli autori si rimettono all'indulgenza degli utilizzatori"
                Monitor.Motore.Informazioni(Me, Reflection.Assembly.GetExecutingAssembly)
        End Select
    End Sub
    Public Sub mnuMateriali_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuMateriali.DropDownOpening
        mnuMateriali_Click(eventSender, eventArgs)
    End Sub
    Public Sub mnuMateriali_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuMateriali.Click
        Dim Mat As LibMat.MaterialeNew1
        Mat = New LibMat.MaterialeNew1
        Mat.Agganciato = True
        Try
            Mat.Scelta(0, Monitor.Motore.Inizio.Archdir, Monitor.Motore.Inizio.DiscoTem)
        Catch e As Exception
            MsgBox("Errore in chiamata a libreria materiali " & vbCrLf & e.ToString, CType(MsgBoxStyle.OKOnly + MsgBoxStyle.Critical, MsgBoxStyle))
        End Try
    End Sub

    Public Sub mnuPersAz_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuPersAz.DropDownOpening
        mnuPersAz_Click(eventSender, eventArgs)
    End Sub
    Public Sub mnuPersAz_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuPersAz.Click
        frmPers.DefInstance.ShowDialog()
        frmPers.DefInstance.Close()
    End Sub
    Public Sub mnuPiping_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuPiping.DropDownOpening
        mnuPiping_Click(eventSender, eventArgs)
    End Sub
    Public Sub mnuPiping_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuPiping.Click
        Dim Mat As LibMat.clsPipe
        Mat = New LibMat.clsPipe
        Mat.DoveMotore = Monitor.Motore
        Mat.Scelta(Monitor.Motore.Inizio.Archdir, Monitor.Motore.Inizio.DiscoTem)
    End Sub
    Public Sub mnuPPgas_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        mnuPPgas_Click(eventSender, eventArgs)
    End Sub
    Public Sub mnuPPgas_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuPPgas.Click
        ShowNotImplemented("Fumi di combustione")
        Return
        ' Dim objPpg As Ppgas.clsPpg
        Dim Fluido As String
        'objPpg = New Ppgas.clsPpg
        '     objPpg.DoveMotore = Monitor.Motore
        'objPpg.Inizia()
        'objPpg.mostra(0, Fluido)
    End Sub

    Public Sub mnuPPSM_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        mnuPPSM_Click(eventSender, eventArgs)
    End Sub
    Public Sub mnuPPSM_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuPPSM.Click
        ShowNotImplemented("PPSM")
        Return
        ' objPPSM = New PPSM.clsPPSM
        '    objPPSM.DoveMotore = Monitor.Motore
        'objPPSM.EseguiSciolto()
    End Sub
    Public Sub mnuPW_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuPW.DropDownOpening
        mnuPW_Click(eventSender, eventArgs)
    End Sub
    Public Sub mnuPW_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuPW.Click
        If ErrCommesse Then Exit Sub
        MyDatabase = New OleDbConnection(Conn & MyFile & ConnFine)
        cmd = New OleDbDataAdapter("SELECT * FROM Utenti WHERE Utente = " & Chr(34) & Trim(Combo1.Text) & Chr(34), MyDatabase)
        cmd.Fill(MyTable)
        Utente.Nome = CStr(MyTable.Rows(0)("Utente"))
        MostraPW()
        MyTable.Dispose()
        MyDatabase.Dispose()
    End Sub

    Public Sub mnuRegole_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuRegole.DropDownOpening
        mnuRegole_Click(eventSender, eventArgs)
    End Sub
    Public Sub mnuRegole_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuRegole.Click
        Dim Mat As LibMat.MaterialeNew1
        If MsgBox("Assumo che tu sappia esattamente che cosa stai facendo.", MsgBoxStyle.OKCancel, "Lancio") = MsgBoxResult.Cancel Then Exit Sub
        Mat = New LibMat.MaterialeNew1
        Mat.RegoleMDMT()
    End Sub

    Public Sub mnuStamLib_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        mnuStamLib_Click(eventSender, eventArgs)
    End Sub
    Public Sub mnuStamLib_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Dim Index As Short = IndexedControls.IndexOf(mnuStamLib, CType(eventSender, ToolStripMenuItem))
        Dim Mat As LibMat.MaterialeNew1
        Select Case Index
            Case 0 'stampa materiali
                Mat = New LibMat.MaterialeNew1
                Mat.Stampa()
            Case 1 ' stampa flange
                ShowNotImplemented("Stampa libreria flange")
        End Select
    End Sub

    Public Sub mnuStdPIP_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuStdPip.DropDownOpening
        mnuStdPIP_Click(eventSender, eventArgs)
    End Sub
    Public Sub mnuStdPIP_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuStdPip.Click
        Dim strS As String
        Dim StandardPiping As Short
        Dim Nin, i As Short
        Dim Tit As String
        Dim Strin1(10) As String
        Dim Aiuto As String
        Dim Testo As String
        With Monitor.Motore
            strS = .Inizio.ReadIniFile("", "Parametri", "StandardPiping")
            StandardPiping = CShort(Val(strS))
            Nin = CShort(IDHS.PIP_NINPUT)
            For i = 1 To Nin
                Strin1(i) = Monitor.Motore.HelpStringaG(IDHS.PIP_BASE + i - 1)
            Next
            Testo = Monitor.Motore.HelpStringaG(IDHS.PIP_HELP)
            Aiuto = RadiceHelp
            Tit = Monitor.Motore.HelpStringaG(IDHS.PIP_TITLE)
            If StandardPiping < 0 Then StandardPiping = 0
            StandardPiping = CShort(.Quale(Nin, Tit, Strin1, Aiuto, CShort(StandardPiping + 1), CStr(Testo), , IDHS.PIP_HELP) - 1)
            strS = Str(StandardPiping)
            .Inizio.WriteIniFile("", "Parametri", "StandardPiping", strS)
        End With
    End Sub

    Public Sub mnuTerm_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        mnuTerm_Click(eventSender, eventArgs)
    End Sub
    Public Sub mnuTerm_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Dim Index As Short = IndexedControls.IndexOf(mnuTerm, CType(eventSender, ToolStripMenuItem))
        Select Case Index
            Case 0 : LanciaProg(19)
            Case 1 : LanciaProg(15)
            Case 2 : LanciaProg(14)
            Case 3 : LanciaProg(13)
            Case 4
                ShowNotImplemented("LigTem")
                'objLigTem = New LigTem.clsLigTemp
                '      objLigTem.DoveMotore = Monitor.Motore
                'objLigTem.Esegui()
            Case 5
                ShowNotImplemented("Fire")
                ' objWallT = New Fire.clsWallT
                '      objWallT.DoveMotore = Monitor.Motore
                ' objWallT.Esegui(False)
        End Select
    End Sub
    Public Sub mnuTipLav_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuTipLav.DropDownOpening
        mnuTipLav_Click(eventSender, eventArgs)
    End Sub
    Public Sub mnuTipLav_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuTipLav.Click
        Monitor.Motore.SetLavoriSciolti()
    End Sub
    Public Sub mnuTiranti_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuTiranti.DropDownOpening
        mnuTiranti_Click(eventSender, eventArgs)
    End Sub
    Public Sub mnuTiranti_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuTiranti.Click
        Dim Mat As LibMat.clsTira
        Mat = New LibMat.clsTira
        Mat.Scelta(Monitor.Motore.Inizio.Archdir, Monitor.Motore.Inizio.DiscoTem)
    End Sub
    Public Sub mnuTracciature_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuTracciature.DropDownOpening
        mnuTracciature_Click(eventSender, eventArgs)
    End Sub
    Public Sub mnuTracciature_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuTracciature.Click
        Dim m As clsMotore = Monitor.Motore
        Monitor = New clsMonitor
        Monitor.Motore = m
        objTraccia = New traccia.clsTracciatura
        objTraccia.DoveMotore = Monitor.Motore
        objTraccia.Esegui(0, "")
    End Sub

    Public Sub mnuTubi_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuTubi.DropDownOpening
        mnuTubi_Click(eventSender, eventArgs)
    End Sub
    Public Sub mnuTubi_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuTubi.Click
        Dim objBWG As New LibMat.clsBWG
        objBWG.DoveMotore = Monitor.Motore
        objBWG.Mostra()
    End Sub

    Public Sub mnuUltAgg_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        mnuUltAgg_Click(eventSender, eventArgs)
    End Sub
    Public Sub mnuUltAgg_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Dim Index As Short = IndexedControls.IndexOf(mnuUltAgg, CType(eventSender, ToolStripMenuItem))
        Dim Stringa(10) As String
        Dim Result(10) As String
        Dim Ris As Boolean
        Dim Archiv(10) As Short
        Dim dAiu(10) As String
        Dim File As String
        Select Case Index
            Case 0
                Result(1) = Monitor.Motore.Inizio.ReadIniFile("", "Preferenze AsmeVip", "Division1")
                Result(2) = Monitor.Motore.Inizio.ReadIniFile("", "Preferenze AsmeVip", "Division2")
                Stringa(1) = "ASME VIII div.1"
                Stringa(2) = "ASME VIII div.2"
                Ris = Monitor.Motore.InputDati(2, "AsmeVip- Codici applicabili", Stringa, Result, "", Archiv, dAiu)
                If Ris Then
                    Monitor.Motore.Inizio.WriteIniFile("", "Preferenze AsmeVip", "Division1", Result(1))
                    Monitor.Motore.Inizio.WriteIniFile("", "Preferenze AsmeVip", "Division2", Result(2))
                End If
            Case 1
                Dim Mat As New LibMat.MaterialeNew1
                Mat.Edizioni(UltimoAggiornamento, File)
                Monitor.Motore.Inizio.WriteIniFile("", "Parametri", "UltimoAggiornamento", Str(UltimoAggiornamento))
        End Select
    End Sub

    Public Sub mnuUt_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        mnuUt_Click(eventSender, eventArgs)
    End Sub
    Public Sub mnuUt_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Dim Index As Short = IndexedControls.IndexOf(mnuUt, CType(eventSender, ToolStripMenuItem))
        Dim File As String
        Dim h As New RoutBase1.HHHelp.HTMLHelp
        Select Case Index
            Case 0 'registrazione .chm
                If MsgBox("Assumo che tu sappia esattamente che cosa stai facendo.", MsgBoxStyle.OKCancel, "Lancio") = MsgBoxResult.Cancel Then Exit Sub
                With OpenFileDialog1
                    .Filter = "HTMLHelp file (*.chm)|*.chm"
                    .ShowDialog()
                    File = .FileName
                End With
                h.HHRegister(File)
        End Select
    End Sub

    Public Sub mnuVentilatori_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        mnuVentilatori_Click(eventSender, eventArgs)
    End Sub
    Public Sub mnuVentilatori_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuVentilatori.Click
        ShowNotImplemented("Ventilatori")
        Return
        ''''Dim objVentil As Ventil.clsVentil
        'objventil = New Ventil.clsVentil
        '  objventil.DoveMotore = Monitor.Motore
        'objventil.Inizia()
        'objventil.Curvasciolta()
        '''objventil.Class_Terminate
        '''Set objventil = Nothing
    End Sub
    Public Sub terAcqua_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        terAcqua_Click(eventSender, eventArgs)
    End Sub
    Public Sub terAcqua_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles terAcqua.Click
        ShowNotImplemented("Acqua-Vapore")
        Return
        ' Dim objVap As New VapAcqua.clsVapAcqua
        '  objVap.DoveMotore = Monitor.Motore
        ' objVap.Inizia()
        ' objVap.Mostra()
    End Sub
    Public Sub terPetrol_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        terPetrol_Click(eventSender, eventArgs)
    End Sub
    Public Sub terPetrol_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles terPetrol.Click
        ShowNotImplemented("Fluidi petroliferi")
        Return
        'Dim objWald As New Wald.clsWald
        Monitor.Motore.Inizio.LavoriSciolti = True
        '    objWald.DoveMotore = Monitor.Motore
        'objWald.Inizia()
        ' objWald.Esegui()
    End Sub
    Private Sub Timer1_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Timer1.Tick
        Dim i, j As Short
        Dim p As New Process
        p = p.GetCurrentProcess
        Dim localAll() As Process = p.GetProcesses()
        For i = 1 To 30
            If Programma(i) <> 0 Then
                For j = 0 To CShort(UBound(localAll))
                    If InStr(UCase(localAll(j).ProcessName), UCase(NomeProg(i))) > 0 Then GoTo Cont
                Next
                Programma(i) = 0
            End If
Cont:       '    If i = 22 And Programma(i) > 0 And Not Altri Then 'xfoil
            '   cmdExit.Enabled = True
            '  cmdExit_Click(cmdExit, New System.EventArgs)
            ' Exit Sub
            'End If
        Next
        For i = 1 To 30
            If Programma(i) > 0 Then GoTo Cont1
        Next
        cmdExit.Enabled = True
        Exit Sub
Cont1:  cmdExit.Enabled = False
    End Sub
    Private Sub Convalida()
        If Not Monitor.Motore.Inizio.InRete Then Convalidato = 1 : Exit Sub
        If Len(Risul) = 0 Then Exit Sub
        If ErrCommesse Then Exit Sub
        MyDatabase = New OleDbConnection(Conn & MyFile & ConnFine)
        cmd = New OleDbDataAdapter("SELECT * FROM Utenti WHERE IDNumber = " & Risul, MyDatabase)
        cmd.Fill(MyTable)
        If MyTable.Rows.Count = 0 Then Exit Sub
        Utente.Nome = CStr(MyTable.Rows(0)("Utente"))
        MostraPW()
        MyTable.Dispose()
        MyDatabase.Dispose()
    End Sub
    Private Sub MostraPW()
        Form2.DefInstance.ShowDialog()
        If Convalidato = 0 Then
            Form2.DefInstance.Close()
            Exit Sub
        End If
        Form2.DefInstance.Close()
        Abilitazioni()
    End Sub
    Private Sub Abilitazioni()
        Dim i As Short
        Dim localOpen As Boolean
        Dim A2, A1, A3 As String
        Dim MyTable As DataTable
        Abilitato = (Convalidato = 1)
        cmdAFC.Enabled = Abilitato
        cmdST.Enabled = Abilitato
        cmdWHB.Enabled = Abilitato
        '   cmdWPS.Enabled = Abilitato
        mnuCalc.Enabled = Abilitato
        mnuTermo.Enabled = Abilitato
        mnuTrac.Enabled = Abilitato
        mnuLibrerie.Enabled = Abilitato
        If Not Abilitato Then
            Command2.Visible = Abilitato ' And Monitor.Motore.Inizio.inrete
            Command3.Visible = Abilitato ' And Monitor.Motore.Inizio.inrete
            Exit Sub
        End If
        If ErrCommesse Then Exit Sub
        Abilitato = True
        If MyDatabase Is Nothing Then
            MyDatabase = New OleDbConnection(Conn & MyFile & ConnFine)
            localOpen = True
        End If
        cmd = New OleDbDataAdapter("SELECT * FROM Utenti WHERE Utente ='" & Trim(Utente.Nome) & "'", MyDatabase)
        cmd.Fill(MyTable)
        If Not IsDBNull(MyTable.Rows(0)("Qualif1")) Then A1 = CStr(MyTable.Rows(0)("Qualif1")) Else A1 = ""
        If Not IsDBNull(MyTable.Rows(0)("Qualif2")) Then A2 = CStr(MyTable.Rows(0)("Qualif2")) Else A2 = ""
        If Not IsDBNull(MyTable.Rows(0)("Qualif3")) Then A3 = CStr(MyTable.Rows(0)("Qualif3")) Else A3 = ""
        Abilitato = (A1 = "AA" Or A2 = "AA" Or A3 = "AA")
        Command2.Visible = Abilitato
        Command3.Visible = Abilitato
        MyTable.Dispose()
        If localOpen Then
            MyDatabase.Dispose()
        End If
    End Sub
    Private Sub ShowNotImplemented(commandName As String)
        MessageBox.Show(Me, "NOT IMPLEMENTED" & Environment.NewLine & commandName,
                        "NOT IMPLEMENTED", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
    Public Sub LanciaProg(ByRef indice As Short)
        Select Case indice
            Case 13 : ShowNotImplemented("WHB / BabCock") : Return
            Case 15 : ShowNotImplemented("Surrisc") : Return
            Case 18 : ShowNotImplemented("Coni") : Return
            Case 21 : ShowNotImplemented("BreLock") : Return
        End Select
        Dim i As Short, Testo As String, j As Short
        If Programma(indice) <> 0 Then
            Dim p As New Process
            p = p.GetCurrentProcess
            Dim localAll() As Process = p.GetProcesses()
            For j = 0 To CShort(UBound(localAll))
                If InStr(UCase(localAll(j).ProcessName), UCase(NomeProg(indice))) > 0 Then
                    Testo = "Esiste già un'istanza del programma " & NomeProg(indice) & vbCrLf
                    Testo = Testo & "La vuoi attivare?"
                    If MsgBox(Testo, CType(MsgBoxStyle.Question + MsgBoxStyle.YesNo, MsgBoxStyle), "Lancio") = MsgBoxResult.Yes Then AppActivate(Programma(indice))
                    Exit Sub
                End If
            Next
        End If
        If Not Monitor.Motore.Inizio.PrintInizio Then cmdExit_Click(cmdExit, New System.EventArgs)
        Select Case indice
            Case 1
                Testo = "alla dll Wrcb"
                If Not objWRCB Is Nothing Then
                    MsgBox("Esiste già un'istanza di WRCB in esecuzione")
                    Exit Sub
                End If
                objWRCB = New Wrcb.clsWrcb
                objWRCB.DoveMotore = Monitor.Motore
                objWRCB.DoveRoutines = Routines
                objWRCB.EseguiSciolto()
            Case 3
                Testo = "alla dll AsmeVip"
                If Not objASME Is Nothing Then
                    MsgBox("Esiste già un'istanza di AsmeVip in esecuzione")
                    Exit Sub
                End If
                objASME = New AsmeVip.CalcASME
                objASME.DoveMotore = Monitor.Motore
                objASME.DoveRoutines = Routines
                objASME.DoveFunzioni = Libgra
                objASME.EseguiSciolto()
                WindowState = System.Windows.Forms.FormWindowState.Minimized
            Case 12
                Testo = "al programma ISFT"
                'Programma(indice) = Shell(Monitor.Motore.Inizio.Basedir & "\DataShee.exe -n /" & Monitor.Motore.Inizio.DiscoRam, CType(1, Microsoft.VisualBasic.AppWinStyle))
                'NomeProg(indice) = "ISFT"
                If Not objDataSheet Is Nothing Then
                    MsgBox("Esiste già un'istanza di ISFT in esecuzione")
                    Exit Sub
                End If
                objDataSheet = New DataSheet.clsDataSheet
                objDataSheet.DoveMotore = Monitor.Motore
                objDataSheet.DoveRoutines = Routines
                objDataSheet.DoveFunzioni = Libgra
                objDataSheet.EseguiSciolto()
                WindowState = System.Windows.Forms.FormWindowState.Minimized
            Case 13
                Testo = "alla dll BabCock"
                'objBabC = New BabCock.Calcoli
                '   objBabC.DoveMotore = Monitor.Motore
                '   objBabC.DoveRoutines = Routines
                ' objBabC.EseguiSciolto()
            Case 14
                Testo = "al programma ISA"
                Programma(indice) = Shell(Monitor.Motore.Inizio.Basedir & "\HTRI5.exe -n", CType(1, Microsoft.VisualBasic.AppWinStyle))
                NomeProg(indice) = "ISA"
            Case 15
                Testo = "alla dll Surrisc"
                'objSURR = New Surrisc.clsSurrisc
                '   objSURR.DoveMotore = Monitor.Motore
                'objSURR.EseguiSciolto()
                WindowState = System.Windows.Forms.FormWindowState.Minimized
                NomeProg(indice) = "SURR"
            Case 16
                Testo = "alla dll Orecchia"
                orec = New Orecchia.Calc_Orecchia
                orec.DoveMotore = Monitor.Motore
                orec.DoveRoutines = Routines
                orec.Calcola()
            Case 17
                Testo = "alla dll Tiranti"
                Try
                    objSerraggio = New Tiranti.Serraggio
                Catch e As Exception
                    ErrHandl(Testo)
                    objSerraggio = Nothing
                    Exit Sub
                End Try
                objSerraggio.DoveMotore = Monitor.Motore
                objSerraggio.EseguiSciolto()
                objSerraggio = Nothing
            Case 18
                Testo = "alla dll prgConi"
                'con = New PrgConi.calcConi
                '         con.DoveMotore = Monitor.Motore
                'con.cConi()
                ' con = Nothing
            Case 19
                Testo = "al programma PreRisc"
                Programma(indice) = Shell(Monitor.Motore.Inizio.Basedir & "\PreRisc.exe -n", CType(1, Microsoft.VisualBasic.AppWinStyle))
                NomeProg(indice) = "PRER"
                ''''Case 20
                ''''    Testo = "alla dll OreLav"
                ''' '   objDiap = New OreLav.clsDiap
                ''''  On Error GoTo 0
                '''' objDiap.DoveMotore = Monitor.Motore
                '''' objDiap.Esegui()
                ''''objDiap = Nothing
            Case 21
                Testo = "alla dll BreLock"
                'Bre = New BreLock.clsBreLoc
                '        Bre.DoveMotore = Monitor.Motore
                'Bre.EseguiSciolto()
                ' Bre = Nothing
                ''''  Case 22
                ''''      Timer1.Enabled = False
                ''''     Testo = "al programma Xfoil"
                ''''    Programma(indice) = Shell(Monitor.Motore.Inizio.Basedir & "\WinXfoil.exe", CType(1, Microsoft.VisualBasic.AppWinStyle))
                ''''   NomeProg(indice) = "XFOI"
                ''''  Sleep(100)
                '''' Timer1.Enabled = True
        End Select
        If Programma(indice) <> 0 Then AppActivate(Programma(indice))
    End Sub
    Private Sub ErrHandl(ByRef Testo As String)
        Testo = "Durante l'accesso " & Testo & " si è prodotto il seguente errore:" & vbCrLf
        Testo = Testo & Err.Description
        MsgBox(Testo, MsgBoxStyle.Critical, "Lancio")
    End Sub

    Public Sub AggCombo()
        Dim i As Integer
        Combo1.Items.Clear()
        If MyDatabase Is Nothing Or ErrCommesse Then
            Combo1.Items.Add("non definito")
        Else
            cmd = New OleDbDataAdapter("SELECT * FROM Utenti ORDER By Utente", MyDatabase)
            cmd.Fill(MyTable)
            For i = 0 To MyTable.Rows.Count - 1
                Combo1.Items.Add(CStr(MyTable.Rows(i)("Utente")))
            Next i
        End If
    End Sub
    Public Sub UtStan()
        Dim Param, Risul As String
        Dim iRec As Short
        If MyDatabase Is Nothing Or ErrCommesse Then
            If Combo1.Items.Count > 0 Then Combo1.SelectedIndex = 0
        Else
            Risul = Monitor.Motore.Inizio.ReadIniFile("", "Utente", "Utente")
            '  If Len(Risul) = 0 Then Exit Sub
            If Val(Risul) < 0 Or Val(Risul) > Combo1.Items.Count Then Exit Sub
            Dim dvMytable As New DataView(MyTable)
            dvMytable.Sort = "Utente"
            Dim iFound As Integer = dvMytable.Find(Risul.Trim)
            If iFound = -1 Then
                iFound = dvMytable.Find("Presciuttini")
            End If
            Combo1.SelectedIndex = iFound
        End If
    End Sub

    Public Sub Features()
        Dim Inst As Boolean
        With Monitor.Motore.Inizio
            Inst = .ReadIniFile("", gstrFeatures, "AsmeVip") = gstrSi
            mecMantelli.Enabled = Inst
            mecBocchelli.Enabled = False
            mecSelle.Enabled = False
            mecOrecchie.Enabled = True
            mecSerraggio.Enabled = True
            mecConi.Enabled = False
            mecBreLoc.Enabled = False
            Inst = .ReadIniFile("", gstrFeatures, "ISA") = gstrSi
            cmdAFC.Enabled = Inst
            mnuTerm(2).Enabled = Inst
            mnuVentilatori.Enabled = Inst
            Inst = .ReadIniFile("", gstrFeatures, "IST") = gstrSi
            cmdST.Enabled = Inst
            Inst = .ReadIniFile("", gstrFeatures, "BabCock") = gstrSi
            cmdWHB.Enabled = Inst
            mnuTerm(3).Enabled = Inst
            mnuPPgas.Enabled = Inst
            'Inst = .ReadIniFile("", gstrFeatures, "WPS") = gstrSi
            'cmdWPS.Enabled = Inst
            Inst = .ReadIniFile("", gstrFeatures, "FBMUtil") = gstrSi
            mnuUtDis.Enabled = Inst
            'Inst = .ReadIniFile("", gstrFeatures, "Gest") = gstrSi
            'Inst = .ReadIniFile("", gstrFeatures, "OreLav") = gstrSi
            Inst = .ReadIniFile("", gstrFeatures, "Termici") = gstrSi
            mnuTerm(0).Enabled = Inst
            mnuTerm(1).Enabled = Inst
            _mnuTerm_4.Enabled = Inst
            _mnuTerm_5.Enabled = Inst
            terAcqua.Enabled = Inst
            Inst = .ReadIniFile("", gstrFeatures, "Wald") = gstrSi
            terPetrol.Enabled = Inst
            Inst = .ReadIniFile("", gstrFeatures, "Traccia") = gstrSi
            mnuTrac.Enabled = Inst
            Inst = .ReadIniFile("", gstrFeatures, "BSDD") = gstrSi
            mecSelle.Enabled = Inst
            Inst = .ReadIniFile("", gstrFeatures, "WRCB") = gstrSi
            mecBocchelli.Enabled = Inst
            'Inst = .ReadIniFile("", gstrFeatures, "xFoil") = gstrSi
            Inst = .ReadIniFile("", gstrFeatures, "PPSM") = gstrSi
            mnuPPSM.Enabled = Inst
        End With
    End Sub

    Private Sub mnuUtDis_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuUtDis.Click
        ShowNotImplemented("FBMUtil")
        Return
        WindowState = System.Windows.Forms.FormWindowState.Minimized
        ' Util = New FBMUtil.clsUtil
        'Set Util.DoveInizio = Monitor.Motore.Inizio
        '   Util.DoveMotore = Monitor.Motore
        '   Util.DoveRoutines = Routines
        ' Util.Esegui()

    End Sub

    Private Sub cmdWHB_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdWHB.Click
        LanciaProg(13)
    End Sub
    Private Sub cmdST_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdST.Click
        LanciaProg(12)
    End Sub

    Private Sub cmdAFC_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAFC.Click
        LanciaProg(14)
    End Sub
    Private Sub cmdWPS_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdWPS.Click
        ShowNotImplemented("WPS")
        Return
        '   WPS = New Sald.clsWPS
        '      WPS.DoveInizio = Monitor.Motore.Inizio
        '      WPS.DoveMotore = Monitor.Motore
        '   WPS.Esegui()
    End Sub
    Private Sub mnuAvvio_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuAvvio.Click
        Dim R As String = Monitor.Motore.Inizio.ReadIniFile("", "Avvio", "CheckSystem")
        If R = "No" Then
            R = "Si"
            mnuAvvio.Checked = True
        Else
            R = "No"
            mnuAvvio.Checked = False
        End If
        Monitor.Motore.Inizio.WriteIniFile("", "Avvio", "CheckSystem", R)
    End Sub

    Private Sub mnuGuide_Click(ByVal Index As Short)
        Dim Rad As String
        Dim Desc, Versione, Disc As String
        Dim VersionInfo As System.Diagnostics.FileVersionInfo
        Rad = System.IO.Path.GetDirectoryName(RadiceHelp) & "\"
        Select Case Index
            Case 0
                Help.ShowHelp(Me, Rad & "AsmeVip.chm", HelpNavigator.TableOfContents)
            Case 1
                Help.ShowHelp(Me, Rad & "AiutoBre.chm", HelpNavigator.TableOfContents)
            Case 2
                Help.ShowHelp(Me, Rad & "AiutoBSDD.chm", HelpNavigator.TableOfContents)
            Case 3
                Help.ShowHelp(Me, Rad & "AiutoGest.chm", HelpNavigator.TableOfContents)
            Case 4
                Help.ShowHelp(Me, Rad & "AiutoISA.chm", HelpNavigator.TableOfContents)
            Case 5
                Help.ShowHelp(Me, Rad & "AiutoIST.chm", HelpNavigator.TableOfContents)
            Case 6
                Help.ShowHelp(Me, Rad & "AiutoLigTem.chm", HelpNavigator.TableOfContents)
            Case 7
                Help.ShowHelp(Me, Rad & "AiutoSald.chm", HelpNavigator.TableOfContents)
            Case 8
                Help.ShowHelp(Me, Rad & "AiutoSur.chm", HelpNavigator.TableOfContents)
            Case 9
                Help.ShowHelp(Me, Rad & "AiutoTraccia.chm", HelpNavigator.TableOfContents)
            Case 10
                Help.ShowHelp(Me, Rad & "AiutoVentil.chm", HelpNavigator.TableOfContents)
            Case 11
                Help.ShowHelp(Me, Rad & "AiutoWald.chm", HelpNavigator.TableOfContents)
            Case 12
                Help.ShowHelp(Me, Rad & "AiutoWHB.chm", HelpNavigator.TableOfContents)
            Case 13
                Help.ShowHelp(Me, Rad & "AiutoWRCB.chm", HelpNavigator.TableOfContents)

        End Select
    End Sub

    Private Sub MenuItem2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuItem2.Click
        mnuGuide_Click(0)
    End Sub

    Private Sub MenuItem3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuItem3.Click
        mnuGuide_Click(1)
    End Sub

    Private Sub MenuItem4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuItem4.Click
        mnuGuide_Click(2)
    End Sub

    Private Sub MenuItem5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuItem5.Click
        mnuGuide_Click(3)
    End Sub

    Private Sub MenuItem6_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuItem6.Click
        mnuGuide_Click(4)
    End Sub

    Private Sub MenuItem7_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuItem7.Click
        mnuGuide_Click(5)
    End Sub

    Private Sub MenuItem8_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuItem8.Click
        mnuGuide_Click(6)
    End Sub

    Private Sub MenuItem9_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuItem9.Click
        mnuGuide_Click(7)
    End Sub

    Private Sub MenuItem10_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuItem10.Click
        mnuGuide_Click(8)
    End Sub

    Private Sub MenuItem11_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuItem11.Click
        mnuGuide_Click(9)
    End Sub

    Private Sub MenuItem12_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuItem12.Click
        mnuGuide_Click(10)
    End Sub

    Private Sub MenuItem13_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuItem13.Click
        mnuGuide_Click(11)
    End Sub

    Private Sub MenuItem14_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuItem14.Click
        mnuGuide_Click(12)
    End Sub

    Private Sub MenuItem15_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuItem15.Click
        mnuGuide_Click(13)
    End Sub
End Class