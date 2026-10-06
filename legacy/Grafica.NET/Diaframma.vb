Option Strict Off
Option Explicit On
Imports System.Math
<Serializable()> Public Class Diaframma
    Inherits Membratura
    Private prDiamExt As Single
    Private prSpessore As Single
    Public ClassTEMA As Short
    Public TipoDiafr As Short
    Private prSottoTipo As Short
    Public Passo As Single
    Public Passo1 As Single
    Public Diamfori As Single
    Public NumFori As Short
    Public NumForiA As Short
    Public NumForiB As Short
    Public NumTipoA As Short
    Public NumTipoB As Short
    Public NumDiafr As Short
    Public LunghFascio As Single
    Public Percento As Single
    Public DirezVert As Boolean
    Private nSTipi(6) As Short
    Private STipi(6, 3) As String
    Private iArea As Boolean
    Private DiamTubo As Single
    Private H1 As Short
    Private D1, H, D2 As Single
    'Public TipoMat As Short
    'Public Variato As Boolean
    Private RCB441(2, 5, 7) As Single
    Private RCB452(2, 10) As Single
    Private TipiDiaf(6) As String
    Private Fascio_Renamed As Fascio
    Private grezzo(3) As clsGrezzo1
    Private Polig As clsPolig
    Private Alfa As Single
    '----------------------
    'Public GenMem As clsGenMem
    'Public Function Convalida() As Short
    '    Convalida = True
    'End Function
    Public Overrides Property Diamext() As Single
        Get
            Return prDiamExt
        End Get
        Set(ByVal Value As Single)
            prDiamExt = Value
        End Set
    End Property
    Public Overrides Property Spessore() As Single
        Get
            Return prSpessore
        End Get
        Set(ByVal Value As Single)
            prSpessore = Value
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
    Public Overloads Sub leggi(ByVal DiscoR As String, ByVal Mode As Short)
        Select Case Mode
            Case 0
                If Not Variato Then Exit Sub
                Call Aggancio(DiscoR)
                If GenMem.Tipo < 0 And Not Fascio_Renamed Is Nothing Then Fascio_Renamed.CalcRCB43()
                Pesi()
                GenMem.Leggiprezzi((Spessore), 0, 0)
                StringMATE()
                Appendi()
                CalcGrezzi()
                Variato = False
                'Mode=0 ricalcolo,=1 editaggio
            Case 1
                Membro = Me
                FormDati.ShowDialog()
        End Select
    End Sub
    Public Overloads Sub CalcGrezzi()
        Dim grez As New clsGrezzo1
        Dim i As Short
        GenMem.ClearGrezzi()
        For i = 1 To 3
            If grezzo(i).NPezzi > 0 Then
                GenMem.IniziaGrezzo(grez)
                If grez Is Nothing Then Exit Sub
                grezzo(i).Copia(grez)
            End If
        Next
    End Sub
    Public Overloads Sub Pesi()
        Dim AT, peso, AF As Single
        Dim Pieno, PF As Single
        Dim Y, X, Z As Single
        Dim Al, Al1 As Single
        Dim PNETA, PNET, PNETB As Single
        Dim PLORA, PLOR, PLORB As Single
        Dim PC1 As Single
        Dim DIMR1 As String = ""
        Dim DIMR2 As String = ""
        Dim i, j As Short
        GenMem.LeggiMat(TipoMat)
        GenMem.PesiSp(TipoMat)
        On Error GoTo ErrP
        If Not Caricamento Then GenMem.ClearAppesi(True)
        grezzo(1).NPezzi = 0 : grezzo(2).NPezzi = 0 : grezzo(3).NPezzi = 0
        PercArea()
        AT = Diamext ^ 2 * PI / 4 'area totale diametro esterno diaframma
        AF = Diamfori ^ 2 * PI / 4 * NumFori 'area totale fori
        PF = AF * Spessore * GenMem.PesoSp1 * EXP9
        Pieno = (1 - (AF / AT)) * 100 'percentuale di pieno su totale area piena
        Select Case TipoDiafr
            Case 1, 2 'single/NTW
                NumDiafr = NumTipoA + NumTipoB
                NumTipoA = NumDiafr \ 2
                NumTipoB = NumDiafr - NumTipoA
                ' If iArea Then Record(jRec).Dati(7) = PerCento Else Record(jRec).Dati(7) = -PerCento
                If Not iArea Then
                    Z = Diamext / 2
