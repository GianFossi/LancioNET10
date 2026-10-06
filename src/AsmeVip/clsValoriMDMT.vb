Option Strict Off
Option Explicit On
Friend Class clsValoriMDMT
	Public k As Short
	Public i As Short
	Public Mark As String
	Public Secondo As Boolean
	Public Rule As String
	'UPGRADE_WARNING: Il limite inferiore della matrice prExempt è stato cambiato da 1 a 0. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1033"'
	Private prExempt(5) As Boolean
	'UPGRADE_WARNING: Il limite inferiore della matrice prArticl è stato cambiato da 1 a 0. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1033"'
	Private prArticl(5) As String
	Public Property Exempt(ByVal i As Short) As Boolean
		Get
			Exempt = prExempt(i)
		End Get
		Set(ByVal Value As Boolean)
			prExempt(i) = Value
		End Set
	End Property
	Public Property Articl(ByVal i As Short) As String
		Get
			Articl = prArticl(i)
		End Get
		Set(ByVal Value As String)
			prArticl(i) = Value
		End Set
	End Property
End Class