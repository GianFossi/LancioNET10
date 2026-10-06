Option Strict Off
Option Explicit On
Imports System.Math
Imports RoutBase1
<Serializable()> Public Class clsNonStd
    Inherits Membratura
    Public prStandard As Flangia
    Public Pipe As New LibMat.clsPipe
    Public Tirante As clsTirante
    Public Guarniz As clsGuarniz
    Public ControFlangia As clsBocch
    Public Pad As Anello
    'Public TipoMat As Short '1 senza rip. 2 con 3 fl.rip.
    Public SpessRive As Single
    Private prTipoF As Short '????
    '        1 con scarpa
    '        2 autorinforzato
    '        3 con pezza di rinforzo
    '        4 standard
    Public Accoppiata As Short
    Public Cieca As Boolean
    Private prDiamScarpa As Single
    Private prSpesScarpa As Single
    Private prDiamRinf As Single
    Public AltzRinf As Single
    Private prRanda As Single
    Private prSporgenza As Single
    Private prSpostLat As Single
    Private prDiamInt As Single
    '------------------------------
    Private prDiamFl As Single 'Adim
    Public SpessFl As Single 't
    Private prBoltCir As Single 'BC
    Public H1 As Single
    Private prDiamExt
    Public H, B1 As Single
    Private prLC, prB3
    Public B2 As Single
    Public SovraMet As Short
    '----------------------
    'Public GenMem As clsGenMem
    'Public Variato As Boolean
    '--------------------------
    Private PesiBl(9) As Single
    Private Ssb1, Ssy1, Ssk As Single
    Private Ssc1, Sso1, Ssx1 As Single
    Public Overrides Property TipoF() As Short
        Get
            Return prTipoF
        End Get
        Set(ByVal Value As Short)
            prTipoF = Value
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
    Public Overrides Property DiamInt() As Single
        Get
            Return prDiamInt
        End Get
        Set(ByVal Value As Single)
            prDiamInt = Value
        End Set
    End Property
    Public Overrides Property DiamFl() As Single
        Get
            Return prDiamFl
        End Get
        Set(ByVal Value As Single)
            prDiamFl = Value
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
    Public Overrides Property DiamExt() As Single
        Get
            Return prDiamExt
        End Get
        Set(ByVal Value As Single)
            prDiamExt = Value
        End Set
    End Property
    Public Overrides Property BoltCir() As Single
        Get
            Return prBoltCir
        End Get
        Set(ByVal Value As Single)
            prBoltCir = Value
        End Set
    End Property
    Public Sub New()
        MyBase.New()
        GenMem = New clsGenMem
        GenMem.Parent = Me
        TipoF = 1
        Variato = True
        'prStandard = New Flangia
    End Sub
    Public Overrides Property LC() As Single
        Get
            Return prLC
        End Get
        Set(ByVal Value As Single)
            prLC = Value
        End Set
    End Property
    Public Overrides Property B3() As Single
        Get
            Return prB3
        End Get
        Set(ByVal Value As Single)
            prB3 = Value
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
    Protected Overrides Sub Finalize()
        GenMem = Nothing
        Standard = Nothing
        Tirante = Nothing
        Pipe = Nothing
        Guarniz = Nothing
        ControFlangia = Nothing
        Pad = Nothing
        MyBase.Finalize()
    End Sub
    Public Overloads Sub leggi(ByVal DiscoR As String, ByVal Mode As Short)
        Select Case Mode
            Case 0
                If Not Variato Then Exit Sub
                Call Aggancio(DiscoR)
                GenMem.LeggiMat((TipoMat))
                GenMem.PesiSp((TipoMat))
                Pesi()
                GenMem.Leggiprezzi(Int(Int(GenMem.plor0)), 0, 0)
                StringDIME()
                StringMATE()
                CalcGrezzi()
                Variato = False
            Case 1
                'Set Membro = Me
                'jRec = 1
                'Set Aux = New clsAuxNonStd
                'Set Aux.Base = Me
                'If Editing Then
                '   Aux.Converti jRec
                'Else
                '   Aux.GenMem.Tipo = -99
                'End If
                'Aux.GenMem.posizione.SuChi = RecordD(0).Ind
                'Aux.GenMem.PosDis = RecordD(0).PosDis
                'Aux.GenMem.Ind = jRec + RecordD(0).Ind
                'Aux.leggi Inizio.DiscoRam, 1
                'Convers.sConverti Aux
                'jRec = 0
                'frmDati.Show vbModal
                'Appendi Mode
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
    Public Sub StringDIME()
        Dim Note(4) As String
        Note(0) = Standard.strTipo & " " & Standard.strDiam & Chr(34) & " ASA" & Standard.strRati & "# DI." & Str(Diamint) '             flangia WN. SO. LJ.
        Note(1) = Note(0) & "h." & "Str$(a!(5, 4))" '                                              flangia LWN.
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
        grezzo.Vartxt(1) = "NSTD"
    End Sub
    Public Overloads Sub Pesi()
        Dim i As Short
        For i = 0 To 8 : PesiBl(i) = 0 : Next i
        GenMem.Pnet1 = 0
        If DiamFl > 0 Then
            PesiBl(1) = (DiamFl ^ 2 - Diamext ^ 2) * PI / 4 * SpessFl * GenMem.PesoSp1
            PesiBl(8) = B3 ^ 2 * PI / 4 * SpessFl * LC * GenMem.PesoSp1
        End If
