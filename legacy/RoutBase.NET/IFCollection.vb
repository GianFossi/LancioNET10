Public Class IFCollection
    Inherits System.Collections.CollectionBase
    Private pnInput() As Short
    Public Sub New()
        MyBase.New()
        ReDim pnInput(4)
    End Sub
    Public Overloads Sub Add(ByVal sp As frmCheck)
        list.Add(sp)
        If UBound(pnInput) < list.Count Then ReDim Preserve pnInput(2 * list.Count)
        pnInput(list.Count - 1) = sp.pNinput
    End Sub
    Public Overloads Sub Add(ByVal sp As frmQuale)
        list.Add(sp)
        If UBound(pnInput) < list.Count Then ReDim Preserve pnInput(2 * list.Count)
        pnInput(list.Count - 1) = sp.pNinput
    End Sub
    Public Overloads Sub Add(ByVal sp As frmInput)
        list.Add(sp)
        If UBound(pnInput) < list.Count Then ReDim Preserve pnInput(2 * list.Count)
        pnInput(list.Count - 1) = sp.pNinput
    End Sub
    Public Sub Remove(ByVal index As Integer)
        Dim i As Short
        If index < list.Count - 1 Then
            For i = index To list.Count - 2
                pnInput(i) = pnInput(i + 1)
            Next
        End If
        list.RemoveAt(index)
    End Sub
    Public ReadOnly Property Ninput(ByVal index As Short) As Short
        Get
            Return pnInput(index)
        End Get
    End Property
    Default Public ReadOnly Property Item(ByVal Index As Integer) As Form
        Get
            Return CType(List.Item(Index), Form)
        End Get
    End Property
End Class
