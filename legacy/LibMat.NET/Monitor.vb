Option Strict On
Option Explicit On
Friend Class clsMonitor
    Public WithEvents Motore As RoutBase1.clsMotore
    Private Sub Motore_ProgrCancella() Handles Motore.ProgrCancella
        InterrompiWinWord = True
    End Sub
End Class