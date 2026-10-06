Module modMain
    Public gstrAppName As String = "LancioNET"
    Public gstrWinSysDir As String = Environment.SystemDirectory
    Public gfFunzionaInRete As Boolean = False
    Public gstrSrcPath As String = "C:\"
    Public Motore As RoutBase1.clsMotore
    Public Sub Inizializza()
        Motore = New RoutBase1.clsMotore("Lanc")
    End Sub
    Public Sub AggiornaINI(ByVal gstrDestDir As String)
        Dim strINIFile As String
        Dim strRete As String = Nothing
        'Dim i As Integer, strInst As String
        Dim DiscoBase As String = "", Basedir As String, Archdir As String
        Dim n As Integer
        'Dim Features As String, fKey As Boolean, sKey As String
        'Dim Testo As String, sChar As String, lCount As Long, sValue As String
        Dim strCommesse As String = ""
        Inizializza()
        Try
            With Motore.Inizio
                '  gstrDestDir = .AddDirSep(gstrDestDir)
                gstrWinSysDir = .AddDirSep(gstrWinSysDir)
                strINIFile = gstrWinSysDir + gstrAppName + ".INI"
                Select Case gfFunzionaInRete
                    Case True
                        Select Case Left(gstrSrcPath, 1)
                            Case "P"
                                DiscoBase = "P:\LANCIO\"
                                .WriteIniFile(strINIFile, "Percorsi", "Basedir", gstrDestDir)
                                .WriteIniFile(strINIFile, "Percorsi", "Archdir", "P:\LANCIO\ARCH")
                            Case Else
                                DiscoBase = Left(gstrSrcPath, 3)
                                n = InStr(UCase(gstrSrcPath), "SETUP")
                                Basedir = Left(gstrSrcPath, n - 1)
                                ' frmSetup1.Tag = Basedir
                                ' frmPath.Caption = "Percorso per gli eseguibili in rete"
                                ' frmPath.Show(vbModal)
                                ' Basedir = frmSetup1.Tag
                                Archdir = Basedir + "ARCH"
                                'frmSetup1.Tag = Archdir
                                'frmPath.Caption = "Percorso per gli archivi in rete"
                                'frmPath.Show(vbModal)
                                'Archdir = frmSetup1.Tag
                                If Right(Basedir, 1) = "\" Then Basedir = Left(Basedir, Len(Basedir) - 1)
                                If Right(Archdir, 1) = "\" Then Archdir = Left(Archdir, Len(Archdir) - 1)
                                .WriteIniFile(strINIFile, "Percorsi", "Basedir", Basedir)
                                .WriteIniFile(strINIFile, "Percorsi", "Archdir", Archdir)
                        End Select
                        strRete = "Si"
                        strCommesse = "Si"
                    Case False
                        DiscoBase = gstrDestDir.Substring(0, 3)
                        .WriteIniFile(strINIFile, "Percorsi", "Basedir", gstrDestDir)
                        .WriteIniFile(strINIFile, "Percorsi", "Archdir", gstrDestDir & "\ARCH")
                        strRete = "No"
                        strCommesse = "No"
                        ' For i = 1 To colSect.Count
                        ' If colSect(i).Presente And colSect(i).Selezionato And colSect(i).Name = "Gest" Then
                        ' strCommesse = "Si"
                        ' Exit For
                        ' End If
                        ' Next
                End Select
                .WriteIniFile(strINIFile, "Avvio", "Commesse", strCommesse)
                .WriteIniFile(strINIFile, "Percorsi", "DiscoBase", DiscoBase)
                .WriteIniFile(strINIFile, "Percorsi", "AppLancio", gstrDestDir)
                .WriteIniFile(strINIFile, "Percorsi", "Datidir", gstrDestDir + "\DATI")
                If Not IO.Directory.Exists(gstrDestDir + "DATI") Then IO.Directory.CreateDirectory(gstrDestDir + "\DATI")
                .WriteIniFile(strINIFile, "Percorsi", "Workdir", gstrDestDir + "\WORK")
                If Not IO.Directory.Exists(gstrDestDir + "WORK") Then IO.Directory.CreateDirectory(gstrDestDir + "\WORK")
                .WriteIniFile(strINIFile, "Percorsi", "DiscoRam", gstrDestDir + "\TEMP\")
                If Not IO.Directory.Exists(gstrDestDir + "TEMP") Then IO.Directory.CreateDirectory(gstrDestDir + "\TEMP")
                .WriteIniFile(strINIFile, "Percorsi", "FunzionamentoInRete", strRete)
                .WriteIniFile(strINIFile, "Percorsi", "Gancio", gstrDestDir + "\WORK\DATI.TEM")
            End With
        Catch e As Exception
            MsgBox(e.Message & vbCrLf & e.StackTrace)
        End Try
        '---------------------------------------------------------------------------
        'Features = ReadSection(strINIFile, "Features")
        'fKey = True
        'For lCount = 1 To Len(Features)
        'sChar = Mid$(Features, lCount, 1)
        'If (sChar = sEQUAL) Then
        'fKey = False
        'ElseIf (Asc(sChar) = 0) Or (Len(Features) = lCount) Then
        '    If Len(Features) = lCount Then
        'If fKey Then
        'sKey = sKey & sChar
        'Else
        '    sValue = sValue & sChar
        'End If
        '    End If
        'If Len(Trim(sKey)) <> 0 Then
        'WriteIniFile(strINIFile, "Features", sKey, "No")
        'End If
        'sKey = vbNullString
        'sValue = vbNullString
        'fKey = True
        'Else
        'If fKey Then
        'sKey = sKey & sChar
        'Else
        '    sValue = sValue & sChar
        'End If
        'End If
        'Next
        ''----------------------------------------------------------------------------
        'For i = 1 To colSect.Count
        'If colSect(i).Presente And colSect(i).Selezionato Then strInst = "Si" Else strInst = "No"
        'WriteIniFile(strINIFile, "Features", colSect(i).Name, strInst)
        'Next
        'Exit Sub
    End Sub

End Module
