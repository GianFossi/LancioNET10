Option Strict On
Option Explicit On
Friend Class clsMonitor
    Public Oggetto As Serraggio
    Public InterrompiTrasferimento As Boolean
    Public Motore As RoutBase1.clsMotore
    Private Sub Motore_ProgrFine(ByRef fDado As Boolean)
        If Not fDado Then InterrompiTrasferimento = True
    End Sub
    Public Overloads Sub inserisci(ByRef nomecampo As String, ByRef variabile As String)
        Stub.SubstitBookM(nomecampo, variabile)
    End Sub
    Public Overloads Sub inserisci(ByRef nomecampo As String, ByRef variabile As Single)
        Stub.SubstitBookM(nomecampo, variabile.ToString)
    End Sub
    Public Overloads Sub inserisci(ByRef nomecampo As String, ByRef variabile As Integer)
        Stub.SubstitBookM(nomecampo, variabile.ToString)
    End Sub
    Public Overloads Sub inserisci(ByRef nomecampo As String, ByRef variabile As Date)
        Stub.SubstitBookM(nomecampo, variabile.ToString("dd/MMM/yy"))
    End Sub
End Class