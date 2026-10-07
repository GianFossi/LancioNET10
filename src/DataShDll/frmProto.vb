Option Strict Off
Option Explicit On
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.common
Imports VB = Microsoft.VisualBasic
Friend Class frmProto
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
	Public WithEvents txtFBM As System.Windows.Forms.TextBox
	Public WithEvents txtDettagli As System.Windows.Forms.TextBox
	Public WithEvents Command3 As System.Windows.Forms.Button
	Public WithEvents ListClasse As System.Windows.Forms.ListBox
	Public WithEvents listProto As System.Windows.Forms.ListBox
	Public WithEvents Command2 As System.Windows.Forms.Button
	Public WithEvents Command1 As System.Windows.Forms.Button
	Public WithEvents Picture1 As System.Windows.Forms.PictureBox
    Public WithEvents Grid1 As System.Windows.Forms.DataGrid 'AxMSGrid.AxGrid
	Public WithEvents lblNomeProto As System.Windows.Forms.Label
	Public WithEvents lblProto As System.Windows.Forms.Label
	Public WithEvents Label13 As System.Windows.Forms.Label
	Public WithEvents TEMA As System.Windows.Forms.Label
	Public WithEvents LabTEMA As System.Windows.Forms.Label
	Public WithEvents LabClasse As System.Windows.Forms.Label
	Public WithEvents LabFBM As System.Windows.Forms.Label
	'NOTA: la routine seguente è richiesta dalla progettazione Windows Form.
	'Può essere modificata utilizzando la finestra di progettazione Windows Form.
	'Non modificarla mediante l'editor di codice.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmProto))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.txtFBM = New System.Windows.Forms.TextBox
        Me.txtDettagli = New System.Windows.Forms.TextBox
        Me.Command3 = New System.Windows.Forms.Button
        Me.ListClasse = New System.Windows.Forms.ListBox
        Me.listProto = New System.Windows.Forms.ListBox
        Me.Command2 = New System.Windows.Forms.Button
        Me.Command1 = New System.Windows.Forms.Button
        Me.Picture1 = New System.Windows.Forms.PictureBox
        Me.Grid1 = New System.Windows.Forms.DataGrid 'AxMSGrid.AxGrid
        Me.lblNomeProto = New System.Windows.Forms.Label
        Me.lblProto = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.TEMA = New System.Windows.Forms.Label
        Me.LabTEMA = New System.Windows.Forms.Label
        Me.LabClasse = New System.Windows.Forms.Label
        Me.LabFBM = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'txtFBM
        '
        Me.txtFBM.AcceptsReturn = True
        Me.txtFBM.AutoSize = False
        Me.txtFBM.BackColor = System.Drawing.SystemColors.Window
        Me.txtFBM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFBM.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtFBM.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtFBM.Location = New System.Drawing.Point(88, 40)
        Me.txtFBM.MaxLength = 0
        Me.txtFBM.Name = "txtFBM"
        Me.txtFBM.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtFBM.Size = New System.Drawing.Size(193, 21)
        Me.txtFBM.TabIndex = 15
        Me.txtFBM.Text = "Text2"
        '
        'txtDettagli
        '
        Me.txtDettagli.AcceptsReturn = True
        Me.txtDettagli.AutoSize = False
        Me.txtDettagli.BackColor = System.Drawing.SystemColors.Window
        Me.txtDettagli.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDettagli.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDettagli.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtDettagli.Location = New System.Drawing.Point(280, 40)
        Me.txtDettagli.MaxLength = 0
        Me.txtDettagli.Name = "txtDettagli"
        Me.txtDettagli.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtDettagli.Size = New System.Drawing.Size(185, 21)
        Me.txtDettagli.TabIndex = 14
        Me.txtDettagli.Text = ""
        '
        'Command3
        '
        Me.Command3.BackColor = System.Drawing.SystemColors.Control
        Me.Command3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command3.Location = New System.Drawing.Point(390, 0)
        Me.Command3.Name = "Command3"
        Me.Command3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command3.Size = New System.Drawing.Size(71, 21)
        Me.Command3.TabIndex = 13
        Me.Command3.Text = "Ripristina"
        Me.Command3.Visible = False
        '
        'ListClasse
        '
        Me.ListClasse.BackColor = System.Drawing.SystemColors.Window
        Me.ListClasse.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ListClasse.Cursor = System.Windows.Forms.Cursors.Default
        Me.ListClasse.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ListClasse.Location = New System.Drawing.Point(480, 70)
        Me.ListClasse.Name = "ListClasse"
        Me.ListClasse.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ListClasse.Size = New System.Drawing.Size(51, 28)
        Me.ListClasse.TabIndex = 12
        Me.ListClasse.Visible = False
        '
        'listProto
        '
        Me.listProto.BackColor = System.Drawing.SystemColors.Window
        Me.listProto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.listProto.Cursor = System.Windows.Forms.Cursors.Default
        Me.listProto.ForeColor = System.Drawing.SystemColors.WindowText
        Me.listProto.Location = New System.Drawing.Point(480, 30)
        Me.listProto.Name = "listProto"
        Me.listProto.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.listProto.Size = New System.Drawing.Size(51, 28)
        Me.listProto.TabIndex = 11
        Me.listProto.Visible = False
        '
        'Command2
        '
        Me.Command2.BackColor = System.Drawing.SystemColors.Control
        Me.Command2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command2.Location = New System.Drawing.Point(320, 0)
        Me.Command2.Name = "Command2"
        Me.Command2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command2.Size = New System.Drawing.Size(71, 21)
        Me.Command2.TabIndex = 10
        Me.Command2.Text = "Sfoglia"
        '
        'Command1
        '
        Me.Command1.BackColor = System.Drawing.SystemColors.Control
        Me.Command1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command1.Location = New System.Drawing.Point(480, 0)
        Me.Command1.Name = "Command1"
        Me.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command1.Size = New System.Drawing.Size(61, 21)
        Me.Command1.TabIndex = 1
        Me.Command1.Text = "OK"
        '
        'Picture1
        '
        Me.Picture1.BackColor = System.Drawing.SystemColors.Window
        Me.Picture1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Picture1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Picture1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Picture1.Location = New System.Drawing.Point(10, 90)
        Me.Picture1.Name = "Picture1"
        Me.Picture1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Picture1.Size = New System.Drawing.Size(531, 241)
        Me.Picture1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.Picture1.TabIndex = 0
        Me.Picture1.TabStop = False
        '
        'Grid1
        '
        Me.Grid1.Location = New System.Drawing.Point(90, 80)
        Me.Grid1.Name = "Grid1"
        Me.Grid1.Size = New System.Drawing.Size(371, 121)
        Me.Grid1.TabIndex = 9
        Me.Grid1.Visible = False
        '
        'lblNomeProto
        '
        Me.lblNomeProto.BackColor = System.Drawing.SystemColors.Window
        Me.lblNomeProto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblNomeProto.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblNomeProto.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblNomeProto.Location = New System.Drawing.Point(90, 60)
        Me.lblNomeProto.Name = "lblNomeProto"
        Me.lblNomeProto.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblNomeProto.Size = New System.Drawing.Size(51, 21)
        Me.lblNomeProto.TabIndex = 8
        '
        'lblProto
        '
        Me.lblProto.BackColor = System.Drawing.SystemColors.Window
        Me.lblProto.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblProto.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblProto.Location = New System.Drawing.Point(10, 60)
        Me.lblProto.Name = "lblProto"
        Me.lblProto.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblProto.Size = New System.Drawing.Size(71, 21)
        Me.lblProto.TabIndex = 7
        Me.lblProto.Text = "Prototipo"
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.SystemColors.Window
        Me.Label13.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label13.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label13.Location = New System.Drawing.Point(10, 40)
        Me.Label13.Name = "Label13"
        Me.Label13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label13.Size = New System.Drawing.Size(71, 21)
        Me.Label13.TabIndex = 6
        Me.Label13.Text = "Tipo"
        '
        'TEMA
        '
        Me.TEMA.BackColor = System.Drawing.SystemColors.Window
        Me.TEMA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TEMA.Cursor = System.Windows.Forms.Cursors.Default
        Me.TEMA.Enabled = False
        Me.TEMA.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TEMA.Location = New System.Drawing.Point(90, 20)
        Me.TEMA.Name = "TEMA"
        Me.TEMA.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TEMA.Size = New System.Drawing.Size(51, 21)
        Me.TEMA.TabIndex = 5
        Me.TEMA.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'LabTEMA
        '
        Me.LabTEMA.BackColor = System.Drawing.SystemColors.Window
        Me.LabTEMA.Cursor = System.Windows.Forms.Cursors.Default
        Me.LabTEMA.ForeColor = System.Drawing.SystemColors.WindowText
        Me.LabTEMA.Location = New System.Drawing.Point(10, 20)
        Me.LabTEMA.Name = "LabTEMA"
        Me.LabTEMA.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LabTEMA.Size = New System.Drawing.Size(71, 21)
        Me.LabTEMA.TabIndex = 4
        Me.LabTEMA.Text = "Tipo TEMA"
        '
        'LabClasse
        '
        Me.LabClasse.BackColor = System.Drawing.SystemColors.Window
        Me.LabClasse.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LabClasse.Cursor = System.Windows.Forms.Cursors.Default
        Me.LabClasse.ForeColor = System.Drawing.SystemColors.WindowText
        Me.LabClasse.Location = New System.Drawing.Point(90, 0)
        Me.LabClasse.Name = "LabClasse"
        Me.LabClasse.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LabClasse.Size = New System.Drawing.Size(231, 21)
        Me.LabClasse.TabIndex = 3
        '
        'LabFBM
        '
        Me.LabFBM.BackColor = System.Drawing.SystemColors.Window
        Me.LabFBM.Cursor = System.Windows.Forms.Cursors.Default
        Me.LabFBM.ForeColor = System.Drawing.SystemColors.WindowText
        Me.LabFBM.Location = New System.Drawing.Point(10, 0)
        Me.LabFBM.Name = "LabFBM"
        Me.LabFBM.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LabFBM.Size = New System.Drawing.Size(71, 21)
        Me.LabFBM.TabIndex = 2
        Me.LabFBM.Text = "Classe"
        '
        'frmProto
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.ClientSize = New System.Drawing.Size(549, 353)
        Me.ControlBox = False
        Me.Controls.Add(Me.txtFBM)
        Me.Controls.Add(Me.txtDettagli)
        Me.Controls.Add(Me.Command3)
        Me.Controls.Add(Me.ListClasse)
        Me.Controls.Add(Me.listProto)
        Me.Controls.Add(Me.Command2)
        Me.Controls.Add(Me.Command1)
        Me.Controls.Add(Me.Picture1)
        Me.Controls.Add(Me.Grid1)
        Me.Controls.Add(Me.lblNomeProto)
        Me.Controls.Add(Me.lblProto)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.TEMA)
        Me.Controls.Add(Me.LabTEMA)
        Me.Controls.Add(Me.LabClasse)
        Me.Controls.Add(Me.LabFBM)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Location = New System.Drawing.Point(59, 44)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmProto"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Lista prototipi"
        Me.ResumeLayout(False)

    End Sub
