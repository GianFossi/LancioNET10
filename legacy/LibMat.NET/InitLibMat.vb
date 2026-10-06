Public Class clsInitLibMat
    Public Sub New(ByVal Value As RoutBase1.clsMotore)
        If Monitor Is Nothing Then Monitor = New clsMonitor
        If Monitor.Motore Is Nothing Then Monitor.Motore = Value
        Archdir = Value.Inizio.Archdir
        DiscoTem = Value.Inizio.DiscoTem
        If myAssembly Is Nothing Then
            myAssembly = Me.GetType.Assembly
            rmHelpStrings = New _
              System.Resources.ResourceManager("Libmat.Risorse", myAssembly)
        End If
        RadiceHelp = Monitor.Motore.Inizio.AppLancio & rmHelpStrings.GetString("Helpfile")
    End Sub
End Class
