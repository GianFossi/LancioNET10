Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class FormRibs
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
    Public WithEvents Timer1 As System.Windows.Forms.Timer
    Public WithEvents Command1 As System.Windows.Forms.Button
    Public WithEvents _Text3_0 As System.Windows.Forms.TextBox
    Public WithEvents _Text2_0 As System.Windows.Forms.TextBox
    Public WithEvents _Text1_0 As System.Windows.Forms.TextBox
    Public WithEvents Label5 As System.Windows.Forms.Label
    Public WithEvents _Label3_0 As System.Windows.Forms.Label
    Public WithEvents Label4 As System.Windows.Forms.Label
    Public WithEvents _Label2_0 As System.Windows.Forms.Label
    Public WithEvents Label6 As System.Windows.Forms.Label
    Public WithEvents Labely As System.Windows.Forms.Label
    Public WithEvents Labelx As System.Windows.Forms.Label
    Public WithEvents _Label1_0 As System.Windows.Forms.Label
    Public WithEvents Label1 As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    Public WithEvents Label2 As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    Public WithEvents Label3 As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    Public WithEvents Text1 As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
    Public WithEvents Text2 As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
    Public WithEvents Text3 As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
    'NOTA: la routine seguente è richiesta dalla progettazione Windows Form.
    'Può essere modificata utilizzando la finestra di progettazione Windows Form.
    'Non modificarla mediante l'editor di codice.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(FormRibs))
        Me.components = New System.ComponentModel.Container
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
        Me.ToolTip1.Active = True
        Me.Timer1 = New System.Windows.Forms.Timer(components)
        Me.Command1 = New System.Windows.Forms.Button
        Me._Text3_0 = New System.Windows.Forms.TextBox
        Me._Text2_0 = New System.Windows.Forms.TextBox
        Me._Text1_0 = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me._Label3_0 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me._Label2_0 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Labely = New System.Windows.Forms.Label
        Me.Labelx = New System.Windows.Forms.Label
        Me._Label1_0 = New System.Windows.Forms.Label
        Me.Label1 = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
        Me.Label2 = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
        Me.Label3 = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
        Me.Text1 = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(components)
        Me.Text2 = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(components)
        Me.Text3 = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(components)
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Text1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Text2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Text3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Text = "Forature piastra di base"
        Me.ClientSize = New System.Drawing.Size(249, 265)
        Me.Location = New System.Drawing.Point(4, 23)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultLocation
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable
        Me.ControlBox = True
        Me.Enabled = True
        Me.KeyPreview = False
        Me.MaximizeBox = True
        Me.MinimizeBox = True
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowInTaskbar = True
        Me.HelpButton = False
        Me.WindowState = System.Windows.Forms.FormWindowState.Normal
        Me.Name = "FormRibs"
        Me.Timer1.Enabled = False
        Me.Timer1.Interval = 1
        Me.Command1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Command1.Text = "GO"
        Me.Command1.Size = New System.Drawing.Size(65, 25)
        Me.Command1.Location = New System.Drawing.Point(16, 42)
        Me.Command1.TabIndex = 11
        Me.Command1.BackColor = System.Drawing.SystemColors.Control
        Me.Command1.CausesValidation = True
        Me.Command1.Enabled = True
        Me.Command1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command1.TabStop = True
        Me.Command1.Name = "Command1"
        Me._Text3_0.AutoSize = False
        Me._Text3_0.Size = New System.Drawing.Size(40, 19)
        Me._Text3_0.Location = New System.Drawing.Point(124, 184)
        Me._Text3_0.TabIndex = 9
        Me._Text3_0.Text = "Text3"
        Me._Text3_0.AcceptsReturn = True
        Me._Text3_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me._Text3_0.BackColor = System.Drawing.SystemColors.Window
        Me._Text3_0.CausesValidation = True
        Me._Text3_0.Enabled = True
        Me._Text3_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text3_0.HideSelection = True
        Me._Text3_0.ReadOnly = False
        Me._Text3_0.MaxLength = 0
        Me._Text3_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text3_0.Multiline = False
        Me._Text3_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text3_0.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me._Text3_0.TabStop = True
        Me._Text3_0.Visible = True
        Me._Text3_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._Text3_0.Name = "_Text3_0"
        Me._Text2_0.AutoSize = False
        Me._Text2_0.Size = New System.Drawing.Size(40, 19)
        Me._Text2_0.Location = New System.Drawing.Point(124, 216)
        Me._Text2_0.TabIndex = 5
        Me._Text2_0.AcceptsReturn = True
        Me._Text2_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me._Text2_0.BackColor = System.Drawing.SystemColors.Window
        Me._Text2_0.CausesValidation = True
        Me._Text2_0.Enabled = True
        Me._Text2_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text2_0.HideSelection = True
        Me._Text2_0.ReadOnly = False
        Me._Text2_0.MaxLength = 0
        Me._Text2_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text2_0.Multiline = False
        Me._Text2_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text2_0.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me._Text2_0.TabStop = True
        Me._Text2_0.Visible = True
        Me._Text2_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._Text2_0.Name = "_Text2_0"
        Me._Text1_0.AutoSize = False
        Me._Text1_0.Size = New System.Drawing.Size(40, 19)
        Me._Text1_0.Location = New System.Drawing.Point(124, 72)
        Me._Text1_0.TabIndex = 0
        Me._Text1_0.AcceptsReturn = True
        Me._Text1_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me._Text1_0.BackColor = System.Drawing.SystemColors.Window
        Me._Text1_0.CausesValidation = True
        Me._Text1_0.Enabled = True
        Me._Text1_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1_0.HideSelection = True
        Me._Text1_0.ReadOnly = False
        Me._Text1_0.MaxLength = 0
        Me._Text1_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1_0.Multiline = False
        Me._Text1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_0.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me._Text1_0.TabStop = True
        Me._Text1_0.Visible = True
        Me._Text1_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._Text1_0.Name = "_Text1_0"
        Me.Label5.Text = "Label5"
        Me.Label5.Size = New System.Drawing.Size(32, 13)
        Me.Label5.Location = New System.Drawing.Point(88, 144)
        Me.Label5.TabIndex = 10
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Enabled = True
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.UseMnemonic = True
        Me.Label5.Visible = True
        Me.Label5.AutoSize = True
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Label5.Name = "Label5"
        Me._Label3_0.Text = "Label3"
        Me._Label3_0.Size = New System.Drawing.Size(81, 17)
        Me._Label3_0.Location = New System.Drawing.Point(16, 184)
        Me._Label3_0.TabIndex = 8
        Me._Label3_0.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me._Label3_0.BackColor = System.Drawing.SystemColors.Control
        Me._Label3_0.Enabled = True
        Me._Label3_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label3_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label3_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label3_0.UseMnemonic = True
        Me._Label3_0.Visible = True
        Me._Label3_0.AutoSize = False
        Me._Label3_0.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me._Label3_0.Name = "_Label3_0"
        Me.Label4.Text = "Label4"
        Me.Label4.Size = New System.Drawing.Size(32, 13)
        Me.Label4.Location = New System.Drawing.Point(88, 112)
        Me.Label4.TabIndex = 7
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Enabled = True
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.UseMnemonic = True
        Me.Label4.Visible = True
        Me.Label4.AutoSize = True
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Label4.Name = "Label4"
        Me._Label2_0.Text = "Label2"
        Me._Label2_0.Size = New System.Drawing.Size(97, 17)
        Me._Label2_0.Location = New System.Drawing.Point(16, 224)
        Me._Label2_0.TabIndex = 6
        Me._Label2_0.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me._Label2_0.BackColor = System.Drawing.SystemColors.Control
        Me._Label2_0.Enabled = True
        Me._Label2_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label2_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_0.UseMnemonic = True
        Me._Label2_0.Visible = True
        Me._Label2_0.AutoSize = False
        Me._Label2_0.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me._Label2_0.Name = "_Label2_0"
        Me.Label6.Text = "   Inserire valori  > 0"
        Me.Label6.Size = New System.Drawing.Size(186, 24)
        Me.Label6.Location = New System.Drawing.Point(16, 8)
        Me.Label6.TabIndex = 4
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Label6.BackColor = System.Drawing.SystemColors.Control
        Me.Label6.Enabled = True
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.UseMnemonic = True
        Me.Label6.Visible = True
        Me.Label6.AutoSize = True
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Label6.Name = "Label6"
        Me.Labely.BackColor = System.Drawing.SystemColors.Window
        Me.Labely.Text = "   -"
        Me.Labely.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Labely.Size = New System.Drawing.Size(41, 17)
        Me.Labely.Location = New System.Drawing.Point(190, 48)
        Me.Labely.TabIndex = 3
        Me.Labely.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Labely.Enabled = True
        Me.Labely.Cursor = System.Windows.Forms.Cursors.Default
        Me.Labely.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Labely.UseMnemonic = True
        Me.Labely.Visible = True
        Me.Labely.AutoSize = False
        Me.Labely.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Labely.Name = "Labely"
        Me.Labelx.BackColor = System.Drawing.SystemColors.Window
        Me.Labelx.Text = "  +"
        Me.Labelx.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Labelx.Size = New System.Drawing.Size(41, 17)
        Me.Labelx.Location = New System.Drawing.Point(124, 48)
        Me.Labelx.TabIndex = 2
        Me.Labelx.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Labelx.Enabled = True
        Me.Labelx.Cursor = System.Windows.Forms.Cursors.Default
        Me.Labelx.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Labelx.UseMnemonic = True
        Me.Labelx.Visible = True
        Me.Labelx.AutoSize = False
        Me.Labelx.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Labelx.Name = "Labelx"
        Me._Label1_0.Text = "Label1"
        Me._Label1_0.Size = New System.Drawing.Size(97, 17)
        Me._Label1_0.Location = New System.Drawing.Point(8, 80)
        Me._Label1_0.TabIndex = 1
        Me._Label1_0.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me._Label1_0.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_0.Enabled = True
        Me._Label1_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_0.UseMnemonic = True
        Me._Label1_0.Visible = True
        Me._Label1_0.AutoSize = False
        Me._Label1_0.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me._Label1_0.Name = "_Label1_0"
        Me.Controls.Add(Command1)
        Me.Controls.Add(_Text3_0)
        Me.Controls.Add(_Text2_0)
        Me.Controls.Add(_Text1_0)
        Me.Controls.Add(Label5)
        Me.Controls.Add(_Label3_0)
        Me.Controls.Add(Label4)
        Me.Controls.Add(_Label2_0)
        Me.Controls.Add(Label6)
        Me.Controls.Add(Labely)
        Me.Controls.Add(Labelx)
        Me.Controls.Add(_Label1_0)
        Me.Label1.SetIndex(_Label1_0, CType(0, Short))
        Me.Label2.SetIndex(_Label2_0, CType(0, Short))
        Me.Label3.SetIndex(_Label3_0, CType(0, Short))
        Me.Text1.SetIndex(_Text1_0, CType(0, Short))
        Me.Text2.SetIndex(_Text2_0, CType(0, Short))
        Me.Text3.SetIndex(_Text3_0, CType(0, Short))
        CType(Me.Text3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Text2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Text1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
    End Sub
#End Region 
#Region "Supporto aggiornamento "
	Private Shared m_vb6FormDefInstance As FormRibs
	Private Shared m_InitializingDefInstance As Boolean
	Public Shared Property DefInstance() As FormRibs
		Get
			If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
				m_InitializingDefInstance = True
				m_vb6FormDefInstance = New FormRibs()
				m_InitializingDefInstance = False
			End If
			DefInstance = m_vb6FormDefInstance
		End Get
		Set
			m_vb6FormDefInstance = Value
		End Set
	End Property
#End Region 
    Dim k, j, i, j1 As Short
    Private Inizializzando As Boolean
	
	Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
		FormRibs_DoubleClick(Me, New System.EventArgs())
        With CType(Membro, Sella)
            .DistRib1 = RibCL(1)
            .DistRib2 = RibCL(2)
            .DistRib3 = RibCL(3)
        End With
	End Sub
    Private Sub FormRibs_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.DoubleClick
        Dim maxribs As Short
        With CType(Membro, Sella)
            maxribs = .nribs \ 2
            If maxribs <= 0 Then maxribs = 1
            ReDim RibCL(maxribs)
            If Nfori(1) = 0 Then Nfori(1) = 1
            Dim ForiCLLun(2, Nfori(1)) As Single
            i = 0
            If .nribs Mod 2 = 0 Then i = 1
            For j = 1 To .nribs \ 2
                RibCL(j) = GlobalRoutines.ValVir(Text1(j - i).Text)
            Next
            i = 0 : If Nfori(1) Mod 2 = 0 Then i = 1
            For j = 1 To Nfori(1) \ 2
                ForiCLLun(1, j) = GlobalRoutines.ValVir(Text2(j - i).Text)
            Next
            If Not .sempor Then
                i = 0 : If Nfori(2) Mod 2 = 0 Then i = 1
                For j = 1 To Nfori(2) \ 2
                    ForiCLLun(2, j) = GlobalRoutines.ValVir(Text3(j - i).Text)
                Next
            End If
        End With
        Me.Close()
    End Sub


    Private Sub FormRibs_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Dim Ribbs, Foris As Short
        Timer1.Interval = 1000
        Timer1.Enabled = True
        Me.SetBounds(GlobalRoutines.TwipsToPixelsX(5300), GlobalRoutines.TwipsToPixelsY(3000), 0, 0, Windows.Forms.BoundsSpecified.X Or Windows.Forms.BoundsSpecified.Y)
        With CType(Membro, Sella)
            If .nribs Mod 2 = 0 Then
                i = 1
                Label1(0).Text = "Ribs  1 / 2"
            Else
                Label1(0).Text = "Rib   1"
                i = 0
            End If
            Ribbs = .nribs \ 2
            For j = 1 To Ribbs - i
                Label1.Load(j)
                Text1.Load(j)
                Text1(j).Top = Text1(0).Top + j * Text1(0).Height + GlobalRoutines.TwipsToPixelsY(20)
                Label1(j).Top = Text1(j).Top + GlobalRoutines.TwipsToPixelsY(50)
                Label1(j).Left = Label1(0).Left
                Text1(j).Left = Text1(0).Left
                Label1(j).Text = "Ribs  " & j * 2 + i & " / " & j * 2 + i + 1
                Label1(j).Visible = True
                Text1(j).Visible = True
            Next
            Ribbs = (j - 1) * 2 + 1
            i = 0
            If .nribs Mod 2 = 1 Then i = 1
            For j1 = j To Ribbs - i
                Text1.Load(j1)
                Text1(j1).Top = Text1(0).Top + ((j1 - j + i) * Text1(0).Height) + GlobalRoutines.TwipsToPixelsY(20)
                Text1(j1).Left = Text1(0).Left + Text1(0).Width + GlobalRoutines.TwipsToPixelsX(380)
                Text1(j1).Visible = True
                Text1(j1).Enabled = False
            Next
            If i = 1 Then
                Text1(0).Text = " 0"
                Text1(0).Enabled = False
            End If
            If GlobalRoutines.ValVir(DbaseSelle.DefInstance.Text1(16).Text) <> 0 Then
                Text1(0).Text = DbaseSelle.DefInstance.Text1(16).Text
            End If
            If GlobalRoutines.ValVir(DbaseSelle.DefInstance.Text1(17).Text) <> 0 Then
                Text1(1).Text = DbaseSelle.DefInstance.Text1(17).Text
            End If
            If GlobalRoutines.ValVir(DbaseSelle.DefInstance.Text1(18).Text) <> 0 Then
                Text1(2).Text = DbaseSelle.DefInstance.Text1(18).Text
            End If
            Label2(0).Visible = False
            Label4.Visible = False
            Text2(0).Visible = False
            Label5.Visible = False
            Label3(0).Visible = False
            Text3(0).Visible = False
            '<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< FORI <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            If Nfori(1) \ 2 < 2 Then GoTo fori2
            Label2(0).Visible = True
            Label4.Visible = True
            Text2(0).Visible = True
            k = VB6.PixelsToTwipsY(Text1(j1 - 1).Top) + 700
            Label4.Top = GlobalRoutines.TwipsToPixelsY(k)
            Label4.Left = GlobalRoutines.TwipsToPixelsX(500)
            Label4.Text = "INTERASSE FORI BASE INFERIORE"
            k = k + 300
            Label2(0).Top = GlobalRoutines.TwipsToPixelsY(k + 100)
            Text2(0).Top = GlobalRoutines.TwipsToPixelsY(k)
            Label2(0).Left = Label1(0).Left
            Text2(0).Left = Text1(0).Left
            Text2(0).Width = Text1(0).Width
            Label2(0).Width = Label1(0).Width
            Text2(0).Height = Text1(0).Height
            Label2(0).Height = Label1(0).Height
            If Nfori(1) Mod 2 = 0 Then
                i = 1
                Label2(0).Text = "Fori  1 / 2"
            Else
                Label2(0).Text = "Foro   1"
                i = 0
            End If
            Foris = Nfori(1) \ 2
            For j = 1 To Foris - i
                Label2.Load(j)
                Text2.Load(j)
                Text2(j).Top = GlobalRoutines.TwipsToPixelsY(VB6.PixelsToTwipsY(Text2(0).Top) + (j * VB6.PixelsToTwipsY(Text1(0).Height)) + 20)
                Label2(j).Top = GlobalRoutines.TwipsToPixelsY(VB6.PixelsToTwipsY(Text2(j).Top) + 50)
                Label2(j).Left = GlobalRoutines.TwipsToPixelsX(Label1(0).Left)
                Text2(j).Left = GlobalRoutines.TwipsToPixelsX(Text1(0).Left)
                Label2(j).Text = "Fori  " & j * 2 + i & " / " & j * 2 + i + 1
                Label2(j).Visible = True
                Text2(j).Visible = True
            Next

            Foris = (j - 1) * 2 + 1
            i = 0 : If Nfori(1) Mod 2 = 1 Then i = 1
            For j1 = j To Foris - i
                Text2.Load(j1)
                Text2(j1).Top = GlobalRoutines.TwipsToPixelsY(VB6.PixelsToTwipsY(Text2(0).Top) + ((j1 - j + i) * VB6.PixelsToTwipsY(Text1(0).Height)) + 20)
                Text2(j1).Left = GlobalRoutines.TwipsToPixelsX(VB6.PixelsToTwipsX(Text2(0).Left) + VB6.PixelsToTwipsX(Text1(0).Width) + 380)
                Text2(j1).Visible = True
                Text2(j1).Enabled = False
            Next
            If Nfori(1) Mod 2 = 1 Then
                Text2(j - 1).Text = " 0"
                Text2(j - 1).Enabled = False
            End If
            If GlobalRoutines.ValVir(DbaseSelle.DefInstance.Text1(12).Text) <> 0 Then
                Text2(0).Text = Str(GlobalRoutines.ValVir(DbaseSelle.DefInstance.Text1(12).Text) / 2)
                Text2(1).Text = Text2(0).Text
            End If

            Me.Height = GlobalRoutines.TwipsToPixelsY(VB6.PixelsToTwipsY(Text2(j1 - 1).Top) + VB6.PixelsToTwipsY(Text1(0).Height) + 600)
fori2:
            '<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< FORI2 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            If Nfori(2) \ 2 < 2 Then Exit Sub
            Label5.Visible = True
            Label3(0).Visible = True
            Text3(0).Visible = True
            k = VB6.PixelsToTwipsY(Text2(j1 - 1).Top) + 700
            Label5.Top = GlobalRoutines.TwipsToPixelsY(k)
            Label5.Left = GlobalRoutines.TwipsToPixelsX(500)
            Label5.Text = "INTERASSE FORI BASE SUPERIORE"
            k = k + 300
            Label3(0).Top = GlobalRoutines.TwipsToPixelsY(k + 100)
            Text3(0).Top = GlobalRoutines.TwipsToPixelsY(k)
            Label3(0).Left = Label1(0).Left
            Text3(0).Left = Text1(0).Left
            Text3(0).Width = Text1(0).Width
            Label3(0).Width = Label1(0).Width
            Text3(0).Height = Text1(0).Height
            Label3(0).Height = Label1(0).Height
            If Nfori(2) Mod 2 = 0 Then
                i = 1
                Label3(0).Text = "Fori  1 / 2"
            Else
                Label3(0).Text = "Foro   1"
                i = 0
            End If
            Foris = Nfori(2) \ 2
            For j = 1 To Foris - i
                Label3.Load(j)
                Text3.Load(j)
                Text3(j).Top = GlobalRoutines.TwipsToPixelsY(VB6.PixelsToTwipsY(Text3(0).Top) + (j * VB6.PixelsToTwipsY(Text1(0).Height)) + 20)
                Label3(j).Top = GlobalRoutines.TwipsToPixelsY(VB6.PixelsToTwipsY(Text3(j).Top) + 50)
                Label3(j).Left = GlobalRoutines.TwipsToPixelsX(Label1(0).Left)
                Text3(j).Left = GlobalRoutines.TwipsToPixelsX(Text1(0).Left)
                Label3(j).Text = "Fori  " & j * 2 + i & " / " & j * 2 + i + 1
                Label3(j).Visible = True
                Text3(j).Visible = True
            Next

            Foris = (j - 1) * 2 + 1
            i = 0 : If Nfori(2) Mod 2 = 1 Then i = 1
            For j1 = j To Foris - i
                Text3.Load(j1)
                Text3(j1).Top = GlobalRoutines.TwipsToPixelsY(VB6.PixelsToTwipsY(Text3(0).Top) + ((j1 - j + i) * VB6.PixelsToTwipsY(Text1(0).Height)) + 20)
                Text3(j1).Left = GlobalRoutines.TwipsToPixelsX(VB6.PixelsToTwipsX(Text3(0).Left) + VB6.PixelsToTwipsX(Text1(0).Width) + 380)
                Text3(j1).Visible = True
                Text3(j1).Enabled = False
            Next
            If Nfori(2) Mod 2 = 1 Then
                Text3(j - 1).Text = " 0"
                Text3(j - 1).Enabled = False
            End If
            If GlobalRoutines.ValVir(DbaseSelle.DefInstance.Text1(33).Text) <> 0 Then
                Text3(0).Text = Str(GlobalRoutines.ValVir(DbaseSelle.DefInstance.Text1(33).Text) / 2)
                Text3(1).Text = Text3(0).Text
            End If
        End With
        Me.Height = GlobalRoutines.TwipsToPixelsY(VB6.PixelsToTwipsY(Text3(j1 - 1).Top) + VB6.PixelsToTwipsY(Text1(0).Height) + 600)
    End Sub
    Private Sub Text1_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Text1.TextChanged
        If Inizializzando Then Exit Sub
        Dim Index As Short = Text1.GetIndex(eventSender)
        Dim nl As Short
        With CType(Membro, Sella)
            nl = .nribs Mod 2
            If Index <= .nribs \ 2 - 1 + nl Then
                If VB.Left(Trim(Text1(Index).Text), 1) = "-" Then
                    Text1(Index).Text = Trim(Str(-Val(Text1(Index).Text)))
                End If
                If (.nribs Mod 2 = 1 And Index <> 0) Or .nribs Mod 2 = 0 Then
                    Text1(Index + .nribs \ 2).Text = " " & Str(-Val(Text1(Index).Text))
                End If
            End If
        End With
    End Sub
    Private Sub Text2_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Text2.TextChanged
        If Inizializzando Then Exit Sub
        Dim Index As Short = Text2.GetIndex(eventSender)
        Dim nl As Short
        nl = Nfori(1) Mod 2
        If Index <= Nfori(1) \ 2 - 1 + nl Then
            If VB.Left(Trim(Text2(Index).Text), 1) = "-" Then
                Text2(Index).Text = Trim(Str(-Val(Text2(Index).Text)))
            End If
            If (Nfori(1) Mod 2 = 1 And Index <> 0) Or Nfori(1) Mod 2 = 0 Then
                Text2(Index + Nfori(1) \ 2).Text = " " & Str(-Val(Text2(Index).Text))
            End If
        End If
    End Sub
    Private Sub Text3_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Text3.TextChanged
        If Inizializzando Then Exit Sub
        Dim Index As Short = Text3.GetIndex(eventSender)
        Dim nl As Short
        nl = Nfori(2) Mod 2
        If Index <= Nfori(2) \ 2 - 1 + nl Then
            If VB.Left(Trim(Text3(Index).Text), 1) = "-" Then
                Text3(Index).Text = Trim(Str(-Val(Text3(Index).Text)))
            End If
            If (Nfori(2) Mod 2 = 1 And Index <> 0) Or Nfori(2) Mod 2 = 0 Then
                Text3(Index + Nfori(2) \ 2).Text = " " & Str(-Val(Text3(Index).Text))
            End If
        End If
    End Sub
    Private Sub Timer1_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Timer1.Tick
        If Text1(0).Visible Then
            If CType(Membro, Sella).nribs Mod 2 = 1 And CType(Membro, Sella).nribs > 1 Then
                Text1(1).Focus()
                Timer1.Enabled = False
            Else
                Timer1.Enabled = False
            End If
        End If
    End Sub
End Class