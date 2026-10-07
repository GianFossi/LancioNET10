Option Strict Off
Option Explicit On
Imports System.io
Imports System.Runtime.InteropServices
Public Class clsPpg
    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> Private Structure RecPpg65
        <VBFixedArray(17), MarshalAs(UnmanagedType.ByValArray, SizeConst:=18)> Dim H() As Single
        Dim PesoMoc As Single
        <VBFixedString(20), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=20)> Public Nome As String
        <VBFixedString(16), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=16)> Public Formula As String
        Public Sub Initialize()
            ReDim H(17)
        End Sub
    End Structure
    Public Stub, StubAcid As StubW2000.clsSW2000
    Public Stub9, StubAcid9 As StubW9.clsSW9
    Public Silente As Boolean
    Public Tmin, Tmax As Single
    Public VolMin, VolMax As Single
    Public ViscoMin, ViscoMax As Single
    Public CpMin, CpMax As Single
    Public kMin, kMax As Single
    Public Manuale As Boolean
    Public Schiavo As Boolean
    Public FileData, FileStam As String
    Public Acqua As Boolean
    Public Gia As Boolean
    'UPGRADE_WARNING: Il limite inferiore della matrice strUnit è stato cambiato da 1,1 a 0,0. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
    Private strUnit(3, 6) As String
    Private mioApert As Apert
    Private Erreur As String
    Private oldIPP As Short
    Private ppg1A1(,) As Single
    Private ppg1A2(,) As Single
    Private ppg1C() As Single
    Private ppg1E1() As String
    Private ppg1E2() As Single
    Private ppg1E3() As Single
    Private ppg1CpC0(,) As Short
    Private ppg1ZZ0(,) As Short
    Private ppg1ZZ1(,) As Short
    Private E165(,) As String
    Private E265() As Single
    Private E365() As Single
    Private Problem As typProblem
    Private Config As typConfig
    Private PPCOEFF() As Single
    Private Ris() As Boolean
    Private ZCM, TCM, VCM, OMM As Single
    Private TSAT, PCM, PRM, TRM As Single
    Private A1(,) As Single
    Private A2(,) As Single
    Private C() As Single
    Private E34 As Single
    Private DensityP, Density, ZM As Single
    Private ZM1, Zm0, VM As Single
    Private NN() As Single
    Private LISTPPG() As String
    Private N165() As Single
    Private Filenum As Short
    Private CC(65, 4) As Single
    Private KK(65, 4) As Single
    Private ZZ(65, 4) As Single
    Private TC(65) As Single
    Private VC(65) As Single
    Private OM(65) As Single
    Private ZC(65) As Single
    Private Rec As RecPpg65
    Public Sub New()
        MyBase.New()
        Monitor = New ppgMonitor
        Monitor.Ogg = Me
        Ifluide = 2
        strUnit(1, 1) = "kCal/kg°C "
        strUnit(2, 1) = "J/kg°C,  @"
        strUnit(3, 1) = "BTU/lb°F,@"
        strUnit(1, 2) = "kCal/h.m°C"
        strUnit(2, 2) = "w/m°C,   @"
        strUnit(3, 2) = "BTU/h.ft°F"
        strUnit(1, 3) = "cP,      @"
        strUnit(2, 3) = "kg/m.s,  @"
        strUnit(3, 3) = "cP,      @"
        strUnit(1, 4) = "kg/m3,   @"
        strUnit(2, 4) = "kg/m3,   @"
        strUnit(3, 4) = "lb/ft3,  @"
        strUnit(1, 5) = "kg/cm2 a. "
        strUnit(2, 5) = "bar a.,  @"
        strUnit(3, 5) = "psi a.,  @"
        strUnit(1, 6) = "°C"
        strUnit(2, 6) = "°C"
        strUnit(3, 6) = "°F"
        myAssembly = Me.GetType.Assembly
        Acqua = False
        Rec.Initialize()
    End Sub
    Public Sub Dispose()
        If Not Monitor Is Nothing Then
            Monitor.Motore = Nothing
        End If
        If Not Monitor Is Nothing Then Monitor.Motore = Nothing
        Monitor = Nothing
    End Sub
    Private Sub CPCZ0Z1() 'LECTPPG.BAS:CPCZ0Z1         Rev. 1 du 12/12/1996
        Dim Filenum, i0 As Short
        Dim icpc(14) As Short
        Dim i4 As Short
        Dim iz As Short
        Filenum = FreeFile()
        FileOpen(Filenum, Monitor.Motore.Inizio.Archdir & "\DCH\DATA\CPCZ.DAT", OpenMode.Input, , OpenShare.Shared)
        For i0 = 1 To 16
            For i4 = 1 To 14 : Input(Filenum, icpc(i4)) : Next
            For i4 = 2 To 14
                If i0 = 1 Then
                    ppg1CpC0(1, i4) = icpc(i4) ' Pression reduite * 1000
                Else
                    ppg1CpC0(i0, i4) = icpc(i4) ' delta Cp * 100
                End If
            Next i4
            ppg1CpC0(i0, 1) = icpc(1) ' Temp. reduite * 100
        Next i0
        For i0 = 1 To 22
            For i4 = 1 To 18
                Input(Filenum, iz)
                ppg1ZZ0(i0, i4) = iz
            Next i4
        Next i0
        For i0 = 23 To 44
            For i4 = 1 To 18
                Input(Filenum, iz)
                ppg1ZZ1(i0 - 22, i4) = iz
            Next i4
        Next i0
        FileClose(Filenum)
    End Sub
    Private Sub PPGAS65INIT()
        Dim Filenum, i As Short
        ' but de la subroutine , remplir E165$() et E265()

        Filenum = FreeFile()
        FileOpen(Filenum, Monitor.Motore.Inizio.Archdir & "\DCH\DATA\PPGAZ65.dat", OpenMode.Random, , OpenShare.Shared, Len(Rec))
        For i = 1 To 65

            'UPGRADE_WARNING: Get è stato aggiornato a FileGet e ha un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
            FileGet(Filenum, Rec, i)
            E265(i) = Rec.PesoMoc '           poids moleculaire
            E165(i, 1) = Rec.Nome '               nom des composes elementaires
            E165(i, 2) = Left(Rec.Formula, 12) '    formule chimique des composes elementaires
            ' TC65(I) = CVI(G15$) / 10'        temperature critique  øK
            ' PC65(I) = CVI(G16$) / 10'        pression    critique  ata
            ' VC65(I) = CVI(G17$) / 10'        volume      critique  cm3/g-mole
            ' ZC65(I) = CVI(G18$) / 1000'      coefficient de compressiblite critique
            ' OM65(I) = CVI(G19$) / 1000'      facteur d'acentrisme de PITZER & CURL
        Next i
        FileClose(Filenum)
    End Sub
    Public Sub Inizia()
        With Monitor.Motore
            .Problem.Extension = ".PPG"
            .About.ProgName = "* Ppgas * Physical properties of gas mixtures *"
            Monitor.Motore.About.ProgVers = myAssembly.GetName.Version.Major.ToString & "." & myAssembly.GetName.Version.Minor.ToString
            Dim Fi As IO.FileInfo = New IO.FileInfo(myAssembly.Location)
            Monitor.Motore.About.ProgDate = Format(Fi.CreationTime, "dd/MM/yy")
            .About.ProgDesc = ""
            .About.Company = Monitor.Motore.Inizio.Firma
        End With
        Dim ifl, i, i6 As Short
        ReDim NN(65)
        ReDim LISTPPG(65)
        ReDim N165(65)
        ReDim ppg1A1(5, 10)
        ReDim ppg1A2(5, 10)
        ReDim ppg1C(10)
        ReDim ppg1E1(16)
        ReDim ppg1E2(16)
        ReDim ppg1E3(16)
        ReDim ppg1CpC0(16, 14)
        ReDim ppg1ZZ0(22, 18)
        ReDim ppg1ZZ1(22, 18)
        ReDim E165(66, 2)
        ReDim E265(65)
        ReDim E365(65)
        ReDim PPCOEFF(23)
        ReDim Ris(65)
        ReDim A1(5, 10)
        ReDim A2(5, 10)
        ReDim C(10)
        ifl = FreeFile()
        FileOpen(ifl, Monitor.Motore.Inizio.Archdir & "\DCH\DATA\PPGDATA.DAT", OpenMode.Input)
        For i = 1 To 10
            Input(ifl, ppg1C(i))
            For i6 = 1 To 5
                Input(ifl, ppg1A1(i6, i))
                Input(ifl, ppg1A2(i6, i))
            Next i6
        Next i
        For i = 1 To 16 : Input(ifl, ppg1E2(i)) : Next i ' poids mol‚culaire
        For i = 1 To 16
            Input(ifl, ppg1E1(i))
        Next i ' nom des compos‚s ‚l‚mentaires
        FileClose(ifl)
        CPCZ0Z1()
        PPGAS65INIT()
    End Sub
    Public Sub mostra(ByRef Fluido As String, Optional ByRef f As String = "")
        ' Modo = 1: da Fire
        If Len(f) > 0 Then FileData = f
        Problem.Fluido = Fluido
        mioApert = New Apert
        mioApert.Ogg = Me
        If Schiavo Then
            mioApert.Aggiorna()
            Inizializza()
            mioApert.Frame3.Visible = True
            Salva()
            mioApert.ShowDialog()
        Else
            mioApert.mnuCompos_Click(mioApert.mnuCompos.Item(0), New System.EventArgs)
            mioApert.Show()
        End If
        Fluido = Problem.Fluido
    End Sub
    Public Property DoveMotore() As RoutBase1.clsMotore
        Get
            DoveMotore = Monitor.Motore
        End Get
        Set(ByVal Value As RoutBase1.clsMotore)
            Monitor.Motore = Value
            Monitor.Motore.InitProb("PPGS")
            'RadiceHelp = Monitor.Motore.Inizio.AppLancio & rmHelpStrings.GetString("Helpfile") '"\BIN\AiutoWRCB.chm"
        End Set
    End Property
    Public Property prTmin() As Single
        Get
            prTmin = Config.Tmin
        End Get
        Set(ByVal Value As Single)
            Config.Tmin = Value
        End Set
    End Property
    Public Property prTmax() As Single
        Get
            prTmax = Config.Tmax
        End Get
        Set(ByVal Value As Single)
            Config.Tmax = Value
        End Set
    End Property
    Public Property prFluido() As String
        Get
            prFluido = Problem.Fluido
        End Get
        Set(ByVal Value As String)
            Problem.Fluido = Value
        End Set
    End Property

    Public Property prTincr() As Single
        Get
            prTincr = Config.Tincr
        End Get
        Set(ByVal Value As Single)
            Config.Tincr = Value
        End Set
    End Property
    Public Property prPressione() As Single
        Get
            prPressione = Config.Pressione
        End Get
        Set(ByVal Value As Single)
            Config.Pressione = Value
        End Set
    End Property
    Public Property prE3(ByVal i As Short) As Single
        Get
            If Config.Ippgas65 = 0 Then
                prE3 = ppg1E3(i)
            ElseIf Config.Ippgas65 < 3 Then
                prE3 = E365(i)
            End If
        End Get
        Set(ByVal Value As Single)
            If Config.Ippgas65 = 0 Then
                ppg1E3(i) = Value
            ElseIf Config.Ippgas65 < 3 Then
                E365(i) = Value
            End If
        End Set
    End Property
    Public Property prPercVol() As Short
        Get
            prPercVol = Config.PercVol
        End Get
        Set(ByVal Value As Short)
            Config.PercVol = Value
        End Set
    End Property
    Public Property prIppgas65() As Short
        Get
            prIppgas65 = Config.Ippgas65
        End Get
        Set(ByVal Value As Short)
            If oldIPP < 0 Or oldIPP > 1 Then oldIPP = 0
            Select Case Value
                Case -1 : Config.Ippgas65 = oldIPP
                Case 2, 3
                    oldIPP = Config.Ippgas65
                    Config.Ippgas65 = Value
                Case Else : Config.Ippgas65 = Value
                    oldIPP = Config.Ippgas65
            End Select
        End Set
    End Property
    Public Property priUnit() As Short
        Get
            priUnit = Config.iUnit
        End Get
        Set(ByVal Value As Short)
            Config.iUnit = Value
        End Set
    End Property
    Public Property prPesoMoc(ByVal t As Single) As Single
        Get
            Dim iinf, i, isup As Short
            If Config.Ippgas65 < 3 Then
                prPesoMoc = PPCOEFF(19)
            Else
                If t < CurvPoint(nPoints).Temp Then
                    iinf = nPoints - 1
                    isup = nPoints
                ElseIf t > CurvPoint(1).Temp Then
                    iinf = 1
                    isup = 2
                Else
                    For i = 1 To nPoints - 1
                        If t <= CurvPoint(i).Temp And t >= CurvPoint(i + 1).Temp Then Exit For
                    Next
                    iinf = i
                    isup = i + 1
                End If
                prPesoMoc = (CurvPoint(iinf).MolG + (CurvPoint(isup).MolG - CurvPoint(iinf).MolG) * (t - CurvPoint(iinf).Temp) / (CurvPoint(isup).Temp - CurvPoint(iinf).Temp))
            End If
        End Get
        Set(ByVal Value As Single)
            If Config.Ippgas65 < 3 Then
                PPCOEFF(19) = Value
            Else
            End If
        End Set
    End Property
    Public Property prE2(ByVal i As Short) As Single
        Get
            prE2 = ppg1E2(i)
        End Get
        Set(ByVal Value As Single)
            ppg1E2(i) = Value
        End Set
    End Property
    Public Property prCommessa() As String
        Get
            prCommessa = Monitor.Motore.Problem.Commessa
        End Get
        Set(ByVal Value As String)
            Monitor.Motore.Problem.Commessa = Value
            Problem.Commessa = Value
        End Set
    End Property


    Public Property prItem() As String
        Get
            prItem = Monitor.Motore.Problem.Item
        End Get
        Set(ByVal Value As String)
            Monitor.Motore.Problem.Item = Value
            Problem.Item = Value
        End Set
    End Property
    Public Function Accedi(ByRef f As String, ByRef ff As String) As Boolean
        Dim Path, File As String
        Dim n As Short
        If Not Acqua Then
            If Len(f) < 5 Then Exit Function
            FileData = Left(f, Len(f) - 3) & "PPG"
            FileStam = Left(f, Len(f) - 4) & "PPS.DOC"
            If Mid(FileData, Len(FileData) - 5, 1) = "\" Then Exit Function
            If Not IO.File.Exists(FileData) And Schiavo Then
                Path = IO.Path.GetFullPath(FileData) & "\"
                File = IO.Path.GetFileName(FileData)
                n = InStr(File, "a")
                If n > 4 Then
                    File = Left(File, n - 1) & "*" & Right(File, 4)
                    'UPGRADE_WARNING: Dir ha un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
                    File = Dir(Path & File)
                    If Len(File) > 0 Then
                        FileCopy(Path & File, FileData)
                    Else
                        Exit Function
                    End If
                Else
                    Exit Function
                End If
                'UPGRADE_WARNING: Dir ha un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
            ElseIf Len(Dir(FileData)) = 0 Then
                MsgBox("Il file di dati " & f & " non esiste.")
            End If
        End If
        Inizia()
        Apri()
        Inizializza()
        ff = Problem.Fluido
        Accedi = True
    End Function
    Public Function Cp(ByRef t As Single, ByRef P As Single) As Single
        Dim iinf, i, isup As Short
        If Manuale Then
            If CpMax = 0 Or CpMin = 0 Then Exit Function
            Cp = CpMin + (t - Tmin) / (Tmax - Tmin) * (CpMax - CpMin)
        Else
            If Config.Ippgas65 = 2 Then
                Cp = CalculCp(t, P, E34, 70) 'manuale
            ElseIf Config.Ippgas65 = 3 Then
                If t < CurvPoint(nPoints).Temp Then
                    iinf = nPoints - 1
                    isup = nPoints
                ElseIf t > CurvPoint(1).Temp Then
                    iinf = 1
                    isup = 2
                Else
                    For i = 1 To nPoints - 1
                        If t <= CurvPoint(i).Temp And t >= CurvPoint(i + 1).Temp Then Exit For
                    Next
                    iinf = i
                    isup = i + 1
                End If
                Cp = (CurvPoint(iinf).Cgas + (CurvPoint(isup).Cgas - CurvPoint(iinf).Cgas) * (t - CurvPoint(iinf).Temp) / (CurvPoint(isup).Temp - CurvPoint(iinf).Temp)) * 1000
            Else
                Cp = CalculCp(t, P, E34, 121)
            End If
        End If
    End Function
    Public Function Titolo(ByRef t As Single) As Single
        Dim iinf, i, isup As Short
        Dim tit As Single
        If t < CurvPoint(nPoints).Temp Then
            iinf = nPoints - 1
            isup = nPoints
        ElseIf t > CurvPoint(1).Temp Then
            iinf = 1
            isup = 2
        Else
            For i = 1 To nPoints - 1
                If t <= CurvPoint(i).Temp And t >= CurvPoint(i + 1).Temp Then Exit For
            Next
            iinf = i
            isup = i + 1
        End If
        tit = (CurvPoint(iinf).Xgas + (CurvPoint(isup).Xgas - CurvPoint(iinf).Xgas) * (t - CurvPoint(iinf).Temp) / (CurvPoint(isup).Temp - CurvPoint(iinf).Temp))
        'If tit < 1 Then Stop
        Titolo = tit
    End Function
    Public Function Dens(ByRef t As Single, ByRef P As Single) As Single
        If Manuale Then
            DensityP = 1 / (VolMin + (t - Tmin) / (Tmax - Tmin) * (VolMax - VolMin))
        Else
            CalcDensity(t, P)
        End If
        Dens = DensityP
    End Function
    Public Function Conduc(ByRef t As Single, ByRef P As Single) As Single
        Dim K0P, Z0P As Single
        Dim iinf, i, isup As Short
        If Manuale Then
            K0P = kMin + (t - Tmin) / (Tmax - Tmin) * (kMax - kMin)
            Conduc = K0P
        Else
            If Config.Ippgas65 = 2 Then
                Call ConducVisco(t, P, 70, K0P, Z0P)
                Conduc = K0P
            ElseIf Config.Ippgas65 = 3 Then
                If t < CurvPoint(nPoints).Temp Then
                    iinf = nPoints - 1
                    isup = nPoints
                ElseIf t > CurvPoint(1).Temp Then
                    iinf = 1
                    isup = 2
                Else
                    For i = 1 To nPoints - 1
                        If t <= CurvPoint(i).Temp And t >= CurvPoint(i + 1).Temp Then Exit For
                    Next
                    iinf = i
                    isup = i + 1
                End If
                Conduc = CurvPoint(iinf).Cong + (CurvPoint(isup).Cong - CurvPoint(iinf).Cong) * (t - CurvPoint(iinf).Temp) / (CurvPoint(isup).Temp - CurvPoint(iinf).Temp)
            Else
                Call ConducVisco(t, P, 121, K0P, Z0P)
                Conduc = K0P
            End If
        End If
    End Function
    Public Function Visco(ByRef t As Single, ByRef P As Single) As Single
        Dim K0P, Z0P As Single
        Dim iinf, i, isup As Short
        If Manuale Then
            Z0P = ViscoMin + (t - Tmin) / (Tmax - Tmin) * (ViscoMax - ViscoMin)
            Visco = Z0P
        Else
            If Config.Ippgas65 = 2 Then
                Call ConducVisco(t, P, 70, K0P, Z0P)
                Visco = Z0P
            ElseIf Config.Ippgas65 = 3 Then
                If t < CurvPoint(nPoints).Temp Then
                    iinf = nPoints - 1
                    isup = nPoints
                ElseIf t > CurvPoint(1).Temp Then
                    iinf = 1
                    isup = 2
                Else
                    For i = 1 To nPoints - 1
                        If t <= CurvPoint(i).Temp And t >= CurvPoint(i + 1).Temp Then Exit For
                    Next
                    iinf = i
                    isup = i + 1
                End If
                Visco = CurvPoint(iinf).Visg + (CurvPoint(isup).Visg - CurvPoint(iinf).Visg) * (t - CurvPoint(iinf).Temp) / (CurvPoint(isup).Temp - CurvPoint(iinf).Temp)
            Else
                Call ConducVisco(t, P, 121, K0P, Z0P)
                Visco = Z0P
            End If
        End If
    End Function
    Private Function INPUTPPGAS16(ByRef IA0 As Short, ByRef PM As Single, Optional ByRef Salto As Boolean = False, Optional ByRef mostra As Boolean = True) As Boolean '                    LECTPPG.BAS:INPUTPPGAS16
        Dim i As Short
        Dim N08, N0 As Single
        Dim Ninput As Short
        Dim Testo As String
        Dim Strin(16) As String
        Dim Risult(16) As String
        Dim Archiv(16) As Short
        Dim dAiuto(16) As String
        'UPGRADE_WARNING: È possibile che si debba inizializzare le matrici nella struttura Rec prima di poterle utilizzare. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
        Dim Index(16) As Short
        Dim M0, M1 As Single
        'SUB INPUTPPGAS16 (IA0, A0$, E1$(), E22() AS SINGLE, E33() AS SINGLE, PM AS SINGLE) '                    LECTPPG.BAS:INPUTPPGAS16
        '(IA0, A0$, E1() AS STRING * 4, E22() AS SINGLE, E33() AS SINGLE, PM AS SINGLE) '                    LECTPPG.BAS:INPUTPPGAS16
        'STOP
        '  IA0=1 : la composition sera entree en % volume
        '  IA0=2 : la composition sera entree en % poids
        '  IA0=3 : la composition est connue en % volume, elle est affichee puis demande de confirmation
        N08 = 0
        'For i = 1 To 16
        '  EEE$(i) = Left$(RTrim$(ppg1E1(i)) + Space$(4), 4)
        'Next
        If Salto Then
            For i = 1 To 16
                If System.Math.Abs(ppg1E3(i)) > 10000000000.0# Then
                    NN(i) = 0
                Else
                    NN(i) = ppg1E3(i) * 100
                End If
            Next
            GoTo Salta
        End If
        If IA0 = 3 Then GoTo AffichEcran
        If IA0 = 1 Then Testo = "in volume" Else Testo = "in peso"
        For i = 1 To 16
            If Ris(i) Then
                NN(i) = ppg1E3(i) * 100
                If IA0 = 2 And PM > 0 Then NN(i) = NN(i) * ppg1E2(i) / PM
                '  LOCATE 4 + i, 1: Print FormatS "% \    \  de \  \  :"; A$; EEE$(i);
                '  If NN(i) = 0 Then Print "  0" Else Print FormatS "###.###"; NN(i)
                N08 = N08 + NN(i)
                '  LOCATE 23, 10: Print FormatS "TOTAL enregistr‚ : ####.####"; N08;
                Ninput = Ninput + 1
                Strin(Ninput) = ppg1E1(i)
                Risult(Ninput) = Funzioni.myStr(NN(i), 4, 2, False)
                Index(Ninput) = i
            Else
                NN(i) = 0
            End If
        Next i
        If Ninput = 0 Then Exit Function
        If mostra Then
            If Not Monitor.Motore.InputDati(Ninput, "Composizione miscela " & Testo, Strin, Risult, "", Archiv, dAiuto) Then Exit Function
        End If
        N0 = 0
        For i = 1 To Ninput
            NN(Index(i)) = Funzioni.ValVir(Risult(i))
            N0 = N0 + NN(Index(i))
        Next
        If N0 < 0.001 Then Exit Function
        If N0 > 100.1 Or N0 < 99.9 Then
            For i = 1 To 16
                NN(i) = NN(i) * 100 / N0
            Next
        End If
        'InpoutNN: N0 = 0
        'For i = 1 To 16
        '  LOCATE 4 + i, 1: Print FormatS "% \    \  de \  \  : "; A$; EEE$(i);: INPOUT NN(i)
        '  If NN(i) < 0 Or NN(i) > 100 Then NN(i) = 0: COLOR 13: LOCATE 1, 1: Print " ERREUR": Print " RECOMMENCEZ": BEEP: COLOR 7: GoTo InpoutNN
        '  If i = 1 Then LOCATE 1, 1: Print "        ": LOCATE 2, 1: Print "             "
        '  N0 = N0 + NN(i): N08 = 0
        '  LOCATE 23, 10: Print FormatS "TOTAL enregistr‚   :####.#### il manque ###.####"; N0; 100 - N0;
        '  For I8 = 1 To 16: N08 = N08 + NN(I8): Next I8
        '  LOCATE 24, 10: Print FormatS "TOTAL sur cet ‚cran:####.#### il manque ###.####"; N08; 100 - N08;
        'Next i
        'If N0 < 99.9 Or N0 > 100.1 Then LOCATE 1, 1: COLOR 13: Print " ERREUR": Print " RECOMMENCEZ": BEEP: COLOR 7: GoTo InpoutNN
