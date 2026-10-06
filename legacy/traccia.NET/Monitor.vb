Option Strict Off
Option Explicit On 
Friend Class clsMonitor
    Public Routines As RoutBase1.Routines
    Public InterrompiTrasferimento As Boolean
    Public WithEvents Motore As RoutBase1.clsMotore
    Private Sub Motore_ProgrFine(ByRef f As Boolean)
        If Tracciatura Is Nothing Then Exit Sub
        If Not f Then InterrompiTrasferimento = True
        iAction = 0
    End Sub
    Private Sub Motore_Cambiofile(ByRef f As String) Handles Motore.Cambiofile
        Dim nome As String
        If Tracciatura Is Nothing Then Exit Sub
        InitDaTos()
        gencommes = f.Substring(0, f.Length - 4)
        nome = gencommes
        Tracciatura.Modo = 1
        Try
            If Not Loadd() Then Exit Sub 'Carica icome
        Catch e As Exception
            MsgBox(e.Message & "all'apertura del file " & gencommes)
            gencommes = ""
            nome = "nessuno"
        End Try
        MainForm.Text = GlobalRoutines.StringaInformativaProgramma(Reflection.Assembly.GetExecutingAssembly) & nome
        MainForm.AggSecondaPagina()
    End Sub
    Private Sub Motore_NuovoLav(ByRef f As String) Handles Motore.NuovoLav
        If Tracciatura Is Nothing Then Exit Sub
        gencommes = Left(f, Len(f) - 4)
        SaveAll()
    End Sub
    Private Sub Motore_Rifiuto() Handles Motore.Rifiuto
        ' MainForm.Pagina(0).Value = False
    End Sub
    Private Sub Motore_SalvaData(ByRef f As String) Handles Motore.SalvaData
        If Tracciatura Is Nothing Then Exit Sub
        gencommes = Left(f, Len(f) - 4)
        ' SaveAll()
    End Sub
End Class
