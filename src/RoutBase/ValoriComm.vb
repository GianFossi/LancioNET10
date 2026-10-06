Option Strict On
Option Explicit On
<Serializable()> Public Class ValoriComm
    Public pag As Short 'indice pagina                       22
    Public File As String '* 3  'nome file APR                       35
    Public Assieme As String 'denominazioni                    220
    Public Qta As Short ' 387+22
    Public Sub New()
        Assieme = ""
        File = ""
    End Sub
End Class