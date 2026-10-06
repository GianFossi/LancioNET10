Option Strict Off
Option Explicit On 
Imports RoutBase1.clsInizio
Imports RoutBase1.HHHelp
Imports RoutBase1
Friend Class clsMonitor
    Public WithEvents Motore As RoutBase1.clsMotore
    Public Sub New()
        MyBase.New()
        Motore = New clsMotore("Lanc")
        Dim InitLibmat As LibMat.clsInitLibMat = New LibMat.clsInitLibMat(Motore)
    End Sub
    Protected Overrides Sub Finalize()
        '   If Not Motore Is Nothing Then Motore = Nothing
        MyBase.Finalize()
    End Sub
    Private Sub Motore_Finito(ByRef p As String) Handles Motore.Finito
        Dim Out As Boolean
        Select Case p
            Case "WRCB"
                If objWRCB Is Nothing Then Exit Sub
                objWRCB.Dispose()
                objWRCB = Nothing
            Case "ISFT"
                If objDataSheet Is Nothing Then Exit Sub
                Out = objDataSheet.Out
                objDataSheet.Dispose()
                objDataSheet = Nothing
                If Out Then
                    Form1.DefInstance.cmdExit_Click(Form1.DefInstance.cmdExit, New System.EventArgs)
                Else
                    Form1.DefInstance.WindowState = System.Windows.Forms.FormWindowState.Normal
                End If
            Case "ASME"
                If objASME Is Nothing Then Exit Sub
                Out = objASME.Out
                objASME.Dispose()
                objASME = Nothing
                If Out Then
                    Form1.DefInstance.cmdExit_Click(Form1.DefInstance.cmdExit, New System.EventArgs)
                Else
                    Form1.DefInstance.WindowState = System.Windows.Forms.FormWindowState.Normal
                End If
                '       Case "SURR"
                '   objSURR = Nothing
                '   Form1.DefInstance.WindowState = System.Windows.Forms.FormWindowState.Normal
                '       Case "Sald"
                '   WPS = Nothing
            Case "Trac"
                If objTraccia Is Nothing Then Exit Sub
                objTraccia.Dispose()
                objTraccia = Nothing
                '       Case "PPSM"
                '   objPPSM = Nothing
                '       Case "Vent"
                '   objventil = Nothing
                '       Case "BabC"
                '   objBabC = Nothing
                '      Case "Util"
                '  Util = Nothing
                '      Case "LigT"
                '  If Not objLigTem Is Nothing Then
                '  objLigTem = Nothing
                '  End If
                '      Case "WalT"
                '  If Not objWallT Is Nothing Then
                '  objWallT = Nothing
                '  End If
            Case "BSDD"
                If objBSDD Is Nothing Then Exit Sub
                objBSDD.Dispose()
                objBSDD = Nothing
            Case "OREC"
                orec = Nothing
        End Select
    End Sub
    Public Sub CheckSystem()
        Dim HRes, VRes As Short
        Dim Testo As String
        Dim hHelp As New HTMLHelp
        Dim HTMLVersion As String = ""
        Dim IEVersion As String = ""
        Dim Res As Integer
        Dim appobj As Object
        Dim NonCera As Boolean 'Word.Application
        If Not hHelp.HHVerifyMinConfig(enumHHVersion.HH_1_2, enumIEVersion.IE_4_01_SP1, CType(HTMLVersion, Object), CType(IEVersion, Object)) Then
            If IEVersion = "" Then IEVersion = "nessuna"
            Testo = "La configurazione di questo computer non è adeguata" & vbCrLf
            Testo = Testo & "per l'utilizzo del sistema di guida in linea." & vbCrLf
            Testo = Testo & "Ciò può comportare problemi anche al di fuori " & vbCrLf
            Testo = Testo & "del sistema di guida in linea." & vbCrLf & vbCrLf
            Testo = Testo & "E' necessario istallare Internet Explorer 4.01+Service Pack 1, o superiore." & vbCrLf
            Testo = Testo & "La versione attualmente istallata è " & IEVersion & "." & vbCrLf
            Testo = Testo & "Qualora ciò sia già soddisfatto l'istallazione di Lancio" & vbCrLf
            Testo = Testo & "non è probabilmente aggiornata."
            MsgBox(Testo, CType(MsgBoxStyle.Information + MsgBoxStyle.OKOnly, MsgBoxStyle), "Lancio")
            Motore.Inizio.EmsChecked = CShort(False)
        Else
            Motore.Inizio.EmsChecked = CShort(True)
        End If
        HRes = CShort(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width)
        VRes = CShort(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height)
        If HRes < 1024 Or VRes < 768 Then
            Motore.Messaggio("", CType(ChiaviMess.MessExclamation + ChiaviMess.MessOkOnly + ChiaviMess.MessHelpButton, ChiaviMess), "Lancio - Messaggi di errore", RadiceHelp, IDHS.IDH_SIST_RISOL)
        End If
        'If Not Motore.Inizio.SeparatoreDecimale = "." Then
        'If Motore.Messaggio("", CType(ChiaviMess.MessInformation + ChiaviMess.MessYesNo + ChiaviMess.MessHelpButton, ChiaviMess), "Lancio", RadiceHelp, IDHS.IDH_SIST_SEPDEC) = ChiaviMess.MessSi Then
        'Res = Motore.Inizio.MettiPunto
        'If Res > 0 Then MsgBox("Errore n°" & Str(Res))
        'End If
        'End If
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
            Motore.MostraAiuto(-IDHS.IDH_WORD_ASSENTE, CType(ChiaviMess.MessCritical + ChiaviMess.MessHelpButton + ChiaviMess.MessOkOnly, ChiaviMess), Err.Description)
            Motore.Inizio.VersOffice = 0
            Exit Sub
        End If
        Err.Clear()
        '------------------------------- da mettere in Lancio-----------------
        If Val(appobj.Version) < 9.0# Then
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            If Motore.MostraAiuto(-IDHS.IDH_WORD_VECCHIO, CType(ChiaviMess.MessInformation + ChiaviMess.MessHelpButton + ChiaviMess.MessOKCancel, ChiaviMess), appobj.Version) = ChiaviMess.MessCancel Then
                Motore.Inizio.VersOffice = 0
            Else
                Motore.Inizio.VersOffice = 1
            End If
        Else
            Motore.Inizio.VersOffice = 2
        End If
        '--------------------------------------------------------------
        If NonCera Then appobj.Quit()
    End Sub
End Class