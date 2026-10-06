Option Strict Off
Option Explicit On
Friend Class clsMonitor
    'Public Oggetto As clsBreLoc
	'Public InterrompiTrasferimento As Boolean
    Public WithEvents Motore As RoutBase1.clsMotore
    Public Routines As RoutBase1.Routines
    Public Overloads Function HelpTopic(ByVal id As Integer) As String
        Dim Nome As String = "str" + id.ToString.Trim
        Dim Stringa As String
        Try
            Stringa = rmHelpTopics.GetString(Nome)
            If Stringa Is Nothing Then
                Stringa = ""
            End If
        Catch e As Exception
            Stringa = id.ToString
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
        If Not IO.Path.GetExtension(f).Equals(".BRE") Then Exit Sub
        nomefile = f
        If apri() Then
            With FormApert
                .InApertura = True
                .Aggiorna()
                .InApertura = False
            End With
            With objBre
                .ClientPlant = Motore.Problem.ClientPlant
                .Item = Motore.Problem.Item
                .Author = Motore.Problem.Author
            End With
     End If
    End Sub

    Private Sub Motore_SalvaData(ByRef f As String) Handles Motore.SalvaData
        If Not IO.Path.GetExtension(f).Equals(".BRE") Then Exit Sub
        With objBre
            .ClientPlant = Motore.Problem.ClientPlant
            .Item = Motore.Problem.Item
            .Author = Motore.Problem.Author
        End With
    End Sub
    Private Sub Motore_Rifiuto() Handles Motore.Rifiuto
        If Not Motore.Problem.Extension.Equals(".BRE") Then Exit Sub
        Try
            FormApert.menChiudi_Click(Me, New System.EventArgs)
        Catch e As Exception
        End Try
    End Sub

    Private Sub Motore_SondaFile(ByVal f As String) Handles Motore.SondaFile
        If objBre Is Nothing Then Exit Sub
        If Not IO.Path.GetExtension(f).Equals(".BRE") Then Exit Sub
        nomefile = f
        '  With objBre
        ' .ClientPlant = Motore.Problem.ClientPlant
        ' .Item = Motore.Problem.Item
        ' .Author = Motore.Problem.Author
        ' End With
        If apri() Then
            With objBre
                Motore.Problem.ClientPlant = .ClientPlant
                Motore.Problem.Item = .Item
                Motore.Problem.Author = .Author
            End With
        End If

    End Sub
End Class