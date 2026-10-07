Option Strict On
Option Explicit On
Imports System.Data
Imports System.Data.OleDb
Friend Class frmChart
    Inherits System.Windows.Forms.Form
    Private IsInitializing As Boolean
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
        IsInitializing = True
        InitializeComponent()
        IsInitializing = False
    End Sub
    'Il form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
    Protected Overloads Overrides Sub Dispose(ByVal Disposing As Boolean)
        If Disposing Then
            DBTesta.Dispose()
            DBValori.Dispose()
            If Not components Is Nothing Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(Disposing)
    End Sub
    'Richiesto dalla progettazione Windows Form
    Private components As System.ComponentModel.IContainer
    Public ToolTip1 As System.Windows.Forms.ToolTip
    Public WithEvents Spiega As System.Windows.Forms.TextBox
    Public WithEvents Command1 As System.Windows.Forms.Button
    Public WithEvents _Label2_2 As System.Windows.Forms.Label
    Public WithEvents _Label2_1 As System.Windows.Forms.Label
    Public WithEvents _Label2_0 As System.Windows.Forms.Label
    Public WithEvents Label1 As System.Windows.Forms.Label
    'NOTA: la routine seguente è richiesta dalla progettazione Windows Form.
    'Può essere modificata utilizzando la finestra di progettazione Windows Form.
    'Non modificarla mediante l'editor di codice.
    Friend WithEvents DBTesta As System.Windows.Forms.DataGrid
    Friend WithEvents DBValori As System.Windows.Forms.DataGrid
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DataGridTextBoxColumn1 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn2 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn3 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn4 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn5 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn6 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn7 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn8 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn9 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTableStyle2 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DataGridTextBoxColumn10 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn11 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn12 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn13 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn15 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn16 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn17 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn18 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn19 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn20 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn21 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn22 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn23 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn24 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn25 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn26 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn27 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn14 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn29 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn30 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn28 As System.Windows.Forms.DataGridTextBoxColumn
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Spiega = New System.Windows.Forms.TextBox
        Me.Command1 = New System.Windows.Forms.Button
        Me._Label2_2 = New System.Windows.Forms.Label
        Me._Label2_1 = New System.Windows.Forms.Label
        Me._Label2_0 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.DBTesta = New System.Windows.Forms.DataGrid
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle
        Me.DataGridTextBoxColumn1 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn2 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn3 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn4 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn5 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn6 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn7 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn8 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn9 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn14 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn29 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DBValori = New System.Windows.Forms.DataGrid
        Me.DataGridTableStyle2 = New System.Windows.Forms.DataGridTableStyle
        Me.DataGridTextBoxColumn10 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn11 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn12 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn13 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn15 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn16 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn17 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn18 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn19 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn20 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn21 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn22 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn23 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn24 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn25 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn26 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn27 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn28 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn30 = New System.Windows.Forms.DataGridTextBoxColumn
        CType(Me.DBTesta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DBValori, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Spiega
        '
        Me.Spiega.AcceptsReturn = True
        Me.Spiega.BackColor = System.Drawing.SystemColors.Window
        Me.Spiega.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Spiega.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Spiega.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Spiega.Location = New System.Drawing.Point(144, 9)
        Me.Spiega.MaxLength = 0
        Me.Spiega.Name = "Spiega"
        Me.Spiega.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Spiega.Size = New System.Drawing.Size(457, 20)
        Me.Spiega.TabIndex = 2
        Me.Spiega.TabStop = False
        Me.Spiega.Text = "Text1"
        '
        'Command1
        '
        Me.Command1.BackColor = System.Drawing.SystemColors.Control
        Me.Command1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command1.Location = New System.Drawing.Point(24, 320)
        Me.Command1.Name = "Command1"
        Me.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command1.Size = New System.Drawing.Size(41, 25)
        Me.Command1.TabIndex = 0
        Me.Command1.TabStop = False
        Me.Command1.Text = "OK"
        Me.Command1.UseVisualStyleBackColor = False
        '
        '_Label2_2
        '
        Me._Label2_2.BackColor = System.Drawing.SystemColors.Control
        Me._Label2_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label2_2.Location = New System.Drawing.Point(16, 69)
        Me._Label2_2.Name = "_Label2_2"
        Me._Label2_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_2.Size = New System.Drawing.Size(65, 17)
        Me._Label2_2.TabIndex = 5
        Me._Label2_2.Text = "Yield [psi]"
        '
        '_Label2_1
        '
        Me._Label2_1.BackColor = System.Drawing.SystemColors.Control
        Me._Label2_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label2_1.Location = New System.Drawing.Point(16, 51)
        Me._Label2_1.Name = "_Label2_1"
        Me._Label2_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_1.Size = New System.Drawing.Size(65, 17)
        Me._Label2_1.TabIndex = 4
        Me._Label2_1.Text = "Young [psi]"
        '
        '_Label2_0
        '
        Me._Label2_0.BackColor = System.Drawing.SystemColors.Control
        Me._Label2_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label2_0.Location = New System.Drawing.Point(16, 32)
        Me._Label2_0.Name = "_Label2_0"
        Me._Label2_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_0.Size = New System.Drawing.Size(65, 17)
        Me._Label2_0.TabIndex = 3
        Me._Label2_0.Text = "Temp [°F]"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(88, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(41, 17)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Chart"
        '
        'DBTesta
        '
        Me.DBTesta.CaptionVisible = False
        Me.DBTesta.ColumnHeadersVisible = False
        Me.DBTesta.DataMember = ""
        Me.DBTesta.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DBTesta.Location = New System.Drawing.Point(88, 32)
        Me.DBTesta.Name = "DBTesta"
        Me.DBTesta.Size = New System.Drawing.Size(512, 80)
        Me.DBTesta.TabIndex = 6
        Me.DBTesta.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.DataGrid = Me.DBTesta
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DataGridTextBoxColumn1, Me.DataGridTextBoxColumn2, Me.DataGridTextBoxColumn3, Me.DataGridTextBoxColumn4, Me.DataGridTextBoxColumn5, Me.DataGridTextBoxColumn6, Me.DataGridTextBoxColumn7, Me.DataGridTextBoxColumn8, Me.DataGridTextBoxColumn9, Me.DataGridTextBoxColumn14, Me.DataGridTextBoxColumn29})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = "tabTesta"
        Me.DataGridTableStyle1.PreferredColumnWidth = 80
        Me.DataGridTableStyle1.RowHeadersVisible = False
        '
        'DataGridTextBoxColumn1
        '
        Me.DataGridTextBoxColumn1.Format = ""
        Me.DataGridTextBoxColumn1.FormatInfo = Nothing
        Me.DataGridTextBoxColumn1.Width = 80
        '
        'DataGridTextBoxColumn2
        '
        Me.DataGridTextBoxColumn2.Format = ""
        Me.DataGridTextBoxColumn2.FormatInfo = Nothing
        Me.DataGridTextBoxColumn2.Width = 80
        '
        'DataGridTextBoxColumn3
        '
        Me.DataGridTextBoxColumn3.Format = ""
        Me.DataGridTextBoxColumn3.FormatInfo = Nothing
        Me.DataGridTextBoxColumn3.Width = 80
        '
        'DataGridTextBoxColumn4
        '
        Me.DataGridTextBoxColumn4.Format = ""
        Me.DataGridTextBoxColumn4.FormatInfo = Nothing
        Me.DataGridTextBoxColumn4.Width = 80
        '
        'DataGridTextBoxColumn5
        '
        Me.DataGridTextBoxColumn5.Format = ""
        Me.DataGridTextBoxColumn5.FormatInfo = Nothing
        Me.DataGridTextBoxColumn5.Width = 80
        '
        'DataGridTextBoxColumn6
        '
        Me.DataGridTextBoxColumn6.Format = ""
        Me.DataGridTextBoxColumn6.FormatInfo = Nothing
        Me.DataGridTextBoxColumn6.Width = 80
        '
        'DataGridTextBoxColumn7
        '
        Me.DataGridTextBoxColumn7.Format = ""
        Me.DataGridTextBoxColumn7.FormatInfo = Nothing
        Me.DataGridTextBoxColumn7.Width = 80
        '
        'DataGridTextBoxColumn8
        '
        Me.DataGridTextBoxColumn8.Format = ""
        Me.DataGridTextBoxColumn8.FormatInfo = Nothing
        Me.DataGridTextBoxColumn8.Width = 80
        '
        'DataGridTextBoxColumn9
        '
        Me.DataGridTextBoxColumn9.Format = ""
        Me.DataGridTextBoxColumn9.FormatInfo = Nothing
        Me.DataGridTextBoxColumn9.Width = 80
        '
        'DataGridTextBoxColumn14
        '
        Me.DataGridTextBoxColumn14.Format = ""
        Me.DataGridTextBoxColumn14.FormatInfo = Nothing
        Me.DataGridTextBoxColumn14.Width = 80
        '
        'DataGridTextBoxColumn29
        '
        Me.DataGridTextBoxColumn29.Format = ""
        Me.DataGridTextBoxColumn29.FormatInfo = Nothing
        Me.DataGridTextBoxColumn29.Width = 80
        '
        'DBValori
        '
        Me.DBValori.CaptionVisible = False
        Me.DBValori.DataMember = ""
        Me.DBValori.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DBValori.Location = New System.Drawing.Point(88, 112)
        Me.DBValori.Name = "DBValori"
        Me.DBValori.Size = New System.Drawing.Size(512, 232)
        Me.DBValori.TabIndex = 7
        Me.DBValori.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle2})
        '
        'DataGridTableStyle2
        '
        Me.DataGridTableStyle2.DataGrid = Me.DBValori
        Me.DataGridTableStyle2.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DataGridTextBoxColumn30, Me.DataGridTextBoxColumn10, Me.DataGridTextBoxColumn11, Me.DataGridTextBoxColumn12, Me.DataGridTextBoxColumn13, Me.DataGridTextBoxColumn15, Me.DataGridTextBoxColumn16, Me.DataGridTextBoxColumn17, Me.DataGridTextBoxColumn18, Me.DataGridTextBoxColumn19, Me.DataGridTextBoxColumn20, Me.DataGridTextBoxColumn21, Me.DataGridTextBoxColumn22, Me.DataGridTextBoxColumn23, Me.DataGridTextBoxColumn24, Me.DataGridTextBoxColumn25, Me.DataGridTextBoxColumn26, Me.DataGridTextBoxColumn27, Me.DataGridTextBoxColumn28})
        Me.DataGridTableStyle2.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle2.MappingName = "tabValori"
        Me.DataGridTableStyle2.PreferredColumnWidth = 40
        Me.DataGridTableStyle2.RowHeadersVisible = False
        '
        'DataGridTextBoxColumn10
        '
        Me.DataGridTextBoxColumn10.Format = ""
        Me.DataGridTextBoxColumn10.FormatInfo = Nothing
        Me.DataGridTextBoxColumn10.MappingName = "A1"
        Me.DataGridTextBoxColumn10.Width = 40
        '
        'DataGridTextBoxColumn11
        '
        Me.DataGridTextBoxColumn11.Format = ""
        Me.DataGridTextBoxColumn11.FormatInfo = Nothing
        Me.DataGridTextBoxColumn11.MappingName = "B1"
        Me.DataGridTextBoxColumn11.Width = 40
        '
        'DataGridTextBoxColumn12
        '
        Me.DataGridTextBoxColumn12.Format = ""
        Me.DataGridTextBoxColumn12.FormatInfo = Nothing
        Me.DataGridTextBoxColumn12.MappingName = "A2"
        Me.DataGridTextBoxColumn12.Width = 40
        '
        'DataGridTextBoxColumn13
        '
        Me.DataGridTextBoxColumn13.Format = ""
        Me.DataGridTextBoxColumn13.FormatInfo = Nothing
        Me.DataGridTextBoxColumn13.MappingName = "B2"
        Me.DataGridTextBoxColumn13.Width = 40
        '
        'DataGridTextBoxColumn15
        '
        Me.DataGridTextBoxColumn15.Format = ""
        Me.DataGridTextBoxColumn15.FormatInfo = Nothing
        Me.DataGridTextBoxColumn15.MappingName = "A3"
        Me.DataGridTextBoxColumn15.Width = 40
        '
        'DataGridTextBoxColumn16
        '
        Me.DataGridTextBoxColumn16.Format = ""
        Me.DataGridTextBoxColumn16.FormatInfo = Nothing
        Me.DataGridTextBoxColumn16.MappingName = "B3"
        Me.DataGridTextBoxColumn16.Width = 40
        '
        'DataGridTextBoxColumn17
        '
        Me.DataGridTextBoxColumn17.Format = ""
        Me.DataGridTextBoxColumn17.FormatInfo = Nothing
        Me.DataGridTextBoxColumn17.MappingName = "A4"
        Me.DataGridTextBoxColumn17.Width = 40
        '
        'DataGridTextBoxColumn18
        '
        Me.DataGridTextBoxColumn18.Format = ""
        Me.DataGridTextBoxColumn18.FormatInfo = Nothing
        Me.DataGridTextBoxColumn18.MappingName = "B4"
        Me.DataGridTextBoxColumn18.Width = 40
        '
        'DataGridTextBoxColumn19
        '
        Me.DataGridTextBoxColumn19.Format = ""
        Me.DataGridTextBoxColumn19.FormatInfo = Nothing
        Me.DataGridTextBoxColumn19.MappingName = "A5"
        Me.DataGridTextBoxColumn19.Width = 40
        '
        'DataGridTextBoxColumn20
        '
        Me.DataGridTextBoxColumn20.Format = ""
        Me.DataGridTextBoxColumn20.FormatInfo = Nothing
        Me.DataGridTextBoxColumn20.MappingName = "B5"
        Me.DataGridTextBoxColumn20.Width = 40
        '
        'DataGridTextBoxColumn21
        '
        Me.DataGridTextBoxColumn21.Format = ""
        Me.DataGridTextBoxColumn21.FormatInfo = Nothing
        Me.DataGridTextBoxColumn21.MappingName = "A6"
        Me.DataGridTextBoxColumn21.Width = 40
        '
        'DataGridTextBoxColumn22
        '
        Me.DataGridTextBoxColumn22.Format = ""
        Me.DataGridTextBoxColumn22.FormatInfo = Nothing
        Me.DataGridTextBoxColumn22.MappingName = "B6"
        Me.DataGridTextBoxColumn22.Width = 40
        '
        'DataGridTextBoxColumn23
        '
        Me.DataGridTextBoxColumn23.Format = ""
        Me.DataGridTextBoxColumn23.FormatInfo = Nothing
        Me.DataGridTextBoxColumn23.MappingName = "A7"
        Me.DataGridTextBoxColumn23.Width = 40
        '
        'DataGridTextBoxColumn24
        '
        Me.DataGridTextBoxColumn24.Format = ""
        Me.DataGridTextBoxColumn24.FormatInfo = Nothing
        Me.DataGridTextBoxColumn24.MappingName = "B7"
        Me.DataGridTextBoxColumn24.Width = 40
        '
        'DataGridTextBoxColumn25
        '
        Me.DataGridTextBoxColumn25.Format = ""
        Me.DataGridTextBoxColumn25.FormatInfo = Nothing
        Me.DataGridTextBoxColumn25.MappingName = "A8"
        Me.DataGridTextBoxColumn25.Width = 40
        '
        'DataGridTextBoxColumn26
        '
        Me.DataGridTextBoxColumn26.Format = ""
        Me.DataGridTextBoxColumn26.FormatInfo = Nothing
        Me.DataGridTextBoxColumn26.MappingName = "B8"
        Me.DataGridTextBoxColumn26.Width = 40
        '
        'DataGridTextBoxColumn27
        '
        Me.DataGridTextBoxColumn27.Format = ""
        Me.DataGridTextBoxColumn27.FormatInfo = Nothing
        Me.DataGridTextBoxColumn27.MappingName = "A9"
        Me.DataGridTextBoxColumn27.Width = 40
        '
        'DataGridTextBoxColumn28
        '
        Me.DataGridTextBoxColumn28.Format = ""
        Me.DataGridTextBoxColumn28.FormatInfo = Nothing
        Me.DataGridTextBoxColumn28.MappingName = "B9"
        Me.DataGridTextBoxColumn28.Width = 40
        '
        'DataGridTextBoxColumn30
        '
        Me.DataGridTextBoxColumn30.Format = ""
        Me.DataGridTextBoxColumn30.FormatInfo = Nothing
        Me.DataGridTextBoxColumn30.Width = 40
        '
        'frmChart
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(630, 349)
        Me.ControlBox = False
        Me.Controls.Add(Me.DBValori)
        Me.Controls.Add(Me.DBTesta)
        Me.Controls.Add(Me.Spiega)
        Me.Controls.Add(Me.Command1)
        Me.Controls.Add(Me._Label2_2)
        Me.Controls.Add(Me._Label2_1)
        Me.Controls.Add(Me._Label2_0)
        Me.Controls.Add(Me.Label1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Location = New System.Drawing.Point(2, 22)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmChart"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "Libreria Materiali - Charts per il buckling"
        CType(Me.DBTesta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DBValori, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region
#Region "Supporto aggiornamento "
    Private Shared m_vb6FormDefInstance As frmChart
    Private Shared m_InitializingDefInstance As Boolean
    Public Shared Property DefInstance() As frmChart
        Get
            If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
                m_InitializingDefInstance = True
                m_vb6FormDefInstance = New frmChart
                m_InitializingDefInstance = False
            End If
            DefInstance = m_vb6FormDefInstance
        End Get
        Set(ByVal Value As frmChart)
            m_vb6FormDefInstance = Value
        End Set
    End Property
#End Region
    Private k, nchart As Short
    Private ColonnaSinistra As Integer
    Private dtTesta As New DataTable
    Private dtValori As New DataTable
    Private cmdT, cmdV As OleDbDataAdapter
    Private CBT, CBV As OleDbCommandBuilder
    Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
        cmdT.Update(Me.dtTesta)
        cmdV.Update(Me.dtValori)
        Dim Direct As New DataTable
        Dim cmd As OleDbDataAdapter = New OleDbDataAdapter("SELECT * FROM DirectCH", MatBase)
        cmd.Fill(Direct)
        Dim CB As OleDbCommandBuilder = New OleDbCommandBuilder(cmd)
        Dim dvDirect As DataView = New DataView(Direct)
        dvDirect.Sort = "ID"
        Dim iFound As Integer = dvDirect.Find(nchart)
        Dim drv As DataRowView = dvDirect(iFound)
        drv.BeginEdit()
        drv("Descrizione") = Spiega.Text
        drv.EndEdit()
        cmd.Update(Direct)
        Direct.Dispose()
        Hide()
    End Sub
    Private Sub frmChart_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
        Inizializza()
    End Sub
    Private Sub Inizializza()
        Dim dsTemp As New DataSet
        Dim Direct As DataTable
        Dim Testa As New DataTable
        Dim Valori As New DataTable
        Dim vTesta As DataTable
        Dim vValori As DataTable
        Dim c As DataGridColumnStyle
        Dim tabTesta As String
        Dim tabValori As String
        Dim m As LibMat.MaterialeNew1
        Dim i, j As Integer
        m = MatElem()
        If m Is Nothing Then Exit Sub
        k = CShort(Scheda.TabControl1.SelectedIndex + 1)
        nchart = m.Caract.Item(k).TextData.IndChart
        If nchart = 0 Then Me.Close()
        Dim cmdD As OleDbDataAdapter = New OleDbDataAdapter("SELECT * FROM DirectCH", MatBase)
        Dim CBcmsD As OleDbCommandBuilder = New OleDbCommandBuilder(cmdD)
        cmdD.Fill(dsTemp)
        dsTemp.Tables(0).TableName = "DirectCH"
        Direct = dsTemp.Tables("DirectCH")
        Dim dvD As DataView = New DataView(Direct)
        dvD.Sort = "ID"
        Dim iFound As Integer = dvD.Find(nchart)
        If CStr(dvD(iFound)("Descrizione")) = "Assente" Then
            Dim cmdds As OleDbDataAdapter = New OleDbDataAdapter("SELECT * FROM tCS_1", MatBase)
            cmdds.Fill(dsTemp, "tCS_1")
            vTesta = dsTemp.Tables("tCS_1")
            tabTesta = "t" + CStr(dvD(iFound)("Codice")).Replace(CChar("-"), CChar("_"))
            RoutBase3.clsAccessoDati.DuplicaTableDef(vTesta, tabTesta, Conn & MyFile & ConnFine)
            Dim cmdT As OleDbDataAdapter = New OleDbDataAdapter("SELECT * FROM " & tabTesta, MatBase)
            Testa = New DataTable
            cmdT.Fill(Testa)
            Dim CB As OleDbCommandBuilder = New OleDbCommandBuilder(cmdT)
            Dim dvTesta As DataView = New DataView(Testa)
            Dim drv As DataRowView
            For i = 0 To vTesta.Rows.Count - 1
                drv = dvTesta.AddNew()
                drv(1) = vTesta.Rows(i)(1)
                For j = 2 To vTesta.Columns.Count - 1
                    drv(j) = 0
                Next
                drv.EndEdit()
            Next
            cmdT.Update(Testa)
            dvTesta.Dispose()
            vTesta.Dispose()
            Testa.Dispose()
            CB.Dispose()
            cmdT.Dispose()
            tabValori = "v" + CStr(dvD(iFound)("Codice")).Replace(CChar("-"), CChar("_"))
            cmdds = New OleDbDataAdapter("SELECT * FROM vCS_1", MatBase)
            cmdds.Fill(dsTemp, "vCS_1")
            vValori = dsTemp.Tables("vCS_1")
            RoutBase3.clsAccessoDati.DuplicaTableDef(vValori, tabValori, Conn & MyFile & ConnFine)
            Dim cmdV As OleDbDataAdapter = New OleDbDataAdapter("SELECT * FROM " & tabValori, MatBase)
            cmdV.Fill(Valori)
            drv = dvD(iFound)
            drv.BeginEdit()
            drv("Descrizione") = "FIG." + CStr(dvD(iFound)("Codice"))
            drv("tabTesta") = tabTesta
            drv("tabDati") = tabValori
            drv.EndEdit()
            cmdD.Update(Direct)
        Else
            tabTesta = CStr(dvD(iFound)("tabTesta"))
            tabValori = CStr(dvD(iFound)("tabDati"))
        End If
        Spiega.Text = CStr(dvD(iFound)("Descrizione"))
        Direct.Dispose()
        cmdT = New OleDbDataAdapter("SELECT * FROM [" & tabTesta & "];", MatBase)
        cmdT.Fill(dtTesta)
        CBT = New OleDbCommandBuilder(cmdT)
        dtTesta.TableName = "tabTesta"
        cmdV = New OleDbDataAdapter("SELECT * FROM [" & tabValori & "];", MatBase)
        cmdV.Fill(dtValori)
        CBV = New OleDbCommandBuilder(cmdV)
        dtValori.TableName = "tabValori"
        DBTesta.SetDataBinding(dtTesta, "")
        DBValori.SetDataBinding(dtValori, "")
        For i = 0 To DBTesta.TableStyles(0).GridColumnStyles.Count - 1
            c = DBTesta.TableStyles(0).GridColumnStyles(i)
            c.Alignment = HorizontalAlignment.Center
            If i <= 1 Or i > dtTesta.Columns.Count - 1 Then
                'c.ResetHeaderText()
                c.Width = 0
            Else
                c.Width = CInt(Funzioni.TwipsToPixelsX(1800))
                c.MappingName = dtTesta.Columns(i).Caption
            End If
            'c.AllowSizing = False
            'c.DividerStyle = MSDataGridLib.DividerStyleConstants.dbgBlackLine
        Next
        For i = 0 To DBValori.TableStyles(0).GridColumnStyles.Count - 1
            c = DBValori.TableStyles(0).GridColumnStyles(i)
            'c.AllowSizing = False
            If i = 0 Or i > dtValori.Columns.Count - 1 Then
                ' c.ResetHeaderText()
                c.Width = 0
            Else
                c.Width = CInt(Funzioni.TwipsToPixelsX(900))
                c.MappingName = dtValori.Columns(i).Caption
                If i Mod 2 = 0 Then
                    'c.DividerStyle = MSDataGridLib.DividerStyleConstants.dbgBlackLine
                    c.HeaderText = "B [psi]"
                Else
                    c.HeaderText = "A [--]"
                End If
            End If
        Next i
    End Sub
    Private Sub DBValori_Scroll(ByVal sender As Object, ByVal e As System.EventArgs) Handles DBValori.Scroll
        If IsInitializing Then Exit Sub
        IsInitializing = True
        If (DBValori.FirstVisibleColumn - 1) Mod 2 = 1 Then
            If DBValori.FirstVisibleColumn > ColonnaSinistra Then
                DBValori.CurrentCell = New DataGridCell(DBValori.CurrentCell.RowNumber, DBValori.FirstVisibleColumn + DBValori.VisibleColumnCount - 3)
            Else
                DBValori.CurrentCell = New DataGridCell(DBValori.CurrentCell.RowNumber, DBValori.FirstVisibleColumn - 2)
            End If
        End If
        ColonnaSinistra = DBValori.FirstVisibleColumn - 1
        Dim ColonnaSinistraT As Integer = (ColonnaSinistra - 1) \ 2 + 2
        If DBTesta.FirstVisibleColumn - 2 > ColonnaSinistraT Then
            DBTesta.CurrentCell = New DataGridCell(0, ColonnaSinistraT)
        ElseIf DBTesta.FirstVisibleColumn < ColonnaSinistraT Then
            DBTesta.CurrentCell = New DataGridCell(0, ColonnaSinistraT + DBTesta.VisibleColumnCount - 2)
        End If
        IsInitializing = False
    End Sub

    Private Sub DBTesta_Scroll(ByVal sender As Object, ByVal e As System.EventArgs) Handles DBTesta.Scroll
        If IsInitializing Then Exit Sub
        IsInitializing = True
        Dim ColonnaSinistraT As Integer = DBTesta.FirstVisibleColumn - 2
        Dim ColonnaSinistraV As Integer = ColonnaSinistraT * 2
        ColonnaSinistra = DBValori.FirstVisibleColumn - 1
        If ColonnaSinistra > ColonnaSinistraV Then
            DBValori.CurrentCell = New DataGridCell(0, ColonnaSinistraV)
        ElseIf ColonnaSinistra < ColonnaSinistraV Then
            DBValori.CurrentCell = New DataGridCell(0, ColonnaSinistraV + DBValori.VisibleColumnCount - 1)
        End If
        IsInitializing = False
    End Sub

    Private Sub DBTesta_Navigate(ByVal sender As System.Object, ByVal ne As System.Windows.Forms.NavigateEventArgs) Handles DBTesta.Navigate

    End Sub
End Class