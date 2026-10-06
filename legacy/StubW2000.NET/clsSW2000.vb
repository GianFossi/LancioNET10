Option Strict On
Option Explicit On 
'Imports Microsoft.Office.Interop
'Imports Microsoft.Office.core
Public Class clsSW2000 'wdsavechanges
    Private prApp As Word.Application 'Object '
    Private prDoc As Word.Document
    Private prRange As Word.Range
    Private prRanges As New Collection '(1 To 3) As Word.Range
    Private prDocs As New Collection '(1 To 3) As Word.Document
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
            If .View.SplitSpecial <> Word.WdSpecialPane.wdPaneNone Then .Panes.Item(2).Close()
            If .ActivePane.View.Type = Word.WdViewType.wdNormalView Or .ActivePane.View.Type = Word.WdViewType.wdOutlineView Or .ActivePane.View.Type = Word.WdViewType.wdMasterView Then
                .ActivePane.View.Type = CType(Word.WdViewTypeOld.wdPageView, Word.WdViewType)
            End If
            .ActivePane.View.SeekView = Word.WdSeekView.wdSeekCurrentPageHeader
            prApp.Selection.TypeText(Text:="Pr. " & Arch)
            prApp.Selection.MoveRight(Unit:=Word.WdUnits.wdCell)
            prApp.Selection.TypeText(Text:="Item " & Ass)
            .ActivePane.View.SeekView = Word.WdSeekView.wdSeekMainDocument
        End With
        prRange = prApp.Selection.Range
    End Sub
    Public Function nDocSec() As Short
        nDocSec = CShort(prDocs.Count())
    End Function
    Public Property App() As Word.Application
        Get 'Word.Application
            App = prApp
        End Get
        Set(ByVal Value As Word.Application) 'Word.Application)
            prApp = Value
        End Set
    End Property
    Public Property Doc() As Word.Document
        Get 'Word.Application
            Doc = prDoc
        End Get
        Set(ByVal Value As Word.Document) 'Word.Application)
            prDoc = Value
        End Set
    End Property
    Public WriteOnly Property sWordRange() As Word.Range
        Set(ByVal Value As Word.Range)
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
        Dim Anch As Word.Range
        Dim i As Short
        'UPGRADE_NOTE: Left è stato aggiornato a Left_Renamed. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1061"'
        Dim Top, Left_Renamed As Single
        Dim Tipo As Word.WdWrapType
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
        s = prDoc.Sections.Item(1).Headers.Item(Word.WdHeaderFooterIndex.wdHeaderFooterEvenPages).Shapes.Item("Picture 5")
        Top = s.Top : Left_Renamed = s.Left
        Anch = s.Anchor
        s.Delete()
        s = prDoc.Sections.Item(1).Headers.Item(Word.WdHeaderFooterIndex.wdHeaderFooterEvenPages).Shapes.AddPicture(Anchor:=CType(Anch, Word.Range), FileName:=LogoFile, LinkToFile:=False, SaveWithDocument:=True)
        s.Top = Top
        s.Left = Left_Renamed
        s.LockAnchor = -1 ' True
        s.LockAspectRatio = Office.MsoTriState.msoTrue ' MsoTriState.msoTrue
        s.Height = 25