1970:   PesiBl(2) = (Diamext ^ 2 - Diamint ^ 2) * (PI / 4) * Sporgenza * GenMem.PesoSp1
1980:   If DiamRinf > 0 Then
            PesiBl(3) = ((H ^ 2) / 2) * PI * (Diamext + (H / 1.5)) * GenMem.PesoSp1
            PesiBl(4) = (DiamRinf ^ 2 - Diamext ^ 2) * (PI / 4) * AltzRinf * GenMem.PesoSp1
        End If
2010:   If B2 > 0 Then
            PesiBl(5) = ((((B2 - Diamint) / 2) * H1) / 2) * PI * (Diamint + (((B2 - Diamint) / 2) / 1.5)) * GenMem.PesoSp1
            PesiBl(6) = (B2 ^ 2 - Diamint ^ 2) * (PI / 4) * B1 * GenMem.PesoSp1
        End If
2040:   If TipoF = 1 Then
2050:       If DiamRinf > 0 Then
2060:           PesiBl(7) = (DiamScarpa ^ 2 - DiamRinf ^ 2) * (PI / 4) * SpesScarpa * GenMem.PesoSp1
2070:       Else
2080:           PesiBl(7) = (DiamScarpa ^ 2 - Diamext ^ 2) * (PI / 4) * SpesScarpa * GenMem.PesoSp1
            End If
        End If
2090:   'Peso netto
        GenMem.Pnet0 = ((PesiBl(1) + PesiBl(2) + PesiBl(3) + PesiBl(4) + PesiBl(7)) - (PesiBl(5) + PesiBl(6) + PesiBl(8)))
        If TipoMat = 2 Then '    W.O.
            If B2 > 0 Then
                GenMem.Pnet1 = ((((B2 * PI * B1) + (Diamint * PI * (Sporgenza - B1))) * SpessRive * GenMem.PesoSp2))
            Else
                GenMem.Pnet1 = (Diamint * PI * Sporgenza * SpessRive * GenMem.PesoSp2)
            End If
            GenMem.Plor1 = GenMem.Pnet1
        ElseIf TipoMat = 3 Then  ' lining
            GenMem.Pnet1 = (Diamint * PI * Sporgenza * SpessRive * GenMem.PesoSp2)
            GenMem.Plor1 = 1.05 * GenMem.Pnet1
        End If
        'Peso lordo
        'misure grezze
        Ssy1 = Sporgenza : Ssb1 = Diamint : Ssk = 0
        If DiamFl > Diamext Then Ssk = DiamFl Else Ssk = Diamext
        If Ssk > DiamRinf Then Ssk = Ssk Else Ssk = DiamRinf
        If Ssk > DiamScarpa Then Ssk = Ssk Else Ssk = DiamScarpa
        Sso1 = Ssk : Ssk = 0
        If Sso1 = DiamFl Then Ssc1 = SpessFl
        If Sso1 = DiamRinf Then Ssc1 = AltzRinf + H
        If Sso1 = DiamScarpa Then Ssc1 = SpesScarpa
        If Sso1 = Diamext Then Ssc1 = 0
        If Sso1 = DiamFl Then
            Ssk = 0
            If Diamext > DiamRinf Then Ssk = Diamext Else Ssk = DiamRinf
            If Ssk > DiamScarpa Then Ssk = Ssk Else Ssk = DiamScarpa
            Ssx1 = Ssk
        ElseIf Sso1 = DiamScarpa Then
            Ssk = 0
            If Diamext > DiamRinf Then Ssk = Diamext Else Ssk = DiamRinf
            If Ssk > DiamFl Then Ssk = Ssk Else Ssk = DiamFl
            Ssx1 = Ssk
        ElseIf Sso1 = DiamRinf Then
            Ssk = 0
            If Diamext > DiamScarpa Then Ssk = Diamext Else Ssk = DiamScarpa
            If Ssk > DiamFl Then Ssk = Ssk Else Ssk = DiamFl
            Ssx1 = Ssk
        Else
            If Sso1 = Diamext Then Ssx1 = Diamext
            SovraMet = True 'SOVRA=TRUE:sovrametalli ridotti
        End If