221:                X = Z - (Diamext / 100 * Percento)
222:                Y = System.Math.Sqrt(Z * Z - X * X) : Alfa = 2 * System.Math.Atan(Y / X)
                Else
223:                Al1 = Percento / 100 * PI
                    ' IF al1 < 0 OR al1 > PI THEN PRINT "Errore in Diaframmi"; al1: u$ = INPUT$(1)
                    Do
                        Al = Al1
                        Al1 = -(Al / PI - 0.5 * System.Math.Sin(2 * Al) / 2 / PI - Percento / 100) + Al
                    Loop Until System.Math.Abs(Al1 - Al) < 0.0001
                    Alfa = Al1
225:                X = Diamext / 2 * System.Math.Cos(Alfa)
                End If
                PNET = (AT - (((AT / (PI * 2)) * Alfa) - (X * Y))) * Spessore * GenMem.PesoSp1 * EXP9
                NumForiA = (AT - (((AT / (PI * 2)) * Alfa) - (X * Y))) / AT * NumFori
                NumForiB = NumForiA
                grezzo(1).Dimens(1) = Diamext + GenMem.MargTag(Int(Spessore))
                grezzo(1).Dimens(2) = Diamext / 2 + X + GenMem.MargTag(Int(Spessore)) + Diamfori
                If grezzo(1).Dimens(2) > grezzo(1).Dimens(1) Then grezzo(1).Dimens(2) = grezzo(1).Dimens(1)
                PLOR = grezzo(1).Dimens(1) * grezzo(1).Dimens(2) * Spessore * GenMem.PesoSp1 * EXP9
                '     IF PerCento = 50 THEN PNET = INT((AT / 2) * Spessore * GenMem.PesoSp1 * EXP9): PLOR = ((DiamExt + 20) * ((DiamExt / 2) + 20) * Spessore * GenMem.PesoSp1 * EXP9)
                GenMem.Denom = "SET DIAFR.tipo SS"
                grezzo(1).NPezzi = NumDiafr
                grezzo(1).Vartxt(1) = "SS  "
                If TipoDiafr = 2 Then
                    GenMem.Denom = "SET DIAFR.tipo NTW"
                End If
                grezzo(1).Variab(1) = Spessore
                grezzo(2).Variab(1) = 0
                grezzo(3).Variab(1) = 0
                DIMR1 = "N°" & Str(NumDiafr) & " DIAFRAMMI D." & Mid(Str(Diamext), 2, Len(Str(Diamext)) - 1) & " sp." & Mid(Str(Spessore), 2, Len(Str(Spessore)) - 1)
                PC1 = Percento
                If iArea Then PC1 = Int((1 - (Diamext / 2 + X) / Diamext) * 1000) / 10
                DIMR2 = " Taglio " & Mid(Str(PC1), 2, Len(Str(PC1)) - 1) & "%"
                If Not Caricamento Then
                    For i = 1 To NumTipoA
                        j = 1 ': If SottoTipo = 1 Then j = -1
                        SetPolig(X, Y, i, j)
                    Next
                    For i = 1 To NumTipoB
                        j = -1 ': If SottoTipo = 1 Then j = 1
                        SetPolig(X, Y, i, j)
                    Next
                End If
            Case 3
                X = (H / 2) : Z = (Diamext / 2) : Y = System.Math.Sqrt(Z ^ 2 - X ^ 2)
                Alfa = 2 * System.Math.Atan(Y / X)
                PNETA = ((((AT / (PI * 2)) * Alfa) - (X * Y)) * Spessore * GenMem.PesoSp1 * EXP9) * 2
                NumForiA = (((AT / (PI * 2)) * Alfa) - (X * Y)) / AT * NumFori
                grezzo(1).Dimens(1) = (Diamext / 2) - X + GenMem.MargTag(Int(Spessore)) + Diamfori
                grezzo(1).Dimens(2) = (Y * 2) + GenMem.MargTag(Int(Spessore))
                PLORA = (grezzo(1).Dimens(1) * grezzo(1).Dimens(2) * Spessore * GenMem.PesoSp1 * EXP9) * 2
                X = (H1 / 2) : Z = (Diamext / 2) : Y = System.Math.Sqrt(Z ^ 2 - X ^ 2)
                Alfa = 2 * System.Math.Atan(Y / X)
                PNETB = (AT - 2 * ((((AT / (PI * 2)) * Alfa) - (X * Y)))) * Spessore * GenMem.PesoSp1 * EXP9
                NumForiB = (AT - 2 * ((((AT / (PI * 2)) * Alfa) - (X * Y)))) / AT * NumFori
                grezzo(2).Dimens(1) = Diamext + GenMem.MargTag(Int(Spessore))
                grezzo(2).Dimens(2) = H1 + GenMem.MargTag(Int(Spessore)) + Diamfori
                PLORB = grezzo(2).Dimens(1) * grezzo(2).Dimens(2) * Spessore * GenMem.PesoSp1 * EXP9
                GenMem.Denom = "SET DIAFR.tipo DS"
                grezzo(1).NPezzi = NumTipoA
                grezzo(2).NPezzi = NumTipoB
                grezzo(1).Vartxt(1) = "DSA "
                grezzo(2).Vartxt(1) = "DSB "
                grezzo(1).Variab(1) = Spessore
                grezzo(2).Variab(1) = Spessore
                grezzo(3).Variab(1) = 0
                DIMR1 = "N°" & Str(NumTipoA + NumTipoB) & " Doppio seg. D." & Mid(Str(Diamext), 2, Len(Str(Diamext)) - 1) & " sp." & Mid(Str(Spessore), 2, Len(Str(Spessore)) - 1)
                DIMR2 = " Taglio " & Mid(Str(H1), 2, Len(Str(H1)) - 1) & "/" & Mid(Str(H), 2, Len(Str(H)) - 1)
            Case 5
                PNETA = D2 ^ 2 * (PI / 4) * Spessore * GenMem.PesoSp1 * EXP9
                NumForiA = D2 ^ 2 * (PI / 4) / AT * NumFori
                grezzo(1).Dimens(1) = D2 + GenMem.MargTag(Int(Spessore))
                grezzo(1).Dimens(2) = D1 + GenMem.MargTag(Int(Spessore))
                PLORA = (D2 + 20) ^ 2 * Spessore * GenMem.PesoSp1 * EXP9
                PNETB = (Diamext ^ 2 - D1 ^ 2) * (PI / 4) * Spessore * GenMem.PesoSp1 * EXP9
                NumForiB = (Diamext ^ 2 - D1 ^ 2) * (PI / 4) / AT * NumFori
                grezzo(2).Dimens(1) = Diamext + 20
                grezzo(2).Dimens(2) = Diamext + 20
                PLORB = (Diamext + 20) ^ 2 * Spessore * GenMem.PesoSp1 * EXP9
                GenMem.Denom = "SET DIAFR.tipo An"
                grezzo(1).NPezzi = NumTipoA
                grezzo(2).NPezzi = NumTipoB
                grezzo(1).Variab(1) = Spessore
                grezzo(2).Variab(1) = Spessore
                grezzo(3).Variab(1) = 0
                grezzo(1).Vartxt(1) = "DI  "
                grezzo(2).Vartxt(1) = "AN  "
                DIMR1 = "N°" & Str(NumTipoA + NumTipoB) & " Disco-anello D " & Mid(Str(Diamext), 2, Len(Str(Diamext)) - 1) & " sp." & Mid(Str(Spessore), 2, Len(Str(Spessore)) - 1)
                DIMR2 = " Taglio D " & Mid(Str(D1), 2, Len(Str(D1)) - 1) & "/" & Mid(Str(D2), 2, Len(Str(D2)) - 1)
            Case 4
                MsgBox("da programmare in Diaframma.Pesi")
        End Select
        PNET = PNET * Pieno / 100
        PNETA = PNETA * Pieno / 100
        PNETB = PNETB * Pieno / 100
        Select Case TipoDiafr
            Case 1, 2
                GenMem.Pnet0 = PNET * NumDiafr
                GenMem.plor0 = PLOR * NumDiafr
            Case 3
                GenMem.Pnet0 = ((PNETA * NumTipoB) + (PNETB * NumTipoA))
                GenMem.plor0 = ((PLORA * NumTipoB) + (PLORB * NumTipoA))
            Case 5
                GenMem.Pnet0 = ((PNETA * NumTipoA) + (PNETB * NumTipoB))
                GenMem.plor0 = ((PLORA * NumTipoA) + (PLORB * NumTipoB))
        End Select
        GenMem.Psfri0 = GenMem.plor0 - GenMem.Pnet0
        ' GenMem.PNET0 = peso * EXP9
        ' GenMem.PLOR0 = GenMem.PNET0 * EXP9
        ' GenMem.Psfri0 = 0
        'GenMem.Converti
        GenMem.Dimensioni = DIMR1
        GenMem.Note = DIMR2
        GenMem.PNET = GenMem.Pnet0
        If Not Caricamento And Editing Then SuperAppendi(Me)
