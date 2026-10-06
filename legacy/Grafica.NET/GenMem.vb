Option Strict Off
Option Explicit On
Imports RoutBase1
<Serializable()> Public Class clsGenMem
    Public Unit As Short
    Public Parent As Membratura
    Public PosDis As Short
    Public Tipo As Short
    Public Ind As Short
    Public Denom As String
    Public Qta As Short
    Public Materiale As String
    Public Dimensioni As String
    Public Pnet0 As Single
    Public Psfri0 As Single
    Public plor0 As Single
    Public Pnet1 As Single
    Public Psfri1 As Single
    Public Plor1 As Single
    Public LireKg1 As Single
    Public LireKg2 As Single
    Public LireKg3 As Single
    Public LireTot As Single
    Public LireTot1 As Single
    Public LireTot2 As Single
    Public LireTot3 As Single
    Public LireLETot As Single
    Public Indmat1 As Short
    Public IndMat2 As Short
    Public IndMat3 As Short
    Public LavorEst As Short
    Public Note As String
    Public PesoSp As Single
    Public PesoSp1 As Single
    Public PesoSp2 As Single
    Public PesoSp3 As Single
    Public TAGLIO As Single
    Public Classe1 As LibMat.ClasseMateriale
    Public Classe2 As LibMat.ClasseMateriale
    Public Classe3 As LibMat.ClasseMateriale
    Public prezzoID As Integer
    Public prezzoID2 As Integer
    Public prezzoID3 As Integer
    Public MaterNome(3) As String
    Public posizione As posizione
    Public SwappedPos As posizione
    Public Param As Short 'Parametri prezzo
    Public Param2 As Short '
    Public MF As String
    Public Appesi As OggList
    Public Segnalini As OggList
    Public Mater As LibMat.clsMatCompos
    Public grezzi As OggList
    Public Lato As Short
    Private Pesonet As Single
    Private Pesosfri As Single
    Public key As String 'chiave negli appesi
    Public keyG As String ' chiave negli elementi
    Public Superiore As Membratura
    Public Sub New()
        MyBase.New()
        Dim m As clsGenMem
        Dim IndMax As Short
        Dim i As Short
        For i = 0 To 3 : MaterNome(i) = "" : Next
        Materiale = ""
        Denom = ""
        Appesi = New OggList(0)
        Segnalini = New OggList(0)
        grezzi = New OggList(0)
        Mater = New LibMat.clsMatCompos
        posizione = New Posizione
        If Apparecchio Is Nothing Then Exit Sub
        Dim n As OggList.NodeP = Apparecchio.Elementi.nodeHead.Next
        While Not n Is Nothing
            m = n.TextData.GenMem
            If m.Ind > IndMax Then IndMax = m.Ind
            n = n.Next
        End While
        Ind = IndMax + 1
        key = ""
        keyG = ""
    End Sub
    Public Sub LeggiMat(ByRef TipoMat As Short)
        If Indmat1 > 0 And Not Mater.Mat(1).Indmat = Indmat1 Then
            Mater.Mat(1).Indmat = Indmat1
            Mater.Mat(1).RecupMat(Inizio.Archdir)
            MaterNome(1) = Mater.Mat(1).MatStr
            Classe1 = Mater.Mat(1).Classe
        End If
        If TipoMat = 1 Then Exit Sub
        If IndMat2 > 0 And Not Mater.Mat(2).Indmat = IndMat2 Then
            Mater.Mat(2).Indmat = IndMat2
            Mater.Mat(2).RecupMat(Inizio.Archdir)
            MaterNome(2) = Mater.Mat(2).MatStr
            Classe2 = Mater.Mat(2).Classe
        End If
        If IndMat3 > 0 And Not Mater.Mat(3).Indmat = IndMat3 Then
            Mater.Mat(3).Indmat = IndMat3
            Mater.Mat(3).RecupMat(Inizio.Archdir)
            MaterNome(3) = Mater.Mat(3).MatStr
            Classe3 = Mater.Mat(3).Classe
        End If
    End Sub
    Public Sub PesiSp(ByRef TipoMat As Short)
        If PesoSp1 <= 0 Then
            If PesoSp > 0 Then
                PesoSp1 = PesoSp * EXP9
            Else
                PesoSp = Mater.Mat(1).PSP
                PesoSp1 = PesoSp * EXP9
            End If
        End If
        If PesoSp1 <= 0 Then
            Dim testo As String = "Il peso specifico del materiale " + Mater.Mat(1).MatStr + "non è stato definito."
            'MsgBox(testo, , "IST")
        End If
        If TipoMat = 1 Then Exit Sub
        If PesoSp2 = 0 Then PesoSp2 = Mater.Mat(2).PSP * EXP9
        If PesoSp3 = 0 Then PesoSp3 = Mater.Mat(3).PSP * EXP9
    End Sub

    Public Function MargTag(ByRef SP As Single) As Single
        Dim Marg As Short
        Select Case SP
            Case Is <= 12 : Marg = 10
            Case Is <= 20 : Marg = 15
            Case Else : Marg = 20
        End Select
        If Mater.Mat(1).Classe > 1 Then Marg = Marg + 6
        MargTag = Marg
    End Function
    Public Sub Leggiprezzi(ByRef Param1 As Single, ByRef Param2 As Single, ByRef Param3 As Single, Optional ByRef Code As Short = 0, Optional ByRef ParamS As Single = 0)
        'Code=1 Anelli, 2=Dischi, 3 LWN 4 WN 5 Virole 6 tronchetti 7 flangioni 8 PT 9 gomiti
        Dim Classe As Short
        If IUNL = 5 Then Exit Sub
        Classe = Mater.Mat(1).Classe
        If (LireKg1 = 0 Or ForzaPrezzo) And Not Caricamento Then
            If Trim(MF) = "FL" Then
                LireKg1 = Mater.Mat(1).prezzo(Param1, Classe, Inizio.Archdir, Inizio.DiscoTem, Code, 2, , prezzoID)
            ElseIf Classe = 4 Then
                LireKg1 = Mater.Mat(1).prezzo(Param1, Classe, Inizio.Archdir, Inizio.DiscoTem, Code, Unit, ParamS, prezzoID)
            Else
                LireKg1 = Mater.Mat(1).prezzo(Param1, Classe, Inizio.Archdir, Inizio.DiscoTem, Code, , ParamS, prezzoID)
            End If
        End If
        If Classe = 4 Then
            If Unit = 2 Then
                LireTot1 = LireKg1 * CType(Parent, Tubi).LungTot
            Else
                Unit = 1
                LireTot1 = LireKg1 * plor0
            End If
        Else
            LireTot1 = LireKg1 * plor0
        End If
        If IndMat2 > 0 Then
            Classe = Mater.Mat(2).Classe
            If LireKg2 = 0 Or ForzaPrezzo Then
                LireKg2 = Mater.Mat(2).prezzo(Param2, Classe, Inizio.Archdir, Inizio.DiscoTem, Code, , , prezzoID2)
            End If
            LireTot2 = LireKg2 * Plor1
        End If
        If IndMat3 > 0 Then
            Classe = Mater.Mat(3).Classe
            If LireKg3 = 0 Or ForzaPrezzo Then
                LireKg3 = Mater.Mat(3).prezzo(Param3, Classe, Inizio.Archdir, Inizio.DiscoTem, Code, , , prezzoID3)
            End If
        End If
        LireTot = LireTot1 + LireTot2
        'da rivedere i prezzi (placcato)
        'Set Mat = Nothing
    End Sub
    Public Property PNET() As Single
        Get
            If Pesonet = 0 Then Pesonet = Pnet0 + Pnet1
            PNET = Pesonet
        End Get
        Set(ByVal Value As Single)
            Pesonet = Value
            'PNET0 = vNewValue
        End Set
    End Property
    Public Property PSFR() As Single
        Get
            If Pesosfri = 0 Then Pesosfri = Psfri0 + Psfri1
            PSFR = Pesosfri
        End Get
        Set(ByVal Value As Single)
            Pesosfri = Value
            Psfri0 = Value
        End Set
    End Property
    Public Sub ClearAppesi(ByRef anche As Boolean)
        Dim i As Short
        If IUNL > 4 Then Exit Sub
        i = 0
        Do While i < CType(Appesi, OggList).Count()
            AppesiRemove(i, anche)
            i = i + 1
        Loop
    End Sub

    Public Sub AppesiRemove(ByRef i As Short, ByRef anche As Boolean)
        Dim j, k As Short
        If Apparecchio Is Nothing Then Exit Sub
        k = 1
        Do While k <= CType(CType(Appesi(i).GenMem, clsGenMem).Appesi, OggList).Count
            j = 1
            Do While j <= CType(Apparecchio.Elementi, OggList).Count()
                If Apparecchio.Elementi(j) Is CType(Appesi(i).GenMem, clsGenMem).Appesi(k) Then
                    CType(Apparecchio.Elementi, OggList).remove(j)
                    Exit Do
                    'j = j - 1
                End If
                j = j + 1
            Loop
            If anche Then
                CType(CType(Appesi(i).GenMem, clsGenMem).Appesi, OggList).remove(1) : k = k - 1
            End If
            k = k + 1
        Loop
        j = 1
        Do While j <= Apparecchio.Elementi.Count()
            If Apparecchio.Elementi(j) Is Appesi(i) Then
                Apparecchio.Elementi.remove(j)
                Exit Do
                'j = j - 1
            End If
            j = j + 1
        Loop
        If anche Then Appesi.remove(i) : i = i - 1
    End Sub

    Public Sub IniziaGrezzo(ByRef g As clsGrezzo1)
        Dim i As Short
        g = New clsGrezzo1
        If Parent Is Nothing Then
            MsgBox("parent")
        End If
        For i = 0 To Apparecchio.Elementi.Count - 1
            If Parent Is Apparecchio.Elementi(i) Then
                g.IndRec = i
                Exit For
            End If
        Next
        If g.IndRec = 0 Then
            g = Nothing
            Exit Sub
        End If
        'g.IndRec = Parent.Ind 'correggere
        g.Indmat = Indmat1 'Mater.Mat(1).Indmat
        g.NPezzi = 1
        grezzi.Add(g)
    End Sub

    Public Sub ClearGrezzi()
        Dim i As Short
        For i = 1 To grezzi.Count()
            grezzi.remove(1)
        Next
    End Sub
    Public Sub AppesiAdd(ByRef O As Membratura)
        Dim o1 As Membratura
        Dim n As OggList.NodeP = Appesi.nodeHead.Next
        While Not n Is Nothing
            o1 = n.TextData
            If O Is o1 Then Exit Sub
            n = n.Next
        End While
        AppesiAddk(O)
    End Sub
    Public Sub AppesiAddk(ByRef O As Membratura)
        O.GenMem.key = O.GenMem.Denom
        O.GenMem.Superiore = Parent
        Appesi.Add(O, O.GenMem.key)
    End Sub
    Public Sub Copia(ByRef A As clsGenMem)
        Dim i As Integer
        Dim g As clsGrezzo1
        A.Parent = Nothing
        'A.PosDis = PosDis
        'A.Tipo=Tipo
        'A.ind=ind
        A.Denom = Denom
        A.Qta = Qta
        A.Materiale = Materiale
        A.Dimensioni = Dimensioni
        A.Pnet0 = Pnet0
        A.Psfri0 = Psfri0
        A.plor0 = plor0
        A.Pnet1 = Pnet1
        A.Psfri1 = Psfri1
        A.Plor1 = Plor1
        A.LireKg1 = LireKg1
        A.LireKg2 = LireKg2
        A.LireKg3 = LireKg3
        A.LireTot = LireTot
        A.LireTot1 = LireTot1
        A.LireTot2 = LireTot2
        A.LireTot3 = LireTot3
        A.LireLETot = LireLETot
        A.Indmat1 = Indmat1
        A.IndMat2 = IndMat2
        A.IndMat3 = IndMat3
        A.LavorEst = LavorEst
        A.Note = Note
        A.PesoSp = PesoSp
        A.PesoSp1 = PesoSp1
        A.PesoSp2 = PesoSp2
        A.PesoSp3 = PesoSp3
        A.TAGLIO = TAGLIO
        A.Classe1 = Classe1
        A.Classe2 = Classe2
        A.Classe3 = Classe3
        For i = 1 To 3
            A.MaterNome(i) = MaterNome(i)
        Next i
        posizione.Copia((A.posizione))
        If Not SwappedPos Is Nothing Then SwappedPos.Copia((A.SwappedPos))
        A.Param = Param
        A.Param2 = Param2
        A.MF = MF
        Dim n As OggList.NodeP = grezzi.nodeHead.Next
        While Not n Is Nothing
            g = n.TextData
            A.grezzi.Add(g)
            n = n.Next
        End While
    End Sub
    Public Sub WOGrezzo(ByRef g As clsGrezzo1)
        g.Dimens(1) = Plor1
    End Sub
    Private Sub Class_Terminate_Renamed()
        posizione = Nothing
        SwappedPos = Nothing
        Mater = Nothing
        If Not grezzi Is Nothing Then
            grezzi.RemoveAll()
        End If
        grezzi = Nothing
    End Sub
    Protected Overrides Sub Finalize()
        Class_Terminate_Renamed()
        MyBase.Finalize()
    End Sub
End Class