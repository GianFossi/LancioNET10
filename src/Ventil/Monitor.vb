Option Strict Off
Option Explicit On
Friend Class clsMonitor
    Public objDatBase As RoutBase1.DatBase
    Public Ogg As clsVentil
    Public Dove As Object 'MSComctlLib.ListView
    Public Routines As RoutBase1.Routines
    Public WithEvents Motore As RoutBase1.clsMotore
    Private Sub Motore_Cambiofile(ByRef f As String) Handles Motore.Cambiofile
        If Not Motore.Chiamante Is Nothing Then If Not Motore.Chiamante Is Me Then Exit Sub
    End Sub
    Private Sub Motore_CancelInput(ByRef f As Short) Handles Motore.CancelInput
        Dim i As Short
        If Not Motore.Chiamante Is Nothing Then If Not Motore.Chiamante Is Me Then Exit Sub
        finCurva.Enabled = True
        If Not Motore.InputForms Is Nothing Then
            For i = Motore.InputForms.Count To 1 Step -1
                Motore.InputForms.Remove(i)
            Next
            Motore.InputForms = Nothing
        End If
        'Apert.Enabled = True
        FaseDati = -1
        OKDati = False
        'AppActivate Apert.Caption
    End Sub

    Private Sub Motore_ComboClick1(ByRef Index As Short) Handles Motore.ComboClick1
        Dim i As Short
        Select Case FaseDati
            Case 1
                If Index = 3 Then
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Motore.inputforms().pCombolist. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    UNITA = DirectCast(Motore.inputforms.Item(1), RoutBase1.frmInput).pCombolist(3) + 1
                    If UNITA = 0 Then UNITA = 1
                End If
                If Index = 4 Then
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Motore.inputforms().pCombolist. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    z1 = DirectCast(Motore.inputforms.Item(1), RoutBase1.frmInput).pCombolist(4)
                End If
                If Index = 3 Or Index = 4 Then
                    For i = Motore.inputforms.Count To 2 Step -1
                        Motore.inputforms.Remove(i)
                    Next
                    DueFin()
                End If
        End Select
    End Sub

    Private Sub Motore_ComboClick2(ByRef Index As Short) Handles Motore.ComboClick2
        Select Case FaseDati
            Case 5
        End Select

    End Sub

    Public Sub Motore_OkInput(ByRef j As Short) Handles Motore.OkInput
        Dim i As Short
        If Not Motore.Chiamante Is Nothing Then If Not Motore.Chiamante Is Me Then Exit Sub
        If finCurva Is Nothing Then finCurva = New frmCurva
        finCurva.Enabled = True
        OKDati = False
        Select Case FaseDati
            Case 1
                OKFin1()
                If Not OKFin2() Then Exit Sub
                OKFin3()
                If Not Monitor.Motore.InputForms Is Nothing Then
                    For i = Motore.InputForms.Count To 1 Step -1
                        Motore.InputForms.Remove(i)
                    Next
                    Motore.InputForms = Nothing
                End If
                FaseDati = 0
        End Select
        OKDati = True
        Cambiato = True
        Exit Sub
    End Sub

    Private Sub Motore_OptClick(ByRef f As Short, ByRef i As Short) Handles Motore.OptClick
        If Not Motore.Chiamante Is Nothing Then If Not Motore.Chiamante Is Me Then Exit Sub
        Select Case FaseDati
            Case 2
        End Select
    End Sub

    Private Sub Motore_SalvaData(ByRef f As String) Handles Motore.SalvaData
        If Not Motore.Chiamante Is Nothing Then If Not Motore.Chiamante Is Me Then Exit Sub
        '        SaveData f
    End Sub

    Private Sub Motore_TestoCambia1(ByRef Index As Short) Handles Motore.TestoCambia1
        If Not Motore.Chiamante Is Nothing Then If Not Motore.Chiamante Is Me Then Exit Sub
        Select Case FaseDati
            Case 3
        End Select
    End Sub

    Private Sub Motore_TestoCambia2(ByRef Index As Short) Handles Motore.TestoCambia2
        If Not Motore.Chiamante Is Nothing Then If Not Motore.Chiamante Is Me Then Exit Sub
        Select Case FaseDati
            Case 2
            Case 3
        End Select
    End Sub
End Class