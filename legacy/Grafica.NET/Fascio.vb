Option Strict Off
Option Explicit On
Imports System.Math
Imports RoutBase1
Imports System.IO 'Namespace for Filestreams
Imports System.Runtime.Serialization.Formatters.Binary 'Namespace for BinaryFormatter
<Serializable()> Public Class Fascio
    Inherits Membratura
    Public TipoFascio As Short '1 FIX 2 Float 3 U-tube, 4 fontana
    Public FileTrac As String
    Private prDiametro As Single
    Private prSpessore As Single
    Public NpassShell As Short
    Public LayOut As traccia.clsTracciatura
    Public Tubi_Renamed As Tubi
    Public Diaframmi As Diaframma
    Public Piatto As Striscia
    Public SealStrips As Raggrupp
    Public Tiranti As Raggrupp
    Public Rods As Raggrupp
    'Public TipoMat As Short
    <NonSerialized()> Private Mom As Single
    <NonSerialized()> Private Gialetto As Boolean
    '-----------------------
    'Public GenMem As clsGenMem
    'Public Variato As Boolean
    Public Overrides Property Spessore() As Single
        Get
            Return prSpessore
        End Get
        Set(ByVal Value As Single)
            prSpessore = Value
        End Set
    End Property
    Public Overrides Property Diametro() As Single
        Get
            Return prDiametro
        End Get
        Set(ByVal Value As Single)
            prDiametro = Value
        End Set
    End Property
    Public Overloads Sub leggi(ByVal DiscoR As String, ByVal Mode As Short)
        'Mode=0 ricalcolo,=1 editaggio
        Select Case Mode
            Case 0
                If Not Variato Then Exit Sub
                Call Aggancio(DiscoR)
                GenMem.LeggiMat(1) 'da prevedere in seguito tubi bimetallici(TipoMat)
                GenMem.PesiSp(1) '(TipoMat)
                Pesi()
                GenMem.Leggiprezzi(0, 0, 0)
                StringDIME()
                StringMATE()
                StringNOTE()
                CalcGrezzi()
                Appendi(Mode)
                Variato = False
            Case 1
                Membro = Me
                NonDisegnare = True
                FormDati.ShowDialog()
                If Funzioni.OKfrmDati Then
                    Appendi(Mode)
                End If
                NonDisegnare = False
        End Select
    End Sub
    Public Sub New()
        MyBase.New()
        GenMem = New clsGenMem
        GenMem.Parent = Me
        FileTrac = FunzLibgra.FileDes("INP")
        Variato = True
    End Sub
    Protected Overrides Sub Finalize()
        GenMem = Nothing
        MyBase.Finalize()
    End Sub
    Public Overloads Sub Pesi()
    End Sub
    Public Sub StringDIME()
        Dim Note As String = ""
        Dim Denom As String = ""
        '   Dim TOLE, Note, Denom As String
        '  Dim Den1, NOTE1, Note2, Den2 As String
        On Error GoTo ErrS
        'Select Case Tubi.Tolleranza
        '    Case 1: TOLE = " MW"
        '    Case 2: TOLE = " AW"
        'End Select
        'NOTE1 = "N°" + Str$(Tubi.NumeroTubi) + " Forcelle De." + LTrim$(Str$(Diametro)) + " sp." + Str$(Spessore) + TOLE
        'Den1 = "TUBI SCAMBIATORI"
        'Note2 = "N°" + Str$(Tubi.NumeroTubi) + " Tubi De." + LTrim$(Str$(Diametro)) + " sp." + Str$(Spessore) + TOLE
        'Den2 = "SERIE DI TUBI AD U"
        'Select Case GenMem.Tipo
        '    Case 8
        '       NOTE = NOTE1
        '       Denom = Den1
        '    Case 9
        '       NOTE = Note2
        '       Denom = Den2
        '    Case 26
        '       Select Case Tubi.TipoFascio
        '       Case 1, 2
        '          NOTE = NOTE1
        '          Denom = Den1
        '       Case 3, 4
        '          NOTE = Note2
        '         Denom = Den2
        '      End Select
        Denom = "FASCIO TUBIERO COMPLETO"
        'End Select
        GenMem.Dimensioni = Note
        If Len(RTrim(GenMem.Denom)) = 0 Then GenMem.Denom = Denom
