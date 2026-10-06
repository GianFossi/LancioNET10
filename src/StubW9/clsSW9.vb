Option Strict On
Option Explicit On
Imports Word
Public Class clsSW9 'wdsavechanges
    Private prApp As Word.Application 'Object '
    Private WithEvents prDoc As Word.Document
    Private prRange As Word.Range
    Private prRanges As New Collection '(1 To 3) As Word.Range
    Private prDocs As New Collection '(1 To 3) As Word.Document
    Event Close()
    Event Open()
    Public ReadOnly Property sBookMarksCount() As Integer
        Get
            Return Doc.Bookmarks.Count
        End Get
    End Property
    Public ReadOnly Property sBookMarksName(ByVal i As Object) As String
        Get
            Return Doc.Bookmarks.Item(i).Name
        End Get
    End Property
    Public Sub FieldsUpdate()
        '   prDoc.TablesOfContents(1).update()
    End Sub
    Public Sub sSelezionaResto(ByVal size As Integer)
        Try
            prRange.EndOf(WdUnits.wdStory, WdMovementType.wdExtend)
            prRange.Font.Size = size
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Public Sub NienteGrammatica()
        With prApp.Options
            .CheckSpellingAsYouType = False
            .CheckGrammarAsYouType = False
            .SuggestSpellingCorrections = False
            .SuggestFromMainDictionaryOnly = False
            .CheckGrammarWithSpelling = False
            .ShowReadabilityStatistics = False
            .IgnoreUppercase = True
            .IgnoreMixedDigits = True
            .IgnoreInternetAndFileAddresses = True
            .AllowCombinedAuxiliaryForms = True
            .EnableMisusedWordsDictionary = True
            .AllowCompoundNounProcessing = False
            .UseGermanSpellingReform = False
        End With
        prDoc.ShowGrammaticalErrors = False
        prDoc.ShowSpellingErrors = False
    End Sub
    Public Sub InsertPreRisc(ByRef n As String)
        prRange = prDoc.Range(0, 0)
        With prRange
            .InsertFile(n)
            .WholeStory()
            .Font.Size = 9
            .ParagraphFormat.FirstLineIndent = 0
        End With
        Pulisci()
    End Sub
    Public Sub sQuit()
        prApp.Quit()
    End Sub
    Public Sub IntestaGr(ByRef Arch As String, ByRef Ass As String)
        prRange.Select()
        With prDoc.ActiveWindow
            If .View.SplitSpecial <> WdSpecialPane.wdPaneNone Then .Panes.Item(2).Close()
            If .ActivePane.View.Type = WdViewType.wdNormalView Or .ActivePane.View.Type = WdViewType.wdOutlineView Or .ActivePane.View.Type = WdViewType.wdMasterView Then
                .ActivePane.View.Type = CType(WdViewTypeOld.wdPageView, WdViewType)
            End If
            .ActivePane.View.SeekView = WdSeekView.wdSeekCurrentPageHeader
            prApp.Selection.TypeText(Text:="Pr. " & Arch)
            prApp.Selection.MoveRight(Unit:=WdUnits.wdCell)
            prApp.Selection.TypeText(Text:="Item " & Ass)
            .ActivePane.View.SeekView = WdSeekView.wdSeekMainDocument
        End With
        prRange = prApp.Selection.Range
    End Sub
    Public Function nDocSec() As Short
        nDocSec = CShort(prDocs.Count())
    End Function
    Public Property App() As Application
        Get 'Word.Application
            App = prApp
        End Get
        Set(ByVal Value As Application) 'Word.Application)
            prApp = Value
        End Set
    End Property
    Public Property Doc() As Document
        Get 'Word.Application
            Doc = prDoc
        End Get
        Set(ByVal Value As Document) 'Word.Application)
            prDoc = Value
        End Set
    End Property
    Public WriteOnly Property sWordRange() As Range
        Set(ByVal Value As Range)
            prRange = Value
        End Set
    End Property
    Public Property sFullName() As String
        Get
            sFullName = prDoc.FullName
        End Get
        Set(ByVal Value As String)

        End Set
    End Property
    Public Property Visible() As Boolean
        Get
            Return prApp.Visible
        End Get
        Set(ByVal Value As Boolean)
            prApp.Visible = Value
        End Set
    End Property
    Public Function Shapes7(ByRef LogoFile As String, Optional ByRef indirFile As String = "") As Boolean
        Dim s As Word.Shape
        Dim Anch As Range
        Dim i As Short
        'UPGRADE_NOTE: Left è stato aggiornato a Left_Renamed. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1061"'
        Dim Top, Left_Renamed As Single
        Dim Tipo As WdWrapType
        Shapes7 = True
        s = prDoc.Shapes.Item("Picture 7")
        Top = s.Top : Left_Renamed = s.Left
        Tipo = s.WrapFormat.Type
        On Error GoTo ExitSub
        s.Delete()
        s = prDoc.Shapes.AddPicture(Anchor:=prApp.Selection.Range, FileName:=LogoFile, LinkToFile:=False, SaveWithDocument:=True)
        s.Top = prApp.CentimetersToPoints(-0.05) ' Top
        s.Left = Left_Renamed
        s.LockAnchor = -1 ' True
        s.WrapFormat.Type = Tipo
        If Len(indirFile) > 0 Then
            s = prDoc.Shapes.Item("Object 6")
            Top = s.Top : Left_Renamed = s.Left
            Tipo = s.WrapFormat.Type
            s.Delete()
            s = prDoc.Shapes.AddPicture(Anchor:=prApp.Selection.Range, FileName:=indirFile, LinkToFile:=False, SaveWithDocument:=True)
            s.Top = Top 'CentimetersToPoints(-0.05)  ' Top
            s.Left = Left_Renamed
            s.LockAnchor = -1 ' True
            s.WrapFormat.Type = Tipo
        End If
        s = prDoc.Sections.Item(1).Headers.Item(WdHeaderFooterIndex.wdHeaderFooterEvenPages).Shapes.Item("Picture 5")
        Top = s.Top : Left_Renamed = s.Left
        Anch = s.Anchor
        s.Delete()
        s = prDoc.Sections.Item(1).Headers.Item(WdHeaderFooterIndex.wdHeaderFooterEvenPages).Shapes.AddPicture(Anchor:=CType(Anch, Range), FileName:=LogoFile, LinkToFile:=False, SaveWithDocument:=True)
        s.Top = Top
        s.Left = Left_Renamed
        s.LockAnchor = -1 ' True.
        s.LockAspectRatio = Office.MsoTriState.msoTrue
        s.Height = 25
