Option Strict On
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports System.Windows
Public Class frmInput
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
        inizializzando = True
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
    Public WithEvents _Command1_0 As System.Windows.Forms.Button
    Public WithEvents _Command1_1 As System.Windows.Forms.Button
    Public WithEvents _Command1_2 As System.Windows.Forms.Button
    Public WithEvents VScroll1 As System.Windows.Forms.VScrollBar
    Public WithEvents HScroll1 As System.Windows.Forms.HScrollBar
    Public WithEvents _Text1_0 As System.Windows.Forms.TextBox
    Public WithEvents _HelpFile_0 As System.Windows.Forms.Button
    Public WithEvents _ComboLibero_0 As System.Windows.Forms.ComboBox
    Public WithEvents _ComboFisso_0 As System.Windows.Forms.ComboBox
    Public WithEvents LabelHelp As System.Windows.Forms.Label
    Public WithEvents _Label1_0 As System.Windows.Forms.Label
    Public WithEvents Picture1 As System.Windows.Forms.Panel
    Public WithEvents ComboFisso As Microsoft.VisualBasic.Compatibility.VB6.ComboBoxArray
    Public WithEvents ComboLibero As Microsoft.VisualBasic.Compatibility.VB6.ComboBoxArray
    Public WithEvents Command1 As Microsoft.VisualBasic.Compatibility.VB6.ButtonArray
    Public WithEvents HelpFile As Microsoft.VisualBasic.Compatibility.VB6.ButtonArray
    Public WithEvents Label1 As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    Public WithEvents Text1 As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
    'NOTA: la routine seguente è richiesta dalla progettazione Windows Form.
    'Può essere modificata utilizzando la finestra di progettazione Windows Form.
    'Non modificarla mediante l'editor di codice.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmInput))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me._Command1_0 = New System.Windows.Forms.Button
        Me._Command1_1 = New System.Windows.Forms.Button
        Me._Command1_2 = New System.Windows.Forms.Button
        Me.VScroll1 = New System.Windows.Forms.VScrollBar
        Me.HScroll1 = New System.Windows.Forms.HScrollBar
        Me.Picture1 = New System.Windows.Forms.Panel
        Me._Text1_0 = New System.Windows.Forms.TextBox
        Me._HelpFile_0 = New System.Windows.Forms.Button
        Me._ComboLibero_0 = New System.Windows.Forms.ComboBox
        Me._ComboFisso_0 = New System.Windows.Forms.ComboBox
        Me.LabelHelp = New System.Windows.Forms.Label
        Me._Label1_0 = New System.Windows.Forms.Label
        Me.ComboFisso = New Microsoft.VisualBasic.Compatibility.VB6.ComboBoxArray(Me.components)
        Me.ComboLibero = New Microsoft.VisualBasic.Compatibility.VB6.ComboBoxArray(Me.components)
        Me.Command1 = New Microsoft.VisualBasic.Compatibility.VB6.ButtonArray(Me.components)
        Me.HelpFile = New Microsoft.VisualBasic.Compatibility.VB6.ButtonArray(Me.components)
        Me.Label1 = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        Me.Text1 = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(Me.components)
        Me.Picture1.SuspendLayout()
        CType(Me.ComboFisso, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ComboLibero, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Command1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.HelpFile, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Text1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        '_Command1_0
        '
        Me._Command1_0.BackColor = System.Drawing.SystemColors.Control
        Me._Command1_0.Cursor = System.Windows.Forms.Cursors.Arrow
        Me._Command1_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command1.SetIndex(Me._Command1_0, CType(0, Short))
        Me._Command1_0.Location = New System.Drawing.Point(168, 64)
        Me._Command1_0.Name = "_Command1_0"
        Me._Command1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Command1_0.Size = New System.Drawing.Size(73, 25)
        Me._Command1_0.TabIndex = 6
        Me._Command1_0.Text = "OK"
        '
        '_Command1_1
        '
        Me._Command1_1.BackColor = System.Drawing.SystemColors.Control
        Me._Command1_1.Cursor = System.Windows.Forms.Cursors.Arrow
        Me._Command1_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command1.SetIndex(Me._Command1_1, CType(1, Short))
        Me._Command1_1.Location = New System.Drawing.Point(240, 64)
        Me._Command1_1.Name = "_Command1_1"
        Me._Command1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Command1_1.Size = New System.Drawing.Size(73, 25)
        Me._Command1_1.TabIndex = 5
        Me._Command1_1.Text = "Cancel"
        '
        '_Command1_2
        '
        Me._Command1_2.BackColor = System.Drawing.SystemColors.Control
        Me._Command1_2.Cursor = System.Windows.Forms.Cursors.Arrow
        Me._Command1_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command1.SetIndex(Me._Command1_2, CType(2, Short))
        Me._Command1_2.Location = New System.Drawing.Point(312, 64)
        Me._Command1_2.Name = "_Command1_2"
        Me._Command1_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Command1_2.Size = New System.Drawing.Size(73, 25)
        Me._Command1_2.TabIndex = 4
        Me._Command1_2.Text = "Help"
        '
        'VScroll1
        '
        Me.VScroll1.Cursor = System.Windows.Forms.Cursors.Default
        Me.VScroll1.LargeChange = 1
        Me.VScroll1.Location = New System.Drawing.Point(384, 0)
        Me.VScroll1.Maximum = 32767
        Me.VScroll1.Name = "VScroll1"
        Me.VScroll1.Size = New System.Drawing.Size(17, 41)
        Me.VScroll1.TabIndex = 3
        Me.VScroll1.TabStop = True
        '
        'HScroll1
        '
        Me.HScroll1.Cursor = System.Windows.Forms.Cursors.Default
        Me.HScroll1.LargeChange = 1
        Me.HScroll1.Location = New System.Drawing.Point(8, 40)
        Me.HScroll1.Maximum = 32767
        Me.HScroll1.Name = "HScroll1"
        Me.HScroll1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HScroll1.Size = New System.Drawing.Size(377, 17)
        Me.HScroll1.TabIndex = 2
        Me.HScroll1.TabStop = True
        '
        'Picture1
        '
        Me.Picture1.BackColor = System.Drawing.SystemColors.Control
        Me.Picture1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Picture1.Controls.Add(Me._Text1_0)
        Me.Picture1.Controls.Add(Me._HelpFile_0)
        Me.Picture1.Controls.Add(Me._ComboLibero_0)
        Me.Picture1.Controls.Add(Me._ComboFisso_0)
        Me.Picture1.Controls.Add(Me.LabelHelp)
        Me.Picture1.Controls.Add(Me._Label1_0)
        Me.Picture1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Picture1.Font = New System.Drawing.Font("Arial", 7.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Picture1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Picture1.Location = New System.Drawing.Point(8, 0)
        Me.Picture1.Name = "Picture1"
        Me.Picture1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Picture1.Size = New System.Drawing.Size(377, 41)
        Me.Picture1.TabIndex = 0
        Me.Picture1.TabStop = True
        '
        '_Text1_0
        '
        Me._Text1_0.AcceptsReturn = True
        Me._Text1_0.AutoSize = False
        Me._Text1_0.BackColor = System.Drawing.Color.White
        Me._Text1_0.Cursor = System.Windows.Forms.Cursors.Arrow
        Me._Text1_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text1.SetIndex(Me._Text1_0, CType(0, Short))
        Me._Text1_0.Location = New System.Drawing.Point(216, 8)
        Me._Text1_0.MaxLength = 0
        Me._Text1_0.Name = "_Text1_0"
        Me._Text1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Text1_0.Size = New System.Drawing.Size(145, 20)
        Me._Text1_0.TabIndex = 1
        Me._Text1_0.Text = ""
        '
        '_HelpFile_0
        '
        Me._HelpFile_0.BackColor = System.Drawing.SystemColors.Control
        Me._HelpFile_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._HelpFile_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._HelpFile_0.Image = CType(resources.GetObject("_HelpFile_0.Image"), System.Drawing.Image)
        Me.HelpFile.SetIndex(Me._HelpFile_0, CType(0, Short))
        Me._HelpFile_0.Location = New System.Drawing.Point(344, 8)
        Me._HelpFile_0.Name = "_HelpFile_0"
        Me._HelpFile_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._HelpFile_0.Size = New System.Drawing.Size(21, 21)
        Me._HelpFile_0.TabIndex = 10
        Me._HelpFile_0.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me._HelpFile_0.Visible = False
        '
        '_ComboLibero_0
        '
        Me._ComboLibero_0.BackColor = System.Drawing.Color.White
        Me._ComboLibero_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._ComboLibero_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ComboLibero.SetIndex(Me._ComboLibero_0, CType(0, Short))
        Me._ComboLibero_0.Location = New System.Drawing.Point(216, 9)
        Me._ComboLibero_0.Name = "_ComboLibero_0"
        Me._ComboLibero_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._ComboLibero_0.Size = New System.Drawing.Size(129, 20)
        Me._ComboLibero_0.TabIndex = 9
        Me._ComboLibero_0.Text = "Combo1"
        '
        '_ComboFisso_0
        '
        Me._ComboFisso_0.BackColor = System.Drawing.Color.White
        Me._ComboFisso_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._ComboFisso_0.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me._ComboFisso_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ComboFisso.SetIndex(Me._ComboFisso_0, CType(0, Short))
        Me._ComboFisso_0.Location = New System.Drawing.Point(216, 8)
        Me._ComboFisso_0.Name = "_ComboFisso_0"
        Me._ComboFisso_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._ComboFisso_0.Size = New System.Drawing.Size(129, 20)
        Me._ComboFisso_0.TabIndex = 8
        '
        'LabelHelp
        '
        Me.LabelHelp.BackColor = System.Drawing.SystemColors.Control
        Me.LabelHelp.Cursor = System.Windows.Forms.Cursors.Default
        Me.LabelHelp.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LabelHelp.Location = New System.Drawing.Point(0, 0)
        Me.LabelHelp.Name = "LabelHelp"
        Me.LabelHelp.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LabelHelp.Size = New System.Drawing.Size(32, 13)
        Me.LabelHelp.TabIndex = 11
        Me.LabelHelp.Text = "Label2"
        Me.LabelHelp.Visible = False
        '
        '_Label1_0
        '
        Me._Label1_0.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(128, Byte))
        Me._Label1_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._Label1_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_0.Font = New System.Drawing.Font("Arial", 7.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Label1_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label1.SetIndex(Me._Label1_0, CType(0, Short))
        Me._Label1_0.Location = New System.Drawing.Point(8, 8)
        Me._Label1_0.Name = "_Label1_0"
        Me._Label1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_0.Size = New System.Drawing.Size(201, 20)
        Me._Label1_0.TabIndex = 7
        Me._Label1_0.Text = "Label1"
        '
        'ComboFisso
        '
        '
        'ComboLibero
        '
        '
        'Command1
        '
        '
        'HelpFile
        '
        '
        'Text1
        '
        '
        'frmInput
        '
        Me.AcceptButton = Me._Command1_0
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(408, 93)
        Me.ControlBox = False
        Me.Controls.Add(Me._Command1_0)
        Me.Controls.Add(Me._Command1_1)
        Me.Controls.Add(Me._Command1_2)
        Me.Controls.Add(Me.VScroll1)
        Me.Controls.Add(Me.HScroll1)
        Me.Controls.Add(Me.Picture1)
        Me.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Location = New System.Drawing.Point(2, 22)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmInput"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Form1"
        Me.Picture1.ResumeLayout(False)
        CType(Me.ComboFisso, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ComboLibero, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Command1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.HelpFile, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Text1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
#End Region
#Region "Supporto aggiornamento "
    Private Shared m_vb6FormDefInstance As frmInput
    Private Shared m_InitializingDefInstance As Boolean
    Public Shared Property DefInstance() As frmInput
        Get
            If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
                m_InitializingDefInstance = True
                m_vb6FormDefInstance = New frmInput
                m_InitializingDefInstance = False
            End If
            DefInstance = m_vb6FormDefInstance
        End Get
        Set(ByVal Value As frmInput)
            m_vb6FormDefInstance = Value
        End Set
    End Property
#End Region
    Public CarFissi As Boolean
    Public Motore As RoutBase1.clsMotore
    Friend Ninput As Short
    Public Tit As String
    Public Aiuto As String
    Public IDH As Integer
    Public strIDH As String
    Friend Strin() As String
    Public Nfin As Short
    Public NonMostrare As Boolean
    Friend Gia As Boolean
    Private gPicture1 As Drawing.Graphics
    Private gPicture2 As Drawing.Graphics
    Public chkCancel As Boolean
    Public Ncol As Short
    Public FinX, FinY As Single
    Private IndexCombo As Short
    Private LeftLabelOld As Single
    Private LeftTextOld As Single
    Private TopLabelOld, LblWidthOld As Single
    Private TopTextOld, TextWidthOld As Single
    Private TextArr() As Control
    Private Risposte() As String
    Private Archivio() As Short
    Private Help() As String
    Private MaxLength1() As Single
    Private Inizializzando As Boolean
    Event OKClick()
    Event ComboClick(ByRef indice As Short)
    Event dAiuClick(ByRef indice As Short)
    Event TestoCambia(ByRef indice As Short)
    Event CancelClick()
    Public WriteOnly Property pStrin(ByVal i As Short) As String
        Set(ByVal Value As String)
            Strin(i) = Value
        End Set
    End Property
    Public Property pNinput() As Short
        Get
            pNinput = Ninput
        End Get
        Set(ByVal Value As Short)
            Ninput = Value
            If Ninput > 0 Then
                ReDim Strin(Ninput)
                ReDim Risposte(Ninput)
                ReDim Archivio(Ninput)
                ReDim Help(Ninput)
            End If
        End Set
    End Property
    Private Sub ComboFisso_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ComboFisso.SelectedIndexChanged
        If Inizializzando Then Exit Sub
        Dim Index As Short = ComboFisso.GetIndex(CType(eventSender, Forms.ComboBox))
        Risposte(Index + 1) = ComboFisso(Index).Text
        If Gia Then
            Select Case Nfin
                Case 0
                Case Else : RaiseEvent ComboClick(CShort(Index + 1))
            End Select
        End If
    End Sub
    Private Sub ComboLibero_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ComboLibero.TextChanged
        If Inizializzando Then Exit Sub
        Dim Index As Short = ComboLibero.GetIndex(CType(eventSender, Forms.ComboBox))
        Risposte(Index + 1) = ComboLibero(Index).Text
    End Sub
    Private Sub ComboLibero_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ComboLibero.SelectedIndexChanged
        If Inizializzando Then Exit Sub
        Dim Index As Short = ComboLibero.GetIndex(CType(eventSender, Forms.ComboBox))
        Risposte(Index + 1) = ComboLibero(Index).Text
        If Gia Then
            Select Case Nfin
                Case 0
                Case Else : RaiseEvent ComboClick(CShort(Index + 1))
            End Select
        End If
    End Sub
    Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
        Dim Index As Short = Command1.GetIndex(CType(eventSender, Forms.Button))
        Select Case Index
            Case 0
                If Nfin > 0 Then
                    RaiseEvent OKClick()
                Else
                    chkCancel = False : Hide()
                End If
            Case 1
                If Nfin > 0 Then
                    RaiseEvent CancelClick()
                Else
                    chkCancel = True : Hide()
                End If
            Case 2
                If Aiuto.Trim.Length = 0 Then
                    MsgBox("Non ci sono informazioni disponibili")
                ElseIf InStr(Aiuto, "\") > 0 Then
                    If IDH > 0 Then
                        Motore.RetrHelp(Aiuto, Me, "", IDH)
                    Else
                        Motore.RetrHelp(Aiuto, Me, "", strIDH)
                    End If
                Else
                    MsgBox(Aiuto)
                End If
        End Select
    End Sub
    Public Sub frmInput_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
        Dim NewLargeChange As Short
        Dim i As Short
        Dim MaxLength As Single
        Dim dH, M, dW, dW1 As Single
        Dim NewWidth, NewHeight As Single
        Dim k, j As Short
        Dim MM As Single
        Dim u As String
        Dim H1V, V1V As Boolean
        Dim MMM As Single
        Dim l As Short
        ReDim MaxLength1(Ncol)
        If Gia Then Exit Sub
        H1V = True : V1V = True
        If Not NonMostrare Then
            Visible = True
            If FinX > 0 And FinY > 0 Then
                TopMost = True
                Location = New Point(CInt(FinX), CInt(FinY))
            End If
        End If
        ReDim TextArr(Ninput * Ncol - 1)
        LeftTextOld = Text1(0).Left
        TopTextOld = Text1(0).Top
        LeftLabelOld = Label1(0).Left
        TopLabelOld = Label1(0).Top
        TextWidthOld = Text1(0).Width
        LblWidthOld = Label1(0).Width
        Text = Tit
        gPicture1 = Graphics.FromHwnd(Picture1.Handle)
        Select Case Archivio(1)
            Case Is > 0
                ComboFisso(0).Visible = True
                ComboLibero(0).Visible = False
                Text1(0).Visible = False
                TextArr(0) = ComboFisso(0)
                u = ReadArch(Archivio(1), ComboFisso(0), 0)
                AggioFisso(ComboFisso(0), Risposte(1))
            Case 0
                ComboFisso(0).Visible = False
                ComboLibero(0).Visible = False
                If Len(Risposte(1)) > 0 Then
                    Text1(0).Visible = True
                    Text1(0).Text = Risposte(1)
                Else
                    Text1(0).Visible = False
                End If
                If CarFissi Then
                    Text1(0).Font = New Font("Courier New", 10)
                    Label1(0).Font = New Font("Courier New", 10)
                    Picture1.Font = New Font("Courier New", 10)
                End If
                TextArr(0) = Text1(0)
                For i = 2 To Ncol
                    Text1.Load(CShort(i - 1) * Ninput)
                    If CarFissi Then Text1(CShort(i - 1)).Font = New Font("Courier New", 10)
                    TextArr((i - 1) * Ninput) = Text1(CShort((i - 1) * Ninput))
                    Text1(CShort((i - 1) * Ninput)).Text = Risposte((i - 1) * Ninput + 1)
                Next
            Case Is < 0
                    ComboFisso(0).Visible = False
                    ComboLibero(0).Visible = True
                    Text1(0).Visible = False
                    TextArr(0) = ComboLibero(0)
                    u = ReadArch(-Archivio(1), ComboLibero(0), 0)
                    TextArr(0).Text = Risposte(1)
        End Select
        HelpFile(0).Visible = Len(Trim(Help(1))) > 0
        TextArr(0).Text = Risposte(1)
        Label1(0).Text = Strin(1)
        MaxLength = CSng(gPicture1.MeasureString(Strin(1), Picture1.Font).Width + Trigon.TwipsToPixelsX(200))
        For k = 1 To Ncol
            j = CShort((k - 1) * Ninput)
            M = CSng(gPicture1.MeasureString(Risposte(j + 1), Picture1.Font).Width + Trigon.TwipsToPixelsX(200))
            If M < Trigon.TwipsToPixelsX(1000) Then M = CSng(Trigon.TwipsToPixelsX(1000))
            If M > MaxLength1(k) Then MaxLength1(k) = M
            TextArr(j).Visible = True
            If Len(Risposte(j + 1)) = 0 And Archivio(1) = 0 Then TextArr(j).Visible = False
        Next
        For i = 1 To CShort(Ninput - 1)
            If Len(Trim(Help(i + 1))) > 0 Then
                HelpFile.Load(i)
                HelpFile(i).Visible = True
            End If
            Select Case Archivio(i + 1)
                Case Is < 0
                    ComboLibero.Load(i)
                    TextArr(i) = ComboLibero(i)
                    u = ReadArch(-Archivio(i + 1), ComboLibero(i), 0)
                    TextArr(i).Text = Risposte(i + 1)
                Case 0
                    For k = 1 To Ncol
                        Text1.Load(CShort((k - 1) * Ninput + i))
                        If CarFissi Then Text1(CShort((k - 1) * Ninput + i)).Font = New Font("Courier New", 10)
                        TextArr((k - 1) * Ninput + i) = Text1(CShort((k - 1) * Ninput + i))
                        TextArr((k - 1) * Ninput + i).Text = Risposte((k - 1) * Ninput + i + 1)
                    Next
                Case Is > 0
                    ComboFisso.Load(i)
                    TextArr(i) = ComboFisso(i)
                    u = ReadArch(Archivio(i + 1), ComboFisso(i), 0)
                    AggioFisso(ComboFisso(i), Risposte(i + 1))
            End Select
            Label1.Load(i)
            If CarFissi Then Label1(i).Font = New Font("Courier New", 10)
            Label1(i).Top = Label1(CShort(i - 1)).Top + TextArr(i - 1).Height
            Label1(i).Text = Strin(i + 1)
            For k = 1 To Ncol
                j = CShort((k - 1) * Ninput)
                TextArr(j + i).Top = TextArr(j + i - 1).Top + TextArr(j + i - 1).Height
            Next
            M = CSng(gPicture1.MeasureString(Strin(i + 1), Picture1.Font).Width + Trigon.TwipsToPixelsY(100))
            If M > MaxLength Then MaxLength = M
            For k = 1 To Ncol
                j = CShort((k - 1) * Ninput)
                M = gPicture1.MeasureString(Risposte(j + i + 1), Picture1.Font).Width
                If M < Trigon.TwipsToPixelsX(1000) Then M = CSng(Trigon.TwipsToPixelsX(1000))
                If Archivio(i + 1) <> 0 Then
                    For l = 0 To CShort(CType(TextArr(i + j), ComboBox).Items.Count - 1)
                        Dim dum As Single = CSng(gPicture1.MeasureString(CStr(CType(TextArr(i + j), ComboBox).Items(l)), Picture1.Font).Width + Trigon.TwipsToPixelsY(350))
                        If dum > M Then M = dum
                    Next
                End If
                If M > MaxLength1(k) Then MaxLength1(k) = M
                TextArr(j + i).Visible = True
                If Len(Risposte(j + i + 1)) = 0 And Archivio(i + 1) = 0 Then TextArr(j + i).Visible = False
            Next
            Label1(i).Visible = True
        Next
        If Len(UltAiu) > 0 Then
            M = CSng(gPicture1.MeasureString(UltAiu, Picture1.Font).Width + Trigon.TwipsToPixelsY(200))
            LabelHelp.Width = CInt(M)
            If M > MaxLength Then MaxLength = M
        End If
        dW = Label1(0).Width - MaxLength
        For i = 1 To Ninput
            Label1(CShort(i - 1)).Width = CInt(MaxLength)
            TextArr(i - 1).Left = CInt(TextArr(i - 1).Left - dW)
        Next
        LeftTextOld = LeftTextOld - dW
        M = MaxLength
        MMM = 0
        dW1 = 0
        For k = 1 To Ncol
            j = CShort((k - 1) * Ninput)
            dW1 = dW1 + TextArr(j).Width - MaxLength1(k)
            For i = 0 To CShort(Ninput - 1)
                TextArr(j + i).Width = CInt(MaxLength1(k))
            Next
            M = M + MaxLength1(k)
            MMM = MMM + TextArr(j).Width
        Next
        dW = dW + dW1 - (Ncol - 1) * TextWidthOld
        If dW > 0 Then
            NewWidth = M
            If NewWidth < 3 * Command1(0).Width Then
                dW = -3 * Command1(0).Width + LblWidthOld + TextWidthOld ' NewWidth
                'dW = dW + (Ncol - 1) * TextWidthOld
                NewWidth = 3 * Command1(0).Width
                MaxLength = MaxLength * NewWidth / M
                ' MaxLength1 = MaxLength1 * NewWidth / M
            End If
            HScroll1.Visible = False : H1V = False
        Else
            NewWidth = M
            If Width - dW + Left > System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width Then
                dW = Width + Left - System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width
                'dW = dW + (Ncol - 1) * TextWidthOld
                NewWidth = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width - Left
            Else
                HScroll1.Visible = False : H1V = False
            End If
        End If
        '   dW = Label1(0).Width + MMM - NewWidth
        '   dW1 = Label1(0).Width - MaxLength
        '  dW = M - NewWidth + dW
        For i = 0 To CShort(Ninput - 1)
            For k = 2 To Ncol
                j = CShort((k - 1) * Ninput)
                TextArr(j + i).Left = TextArr((k - 2) * Ninput + i).Left + TextArr((k - 2) * Ninput + i).Width
            Next
            Try
                If HelpFile(i).Visible Then
                    HelpFile(i).Top = TextArr(i).Top
                    TextArr(i + (Ncol - 1) * Ninput).Width = TextArr(i + (Ncol - 1) * Ninput).Width - HelpFile(i).Width
                    HelpFile(i).Left = TextArr(i + (Ncol - 1) * Ninput).Left + TextArr(i + (Ncol - 1) * Ninput).Width
                End If
            Catch
            End Try
        Next
        Picture1.Width = CInt(Picture1.Width - dW)
        VScroll1.Left = CInt(VScroll1.Left - dW)
        HScroll1.Width = CInt(HScroll1.Width - dW)
        If VScroll1.Visible = False Then dW = dW + VScroll1.Width
        Width = CInt(Width - dW)
        For i = 0 To 2
            Command1(i).Left = CInt(Command1(i).Left - dW)
        Next
        If Len(UltAiu) > 0 Then
            LabelHelp.Visible = True
            LabelHelp.Text = UltAiu
            LabelHelp.Top = Label1(0).Top
            LabelHelp.Left = Label1(0).Left
            LabelHelp.Height = CInt(gPicture1.MeasureString(UltAiu, Picture1.Font).Height)
            For i = 0 To CShort(Ninput - 1)
                Try
                    Label1(i).Top = (Label1(i).Top + LabelHelp.Height)
                    For k = 1 To Ncol
                        j = CShort((k - 1) * Ninput)
                        TextArr(j + i).Top = TextArr(j + i).Top + LabelHelp.Height
                        If k > 1 And Len(Trim(TextArr(j + i).Text)) = 0 Then TextArr(j + i).Visible = False
                        If i = 0 And Ncol > 1 Then
                            TextArr(i + j).Enabled = False
                            TextArr(i + j).BackColor = System.Drawing.Color.Yellow
                        End If
                    Next
                    HelpFile(i).Top = (HelpFile(i).Top + LabelHelp.Height)
                Catch
                End Try
            Next
        End If
        gPicture1.Dispose()
        For i = 0 To CShort(Ninput - 1)
            For k = 1 To Ncol
                j = CShort((k - 1) * Ninput)
                If k > 1 And Len(Trim(TextArr(j + i).Text)) = 0 Then TextArr(j + i).Visible = False
                If i = 0 And Ncol > 1 Then
                    TextArr(i + j).Enabled = False
                    TextArr(i + j).BackColor = System.Drawing.Color.Yellow
                End If
            Next
        Next
        If Ncol > 1 Then Label1(0).Visible = False
        MM = TextArr(Ninput - 1).Top + TextArr(Ninput - 1).Height
        If MM <= Picture1.ClientRectangle.Height Then
            NewHeight = MM
            VScroll1.Visible = False : V1V = False
        Else
            NewHeight = CSng(Picture1.Top + MM + Command1(0).Top - (Picture1.Top + Picture1.Height) + Command1(0).Height + Trigon.TwipsToPixelsY(200))
            If H1V Then NewHeight = NewHeight + HScroll1.Height
            If NewHeight > CSng(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height - (NewHeight - MM) - Trigon.TwipsToPixelsY(1000)) Then
                NewHeight = CSng(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height - (NewHeight - MM) - Trigon.TwipsToPixelsY(1000))
            Else
                NewHeight = MM
                VScroll1.Visible = False : V1V = False
            End If
        End If
        dH = Picture1.ClientRectangle.Height - NewHeight
        Picture1.Height = CInt(Picture1.Height - dH)
        VScroll1.Height = CInt(VScroll1.Height - dH)
        HScroll1.Top = CInt(HScroll1.Top - dH)
        Height = CInt(Height - dH)
        For i = 0 To 2
            Command1(i).Top = CInt(Command1(i).Top - dH)
            If Not H1V Then Command1(i).Top = CInt(Command1(i).Top - HScroll1.Height)
        Next
        If H1V Then
            HScroll1.Minimum = CInt(NewWidth)
            HScroll1.Maximum = CInt(M + HScroll1.LargeChange - 1)
            HScroll1.Value = HScroll1.Minimum
            HScroll1.SmallChange = CInt((M - NewWidth) ^ 2 / M)
            NewLargeChange = CShort((M - NewWidth) / 2)
            HScroll1.Maximum = HScroll1.Maximum + NewLargeChange - HScroll1.LargeChange
            HScroll1.LargeChange = NewLargeChange
        End If
        If V1V Then
            VScroll1.Minimum = CInt(NewHeight)
            VScroll1.Maximum = CInt(MM + VScroll1.LargeChange - 1)
            VScroll1.Value = VScroll1.Minimum
            VScroll1.SmallChange = CInt((MM - NewHeight) ^ 2 / MM)
            NewLargeChange = CShort((MM - NewHeight) / 2)
            VScroll1.Maximum = VScroll1.Maximum + NewLargeChange - VScroll1.LargeChange
            VScroll1.LargeChange = NewLargeChange
        End If
        Gia = True
        If Nfin = 0 Then Visible = True
        If Len(Trim(Aiuto)) = 0 Then Command1(2).Visible = False
    End Sub
    Private Sub HelpFile_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HelpFile.Click
        Dim Index As Short = HelpFile.GetIndex(CType(eventSender, Forms.Button))
        If Nfin > 0 And Help(Index + 1) = "*" Then
            RaiseEvent dAiuClick(CShort(Index + 1))
        Else
            If Help(Index + 1).IndexOf("\") = -1 Then
                MsgBox(Help(Index + 1))
            Else
                Stop
                'Motore.RetrHelp(Help(Index + 1))
            End If
        End If
    End Sub
    Private Sub HScroll1_Change(ByVal newScrollValue As Integer)
        Dim delta As Single
        Dim i, k As Short
        delta = newScrollValue - HScroll1.Minimum
        For i = 0 To CShort(Ninput - 1)
            Label1(i).Left = CInt(LeftLabelOld - delta)
            TextArr(i).Left = CInt(LeftTextOld - delta)
            For k = 2 To Ncol
                TextArr((k - 1) * Ninput + i).Left = TextArr(i).Left + (k - 1) * TextArr(i).Width
            Next
        Next
    End Sub
    Private Sub Text1_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Text1.TextChanged
        Dim Index As Short = Text1.GetIndex(CType(eventSender, Forms.TextBox))
        Risposte(Index + 1) = Text1(Index).Text
        If Gia Then
            Select Case Nfin
                Case 0
                Case Else : RaiseEvent TestoCambia(CShort(Index + 1))
            End Select
        End If
    End Sub
    'UPGRADE_NOTE: VScroll1.Change è stato modificato da evento a routine. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup2010"'
    'UPGRADE_WARNING: VScrollBar evento VScroll1.Change presenta un nuovo comportamento. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup2065"'
    Private Sub VScroll1_Change(ByVal newScrollValue As Integer)
        Dim delta As Single
        Dim j, i, k As Short
        delta = newScrollValue - VScroll1.Minimum
        Label1(0).Top = CInt(TopLabelOld - delta)
        For k = 1 To Ncol
            TextArr((k - 1) * Ninput).Top = CInt(TopTextOld - delta)
        Next
        For i = 1 To CShort(Ninput - 1)
            Label1(i).Top = (Label1(CShort(i - 1)).Top + TextArr(i - 1).Height)
            For k = 1 To Ncol
                j = CShort((k - 1) * Ninput)
                TextArr(j + i).Top = TextArr(j + i - 1).Top + TextArr(j + i - 1).Height
            Next
        Next
    End Sub
    Private Function ReadArch(ByRef nArch As Short, ByRef c As System.Windows.Forms.ComboBox, ByRef X As Short) As String
        Dim File1 As String
        Dim iff, x1 As Short
        Dim Riga As String
        Dim nchar, icount As Short
        Dim i3, i1, i2, i4 As Short
        File1 = RTrim(Motore.Inizio.Archdir) & "\ARCH" & LTrim(Str(nArch)) & ".DAT"
        iff = CShort(FreeFile())
        Try
            FileOpen(iff, File1, OpenMode.Input)
        Catch e As Exception
            MsgBox(e.Message & vbCrLf & e.StackTrace)
            Return ""
        End Try
        Riga = LineInput(iff)
        nchar = 4
        If (nArch = 28 Or nArch = 29 Or nArch = 105) Then nchar = 2
        i1 = CShort(Val(Mid(Riga, 1, nchar)))
        i2 = CShort(Val(Mid(Riga, 1 + nchar, nchar)))
        i3 = CShort(Val(Mid(Riga, 1 + 2 * nchar, nchar)))
        i4 = CShort(Val(Mid(Riga, 1 + 3 * nchar, nchar)))
        If X >= 0 Then
            c.Items.Clear()
            Do
                If EOF(iff) Then Exit Do
                Riga = LineInput(iff)
                If Not (VB.Left(Riga, 1) = " " Or (VB.Left(Riga, 1) = "X" And Len(Trim(Riga)) > 1)) Then
                    c.Items.Add(VB.Left(Riga, 2 * i1))
                ElseIf Len(Trim(Riga)) > 1 Then
                    c.Items.Add(VB.Left(Riga, 2 * i1))
                Else
                    If c.Items.Count > 0 Then Exit Do
                End If
            Loop
            ReadArch = Space(0)
        Else
100:        x1 = -X
            For icount = 1 To CShort(x1 - 1)
                Riga = LineInput(iff)
            Next
            ReadArch = VB.Left(Riga, 2 * i1)
        End If
        FileClose(iff)
    End Function
    Private Sub AggioFisso(ByRef c As System.Windows.Forms.ComboBox, ByRef R As String)
        Dim i As Short
        For i = 0 To CShort(c.Items.Count - 1)
            If Trim(UCase(VB6.GetItemString(c, i))) = Trim(UCase(R)) Then c.SelectedIndex = i : Exit Sub
        Next
        For i = 0 To CShort(c.Items.Count - 1)
            If Len(Trim(UCase(VB6.GetItemString(c, i)))) > 1 Then
                If VB.Left(Trim(UCase(VB6.GetItemString(c, i))), 2) = VB.Left(Trim(UCase(R)), 2) Then c.SelectedIndex = i : Exit Sub
            End If
        Next
        For i = 0 To CShort(c.Items.Count - 1)
            If VB.Left(Trim(UCase(VB6.GetItemString(c, i))), 1) = VB.Left(Trim(UCase(R)), 1) Then c.SelectedIndex = i : Exit Sub
        Next
        If c.Items.Count = 0 Then Exit Sub
        c.SelectedIndex = 0
    End Sub
    Public Property pRisposte(ByVal i As Short) As String
        Get
            pRisposte = Risposte(i)
        End Get
        Set(ByVal Value As String)
            Risposte(i) = Value
            On Error Resume Next
            Text1(CShort(i - 1)).Text = Risposte(i)
        End Set
    End Property
    Public WriteOnly Property pEnaRisp(ByVal i As Short) As Boolean
        Set(ByVal Value As Boolean)
            On Error Resume Next
            Text1(CShort(i - 1)).Enabled = Value
        End Set
    End Property

    Public Property pComboList(ByVal i As Short) As Short
        Get
            pComboList = CShort(ComboFisso(CShort(i - 1)).SelectedIndex)
        End Get
        Set(ByVal Value As Short)
            On Error Resume Next
            ComboFisso(CShort(i - 1)).SelectedIndex = Value
        End Set
    End Property
    Public WriteOnly Property pEnaList(ByVal i As Short) As Boolean
        Set(ByVal Value As Boolean)
            On Error Resume Next
            ComboFisso(CShort(i - 1)).Enabled = Value
        End Set
    End Property

    Public Property pComboListL(ByVal i As Short) As Short
        Get
            pComboListL = CShort(ComboLibero(CShort(i - 1)).SelectedIndex)
        End Get
        Set(ByVal Value As Short)
            On Error Resume Next
            ComboLibero(CShort(i - 1)).SelectedIndex = Value
        End Set
    End Property
    Public WriteOnly Property pEnaListL(ByVal i As Short) As Boolean
        Set(ByVal Value As Boolean)
            On Error Resume Next
            ComboLibero(CShort(i - 1)).Enabled = Value
        End Set
    End Property
    Public WriteOnly Property pHelp(ByVal i As Short) As String
        Set(ByVal Value As String)
            Help(i) = Value
        End Set
    End Property
    Public WriteOnly Property pArchivio(ByVal i As Short) As Short
        Set(ByVal Value As Short)
            Archivio(i) = Value
        End Set
    End Property
    Private Sub HScroll1_Scroll(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.ScrollEventArgs) Handles HScroll1.Scroll
        Select Case eventArgs.Type
            Case System.Windows.Forms.ScrollEventType.EndScroll
                HScroll1_Change(eventArgs.NewValue)
        End Select
    End Sub
    Private Sub VScroll1_Scroll(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.ScrollEventArgs) Handles VScroll1.Scroll
        Select Case eventArgs.Type
            Case System.Windows.Forms.ScrollEventType.EndScroll
                VScroll1_Change(eventArgs.NewValue)
        End Select
    End Sub
End Class