Salta:
        M0 = 0 : M1 = 0
        If IA0 = 1 Then
            For i = 1 To 16 : ppg1E3(i) = NN(i) / 100 : M1 = M1 + ppg1E3(i) : Next i
        Else
            For i = 1 To 16 : ppg1E3(i) = NN(i) / ppg1E2(i) : M0 = M0 + ppg1E3(i) : Next i
            For i = 1 To 16 : ppg1E3(i) = ppg1E3(i) / M0 : M1 = M1 + ppg1E3(i) : Next i
        End If
        PM = 0
        For i = 1 To 16 : PM = PM + ppg1E2(i) * ppg1E3(i) : Next i
        'LOCATE 13, 41: Print "POIDS MOLECULAIRE "; PM; "kg/kmole"
        INPUTPPGAS16 = True
        Exit Function
AffichEcran:
        If mostra Then
            PM = 0
            mioApert.Picture1.BringToFront()
            mioApert.Picture1.Visible = True
            mioApert.cmdOKGo.BringToFront()
            mioApert.cmdOKGo.Visible = True
            mioApert.mygraphics.Clear(Color.White)
            'mioApert.Picture1.Top = mioApert.Frame1.Top - 400
            For i = 1 To 16 : PM = PM + ppg1E2(i) * ppg1E3(i) : Next i
            For i = 1 To 16
                If ppg1E3(i) = 0 Then
                    mioApert.Scrivi(Funzioni.FormatS("\    \:   0     % vol     0     % peso", ppg1E1(i)))
                Else
                    mioApert.Scrivi(Funzioni.FormatS("\    \: ###.### % vol   ###.### % peso", ppg1E1(i), ppg1E3(i) * 100, ppg1E2(i) * ppg1E3(i) / PM * 100))
                End If
            Next i
            mioApert.Scrivi("")
            mioApert.Scrivi("POIDS MOLECULAIRE " & PM.ToString & " kg/kmole")
        End If
        INPUTPPGAS16 = True
    End Function
    Private Function INPUTPPGAS65(ByRef IA0 As Object, ByRef PM As Single, Optional ByRef Salto As Boolean = False, Optional ByRef mostra As Boolean = True) As Boolean '                                     LECTPPG.BAS:INPUTPPGAS65
        Dim i As Short
        Dim N0 As Single
        Dim Ninput As Short
        Dim Testo As String
        Dim Strin(65) As String
        Dim Risult(65) As String
        Dim Archiv(65) As Short
        Dim dAiuto(65) As String
        Dim Index(65) As Short
        Dim M0, M1 As Single

        ' but de la subroutine : remplir N165() et calculer PM & E365()
        ' variables d'entree  : IA0, A0$, E165$() & E265()
        ' variables de sortie : A0$, PM, E365()
        ' variables locales   : I, I2, I3, I5, II, N0, NN1, LISTPPG$(), N165()

        '  IA0=1 : la composition sera entree en % volume
        '  IA0=2 : la composition sera entree en % poids
        '  IA0=3 : la composition sera affichee puis demande de confirmation
        Try
            If Salto Then
                For i = 1 To 65
                    N165(i) = E365(i) * 100
                Next
                GoTo CALCULPM65
            End If
            For i = 1 To 65
                LISTPPG(i) = " " & E165(i, 1) & " " & E165(i, 2) & " " ' nom du composant + formule chimique
                N165(i) = 0
            Next i
            Testo = "in volume"
            If IA0 = 3 Then
                For i = 1 To 65 : N165(i) = 100 * E365(i) : Next i
                IA0 = 1
                GoTo AFFICHPPGAZ65
            End If
            If IA0 = 2 Then Testo = "in peso"
            For i = 1 To 65
                If Ris(i) Then
                    N165(i) = E365(i) * 100
                    If IA0 = 2 And PM > 0 Then N165(i) = N165(i) * E265(i) / PM
                    Ninput = Ninput + 1
                    Strin(Ninput) = LISTPPG(i)
                    Risult(Ninput) = Funzioni.myStr(N165(i), 4, 2, False)
                    Index(Ninput) = i
                Else
                    N165(i) = 0
                End If
            Next i
            If Ninput = 0 Then Exit Function
            If mostra Then
                If Not Monitor.Motore.InputDati(Ninput, "Composizione miscela " & Testo, Strin, Risult, "", Archiv, dAiuto) Then Exit Function
            End If
            N0 = 0
            For i = 1 To 65
                N165(i) = 0
            Next
            For i = 1 To Ninput
                N165(Index(i)) = Funzioni.ValVir(Risult(i))
                N0 = N0 + N165(Index(i))
            Next
            If N0 < 0.001 Then Exit Function
            If N0 > 100.1 Or N0 < 99.9 Then
                For i = 1 To 65
                    N165(i) = N165(i) * 100 / N0
                Next
            End If

CALCULPM65:  'calcul poids mol‚culaire et traduction % vol en % poids et vice-versa
            M0 = 0 : M1 = 0
            If IA0 = 1 Then
                For i = 1 To 65 : E365(i) = N165(i) / 100 : M1 = M1 + E365(i) : Next i
            Else ' (IA0=2)
                For i = 1 To 65 : E365(i) = N165(i) / E265(i) : M0 = M0 + E365(i) : Next i
                For i = 1 To 65 : E365(i) = E365(i) / M0 : M1 = M1 + E365(i) : Next i
            End If
            INPUTPPGAS65 = True
            Exit Function
AFFICHPPGAZ65:  ' affichage de la composition et demande de confirmation
            PM = 0
            For i = 1 To 65 : PM = PM + E265(i) * E365(i) : Next i
            If mostra Then
                mioApert.Picture1.BringToFront()
                mioApert.Picture1.Visible = True
                mioApert.cmdOKGo.BringToFront()
                mioApert.cmdOKGo.Visible = True
                mioApert.mygraphics.Clear(Color.White)
                mioApert.Scrivi("DONNEES D'ENTREE  -  " & Testo)
                mioApert.Scrivi("COMPOSITION DU GAZ")
                mioApert.Scrivi("")
                For i = 1 To 65
                    If E365(i) > 0 Then mioApert.Scrivi(Funzioni.FormatS("\                    \ : ###.### % volume ###.### % poids", E165(i, 1), E365(i) * 100, E265(i) * E365(i) * 100 / PM))
                Next i
                mioApert.Scrivi("POIDS MOLECULAIRE " & PM.ToString & " kg/kmole")
            End If
            INPUTPPGAS65 = True
        Catch ex As Exception
            MessageBox.Show(ex.Message + vbCrLf + ex.StackTrace)
        End Try
    End Function

    Private Sub LECTUREPPGAS16() '                        LECTPPG.BAS:LECTUREPPGAS     Rev. 1 du 12/12/1996
        Dim i As Short
        Dim H(18) As Single
        Dim C3, C1, C2, PM As Single
        Dim K3, K1, N0, K2, K4 As Single
        Dim Z2, Z1, Z3 As Single
        Dim XM, C4 As Single
        ' variables d'entree  : E22(), E33() et le poids moleculaire PM alias PPCOEFF(19)
        ' variables de sortie : PPCOEFF(1 … 11), XM, PCM, TCM, VCM, OMM & ZCM  dans PPCOEFF(17 … 23)
        ' variables locales   : C1, C2, C3, C4, CC(), H(), I, I1, I0, K1, K2, K3, K4, KK(), N0, NN(),PM, Z1, Z2, Z3, ZZ(), TC(), VC() ,OM() ,ZC()
        N0 = 0 '                                                                                              LECTPPG.BAS:LECTUREPPGAS
        For i = 1 To 16
            NN(i) = ppg1E3(i)
            N0 = N0 + NN(i)
        Next i
        If N0 = 0 Then Exit Sub
        Filenum = FreeFile()
        FileOpen(Filenum, Monitor.Motore.Inizio.Archdir & "\DCH\DATA\PPGAZ65.dat", OpenMode.Random, , OpenShare.Shared, Len(Rec))
        LP16(1, 11) 'CO
        LP16(2, 26) 'H2O
        LP16(3, 1) 'H2
        LP16(4, 2) 'N2
        LP16(5, 12) 'CO2
        LP16(6, 31) 'CH4
        LP16(7, 6) 'Ar
        LP16(8, 18) 'NH3
        LP16(9, 3) 'O2
        LP16(10, 16) 'NO
        LP16(11, 17) 'NO2
        LP16(12, 13) 'SO2
        LP16(13, 14) 'SO3
        LP16(14, 28) 'C2H4
        LP16(15, 32) 'C2H6
        LP16(16, 33) 'C3H8
        FileClose(Filenum)
        C1 = 0 : C2 = 0 : C3 = 0 : C4 = 0 : PM = PPCOEFF(19)
        For i = 1 To 16 ' la fraction en poids = NN(I) / PM
            NN(i) = ppg1E2(i) * ppg1E3(i) / PM
            C1 = C1 + CalJ * CC(i, 1) * NN(i) / ppg1E2(i)
            C2 = C2 + CalJ * CC(i, 2) * NN(i) / ppg1E2(i) ' le E2(I) est la … cause de l'unite choisie par YAWS
            C3 = C3 + CalJ * CC(i, 3) * NN(i) / ppg1E2(i)
            C4 = C4 + CalJ * CC(i, 4) * NN(i) / ppg1E2(i)
        Next i
        N0 = 0 '                                                                                              LECTPPG.BAS:LECTUREPPGAS
        For i = 1 To 16
            NN(i) = ppg1E3(i) * (ppg1E2(i) ^ 0.333333)
            N0 = N0 + NN(i)
        Next i
        'C0 = C1 + C2 * T6 + C3 * T6 * T6 + C4 * T6 * T6 * T6 en J/kgøC
        K1 = 0 : K2 = 0 : K3 = 0 : K4 = 0
        For i = 1 To 16
            K1 = K1 + KK(i, 1) * NN(i) / N0 * 241.8 / 1000000.0! / kgmsB
            K2 = K2 + KK(i, 2) * NN(i) / N0 * 241.8 / 1000000.0! / kgmsB
            K3 = K3 + KK(i, 3) * NN(i) / N0 * 241.8 / 1000000.0! / kgmsB
            K4 = K4 + KK(i, 4) * NN(i) / N0 * 241.8 / 1000000.0! / kgmsB
        Next i
        'K0 = K1 + K2 * T6 + K3 * T6 * T6 + K4 * T6 * T6 * T6  e n W/mýøC
        N0 = 0
        For i = 1 To 16
            NN(i) = ppg1E3(i) * System.Math.Sqrt(ppg1E2(i))
            N0 = N0 + NN(i)
        Next i
        Z1 = 0 : Z2 = 0 : Z3 = 0
        For i = 1 To 16
            Z1 = Z1 + ZZ(i, 1) * NN(i) / N0 / 10000.0! / 1000
            Z2 = Z2 + ZZ(i, 2) * NN(i) / N0 / 10000.0! / 1000
            Z3 = Z3 + ZZ(i, 3) * NN(i) / N0 / 10000.0! / 1000
        Next i
        'Z0 = Z1 + Z2 * T6 + Z3 * T6 * T6 en kg/msec

        PPCOEFF(1) = C1 : PPCOEFF(2) = C2 : PPCOEFF(3) = C3 : PPCOEFF(4) = C4
        PPCOEFF(5) = K1 : PPCOEFF(6) = K2 : PPCOEFF(7) = K3 : PPCOEFF(8) = K4
        PPCOEFF(9) = Z1 : PPCOEFF(10) = Z2 : PPCOEFF(11) = Z3

        TCM = 0 : VCM = 0 : ZCM = 0 : OMM = 0 ' calcul des constantes
        For i = 1 To 16 : TCM = TCM + TC(i) * ppg1E3(i) : Next i ' pseudocritiques du
        For i = 1 To 16 : VCM = VCM + VC(i) * ppg1E3(i) : Next i ' melange
        For i = 1 To 16 : OMM = OMM + OM(i) * ppg1E3(i) : Next i ' methode de P. & G.
        For i = 1 To 16 : ZCM = ZCM + ZC(i) * ppg1E3(i) : Next i ' modifiee

        PCM = ZCM * 82.06 * TCM / VCM ' en ata
        XM = (TCM ^ 0.166667) / System.Math.Sqrt(PM) / (PCM ^ 0.666667) ' lettre grec KSI pour la viscosite

        'E33(17) = 0:   E33(18) = 0:   E33(19) = XM:  E33(20) = PCM: E33(21) = PM
        'E33(22) = TCM: E33(23) = OMM: E33(24) = VCM: E33(25) = ZCM: E33(26) = -999

        PPCOEFF(17) = VCM : PPCOEFF(18) = ZCM ' PPCOEFF(19) = PM (deja defini)
        PPCOEFF(20) = PCM : PPCOEFF(21) = XM : PPCOEFF(22) = TCM : PPCOEFF(23) = OMM
    End Sub
    Private Sub LP16(ByVal i1 As Short, ByVal i0 As Short)
        FileGet(Filenum, Rec, i0)
        CC(i1, 1) = Rec.H(2 - 1) : CC(i1, 2) = Rec.H(3 - 1)
        CC(i1, 3) = Rec.H(4 - 1) : CC(i1, 4) = Rec.H(5 - 1)
        KK(i1, 1) = Rec.H(6 - 1) : KK(i1, 2) = 10 * Rec.H(7 - 1)
        KK(i1, 3) = 100 * Rec.H(8 - 1) : KK(i1, 4) = 10 * Rec.H(9 - 1)
        ZZ(i1, 1) = Rec.H(10 - 1) : ZZ(i1, 2) = 10 * Rec.H(11 - 1)
        ZZ(i1, 3) = Rec.H(12 - 1)
        TC(i1) = Rec.H(13 - 1) / 10 : VC(i1) = Rec.H(15 - 1) / 10
        OM(i1) = Rec.H(17 - 1) / 1000 : ZC(i1) = Rec.H(16 - 1) / 1000
    End Sub
    Private Function LECTUREPPGAS65() As Boolean '                                             LECTPPG.BAS:LECTUREPPGAS65
        Dim Filenum As Short
        Dim i0, i As Short
        Dim C3, C1, C2, PM As Single
        Dim K3, K1, N0, K2, K4 As Single
        Dim Z2, Z1, Z3 As Single
        Dim XM, C4 As Single
        Dim Rec As RecPpg65 = New RecPpg65
        Rec.Initialize()
        ' variables d'entree  : E265(), E365(), Poids moleculaire = PPCOEFF(19)
        ' variables de sortie : PPCOEFF(1 … 11 et 17 … 23)
        ' variables locales   : C1, C2, C3, C4, CC(), H(), I, I0, K1, K2, K3, K4, KK(), N0, NN(), Z1, Z2, Z3, ZZ()
        N0 = 0
        LECTUREPPGAS65 = True
        For i = 1 To 65
            NN(i) = E365(i)
            N0 = N0 + NN(i)
        Next i
        If N0 = 0 Then Exit Function
        Filenum = FreeFile()
        FileOpen(Filenum, Monitor.Motore.Inizio.Archdir & "\DCH\DATA\PPGAZ65.dat", OpenMode.Random, , OpenShare.Shared, Len(Rec))
        For i0 = 1 To 65
            If E365(i0) > 0 Then
                FileGet(Filenum, Rec, i0)
                CC(i0, 1) = Rec.H(2 - 1) : CC(i0, 2) = Rec.H(3 - 1)
                CC(i0, 3) = Rec.H(4 - 1) : CC(i0, 4) = Rec.H(5 - 1)
                KK(i0, 1) = Rec.H(6 - 1) : KK(i0, 2) = 10 * Rec.H(7 - 1)
                KK(i0, 3) = 100 * Rec.H(8 - 1) : KK(i0, 4) = 10 * Rec.H(9 - 1)
                ZZ(i0, 1) = Rec.H(10 - 1) : ZZ(i0, 2) = 10 * Rec.H(11 - 1)
                ZZ(i0, 3) = Rec.H(12 - 1)
                TC(i0) = Rec.H(13 - 1) / 10 : VC(i0) = Rec.H(15 - 1) / 10
                OM(i0) = Rec.H(17 - 1) / 1000 : ZC(i0) = Rec.H(16 - 1) / 1000
            End If
        Next i0
        FileClose(Filenum)
        PM = PPCOEFF(19)
        If PM = 0 Then
            LECTUREPPGAS65 = False
            Exit Function
        End If
        C1 = 0 : C2 = 0 : C3 = 0 : C4 = 0
        For i = 1 To 65
            NN(i) = E365(i) * E265(i) / PM ' fraction en masse
            If E365(i) = 0 Then GoTo 6100
            C1 = C1 + CalJ * CC(i, 1) * NN(i) / E265(i)
            C2 = C2 + CalJ * CC(i, 2) * NN(i) / E265(i) ' le E2(I) est la … cause de l'unite choisie par YAWS
            C3 = C3 + CalJ * CC(i, 3) * NN(i) / E265(i)
            C4 = C4 + CalJ * CC(i, 4) * NN(i) / E265(i)
