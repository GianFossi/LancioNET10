Option Strict On
Option Explicit On
Imports System.Data
Imports System.Data.OleDb
Friend Class frmDati
    Inherits System.Windows.Forms.Form
#Region "Codice generato dalla finestra di progettazione Windows Form "
    Public Sub New()
        MyBase.New()
        ' If m_vb6FormDefInstance Is Nothing Then
        ' If m_InitializingDefInstance Then
        ' m_vb6FormDefInstance = Me
        ' Else
        '     Try
        ' 'La prima istanza creata per il form di avvio rappresenta l'istanza predefinita.
        ' If System.Reflection.Assembly.GetExecutingAssembly.EntryPoint IsNot Nothing AndAlso System.Reflection.Assembly.GetExecutingAssembly.EntryPoint.DeclaringType Is Me.GetType Then
        ' m_vb6FormDefInstance = Me
        ' End If
        '     Catch
        ' End Try
        ' End If
        ' End If
        'Chiamata richiesta dalla progettazione Windows Form.
        InitializeComponent()
    End Sub
    Protected Overloads Overrides Sub Dispose(ByVal Disposing As Boolean)
        If Disposing Then
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
    Public WithEvents Command1 As System.Windows.Forms.Button
    Public WithEvents cmdRipr As System.Windows.Forms.Button
    Public WithEvents _Label1_3 As System.Windows.Forms.Label
    Public WithEvents _Label1_0 As System.Windows.Forms.Label
    Public WithEvents _Label1_1 As System.Windows.Forms.Label
    Public WithEvents _Label1_2 As System.Windows.Forms.Label
    'NOTA: la routine seguente è richiesta dalla progettazione Windows Form.
    'Può essere modificata utilizzando la finestra di progettazione Windows Form.
    'Non modificarla mediante l'editor di codice.
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
    Friend WithEvents DataGridTextBoxColumn10 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn11 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn12 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn13 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn14 As System.Windows.Forms.DataGridTextBoxColumn
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
    Friend WithEvents DataGridTextBoxColumn28 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn29 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn30 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn31 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn32 As System.Windows.Forms.DataGridTextBoxColumn
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Command1 = New System.Windows.Forms.Button
        Me.cmdRipr = New System.Windows.Forms.Button
        Me._Label1_3 = New System.Windows.Forms.Label
        Me._Label1_0 = New System.Windows.Forms.Label
        Me._Label1_1 = New System.Windows.Forms.Label
        Me._Label1_2 = New System.Windows.Forms.Label
        Me.DBValori = New System.Windows.Forms.DataGrid
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
        Me.DataGridTextBoxColumn10 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn11 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn12 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn13 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn14 = New System.Windows.Forms.DataGridTextBoxColumn
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
        Me.DataGridTextBoxColumn29 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn30 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn31 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn32 = New System.Windows.Forms.DataGridTextBoxColumn
        CType(Me.DBValori, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Command1
        '
        Me.Command1.BackColor = System.Drawing.SystemColors.Control
        Me.Command1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command1.Location = New System.Drawing.Point(480, 8)
        Me.Command1.Name = "Command1"
        Me.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command1.Size = New System.Drawing.Size(64, 28)
        Me.Command1.TabIndex = 4
        Me.Command1.Text = "Fatto"
        '
        'cmdRipr
        '
        Me.cmdRipr.BackColor = System.Drawing.SystemColors.Control
        Me.cmdRipr.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdRipr.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdRipr.Location = New System.Drawing.Point(558, 9)
        Me.cmdRipr.Name = "cmdRipr"
        Me.cmdRipr.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdRipr.Size = New System.Drawing.Size(64, 28)
        Me.cmdRipr.TabIndex = 2
        Me.cmdRipr.Text = "Ripristina"
        '
        '_Label1_3
        '
        Me._Label1_3.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_3.Font = New System.Drawing.Font("Arial", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Label1_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_3.Location = New System.Drawing.Point(18, 18)
        Me._Label1_3.Name = "_Label1_3"
        Me._Label1_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_3.Size = New System.Drawing.Size(225, 25)
        Me._Label1_3.TabIndex = 5
        Me._Label1_3.Text = "Unità di misura: BTU/hr.ft.°F"
        Me._Label1_3.Visible = False
        '
        '_Label1_0
        '
        Me._Label1_0.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_0.Font = New System.Drawing.Font("Arial", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Label1_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_0.Location = New System.Drawing.Point(16, 16)
        Me._Label1_0.Name = "_Label1_0"
        Me._Label1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_0.Size = New System.Drawing.Size(225, 25)
        Me._Label1_0.TabIndex = 0
        Me._Label1_0.Text = "Unità di misura: 10E5 psi"
        Me._Label1_0.Visible = False
        '
        '_Label1_1
        '
        Me._Label1_1.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_1.Font = New System.Drawing.Font("Arial", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Label1_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_1.Location = New System.Drawing.Point(16, 16)
        Me._Label1_1.Name = "_Label1_1"
        Me._Label1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_1.Size = New System.Drawing.Size(249, 25)
        Me._Label1_1.TabIndex = 3
        Me._Label1_1.Text = "Unità di misura: psi"
        Me._Label1_1.Visible = False
        '
        '_Label1_2
        '
        Me._Label1_2.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_2.Font = New System.Drawing.Font("Arial", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Label1_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_2.Location = New System.Drawing.Point(16, 16)
        Me._Label1_2.Name = "_Label1_2"
        Me._Label1_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_2.Size = New System.Drawing.Size(225, 25)
        Me._Label1_2.TabIndex = 1
        Me._Label1_2.Text = "Unità di misura: 10E-07 1/°F"
        Me._Label1_2.Visible = False
        '
        'DBValori
        '
        Me.DBValori.CaptionVisible = False
        Me.DBValori.DataMember = ""
        Me.DBValori.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DBValori.Location = New System.Drawing.Point(8, 48)
        Me.DBValori.Name = "DBValori"
        Me.DBValori.Size = New System.Drawing.Size(624, 248)
        Me.DBValori.TabIndex = 6
        Me.DBValori.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.AllowSorting = False
        Me.DataGridTableStyle1.DataGrid = Me.DBValori
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DataGridTextBoxColumn1, Me.DataGridTextBoxColumn2, Me.DataGridTextBoxColumn3, Me.DataGridTextBoxColumn4, Me.DataGridTextBoxColumn5, Me.DataGridTextBoxColumn6, Me.DataGridTextBoxColumn7, Me.DataGridTextBoxColumn8, Me.DataGridTextBoxColumn9, Me.DataGridTextBoxColumn10, Me.DataGridTextBoxColumn11, Me.DataGridTextBoxColumn12, Me.DataGridTextBoxColumn13, Me.DataGridTextBoxColumn14, Me.DataGridTextBoxColumn15, Me.DataGridTextBoxColumn16, Me.DataGridTextBoxColumn17, Me.DataGridTextBoxColumn18, Me.DataGridTextBoxColumn19, Me.DataGridTextBoxColumn20, Me.DataGridTextBoxColumn21, Me.DataGridTextBoxColumn22, Me.DataGridTextBoxColumn23, Me.DataGridTextBoxColumn24, Me.DataGridTextBoxColumn25, Me.DataGridTextBoxColumn26, Me.DataGridTextBoxColumn27, Me.DataGridTextBoxColumn28, Me.DataGridTextBoxColumn29, Me.DataGridTextBoxColumn30, Me.DataGridTextBoxColumn31, Me.DataGridTextBoxColumn32})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = ""
        '
        'DataGridTextBoxColumn1
        '
        Me.DataGridTextBoxColumn1.Format = ""
        Me.DataGridTextBoxColumn1.FormatInfo = Nothing
        Me.DataGridTextBoxColumn1.MappingName = ""
        Me.DataGridTextBoxColumn1.Width = 75
        '
        'DataGridTextBoxColumn2
        '
        Me.DataGridTextBoxColumn2.Format = ""
        Me.DataGridTextBoxColumn2.FormatInfo = Nothing
        Me.DataGridTextBoxColumn2.MappingName = ""
        Me.DataGridTextBoxColumn2.Width = 75
        '
        'DataGridTextBoxColumn3
        '
        Me.DataGridTextBoxColumn3.Format = ""
        Me.DataGridTextBoxColumn3.FormatInfo = Nothing
        Me.DataGridTextBoxColumn3.MappingName = ""
        Me.DataGridTextBoxColumn3.Width = 75
        '
        'DataGridTextBoxColumn4
        '
        Me.DataGridTextBoxColumn4.Format = ""
        Me.DataGridTextBoxColumn4.FormatInfo = Nothing
        Me.DataGridTextBoxColumn4.MappingName = ""
        Me.DataGridTextBoxColumn4.Width = 75
        '
        'DataGridTextBoxColumn5
        '
        Me.DataGridTextBoxColumn5.Format = ""
        Me.DataGridTextBoxColumn5.FormatInfo = Nothing
        Me.DataGridTextBoxColumn5.MappingName = ""
        Me.DataGridTextBoxColumn5.Width = 75
        '
        'DataGridTextBoxColumn6
        '
        Me.DataGridTextBoxColumn6.Format = ""
        Me.DataGridTextBoxColumn6.FormatInfo = Nothing
        Me.DataGridTextBoxColumn6.MappingName = ""
        Me.DataGridTextBoxColumn6.Width = 75
        '
        'DataGridTextBoxColumn7
        '
        Me.DataGridTextBoxColumn7.Format = ""
        Me.DataGridTextBoxColumn7.FormatInfo = Nothing
        Me.DataGridTextBoxColumn7.MappingName = ""
        Me.DataGridTextBoxColumn7.Width = 75
        '
        'DataGridTextBoxColumn8
        '
        Me.DataGridTextBoxColumn8.Format = ""
        Me.DataGridTextBoxColumn8.FormatInfo = Nothing
        Me.DataGridTextBoxColumn8.MappingName = ""
        Me.DataGridTextBoxColumn8.Width = 75
        '
        'DataGridTextBoxColumn9
        '
        Me.DataGridTextBoxColumn9.Format = ""
        Me.DataGridTextBoxColumn9.FormatInfo = Nothing
        Me.DataGridTextBoxColumn9.MappingName = ""
        Me.DataGridTextBoxColumn9.Width = 75
        '
        'DataGridTextBoxColumn10
        '
        Me.DataGridTextBoxColumn10.Format = ""
        Me.DataGridTextBoxColumn10.FormatInfo = Nothing
        Me.DataGridTextBoxColumn10.MappingName = ""
        Me.DataGridTextBoxColumn10.Width = 75
        '
        'DataGridTextBoxColumn11
        '
        Me.DataGridTextBoxColumn11.Format = ""
        Me.DataGridTextBoxColumn11.FormatInfo = Nothing
        Me.DataGridTextBoxColumn11.MappingName = ""
        Me.DataGridTextBoxColumn11.Width = 75
        '
        'DataGridTextBoxColumn12
        '
        Me.DataGridTextBoxColumn12.Format = ""
        Me.DataGridTextBoxColumn12.FormatInfo = Nothing
        Me.DataGridTextBoxColumn12.MappingName = ""
        Me.DataGridTextBoxColumn12.Width = 75
        '
        'DataGridTextBoxColumn13
        '
        Me.DataGridTextBoxColumn13.Format = ""
        Me.DataGridTextBoxColumn13.FormatInfo = Nothing
        Me.DataGridTextBoxColumn13.MappingName = ""
        Me.DataGridTextBoxColumn13.Width = 75
        '
        'DataGridTextBoxColumn14
        '
        Me.DataGridTextBoxColumn14.Format = ""
        Me.DataGridTextBoxColumn14.FormatInfo = Nothing
        Me.DataGridTextBoxColumn14.MappingName = ""
        Me.DataGridTextBoxColumn14.Width = 75
        '
        'DataGridTextBoxColumn15
        '
        Me.DataGridTextBoxColumn15.Format = ""
        Me.DataGridTextBoxColumn15.FormatInfo = Nothing
        Me.DataGridTextBoxColumn15.MappingName = ""
        Me.DataGridTextBoxColumn15.Width = 75
        '
        'DataGridTextBoxColumn16
        '
        Me.DataGridTextBoxColumn16.Format = ""
        Me.DataGridTextBoxColumn16.FormatInfo = Nothing
        Me.DataGridTextBoxColumn16.MappingName = ""
        Me.DataGridTextBoxColumn16.Width = 75
        '
        'DataGridTextBoxColumn17
        '
        Me.DataGridTextBoxColumn17.Format = ""
        Me.DataGridTextBoxColumn17.FormatInfo = Nothing
        Me.DataGridTextBoxColumn17.MappingName = ""
        Me.DataGridTextBoxColumn17.Width = 75
        '
        'DataGridTextBoxColumn18
        '
        Me.DataGridTextBoxColumn18.Format = ""
        Me.DataGridTextBoxColumn18.FormatInfo = Nothing
        Me.DataGridTextBoxColumn18.MappingName = ""
        Me.DataGridTextBoxColumn18.Width = 75
        '
        'DataGridTextBoxColumn19
        '
        Me.DataGridTextBoxColumn19.Format = ""
        Me.DataGridTextBoxColumn19.FormatInfo = Nothing
        Me.DataGridTextBoxColumn19.MappingName = ""
        Me.DataGridTextBoxColumn19.Width = 75
        '
        'DataGridTextBoxColumn20
        '
        Me.DataGridTextBoxColumn20.Format = ""
        Me.DataGridTextBoxColumn20.FormatInfo = Nothing
        Me.DataGridTextBoxColumn20.MappingName = ""
        Me.DataGridTextBoxColumn20.Width = 75
        '
        'DataGridTextBoxColumn21
        '
        Me.DataGridTextBoxColumn21.Format = ""
        Me.DataGridTextBoxColumn21.FormatInfo = Nothing
        Me.DataGridTextBoxColumn21.MappingName = ""
        Me.DataGridTextBoxColumn21.Width = 75
        '
        'DataGridTextBoxColumn22
        '
        Me.DataGridTextBoxColumn22.Format = ""
        Me.DataGridTextBoxColumn22.FormatInfo = Nothing
        Me.DataGridTextBoxColumn22.MappingName = ""
        Me.DataGridTextBoxColumn22.Width = 75
        '
        'DataGridTextBoxColumn23
        '
        Me.DataGridTextBoxColumn23.Format = ""
        Me.DataGridTextBoxColumn23.FormatInfo = Nothing
        Me.DataGridTextBoxColumn23.MappingName = ""
        Me.DataGridTextBoxColumn23.Width = 75
        '
        'DataGridTextBoxColumn24
        '
        Me.DataGridTextBoxColumn24.Format = ""
        Me.DataGridTextBoxColumn24.FormatInfo = Nothing
        Me.DataGridTextBoxColumn24.MappingName = ""
        Me.DataGridTextBoxColumn24.Width = 75
        '
        'DataGridTextBoxColumn25
        '
        Me.DataGridTextBoxColumn25.Format = ""
        Me.DataGridTextBoxColumn25.FormatInfo = Nothing
        Me.DataGridTextBoxColumn25.MappingName = ""
        Me.DataGridTextBoxColumn25.Width = 75
        '
        'DataGridTextBoxColumn26
        '
        Me.DataGridTextBoxColumn26.Format = ""
        Me.DataGridTextBoxColumn26.FormatInfo = Nothing
        Me.DataGridTextBoxColumn26.MappingName = ""
        Me.DataGridTextBoxColumn26.Width = 75
        '
        'DataGridTextBoxColumn27
        '
        Me.DataGridTextBoxColumn27.Format = ""
        Me.DataGridTextBoxColumn27.FormatInfo = Nothing
        Me.DataGridTextBoxColumn27.MappingName = ""
        Me.DataGridTextBoxColumn27.Width = 75
        '
        'DataGridTextBoxColumn28
        '
        Me.DataGridTextBoxColumn28.Format = ""
        Me.DataGridTextBoxColumn28.FormatInfo = Nothing
        Me.DataGridTextBoxColumn28.MappingName = ""
        Me.DataGridTextBoxColumn28.Width = 75
        '
        'DataGridTextBoxColumn29
        '
        Me.DataGridTextBoxColumn29.Format = ""
        Me.DataGridTextBoxColumn29.FormatInfo = Nothing
        Me.DataGridTextBoxColumn29.MappingName = ""
        Me.DataGridTextBoxColumn29.Width = 75
        '
        'DataGridTextBoxColumn30
        '
        Me.DataGridTextBoxColumn30.Format = ""
        Me.DataGridTextBoxColumn30.FormatInfo = Nothing
        Me.DataGridTextBoxColumn30.MappingName = ""
        Me.DataGridTextBoxColumn30.Width = 75
        '
        'DataGridTextBoxColumn31
        '
        Me.DataGridTextBoxColumn31.Format = ""
        Me.DataGridTextBoxColumn31.FormatInfo = Nothing
        Me.DataGridTextBoxColumn31.MappingName = ""
        Me.DataGridTextBoxColumn31.Width = 75
        '
        'DataGridTextBoxColumn32
        '
        Me.DataGridTextBoxColumn32.Format = ""
        Me.DataGridTextBoxColumn32.FormatInfo = Nothing
        Me.DataGridTextBoxColumn32.MappingName = ""
        Me.DataGridTextBoxColumn32.Width = 75
        '
        'frmDati
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(637, 304)
        Me.Controls.Add(Me.DBValori)
        Me.Controls.Add(Me.Command1)
        Me.Controls.Add(Me.cmdRipr)
        Me.Controls.Add(Me._Label1_3)
        Me.Controls.Add(Me._Label1_0)
        Me.Controls.Add(Me._Label1_1)
        Me.Controls.Add(Me._Label1_2)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.HelpButton = True
        Me.Location = New System.Drawing.Point(2, 22)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDati"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "Form1"
        CType(Me.DBValori, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
#End Region
#Region "Supporto aggiornamento "
    '   Private Shared m_vb6FormDefInstance As frmDati
    '   Private Shared m_InitializingDefInstance As Boolean
    '   Public Shared Property DefInstance() As frmDati
    '       Get
    '           If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
    '               m_InitializingDefInstance = True
    '               m_vb6FormDefInstance = New frmDati
    '               m_InitializingDefInstance = False
    '           End If
    '           DefInstance = m_vb6FormDefInstance
    '       End Get
    '       Set(ByVal Value As frmDati)
    '           m_vb6FormDefInstance = Value
    '       End Set
    '   End Property
#End Region
    Public IndiceTab As Short
    Public IndiceRig As Short
    Public consult As Boolean
    Public File, NomeTabella As String
    Private Ripristina As Short
    Private Temperature As DataTable
    Private Valori As DataTable
    Private dvValori As DataView
    Private cmdValori As OleDbDataAdapter
    Private CB As OleDbCommandBuilder
    Private cmdTemperature As OleDbDataAdapter
    Private m As MaterialeNew1
    Private Sub cmdRipr_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdRipr.Click
        IndiceRig = Ripristina
        Dim iFound As Integer
        Dim m As MaterialeNew1 = MatElem()
        If IndiceTab <> 1 Then
            If m.Agganciato Then
                iFound = dvValori.Find(IndiceRig)
            Else
                iFound = 1
            End If
        End If
        DBValori.CurrentCell = New DataGridCell(iFound, DBValori.CurrentCell.ColumnNumber)
    End Sub
    Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
        If m.Agganciato Then If IndiceTab <> 1 Then IndiceRig = CShort(Valori.Rows(CShort(DBValori.CurrentRowIndex))(0)) '.AbsolutePosition + 1
        If Not consult And m.Agganciato Then cmdValori.Update(Valori)
        If Not m.Agganciato Then
            Dim i As Integer
            With m.AlfaYoung
                Select Case IndiceTab
                    Case 0
                        .tblEmod.Rows(0).BeginEdit()
                        .tblEmod.Rows(1).BeginEdit()
                        For i = 0 To .tblEmod.Columns.Count - 1
                            .tblEmod.Rows(0)(i) = Valori.Rows(0)(i)
                            .tblEmod.Rows(1)(i) = Valori.Rows(1)(i)
                        Next
                        .tblEmod.Rows(0).EndEdit()
                        .tblEmod.Rows(1).EndEdit()
                    Case 2
                        .tblAlfa.Rows(0).BeginEdit()
                        .tblAlfa.Rows(1).BeginEdit()
                        For i = 0 To .tblAlfa.Columns.Count - 1
                            .tblAlfa.Rows(0)(i) = Valori.Rows(0)(i)
                            .tblAlfa.Rows(1)(i) = Valori.Rows(1)(i)
                        Next
                        .tblAlfa.Rows(0).EndEdit()
                        .tblAlfa.Rows(1).EndEdit()
                    Case 3
                        .tblCond.Rows(0).BeginEdit()
                        .tblCond.Rows(1).BeginEdit()
                        For i = 0 To .tblCond.Columns.Count - 1
                            .tblCond.Rows(0)(i) = Valori.Rows(0)(i)
                            .tblCond.Rows(1)(i) = Valori.Rows(1)(i)
                        Next
                        .tblCond.Rows(0).EndEdit()
                        .tblCond.Rows(1).EndEdit()
                End Select
            End With
        End If
        dvValori.Dispose()
        Valori.Dispose()
        If m.Agganciato Then
            cmdValori.Dispose()
            CB.Dispose()
        End If
        Temperature.Dispose()
        Valori = Nothing
        Hide()
    End Sub
    Private Sub frmDati_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
        Dim c As DataGridColumnStyle
        Dim rr As New DataTable
        Dim i As Integer
        Dim myDataRow, myDataRow1 As DataRow
        Dim myDataColumn As DataColumn
        m = MatElem()
        If Not Valori Is Nothing Then Exit Sub
        Valori = New DataTable
        Temperature = New DataTable
        Select Case IndiceTab
            Case 0
                If m.Agganciato Then
                    cmdValori = New OleDbDataAdapter("SELECT * FROM Modelas WHERE ID>1", MatBase)
                    cmdTemperature = New OleDbDataAdapter("SELECT * FROM Modelas WHERE ID=1", MatBase)
                Else
                    For i = 0 To m.AlfaYoung.tblEmod.Columns.Count - 1
                        myDataColumn = New DataColumn
                        myDataColumn.Caption = m.AlfaYoung.tblEmod.Columns(i).Caption
                        myDataColumn.DataType = m.AlfaYoung.tblEmod.Columns(i).DataType
                        Valori.Columns.Add(myDataColumn)
                    Next
                    myDataRow = Valori.NewRow
                    myDataRow1 = Valori.NewRow
                    For i = 0 To m.AlfaYoung.tblEmod.Columns.Count - 1
                        myDataRow(i) = m.AlfaYoung.tblEmod.Rows(0)(i)
                        myDataRow1(i) = m.AlfaYoung.tblEmod.Rows(1)(i)
                    Next
                    myDataRow(1) = "T [°F]"
                    Valori.Rows.Add(myDataRow)
                    Valori.Rows.Add(myDataRow1)
                End If
                Text = "Tabella dei moduli di elasticità"
            Case 1
                cmdValori = New OleDbDataAdapter("SELECT * FROM " & File & " WHERE ID>1", MatBase)
                cmdTemperature = New OleDbDataAdapter("SELECT * FROM " & File & " WHERE ID=1", MatBase)
                Text = "Pressure ratings per il Gruppo " & NomeTabella
                cmdRipr.Visible = False
            Case 2
                If m.Agganciato Then
                    cmdValori = New OleDbDataAdapter("SELECT * FROM Alfater WHERE ID>1", MatBase)
                    cmdTemperature = New OleDbDataAdapter("SELECT * FROM Alfater WHERE ID=1", MatBase)
                Else
                    For i = 0 To m.AlfaYoung.tblAlfa.Columns.Count - 1
                        myDataColumn = New DataColumn
                        myDataColumn.Caption = m.AlfaYoung.tblAlfa.Columns(i).Caption
                        myDataColumn.DataType = m.AlfaYoung.tblAlfa.Columns(i).DataType
                        Valori.Columns.Add(myDataColumn)
                    Next
                    myDataRow = Valori.NewRow
                    myDataRow1 = Valori.NewRow
                    For i = 0 To m.AlfaYoung.tblAlfa.Columns.Count - 1
                        myDataRow(i) = m.AlfaYoung.tblAlfa.Rows(0)(i)
                        myDataRow1(i) = m.AlfaYoung.tblAlfa.Rows(1)(i)
                    Next
                    myDataRow(1) = "T [°F]"
                    Valori.Rows.Add(myDataRow)
                    Valori.Rows.Add(myDataRow1)
                End If
                Text = "Tabella dei coefficienti di espansione termica"
            Case 3
                If m.Agganciato Then
                    cmdValori = New OleDbDataAdapter("SELECT * FROM ConducTer WHERE ID>1", MatBase)
                    cmdTemperature = New OleDbDataAdapter("SELECT * FROM ConducTer WHERE ID=1", MatBase)
                Else
                    For i = 0 To m.AlfaYoung.tblCond.Columns.Count - 1
                        myDataColumn = New DataColumn
                        myDataColumn.Caption = m.AlfaYoung.tblCond.Columns(i).Caption
                        myDataColumn.DataType = m.AlfaYoung.tblCond.Columns(i).DataType
                        Valori.Columns.Add(myDataColumn)
                    Next
                    myDataRow = Valori.NewRow
                    myDataRow1 = Valori.NewRow
                    For i = 0 To m.AlfaYoung.tblCond.Columns.Count - 1
                        myDataRow(i) = m.AlfaYoung.tblCond.Rows(0)(i)
                        myDataRow1(i) = m.AlfaYoung.tblCond.Rows(1)(i)
                    Next
                    myDataRow(1) = "T [°F]"
                    Valori.Rows.Add(myDataRow)
                    Valori.Rows.Add(myDataRow1)
                End If
                Text = "Tabella delle conducibilità termiche"
        End Select
        If m.Agganciato Then
            cmdValori.Fill(Valori)
            CB = New OleDbCommandBuilder(cmdValori)
            cmdTemperature.Fill(Temperature)
        Else
        End If
        Valori.TableName = "Valori"
        Label1(IndiceTab).Visible = True
        DBValori.SetDataBinding(Valori, "")
        dvValori = New DataView(Valori)
        If m.Agganciato Then
            dvValori.Sort = "ID"
        End If
        DBValori.TableStyles(0).MappingName = "Valori"
        DBValori.TableStyles(0).ColumnHeadersVisible = m.Agganciato
        For i = 0 To DBValori.TableStyles(0).GridColumnStyles.Count - 1
            c = DBValori.TableStyles(0).GridColumnStyles(i)
            c.Alignment = HorizontalAlignment.Right
            If i = 0 Or i > Valori.Columns.Count - 1 Then
                c.ResetHeaderText()
                c.Width = 0
            ElseIf i = 1 Then
                If IndiceTab = 1 Then
                    c.Width = CInt(Funzioni.TwipsToPixelsX(1200))
                Else
                    c.Width = CInt(Funzioni.TwipsToPixelsX(3000))
                End If
                c.HeaderText = "T [°F]"
                c.MappingName = Valori.Columns(i).Caption
            Else
                If IndiceTab = 1 Then
                    c.Width = CInt(Funzioni.TwipsToPixelsX(800))
                Else
                    c.Width = CInt(Funzioni.TwipsToPixelsX(500))
                End If
                If m.Agganciato Then
                    If IsDBNull(Temperature.Rows(0)(i)) Then
                        c.HeaderText = ""
                    Else
                        c.HeaderText = CStr(Temperature.Rows(0)(i))
                    End If
                    If IndiceTab = 1 Then c.HeaderText = c.HeaderText & " # "
                End If
                c.MappingName = Valori.Columns(i).Caption
            End If
        Next i
        Ripristina = IndiceRig
        If IndiceTab <> 1 Then
            If m.Agganciato Then
                For i = 0 To Valori.Rows.Count - 1
                    If CInt(Valori.Rows(i)(0)) = IndiceRig Then
                        DBValori.CurrentRowIndex = i
                        Exit For
                    End If
                Next
            Else
                DBValori.CurrentRowIndex = 1
            End If
        End If
        If consult Then
            cmdRipr.Enabled = False
            dvValori.AllowNew = False
            dvValori.AllowDelete = False
            dvValori.AllowEdit = False
        End If
        If IndiceTab = 1 Or Not m.Agganciato Then
            dvValori.AllowNew = False
            dvValori.AllowDelete = False
        End If
    End Sub
    Private Function Label1(ByVal Index As Short) As Label
        Select Case Index
            Case 0 : Return _Label1_0
            Case 1 : Return _Label1_1
            Case 2 : Return _Label1_2
            Case 3 : Return _Label1_3
            Case Else : Return Nothing
        End Select
    End Function
End Class