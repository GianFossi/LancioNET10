Option Strict On
Option Explicit On
Public Class clsBWG
    Public TipoMat As Short '0,1,2
    Public Diam As Single
    Public BWG As Short
    Public Spess As Single
    Public TextBWG As String
    Public DiamSt() As Single = {6.35, 9.525, 12.7, 15.875, 19.05, 22.225, 25.4, 31.75, 38.1, 50.8}
    Public DiamInch() As String = {" 1/4 ", _
                                   " 3/8 ", _
                                   " 1/2 ", _
                                   " 5/8 ", _
                                   " 3/4 ", _
                                   " 7/8 ", _
                                   "  1  ", _
                                   "1-1/4", _
                                   "1-1/2", _
                                   "  2  "}
    Public SpBWG(,) As Single = {{0.284, 2}, _
                                 {0.259, 3}, _
                                 {0.238, 4}, _
                                 {0.22, 5}, _
                                 {0.203, 6}, _
                                 {0.18, 7}, _
                                 {0.165, 8}, _
                                 {0.148, 9}, _
                                 {0.134, 10}, _
                                 {0.12, 11}, _
                                 {0.109, 12}, _
                                 {0.095, 13}, _
                                 {0.083, 14}, _
                                 {0.072, 15}, _
                                 {0.065, 16}, _
                                 {0.058, 17}, _
                                 {0.049, 18}, _
                                 {0.042, 19}, _
                                 {0.035, 20}, _
                                 {0.028, 22}, _
                                 {0.022, 24}, _
                                 {0.018, 26}, _
                                 {0.016, 27}}
    Public RCB221(,,) As Short = {{{27, 24, 22, 0}, {0, 0, 0, 0}, {27, 24, 22, 0}}, _
                                  {{22, 20, 18, 0}, {0, 0, 0, 0}, {22, 20, 18, 0}}, _
                                  {{20, 18, 0, 0}, {0, 0, 0, 0}, {20, 18, 0, 0}}, _
                                  {{20, 18, 16, 0}, {18, 16, 14, 0}, {20, 18, 16, 0}}, _
                                  {{20, 18, 16, 0}, {16, 14, 12, 0}, {18, 16, 14, 0}}, _
                                  {{18, 16, 14, 12}, {14, 12, 10, 0}, {16, 14, 12, 0}}, _
                                  {{18, 16, 14, 0}, {14, 12, 0, 0}, {16, 14, 12, 0}}, _
                                  {{16, 14, 0, 0}, {14, 12, 0, 0}, {16, 14, 12, 0}}, _
                                  {{16, 14, 0, 0}, {14, 12, 0, 0}, {14, 12, 0, 0}}, _
                                  {{14, 12, 0, 0}, {14, 12, 0, 0}, {14, 12, 0, 0}}}
    Public Sub Mostra()
        Dim FormBWG As frmBWG
        FormBWG = New frmBWG
        FormBWG.objBWG = Me
        FormBWG.ShowDialog()
    End Sub
    Public Function SpFinale(ByVal BWG As String, ByVal TOL As String) As Single
        Dim i As Short, Sp As Single
        For i = 0 To CShort(UBound(SpBWG, 1))
            If CShort(BWG) = SpBWG(i, 1) Then
                Sp = CSng(SpBWG(i, 0))
            End If
        Next
        Select Case TOL.Trim
            Case "MI", "MW"
                Sp = CSng(Sp * 1.02)
            Case "AV", "AW"
                Sp = CSng(Sp * 1.11)
        End Select
        Return Sp
    End Function
    Public WriteOnly Property DoveMotore() As RoutBase1.clsMotore
        Set(ByVal Value As RoutBase1.clsMotore)
            If Monitor Is Nothing Then Monitor = New clsMonitor
            If Monitor.Motore Is Nothing Then Monitor.Motore = Value
            Archdir = Value.Inizio.Archdir
        End Set
    End Property
End Class