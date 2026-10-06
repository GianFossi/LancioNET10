Option Strict Off
Option Explicit On
Imports System.Math
Imports RoutBase1
<Serializable()> Public Class Dilat
    Inherits Membratura
    Public Norma As Short
    Public Collare As Cilindro
    Public DIMAX As Single
    Public DIMIN As Single
    Public Raggio As Single
    Private prSpess As Single
    Private prLunghezza As Single
    Public Colletto As Single
    Public nPli As Short
    Public LungCol As Single
    Public SpesCol As Single
    Public SezRinf As Single
    Public SezTira As Single
    Public LunTira As Single
    Public nOnde As Short
    'Public TipoMat As Short '1,2,3,4
    Private prSottoTipo As Short
    Public MatColl As LibMat.MaterialeNew1
    Public MatAnel As LibMat.MaterialeNew1
    Public MatBull As LibMat.MaterialeNew1
    'Public Variato As Boolean
    Private de, di As Single
    '----------------------
    'Public GenMem As clsGenMem
    Private Mode As Short
    Public Overrides Property Spess() As Single
        Get
            Return prSpess
        End Get
        Set(ByVal Value As Single)
            prSpess = Value
        End Set
    End Property
    Public Overrides Property SottoTipo() As Short
        Get
            Return prSottoTipo
        End Get
        Set(ByVal Value As Short)
            prSottoTipo = Value
        End Set
    End Property
    Public Overrides Property Lunghezza() As Single
        Get
            Return prLunghezza
        End Get
        Set(ByVal Value As Single)
            prLunghezza = Value
        End Set
    End Property
    Public Overrides Sub StringMATE()
        Dim M0 As String
        M0 = GenMem.MaterNome(1).Trim
        If M0 = "" Then M0 = GenMem.Materiale.Trim
        GenMem.Materiale = M0
    End Sub
    Public Sub StringDIME()
        Dim Note4, Note5 As String
        Note4 = "N°" & Str(nOnde) & " nOnde De" & Str(DIMAX + 2 * Spess) & " Di" & Str(DIMIN) & " Raggio." & Str(Raggio) & " Colletto." & Str(Colletto)
        Note5 = " sp." & Str(Spess)
        GenMem.Dimensioni = Note4 & Note5
    End Sub

    Public Sub StringNOTE()
        GenMem.Note = "N°" & Str(nOnde * 2) & " Lamiere " & Str(Int(de + 20)) & "x" & Str(Int(de + 20)) & "x" & Str(Spess)
    End Sub
    Private Sub Leggi01()
        Dim ifl, i As Short
        Dim Riga As String
        ifl = FreeFile()
        FileOpen(ifl, RTrim(Inizio.Archdir) & "\CALA01.DAT", OpenMode.Input, , OpenShare.Shared)
        For i = 0 To 21
            Riga = LineInput(ifl)
            FormDati.lblPara(i).Text = Riga
        Next
        FileClose(ifl)
    End Sub
    Private Sub MettiMeno()
        Dim ifl, i As Short
        Dim Strin(6) As String
        ifl = FreeFile()
        FileOpen(ifl, RTrim(Inizio.Archdir) & "\CALA16.DAT", OpenMode.Input, , OpenShare.Shared)
        For i = 1 To 6 : Strin(i) = LineInput(ifl) : Next
        FileClose(ifl)
        With FormDati
            .lblPara(0).Text = Chr(45)
            .lblPara(16).Text = Chr(45) 'denominazione
            .lblPara(17).Text = Chr(45) 'materiale dilatatore
            Select Case SottoTipo
                Case 1 'Monostrato raccordato           .
                    .lblPara(4).Text = Chr(45)
                    .lblPara(5).Text = Strin(1) ' "Raggio int. superiore"
                    .lblPara(6).Text = Strin(2) '"Raggio int. inferiore"
                    .txtPara(5).Text = LTrim(GlobalRoutines.myStr(SezRinf, 8, 2, False))
                    For i = 8 To 12 : .lblPara(i).Text = Chr(45) : Next
                    For i = 18 To 20 : .lblPara(i).Text = Chr(45) : Next
                Case 2 'Monostrato flangiato            .
                    .lblPara(4).Text = Chr(45)
                    .lblPara(5).Text = Chr(45)
                    .lblPara(6).Text = Chr(45)
                    For i = 8 To 12 : .lblPara(i).Text = Chr(45) : Next
                    For i = 18 To 20 : .lblPara(i).Text = Chr(45) : Next
                Case 3 'Multistrato senza anelli        .
                    .lblPara(3).Text = Chr(45)
                    For i = 10 To 14 : .lblPara(i).Text = Chr(45) : Next
                    For i = 19 To 21 : .lblPara(i).Text = Chr(45) : Next
                Case 4 'Multistrato con anelli integrali.
                    .lblPara(3).Text = Chr(45)
                    For i = 11 To 14 : .lblPara(i).Text = Chr(45) : Next
                    For i = 20 To 21 : .lblPara(i).Text = Chr(45) : Next
                Case 5 'Multistrato con anelli bullonati.
                    .lblPara(3).Text = Chr(45)
                    For i = 13 To 14 : .lblPara(i).Text = Chr(45) : Next
                    .lblPara(21).Text = Chr(45)
                Case 6 'Monostrato a spessori diversi
                    .lblPara(3).Text = Strin(3) ' "Spessore ginocchi"
                    .lblPara(4).Text = Strin(4) '"Spessore mantello       "
                    .lblPara(5).Text = Chr(45) 'Strin(5) ' "Spessore cilindro maggiore"
                    .txtPara(4).Text = LTrim(GlobalRoutines.myStr(SpesCol, 8, 2, False))
                    'frmDati.txtPara(5).Text = LTrim$(myStr(SezRinf, 8, 2, False))
                    .lblPara(7).Text = "Colletto             "
                    .lblPara(8).Text = "Semilungh.cil. minori" 'Strin(6) ' "Semilungh.cil. maggiori"
                    '          frmDati.txtPara(9) = MyStr(CSNG(AlungC), 8, 0, FALSE)
                    For i = 9 To 14 : .lblPara(i).Text = Chr(45) : Next
                    For i = 18 To 21 : .lblPara(i).Text = Chr(45) : Next
                    .lblPara(10).Text = Strin(5) ' "Spessore cilindro maggiore"
                    .lblPara(11).Text = "Semilungh.cil. maggiori"
                Case 7 ' dati per PTff con inserimento manuale di Sj
                    For i = 2 To 21 : .lblPara(i).Text = Chr(45) : Next
            End Select
            If IUNL = 5 Or IUNL = 6 Then
                If IUNL = 5 Then
                    .lblPara(14).Text = Chr(45)
                    .lblPara(13).Text = Chr(45)
                End If
                '         frmDati.lblPara(15).Caption = Chr$(45)
                '          frmDati.lblPara(18).Caption = Chr$(45)
                '          frmDati.lblPara(17).Caption = Chr$(45)
                .lblPara(21).Text = Chr(45)
            End If
            If IUNL = 6 Then
                .cmbTipo.Enabled = False
                .txtDen.Enabled = False
            End If
        End With
    End Sub
    Private Sub PreparaR()
        Dim i As Short
        If SottoTipo = 0 Then SottoTipo = 1
        With FormDati
            .txtPara(0).Text = "" ' da eliminare Stringa(SottoTipo)
            .txtPara(1).Text = LTrim(GlobalRoutines.myStr(DIMAX, 8, 2, False))
            .txtPara(2).Text = LTrim(GlobalRoutines.myStr(DIMIN, 8, 2, False))
            .txtPara(3).Text = LTrim(GlobalRoutines.myStr(Spess, 8, 0, False))
            .txtPara(4).Text = LTrim(GlobalRoutines.myStr(Spess, 8, 0, False))
            .txtPara(5).Text = LTrim(Str(nPli))
            If SottoTipo = 1 Then .txtPara(5).Text = LTrim(GlobalRoutines.myStr(SezRinf, 8, 0, False))
            .txtPara(6).Text = LTrim(GlobalRoutines.myStr(Raggio, 8, 2, False))
            .txtPara(7).Text = LTrim(GlobalRoutines.myStr(Colletto, 8, 2, False))
            .txtPara(8).Text = LTrim(GlobalRoutines.myStr(LungCol, 8, 2, False))
            .txtPara(9).Text = LTrim(GlobalRoutines.myStr(SpesCol, 8, 2, False))
            .txtPara(10).Text = LTrim(GlobalRoutines.myStr(SezRinf, 8, 2, False))
            .txtPara(11).Text = LTrim(GlobalRoutines.myStr(SezTira, 8, 2, False))
            .txtPara(12).Text = LTrim(GlobalRoutines.myStr(LunTira, 8, 2, False))
            .txtPara(13).Text = LTrim(GlobalRoutines.myStr(SpesCol, 8, 2, False))
            .txtPara(14).Text = LTrim(GlobalRoutines.myStr(LungCol, 8, 2, False))
            .txtPara(15).Text = LTrim(GlobalRoutines.myStr(CSng(nOnde), 8, 0, True))
            For i = 0 To 4
                'k = i: If i = 4 Then k = 2
                Select Case i
                    Case 1
                        If MatColl Is Nothing Then MatColl = New LibMat.MaterialeNew1
                        .txtPara(17 + i).Text = MatColl.MatStr
                    Case 2, 4
                        If MatAnel Is Nothing Then MatAnel = New LibMat.MaterialeNew1
                        .txtPara(17 + i).Text = MatAnel.MatStr
                    Case 3
                        If MatBull Is Nothing Then MatBull = New LibMat.MaterialeNew1
                        .txtPara(17 + i).Text = MatBull.MatStr
                End Select
            Next
            .txtPara(16).Text = Membro.GenMem.Denom
        End With
    End Sub
    Public Sub PrSeFinDil(ByRef Nfield As Short)
        Dim i, j As Short
