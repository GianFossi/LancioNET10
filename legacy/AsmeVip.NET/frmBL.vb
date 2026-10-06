Public Class frmBL
    Private Sub frmBL_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        _cmbCil_0.Items.Clear()
        _cmbCil_0.Items.Add("Breech-Lock closure HH")
        _cmbCil_0.Text = Involucr(kLato, jInvolucr).Mark
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        Hide()
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Hide()
    End Sub
End Class