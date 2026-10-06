Imports routbase1
<Serializable()> Public Class clsPRV
    Public NomeFile As String
    Public Opened As Boolean
    '---------------------------------------------------------------------------
    Public Items As OggList
    '------------------------------------------------------------------------------
    Public SiglaPrev As String = "" ' 1    1     1     4    S,  00,   0   ,N. Preventivo
    Public NomeClien As String = "" ' 1    2     5    10    S,  00,   0   ,Nome cliente
    Public IndirClie As String = "" ' 1    3    15    10    S,  00,   0   ,Indirizzo cliente
    Public LuogoImpi As String = "" ' 1    4    25    10    S,  00,   0   ,Localita' impianto
    Public RiferClie As String = "" ' 1    5    35     6    S,  00,   0   ,Riferimento cliente
    Public UnitaMisu As String = "" ' 1    6    41     1    S,  00,   0   ,Unita' misura
    Public Linguaggi As String = "" ' 1    7    42     1    S,  00,   0   ,Linguaggio
    Public NumerItm As Integer ' 1    8    43     1    I,  00,   0   ,N. totale di items
    Public UltimRec As Integer ' 1    9    45     1    I,  00,   0   ,Ultimo record del file
    Public NumerComm As String = "" ' 1   10    46     3    S,  00,   0   ,N. della commessa
    Public Ventiltor As String = "" ' 1   11   114     5    S,  00,   0   ,Ventilatore se # da AX-HI
    Public MaterPale As String = "" ' 1   12   119     5    S,  00,   0   ,Materiale pale ventil. # AX-HI
    Public MaterMozz As String = "" ' 1   13   124     5    S,  00,   0   ,Mat. mozzo vent. # AH-HI
    Public OpCamini As Integer ' 1   14    49     1    I,  00,   0   ,2=vecchia opz camini;1=nuova
    Public DataPreve As String = "" ' 1   15    50     4    S,  00,   0   ,Data ap.prev. (ggmmaa)
    Public DataApCom As String = "" ' 1   16    54     4    S,  00,   0   ,Data ap.commessa
    Public DataChius As String = "" ' 1   17    58     4    S,  00,   0   ,Data chiusura
    Public NumerProt As String = "" ' 1   18    62     4    S,  00,   0   ,Nø protocollo
    Public Sub New(ByVal Nome As String)
        MyBase.New()
        NomeFile = Nome
        Items = New OggList(1)
    End Sub
    Public Property prNomeFile() As String
        Get
            Return NomeFile
        End Get
        Set(ByVal value As String)

        End Set
    End Property
    Public Property DutyTotale() As Single
        Get
            Return Dati.R(1)
        End Get
        Set(ByVal value As Single)
            Dati.R(1) = value
        End Set
    End Property
    Public Property TempINr() As Single
        Get
            Return Dati.R(2)
        End Get
        Set(ByVal value As Single)
            Dati.R(2) = value
        End Set
    End Property
    Public Property TempOUTr() As Single
        Get
            Return Dati.R(3)
        End Get
        Set(ByVal value As Single)
            Dati.R(3) = value
        End Set
    End Property
    Public Property LiqHCInr() As Single
        Get
            Return Dati.R(4)
        End Get
        Set(ByVal value As Single)
            Dati.R(4) = value
        End Set
    End Property
    Public Property VapHCInr() As Single
        Get
            Return Dati.R(5)
        End Get
        Set(ByVal value As Single)
            Dati.R(5) = value
        End Set
    End Property
    Public Property NonCondInr() As Single
        Get
            Return Dati.R(6)
        End Get
        Set(ByVal value As Single)
            Dati.R(6) = value
        End Set
    End Property
    Public Property SteamInr() As Single
        Get
            Return Dati.R(7)
        End Get
        Set(ByVal value As Single)
            Dati.R(7) = value
        End Set
    End Property
    Public Property WaterInr() As Single
        Get
            Return Dati.R(8)
        End Get
        Set(ByVal value As Single)
            Dati.R(8) = value
        End Set
    End Property
    Public Property PressAbs() As Single
        Get
            Return Dati.R(9)
        End Get
        Set(ByVal value As Single)
            Dati.R(9) = value
        End Set
    End Property
    Public Property TariaIN() As Single
        Get
            Return Dati.R(11)
        End Get
        Set(ByVal value As Single)
            Dati.R(11) = value
        End Set
    End Property
    Public Property Fouling() As Single
        Get
            Return Dati.R(12)
        End Get
        Set(ByVal value As Single)
            Dati.R(12) = value
        End Set
    End Property
    Public Property MWnonCondr() As Single
        Get
            Return Dati.R(13)
        End Get
        Set(ByVal value As Single)
            Dati.R(13) = value
        End Set
    End Property
    Public Property MWVapHCin() As Single
        Get
            Return Dati.R(14)
        End Get
        Set(ByVal value As Single)
            Dati.R(14) = value
        End Set
    End Property
    Public Property MWVapHCout() As Single
        Get
            Return Dati.R(15)
        End Get
        Set(ByVal value As Single)
            Dati.R(15) = value
        End Set
    End Property
    Public Property CondenHCr() As Single
        Get
            Return Dati.R(59)
        End Get
        Set(ByVal value As Single)
            Dati.R(59) = value
        End Set
    End Property
    Public Property CondSteamr() As Single
        Get
            Return Dati.R(60)
        End Get
        Set(ByVal value As Single)
            Dati.R(60) = value
        End Set
    End Property
    Public Property Elevazione() As Single
        Get
            Return Dati.R(61)
        End Get
        Set(ByVal value As Single)
            Dati.R(61) = value
        End Set
    End Property
    Public Property LunghPercorsoEff() As Single
        Get
            Return Dati.R(62)
        End Get
        Set(ByVal value As Single)
            Dati.R(62) = value
        End Set
    End Property
    Public Property FrazPassoHor() As Single
        Get
            Return Dati.R(69)
        End Get
        Set(ByVal value As Single)
            Dati.R(69) = value
        End Set
    End Property
    Public Property ElevFactor() As Single
        Get
            Return Dati.R(74)
        End Get
        Set(ByVal value As Single)
            Dati.R(74) = value
        End Set
    End Property
    Public Property DeltaTaria() As Single
        Get
            Return Dati.R(75)
        End Get
        Set(ByVal value As Single)
            Dati.R(75) = value
        End Set
    End Property
    Public Property EffWidthTotal() As Single
        Get
            Return Dati.R(76)
        End Get
        Set(ByVal value As Single)
            Dati.R(76) = value
        End Set
    End Property
    Public Property SurfReqTotal() As Single
        Get
            Return Dati.R(79)
        End Get
        Set(ByVal value As Single)
            Dati.R(79) = value
        End Set
    End Property
    Public Property TwOUT() As Single
        Get
            Return Dati.R(85)
        End Get
        Set(ByVal value As Single)
            Dati.R(85) = value
        End Set
    End Property
End Class
