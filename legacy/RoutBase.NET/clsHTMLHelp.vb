Option Strict On
Option Explicit On
Option Compare Text
Imports Microsoft.Win32
Imports System.IO
Namespace HHHelp
    Public Enum enumHHVersion
        HH_1_0 = &H10S
        HH_1_1 = &H11S
        HH_1_1A = &H12S
        HH_1_1B = &H13S
        HH_1_2 = &H14S
        HH_1_21 = &H15S
        HH_1_21A = &H16S
        HH_1_22 = &H17S
    End Enum
    Public Enum enumIEVersion
        IE_3_0 = &H100S
        IE_3_0_OSR2 = &H101S
        IE_3_01 = &H102S
        IE_3_02 = &H103S
        IE_4_0_PP2 = &H104S
        IE_4_0 = &H105S
        IE_4_01 = &H106S
        IE_4_01_SP1 = &H107S
        IE_4_01_SP2 = &H108S
        IE_5_0_Beta1 = &H109S
        IE_5_0_Beta2 = &H10AS
        IE_5_0 = &H10BS
        IE_5_0A = &H10CS
        IE_5_0B = &H10DS
    End Enum
    Public Class HTMLHelp
        '=================================================
        'Modified on 01 Aug 1999 by L.Presciuttini where marked with '01 Aug 1999
        '=================================================


        ' *****************************************************
        ' HTML Help class for Microsoft Visual Basic
        ' Version 3.0
        ' (c)July 1999, Delmar Computing Services
        '
        ' Developed by David Liske, Tipton, Michigan, USA
        ' Microsoft HTML Help MVP
        ' http://www.vbexplorer.com/htmlhelp.asp
        '
        ' Proof-of-concept testing and some HTML Help
        ' API research provided by Robert Chandler,
        ' Melbourne, Vic, Australia
        ' Microsoft HTML Help MVP
        ' http://www.helpware.net
        '
        ' Some registry functionality re-developed from
        ' original code written by Dave Scarmozzino
        ' http://www.TheScarms.com
        '
        ' Beta testing:
        ' Lani Hardage, MDL Information Systems, Inc.
        ' Steve Hsu, TREEV, Inc.
        ' John Hunt, Lotus Development Corporation
        ' Shirley Kelly, Corbel, A SunGard Company
        ' Valerie A. Lipow, Compuware Corporation
        ' Leyden Martinez, Copextel, S.A.
        ' Alejandro Sicilia, Copextel, S.A.
        '
        ' Please send any performance or functionality
        ' modifications of this file to delmar@tc3net.com
        ' *****************************************************


        'FIXIT: Dichiarare "frm" con un tipo di dati ad associazione anticipata                    FixIT90210ae-R1672-R1B8ZE
        Public frm As Object
        Public hwnd As Integer
        Public lpPrevWndFunc As Integer
        Public Enum PopupType
            HH_CHM_POPUP = &H1S
            HH_RESOURCE_POPUP = &H2S
            HH_TEXT_POPUP = &H4S
        End Enum
        '============================start 01 Aug 1999
        Private Const extIE_3_0 As String = "4.70.1155"
        Private Const extIE_3_0_OSR2 As String = "4.70.1158"
        Private Const extIE_3_01 As String = "4.70.1215"
        Private Const extIE_3_02 As String = "4.70.1300"
        Private Const extIE_4_0_PP2 As String = "4.71.1008.3"
        Private Const extIE_4_0 As String = "4.71.1712.5"
        Private Const extIE_4_01 As String = "4.72.2106.7"
        Private Const extIE_4_01_SP1 As String = "4.72.3110.03"
        'modified .3 in .03 on the constant above '01 Aug 1999
        Private Const extIE_4_01_SP2 As String = "4.72.3612.1707"
        Private Const extIE_5_0_Beta1 As String = "5.00.0518.5"
        Private Const extIE_5_0_Beta2 As String = "5.00.0910.1308"
        Private Const extIE_5_0 As String = "5.00.2014.213"
        Private Const extIE_5_0A As String = "5.00.2314.1000"
        Private Const extIE_5_0B As String = "5.00.2614.3500"
        Private Const extHH_1_0 As String = "4.72.7290"
        Private Const extHH_1_1 As String = "4.72.7323"
        Private Const extHH_1_1A As String = "4.72.7325"
        Private Const extHH_1_1B As String = "4.72.8164.0"
        Private Const extHH_1_2 As String = "4.73.8252"
        Private Const extHH_1_21 As String = "4.73.8412"
        Private Const extHH_1_21A As String = "4.73.8474"
        '  Private Const extHH_1_22= ""
        'local variable(s) to hold property value(s)
        Private mvarCHMFile As String
        Private mvarHHALink As String
        Private mvarHHDefaultURL As String
        Private mvarHHInstalled As Boolean
        Private mvarHHKeyword As String
        Private mvarHHMsgText As String
        Private mvarHHMsgTitle As String
        Private mvarHHShowOnTop As Boolean
        Private mvarHHTopicID As Integer
        Private mvarHHTopicURL As String
        Private mvarHHWindow As String
        Private mvarHHRegFileName As String
        Private mvarHHRegFilePath As String
        Private mvarHHRegFileExists As Boolean
        Private mvarHHPopupFile As String
        Private mvarHHPopupType As PopupType
        Private mvarHHPopupText As String
        Private mvarHHPopupID As Integer
        Private mvarHHPopupTextColor As Integer
        Private mvarHHPopupBackColor As Integer
        Private mvarHHPopupCustomTextColor As Integer
        Private mvarHHPopupCustomBackColor As Integer
        Private mvarHHPopupCustomColors As Boolean
        Private mvarHHPopupTextFont As String
        Private mvarHHPopupTextSize As String
        Private mvarHHPopupTextBold As Boolean
        Private mvarHHPopupTextItalic As Boolean
        Private mvarHHPopupTextUnderline As Boolean
        Private mvarHHCtrlPath As String
        Private mvarHHVersion As String
        Private mvarIEVersion As String

        ' Module-level variables
        Private strHTMLHelpPath As String
        Private strWindow As String
        Private strTopic As String
        Private lngTopicID As Integer
        Public Sub HHRegister(ByRef FileToRegister As String)
            ' Registers the specified HTML Help file in
            ' HKEY_LOCAL_MACHINE\Software\Microsoft\Windows\HTML Help
            Dim strFilePath As String
            Dim intPosition As Short
            Dim intLength As Short
            Dim key As RegistryKey
            Dim strMsg As String
            If FileToRegister = "" Then
                Exit Sub
            End If
            HHCheckRegistry(FileToRegister)
            If (mvarHHRegFileName <> "") Then
                strMsg = "The file " & FileToRegister & " is already registered.  " & "HHRegister will not be run as no action need be taken."
                MsgBox(strMsg, MsgBoxStyle.Information, "HTML Help Class")
                Exit Sub
            End If
            ' Copy it to get the path later
            strFilePath = FileToRegister
            If ValidHHFile(FileToRegister) = False Then
                Exit Sub
            Else
                If EnsureFileExists(FileToRegister) = False Then
                    Exit Sub
                End If
                If InStr(FileToRegister, "\") = 0 Then
                    MsgBox("Cannot register " & FileToRegister & " without having a supplied path.", CType(MsgBoxStyle.OKOnly + MsgBoxStyle.Exclamation, MsgBoxStyle), "HTML Help Class")
                    Exit Sub
                Else
                    ' strip the file name itself off the path
                    intPosition = 1
                    Do While intPosition <> 0
                        intLength = CShort(Len(FileToRegister))
                        intPosition = CShort(InStr(1, FileToRegister, "\"))
                        'FIXIT: Sostituire la funzione "Right" con la funzione "Right$"                            FixIT90210ae-R9757-R1B8ZE
                        FileToRegister = Right(FileToRegister, intLength - intPosition)
                    Loop
                    ' Get the registered path
                    strFilePath = Left(strFilePath, Len(strFilePath) - Len(FileToRegister))
                    'lngResult = RegCreateKeyEx(HKEY_LOCAL_MACHINE, "Software\Microsoft\Windows\HTML Help", 0, "", REG_OPTION_NON_VOLATILE, KEY_CREATE_SUB_KEY Or KEY_SET_VALUE, secSecAttributes, lngHandle, lngDisposition)
                    Try
                        key = Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software\Microsoft\Windows\HTML Help")
                        key.SetValue(FileToRegister, strFilePath)
                    Catch err As Security.SecurityException
                        MsgBox(err.ToString)
                    Catch err As UnauthorizedAccessException
                        MsgBox(err.ToString)
                    Finally
                    End Try
                    'lngResult = RegSetValueEx(lngHandle, FileToRegister, 0, REG_SZ, strValue, lngLenData)
                End If
            End If
            HHCheckRegistry(CStr(FileToRegister))
        End Sub
        Public Sub HHUnRegister(ByRef FileToUnRegister As String)
            ' Deletes the entry for the specified HTML Help file from
            ' HKEY_LOCAL_MACHINE\Software\Microsoft\Windows\HTML Help
            Dim intPosition As Short
            Dim intLength As Short
            Dim strMsg As String
            Dim key As RegistryKey
            If FileToUnRegister = "" Then
                Exit Sub
            End If
            If ValidHHFile(FileToUnRegister) = False Then
                Exit Sub
            Else
                HHCheckRegistry(FileToUnRegister)
                If (mvarHHRegFileName = "") Then
                    ' The file isn't registered to begin with,
                    ' so we need to say so and exit.
                    strMsg = "The file " & FileToUnRegister & " is not registered.  " & "HHUnRegister will not be run as no action need be taken."
                    MsgBox(strMsg, MsgBoxStyle.Information, "HTML Help Class")
                    Exit Sub
                End If
                ' strip the file name itself off the path
                intPosition = 1
                Do While intPosition <> 0
                    intLength = CShort(Len(FileToUnRegister))
                    intPosition = CShort(InStr(1, FileToUnRegister, "\"))
                    FileToUnRegister = Right(FileToUnRegister, intLength - intPosition)
                Loop
                ' Delete the entry
                Try
                    key = Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software\Microsoft\Windows\HTML Help")
                    key.DeleteValue(FileToUnRegister)
                Catch err As Security.SecurityException
                    MsgBox(err.ToString)
                Catch err As UnauthorizedAccessException
                    MsgBox(err.ToString)
                Finally
                End Try
            End If
            HHCheckRegistry(CStr(FileToUnRegister))
        End Sub
        Public Function HHCheckRegistry(ByRef FileToCheck As String) As Boolean
            ' Verifies the specified HTML Help file has been registered in
            ' HKEY_LOCAL_MACHINE\Software\Microsoft\Windows\HTML Help
            Dim intLength As Short
            Dim intPosition As Short
            Dim i As Short
            Dim strTempFileName As String
            ' Reassign the file name so the original
            ' doesn't become mangled
            strTempFileName = FileToCheck
            If strTempFileName = "" Then
                Exit Function
            End If
            HHCheckRegistry = False
            mvarHHRegFileExists = False
            If ValidHHFile(strTempFileName) = False Then
                Exit Function
            Else
                ' strip the file name itself off the path
                intPosition = 1
                Do While intPosition <> 0
                    intLength = CShort(Len(strTempFileName))
                    intPosition = CShort(InStr(1, strTempFileName, "\"))
                    'FIXIT: Sostituire la funzione "Right" con la funzione "Right$"                            FixIT90210ae-R9757-R1B8ZE
                    strTempFileName = Right(strTempFileName, intLength - intPosition)
                Loop
                Dim rk As RegistryKey = Registry.LocalMachine.OpenSubKey("Software\Microsoft\Windows\HTML Help", False)
                Dim FileNames() As String = rk.GetValueNames()
                '            varRegValues = EnumRegValue("HKLM", "Software\Microsoft\Windows\HTML Help", sValues, strTempFileName)
                '            With varRegValues
                For i = 0 To CShort(UBound(FileNames))
                    If FileNames(i) = strTempFileName Then
                        ' Load the verified file name into the HHRegFileName
                        ' property, and the registered path of the file into
                        ' the HHRegFilePath property.
                        mvarHHRegFileName = FileNames(i)
                        mvarHHRegFilePath = CType(rk.GetValue(FileNames(i)), String)
                        ' Verify the HTML Help file exists according to the registry data.
                        '      lngHandle = FindFirstFile(mvarHHRegFilePath & mvarHHRegFileName, lpFindFileData)
                        mvarHHRegFileExists = File.Exists(mvarHHRegFilePath & mvarHHRegFileName)
                    Else
                        mvarHHRegFileName = ""
                        mvarHHRegFilePath = ""
                    End If
                Next
            End If
        End Function
        Public Function HHVerifyMinConfig(ByRef MinHHVersion As enumHHVersion, ByRef MinIEVersion As enumIEVersion, Optional ByRef VerHH As String = "", Optional ByRef VerIE As String = "") As Boolean
            ' Verifies the minimum HTML Help and IE versions
            ' as specified by the developer.
            Dim boolHHVerified, boolIEVerified As Boolean
            mvarHHVersion = HHVersion()
            mvarIEVersion = IEVersion()
            If VerHH = "" Then VerHH = extHHVersion(mvarHHVersion)
            If VerIE = "" Then VerIE = extIEVersion(mvarIEVersion)
            HHVerifyMinConfig = False
            If Len(mvarHHVersion) = 0 Or Len(mvarIEVersion) = 0 Then Exit Function
            Select Case MinHHVersion
                Case enumHHVersion.HH_1_0
                    If mvarHHVersion >= extHH_1_0 Then
                        boolHHVerified = True
                    End If
                Case enumHHVersion.HH_1_1
                    If mvarHHVersion >= extHH_1_1 Then
                        boolHHVerified = True
                    End If
                Case enumHHVersion.HH_1_1A
                    If mvarHHVersion >= extHH_1_1A Then
                        boolHHVerified = True
                    End If
                Case enumHHVersion.HH_1_1B
                    If mvarHHVersion >= extHH_1_1B Then
                        boolHHVerified = True
                    End If
                Case enumHHVersion.HH_1_2
                    If mvarHHVersion >= extHH_1_2 Then
                        boolHHVerified = True
                    End If
                Case enumHHVersion.HH_1_21
                    If mvarHHVersion >= extHH_1_21 Then
                        boolHHVerified = True
                    End If
                Case enumHHVersion.HH_1_21A
                    If mvarHHVersion >= extHH_1_21A Then
                        boolHHVerified = True
                    End If
                    'Case HH_1_22
                    'If mvarHHVersion >= extHH_1_22 Then
                    'boolhhverified = True
                    'End If
            End Select

            Select Case MinIEVersion
                Case enumIEVersion.IE_3_0
                    If mvarIEVersion >= extIE_3_0 Then
                        boolIEVerified = True
                    End If
                Case enumIEVersion.IE_3_0_OSR2
                    If mvarIEVersion >= extIE_3_0_OSR2 Then
                        boolIEVerified = True
                    End If
                Case enumIEVersion.IE_3_01
                    If mvarIEVersion >= extIE_3_01 Then
                        boolIEVerified = True
                    End If
                Case enumIEVersion.IE_3_02
                    If mvarIEVersion >= extIE_3_02 Then
                        boolIEVerified = True
                    End If
                Case enumIEVersion.IE_4_0_PP2
                    If mvarIEVersion >= extIE_4_0_PP2 Then
                        boolIEVerified = True
                    End If
                Case enumIEVersion.IE_4_0
                    If mvarIEVersion >= extIE_4_0 Then
                        boolIEVerified = True
                    End If
                Case enumIEVersion.IE_4_01
                    If mvarIEVersion >= extIE_4_01 Then
                        boolIEVerified = True
                    End If
                Case enumIEVersion.IE_4_01_SP1
                    If mvarIEVersion >= extIE_4_01_SP1 Then
                        boolIEVerified = True
                    End If
                Case enumIEVersion.IE_4_01_SP2
                    If mvarIEVersion >= extIE_4_01_SP2 Then
                        boolIEVerified = True
                    End If
                Case enumIEVersion.IE_5_0_Beta1
                    If mvarIEVersion >= extIE_5_0_Beta1 Then
                        boolIEVerified = True
                    End If
                Case enumIEVersion.IE_5_0_Beta2
                    If mvarIEVersion >= extIE_5_0_Beta2 Then
                        boolIEVerified = True
                    End If
                Case enumIEVersion.IE_5_0
                    If mvarIEVersion >= extIE_5_0 Then
                        boolIEVerified = True
                    End If
                Case enumIEVersion.IE_5_0A
                    If mvarIEVersion >= extIE_5_0A Then
                        boolIEVerified = True
                    End If
                Case enumIEVersion.IE_5_0B
                    If mvarIEVersion >= extIE_5_0B Then
                        boolIEVerified = True
                    End If
            End Select
            '===========================end 01 Aug 1999
            HHVerifyMinConfig = (boolHHVerified And boolIEVerified)
        End Function
        Private Function GetVersionInfo(ByRef FileName As String) As String
            Dim Version As FileVersionInfo
            Version = FileVersionInfo.GetVersionInfo(FileName)
            GetVersionInfo = Version.FileVersion
        End Function
        Private Function ValidHHFile(ByRef FileToVerify As String) As Boolean
            ValidHHFile = True
            If Right(FileToVerify, 3) <> "chm" Then
                MsgBox(FileToVerify & " is not a valid HTML Help file.", CType(MsgBoxStyle.OKOnly + MsgBoxStyle.Exclamation, MsgBoxStyle), "HTML Help Class")
                ValidHHFile = False
            End If
        End Function
        Private Function ValidPopupFile(ByRef FileToVerify As String) As Boolean
            ValidPopupFile = True
            If Right(FileToVerify, 3) <> "txt" Then
                MsgBox("The file specified as the text popup source, '" & FileToVerify & "', is not a valid popup file.", CType(MsgBoxStyle.OKOnly + MsgBoxStyle.Exclamation, MsgBoxStyle), "HTML Help Class")
                ValidPopupFile = False
            End If
        End Function
        Private Function EnsureFileExists(ByRef FileToFind As String) As Boolean
            EnsureFileExists = True
            If (InStr(FileToFind, "\") = 0) Then
                FileToFind = Path.GetFullPath(FileToFind)
            End If
            Dim strMsg As String
            If Not File.Exists(FileToFind) Then
                strMsg = "The file " & FileToFind & " does not exist." & Chr(10) & "Please make sure the correct path and file name have been specified."
                MsgBox(strMsg, MsgBoxStyle.Exclamation, "HTML Help Class")
                EnsureFileExists = False
            End If
        End Function
        Public Property HHWindow() As String
            Get
                HHWindow = mvarHHWindow
            End Get
            Set(ByVal Value As String)
                mvarHHWindow = Value
            End Set
        End Property
        Public Property HHTopicURL() As String
            Get
                HHTopicURL = mvarHHTopicURL
            End Get
            Set(ByVal Value As String)
                mvarHHTopicURL = Value
            End Set
        End Property
        Public Property HHTopicID() As Integer
            Get
                HHTopicID = mvarHHTopicID
            End Get
            Set(ByVal Value As Integer)
                mvarHHTopicID = Value
            End Set
        End Property
        Public Property HHMsgTitle() As String
            Get
                HHMsgTitle = mvarHHMsgTitle
            End Get
            Set(ByVal Value As String)
                mvarHHMsgTitle = Value
            End Set
        End Property
        Public Property HHMsgText() As String
            Get
                HHMsgText = mvarHHMsgText
            End Get
            Set(ByVal Value As String)
                mvarHHMsgText = Value
            End Set
        End Property
        Public Property HHKeyword() As String
            Get
                HHKeyword = mvarHHKeyword
            End Get
            Set(ByVal Value As String)
                mvarHHKeyword = Value
            End Set
        End Property
        Public Property HHDefaultURL() As String
            Get
                HHDefaultURL = mvarHHDefaultURL
            End Get
            Set(ByVal Value As String)
                mvarHHDefaultURL = Value
            End Set
        End Property
        Public Property HHALink() As String
            Get
                HHALink = mvarHHALink
            End Get
            Set(ByVal Value As String)
                mvarHHALink = Value
            End Set
        End Property
        Public Property CHMFile() As String
            Get
                CHMFile = mvarCHMFile
            End Get
            Set(ByVal Value As String)
                mvarCHMFile = Value
            End Set
        End Property
        Public Property HHShowOnTop() As Boolean
            Get
                HHShowOnTop = mvarHHShowOnTop
            End Get
            Set(ByVal Value As Boolean)
                mvarHHShowOnTop = Value
            End Set
        End Property
        Public ReadOnly Property HHRegFileName() As String
            Get
                HHRegFileName = mvarHHRegFileName
            End Get
        End Property
        Public ReadOnly Property HHRegFilePath() As String
            Get
                HHRegFilePath = mvarHHRegFilePath
            End Get
        End Property
        Public ReadOnly Property HHRegFileExists() As Boolean
            Get
                HHRegFileExists = mvarHHRegFileExists
            End Get
        End Property
        Public WriteOnly Property HHPopupFile() As String
            Set(ByVal Value As String)
                mvarHHPopupFile = Value
            End Set
        End Property
        Public WriteOnly Property HHPopupID() As Integer
            Set(ByVal Value As Integer)
                mvarHHPopupID = Value
            End Set
        End Property
        Public WriteOnly Property HHPopupText() As String
            Set(ByVal Value As String)
                mvarHHPopupText = Value
            End Set
        End Property
        Public WriteOnly Property HHPopupType() As PopupType
            Set(ByVal Value As PopupType)

                On Error Resume Next

                mvarHHPopupType = Value

            End Set
        End Property

        Public WriteOnly Property HHPopupTextColor() As System.Drawing.Color
            Set(ByVal Value As System.Drawing.Color)

                On Error Resume Next

                mvarHHPopupTextColor = System.Drawing.ColorTranslator.ToOle(Value)

            End Set
        End Property

        Public WriteOnly Property HHPopupBackColor() As System.Drawing.Color
            Set(ByVal Value As System.Drawing.Color)

                On Error Resume Next

                mvarHHPopupBackColor = System.Drawing.ColorTranslator.ToOle(Value)

            End Set
        End Property

        Public WriteOnly Property HHPopupCustomTextColor() As Integer
            Set(ByVal Value As Integer)

                On Error Resume Next

                mvarHHPopupCustomTextColor = Value

            End Set
        End Property

        Public WriteOnly Property HHPopupCustomBackColor() As Integer
            Set(ByVal Value As Integer)

                On Error Resume Next

                mvarHHPopupCustomBackColor = Value

            End Set
        End Property


        Public Property HHPopupCustomColors() As Boolean
            Get

                On Error Resume Next

                HHPopupCustomColors = mvarHHPopupCustomColors

            End Get
            Set(ByVal Value As Boolean)

                On Error Resume Next

                mvarHHPopupCustomColors = Value

            End Set
        End Property

        Public WriteOnly Property HHPopupTextFont() As String
            Set(ByVal Value As String)

                On Error Resume Next

                mvarHHPopupTextFont = Value

            End Set
        End Property

        Public WriteOnly Property HHPopupTextSize() As String
            Set(ByVal Value As String)

                On Error Resume Next

                mvarHHPopupTextSize = Value

            End Set
        End Property

        Public WriteOnly Property HHPopupTextBold() As Boolean
            Set(ByVal Value As Boolean)

                On Error Resume Next

                mvarHHPopupTextBold = Value

            End Set
        End Property

        Public WriteOnly Property HHPopupTextItalic() As Boolean
            Set(ByVal Value As Boolean)

                On Error Resume Next

                mvarHHPopupTextItalic = Value

            End Set
        End Property

        Public WriteOnly Property HHPopupTextUnderline() As Boolean
            Set(ByVal Value As Boolean)

                On Error Resume Next

                mvarHHPopupTextUnderline = Value

            End Set
        End Property
        Public ReadOnly Property HHInstalled() As Boolean
            Get
                ' Verifies whether or not HTML Help is installed on
                ' the system.  This is done by checking the existence of
                ' HKEY_LOCAL_MACHINE\Software\CLASSES\TypeLib\{ADB880A2-D8FF-11CF-9377-00AA003B7A11}
                Dim rk As RegistryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\Classes\TypeLib\{ADB880A2-D8FF-11CF-9377-00AA003B7A11}", False)
                mvarHHInstalled = Not rk Is Nothing
                HHInstalled = mvarHHInstalled
            End Get
        End Property
        Private Function HHVersion() As String
            ' Get the path of the registered copy of hhctrl.ocx
            Dim rk As RegistryKey = Registry.ClassesRoot.OpenSubKey("CLSID\{4662DAB0-D393-11D0-9A56-00C04FB68B66}\InprocServer32", False)
            'varHHRegValues = EnumRegValue("HKCR", "CLSID\{4662DAB0-D393-11D0-9A56-00C04FB68B66}\InprocServer32", sValues, "")
            If rk Is Nothing Then
                MsgBox("Hhctrl.ocx non è registrato.  " & "Prego istallare i Files ausiliari di Lancio.", CType((MsgBoxStyle.OKOnly + MsgBoxStyle.Information), MsgBoxStyle), "Lancio")
                Return ""
            End If
            Dim Predefinito As String = CType(rk.GetValue(""), String)
            If Not File.Exists(Predefinito) Then
                MsgBox("Hhctrl.ocx non si trova nella posizione registrata.  " & "Prego riistallare i Files Ausiliari di Lancio.", CType(MsgBoxStyle.OKOnly + MsgBoxStyle.Critical, MsgBoxStyle), "Lancio")
                Return ""
            End If
            HHVersion = FileVersionInfo.GetVersionInfo(Predefinito).FileVersion
        End Function
        Public Function extIEVersion(Optional ByRef Version As String = "") As String
            If Version = "" Then Version = mvarIEVersion
            If Version = "" Then Version = IEVersion()
            Select Case Version
                Case Is >= extIE_5_0B
                    extIEVersion = "5.0b"
                Case Is >= extIE_5_0A
                    extIEVersion = "5.0a"
                Case Is >= extIE_5_0
                    extIEVersion = "5.0"
                Case Is >= extIE_5_0_Beta2
                    extIEVersion = "5.0.beta2"
                Case Is >= extIE_5_0_Beta1
                    extIEVersion = "5.0.beta1"
                Case Is >= extIE_4_01_SP2
                    extIEVersion = "4.01+Service Pack 2"
                Case Is >= extIE_4_01_SP1
                    extIEVersion = "4.01+Service Pack 1"
                Case Is >= extIE_4_01
                    extIEVersion = "4.01"
                Case Is >= extIE_4_0
                    extIEVersion = "4.0"
                Case Is >= extIE_4_0_PP2
                    extIEVersion = "4.0.PP2"
                Case Is >= extIE_3_02
                    extIEVersion = "3.02"
                Case Is >= extIE_3_01
                    extIEVersion = "3.01"
                Case Is >= extIE_3_0_OSR2
                    extIEVersion = "3.0.OSR2"
                Case Is >= extIE_3_0
                    extIEVersion = "3.0"
                Case Else
                    extIEVersion = ""
            End Select
        End Function
        Public Function extHHVersion(Optional ByRef Version As String = "") As String
            If Version = "" Then Version = mvarHHVersion
            If Version = "" Then Version = HHVersion()
            Select Case Version
                'case is>=extHH_1_22
            Case Is >= extHH_1_21A
                    extHHVersion = "1.2.1a"
                Case Is >= extHH_1_21
                    extHHVersion = "1.2.1"
                Case Is >= extHH_1_2
                    extHHVersion = "1.2"
                Case Is >= extHH_1_1B
                    extHHVersion = "1.1b"
                Case Is >= extHH_1_1A
                    extHHVersion = "1.1a"
                Case Is >= extHH_1_1
                    extHHVersion = "1.1"
                Case Is >= extHH_1_0
                    extHHVersion = "1.0"
                Case Else
                    extHHVersion = ""
            End Select
        End Function
        Private Function IEVersion() As String
            ' Get the path of the registered copy of shdocvw.dll
            Dim rk As RegistryKey = Registry.ClassesRoot.OpenSubKey("CLSID\{0A89A860-D7B1-11CE-8350-444553540000}\InprocServer32", False)
            '  varIERegValues = EnumRegValue("HKCR", "CLSID\{0A89A860-D7B1-11CE-8350-444553540000}\InProcServer32", sValues, "")
            If rk Is Nothing Then
                MsgBox("Shdocvw.dll is not registered.  " & "Please install Internet Explorer.", CType(MsgBoxStyle.OKOnly + MsgBoxStyle.Critical, MsgBoxStyle), "Lancio")
                Return ""
            End If
            Dim Predefinito As String = CType(rk.GetValue(""), String)
            ' Verify the shdocvw.dll exists according
            ' to the registry data.
            If Not File.Exists(Predefinito) Then
                MsgBox("Shdocvw.dll is not in its registered location.  " & "Please reinstall Internet Explorer.", CType(MsgBoxStyle.OKOnly + MsgBoxStyle.Critical, MsgBoxStyle), "Lancio")
                Return ""
            End If
            IEVersion = FileVersionInfo.GetVersionInfo(Predefinito).FileVersion
        End Function
    End Class
End Namespace