6100:   Next i
        'C0 = C1 + C2 * T6 + C3 * T6 * T6 + C4 * T6 * T6 * T6 * T6 en J/kgøC
        N0 = 0
        For i = 1 To 65
            NN(i) = E365(i) * (E265(i) ^ 0.333333)
            N0 = N0 + NN(i)
        Next i

        K1 = 0 : K2 = 0 : K3 = 0 : K4 = 0
        For i = 1 To 65
            If E365(i) = 0 Then GoTo 6200
            K1 = K1 + KK(i, 1) * NN(i) / N0 * 241.8 / 1000000.0! / kgmsB
            K2 = K2 + KK(i, 2) * NN(i) / N0 * 241.8 / 1000000.0! / kgmsB
            K3 = K3 + KK(i, 3) * NN(i) / N0 * 241.8 / 1000000.0! / kgmsB
            K4 = K4 + KK(i, 4) * NN(i) / N0 * 241.8 / 1000000.0! / kgmsB
6200:   Next i
        'K0 = K1 + K2 * T6 + K3 * T6 * T6 + K4 * T6 * T6 * T6  en W/mýøC

        N0 = 0
        For i = 1 To 65
            NN(i) = E365(i) * System.Math.Sqrt(E265(i))
            N0 = N0 + NN(i)
        Next i
        Z1 = 0 : Z2 = 0 : Z3 = 0
        For i = 1 To 65
            If E365(i) = 0 Then GoTo 6300
            Z1 = Z1 + ZZ(i, 1) * NN(i) / N0 / 10000.0! / 1000
            Z2 = Z2 + ZZ(i, 2) * NN(i) / N0 / 10000.0! / 1000
            Z3 = Z3 + ZZ(i, 3) * NN(i) / N0 / 10000.0! / 1000
6300:   Next i
        'Z0 = Z1 + Z2 * T6 + Z3 * T6 * T6 en kg/msec

        PPCOEFF(1) = C1 : PPCOEFF(2) = C2 : PPCOEFF(3) = C3 : PPCOEFF(4) = C4
        PPCOEFF(5) = K1 : PPCOEFF(6) = K2 : PPCOEFF(7) = K3 : PPCOEFF(8) = K4
        PPCOEFF(9) = Z1 : PPCOEFF(10) = Z2 : PPCOEFF(11) = Z3

        TCM = 0 : VCM = 0 : ZCM = 0 : OMM = 0 ' calcul des constantes
        For i = 1 To 65 : TCM = TCM + TC(i) * E365(i) : Next i ' pseudocritiques du
        For i = 1 To 65 : VCM = VCM + VC(i) * E365(i) : Next i ' melange
        For i = 1 To 65 : OMM = OMM + OM(i) * E365(i) : Next i ' methode de P. & G.
        For i = 1 To 65 : ZCM = ZCM + ZC(i) * E365(i) : Next i ' modifiee

        PCM = ZCM * 82.06 * TCM / VCM ' en ata
        XM = (TCM ^ 0.166667) / System.Math.Sqrt(PM) / (PCM ^ 0.666667) ' lettre grec KSI pour la viscosite

        'E3333(17) = 0:   E3333(18) = 0:   E3333(19) = XM:  E3333(20) = PCM: E3333(21) = PM
        'E3333(22) = TCM: E3333(23) = OMM: E3333(24) = VCM: E3333(25) = ZCM: E3333(26) = -999

        PPCOEFF(17) = VCM : PPCOEFF(18) = ZCM ' PPCOEFF(19) = PM (deja defini)
        PPCOEFF(20) = PCM : PPCOEFF(21) = XM : PPCOEFF(22) = TCM : PPCOEFF(23) = OMM

    End Function
    Private Function CalculCp(ByRef Temp As Single, ByRef Press As Single, ByRef FRACTIONmolaireN2 As Single, ByRef PPG As Short) As Single ' PPGSUB.BAS:CalculCp!  Revision 2 du 21/11/1996
        Dim Cp, T6, CPP As Single
        ' Temp(øC), Press(bar a), FRACTIONmolaireN2!, PPG%, PPCOEFF(), ppg1CpC0()
        ' PPG% = ASC(PPG$)   70=F 89=Y 90=Z 121=y 122=z
        ' variables locales : CP, CPP & T6
        If Config.Ippgas65 = 3 Then Exit Function
        If PPCOEFF(1) = 0 And PPCOEFF(4) = 0 And Config.Ippgas65 < 2 Then
            If Not Silente Then MsgBox("La composizione del gas non è stata correttamente definita", MsgBoxStyle.Critical)
            Exit Function
        End If
        If PPG = 70 Then ' "F"
            If Temp <= PPCOEFF(1) Then CalculCp = PPCOEFF(2) * Temp + PPCOEFF(3) : Exit Function
            If Temp >= PPCOEFF(4) Then CalculCp = PPCOEFF(7) * Temp + PPCOEFF(8) : Exit Function
            CalculCp = PPCOEFF(5) * Temp + PPCOEFF(6) : Exit Function ' en J/kgøC
        End If

        T6 = (Temp + 273.15) / 1000
        Cp = PPCOEFF(1) + PPCOEFF(2) * T6 + PPCOEFF(3) * T6 * T6 + PPCOEFF(4) * T6 * T6 * T6 ' en J/kgøC

        ' Fraction en masse de N2 = Fraction molaire de N2 * 28.02 / masse molaire m‚lange
        If T6 > 1.4 Then Cp = Cp + (225.3074 * T6 * T6 * T6 - 728.8922 * T6 * T6 + 755.7438 * T6 - 247.6586) * FRACTIONmolaireN2 * 28.02 / PPCOEFF(19) ' Cp du N2

        If PPG = 89 Or PPG = 90 Then CalculCp = Cp : Exit Function

        'PRM = Press * .98692 / PPCOEFF(20)   ' PPCOEFF(20)=PCM en ata
        'TRM = (Temp + 273.15) / PPCOEFF(22)  ' PPCOEFF(22)=TCM en øK

        CPP = CpCORRECTION(Press * 0.98692 / PPCOEFF(20), (Temp + 273.15) / PPCOEFF(22)) ' CPP = Isothermal press. correc. to Cp of vapors  ëCp kcal/kg-moleøC
        If PPCOEFF(19) = 0 Then Exit Function
        CalculCp = Cp + CalJ * CPP / 100 / PPCOEFF(19) ' en J/kgøC

    End Function
    Private Function CalculZ(ByRef PR As Single, ByRef TR As Single, ByRef ZZ(,) As Short, ByRef Erreur As String) As Single '                              PPGSUB.BAS:CalculZ Revision 1 du 12/12/1995
        'On Local Error Resume Next
        Dim i2, IZ1, iz2 As Short
        Dim Z3, Z5, Z4 As Single
        If TR < 0.8 Then Erreur = "La température réduite est < 0.8, le calcul de Z sera fait … 0.8" : TR = 0.8

        IZ1 = 1
        For i2 = 18 To 2 Step -1
            If 1000 * TR >= ZZ(1, i2) Then IZ1 = i2 : Exit For
        Next i2

        iz2 = 1
        For i2 = 22 To 2 Step -1
            If 1000 * PR >= ZZ(i2, 1) Then iz2 = i2 : Exit For
        Next i2

        ' 4 points (IZ2,IZ1),(IZ2+1,IZ1),(IZ2,IZ1+1)&(IZ2+1,IZ1+1)


        If IZ1 = 1 And iz2 = 1 Then Z5 = ZZ(2, 2) : GoTo ZFIN
        If IZ1 = 1 And iz2 = 22 Then Z5 = ZZ(22, 2) : GoTo ZFIN
        If IZ1 = 18 And iz2 = 1 Then Z5 = ZZ(2, 18) : GoTo ZFIN
        If IZ1 = 18 And iz2 = 22 Then Z5 = ZZ(22, 18) : GoTo ZFIN
        If IZ1 = 1 Then Z3 = ZZ(iz2, 2) : GoTo ZSUITE
        If IZ1 = 18 Then Z3 = ZZ(iz2, 18) : Z4 = ZZ(iz2 + 1, 18) : GoTo ZSUITE
        If iz2 = 1 Then
            Z5 = ((ZZ(1, IZ1 + 1) - 1000 * TR) * ZZ(2, IZ1) + (1000 * TR - ZZ(1, IZ1)) * ZZ(2, IZ1 + 1)) / (ZZ(1, IZ1 + 1) - ZZ(1, IZ1))
            GoTo ZFIN '   cas o— TR < ZZ% (2,1)
        End If

        Z3 = (ZZ(1, IZ1 + 1) - 1000 * TR) * ZZ(iz2, IZ1) + (1000 * TR - ZZ(1, IZ1)) * ZZ(iz2, IZ1 + 1)
        Z3 = Z3 / (ZZ(1, IZ1 + 1) - ZZ(1, IZ1)) ' = Z … IZ2(PR) et TR
        If iz2 = 22 Then Z5 = Z3 : GoTo ZFIN ' cas o— Z2 > ZZ% (22,1)

        Z4 = (ZZ(1, IZ1 + 1) - 1000 * TR) * ZZ(iz2 + 1, IZ1) + (1000 * TR - ZZ(1, IZ1)) * ZZ(iz2 + 1, IZ1 + 1)
        Z4 = Z4 / (ZZ(1, IZ1 + 1) - ZZ(1, IZ1)) ' = Z … IZ2+1 et TR

ZSUITE: Z5 = (ZZ(iz2 + 1, 1) - 1000 * PR) * Z3 + (1000 * PR - ZZ(iz2, 1)) * Z4
        Z5 = Z5 / (ZZ(iz2 + 1, 1) - ZZ(iz2, 1)) ' = Z … PR et TR

ZFIN:   IZ1 = 0 : iz2 = 0 : Z3 = 0 : Z4 = 0 : CalculZ = Z5 / 1000

    End Function
    Private Function ConducVisco(ByRef Temp As Single, ByRef Press As Single, ByRef PPG As Short, ByRef PTC As Single, ByRef PVC As Single) As Single '  PPGSUB.BAS:ConducVisco Revision 2 du 21/11/1996
        Dim T6, ZM As Single
        Dim Erreur As String = ""
        Dim VM, Zm0, ZM1, ZZZ As Single
        Dim KK As Single
        Dim JRM As Single
        ' PPG% = ASC(PPG$)  70=F 89=Y 90=Z 121=y 122=z

        If PPG = 70 And Temp <= PPCOEFF(9) Then PTC = PPCOEFF(10) * Temp + PPCOEFF(11) : GoTo CV2
        If PPG = 70 And Temp > PPCOEFF(9) Then PTC = PPCOEFF(12) * Temp + PPCOEFF(13) ' en W/møC

CV2:    If PPG = 70 And Temp <= PPCOEFF(14) Then PVC = PPCOEFF(15) * Temp + PPCOEFF(16) : Exit Function
        If PPG = 70 And Temp > PPCOEFF(14) Then PVC = PPCOEFF(17) * Temp + PPCOEFF(18) : Exit Function ' en kg/m.sec.

        T6 = (Temp + 273.15) / 1000
        PTC = PPCOEFF(5) + PPCOEFF(6) * T6 + PPCOEFF(7) * T6 * T6 + PPCOEFF(8) * T6 * T6 * T6 ' en W/møC
        PVC = PPCOEFF(9) + PPCOEFF(10) * T6 + PPCOEFF(11) * T6 * T6 '                          en kg/m.sec.

        If PPG = 89 Or PPG = 90 Then Exit Function

        ' reste les PPG% = 121 ou 122  soit donc y ou z
        If PPCOEFF(20) = 0 Then Exit Function
        PRM = Press * 0.98692 / PPCOEFF(20) ' PPCOEFF(20)=PCM en ata
        TRM = (Temp + 273.15) / PPCOEFF(22) ' PPCOEFF(22)=TCM en øK

        If PRM > 9 Then ZM = 1.1 + (PRM - 9) / (10 * TRM) : GoTo CV4
        If TRM > 3 And PRM < 1.2 Then ZM = 1 : GoTo CV4
        If TRM > 3 And PRM < 1.4 Then ZM = 1 + TRM / 2000 : GoTo CV4
        If TRM > 3.5 And PRM < 1.8 Then ZM = 1 + TRM / 1000 : GoTo CV4
        If TRM > 4 Then ZM = 1 + (TRM - 10) / 1000 : GoTo CV4

        Zm0 = CalculZ(PRM, TRM, ppg1ZZ0, Erreur)
        ZM1 = CalculZ(PRM, TRM, ppg1ZZ1, Erreur)
        ZM = Zm0 + PPCOEFF(23) * ZM1 '  corr‚lation de PITZER     PPCOEFF(23)=OMM

CV4:    VM = ZM * 83.14474 * (Temp + 273.15) / Press
        JRM = PPCOEFF(17) / VM ' PPCOEFF(17)=VCM

        ZZZ = 0.000108 * (System.Math.Exp(1.439 * JRM) - System.Math.Exp(-1.111 * (JRM ^ 1.858)))
        PVC = PVC + ZZZ / PPCOEFF(21) / 1000 '   PPCOEFF(21)=XM    ZZZ/PPCOEFF(21) est en centipoises

        Select Case JRM
            Case 0.000001 To 0.4984 : KK = 0.0000584 * (System.Math.Exp(0.535 * JRM) - 1)
            Case 0.4984 To 1.991 : KK = 0.0000545 * (System.Math.Exp(0.67 * JRM) - 1.069)
            Case 1.991 To 70 : KK = 0.0000124 * (System.Math.Exp(1.155 * JRM) + 2.016)
            Case Else : KK = 0 ' JRM > 70 entraine un d‚passement de capacit‚
        End Select

        ' Gamma = Mw * Xm   PPCOEFF(19) = Mw    PPCOEFF(21)=Xm   PPCOEFF(18) =Zcm
        PTC = PTC + KK / (PPCOEFF(19) * PPCOEFF(21) * PPCOEFF(18) * PPCOEFF(18) * PPCOEFF(18) * PPCOEFF(18) * PPCOEFF(18))

    End Function
    Private Function CpCORRECTION(ByRef PRM0 As Single, ByRef TRM0 As Single) As Single '                      PPGSUB.BAS:CpCORRECTION Revision 1 du 12/12/1995
        'On Local Error Resume Next
        Dim IPRM0, ITRM0, i2 As Short
        Dim CPC4, CpC3, CpC5 As Single
        IPRM0 = 1
        For i2 = 14 To 2 Step -1
            If 1000 * PRM0 >= ppg1CpC0(1, i2) Then IPRM0 = i2 : Exit For ' Pr‚duite
        Next i2

        ITRM0 = 1
        For i2 = 16 To 2 Step -1
            If 100 * TRM0 >= ppg1CpC0(i2, 1) Then ITRM0 = i2 : Exit For ' Tr‚duite
        Next i2

        '4 points (ITRM0,IPRM0),(ITRM0+1,IPRM0),(ITRM0,IPRM0+1)&(ITRM0+1,IPRM0+1)

        If IPRM0 = 1 And ITRM0 = 1 Then CpCORRECTION = ppg1CpC0(2, 2) : Exit Function
        If IPRM0 = 1 And ITRM0 = 16 Then CpCORRECTION = ppg1CpC0(16, 2) : Exit Function
        If IPRM0 = 14 And ITRM0 = 1 Then CpCORRECTION = ppg1CpC0(2, 14) : Exit Function
        If IPRM0 = 14 And ITRM0 = 16 Then CpCORRECTION = ppg1CpC0(16, 14) : Exit Function
        If IPRM0 = 1 Then CpC3 = ppg1CpC0(ITRM0, 2) : GoTo CPCSUITE
        If IPRM0 = 14 Then CpC3 = ppg1CpC0(ITRM0, 14) : CPC4 = ppg1CpC0(ITRM0 + 1, 14) : GoTo CPCSUITE
        If ITRM0 = 1 Then
            CpCORRECTION = ((ppg1CpC0(1, IPRM0 + 1) - 1000 * PRM0) * ppg1CpC0(2, IPRM0) + (1000 * PRM0 - ppg1CpC0(1, IPRM0)) * ppg1CpC0(2, IPRM0 + 1)) / (ppg1CpC0(1, IPRM0 + 1) - ppg1CpC0(1, IPRM0))
            Exit Function '    cas o— TRM0 < ppg1CpC0 (2,1)
        End If

        CpC3 = (ppg1CpC0(1, IPRM0 + 1) - 1000 * PRM0) * ppg1CpC0(ITRM0, IPRM0) + (1000 * PRM0 - ppg1CpC0(1, IPRM0)) * ppg1CpC0(ITRM0, IPRM0 + 1)
        CpC3 = CpC3 / (ppg1CpC0(1, IPRM0 + 1) - ppg1CpC0(1, IPRM0)) ' = CPC … ITRM0 et PRM0
        If ITRM0 = 16 Then CpCORRECTION = CpC3 : Exit Function ' cas o— TRM0 < ppg1CpC0 (16,1)

        CPC4 = (ppg1CpC0(1, IPRM0 + 1) - 1000 * PRM0) * ppg1CpC0(ITRM0 + 1, IPRM0) + (1000 * PRM0 - ppg1CpC0(1, IPRM0)) * ppg1CpC0(ITRM0 + 1, IPRM0 + 1)
        CPC4 = CPC4 / (ppg1CpC0(1, IPRM0 + 1) - ppg1CpC0(1, IPRM0)) ' = CPC … ITRM0+1 et PRM0

CPCSUITE: CpC5 = (ppg1CpC0(ITRM0 + 1, 1) - 100 * TRM0) * CpC3 + (100 * TRM0 - ppg1CpC0(ITRM0, 1)) * CPC4
        CpCORRECTION = CpC5 / (ppg1CpC0(ITRM0 + 1, 1) - ppg1CpC0(ITRM0, 1)) ' = CPC … TRM0 et PRM0

    End Function
    Public Sub Apri()
        Dim ifl, i As Short
        Gia = False
        If Acqua Then
            Config.iUnit = 2
            Config.Ippgas65 = 0
            PPCOEFF(19) = 18.02
            ppg1E3(2) = 1
            Exit Sub
        End If
        If FileData = "" Then Exit Sub
        ifl = FreeFile()
        FileOpen(ifl, FileData, OpenMode.Binary)
        If LOF(ifl) = 0 Then FileClose(ifl) : Exit Sub
        FileGet(ifl, Problem)
        If Problem.Version = 1 Then
            With Monitor.Motore.Problem
                .ClientPlant = Problem.ClientPlant
                .Commessa = Problem.Commessa
                .Item = Problem.Item
                .Author = Problem.Author
            End With
            FileGet(ifl, Config)
            PPCOEFF(19) = Config.PesoMoc
            Select Case Config.Ippgas65
                Case 0
                    For i = 1 To 16
                        FileGet(ifl, ppg1E2(i))
                        FileGet(ifl, ppg1E3(i))
                    Next
                Case 1
                    For i = 1 To 65
                        FileGet(ifl, E265(i))
                        FileGet(ifl, E365(i))
                    Next
                Case 2
                    For i = 1 To 26
                        FileGet(ifl, E365(i))
                    Next
                Case 3
            End Select
        End If
        FileClose(ifl)
        If Not mioApert Is Nothing Then
            mioApert.Aggiorna()
        End If
    End Sub
    Public Sub Iniziamono65(ByVal codice As Integer)
        Dim i As Integer
        prIppgas65 = 1
        For i = 1 To 65
            Ris(i) = False
        Next
        Ris(codice) = True
        E365(codice) = 1
        PostSelezione(False)
    End Sub
    Public Sub IniziaAria()
        Dim i As Integer
        prIppgas65 = 1
        For i = 1 To 65
            Ris(i) = False
        Next
        Ris(2) = True
        Ris(3) = True
        E365(2) = 80
        E365(1) = 20
        PostSelezione(False)
    End Sub
    Public Sub SelezioneMiscela(ByRef mostra As Boolean)
        Dim Strin(65) As String
        Dim Titolo As String
        Dim Ninput, i As Short
        If Gia Then Exit Sub
        Gia = True
        Titolo = "Selezione dei componenti della miscela"
        Select Case Config.Ippgas65
            Case 0
                Ninput = 16
                For i = 1 To Ninput
                    Strin(i) = ppg1E1(i)
                    Ris(i) = ppg1E3(i) > 0
                Next
            Case 1
                Ninput = 65
                For i = 1 To Ninput
                    Strin(i) = E165(i, 1) & " " & E165(i, 2)
                    Ris(i) = E365(i) > 0
                Next
        End Select
        If mostra Then
            If Not Monitor.Motore.CheckQuale(Ninput, Titolo, Strin, Ris, "") Then Exit Sub
        End If
        PostSelezione(mostra)
    End Sub
    Public Sub Calcola(ByRef iErr As Short)
        Dim Ninput As Short
        Dim tit, Testo As String
        Dim Strin(4) As String
        Dim LogoFile As String
        SelezioneMiscela(False)
        If Config.Pressione <= 0 Then
            Call Warn1() : iErr = 1 : Exit Sub
        End If
        '?????????????????????????????????????????????
        'PPCOEFF(19) = 10
        '?????????????????????????????????????????????
        TCM = PPCOEFF(22)
        PCM = PPCOEFF(20)
        PRM = Config.Pressione * 0.98692 / PCM

        Config.idewpoint = 1
        If ppg1E3(12) + ppg1E3(13) = 0 Then Config.idewpoint = 0 : GoTo 920
        If ppg1E3(2) = 0 Then Config.idewpoint = 0 : GoTo 920
        tit = "POINT DE ROSEE ACIDE  (H2SO4)"
        Testo = "Les fumées contenant du SO2 et/ou du SO3, " & vbCrLf
        Testo = Testo & "un calcul du point de rosée acide peut etre effectué." & vbCrLf
        Testo = Testo & "  Quale opzione scegli?"
        Strin(1) = "Ce calcul doit etre inclus avec celui des propriétés physiques"
        Strin(2) = "Ce calcul doit etre séparé de celui des propriétés physiques"
        Strin(3) = "On ne veut pas de calcul du point de rosée acide (H2SO4)"
        Strin(4) = "On veut uniquement le calcul du point de rosée acide (H2SO4)"
        Ninput = 4
        Config.idewpoint = Monitor.Motore.Quale(Ninput, tit, Strin, "", Config.idewpoint, Testo)

        If Config.idewpoint < 1 Or Config.idewpoint > 4 Then Beep() : Exit Sub

        If Config.idewpoint = 4 Then
            StampaRugiada()
            Exit Sub
        End If
