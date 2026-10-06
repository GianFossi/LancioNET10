Option Explicit On 
Option Strict On
Imports System.Windows.Forms
Public Class frmUpDateCampi
    Inherits System.Windows.Forms.Form
    Private Campo As String, Valore As String
    Private rs As DataTable

#Region " Codice generato da Progettazione Windows Form "

    Public Sub New()
        MyBase.New()

        'Chiamata richiesta da Progettazione Windows Form.
        InitializeComponent()
        'Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent()

    End Sub

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Richiesto da Progettazione Windows Form
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura che segue è richiesta da Progettazione Windows Form.
    'Può essere modificata in Progettazione Windows Form.  
    'Non modificarla nell'editor del codice.
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label
        Me.ListBox1 = New System.Windows.Forms.ListBox
        Me.cmdOK = New System.Windows.Forms.Button
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(16, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(232, 88)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nel database di aggiornamento non si trova un campo"
        '
        'ListBox1
        '
        Me.ListBox1.Location = New System.Drawing.Point(8, 120)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(240, 355)
        Me.ListBox1.TabIndex = 1
        '
        'cmdOK
        '
        Me.cmdOK.Location = New System.Drawing.Point(136, 488)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(112, 32)
        Me.cmdOK.TabIndex = 2
        Me.cmdOK.Text = "OK"
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(8, 488)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(120, 32)
        Me.cmdCancel.TabIndex = 3
        Me.cmdCancel.Text = "Annulla"
        '
        'frmUpDateCampi
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(256, 528)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmUpDateCampi"
        Me.Text = "Ricerca campi database"
        Me.ResumeLayout(False)

    End Sub

#End Region
    Public Property prCampo() As String
        Get
            Return Campo
        End Get
        Set(ByVal Value As String)
            Campo = Value
        End Set
    End Property
    Public Property prValore() As String
        Get
            Return Valore
        End Get
        Set(ByVal Value As String)
            Valore = Value
        End Set
    End Property
    Public Property prrs() As DataTable
        Get
            Return rs
        End Get
        Set(ByVal Value As DataTable)
            rs = Value
        End Set
    End Property
    Private Sub Inizializza()
        Dim i As Integer
        Label1.Text = Label1.Text & " " & Campo & ". Scegliere tra i campi disponibli quello applicabile."
        ListBox1.Items.Clear()
        For i = 0 To rs.Columns.Count - 1
            ListBox1.Items.Add(rs.Columns(i).Caption)
        Next
    End Sub

    Private Sub Label1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub

    Private Sub ListBox1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBox1.Click
        prValore = CStr(ListBox1.SelectedItem)
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        prValore = ""
        Hide()
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        Hide()
    End Sub

    Private Sub frmUpDateCampi_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        Inizializza()
    End Sub
End Class
