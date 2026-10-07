Option Strict On
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports System.IO.File
Imports System.IO.Path
Imports System.Runtime.InteropServices
Imports System.Threading
Imports System.Globalization
Imports RoutBase1
'Imports Microsoft.Office.Interop
Public Class clsInizio
    Private Structure NETRESOURCE
        Dim dwScope As Integer
        Dim dwType As Integer
        Dim dwDisplayType As Integer
        Dim dwUsage As Integer
        Dim lpLocalName As String
        Dim lpRemoteName As String
        Dim lpComment As String
        Dim lpProvider As String
    End Structure
    Private Structure REMOTE_NAME_INFO
        <MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPTStr)> _
        Public lpUniversalName As String
        <MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPTStr)> _
        Public lpConnectionName As String
        <MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPTStr)> _
        Public lpRemainingPath As String
    End Structure
    Private Enum INFO_LEVEL As Integer
        UNIVERSAL_NAME_INFO_LEVEL = 1
        REMOTE_NAME_INFO_LEVEL = 2
    End Enum
    Private Declare Function GetPrivateProfileString Lib "kernel32" Alias "GetPrivateProfileStringA" (ByVal lpApplicationName As String, _
    ByVal lpKeyName As String, ByVal lpDefault As String, ByVal lpReturnedString As String, ByVal lSize As Integer, ByVal lpFilename As String) As Integer
    Private Declare Function WritePrivateProfileString Lib "kernel32" Alias "WritePrivateProfileStringA" _
    (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpString As String, ByVal lplFilename As String) As Integer
    Private Declare Function GetPrivateProfileSection Lib "kernel32" Alias "GetPrivateProfileSectionA" _
    (ByVal lpAppName As String, ByVal lpReturnedString As String, ByVal nSize As Integer, ByVal lpFilename As String) As Integer
    Private Declare Function GetPrivateProfileSectionNames Lib "kernel32" Alias "GetPrivateProfileSectionNamesA" (ByVal lpReturnedString As String, ByVal nSize As Integer, ByVal lpFilename As String) As Integer
    Private Declare Function GetLastError Lib "kernel32" () As Integer
    Private Declare Auto Function WNetGetUniversalName Lib "mpr.dll" (<MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPTStr)> _
    ByVal lpLocalPath As String, ByVal dwInfoLevel As INFO_LEVEL, ByVal lpBuffer As IntPtr, ByRef lpBufferSize As Integer) As Integer
    Public Enum IDHS
        IDH_AUTOCAD_ASSENTE = 1050
        IDH_AUTOCAD_VECCHIO = 1051
        IDH_BASE_HTRI06 = 12000
        IDH_CAP_BANCHEDATI = 9000
        IDH_CAP_BD_MAT = 9010
        IDH_CAP_BD_MAT_CLASSE = 9020
        IDH_CAP_BD_MAT_SCELTA = 9030
        IDH_CAP_BD_MAT_SCHEDA = 9040
        IDH_CAP_BD_MAT_DATI = 9050
        IDH_CAP_BD_MAT_DATIFAT = 9051
        IDH_CAP_BD_MAT_DATIRIP = 9052
        IDH_CAP_BD_MAT_DATIDB = 9053
        IDH_ERR_AUTOEXECBAT = 10006
        IDH_ERR_AUTOEXECNT = 10007
        IDH_ERR_CHECKDIR = 10001
        IDH_ERR_LANCIOINI = 10000
        IDH_ERR_LIBMAT_NOLISTINO = 10020
        IDH_ERR_LIBMAT_NOINDMAT = 10021
        IDH_ERR_LIBMAT_EMODALT1 = 10022
        IDH_ERR_LIBMAT_EMODALT2 = 10023
        IDH_ERR_LIBMAT_ALFATER1 = 10024
        IDH_ERR_LIBMAT_ALFATER2 = 10025
        IDH_ERR_LIBMAT_LEGRAT1 = 10026
        IDH_ERR_LIBMAT_LEGRAT2 = 10027
        IDH_ERR_LIBMAT_CONDUC1 = 10028
        IDH_ERR_LIBMAT_CONDUC2 = 10029
        IDH_ERR_LIBMAT_NODIV1 = 10030
        IDH_ERR_LIBMAT_NODIV1a = 10031
        IDH_ERR_LIBMAT_NOVALOR1 = 10032
        IDH_ERR_LIBMAT_NOVALOR2 = 10033
        IDH_ERR_LIBMAT_IMPREV1 = 10034
        IDH_ERR_LIBMAT_IMPREV2 = 10035
        IDH_ERR_LIBMAT_NOFILEAGG = 10036
        IDH_ERR_LIBMAT_NODIV1b = 10037
        IDH_FINLANCIO_BOTTAFC = 2500
        IDH_FINLANCIO_BOTTST = 2501
        IDH_FINLANCIO_BOTTWHB = 2502
        IDH_FINLANCIO_BOTTWPS = 2503
        IDH_FINLANCIO_BOTTPRECONS = 2504
        IDH_FINLANCIO_BOTTUTIL = 2505
        IDH_FINLANCIO_BOTTGEST = 2506
        IDH_INIZIO_CAMBIORETE = 2000
        IDH_INIZIO_RISPOSTASI = 2001
        IDH_INIZIO_LAVSCIOLTI = 2002
        IDH_INIZIO_LAVCOMMESS = 2003
        IDH_INIZIO_ESEGUIBILI = 2004
        IDH_INIZIO_ARCHIVI = 2005
        IDH_INIZIO_BRT = 2006
        IDH_INIZIO_CAMBIORETE1 = 2007
        IDH_INTERNO_LISTINO1 = 11001
        IDH_INTERNO_LISTINO2 = 11002
        IDH_INTERNO_LISTINO3 = 11003
        IDH_INTERNO_LISTINO4 = 11004
        IDH_INTERNO_LISTINO5 = 11005
        IDH_INTERNO_LISTINO6 = 11006
        IDH_INTERNO_LISTINO7 = 11007
        IDH_INTERNO_LISTINO8 = 11008
        IDH_INTERNO_LISTINO9 = 11009
        IDH_INTERNO_TIT = 11020
        IDH_LISTINO_HELP = 11030
        IDH_LISTINO_MSG = 11040
        IDH_LISTINO_TIT = 11050
        IDH_LISTINO_TIT1 = 11051
        IDH_LB_SCHEDA_DENOM = 2550
        IDH_LB_SCHEDA_CLASSIF = 2551
        IDH_LB_SCHEDA_CARACT = 2552
        IDH_LB_SCHEDA_GRUPPO = 2553
        IDH_LB_SCHEDA_PREZZI = 2554
        IDH_LB_SCHEDA_DATICODICE = 2555
        IDH_LB_SCHEDA_FONTE = 2556
        IDH_LB_SCHEDA_SNERV = 2557
        IDH_LB_SCHEDA_CHART = 2558
        IDH_LB_SCHEDA_PNUMBER = 2559
        IDH_LB_SCHEDA_MWDTRULES = 2560
        IDH_LB_SCHEDA_MWDTRULES1 = 2561
        IDH_LB_SCHEDA_MWDTRULES2 = 2562
        IDH_LB_SCHEDA_MWDTRULES3 = 2563
        IDH_LB_SCHEDA_TABELL1 = 2564
        IDH_LB_SCHEDA_TABELL2 = 2565
        IDH_OPZIONE_LAVSCIOLTI = 2010
        IDH_SIST_RISOL = 1000
        IDH_SIST_LINGUA = 1010
        IDH_SIST_SEPDEC = 1020
        IDH_SIST_STAMP = 1030
        IDH_UPASME_NODBASME = 10050
        IDH_UPASME_NODBMATE = 10051
        IDH_WORD_ASSENTE = 1040
        IDH_WORD_VECCHIO = 1041
        LIC_MSG1 = 60
        LIC_MSG2 = 61
        MSG_AMMISSCALDO = 500
        MSG_AMMISSFREDDO = 510
        MSG_YIELDCALDO = 520
        MSG_YIELDFREDDO = 530
        MSG_YOUNGCALDO = 540
        MSG_YOUNGFREDDO = 550
        MSG_ALFACALDO = 560
        MSG_ALFAFREDDO = 570
        PIP_TITLE = 49
        PIP_HELP = 50
        PIP_NINPUT = 51
        PIP_BASE = 52
        PIP_BASE_1 = 52
        PIP_BASE_2 = 53
    End Enum
    Private WithEvents lApp As Word.Application
    Private Const NO_ERROR As Integer = 0
    Private Const ERROR_MORE_DATA As Integer = 234  '  dderror
    Private Const LINGUAUS As String = "English United States"
    Private Const gintMAX_SIZE As Short = 32000
    Private Const gstrNULL As String = ""
    Private Const gstrSEP_URLDIR As String = "/" ' Separatore per dividere le directory negli indirizzi URL.
    'Private Const gstrSEP_DIR As String = "\" ' Carattere di separazione delle directory.
    Private Cancellato As Boolean
    Public WinSys, ProgMain As String
    Public Basedir As String
    Public Workdir As String
    Public Archdir As String
    Public Datidir As String
    Public DBFdir As String
    Public Brt As String
    Public AppLancio As String
    Public Gancio As String
    Public StampPort As String
    Public ImmedStam As Short 'ora è num utente
    Public BackGround As Short
    Public TipoStam As Short
    Public VersOffice As Short '1 Office97 2 Office2000
    Public EmsChecked As Short '0 non checkato, 1 c'Š, 2 non c'Š
    Public InRete As Boolean
    Public InizioP As Short
    'Public Percorsi  As String
    Public DiscoRam As String
    Public DiscoTem As String
    Public AddDistinta As Short
    Public UnitServer As String
    Public Utente As String
    Public LavoriSciolti As Boolean
    Public WithEvents Motore As clsMotore
    Public Function Firma() As String
        Dim Fir As String
        Fir = ReadIniFile("", "Azienda", "Firma")
        If Fir = "" Then
            Fir = "FBM-HUDSON ITALIANA S.p.A."
        Else
            If Len(Fir) < 26 Then
                Fir = Space((26 - Len(Fir)) \ 2) & Fir
            Else
                Fir = Left(Fir, 26)
            End If
        End If
        Firma = Fir
    End Function
    Public Sub Immatricolazione(ByRef Documento As StubW2000.clsSW2000, ByRef Comm As String, ByRef numero As String)
        If Len(numero) <> 5 Then numero = "SC001"
        Documento.Riempi("NoFBM", Comm, numero)
        Documento.Riempi("CarInt1", Comm, numero)
        Documento.NienteGrammatica()
    End Sub
    Function PrintInizio() As Boolean
        Dim FLancio As String
        Dim i As Short
        Dim Rete As Boolean
        Dim strRete As String
        Rete = SeiInRete(Basedir)
        Rete = Rete Or SeiInRete(Archdir)
        PrintInizio = True
        FLancio = FileIni()
        If Len(FLancio) = 0 Then Exit Function
        If Not InRete And Rete Then
            If Motore.MostraAiuto(IDHS.IDH_INIZIO_CAMBIORETE, CType(ChiaviMess.MessQuestion + ChiaviMess.MessYesNo + ChiaviMess.MessHelpButton, ChiaviMess)) = ChiaviMess.MessSi Then
                If Motore.MostraAiuto(IDHS.IDH_INIZIO_RISPOSTASI, CType(ChiaviMess.MessInformation + ChiaviMess.MessOKCancel + ChiaviMess.MessHelpButton, ChiaviMess)) = ChiaviMess.MessOK Then
                    WriteIniFile(FLancio, "Percorsi", "FunzionamentoInRete", "Si")
                    InRete = True
                    PrintInizio = False
                Else
                    Exit Function
                End If
            Else
                Exit Function
            End If
        End If
        If InRete And Not Rete Then
            If Motore.MostraAiuto(IDHS.IDH_INIZIO_CAMBIORETE1, CType(ChiaviMess.MessQuestion + ChiaviMess.MessYesNo + ChiaviMess.MessHelpButton, ChiaviMess)) = ChiaviMess.MessSi Then
                InRete = False
                WriteIniFile(FLancio, "Percorsi", "FunzionamentoInRete", "No")
            End If
        End If
        If InRete Then strRete = "Si" Else strRete = "No"
        WriteIniFile(FLancio, "Percorsi", "DiscoBase", UCase(UnitServer))
        If Basedir.EndsWith("\") Then Stop
        WriteIniFile(FLancio, "Percorsi", "BaseDir", UCase(Basedir))
        WriteIniFile(FLancio, "Percorsi", "WorkDir", UCase(Workdir))
        WriteIniFile(FLancio, "Percorsi", "ArchDir", UCase(Archdir))
        WriteIniFile(FLancio, "Percorsi", "DatiDir", UCase(Datidir))
        WriteIniFile(FLancio, "Percorsi", "DiscoRam", UCase(DiscoRam))
        WriteIniFile(FLancio, "Percorsi", "DBFdir", UCase(DBFdir))
        WriteIniFile(FLancio, "Percorsi", "Gancio", UCase(Gancio))
        WriteIniFile(FLancio, "Percorsi", "FunzionamentoInRete", strRete)
        WriteIniFile(FLancio, "Utente", "Percorsi", "NULL") ' UCase(Percorsi)
        WriteIniFile(FLancio, "Parametri", "TipoStam", Str(TipoStam))
        WriteIniFile(FLancio, "Parametri", "ImmedStam", Str(ImmedStam))
        WriteIniFile(FLancio, "Parametri", "BackGround", Str(BackGround))
        WriteIniFile(FLancio, "Parametri", "VersOffice", Str(VersOffice))
        i = CShort(LavoriSciolti)
        WriteIniFile(FLancio, "Parametri", "LavoriSciolti", Str(i))
        WriteIniFile(FLancio, "Stampante", "StampPort", StampPort)
    End Function
    Public Sub SuperStampa(ByRef File As String, Optional ByRef Stub As StubW2000.clsSW2000 = Nothing, _
                           Optional ByRef NonAttivare As Boolean = False, Optional ByVal wordPanel As Lancio.Office.Word.WinForms.WordReportPanel = Nothing)
        Dim Testo As String ', Stub As Object
        Dim Errore As Boolean = False
        If VersOffice = 0 Then Exit Sub
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        Dim Vecchio As Boolean = wordPanel Is Nothing
        If Not Vecchio Then Vecchio = Not wordPanel.Enabled
        If Vecchio Then
            Try
                lApp = CType(GetObject(, "Word.Application"), Word.Application)   '"Word.Application"
            Catch
                Try
                    lApp = CType(CreateObject("Word.Application"), Word.Application) '"Word.Application"
                Catch ex As Exception
                    Errore = True
                End Try
            End Try
            If Errore Then
                '         Testo = "Impossibile lanciare Word." + vbCrLf
                ' Testo = Testo + "(" + Err.Description + ")"
                ' MsgBox Testo, vbCritical + vbOKOnly
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
                Motore.MostraAiuto(-IDHS.IDH_WORD_ASSENTE, CType(ChiaviMess.MessCritical + ChiaviMess.MessHelpButton + ChiaviMess.MessOkOnly, ChiaviMess), Err.Description)
                Exit Sub
            End If
            Try
7:              If Not NonAttivare Then
                    lApp.Visible = True
                    lApp.WindowState = CType(1, Word.WdWindowState) ' wdWindowStateMaximize
                    AppActivate(lApp.Application.Caption)
                End If
            Catch
                If Not Stub Is Nothing Then GoTo 31
            End Try
            Select Case VersOffice
                Case 1
                    Stop
                Case 2
                    Stub = New StubW2000.clsSW2000
                Case Else
                    MsgBox("VersOffice =" & Str(VersOffice))
                    lApp.Quit()
                    Exit Sub
            End Select
            Stub.App = lApp
31:         If File.Trim.Length > 0 Then
                If System.IO.File.Exists(File) Then
                    Stub.sOpen(File)
                Else
                    Stub.sOpen("")
                    Stub.sSaveAs(File)
                End If
            Else
                Stub.sOpen("")
            End If
50:         If Err.Number > 0 Then
                Testo = "Impossibile aprire " & File & vbCrLf
                Testo = Testo & "(" & Err.Description & ";" & Str(Erl()) & ")"
                MsgBox(Testo, CType(MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, MsgBoxStyle))
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
                Stub = Nothing 'Doc = Nothing
                Exit Sub
            End If
            If Not NonAttivare Then Stub.sView()
        Else
            Try
                wordPanel.EnsureStarted()
                Stub = New StubW2000.clsSW2000
                If File.Trim.Length > 0 AndAlso System.IO.File.Exists(File) Then
                    wordPanel.LoadDocument(File)
                Else
                    wordPanel.CreateDocument()
                    If File.Trim.Length > 0 Then wordPanel.OfficeSession.SaveAs(File)
                End If
                Stub.WordDocument = CType(wordPanel.NativeDocument, Word.Document)
                Stub.App = CType(wordPanel.NativeApplication, Word.Application)
                If Not NonAttivare Then wordPanel.ShowWord()
            Catch ex As Exception
                MessageBox.Show(ex.Message + vbCrLf + ex.StackTrace)
                Stub = Nothing
            End Try
        End If
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        Exit Sub
    End Sub
    ' Public Sub LanciaExcel(ByRef File As String, Optional ByRef Doc As Excel.Workbook = Nothing)
    '     Dim App As Excel.Application
    '     Dim Testo As String
    '     'UPGRADE_WARNING: Screen proprietà Screen.MousePointer presenta un nuovo comportamento. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup2065"'
    '     System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
    '     On Error Resume Next
    '     App = CType(GetObject(, "Excel.Application"), Excel.Application)
    '     If Err.Number > 0 Then
    '         Err.Clear()
    '         App = CType(CreateObject("Excel.Application"), Excel.Application)
    '     End If
    '     If Err.Number > 0 Then
    '         Testo = "Impossibile lanciare Excel." & vbCrLf
    '         Testo = Testo & "(" & Err.Description & ")"
    '         MsgBox(Testo, CType(MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, MsgBoxStyle))
    '         System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
    '         On Error GoTo 0
    '         Exit Sub
    '     End If
    '     Err.Clear()
    '     Doc = App.Workbooks.Open(File)
    '     If Err.Number > 0 Then
    '         Testo = "Impossibile aprire " & File & vbCrLf
    '         Testo = Testo & "(" & Err.Description & ")"
    '         MsgBox(Testo, CType(MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, MsgBoxStyle))
    '         System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
    '         'UPGRADE_NOTE: È possibile che l'oggetto Doc non venga eliminato finché non venga raccolto nel Garbage Collector. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1029"'
    '         Doc = Nothing
    '         Exit Sub
    '     End If
    '     On Error GoTo 0
    '     System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
    ' End Sub
    Public Function ConvertiCr(ByRef Testo As String) As String
        If Testo Is Nothing Then
            Return ""
        Else
            Return Testo.Replace("|", vbCrLf)
        End If
    End Function
    Public Function QuestoComputer() As String
        QuestoComputer = Environment.MachineName
    End Function
    Public Function QuestoProgramma() As String
        'QuestoProgramma = Reflection.AssemblyName
        QuestoProgramma = Reflection.Assembly.GetExecutingAssembly.GetName.Name
    End Function
    '    Public Sub BrtSet()
    '        Dim i, n As Short
    '        Dim Comm, EnvString, Testo As String
    '        Dim iSh, Res As Integer
    '        If Not ReadIniFile("", "Avvio", "BrtSet") = "Si" Then Exit Sub
    '        If GiaFattoB Then Exit Sub
    '        If Right(AppLancio, 1) = gstrSEP_DIR Then
    '            Brt = AppLancio & "BIN"
    '        Else
    '            Brt = AppLancio & "\BIN"
    '        End If
    '        'Brt = System.IO.Path.GetDirectoryName(Brt)
    '        Dim PlatformID As System.PlatformID = Environment.OSVersion.Platform
    '        Select Case PlatformID
    '            Case PlatformID.Win32NT
    '                TrattaNT(Brt, PlatformID)
    '                GiaFattoB = True
    '                Exit Sub
    '            Case PlatformID.Win32Windows
    '                If Environment.OSVersion.Version.Major = 4 And Environment.OSVersion.Version.Minor >= 90 Then
    '                    TrattaNT(Brt, PlatformID)
    '                    GiaFattoB = True
    '                    Exit Sub
    '                End If
    '            Case PlatformID.Win32S
    '                MsgBox("Questo software non è stato testato su piattaforme Win32s o Windows 3.1", MsgBoxStyle.Information)
    '            Case PlatformID.WinCE
    '                MsgBox("Questo software non è stato testato su piattaforme Windows CE", MsgBoxStyle.Information)
    '        End Select
    '        i = 1 ' Initialize index to 1.
    '        Dim environmentVariables As IDictionary = Environment.GetEnvironmentVariables()
    '        Dim de As DictionaryEntry
    '        For Each de In environmentVariables
    '            '  Console.WriteLine("  {0} = {1}", de.Key, de.Value)
    '            If UCase(CStr(de.Key)) = "PATH" Then ' Check PATH entry.
    '                EnvString = CStr(de.Value)
    '                Comm = Brt & "\WINSET.EXE PATH=" & Brt & ";" & EnvString '%PATH%;" + Brt 'C:\BASE\ESEGUI\BIN"'"\WINSET.PIF"
    '            Try
    '                iSh = Shell(Comm)
    '            Catch e As Exception
    '                Testo = "Non è stato possibile comunicare a Windows" & vbCrLf
    '                Testo = Testo & "il cammino di rircerca di 'BRT71EFR.EXE'." & vbCrLf
    '                Testo = Testo & "Non sarà quindi possibile lanciare i programmi DOS." & vbCrLf
    '                Testo = Testo & "L'esecuzione continua"
    '                MsgBox(Testo, MsgBoxStyle.Information)
    '            End Try
    '            GiaFattoB = True
    '            Exit Sub
    '        End If
    '    Next de
    '    MsgBox("Nelle variabili di ambiente non è stato possibile trovare PATH")
    'End Sub
    Public Function CommPulita(ByRef icome As String) As String
        Dim File As String
        Dim l As Short
        File = System.IO.Path.GetFileName(icome)
        l = CShort(InStr(File, "."))
        If l > 0 Then File = Left(File, l - 1)
        Do
            l = CShort(InStr(File, "-"))
            If l = 0 Then
                Exit Do
            Else
                File = Left(File, l - 1) & Right(File, Len(File) - l)
            End If
        Loop
        CommPulita = File.Trim
    End Function
    Function StripTerminator(ByVal strString As String) As String
        '-----------------------------------------------------------
        ' Funzione: StripTerminator
        '
        ' Restituisce una stringa senza zero come carattere di
        ' terminazione. In genere si applica alle stringhe restituite
        ' dalle chiamate all'API di Windows.
        '
        ' In: [strString]: stringa da cui rimuovere il carattere di
        '                  terminazione.
        '
        ' Restituisce: valore della stringa passata meno gli eventuali
        '              zero finali.
        '-----------------------------------------------------------
        '
        Dim intZeroPos As Short

        intZeroPos = CShort(InStr(strString, Chr(0)))
        If intZeroPos > 0 Then
            StripTerminator = Left(strString, intZeroPos - 1)
        Else
            StripTerminator = strString
        End If
    End Function
    Function AddDirSep(ByVal strPathName As String) As String
        '-----------------------------------------------------------
        ' Sub: AddDirSep
        ' Aggiunge un carattere di separazione di directory (ovvero
        ' una barra rovesciata) alla fine del nome di percorso, a
        ' meno che tale carattere non sia già presente.
        '
        ' In/Out: [strPathName]: percorso in cui viene aggiunto il
        '                        separatore.
        '-----------------------------------------------------------
        '
        AddDirSep = strPathName
        Dim n As Integer = gstrSEP_URLDIR.Length
        Dim n1 As Integer = gstrSEP_DIR.Length
        Dim stringa As String = strPathName.Trim
        If Not stringa.Substring(stringa.Length - n, n) = gstrSEP_URLDIR _
        And Not stringa.Substring(stringa.Length - n1, n1) = gstrSEP_DIR Then
            AddDirSep = stringa & gstrSEP_DIR
        End If
    End Function
    '    Public Function Legale(ByRef com As String, ByRef Tit As String) As Boolean
    '        Dim fErr As Boolean
    '        Dim Exec, Testo As String
    '        If Len(com) = 0 Then GoTo Errore
    '        Exec = ""
    '        If fErr Or Len(com) = 0 Then GoTo Errore
    '        If InStr(com, "-n") = 0 Then GoTo Errore
    '        Legale = True
    '        Exit Function
    'Errore:
    '        'If Trigon Is Nothing Then Set Trigon = New clsTrigon
    '        'Exec = Trigon.GetFileName(Exec)
    '        If Len(Exec) = 0 Then Exec = Tit
    '        Testo = "Si è tentato di lanciare direttamente l'eseguibile " & Exec
    '        Testo = Testo & ". Ciò non è consentito. E' necessario eseguire Lancio."
    '        MsgBox(Testo, MsgBoxStyle.Critical, "Lancio")
    '    End Function
    Public Function Standard() As Short
        Dim FLancio As String
        Dim i As Short
        FLancio = FileIni()
        If Len(FLancio) = 0 Then Standard = 1 : Exit Function
        UnitServer = ReadIniFile(FLancio, "Percorsi", "DiscoBase")
        'MsgBox "|" + UnitServer + "|", , "Prova Standard"
        If Len(UnitServer) = 0 Then
            Motore.MostraAiuto(IDHS.IDH_ERR_LANCIOINI)
            Standard = 2
            Exit Function
        End If
        UnitServer = AddDirSep(UnitServer)
        'Dim Programmi As String = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles)
        Basedir = ReadIniFile(FLancio, "Percorsi", "BaseDir")
        Workdir = ReadIniFile(FLancio, "Percorsi", "WorkDir") 'Basedir & "\Work" '
        Archdir = ReadIniFile(FLancio, "Percorsi", "ArchDir") 'Basedir & "\Arch" '
        Datidir = ReadIniFile(FLancio, "Percorsi", "DatiDir")  'Basedir & "\Dati"
        AppLancio = Basedir 'ReadIniFile(FLancio, "Percorsi", "AppLancio")
        Motore.RadiceHelp = AppLancio & "\BIN\Lancio.chm"
        DiscoRam = Basedir & "\TEMP\" ' AddDirSep(ReadIniFile(FLancio, "Percorsi", "DiscoRam"))
        DiscoTem = DiscoRam
        DBFdir = "" 'ReadIniFile(FLancio, "Percorsi", "DBFdir")
        Gancio = Workdir & "\DATI.TEM" ' ReadIniFile(FLancio, "Percorsi", "Gancio")
        InRete = ReadIniFile(FLancio, "Percorsi", "FunzionamentoInRete") = "Si"
        'Percorsi = ReadIniFile(FLancio, "Utente", "Percorsi")
        TipoStam = 3 ' CShort(Val(ReadIniFile(FLancio, "Parametri", "TipoStam")))
        ImmedStam = 1 ' CShort(Val(ReadIniFile(FLancio, "Parametri", "ImmedStam")))
        BackGround = -1 ' CShort(Val(ReadIniFile(FLancio, "Parametri", "BackGround")))
        VersOffice = 2 'CShort(Val(ReadIniFile(FLancio, "Parametri", "VersOffice")))
        i = CShort(Val(ReadIniFile(FLancio, "Parametri", "LavoriSciolti")))
        LavoriSciolti = CBool(i)
        StampPort = ReadIniFile(FLancio, "Stampante", "StampPort")
        If Not CheckDir() Then Standard = 3
    End Function
    Public Function ReadIniFile(ByVal strIniFile As String, ByVal strSection As String, ByVal strKey As String) As String
        Dim strBuffer As String
        If Len(strIniFile) = 0 Then strIniFile = FileIni()
        If Len(strIniFile) = 0 Then Return ""
        '
        'Se la lettura dal file .ini ha avuto esito positivo, elimina gli eventuali zeri
        'restituiti dalla funzione GetPrivateProfileString dell'API di Windows.
        '
        strBuffer = Space(gintMAX_SIZE)

        If GetPrivateProfileString(strSection, strKey, gstrNULL, strBuffer, gintMAX_SIZE, strIniFile) > 0 Then
            ReadIniFile = RTrim(StripTerminator(strBuffer))
        Else
            ReadIniFile = gstrNULL
        End If
    End Function
    Public Function WriteIniFile(ByVal strIniFile As String, ByVal strSection As String, ByVal strKey As String, ByVal strBuffer As String) As Integer
        If Len(strIniFile) = 0 Then strIniFile = FileIni()
        If Len(strIniFile) = 0 Then WriteIniFile = 1 : Exit Function
        strBuffer = strBuffer & Chr(0)
        WriteIniFile = WritePrivateProfileString(strSection, strKey, strBuffer, strIniFile)
    End Function
    Public Function ReadProfileSection(ByVal File As String, ByVal Section As String, ByRef colSection() As String) As Integer
        Dim n As Integer, Buffer As String, Dato As String
        Buffer = New String(CChar(" "), gintMAX_SIZE)
        n = GetPrivateProfileSection(Section, Buffer, gintMAX_SIZE, File)
        ReDim colSection(20)
        Dim i As Integer
        Do
            n = Buffer.IndexOf(Chr(0)) ' InStr(Buffer, Chr(0))
            If n <= 0 Then Exit Do
            Dato = Buffer.Substring(0, n)   ' Left(Buffer, n - 1)
            colSection(i) = Dato
            If Buffer.Length - n <= 0 Then Exit Do
            Buffer = Buffer.Substring(n + 1) ' Right(Buffer, Len(Buffer) - n)
            i = i + 1
            If i = UBound(colSection) Then ReDim Preserve colSection(2 * i)
        Loop
        Return i
    End Function
    Public Function ReadProfileSectionNames(ByVal File As String, ByRef Names() As String) As Integer
        Dim n As Integer, Buffer As String, Dato As String
        Buffer = New String(CChar(" "), gintMAX_SIZE)
        n = GetPrivateProfileSectionNames(Buffer, gintMAX_SIZE, File)
        Dim i As Integer
        ReDim Names(20)
        Do
            n = Buffer.IndexOf(Chr(0)) ' InStr(Buffer, Chr(0))
            If n <= 0 Then Exit Do
            Dato = Buffer.Substring(0, n)   ' Left(Buffer, n - 1)
            Names(i) = Dato
            If Buffer.Length - n <= 0 Then Exit Do
            Buffer = Buffer.Substring(n + 1) ' Right(Buffer, Len(Buffer) - n)
            i = i + 1
            If i = UBound(Names) Then ReDim Preserve Names(2 * i)
        Loop
        Return i
    End Function
    Private Function CheckDir() As Boolean
        Dim drive, Testo As String
        On Error GoTo ErrCD
        If IsUNCName(UnitServer) Then
            Testo = "Il file " & ProgMain & " contiene riferimenti a percorsi di tipo UNC.| Ciò non è accettabile."
            MsgBox(ConvertiCr(Testo), MsgBoxStyle.Critical, ProgMain)
            Exit Function
        End If
        ChDrive(UnitServer)
        ChDrive(Basedir)
        ChDir(Basedir)
        On Error GoTo ErrDR
        ChDir(DiscoRam)
        On Error GoTo ErrWK
        ChDir(Workdir)
        On Error GoTo ErrDD
        ChDir(Datidir)
        On Error GoTo ErrAD
        ChDir(Archdir)
        ChDir(Basedir)
        CheckDir = True
        Exit Function
ErrCD:
        Resume ExCD
ExCD:
        Testo = Motore.Inizio.ConvertiCr(HelpStringa(IDHS.IDH_ERR_CHECKDIR)) + vbCrLf
        '        Testo = "Le informazioni contenute in LANCIO.INI non sono corrette,|oppure ci sono dei problemi di rete." + vbCrLf
        Testo = Testo & Err.Description & vbCrLf
        Testo = Testo & "Basedir = " & Basedir
        Motore.MostraAiuto(IDHS.IDH_ERR_CHECKDIR, , Testo)
        Exit Function
ExDR:
        Testo = Motore.Inizio.ConvertiCr(HelpStringa(IDHS.IDH_ERR_CHECKDIR)) + vbCrLf
        Testo = Testo & Err.Description & vbCrLf
        Testo = Testo & "Controllare: Discoram = " & DiscoRam
        Motore.MostraAiuto(IDHS.IDH_ERR_CHECKDIR, , Testo)
        Exit Function
ErrDR:
        Resume ExDR
ExWK:
        Testo = Motore.Inizio.ConvertiCr(HelpStringa(IDHS.IDH_ERR_CHECKDIR)) + vbCrLf
        Testo = Testo & Err.Description & vbCrLf
        Testo = Testo & "Controllare: Workdir = " & Workdir
        Motore.MostraAiuto(IDHS.IDH_ERR_CHECKDIR, , Testo)
        Exit Function
ErrWK:
        Resume ExWK
ExDD:
        Testo = Motore.Inizio.ConvertiCr(HelpStringa(IDHS.IDH_ERR_CHECKDIR)) + vbCrLf
        Testo = Testo & Err.Description & vbCrLf
        Testo = Testo & "Controllare: Datidir = " & Datidir
        Motore.MostraAiuto(IDHS.IDH_ERR_CHECKDIR, , Testo)
        Exit Function
ErrDD:
        Resume ExDD
ExAD:
        Testo = Motore.Inizio.ConvertiCr(HelpStringa(IDHS.IDH_ERR_CHECKDIR)) + vbCrLf
        Testo = Testo & Err.Description & vbCrLf
        Testo = Testo & "Controllare: ArchDir = " & Archdir
        Motore.MostraAiuto(IDHS.IDH_ERR_CHECKDIR, , Testo)
        Exit Function
ErrAD:
        Resume ExAD
    End Function
    Public Function IsUNCName(ByVal strPathName As String) As Boolean
        Const strUNCNAME As String = "\\//\" 'so can check for \\, //, \/, /\
        IsUNCName = ((InStr(strUNCNAME, Left(strPathName, 2)) > 0) And (Len(strPathName) > 1))
    End Function
    Public Function LanciaAutoCAD(ByRef objAcadDoc As AutoCAD.AcadDocument, Optional ByRef Caricalin As Short = 0, Optional ByRef Silent As Boolean = False) As Short
        Dim Testo As String
        Dim objAcadApp As AutoCAD.AcadApplication
        Dim Vers As String
        Dim frm As System.Windows.Forms.Form
        Dim sset As AutoCAD.AcadSelectionSet
        Dim i As Short
        Dim ssobj() As AutoCAD.AcadEntity
        'UPGRADE_NOTE: È possibile che l'oggetto objAcadDoc non venga eliminato finché non venga raccolto nel Garbage Collector. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1029"'
        objAcadDoc = Nothing
        frm = frmMessage.DefInstance
        Trigon.CenterForm(frm)
        On Error GoTo ErrMode
        frm.Show()
        On Error GoTo 0
        System.Windows.Forms.Application.DoEvents()
        'UPGRADE_WARNING: Screen proprietà Screen.MousePointer presenta un nuovo comportamento. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup2065"'
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        On Error Resume Next
        objAcadApp = CType(GetObject(, "AutoCAD.Application"), AutoCAD.AcadApplication)
        If Err.Number > 0 Then
            Err.Clear()
            objAcadApp = CType(CreateObject("AutoCAD.Application"), AutoCAD.AcadApplication)
        End If
        If Err.Number > 0 Or objAcadApp Is Nothing Then
            On Error GoTo 0
            '                Testo = "Impossibile lanciare AutoCad." + vbCrLf
            '        Testo = Testo + "(" + Err.Description + ")"
            '        If Not Silent Then MsgBox Testo, vbCritical + vbOKOnly, Motore.About.ProgName
            Err.Clear()
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            If Not Silent Then Motore.MostraAiuto(-IDHS.IDH_AUTOCAD_ASSENTE, CType(ChiaviMess.MessCritical + ChiaviMess.MessHelpButton + ChiaviMess.MessOkOnly, ChiaviMess), Err.Description)
            LanciaAutoCAD = 1
            If Not frm Is Nothing Then frm.Hide()
            Exit Function
        End If
        Err.Clear()
        On Error GoTo 0
        Vers = objAcadApp.Version
        If Val(Vers) < 15 Then
            '         Testo = "Questo programma richiede AutoCAD nella versione" + vbCrLf
            ' Testo = Testo + "15 (AutoCad 2000) o superiore." + vbCrLf
            ' Testo = Testo + "La versione istallata su questo computer è " + Vers + vbCrLf
            ' Testo = Testo + "L'esecuzione continua senza AutoCAD in linea."
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            '        If Not Silent Then MsgBox Testo, vbOKOnly + vbInformation, Motore.About.ProgName
            If Not Silent Then Motore.MostraAiuto(-IDHS.IDH_AUTOCAD_VECCHIO, CType(ChiaviMess.MessCritical + ChiaviMess.MessHelpButton + ChiaviMess.MessOkOnly, ChiaviMess), Vers)
            LanciaAutoCAD = 2
            objAcadApp.Quit()
            If Not frm Is Nothing Then frm.Hide()
            Exit Function
        End If
        objAcadApp.Visible = True
        On Error Resume Next
        objAcadDoc = objAcadApp.ActiveDocument
        On Error GoTo 0
        If objAcadDoc Is Nothing Then
            '        Set objAcadDoc = objAcadApp.Documents.Add
        Else
            '        ReDim ssobj(objAcadDoc.ModelSpace.Count - 1) As AutoCAD.AcadEntity
            '        For i = 0 To objAcadDoc.ModelSpace.Count - 1
            '            Set ssobj(i) = objAcadDoc.ModelSpace.Item(i)
            '        Next
            '        Set sset = objAcadDoc.SelectionSets.Add("Tutto")
            '        sset.AddItems ssobj
            '        sset.Erase
            objAcadDoc.Close()
        End If
        objAcadDoc = objAcadApp.Documents.Add
        If Caricalin <> 0 Then Caricalinee(objAcadDoc)
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        If Not frm Is Nothing Then frm.Hide()
        Exit Function
ErrMode:
        Select Case Err.Number
            Case 401 'impossibile visualizzare un form non obbligatorio quando....
                'UPGRADE_ISSUE: Il codice scaricato frm non è stato aggiornato. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup2029"'
                MsgBox(Err.Description & Str(Err.Number) & " in LanciaAutoCAD")
                frm.Hide()
                'UPGRADE_NOTE: È possibile che l'oggetto frm non venga eliminato finché non venga raccolto nel Garbage Collector. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1029"'
                frm = Nothing
                Resume Next
            Case Else
                MsgBox(Err.Description & Str(Err.Number) & " in LanciaAutoCAD")
        End Select
    End Function
    '    Public Function SeparatoreDecimale() As String
    '        SeparatoreDecimale = Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator
    '    End Function
    Public Function LinguaPaeseIngl() As String
        ' Dim Buffer As String
        ' Dim UserLCID As Integer
        ' Dim mChar As Integer
        ' Dim Testo As String
        ' UserLCID = GetUserDefaultLCID
        ' mChar = GetLocaleInfo(UserLCID, LOCALE_SENGLANGUAGE, Buffer, 0)
        ' Buffer = Space(mChar)
        ' mChar = GetLocaleInfo(UserLCID, LOCALE_SENGLANGUAGE, Buffer, mChar)
        ' 'FIXIT: Sostituire la funzione "Left" con la funzione "Left$"                              FixIT90210ae-R9757-R1B8ZE
        ' Testo = Left(Buffer, mChar - 1)
        ' mChar = GetLocaleInfo(UserLCID, LOCALE_SENGCOUNTRY, Buffer, 0)
        ' Buffer = Space(mChar)
        ' mChar = GetLocaleInfo(UserLCID, LOCALE_SENGCOUNTRY, Buffer, mChar)
        ' 'FIXIT: Sostituire la funzione "Left" con la funzione "Left$"                              FixIT90210ae-R9757-R1B8ZE
        ' Testo = Testo & " " & Left(Buffer, mChar - 1)
        ' LinguaPaeseIngl = Testo
        LinguaPaeseIngl = Thread.CurrentThread.CurrentCulture.EnglishName
    End Function
    Public Function EUS() As Boolean
        Dim Testo As String
        Testo = LinguaPaeseIngl()
        EUS = Testo = LINGUAUS
    End Function
    Public Function LinguaPaese() As String
        LinguaPaese = Thread.CurrentThread.CurrentCulture.DisplayName
    End Function
    '   Public Function MettiPunto() As Short
    '        Dim Buffer As String
    '        Dim UserLCID As Integer
    '        Dim Res, Dummy As Integer
    '        Buffer = "." & Chr(0)
    '        Res = SetLocaleInfo(UserLCID, LOCALE_SDECIMAL, Buffer)
    '        If Res = 0 Then
    '            Res = GetLastError
    '        Else
    '            Res = 0
    '            SendMessageTimeout(HWND_BROADCAST, WM_SETTINGCHANGE, 0, 0, SMTO_ABORTIFHUNG, 2000, Dummy)
    '        End If
    '       MettiPunto = Res
    '      Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator = "."
    '      Thread.CurrentThread.CurrentCulture.NumberFormat.NumberGroupSeparator = ","
    '  End Function
    Public Function SeiInRete(ByRef Path As String) As Boolean
        Dim drive, UNC As String
        If Len(Path) < 2 Then Exit Function
        'FIXIT: Sostituire la funzione "Left" con la funzione "Left$"                              FixIT90210ae-R9757-R1B8ZE
        drive = Left(Path, 2)
        UNC = OttieniUNC(drive)
        SeiInRete = Not (UNC = "Locale" Or UNC = "Errore")
    End Function
    Private Function GetUniversalName(ByVal Path As String, _
        ByRef UniversalName As String, _
        ByRef ConnectionName As String, _
        ByRef RemainingPath As String) As Boolean
        ' When successful, returns TRUE with UniversalName,
        ' ConnectionName, and RemainingPath data. If not
        ' successful, it may be the drive is local and not mapped.
        Dim buffer As Integer
        Dim ptrbuffer As IntPtr
        Dim status As Integer
        Dim rni As REMOTE_NAME_INFO
        Dim Success As Boolean
        Dim SafteyCount As Integer = 0

        UniversalName = ""
        ConnectionName = ""
        RemainingPath = ""
        buffer = 1024

        ptrbuffer = Marshal.AllocHGlobal(buffer)
        status = WNetGetUniversalName( _
        Path, INFO_LEVEL.REMOTE_NAME_INFO_LEVEL, _
        ptrbuffer, buffer)
        Do While True
            Select Case status
                Case NO_ERROR
                    rni = CType(Marshal.PtrToStructure(ptrbuffer, GetType(REMOTE_NAME_INFO)), REMOTE_NAME_INFO)
                    UniversalName = rni.lpUniversalName
                    ConnectionName = rni.lpConnectionName
                    RemainingPath = rni.lpRemainingPath
                    Success = True
                    Exit Do
                Case ERROR_MORE_DATA
                    If SafteyCount > 3 Then
                        Success = False
                        Exit Do
                    End If
                    SafteyCount += 1
                    Marshal.FreeHGlobal(ptrbuffer)
                    ptrbuffer = Marshal.AllocHGlobal(buffer)
                    status = WNetGetUniversalName(Path, _
                    INFO_LEVEL.REMOTE_NAME_INFO_LEVEL, ptrbuffer, buffer)
                Case Else
                    Success = False
                    Exit Do
            End Select
        Loop
        Marshal.FreeHGlobal(ptrbuffer)
        Return Success
    End Function
    Public Function OttieniUNC(ByRef drive As String) As String
        Dim strOtt As String
        Dim UniversalName As String = ""
        Dim ConnectionName As String = ""
        Dim RemainingPath As String = ""
        If GetUniversalName(drive, UniversalName, ConnectionName, RemainingPath) Then
            strOtt = UniversalName
        Else
            strOtt = "Locale"
        End If
        OttieniUNC = strOtt
    End Function
    Public Sub TrattaNT(ByRef Brt As String, ByRef Plat As System.PlatformID)
        Dim strSystem As String = ""
        Dim ifl, ifl1 As Short
        Dim Riga As String
        Dim strSystem1 As String = ""
        Dim EnvString As String
        Dim n As Short
        Select Case Plat
            Case PlatformID.Win32NT
                strSystem = Environment.SystemDirectory & "\AUTOEXEC.NT"
                strSystem1 = Environment.SystemDirectory & "\AUTOMIO.NT"
                If Not System.IO.File.Exists(strSystem) Then
                    Motore.MostraAiuto(IDHS.IDH_ERR_AUTOEXECNT) ' "AUTOEXEC.NT non trovato!!!"
                    Exit Sub
                End If
            Case PlatformID.Win32Windows
                strSystem1 = Environment.SystemDirectory
                strSystem1 = Left(strSystem1, 3) & "AUTOEXEC.LAN"
                strSystem = Left(strSystem1, Len(strSystem1) - 3) & "BAT"
                If Not System.IO.File.Exists(strSystem) Then
                    Motore.MostraAiuto(IDHS.IDH_ERR_AUTOEXECBAT) ' "AUTOEXEC.NT non trovato!!!"
                    Exit Sub
                End If
                FileCopy(strSystem, strSystem1)
        End Select
        ifl = CShort(FreeFile())
        FileOpen(ifl, strSystem, OpenMode.Input)
        ifl1 = CShort(FreeFile())
        FileOpen(ifl1, strSystem1, OpenMode.Output)
        Do Until EOF(ifl)
            Riga = LineInput(ifl)
            If InStr(UCase(Riga), UCase(Brt)) > 0 Then
                FileClose(ifl)
                FileClose(ifl1)
                If Plat = PlatformID.Win32NT Then Kill(strSystem1)
                GiaFatto = True
                Exit Sub
            End If
            'FIXIT: Print method non ha alcun equivalente in Visual Basic .NET e non verrà aggiornato.     FixIT90210ae-R7593-R67265
            PrintLine(ifl1, Riga)
        Loop
        If Not Plat = PlatformID.Win32NT Then
            Dim environmentVariables As IDictionary = Environment.GetEnvironmentVariables()
            Dim de As DictionaryEntry
            For Each de In environmentVariables
                EnvString = CStr(de.Value)
                If UCase(CStr(de.Key)) = "PATH" Then ' Check PATH entry.
                    n = CShort(InStr(EnvString, Brt))
                    If n > 0 Then
                        FileClose(ifl)
                        FileClose(ifl1)
                        GiaFattoB = True : Exit Sub
                    End If
                    Exit For
                End If
            Next
        End If
        If Plat = PlatformID.Win32NT Then
            PrintLine(ifl1, "PATH=" & Brt & ";%PATH%")
            'MsgBox "AUTOEXEC.NT MODIFICATO!!!"
        Else
            PrintLine(ifl1, "SET PATH=" & "%PATH%;" & Brt)
            'MsgBox "AUTOEXEC.BAT MODIFICATO!!!"
        End If
        FileClose(ifl, ifl1)
        If Motore.MostraAiuto(IDHS.IDH_INIZIO_BRT, CType(ChiaviMess.MessInformation + ChiaviMess.MessHelpButton + ChiaviMess.MessOKCancel, ChiaviMess)) = ChiaviMess.MessOK Then
            FileCopy(strSystem1, strSystem)
        End If
        Kill(strSystem1)
    End Sub

    Private Sub Motore_Renamed_ProgrCancella() Handles Motore.ProgrCancella
        Cancellato = True
    End Sub

    Public Function Directory(ByRef c As String) As String
        Directory = System.IO.Path.GetDirectoryName(c)
    End Function
    Public Sub Caricalinee(ByRef objAcadDoc As AutoCAD.AcadDocument)
        With objAcadDoc
            LineaContinua = .ActiveLinetype
            If LineaContinua Is Nothing Then
                LineaContinua = .Linetypes.Item(1)
            End If
            On Error Resume Next
            'UPGRADE_NOTE: È possibile che l'oggetto LineaNascosta non venga eliminato finché non venga raccolto nel Garbage Collector. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1029"'
            LineaNascosta = Nothing
            LineaNascosta = .Linetypes.Item("NASCOSTA") ', "acadiso.lin")
            If Not LineaNascosta Is Nothing Then Exit Sub
            On Error GoTo 0
            .Linetypes.Load("NASCOSTA", "acadiso.lin")
            LineaNascosta = .Linetypes.Item("NASCOSTA") ', "acadiso.lin")
            .Linetypes.Load("TRATTOPUNTO", "acadiso.lin")
            TrattPunto = .Linetypes.Item("TRATTOPUNTO") ', "acadiso.lin")
        End With
    End Sub
    Private Function FileIni() As String
        WinSys = Environment.SystemDirectory & gstrSEP_DIR
        If Len(WinSys) = 0 Then Return ""
        ProgMain = "LancioNET" ' GetFileName(QuestoProgramma)
        FileIni = WinSys & ProgMain & ".INI"
        If Not System.IO.File.Exists(FileIni) Then FileIni = ""
    End Function
    Public Function CodiciCalc() As String()
        Dim Testo As String = ReadIniFile("", "Preferenze AsmeVip", "Codici")
        Dim delimiter As Char = CChar(",")
        Return Testo.Split(delimiter)
    End Function
    Public Function CodiceCalc(ByVal cod As Integer) As String
        Dim Testo As String
        Dim s As String() = CodiciCalc()
        Testo = ReadIniFile("", "Preferenze AsmeVip", s(cod))
        Select Case cod
            Case 0
                If Len(Trim$(Testo)) = 0 Then
                    Testo = " ASME VIII Div.1 2000 Ed.+2002 Add."
                    WriteIniFile("", "Preferenze AsmeVip", s(cod), Testo)
                End If
            Case 1
                If Len(Trim$(Testo)) = 0 Then
                    Testo = " ASME VIII Div.2 2000 Ed.+2002 Add."
                    WriteIniFile("", "Preferenze AsmeVip", s(cod), Testo)
                End If
            Case 2
                If Len(Trim$(Testo)) = 0 Then
                    Testo = " EN-13445-3 rev.4 15-10-2001"
                    WriteIniFile("", "Preferenze AsmeVip", s(cod), Testo)
                End If
            Case 3
                If Len(Trim$(Testo)) = 0 Then
                    Testo = "PED/ASME VIII Div.1 2004 Ed."
                    WriteIniFile("", "Preferenze AsmeVip", s(cod), Testo)
                End If
        End Select
        Return Testo
    End Function
    Public Function CodiceStress(ByVal cod As Integer) As Integer
        'trasforma il codice cod nel codice di Libmat
        Select Case cod
            Case 0, 3
                CodiceStress = 1
            Case 1
                CodiceStress = 6
            Case 2
                CodiceStress = 8
        End Select
    End Function
End Class