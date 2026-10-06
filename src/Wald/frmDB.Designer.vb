<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmDB
#Region "Codice generato da Progettazione Windows Form "
	<System.Diagnostics.DebuggerNonUserCode()> Public Sub New()
		MyBase.New()
        'Chiamata richiesta dalla progettazione Windows Form.
        Inizializzando = True
        InitializeComponent()
        Inizializzando = False
        Inizializza()
    End Sub
	'Il form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
	<System.Diagnostics.DebuggerNonUserCode()> Protected Overloads Overrides Sub Dispose(ByVal Disposing As Boolean)
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
    Public WithEvents cmdRiordina As System.Windows.Forms.Button
	Public WithEvents PictHelp As System.Windows.Forms.PictureBox
    Public WithEvents Combo1 As System.Windows.Forms.ComboBox
    Public WithEvents Command2 As System.Windows.Forms.Button
	Public WithEvents Command1 As System.Windows.Forms.Button
    Public WithEvents Label1 As System.Windows.Forms.Label
	'NOTA: la routine seguente è richiesta dalla progettazione Windows Form.
	'Può essere modificata utilizzando la finestra di progettazione Windows Form.
	'Non modificarla mediante l'editor di codice.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmdRiordina = New System.Windows.Forms.Button
        Me.PictHelp = New System.Windows.Forms.PictureBox
        Me.Combo1 = New System.Windows.Forms.ComboBox
        Me.Command2 = New System.Windows.Forms.Button
        Me.Command1 = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.cDummy = New System.Windows.Forms.Label
        Me.Picture1 = New System.Windows.Forms.PictureBox
        Me.DBGrid1 = New System.Windows.Forms.DataGridView
        Me.IDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TipoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.YDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.XDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.HtotDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.HliqDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.HvapDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MtotDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MliqDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MvapDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DenslDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DensvDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CspeclDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CspecvDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VislDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VisvDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.KliqDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.KvapDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CfaclDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CfacvDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.HAcqLiqDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MolAcqLiqDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MasAcqLiqDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CondCurvaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dsCondCurva = New Wald.CondCurvaDataSet
        Me.CondCurvaTableAdapter = New Wald.CondCurvaDataSetTableAdapters.CondCurvaTableAdapter
        CType(Me.PictHelp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Picture1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DBGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CondCurvaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsCondCurva, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdRiordina
        '
        Me.cmdRiordina.BackColor = System.Drawing.SystemColors.Control
        Me.cmdRiordina.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdRiordina.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdRiordina.Location = New System.Drawing.Point(612, 9)
        Me.cmdRiordina.Name = "cmdRiordina"
        Me.cmdRiordina.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdRiordina.Size = New System.Drawing.Size(28, 28)
        Me.cmdRiordina.TabIndex = 7
        Me.cmdRiordina.Text = "R"
        Me.ToolTip1.SetToolTip(Me.cmdRiordina, "Riordina in senso decrescente le righe della tabella")
        Me.cmdRiordina.UseVisualStyleBackColor = False
        '
        'PictHelp
        '
        Me.PictHelp.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.PictHelp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictHelp.Cursor = System.Windows.Forms.Cursors.Default
        Me.PictHelp.ForeColor = System.Drawing.SystemColors.WindowText
        Me.PictHelp.Location = New System.Drawing.Point(27, 18)
        Me.PictHelp.Name = "PictHelp"
        Me.PictHelp.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.PictHelp.Size = New System.Drawing.Size(73, 33)
        Me.PictHelp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictHelp.TabIndex = 5
        Me.PictHelp.TabStop = False
        Me.PictHelp.Visible = False
        '
        'Combo1
        '
        Me.Combo1.BackColor = System.Drawing.SystemColors.Window
        Me.Combo1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Combo1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Combo1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Combo1.Location = New System.Drawing.Point(126, 567)
        Me.Combo1.Name = "Combo1"
        Me.Combo1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Combo1.Size = New System.Drawing.Size(172, 21)
        Me.Combo1.TabIndex = 4
        '
        'Command2
        '
        Me.Command2.BackColor = System.Drawing.SystemColors.Control
        Me.Command2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command2.Location = New System.Drawing.Point(450, 567)
        Me.Command2.Name = "Command2"
        Me.Command2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command2.Size = New System.Drawing.Size(73, 25)
        Me.Command2.TabIndex = 1
        Me.Command2.Text = "Cancella"
        Me.Command2.UseVisualStyleBackColor = False
        '
        'Command1
        '
        Me.Command1.BackColor = System.Drawing.SystemColors.Control
        Me.Command1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command1.Location = New System.Drawing.Point(531, 568)
        Me.Command1.Name = "Command1"
        Me.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command1.Size = New System.Drawing.Size(73, 24)
        Me.Command1.TabIndex = 0
        Me.Command1.Text = "Finito"
        Me.Command1.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(9, 567)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(100, 19)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Grandezza graficata"
        '
        'cDummy
        '
        Me.cDummy.BackColor = System.Drawing.SystemColors.Control
        Me.cDummy.Cursor = System.Windows.Forms.Cursors.Default
        Me.cDummy.Font = New System.Drawing.Font("Courier New", 7.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cDummy.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cDummy.Location = New System.Drawing.Point(456, 288)
        Me.cDummy.Name = "cDummy"
        Me.cDummy.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cDummy.Size = New System.Drawing.Size(41, 25)
        Me.cDummy.TabIndex = 6
        Me.cDummy.Text = "Label4"
        Me.cDummy.Visible = False
        '
        'Picture1
        '
        Me.Picture1.Location = New System.Drawing.Point(8, 208)
        Me.Picture1.Name = "Picture1"
        Me.Picture1.Size = New System.Drawing.Size(592, 352)
        Me.Picture1.TabIndex = 9
        Me.Picture1.TabStop = False
        '
        'DBGrid1
        '
        Me.DBGrid1.AutoGenerateColumns = False
        Me.DBGrid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DBGrid1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IDDataGridViewTextBoxColumn, Me.TipoDataGridViewTextBoxColumn, Me.TDataGridViewTextBoxColumn, Me.PDataGridViewTextBoxColumn, Me.YDataGridViewTextBoxColumn, Me.XDataGridViewTextBoxColumn, Me.HtotDataGridViewTextBoxColumn, Me.HliqDataGridViewTextBoxColumn, Me.HvapDataGridViewTextBoxColumn, Me.MtotDataGridViewTextBoxColumn, Me.MliqDataGridViewTextBoxColumn, Me.MvapDataGridViewTextBoxColumn, Me.DenslDataGridViewTextBoxColumn, Me.DensvDataGridViewTextBoxColumn, Me.CspeclDataGridViewTextBoxColumn, Me.CspecvDataGridViewTextBoxColumn, Me.VislDataGridViewTextBoxColumn, Me.VisvDataGridViewTextBoxColumn, Me.KliqDataGridViewTextBoxColumn, Me.KvapDataGridViewTextBoxColumn, Me.CfaclDataGridViewTextBoxColumn, Me.CfacvDataGridViewTextBoxColumn, Me.HAcqLiqDataGridViewTextBoxColumn, Me.MolAcqLiqDataGridViewTextBoxColumn, Me.MasAcqLiqDataGridViewTextBoxColumn})
        Me.DBGrid1.DataSource = Me.CondCurvaBindingSource
        Me.DBGrid1.Location = New System.Drawing.Point(8, 0)
        Me.DBGrid1.Name = "DBGrid1"
        Me.DBGrid1.Size = New System.Drawing.Size(592, 200)
        Me.DBGrid1.TabIndex = 10
        '
        'IDDataGridViewTextBoxColumn
        '
        Me.IDDataGridViewTextBoxColumn.DataPropertyName = "ID"
        Me.IDDataGridViewTextBoxColumn.HeaderText = "ID"
        Me.IDDataGridViewTextBoxColumn.Name = "IDDataGridViewTextBoxColumn"
        Me.IDDataGridViewTextBoxColumn.Visible = False
        '
        'TipoDataGridViewTextBoxColumn
        '
        Me.TipoDataGridViewTextBoxColumn.DataPropertyName = "Tipo"
        Me.TipoDataGridViewTextBoxColumn.HeaderText = "Tipo"
        Me.TipoDataGridViewTextBoxColumn.Name = "TipoDataGridViewTextBoxColumn"
        Me.TipoDataGridViewTextBoxColumn.Width = 25
        '
        'TDataGridViewTextBoxColumn
        '
        Me.TDataGridViewTextBoxColumn.DataPropertyName = "T"
        Me.TDataGridViewTextBoxColumn.HeaderText = "T"
        Me.TDataGridViewTextBoxColumn.Name = "TDataGridViewTextBoxColumn"
        Me.TDataGridViewTextBoxColumn.Width = 35
        '
        'PDataGridViewTextBoxColumn
        '
        Me.PDataGridViewTextBoxColumn.DataPropertyName = "P"
        Me.PDataGridViewTextBoxColumn.HeaderText = "P"
        Me.PDataGridViewTextBoxColumn.Name = "PDataGridViewTextBoxColumn"
        '
        'YDataGridViewTextBoxColumn
        '
        Me.YDataGridViewTextBoxColumn.DataPropertyName = "y"
        Me.YDataGridViewTextBoxColumn.HeaderText = "y"
        Me.YDataGridViewTextBoxColumn.Name = "YDataGridViewTextBoxColumn"
        '
        'XDataGridViewTextBoxColumn
        '
        Me.XDataGridViewTextBoxColumn.DataPropertyName = "x"
        Me.XDataGridViewTextBoxColumn.HeaderText = "x"
        Me.XDataGridViewTextBoxColumn.Name = "XDataGridViewTextBoxColumn"
        '
        'HtotDataGridViewTextBoxColumn
        '
        Me.HtotDataGridViewTextBoxColumn.DataPropertyName = "Htot"
        Me.HtotDataGridViewTextBoxColumn.HeaderText = "Htot"
        Me.HtotDataGridViewTextBoxColumn.Name = "HtotDataGridViewTextBoxColumn"
        '
        'HliqDataGridViewTextBoxColumn
        '
        Me.HliqDataGridViewTextBoxColumn.DataPropertyName = "Hliq"
        Me.HliqDataGridViewTextBoxColumn.HeaderText = "Hliq"
        Me.HliqDataGridViewTextBoxColumn.Name = "HliqDataGridViewTextBoxColumn"
        '
        'HvapDataGridViewTextBoxColumn
        '
        Me.HvapDataGridViewTextBoxColumn.DataPropertyName = "Hvap"
        Me.HvapDataGridViewTextBoxColumn.HeaderText = "Hvap"
        Me.HvapDataGridViewTextBoxColumn.Name = "HvapDataGridViewTextBoxColumn"
        '
        'MtotDataGridViewTextBoxColumn
        '
        Me.MtotDataGridViewTextBoxColumn.DataPropertyName = "Mtot"
        Me.MtotDataGridViewTextBoxColumn.HeaderText = "Mtot"
        Me.MtotDataGridViewTextBoxColumn.Name = "MtotDataGridViewTextBoxColumn"
        '
        'MliqDataGridViewTextBoxColumn
        '
        Me.MliqDataGridViewTextBoxColumn.DataPropertyName = "Mliq"
        Me.MliqDataGridViewTextBoxColumn.HeaderText = "Mliq"
        Me.MliqDataGridViewTextBoxColumn.Name = "MliqDataGridViewTextBoxColumn"
        '
        'MvapDataGridViewTextBoxColumn
        '
        Me.MvapDataGridViewTextBoxColumn.DataPropertyName = "Mvap"
        Me.MvapDataGridViewTextBoxColumn.HeaderText = "Mvap"
        Me.MvapDataGridViewTextBoxColumn.Name = "MvapDataGridViewTextBoxColumn"
        '
        'DenslDataGridViewTextBoxColumn
        '
        Me.DenslDataGridViewTextBoxColumn.DataPropertyName = "Densl"
        Me.DenslDataGridViewTextBoxColumn.HeaderText = "Densl"
        Me.DenslDataGridViewTextBoxColumn.Name = "DenslDataGridViewTextBoxColumn"
        '
        'DensvDataGridViewTextBoxColumn
        '
        Me.DensvDataGridViewTextBoxColumn.DataPropertyName = "Densv"
        Me.DensvDataGridViewTextBoxColumn.HeaderText = "Densv"
        Me.DensvDataGridViewTextBoxColumn.Name = "DensvDataGridViewTextBoxColumn"
        '
        'CspeclDataGridViewTextBoxColumn
        '
        Me.CspeclDataGridViewTextBoxColumn.DataPropertyName = "Cspecl"
        Me.CspeclDataGridViewTextBoxColumn.HeaderText = "Cspecl"
        Me.CspeclDataGridViewTextBoxColumn.Name = "CspeclDataGridViewTextBoxColumn"
        '
        'CspecvDataGridViewTextBoxColumn
        '
        Me.CspecvDataGridViewTextBoxColumn.DataPropertyName = "Cspecv"
        Me.CspecvDataGridViewTextBoxColumn.HeaderText = "Cspecv"
        Me.CspecvDataGridViewTextBoxColumn.Name = "CspecvDataGridViewTextBoxColumn"
        '
        'VislDataGridViewTextBoxColumn
        '
        Me.VislDataGridViewTextBoxColumn.DataPropertyName = "Visl"
        Me.VislDataGridViewTextBoxColumn.HeaderText = "Visl"
        Me.VislDataGridViewTextBoxColumn.Name = "VislDataGridViewTextBoxColumn"
        '
        'VisvDataGridViewTextBoxColumn
        '
        Me.VisvDataGridViewTextBoxColumn.DataPropertyName = "Visv"
        Me.VisvDataGridViewTextBoxColumn.HeaderText = "Visv"
        Me.VisvDataGridViewTextBoxColumn.Name = "VisvDataGridViewTextBoxColumn"
        '
        'KliqDataGridViewTextBoxColumn
        '
        Me.KliqDataGridViewTextBoxColumn.DataPropertyName = "kliq"
        Me.KliqDataGridViewTextBoxColumn.HeaderText = "kliq"
        Me.KliqDataGridViewTextBoxColumn.Name = "KliqDataGridViewTextBoxColumn"
        '
        'KvapDataGridViewTextBoxColumn
        '
        Me.KvapDataGridViewTextBoxColumn.DataPropertyName = "kvap"
        Me.KvapDataGridViewTextBoxColumn.HeaderText = "kvap"
        Me.KvapDataGridViewTextBoxColumn.Name = "KvapDataGridViewTextBoxColumn"
        '
        'CfaclDataGridViewTextBoxColumn
        '
        Me.CfaclDataGridViewTextBoxColumn.DataPropertyName = "Cfacl"
        Me.CfaclDataGridViewTextBoxColumn.HeaderText = "Cfacl"
        Me.CfaclDataGridViewTextBoxColumn.Name = "CfaclDataGridViewTextBoxColumn"
        '
        'CfacvDataGridViewTextBoxColumn
        '
        Me.CfacvDataGridViewTextBoxColumn.DataPropertyName = "Cfacv"
        Me.CfacvDataGridViewTextBoxColumn.HeaderText = "Cfacv"
        Me.CfacvDataGridViewTextBoxColumn.Name = "CfacvDataGridViewTextBoxColumn"
        '
        'HAcqLiqDataGridViewTextBoxColumn
        '
        Me.HAcqLiqDataGridViewTextBoxColumn.DataPropertyName = "HAcqLiq"
        Me.HAcqLiqDataGridViewTextBoxColumn.HeaderText = "HAcqLiq"
        Me.HAcqLiqDataGridViewTextBoxColumn.Name = "HAcqLiqDataGridViewTextBoxColumn"
        '
        'MolAcqLiqDataGridViewTextBoxColumn
        '
        Me.MolAcqLiqDataGridViewTextBoxColumn.DataPropertyName = "MolAcqLiq"
        Me.MolAcqLiqDataGridViewTextBoxColumn.HeaderText = "MolAcqLiq"
        Me.MolAcqLiqDataGridViewTextBoxColumn.Name = "MolAcqLiqDataGridViewTextBoxColumn"
        '
        'MasAcqLiqDataGridViewTextBoxColumn
        '
        Me.MasAcqLiqDataGridViewTextBoxColumn.DataPropertyName = "MasAcqLiq"
        Me.MasAcqLiqDataGridViewTextBoxColumn.HeaderText = "MasAcqLiq"
        Me.MasAcqLiqDataGridViewTextBoxColumn.Name = "MasAcqLiqDataGridViewTextBoxColumn"
        '
        'CondCurvaBindingSource
        '
        Me.CondCurvaBindingSource.DataMember = "CondCurva"
        Me.CondCurvaBindingSource.DataSource = Me.dsCondCurva
        '
        'dsCondCurva
        '
        Me.dsCondCurva.DataSetName = "CondCurvaDataSet"
        Me.dsCondCurva.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'CondCurvaTableAdapter
        '
        Me.CondCurvaTableAdapter.ClearBeforeFill = True
        '
        'frmDB
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(640, 597)
        Me.ControlBox = False
        Me.Controls.Add(Me.DBGrid1)
        Me.Controls.Add(Me.Picture1)
        Me.Controls.Add(Me.cDummy)
        Me.Controls.Add(Me.cmdRiordina)
        Me.Controls.Add(Me.PictHelp)
        Me.Controls.Add(Me.Combo1)
        Me.Controls.Add(Me.Command2)
        Me.Controls.Add(Me.Command1)
        Me.Controls.Add(Me.Label1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Location = New System.Drawing.Point(4, 24)
        Me.Name = "frmDB"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "Curva di raffreddamento o riscaldamento"
        CType(Me.PictHelp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Picture1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DBGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CondCurvaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dsCondCurva, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region
#Region "Upgrade Support"
    Public WithEvents cDummy As System.Windows.Forms.Label
    Friend WithEvents Picture1 As System.Windows.Forms.PictureBox
    Friend WithEvents DBGrid1 As System.Windows.Forms.DataGridView
    Friend WithEvents dsCondCurva As Wald.CondCurvaDataSet
    Friend WithEvents CondCurvaBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CondCurvaTableAdapter As Wald.CondCurvaDataSetTableAdapters.CondCurvaTableAdapter
    Friend WithEvents IDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TipoDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents YDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents XDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HtotDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HliqDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HvapDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MtotDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MliqDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MvapDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DenslDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DensvDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CspeclDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CspecvDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VislDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VisvDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents KliqDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents KvapDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CfaclDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CfacvDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HAcqLiqDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MolAcqLiqDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MasAcqLiqDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
#End Region
End Class