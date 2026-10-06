Imports RoutBase1
Public Class clsMonitor
    Public WithEvents Motore As RoutBase1.clsMotore
    Public Sub New()
        MyBase.New()
        Motore = New RoutBase1.clsMotore("LancHTRI")
        'Dim InitLibmat As LibMat.clsInitLibMat = New LibMat.clsInitLibMat(Motore)
    End Sub
    Public Sub CheckSystem()
        Dim HRes, VRes As Short
        Dim Testo As String
        Dim HTMLVersion As String = ""
        Dim IEVersion As String = ""
        Dim Res As Integer
        Dim appobj As Object
        Dim NonCera As Boolean 'Word.Application
        Motore.Inizio.EmsChecked = CShort(True)
        HRes = CShort(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width)
        VRes = CShort(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height)
        If HRes < 1024 Or VRes < 768 Then
            Stop ' Motore.Messaggio("", CType(ChiaviMess.MessExclamation + ChiaviMess.MessOkOnly + ChiaviMess.MessHelpButton, ChiaviMess), "Lancio - Messaggi di errore", RadiceHelp, IDHS.IDH_SIST_RISOL)
        End If
        '-----------------Word----------------------------------
        On Error Resume Next
        appobj = GetObject(, "Word.Application")  '"Word.Application"
        If Err.Number > 0 Then
            Err.Clear()
            appobj = CreateObject("Word.Application") '"Word.Application"
            NonCera = True
        End If
        If Err.Number > 0 Then
            On Error GoTo 0
            Stop '  Motore.MostraAiuto(-IDHS.IDH_WORD_ASSENTE, CType(ChiaviMess.MessCritical + ChiaviMess.MessHelpButton + ChiaviMess.MessOkOnly, ChiaviMess), Err.Description)
            Motore.Inizio.VersOffice = 0
            Exit Sub
        End If
        Err.Clear()
        '------------------------------- da mettere in Lancio-----------------
        If Val(appobj.Version) < 9.0# Then
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            Stop 'If Motore.MostraAiuto(-IDHS.IDH_WORD_VECCHIO, CType(ChiaviMess.MessInformation + ChiaviMess.MessHelpButton + ChiaviMess.MessOKCancel, ChiaviMess), appobj.Version) = ChiaviMess.MessCancel Then
            Motore.Inizio.VersOffice = 0
            'Else
            '    Motore.Inizio.VersOffice = 1
            'End If
        Else
        Motore.Inizio.VersOffice = Val(appobj.version)
        End If
        '--------------------------------------------------------------
        If NonCera Then appobj.Quit()
    End Sub
End Class
