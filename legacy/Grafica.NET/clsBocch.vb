Option Strict On
Option Explicit On
Imports RoutBase1
<Serializable()> Public Class clsBocch
    Inherits Membratura
    Private prStandard As Flangia
    Public Tronchetto As Cilindro
    Public Tirante As clsTirante
    Public Guarniz As clsGuarniz
    Public ControFlangia As clsBocch
    Public Pad As Anello
    'Public TipoMat As Short '1 senza rip. 2 con 3 fl.rip.
    Private prTipoF As Short
    '1 "DA FORGIATO CON SCARPA"
    '2 "DA FORGIATO AUTORINFORZATO"
    '3 "STANDARD CON RINFORZO"
    '4 "STANDARD SENZA RINFORZO"
    '5 "FLANGIA SOLA"
    Public Accoppiata As Boolean
    Public Cieca As Boolean
    Private prDiamScarpa As Single
    Private prSpesScarpa As Single
    Private prDiamRinf As Single
    Public AltzRinf As Single
    Private prRanda As Single
    Private prDiamInt As Single
    Private prSporgenza As Single
    Private prSpostLat As Single
    Public SpessRive As Single
    '----------------------
    'Public GenMem As clsGenMem
    'Public Variato As Boolean
    Private Mode As Short
    Private Ri, Re As Single
    Private Ogg As Membratura
    Private i As Short
    Public Overrides Property TipoF() As Short
        Get
            Return prTipoF
        End Get
        Set(ByVal Value As Short)
            prTipoF = Value
        End Set
    End Property
    Public Overrides Property SpesScarpa() As Single
        Get
            Return prSpesScarpa
        End Get
        Set(ByVal Value As Single)
            prSpesScarpa = Value
        End Set
    End Property
    Public Overrides Property SpostLat() As Single
        Get
            Return prSpostLat
        End Get
        Set(ByVal Value As Single)
            prSpostLat = Value
        End Set
    End Property
    Public Overrides Property Sporgenza() As Single
        Get
            Return prSporgenza
        End Get
        Set(ByVal Value As Single)
            prSporgenza = Value
        End Set
    End Property
    Public Overrides Property Randa() As Single
        Get
            Return prRanda
        End Get
        Set(ByVal Value As Single)
            prRanda = Value
        End Set
    End Property
    Public Sub New()
        MyBase.New()
        GenMem = New clsGenMem
        GenMem.Parent = Me
        TipoF = 4
        Variato = True
        Standard = New Flangia
    End Sub
    Protected Overrides Sub Finalize()
        'GenMem = Nothing
        'Standard = Nothing
        'Tronchetto = Nothing
        'Tirante = Nothing
        'Guarniz = Nothing
        'ControFlangia = Nothing
        'Pad = Nothing
        MyBase.Finalize()
    End Sub
    Public Overrides Property Diamint() As Single
        Get
            Return prDiamInt
        End Get
        Set(ByVal Value As Single)
            prDiamInt = Value
        End Set
    End Property
    Public Overrides Property Standard() As Flangia
        Get
            Return prStandard
        End Get
        Set(ByVal Value As Flangia)
            prStandard = Value
        End Set
    End Property
    Public Overrides Property DiamScarpa() As Single
        Get
            Return prDiamScarpa
        End Get
        Set(ByVal Value As Single)
            prDiamScarpa = Value
        End Set
    End Property
    Public Overrides Property DiamRinf() As Single
        Get
            Return prDiamRinf
        End Get
        Set(ByVal Value As Single)
            prDiamRinf = Value
        End Set
    End Property
    Public Overloads Sub leggi(ByVal DiscoR As String, ByVal Mode As Short)
        Select Case Mode
            Case 0
                If Not Variato Then Exit Sub
                Call Aggancio(DiscoR)
                Calcoli()
                Pesi()
                GenMem.Leggiprezzi(Int(Param1), 0, 0, Code7)
                StringDIME()
                StringMATE()
                CalcGrezzi()
                Appendi(Mode)
                Variato = False
            Case 1
                Membro = Me
                NonDisegnare = True
                FormDati.ShowDialog()
                If Funzioni.OKfrmDati Then
                    Appendi(Mode)
                    If IUNL = 5 And Randa > 0 Then GenMem.posizione.DirTraversa = "Pe"
                End If
                NonDisegnare = False
        End Select
        '   SalvaLav
    End Sub
    Private Sub Calcoli()
        If Standard.K1 = 0 Then Standard.K1 = 1
        If Standard.K2 = 0 Then Standard.K2 = 1
        If Standard.K3 = 0 Then Standard.K3 = 1
        If Standard.Facing = 0 Then Standard.Facing = 1
        Standard.Leggi(Standard.K1, Standard.K2, Standard.Facing, Standard.TabFlan, Standard.K3, False, Inizio.DiscoRam)
    End Sub
    Public Sub StringDIME()
        Dim Note(4) As String
        Note(0) = Standard.strTipo & " " & Standard.strDiam & Chr(34) & " ASA" & Standard.strRati & "# DI." & Str(Diamint) '             flangia WN. SO. LJ.
        Note(1) = Note(0) & "h." & Str(Standard.Altezza) '                                              flangia LWN.
        Note(2) = Standard.strTipo & " " & Standard.strDiam & Chr(34) & " ASA" & Standard.strRati & "#"
        Note(3) = Note(1) & "DE." & Str(DiamRinf) & "/" & LTrim(Str(Diamint)) 'flangia LWN. con tronchetto autorinforzante
        Note(4) = "SCARPA DE." & Str(DiamScarpa) & " sp." & Str(SpesScarpa) '                            tronchetto con scarpa
        If Standard.K3 = 1 Or Standard.K3 = 2 Or Standard.K3 = 3 Then GenMem.Dimensioni = Note(0)
        If Standard.K3 = 4 Then GenMem.Dimensioni = Note(1)
        If Standard.K3 = 5 Then GenMem.Dimensioni = Note(2)
        If Standard.K3 = 4 And DiamRinf > Diamint Then GenMem.Dimensioni = Note(3)
        If TipoF = 1 Then GenMem.Dimensioni = GenMem.Dimensioni & Note(4)
    End Sub
    Public Overrides Sub StringMATE()
        Dim M0 As String = GenMem.MaterNome(1).Trim
        If M0 = "" Then M0 = GenMem.Materiale.Trim
        GenMem.Materiale = M0
    End Sub
    Public Overloads Sub CalcGrezzi()
        Dim grezzo As New clsGrezzo1
        GenMem.ClearGrezzi()
        GenMem.IniziaGrezzo(grezzo)
        If grezzo Is Nothing Then Exit Sub
        grezzo.Vartxt(1) = Standard.strTipo
        grezzo.Vartxt(2) = Standard.strDiam
        grezzo.Vartxt(3) = Standard.strRati
        grezzo.Variab(1) = Standard.TabFlan
        Select Case Standard.K3
            Case 1
            Case 2
            Case 3
            Case 4
            Case 5
        End Select
    End Sub
    Public Overloads Sub Pesi()
        Dim v As Single
        GenMem.LeggiMat(TipoMat)
        GenMem.PesiSp(TipoMat)
        v = LeggiFlanBase(16, Standard.TabFlan, Standard.K1, Standard.K2, Standard.K3)
        GenMem.Pnet0 = v * GenMem.PesoSp1 / 7850 / EXP9
        v = LeggiFlanBase(17, Standard.TabFlan, Standard.K1, Standard.K2, Standard.K3)
        GenMem.plor0 = v * GenMem.PesoSp1 / 7850 / EXP9
    End Sub
    Public Sub Appendi(ByRef lMode As Short)
        Mode = lMode
        If Not Editing Then GenMem.ClearAppesi(True)
        If Accoppiata Then
            If Not Editing Then
                If Guarniz Is Nothing Then Guarniz = New clsGuarniz
                SetGuarniz()
            Else
                If Guarniz Is Nothing Then
                    Dim n As OggList.NodeP = CType(GenMem.Appesi, OggList).nodeHead.Next
                    While Not n Is Nothing
                        Ogg = CType(n.textdata, Membratura)
                        If Ogg.GenMem.Tipo = -28 Then
                            Guarniz = CType(Ogg, clsGuarniz)
                            Exit While
                        End If
                        n = n.Next
                    End While
                End If
                If Guarniz Is Nothing Then
                    Guarniz = New clsGuarniz
                    SetGuarniz()
                End If
            End If
            Guarniz.Leggi((Inizio.DiscoRam), Mode)
            If Not Editing Then
                If ControFlangia Is Nothing Then ControFlangia = New clsBocch
                SetControFlangia()
            Else
                If ControFlangia Is Nothing Then
                    Dim n As OggList.NodeP = CType(GenMem.Appesi, OggList).nodeHead.Next
                    While Not n Is Nothing
                        Ogg = CType(n.textdata, Membratura)
                        If Ogg.GenMem.Tipo = -10 Then
                            ControFlangia = CType(Ogg, clsBocch)
                            Exit While
                        End If
                        n = n.Next
                    End While
                End If
                If ControFlangia Is Nothing Then
                    ControFlangia = New clsBocch
                    ControFlangia.TipoF = 5
                    SetControFlangia()
                End If
                'ControFlangia.GenMem.Tipo = -10
            End If
            ControFlangia.Leggi((Inizio.DiscoRam), Mode)
            If Not Editing Then
                If Tirante Is Nothing Then Tirante = New clsTirante
                SetTirante()
            Else
                If Tirante Is Nothing Then
                    Dim n As OggList.NodeP = CType(GenMem.Appesi, OggList).nodeHead.Next
                    While Not n Is Nothing
                        Ogg = CType(n.textdata, Membratura)
                        If Ogg.GenMem.Tipo = -13 Then
                            Tirante = CType(Ogg, clsTirante)
                            Exit While
                        End If
                        n = n.Next
                    End While
                End If
                If Tirante Is Nothing Then
                    Tirante = New clsTirante
                    SetTirante()
                End If
            End If
            Tirante.Leggi((Inizio.DiscoRam), Mode)
        Else
            ControFlangia = Nothing
            Guarniz = Nothing
            Tirante = Nothing
            i = 0
            Do While i < CType(GenMem.Appesi, OggList).Count
                Select Case CType(GenMem.Appesi(i), Membratura).GenMem.Tipo
                    Case -10, -13, -28 : GenMem.AppesiRemove(i, True)
                        'i = i - 1
                End Select
                i = CShort(i + 1)
            Loop
        End If
        If TipoF > 2 And TipoF < 5 And Standard.K3 = 1 Then
            '           jRec = jRec + 1
            If Not Editing Then
                If Tronchetto Is Nothing Then Tronchetto = New Cilindro
                SetTronchetto()
            Else
                CercaTrAppeso()
            End If
            Tronchetto.Leggi((Inizio.DiscoRam), Mode)
        Else
            Tronchetto = Nothing
            i = 0
            Do While i < CType(GenMem.Appesi, OggList).Count
                Select Case CType(GenMem.Appesi(i), Membratura).GenMem.Tipo
                    Case -2 : GenMem.AppesiRemove(i, True)
                        'i = i - 1
                        If i = 0 Then Exit Do
                End Select
                i = CShort(i + 1)
            Loop
        End If
        If TipoF = 3 Then
            If Not Editing Then
                If Pad Is Nothing Then Pad = New Anello
                SetPad()
            Else
                CercaPadAppeso()
            End If
            Pad.Leggi((Inizio.DiscoRam), Mode)
            If IUNL = 5 And Pad.Dmant > 0 Then GenMem.posizione.DirTraversa = "Pe"
        Else
            Pad = Nothing
            i = 0
            Do While i < CType(GenMem.Appesi, OggList).Count
                Select Case CType(GenMem.Appesi(i), Membratura).GenMem.Tipo
                    Case -17 : GenMem.AppesiRemove(i, True)
                        'i = i - 1
                End Select
                i = CShort(i + 1)
            Loop
        End If
    End Sub
    Private Sub SetGuarniz()
        With Guarniz
            .GenMem.Tipo = -28
            Re = Standard.GradExt / 2
            Ri = Standard.GradInt / 2
            If Ri = 0 Then Ri = Standard.Diamint / 2
            .DiamMed = Ri + Re
            .Largh = Re - Ri
            .Spess = 3
            .GenMem.Denom = "Guarn. su " & GenMem.Denom
            .GenMem.Qta = 1
            GenMem.AppesiAdd(CType(Guarniz, Membratura))
            GenMem.posizione.Copia((.GenMem.posizione))
            .GenMem.PosDis = Funzioni.SetPosizN(Me) 'RecordD(0).PosDis + jRec
            .GenMem.Ind = 0 ' jRec + RecordD(0).Ind
            .GenMem.posizione.DirDiritta = "=+"
            .GenMem.posizione.Quota = Str(Standard.Altezza)
            Funzioni.InitPosSpaN(CType(GenMem, Object), .GenMem)
        End With
    End Sub
    Private Sub SetControFlangia()
        With ControFlangia
            .GenMem.Tipo = -10
            .GenMem.Denom = "ControFl " & GenMem.Denom
            .GenMem.Qta = 1
            .Standard.K1 = Standard.K1 : .Standard.K2 = Standard.K2 : .Standard.Facing = Standard.Facing
            If Cieca Then
                .Standard.K3 = 5
            Else
                .Standard.K3 = Standard.K3
                .Diamint = Diamint
            End If
            GenMem.AppesiAdd(CType(ControFlangia, Membratura))
            GenMem.posizione.Copia((.GenMem.posizione))
            .GenMem.PosDis = Funzioni.SetPosizN(Me)
            .GenMem.Ind = 0
            .GenMem.posizione.DirDiritta = "=-"
            .GenMem.posizione.Quota = Str(ControFlangia.Standard.Altezza)
            .TipoMat = TipoMat
            .GenMem.Indmat1 = GenMem.Indmat1
            .GenMem.IndMat2 = GenMem.IndMat2
            Funzioni.InitPosSpaN(CType(Guarniz.GenMem, Object), .GenMem)
        End With
    End Sub
    Private Sub SetTirante()
        With Tirante
            .GenMem.Tipo = -13
            .Tipo = "T"
            'Standard.CatalogoR.FindFirst "Indice=" + Str(Standard.K3)
            .Dinst = Standard.BC
            .Lunghezza = 3 * Standard.Spessore + Standard.DiaFori
            .StandardTir.Xfil = 2
            .StandardTir.DN = Standard.DNtiranti
            .GenMem.Denom = "Tiranti. su " & GenMem.Denom
            .GenMem.Qta = CShort(Standard.NumBolts)
            GenMem.AppesiAdd(CType(Tirante, Membratura))
            GenMem.posizione.Copia((.GenMem.posizione))
            'Set .GenMem.posizione.SuChi = Me ' RecordD(0).Ind
            .GenMem.PosDis = Funzioni.SetPosizN(Me) ' RecordD(0).PosDis + jRec
            .GenMem.Ind = 0 ' jRec + RecordD(0).Ind
            .GenMem.posizione.DirDiritta = "=+"
            .GenMem.posizione.Quota = "Standard"
            If Not .StandardTir.CercaDN(Inizio.Archdir, Inizio.DiscoRam) Then .Leggi((Inizio.DiscoRam), Mode)
            Funzioni.InitPosSpaN(CType(GenMem, Object), .GenMem)
        End With
    End Sub
    Public Sub Converti(ByRef jRec As Short)
        'Dim Look As New clsGenLook
        'Dim k As Short
        'GenMem.ConvertiPos(jRec)
        'Look.LookTipoBocch(RecordD(jRec).Dati, True, Standard)
        'TipoMat = Look.TipoV
        'If Look.K1 * Look.K2 * Look.K3 = 0 Then MsgBox("Illogico in clsBocch.Converti")
        ''Standard.leggi Look.K1, Look.K2, Look.Facing, Look.TabFlan, Look.K3, False, ""
        'GenMem.LavorEst = Look.Lavorato
        'Sporgenza = Look.ALTBOC
        'DiamInt = Look.b
        'TipoF = Look.TipoF
        'If Look.junk1 = 2 Then
        ''TipoF=1
        'DiamScarpa = Look.DSCAR
        'SpesScarpa = Look.TSCAR
        'ElseIf Look.junk2 = 2 Then
        '    'TipoF = 2
        '    DiamRinf = Look.DRINF
        '    AltzRinf = Look.HRINF
        'ElseIf Look.junk3 = 2 Then
        '    'TipoF = 3
        'End If
        'If Look.junk4 = 2 Then
        'Accoppiata = True
        '' Set ControFlangia = new clsbocch
        'If Look.junk5 = 2 Then Cieca = True ': ControFlangia.Standard.K3 = 5
        'End If
        'SpostLat = Look.SpostLat
        'Standard.SpessTr = Look.t
        'Randa = Look.RANZA
        'If GenMem.Tipo < 0 Then Exit Sub
        'k = 0
        'Do
        'k = k + 1
        'If RecordD(k).Ind = 0 Or RecordD(k).Tipo >= 0 Then Exit Do
        'Select Case System.Math.Abs(RecordD(k).Tipo)
        '    Case 2
        'Tronchetto = New Cilindro
        'Tronchetto.Converti(k)
        'End Select
        'Loop

    End Sub

    Public Sub CercaPadAppeso()
        Dim Ogg As Membratura
        If Pad Is Nothing Then
            Dim n As OggList.NodeP = CType(GenMem.Appesi, OggList).nodeHead.Next
            While Not n Is Nothing
                Ogg = CType(n.TextData, Membratura)
                If Ogg.GenMem.Tipo = -17 Then
                    Pad = CType(Ogg, Anello)
                    Exit While
                End If
                n = n.Next
            End While
        End If
        If Pad Is Nothing Then
            Pad = New Anello
            SetPad()
        End If
    End Sub

    Public Sub SetPad()
        Dim Ogg As Membratura
        Dim SP As Single
        With Pad
            .GenMem.Tipo = -17
            .Diamint = Standard.DiamTr
            If Len(Trim(.GenMem.Denom)) = 0 Then .GenMem.Denom = "RINFORZO BOCCHELLO"
            .GenMem.Qta = 1
            GenMem.AppesiAdd(CType(Pad, Membratura))
            GenMem.posizione.Copia((.GenMem.posizione))
            .GenMem.PosDis = Funzioni.SetPosizN(Me) ' RecordD(0).PosDis + jRec
            .GenMem.Ind = 0 ' jRec + RecordD(0).Ind
            If .Diamext = 0 Then .Diamext = Int(2 * Standard.DiamTr)
            If .Spess = 0 Then .Spess = Int(Standard.SpessTr)
            .TipoS = 5
            .GenMem.posizione.DirDiritta = "=-"
            .GenMem.posizione.DirTraversa = "Au"
            Ogg = GenMem.posizione.SuChi
            SP = .Spess
            If Not Ogg Is Nothing Then SP = Ogg.Spessore
            If Not Tronchetto Is Nothing Then
                .GenMem.posizione.Quota = Str(-Tronchetto.Lunghezza + 2 * SP)
            Else
                .GenMem.posizione.Quota = Str(2 * SP)
            End If
            Funzioni.InitPosSpaN(CType(GenMem, Object), .GenMem)
            .GenMem.posizione.Raggio = "N.A."
            AggCoordN(.GenMem)
            Ogg = GenMem.posizione.SuChi
            Select Case Ogg.GenMem.Tipo 'Dmant
                Case 1, 34 'bocchello con pad su cilindro
                    .Dmant = Ogg.Diametro + 2 * (Ogg.Spessore) 'Diam=D+2(T1+T2)
                Case 3, 4, 5
                    .Dmant = 2 * Ogg.Diametro + 2 * Ogg.Spessore 'Diam=2*D+2(T1+T2)
                Case Else
                    .Dmant = 0
            End Select
        End With
    End Sub
    Public Function SetTronchetto() As Boolean
        If Tronchetto Is Nothing Then CercaTrAppeso()
        If Tronchetto Is Nothing Then Exit Function
        SetTronchetto = True
        With Tronchetto
            .GenMem.Tipo = -2
            .Lunghezza = Sporgenza - Standard.Altezza
            .Randa = Randa
            .SpessBase = (Standard.DiamTr - Diamint) / 2 'Standard.SpessTr
            .Diametro = Standard.DiamTr
            .GenMem.Denom = "TRONCHETTO su " & GenMem.Denom
            .GenMem.Qta = 1
            GenMem.AppesiAdd(CType(Tronchetto, Membratura))
            GenMem.posizione.Copia((.GenMem.posizione))
            .GenMem.PosDis = Funzioni.SetPosizN(Me)
            .GenMem.Ind = 0
            .GenMem.posizione.DirDiritta = "=-"
            .GenMem.posizione.Quota = "0"
            .GenMem.posizione.Anomal = "N.A."
            .GenMem.posizione.Raggio = "N.A."
            .GenMem.posizione.DirTraversa = "Auto"
            Funzioni.InitPosSpaN(CType(GenMem, Object), .GenMem)
            AggCoordN(.GenMem)
        End With
    End Function
    Public Sub CercaTrAppeso()
        Dim Ogg As Membratura
        If Tronchetto Is Nothing Then
            Dim n As OggList.NodeP = CType(GenMem.Appesi, OggList).nodeHead.Next
            While Not n Is Nothing
                Ogg = CType(n.TextData, Membratura)
                If CType(Ogg.GenMem, clsGenMem).Tipo = -2 Then
                    Tronchetto = CType(Ogg, Cilindro)
                    Exit While
                End If
                n = n.Next
            End While
        End If
        If Tronchetto Is Nothing Then
            Tronchetto = New Cilindro
            SetTronchetto()
        End If
    End Sub
    Public Overloads Sub Copia(ByRef A As clsBocch)
        If A Is Nothing Then A = New clsBocch
        If Not Standard Is Nothing Then Standard.Copia((A.Standard))
        If Not Tronchetto Is Nothing Then Tronchetto.Copia((A.Tronchetto))
        If Not Tirante Is Nothing Then Tirante.Copia(A.Tirante)
        If Not Guarniz Is Nothing Then Guarniz.Copia(A.Guarniz)
        If Not ControFlangia Is Nothing Then ControFlangia.Copia((A.ControFlangia))
        If Not Pad Is Nothing Then Pad.Copia((A.Pad))
        A.TipoMat = TipoMat
        A.TipoF = TipoF
        A.Accoppiata = Accoppiata
        A.Cieca = Cieca
        A.DiamScarpa = DiamScarpa
        A.SpesScarpa = SpesScarpa
        A.DiamRinf = DiamRinf
        A.AltzRinf = AltzRinf
        A.Randa = Randa
        A.Diamint = Diamint
        A.Sporgenza = Sporgenza
        A.SpostLat = SpostLat
        A.SpessRive = SpessRive
        '----------------------
        GenMem.Copia(A.GenMem)
        A.GenMem.Parent = A
        '????AggiornaApparecchio Me
    End Sub
    Public Overrides Sub RimuoviSpeciali(ByRef O As Membratura)
        If O Is Tronchetto Then Tronchetto = Nothing
        If O Is Tirante Then Tirante = Nothing
        If O Is Guarniz Then Guarniz = Nothing
        If O Is ControFlangia Then ControFlangia = Nothing
        If O Is Pad Then Pad = Nothing
    End Sub
    Public Overrides Property Code7() As Short
        Get
            Select Case Standard.K3
                Case 4 : Code7 = 3
                Case 1 : Code7 = 4
                Case 5 : Code7 = 2
                Case Else : Code7 = 1
            End Select
        End Get
        Set(ByVal Value As Short)

        End Set
    End Property
    Public Overrides Property Param1() As Single
        Get
            Param1 = GlobalRoutines.ConvPoll(Standard.strDiam)
        End Get
        Set(ByVal Value As Single)

        End Set
    End Property
    Public Overrides Property Spessore() As Single
        Get
            Spessore = (Standard.DiamTr - Diamint) / 2
        End Get
        Set(ByVal Value As Single)

        End Set
    End Property
    Public Overrides Property SpessBase() As Single
        Get
            SpessBase = Spessore
        End Get
        Set(ByVal Value As Single)

        End Set
    End Property
End Class