Option Strict On
' Preserve padding/truncation at existing VB binary FileGet/FilePut call sites.
Friend NotInheritable Class FixedRecordString
    Private ReadOnly length As Integer
    Private text As String
    Public Sub New(size As Integer)
        If size < 0 Then Throw New ArgumentOutOfRangeException(NameOf(size))
        length = size
        text = New String(" "c, size)
    End Sub
    Public Property Value As String
        Get
            Return text
        End Get
        Set(value As String)
            text = If(value, "").PadRight(length).Substring(0, length)
        End Set
    End Property
End Class

