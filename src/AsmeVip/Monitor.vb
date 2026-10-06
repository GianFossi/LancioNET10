Option Strict Off
Option Explicit On
Friend Class clsMonitor
    Public WithEvents Motore As RoutBase1.clsMotore
    Private Sub Motore_Finito(ByRef p As String) Handles Motore.Finito
        Select Case p
            Case "WRCB"
                If Not objWRCB Is Nothing Then
                    If Len(objWRCB.FileScambio) > 0 Then
                        FileSt = objWRCB.FileScambio
                        mioApert.Text1.Text = FileSt
                        Monitor.Motore.Problem.FileStream = New IO.StreamWriter(FileSt, True)
                    End If
                    objWRCB.Dispose()
                    objWRCB = Nothing
                End If
        End Select
        If Not mioApert Is Nothing Then mioApert.Enabled = True
    End Sub
    Private Sub Motore_ProgrCancella() Handles Motore.ProgrCancella
        InterrompiMAWP = True
    End Sub

    Private Sub Motore_Cambiofile(ByRef f As String) Handles Motore.Cambiofile
        Dim junk As DialogResult
        icome = f
        Call Design(junk, False)
        If junk = DialogResult.No Then f = 0 : Exit Sub
        Motore.Problem.ClientPlant = job.Comm.Clie
        Motore.Problem.Doc = ""
        Motore.Problem.Item = job.Comm.Item
        Config(0).Item = job.Comm.Item
        Motore.Problem.Author = job.Comm.Comp
    End Sub

    Private Sub Motore_SalvaData(ByRef f As String) Handles Motore.SalvaData
        job.Comm.Clie = Motore.Problem.ClientPlant
        'Config.Docu = Motore.Problem.Doc
        Config(0).Item = Motore.Problem.Item
        job.Comm.Item = Motore.Problem.Item
        job.Comm.Comp = Motore.Problem.Author
        icome = f
        ' SalvaU()
    End Sub

    Private Sub Motore_Rifiuto() Handles Motore.Rifiuto
        Try
            mioApert.mnuChiudi_Click(Me, New System.EventArgs)
        Catch e As Exception
        End Try
    End Sub

    Private Sub Motore_SondaFile(ByVal f As String) Handles Motore.SondaFile
        Dim junk As DialogResult
        icome = f
        job.Comm.Arch = clsInizio.CommPulita(icome)
        job.Comm.Clie = "_________"
        job.Comm.Item = "_________"
        Call Design(junk, True)
        If junk = DialogResult.No Then f = 0 : Exit Sub
        Motore.Problem.ClientPlant = job.Comm.Clie
        Motore.Problem.Doc = ""
        Motore.Problem.Item = job.Comm.Item
        Motore.Problem.Author = job.Comm.Comp
    End Sub

    Private Sub Motore_NuovoLav(ByRef f As String) Handles Motore.NuovoLav
        job.Comm.Clie = Motore.Problem.ClientPlant
        Config(0).Item = Motore.Problem.Item
        job.Comm.Item = Motore.Problem.Item
        job.Comm.Comp = Motore.Problem.Author
        icome = f
        SalvaU()
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

    Private Sub Motore_Uccidi(ByVal f As String) Handles Motore.Uccidi
        mioApert.mnuChiudi_Click(mioApert, New EventArgs)
        IO.File.Delete(f)
    End Sub
End Class