Imports System.Windows.Forms
Imports Lancio.Office.Word
Imports System.IO

Public Class WordReportPanel
    Inherits UserControl
    Private ReadOnly session As New WordSession(New OfficeComBackend())
    Private templatePath As String

    Public Sub New()
        Dim description As New Label With {
            .Text = "Il rapporto viene aperto nella finestra di Microsoft Word.",
            .Dock = DockStyle.Top, .Height = 50
        }
        Dim openButton As New Button With {.Text = "Apri in Microsoft Word", .Dock = DockStyle.Top}
        AddHandler openButton.Click, Sub(sender, args)
                                         Try
                                             ShowWord()
                                         Catch ex As Exception
                                             MessageBox.Show(Me, ex.Message, "Microsoft Word", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                         End Try
                                     End Sub
        Controls.Add(openButton)
        Controls.Add(description)
    End Sub

    Public ReadOnly Property OfficeSession As WordSession
        Get
            Return session
        End Get
    End Property

    Public ReadOnly Property NativeDocument As Object
        Get
            Return session.NativeDocument
        End Get
    End Property

    Public ReadOnly Property NativeApplication As Object
        Get
            Return session.NativeApplication
        End Get
    End Property

    Public Sub EnsureStarted()
        session.EnsureStarted()
    End Sub

    Public Sub SetTemplate(path As String)
        If Not File.Exists(path) Then Throw New FileNotFoundException("Word template not found.", path)
        templatePath = System.IO.Path.GetFullPath(path)
    End Sub

    Public Sub LoadDocument(path As String)
        session.OpenDocument(path)
    End Sub

    Public Sub CreateDocument()
        session.CreateDocument(templatePath)
    End Sub

    Public Sub ShowWord()
        session.Show()
    End Sub

    Public Sub CloseDocument()
        session.CloseDocument(WordSaveChoice.Prompt)
    End Sub

    Public Sub CloseSession()
        session.Close(WordSaveChoice.Prompt)
    End Sub

    Protected Overrides Sub Dispose(disposing As Boolean)
        If disposing Then session.Dispose()
        MyBase.Dispose(disposing)
    End Sub
End Class
