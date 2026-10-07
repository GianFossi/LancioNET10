Option Strict Off
Option Explicit On
Imports System.Windows.forms
Imports VB = Microsoft.VisualBasic
Friend Class frmForm
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
	Public WithEvents Procedi As System.Windows.Forms.Button
    Public WithEvents ListViewMat As System.windows.Forms.ListView
    Public WithEvents _optOrd_1 As System.Windows.Forms.RadioButton
    Public WithEvents _optOrd_0 As System.Windows.Forms.RadioButton
    Public WithEvents Frame1 As System.Windows.Forms.GroupBox
    Public WithEvents cmdOK As System.Windows.Forms.Button
    Public WithEvents pctForm As System.Windows.Forms.PictureBox
    Public WithEvents _ListViewSpess_0 As System.windows.forms.ListView
    'Public WithEvents ListViewSpess As Microsoft.VisualBasic.Compatibility.VB6.lis
    Public optOrd As New System.Collections.Generic.Dictionary(Of Integer, RadioButton)
    'NOTA: la routine seguente è richiesta dalla progettazione Windows Form.
    'Può essere modificata utilizzando la finestra di progettazione Windows Form.
    'Non modificarla mediante l'editor di codice.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmForm))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Procedi = New System.Windows.Forms.Button
        Me.ListViewMat = New System.windows.forms.ListView
        Me.Frame1 = New System.Windows.Forms.GroupBox
        Me._optOrd_1 = New System.Windows.Forms.RadioButton
        Me._optOrd_0 = New System.Windows.Forms.RadioButton
        Me.cmdOK = New System.Windows.Forms.Button
        Me.pctForm = New System.Windows.Forms.PictureBox
        Me._ListViewSpess_0 = New System.windows.forms.ListView
        '    Me.ListViewSpess = New AxListViewArray.AxListViewArray(Me.components)
        Me.Frame1.SuspendLayout()
        CType(Me._ListViewSpess_0, System.ComponentModel.ISupportInitialize).BeginInit()
        '     CType(Me.ListViewSpess, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Procedi
        '
        Me.Procedi.BackColor = System.Drawing.SystemColors.Control
        Me.Procedi.Cursor = System.Windows.Forms.Cursors.Default
        Me.Procedi.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Procedi.Location = New System.Drawing.Point(512, 416)
        Me.Procedi.Name = "Procedi"
        Me.Procedi.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Procedi.Size = New System.Drawing.Size(89, 17)
        Me.Procedi.TabIndex = 7
        Me.Procedi.Text = "Procedi"
        '
        'ListViewMat
        '
        Me.ListViewMat.Location = New System.Drawing.Point(512, 72)
        Me.ListViewMat.Name = "ListViewMat"
        Me.ListViewMat.Size = New System.Drawing.Size(137, 113)
        Me.ListViewMat.TabIndex = 5
        '
        'Frame1
        '
        Me.Frame1.BackColor = System.Drawing.SystemColors.Control
        Me.Frame1.Controls.Add(Me._optOrd_1)
        Me.Frame1.Controls.Add(Me._optOrd_0)
        Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame1.Location = New System.Drawing.Point(512, 8)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame1.Size = New System.Drawing.Size(137, 57)
        Me.Frame1.TabIndex = 2
        Me.Frame1.TabStop = False
        Me.Frame1.Text = "Criterio di ordinamento"
        '
        '_optOrd_1
        '
        Me._optOrd_1.BackColor = System.Drawing.SystemColors.Control
        Me._optOrd_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._optOrd_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.optOrd.Add(1, Me._optOrd_1)
        Me._optOrd_1.Location = New System.Drawing.Point(8, 32)
        Me._optOrd_1.Name = "_optOrd_1"
        Me._optOrd_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._optOrd_1.Size = New System.Drawing.Size(121, 17)
        Me._optOrd_1.TabIndex = 4
        Me._optOrd_1.TabStop = True
        Me._optOrd_1.Text = "Larghezza decresc."
        '
        '_optOrd_0
        '
        Me._optOrd_0.BackColor = System.Drawing.SystemColors.Control
        Me._optOrd_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._optOrd_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.optOrd.Add(0, Me._optOrd_0)
        Me._optOrd_0.Location = New System.Drawing.Point(8, 16)
        Me._optOrd_0.Name = "_optOrd_0"
        Me._optOrd_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._optOrd_0.Size = New System.Drawing.Size(121, 17)
        Me._optOrd_0.TabIndex = 3
        Me._optOrd_0.TabStop = True
        Me._optOrd_0.Text = "Altezza decrescente"
        '
        'cmdOK
        '
        Me.cmdOK.BackColor = System.Drawing.SystemColors.Control
        Me.cmdOK.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdOK.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdOK.Location = New System.Drawing.Point(512, 440)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdOK.Size = New System.Drawing.Size(41, 17)
        Me.cmdOK.TabIndex = 1
        Me.cmdOK.Text = "OK"
        '
        'pctForm
        '
        Me.pctForm.BackColor = System.Drawing.SystemColors.Window
        Me.pctForm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pctForm.Cursor = System.Windows.Forms.Cursors.Default
        Me.pctForm.Font = New System.Drawing.Font("Arial", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pctForm.ForeColor = System.Drawing.SystemColors.WindowText
        Me.pctForm.Location = New System.Drawing.Point(8, 8)
        Me.pctForm.Name = "pctForm"
        Me.pctForm.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.pctForm.Size = New System.Drawing.Size(497, 473)
        Me.pctForm.TabIndex = 0
        Me.pctForm.TabStop = False
        '
        '_ListViewSpess_0
        '
        '    Me.ListViewSpess.SetIndex(Me._ListViewSpess_0, CType(0, Short))
        Me._ListViewSpess_0.Location = New System.Drawing.Point(512, 192)
        Me._ListViewSpess_0.Name = "_ListViewSpess_0"
        Me._ListViewSpess_0.Size = New System.Drawing.Size(137, 89)
        Me._ListViewSpess_0.TabIndex = 6
        Me._ListViewSpess_0.Visible = False
        '
        'ListViewSpess
        '
        '
        'optOrd
        '
        '
        'frmForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(658, 484)
        Me.Controls.Add(Me.Procedi)
        Me.Controls.Add(Me.ListViewMat)
        Me.Controls.Add(Me.Frame1)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.pctForm)
        Me.Controls.Add(Me._ListViewSpess_0)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Location = New System.Drawing.Point(4, 23)
        Me.Name = "frmForm"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "Lamieramenti"
        Me.Frame1.ResumeLayout(False)
        CType(Me._ListViewSpess_0, System.ComponentModel.ISupportInitialize).EndInit()
        '  CType(Me.ListViewSpess, System.ComponentModel.ISupportInitialize).EndInit()
        For Each control In optOrd.Values
            AddHandler control.CheckedChanged, AddressOf optOrd_CheckedChanged
        Next
        Me.ResumeLayout(False)

    End Sub