2420:   If SovraMet Then
            Ssy1 = Ssy1 + 6 : Ssb1 = Ssb1 - 6
            Sso1 = Sso1 + 6 : Ssx1 = Ssx1 + 6
            Ssc1 = Ssc1 + 6
        Else
            Sub4220() 'sovrametalli
        End If
2440:   GenMem.plor0 = ((((Sso1 ^ 2 - Ssx1 ^ 2) * (PI / 4) * Ssc1) + ((Ssx1 ^ 2 - Ssb1 ^ 2) * (PI / 4) * Ssy1)) * GenMem.PesoSp1)
        GenMem.Plor1 = GenMem.plor0
        'peso pad
        'If Classedim(6) > 0 Then
        '   GenMem.Pnetdim(6) = (D5 ^ 2 - DiamRinf ^ 2) * (PI / 4) * T5 * Matdim(6).PSP * EXP9
        '   GenMem.PLORdim(6) = (D5 ^ 2 * T5 * Matdim(6).PSP * EXP9)
        'End If
        'peso tiranti
        'If Classedim(7) = 0 Then
        '       PTIR = LC * (B3 - 4) ^ 2 * PI / 4 * 4 * SpessFl * Matdim(7).PSP * EXP9
4130:   '       GenMem.Pnetdim(7) = PTIR: GenMem.PLORdim(7) = PTIR
        'End If

        GenMem.PNET = GenMem.Pnet0 + GenMem.Pnet1
    End Sub
    Private Sub Sub4220() 'sovrametalli bocchello
