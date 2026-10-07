Option Strict Off
Option Explicit On
Public Class wldMonitor
    Public WithEvents Motore As RoutBase1.clsMotore
    Public Ogg As clsWald

    Private Sub Motore_OkInput(ByRef f As Short) Handles Motore.OkInput
        Dim Nfin, i As Short
        Select Case FaseDati
            Case 1
                If ProblWLD.Tequi = 1 Then
                    Nfin = Nfin + 1
                    For i = 1 To ProblWLD.Npun - 1
                        Tpun(i + 1) = Val(DirectCast(Motore.InputForms.Item(Nfin), RoutBase1.frmInput).pRisposte(i))
                    Next
                End If
                If ProblWLD.Pequi = 1 Then
                    Nfin = Nfin + 1
                    For i = 1 To ProblWLD.Npun - 1
                        Ppun(i + 1) = Val(DirectCast(Motore.InputForms.Item(Nfin), RoutBase1.frmInput).pRisposte(i))
                    Next
                End If
                mioApert.Enabled = True
            Case 2
                '     t = Val(Motore.InputForms(1).pRisposte(1))
                '     If t >= ProblWLD.Tzone(frmDB.EditZone - 1) Or t <= ProblWLD.Tzone(frmDB.EditZone + 1) Then
                '        Beep
                '     Else
                '        ProblWLD.Tzone(frmDB.EditZone) = t
                '        frmDB.Combo1_Click
                '     End If
                '     frmDB.Enabled = True
        End Select
        FaseDati = 0
        For i = Motore.InputForms.Count To 1 Step -1
            CType(Motore.InputForms(i), Form).Dispose()
            Motore.InputForms.Remove(i)
        Next
        Motore.InputForms = Nothing
    End Sub
    Private Sub Motore_CancelInput(ByRef f As Short) Handles Motore.CancelInput
        Dim i As Short
        Select Case FaseDati
            Case 1
                mioApert.Enabled = True
            Case 2
                FormDB.Enabled = True
        End Select
        For i = Motore.InputForms.Count To 1 Step -1
            CType(Motore.InputForms(i), Form).Dispose()
            Motore.InputForms.Remove(i)
        Next
        Motore.InputForms = Nothing
    End Sub
End Class