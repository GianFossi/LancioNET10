Option Strict Off
Option Explicit On
Friend Class frmTipo
	Inherits System.Windows.Forms.Form
    Private Inizializzando As Boolean
    Private UpDown1_0 As Short
	Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
		Hide()
	End Sub
	
	Private Sub frmTipo_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		If Config.Tipo = 0 Then Config.Tipo = 1
        TabControl1.SelectedIndex = Config.Tipo - 1
	End Sub
    Private Sub Text1_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        If Inizializzando Then Exit Sub
        Dim Index As Short = IndexedControls.IndexOf(Text1, eventSender)
        Select Case Index
            Case 0
                If Not _UpDown1_0.Enabled Then Exit Sub
                Config.NCross = Val(Text1(Index).Text)
            Case 1
                If Not _UpDown1_1.Enabled Then Exit Sub
                Config.NCrossCieco = Val(Text1(Index).Text)
        End Select
    End Sub
    Private Sub _UpDown1_0_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles _UpDown1_0.Enter
        UpDown1_0 = _UpDown1_0.Value
    End Sub
    Private Sub _UpDown1_0_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _UpDown1_0.ValueChanged
        If Config.Tipo = 3 And _UpDown1_0.Value Mod 2 = 0 Then
            If _UpDown1_0.Value > UpDown1_0 Then
                _UpDown1_0.Value += 1
            Else
                _UpDown1_0.Value -= 1
            End If
        End If
    End Sub

    Private Sub TabControl1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.Click
        Dim v As Boolean
        v = TabControl1.SelectedIndex = 2 - 1 'con cieca
        Label1(1).Visible = v
        Text1(1).Visible = v
        Label2(1).Visible = v
        _UpDown1_1.Visible = v
        Config.Tipo = TabControl1.SelectedIndex + 1
        _UpDown1_0.Enabled = False
        _UpDown1_1.Enabled = False
        Select Case Config.Tipo
            Case 1
                Label2(0).Text = "(4 nell'esempio)"
                _UpDown1_0.Minimum = 4
                _UpDown1_0.Maximum = 20
                _UpDown1_0.Increment = 2
                If Config.NCross Mod 2 = 1 Then Config.NCross = Config.NCross - 1
            Case 2
                Label2(0).Text = "(2 nell'esempio)"
                _UpDown1_0.Minimum = 2
                _UpDown1_0.Maximum = 12
                _UpDown1_0.Increment = 2
                Label2(1).Text = "(2 nell'esempio)"
                _UpDown1_1.Minimum = 2
                _UpDown1_1.Maximum = 12
                _UpDown1_1.Increment = 2
                If Config.NCross Mod 2 = 1 Then Config.NCross = Config.NCross - 1
                If Config.NCrossCieco Mod 2 = 1 Then Config.NCrossCieco = Config.NCrossCieco - 1
            Case 3
                Label2(0).Text = "(5 nell'esempio)"
                _UpDown1_0.Minimum = 3
                _UpDown1_0.Maximum = 21
                _UpDown1_0.Increment = 2
                If Config.NCross Mod 2 = 0 Then Config.NCross = Config.NCross + 1
                If Config.NCross < _UpDown1_0.Minimum Then Config.NCross = _UpDown1_0.Minimum
                _UpDown1_0.Enabled = True
                _UpDown1_0.Value = Val(CStr(Config.NCross))
                Exit Sub
        End Select
        If Config.NCross < _UpDown1_0.Minimum Then Config.NCross = _UpDown1_0.Minimum
        If Config.NCrossCieco < _UpDown1_1.Minimum Then Config.NCrossCieco = _UpDown1_1.Minimum
        _UpDown1_0.Enabled = True
        _UpDown1_1.Enabled = True
        _UpDown1_0.Value = Config.NCross
        _UpDown1_1.Value = Config.NCrossCieco
    End Sub
End Class