4230:   If Sso1 <= 300 Then Sso1 = Sso1 + 15 : Ssx1 = Ssx1 + 15 : Ssb1 = 0 : Ssc1 = Ssc1 + 20 : Ssy1 = Ssy1 + 20 : GoTo 4310
4240:   If Sso1 <= 500 Then Sso1 = Sso1 + 20 : Ssx1 = Ssx1 + 20 : Ssb1 = Ssb1 - 25 : Ssc1 = Ssc1 + 25 : Ssy1 = Ssy1 + 25 : GoTo 4310
4250:   If Sso1 <= 700 Then Sso1 = Sso1 + 25 : Ssx1 = Ssx1 + 25 : Ssb1 = Ssb1 - 30 : Ssc1 = Ssc1 + 30 : Ssy1 = Ssy1 + 30 : GoTo 4310
4260:   If Sso1 <= 900 Then Sso1 = Sso1 + 30 : Ssx1 = Ssx1 + 30 : Ssb1 = Ssb1 - 35 : Ssc1 = Ssc1 + 35 : Ssy1 = Ssy1 + 35 : GoTo 4310
4270:   If Sso1 <= 1100 Then Sso1 = Sso1 + 35 : Ssx1 = Ssx1 + 35 : Ssb1 = Ssb1 - 40 : Ssc1 = Ssc1 + 40 : Ssy1 = Ssy1 + 40 : GoTo 4310
4280:   If Sso1 <= 1300 Then Sso1 = Sso1 + 40 : Ssx1 = Ssx1 + 40 : Ssb1 = Ssb1 - 45 : Ssc1 = Ssc1 + 45 : Ssy1 = Ssy1 + 45 : GoTo 4310
4290:   If Sso1 <= 1500 Then Sso1 = Sso1 + 45 : Ssx1 = Ssx1 + 45 : Ssb1 = Ssb1 - 50 : Ssc1 = Ssc1 + 50 : Ssy1 = Ssy1 + 50 : GoTo 4310
4300:   If Sso1 > 1500 Then Sso1 = Sso1 + 45 : Ssx1 = Ssx1 + 45 : Ssb1 = Ssb1 - 50 : Ssc1 = Ssc1 + 50 : Ssy1 = Ssy1 + 50 : GoTo 4310
4310:   If (Sso1 - Ssx1) < 80 Then Ssx1 = Sso1
    End Sub
    Private Sub Leggi01()
        Dim ifl, i As Short
        Dim Riga As String
        ifl = FreeFile()
        FileOpen(ifl, RTrim(Inizio.Archdir) & "\FLAN09.DAT", OpenMode.Input, , OpenShare.Shared)
        For i = 1 To 24
            Riga = LineInput(ifl)
            FormDati.lblPara(i).Text = Riga
        Next
        FileClose(ifl)
    End Sub
    Private Sub MettiMeno()
        Dim i As Short
        With FormDati
            .lblPara(23).Text = Chr(45) 'Denom
            .lblPara(24).Text = Chr(45) 'Quantità
            If TipoMat = 0 Then TipoMat = 1
            Select Case TipoMat
                Case 1 'mono
                    .lblPara(18).Text = Chr(45)
                    .lblPara(19).Text = Chr(45)
                    .lblPara(20).Text = Chr(45)
                Case 2 'WO
                    .lblPara(19).Text = Chr(45)
                Case 3 'lining
                    .lblPara(18).Text = Chr(45)
                Case 4 'pl.?
            End Select
            If Not TipoF = 1 Then 'non c'è scarpa
                .lblPara(16).Text = Chr(45)
                .lblPara(17).Text = Chr(45) 'denominazione
            End If
            If Not TipoF = 2 Then 'non c'è autorinforzo
                For i = 5 To 10
                    .lblPara(i).Text = Chr(45)
                Next
            End If
            If Not TipoF = 3 Then 'non c'è pad
                .lblPara(21).Text = Chr(45)
                .lblPara(22).Text = Chr(45) 'denominazione
            End If
            If Not TipoF = 4 Then 'non c'‚ flangia integrale DA CAMBIARE
                For i = 11 To 15 : .lblPara(i).Text = Chr(45) : Next
            End If
            If Not Accoppiata Then .lblPara(20).Text = Chr(45)
        End With
    End Sub
    Private Sub PreparaR()
        With FormDati
            .txtPara(1).Text = LTrim(GlobalRoutines.myStr(Sporgenza, 8, 2, False)) ' da eliminare Stringa(SottoTipo))
            .txtPara(2).Text = LTrim(GlobalRoutines.myStr(Randa, 8, 2, False)) '? myStr(DiamInt, 8, 2, False)
            .txtPara(3).Text = LTrim(GlobalRoutines.myStr(Diamint, 8, 2, False))
            .txtPara(4).Text = LTrim(GlobalRoutines.myStr(Diamext, 8, 2, False))
            .txtPara(5).Text = LTrim(GlobalRoutines.myStr(DiamRinf, 8, 2, False))
            .txtPara(6).Text = LTrim(GlobalRoutines.myStr(AltzRinf, 8, 2, False))
            .txtPara(7).Text = LTrim(GlobalRoutines.myStr(H, 8, 2, False)) 'cono esterno
            .txtPara(8).Text = LTrim(GlobalRoutines.myStr(B2, 8, 2, False)) 'd.int allarg
            .txtPara(9).Text = LTrim(GlobalRoutines.myStr(B1, 8, 2, False)) 'alt.int allarg
            .txtPara(10).Text = LTrim(GlobalRoutines.myStr(H1, 8, 2, False)) 'cono int.
            .txtPara(11).Text = LTrim(GlobalRoutines.myStr(SpessFl, 8, 2, False))
            .txtPara(12).Text = LTrim(GlobalRoutines.myStr(DiamFl, 8, 2, False))
            .txtPara(13).Text = LTrim(GlobalRoutines.myStr(B3, 8, 2, False)) 'diametro fori
            .txtPara(14).Text = LTrim(GlobalRoutines.myStr(BoltCir, 8, 2, False))
            .txtPara(15).Text = LTrim(GlobalRoutines.myStr(LC, 8, 0, False)) 'numero bulloni
            .txtPara(16).Text = LTrim(GlobalRoutines.myStr(DiamScarpa, 8, 2, True))
            .txtPara(17).Text = LTrim(GlobalRoutines.myStr(SpesScarpa, 8, 2, True))
            .txtPara(18).Text = LTrim(GlobalRoutines.myStr(SpessRive, 8, 2, True))
            .txtPara(19).Text = LTrim(GlobalRoutines.myStr(SpessRive, 8, 2, True))
            '  If Accoppiata Then frmDati.txtPara(20).Text = myStr(ControFlangia.SpessRive, 8, 2, True)
            If Not Pad Is Nothing Then
                .txtPara(21).Text = LTrim(GlobalRoutines.myStr((Pad.Diamext), 8, 2, True)) 'diametro rinforzomyStr(D5, 8, 2, True)
                .txtPara(22).Text = LTrim(GlobalRoutines.myStr((Pad.Spess), 8, 2, True)) 'spessore rinf. myStr(T5, 8, 2, True)
            End If
        End With
    End Sub
    Public Sub PrSeFinDil(ByRef Nfield As Short)
        Dim i, j As Short
