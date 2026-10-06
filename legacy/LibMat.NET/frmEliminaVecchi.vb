Imports System.Collections
Imports System.Collections.Specialized
Imports System.Data
Imports System.Data.OleDb
Public Class frmEliminaVecchi
    Inherits System.Windows.Forms.Form
    Public Lista As StringDictionary
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
    Friend WithEvents CheckedListBox1 As System.Windows.Forms.CheckedListBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.CheckedListBox1 = New System.Windows.Forms.CheckedListBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmdOK = New System.Windows.Forms.Button
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'CheckedListBox1
        '
        Me.CheckedListBox1.Location = New System.Drawing.Point(32, 88)
        Me.CheckedListBox1.Name = "CheckedListBox1"
        Me.CheckedListBox1.Size = New System.Drawing.Size(472, 184)
        Me.CheckedListBox1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(40, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(464, 64)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "I seguenti materiali non risultano presenti nell'edizione/addenda ASME applicabil" & _
        "e e saranno eliminati permanentemente dalla lista materiali di Lancio. Deselezio" & _
        "nare quei materiali che si desidera mantenere."
        '
        'cmdOK
        '
        Me.cmdOK.Location = New System.Drawing.Point(424, 288)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(80, 32)
        Me.cmdOK.TabIndex = 2
        Me.cmdOK.Text = "OK"
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(336, 288)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(80, 32)
        Me.cmdCancel.TabIndex = 3
        Me.cmdCancel.Text = "Cancel"
        '
        'frmEliminaVecchi
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(544, 336)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CheckedListBox1)
        Me.Name = "frmEliminaVecchi"
        Me.Text = "Eliminazione materiali obsoleti"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub frmEliminaVecchi_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        Dim Mat As String
        Me.CheckedListBox1.Items.Clear()
        For Each Mat In Lista.Keys
            Me.CheckedListBox1.Items.Add(Mat, True)
        Next
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Hide()
    End Sub

    Private Sub cmdOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        Dim i As Integer, Ind As Integer
        Dim r As New DataTable
        Dim cmd As OleDbDataAdapter = New OleDbDataAdapter("SELECT * from ListaMat", MatBase)
        cmd.Fill(r)
        Dim CB As OleDbCommandBuilder = New OleDbCommandBuilder(cmd)
        Dim dvr As DataView = New DataView(r)
        dvr.Sort = "Ind"
        For i = 0 To Me.CheckedListBox1.Items.Count - 1
            If Me.CheckedListBox1.GetItemChecked(i) Then
                Ind = CInt(Lista.Item(CStr(Me.CheckedListBox1.Items(i))))
                Dim iFound As Integer = dvr.Find(Ind)
                If iFound = -1 Then
                    MsgBox("Materiale " & Trim(CStr(Me.CheckedListBox1.Items(i))) & " non trovato")
                    'Exit Sub
                End If
                EliminaDB(dvr(iFound), CShort(Ind), CType(dvr(iFound)("Classe"), ClasseMateriale))
            End If
        Next
        cmd.Update(r)
        r.Dispose()
        Hide()
    End Sub
End Class