ExF:    Exit Function
ExitSub:
        MsgBox("Si è determinato l'errore " & Err.Description & vbCrLf & "durante l'apposizione del logo (Shapes7)", MsgBoxStyle.Critical)
        Shapes7 = False
        Resume ExF
    End Function
    Public Sub FinPag(ByRef Autore As String)
        Dim r As Range
        r = prRange
        r.Select()
        With prApp.Selection
            .TypeText(Autore)
            .MoveRight()
            .MoveRight(WdUnits.wdWord)
            .MoveRight()
            .TypeText(CStr(Today))
        End With
    End Sub
    Public Sub Object6(ByRef LogoFile As String)
        Dim Top, Left_Renamed As Single
        Dim s As Word.Shape
        prDoc.ActiveWindow.ActivePane.View.SeekView = WdSeekView.wdSeekMainDocument
        s = prDoc.Shapes.Item("Object 6")
        s.Select()
        Top = prApp.CentimetersToPoints(-0.05) 's.Top
        Left_Renamed = 252 ' s.Left
        prApp.Selection.ShapeRange.Delete()
        s = prDoc.Shapes.AddPicture(Anchor:=prApp.Selection.Range, FileName:=LogoFile, LinkToFile:=False, SaveWithDocument:=True)
        s.Top = Top
        s.Left = Left_Renamed
        s.LockAnchor = -1 ' True
    End Sub
    Public Sub ASMECap(ByRef Arch As String, ByRef Temp As String, ByRef cap1 As String, ByRef cap2 As String)
        Dim r1, r2 As Range
        Dim locDoc As Document
        '  If prRanges.Count() = 0 Then Exit Sub
        r1 = prRange
        r1.Select()
        prApp.Selection.MoveRight(WdUnits.wdCharacter, 1, WdMovementType.wdMove)
        r1 = prApp.Selection.Range
        VaiInizio(cap2)
        r2 = prRange
        r2.Select()
        prApp.Selection.MoveLeft(WdUnits.wdCharacter, 2, WdMovementType.wdMove)
        r2 = prApp.Selection.Range
        r1.SetRange(r1.Start, r2.End)
        r1.Copy()
        locDoc = prDoc.Application.Documents.Open(Arch & "\Header.doc")
        r2 = locDoc.GoTo(What:=WdGoToItem.wdGoToBookmark, Name:="\StartOfDoc")
        r2.Collapse()
        r2.Paste()
        locDoc.SaveAs(Temp & cap1)
        prDocs.Add(locDoc, cap1)
        r2.Collapse()
        r2.Select()
    End Sub
    Public Function NullRange() As Boolean
        NullRange = (prRange Is Nothing)
    End Function
    Public Property WordDocument() As Document
        Get
            Return prDoc
        End Get
        Set(ByVal Value As Document)
            prDoc = Value
        End Set
    End Property
    Public Sub sOpen(ByRef File As String, Optional ByRef ReadOnly_Renamed As Boolean = False, Optional ByRef nDoc As Short = 0)
        Dim d As Document
        If nDoc = 0 Then
            If Len(File) > 0 Then
                Try
                    prDoc = prApp.Documents.Open(FileName:=CStr(File), ConfirmConversions:=False, ReadOnly:=CBool(ReadOnly_Renamed))   ', True) ', , , , , , , , wdOpenFormatRTF)
                Catch e As Exception
                    MsgBox(e.Message + vbCrLf + e.StackTrace + "prApp nullo " + vbCrLf + (prApp Is Nothing).ToString + vbCrLf + _
                                        "prApp.version=" + prApp.Version + vbCrLf + "FileName=" + File)
                    '                                 "FileName=" + File)
                    Exit Sub
                End Try
            Else
                prDoc = prApp.Documents.Add
            End If
            With prApp.Windows.Item(1)
                If .View.SplitSpecial = WdSpecialPane.wdPaneNone Then
                    .ActivePane.View.Type = WdViewType.wdPrintView
                Else
                    .View.Type = WdViewType.wdPrintView
                End If
            End With
        Else
            If Len(File) > 0 Then
                d = prApp.Documents.Open(FileName:=CStr(File), ConfirmConversions:=False, ReadOnly:=CBool(ReadOnly_Renamed))  ', True) ', , , , , , , , wdOpenFormatRTF)
            Else
                d = prApp.Documents.Add
            End If
            prDocs.Add(d)
        End If
    End Sub
    Public Sub sSaveAs(ByRef File As String, Optional ByRef nDoc As Short = 0)
        If nDoc = 0 Then
            prDoc.SaveAs(CStr(File))
        Else
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto prDocs().SaveAs. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            CType(prDocs.Item(nDoc), Document).SaveAs(CStr(File))
        End If
    End Sub
    Public Sub sSave()
        prDoc.Save()
    End Sub
    Public Sub sView()
        If prDoc.ActiveWindow.View.SplitSpecial = WdSpecialPane.wdPaneNone Then
            prDoc.ActiveWindow.ActivePane.View.Type = CType(WdViewTypeOld.wdPageView, WdViewType)
        Else
            prDoc.ActiveWindow.View.Type = CType(WdViewTypeOld.wdPageView, WdViewType)
        End If
    End Sub
    Public Sub sClose(Optional ByRef m As Short = 0, Optional ByRef nDoc As Short = 0)
        Dim opt As Integer
        If m = 0 Then m = 3
        Select Case m
            Case 1 : opt = WdSaveOptions.wdSaveChanges
            Case 2 : opt = WdSaveOptions.wdPromptToSaveChanges
            Case 3 : opt = WdSaveOptions.wdDoNotSaveChanges
        End Select
        Try
            If nDoc = 0 Then
                prDoc.Close(CInt(opt))
            Else
                CType(prDocs.Item(nDoc), Document).Close(CInt(opt))
                prDocs.Remove(prDocs.Count())
                prRanges.Remove(prRanges.Count())
            End If
        Catch e As Exception
            'MessageBox.Show(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Public Sub sPaste()
        prRange.Select()
        prApp.Selection.MoveRight(WdUnits.wdWord)
        prApp.Selection.MoveRight()
        prRange = prApp.Selection.Range
        prRange.Paste()
    End Sub
    Public Sub sCloseAll(ByRef m As Short)
        Dim opt As Integer
        Dim d As Document
        Select Case m
            Case 1 : opt = WdSaveOptions.wdSaveChanges
            Case 2 : opt = WdSaveOptions.wdPromptToSaveChanges
            Case 3 : opt = WdSaveOptions.wdDoNotSaveChanges
        End Select
        On Error Resume Next
        For Each d In prApp.Documents
            d.Close(CInt(opt))
        Next d
    End Sub
    Public Function SubstitBookM(ByRef b As String, ByRef t As String, Optional ByRef Delete As Boolean = False, Optional ByRef nDoc As Short = 0) As Boolean
        Dim r1 As Range
        Dim Testo As String
        SubstitBookM = True
        Try
            If nDoc = 0 Then
                r1 = prDoc.Bookmarks.Item(CStr(b)).Range
                r1.Text = t
                If Not Delete Then prDoc.Bookmarks.Add(b, CType(r1, Range))
                prRange = r1
            Else
                r1 = CType(prDocs.Item(nDoc), Document).Bookmarks.Item(CStr(b)).Range
                r1.Text = t
                If Not Delete Then CType(prDocs.Item(nDoc), Document).Bookmarks.Add(b, CType(r1, Range))
                If prRanges.Count >= nDoc Then prRanges.Remove(nDoc)
                prRanges.Add(r1)
            End If
        Catch e As Exception
            Testo = "Si è verificato un errore durante la compilazione" & vbCrLf
            Testo = Testo & "del documento " & prDoc.FullName & "," & vbCrLf
            Testo = Testo & "durante la ricerca del segnalibro " & b & "." & vbCrLf
            Testo = Testo & "(" & e.Message & ")"
            MsgBox(Testo, MsgBoxStyle.Critical, "Interfaccia con Word")
            Return False
        End Try
    End Function
    Public Function EliminaRiga(ByRef b As String, Optional ByRef nDoc As Short = 0) As Boolean
        Dim r1 As Range
        Dim Testo As String
        EliminaRiga = True
        Try
            If nDoc = 0 Then
                r1 = prDoc.Bookmarks.Item(CStr(b)).Range
                r1.Expand(WdUnits.wdParagraph)
                r1.Delete()
            Else
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto prDocs().Bookmarks. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                r1 = CType(prDocs.Item(nDoc), Document).Bookmarks.Item(CStr(b)).Range
                r1.Expand(WdUnits.wdParagraph)
                r1.Delete()
            End If
        Catch e As Exception
            Testo = "Si è verificato un errore durante la compilazione" & vbCrLf
            Testo = Testo & "del documento " & prDoc.FullName & "." & vbCrLf
            Testo = Testo & "(" & e.Message & ")" + vbCrLf + e.StackTrace
            MsgBox(Testo, MsgBoxStyle.Critical, "Interfaccia con Word")
            Return False
        End Try
    End Function
    Public Function EliminaCelle(ByVal bStart As String, ByVal bEnd As String, Optional ByVal nDoc As Short = 0) As Boolean
        Dim r1, r2 As Range
        Dim Testo As String
        Dim r3 As Range
        EliminaCelle = True
        Try
            If nDoc = 0 Then
                r1 = prDoc.Bookmarks.Item(CStr(bStart)).Range
                r2 = prDoc.Bookmarks.Item(CStr(bEnd)).Range
                r3 = prDoc.Range(CInt(r1.Start), CInt(r2.End))
            Else
                r1 = CType(prDocs.Item(nDoc), Document).Bookmarks.Item(CStr(bStart)).Range
                r2 = CType(prDocs.Item(nDoc), Document).Bookmarks.Item(CStr(bEnd)).Range
                r3 = CType(prDocs.Item(nDoc), Document).Range(CInt(r1.Start), CInt(r2.End))
            End If
            r3.Cells.Delete(WdDeleteCells.wdDeleteCellsEntireRow)
        Catch e As Exception
            Testo = "Si è verificato un errore durante la compilazione" & vbCrLf
            Testo = Testo & "del documento " & prDoc.FullName & "." & vbCrLf
            Testo = Testo & "(" & e.Message & ")" + vbCrLf + e.StackTrace
            MsgBox(Testo, MsgBoxStyle.Critical, "Interfaccia con Word, EliminaCelle")
            Return False
        End Try
    End Function
    Public Function EliminaRighe(ByVal b As String, ByVal b1 As String, Optional ByVal nDoc As Short = 0) As Boolean
        Dim r1, r2 As Range
        Dim Testo As String
        Dim r3 As Range
        EliminaRighe = True
        Try
            If nDoc = 0 Then
                r1 = prDoc.Bookmarks.Item(CStr(b)).Range
                r1.Expand(WdUnits.wdParagraph)
                r2 = prDoc.Bookmarks.Item(CStr(b1)).Range
                r2.Expand(WdUnits.wdParagraph)
                r3 = prDoc.Range(CInt(r1.Start), CInt(r2.End))
            Else
                r1 = CType(prDocs.Item(nDoc), Document).Bookmarks.Item(CStr(b)).Range
                r1.Expand(WdUnits.wdParagraph)
                r2 = CType(prDocs.Item(nDoc), Document).Bookmarks.Item(CStr(b1)).Range
                r2.Expand(WdUnits.wdParagraph)
                r3 = CType(prDocs.Item(nDoc), Document).Range(CInt(r1.Start), CInt(r2.End))
            End If
            r3.Delete()
        Catch e As Exception
            Testo = "Si è verificato un errore durante la compilazione" & vbCrLf
            Testo = Testo & "del documento " & prDoc.FullName & "." & vbCrLf
            Testo = Testo & "(" & e.Message & ")" + vbCrLf + e.StackTrace
            MsgBox(Testo, MsgBoxStyle.Critical, "Interfaccia con Word, EliminaRighe")
            Return False
        End Try
    End Function
    ' Protected Overrides Sub Finalize()
    '    prDoc = Nothing
    '    MyBase.Finalize()
    'End Sub
    Public Sub BorderBottom()
        prRange.Select()
        prApp.Selection.Expand(WdUnits.wdRow)
        With prApp.Selection.Cells.Borders.Item(WdBorderType.wdBorderBottom)
            .LineWidth = WdLineWidth.wdLineWidth225pt
            .LineStyle = WdLineStyle.wdLineStyleSingle
        End With
    End Sub
    Public Sub Testo(ByRef t As String)
        prRange.Expand(WdUnits.wdParagraph)
        prRange.Text = t
    End Sub
    Public Function GetTesto() As String
        GetTesto = prRange.Text
    End Function
    Public Sub MuoviCella(ByRef n As Short)
        prRange.Move(WdUnits.wdCell, CShort(n))
    End Sub
    Public Sub sInsertParagrahAfter()
        prRange.InsertParagraphAfter()
        prRange.Collapse(WdCollapseDirection.wdCollapseStart)
    End Sub
    Public Sub ASMEMAWP1()
        Dim r As Range
        r = prRange
        r.Move(WdUnits.wdCharacter, -1)
        r.InsertBreak(Type:=WdBreakType.wdPageBreak)
        r.InsertParagraphBefore()
        r.Collapse(WdCollapseDirection.wdCollapseStart)
        prDoc.Bookmarks.Add("MAWP", CType(r, Range))
        r.InsertBefore("Summary of MAWP's")
        r.InsertParagraphAfter()
        r.Move(WdUnits.wdParagraph, 1)
        r.Style = prDoc.Styles.Item("corpo")
        r.Collapse(WdCollapseDirection.wdCollapseStart)
        r.Paste()
        prRange = r
    End Sub
    Public Sub NewCap(ByRef Titolo As String, ByRef break As Boolean)
        Dim r As Range
        r = prRange
        With r
            If break Then .InsertBreak(WdBreakType.wdPageBreak)
            .InsertParagraphAfter()
            .Move(WdUnits.wdParagraph, 1)
            .Text = Titolo
            .Expand(WdUnits.wdParagraph)
            .Style = prDoc.Styles.Item("Titolo 2")
            prDoc.Bookmarks.Add(TogliBlank(Titolo), CType(r, Range))
            .InsertParagraphAfter()
            .Move(WdUnits.wdParagraph, 1)
            .Expand(WdUnits.wdParagraph)
            .Style = prDoc.Styles.Item("corpo")
            .Paste()
        End With
    End Sub
    Public Sub ASMEPI(Optional ByVal Break As Boolean = False, Optional ByVal UnaVolta As Boolean = False)
        Dim r As Range
        r = prRange
        r.Move(WdUnits.wdParagraph, 1)
        r.Collapse(WdCollapseDirection.wdCollapseEnd)
        If Break Then
            r.InsertBreak(Type:=WdBreakType.wdPageBreak) 'Selection.MoveRight
        Else
            If Not UnaVolta Then
                r.Move(WdUnits.wdCharacter, 1)
                r.Collapse(WdCollapseDirection.wdCollapseEnd)
            End If
        End If
        r.Paste()
        prRange = r
    End Sub
    Public Sub ASMEMAWP()
        Dim r, r1 As Range
        r = prRange
        r.Select()
        With prApp.Selection
            .GoTo(What:=WdGoToItem.wdGoToBookmark, Name:="StartMAWP")
            .MoveDown(Unit:=WdUnits.wdLine, Count:=1)
            r = .Range
            r.Expand(WdUnits.wdParagraph)
            .GoTo(What:=WdGoToItem.wdGoToBookmark, Name:="EndMAWP")
            r1 = .Range
        End With
        r.SetRange(r.Start, r1.End)
        r.Select()
        prApp.Selection.Cells.Delete(ShiftCells:=WdDeleteCells.wdDeleteCellsEntireRow)
        prRange = r
    End Sub
    Public Sub MuoviLinea(ByRef n As Short, Optional ByVal Estendi As Boolean = False)
        Dim m As WdMovementType = WdMovementType.wdMove
        If Estendi Then m = WdMovementType.wdExtend
        prRange.Select()
        prApp.Selection.Collapse(WdCollapseDirection.wdCollapseStart)
        prApp.Selection.MoveDown(WdUnits.wdLine, CShort(n), CType(m, Object))
        prRange = prApp.Selection.Range
    End Sub
    Public Sub MuoviParola(ByRef n As Short)
        prRange.Move(WdUnits.wdWord, CShort(n))
    End Sub
    Public Sub LibMatDestra()
        Dim r As Range
        r = prRange
        r.Select()
        prApp.Selection.MoveRight(WdUnits.wdCell)
        prRange = prApp.Selection.Range
    End Sub
    Public Sub LibMatScrivi(ByRef Primo As Boolean, ByRef Mat As String)
        Dim r As Range
        r = prRange
        r.Select()
        With prApp.Selection
            If Not Primo Then
                .MoveRight(Unit:=WdUnits.wdCell, Count:=8)
                .MoveLeft(Unit:=WdUnits.wdCell, Count:=8)
            End If
            .MoveRight(Unit:=WdUnits.wdCharacter, Count:=8, Extend:=WdMovementType.wdExtend)
            .Cells.Merge()
            .MoveLeft(Unit:=WdUnits.wdCharacter, Count:=1)
            If Primo Then .MoveRight(Unit:=WdUnits.wdCharacter, Count:=5, Extend:=WdMovementType.wdExtend)
            Primo = False
            .TypeText(Text:=Trim(Mat))
            .Expand(WdUnits.wdParagraph)
            .Font.Size = 12
            .Font.Bold = -1 ' True
            .Collapse(WdCollapseDirection.wdCollapseEnd)
        End With
        r.Move(WdUnits.wdCell, 1)

    End Sub
    Public Sub sCollapse(ByRef d As Short)
        prRange.Select()
        prApp.Selection.Collapse(CShort(d))
        prRange = prApp.Selection.Range
    End Sub
    Public Sub ScriviBM(ByRef nome As String, ByRef Descr As String)
        prRange = prDoc.Bookmarks.Item(CStr(nome)).Range
        prRange.Select()
        If Len(Descr) > 0 Then prApp.Selection.TypeText(Descr)
    End Sub
    Public Sub Riempi(ByRef b As String, ByRef Comm As String, ByRef Numero As String)
        prDoc.Bookmarks.Item(CStr(b)).Range.Select()
        With prApp.Selection
            .MoveRight(Extend:=WdMovementType.wdExtend)
            .TypeText(Mid(Comm, 1, 1))
            .MoveLeft()
            prDoc.Bookmarks.Add(b, .Range)
            .MoveRight(Count:=2)
            .MoveRight(Extend:=WdMovementType.wdExtend)
            .TypeText(Mid(Comm, 2, 1))
            .MoveRight()
            .MoveRight(Extend:=WdMovementType.wdExtend)
            .TypeText(Mid(Comm, 3, 1))
            .MoveRight()
            .MoveRight(Extend:=WdMovementType.wdExtend)
            .TypeText(Mid(Comm, 4, 1))
            .MoveRight(Count:=3)
            .MoveRight(Extend:=WdMovementType.wdExtend)
            .TypeText(Mid(Comm, 5, 1))
            .MoveRight()
            .MoveRight(Extend:=WdMovementType.wdExtend)
            .TypeText(Mid(Comm, 6, 1))
            .MoveRight(Count:=3)
            .MoveRight(Extend:=WdMovementType.wdExtend)
            .TypeText(Mid(Numero, 1, 1))
            .MoveRight()
            .MoveRight(Extend:=WdMovementType.wdExtend)
            .TypeText(Mid(Numero, 2, 1))
            .MoveRight(Count:=3)
            .MoveRight(Extend:=WdMovementType.wdExtend)
            .TypeText(Mid(Numero, 3, 1))
            .MoveRight()
            .MoveRight(Extend:=WdMovementType.wdExtend)
            .TypeText(Mid(Numero, 4, 1))
            .MoveRight()
            .MoveRight(Extend:=WdMovementType.wdExtend)
            .TypeText(Mid(Numero, 5, 1))
        End With

    End Sub
    Public Sub sTypeParagraph()
        prRange.Select()
        prApp.Selection.Collapse(WdCollapseDirection.wdCollapseEnd)
        prApp.Selection.TypeParagraph()
        prApp.Selection.MoveRight(Unit:=WdUnits.wdCharacter)
        prRange = prApp.Selection.Range
    End Sub
    Public Sub sInsertBreak()
        prRange.Select()
        prApp.Selection.InsertBreak(Type:=WdBreakType.wdPageBreak)
        prRange = prApp.Selection.Range
    End Sub
    Public Sub WaldInsert(ByRef FileTxt As String, ByRef Libreria As Short)
        prDoc.Select()
        With prApp.Selection
            .InsertFile(FileTxt)
            .WholeStory()
            .Font.Size = 9
            .ParagraphFormat.FirstLineIndent = 0
            If Libreria = 1 Then
                .ParagraphFormat.SpaceBefore = 0
                .ParagraphFormat.SpaceBeforeAuto = 0 ' False
                .ParagraphFormat.SpaceAfter = 0
                .ParagraphFormat.SpaceAfterAuto = 0 ' False
                .ParagraphFormat.CharacterUnitLeftIndent = 0
                .ParagraphFormat.CharacterUnitRightIndent = 0
                .ParagraphFormat.CharacterUnitFirstLineIndent = 0
                .ParagraphFormat.LineUnitBefore = 0
                .ParagraphFormat.LineUnitAfter = 0
            End If
        End With
        Pulisci()
    End Sub
    Public Sub CollapseStart()
        prRange.Collapse(WdCollapseDirection.wdCollapseStart)
    End Sub
    Public Function Pulisci() As Short
        Dim Primo As Boolean
        Dim p As Paragraph
        Dim r As Range
        Dim i As Short
        Primo = True
        On Error GoTo ExClose2
        For Each p In prDoc.Paragraphs
            If p.Range.Characters.Item(1).Text = "1" Then
                i += CShort(1)
                r = p.Range.Characters.Item(1)
                r.Text = " "
                If Not Primo Then
                    r.Collapse()
                    r.InsertBreak()
                End If
                Primo = False
            End If
        Next p
        Pulisci = i
