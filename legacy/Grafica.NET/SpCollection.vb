<Serializable()> Public Class SpCollection
    Inherits System.Collections.CollectionBase
    Public Sub Add(ByVal sp As Spicchio4)
        list.Add(sp)
    End Sub
    Public Sub Remove(ByVal index As Integer)
        list.RemoveAt(index)
    End Sub
    Default Public Property Item(ByVal Index As Integer) As Spicchio4
        Get
            Return CType(List.Item(Index), Spicchio4)
        End Get
        Set(ByVal Value As Spicchio4)
            List.Item(Index) = Value
        End Set
    End Property
End Class