920:
        If Config.Tmin < -100 Then
            Call Warn() : Exit Sub
        End If
        If Config.Tmax <= Config.Tmin Then
            Call Warn() : Exit Sub
        End If
        If Config.Tincr <= 0 Then
            Call Warn() : Exit Sub
        End If
        If FileStam = "" Then
            FileStam = Left(FileData, Len(FileData) - 4) & "PPS.DOC"
        End If
        LogoFile = Monitor.Motore.Inizio.Archdir & "\" & Monitor.Motore.Inizio.ReadIniFile("", "Azienda", "Logo")
        If Monitor.Motore.Inizio.VersOffice < 11 Then
            Stub9 = New StubW9.clsSW9
            Stub9.SuperStampa(Monitor.Motore.Inizio.Archdir & "\PPGAS.DOC", Monitor.Motore.Inizio.VersOffice)
            If Stub9 Is Nothing Then Exit Sub
            Stub9.sSaveAs(FileStam)
            Stub9.IntestLogo(LogoFile)
            StampaRugiada()
            Testata(Stub9)
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
            StampaCorpo(Stub9)
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        Else
            Stub = New StubW2000.clsSW2000
            Stub.SuperStampa(Monitor.Motore.Inizio.Archdir & "\PPGAS.DOC", Monitor.Motore.Inizio.VersOffice)
            If Stub Is Nothing Then Exit Sub
            Stub.sSaveAs(FileStam)
            Stub.IntestLogo(LogoFile)
            StampaRugiada()
            Testata(Stub)
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
            StampaCorpo(Stub)
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        End If
    End Sub
    Private Sub Warn()
        MsgBox("L'intervallo di temperature per la redazione del rapporto non è definito correttamente", MsgBoxStyle.Critical)
    End Sub
    Private Sub Warn1()
        MsgBox("La pressione per la redazione del rapporto non è definita", MsgBoxStyle.Critical)
    End Sub
    Private Overloads Sub FinePagina(ByRef Stub As StubW2000.clsSW2000)
        Stub.VaiInizio("Autore")
        If Len(Monitor.Motore.Problem.Author) = 0 Then
            Monitor.Motore.Problem.Author = Monitor.Motore.Inizio.DBFdir
        ElseIf Asc(Monitor.Motore.Problem.Author) < 32 Then
            Monitor.Motore.Problem.Author = Monitor.Motore.Inizio.DBFdir
        End If
        Stub.FinPag(Monitor.Motore.Problem.Author)
    End Sub
    Private Overloads Sub FinePagina(ByRef Stub As StubW9.clsSW9)
        Stub.VaiInizio("Autore")
        If Len(Monitor.Motore.Problem.Author) = 0 Then
            Monitor.Motore.Problem.Author = Monitor.Motore.Inizio.DBFdir
        ElseIf Asc(Monitor.Motore.Problem.Author) < 32 Then
            Monitor.Motore.Problem.Author = Monitor.Motore.Inizio.DBFdir
        End If
        Stub.FinPag(Monitor.Motore.Problem.Author)
    End Sub
    Private Overloads Sub Testata(ByRef Stub As StubW2000.clsSW2000)
        Dim i As Short
        Dim strKCO As String
        Dim KCO As Single
        Dim TTSAT, P As Single
        Stub.VaiInizio("Programma")
        Stub.Testo(Monitor.Motore.About.ProgName & " " & Monitor.Motore.About.ProgVers)
        Stub.VaiInizio("Gas")
        Stub.Testo(Trim(Problem.Fluido))
        Stub.VaiInizio("Job")
        Stub.Testo(Monitor.Motore.Inizio.CommPulita(FileData))
        Stub.VaiInizio("Tab1")
        Stub.MuoviCella(-1)
        Select Case Config.Ippgas65
            Case 1
                For i = 1 To 65
                    If E365(i) > 0 Then
                        With Stub 'Selection
                            .LibMatDestra()
                            .Testo(Trim(Str(i)))
                            .MuoviCella(1)
                            .Testo(E165(i, 1))
                            .MuoviCella(1)
                            .Testo(E165(i, 2))
                            .MuoviCella(1)
                            .Testo(Trim(Funzioni.myStr(E365(i) * 100, 3, 2, False)))
                            .MuoviCella(1)
                            .Testo(Trim(Funzioni.myStr(E365(i) * E265(i) / PPCOEFF(19) * 100, 3, 2, False)))
                        End With
                        'Print #iout, FormatS("##    \                   \ \          \ :     ###.###        ###.###     *", i, E165$(i, 1), E165$(i, 2), E365(i) * 100, E365(i) * E265(i) / PPCOEFF(19) * 100)
                    End If
                    'M1 = M1 + E365(i): M2 = M2 + E365(i) * E265(i)
                Next i
                'Print #iout, FormatS("                      TOTAL              :     ###.###        ###.###     *", M1 * 100, M2 / PPCOEFF(19) * 100)
            Case 0
                'M1 = 0: M2 = 0
                'Print #iout, "               COMPOSITION     POURCENT VOLUME   POURCENT POIDS           *"
                'Print #iout, ""
                For i = 1 To 16
                    If ppg1E3(i) > 0 Then
                        With Stub 'Selection
                            .LibMatDestra()
                            .Testo(Trim(Str(i)))
                            .MuoviCella(1)
                            .Testo(ppg1E1(i))
                            .MuoviCella(1)
                            .Testo("") 'E165(i, 2)
                            .MuoviCella(1)
                            .Testo(Trim(Funzioni.myStr(ppg1E3(i) * 100, 3, 2, False)))
                            .MuoviCella(1)
                            .Testo(Trim(Funzioni.myStr(ppg1E3(i) * ppg1E2(i) / PPCOEFF(19) * 100, 3, 2, False)))
                        End With
                        'Print #iout, FormatS("                 \  \     :         ###.###       ###.###                 *", ppg1E1(i), ppg1E3(i) * 100, ppg1E3(i) * ppg1E2(i) / PPCOEFF(19) * 100)
                    End If
                    'M1 = M1 + ppg1E3(i): M2 = M2 + ppg1E3(i) * ppg1E2(i)
                Next i
                '  Print #iout, FormatS("                 TOTAL    :         ###.###       ###.###                 *", M1 * 100, M2 / PPCOEFF(19) * 100)
            Case 2, 3
                With Stub
                    .LibMatDestra()
                    .Testo("N.A.")
                    .MuoviCella(1)
                    .Testo("N.A.")
                    .MuoviCella(1)
                    .Testo("N.A.")
                    .MuoviCella(1)
                    .Testo("N.A.")
                    .MuoviCella(1)
                    .Testo("N.A.")
                End With
        End Select
        '***(200)********************************************************************************************************************** PPGAS165.BAS
        If Config.Ippgas65 > 1 Then Exit Sub
        Stub.VaiInizio("Tab2", , True)
        With Stub 'Selection
            .Testo(Trim(Funzioni.myStr(PPCOEFF(19), 4, 2, False)))
            .MuoviLinea(1)
            .Testo(Trim(Funzioni.myStr(TCM, 4, 2, False)))
            .MuoviLinea(1)
            .Testo(Trim(Funzioni.myStr(PPCOEFF(17), 4, 2, False)))
            .MuoviLinea(1)
            .Testo(Trim(Funzioni.myStr(PPCOEFF(17) / PPCOEFF(19) / 1000, 5, 5, False)))
            .MuoviLinea(1)
            .Testo(Trim(Funzioni.myStr(1 / (PPCOEFF(17) / PPCOEFF(19) / 1000), 5, 2, False)))
            .MuoviLinea(1)
            .Testo(Trim(Funzioni.myStr(PPCOEFF(18), 5, 3, False)))
            .MuoviLinea(1)
            .Testo(Trim(Funzioni.myStr(PCM * 1.01325, 5, 2, False)))
            .MuoviLinea(1)
            .Testo(Trim(Funzioni.myStr(Config.Pressione, 5, 4, False)))
            .MuoviLinea(1)
            .Testo(Trim(Funzioni.myStr(PRM, 5, 4, False)))
            'Print #iout, ""
            'Print #iout, FormatS(" MASSE MOLAIRE                    #######.####     kg/kmole               *", PPCOEFF(19))
            'Print #iout, FormatS(" TEMPERATURE CRITIQUE              #########.#     K                      *", TCM)
            'Print #iout, FormatS(" VOLUME CRITIQUE                   ########.##     cm3/g-mole             *", PPCOEFF(17))
            'Print #iout, FormatS(" VOLUME CRITIQUE            ###########.######     m3/kg                  *", PPCOEFF(17) / PPCOEFF(19) / 1000)
            'Print #iout, FormatS(" DENSITE CRITIQUE                  ########.##     kg/m3                  *", 1000 * PPCOEFF(19) / PPCOEFF(17))
            'Print #iout, FormatS(" FACTEUR DE COMPRESSIBILITE CRITIQUE #####.###                            *", PPCOEFF(18))
            'Print #iout, FormatS(" PRESSION CRITIQUE ABSOLUE         ########.##     bar                    *", PCM * 1.01325)
            'Print #iout, FormatS(" PRESSION ABSOLUE DU GAZ    ############.#####     bar                    *", Config.Pressione)
            'Print #iout, FormatS(" PRESSION REDUITE DU GAZ    ############.#####                            *", PRM)

            If Config.Pressione * ppg1E3(2) < 0.03 Or Config.Pressione * ppg1E3(2) > 105 Then
                TSAT = 0
                .sMoveDown()
                .sTypeText("--")
                .sTypeText("--")
            Else
                P = Config.Pressione * ppg1E3(2) * 14.504
                TTSAT = -0.17724 * P + 3.83986 / P + 11.48345 * System.Math.Sqrt(P) + 31.1311 * System.Math.Log(P) + 0.00008762969 * P * P - 0.0000000278794 * P * P * P + 86.594
                TSAT = 5 / 9 * (TTSAT - 32)
                .sMoveDown()
                .sTypeText(Trim(Funzioni.myStr(Config.Pressione * ppg1E3(2), 5, 4, False)))
                .sTypeText(Trim(Funzioni.myStr(TSAT, 5, 1, False)))
            End If
            .sTypeText(Trim(Funzioni.myStr(PPCOEFF(23), 5, 4, False)))
            .sTypeText(Trim(Funzioni.myStr(PPCOEFF(23) / 0.203 + 5.80788, 5, 4, False)))
            .sTypeText(Trim(Funzioni.myStr(PPCOEFF(21), 5, 4, False)))
            .sTypeText(Trim(Funzioni.myStr(PPCOEFF(21) * PPCOEFF(19), 5, 4, False)), False)
            KCO = Kactivity()
            If KCO = 0 Then strKCO = "N.A." Else strKCO = Funzioni.myStr(1 / KCO, 4, 2, False)
            .sTypeText(strKCO, True)
        End With
    End Sub
    Private Overloads Sub Testata(ByRef Stub As StubW9.clsSW9)
        Dim i As Short
        Dim strKCO As String
        Dim KCO As Single
        Dim TTSAT, P As Single
        Stub.VaiInizio("Programma")
        Stub.Testo(Monitor.Motore.About.ProgName & " " & Monitor.Motore.About.ProgVers)
        Stub.VaiInizio("Gas")
        Stub.Testo(Trim(Problem.Fluido))
        Stub.VaiInizio("Job")
        Stub.Testo(Monitor.Motore.Inizio.CommPulita(FileData))
        Stub.VaiInizio("Tab1")
        Stub.MuoviCella(-1)
        Select Case Config.Ippgas65
            Case 1
                For i = 1 To 65
                    If E365(i) > 0 Then
                        With Stub 'Selection
                            .LibMatDestra()
                            .Testo(Trim(Str(i)))
                            .MuoviCella(1)
                            .Testo(E165(i, 1))
                            .MuoviCella(1)
                            .Testo(E165(i, 2))
                            .MuoviCella(1)
                            .Testo(Trim(Funzioni.myStr(E365(i) * 100, 3, 2, False)))
                            .MuoviCella(1)
                            .Testo(Trim(Funzioni.myStr(E365(i) * E265(i) / PPCOEFF(19) * 100, 3, 2, False)))
                        End With
                        'Print #iout, FormatS("##    \                   \ \          \ :     ###.###        ###.###     *", i, E165$(i, 1), E165$(i, 2), E365(i) * 100, E365(i) * E265(i) / PPCOEFF(19) * 100)
                    End If
                    'M1 = M1 + E365(i): M2 = M2 + E365(i) * E265(i)
                Next i
                'Print #iout, FormatS("                      TOTAL              :     ###.###        ###.###     *", M1 * 100, M2 / PPCOEFF(19) * 100)
            Case 0
                'M1 = 0: M2 = 0
                'Print #iout, "               COMPOSITION     POURCENT VOLUME   POURCENT POIDS           *"
                'Print #iout, ""
                For i = 1 To 16
                    If ppg1E3(i) > 0 Then
                        With Stub 'Selection
                            .LibMatDestra()
                            .Testo(Trim(Str(i)))
                            .MuoviCella(1)
                            .Testo(ppg1E1(i))
                            .MuoviCella(1)
                            .Testo("") 'E165(i, 2)
                            .MuoviCella(1)
                            .Testo(Trim(Funzioni.myStr(ppg1E3(i) * 100, 3, 2, False)))
                            .MuoviCella(1)
                            .Testo(Trim(Funzioni.myStr(ppg1E3(i) * ppg1E2(i) / PPCOEFF(19) * 100, 3, 2, False)))
                        End With
                        'Print #iout, FormatS("                 \  \     :         ###.###       ###.###                 *", ppg1E1(i), ppg1E3(i) * 100, ppg1E3(i) * ppg1E2(i) / PPCOEFF(19) * 100)
                    End If
                    'M1 = M1 + ppg1E3(i): M2 = M2 + ppg1E3(i) * ppg1E2(i)
                Next i
                '  Print #iout, FormatS("                 TOTAL    :         ###.###       ###.###                 *", M1 * 100, M2 / PPCOEFF(19) * 100)
            Case 2, 3
                With Stub
                    .LibMatDestra()
                    .Testo("N.A.")
                    .MuoviCella(1)
                    .Testo("N.A.")
                    .MuoviCella(1)
                    .Testo("N.A.")
                    .MuoviCella(1)
                    .Testo("N.A.")
                    .MuoviCella(1)
                    .Testo("N.A.")
                End With
        End Select
        '***(200)********************************************************************************************************************** PPGAS165.BAS
        If Config.Ippgas65 > 1 Then Exit Sub
        Stub.VaiInizio("Tab2", , True)
        With Stub 'Selection
            .Testo(Trim(Funzioni.myStr(PPCOEFF(19), 4, 2, False)))
            .MuoviLinea(1)
            .Testo(Trim(Funzioni.myStr(TCM, 4, 2, False)))
            .MuoviLinea(1)
            .Testo(Trim(Funzioni.myStr(PPCOEFF(17), 4, 2, False)))
            .MuoviLinea(1)
            .Testo(Trim(Funzioni.myStr(PPCOEFF(17) / PPCOEFF(19) / 1000, 5, 5, False)))
            .MuoviLinea(1)
            .Testo(Trim(Funzioni.myStr(1 / (PPCOEFF(17) / PPCOEFF(19) / 1000), 5, 2, False)))
            .MuoviLinea(1)
            .Testo(Trim(Funzioni.myStr(PPCOEFF(18), 5, 3, False)))
            .MuoviLinea(1)
            .Testo(Trim(Funzioni.myStr(PCM * 1.01325, 5, 2, False)))
            .MuoviLinea(1)
            .Testo(Trim(Funzioni.myStr(Config.Pressione, 5, 4, False)))
            .MuoviLinea(1)
            .Testo(Trim(Funzioni.myStr(PRM, 5, 4, False)))
            'Print #iout, ""
            'Print #iout, FormatS(" MASSE MOLAIRE                    #######.####     kg/kmole               *", PPCOEFF(19))
            'Print #iout, FormatS(" TEMPERATURE CRITIQUE              #########.#     K                      *", TCM)
            'Print #iout, FormatS(" VOLUME CRITIQUE                   ########.##     cm3/g-mole             *", PPCOEFF(17))
            'Print #iout, FormatS(" VOLUME CRITIQUE            ###########.######     m3/kg                  *", PPCOEFF(17) / PPCOEFF(19) / 1000)
            'Print #iout, FormatS(" DENSITE CRITIQUE                  ########.##     kg/m3                  *", 1000 * PPCOEFF(19) / PPCOEFF(17))
            'Print #iout, FormatS(" FACTEUR DE COMPRESSIBILITE CRITIQUE #####.###                            *", PPCOEFF(18))
            'Print #iout, FormatS(" PRESSION CRITIQUE ABSOLUE         ########.##     bar                    *", PCM * 1.01325)
            'Print #iout, FormatS(" PRESSION ABSOLUE DU GAZ    ############.#####     bar                    *", Config.Pressione)
            'Print #iout, FormatS(" PRESSION REDUITE DU GAZ    ############.#####                            *", PRM)

            If Config.Pressione * ppg1E3(2) < 0.03 Or Config.Pressione * ppg1E3(2) > 105 Then
                TSAT = 0
                .sMoveDown()
                .sTypeText("--")
                .sTypeText("--")
            Else
                P = Config.Pressione * ppg1E3(2) * 14.504
                TTSAT = -0.17724 * P + 3.83986 / P + 11.48345 * System.Math.Sqrt(P) + 31.1311 * System.Math.Log(P) + 0.00008762969 * P * P - 0.0000000278794 * P * P * P + 86.594
                TSAT = 5 / 9 * (TTSAT - 32)
                .sMoveDown()
                .sTypeText(Trim(Funzioni.myStr(Config.Pressione * ppg1E3(2), 5, 4, False)))
                .sTypeText(Trim(Funzioni.myStr(TSAT, 5, 1, False)))
            End If
            .sTypeText(Trim(Funzioni.myStr(PPCOEFF(23), 5, 4, False)))
            .sTypeText(Trim(Funzioni.myStr(PPCOEFF(23) / 0.203 + 5.80788, 5, 4, False)))
            .sTypeText(Trim(Funzioni.myStr(PPCOEFF(21), 5, 4, False)))
            .sTypeText(Trim(Funzioni.myStr(PPCOEFF(21) * PPCOEFF(19), 5, 4, False)), False)
            KCO = Kactivity()
            If KCO = 0 Then strKCO = "N.A." Else strKCO = Funzioni.myStr(1 / KCO, 4, 2, False)
            .sTypeText(strKCO, True)
        End With
    End Sub
    Private Sub StampaRugiada()
        If Config.idewpoint = 2 Or Config.idewpoint = 4 Then
            If Monitor.Motore.Inizio.VersOffice < 11 Then
                StubAcid9 = New StubW9.clsSW9
                StubAcid9.SuperStampa(Monitor.Motore.Inizio.Archdir & "\PPGAR.DOC", Monitor.Motore.Inizio.VersOffice)
                With StubAcid9
                    .sSaveAs(FileStam)
                    .VaiInizio("Programma")
                    .Testo(Monitor.Motore.About.ProgName & " " & Monitor.Motore.About.ProgVers)
                    .VaiInizio("Gas")
                    .Testo(": " & Trim(Problem.Fluido))
                    .VaiInizio("Job")
                    .Testo(Monitor.Motore.Inizio.CommPulita(FileData))
                End With
                Call ACIDEWCOMPLET(Config.Pressione, ppg1E3(2) * 100, ppg1E3(12) * 100, _
                      ppg1E3(13) * 100, ppg1E3(9) * 100, StubAcid9)
            Else
                StubAcid = New StubW2000.clsSW2000
                StubAcid.SuperStampa(Monitor.Motore.Inizio.Archdir & "\PPGAR.DOC", Monitor.Motore.Inizio.VersOffice)
                With StubAcid
                    .sSaveAs(FileStam)
                    .VaiInizio("Programma")
                    .Testo(Monitor.Motore.About.ProgName & " " & Monitor.Motore.About.ProgVers)
                    .VaiInizio("Gas")
                    .Testo(": " & Trim(Problem.Fluido))
                    .VaiInizio("Job")
                    .Testo(Monitor.Motore.Inizio.CommPulita(FileData))
                End With
                Call ACIDEWCOMPLET(Config.Pressione, ppg1E3(2) * 100, ppg1E3(12) * 100, _
                      ppg1E3(13) * 100, ppg1E3(9) * 100, StubAcid)
            End If
        End If
    End Sub
    Private Overloads Sub StampaCorpo(ByVal Stub As StubW2000.clsSW2000)
        Dim t As Single
        Dim C0, C0P As Single
        Dim K0P, K0, Z0, Z0P As Single
        Dim Prandint, Prandext As Single
        Dim PrandintP, PrandextP As Single
        Dim PRANDTLcoeffINT, PRANDTLcoeffEXT As Single
        Dim E365NONASME As Single
        Dim i As Short
        Dim CP1, CP0, CP2 As Single
        Dim CP22, CP3, CP33, CP11 As Single
        Dim CP00, ENTN2 As Single
        Dim ENTHALSI, ENTHAL, ENTHAL0, ENTHALP As Single
        Dim Temp, T6, HE0, HE As Single
        Dim Testo As String
        Stub.VaiInizio("Tab3")
        With Stub ' Selection
            Select Case Config.iUnit
                Case 1
                    .Testo("°C")
                    .MuoviCella(1)
                    .Testo("cm3/mole")
                    .MuoviCella(2)
                    .Testo("kCal/kg°C")
                    .MuoviCella(1)
                    .Testo("kCal/hr.m.°C")
                    .MuoviCella(1)
                    .Testo("cP")
                Case 2
                    .Testo("°C")
                    .MuoviCella(1)
                    .Testo("cm3/mole")
                    .MuoviCella(2)
                    .Testo("j/kg°C")
                    .MuoviCella(1)
                    .Testo("w/m°C")
                    .MuoviCella(1)
                    .Testo("kg/m.s")
                Case 3
                    .Testo("°C")
                    .MuoviCella(1)
                    .Testo("cm3/mole")
                    .MuoviCella(2)
                    .Testo("kCal/kg°C")
                    .MuoviCella(1)
                    .Testo("BTU/hr.ft.°F")
                    .MuoviCella(1)
                    .Testo("cP")
            End Select
        End With
        Stub.VaiInizio("Tab3", , True)
        With Stub 'Selection
            .MuoviLinea(2)
            .MuoviCella(-1)
