Public Class clsRectang
    Private Corners1 As New clsVec2
    Private Corners2 As New clsVec2
    Private Corners3 As New clsVec2
    Private Corners4 As New clsVec2
    Public Lung As Single
    Public Larg As Single
    Public Property Corners(ByVal i As Short) As clsVec2
        Get
            Select Case i
                Case 1 : Return Corners1
                Case 2 : Return Corners2
                Case 3 : Return Corners3
                Case 4 : Return Corners4
                Case Else : Return Nothing
            End Select
        End Get
        Set(ByVal Value As clsVec2)
            Select Case i
                Case 1 : Corners1 = Value
                Case 2 : Corners2 = Value
                Case 3 : Corners3 = Value
                Case 4 : Corners4 = Value
            End Select
        End Set
    End Property
    Public Function Clone() As clsRectang
        Dim R As New clsRectang
        Corners1.copia(R.Corners1)
        Corners2.copia(R.Corners2)
        Corners3.copia(R.Corners3)
        Corners4.copia(R.Corners4)
        R.Lung = Lung
        R.Larg = Larg
        Return R
    End Function
End Class
