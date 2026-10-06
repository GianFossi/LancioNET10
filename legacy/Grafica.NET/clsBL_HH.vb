Option Strict On
Option Explicit On
Imports System.Math
Imports RoutBase1
Imports System.IO 'Namespace for Filestreams
Imports System.Runtime.Serialization.Formatters.Binary 'Namespace for BinaryFormatter
<Serializable()> Public Class clsBL_HH
    Inherits Membratura
    Public Integrale As Boolean
    Public objBre As BreLock.clsBreLoc
    '-------------------------------------------
    Public Transition As Flangione
    Public Cassa As Cilindro
    Public LockRing As Flangione
    Public Coperchio As Piastrone
    Public PiastraTubiera As Piastrone
    ' Public GuarnizionePT As clsGuarniz
    Public GuarnizioneLR As clsGuarniz
    Public CassonettoCil As Cilindro
    Public CassonettoCon As Cono
    Public FlangiaCassonCon As Anello
    Public FlangiaCassonCil As Flangione
    Public AnelloInterno As Flangione
    Public SplitRing As Flangione
    Public AnelloSpinta As Cilindro
    Public DiaframmaElastico As CalDisc
    Public AnelloSupInt As Flangione
    Public AnelloSupExt As Flangione
    Public VitiInterne As clsTirante
    Public VitiSupInt As clsTirante
    Public VitiSupExt As clsTirante
    '------------------------------------------------
    Public Overrides Sub Pesi()

    End Sub
    Public ReadOnly Property LunghezzaRidotta() As Single
        Get
            Return objBre.ImpilaggioFinale - Transition.H2 - Cassa.Lunghezza
        End Get
    End Property
    Public Overrides Property Diamext() As Single
        Get
            Return objBre.IDChan + 2 * objBre.ThkAdpCh
        End Get
        Set(ByVal value As Single)

        End Set
    End Property
    Public Overrides Property Diamint() As Single
        Get
            Return objBre.IDChan
        End Get
        Set(ByVal value As Single)

        End Set
    End Property
    Public Overloads Overrides Sub leggi(ByVal DiscoR As String, ByVal Mode As Short)
        'Mode=0 ricalcolo,=1 editaggio
        Select Case Mode
            Case 0
                If Not Variato Then Exit Sub
                Call Aggancio(DiscoR)
                Pesi()
                StringDIME()
                StringMATE()
                StringNOTE()
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
        Variato = True
    End Sub
    Protected Overrides Sub Finalize()
        GenMem = Nothing
        MyBase.Finalize()
    End Sub
    Private Sub StringDIME()
        GenMem.Dimensioni = "(da scrivere)"
    End Sub
    Private Sub StringNOTE()
        Dim Note As String = "Posizione di raggruppamento"
        GenMem.Note = Note
    End Sub
    Public Overrides Sub StringMATE()
        Dim M1, M0, Riga As String
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
    Private Sub Appendi(ByRef Mode As Short)
        Dim i As Short
        Dim Ogg As Membratura
        If Not Editing Then GenMem.ClearAppesi(True)
        '----membrature presenti prima di BL_HH
        If Not SetTransition() Then Exit Sub
        If Not SetCassa() Then Exit Sub
        If Not SetPT Then Exit Sub
        '-----------------------------------------
        If Integrale Then
            If Editing Then
                If LockRing Is Nothing Then
                    For i = 0 To CShort(GenMem.Appesi.Count - 1)
                        Ogg = GenMem.Appesi(i)
                        If Ogg.GenMem.Tipo = TipoMembratura.Flangione_n Then
                            If CType(Ogg, Flangione).SottoTipo = SottoTipoFlangione.LockRing Then
                                LockRing = CType(Ogg, Flangione)
                                Exit For
                            End If
                        End If
                    Next
                End If
            End If
            SetLockRing()
            LockRing.leggi(Inizio.DiscoRam, Mode)
            If Editing Then
                If SplitRing Is Nothing Then
                    For i = 0 To CShort(GenMem.Appesi.Count - 1)
                        Ogg = GenMem.Appesi(i)
                        If Ogg.GenMem.Tipo = TipoMembratura.Flangione_n Then
                            If CType(Ogg, Flangione).SottoTipo = SottoTipoFlangione.AnelloSemplice Then
                                SplitRing = CType(Ogg, Flangione)
                                Exit For
                            End If
                        End If
                    Next
                End If
            End If
            SetSplitRing()
            SplitRing.leggi(Inizio.DiscoRam, Mode)
            If Editing Then
                If AnelloSupInt Is Nothing Then
                    For i = 0 To CShort(GenMem.Appesi.Count - 1)
                        Ogg = GenMem.Appesi(i)
                        If Ogg.GenMem.Tipo = TipoMembratura.Flangione_n Then
                            If CType(Ogg, Flangione).SottoTipo = SottoTipoFlangione.AnelloSemplice Then
                                AnelloSupInt = CType(Ogg, Flangione)
                                Exit For
                            End If
                        End If
                    Next
                End If
            End If
            SetAnelloSupInt()
            AnelloSupInt.leggi(Inizio.DiscoRam, Mode)
            If Editing Then
                If AnelloSupExt Is Nothing Then
                    For i = 0 To CShort(GenMem.Appesi.Count - 1)
                        Ogg = GenMem.Appesi(i)
                        If Ogg.GenMem.Tipo = TipoMembratura.Flangione_n Then
                            If CType(Ogg, Flangione).SottoTipo = SottoTipoFlangione.AnelloSemplice Then
                                AnelloSupExt = CType(Ogg, Flangione)
                                Exit For
                            End If
                        End If
                    Next
                End If
            End If
            SetAnelloSupExt()
            AnelloSupExt.leggi(Inizio.DiscoRam, Mode)
            If Editing Then
                If DiaframmaElastico Is Nothing Then
                    For i = 0 To CShort(GenMem.Appesi.Count - 1)
                        Ogg = GenMem.Appesi(i)
                        If Ogg.GenMem.Tipo = TipoMembratura.DiscCalFondiPiani_n Then
                            If CType(Ogg, CalDisc).SottoTipo = SottoTipoCalDisc.DiaframmaElastico Then
                                DiaframmaElastico = CType(Ogg, CalDisc)
                                Exit For
                            End If
                        End If
                    Next
                End If
            End If
            SetDiaframmaElastico()
            DiaframmaElastico.leggi(Inizio.DiscoRam, Mode)
            If Editing Then
                If Me.GuarnizioneLR Is Nothing Then
                    For i = 0 To CShort(GenMem.Appesi.Count - 1)
                        Ogg = GenMem.Appesi(i)
                        If Ogg.GenMem.Tipo = TipoMembratura.Guarnizione_n Then
                            GuarnizioneLR = CType(Ogg, clsGuarniz)
                            Exit For
                        End If
                    Next
                End If
            End If
            SetGuarnizioneLR()
            GuarnizioneLR.leggi(Inizio.DiscoRam, Mode)
            If Editing Then
                If AnelloInterno Is Nothing Then
                    For i = 0 To CShort(GenMem.Appesi.Count - 1)
                        Ogg = GenMem.Appesi(i)
                        If Ogg.GenMem.Tipo = TipoMembratura.Flangione_n Then
                            If CType(Ogg, Flangione).SottoTipo = SottoTipoFlangione.GradinoFemmina Then
                                AnelloInterno = CType(Ogg, Flangione)
                                Exit For
                            End If
                        End If
                    Next
                End If
            End If
            SetAnelloInterno()
            AnelloInterno.leggi(Inizio.DiscoRam, Mode)
            If Editing Then
                If VitiInterne Is Nothing Then
                    For i = 0 To CShort(GenMem.Appesi.Count - 1)
                        Ogg = GenMem.Appesi(i)
                        If Ogg.GenMem.Tipo = TipoMembratura.Tiranti_n Then
                            If CType(Ogg, clsTirante).SottoTipo = SottoTipoTirante.ViteSpingitriceNasello Then
                                VitiInterne = CType(Ogg, clsTirante)
                                Exit For
                            End If
                        End If
                    Next
                End If
            End If
            SetVitiInterne()
            VitiInterne.leggi(Inizio.DiscoRam, Mode)
            If Editing Then
                If AnelloSpinta Is Nothing Then
                    For i = 0 To CShort(GenMem.Appesi.Count - 1)
                        Ogg = GenMem.Appesi(i)
                        If Ogg.GenMem.Tipo = TipoMembratura.Cilindro_n Then
                            '  If CType(Ogg, Flangione).SottoTipo = SottoTipoFlangione.GradinoFemmina Then
                            AnelloSpinta = CType(Ogg, Cilindro)
                            Exit For
                            ' End If
                        End If
                    Next
                End If
            End If
            SetAnelloSpinta()
            AnelloSpinta.leggi(Inizio.DiscoRam, Mode)
            If Editing Then
                If VitiSupInt Is Nothing Then
                    For i = 0 To CShort(GenMem.Appesi.Count - 1)
                        Ogg = GenMem.Appesi(i)
                        If Ogg.GenMem.Tipo = TipoMembratura.Tiranti_n Then
                            If CType(Ogg, clsTirante).SottoTipo = SottoTipoTirante.ViteSpingitrice Then
                                VitiSupInt = CType(Ogg, clsTirante)
                                Exit For
                            End If
                        End If
                    Next
                End If
            End If
            SetVitiSupInt()
            VitiSupInt.leggi(Inizio.DiscoRam, Mode)
            If Editing Then
                If VitiSupExt Is Nothing Then
                    For i = 0 To CShort(GenMem.Appesi.Count - 1)
                        Ogg = GenMem.Appesi(i)
                        If Ogg.GenMem.Tipo = TipoMembratura.Tiranti_n Then
                            If CType(Ogg, clsTirante).SottoTipo = SottoTipoTirante.ViteSpingitrice Then
                                VitiSupExt = CType(Ogg, clsTirante)
                                Exit For
                            End If
                        End If
                    Next
                End If
            End If
            SetVitiSupExt()
            VitiSupExt.leggi(Inizio.DiscoRam, Mode)
            If Editing Then
                If Coperchio Is Nothing Then
                    For i = 0 To CShort(GenMem.Appesi.Count - 1)
                        Ogg = GenMem.Appesi(i)
                        If Ogg.GenMem.Tipo = TipoMembratura.Piastrone_n Then
                            '  If CType(Ogg, Flangione).SottoTipo = SottoTipoFlangione.GradinoFemmina Then
                            Coperchio = CType(Ogg, Piastrone)
                            Exit For
                            ' End If
                        End If
                    Next
                End If
            End If
            SetCoperchio()
            Coperchio.leggi(Inizio.DiscoRam, Mode)
            If objBre.TipoCassonetto = BreLock.TipiCassonetto.Conico Then
                If Editing Then
                    If CassonettoCon Is Nothing Then
                        For i = 0 To CShort(GenMem.Appesi.Count - 1)
                            Ogg = GenMem.Appesi(i)
                            If Ogg.GenMem.Tipo = TipoMembratura.Cono_n Then
                                '  If CType(Ogg, Flangione).SottoTipo = SottoTipoFlangione.GradinoFemmina Then
                                CassonettoCon = CType(Ogg, Cono)
                                Exit For
                                ' End If
                            End If
                        Next
                    End If
                End If
                SetCassonettoCon()
                CassonettoCon.leggi(Inizio.DiscoRam, Mode)
                If Editing Then
                    If FlangiaCassonCon Is Nothing Then
                        For i = 0 To CShort(GenMem.Appesi.Count - 1)
                            Ogg = GenMem.Appesi(i)
                            If Ogg.GenMem.Tipo = TipoMembratura.Anello_n Then
                                '  If CType(Ogg, Flangione).SottoTipo = SottoTipoFlangione.GradinoFemmina Then
                                FlangiaCassonCon = CType(Ogg, Anello)
                                Exit For
                                ' End If
                            End If
                        Next
                    End If
                End If
                SetFlangiaCassonCon()
                FlangiaCassonCon.leggi(Inizio.DiscoRam, Mode)
            ElseIf objBre.TipoCassonetto = BreLock.TipiCassonetto.CilindricoInLinea Then
                If Editing Then
                    If CassonettoCil Is Nothing Then
                        For i = 0 To CShort(GenMem.Appesi.Count - 1)
                            Ogg = GenMem.Appesi(i)
                            If Ogg.GenMem.Tipo = TipoMembratura.Cilindro_n Then
                                '  If CType(Ogg, Flangione).SottoTipo = SottoTipoFlangione.GradinoFemmina Then
                                CassonettoCil = CType(Ogg, Cilindro)
                                Exit For
                                ' End If
                            End If
                        Next
                    End If
                End If
                SetCassonettoCil()
                CassonettoCil.leggi(Inizio.DiscoRam, Mode)
                If Editing Then
                    If FlangiaCassonCon Is Nothing Then
                        For i = 0 To CShort(GenMem.Appesi.Count - 1)
                            Ogg = GenMem.Appesi(i)
                            If Ogg.GenMem.Tipo = TipoMembratura.Anello_n Then
                                '  If CType(Ogg, Flangione).SottoTipo = SottoTipoFlangione.GradinoFemmina Then
                                FlangiaCassonCon = CType(Ogg, Anello)
                                Exit For
                                ' End If
                            End If
                        Next
                    End If
                End If
                SetFlangiaCassonCon()
                FlangiaCassonCon.leggi(Inizio.DiscoRam, Mode)
            Else
                MessageBox.Show("Cassonetto cilindrico non in linea ancora da programmare")
            End If
        Else
            Stop
        End If
    End Sub
    Private Sub SetLockRing()
        If LockRing Is Nothing Then LockRing = New Flangione
        With LockRing
            .GenMem.Tipo = TipoMembratura.Flangione
            .SottoTipo = SottoTipoFlangione.LockRing
            GenMem.posizione.Copia((.GenMem.posizione))
            .GenMem.posizione.SuChi = Me
            .GenMem.posizione.DirDiritta = "=+"
            .GenMem.posizione.Anomal = ""
            .GenMem.posizione.Quota = (objBre.ImpilaggioPianoGsk - _
                                       Cassa.Lunghezza - Transition.H2 + _
                                       objBre.Guarn2.Spessore + _
                                       objBre.lbSpessMaxDiaf).ToString
            If .GenMem.PosDis <= 0 Then .GenMem.PosDis = Funzioni.SetPosizN(Me)
            .GenMem.Qta = 1
            .GenMem.Indmat1 = objBre.Mater(BreLock.CodMAT.MAT_LOCKRING).IndMat
            If Len(Trim(.GenMem.Denom)) = 0 Then .GenMem.Denom = "Threaded lock-ring"
            .Spessore = objBre.ThkAdpLR + objBre.AltezzaAnelliSuperiori
            .Diamext = objBre.Filetto.DMaxAn
            .Diamint = objBre.IDLockR
        End With
        GenMem.AppesiAdd(CType(LockRing, Membratura))
    End Sub
    Private Sub SetSplitRing()
        If SplitRing Is Nothing Then SplitRing = New Flangione
        With SplitRing
            .GenMem.Tipo = TipoMembratura.Flangione_n
            .SottoTipo = SottoTipoFlangione.AnelloSemplice
            GenMem.posizione.Copia((.GenMem.posizione))
            .GenMem.posizione.SuChi = Me
            .GenMem.posizione.DirDiritta = "=+"
            .GenMem.posizione.Anomal = ""
            .GenMem.posizione.Quota = (objBre.ImpilaggioSottoSR - _
                                       Cassa.Lunghezza - Transition.H2).ToString
            If .GenMem.PosDis <= 0 Then .GenMem.PosDis = Funzioni.SetPosizN(Me)
            .GenMem.Qta = 1
            .GenMem.Indmat1 = objBre.Mater(BreLock.CodMAT.MAT_SPLITRING).IndMat
            If Len(Trim(.GenMem.Denom)) = 0 Then .GenMem.Denom = "Split Ring"
            .Diamint = objBre.IDSplitRing
            .Diamext = objBre.ODSplitRing
            .Spessore = objBre.ThkAdpSplitRing
        End With
        GenMem.AppesiAdd(CType(SplitRing, Membratura))
    End Sub
    Private Sub SetCassonettoCon()
        If CassonettoCon Is Nothing Then CassonettoCon = New Cono
        With CassonettoCon
            .GenMem.Tipo = TipoMembratura.Cono_n
            GenMem.posizione.Copia((.GenMem.posizione))
            .GenMem.posizione.SuChi = Me
            .GenMem.posizione.DirDiritta = "=+"
            .GenMem.posizione.Anomal = ""
            .GenMem.posizione.Quota = (objBre.ImpilaggioSopraFC - _
                                       objBre.AltCasson - objBre.ThkAdpFC - _
                                       Cassa.Lunghezza - Transition.H2).ToString
            If .GenMem.PosDis <= 0 Then .GenMem.PosDis = Funzioni.SetPosizN(Me)
            .GenMem.Qta = 1
            .GenMem.Indmat1 = objBre.Mater(BreLock.CodMAT.MAT_CASSONETTO).IndMat
            If Len(Trim(.GenMem.Denom)) = 0 Then .GenMem.Denom = "Cassonetto"
            .Dgran = objBre.MaxDCasson - objBre.ThkCasson
            .Dpicc = objBre.MinDCasson - objBre.ThkCasson
            .Altezza = objBre.AltCasson
            .Spessore = objBre.ThkCasson
        End With
        GenMem.AppesiAdd(CType(CassonettoCon, Membratura))
    End Sub
    Private Sub SetCassonettoCil()
        If CassonettoCil Is Nothing Then CassonettoCil = New Cilindro
        With CassonettoCil
            .GenMem.Tipo = TipoMembratura.Cilindro_n
            GenMem.posizione.Copia((.GenMem.posizione))
            .GenMem.posizione.SuChi = Me
            .GenMem.posizione.DirDiritta = "=+"
            .GenMem.posizione.Anomal = ""
            .GenMem.posizione.Quota = (objBre.ImpilaggioSopraFC - _
                                       objBre.AltCasson - objBre.ThkAdpFC - _
                                       Cassa.Lunghezza - Transition.H2).ToString
            If .GenMem.PosDis <= 0 Then .GenMem.PosDis = Funzioni.SetPosizN(Me)
            .GenMem.Qta = 1
            .GenMem.Indmat1 = objBre.Mater(BreLock.CodMAT.MAT_CASSONETTO).IndMat
            If Len(Trim(.GenMem.Denom)) = 0 Then .GenMem.Denom = "Cassonetto"
            .Diametro = objBre.MinDCasson - objBre.ThkCasson
            .Lunghezza = objBre.AltCasson
            .Spessore = objBre.ThkCasson
        End With
        GenMem.AppesiAdd(CType(CassonettoCil, Membratura))
    End Sub
    Private Sub SetAnelloSupInt()
        If AnelloSupInt Is Nothing Then AnelloSupInt = New Flangione
        With AnelloSupInt
            .GenMem.Tipo = TipoMembratura.Flangione_n
            .SottoTipo = SottoTipoFlangione.AnelloSemplice
            GenMem.posizione.Copia((.GenMem.posizione))
            .GenMem.posizione.SuChi = Me
            .GenMem.posizione.DirDiritta = "=+"
            .GenMem.posizione.Anomal = ""
            .GenMem.posizione.Quota = (objBre.ImpilaggioPianoGsk - _
                                       Cassa.Lunghezza - Transition.H2 + _
                                       objBre.Guarn2.Spessore + _
                        objBre.lbSpessMaxDiaf).ToString
            If .GenMem.PosDis <= 0 Then .GenMem.PosDis = Funzioni.SetPosizN(Me)
            .GenMem.Qta = 1
            .GenMem.Indmat1 = objBre.Mater(BreLock.CodMAT.MAT_LOCKRING).IndMat
            If Len(Trim(.GenMem.Denom)) = 0 Then .GenMem.Denom = "Internal Push Ring"
            .Diamint = objBre.IDIntComprRing
            .Diamext = objBre.ODIntComprRing
            .Spessore = objBre.AltezzaAnelliSuperiori
        End With
        GenMem.AppesiAdd(CType(AnelloSupInt, Membratura))
    End Sub
    Private Sub SetDiaframmaElastico()
        If DiaframmaElastico Is Nothing Then DiaframmaElastico = New CalDisc
        With DiaframmaElastico
            .GenMem.Tipo = TipoMembratura.DiscCalFondiPiani_n
            .SottoTipo = SottoTipoCalDisc.DiaframmaElastico
            GenMem.posizione.Copia((.GenMem.posizione))
            .GenMem.posizione.SuChi = Me
            .GenMem.posizione.DirDiritta = "=+"
            .GenMem.posizione.Anomal = ""
            .GenMem.posizione.Quota = (objBre.ImpilaggioPianoGsk - _
                                       Cassa.Lunghezza - Transition.H2 + _
                                       objBre.Guarn2.Spessore).ToString
            If .GenMem.PosDis <= 0 Then .GenMem.PosDis = Funzioni.SetPosizN(Me)
            .GenMem.Qta = 1
            .GenMem.Indmat1 = objBre.Mater(BreLock.CodMAT.MAT_DIAFR).IndMat
            If Len(Trim(.GenMem.Denom)) = 0 Then .GenMem.Denom = "Elastic Diaphragm"
            .Diamext = objBre.G2out + 2 * objBre.G2AnExt - 2
            .LarghCorona = objBre.G2N + objBre.G2AnExt + objBre.G2AnInt - 2
            .LarghSpessMin = (.Diamext - 2 * .LarghCorona - objBre.IDLockR) / 2
            .SpessMinimo = objBre.lbSpessMinDiaf
            .SpessCentrale = objBre.lbSpessMaxDiaf
            .SpessPeriferico = objBre.lbSpessMaxDiaf
        End With
        GenMem.AppesiAdd(CType(DiaframmaElastico, Membratura))
    End Sub
    Private Sub SetGuarnizioneLR()
        If GuarnizioneLR Is Nothing Then GuarnizioneLR = New clsGuarniz
        With GuarnizioneLR
            .GenMem.Tipo = TipoMembratura.Guarnizione_n
            ' .SottoTipo = SottoTipoCalDisc.DiaframmaElastico
            GenMem.posizione.Copia((.GenMem.posizione))
            .GenMem.posizione.SuChi = Me
            .GenMem.posizione.DirDiritta = "=+"
            .GenMem.posizione.Anomal = ""
            .GenMem.posizione.Quota = (objBre.ImpilaggioPianoGsk - _
                                       Cassa.Lunghezza - Transition.H2).ToString
            If .GenMem.PosDis <= 0 Then .GenMem.PosDis = Funzioni.SetPosizN(Me)
            .GenMem.Qta = 1
            If Len(Trim(.GenMem.Denom)) = 0 Then .GenMem.Denom = "Gasket LR"
            .Largh = objBre.G2N
            .DiamMed = objBre.G2out - objBre.G2N
            .Spess = objBre.Guarn2.Spessore
            .LarghExt = objBre.G2AnExt
            .LarghInt = objBre.G2AnInt
            .SpessAn = CSng(0.8 * .Spess)
        End With
        GenMem.AppesiAdd(CType(GuarnizioneLR, Membratura))
    End Sub
    Private Sub SetAnelloSupExt()
        If AnelloSupExt Is Nothing Then AnelloSupExt = New Flangione
        With AnelloSupExt
            .GenMem.Tipo = TipoMembratura.Flangione_n
            .SottoTipo = SottoTipoFlangione.AnelloSemplice
            GenMem.posizione.Copia((.GenMem.posizione))
            .GenMem.posizione.SuChi = Me
            .GenMem.posizione.DirDiritta = "=+"
            .GenMem.posizione.Anomal = ""
            .GenMem.posizione.Quota = (objBre.ImpilaggioPianoGsk - _
                                       Cassa.Lunghezza - Transition.H2 + _
                                       objBre.Guarn2.Spessore + _
                                       objBre.lbSpessMaxDiaf).ToString
            If .GenMem.PosDis <= 0 Then .GenMem.PosDis = Funzioni.SetPosizN(Me)
            .GenMem.Qta = 1
            .GenMem.Indmat1 = objBre.Mater(BreLock.CodMAT.MAT_LOCKRING).IndMat
            If Len(Trim(.GenMem.Denom)) = 0 Then .GenMem.Denom = "External Push Ring"
            .Diamint = objBre.IDExtComprRing
            .Diamext = objBre.ODExtComprRing
            .Spessore = objBre.AltezzaAnelliSuperiori
        End With
        GenMem.AppesiAdd(CType(AnelloSupExt, Membratura))
    End Sub
    Private Sub SetAnelloInterno()
        If AnelloInterno Is Nothing Then AnelloInterno = New Flangione
        With AnelloInterno
            .GenMem.Tipo = TipoMembratura.Flangione_n
            .SottoTipo = SottoTipoFlangione.GradinoFemmina
            GenMem.posizione.Copia((.GenMem.posizione))
            .GenMem.posizione.SuChi = Me
            .GenMem.posizione.DirDiritta = "=+"
            .GenMem.posizione.Anomal = ""
            .GenMem.posizione.Quota = (objBre.ImpilaggioSopraFC() + _
                                       objBre.lbAria_FlangiaCAssonetto_AnelloInterno - _
                                       Cassa.Lunghezza - Transition.H2).ToString
            If .GenMem.PosDis <= 0 Then .GenMem.PosDis = Funzioni.SetPosizN(Me)
            .GenMem.Qta = 1
            .GenMem.Indmat1 = objBre.Mater(BreLock.CodMAT.MAT_SPLITRING).IndMat
            If Len(Trim(.GenMem.Denom)) = 0 Then .GenMem.Denom = "Internal Ring"
            .Diamint = objBre.IDInnerRing
            .Diamext = objBre.ODInnerRing
            .Spessore = objBre.ThkAdpInnerRing
            .SpessGra = objBre.lbSpessGradinoAnelloInterno
            .DiamGra = .Diamint + 2 * objBre.lbThkCompRing
            .SpessGra2 = objBre.lbSpessGradinoAnelloInterno
            .DiamGra2 = objBre.IDSplitRing
        End With
        GenMem.AppesiAdd(CType(AnelloInterno, Membratura))
    End Sub
    Private Sub SetFlangiaCassonCon()
        If FlangiaCassonCon Is Nothing Then FlangiaCassonCon = New Anello
        With FlangiaCassonCon
            .GenMem.Tipo = TipoMembratura.Anello_n
            '.SottoTipo = SottoTipoFlangione.GradinoFemmina
            GenMem.posizione.Copia((.GenMem.posizione))
            .GenMem.posizione.SuChi = Me
            .GenMem.posizione.DirDiritta = "=+"
            .GenMem.posizione.Anomal = ""
            .GenMem.posizione.Quota = (objBre.ImpilaggioSopraFC - _
                                       objBre.ThkAdpFC - _
                                       Cassa.Lunghezza - Transition.H2).ToString
            If .GenMem.PosDis <= 0 Then .GenMem.PosDis = Funzioni.SetPosizN(Me)
            .GenMem.Qta = 1
            .GenMem.Indmat1 = objBre.Mater(BreLock.CodMAT.MAT_FL_CASSON).IndMat
            If Len(Trim(.GenMem.Denom)) = 0 Then .GenMem.Denom = "Flangia cassonetto"
            .Diamint = objBre.DIAnelCono
            .Diamext = objBre.DOAnelCono
            .Spessore = objBre.ThkAdpFC
        End With
        GenMem.AppesiAdd(CType(FlangiaCassonCon, Membratura))
    End Sub
    Private Function SetTransition() As Boolean
        Dim i As Integer
        SetTransition = True
        Transition = Nothing
        For i = 1 To Apparecchio.Elementi.Count - 1
            If Apparecchio.Elementi(i).GenMem.Tipo = TipoMembratura.Flangione Then
                Dim T As Flangione = CType(Apparecchio.Elementi(i), Flangione)
                If T.SottoTipo = SottoTipoFlangione.Transition Then
                    Transition = T
                    Exit For
                End If
            End If
        Next
        If Transition Is Nothing Then
            MostraAiuto(1001)
            Return False
        End If
        Transition.Dummy = Integrale
    End Function
    Private Function SetCassa() As Boolean
        Dim i As Integer
        SetCassa = True
        Cassa = Nothing
        For i = 1 To Apparecchio.Elementi.Count - 1
            If Apparecchio.Elementi(i).GenMem.Tipo = TipoMembratura.Cilindro Then
                Dim C As Cilindro = CType(Apparecchio.Elementi(i), Cilindro)
                If C.GenMem.posizione.SuChi Is Transition Or _
                   Transition.GenMem.posizione.SuChi Is C Then
                    Cassa = C
                    Exit For
                End If
            End If
        Next
        If Cassa Is Nothing Then
            MostraAiuto(1002)
            Return False
        End If
        Cassa.Dummy = Integrale
    End Function
    Private Function SetPT() As Boolean
        Dim i As Integer
        SetPT = True
        PiastraTubiera = Nothing
        For i = 1 To Apparecchio.Elementi.Count - 1
            If Apparecchio.Elementi(i).GenMem.Tipo = TipoMembratura.Piastrone Then
                Dim PT As Piastrone = CType(Apparecchio.Elementi(i), Piastrone)
                If PT.SottoTipo = SottoTipoPiastrone._4_BiFlangSenzaEstensione Then
                    PiastraTubiera = PT
                    Exit For
                End If
            End If
        Next
        If PiastraTubiera Is Nothing Then
            MostraAiuto(1003)
            Return False
        End If
    End Function
    Private Sub SetVitiInterne()
        If VitiInterne Is Nothing Then VitiInterne = New clsTirante
        With VitiInterne
            .GenMem.Tipo = TipoMembratura.Tiranti_n
            .SottoTipo = SottoTipoTirante.ViteSpingitriceNasello
            GenMem.posizione.Copia((.GenMem.posizione))
            .GenMem.posizione.SuChi = AnelloInterno
            .GenMem.posizione.DirDiritta = "=+"
            .GenMem.posizione.Anomal = ""
            .GenMem.posizione.Quota = (0.5 * objBre.lbLunghNasello).ToString
            If .GenMem.PosDis <= 0 Then .GenMem.PosDis = Funzioni.SetPosizN(Me)
            .GenMem.Qta = objBre.NumScr
            .GenMem.Indmat1 = objBre.Mater(BreLock.CodMAT.MAT_INTSCREWS).IndMat
            If Len(Trim(.GenMem.Denom)) = 0 Then .GenMem.Denom = "Vite di spinta"
            .StandardTir.Xfil = objBre.Tir0.Xfil
            .Dinst = objBre.BCIntScr
            .StandardTir.DN = objBre.Tir0.DN
            .StandardTir.CercaDN()
            .DiamNasello = CInt(Sqrt(4 / PI * objBre.AreExtension))
            .LungNasello = objBre.lbLunghNasello
            .Lunghezza = CInt(AnelloInterno.Spessore + _
                         SplitRing.Spessore + _
                         objBre.lbSopralzoTestaVitiInterne + _
                         .StandardTir.Diam + 1.5 * .LungNasello + 0.49)
            .nDadi = 0
        End With
        GenMem.AppesiAdd(CType(VitiInterne, Membratura))
    End Sub
    Private Sub SetVitiSupInt()
        If VitiSupInt Is Nothing Then VitiSupInt = New clsTirante
        With VitiSupInt
            .GenMem.Tipo = TipoMembratura.Tiranti_n
            .SottoTipo = SottoTipoTirante.ViteSpingitrice
            GenMem.posizione.Copia((.GenMem.posizione))
            .GenMem.posizione.SuChi = LockRing
            .GenMem.posizione.DirDiritta = "=+"
            .GenMem.posizione.Anomal = ""
            .GenMem.posizione.Quota = (-objBre.AltezzaAnelliSuperiori).ToString
            If .GenMem.PosDis <= 0 Then .GenMem.PosDis = Funzioni.SetPosizN(Me)
            .GenMem.Qta = CShort(objBre.NumScr2)
            .GenMem.Indmat1 = objBre.Mater(BreLock.CodMAT.MAT_EXTSCREWS).IndMat
            If Len(Trim(.GenMem.Denom)) = 0 Then .GenMem.Denom = "Vite di registro"
            .StandardTir.Xfil = objBre.Tir1.Xfil
            .Dinst = objBre.BCIntScr2
            .StandardTir.DN = objBre.Tir1.DN
            .StandardTir.CercaDN()
            .Lunghezza = CSng(objBre.ThkAdpLR + _
                         2 * .StandardTir.Diam)
            .nDadi = 0
        End With
        GenMem.AppesiAdd(CType(VitiSupInt, Membratura))
    End Sub
    Private Sub SetVitiSupExt()
        If VitiSupExt Is Nothing Then VitiSupExt = New clsTirante
        With VitiSupExt
            .GenMem.Tipo = TipoMembratura.Tiranti_n
            .SottoTipo = SottoTipoTirante.ViteSpingitrice
            GenMem.posizione.Copia((.GenMem.posizione))
            .GenMem.posizione.SuChi = LockRing
            .GenMem.posizione.DirDiritta = "=+"
            .GenMem.posizione.Anomal = ""
            .GenMem.posizione.Quota = (-objBre.AltezzaAnelliSuperiori).ToString
            If .GenMem.PosDis <= 0 Then .GenMem.PosDis = Funzioni.SetPosizN(Me)
            .GenMem.Qta = CShort(objBre.NExtScr)
            .GenMem.Indmat1 = objBre.Mater(BreLock.CodMAT.MAT_EXTSCREWS).IndMat
            If Len(Trim(.GenMem.Denom)) = 0 Then .GenMem.Denom = "Vite di tenuta"
            .StandardTir.Xfil = objBre.Tir2.Xfil
            .Dinst = objBre.BCExtScr
            .StandardTir.DN = objBre.Tir2.DN
            .StandardTir.CercaDN()
            .Lunghezza = CSng(objBre.ThkAdpLR + _
                         2 * .StandardTir.Diam)
            .nDadi = 0
        End With
        GenMem.AppesiAdd(CType(VitiSupExt, Membratura))
    End Sub
    Private Sub SetAnelloSpinta()
        If AnelloSpinta Is Nothing Then AnelloSpinta = New Cilindro
        With AnelloSpinta
            .GenMem.Tipo = TipoMembratura.Cilindro_n
            '.SottoTipo = Sotto
            GenMem.posizione.Copia((.GenMem.posizione))
            .GenMem.posizione.SuChi = Me
            .GenMem.posizione.DirDiritta = "=+"
            .GenMem.posizione.Anomal = ""
            .GenMem.posizione.Quota = (objBre.ImpilaggioSopraFC() + _
                                       objBre.lbAria_FlangiaCAssonetto_AnelloInterno + _
                                       objBre.ThkAdpInnerRing - _
                                       objBre.lbSpessGradinoAnelloInterno - _
                                       Cassa.Lunghezza - Transition.H2).ToString
            If .GenMem.PosDis <= 0 Then .GenMem.PosDis = Funzioni.SetPosizN(Me)
            .GenMem.Qta = 1
            .GenMem.Indmat1 = objBre.Mater(BreLock.CodMAT.MAT_CASSONETTO).IndMat
            If Len(Trim(.GenMem.Denom)) = 0 Then .GenMem.Denom = "Lower push ring"
            .Lunghezza = CSng(objBre.ImpilaggioPianoGsk + _
                              objBre.Guarn2.Spessore + _
                              Me.DiaframmaElastico.SpessPeriferico - _
                              Me.DiaframmaElastico.SpessMinimo - _
                              objBre.ImpilaggioSottoSR)
            .Spessore = objBre.lbThkCompRing
            .Diametro = Me.AnelloInterno.Diamint
        End With
        GenMem.AppesiAdd(CType(AnelloSpinta, Membratura))
    End Sub
    Private Sub SetCoperchio()
        If Coperchio Is Nothing Then Coperchio = New Piastrone
        With Coperchio
            .GenMem.Tipo = TipoMembratura.Piastrone_n
            .SottoTipo = SottoTipoPiastrone._4_BiFlangSenzaEstensione
            GenMem.posizione.Copia((.GenMem.posizione))
            .GenMem.posizione.SuChi = Me
            .GenMem.posizione.DirDiritta = "=+"
            .GenMem.posizione.Anomal = ""
            .GenMem.posizione.Quota = (objBre.ImpilaggioPianoGsk - _
                                       Cassa.Lunghezza - Transition.H2 + _
                                       objBre.Guarn2.Spessore + _
                                       objBre.lbSpessMaxDiaf).ToString
            If .GenMem.PosDis <= 0 Then .GenMem.PosDis = Funzioni.SetPosizN(Me)
            .GenMem.Qta = 1
            .GenMem.Indmat1 = objBre.Mater(BreLock.CodMAT.MAT_COVER).IndMat
            If Len(Trim(.GenMem.Denom)) = 0 Then .GenMem.Denom = "Channel cover"
            .Spessore = objBre.ThkAdpCv
            .Diamext = objBre.ODCover
            .H1 = 0
            .H3 = .Spessore - objBre.ExtCrwAdpThk
            .B3 = objBre.IDLockR
        End With
        GenMem.AppesiAdd(CType(Coperchio, Membratura))
    End Sub
    Public Overloads Sub Copia(ByRef A As Fascio)
        MsgBox("mi rifiuto di copiare un cass BL")
    End Sub
End Class
