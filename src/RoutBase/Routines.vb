Option Strict On
Option Explicit On
Imports System.Windows.Forms
Imports System.IO
Imports System.Drawing.Drawing2D
Public Class Routines
    '1     3     3    #.####   #
    '2     4   ###
    '3     ##.#######^^^^ ##.#######^^^^
    '4    22    12    C:##.#######^^^^##.#######^^^^    R=##.#######^^^^
    '5                P:##.#######^^^^##.#######^^^^    A=##.#######^^^^
    '6     5     8    O:##.#######^^^^##.#######^^^^    L=##.#######^^^^    NC=##
    '7 >&
    '8     8     9    H=##.#######^^^^    E=##.#######^^^^    A=##.#######^^^^
    '9                I=##.#######^^^^    P=##
    Private Fx, Fy As Single
    Public mioFx, mioFy As Single
    Private ht, et As Single
    Private x1, x0, y0, y1 As Single
    Private x2, y2 As Single
    Private CarHeight, CarWidth, Alfa As Single
    Private File1 As String ', obj As Object 'AutoCad.AcadDocument
    Private genFtesta As String
    Private Ac2000 As Boolean
    Private ProgText As Integer
    Private Penna As Pen
    Private Pennello As SolidBrush
    Public SwIUNpri As Short
    Private iunit, iunits As StreamWriter
    Private Dove As PictureBox
    Private gDove As Drawing.Graphics 'della bitmap
    Private gDovePic As Drawing.Graphics 'della Picturebox
    Private bm As Bitmap
    Public SH, SW As Single
    Public ymin, xmin, xmax, ymax As Single
    Public AcadBlock As AutoCAD.AcadBlock
    Public AcadDoc As AutoCAD.AcadDocument
    Public AcadApp As AutoCAD.AcadApplication
    Public StubWord As StubW2000.clsSW2000 'WordDoc   As Word.Document 'AutoCad.AcadDocument
    Private BlockRef As AutoCAD.AcadBlockReference
    Private Strato As AutoCAD.AcadLayer
    Private xcoor() As Single
    Private ycoor() As Single
    Private Strtp() As String
    Private NPU As Integer
    Private tipli, Layer As String
    Private Ncolo As Short
    Private tipolinea As Short
    Private hquo As Single 'altezza caratteri quote in mm carta
    Private Spessore As Single
    Private ch As String
    Private alfz, orx, ory, ScalStrim As Single
    Private NPUMAX As Integer
    Private IUNL As Short
    Private n(7) As Short
    Private M(7) As Short
    Private acastri(50, 2) As String
    Private offxWin, ScalaWinx, ScalaWiny, offyWin As Single
    Public Sub Freccia(ByVal X As Single, ByVal y As Single)
        tratto(X, y, X - 4, y + 3, 0.1, 0)
        tratto(X, y, X - 4, y - 3, 0.1, 0)
        tratto(X - 4, y - 3, X - 3, y, 0.1, 0)
        tratto(X - 3, y, X - 4, y + 3, 0.1, 0)
    End Sub
    Public Sub Init200(ByVal Arch As String)
        Dim ifl, i As Short
        Archdir = Arch