ExF:    Exit Function
ExitSub:
        MsgBox("Si è determinato l'errore " & Err.Description & vbCrLf & "durante l'apposizione del logo (Shapes7)", MsgBoxStyle.Critical)
        Shapes7 = False
        Resume ExF
    End Function
    Public Sub FinPag(ByRef Autore As String)
        Dim r As Word.Range
        r = prRange
        r.Select()
        With prApp.Selection
            .TypeText(Autore)
            .MoveRight()
            .MoveRight(Word.WdUnits.wdWord)
            .MoveRight()
            .TypeText(CStr(Today))
        End With
    End Sub
    Public Sub Object6(ByRef LogoFile As String)
        Dim Top, Left_Renamed As Single
        Dim s As Word.Shape
        prDoc.ActiveWindow.ActivePane.View.SeekView = Word.WdSeekView.wdSeekMainDocument
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
        Dim r1, r2 As Word.Range
        Dim locDoc As Word.Document
        If prRanges.Count() = 0 Then Exit Sub
        r1 = prRange
        r1.Select()
        prApp.Selection.MoveRight(Word.WdUnits.wdCharacter, Word.WdMovementType.wdExtend)
        r1 = prApp.Selection.Range
        VaiInizio(cap2)
        r2 = prRange
        r2.Select()
        prApp.Selection.MoveLeft(Word.WdUnits.wdCharacter, Word.WdMovementType.wdExtend)
        r2 = prApp.Selection.Range
        r1.SetRange(r1.Start, r2.End)
        r1.Copy()
        locDoc = prDoc.Application.Documents.Open(Arch & "\Header.doc")
        r2 = locDoc.GoTo(What:=Word.WdGoToItem.wdGoToBookmark, Name:="\StartOfDoc")
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
    Public Property WordDocument() As Word.Document
        Get
            Return prDoc
        End Get
        Set(ByVal Value As Word.Document)
            prDoc = Value
        End Set
    End Property
    Public Sub sOpen(ByRef File As String, Optional ByRef ReadOnly_Renamed As Boolean = False, Optional ByRef nDoc As Short = 0)
        Dim d As Word.Document
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
                If .View.SplitSpecial = Word.WdSpecialPane.wdPaneNone Then
                    .ActivePane.View.Type = Word.WdViewType.wdPrintView
                Else
                    .View.Type = Word.WdViewType.wdPrintView
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
            CType(prDocs.Item(nDoc), Word.Document).SaveAs(CStr(File))
        End If
    End Sub
    Public Sub sSave()
        prDoc.Save()
    End Sub
    Public Sub sView()
        If prDoc.ActiveWindow.View.SplitSpecial = Word.WdSpecialPane.wdPaneNone Then
            prDoc.ActiveWindow.ActivePane.View.Type = CType(Word.WdViewTypeOld.wdPageView, Word.WdViewType)
        Else
            prDoc.ActiveWindow.View.Type = CType(Word.WdViewTypeOld.wdPageView, Word.WdViewType)
        End If
    End Sub
    Public Sub sClose(Optional ByRef m As Short = 0, Optional ByRef nDoc As Short = 0)
        Dim opt As Integer
        If m = 0 Then m = 3
        Select Case m
            Case 1 : opt = Word.WdSaveOptions.wdSaveChanges
            Case 2 : opt = Word.WdSaveOptions.wdPromptToSaveChanges
            Case 3 : opt = Word.WdSaveOptions.wdDoNotSaveChanges
        End Select
        Try
            If nDoc = 0 Then
                prDoc.Close(CInt(opt))
            Else
                CType(prDocs.Item(nDoc), Word.Document).Close(CInt(opt))
                prDocs.Remove(prDocs.Count())
                prRanges.Remove(prRanges.Count())
            End If
        Catch e As Exception
            'MessageBox.Show(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Public Sub sPaste()
        prRange.Select()
        prApp.Selection.MoveRight(Word.WdUnits.wdWord)
        prApp.Selection.MoveRight()
        prRange = prApp.Selection.Range
        prRange.Paste()
    End Sub
    Public Sub sCloseAll(ByRef m As Short)
        Dim opt As Integer
        Dim d As Word.Document
        Select Case m
            Case 1 : opt = Word.WdSaveOptions.wdSaveChanges
            Case 2 : opt = Word.WdSaveOptions.wdPromptToSaveChanges
            Case 3 : opt = Word.WdSaveOptions.wdDoNotSaveChanges
        End Select
        On Error Resume Next
        For Each d In prApp.Documents
            d.Close(CInt(opt))
        Next d
    End Sub
    Public Function SubstitBookM(ByRef b As String, ByRef t As String, Optional ByRef Delete As Boolean = False, Optional ByRef nDoc As Short = 0) As Boolean
        Dim r1 As Word.Range
        Dim Testo As String
        SubstitBookM = True
        Try
            If nDoc = 0 Then
                r1 = prDoc.Bookmarks.Item(CStr(b)).Range
                r1.Text = t
                If Not Delete Then prDoc.Bookmarks.Add(b, CType(r1, Word.Range))
                prRange = r1
            Else
                r1 = CType(prDocs.Item(nDoc), Word.Document).Bookmarks.Item(CStr(b)).Range
                r1.Text = t
                If Not Delete Then CType(prDocs.Item(nDoc), Word.Document).Bookmarks.Add(b, CType(r1, Word.Range))
                prRanges.Remove(nDoc)
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
        Dim r1 As Word.Range
        Dim Testo As String
        EliminaRiga = True
        Try
            If nDoc = 0 Then
                r1 = prDoc.Bookmarks.Item(CStr(b)).Range
                r1.Expand(Word.WdUnits.wdParagraph)
                r1.Delete()
            Else
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto prDocs().Bookmarks. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                r1 = CType(prDocs.Item(nDoc), Word.Document).Bookmarks.Item(CStr(b)).Range
                r1.Expand(Word.WdUnits.wdParagraph)
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
        Dim r1, r2 As Word.Range
        Dim Testo As String
        Dim r3 As Word.Range
        EliminaCelle = True
        Try
            If nDoc = 0 Then
                r1 = prDoc.Bookmarks.Item(CStr(bStart)).Range
                r2 = prDoc.Bookmarks.Item(CStr(bEnd)).Range
                r3 = prDoc.Range(CInt(r1.Start), CInt(r2.End))
            Else
                r1 = CType(prDocs.Item(nDoc), Word.Document).Bookmarks.Item(CStr(bStart)).Range
                r2 = CType(prDocs.Item(nDoc), Word.Document).Bookmarks.Item(CStr(bEnd)).Range
                r3 = CType(prDocs.Item(nDoc), Word.Document).Range(CInt(r1.Start), CInt(r2.End))
            End If
            r3.Cells.Delete(Word.WdDeleteCells.wdDeleteCellsEntireRow)
        Catch e As Exception
            Testo = "Si è verificato un errore durante la compilazione" & vbCrLf
            Testo = Testo & "del documento " & prDoc.FullName & "." & vbCrLf
            Testo = Testo & "(" & e.Message & ")" + vbCrLf + e.StackTrace
            MsgBox(Testo, MsgBoxStyle.Critical, "Interfaccia con Word, EliminaCelle")
            Return False
        End Try
    End Function
    Public Function EliminaRighe(ByVal b As String, ByVal b1 As String, Optional ByVal nDoc As Short = 0) As Boolean
        Dim r1, r2 As Word.Range
        Dim Testo As String
        Dim r3 As Word.Range
        EliminaRighe = True
        Try
            If nDoc = 0 Then
                r1 = prDoc.Bookmarks.Item(CStr(b)).Range
                r1.Expand(Word.WdUnits.wdParagraph)
                r2 = prDoc.Bookmarks.Item(CStr(b1)).Range
                r2.Expand(Word.WdUnits.wdParagraph)
                r3 = prDoc.Range(CInt(r1.Start), CInt(r2.End))
            Else
                r1 = CType(prDocs.Item(nDoc), Word.Document).Bookmarks.Item(CStr(b)).Range
                r1.Expand(Word.WdUnits.wdParagraph)
                r2 = CType(prDocs.Item(nDoc), Word.Document).Bookmarks.Item(CStr(b1)).Range
                r2.Expand(Word.WdUnits.wdParagraph)
                r3 = CType(prDocs.Item(nDoc), Word.Document).Range(CInt(r1.Start), CInt(r2.End))
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
    Protected Overrides Sub Finalize()
        prDoc = Nothing
        MyBase.Finalize()
    End Sub
    Public Sub BorderBottom()
        prRange.Select()
        prApp.Selection.Expand(Word.WdUnits.wdRow)
        With prApp.Selection.Cells.Borders.Item(Word.WdBorderType.wdBorderBottom)
            .LineWidth = Word.WdLineWidth.wdLineWidth225pt
            .LineStyle = Word.WdLineStyle.wdLineStyleSingle
        End With
    End Sub
    Public Sub Testo(ByRef t As String)
        prRange.Expand(Word.WdUnits.wdParagraph)
        prRange.Text = t
    End Sub
    Public Function GetTesto() As String
        GetTesto = prRange.Text
    End Function
    Public Sub MuoviCella(ByRef n As Short)
        prRange.Move(Word.WdUnits.wdCell, CShort(n))
    End Sub
    Public Sub sInsertParagrahAfter()
        prRange.InsertParagraphAfter()
        prRange.Collapse(Word.WdCollapseDirection.wdCollapseStart)
    End Sub
    Public Sub ASMEMAWP1()
        Dim r As Word.Range
        r = prRange
        r.Move(Word.WdUnits.wdCharacter, -1)
        r.InsertBreak(Type:=Word.WdBreakType.wdPageBreak)
        r.InsertParagraphBefore()
        r.Collapse(Word.WdCollapseDirection.wdCollapseStart)
        prDoc.Bookmarks.Add("MAWP", CType(r, Word.Range))
        r.InsertBefore("Summary of MAWP's")
        r.InsertParagraphAfter()
        r.Move(Word.WdUnits.wdParagraph, 1)
        r.Style = prDoc.Styles.Item("corpo")
        r.Collapse(Word.WdCollapseDirection.wdCollapseStart)
        r.Paste()
        prRange = r
    End Sub
    Public Sub NewCap(ByRef Titolo As String, ByRef break As Boolean)
        Dim r As Word.Range
        r = prRange
        With r
            If break Then .InsertBreak(Word.WdBreakType.wdPageBreak)
            .InsertParagraphAfter()
            .Move(Word.WdUnits.wdParagraph, 1)
            .Text = Titolo
            .Expand(Word.WdUnits.wdParagraph)
            .Style = prDoc.Styles.Item("Titolo 2")
            prDoc.Bookmarks.Add(TogliBlank(Titolo), CType(r, Word.Range))
            .InsertParagraphAfter()
            .Move(Word.WdUnits.wdParagraph, 1)
            .Expand(Word.WdUnits.wdParagraph)
            .Style = prDoc.Styles.Item("corpo")
            .Paste()
        End With
    End Sub
    Public Sub ASMEPI(Optional ByVal Break As Boolean = False, Optional ByVal UnaVolta As Boolean = False)
        Dim r As Word.Range
        r = prRange
        r.Move(Word.WdUnits.wdParagraph, 1)
        r.Collapse(Word.WdCollapseDirection.wdCollapseEnd)
        If Break Then
            r.InsertBreak(Type:=Word.WdBreakType.wdPageBreak) 'Selection.MoveRight
        Else
            If Not UnaVolta Then
                r.Move(Word.WdUnits.wdCharacter, 1)
                r.Collapse(Word.WdCollapseDirection.wdCollapseEnd)
            End If
        End If
        r.Paste()
        prRange = r
    End Sub
    Public Sub ASMEMAWP()
        Dim r, r1 As Word.Range
        r = prRange
        r.Select()
        With prApp.Selection
            .GoTo(What:=Word.WdGoToItem.wdGoToBookmark, Name:="StartMAWP")
            .MoveDown(Unit:=Word.WdUnits.wdLine, Count:=1)
            r = .Range
            r.Expand(Word.WdUnits.wdParagraph)
            .GoTo(What:=Word.WdGoToItem.wdGoToBookmark, Name:="EndMAWP")
            r1 = .Range
        End With
        r.SetRange(r.Start, r1.End)
        r.Select()
        prApp.Selection.Cells.Delete(ShiftCells:=Word.WdDeleteCells.wdDeleteCellsEntireRow)
        prRange = r
    End Sub
    Public Sub MuoviLinea(ByRef n As Short, Optional ByVal Estendi As Boolean = False)
        Dim m As Word.WdMovementType = Word.WdMovementType.wdMove
        If Estendi Then m = Word.WdMovementType.wdExtend
        prRange.Select()
        prApp.Selection.Collapse(Word.WdCollapseDirection.wdCollapseStart)
        prApp.Selection.MoveDown(Word.WdUnits.wdLine, CShort(n), CType(m, Object))
        prRange = prApp.Selection.Range
    End Sub
    Public Sub MuoviParola(ByRef n As Short)
        prRange.Move(Word.WdUnits.wdWord, CShort(n))
    End Sub
    Public Sub LibMatDestra()
        Dim r As Word.Range
        r = prRange
        r.Select()
        prApp.Selection.MoveRight(Word.WdUnits.wdCell)
        prRange = prApp.Selection.Range
    End Sub
    Public Sub LibMatScrivi(ByRef Primo As Boolean, ByRef Mat As String)
        Dim r As Word.Range
        r = prRange
        r.Select()
        With prApp.Selection
            If Not Primo Then
                .MoveRight(Unit:=Word.WdUnits.wdCell, Count:=8)
                .MoveLeft(Unit:=Word.WdUnits.wdCell, Count:=8)
            End If
            .MoveRight(Unit:=Word.WdUnits.wdCharacter, Count:=8, Extend:=Word.WdMovementType.wdExtend)
            .Cells.Merge()
            .MoveLeft(Unit:=Word.WdUnits.wdCharacter, Count:=1)
            If Primo Then .MoveRight(Unit:=Word.WdUnits.wdCharacter, Count:=5, Extend:=Word.WdMovementType.wdExtend)
            Primo = False
            .TypeText(Text:=Trim(Mat))
            .Expand(Word.WdUnits.wdParagraph)
            .Font.Size = 12
            .Font.Bold = -1 ' True
            .Collapse(Word.WdCollapseDirection.wdCollapseEnd)
        End With
        r.Move(Word.WdUnits.wdCell, 1)

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
            .MoveRight(Extend:=Word.WdMovementType.wdExtend)
            .TypeText(Mid(Comm, 1, 1))
            .MoveLeft()
            prDoc.Bookmarks.Add(b, .Range)
            .MoveRight(Count:=2)
            .MoveRight(Extend:=Word.WdMovementType.wdExtend)
            .TypeText(Mid(Comm, 2, 1))
            .MoveRight()
            .MoveRight(Extend:=Word.WdMovementType.wdExtend)
            .TypeText(Mid(Comm, 3, 1))
            .MoveRight()
            .MoveRight(Extend:=Word.WdMovementType.wdExtend)
            .TypeText(Mid(Comm, 4, 1))
            .MoveRight(Count:=3)
            .MoveRight(Extend:=Word.WdMovementType.wdExtend)
            .TypeText(Mid(Comm, 5, 1))
            .MoveRight()
            .MoveRight(Extend:=Word.WdMovementType.wdExtend)
            .TypeText(Mid(Comm, 6, 1))
            .MoveRight(Count:=3)
            .MoveRight(Extend:=Word.WdMovementType.wdExtend)
            .TypeText(Mid(Numero, 1, 1))
            .MoveRight()
            .MoveRight(Extend:=Word.WdMovementType.wdExtend)
            .TypeText(Mid(Numero, 2, 1))
            .MoveRight(Count:=3)
            .MoveRight(Extend:=Word.WdMovementType.wdExtend)
            .TypeText(Mid(Numero, 3, 1))
            .MoveRight()
            .MoveRight(Extend:=Word.WdMovementType.wdExtend)
            .TypeText(Mid(Numero, 4, 1))
            .MoveRight()
            .MoveRight(Extend:=Word.WdMovementType.wdExtend)
            .TypeText(Mid(Numero, 5, 1))
        End With

    End Sub
    Public Sub sTypeParagraph()
        prRange.Select()
        prApp.Selection.Collapse(Word.WdCollapseDirection.wdCollapseEnd)
        prApp.Selection.TypeParagraph()
        prApp.Selection.MoveRight(Unit:=Word.WdUnits.wdCharacter)
        prRange = prApp.Selection.Range
    End Sub
    Public Sub sInsertBreak()
        prRange.Select()
        prApp.Selection.InsertBreak(Type:=Word.WdBreakType.wdPageBreak)
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
        prRange.Collapse(Word.WdCollapseDirection.wdCollapseStart)
    End Sub
    Public Function Pulisci() As Short
        Dim Primo As Boolean
        Dim p As Word.Paragraph
        Dim r As Word.Range
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
            .EndKey(Unit:=Word.WdUnits.wdStory)
            .TypeParagraph()
            .InsertBreak(Type:=Word.WdBreakType.wdPageBreak)
            .InsertFile(FileName:=nome, Range:="", ConfirmConversions:=False, Link:=False, Attachment:=False)
        End With
    End Sub
    Public Function Logo(ByRef t As String, Optional ByRef bm As String = "logo") As Word.InlineShape
        On Error GoTo Fine
        If Not bm = "fermo" Then
            prRange = prDoc.Bookmarks.Item(CStr(bm)).Range
            prRange.Text = ""
        End If
        Logo = prRange.InlineShapes.AddPicture(FileName:=t, LinkToFile:=False, SaveWithDocument:=True)
