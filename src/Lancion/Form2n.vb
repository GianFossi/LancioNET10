Option Strict On
Option Explicit On
Imports System.Data
Imports System.Data.OleDb
Friend Class Form2
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
    Public WithEvents cmdhelp As System.Windows.Forms.Button
    Public WithEvents Command3 As System.Windows.Forms.Button
    Public WithEvents _txtQualif_2 As System.Windows.Forms.TextBox
    Public WithEvents _txtQualif_1 As System.Windows.Forms.TextBox
    Public WithEvents _txtQualif_0 As System.Windows.Forms.TextBox
    Public WithEvents Text3 As System.Windows.Forms.TextBox
    Public WithEvents cmdCambia As System.Windows.Forms.Button
    Public WithEvents Command2 As System.Windows.Forms.Button
    Public WithEvents Command1 As System.Windows.Forms.Button
    Public WithEvents Text2 As System.Windows.Forms.TextBox
    Public WithEvents Text1 As System.Windows.Forms.TextBox
    Public WithEvents Label6 As System.Windows.Forms.Label
    Public WithEvents Label5 As System.Windows.Forms.Label
    Public WithEvents Label4 As System.Windows.Forms.Label
    Public WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents Label1 As System.Windows.Forms.Label
    Public txtQualif As New System.Collections.Generic.Dictionary(Of Integer, TextBox)
    'NOTA: la routine seguente è richiesta dalla progettazione Windows Form.
    'Può essere modificata utilizzando la finestra di progettazione Windows Form.
    'Non modificarla mediante l'editor di codice.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmdhelp = New System.Windows.Forms.Button
        Me.Command3 = New System.Windows.Forms.Button
        Me._txtQualif_2 = New System.Windows.Forms.TextBox
        Me._txtQualif_1 = New System.Windows.Forms.TextBox
        Me._txtQualif_0 = New System.Windows.Forms.TextBox
        Me.Text3 = New System.Windows.Forms.TextBox
        Me.cmdCambia = New System.Windows.Forms.Button
        Me.Command2 = New System.Windows.Forms.Button
        Me.Command1 = New System.Windows.Forms.Button
        Me.Text2 = New System.Windows.Forms.TextBox
        Me.Text1 = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'cmdhelp
        '
        Me.cmdhelp.BackColor = System.Drawing.SystemColors.Control
        Me.cmdhelp.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdhelp.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdhelp.Location = New System.Drawing.Point(216, 184)
        Me.cmdhelp.Name = "cmdhelp"
        Me.cmdhelp.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdhelp.Size = New System.Drawing.Size(49, 25)
        Me.cmdhelp.TabIndex = 16
        Me.cmdhelp.Text = "&Help"
        '
        'Command3
        '
        Me.Command3.BackColor = System.Drawing.SystemColors.Control
        Me.Command3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command3.Location = New System.Drawing.Point(88, 184)
        Me.Command3.Name = "Command3"
        Me.Command3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command3.Size = New System.Drawing.Size(121, 25)
        Me.Command3.TabIndex = 15
        Me.Command3.Text = "Cambia Utente"
        '
        '_txtQualif_2
        '
        Me._txtQualif_2.AcceptsReturn = True
        Me._txtQualif_2.AutoSize = False
        Me._txtQualif_2.BackColor = System.Drawing.SystemColors.Window
        Me._txtQualif_2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtQualif_2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtQualif.Add(2, Me._txtQualif_2)
        Me._txtQualif_2.Location = New System.Drawing.Point(96, 104)
        Me._txtQualif_2.MaxLength = 0
        Me._txtQualif_2.Name = "_txtQualif_2"
        Me._txtQualif_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtQualif_2.Size = New System.Drawing.Size(169, 20)
        Me._txtQualif_2.TabIndex = 12
        Me._txtQualif_2.Text = ""
        Me._txtQualif_2.Visible = False
        '
        '_txtQualif_1
        '
        Me._txtQualif_1.AcceptsReturn = True
        Me._txtQualif_1.AutoSize = False
        Me._txtQualif_1.BackColor = System.Drawing.SystemColors.Window
        Me._txtQualif_1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtQualif_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtQualif.Add(1, Me._txtQualif_1)
        Me._txtQualif_1.Location = New System.Drawing.Point(96, 80)
        Me._txtQualif_1.MaxLength = 0
        Me._txtQualif_1.Name = "_txtQualif_1"
        Me._txtQualif_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtQualif_1.Size = New System.Drawing.Size(169, 20)
        Me._txtQualif_1.TabIndex = 11
        Me._txtQualif_1.Text = ""
        Me._txtQualif_1.Visible = False
        '
        '_txtQualif_0
        '
        Me._txtQualif_0.AcceptsReturn = True
        Me._txtQualif_0.AutoSize = False
        Me._txtQualif_0.BackColor = System.Drawing.SystemColors.Window
        Me._txtQualif_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtQualif_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtQualif.Add(0, Me._txtQualif_0)
        Me._txtQualif_0.Location = New System.Drawing.Point(96, 56)
        Me._txtQualif_0.MaxLength = 0
        Me._txtQualif_0.Name = "_txtQualif_0"
        Me._txtQualif_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtQualif_0.Size = New System.Drawing.Size(169, 20)
        Me._txtQualif_0.TabIndex = 10
        Me._txtQualif_0.Text = ""
        Me._txtQualif_0.Visible = False
        '
        'Text3
        '
        Me.Text3.AcceptsReturn = True
        Me.Text3.AutoSize = False
        Me.Text3.BackColor = System.Drawing.SystemColors.Window
        Me.Text3.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Text3.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text3.Location = New System.Drawing.Point(96, 128)
        Me.Text3.MaxLength = 0
        Me.Text3.Name = "Text3"
        Me.Text3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text3.Size = New System.Drawing.Size(169, 20)
        Me.Text3.TabIndex = 8
        Me.Text3.Text = ""
        Me.Text3.Visible = False
        '
        'cmdCambia
        '
        Me.cmdCambia.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCambia.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCambia.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCambia.Location = New System.Drawing.Point(8, 152)
        Me.cmdCambia.Name = "cmdCambia"
        Me.cmdCambia.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCambia.Size = New System.Drawing.Size(137, 25)
        Me.cmdCambia.TabIndex = 6
        Me.cmdCambia.Text = "&Cambia PassWord"
        '
        'Command2
        '
        Me.Command2.BackColor = System.Drawing.SystemColors.Control
        Me.Command2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command2.Location = New System.Drawing.Point(152, 152)
        Me.Command2.Name = "Command2"
        Me.Command2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command2.Size = New System.Drawing.Size(57, 25)
        Me.Command2.TabIndex = 5
        Me.Command2.Text = "&Annulla"
        '
        'Command1
        '
        Me.Command1.BackColor = System.Drawing.SystemColors.Control
        Me.Command1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command1.Location = New System.Drawing.Point(216, 152)
        Me.Command1.Name = "Command1"
        Me.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command1.Size = New System.Drawing.Size(49, 25)
        Me.Command1.TabIndex = 4
        Me.Command1.Text = "&Fatto"
        '
        'Text2
        '
        Me.Text2.AcceptsReturn = True
        Me.Text2.AutoSize = False
        Me.Text2.BackColor = System.Drawing.SystemColors.Window
        Me.Text2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Text2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text2.Location = New System.Drawing.Point(96, 32)
        Me.Text2.MaxLength = 0
        Me.Text2.Name = "Text2"
        Me.Text2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text2.Size = New System.Drawing.Size(65, 20)
        Me.Text2.TabIndex = 3
        Me.Text2.Text = "????"
        '
        'Text1
        '
        Me.Text1.AcceptsReturn = True
        Me.Text1.AutoSize = False
        Me.Text1.BackColor = System.Drawing.SystemColors.Window
        Me.Text1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Text1.Enabled = False
        Me.Text1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text1.Location = New System.Drawing.Point(96, 8)
        Me.Text1.MaxLength = 0
        Me.Text1.Name = "Text1"
        Me.Text1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text1.Size = New System.Drawing.Size(169, 20)
        Me.Text1.TabIndex = 2
        Me.Text1.Text = ""
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(0, Byte), CType(255, Byte))
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.Font = New System.Drawing.Font("Arial", 7.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(160, 32)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(104, 16)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Conferma nuova PW"
        Me.Label6.Visible = False
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.FromArgb(CType(128, Byte), CType(128, Byte), CType(0, Byte))
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(168, 32)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(97, 17)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Nuova PassWord"
        Me.Label5.Visible = False
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(0, Byte))
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label4.Location = New System.Drawing.Point(8, 56)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(65, 17)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Qualifiche:"
        Me.Label4.Visible = False
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(0, Byte))
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Enabled = False
        Me.Label3.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label3.Location = New System.Drawing.Point(8, 128)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(65, 17)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Nuova PW:"
        Me.Label3.Visible = False
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(0, Byte))
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label2.Location = New System.Drawing.Point(8, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(65, 17)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Password:"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(0, Byte))
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label1.Location = New System.Drawing.Point(8, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(65, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nome:"
        '
        'Form2
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 12)
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.ClientSize = New System.Drawing.Size(279, 216)
        Me.ControlBox = False
        Me.Controls.Add(Me.cmdhelp)
        Me.Controls.Add(Me.Command3)
        Me.Controls.Add(Me._txtQualif_2)
        Me.Controls.Add(Me._txtQualif_1)
        Me.Controls.Add(Me._txtQualif_0)
        Me.Controls.Add(Me.Text3)
        Me.Controls.Add(Me.cmdCambia)
        Me.Controls.Add(Me.Command2)
        Me.Controls.Add(Me.Command1)
        Me.Controls.Add(Me.Text2)
        Me.Controls.Add(Me.Text1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 7.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.SystemColors.WindowText
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Location = New System.Drawing.Point(199, 98)
        Me.Name = "Form2"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Autenticazione Utente"

        Me.ResumeLayout(False)

    End Sub
#End Region
#Region "Supporto aggiornamento "
    Private Shared m_vb6FormDefInstance As Form2
    Private Shared m_InitializingDefInstance As Boolean
    Public Shared Property DefInstance() As Form2
        Get
            If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
                m_InitializingDefInstance = True
                m_vb6FormDefInstance = New Form2
                m_InitializingDefInstance = False
            End If
            DefInstance = m_vb6FormDefInstance
        End Get
        Set(ByVal Value As Form2)
            m_vb6FormDefInstance = Value
        End Set
    End Property
#End Region
    Public NuovoUtente As Boolean
    Private PosPW As Short
    Private BufPW As String
    Private NuovaPW As Boolean
    Private NuovaPWfine As Boolean
    Private PassWord As String

    Private Sub cmdCambia_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCambia.Click
        If Not Convalidato = 1 Then
            Convalida()
            If Not Convalidato = 1 Then
                'MsgBox "Non hai correttamente inserito la vecchia PassWord", vbCritical + vbOKCancel, "PassWord per Lancio"
                Exit Sub
            End If
        End If
        Text2.Text = "????"
        Label5.Visible = True
        Text2.Focus()
        NuovaPW = True
    End Sub

    Private Sub cmdhelp_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdhelp.Click
        System.Windows.Forms.SendKeys.Send("{F1}")
    End Sub

    Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
        If NuovoUtente Then
            Convalidato = 1
            Hide()
            Exit Sub
        End If
        Convalida()
        If Convalidato = 1 Then Hide()
    End Sub

    Private Sub Command2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command2.Click
        Convalidato = 0
        Hide()
    End Sub

    Private Sub Command3_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command3.Click
        Convalidato = -1
        Hide()
    End Sub

    Private Sub Form2_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
        Dim Query As New DataTable
        Dim lcmd As oledbdataadapter
        Dim i As Short
        Label4.Visible = False
        txtQualif(0).Visible = False
        txtQualif(1).Visible = False
        txtQualif(2).Visible = False
        If MyTable Is Nothing Then Exit Sub
        If NuovoUtente Then
            Text1.Enabled = True
            Text = "Inserimento nuovo Utente"
            cmdCambia.Visible = False
            Command3.Visible = False
            Label2.Visible = False
            Text2.Visible = False
            Text1.Focus()
            Exit Sub
        End If
        BufPW = Space(4)
        If Not IsDBNull(MyTable.Rows(0)("PassWord")) Then
            PassWord = CStr(MyTable.Rows(0)("PassWord"))
        Else
            PassWord = ""
        End If
        Text1.Text = Trim(Utente.Nome)
        For i = 1 To 3
            If Not IsDBNull(MyTable.Rows(0)(i + 2)) Then
                lcmd = New OleDbDataAdapter("SELECT * FROM Qualifiche WHERE Qualif = " & Chr(34) & CStr(MyTable.Rows(0)(i + 2)) & Chr(34), MyDatabase)
                cmd.Fill(Query)
                If Query.Rows.Count > 0 Then
                    Label4.Visible = True
                    txtQualif(CShort(i - 1)).Visible = True
                    txtQualif(CShort(i - 1)).Text = CStr(Query.Rows(0)("Esteso"))
                End If
                Query.Dispose()
            End If
        Next
        PosPW = 1

    End Sub

    Private Sub Text2_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles Text2.KeyDown
        Dim KeyCode As Keys = eventArgs.KeyCode
        Dim Shift As Short = CShort(eventArgs.KeyData \ &H10000)
        Dim Testo As String
        If Not NuovaPW Then cmdCambia.Enabled = False
        Select Case KeyCode
            Case Keys.Return
                If PosPW = 5 Then
                    Convalida()
                    PosPW = 1
                Else
                    Beep()
                End If
            Case Keys.Back
                If PosPW > 1 Then
                    PosPW = PosPW - CShort(1)
                    Testo = Text2.Text
                    Mid(Testo, PosPW, 1) = "?"
                    Text2.Text = Testo
                    Mid(BufPW, PosPW, 1) = " "
                    Text2.SelectionStart = PosPW - 1
                Else
                    Beep()
                End If
            Case Keys.D0 To Keys.D9, Keys.A To Keys.Z
                Exit Sub
            Case Else
                Beep()
        End Select
        KeyCode = 0
    End Sub

    Private Sub Text2_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles Text2.KeyPress
        Dim KeyAscii As Integer = Asc(eventArgs.KeyChar)
        Dim Testo As String
        Select Case KeyAscii
            Case Asc(CStr(Keys.D0)) To Keys.D9, Keys.A To Keys.Z, 97 To 122
                If PosPW <= 4 Then
                    Mid(BufPW, PosPW, 1) = Chr(KeyAscii)
                    Testo = Text2.Text
                    Mid(Testo, PosPW, 1) = "*"
                    Text2.Text = Testo
                    PosPW = PosPW + CShort(1)
                    Text2.SelectionStart = PosPW - 1
                Else
                    Beep()
                End If
            Case Else
                Beep()
        End Select
        KeyAscii = 0
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub Convalida()
        If NuovaPW And Not NuovaPWfine Then
            NewPW()
        ElseIf Len(Trim(PassWord)) = 0 Then
            Convalidato = 1
            Hide()
        ElseIf InStr(BufPW, PassWord) > 0 Then
            Convalidato = 1
            If NuovaPWfine Then NewPW()
            cmdCambia.Enabled = True
            '       Hide
        Else
            MsgBox("PassWord non valida", MsgBoxStyle.Critical)
            Convalidato = 0
            PosPW = 1
            Text2.Text = "????"
            Text2.Focus()
        End If
    End Sub

    Private Sub NewPW()
        Label5.Visible = False
        Label6.Visible = True
        PassWord = BufPW
        If NuovaPWfine Then
            Dim drv As DataRowView = MyTable.DefaultView(0)
            drv.BeginEdit()
            drv("PassWord") = PassWord
            drv.EndEdit()
            cmd.Update(MyTable)
            Hide()
        Else
            NuovaPWfine = True
            PosPW = 1
            Text2.Text = "????"
            Text2.Focus()
        End If
    End Sub
End Class