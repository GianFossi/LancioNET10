Option Strict On
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports System.Data
Imports System.Data.OleDb
Imports System.windows
Imports System.drawing
Friend Class frmNote
	Inherits System.Windows.Forms.Form
#Region "Codice generato dalla finestra di progettazione Windows Form "
	Public Sub New()
		MyBase.New()
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
    Public WithEvents cmdCancel As System.Windows.Forms.Button
    Public WithEvents cmdOK As System.Windows.Forms.Button
    'NOTA: la routine seguente è richiesta dalla progettazione Windows Form.
    'Può essere modificata utilizzando la finestra di progettazione Windows Form.
    'Non modificarla mediante l'editor di codice.
    Friend WithEvents DBNote As System.Windows.Forms.DataGrid
    Friend WithEvents DBnote1 As System.Windows.Forms.DataGrid
    Friend WithEvents Stile As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents Col_0 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents Col_1 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents Col_2 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents Col_3 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents Col_4 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents Col_5 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents Stle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents Col1_1 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents Col1_2 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents Col1_3 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents Col1_4 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents Col1_5 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents Col1_0 As System.Windows.Forms.DataGridTextBoxColumn
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdOK = New System.Windows.Forms.Button
        Me.DBNote = New System.Windows.Forms.DataGrid
        Me.Stile = New System.Windows.Forms.DataGridTableStyle
        Me.Col_0 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.Col_1 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.Col_2 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.Col_3 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.Col_4 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.Col_5 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DBnote1 = New System.Windows.Forms.DataGrid
        Me.Stle1 = New System.Windows.Forms.DataGridTableStyle
        Me.Col1_0 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.Col1_1 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.Col1_2 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.Col1_3 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.Col1_4 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.Col1_5 = New System.Windows.Forms.DataGridTextBoxColumn
        CType(Me.DBNote, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DBnote1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCancel.Location = New System.Drawing.Point(496, 280)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCancel.Size = New System.Drawing.Size(65, 25)
        Me.cmdCancel.TabIndex = 2
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.Visible = False
        '
        'cmdOK
        '
        Me.cmdOK.BackColor = System.Drawing.SystemColors.Control
        Me.cmdOK.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdOK.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdOK.Location = New System.Drawing.Point(568, 280)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdOK.Size = New System.Drawing.Size(57, 25)
        Me.cmdOK.TabIndex = 1
        Me.cmdOK.Text = "OK"
        Me.cmdOK.Visible = False
        '
        'DBNote
        '
        Me.DBNote.CaptionVisible = False
        Me.DBNote.DataMember = ""
        Me.DBNote.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DBNote.Location = New System.Drawing.Point(0, 8)
        Me.DBNote.Name = "DBNote"
        Me.DBNote.Size = New System.Drawing.Size(640, 320)
        Me.DBNote.TabIndex = 3
        Me.DBNote.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.Stile})
        '
        'Stile
        '
        Me.Stile.DataGrid = Me.DBNote
        Me.Stile.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.Col_0, Me.Col_1, Me.Col_2, Me.Col_3, Me.Col_4, Me.Col_5})
        Me.Stile.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.Stile.MappingName = "Notes"
        '
        'Col_0
        '
        Me.Col_0.Format = ""
        Me.Col_0.FormatInfo = Nothing
        Me.Col_0.MappingName = "ID"
        Me.Col_0.Width = 75
        '
        'Col_1
        '
        Me.Col_1.Format = ""
        Me.Col_1.FormatInfo = Nothing
        Me.Col_1.MappingName = "[Notes Group]"
        Me.Col_1.Width = 75
        '
        'Col_2
        '
        Me.Col_2.Format = ""
        Me.Col_2.FormatInfo = Nothing
        Me.Col_2.MappingName = "Addenda"
        Me.Col_2.Width = 75
        '
        'Col_3
        '
        Me.Col_3.Format = ""
        Me.Col_3.FormatInfo = Nothing
        Me.Col_3.MappingName = "note_abrv"
        Me.Col_3.Width = 75
        '
        'Col_4
        '
        Me.Col_4.Format = ""
        Me.Col_4.FormatInfo = Nothing
        Me.Col_4.MappingName = "note_text"
        Me.Col_4.Width = 75
        '
        'Col_5
        '
        Me.Col_5.Format = ""
        Me.Col_5.FormatInfo = Nothing
        Me.Col_5.MappingName = "Tabella"
        Me.Col_5.Width = 75
        '
        'DBnote1
        '
        Me.DBnote1.CaptionVisible = False
        Me.DBnote1.DataMember = ""
        Me.DBnote1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DBnote1.Location = New System.Drawing.Point(0, 0)
        Me.DBnote1.Name = "DBnote1"
        Me.DBnote1.PreferredColumnWidth = 80
        Me.DBnote1.Size = New System.Drawing.Size(640, 272)
        Me.DBnote1.TabIndex = 4
        Me.DBnote1.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.Stle1})
        Me.DBnote1.Visible = False
        '
        'Stle1
        '
        Me.Stle1.DataGrid = Me.DBnote1
        Me.Stle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.Col1_0, Me.Col1_1, Me.Col1_2, Me.Col1_3, Me.Col1_4, Me.Col1_5})
        Me.Stle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.Stle1.MappingName = "Notes1"
        Me.Stle1.PreferredColumnWidth = 80
        '
        'Col1_0
        '
        Me.Col1_0.Format = ""
        Me.Col1_0.FormatInfo = Nothing
        Me.Col1_0.MappingName = "ID"
        Me.Col1_0.Width = 75
        '
        'Col1_1
        '
        Me.Col1_1.Format = ""
        Me.Col1_1.FormatInfo = Nothing
        Me.Col1_1.MappingName = "[Notes Group]"
        Me.Col1_1.Width = 75
        '
        'Col1_2
        '
        Me.Col1_2.Format = ""
        Me.Col1_2.FormatInfo = Nothing
        Me.Col1_2.MappingName = "Addenda"
        Me.Col1_2.Width = 75
        '
        'Col1_3
        '
        Me.Col1_3.Format = ""
        Me.Col1_3.FormatInfo = Nothing
        Me.Col1_3.MappingName = "note_abrv"
        Me.Col1_3.Width = 75
        '
        'Col1_4
        '
        Me.Col1_4.Format = ""
        Me.Col1_4.FormatInfo = Nothing
        Me.Col1_4.MappingName = "note_text"
        Me.Col1_4.Width = 75
        '
        'Col1_5
        '
        Me.Col1_5.Format = ""
        Me.Col1_5.FormatInfo = Nothing
        Me.Col1_5.MappingName = "Tabella"
        Me.Col1_5.Width = 75
        '
        'frmNote
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(639, 325)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.DBNote)
        Me.Controls.Add(Me.DBnote1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmNote"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "Libreria materiali - Visualizzatore delle note"
        CType(Me.DBNote, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DBnote1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
#End Region 
    Private No As Boolean
    Private m As LibMat.MaterialeNew1
    Private Direct As New DataTable
    Private rsDBNote As New DataTable
    Private rsDBNote1 As New DataTable
    Private WithEvents dvDBNote, dvDBNote1 As DataView
    Private dvD As DataView
    Private drv As DataRowView
    Private custCB As OleDbCommandBuilder
    Private cmd As OleDbDataAdapter
    Private cmdDBNote, cmdDBNote1 As OleDbDataAdapter
    Private Codice As Codes
	Private RowColChangeForb As Boolean
	Private GiaRiempito As Boolean
	Private TabNota As String
	Public consult As Boolean
	Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
		'--------------------------------------------
		DBNote.Visible = True
		DBNote1.Visible = False
		cmdOK.Visible = False
		cmdCancel.Visible = False
	End Sub
	Private Sub cmdOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOK.Click
		Dim nuovo, i, j As Short
        nuovo = CShort(rsDBNote1.Rows(DBnote1.CurrentRowIndex)("ID"))
        drv.BeginEdit()
        For i = 1 To CShort(Direct.Columns.Count - 1)
            If CShort(drv(i)) > nuovo Then
                For j = CShort(Direct.Columns.Count - 2) To i Step -1
                    drv(j + 1) = drv(j)
                Next
                drv(i) = nuovo
                Exit For
            ElseIf CShort(drv(i)) = nuovo Then
                Exit For
            ElseIf CShort(drv(i)) = 0 Then
                drv(i) = nuovo
                Exit For
            End If
        Next
        drv.EndEdit()
        '--------------------------------------------
        DBNote.Visible = True
        DBnote1.Visible = False
        cmdOK.Visible = False
        cmdCancel.Visible = False
        Riempi()
        AggNote()
    End Sub
    ' Private Sub DBNote_BeforeColEdit(ByVal eventSender As System.Object, ByVal eventArgs As AxMSDataGridLib.DDataGridEvents_BeforeColEditEvent)
    '     If eventArgs.colIndex = 3 Then
    '         eventArgs.cancel = CShort(True)
    '         On Error GoTo ErrH
    '         If Len(Trim(DBNote.Text)) = 0 Then MenuNote()
    '     End If
    '     On Error Resume Next
    '     If Len(Trim(DBNote.Text)) = 0 Then
    '         eventArgs.cancel = CShort(True)
    '     End If
    '     Exit Sub
    'ErrH:
    '       MenuNote()
    '  End Sub
    'Private Sub DBNote_BeforeDelete(ByVal eventSender As System.Object, ByVal eventArgs As AxMSDataGridLib.DDataGridEvents_BeforeDeleteEvent)
    '    Dim i As Short
    '    Dim Criterio As String
    '    With Direct
    '        .Edit()
    '        For i = CShort(DBNote.Bookmark) To CShort(.Fields.Count - 2)
    '            .Fields(i).Value = .Fields(i + 1).Value
    '        Next
    '        .Fields(.Fields.Count - 1).Value = 0
    '        .Update()
    '    End With
    '    Riempi()
    '    AggNote()
    '    eventArgs.cancel = CShort(True)
    'End Sub
    'Private Sub DBNote_RowColChange(ByVal eventSender As System.Object, ByVal eventArgs As AxMSDataGridLib.DDataGridEvents_RowColChangeEvent)
    '    If eventArgs.lastCol < 0 Or IsNothing(eventArgs.lastRow) Or IsDBNull(eventArgs.lastRow) Or RowColChangeForb Then Exit Sub
    '    If Len(Trim(DBNote.Text)) = 0 Then
    '        MenuNote()
    '    End If
    'End Sub
    Private Sub Inizializza()
        Dim k As Short
        Dim IndNote As Integer
        m = MatElem()
        Try
            If m Is Nothing Then No = True : Exit Sub
            k = CShort(Scheda.TabControl1.SelectedIndex + 1)
            IndNote = m.Caract.Item(k).TextData.IndNote
            Codice = m.Caract.Item(k).TextData.Codice
            cmd = New OleDbDataAdapter("SELECT * FROM IndNote WHERE ID=" & Str(IndNote) & ";", MatBase)
            cmd.Fill(Direct)
            If Direct.Rows.Count = 0 Then
                cmd = New OleDbDataAdapter("SELECT * FROM IndNote", MatBase)
                Dim custCB As OleDbCommandBuilder = New OleDbCommandBuilder(cmd)
                cmd.Fill(Direct)
                dvD = New DataView(Direct)
                Dim drv As DataRowView = dvD.AddNew()
                drv.EndEdit()
                IndNote = CInt(drv("ID"))
                m.Caract.Item(k).TextData.IndNote = IndNote
                dvD.RowFilter = "ID=" & Str(IndNote)
            ElseIf Direct.Rows.Count > 1 Then
                Stop
            Else
                dvD = New DataView(Direct)
            End If
            drv = dvD(0)
            Dim custDB As OleDbCommandBuilder = New OleDbCommandBuilder(cmd)
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
        Desumi()
        Riempi()
    End Sub
    Private Sub Riempi()
        Dim Criterio As String
        With DBNote
            .TableStyles(0).GridColumnStyles(0).Width = 0
            .TableStyles(0).GridColumnStyles(1).Width = 0
            .TableStyles(0).GridColumnStyles(2).Width = 0
            .TableStyles(0).GridColumnStyles(3).Width = CInt(Funzioni.TwipsToPixelsX(495))
            .TableStyles(0).GridColumnStyles(3).HeaderText = "Nota"
            Dim Col_4n As MultiLineColumn = New MultiLineColumn
            Col_4n.TextBox.Multiline = True
            Col_4n.TextBox.WordWrap = True
            Col_4n.AutoAdjustHeight = True
            Col_4n.MappingName = "Note_text"
            Col_4n.Width = CInt(Funzioni.TwipsToPixelsX(8400))
            .TableStyles(0).GridColumnStyles(4).HeaderText = "Testo"
            .TableStyles(0).GridColumnStyles.RemoveAt(5)
            .TableStyles(0).GridColumnStyles.RemoveAt(4)
            .TableStyles(0).GridColumnStyles.Add(Col_4n)
            .TableStyles(0).GridColumnStyles.Add(Col_5)
            .TableStyles(0).GridColumnStyles(5).Width = 0
            RowColChangeForb = True
            .BringToFront()
        End With
        Criterio = "SELECT * FROM Notes WHERE ID IN (" & CStr(drv("Ind1"))
        If CInt(drv("Ind2")) > 0 Then Criterio = Criterio & ", " & Str(drv("Ind2"))
        If CInt(drv("Ind3")) > 0 Then Criterio = Criterio & ", " & Str(drv("Ind3"))
        If CInt(drv("Ind4")) > 0 Then Criterio = Criterio & ", " & Str(drv("Ind4"))
        If CInt(drv("Ind5")) > 0 Then Criterio = Criterio & ", " & Str(drv("Ind5"))
        If CInt(drv("Ind6")) > 0 Then Criterio = Criterio & ", " & Str(drv("Ind6"))
        If CInt(drv("Ind7")) > 0 Then Criterio = Criterio & ", " & Str(drv("Ind7"))
        If CInt(drv("Ind8")) > 0 Then Criterio = Criterio & ", " & Str(drv("Ind8"))
        Criterio = Criterio & ") ORDER BY ID"
        cmdDBNote = New OleDbDataAdapter(Criterio, MatBase)
        cmdDBNote.Fill(rsDBNote)
        rsDBNote.TableName = "Notes"
        dvDBNote = rsDBNote.DefaultView
        DBNote.SetDataBinding(rsDBNote, "")
        If Not GiaRiempito Then
            cmdDBNote1 = New OleDbDataAdapter("SELECT * FROM Notes", MatBase)
            cmdDBNote1.Fill(rsDBNote1)
            rsDBNote1.TableName = "Notes1"
            dvDBNote1 = rsDBNote1.DefaultView
            DBnote1.SetDataBinding(rsDBNote1, "")
        End If
        Dim gDBnote As Drawing.Graphics = Graphics.FromHwnd(DBNote.Handle)
        With dvDBNote
            .AllowNew = Not consult
            .AllowDelete = Not consult
            .AllowEdit = Not consult
        End With
        RowColChangeForb = False
        GiaRiempito = True
    End Sub
    Private Sub MenuNote()
        Dim Scelta As String
        Dim Criterio As String
        DBNote.Visible = False
        DBnote1.Visible = True
        cmdOK.Visible = True
        cmdCancel.Visible = True
        '--------------------------------------------
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        Scelta = "Tabella='" & TabNota & "'"
        Criterio = "SELECT * FROM Notes WHERE " & Scelta
        Criterio = Criterio & " ORDER BY Tabella,[Notes Group],note_abrv"
        cmdDBNote1 = New OleDbDataAdapter(Criterio, MatBase)
        cmdDBNote1.Fill(rsDBNote1)
        rsDBNote1.TableName = "Notes1"
        DBnote1.SetDataBinding(rsDBNote1, "")
        With DBnote1
            .TableStyles(0).GridColumnStyles(0).Width = 0
            .TableStyles(0).GridColumnStyles(1).Width = CInt(Funzioni.TwipsToPixelsX(800))
            .TableStyles(0).GridColumnStyles(1).HeaderText = "Group"
            .TableStyles(0).GridColumnStyles(2).Width = CInt(Funzioni.TwipsToPixelsX(495))
            .TableStyles(0).GridColumnStyles(2).HeaderText = "Add"
            .TableStyles(0).GridColumnStyles(3).Width = CInt(Funzioni.TwipsToPixelsX(400))
            .TableStyles(0).GridColumnStyles(3).HeaderText = "Nota"
            .TableStyles(0).GridColumnStyles(4).Width = CInt(Funzioni.TwipsToPixelsX(6900))
            .TableStyles(0).GridColumnStyles(4).HeaderText = "Testo"
            .TableStyles(0).GridColumnStyles(5).Width = CInt(Funzioni.TwipsToPixelsX(495))
            .TableStyles(0).GridColumnStyles(5).HeaderText = "Tab"
        End With
        With dvDBNote1
            .AllowNew = True
            .AllowDelete = True
            .AllowEdit = True
        End With
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
    End Sub
    Private Sub AggNote()
        Dim note As String = ""
        Dim Criterio As String = ""
        Dim Table As New DataTable
        Dim i As Short
        Dim qualche As Boolean
        Dim r As New DataTable
        Dim l As Short
        Dim cmd As OleDbDataAdapter
        Criterio = "SELECT * FROM Notes WHERE "
        For i = 1 To CShort(Direct.Columns.Count - 2)
            If CSng(drv(i)) > 0 Then
                cmd = New OleDbDataAdapter("SELECT * FROM Notes WHERE ID=" & Str(drv(i)), MatBase)
                cmd.Fill(Table)
                If Table.Rows.Count = 0 Then
                    drv.BeginEdit()
                    drv(i) = 0
                    drv.EndEdit()
                End If
            End If
            If CSng(drv(i)) = 0 And CSng(drv(i + 1)) > 0 Then
                drv.BeginEdit()
                For l = i To CShort(Direct.Columns.Count - 2)
                    drv(l) = drv(l + 1)
                Next
                drv(Direct.Columns.Count - 1) = 0
                drv.EndEdit()
            End If
            If CSng(drv(i)) = CSng(drv(i + 1)) And CSng(drv(i)) > 0 Then
                drv.BeginEdit()
                For l = CShort(i + 1) To CShort(Direct.Columns.Count - 2)
                    drv(l) = drv(l + 1)
                Next
                drv(Direct.Columns.Count - 1) = 0
                'i = i - 1
                drv.EndEdit()
            End If
        Next
        For i = 1 To CShort(Direct.Columns.Count - 1)
            If CSng(drv(i)) > 0 Then
                If i > 1 Then Criterio = Criterio & " OR"
                Criterio = Criterio & " ID=" & Str(drv(i))
                qualche = True
            End If
        Next
        If Not qualche Then Exit Sub
        cmd = New OleDbDataAdapter(Criterio, MatBase)
        cmd.Fill(Table)
        If Table.Rows.Count = 0 Then Exit Sub
        For i = 0 To CShort(Table.Rows.Count - 1)
            If note.Length > 0 Then note = note & ","
            note = note + CStr(Table.Rows(i)("note_abrv"))
        Next i
        Table.Dispose()
        cmd = New OleDbDataAdapter("SELECT * FROM ListaMat WHERE Ind=" & Str(m.Indmat), MatBase)
        cmd.MissingSchemaAction = MissingSchemaAction.AddWithKey
        cmd.Fill(r)
        Dim dvr As DataView = New DataView(r)
        Dim custCB As OleDbCommandBuilder = New OleDbCommandBuilder(cmd)
        Dim drvr As DataRowView = dvr(0)
        drvr.BeginEdit()
        l = CShort(r.Columns("Notes").MaxLength)
        If r.Columns("Notes2").MaxLength < l Then l = CShort(r.Columns("Notes2").MaxLength)
        If note.Length > l Then note = note.Substring(0, l)
        If Codice = 6 Then
            drvr("Notes2") = note
        Else
            drvr("notes") = note
        End If
        drvr.EndEdit()
        cmd.Update(r)
        dvr.Dispose()
        r.Dispose()
        cmd.Dispose()
        custCB.Dispose()
    End Sub
    Private Sub frmNote_Closing(ByVal eventSender As System.Object, ByVal eventArgs As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Dim Cancel As Short = CShort(eventArgs.Cancel)
        'Stop
        eventArgs.Cancel = CBool(Cancel)
    End Sub
    Public Sub Desumi()
        Dim r As New DataTable
        Dim t As New DataTable
        ' Dim notetxt As New DataTable
        Dim listNote As String
        Dim Nota As String = ""
        Dim Spec As String = ""
        Dim sql As String = ""
        Dim NF As String = ""
        Dim cmdt As OleDbDataAdapter
        Dim cmd As OleDbDataAdapter = New OleDbDataAdapter("SELECT * FROM ListaMat WHERE Ind=" & Str(m.Indmat), MatBase)
        cmd.Fill(r)
        Dim drv As DataRowView = r.DefaultView(0)
        Spec = CStr(drv("Spec"))
        Select Case Codice
            Case Codes.div2psi, Codes.div2MPa
                If Not IsDBNull(drv("Notes2")) Then listNote = CStr(drv("Notes2"))
                TabNota = "2"
                If CInt(drv("Classe")) = 8 Then TabNota = "4"
                If Len(Spec) > 0 Then sql = "SELECT * FROM [ANF_1] WHERE Spec='" & Trim(Spec) & "'"
            Case Codes.div1psi, Codes.div1MPa
                If Not IsDBNull(drv("notes")) Then listNote = CStr(drv("notes"))
                TabNota = "1"
                If CShort(drv("Classe")) = 8 Then TabNota = "3"
                If Len(Spec) > 0 Then sql = "SELECT * FROM [UNF_23] WHERE Spec='" & Trim(Spec) & "'"
            Case Else : Exit Sub
        End Select
        If CShort(drv("Classe")) <> 8 Then
            cmdt = New OleDbDataAdapter(sql, MatBase)
            cmdt.Fill(t)
            If t.Rows.Count > 0 Then NF = "B" Else NF = "A"
        End If
        TabNota = TabNota & NF
    End Sub
    Private Sub DBNote_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DBNote.CurrentCellChanged
        If RowColChangeForb Then Exit Sub
        Dim r As Integer = DBNote.CurrentCell.RowNumber
        Dim c As Integer = DBNote.CurrentCell.ColumnNumber
        Try
            If c = 3 Then
                If IsDBNull(DBNote.Item(r, c)) Then
                    MenuNote() '                If CInt(DBNote.Item(r, c)) = 0 Then MenuNote()
                ElseIf CStr(DBNote.Item(r, c)) = "" Then
                    MenuNote()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message + vbCrLf + ex.StackTrace)
        End Try
    End Sub
    Private Sub dvDBNote_ListChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ListChangedEventArgs) Handles dvDBNote.ListChanged
        Dim i As Integer
        Select Case e.ListChangedType
            Case System.ComponentModel.ListChangedType.ItemDeleted
                drv.BeginEdit()
                For i = e.NewIndex To dvD.Count - 2
                    drv(i) = drv(i + 1)
                Next
                drv.EndEdit()
                Riempi()
                AggNote()
            Case System.ComponentModel.ListChangedType.ItemChanged
                If CStr(drv(e.NewIndex)).Length = 0 Then MenuNote()
        End Select
    End Sub
    Private Sub frmNote_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        '        Riempi()
    End Sub
End Class