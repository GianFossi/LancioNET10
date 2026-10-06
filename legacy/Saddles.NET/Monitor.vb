Option Strict On
Option Explicit On
Friend Class clsMonitor
    Public WithEvents Motore As RoutBase1.clsMotore
    Public Routines As RoutBase1.Routines
    Public Sub New()
        MyBase.New()
        'Motore = New RoutBase1.clsMotore
    End Sub
    Private Sub Motore_Cambiofile(ByRef f As String) Handles Motore.Cambiofile
        If BSDD Is Nothing Then Exit Sub
        FileData = f
        Call ChiudiExcel()
        Motore.Problem.ClientPlant = Problem.ClientPlant
        Motore.Problem.Doc = Problem.Doc
        Motore.Problem.Item = Problem.Item
        Motore.Problem.Author = Problem.Author
        If Not LeggiData() Then f = "" : Exit Sub
        InitTables()
        IniziaBocchelli()
        IniziaVento()
        RicalcolaVento()
        IniziaSisma()
        RicalcolaSisma()
        IniziaBocchelliT()
        IniziaVentoT()
        RicalcolaVentoT()
        IniziaSismaT()
        RicalcolaSismaT()
        With frmSaddles.DefInstance
            .Text = GlobalRoutines.StringaInformativaProgramma(myAssembly) & " " & FileData
            .TabPrimoLivDown.Enabled = True
            .TabPrimoLivDown.Invalidate(False)
            .TabPrimoLivDown.Update()
            .TabMain.Enabled = True
            .TabMain.Invalidate(False)
            .TabMain.Update()
            .TabCarichiDown.Enabled = True
            .TabCarichiDown.Invalidate(False)
            .TabCarichiDown.Update()
            If .TabPrimoLivDown.SelectedIndex <> 0 Then
                .TabPrimoLivDown.SelectedIndex = 0
            Else
                .CambiaPagina(0)
            End If
        End With
    End Sub
    Private Sub Motore_SalvaData(ByRef f As String) Handles Motore.SalvaData
        If BSDD Is Nothing Then Exit Sub
        Problem.ClientPlant = Motore.Problem.ClientPlant
        Problem.Doc = Motore.Problem.Doc
        Problem.Item = Motore.Problem.Item
        Problem.Author = Motore.Problem.Author
        Problem.Verbose = frmSaddles.DefInstance.mnuVerb.Checked
        FileData = f
        SaveData()
    End Sub
    Private Sub Motore_ProgrCancella() Handles Motore.ProgrCancella
        Interrompi = True
    End Sub

    Private Sub Motore_Uccidi(ByVal f As String) Handles Motore.Uccidi
        If BSDD Is Nothing Then Exit Sub
        Kill(f)
    End Sub
    Private Sub Motore_NuovoLav(ByRef f As String) Handles Motore.NuovoLav
        If BSDD Is Nothing Then Exit Sub
        Problem.ClientPlant = Motore.Problem.ClientPlant
        Problem.Doc = Motore.Problem.Doc
        Problem.Item = Motore.Problem.Item
        Problem.Author = Motore.Problem.Author
        Problem.Verbose = frmSaddles.DefInstance.mnuVerb.Checked
        FileData = f
        SaveData()
    End Sub
    Private Sub Motore_SondaFile(ByVal f As String) Handles Motore.SondaFile
        sonda = True
        FileData = f
        If Not LeggiData() Then f = "" : Exit Sub
        Motore.Problem.ClientPlant = Problem.ClientPlant
        Motore.Problem.Doc = Problem.Doc
        Motore.Problem.Item = Problem.Item
        Motore.Problem.Author = Problem.Author
        sonda = False
    End Sub
End Class