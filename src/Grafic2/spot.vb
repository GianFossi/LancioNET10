Option Strict Off
Option Explicit On
<Serializable()> Public Class spot
    Public indice As Membratura
    Public Sezione As Short 'progressivo (LungPIP) della sezione in corso
    Public Quota As Single 'profondita perpendicolare al piano
    Public Tipo As Short '1 Quadro 2 Spicchio
    Public Quadro As New clsLamQuadr
    Public spicchio As New Spicchio4
End Class