1300:       For t = Config.Tmin To Config.Tmax Step Config.Tincr

                Erreur = "" ': Print T,
                If Config.Ippgas65 = 2 Then
                    C0 = CalculCp(t, Config.Pressione, E34, 70)
                    C0P = CalculCp(t, Config.Pressione, E34, 70)
                    Call ConducVisco(t, Config.Pressione, 70, K0, Z0)
                    Call ConducVisco(t, Config.Pressione, 70, K0P, Z0P)
                ElseIf Config.Ippgas65 = 3 Then
                    Stop
                Else
                    C0 = CalculCp(t, Config.Pressione, E34, 89)
                    C0P = CalculCp(t, Config.Pressione, E34, 121)
                    'TCM = PPCOEFF(20): PCM = PPCOEFF(22) 'aggiunto da LP (non necessario?)
                    Call ConducVisco(t, Config.Pressione, 89, K0, Z0)
                    Call ConducVisco(t, Config.Pressione, 121, K0P, Z0P)
                End If

                Prandint = (C0 ^ 0.42) * (K0 ^ 0.58) / (Z0 ^ 0.37)
                Prandext = (C0 ^ 0.333) * (K0 ^ 0.667) / (Z0 ^ 0.328)
                PrandintP = (C0P ^ 0.42) * (K0P ^ 0.58) / (Z0P ^ 0.37)
                PrandextP = (C0P ^ 0.333) * (K0P ^ 0.667) / (Z0P ^ 0.328)
                CalcDensity(t, Config.Pressione)
                .LibMatDestra()
                .Testo(Trim(Funzioni.myStr(t, 4, 0, False)))
                .MuoviCella(1)
                .Testo(Trim(Funzioni.myStr(VM, 6, 0, False)))
                .MuoviCella(1)
                .Testo(Trim(Funzioni.myStr(ZM, 2, 3, False)))
                Select Case Config.iUnit
                    Case 1 'Print #iout, FormatS("##.#### ##.#### #.##### #.##### #.####### #.####### ", C0 / 4185.5, C0P / 4185.5, K0 * 0.86011, K0P * 0.86011, Z0 * 1000, Z0P * 1000);
                        .MuoviCella(1)
                        .Testo(Trim(Funzioni.myStr(C0 / CalJ, 2, 4, False)))
                        .MuoviCella(1)
                        .Testo(Trim(Funzioni.myStr(C0P / CalJ, 2, 4, False)))
                        .MuoviCella(1)
                        .Testo(Trim(Funzioni.myStr(K0 * kgmscp, 1, 5, False)))
                        .MuoviCella(1)
                        .Testo(Trim(Funzioni.myStr(K0P * kgmscp, 1, 5, False)))
                        .MuoviCella(1)
                        .Testo(Trim(Funzioni.myStr(Z0 * 1000, 1, 7, False)))
                        .MuoviCella(1)
                        .Testo(Trim(Funzioni.myStr(Z0P * 1000, 1, 7, False)))
                        PRANDTLcoeffINT = (kgmscp ^ 0.58) / (CalJ ^ 0.42) / (1000 ^ 0.37)
                        PRANDTLcoeffEXT = (kgmscp ^ 0.667) / (CalJ ^ 0.333) / (1000 ^ 0.328)
                        .MuoviCella(1)
                        .Testo(Trim(Funzioni.myStr(Prandint * PRANDTLcoeffINT, 3, 4, False)))
                        .MuoviCella(1)
                        .Testo(Trim(Funzioni.myStr(PrandintP * PRANDTLcoeffINT, 3, 4, False)))
                        .MuoviCella(1)
                        .Testo(Trim(Funzioni.myStr(Prandext * PRANDTLcoeffEXT, 3, 4, False)))
                        .MuoviCella(1)
                        .Testo(Trim(Funzioni.myStr(PrandextP * PRANDTLcoeffEXT, 3, 4, False)))
                        .MuoviCella(1)
                        .Testo(Trim(Funzioni.myStr(Density, 4, 3, False)))
                        .MuoviCella(1)
                        .Testo(Trim(Funzioni.myStr(DensityP, 4, 3, False)))
                    Case 2 'Print #iout, FormatS("#####.# #####.# #.##### #.##### #.####^^^^ #.####^^^^ ", C0, C0P, K0, K0P, Z0, Z0P);
                        .MuoviCella(1)
                        .Testo(Trim(Funzioni.myStr(C0, 4, 1, False)))
                        .MuoviCella(1)
                        .Testo(Trim(Funzioni.myStr(C0P, 4, 1, False)))
                        .MuoviCella(1)
                        .Testo(Trim(Funzioni.myStr(K0, 1, 5, False)))
                        .MuoviCella(1)
                        .Testo(Trim(Funzioni.myStr(K0P, 1, 5, False)))
                        .MuoviCella(1)
                        .Testo(Trim(Microsoft.VisualBasic.Strings.Format(Z0, FormSci)))
                        .MuoviCella(1)
                        .Testo(Trim(Microsoft.VisualBasic.Strings.Format(Z0P, FormSci)))
                        .MuoviCella(1)
                        .Testo(Trim(Funzioni.myStr(Prandint, 3, 4, False)))
                        .MuoviCella(1)
                        .Testo(Trim(Funzioni.myStr(PrandintP, 3, 4, False)))
                        .MuoviCella(1)
                        .Testo(Trim(Funzioni.myStr(Prandext, 3, 4, False)))
                        .MuoviCella(1)
                        .Testo(Trim(Funzioni.myStr(PrandextP, 3, 4, False)))
                        .MuoviCella(1)
                        .Testo(Trim(Funzioni.myStr(Density, 4, 3, False)))
                        .MuoviCella(1)
                        .Testo(Trim(Funzioni.myStr(DensityP, 4, 3, False)))
                    Case 3 'Print #iout, FormatS("##.#### ##.#### #.##### #.##### #.####### #.####### ", C0 / 4185.5, C0P / 4185.5, K0 * 0.57779, K0P * 0.57779, Z0 * 1000, Z0P * 1000);
                        .MuoviCella(1)
                        .Testo(Trim(Funzioni.myStr(C0 / CalJ, 2, 4, False)))
                        .MuoviCella(1)
                        .Testo(Trim(Funzioni.myStr(C0P / CalJ, 2, 4, False)))
                        .MuoviCella(1)
                        .Testo(Trim(Funzioni.myStr(K0 * kgmsB, 1, 5, False)))
                        .MuoviCella(1)
                        .Testo(Trim(Funzioni.myStr(K0P * kgmsB, 1, 5, False)))
                        .MuoviCella(1)
                        .Testo(Trim(Funzioni.myStr(Z0 * 1000, 1, 7, False)))
                        .MuoviCella(1)
                        .Testo(Trim(Funzioni.myStr(Z0P * 1000, 1, 7, False)))
                        PRANDTLcoeffINT = (kgmsB ^ 0.58) / (CalJ ^ 0.42) / (1000 ^ 0.37)
                        PRANDTLcoeffEXT = (kgmsB ^ 0.667) / (CalJ ^ 0.333) / (1000 ^ 0.328)
                        .MuoviCella(1)
                        .Testo(Trim(Funzioni.myStr(Prandint * PRANDTLcoeffINT, 3, 4, False)))
                        .MuoviCella(1)
                        .Testo(Trim(Funzioni.myStr(PrandintP * PRANDTLcoeffINT, 3, 4, False)))
                        .MuoviCella(1)
                        .Testo(Trim(Funzioni.myStr(Prandext * PRANDTLcoeffEXT, 3, 4, False)))
                        .MuoviCella(1)
                        .Testo(Trim(Funzioni.myStr(PrandextP * PRANDTLcoeffEXT, 3, 4, False)))
                        .MuoviCella(1)
                        .Testo(Trim(Funzioni.myStr(Density, 4, 3, False)))
                        .MuoviCella(1)
                        .Testo(Trim(Funzioni.myStr(DensityP, 4, 3, False)))
                End Select
1380:       Next t
        End With
        Config.IasmePTC4 = 1
        Select Case Config.Ippgas65
            Case 0 : If ppg1E3(6) + ppg1E3(8) + ppg1E3(10) + ppg1E3(11) + ppg1E3(13) + ppg1E3(14) + ppg1E3(15) + ppg1E3(16) > 0 Then Config.IasmePTC4 = 0
            Case 1 : E365NONASME = 0
                For i = 14 To 65 : E365NONASME = E365NONASME + E365(i) : Next i
                E365NONASME = E365NONASME + E365(4) + E365(5) + E365(7) + E365(8) + E365(9) + E365(10) - E365(26)
                If E365NONASME > 0 Then Config.IasmePTC4 = 0
        End Select

        CP3 = PPCOEFF(4) : CP2 = PPCOEFF(3) : CP1 = PPCOEFF(2) : CP0 = PPCOEFF(1)
        CP33 = 225.3074 * E34 * 28.02 / PPCOEFF(19)
        CP22 = -728.8922 * E34 * 28.02 / PPCOEFF(19)
        CP11 = 755.7438 * E34 * 28.02 / PPCOEFF(19)
        CP00 = -247.6586 * E34 * 28.02 / PPCOEFF(19)
        ENTN2 = CP00 * 1.4 + CP11 / 2 * 1.4 * 1.4 + CP22 / 3 * 1.4 * 1.4 * 1.4 + CP33 / 4 * 1.4 * 1.4 * 1.4 * 1.4 ' en kJ/kg
        ' enthalpie de N2 par cette equation = 0 pour T6=1.4

        ' Print #iout, CPI10$
        ' Print #iout, ESP6$
        '         Print #iout, "Temp‚r.   Temp.   … Pr atmosph.    … Press. r‚elle     ASME PTC 4.4       *"
        '         Print #iout, "    T      Tr         Ÿ CpdT           ä CpdT           Enthalpie         *"
        Stub.VaiInizio("Tab4")
        With Stub 'Selection
            .Testo("°C")
            .MuoviCella(1)
            If Config.iUnit = 2 Then
                .Testo("j/kg")
                .MuoviCella(1)
                .Testo("j/kg")
                .MuoviCella(1)
                .Testo("j/kg")
                ENTHAL0 = ENTHALASME(Config.Tmin)
            Else
                .Testo("kCal/kg")
                .MuoviCella(1)
                .Testo("kCal/kg")
                .MuoviCella(1)
                .Testo("kCal/kg")
                ENTHAL0 = ENTHALASME(Config.Tmin) / CalJ
            End If
        End With
        Stub.VaiInizio("Tab4")
        With Stub 'Selection
            .MuoviLinea(2)
            .MuoviCella(-1)
            .MuoviCella(1)
            .Testo(Trim(Funzioni.myStr(Config.Tmin, 4, 0, False)))
            .MuoviCella(1)
            .Testo(Trim(Funzioni.myStr((Config.Tmin + 273.15) / TCM, 3, 3, False)))
            .MuoviCella(1)
            .Testo("0.")
            .MuoviCella(1)
            .Testo("0.")
            If Config.IasmePTC4 = 1 Then
                If Config.iUnit = 2 Then
                    .MuoviCella(1)
                    .Testo(Trim(Funzioni.myStr(ENTHAL0, 10, 0, False)))
                Else
                    .MuoviCella(1)
                    .Testo(Trim(Funzioni.myStr(ENTHAL0, 8, 2, False)))
                End If
            Else
                .MuoviCella(1)
            End If
            ENTHAL = 0 : ENTHALSI = 0 : ENTHALP = 0
            T6 = (Config.Tmin + 273.15) / 1000
            HE0 = CP0 * T6 + CP1 / 2 * T6 * T6 + CP2 / 3 * T6 * T6 * T6 + CP3 / 4 * T6 * T6 * T6 * T6 ' en kJ/kg
            If T6 > 1.4 Then HE0 = HE0 + CP00 * T6 + CP11 / 2 * T6 * T6 + CP22 / 3 * T6 * T6 * T6 + CP33 / 4 * T6 * T6 * T6 * T6 - ENTN2
            '*(332)***********************************************************************************************************
            For t = Config.Tmin To Config.Tmax - Config.Tincr Step Config.Tincr
                Temp = t + 0.5 * Config.Tincr ': Print Temp,
                C0P = CalculCp(Temp, Config.Pressione, E34, 121)
                ENTHALP = ENTHALP + Config.Tincr * C0P 'J/kg
                T6 = (t + Config.Tincr + 273.15) / 1000
                HE = CP0 * T6 + CP1 / 2 * T6 * T6 + CP2 / 3 * T6 * T6 * T6 + CP3 / 4 * T6 * T6 * T6 * T6 ' en kJ/kg
                If T6 > 1.4 Then HE = HE + CP00 * T6 + CP11 / 2 * T6 * T6 + CP22 / 3 * T6 * T6 * T6 + CP33 / 4 * T6 * T6 * T6 * T6 - ENTN2
                ENTHAL = (HE - HE0) * 1000 'J/kg
                .LibMatDestra()
                .Testo(Trim(Funzioni.myStr(t + Config.Tincr, 4, 0, False)))
                .MuoviCella(1)
                .Testo(Trim(Funzioni.myStr((t + Config.Tincr + 273.15) / TCM, 3, 3, False)))
                If Config.iUnit = 2 Then
                    .MuoviCella(1)
                    .Testo(Trim(Funzioni.myStr(ENTHAL, 10, 0, False)))
                    .MuoviCella(1)
                    .Testo(Trim(Funzioni.myStr(ENTHALP, 10, 0, False)))
                Else
                    .MuoviCella(1)
                    .Testo(Trim(Funzioni.myStr(ENTHAL / CalJ, 8, 2, False)))
                    .MuoviCella(1)
                    .Testo(Trim(Funzioni.myStr(ENTHALP / CalJ, 8, 2, False)))
                End If
                If Config.IasmePTC4 = 1 Then
                    If Config.iUnit = 2 Then
                        .MuoviCella(1)
                        .Testo(Trim(Funzioni.myStr(ENTHALASME(t + Config.Tincr), 10, 0, False)))
                    Else
                        .MuoviCella(1)
                        .Testo(Trim(Funzioni.myStr(ENTHALASME(t + Config.Tincr) / CalJ, 8, 2, False)))
                    End If
                Else
                    .MuoviCella(1)
                End If
            Next t
        End With
        Stub.VaiInizio("Testo")
        With Stub 'Selection
            If Config.IasmePTC4 = 1 And ppg1E3(7) > 0 Then
                Testo = " Ce gaz contenant de l'Argon, le calcul de l'enthalpie par la méthode ANSI/ASME PTC 4.4 est celui d'un gaz avec "
                Testo = Testo & Funzioni.FormatS("###.## + ##.## =###.## % volume de N2 et donc un poids moléculaire de####.## kg/kmole", ppg1E3(4) * 100, ppg1E3(7) * 100, (ppg1E3(4) + ppg1E3(7)) * 100, ppg1E3(1) * 28.01 + ppg1E3(2) * 18.02 + ppg1E3(3) * 2.016 + (ppg1E3(4) + ppg1E3(7)) * 28.02 + ppg1E3(5) * 44.01 + ppg1E3(9) * 32 + ppg1E3(12) * 64.07)
                .Testo(Testo)
                .sTypeParagraph()
            End If
            Testo = Funzioni.FormatS(" Si T < 1127°C Enthal(t)=#####.## *t4 +#####.## *t3 +#####.## *t2 +#####.## *t - ########  avec t=(T+273.15)/1000", CP3 / 4, CP2 / 3, CP1 / 2, CP0, HE0)
            .Testo(Testo)
            .sTypeParagraph()
            If Config.idewpoint = 1 Then
                If Monitor.Motore.Inizio.VersOffice < 11 Then
                    Stop
                Else
                    StubAcid = New StubW2000.clsSW2000
                    StubAcid.SuperStampa(Monitor.Motore.Inizio.Archdir & "\PPGAR.DOC", Monitor.Motore.Inizio.VersOffice)
                    StubAcid.sSaveAs(Left(FileStam, Len(FileStam) - 4) & "1.DOC")
                    Call ACIDEWCOMPLET(Config.Pressione, ppg1E3(2) * 100, ppg1E3(12) * 100, _
                         ppg1E3(13) * 100, ppg1E3(9) * 100, StubAcid)
                    StubAcid.sSave()
                    Stub.sInsertFile(Left(FileStam, Len(FileStam) - 4) & "1.DOC")
                    Stub.sSave()
                    StubAcid.sClose()
                    Kill(Left(FileStam, Len(FileStam) - 4) & "1.DOC")
                End If
            End If
        End With
        FinePagina(Stub)
