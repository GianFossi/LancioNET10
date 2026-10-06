Option Strict Off
Option Explicit On
Friend Class clsMonitor
    Public WithEvents Motore As RoutBase1.clsMotore
    Public Sub New()
        MyBase.New()
    End Sub
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
    Public Overloads Function HelpTopic(ByVal id As Integer) As String
        Dim Nome As String = "str" + id.ToString.Trim
        Dim Stringa As String
        Try
            Stringa = rmHelpTopics.GetString(Nome)
            If Stringa Is Nothing Then
                Stringa = ""
            End If
        Catch e As Exception
            Stringa = ""
        End Try
        Return Stringa
    End Function
    Public Overloads Function HelpTopic(ByVal id As String) As String
        Dim Nome As String = id.Trim
        Dim Stringa As String
        Try
            Stringa = rmHelpTopics.GetString(Nome)
            If Stringa Is Nothing Then
                Stringa = ""
            End If
        Catch e As Exception
            Stringa = ""
        End Try
        Return Stringa
    End Function
    Private Sub Motore_Cambiofile(ByRef f As String) Handles Motore.Cambiofile
        Dim i As Boolean
        FileData = f
    End Sub
    Private Sub Motore_SalvaData(ByRef f As String) Handles Motore.SalvaData
        '        Problem.ClientPlant = Monitor.Motore.Problem.ClientPlant
        '        Problem.Doc = Monitor.Motore.Problem.Doc
        '        Problem.Item = Monitor.Motore.Problem.Item
        '        SaveData f
    End Sub
End Class