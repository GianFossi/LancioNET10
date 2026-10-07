Option Strict Off
Imports System.Runtime.InteropServices

' Late binding is confined to this Office boundary; no private control DLL/PIA.
Public NotInheritable Class OfficeComBackend
    Implements IWordBackend
    Private application As Object
    Private document As Object

    Public ReadOnly Property RequiresSta As Boolean Implements IWordBackend.RequiresSta
        Get
            Return True
        End Get
    End Property
    Public ReadOnly Property NativeApplication As Object Implements IWordBackend.NativeApplication
        Get
            Return application
        End Get
    End Property
    Public ReadOnly Property NativeDocument As Object Implements IWordBackend.NativeDocument
        Get
            Return document
        End Get
    End Property

    Public Sub Start() Implements IWordBackend.Start
        If Not OperatingSystem.IsWindows() Then Throw New PlatformNotSupportedException("Microsoft Word desktop automation requires Windows.")
        If application IsNot Nothing Then Throw New InvalidOperationException("Word is already started.")
        Dim wordType = Type.GetTypeFromProgID("Word.Application", throwOnError:=True)
        application = Activator.CreateInstance(wordType)
        ' Create our own application. Never attach to an unrelated Word session.
    End Sub

    Public Sub OpenDocument(path As String, readOnlyDocument As Boolean) Implements IWordBackend.OpenDocument
        Dim documents As Object = application.Documents
        Try
            document = documents.Open(path, False, readOnlyDocument)
        Finally
            Release(documents)
        End Try
    End Sub

    Public Sub CreateDocument(templatePath As String) Implements IWordBackend.CreateDocument
        Dim documents As Object = application.Documents
        Try
            If templatePath Is Nothing Then
                document = documents.Add()
            Else
                document = documents.Add(templatePath, False)
            End If
        Finally
            Release(documents)
        End Try
    End Sub

    Public Sub Show() Implements IWordBackend.Show
        application.Visible = True
        application.Activate()
    End Sub

    Public Sub SaveAs(path As String, format As Integer) Implements IWordBackend.SaveAs
        document.SaveAs2(path, format)
    End Sub

    Public Sub ExportPdf(path As String) Implements IWordBackend.ExportPdf
        document.ExportAsFixedFormat(path, 17) ' wdExportFormatPDF
    End Sub

    Public Sub Print() Implements IWordBackend.Print
        document.PrintOut(False) ' Foreground print: do not quit during background printing.
    End Sub

    Public Sub CloseDocument(choice As WordSaveChoice) Implements IWordBackend.CloseDocument
        If document Is Nothing Then Return
        Try
            document.Close(CInt(choice))
        Catch ex As COMException When IsDisconnected(ex)
            ' Word was closed or crashed outside Lancio. Treat its document as
            ' already closed and discard the stale application proxy as well.
            Release(application)
        Finally
            Release(document)
        End Try
    End Sub

    Public Sub Quit(choice As WordSaveChoice) Implements IWordBackend.Quit
        If application Is Nothing Then Return
        Try
            application.Quit(CInt(choice))
        Catch ex As COMException When IsDisconnected(ex)
            ' The external Word process no longer exists; there is nothing to quit.
        Finally
            Release(application)
        End Try
    End Sub

    Private Shared Function IsDisconnected(ex As COMException) As Boolean
        Select Case ex.HResult
            Case -2147023174, -2147023170, -2147417848
                Return True
            Case Else
                Return False
        End Select
    End Function

    Private Shared Sub Release(ByRef value As Object)
        If value IsNot Nothing AndAlso Marshal.IsComObject(value) Then
            Marshal.ReleaseComObject(value)
        End If
        value = Nothing
    End Sub
End Class
