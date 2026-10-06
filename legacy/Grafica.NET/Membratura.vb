<Serializable()> Public MustInherit Class Membratura
    Public GenMem As clsGenMem
    Public Variato As Boolean
    Public TipoMat As Short
    Public TipoS As Short
    Public Overridable Function Convalida() As Boolean
        Convalida = True
    End Function
    Public Overridable Sub CalcGrezzi()
    End Sub
    Public Overridable Overloads Sub Copia(ByRef c As Membratura)

    End Sub
    Public Overridable Property Altezza() As Single
        Get
            Throw New OverrideException("Altezza", GenMem.Denom, GenMem.Tipo.ToString)
        End Get
        Set(ByVal Value As Single)
            Throw New OverrideException("Altezza", GenMem.Denom, GenMem.Tipo.ToString)
        End Set
    End Property
    Public Overridable Overloads Sub Leggi(ByVal i As String, ByVal j As Short)

    End Sub
    Public Overridable Overloads Function leggi(Optional ByRef iDia As Short = -1, Optional ByRef iRat As Short = -1, Optional ByRef iFac As Short = -1, _
    Optional ByRef TabFl As Short = -1, Optional ByRef iTipo As Short = 0, Optional ByRef Visual As Boolean = False, _
    Optional ByRef DiscoR As String = "") As Boolean
    End Function
    Public Overridable Sub Pesi()

    End Sub
    Public Overridable Sub StringMATE()

    End Sub
    Public Overridable Property Code7() As Short
        Get
            Throw New OverrideException("Code7", GenMem.Denom, GenMem.Tipo.ToString)
        End Get
        Set(ByVal Value As Short)
            Throw New OverrideException("Code7", GenMem.Denom, GenMem.Tipo.ToString)
        End Set
    End Property
    Public Overridable Sub MostraSviluppi()

    End Sub
    Public Overridable Property Param1() As Single
        Get
            Throw New OverrideException("Param1", GenMem.Denom, GenMem.Tipo.ToString)
        End Get
        Set(ByVal Value As Single)
            Throw New OverrideException("Param1", GenMem.Denom, GenMem.Tipo.ToString)
        End Set
    End Property
    Public Overridable Function NumSpic(ByRef NumSpicchi As Short) As Short
        NumSpicchi = NumSpicGen(False, "UnkNown", 0.0!, NumSpicchi)
        NumSpic = NumSpicchi
    End Function
    Public Overridable Property Bucante() As Membratura
        Get
            Throw New OverrideException("Bucante", GenMem.Denom, GenMem.Tipo.ToString)
        End Get
        Set(ByVal Value As Membratura)
            Throw New OverrideException("Bucante", GenMem.Denom, GenMem.Tipo.ToString)
        End Set
    End Property
    Public Overridable Property Spessore() As Single
        Get
            Throw New OverrideException("Spessore", GenMem.Denom, GenMem.Tipo.ToString)
        End Get
        Set(ByVal Value As Single)
            Throw New OverrideException("Spessore", GenMem.Denom, GenMem.Tipo.ToString)
        End Set
    End Property
    Public Overridable Property Spess() As Single
        Get
            Throw New OverrideException("Spess", GenMem.Denom, GenMem.Tipo.ToString)
        End Get
        Set(ByVal Value As Single)
            Throw New OverrideException("Spess", GenMem.Denom, GenMem.Tipo.ToString)
        End Set
    End Property
    Public Overridable Property Randa() As Single
        Get
            Throw New OverrideException("Randa", GenMem.Denom, GenMem.Tipo.ToString)
        End Get
        Set(ByVal Value As Single)
            Throw New OverrideException("Randa", GenMem.Denom, GenMem.Tipo.ToString)
        End Set
    End Property
    Public Overridable Property SpessBase() As Single
        Get
            Throw New OverrideException("SpessBase", GenMem.Denom, GenMem.Tipo.ToString)
        End Get
        Set(ByVal Value As Single)
            Throw New OverrideException("SpessBase", GenMem.Denom, GenMem.Tipo.ToString)
        End Set
    End Property
    Public Overridable Property SpesScarpa() As Single
        Get
            Throw New OverrideException("SpesScarpa", GenMem.Denom, GenMem.Tipo.ToString)
        End Get
        Set(ByVal Value As Single)
            Throw New OverrideException("SpesScarpa", GenMem.Denom, GenMem.Tipo.ToString)
        End Set
    End Property
    Public Overridable Property SpostLat() As Single
        Get
            Throw New OverrideException("SpostLat", GenMem.Denom, GenMem.Tipo.ToString)
        End Get
        Set(ByVal Value As Single)
            Throw New OverrideException("SpostLat", GenMem.Denom, GenMem.Tipo.ToString)
        End Set
    End Property
    Public Overridable Property DiamScarpa() As Single
        Get
            Throw New OverrideException("DiamScarpa", GenMem.Denom, GenMem.Tipo.ToString)
        End Get
        Set(ByVal Value As Single)
            Throw New OverrideException("DiamScarpa", GenMem.Denom, GenMem.Tipo.ToString)
        End Set
    End Property
    Public Overridable Property DiamRinf() As Single
        Get
            Throw New OverrideException("DiamRinf", GenMem.Denom, GenMem.Tipo.ToString)
        End Get
        Set(ByVal Value As Single)
            Throw New OverrideException("DiamRinf", GenMem.Denom, GenMem.Tipo.ToString)
        End Set
    End Property
    Public Overridable Sub RimuoviSpeciali(ByRef O As Membratura)

    End Sub
    Public Overridable Property Standard() As Flangia
        Get
            Throw New OverrideException("Standard", GenMem.Denom, GenMem.Tipo.ToString)
        End Get
        Set(ByVal Value As Flangia)
            Throw New OverrideException("Standard", GenMem.Denom, GenMem.Tipo.ToString)
        End Set
    End Property
    Public Overridable Property StandardPip() As LibMat.clsPipe
        Get
            Throw New OverrideException("Standard", GenMem.Denom, GenMem.Tipo.ToString)
        End Get
        Set(ByVal Value As LibMat.clsPipe)
            Throw New OverrideException("Standard", GenMem.Denom, GenMem.Tipo.ToString)
        End Set
    End Property
    Public Overridable Property Apertura() As Single
        Get
            Throw New OverrideException("Apertura", GenMem.Denom, GenMem.Tipo.ToString)
        End Get
        Set(ByVal Value As Single)
            Throw New OverrideException("Apertura", GenMem.Denom, GenMem.Tipo.ToString)
        End Set
    End Property
    Public Overridable Property Sporgenza() As Single
        Get
            Throw New OverrideException("Sporgenza", GenMem.Denom, GenMem.Tipo.ToString)
        End Get
        Set(ByVal Value As Single)
            Throw New OverrideException("Sporgenza", GenMem.Denom, GenMem.Tipo.ToString)
        End Set
    End Property
    Public Overridable Property DiamFl() As Single
        Get
            Throw New OverrideException("DiamFl", GenMem.Denom, GenMem.Tipo.ToString)
        End Get
        Set(ByVal Value As Single)
            Throw New OverrideException("DiamFl", GenMem.Denom, GenMem.Tipo.ToString)
        End Set
    End Property
    Public Overridable Property B3() As Single
        Get
            Throw New OverrideException("B3", GenMem.Denom, GenMem.Tipo.ToString)
        End Get
        Set(ByVal Value As Single)
            Throw New OverrideException("B3", GenMem.Denom, GenMem.Tipo.ToString)
        End Set
    End Property
    Public Overridable Property LC() As Single
        Get
            Throw New OverrideException("LC", GenMem.Denom, GenMem.Tipo.ToString)
        End Get
        Set(ByVal Value As Single)
            Throw New OverrideException("LC", GenMem.Denom, GenMem.Tipo.ToString)
        End Set
    End Property
    Public Overridable Property BoltCir() As Single
        Get
            Throw New OverrideException("BoltCir", GenMem.Denom, GenMem.Tipo.ToString)
        End Get
        Set(ByVal Value As Single)
            Throw New OverrideException("BoltCir", GenMem.Denom, GenMem.Tipo.ToString)
        End Set
    End Property
    Public Overridable Property Dgran() As Single
        Get
            Throw New OverrideException("Dgran", GenMem.Denom, GenMem.Tipo.ToString)
        End Get
        Set(ByVal Value As Single)
            Throw New OverrideException("Dgran", GenMem.Denom, GenMem.Tipo.ToString)
        End Set
    End Property
    Public Overridable Property Diametro() As Single
        Get
            Throw New OverrideException("Diametro", GenMem.Denom, GenMem.Tipo.ToString)
        End Get
        Set(ByVal Value As Single)
            Throw New OverrideException("Diametro", GenMem.Denom, GenMem.Tipo.ToString)
        End Set
    End Property
    Public Overridable Property Diamext() As Single
        Get
            Throw New OverrideException("Diamext", GenMem.Denom, GenMem.Tipo.ToString)
        End Get
        Set(ByVal Value As Single)
            Throw New OverrideException("Diamext", GenMem.Denom, GenMem.Tipo.ToString)
        End Set
    End Property
    Public Overridable Property Diamint() As Single
        Get
            Throw New OverrideException("Diamint", GenMem.Denom, GenMem.Tipo.ToString)
        End Get
        Set(ByVal Value As Single)
            Throw New OverrideException("Diamint", GenMem.Denom, GenMem.Tipo.ToString)
        End Set
    End Property
    Public Overridable Property Dpicc() As Single
        Get
            Throw New OverrideException("Dpicc", GenMem.Denom, GenMem.Tipo.ToString)
        End Get
        Set(ByVal Value As Single)
            Throw New OverrideException("Dpicc", GenMem.Denom, GenMem.Tipo.ToString)
        End Set
    End Property
    Public Overridable Property Lunghezza() As Single
        Get
            Throw New OverrideException("Lunghezza", GenMem.Denom, GenMem.Tipo.ToString)
        End Get
        Set(ByVal Value As Single)
            Throw New OverrideException("Lunghezza", GenMem.Denom, GenMem.Tipo.ToString)
        End Set
    End Property
    Public Overridable Property Larghezza() As Single
        Get
            Throw New OverrideException("Larghezza", GenMem.Denom, GenMem.Tipo.ToString)
        End Get
        Set(ByVal Value As Single)
            Throw New OverrideException("Larghezza", GenMem.Denom, GenMem.Tipo.ToString)
        End Set
    End Property
    Public Overridable Property SottoTipo() As Short
        Get
            Throw New OverrideException("SottoTipo", GenMem.Denom, GenMem.Tipo.ToString)
        End Get
        Set(ByVal Value As Short)
            Throw New OverrideException("SottoTipo", GenMem.Denom, GenMem.Tipo.ToString)
        End Set
    End Property
    Public Overridable Property TipoF() As Short
        Get
            Throw New OverrideException("TipoF", GenMem.Denom, GenMem.Tipo.ToString)
        End Get
        Set(ByVal Value As Short)
            Throw New OverrideException("TipoF", GenMem.Denom, GenMem.Tipo.ToString)
        End Set
    End Property
End Class
Public Class OverrideException
    Inherits Exception
    Public Sub New(ByVal Proprieta As String, ByVal Nome As String, ByVal Tipo As String)
        MyBase.New(GlobalRoutines.FormatS(rmHelpStrings.GetString("ErrOverride"), Proprieta, Nome, Tipo))
    End Sub
End Class