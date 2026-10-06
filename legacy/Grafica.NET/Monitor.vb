Option Strict Off
Option Explicit On
Friend Class clsMonitor
    Public Smetti As Boolean
    Public WithEvents Motore As RoutBase1.clsMotore
    Public WithEvents AcadDis As AutoCAD.AcadDocument

    Private Sub AcadDis_BeginClose() Handles AcadDis.BeginClose
        'UPGRADE_NOTE: È possibile che l'oggetto AcadDis non venga eliminato finché non venga raccolto nel Garbage Collector. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1029"'
        AcadDis = Nothing
    End Sub

    'UPGRADE_NOTE: Object è stato aggiornato a Object_Renamed. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1061"'
    Private Sub AcadDis_ObjectAdded(ByVal Object_Renamed As Object) Handles AcadDis.ObjectAdded
        ' Dim BlockRef As AutoCAD.AcadBlockReference
        '   Set BlockRef = Object
        ' Debug.Print "Added"; TypeName(Object)
    End Sub

    Private Sub Motore_CancelInput(ByRef f As Short) Handles Motore.CancelInput
        Dim i As Short
        If Not Motore.Chiamante Is Nothing Then If Not Motore.Chiamante Is Me Then Exit Sub
        sezioni = sezvec.Clone
        EditingSezioni = False
        If Not Monitor.Motore.InputForms Is Nothing Then
            For i = Motore.InputForms.Count To 1 Step -1
                Motore.InputForms(i).Dispose()
                Motore.InputForms.Remove(i)
            Next
            'UPGRADE_NOTE: È possibile che l'oggetto Motore.InputForms non venga eliminato finché non venga raccolto nel Garbage Collector. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1029"'
            Motore.InputForms = Nothing
        End If
    End Sub

    Private Sub Motore_dAiuClick(ByRef n As Short, ByRef Index As Short) Handles Motore.dAiuClick
        Dim j As Short
        If Not Motore.Chiamante Is Nothing Then If Not Motore.Chiamante Is Me Then Exit Sub
        Select Case Index
            Case Motore.InputForms.Ninput(1)
                For j = ySez To sezvec.Nsezioni - 1
410:                sezvec.Tipo(j) = sezvec.Tipo(j + 1)
                    sezvec.Quota(j) = sezvec.Quota(j + 1)
                    sezvec.Spost(j) = sezvec.Spost(j + 1)
                    sezvec.Verso(j) = sezvec.Verso(j + 1)
                Next
                sezvec.Nsezioni = sezvec.Nsezioni - 1
                Motore_OkInput(1)
        End Select
    End Sub

    Private Sub Motore_OkInput(ByRef f As Short) Handles Motore.OkInput
        If Not Motore.Chiamante Is Nothing Then If Not Motore.Chiamante Is Me Then Exit Sub
        Registra()
        Ritorna()
    End Sub
    Private Sub Registra()
        If Motore.InputForms Is Nothing Then Return
        Try
            If ySez <= sezvec.Nsezioni Then
                With CType(Motore.InputForms.Item(1), RoutBase1.frmInput)
                    sezvec.Tipo(ySez) = GlobalRoutines.ValVir(.pRisposte(1))
                    sezvec.Quota(ySez) = GlobalRoutines.ValVir(.pRisposte(2))
                    sezvec.Spost(ySez).X = GlobalRoutines.ValVir(.pRisposte(3))
                    sezvec.Spost(ySez).y = GlobalRoutines.ValVir(.pRisposte(4))
                    sezvec.Verso(ySez) = GlobalRoutines.ValVir(.pRisposte(5))
                End With
                If sezvec.Tipo(ySez) < 1 Or sezvec.Tipo(ySez) > 3 Then
                    sezvec.Tipo(ySez) = 1
                    MsgBox("Il tipo può essere 1, 2 o 3", MsgBoxStyle.Critical)
                End If
                If Not (sezvec.Verso(ySez) = -1 Or sezvec.Verso(ySez) = 1) Then
                    sezvec.Verso(ySez) = 1
                    MsgBox("Il verso può essere 1 o -1", MsgBoxStyle.Critical)
                End If
            End If
            sezioni = sezvec
            SalvaSezioni()
            EditingSezioni = False
            SecondaVolta = False
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Private Sub Ritorna()
        Dim i As Short
        If Not Motore.InputForms Is Nothing Then
            For i = Motore.InputForms.Count To 1 Step -1
                Motore.InputForms(i).Dispose()
                'Set Motore.InputForms(i) = Nothing
                Motore.InputForms.Remove(i)
            Next
            Motore.InputForms = Nothing
        End If
    End Sub

    Private Sub Motore_ProgrCancella() Handles Motore.ProgrCancella
        If Not Motore.Chiamante Is Nothing Then If Not Motore.Chiamante Is Me Then Exit Sub
        Smetti = True
    End Sub

    Private Sub Motore_TestoCambia1(ByRef Index As Short) Handles Motore.TestoCambia1
        Dim Help As String
        If Not Motore.Chiamante Is Nothing Then If Not Motore.Chiamante Is Me Then Exit Sub
        Select Case Index
            Case Motore.InputForms.Ninput(1)
                'GoSub Deleta
            Case 1 'Tipo sezione
                Help = "Questo valore è (per ora) immodificabile| e pari a 2 (perp. a ySez)"
                MsgBox(Help)
                CType(Motore.InputForms.Item(1), RoutBase1.frmInput).pRisposte(Index) = Str(sezvec.Tipo(ySez))
            Case 5 'Verso
                '  Help = "Questo valore è pari a -1 o a 1 a seconda| che si proietti a sin. o a dx"
                '  MsgBox Help
            Case Else
                '   Help$ = "Inserisci un valore"
                '   MsgBox Help
        End Select
        Exit Sub
    End Sub
End Class