1450:   StampaRugiada()
    End Sub
    Private Overloads Sub StampaCorpo(ByVal Stub As StubW9.clsSW9)
        Dim t As Single
        Dim C0, C0P As Single
        Dim K0P, K0, Z0, Z0P As Single
        Dim Prandint, Prandext As Single
        Dim PrandintP, PrandextP As Single
        Dim PRANDTLcoeffINT, PRANDTLcoeffEXT As Single
        Dim E365NONASME As Single
        Dim i As Short
        Dim CP1, CP0, CP2 As Single
        Dim CP22, CP3, CP33, CP11 As Single
        Dim CP00, ENTN2 As Single
        Dim ENTHALSI, ENTHAL, ENTHAL0, ENTHALP As Single
        Dim Temp, T6, HE0, HE As Single
        Dim Testo As String
        Stub.VaiInizio("Tab3")
        With Stub ' Selection
            Select Case Config.iUnit
                Case 1
                    .Testo("°C")
                    .MuoviCella(1)
                    .Testo("cm3/mole")
                    .MuoviCella(2)
                    .Testo("kCal/kg°C")
                    .MuoviCella(1)
                    .Testo("kCal/hr.m.°C")
                    .MuoviCella(1)
                    .Testo("cP")
                Case 2
                    .Testo("°C")
                    .MuoviCella(1)
                    .Testo("cm3/mole")
                    .MuoviCella(2)
                    .Testo("j/kg°C")
                    .MuoviCella(1)
                    .Testo("w/m°C")
                    .MuoviCella(1)
                    .Testo("kg/m.s")
                Case 3
                    .Testo("°C")
                    .MuoviCella(1)
                    .Testo("cm3/mole")
                    .MuoviCella(2)
                    .Testo("kCal/kg°C")
                    .MuoviCella(1)
                    .Testo("BTU/hr.ft.°F")
                    .MuoviCella(1)
                    .Testo("cP")
            End Select
        End With
        Stub.VaiInizio("Tab3", , True)
        With Stub 'Selection
            .MuoviLinea(2)
            .MuoviCella(-1)
1300:       For t = Config.Tmin To Config.Tmax Step Config.Tincr

                Erreur = "" ': Print T,
                If Config.Ippgas65 = 2 Then
                    C0 = CalculCp(t, Config.Pressione, E34, 70)
                    C0P = CalculCp(t, Config.Pressione, E34, 70)
                    Call ConducVisco(t, Config.Pressione, 70, K0, Z0)
                    Call ConducVisco(t, Config.Pressione, 70, K0P, Z0P)
                ElseIf Config.Ippgas65 = 3 Then
                    Stop
                Else
                    C0 = CalculCp(t, Config.Pressione, E34, 89)
                    C0P = CalculCp(t, Config.Pressione, E34, 121)
                    'TCM = PPCOEFF(20): PCM = PPCOEFF(22) 'aggiunto da LP (non necessario?)
                    Call ConducVisco(t, Config.Pressione, 89, K0, Z0)
                    Call ConducVisco(t, Config.Pressione, 121, K0P, Z0P)
                End If

                Prandint = (C0 ^ 0.42) * (K0 ^ 0.58) / (Z0 ^ 0.37)
                Prandext = (C0 ^ 0.333) * (K0 ^ 0.667) / (Z0 ^ 0.328)
                PrandintP = (C0P ^ 0.42) * (K0P ^ 0.58) / (Z0P ^ 0.37)
                PrandextP = (C0P ^ 0.333) * (K0P ^ 0.667) / (Z0P ^ 0.328)
                CalcDensity(t, Config.Pressione)
                .LibMatDestra()
                .Testo(Trim(Funzioni.myStr(t, 4, 0, False)))
                .MuoviCella(1)
                .Testo(Trim(Funzioni.myStr(VM, 6, 0, False)))
                .MuoviCella(1)
                .Testo(Trim(Funzioni.myStr(ZM, 2, 3, False)))
                Select Case Config.iUnit
                    Case 1 'Print #iout, FormatS("##.#### ##.#### #.##### #.##### #.####### #.####### ", C0 / 4185.5, C0P / 4185.5, K0 * 0.86011, K0P * 0.86011, Z0 * 1000, Z0P * 1000);
                        .MuoviCella(1)
                        .Testo(Trim(Funzioni.myStr(C0 / CalJ, 2, 4, False)))
                        .MuoviCella(1)
                        .Testo(Trim(Funzioni.myStr(C0P / CalJ, 2, 4, False)))
                        .MuoviCella(1)
                        .Testo(Trim(Funzioni.myStr(K0 * kgmscp, 1, 5, False)))
                        .MuoviCella(1)
                        .Testo(Trim(Funzioni.myStr(K0P * kgmscp, 1, 5, False)))
                        .MuoviCella(1)
                        .Testo(Trim(Funzioni.myStr(Z0 * 1000, 1, 7, False)))
                        .MuoviCella(1)
                        .Testo(Trim(Funzioni.myStr(Z0P * 1000, 1, 7, False)))
                        PRANDTLcoeffINT = (kgmscp ^ 0.58) / (CalJ ^ 0.42) / (1000 ^ 0.37)
                        PRANDTLcoeffEXT = (kgmscp ^ 0.667) / (CalJ ^ 0.333) / (1000 ^ 0.328)
                        .MuoviCella(1)
                        .Testo(Trim(Funzioni.myStr(Prandint * PRANDTLcoeffINT, 3, 4, False)))
                        .MuoviCella(1)
                        .Testo(Trim(Funzioni.myStr(PrandintP * PRANDTLcoeffINT, 3, 4, False)))
                        .MuoviCella(1)
                        .Testo(Trim(Funzioni.myStr(Prandext * PRANDTLcoeffEXT, 3, 4, False)))
                        .MuoviCella(1)
                        .Testo(Trim(Funzioni.myStr(PrandextP * PRANDTLcoeffEXT, 3, 4, False)))
                        .MuoviCella(1)
                        .Testo(Trim(Funzioni.myStr(Density, 4, 3, False)))
                        .MuoviCella(1)
                        .Testo(Trim(Funzioni.myStr(DensityP, 4, 3, False)))
                    Case 2 'Print #iout, FormatS("#####.# #####.# #.##### #.##### #.####^^^^ #.####^^^^ ", C0, C0P, K0, K0P, Z0, Z0P);
                        .MuoviCella(1)
                        .Testo(Trim(Funzioni.myStr(C0, 4, 1, False)))
                        .MuoviCella(1)
                        .Testo(Trim(Funzioni.myStr(C0P, 4, 1, False)))
                        .MuoviCella(1)
                        .Testo(Trim(Funzioni.myStr(K0, 1, 5, False)))
                        .MuoviCella(1)
                        .Testo(Trim(Funzioni.myStr(K0P, 1, 5, False)))
                        .MuoviCella(1)
                        .Testo(Trim(Microsoft.VisualBasic.Strings.Format(Z0, FormSci)))
                        .MuoviCella(1)
                        .Testo(Trim(Microsoft.VisualBasic.Strings.Format(Z0P, FormSci)))
                        .MuoviCella(1)
                        .Testo(Trim(Funzioni.myStr(Prandint, 3, 4, False)))
                        .MuoviCella(1)
                        .Testo(Trim(Funzioni.myStr(PrandintP, 3, 4, False)))
                        .MuoviCella(1)
                        .Testo(Trim(Funzioni.myStr(Prandext, 3, 4, False)))
                        .MuoviCella(1)
                        .Testo(Trim(Funzioni.myStr(PrandextP, 3, 4, False)))
                        .MuoviCella(1)
                        .Testo(Trim(Funzioni.myStr(Density, 4, 3, False)))
                        .MuoviCella(1)
                        .Testo(Trim(Funzioni.myStr(DensityP, 4, 3, False)))
                    Case 3 'Print #iout, FormatS("##.#### ##.#### #.##### #.##### #.####### #.####### ", C0 / 4185.5, C0P / 4185.5, K0 * 0.57779, K0P * 0.57779, Z0 * 1000, Z0P * 1000);
                        .MuoviCella(1)
                        .Testo(Trim(Funzioni.myStr(C0 / CalJ, 2, 4, False)))
                        .MuoviCella(1)
                        .Testo(Trim(Funzioni.myStr(C0P / CalJ, 2, 4, False)))
                        .MuoviCella(1)
                        .Testo(Trim(Funzioni.myStr(K0 * kgmsB, 1, 5, False)))
                        .MuoviCella(1)
                        .Testo(Trim(Funzioni.myStr(K0P * kgmsB, 1, 5, False)))
                        .MuoviCella(1)
                        .Testo(Trim(Funzioni.myStr(Z0 * 1000, 1, 7, False)))
                        .MuoviCella(1)
                        .Testo(Trim(Funzioni.myStr(Z0P * 1000, 1, 7, False)))
                        PRANDTLcoeffINT = (kgmsB ^ 0.58) / (CalJ ^ 0.42) / (1000 ^ 0.37)
                        PRANDTLcoeffEXT = (kgmsB ^ 0.667) / (CalJ ^ 0.333) / (1000 ^ 0.328)
                        .MuoviCella(1)
                        .Testo(Trim(Funzioni.myStr(Prandint * PRANDTLcoeffINT, 3, 4, False)))
                        .MuoviCella(1)
                        .Testo(Trim(Funzioni.myStr(PrandintP * PRANDTLcoeffINT, 3, 4, False)))
                        .MuoviCella(1)
                        .Testo(Trim(Funzioni.myStr(Prandext * PRANDTLcoeffEXT, 3, 4, False)))
                        .MuoviCella(1)
                        .Testo(Trim(Funzioni.myStr(PrandextP * PRANDTLcoeffEXT, 3, 4, False)))
                        .MuoviCella(1)
                        .Testo(Trim(Funzioni.myStr(Density, 4, 3, False)))
                        .MuoviCella(1)
                        .Testo(Trim(Funzioni.myStr(DensityP, 4, 3, False)))
                End Select
1380:       Next t
        End With
        Config.IasmePTC4 = 1
        Select Case Config.Ippgas65
            Case 0 : If ppg1E3(6) + ppg1E3(8) + ppg1E3(10) + ppg1E3(11) + ppg1E3(13) + ppg1E3(14) + ppg1E3(15) + ppg1E3(16) > 0 Then Config.IasmePTC4 = 0
            Case 1 : E365NONASME = 0
                For i = 14 To 65 : E365NONASME = E365NONASME + E365(i) : Next i
                E365NONASME = E365NONASME + E365(4) + E365(5) + E365(7) + E365(8) + E365(9) + E365(10) - E365(26)
                If E365NONASME > 0 Then Config.IasmePTC4 = 0
        End Select

        CP3 = PPCOEFF(4) : CP2 = PPCOEFF(3) : CP1 = PPCOEFF(2) : CP0 = PPCOEFF(1)
        CP33 = 225.3074 * E34 * 28.02 / PPCOEFF(19)
        CP22 = -728.8922 * E34 * 28.02 / PPCOEFF(19)
        CP11 = 755.7438 * E34 * 28.02 / PPCOEFF(19)
        CP00 = -247.6586 * E34 * 28.02 / PPCOEFF(19)
        ENTN2 = CP00 * 1.4 + CP11 / 2 * 1.4 * 1.4 + CP22 / 3 * 1.4 * 1.4 * 1.4 + CP33 / 4 * 1.4 * 1.4 * 1.4 * 1.4 ' en kJ/kg
        ' enthalpie de N2 par cette equation = 0 pour T6=1.4

        ' Print #iout, CPI10$
        ' Print #iout, ESP6$
        '         Print #iout, "Temp‚r.   Temp.   … Pr atmosph.    … Press. r‚elle     ASME PTC 4.4       *"
        '         Print #iout, "    T      Tr         Ÿ CpdT           ä CpdT           Enthalpie         *"
        Stub.VaiInizio("Tab4")
        With Stub 'Selection
            .Testo("°C")
            .MuoviCella(1)
            If Config.iUnit = 2 Then
                .Testo("j/kg")
                .MuoviCella(1)
                .Testo("j/kg")
                .MuoviCella(1)
                .Testo("j/kg")
                ENTHAL0 = ENTHALASME(Config.Tmin)
            Else
                .Testo("kCal/kg")
                .MuoviCella(1)
                .Testo("kCal/kg")
                .MuoviCella(1)
                .Testo("kCal/kg")
                ENTHAL0 = ENTHALASME(Config.Tmin) / CalJ
            End If
        End With
        Stub.VaiInizio("Tab4")
        With Stub 'Selection
            .MuoviLinea(2)
            .MuoviCella(-1)
            .MuoviCella(1)
            .Testo(Trim(Funzioni.myStr(Config.Tmin, 4, 0, False)))
            .MuoviCella(1)
            .Testo(Trim(Funzioni.myStr((Config.Tmin + 273.15) / TCM, 3, 3, False)))
            .MuoviCella(1)
            .Testo("0.")
            .MuoviCella(1)
            .Testo("0.")
            If Config.IasmePTC4 = 1 Then
                If Config.iUnit = 2 Then
                    .MuoviCella(1)
                    .Testo(Trim(Funzioni.myStr(ENTHAL0, 10, 0, False)))
                Else
                    .MuoviCella(1)
                    .Testo(Trim(Funzioni.myStr(ENTHAL0, 8, 2, False)))
                End If
            Else
                .MuoviCella(1)
            End If
            ENTHAL = 0 : ENTHALSI = 0 : ENTHALP = 0
            T6 = (Config.Tmin + 273.15) / 1000
            HE0 = CP0 * T6 + CP1 / 2 * T6 * T6 + CP2 / 3 * T6 * T6 * T6 + CP3 / 4 * T6 * T6 * T6 * T6 ' en kJ/kg
            If T6 > 1.4 Then HE0 = HE0 + CP00 * T6 + CP11 / 2 * T6 * T6 + CP22 / 3 * T6 * T6 * T6 + CP33 / 4 * T6 * T6 * T6 * T6 - ENTN2
            '*(332)***********************************************************************************************************
            For t = Config.Tmin To Config.Tmax - Config.Tincr Step Config.Tincr
                Temp = t + 0.5 * Config.Tincr ': Print Temp,
                C0P = CalculCp(Temp, Config.Pressione, E34, 121)
                ENTHALP = ENTHALP + Config.Tincr * C0P 'J/kg
                T6 = (t + Config.Tincr + 273.15) / 1000
                HE = CP0 * T6 + CP1 / 2 * T6 * T6 + CP2 / 3 * T6 * T6 * T6 + CP3 / 4 * T6 * T6 * T6 * T6 ' en kJ/kg
                If T6 > 1.4 Then HE = HE + CP00 * T6 + CP11 / 2 * T6 * T6 + CP22 / 3 * T6 * T6 * T6 + CP33 / 4 * T6 * T6 * T6 * T6 - ENTN2
                ENTHAL = (HE - HE0) * 1000 'J/kg
                .LibMatDestra()
                .Testo(Trim(Funzioni.myStr(t + Config.Tincr, 4, 0, False)))
                .MuoviCella(1)
                .Testo(Trim(Funzioni.myStr((t + Config.Tincr + 273.15) / TCM, 3, 3, False)))
                If Config.iUnit = 2 Then
                    .MuoviCella(1)
                    .Testo(Trim(Funzioni.myStr(ENTHAL, 10, 0, False)))
                    .MuoviCella(1)
                    .Testo(Trim(Funzioni.myStr(ENTHALP, 10, 0, False)))
                Else
                    .MuoviCella(1)
                    .Testo(Trim(Funzioni.myStr(ENTHAL / CalJ, 8, 2, False)))
                    .MuoviCella(1)
                    .Testo(Trim(Funzioni.myStr(ENTHALP / CalJ, 8, 2, False)))
                End If
                If Config.IasmePTC4 = 1 Then
                    If Config.iUnit = 2 Then
                        .MuoviCella(1)
                        .Testo(Trim(Funzioni.myStr(ENTHALASME(t + Config.Tincr), 10, 0, False)))
                    Else
                        .MuoviCella(1)
                        .Testo(Trim(Funzioni.myStr(ENTHALASME(t + Config.Tincr) / CalJ, 8, 2, False)))
                    End If
                Else
                    .MuoviCella(1)
                End If
            Next t
        End With
        Stub.VaiInizio("Testo")
        With Stub 'Selection
            If Config.IasmePTC4 = 1 And ppg1E3(7) > 0 Then
                Testo = " Ce gaz contenant de l'Argon, le calcul de l'enthalpie par la méthode ANSI/ASME PTC 4.4 est celui d'un gaz avec "
                Testo = Testo & Funzioni.FormatS("###.## + ##.## =###.## % volume de N2 et donc un poids moléculaire de####.## kg/kmole", ppg1E3(4) * 100, ppg1E3(7) * 100, (ppg1E3(4) + ppg1E3(7)) * 100, ppg1E3(1) * 28.01 + ppg1E3(2) * 18.02 + ppg1E3(3) * 2.016 + (ppg1E3(4) + ppg1E3(7)) * 28.02 + ppg1E3(5) * 44.01 + ppg1E3(9) * 32 + ppg1E3(12) * 64.07)
                .Testo(Testo)
                .sTypeParagraph()
            End If
            Testo = Funzioni.FormatS(" Si T < 1127°C Enthal(t)=#####.## *t4 +#####.## *t3 +#####.## *t2 +#####.## *t - ########  avec t=(T+273.15)/1000", CP3 / 4, CP2 / 3, CP1 / 2, CP0, HE0)
            .Testo(Testo)
            .sTypeParagraph()
            If Config.idewpoint = 1 Then
                If Monitor.Motore.Inizio.VersOffice < 11 Then
                    Stop
                Else
                    StubAcid9 = New StubW9.clsSW9
                    StubAcid9.SuperStampa(Monitor.Motore.Inizio.Archdir & "\PPGAR.DOC", Monitor.Motore.Inizio.VersOffice)
                    StubAcid9.sSaveAs(Left(FileStam, Len(FileStam) - 4) & "1.DOC")
                    Call ACIDEWCOMPLET(Config.Pressione, ppg1E3(2) * 100, ppg1E3(12) * 100, _
                         ppg1E3(13) * 100, ppg1E3(9) * 100, StubAcid9)
                    StubAcid9.sSave()
                    Stub.sInsertFile(Left(FileStam, Len(FileStam) - 4) & "1.DOC")
                    Stub.sSave()
                    StubAcid9.sClose()
                    Kill(Left(FileStam, Len(FileStam) - 4) & "1.DOC")
                End If
            End If
        End With
        FinePagina(Stub)
