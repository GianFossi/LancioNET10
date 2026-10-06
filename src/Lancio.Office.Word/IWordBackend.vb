Public Enum WordSaveChoice
    Prompt = -2
    Save = -1
    Discard = 0
End Enum

Public Interface IWordBackend
    ReadOnly Property RequiresSta As Boolean
    ReadOnly Property NativeApplication As Object
    ReadOnly Property NativeDocument As Object
    Sub Start()
    Sub OpenDocument(path As String, readOnlyDocument As Boolean)
    Sub CreateDocument(templatePath As String)
    Sub Show()
    Sub SaveAs(path As String, format As Integer)
    Sub ExportPdf(path As String)
    Sub Print()
    Sub CloseDocument(choice As WordSaveChoice)
    Sub Quit(choice As WordSaveChoice)
End Interface
