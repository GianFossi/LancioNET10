Option Strict Off
Option Explicit On
Friend Class clsMonitor
    Public Oggetto As Calc_Orecchia
    Public InterrompiTrasferimento As Boolean
    Public WithEvents Motore As RoutBase1.clsMotore
    Public Routines As RoutBase1.Routines
    Private Sub Motore_ProgrFine(ByRef F As Boolean)
        If Not F Then InterrompiTrasferimento = True
    End Sub
    Private Sub Motore_Cambiofile(ByRef f As String) Handles Motore.Cambiofile
        If Monitor.Oggetto Is Nothing Then Exit Sub
        nomefile = f
        Motore.Problem.ClientPlant = Problem.ClientPlant
        Motore.Problem.Doc = Problem.Doc
        Motore.Problem.Item = Problem.Item
        Motore.Problem.Author = Problem.Author
        If Not Leggi() Then f = "" : Exit Sub
        InserDati_1.DefInstance.Text = GlobalRoutines.StringaInformativaProgramma(myAssembly) & " " & nomefile
    End Sub
    Private Sub Motore_SalvaData(ByRef f As String) Handles Motore.SalvaData
        If Monitor.Oggetto Is Nothing Then Exit Sub
        Problem.ClientPlant = Motore.Problem.ClientPlant
        Problem.Doc = Motore.Problem.Doc
        Problem.Item = Motore.Problem.Item
        Orecchia.Sigla = Problem.Item
        Problem.Author = Motore.Problem.Author
        nomefile = f
        Salva()
    End Sub

    Private Sub Motore_ProgrCancella() Handles Motore.ProgrCancella
        Interrompi = True
    End Sub
End Class