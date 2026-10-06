Option Strict Off
Option Explicit On
<Serializable()> Public Class clsGrezzo1
    Public IndRec As Short 'indirizzo in APR
    Public APR As String 'Distinta
    Public IndFile As Short
    Public Indmat As Short 'indice del materiale
    Public NPezzi As Short
    Private pVariab(5) As Single 'variabili essenziali numeriche
    Private pVartxt(3) As String 'variabili essenziali alfabetiche
    Private pDimens(4) As Single
    Public Property Dimens(ByVal i As Short) As Single
        Get
            Dimens = pDimens(i)
        End Get
        Set(ByVal Value As Single)
            pDimens(i) = Value
        End Set
    End Property
    Public Property Variab(ByVal i As Short) As Single
        Get
            Variab = pVariab(i)
        End Get
        Set(ByVal Value As Single)
            pVariab(i) = Value
        End Set
    End Property
    Public Property Vartxt(ByVal i As Short) As String
        Get
            Vartxt = pVartxt(i)
        End Get
        Set(ByVal Value As String)
            pVartxt(i) = Value
        End Set
    End Property

    Public Sub Copia(ByRef g As clsGrezzo1)
        Dim i As Short
        g.NPezzi = NPezzi
        If IndRec > 0 Then g.IndRec = IndRec
        g.APR = APR
        g.IndFile = IndFile
        If Indmat > 0 Then g.Indmat = Indmat
        For i = 1 To 5 : g.Variab(i) = pVariab(i) : Next
        For i = 1 To 3 : g.Vartxt(i) = pVartxt(i) : Next
        For i = 1 To 4 : g.Dimens(i) = pDimens(i) : Next
    End Sub
End Class