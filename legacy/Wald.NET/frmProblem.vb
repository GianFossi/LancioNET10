Option Strict Off
Option Explicit On
Friend Class frmProblem
	Inherits System.Windows.Forms.Form
	Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
		Monitor.Motore.Problem.ClientPlant = Text1(1).Text
		Monitor.Motore.Problem.Item = Text1(2).Text
		Monitor.Motore.Problem.Problema = Text1(3).Text
		Monitor.Motore.Problem.Author = Text1(4).Text
		Hide()
	End Sub
	
	Private Sub frmProblem_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		Text1(1).Text = Monitor.Motore.Problem.ClientPlant
		Text1(2).Text = Monitor.Motore.Problem.Item
		Text1(3).Text = Monitor.Motore.Problem.Problema
		Text1(4).Text = Monitor.Motore.Problem.Author
		
	End Sub
End Class