1450:   StampaRugiada()
    End Sub
    Private Overloads Sub ACIDEWCOMPLET(ByRef SYPRES As Single, ByRef H2OVP As Single, _
                              ByRef SO2VP As Single, ByRef SO3VP As Single, ByRef O2VP As Single, _
                              ByVal StubACid As StubW2000.clsSW2000)
        'SHARED CPI10$, CPI12$

        ' Calcul du point de ros‚e acide (H2SO4) pour quelques pourcentages de
        ' conversion du SO2 en SO3 par trois correlations diff‚rentes
        ' SYPRES = Pression du gaz en bar absolus
        ' H2OVP =  volume % de H2O in wet gas = E3(2) * 100
        ' SO2VP =  volume % de SO2 in wet gas = E3(12) * 100
        ' SO3VP =  volume % de SO3 in wet gas = E3(13) * 100
        ' O2VP  =  volume % de O2  in wet gas = E3(9) * 100

        'UPGRADE_WARNING: Il limite inferiore della matrice YVAR è stato cambiato da 1 a 0. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
        Dim YVAR(2) As Object
        Dim PPH2OA, PPH2O As Single
        Dim iflag As Short
        Dim Iconversion As Short
        Dim PERSO3, PPSO3 As Single
        Dim T11, TMOK, TVB As Single
        Dim i8 As Short
        Dim delta As Single
        Dim iptl, icrv, i9 As Short
        Dim ipth As Short
        Dim A165, Slope As Single
        Dim PPMSO3, Tmartin As Single
        Dim ICVL As Short
        Dim T22, Tabel As Single
        Dim IflagBis As Short
        Dim A, H2Ovpdry, CC As Single
        Dim TOSO3 As Single
        Dim Testo As String
        If SYPRES < 0 Then SYPRES = 1
        PPH2OA = SYPRES * 0.98692 * H2OVP / 100 ' ata
        PPH2O = PPH2OA * 760 ' mm Hg
        iflag = 0
        'Print #iout, CPI12$
        'Print #iout, "  % de SO2     % volume   vpm SO3   VERHOFF & BANCHERO   MARTIN     ABEL    MOIL & KAH   *"
        'Print #iout, "  converti    de SO3 dans   dans                 point de ros‚e acide  (H2SO4)           *"
        'Print #iout, "  en  SO3     gaz humide   gaz sec       Deg. C         Deg. C     Deg. C      Deg. C    *"
        'Set R = DocAcid.GoTo(wdGoToBookmark, , , "Tab5")
        StubACid.VaiInizio("Tab5")
        'R.Select
        With StubACid 'Selection
            '.MoveLeft wdCell
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto StubAcid.MuoviCella. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            .MuoviCella(-1)
            For Iconversion = 1 To 6
                PERSO3 = SO2VP * Iconversion / 100 + SO3VP

                '     MOBIL OIL & KAH correlation

                PPSO3 = SYPRES * PERSO3 / 100 ' bara
                TMOK = 203.25 + 27.6 * System.Math.Log(PPH2OA) / System.Math.Log(10) + 10.831 * System.Math.Log(PPSO3) / System.Math.Log(10) + (1.06 * (8 + System.Math.Log(PPSO3) / System.Math.Log(10)) ^ 2.19)


                '     VERHOFF & BANCHERO correlation

                PPSO3 = SYPRES * 0.98692 * PERSO3 / 100 ' ata
                T11 = 1.7842 + 0.0269 * System.Math.Log(PPH2OA) / System.Math.Log(10) - 0.1029 * System.Math.Log(PPSO3) / System.Math.Log(10) + 0.0329 * System.Math.Log(PPH2OA) / System.Math.Log(10) * System.Math.Log(PPSO3) / System.Math.Log(10)
                TVB = 1000 / T11 - 273.15


                '       MARTIN  correlation

                PPMSO3 = PERSO3 * 10000 * (100 / (100 - H2OVP)) ' amount of SO3 in vpm of dry flue products
                If PPMSO3 < 2 Or PPMSO3 > 600 Then Beep() : iflag = 1 : Tmartin = 0 : GoTo ABEL
                If PPH2O > 160 Or PPH2O < 5 Then Beep() : iflag = 1 : Tmartin = 0 : GoTo ABEL
                ICVL = 1
                For i8 = 2 To 9
                    If PPH2O > C(i8) Then ICVL = i8
                Next i8
                delta = C(ICVL + 1) - C(ICVL)
                For i8 = 1 To 2
                    icrv = ICVL + i8 - 1
                    iptl = 1
                    For i9 = 2 To 4
                        If PPMSO3 > A1(i9, icrv) Then iptl = i9
                    Next i9
                    ipth = iptl + 1
                    A165 = System.Math.Log(A1(iptl, icrv)) / System.Math.Log(10)
                    Slope = (A2(ipth, icrv) - A2(iptl, icrv)) / (System.Math.Log(A1(ipth, icrv)) / System.Math.Log(10) - A165)
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto YVAR(i8). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    YVAR(i8) = A2(iptl, icrv) + Slope * (System.Math.Log(PPMSO3) / System.Math.Log(10) - A165)
                Next i8
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto YVAR(1). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto YVAR(2). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                T22 = ((PPH2O - C(ICVL)) / delta * (YVAR(2) - YVAR(1))) + YVAR(1)
                Tmartin = (T22 - 32) / 1.8
                '*** (68) *********************************************************************************************************************
ABEL:           '  ABEL  correlation   ( courbes trac‚es par le C.E.R.M.A.T.)

                ' PPMSO3 =  amount of SO3 in vpm of dry flue products

                If PPMSO3 < 0.01 Or PPMSO3 > 1000 Then IflagBis = 1 : Tabel = 0 : GoTo ABELFIN

                H2Ovpdry = H2OVP * (100 / (100 - H2OVP)) ' % volume d'eau rapport‚ au gaz sec !

                If H2Ovpdry > 25 Or H2Ovpdry < 1 Then IflagBis = 1 : Tabel = 0 : GoTo ABELFIN

                A = 0.10794 * System.Math.Exp(-0.20656 * H2Ovpdry) + 0.24182
                CC = 90.84 + 10.8563 * System.Math.Log(H2Ovpdry)
                Tabel = A * System.Math.Log(PPMSO3) * System.Math.Log(PPMSO3) + 7.3 * System.Math.Log(PPMSO3) + CC

ABELFIN:
                .LibMatDestra()
                .Testo(Funzioni.myStr(Iconversion, 3, 0, False))
                .MuoviCella(1)
                .Testo(Funzioni.myStr(PERSO3, 3, 4, False))
                .MuoviCella(1)
                .Testo(Funzioni.myStr(PPMSO3, 4, 2, False))
                .MuoviCella(1)
                .Testo(Funzioni.myStr(TVB, 5, 2, False))
                .MuoviCella(1)
                .Testo(Funzioni.myStr(Tmartin, 5, 2, False))
                .MuoviCella(1)
                .Testo(Funzioni.myStr(Tabel, 5, 2, False))
                .MuoviCella(1)
                .Testo(Funzioni.myStr(TMOK, 5, 2, False))
            Next Iconversion
        End With
        StubACid.VaiInizio("Testo")
        With StubACid 'Selection
            TOSO3 = 0.167 * System.Math.Sqrt(SYPRES * O2VP / 100)
            If TOSO3 < 0.05 Then TOSO3 = 0.05
            Testo = "Nota : La méthode de MOIL & KAH propose d'utiliser un taux de conversion du SO2 en SO3 "
            PERSO3 = SO2VP * TOSO3 + SO3VP
            PPSO3 = SYPRES * PERSO3 / 100 ' bara
            TMOK = 203.25 + 27.6 * System.Math.Log(PPH2OA) / System.Math.Log(10) + 10.831 * System.Math.Log(PPSO3) / System.Math.Log(10) + (1.06 * (8 + System.Math.Log(PPSO3) / System.Math.Log(10)) ^ 2.19)
            Testo = Testo & Funzioni.FormatS("de ###.## %, soit donc un point de rosée acide de #####.# °C", TOSO3 * 100, TMOK)
            .Testo(Testo)
            .sTypeParagraph()
            .sTypeParagraph()
            Testo = "     : La méthode de ABEL-PIERCE n'est valable qu'à pression atmosphérique"
            .Testo(Testo)
            .sTypeParagraph()
            If iflag = 1 Then
                'Print #iout, ""
                Testo = "Attention : une ou plusieurs des valeurs calculées par la méthode de "
                Testo = Testo & "MARTIN ont été lues en dehors des courbes, celles-ci ont été "
                Testo = Testo & "tracées pour des concentrations de SO3 comprises entre 2 et "
                Testo = Testo & "600 vpm de gaz sec et pour des pressions partielles d'eau "
                Testo = Testo & Funzioni.FormatS("(ici égale à #####.# mm Hg) comprises entre  5 et 160 mm Hg.", PPH2O)
                .Testo(Testo)
                .sTypeParagraph()
                .sTypeParagraph()
            End If

            If IflagBis = 1 Then
                Testo = "Attention : les courbes d'ABEL ont été tracées par le C.E.R.M.A.T. pour "
                Testo = Testo & "une teneur en vapeur d'eau comprise entre 1 et 20 % volume "
                Testo = Testo & Funzioni.FormatS("(ici égale à ##.## % volume) et pour des concentrations en ", H2OVP)
                Testo = Testo & "SO3 comprises entre .01 et 1000 vpm des fumées sèches."
                .Testo(Testo)
                .sTypeParagraph()
            End If
        End With
    End Sub
    Private Overloads Sub ACIDEWCOMPLET(ByRef SYPRES As Single, ByRef H2OVP As Single, _
                              ByRef SO2VP As Single, ByRef SO3VP As Single, ByRef O2VP As Single, _
                              ByVal StubACid As StubW9.clsSW9)
        'SHARED CPI10$, CPI12$

        ' Calcul du point de ros‚e acide (H2SO4) pour quelques pourcentages de
        ' conversion du SO2 en SO3 par trois correlations diff‚rentes
        ' SYPRES = Pression du gaz en bar absolus
        ' H2OVP =  volume % de H2O in wet gas = E3(2) * 100
        ' SO2VP =  volume % de SO2 in wet gas = E3(12) * 100
        ' SO3VP =  volume % de SO3 in wet gas = E3(13) * 100
        ' O2VP  =  volume % de O2  in wet gas = E3(9) * 100

        'UPGRADE_WARNING: Il limite inferiore della matrice YVAR è stato cambiato da 1 a 0. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
        Dim YVAR(2) As Object
        Dim PPH2OA, PPH2O As Single
        Dim iflag As Short
        Dim Iconversion As Short
        Dim PERSO3, PPSO3 As Single
        Dim T11, TMOK, TVB As Single
        Dim i8 As Short
        Dim delta As Single
        Dim iptl, icrv, i9 As Short
        Dim ipth As Short
        Dim A165, Slope As Single
        Dim PPMSO3, Tmartin As Single
        Dim ICVL As Short
        Dim T22, Tabel As Single
        Dim IflagBis As Short
        Dim A, H2Ovpdry, CC As Single
        Dim TOSO3 As Single
        Dim Testo As String
        If SYPRES < 0 Then SYPRES = 1
        PPH2OA = SYPRES * 0.98692 * H2OVP / 100 ' ata
        PPH2O = PPH2OA * 760 ' mm Hg
        iflag = 0
        'Print #iout, CPI12$
        'Print #iout, "  % de SO2     % volume   vpm SO3   VERHOFF & BANCHERO   MARTIN     ABEL    MOIL & KAH   *"
        'Print #iout, "  converti    de SO3 dans   dans                 point de ros‚e acide  (H2SO4)           *"
        'Print #iout, "  en  SO3     gaz humide   gaz sec       Deg. C         Deg. C     Deg. C      Deg. C    *"
        'Set R = DocAcid.GoTo(wdGoToBookmark, , , "Tab5")
        StubACid.VaiInizio("Tab5")
        'R.Select
        With StubACid 'Selection
            '.MoveLeft wdCell
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto StubAcid.MuoviCella. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            .MuoviCella(-1)
            For Iconversion = 1 To 6
                PERSO3 = SO2VP * Iconversion / 100 + SO3VP

                '     MOBIL OIL & KAH correlation

                PPSO3 = SYPRES * PERSO3 / 100 ' bara
                TMOK = 203.25 + 27.6 * System.Math.Log(PPH2OA) / System.Math.Log(10) + 10.831 * System.Math.Log(PPSO3) / System.Math.Log(10) + (1.06 * (8 + System.Math.Log(PPSO3) / System.Math.Log(10)) ^ 2.19)


                '     VERHOFF & BANCHERO correlation

                PPSO3 = SYPRES * 0.98692 * PERSO3 / 100 ' ata
                T11 = 1.7842 + 0.0269 * System.Math.Log(PPH2OA) / System.Math.Log(10) - 0.1029 * System.Math.Log(PPSO3) / System.Math.Log(10) + 0.0329 * System.Math.Log(PPH2OA) / System.Math.Log(10) * System.Math.Log(PPSO3) / System.Math.Log(10)
                TVB = 1000 / T11 - 273.15


                '       MARTIN  correlation

                PPMSO3 = PERSO3 * 10000 * (100 / (100 - H2OVP)) ' amount of SO3 in vpm of dry flue products
                If PPMSO3 < 2 Or PPMSO3 > 600 Then Beep() : iflag = 1 : Tmartin = 0 : GoTo ABEL
                If PPH2O > 160 Or PPH2O < 5 Then Beep() : iflag = 1 : Tmartin = 0 : GoTo ABEL
                ICVL = 1
                For i8 = 2 To 9
                    If PPH2O > C(i8) Then ICVL = i8
                Next i8
                delta = C(ICVL + 1) - C(ICVL)
                For i8 = 1 To 2
                    icrv = ICVL + i8 - 1
                    iptl = 1
                    For i9 = 2 To 4
                        If PPMSO3 > A1(i9, icrv) Then iptl = i9
                    Next i9
                    ipth = iptl + 1
                    A165 = System.Math.Log(A1(iptl, icrv)) / System.Math.Log(10)
                    Slope = (A2(ipth, icrv) - A2(iptl, icrv)) / (System.Math.Log(A1(ipth, icrv)) / System.Math.Log(10) - A165)
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto YVAR(i8). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    YVAR(i8) = A2(iptl, icrv) + Slope * (System.Math.Log(PPMSO3) / System.Math.Log(10) - A165)
                Next i8
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto YVAR(1). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto YVAR(2). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                T22 = ((PPH2O - C(ICVL)) / delta * (YVAR(2) - YVAR(1))) + YVAR(1)
                Tmartin = (T22 - 32) / 1.8
                '*** (68) *********************************************************************************************************************
ABEL:           '  ABEL  correlation   ( courbes trac‚es par le C.E.R.M.A.T.)

                ' PPMSO3 =  amount of SO3 in vpm of dry flue products

                If PPMSO3 < 0.01 Or PPMSO3 > 1000 Then IflagBis = 1 : Tabel = 0 : GoTo ABELFIN

                H2Ovpdry = H2OVP * (100 / (100 - H2OVP)) ' % volume d'eau rapport‚ au gaz sec !

                If H2Ovpdry > 25 Or H2Ovpdry < 1 Then IflagBis = 1 : Tabel = 0 : GoTo ABELFIN

                A = 0.10794 * System.Math.Exp(-0.20656 * H2Ovpdry) + 0.24182
                CC = 90.84 + 10.8563 * System.Math.Log(H2Ovpdry)
                Tabel = A * System.Math.Log(PPMSO3) * System.Math.Log(PPMSO3) + 7.3 * System.Math.Log(PPMSO3) + CC

ABELFIN:
                .LibMatDestra()
                .Testo(Funzioni.myStr(Iconversion, 3, 0, False))
                .MuoviCella(1)
                .Testo(Funzioni.myStr(PERSO3, 3, 4, False))
                .MuoviCella(1)
                .Testo(Funzioni.myStr(PPMSO3, 4, 2, False))
                .MuoviCella(1)
                .Testo(Funzioni.myStr(TVB, 5, 2, False))
                .MuoviCella(1)
                .Testo(Funzioni.myStr(Tmartin, 5, 2, False))
                .MuoviCella(1)
                .Testo(Funzioni.myStr(Tabel, 5, 2, False))
                .MuoviCella(1)
                .Testo(Funzioni.myStr(TMOK, 5, 2, False))
            Next Iconversion
        End With
        StubACid.VaiInizio("Testo")
        With StubACid 'Selection
            TOSO3 = 0.167 * System.Math.Sqrt(SYPRES * O2VP / 100)
            If TOSO3 < 0.05 Then TOSO3 = 0.05
            Testo = "Nota : La méthode de MOIL & KAH propose d'utiliser un taux de conversion du SO2 en SO3 "
            PERSO3 = SO2VP * TOSO3 + SO3VP
            PPSO3 = SYPRES * PERSO3 / 100 ' bara
            TMOK = 203.25 + 27.6 * System.Math.Log(PPH2OA) / System.Math.Log(10) + 10.831 * System.Math.Log(PPSO3) / System.Math.Log(10) + (1.06 * (8 + System.Math.Log(PPSO3) / System.Math.Log(10)) ^ 2.19)
            Testo = Testo & Funzioni.FormatS("de ###.## %, soit donc un point de rosée acide de #####.# °C", TOSO3 * 100, TMOK)
            .Testo(Testo)
            .sTypeParagraph()
            .sTypeParagraph()
            Testo = "     : La méthode de ABEL-PIERCE n'est valable qu'à pression atmosphérique"
            .Testo(Testo)
            .sTypeParagraph()
            If iflag = 1 Then
                'Print #iout, ""
                Testo = "Attention : une ou plusieurs des valeurs calculées par la méthode de "
                Testo = Testo & "MARTIN ont été lues en dehors des courbes, celles-ci ont été "
                Testo = Testo & "tracées pour des concentrations de SO3 comprises entre 2 et "
                Testo = Testo & "600 vpm de gaz sec et pour des pressions partielles d'eau "
                Testo = Testo & Funzioni.FormatS("(ici égale à #####.# mm Hg) comprises entre  5 et 160 mm Hg.", PPH2O)
                .Testo(Testo)
                .sTypeParagraph()
                .sTypeParagraph()
            End If

            If IflagBis = 1 Then
                Testo = "Attention : les courbes d'ABEL ont été tracées par le C.E.R.M.A.T. pour "
                Testo = Testo & "une teneur en vapeur d'eau comprise entre 1 et 20 % volume "
                Testo = Testo & Funzioni.FormatS("(ici égale à ##.## % volume) et pour des concentrations en ", H2OVP)
                Testo = Testo & "SO3 comprises entre .01 et 1000 vpm des fumées sèches."
                .Testo(Testo)
                .sTypeParagraph()
            End If
        End With
    End Sub
    Private Function ENTHALASME(ByRef Temp As Object) As Single
        Dim TF, R As Single
        Dim HHY, HOM, HIM, HNO As Single
        Dim HSO, HCO, HOX, H As Single
        Dim PM As Single
        ' PPCOEFF(19) = masse molaire COMMON SHARED
        ' E3() = fraction volume    COMMON SHARED
        ' Temp                    en øC
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Temp. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        TF = Temp * 1.8 + 32 ' en øF
        R = (TF + 459.7) / 100 ' en køR

        HOM = 23.39643 * R + 0.13848 * R * R - 0.000164 * R * R * R + 18.89712 / R 'carbon monoxyde  1
        HIM = 40.83193 * R + 0.3671 * R * R + 0.000616 * R * R * R + 34.42356 / R 'moisture        2
        HHY = 208.1129 * R + 1.30827 * R * R + 0.0270216 * R * R * R + 157.9353 / R 'hydrogene       3
        HNO = 23.69959 * R + 0.09764 * R * R + 0.0005949 * R * R * R + 15.60296 / R 'nitrogen        4
        HCO = 14.00137 * R + 0.67027 * R * R - 0.0087505 * R * R * R - 8.57364 / R 'carbon dioxyde  5
        HOX = 19.75583 * R + 0.24852 * R * R - 0.0027109 * R * R * R + 18.86205 / R 'oxygene         9
        HSO = 11.10611 * R + 0.42328 * R * R - 0.0060594 * R * R * R + 0.6788 / R 'sulfur dioxide  12

        'E3(I)                     = fraction volume
        'E3(I) * E2(I) / PPCOEFF(19) = fraction en masse
        'H = E3(1) * E2(1) * HOM + E3(2) * E2(2) * HIM + E3(3) * E2(3) * HHY +      E3(4)      * E2(4) * HNO + E3(5) * E2(5) * HCO + E3(9) * E2(9) * HOX + E3(12) * E2(12) * HSO ' BTU/Lb
        H = ppg1E3(1) * 28.01 * HOM + ppg1E3(2) * 18.02 * HIM + ppg1E3(3) * 2.016 * HHY + (ppg1E3(4) + ppg1E3(7)) * 28.02 * HNO + ppg1E3(5) * 44.01 * HCO + ppg1E3(9) * 32 * HOX + ppg1E3(12) * 64.07 * HSO ' BTU/Lb

        If ppg1E3(7) > 0 Then
            PM = ppg1E3(1) * 28.01 + ppg1E3(2) * 18.02 + ppg1E3(3) * 2.016 + (ppg1E3(4) + ppg1E3(7)) * 28.02 + ppg1E3(5) * 44.01 + ppg1E3(9) * 32 + ppg1E3(12) * 64.07
        Else
            PM = PPCOEFF(19)
        End If

        ENTHALASME = H * 2326 / PM ' J/kg

    End Function
    Public Sub Salva(Optional ByRef f As String = "")
        Dim ifl, i As Short
        If Len(f) > 0 Then FileData = f
        If FileData = "" Then Exit Sub
        If Acqua Then Exit Sub
        ifl = FreeFile()
        FileOpen(ifl, FileData, OpenMode.Binary)
        With Monitor.Motore.Problem
            Problem.ClientPlant = .ClientPlant
            Problem.Commessa = .Commessa
            Problem.Item = .Item
            Problem.Author = .Author
        End With
        Problem.Version = 1
        'UPGRADE_WARNING: Put è stato aggiornato a FilePut e ha un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
        FilePut(ifl, Problem)
        Config.PesoMoc = PPCOEFF(19)
        'UPGRADE_WARNING: Put è stato aggiornato a FilePut e ha un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
        FilePut(ifl, Config)
        Select Case Config.Ippgas65
            Case 0
                For i = 1 To 16
                    'UPGRADE_WARNING: Put è stato aggiornato a FilePut e ha un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
                    FilePut(ifl, ppg1E2(i))
                    'UPGRADE_WARNING: Put è stato aggiornato a FilePut e ha un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
                    FilePut(ifl, ppg1E3(i))
                Next
            Case 1
                For i = 1 To 65
                    'UPGRADE_WARNING: Put è stato aggiornato a FilePut e ha un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
                    FilePut(ifl, E265(i))
                    'UPGRADE_WARNING: Put è stato aggiornato a FilePut e ha un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
                    FilePut(ifl, E365(i))
                Next
            Case 2
                For i = 1 To 65
                    'UPGRADE_WARNING: Put è stato aggiornato a FilePut e ha un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
                    FilePut(ifl, E365(i))
                Next
            Case 3
                'Stop
        End Select
        FileClose(ifl)
    End Sub
    Public Function Inizializza() As Boolean
        Inizializza = True
        Dim FileSt As String
        Dim iF3, n As Short
        Dim Curva As New CondCurva
        Dim i As Short
        Select Case Config.Ippgas65
            Case 0
                If Not INPUTPPGAS16(1, PPCOEFF(19), True) Then Exit Function
                Call LECTUREPPGAS16()
                E34 = ppg1E3(4)
            Case 1
                If Not INPUTPPGAS65(1, PPCOEFF(19), True) Then Exit Function
                If Not LECTUREPPGAS65() Then
                    Inizializza = False
                    Exit Function
                End If
                ppg1E3(1) = E365(11) : ppg1E3(2) = E365(26) : ppg1E3(3) = E365(1) : ppg1E3(4) = E365(2)
                ppg1E3(5) = E365(12) : ppg1E3(6) = E365(31) : ppg1E3(7) = E365(6) : ppg1E3(8) = E365(18)
                ppg1E3(9) = E365(3) : ppg1E3(10) = E365(16) : ppg1E3(11) = E365(17) : ppg1E3(12) = E365(13)
                ppg1E3(13) = E365(14) : ppg1E3(14) = E365(28) : ppg1E3(15) = E365(32) : ppg1E3(16) = E365(33)
                E34 = E365(2)
            Case 2
                VerificaDati()
            Case 3
                iF3 = FreeFile()
                FileSt = Left(FileData, Len(FileData) - 3) & "RA1"
                FileOpen(iF3, FileSt, OpenMode.Random, , , Len(Curva))
                n = LOF(iF3)
                If n = 0 Then
                    MsgBox("La curva di condensazione non contiene alcun punto")
                    Exit Function
                End If
                nPoints = n \ Len(Curva)
                'UPGRADE_WARNING: È possibile che singoli elementi della matrice CurvPoint debbano essere inizializzati. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="B97B714D-9338-48AC-B03F-345B617E2B02"'
                ReDim CurvPoint(nPoints)
                i = 1
                Do
                    'UPGRADE_WARNING: Get è stato aggiornato a FileGet e ha un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
                    FileGet(iF3, Curva, i)
                    If EOF(iF3) Then Exit Do
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto CurvPoint(i). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    CurvPoint(i) = Curva
                    i = i + 1
                Loop
                FileClose(iF3)
                ApertoCurva = True
        End Select
    End Function
    Private Sub CalcDensity(ByRef t As Single, ByRef Press As Single)
        ZM = 1
        Dim iinf, i, isup As Short
        If Config.Ippgas65 < 2 Then
            PRM = Press * 0.98692 / PPCOEFF(20) ' PPCOEFF(20)=PCM en ata
            TRM = (t + 273.15) / TCM
            If PRM > 9 Then ZM = 1.1 + (PRM - 9) / (10 * TRM) : GoTo 1400
            If TRM > 3 And PRM < 1.2 Then ZM = 1 : GoTo 1400
            If TRM > 3 And PRM < 1.4 Then ZM = 1 + TRM / 2000 : GoTo 1400
            If TRM > 3.5 And PRM < 1.8 Then ZM = 1 + TRM / 1000 : GoTo 1400
            If TRM > 4 Then ZM = 1 + (TRM - 10) / 1000 : GoTo 1400
            Zm0 = CalculZ(PRM, TRM, ppg1ZZ0, Erreur)
            ZM1 = CalculZ(PRM, TRM, ppg1ZZ1, Erreur)
            ZM = Zm0 + PPCOEFF(23) * ZM1 '  corr‚lation de PITZER     PPCOEFF(23)=OMM
            '***(266)********************************************************************************************************************* PPGAS165.BAS