100:    Call Leggi01()
120:    Call PreparaR()
        Nfield = 21
130:    Call MettiMeno()
        With FormDati
            j = -1
            For i = 0 To Nfield
                If .lblPara(i).Text = Chr(45) Then
                    .lblPara(i).Tag = "0" 'Compr(i) = 0
                Else
                    j = j + 1
                    .lblPara(i).Tag = Str(j) 'Compr(i) = j
                    .txtPara(j).Tag = Str(i) 'Esp(j) = i
                End If 'e
            Next i '1
140:        Nfield = j
            For i = 0 To Nfield
                .lblPara(i).Text = .lblPara(Val(.txtPara(i).Tag)).Text
                .txtPara(i).Text = .txtPara(Val(.txtPara(i).Tag)).Text
            Next i ' a
            For i = Nfield + 1 To 21
                .lblPara(i).Visible = False
                .txtPara(i).Visible = False
            Next
        End With
    End Sub
    Public Overloads Sub leggi(ByVal DiscoR As String, ByVal Mode As Short)
        Select Case Mode
            Case 0
                If Not Variato Then Exit Sub
                Call Aggancio(DiscoR)
                GenMem.LeggiMat((TipoMat))
                GenMem.PesiSp((TipoMat))
                ' SovraMet
                GenMem.TAGLIO = GenMem.MargTag(Spess)
                ' Calcoli
                Pesi()
                GenMem.Leggiprezzi(Int(Spess), 0, 0)
                StringDIME()
                StringMATE()
                StringNOTE()
                If IUNL < 5 Then CalcGrezzi()
                Variato = False
                'Mode=0 ricalcolo,=1 editaggio
            Case 1
                Membro = Me
                FormDati.ShowDialog()
        End Select
        Appendi(Mode)
        SalvaLav()
    End Sub


    Public Overloads Sub Pesi()
        Dim DMMAX, XLung, DMMIN As Single
        Dim PNET, SV, PLOR As Single
        XLung = Colletto : If SottoTipo = 6 Then XLung = 0
        If SottoTipo <> 2 Then
            DMMAX = DIMAX - (2 * Raggio) : DMMIN = DIMIN + 2 * (Spess + Raggio)
            SV = (Raggio + Spess / 2) * PI / 2 + XLung
            de = DMMAX + 2 * SV
            di = DIMIN - 2 * SV
        End If
        If SottoTipo = 6 Then
            Lunghezza = (2 * (Raggio + Colletto) + 2 * (Raggio + LungCol) + 2 * Spess) * nOnde
        ElseIf SottoTipo < 3 Then
            Lunghezza = (4 * (Raggio + Colletto) + 2 * Spess) * nOnde
        Else
            Lunghezza = (4 * Raggio + 2 * Spess * nPli) * nOnde + 2 * Colletto
        End If
        If SottoTipo = 1 Or SottoTipo = 6 Then
            PNET = (de ^ 2 - di ^ 2) * PI / 4 * Spess * GenMem.PesoSp1
            If TipoMat = 1 Then
                PLOR = (de + 20) ^ 2 * Spess * GenMem.PesoSp1
            Else
                PLOR = (((de + 20) ^ 2) - ((di - 20) ^ 2 * PI / 4)) * Spess * GenMem.PesoSp1
            End If
            GenMem.Pnet0 = PNET * 2 * nOnde * EXP9
            GenMem.plor0 = PLOR * 2 * nOnde * EXP9
            GenMem.Psfri0 = GenMem.plor0 - GenMem.Pnet0
            GenMem.PNET = GenMem.Pnet0
        End If
    End Sub

    Public Overloads Sub CalcGrezzi()
        Dim grezzo As New clsGrezzo1
        GenMem.ClearGrezzi()
        GenMem.IniziaGrezzo(grezzo)
        If grezzo Is Nothing Then Exit Sub
        grezzo.Variab(1) = Spess
        grezzo.Vartxt(1) = "AN  "
        grezzo.Dimens(1) = de + GenMem.MargTag(Spess)
        grezzo.Dimens(2) = di
        grezzo.NPezzi = nOnde
    End Sub

    Public Sub Registra(ByRef Index As Short)
        With FormDati
            Dim Valore As Single = GlobalRoutines.ValVir(.txtPara(Index).Text)
            Select Case Val(.txtPara(Index).Tag)
                Case 1 : DIMAX = Valore
                Case 2 : DIMIN = Valore
                Case 3 : Spess = Int(Valore)
                Case 4
                    If SottoTipo = 1 Then
                        Spess = Int(Valore)
                    Else
                        SpesCol = Valore
                    End If
                Case 5 : nPli = Int(Valore)
                    If SottoTipo = 1 Then 'Or SottoTipo = 6 Then
                        SezRinf = Int(Valore)
                        nPli = 1
                    End If
                Case 6 : Raggio = Int(Valore)
                Case 7 : Colletto = Valore
                Case 8 : LungCol = Valore
                Case 9 : SpesCol = Valore
                Case 10 : SezRinf = Valore
                Case 11 : SezTira = Valore
                Case 12 : LunTira = Valore
                Case 13 : SpesCol = Valore
                Case 14 : LungCol = Valore
                Case 15 : nOnde = Valore
            End Select
        End With
    End Sub
    Public Sub New()
        MyBase.New()
        GenMem = New clsGenMem
        GenMem.Parent = Me
        SottoTipo = 1
        Variato = True
    End Sub
    Protected Overrides Sub Finalize()
        GenMem = Nothing
        MyBase.Finalize()
    End Sub
    Public Overrides Function Convalida() As Boolean
        Dim Errore As Short = 0
        Convalida = True
        If (SottoTipo = 1) And DIMAX < DIMIN + 4 * Raggio Then
            Errore = 1
        End If
        If di <= 0 And SottoTipo <> 2 Then
            Errore = 2
        End If
        If Errore > 0 Then
            MsgBox("Costruzione dilatatore impossibile." & Chr(13) & "Rivedere i dati geometrici", MsgBoxStyle.Exclamation)
            Convalida = False
        End If
    End Function
    Public Sub Appendi(ByRef lMode As Short)
        Dim Ogg As Membratura
        Dim i As Short
        Mode = lMode
        If Not Editing Then GenMem.ClearAppesi(True)
        If LungCol * SpesCol > 0 And SottoTipo < 6 And SottoTipo > 2 Then
            If Not Editing Then
                If Collare Is Nothing Then Collare = New Cilindro
                SetCollare()
            Else
                If Collare Is Nothing Then
                    Dim n As OggList.NodeP = GenMem.Appesi.nodeHead.Next
                    While Not n Is Nothing
                        Ogg = n.TextData
                        If Ogg.GenMem.Tipo = -1 Then
                            Collare = Ogg
                            Exit While
                        End If
                        n = n.Next
                    End While
                End If
                If Collare Is Nothing Then
                    Collare = New Cilindro
                    SetCollare()
                End If
            End If
        Else
            Collare = Nothing
            i = 0
            If Not Apparecchio Is Nothing Then
                Do While i < GenMem.Appesi.Count
                    Select Case GenMem.Appesi(i).GenMem.Tipo
                        Case -1 : GenMem.AppesiRemove(i, True)
                            'i = i - 1
                    End Select
                    i = i + 1
                Loop
            End If
        End If
        If SottoTipo = 6 Then
            If Not Editing Then
                If Collare Is Nothing Then Collare = New Cilindro
                SetCollare1()
            Else
                If Collare Is Nothing Then
                    Dim n As OggList.NodeP = GenMem.Appesi.nodeHead.Next
                    While Not n Is Nothing
                        Ogg = n.textdata
                        If Ogg.GenMem.Tipo = -1 Then
                            Collare = Ogg
                            Exit While
                        End If
                        n = n.Next
                    End While
                End If
                If Collare Is Nothing Then
                    Collare = New Cilindro
                    SetCollare1()
                End If
            End If
        Else
            Collare = Nothing
            i = 1
            If IUNL < 5 Then
                Do While i <= GenMem.Appesi.Count()
                    Select Case GenMem.Appesi(i).GenMem.Tipo
                        Case -1 : GenMem.AppesiRemove(i, True)
                            'i = i - 1
                    End Select
                    i = i + 1
                Loop
            End If
        End If
    End Sub
    Private Sub SetCollare()
        With Collare
            .GenMem.Tipo = -1
            .Lunghezza = LungCol
            .SpessBase = SpesCol
            .Diametro = DIMIN + 2 * nPli * Spess
            .GenMem.Denom = "COLLARE DI RINFORZO"
            .GenMem.Qta = 1
            GenMem.AppesiAdd(Collare)
            .GenMem.posizione.SuChi = Me
            If IUNL < 5 Then
                If .GenMem.PosDis <= 0 Then .GenMem.PosDis = Funzioni.SetPosizN(Me) ' RecordD(0).PosDis + jRec
                .GenMem.Ind = 0 'jRec + RecordD(0).Ind
                Funzioni.InitPosSpaN(GenMem, .GenMem)
                .GenMem.posizione.DirDiritta = "=-"
                .GenMem.posizione.Quota = "Ne"
                .Leggi((Inizio.DiscoRam), Mode)
                .GenMem.posizione.DirDiritta = "=+"
                .GenMem.posizione.Quota = "Fa"
                AggCoordN(.GenMem)
            End If
        End With
    End Sub
    Private Sub SetCollare1()
        With Collare
            .GenMem.Tipo = -1
            .GenMem.Denom = "Collare per dil."
            .Lunghezza = 2 * LungCol
            .SpessBase = SezRinf
            .Diametro = DIMAX
            'If .GenMem.posizione Is Nothing Then Return
            .GenMem.posizione.SuChi = Me ' RecordD(0).Ind
            If .GenMem.PosDis <= 0 Then .GenMem.PosDis = Funzioni.SetPosizN(Me) 'RecordD(0).PosDis + jRec
            .GenMem.Ind = 0 ' jRec + RecordD(0).Ind
            Funzioni.InitPosSpaN(GenMem, .GenMem)
            GenMem.AppesiAdd(Collare)
            .Leggi((Inizio.DiscoRam), Mode)
        End With
    End Sub
    Public Sub Dati()
        IUNL = 6
        Membro = Me
        If FormDati Is Nothing Then FormDati = New frmDati
        FormDati.ShowDialog()
        Membro = Nothing
    End Sub
    Public Overrides Property Diametro() As Single
        Get
            Diametro = DIMIN
        End Get
        Set(ByVal Value As Single)

        End Set
    End Property
    Public Overloads Sub Copia(ByRef A As Dilat)
        If A Is Nothing Then A = New Dilat
        A.Norma = Norma
        If Not Collare Is Nothing Then Collare.Copia((A.Collare))
        A.DIMAX = DIMAX
        A.DIMIN = DIMIN
        A.Raggio = Raggio
        A.Spess = Spess
        A.Lunghezza = Lunghezza
        A.Colletto = Colletto
        A.nPli = nPli
        A.LungCol = LungCol
        A.SpesCol = SpesCol
        A.SezRinf = SezRinf
        A.SezTira = SezTira
        A.LunTira = LunTira
        A.nOnde = nOnde
        A.TipoMat = TipoMat
        A.SottoTipo = SottoTipo
        'A.MatColl    As LibMat.Materiale
        'A.MatAnel    As LibMat.Materiale
        'A.MatBull    As LibMat.Materiale
        '----------------------
        GenMem.Copia(A.GenMem)
        A.GenMem.Parent = A
    End Sub
End Class