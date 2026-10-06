Option Strict On
Option Explicit On
<Serializable()> Public Class clsGuarn
    Public [Class] As Short '1-self energizing
    Public ClassS As String
    Public Tipo As Short
    Public TipoS As String
    Public Face As Short
    Public FaceS As String
    Public Formula As Short
    Public FormulaS As String
    Public m As Single
    Public y As Single
    Public Alfa As Single
    Public Height As Single
    Public Radius As Single
    Private Const inc As Single = 25.4
    Public Property Spessore() As Single
        Get
            Return 3
        End Get
        Set(ByVal value As Single)

        End Set
    End Property
    Public Sub Cerca(ByRef Arch As String, ByRef DiscoT As String)
        Archdir = Arch
        DiscoTem = DiscoT
        Guarniz = Me
        FormGuarn = New frmGuarn
        With FormGuarn
            .Command1_Click(.Command1, New System.EventArgs)
            .Dispose()
        End With
    End Sub
    Public Sub Scelta(ByRef Arch As String, ByRef DiscoT As String)
        Archdir = Arch
        DiscoTem = DiscoT
        Guarniz = Me
        FormGuarn = New frmGuarn
        FormGuarn.ShowDialog()
    End Sub
    Public Sub Copia(ByRef A As clsGuarn)
        If A Is Nothing Then A = New clsGuarn
        A.[Class] = [Class]
        A.ClassS = ClassS
        A.Tipo = Tipo
        A.TipoS = TipoS
        A.Face = Face
        A.FaceS = FaceS
        A.Formula = Formula
        A.FormulaS = FormulaS
        A.m = m
        A.y = y
    End Sub
    Public Sub Width(ByVal N As Single, ByRef b As Single, ByVal w As Single, _
                     ByRef Gef As Single, ByVal DiamExt As Single, ByVal F As Integer)
        Dim b0 As Single, b0inc As Single
        Select Case F
            Case 1 : b0 = N / 2
            Case 2 : b0 = (w + N) / 4
            Case 3 : b0 = (w + N) / 4
            Case 4 : b0 = (w + 3 * N) / 8
            Case 5 : b0 = N / 4
            Case 6 : b0 = 3 * N / 8
            Case 7 : b0 = 7 * N / 16
            Case 8 : b0 = N / 8
        End Select
        b0inc = b0 / inc
        If b0inc < 0.25 Then
            b = CSng(0.5 * inc * Math.Sqrt(b0inc))
        Else
            b = b0
        End If
        Gef = DiamExt - 2 * b
    End Sub
End Class