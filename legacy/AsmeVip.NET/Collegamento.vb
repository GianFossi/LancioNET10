Option Strict Off
Option Explicit On
Friend Class Collegamento
	Public Lato1 As Short
	Public Lato2 As Short
	Public Membro1 As Short
	Public Membro2 As Short
	Public Tipo As Short
	
	Public Sub Aggiorna()
		Select Case Tipo
			Case 1 'generico
			Case 2 'cono lato grande
			Case 3 'cono lato piccolo
			Case 4 'PT a dilatatore
			Case 5, 6, 7, 8 'PT a FLShel,FlChan,SlShel,SlChan
			Case 10 'PT a fondo flottante
			Case 11 'PT a flangia fondo flottante
		End Select
	End Sub
End Class