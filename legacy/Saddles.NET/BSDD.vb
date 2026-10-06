Public Class clsBSDD
    Public Sub New()
        MyBase.New()
        Monitor = New clsMonitor
        BSDD = Me
        myAssembly = Me.GetType.Assembly
        rmHelpStrings = New System.Resources.ResourceManager("Saddles.ProjectResources", myAssembly)
        rmHelpTopics = New System.Resources.ResourceManager("Saddles.HelpTopics", myAssembly)
        GlobalRoutines = New RoutBase1.clsTrigon
30:     ReDim GGD(9)
        ReDim GG1(25)
        ReDim GG2(25)
40:     ReDim KK1(3)
        ReDim KK2(3)
        ReDim ANG(3)
        ANG(1) = 120 : ANG(2) = 135 : ANG(3) = 150
        KK1(1) = 0.107 : KK1(2) = 0.132 : KK1(3) = 0.161
        KK2(1) = 0.192 : KK2(2) = 0.234 : KK2(3) = 0.279
        Problem = New typProblem
        Dim i As Integer
        For i = 0 To 2
            xSupport(i) = New typxSupportItem
            xSupportT(i) = New typxSupportItem
            xFondaItem(i) = New typxFondaItem
        Next
    End Sub
    Public Sub Dispose()
        If Not Monitor Is Nothing Then
            Monitor.Routines = Nothing
            Monitor.Motore = Nothing
        End If
        RadiceHelp = Nothing
        BSDD = Nothing
    End Sub
    Public Function Esegui(ByRef Mode As Short, ByRef icome As String) As Short
        Problem.Initialize()
        Monitor.Motore.Problem.Extension = ".SDD"
        Monitor.Motore.Problem.TipoFile = "Calcolo selle "
        With Monitor.Motore.About
            .ProgName = "* BSSD * local stresses due to the saddles"
            .ProgVers = "Vers. " & myAssembly.GetName.Version.Major.ToString & "." & myAssembly.GetName.Version.Minor.ToString
            Dim Fi As IO.FileInfo = New IO.FileInfo(myAssembly.Location)
            .ProgDate = GlobalRoutines.FormatS(Fi.CreationTime, "dd/MM/yy")
            .ProgDesc = "STRESSES ON HORIZONTAL VESSEL ON TWO SUPPORT SADDLES"
            .Company = "Copyright (c) 2005 SSAP"
            .Esteso1 = "according to PD-5500 G.3.3.2"
            .Esteso2 = " shell not stiffened by rings - saddles welded to the shell "
        End With
        If Monitor.Routines Is Nothing Then
            Monitor.Routines = New RoutBase1.Routines
            Monitor.Routines.Init200(Monitor.Motore.Inizio.Archdir)
        End If
        Monitor.Routines.DoveInizio = Monitor.Motore.Inizio
        frmSaddles.DefInstance.ShowDialog()
    End Function
    Public WriteOnly Property DoveRoutines() As RoutBase1.Routines
        Set(ByVal Value As RoutBase1.Routines)
            Monitor.Routines = Value
        End Set
    End Property
    Public WriteOnly Property DoveMotore() As RoutBase1.clsMotore
        Set(ByVal Value As RoutBase1.clsMotore)
            Monitor.Motore = Value
            Monitor.Motore.InitProb("BSDD")
            RadiceHelp = Value.Inizio.AppLancio & rmHelpStrings.GetString("Helpfile") ' "\BIN\AiutoBSDD.chm"
            Dim InitLibmat As LibMat.clsInitLibMat = New LibMat.clsInitLibMat(Monitor.Motore)
        End Set
    End Property
End Class
