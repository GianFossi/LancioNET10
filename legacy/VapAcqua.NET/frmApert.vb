Option Strict Off
Option Explicit On
Friend Class frmApert
	Inherits System.Windows.Forms.Form
    Public obj As clsVapAcqua
    Private Inizializzando As Boolean
	Private Temp, Press As Single
    Private Sub Check1_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Check1.CheckStateChanged
        Dim i As Short
        If Inizializzando Then Exit Sub
        Select Case Check1.CheckState
            Case 0 'non saturo
                Frame1.Visible = False
                Text1(0).Enabled = True
                Text1(1).Enabled = True
            Case 1
                Frame1.Visible = True
                Frame2(0).Visible = True
                Frame2(1).Visible = True
                Option2(0).Checked = True
                Option2_CheckedChanged(Option2.Item(0), New System.EventArgs())
        End Select
        For i = 0 To 11
            Label2(i).Text = ""
        Next
    End Sub
	
	Private Sub cmdCalc_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCalc.Click
        Dim Psat As Single
        If Inizializzando Then Exit Sub
		If Check1.CheckState = 1 Then
			CallVap()
			CallLiq()
        Else
            Select Case Libreria
                Case 0
                    Psat = XSteam.clsXSteam.XSteam("psat_T", Temp)
                Case 1
                    obj.SubPSATT(Psat, Temp)
            End Select
            If Psat < Press Then
                Frame2(0).Visible = True
                Frame2(1).Visible = False
                CallLiq()
            Else
                Frame2(0).Visible = False
                Frame2(1).Visible = True
                CallVap()
            End If
		End If
	End Sub
	
	Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
		Hide()
	End Sub
    Private Sub Option2_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Option2.CheckedChanged
        If Inizializzando Then Exit Sub
        If eventSender.Checked Then
            Dim Index As Short = Option2.GetIndex(eventSender)
            Dim Tempb As Boolean
            Select Case Index
                Case 0 'temp
                    Tempb = Option2(0).Checked
                Case 1 'press
                    Tempb = Not Option2(1).Checked
            End Select
            Select Case Tempb
                Case True
                    Text1(0).Enabled = True
                    Text1(1).Enabled = False
                    Text1_TextChanged(Text1.Item(0), New System.EventArgs())
                Case False
                    Text1(0).Enabled = False
                    Text1(1).Enabled = True
                    Text1_TextChanged(Text1.Item(1), New System.EventArgs())
            End Select
        End If
    End Sub
    Private Sub Text1_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Text1.TextChanged
        Dim Index As Short = Text1.GetIndex(eventSender)
        If Inizializzando Then Exit Sub
        If Not Text1(Index).Enabled Then Exit Sub
        Select Case Index
            Case 0
                Temp = Funzioni.ValVir(Text1(Index).Text)
                If Check1.CheckState = 1 Then
                    If Temp <= 0 Then Exit Sub
                    Select Case Libreria
                        Case 0
                            Press = XSteam.clsXSteam.XSteam("psat_T", Temp)
                        Case 1
                            obj.SubPSATT(Press, Temp)
                    End Select
                    Text1(0).Enabled = False
                    Text1(1).Text = Funzioni.myStr(Press, 4, 2, False)
                    Text1(0).Enabled = True
                    Text1(0).Focus()
                End If
            Case 1
                Press = Funzioni.ValVir(Text1(Index).Text)
                If Check1.CheckState = 1 Then
                    If Press <= 0 Then Exit Sub
                    Select Case Libreria
                        Case 0
                            Temp = XSteam.clsXSteam.XSteam("Tsat_p", Temp)
                        Case 1
                            obj.TSATP(Press, Temp)
                    End Select
                    Text1(1).Enabled = False
                    Text1(0).Text = Funzioni.myStr(Temp, 4, 2, False)
                    Text1(1).Enabled = True
                    Text1(1).Focus()
                End If
        End Select
    End Sub

    Private Sub CallVap()
        Dim h1, H, Cp As Single
        Dim k, E, V As Single
        Select Case Libreria
            Case 0
                If Check1.Checked Then
                    H = XSteam.clsXSteam.XSteam("hV_T", Temp)
                    Cp = 1000 * XSteam.clsXSteam.XSteam("CpV_T", Temp)
                    V = XSteam.clsXSteam.XSteam("vV_T", Temp)
                    k = XSteam.clsXSteam.XSteam("tcV_T", Temp)
                    E = XSteam.clsXSteam.XSteam("my_ph", Press, H)
                Else
                    H = XSteam.clsXSteam.XSteam("h_pT", Press, Temp)
                    Cp = 1000 * XSteam.clsXSteam.XSteam("Cp_pT", Press, Temp)
                    V = XSteam.clsXSteam.XSteam("v_pT", Press, Temp)
                    k = XSteam.clsXSteam.XSteam("tc_pT", Press, Temp)
                    E = XSteam.clsXSteam.XSteam("my_pT", Press, Temp)
                End If
            Case 1
                obj.SubHPTS(Temp, Press, H)
                obj.SubHPTS(Temp + 1, Press, h1)
                Cp = (h1 - H) * 1000
                obj.SubVPTS(Temp, Press, V)
                If V = 0 Then Exit Sub
                obj.SubEPTS(Temp, V, E)
                'obj.SubKPTS Temp, Press, K
                k = obj.Cond67(Temp, Press)
        End Select
        Label2(11).Text = Funzioni.myStr(H, 5, 2, False)
        Label2(10).Text = Funzioni.myStr(Cp, 5, 2, False)
        Label2(9).Text = VB6.Format(V, "#.####E+##")
        Label2(8).Text = VB6.Format(1 / V, "#.####E+##")
        Label2(7).Text = VB6.Format(E, "#.####E+##")
        Label2(6).Text = Funzioni.myStr(k, 1, 5, False)

    End Sub
    Private Sub CallLiq()
        Dim h1, H, Cp As Single
        Dim k, E, V As Single
        Select Case Libreria
            Case 0
                If Check1.Checked Then
                    H = XSteam.clsXSteam.XSteam("hL_T", Temp)
                    Cp = 1000 * XSteam.clsXSteam.XSteam("CpL_T", Temp)
                    V = XSteam.clsXSteam.XSteam("vL_T", Temp)
                    k = XSteam.clsXSteam.XSteam("tcL_T", Temp)
                    E = XSteam.clsXSteam.XSteam("my_ph", Press, H)
                Else
                    H = XSteam.clsXSteam.XSteam("h_pT", Press, Temp)
                    Cp = 1000 * XSteam.clsXSteam.XSteam("Cp_pT", Press, Temp)
                    V = XSteam.clsXSteam.XSteam("v_pT", Press, Temp)
                    k = XSteam.clsXSteam.XSteam("tc_pT", Press, Temp)
                    E = XSteam.clsXSteam.XSteam("my_pT", Press, Temp)
                End If
            Case 1
                obj.SubHPTL(Temp, Press, H)
                obj.SubHPTL(Temp + 1, Press, h1)
                Cp = (h1 - H) * 1000
                obj.SubVPTL(Temp, Press, V)
                obj.SubEPTS(Temp, V, E)
                'obj.SubKPTS Temp, Press, K
                k = obj.CondI(Temp, Press)
        End Select
        Label2(0).Text = Funzioni.myStr(H, 5, 2, False)
        Label2(1).Text = Funzioni.myStr(Cp, 5, 2, False)
        Label2(2).Text = VB6.Format(V, "#.####E+##")
        Label2(3).Text = VB6.Format(1 / V, "#.####E+##")
        Label2(4).Text = VB6.Format(E, "#.####E+##")
        Label2(5).Text = Funzioni.myStr(k, 1, 5, False)
    End Sub

    Private Sub frmApert_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Monitor.Motore.Ammazza("VAPQ")
        Dispose()
    End Sub

    Private Sub frmApert_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked Then Libreria = 0 Else Libreria = 1
        If Option2(0).Checked Then
            Text1_TextChanged(Me._Text1_0, New System.EventArgs)
        Else
            Text1_TextChanged(Me._Text1_1, New System.EventArgs)
        End If
        cmdCalc_Click(Me, New System.EventArgs)
    End Sub

    Private Sub Check1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Check1.CheckedChanged

    End Sub
End Class