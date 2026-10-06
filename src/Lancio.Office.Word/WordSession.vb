Imports System.IO
Imports System.Threading

Public NotInheritable Class WordSession
    Implements IDisposable

    Private ReadOnly backend As IWordBackend
    Private ReadOnly ownerThread As Integer = Environment.CurrentManagedThreadId
    Private started As Boolean
    Private opened As Boolean
    Private disposed As Boolean

    Public Sub New(backend As IWordBackend)
        If backend Is Nothing Then Throw New ArgumentNullException(NameOf(backend))
        Me.backend = backend
    End Sub

    Public ReadOnly Property IsOpen As Boolean
        Get
            Return opened
        End Get
    End Property

    Public ReadOnly Property NativeApplication As Object
        Get
            CheckAccess()
            If Not started Then Throw New InvalidOperationException("Word has not been started.")
            Return backend.NativeApplication
        End Get
    End Property

    Public ReadOnly Property NativeDocument As Object
        Get
            CheckDocument()
            Return backend.NativeDocument
        End Get
    End Property

    Public Sub EnsureStarted()
        CheckAccess()
        If Not started Then
            backend.Start()
            started = True
        End If
    End Sub

    Public Sub OpenDocument(path As String, Optional readOnlyDocument As Boolean = False)
        CheckAccess()
        Dim fullPath = RequireExistingFile(path)
        CloseDocument(WordSaveChoice.Prompt)
        EnsureStarted()
        backend.OpenDocument(fullPath, readOnlyDocument)
        opened = True
    End Sub

    Public Sub CreateDocument(Optional templatePath As String = Nothing)
        CheckAccess()
        Dim fullPath As String = Nothing
        If Not String.IsNullOrWhiteSpace(templatePath) Then fullPath = RequireExistingFile(templatePath)
        CloseDocument(WordSaveChoice.Prompt)
        EnsureStarted()
        backend.CreateDocument(fullPath)
        opened = True
    End Sub

    Public Sub Show()
        EnsureStarted()
        backend.Show()
    End Sub

    Public Sub SaveAs(path As String)
        CheckDocument()
        Dim fullPath = RequireOutputPath(path)
        Dim format As Integer
        Select Case System.IO.Path.GetExtension(fullPath).ToLowerInvariant()
            Case ".doc" : format = 0
            Case ".dot" : format = 1
            Case ".rtf" : format = 6
            Case ".docx" : format = 12
            Case ".docm" : format = 13
            Case ".dotx" : format = 14
            Case ".dotm" : format = 15
            Case Else : Throw New NotSupportedException("Unsupported Word save format. Use ExportPdf for PDF.")
        End Select
        If File.Exists(fullPath) Then Throw New IOException("The destination already exists; choose another file or save through Word.")
        backend.SaveAs(fullPath, format)
    End Sub

    Public Sub ExportPdf(path As String)
        CheckDocument()
        Dim fullPath = RequireOutputPath(path)
        If Not String.Equals(System.IO.Path.GetExtension(fullPath), ".pdf", StringComparison.OrdinalIgnoreCase) Then
            Throw New ArgumentException("A .pdf destination is required.", NameOf(path))
        End If
        If File.Exists(fullPath) Then Throw New IOException("The PDF destination already exists.")
        backend.ExportPdf(fullPath)
    End Sub

    Public Sub Print()
        CheckDocument()
        backend.Print()
    End Sub

    Public Sub CloseDocument(Optional choice As WordSaveChoice = WordSaveChoice.Prompt)
        CheckAccess()
        ValidateChoice(choice)
        If opened Then
            backend.CloseDocument(choice)
            ' A cancellation/error leaves the session available for a retry.
            opened = False
        End If
    End Sub

    Public Sub Close(Optional choice As WordSaveChoice = WordSaveChoice.Prompt)
        CheckAccess()
        ValidateChoice(choice)
        CloseDocument(choice)
        If started Then
            backend.Quit(choice)
            started = False
        End If
    End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        If disposed Then Return
        Close(WordSaveChoice.Prompt)
        disposed = True
    End Sub

    Private Sub CheckAccess()
        If disposed Then Throw New ObjectDisposedException(NameOf(WordSession))
        If Environment.CurrentManagedThreadId <> ownerThread Then
            Throw New InvalidOperationException("Use the Word session on its owning thread.")
        End If
        If backend.RequiresSta AndAlso Thread.CurrentThread.GetApartmentState() <> ApartmentState.STA Then
            Throw New InvalidOperationException("Word automation requires the owning Windows STA thread.")
        End If
    End Sub

    Private Sub CheckDocument()
        CheckAccess()
        If Not opened Then Throw New InvalidOperationException("No Word document is open.")
    End Sub

    Private Shared Sub ValidateChoice(choice As WordSaveChoice)
        If Not [Enum].IsDefined(choice) Then Throw New ArgumentOutOfRangeException(NameOf(choice))
    End Sub

    Private Shared Function RequireExistingFile(path As String) As String
        If String.IsNullOrWhiteSpace(path) Then Throw New ArgumentException("A file path is required.", NameOf(path))
        Dim fullPath = System.IO.Path.GetFullPath(path)
        If Not File.Exists(fullPath) Then Throw New FileNotFoundException("Word input file not found.", fullPath)
        Return fullPath
    End Function

    Private Shared Function RequireOutputPath(path As String) As String
        If String.IsNullOrWhiteSpace(path) Then Throw New ArgumentException("A destination path is required.", NameOf(path))
        Dim fullPath = System.IO.Path.GetFullPath(path)
        If Not Directory.Exists(System.IO.Path.GetDirectoryName(fullPath)) Then
            Throw New DirectoryNotFoundException("The destination directory must exist.")
        End If
        Return fullPath
    End Function
End Class