#End Region 
#Region "Supporto aggiornamento "
	Private Shared m_vb6FormDefInstance As frmForm
	Private Shared m_InitializingDefInstance As Boolean
	Public Shared Property DefInstance() As frmForm
		Get
			If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
				m_InitializingDefInstance = True
				m_vb6FormDefInstance = New frmForm()
				m_InitializingDefInstance = False
			End If
			DefInstance = m_vb6FormDefInstance
		End Get
		Set
			m_vb6FormDefInstance = Value
		End Set
	End Property
#End Region 
    Public myfont As Font
    Public mybrush As SolidBrush
    Public x, y As Single
    Private Sub Inizializza()
        myfont = pctForm.Font
        mybrush = New SolidBrush(Color.Black)
    End Sub
    Private Sub cmdOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOK.Click
        Hide()
        Me.Close()
    End Sub

    Private Sub frmForm_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Prelimin()
        optOrd(0).Checked = True
        RiempiLista()
        Funzioni.DisRut.DoveDisegno = pctForm
    End Sub

    'UPGRADE_WARNING: Form evento frmForm.QueryUnload presenta un nuovo comportamento. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup2065"'
    Private Sub frmForm_Closing(ByVal eventSender As System.Object, ByVal eventArgs As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Dim Cancel As Short = eventArgs.Cancel
        OffTrap()
        'Funzioni.Class_Terminate
        'Set Funzioni = Nothing
        eventArgs.Cancel = Cancel
    End Sub

    Private Sub ListViewMat_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles ListViewMat.ItemCheck
        Dim Item As System.Windows.Forms.ListViewItem
        Dim ListviewSpess As System.Windows.Forms.ListView
        Item = ListViewMat.Items(e.Index)
        Dim Sp As Single
        If Item.Checked Then
            ListviewSpess = lCarica(Item.Index)
            With ListviewSpess
                .Items.Clear()
                dvIUNQ.RowFilter = "Indmat=" & VB.Right(Item.Tag, Len(Item.Tag) - 1)
                Dim i As Short
                For i = 0 To dvIUNQ.Count - 1
                    If dvIUNQ(i)("Variab1") <> Sp Then
                        Sp = dvIUNQ(i)("Variab1")
                        Dim l As System.Windows.Forms.ListViewItem = .Items.Add("boh") ', , "Spessore" & Str(Sp))
                        l.Tag = "Spessore" & Str(Sp)
                    End If
                Next
            End With
            ListViewMat_ItemClick(ListViewMat, New EventArgs)
        Else
            ListviewSpess.Visible = False
        End If
    End Sub
    Private Function lCarica(ByVal i As Integer) As System.windows.forms.ListView
        Dim l As System.windows.forms.ListView = New System.windows.forms.ListView
        l.Location = New System.Drawing.Point(512, 72)
        l.Name = "ListViewMat" + "_" + i.ToString
        l.Size = New System.Drawing.Size(137, 113)
        Controls.Add(l)
        AddHandler l.ItemCheck, AddressOf ListViewSpess_ItemCheck
        AddHandler l.SelectedIndexChanged, AddressOf ListViewSpess_ItemClick
    End Function
    Private Sub ListViewMat_ItemClick(ByVal Sender As System.Object, ByVal eventArgs As System.EventArgs) Handles ListViewMat.SelectedIndexChanged
        Dim Index As Short = ListViewMat.SelectedItems(0).Index
        Dim c As Control
        Dim Item As ListViewItem = ListViewMat.Items(Index)
        Visibile(Item)
        IndMatClick = Val(VB.Right(Item.Tag, Len(Item.Tag) - 1))
        For Each c In Controls
            If c.Name = "ListViewMat" + "_" + Index.ToString Then
                ListViewSpess_ItemClick(c, New System.EventArgs)
                Exit For
            End If
        Next
    End Sub
    Private Sub ListViewSpess_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs)
        Dim Index As Short = CType(sender, ListView).CheckedItems(0).Index
        Dim Item As ListViewItem = CType(sender, ListView).Items(Index)
        If Item.Checked Then ListViewSpess_ItemClick(sender, New System.EventArgs)
    End Sub
    Private Sub ListViewSpess_ItemClick(ByVal Sender As System.Object, ByVal eventArgs As System.EventArgs)
        Dim Index As Short = CType(Sender, ListView).SelectedItems(0).Index
        Dim Item As ListViewItem = CType(Sender, ListView).Items(Index)
        SpClick = Val(VB.Right(Item.Text, Len(Item.Text) - 8))
        DisegnaLamiere()
    End Sub
    'UPGRADE_WARNING: L'evento optOrd.CheckedChanged può essere generato quando il form è inizializzato. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup2075"'
    Private Sub optOrd_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        If eventSender.Checked Then
            Dim Index As Short = IndexedControls.IndexOf(optOrd, eventSender)
            PrimaLungDopoLarg = optOrd(0).Checked
            Riordina()
        End If
    End Sub
    Private Sub Procedi_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Procedi.Click
        PreparaLamiere()
        Formati()
    End Sub
    Public Sub Visibile(ByVal Item As ListViewItem)
        Dim l As System.Windows.Forms.ListViewItem
        Dim c As Control
        For Each c In Controls
            If c.Name.IndexOf("ListViewSpess") > -1 Then
                Dim i As Short = CShort(c.Name.Substring(14))
                CType(c, ListView).Visible = i = Item.Index
            End If
        Next
    End Sub
End Class