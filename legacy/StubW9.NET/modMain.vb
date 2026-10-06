Option Strict On
Option Explicit On
Module modMain
    Friend Function TogliBlank(ByRef s As String) As String
        Dim i As Short
        Dim SS As String
        SS = Trim(s)
        For i = 1 To CShort(Len(SS))
            If Mid(SS, i, 1) = " " Or Mid(SS, i, 1) = "." Or Mid(SS, i, 1) = "-" Or Mid(SS, i, 1) = "+" Then Mid(SS, i, 1) = "_"
        Next
        TogliBlank = SS
    End Function
End Module