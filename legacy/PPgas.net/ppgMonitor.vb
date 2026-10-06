Option Strict Off
Option Explicit On
Friend Class ppgMonitor
    Public WithEvents Motore As RoutBase1.clsMotore
    Public Ogg As clsPpg
    Private Sub Motore_ProgrFine(ByRef f As Boolean)
        '  If Not f Then InterrompiTrasferimento = True
    End Sub
    Private Sub Motore_Cambiofile(ByRef f As String) Handles Motore.Cambiofile
        If Not Right(f, 3) = "PPG" Then Exit Sub
        Ogg.FileData = f
        Ogg.Apri()
    End Sub
End Class