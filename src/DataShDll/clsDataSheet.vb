Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Public Class clsDataSheet
    Public Out As Boolean
    Public Sub Dispose()
        'myAssembly = Nothing
        rmHelpStrings = Nothing
        rmHelpTopics = Nothing
        GlobalRoutines = Nothing
        objIFST = Nothing
        If Not Monitor Is Nothing Then Monitor.Motore = Nothing
        Routines = Nothing
        Monitor = Nothing
        RadiceHelp = Nothing
    End Sub
    Public Sub New()
        MyBase.New()
        Dim ifl, iErr As Short
        Monitor = New clsMonitor
        GlobalRoutines = New RoutBase1.clsTrigon
        myAssembly = Me.GetType.Assembly
        rmHelpStrings = New _
           System.Resources.ResourceManager("DataSheet.ProjectResources", myAssembly)
        objIFST = Me
        rmHelpTopics = New _
        System.Resources.ResourceManager("DataSheet.HelpTopics", myAssembly)
        DataSheet = New RoutBase1.clsDatiDes
    End Sub
    Public Sub EseguiSciolto()
        mioApert = New Apert
        mioApert.Show()
        mioApert.BringToFront()
    End Sub
    Public WriteOnly Property DoveRoutines() As RoutBase1.Routines
        Set(ByVal Value As RoutBase1.Routines)
            Routines = Value
        End Set
    End Property
    Public WriteOnly Property DoveMotore() As RoutBase1.clsMotore
        Set(ByVal Value As RoutBase1.clsMotore)
            Monitor.Motore = Value
            Monitor.Motore.InitProb("ISFT")
            Monitor.Motore.Problem.Extension = ".APR"
            With Monitor.Motore.About
                .ProgName = "IST"
                .ProgVers = myAssembly.GetName.Version.Major.ToString & "." & myAssembly.GetName.Version.Minor.ToString
                Dim Fi As IO.FileInfo = New IO.FileInfo(myAssembly.Location)
                .ProgDate = Format(Fi.CreationTime, "dd/MM/yy")
                .ProgDesc = "Ingegneria Scambiatori di Calore"
                .Company = "Copyright (c) 2005 SSAP"
                .Esteso1 = ""
                .Esteso2 = ""
            End With
            job = New RoutBase1.clsjob(Monitor.Motore)
            RadiceHelp = Monitor.Motore.Inizio.AppLancio & rmHelpStrings.GetString("Helpfile")
            Dim InitLibmat As LibMat.clsInitLibMat = New LibMat.clsInitLibMat(Monitor.Motore)
            LeggiPrefGen()
        End Set
    End Property
    Public WriteOnly Property DoveFunzioni() As Grafica.LibGra
        Set(ByVal Value As Grafica.LibGra)
            Funzioni = Value
            Funzioni.DoveMotore = Monitor.Motore
            Funzioni.DoveRoutines = Routines
        End Set
    End Property
End Class