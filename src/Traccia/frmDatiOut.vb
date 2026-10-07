Option Strict Off
Option Explicit On
Friend Class frmEdita
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
        Inizializza()
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
    Public WithEvents cmdOK As System.Windows.Forms.Button
	Public WithEvents cmdCancel As System.Windows.Forms.Button
    'NOTA: la routine seguente è richiesta dalla progettazione Windows Form.
    'Può essere modificata utilizzando la finestra di progettazione Windows Form.
    'Non modificarla mediante l'editor di codice.
    Friend WithEvents cmdHelp As System.Windows.Forms.Button
    Public WithEvents _Text1 As System.Windows.Forms.TextBox
    Public WithEvents _Label1 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmEdita))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmdOK = New System.Windows.Forms.Button
        Me.cmdCancel = New System.Windows.Forms.Button
        Me._Text1 = New System.Windows.Forms.TextBox
        Me._Label1 = New System.Windows.Forms.Label
        Me.cmdHelp = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'cmdOK
        '
        Me.cmdOK.BackColor = System.Drawing.SystemColors.Control
        Me.cmdOK.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdOK.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdOK.Location = New System.Drawing.Point(176, 48)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdOK.Size = New System.Drawing.Size(57, 25)
        Me.cmdOK.TabIndex = 3
        Me.cmdOK.Text = "OK"
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCancel.Location = New System.Drawing.Point(104, 48)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCancel.Size = New System.Drawing.Size(57, 25)
        Me.cmdCancel.TabIndex = 2
        Me.cmdCancel.Text = "Cancel"
        '
        '_Text1
        '
        Me._Text1.AcceptsReturn = True
        Me._Text1.AutoSize = False
        Me._Text1.BackColor = System.Drawing.SystemColors.Window
        Me._Text1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._Text1.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Text1.Location = New System.Drawing.Point(144, 0)
        Me._Text1.MaxLength = 0
        Me._Text1.Name = "_Text1"
        Me._Text1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1.Size = New System.Drawing.Size(89, 20)
        Me._Text1.TabIndex = 1
        Me._Text1.Text = "Text1"
        '
        '_Label1
        '
        Me._Label1.BackColor = System.Drawing.SystemColors.Control
        Me._Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1.Location = New System.Drawing.Point(0, 0)
        Me._Label1.Name = "_Label1"
        Me._Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1.Size = New System.Drawing.Size(137, 17)
        Me._Label1.TabIndex = 0
        Me._Label1.Text = "Label1"
        '
        'cmdHelp
        '
        Me.cmdHelp.Image = CType(resources.GetObject("cmdHelp.Image"), System.Drawing.Image)
        Me.cmdHelp.Location = New System.Drawing.Point(112, 160)
        Me.cmdHelp.Name = "cmdHelp"
        Me.cmdHelp.Size = New System.Drawing.Size(32, 24)
        Me.cmdHelp.TabIndex = 5
        '
        'frmEdita
        '
        Me.AcceptButton = Me.cmdOK
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(235, 424)
        Me.ControlBox = False
        Me.Controls.Add(Me.cmdHelp)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me._Text1)
        Me.Controls.Add(Me._Label1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmEdita"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Risultati"
        Me.ResumeLayout(False)

    End Sub
#End Region
#Region "Supporto aggiornamento "
    Private Shared m_vb6FormDefInstance As frmEdita
    Private Shared m_InitializingDefInstance As Boolean
    Public Shared Property DefInstance() As frmEdita
        Get
            If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
                m_InitializingDefInstance = True
                m_vb6FormDefInstance = New frmEdita
                m_InitializingDefInstance = False
            End If
            DefInstance = m_vb6FormDefInstance
        End Get
        Set(ByVal Value As frmEdita)
            m_vb6FormDefInstance = Value
        End Set
    End Property
#End Region
    Private Ninput As Short
    Private Stringhe(55) As String
    Private Text1 As Text1Array
    Friend Label1 As LabelArray
    Private Sub Inizializza()
        Text1 = New Text1Array(Me)
        Dim Text1_0 As arrText1 = Text1.AddNewTextBox
        Text1_0.Top = Me._Text1.Top
        Text1_0.Left = Me._Text1.Left
        Text1_0.Width = Me._Text1.Width
        Text1_0.Height = Me._Text1.Height
        Text1_0.Multiline = Me._Text1.Multiline
        Text1_0.TextAlign = Me._Text1.TextAlign
        Label1 = New LabelArray(Me)
        Dim Label1_0 As arrLabel = Label1.AddNewTextBox("Label1")
        Label1_0.Top = Me._Label1.Top
        Label1_0.Left = Me._Label1.Left
        Label1_0.Width = Me._Label1.Width
        Label1_0.Height = Me._Label1.Height
        Label1_0.BorderStyle = Me._Label1.BorderStyle
        Label1_0.FlatStyle = Me._Label1.FlatStyle
    End Sub
    Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub cmdOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOK.Click
        Dim i As Short
        Select Case MainForm.FuoriLayOut
            Case 3
                For i = 0 To Ninput - 1
                    DaTos(iDat).td(i + 1, MainForm.Nelem) = GlobalRoutines.ValVir(Text1(i).Text)
                Next
            Case 4
                For i = 0 To Ninput - 1
                    If i <> 2 Then
                        DaTos(iDat).runn(i + 1, MainForm.Nelem) = GlobalRoutines.ValVir(Text1(i).Text)
                    Else
                        DaTos(iDat).runn(i + 1, MainForm.Nelem) = Math.PI / 180 * GlobalRoutines.ValVir(Text1(i).Text)
                    End If
                Next
            Case 5
                For i = 0 To Ninput - 1
                    DaTos(iDat).URTY(i + 1) = GlobalRoutines.ValVir(Text1(i).Text)
                Next
            Case 6
                For i = 0 To Ninput - 1
                    DaTos(iDat).seal(i + 1, MainForm.Nelem) = GlobalRoutines.ValVir(Text1(i).Text)
                Next
            Case 100
                MainForm.DELTAX = GlobalRoutines.ValVir(Text1(0).Text)
                MainForm.DELTAA = GlobalRoutines.ValVir(Text1(1).Text)
        End Select
        Me.Close()
    End Sub

    Private Sub frmEdita_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Dim Baseat1 As Short
        Dim i, ifl As Short
        ifl = FreeFile()
        FileOpen(ifl, RTrim(Monitor.Motore.Inizio.Archdir) & "\IT\TESTMAP", OpenMode.Input, , OpenShare.Shared)
        For i = 1 To 55 : Stringhe(i) = LineInput(ifl) : Next i
        FileClose(ifl)
        Select Case MainForm.FuoriLayOut
            Case 3 'tirante
                Ninput = 3 : Baseat1 = 1
            Case 4 'tondo
                Ninput = 4 : Baseat1 = 32
            Case 5 'piatto
                Ninput = 4
            Case 6 ' SS
                Ninput = 7 : Baseat1 = 6
            Case 100 'Panel 3
                Ninput = 2
        End Select
        For i = 1 To Ninput - 1
            Label1.Load(i, "Label1")
            Text1.Load(i)
            Label1(i).Top = Label1(i - 1).Top + Label1(i - 1).Height
            Text1(i).Top = Label1(i).Top
            Label1(i).Visible = True
            Text1(i).Visible = True
        Next
        Select Case MainForm.FuoriLayOut
            Case 3, 4
                For i = 0 To Ninput - 1
                    Label1(i).Text = Stringhe(Baseat1 + i + 1)
                Next
            Case 6
                For i = 0 To Ninput - 1
                    Label1(i).Text = Stringhe(Baseat1 + i + 1)
                Next
                cmdHelp.Visible = True
                cmdHelp.Top = Label1(Ninput - 1).Top
                cmdHelp.Left = Label1(Ninput - 1).Left + Label1(Ninput - 1).Width - cmdHelp.Width
            Case 5
                Label1(0).Text = "Distanza da asse"
                Label1(1).Text = "Larghezza"
                Label1(2).Text = "Spessore"
                Label1(3).Text = "Lunghezza"
            Case 100
                Label1(0).Text = "deltaSpostam. [mm]"
                Label1(1).Text = "deltaAngolo   [°C]"
        End Select
        cmdOK.Top = Label1(Ninput - 1).Top + Label1(Ninput - 1).Height + GlobalRoutines.TwipsToPixelsY(200)
        cmdCancel.Top = cmdOK.Top
        Height = cmdOK.Top + cmdOK.Height + GlobalRoutines.TwipsToPixelsY(500)
        Select Case MainForm.FuoriLayOut
            Case 3
                Text = Stringhe(Baseat1) & Str(MainForm.Nelem)
                For i = 0 To Ninput - 1
                    Text1(i).Text = GlobalRoutines.myStr(DaTos(iDat).td(i + 1, MainForm.Nelem), 4, 2, False)
                Next
            Case 4
                Text = Stringhe(Baseat1) & Str(MainForm.Nelem)
                For i = 0 To Ninput - 1
                    If i <> 2 Then
                        Text1(i).Text = GlobalRoutines.myStr(DaTos(iDat).runn(i + 1, MainForm.Nelem), 4, 2, False)
                    Else
                        Text1(i).Text = GlobalRoutines.myStr(180 / Math.PI * DaTos(iDat).runn(i + 1, MainForm.Nelem), 4, 2, False)
                    End If
                Next
            Case 5
                Text = "Piatto d'urto"
                For i = 0 To Ninput - 1
                    Text1(i).Text = GlobalRoutines.myStr(DaTos(iDat).URTY(i + 1), 4, 2, False)
                Next
            Case 6
                Text = Stringhe(Baseat1) & Str(MainForm.Nelem)
                For i = 0 To Ninput - 1
                    Text1(i).Text = GlobalRoutines.myStr(DaTos(iDat).seal(i + 1, MainForm.Nelem), 4, 2, False)
                Next
            Case 100
                Text = "Griglia spostamenti"
                Text1(0).Text = GlobalRoutines.myStr((MainForm.DELTAX), 3, 2, False)
                Text1(1).Text = GlobalRoutines.myStr((MainForm.DELTAA), 3, 2, False)
        End Select
    End Sub

    'UPGRADE_WARNING: Form evento frmEdita.Unload presenta un nuovo comportamento. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup2065"'
    Private Sub frmEdita_Closed(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Closed
        Dim i As Short
        For i = 1 To Ninput - 1
            Label1.UnLoad(i)
            Text1.UnLoad(i)
        Next
    End Sub

    'UPGRADE_WARNING: L'evento Text1.TextChanged può essere generato quando il form è inizializzato. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup2075"'
    Private Sub Text1Changed(ByVal Index As Short)
        Dim Y, X, Raggio As Single
        Dim Ang As Single
        If Not Text1(Index).Enabled Then Exit Sub
        Select Case MainForm.FuoriLayOut
            Case 4
                Select Case Index
                    Case 0, 1
                        X = GlobalRoutines.ValVir(Text1(0).Text)
                        Y = GlobalRoutines.ValVir(Text1(1).Text)
                        Raggio = System.Math.Sqrt(X * X + Y * Y)
                        If Raggio < 0.1 Then Exit Sub
                        Ang = GlobalRoutines.arco(X / Raggio, Y / Raggio)
                        Text1(2).Enabled = False
                        Text1(2).Text = GlobalRoutines.myStr(180 / Math.PI * Ang, 4, 2, False)
                        Text1(2).Enabled = True
                    Case 2
                        X = GlobalRoutines.ValVir(Text1(0).Text)
                        Y = GlobalRoutines.ValVir(Text1(1).Text)
                        Raggio = System.Math.Sqrt(X * X + Y * Y)
                        If Raggio < 0.1 Then Exit Sub
                        Ang = Math.PI / 180 * GlobalRoutines.ValVir(Text1(2).Text)
                        Text1(0).Enabled = False
                        Text1(1).Enabled = False
                        Text1(0).Text = CStr(GlobalRoutines.ValVir(CStr(Raggio * System.Math.Cos(Ang))))
                        Text1(1).Text = CStr(GlobalRoutines.ValVir(CStr(Raggio * System.Math.Sin(Ang))))
                        Text1(0).Enabled = True
                        Text1(1).Enabled = True
                End Select
        End Select
    End Sub

    Private Sub cmdHelp_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdHelp.Click
        Dim jti As Short
        Dim Testo As String
        Dim Stringa(3) As String
        Dim i As Short
        Dim Dirx, Raggio, Diry As Single
        Dim iOrient As Short
        jti = MainForm.Nelem
        If DaTos(iDat).seal(10, jti) = -6 Then
            Testo = "Fornire l'anomalia in gradi" & vbCrLf
            Testo = Testo & "rispetto al cerchio" & vbCrLf
            Testo = Testo & "goniometrico standard"
            MsgBox(Testo, MsgBoxStyle.OKOnly + MsgBoxStyle.Information)
        Else
            For i = 1 To 3 : Stringa(i) = GlobalRoutines.Adjust(Stringhe(47 + i), 15) : Next
            'Stringa(1) = "radiale        "
            'Stringa(2) = "orizzontale    "
            'Stringa(3) = "verticale      "
            iOrient = Monitor.Motore.Quale(3, Stringhe(54), Stringa, Stringhe(41), 0)
            Select Case iOrient
                Case 1 : Raggio = System.Math.Sqrt(DaTos(iDat).seal(1, jti) ^ 2 + DaTos(iDat).seal(2, jti) ^ 2)
                    Dirx = DaTos(iDat).seal(1, jti) / Raggio
                    Diry = DaTos(iDat).seal(2, jti) / Raggio
                    DaTos(iDat).seal(7, jti) = GlobalRoutines.arco(Dirx, Diry)
                    DaTos(iDat).seal(10, jti) = -1
                Case 2 : If DaTos(iDat).seal(1, jti) > 0 Then DaTos(iDat).seal(10, jti) = -2 Else DaTos(iDat).seal(10, jti) = -4
                Case 3 : If DaTos(iDat).seal(2, jti) > 0 Then DaTos(iDat).seal(10, jti) = -3 Else DaTos(iDat).seal(10, jti) = -5
            End Select
            If DaTos(iDat).seal(10, jti) < -1 Then DaTos(iDat).seal(7, jti) = (-DaTos(iDat).seal(10, jti) - 2) * Math.PI / 2
            Text1(7).Text = GlobalRoutines.myStr(DaTos(iDat).seal(7, jti) * 180 / Math.PI, 4, 2, False)
        End If

    End Sub
    Private Class arrText1
        Inherits System.Windows.Forms.TextBox
        Private ReadOnly HostForm As frmEdita
        Public Sub New(ByVal host As frmEdita)
            MyBase.new()
            HostForm = host
        End Sub
        Protected Overrides Sub OnTextChanged(ByVal e As System.EventArgs)
            HostForm.Text1Changed(CShort(GetTag0(CStr(Tag))))
        End Sub
    End Class
    Private Class Text1Array
        Inherits System.Collections.CollectionBase
        Private ReadOnly HostForm As frmEdita
        Public Sub New(ByRef m As frmEdita)
            HostForm = m
        End Sub
        Default Public ReadOnly Property Item(ByVal Index As Integer) As arrText1
            Get
                Return CType(List.Item(Index), arrText1)
            End Get
        End Property
        Public Sub UnLoad(ByVal Index As Integer)
            Me.Item(Index).Dispose()
            HostForm.Controls.Remove(Me(Index))
            Me.List.RemoveAt(Index)
        End Sub
        Public Sub Remove()
            ' Check to be sure there is a button to remove.
            If Me.Count > 0 Then
                ' Remove the last button added to the array from the host form 
                ' controls collection. Note the use of the default property in 
                ' accessing the array.
                Me.Item(Me.Count - 1).Dispose()
                HostForm.Controls.Remove(Me(Me.Count - 1))
                Me.List.RemoveAt(Me.Count - 1)
            End If
        End Sub
        Public Sub RemoveAll(Optional ByVal i As Integer = 0)
            Do While Count > i
                Remove()
            Loop
        End Sub
        Public Function Load(ByVal Index As Integer) As arrText1
            Dim i As Integer
            If Index >= Count Then
                For i = Count To Index - 1
                    AddNewTextBox()
                Next
                Return AddNewTextBox()
            Else
                Return CType(list(Index), arrText1)
            End If
        End Function
        Public Function AddNewTextBox() As arrText1
            Dim aButton As New arrText1(HostForm)
            ' Add the button to the collection's internal list.
            Me.List.Add(aButton)
            ' Add the button to the controls collection of the form 
            ' referenced by the HostForm field.
            HostForm.Controls.Add(aButton)
            aButton.Tag = Me.Count - 1
            aButton.Name = "Text1_" & CStr(aButton.Tag).Trim
            aButton.Visible = False
            aButton.Width = CType(list(0), arrText1).Width
            aButton.Height = CType(list(0), arrText1).Height
            aButton.Multiline = CType(list(0), arrText1).Multiline
            aButton.TextAlign = CType(list(0), arrText1).TextAlign
            Return aButton
        End Function
    End Class
End Class