Fine:
    End Function
    Public Sub IntestLogo(ByRef LogoFile As String, Optional ByRef factor As Single = 0)
        Dim s As Word.InlineShape
        Dim Documento As Word.Document
        Documento = prDoc
        If Len(LogoFile) > 0 Then
            If Not Right(LogoFile, 1) = "\" Then
                If IO.File.Exists(LogoFile) Then
                    If Documento.Sections.Item(1).Headers.Item(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InlineShapes.Count > 0 Then
                        s = Documento.Sections.Item(1).Headers.Item(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InlineShapes.Item(1)
                        s.Select()
                        prApp.Selection.Delete()
                        s = prApp.Selection.InlineShapes.AddPicture(FileName:=LogoFile, LinkToFile:=False, SaveWithDocument:=True)
                        '                        s = Documento.Sections.Item(1).Headers.Item(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InlineShapes.AddPicture(FileName:=LogoFile, LinkToFile:=False, SaveWithDocument:=True)
                        s.LockAspectRatio = Office.MsoTriState.msoTrue ' MsoTriState.msoTrue ' True
                        If factor > 0 Then
                            s.Height = s.Height * factor
                            s.Width = s.Width * factor
                        End If
                        If prDoc.ActiveWindow.View.SplitSpecial = Word.WdSpecialPane.wdPaneNone Then
                            prDoc.ActiveWindow.ActivePane.View.Type = Word.WdViewType.wdPrintView
                        Else
                            prDoc.ActiveWindow.View.Type = Word.WdViewType.wdPrintView
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
            CType(prRanges.Item(nDoc), Word.Range).WholeStory()
            CType(prRanges.Item(nDoc), Word.Range).Copy()
        End If
    End Sub
    Public Function ApplicaStile(ByRef t As String) As Short
        prRange.Style = prDoc.Styles.Item(CStr(t))
    End Function
    Public Function VaiFine(ByVal t As String) As Integer
        With prApp.Selection
            .ExtendMode = True
            VaiInizio(t, , True)
            .MoveRight(Word.WdUnits.wdCharacter)
            .ExtendMode = False
        End With
    End Function
    Public Function VaiInizio(Optional ByRef t As String = "", Optional ByRef nDoc As Short = 0, Optional ByRef Sel As Boolean = False, Optional ByVal Del As Boolean = False) As Integer
        Dim r As Word.Range
        Try
            If t = "" Then t = "\StartOfDoc"
            If nDoc = 0 Then
                If Sel Then
                    prRange = prApp.Selection.GoTo(Word.WdGoToItem.wdGoToBookmark, , , CStr(t))
                Else
                    prRange = prDoc.GoTo(Word.WdGoToItem.wdGoToBookmark, , , CStr(t))
                End If
                r = prRange
                If Del Then prDoc.Bookmarks.Item(CStr(t)).Delete()
            Else
                r = CType(prDocs.Item(nDoc), Word.Document).GoTo(Word.WdGoToItem.wdGoToBookmark, , , CStr(t))
                If prRanges.Count() = nDoc Then
                    prRanges.Remove(nDoc)
                End If
                prRanges.Add(r)
                If Del Then CType(prDocs.Item(nDoc), Word.Document).Bookmarks.Item(CStr(t)).Delete()
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
        s = prApp.ActiveDocument.Shapes.AddLine(20, 20, 20, 20, CType(prRange, Word.Range))
        s.Line.Weight = 0.75
        s.Line.DashStyle = Office.MsoLineDashStyle.msoLineSolid ' MsoLineDashStyle.msoLineSolid ' 1 ' msoLineSolid
        s.Line.Style = Office.MsoLineStyle.msoLineSingle ' MsoLineStyle.msoLineSingle ' 1 ' msoLineSingle
        s.RelativeHorizontalPosition = Word.WdRelativeHorizontalPosition.wdRelativeHorizontalPositionPage
        s.RelativeVerticalPosition = Word.WdRelativeVerticalPosition.wdRelativeVerticalPositionPage
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
        s = prApp.ActiveDocument.Shapes.AddTextbox(CType(1, Office.MsoTextOrientation), 20, 20, 20, 20, CType(prRange, Word.Range))
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
        s.RelativeHorizontalPosition = Word.WdRelativeHorizontalPosition.wdRelativeHorizontalPositionPage
        s.RelativeVerticalPosition = Word.WdRelativeVerticalPosition.wdRelativeVerticalPositionPage
        s.Left = prApp.CentimetersToPoints(xo / 100)
        s.Top = prApp.CentimetersToPoints(yo / 100)

    End Sub
    Public Sub Massimizza()
        prDoc.Application.Visible = True
        prDoc.Application.WindowState = Word.WdWindowState.wdWindowStateMaximize
        prDoc.ActiveWindow.ActivePane.View.ShowAll = False
        App.Activate()
        '        AppActivate(prDoc.Application.Caption)
    End Sub
    Public Sub Minimizza()
        prDoc.Application.WindowState = Word.WdWindowState.wdWindowStateMinimize
    End Sub
    Public Sub ASMESinistra(ByRef v As Boolean)
        Dim r As Word.Range
        r = prRange
        r.Select()
        With prApp.Selection
            .MoveLeft(Word.WdUnits.wdWord, 1, Word.WdMovementType.wdExtend)
            .Font.Bold = CInt(v)
            .Collapse(Word.WdCollapseDirection.wdCollapseEnd)
        End With
    End Sub
    Public Sub BMAdd(ByRef s As String)
        prDoc.Bookmarks.Add(s, CType(prRange, Word.Range))
    End Sub
    Public Sub MuoviCaratt(ByRef n As Short)
        prRange.Move(Word.WdUnits.wdCharacter, CShort(n))
    End Sub
    Public Sub MuoviRiga(ByRef n As Short)
        prRange.Move(Word.WdUnits.wdRow, CShort(n))
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
        Dim t As Word.Table
        prDoc.ActiveWindow.ActivePane.View.ShowAll = False
        prRange = prDoc.GoTo(Word.WdGoToItem.wdGoToBookmark, , , "\StartOfDoc")
        prRange.Select()
        prApp.Selection.Font.Size = 8
        prRange.InsertParagraphAfter()
        prRange.Move(Word.WdUnits.wdParagraph, 1)
        t = prDoc.Tables.Add(prRange, Righe, Colonne, Word.WdDefaultTableBehavior.wdWord8TableBehavior)
        If Ret Then Exit Sub
        t.Columns.Item(1).Width = prApp.CentimetersToPoints(1.8)
        t.Columns.Item(2).Width = prApp.CentimetersToPoints(1.3)
        t.Columns.Item(3).Width = prApp.CentimetersToPoints(6.0#)
        t.Columns.Item(4).Width = prApp.CentimetersToPoints(6.0#)
        t.Columns.Item(5).Width = prApp.CentimetersToPoints(1.1)
        t.Columns.Item(6).Width = prApp.CentimetersToPoints(0.9)
    End Sub
    Public Sub OreLavSub1(ByRef Colonne As Short)
        prRange.Move(Word.WdUnits.wdCell, -1)
        prRange.Select()
        prApp.Selection.MoveLeft(Unit:=Word.WdUnits.wdSentence, Count:=CShort(Colonne), Extend:=Word.WdMovementType.wdExtend)
        prApp.Selection.Font.Bold = -1 ' True
        prRange.Collapse(Word.WdCollapseDirection.wdCollapseEnd)
        prRange.Move(Word.WdUnits.wdCell, 1)

    End Sub
    Public Sub TastoTab()
        prRange.Select()
        prApp.Selection.MoveRight(Word.WdUnits.wdCell)
        prRange = prApp.Selection.Range
    End Sub
    Public Sub VentilPict(ByRef FileP As String)
        Dim inls As Word.InlineShape
        prRange = prDoc.GoTo(Word.WdGoToItem.wdGoToBookmark, , , "\StartOfDoc")
        inls = prDoc.InlineShapes.AddPicture(FileP, False, True, CType(prRange, Word.Range))
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
            .Move(Word.WdUnits.wdParagraph, 1)
            .Style = prDoc.Styles.Item(CStr(s))
            .InsertBefore(t)
        End With
    End Sub
    Public Sub StampaNota(ByRef Nota As String, ByRef n As Short)
        Dim r1 As Word.Range
        r1 = prRange.Characters.Item(n + 2)
        r1.Collapse(Word.WdCollapseDirection.wdCollapseEnd)
        prDoc.Footnotes.Add(r1, , CStr(Nota))
        prRange.Expand(Word.WdUnits.wdParagraph)
        prRange.Collapse(Word.WdCollapseDirection.wdCollapseEnd)
    End Sub
    Public Sub Espandi()
        With prRange
            .Expand(Word.WdUnits.wdParagraph)
            .Collapse(Word.WdCollapseDirection.wdCollapseEnd)
            .InsertParagraphAfter()
            .Collapse(Word.WdCollapseDirection.wdCollapseEnd)
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
        prDoc.Paragraphs.Item(1).Format.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter
    End Sub
    'Public Sub Saddles()
    '    Try
    '        With prApp.Selection
    '            .MoveDown(Count:=8)
    '            .PasteSpecial(Link:=False, DataType:=Word.WdPasteDataType.wdPasteOLEObject, Placement:=Word.WdOLEPlacement.wdFloatOverText, DisplayAsIcon:=False)
    '            .ShapeRange.Height = 434.85
    '            .ShapeRange.Width = 438.25
    '            .ShapeRange.RelativeHorizontalPosition = Word.WdRelativeHorizontalPosition.wdRelativeHorizontalPositionColumn
    '           .ShapeRange.RelativeVerticalPosition = Word.WdRelativeVerticalPosition.wdRelativeVerticalPositionParagraph
    '            .ShapeRange.Left = prApp.CentimetersToPoints(0)
    '            .ShapeRange.Top = prApp.CentimetersToPoints(0)
    '            .HomeKey(Unit:=Word.WdUnits.wdStory)
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
            .MoveRight(Unit:=Word.WdUnits.wdCharacter, Count:=1)
            .MoveDown(Unit:=Word.WdUnits.wdLine, Count:=3, Extend:=Word.WdMovementType.wdExtend)
            .Copy()
            If Nzone > 0 Then
                .MoveRight(Unit:=Word.WdUnits.wdCharacter, Count:=1)
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
            .Borders.Item(Word.WdBorderType.wdBorderLeft).LineStyle = Word.WdLineStyle.wdLineStyleNone
            .Borders.Item(Word.WdBorderType.wdBorderRight).LineStyle = Word.WdLineStyle.wdLineStyleNone
            .Borders.Item(Word.WdBorderType.wdBorderTop).LineStyle = Word.WdLineStyle.wdLineStyleNone
            With .Borders.Item(Word.WdBorderType.wdBorderBottom)
                .LineStyle = Word.WdLineStyle.wdLineStyleSingle
                .LineWidth = Word.WdLineWidth.wdLineWidth050pt
                .Color = Word.WdColor.wdColorAutomatic
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
    Public Function sAddPicture(ByRef PicFile As String) As Word.Shape
        Dim s As Word.Shape
        prRange.Select()
        s = prDoc.Shapes.AddPicture(Anchor:=prApp.Selection.Range, FileName:=PicFile, LinkToFile:=False, SaveWithDocument:=True)
        With s
            .LockAspectRatio = Office.MsoTriState.msoTrue ' True
            .Width = 157
            .RelativeHorizontalPosition = Word.WdRelativeHorizontalPosition.wdRelativeHorizontalPositionColumn
            .RelativeVerticalPosition = Word.WdRelativeVerticalPosition.wdRelativeVerticalPositionParagraph
            .Left = Word.WdShapePosition.wdShapeRight
            .Top = Word.WdShapePosition.wdShapeTop
            '.LockAnchor = 0 ' False
            '.WrapFormat.AllowOverlap = -1 ' True
            '.WrapFormat.Side = Word.WdWrapSideType.wdWrapBoth
            '.WrapFormat.DistanceTop = prApp.CentimetersToPoints(0)
            '.WrapFormat.DistanceBottom = prApp.CentimetersToPoints(0)
            '.WrapFormat.DistanceLeft = prApp.CentimetersToPoints(0.32)
            '.WrapFormat.DistanceRight = prApp.CentimetersToPoints(0.32)
            .WrapFormat.Type = Word.WdWrapType.wdWrapSquare
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
                prDoc.ActiveWindow.ActivePane.View.SeekView = Word.WdSeekView.wdSeekMainDocument
                prApp.Activate()
            Catch
            End Try
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
End Class