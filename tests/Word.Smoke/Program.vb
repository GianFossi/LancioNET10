Imports System.IO
Imports System.Threading
Imports Lancio.Office.Word

Module Program
    Private count As Integer
    Sub Main()
        Dim temp = System.IO.Path.Combine(System.IO.Path.GetTempPath(), Guid.NewGuid().ToString())
        Directory.CreateDirectory(temp)
        Dim input = System.IO.Path.Combine(temp, "input.doc")
        File.WriteAllText(input, "fixture used only by fake backend")
        Try
            Dim backend As New FakeWordBackend()
            Dim session As New WordSession(backend)
            Reject(Of InvalidOperationException)(Sub() session.Print())
            Reject(Of FileNotFoundException)(Sub() session.OpenDocument(System.IO.Path.Combine(temp, "missing.doc")))
            Check(backend.Starts = 0, "Invalid input must not start Word")
            session.OpenDocument(input, True)
            Check(backend.ReadOnlyDocument AndAlso session.IsOpen, "Read-only open")
            session.EnsureStarted()
            Check(backend.Starts = 1, "One owned Word application")
            session.Show()
            Check(backend.Shows = 1, "Show")
            session.SaveAs(System.IO.Path.Combine(temp, "result.docx"))
            Check(backend.LastFormat = 12, "DOCX format")
            session.SaveAs(System.IO.Path.Combine(temp, "result.doc"))
            Check(backend.LastFormat = 0, "Legacy DOC format")
            session.SaveAs(System.IO.Path.Combine(temp, "result.docm"))
            Check(backend.LastFormat = 13, "Macro-enabled document format")
            Reject(Of NotSupportedException)(Sub() session.SaveAs(System.IO.Path.Combine(temp, "result.unknown")))
            Reject(Of IOException)(Sub() session.SaveAs(input))
            session.ExportPdf(System.IO.Path.Combine(temp, "result.pdf"))
            Check(backend.Pdfs = 1, "PDF export")
            Reject(Of ArgumentException)(Sub() session.ExportPdf(System.IO.Path.Combine(temp, "result.docx")))
            session.Print()
            Check(backend.Prints = 1, "Print delegates once")
            backend.CancelClose = True
            Reject(Of OperationCanceledException)(Sub() session.CloseDocument())
            Check(session.IsOpen AndAlso backend.Quits = 0, "Cancellation retains the owned session")
            backend.CancelClose = False
            session.CreateDocument(input)
            Check(backend.Template = input AndAlso backend.LastClose = WordSaveChoice.Prompt, "Template creation prompts before replacement")
            Dim wrongThreadError As Exception = Nothing
            Dim thread As New Thread(Sub()
                                         Try
                                             session.Show()
                                         Catch ex As Exception
                                             wrongThreadError = ex
                                         End Try
                                     End Sub)
            thread.Start()
            thread.Join()
            Check(TypeOf wrongThreadError Is InvalidOperationException, "Reject cross-thread access")
            Reject(Of ArgumentOutOfRangeException)(Sub() session.CloseDocument(CType(99, WordSaveChoice)))
            session.Dispose()
            Check(backend.Quits = 1 AndAlso backend.LastClose = WordSaveChoice.Prompt, "Dispose closes only owned backend and prompts")
            session.Dispose()
            Check(backend.Quits = 1, "Idempotent dispose")
            Reject(Of ObjectDisposedException)(Sub() session.Show())
            Console.WriteLine($"PASS: {count} Word session checks using a fake backend.")
            Console.WriteLine("NOT RUN: real Word COM, PDF rendering, printing and WinForms UI on Windows.")
        Finally
            Directory.Delete(temp, True)
        End Try
    End Sub

    Private Sub Check(condition As Boolean, name As String)
        If Not condition Then Throw New Exception(name)
        count += 1
    End Sub
    Private Sub Reject(Of T As Exception)(action As Action)
        Try
            action()
        Catch ex As Exception
            If Not TypeOf ex Is T Then Throw
            count += 1
            Return
        End Try
        Throw New Exception("Expected " & GetType(T).Name)
    End Sub
End Module

Class FakeWordBackend
    Implements IWordBackend
    Public Starts, Shows, Pdfs, Prints, Quits, LastFormat As Integer
    Public ReadOnlyDocument, CancelClose As Boolean
    Public Template As String
    Public LastClose As WordSaveChoice
    Public ReadOnly Property RequiresSta As Boolean Implements IWordBackend.RequiresSta
        Get
            Return False
        End Get
    End Property
    Public ReadOnly Property NativeApplication As Object Implements IWordBackend.NativeApplication
        Get
            Return Me
        End Get
    End Property
    Public ReadOnly Property NativeDocument As Object Implements IWordBackend.NativeDocument
        Get
            Return Me
        End Get
    End Property
    Public Sub Start() Implements IWordBackend.Start
        Starts += 1
    End Sub
    Public Sub OpenDocument(path As String, readOnlyDocument As Boolean) Implements IWordBackend.OpenDocument
        Me.ReadOnlyDocument = readOnlyDocument
    End Sub
    Public Sub CreateDocument(templatePath As String) Implements IWordBackend.CreateDocument
        Template = templatePath
    End Sub
    Public Sub Show() Implements IWordBackend.Show
        Shows += 1
    End Sub
    Public Sub SaveAs(path As String, format As Integer) Implements IWordBackend.SaveAs
        LastFormat = format
    End Sub
    Public Sub ExportPdf(path As String) Implements IWordBackend.ExportPdf
        Pdfs += 1
    End Sub
    Public Sub Print() Implements IWordBackend.Print
        Prints += 1
    End Sub
    Public Sub CloseDocument(choice As WordSaveChoice) Implements IWordBackend.CloseDocument
        If CancelClose Then Throw New OperationCanceledException()
        LastClose = choice
    End Sub
    Public Sub Quit(choice As WordSaveChoice) Implements IWordBackend.Quit
        Quits += 1
    End Sub
End Class
