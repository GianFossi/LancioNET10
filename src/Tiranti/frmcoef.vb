Option Strict On
Option Explicit On
Imports Microsoft.VisualBasic
Friend Class frmcoef
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
    Public WithEvents Command2 As System.Windows.Forms.Button
    Public WithEvents Command1 As System.Windows.Forms.Button
    Public WithEvents Text2 As System.Windows.Forms.TextBox
    Public WithEvents Text1 As System.Windows.Forms.TextBox
    Public WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents Label1 As System.Windows.Forms.Label
    'NOTA: la routine seguente è richiesta dalla progettazione Windows Form.
    'Può essere modificata utilizzando la finestra di progettazione Windows Form.
    'Non modificarla mediante l'editor di codice.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmcoef))
        Me.components = New System.ComponentModel.Container
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
        Me.ToolTip1.Active = True
        Me.Command2 = New System.Windows.Forms.Button
        Me.Command1 = New System.Windows.Forms.Button
        Me.Text2 = New System.Windows.Forms.TextBox
        Me.Text1 = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Text = "Coefficiente"
        Me.ClientSize = New System.Drawing.Size(347, 63)
        Me.Location = New System.Drawing.Point(3, 22)
        Me.ControlBox = False
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultLocation
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.Enabled = True
        Me.KeyPreview = False
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowInTaskbar = True
        Me.HelpButton = False
        Me.WindowState = System.Windows.Forms.FormWindowState.Normal
        Me.Name = "frmcoef"
        Me.Command2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Command2.Text = "Annulla"
        Me.Command2.Size = New System.Drawing.Size(113, 17)
        Me.Command2.Location = New System.Drawing.Point(0, 40)
        Me.Command2.TabIndex = 5
        Me.Command2.BackColor = System.Drawing.SystemColors.Control
        Me.Command2.CausesValidation = True
        Me.Command2.Enabled = True
        Me.Command2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command2.TabStop = True
        Me.Command2.Name = "Command2"
        Me.Command1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Command1.Text = "Inserisci"
        Me.Command1.Size = New System.Drawing.Size(113, 17)
        Me.Command1.Location = New System.Drawing.Point(232, 40)
        Me.Command1.TabIndex = 4
        Me.Command1.BackColor = System.Drawing.SystemColors.Control
        Me.Command1.CausesValidation = True
        Me.Command1.Enabled = True
        Me.Command1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command1.TabStop = True
        Me.Command1.Name = "Command1"
        Me.Text2.AutoSize = False
        Me.Text2.Size = New System.Drawing.Size(169, 21)
        Me.Text2.Location = New System.Drawing.Point(176, 16)
        Me.Text2.TabIndex = 1
        Me.Text2.AcceptsReturn = True
        Me.Text2.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Text2.BackColor = System.Drawing.SystemColors.Window
        Me.Text2.CausesValidation = True
        Me.Text2.Enabled = True
        Me.Text2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text2.HideSelection = True
        Me.Text2.ReadOnly = False
        Me.Text2.MaxLength = 0
        Me.Text2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Text2.Multiline = False
        Me.Text2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text2.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Text2.TabStop = True
        Me.Text2.Visible = True
        Me.Text2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Text2.Name = "Text2"
        Me.Text1.AutoSize = False
        Me.Text1.Size = New System.Drawing.Size(169, 19)
        Me.Text1.Location = New System.Drawing.Point(0, 16)
        Me.Text1.TabIndex = 0
        Me.Text1.AcceptsReturn = True
        Me.Text1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Text1.BackColor = System.Drawing.SystemColors.Window
        Me.Text1.CausesValidation = True
        Me.Text1.Enabled = True
        Me.Text1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text1.HideSelection = True
        Me.Text1.ReadOnly = False
        Me.Text1.MaxLength = 0
        Me.Text1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Text1.Multiline = False
        Me.Text1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text1.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Text1.TabStop = True
        Me.Text1.Visible = True
        Me.Text1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Text1.Name = "Text1"
        Me.Label2.Text = "Valore"
        Me.Label2.Size = New System.Drawing.Size(97, 17)
        Me.Label2.Location = New System.Drawing.Point(176, 0)
        Me.Label2.TabIndex = 3
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Enabled = True
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.UseMnemonic = True
        Me.Label2.Visible = True
        Me.Label2.AutoSize = False
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Label2.Name = "Label2"
        Me.Label1.Text = "Nome"
        Me.Label1.Size = New System.Drawing.Size(129, 17)
        Me.Label1.Location = New System.Drawing.Point(8, 0)
        Me.Label1.TabIndex = 2
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Enabled = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.UseMnemonic = True
        Me.Label1.Visible = True
        Me.Label1.AutoSize = False
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Label1.Name = "Label1"
        Me.Controls.Add(Command2)
        Me.Controls.Add(Command1)
        Me.Controls.Add(Text2)
        Me.Controls.Add(Text1)
        Me.Controls.Add(Label2)
        Me.Controls.Add(Label1)
    End Sub
#End Region
#Region "Supporto aggiornamento "
    Private Shared m_vb6FormDefInstance As frmcoef
    Private Shared m_InitializingDefInstance As Boolean
    Public Shared Property DefInstance() As frmcoef
        Get
            If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
                m_InitializingDefInstance = True
                m_vb6FormDefInstance = New frmcoef
                m_InitializingDefInstance = False
            End If
            DefInstance = m_vb6FormDefInstance
        End Get
        Set(ByVal Value As frmcoef)
            m_vb6FormDefInstance = Value
        End Set
    End Property
#End Region
    Public Index As Short
    Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
        Dim ListD, ListF As Short
        ClickManuale = True
        With Problem
            .coefft(3).Nome = Text1.Text
            .coefft(3).Coeff = CSng(Text2.Text)
            Select Case Index
                Case 0 : .fDado = .coefft(3).Coeff
                    .coeffindexD = 3
                Case 1 : .fFil = .coefft(3).Coeff
                    .coeffindexF = 3
            End Select
        End With
        With Tir1.DefInstance
            ListD = CShort(._Coeff_0.SelectedIndex)
            ListF = CShort(._Coeff_1.SelectedIndex)
            ._Coeff_0.Items.RemoveAt(3)
            ._Coeff_1.Items.RemoveAt(3)
            ._Coeff_0.Items.Add(Problem.coefft(3).Nome & ": " & Str(Problem.coefft(3).Coeff))
            ._Coeff_1.Items.Add(Problem.coefft(3).Nome & ": " & Str(Problem.coefft(3).Coeff))
            Select Case Index
                Case 0 : ._Coeff_0.SelectedIndex = 3
                    ._Coeff_1.SelectedIndex = ListF
                Case 1 : ._Coeff_1.SelectedIndex = 3
                    ._Coeff_0.SelectedIndex = ListD
            End Select
        End With
        ClickManuale = False
        Me.Close()
    End Sub
    Private Sub Command2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command2.Click
        Me.Close()
        Tir1.DefInstance.Enabled = True
    End Sub
    Private Sub frmcoef_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        With Problem
            Text1.Text = .coefft(3).Nome
            Text2.Text = Str(.coefft(3).Coeff)
        End With
    End Sub
End Class