<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBL
    Inherits System.Windows.Forms.Form

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Richiesto da Progettazione Windows Form
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura che segue è richiesta da Progettazione Windows Form
    'Può essere modificata in Progettazione Windows Form.  
    'Non modificarla nell'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me._cmbCil_0 = New System.Windows.Forms.ComboBox
        Me._LabelCil_0 = New System.Windows.Forms.Label
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdOK = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        '_cmbCil_0
        '
        Me._cmbCil_0.BackColor = System.Drawing.SystemColors.Window
        Me._cmbCil_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmbCil_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._cmbCil_0.Location = New System.Drawing.Point(144, 8)
        Me._cmbCil_0.Name = "_cmbCil_0"
        Me._cmbCil_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmbCil_0.Size = New System.Drawing.Size(137, 21)
        Me._cmbCil_0.TabIndex = 61
        Me._cmbCil_0.Text = "cmbCil"
        '
        '_LabelCil_0
        '
        Me._LabelCil_0.BackColor = System.Drawing.SystemColors.Control
        Me._LabelCil_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelCil_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LabelCil_0.Location = New System.Drawing.Point(8, 8)
        Me._LabelCil_0.Name = "_LabelCil_0"
        Me._LabelCil_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelCil_0.Size = New System.Drawing.Size(121, 17)
        Me._LabelCil_0.TabIndex = 62
        Me._LabelCil_0.Text = "Member identification"
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCancel.Location = New System.Drawing.Point(200, 232)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCancel.Size = New System.Drawing.Size(48, 25)
        Me.cmdCancel.TabIndex = 64
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'cmdOK
        '
        Me.cmdOK.BackColor = System.Drawing.SystemColors.Control
        Me.cmdOK.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdOK.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdOK.Location = New System.Drawing.Point(248, 232)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdOK.Size = New System.Drawing.Size(48, 25)
        Me.cmdOK.TabIndex = 63
        Me.cmdOK.Text = "OK"
        Me.cmdOK.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(32, 104)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(237, 13)
        Me.Label1.TabIndex = 65
        Me.Label1.Text = "Tutti i dati vengono forniti al momento del calcolo"
        '
        'frmBL
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(303, 266)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me._cmbCil_0)
        Me.Controls.Add(Me._LabelCil_0)
        Me.HelpButton = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmBL"
        Me.Text = "Chiusure tipo Breech Lock"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents _cmbCil_0 As System.Windows.Forms.ComboBox
    Public WithEvents _LabelCil_0 As System.Windows.Forms.Label
    Public WithEvents cmdCancel As System.Windows.Forms.Button
    Public WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
