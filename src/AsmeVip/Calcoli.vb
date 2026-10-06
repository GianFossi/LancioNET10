Option Strict Off
Option Explicit On 
Imports LibMat
Imports RoutBase1
Module Calcoli
    Private DistBocMin(,) As Single
    Private DistBoc(,) As Single
    Private Testo As String
    Private BanellRinf, AanellRinf As Single
	Private trh, TRHY As Single
	Private ContBkml As Short
	Private Aspp, ASS As Single
	Public TEMA As Short
	Public pHImin, pHImax As Single
	Private StriSt(60) As String
	Private SWR As Single
	Public rc As Single
	Private rcy As Single
	Public Ro As Single
	Private RoY, R As Single
	Private t0y, t0sy As Single
	Private Trs, Trsy As Single
	Public t0s, tts As Single
	Private TPR As Single
	Private ZSS, ZES As Single
	Private tmsy, E, tms, TNSY As Single
	Public S10, Asnell, Pm As Single
	Public Chart As String
	Public Nmin As Short
	Public PrPy, Stheta As Single
	Private tcs, Rsav As Single
	Public psig1, psig, psig2 As Single
	Private kk, KC, km As Single
	Private TCHY, TNHY, tch, KCY As Single
	Private SUX, SRX, S0X As Single
    Private SH, SHX, St As Single
	Private AHY, kt, SR As Single
	Public AH As Single
	Private ke, ky, LC As Single
	Private t0h, t0hy As Single
	Private LCY, LSH, LSHY As Single
	Private HC, HCY As Single
	Private TMH, YEH, TMHY As Single
	Private tsh, YSH, TSHY As Single
	Private s, RMT, T0, LC1 As Single
	Private AKo, KZ As Single
    Private Res As Short
    Private Ri, Rm As Single
    Private Gia() As Boolean
    Private Rf, t As Single
    Private Strain As Single
    Private Doppio As Boolean
    Function CalcolaBocchello(ByRef k As Short) As Boolean
        Dim Res As Boolean
        CalcolaBocchello = False
        Res = DisplayBocchello(k)
        If Res = 0 Then Exit Function
        Res = CalcolaElemento(Res)
        CalcolaBocchello = Res
    End Function
    Function CalcolaElemento(ByRef iBocc As Short) As Boolean
        Dim Res As Boolean, Resi, i As Short
        Dim Tipo As String
        Dim Elemento As String
        Dim Stringa1(20) As String
        Config(kLato).VerificandoPI = Config(0).VerificandoPI
        Call AcqNomi(Stringa1, 0)
        CalcolaElemento = False
        PrimaVoltaMWDT = True
        If iBocc <= 0 Then
            Resi = jInvolucr
            Tipo = Trim(Stringa1(Involucr(kLato, Resi).Tipo + 1))
            Elemento = Trim(Involucr(kLato, Resi).Mark)
            If Involucr(kLato, Resi).ES = 0 Then Involucr(kLato, Resi).ES = 1
            '??????????????If Res = 0 Then Exit Function
            nIndent = 0
            PrintlstRes("Calcolo di *** " & Elemento & " ***")
        Else
            kNozzle = iBocc
            Resi = Nozzles(kLato, iBocc).InvolucroSU
            Tipo = "Apertura"
            Elemento = Trim(Nozzles(kLato, iBocc).Mark)
            If Resi < 0 Then
                iBocc = -Resi
                Resi = Nozzles(kLato, -Resi).InvolucroSU
            End If
        End If
        If Involucr(kLato, Resi).Tipo < 5 Then
            If Not PrepRapp(Template, Tipo, Elemento, FileSt, mioApert.lstRapp) Then Exit Function
        End If
        If Resi > 0 Then
            If Involucr(kLato, Resi).Tipo = 1 Then 'fondi
                For i = Resi To 1 Step -1
                    If Involucr(kLato, i).Tipo = 0 Then
                        Config(kLato).TNS = Involucr(kLato, i).Spess
                        Config(kLato).dns = Involucr(kLato, i).dns
                        Config(kLato).ES = Involucr(kLato, i).ES
                        Config(kLato).ms = Involucr(kLato, i).ms
                        '         Config.di = Involucr(i).di
                        Exit For
                    Else
                        '         Config.di = 0
                    End If
                Next
            ElseIf Involucr(kLato, Resi).Tipo = 5 And iBocc > 0 Then
                jInvolucr = Resi
                kNozzle = iBocc
                formTab = New frmTab
                Try
                    formTab.Esci = True
                    If CType(objMemb(Involucr(kLato, jInvolucr).IndObject), wn_flan).Supercont(iBocc) Then
                        If Not CType(objMemb(Involucr(kLato, jInvolucr).IndObject), wn_flan).CoperchioAutoRinforzato Then
                            formTab.Show()
                            If formTab.OK Then
                                CheckDiafr((formTab.OK))
                                ' Do
                                ' System.Windows.Forms.Application.DoEvents()
                                ' Loop Until formDiaframma Is Nothing
                                '    mioApert.Enabled = True
                                '   AppActivate(mioApert.Text)
                            End If
                        End If
                    Else
                        Exit Function
                    End If
                Catch e As NoLinkFFException
                Catch ex As Exception
                    MessageBox.Show(ex.Message + vbCrLf + ex.StackTrace)
                End Try
                formTab.Dispose()
                formTab = Nothing
                Exit Function
            ElseIf Involucr(kLato, Resi).Tipo = 5 And iBocc = 0 Then
                kNozzle = 0
            ElseIf Involucr(kLato, Resi).Tipo = 8 Then
                If CType(CType(objMemb(Involucr(kLato, Resi).IndObject), wn_PT).Piastra, wn_FTC).IndiceDilat > -1 Then
                    If Not ContinuoAuto Then If iBocc >= 0 Then MessageBox.Show(clsInizio.ConvertiCr("Questo dilatatore è connesso con|il fascio tubiero a teste fisse.|  Calcolare quindi la P.T. corrispondente"))
                    CalcolaElemento = True
                    PrintlstRes("   *** differito ***")
                    Exit Function
                End If
                Call PrepRapp(Template, Tipo, Elemento, FileSt, mioApert.lstRapp)
                If Monitor.Motore.Problem.FileStream Is Nothing Then
                    CalcolaElemento = True
                    PrintlstRes("   *** rifiutato (dilatatore accoppiato) ***")
                    Exit Function
                End If
            End If
        End If
        If Resi > -1 Then Resi = CShort(CalcolaProgetto(Resi, iBocc))
        If Resi = 0 Then PrintlstRes("   *** terminato anormalmente ***")
        CalcolaElemento = CBool(Resi)
    End Function

    Function CalcolaProgetto(ByRef i As Short, ByRef iBocc As Short) As Boolean
        Dim wn As wn_flan
        Dim lContinuoAuto As Boolean
        Dim TipoCalc As Short
        CalcolaProgetto = False
        lContinuoAuto = ContinuoAuto
        If Involucr(kLato, i).Escluso Then CalcolaProgetto = True : Exit Function
        jInvolucr = i
        UG37a = 0
        SetDiv(kLato)
        td = TempDes()
        P0 = PressDes()
        pext = Pextdes()
        Try
            Select Case Involucr(kLato, i).Tipo
                Case 0 : Res = CylShells(i, iBocc)
                Case 1 : Res = Heads(i, iBocc)
                Case 2, 3 : Res = ConShells(i, iBocc)
                Case 4 : Res = Belts(i, iBocc)
                Case 5 : formTab = New frmTab
                    GlobalRoutines.FormatS("|")
                    wn = objMemb(Involucr(kLato, jInvolucr).IndObject)
                    If wn.Mem.LOOSE = 5 And Involucr(kLato, jInvolucr).AccoppK = 0 Then
                        wn.Mp(45) = 0 : wn.Mp(46) = 0 : wn.Mp(173) = 0
                        wn.Zp(45) = 0 : wn.Zp(46) = 0 : wn.Zp(173) = 0
                    End If
                    wn.Vari()
                    formTab.VisualTipo = 1
                    Res = Rif(lContinuoAuto, wn)
                    If Res Then
                        If Pextdes() > 0 And kLato = 3 Then
                            VerificandoPext = True
                            formTab.VisualTipo = 2
                            formTab.Finito = False
                            TipoCalc = wn.TipCalc
                            wn.TipCalc = 2
                            formTab.cmdCalc.Visible = True
                            Call Rif(lContinuoAuto, wn)
                            wn.TipCalc = TipoCalc
                            VerificandoPext = False
                        End If
                        'calcolo diaframma elastico
                    End If
                    CheckDiafr(Res <> 0)
                    ' Do
                    ' System.Windows.Forms.Application.DoEvents()
                    ' Loop Until formDiaframma Is Nothing
                    mioApert.Enabled = True
                    AppActivate(mioApert.Text)
                    formTab.Dispose()
                    formTab = Nothing
                    CalcolBocch()
                Case 6
                    Res = CType(objMemb(Involucr(kLato, jInvolucr).IndObject), wn_PT).Calcola 'PT
                Case 7 : Res = CalcTubi() 'tubi
                Case 8
                    CType(objMemb(Involucr(kLato, jInvolucr).IndObject), wn_PT).Calcola()
                    Res = -1
                Case 9
                    If Not ContinuoAuto Then
                        If Not VerificandoPI Then
                            frmPartAB.DefInstance.ShowDialog()
                        Else
                            MessageBox.Show("Non viene effettuato alcun calcolo in prova idraulica per i setti partitori")
                        End If
                    Else
                        If Not VerificandoPI Then
                            'UPGRADE_WARNING: Form evento frmPartAB.Activated presenta un nuovo comportamento. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup2065"'
                            frmPartAB.DefInstance.frmPartAB_Activated(frmPartAB.DefInstance, New System.EventArgs)
                            frmPartAB.DefInstance.Command1_Click(frmPartAB.DefInstance.Command1, New System.EventArgs)
                        End If
                    End If
                    Res = -1
            End Select
            CalcolaProgetto = Res
        Catch ex As NoLinkFFException
            CalcolaProgetto = 0
        Catch e As Exception
            MessageBox.Show(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Function
    Private Function Rif(ByVal lContinuoAuto As Boolean, ByVal wn As wn_flan) As Boolean
Rif:
        formTab.SetPagina(1)
        If Not lContinuoAuto Then
            formTab.ShowDialog()
        Else
            formTab.cmdCliccato = False
            formTab.cmdCalc_Click(Nothing, New EventArgs)
            If wn.qbflan = 5 Then
                lContinuoAuto = False
                GoTo Rif
            End If
            If formTab.cmdCalc.Enabled And wn.TipCalc = 3 Then
                formTab.cmdCliccato = False
                formTab.cmdCalc_Click(Nothing, New EventArgs)
                If wn.qbflan = 5 Then
                    lContinuoAuto = False
                    GoTo Rif
                End If
            End If
            formTab.cmdOk_Click(Nothing, New EventArgs)
            'continuoauto
        End If
        'mioApert.Enabled = True
        'AppActivate(mioApert.Text)
        Rif = formTab.OK
    End Function
    Function CalcolaTutto() As Short
        Dim k, i, Res, Ntot As Short
        Dim iTot, ii As Short
        CalcolaTutto = False
        InterrompiMAWP = False
        CloseioutS((mioApert.lstRapp))
        Distruggi(colMAWP)
        Distruggi(colMDMT)
        CostrMDMT(colMDMT)
        NoHeader = True
        StoCalcolandoTutto = True
        If ContinuoAuto Then
            For k = 1 To Config(0).NumeroLati
                For i = 1 To Config(k).Ninvolucri
                    Ntot = Ntot + 1
                Next i
            Next k
            mioApert.Refresh()
            Monitor.Motore.ProgrInizio("Calcolo automatico apparecchio", "AsmeVip", mioApert)
        End If
        If VerificandoPI Then
            mioGen.PulsPI.Text = "Off"
        End If
        Config(0).VerificandoPI = CShort(VerificandoPI)
        For ii = 1 To 2
            If ii = 2 Then
                If Config(0).VerifPI <> 1 Then Exit For
                VerificandoPI = True
                Config(0).VerificandoPI = CShort(True)
                If ContinuoAuto Then
                    Monitor.Motore.ProgrAmmazza()
                    Monitor.Motore.ProgrInizio("Verifiche automatiche in P.I.", "AsmeVip", mioApert)
                    iTot = 0
                End If
            End If
            For k = 1 To Config(0).NumeroLati
                For i = 1 To Config(k).Ninvolucri
                    kLato = k
                    kNozzle = 0
                    jInvolucr = i
                    Res = CalcolaElemento(0)
                    System.Windows.Forms.Application.DoEvents()
                    If Res = 0 Or InterrompiMAWP Then GoTo Fine
                    iTot = iTot + 1
                    If ContinuoAuto Then Monitor.Motore.Avanzamento = iTot * 100.0# / Ntot
                Next
            Next
        Next ii
Fine:
        VerificandoPI = False
        Config(0).VerificandoPI = CShort(False)
        CalcolaTutto = Res
        If ContinuoAuto Then Monitor.Motore.ProgrAmmazza()
        StoCalcolandoTutto = False
        If div = 2 Then CalcRappMax()
    End Function
    Sub CylPres(ByRef Press As Single, ByRef T0 As Single, ByRef R As Single, ByRef Z As Single, ByRef s As Single, ByRef E As Single, ByRef SWR As Single)
        Select Case Config(kLato).DC
            Case 0, 1, 2, 9, 10, 11
                ASME1(Press, Z, T0, R, s, E)
            Case 3, 4, 5
                ASME1(Press, Z, T0, R, s, E) '(sarebbe 2)
            Case 6, 7, 8 'EuroNOrm
                Euro(Press, T0, R, s, E)
        End Select
        Exit Sub
    End Sub
    Private Sub Euro(ByRef Press As Single, ByVal T0 As Single, ByVal R As Single, ByVal s As Single, ByVal E As Single)
        If SWR > 0 Then
            Rm = R - 0.5 * T0
        Else
            Rm = R + 0.5 * T0
        End If
        Press = T0 * s * E / Rm
        USStr(1) = "(7.4-3)"
    End Sub
    Private Sub ASME1(ByRef Press As Single, ByRef Z As Single, ByVal T0 As Single, ByVal R As Single, ByVal s As Single, ByVal E As Single)
        If SWR > 0 Then
            USStr(1) = " 1-1 "
            Press = T0 * s * E / (R - 0.4 * T0)
            Ri = R - 0.4 * T0
        Else
            USStr(1) = " UG-27(c) "
            Press = T0 * s * E / (R + 0.6 * T0)
            Ri = R
        End If
        If Press > (0.385 * s * E) Or T0 > Ri / 2 Then
            USStr(1) = " 1-2 "
            If SWR > 0 Then
                Z = (R / (R - T0)) ^ 2
            Else
                Z = ((R + T0) / R) ^ 2
            End If
            Press = s * E * ((Z - 1) / (Z + 1))
        End If
    End Sub
    Function CylShells(ByRef jmemb As Short, ByRef iBocc As Short) As Short
        Dim i As Short
        Dim Issue As New ASMERES
        Dim j As Short
        Dim tms1 As Single
        Dim s, T0 As Single
        Dim Testo, uu As String
        Dim Dout As Single
        Dim ifl As Short
        Dim MUS, MUM, TES As Single
        Dim TCSY, KZ As Single
        Dim FileFor As New Str50
        Dim valido As Boolean
        Dim Stringa(3) As String
        Dim Stringa1(3) As String
        Dim Risult(3) As String
        Dim Arch(3) As Short
        Dim dAiu(3) As String
        Dim junk, jRec As Short
        Dim Ls As Single
        Dim nn As Short
        Dim pr, pr0 As Single
        Dim MatGr As String = ""
        Dim RisExam As Short
        Dim Sn As Single
        Dim lContinuoAuto As Boolean
        CylShells = False
        lContinuoAuto = ContinuoAuto
        jInvolucr = jmemb '9-1-99
        STStr = "Cylindrical shell"
        Try
            If Involucr(kLato, jmemb).di <= 0 Then Involucr(kLato, jmemb).di = Config(kLato).di
            If Involucr(kLato, jmemb).di <= 0 Then Involucr(kLato, jmemb).di = Involucr(kLato, jmemb).dns - 2 * Involucr(kLato, jmemb).Spess
            If Involucr(kLato, jmemb).di <= 0 Or P0 = 0 Then Call Erro(16) : Exit Function
            If Involucr(kLato, jmemb).OS = 0 Then Aspp = Involucr(kLato, jmemb).cs * CondizioniCorrose Else Aspp = Involucr(kLato, jmemb).OS
InizioC:
            AggiustaHydr(kLato, jmemb, 0, P0, VerificandoPI)
            swn = 0
            TEMA = Config(kLato).DC Mod 3
            If Involucr(kLato, jmemb).ms < 2 Then GoTo 5220
            For i = 1 To 30
                If System.Math.Abs(Involucr(kLato, jmemb).dns - MMM(2, i)) < 1 Then GoTo 5130
            Next i
            Call Erro(3) : Exit Function
5130:       Config(kLato).dogg = MMM(2, i)
            Ro = Config(kLato).dogg / 2
            RoY = Ro / inc
            R = Ro
            SWR = 1
            tts = 0
            If TEMA = 0 Then GoTo 5290
            ' MIN.REQ.PIPE SHELL THK.FOR TEMA STANDARD
            ' ****************************************
            If Config(kLato).mv <= 0 Then
                If TEMA = 1 Then j = 20 Else j = 21
            Else
                If TEMA = 1 Then j = 22 Else j = 23
            End If
            If MMM(j, i) = 0 Then
                Call Erro(4)
                tts = 0
            Else
                tts = MMM(j, i)
            End If
            GoTo 5290
5220:       SWR = 0
            tts = 0
            If TEMA > 0 Then tts = MinPlateThk(Involucr(kLato, jmemb).di)
            'TTS = TTX
            rc = Involucr(kLato, jmemb).di / 2 + Aspp
            rcy = rc / inc
            R = rc
5290:       If VerificandoPI Then
                s = Involucr(kLato, jmemb).Shydr
                uu = "in condizioni di prova idraulica"
            Else
                s = Involucr(kLato, jmemb).St
                uu = "in condizioni di progetto"
            End If
            If s = 0 Then
                Testo = "   Non è stata specificata la tensione ammissibile." & vbCrLf
                Testo = Testo & uu & vbCrLf & "per la membratura " & Trim(Involucr(kLato, jmemb).Mark)
                If MessageBox.Show(clsInizio.ConvertiCr(Testo), "AsmeVip", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) = DialogResult.Cancel Then Exit Function
                'If ContinuoAuto Then Exit Function
                If Not DatiProgCyl(kLato, jmemb) Then Exit Function
                GoTo InizioC
            End If
            e = Involucr(kLato, jmemb).ES
            Call SuperCylThk(P0, td, T0, R, ZSS, ZES, s, e, uu, SWR, Trs, Involucr(kLato, jmemb), Config(kLato))
            Call SuperCylThk(P0, td, TRV, R, ZSS, ZES, s, e, uu, SWR, Trs, Involucr(kLato, jmemb), Config(kLato))
            Trsy = Trs / inc
            t0s = T0
            t0sy = t0s / inc
            tms = T0 + Aspp
            tmsy = tms / inc
5500:       If VerificandoPI Then
                Stringa(1) = " Required Thickness in HydroTest " & UnitLength & " to =" & GlobalRoutines.myStr(tms * kLength, 2 + IncrVirgola, 3 - IncrVirgola, 0)
            Else
                Stringa(1) = " Minimum Code Design Shell Thickness  " & UnitLength & " to =" & GlobalRoutines.myStr(tms * kLength, 2 + IncrVirgola, 3 - IncrVirgola, 0)
            End If
            TPR = tms
            If TEMA > 0 Then
                Stringa(2) = " Minimum TEMA Nominal Shell Thickness " & UnitLength & " to'=" & GlobalRoutines.myStr(tts * kLength, 2 + IncrVirgola, 3 - IncrVirgola, 0)
                If tts > TPR Then TPR = tts
            Else
                Stringa(2) = ""
            End If
5550:       If Involucr(kLato, jmemb).ms < 2 Then GoTo 5590
            '    CALL StdPipe(INT(i))'GOSUB 9000
            tms1 = Involucr(kLato, jmemb).Spess
            If tts > 0 Then tms1 = tts
            If TPR > tts Then tms1 = TPR
            If tms1 = 0 Then
                Tubo = New LibMat.clsPipe
                Tubo.DoveMotore = Monitor.Motore
                Tubo.Diam = MMM(2, i)
                Tubo.Scelta(clsInizio.Archdir, clsInizio.DiscoTem)
                tms1 = Tubo.Spess
                'UPGRADE_NOTE: È possibile che l'oggetto Tubo non venga eliminato finché non venga raccolto nel Garbage Collector. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1029"'
                Tubo = Nothing
            End If
            '  Involucr(kLato, jmemb).Spess = tms1
5590:       Stringa(3) = " Adopted Nominal Shell Thickness     " & UnitLength
            Risult(3) = GlobalRoutines.myStr(Involucr(kLato, jmemb).Spess * kLength, 2 + IncrVirgola, 3 - IncrVirgola, 0)
            Risult(1) = "" : Risult(2) = ""
            If Involucr(kLato, jmemb).Spess = 0 Then Risult(3) = GlobalRoutines.myStr(TPR * kLength, 2 + IncrVirgola, 3 - IncrVirgola, 0)
5595:       If Not lContinuoAuto Then
                If Not Monitor.Motore.InputDati(3, RTrim(Involucr(kLato, jmemb).Mark) & ", adopted thickness", Stringa, Risult, "", Arch, dAiu) Then Exit Function
            Else
                'continuoauto
            End If
            If Involucr(kLato, jmemb).Spess <> GlobalRoutines.ValVir(Risult(3)) / kLength Then AzzeraLocalThk()
            Involucr(kLato, jmemb).Spess = GlobalRoutines.ValVir(Risult(3)) / kLength ' -INT(-VAL(Risult$(3)))
            If Involucr(kLato, jmemb).Spess < tts Or Involucr(kLato, jmemb).Spess < tms Then
                lContinuoAuto = False
                Testo = "Lo spessore adottato è insufficiente.|   Cosa vuoi fare ?"
                Stringa1(1) = "Modificare il dato"
                Stringa1(2) = "Procedere ugualmente"
                junk = Monitor.Motore.Quale(2, "Spessore adottato " & Involucr(kLato, jmemb).Mark.Trim, Stringa1, "", 1, Testo)
                Select Case junk
                    Case 2
                        If ContinuoAuto Then
                            nIndent = 6
                            PrintlstRes(uu)
                            nIndent = 0
                        End If
                    Case Else
                        GoTo 5590
                End Select
            End If
            TNSY = Involucr(kLato, jmemb).Spess / inc
            If Involucr(kLato, jmemb).ms > 0 Then GoTo 5760
            MUM = 0.06 * Involucr(kLato, jmemb).Spess
            If MUM > 0.254 Then MUM = 0.254
            MUS = 0.3
            TES = Involucr(kLato, jmemb).Spess
5597:       If MUM >= MUS Then GoTo 5760
            TES = Involucr(kLato, jmemb).Spess - MUS
            If TES < tms Then
                lContinuoAuto = False
                Testo = "   Lo spessore adottato " & GlobalRoutines.myStr(TES * kLength, 3, 2, 0) & UnitLength & " al net" '+ vbCrLf
                Testo = Testo & "to della tolleranza (" & GlobalRoutines.myStr(MUS * kLength, 3, 2, 0) & UnitLength & " )" & vbCrLf & "è inferiore" '+ vbCrLf
                Testo = Testo & "allo spessore di calcolo (" & GlobalRoutines.myStr(tms * kLength, 3, 2, False) & UnitLength & " )." & vbCrLf
                uu = Testo
                Testo = Testo & "   Cosa vuoi fare ?"
                Stringa(1) = "Modificare i dati di input"
                Stringa(2) = "Procedere ugualmente"
                junk = Monitor.Motore.Quale(2, "Mill tolerance " & Involucr(kLato, jmemb).Mark.Trim, Stringa, "", 1, Testo)
                Select Case junk
                    Case 2
                        If ContinuoAuto Then
                            nIndent = 6
                            PrintlstRes(uu)
                            nIndent = 0
                        End If
                        GoTo 5760
                    Case Else
                        If Not DatiProgCyl(kLato, jmemb) Then Exit Function
                        GoTo InizioC
                End Select
            End If
5760:       tcs = Involucr(kLato, jmemb).Spess - Aspp
            TCSY = tcs / inc : Rsav = R
            If Not RTrim(Config(kLato).lkStr) = "MAWP" And Config(0).CalcMAWP = 1 And Not VerificandoPI Then
                '--------------------------MAWP------------------
                For i = 1 To 4
                    Call T0andS(i, jmemb, T0, s)
                    If SWR = 0 Then
                        If i < 3 Then R = Involucr(kLato, jmemb).di / 2 + Involucr(kLato, jmemb).OS Else R = Involucr(kLato, jmemb).di / 2 + Involucr(kLato, jmemb).OS + Involucr(kLato, jmemb).cs * CondizioniCorrose
                    End If
                    Call CylPres(Involucr(kLato, jmemb).MAWP(i - 1), T0, R, KZ, s, e, SWR)
                Next
            End If
            '------------------Pressione PI EuroNorm---------
            If div = 2 Then
                pHImin = Pr10p2p3p3(valido)
                R = Involucr(kLato, jmemb).di / 2 + Involucr(kLato, jmemb).OS
                CylPres(pHImax, Involucr(kLato, jmemb).Spess, R, KZ, Involucr(kLato, jmemb).Shydr, e, SWR)
                If Not lContinuoAuto Then
                    EUInformaPI(valido)
                End If
            End If
            '------------------------------------------------
            SpxBExt = 0
            If Not RTrim(Config(kLato).lkStr) = "MAWP" And Config(kLato).Vacuum And Not VerificandoPI Then
                If Involucr(kLato, jmemb).L0 <= 0 Then
                    Testo = "Poiché non è stata definita la lunghezza libera|è impossibile calcolare a pressione esterna."
                    MessageBox.Show(clsInizio.ConvertiCr(Testo))
                Else
                    jRec = Involucr(kLato, jmemb).indice(1 - 1)
                    psig = 0
                    Dout = Involucr(kLato, jmemb).di + 2 * Involucr(kLato, jmemb).Spess
                    Ls = Involucr(kLato, jmemb).L0 / (Involucr(kLato, jmemb).SottoTipo + 1)
                    If Dout <= 0 Then
                        Testo = "La geometrici della membratura " & Trim(Involucr(kLato, jInvolucr).Mark) & vbCrLf
                        Testo = Testo & "non sono stati definiti correttamente."
                        MessageBox.Show(Testo)
                        CylShells = False
                        Exit Function
                    End If
                    PressExtCil(Dout, tcs, Ls, Textdes, jRec, psig, psig1, psig2, Chart)
                    If psig = 0 Or psig1 = 0 Then Exit Function
                    trPressExt(0, 0, 0, SpxBExt)
                    If Involucr(kLato, jmemb).SottoTipo > 0 Then
                        If div = 2 Then
                            MessageBox.Show("anelli di rinforzo su cilindri non programmati per EuroNOrm")
                        End If
                        If Not AnellRinf(Pextdes, Dout, SpxBExt, tcs, Ls, jRec) Then CylShells = False : Exit Function
                    End If
                    If Not lContinuoAuto Then
                        If AlertPext(psig1) = ChiaviMess.MessCancel Then GoTo 5500
                    End If
                End If
            End If
            ' ********************************
            ' SHELL PRINTOUT SUBROUTINE
            ' ********************************
            ifl = FreeFile()
            FilOpen = RTrim(clsInizio.Archdir) & "\RTF\ASME10.DAT"
            Try
                FileOpen(ifl, FilOpen, OpenMode.Input, , OpenShare.Shared)
            Catch e As Exception
                MessageBox.Show(e.Message + vbCrLf + e.StackTrace)
                CylShells = False
                Exit Function
            End Try
            For i = 0 To 43 : StriSt(i) = LineInput(ifl) : Next '140506
            FileClose(ifl)
            Select Case Config(kLato).DC
                Case 0, 1, 2, 9, 10, 11
                    Call CylShellPr(jmemb, s)
                Case 3, 4, 5
                    FileFor.Str_Renamed = RTrim(clsInizio.DiscoRam) & "ROTFLFOR.OUT"
                    Testa1(jmemb)
                    Call CILPRI(Involucr(kLato, jmemb), Config(kLato), FileFor)
                    Stamparo("", FileFor.Str_Renamed) ' clsInizio.DiscoRam + "ROTFLFOR.OUT"
                    If Not (RTrim(Config(kLato).lkStr) = "MAWP") And Config(0).CalcMAWP = 1 And Not VerificandoPI Then Call StamMAWP(jmemb)
                Case 6, 7, 8
                    Call EUCylShellPr()
            End Select
            If Not VerificandoPI Then
                CylVacuumPr(jmemb)
                StrainTreat()
            End If
20160:      For nn = Involucr(kLato, jmemb).inizio To Involucr(kLato, jmemb).Fine
                SWR = Nozzles(kLato, nn).SWR : If SWR > 9 Then SWR = SWR - 10
                If iBocc = 0 Or nn = iBocc Then
                    Call PrepRapp(Template, "Apertura su cilindro", Nozzles(kLato, nn).Mark, FileSt, mioApert.lstRapp, 2)
                    Select Case Config(kLato).DC
                        Case 0, 1, 2, 9, 10, 11
                            If Not BranchesCal(1, rc, s, Involucr(kLato, jmemb).di, TRV, Trs, tcs, KZ, Nozzles(kLato, nn).EffN, SWR, Int(nn), jmemb) Then Exit Function
                        Case 3, 4, 5
                            If Not Valid2(nn, jmemb) Then CylShells = False : Exit Function
                            Issue.SR = SpxBExt
                            Issue.SpCop = 0
                            Issue.AllN = 0
                            Issue.VerificandoPI = VerificandoPI
                            Nozzles(kLato, nn).Pdes = P0
                            Nozzles(kLato, nn).Tdes = td
                            AD550f(nn)
                            Do
                                If Not VerificaAllN(nn, jmemb, Sn) Then CylShells = False : Exit Function
                            Loop Until Sn > 0
                            Nozzles(kLato, nn).Risult = 0
                            If Not ContinuoAuto Then Nozzles(kLato, nn).BNoRinf = False
Rif:                        OP(Nozzles(kLato, nn), NozzAdd(kLato, nn), Issue)
                            RisExam = ExamRis(nn, jmemb, Issue)
                            Select Case RisExam
                                Case -1 : CylShells = False : Exit Function
                                Case 0
                                Case 1 : GoTo Rif
                                Case 11 ' si vuole calcolare comunque
                                    Nozzles(kLato, nn).Risult = 2
                                    Nozzles(kLato, nn).BNoRinf = True
                                    GoTo Rif
                            End Select
                            Call BraPrint(nn, jmemb, False, 0, 0, 0, "", 0, 0.0#)
                            OPPRI(Nozzles(kLato, nn), FileFor)
                            Stamparo("", FileFor.Str_Renamed) 'clsInizio.DiscoRam + "ROTFLFOR.OUT"
                            If RisExam <> -2 And Not VerificandoPI Then
                                Call SuperRatings(pr, pr0, nn, MatGr)
                                Call BraMAWP(nn, jmemb, pr, pr0, False, False, LSH)
                                Call MAWPpri(nn)
                            End If
                        Case 6, 7, 8
                            MessageBox.Show("Euronorm in CylShells2")
                    End Select
                    If Not BocBoc(nn, jmemb, FileFor) Then CylShells = False : Exit Function
                End If
            Next nn
20161:      CylShells = True
        Catch ex As Exception
            If Erl() = 5290 And Err.Number = 48 Then
                MostraAiuto(IDH_MANCAASMELIB)
            Else
                MessageBox.Show(ex.Message + vbCrLf + ex.StackTrace)
            End If
            CylShells = False
        End Try
        Config(kLato).TNS = Involucr(kLato, jmemb).Spess
        Config(kLato).dns = Involucr(kLato, jmemb).dns
        Config(kLato).ES = Involucr(kLato, jmemb).ES
        Config(kLato).ms = Involucr(kLato, jmemb).ms
    End Function
    Sub CylThk(ByRef P0 As Single, ByRef td As Single, ByRef T0 As Single, ByRef R As Single, ByRef KZ As Single, ByRef s As Single, ByRef E As Single, ByRef SWR As Single)
        Dim KZq, Ri As Single
        ' CYLINDRICAL SHELL THICKNESS SUBROUTINE
        ' **************************************
        If E = 0 Then E = 1
        Try
            If P0 > (0.385 * s * E) Then
Thick:          USStr(0) = " 1-2 "
                If s * E - P0 <= 0 Then
                    If iMAWP > 0 Then
                        P0 = 0.9 * 2 * E
                    Else
                        Call Erro(20)
                        T0 = 0
                        Exit Sub
                    End If
                End If
                KZ = (s * E + P0) / (s * E - P0)
                KZq = System.Math.Sqrt(KZ)
                If SWR > 0 Then
                    T0 = R * (KZq - 1) / KZq
                Else
                    T0 = R * (KZq - 1)
                End If
                Exit Sub
            End If
            If SWR > 0 Then
                USStr(0) = " 1-1 "
                T0 = P0 * R / (s * E + 0.4 * P0)
                Ri = R - T0
            Else
                USStr(0) = " UG-27(c) "
                T0 = P0 * R / (s * E - 0.6 * P0)
                Ri = R
            End If
            If T0 > Ri / 2 Then GoTo Thick
        Catch ex As Exception
            MessageBox.Show(ex.Message + vbCrLf + ex.StackTrace)
        End Try
    End Sub

    Sub Ell21(ByRef SH As Single, ByRef E As Single, ByRef kk As Single, ByRef LC As Single, ByRef t0h As Single, ByRef t0hy As Single)
        uh = " UG-32(d) " 'Ellittico 2:1
        If E = 0 Then E = 1
        kk = 1
        t0h = P0 * LC * kk / (2 * SH * E - 0.2 * P0)
        t0hy = t0h / inc
    End Sub

    Sub Ell21INV(ByRef Press As Single, ByRef SH As Single, ByRef E As Single, ByRef kk As Single, ByRef LC As Single, ByRef t0h As Single, ByRef t0hy As Single)
        kk = 1
        Press = 2 * SH * E * t0h / (kk * LC + 0.2 * t0h)
    End Sub

    Sub Ellittk(ByRef ke As Single, ByRef kk As Single)
        If ((ke * 10) - Int(ke * 10)) > 0.5 Then
            ke = (Int(ke * 10) + 1) / 10
        Else
            ke = Int(ke * 10) / 10
        End If
        kk = (2 + ke ^ 2) / 6
        If (((kk * 100) - Int(kk * 100)) * 10) > 5 Then
            kk = (Int(kk * 100) + 1) / 100
        Else
            kk = Int(kk * 100) / 100
        End If
    End Sub

    Sub EllittQ(ByRef SH As Single, ByRef E As Single, ByRef ke As Single, ByRef kk As Single, ByRef LC As Single, ByRef t0h As Single, ByRef t0hy As Single)
11590:  uh = " 1-4(c) "
        Call Ellittk(ke, kk)
11690:  t0h = P0 * LC * kk / (2 * SH * E - 0.2 * P0)
        t0hy = t0h / inc
    End Sub

    Sub EllittQINV(ByRef Press As Single, ByRef SH As Single, ByRef E As Single, ByRef ke As Single, ByRef kk As Single, ByRef LC As Single, ByRef t0h As Single, ByRef t0hy As Single)
        Call Ellittk(ke, kk)
        Press = 2 * SH * E * t0h / (kk * LC + 0.2 * t0h)
    End Sub
    Sub Erro(ByRef n As Short, Optional ByVal Titolo As String = "")
        Dim N1 As Short
        N1 = n : If n > 120 Then N1 = 12
        Dim Riga As String = Helpstringa(2500 + N1)
        If Not ContinuoAuto Then
            MostraAiuto(2500 + N1, ChiaviMess.MessInformation Or ChiaviMess.MessOkOnly Or ChiaviMess.MessHelpButton, _
            "", Titolo, True)
        Else
            PrintlstRes(Riga)
        End If
    End Sub

    Sub HeadPress(ByRef jmemb As Short, ByRef Press As Single, ByRef SH As Single, ByRef E As Single, ByRef ky As Single, ByRef LC As Single, ByRef t0h As Single, ByRef t0hy As Single, ByRef kk As Single, ByRef ke As Single, ByRef km As Single, ByRef kt As Single)
        Select Case Involucr(kLato, jmemb).ms
            Case 7, 8 : Call SferaINV(Press, SH, E, ky, LC, t0h, t0hy)
            Case 6 : Call Toro6INV(Press, SH, E, kt, km, LC, t0h, t0hy)
            Case 3, 4, 5 : Call Toro6INV(Press, SH, E, kt, km, LC, t0h, t0hy) ' Call ToroINV(Press, SH, E, km, LC, t0h, t0hy)
            Case 2 : Call EllittQINV(Press, SH, E, ke, kk, LC, t0h, t0hy)
            Case 1 : Call Ell21INV(Press, SH, E, kk, LC, t0h, t0hy)
        End Select
    End Sub

    Function Heads(ByRef jmemb As Short, ByRef iBocc As Short) As Short
        Dim iRis As Short
        Dim fit1, fit2 As Single
        Dim fit3 As Single
        Dim Issue2 As New ASMERES
        Dim Issue1 As New ASMERES
        Dim nm, ifl, j As Short
        Dim TPR, T0 As Single
        Dim L0Y, H0Y, R0Y As Single
        Dim tth, E As Single
        Dim Indmat, jRec As Short
        Dim valido As Boolean
        Dim nn As Short
        Dim SWR, rc As Single
        Dim Nfield As Short
        Dim Stringa(10) As String
        Dim Risult(10) As String
        Dim Arch(10) As Short
        Dim dAiu(10) As String
        Dim i As Short
        Dim Cambiato As Boolean
        Dim Sn As Single
        Dim FileFor As New Str50
        Dim Issue As New ASMERES
        Dim RisExam As Short
        Dim pr, pr0 As Single
        Dim MatGr As String = ""
        Dim lContinuoAuto As Boolean
        Dim Par As String
        Dim fact() As Single = Nothing
        Par = "\par "
        Heads = False
        lContinuoAuto = ContinuoAuto
        jInvolucr = jmemb '9-1-99
        STStr = ""
        '     IF Config(kLato).di = 0 THEN Config(kLato).di = Involucr(kLato,jmemb).di
        If P0 = 0 Then Call Erro(17) : Exit Function
        Try
            'input fondo ----------------------------------------------------------
            AggiustaHydr(kLato, jmemb, 0, P0, VerificandoPI)
RifHeads:
            Select Case Involucr(kLato, jmemb).ms 'era HT
                Case 1
3890:               'di = 1000 shared
                    Involucr(kLato, jmemb).H0 = Involucr(kLato, jmemb).di / 4
                    H0Y = Involucr(kLato, jmemb).H0 / inc
                Case 2
                    'INPUT H0
                    H0Y = Involucr(kLato, jmemb).H0 / inc
                Case 3
                    '  Involucr(kLato, jmemb).L0 = Involucr(kLato, jmemb).di
                Case 6
                    L0Y = Involucr(kLato, jmemb).L0 / inc
                    R0Y = Involucr(kLato, jmemb).R0 / inc
                    kt = Involucr(kLato, jmemb).L0 / Involucr(kLato, jmemb).R0
                    If (1 / kt) < 0.06 Then Call Erro(8) : Exit Function
                Case 7
                    'INPUT L0
                Case 8 'calotta
            End Select
            '???  IF Involucr(kLato,jmemb).ES > Config(kLato).ES THEN Involucr(kLato,jmemb).ES = Config(kLato).ES
4260:       If Involucr(kLato, jmemb).OS = 0 Then AH = Involucr(kLato, jmemb).cs * CondizioniCorrose Else AH = Involucr(kLato, jmemb).OS
            AHY = AH / inc
            SUX = Involucr(kLato, jmemb).SU
            SR = 0
            If Involucr(kLato, jmemb).SU > 80000.0! * mpa And Not VerificandoPI Then
4510:           SR = 20000
                SRX = SR / psi
            Else
                SR = 0
                S0X = Involucr(kLato, jmemb).S0
            End If
            If VerificandoPI Then
                St = Involucr(kLato, jmemb).Shydr
                SH = Involucr(kLato, jmemb).Shydr
            Else
                St = Involucr(kLato, jmemb).St
                SH = Involucr(kLato, jmemb).St
            End If
            If Involucr(kLato, jmemb).S0 > 0 And SR > 0 Then
                SHX = SRX * St / Involucr(kLato, jmemb).S0
            End If
            swn = 1
            If Involucr(kLato, jmemb).ms < 8 Then
                If Involucr(kLato, jmemb).ms < 2 Then GoTo 6620
                If Involucr(kLato, jmemb).di = 0 Then Involucr(kLato, jmemb).di = Config(kLato).dogg - 2 * Config(kLato).TNS
                If (Involucr(kLato, jmemb).di - Int(Involucr(kLato, jmemb).di)) > 0.5 Then Involucr(kLato, jmemb).di = Int(Involucr(kLato, jmemb).di) + 1 Else Involucr(kLato, jmemb).di = Int(Involucr(kLato, jmemb).di)
6620:           If Config(kLato).DC Mod 3 > 0 And Not VerificandoPI Then tth = MinPlateThk(Involucr(kLato, jmemb).di) Else tth = 0
                tts = tth
            End If
            If SH = 0 Then
                Testo = "   Non è stata specificata la tensione ammissibile" & vbCrLf
                Testo = Testo & "per la membratura " & Trim(Involucr(kLato, jmemb).Mark) & vbCrLf
                If VerificandoPI Then
                    Testo = Testo & "nelle condizioni di prova idraulica."
                Else
                    Testo = Testo & "nelle condizioni di progetto."
                End If
                If MessageBox.Show(clsInizio.ConvertiCr(Testo), "AsmeVip", MessageBoxButtons.OKCancel) = DialogResult.Cancel Then Exit Function
                If Not DatiProgFon(kLato, jmemb) Then Exit Function
                GoTo RifHeads
            End If
            'calcolo spessore per bocchello
            Call SpessXbocch(SH, ky, ke, LC, t0h, t0hy, jmemb, AH)
            '---------------------------------------------------
            LSH = LC
            LCY = LC / inc
            LSHY = LCY
            YSH = ky
            tsh = t0h
            TSHY = tsh / inc
            If Involucr(kLato, jmemb).ms > 2 Then GoTo 6860
            HC = Involucr(kLato, jmemb).H0 + AH
            HCY = HC / inc
            LC = Involucr(kLato, jmemb).di + 2 * AH
            GoTo 6960
6860:       If Involucr(kLato, jmemb).ms > 5 Then GoTo 6930
            'da rivedere procedura a codice del fondo torosferico XXXXXXXXXXXXXXXXX( tra UG-32(e) e 1-4(d) )
            Select Case Involucr(kLato, jInvolucr).ms
                Case 3
                    Involucr(kLato, jmemb).Spess = Int((0.885 * P0 * (Involucr(kLato, jmemb).di + AH) + AH * (SH * Involucr(kLato, jmemb).ES - 0.1 * P0)) / (SH * Involucr(kLato, jmemb).ES - 1.87 * P0)) + 1
6880:               Involucr(kLato, jmemb).L0 = Involucr(kLato, jmemb).di ' + 2 * Involucr(kLato, jmemb).Spess
                    Involucr(kLato, jmemb).R0 = 0.06 * Involucr(kLato, jmemb).L0
                    L0Y = Involucr(kLato, jmemb).L0 / inc
                    R0Y = Involucr(kLato, jmemb).R0 / inc
                    kt = Involucr(kLato, jmemb).L0 / Involucr(kLato, jmemb).R0
                Case 4
                    KC = Involucr(kLato, jmemb).R0 + AH
                    LC = Involucr(kLato, jmemb).L0 + AH
                    kt = LC / KC
                Case 5
                    KC = Involucr(kLato, jmemb).R0 + AH
                    LC = Involucr(kLato, jmemb).L0 + AH
                    kt = LC / KC
            End Select
6930:       KC = Involucr(kLato, jmemb).R0 + AH
            LC = Involucr(kLato, jmemb).L0 + AH
6960:       LCY = LC / inc
            E = Involucr(kLato, jmemb).ES
            Select Case Config(kLato).DC
                Case 0, 1, 2, 9, 10, 11
                    If Involucr(kLato, jmemb).ms = 8 Then
                        Cambiato = True
                        Involucr(kLato, jmemb).ms = 7
                    End If
                    Call HeadThk(jmemb, SH, 1.0!, ky, LC, t0h, t0hy, kk, ke, km, kt) 'GOSUB 11500
                    If t0h = 0 Then Heads = False : Exit Function
                    If Cambiato Then Involucr(kLato, jmemb).ms = 8
                    trh = t0h
                    Call HeadThk(jmemb, SH, E, ky, LC, t0h, t0hy, kk, ke, km, kt) 'GOSUB 11500
                Case 3, 4, 5
                    Call Fon(Involucr(kLato, jmemb), Config(kLato), P0, td, T0)
                    t0h = T0
                Case 6, 7, 8
                    If Involucr(kLato, jmemb).ms = 8 Then
                        Cambiato = True
                        Involucr(kLato, jmemb).ms = 7
                    End If
                    Call EUHeadThk(SH, Involucr(kLato, jmemb).Dati(4 - 4), 1.0!, LC, t0h, kt)
                    If t0h = 0 Then Heads = False : Exit Function
                    If Cambiato Then Involucr(kLato, jmemb).ms = 8
                    trh = t0h
                    Call EUHeadThk(SH, Involucr(kLato, jmemb).Dati(4 - 4), E, LC, t0h, kt)
            End Select
            t0s = t0h
            TRHY = trh / inc
            YEH = ky
            TMH = t0h + AH
            TMHY = TMH / inc
            Nfield = 0
            If Involucr(kLato, jmemb).ms < 3 Or Involucr(kLato, jmemb).ms > 5 Then GoTo 7160
            Stringa(1) = " Assumed Head Thickness         " & UnitLength & GlobalRoutines.myStr(Involucr(kLato, jmemb).Spess * kLength, 2 + IncrVirgola, 3 - IncrVirgola, 0)
            Stringa(2) = " Assumed Inside Skirt Diameter  " & UnitLength & GlobalRoutines.myStr(Involucr(kLato, jmemb).L0 * kLength, 3 + IncrVirgola, 3 - IncrVirgola, 0)
            Stringa(3) = " Assumed Crown Radius            " & UnitLength & GlobalRoutines.myStr(Involucr(kLato, jmemb).L0 * kLength, 3 + IncrVirgola, 3 - IncrVirgola, 0)
            Stringa(4) = " Assumed Knuckle Radius          " & UnitLength & GlobalRoutines.myStr(Involucr(kLato, jmemb).R0 * kLength, 3 + IncrVirgola, 3 - IncrVirgola, 0)
            Stringa(5) = " r/L                             " & GlobalRoutines.myStr(1 / kt, 2, 3, False)
            Nfield = 5
7160:       If VerificandoPI Then
                Stringa(1 + Nfield) = " Required Thickness in HydroTest" & UnitLength & GlobalRoutines.myStr(TMH * kLength, 2 + IncrVirgola, 3 - IncrVirgola, 0)
            Else
                Stringa(1 + Nfield) = " Min. Code Design Head Thickness " & UnitLength & GlobalRoutines.myStr(TMH * kLength, 2 + IncrVirgola, 3 - IncrVirgola, 0)
            End If
            TPR = -Int(-TMH)
            If Involucr(kLato, jmemb).ms < 6 Then
                Nfield = Nfield + 1
                If Config(kLato).DC Mod 3 = 0 Then GoTo 7220
                Stringa(1 + Nfield) = " Min.TEMA Nominal Head Thickness " & UnitLength & GlobalRoutines.myStr(tth * kLength, 2 + IncrVirgola, 3 - IncrVirgola, 0)
                If tth > TPR Then TPR = -Int(-tth)
            End If
            Nfield = Nfield + 1
7220:       Stringa(1 + Nfield) = " Min.Head Thickness After Forming" & UnitLength
            For i = 1 To Nfield : Risult(i) = "" : Next
            Nfield = Nfield + 1
            Risult(Nfield) = GlobalRoutines.myStr(Involucr(kLato, jmemb).Spess * kLength, 2 + IncrVirgola, 3 - IncrVirgola, 0)
            If Involucr(kLato, jmemb).Spess = 0 Then Risult(Nfield) = GlobalRoutines.myStr(TPR * kLength, 2 + IncrVirgola, 3 - IncrVirgola, 0)
6595:       If Not lContinuoAuto Then
                If Not Monitor.Motore.InputDati(Nfield, RTrim(Involucr(kLato, jmemb).Mark) & ", adopted thickness", Stringa, Risult, "", Arch, dAiu) Then Exit Function
            Else
                'continuoauto
            End If
            If Involucr(kLato, jmemb).Spess <> GlobalRoutines.ValVir(Risult(Nfield)) / kLength Then AzzeraLocalThk()
            Involucr(kLato, jmemb).Spess = GlobalRoutines.ValVir(Risult(Nfield)) / kLength
            If Involucr(kLato, jmemb).Spess < TMH Or Involucr(kLato, jmemb).Spess < tth Then
                Beep()
                lContinuoAuto = False
                If Not ContinuoAuto Then GoTo 6595
            End If
            TNHY = Involucr(kLato, jmemb).Spess / inc
            tch = Involucr(kLato, jmemb).Spess - AH
            TCHY = tch / inc
            If Involucr(kLato, jmemb).ms < 3 Or Involucr(kLato, jmemb).ms >= 7 Then GoTo 7590
            RMT = 3 * Involucr(kLato, jmemb).Spess
            If div = 2 Then RMT = 2 * Involucr(kLato, jmemb).Spess
            If Involucr(kLato, jmemb).ms > 5 Then GoTo 7330
            GoTo 7390
            '     If Involucr(kLato, jmemb).L0 = (Involucr(kLato, jmemb).di + 2 * Involucr(kLato, jmemb).Spess) Then GoTo 7390
            '     GoTo 6880
7330:       If Involucr(kLato, jmemb).Tipo < 6 And Not VerificandoPI Then
                If Involucr(kLato, jmemb).L0 > (Involucr(kLato, jmemb).di + 2 * Involucr(kLato, jmemb).Spess) Then Call Erro(9) : Exit Function
                If Involucr(kLato, jmemb).L0 < (Involucr(kLato, jmemb).di + 2 * Involucr(kLato, jmemb).Spess) Then GoTo 7370
                If Involucr(kLato, jmemb).R0 = 0.06 * Involucr(kLato, jmemb).L0 Then GoTo 7390
                Call Erro(10) : Exit Function
7370:           If Involucr(kLato, jmemb).R0 > 0.06 * Involucr(kLato, jmemb).L0 Then GoTo 7390
                Call Erro(11) : Exit Function
7390:           If Involucr(kLato, jmemb).R0 < RMT Then
                    Testo = "   Il raggio del ginocchio di " & GlobalRoutines.myStr(Involucr(kLato, jmemb).R0, 4, 2, False) & " mm risulta|"
                    If div = 2 Then
                        Testo = Testo & "inferiore al minimo 2t (" & GlobalRoutines.myStr(RMT, 4, 2, False) & " mm).|"
                    Else
                        Testo = Testo & "inferiore al minimo 3t (" & GlobalRoutines.myStr(RMT, 4, 2, False) & " mm).|"
                    End If
                    Testo = Testo & "Propongo di modificare i dati"
                    If MessageBox.Show(clsInizio.ConvertiCr(Testo), "AsmeVip", MessageBoxButtons.YesNo) = DialogResult.Yes Then 'Exit Function
                        Involucr(kLato, jmemb).ms = 6
                        If Not DatiProgFon(kLato, jmemb) Then Exit Function
                        GoTo RifHeads
                    End If
                End If
            End If
            'Stop
7570:       Involucr(kLato, jmemb).H0 = Involucr(kLato, jmemb).L0 - System.Math.Sqrt(Involucr(kLato, jmemb).L0 * (Involucr(kLato, jmemb).L0 - 2 * Involucr(kLato, jmemb).R0) - Involucr(kLato, jmemb).di * (Involucr(kLato, jmemb).di - 4 * Involucr(kLato, jmemb).R0) / 4)
            H0Y = Involucr(kLato, jmemb).H0 / inc
7590:
            If Not RTrim(Config(kLato).lkStr) = "MAWP" And Config(0).CalcMAWP = 1 And Not VerificandoPI Then
                '------------------MAWP---------------------
                For iMAWP = 1 To 4
                    Call T0andS(iMAWP, jmemb, T0, s)
                    If iMAWP > 2 Then LC1 = LC Else LC1 = LC - Involucr(kLato, jmemb).cs * CondizioniCorrose
                    Select Case Config(kLato).DC
                        Case 0, 1, 2, 9, 10, 11
                            Call HeadPress(jmemb, Involucr(kLato, jmemb).MAWP(iMAWP - 1), s, E, ky, LC1, T0, t0hy, kk, ke, km, kt)
                        Case 3, 4, 5
                            Call HeadPress(jmemb, Involucr(kLato, jmemb).MAWP(iMAWP - 1), s, E, ky, LC1, T0, t0hy, kk, ke, km, kt)
                        Case 6, 7, 8
                            Call EUHeadPress(Involucr(kLato, jmemb).MAWP(iMAWP - 1), s, Involucr(kLato, jmemb).Dati(4 - 4), E, LC1, T0, kt)
                    End Select
                Next
            End If
            iMAWP = 0
            '------------------Pressione PI EuroNorm---------
            If div = 2 Then
                pHImin = Pr10p2p3p3(valido)
                R = Involucr(kLato, jmemb).di / 2 + Involucr(kLato, jmemb).OS
                EUHeadPress(pHImax, Involucr(kLato, jmemb).Shydr, Involucr(kLato, jmemb).Dati(4 - 4), E, LC1, T0, kt)
                If Not lContinuoAuto Then
                    EUInformaPI(valido)
                End If
            End If
            '------------------------------------------------
            SpxBExt = 0
            If Not RTrim(Config(kLato).lkStr) = "MAWP" And Config(kLato).Vacuum And Not VerificandoPI Then
                HeadsBuckPar(Ro, Involucr(kLato, jmemb).Spess)
                Asnell = 0.125 / Ro * (Involucr(kLato, jmemb).Spess - AH)
                If Asnell <= 0 Then
                    Testo = "A causa di dati geometrici erronei|è impossibile calcolare a pressione esterna."
                    MessageBox.Show(clsInizio.ConvertiCr(Testo))
                Else
                    jRec = Involucr(kLato, jmemb).indice(1 - 1)
                    Indmat = Matdim(jRec).Indmat
                    psig = System.Math.Abs(Matdim(jRec).BValor(Asnell, Textdes, Indmat, CodiceStress, Chart, 0))
                    psig1 = psig * (Involucr(kLato, jmemb).Spess - AH) / Ro
                    If AlertPext(psig1) = ChiaviMess.MessCancel Then GoTo RifHeads
                    trPressExt(0, 0, 0, SpxBExt)
                End If
            End If
            If kLato = 3 Then
                jRec = Involucr(kLato, jmemb).indice(1 - 1)
                Indmat = Matdim(jRec).Indmat
                For i = 1 To 4
                    Call T0andS(i, jmemb, T0, s)
                    HeadsBuckPar(Ro, T0)
                    Asnell = 0.125 / Ro * T0
                    If i = 2 Or i = 4 Then fit1 = TempDes() Else fit1 = 20
                    psig = System.Math.Abs(Matdim(jRec).BValor(Asnell, fit1, Indmat, CodiceStress, Chart, 0))
                    psig1 = psig * T0 / Ro
                    Involucr(kLato, jInvolucr).MAWP2(i - 1) = psig1
                Next
            End If
            ' ********************************
            ' HEAD PRINTOUT SUBROUTINE
            ' ********************************
            Dim div2 As Boolean
            ifl = FreeFile()
            Select Case Config(kLato).DC
                Case 0, 1, 2, 9, 10, 11 : FilOpen = RTrim(clsInizio.Archdir) & "\RTF\ASME11.DAT"
                Case 3, 4, 5 : FilOpen = RTrim(clsInizio.Archdir) & "\RTF\ASME112.DAT"
                Case 6 : MessageBox.Show("EuroNorm in Heads2")
            End Select
            Try
                FileOpen(ifl, FilOpen, OpenMode.Input, , OpenShare.Shared)
            Catch exc As Exception
                MessageBox.Show(exc.Message + vbCrLf + exc.StackTrace)
            End Try
            For i = 1 To 55 : StriSt(i) = LineInput(ifl) : Next '140506
            FileClose(ifl)
            div2 = False
            Select Case Config(kLato).DC
                Case 0, 1, 2, 9, 10, 11
                    Call HeadsPr(jmemb)
                Case 3, 4, 5
                    div2 = True
                    FileFor.Str_Renamed = RTrim(clsInizio.DiscoRam) & "ROTFLFOR.OUT"
                    Testa1(jmemb)
                    Call FONPRI(Involucr(kLato, jmemb), Config(kLato), FileFor)
                    Stamparo("", FileFor.Str_Renamed) ' clsInizio.DiscoRam + "ROTFLFOR.OUT"
                    If Not RTrim(Config(kLato).lkStr) = "MAWP" And Config(0).CalcMAWP = 1 Then Call StamMAWP(jmemb)
                Case 6, 7, 8
                    Call EUHeadsPr(AH)
            End Select
            If Not VerificandoPI Then
                HeadsVacuumPr(jmemb)
                StrainTreat()
            End If
            '-------------------MDMT-----------------------------------
            If Not RTrim(Config(kLato).lkStr) = "MAWP" And Not VerificandoPI Then Call MinTemp(0, jmemb, 0.0!, 0.0!)
            '----------------------------------------------------------
            With Monitor.Motore.Problem
                .Printa(StriSt(36))  'CHR$(12)
                Dim NBocc As Short
                NBocc = Involucr(kLato, jmemb).Fine - Involucr(kLato, jmemb).inizio + 1
21750:          If div2 And NBocc > 1 And iBocc = 0 Then
                    ReDim DistBoc(Involucr(kLato, jmemb).Fine, Involucr(kLato, jmemb).Fine)
                    ReDim DistBocMin(Involucr(kLato, jmemb).Fine, Involucr(kLato, jmemb).Fine)
                    ReDim Gia(NBocc)
                    For nn = Involucr(kLato, jmemb).inizio To Involucr(kLato, jmemb).Fine
                        SWR = Nozzles(kLato, nn).SWR : If SWR > 9 Then SWR = SWR - 10
                        For nm = nn + 1 To Involucr(kLato, jmemb).Fine
                            'FileFor.Str = Trim(clsInizio.DiscoRam) + "\SCRATCH.TXT"
                            Issue1.SR = SpxBExt : Issue2.SR = SpxBExt
                            Issue1.VerificandoPI = VerificandoPI
                            Issue2.VerificandoPI = VerificandoPI
                            COUPS(Nozzles(kLato, nn), Nozzles(kLato, nm), iRis, fit1, fit2, fit3, Issue1, Issue2, FileFor, NozzAdd(kLato, nn), NozzAdd(kLato, nm))
                            Select Case iRis
                                Case 1 'il primo nozzle è radiale al cilindro su fondo non sferico
                                    j = nn
                                    Testo = Nozzles(kLato, nn).Mark
                                    Warn(j, nn, nm)
                                Case 11 ''il secondo nozzle è radiale al cilindro su fondo non sferico
                                    j = nm
                                    Testo = Nozzles(kLato, nm).Mark
                                    Warn(j, nn, nm)
                                Case 2 'fuori del fondo
                                    Testo = "Uno dei due bocchelli " & Trim(Nozzles(kLato, nn).Mark) & ",|"
                                    Testo = Testo & Trim(Nozzles(kLato, nm).Mark) & " cade fuori del fondo.|"
                                    Testo = Testo & "Correggere i dati di posizionamento."
                                    MessageBox.Show(clsInizio.ConvertiCr(Testo))
                                    Heads = False
                                    Exit Function
                                Case 3 'DL=0
                                    Testo = "I dati di posizione per " & Trim(Nozzles(kLato, nn).Mark) & "e|"
                                    Testo = Testo & Trim(Nozzles(kLato, nm).Mark) & " non sono validi:|"
                                    Testo = Testo & "I bocchelli si sovrappongono. (Distanza " & Format(fit3, "#####") & " mm)"
                                    MessageBox.Show(clsInizio.ConvertiCr(Testo))
                                    Heads = False
                                    Exit Function
                                Case -2
                                    Testo = "I due bocchelli " & Trim(Nozzles(kLato, nn).Mark) & " e "
                                    Testo = Testo & Trim(Nozzles(kLato, nm).Mark) & " non interferiscono.|"
                                    Testo = Testo & "Saranno quindi verificati come aperture isolate."
                                    If Config(0).Verbose Then MessageBox.Show(clsInizio.ConvertiCr(Testo))
                                    DistBoc(nn, nm) = fit3
                                    DistBoc(nm, nn) = fit3
                                    DistBocMin(nn, nm) = fit1 + fit2 + (Nozzles(kLato, nn).DiIn + Nozzles(kLato, nm).DiIn) / 2
                                    DistBocMin(nm, nn) = DistBocMin(nn, nm)
                                Case -1 'interferiscono ma si possono calcolare
                                    If fit3 < 3 * (Nozzles(kLato, nn).DiIn + Nozzles(kLato, nm).DiIn) / 2 Then
                                        Testo = "La distanza fra gli assi dei bocchelli     |"
                                        Testo = Testo & RTrim(Nozzles(kLato, nn).Mark) & " e " & RTrim(Nozzles(kLato, nm).Mark)
                                        Testo = Testo & "|non è conforme alla regola AD-501(3).    |"
                                        Testo = Testo & "(" & Str(Int(fit3)) & ">" & Str(Int(3 * (Nozzles(kLato, nn).DiIn + Nozzles(kLato, nm).DiIn) / 2)) & " mm)|"
                                        Testo = Testo & "Si vuole rivedere il posizionamento bocchelli.?"
                                        Testo = Testo & "Se si risponde negativamente la norma verrà ignorata."
                                        If MessageBox.Show(clsInizio.ConvertiCr(Testo), "AsmeVip", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then Heads = False : Exit Function
                                    Else
                                        Testo = "Le lunghezze di compensazione dei due bocchelli " & Trim(Nozzles(kLato, nn).Mark) & " e "
                                        Testo = Testo & Trim(Nozzles(kLato, nm).Mark) & " interferiscono.|"
                                        Testo = Testo & "Essi saranno quindi verificati come aperture non isolate."
                                        If Config(0).Verbose Then MessageBox.Show(clsInizio.ConvertiCr(Testo))
                                    End If
                                    DistBoc(nn, nm) = fit3
                                    DistBoc(nm, nn) = fit3
                                    DistBocMin(nn, nm) = fit1 + fit2 + (Nozzles(kLato, nn).DiIn + Nozzles(kLato, nm).DiIn) / 2
                                    DistBocMin(nm, nn) = DistBocMin(nn, nm)
                                Case Else
                                    If Not ContinuoAuto Then Nozzles(kLato, nn).BNoRinf = False
                                    '                  If Nozzles(kLato, nn).Risult <> 0 Then
                                    'Rif1:             RisExam = ExamRis(nn, jmemb, Issue1)
                                    '                  Select Case RisExam
                                    '                    Case -1:  Heads = False: Exit Function
                                    '                    Case 0:
                                    '                    Case 1: GoTo Rif1
                                    '                    Case 11 ' si vuole calcolare comunque
                                    '                        Nozzles(kLato, nn).Risult = 2
                                    '                        Nozzles(kLato, nn).BNoRinf = True
                                    '                        GoTo Rif
                                    '                  End Select
                                    '                  End If
                                    If Not ContinuoAuto Then Nozzles(kLato, nm).BNoRinf = False
                                    '                  If Nozzles(kLato, nm).Risult <> 0 Then
                                    'Rif2:             Select Case ExamRis(nm, jmemb, Issue2)
                                    '                    Case -1:  Heads = False: Exit Function
                                    '                    Case 0:
                                    '                    Case 1: GoTo Rif2
                                    '                    Case 11 ' si vuole calcolare comunque
                                    '                        Nozzles(kLato, nm).Risult = 2
                                    '                        Nozzles(kLato, nm).BNoRinf = True
                                    '                        GoTo Rif
                                    '                  End Select
                                    '                  End If
                            End Select
                        Next nm
                    Next nn
                    .Printa(Par)
                    .Printa("NUMBER OF OPENINGS ON THE HEAD " & NBocc & Par)
                    .Printa(Par)
                    .Printa(" Pos. Nozzle Mark             |Int.dia.    " & Par)
                    For i = 1 To NBocc
                        j = i - 1 + Involucr(kLato, jmemb).inizio
                        .Printa(GlobalRoutines.FormatS(" ##) \                     \ _|####.0 mm ", i, Nozzles(kLato, j).Mark, Nozzles(kLato, j).DiIn) & Par)
                    Next
                    .Printa(Par)
                    .Printa(" Study of all the pairs of openings" & Par)
                    .Printa(" Pos1 Pos2         Spacing       Min spacing for separated openings" & Par)
                    For i = 1 To NBocc - 1
                        For j = i + 1 To NBocc
                            .Printa(GlobalRoutines.FormatS("  ##  ##     ######.0 mm          #######.0 mm", i, j, DistBoc(i, j), DistBocMin(i, j)) & Par)
                        Next j
                    Next i
                    .Print(Par)
                    .Printa("   The lengths of reinforcement along the heads will be reduced by the least ratio " & Par)
                    .Printa("of the actual spacing to the 'not accoupled spacing', when applicable." & Par)
                    .Printa("This procedure may lead to a certain conseravitivism." & Par)
                    .Printa("The resulting factors follow:" & Par)
                    .Printa(" Pos. Nozzle Mark             |Factor    " & Par)
                    ReDim fact(NBocc)
                    For i = Involucr(kLato, jmemb).inizio To Involucr(kLato, jmemb).inizio + NBocc - 1
                        fact(i - Involucr(kLato, jmemb).inizio + 1) = 1
                        For j = Involucr(kLato, jmemb).inizio To Involucr(kLato, jmemb).inizio + NBocc - 1
                            If i <> j And DistBoc(i, j) > 0 Then
                                If DistBoc(i, j) / DistBocMin(i, j) < 1 Then fact(i) = DistBoc(i, j) / DistBocMin(i, j)
                            End If
                        Next j
                        .Printa(GlobalRoutines.FormatS(" ##) \                     \ |  #.000 ", i, Nozzles(kLato, Involucr(kLato, jmemb).inizio + i - 1).Mark, fact(i - Involucr(kLato, jmemb).inizio + 1)) & Par)
                    Next i
                End If
            End With
            For nn = Involucr(kLato, jmemb).inizio To Involucr(kLato, jmemb).Fine
                SWR = Nozzles(kLato, nn).SWR : If SWR > 9 Then SWR = SWR - 10
                If iBocc = 0 Or nn = iBocc Then
                    Call PrepRapp(Template, "Apertura su fondo", Nozzles(kLato, nn).Mark, FileSt, mioApert.lstRapp, 2)
                    Select Case Config(kLato).DC
                        Case 0, 1, 2, 9, 10, 11
                            If Not BranchesCal(LSH, rc, SH, Involucr(kLato, jmemb).di, trh, tsh, tch, KZ, Nozzles(kLato, nn).EffN, SWR, Int(nn), jmemb) Then Exit Function
                        Case 3, 4, 5
                            If Not Valid2(nn, jmemb) Then Heads = False : Exit Function
                            Issue.SR = SpxBExt
                            Issue.AllN = 0
                            Issue.VerificandoPI = VerificandoPI
                            Nozzles(kLato, nn).Pdes = P0
                            Nozzles(kLato, nn).Tdes = td
                            AD550f(nn)
                            Do
                                If Not VerificaAllN(nn, jmemb, Sn) Then Heads = False : Exit Function
                            Loop Until Sn > 0
                            If iBocc > 0 Then
                                Nozzles(kLato, nn).FactVicini = 1
                            Else
                                Nozzles(kLato, nn).FactVicini = fact(nn - Involucr(kLato, jmemb).inizio + 1)
                            End If
                            Nozzles(kLato, nn).Risult = 0
                            If Not ContinuoAuto Then Nozzles(kLato, nn).BNoRinf = False
Rif:                        OPSH(Nozzles(kLato, nn), NozzAdd(kLato, nn), Issue)
                            RisExam = ExamRis(nn, jmemb, Issue)
                            Select Case RisExam
                                Case -1 : Heads = False : Exit Function
                                Case 0
                                Case 1 : GoTo Rif
                                Case 11 ' si vuole calcolare comunque
                                    Nozzles(kLato, nn).Risult = 2
                                    Nozzles(kLato, nn).BNoRinf = True
                                    GoTo Rif
                            End Select
                            Call BraPrint(nn, jmemb, False, 0, 0, 0, "", 0, 0.0#)
                            FileFor.Str_Renamed = RTrim(clsInizio.DiscoRam) & "ROTFLFOR.OUT"
                            OPSHPRI(Nozzles(kLato, nn), FileFor)
                            Stamparo("", FileFor.Str_Renamed)
                            If RisExam <> -2 And Not VerificandoPI Then
                                Call SuperRatings(pr, pr0, nn, MatGr)
                                Call BraMAWP(nn, jmemb, pr, pr0, False, False, LSH)
                                Call MAWPpri(nn)
                            End If
                        Case 6 : MessageBox.Show("EuroNorm in Heads4")
                    End Select
                End If
                If Not BocBoc(nn, jmemb, FileFor) Then Heads = False : Exit Function
            Next nn
21751:      Heads = True
        Catch ex As Exception
            Heads = False
            MessageBox.Show(ex.Message + vbCrLf + ex.StackTrace)
        End Try
    End Function
    Private Sub Warn(ByVal j As Short, ByVal nn As Short, ByVal nm As Short)
        If Not Gia(j) Then
            Testo = "il bocchello " & Trim(Testo) & " è posizionato su fondo non emisferico" & vbCrLf
            Testo = Testo & "ed è radiale rispetto al cilindro. In tali situazioni il controllo" & vbCrLf
            Testo = Testo & "di prossimità tra bocchelli non viene effettuato."
            MessageBox.Show(Testo)
        End If
        Gia(j) = True
        DistBoc(nn, nm) = 0
        DistBoc(nm, nn) = 0
        DistBocMin(nn, nm) = 0
        DistBocMin(nm, nn) = 0
    End Sub
    Sub HeadThk(ByRef jmemb As Short, ByRef SH As Single, ByRef E As Single, ByRef ky As Single, ByRef LC As Single, ByRef t0h As Single, ByRef t0hy As Single, ByRef kk As Single, ByRef ke As Single, ByRef km As Single, ByRef kt As Single)
        '11500 REM *********************************
        ' FORMED HEADS THICKNESS SUBROUTINE
        ' *********************************
        Select Case Involucr(kLato, jmemb).ms
            Case 7, 8 : Call Sfera(SH, E, ky, LC, t0h, t0hy)
            Case 6 : Call Toro6(SH, E, kt, km, LC, t0h, t0hy)
            Case 3, 4, 5 : Call Toro6(SH, E, kt, km, LC, t0h, t0hy) ' Call Toro(SH, E, km, LC, t0h, t0hy)
            Case 2 : Call EllittQ(SH, E, ke, kk, LC, t0h, t0hy)
            Case 1 : Call Ell21(SH, E, kk, LC, t0h, t0hy)
        End Select
    End Sub
    Sub MEMO()
        Dim i2, k, i1, i As Short
        Dim j As Short
        Dim Fi As String
        Fi = "{\fs14 {\field{\*\fldinst SYMBOL 102 \\f ""Symbol"" \\s 7}{\fldrslt\f3\fs14}}}"
        CloseioutS((mioApert.lstRapp))
        NoHeader = False
        FileSt = clsInizio.Archdir & "\MEMO.VIS"
        If Not PrepRappMEMO("ASMEMEMO", "Libreria", "", FileSt, mioApert.lstRapp) Then Exit Sub
        With Monitor.Motore.Problem
            .Printa("{\pard\plain \qj\nowidctlpar\widctlpar\tx4536\adjustright \f2\fs14\lang1040")
            'Print #iout, "{\fs14\lang1040 ";
            For k = 1 To 2
                .Printa("{\b\fs20" & New String(CChar(" "), 50) & "Libreria del programma ASME-VIP\par \par}")
                .Print(" DN" & Space(9) & Fi & "e" & Space(4) & "Sch.STD Sch. XS ")
                .Print("Sch.DXS Sch. 10 Sch. 20 ")
                .Print("Sch. 30 Sch. 40 Sch. 60 ")
                .Print("Sch. 80 Sch. 90 Sch.120 ")
                .Print("Sch.140 Sch.160 Sch. 5S ")
                .Printa("Sch.10S Sch.40S Sch.80S" & "\par \par \par ")
                If k = 1 Then i1 = 1 : i2 = 17 Else i1 = 18 : i2 = 30
                For i = i1 To i2
                    .Print(" " & diamNm(i))
                    For j = 2 To 19
                        .Print("  ") 'TAB(8 * (j - 1) + 1))
                        If MMM(j, i) = 0 Then GoTo 1850
                        .Print(GlobalRoutines.FormatS("###.##", MMM(j, i)))
                        GoTo 1860
1850:                   .Print("  -  ")
1860:               Next j
                    .Print("nom.thk.")
                    .Printa("\par ")
                    For j = 2 To 19
                        .Print("  ") 'TAB(8 * (j - 1) + 1))
                        If j > 2 Then GoTo 1940
                        .Print("     ")
                        GoTo 1980
1940:                   If MMM(j, i) = 0 Then GoTo 1970
                        .Print(GlobalRoutines.FormatS("###.##", MMM(j, i) - 0.125 * MMM(j, i)))
                        GoTo 1980
1970:                   .Print("  -  ")
1980:               Next j
                    .Print("min.thk.")
                    .Printa("\par \par ")
                Next i
                .Printa("\page ")
            Next k
            .Printa("\par {\b\fs20" & New String(CChar(" "), 50) & "Libreria del programma ASME-VIP. Diametri LWN\par \par}")
            .Print(New String(CChar(" "), 50) & "  150#      300#      400#     600#      900#")
            .Printa("    1500#    2500#\par ")
            .Print(New String(CChar(" "), 12) & "DN" & New String(CChar(" "), 33) & Fi & "i" & New String(CChar(" "), 19) & Fi & "e" & New String(CChar(" "), 8) & Fi & "e" & New String(CChar(" "), 8) & Fi & "e")
            .Printa(Space(8) & Fi & "e" & Space(8) & Fi & "e" & Space(8) & Fi & "e" & Space(8) & Fi & "e")
            .Printa("\par \par ")
            Dim Lung As Short
            For i = 1 To 34
                .Print(n(i).PadLeft(10))
                For j = 2 To 9
                    If j = 2 Then
                        .Print(New String(CChar(" "), 30))
                    ElseIf j = 3 Then
                        Lung = 20
                    Else
                        Lung = 10
                    End If
                    If NNN(j, i) = 0 Then GoTo 2170
                    .Print(GlobalRoutines.FormatS(FormTemp, NNN(j, i)).PadLeft(Lung))
                    GoTo 2180
2170:               .Print("    -    ".PadLeft(Lung))
2180:           Next j
                .Printa("\par ")
            Next i
            .Printa("\par \par \par \par \par")
            .Printa(New String(CChar(" "), 80) & "P.L.Minor fecit A.D.1987" & "\par ")
            .Printa(New String(CChar(" "), 80) & "L.DaTos melius confecit A.D.1994" & "\par ")
            .Printa(New String(CChar(" "), 80) & "L.Prex  magis magisque opus absolvit A.D.1995" & "\par }")
            .FineRapp()
        End With
        clsInizio.SuperStampa(FileSt)
    End Sub

    Function MinPlateThk(ByRef di As Single) As Single
        'MIN.REQ.PLATE SHELL THK.FOR TEMA STANDARD
        Dim k As Short
        If Config(0).Verbose Then
            If di < 152.4 Then Call Erro(5)
            If di > 2540.0! Then Call Erro(5)
        End If
        For k = 1 To 9
            If di > Oasme(1, k) Then GoTo 10720
            If Config(kLato).DC Mod 3 = 2 Then GoTo 10650
            If Config(kLato).mv > 0 Then
                If Oasme(3, k - 1) = 0 Then Call Erro(6)
                MinPlateThk = Oasme(3, k - 1) : Exit Function
            End If
            If Oasme(2, k - 1) = 0 Then Call Erro(6)
            MinPlateThk = Oasme(2, k - 1) : Exit Function
10650:      If Config(kLato).mv > 0 Then
                If Oasme(5, k - 1) = 0 Then Call Erro(6)
                MinPlateThk = Oasme(5, k - 1) : Exit Function
            End If
            If Oasme(4, k - 1) = 0 Then Call Erro(6)
            MinPlateThk = Oasme(4, k - 1) : Exit Function
10720:  Next k
    End Function

    Sub Sfera(ByRef SH As Single, ByRef E As Single, ByRef ky As Single, ByRef LC As Single, ByRef t0h As Single, ByRef t0hy As Single)
        Select Case Involucr(kLato, jInvolucr).ms
            Case 8
                uh = " 1.6 "
                t0h = 5 / 6 * P0 * LC / SH
            Case Else
                If P0 > (0.665 * SH * E) Then
ThickS:             uh = " 1-3 "
                    ky = 2 * (SH * E + P0) / (2 * SH * E - P0)
                    If ky < 0 Then
                        If iMAWP > 0 Then
                            ky = 4 'solo se durante MAWP!
                            P0 = SH * E
                        Else
                            Call Erro(21)
                            t0h = 0
                            Exit Sub
                        End If
                    End If
                    t0h = LC * (ky ^ (1 / 3) - 1)
                    t0hy = t0h / inc
                    Exit Sub
                Else
                    uh = " UG-32(f) "
                    t0h = P0 * LC / (2 * SH * E - 0.2 * P0)
                End If
                If t0h > 0.356 * LC Then GoTo ThickS
        End Select
        t0hy = t0h / inc
    End Sub

    Sub SferaINV(ByRef Press As Single, ByRef SH As Single, ByRef E As Single, ByRef ky As Single, ByRef LC As Single, ByRef t0h As Single, ByRef t0hy As Single)
        Dim ky1 As Single
        If Involucr(kLato, jInvolucr).Tipo < 8 Then
            Press = 2 * SH * E * t0h / (LC - 0.8 * t0h)
            If Press > 0.665 * SH * E Or t0h > 0.356 * LC Then
                ky1 = ((LC + t0h) / LC) ^ 3
                Press = 2 * SH * E * (ky1 - 1) / (ky1 + 2)
            End If
        Else
            Press = 6 / 5 * t0h * SH / LC
        End If
    End Sub

    Sub SpessXbocch(ByRef SH As Single, ByRef ky As Single, ByRef ke As Single, ByRef LC As Single, ByRef t0h As Single, ByRef t0hy As Single, ByRef jmemb As Short, ByRef AH As Single)
        Dim E, K1 As Single
        Dim i As Short
6650:   E = 1
        Select Case Involucr(kLato, jmemb).ms
            Case 3, 4, 5 'torosf
6730:           LC = Involucr(kLato, jmemb).L0 + AH
                UG37a = 1
            Case 1, 2
                ke = Involucr(kLato, jmemb).di / (2 * Involucr(kLato, jmemb).H0)
                If ke > 3 Then Call Erro(7) : Exit Sub
                For i = 1 To 11 'TABLE UG-37
                    If ke < Pasme(1, i) Then GoTo 6710
                    K1 = Pasme(2, i) + (ke - Pasme(1, i)) * (Pasme(2, i - 1) - Pasme(2, i)) / (Pasme(1, i - 1) - Pasme(1, i))
                    GoTo 6720
6710:           Next i
6720:           LC = K1 * Involucr(kLato, jmemb).di + AH
                UG37a = 3
            Case Else
                LC = Involucr(kLato, jmemb).L0 + AH
                UG37a = 0
        End Select
        'If Config(kLato).DC > 2 Then Exit Sub
6731:   Call Sfera(SH, E, ky, LC, t0h, t0hy) 'GOSUB 12110
    End Sub

    Sub StamMAWP(ByVal jmemb As Short)
        Dim ifl As Short
        Dim i As Short
        Dim Rtf As String
        ifl = FreeFile()
        Rtf = "\RTF"
        FilOpen = RTrim(clsInizio.Archdir) & Rtf & "\ASME21.DAT"
        Try
            FileOpen(ifl, FilOpen, OpenMode.Input, , OpenShare.Shared)
            For i = 1 To 6 : StriSt(i) = LineInput(ifl) : Next
            FileClose(ifl)
        Catch e As Exception
            MessageBox.Show(e.Message + vbCrLf + e.StackTrace)
        End Try
        With Monitor.Motore.Problem
            .Printa(StriSt(1))
            .Printa(StriSt(2))  ' "Calculation of the Maximum Allowable Working Pressures"
            .Printa(StriSt(1))
            .Printa(GlobalRoutines.FormatS(StriSt(3), Involucr(kLato, jmemb).MAWP(1 - 1), "[MPa]", Involucr(kLato, jmemb).MAWP(1 - 1) * psi, "[psi]")) '"New _& Cold  ######.## &   ######.## &"
            .Printa(GlobalRoutines.FormatS(StriSt(4), Involucr(kLato, jmemb).MAWP(2 - 1), "[MPa]", Involucr(kLato, jmemb).MAWP(2 - 1) * psi, "[psi]")) '"New _& Hot   ######.## &   ######.## &"
            .Printa(GlobalRoutines.FormatS(StriSt(5), Involucr(kLato, jmemb).MAWP(3 - 1), "[MPa]", Involucr(kLato, jmemb).MAWP(3 - 1) * psi, "[psi]")) '"Corr_& Cold  ######.## &   ######.## &"
            .Printa(GlobalRoutines.FormatS(StriSt(6), Involucr(kLato, jmemb).MAWP(4 - 1), "[MPa]", Involucr(kLato, jmemb).MAWP(4 - 1) * psi, "[psi]")) '"Corr_& Hot   ######.## &   ######.## &"
        End With
    End Sub

    Sub T0andS(ByRef i As Short, ByRef jmemb As Short, ByRef T0 As Single, ByRef s As Single)
        Select Case i
            Case 1 'nuovo e freddo
                T0 = Involucr(kLato, jmemb).Spess - Involucr(kLato, jmemb).OS
                s = Involucr(kLato, jmemb).S0
            Case 2 'nuovo e caldo
                T0 = Involucr(kLato, jmemb).Spess - Involucr(kLato, jmemb).OS
                s = Involucr(kLato, jmemb).St
            Case 3 'corroso e freddo
                T0 = Involucr(kLato, jmemb).Spess - Involucr(kLato, jmemb).OS - Involucr(kLato, jmemb).cs
                s = Involucr(kLato, jmemb).S0
            Case 4 'corroso e caldo
                T0 = Involucr(kLato, jmemb).Spess - Involucr(kLato, jmemb).OS - Involucr(kLato, jmemb).cs
                s = Involucr(kLato, jmemb).St
        End Select
    End Sub
    Sub Testa1(ByRef jmemb As Short)
        Dim i As Short
        Dim StriSt(19) As String
        Dim ifl As Short
        Dim pHydr As Single
        Dim Gradf, Subd, GradC As String
        Dim Test As String = New String(CChar(" "), 4)
        Dim Suffix As String = Involucr(kLato, jmemb).Suffix
        If jmemb > 0 Then
            Test = "#" & Suffix
            If Suffix.Trim.Length = 0 Then Test = New String(CChar(" "), 4)
        End If
        Call Monitor.Motore.Testata(Test, mioApert.Check1.Checked)
        Subd = "\RTF" : Gradf = " [\'b0F]" : GradC = " [\'b0C]"
        ifl = FreeFile()
        FileOpen(ifl, RTrim(clsInizio.Archdir) & Subd & "\ASME19.DAT", OpenMode.Input, , OpenShare.Shared)
        For i = 1 To 19 : StriSt(i) = LineInput(ifl) : Next
        FileClose(ifl)
        With Monitor.Motore.Problem
            .Printa(StriSt(1))
            .Printa(GlobalRoutines.FormatS(StriSt(2), CodiceCalc))  '"ASME 1992 Edition + Addenda '94"
            .Printa(StriSt(3))  ' DL$; DL$; DL$; DL$; DL$; DL$; DL$; DL$
            .Printa(StriSt(1))
            .Printa(GlobalRoutines.FormatS(StriSt(4), GlobalRoutines.Adjust(Config(0).lkStr, 40), RTrim(xsStr), RTrim(xhStr)))  '"Load Case: "
            .Print(StriSt(5))  '"Internal Design Pressure             P   =";
            .Printa(GlobalRoutines.FormatS(StriSt(6), PressDes() * kPress, "[MPa]", PressDes() * psi, "[psi]")) '"######.## &   ######.## &"
            .Print(StriSt(15))  '"Profondità             P   =";
            .Printa(GlobalRoutines.FormatS(StriSt(6), Involucr(kLato, jmemb).HydrDepth, " [mm]", Involucr(kLato, jmemb).HydrDepth / inc, " [in]"))  '"######.## &   ######.## &"
            .Print(StriSt(16))  '"Densità relativa             P   =";
            If VerificandoPI Then
                .Printa(GlobalRoutines.FormatS(StriSt(19), 1.0#, " [--]", Involucr(kLato, jmemb).DensFluido, " [--]"))  '"######.## &   ######.## &"
            Else
                .Printa(GlobalRoutines.FormatS(StriSt(19), Involucr(kLato, jmemb).DensFluido, " [--]", Involucr(kLato, jmemb).DensFluido, " [--]"))  '"######.## &   ######.## &"
            End If
            AggiustaHydr(kLato, jmemb, 0, pHydr, VerificandoPI)
            .Print(StriSt(18))  '"pressione di calcolo             P   =";
            .Printa(GlobalRoutines.FormatS(StriSt(6), pHydr, "[MPa]", pHydr * psi, "[psi]")) '"######.## &   ######.## &"
            If Config(kLato).ms >= 2 Then
                .Print(StriSt(7))  '"Nominal Vessel Size                  Dn  =";
                .Printa(GlobalRoutines.FormatS(StriSt(8), Config(kLato).dns, " [in]"))  '"                  ######.## &"
                .Print(StriSt(9))  '"Outside Nominal Vessel Diameter      íe  =";
                .Printa(GlobalRoutines.FormatS(StriSt(6), Config(kLato).dogg, " [mm]", Config(kLato).dogg / inc, " [in]"))  '"######.## &   ######.## &"
            Else
                If Config(kLato).di > 0 Then
                    .Print(StriSt(10))  ' "Inside Nominal Vessel Diameter       íi  =";
                    .Printa(GlobalRoutines.FormatS(StriSt(6), Config(kLato).di, " [mm]", Config(kLato).di / inc, " [in]"))
                End If
            End If
            .Print(StriSt(11))  '"Design Temperature                   é   =";
            .Printa(GlobalRoutines.FormatS(StriSt(6), TempDes(), GradC, TempDes() * 1.8 + 32, Gradf))
            If Not VerificandoPI Then
                If Config(kLato).NMWDT >= 1 Then
                    .Print(StriSt(12))  ' "Minimum Design Metal Temperature         =";
                    .Printa(GlobalRoutines.FormatS(StriSt(6), Config(kLato).tdxMDMT(0), GradC, Config(kLato).tdxMDMT(0) * 1.8 + 32, Gradf))
                    .Print(StriSt(13))  ' "Concurrent applied pressure              =";
                    .Printa(GlobalRoutines.FormatS(StriSt(6), Config(kLato).pdxMDMT(0), "[MPa]", Config(kLato).pdxMDMT(0) * psi, "[psi]"))
                End If
                If Config(kLato).NMWDT = 2 Then
                    .Print(StriSt(14))  '"Minimum Design Metal Temperature   #2    =";
                    .Printa(GlobalRoutines.FormatS(StriSt(6), Config(kLato).tdxMDMT(1), GradC, Config(kLato).tdxMDMT(1) * 1.8 + 32, Gradf))
                    .Print(StriSt(13))  '"Concurrent applied pressure              =";
                    .Printa(GlobalRoutines.FormatS(StriSt(6), Config(kLato).pdxMDMT(1), "[MPa]", Config(kLato).pdxMDMT(1) * psi, "[psi]"))
                End If
            End If
            .Printa(StriSt(1))
        End With
    End Sub
    Sub Toro(ByRef SH As Single, ByRef E As Single, ByRef km As Single, ByRef LC As Single, ByRef t0h As Single, ByRef t0hy As Single)
        uh = " UG-32(e) "
        km = 1.77
        t0h = P0 * LC * km / (2 * SH * E - 0.2 * P0)
        t0hy = t0h / inc
    End Sub

    Sub Toro6(ByRef SH As Single, ByRef E As Single, ByRef kt As Single, ByRef km As Single, ByRef LC As Single, ByRef t0h As Single, ByRef t0hy As Single)
11750:  uh = " 1-4(d) "
        Call Torok(kt, km)
        t0h = P0 * LC * km / (2 * SH * E - 0.2 * P0)
        t0hy = t0h / inc
    End Sub

    Sub Toro6INV(ByRef Press As Single, ByRef SH As Single, ByRef E As Single, ByRef kt As Single, ByRef km As Single, ByRef LC As Single, ByRef t0h As Single, ByRef t0hy As Single)
        Call Torok(kt, km)
        Press = 2 * SH * E * t0h / (LC * km + 0.2 * t0h)
    End Sub

    Sub ToroINV(ByRef Press As Single, ByRef SH As Single, ByRef E As Single, ByRef km As Single, ByRef LC As Single, ByRef t0h As Single, ByRef t0hy As Single)
        km = 1.77
        Press = 2 * SH * E * t0h / (LC * km + 0.2 * t0h)
    End Sub

    Sub Torok(ByRef kt As Single, ByRef km As Single)
        Try
            If kt > 3.5 Then GoTo 11910
            If (kt - Int(kt)) > 0.125 Then GoTo 11800
            kt = Int(kt)
            GoTo 12040
11800:      If (kt - Int(kt)) > 0.375 Then GoTo 11830
            kt = Int(kt) + 0.25
            GoTo 12040
11830:      If (kt - Int(kt)) > 0.625 Then GoTo 11860
            kt = Int(kt) + 0.5
            GoTo 12040
11860:      If (kt - Int(kt)) > 0.875 Then GoTo 11890
            kt = Int(kt) + 0.75
            GoTo 12040
11890:      kt = Int(kt) + 1
            GoTo 12040
11910:      If kt > 12 Then GoTo 12000
            If (kt - Int(kt)) > 0.25 Then GoTo 11950
            kt = Int(kt)
            GoTo 12040
11950:      If (kt - Int(kt)) > 0.75 Then GoTo 11980
            kt = Int(kt) + 0.5
            GoTo 12040
11980:      kt = Int(kt) + 1
            GoTo 12040
12000:      If (kt - Int(kt)) > 0.5 Then GoTo 12030
            kt = Int(kt)
            GoTo 12040
12030:      kt = Int(kt) + 1
12040:      km = (3 + System.Math.Sqrt(kt)) / 4
            If (((km * 100) - Int(km * 100)) * 10) > 5 Then
                km = (Int(km * 100) + 1) / 100
            Else
                km = Int(km * 100) / 100
            End If
        Catch e As Exception
            MessageBox.Show(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Private Sub CylShellPr(ByRef jmemb As Short, ByRef s As Single)
        '      IF Involucr(kLato,jmemb).Inizio > Involucr(kLato,jmemb).Fine THEN GOTO 19550 ' non esistono bocchelli su fasciame
        swn = 0
19550:  Call Testa1(jmemb)
        Call TestaCylCon(Aspp, jmemb, s)
        With Monitor.Motore.Problem
            If Involucr(kLato, jmemb).ms < 2 Then 'GoTo 19760
                If Involucr(kLato, jmemb).OS > 0 Then 'GoTo 19730
                    .Print(StriSt(24))  ' "Ins.Radius on Base Material          R   =";
                Else
                    .Print(StriSt(2))  '"Corroded Inside Radius               R   =";
                End If
                .Printa(GlobalRoutines.FormatS(StriSt(1), rc, " [mm]", rcy, " [in]"))
            Else
                .Print(StriSt(3))  ' "Outside Radius                       Ro  =";
                .Printa(GlobalRoutines.FormatS(StriSt(1), Ro, " [mm]", RoY, " [in]"))
            End If
19780:      .Printa(StriSt(0))
            If P0 > (0.385 * s * Involucr(kLato, jmemb).ES) Then GoTo 19860
            If Involucr(kLato, jmemb).ms = 2 Then GoTo 19830
            .Print(StriSt(4))  '"to =PR/(SE-0.6P)                         =";
            GoTo 19840
19830:      .Print(StriSt(5))  ' "to =PRo/(SE+0.4P)                        =";
19840:      .Printa(GlobalRoutines.FormatS(StriSt(1), t0s, " [mm]", t0sy, " [in]"))
            GoTo 19930
19860:      .Print(StriSt(25))  ' "Z  =(SE+P)/(SE-P)                        =";
            .Printa(GlobalRoutines.FormatS(StriSt(1), ZES, "  [-]", ZES, "  [-]"))
            If Involucr(kLato, jmemb).ms = 2 Then GoTo 19910
            .Print(StriSt(6))  '"to =R(ûZ-1)                              =";
            GoTo 19920
19910:      .Print(StriSt(7))  '"to =Ro(ûZ-1)/ûZ                          =";
19920:      .Printa(GlobalRoutines.FormatS(StriSt(1), t0s, " [mm]", t0sy, " [in]"))
19930:      .Printa(StriSt(0))
            If P0 > (0.385 * s) Then 'GoTo 20010
                .Print(StriSt(10))  '"Z  =(S+P)/(SE-P)                         =";
                .Printa(GlobalRoutines.FormatS(StriSt(1), ZSS, "  [-]", ZSS, "  [-]"))
                If Involucr(kLato, jmemb).ms = 2 Then 'oTo 20060
                    .Print(StriSt(12))  '"tr =Ro(ûZ-1)/ûZ                          =";
                Else
                    .Print(StriSt(11))  '"tr =R(ûZ-1)                              =";
                End If
                .Printa(GlobalRoutines.FormatS(StriSt(1), Trs, " [mm]", Trsy, " [in]"))
            Else
                If Involucr(kLato, jmemb).ms <> 2 Then 'GoTo 19980
                    .Print(StriSt(8))  '"tr =PR/(S-0.6P)                          =";
                Else
                    .Print(StriSt(9))  '"tr =PRo/(S+0.4P)                         =";
                End If
                .Printa(GlobalRoutines.FormatS(StriSt(1), Trs, " [mm]", Trsy, " [in]"))
            End If
            If Config(kLato).Vacuum And Not VerificandoPI Then
                .Print(StriSt(28))
                .Printa(GlobalRoutines.FormatS(StriSt(1), SpxBExt, " [mm]", SpxBExt / inc, " [in]"))
            End If
20080:      .Printa(StriSt(0))
            .Print(StriSt(13))  '"Minimum Design Thickness                 =";
            .Printa(GlobalRoutines.FormatS(StriSt(1), tms, " [mm]", tmsy, " [in]"))
            If Config(kLato).DC Mod 3 > 0 Then
                .Print(StriSt(14))  '"Minimum Thickness according to TEMA      =";
                .Printa(GlobalRoutines.FormatS(StriSt(1), tts, " [mm]", tts / inc, " [in]"))
            End If
            .Print(StriSt(43)) '"Minimum Thickness to UG-16(b)      ="; '140506
            .Printa(GlobalRoutines.FormatS(StriSt(1), 1.5, " [mm]", 1 / 16, " [in]"))  '140506
            .Print(StriSt(15))  ' "Adopted Nominal Thickness                =";
            .Printa(GlobalRoutines.FormatS(StriSt(1), Involucr(kLato, jmemb).Spess, " [mm]", Involucr(kLato, jmemb).Spess / inc, " [in]"))
            If Not (RTrim(Config(kLato).lkStr) = "MAWP") And Config(0).CalcMAWP = 1 And Not VerificandoPI Then Call StamMAWP(jmemb)
            .Printa(StriSt(0))
        End With
    End Sub
    Private Function Valid2(ByRef nn As Short, ByRef jmemb As Short) As Boolean
        ' Dim Testo As String=""
        'Do
        Valid2 = True
        'If Nozzles(kLato, nn).LXdisp = 0 Or Nozzles(kLato, nn).LSDisp = 0 Then
        '           Testo = "   Non sono accettabili valori nulli" + vbCrLf
        '   Testo = Testo + "per le lunghezze disponibili lungo" + vbCrLf
        '   Testo = Testo + "il bocchello e lungo il mantello." + vbCrLf
        '   Testo = Testo + "   Fornire i valori minimi disponibili" + vbCrLf
        '   Testo = Testo + "nella maschera seguente."
        '   messagebox.show Testo, vbInformation + vbOKOnly
        '   If Not DatiNozzles(kLato, jmemb, nn) Then Valid2 = False: Exit Do
        'Else
        '   Exit Do
        'End If
        'Loop
    End Function
    Public Function ExamRis(ByRef nn As Short, ByRef jmemb As Short, ByRef Issue As ASMERES, Optional ByRef MAWP As Boolean = False) As Short
        Dim Testo As String = ""
        Dim Risp As DialogResult
        A0 = Issue.a
        a1 = Issue.a1
        a2 = Issue.a2
        A3 = Issue.A2PROT
        A41 = Issue.A4
        A5 = Issue.A3
        A0Ext = Issue.AExt
        Try
            ExamRis = 0
            Select Case Nozzles(kLato, nn).Risult
                Case -5
                    Testo = "   L'ammissibile del bocchello non deve essere|"
                    Testo = Testo & "inferiore all'80% dell'ammissibile del mantello.|"
                    Testo = Testo & "Cambiare il materiale del bocchello."
                    Risp = MessageBox.Show(clsInizio.ConvertiCr(Testo), "AsmeVip", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Exclamation)
                    If Risp = DialogResult.Abort Then
                        ExamRis = -2 : Exit Function
                    ElseIf Risp = DialogResult.Ignore Then
                        Exit Function
                    Else
                        If Not DatiNozzles(kLato, jmemb, nn) Then ExamRis = -1 : Exit Function
                        ExamRis = 1
                    End If
                Case -6 'theta>45
                    Testo = "   L'angolo di rastremazione sul bocchello non deve essere|"
                    Testo = Testo & "superiore a 45 gradi.|"
                    Testo = Testo & "Cambiare i dati."
                    MessageBox.Show(clsInizio.ConvertiCr(Testo))
                    If Not DatiNozzles(kLato, jmemb, nn) Then ExamRis = -1 : Exit Function
                    ExamRis = 1
                Case -7 'XLT<0
                    Testo = "   Le altezze (con spessore Tn e con spessore Tp)|"
                    Testo = Testo & "del bocchello non sono definite correttamente.|"
                    Testo = Testo & "Correggere i dati geometrici."
                    MessageBox.Show(clsInizio.ConvertiCr(Testo))
                    If Not DatiNozzles(kLato, jmemb, nn) Then ExamRis = -1 : Exit Function
                    ExamRis = 1
                Case -9
                    Testo = "Questa geometria non è stata ancora programmata."
                    Testo = Testo & "|(UW16=" & Str(NozzAdd(kLato, nn).UW16) & ")"
                    MessageBox.Show(clsInizio.ConvertiCr(Testo))
                    ExamRis = -1 : Exit Function
                Case -3 'AT<A
                    Select Case Decision(Testo, jmemb, nn, 1)
                        Case 1, 2, 3, 5 'If Not DatiNozzles(kLato, jmemb, nn) Then ExamRis = -1: Exit Function
                            ExamRis = 1
                        Case 4 : ExamRis = 2
                        Case 0, 6 : ExamRis = -1 : Exit Function
                    End Select
                Case -4 'ATT<AA
                    A0 = Issue.Aa
                    a1 = Issue.AA1
                    a2 = Issue.a2
                    A3 = Issue.A2PROT
                    A41 = Issue.A4
                    A5 = Issue.AA3
                    A0Ext = Issue.AAExt
                    Select Case Decision(Testo, jmemb, nn, 2)
                        Case 1, 2, 3, 5 'If Not DatiNozzles(kLato, jmemb, nn) Then ExamRis = -1: Exit Function
                            ExamRis = 1
                        Case 4
                        Case 0, 6 : ExamRis = -1 : Exit Function
                    End Select
                Case -1
                    'C       WRITE(*,*)'d/D > 0.50 USE ASME CODE APPENDIX 4 OR 5 '
                    Testo = "Bocchello: " & RTrim(Nozzles(kLato, nn).Mark)
                    Testo = Testo & "|  Il rapporto d/D è superiore a 0.5|"
                    Testo = Testo & "Caso non coperto dalle regole D-5."
                    MessageBox.Show(clsInizio.ConvertiCr(Testo))
                    ExamRis = -1 : Exit Function
                Case -2
                    Testo = "Bocchello: " & RTrim(Nozzles(kLato, nn).Mark)
                    Testo = Testo & "|   Apertura circolare non richiedente il rinforzo"
                    Testo = Testo & "|   a fronte di AD-510."
                    If Not ContinuoAuto Then
                        Testo = Testo & "|   Si vuole calcolarla comunque?"
                        If MessageBox.Show(clsInizio.ConvertiCr(Testo), "AsmeVip", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                            ExamRis = 11
                        Else
                            ExamRis = -2
                        End If
                    Else
                        If Nozzles(kLato, nn).BNoRinf Then
                            ExamRis = 11
                            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto clsInizio.ConvertiCr(). Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                            Testo = clsInizio.ConvertiCr(Testo & "|   Calcolata comunque su richiesta dell'utente.")
                            PrintlstRes(Testo)
                        Else
                            ExamRis = -2
                        End If
                    End If
                Case 0
                    Testo = "Bocchello: " & RTrim(Nozzles(kLato, nn).Mark)
                    Testo = Testo & "|La compensazione dell'apertura è verificata. [AD-540.1(a)]  |"
                    Str234(Testo)
                    Testo = Testo & "|La compensazione dell'apertura è verificata. [AD-540.1(b)]  |"
                    A0 = Issue.Aa
                    a1 = Issue.AA1
                    a2 = Issue.a2
                    A3 = Issue.A2PROT
                    A41 = Issue.A4
                    A5 = Issue.AA3
                    If MAWP Then
                        ExamRis = 0
                    Else
                        Str234(Testo)
                        Testo = Testo & "||    Approvi ?"
                        If Not ContinuoAuto Then
                            Risp = MessageBox.Show(clsInizio.ConvertiCr(Testo), "AsmeVip", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                        Else
                            Risp = DialogResult.Yes
                        End If
                        Select Case Risp
                            Case DialogResult.No
                                If Not DatiNozzles(kLato, jmemb, nn) Then
                                    ExamRis = -1
                                Else
                                    ExamRis = 1
                                End If
                            Case DialogResult.Cancel
                                ExamRis = -1
                        End Select
                    End If
            End Select
        Catch e As Exception
            MessageBox.Show(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Function

    Public Sub CylVacuumPr(ByRef jmemb As Short)
        Dim i As Short
        Dim Bkmk, Figur As String
        If Not (RTrim(Config(kLato).lkStr) = "MAWP") Then
            If Config(kLato).Vacuum Then
                If div = 2 Then
                    EUCylVacuumPr()
                Else
                    With Monitor.Motore.Problem
                        .Printa(StriSt(0))
                        .Printa(StriSt(16))  ' "Design under vacuum conditions"
                        .Print(StriSt(26))
                        .Printa(GlobalRoutines.FormatS(StriSt(23), Pextdes(), "[MPa]", Pextdes() * psi, "[psi]")) '"######.## &   ######.## &"
                        .Print(StriSt(27))
                        .Printa(GlobalRoutines.FormatS(StriSt(23), Textdes(), "[\'b0C ]", Textdes() * 1.8 + 32, "[\'b0F ]")) '"######.## &   ######.## &"
                        '     PRINT #iout, StriSt(17);' "Shell length betw. structural discon'ties=";
                        '     PRINT #iout, USING StriSt(1); Involucr(kLato,jmemb).L0; " [mm]"; Involucr(kLato,jmemb).L0 / INC; " [in]"
                        .Print(StriSt(18))  ' "Shell effective length                   =";
                        .Printa(GlobalRoutines.FormatS(StriSt(23), Involucr(kLato, jmemb).L0 / (Involucr(kLato, jmemb).SottoTipo + 1), " [mm]", Involucr(kLato, jmemb).L0 / inc, " [in]"))
                        .Print(StriSt(19))  '"A-factor per Fig. G, II-D Subpart 3      =";
                        .Printa(GlobalRoutines.FormatS(StriSt(20), Asnell, " [--]", Asnell, " [--]"))  '"#.###^^^^ &   #.###^^^^ &"
                        .Print(StriSt(21) & Space(1) & Left(Chart, 23) & "\tab =")  '"B-factor per curve "
                        .Printa(GlobalRoutines.FormatS(StriSt(20), psig, " [MPa]", psig * psi, " [psi]"))
                        .Print(StriSt(22))  ' "Allowable external pressure              =";
                        .Printa(GlobalRoutines.FormatS(StriSt(23), psig1, " [MPa]", psig1 * psi, " [psig]")) '"###.##### &   #####.## &"
                        .Printa(StriSt(0))
                        If Involucr(kLato, jmemb).SottoTipo > 0 Then
                            ContBkml = ContBkml + 1
                            Bkmk = "bkml" & Trim(Str(ContBkml))
                            Figur = frmStiff.DefInstance.TagImageList1(Involucr(kLato, jmemb).Dati3)
                            .Printa(GlobalRoutines.FormatS(StriSt(29), Involucr(kLato, jmemb).SottoTipo, Figur))
                            .Printa(GlobalRoutines.FormatS(StriSt(42), Bkmk, Figur, Bkmk))
                            .Printa(GlobalRoutines.FormatS(StriSt(30), Involucr(kLato, jmemb).Dati2, Involucr(kLato, jmemb).Dati2 / inc))
                            .Printa(GlobalRoutines.FormatS(StriSt(31), Involucr(kLato, jmemb).Dati1, Involucr(kLato, jmemb).Dati1 / inc))
                            If Involucr(kLato, jmemb).Dati3 < 4 Then
                                .Printa(GlobalRoutines.FormatS(StriSt(40), Involucr(kLato, jmemb).Dati(4 - 4), Involucr(kLato, jmemb).Dati(4 - 4) / inc))
                                .Printa(GlobalRoutines.FormatS(StriSt(41), Involucr(kLato, jmemb).Dati(5 - 4), Involucr(kLato, jmemb).Dati(5 - 4) / inc))
                            End If
                            .Printa(GlobalRoutines.FormatS(StriSt(32), ASS, ASS / inc / inc))
                            .Printa(GlobalRoutines.FormatS(StriSt(33), Involucr(kLato, jmemb).L0 / (Involucr(kLato, jmemb).SottoTipo + 1), Involucr(kLato, jmemb).L0 / (Involucr(kLato, jmemb).SottoTipo + 1) / inc))
                            .Printa(GlobalRoutines.FormatS(StriSt(34), BanellRinf * psi))
                            .Printa(GlobalRoutines.FormatS(StriSt(35), AanellRinf))
                            .Printa(GlobalRoutines.FormatS(StriSt(36), Involucr(kLato, jmemb).TubeMinT, Involucr(kLato, jmemb).TubeMinT / inc ^ 4))
                            .Printa(GlobalRoutines.FormatS(StriSt(37), Involucr(kLato, jmemb).TubeAdopt, Involucr(kLato, jmemb).TubeAdopt / inc ^ 4))
                            i = 38 : If Involucr(kLato, jmemb).TubeAdopt < Involucr(kLato, jmemb).TubeMinT Then i = 39
                            .Printa(StriSt(i))
                        End If
                    End With
                End If
            End If
            '-------------------MDMT-----------------------------------
            Call MinTemp(0, jmemb, Rsav, SWR)
            '----------------------------------------------------------
        End If
    End Sub

    Public Sub HeadsPr(ByRef jmemb As Short)
        Dim ifl, i As Short
        Call Testa1(jmemb)
        ifl = FreeFile()
        Select Case Config(kLato).DC
            Case 0, 1, 2, 9, 10, 11
                FileOpen(ifl, RTrim(clsInizio.Archdir) & "\RTF\ASME11.DAT", OpenMode.Input, , OpenShare.Shared)
            Case 3, 4, 5
                FileOpen(ifl, RTrim(clsInizio.Archdir) & "\RTF\ASME112.DAT", OpenMode.Input, , OpenShare.Shared)
            Case 6 : MessageBox.Show("EuroNorm in HeadsPr")
        End Select
        For i = 1 To 56 : StriSt(i) = LineInput(ifl) : Next
        FileClose(ifl)
        KCY = KC / inc
        With Monitor.Motore.Problem
            .Printa(StriSt(36))
            .Printa(StriSt(37) & Space(1) & Involucr(kLato, jmemb).Mark)  ' "Identification: "
            .Printa(GlobalRoutines.FormatS(StriSt(38), uh, HTStr))
            .Printa(StriSt(39))  'DL$; DL$; DL$; DL$; DL$
            .Printa(StriSt(36))
            .Printa(StriSt(40) & Space(1) & Involucr(kLato, jmemb).MATE)  '"Material : "
            If Involucr(kLato, jmemb).ms = 1 Or Involucr(kLato, jmemb).ms >= 7 Then GoTo 20770
            If Involucr(kLato, jmemb).ms > 2 Then GoTo 20680
            If (Involucr(kLato, jmemb).di / Involucr(kLato, jmemb).H0) < 4 Then GoTo 20770
            GoTo 20710
20680:      If Involucr(kLato, jmemb).SU <= 80000.0! Then GoTo 20770
            .Print(StriSt(41))  ' "Specified Min.Tensile Stress         Su  =";
            .Printa(GlobalRoutines.FormatS(StriSt(1), SUX, "[MPa]", SUX * psi, "[psi]"))
20710:      .Print(StriSt(42))  '"Max.Allow.Stress / Design Temp.      St  =";
            .Printa(GlobalRoutines.FormatS(StriSt(1), St, "[MPa]", St * psi, "[psi]"))
            .Print(StriSt(43))  '"Max.Allow.Stress / Room Temp.        So  =";
            .Printa(GlobalRoutines.FormatS(StriSt(1), S0X, "[MPa]", S0X * psi, "[psi]"))
            .Print(StriSt(44))  '"Reference Stress / Room Temp.        Sr  =";
            .Printa(GlobalRoutines.FormatS(StriSt(1), SRX, "[MPa]", SR, "[psi]"))
20770:      .Print(StriSt(45))  '"Design Stress Value                  S   =";
            .Printa(GlobalRoutines.FormatS(StriSt(1), SH, "[MPa]", SH * psi, "[psi]"))
            .Printa(StriSt(36))
            .Print(StriSt(46))  '"Joint Efficiency                     E   =";
            .Printa(GlobalRoutines.FormatS(StriSt(1), Involucr(kLato, jmemb).ES, "  [-]", Involucr(kLato, jmemb).ES, "  [-]"))
            If Involucr(kLato, jmemb).OS = 0 Then GoTo 20850
            .Print(StriSt(47))  '"Cladding or Weld Overlay             o   =";
            GoTo 20860
20850:      .Print(StriSt(48))  '"Corrosion Allowance                  c   =";
20860:      .Printa(GlobalRoutines.FormatS(StriSt(1), AH, " [mm]", AHY, " [in]"))
            If Involucr(kLato, jmemb).ms >= 7 Then GoTo 21340
            If Involucr(kLato, jmemb).ms > 2 Then GoTo 21120
            If Involucr(kLato, jmemb).OS = 0 Then GoTo 20920
            .Print(StriSt(2))  ' "Ins.Diameter on Base Mat.            D   =";
            GoTo 20930
20920:      .Print(StriSt(3))  ' "Corroded Inside Diameter             D   =";
20930:      .Printa(GlobalRoutines.FormatS(StriSt(1), LC, " [mm]", LCY, " [in]"))
            If Involucr(kLato, jmemb).ms = 1 Then GoTo 21050
            If Involucr(kLato, jmemb).OS = 0 Then GoTo 20980
            .Print(StriSt(4))  ' "Ins.Depth on Base Mat.               h   =";
            GoTo 20990
20980:      .Print(StriSt(5))  ' "Corroded Inside Depth                h   =";
20990:      .Printa(GlobalRoutines.FormatS(StriSt(1), HC, " [mm]", HCY, " [in]"))
            .Print(StriSt(6))  '"Ratio of Major to Minor Axis         D/2h=";
            .Printa(GlobalRoutines.FormatS(StriSt(1), ke, "  [-]", ke, "  [-]"))
            If Involucr(kLato, jmemb).ms = 1 Then GoTo 21060
            .Print(StriSt(7))  ' "Factor from Table 1-4.1              K   =";
            .Printa(GlobalRoutines.FormatS(StriSt(1), kk, "  [-]", kk, "  [-]"))
21050:      .Printa("")
21060:      If Involucr(kLato, jmemb).ms = 2 Then GoTo 21090
            .Print(StriSt(8))  '"to =PD/(2SE-0.2P)                        =";
            GoTo 21100
21090:      .Print(StriSt(9))  '"to =PDK/(2SE-0.2P)                       =";
21100:      .Printa(GlobalRoutines.FormatS(StriSt(1), t0h, " [mm]", t0hy, " [in]"))
            GoTo 21540
21120:      If Involucr(kLato, jmemb).OS = 0 Then GoTo 21150
            .Print(StriSt(10))  '"Ins.Crown Radius on Base Mat.        L   =";
            GoTo 21160
21150:      .Print(StriSt(11))  ' "Corroded Inside Crown Radius         L   =";
21160:      .Printa(GlobalRoutines.FormatS(StriSt(1), LC, " [mm]", LCY, " [in]"))
            If Involucr(kLato, jmemb).ms = 3 Or Involucr(kLato, jmemb).ms = 4 Or Involucr(kLato, jmemb).ms = 5 Then GoTo 21270
            If Involucr(kLato, jmemb).OS = 0 Then GoTo 21210
            .Print(StriSt(12))  '"Ins.Knuckle Radius on Base Mat.      r   =";
            GoTo 21220
21210:      .Print(StriSt(13))  ' "Corroded Inside Knuckle Radius       r   =";
21220:      .Printa(GlobalRoutines.FormatS(StriSt(1), KC, " [mm]", KCY, " [in]"))
            .Print(StriSt(14))  '"Ratio of Crown to Knuckle Radius     L/r =";
            .Printa(GlobalRoutines.FormatS(StriSt(1), kt, "  [-]", kt, "  [-]"))
            .Print(StriSt(15))  ' "Factor from Table 1-4.2              M   =";
            .Printa(GlobalRoutines.FormatS(StriSt(1), km, "  [-]", km, "  [-]"))
21270:      .Printa(StriSt(36))
            If Involucr(kLato, jmemb).ms = 6 Then GoTo 21310
            .Print(StriSt(16))  '"to =0.885PL/(SE-0.1P)                    =";
            GoTo 21320
21310:      .Print(StriSt(17))  '"to =PLM/(2SE-0.2P)                       =";
21320:      .Printa(GlobalRoutines.FormatS(StriSt(1), t0h, " [mm]", t0hy, " [in]"))
            GoTo 21540
21340:      If P0 > (0.665 * SH * Involucr(kLato, jmemb).ES) And Involucr(kLato, jmemb).Tipo < 6 Then GoTo 21450
            If Involucr(kLato, jmemb).OS = 0 Then GoTo 21380
            .Print(StriSt(18))  ' "Ins.Radius on Base Mat.              L   =";
            GoTo 21390
21380:      .Print(StriSt(19))  '"Corroded Inside Radius               L   =";
21390:      .Printa(GlobalRoutines.FormatS(StriSt(1), LC, " [mm]", LCY, " [in]"))
            .Printa(StriSt(36))
            If Involucr(kLato, jmemb).ms < 8 Then
                .Print(StriSt(20))  ' "to =PL/(2SE-0.2P)                        =";
            Else
                .Print(StriSt(53))  ' "to =5PL/6S                        =";
            End If
            .Printa(GlobalRoutines.FormatS(StriSt(1), t0h, " [mm]", t0hy, " [in]"))
            GoTo 21540
            If Involucr(kLato, jmemb).OS = 0 Then GoTo 21470
21450:      .Print(StriSt(21))  '"Ins.Radius on Base Mat.              R   =";
            GoTo 21480
21470:      .Print(StriSt(22))  '"Corroded Inside Radius               R   =";
21480:      .Printa(GlobalRoutines.FormatS(StriSt(1), LC, " [mm]", LCY, " [in]"))
            .Printa(StriSt(36))
            .Print(StriSt(23))  '"Y  =2(SE+P)/(2SE-P)                      =";
            .Printa(GlobalRoutines.FormatS(StriSt(1), YEH, "  [-]", YEH, "  [-]"))
            .Print(StriSt(24))  '"to =R(ûY-1)                              =";
            .Printa(GlobalRoutines.FormatS(StriSt(1), t0h, " [mm]", t0hy, " [in]"))
21540:      .Printa(StriSt(36))
            If Involucr(kLato, jmemb).ms > 2 Then GoTo 21590
            .Print(StriSt(25))  '"L  =K1*D                                 =";
            .Printa(GlobalRoutines.FormatS(StriSt(1), LSH, " [mm]", LSHY, " [in]"))
            GoTo 21610
21590:      If Involucr(kLato, jmemb).ms < 7 Then GoTo 21610
            If P0 > (0.665 * SH) Then GoTo 21630
21610:      .Print(StriSt(26))  ' "trh=PL/(2S-0.2P)                         =";
            GoTo 21660
21630:      .Print(StriSt(27))  ' "Y  =2(S+P)/(2S-P)                        =";
21640:      .Printa(GlobalRoutines.FormatS(StriSt(1), YSH, "  [-]", YSH, "  [-]"))
            .Print(StriSt(28))  '"trh=R(ûY-1)                              =";
21660:      .Printa(GlobalRoutines.FormatS(StriSt(1), trh, " [mm]", TRHY, " [in]"))
            If Config(kLato).Vacuum Then
                .Print(StriSt(55))
                .Printa(GlobalRoutines.FormatS(StriSt(1), SpxBExt, " [mm]", SpxBExt / inc, " [in]"))
            End If
            .Print(StriSt(56)) '"Minimum Thickness to UG-16(b)      ="; '140506
            .Printa(GlobalRoutines.FormatS(StriSt(1), 1.5, " [mm]", 1 / 16, " [in]"))  '140506
            .Printa(StriSt(36))
            .Print(StriSt(29))  '"Minimum Design Thickness                 =";
            .Printa(GlobalRoutines.FormatS(StriSt(1), TMH, " [mm]", TMHY, " [in]"))
            .Print(StriSt(30))  '"Min. Adopted Thickness After Forming     =";
            .Printa(GlobalRoutines.FormatS(StriSt(1), Involucr(kLato, jmemb).Spess, " [mm]", TNHY, " [in]"))
            If Involucr(kLato, jmemb).ms < 3 Then
                Call CylThk(P0, td, T0, LC / 2, KZ, SH, 1, 0)
                .Print(StriSt(51))
                .Printa(GlobalRoutines.FormatS(StriSt(1), T0 + AH, " [mm]", (T0 + AH) / inc, " [in]"))
            End If
        End With
20510:  If Not Involucr(kLato, jmemb).Fine < Involucr(kLato, jmemb).inizio Then swn = 1
        If Not RTrim(Config(kLato).lkStr) = "MAWP" And Config(0).CalcMAWP = 1 And Not VerificandoPI Then Call StamMAWP(jmemb)
    End Sub

    Public Sub HeadsVacuumPr(ByRef jmemb As Short)
        Dim ifl, i As Short
        If Not RTrim(Config(kLato).lkStr) = "MAWP" And Config(kLato).Vacuum Then
            ifl = FreeFile()
            Select Case Config(kLato).DC
                Case 0, 1, 2, 9, 10, 11
                    FileOpen(ifl, RTrim(clsInizio.Archdir) & "\RTF\ASME11.DAT", OpenMode.Input, , OpenShare.Shared)
                Case 3, 4, 5
                    FileOpen(ifl, RTrim(clsInizio.Archdir) & "\RTF\ASME112.DAT", OpenMode.Input, , OpenShare.Shared)
                Case 6 : MessageBox.Show("EuroNorm in HeadsVacuumPr")
            End Select
            For i = 1 To 56 : StriSt(i) = LineInput(ifl) : Next
            FileClose(ifl)
            With Monitor.Motore.Problem
                .Printa(StriSt(36))
                .Printa(StriSt(31))  ' "Design under vacuum conditions"
                .Print(StriSt(54))
                .Printa(GlobalRoutines.FormatS(StriSt(1), Textdes(), "[\'b0C ]", Textdes() * 1.8 + 32, "[\'b0F ]")) '"######.## &   ######.## &"
                .Print(StriSt(52))
                .Printa(GlobalRoutines.FormatS(StriSt(1), Pextdes(), "[MPa]", Pextdes() * psi, "[psi]")) '"######.## &   ######.## &"
                If Involucr(kLato, jmemb).ms < 3 Then
                    .Print(StriSt(32))  '"Factor Ko according to UG-33(b)          =";
                    .Printa(GlobalRoutines.FormatS(StriSt(1), AKo, " [--]", AKo, " [--]"))
                End If
                .Print(StriSt(33))  ' "Radius Ro according to UG-33(b)          =";
                .Printa(GlobalRoutines.FormatS(StriSt(1), Ro, " [mm]", Ro / inc, " [in]"))
                .Print(StriSt(34))  ' "A-factor , .125 t/Ro                     =";
                .Printa(GlobalRoutines.FormatS(StriSt(49), Asnell, " [--]", Asnell, " [--]"))  '"#.###^^^^ &   #.###^^^^ &"
                .Print(StriSt(50) & Space(1) & Left(Chart, 23) & "\tab =")  '"B-factor per curve " +
                .Printa(GlobalRoutines.FormatS(StriSt(1), psig, " [MPa]", psig * psi, " [psi]"))
                .Print(StriSt(35))  ' "Allowable external pressure, B * t/Ro    =";
                .Printa(GlobalRoutines.FormatS(StriSt(1), psig1, " [MPa]", psig1 * psi, " [psig]")) '"###.##### &   #####.## &"
            End With
        End If
    End Sub

    Public Function BocBoc(ByRef nn As Short, ByRef jmemb As Short, ByRef FileFor As Str50) As Boolean
        Dim nm As Short
        Dim TNN As Single
        Dim MatGr As String = ""
        Dim Issue As New ASMERES
        Dim pr, rc, pr0 As Single
        Dim s, Sn As Single
        BocBoc = True
        For nm = Nozzles(kLato, nn).inizio To Nozzles(kLato, nn).Fine
            'trs spessore di calcolo per bocchello calcolato in branches
            'tcs spessore al netto della coorosione
            If nm > 0 Then
                If VerificandoPI Then
                    s = Nozzles(kLato, nn).AllNPI
                Else
                    s = Nozzles(kLato, nn).AllN
                End If
                Call PrepRapp(Template, "Apertura su bocchello", Nozzles(kLato, nm).Mark, FileSt, mioApert.lstRapp, 3)
                Select Case Config(kLato).DC
                    Case 0, 1, 2, 9, 10, 11
                        SWR = Nozzles(kLato, nm).SWR : If SWR > 9 Then SWR = SWR - 10
                        TNN = (Nozzles(kLato, nn).DiOn - Nozzles(kLato, nn).DiIn) / 2
                        If Nozzles(kLato, nn).Tipo.Trim = "WN" Then TNN = Nozzles(kLato, nn).Spess
                        tcs = TNN - Nozzles(kLato, nn).CorrA
                        rc = Nozzles(kLato, nn).DiIn / 2 + Nozzles(kLato, nn).CorrA
                        Call CylThk(P0, td, T0, rc, KZ, s, 1, 0)  'GOSUB 11000
                        If T0 = 0 Then BocBoc = False : Exit Function
                        swn = -1
                        '                        If Not BranchesCal(1, rc, s, Nozzles(kLato, nn).DiIn, TNN, T0, tcs, KZ, Nozzles(kLato, nm).EffN, SWR, Int(nm), nn) Then BocBoc = False : Exit Function
                        If Not BranchesCal(1, rc, s, Nozzles(kLato, nn).DiIn, T0, T0, tcs, KZ, Nozzles(kLato, nm).EffN, SWR, Int(nm), nn) Then BocBoc = False : Exit Function
                    Case 3, 4, 5
                        If Not Valid2(nm, -nn) Then BocBoc = False : Exit Function
                        Issue.SR = SpxBExt
                        Issue.AllN = s
                        Issue.MatN = Nozzles(kLato, nn).MATE
                        Issue.VerificandoPI = VerificandoPI
                        Nozzles(kLato, nn).Pdes = P0
                        Nozzles(kLato, nn).Tdes = td
                        Issue.SpCop = 0
                        Do
                            If Not VerificaAllN(nm, -nn, Sn) Then BocBoc = False : Exit Function
                        Loop Until Sn > 0
                        Nozzles(kLato, nm).Risult = 0
                        If Not ContinuoAuto Then Nozzles(kLato, nm).BNoRinf = False
Rif1:                   OP(Nozzles(kLato, nm), NozzAdd(kLato, nm), Issue)
                        Select Case ExamRis(nm, -nn, Issue)
                            Case -1 : BocBoc = False : Exit Function
                            Case 0
                            Case 1 : GoTo Rif1
                            Case 11 ' si vuole calcolare comunque
                                Nozzles(kLato, nm).Risult = 2
                                Nozzles(kLato, nm).BNoRinf = True
                                GoTo Rif1
                        End Select
                        Call BraPrint(nm, -nn, False, 0, 0, 0, "", 0, 0.0#)
                        OPPRI(Nozzles(kLato, nm), FileFor)
                        Stamparo("", FileFor.Str_Renamed)
                        If Not VerificandoPI Then
                            Call SuperRatings(pr, pr0, nn, MatGr)
                            Call BraMAWP(nn, jmemb, pr, pr0, False, False, LSH)
                            Call MAWPpri(nn)
                        End If
                    Case 6
                        MessageBox.Show("Euronorm in BocBoc")
                End Select
            End If
        Next nm

    End Function
    Public Function AlertPext(ByRef psig1 As Single) As ChiaviMess
        Dim Testo As String
        Testo = "Verifica a pressione esterna|"
        'If kLato = 3 Then
        Testo = Testo & "Pressione esterna =     " & GlobalRoutines.myStr(pext * kPress, 6 - IncrVirgola, 1 + IncrVirgola, 0) & " " & UnitPress & ".|"
        'End If
        Testo = Testo & "Pressione ammissibile = " & GlobalRoutines.myStr(psig1 * kPress, 6 - IncrVirgola, 1 + IncrVirgola, 0) & " " & UnitPress & "."
        If pext > psig1 Then Testo = Testo & "|Verifica NON soddisfatta."
        If Involucr(kLato, jInvolucr).SottoTipo > 0 And Involucr(kLato, jInvolucr).Tipo = 0 Then
            Testo = Testo & "||Verifica degli anelli di rinforzo"
            Testo = Testo & "|Momento d'inerzia disponibile: " & Format(Involucr(kLato, jInvolucr).TubeAdopt * kMomI, "#.####E+##") & " " & UnitMomI '" mm4"
            Testo = Testo & "|Momento d'inerzia richiesto:   " & Format(Involucr(kLato, jInvolucr).TubeMinT * kMomI, "#.####E+##") & " " & UnitMomI
            If Involucr(kLato, jInvolucr).TubeAdopt > Involucr(kLato, jInvolucr).TubeMinT Then
                Testo = Testo & "|   Gli anelli di rinforzo sono adeguati."
            Else
                Testo = Testo & "|   Gli anelli di rinforzo NON sono adeguati."
            End If
        End If
        If ContinuoAuto Then
            PrintlstRes(Testo)
            AlertPext = ChiaviMess.MessOK
        Else
            AlertPext = Monitor.Motore.Messaggio(clsInizio.ConvertiCr(Testo), ChiaviMess.MessOKCancel, "AsmeVip", Proportional:=True)
        End If
    End Function

    Public Sub HeadsBuckPar(ByRef Ro As Single, ByRef Spess As Single)
        Dim delta, Param, deltac As Single
        Dim Paramv, PSE, deltav As Single
        Dim ifl As Short
        Dim Testo As String
        Select Case Involucr(kLato, jInvolucr).ms 'era HT
            Case 1 'ellittico 2:1
                AKo = 0.9
                Ro = Involucr(kLato, jInvolucr).di * AKo + Spess
            Case 2 'ellittico qualsiasi
                ifl = FreeFile()
                FileOpen(ifl, RTrim(clsInizio.Archdir) & "\UG331.DAT", OpenMode.Input, , OpenShare.Shared)
                Testo = LineInput(ifl)
                PSE = (Involucr(kLato, jInvolucr).di + Spess) / (2 * Involucr(kLato, jInvolucr).H0)
                Paramv = 0 : deltav = 0
                Do
                    Input(ifl, Param)
                    Input(ifl, delta)
                    If Param = -1 Then
                        MessageBox.Show("Errore in Heads") ': u$ = INPUT$(1)
                        deltac = 2 : Exit Do
                    End If
                    If Param > PSE Then
                        deltac = deltav + (PSE - Paramv) / (Param - Paramv) * (delta - deltav)
                        Exit Do
                    End If
                    Paramv = Param : deltav = delta
                Loop
                FileClose(ifl)
                AKo = deltac
                Ro = Involucr(kLato, jInvolucr).di * AKo + Spess
            Case 3 To 6 'torosferici
                Ro = Involucr(kLato, jInvolucr).L0 + Spess
            Case 7, 8 'emisferico
                Ro = Involucr(kLato, jInvolucr).L0 + Spess
        End Select
    End Sub

    Public Sub CheckDiafr(ByRef Res As Boolean)
        Dim Testo As String
        If formTab.Fatto Is Nothing Then Exit Sub
        With formTab.Fatto
            If Not .Mp(161) = 14 Then
                'UPGRADE_NOTE: È possibile che l'oggetto formTab.Fatto.Diaf non venga eliminato finché non venga raccolto nel Garbage Collector. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1029"'
                .Diaf = Nothing : Exit Sub
            End If
            If Not .Mem.LOOSE = 4 Then
                'UPGRADE_NOTE: È possibile che l'oggetto formTab.Fatto.Diaf non venga eliminato finché non venga raccolto nel Garbage Collector. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1029"'
                .Diaf = Nothing : Exit Sub
            End If
            If .Diaf Is Nothing Then .Diaf = New wn_Diaf
            '.Diaf.Riversa frmTab.Fatto, frmTab.Accoppiato
            .Diaf.Coperchio = formTab.Fatto
            .Diaf.Flangia = formTab.Accoppiato
            formDiaframma = New frmDiaf
            formDiaframma.objDiaf = .Diaf
            formDiaframma.Inizializza()
            If formTab.Accoppiato Is Nothing And Res Then
                Testo = "Non essendo stata definita la flangia o cassa" & vbCrLf
                Testo = Testo & "accoppiata al coperchio, alcuni dati relativi" & vbCrLf
                Testo = Testo & "al calcolo del diaframma dovranno essere forniti" & vbCrLf
                Testo = Testo & "manualmente."
                MessageBox.Show(Testo)
            End If
            If Res Then
                mioApert.Enabled = False
                formDiaframma.ShowDialog()
            End If
            formDiaframma.Dispose()
        End With
    End Sub
    Public Sub PressExtCil(ByRef DE As Single, ByRef t As Single, ByRef L0 As Single, ByRef td As Single, ByRef jRec As Short, ByRef psig As Single, ByRef psig1 As Single, ByRef psig2 As Single, ByRef Carta As String, Optional ByRef AsmeA As Single = -1, Optional ByRef AsmeB As Single = -1)
        Dim Syo, Sya As Single
        Dim Testo As String
        Dim pr, Sfo, Sfa, E As Single
        Select Case CType(CodiceStress(), Codes)
            Case Codes.div1MPa, Codes.div1psi, Codes.div2MPa, Codes.div2psi
                If DE / t < 4 Then
                    Asnell = 1.1 / (DE / t) ^ 2
                Else
                    Asnell = Matdim(jRec).Avalor(DE / t, L0 / DE)
                    If Asnell < 0 Then
                        Testo = " Codice di errore " & Str(Asnell) & " nel calcolo|"
                        Testo = Testo & " di A. D/T=" & Str(Asnell) & " L/D=" & Str(L0 / DE)
                        MessageBox.Show(Monitor.Motore.Inizio.ConvertiCr(Testo))
                        Exit Sub
                    End If
                End If
                Matdim(jRec).YieldTemp(CodiceStress, td, Sya, Syo)
                If Sya = 0 Then psig = -2 : Exit Sub
                AsmeA = Asnell
                psig = System.Math.Abs(Matdim(jRec).BValor(Asnell, td, 0, CodiceStress, Carta, 0))
                AsmeB = psig
                If psig <= -2 Then Exit Sub
                psig1 = psig * 4 / 3 * t / DE
                psig2 = 0
                If DE / t < 10 Then
                    psig1 = (2.167 / DE * t - 0.0833) * psig
                    S10 = 0.9 * Syo
                    Matdim(jRec).SigmaAmm(CodiceStress, td, Sfa, Sfo)
                    If 2 * Sfo < S10 Then S10 = 2 * Sfo
                    psig2 = 2 * S10 * t / DE * (1 - t / DE)
                End If
            Case Codes.EU
                Stheta = Matdim(jRec).SigmaTheta(CodiceStress, td)
                If Stheta = 0 Then Exit Sub
                psig = Stheta * t / ((DE - t) / 2)
                E = Matdim(jRec).EmodAlt(td)
                Asnell = epsmin((DE - t) / 2, L0, t, Nmin)
                Pm = E * t * Asnell / ((DE - t) / 2)
                Call Leggidelta(4, PrPy, Pm / psig)
                pr = PrPy * psig
                psig1 = pr / 1.5 '* psi
                psig2 = 0
        End Select
    End Sub

    Private Function AnellRinf(ByRef pext As Single, ByRef Dout As Single, ByRef t As Single, ByRef ts As Single, ByRef Ls As Single, ByRef indice As Short) As Boolean
        Dim Indmat As Short
        Dim Ips, id As Single
        Dim Testo As String
        Dim Chart As String = ""
        Dim tw, H, W, tw1 As Single
        Dim aneu, Avail, Amom, Area As Single
        Dim valid As Boolean
        Dim Ans As Integer
        Dim Stringa(3) As String
        Dim uu As String
        AnellRinf = True
        With Involucr(kLato, jInvolucr)
Rifa:
            H = .Dati1
            valid = H > 0
            W = .Dati(4 - 4)
            valid = valid And (W > 0 Or .Dati3 = 4)
            tw = .Dati2
            valid = valid And tw > 0
            tw1 = .Dati(5 - 4)
            valid = valid And (tw1 > 0 Or .Dati3 = 4)
            If Not valid Then
                Testo = "I dati relativi agli anelli di rinforzo non sono completi" & vbCrLf
                uu = Testo
                Testo = Testo & "   Cosa vuoi fare ?"
                Stringa(1) = "Introdurre nuovi dati di input e proseguire"
                Stringa(2) = "Procedere nel calcolo con i dati attuali"
                Stringa(3) = "Arrestare il calcolo"
                Ans = 2
                If Not ContinuoAuto Then Ans = Monitor.Motore.Quale(3, "Anelli di rinforzo su " & Trim(Involucr(kLato, jInvolucr).Mark), Stringa, "", 1, Testo)
                Select Case Ans
                    Case 1
                        StiffRings()
                        GoTo Rifa
                    Case 2
                        If ContinuoAuto Then
                            nIndent = 6
                            PrintlstRes(uu)
                            nIndent = 0
                        End If
                    Case Else
                        AnellRinf = False
                        Exit Function
                End Select
            End If
            Select Case .Dati3
                Case 0, 2 '(a) (c)
                    ASS = tw * H + (W - tw) * tw1
                Case 1 '(b)
                    ASS = tw * H + 2 * (W - tw) * tw1
                Case 3 '(d)
                    ASS = tw * H + (W - tw) * tw1
                Case 4 '(c)
                    ASS = tw * H
            End Select
            BanellRinf = 0.75 * (pext * Dout) / (t + ASS / Ls)
            Indmat = Matdim(indice).Indmat
            AanellRinf = System.Math.Abs(Matdim(indice).BValor(BanellRinf, Textdes, Indmat, CodiceStress, Chart, 1))
            Ips = Dout ^ 2 * Ls * (t + ASS / Ls) * AanellRinf / 10.9
            Avail = 1.1 * System.Math.Sqrt(Dout * ts)
            If Avail > Ls Then Avail = Ls
            Area = Avail * ts + ASS
            Select Case .Dati3
                Case 0, 2 '(a) (c)
                    Amom = ts * ts * Avail / 2 + (ts + H / 2) * tw * H + (ts + H - tw1 / 2) * (W - tw) * tw1
                Case 1 '(b)
                    Amom = ts * ts * Avail / 2 + (ts + H / 2) * tw * H + (ts + tw1 / 2 + ts + H - tw1 / 2) * (W - tw) * tw1
                Case 3 '(d)
                    Amom = ts * ts * Avail / 2 + (ts + H / 2) * tw * H + (ts + tw1 / 2) * (W - tw) * tw1
                Case 4 '(c)
                    Amom = ts * ts * Avail / 2 + (ts + H / 2) * ASS
            End Select
            aneu = Amom / Area
            id = Avail * ts ^ 3 / 12 + (aneu - ts / 2) ^ 2 * Avail * ts + H ^ 3 / 12 * tw + (ts + H / 2 - aneu) ^ 2 * H * tw
            Select Case .Dati3
                Case 0, 2 '(a) (c)
                    id = id + (W - tw) * (tw1 ^ 3 / 12 + (ts + H - tw1 / 2 - aneu) ^ 2 * tw1)
                Case 1 '(b)
                    id = id + (W - tw) * (tw1 ^ 3 / 12 + (ts + H - tw1 / 2 - aneu) ^ 2 * tw1)
                    id = id + (W - tw) * (tw1 ^ 3 / 12 + (ts + tw1 / 2 - aneu) ^ 2 * tw1)
                Case 3 '(d)
                    id = id + (W - tw) * (tw1 ^ 3 / 12 + (ts + tw1 / 2 - aneu) ^ 2 * tw1)
                Case 4 '(c)
            End Select
            .TubeMinT = Ips
            .TubeAdopt = id
        End With
    End Function
    Public Sub AzzeraLocalThk()
        Dim n As Short
        For n = Involucr(kLato, jInvolucr).inizio To Involucr(kLato, jInvolucr).Fine
            Nozzles(kLato, n).ShThkNozArea = 0
        Next
    End Sub
    Public Sub StrainTreat()
        Dim Mat As LibMat.MaterialeNew1
        Dim Rule As Short
        Dim ang As Single
        Dim ifl, i As Short
        Dim Parola As String
        Dim jj As Short
        With Involucr(kLato, jInvolucr)
            Mat = Matdim(.indice(1 - 1))
            If Mat Is Nothing Then Exit Sub
            If Not Mat.Classe = 1 Then Exit Sub
            If .MWDTrule Is Nothing Then
                MWDTdata(kLato, jInvolucr)
            ElseIf .MWDTrule.Length = 0 Then
                MWDTdata(kLato, jInvolucr)
            End If
            If .MWDTrule Is Nothing And div = 0 Then
                MostraAiuto(IDH_MDMT1, RoutBase1.ChiaviMess.MessInformation + RoutBase1.ChiaviMess.MessOkOnly, GlobalRoutines.FormatS(Helpstringa(IDH_MDMT1), Trim(Mat.MatStr)))
                Exit Sub
            ElseIf (InStr(.MWDTrule, "not") Or .MWDTrule.Length = 0) And div = 0 Then
                MostraAiuto(IDH_MDMT1, RoutBase1.ChiaviMess.MessInformation + RoutBase1.ChiaviMess.MessOkOnly, GlobalRoutines.FormatS(Helpstringa(IDH_MDMT1), Trim(Mat.MatStr)))
                Exit Sub
            ElseIf div = 1 Then
                If Not Mat.AQT Then Exit Sub
            Else
                If InStr(.MWDTrule, "UCS") Then
                    Rule = 1
                ElseIf InStr(.MWDTrule, "UHT") Then
                    Rule = 2
                Else
                    Exit Sub
                End If
            End If
            Doppio = False
            Select Case .Tipo
                Case 0 'cil
                    Rf = (.di + .Spess) / 2 : t = .Spess
                Case 1 'heads
                    Doppio = True
                    t = .Spess
                    Select Case .ms
                        Case 1 'Ell21
                            Rf = 0.17 * .di + .Spess / 2
                        Case 2 'Ellitt
                            Rf = .R0 + .Spess / 2
                        Case 3 'Toro
                            Rf = 0.06 * .di + .Spess / 2
                        Case 4
                            Rf = 0.1 * .di + .Spess / 2
                        Case 5
                            Rf = 0.154 * .di + .Spess / 2
                        Case 6 'Toro6
                            Rf = .R0 + .Spess / 2
                        Case 7, 8 'sfera
                            Rf = .L0 + .Spess / 2
                    End Select
                Case 2 'coni
                    ang = Involucr(kLato, jInvolucr).R0 * pi / 180
                    Rf = .di / 2 / System.Math.Cos(ang) + .Spess / 2
                    If .H0 > 0 Then
                        If .H0 + .Spess / 2 < Rf Then Rf = .H0 + .Spess / 2 : Doppio = True
                    End If
                    t = .Spess
                Case 3 'conoidi
                    Rf = .di / 2 + .Spess / 2
                    If .H0 > 0 Then
                        If .H0 + .Spess / 2 < Rf Then Rf = .H0 + .Spess / 2 : Doppio = True
                    End If
                    t = .Spess
                Case Else
                    MessageBox.Show("Valore di Tipo dell'Involucro non previsto in StrainTreat (" & Format(.Tipo))
            End Select
        End With
        ifl = FreeFile()
        With Monitor.Motore.Problem
            If div = 0 Then
                FileOpen(ifl, RTrim(clsInizio.Archdir) & "\RTF\ASME09.DAT", OpenMode.Input, , OpenShare.Shared)
                For i = 1 To 14 : StriSt(i) = LineInput(ifl) : Next
                FileClose(ifl)
                .Printa(StriSt(2) & StriSt(3) & StriSt(4))
                jj = 0
                Call PrintV(jj)
                If Rule = 1 Then
                    If Strain > 5 Then Parola = "Shall" Else Parola = "needs not to"
                    .Printa(GlobalRoutines.FormatS(StriSt(8), Parola))
                Else
                    If Strain < 5 Then
                        .Printa(StriSt(9))
                    ElseIf t > 16 Then
                        .Printa(StriSt(10))
                    Else
                        .Printa(StriSt(11))
                        .Printa(StriSt(12))
                        .Printa(StriSt(13))
                        .Printa(StriSt(14))
                    End If
                End If
            ElseIf div = 1 Then
                FileOpen(ifl, RTrim(clsInizio.Archdir) & "\RTF\ASME092.DAT", OpenMode.Input, , OpenShare.Shared)
                For i = 1 To 13 : StriSt(i) = LineInput(ifl) : Next
                FileClose(ifl)
                .Printa(StriSt(2) & GlobalRoutines.FormatS(StriSt(3), Trim(Mat.MatStr)) & StriSt(4) & StriSt(5) & StriSt(6))
                jj = 2
                Call PrintV(jj)
                If Strain < 5 Then
                    .Printa(StriSt(10))
                Else
                    .Printa(StriSt(11) & StriSt(12) & StriSt(13))
                End If
            End If
        End With
    End Sub
    Private Sub PrintV(ByVal jj As Short)
        With Monitor.Motore.Problem
            .Printa(GlobalRoutines.FormatS(StriSt(1), Rf, "[mm]", Rf / inc, "[in]"))
            .Printa(StriSt(5 + jj))
            .Printa(GlobalRoutines.FormatS(StriSt(1), t, "[mm]", t / inc, "[in]"))
            If Doppio Then
                Strain = 75 * t / Rf
                .Printa(StriSt(6 + jj) & Format(Strain, "##0.00"))
            Else
                Strain = 50 * t / Rf
                .Printa(StriSt(7 + jj) & Format(Strain, "##0.00"))
            End If
        End With
    End Sub
    Public Function epsmin(ByRef R As Single, ByRef l As Single, ByRef t As Single, ByRef Nmin As Short) As Single
        Dim i As Short
        Dim Min, eps As Single
        Min = clsTrigon.Infinito
        For i = 2 To 100
            eps = eps852(R, l, t, i)
            If eps > Min Then
                epsmin = Min
                Exit Function
            End If
            Min = eps
            Nmin = i
        Next
    End Function
    Public Function eps852(ByRef R As Single, ByRef l As Single, ByRef t As Single, ByRef n As Short) As Single
        Dim c, a, Z, ni, b, d As Single
        Z = pi * R / l
        ni = 0.3
        a = n * n - 1 + Z * Z / 2
        b = (n * n / Z / Z + 1) ^ 2
        c = t * t / 12 / R / R / (1 - ni * ni)
        d = (n * n - 1 + Z * Z) ^ 2
        eps852 = 1 / a * (1 / b + c * d)
    End Function
    Public Sub SuperCylThk(ByRef P0 As Single, ByRef td As Single, ByRef T0 As Single, _
    ByRef R As Single, ByRef ZSS As Single, ByRef ZES As Single, ByRef s As Single, _
    ByRef E As Single, ByRef uu As String, ByRef SWR As Single, ByRef Trs As Single, _
    ByRef Involucr As Involucro, ByRef Config As asConfig, Optional ByRef simple As Boolean = False)
        Select Case Config.DC
            Case 0, 1, 2, 9, 10, 11
                Call CylThk(P0, td, T0, R, ZSS, s, 1, SWR)
                Trs = T0
                If T0 = 0 Or simple Then Exit Sub
                Call CylThk(P0, td, T0, R, ZES, s, E, SWR) '------GOSUB 11000
            Case 3, 4, 5
                Call Cil(Involucr, Config, P0, td, T0)
                Trs = T0
            Case 6, 7, 8 'EuroNorm
                Call EuroCylThk(P0, td, T0, R, s, E, SWR)
                Trs = T0
        End Select
    End Sub
    Public Function CalcolBocch() As Boolean
        Dim nn As Short
        For nn = Involucr(kLato, jInvolucr).inizio To Involucr(kLato, jInvolucr).Fine
            SWR = Nozzles(kLato, nn).SWR : If SWR > 9 Then SWR = SWR - 10
            If Nozzles(kLato, nn).DCL = -1 Or Nozzles(kLato, nn).DCL = -2 Then
                Select Case Config(kLato).DC
                    Case 0, 1, 2, 9, 10, 11
                        If Not BranchesCal(0.0#, 0.0#, 0.0#, Involucr(kLato, jInvolucr).di, trh, tsh, tch, KZ, Nozzles(kLato, nn).EffN, SWR, Int(nn), jInvolucr, True) Then Exit Function
                    Case 3, 4, 5
                        MessageBox.Show("CalcolBocch da programmare per div.2")
                    Case 6, 7, 8 : MessageBox.Show("EuroNorm in CalcolBocch")
                End Select
            End If
        Next
    End Function
End Module