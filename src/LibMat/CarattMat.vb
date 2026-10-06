Option Strict On
Option Explicit On
<Serializable()> Public Class CarattMatNew
    Public Codice As Codes '1 ASME psi 2 ASME MPA 3 VSR 4 BS psi 5 BS MPA 6 div.2 psi 7 Stomweezen 8 EU
    Public Source As String
    Public Yield As Single
    Public Alfa As Single
    Public Young As Single
    Public US As Single
    Public CreepRange As Single 'temp in Fahrenheit limite creep
    Public IndChart As Short
    Public MWDTrule As String
    Public MWDTclause As String
    Public MWDTtemp As Single
    Public Temp As RoutBase1.LinkListS
    Public Ammiss As RoutBase1.LinkListS ' per EN è Rp
    Public TempY As RoutBase1.LinkListS
    Public AlfaT As RoutBase1.LinkListS 'si deve intendere Sy
    Public TempU As RoutBase1.LinkListS
    Public Ustrength As RoutBase1.LinkListS
    Public PNumber As String
    Public Group As String
    Public Pad As String
    Public IndNote As Integer
    Public Sub New()
        MyBase.New()
        Dim i As Short
        Dim s(6, 24) As Single
        Temp = New RoutBase1.LinkListS
        Ammiss = New RoutBase1.LinkListS
        TempY = New RoutBase1.LinkListS
        AlfaT = New RoutBase1.LinkListS
        TempU = New RoutBase1.LinkListS
        Ustrength = New RoutBase1.LinkListS
        For i = 1 To 24
            Temp.Add(s(1, i))
            TempY.Add(s(2, i))
            Ammiss.Add(s(3, i))
            AlfaT.Add(s(4, i))
            TempU.Add(s(5, i))
            Ustrength.Add(s(6, i))
        Next
    End Sub
    Protected Overrides Sub Finalize()
        Temp = Nothing
        Ammiss = Nothing
        TempY = Nothing
        AlfaT = Nothing
        TempU = Nothing
        Ustrength = Nothing
        MyBase.Finalize()
    End Sub
End Class
<Serializable()> Public Class CarattMat
    Public Codice As Short '1 ASME psi 2 ASME MPA 3 VSR 4 BS psi 5 BS MPA 6 div.2 psi 7 Stomweezen 8 EU
    Public Source As String
    Public Yield As Single
    Public Alfa As Single
    Public Young As Single
    Public US As Single
    Public CreepRange As Single 'temp in Fahrenheit limite creep
    Public IndChart As Short
    Public MWDTrule As String
    Public MWDTclause As String
    Public MWDTtemp As Single
    Public Temp As RoutBase1.LinkListS
    Public Ammiss As RoutBase1.LinkListS ' per EN è Rp
    Public TempY As RoutBase1.LinkListS
    Public AlfaT As RoutBase1.LinkListS 'si deve intendere Sy
    Public PNumber As String
    Public Group As String
    Public Pad As String
    Public IndNote As Integer
    Public Function Converti() As CarattMatNew
        Dim i As Short
        Dim c As New CarattMatNew
        c.Codice = CType(Codice, Codes)
        c.Source = Source
        c.Yield = Yield
        c.Alfa = Alfa
        c.Young = Young
        c.US = US
        c.CreepRange = CreepRange
        c.IndChart = IndChart
        c.MWDTrule = MWDTrule
        c.MWDTclause = MWDTclause
        c.MWDTtemp = MWDTtemp
        c.Temp = New RoutBase1.LinkListS
        c.Ammiss = New RoutBase1.LinkListS
        c.TempY = New RoutBase1.LinkListS
        c.AlfaT = New RoutBase1.LinkListS
        For i = 1 To 24
            c.Temp.Add(Temp(i).TextData)
            c.TempY.Add(TempY(i).TextData)
            c.Ammiss.Add(Ammiss(i).TextData)
            c.AlfaT.Add(AlfaT(i).TextData)
        Next
        c.PNumber = PNumber
        c.Group = Group
        c.Pad = Pad
        c.IndNote = IndNote
        Return c
    End Function
    Public Sub New()
        MyBase.New()
        Dim i As Short
        Dim s(4, 24) As Single
        Temp = New RoutBase1.LinkListS
        Ammiss = New RoutBase1.LinkListS
        TempY = New RoutBase1.LinkListS
        AlfaT = New RoutBase1.LinkListS
        For i = 1 To 24
            Temp.Add(s(1, i))
            TempY.Add(s(2, i))
            Ammiss.Add(s(3, i))
            AlfaT.Add(s(4, i))
        Next
    End Sub
    Protected Overrides Sub Finalize()
        Temp = Nothing
        Ammiss = Nothing
        TempY = Nothing
        AlfaT = Nothing
        MyBase.Finalize()
    End Sub
End Class