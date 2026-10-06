Public Class frmFonda
    Inherits System.Windows.Forms.Form

#Region " Codice generato da Progettazione Windows Form "

    Public Sub New()
        MyBase.New()

        'Chiamata richiesta da Progettazione Windows Form.
        InitializeComponent()
        Me.TabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed
        '  AddHandler Me.TabPrimoLivDown.DrawItem, New DrawItemEventHandler(AddressOf Me.TabPrimoLivDown_DrawItem)

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
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents Labelup1 As System.Windows.Forms.Label
    Friend WithEvents Labeldo1 As System.Windows.Forms.Label
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents TabPageFonda As System.Windows.Forms.TabPage
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPageFonda = New System.Windows.Forms.TabPage
        Me.Labelup1 = New System.Windows.Forms.Label
        Me.Labeldo1 = New System.Windows.Forms.Label
        Me.cmdOK = New System.Windows.Forms.Button
        Me.TabControl1.SuspendLayout()
        Me.TabPageFonda.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPageFonda)
        Me.TabControl1.Location = New System.Drawing.Point(8, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(520, 560)
        Me.TabControl1.TabIndex = 0
        '
        'TabPageFonda
        '
        Me.TabPageFonda.Controls.Add(Me.Labelup1)
        Me.TabPageFonda.Controls.Add(Me.Labeldo1)
        Me.TabPageFonda.Location = New System.Drawing.Point(4, 22)
        Me.TabPageFonda.Name = "TabPageFonda"
        Me.TabPageFonda.Size = New System.Drawing.Size(512, 534)
        Me.TabPageFonda.TabIndex = 0
        Me.TabPageFonda.Text = "Cond. 1"
        '
        'Labelup1
        '
        Me.Labelup1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Labelup1.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Labelup1.Location = New System.Drawing.Point(16, 16)
        Me.Labelup1.Name = "Labelup1"
        Me.Labelup1.Size = New System.Drawing.Size(480, 248)
        Me.Labelup1.TabIndex = 0
        Me.Labelup1.Text = "Label1"
        Me.Labelup1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Labeldo1
        '
        Me.Labeldo1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Labeldo1.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Labeldo1.Location = New System.Drawing.Point(16, 272)
        Me.Labeldo1.Name = "Labeldo1"
        Me.Labeldo1.Size = New System.Drawing.Size(480, 248)
        Me.Labeldo1.TabIndex = 1
        Me.Labeldo1.Text = "Label1"
        Me.Labeldo1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmdOK
        '
        Me.cmdOK.Location = New System.Drawing.Point(536, 520)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(56, 32)
        Me.cmdOK.TabIndex = 1
        Me.cmdOK.Text = "OK"
        '
        'frmFonda
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(594, 570)
        Me.ControlBox = False
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmFonda"
        Me.Text = "Risulati della verifica fondazioni"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPageFonda.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        Dispose()
    End Sub

    Private Sub TabControl1_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles TabControl1.DrawItem
        Dim fntTab As Font
        Dim bshBack As Brush
        Dim bshFore As Brush

        If CStr(TabControl1.TabPages(e.Index).Tag) = "rosso" Then
            fntTab = New Font(e.Font, FontStyle.Bold)
            bshBack = New System.Drawing.Drawing2D.LinearGradientBrush(e.Bounds, SystemColors.Control, SystemColors.Control, System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal)
            bshFore = Brushes.Red
            '				//bshBack = new System.Drawing.Drawing2D.LinearGradientBrush(e.Bounds, Color.LightSkyBlue , Color.LightGreen, System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal);
            '				//bshFore = Brushes.Blue;
        Else
            fntTab = e.Font
            bshBack = New SolidBrush(SystemColors.Control)
            bshFore = New SolidBrush(Color.Black)

            '				//bshBack = new SolidBrush(Color.White);
            '				//bshFore = new SolidBrush(Color.Black);
        End If
        Dim tabName As String = TabControl1.TabPages(e.Index).Text
        Dim sftTab As StringFormat = New StringFormat
        e.Graphics.FillRectangle(bshBack, e.Bounds)
        Dim x As Single = e.Bounds.X
        Dim y As Single = e.Bounds.Y
        e.Graphics.DrawString(tabName, fntTab, bshFore, x, y, sftTab)

    End Sub
End Class