1400:       VM = ZM * 83.144 * (t + 273.15) / Press
        ElseIf Config.Ippgas65 = 3 Then
            If t < CurvPoint(nPoints).Temp Then
                iinf = nPoints - 1
                isup = nPoints
            ElseIf t > CurvPoint(1).Temp Then
                iinf = 1
                isup = 2
            Else
                For i = 1 To nPoints - 1
                    If t <= CurvPoint(i).Temp And t >= CurvPoint(i + 1).Temp Then Exit For
                Next
                iinf = i
                isup = i + 1
            End If
            ZM = (CurvPoint(iinf).Cfac + (CurvPoint(isup).Cfac - CurvPoint(iinf).Cfac) * (t - CurvPoint(iinf).Temp) / (CurvPoint(isup).Temp - CurvPoint(iinf).Temp))
        End If
        Density = prPesoMoc(t) / 22.414 * 273.15 / (273.15 + t) * Press / 1.01325
        DensityP = Density / ZM
        ' 12.02722 * Gas.prpesomoc(T1) * P1 / (T1 + 273.15)
    End Sub
    Protected Overrides Sub Finalize()
        If Not Monitor Is Nothing Then Monitor.Motore = Nothing
        Monitor = Nothing
        MyBase.Finalize()
    End Sub
    Private Sub PostSelezione(ByRef mostra As Boolean)
        If Config.Ippgas65 = 0 Then
            If Not INPUTPPGAS16(Config.PercVol + 1, PPCOEFF(19), , mostra) Then Exit Sub
            If Not INPUTPPGAS16(3, PPCOEFF(19), , mostra) Then Exit Sub
            Call LECTUREPPGAS16()
            E34 = ppg1E3(4) ' E365(2)
        ElseIf Config.Ippgas65 = 1 Then
            If Not INPUTPPGAS65(Config.PercVol + 1, PPCOEFF(19), , mostra) Then Exit Sub
            If Not INPUTPPGAS65(3, PPCOEFF(19), , mostra) Then Exit Sub
            Call LECTUREPPGAS65()
            ppg1E3(1) = E365(11) : ppg1E3(2) = E365(26) : ppg1E3(3) = E365(1) : ppg1E3(4) = E365(2)
            ppg1E3(5) = E365(12) : ppg1E3(6) = E365(31) : ppg1E3(7) = E365(6) : ppg1E3(8) = E365(18)
            ppg1E3(9) = E365(3) : ppg1E3(10) = E365(16) : ppg1E3(11) = E365(17) : ppg1E3(12) = E365(13)
            ppg1E3(13) = E365(14) : ppg1E3(14) = E365(28) : ppg1E3(15) = E365(32) : ppg1E3(16) = E365(33)
            E34 = ppg1E3(4)
        End If
    End Sub
    Public Function FrazAcqua() As Single
        Select Case Config.Ippgas65
            Case 0
                FrazAcqua = ppg1E2(2) * ppg1E3(2) / PPCOEFF(19)
            Case 1
                FrazAcqua = E265(26) * E365(26) / PPCOEFF(19)
            Case Else
                Stop
        End Select
    End Function
    Public Sub INPUTPHYSICALPROPERTY(ByRef IA0 As Short, ByRef A0 As String) '                                                      FIRE1.BAS:INPOUTPHYSICALPROPERTY
        ' IA0=1  : entr‚e des donn‚es
        ' IA0=3  : verif des donn‚es + remplissage du tableau
        ' E365() et PPCOEFF sont dans le COMMON

        'CLS:  Print Tab(13); "PROPRIETES PHYSIQUES DU FLUIDE "; A0$

        If IA0 = 3 Then
            If E365(26) = -999 Then
                mioApert.optLG(1).Checked = True
            Else
                mioApert.optLG(0).Checked = True
            End If
        End If
        'ipp:    Ifluide = Ifluide - 1: ReDim optn$(1 To 26)


        'For i = 1 To 26 Step 2: optn$(i) = "… la temp‚rature (en øC) ": Next i
        ' optn$(2) = "Cp  (J/kgøC)   = ":  optn$(4) = "Cp  (J/kgøC)   = "
        ' optn$(6) = "Cp  (J/kgøC)   = ":  optn$(8) = "Cp  (J/kgøC)   = "
        'optn$(10) = "K   (W/møC)    = ": optn$(12) = "K   (W/møC)    = ": optn$(14) = "K   (W/møC)    = "
        'optn$(16) = "æ   (kg/m.sec) = ": optn$(18) = "æ   (kg/m.sec) = ": optn$(20) = "æ   (kg/m.sec) = "
        'optn$(22) = "ô   (kg/m3)    = ": optn$(24) = "ô   (kg/m3)    = ": optn$(26) = "ô   (kg/m3)    = "
        'If Ifluide = 2 Then optn$(22) = "et … la pression (bar a) ": optn$(23) = "densite ô du gaz (kg/m3) ": optn$(24) = "soit un PdsMol de "


debutPP:  ' CLS: Print Tab(10); "PROPRIETES PHYSIQUES DU FLUIDE ";
        'If Ifluide = 1 Then Print "liquide "; A0$ Else Print "gazeux "; A0$
        'Ix = 1: Iy = 1: i = 1
        'Color 7, 0
        If Ifluide = 2 And E365(23) > 0 Then
            E365(26) = -999
            Config.PesoMoc = E365(22) * 22.4 * (273.15 + E365(21)) * 1.01325 / 273.15 / E365(23)
        End If
        mioApert.AggManual()
        'For Ix = 1 To 13 - Ifluide - 1
        '  LOCATE Ix + 3, 5: Print optn$(i); E365(i); Tab(40); optn$(i + 1);
        '  If Ifluide = 2 And Ix = 12 Then Print Config.PesoMoc Else Print E365(i + 1)
        '  i = i + 2
        'Next Ix

        'Print: Print Tab(25); "Frappez ESCAPE pour abandonner": Print Tab(17); "Frappez la touche de fonction F1 pour conclure"
        'Print "  Pour chaque propri‚t‚ physique entrez les temp‚ratures en ordre croissant"
        'call INFOPP
        'Ix = 1:  i = 1

        'PPSAISIE:
        ' PM=densit‚ * 22.4 * (273.15+T) * 1.01325 / 273.15 / Pression
        'If Ifluide = 2 And E365(22) > 0 Then
        '   E365(26) = -999
        '   PesoMoc = E365(23) * 22.4 * (273.15 + E365(21)) * 1.01325 / 273.15 / E365(22)
        'End If
        'Iy = 2 * (Int(i / 2) - 0.5 * Int(i)) + 2 ' Iy = 1 ou 2

        'LOCATE Ix + 3, 35 * Iy - 30
        'If Ifluide = 2 And i = 24 Then LOCATE 15, 57: Print Config.PesoMoc: call PMOLWARNING: Ix = 1: Iy = 1: i = 1: GoTo PPSAISIE
        'Color 0, 7: Print optn$(i);: Call INPOUT2(E365(i), A$)

        'If i = 1 Then call INFOPP
        'LOCATE Ix + 3, 35 * Iy - 30: Color 7, 0: Print optn$(i); E365(i)


        'If A$ = Chr$(0) + Chr$(&H49) Or A$ = Chr$(0) + Chr$(&H47) Then Ix = 1: Iy = 1: i = 1: GoTo PPSAISIE  ' pgup et home

        'If A$ = Chr$(0) + Chr$(&H48) Then 'up
        '    If i < 3 Then SOUND 300, 5: call INFOPP: GoTo PPSAISIE
        '    i = i - 2: Ix = Ix - 1: GoTo PPSAISIE
        'End If

        'If A$ = Chr$(0) + Chr$(&H50) Then  ' down
        '    If i >= 25 - 2 * (Ifluide - 1) Then SOUND 300, 5: call INFOPP: GoTo PPSAISIE ' FIRE1.BAS:INPUTPHYSICALPROPERTY
        '    i = i + 2: Ix = Ix + 1: GoTo PPSAISIE
        'End If

        'If A$ = Chr$(0) + Chr$(&H4D) Then  ' fleche vers la droite
        '    If Iy = 2 Then SOUND 300, 5: call INFOPP:  GoTo PPSAISIE
        '    i = i + 1: Iy = Iy + 1: GoTo PPSAISIE
        'End If

        'If A$ = Chr$(0) + Chr$(&H4B) Then  ' fleche vers la gauche
        '    If Iy = 1 Then SOUND 300, 5: call INFOPP:  GoTo PPSAISIE
        '    i = i - 1: GoTo PPSAISIE
        'End If

        'If A$ = Chr$(0) + Chr$(&H51) Or A$ = Chr$(0) + Chr$(&H4F) Then 'fin ou pgdn
        '    If i = 26 Then Ix = 1: Iy = 1: i = 1: GoTo PPSAISIE
        '    If Ifluide = 2 And i = 23 Then Ix = 1: i = 1: GoTo PPSAISIE
        '    i = 26 - 2 * (Ifluide - 1): Ix = 13 - Ifluide - 1: Iy = 2: GoTo PPSAISIE
        'End If

        'If A$ = Chr$(13) Then  ' enter
        '    If i = 26 - 2 * (Ifluide - 1) Then Ix = 1: i = 1: GoTo PPSAISIE
        '    i = i + 1
        '    If Iy = 2 Then Ix = Ix + 1
        '    GoTo PPSAISIE
        'End If

        'If A$ = Chr$(0) + Chr$(&H3B) Then GoTo VERIFTABLEAUPP  ' F1

        'If A$ = Chr$(27) Then
        '     Call MAKEWIND(8, 18, 10, 54, 0, 7, 0, 1, ""): Play "MBL32D<<D<<D<<D>>D>>D<<D"
        '     LOCATE 8, 20:  Print "Vous avez press‚ la touche ESCAPE"
        '     LOCATE 9, 20: Print "   pour l'abandon de la saisie"
        '     LOCATE 10, 20: Print "frapper une touche pour continuer"
        '     Do: Loop While INKEY$ = "": A0$ = "ABANDON": Color 7, 0
        '     Exit Sub
        'End If

        'Play "MBL64CDEFCA": GoTo PPSAISIE

        'PMOLWARNING:
        'Call MAKEWIND(22, 4, 24, 76, 0, 7, 1, 0, "")
        'LOCATE 23, 8: Print " Pdsmol est le poids mol‚culaire calcul‚, il ne peut ˆtre modifi‚ "
        'SOUND 200, 2: SOUND 400, 3
        'Return

    End Sub
    Public Function VerificaDati() As Boolean
        Dim NonCresc As Boolean
        Dim B5, B4, B6 As Single
        Dim B8, B7, B9 As Single
        'INFOPP:
        'Call MAKEWIND(22, 4, 24, 76, 7, 0, 1, 0, "")
        'LOCATE 22, 5: Print "Vous pouvez vous d‚placer avec les flˆches, Pgup, Pgdown, Home ou Fin"   '    FIRE1.BAS: INPUTPHYSICALPROPERTY
        'LOCATE 23, 5: Print "Ceux qui n'ont pas un clavier ‚tendu (102 touches) peuvent passer d'un"
        'LOCATE 24, 5: Print "champ … l'autre en frappant ÄÄÙ ";
        'Return

        '           Remplissage du tableau PPCOEFF()

        'If IA0 = 1 Then Erase optn$: Exit Function
        NonCresc = E365(3) <= E365(1) Or (E365(5) <= E365(3) And E365(5) > 0) Or (E365(7) <= E365(5) And E365(7) > 0)
        NonCresc = NonCresc Or E365(11) <= E365(9) Or (E365(13) <= E365(11) And E365(13) > 0)
        NonCresc = NonCresc Or E365(17) <= E365(15) Or (E365(19) <= E365(17) And E365(19) > 0)
        'If E365(3) <= E365(1) Or E365(5) <= E365(3) Or E365(7) <= E365(5) Or E365(11) <= E365(9) Or E365(13) <= E365(11) Or E365(17) <= E365(15) Or E365(19) <= E365(17) Then
        If NonCresc Then
            Call NONCROISSANT() : Exit Function ' GoTo debutPP
        End If
        If (Ifluide = 1 And E365(23) <= E365(21)) Or (Ifluide = 1 And E365(25) <= E365(23) And E365(25) > 0) Then
            Call NONCROISSANT() : Exit Function ' GoTo debutPP
        End If
        If (Ifluide = 2 And E365(21) <= -270) Or (Ifluide = 2 And E365(22) <= 0) Or (Ifluide = 2 And E365(23) <= 0) Then
            Call ERREURDENSITE() : Exit Function ' GoTo debutPP
        End If
        VerificaDati = True
        B4 = (E365(4) - E365(2)) / (E365(3) - E365(1))
        B5 = E365(2) - B4 * E365(1)
        If E365(5) = 0 Then
            B6 = B4
            B7 = B5
        Else
            B6 = (E365(6) - E365(4)) / (E365(5) - E365(3))
            B7 = E365(4) - B6 * E365(3)
        End If
        If E365(7) = 0 Then
            B8 = B4
            B9 = B5
        Else
            B8 = (E365(8) - E365(6)) / (E365(7) - E365(5))
            B9 = E365(6) - B8 * E365(5)
        End If

        PPCOEFF(1) = E365(3) : PPCOEFF(2) = B4
        PPCOEFF(3) = B5 : PPCOEFF(4) = E365(5)
        PPCOEFF(5) = B6 : PPCOEFF(6) = B7 : PPCOEFF(7) = B8 : PPCOEFF(8) = B9

        B4 = (E365(12) - E365(10)) / (E365(11) - E365(9))
        B5 = E365(10) - B4 * E365(9)
        If E365(13) > 0 Then
            B6 = (E365(14) - E365(12)) / (E365(13) - E365(11))
            B7 = E365(12) - B6 * E365(11)
        Else
            B6 = B4
            B7 = B5
        End If

        PPCOEFF(9) = E365(11) : PPCOEFF(10) = B4
        PPCOEFF(11) = B5 : PPCOEFF(12) = B6 : PPCOEFF(13) = B7

        B4 = (E365(18) - E365(16)) / (E365(17) - E365(15))
        B5 = E365(16) - B4 * E365(15)
        If E365(19) = 0 Then
            B6 = B4
            B7 = B5
        Else
            B6 = (E365(20) - E365(18)) / (E365(19) - E365(17))
            B7 = E365(18) - B6 * E365(17)
        End If

        PPCOEFF(14) = E365(17) : PPCOEFF(15) = B4
        PPCOEFF(16) = B5 : PPCOEFF(17) = B6 : PPCOEFF(18) = B7

        If Ifluide = 2 And E365(23) > 0 Then
            Config.PesoMoc = E365(22) * 22.4 * (273.15 + E365(21)) * 1.01325 / 273.15 / E365(23) ' pseudo poids mol‚culaire
            PPCOEFF(19) = Config.PesoMoc
            PPCOEFF(20) = -999 : PPCOEFF(21) = -999 : PPCOEFF(22) = -999 : PPCOEFF(23) = -999 : E365(26) = -999
        Else
            B4 = (E365(24) - E365(22)) / (E365(23) - E365(21))
            B5 = E365(22) - B4 * E365(21)
            If E365(25) > 0 Then
                B6 = B4
                B7 = B5
            Else
                B6 = (E365(26) - E365(24)) / (E365(25) - E365(23))
                B7 = E365(24) - B6 * E365(23)
            End If
            PPCOEFF(19) = E365(17) : PPCOEFF(20) = B4
            PPCOEFF(21) = B5 : PPCOEFF(22) = B6 : PPCOEFF(23) = B7
        End If
    End Function
    Public Sub NONCROISSANT()
        Dim Testo As String = "Pour chaque propriété physique entrez les températures en ordre croissant"
        MsgBox(Testo)
    End Sub
    Public Sub ERREURDENSITE()
        Dim Testo As String = "Erreur dans les donn‚es pour le calul de la densit‚"
        MsgBox(Testo)
    End Sub
    Public Sub ConvUnit()
        Dim i, var As Short
        With mioApert
            For i = 0 To 12
                Select Case i
                    Case 0 To 3 : var = 1
                    Case 4 To 6 : var = 2
                    Case 7 To 9 : var = 3
                    Case 10 To 13 : var = 4
                End Select
                .Label6(i).Text = strUnit(Config.iUnit, var)
                .Label7(i).Text = strUnit(Config.iUnit, 6)
            Next
            .Label6(13).Text = strUnit(Config.iUnit, 4)
            .Label7(13).Text = strUnit(Config.iUnit, 6)
            .Label7(14).Text = strUnit(Config.iUnit, 5)
        End With
    End Sub
    Public Function Kactivity() As Single
        Dim molCO, molCO2 As Single
        Select Case Config.Ippgas65
            Case 0
                molCO = ppg1E3(1)
                molCO2 = ppg1E3(5)
            Case 1
                molCO = E365(11)
                molCO2 = E365(12)
            Case Else : Exit Function
        End Select
        If molCO = 0 Then Exit Function
        Kactivity = molCO2 / molCO ^ 2 / Config.Pressione
    End Function
End Class