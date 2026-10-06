Option Strict Off
Option Explicit On
Public Class clsVentil
    Public WriteOnly Property DoveDatBase() As RoutBase1.DatBase
        Set(ByVal Value As RoutBase1.DatBase)
            Monitor.objDatBase = Value
        End Set
    End Property
    Public WriteOnly Property DoveMotore() As RoutBase1.clsMotore
        Set(ByVal Value As RoutBase1.clsMotore)
            Monitor.Motore = Value
            With Value.Inizio
                RadiceHelp = .AppLancio & "\BIN\AiutoVent.chm"
                nuovePar = .ReadIniFile("", "Preferenze Ventil", "NuoveParabole") = "Si"
                CorrDB = Val(.ReadIniFile("", "Preferenze Ventil", "CorrezioneRumore"))
                CorrRd = Val(.ReadIniFile("", "Preferenze Ventil", "CorrezioneRendimento"))
                If CorrRd = 0 Then CorrRd = 1
            End With
            If nuovePar Then AprimyDb()
            finCurva = New frmCurva
        End Set
    End Property
    Public WriteOnly Property DoveInizio() As RoutBase1.clsInizio
        Set(ByVal Value As RoutBase1.clsInizio)
            ' Set Monitor.Motore.Inizio = m
            ''    Set clsInizio = i
            ''    Set inizio = i
        End Set
    End Property
    Public WriteOnly Property DoveScrivere() As Object
        Set(ByVal Value As Object)
            Monitor.Dove = Value
        End Set
    End Property
    Public WriteOnly Property DoveRoutines() As RoutBase1.Routines
        Set(ByVal Value As RoutBase1.Routines)
            Monitor.Routines = Value
        End Set
    End Property
    Public Sub New()
        MyBase.New()
        Monitor = New clsMonitor
        Monitor.Ogg = Me
        Lin(1) = "IT" : Lin(2) = "FR" : Lin(3) = "IN"
        myAssembly = Me.GetType.Assembly
    End Sub
    Public Function Esegui(ByRef m As Short, ByRef IUNP As Short, ByRef nAlt As Short, ByRef Arch As String, ByRef DisplayOnly As Boolean) As Boolean
        Dim i As Boolean
        AddDistinta = m
        n = nAlt
        Nrdit = IUNP
        secondo = False
        Select Case AddDistinta
            Case 0
            Case Else
                Apri(LTrim(Arch))
                daISA = True
                Call GetStandFH()
                Select Case AddDistinta
                    Case 100
                        Stop
                    Case 101, 105, 106, 107 : i = Ventilat(Arch, DisplayOnly)
                        Esegui = i
                End Select
        End Select
    End Function
    Public Function Riscrivi(ByRef NewF As String, ByRef n As Short, ByRef Arch As String) As Boolean
        Dim Testo As String
        Riscrivi = True
        Nrdit = n
        Testo = GlobalRoutines.Str2Cifre(Nrdit \ 2)
        If Left(Testo, 1) = Chr(32) Then Testo = Chr(48) & Right(Testo, 1)
        NewF = Monitor.Motore.Inizio.Workdir & Chr(92) & Arch & Testo & ".VEN"
        'UPGRADE_WARNING: Dir ha un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
        If Len(Dir(NewF)) = 0 Then
            '  Testo = Monitor.Motore.Inizio.ConvertiCr(at1(21))
            '  MsgBox Testo, vbInformation + vbOKOnly
            MostraAiuto(IDH_STR_AT21)
            Exit Function
        End If
        NewF = Monitor.Motore.Inizio.Workdir & Chr(92) & Arch & Testo & ".CAL"
        'UPGRADE_WARNING: Dir ha un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
        If Len(Dir(NewF)) = 0 Then
            '        Help$ = "Non hai eseguito il calcolo termico!|"
            'Help$ = Help$ + "Le scelte or ora effettuate verranno|"
            'Help$ = Help$ + "perse.                              |"
            ' Testo = Monitor.Motore.Inizio.ConvertiCr(at1(20))
            ' MsgBox Testo
            MostraAiuto(IDH_STR_AT20)
            Riscrivi = False
            Exit Function
        End If
        FileCopy(NewF, RadText & Arch)
        HTRI8(1)
        If TrapErrFortran() Then
            MostraAiuto(IDH_VEN_NOCALC)
        Else
            GeneraCAL(NewF, Arch)
        End If
    End Function
    Public Sub IniziaDaISA()
        ReDim Lav(0) ', DatiPrg(0) As DatiDes
        Inizia()
        '        BufBuf.WorkS.St = GlobalRoutines.Adjust(Monitor.Motore.Inizio.Workdir, 40)
        '       BufBuf.BaseArch.St = GlobalRoutines.Adjust(Monitor.Motore.Inizio.Archdir, 40)
    End Sub
    Public Sub Curvasciolta()
        Dim FirmaAz, Helpfile As Str40
        secondo = False
        daISA = False
        '      If Not Trim(BufBuf.WorkS.St) = Trim(Monitor.Motore.Inizio.Workdir) Then
        ' BufBuf.WorkS.St = GlobalRoutines.Adjust(Monitor.Motore.Inizio.Workdir, 40)
        ' BufBuf.BaseArch.St = GlobalRoutines.Adjust(Monitor.Motore.Inizio.Archdir, 40)
        FirmaAz.St = Monitor.Motore.Inizio.Firma
        Helpfile.St = RadiceHelp
        'DOAPAI(BufBuf.BaseArch, BufBuf.WorkS, FirmaAz, Helpfile, iErr)
        ' End If
        finCurva.Show()
    End Sub
    Public Function MainCurva() As Boolean
        MainCurva = True
        If Not secondo Then Call GetStandFH()
        If Tipo = "" Then Tipo = "FH"
        If Tipo = "FH" Then
            If Not Modulo() Then MainCurva = False : Exit Function
            If Not Fancur() Then MainCurva = False : Exit Function
        ElseIf Tipo = "SH" Then
            Call HpglHp("\CF\CF-P15PL.HPL", Monitor.Motore.Inizio.DiscoRam & "PROV" & RTrim(Lav(0).Arch))
        End If
        Do
            System.Windows.Forms.Application.DoEvents()
        Loop Until Monitor.Motore.InputForms Is Nothing
        If daISA Then
            If Not OKDati Then
                'UPGRADE_NOTE: È possibile che l'oggetto finCurva non venga eliminato in modo permanente finché non venga raccolto nel Garbage Collector. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
                finCurva = Nothing
                MainCurva = False : Exit Function
            End If
        Else
            RivsuFile()
            Modulo()
        End If
        If GeneraPRI() Then makepri(False)
        'End If
    End Function
    Public Sub CurvadaISA(ByRef Nrdit As Short, ByRef Arch As String, ByRef objDatBase As RoutBase1.DatBase)
        Dim Esito As Boolean
        Dim itp As String = ""
        Dim ifl As Short
        secondo = False
        ifl = FreeFile()
        FileOpen(ifl, Monitor.Motore.Inizio.Workdir & "\" & Arch & ".TE1", OpenMode.Random, , , Len(Lav(0)))
        'UPGRADE_WARNING: Get è stato aggiornato a FileGet e ha un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
        FileGet(ifl, Lav(0), 1)
        FileClose(ifl)
        If Not Ventilat(Arch, False, True) Then Exit Sub
        n = Val(Lav(0).Assieme(2))
        FilePRI = Monitor.Motore.Inizio.Workdir & "\" & Arch & GlobalRoutines.Str2Cifre(Nrdit \ 2) & Trim(Str(n)) & ".PSW"
        If n < 1 Or n > 5 Then n = 1
        Tipo = objDatBase.DatBase(4, 10, Nrdit \ 2, n, itp, 0)
        Prev = Trim(Lav(0).Arch)
        Item = RTrim(objDatBase.DatBase(2, 1, Nrdit \ 2, 1, itp, 0))
        File = Prev & GlobalRoutines.Str2Cifre(Nrdit \ 2)
        daISA = True
        If Not LeggiDati() Then Exit Sub
        If finCurva Is Nothing Then finCurva = New frmCurva
        finCurva.Show()
        'RivdaFile
        Esito = MainCurva()
    End Sub
    Public Sub Inizia()
        About = New RoutBase1.clsAbout
        Problem = New RoutBase1.clsProblem
        About.ProgName = "Ventil" '"HTRI"
        About.ProgVers = myAssembly.GetName.Version.Major.ToString & "." & myAssembly.GetName.Version.Minor.ToString
        Dim Fi As IO.FileInfo = New IO.FileInfo(myAssembly.Location)
        About.ProgDate = Format(Fi.CreationTime, "dd/MM/yy")
        About.ProgDesc = "Selezione ventilatori AFC"
        Problem.Extension = ".VE1"
        Problem.nonSciolto = True
        finCurva.Text = finCurva.Text & " (" & About.ProgVers & ", del " & About.ProgDate & ")"
    End Sub
    'UPGRADE_NOTE: Class_Terminate è stato aggiornato a Class_Terminate_Renamed. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
    Public Sub Class_Terminate_Renamed()
        'UPGRADE_NOTE: È possibile che l'oggetto About non venga eliminato in modo permanente finché non venga raccolto nel Garbage Collector. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        About = Nothing
        'UPGRADE_NOTE: È possibile che l'oggetto Problem non venga eliminato in modo permanente finché non venga raccolto nel Garbage Collector. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        Problem = Nothing
        'UPGRADE_NOTE: È possibile che l'oggetto Monitor non venga eliminato in modo permanente finché non venga raccolto nel Garbage Collector. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        Monitor = Nothing
        'UPGRADE_NOTE: È possibile che l'oggetto finCurva non venga eliminato in modo permanente finché non venga raccolto nel Garbage Collector. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        finCurva = Nothing
    End Sub
    Protected Overrides Sub Finalize()
        Class_Terminate_Renamed()
        MyBase.Finalize()
    End Sub
End Class