100:    Call Leggi01()
120:    Call PreparaR()
        Nfield = 24
130:    Call MettiMeno()
        With FormDati
            j = 0
            For i = 1 To Nfield
                If .lblPara(i).Text = Chr(45) Then
                    .lblPara(i).Tag = "0" 'Compr(i) = 0
                Else
                    j = j + 1
                    .lblPara(i).Tag = Str(j) 'Compr(i) = j
                    .txtPara(j).Tag = Str(i) 'Esp(j) = i
                End If 'e
            Next i '1
140:        Nfield = j
            For i = 1 To Nfield
                .lblPara(i).Text = .lblPara(Val(.txtPara(i).Tag)).Text
                .txtPara(i).Text = .txtPara(Val(.txtPara(i).Tag)).Text
            Next i
        End With
    End Sub

    Public Sub Registra(ByRef Index As Short)
        With FormDati
            Dim Valore As Single = GlobalRoutines.ValVir(.txtPara(Index).Text)
            Select Case Val(.txtPara(Index).Tag)
                Case 1 : Sporgenza = Valore
                Case 2 : Randa = Valore
                Case 3 : Diamint = Int(Valore)
                Case 4 : Diamext = Int(Valore)
                Case 5 : DiamRinf = Int(Valore)
                Case 6 : AltzRinf = Int(Valore)
                Case 7 : H = Valore
                Case 8 : B2 = Valore
                Case 9 : B1 = Valore
                Case 10 : H1 = Valore
                Case 11 : SpessFl = Valore
                Case 12 : DiamFl = Valore
                Case 13 : B3 = Valore
                Case 14 : BoltCir = Valore
                Case 15 : LC = Valore
                Case 16 : DiamScarpa = Valore
                Case 17 : SpesScarpa = Valore
                Case 18 : SpessRive = Valore
                Case 19 : SpessRive = Valore
                Case 20 : If Accoppiata Then ControFlangia.SpessRive = Valore
                Case 21 : Pad.Diamext = Valore
                Case 22 : Pad.Spess = Valore
            End Select
        End With
    End Sub
    Public Sub Appendi(ByRef Mode As Short)
        Dim Ogg As Membratura = Nothing
        Dim i As Short
        If Not Editing Then GenMem.ClearAppesi(True)
        If TipoF = 3 Then
            If Not Editing Then
                If Pad Is Nothing Then Pad = New Anello
                SetPad()
            Else
                If Pad Is Nothing Then
                    Dim n As OggList.NodeP = GenMem.Appesi.nodeHead.Next
                    While Not n Is Nothing
                        If Ogg.GenMem.Tipo = -17 Then
                            Pad = Ogg
                            Exit While
                        End If
                        n = n.Next
                    End While
                End If
                If Pad Is Nothing Then
                    Pad = New Anello
                    SetPad()
                End If
            End If
            Pad.Leggi((Inizio.DiscoRam), Mode)
            If IUNL = 5 And Pad.Dmant > 0 Then GenMem.posizione.DirTraversa = "Pe"
            'Funzioni.InitposSpaN GenMem, Pad.GenMem
        Else
            Pad = Nothing
            i = 1
            Do While i < GenMem.Appesi.Count()
                Select Case GenMem.Appesi(i).GenMem.Tipo
                    Case -17 : GenMem.AppesiRemove(i, True)
                        'i = i - 1
                End Select
                i = i + 1
            Loop
        End If
        Exit Sub
    End Sub

    Public Sub Converti(ByRef jRec As Short)
        ' Dim Look As New clsGenLook
        ' GenMem.ConvertiPos(jRec)
        ' Look.LookTipoNStd(RecordD(jRec).Dati, RecordD(jRec + 1).Dati)
        ' GenMem.LavorEst = Look.Lavorato
        ' If Look.TipoV > 0 Then TipoF = Look.TipoV
        ' DiamInt = Look.b
        ' DiamRinf = Look.DRINF
        ' AltzRinf = Look.HRINF
        ' Sporgenza = Look.ALTBOC
        ' DiamScarpa = Look.DSCAR
        ' Accoppiata = (Look.junk2 = 2)
        ' Randa = Look.RANZA
        ' SpesScarpa = Look.TSCAR
        ' SpostLat = Look.SpostLat
        ' DiamFl = Look.Adim
        ' SpessFl = Look.t
        ' BoltCir = Look.BC
        ' DiamExt = Look.d
        ' H = Look.H
        ' H1 = Look.H1
        ' B1 = Look.B1
        ' B3 = Look.B3
        ' LC = Look.BC
        ' B2 = Look.B2
        ' Converti2(jRec)
    End Sub

    Public Sub SetPad()
        Dim Ogg As Membratura
        With Pad
            .GenMem.Tipo = -17
            .Diamint = Diamext 'Standard.DiamTr
            .GenMem.Denom = "RINFORZO BOCCHELLO"
            .GenMem.Qta = 1
            GenMem.AppesiAdd(Pad)
            GenMem.posizione.Copia((.GenMem.posizione))
            Ogg = GenMem.posizione.SuChi
            'Set .GenMem.posizione.SuChi = Ogg ' Me ' RecordD(0).Ind
            .GenMem.posizione.Raggio = "Re"
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Ogg.GenMem. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            Select Case Ogg.GenMem.Tipo 'Dmant
                Case 1, 34 'bocchello con pad su cilindro
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Ogg.Spessore. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Ogg.Diametro. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                    .Dmant = Ogg.Diametro + 2 * (Ogg.Spessore) 'Diam=D+2(T1+T2)
                Case 3, 4, 5
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Ogg.Spessore. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Ogg.Diametro. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                    .Dmant = 2 * Ogg.Diametro + 2 * Ogg.Spessore 'Diam=2*D+2(T1+T2)
                Case Else
                    .Dmant = 0
            End Select
            If .GenMem.PosDis <= 0 Then .GenMem.PosDis = Funzioni.SetPosizN(Me) ' RecordD(0).PosDis + jRec
            .GenMem.Ind = 0 ' jRec + RecordD(0).Ind
            If .Diamext = 0 Then .Diamext = Int(2 * Standard.DiamTr)
            If .Spess = 0 Then .Spess = Int(Standard.SpessTr)
            .TipoS = 5
            AggCoordN(.GenMem)
            '              .GenMem.posizione.DirDiritta = "=-"
            '              If Not Tronchetto Is Nothing Then
            '                 .GenMem.posizione.Quota = Str(-Tronchetto.Lunghezza + 2 * .Spess)
            '              Else
            '                 .GenMem.posizione.Quota = Str(2 * .Spess)
            '              End If
        End With
    End Sub
    Public Overloads Sub Copia(ByRef A As clsNonStd)
        If A Is Nothing Then A = New clsNonStd
        If Not Standard Is Nothing Then Standard.Copia((A.Standard))
        If Not Tirante Is Nothing Then Tirante.Copia(A.Tirante)
        If Not Guarniz Is Nothing Then Guarniz.Copia(A.Guarniz)
        If Not ControFlangia Is Nothing Then ControFlangia.Copia((A.ControFlangia))
        If Not Pad Is Nothing Then Pad.Copia((A.Pad))
        A.TipoMat = TipoMat
        A.SpessRive = SpessRive
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
        A.DiamFl = DiamFl
        A.SpessFl = SpessFl
        A.BoltCir = BoltCir
        A.Diamext = Diamext
        A.H = H
        A.H1 = H1
        A.B1 = B1
        A.B3 = B3
        A.LC = LC
        A.B2 = B2
        A.SovraMet = SovraMet
        '----------------------
        GenMem.Copia(A.GenMem)
        A.GenMem.Parent = A
        Funzioni.AggiornaApparecchio(Me)
    End Sub
    Public Overloads Sub RimuoviSpeciali(ByRef O As Membratura)
        If O Is Tirante Then Tirante = Nothing
        If O Is Guarniz Then Guarniz = Nothing
        If O Is ControFlangia Then ControFlangia = Nothing
        If O Is Pad Then Pad = Nothing
    End Sub
End Class