Option Strict Off
Option Explicit On 
Imports System.io
Imports RoutBase1
Public Class clsWrcb
    Public Sciolto As Boolean
    Public lstRapp As Object
    Public FileScambio As String
    Private icome As String
    Public Sub New()
        MyBase.New()
        Monitor = New clsMonitor
        objWRCB = Me
        myAssembly = Me.GetType.Assembly
        rmHelpStrings = New System.Resources.ResourceManager("WRCB.ProjectResources", myAssembly)
        rmHelpTopics = New System.Resources.ResourceManager("WRCB.HelpTopics", myAssembly)
        globalRoutines = New RoutBase1.clsTrigon
        icome = ""
    End Sub
    Public Sub Dispose()
        lstRapp = Nothing
        Monitor = Nothing
        objWRCB = Nothing
    End Sub
    Public WriteOnly Property dovejob() As clsjob
        Set(ByVal Value As clsjob)
            job = Value
        End Set
    End Property
    Public WriteOnly Property Materiale(ByVal i As Short) As LibMat.MaterialeNew1
        Set(ByVal Value As LibMat.MaterialeNew1)
            Matdim(2 * i - 1) = Value
            Geom(i).ShellMat = Value.MatStr
        End Set
    End Property
    Public WriteOnly Property DoveRoutines() As RoutBase1.Routines
        Set(ByVal Value As RoutBase1.Routines)
            Monitor.Routines = Value
        End Set
    End Property
    Public WriteOnly Property DoveMotore() As clsMotore
        Set(ByVal Value As clsMotore)
            Monitor.Motore = Value
            Monitor.Motore.InitProb("WRCB")
            Monitor.clsProblem = Monitor.Motore.Problem
            Monitor.clsInizio = Monitor.Motore.Inizio
            RadiceHelp = Monitor.Motore.Inizio.AppLancio & rmHelpStrings.GetString("Helpfile") '"\BIN\AiutoWRCB.chm"
            Dim InitLibmat As LibMat.clsInitLibMat = New LibMat.clsInitLibMat(Monitor.Motore)
        End Set
    End Property
    Public Sub Inizia()
        InitWRCB()
    End Sub
    Public Property NBocch() As Short
        Get
            NBocch = Config.NBocch
        End Get
        Set(ByVal Value As Short)
            'Docu    As String * 15
            'Unit(1 To 7) As String * 8
            Config.NBocch = Value
            Ridimens()
            'Chart   As Integer
            'Versione As Integer
        End Set
    End Property
    Public Property EndEffect() As Boolean
        Get
            EndEffect = Config.EndEffect
        End Get
        Set(ByVal Value As Boolean)
            Config.EndEffect = Value '0 SI 1 tecn 2 BR
        End Set
    End Property
    Public Property Item() As String
        Get
            Item = Config.Item
        End Get
        Set(ByVal Value As String)
            Config.Item = Value '0 SI 1 tecn 2 BR
            job.Comm.NumAs = 1
            job.Comm.Ind.Item(1).Data.Assieme = Value
        End Set
    End Property
    Public Property commessa() As String
        Get
            commessa = icome
        End Get
        Set(ByVal Value As String)
            icome = Trim(Value)
            If Monitor.Motore.Inizio.LavoriSciolti Then
                job.Comm.Arch = "______"
                job.Contratto = "____"
            Else
                job.Comm.Arch = Monitor.Motore.Inizio.CommPulita(icome)
                If job.Comm.Arch.Length >= 4 Then job.Contratto = job.Comm.Arch.Substring(0, 4) Else job.Contratto = "____"
            End If
        End Set
    End Property
    Public WriteOnly Property Cliente() As String
        Set(ByVal Value As String)
            job.Comm.Clie = Trim(Value)
        End Set
    End Property
    Public Property ConvSumm() As Short
        Get
            ConvSumm = Config.ConvSumm
        End Get
        Set(ByVal Value As Short)
            Config.ConvSumm = Value
        End Set
    End Property
    Public Property Verbose() As Short
        Get
            Verbose = Config.Verbose
        End Get
        Set(ByVal Value As Short)
            If Value <> 0 Then Value = 1
            Config.Verbose = Value
        End Set
    End Property
    Public Property Ammiss() As Short
        Get
            Ammiss = Config.Ammiss
        End Get
        Set(ByVal Value As Short)
            Config.Ammiss = Value '0 SI 1 tecn 2 BR
        End Set
    End Property
    Public Property UnitSis() As Short
        Get
            UnitSis = Config.UnitSis
        End Get
        Set(ByVal Value As Short)
            Config.UnitSis = Value '0 SI 1 tecn 2 BR
            ConfigString()
        End Set
    End Property
    Public Property WRC297() As Short
        Get
            WRC297 = Config.WRC297
        End Get
        Set(ByVal Value As Short)
            Config.WRC297 = Value '0 SI 1 tecn 2 BR
        End Set
    End Property
    Public Property Reduced() As Short
        Get
            Reduced = Config.Reduced
        End Get
        Set(ByVal Value As Short)
            Config.Reduced = Value '0 SI 1 tecn 2 BR
        End Set
    End Property
    Public Property Casi() As Short
        Get
            Casi = Config.Casi
        End Get
        Set(ByVal Value As Short)
            Config.Casi = Value
        End Set
    End Property
    Public Property Note() As Short
        Get
            Note = Config.Note
        End Get
        Set(ByVal Value As Short)
            Config.Note = Value
        End Set
    End Property
    Public Property Analisi() As Short
        Get
            Analisi = Config.Analisi
        End Get
        Set(ByVal Value As Short)
            Config.Analisi = Value 'solo shell 1 tutte 2 solo nozzle
        End Set
    End Property
    Public Property Mark(ByVal i As Short) As String
        Get
            Mark = Geom(i).Mark
        End Get
        Set(ByVal Value As String)
            Geom(i).Mark = Value
            '  RC As Single
            '  D1 As Single
            '  D2 As Single
            '  ShellMat As String * 25
            '  NozzMat  As String * 25
            '  kS       As Single
            '  T As Single
            '  RI As Single
            '  R As Single
            '  RO As Single
            '  RM As Single
            '  RN As Single
            '  Carichi(1 To 4) As CarichiOld
            '  Lato As Integer '1 lato tubi 2 lato mantello
            '  Ind As Integer  'ind di RecAPR
            '  BS35434 As Integer
            '  D1Rinf As Single
            '  D2Rinf As Single
            '  Pad(0)  As Single  'era 1
            '  Casi As Integer
            '  IndiceB As Integer
            '  IndiceC  As Integer 'indice in RecAPR
            '  iB(1 To 4) As Integer 'nearest nozzles in Q1,Q2,Q3,Q4
            '  Dist(1 To 4) As Single
        End Set
    End Property
    Public Property Size(ByVal i As Short) As String
        Get
            Return Geom(i).Size
        End Get
        Set(ByVal Value As String)
            Geom(i).Size = Value
        End Set
    End Property
    Public Property Asa(ByVal i As Short) As Short
        Get
            Asa = CShort(Geom(i).Size)
        End Get
        Set(ByVal Value As Short)
            Geom(i).Asa = Value '1,2,3,4,5,6,7
        End Set
    End Property
    Public Property ShellType(ByVal i As Short) As Short
        Get
            ShellType = Geom(i).ShellType
        End Get
        Set(ByVal Value As Short)
            Geom(i).ShellType = Value '0Cyl 1 Sphe
        End Set
    End Property
    Public Property Buco(ByVal i As Short) As Short
        Get
            Buco = Geom(i).Buco
        End Get
        Set(ByVal Value As Short)
            Geom(i).Buco = Value '0Cyl 1 Sphe
        End Set
    End Property
    Public Property Forma(ByVal i As Short) As Short
        Get
            Forma = Geom(i).Forma
        End Get
        Set(ByVal Value As Short)
            Geom(i).Forma = Value '0Cyl 1 Sphe
        End Set
    End Property
    Public Property Incluso(ByVal i As Short) As Short
        Get
            Incluso = Geom(i).Incluso
        End Get
        Set(ByVal Value As Short)
            Geom(i).Incluso = Value '0Cyl 1 Sphe
        End Set
    End Property
    Public Property Rinforzo(ByVal i As Short) As Short
        Get
            Rinforzo = Geom(i).Rinforzo
        End Get
        Set(ByVal Value As Short)
            Geom(i).Rinforzo = Value '0Cyl 1 Sphe
        End Set
    End Property
    Public Property di(ByVal i As Short) As Single
        Get
            di = Geom(i).di
        End Get
        Set(ByVal Value As Single)
            Geom(i).di = Value '0Cyl 1 Sphe
        End Set
    End Property
    Public Property RC(ByVal i As Short) As Single
        Get
            RC = Geom(i).RC
        End Get
        Set(ByVal Value As Single)
            Geom(i).RC = Value
        End Set
    End Property
    Public Property ShellT(ByVal i As Short) As Single
        Get
            ShellT = Geom(i).ShellT
        End Get
        Set(ByVal Value As Single)
            Geom(i).ShellT = Value '0Cyl 1 Sphe
        End Set
    End Property
    Public Property Padd(ByVal i As Short) As Single
        Get
            Padd = Geom(i).Padd
        End Get
        Set(ByVal Value As Single)
            Geom(i).Padd = Value '0Cyl 1 Sphe
        End Set
    End Property
    Public Property PadT(ByVal i As Short) As Single
        Get
            PadT = Geom(i).PadT
        End Get
        Set(ByVal Value As Single)
            Geom(i).PadT = Value '0Cyl 1 Sphe
        End Set
    End Property
    Public Property R0(ByVal i As Short) As Single
        Get
            R0 = Geom(i).R0
        End Get
        Set(ByVal Value As Single)
            Geom(i).R0 = Value
        End Set
    End Property
    Public Property RX(ByVal i As Short) As Single
        Get
            RX = Geom(i).RX
        End Get
        Set(ByVal Value As Single)
            Geom(i).RX = Value
        End Set
    End Property
    Public Property T0(ByVal i As Short) As Single
        Get
            T0 = Geom(i).T0
        End Get
        Set(ByVal Value As Single)
            Geom(i).T0 = Value
        End Set
    End Property
    Public Property TX(ByVal i As Short) As Single
        Get
            TX = Geom(i).TX
        End Get
        Set(ByVal Value As Single)
            Geom(i).TX = Value
        End Set
    End Property
    Public Property Corr(ByVal i As Short) As Single
        Get
            Corr = Geom(i).Corr
        End Get
        Set(ByVal Value As Single)
            Geom(i).Corr = Value
        End Set
    End Property
    Public Property CorrN(ByVal i As Short) As Single
        Get
            CorrN = Geom(i).CorrN
        End Get
        Set(ByVal Value As Single)
            Geom(i).CorrN = Value
        End Set
    End Property
    Public Property CylL(ByVal i As Short) As Single
        Get
            CylL = Geom(i).CylL
        End Get
        Set(ByVal Value As Single)
            Geom(i).CylL = Value
        End Set
    End Property
    Public Property Cyld(ByVal i As Short) As Single
        Get
            Cyld = Geom(i).Cyld
        End Get
        Set(ByVal Value As Single)
            Geom(i).Cyld = Value
        End Set
    End Property
    Public Property DiaN(ByVal i As Short) As Single
        Get
            DiaN = Geom(i).DiaN
        End Get
        Set(ByVal Value As Single)
            Geom(i).DiaN = Value
        End Set
    End Property
    Public Property Sporg(ByVal i As Short) As Single
        Get
            Sporg = Geom(i).Sporg
        End Get
        Set(ByVal Value As Single)
            Geom(i).Sporg = Value
        End Set
    End Property
    Public Property Pressione(ByVal i As Short, ByVal j As Short) As Single
        Get
            Pressione = Geom(i).Carichi(j).DesPress
        End Get
        Set(ByVal Value As Single)
            Geom(i).Carichi(j).DesPress = Value
        End Set
    End Property
    Public Property Temper(ByVal i As Short, ByVal j As Short) As Single
        Get
            Temper = Geom(i).Carichi(j).DesTemp
        End Get
        Set(ByVal Value As Single)
            Geom(i).Carichi(j).DesTemp = Value
        End Set
    End Property
    Public Property CaseDesc(ByVal i As Short, ByVal j As Short) As String
        Get
            CaseDesc = Geom(i).Carichi(j).CaseDescription
        End Get
        Set(ByVal Value As String)
            Geom(i).Carichi(j).CaseDescription = Value
        End Set
    End Property
    Public Sub EseguiSciolto()
        Call InitWRCB()
        Sciolto = True
        AddDistinta = 0
        job = New RoutBase1.clsjob(Monitor.Motore)
        job.Comm.NumAs = 0
        job.AggiungiCom("Sciolt")
        job.Comm.Ind.Item(1).Data.File = "$"
        job.Comm.peso = 0.0!
        Apert.DefInstance.Show()
    End Sub
    Public Sub Ridimens()
        Dim i, j As Integer
        Try
            Config.initialize()
            If UBound(Geom) > Config.NBocch Then Exit Sub
            ReDim Preserve Geom(Config.NBocch)
            ReDim Preserve StressLim(4, Config.NBocch)
            ReDim Preserve Gia297(Config.NBocch)
            ReDim Preserve Result(2, 6, Config.NBocch)
            ReDim Preserve Resultv(2, 6, Config.NBocch)
            ReDim Preserve Matdim(2 * Config.NBocch)
            ReDim Preserve IntersLoc(Config.NBocch)
            ReDim Fact(Config.NBocch)
            ReDim Factk(Config.NBocch)
            For i = 1 To Config.NBocch
                Geom(i).Initialize(False)
                For j = 1 To 4
                    StressLim(j, i).Initialize()
                Next
            Next
            For i = 1 To 2 * Config.NBocch
                If Matdim(i) Is Nothing Then
                    Matdim(i) = New LibMat.MaterialeNew1
                End If
            Next
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Public Sub RiRidimens()
        Dim i, j As Integer
        Try
            Config.NBocch = 1
            ReDim Geom(Config.NBocch)
            ReDim StressLim(4, Config.NBocch)
            ReDim Gia297(Config.NBocch)
            ReDim Result(2, 6, Config.NBocch)
            ReDim Resultv(2, 6, Config.NBocch)
            ReDim Matdim(2 * Config.NBocch)
            ReDim IntersLoc(Config.NBocch)
            ReDim Fact(Config.NBocch)
            ReDim Factk(Config.NBocch)
            For i = 1 To Config.NBocch
                Geom(i).Initialize(True)
                For j = 1 To 4
                    StressLim(j, i).Initialize()
                Next
            Next
            For i = 1 To 2 * Config.NBocch
                If Matdim(i) Is Nothing Then
                    Matdim(i) = New LibMat.MaterialeNew1
                End If
            Next
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Public Sub EseguiDaAsme(ByRef c As Short, ByVal A As Grafica.clsApparecchio)
        Dim i As Short
        Sciolto = False
        Apparecchio = A
        AddDistinta = 0
        '    job.comm.arch = icome
        job.Comm.NumAs = 0
        With job.Comm.Ind
            For i = 1 To .Count
                .Item(i).Data.File = " "
                .Item(i).Data.pag = 0
                ' Lav(0).Ind(i) = 0
                .Item(i).Data.Assieme = New String(" ", 30)
                .Item(i).Data.Qta = 0
            Next i
            .Item(1).Data.File = "$"
        End With
        job.Comm.peso = 0.0!
        If FileSt = "" Then
            TitoloDoc()
        Else
            Apert.DefInstance.Text1.Text = FileSt
        End If
        Apert.DefInstance.Check1.CheckState = c
        Apert.DefInstance.Check1.Enabled = False
        Apert.DefInstance.Show()
    End Sub
    Public Sub EseguiAutom()
    End Sub
    Public Sub Appendi(ByRef F As String)
        FileSt = F
        Monitor.Motore.Problem.FileStream = New StreamWriter(F, True)
        Apert.DefInstance.Text1.Text = F
    End Sub

    Protected Overrides Sub Finalize()
        Monitor = Nothing
        MyBase.Finalize()
    End Sub
End Class