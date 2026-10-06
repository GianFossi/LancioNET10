Option Strict Off
Option Explicit On
Imports System.Math
Imports System.Runtime.InteropServices
Imports RoutBase1
<Serializable()> Public Class clsPolig
    Inherits Membratura
    ' Declare Sub CopyMemory Lib "kernel32" Alias "RtlMoveMemory" (ByVal pDst As Object, _
    '                                                                 ByVal pSrc As Object, _
    '                                                                 ByVal ByteLen As Long)
    Public Vertici As RoutBase1.clsPunti
    Public Centri As RoutBase1.clsPunti
    Public Raggi As RoutBase1.LinkListS
    Private prLarghezza As Single
    Private prLunghezza As Single
    Private prSpessore As Single
    Public Alt As Single
    Public Alung As Single
    ' Public TipoMat As Short
    ' Public GenMem As clsGenMem
    Public Rifer As Short '1 terza perpendicolare
    '0 diritta perpendicolare
    Public Overrides Property Spessore() As Single
        Get
            Return prSpessore
        End Get
        Set(ByVal Value As Single)
            prSpessore = Value
        End Set
    End Property
    Public Sub New()
        MyBase.New()
        GenMem = New clsGenMem
        GenMem.Parent = Me
        TipoMat = 1
        GenMem.Tipo = 96
        Vertici = New RoutBase1.clsPunti
        Centri = New RoutBase1.clsPunti
        Raggi = New RoutBase1.LinkListS
    End Sub
    Public Property Npunti() As Short
        Get
            Npunti = Vertici.Punti.Count
        End Get
        Set(ByVal Value As Short)
            Dim i As Short
            Vertici.Inizia(Value)
            Centri.Inizia(Value)
            For i = 1 To Value
                Raggi.Add(0)
            Next
        End Set
    End Property
    Private Sub Rimuovi()
        Dim i As Short
        For i = 1 To Vertici.Punti.Count
            Raggi.remove(1)
        Next
        Vertici.Punti = Nothing
        Centri.Punti = Nothing
    End Sub
    Public Overrides Property Lunghezza() As Single
        Get
            Return prLunghezza
        End Get
        Set(ByVal Value As Single)
            prLunghezza = Value
        End Set
    End Property
    Public Overrides Property Larghezza() As Single
        Get
            Return prLarghezza
        End Get
        Set(ByVal Value As Single)
            prLarghezza = Value
        End Set
    End Property
    Private Sub Class_Terminate_Renamed()
        Vertici = Nothing
        Centri = Nothing
        Raggi = Nothing
        GenMem = Nothing
    End Sub
    Protected Overrides Sub Finalize()
        Class_Terminate_Renamed()
        MyBase.Finalize()
    End Sub
    Public Overloads Sub Pesi()
        GenMem.LeggiMat(TipoMat)
        GenMem.PesiSp(TipoMat)
        GenMem.Pnet0 = Area() * Spessore * GenMem.PesoSp1
        CalcInscritto(Larghezza, Lunghezza)
        If GenMem.Classe1 = 3 Then
            GenMem.plor0 = GenMem.Pnet0
            ' Param% = 1
        Else
            '      PLOR = 1.05 * PNET
            GenMem.plor0 = (Larghezza + GenMem.MargTag(Int(Spessore))) * (Lunghezza + GenMem.MargTag(Int(Spessore))) * Spessore * GenMem.PesoSp1
            '   Param% = t
        End If
        GenMem.Psfri0 = GenMem.plor0 - GenMem.Pnet0
        GenMem.PNET = GenMem.Pnet0
    End Sub
    Public Overloads Sub CalcGrezzi()
        Dim grezzo As New clsGrezzo1
        GenMem.ClearGrezzi()
        GenMem.IniziaGrezzo(grezzo)
        If grezzo Is Nothing Then Exit Sub
        CalcInscritto(Larghezza, Lunghezza)
        grezzo.Dimens(1) = Larghezza + GenMem.MargTag(Int(Spessore)) '+ Record(jRec).Dati(5) 'toll lav
        grezzo.Dimens(2) = Lunghezza + GenMem.MargTag(Int(Spessore))
        grezzo.NPezzi = GenMem.Qta
        grezzo.Vartxt(1) = "POLI"
        grezzo.Variab(1) = Spessore ' + Record(jRec).Dati(4) 'toll.lav
    End Sub
    Public Function Area() As Single
        Dim i As Short
        Dim A, dist As Single
        Dim Alfa As Single
        For i = 1 To Npunti - 1
            A = A + (Vertici.Punti.Item(i).TextData.y + Vertici.Punti.Item(i + 1).TextData.y) / 2 * (Vertici.Punti.Item(i + 1).TextData.X - Vertici.Punti.Item(i).TextData.X)
        Next
        Area = System.Math.Abs(A)
        For i = 1 To Npunti - 1
            If Raggi.Item(i).TextData <> 0 Then
                dist = Vertici.Punti.Item(i).TextData.DistPunPun(Vertici.Punti.Item(i + 1).TextData)
                Alfa = System.Math.Asin(dist / 2 / System.Math.Abs(Raggi.Item(i).TextData))
                Area = Area + (Alfa * Raggi.Item(i).TextData ^ 2 - System.Math.Abs(Raggi.Item(i).TextData) * System.Math.Cos(Alfa) * dist / 2) * System.Math.Sign(Raggi.Item(i).TextData)
            End If
        Next
    End Function
    Public Sub CalcInscritto(ByRef Larghezza As Single, ByRef Lunghezza As Single)
        Dim Linea As New RoutBase1.clsLinea2
        Dim i As Short
        Dim Linea1 As New RoutBase1.clsLinea2
        Dim i1, i2 As Short
        Dim dist1, dist, dist0 As Single
        Dim iprima, idopo As Short
        Dim imax As Single
        Dim Piede As New RoutBase1.clsVec2
        Dim Direz As New RoutBase1.clsVec2
        Dim segno As Boolean
        Dim ii1, ii2 As Short
        i1 = 1 : i2 = 2
        Do Until Raggi.Item(i1).TextData = 0
            i1 = i1 + 1
            i2 = i2 + 1
            If i1 > Npunti Then
                MsgBox("Errore in CalcInscritto")
                Exit Sub
            End If
            If i2 > Npunti Then i2 = 1
        Loop
        Linea.P0 = New RoutBase1.clsVec2 ' Vertici.Punti(i1)
        Linea.p1 = New RoutBase1.clsVec2 'Vertici.Punti(i2)
        Linea.P0.X = Vertici.Punti.Item(i1).TextData.X
        Linea.P0.y = Vertici.Punti.Item(i1).TextData.y
        Linea.p1.X = Vertici.Punti.Item(i2).TextData.X
        Linea.p1.y = Vertici.Punti.Item(i2).TextData.y
        Linea.CalcolaDir()
        dist = 0
        For i = 1 To Npunti
            If i <> i1 And i <> i2 Then
                dist1 = Linea.DistPunLinea(Vertici.Punti.Item(i).TextData)
                If dist1 > dist Then
                    dist = dist1
                    imax = i
                End If
            End If
        Next
        If imax = 0 Then Exit Sub
        iprima = imax - 1 : If iprima = 0 Then iprima = Npunti
        segno = False
        If Raggi.Item(iprima).TextData > 0 Then
            ii1 = iprima : ii2 = imax
            Cerchio(ii1, ii2, Linea, segno, dist, dist1)
        End If
        If Raggi.Item(imax).TextData > 0 Then
            idopo = imax + 1
            If idopo > Npunti Then idopo = 1
            ii1 = imax : ii2 = idopo
            Cerchio(ii1, ii2, Linea, segno, dist, dist1)
        End If
        Larghezza = dist
        Direz.X = Linea.Direz.X
        Direz.y = Linea.Direz.y
        Linea.Direz.X = -Direz.y
        Linea.Direz.y = Direz.X
        Linea.CalcolaDir()
        dist0 = -clsTrigon.Infinito
        dist1 = clsTrigon.Infinito
        segno = True
        For i = 1 To Npunti
            dist = Linea.DistPunLinea(Vertici.Punti.Item(i).TextData, True)
            If Raggi.Item(i).TextData > 0 Then
                ii1 = i : ii2 = i + 1
                If ii2 > Npunti Then ii2 = 1
                Cerchio(ii1, ii2, Linea, segno, dist, dist1)
            End If
            If dist < dist1 Then dist1 = dist
            If dist > dist0 Then dist0 = dist
        Next
        Lunghezza = dist0 - dist1
        Exit Sub
    End Sub
    Private Sub Cerchio(ByVal ii1 As Short, ByVal ii2 As Short, ByVal Linea As RoutBase1.clsLinea2, ByVal segno As Boolean, _
    ByVal dist As Single, ByVal dist1 As Single)
        Dim dist2 As Single
        Dim Alfa As Single
        Dim Centro As New RoutBase1.clsVec2
        Dim Direz As New RoutBase1.clsVec2
        Dim is2 As Short
        Dim Tangenza As New RoutBase1.clsVec2
        Dim ang2, ang1, ang3 As Single
        Dim dang As Single
        dist2 = Vertici.Punti.Item(ii1).TextData.DistPunPun(Vertici.Punti.Item(ii2).TextData)
        Alfa = System.Math.Asin(dist2 / 2 / System.Math.Abs(Raggi.Item(ii1).TextData))
        Centro.X = Centri.Punti.Item(ii1).TextData.X
        Centro.y = Centri.Punti.Item(ii1).TextData.y
        For is2 = -1 To 1 Step 2
            Direz.X = -is2 * Linea.Direz.y
            Direz.y = is2 * Linea.Direz.X
            Tangenza.X = Centro.X + Direz.X * Raggi.Item(ii1).TextData
            Tangenza.y = Centro.y + Direz.y * Raggi.Item(ii1).TextData
            ang1 = GlobalRoutines.arco((Vertici.Punti.Item(ii1).TextData.X - Centro.X) / Raggi.Item(ii1).TextData, (Vertici.Punti.Item(ii1).TextData.y - Centro.y) / Raggi.Item(ii1).TextData)
            ang2 = GlobalRoutines.arco((Tangenza.X - Centro.X) / Raggi.Item(ii1).TextData, (Tangenza.y - Centro.y) / Raggi.Item(ii1).TextData)
            ang3 = GlobalRoutines.arco((Vertici.Punti.Item(ii2).TextData.X - Centro.X) / Raggi.Item(ii1).TextData, (Vertici.Punti.Item(ii2).TextData.y - Centro.y) / Raggi.Item(ii1).TextData)
            If (ang1 - ang2) * (ang2 - ang3) > 0 Then
                dang = System.Math.Abs(ang1 - ang2)
                If dang < PI Then
                    dist1 = Linea.DistPunLinea(Tangenza, segno)
                    If System.Math.Abs(dist1) > System.Math.Abs(dist) Then dist = dist1
                End If
            End If
        Next is2
    End Sub
    Public Overloads Sub Copia(ByRef A As clsPolig)
        Dim R As Single
        Dim j As Short
        If A Is Nothing Then A = New clsPolig
        A.Larghezza = Larghezza
        A.Lunghezza = Lunghezza
        A.Spessore = Spessore
        A.Alt = Alt
        A.Alung = Alung
        A.TipoMat = TipoMat
        GenMem.Copia(A.GenMem)
        A.GenMem.Parent = A
        If Not Vertici Is Nothing Then
            A.Vertici = New RoutBase1.clsPunti
            Vertici.Copia((A.Vertici))
        End If
        If Not Centri Is Nothing Then
            A.Centri = New RoutBase1.clsPunti
            Centri.Copia((A.Centri))
        End If
        If Not Raggi Is Nothing Then
            A.Raggi = New RoutBase1.LinkListS
            For j = 1 To Raggi.Count()
                A.Raggi.Add(R)
                A.Raggi(j).TextData = Raggi(j).TextData
            Next
        End If
    End Sub
    Public Overloads Sub leggi(ByVal DiscoR As String, ByVal Mode As Short)
        MsgBox("Funzione non disponibile")
        Funzioni.OKfrmDati = False
    End Sub
    Public Sub ShowOid(ByRef SubRect As RoutBase1.Rettangolo)
        Dim Lung, LARG, Verso As Single
        Dim Ruota As Boolean
        Dim Npunti As Short
        Dim Puntif, Puntif1 As RoutBase1.clsPunti
        Dim CoszSW As New RoutBase1.clsVec3
        CalcInscritto(LARG, Lung)
        Ruota = (LARG + GenMem.MargTag(Spessore) - SubRect.LARG) * (Lung + GenMem.MargTag(Spessore) - SubRect.Lung) < 0
        Rifer = 1
        With GenMem.posizione
            If Ruota Then
                .CosTraversa.X = 0 : .CosTraversa.y = 1
                .CosDiritta.X = -1 : .CosDiritta.y = 0
                .Origine.X = SubRect.x(1)
                .Origine.y = SubRect.y(1) + (SubRect.y(4) - SubRect.y(1)) / 2
            Else
                .CosTraversa.X = 1 : .CosTraversa.y = 0
                .CosDiritta.X = 0 : .CosDiritta.y = 1
                .Origine.X = SubRect.x(1) + (SubRect.x(2) - SubRect.x(1)) / 2
                .Origine.y = SubRect.y(1)
            End If
            .CosTerza.X = 0 : .CosTerza.y = 0 : .CosTerza.Z = -1
            .Origine.Z = 1000
            .CosDiritta.Z = 0
            .CosTraversa.Z = 0
        End With
        GenMem.SwappedPos = New Posizione
        GenMem.posizione.Copia((GenMem.SwappedPos))
        LungPip = 1
        sezioni.Tipo(LungPip) = 0
        Call IntersPol(Me, Npunti, Puntif, Puntif1, Verso, CoszSW)
        Call SpezzSpecial(Npunti, Puntif, Puntif1, Raggi, CoszSW)
        Call Funzioni.DisRut.ctrait(0, 0.1)
    End Sub
End Class