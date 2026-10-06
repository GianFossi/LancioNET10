Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class frmDB
	Inherits System.Windows.Forms.Form
	
	'   Begin VB.Label Label1
	'      Caption = "Grandezza graficata"
	'      Height = 285
	'      Left = 135
	'      TabIndex = 3
	'      Top = 8505
	'      Width = 1500
	'   End
	'End
	Public OK As Boolean
	Public yTop, yBot As Single
	Public pictWidth, pictHeight As Single
	Public EditZone As Short
	Private Grafico As RoutBase1.clsGrafico
    Public mygraphics As Graphics
    Public myfont As Font
    Public mybrush As SolidBrush
    Public mypen As Pen
    Private Inizializzando As Boolean
    Private dovebitmap As Bitmap
    Private Sub Inizializza()
        dovebitmap = New Bitmap(Picture1.ClientRectangle.Width, Picture1.ClientRectangle.Height)
        mygraphics = Graphics.FromImage(dovebitmap)
        Picture1.Image = dovebitmap
        myfont = Picture1.Font
        mybrush = New SolidBrush(Color.Black)
        mypen = New Pen(Color.Black)
    End Sub
    Private Sub cmdRiempi_Click()
        Dim kk, i, j, k, kkk As Short
        Dim X() As Single
        Dim Y() As Single
        Dim n As Short
        Dim indice() As Short
        Dim dv As DataView = dsCondCurva.CondCurva.DefaultView
        n = dv.Count
        ReDim X(n)
        ReDim Y(n)
        ReDim indice(n)
        For j = 4 To dsCondCurva.CondCurva.Columns.Count - 1
            For i = 1 To n
                X(i) = dv(i - 1)("t")
                Y(i) = dv(i - 1)(j)
            Next
            k = 0
            For i = 1 To n
                If Y(i) <> 0 Then
                    k = k + 1
                    indice(k) = i
                End If
            Next
            For kk = 1 To k - 1
                For kkk = indice(kk) + 1 To indice(kk + 1) - 1
                    Y(kkk) = Y(indice(kk)) + (Y(indice(kk + 1)) - Y(indice(kk))) * (X(kkk) - X(indice(kk))) / (X(indice(kk + 1)) - X(indice(kk)))
                Next
            Next
            For i = 1 To n
                dv(i - 1).BeginEdit()
                dv(i - 1)(j).Value = Y(i)
                dv(i - 1).EndEdit()
            Next
        Next
    End Sub
	
	Private Sub cmdRiordina_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdRiordina.Click
		Rinfresca()
	End Sub
    Public Sub Combo1_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Combo1.SelectedIndexChanged
        If Inizializzando Then Exit Sub
        Dim tRight, tLeft As Single
        Dim Tity, Titx As String
        Dim Tit As String = ""
        Dim X() As Single
        Dim Y() As Single
        Dim n As Short
        Dim Dida As String
        Dim Stile As Drawing2D.DashStyle
        Dim i As Short
        Dim yMax, yMin As Single
        i = 1
        With t
            n = .Rows.Count
            ReDim X(n)
            ReDim Y(n)
            For i = 1 To n
                X(i) = .DefaultView(i - 1)("t")
            Next
            tLeft = X(1) : tRight = X(n)
            Titx = "Temperatura"
            Me.mygraphics.Clear(Color.White)
            Select Case Combo1.SelectedIndex
                Case 0 ' "Nessuna"
                Case 1 ' "Pressione"
                    yMax = -10000000000.0# : yMin = 10000000000.0#
                    For i = 1 To n
                        Y(i) = .DefaultView(i - 1)("p")
                        If Y(i) > yMax Then yMax = Y(i)
                        If Y(i) < yMin Then yMin = Y(i)
                    Next
                    yTop = yMax : yBot = yMin
                    Tity = "Pressione"
                    Dida = ""
                    Stile = Drawing2D.DashStyle.Solid
                    Grafico.Inizializza(yTop, yBot, tRight, tLeft, Titx, Tity, Tit, Picture1)
                    Grafico.DisCurva(X, Y, 1, n, Dida, Stile)
                Case 2 ' "Entalpie"
                    yMax = -10000000000.0# : yMin = 10000000000.0#
                    For i = 1 To n
                        Try
                            Y(i) = .DefaultView(i - 1)("Htot")
                        Catch e As Exception
                            Y(i) = 0
                        End Try
                        If Y(i) > yMax Then yMax = Y(i)
                        If Y(i) < yMin Then yMin = Y(i)
                        If .DefaultView(i - 1)("Hliq") > yMax Then yMax = .DefaultView(i - 1)("Hliq")
                        If .DefaultView(i - 1)("Hliq") < yMin Then yMin = .DefaultView(i - 1)("Hliq")
                        If .DefaultView(i - 1)("Hvap") > yMax Then yMax = .DefaultView(i - 1)("Hvap")
                        If .DefaultView(i - 1)("Hvap") < yMin Then yMin = .DefaultView(i - 1)("Hvap")
                    Next
                    yTop = yMax : yBot = yMin
                    Tity = "Entalpia"
                    Dida = "Entalpia totale"
                    Stile = Drawing2D.DashStyle.Solid
                    Grafico.Inizializza(yTop, yBot, tRight, tLeft, Titx, Tity, Tit, Picture1)
                    Grafico.DisCurva(X, Y, 1, n, Dida, Stile)
                    For i = 1 To n
                        Y(i) = .DefaultView(i - 1)("Hliq")
                    Next
                    Dida = "Entalpia liquido"
                    Stile = Drawing2D.DashStyle.Dash
                    Grafico.DisCurva(X, Y, 1, n, Dida, Stile)
                    For i = 1 To n
                        Y(i) = .DefaultView(i - 1)("Hvap")
                    Next
                    Dida = "Entalpia vapore"
                    Stile = Drawing2D.DashStyle.DashDot
                    Grafico.DisCurva(X, Y, 1, n, Dida, Stile)
                Case 3 ' "Titoli"
                    For i = 1 To n
                        Y(i) = .DefaultView(i - 1)("X")
                    Next
                    yTop = 1 : yBot = 0
                    Tity = "Titoli"
                    Dida = "Titolo ponderale"
                    Stile = Drawing2D.DashStyle.Solid
                    Grafico.Inizializza(yTop, yBot, tRight, tLeft, Titx, Tity, Tit, Picture1)
                    Grafico.DisCurva(X, Y, 1, n, Dida, Stile)
                    For i = 1 To n
                        Y(i) = .DefaultView(i - 1)("Y")
                    Next
                    Dida = "Titolo molare"
                    Stile = Drawing2D.DashStyle.DashDot
                    Grafico.DisCurva(X, Y, 1, n, Dida, Stile)
                Case 4 ' "Densità"
                    yMax = -10000000000.0# : yMin = 10000000000.0#
                    For i = 1 To n
                        Y(i) = .DefaultView(i - 1)("Densv")
                        If Y(i) > yMax Then yMax = Y(i)
                        If Y(i) < yMin Then yMin = Y(i)
                        If .DefaultView(i - 1)("Densl") * 1000 > yMax Then yMax = .DefaultView(i - 1)("Densl") * 1000
                        If .DefaultView(i - 1)("Densl") * 1000 < yMin Then yMin = .DefaultView(i - 1)("Densl") * 1000
                    Next
                    yTop = yMax : yBot = yMin
                    Tity = "Densità"
                    Dida = "Densità vapore"
                    Stile = Drawing2D.DashStyle.Solid
                    Grafico.Inizializza(yTop, yBot, tRight, tLeft, Titx, Tity, Tit, Picture1)
                    Grafico.DisCurva(X, Y, 1, n, Dida, Stile)
                    For i = 1 To n
                        Y(i) = .DefaultView(i - 1)("Densl").Value
                    Next
                    Dida = "Densità liquido"
                    Stile = Drawing2D.DashStyle.DashDot
                    Grafico.DisCurva(X, Y, 1, n, Dida, Stile)
                Case 5 ' "Calori specifici"
                    yMax = -10000000000.0# : yMin = 10000000000.0#
                    For i = 1 To n
                        Y(i) = .DefaultView(i - 1)("Cspecv")
                        If Y(i) > yMax Then yMax = Y(i)
                        If Y(i) < yMin Then yMin = Y(i)
                        If .DefaultView(i - 1)("Cspecl") > yMax Then yMax = .DefaultView(i - 1)("Cspecl")
                        If .DefaultView(i - 1)("Cspecl") < yMin Then yMin = .DefaultView(i - 1)("Cspecl")
                    Next
                    yTop = yMax : yBot = yMin
                    Tity = "Calore specifico"
                    Dida = "Vapore"
                    Stile = Drawing2D.DashStyle.Solid
                    Grafico.Inizializza(yTop, yBot, tRight, tLeft, Titx, Tity, Tit, Picture1)
                    Grafico.DisCurva(X, Y, 1, n, Dida, Stile)
                    For i = 1 To n
                        Y(i) = .DefaultView(i - 1)("Cspecl")
                    Next
                    Dida = "Liquido"
                    Stile = Drawing2D.DashStyle.DashDot
                    Grafico.DisCurva(X, Y, 1, n, Dida, Stile)
                Case 6 ' "Conducibilità"
                    yMax = -10000000000.0# : yMin = 10000000000.0#
                    For i = 1 To n
                        Y(i) = .DefaultView(i - 1)("kvap")
                        If Y(i) > yMax Then yMax = Y(i)
                        If Y(i) < yMin Then yMin = Y(i)
                        If .DefaultView(i - 1)("kLiq") > yMax Then yMax = .DefaultView(i - 1)("kLiq")
                        If .DefaultView(i - 1)("kLiq") < yMin Then yMin = .DefaultView(i - 1)("kLiq")
                    Next
                    yTop = yMax : yBot = yMin
                    Tity = "Conducibilità"
                    Dida = "Vapore"
                    Stile = Drawing2D.DashStyle.Solid
                    Grafico.Inizializza(yTop, yBot, tRight, tLeft, Titx, Tity, Tit, Picture1)
                    Grafico.DisCurva(X, Y, 1, n, Dida, Stile)
                    For i = 1 To n
                        Y(i) = .DefaultView(i - 1)("kLiq")
                    Next
                    Dida = "Liquido"
                    Stile = Drawing2D.DashStyle.DashDot
                    Grafico.DisCurva(X, Y, 1, n, Dida, Stile)
                Case 7 ' "Viscosità"
                    yMax = -10000000000.0# : yMin = 10000000000.0#
                    For i = 1 To n
                        Y(i) = .DefaultView(i - 1)("Visv")
                        If Y(i) > yMax Then yMax = Y(i)
                        If Y(i) < yMin Then yMin = Y(i)
                        If .DefaultView(i - 1)("Visl") > yMax Then yMax = .DefaultView(i - 1)("Visl")
                        If .DefaultView(i - 1)("Visl") < yMin Then yMin = .DefaultView(i - 1)("Visl")
                    Next
                    yTop = yMax : yBot = yMin
                    Tity = "Viscosità"
                    Dida = "Vapore"
                    Stile = Drawing2D.DashStyle.Solid
                    Grafico.Inizializza(yTop, yBot, tRight, tLeft, Titx, Tity, Tit, Picture1)
                    Grafico.DisCurva(X, Y, 1, n, Dida, Stile)
                    For i = 1 To n
                        Y(i) = .DefaultView(i - 1)("Visl")
                    Next
                    Dida = "Liquido"
                    Stile = Drawing2D.DashStyle.DashDot
                    Grafico.DisCurva(X, Y, 1, n, Dida, Stile)
            End Select
        End With
        Putzone()
    End Sub
    Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
        Adapter.Update(t)
        OK = True
        Grafico = Nothing
        Salva()
        Adapter.Connection.Close()
        Hide()
    End Sub
	
	Private Sub Command1_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles Command1.MouseMove
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		PictHelp.Visible = False
	End Sub
    Private Sub Command2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command2.Click
        OK = False
        Grafico = Nothing
        Adapter.Connection.Close()
        Hide()
    End Sub
    Private Sub Command2_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles Command2.MouseMove
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        PictHelp.Visible = False
    End Sub
    Private Sub frmDB_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
        DBGrid1.AllowUserToAddRows = AddRigaCurva
        DBGrid1.AllowUserToDeleteRows = AddRigaCurva
    End Sub
	Private Sub frmDB_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        'TODO: questa riga di codice carica i dati nella tabella 'dsCondCurva.CondCurva'. È possibile spostarla o rimuoverla se necessario.
        Me.CondCurvaTableAdapter.Fill(Me.dsCondCurva.CondCurva)
        Dim SQL As String
		If DaIsa > 0 Then FileDataBase = RadiceISA & ".MDB"
        CreaDB(False)
        Adapter.Connection.Close()
        Connection = New OleDb.OleDbConnection(Conn & FileDataBase & ";Persist Security Info=True")
        If ProblWLD.iCode = 36 Or DaIsa > 0 Then
            SQL = "SELECT * FROM CondCurva ORDER BY y DESC,T DESC"
        Else
            SQL = "SELECT * FROM CondCurva ORDER BY y ASC,T ASC"
        End If
        cmd = New OleDb.OleDbDataAdapter(SQL, Connection)
        cmd.Fill(dsCondCurva)
        If Not Rinfresca() Then
            Exit Sub
        End If
		Combo1.Items.Add("Nessuna")
		Combo1.Items.Add("Pressione")
		Combo1.Items.Add("Entalpie")
		Combo1.Items.Add("Titoli")
		Combo1.Items.Add("Densità")
		Combo1.Items.Add("Calori specifici")
		Combo1.Items.Add("Conducibilità")
		Combo1.Items.Add("Viscosità")
		Grafico = New RoutBase1.clsGrafico
		Grafico.Motore = Monitor.Motore
		pictWidth = VB6.PixelsToTwipsX(Picture1.ClientRectangle.Width)
		pictHeight = VB6.PixelsToTwipsY(Picture1.ClientRectangle.Height)
		Combo1.SelectedIndex = 2
		'Rinfresca
	End Sub
	
	Private Sub frmDB_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseMove
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		PictHelp.Visible = False
	End Sub
	
    Private Sub Picture1_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs)
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = eventArgs.X
        Dim Y As Single = eventArgs.Y
        Dim Dom(1) As String
        Dim Risp(1) As String
        Dim Archiv(1) As Short
        Dim dAiu(1) As String
        Dim t As Single
        If EditZone > 0 And EditZone < ProblWLD.NZONE Then
            Dom(1) = "Temperatura uscita zona" & Str(EditZone)
            Risp(1) = Funzioni.myStr(ProblWLD.Tzone(EditZone), 3, 2, False)
            PictHelp.Visible = False
            With Monitor.Motore
                If Not .InputDati(1, "Dati di zona", Dom, Risp, "", Archiv, dAiu, , X, Y) Then Exit Sub
            End With
            t = Val(Risp(1))
            If t >= ProblWLD.Tzone(EditZone - 1) Or t <= ProblWLD.Tzone(EditZone + 1) Then
                Beep()
            Else
                ProblWLD.Tzone(EditZone) = t
                Combo1_SelectedIndexChanged(Combo1, New System.EventArgs())
            End If
        End If
    End Sub
	
    Private Sub Picture1_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs)
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Dim i As Short
        Dim DT As Single
        Dim Testo As String = ""
        Dim DT1, DT2 As Single
        If ProblWLD.NZONE = 0 Then Exit Sub
        EditZone = -1
        For i = 0 To ProblWLD.NZONE
            If i = 0 Then
                DT = ProblWLD.Tzone(1) - ProblWLD.Tzone(0)
            ElseIf i < ProblWLD.NZONE Then
                DT1 = System.Math.Abs(ProblWLD.Tzone(i) - ProblWLD.Tzone(i - 1))
                DT2 = System.Math.Abs(ProblWLD.Tzone(i + 1) - ProblWLD.Tzone(i))
                DT = DT1 : If DT2 < DT Then DT = DT2
            Else
                DT = ProblWLD.Tzone(i) - ProblWLD.Tzone(i - 1)
            End If
            If System.Math.Abs(X - ProblWLD.Tzone(i)) < System.Math.Abs(DT) / 4 Then
                EditZone = i
                If i = 0 Then
                    Testo = "T in" & vbCrLf & "z.n° 1" & vbCrLf & Str(ProblWLD.Tzone(i)) & "°"
                Else
                    Testo = "T out" & vbCrLf & "z.n°" & Str(i) & vbCrLf & Str(ProblWLD.Tzone(i)) & "°"
                End If
            End If
        Next
        If Testo = "" Then PictHelp.Visible = False : Exit Sub
        cDummy.Top = VB6.TwipsToPixelsY(Y)
        cDummy.Left = VB6.TwipsToPixelsX(X)
        Routines.DisplayHelp(PictHelp, Me.Picture1, Testo, 0, 0, True)
    End Sub
    Private Function Rinfresca() As Boolean
        Dim c As DataGridViewColumn 'MSDataGridLib.Column
        Dim i, l As Short
        'Dim PrimaV As Boolean
        ' Data1.Refresh()
        Rinfresca = True
        ' If Data1.Recordset.RecordCount = 0 Then
        ' Data1.Recordset.AddNew()
        ' Data1.Recordset.Update()
        ' End If
        ' DBGrid1.ClearFields()
        ' DBGrid1.ReBind()
        For i = DBGrid1.Columns.Count - 1 To 0 Step -1
            c = DBGrid1.Columns(i)
            'c.Width = VB6.TwipsToPixelsX(700)
            Select Case i 'c.ColIndex
                Case 0
                    c.Visible = False
                Case 1
                    c.Width = VB6.TwipsToPixelsX(400)
                Case 2 'T
                    'c.NumberFormat = "Standard"
                    Select Case ProblWLD.iUnit
                        Case 2
                            c.HeaderText = "T" & vbCrLf & "[°F]"
                        Case Else
                            c.HeaderText = "T" & vbCrLf & "[°C]"
                    End Select
                Case 3 'P
                    If DaIsa = 2 Then
                        c.Visible = False
                    Else
                        '  c.NumberFormat = "####.00"
                        Select Case ProblWLD.iUnit
                            Case 1
                                If ProblWLD.iAbs = 0 Then
                                    c.HeaderText = "P" & vbCrLf & "[ate]"
                                Else
                                    c.HeaderText = "P" & vbCrLf & "[ata]"
                                End If
                            Case 2
                                If ProblWLD.iAbs = 0 Then
                                    c.HeaderText = "P" & vbCrLf & "[psig]"
                                Else
                                    c.HeaderText = "P" & vbCrLf & "[psia]"
                                End If
                            Case 3
                                If ProblWLD.iAbs = 0 Then
                                    c.HeaderText = "P" & vbCrLf & "[bar e]"
                                Else
                                    c.HeaderText = "P" & vbCrLf & "[bar]"
                                End If
                        End Select
                    End If
                Case 4, 5 'x,y
                    ' c.NumberFormat = "0.0000"
                    If DaIsa = 1 And Monitor.Ogg.TipCalc = 2 And i = 4 Then c.Visible = False
                    If DaIsa = 2 And i = 4 Then c.Visible = False
                Case 6 'Htot Hliq, Hvap
                    ' c.NumberFormat = "####.00"
                    l = InStr(c.HeaderText, "[")
                    If l > 0 Then c.HeaderText = VB.Left(c.HeaderText, l - 1)
                    Select Case ProblWLD.iPond
                        Case 0
                            Select Case ProblWLD.iUnit
                                Case 1
                                    c.HeaderText = c.HeaderText & vbCrLf & "[Cal/mol]"
                                Case 2
                                    c.HeaderText = c.HeaderText & vbCrLf & "[BTU/mol]"
                                Case 3
                                    c.HeaderText = c.HeaderText & vbCrLf & "[kJ/mol]"
                            End Select
                        Case 1
                            Select Case ProblWLD.iUnit
                                Case 1
                                    c.HeaderText = c.HeaderText & vbCrLf & "[Cal/kg]"
                                Case 2
                                    c.HeaderText = c.HeaderText & vbCrLf & "[BTU/lb]"
                                Case 3
                                    c.HeaderText = c.HeaderText & vbCrLf & "[kJ/kg]"
                            End Select
                    End Select
                Case 7, 8
                    If DaIsa = 2 Then
                        c.Visible = False
                    Else
                        ' c.NumberFormat = "####.00"
                        l = InStr(c.HeaderText, "[")
                        If l > 0 Then c.HeaderText = VB.Left(c.HeaderText, l - 1)
                        Select Case ProblWLD.iUnit
                            Case 1
                                c.HeaderText = c.HeaderText & vbCrLf & "[Cal/kg]"
                            Case 2
                                c.HeaderText = c.HeaderText & vbCrLf & "[BTU/lb]"
                            Case 3
                                c.HeaderText = c.HeaderText & vbCrLf & "[kJ/kg]"
                        End Select
                    End If
                Case 9 To 11 'Mtot,Mliq,Mvap
                    ' c.NumberFormat = "###.00"
                    If DaIsa = 1 And Monitor.Ogg.TipCalc = 2 And i < 11 Then c.Visible = False
                    If DaIsa = 2 And i < 11 Then c.Visible = False
                Case 12 'densl
                    'c.NumberFormat = "##.0000"
                    c.HeaderText = c.HeaderText & vbCrLf & "[--]"
                Case 13 'densv
                    'c.NumberFormat = "####.000"
                    l = InStr(c.HeaderText, "[")
                    If l > 0 Then c.HeaderText = VB.Left(c.HeaderText, l - 1)
                    Select Case ProblWLD.iUnit
                        Case 1, 3
                            c.HeaderText = c.HeaderText & vbCrLf & "[kg/m3]"
                        Case 2
                            c.HeaderText = c.HeaderText & vbCrLf & "[lb/ft3]"
                    End Select
                    If DaIsa = 1 And Monitor.Ogg.TipCalc = 2 Then c.Visible = False
                    If DaIsa = 2 Then c.Visible = False
                Case 14 'calore specifico liq
                    If DaIsa = 2 Then
                        'c.NumberFormat = "####.0000"
                        Select Case ProblWLD.iUnit
                            Case 1
                                c.HeaderText = "Cp liq" & vbCrLf & "[Cal/kg°C]"
                            Case 2
                                c.HeaderText = "Cp liq" & vbCrLf & "[BTU/lb°F]"
                            Case 3
                                c.HeaderText = "Cp liq" & vbCrLf & "[kJ/kg°C]"
                        End Select
                        c.Width = VB6.TwipsToPixelsX(800)
                    Else
                        c.Visible = False
                    End If
                Case 15 'calore specifico vap
                    'c.NumberFormat = "####.0000"
                    Select Case ProblWLD.iUnit
                        Case 1
                            c.HeaderText = "Cp vap" & vbCrLf & "[Cal/kg°C]"
                        Case 2
                            c.HeaderText = "Cp vap" & vbCrLf & "[BTU/lb°F]"
                        Case 3
                            c.HeaderText = "Cp vap" & vbCrLf & "[kJ/kg°C]"
                    End Select
                    c.Width = VB6.TwipsToPixelsX(800)
                Case 16, 17 'viscosità
                    c.Width = VB6.TwipsToPixelsX(900)
                    'c.NumberFormat = "0.000E+00"
                    l = InStr(c.HeaderText, "[")
                    If l > 0 Then c.HeaderText = VB.Left(c.HeaderText, l - 1)
                    Select Case ProblWLD.iUnit
                        Case 1, 2
                            c.HeaderText = c.HeaderText & vbCrLf & "[cp]"
                        Case 3
                            c.HeaderText = c.HeaderText & vbCrLf & "[kg/m.sec]"
                    End Select
                Case 18, 19 'conducibilità
                    'c.NumberFormat = "####.000"
                    l = InStr(c.HeaderText, "[")
                    If l > 0 Then c.HeaderText = VB.Left(c.HeaderText, l - 1)
                    Select Case ProblWLD.iUnit
                        Case 1
                            c.HeaderText = c.HeaderText & vbCrLf & "[Cal/m.hr°C]"
                        Case 2
                            c.HeaderText = c.HeaderText & vbCrLf & "[BTU/ft.hr°F]"
                        Case 3
                            c.HeaderText = c.HeaderText & vbCrLf & "[w/m°C]"
                    End Select
                Case 20
                    c.Visible = False
                Case 21 'comprim.
                    'c.NumberFormat = "#.00000"
                Case 22 'entalpia acqua liquida
                    If DaIsa = 2 Then
                        c.Visible = False
                    Else
                        'c.NumberFormat = "####.00"
                        Select Case ProblWLD.iUnit
                            Case 1
                                c.HeaderText = "HliqW" & vbCrLf & "[Cal/kg]"
                            Case 2
                                c.HeaderText = "HliqW" & vbCrLf & "[BTU/lb]"
                            Case 3
                                c.HeaderText = "HliqW" & vbCrLf & "[kJ/kg]"
                        End Select
                    End If
                Case 23 'frazioni acqua liquida
                    'c.NumberFormat = "0.0000"
                    c.HeaderText = "mol liqW"
                    If DaIsa = 1 And Monitor.Ogg.TipCalc = 2 Then c.Visible = False
                    If DaIsa = 2 Then c.Visible = False
                Case 24 'frazioni acqua liquida
                    'c.NumberFormat = "0.0000"
                    c.HeaderText = "mass liqW"
                    If DaIsa = 2 Then c.Visible = False
            End Select
            c.Resizable = False
        Next
        '		PrimaV = DBGrid1.Splits.Count = 1
        '		If PrimaV Then DBGrid1.Splits.Add(1)
        '        If PrimaV Then
        'DBGrid1.Splits(0).Size = 1
        'DBGrid1.Splits(1).Size = 3
        'DBGrid1.Splits(0).Columns(0).Visible = False
        'For i = 1 To DBGrid1.Columns.Count - 1
        ' If i > 3 Then
        ' c = DBGrid1.Splits(0).Columns(i)
        ' c.Visible = False
        ' Else
        ' c = DBGrid1.Splits(1).Columns(i)
        ' c.Visible = False
        ' End If
        ' Next
        ' End If
    End Function

    Private Sub DBGrid1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DBGrid1.MouseMove
        PictHelp.Visible = False
    End Sub
End Class