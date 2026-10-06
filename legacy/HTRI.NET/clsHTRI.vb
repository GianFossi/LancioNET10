Public Class clsHTRI
    Public Sub Esegui()
        Apert = New frmHTRI
        Apert.ShowDialog()
    End Sub
    Public Sub New()
        Monitor = New clsMonitor
        FormMsg = New frmMsg
        myAssembly = Me.GetType.Assembly
        ' rmTestiAsmeVip = New _
        '  System.Resources.ResourceManager("HTRI.TestiAsmeVip", myAssembly)
        rmHelpStrings = New _
          System.Resources.ResourceManager("HTRI.ProjectResources", myAssembly)
        rmHelpTopics = New _
          System.Resources.ResourceManager("HTRI.HelpTopics", myAssembly)
        GlobalRoutines = New RoutBase1.clsTrigon
        objHTRI = Me
        objBWG = New LibMat.clsBWG
    End Sub
    Public WriteOnly Property DoveRoutines() As RoutBase1.Routines
        Set(ByVal Value As RoutBase1.Routines)
            Routines = Value
        End Set
    End Property
    Public WriteOnly Property DoveFunzioni() As Grafica.LibGra
        Set(ByVal Value As Grafica.LibGra)
            Funzioni = Value
        End Set
    End Property
    Public WriteOnly Property DoveMotore() As RoutBase1.clsMotore
        Set(ByVal Value As RoutBase1.clsMotore)
            Monitor.Motore = Value
            Monitor.Motore.InitProb("HTRI")
            RadiceHelp = Monitor.Motore.Inizio.AppLancio & rmHelpStrings.GetString("Helpfile") '"\BIN\AsmeVip.chm"
            Dim InitLibmat As LibMat.clsInitLibMat = New LibMat.clsInitLibMat(Monitor.Motore)
        End Set
    End Property
    Public Sub Dispose()
        Routines = Nothing
        Funzioni = Nothing
    End Sub
End Class