Ex:     Exit Function
ExClose2: Resume Ex

    End Function
    Public Sub sInsertFile(ByRef nome As String)
        prDoc.Select()
        With prApp.Selection
            .EndKey(Unit:=WdUnits.wdStory)
            .TypeParagraph()
            .InsertBreak(Type:=WdBreakType.wdPageBreak)
            .InsertFile(FileName:=nome, Range:="", ConfirmConversions:=False, Link:=False, Attachment:=False)
        End With
    End Sub
    Public Sub sLogo(ByRef t As String, Optional ByRef bm As String = "logo")
        On Error GoTo Fine
        If Not bm = "fermo" Then
            prRange = prDoc.Bookmarks.Item(CStr(bm)).Range
            prRange.Text = ""
        End If
        Dim Logo As InlineShape = prRange.InlineShapes.AddPicture(FileName:=t, LinkToFile:=False, SaveWithDocument:=True)
Fine:
    End Sub
    Public Function Logo(ByRef t As String, Optional ByRef bm As String = "logo") As InlineShape
        On Error GoTo Fine
        If Not bm = "fermo" Then
            prRange = prDoc.Bookmarks.Item(CStr(bm)).Range
            prRange.Text = ""
        End If
        Logo = prRange.InlineShapes.AddPicture(FileName:=t, LinkToFile:=False, SaveWithDocument:=True)