1120:   ReDim xcoor(NPUMAX)
        ReDim ycoor(NPUMAX)
        ReDim Strtp(9)
        ifl = CShort(FreeFile())
        FileOpen(ifl, RTrim(Archdir) & "\STRI04.DAT", OpenMode.Input, , OpenShare.Shared)
        For i = 1 To 9 : Strtp(i) = LineInput(ifl) : Next
        FileClose(ifl)
        NPU = 0
        'If iunit = 0 Then iunit = FreeFile
        n(1) = 2 : M(1) = 4
        n(2) = 6 : M(2) = 8
        n(3) = 3 : M(3) = 7
        n(4) = 3 : M(4) = 9
        n(5) = 3 : M(5) = 10
        n(6) = 7 : M(6) = 11
        n(7) = 7 : M(7) = 12
    End Sub
    Public Sub coda()
        Dim ifl As Short
        Dim Riga As String
        'fine file output
        Select Case SwIUNpri
            Case 1
                iunit.WriteLine("    21     0")
            Case 2
                Select Case genFtesta
                    Case "TESDXF2.DXF"
                        ifl = CShort(FreeFile())
                        FileOpen(ifl, RTrim(Archdir) & "\CODDXF2.DXF", OpenMode.Input, , OpenShare.Shared)
                        Do
                            Riga = LineInput(ifl)
                            If Val(Riga) = -999 Then Exit Do
                            iunit.WriteLine(Riga)
                        Loop Until EOF(ifl)
                        FileClose(ifl)
                    Case Else
                        iunit.WriteLine("ENDSEC")
                        iunit.WriteLine(0)
                        iunit.WriteLine("EOF")
                End Select
            Case 3
                On Error Resume Next
                AcadApp.ActiveDocument.Save()
            Case 4
                iunit.WriteLine("}")
            Case 6
                '                StubWord.save()
        End Select
    End Sub
    Sub HCOTE(ByVal thk As Single)
        hquo = thk
    End Sub
    Sub tiplin(ByVal SP As Single, ByVal nli As Short)
        If Penna Is Nothing Then Penna = New Pen(Color.Black)
        If Pennello Is Nothing Then Pennello = New SolidBrush(Color.Black)
        If Spessore <> SP Or tipolinea <> nli Then
            Spessore = SP : tipolinea = nli
            Penna.Width = -1 ' Spessore
            If tipolinea = 0 Then tipolinea = 5
            Penna.DashStyle = ConvertDash(tipolinea)
            Select Case SwIUNpri
                Case 1
                    iunit.WriteLine(Trigon.FormatS(Strtp(1), SP / 10, nli))
                Case 2
                    Ncolo = colora(SP, Layer)
                Case 3
            End Select
        End If
    End Sub
    Sub testa(ByVal Ftesta As String)
        'testata fissa
        Dim j, ifl, js As Short
        Dim Riga As String
        Dim i As Short
        Dim l As AutoCAD.AcadLayer
        ifl = CShort(FreeFile())
        Select Case SwIUNpri
            Case 1
                If Len(Ftesta) = 0 Then Ftesta = "STRI01.DAT"
                FileOpen(ifl, RTrim(Archdir) & "\" & Ftesta, OpenMode.Input, , OpenShare.Shared)
                iunit.WriteLine("")
                Do
                    If EOF(ifl) Then Exit Do
                    Riga = LineInput(ifl)
                    If Len(Riga) = 0 Then Exit Do
                    iunit.WriteLine(Riga)
                Loop
                FileClose(ifl)
                'PRINT #IUNIT, " /////INIT//////---TITRE----/"
                'PRINT #IUNIT, "     1     6    descrizione"
                'PRINT #IUNIT, " ///////////////////////////"
                'PRINT #IUNIT, "    11     4    0.3396307E+02  0.4707377E+02"
                'PRINT #IUNIT, "     2     1    1"
                'PRINT #IUNIT, "     3     3    0.0400   0"
            Case 2
300:            FileOpen(ifl, RTrim(Archdir) & "\exch.cad", OpenMode.Input, , OpenShare.Shared)
                For j = 1 To 6 : Riga = LineInput(ifl) : Next
                js = 3
                Do
                    Riga = LineInput(ifl)
                    If Riga <> "" Then
                        js = CShort(js + 1)
                        acastri(js, 1) = RTrim(LTrim(Mid(Riga, 1, 7)))
                        acastri(js, 2) = RTrim(LTrim(Mid(Riga, 10, 7)))
                    End If
                Loop Until EOF(ifl)
                FileClose(ifl)
                acastri(1, 1) = "ø" : acastri(1, 2) = "@"
                acastri(2, 1) = "ñ" : acastri(2, 2) = "#"
                acastri(3, 1) = "í" : acastri(3, 2) = "$"
                'acastri(4, 1) = "%127": acastri(4, 2) = "@"
                'acastri(5, 1) = "%%248": acastri(5, 2) = "@"
                'acastri(6, 1) = "%%241": acastri(6, 2) = "#"
                'acastri(7, 1) = "„µ^N": acastri(7, 2) = ""
                If Len(Ftesta) = 0 Then
                    Ftesta = "TESDXF1.DXF"
                    genFtesta = Ftesta
                End If
                Ac2000 = InStr(Ftesta, "2") > 0
                ProgText = 47
                FileOpen(ifl, RTrim(Archdir) & "\" & Ftesta, OpenMode.Input, , OpenShare.Shared)
                Do
                    Riga = LineInput(ifl)
                    If Val(Riga) = -999 Then Exit Do
                    iunit.WriteLine(Riga)
                Loop Until EOF(ifl)
                FileClose(ifl)
                '    Print #iunit, 0
                '    Print #iunit, "SECTION"
                '    Print #iunit, 2
                '    Print #iunit, "ENTITIES"
                '    Print #iunit, 0
                tipli = "CONTINUOUS"
                Spessore = 0.1
                Ncolo = colora(Spessore, Layer)
            Case 3
                Strato = AcadDoc.ActiveLayer
                If Not Strato.Name = "0" Then
                    Strato = AcadDoc.Layers.Add("0")
                    AcadDoc.ActiveLayer = Strato
                End If
                For i = 1 To 6
                    For Each l In AcadDoc.Layers
                        If l.Name = Trim(Str(i)) Then GoTo Cont
                    Next l
                    AcadDoc.Layers.Add(Trim(Str(i)))
Cont:
                Next
            Case 4
                FileOpen(ifl, Trim(Archdir) & "\HEADER.RTF", OpenMode.Input, , OpenShare.Shared)
                Do
                    If EOF(ifl) Then Exit Do
                    Riga = LineInput(ifl)
                    i = CShort(Riga.IndexOf("company"))
                    If i > 0 Then
                        iunit.WriteLine(Riga.Substring(0, i + 2))
                        iunit.WriteLine(gInizio.Firma)
                        iunit.WriteLine(Riga.Substring(i + 4, Riga.Length - i - 4))
                    Else
                        iunit.WriteLine(Riga)
                    End If
                Loop
                FileClose(ifl)
                iunit.WriteLine("\pard \s28\widctlpar\tx4820 ")
            Case 6
                StubWord.VaiInizio()
        End Select
    End Sub
    Sub Scambia()
        Trigon.SWAP(iunit, iunits)
    End Sub
    Public Function ApriPri(ByVal File As String, ByVal Ext As String, ByVal Mode As Short, _
    ByVal Tipo As Short, ByVal Ftesta As String, Optional ByVal lAcadApp As AutoCAD.AcadDocument = Nothing, _
    Optional ByVal Silent As Boolean = False, Optional ByVal iout As StreamWriter = Nothing) As Short
        Dim Res As Short
        Dim Dis As AutoCAD.AcadDocument
        'Mode 0 nuovo, 1 aggiunta
        'Tipo 1 .PRI, 2 .DXF,3 .DWG
        genFtesta = Ftesta
        If Len(Ext) > 0 Then File1 = File & "." & Ext Else File1 = File
        SwIUNpri = Tipo
        If Mode = 0 Then
            On Error GoTo ErrAP
            Select Case SwIUNpri
                Case 3
                    Res = gInizio.LanciaAutoCAD(lAcadApp, 1, Silent)
                    If Res > 0 Then
                        ApriPri = Res
                        Exit Function
                    End If
                    AcadApp = lAcadApp.Application 'lAcadApp
                    For Each Dis In AcadApp.Documents
                        If Dis.FullName = File1 Then
                            Dis.Close()
                            If AcadApp.Documents.Count = 0 Then
                                lAcadApp = AcadApp.Documents.Add
                            Else
                                lAcadApp = AcadApp.ActiveDocument
                            End If
                            Exit For
                        End If
                    Next Dis
                    AcadDoc.SaveAs(File1)
                Case 6
                    gInizio.SuperStampa(File1, CType(lAcadApp, StubW2000.clsSW2000))
                    If lAcadApp Is Nothing Then Exit Function
                    StubWord = CType(lAcadApp, StubW2000.clsSW2000)
                Case Else
                    iunit = IO.File.CreateText(File1)
            End Select
            On Error GoTo 0
            testa(Ftesta)
        Else
            Select Case SwIUNpri
                Case 3
                    MsgBox("Da fare in ApriPRI")
                Case Else
                    If Not iout Is Nothing Then
                        iunit = New StreamWriter(iout.BaseStream)
                        iunit.BaseStream.Seek(0, SeekOrigin.End)
                    ElseIf iunit Is Nothing Then
                        iunit = IO.File.CreateText(File1)
                    Else
                        iunits = IO.File.CreateText(File1)
                        Scambia()
                    End If
                    iunit.WriteLine("{")
            End Select
        End If
ExAP:   On Error GoTo 0
        Exit Function
ErrAP:  If Err.Number = 70 Or Err.Number = 55 Then
            If MsgBox("Accesso negato al file " & File1 & ". Verificare se esso è in uso presso Winword o AutoCAD", CType(MsgBoxStyle.Exclamation + MsgBoxStyle.RetryCancel, MsgBoxStyle)) = MsgBoxResult.Retry Then
                Resume
            Else
                Resume ExAP
            End If
        Else
            MsgBox(Err.Description)
        End If
    End Function
    Sub segmes(ByVal x0() As Single, ByVal y0() As Single, ByVal nst As Short, ByVal ns As Short, ByVal SP As Single, ByVal nli As Short)
        Dim j As Short
        Dim polilinea As AutoCAD.AcadPolyline
        Dim vertList() As Double
        If SP > 0 Then tiplin(SP, nli)
        For j = nst To ns
            rotate(x0(j), y0(j))
            If j > nst Then
                gDove.DrawLine(Penna, x0(j - 1) / mioFx, y0(j - 1) / mioFy, x0(j) / mioFx, y0(j) / mioFy)
            End If
        Next
        Select Case SwIUNpri
            Case 1
                iunit.WriteLine(Trigon.FormatS(Strtp(2), (ns - nst + 1) * 4))
                For j = nst To ns
                    iunit.WriteLine(Trigon.FormatS(Strtp(3), x0(j) / mioFx / 10, y0(j) / mioFy / 10))
                Next
            Case 2
                For j = CShort(nst + 1) To ns
                    LineaDXF(x0(j - 1), y0(j - 1), x0(j), y0(j))
                Next
            Case 3
                ReDim vertList(3 * (ns - nst + 1) - 1)
                For j = nst To ns
                    vertList(3 * (j - nst)) = x0(j) / mioFx : vertList(3 * (j - nst) + 1) = y0(j) / mioFy
                Next
                polilinea = AcadBlock.AddPolyline(vertList)
        End Select
    End Sub
    Sub texts(ByVal xo As Single, ByVal yo As Single, ByVal txt As String, ByVal ht As Single, ByVal alf As Single, ByVal SP As Single)
        Dim et, Alfa As Single
        Dim Testo As AutoCAD.AcadText
        Dim inspoint(2) As Double ', s As Word.Shape
        If SP > 0 Then tiplin(SP, 0)
        Select Case SwIUNpri
            Case 1
                iunit.WriteLine(Trigon.FormatS(Strtp(8), ht / 10, SP * 0.01, alf))
                iunit.WriteLine(Trigon.FormatS(Strtp(9), 0, 1))
                iunit.WriteLine(Trigon.FormatS(Strtp(6), xo / mioFx / 10, yo / mioFy / 10 - 1.5 * ht / 10, 11, Len(txt)))
                iunit.WriteLine(Trigon.FormatS(Strtp(7), txt))
            Case 2
                et = SP ' et = Val(Mid$(record, 39, 14)) * 10
                Alfa = CSng(alf * 180 / Math.PI)
                TextDXF(xo, yo, ht, txt, Alfa)
            Case 3
                inspoint(0) = xo / mioFx
                inspoint(1) = yo / mioFy
                Testo = AcadBlock.AddText(txt, inspoint, ht)
                Testo.Rotation = alf
            Case 6
                StubWord.AggiungiCasella(xo / mioFx, yo / mioFy, txt)
        End Select
        Dim m As Matrix = New Matrix(1, 0, 0, -1, 0, 2 * yo)
        Dim hTesto As Single = CSng(Math.Abs(gDove.MeasureString(txt, Dove.Font).Height) / Fy)
        m.RotateAt(CSng(alf * 180 / Math.PI), New PointF(xo, yo), MatrixOrder.Append)
        m.Translate(0, CSng(-1.2 * hTesto * Math.Sin(alf)))
        gDove.MultiplyTransform(m)
        gDove.DrawString(txt, Dove.Font, Pennello, xo / mioFx, yo / mioFy)
        m.Invert()
        gDove.MultiplyTransform(m)
    End Sub
    Function arc(ByVal xa As Single, ByVal ya As Single, ByVal xb As Single, ByVal yb As Single, ByVal Beta As Single) As Object
        Dim x1, xc, yc, y1 As Single
        Dim R, xr, yr, gama As Single
        Dim sgy, sgx, alx As Single
        Dim Alfap, Alfaa, delta As Single
        Dim arcoA As AutoCAD.AcadArc
        Dim inspoint(2) As Double
        arc = 0
        On Error GoTo ErrArc
        xc = xa / mioFx : yc = ya / mioFy : x1 = xb / mioFx : y1 = yb / mioFy
        xr = Math.Abs(x1 - xc)
        yr = Math.Abs(y1 - yc)
        R = CSng(Math.Sqrt(xr ^ 2 + yr ^ 2))
        rotate(xc, yc)
        rotate(x1, y1)
        gama = CSng(Beta * Math.PI / 180)
        If Math.Abs(Beta) >= 359.9 Then
            Alfap = 0 : Alfaa = 359.99 : GoTo 123
        End If
        sgx = Math.Sign(x1 - xc)
        sgy = Math.Sign(y1 - yc)
        alx = CSng(Math.Asin(Math.Abs(y1 - yc) / R) * 180 / Math.PI)
        Alfap = polare(sgx, sgy, alx)
        Alfaa = Beta + Alfap
        If Alfaa < 0 Then Alfaa = 360 + Alfaa
        If Alfaa > 360 Then Alfaa = Alfaa - 360
        If Alfap < 0 Then Alfap = 360 + Alfap
        If Alfap > 360 Then Alfap = Alfap - 360
        '-----------------------------------------
123:    delta = Alfaa - Alfap : If delta < 0 Then delta = delta + 360
        If delta - Math.Abs(Beta) > 1 Then Trigon.SWAP(Alfaa, Alfap)
        If IUNL < 3 Then
            If Math.Abs(Math.Abs(Alfaa - Alfap) - 360) < 1 Then
                gDove.DrawEllipse(Penna, xc - R, yc - R, 2 * R, 2 * R) ' mycol(tipli))
            Else
                gDove.DrawArc(Penna, xc - R, yc - R, 2 * R, 2 * R, Alfap, Alfaa)
            End If
        End If
        Select Case SwIUNpri '22
            Case 1
                iunit.WriteLine(Trigon.FormatS(Strtp(4), xc / 10, yc / 10, R / 10))
                iunit.WriteLine(Trigon.FormatS(Strtp(5), x1 / 10, y1 / 10, gama))
            Case 2
                Alfaa = CSng(gama * 180 / Math.PI)
                ArcDXF(xc, yc, R, x1, y1, Alfaa)
            Case 3
                inspoint(0) = xc
                inspoint(1) = yc
                arcoA = AcadBlock.AddArc(inspoint, R, Alfap * Math.PI / 180, Alfaa * Math.PI / 180)
        End Select
Exarc:  On Error GoTo 0
        Exit Function
ErrArc: If Err.Number = 6 Or Err.Number = 11 Then
            Resume Exarc
        Else
            arc = Err.Number 'MsgBox Error + " in arc"
            Resume Exarc
        End If
    End Function
    Sub ctrait(ByVal ltipo As Short, ByVal Spess As Single)
        Dim ifl, i As Short
        If Spessore <> Spess Or tipolinea <> ltipo Then
            Spessore = Spess : tipolinea = ltipo
            Select Case SwIUNpri
                Case 1
                    iunit.WriteLine(Trigon.FormatS(Strtp(1), Spess / 10, ltipo))
                    ifl = CShort(FreeFile())
                    FileOpen(ifl, RTrim(Archdir) & "\STRI02.DAT", OpenMode.Input, , OpenShare.Shared)
                    For i = 0 To ltipo
                        Input(ifl, tipli)
                    Next
                    FileClose(ifl)
                    '                SELECT CASE ltipo
                    '                       CASE 0, 5:   tipli = "0CONTINUOUS"
                    '                       CASE 1:      tipli = "6DOT"
                    '                       CASE 2:      tipli = "4CENTER"
                    '                       CASE 3:      tipli = "6DASHED"
                    '                       CASE 4:      tipli = "1DASHED"
                    '                       CASE 6:      tipli = "2CONTINUOUS"
                    '                       CASE 7:      tipli = "1PHANTOM"
                    '                END SELECT
                Case 3 'Autocad
                    Select Case ltipo
                        Case 0, 5, 6
                            If Not LineaContinua Is Nothing Then AcadDoc.ActiveLinetype = LineaContinua
                        Case 2
                            If Not TrattPunto Is Nothing Then AcadDoc.ActiveLinetype = TrattPunto
                        Case 3, 4
                            If Not LineaNascosta Is Nothing Then AcadDoc.ActiveLinetype = LineaNascosta
                    End Select
                Case 2, 4
                    Select Case ltipo
                        Case 0, 5, 6 : tipli = "CONTINUOUS"
                        Case 1 : tipli = "DOT"
                        Case 2 : tipli = "CENTER"
                        Case 3 : tipli = "DASHED2"
                        Case 4 : tipli = "DASHED"
                        Case 7 : tipli = "PHANTOM"
                    End Select
            End Select
        End If
        Ncolo = colora(Spess, Layer)
        If Penna Is Nothing Then Penna = New Pen(Color.Black)
        If Pennello Is Nothing Then Pennello = New SolidBrush(Color.Black)
        If tipolinea > 5 Then tipolinea = 0
        Penna.DashStyle = ConvertDash(tipolinea)
        Dim c As Color = Drawing.ColorTranslator.FromOle(QBColor(Ncolo))
        Penna.Color = c
    End Sub
    Private Function ConvertDash(ByVal t As Integer) As DashStyle
        Select Case t
            Case 0, 5, 6 : Return DashStyle.Solid
            Case 1 : Return DashStyle.Dot
            Case 3 : Return DashStyle.Dash
            Case 4 : Return DashStyle.DashDot
        End Select
    End Function
    Sub legpri(ByVal infil As String, ByVal exti As String)
        'On Local Error GoTo Errlegpri
        Dim ht, et As Single
        Dim tipo1, nfi, tipo2 As Short
        Dim reco As String
        Dim thk As Single
        Dim tip As Short
        Dim ifl, i As Short
        Dim txt As String
        Dim x1, y1 As Single
        Dim nvo As Short
        Dim x2, y2 As Single
        Dim nc As Short
        Dim yc, xc, R As Single
        Dim alfastrim, xo, yo, Alfa As Single
        Dim Alfap, Alfaa As Single
        Dim sgy, sgx, alx As Single
        nfi = CShort(FreeFile())
300:    FileOpen(nfi, infil & exti, OpenMode.Input)
        Do
            reco = LineInput(nfi)
            tipo1 = CShort(Val(Mid(reco, 5, 2)))
            tipo2 = CShort(Val(Mid(reco, 9, 4)))
            'if SwIUNpri then print #iUnit, reco
            Select Case tipo1
                Case 3
310:                thk = CSng(Val(Mid(reco, 17, 6)) * 10)
                    tip = CShort(Val(Mid(reco, 26, 1)))
                    ' if SwIUNpri then print #IUNIT, reco
                    ifl = CShort(FreeFile())
                    FileOpen(ifl, RTrim(Archdir) & "\STRI03.dat", OpenMode.Input, , OpenShare.Shared)
                    For i = 0 To tip
                        Input(ifl, tipli)
                    Next
                    FileClose(ifl)
                    '               SELECT CASE TIP
                    '                      CASE 0, 5, 6: tipli = "0CONTINUOUS"
                    '                      CASE 1:      tipli = "2DOT"
                    '                      CASE 2:      tipli = "1CENTER"
                    '                      CASE 3:      tipli = "5DASHED"
                    '                      CASE 4:      tipli = "5DASHED"
                    '                      CASE 7:      tipli = "5PHANTOM"
                    '               END SELECT
                Case 4
                    ' if SwIUNpri then print #IUNIT, reco
320:                reco = LineInput(nfi)
                    ' if SwIUNpri then print #IUNIT, reco
                    x1 = CSng(Val(Mid(reco, 6, 14)) * 10)
                    y1 = CSng(Val(Mid(reco, 21, 14)) * 10)
                    nvo = CShort((tipo2 / 4) - 1)
                    Do
                        reco = LineInput(nfi)
                        x2 = CSng(Val(Mid(reco, 6, 14)) * 10)
                        y2 = CSng(Val(Mid(reco, 21, 14)) * 10)
                        gDove.DrawLine(Penna, x1, y1, x2, y2)
                        nvo = CShort(nvo - 1)
                        x1 = x2 : y1 = y2
                    Loop Until nvo = 0
                Case 22
330:                xc = CSng(Val(Mid(reco, 19, 14)) * 10)
                    yc = CSng(Val(Mid(reco, 33, 14)) * 10)
                    R = CSng(Val(Mid(reco, 53, 14)) * 10)
                    reco = LineInput(nfi)
                    ' if SwIUNpri then print #IUNIT, reco
                    xo = CSng(Val(Mid(reco, 19, 14)) * 10)
                    yo = CSng(Val(Mid(reco, 33, 14)) * 10)
                    alfastrim = CSng(Val(Mid(reco, 53, 14)))
                    Alfa = CSng(alfastrim * 180 / Math.PI)
                    If Math.Abs(Alfa) >= 359.9 Then
                        Alfap = 0 : Alfaa = 359.99 : GoTo 1230
                    End If
                    sgx = Math.Sign(xo - xc)
                    sgy = Math.Sign(yo - yc)
                    alx = CSng(Math.Asin(Math.Abs(yo - yc) / R) * 180 / Math.PI)
                    Alfap = polare(sgx, sgy, alx)
                    Alfaa = Alfa + Alfap
1230:               If Alfaa > 360 Then Alfaa = Alfaa - 360
                    If alfastrim < 0 Then Trigon.SWAP(Alfap, Alfaa)
                    If Alfaa > 360 Then Alfaa = Alfaa - 360
                    If Alfap > 360 Then Alfap = Alfap - 360
                    If Alfaa < 0 Then Alfaa = Alfaa + 360
                    If Alfap < 0 Then Alfap = Alfap + 360
                    gDove.DrawArc(Penna, xc - R, yc - R, 2 * R, 2 * R, Alfap, Alfaa)
                Case 5
1240:               xo = CSng(Val(Mid(reco, 19, 14)) * 10)
                    yo = CSng(Val(Mid(reco, 33, 14)) * 10)
                    nc = CShort(Val(Mid(reco, 74, 2)))
1242:               reco = LineInput(nfi)
                    txt = Mid(reco, 3, nc)
1246:               Call ECRIR(txt)
1248:               texte0(xo, yo, Alfa, ht, et)
                Case 8
1250:               ht = CSng(Val(Mid(reco, 19, 14)) * 10)
                    et = CSng(Val(Mid(reco, 39, 14)) * 10)
                    Alfa = CSng(Val(Mid(reco, 59, 14)) * 180 / Math.PI)
                    reco = LineInput(nfi)
            End Select
        Loop Until tipo1 = 21 Or EOF(nfi)
        FileClose(nfi)
    End Sub
    Function mycol(ByVal T As String) As Integer
        Dim i As Short
        i = CShort(Val(T))
        Select Case i
            Case 0 : mycol = QBColor(0)
            Case 15 : mycol = QBColor(0)
                '   CASE 2: mycol = 4
                '   CASE 5: mycol =
                '   CASE 6: mycol = 8
            Case Else : mycol = QBColor(i)
        End Select
    End Function
    Sub polar(ByRef xx As Single, ByRef yy As Single, ByRef alo As Single)
        '     subroutine polar (alt, xx, yy, delx, dely, alo)
        '      SUBROUTINE polar(xx, yy, alo, ro)
        'alfz = angolo rotazione      xx   = x originale         yy  = y originale
        'ritorna xx ed yy attuali e alo attuale
        Dim Alfa, ro, alx As Single
        Dim igx, igy As Short
        ro = 0.0!
        Alfa = 0.0!
        If (Math.Abs(xx) <= 0.0001) Then xx = 0.0!
        If (Math.Abs(yy) <= 0.0001) Then yy = 0.0!
        If (Math.Abs(xx) < 0.0001 And Math.Abs(yy) < 0.0001) Then GoTo 600
        ro = CSng(Math.Sqrt(xx ^ 2 + yy ^ 2))
        alx = CSng(Math.Abs(Math.Asin(yy / ro)))
222:    igx = CShort(Math.Sign(xx))
        igy = CShort(Math.Sign(yy))
        If (igx = 1) Then GoTo 566
        If (igx = -1) Then GoTo 588
        GoTo 577
566:    If (igy = 1) Then
            Alfa = alx
        Else
            If (igy = -1) Then
                Alfa = CSng(2 * Math.PI - alx)
            Else
                Alfa = 0
            End If
        End If
        GoTo 600
577:    If (igy = 1) Then
            Alfa = Math.PI / 2
        Else
            If (igy = -1) Then
                Alfa = CSng(3 / 2 * Math.PI)
            Else
                Alfa = 0
            End If
        End If
        GoTo 600
588:    If (igy = 1) Then
            Alfa = CSng(Math.PI - alx)
        Else
            If (igy = -1) Then
                Alfa = CSng(Math.PI + alx)
            Else
                Alfa = Math.PI
            End If
        End If
600:    alo = Alfa + alfz
        If (alo > 2 * Math.PI) Then alo = CSng(alo - 2 * Math.PI)
    End Sub
    Function polare(ByVal sgx As Single, ByVal sgy As Single, ByVal alx As Single) As Single
        Select Case sgx
            Case 1
                Select Case sgy
                    Case 1
                        polare = alx
                    Case 0
                        polare = 0
                    Case -1
                        polare = 360 - alx
                End Select
            Case 0
                Select Case sgy
                    Case 1
                        polare = 90
                    Case 0
                        polare = 0
                    Case -1
                        polare = 270
                End Select
            Case -1
                Select Case sgy
                    Case 1
                        polare = 180 - alx
                    Case 0
                        polare = 180
                    Case -1
                        polare = 180 + alx
                End Select
            Case Else : Stop
        End Select
    End Function
    Function poynt(ByVal X As Single, ByVal y As Single) As Single
        Dim pu As Single
        NPU = NPU + 1
500:    If (NPU > NPUMAX) Then
            NPUMAX = NPUMAX + 100
510:        ReDim Preserve xcoor(NPUMAX)
            ReDim Preserve ycoor(NPUMAX)
        End If
520:    xcoor(NPU) = X
        ycoor(NPU) = y
        pu = 1000000.0! + NPU * 2.0!
        poynt = pu
    End Function
    Sub ql1(ByVal p1 As Single, ByVal P2 As Single, ByVal Direzione As Short, _
     ByVal DistanzaScritta As Single, ByVal TestoQuota As String)
        '      On Local Error GoTo Errql1
        Dim X(20) As Single
        Dim y(20) As Single
        Dim yy1, xx1, Pote As Single
        Dim teori, intt As Integer
        Dim alfo, localfactor As Single
        Dim j As Short
        Dim xb, xa, ya, yb As Single
        Dim SizeArrow As Single
        Dim Spess As Single
        Dim ltipo As Short
        Dim ins1(2) As Double
        Dim ins2(2) As Double
        Dim quotTest(2) As Double
        Dim l As AutoCAD.AcadLayer
        Dim Quota As AutoCAD.AcadDimAligned
        'Direzione=1 : ORIZZONTALE    Direzione=2 : VERTICALE    Direzione=3 : OBLIQUA
        'DistanzaScritta : DIST QUOTA DA P1
        'E : BOO    
        If SwIUNpri = 2 Then Exit Sub
        Spess = Spessore : ltipo = tipolinea
        If p1 = 0 Or P2 = 0 Then Exit Sub
        SizeArrow = CSng(Math.Abs(gDove.MeasureString(TestoQuota, Dove.Font).Height) / Fy * 0.7)
        X(1) = xcoord(p1)
        y(1) = ycoord(p1)
        X(2) = xcoord(P2)
        y(2) = ycoord(P2)
        orx = X(1)
        ory = y(1)
        xx1 = X(2) - X(1)
        yy1 = y(2) - y(1)
        alfz = 0
        Pote = CSng(Math.Sqrt(xx1 ^ 2 + yy1 ^ 2))
        If Pote = 0.0! Then Exit Sub
        Call polar(xx1, yy1, alfz)
        X(1) = 0
        y(1) = 0
        X(2) = X(1)
        y(2) = DistanzaScritta / 8
        X(3) = X(1)
        y(3) = DistanzaScritta
        X(4) = X(1)
        y(4) = y(3) + DistanzaScritta / 8
        X(5) = Pote
        y(5) = y(1)
        X(6) = X(5)
        y(6) = y(2)
        X(7) = X(5)
        y(7) = y(3)
        X(8) = X(5)
        y(8) = y(4)
        X(9) = CSng(X(3) + 1.5 * SizeArrow)
        y(9) = CSng(y(3) + 0.5 * SizeArrow)
        X(10) = X(9)
        y(10) = CSng(y(3) - 0.5 * SizeArrow)
        X(11) = CSng(X(7) - 1.5 * SizeArrow)
        y(11) = CSng(y(7) + 0.5 * SizeArrow)
        X(12) = X(11)
        y(12) = CSng(y(7) - 0.5 * SizeArrow)
        If Len(TestoQuota) = 0 Then
            teori = CInt(Pote)
            intt = 10 * CInt(teori)
            If Math.Abs(intt / 10.0! - teori) < 0.1 Then TestoQuota = Str(CInt(teori)) Else TestoQuota = Trigon.myStr(CSng(teori), 6, 1, 0)
            TestoQuota = LTrim(TestoQuota)
        End If
        Dove.Font = New System.Drawing.Font("MS Sans Serif", 8)
        If gDove.MeasureString(TestoQuota, Dove.Font).Width > Math.Abs(X(6) - X(2)) Then
            localfactor = Math.Abs(X(6) - X(2)) / gDove.MeasureString(TestoQuota, Dove.Font).Width
            Dove.Font = New System.Drawing.Font("Small Fonts", 8 * localfactor)
        End If
        Select Case SwIUNpri
            Case 4, 5
                If Direzione = 1 Then
                    xx1 = (X(2) + X(6)) / 2 - gDove.MeasureString(TestoQuota, Dove.Font).Width / gDove.MeasureString(TestoQuota, Dove.Font).Height * hquo / 10 / Fy / 2
                    yy1 = CSng(y(3) - hquo / 10 / Fy * 1.2)
                Else
                    xx1 = (X(2) + X(6)) / 2 + gDove.MeasureString(TestoQuota, Dove.Font).Width / gDove.MeasureString(TestoQuota, Dove.Font).Height * hquo / 10 / Fy / 2
                    yy1 = CSng(y(3) + hquo / 10 / Fy * 0.3)
                End If
                rotateq(xx1, yy1)
            Case Else
                If Direzione = 1 Then
                    xx1 = (X(2) + X(6)) / 2 - gDove.MeasureString(TestoQuota, Dove.Font).Width / Fx / 2
                    yy1 = CSng(y(3) - gDove.MeasureString(TestoQuota, Dove.Font).Height / Fy * 1.2)
                Else
                    xx1 = (X(2) + X(6)) / 2 + gDove.MeasureString(TestoQuota, Dove.Font).Width / Fx / 2
                    yy1 = CSng(y(3) + gDove.MeasureString(TestoQuota, Dove.Font).Height / Fy * 0.3)
                End If
                rotateq(xx1, yy1)
        End Select
        If SwIUNpri = 1 Then TestoQuota = TestoQuota & " !"
        Select Case SwIUNpri
            Case 3
                l = AcadDoc.ActiveLayer
                AcadDoc.ActiveLayer = AcadDoc.Layers.Item("1")
                xa = xcoord(p1) : ya = ycoord(p1)
                rotate(xa, ya)
                ins1(0) = xa : ins1(1) = ya
                xa = xcoord(P2) : ya = ycoord(P2)
                rotate(xa, ya)
                ins2(0) = xa : ins2(1) = ya
                If Direzione = 1 Then
                    xa = (xcoord(p1) + xcoord(P2)) / 2
                    ya = ycoord(p1) + DistanzaScritta
                Else
                    xa = xcoord(p1) + DistanzaScritta
                    ya = (ycoord(p1) + ycoord(P2)) / 2
                End If
                rotate(xa, ya)
                quotTest(0) = xa : quotTest(1) = ya
                Quota = AcadDoc.ModelSpace.AddDimAligned(ins1, ins2, quotTest)
                If l Is Nothing Then
                    AcadDoc.ActiveLayer = AcadDoc.Layers.Item("0")
                Else
                    AcadDoc.ActiveLayer = l
                End If
            Case Else
                Call ECRIR(TestoQuota) ' + " !")
                alfo = roundb(2, CSng(alfz * 180 / Math.PI))
                If Math.Abs(Int(alfo) - 180) < 45 Then alfo = 0
                If Math.Abs(Int(alfo) - 270) < 45 Then alfo = 90
                If Int(alfo) > 315 Then alfo = 0
                texte0(xx1, yy1, alfo, hquo, 0.2)
                Call ctrait(6, 0.2)
                If SwIUNpri = 4 Then
                    Call ctrait(0, 0.1)
                    For j = 1 To 3
                        xa = X(n(j)) : ya = y(n(j)) : xb = X(M(j)) : yb = y(M(j))
                        rotateq(xa, ya)
                        rotateq(xb, yb)
                        If j < 3 Then
                            segm(xa, ya, xb, yb)
                        Else
                            segm(xa, ya, xb, yb, "F")
                        End If
                    Next
                Else
                    For j = 1 To 7
                        xa = X(n(j)) : ya = y(n(j)) : xb = X(M(j)) : yb = y(M(j))
                        rotateq(xa, ya)
                        rotateq(xb, yb)
                        segm(xa, ya, xb, yb)
                    Next
                End If
                Call ctrait(ltipo, Spess)
        End Select
    End Sub
    Function roundb(ByVal nk As Short, ByVal X As Single) As Single
        roundb = CSng(Math.Sign(X) * Int(Math.Abs(X) * 10 ^ nk + 0.1) / 10 ^ nk)
    End Function
    Sub ql2(ByVal p1 As Single, ByVal P2 As Single, ByVal Direzione As Short, _
    ByVal DistanzaScritta As Single, ByVal TestoQuota As String, _
    ByVal PrefissoQuota As String, ByVal SuffissoQuota As String)
        Dim xx1, Ipotenusa, yy1 As Single
        Dim IpotenusaArrotondata As Short
        xx1 = xcoord(P2) - xcoord(p1)
        yy1 = ycoord(P2) - ycoord(p1)
        Ipotenusa = CSng(Math.Sqrt(xx1 * xx1 + yy1 * yy1))
        IpotenusaArrotondata = CShort(0.45 + Ipotenusa)
        TestoQuota = IpotenusaArrotondata.ToString.Trim
        TestoQuota = PrefissoQuota & TestoQuota & SuffissoQuota
        Call ql1(p1, P2, Direzione, DistanzaScritta, TestoQuota)
    End Sub
    Sub refabs()
        x0 = 0.0!
        y0 = 0.0!
        Alfa = 0.0!
    End Sub
    Sub refere(ByVal DELTAX As Single, ByVal DELTAY As Single, ByVal DELTAA As Single)
        If ScalStrim = 0 Then ScalStrim = 1
        x0 = x0 + DELTAX * ScalStrim
        y0 = y0 + DELTAY * ScalStrim
        Alfa = CSng(Alfa + DELTAA * Math.PI / 180)
    End Sub
    Sub rotate(ByRef x1 As Single, ByRef y1 As Single)
        Dim xa, ya As Single
        If ScalStrim = 0 Then ScalStrim = 1
        xa = x1 * ScalStrim : ya = y1 * ScalStrim
        x1 = CSng(x0 + xa * Math.Cos(Alfa) - ya * Math.Sin(Alfa))
        y1 = CSng(y0 + xa * Math.Sin(Alfa) + ya * Math.Cos(Alfa))
    End Sub
    Sub rotateq(ByRef x1 As Single, ByRef y1 As Single)
        Dim xa, ya As Single
        If ScalStrim = 0 Then ScalStrim = 1
        xa = x1 * ScalStrim : ya = y1 * ScalStrim
        x1 = CSng(orx + xa * Math.Cos(alfz) - ya * Math.Sin(alfz))
        y1 = CSng(ory + xa * Math.Sin(alfz) + ya * Math.Cos(alfz))
        'U = segm(xa, ya, xb, yb)
    End Sub
    Sub seg1(ByVal p1 As Single, ByVal P2 As Single)
        Dim x2, x1, y1, y2 As Single
        '      SHARED xcoor(), YCOOR()
        x1 = xcoord(p1)
        y1 = ycoord(p1)
        x2 = xcoord(P2)
        y2 = ycoord(P2)
        segm(x1, y1, x2, y2)
    End Sub
    Sub ColoreTratto(ByVal c As Drawing.Color)
        Penna.Color = c
    End Sub
    Sub CLIN(ByVal X As Single, ByVal y As Single, ByVal R As Single, ByVal a As Single)
        Dim x0, y0 As Single
        x0 = CSng(R * Math.Cos(a))
        y0 = CSng(R * Math.Sin(a))
        segm(X - x0, y + y0, X + x0, y - y0)
        If Math.Abs(a) < clsTrigon.TOLER Then
            y0 = x0
            x0 = 0
        End If
        segm(X + x0, y + y0, X - x0, y - y0)
    End Sub
    Sub seg2(ByVal p1 As Single, ByVal x2 As Single, ByVal a As Single)
        '      SHARED xcoor(), YCOOR()
        Dim y1, x1, al As Single
        Dim xx, y2 As Single
        x1 = xcoord(p1)
        y1 = ycoord(p1)
        al = CSng(a * Math.PI / 180)
        y2 = CSng(y1 + x2 * Math.Sin(al))
        xx = CSng(x1 + x2 * Math.Cos(al))
        segm(x1, y1, xx, y2)
    End Sub
    Sub segm(ByVal xa As Single, ByVal ya As Single, ByVal xb As Single, ByVal yb As Single, Optional ByVal Cod As String = "")
        Dim x2, x1, y1, y2 As Single
        Dim lineaA As AutoCAD.AcadLine
        Dim startPoint(2) As Double
        Dim endPoint(2) As Double
        '      On Local Error GoTo errsegm
        x1 = xa : y1 = ya : x2 = xb : y2 = yb
125:    rotate(x1, y1)
126:    rotate(x2, y2)
        Select Case SwIUNpri
            Case 1
127:            iunit.WriteLine(Trigon.FormatS(Strtp(2), 8))
128:            iunit.WriteLine(Trigon.FormatS(Strtp(3), x1 / mioFx / 10, y1 / mioFy / 10))
129:            iunit.WriteLine(Trigon.FormatS(Strtp(3), x2 / mioFx / 10, y2 / mioFy / 10))
            Case 2
                LineaDXF(x1, y1, x2, y2)
            Case 3
                startPoint(0) = x1 : startPoint(1) = y1
                endPoint(0) = x2 : endPoint(1) = y2
                lineaA = AcadBlock.AddLine(startPoint, endPoint)
            Case 4
                LineaRTF(x1, y1, x2, y2, Cod)
            Case 5
                ScalaRel(x1, y1, x2, y2)
        End Select
        If IUNL < 3 And SwIUNpri < 4 Then
            gDove.DrawLine(Penna, x1 / mioFx, y1 / mioFy, x2 / mioFx, y2 / mioFy) ', mycol(tipli))
        End If
    End Sub
    Private Sub LineaRTF(ByVal x0 As Single, ByVal y0 As Single, ByVal x1 As Single, ByVal y1 As Single, _
    Optional ByVal Cod As String = "")
        Dim Lf, Tp, Bt, Rt As Single
        Dim i As Short
        x0 = x0 / mioFx
        y0 = y0 / mioFy
        x1 = x1 / mioFx
        y1 = y1 / mioFy
        i = 1
        iunit.Write("{\shp{\*\shpinst")
        'x0*ScalaWin=centimetri
        Lf = Int(((x0 + offxWin) * ScalaWinx) * 567)
        Tp = Int(((28 - (y0 + offyWin) * ScalaWiny)) * 567)
        Rt = Int(((x1 + offxWin) * ScalaWinx) * 567)
        Bt = Int(((28 - (y1 + offyWin) * ScalaWiny)) * 567)
        If Lf > Rt Then i = -i : Trigon.SWAP(Lf, Rt)
        If Bt < Tp Then i = -i : Trigon.SWAP(Bt, Tp)
        iunit.Write("\shpleft" & Trim(Str(Lf)))
        iunit.Write("\shptop" & Trim(Str(Tp)))
        iunit.Write("\shpright" & Trim(Str(Rt)))
        iunit.WriteLine("\shpbottom" & Trim(Str(Bt)))
        iunit.WriteLine("\shpfhdr0\shpbxpage\shpbypara\shpwr3\shpwrk0\shpfblwtxt0\shpz3\shplid1029")
        iunit.WriteLine("{\sp{\sn shapeType}{\sv 20}}{\sp{\sn shapePath}{\sv 4}}")
        If i = 1 Then
            iunit.WriteLine("{\sp{\sn fFlipH}{\sv 0}}{\sp{\sn fFlipV}{\sv 0}}")
        Else
            iunit.WriteLine("{\sp{\sn fFlipH}{\sv 1}}{\sp{\sn fFlipV}{\sv 0}}")
        End If
        iunit.Write("{\sp{\sn lineWidth}{\sv" & Str(Int(12700 * Spessore)) & "}}")
        If Cod = "F" Then
            iunit.Write("{\sp{\sn lineStartArrowhead}{\sv 2}}{\sp{\sn lineEndArrowhead}{\sv 2}}{\sp{\sn fArrowheadsOK}{\sv 1}}")
        Else
            iunit.Write("{\sp{\sn fArrowheadsOK}{\sv 1}}")
        End If
        iunit.Write("{\sp{\sn fLine}{\sv 1}}")  'perché?
        If tipolinea = 3 Then
            iunit.Write("{\sp{\sn lineDashing}{\sv 7}}")
        ElseIf tipolinea = 2 Then
            iunit.Write("{\sp{\sn lineDashing}{\sv 9}}")
        End If
        iunit.WriteLine("}}")
    End Sub
    Sub texte0(ByVal xa As Single, ByVal ya As Single, ByVal angolo As Single, _
    ByVal AltezzaTesto As Single, ByVal E As Single)
        Dim Lf, Tp, Bt, Rt As Single
        Dim fliph, flipv As Boolean
        Dim inspoint(2) As Double
        Dim Testo As AutoCAD.AcadText
        Dim l As AutoCAD.AcadLayer
        Dim x0, y0, x1, y1 As Single
400:    If ch.Length = 0 Then Exit Sub
        xa = xa / mioFx
        ya = ya / mioFy
        rotate(xa, ya)
        angolo = CSng(angolo * Math.PI / 180)
        Select Case SwIUNpri
            Case 1
420:            iunit.WriteLine(Trigon.FormatS(Strtp(8), AltezzaTesto / 10, E / 10, angolo))
                iunit.WriteLine(Trigon.FormatS(Strtp(9), 0, 1))
                iunit.WriteLine(Trigon.FormatS(Strtp(6), xa / 10, ya / 10, 11, Len(ch)))
                iunit.WriteLine(Trigon.FormatS(Strtp(7), ch))
            Case 2
                et = E ' et = Val(Mid$(record, 39, 14)) * 10
                TextDXF(xa, ya, AltezzaTesto, ch, angolo)
            Case 3
                inspoint(0) = xa
                inspoint(1) = ya
                ht = AltezzaTesto
                l = AcadDoc.ActiveLayer
                AcadDoc.ActiveLayer = AcadDoc.Layers.Item("2")
                Testo = AcadDoc.ModelSpace.AddText(ch, inspoint, ht)
                AcadDoc.ActiveLayer = l
            Case 4
                Call Char_Renamed(x0, y0, x1, y1, xa, ya, angolo, AltezzaTesto / 10)
                y0 = 28 - y0
                y1 = 28 - y1
                iunit.Write("{\shp{\*\shpinst")
                'x0*ScalaWin=centimetri
                ' Lf = Int(((x0 + offxWin) * ScalaWinx) * 567)
                ' Tp = Int(((28 - (y0 + offyWin) * ScalaWiny)) * 567)
                ' Rt = Int(((x1 + offxWin) * ScalaWinx) * 567)
                ' Bt = Int(((28 - (y1 + offyWin) * ScalaWiny)) * 567)
                Lf = Int(x0 * 567) : Tp = Int(y0 * 567)
                Rt = Int(x1 * 567) : Bt = Int(y1 * 567)
                If Lf > Rt Then fliph = True : Trigon.SWAP(Lf, Rt) Else fliph = False
                If Bt < Tp Then flipv = True : Trigon.SWAP(Bt, Tp) Else flipv = False
                iunit.Write("\shpleft" & Trim(Str(Lf)))
                iunit.Write("\shptop" & Trim(Str(Tp)))
                iunit.Write("\shpright" & Trim(Str(Rt)))
                iunit.WriteLine("\shpbottom" & Trim(Str(Bt)))
                iunit.WriteLine("\shpfhdr0\shpbxpage\shpbypara\shpwr3\shpwrk0\shpfblwtxt0\shpz2\shplid1029")
                iunit.WriteLine("{\sp{\sn shapeType}{\sv 136}}")
                If angolo <> 0 Then iunit.Write("{\sp{\sn rotation}{\sv" & Str(angolo / Math.PI * 2 * 5898240) & "}}")
                If angolo > 0 Then
                    iunit.Write("{\sp{\sn fFlipH}{\sv 1}}{\sp{\sn fFlipV}{\sv 1}}")
                Else
                    iunit.Write("{\sp{\sn fFlipH}{\sv 0}}{\sp{\sn fFlipV}{\sv 0}}")
                End If
                iunit.WriteLine("{\sp{\sn gtextUNICODE}{\sv " & ch & "}}{\sp{\sn gtextSpacing}{\sv 78650}}")
                iunit.WriteLine("{\sp{\sn gtextSize}{\sv 786432}}{\sp{\sn gtextFont}{\sv Arial}}{\sp{\sn gtextFReverseRows}{\sv 0}}")
                iunit.WriteLine("{\sp{\sn gtextFReverseRows}{\sv 0}}{\sp{\sn fGtext}{\sv 1}}{\sp{\sn gtextFVertical}{\sv 0}}")
                iunit.WriteLine("{\sp{\sn gtextFKern}{\sv 1}}{\sp{\sn gtextFTight}{\sv 0}}{\sp{\sn gtextFStretch}{\sv 1}}{\sp{\sn gtextFShrinkFit}{\sv 1}}{\sp{\sn gtextFBestFit}{\sv 1}}{\sp{\sn gtextFNormalize}{\sv 0}}")
                iunit.WriteLine("{\sp{\sn gtextFDxMeasure}{\sv 0}}{\sp{\sn gtextFBold}{\sv 0}}{\sp{\sn gtextFItalic}{\sv 0}}{\sp{\sn gtextFUnderline}{\sv 0}}{\sp{\sn gtextFShadow}{\sv 0}}{\sp{\sn gtextFSmallcaps}{\sv 0}}")
                iunit.WriteLine("{\sp{\sn gtextFStrikethrough}{\sv 0}}{\sp{\sn adjustValue}{\sv 10808}}{\sp{\sn fillColor}{\sv 0}}{\sp{\sn fFilled}{\sv 1}}{\sp{\sn fLine}{\sv 1}}{\sp{\sn shadowColor}{\sv 8816262}}{\sp{\sn fShadow}{\sv 0}}{\sp{\sn fshadowObscured}{\sv 0}}")
                iunit.WriteLine("{\sp{\sn fPerspective}{\sv 0}}{\sp{\sn f3D}{\sv 0}}{\sp{\sn fc3DMetallic}{\sv 0}}{\sp{\sn fc3DUseExtrusionColor}{\sv 0}}{\sp{\sn fc3DLightFace}{\sv 1}}{\sp{\sn fc3DConstrainRotation}{\sv 1}}{\sp{\sn fc3DRotationCenterAuto}{\sv 0}}")
                iunit.WriteLine("{\sp{\sn fc3DParallel}{\sv 1}}{\sp{\sn fc3DKeyHarsh}{\sv 1}}{\sp{\sn fc3DFillHarsh}{\sv 0}}")
                iunit.WriteLine("}}")
            Case 5
                Call Char_Renamed(x0, y0, x1, y1, xa, ya, angolo, AltezzaTesto / 10)
                x0 = x0 / ScalaWinx - offxWin
                x1 = x1 / ScalaWinx - offxWin
                y0 = y0 / ScalaWiny - offyWin
                y1 = y1 / ScalaWiny - offyWin
                ScalaRel(x0, y0, x1, y1)
        End Select
        Try
            Dim m As Matrix = New Matrix(1, 0, 0, -1, 0, 2 * ya) 'rimetti provvisoriamente l'asse y verso il basso
            Dim hTesto As Single = CSng(Math.Abs(gDove.MeasureString(ch, Dove.Font).Height) / Fy)
            m.RotateAt(CSng(angolo * 180 / Math.PI), New PointF(xa, ya), MatrixOrder.Append)
            m.Translate(0, CSng(-1.2 * hTesto * Math.Sin(angolo)))
            gDove.MultiplyTransform(m)
            gDove.DrawString(ch, Dove.Font, Pennello, xa, ya)
            m.Invert()
            gDove.MultiplyTransform(m)
        Catch exc As Exception
            MsgBox(exc.Message + vbCrLf + exc.StackTrace)
        End Try
    End Sub
    Private Sub Char_Renamed(ByRef x0 As Single, ByRef y0 As Single, ByRef x1 As Single, ByRef y1 As Single, _
    ByVal xa As Single, ByVal ya As Single, ByVal angolo As Single, ByVal AltezzaTesto As Single)
        CarWidth = Math.Abs(gDove.MeasureString(ch, Dove.Font).Width) ' * d * 567
        CarHeight = Math.Abs(gDove.MeasureString(ch, Dove.Font).Height) ' * d * 567
        x0 = (xa + offxWin) * ScalaWinx
        y0 = (ya + offyWin) * ScalaWiny
        x1 = x0 + AltezzaTesto * ScalaWinx / CarHeight * CarWidth * 2
        y1 = y0 + AltezzaTesto * ScalaWiny
        x1 = x0 + 90 / (y1 - y0) * (x1 - x0) / 567
        y1 = CSng(y0 + 90 / 567)
        If angolo <> 0 Then
            x2 = x0 : y2 = y1
            Ruota(x2, y2, x0, y0, angolo)
            Ruota(x2, y2, x1, y1, angolo)
            refabs()
        End If
    End Sub
    Sub ECRIR(ByVal ch1 As String)
        Dim leng, i As Short
        ch1 = LTrim(RTrim(ch1))
        leng = CShort(Len(ch1))
        For i = leng To 1 Step -1
            If Asc(Mid(ch1, i, 1)) > 33 Then
                ch = Mid(ch1, 1, i)
                Exit Sub
            End If
        Next
        ch = ""
    End Sub
    Function xcoord(ByVal PX As Single) As Single
        Dim Np1 As Integer
        Np1 = CInt((PX - 1000000.0!) / 2.0!)
        If (Np1 <= 0) Then
            xcoord = 0.0!
            Exit Function
        End If
        xcoord = xcoor(Np1)
    End Function
    Function ycoord(ByVal PY As Single) As Single
        Dim Np1 As Integer
        Np1 = CInt((PY - 1000000.0!) / 2.0!)
        If (Np1 <= 0) Then
            ycoord = 0.0!
            Exit Function
        End If
        ycoord = ycoor(Np1)
    End Function
    Function cerc(ByVal xa As Single, ByVal ya As Single, ByVal R As Single, Optional ByVal Fill As Boolean = False) As Single
        Dim Lf, Tp, Bt, Rt As Single
        Dim i As Short
        Dim xc, yc As Single
        Dim cerchioA As AutoCAD.AcadCircle
        Dim inspoint(2) As Double
        If R <= 0 Then Exit Function
        xc = xa / mioFx : yc = ya / mioFy
        R = R / mioFx
200:    rotate(xc, yc)
        Select Case SwIUNpri
            Case 1
210:            iunit.WriteLine(Trigon.FormatS(Strtp(4), xc / 10, yc / 10, R / 10))
220:            iunit.WriteLine(Trigon.FormatS(Strtp(5), (xc + R) / 10, yc / 10, Math.PI * 2))
            Case 2
1460:           iunit.WriteLine("CIRCLE")
                iunit.WriteLine(8)
                iunit.WriteLine(Layer)
                iunit.WriteLine(6)
                iunit.WriteLine(tipli)
                iunit.WriteLine(62)
                iunit.WriteLine(Ncolo)
                iunit.WriteLine(10)
1480:           iunit.WriteLine(roundb(2, xc))
                iunit.WriteLine(20)
                iunit.WriteLine(roundb(2, yc))
                iunit.WriteLine(40)
                iunit.WriteLine(roundb(2, R))  'D
                iunit.WriteLine(0)
            Case 3
                inspoint(0) = xc : inspoint(1) = yc
                cerchioA = AcadBlock.AddCircle(inspoint, R)
            Case 4
                iunit.Write("{\shp{\*\shpinst")
                Lf = Int((xc - R + offxWin) * 567 * ScalaWinx)
                Tp = Int((28 - (yc - R + offyWin) * ScalaWiny) * 567)
                Rt = Int((xc + R + offxWin) * 567 * ScalaWinx)
                Bt = Int((28 - (yc + R + offyWin) * ScalaWiny) * 567)
                If Lf > Rt Then i = -i : Trigon.SWAP(Lf, Rt)
                If Bt < Tp Then i = -i : Trigon.SWAP(Bt, Tp)
                iunit.Write("\shpleft" & Trim(Str(Lf)))
                iunit.Write("\shptop" & Trim(Str(Tp)))
                iunit.Write("\shpright" & Trim(Str(Rt)))
                iunit.WriteLine("\shpbottom" & Trim(Str(Bt)))
                iunit.WriteLine("\shpfhdr0\shpbxpage\shpbypara\shpwr3\shpwrk0\shpfblwtxt0\shpz3\shplid1029")
                iunit.WriteLine("{\sp{\sn shapeType}{\sv 3}}{\sp{\sn fFilled}{\sv 0}}")
                iunit.Write("{\sp{\sn lineWidth}{\sv" & Str(Int(12700 * Spessore)) & "}}")
                iunit.WriteLine("}}")
            Case 5
                ScalaRel(xc - R, yc - R, xc + R, yc + R)
        End Select
        If Dove Is Nothing Then Exit Function
        If IUNL < 3 And SwIUNpri < 4 Then
            If Fill Then
                gDove.FillEllipse(Pennello, xc - R, yc - R, 2 * R, 2 * R)   ' mycol(tipli)) ', 0,  Math.PI * 2
            Else
                gDove.DrawEllipse(Penna, xc - R, yc - R, 2 * R, 2 * R)     ' mycol(tipli)) ', 0,  Math.PI * 2
            End If
        End If
    End Function
    Public Sub tratto(ByVal x1 As Single, ByVal y1 As Single, ByVal x2 As Single, ByVal y2 As Single, Optional ByVal SP As Single = 0, Optional ByVal Tipo As Short = 0)
        Dim lineaA As AutoCAD.AcadLine
        Dim startPoint(2) As Double
        Dim endPoint(2) As Double
        x2 = x2 / mioFx
        y2 = y2 / mioFy
        Try
            Static x2Vec, y2Vec As Single
            If x1 = -1 And y1 = -1 Then
                x1 = x2Vec
                y1 = y2Vec
            Else
                x1 = x1 / mioFx
                y1 = y1 / mioFy
            End If
            rotate(x1, y1)
            rotate(x2, y2)
            If SP > 0 Then tiplin(SP, Tipo)
            Select Case SwIUNpri
                Case 1
                    iunit.WriteLine(Trigon.FormatS(Strtp(2), 8))
                    iunit.WriteLine(Trigon.FormatS(Strtp(3), x1 / 10, y1 / 10))
                    iunit.WriteLine(Trigon.FormatS(Strtp(3), x2 / 10, y2 / 10))
                Case 2
                    LineaDXF(x1, y1, x2, y2)
                Case 3
                    startPoint(0) = x1 : startPoint(1) = y1
                    endPoint(0) = x2 : endPoint(1) = y2
                    lineaA = AcadBlock.AddLine(startPoint, endPoint)
                    lineaA.Lineweight = CType(PesoLinea(), AutoCAD.ACAD_LWEIGHT)
                Case 4
                    LineaRTF(x1, y1, x2, y2)
                Case 6
                    StubWord.AggiungiLinea(x1, y1, x2, y2)
            End Select
            Penna.DashStyle = ConvertDash(tipolinea)
            If SP > 0 Then
                Dim c As Color = Drawing.ColorTranslator.FromOle(QBColor(CInt(SP)))
                Penna.Color = c
            End If
            gDove.DrawLine(Penna, x1, y1, x2, y2)
            x2Vec = x2
            y2Vec = y2
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Private Function Red(ByVal c As Integer) As Integer
        Red = c And &HFF
    End Function
    Private Function Green(ByVal c As Integer) As Integer
        Green = c And &HFF00 \ 256
    End Function
    Private Function Blue(ByVal c As Integer) As Integer
        Blue = c And &HFF0000 \ 256 \ 256
    End Function
    Public Sub trattoBF(ByVal x1 As Single, ByVal y1 As Single, ByVal x2 As Single, _
                        ByVal y2 As Single, ByVal SP As Single, ByVal Tipo As Short)
        Static x2Vec, y2Vec As Single
        Dim Rett As AutoCAD.Acad3DSolid
        Dim inspoint(2) As Double
        x2 = x2 / mioFx
        y2 = y2 / mioFy
        If x1 = -1 And y1 = -1 Then
            x1 = x2Vec
            y1 = y2Vec
        Else
            x1 = x1 / mioFx
            y1 = y1 / mioFy
        End If
        rotate(x1, y1)
        rotate(x2, y2)
        Select Case SwIUNpri
            Case 1
                If SP > 0 Then tiplin(SP, Tipo)
                iunit.WriteLine(Trigon.FormatS(Strtp(2), 8))
                iunit.WriteLine(Trigon.FormatS(Strtp(3), x1 / 10, y1 / 10))
                iunit.WriteLine(Trigon.FormatS(Strtp(3), x2 / 10, y2 / 10))
            Case 2
                iunit.WriteLine("LINE")
                iunit.WriteLine(8)
                iunit.WriteLine(Layer)
                iunit.WriteLine(6)
                iunit.WriteLine(tipli)
                iunit.WriteLine(62)
                iunit.WriteLine(Ncolo)
                iunit.WriteLine(10)
                iunit.WriteLine(roundb(2, x1))
                iunit.WriteLine(20)
                iunit.WriteLine(roundb(2, y1))
                iunit.WriteLine(11)
                iunit.WriteLine(roundb(2, x2))
                iunit.WriteLine(21)
                iunit.WriteLine(roundb(2, y2))
                iunit.WriteLine(0)
            Case 3
                inspoint(0) = (x1 + x2) / 2
                inspoint(2) = (y1 + y2) / 2
                Rett = AcadBlock.AddWedge(inspoint, x2 - x1, y2 - y1, 0)
        End Select
        tipolinea = Tipo
        Penna.DashStyle = ConvertDash(tipolinea)
        Dim c As Color = Drawing.ColorTranslator.FromOle(QBColor(CInt(SP)))
        If SP > 0 Then Penna.Color = c
        gDove.FillRectangle(Pennello, x1, y1, x2 - x1, y2 - y1)
        x2Vec = x2
        y2Vec = y2
    End Sub
    Public Sub Cerchio(ByVal X As Single, ByVal y As Single, ByVal R As Single, ByVal ang1 As Single, ByVal ang2 As Single, ByVal SP As Single)
        Dim arcoA As AutoCAD.AcadArc
        Dim inspoint(2) As Double
        Dim x1, y1 As Single
        tipolinea = 0
        Penna.DashStyle = DashStyle.Solid
        X = X / mioFx
        y = y / mioFy
        R = R / mioFx
        gDove.DrawArc(Penna, X - R, y - R, 2 * R, 2 * R, CSng(ang1 * 180 / Math.PI), CSng((ang2 - ang1) * 180 / Math.PI))
        x1 = CSng(X + R * Math.Cos(ang1))
        y1 = CSng(y + R * Math.Sin(ang1))
        Select Case SwIUNpri '22
            Case 1
                iunit.WriteLine(Trigon.FormatS(Strtp(4), X / 10, y / 10, R / 10))
                iunit.WriteLine(Trigon.FormatS(Strtp(5), x1 / 10, y1 / 10, (ang2 - ang1) * 180 / Math.PI))
            Case 2
                ArcDXF(X, y, R, x1, y1, CSng((ang2 - ang1) * 180 / Math.PI))
            Case 3
                inspoint(0) = X
                inspoint(1) = y
                arcoA = AcadBlock.AddArc(inspoint, R, ang1, ang2)
        End Select
    End Sub
    Private Sub myTransform(ByVal dx As Single, ByVal dy As Single)
        Try
            Dim m As Matrix = New Matrix(1, 0, 0, -1, 0, 0)
            gDove.Transform = New Matrix
            If Penna Is Nothing Then Penna = New Pen(Color.Black)
            If Pennello Is Nothing Then Pennello = New SolidBrush(Color.Black)
            Penna.Width = -1 ' / gDove.DpiX
            gDove.ScaleTransform(Fx, Fy)
            gDove.TranslateTransform(dx, dy)
            gDove.MultiplyTransform(m, Drawing.Drawing2D.MatrixOrder.Append)
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Public Sub MouseToWorld(ByRef x As Single, ByRef y As Single)
        Dim m As Drawing2D.Matrix = DoveDisegnog.Transform.Clone
        m.Invert()
        Dim Points As PointF() = {New PointF(x, y)}
        m.TransformPoints(Points)
        x = Points(0).X
        y = Points(0).Y
    End Sub
    Public Sub WorldToMouse(ByRef x As Single, ByRef y As Single)
        Dim Points As PointF() = {New PointF(x, y)}
        DoveDisegnog.Transform.TransformPoints(Points)
        x = Points(0).X
        y = Points(0).Y
    End Sub
    Public Function Scala(ByVal x1 As Single, ByVal x2 As Single, ByVal y1 As Single, ByVal y2 As Single, _
    Optional ByVal Mode As Integer = 0, Optional ByVal NonCanc As Boolean = False, Optional ByVal p As Drawing.Pen = Nothing) As Boolean
        Dim RealHeight, RealWidth As Single
        Dim SH2, SH1, SW1, SW2 As Single
        Static DoveV As PictureBox
        Scala = True
        Fx = 1
        Fy = 1
        If Not p Is Nothing Then Penna = p
        RealHeight = y2 - y1 : RealWidth = x2 - x1
        If Not Dove Is Nothing Then
            If Not Dove Is DoveV Or SH = 0 Or SW = 0 Then
                DoveV = Dove
                SH = Dove.Height
                SW = Dove.Width
            End If
        End If
        SH1 = SH
        SW1 = SW
        Try
            Fy = Math.Abs(SH1 / RealHeight)
            Fx = Math.Abs(SW1 / RealWidth)
            If SwIUNpri = 4 Or SwIUNpri = 5 Then
                SH2 = 27
                SW2 = 19
                SH1 = SH2
                SW1 = SW2
            Else
                If Mode = 1 Then
                    mioFx = 1 / Fx
                    mioFy = 1 / Fy
                    Fx = 1
                    Fy = 1
                    myTransform(-x1 / mioFx, -y2 / mioFy)
                    Exit Function
                End If
            End If
            If Fy < Fx Then
                x1 = x1 + RealWidth * (1 - Fx / Fy) / 2
                x2 = x2 - RealWidth * (1 - Fx / Fy) / 2
                Fx = Fy
            Else
                y1 = y1 + RealHeight * (1 - Fy / Fx) / 2
                y2 = y2 - RealHeight * (1 - Fy / Fx) / 2
                Fy = Fx
            End If
            If x1 > x2 Then Trigon.SWAP(x1, x2)
            If SwIUNpri = 4 Or SwIUNpri = 5 Then
                ScalaWinx = SW2 / (x2 - x1)
                ScalaWiny = SH2 / (y2 - y1)
                If ScalaWiny > ScalaWinx Then ScalaWiny = ScalaWinx Else ScalaWinx = ScalaWiny
                offxWin = 1 / ScalaWinx - x1
                offyWin = 1 / ScalaWiny - y1
            Else
                If Not gDove Is Nothing Then
                    If Not NonCanc Then gDove.Clear(Color.White)
                    mioFx = 1 ' / Fx
                    mioFy = 1 ' / Fy
                    myTransform(-x1, -y2)
                End If
            End If
        Catch e As Exception
            MsgBox("Scala:" + vbCrLf + e.Message + e.StackTrace)
        End Try
    End Function
    'Sub arcos(ByVal X As Single, ByVal y As Single, ByVal R As Single, ByVal ap As Single, ByVal af As Single, ByVal SP As Single, ByVal nli As Short)
    '    Dim da, xp, yp, Alfa As Single
    '    Dim arcoA As AutoCAD.AcadArc
    '    Dim inspoint(2) As Double
    '    xp = CSng(X + R * Math.Cos(ap))
    '    yp = CSng(y + R * Math.Sin(ap))
    '    da = af - ap
    '    If da < 0 Then da = CSng(2 * Math.PI + da)
    '    If SP > 0 Then tiplin(SP, nli)
    '    Select Case SwIUNpri
    '        Case 1
    '            iunit.WriteLine(Trigon.FormatS(Strtp(4), X / 10, y / 10, R / 10))
    '            iunit.WriteLine(Trigon.FormatS(Strtp(5), xp / 10, yp / 10, da))
    '        Case 2
    '            Alfa = CSng(da * 180 / Math.PI)
    '            ArcDXF(X, y, R, xp, yp, Alfa)
    '        Case 3
    '            inspoint(0) = X
    '            inspoint(1) = y
    '            arcoA = AcadBlock.AddArc(inspoint, R, ap, af)
    '    End Select
    'End Sub
    'Sub cerchios(ByVal X As Single, ByVal y As Single, ByVal R As Single, ByVal SP As Single, ByVal nli As Short)
    '    Dim arcoA As AutoCAD.AcadCircle
    '    Dim inspoint(2) As Double
    '    If SP > 0 Then tiplin(SP, nli)
    '    Select Case SwIUNpri
    '        Case 1
    '            iunit.WriteLine(Trigon.FormatS(Strtp(4), X / 10, y / 10, R / 10))
    '            iunit.WriteLine(Trigon.FormatS(Strtp(5), (X + R) / 10, y / 10, 2 * Math.PI))
    '        Case 2
    '            ArcDXF(X, y, R, X + R, y, 360)
    '        Case 3
    '            inspoint(0) = X
    '            inspoint(1) = y
    '            arcoA = AcadBlock.AddCircle(inspoint, R)
    '    End Select
    'End Sub
    Sub ChiudiPRI()
        coda()
        iunit.Close()
        iunit = Nothing
        Scambia()
        If iunit Is Nothing Then SwIUNpri = 0
    End Sub
    Sub Linea(ByVal x0 As Single, ByVal y0 As Single, ByVal x1 As Single, ByVal y1 As Single, ByVal SP As Single, ByVal nli As Short)
        Dim lineaA As AutoCAD.AcadLine
        Dim startPoint(2) As Double
        Dim endPoint(2) As Double
221:    If SP > 0.0! Then tiplin(SP, nli)
        Select Case SwIUNpri
            Case 1
                x1 = x1 / mioFx
                x0 = x0 / mioFx
                y1 = y1 / mioFy
                y0 = y0 / mioFy
222:            iunit.WriteLine(Trigon.FormatS(Strtp(2), 8))
223:            iunit.WriteLine(Trigon.FormatS(Strtp(3), x0 / 10, y0 / 10))
224:            iunit.WriteLine(Trigon.FormatS(Strtp(3), x1 / 10, y1 / 10))
            Case 2
                LineaDXF(x0, y0, x1, y1)
            Case 3
                x1 = x1 / mioFx
                x0 = x0 / mioFx
                y1 = y1 / mioFy
                y0 = y0 / mioFy
                startPoint(0) = x0 : startPoint(1) = y0
                endPoint(0) = x1 : endPoint(1) = y1
                lineaA = AcadBlock.AddLine(startPoint, endPoint)
            Case 4
                LineaRTF(x0, y0, x1, y1)
                'Case 5
                '      ScalaRel x0, y0, x1, y1
        End Select
    End Sub
    Public Sub quadrato(ByVal x1 As Single, ByVal y1 As Single, ByVal x2 As Single, ByVal y2 As Single, _
    ByVal SP As Single, ByVal Tipo As Short, ByVal Fill As Boolean)
        Dim Rett As AutoCAD.Acad3DSolid
        Dim inspoint(2) As Double
        x1 = x1 / mioFx
        x2 = x2 / mioFx
        y1 = y1 / mioFy
        y2 = y2 / mioFy
        Select Case SwIUNpri
            Case 1
                '?????????????
            Case 2
            Case 3
                inspoint(0) = (x1 + x2) / 2
                inspoint(1) = (y1 + y2) / 2
                Rett = AcadBlock.AddWedge(inspoint, Math.Abs(x2 - x1), Math.Abs(y2 - y1), 0.001)
        End Select
        tipolinea = Tipo
        Penna.DashStyle = ConvertDash(tipolinea)
        If Fill Then
            gDove.FillRectangle(Pennello, x1, y1, Math.Abs(x2 - x1), Math.Abs(y2 - y1))
        Else
            gDove.DrawRectangle(Penna, x1, y1, Math.Abs(x2 - x1), Math.Abs(y2 - y1))
        End If
    End Sub
    Public Property DoveDisegno() As PictureBox
        Get
            DoveDisegno = Dove
        End Get
        Set(ByVal Value As PictureBox)
            Try
                Dove = Value
                If Not Value Is Nothing Then
                    If Not gDove Is Nothing Then gDove.Dispose()
                    DoveDisegnogPic = Value.CreateGraphics
                    DoveBitmap = New Bitmap(Value.ClientRectangle.Width, Value.ClientRectangle.Height, DoveDisegnogPic)
                    DoveDisegnog = Graphics.FromImage(DoveBitmap)
                    Value.Image = DoveBitmap
                End If
            Catch e As Exception
                MsgBox(e.Message + vbCrLf + e.StackTrace)
            End Try
        End Set
    End Property
    Public Property DoveBitmap() As Drawing.Bitmap
        Get
            DoveBitmap = bm
        End Get
        Set(ByVal Value As Drawing.Bitmap)
            bm = Value
        End Set
    End Property
    Public Property DoveDisegnog() As Drawing.Graphics
        Get
            DoveDisegnog = gDove
        End Get
        Set(ByVal Value As Drawing.Graphics)
            gDove = Value
        End Set
    End Property
    Public Property DoveDisegnogPic() As Drawing.Graphics
        Get
            DoveDisegnogPic = gDovePic
        End Get
        Set(ByVal Value As Drawing.Graphics)
            gDovePic = Value
        End Set
    End Property
    Public WriteOnly Property DoveScrivere() As Short
        Set(ByVal Value As Short)
            IUNL = Value
        End Set
    End Property
    Public WriteOnly Property DoveInizio() As RoutBase1.clsInizio
        Set(ByVal Value As RoutBase1.clsInizio)
            gInizio = Value
        End Set
    End Property
    Public Sub New()
        MyBase.New()
        NPUMAX = 500
        If Trigon Is Nothing Then Trigon = New clsTrigon
    End Sub
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
    Function colora(ByVal thk As Single, ByVal Layer As String) As Short
        Select Case thk
            Case Is > 0.6 : colora = 0 : Layer = "0"
            Case Is < 0.15 : colora = 1 : Layer = "1"
            Case 0.15 To 0.2 : colora = 2 : Layer = "2"
            Case 0.2 To 0.3 : colora = 3 : Layer = "3"
            Case 0.3 To 0.4 : colora = 4 : Layer = "4"
            Case 0.4 To 0.5 : colora = 5 : Layer = "5"
            Case 0.5 To 0.6 : colora = 6 : Layer = "6"
        End Select
    End Function
    Function txindxf(ByVal txt As String) As String
        Dim j, ll As Short
        Dim txp, txf As String
        Dim k As String
        For j = 1 To 3
            k = CStr(InStr(txt, acastri(j, 2)))
            While CDbl(k) <> 0
                ll = CShort(Len(txt) - CDbl(k))
                txp = Mid(txt, 1, CInt(Val(k) - 1))
                txf = Mid(txt, CInt(Val(k) + 1), ll)
                txt = txp & acastri(j, 1) & txf
                k = CStr(InStr(txt, acastri(j, 2)))
            End While
        Next j
        txindxf = txt
    End Function
    Public Sub ArcDXF(ByVal xc As Single, ByVal yc As Single, ByVal R As Single, ByVal x1 As Single, ByVal y1 As Single, ByVal Alfa As Single)
        Dim Alfaa, sgx, sgy, Alfap As Single
        Dim alx As Single
        If Math.Abs(Alfa) >= 359.9 Then
1460:       iunit.WriteLine("CIRCLE")
            iunit.WriteLine(8)
            iunit.WriteLine(Layer)
            iunit.WriteLine(6)
            iunit.WriteLine(tipli)
            iunit.WriteLine(62)
            iunit.WriteLine(Ncolo)
            iunit.WriteLine(10)
1480:       iunit.WriteLine(roundb(2, xc))
            iunit.WriteLine(20)
            iunit.WriteLine(roundb(2, yc))
            iunit.WriteLine(40)
            iunit.WriteLine(roundb(2, R))  'D
            iunit.WriteLine(0)
        Else
1490:       iunit.WriteLine("ARC")
            iunit.WriteLine(8)
            iunit.WriteLine(Layer)
            iunit.WriteLine(6)
            iunit.WriteLine(tipli)
            iunit.WriteLine(62)
            iunit.WriteLine(Ncolo)
            iunit.WriteLine(10)
1500:       iunit.WriteLine(roundb(2, xc))
            iunit.WriteLine(20)
1502:       iunit.WriteLine(roundb(2, yc))
            iunit.WriteLine(40)
1504:       iunit.WriteLine(roundb(2, R))  'D
            iunit.WriteLine(50)
            sgx = Math.Sign(x1 - xc)
            sgy = Math.Sign(y1 - yc)
1519:       alx = CSng(Math.Asin(Math.Abs(y1 - yc) / R) * 180 / Math.PI)
            Alfap = polare(sgx, sgy, alx)
            Alfaa = Alfa + Alfap
            If Alfaa > 360 Then Alfaa = Alfaa - 360
            If Alfa < 0 Then Trigon.SWAP(Alfap, Alfaa)
1530:       iunit.WriteLine(roundb(2, Alfap))
            iunit.WriteLine(51)
            iunit.WriteLine(roundb(2, Alfaa))
            iunit.WriteLine(0)
        End If
    End Sub
    Public Sub LineaDXF(ByVal x0 As Single, ByVal y0 As Single, ByVal x1 As Single, ByVal y1 As Single)
        ProgText = ProgText + 1
        iunit.WriteLine("LINE")
        x1 = x1 / mioFx
        x0 = x0 / mioFx
        y1 = y1 / mioFy
        y0 = y0 / mioFy
        If Ac2000 Then
            iunit.WriteLine(5)
            iunit.WriteLine(Hex(ProgText))
            iunit.WriteLine("330")
            iunit.WriteLine("1E")
            iunit.WriteLine(100)
            iunit.WriteLine("AcDbEntity")
        End If
        iunit.WriteLine(8)
        iunit.WriteLine(Layer)
        iunit.WriteLine(6)
        iunit.WriteLine(tipli)
        iunit.WriteLine(62)
        iunit.WriteLine(Ncolo)
        If Ac2000 Then
            iunit.WriteLine(100)
            iunit.WriteLine("AcDbLine")
        End If
        iunit.WriteLine(10)
        iunit.WriteLine(roundb(2, x0))
        iunit.WriteLine(20)
        iunit.WriteLine(roundb(2, y0))
        iunit.WriteLine(11)
        iunit.WriteLine(roundb(2, x1))
        iunit.WriteLine(21)
        iunit.WriteLine(roundb(2, y1))
        iunit.WriteLine(0)
    End Sub
    Public Sub InitAcad(ByVal block As AutoCAD.AcadBlock) 'AutoCad.AcadBlock)
        SwIUNpri = 3
        AcadBlock = block
    End Sub
    Public Sub ChiudiAcad()
        SwIUNpri = 0
    End Sub
    Private Sub ScalaRel(ByVal x1 As Single, ByVal y1 As Single, ByVal x2 As Single, ByVal y2 As Single)
        If Math.Abs(x1) > 1000 Or Math.Abs(x2) > 1000 Or Math.Abs(y1) > 1000 Or Math.Abs(y2) > 1000 Then Stop
        If x1 < xmin Then xmin = x1
        If y1 < ymin Then ymin = y1
        If x2 > xmax Then xmax = x2
        If y2 > ymax Then ymax = y2
    End Sub
    Public Sub Scalainit()
        xmin = clsTrigon.Infinito
        ymin = clsTrigon.Infinito
        xmax = -clsTrigon.Infinito
        ymax = -clsTrigon.Infinito
        offxWin = 0 : offyWin = 0
        ScalaWinx = 1 : ScalaWiny = 1
    End Sub
    Public Sub Ruota(ByVal Polx As Single, ByVal Poly As Single, ByRef X As Single, ByRef y As Single, ByVal Beta As Single)
        Dim d, a As Single
        d = CSng(Math.Sqrt((Polx - X) ^ 2 + (Poly - y) ^ 2))
        If d < clsTrigon.TOLER Then Exit Sub
        a = Trigon.arco((X - Polx) / d, (y - Poly) / d)
        a = a + Beta
        X = CSng(Polx - d * Math.Cos(a))
        y = CSng(Poly + d * Math.Sin(a))
    End Sub
    Public Sub ApriGruppo()
        iunit.WriteLine("{\shpgrp")
    End Sub
    Public Sub ChiudiGruppo()
        iunit.WriteLine("}")
    End Sub
    Public Sub IniziaBlocco(ByVal Nome As String)
        Dim inspoint(2) As Double
        If Not SwIUNpri = 3 Then Exit Sub
        AcadBlock = AcadDoc.Blocks.Add(inspoint, Nome)
    End Sub
    Public Sub FinisciBlocco(ByVal Nome As String)
        Dim inspoint(2) As Double
        If Not SwIUNpri = 3 Then Exit Sub
        BlockRef = AcadDoc.ModelSpace.InsertBlock(inspoint, Nome, 1, 1, 1, 0)
        AcadDoc.Application.Update()
    End Sub
    Public Sub TextDXF(ByVal xo As Single, ByVal yo As Single, ByVal ht As Single, ByVal txt As String, ByVal Alfa As Single)
        x0 = x0 / mioFx
        yo = yo / mioFy
        ProgText = ProgText + 1
        iunit.WriteLine("TEXT")
        If Ac2000 Then
            iunit.WriteLine(5)
            iunit.WriteLine(Hex(ProgText))
            iunit.WriteLine("330")
            iunit.WriteLine("1E")
            iunit.WriteLine(100)
            iunit.WriteLine("AcDbEntity")
        End If
        iunit.WriteLine(8)
        iunit.WriteLine(Layer)
        iunit.WriteLine(6)
        iunit.WriteLine(tipli)
        iunit.WriteLine(62)
        iunit.WriteLine(Ncolo)
        If Ac2000 Then
            iunit.WriteLine(100)
            iunit.WriteLine("AcDbText")
        End If
        iunit.WriteLine(10)
        iunit.WriteLine(roundb(2, xo))
        iunit.WriteLine(20)
        iunit.WriteLine(roundb(2, yo))
        iunit.WriteLine(30)
        iunit.WriteLine(0)
        iunit.WriteLine(40)
        iunit.WriteLine(roundb(2, ht))
        iunit.WriteLine(1)
        iunit.WriteLine(txindxf(txt))
        iunit.WriteLine(50)
        iunit.WriteLine(roundb(2, Alfa))
        If Ac2000 Then
            iunit.WriteLine(100)
            iunit.WriteLine("AcDbText")
        End If
        iunit.WriteLine(0)
    End Sub
    Public Function PesoLinea() As AutoCAD.AcLineWeight
        Select Case Spessore
            Case 0.1 : PesoLinea = AutoCAD.AcLineWeight.acLnWt020
            Case 0.2 : PesoLinea = AutoCAD.AcLineWeight.acLnWt030
            Case 0.3 : PesoLinea = AutoCAD.AcLineWeight.acLnWt040
            Case 0.4 : PesoLinea = AutoCAD.AcLineWeight.acLnWt050
            Case Else : PesoLinea = AutoCAD.AcLineWeight.acLnWtByLayer
        End Select
    End Function
    Public Property PennaFill() As SolidBrush
        Get
            If Pennello Is Nothing Then Pennello = New SolidBrush(Color.Black)
            Return Pennello
        End Get
        Set(ByVal Value As SolidBrush)
            Pennello = Value
        End Set
    End Property
    Public Sub DisplayHelp(ByRef pictHelp As PictureBox, ByRef c As Control, ByRef Testo As String, ByRef X As Single, ByRef y As Single, ByRef Relativo As Boolean)
        Static xVec, yVec As Single
        If xVec = X And yVec = y And Not (X = 0 And y = 0) Then Exit Sub
        xVec = X : yVec = y
        Dim TopL, LeftL As Single
        Dim n As Integer
        Dim w, wl As Integer
        Dim gPictHelp As Graphics = pictHelp.CreateGraphics
        Try
            pictHelp.Visible = Testo.Trim.Length > 0
            If Testo.Trim.Length = 0 Then Exit Sub
            Testo = gInizio.ConvertiCr(Testo)
            pictHelp.BringToFront()
            gPictHelp.Clear(Color.Yellow)
            Dim s As String() = Testo.Split(Chr(13))
            Dim sottostr As String
            w = 0
            n = 0
            For Each sottostr In s
                wl = CInt(gPictHelp.MeasureString(sottostr, pictHelp.Font).Width)
                If wl > w Then w = wl
                n += 1
            Next
            pictHelp.Height = CInt(gPictHelp.MeasureString(Testo, pictHelp.Font).Height)  ' CInt(gPIctHelp.MeasureString(Testo, PIctHelp.Font).Height + Trigon.TwipsToPIxelsY(50))
            pictHelp.Width = CInt(gPictHelp.MeasureString(Testo, pictHelp.Font).Width)  '+ Trigon.TwipsToPIxelsY(50))
            WorldToMouse(X, y)
            TopL = CSng(c.Top + y + Trigon.TwipsToPixelsY(200))
            LeftL = CSng(c.Left + X + Trigon.TwipsToPixelsX(200))
            If Relativo Then
                TopL = TopL + c.Parent.Top
                LeftL = LeftL + c.Parent.Left
            End If
            If TopL + pictHelp.Height >= c.Parent.Height Then TopL = CSng(TopL - pictHelp.Height - Trigon.TwipsToPixelsY(400))
            If LeftL + pictHelp.Width >= c.Parent.Width Then LeftL = CSng(LeftL - pictHelp.Width - Trigon.TwipsToPixelsX(400))
            pictHelp.Top = CInt(TopL)
            pictHelp.Left = CInt(LeftL)
            Dim bm As Bitmap = New Bitmap(pictHelp.ClientRectangle.Width, pictHelp.ClientRectangle.Height, gPictHelp)
            gPictHelp = Graphics.FromImage(bm)
            pictHelp.Image = bm
            gPictHelp.DrawString(Testo, pictHelp.Font, New SolidBrush(Color.Black), 0, 0)
            pictHelp.Visible = True
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
End Class