#End Region 
    Public Oper As Single '0 scelta 1 creazione nuovo
	Public Descrizione, Dettagli As String
	Private W, H, TopFig As Short
	Private ProtoVec As String
    Public mygraphics As Graphics
    Public myfont As Font
    Public mybrush As SolidBrush
    Public x, y As Single
    Private dovebitmap As Bitmap
    Private Sub Inizializza()
        dovebitmap = New Bitmap(Picture1.ClientRectangle.Width, Picture1.ClientRectangle.Height)
        mygraphics = Graphics.FromImage(dovebitmap)
        Picture1.Image = dovebitmap
        myfont = Picture1.Font
        mybrush = New SolidBrush(Color.Black)
    End Sub
    Private Function CaricaDis(ByRef Nome As String) As Boolean
        Dim W1, H1, Factor As Single
        Dim Clas, Testo As String
        Dim i As Short
        CaricaDis = True
        Picture1.Visible = False
        Try
            Picture1.Image = System.Drawing.Image.FromFile(Nome)
        Catch e As Exception
            Testo = Helpstringa(IDH_ERR_NOWMF)
            Testo = GlobalRoutines.FormatS(Testo, Nome)
            MostraAiuto(IDH_ERR_NOWMF, RoutBase1.ChiaviMess.MessInformation, Testo)
            'Routines.DoveDisegnog.Clear(Color.White)
            Return False
        End Try
        H1 = LegacyUiUnits.PixelsToTwipsY(Picture1.Height)
        W1 = LegacyUiUnits.PixelsToTwipsX(Picture1.Width)
        Factor = H1 / H
        If W1 / W > Factor Then Factor = W1 / W
        Picture1.Height = GlobalRoutines.TwipsToPixelsY(LegacyUiUnits.PixelsToTwipsY(Picture1.Height) / Factor)
        Picture1.Width = GlobalRoutines.TwipsToPixelsX(LegacyUiUnits.PixelsToTwipsX(Picture1.Width) / Factor)
        Picture1.Top = GlobalRoutines.TwipsToPixelsY(TopFig + H - LegacyUiUnits.PixelsToTwipsY(Picture1.Height))
        Picture1.Visible = True
        If LegacyUiUnits.PixelsToTwipsY(Picture1.Top) + LegacyUiUnits.PixelsToTwipsY(Picture1.Height) > LegacyUiUnits.PixelsToTwipsY(Height) - 200 Then Height = GlobalRoutines.TwipsToPixelsY(LegacyUiUnits.PixelsToTwipsY(Picture1.Top) + LegacyUiUnits.PixelsToTwipsY(Picture1.Height) + 200)
        ' Grid1.Col = 0
        ' Clas = LTrim(RTrim(Grid1.CtlText))
        For i = 0 To ListClasse.Items.Count - 1
            If VB.Left(LTrim(ListClasse.GetItemText(ListClasse.Items(i))), 1) = Clas Then
                LabClasse.Text = Clas
                Exit For
            End If
        Next
    End Function
    Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click ' OK
        Dim i As Short
        If Oper = 0 Then
            mioApert.cmbClasse.Text = LabClasse.Text
            mioApert.TEMA.Text = TEMA.Text
            mioApert.FBMLabel.Text = Trim(txtFBM.Text) & ";" & Trim(txtDettagli.Text)
            mioApert.lblNomeProto.Text = ProtoTyp
            'cazzata! DataSheet.DatiSh0.FBMLetter = Left$(LTrim$(FBMLabel.Caption), 1)
            DataSheet.DatiSh0.TEMALetter(1) = Mid(TEMA.Text, 1, 1)
            DataSheet.DatiSh0.TEMALetter(2) = Mid(TEMA.Text, 2, 1)
            DataSheet.DatiSh0.TEMALetter(3) = Mid(TEMA.Text, 3, 1)
        Else
            Descrizione = txtFBM.Text
            Dettagli = txtDettagli.Text
        End If
        listProto.Items.Clear()
        '  Grid1.FixedRows = 0
        ' ' For i = Grid1.Rows To 1: Grid1.RemoveItem i: Next
        Hide()
    End Sub
    Private Sub Command2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command2.Click 'sfoglia
        Dim Text1 As String
        If Not Grid1.Visible Then
            Command1.Enabled = False
            Command2.Text = "Accetta"
            Command3.Visible = True
            Grid1.Visible = True
            Command2.Enabled = Oper = 0
        Else
            Grid1.Visible = False
            Command1.Enabled = True
            Command2.Text = "Sfoglia"
            Command2.Enabled = True
            Command3.Visible = False
            If ProtoTyp = ProtoVec Then
                Call CaricaDis(RTrim(Monitor.Motore.Inizio.Archdir) & "\PROTO\A" & ProtoTyp & "\000.WMF")
            Else
                If MsgBox("Vuoi veramente sostituire il prototipo precedentemente definito con l'attuale?", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.Yes Then
                    '   Grid1.Col = 1
                    '   TEMA.Text = Grid1.CtlText
                    '   Grid1.Col = 2
                    ' 'Text1 = Grid1.Text + " ; "
                    '  txtFBM.Text = Grid1.CtlText
                    'Grid1.Col = 3
                    ''Text1 = Text1 + Grid1.Text
                    ''FBMLabel.Caption = Text1
                    'txtDettagli.Text = Grid1.CtlText
                    Call CaricaDis(RTrim(Monitor.Motore.Inizio.Archdir) & "\PROTO\A" & ProtoTyp & "\000.WMF")
                Else
                    ProtoTyp = ProtoVec
                    Call CaricaDis(RTrim(Monitor.Motore.Inizio.Archdir) & "\PROTO\A" & ProtoTyp & "\000.WMF")
                End If
            End If
        End If
    End Sub
    Private Sub Command3_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command3.Click 'Ripristina
        Dim Nome As String
        Grid1.Visible = False
        Command1.Enabled = True
        Command2.Text = "Sfoglia"
        Command3.Visible = False
        ProtoTyp = ProtoVec
        If Oper = 0 Then
            Nome = RTrim(Monitor.Motore.Inizio.Archdir) & "\PROTO\" & ProtoTyp & "\000.WMF"
        Else
            Nome = Monitor.Motore.Inizio.Workdir & "\" & job.Comm.Arch & "\" + job.Comm.Ind(job.Comm.indice).Data.File + ".WMF"
        End If
        CaricaDis(Nome)
    End Sub
    Public Function Inizializza1() As Boolean
        Dim Nome As String
        Dim n As Short
        Inizializza1 = True
        ProtoVec = ProtoTyp
        H = LegacyUiUnits.PixelsToTwipsY(Picture1.Height)
        W = LegacyUiUnits.PixelsToTwipsX(Picture1.Width)
        TopFig = LegacyUiUnits.PixelsToTwipsY(Picture1.Top)
        LabClasse.Text = mioApert.cmbClasse.Text
        TEMA.Text = mioApert.TEMA.Text
        Nome = mioApert.FBMLabel.Text
        n = InStr(Nome, ";")
        If n = 0 Then Stop
        txtFBM.Text = VB.Left(Nome, n - 1)
        txtDettagli.Text = VB.Right(Nome, Len(Nome) - n)
        lblNomeProto.Text = mioApert.lblNomeProto.Text
        If Oper = 0 Then
            Nome = RTrim(Monitor.Motore.Inizio.Archdir) & "\PROTO\A" & ProtoTyp & "\000.WMF"
        Else
            Nome = Monitor.Motore.Inizio.Workdir & "A" & job.Comm.Arch & "\" + job.Comm.Ind(job.Comm.indice).Data.File + ".WMF"
        End If
        If Not CaricaDis(Nome) Then Return False
        Call RiempiGrid()
        If Oper = 1 Then
            lblNomeProto.Text = ProtoTyp
            txtFBM.Text = "Descrizione?"
            txtDettagli.Text = "Dettagli?"
        End If
        txtFBM.Enabled = Oper = 1
        txtDettagli.Enabled = Oper = 1
    End Function
    'Private Sub Grid1_RowColChange(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Grid1.RowColChange
    '    Dim NewProto, Nome As String
    '    'NewProto = VB6.GetItemString(listProto, Grid1.Row - 1)
    '    If Len(LTrim(RTrim(NewProto))) = 0 Then Exit Sub
    '    If NewProto <> ProtoTyp Then
    '        ProtoTyp = NewProto
    '        Nome = RTrim(Monitor.Motore.Inizio.Archdir) & "\PROTO\A" & ProtoTyp & "\000.WMF"
    '        Call CaricaDis(Nome)
    '    End If
    '    'Grid1.SelStartCol = 0
    '    'Grid1.SelEndCol = 4
    'End Sub
    Private Sub RiempiGrid()
        Dim ifl, Nrow As Short
        Dim Log2, Log1, Log3 As Boolean
        'ReDim Cod(9) As String
        ' Grid1.Rows = 1
        ' Grid1.Row = 0
        ' Grid1.set_ColWidth(0, 350)
        ' Grid1.set_ColWidth(1, 600)
        ' Grid1.set_ColWidth(2, 2000)
        ' Grid1.set_ColWidth(3, 2000)
        ' Grid1.set_ColWidth(4, 200)
        ' Grid1.Col = 0 : Grid1.CtlText = "Cat"
        ' Grid1.Col = 1 : Grid1.CtlText = "TEMA"
        ' Grid1.Col = 2 : Grid1.CtlText = "Descrizione"
        ' Grid1.Col = 3 : Grid1.CtlText = "Dettagli"
        ' Grid1.Col = 4 : Grid1.CtlText = ""
        ' Grid1.Col = 0
        Dim cString As String = Conn & Monitor.Motore.Inizio.Archdir & "\PROTO\CLASSI.MDB" & ConnFine
        dbClassi = New OleDbConnection(cString)
        cmdClassi = New OleDbDataAdapter("SELECT * FROM Classi", dbClassi)
        tbClassi = New DataTable
        cmdClassi.Fill(tbClassi)
        CBClassi = New OleDbCommandBuilder(cmdClassi)
        dvClassi = tbClassi.DefaultView
        Nrow = 0
        Dim ii As Short
        For ii = 0 To dvClassi.Count - 1
            If Not IsDBNull(dvClassi(ii)("Commessa")) Then
                If Oper = 0 Then
                    If Len(RTrim(dvClassi(ii)("Commessa"))) > 0 Then
                        listProto.Items.Add(dvClassi(ii)("Commessa"))
                        '   Grid1.AddItem(dvClassi(ii)("Categoria") & Chr(9) & dvClassi(ii)("TipoTEMA") & Chr(9) & dvClassi(ii)("Descrizione") & Chr(9) & dvClassi(ii)("Dettagli") & Chr(9) & dvClassi(ii)("HV"))
                        Nrow = Nrow + 1
                        If RTrim(dvClassi(ii)("Commessa")) = ProtoTyp Then
                            '       Grid1.SelStartRow = Nrow
                            '      Grid1.SelEndRow = Nrow
                            '     Grid1.SelStartCol = 0
                            '     Grid1.SelEndCol = 4
                        End If
                    End If
                Else
                    Log1 = dvClassi(ii)("Categoria") = DataSheet.DatiSh0.FBMLetter
                    Log2 = IsDBNull(dvClassi(ii)("TipoTEMA")) And Trim(DataSheet.DatiSh0.TEMALetter(1)) = ""
                    If Not IsDBNull(dvClassi(ii)("TipoTEMA")) Then
                        Log2 = Trim(dvClassi(ii)("TipoTEMA")) = "" And Trim(DataSheet.DatiSh0.TEMALetter(1)) = ""
                        If Not Trim(dvClassi(ii)("TipoTEMA")) = "" Then
                            Log2 = dvClassi(ii)("TipoTEMA") = DataSheet.DatiSh0.TEMALetter(1) & DataSheet.DatiSh0.TEMALetter(2) & DataSheet.DatiSh0.TEMALetter(3)
                        End If
                    End If
                    Log3 = dvClassi(ii)("HV") = job.Comm.Asse
                    If Log1 And Log2 And Log3 Then
                        listProto.Items.Add(dvClassi(ii)("Commessa"))
                        '   Grid1.AddItem(dvClassi(ii)("Categoria") & Chr(9) & dvClassi(ii)("TipoTEMA") & Chr(9) & dvClassi(ii)("Descrizione") & Chr(9) & dvClassi(ii)("Dettagli") & Chr(9) & dvClassi(ii)("HV"))
                        Nrow = Nrow + 1
                    End If
                End If
            End If
        Next
        If Oper = 1 Then
            '          Grid1.AddItem DataSheet.DatiSh0.FBMLetter & Chr$(9) & DataSheet.DatiSh0.TEMALetter(1) + DataSheet.DatiSh0.TEMALetter(2) + DataSheet.DatiSh0.TEMALetter(3) & Chr$(9) & "Descrizione" & Chr$(9) & "Dettagli" & Chr$(9) & job.Comm.Asse
            '          Nrow = Nrow + 1
            '          Grid1.SelStartRow = Nrow
            '          Grid1.SelEndRow = Nrow
            '          Grid1.SelStartCol = 0
            '          Grid1.SelEndCol = 4
        End If
        '  Grid1.FixedRows = 1
    End Sub
    Private Sub Grid1_Validating(ByVal eventSender As System.Object, ByVal eventArgs As System.ComponentModel.CancelEventArgs) Handles Grid1.Validating
        Dim Cancel As Boolean = eventArgs.Cancel
        'If Oper = 0 Then
        '   Cancel = True
        'Else
        '   If Grid1.Row < Grid1.Rows - 1 Then
        '      Cancel = True
        '   Else
        '      Select Case Grid1.Col
        '         Case 0, 1, 4
        '            Cancel = True
        '         Case 2
        '            Descrizione = Grid1.Text
        '         Case 3
        '            Dettagli = Grid1.Text
        '      End Select
        '   End If
        'End If
        eventArgs.Cancel = Cancel
    End Sub
End Class