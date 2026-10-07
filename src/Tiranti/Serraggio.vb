Option Strict Off
Option Explicit On
Imports Microsoft.VisualBasic
Imports System.IO 'Namespace for Filestreams
Imports System.Runtime.Serialization.Formatters.Binary 'Namespace for BinaryFormatter
Public Class Serraggio
    Public Sciolto As Boolean
    Public Sub EseguidaASME()
        Sciolto = False
        With objTir
            .Xfil = Problem.xfil
            If Problem.DN.Length > 0 Then
                .DN = Problem.DN
                .CercaDN(Monitor.Motore.Inizio.Archdir, Monitor.Motore.Inizio.DiscoTem)
                Problem.Diam = .Dnom
                Problem.Chiave = .Chia
                'Problem.DN = .DN
                Problem.Dnoc = .Diam
                If Problem.xfil < 2 Then
                    Problem.passofil = .Passo
                Else
                    Problem.passofil = 25.4 / .Passo
                End If
            End If
        End With
        With Tir1.DefInstance
            .menfile.Visible = False
            .ToolBar2.Visible = False
            .Sistema.Visible = False
            .Tipocalc.Visible = False
            .cmdDone.Visible = True
            Tir1.DefInstance.ShowDialog()
        End With
    End Sub
    Public Sub EseguiSciolto()
        Sciolto = True
        Tir1.DefInstance.ShowDialog()
    End Sub
    Public WriteOnly Property DoveMotore() As RoutBase1.clsMotore
        Set(ByVal Value As RoutBase1.clsMotore)
            Monitor.Motore = Value
            Dim InitLibmat As LibMat.clsInitLibMat = New LibMat.clsInitLibMat(Monitor.Motore)
            objMat = New LibMat.MaterialeNew1
            objTir = New LibMat.clsTira
            Guarn = New LibMat.clsGuarn
            RadiceHelp = Value.Inizio.AppLancio & "\BIN\AsmeVip.chm"
        End Set
    End Property
    Public Property prunmi() As Short
        Get
            prunmi = Problem.unmi
        End Get
        Set(ByVal Value As Short)
            Problem.unmi = Value
        End Set
    End Property
    Public Property prcod() As Short
        Get
            prcod = Problem.cod
        End Get
        Set(ByVal Value As Short)
            Problem.cod = Value
        End Set
    End Property
    Public Property prt(ByVal m As Short) As Single
        Get
            With Problem
                If m = 1 And .unmi = 3 Then
                    prt = (.t - 32) / 1.8
                Else
                    prt = .t
                End If
            End With
        End Get
        Set(ByVal Value As Single)
            Problem.t = Value
        End Set
    End Property
    Public Property prp(ByVal m As Short) As Single
        Get
            With Problem
                If m = 1 Then
                    prp = .p / colConv.Item("p")(.unmi)
                Else
                    prp = .p
                End If
            End With
        End Get
        Set(ByVal Value As Single)
            Problem.p = Value
        End Set
    End Property
    Public Property prphydr(ByVal m As Short) As Single
        Get
            With Problem
                If m = 1 Then
                    prphydr = .phydr / colConv.Item("p")(.unmi)
                Else
                    prphydr = .phydr
                End If
            End With
        End Get
        Set(ByVal Value As Single)
            Problem.phydr = Value
        End Set
    End Property
    Public Property prDiamExtGuar() As Single
        Get
            prDiamExtGuar = Problem.DiamExtGuar
        End Get
        Set(ByVal Value As Single)
            Problem.DiamExtGuar = Value
        End Set
    End Property
    Public Property prDiam(ByVal m As Short) As Single
        Get
            With Problem
                If m = 1 Then
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto colConv()(). Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                    prDiam = .Diam / colConv.Item("l")(.unmi)
                Else
                    prDiam = .Diam
                End If
            End With
        End Get
        Set(ByVal Value As Single)
            Problem.Diam = Value
        End Set
    End Property
    Public ReadOnly Property prDiammed(ByVal m As Short) As Single
        Get
            With Problem
                If m = 1 Then
                    prDiammed = .diammed / colConv.Item("l")(.unmi)
                Else
                    prDiammed = .diammed
                End If
            End With
        End Get
    End Property
    Public ReadOnly Property prChiave(ByVal m As Short) As Single
        Get
            With Problem
                If m = 1 Then
                    prChiave = .Chiave / colConv.Item("l")(.unmi)
                Else
                    prChiave = .Chiave
                End If
            End With
        End Get
    End Property
    Public ReadOnly Property prAlfa() As Single
        Get
            prAlfa = Problem.alfa
        End Get
    End Property
    Public ReadOnly Property prAlf() As Single
        Get
            prAlf = Problem.alf
        End Get
    End Property
    Public ReadOnly Property prbeta() As Single
        Get
            prbeta = Problem.beta
        End Get
    End Property
    Public ReadOnly Property prfDado() As Single
        Get
            prfDado = Problem.fDado
        End Get
    End Property
    Public ReadOnly Property prfFil() As Single
        Get
            prfFil = Problem.fFil
        End Get
    End Property
    Public ReadOnly Property prfGlob() As Single
        Get
            prfGlob = Problem.fGlob
        End Get
    End Property
    Public ReadOnly Property prfNomeDado() As String
        Get
            With Problem
                prfNomeDado = .coefft(.coeffindexD).Nome
            End With
        End Get
    End Property
    Public ReadOnly Property prfNomeFil() As String
        Get
            With Problem
                prfNomeFil = .coefft(.coeffindexF).Nome
            End With
        End Get
    End Property
    Public Property prArea(ByVal m As Short) As Single
        Get
            With Problem
                If m = 1 Then
                    prArea = .Area / colConv.Item("l2")(.unmi)
                Else
                    prArea = .Area
                End If
            End With
        End Get
        Set(ByVal Value As Single)
            Problem.Area = Value
        End Set
    End Property
    Public ReadOnly Property prAreaPist(ByVal m As Short) As Single
        Get
            With Problem
                If m = 1 Then
                    prAreaPist = .areaPist / colConv.Item("l2")(.unmi)
                Else
                    prAreaPist = .areaPist
                End If
            End With
        End Get
    End Property
    Public ReadOnly Property prpassofil(ByVal m As Short) As Single
        Get
            With Problem
                If m = 1 Then
                    prpassofil = .passofil / colConv.Item("l")(.unmi)
                Else
                    prpassofil = .passofil
                End If
            End With
        End Get
    End Property
    Public ReadOnly Property prPresPist(ByVal m As Short) As Single
        Get
            With Problem
                If m = 1 Then
                    prPresPist = .presPist / colConv.Item("p")(.unmi)
                Else
                    prPresPist = .presPist
                End If
            End With
        End Get
    End Property
    Public Property prN() As Single
        Get
            prN = Problem.N
        End Get
        Set(ByVal Value As Single)
            Problem.N = Value
        End Set
    End Property
    Public Property prwNubbin() As Single
        Get
            prwNubbin = Problem.wnubbin
        End Get
        Set(ByVal Value As Single)
            Problem.wnubbin = Value
        End Set
    End Property
    Public Property prsa1() As Single
        Get
            prsa1 = Problem.sa1
        End Get
        Set(ByVal Value As Single)
            Problem.sa1 = Value
        End Set
    End Property
    Public Property prsa2(ByVal m As Short) As Single
        Get
            With Problem
                If m = 1 Then
                    prsa2 = .sa2 / colConv.Item("pamm")(.unmi)
                Else
                    prsa2 = .sa2
                End If
            End With
        End Get
        Set(ByVal Value As Single)
            Problem.sa2 = Value
        End Set
    End Property
    Public Property prnb() As Integer
        Get
            prnb = Problem.nb
        End Get
        Set(ByVal Value As Integer)
            Problem.nb = Value
        End Set
    End Property
    Public Property prClasseGuarnizione() As Short
        Get
            prClasseGuarnizione = Problem.ClasseGuarnizione
        End Get
        Set(ByVal Value As Short)
            Problem.ClasseGuarnizione = Value
        End Set
    End Property
    Public Property prTipoGuarnizione() As Short
        Get
            prTipoGuarnizione = Problem.TipoGuarnizione
        End Get
        Set(ByVal Value As Short)
            Problem.TipoGuarnizione = Value
        End Set
    End Property
    Public Property prstrClasseGuarnizione() As String
        Get
            prstrClasseGuarnizione = Problem.strClasseGuarnizione
        End Get
        Set(ByVal Value As String)
            Problem.strClasseGuarnizione = Value
        End Set
    End Property
    Public Property prstrTipoGuarnizione() As String
        Get
            prstrTipoGuarnizione = Problem.strTipoGuarnizione
        End Get
        Set(ByVal Value As String)
            Problem.strTipoGuarnizione = Value
        End Set
    End Property
    Public Property prm() As Single
        Get
            prm = Problem.m
        End Get
        Set(ByVal Value As Single)
            Problem.m = Value
        End Set
    End Property
    Public Property pryy() As Single
        Get
            pryy = Problem.yy
        End Get
        Set(ByVal Value As Single)
            Problem.yy = Value
        End Set
    End Property
    Public Property prFace() As Short
        Get
            prFace = Problem.Face
        End Get
        Set(ByVal Value As Short)
            Problem.Face = Value
        End Set
    End Property
    Public Property prMatTira() As String
        Get
            prMatTira = Problem.MatTira
        End Get
        Set(ByVal Value As String)
            Problem.MatTira = Value
        End Set
    End Property
    Public Property prDN() As String
        Get
            prDN = Problem.DN
        End Get
        Set(ByVal Value As String)
            Problem.DN = Value
        End Set
    End Property
    Public Property prindMat() As Short
        Get
            prindMat = Problem.indMat
        End Get
        Set(ByVal Value As Short)
            Problem.indMat = Value
        End Set
    End Property
    Public Property prxFil() As Short
        Get
            prxFil = Problem.xfil
        End Get
        Set(ByVal Value As Short)
            Problem.xfil = Value
        End Set
    End Property
    Public Property prwm1() As Single
        Get
            prwm1 = Problem.wm1
        End Get
        Set(ByVal Value As Single)
            Problem.wm1 = Value
        End Set
    End Property
    Public Property prwm2() As Single
        Get
            prwm2 = Problem.wm2
        End Get
        Set(ByVal Value As Single)
            Problem.wm2 = Value
        End Set
    End Property
    Public Property prw0() As Single
        Get
            prw0 = Problem.w0
        End Get
        Set(ByVal Value As Single)
            Problem.w0 = Value
        End Set
    End Property
    Public Property prv(ByVal m As Short) As Single
        Get
            With Problem
                If m = 1 Then
                    prv = .v / colConv.Item("f")(.unmi)
                Else
                    prv = .v
                End If
            End With
        End Get
        Set(ByVal Value As Single)
            Problem.v = Value
        End Set
    End Property
    Public Property prvPilgrim(ByVal m As Short) As Single
        Get
            With Problem
                If m = 1 Then
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto colConv()(). Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                    prvPilgrim = .vPilgrim / colConv.Item("f")(.unmi)
                Else
                    prvPilgrim = .vPilgrim
                End If
            End With
        End Get
        Set(ByVal Value As Single)
            Problem.vPilgrim = Value
        End Set
    End Property
    Public Property prTorque(ByVal m As Short) As Single
        Get
            With Problem
                If m = 1 Then
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto colConv()(). Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                    prTorque = .torque / colConv.Item("fl")(.unmi)
                Else
                    prTorque = .torque
                End If
            End With
        End Get
        Set(ByVal Value As Single)
            Problem.torque = Value
        End Set
    End Property
    Public Property prk1() As Single
        Get
            prk1 = Problem.k1
        End Get
        Set(ByVal Value As Single)
            Problem.k1 = Value
        End Set
    End Property
    Public Property prk2Pilgrim() As Single
        Get
            prk2Pilgrim = Problem.k2Pilgrim
        End Get
        Set(ByVal Value As Single)
            Problem.k2Pilgrim = Value
        End Set
    End Property
    Public Property prk2Torque() As Single
        Get
            prk2Torque = Problem.k2Torque
        End Get
        Set(ByVal Value As Single)
            Problem.k2Torque = Value
        End Set
    End Property
    Public Property prk3() As Single
        Get
            prk3 = Problem.k3
        End Get
        Set(ByVal Value As Single)
            Problem.k3 = Value
        End Set
    End Property
    Public ReadOnly Property lenProblem() As Short
        Get
            lenProblem = Len(Problem)
        End Get
    End Property
    Public Sub New()
        MyBase.New()
        Monitor = New clsMonitor
        Monitor.Oggetto = Me
        SetUnitStrings()
        Inizializza()
        nomefile = ""
    End Sub
    Public Sub Inizializza()
        With Problem
            .Initialize()
            .unmi = 1
            .xfil = 2
            .cod = 1
            .coefft(0).Coeff = 0.31
            .coefft(0).Nome = "A secco"
            .coefft(1).Coeff = 0.17 'Definisco le variabili
            .coefft(1).Nome = "Gr. ordinario"
            .coefft(2).Coeff = 0.08
            .coefft(2).Nome = "Gr. al Molycote"
            .coefft(3).Coeff = 0.1
            .coefft(3).Nome = "Generico"
            .coeffindexD = -1
            .coeffindexF = -1
        End With
    End Sub
    Public Function apri(Optional ByRef icome As String = "") As Boolean
        Lancio.Legacy.Serialization.LegacyBinarySerializer.EnsureEnabled()
        If Not Sciolto Then nomefile = icome
        Dim fs As New FileStream(nomefile, FileMode.Open)
        Dim bf As New Lancio.Legacy.Serialization.LegacyBinarySerializer
        Problem = CType(bf.Deserialize(fs), typProblem)
        If Problem.intestazione <> intestazione Then
            MsgBox("Il file che si è deciso di aprire non è stato creato da questa applicazione", MsgBoxStyle.Critical, "Apri")
            fs.Close()
            Azzera()
            Exit Function
        End If
        If Problem.Version <> Version Then
            MsgBox("Il file che si è deciso di aprire è di una versione obsoleta", MsgBoxStyle.Critical, "Apri")
            fs.Close()
            Azzera()
            Exit Function
        End If
        fs.Close()
        apri = True
    End Function
    Public Sub scrivi(Optional ByRef icome As String = "")
        Lancio.Legacy.Serialization.LegacyBinarySerializer.EnsureEnabled()
        Problem.intestazione = intestazione
        If Not Sciolto Then nomefile = icome
        Dim fs As New FileStream(nomefile, FileMode.OpenOrCreate)
        Dim bf As New Lancio.Legacy.Serialization.LegacyBinarySerializer
        Problem.Version = Version
        bf.Serialize(fs, Problem)
        fs.Close()
    End Sub
    Protected Overrides Sub Finalize()
        Tir1.DefInstance.Dispose()
        frmcoef.DefInstance.Dispose()
        MyBase.Finalize()
    End Sub
End Class