ExS:    Exit Sub
ErrS:   Resume ExS
    End Sub
    Public Overrides Sub StringMATE()
        Dim M1, M0, Riga As String
        Dim i As Short
        M0 = GenMem.MaterNome(1).Trim
        If M0 = "" Then M0 = GenMem.Materiale.Trim
        If GenMem.Classe2 = 2 Then
            M1 = GenMem.MaterNome(2).Trim
            Riga = M0 & " + " & M1
        Else 'hh
            Riga = M0
        End If
        If Len(Riga) < 30 Then Riga = Chr(32) & Riga & New String(Chr(32), 30 - Len(Riga)) & Chr(32) Else Riga = Chr(32) & Mid(Riga, 1, 30) & Chr(32)
        GenMem.Materiale = Riga
    End Sub
    Private Sub StringNOTE()
        Dim Note As String = ""
        GenMem.Note = Note
    End Sub
    Public Overrides Sub CalcGrezzi()
    End Sub
    Public Sub LeggiDT(Optional ByRef Mode As Short = 0)
        If Mode = 1 Then Gialetto = False
        If Gialetto Then Exit Sub
        Gialetto = True
        If FileTrac.Length Then Exit Sub
        If Not IO.File.Exists(FileTrac) Then Exit Sub
        Dim fs As New FileStream(FileTrac, FileMode.Open)
        Dim bf As New BinaryFormatter
        Try
            Dim p As RoutBase1.clsProblem = CType(bf.Deserialize(fs), RoutBase1.clsProblem)
            DaTos = CType(bf.Deserialize(fs), traccia.clsTracciatura.typDaTos)
        Catch e As Runtime.Serialization.SerializationException
            MsgBox(e.Message)
            Exit Sub
        End Try
        fs.Close()
        If DaTos.dt(1) > 0 Then GenMem.Mater.Mat(1).Indmat = DaTos.dt(1)
        If DaTos.dtubo > 0 Then Tubi_Renamed.Diamext = DaTos.dtubo
        If DaTos.Tublu > 0 Then Tubi_Renamed.Lunghezza = DaTos.Tublu
        If DaTos.dt(24) > 0 Then Tubi_Renamed.Spessore = DaTos.dt(24)
        If DaTos.dt(27) > 0 Then
            Tubi_Renamed.Tolleranza = DaTos.dt(27) '1 MW 2 AW
            Tubi_Renamed.TipoMateriale = 3 - DaTos.matub '1 INOX 2 NO
            If Tubi_Renamed.TipoMateriale = 3 Then Tubi_Renamed.TipoMateriale = 2
        End If
        If DaTos.TipoFascio > 0 Then TipoFascio = DaTos.TipoFascio
        If DaTos.dt(12) > 0 Then Tubi_Renamed.TipoPasso = DaTos.dt(12)
        Tubi_Renamed.OTL = DaTos.OTL
        Tubi_Renamed.yUltimFila = System.Math.Abs(DaTos.y(1))
        Tubi_Renamed.yPrimaFila = System.Math.Abs(DaTos.y(DaTos.kymax))
        Tubi_Renamed.NumeroSettori = DaTos.NumeroSettori
        If DaTos.ktotal > 0 Then Tubi_Renamed.NumeroTubi = DaTos.ktotal
        If DaTos.TipoFascio > 2 Then Tubi_Renamed.NumeroTubi = Tubi_Renamed.NumeroTubi / 2
        If DaTos.Passo > 0 Then Tubi_Renamed.Passo = DaTos.Passo
        If DaTos.dt(41) > 0 Then DataSheet.DatiPrg.NPassMant = DaTos.dt(41)
        If DaTos.PassoFascio > 0 Then DataSheet.DatiPrg.NPassTubi = DaTos.PassoFascio
    End Sub
    Private Sub Appendi(ByRef Mode As Short)
        Dim i As Short
        Dim Ogg As Membratura
        Dim SS As Striscia
        Dim tt As Tondo
        Dim dirx, diry As Single
        '   jRec = 1
        If Not Editing Then GenMem.ClearAppesi(True)
        If Not Editing Then
            If Tubi_Renamed Is Nothing Then Tubi_Renamed = New Tubi
            SetTubi()
        Else
            If Tubi_Renamed Is Nothing Then
                Dim n As OggList.NodeP = GenMem.Appesi.nodeHead.Next
                While Not n Is Nothing
                    Ogg = n.TextData
                    If Ogg.GenMem.Tipo = -9 Or Ogg.GenMem.Tipo = -8 Then
                        Tubi_Renamed = Ogg
                        Exit While
                    End If
                    n = n.Next
                End While
            End If
            If Tubi_Renamed Is Nothing Then
                Tubi_Renamed = New Tubi
                SetTubi()
            Else
                LeggiDT()
            End If
        End If
        Tubi_Renamed.Leggi(Inizio.DiscoRam, Mode)
        If Mode = 1 And Not Funzioni.OKfrmDati Then Exit Sub
        If Not Editing Then
            If Diaframmi Is Nothing Then
                Diaframmi = New Diaframma
                SetDiaframmi()
            End If
        Else
            If Diaframmi Is Nothing Then
                Dim n As OggList.NodeP = GenMem.Appesi.nodeHead.Next
                While Not n Is Nothing
                    Ogg = n.textdata
                    If Ogg.GenMem.Tipo = -19 Then
                        Diaframmi = Ogg
                        Exit While
                    End If
                    n = n.Next
                End While
            End If
            If Diaframmi Is Nothing Then
                Diaframmi = New Diaframma
                SetDiaframmi()
            End If
        End If
        AggDiaframmi()
        Diaframmi.Leggi((Inizio.DiscoRam), Mode)
        If Mode = 1 And Not Funzioni.OKfrmDati Then Exit Sub
        If DaTos.URTY(2) * DaTos.URTY(3) * DaTos.URTY(4) > 0 Then
            If Not Editing Then
                If Piatto Is Nothing Then Piatto = New Striscia
                SetPiatto()
            Else
                If Piatto Is Nothing Then
                    Dim n As OggList.NodeP = GenMem.Appesi.nodeHead.Next
                    While Not n Is Nothing
                        Ogg = n.textdata
                        If Ogg.GenMem.Tipo = -15 Then
                            Piatto = Ogg
                            Exit While
                        End If
                        n = n.Next
                    End While
                End If
                If Piatto Is Nothing Then
                    Piatto = New Striscia
                    SetPiatto()
                End If
            End If
            Piatto.Leggi((Inizio.DiscoRam), Mode)
            If Mode = 1 And Not Funzioni.OKfrmDati Then Exit Sub
        End If
        If DaTos.ISEAL > 0 Then
            If Not Editing Then
                If SealStrips Is Nothing Then SealStrips = New Raggrupp
                SetSS()
            Else
                If SealStrips Is Nothing Then
                    Dim n As OggList.NodeP = GenMem.Appesi.nodeHead.Next
                    While Not n Is Nothing
                        Ogg = n.textdata
                        If Ogg.GenMem.Tipo = -31 Then
                            SealStrips = Ogg
                            Exit While
                        End If
                        n = n.Next
                    End While
                End If
                If SealStrips Is Nothing Then
                    SealStrips = New Raggrupp
                    SetSS()
                End If
            End If
            If SealStrips.Spessore = 0 Then SealStrips.Spessore = DaTos.seal(3, 1)
            If SealStrips.Lunghezza = 0 Then SealStrips.Lunghezza = DaTos.seal(6, 1)
            If SealStrips.Larghezza = 0 Then SealStrips.Larghezza = DaTos.seal(5, 1)
            SealStrips.Numero = DaTos.ISEAL
            'SealStrips.Tipo = -15
            If Not Caricamento Then
                SealStrips.GenMem.ClearAppesi(True)
                For i = 1 To SealStrips.Numero
                    SS = New Striscia
                    With SS
                        SealStrips.GenMem.Copia(.GenMem)
                        .GenMem.Parent = SS
                        .GenMem.Tipo = -15
                        .GenMem.Lato = 1
                        .GenMem.Denom = "SS" & Trim(Str(i))
                        .GenMem.PosDis = 0 ' SealStrips.GenMem.PosDis
                        .GenMem.posizione.SuChi = SealStrips 'RecordD(0).Ind
                        .GenMem.Qta = 1
                        .GenMem.posizione.DirDiritta = "=+"
                        .GenMem.posizione.Quota = "Ne"
                        .Spessore = DaTos.seal(3, i)
                        .Larghezza = DaTos.seal(5, i)
                        .Lunghezza = DaTos.seal(6, i)
                        .GenMem.posizione.Raggio = Str(System.Math.Sqrt(DaTos.seal(1, i) ^ 2 + DaTos.seal(2, i) ^ 2))
                        If CDbl(.GenMem.posizione.Raggio) > 0 Then
                            .GenMem.posizione.Anomal = Str(-180 / PI * GlobalRoutines.arco(DaTos.seal(1, i) / CDbl(.GenMem.posizione.Raggio), DaTos.seal(2, i) / CDbl(.GenMem.posizione.Raggio)))
                        Else
                            .GenMem.posizione.Anomal = "N.A."
                        End If
                        .GenMem.posizione.DirTraversa = Str(180 / PI * DaTos.seal(7, i))
                        SealStrips.GenMem.AppesiAdd(SS)
                        AggCoordN(.GenMem)
                    End With
                Next
            End If
            SealStrips.Leggi((Inizio.DiscoRam), Mode)
            If Mode = 1 And Not Funzioni.OKfrmDati Then Exit Sub
        End If
        If DaTos.ntira > 0 Then
            If Not Editing Then
                If Tiranti Is Nothing Then Tiranti = New Raggrupp
                SetTira()
            Else
                If Tiranti Is Nothing Then
                    Dim n As OggList.NodeP = GenMem.Appesi.nodeHead.Next
                    While Not n Is Nothing
                        Ogg = n.textdata
                        If Ogg.GenMem.Tipo = -32 Then
                            Tiranti = Ogg
                            Exit While
                        End If
                        n = n.Next
                    End While
                End If
                If Tiranti Is Nothing Then
                    Tiranti = New Raggrupp
                    SetTira()
                End If
            End If
            If Tiranti.Diametro = 0 Then Tiranti.Diametro = DaTos.td(3, 1)
            If Tiranti.Lunghezza = 0 Then Tiranti.Lunghezza = Tubi_Renamed.Lunghezza
            Tiranti.Numero = DaTos.ntira
            Tiranti.Tipo = -23
            If Not Caricamento Then
                Tiranti.GenMem.ClearAppesi(True)
                For i = 1 To Tiranti.Numero
                    tt = New Tondo
                    With tt
                        Tiranti.GenMem.Copia(.GenMem) 'non funziona ancora
                        .GenMem.Parent = tt
                        .GenMem.Tipo = -23
                        .GenMem.Lato = 1
                        .GenMem.Denom = "Tirante" & Trim(Str(i))
                        .GenMem.PosDis = 0 ' Tiranti.GenMem.PosDis
                        .GenMem.posizione.SuChi = Tiranti 'RecordD(0).Ind
                        .GenMem.Qta = 1
                        .GenMem.posizione.DirDiritta = "=+"
                        .GenMem.posizione.Quota = "Ne"
                        If Tiranti.Diametro > 0 Then
                            .Diametro = Tiranti.Diametro
                        Else
                            .Diametro = DaTos.td(3, i)
                        End If
                        If Tiranti.Lunghezza > 0 Then
                            .Lunghezza = Tiranti.Lunghezza
                        Else
                            .Lunghezza = Tubi_Renamed.Lunghezza
                        End If
                        .GenMem.posizione.Raggio = Str(System.Math.Sqrt(DaTos.td(1, i) ^ 2 + DaTos.td(2, i) ^ 2))
                        If GlobalRoutines.ValVir(.GenMem.posizione.Raggio) > 0 Then
                            dirx = DaTos.td(1, i) / GlobalRoutines.ValVir(.GenMem.posizione.Raggio)
                            diry = DaTos.td(2, i) / GlobalRoutines.ValVir(.GenMem.posizione.Raggio)
                            .GenMem.posizione.Anomal = Str(-180 / PI * GlobalRoutines.arco(dirx, diry))
                        Else
                            .GenMem.posizione.Anomal = "N.A."
                        End If
                        .GenMem.posizione.DirTraversa = "N.A."
                        Tiranti.GenMem.AppesiAdd(tt)
                        AggCoordN(.GenMem)
                    End With
                Next
            End If
            Tiranti.Leggi((Inizio.DiscoRam), Mode)
            If Mode = 1 And Not Funzioni.OKfrmDati Then Exit Sub
        End If
        If DaTos.Nrod > 0 Then
            If Not Editing Then
                If Rods Is Nothing Then Rods = New Raggrupp
                SetRods()
            Else
                If Rods Is Nothing Then
                    Dim n As OggList.NodeP = GenMem.Appesi.nodeHead.Next
                    While Not n Is Nothing
                        Ogg = n.textdata
                        If Ogg.GenMem.Tipo = -32 Then
                            Rods = Ogg
                            Exit While
                        End If
                        n = n.Next
                    End While
                End If
                If Rods Is Nothing Then
                    Rods = New Raggrupp
                    SetRods()
                End If
            End If
            If Rods.Diametro = 0 Then Rods.Diametro = DaTos.runn(3, 1)
            If Rods.Lunghezza = 0 Then Rods.Lunghezza = DaTos.runn(4, 1)
            Rods.Numero = DaTos.Nrod
            Rods.Tipo = -23
            If Not Caricamento Then
                Rods.GenMem.ClearAppesi(True)
                For i = 1 To Rods.Numero
                    tt = New Tondo
                    With tt
                        Rods.GenMem.Copia(.GenMem)
                        .GenMem.Parent = tt
                        .GenMem.Tipo = -23
                        .GenMem.Lato = 1
                        .GenMem.Denom = "Rod" & Trim(Str(i))
                        .GenMem.PosDis = 0 'Rods.GenMem.PosDis
                        .GenMem.posizione.SuChi = Rods 'RecordD(0).Ind
                        .GenMem.Qta = 1
                        .GenMem.posizione.DirDiritta = "=+"
                        .GenMem.posizione.Quota = "Ne"
                        .Diametro = DaTos.runn(3, i)
                        .Lunghezza = DaTos.runn(4, i)
                        .GenMem.posizione.Raggio = Str(System.Math.Sqrt(DaTos.runn(1, i) ^ 2 + DaTos.runn(2, i) ^ 2))
                        If GlobalRoutines.ValVir(.GenMem.posizione.Raggio) > 0 Then
                            dirx = DaTos.runn(1, i) / GlobalRoutines.ValVir(.GenMem.posizione.Raggio)
                            diry = DaTos.runn(2, i) / GlobalRoutines.ValVir(.GenMem.posizione.Raggio)
                            .GenMem.posizione.Anomal = Str(-180 / PI * GlobalRoutines.arco(dirx, diry))
                        Else
                            .GenMem.posizione.Anomal = "N.A."
                        End If
                        .GenMem.posizione.DirTraversa = "N.A."
                        Rods.GenMem.AppesiAdd(tt)
                        AggCoordN(.GenMem)
                    End With
                Next
            End If
            Rods.Leggi((Inizio.DiscoRam), Mode)
            If Mode = 1 And Not Funzioni.OKfrmDati Then Exit Sub
        End If
    End Sub
    Private Sub SetTubi()
        With Tubi_Renamed
            Select Case TipoFascio
                Case 1, 2 : .GenMem.Tipo = -8
                Case Else : .GenMem.Tipo = -9
            End Select
            GenMem.posizione.Copia((.GenMem.posizione))
            .GenMem.posizione.SuChi = Me 'RecordD(0).Ind
            .GenMem.posizione.DirDiritta = "=+"
            .GenMem.posizione.Anomal = ""
            .GenMem.posizione.Quota = "St"
            If .GenMem.PosDis <= 0 Then .GenMem.PosDis = Funzioni.SetPosizN(Me) ' RecordD(0).PosDis + jRec
            .GenMem.Qta = 1
            If Len(Trim(.GenMem.Denom)) = 0 Then .GenMem.Denom = "TUBI SCAMBIATORI"
            GenMem.AppesiAdd(Tubi_Renamed)
        End With
    End Sub
    Private Sub SetPiatto()
        With Piatto
            .GenMem.Tipo = -15
            GenMem.posizione.Copia((.GenMem.posizione))
            .GenMem.posizione.SuChi = Tubi_Renamed 'RecordD(0).Ind
            If .GenMem.PosDis <= 0 Then .GenMem.PosDis = Funzioni.SetPosizN(Me) ' RecordD(0).PosDis + jRec
            .GenMem.Ind = 0 ' jRec + RecordD(0).Ind
            .Larghezza = DaTos.URTY(2)
            .Spessore = DaTos.URTY(3)
            .Lunghezza = DaTos.URTY(4)
            .GenMem.Qta = 1
            .GenMem.Denom = "PIATTO D'URTO"
            .GenMem.posizione.Raggio = Str(DaTos.URTY(1))
            .GenMem.posizione.DirDiritta = "=+"
            .GenMem.posizione.Anomal = "+N"
            .GenMem.posizione.DirTraversa = "Up"
            GenMem.AppesiAdd(Piatto)
        End With
    End Sub
    Private Sub SetDiaframmi()
        With Diaframmi
            .Base = Me
            .GenMem.Tipo = -19
            GenMem.posizione.Copia((.GenMem.posizione))
            If .GenMem.PosDis <= 0 Then .GenMem.PosDis = Funzioni.SetPosizN(Me) ' RecordD(0).PosDis + 1
            .GenMem.posizione.SuChi = Tubi_Renamed 'RecordD(0).Ind
            .GenMem.Qta = 1
            .GenMem.posizione.DirDiritta = "=+"
            .GenMem.posizione.Quota = "Ne"
            If Len(Trim(.GenMem.Denom)) = 0 Then .GenMem.Denom = "DIAFRAMMI FASCIO"
            GenMem.AppesiAdd(Diaframmi)
        End With
    End Sub
    Private Sub AggDiaframmi()
        With Diaframmi
            .Diamfori = Tubi_Renamed.Diamext
            .NumFori = Tubi_Renamed.NumeroTubi
            If System.Math.Abs(Tubi_Renamed.GenMem.Tipo) = 9 Then .NumFori = .NumFori * 2
            .LunghFascio = Lunghezza
            .Percento = DaTos.dt(30)
        End With
    End Sub
    Private Sub SetSS()
        With SealStrips
            .Base = Me
            .Tipo = -15
            .GenMem.Tipo = -31
            GenMem.posizione.Copia((.GenMem.posizione))
            If .GenMem.PosDis <= 0 Then .GenMem.PosDis = Funzioni.SetPosizN(Me) ' RecordD(0).PosDis + 1
            .GenMem.posizione.SuChi = Tubi_Renamed 'RecordD(0).Ind
            .GenMem.Ind = 0 ' jRec + RecordD(0).Ind
            .GenMem.Denom = "SEALING STRIPS"
            .GenMem.Qta = 1
            .GenMem.posizione.DirDiritta = "=+"
            .GenMem.posizione.Quota = "Ne"
            GenMem.AppesiAdd(SealStrips)
        End With
    End Sub
    Private Sub SetTira()
        With Tiranti
            .Base = Me
            .Tipo = -23
            .GenMem.Tipo = -32
            GenMem.posizione.Copia((.GenMem.posizione))
            If .GenMem.PosDis <= 0 Then .GenMem.PosDis = Funzioni.SetPosizN(Me) ' RecordD(0).PosDis + 1
            .GenMem.posizione.SuChi = Tubi_Renamed 'RecordD(0).Ind
            .GenMem.Denom = "TIRANTI FASCIO"
            .GenMem.Qta = 1
            .GenMem.posizione.DirDiritta = "=+"
            .GenMem.posizione.Quota = "Ne"
            GenMem.AppesiAdd(Tiranti)
        End With
    End Sub
    Private Sub SetRods()
        With Rods
            .Base = Me
            .Tipo = -23
            .GenMem.Tipo = -33
            GenMem.posizione.Copia((.GenMem.posizione))
            If .GenMem.PosDis <= 0 Then .GenMem.PosDis = Funzioni.SetPosizN(Me) ' RecordD(0).PosDis + 1
            .GenMem.posizione.SuChi = Tubi_Renamed 'RecordD(0).Ind
            .GenMem.Denom = "TONDI SCORRIMENTO"
            .GenMem.Qta = 1
            .GenMem.posizione.DirDiritta = "=+"
            .GenMem.posizione.Quota = "Ne"
            GenMem.AppesiAdd(Rods)
        End With
    End Sub

    Public Sub CalcRCB43()
        Dim diinc As Short
        Dim clearan As Single
        'Calcolo diametro esterno secondo RCB-4.3
        If DaTos.di1 = 0 Then Exit Sub
        diinc = DaTos.di1 / 25.4
        Select Case diinc
            Case Is < 17 : clearan = 25.4 / 8
            Case Is < 39 : clearan = 25.4 * 3 / 16
            Case Is < 54 : clearan = 25.4 / 4
            Case Else : clearan = 25.4 * 5 / 16
        End Select
        Diaframmi.Diamext = Int(DaTos.di1 - clearan)
    End Sub
    Public Function DaTosdt(ByVal i As Integer) As Single
        Return DaTos.dt(i)
    End Function

    Public Sub Genera(ByRef File As String)
        Trasferisci()
        Dim fs As New FileStream(File, FileMode.OpenOrCreate)
        Dim bf As New BinaryFormatter
        Try
            bf.Serialize(fs, Monitor.Motore.Problem)
            bf.Serialize(fs, DaTos)
        Catch e As Runtime.Serialization.SerializationException
            MsgBox(e.Message + vbCrLf + e.StackTrace)
            Exit Sub
        End Try
        fs.Close()
    End Sub

    Private Sub Trasferisci()
        DaTos.dt(11) = Tubi_Renamed.NumeroTubi ' DaTos(0).ntubi
        DaTos.dt(12) = Tubi_Renamed.TipoPasso 'DaTos(0).TipoPasso
        DaTos.dt(13) = DataSheet.DatiPrg.NPassTubi ' DaTos(0).PassoFascio'Tipo tracciatura
        DaTos.dt(14) = TipoFascio ' DaTos(0).TipoFascio
        DaTos.dt(15) = Tubi_Renamed.Diamext ' DaTos(0).dtubo
        DaTos.dt(16) = Tubi_Renamed.Passo ' DaTos(0).Passo
        DaTos.dt(17) = Diaframmi.Passo 'DaTos(0).pdiaf
        DaTos.dt(18) = Diaframmi.Passo1 'DaTos(0).p1
        DaTos.dt(19) = 3 - Tubi_Renamed.TipoMateriale 'DaTos(0).matub
        DaTos.dt(24) = Tubi_Renamed.Spessore ' DaTos(0).Spmm
        DaTos.dt(26) = Tubi_Renamed.Lunghezza ' DaTos(0).Tublu
        DaTos.dt(27) = Tubi_Renamed.Tolleranza 'DaTos(0).TipoTolleranza
        DaTos.dt(2) = CSng(Int(Tubi_Renamed.OTL + LayOut.diadiffe + 0.51))
        DaTos.dt(41) = DataSheet.DatiPrg.NPassMant
    End Sub
    Public Overrides Property Lunghezza() As Single
        Get
            If Tubi_Renamed Is Nothing Then Exit Property
            Select Case System.Math.Abs(Tubi_Renamed.GenMem.Tipo)
                Case 8
                    Lunghezza = Tubi_Renamed.Lunghezza
                Case 9
                    Lunghezza = Tubi_Renamed.Lunghezza + Tubi_Renamed.OTL / 2
            End Select
        End Get
        Set(ByVal Value As Single)

        End Set
    End Property
    Public Overloads Sub Copia(ByRef A As Fascio)
        MsgBox("mi rifiuto di copiare un fascio")
    End Sub
    Public Function jt() As Short
        LeggiDT()
        jt = DaTos.PassoFascio
    End Function
    Public Overloads Sub RimuoviSpeciali(ByRef O As Membratura)
        If O Is Tubi_Renamed Then Tubi_Renamed = Nothing
        If O Is Diaframmi Then Diaframmi = Nothing
        If O Is Piatto Then Piatto = Nothing
        If O Is SealStrips Then SealStrips = Nothing
        If O Is Tiranti Then Tiranti = Nothing
        If O Is Rods Then Rods = Nothing
    End Sub
End Class