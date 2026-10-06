Option Strict Off
Option Explicit On
<Serializable()> Public Class Posizione
    Public SuChi As Membratura 'Ind del Componente sul quale
    Public ForoSecondario As Membratura 'Ind del Componente sul quale
    Public ForoTerziario As Membratura 'Ind del Componente sul quale
    Public Quota As String 'Quota lungo l'asse del quale
    Public Anomal As String 'Anomalia
    Public Raggio As String '
    Public DirDiritta As String 'Direz nuovo asse
    Public DirTraversa As String
    Public NearFar As String 'Nuovo part.attaccato su N F
    Public QuotaR As Single
    Public AnomalR As Single
    Public RaggioR As Single
    Public Origine As New RoutBase1.clsVec3
    Public CosOrigine As New RoutBase1.clsVec3
    Public CosDiritta As New RoutBase1.clsVec3
    Public CosTraversa As New RoutBase1.clsVec3
    Public CosTerza As New RoutBase1.clsVec3
    Public BaricAss As New RoutBase1.clsVec3
    Public BaricRel As New RoutBase1.clsVec3
    Public Sub Copia(ByRef p As Posizione)
        If p Is Nothing Then p = New Posizione
        p.SuChi = SuChi
        p.ForoSecondario = ForoSecondario
        p.ForoTerziario = ForoTerziario
        p.Quota = Quota
        p.Anomal = Anomal
        p.Raggio = Raggio
        p.DirDiritta = DirDiritta
        p.DirTraversa = DirTraversa
        p.NearFar = NearFar
        p.QuotaR = QuotaR
        p.AnomalR = AnomalR
        p.RaggioR = RaggioR
        Origine.copia((p.Origine))
        CosOrigine.copia((p.CosOrigine))
        CosDiritta.copia((p.CosDiritta))
        CosTraversa.copia((p.CosTraversa))
        CosTerza.copia((p.CosTerza))
        BaricAss.copia((p.BaricAss))
        BaricRel.copia((p.BaricRel))
    End Sub
    Protected Overrides Sub Finalize()
        Origine = Nothing
        CosOrigine = Nothing
        CosDiritta = Nothing
        CosTraversa = Nothing
        CosTerza = Nothing
        BaricAss = Nothing
        BaricRel = Nothing
        MyBase.Finalize()
    End Sub
    Public Sub New()
        Quota = ""
        Anomal = ""
        Raggio = ""
        DirDiritta = ""
        DirTraversa = ""
        NearFar = ""
    End Sub
End Class