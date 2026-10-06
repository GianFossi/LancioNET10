Option Strict On
Option Explicit On
Friend Class clsMonitor
    Public InterrompiTrasferimento As Boolean
    Public WithEvents Motore As RoutBase1.clsMotore
    Public clsProblem As RoutBase1.clsProblem
    Public clsInizio As RoutBase1.clsInizio
    Public Routines As RoutBase1.Routines
    Public Sub Dispose()
        Motore = Nothing
        clsProblem = Nothing
        clsInizio = Nothing
        Routines = Nothing
    End Sub
    Private Sub Motore_ProgrFine(ByRef F As Boolean)
        If Not F Then InterrompiTrasferimento = True
    End Sub
    Private Sub Motore_Cambiofile(ByRef f As String) Handles Motore.Cambiofile
        Dim i As Integer
        If objWRCB Is Nothing Then Exit Sub
        objWRCB.commessa = f
        If Not LeggiW(False) Then f = "" : Exit Sub
        Motore.Problem.ClientPlant = job.Comm.Clie
        Motore.Problem.Doc = Config.Docu
        Motore.Problem.Item = job.Comm.Item
        Motore.Problem.Author = job.Comm.Comp
        With Apert.DefInstance
            ._Frames_1.Visible = True
            ._Frames_0.Visible = True
            ._Frames_2.Visible = True
            .PictureBox1.Visible = False
        End With
        AggAlbero()
        For i = 1 To Config.NBocch
            Gia297(i) = False
        Next
        TitoloDoc()
    End Sub
    Private Sub Motore_SalvaData(ByRef f As String) Handles Motore.SalvaData
        If objWRCB Is Nothing Then Exit Sub
        job.Comm.Clie = Motore.Problem.ClientPlant
        Config.Docu = Motore.Problem.Doc
        job.Comm.Item = Motore.Problem.Item
        Config.Item = Motore.Problem.Item
        job.Comm.Comp = Motore.Problem.Author
        objWRCB.commessa = f
        ' SalvaW()
        AggiornaApert()
    End Sub

    Private Sub Motore_Uccidi(ByVal f As String) Handles Motore.Uccidi
        If objWRCB Is Nothing Then Exit Sub
        Kill(f)
        objWRCB.RiRidimens()
        AggiornaApert()
    End Sub

    Private Sub Motore_ProgrCancella() Handles Motore.ProgrCancella
        Interrompi = True
    End Sub

    Private Sub Motore_SondaFile(ByVal f As String) Handles Motore.SondaFile
        If objWRCB Is Nothing Then Exit Sub
        objWRCB.commessa = f
        If Not LeggiW(True) Then f = "" : Exit Sub
        Motore.Problem.ClientPlant = job.Comm.Clie
        Motore.Problem.Doc = Config.Docu
        Motore.Problem.Item = job.Comm.Item
        Motore.Problem.Author = job.Comm.Comp

    End Sub

    Private Sub Motore_NuovoLav(ByRef f As String) Handles Motore.NuovoLav
        If objWRCB Is Nothing Then Exit Sub
        job.Comm.Clie = Motore.Problem.ClientPlant
        Config.Docu = Motore.Problem.Doc
        job.Comm.Item = Motore.Problem.Item
        Config.Item = Motore.Problem.Item
        job.Comm.Comp = Motore.Problem.Author
        objWRCB.commessa = f
        SalvaW()
        AggiornaApert()
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class