Fine:
    End Function
    Public Sub IntestLogo(ByRef LogoFile As String, Optional ByRef factor As Single = 0)
        Dim s As InlineShape
        Dim Documento As Document
        Documento = prDoc
        If Len(LogoFile) > 0 Then
            If Not Right(LogoFile, 1) = "\" Then
                If IO.File.Exists(LogoFile) Then
                    If Documento.Sections.Item(1).Headers.Item(WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InlineShapes.Count > 0 Then
                        s = Documento.Sections.Item(1).Headers.Item(WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InlineShapes.Item(1)
                        s.Select()
                        prApp.Selection.Delete()
                        s = prApp.Selection.InlineShapes.AddPicture(FileName:=LogoFile, LinkToFile:=False, SaveWithDocument:=True)
                        '                        s = Documento.Sections.Item(1).Headers.Item(WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InlineShapes.AddPicture(FileName:=LogoFile, LinkToFile:=False, SaveWithDocument:=True)
                        s.LockAspectRatio = Office.MsoTriState.msoTrue ' MsoTriState.msoTrue ' True
                        If factor > 0 Then
                            s.Height = s.Height * factor
                            s.Width = s.Width * factor
                        End If
                        If prDoc.ActiveWindow.View.SplitSpecial = WdSpecialPane.wdPaneNone Then
                            prDoc.ActiveWindow.ActivePane.View.Type = WdViewType.wdPrintView
                        Else
                            prDoc.ActiveWindow.View.Type = WdViewType.wdPrintView
                        End If
                    End If
                End If
            End If
        End If
    End Sub
    Public Sub Copia(Optional ByRef nDoc As Short = 0)
        If nDoc = 0 Then
            prRange.WholeStory()
            prRange.Copy()
        Else
            CType(prRanges.Item(nDoc), Range).WholeStory()
            CType(prRanges.Item(nDoc), Range).Copy()
        End If
    End Sub
    Public Function ApplicaStile(ByRef t As String) As Short
        prRange.Style = prDoc.Styles.Item(CStr(t))
    End Function
    Public Function VaiFine(ByVal t As String) As Integer
        With prApp.Selection
            .ExtendMode = True
            VaiInizio(t, , True)
            .MoveRight(WdUnits.wdCharacter)
            .ExtendMode = False
        End With
    End Function
    Public Function VaiInizio(Optional ByRef t As String = "", Optional ByRef nDoc As Short = 0, Optional ByRef Sel As Boolean = False, Optional ByVal Del As Boolean = False) As Integer
        Dim r As Range
        Try
            If t = "" Then t = "\StartOfDoc"
            If nDoc = 0 Then
                If Sel Then
                    prRange = prApp.Selection.GoTo(WdGoToItem.wdGoToBookmark, , , CStr(t))
                Else
                    prRange = prDoc.GoTo(WdGoToItem.wdGoToBookmark, , , CStr(t))
                End If
                r = prRange
                If Del Then prDoc.Bookmarks.Item(CStr(t)).Delete()
            Else
                r = CType(prDocs.Item(nDoc), Document).GoTo(WdGoToItem.wdGoToBookmark, , , CStr(t))
                If prRanges.Count() = nDoc Then
                    prRanges.Remove(nDoc)
                End If
                prRanges.Add(r)
                If Del Then CType(prDocs.Item(nDoc), Document).Bookmarks.Item(CStr(t)).Delete()
            End If
            If Sel Then r.Select()
        Catch e As Exception
            Return 1
        End Try
    End Function
    Public Sub AggiungiLinea(ByRef x1 As Single, ByRef y1 As Single, ByRef x2 As Single, ByRef y2 As Single)
        Dim s As Word.Shape
        Dim d As Single
        Dim y1a, x1a, x2a, y2a As Single
        s = prApp.ActiveDocument.Shapes.AddLine(20, 20, 20, 20, CType(prRange, Range))
        s.Line.Weight = 0.75
        s.Line.DashStyle = Office.MsoLineDashStyle.msoLineSolid
        s.Line.Style = Office.MsoLineStyle.msoLineSingle
        s.RelativeHorizontalPosition = WdRelativeHorizontalPosition.wdRelativeHorizontalPositionPage
        s.RelativeVerticalPosition = WdRelativeVerticalPosition.wdRelativeVerticalPositionPage
        x1a = x1 : x2a = x2 : y1a = y1 : y2a = y2
        If x2a < x1a Then
            d = x1a
            x1a = x2a
            x2a = d
        End If
        If y2a < y1a Then
            d = y1a
            y1a = y2a
            y2a = d
        End If
        s.Top = prApp.CentimetersToPoints(x1a / 100)
        s.Left = prApp.CentimetersToPoints(y1a / 100)
        s.Width = prApp.CentimetersToPoints((y2a - y1a) / 100)
        s.Height = prApp.CentimetersToPoints((x2a - x1a) / 100)

    End Sub
    Public Sub AggiungiCasella(ByRef xo As Single, ByRef yo As Single, ByRef txt As String)
        Dim s As Word.Shape
        s = prApp.ActiveDocument.Shapes.AddTextbox(CType(1, Office.MsoTextOrientation), 20, 20, 20, 20, CType(prRange, Range))
        'msoTextOrientationHorizontal=1
        s.Fill.Visible = Office.MsoTriState.msoFalse ' MsoTriState.msoFalse ' False
        s.Line.Visible = Office.MsoTriState.msoFalse ' MsoTriState.msoFalse ' False
        With s.TextFrame
            .TextRange.Text = txt
            .MarginBottom = 0
            .MarginLeft = 0
            .MarginRight = 0
            .MarginTop = 0
        End With
        'S.Name = "Testo3"
        Do While s.TextFrame.Overflowing
            s.Width = CSng(1.1 * s.Width)
            If prApp.PointsToCentimeters(s.Width) > 20 Then Exit Do
            ' S.Height = S.Height * 1.1
        Loop
        s.RelativeHorizontalPosition = WdRelativeHorizontalPosition.wdRelativeHorizontalPositionPage
        s.RelativeVerticalPosition = WdRelativeVerticalPosition.wdRelativeVerticalPositionPage
        s.Left = prApp.CentimetersToPoints(xo / 100)
        s.Top = prApp.CentimetersToPoints(yo / 100)

    End Sub
    Public Sub Massimizza()
        prDoc.Application.Visible = True
        prDoc.Application.WindowState = WdWindowState.wdWindowStateMaximize
        prDoc.ActiveWindow.ActivePane.View.ShowAll = False
        App.Activate()
        '        AppActivate(prDoc.Application.Caption)
    End Sub
    Public Sub Minimizza()
        Try
            prDoc.Application.WindowState = WdWindowState.wdWindowStateMinimize
        Catch ex As Exception
        End Try
    End Sub
    Public Sub ASMESinistra(ByRef v As Boolean)
        Dim r As Range
        r = prRange
        r.Select()
        With prApp.Selection
            .MoveLeft(WdUnits.wdWord, 1, WdMovementType.wdExtend)
            .Font.Bold = CInt(v)
            .Collapse(WdCollapseDirection.wdCollapseEnd)
        End With
    End Sub
    Public Sub BMAdd(ByRef s As String)
        prDoc.Bookmarks.Add(s, CType(prRange, Range))
    End Sub
    Public Sub MuoviCaratt(ByRef n As Short)
        prRange.Move(WdUnits.wdCharacter, CShort(n))
    End Sub
    Public Sub MuoviRiga(ByRef n As Short)
        prRange.Move(WdUnits.wdRow, CShort(n))
    End Sub
    Public Sub InserisciRiga(ByRef n As Short)
        prRange.Select()
        prApp.Selection.InsertRows(CShort(n))
        prRange = prApp.Selection.Range
    End Sub
    Public Sub sStile(ByRef nome As String)
        prApp.Selection.Style = prDoc.Styles.Item(CStr(nome)).NameLocal
    End Sub
    Public Sub NascondiTestoNascosto()
        prDoc.ActiveWindow.View.ShowHiddenText = False
    End Sub
    Public Sub VediTestoNascosto()
        prDoc.ActiveWindow.View.ShowHiddenText = True
    End Sub
    Public Sub OreTabelle(ByRef Righe As Short, ByRef Colonne As Short, ByRef Ret As Boolean)
        Dim t As Table
        prDoc.ActiveWindow.ActivePane.View.ShowAll = False
        prRange = prDoc.GoTo(WdGoToItem.wdGoToBookmark, , , "\StartOfDoc")
        prRange.Select()
        prApp.Selection.Font.Size = 8
        prRange.InsertParagraphAfter()
        prRange.Move(WdUnits.wdParagraph, 1)
        t = prDoc.Tables.Add(prRange, Righe, Colonne, WdDefaultTableBehavior.wdWord8TableBehavior)
        If Ret Then Exit Sub
        t.Columns.Item(1).Width = prApp.CentimetersToPoints(1.8)
        t.Columns.Item(2).Width = prApp.CentimetersToPoints(1.3)
        t.Columns.Item(3).Width = prApp.CentimetersToPoints(6.0#)
        t.Columns.Item(4).Width = prApp.CentimetersToPoints(6.0#)
        t.Columns.Item(5).Width = prApp.CentimetersToPoints(1.1)
        t.Columns.Item(6).Width = prApp.CentimetersToPoints(0.9)
    End Sub
    Public Sub OreLavSub1(ByRef Colonne As Short)
        prRange.Move(WdUnits.wdCell, -1)
        prRange.Select()
        prApp.Selection.MoveLeft(Unit:=WdUnits.wdSentence, Count:=CShort(Colonne), Extend:=WdMovementType.wdExtend)
        prApp.Selection.Font.Bold = -1 ' True
        prRange.Collapse(WdCollapseDirection.wdCollapseEnd)
        prRange.Move(WdUnits.wdCell, 1)

    End Sub
    Public Sub TastoTab()
        prRange.Select()
        prApp.Selection.MoveRight(WdUnits.wdCell)
        prRange = prApp.Selection.Range
    End Sub
    Public Sub VentilPict(ByRef FileP As String)
        Dim inls As InlineShape
        prRange = prDoc.GoTo(WdGoToItem.wdGoToBookmark, , , "\StartOfDoc")
        inls = prDoc.InlineShapes.AddPicture(FileP, False, True, CType(prRange, Range))
        prRange.PageSetup.TopMargin = prApp.CentimetersToPoints(1.25)
        prRange.PageSetup.BottomMargin = prApp.CentimetersToPoints(1.25)
        inls.PictureFormat.CropLeft = 51.02
        inls.PictureFormat.CropRight = 51.02
        inls.PictureFormat.CropTop = 28.35
        inls.PictureFormat.CropBottom = 28.35
        inls.LockAspectRatio = Office.MsoTriState.msoFalse ' False
        inls.Height = prApp.CentimetersToPoints(26.9)
        inls.Width = prApp.CentimetersToPoints(16.8)
    End Sub
    Public Sub TestaDS(ByRef t As String, ByRef s As String)
        With prRange
            .InsertParagraphAfter()
            .Move(WdUnits.wdParagraph, 1)
            .Style = prDoc.Styles.Item(CStr(s))
            .InsertBefore(t)
        End With
    End Sub
    Public Sub StampaNota(ByRef Nota As String, ByRef n As Short)
        Dim r1 As Range
        r1 = prRange.Characters.Item(n + 2)
        r1.Collapse(WdCollapseDirection.wdCollapseEnd)
        prDoc.Footnotes.Add(r1, , CStr(Nota))
        prRange.Expand(WdUnits.wdParagraph)
        prRange.Collapse(WdCollapseDirection.wdCollapseEnd)
    End Sub
    Public Sub Espandi()
        With prRange
            .Expand(WdUnits.wdParagraph)
            .Collapse(WdCollapseDirection.wdCollapseEnd)
            .InsertParagraphAfter()
            .Collapse(WdCollapseDirection.wdCollapseEnd)
            .Select()
        End With
        prRange = prApp.Selection.Range
    End Sub
    Public Sub HTRI(ByRef FileStam As String)
        prDoc.Paragraphs.Add(prDoc.Paragraphs.Item(1).Range)
        With prDoc.Paragraphs.Item(1).Range
            .Text = "File:" & FileStam
            .Font.Name = "Arial"
            .Font.Size = 8
        End With
        prDoc.Paragraphs.Item(1).Format.Alignment = WdParagraphAlignment.wdAlignParagraphCenter
    End Sub
    'Public Sub Saddles()
    '    Try
    '        With prApp.Selection
    '            .MoveDown(Count:=8)
    '            .PasteSpecial(Link:=False, DataType:=WdPasteDataType.wdPasteOLEObject, Placement:=WdOLEPlacement.wdFloatOverText, DisplayAsIcon:=False)
    '            .ShapeRange.Height = 434.85
    '            .ShapeRange.Width = 438.25
    '            .ShapeRange.RelativeHorizontalPosition = WdRelativeHorizontalPosition.wdRelativeHorizontalPositionColumn
    '           .ShapeRange.RelativeVerticalPosition = WdRelativeVerticalPosition.wdRelativeVerticalPositionParagraph
    '            .ShapeRange.Left = prApp.CentimetersToPoints(0)
    '            .ShapeRange.Top = prApp.CentimetersToPoints(0)
    '            .HomeKey(Unit:=WdUnits.wdStory)
    '        End With
    '    Catch e As Exception
    '        MsgBox(e.Message + vbCrLf + e.StackTrace)
    '    End Try
    'End Sub
    Public Sub sTypeText(ByRef t As String, Optional ByRef f As Boolean = False)
        With prApp.Selection
            .TypeText(t)
            If Not f Then .MoveDown()
        End With
        prRange = prApp.Selection.Range
    End Sub
    Public Sub SurrCopia(ByRef Nzone As Short)
        Dim i As Short
        With prApp.Selection
            .MoveRight(Unit:=WdUnits.wdCharacter, Count:=1)
            .MoveDown(Unit:=WdUnits.wdLine, Count:=3, Extend:=WdMovementType.wdExtend)
            .Copy()
            If Nzone > 0 Then
                .MoveRight(Unit:=WdUnits.wdCharacter, Count:=1)
                For i = 1 To CShort(Nzone - 1)
                    .Paste()
                Next
            End If
            prRange = .Range
        End With
    End Sub
    Public Sub sBreak()
        With prRange
            .InsertParagraphAfter()
            .InsertBreak()
            .Select()
        End With
    End Sub
    Public Sub sPaste1()
        With prRange
            .Paste()
            .Select()
        End With
    End Sub
    Public Sub sMoveLeft(Optional ByRef Unit As Object = Nothing, Optional ByRef Count As Object = Nothing, Optional ByRef Extend As Object = Nothing)
        With prApp.Selection
            .MoveLeft(Unit, Count, Extend)
        End With
        prRange = prApp.Selection.Range
    End Sub
    Public Sub sMoveDown(Optional ByRef Unit As Object = Nothing, Optional ByRef Count As Object = Nothing, Optional ByRef Extend As Object = Nothing)
        With prApp.Selection
            .MoveDown(Unit, Count, Extend)
        End With
        prRange = prApp.Selection.Range
    End Sub
    Public Sub sMoveRight(Optional ByRef Unit As Object = Nothing, Optional ByRef Count As Object = Nothing, Optional ByRef Extend As Object = Nothing)
        With prApp.Selection
            .MoveRight(Unit, Count, Extend)
        End With
        prRange = prApp.Selection.Range
    End Sub
    Public Sub FontSize(ByRef size As Short)
        prRange.Font.Size = size
    End Sub
    Public Sub sDelete(Optional ByRef Unit As Object = Nothing, Optional ByRef Count As Object = Nothing)
        With prApp.Selection
            .Delete(Unit, Count)
        End With
    End Sub
    Public Sub sInsertAfter(ByRef bm As String, ByRef Testo As String)
        prRange = prDoc.Bookmarks.Item(CStr(bm)).Range
        prRange.InsertAfter(Testo)
    End Sub
    Public Sub sMoveUp(Optional ByRef Unit As Object = Nothing, Optional ByRef Count As Object = Nothing, Optional ByRef Extend As Object = Nothing)
        With prApp.Selection
            .MoveUp(Unit, Count, Extend)
        End With
        prRange = prApp.Selection.Range
    End Sub
    Public Sub SurrFormat()
        With prApp.Selection.ParagraphFormat
            .Borders.Item(WdBorderType.wdBorderLeft).LineStyle = WdLineStyle.wdLineStyleNone
            .Borders.Item(WdBorderType.wdBorderRight).LineStyle = WdLineStyle.wdLineStyleNone
            .Borders.Item(WdBorderType.wdBorderTop).LineStyle = WdLineStyle.wdLineStyleNone
            With .Borders.Item(WdBorderType.wdBorderBottom)
                .LineStyle = WdLineStyle.wdLineStyleSingle
                .LineWidth = WdLineWidth.wdLineWidth050pt
                .Color = WdColor.wdColorAutomatic
            End With
            With .Borders
                .DistanceFromTop = 1
                .DistanceFromLeft = 4
                .DistanceFromBottom = 1
                .DistanceFromRight = 4
                .Shadow = False
            End With
        End With
    End Sub
    Public Sub sCopy()
        prApp.Selection.Copy()
    End Sub
    Public Sub ssAddPicture(ByVal PicFile As String)
        Dim s As Word.Shape
        prRange.Select()
        s = prDoc.Shapes.AddPicture(Anchor:=prApp.Selection.Range, FileName:=PicFile, LinkToFile:=False, SaveWithDocument:=True)
        With s
            .LockAspectRatio = Office.MsoTriState.msoTrue ' True
            .Width = 157
            .RelativeHorizontalPosition = WdRelativeHorizontalPosition.wdRelativeHorizontalPositionColumn
            .RelativeVerticalPosition = WdRelativeVerticalPosition.wdRelativeVerticalPositionParagraph
            .Left = WdShapePosition.wdShapeRight
            .Top = WdShapePosition.wdShapeTop
            .WrapFormat.Type = WdWrapType.wdWrapSquare
        End With
    End Sub
    Public Function sAddPicture(ByRef PicFile As String) As Word.Shape
        Dim s As Word.Shape
        prRange.Select()
        s = prDoc.Shapes.AddPicture(Anchor:=prApp.Selection.Range, FileName:=PicFile, LinkToFile:=False, SaveWithDocument:=True)
        With s
            .LockAspectRatio = Office.MsoTriState.msoTrue ' True
            .Width = 157
            .RelativeHorizontalPosition = WdRelativeHorizontalPosition.wdRelativeHorizontalPositionColumn
            .RelativeVerticalPosition = WdRelativeVerticalPosition.wdRelativeVerticalPositionParagraph
            .Left = WdShapePosition.wdShapeRight
            .Top = WdShapePosition.wdShapeTop
            '.LockAnchor = 0 ' False
            '.WrapFormat.AllowOverlap = -1 ' True
            '.WrapFormat.Side = WdWrapSideType.wdWrapBoth
            '.WrapFormat.DistanceTop = prApp.CentimetersToPoints(0)
            '.WrapFormat.DistanceBottom = prApp.CentimetersToPoints(0)
            '.WrapFormat.DistanceLeft = prApp.CentimetersToPoints(0.32)
            '.WrapFormat.DistanceRight = prApp.CentimetersToPoints(0.32)
            .WrapFormat.Type = WdWrapType.wdWrapSquare
        End With
        Return s
    End Function
    Public Sub sShowAll(ByRef v As Boolean, Optional ByVal slim As Boolean = False)
        Try
            If Not slim Then Visible = True
            With prDoc.ActiveWindow.View
                .ShowAll = v
                .ShowBookmarks = v
            End With
            If slim Then Exit Sub
            Try
                prDoc.ActiveWindow.ActivePane.View.SeekView = WdSeekView.wdSeekMainDocument
                prApp.Activate()
            Catch
            End Try
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Public Function SuperStampa(ByRef File As String, ByVal VersOffice As Integer, _
                                Optional ByRef NonAttivare As Boolean = False) As Integer
        Dim Errore As Boolean = False
        Dim Cera As Boolean = True
        If VersOffice = 0 Then Exit Function
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        Try
            prApp = CType(GetObject(, "Word.Application"), Word.Application)   '"Word.Application"
        Catch
            Cera = False
            Try
                If VersOffice = 9 Then
                    prApp = New Word.Application
                Else
                    prApp = CType(CreateObject("Word.Application"), Word.Application) '"Word.Application"
                End If
            Catch ex As Exception
                Errore = True
            End Try
        End Try
        If Errore Then
            '         Testo = "Impossibile lanciare Word." + vbCrLf
            ' Testo = Testo + "(" + Err.Description + ")"
            ' MsgBox Testo, vbCritical + vbOKOnly
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            Return 1
            '    Motore.MostraAiuto(-IDHS.IDH_WORD_ASSENTE, CType(ChiaviMess.MessCritical + ChiaviMess.MessHelpButton + ChiaviMess.MessOkOnly, ChiaviMess), Err.Description)
            Exit Function
        End If
        Try
7:          If Not NonAttivare Then
                prApp.Visible = True
                prApp.WindowState = WdWindowState.wdWindowStateMaximize
                If Not Cera Then AppActivate(prApp.Application.Caption)
            End If
        Catch
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            Return 2
        End Try
        If File.Trim.Length > 0 Then
            If System.IO.File.Exists(File) Then
                sOpen(File)
            Else
                sOpen("")
                sSaveAs(File)
            End If
        Else
            sOpen("")
        End If
        If Err.Number > 0 Then
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            Return 3
            '    Testo = "Impossibile aprire " & File & vbCrLf
            '    Testo = Testo & "(" & Err.Description & ";" & Str(Erl()) & ")"
            '    MsgBox(Testo, CType(MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, MsgBoxStyle))
            '    System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            '    Stub = Nothing 'Doc = Nothing
        End If
        If Not NonAttivare Then sView()
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
    End Function
    Private Sub prDoc_Close() Handles prDoc.Close
        RaiseEvent Close()
    End Sub
    Private Sub prDoc_New() Handles prDoc.New
        RaiseEvent Open()
    End Sub
    Private Sub prDoc_Open() Handles prDoc.Open
        RaiseEvent Open()
    End Sub
End Class