ExP:    Exit Sub
ErrP:   Resume ExP
    End Sub
    Private Sub SetPolig(ByVal X As Single, ByVal Y As Single, ByVal i As Short, ByVal j As Short)
        Polig = New clsPolig
        With Polig
            .Spessore = Spessore
            If Alfa = 0 Then
                .Npunti = 2
                .Vertici.Punti.Item(1).TextData.X = Y
                .Vertici.Punti.Item(1).TextData.y = j * X
                .Raggi(1).TextData = Diamext / 2
                .Vertici.Punti.Item(2).TextData.X = 0
                .Vertici.Punti.Item(2).TextData.y = j * (-Diamext / 2)
                .Raggi(2).TextData = Diamext / 2
            Else
                .Npunti = 3
                .Vertici.Punti.Item(1).TextData.X = Y
                .Vertici.Punti.Item(1).TextData.y = j * X
                .Raggi(1).TextData = Diamext / 2
                .Vertici.Punti.Item(2).TextData.X = 0
                .Vertici.Punti.Item(2).TextData.y = j * (-Diamext / 2)
                .Raggi(2).TextData = Diamext / 2
                .Vertici.Punti.Item(3).TextData.X = -Y
                .Vertici.Punti.Item(3).TextData.y = j * X
                .Raggi(3).TextData = 0
            End If
            Funzioni.InitPosSpaN(GenMem, .GenMem)
            .GenMem.posizione.DirDiritta = "=+"
            .GenMem.Tipo = -96
            If Not DirezVert Then
                If SottoTipo = 1 Then
                    .GenMem.posizione.DirTraversa = "Do"
                Else
                    .GenMem.posizione.DirTraversa = "Up"
                End If
            Else
                If SottoTipo = 1 Then
                    .GenMem.posizione.DirTraversa = "-N"
                Else
                    .GenMem.posizione.DirTraversa = "+N"
                End If
            End If
            .GenMem.posizione.Quota = Str((2 * (i - 1) + (j + 1) / 2) * Passo + Passo1)
            .GenMem.Denom = "Diaf" & Trim(Str(2 * (i - 1) + (j + 1) / 2))
            AggCoordN(.GenMem)
        End With
        GenMem.AppesiAddk(Polig)
    End Sub
    Public Overrides Sub StringMATE()
        Dim M0 As String = GenMem.MaterNome(1).Trim
        If M0 = "" Then M0 = GenMem.Materiale.Trim
        GenMem.Materiale = M0
    End Sub
    Private Sub Class_Initialize_Renamed()
        Dim i, ifl As Short
        Dim j, k As Short
        GenMem = New clsGenMem
        GenMem.Parent = Me
        Variato = True
        GenMem.LavorEst = True
        TipoMat = 1
        ifl = FreeFile()
        FileOpen(ifl, RTrim(Inizio.Archdir) & "\DIAF03.DAT", OpenMode.Input, , OpenShare.Shared)
        For i = 0 To 1 : For j = 0 To 9
                Input(ifl, RCB452(i, j))
                RCB452(i, j) = RCB452(i, j) * 25.4
            Next
        Next i
        For k = 0 To 1 : For i = 0 To 5 : For j = 0 To 6
                    Input(ifl, RCB441(k, i, j))
                    RCB441(k, i, j) = RCB441(k, i, j) * 25.4
                Next
            Next i
        Next k
        FileClose(ifl)
        FileOpen(ifl, RTrim(Inizio.Archdir) & "\DIAF01.DAT", OpenMode.Input, , OpenShare.Shared)
        For i = 1 To 6 : TipiDiaf(i) = LineInput(ifl) : Next
        FileClose(ifl)
        nSTipi(1) = 2 : nSTipi(2) = 2 : nSTipi(3) = 2 : nSTipi(4) = 2 : nSTipi(5) = 3 : nSTipi(6) = 1
        'single
        STipi(1, 1) = "Taglio verso il +"
        STipi(1, 2) = "Taglio verso il -"
        'NTW
        STipi(2, 1) = "Taglio verso il +"
        STipi(2, 2) = "Taglio verso il -"
        STipi(3, 1) = "Esterno"
        STipi(3, 2) = "Interno"
        STipi(4, 1) = "Esterno"
        STipi(4, 2) = "Interno"
        STipi(5, 1) = "Esterno"
        STipi(5, 2) = "Intermedio"
        STipi(5, 3) = "Interno"
        STipi(6, 1) = "?"
        GenMem.Lato = 1
    End Sub
    Public Sub New()
        MyBase.New()
        Dim i As Short
        Class_Initialize_Renamed()
        For i = 0 To 3
            grezzo(i) = New clsGrezzo1
        Next
    End Sub
    Protected Overrides Sub Finalize()
        GenMem = Nothing
        MyBase.Finalize()
    End Sub
    Public WriteOnly Property Base() As Fascio
        Set(ByVal Value As Fascio)
            Fascio_Renamed = Value
        End Set
    End Property
    Public Property TipiP(ByVal i As Short) As String
        Get
            TipiP = TipiDiaf(i)
        End Get
        Set(ByVal Value As String)

        End Set
    End Property
    Public Overrides Property Diametro() As Single
        Get
            Diametro = Diamext
        End Get
        Set(ByVal Value As Single)

        End Set
    End Property
    Public Sub ListTipi()
        Dim i As Short
        FormDati.cmbPara(3).Items.Clear()
        For i = 1 To nSTipi(TipoDiafr)
            FormDati.cmbPara(3).Items.Add(STipi(TipoDiafr, i))
        Next
    End Sub
    Public Sub Unsupported()
        Dim NonSupp As Single
        Dim j, i, k As Short
        Dim Text As String
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto GenMem.posizione.SuChi.GenMem. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
        If System.Math.Abs(GenMem.posizione.SuChi.GenMem.Tipo) = 8 Or System.Math.Abs(GenMem.posizione.SuChi.GenMem.Tipo) = 9 Then
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto GenMem.posizione.SuChi.DiamExt. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            DiamTubo = GenMem.posizione.SuChi.Diamext
        End If
        If DiamTubo < 1 Then
            MsgBox("Non è possibile calcolare lo spessore a norma TEMA dei diaframmi poiché non è noto il diametro dei tubi", MsgBoxStyle.Information + MsgBoxStyle.OKOnly)
            Exit Sub
        End If
        Select Case TipoDiafr
            Case 1, 2 : NonSupp = Passo
            Case 3, 5 : NonSupp = 2 * Passo
            Case 4 : NonSupp = 3 * Passo
        End Select
        For i = 0 To 9
            If RCB452(0, i) > Diamfori Then Exit For
        Next
        If NonSupp > RCB452(1, i) Then
            Text = "WARNING! " & vbCrLf
            Text = Text & " Lunghezza non supportata dei tubi: " & GlobalRoutines.myStr(NonSupp, 5, 1, False) & vbCrLf
            Text = Text & " maggiore dell'ammissibile. (" & GlobalRoutines.myStr(RCB452(1, i), 5, 1, False) & ")"
            MsgBox(Text, MsgBoxStyle.Critical)
            Exit Sub
        End If
        If ClassTEMA = 1 Then k = 0 Else k = 1
        For j = 1 To 6
            If NonSupp < RCB441(k, 0, j) Then Exit For
        Next
        For i = 1 To 5
            If Diamext < RCB441(k, i, 0) Then Exit For
        Next
        Spessore = CShort(RCB441(k, i, j))
    End Sub
    Public Sub NumDiaf()
        Dim dt26, dt41 As Single
        Dim o As Tubi
        Dim f As Membratura
        If Fascio_Renamed Is Nothing Then
            o = GenMem.posizione.SuChi
            If System.Math.Abs(o.GenMem.Tipo) = 8 Or System.Math.Abs(o.GenMem.Tipo) = 9 Then
                f = o.GenMem.posizione.SuChi
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto f.GenMem. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                If f.GenMem.Tipo = 26 Then
                    Fascio_Renamed = f
                End If
            End If
        End If
        If Fascio_Renamed Is Nothing Then Exit Sub
        dt26 = Fascio_Renamed.DaTosdt(26)
        dt41 = Fascio_Renamed.DaTosdt(41)
        If Passo > 0 Then
            If dt26 - Passo1 < Passo Then
                NumDiafr = 0
            Else
                If Int(dt41) < 2 Then 'DaTos(0).dt(41) NumDiafr. passi lato mantello
                    NumDiafr = 2 + Int((dt26 - 2 * Passo1) / Passo)
                Else 'tubi a u
                    NumDiafr = 1 + Int((dt26 - Passo1) / Passo)
                End If
            End If
        Else
            NumDiafr = 0
        End If
        NumTipoA = NumDiafr / 2 : NumTipoB = NumTipoA '???????????????
        '????????????????????????????????
        'NumTipoA = 5: NumTipoB = 5: NumDiafr = 10
        FormDati.txtPara(8).Text = Str(NumDiafr)
    End Sub
    Public Sub PercArea()
        Dim Risult(2) As String
        Dim i As Short
        Dim ifl As Short
        Dim Stringa1(6) As String
        Dim Stringa(2) As String
        Dim Archivio(2) As Short
        Dim dAiuto(2) As String
        ifl = FreeFile()
        FileOpen(ifl, RTrim(Inizio.Archdir) & "\DIAF02.DAT", OpenMode.Input, , OpenShare.Shared)
        For i = 1 To 6 : Stringa1(i) = LineInput(ifl) : Next
        FileClose(ifl)
        Select Case TipoDiafr
            Case 1, 2
                iArea = False
                If Percento < 0 Then
                    iArea = True
                End If
            Case 3
                '     Stringa1$(1) = "Larghezza diaframma centrale        = "
                '     Stringa1$(2) = "Larghezza finestra tra i segmenti   = "
                Stringa1(1) = Stringa1(2) : Stringa1(2) = Stringa1(3)
                Risult(1) = GlobalRoutines.myStr(CSng(H), 5, 1, False)
                Risult(2) = GlobalRoutines.myStr(CSng(H1), 5, 1, False)
                Archivio(1) = 0 : Archivio(2) = 0
                Motore.InputDati(2, "Diaframmi double segmented", Stringa1, Risult, "", Archivio, dAiuto)
                H = GlobalRoutines.ValVir(Risult(1))
                H1 = GlobalRoutines.ValVir(Risult(2))
            Case 5
                '     Stringa1$(1) = "Diametro disco centrale             = "
                '     Stringa1$(2) = "Diametro foro anello                = "
                Stringa1(1) = Stringa1(4) : Stringa1(2) = Stringa1(5)
                Risult(1) = GlobalRoutines.myStr(D1, 5, 1, False)
                Risult(2) = GlobalRoutines.myStr(D2, 5, 1, False)
                Archivio(1) = 0 : Archivio(2) = 0
                Motore.InputDati(2, "Diaframmi anulari", Stringa1, Risult, "", Archivio, dAiuto)
                D1 = GlobalRoutines.ValVir(Risult(1))
                D2 = GlobalRoutines.ValVir(Risult(2))
            Case 4 'triplo
                MsgBox("Lavori in corso in Diaframma PercArea")
        End Select
    End Sub
    Private Sub Appendi()
        Dim i As Short
        If GenMem.Appesi.Count() > 0 Then Exit Sub
        For i = 0 To Apparecchio.Elementi.Count() - 1
            If Apparecchio.Elementi(i).GenMem.Tipo = -96 Then
                If Apparecchio.Elementi(i).GenMem.posizione.SuChi Is Me Then
                    GenMem.AppesiAddk(Apparecchio.Elementi(i))
                End If
            End If
        Next
    End Sub
    Public Overloads Sub Copia(ByRef A As Diaframma)
        MsgBox("mi rifiuto di copiare un set di diaframmi")
    End Sub
End Class