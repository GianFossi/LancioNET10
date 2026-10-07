Option Strict Off
Option Explicit On
Imports Infralution.Licensing
Imports Routbase1
Imports System.math
Friend Class frmApert
    Inherits System.Windows.Forms.Form
    Private Antiripeti As Boolean
    Private iMat As Short
    Private Storia As Short
    Private pages8(), Pages4() As TabPage
    Friend InApertura, Aggiornando As Boolean
    Private vecchiotab As TabPage
    Private Esito As Boolean
    Private Inizializzando As Boolean
    Private Resetting As Boolean
    Private NonAncora As Boolean = True
    Private EP_txtPT_9 As ErrorProvider
    Private EP_txtLR_5 As ErrorProvider
    Private EP_txtLR_26 As ErrorProvider
    Private EP_txtSplit_0 As ErrorProvider
    Private EP_txtSplit_1 As ErrorProvider
    Private EP_txtSplit_3 As ErrorProvider
    Private EP_txtSplit_4 As ErrorProvider
    Private EP_txtSplit_5 As ErrorProvider
    Private EP_txtSplit_6 As ErrorProvider
    Private EP_txtSplit_8 As ErrorProvider
    Public EP_txtCasson_0 As ErrorProvider
    Public EP_txtCasson_1 As ErrorProvider
    Public EP_txtCasson_2 As ErrorProvider
    Public EP_txtCasson_4 As ErrorProvider
    Public EP_txtCasson_5 As ErrorProvider
    Public EP_txtCasson_3 As ErrorProvider
    Public EP_txtCasson_13 As ErrorProvider
    Public EP_txtShell_2 As ErrorProvider
    Public EP_txtShell_4 As ErrorProvider
    Public EP_txtShell_16 As ErrorProvider
    Public EP_txtShell_18 As ErrorProvider
    Public EP_txtchan_0 As ErrorProvider
    Public EP_txtchan_3 As ErrorProvider
    Public EP_txtchan_4 As ErrorProvider
    Public EP_txtchan_12 As ErrorProvider
    Public EP_txtViti_2 As ErrorProvider
    Public EP_txtVitiInt_10 As ErrorProvider
    Public EP_txtVitiExt_10 As ErrorProvider
    Private Sub chkDeltaT_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkDeltaT.CheckStateChanged
        If Inizializzando Then Exit Sub
        objBre.CalcDeltaT = chkDeltaT.CheckState
        txtLR(20).Visible = chkDeltaT.CheckState = 1
        txtLR(21).Visible = chkDeltaT.CheckState = 1
        _Label_119.Visible = chkDeltaT.CheckState = 1
        _Label_120.Visible = chkDeltaT.CheckState = 1
        _lblMis_91.Visible = chkDeltaT.CheckState = 1
        _lblMis_92.Visible = chkDeltaT.CheckState = 1
    End Sub
    Private Sub cmbMat_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbMat.SelectedIndexChanged
        If Inizializzando Then Exit Sub
        iMat = cmbMat.SelectedIndex
        If iMat = -1 Then Exit Sub
        Try
            cmbMat.Tag = EspandiMat(iMat + 1).ToString
            AzioniMateriali()
            UpDownMat.Enabled = False
            UpDownMat.Value = iMat
            UpDownMat.Enabled = True
        Catch ex As Exception
            MessageBox.Show(ex.Message + vbCrLf + ex.StackTrace)
        End Try
    End Sub
    Private Sub AzioniMateriali()
        With objBre.Mater(Val(cmbMat.Tag))
            Aggiornando = True
            txtMat(8).Text = .Mat
            Aggiornando = False
            If (.TempDes = 0) Or Resetting Then
                '  cmdRic.Enabled = False
                Select Case cmbMat.SelectedIndex + 1
                    Case CodMAT.MAT_SHELL, CodMAT.MAT_FONDO
                        .TempDes = objBre.DesTempSS
                    Case CodMAT.MAT_TUBI, CodMAT.MAT_TS
                        If objBre.DesTempTS > objBre.DesTempSS Then .TempDes = objBre.DesTempTS Else .TempDes = objBre.DesTempSS
                    Case Else
                        .TempDes = objBre.DesTempTS
                End Select
                .Autom(0) = True
                objmat.Indmat = .IndMat
                objmat.RecupMat(Monitor.Motore.Inizio.Archdir)
                AggiornaValori()
            End If
            AggiornaDisplay()
        End With

    End Sub
    Private ReadOnly Property lblMismat(ByVal i As Integer) As Label
        Get
            Select Case i
                Case 0 : Return _lblMisMat_0
                Case 1 : Return _lblMisMat_1
                Case 2 : Return _lblMisMat_2
                Case 3 : Return _lblMisMat_3
                Case 4 : Return _lblMisMat_4
                Case 5 : Return _lblMisMat_5
                Case 6 : Return _lblMisMat_6
                Case 7 : Return _lblMisMat_7
                Case Else : Return Nothing
            End Select
        End Get
    End Property
    Private ReadOnly Property lblmat(ByVal i As Integer) As Label
        Get
            Select Case i
                Case 0 : Return _lblMat_0
                Case 1 : Return _lblMat_1
                Case 2 : Return _lblMat_2
                Case 3 : Return _lblMat_3
                Case 4 : Return _lblMat_4
                Case 5 : Return _lblMat_5
                Case 6 : Return _lblMat_6
                Case 7 : Return _lblMat_7
                Case Else : Return Nothing
            End Select
        End Get
    End Property
    Private Sub AggiornaDisplay(Optional ByVal cod As Integer = 0)
        Dim i, CodMat As Integer
        Aggiornando = True
        If cod = 0 Then
            CodMat = Val(cmbMat.Tag)
        Else
            CodMat = cod
        End If
        If objBre.Mater(CodMat) Is Nothing Then Exit Sub
        With objBre.Mater(CodMat)
            txtMat(0).Text = GlobalRoutines.myStr(.TempDes, 4, 2, False)
            txtMat(1).Text = GlobalRoutines.myStr(.S, 4, 2, False)
            txtMat(2).Text = GlobalRoutines.myStr(.S0, 4, 2, False)
            txtMat(3).Text = GlobalRoutines.myStr(.SY, 4, 2, False)
            txtMat(4).Text = GlobalRoutines.myStr(.SY0, 4, 2, False)
            txtMat(5).Text = GlobalRoutines.myStr(.E, 6, 0, False)
            txtMat(6).Text = GlobalRoutines.myStr(.E0, 6, 0, False)
            txtMat(7).Text = Microsoft.VisualBasic.Strings.Format(.Alfa, "#.###E-00")
            For i = 0 To 7
                If .Autom(i) Then
                    txtMat(i).BackColor = System.Drawing.Color.Yellow
                Else
                    txtMat(i).BackColor = System.Drawing.Color.White
                End If
                txtMat(i).Visible = True
                lblmat(i).Visible = True
                lblMismat(i).Visible = True
            Next
        End With
        Select Case CType(Val(cmbMat.Tag), CodMAT)
            Case BreLock.CodMAT.MAT_INSERTO
                _txtMat_1.Visible = False : _lblMat_1.Visible = False : _lblMisMat_1.Visible = False
                _txtMat_2.Visible = False : _lblMat_2.Visible = False : _lblMisMat_2.Visible = False
                _txtMat_5.Visible = False : _lblMat_5.Visible = False : _lblMisMat_5.Visible = False
                _txtMat_6.Visible = False : _lblMat_6.Visible = False : _lblMisMat_6.Visible = False
                _txtMat_7.Visible = False : _lblMat_7.Visible = False : _lblMisMat_7.Visible = False
            Case BreLock.CodMAT.MAT_SHELL, BreLock.CodMAT.MAT_FONDO
                _txtMat_2.Visible = False : _lblMat_2.Visible = False : _lblMisMat_2.Visible = False
                _txtMat_3.Visible = False : _lblMat_3.Visible = False : _lblMisMat_3.Visible = False
                _txtMat_4.Visible = False : _lblMat_4.Visible = False : _lblMisMat_4.Visible = False
                _txtMat_5.Visible = False : _lblMat_5.Visible = False : _lblMisMat_5.Visible = False
                _txtMat_6.Visible = False : _lblMat_6.Visible = False : _lblMisMat_6.Visible = False
                _txtMat_7.Visible = False : _lblMat_7.Visible = False : _lblMisMat_7.Visible = False
            Case BreLock.CodMAT.MAT_CHANNEL
                _txtMat_2.Visible = False : _lblMat_2.Visible = False : _lblMisMat_2.Visible = False
                _txtMat_3.Visible = False : _lblMat_3.Visible = False : _lblMisMat_3.Visible = False
                _txtMat_4.Visible = False : _lblMat_4.Visible = False : _lblMisMat_4.Visible = False
            Case BreLock.CodMAT.MAT_TS, BreLock.CodMAT.MAT_TUBI
                _txtMat_3.Visible = False : _lblMat_3.Visible = False : _lblMisMat_3.Visible = False
                _txtMat_4.Visible = False : _lblMat_4.Visible = False : _lblMisMat_4.Visible = False
                _txtMat_5.Visible = False : _lblMat_5.Visible = False : _lblMisMat_5.Visible = False
                _txtMat_6.Visible = False : _lblMat_6.Visible = False : _lblMisMat_6.Visible = False
                _txtMat_7.Visible = False : _lblMat_7.Visible = False : _lblMisMat_7.Visible = False
            Case BreLock.CodMAT.MAT_CASSONETTO, BreLock.CodMAT.MAT_LOCKRING
            Case BreLock.CodMAT.MAT_PUSHRING, BreLock.CodMAT.MAT_FL_CASSON
                _txtMat_7.Visible = False : _lblMat_7.Visible = False : _lblMisMat_7.Visible = False
            Case BreLock.CodMAT.MAT_SPLITRING, BreLock.CodMAT.MAT_INTSCREWS, BreLock.CodMAT.MAT_EXTSCREWS, BreLock.CodMAT.MAT_COVER
                _txtMat_5.Visible = False : _lblMat_5.Visible = False : _lblMisMat_5.Visible = False
                _txtMat_6.Visible = False : _lblMat_6.Visible = False : _lblMisMat_6.Visible = False
                _txtMat_7.Visible = False : _lblMat_7.Visible = False : _lblMisMat_7.Visible = False
        End Select
        Aggiornando = False
    End Sub
    Private Sub cmbPrecis_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbPrecis.SelectedIndexChanged
        If Inizializzando Then Exit Sub
        With objBre.Filetto
            .Precision = cmbPrecis.SelectedIndex + 5
            txtLR(19).Enabled = .Precision = 8
            If .Precision = 8 Then
                txtLR(19).BackColor = System.Drawing.Color.White
            Else
                txtLR(19).BackColor = System.Drawing.Color.Yellow
            End If
        End With
        If Not Aggiornando Then Calcolato(7) = False
        InizLR8()
        AggText()
    End Sub
    Private Sub cmbStampa_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbStampa.SelectedIndexChanged
        If Inizializzando Then Exit Sub
        objBre.iStampa = cmbStampa.SelectedIndex + 1
    End Sub
    Private Sub cmbTipoFil_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbTipoFil.SelectedIndexChanged
        If Inizializzando Then Exit Sub
        With objBre
            .OptFiletto = cmbTipoFil.SelectedIndex
        End With
        cmbPrecis.Visible = cmbTipoFil.SelectedIndex > 0
        lblPrecis.Visible = cmbTipoFil.SelectedIndex > 0
        _Label_118.Visible = cmbTipoFil.SelectedIndex > 0
        _txtLR_19.Visible = cmbTipoFil.SelectedIndex > 0
        _lblMis_90.Visible = cmbTipoFil.SelectedIndex > 0
        txtLR(1).Enabled = cmbTipoFil.SelectedIndex > 0
        If cmbTipoFil.SelectedIndex > 0 Then
            txtLR(1).BackColor = System.Drawing.Color.White
        Else
            txtLR(1).BackColor = System.Drawing.Color.Yellow
        End If
        InizLR8()
        AggText()
        If Not Aggiornando Then Calcolato(7) = False
    End Sub
    Private Function CheckLicenza() As Boolean
        Dim DllDir As String = Monitor.Motore.Inizio.Basedir & "\Dll" 'Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData)
        Dim licenseFile As String = DllDir + "\LicensedApp\BreLock.lic"
        Return LegacyBreLockLicense.ValidateLicense(LICENSE_PARAMETERS, licenseFile)
    End Function
    Private Sub cmdCalc_Click(ByVal Index As Short)
        Dim iTir As Integer
        If NonAncora Then
            If Not CheckLicenza() Then Exit Sub
            NonAncora = False
        End If
        'If Index > 1 And Index < 8 Then
        ' If Not Calcolato(Index - 1) Then Calcolato(Index) = False : Exit Sub
        ' End If
        If Index > 1 Then
            TabStrip1.Enabled = False
            TabStrip1.SelectedIndex = Index
            TabStrip1.Enabled = True
        End If
        Select Case Espandi(Index)
            Case 1 'mantello
                If objBre.TipoBL = 0 Then Exit Sub
                Esito = CheckDatiMantello()
                If Not Esito Then Call Fallimento(Index) : Exit Sub
                objBre.Guarn.Width(objBre.G1N, objBre.B1, objBre.Nubbin, objBre.G1eff, objBre.G1out, objBre.Formula)
                If objBre.B1 * objBre.Formula = 0 Then Call Fallimento(Index) : Exit Sub
                BRE()
                Labelcom1.Text = HelpStringa(STA_MANTELLO)
            Case 2 'PT
                Esito = CheckDatiPT()
                If Not Esito Then Call Fallimento(Index) : Exit Sub
                'Aggiornando = True
                ' TabStrip1.SelectedIndex = 1
                'Aggiornando = False
                'Storia = 0
                'TabStrip1_ClickEvent(Me, Nothing)
                TUBESHEET()
                'TabStrip1.SelectedIndex = 2
                Labelcom1.Text = HelpStringa(STA_PT)
            Case 3 'Viti interne
                Esito = CheckDatiScr()
                If Not Esito Then Call Fallimento(Index) : Exit Sub
                'Aggiornando = True
                'TabStrip1.SelectedIndex = 2
                'Aggiornando = False
                'Storia = 0
                'TabStrip1_ClickEvent(Me, Nothing)
                With objBre
                    If modMain.optVitiAutomatiche Then
                        .Tir0.Xfil = objBre.xFil1
                        iTir = 0
                        Do
                            iTir += 1
                            .Tir0.Preleva(iTir)
                            .DNStr1 = .Tir0.DN
                            .xFil1 = .Tir0.Xfil
                            .DNIntScr = .Tir0.Dnom
                            .BSmin1 = .Tir0.BSmin
                            .AreBltScr = .Tir0.Diam ^ 2 * PI / 4
                            cmdEstensioneAutomatica_Click(Me, Nothing)
                            InizIntScr3()
                            '  INTSCR()
                        Loop While Not AggiornaViti(0, True)
                    End If
                End With
                INTSCR()
                Labelcom1.Text = HelpStringa(STA_NUMSCR)
                'TabStrip1.SelectedIndex = 3
            Case 4 'Anelli
                Esito = CheckDatiAnelli()
                If Not Esito Then Call Fallimento(Index) : Exit Sub
                'Aggiornando = True
                'TabStrip1.SelectedIndex = 3
                'Aggiornando = False
                'Storia = 0
                'TabStrip1_ClickEvent(Me, Nothing)
                Anelli()
                'TabStrip1.SelectedIndex = 4
                Labelcom1.Text = HelpStringa(STA_ANELLI)
                'TabStrip1.SelectedIndex = 4
            Case 5 'Cassonetto
                Esito = CheckDatiCassonetto()
                If Not Esito Then Call Fallimento(Index) : Exit Sub
                'Aggiornando = True
                'TabStrip1.SelectedIndex = 4
                'Aggiornando = False
                'Storia = 0
                'TabStrip1_ClickEvent(Me, Nothing)
                If CalcolaTutto Then
                    Me.cmdMincasson_Click(Me, Nothing)
                Else
                    CASSONETTO()
                End If
                With objBre
                    If .IDChan < .IDShell + 2 * (.ThkCasson + 2 * .lbRadialGap) Then
                        Calcolato(1) = False
                        Calcolato(2) = False
                        Calcolato(3) = False
                        Calcolato(4) = False
                    End If
                End With
                Labelcom1.Text = HelpStringa(STA_CASSONETTO)
                'TabStrip1.SelectedIndex = 5
            Case 6 'Cassa
                Esito = CheckDatiCassa()
                If Not Esito Then Call Fallimento(Index) : Exit Sub
                'Aggiornando = True
                'TabStrip1.SelectedIndex = 5
                'Aggiornando = False
                'Storia = 0
                'TabStrip1_ClickEvent(Me, Nothing)
                GSKCH()
                Labelcom1.Text = HelpStringa(STA_CASSA)
                With objBre
                    If .SpostDiaf1 = 0 Then .SpostDiaf1 = 3
                    If .SpostDiaf2 = 0 Then .SpostDiaf2 = 1
                    If .SpessDiaf = 0 Then .SpessDiaf = 3
                End With
                'TabStrip1.SelectedIndex = 6
            Case 7 'Viti esterne
                Esito = CheckDatiVitiExt()
                If Not Esito Then Call Fallimento(Index) : Exit Sub
                'Aggiornando = True
                'TabStrip1.SelectedIndex = 6
                'Aggiornando = False
                'Storia = 0
                'TabStrip1_ClickEvent(Me, Nothing)
                With objBre
                    If modMain.optVitiAutomatiche Then
                        If objBre.TipoBL = 1 Then
                            If .xFil2 = 0 Then .xFil2 = 2
                            .Tir1.Xfil = .xFil2
                            iTir = 0
                            Do
                                iTir += 1
                                .Tir1.Preleva(iTir)
                                .DNStr2 = .Tir1.DN
                                .DNBltScr2 = .Tir1.Dnom
                                .xFil2 = .Tir1.Xfil
                                .BSmin2 = .Tir1.BSmin
                                .AreBltScr2 = .Tir1.Diam ^ 2 * PI / 4
                                .DNIntPushBar2 = .Tir1.Dnom
                                PUSHBARS()
                                InizScrews7()
                            Loop While Not AggiornaViti(1, True)
                        End If
                        If .xFil3 = 0 Then .xFil3 = 2
                        .Tir2.Xfil = .xFil3
                        iTir = 0
                        Do
                            iTir += 1
                            .Tir2.Preleva(iTir)
                            .DNStr3 = .Tir2.DN
                            .AreExtScr = .Tir2.Diam ^ 2 * PI / 4
                            .xFil3 = .Tir2.Xfil
                            .DNExtScr = .Tir2.Dnom
                            .DPushBars = .Tir2.Dnom
                            .BSmin3 = .Tir2.BSmin
                            PUSHBARS()
                            InizScrews7()
                        Loop While Not AggiornaViti(2, True)
                    End If
                End With
                PUSHBARS()
                Labelcom1.Text = HelpStringa(STA_PUSHBARS)
                'TabStrip1.SelectedIndex = 7
            Case 8 'Lock Ring
                Esito = CheckDatiLR()
                If Not Esito Then Call Fallimento(Index) : Exit Sub
                'Aggiornando = True
                'TabStrip1.SelectedIndex = 7
                'Aggiornando = False
                'Storia = 0
                'TabStrip1_ClickEvent(Me, Nothing)
                CalcDeltaT()
                LOCKRING()
                Labelcom1.Text = HelpStringa(STA_LOCKRING)
                'TabStrip1.SelectedIndex = 8
        End Select
        Calcolato(Espandi(Index)) = True
        With objBre
            Select Case Espandi(Index)
                Case 1
                    If .ThkAdpSh < CShort(.ThkMinSh + 0.5) Then .ThkAdpSh = CShort(.ThkMinSh + 0.5)
                    If .ThkAdpHe < CShort(.ThkMinHe + 0.5) Then .ThkAdpHe = CShort(.ThkMinHe + 0.5)
                Case 2
                    If .ThkAdpTS < CShort(.ThkMinTS + 0.5) Then .ThkAdpTS = CShort(.ThkMinTS + 0.5)
                Case 4
                    If .au_ThkAdpInnerRing Then .ThkAdpInnerRing = CShort(.ThkReqInnerRing + 0.49)
                    If .au_ThkAdpSplitRing Then .ThkAdpSplitRing = CShort(.ThkReqSplitRing + 0.49)
                Case 5
                    If .au_ThkAdpFC Then .ThkAdpFC = CShort(.ThkMinFC + 0.49)
                Case 6
                    If .ThkAdpCh < CShort(.ThkMinCh + 0.49) Then .ThkAdpCh = CShort(.ThkMinCh + 0.49)
                Case 8
                    If .au_ThkAdpLR Then .ThkAdpLR = CShort(.ThkMinLR + 0.49)
                    If .NmaxFiletti < .NreqFiletti Then .NmaxFiletti = .NreqFiletti
                    If .ThkAdpCv < CShort(.ThkMinCv + 0.49) Then .ThkAdpCv = CShort(.ThkMinCv + 0.49)
                    If .ExtCrwAdpThk < CShort(.ExtCrwMinThk + 0.49) Then .ExtCrwAdpThk = CShort(.ExtCrwMinThk + 0.49)
            End Select
        End With
        AggText()
    End Sub
    Private Sub Fallimento(ByVal Index As Integer)
        Calcolato(Index) = False
        Labelcom1.Text = "Calcolo fallito a causa di insufficienti o erronei dati in ingresso"
    End Sub
    Private Sub cmdGuarn1_Click(ByVal Index As Integer)
        Select Case Index
            Case 0
                With objBre.Guarn
                    .Class = objBre.ClasGuarn1
                    .Tipo = objBre.TipoGuarn1
                    .Formula = objBre.Formula
                    .Face = objBre.Face1
                    .Scelta(Monitor.Motore.Inizio.Archdir, Monitor.Motore.Inizio.DiscoTem)
                    objBre.ClasGuarn1 = .Class
                    objBre.TipoGuarn1 = .Tipo
                    objBre.Formula = .Formula
                    objBre.FormulaS = .FormulaS
                    objBre.Face1 = .Face
                    objBre.m = .m
                    objBre.Y = .y
                    objBre.Gasket = .ClassS & " " & .TipoS
                End With
            Case 1
                With objBre.Guarn2
                    .Class = objBre.ClasGuarn2
                    .Tipo = objBre.TipoGuarn2
                    .Formula = objBre.Formula2
                    .Face = objBre.Face2
                    .Scelta(Monitor.Motore.Inizio.Archdir, Monitor.Motore.Inizio.DiscoTem)
                    objBre.ClasGuarn2 = .Class
                    objBre.TipoGuarn2 = .Tipo
                    objBre.Formula2 = .Formula
                    objBre.Formula2Sp = .FormulaS
                    objBre.Face2 = .Face
                    objBre.mGskChan = .m
                    objBre.YGskChan = .y
                    objBre.GskChan = .ClassS & " " & .TipoS
                End With
        End Select
        AggText()
    End Sub

    Private Sub cmdLibMat_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdLibMat.Click
        With objBre.Mater(Val(cmbMat.Tag))
            objmat.Agganciato = True
            objmat.Indmat = .IndMat
            objmat.Scelta(.Classe)
            If objmat.Indmat > 0 Then
                .Mat = objmat.MatStr
                .IndMat = objmat.Indmat
                AggiornaValori()
                .Classe = objmat.Classe
            End If
        End With
        AzioniMateriali()
    End Sub
    Private Sub AggiornaValori(Optional ByVal cod As Integer = 0)
        Dim Sfo, Sfa As Single
        Dim i, CodMat As Integer
        If cod = 0 Then
            CodMat = Val(cmbMat.Tag)
        Else
            CodMat = cod
            objmat.Indmat = objBre.Mater(CodMat).IndMat
            If objmat.Indmat = 0 Then Exit Sub
            objmat.RecupMat(Monitor.Motore.Inizio.Archdir)
        End If
        With objBre.Mater(CodMat)
            objmat.Agganciato = True
            For i = 0 To 8
                If i < 8 Then .Autom(i) = True
                txtMat(i).BackColor = Color.Yellow
            Next
            If .IndMat = 0 Then Exit Sub
            cmdRicalcola.Enabled = False
            SigmaAmm(.TempDes, Sfo, Sfa)
            .S = Sfo
            .S0 = Sfa
            Select Case CodMat
                Case BreLock.CodMAT.MAT_INTSCREWS, BreLock.CodMAT.MAT_EXTSCREWS
                    If modMain.optVitiSnerv Then
                        .S = Max(.S, .SY / 2)
                        .S0 = Max(.S0, .SY0 / 2)
                    End If
            End Select
            Select Case CodMat
                Case BreLock.CodMAT.MAT_CASSONETTO, BreLock.CodMAT.MAT_INSERTO, BreLock.CodMAT.MAT_INTSCREWS, BreLock.CodMAT.MAT_FL_CASSON, _
                     BreLock.CodMAT.MAT_SPLITRING, BreLock.CodMAT.MAT_PUSHRING, BreLock.CodMAT.MAT_EXTSCREWS, BreLock.CodMAT.MAT_LOCKRING, _
                     BreLock.CodMAT.MAT_COVER, BreLock.CodMAT.MAT_DIAFR
                    Snerv(.TempDes, Sfo, Sfa)
                    .SY = Sfo
                    .SY0 = Sfa
            End Select
            ' t1 = 1.8 * .TempDes + 32
            Select Case CodMat
                Case BreLock.CodMAT.MAT_CASSONETTO, BreLock.CodMAT.MAT_PUSHRING, BreLock.CodMAT.MAT_DIAFR, BreLock.CodMAT.MAT_CHANNEL, _
                     BreLock.CodMAT.MAT_LOCKRING, BreLock.CodMAT.MAT_DIAFR, BreLock.CodMAT.MAT_FL_CASSON
                    .E = objmat.EmodAlt(.TempDes) '/ PSI
                    .E0 = objmat.EmodAlt(20.0#) '/ PSI
            End Select
            Select Case CodMat
                Case BreLock.CodMAT.MAT_CASSONETTO, BreLock.CodMAT.MAT_CHANNEL, BreLock.CodMAT.MAT_LOCKRING, BreLock.CodMAT.MAT_DIAFR
                    .Alfa = objmat.AlfaTer(.TempDes)
            End Select
        End With
    End Sub
    Private Sub cmdRic_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdRic.Click
        Resetting = True
        AzioniMateriali()
        Resetting = False
    End Sub

    Private Sub cmdtir_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Dim Index As Short = IndexedControls.IndexOf(cmdtir, eventSender)
        Dim area As Single
        Dim Index1 As Integer
        With objBre
            Select Case Index
                Case 0
                    .Tir0.Xfil = .xFil1
                    .Tir0.DN = .DNStr1
                    .Tir0.Scelta(Monitor.Motore.Inizio.Archdir, Monitor.Motore.Inizio.DiscoTem)
                    If Not .Tir0.DN.Trim = .DNStr1.Trim Then Calcolato(3) = False
                    .DNStr1 = .Tir0.DN
                    .xFil1 = .Tir0.Xfil
                    .DNIntScr = .Tir0.Dnom
                    .BSmin1 = .Tir0.BSmin
                    area = .Tir0.Diam ^ 2 * PI / 4
                    .AreBltScr = area
                    If .AreExtension > area Then .AreExtension = area * 0.67
                    If modMain.optAutomEstensioni Then Me.cmdEstensioneAutomatica_Click(Me, New System.EventArgs)
                    InizIntScr3()
                    cmdCalc_Click(3)
                    Index1 = 3
                Case 1 'viti interne
                    .Tir1.Xfil = .xFil2
                    .Tir1.DN = .DNStr2
                    .Tir1.Scelta(Monitor.Motore.Inizio.Archdir, Monitor.Motore.Inizio.DiscoTem)
                    If Not .Tir1.DN.Trim = Trim(.DNStr2) Then Calcolato(7) = False
                    .DNStr2 = .Tir1.DN
                    .DNBltScr2 = .Tir1.Dnom
                    .AreBltScr2 = .Tir1.Diam ^ 2 * PI / 4
                    .xFil2 = .Tir1.Xfil
                    .DNIntPushBar2 = .Tir1.Dnom
                    .BSmin2 = .Tir1.BSmin
                    cmdCalc_Click(7)
                    Index1 = 7
                Case 2 'viti esterne
                    .Tir2.Xfil = .xFil3
                    .Tir2.DN = .DNStr3
                    .Tir2.Scelta(Monitor.Motore.Inizio.Archdir, Monitor.Motore.Inizio.DiscoTem)
                    If Not .Tir2.DN.Trim = Trim(.DNStr3) Then Calcolato(7) = False
                    .DNStr3 = .Tir2.DN
                    .AreExtScr = .Tir2.Diam ^ 2 * PI / 4
                    .xFil3 = .Tir2.Xfil
                    .DNExtScr = .Tir2.Dnom
                    .DPushBars = .Tir2.Dnom
                    .BSmin3 = .Tir2.BSmin
                    cmdCalc_Click(7)
                    Index1 = 7
            End Select
            If Not AggiornaViti(Index) Then Call Fallimento(Index1)
        End With
    End Sub

    'UPGRADE_WARNING: Form evento frmApert.Activate presenta un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
    Private Sub frmApert_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
        With objBre
            txtLR(20).Visible = .CalcDeltaT = 1
            txtLR(21).Visible = .CalcDeltaT = 1
            _Label_119.Visible = .CalcDeltaT = 1
            _Label_120.Visible = .CalcDeltaT = 1
            _lblMis_91.Visible = .CalcDeltaT = 1
            _lblMis_92.Visible = .CalcDeltaT = 1
        End With
    End Sub
    Private Sub Inizializza() 'frmApert_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Monitor.Motore.Problem.Extension = ".BRE"
        Monitor.Motore.Problem.TipoFile = "Calcolo scambiatori con chiusura Breech-Lock"
        Monitor.Motore.About.ProgName = "* BreLock * Breech-Lock type closures *"
        Monitor.Motore.About.ProgVers = myAssembly.GetName.Version.Major.ToString & "." & myAssembly.GetName.Version.Minor.ToString
        Dim Fi As IO.FileInfo = New IO.FileInfo(myAssembly.Location)
        Monitor.Motore.About.ProgDate = Format(Fi.CreationTime, "dd/MM/yy")
        Monitor.Motore.About.ProgDesc = "Heat Exchanger Mechanical Design"
        Monitor.Motore.About.Company = "Copyright (c) 2005 SSAP"
        Text = Text & " (Vers." & Monitor.Motore.About.ProgVers & ", " & Monitor.Motore.About.ProgDate & ")"
        NormalColor = System.Drawing.ColorTranslator.ToOle(framShell.BackColor)
        rtLogo.Top = 26
        rtLogo.BringToFront()
        rtLogo.Cursor = Nothing
        Labelcom1.Text = ""
        cmbStampa.Items.Add("Unità metriche")
        cmbStampa.Items.Add("Unità British")
        cmbStampa.Items.Add("Entrambe")
        ClickManuale = True
        InApertura = True
        ClickManuale = False
        ModifiedData = False
        rtLogo.LoadFile(Monitor.Motore.Inizio.Archdir & "\brelock.rtf")
        cmbTipoFil.Items.Clear()
        cmbTipoFil.Items.Add("0-Originale 15/16")
        cmbTipoFil.Items.Add("1-Stub ACME")
        cmbTipoFil.Items.Add("2-ACME")
        cmbPrecis.Items.Clear()
        cmbPrecis.Items.Add("IT 5")
        cmbPrecis.Items.Add("IT 6")
        cmbPrecis.Items.Add("IT 7")
        cmbPrecis.Items.Add("Dato")
        HelpProvider1.SetHelpString(Me.framHTDiff, HelpStringa(9001))
        HelpProvider1.SetHelpString(Me._Label_32, HelpStringa(9001))
        HelpProvider1.SetHelpString(Me._txtPT_7, HelpStringa(9001))
        HelpProvider1.SetHelpString(Me.txtSizeScr, HelpStringa(9007))
        HelpProvider1.SetHelpString(Me.framDiff, HelpStringa(9008))
        HelpProvider1.SetHelpString(Me._optDiff_0, HelpStringa(9008))
        HelpProvider1.SetHelpString(Me._optDiff_1, HelpStringa(9008))
        HelpProvider1.SetHelpString(Me._Label_122, HelpStringa(1022))
        HelpProvider1.SetHelpString(Me._txtVitiInt_6, HelpStringa(1022))
        HelpProvider1.SetHelpString(Me._Label_123, HelpStringa(1023))
        HelpProvider1.SetHelpString(Me._txtVitiInt_8, HelpStringa(1023))
        HelpProvider1.SetHelpString(Me._Label_32, HelpStringa(1025))
        HelpProvider1.SetHelpString(Me._txtPT_7, HelpStringa(1025))
        ToolTip1.SetToolTip(Me.framHTDiff, HelpStringa(9001))
        ToolTip1.SetToolTip(Me._Label_32, HelpStringa(9001))
        ToolTip1.SetToolTip(Me._txtPT_7, HelpStringa(9001))
        ToolTip1.SetToolTip(Me.txtSizeScr, HelpStringa(9007))
        ToolTip1.SetToolTip(Me.framDiff, HelpStringa(9008))
        ToolTip1.SetToolTip(Me._optDiff_0, HelpStringa(9008))
        ToolTip1.SetToolTip(Me._optDiff_1, HelpStringa(9008))
        ToolTip1.SetToolTip(Me._Label_122, HelpStringa(1022))
        ToolTip1.SetToolTip(Me._txtVitiInt_6, HelpStringa(1022))
        ToolTip1.SetToolTip(Me._Label_123, HelpStringa(1023))
        ToolTip1.SetToolTip(Me._txtVitiInt_8, HelpStringa(1023))
        ToolTip1.SetToolTip(Me._Label_32, HelpStringa(1025))
        ToolTip1.SetToolTip(Me._txtPT_7, HelpStringa(1025))
        HelpProvider1.HelpNamespace = RadiceHelp
        '------------------------------
        EP_txtPT_9 = New ErrorProvider
        EP_txtPT_9.SetIconAlignment(_txtPT_9, ErrorIconAlignment.MiddleLeft)
        EP_txtPT_9.SetIconPadding(_txtPT_9, 2)
        EP_txtPT_9.BlinkRate = 500
        EP_txtPT_9.BlinkStyle = ErrorBlinkStyle.AlwaysBlink
        EP_txtLR_5 = New ErrorProvider
        EP_txtLR_5.SetIconAlignment(_txtLR_5, ErrorIconAlignment.MiddleLeft)
        EP_txtLR_5.SetIconPadding(_txtLR_5, 2)
        EP_txtLR_5.BlinkRate = 500
        EP_txtLR_5.BlinkStyle = ErrorBlinkStyle.AlwaysBlink
        EP_txtLR_26 = New ErrorProvider
        EP_txtLR_26.SetIconAlignment(_txtLR_26, ErrorIconAlignment.MiddleLeft)
        EP_txtLR_26.SetIconPadding(_txtLR_26, 2)
        EP_txtLR_26.BlinkRate = 500
        EP_txtLR_26.BlinkStyle = ErrorBlinkStyle.AlwaysBlink
        EP_txtSplit_0 = New ErrorProvider
        EP_txtSplit_0.SetIconAlignment(_txtSplit_0, ErrorIconAlignment.MiddleLeft)
        EP_txtSplit_0.SetIconPadding(_txtSplit_0, 2)
        EP_txtSplit_0.BlinkRate = 500
        EP_txtSplit_0.BlinkStyle = ErrorBlinkStyle.AlwaysBlink
        EP_txtSplit_1 = New ErrorProvider
        EP_txtSplit_1.SetIconAlignment(_txtSplit_1, ErrorIconAlignment.MiddleLeft)
        EP_txtSplit_1.SetIconPadding(_txtSplit_1, 2)
        EP_txtSplit_1.BlinkRate = 500
        EP_txtSplit_1.BlinkStyle = ErrorBlinkStyle.AlwaysBlink
        EP_txtSplit_3 = New ErrorProvider
        EP_txtSplit_3.SetIconAlignment(_txtSplit_3, ErrorIconAlignment.MiddleLeft)
        EP_txtSplit_3.SetIconPadding(_txtSplit_3, 2)
        EP_txtSplit_3.BlinkRate = 500
        EP_txtSplit_3.BlinkStyle = ErrorBlinkStyle.AlwaysBlink
        EP_txtSplit_4 = New ErrorProvider
        EP_txtSplit_4.SetIconAlignment(_txtSplit_4, ErrorIconAlignment.MiddleLeft)
        EP_txtSplit_4.SetIconPadding(_txtSplit_4, 2)
        EP_txtSplit_4.BlinkRate = 500
        EP_txtSplit_4.BlinkStyle = ErrorBlinkStyle.AlwaysBlink
        EP_txtSplit_5 = New ErrorProvider
        EP_txtSplit_5.SetIconAlignment(_txtSplit_5, ErrorIconAlignment.MiddleLeft)
        EP_txtSplit_5.SetIconPadding(_txtSplit_5, 2)
        EP_txtSplit_5.BlinkRate = 500
        EP_txtSplit_5.BlinkStyle = ErrorBlinkStyle.AlwaysBlink
        EP_txtSplit_6 = New ErrorProvider
        EP_txtSplit_6.SetIconAlignment(_txtSplit_6, ErrorIconAlignment.MiddleLeft)
        EP_txtSplit_6.SetIconPadding(_txtSplit_6, 2)
        EP_txtSplit_6.BlinkRate = 500
        EP_txtSplit_6.BlinkStyle = ErrorBlinkStyle.AlwaysBlink
        EP_txtSplit_8 = New ErrorProvider
        EP_txtSplit_8.SetIconAlignment(_txtSplit_8, ErrorIconAlignment.MiddleLeft)
        EP_txtSplit_8.SetIconPadding(_txtSplit_8, 2)
        EP_txtSplit_8.BlinkRate = 500
        EP_txtSplit_8.BlinkStyle = ErrorBlinkStyle.AlwaysBlink
        EP_txtCasson_0 = New ErrorProvider
        EP_txtCasson_0.SetIconAlignment(_txtCasson_0, ErrorIconAlignment.MiddleLeft)
        EP_txtCasson_0.SetIconPadding(_txtCasson_0, 2)
        EP_txtCasson_0.BlinkRate = 500
        EP_txtCasson_0.BlinkStyle = ErrorBlinkStyle.AlwaysBlink
        EP_txtCasson_1 = New ErrorProvider
        EP_txtCasson_1.SetIconAlignment(_txtCasson_1, ErrorIconAlignment.MiddleLeft)
        EP_txtCasson_1.SetIconPadding(_txtCasson_1, 2)
        EP_txtCasson_1.BlinkRate = 500
        EP_txtCasson_1.BlinkStyle = ErrorBlinkStyle.AlwaysBlink
        EP_txtCasson_2 = New ErrorProvider
        EP_txtCasson_2.SetIconAlignment(_txtCasson_2, ErrorIconAlignment.MiddleLeft)
        EP_txtCasson_2.SetIconPadding(_txtCasson_2, 2)
        EP_txtCasson_2.BlinkRate = 500
        EP_txtCasson_2.BlinkStyle = ErrorBlinkStyle.AlwaysBlink
        EP_txtCasson_4 = New ErrorProvider
        EP_txtCasson_4.SetIconAlignment(_txtCasson_4, ErrorIconAlignment.MiddleLeft)
        EP_txtCasson_4.SetIconPadding(_txtCasson_4, 2)
        EP_txtCasson_4.BlinkRate = 500
        EP_txtCasson_4.BlinkStyle = ErrorBlinkStyle.AlwaysBlink
        EP_txtCasson_5 = New ErrorProvider
        EP_txtCasson_5.SetIconAlignment(_txtCasson_5, ErrorIconAlignment.MiddleLeft)
        EP_txtCasson_5.SetIconPadding(_txtCasson_5, 2)
        EP_txtCasson_5.BlinkRate = 500
        EP_txtCasson_5.BlinkStyle = ErrorBlinkStyle.AlwaysBlink
        EP_txtCasson_3 = New ErrorProvider
        EP_txtCasson_3.SetIconAlignment(_txtCasson_3, ErrorIconAlignment.MiddleLeft)
        EP_txtCasson_3.SetIconPadding(_txtCasson_3, 2)
        EP_txtCasson_3.BlinkRate = 500
        EP_txtCasson_3.BlinkStyle = ErrorBlinkStyle.AlwaysBlink
        EP_txtCasson_13 = New ErrorProvider
        EP_txtCasson_13.SetIconAlignment(_txtCasson_13, ErrorIconAlignment.MiddleLeft)
        EP_txtCasson_13.SetIconPadding(_txtCasson_13, 2)
        EP_txtCasson_13.BlinkRate = 500
        EP_txtCasson_13.BlinkStyle = ErrorBlinkStyle.AlwaysBlink
        EP_txtShell_2 = New ErrorProvider
        EP_txtShell_2.SetIconAlignment(_txtShell_2, ErrorIconAlignment.MiddleLeft)
        EP_txtShell_2.SetIconPadding(_txtShell_2, 2)
        EP_txtShell_2.BlinkRate = 500
        EP_txtShell_2.BlinkStyle = ErrorBlinkStyle.AlwaysBlink
        EP_txtShell_4 = New ErrorProvider
        EP_txtShell_4.SetIconAlignment(_txtShell_4, ErrorIconAlignment.MiddleLeft)
        EP_txtShell_4.SetIconPadding(_txtShell_4, 2)
        EP_txtShell_4.BlinkRate = 500
        EP_txtShell_4.BlinkStyle = ErrorBlinkStyle.AlwaysBlink
        EP_txtShell_16 = New ErrorProvider
        EP_txtShell_16.SetIconAlignment(_txtShell_16, ErrorIconAlignment.MiddleLeft)
        EP_txtShell_16.SetIconPadding(_txtShell_16, 2)
        EP_txtShell_16.BlinkRate = 500
        EP_txtShell_16.BlinkStyle = ErrorBlinkStyle.AlwaysBlink
        EP_txtShell_18 = New ErrorProvider
        EP_txtShell_18.SetIconAlignment(_txtShell_18, ErrorIconAlignment.MiddleLeft)
        EP_txtShell_18.SetIconPadding(_txtShell_18, 2)
        EP_txtShell_18.BlinkRate = 500
        EP_txtShell_18.BlinkStyle = ErrorBlinkStyle.AlwaysBlink
        EP_txtchan_0 = New ErrorProvider
        EP_txtchan_0.SetIconAlignment(_txtchan_0, ErrorIconAlignment.MiddleLeft)
        EP_txtchan_0.SetIconPadding(_txtchan_0, 2)
        EP_txtchan_0.BlinkRate = 500
        EP_txtchan_0.BlinkStyle = ErrorBlinkStyle.AlwaysBlink
        EP_txtchan_3 = New ErrorProvider
        EP_txtchan_3.SetIconAlignment(_txtchan_3, ErrorIconAlignment.MiddleLeft)
        EP_txtchan_3.SetIconPadding(_txtchan_3, 2)
        EP_txtchan_3.BlinkRate = 500
        EP_txtchan_3.BlinkStyle = ErrorBlinkStyle.AlwaysBlink
        EP_txtchan_4 = New ErrorProvider
        EP_txtchan_4.SetIconAlignment(_txtchan_4, ErrorIconAlignment.MiddleLeft)
        EP_txtchan_4.SetIconPadding(_txtchan_4, 2)
        EP_txtchan_4.BlinkRate = 500
        EP_txtchan_4.BlinkStyle = ErrorBlinkStyle.AlwaysBlink
        EP_txtchan_12 = New ErrorProvider
        EP_txtchan_12.SetIconAlignment(_txtChan_12, ErrorIconAlignment.MiddleLeft)
        EP_txtchan_12.SetIconPadding(_txtChan_12, 2)
        EP_txtchan_12.BlinkRate = 500
        EP_txtchan_12.BlinkStyle = ErrorBlinkStyle.AlwaysBlink
        EP_txtViti_2 = New ErrorProvider
        EP_txtViti_2.SetIconAlignment(_txtViti_2, ErrorIconAlignment.MiddleLeft)
        EP_txtViti_2.SetIconPadding(_txtViti_2, 2)
        EP_txtViti_2.BlinkRate = 500
        EP_txtViti_2.BlinkStyle = ErrorBlinkStyle.AlwaysBlink
        EP_txtVitiInt_10 = New ErrorProvider
        EP_txtVitiInt_10.SetIconAlignment(_txtVitiInt_10, ErrorIconAlignment.MiddleLeft)
        EP_txtVitiInt_10.SetIconPadding(_txtVitiInt_10, 2)
        EP_txtVitiInt_10.BlinkRate = 500
        EP_txtVitiInt_10.BlinkStyle = ErrorBlinkStyle.AlwaysBlink
        EP_txtVitiExt_10 = New ErrorProvider
        EP_txtVitiExt_10.SetIconAlignment(_txtVitiExt_10, ErrorIconAlignment.MiddleLeft)
        EP_txtVitiExt_10.SetIconPadding(_txtVitiExt_10, 2)
        EP_txtVitiExt_10.BlinkRate = 500
        EP_txtVitiExt_10.BlinkStyle = ErrorBlinkStyle.AlwaysBlink
        '--------------------------------------------------------
        Dim i, j As Integer
        ReDim pages8(TabStrip1.TabPages.Count - 1)
        ReDim Pages4(4)
        For i = 0 To TabStrip1.TabPages.Count - 1
            pages8(i) = TabStrip1.TabPages(i)
            Select Case i
                Case 0, 2, 6, 7, 8
                    Pages4(j) = TabStrip1.TabPages(i)
                    j += 1
            End Select
        Next
        Me.rtLogo.Visible = Not DaASME
        Me._optTipo_0.Enabled = Not DaASME
        Me._optTipo_1.Enabled = Not DaASME
        framNorme.Visible = Not DaASME
        Me.mennuovo.Enabled = Not DaASME
        Me.menChiudi.Enabled = Not DaASME
        Me.menSalva.Enabled = Not DaASME
        Me.menstampa.Enabled = Not DaASME
        Me.StatusBar1.Visible = Not DaASME
        If DaASME Then
            Me.menapri.Text = "Importa ..."
            Me.menSalvaCome.Text = "Esporta ..."
            Me.menEsci.Text = "Torna ad AsmeVip"
        Else
            Me.menapri.Text = "Apri"
            Me.menSalvaCome.Text = "Salva come ..."
            Me.menEsci.Text = "Esci"
        End If
        Aggiorna()
        InApertura = False
    End Sub
    Private Sub Inizializza1()
        If Monitor.Motore.Inizio.ReadIniFile("", "Preferenze BreLock", "Verifica cassonetto a buckling") = "Si" Then
            mnuPrefBuckling.CheckState = CheckState.Checked
        Else
            mnuPrefBuckling.CheckState = CheckState.Unchecked
        End If
        If Monitor.Motore.Inizio.ReadIniFile("", "Preferenze BreLock", "Verifica viti a snervamento") = "Si" Then
            mnuVitiSnerv.CheckState = CheckState.Checked
        Else
            mnuVitiSnerv.CheckState = CheckState.Unchecked
        End If
        If Monitor.Motore.Inizio.ReadIniFile("", "Preferenze BreLock", "Calcolo automatico estensioni") = "Si" Then
            mnuAutomEstensioni.CheckState = CheckState.Checked
        Else
            mnuAutomEstensioni.CheckState = CheckState.Unchecked
        End If
        If Monitor.Motore.Inizio.ReadIniFile("", "Preferenze BreLock", "Calcolo automatico viti") = "Si" Then
            Me.menVitiAutomatiche.CheckState = CheckState.Checked
        Else
            Me.menVitiAutomatiche.CheckState = CheckState.Unchecked
        End If

    End Sub
    Public Sub menapri_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles menapri.Click
        If ModifiedData Then DomSalva()
        Azzera()
        framMat.Visible = False
        cmbMat.SelectedIndex = -1
        cmdSel.Visible = True
        If Monitor.Motore.Inizio.LavoriSciolti Then
            If Not Monitor.Motore.Mostra(myAssembly, 2) Then Exit Sub
        Else
            Stop
        End If
        rtLogo.Visible = False
        cmdRicalcola.Enabled = False
        CheckAutomatismi()
        With objBre
            If .Guarn Is Nothing Then
                .Guarn = New LibMat.clsGuarn
                .Guarn2 = New LibMat.clsGuarn
                .Tir0 = New LibMat.clsTira
                .Tir1 = New LibMat.clsTira
                .Tir2 = New LibMat.clsTira
            End If
        End With
    End Sub
    Friend Sub CheckAutomatismi()
        Dim Qualche As Boolean = False
        With objBre
            Dim Sporg As Single = .lbSporgenzaSplitRing
            If Not .au_IDSplitRing Then
                Me._txtSplit_1.BackColor = Color.LightPink
                If .IDSplitRing < .IDChan - 2 * Sporg - 2 Then
                    EP_txtSplit_1.SetError(_txtSplit_1, String.Format(HelpStringa(1002), Sporg, .IDChan))
                ElseIf .IDSplitRing > .IDChan - 2 * Sporg + 2 Then
                    EP_txtSplit_1.SetError(_txtSplit_1, String.Format(HelpStringa(1003), Sporg, .IDChan))
                Else
                    EP_txtSplit_1.SetError(_txtSplit_1, "")
                End If
                Qualche = True
            End If
            If Not .au_ThkAdpFC Then
                Me._txtCasson_13.BackColor = Color.LightPink
                If .ThkAdpFC < CShort(.ThkMinFC + 0.49) Then
                    EP_txtCasson_13.SetError(_txtCasson_13, HelpStringa(1042))
                End If
                Qualche = True
            End If
            If Not .au_MaxDCasson Then
                Me._txtCasson_3.BackColor = Color.LightPink
                If .MaxDCasson - .ThkCasson < .IDShell Then
                    EP_txtCasson_3.SetError(_txtCasson_3, HelpStringa(1011))
                ElseIf .MaxDCasson + .ThkCasson > .G1out + 2 * .G1AnExt Then
                    EP_txtCasson_3.SetError(_txtCasson_3, HelpStringa(1012))
                End If
                Qualche = True
            End If
            If Not .au_MinDCasson Then
                Me._txtCasson_4.BackColor = Color.LightPink
                If .MinDCasson < .BCIntScr - 2 Then
                    EP_txtCasson_4.SetError(_txtCasson_4, HelpStringa(1011))
                ElseIf .MinDCasson > .MaxDCasson And .TipoCassonetto = TipiCassonetto.Conico Then
                    EP_txtCasson_4.SetError(_txtCasson_4, HelpStringa(1012))
                ElseIf .MinDCasson > .BCIntScr + 2 And .TipoCassonetto = TipiCassonetto.CilindricoInLinea Then
                    EP_txtCasson_4.SetError(_txtCasson_4, HelpStringa(1047))
                    .au_MinDCasson = False
                    _txtCasson_4.BackColor = Color.LightPink
                End If
                Qualche = True
            End If
            If Not .au_BCIntScr Then
                _txtViti_2.BackColor = Color.LightPink
                Dim BC As Single = CInt(BCIntScrMin())
                If .BCIntScr < BC - 2 Then
                    EP_txtViti_2.SetError(_txtViti_2, String.Format(HelpStringa(1045), BC))
                ElseIf .BCIntScr > BC + 2 Then
                    EP_txtViti_2.SetError(_txtViti_2, String.Format(HelpStringa(1046), BC))
                End If
                Qualche = True
            End If
            If Not .au_ThkAdpSplitRing Then
                _txtSplit_6.BackColor = Color.LightPink
                If .ThkAdpSplitRing < .ThkReqSplitRing Then
                    EP_txtSplit_6.SetError(_txtSplit_6, HelpStringa(1044))
                End If
                Qualche = True
            End If
            If Not .au_ThkAdpInnerRing Then
                _txtSplit_5.BackColor = Color.LightPink
                If .ThkAdpInnerRing < .ThkReqInnerRing Then
                    EP_txtSplit_5.SetError(_txtSplit_5, HelpStringa(1044))
                End If
                Qualche = True
            End If
            If Not .au_ThkAdpLR Then
                _txtLR_5.BackColor = Color.LightPink
                If .ThkAdpLR < .ThkMinLR Then
                    EP_txtLR_5.SetError(_txtLR_5, HelpStringa(1044))
                End If
                Qualche = True
            End If
            If Not .au_DiamIntGola Then
                _txtLR_26.BackColor = Color.LightPink
                Dim ProfCava As Single = .lbProfCavaThreadedEnd
                If .DiamIntGola < .Filetto.DMaxCas + 2 * ProfCava - 1 Then
                    EP_txtLR_26.SetError(_txtLR_26, String.Format(HelpStringa(1048), ProfCava, .Filetto.DMaxCas))
                ElseIf .DiamIntGola > .Filetto.DMaxCas + 2 * ProfCava + 1 Then
                    EP_txtLR_26.SetError(_txtLR_26, String.Format(HelpStringa(1049), ProfCava, .Filetto.DMaxCas))
                Else
                    EP_txtLR_26.SetError(_txtLR_26, "")
                End If
                Qualche = True
            End If
            If Not .au_ODInnerRing Then
                _txtSplit_3.BackColor = Color.LightPink
                Dim Vecchio As Single = modMain.Val_ODInnerRing
                If .ODInnerRing < Vecchio - 2 Then
                    EP_txtSplit_3.SetError(_txtSplit_3, String.Format(HelpStringa(1006), Vecchio))
                ElseIf .ODInnerRing > Vecchio + 2 Then
                    EP_txtSplit_3.SetError(_txtSplit_3, String.Format(HelpStringa(1007), Vecchio))
                Else
                    EP_txtSplit_3.SetError(_txtSplit_3, "")
                End If
                Qualche = True
            End If
            If Not .au_IDInnerRing Then
                _txtSplit_4.BackColor = Color.LightPink
                Dim ID As Single = modMain.IDInnerRingOpt
                If .IDInnerRing < ID - 2 Then
                    EP_txtSplit_4.SetError(_txtSplit_4, String.Format(HelpStringa(1004), ID))
                ElseIf .IDInnerRing > ID + 2 Then
                    EP_txtSplit_4.SetError(_txtSplit_4, String.Format(HelpStringa(1005), ID))
                Else
                    EP_txtSplit_4.SetError(_txtSplit_4, "")
                End If
                Qualche = True
            End If
        End With
        If Qualche Then
            MostraAiuto(1043, ChiaviMess.MessExclamation Or _
                              ChiaviMess.MessHelpButton Or _
                              ChiaviMess.MessOkOnly, mioTitolo:="BreLock - Messaggi di avvertimento")
            Me.mnuCalcGeomAuto.Enabled = True
        Else
            Me.mnuCalcGeomAuto.Enabled = False
        End If

    End Sub
    Public Sub menEsci_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles menEsci.Click
        menChiudi_Click(Me, New System.EventArgs)
        Hide()
        If Not Monitor Is Nothing Then
            If Not Monitor.Motore Is Nothing Then Monitor.Motore.Ammazza("BREL")
        End If
        Dispose()
    End Sub
    Private Sub SalvaCome()
        'If Monitor.Motore.Inizio.LavoriSciolti Then
        With CommonDialog2
            .Filter = "Progetti Breech-Lock (*.BRE)|*.BRE"
            .InitialDirectory = Monitor.Motore.Inizio.Datidir
            .AddExtension = True
            Try
                .ShowDialog()
            Catch e As Exception
                Exit Sub
            End Try
            nomefile = .FileName
        End With
        'Else
        'MessageBox.Show("Funzione non implementata per lavori a commessa")
        'End If
        scrivi()
        ModifiedData = False
        Aggiorna()
    End Sub
    Public Sub mennuovo_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mennuovo.Click
        menChiudi_Click(Me, New System.EventArgs)
        rtLogo.Visible = False
        framMat.Visible = False
        cmbMat.SelectedIndex = -1
        cmdSel.Visible = True
        Azzera()
        TabStrip1.SelectedIndex = 0 ' 1 ' TabStrip1.Tabs(1)
        AggText()
        Aggiorna()
    End Sub
    Public Sub menSalva_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles menSalva.Click
        If Not scrivi() Then
            MostraAiuto(1041)
            Exit Sub
        End If
        ModifiedData = False
        Aggiorna()
    End Sub
    Public Sub menstampa_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles menstampa.Click
        stampa()
    End Sub

    Public Sub mnuAnn_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuAnn.Click
        Azzera()
        TabStrip1.SelectedIndex = 0 ' 1 ' TabStrip1.Tabs(1)
    End Sub
    Public Sub mnuGuiBre_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuGuiBre.Click
        Help.ShowHelp(Me, RadiceHelp, HelpNavigator.TableOfContents)
    End Sub
    Public Sub mnuInf_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuInf.Click
        Monitor.Motore.Informazioni(Me, myAssembly)  ',Versione,Desc,Disc
    End Sub
    Private Sub Text_KeyPress(ByRef Index As Short, ByRef KeyAscii As Short)
        'Dim t As TextBox
        'Select Case KeyAscii
        '   Case vbKeyReturn
        '     For Each t In Text
        '       If t.TabStop And t.TabIndex = Text(Index).TabIndex + 1 Then
        '          On Error GoTo Res
        '          t.SetFocus
        '          Exit Sub
        '       End If
        '     Next
        'End Select
        'Exit Sub
        'ExS: Text(0).SetFocus
        'Exit Sub
        'Res: Resume ExS
    End Sub

    Private Sub Text_LostFocus(ByRef Index As Short)
        'UPGRADE_ISSUE: Impossibile risolvere Control Name poiché si trova all'interno dello spazio dei nomi generico ActiveControl. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
        If Not ActiveControl.Name = "Text" Then Exit Sub
        If Antiripeti Then Exit Sub
        With objBre
            Select Case Index
                Case 0
                    '  SigmaAmm
                    'calcolo
                    Antiripeti = True
                    AggText()
                    Antiripeti = False
                Case 1, 2, 3, 5, 6, 8, 9, 12, 13, 14, 15, 17, 30
                    'calcolo
                    Antiripeti = True
                    AggText()
                    Antiripeti = False
                Case 18, 19
                    'calcol1
                    Antiripeti = True
                    AggText()
                    Antiripeti = False
                Case 20 To 24
                    'Calcol2
                    Antiripeti = True
                    AggText()
                    Antiripeti = False
                Case 10, 11, 26, 27, 28
                    'Calcol3
                    Antiripeti = True
                    AggText()
                    Antiripeti = False
            End Select
        End With

    End Sub
    Private Function Esiste(ByVal Ind As Integer) As Boolean
        If objBre.TipoBL = 1 Then Return True
        Select Case Ind
            Case 1, 3, 4, 5 : Return False
            Case Else : Return True
        End Select
    End Function
    Private Sub TabStrip1_ClickEvent(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TabStrip1.SelectedIndexChanged
        If Aggiornando Then Exit Sub
        Dim Ind As Short
        Dim t As TabPage
        Dim IndR As Short
        Storia = Storia + 1
        With TabStrip1
            Ind = .SelectedIndex ' - 1
            If Not .Enabled Then Exit Sub
            HelpProvider1.SetHelpKeyword(TabStrip1, Monitor.HelpTopic(IDH_BASE_TAB + Espandi(Ind)))
            '            .HelpContextID = IDH_BASE_TAB + Ind
            If .TabPages(Ind).Text = "i" Then
                If Ind < .TabPages.Count - 1 Then
                    .SelectedIndex = Ind + 1 ' .Tabs(Ind + 2)
                Else
                    .SelectedIndex = 0 ' .Tabs(1)
                End If
            End If
            Select Case Espandi(Ind)
                Case 1
                    If objBre.TipoBL = 1 Then InizShell()
                Case 2 'PT
                    InizChan2()
                    GuardaIndietro(Ind, IndR)
                Case 3 'viti interne
                    GuardaIndietro(Ind, IndR)
                    InizIntScr3()
                Case 4 'anelli
                    GuardaIndietro(Ind, IndR)
                    InizChan2()
                    InizAnelli4()
                Case 5 'cassonetto
                    GuardaIndietro(Ind, IndR)
                    InizCassonetto5()
                Case 6 'cassa
                    GuardaIndietro(Ind, IndR)
                    InizChan2()
                Case 7 'viti esterne
                    GuardaIndietro(Ind, IndR)
                    InizScrews7()
                Case 8 'Lock ring
                    GuardaIndietro(Ind, IndR)
                    InizLR8()
            End Select
            If Ind > 1 Then
                ' If Not Calcolato(Ind - 1) And Esiste(Ind - 1) Then Exit Sub
                If Not Calcolato(Espandi(Ind - 1)) Then Exit Sub
            End If
            Storia = Storia - 1
            If Storia = 0 Then
                If Not vecchiotab Is Nothing Then
                    If Esito Then
                        t = vecchiotab
                        vecchiotab = Nothing
                        .SelectedTab = t
                    Else
                        vecchiotab = Nothing
                        If IndR > 0 Then
                            .SelectedIndex = IndR '.Tabs(IndR)
                        Else
                            '    For Each p In pctFrames
                            ' p.Top = VB6.TwipsToPixelsY(9000)
                            ' Next p
                            ' pctFrames(.SelectedIndex - 1).Top = VB6.TwipsToPixelsY(960)
                        End If
                    End If
                End If
            End If
        End With
        Aggiorna()
        If Ind = 0 Then cmbMat.SelectedIndex = iMat
    End Sub
    Friend Sub GuardaIndietro(ByVal Ind As Short, ByRef IndR As Short)
        With TabStrip1
            If Storia = 1 Then
                vecchiotab = .SelectedTab
                'Storia = 0
                Esito = True
            Else
                If Not Esito Then
                    IndR = .SelectedIndex
                    Exit Sub
                End If
            End If
            If Not Calcolato(Espandi(Ind - 1)) Then
                Aggiornando = True
                .SelectedIndex = Ind - 1
                Aggiornando = False
                TabStrip1_ClickEvent(Me, Nothing)
                cmdCalc_Click(Ind - 1)
            End If
        End With
    End Sub
    Public Sub converti(ByRef univecchio As Short, ByRef uninuovo As Short)
        'Dim c As TextBox
        'For Each c In Text
        '   If Len(c.Tag) > 0 Then
        '   Select Case uninuovo
        '     Case 1: lblMis(c.Index) = colSI(c.Tag)
        '     Case 2: lblMis(c.Index) = colTec(c.Tag)
        '     Case 3: lblMis(c.Index) = colBR(c.Tag)
        '   End Select
        '   If c.Tag = "t" Then
        '      If uninuovo <> univecchio Then
        '        If univecchio = 3 Then
        '          Text(c.Index) = Str((Val(Text(c.Index)) - 32) / 1.8)
        '        ElseIf uninuovo = 3 Then
        '        Text(c.Index) = Str((Val(Text(c.Index)) * 1.8) + 32)
        '      End If
        '   End If
        '   Else
        '   Text(c.Index) = Str(Val(Text(c.Index)) / colConv(c.Tag)(univecchio) * colConv(c.Tag)(uninuovo))
        '   End If
        '   End If
        'Next
    End Sub
    Private ReadOnly Property optTipo(ByVal i As Integer) As RadioButton
        Get
            Select Case i
                Case 0 : Return _optTipo_0
                Case 1 : Return _optTipo_1
                Case Else : Return Nothing
            End Select
        End Get
    End Property
    Private ReadOnly Property optPlastic(ByVal i As Integer) As RadioButton
        Get
            Select Case i
                Case 0 : Return _optPlastic_0
                Case 1 : Return _optPlastic_1
                Case Else : Return Nothing
            End Select
        End Get
    End Property
    Public Sub Aggiorna()
        Dim Testo As String
        StatusBar1.Items(0).Text = "Area di lavoro: " & RTrim(Monitor.Motore.Inizio.Datidir)
        If nomefile Is Nothing Then
            Testo = "nessuno"
        ElseIf nomefile = "" Then
            Testo = "nessuno"
        Else
            Testo = IO.Path.GetFileName(nomefile)
        End If
        Testo = " File corrente = " & Testo
        StatusBar1.Items(1).Text = Testo
        Testo = " Item = " & objBre.Item
        StatusBar1.Items(2).Text = Testo
        With objBre
            optTipo(.TipoBL).Checked = True
            optDiff(.Ipres).Checked = True
            optPlastic(.Considera).Checked = True
            If .iPasso = 0 Then .iPasso = 1
            optPasso(.iPasso - 1).Checked = True
            cmbStampa.SelectedIndex = .iStampa - 1
            Select Case LibMat.Codes.div1MPa
                Case LibMat.Codes.div1MPa
                    optdiv1.Checked = True
                Case LibMat.Codes.div2MPa
                    optdiv2.Checked = True
                Case Else
                    optdiv3.Checked = True
            End Select
            Me.optdiv1.Checked = .Norme = LibMat.Codes.div1MPa
            Me.cmbTipoCassonetto.SelectedIndex = .TipoCassonetto
        End With
        AggMateriali()
        AggText()
    End Sub
    Private ReadOnly Property optDiff(ByVal i As Integer) As RadioButton
        Get
            Select Case i
                Case 0 : Return _optDiff_0
                Case 1 : Return _optDiff_1
                Case Else : Return Nothing
            End Select
        End Get
    End Property
    Private Function Espandi(ByVal ind As Integer) As Integer
        If objBre.TipoBL = 1 Then Return ind
        Select Case ind
            Case 0 : Return 0
            Case 1 : Return 2
            Case Else : Return ind + 4
        End Select
    End Function
    Private Function EspandiInv(ByVal ind As Integer) As Integer
        If objBre.TipoBL = 1 Then Return ind
        Select Case ind
            Case 0 : Return 0
            Case 2 : Return 1
            Case Else : Return ind - 4
        End Select
    End Function
    Public Sub AggText(Optional ByVal t As TextBox = Nothing)
        Dim Ind As Short
        Ind = TabStrip1.SelectedIndex '+ 1
        If Ind = -1 Then Ind = 0
        Aggiornando = True
        If t Is Nothing Then t = _txtDes_0
        Ind = Espandi(Ind) + 1
        With objBre
            Select Case Ind
                Case 1
                    txtDes(0).Text = GlobalRoutines.myStr(.DesTempSS, 4, 2, False)
                    txtDes(1).Text = GlobalRoutines.myStr(.DesPresSS, 4, 2, False)
                    txtDes(2).Text = GlobalRoutines.myStr(.DesTempTS, 4, 2, False)
                    txtDes(3).Text = GlobalRoutines.myStr(.DesPresTS, 4, 2, False)
                    txtDes(4).Text = GlobalRoutines.myStr(.DiffPres, 4, 2, False)
                    txtDes(5).Text = GlobalRoutines.myStr(.P2idr, 4, 2, False)
                    '--------------------------------------------
                Case 2
                    If Not t.Equals(_txtShell_0) Then _txtShell_0.Text = GlobalRoutines.myStr(.IDShell, 4, 2, False)
                    If Not t.Equals(_txtShell_1) Then _txtShell_1.Text = GlobalRoutines.myStr(.CorrSh, 3, 2, False)
                    If Not t.Equals(_txtShell_10) Then _txtShell_10.Text = GlobalRoutines.myStr(.ThkMinSh, 4, 2, False)
                    If Not t.Equals(_txtShell_11) Then _txtShell_11.Text = GlobalRoutines.myStr(.ThkAdpSh, 4, 2, False)
                    If Not t.Equals(_txtShell_3) Then _txtShell_3.Text = .Gasket
                    If Not t.Equals(_txtShell_2) Then _txtShell_2.Text = GlobalRoutines.myStr(.G1out, 4, 2, False)
                    If Not t.Equals(_txtShell_4) Then _txtShell_4.Text = GlobalRoutines.myStr(.G1N, 4, 2, False)
                    If Not t.Equals(_txtShell_5) Then _txtShell_5.Text = GlobalRoutines.myStr(.Nubbin, 4, 2, False)
                    If Not t.Equals(_txtShell_6) Then _txtShell_6.Text = GlobalRoutines.myStr(.m, 4, 2, False)
                    If Not t.Equals(_txtShell_7) Then _txtShell_7.Text = GlobalRoutines.myStr(.Y, 6, 0, False)
                    If Not t.Equals(_txtShell_8) Then _txtShell_8.Text = .FormulaS
                    If Not t.Equals(_txtShell_9) Then _txtShell_9.Text = GlobalRoutines.myStr(.B1, 3, 3, False)
                    If Not objBre.NonCalcolaFondo Then
                        If Not t.Equals(_txtShell_13) Then _txtShell_13.Text = GlobalRoutines.myStr(.ThkMinHe, 4, 2, False)
                        If Not t.Equals(_txtShell_12) Then _txtShell_12.Text = GlobalRoutines.myStr(.ThkAdpHe, 4, 2, False)
                        If Not t.Equals(_txtShell_14) Then _txtShell_14.Text = GlobalRoutines.myStr(.CorrSh, 4, 2, False)
                        If Not t.Equals(_txtShell_15) Then _txtShell_15.Text = GlobalRoutines.myStr(.HemRadius, 4, 2, False)
                        If Not t.Equals(_txtShell_16) Then _txtShell_16.Text = GlobalRoutines.myStr(.G1AnInt, 4, 2, False)
                    Else
                        _txtShell_13.Text = "N.A."
                        _txtShell_12.Text = "N.A."
                        _txtShell_14.Text = "N.A."
                        _txtShell_15.Text = "N.A."
                        _txtShell_16.Text = "N.A."
                    End If
                    If Not t.Equals(_txtShell_17) Then _txtShell_17.Text = GlobalRoutines.myStr(.G1AnExt, 4, 2, False)
                    chkNonCalcolaFondo.Checked = .NonCalcolaFondo
                    chkAnelloEst.Checked = .G1AnExt > 0
                    chkAnelloInt.Checked = .G1AnInt > 0
                    chkAnelloEst_CheckedChanged(Me, New EventArgs)
                    chkAnelloInt_CheckedChanged(Me, New EventArgs)
                    If Not t.Equals(_txtShell_18) Then _txtShell_18.Text = GlobalRoutines.myStr(.G1dente, 4, 2, False)
                    '---------------------------------------------
                Case 3
                    txtPT(0).Text = GlobalRoutines.myStr(.TubeDout, 2, 3, False)
                    txtPT(1).Text = GlobalRoutines.myStr(.Passo, 2, 3, False)
                    txtPT(2).Text = GlobalRoutines.myStr(.CorrTSCh, 3, 2, False)
                    txtPT(3).Text = GlobalRoutines.myStr(.CorrTSSh, 3, 2, False)
                    txtPT(4).Text = GlobalRoutines.myStr(.Cava, 3, 2, False)
                    txtPT(5).Text = GlobalRoutines.myStr(.ThkMinTS, 3, 2, False)
                    txtPT(6).Text = GlobalRoutines.myStr(.ThkAdpTS, 3, 2, False)
                    txtPT(7).Text = GlobalRoutines.myStr(.DiffPresHT, 3, 2, False)
                    txtPT(8).Text = GlobalRoutines.myStr(.ThkAdpCh, 3, 2, False)
                    txtPT(9).Text = GlobalRoutines.myStr(.IDChan, 4, 2, False)
                    '----------------------------------------------
                Case 4
                    txtViti(0).Text = .DNStr1 ' mystr(.DNIntScr, 3, 2, False)
                    txtViti(2).Text = GlobalRoutines.myStr(.BCIntScr, 4, 2, False)
                    txtViti(3).Text = GlobalRoutines.myStr(.AreBltScr, 5, 2, False)
                    txtViti(1).Text = .NumScr.ToString
                    txtViti(4).Text = GlobalRoutines.myStr(.Wseating / 1000000.0#, 5, 3, False)
                    txtViti(5).Text = GlobalRoutines.myStr(.Wtest / 1000000.0#, 5, 3, False)
                    txtViti(6).Text = GlobalRoutines.myStr(.Wdesign / 1000000.0#, 5, 3, False)
                    txtViti(7).Text = GlobalRoutines.myStr(.WplasticBox / 1000000.0#, 5, 3, False)
                    If Not t.Equals(txtViti(10)) Then txtViti(10).Text = GlobalRoutines.myStr(.AreExtension, 5, 2, False)
                    If .xFil1 = 0 Then .xFil1 = 2
                    .Tir0.Xfil = .xFil1
                    .Tir0.Dnom = .DNIntScr
                    .Tir0.Cerca("Dnom")
                    If Not AggiornaViti(0) Then Call Fallimento(3)
                    '----------------------------------------------
                Case 5
                    txtSplit(0).Text = GlobalRoutines.myStr(.ODSplitRing, 4, 2, False)
                    txtSplit(1).Text = GlobalRoutines.myStr(.IDSplitRing, 4, 2, False)
                    txtSplit(2).Text = GlobalRoutines.myStr(.ThkReqSplitRing, 4, 2, False)
                    txtSplit(6).Text = GlobalRoutines.myStr(.ThkAdpSplitRing, 4, 2, False)
                    txtSplit(3).Text = GlobalRoutines.myStr(.ODInnerRing, 4, 2, False)
                    txtSplit(4).Text = GlobalRoutines.myStr(.IDInnerRing, 4, 2, False)
                    txtSplit(7).Text = GlobalRoutines.myStr(.ThkReqInnerRing, 4, 2, False)
                    txtSplit(5).Text = GlobalRoutines.myStr(.ThkAdpInnerRing, 4, 2, False)
                    txtSplit(8).Text = GlobalRoutines.myStr(.MDCompRing, 4, 2, False)
                    txtSplit(9).Text = GlobalRoutines.myStr(.Corr, 4, 2, False)
                    If .Fascia > 0 Then
                        framBear.Visible = True
                        _txtSplit_10.Text = GlobalRoutines.myStr(.Fascia, 4, 2, False)
                        _txtSplit_11.Text = GlobalRoutines.myStr((.ODInnerRing - 2 * .Corr - .IDSplitRing) / 2, 4, 2, False)
                        Call Fallimento(4)
                    Else
                        framBear.Visible = False
                    End If
                    '----------------------------------------------
                Case 6
                    _txtCasson_0.Text = GlobalRoutines.myStr(.RotBolt, 3, 3, False)
                    _txtCasson_1.Text = GlobalRoutines.myStr(.RotTest, 3, 3, False)
                    _txtCasson_2.Text = GlobalRoutines.myStr(.RotDes, 3, 3, False)
                    _txtCasson_3.Text = GlobalRoutines.myStr(.MaxDCasson, 4, 2, False)
                    _txtCasson_4.Text = GlobalRoutines.myStr(.MinDCasson, 4, 2, False)
                    _txtCasson_5.Text = GlobalRoutines.myStr(.AltCasson, 4, 2, False)
                    _txtCasson_6.Text = GlobalRoutines.myStr(.ThkCasson, 4, 2, False)
                    _txtCasson_7.Text = GlobalRoutines.myStr(.DiamApCono, 4, 2, False)
                    _txtCasson_8.Text = GlobalRoutines.myStr(CSng(.NoApCono), 3, 0, True)
                    _txtCasson_9.Text = GlobalRoutines.myStr(.CorrCono, 4, 2, False)
                    _txtCasson_10.Text = GlobalRoutines.myStr(.DOAnelCono, 4, 2, False)
                    _txtCasson_11.Text = GlobalRoutines.myStr(.DIAnelCono, 4, 2, False)
                    _txtCasson_12.Text = GlobalRoutines.myStr(.ThkMinFC, 4, 2, False)
                    _txtCasson_13.Text = GlobalRoutines.myStr(.ThkAdpFC, 4, 2, False)
                    Dim Testo As String
                    If Not Calcolato(5) Then
                        _lblCasson_3.BringToFront()
                        _lblFC_0.BringToFront()
                        _lblCasson_1.Visible = False
                        _lblFC_2.Visible = False
                    Else
                        If .VerificaCono = 0 Then
                            _lblCasson_0.BringToFront()
                            _lblCasson_1.Visible = False
                        Else
                            Testo = HelpStringa(9009) + vbCrLf
                            If (.VerificaCono And 1) > 0 Then
                                Testo = Testo + String.Format(HelpStringa(9010), .ComprCdesign, .Mater(CodMAT.MAT_CASSONETTO).S) + vbCrLf
                            End If
                            If (.VerificaCono And 2) > 0 Then
                                Testo = Testo + String.Format(HelpStringa(9011), .ComprCseating, .Mater(CodMAT.MAT_CASSONETTO).S0) + vbCrLf
                            End If
                            If (.VerificaCono And 4) > 0 Then
                                Testo = Testo + String.Format(HelpStringa(9012), .ComprCtest, 0.9 * .Mater(CodMAT.MAT_CASSONETTO).SY0) + vbCrLf
                            End If
                            If (.VerificaCono And 8) > 0 Then
                                Testo = Testo + String.Format(HelpStringa(9013), .ComprCdesign, .EulerCtemp) + vbCrLf
                            End If
                            If (.VerificaCono And 16) > 0 Then
                                Testo = Testo + String.Format(HelpStringa(9014), .ComprCseating, .EulerCroom) + vbCrLf
                            End If
                            If (.VerificaCono And 32) > 0 Then
                                Testo = Testo + String.Format(HelpStringa(9015), .ComprCtest, .EulerCroom) + vbCrLf
                            End If
                            _lblCasson_1.Text = Testo
                            _lblCasson_1.BringToFront()
                            _lblCasson_1.Visible = True
                            Call Fallimento(5)
                        End If
                        If .VerificaBearing = 0 Then
                            _lblFC_1.BringToFront()
                            _lblFC_2.Visible = False
                        Else
                            Testo = HelpStringa(9016) + vbCrLf
                            If (.VerificaBearing And 1) > 0 Then
                                Testo = Testo + String.Format(HelpStringa(9017), .Sbearingdesign, .Mater(CodMAT.MAT_INSERTO).SY) + vbCrLf
                            End If
                            If (.VerificaBearing And 2) > 0 Then
                                Testo = Testo + String.Format(HelpStringa(9018), .Sbearingseating, .Mater(CodMAT.MAT_INSERTO).SY0) + vbCrLf
                            End If
                            If (.VerificaBearing And 4) > 0 Then
                                Testo = Testo + String.Format(HelpStringa(9019), .Sbearingtest, .Mater(CodMAT.MAT_INSERTO).SY0) + vbCrLf
                            End If
                            Testo += HelpStringa(9020)
                            _lblFC_2.Visible = True
                            _lblFC_2.BringToFront()
                            _lblFC_2.Text = Testo
                        End If
                    End If
                Case 7
                    _txtchan_0.Text = GlobalRoutines.myStr(.IDChan, 4, 2, False)
                    _txtchan_1.Text = GlobalRoutines.myStr(.CorrCh, 3, 2, False)
                    _txtchan_2.Text = .GskChan
                    _txtchan_3.Text = GlobalRoutines.myStr(.G2out, 4, 2, False)
                    _txtchan_4.Text = GlobalRoutines.myStr(.G2N, 3, 2, False)
                    _txtchan_5.Text = GlobalRoutines.myStr(.NubGskChan, 3, 2, False)
                    _txtchan_6.Text = GlobalRoutines.myStr(.mGskChan, 3, 2, False)
                    _txtchan_7.Text = GlobalRoutines.myStr(.YGskChan, 5, 0, False)
                    _txtchan_8.Text = .Formula2Sp
                    _txtchan_9.Text = GlobalRoutines.myStr(.B2, 3, 2, False)
                    _txtchan_10.Text = GlobalRoutines.myStr(.ThkMinCh, 3, 2, False)
                    _txtchan_11.Text = GlobalRoutines.myStr(.ThkAdpCh, 3, 2, False)
                    _txtChan_12.Text = GlobalRoutines.myStr(.G2AnInt, 3, 2, False)
                    _txtChan_13.Text = GlobalRoutines.myStr(.G2AnExt, 3, 2, False)
                    chkAnelloEst2.Checked = .G2AnExt > 0
                    chkAnelloInt2.Checked = .G2AnInt > 0
                    chkAnelloEst2_CheckedChanged(Me, New EventArgs)
                    chkAnelloInt2_CheckedChanged(Me, New EventArgs)
                    _txtchan_14.Text = GlobalRoutines.myStr(.G2dente, 3, 2, False)
                Case 8
                    txtVitiExt(0).Text = .DNStr3 'mystr(.DNExtScr, 4, 2, False)
                    txtVitiExt(1).Text = GlobalRoutines.myStr(.BCExtScr, 4, 2, False)
                    txtVitiExt(2).Text = GlobalRoutines.myStr(.AreExtScr, 4, 2, False)
                    txtVitiExt(4).Text = Str(.NExtScr)
                    txtVitiExt(5).Text = GlobalRoutines.myStr(.WseatingCh / 1000000.0#, 5, 3, False)
                    txtVitiExt(6).Text = GlobalRoutines.myStr(.WtestCh / 1000000.0#, 5, 3, False)
                    txtVitiExt(7).Text = GlobalRoutines.myStr(.WdesignCh / 1000000.0#, 5, 3, False)
                    txtVitiExt(8).Text = GlobalRoutines.myStr(.SpostDiaf2, 4, 2, False)
                    If .xFil3 = 0 Then .xFil3 = 2
                    .Tir2.Xfil = .xFil3
                    .Tir2.Dnom = .DNExtScr '.DNStr3
                    .Tir2.Cerca("Dnom")
                    AggiornaViti(2)
                    txtVitiExt(3).Text = GlobalRoutines.myStr(.DPushBars, 4, 2, False)
                    txtVitiInt(0).Text = .DNStr2 ' mystr(.DNBltScr2, 4, 2, False)
                    txtVitiInt(1).Text = GlobalRoutines.myStr(.BCIntScr2, 4, 2, False)
                    txtVitiInt(2).Text = GlobalRoutines.myStr(.AreBltScr2, 4, 2, False)
                    txtVitiInt(4).Text = Str(.NumScr2)
                    txtVitiInt(5).Text = GlobalRoutines.myStr(.IDExtComprRing, 4, 2, False)
                    '   txtVitiInt(7) = mystr(.WdesignPl / 1000000#, 5, 3, False)
                    txtVitiInt(7).Text = GlobalRoutines.myStr(WdesignVitiInt() / 1000000.0#, 5, 3, False)
                    txtVitiInt(6).Text = GlobalRoutines.myStr(.SpostDiaf1, 4, 2, False)
                    txtVitiInt(8).Text = GlobalRoutines.myStr(.SpessDiaf, 4, 2, False)
                    If .xFil2 = 0 Then .xFil2 = 2
                    .Tir1.Xfil = .xFil2
                    .Tir1.Dnom = .DNBltScr2
                    .Tir1.Cerca("Dnom")
                    AggiornaViti(1)
                    txtVitiInt(3).Text = GlobalRoutines.myStr(.DNIntPushBar2, 4, 2, False)
                Case 9
                    txtLR(0).Text = GlobalRoutines.myStr(.DNLockR, 4, 2, False)
                    txtLR(6).Text = GlobalRoutines.myStr(.Filetto.DMaxAn, 4, 2, False)
                    txtLR(9).Text = GlobalRoutines.myStr(.IDLockR, 4, 2, False)
                    txtLR(4).Text = GlobalRoutines.myStr(.ThkMinLR, 4, 2, False)
                    txtLR(5).Text = GlobalRoutines.myStr(.ThkAdpLR, 4, 2, False)
                    If Not t.Equals(_txtLR_1) Then _txtLR_1.Text = GlobalRoutines.myStr(.Filetto.Passo, 4, 2, False)
                    txtLR(2).Text = GlobalRoutines.myStr(.Filetto.Altezza, 4, 2, False)
                    txtLR(3).Text = GlobalRoutines.myStr(.Filetto.RootThk, 4, 2, False)
                    txtLR(8).Text = GlobalRoutines.myStr(.Filetto.GiocoDiam, 4, 2, False)
                    txtLR(10).Text = Str(.NmaxFilettiPoss)
                    txtLR(11).Text = Str(.NreqFiletti)
                    txtLR(12).Text = Str(.NmaxFiletti)
                    txtLR(7).Text = GlobalRoutines.myStr(.Filetto.DMaxCas, 4, 2, False)
                    txtLR(13).Text = GlobalRoutines.myStr(.ODCover, 4, 2, False)
                    txtLR(15).Text = GlobalRoutines.myStr(.ThkMinCv, 4, 3, False)
                    txtLR(14).Text = GlobalRoutines.myStr(.ThkAdpCv, 4, 3, False)
                    txtLR(17).Text = GlobalRoutines.myStr(.ExtCrwMinThk, 4, 3, False)
                    txtLR(16).Text = GlobalRoutines.myStr(.ExtCrwAdpThk, 4, 3, False)
                    txtLR(18).Text = GlobalRoutines.myStr(.EngagedDesign, 4, 3, False)
                    txtLR(19).Text = GlobalRoutines.myStr(.Filetto.TollDiam / 1000.0#, 4, 3, False)
                    txtLR(20).Text = GlobalRoutines.myStr(.TempTransCh, 4, 3, False)
                    txtLR(21).Text = GlobalRoutines.myStr(.TempTransLR, 4, 3, False)
                    txtLR(22).Text = Str(.LunghezzaFiletti)
                    txtLR(23).Text = GlobalRoutines.myStr(.EngagedAccident, 4, 3, False)
                    txtLR(24).Text = GlobalRoutines.myStr(.ThrEndMinThk, 4, 3, False)
                    txtLR(25).Text = GlobalRoutines.myStr(.ThrAdpMinThk, 4, 3, False)
                    txtLR(26).Text = GlobalRoutines.myStr(.DiamIntGola, 4, 3, False)
                    lblFiletti.Visible = .NmaxFilettiPoss < .NreqFiletti
                    cmbTipoFil.SelectedIndex = .OptFiletto
                    cmbPrecis.SelectedIndex = .Filetto.Precision - 5
                    chkDeltaT.CheckState = .CalcDeltaT
                    Me.chkSuperSafe.Checked = .SuperSafe
            End Select
        End With
        Aggiornando = False
    End Sub
    Private ReadOnly Property txtLR(ByVal i As Integer) As TextBox
        Get
            Select Case i
                Case 0 : Return _txtLR_0
                Case 1 : Return _txtLR_1
                Case 2 : Return _txtLR_2
                Case 3 : Return _txtLR_3
                Case 4 : Return _txtLR_4
                Case 5 : Return _txtLR_5
                Case 6 : Return _txtLR_6
                Case 7 : Return _txtLR_7
                Case 8 : Return _txtLR_8
                Case 9 : Return _txtLR_9
                Case 10 : Return _txtLR_10
                Case 11 : Return _txtLR_11
                Case 12 : Return _txtLR_12
                Case 13 : Return _txtLR_13
                Case 14 : Return _txtLR_14
                Case 15 : Return _txtLR_15
                Case 16 : Return _txtLR_16
                Case 17 : Return _txtLR_17
                Case 18 : Return _txtLR_18
                Case 19 : Return _txtLR_19
                Case 20 : Return _txtLR_20
                Case 21 : Return _txtLR_21
                Case 22 : Return _txtLR_22
                Case 23 : Return _txtLR_23
                Case 24 : Return _txtLR_24
                Case 25 : Return _txtLR_25
                Case 26 : Return _txtLR_26
                Case Else : Return Nothing
            End Select
        End Get
    End Property
    Public Sub DomSalva()
        If nomefile Is Nothing Then Exit Sub
        If nomefile = "" Then Exit Sub
        If DaASME Then Exit Sub
        If MsgBox("Vuoi salvare il lavoro in corso?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            menSalva_Click(menSalva, New System.EventArgs())
        End If
    End Sub
    Private Sub AggMateriali()
        Dim i As Short
        Dim N As Integer = NumMat
        If objBre.TipoBL = 0 Then N = 7
        If cmbMat.Items.Count = N Then Exit Sub
        cmbMat.Items.Clear()
        For i = 1 To N
            cmbMat.Items.Add(HelpStringa(EspandiMat(i)))
            cmbMat.Tag = Str(EspandiMat(i))
        Next
        cmbMat.SelectedIndex = 0
    End Sub
    Private ReadOnly Property txtCasson(ByVal i As Integer) As TextBox
        Get
            Select Case i
                Case 0 : Return _txtCasson_0
                Case 1 : Return _txtCasson_1
                Case 2 : Return _txtCasson_2
                Case 3 : Return _txtCasson_3
                Case 4 : Return _txtCasson_4
                Case 5 : Return _txtCasson_5
                Case 6 : Return _txtCasson_6
                Case 7 : Return _txtCasson_7
                Case 8 : Return _txtCasson_8
                Case 9 : Return _txtCasson_9
                Case 10 : Return _txtCasson_10
                Case 11 : Return _txtCasson_11
                Case 12 : Return _txtCasson_12
                Case 13 : Return _txtCasson_13
                Case Else : Return Nothing
            End Select
        End Get
    End Property
    Private Sub txtCasson_TextChanged(ByVal Index As Integer)
        If Inizializzando Then Exit Sub
        If Antiripeti Then Exit Sub
        ModifiedData = True
        With objBre
            Select Case Index
                Case 3 : .MaxDCasson = GlobalRoutines.ValVir(txtCasson(Index).Text)
                Case 4 : .MinDCasson = GlobalRoutines.ValVir(txtCasson(Index).Text)
                Case 5 : .AltCasson = GlobalRoutines.ValVir(txtCasson(Index).Text)
                    EP_txtCasson_5.SetError(FormApert._txtCasson_5, "")
                Case 6 : .ThkCasson = GlobalRoutines.ValVir(txtCasson(Index).Text)
                Case 7 : .DiamApCono = GlobalRoutines.ValVir(txtCasson(Index).Text)
                Case 8 : .NoApCono = GlobalRoutines.ValVir(txtCasson(Index).Text)
                Case 9 : .CorrCono = GlobalRoutines.ValVir(txtCasson(Index).Text)
                Case 10 : .DOAnelCono = GlobalRoutines.ValVir(txtCasson(Index).Text)
                Case 11 : .DIAnelCono = GlobalRoutines.ValVir(txtCasson(Index).Text)
                Case 13 : .ThkAdpFC = GlobalRoutines.ValVir(txtCasson(Index).Text)
            End Select
        End With
        If Not Aggiornando Then Calcolato(5) = False
        'AggText
    End Sub
    Private ReadOnly Property txtchan(ByVal i As Integer) As TextBox
        Get
            Select Case i
                Case 0 : Return _txtchan_0
                Case 1 : Return _txtchan_1
                Case 2 : Return _txtchan_2
                Case 3 : Return _txtchan_3
                Case 4 : Return _txtchan_4
                Case 5 : Return _txtchan_5
                Case 6 : Return _txtchan_6
                Case 7 : Return _txtchan_7
                Case 8 : Return _txtchan_8
                Case 9 : Return _txtchan_9
                Case 10 : Return _txtchan_10
                Case 11 : Return _txtchan_11
                Case 12 : Return _txtChan_12
                Case 13 : Return _txtChan_13
                Case 14 : Return _txtchan_14
                Case Else : Return Nothing
            End Select
        End Get
    End Property
    Private Sub txtchan_TextChanged(ByVal Index As Integer)
        If Inizializzando Then Exit Sub
        ModifiedData = True
        Select Case Index
            Case 0 : objBre.IDChan = GlobalRoutines.ValVir(txtchan(Index).Text)
                objBre.offG2out = 0
            Case 1 : objBre.CorrCh = GlobalRoutines.ValVir(txtchan(Index).Text)
            Case 2 : objBre.GskChan = txtchan(Index).Text
            Case 3
                objBre.G2out = GlobalRoutines.ValVir(txtchan(Index).Text)
                objBre.OffBCextScr = 0
            Case 4 : objBre.G2N = GlobalRoutines.ValVir(txtchan(Index).Text)
                objBre.OffBCextScr = 0
                objBre.offG2out = 0
            Case 5 : objBre.NubGskChan = GlobalRoutines.ValVir(txtchan(Index).Text)
            Case 6 : objBre.mGskChan = GlobalRoutines.ValVir(txtchan(Index).Text)
            Case 7 : objBre.YGskChan = GlobalRoutines.ValVir(txtchan(Index).Text)
            Case 11 : objBre.ThkAdpCh = GlobalRoutines.ValVir(txtchan(Index).Text)
            Case 12 : objBre.G2AnInt = GlobalRoutines.ValVir(txtchan(Index).Text)
            Case 13 : objBre.G2AnExt = GlobalRoutines.ValVir(txtchan(Index).Text)
                objBre.offG2out = 0
            Case 14 : objBre.G2dente = GlobalRoutines.ValVir(txtchan(Index).Text)
                objBre.offG2out = 0
        End Select
    End Sub
    Private Sub txtDes_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        If Inizializzando Then Exit Sub
        Dim Index As Short = IndexedControls.IndexOf(txtDes, eventSender)
        Dim i As Short
        If Antiripeti Or Aggiornando Then Exit Sub
        ModifiedData = True
        With objBre
            Select Case Index
                Case 0 : .DesTempSS = GlobalRoutines.ValVir(txtDes(Index).Text)
                    For i = 1 To 4
                        objBre.Mater(i).Autom(0) = False
                    Next
                Case 1 : .DesPresSS = GlobalRoutines.ValVir(txtDes(Index).Text)
                Case 2 : .DesTempTS = GlobalRoutines.ValVir(txtDes(Index).Text)
                    For i = 4 To 14
                        objBre.Mater(i).Autom(0) = False
                    Next
                Case 3 : .DesPresTS = GlobalRoutines.ValVir(txtDes(Index).Text)
                Case 4 : .DiffPres = GlobalRoutines.ValVir(txtDes(Index).Text)
                Case 5 : .P2idr = GlobalRoutines.ValVir(txtDes(Index).Text)
            End Select
            If Not Aggiornando Then
                For i = 0 To NumCalc
                    Calcolato(i) = False
                Next
            End If
        End With
    End Sub
    Private Sub txtLR_TextChanged(ByVal Index As Integer)
        If Inizializzando Then Exit Sub
        With objBre
            Select Case Index
                Case 0 : .DNLockR = GlobalRoutines.ValVir(txtLR(Index).Text)
                Case 6 : .Filetto.DMaxAn = GlobalRoutines.ValVir(txtLR(Index).Text)
                Case 9 : .IDLockR = GlobalRoutines.ValVir(txtLR(Index).Text)
                Case 5 : .ThkAdpLR = GlobalRoutines.ValVir(txtLR(Index).Text)
                Case 1 : .Filetto.Passo = GlobalRoutines.ValVir(txtLR(Index).Text)
                    If Not Aggiornando Then Calcolato(7) = False
                    InizLR8()
                    AggText(_txtLR_1)
                Case 2 : .Filetto.Altezza = GlobalRoutines.ValVir(txtLR(Index).Text)
                Case 3 : .Filetto.RootThk = GlobalRoutines.ValVir(txtLR(Index).Text)
                Case 8 : .Filetto.GiocoDiam = GlobalRoutines.ValVir(txtLR(Index).Text)
                Case 10 : .NmaxFilettiPoss = Val(txtLR(Index).Text)
                Case 12 : .NmaxFiletti = Val(txtLR(Index).Text)
                Case 7 : .Filetto.DMaxCas = GlobalRoutines.ValVir(txtLR(Index).Text)
                Case 13 : .ODCover = GlobalRoutines.ValVir(txtLR(Index).Text)
                Case 14 : .ThkAdpCv = GlobalRoutines.ValVir(txtLR(Index).Text)
                Case 16 : .ExtCrwAdpThk = GlobalRoutines.ValVir(txtLR(Index).Text)
                Case 19 : .Filetto.TollDiam = 1000.0# * GlobalRoutines.ValVir(txtLR(Index).Text)
                Case 20 : .TempTransCh = GlobalRoutines.ValVir(txtLR(Index).Text)
                Case 21 : .TempTransLR = GlobalRoutines.ValVir(txtLR(Index).Text)
                Case 25 : .ThrAdpMinThk = GlobalRoutines.ValVir(txtLR(Index).Text)
                Case 26 : .DiamIntGola = GlobalRoutines.ValVir(txtLR(Index).Text)
            End Select
        End With
    End Sub
    Private Sub txtMat_TextChanged(ByVal Index As Integer)
        If Inizializzando Or Aggiornando Then Exit Sub
        Dim i As Integer
        Try
            With objBre.Mater(Val(cmbMat.Tag))
                If Index < 8 Then
                    .Autom(Index) = False
                    txtMat(Index).BackColor = Color.White
                End If
                Select Case Index
                    Case 0
                        .TempDes = GlobalRoutines.ValVir(txtMat(Index).Text)
                        ' cmdRic.Enabled = True
                    Case 1
                        .S = GlobalRoutines.ValVir(txtMat(Index).Text)
                        cmdRicalcola.Enabled = Not _txtMat_8.BackColor = Color.White
                    Case 2
                        .S0 = GlobalRoutines.ValVir(txtMat(Index).Text)
                        cmdRicalcola.Enabled = Not _txtMat_8.BackColor = Color.White
                    Case 3
                        .SY = GlobalRoutines.ValVir(txtMat(Index).Text)
                        cmdRicalcola.Enabled = Not _txtMat_8.BackColor = Color.White
                    Case 4
                        .SY0 = GlobalRoutines.ValVir(txtMat(Index).Text)
                        cmdRicalcola.Enabled = Not _txtMat_8.BackColor = Color.White
                    Case 5
                        .E = GlobalRoutines.ValVir(txtMat(Index).Text)
                        cmdRicalcola.Enabled = Not _txtMat_8.BackColor = Color.White
                    Case 6
                        .E0 = GlobalRoutines.ValVir(txtMat(Index).Text)
                        cmdRicalcola.Enabled = Not _txtMat_8.BackColor = Color.White
                    Case 7
                        .Alfa = GlobalRoutines.ValVir(txtMat(Index).Text)
                        cmdRicalcola.Enabled = True
                    Case 8 : .Mat = txtMat(Index).Text
                        cmdRicalcola.Enabled = False
                        For i = 0 To 8
                            If i < 8 Then .Autom(i) = False
                            txtMat(i).BackColor = Color.White
                        Next
                End Select
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message + vbCrLf + ex.StackTrace)
        End Try
    End Sub
    Private Sub txtPT_TextChanged(ByVal Index As Integer)
        If Inizializzando Then Exit Sub
        With objBre
            Select Case Index
                Case 0 : .TubeDout = GlobalRoutines.ValVir(txtPT(Index).Text)
                Case 1 : .Passo = GlobalRoutines.ValVir(txtPT(Index).Text)
                Case 2 : .CorrTSCh = GlobalRoutines.ValVir(txtPT(Index).Text)
                Case 3 : .CorrTSSh = GlobalRoutines.ValVir(txtPT(Index).Text)
                Case 4 : .Cava = GlobalRoutines.ValVir(txtPT(Index).Text)
                Case 5 : .ThkMinTS = GlobalRoutines.ValVir(txtPT(Index).Text)
                Case 6 : .ThkAdpTS = GlobalRoutines.ValVir(txtPT(Index).Text)
                Case 7 : .DiffPresHT = GlobalRoutines.ValVir(txtPT(Index).Text)
                Case 8 : .ThkAdpCh = GlobalRoutines.ValVir(txtPT(Index).Text)
                Case 9 : .IDChan = GlobalRoutines.ValVir(txtPT(Index).Text)
                    .offG2out = 0
            End Select
        End With
    End Sub
    Private ReadOnly Property txtPT(ByVal i As Integer) As TextBox
        Get
            Select Case i
                Case 0 : Return _txtPT_0
                Case 1 : Return _txtPT_1
                Case 2 : Return _txtPT_2
                Case 3 : Return _txtPT_3
                Case 4 : Return _txtPT_4
                Case 5 : Return _txtPT_5
                Case 6 : Return _txtPT_6
                Case 7 : Return _txtPT_7
                Case 8 : Return _txtPT_8
                Case 9 : Return _txtPT_9
                Case Else : Return Nothing
            End Select
        End Get
    End Property
    Private ReadOnly Property txtShell(ByVal i As Integer) As TextBox
        Get
            Select Case i
                Case 0 : Return _txtShell_0
                Case 1 : Return _txtShell_1
                Case 2 : Return _txtShell_2
                Case 3 : Return _txtShell_3
                Case 4 : Return _txtShell_4
                Case 5 : Return _txtShell_5
                Case 6 : Return _txtShell_6
                Case 7 : Return _txtShell_7
                Case 8 : Return _txtShell_8
                Case 9 : Return _txtShell_9
                Case 10 : Return _txtShell_10
                Case 11 : Return _txtShell_11
                Case 12 : Return _txtShell_12
                Case 13 : Return _txtShell_13
                Case 14 : Return _txtShell_14
                Case 15 : Return _txtShell_15
                Case 16 : Return _txtShell_16
                Case 17 : Return _txtShell_17
                Case 18 : Return _txtShell_18
                Case Else : Return Nothing
            End Select
        End Get
    End Property
    Private Sub txtShell_TextChanged(ByVal Index As Integer)
        If Inizializzando Or Aggiornando Then Exit Sub
        ModifiedData = True
        Select Case Index
            Case 0 'diametro interno mantello
                objBre.IDShell = GlobalRoutines.ValVir(txtShell(Index).Text)
            Case 1 'corrosione o clad
                objBre.CorrSh = GlobalRoutines.ValVir(txtShell(Index).Text)
            Case 11 'spessore assunto
                objBre.ThkAdpSh = GlobalRoutines.ValVir(txtShell(Index).Text)
            Case 3 : objBre.Gasket = txtShell(Index).Text
            Case 2 : objBre.G1out = GlobalRoutines.ValVir(txtShell(Index).Text)
                If Not Aggiornando Then Calcolato(1) = False
            Case 4 : objBre.G1N = GlobalRoutines.ValVir(txtShell(Index).Text)
                If Not Aggiornando Then Calcolato(1) = False
            Case 5 : objBre.Nubbin = GlobalRoutines.ValVir(txtShell(Index).Text)
                If Not Aggiornando Then Calcolato(1) = False
            Case 6 : objBre.m = GlobalRoutines.ValVir(txtShell(Index).Text)
                If Not Aggiornando Then Calcolato(1) = False
            Case 7 : objBre.Y = GlobalRoutines.ValVir(txtShell(Index).Text)
                If Not Aggiornando Then Calcolato(1) = False
            Case 15 'raggio fondo
                objBre.HemRadius = GlobalRoutines.ValVir(txtShell(Index).Text)
                If Not Aggiornando Then Calcolato(1) = False
            Case 14 'corrosione o clad
                objBre.CorrSh = GlobalRoutines.ValVir(txtShell(Index).Text)
                If Not Aggiornando Then Calcolato(1) = False
            Case 12 'spess assunto fondo
                objBre.ThkAdpHe = GlobalRoutines.ValVir(txtShell(Index).Text)
            Case 16 'anello interno
                objBre.G1AnInt = GlobalRoutines.ValVir(txtShell(Index).Text)
                If Not Aggiornando Then Calcolato(1) = False
            Case 17 'anello esterno
                objBre.G1AnExt = GlobalRoutines.ValVir(txtShell(Index).Text)
                If Not Aggiornando Then Calcolato(1) = False
            Case 18 'dente
                objBre.G1dente = GlobalRoutines.ValVir(txtShell(Index).Text)
                If Not Aggiornando Then Calcolato(1) = False
        End Select
        InizShell()
        AggText(txtShell(Index))
    End Sub
    Private Sub txtSplit_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        If Inizializzando Then Exit Sub
        Dim Index As Short = IndexedControls.IndexOf(txtSplit, eventSender)
        With objBre
            Select Case Index
                Case 0 : .ODSplitRing = GlobalRoutines.ValVir(txtSplit(Index).Text)
                Case 1 : .IDSplitRing = GlobalRoutines.ValVir(txtSplit(Index).Text)
                Case 6 : .ThkAdpSplitRing = GlobalRoutines.ValVir(txtSplit(Index).Text)
                Case 3 : .ODInnerRing = GlobalRoutines.ValVir(txtSplit(Index).Text)
                Case 4 : .IDInnerRing = GlobalRoutines.ValVir(txtSplit(Index).Text)
                Case 5 : .ThkAdpInnerRing = GlobalRoutines.ValVir(txtSplit(Index).Text)
                Case 8 : .MDCompRing = GlobalRoutines.ValVir(txtSplit(Index).Text)
                Case 9 : .Corr = GlobalRoutines.ValVir(txtSplit(Index).Text)
            End Select
        End With
    End Sub
    Private Sub txtViti_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        If Inizializzando Then Exit Sub
        Dim Index As Short = IndexedControls.IndexOf(txtViti, eventSender)
        With objBre
            Select Case Index
                Case 0 : .DNStr1 = txtViti(Index).Text '.DNIntScr = Val(txtViti(Index))
                Case 2 : .BCIntScr = GlobalRoutines.ValVir(txtViti(Index).Text)
                    'Case 3 : .AreBltScr = GlobalRoutines.ValVir(txtViti(Index).Text)
                Case 1 : .NumScr = Val(txtViti(Index).Text)
                    If Not Aggiornando Then Calcolato(3) = False
                    'Case 8 : .BSmin1 = GlobalRoutines.ValVir(txtViti(Index).Text)
                Case 10 : .AreExtension = GlobalRoutines.ValVir(txtViti(Index).Text)
                    INTSCR()
                    AggText(FormApert._txtViti_10)
            End Select
        End With
    End Sub
    Private Sub txtVitiExt_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        If Inizializzando Then Exit Sub
        Dim Index As Short = IndexedControls.IndexOf(txtVitiExt, eventSender)
        ModifiedData = True
        With objBre
            Select Case Index
                Case 0 : .DNStr3 = txtVitiExt(Index).Text
                Case 1 : .BCExtScr = GlobalRoutines.ValVir(txtVitiExt(Index).Text)
                Case 2 : .AreExtScr = GlobalRoutines.ValVir(txtVitiExt(Index).Text)
                Case 3 : .DPushBars = GlobalRoutines.ValVir(txtVitiExt(Index).Text)
                Case 4 : .NExtScr = Val(txtVitiExt(Index).Text)
                    If Not Aggiornando Then Calcolato(7) = False
                Case 8 : .SpostDiaf2 = GlobalRoutines.ValVir(txtVitiExt(Index).Text)
                Case 9 : .BSmin3 = GlobalRoutines.ValVir(txtVitiExt(Index).Text)
            End Select
        End With

    End Sub
    Private Sub txtVitiInt_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        If Inizializzando Then Exit Sub
        Dim Index As Short = IndexedControls.IndexOf(txtVitiInt, eventSender)
        ModifiedData = True
        With objBre
            Select Case Index
                Case 0 : .DNStr2 = txtVitiInt(Index).Text
                Case 1 : .BCIntScr2 = GlobalRoutines.ValVir(txtVitiInt(Index).Text)
                Case 2 : .AreBltScr2 = GlobalRoutines.ValVir(txtVitiInt(Index).Text)
                Case 3 : .DNIntPushBar2 = GlobalRoutines.ValVir(txtVitiInt(Index).Text)
                Case 4 : .NumScr2 = Val(txtVitiInt(Index).Text)
                    If Not Aggiornando Then Calcolato(7) = False
                Case 5 : .IDExtComprRing = GlobalRoutines.ValVir(txtVitiInt(Index).Text)
                Case 6 : .SpostDiaf1 = GlobalRoutines.ValVir(txtVitiInt(Index).Text)
                Case 8 : .SpessDiaf = GlobalRoutines.ValVir(txtVitiInt(Index).Text)
                Case 9 : .BSmin2 = GlobalRoutines.ValVir(txtVitiInt(Index).Text)
            End Select
        End With
    End Sub
    Private Sub Designvisible(ByRef v As Boolean)
        _Label_0.Visible = v
        _Label_1.Visible = v
        _Label_4.Visible = v
        txtDes(0).Visible = v
        txtDes(1).Visible = v
        txtDes(4).Visible = v
        _lblMis_0.Visible = v
        _lblMis_1.Visible = v
        _lblMis_4.Visible = v
        Label20.Visible = Not v
        Label21.Visible = Not v
        Label22.Visible = Not v
        Label23.Visible = Not v
        _txtPT_8.Visible = Not v
        _txtPT_9.Visible = Not v
        framIntScr2.Visible = v
        framCarInt.Visible = v
        _Label_93.Visible = v
        _txtVitiInt_5.Visible = v
        _lblMis_79.Visible = v
        Aggiornando = True
        Do
            TabStrip1.TabPages.RemoveAt(0)
        Loop While TabStrip1.TabPages.Count > 0
        If v Then
            TabStrip1.TabPages.AddRange(pages8)
            framExtScr.Text = "Viti e pistoni sul diametro esterno"
            framCarExt.Text = "Carichi sulle viti sul diametro esterno"
        Else
            TabStrip1.TabPages.AddRange(Pages4)
            framExtScr.Text = "Viti e pistoni"
            framCarExt.Text = "Carichi sulle viti"
        End If
        Aggiornando = False
    End Sub
    Private ReadOnly Property lblCasson(ByVal i As Integer) As Label
        Get
            Select Case i
                Case 0 : Return _lblCasson_0
                Case 1 : Return _lblCasson_1
                    'Case 2 : Return _lblCasson_2
                Case 3 : Return _lblCasson_3
                Case Else : Return Nothing
            End Select
        End Get
    End Property
    Private Function AggiornaViti(ByRef Index As Short, Optional ByVal invisibile As Boolean = False) As Boolean
        Dim corda, arco, area As Single
        With objBre
            Select Case Index
                Case 0
                    If .NumScr > 0 And .BCIntScr > 0 Then
                        arco = 2 * PI / .NumScr
                        corda = 2 * System.Math.Sin(arco / 2) * .BCIntScr / 2
                    End If
                    If Not invisibile Then
                        txtViti(0).Text = .Tir0.DN
                        txtViti(3).Text = GlobalRoutines.myStr(.AreBltScr, 5, 2, False)
                        txtViti(8).Text = GlobalRoutines.myStr((.Tir0.BSmin), 4, 2, False)
                        txtViti(9).Text = GlobalRoutines.myStr(corda, 4, 2, False)
                        txtTroppiTiranti.Visible = corda < .Tir0.BSmin
                    End If
                    Return Not corda < .Tir0.BSmin
                Case 1
                    area = .Tir1.Diam ^ 2 * PI / 4
                    If .NumScr2 > 0 And .BCIntScr2 > 0 Then
                        arco = 2 * PI / .NumScr2
                        corda = 2 * System.Math.Sin(arco / 2) * .BCIntScr2 / 2
                    End If
                    If Not invisibile Then
                        txtVitiInt(0).Text = .Tir1.DN
                        txtVitiInt(2).Text = GlobalRoutines.myStr(area, 4, 2, False)
                        txtVitiInt(9).Text = GlobalRoutines.myStr((.Tir1.BSmin), 4, 2, False)
                        If corda < .Tir1.BSmin Then
                            EP_txtVitiInt_10.SetError(_txtVitiInt_10, HelpStringa(1024))
                        Else
                            EP_txtVitiInt_10.SetError(_txtVitiInt_10, "")
                        End If
                        txtVitiInt(10).Text = GlobalRoutines.myStr(corda, 4, 2, False)
                    End If
                    .DNIntPushBar2 = .Tir1.Dnom
                    Return Not corda < .Tir1.BSmin
                Case 2
                    area = .Tir2.Diam ^ 2 * PI / 4
                    If .NExtScr > 0 And .BCExtScr > 0 Then
                        arco = 2 * PI / .NExtScr
                        corda = 2 * System.Math.Sin(arco / 2) * .BCExtScr / 2
                    End If
                    If Not invisibile Then
                        txtVitiExt(0).Text = .Tir2.DN
                        txtVitiExt(2).Text = GlobalRoutines.myStr(area, 4, 2, False)
                        txtVitiExt(9).Text = GlobalRoutines.myStr((.Tir2.BSmin), 4, 2, False)
                        If corda < .Tir2.BSmin Then
                            EP_txtVitiExt_10.SetError(_txtVitiExt_10, HelpStringa(1024))
                        Else
                            EP_txtVitiExt_10.SetError(_txtVitiExt_10, "")
                        End If
                        txtVitiExt(10).Text = GlobalRoutines.myStr(corda, 4, 2, False)
                    End If
                    .DPushBars = .Tir2.Dnom
                    Return Not corda < .Tir2.BSmin
            End Select
        End With
    End Function

    Private Sub _cmdCalc_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmdCalc_1.Click
        cmdCalc_Click(EspandiInv(1))
    End Sub

    Private Sub _cmdCalc_2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmdCalc_2.Click
        cmdCalc_Click(EspandiInv(2))

    End Sub

    Private Sub _cmdCalc_3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmdCalc_3.Click
        cmdCalc_Click(EspandiInv(3))
    End Sub

    Private Sub _cmdCalc_4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmdCalc_4.Click
        cmdCalc_Click(EspandiInv(4))
    End Sub

    Private Sub _cmdCalc_5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmdCalc_5.Click
        cmdCalc_Click(EspandiInv(5))
        If objBre.TipoBL = 1 And Not Calcolato(1) Then TabStrip1_ClickEvent(Me, New System.EventArgs)
    End Sub

    Private Sub _cmdCalc_6_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmdCalc_6.Click
        cmdCalc_Click(EspandiInv(6))
    End Sub

    Private Sub _cmdCalc_7_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmdCalc_7.Click
        cmdCalc_Click(EspandiInv(7))
    End Sub

    Private Sub _cmdCalc_8_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmdCalc_8.Click
        cmdCalc_Click(EspandiInv(8))
    End Sub
    Private Sub UpDownMat_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpDownMat.ValueChanged
        If Inizializzando Or Not UpDownMat.Enabled Then Exit Sub
        cmbMat.SelectedIndex = UpDownMat.Value
    End Sub

    Private Sub cmdRicalcola_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRicalcola.Click
        AggiornaValori()
        AggiornaDisplay()
    End Sub

    Private Sub _txtMat_0_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtMat_0.TextChanged
        txtMat_TextChanged(0)
    End Sub

    Private Sub _txtMat_1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtMat_1.TextChanged
        txtMat_TextChanged(1)
    End Sub

    Private Sub _txtMat_2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtMat_2.TextChanged
        txtMat_TextChanged(2)
    End Sub

    Private Sub _txtMat_3_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtMat_3.TextChanged
        txtMat_TextChanged(3)
    End Sub

    Private Sub _txtMat_4_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtMat_4.TextChanged
        txtMat_TextChanged(4)
    End Sub

    Private Sub _txtMat_5_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtMat_5.TextChanged
        txtMat_TextChanged(5)
    End Sub

    Private Sub _txtMat_6_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtMat_6.TextChanged
        txtMat_TextChanged(6)
    End Sub

    Private Sub _txtMat_7_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtMat_7.TextChanged
        txtMat_TextChanged(7)
    End Sub

    Private Sub _txtMat_8_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtMat_8.TextChanged
        txtMat_TextChanged(8)
    End Sub
    Private ReadOnly Property txtMat(ByVal i As Integer) As TextBox
        Get
            Select Case i
                Case 0 : Return _txtMat_0
                Case 1 : Return _txtMat_1
                Case 2 : Return _txtMat_2
                Case 3 : Return _txtMat_3
                Case 4 : Return _txtMat_4
                Case 5 : Return _txtMat_5
                Case 6 : Return _txtMat_6
                Case 7 : Return _txtMat_7
                Case 8 : Return _txtMat_8
                Case Else : Return Nothing
            End Select
        End Get
    End Property
    Private Sub cmdSel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSel.Click
        framMat.Visible = True
        cmbMat.SelectedIndex = 0
        cmdSel.Visible = False
    End Sub
    Private Sub _txtDes_0_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _txtDes_0.TextChanged

    End Sub
    Friend Sub menChiudi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menChiudi.Click
        If ModifiedData Then DomSalva()
        'Guarn = Nothing
        'Guarn2 = Nothing
        'Tir0 = Nothing
        'Tir1 = Nothing
        'Tir2 = Nothing
    End Sub
    Private Sub _optDiff_0_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _optDiff_0.CheckedChanged
        If _optDiff_0.Checked Then
            objBre.Ipres = 0
        Else
            objBre.Ipres = 1
        End If
    End Sub

    Private Sub _optDiff_1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _optDiff_1.CheckedChanged
        If _optDiff_1.Checked Then
            objBre.Ipres = 1
        Else
            objBre.Ipres = 0
        End If
    End Sub

    Private Sub cmdRicalcRings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRicalcRings.Click
        InizChan2()
        InizAnelli4()
        AggText()
        EP_txtSplit_0.SetError(_txtSplit_0, "")
        EP_txtSplit_1.SetError(_txtSplit_1, "")
        EP_txtSplit_3.SetError(_txtSplit_3, "")
        EP_txtSplit_4.SetError(_txtSplit_4, "")
        EP_txtSplit_8.SetError(_txtSplit_8, "")
    End Sub

    Private Sub _txtSplit_0_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtSplit_0.Validated
        'ODSplitRing
        Dim Valore As Single = GlobalRoutines.ValVir(_txtSplit_0.Text)
        With objBre
            If Valore < .IDSplitRing + 2 * objBre.lbThkSplitRing / 2 Then
                EP_txtSplit_0.SetError(_txtSplit_0, HelpStringa(1000))
            ElseIf Valore > .IDSplitRing + 2 * objBre.lbThkSplitRing * 2 Then
                EP_txtSplit_0.SetError(_txtSplit_0, HelpStringa(1001))
            Else
                EP_txtSplit_0.SetError(_txtSplit_0, "")
            End If
        End With

    End Sub

    Private Sub _txtSplit_1_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtSplit_1.Validated
        'IDSplitRing
        Dim Valore As Single = GlobalRoutines.ValVir(_txtSplit_1.Text)
        With objBre
            If Valore < .IDChan - 2 * objBre.lbSporgenzaSplitRing Then
                EP_txtSplit_1.SetError(_txtSplit_1, HelpStringa(1002))
                _txtSplit_1.BackColor = Color.LightPink
                .au_IDSplitRing = False
            ElseIf Valore > .IDChan - 2 * objBre.lbSporgenzaSplitRing Then
                EP_txtSplit_1.SetError(_txtSplit_1, HelpStringa(1003))
                _txtSplit_1.BackColor = Color.LightPink
                .au_IDSplitRing = False
            Else
                EP_txtSplit_1.SetError(_txtSplit_1, "")
            End If
            ' + 6.0# - 30.0#
        End With
    End Sub

    Private Sub _txtSplit_4_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtSplit_4.Validated
        'IDInnerRing
        Dim Valore As Single = GlobalRoutines.ValVir(_txtSplit_4.Text)
        Dim ID As Single = modMain.IDInnerRingOpt
        With objBre
            If Valore < ID - 2 Then
                EP_txtSplit_4.SetError(_txtSplit_4, String.Format(HelpStringa(1004), ID))
                .au_IDInnerRing = False
                Me._txtSplit_4.BackColor = Color.LightPink
            ElseIf Valore > ID + 2 Then
                EP_txtSplit_4.SetError(_txtSplit_4, String.Format(HelpStringa(1005), ID))
                .au_IDInnerRing = False
                Me._txtSplit_4.BackColor = Color.LightPink
            Else
                EP_txtSplit_4.SetError(_txtSplit_4, "")
            End If
        End With
    End Sub

    Private Sub _txtSplit_3_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtSplit_3.Validated
        'ODInnerRing
        Dim Valore As Single = GlobalRoutines.ValVir(_txtSplit_3.Text)
        With objBre
            Dim Vecchio As Single = modMain.Val_ODInnerRing
            If Valore < Vecchio - 2 Then
                EP_txtSplit_3.SetError(_txtSplit_3, String.Format(HelpStringa(1006), Vecchio))
                .au_ODInnerRing = False
                Me._txtSplit_3.BackColor = Color.LightPink
            ElseIf Valore > Vecchio + 2 Then
                EP_txtSplit_3.SetError(_txtSplit_3, String.Format(HelpStringa(1007), Vecchio))
                .au_ODInnerRing = False
                Me._txtSplit_3.BackColor = Color.LightPink
            Else
                EP_txtSplit_3.SetError(_txtSplit_3, "")
            End If
        End With
    End Sub

    Private Sub _txtSplit_8_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtSplit_8.Validated
        'MDCompRing
        Dim Valore As Single = GlobalRoutines.ValVir(_txtSplit_8.Text)
        With objBre
            If Valore < .IDInnerRing + objBre.lbThkCompRing - 0.5 Then
                EP_txtSplit_8.SetError(_txtSplit_8, HelpStringa(1008))
            ElseIf Valore > .IDInnerRing + objBre.lbThkCompRing + 0.5 Then
                EP_txtSplit_8.SetError(_txtSplit_8, HelpStringa(1009))
            Else
                EP_txtSplit_8.SetError(_txtSplit_8, "")
            End If
        End With
    End Sub

    Private Sub _txtCasson_3_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtCasson_3.TextChanged
        txtCasson_TextChanged(3)
    End Sub

    Private Sub _txtCasson_3_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtCasson_3.Validated
        'MaxDCasson
        Dim Valore As Single = GlobalRoutines.ValVir(_txtCasson_3.Text)
        With objBre
            If Valore - .ThkCasson < .IDShell Then
                EP_txtCasson_3.SetError(_txtCasson_3, HelpStringa(1011))
                .au_MaxDCasson = False
                _txtCasson_3.BackColor = Color.LightPink
            ElseIf Valore + .ThkCasson > .G1out + 2 * .G1AnExt Then
                EP_txtCasson_3.SetError(_txtCasson_3, HelpStringa(1012))
                .au_MaxDCasson = False
                _txtCasson_3.BackColor = Color.LightPink
            Else
                EP_txtCasson_3.SetError(_txtCasson_3, "")
            End If
        End With
    End Sub

    Private Sub chkAnelloEst_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkAnelloEst.CheckedChanged
        If chkAnelloEst.Checked Then
            _txtShell_17.Visible = True
            Label5.Visible = True
            If objBre.G1AnExt <= 0 Then objBre.G1AnExt = 5
            If Not Aggiornando Then
                _txtShell_17.Text = GlobalRoutines.myStr(objBre.G1AnExt, 3, 2, 0)
                _txtShell_17_Validated(Me, Nothing)
            End If
        Else
            _txtShell_17.Visible = False
            Label5.Visible = False
            objBre.G1AnExt = 0
        End If
    End Sub
    Private Sub chkAnelloInt_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkAnelloInt.CheckedChanged
        If chkAnelloInt.Checked Then
            _txtShell_16.Visible = True
            Label4.Visible = True
            If objBre.G1AnInt <= 0 Then objBre.G1AnInt = 5
            If Not Aggiornando Then
                _txtShell_16.Text = GlobalRoutines.myStr(objBre.G1AnInt, 3, 2, 0)
                _txtShell_16_Validated(Me, Nothing)
            End If
        Else
            _txtShell_16.Visible = False
            Label4.Visible = False
            objBre.G1AnInt = 0
        End If
    End Sub
    Private Sub _txtShell_0_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtShell_0.TextChanged
        txtShell_TextChanged(0)
    End Sub
    Private Sub _txtShell_0_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtShell_0.Validated
        'IDShell
        cmdRicalcShell_Click(Me, Nothing)
    End Sub
    Private Sub _txtShell_2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtShell_2.TextChanged
        txtShell_TextChanged(2)
    End Sub
    Private Sub _txtShell_2_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtShell_2.Validated
        'G1out
        'Dim Testo As String
        With objBre
            If .G1out < .IDShell + 2 * (.G1dente + .G1AnInt + .G1N) Then
                'Testo = HelpStringa(WRN_G1OUT)
                If MostraAiuto(WRN_G1OUT, RoutBase1.ChiaviMess.MessQuestion + _
                                          RoutBase1.ChiaviMess.MessHelpButton + _
                                          RoutBase1.ChiaviMess.MessYesNo) = _
                                          RoutBase1.ChiaviMess.MessSi Then
                    .G1out = .IDShell + 2 * (.G1dente + .G1AnInt + .G1N)
                    EP_txtShell_2.SetError(_txtShell_2, "")
                    EP_txtShell_4.SetError(_txtShell_4, "")
                    EP_txtShell_16.SetError(_txtShell_16, "")
                    EP_txtShell_18.SetError(_txtShell_18, "")
                Else
                    EP_txtShell_2.SetError(_txtShell_2, HelpStringa(1013))
                End If
            ElseIf .G1out > .IDShell + 2 * (.G1dente + .G1AnInt + .G1N) + 2 Then
                EP_txtShell_2.SetError(_txtShell_2, HelpStringa(1014))
            Else
                EP_txtShell_2.SetError(_txtShell_2, "")
                EP_txtShell_4.SetError(_txtShell_4, "")
                EP_txtShell_16.SetError(_txtShell_16, "")
                EP_txtShell_18.SetError(_txtShell_18, "")
            End If
        End With
        InizShell()
        AggText()
    End Sub

    Private Sub _txtShell_4_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtShell_4.TextChanged
        txtShell_TextChanged(4)
    End Sub
    Private Sub _txtShell_4_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtShell_4.Validated
        'G1N
        With objBre
            If .G1out < .IDShell + 2 * (.G1dente + .G1AnInt + .G1N) Then
                EP_txtShell_4.SetError(_txtShell_4, HelpStringa(1015))
            ElseIf .G1out > .IDShell + 2 * (.G1dente + .G1AnInt + .G1N) + 2 Then
                EP_txtShell_4.SetError(_txtShell_4, HelpStringa(1016))
            Else
                EP_txtShell_4.SetError(_txtShell_4, "")
                EP_txtShell_2.SetError(_txtShell_2, "")
                EP_txtShell_16.SetError(_txtShell_16, "")
                EP_txtShell_18.SetError(_txtShell_18, "")
            End If
        End With
        InizShell()
        AggText()
    End Sub

    Private Sub _txtShell_16_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtShell_16.TextChanged
        txtShell_TextChanged(16)
    End Sub
    Private Sub _txtShell_16_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtShell_16.Validated
        'AnInt
        With objBre
            If .G1out < .IDShell + 2 * (.G1dente + .G1AnInt + .G1N) Then
                EP_txtShell_16.SetError(_txtShell_16, HelpStringa(1017))
            ElseIf .G1out > .IDShell + 2 * (.G1dente + .G1AnInt + .G1N) + 2 Then
                EP_txtShell_16.SetError(_txtShell_16, HelpStringa(1018))
            Else
                EP_txtShell_4.SetError(_txtShell_4, "")
                EP_txtShell_2.SetError(_txtShell_2, "")
                EP_txtShell_16.SetError(_txtShell_16, "")
                EP_txtShell_18.SetError(_txtShell_18, "")
            End If
        End With
        InizShell()
        AggText()
    End Sub

    Private Sub _txtShell_17_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtShell_17.TextChanged
        txtShell_TextChanged(17)
    End Sub
    Private Sub _txtShell_17_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtShell_17.Validated
        'AnEst
    End Sub

    Private Sub _txtCasson_0_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtCasson_0.TextChanged
        txtCasson_TextChanged(0)
    End Sub

    Private Sub _txtCasson_1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtCasson_1.TextChanged
        txtCasson_TextChanged(1)
    End Sub

    Private Sub _txtCasson_10_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtCasson_10.TextChanged
        txtCasson_TextChanged(10)
    End Sub

    Private Sub _txtCasson_11_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtCasson_11.TextChanged
        txtCasson_TextChanged(11)
    End Sub

    Private Sub _txtCasson_12_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtCasson_12.TextChanged
        txtCasson_TextChanged(12)
    End Sub

    Private Sub _txtCasson_13_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtCasson_13.TextChanged
        txtCasson_TextChanged(13)
    End Sub

    Private Sub _txtCasson_2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtCasson_2.TextChanged
        txtCasson_TextChanged(2)
    End Sub

    Private Sub _txtCasson_4_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtCasson_4.TextChanged
        txtCasson_TextChanged(4)
    End Sub

    Private Sub _txtCasson_5_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtCasson_5.TextChanged
        txtCasson_TextChanged(5)
    End Sub

    Private Sub _txtCasson_6_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtCasson_6.TextChanged
        txtCasson_TextChanged(6)
    End Sub

    Private Sub _txtCasson_7_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtCasson_7.TextChanged
        txtCasson_TextChanged(7)
    End Sub

    Private Sub _txtCasson_8_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtCasson_8.TextChanged
        txtCasson_TextChanged(8)
    End Sub

    Private Sub _txtCasson_9_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtCasson_9.TextChanged
        txtCasson_TextChanged(9)
    End Sub

    Private Sub _txtShell_1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtShell_1.TextChanged
        txtShell_TextChanged(1)
    End Sub

    Private Sub _txtShell_10_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtShell_10.TextChanged
        txtShell_TextChanged(10)
    End Sub

    Private Sub _txtShell_11_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtShell_11.TextChanged
        txtShell_TextChanged(11)
    End Sub

    Private Sub _txtShell_12_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtShell_12.TextChanged
        txtShell_TextChanged(12)
    End Sub

    Private Sub _txtShell_13_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtShell_13.TextChanged
        txtShell_TextChanged(13)
    End Sub

    Private Sub _txtShell_14_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtShell_14.TextChanged
        txtShell_TextChanged(14)
    End Sub

    Private Sub _txtShell_15_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtShell_15.TextChanged
        txtShell_TextChanged(15)
    End Sub

    Private Sub _txtShell_3_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtShell_3.TextChanged
        txtShell_TextChanged(3)
    End Sub

    Private Sub _txtShell_5_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtShell_5.TextChanged
        txtShell_TextChanged(5)
    End Sub

    Private Sub _txtShell_6_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtShell_6.TextChanged
        txtShell_TextChanged(6)
    End Sub

    Private Sub _txtShell_7_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtShell_7.TextChanged
        txtShell_TextChanged(7)
    End Sub

    Private Sub _txtShell_8_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtShell_8.TextChanged
        txtShell_TextChanged(8)
    End Sub

    Private Sub _txtShell_9_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtShell_9.TextChanged
        txtShell_TextChanged(9)
    End Sub

    Private Sub cmdRicalcShell_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRicalcShell.Click
        objBre.G1out = 0
        InizShell()
        AggText()
        EP_txtShell_16.SetError(Me._txtShell_16, "")
        EP_txtShell_4.SetError(Me._txtShell_4, "")
        EP_txtShell_2.SetError(Me._txtShell_2, "")
        EP_txtShell_18.SetError(_txtShell_18, "")
    End Sub

    Private Sub _txtchan_0_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtchan_0.TextChanged
        txtchan_TextChanged(0)
    End Sub
    Private Sub _txtchan_0_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtchan_0.Validated
        'IDchan
        With objBre
            If .IDChan < .G1out + 2 * .G1AnExt + 2 * .lbRadialGap Then
                '.DiamChan = .G1out + 2 * .G1AnExt + 2 * .lbRadialGap
                EP_txtchan_0.SetError(_txtchan_0, HelpStringa(1020))
                _txtchan_0.BackColor = Color.LightPink
                .au_IDChan = False
            Else
                EP_txtchan_0.SetError(_txtchan_0, "")
            End If
        End With
        'InizChan2()
        'AggText()
    End Sub
    Private Sub _txtchan_1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtchan_1.TextChanged
        txtchan_TextChanged(1)
    End Sub

    Private Sub _txtchan_10_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtchan_10.TextChanged
        txtchan_TextChanged(10)
    End Sub

    Private Sub _txtchan_11_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtchan_11.TextChanged
        txtchan_TextChanged(11)
    End Sub

    Private Sub _txtChan_12_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtChan_12.TextChanged
        txtchan_TextChanged(12)
    End Sub

    Private Sub _txtChan_13_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtChan_13.TextChanged
        txtchan_TextChanged(13)
    End Sub

    Private Sub _txtchan_2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtchan_2.TextChanged
        txtchan_TextChanged(2)
    End Sub

    Private Sub _txtchan_3_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtchan_3.TextChanged
        txtchan_TextChanged(3)
    End Sub

    Private Sub _txtchan_4_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtchan_4.TextChanged
        txtchan_TextChanged(4)
    End Sub

    Private Sub _txtchan_5_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtchan_5.TextChanged
        txtchan_TextChanged(5)
    End Sub

    Private Sub _txtchan_6_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtchan_6.TextChanged
        txtchan_TextChanged(6)
    End Sub

    Private Sub _txtchan_7_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtchan_7.TextChanged
        txtchan_TextChanged(7)
    End Sub

    Private Sub _txtchan_8_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtchan_8.TextChanged
        txtchan_TextChanged(8)
    End Sub

    Private Sub _txtchan_9_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtchan_9.TextChanged
        txtchan_TextChanged(9)
    End Sub

    Private Sub chkAnelloEst2_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkAnelloEst2.CheckedChanged
        If chkAnelloEst2.Checked Then
            _txtChan_13.Visible = True
            Label6.Visible = True
            If objBre.G2AnExt <= 0 Then objBre.G2AnExt = 5
            If Not Aggiornando Then
                _txtChan_13.Text = GlobalRoutines.myStr(objBre.G2AnExt, 3, 2, 0)
                _txtChan_13_Validated(Me, Nothing)
            End If
        Else
            _txtChan_13.Visible = False
            Label6.Visible = False
            objBre.G2AnExt = 0
        End If

    End Sub

    Private Sub _txtChan_13_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtChan_13.Validated
        'AnEst
    End Sub

    Private Sub chkAnelloInt2_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkAnelloInt2.CheckedChanged
        If chkAnelloInt2.Checked Then
            _txtChan_12.Visible = True
            Label7.Visible = True
            If objBre.G2AnInt <= 0 Then objBre.G2AnInt = 5
            If Not Aggiornando Then
                _txtChan_12.Text = GlobalRoutines.myStr(objBre.G2AnInt, 3, 2, 0)
                _txtChan_12_Validated(Me, Nothing)
            End If
        Else
            _txtChan_12.Visible = False
            Label7.Visible = False
            objBre.G2AnInt = 0
        End If

    End Sub
    Private Sub _txtChan_12_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtChan_12.Validated
        'AnInt
        With objBre
            If .G2out < .IDChan + 2 * (.G2dente + .G2AnInt + .G2N) Then
                EP_txtchan_12.SetError(_txtChan_12, HelpStringa(1017))
            ElseIf .G2out > .IDChan + Math.Min(2 * (.G2dente + .G2AnInt + .G2N) * 2, 60) Then
                EP_txtchan_12.SetError(_txtChan_12, HelpStringa(1018))
            Else
                EP_txtchan_4.SetError(_txtchan_4, "") '_txtShell_4, "")
                EP_txtchan_3.SetError(_txtchan_3, "") '_txtShell_2, "")
                EP_txtchan_12.SetError(_txtChan_12, "")
                EP_txtShell_18.SetError(_txtShell_18, "")
            End If
        End With
        InizChan2()
        AggText()
    End Sub
    Private Sub _txtchan_3_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtchan_3.Validated
        'G2out
        Dim Testo As String
        With objBre
            If .G2out < .IDChan + 2 * (.G2dente + .G2AnInt + .G2N) + .offG2out Then
                Testo = HelpStringa(WRN_G2OUT)
                If MostraAiuto(WRN_G2OUT, RoutBase1.ChiaviMess.MessQuestion + _
                                          RoutBase1.ChiaviMess.MessHelpButton + _
                                          RoutBase1.ChiaviMess.MessYesNo) = _
                                          RoutBase1.ChiaviMess.MessSi Then
                    .offG2out = 0
                    .G2out = .IDChan + 2 * (.G2dente + .G2AnInt + .G2N) + .offG2out
                    .OffBCextScr = 0
                    EP_txtchan_3.SetError(_txtchan_3, "")
                    EP_txtchan_4.SetError(_txtchan_4, "")
                    EP_txtchan_12.SetError(_txtChan_12, "")
                Else
                    EP_txtchan_3.SetError(_txtchan_3, HelpStringa(1013))
                End If
            ElseIf .G2out > .IDChan + Math.Min(2 * (.G2dente + .G2AnInt + .G2N) * 2, 60) Then
                EP_txtchan_3.SetError(_txtchan_3, HelpStringa(1014))
            Else
                EP_txtchan_3.SetError(_txtchan_3, "")
                EP_txtchan_4.SetError(_txtchan_4, "")
                EP_txtchan_12.SetError(_txtChan_12, "")
            End If
        End With
        InizChan2()
        AggText()

    End Sub

    Private Sub _txtchan_4_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtchan_4.Validated
        'G2N
        With objBre
            If .G2out < .IDChan + 2 * (.G2dente + .G2AnInt + .G2N) Then
                EP_txtchan_4.SetError(_txtchan_4, HelpStringa(1015))
            ElseIf .G2out > .IDChan + Math.Min(2 * (.G2dente + .G2AnInt + .G2N) * 2, 60) Then
                EP_txtchan_4.SetError(_txtchan_4, HelpStringa(1016))
            Else
                EP_txtchan_4.SetError(_txtchan_4, "")
                EP_txtchan_3.SetError(_txtchan_3, "")
                EP_txtchan_12.SetError(_txtChan_12, "")
            End If
        End With
        InizChan2()
        AggText()

    End Sub

    Private Sub cmdRicalcCassa_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdRicalcCassa.Click
        GSKCH()
        AggText()
        EP_txtchan_12.SetError(Me._txtChan_12, "")
        EP_txtchan_4.SetError(Me._txtchan_4, "")
        EP_txtchan_3.SetError(Me._txtchan_3, "")
    End Sub

    Private Sub _txtShell_18_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtShell_18.TextChanged
        txtShell_TextChanged(18)
    End Sub

    Private Sub _txtchan_14_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtchan_14.TextChanged
        txtchan_TextChanged(14)
    End Sub
    Public Sub SetErrorRotaz()
        With objBre
            If .VerificaRotaz And 1 > 0 Then
                EP_txtCasson_2.SetError(_txtCasson_2, HelpStringa(1021))
            Else
                EP_txtCasson_2.SetError(_txtCasson_2, "")
            End If
            If .VerificaRotaz And 2 > 0 Then
                EP_txtCasson_0.SetError(_txtCasson_0, HelpStringa(1021))
            Else
                EP_txtCasson_0.SetError(_txtCasson_0, "")
            End If
            If .VerificaRotaz And 4 > 0 Then
                EP_txtCasson_1.SetError(_txtCasson_1, HelpStringa(1021))
            Else
                EP_txtCasson_1.SetError(_txtCasson_1, "")
            End If
        End With
    End Sub

    Private Sub cmdRicalcCasson_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRicalcCasson.Click
        objBre.MinDCasson = 0
        objBre.MaxDCasson = 0
        objBre.au_MinDCasson = True
        _txtCasson_4.BackColor = Color.White
        objBre.au_MaxDCasson = True
        _txtCasson_3.BackColor = Color.White
        InizCassonetto5()
        AggText()
    End Sub

    Private Sub _txtViti_1_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtViti_1.Validated
        If Not AggiornaViti(0) Then Call Fallimento(3)
    End Sub
    Private Sub _txtVitiInt_4_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtVitiInt_4.Validated
        If Not AggiornaViti(1) Then Call Fallimento(7)
    End Sub
    Private Sub _txtVitiExt_4_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtVitiExt_4.Validated
        If Not AggiornaViti(2) Then Call Fallimento(7)
    End Sub

    Private Sub _cmdGuarn1_0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmdGuarn1_0.Click
        cmdGuarn1_Click(0)
    End Sub

    Private Sub _cmdGuarn1_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmdGuarn1_1.Click
        cmdGuarn1_Click(1)
    End Sub

    Private Sub _optPasso_0_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _optPasso_0.CheckedChanged
        If Inizializzando Then Exit Sub
        If _optPasso_0.Checked Then objBre.iPasso = 1 Else objBre.iPasso = 2
    End Sub

    Private Sub _optPlastic_0_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _optPlastic_0.CheckedChanged
        With objBre
            If .TipoBL = 0 Then Exit Sub
            If _optPlastic_0.Checked Then .Considera = 0 Else .Considera = 1
            If Not nomefile = "" And Not InApertura Then cmdCalc_Click(3)
        End With
    End Sub

    Private Sub StatusBar1_PanelClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs)

    End Sub
    Private ReadOnly Property optPasso(ByVal i As Integer) As RadioButton
        Get
            Select Case i
                Case 0 : Return _optPasso_0
                Case 1 : Return _optPasso_1
                Case Else : Return Nothing
            End Select
        End Get
    End Property
    Private Sub _optTipo_0_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _optTipo_0.CheckedChanged
        If Inizializzando Then Exit Sub
        ModifiedData = True
        If _optTipo_0.Checked Then
            objBre.TipoBL = 0
            framDiff.Visible = False
            TabStrip1.TabPages(0).Tag = "i"
            Designvisible(False)
            Me.UpDownMat.Maximum = 7 - 1
        Else
            objBre.TipoBL = 1
            framDiff.Visible = True
            TabStrip1.TabPages(0).Tag = ""
            Designvisible(True)
            Me.UpDownMat.Maximum = NumMat - 1
        End If
        AggMateriali()
    End Sub

    Private Sub chkSuperSafe_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSuperSafe.CheckedChanged
        objBre.SuperSafe = chkSuperSafe.Checked
    End Sub

    Private Sub _txtLR_0_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtLR_0.TextChanged
        txtLR_TextChanged(0)
    End Sub

    Private Sub _txtLR_1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtLR_1.TextChanged
        txtLR_TextChanged(1)
    End Sub

    Private Sub _txtLR_10_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtLR_10.TextChanged
        txtLR_TextChanged(10)
    End Sub

    Private Sub _txtLR_11_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtLR_11.TextChanged
        txtLR_TextChanged(11)
    End Sub

    Private Sub _txtLR_12_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtLR_12.TextChanged
        txtLR_TextChanged(12)
    End Sub

    Private Sub _txtLR_13_TextAlignChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtLR_13.TextAlignChanged
        txtLR_TextChanged(13)
    End Sub

    Private Sub _txtLR_14_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtLR_14.TextChanged
        txtLR_TextChanged(14)
    End Sub

    Private Sub _txtLR_15_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtLR_15.TextChanged
        txtLR_TextChanged(15)
    End Sub

    Private Sub _txtLR_16_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtLR_16.TextChanged
        txtLR_TextChanged(16)
    End Sub

    Private Sub _txtLR_17_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtLR_17.TextChanged
        txtLR_TextChanged(17)
    End Sub

    Private Sub _txtLR_18_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtLR_18.TextChanged
        txtLR_TextChanged(18)
    End Sub

    Private Sub _txtLR_19_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtLR_19.TextChanged
        txtLR_TextChanged(19)
    End Sub

    Private Sub _txtLR_2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtLR_2.TextChanged
        txtLR_TextChanged(2)
    End Sub

    Private Sub _txtLR_20_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtLR_20.TextChanged
        txtLR_TextChanged(20)
    End Sub

    Private Sub _txtLR_21_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtLR_21.TextChanged
        txtLR_TextChanged(21)
    End Sub

    Private Sub _txtLR_22_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtLR_22.TextChanged
        txtLR_TextChanged(22)
    End Sub

    Private Sub _txtLR_23_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtLR_23.TextChanged
        txtLR_TextChanged(23)
    End Sub

    Private Sub _txtLR_3_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtLR_3.TextChanged
        txtLR_TextChanged(3)
    End Sub

    Private Sub _txtLR_4_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtLR_4.TextChanged
        txtLR_TextChanged(4)
    End Sub

    Private Sub _txtLR_5_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtLR_5.TextChanged
        txtLR_TextChanged(5)
    End Sub

    Private Sub _txtLR_6_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtLR_6.TextChanged
        txtLR_TextChanged(6)
    End Sub

    Private Sub _txtLR_7_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtLR_7.TextChanged
        txtLR_TextChanged(7)
    End Sub

    Private Sub _txtLR_8_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtLR_8.TextChanged
        txtLR_TextChanged(8)
    End Sub

    Private Sub _txtLR_9_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtLR_9.TextChanged
        txtLR_TextChanged(9)
    End Sub

    Private Sub _txtLR_24_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtLR_24.TextChanged
        txtLR_TextChanged(24)
    End Sub

    Private Sub _txtLR_25_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtLR_25.TextChanged
        txtLR_TextChanged(25)
    End Sub
    Private Sub _txtLR_26_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtLR_26.TextChanged
        txtLR_TextChanged(26)
    End Sub

    Private Sub _txtShell_18_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtShell_18.Validated
        With objBre
            If .G1out < .IDShell + 2 * (.G1dente + .G1AnInt + .G1N) Then
                EP_txtShell_18.SetError(_txtShell_18, HelpStringa(1015))
            ElseIf .G1out > .IDShell + 2 * (.G1dente + .G1AnInt + .G1N) + 2 Then
                EP_txtShell_18.SetError(_txtShell_18, HelpStringa(1016))
            Else
                EP_txtShell_18.SetError(_txtShell_18, "")
                EP_txtShell_2.SetError(_txtShell_2, "")
                EP_txtShell_16.SetError(_txtShell_16, "")
                EP_txtShell_4.SetError(_txtShell_4, "")
            End If
        End With
        InizShell()
        AggText()

    End Sub

    Private Sub chkNonCalcolaFondo_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkNonCalcolaFondo.CheckStateChanged
        Dim b As Boolean = chkNonCalcolaFondo.Checked
        Dim Testo As String
        objBre.NonCalcolaFondo = b
        'If b Then
        ' Testo = "N.A."
        ' chkAnelloInt.Checked = False
        ' chkAnelloInt.Enabled = False
        ' Else
        ' Testo = GlobalRoutines.myStr(0, 1, 2, 0)
        ' chkAnelloInt.Enabled = True
        ' End If
        Aggiornando = True
        _txtShell_15.Text = Testo
        _txtShell_14.Text = Testo
        _txtShell_12.Text = Testo
        _txtShell_13.Text = Testo
        _txtShell_13.Text = Testo
        Aggiornando = False
        _txtShell_15.Enabled = Not b
        _txtShell_12.Enabled = Not b
        _txtShell_14.Enabled = Not b
        _txtShell_16.Enabled = Not b
    End Sub

    Private Sub cmdEstensioneAutomatica_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdEstensioneAutomatica.Click
        Dim arco, corda As Single
        With objBre
            For .AreExtension = 10 To .AreBltScr Step 10
                INTSCR()
                If .NumScr > 0 And .BCIntScr > 0 Then
                    arco = 2 * PI / .NumScr
                    corda = 2 * System.Math.Sin(arco / 2) * .BCIntScr / 2
                    If corda > .Tir0.BSmin Then Exit For
                End If
            Next
        End With
        If e IsNot Nothing Then AggText()
    End Sub

    Private Sub mnuPrefBuckling_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuPrefBuckling.CheckStateChanged
        If Inizializzando Then Exit Sub
        Dim Testo As String
        optCalcolaBuckling = mnuPrefBuckling.CheckState = CheckState.Checked
        If optCalcolaBuckling Then
            'mnuPrefBuckling.CheckState = CheckState.Checked
            Testo = "Si"
        Else
            'mnuPrefBuckling.CheckState = CheckState.Unchecked
            Testo = "No"
        End If
        Monitor.Motore.Inizio.WriteIniFile("", "Preferenze BreLock", "Verifica cassonetto a buckling", Testo)
    End Sub
    Private Sub mnuVitiSnerv_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuVitiSnerv.CheckStateChanged
        If Inizializzando Then Exit Sub
        Dim Testo As String
        optVitiSnerv = mnuVitiSnerv.CheckState = CheckState.Checked
        If optVitiSnerv Then
            Testo = "Si"
        Else
            Testo = "No"
        End If
        Monitor.Motore.Inizio.WriteIniFile("", "Preferenze BreLock", "Verifica viti a snervamento", Testo)
        AggiornaValori(CodMAT.MAT_INTSCREWS)
        AggiornaValori(CodMAT.MAT_EXTSCREWS)
        AggiornaDisplay()
        Dim i As Integer
        For i = 3 To 10
            Calcolato(i) = False
        Next
    End Sub
    Private Sub mnuVitiSnerv_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuVitiSnerv.Click
        mnuVitiSnerv.Checked = Not mnuVitiSnerv.Checked
    End Sub
    Private Sub cmdMincasson_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMinCasson.Click
        With objBre
            For .ThkCasson = 10 To 100 Step 1
                cmdCalc_Click(5)
                If Calcolato(5) Then Exit Sub
            Next
        End With
    End Sub
    Private Sub mnuAutomEstensioni_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuAutomEstensioni.CheckStateChanged
        If Inizializzando Then Exit Sub
        Dim Testo As String
        optAutomEstensioni = mnuAutomEstensioni.CheckState = CheckState.Checked
        If optAutomEstensioni Then
            ' mnuAutomEstensioni.CheckState = CheckState.Checked
            Testo = "Si"
            Me.cmdEstensioneAutomatica.Visible = False
            Me._txtViti_10.BackColor = Color.Yellow
            Me._txtViti_10.Enabled = False
        Else
            '   mnuAutomEstensioni.CheckState = CheckState.Unchecked
            Testo = "No"
            Me.cmdEstensioneAutomatica.Visible = True
            Me._txtViti_10.BackColor = Color.White
            Me._txtViti_10.Enabled = True
        End If
        Monitor.Motore.Inizio.WriteIniFile("", "Preferenze BreLock", "Calcolo automatico estensioni", Testo)
        Dim i As Integer
        For i = 3 To 10
            Calcolato(i) = False
        Next
    End Sub
    Private Sub menSalvaCome_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menSalvaCome.Click
        SalvaCome()
        Aggiorna()
    End Sub

    Private Sub optdiv1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles optdiv1.CheckedChanged
        If optdiv1.Checked Then
            objBre.Norme = LibMat.Codes.div1MPa
        Else
            objBre.Norme = LibMat.Codes.div2MPa
        End If
    End Sub
    Private Sub menVitiAutomatiche_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles menVitiAutomatiche.CheckStateChanged
        If Inizializzando Then Exit Sub
        Dim Testo As String
        optVitiAutomatiche = menVitiAutomatiche.CheckState = CheckState.Checked
        If optVitiAutomatiche Then
            Me.mnuAutomEstensioni.CheckState = CheckState.Checked
            Testo = "Si"
            Me._cmdtir_0.Visible = False
            Me._txtViti_0.BackColor = Color.Yellow
            Me._txtViti_0.Enabled = False
            Me._cmdtir_1.Visible = False
            Me._txtVitiInt_0.BackColor = Color.Yellow
            Me._txtVitiInt_0.Enabled = False
            Me._cmdtir_2.Visible = False
            Me._txtVitiExt_0.BackColor = Color.Yellow
            Me._txtVitiExt_0.Enabled = False
        Else
            ' menVitiAutomatiche.CheckState = CheckState.Unchecked
            Testo = "No"
            Me._cmdtir_0.Visible = True
            Me._txtViti_0.BackColor = Color.White
            Me._txtViti_0.Enabled = True
            Me._cmdtir_1.Visible = True
            Me._txtVitiInt_0.BackColor = Color.White
            Me._txtVitiInt_0.Enabled = True
            Me._cmdtir_2.Visible = True
            Me._txtVitiExt_0.BackColor = Color.White
            Me._txtVitiExt_0.Enabled = True
        End If
        Monitor.Motore.Inizio.WriteIniFile("", "Preferenze BreLock", "Calcolo automatico viti", Testo)
        Dim i As Integer
        For i = 3 To 10
            Calcolato(i) = False
        Next

    End Sub
    Private Sub menVitiAutomatiche_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menVitiAutomatiche.Click
        menVitiAutomatiche.Checked = Not menVitiAutomatiche.Checked
    End Sub
    Private Sub mnuPrefBuckling_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuPrefBuckling.Click
        mnuPrefBuckling.Checked = Not mnuPrefBuckling.Checked
    End Sub
    Private Sub mnuAutomEstensioni_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuAutomEstensioni.Click
        mnuAutomEstensioni.Checked = Not mnuAutomEstensioni.Checked
    End Sub

    Private Sub mnuCalcolaTutto_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuCalcolaTutto.Click
        Dim i As Integer
        CalcolaTutto = True
        TabStrip1.SelectedIndex = 0
        For i = 1 To 8
            Calcolato(i) = False
        Next
        CalcolaTutto = False
        Cursor = Cursors.WaitCursor
        TabStrip1.SelectedIndex = TabStrip1.TabPages.Count - 1
        cmdCalc_Click(TabStrip1.TabPages.Count - 1)
        TabStrip1.SelectedIndex = TabStrip1.TabPages.Count - 1
        Cursor = Cursors.Default
    End Sub

    Private Sub _txtPT_0_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtPT_0.TextChanged
        txtPT_TextChanged(0)
    End Sub

    Private Sub _txtPT_1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtPT_1.TextChanged
        txtPT_TextChanged(1)
    End Sub

    Private Sub _txtPT_2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtPT_2.TextChanged
        txtPT_TextChanged(2)
    End Sub

    Private Sub _txtPT_3_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtPT_3.TextChanged
        txtPT_TextChanged(3)
    End Sub

    Private Sub _txtPT_4_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtPT_4.TextChanged
        txtPT_TextChanged(4)
    End Sub

    Private Sub _txtPT_5_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtPT_5.TextChanged
        txtPT_TextChanged(5)
    End Sub

    Private Sub _txtPT_6_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtPT_6.TextChanged
        txtPT_TextChanged(6)
    End Sub

    Private Sub _txtPT_7_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtPT_7.TextChanged
        txtPT_TextChanged(7)
    End Sub

    Private Sub _txtPT_8_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtPT_8.TextChanged
        txtPT_TextChanged(8)
    End Sub

    Private Sub _txtPT_9_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtPT_9.TextChanged
        txtPT_TextChanged(9)
    End Sub

    Private Sub chkNonCalcolaFondo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkNonCalcolaFondo.CheckedChanged

    End Sub

    Private Sub mnuCalcGeomAuto_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuCalcGeomAuto.Click
        objBre.au_IDChan = True
        Me._txtPT_9.BackColor = Color.White
        Me._txtchan_0.BackColor = Color.White
        objBre.au_IDSplitRing = True
        Me._txtSplit_1.BackColor = Color.White
        objBre.au_ThkAdpFC = True
        Me._txtCasson_13.BackColor = Color.White
        objBre.au_MinDCasson = True
        Me._txtCasson_4.BackColor = Color.White
        objBre.au_MaxDCasson = True
        Me._txtCasson_3.BackColor = Color.White
        objBre.au_BCIntScr = True
        Me._txtViti_2.BackColor = Color.White
        objBre.au_ThkAdpInnerRing = True
        Me._txtSplit_5.BackColor = Color.White
        objBre.au_ThkAdpLR = True
        Me._txtLR_5.BackColor = Color.White
        objBre.au_Diamintgola = True
        Me._txtLR_26.BackColor = Color.White
        objBre.au_ThkAdpSplitRing = True
        Me._txtSplit_6.BackColor = Color.White
        objBre.au_IDInnerRing = True
        Me._txtSplit_4.BackColor = Color.White
        objBre.au_ODInnerRing = True
        Me._txtSplit_3.BackColor = Color.White
    End Sub

    Private Sub cmbTipoCassonetto_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbTipoCassonetto.SelectedIndexChanged
        objBre.TipoCassonetto = CType(cmbTipoCassonetto.SelectedIndex, TipiCassonetto)
        Select Case objBre.TipoCassonetto
            Case TipiCassonetto.Conico
                _Label_55.Visible = True : _txtCasson_3.Visible = True : _lblMis_46.Visible = True
                _Label_56.Text = "Diametro medio minore"
            Case TipiCassonetto.CilindricoDisass, TipiCassonetto.CilindricoInLinea
                _Label_55.Visible = False : _txtCasson_3.Visible = False : _lblMis_46.Visible = False
                _Label_56.Text = "Diametro medio"
        End Select
    End Sub

    Private Sub _txtCasson_13_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtCasson_13.Validated
        'ThkAdpFC
        Dim Valore As Single = GlobalRoutines.ValVir(_txtCasson_13.Text)
        With objBre
            If Valore < CShort(.ThkMinFC + 0.49) Then
                EP_txtCasson_13.SetError(_txtCasson_13, HelpStringa(1042))
                _txtCasson_13.BackColor = Color.LightPink
                .au_ThkAdpFC = False
            ElseIf Valore > CShort(.ThkMinFC + 1.49) Then
                EP_txtCasson_13.SetError(_txtCasson_13, "")
                _txtCasson_13.BackColor = Color.LightPink
                .au_ThkAdpFC = False
            Else
                EP_txtCasson_13.SetError(_txtCasson_13, "")
            End If
        End With
    End Sub

    Private Sub _txtCasson_4_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtCasson_4.Validated
        'MinDCasson
        Dim Valore As Single = GlobalRoutines.ValVir(_txtCasson_4.Text)
        With objBre
            If Valore < .BCIntScr - 2 Then
                EP_txtCasson_4.SetError(_txtCasson_4, HelpStringa(1011))
                .au_MinDCasson = False
                _txtCasson_4.BackColor = Color.LightPink
            ElseIf Valore > .MaxDCasson And .TipoCassonetto = 0 Then
                EP_txtCasson_4.SetError(_txtCasson_4, HelpStringa(1012))
                .au_MinDCasson = False
                _txtCasson_4.BackColor = Color.LightPink
            ElseIf .MinDCasson > .BCIntScr + 2 And .TipoCassonetto = 2 Then
                EP_txtCasson_4.SetError(_txtCasson_4, HelpStringa(1047))
                .au_MinDCasson = False
                _txtCasson_4.BackColor = Color.LightPink
            Else
                EP_txtCasson_4.SetError(_txtCasson_4, "")
            End If
        End With
    End Sub

    Private Sub _txtLR_5_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtLR_5.Validated
        'ThkAdpLR
        Dim Valore As Single = GlobalRoutines.ValVir(_txtLR_5.Text)
        With objBre
            If Valore < .ThkMinLR Then
                EP_txtLR_5.SetError(_txtLR_5, HelpStringa(1044))
                _txtLR_5.BackColor = Color.LightPink
            Else
                EP_txtLR_5.SetError(_txtLR_5, "")
            End If
            .au_ThkAdpLR = False
        End With
    End Sub
    Private Sub _txtLR_26_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtLR_26.Validated
        'DiamIntGola
        Dim Valore As Single = GlobalRoutines.ValVir(_txtLR_26.Text)
        With objBre
            Dim ProfCava As Single = .lbProfCavaThreadedEnd
            If Valore < .Filetto.DMaxCas + 2 * ProfCava - 1 Then
                EP_txtLR_26.SetError(_txtLR_26, String.Format(HelpStringa(1048), ProfCava, .Filetto.DMaxCas))
                _txtLR_26.BackColor = Color.LightPink
            ElseIf Valore > .Filetto.DMaxCas + 2 * ProfCava + 1 Then
                EP_txtLR_26.SetError(_txtLR_26, String.Format(HelpStringa(1049), ProfCava, .Filetto.DMaxCas))
                _txtLR_26.BackColor = Color.LightPink
            Else
                EP_txtLR_26.SetError(_txtLR_26, "")
            End If
            .au_DiamIntGola = False
        End With
    End Sub

    Private Sub _txtSplit_5_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtSplit_5.Validated
        'ThkAdpInnerRing
        Dim Valore As Single = GlobalRoutines.ValVir(_txtSplit_5.Text)
        With objBre
            If Valore < .ThkReqInnerRing Then
                EP_txtSplit_5.SetError(_txtSplit_5, HelpStringa(1044))
                _txtSplit_5.BackColor = Color.LightPink
            Else
                EP_txtSplit_5.SetError(_txtSplit_5, "")
            End If
            .au_ThkAdpInnerRing = False
        End With
    End Sub

    Private Sub _txtSplit_6_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtSplit_6.Validated
        'ThkAdpSplitRing
        Dim Valore As Single = GlobalRoutines.ValVir(_txtSplit_6.Text)
        With objBre
            If Valore < .ThkReqSplitRing Then
                EP_txtSplit_6.SetError(_txtSplit_6, HelpStringa(1044))
                _txtSplit_6.BackColor = Color.LightPink
            Else
                EP_txtSplit_6.SetError(_txtSplit_6, "")
            End If
            .au_ThkAdpSplitRing = False
        End With

    End Sub

    Private Sub _txtViti_2_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtViti_2.Validated
        'BCIntScr
        Dim Valore As Single = GlobalRoutines.ValVir(_txtViti_2.Text)
        Dim BC As Single = CInt(BCIntScrMin())
        With objBre
            If Valore < BC - 2 Then
                EP_txtViti_2.SetError(_txtViti_2, String.Format(HelpStringa(1045), BC))
                _txtViti_2.BackColor = Color.LightPink
                .au_BCIntScr = False
            ElseIf Valore > BC + 2 Then
                EP_txtViti_2.SetError(_txtViti_2, String.Format(HelpStringa(1046), BC))
                _txtViti_2.BackColor = Color.LightPink
                .au_BCIntScr = False
            Else
                EP_txtViti_2.SetError(_txtViti_2, "")
            End If
        End With
    End Sub

    Private Sub _txtPT_9_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtPT_9.Validated
        'IDchan
        With objBre
            If .IDChan < .G1out + 2 * .G1AnExt + 2 * .lbRadialGap Then
                '.DiamChan = .G1out + 2 * .G1AnExt + 2 * .lbRadialGap
                EP_txtPT_9.SetError(_txtPT_9, HelpStringa(1020))
                _txtPT_9.BackColor = Color.LightPink
                .au_IDChan = False
            Else
                EP_txtPT_9.SetError(_txtchan_0, "")
            End If
        End With

    End Sub
End Class