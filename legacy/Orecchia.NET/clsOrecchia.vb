Option Strict Off
Option Explicit On
Public Class Calc_Orecchia
    Public Sub Calcola()
        Problem.Initialize()
        Monitor.Motore.Problem.Extension = ".ORE"
        Monitor.Motore.Problem.TipoFile = "Calcolo orecchie di sollevamento "
        With Monitor.Motore.About
            .ProgName = "* Orecchia * ear lugs design"
            .ProgVers = "Vers. " & myAssembly.GetName.Version.Major.ToString & "." & myAssembly.GetName.Version.Minor.ToString
            Dim Fi As IO.FileInfo = New IO.FileInfo(myAssembly.Location)
            .ProgDate = Format(Fi.CreationTime, "dd/MM/yy")
            .ProgDesc = "Lifting lugs design"
            .Company = "Copyright (c) 2005 SSAP"
            .Esteso1 = ""
            .Esteso2 = ""
        End With
        If Monitor.Routines Is Nothing Then
            Monitor.Routines = New RoutBase1.Routines
            Monitor.Routines.Init200(Monitor.Motore.Inizio.Archdir)
        End If
        Monitor.Routines.DoveInizio = Monitor.Motore.Inizio
        InserDati_1.DefInstance.ShowDialog()
    End Sub
    Public WriteOnly Property DoveMotore() As RoutBase1.clsMotore
        Set(ByVal Value As RoutBase1.clsMotore)
            Dim i As Short
            Monitor.Motore = Value
            Dim InitLibmat As LibMat.clsInitLibMat = New LibMat.clsInitLibMat(Monitor.Motore)
            For i = 0 To 4
                Matdim(i) = New LibMat.MaterialeNew1
            Next
            RadiceHelp = Value.Inizio.AppLancio & "\BIN\AiutoOrec.chm"
        End Set
    End Property
    Public WriteOnly Property DoveRoutines() As RoutBase1.Routines
        Set(ByVal Value As RoutBase1.Routines)
            Monitor.Routines = Value
        End Set
    End Property
    Public Sub New()
        MyBase.New()
        Orecchia.initialize()
        GlobalRoutines = New RoutBase1.clsTrigon
        Monitor = New clsMonitor
        Monitor.Oggetto = Me
        myAssembly = Me.GetType.Assembly
        rmHelpStrings = New System.Resources.ResourceManager("Orecchia.ProjectResources", myAssembly)
    End Sub
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class