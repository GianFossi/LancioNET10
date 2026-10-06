Option Strict Off
Option Explicit On
Imports RoutBase1
Friend Class wn_AA
	'---------------------------------
	Private Const nMax As Short = 2
	Private Const icMax As Short = 15
    Private Const MaxIter As Short = 100 'MAWP 030506
	Private Const Espr As String = "0.000E+00"
	Private colFM As Collection
	'--------------------------------------
    Private ifl, SuperCorroso As Short
    Private TIMA, File, Affix, Tit As String
    Private TIMA2, TIMA1, TIMA3 As String
    Private Sfa, Sfo As Single
    Private Titolo As String
	Private ic As Short
    Private junctionOK(2, 16) As Short ' -1 incastro OK, 0 non OK, 1 analisi elastoplastica
	Private ElasPlas As Boolean
	Public Padre As wn_PT
	Public CalcMAWP As Boolean
	Public A02 As Short '0 ASME 2000; 1 + A02; 2 + A03;3 ASME2004
	Public retcods, retcodc As Short
    'Private Corroso As Integer '0 no 1 si
	Private unitErr As Short
	Private fileErr As Str50
    Private ptTipoAA As Short
	Private iGia As Boolean
	Private NNOTE, nr, NPAGE, NRIGHE, Ntot, NNOTSW As Short
	Private Nota(1) As String
	Private prContaPagAgg As Short
	'--------------------------------------
    Private alfai(1, 3, 5) As Single
    Private betai(1, 5, 5) As Single
	Private xValues(nMax) As Single
	Private FmValues(nMax) As Single
	'--------------------------------------
    Private Indmat, Ind As Short
    Private A0 As Single
	Private ac As Single
	Private aas As Single
	Private calcZd As Single
	Private calcZv As Single
	Private calcZm As Single
	Private calcFm As Single
	Private cs As Single
    Private CT As Single 'corrosione lato tubi
    Private cortubi, ctubi As Single
	Private dstar As Single
	Private dstari As Single
	Private d As Single 'diametro foro IBW
	Private dt As Single 'diametro tubo
	Private facts As Single
	Private factc As Single
	Private H As Single 'adopted thk
	Private hb As Single
	Private hbi As Single
	Private hbs As Single
	Private hbt As Single
	Private Hsh As Single
	Private HG As Single 'altezza groove
	Private hj As Single 'altezza dilatat
	Private hgprim As Single
	Private H1 As Single
	Private H2 As Single
	Private hpg As Single 'h primo g di AA-2.4.7
	Private hpg1 As Single 'riduzione spessore piastra in periferia per gola saldatura
	Public hr As Single
	Private hsup As Single
	Public ltx As Single
	Public ltxperc As Boolean
	Private p As Single
	Private pstar As Single
	Private pstari As Single
	Private rapp As Single
	Private SuperLoop As Boolean
	Private rappS As Single
	Private rappc As Single
	Private R0 As Single
	'Private tfa      As Single 'spessore adottato
	Private simplif As Boolean
	Private tc As Single
	Private Tm As Single
	Private ts As Single
	Private tsv1 As Single
	Private tt As Single 'spessore tubi
	Private tI As Single 'tc or ts
	Private xs As Single
	Private xt As Single
	Private a As Single
	Private c As Single 'bolt circle of the flange
	Private D0 As Single
	Private Destemp As Single
	Private DC As Single 'Diametro integrale lato channel
	Private Dm As Single
	Private Ds As Single
	Private di As Single 'Dc or Ds
	Private Ec As Single
	Private Eccorr As Single
	Private ES As Single
	Private Esv1 As Single
	Private Escorr As Single
	Private Et As Single
	Private E As Single
	Private EstarE As Single
	Private EstarE2 As Single
	Private EI As Single 'Ec or Es
	Private EIvecchio As Single 'non corretto per elastoplastico Step 12
	Private Esvec, Ecvec As Single
	Private FIAA152 As Single
	Private f As Single
	Private FO As Single
	Private Fq As Single
	Private g As Single 'Diametro efficace guarnizione
	Private GS As Single 'Diametro efficace guarnizione lato shell
	Private GC As Single 'Diametro efficace guarnizione lato channel
	Private k As Single
	Private j As Single
	Private Kj As Single
	Private Ks As Single
	Private Ksvt As Single
	Private kss As Single
	Private kt As Single
	Private ktt As Single
	Private Lunght As Single
	Private Lungh As Single
	Private Lungh1 As Single
	Private Lungh1p As Single
	Private MatTubes As String
	Private MG As Single
	Private MI As Single
	Private m0 As Single
	Private m1 As Single
	Private m2 As Single
	Private m3 As Single
	Private M4 As Single
	Private M0i As Single
	Private M1i As Single
	Private M2i As Single
	Private M3i As Single
	Private M4i As Single
	Private MTS As Single
	Private Mstar As Single
	Private Mp As Single
	Private NumTub As Single
	Private PressEff As Single
	Private Pressg As Single 'pressione equiv. alla dilat.
	Private Pressgs As Single
	Private Presss As Single
	Private Presst As Single
	Private Pressss As Single
	Private Presscs As Single
	Private Presssp As Single
	Private Presstp As Single
	Private Presssd As Single
	Private Presstd As Single
	Private Presstd1 As Single
	Private Presssd1 As Single
	Private Pressrim As Single
	Private PressI As Single 'Psd or Ptd, lato integral
	Private PressW As Single
	Private PrHTs As Single
	Private PrHTt As Single
	Private q1 As Single
	Private q2 As Single
	Private q3 As Single
	Private QZ1 As Single
	Private QZ2 As Single
	Private QZ2s As Single
	Private rhos As Single
	Private rhoc As Single
	Private lambdas As Single
	Private lambdac As Single
	Private deltas As Single
	Private deltac As Single
	Private omegas As Single
	Private omegac As Single
	Private omegass As Single
	Private omegacs As Single
	Private St As Single
	Private s As Single
	Private Sc As Single
	Private Scs As Single
	Private Syc As Single
	Private Si As Single 'Sc or Ss, lato Integral
	Private SS As Single
	Private SSS As Single
	Private Sys As Single
	Private SPS As Single 'AA-1.5.10 Prim+Sec. stress limit
	Private SPSs As Single 'AA-1.5.10 Prim+Sec. stress limit
	Private SPSc As Single 'AA-1.5.10 Prim+Sec. stress limit
	Private temp As Single 'T.S. design
	Private Tempc As Single 'Channel design
	Private Tempp As Single 'T.S. at the rim
	Private Tempt As Single 'tube design ?!
	Private Temps As Single 'shell  design
	Private Tempcp As Single 'channel @ TS
	Private Tempsp As Single 'shell @ TS
	Private Tempcs As Single
	Private Tempss As Single
	Private Temptm As Single
	Private Tempsm As Single
	Private Tempr As Single 'unperforated rim
	Private u As Single
	Private UL As Single
	Private V As Single
	Private W As Single 'flange design bolt load
	Private wm1 As Single
	Private wm2 As Single
	Private wot As Single
	Private Wc As Single
	Private Ws As Single
	Private Xa As Single
	Private Alfa As Single
	Private alfatm As Single
	Private alfasm As Single
	Private alfacp As Single
	Private alfasp As Single
	Private alfap As Single 'expansion of the TS
	Private betas As Single
	Private betac As Single
	Private eta As Single
	Private gamma As Single
	Private gammab As Single
	Private gammacs As Single
	Private gammass As Single
	Private gammac As Single
	Private gammas As Single
	Private lambdav As Single
	Private migrec As Single
	Private mistar As Single
	Private mistari As Single
	Private ni As Single
	Private nic As Single
	Private nis As Single
	Private nit As Single
	Private nistar As Single
	Private nistar2 As Single
	Private Psprim As Single
	Private Pcprim As Single
	Private Mps As Single
	Private Mpc As Single
	Private phig As Single
	Private rho As Single
	Private rhoi As Single
	Private Sigma As Single
	Private sigmab As Single
	Private sigmatv0 As Single
	Private sigma2 As Single
	Private sigma1G As Single
	Private sigma1 As Single
	Private Sigmac As Single
	Private sigmacvm As Single
	Private sigmacvb As Single
	Private sigmas As Single
	Private sigmasvm As Single
	Private sigmasvb As Single
	Private Tau As Single
	'----------------------------------
	Private MAWPChan(4) As Single
	Private MAWPShel(4) As Single
	Private jtubo As Short
	Private Verificando As Boolean
	'   0 nessuno 1 Fig AA-1.4.1 U bifl. non estesa
	'             2 Fig.AA-1.5.1 U integrale
	'             3 Fig.AA-1.6.1(a) U flangiata lato mantello
	'             4 Fig.AA-1.6.1(b) U flangiata lato cassa
	'             5 Fig.AA-2.0(a) f integrale
	'             6 Fig.AA-2.0(b) f flangiata lato cassa
	'             7 Fig.AA-2.0(c) f flangiata non estesa lato cassa
	'             8 Fig.AA-2.0(d) f bifl. non estesa
    Private Function NonTermici() As Boolean
        With CType(Padre.Piastra, wn_FTC)
            If .Rear = 1 Then
                Return False
            Else
                If Padre.GetPiastra = 1 Then
                    Select Case ptTipoAA
                        Case 101 : Return False
                        Case 102 : Return False
                        Case 103 : Return False
                        Case 104 : Return True
                        Case 105 : Return False
                        Case 106 : Return False
                    End Select
                Else
                    Select Case .Flottante
                        Case 1 : Return False 'P - outside packed
                        Case 2 : Return True 'S - with back ring
                        Case 3 : Return True 'T - flanged
                        Case 4 : Return False 'T - integral
                        Case 5 : Return True 'W
                    End Select
                End If
            End If
        End With
    End Function
    Private Function psi1(ByRef x As Single) As Single
        Dim Z1, Z, Res As Single
        Static xv, psi1v As Single
        If x <> xv Then
            Call KELVIN(x, 2, 0, Z, unitErr, fileErr)
            Call KELVIN(x, 1, 1, Z1, unitErr, fileErr)
            If x > 0 Then
                Res = Z + (1 - nistar) / x * Z1
            Else
                Res = 0
            End If
            xv = x : psi1v = Res
        End If
        psi1 = psi1v
    End Function
    Private Function psi2(ByRef x As Single) As Single
        Dim Z1, Z, Res As Single
        Static xv, psi2v As Single
        If x <> xv Then
            Call KELVIN(x, 1, 0, Z, unitErr, fileErr)
            Call KELVIN(x, 2, 1, Z1, unitErr, fileErr)
            If x > 0 Then
                Res = Z - (1 - nistar) / x * Z1
            Else
                Res = Z - (1 - nistar) / 2
            End If
            xv = x : psi2v = Res
        End If
        psi2 = psi2v
    End Function
    Private Function Za(ByRef x As Single) As Single
        Dim Z, Z1 As Single
        Call KELVIN(x, 2, 1, Z, unitErr, fileErr)
        Z = Z * psi2(x)
        Call KELVIN(x, 1, 1, Z1, unitErr, fileErr)
        Z = Z - Z1 * psi1(x)
        Za = Z
    End Function
    Private Function Zd(ByRef x As Single) As Single
        Dim Z, Z1 As Single
        Call KELVIN(x, 1, 0, Z, unitErr, fileErr)
        Z = Z * psi2(x)
        Call KELVIN(x, 2, 0, Z1, unitErr, fileErr)
        Z = (Z + Z1 * psi1(x)) / x ^ 3 / Za(x)
        Zd = Z
    End Function
    Private Function Zv(ByRef x As Single) As Single
        Dim Z, Z1 As Single
        Call KELVIN(x, 1, 1, Z, unitErr, fileErr)
        Z = Z * psi2(x)
        Call KELVIN(x, 2, 1, Z1, unitErr, fileErr)
        Z = (Z + Z1 * psi1(x)) / x ^ 2 / Za(x)
        Zv = Z
    End Function
    Private Function Zm(ByRef x As Single) As Single
        Dim Z, Z1 As Single
        Call KELVIN(x, 1, 1, Z, unitErr, fileErr)
        Z = Z * Z
        Call KELVIN(x, 2, 1, Z1, unitErr, fileErr)
        Z = (Z + Z1 * Z1) / x / Za(x)
        Zm = Z
    End Function
    Private Function Qm(ByRef x As Single, ByRef Xa As Single) As Single
        Dim Z As Single
        Static Zav, Zv, Z1v, XaV As Single
        If Xa <> XaV Then
            Call KELVIN(Xa, 1, 1, Zv, unitErr, fileErr)
            Call KELVIN(Xa, 2, 1, Z1v, unitErr, fileErr)
            Zav = Za(Xa)
            XaV = Xa
        End If
        Z = -Zv * psi1(x)
        Z = (Z + Z1v * psi2(x)) / Zav
        Qm = Z
    End Function
    Private Function Qv(ByRef x As Single, ByRef Xa As Single) As Single
        Dim Z As Single
        Static Zav, psi1v, psi2v, XaV As Single
        If Xa <> XaV Then
            psi1v = psi1(Xa)
            psi2v = psi2(Xa)
            Zav = Za(Xa)
            XaV = Xa
        End If
        Z = psi1v * psi2(x)
        Z = (Z - psi2v * psi1(x)) / Xa / Zav
        Qv = Z
    End Function
    Private Function Fm(ByRef x As Single, ByRef Xa As Single, ByRef q3 As Single) As Single
        Fm = (Qv(x, Xa) + q3 * Qm(x, Xa)) / 2
    End Function
    Public Sub New()
        MyBase.New()
        Dim j, ifl, i, k As Short
        Dim Nome As String
        ni = 0.3 : nis = 0.3 : nic = 0.3 : nit = 0.3
        nistar = 0.4
        unitErr = 9
        rho = 1
        fileErr.Str_Renamed = Monitor.Motore.Inizio.DiscoTem & "ErrMathAV.txt"
        ifl = FreeFile()
        Nome = Monitor.Motore.Inizio.Archdir & "\TableAA16.DAT"
        If OpenFile(Nome, ifl) Then
            For i = 0 To 1
                For j = 0 To 3
                    For k = -1 To 4
                        Input(ifl, alfai(i, j, k + 1))
                    Next
                Next
                For j = 0 To 5
                    For k = -1 To 4
                        Input(ifl, betai(i, j, k + 1))
                    Next
                Next
            Next
            FileClose(ifl)
        End If
        InitString()
        colFM = New Collection
        A02 = UltimoAggiornamento - 1
    End Sub
    Public Function Calcola() As Boolean
        Dim Res As Boolean
        Dim Cod As String
        Dim Fin, FinS As String
        Dim i, Tipo As Short
        Dim codice As Short
        Dim s, c As Single
        H = 0
        hr = 0
        If Not Abbassai() Then Exit Function
        If Not Abbassa(1) Then Exit Function
        AA13()
        rhoi = rho
        dstari = dstar
        pstari = pstar
        mistari = mistar
        Presssd1 = 0
        Presstd1 = 0
        codice = 1
        Res = Calc(Tipo, codice, 0)
        If Not Res Then
            Stampa(Tipo, codice)
            Exit Function
        End If
        Res = ScelSpes()
        If Not Res Then Exit Function
        Stampa(Tipo, codice)
        If Config(0).CalcMAWP = 1 And Not VerificandoPI Then
            If Not ContinuoAuto Then
                Monitor.Motore.ProgrInizio("Calcolo MAWP Piastra Tubiera (UHX) " & Involucr(kLato, jInvolucr).Mark.Trim, "AsmeVip", mioApert)
                InterrompiMAWP = False
            End If
            Res = MAWP(Tipo)
            CalcMAWP = False
            If Not ContinuoAuto Then Monitor.Motore.ProgrAmmazza()
            If Not Res Then Exit Function
            Cod = Space(5)
            ' Select Case ptTipoAA     030506
            '     Case 1 : Cap = 7     030506
            '     Case 2 : Cap = 10    030506
            '     Case 3, 4 : Cap = 11 030506
            '     Case Else : Cap = 12 030506
            ' End Select               030506
            If Monitor.Motore.Problem.FileStream Is Nothing Then Exit Function
            Call testaU(Cod, 7, Padre.Piastra.Rear) '030506
            Fin = "\par" : FinS = "_\par"
            With Monitor.Motore.Problem
                .Printa(Fin)
                .Printa(New String(CChar(" "), 29) & "MAWP CALCULATION [psi]" & Fin)
                .Printa(New String(CChar(" "), 29) & "======================" & Fin)
                .Printa(Fin)
                .Printa(New String(CChar(" "), 15) & "New&Cold      New&Hot   Corroded&Cold Corroded&Hot " & Fin)
                If Problem(Padre.IndProbl).PDIFF = 0 Then
                    .Printa(GlobalRoutines.FormatS("Differential  ######.0      ######.0     ######.0     ######.0" & FinS, System.Math.Abs(MAWPShel(1) - MAWPChan(1)), System.Math.Abs(MAWPShel(2) - MAWPChan(2)), System.Math.Abs(MAWPShel(3) - MAWPChan(3)), System.Math.Abs(MAWPShel(4) - MAWPChan(4))))
                Else
                    .Printa(GlobalRoutines.FormatS("Shell-side    ######.0      ######.0     ######.0     ######.0" & FinS, MAWPShel(1), MAWPShel(2), MAWPShel(3), MAWPShel(4)))
                    .Printa(GlobalRoutines.FormatS("Tube-side     ######.0      ######.0     ######.0     ######.0" & FinS, MAWPChan(1), MAWPChan(2), MAWPChan(3), MAWPChan(4)))
                End If
                For i = 1 To 4
                    If Problem(Padre.IndProbl).PDIFF = 0 Then
                        s = MAWPShel(i) : c = MAWPChan(i)
                        MAWPShel(i) = s - c : MAWPChan(i) = c - s
                    End If
                    If System.Math.Abs(Involucr(kLato, jInvolucr).MAWP(i - 1)) > System.Math.Abs(MAWPShel(i)) Then Involucr(kLato, jInvolucr).MAWP(i - 1) = MAWPShel(i)
                    If System.Math.Abs(Involucr(kLato, jInvolucr).MAWP2(i - 1)) > System.Math.Abs(MAWPChan(i)) Then Involucr(kLato, jInvolucr).MAWP2(i - 1) = MAWPChan(i)
                Next
            End With
        End If
        Calcola = Res
    End Function
    Private Function VERIFICA() As Boolean
        Dim ifl As Short
        'UPGRADE_WARNING: Dir ha un nuovo comportamento. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1041"'
        If Len(Dir(fileErr.Str_Renamed)) = 0 Then Exit Function
        ifl = FreeFile()
        FileOpen(ifl, fileErr.Str_Renamed, OpenMode.Input)
        If LOF(ifl) Then
            FileClose(ifl)
            Kill(fileErr.Str_Renamed)
            VERIFICA = True
        Else
            FileClose(ifl)
            MessageBox.Show("Errore wn_AA")
            VERIFICA = False
        End If
    End Function
    Private Function Abbassa(ByRef codice As Short) As Boolean
        'Dim i As Integer '1 CC, 2 NC, 3 CF, 4 NF
        Dim Sfa, Sfo As Single
        Abbassa = True
        With Padre
            Select Case codice
                Case 1, 3
                    cs = .CorShel
                    CT = .CorChan
                    ctubi = cortubi
                    SuperCorroso = 1
                Case 2, 4
                    cs = 0
                    CT = 0
                    ctubi = 0
                    SuperCorroso = 0
            End Select
            Select Case codice
                Case 1, 2
                    s = Involucr(kLato, jInvolucr).St
                    Destemp = .Destemp
                    Matdim(Involucr(kLato, jtubo).indice(1 - 1)).SigmaAmm(CodiceStress, Destemp, Sfa, Sfo)
                    St = Sfo 'operating del tubo
                    If St = 0 Then Abbassa = False : Exit Function
                Case 3, 4
                    s = Involucr(kLato, jInvolucr).S0
                    Destemp = 20
                    Matdim(Involucr(kLato, jtubo).indice(1 - 1)).SigmaAmm(CodiceStress, Destemp, Sfa, Sfo)
                    St = Sfa 'ambiente del tubo
            End Select
            If ptTipoAA < 5 Then
                Et = Matdim(Involucr(kLato, jtubo).indice(1 - 1)).EmodAlt(Destemp)
                If Et = 0 Then Abbassa = False : Exit Function
                E = Matdim(Involucr(kLato, jInvolucr).indice(1 - 1)).EmodAlt(Destemp)
                If E = 0 Then Abbassa = False : Exit Function
            End If
            If CalcMAWP And ic > 0 Then Exit Function
            Presss = .PDesShel
            Presst = .PDesChan
            PrHTs = .PHTShel
            PrHTt = .PHTChan
            Presssd = Presss
            Presstd = Presst
            'If .VacuumSS Then Presstd = Presst + Config(1).pxExt
            'If .VacuumTS Then Presssd = Presss + Config(2).pxExt
            If Problem(.IndProbl).PDIFF = 0 Then
                PressEff = .DiffPress
                If PressEff = 0 Then
                    PressEff = System.Math.Abs(Presssd - Presstd)
                ElseIf PressEff > 0 Then
                    If Presssd - PressEff < Presstd Then Presstd = Presssd - PressEff
                Else
                    If Presstd + PressEff < Presssd Then Presssd = Presstd + PressEff
                End If
            Else
                PressEff = Presssd
                If Presstd > PressEff Then PressEff = Presstd
            End If
        End With
    End Function
    Private Sub AA13(Optional ByRef iCond As Short = 0)
        Dim Corroso As Short
        If A02 < 3 Then
            If UL > 4 * p Then UL = 4 * p
        Else
            If UL > 4 * p * D0 Then UL = 4 * p * D0
            d = Padre.diamIBW
        End If
        If A02 < 3 Or Not Padre.IBW Then
            migrec = (p - dt) / p
            R0 = (D0 - dt) / 2
            If ltxperc Then
                rho = ltx / 100
            Else
                If H = 0 Then
                    rho = 0
                Else
                    rho = ltx / H
                End If
            End If
            If rho < 0 Then rho = 0
            If rho > 1 Then rho = 1
            dstar = dt - 2 * (tt - ctubi) * Et * St / E / s * rho
            If dt - 2 * tt > dstar Then dstar = dt - 2 * (tt - ctubi)
            Select Case A02
                Case 0
                    pstar = p / System.Math.Sqrt(1 - 8 * R0 * UL / pi / D0 ^ 2)
                Case 1, 2
                    pstar = p / System.Math.Sqrt(1 - 4 * UL / pi / D0)
                Case Else
                    pstar = p / System.Math.Sqrt(1 - 4 * UL / pi / D0 / D0)
            End Select
        Else
            migrec = (p - d) / p
            R0 = (D0 - d) / 2
            dstar = d
            pstar = p / System.Math.Sqrt(1 - 4 * UL / pi / D0 / D0)
        End If
        mistar = (pstar - dstar) / pstar
        If ptTipoAA > 4 Then
            CType(Padre.Piastra, wn_FTC).Zp(iCond, 382 + SuperCorroso * (718 - 382)) = dstar
            CType(Padre.Piastra, wn_FTC).Zp(iCond, 383 + SuperCorroso * (725 - 383)) = pstar
            CType(Padre.Piastra, wn_FTC).Zp(iCond, 384 + SuperCorroso * (732 - 384)) = mistar
        End If
    End Sub
    Public Function AA14() As Boolean
        hb = 0.556 * (g / D0) ^ (Alfa * System.Math.Log(mistar)) * g * System.Math.Sqrt(PressEff / 1.5 / mistar / s)
        H1 = hb : If HG - CT > 0 Then H1 = hb + HG - CT
        H2 = PressEff * D0 / 3.2 / migrec / s
        hr = H1 : If H2 > hr Then hr = H2
        AA14 = True
    End Function
    Private Function AA15(ByRef Tipo As Short) As Boolean
        Dim tmDm As Single
        Dim Res As Boolean
        Res = IntegDiam(Tipo, False)
        If Not Res Then Exit Function
        AA15 = True
        Dm = (Ds + DC) / 2 + (ts + tc) / 2
        Tm = (ts ^ (5 / 2) + tc ^ (5 / 2)) ^ (2 / 5)
        tmDm = Tm / Dm
        If tmDm < 0.02 Then
            FIAA152 = 1
        ElseIf tmDm > 0.05 Then
            FIAA152 = 0.8
        Else
            FIAA152 = 1 + (tmDm - 0.02) / (0.05 - 0.02) * (0.8 - 1)
        End If
        hbs = 0.556 * (Ds / D0) ^ (Alfa * System.Math.Log(mistar)) * Ds * System.Math.Sqrt(Presssd / 1.5 / mistar / s) * FIAA152
        hbt = 0.556 * (DC / D0) ^ (Alfa * System.Math.Log(mistar)) * DC * System.Math.Sqrt(Presstd / 1.5 / mistar / s) * FIAA152
        hb = hbs : If hbt > hb Then hb = hbt
        H1 = hb : If HG - CT > 0 Then H1 = hb + HG - CT
        H2 = PressEff * D0 / 3.2 / migrec / s
        hr = H1 : If H2 > hr Then hr = H2
    End Function
    Private Sub Calcolastar()
        Dim n1a, i, n2a As Short
        Dim n2b, n1b, j As Short
        Dim k As Short
        Dim nistar1, nistar2 As Single
        Dim Estar1, Estar2 As Single
        Select Case Padre.TipPass
            Case 1 : i = 1 'quadr
            Case 0 : i = 0 'triang
            Case Else : Stop
        End Select
        Try
            n1a = -1 : n1b = -1 : n2a = -1 : n2b = -1
            If hsup <= 0.10001 Then
                n1a = 0 : n1b = 0
            ElseIf hsup >= 1.9999 Then
                n1a = 3 : n1b = 5
            Else
                For j = 3 To 0 Step -1
                    If hsup > alfai(i, j, 0) Then
                        n1a = j : n2a = j + 1
                        Exit For
                    End If
                Next
                For j = 5 To 0 Step -1
                    If hsup > betai(i, j, 0) Then
                        n1b = j : n2b = j + 1
                        Exit For
                    End If
                Next
            End If
            Estar1 = 0
            For k = 0 To 4
                Estar1 = Estar1 + alfai(i, n1a, k + 1) * mistar ^ k
            Next
            If n2a > -1 Then
                Estar2 = 0
                For k = 0 To 4
                    Estar2 = Estar2 + alfai(i, n2a, k + 1) * mistar ^ k
                Next
                EstarE = Estar1 + (Estar2 - Estar1) * (hsup - alfai(i, n1a, 0)) / (alfai(i, n2a, 0) - alfai(i, n1a, 0))
            Else
                EstarE = Estar1
            End If
            nistar1 = 0
            For k = 0 To 4
                nistar1 = nistar1 + betai(i, n1b, k + 1) * mistar ^ k
            Next
            If n2b > -1 Then
                nistar2 = 0
                For k = 0 To 4
                    nistar2 = nistar2 + betai(i, n2b, k + 1) * mistar ^ k
                Next
                nistar = nistar1 + (nistar2 - nistar1) * (hsup - betai(i, n1b, 0)) / (betai(i, n2b, 0) - betai(i, n1b, 0))
            Else
                nistar = nistar1
            End If
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Private Function AA16(ByRef Tipo As Short, ByRef codice As Short) As Boolean
        Dim hbvec As Single
        Dim Res As Boolean
        Dim innerloop, outerloop As Short
        'tipo 1 flangiata lato shell
        'tipo 2 flangiata lato tubi
        Res = FlangedDati(Tipo, codice)
        If Not Res Then Exit Function
        AA16 = True
        W = wm1
        If Presssd1 > 0 Or Presstd1 > 0 Then
            Select Case ptTipoAA
                Case 3 : If Presssd1 > 0 Then W = W * Presssd / Presssd1
                Case 4 : If Presstd1 > 0 Then W = W * Presstd / Presstd1
            End Select
        End If
        If wm2 > W Then W = wm2
        If wot > W Then W = wot
        k = g / D0
        If (di + 2 * tI) > g Then k = (di + 2 * tI) / D0
        hsup = 2
        Calcolastar()
        EstarE2 = EstarE
        nistar2 = nistar
        FO = (1 - nistar) / EstarE * System.Math.Log(k)
        If c = 0 Then
            MessageBox.Show("Non è stato specificato il diametro di installazione dei tiranti")
            AA16 = False
            Exit Function
        End If
        MG = W * c / 2 / pi / D0 * (1 - g / c) + Pressg * D0 ^ 2 / 16 * (g / D0 - 1) * (g ^ 2 / D0 ^ 2 + 1)
        MI = W * c / 2 / pi / D0 * (1 - g / c) - PressI * D0 ^ 2 / 16 * (di / D0 - 1) * (di ^ 2 / D0 ^ 2 + 1)
        M1i = (MG - D0 ^ 2 / 32 * FO * Pressg) / (1 + FO)
        M2i = (MI + D0 ^ 2 / 32 * FO * PressI) / (1 + FO)
        M3i = M1i + D0 ^ 2 / 64 * (3 + nistar) * Pressg
        M4i = M2i - D0 ^ 2 / 64 * (3 + nistar) * PressI
        M0i = System.Math.Abs(M3i)
        If System.Math.Abs(M4i) > M0i Then M0i = System.Math.Abs(M4i)
        hbi = System.Math.Sqrt(6 * M0i / 1.5 / mistar / s)
        hb = hbi
        rho = rhoi
        EIvecchio = EI
        outerloop = 0
        Do
            innerloop = 0
            Do
                Step6()
                sigmab = 6 * m0 / mistar / hb ^ 2
                If SuperLoop Then
                    Exit Do
                Else
                    hbvec = hb
                    hb = System.Math.Sqrt(sigmab / 1.499 / s) * hb
                    If System.Math.Abs(hb - hbvec) / hb < 10 * clsTrigon.TOLER Then Exit Do
                    If innerloop > 50 Then
                        MessageBox.Show("Non converge dentro")
                        Exit Do
                    End If
                End If
                innerloop = innerloop + 1
            Loop
            phig = EI / E * (tI / hb) ^ 2 * System.Math.Sqrt(tI / di) * (1 - nistar) / EstarE * D0 * (2 / hb + 1.816 / System.Math.Sqrt(di * tI))
            sigma2 = -6 / tI ^ 2 * phig * (m2 - D0 ^ 2 / 32 * PressI) + 0.7717 * di / tI * PressI
            sigma1G = -6 / tI ^ 2 * phig * (m1 + D0 ^ 2 / 32 * Pressg)
            sigma1 = System.Math.Abs(sigma2)
            If System.Math.Abs(sigma1G) > sigma1 Then sigma1 = System.Math.Abs(sigma1G)
            rapp = sigma1 / Si
            SuperLoop = True
            If rapp <= 1.5001 Then 'OK
                simplif = False
                Exit Do
            ElseIf rapp <= 3.001 Then  'And EIvecchio = 0 Then  'simplified elasto-plastic calculation
                simplif = True
                'EIvecchio = EI
                EI = EIvecchio * System.Math.Sqrt(1.5 * Si / sigma1)
                Step6()
                sigmab = 6 * m0 / mistar / hb ^ 2
                If sigmab < 1.5 * s Then Exit Do '???? S era Si
                SuperLoop = True
                hb = hb * (sigmab / 1.499 / s) ^ 0.75 '???? S era Si
            Else ' aumentare hb
                simplif = False
                SuperLoop = True
                hb = hb * (sigma1 / 2.999 / s) ^ 0.25 '???? S era Si
            End If
            If outerloop > 50 Then
                MessageBox.Show("Non converge fuori")
                Exit Do
            End If
            outerloop = outerloop + 1
        Loop
Step13:
        H1 = hb : If HG - CT > 0 Then H1 = hb + HG - CT
        H2 = PressEff * D0 / 3.2 / migrec / s
        hr = H1 : If H2 > hr Then hr = H2
        Exit Function
    End Function
    Private Sub Step6()
        hsup = hb / p
        If hsup > 2 Then hsup = 2
        If hsup < 0.1 Then hsup = 0.1
        If Not ltxperc Then AA13()
        Calcolastar()
        '  EI = 180000
        lambdav = lambda()
        f = (1 - nistar) / EstarE * (EI / E * lambdav + System.Math.Log(k))
        m1 = (MG - D0 ^ 2 / 32 * f * Pressg) / (1 + f)
        m2 = (MI + D0 ^ 2 / 32 * f * PressI) / (1 + f)
        m3 = m1 + D0 ^ 2 / 64 * (3 + nistar) * Pressg
        M4 = m2 - D0 ^ 2 / 64 * (3 + nistar) * PressI
        m0 = System.Math.Abs(m3)
        If System.Math.Abs(M4) > m0 Then m0 = System.Math.Abs(M4)
        If System.Math.Abs(m1) > m0 Then m0 = System.Math.Abs(m1)
        If System.Math.Abs(m2) > m0 Then m0 = System.Math.Abs(m2)
    End Sub
    Private Function lambda() As Single
        Dim a, b As Single
        a = di / 2 / tI
        b = tI / hb
        lambda = 2.235 * b / System.Math.Sqrt(a) + 2.825 * b ^ 3 * System.Math.Sqrt(a) + 3.631 * b ^ 2
    End Function
    Private Sub StampAA16()
        Dim Cod, Tit As String
        If A02 < 2 Then
            Tit = "P.T. App.AA-1.6"
        Else
            Tit = "P.T. UHX-12"
        End If
        If Not PrepRapp(Template, Tit, Involucr(kLato, jInvolucr).Mark.Trim & " (" & Tit.Substring(5) & ")", FileSt, mioApert.lstRapp) Then Exit Sub
        Cod = Space(5)
        Call testaU(Cod, 11, 3)
        Call printa()
        Call printAA13(1)
        Call printAA162()
        Call printAA163a()
        Call printAA163b()
        Call printStep7()
        Call printStep10()
    End Sub
    Private Sub count()
        nr = nr + 1
        If (nr < NRIGHE + 1) Then Exit Sub
        nr = 0
        NPAGE = NPAGE + 1
        If (Ntot < NPAGE) Then Ntot = NPAGE
        iGia = False
        Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS("         -TubeSheet Calculation pag. ## ", NPAGE) & "\par \page ")
    End Sub
    Private Sub testaU(ByRef Cod As String, ByRef Cap As Short, ByRef mode As Short, Optional ByRef Offset As Short = 0)
        'mode 1 fixed, 2 floating 3 U
        Dim i, ifl As Short
        Dim StriSt(25) As String
        Dim File As String = ""
        Dim n As Short
        Dim Piastra As Short
        'AA-1.4 Cap= 7
        'AA-1.5 Cap=10
        'AA-1.6 Cap=11
        'AA-2.0 Cap=12
        Piastra = 1 : If Offset = 8 Then Piastra = 2
        ifl = FreeFile()
        Select Case mode
            Case 1
            Case 2
                If A02 = 1 Then
                    File = "\RTF\STAM0602Fl.TXT"
                    n = 21
                ElseIf A02 >= 2 Then
                    File = "\RTF\STAM0603Fl.TXT"
                    n = 22
                End If
            Case 3
                If A02 = 0 Then
                    File = "\RTF\STAM06.EXT"
                    n = 14
                ElseIf A02 = 1 Then
                    File = "\RTF\STAM0602.TXT"
                    n = 16
                ElseIf A02 >= 2 Then
                    File = "\RTF\STAM0603.TXT"
                    n = 17
                End If
        End Select
        File = Monitor.Motore.Inizio.Archdir & File
        If Not OpenFile(File, ifl) Then Exit Sub
        For i = 1 To n
            StriSt(i) = LineInput(ifl)
        Next
        FileClose(ifl)
        With Monitor.Motore.Problem
            If .pag > 0 Then iGia = True
            If Not iGia Then
                iGia = True
                'Else
                .Printa("\page \par ") : nr = 1
                .pag = CShort(.pag + 1)
            End If
            .Printa(StriSt(9))
            Call count() : .Printa(GlobalRoutines.FormatS(StriSt(2), Cod, clsInizio.Firma, Monitor.Motore.About.ProgName, Monitor.Motore.About.ProgVers)) '"\   \         FBM-HUDSON ITALIANA S.p.A.         Program: \      \ Vers. \    \       "
            'Call count() : .Printa(StriSt(3)) '"              ==========================                                         "
            Call count() : .Printa(GlobalRoutines.FormatS(StriSt(4), CodiceCalc)) '"      TUBULAR EXCHANGER MANUFACTURER ASSOCIATION 1988 7th ed. + add.92"
            Call count() : .Printa(StriSt(5)) '"      ================================================================"
            Call count() : .Printa(StriSt(6)) '"                  RCB-7.132 RCB-7.1342 RCB-7.162"
            Select Case mode
                Case 1
                Case 2
                    Call count() : .Printa(StriSt(7)) '"                  RCB-7.132 RCB-7.1342 RCB-7.162"
                    Call count() : .Printa(StriSt(19 + Piastra))
                    Select Case Piastra
                        Case 1
                            Call count() : .Printa(StriSt(9 + ptTipoAA - 100))
                        Case 2
                            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Padre.Piastra.Flottante. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                            Select Case Padre.Piastra.Flottante
                                Case 1, 4 : Call count() : .Printa(StriSt(16))
                                Case 3 : Call count() : .Printa(StriSt(17))
                                Case 2 : Call count() : .Printa(StriSt(18))
                                Case 5 : Call count() : .Printa(StriSt(19))
                            End Select
                    End Select
                Case 3
                    Call count() : .Printa(StriSt(Cap)) '"           U  TUBESHEETS  WITH EXTENSION AS A FLANGE"
                    If A02 = 0 Then
                        Select Case ptTipoAA
                            Case 3 : Call count() : .Printa(StriSt(13))
                            Case 4 : Call count() : .Printa(StriSt(14))
                        End Select
                    Else
                        Select Case ptTipoAA
                            Case 0 : Call count() : .Printa(StriSt(10))
                            Case 1 : Call count() : .Printa(StriSt(11))
                            Case 2 : Call count() : .Printa(StriSt(12))
                            Case 3
                                i = 13
                                If Padre.SlChanDati(1) < 0 Then i = 17
                                Call count() : .Printa(StriSt(i))
                            Case 30 : Call count() : .Printa(StriSt(14))
                            Case 4 : Call count() : .Printa(StriSt(15))
                            Case 40 : Call count() : .Printa(StriSt(16))
                        End Select
                    End If
            End Select
            Call count() : .Printa(StriSt(8)) '"           ==============================================="
            If A02 >= 2 Then Call count() : .Printa(StriSt(22))
        End With
    End Sub
    Private Sub printa()
        Dim Flangia(2) As String
        Dim StriSt(88) As String
        Dim ifl As Short
        Dim Cod As String
        Dim i, j As Short
        Dim Nome As String
        Dim Integral As Boolean
        Integral = (ptTipoAA = 2 Or ptTipoAA = 5 Or ptTipoAA = 6)
        Flangia(0) = "tube"
        Flangia(1) = "shell"
        ifl = FreeFile()
        Nome = RTrim(Monitor.Motore.Inizio.Archdir) & "\RTF\STAM07AA.EXT"
        If Not OpenFile(Nome, ifl) Then Exit Sub
        For i = 1 To 88 '83
            StriSt(i) = LineInput(ifl)
        Next
        FileClose(ifl)
        Dim prob As RoutBase1.clsProblem = Monitor.Motore.Problem
        prob.Printa(StriSt(80))
        For j = 1 To 2 : Call count() : prob.Printa(StriSt(1)) : Next
        Call count() : prob.Printa(GlobalRoutines.FormatS(StriSt(2), Trim(Involucr(kLato, jInvolucr).Mark))) ' Problem(IndProbl).TipPias(1)) '"T. SHEET IDENTIF.     : &"
        Call count() : prob.Printa(GlobalRoutines.FormatS(StriSt(3), Trim(Involucr(kLato, jInvolucr).MATE))) ' Problem(IndProbl).MatPias(1)) '"T. SHEET MATERIAL     : &"
        With Padre
            If .mart Then
                Select Case .bdice
                    Case 1
                        Call count() : prob.Printa(GlobalRoutines.FormatS(StriSt(4), .FlChanNome)) '"GASKET TYPE           : &"
                        Call count() : prob.Printa(GlobalRoutines.FormatS(StriSt(5), .FlChanDati(8))) 'FlChan(IndProbl).MatGuar) '"GASKET MATERIAL       : &"
                        Call count() : prob.Printa(GlobalRoutines.FormatS(StriSt(6), .MatBull(1))) '"STUDS  MATERIAL       : &"
                        Call count() : prob.Printa(StriSt(1))
                    Case 2
                        Call count() : prob.Printa(GlobalRoutines.FormatS(StriSt(4), .FlShelNome)) '"GASKET TYPE           : &"
                        Call count() : prob.Printa(GlobalRoutines.FormatS(StriSt(5), .FlShelDati(8))) 'FlShel(IndProbl).MatGuar) '"GASKET MATERIAL       : &"
                        Call count() : prob.Printa(GlobalRoutines.FormatS(StriSt(6), .MatBull(2))) '"STUDS  MATERIAL       : &"
                        Call count() : prob.Printa(StriSt(1))
                End Select
            End If
            Call count() : prob.Printa(StriSt(7)) '"                                  INPUT DATA"
            Call count() : prob.Printa(StriSt(8)) '"                                  =========="
            For j = 1 To 2 : Call count() : prob.Printa(StriSt(1)) : Next
            Call count() : prob.Printa(GlobalRoutines.FormatS(StriSt(9), Presst, Presst * psi)) '"Ps    =    ###.#### MPa     #######.#### psi      Design pressure  (tube-side)"
            Call count() : prob.Printa(GlobalRoutines.FormatS(StriSt(10), Presss, Presss * psi)) '"Pt    =    ###.#### MPa     #######.#### psi      Design pressure (shell-side)"
            If .SPHT = 0 Then
                If .bdice = 0 Then
                    Call count() : prob.Printa(GlobalRoutines.FormatS(StriSt(11), PrHTt, PrHTt * psi)) '"Psh   =  #####.#### MPa     #######.#### psi      Hydr.t.pressure  (tube-side)"
                    Call count() : prob.Printa(GlobalRoutines.FormatS(StriSt(12), PrHTs, PrHTs * psi)) '"Pth   =  #####.#### MPa     #######.#### psi      Hydr.t.pressure (shell side)"
                Else
                    Call count() : prob.Printa(GlobalRoutines.FormatS(StriSt(13), PrHTt, PrHTt * psi)) '"Psh   =  #####.#### MPa     #######.#### psi      Hydr.t.pressure (flanged side)"
                    Call count() : prob.Printa(GlobalRoutines.FormatS(StriSt(14), PrHTs, PrHTs * psi)) '"Pth   =  #####.#### MPa     #######.#### psi      Hydr.t.pressure(welded side)"
                End If
            End If
            Call count() : prob.Printa(GlobalRoutines.FormatS(StriSt(15), Destemp, Destemp * 1.8 + 32)) '"Tp    =  #####.#### øC      #######.#### øF       Design temperature"
            If Not Integral Then
                If .mart Then
                    If .bdice < 2 Then
                        Call count()
                        prob.Printa(GlobalRoutines.FormatS(StriSt(16), .FlChanDati(1), .FlChanDati(1) / inc))
                    End If '"At    = #########.## mm     #######.#### in       Flange outside diameter (T.S.)"
                    If .bdice <> 1 And .FlShelDati(1) > 0 Then
                        Call count()
                        prob.Printa(GlobalRoutines.FormatS(StriSt(17), .FlShelDati(1), .FlShelDati(1) / inc))
                    End If '"As    = #########.## mm     #######.#### in       Flange outside diameter (S.S.)"
                End If
                Call count() : prob.Printa(GlobalRoutines.FormatS(StriSt(18), .TSheDes, .TSheDes / inc)) '"A     = #########.## mm     #######.#### in       T.S. outside diameter"
                Call count() : prob.Printa(GlobalRoutines.FormatS(StriSt(19), c, c / inc)) '"C     = #########.## mm     #######.#### in       Bolt-Circle diameter"
                If .bdice < 2 Then Call count() : prob.Printa(GlobalRoutines.FormatS(StriSt(20), GC, GC / inc)) '"Gt    = #########.## mm     #######.#### in       Gasket mean diameter,T.S."
                If .bdice <> 1 Then Call count() : prob.Printa(GlobalRoutines.FormatS(StriSt(21), GS, GS / inc)) '"Gs    = #########.## mm     #######.#### in       Gasket mean diameter,S.S."
                If .bdice < 2 Then
                    Call count()
                    prob.Printa(GlobalRoutines.FormatS(StriSt(22), .FlShelDati(2), .FlShelDati(2) / inc))
                End If '"Bt    = #########.## mm     #######.#### in       Inter. flange  dia., T.S."
                If .bdice <> 1 Then
                    If .FlChanDati(2) > 0 Then
                        Call count()
                        prob.Printa(GlobalRoutines.FormatS(StriSt(23), .FlChanDati(2), .FlChanDati(2) / inc))
                    End If
                End If '"Bs    = #########.## mm     #######.#### in       Inter. flange  dia., S.S."
                If .mart And .FlChanDati(2) > 0 Then
                    If .bdice < 2 Then
                        Call count()
                        prob.Printa(GlobalRoutines.FormatS(StriSt(24), .FlChanDati(3), .FlChanDati(3) / inc))
                    End If '"g1t   = #########.## mm     #######.#### in       Flange hub max thickness, T.S."
                    If .bdice <> 1 Then
                        Call count()
                        prob.Printa(GlobalRoutines.FormatS(StriSt(25), .FlShelDati(3), .FlShelDati(3) / inc))
                    End If '"g1s   = #########.## mm     #######.#### in       Flange hub max thickness, S.S."
                    If .bdice < 2 Then
                        Call count()
                        prob.Printa(GlobalRoutines.FormatS(StriSt(26), .FlChanDati(4), .FlChanDati(4) / inc))
                    End If '"g0t   = #########.## mm     #######.#### in       Flange hub min thickness, T.S."
                    If .bdice <> 1 Then
                        Call count()
                        prob.Printa(GlobalRoutines.FormatS(StriSt(27), .FlShelDati(4), .FlShelDati(4) / inc))
                    End If '"g0s   = #########.## mm     #######.#### in       Flange hub min thickness, S.S."
                End If
            Else
                Call count()
                prob.Printa(GlobalRoutines.FormatS(StriSt(22), .SlShelDati(1), .SlShelDati(1) / inc))
                Call count()
                prob.Printa(GlobalRoutines.FormatS(StriSt(23), .SlChanDati(1), .SlChanDati(1) / inc))
                Call count()
                prob.Printa(GlobalRoutines.FormatS(StriSt(81), .SlShelDati(2), .SlShelDati(2) / inc))
                Call count()
                prob.Printa(GlobalRoutines.FormatS(StriSt(82), .SlChanDati(2), .SlChanDati(2) / inc))
            End If
            If .bdice > 0 And .SlChanDati(1) > 0 Then
                Call count() : prob.Printa(GlobalRoutines.FormatS(StriSt(28), di, di / inc)) '"Bs    = #########.## mm     #######.#### in       Inter. tube-sh. dia.(Corroded)"
                Call count() : prob.Printa(GlobalRoutines.FormatS(StriSt(29), tI, tI / inc)) '"Ts    = #########.## mm     #######.#### in       Shell thickness (Corroded)"
            Else
                'CALL count: PRINT #iout, USING StriSt$(30); DatiInt(Indprobl).gef; DatiInt(Indprobl).gef / inc'"Bs    = #########.## [mm]     #######.#### [in]       Mean gsk dia.(minimum on sides)"
            End If
            Call count() : prob.Printa(GlobalRoutines.FormatS(StriSt(31), H, H / inc)) '"T     = #########.## mm     #######.#### in       T. sheet thk. adopted (center)"
            'Call count: Print #iout, FormatS(StriSt$(32), tRa, tRa / inc) '"Tr    = #########.## [mm]     #######.#### [in]       T. sheet thk. adopted (ext.)"
            Call count() : prob.Printa(GlobalRoutines.FormatS(StriSt(33), cs, cs / inc)) '"Cs    = #########.## mm     #######.#### in       Shell side corrosion"
            '  If Padre.SlChanDati(1) > 0 Then
            Call count() : prob.Printa(GlobalRoutines.FormatS(StriSt(34), CT, CT / inc)) '"Ct    = #########.## [mm]     #######.#### [in]       Tube side corrosion"
            Call count() : prob.Printa(GlobalRoutines.FormatS(StriSt(35), HG, HG / inc)) '"Gr    = #########.## [mm]     #######.#### [in]       Tube side corr. or groove"
            ' End If
            If Not Integral Then
                If .mart Then
                    Call count() : prob.Printa(GlobalRoutines.FormatS(StriSt(36), .DiNBull(1))) '"d     =                \                 \ --       Bolts nominal diameter"
                    Call count() : prob.Printa(GlobalRoutines.FormatS(StriSt(37), .NumBolt(1))) '"Nø    =                       #########    --       Number of bolts"
                    Call count() : prob.Printa(GlobalRoutines.FormatS(StriSt(38), .AreBolt(1))) '"Ab1   =                       #######.#### iný      Area of one bolt"
                    If .bdice = 0 Then
                        Call count() : prob.Printa(GlobalRoutines.FormatS(StriSt(39), .NumColl(1))) '"Nø    =                       #########    --       Number of bolts with collars"
                    End If
                    Call count() : prob.Printa(GlobalRoutines.FormatS(StriSt(40), .BSpcMin(1), .BSpcMin(1) / inc)) '"BSmin = #########.## mm     #######.#### in       Minimum bolt spacing"
                    Call count() : prob.Printa(GlobalRoutines.FormatS(StriSt(41), .BoltSpc, .BoltSpc / inc)) '"BS    = #########.## mm     #######.#### in       Actual  bolt spacing"
                End If
            End If
            For j = 1 To 2 : Call count() : prob.Printa(StriSt(1)) : Next
            Call count() : prob.Printa(GlobalRoutines.FormatS(StriSt(42), .AllFRoo, .AllFRoo * psi)) '"Sfa   =  #####.#### MPa     #######.#### psi      All.Des.Stress, t.sheet at room"
            Call count() : prob.Printa(GlobalRoutines.FormatS(StriSt(43), .AllFOpe, .AllFOpe * psi)) '"Sfo   =  #####.#### MPa     #######.#### psi      All.Des.Stress, t.sheet at temp."
            If .mart < 2 Then
                Call count() : prob.Printa(GlobalRoutines.FormatS(StriSt(44), .AllBRoo(1), .AllBRoo(1) * psi)) '"Sba   =  #####.#### MPa     #######.#### psi      All.Des.Stress, bolts  at room"
                Call count() : prob.Printa(GlobalRoutines.FormatS(StriSt(45), .AllBOpe(1), .AllBOpe(1) * psi)) '"Sbo   =  #####.#### MPa     #######.#### psi      All.Des.Stress, bolts  at temp."
                Call count() : prob.Printa(GlobalRoutines.FormatS(StriSt(46), .fSicBul(1))) '"k     =                       #######.#### --       Safety factor for bolts"
            End If
            If A02 < 3 Then
                Call count() : prob.Printa(GlobalRoutines.FormatS(StriSt(47), dt, dt / inc)) '"do    = #########.## mm     #######.#### in       Tube O.D."
            Else
                If .IBW Then
                    Call count() : prob.Printa(StriSt(87))
                    Call count() : prob.Printa(GlobalRoutines.FormatS(StriSt(47), dt, dt / inc))
                    Call count() : prob.Printa(GlobalRoutines.FormatS(StriSt(85), d, d / inc))
                Else
                    Call count() : prob.Printa(StriSt(86))
                    Call count() : prob.Printa(GlobalRoutines.FormatS(StriSt(47), dt, dt / inc))
                End If
            End If
            Call count() : prob.Printa(GlobalRoutines.FormatS(StriSt(69), tt, tt / inc))
            Call count() : prob.Printa(GlobalRoutines.FormatS(StriSt(88), cortubi, cortubi / inc))
            Call count() : prob.Printa(GlobalRoutines.FormatS(StriSt(48), p, p / inc)) '"p     = #########.## mm     #######.#### in       Tube pitch"
            If A02 < 3 Then
                Call count() : prob.Printa(GlobalRoutines.FormatS(StriSt(68), UL, UL / inc))
            Else
                Call count() : prob.Printa(GlobalRoutines.FormatS(StriSt(84), UL, UL / inc / inc))
            End If
            Call count() : prob.Printa(GlobalRoutines.FormatS(StriSt(49), D0, D0 / inc)) '"Dl    = #########.## mm     #######.#### in       Equiv. dia. of tube center limit"
            Call count() : prob.Printa(GlobalRoutines.FormatS(StriSt(50), 2 - .TipPass)) '"Pitch =                       #########    --       1=square  2=triang."
            If A02 < 2 Then Call count() : prob.Printa(GlobalRoutines.FormatS(StriSt(51), Alfa)) '
            If Not .IBW Then
                If ltxperc Then
                    Call count() : prob.Printa(GlobalRoutines.FormatS(StriSt(53), ltx))
                Else
                    Call count() : prob.Printa(GlobalRoutines.FormatS(StriSt(54), ltx, ltx / inc))
                End If
            End If
            Call count() : prob.Printa(StriSt(1))
            If Not Integral Then
                Cod = "Data for bolt load calculation "
                If .mart Then Cod = "Bolt Loads "
                Select Case .bdice
                    Case 0
                        Call count() : prob.Printa(GlobalRoutines.FormatS(StriSt(55), Cod)) '; "       "; Cod$; "channel-side"
                        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Fl. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                        Fl = FlChan(.IndProbl)
                        pringuar("s")
                        Call count() : prob.Printa(StriSt(1))
                        Call count() : prob.Printa(GlobalRoutines.FormatS(StriSt(56), Cod)) '"       "; Cod$; "T.S."
                        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Fl. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                        Fl = FlShel(.IndProbl)
                        pringuar("c")
                        Call count() : prob.Printa(GlobalRoutines.FormatS(StriSt(83), W, W / NIUT))
                    Case 1
                        Call count() : prob.Printa(GlobalRoutines.FormatS(StriSt(55), Cod)) 'channel side
                        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Fl. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                        Fl = FlChan(.IndProbl)
                        pringuar("c")
                    Case 2
                        Call count() : prob.Printa(GlobalRoutines.FormatS(StriSt(56), Cod)) 'bolt tube side
                        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Fl. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                        Fl = FlShel(.IndProbl)
                        pringuar("s")
                End Select
            End If
            For j = 1 To 2 : Call count() : prob.Printa(StriSt(1)) : Next
            Call count() : prob.Printa(GlobalRoutines.FormatS(StriSt(57), Nota(NNOTSW), NNOTE)) '"\   \ : ## - Input of geometric dimensions in  mm . - Displayed values in  in "
            Call count() : prob.Printa(StriSt(58)) '"                   are fixed by conversion factors."
            NNOTE = NNOTE + 1 : NNOTSW = 1
            'If (Problem(IndProbl).SERRA = 0) And Problem(IndProbl).mart < 2 Then
            '   For j = 1 To 2: Call count: Print #iout, StriSt$(1): Next
            '   Call count: Print #iout, FormatS(StriSt$(59), Nota(NNOTSW), NNOTE)  '"\   \ : ## - The rule contained in the note 2 to ASME VIII div.1, App.2-5, will be applied."
            '   NNOTE = NNOTE + 1
            'End If
            'If (Problem(.IndProbl).SPHT = 0) Then
            '   For j = 1 To 2: Call count: Print #iout, StriSt$(1): Next
            '   Call count: Print #iout, FormatS(StriSt$(60), Nota(NNOTSW), NNOTE)  '"\   \ : ## - The tightness of the flanged joint will be assured up to the hydraulic test pressure."
            '   Call count: Print #iout, StriSt$(61) '"                   (This is an additional requirement to the code requirements)"
            '   NNOTE = NNOTE + 1
            'End If
            'If .mart = 0 Then
            '   FOR j = 1 TO 2: CALL count: PRINT #iout,StriSt$(1) : NEXT
            '   CALL count: PRINT #iout, USING StriSt$(62); Nota$(NNOTSW); NNOTE'"\   \ : ## - The operating bolt load will not be allowed to be less than seating bolt load."
            '   CALL count: PRINT #iout, StriSt$(61)'"                   (This is an additional requirement to the code requirements)"
            '   NNOTE = NNOTE + 1
            'End If
            If (Problem(.IndProbl).PDIFF = 0) Then
                For j = 1 To 2 : Call count() : prob.Printa(StriSt(1)) : Next
                Call count() : prob.Printa(GlobalRoutines.FormatS(StriSt(63), Nota(NNOTSW), NNOTE)) '"\   \ : ## - The equipment will be dimensioned under differential pressure only."
                Call count() : prob.Printa(GlobalRoutines.FormatS(StriSt(79), Problem(.IndProbl).DiffPress, Problem(.IndProbl).DiffPress * psi))
                'Call count: Print #iout, StriSt$(64) '"                   (This is an additional requirement to the TEMA rules)"
                NNOTE = NNOTE + 1
            End If
            'If (Problem(IndProbl).FLEX > 0) Then
            '   For j = 1 To 2: Call count: Print #iout, StriSt$(1): Next
            '   Call count: Print #iout, FormatS(StriSt$(64), Nota(NNOTSW), NNOTE)  '"\   \ : ## - When calculating the stresses in the extension, also radial bending will be accounted."
            '   Call count: Print #iout, StriSt$(65) '"                   (This is an additional requirement to the TEMA rules)"
            '   NNOTE = NNOTE + 1
            'End If
            If (Problem(.IndProbl).Vacuum > 0 And Problem(.IndProbl).PDIFF > 0) Then
                For j = 1 To 2 : Call count() : prob.Printa(StriSt(1)) : Next
                Select Case Problem(.IndProbl).Vacuum
                    Case 1
                        Call count() : prob.Printa(GlobalRoutines.FormatS(StriSt(65), Nota(NNOTSW), NNOTE)) '"\   \ : ## - The shell side may operate under vacuum."
                    Case 2
                        Call count() : prob.Printa(GlobalRoutines.FormatS(StriSt(66), Nota(NNOTSW), NNOTE)) '"\   \ : ## - The tube side may operate under vacuum."
                    Case 3
                        Call count() : prob.Printa(GlobalRoutines.FormatS(StriSt(67), Nota(NNOTSW), NNOTE)) '"\   \ : ## - Both tube and shell sides may operate under vacuum."
                End Select
                NNOTE = NNOTE + 1
            End If
            NNOTSW = 0
            For j = 1 To 2 : Call count() : prob.Printa(StriSt(1)) : Next
            'If .mart < 2 Then
            '   nr1 = nr + 1
            '   For j = nr1 To NRIGHE: Call count: Print #iout, StriSt$(1): Next
            '   jFlan = 0
            '   For iFlan = 0 To 1
            '     If .bdice = 1 And iFlan = 1 Or .bdice = 2 And iFlan = 0 Then GoTo Cont2
            '     If jFlan = 0 Then
            '       Cod = Space$(5)
            '       Call testaU(Cod, 11)
            '       Call count: Print #iout, FormatS(StriSt(68), Titol$(1))  '"                            OUTPUT  DATA (check of the bolted joint sizeing)\\"
            '       Call count: Print #iout, StriSt(69)  '"                            ============"
            '       jFlan = 1
            '     End If
            '     Call count: Print #iout, StriSt(1)
            '     If Not FlChan(.IndProbl).DintFla = -1 Then Call count: Print #iout, FormatS(StriSt(70), Flangia$(iFlan%)) '"                      (Data for the flange \  \-side)"
            '     If iFlan = 0 Then Fl = FlChan(.IndProbl): printc iFlan: nr = NRIGHE + 1
            '     If iFlan = 1 Then Fl = FlShel(.IndProbl): printc iFlan
            '     For j = 1 To 2: Call count: Print #iout, StriSt(1): Next
            'Cont2:
            '   Next iFlan
            '   Call count: Print #iout, FormatS(StriSt(71), Nota(NNOTSW), NNOTE)   '"\   \ : ## - Calculation performed using values in Imperial Units. Displayed values in ISU"
            '   Call count: Print #iout, StriSt(72)  '"                   are fixed by conversion factors."
            '   NNOTE = NNOTE + 1: NNOTSW = 1
            'If (Problem(.IndProbl).CRUSH = 0 And FlChan(.IndProbl).SWCRUS = 1) Then
            '   For j = 1 To 2: Call count: Print #iout, StriSt$(1): Next
            '   Call count: Print #iout, FormatS(StriSt$(73), Nota(NNOTSW), NNOTE)  '"\   \ : ## - The gasket channel-side could be overstressed, according to VSR code."
            '   NNOTE = NNOTE + 1
            'End If
            'If (Problem(.IndProbl).CRUSH = 0 And FlShel(.IndProbl).SWCRUS = 1) Then
            '   For j = 1 To 2: Call count: Print #iout, StriSt$(1): Next
            '   Call count: Print #iout, FormatS(StriSt$(74), Nota(NNOTSW), NNOTE)  '"\   \ : ## - The gasket shell-side could be overstressed, according to VSR code."
            '   NNOTE = NNOTE + 1
            'End If
            'If (DatiInt(.IndProbl).SWITCH = 1) Then
            '   For j = 1 To 2: Call count: Print #iout, StriSt$(1): Next
            '   Call count: Print #iout, FormatS(StriSt$(75), Nota(NNOTSW), NNOTE)  '"\   \ : ## - CAUTION: The bolt spacing could be isuffucient!"
            '   NNOTE = NNOTE + 1
            'End If
            'If (FlChan(.IndProbl).SWITCH = 1 And Not FlChan(.IndProbl).DintFla = -1) Then
            '   For j = 1 To 2: Call count: Print #iout, StriSt$(1): Next
            '   Call count: Print #iout, FormatS(StriSt$(76), Nota(NNOTSW), NNOTE)  '"\   \ : ## - CAUTION: The bolt area is insufficient for the flange channel-side!"
            '   NNOTE = NNOTE + 1
            'End If
            'If (FlShel(.IndProbl).SWITCH = 1 And Not FlChan(.IndProbl).DintFla = -1) Then
            '   For j = 1 To 2: Call count: Print #iout, StriSt$(1): Next
            '   Call count: Print #iout, FormatS(StriSt$(77), Nota(NNOTSW), NNOTE)  '"\   \ : ## - CAUTION: The bolt area is insufficient for the flange shell-side!"
            '   NNOTE = NNOTE + 1
            'End If
            'End If
            '   For j = 1 To 2: Call count: Print #iout, StriSt$(1): Next
            '   Call count: Print #iout, FormatS(StriSt$(78), Nota(NNOTSW), NNOTE, Titol(DatiInt(IndProbl).IMAX))   '"\   \ : ## - The dimensioning load case is: \                                 \"
            '   NNOTE = NNOTE + 1
            '   NNOTSW = 0
        End With
        For j = 1 To 2 : Call count() : prob.Printa(StriSt(1)) : Next
        If nr = 0 Then Exit Sub
        NewPage()
        'nr1 = nr ' + 1
        'For j = nr1 To NRIGHE: Call count: Print #iout, StriSt$(1): Next
    End Sub
    Private Sub pringuar(ByRef Lato As String)
        Dim StriSt(13) As String
        Dim ifl As Short
        Dim i As Short
        Dim File As String
        ifl = FreeFile()
        If A02 > 1 Then
            File = RTrim(Monitor.Motore.Inizio.Archdir) & "\RTF\STAM04UHX.EXT"
        Else
            File = RTrim(Monitor.Motore.Inizio.Archdir) & "\RTF\STAM04.EXT"
        End If
        If Not OpenFile(File, ifl) Then Exit Sub
        For i = 1 To 13
            StriSt(i) = LineInput(ifl)
        Next
        FileClose(ifl)
        Dim prob As RoutBase1.clsProblem = Monitor.Motore.Problem
        With Padre
            If .mart Then
                Call count() : prob.Printa(GlobalRoutines.FormatS(StriSt(2), Fl.LargGua, Fl.LargGua / inc)) '"N     = #########.## [mm]     #######.#### [in]       Gasket width"
                Call count() : prob.Printa(GlobalRoutines.FormatS(StriSt(3), Fl.mguar)) '"m     =                       #########.## [--]       Gasket factor"
                Call count() : prob.Printa(GlobalRoutines.FormatS(StriSt(4), Fl.y)) '"y     =                       #######.#### [psi]      Gasket min.design seating load"
                Call count() : prob.Printa(GlobalRoutines.FormatS(StriSt(5), Fl.wn, Fl.wn / inc)) '"w     = #########.## [mm]     #######.#### [in]       Nubbin width"
                Call count() : prob.Printa(GlobalRoutines.FormatS(StriSt(6), Fl.PHI)) '"Phi   =                       #########    [--]       Type of the gasketed joint"
                If Fl.ytrav > 0 Then
                    Call count() : prob.Printa(GlobalRoutines.FormatS(StriSt(7), Fl.btrav, Fl.btrav / inc)) '"Ntrav = #########.## [mm]     #######.#### [in]       Pass Part.Gasket width"
                    Call count() : prob.Printa(GlobalRoutines.FormatS(StriSt(8), Fl.ltrav, Fl.ltrav / inc)) '"Ltrav = #########.## [mm]     #######.#### [in]       Pass Part.Gasket length"
                    Call count() : prob.Printa(GlobalRoutines.FormatS(StriSt(9), Fl.ytrav)) '"ytrav                         #######.#### [psi]      Pass Part.Gsk Seat.Load"
                    Call count() : prob.Printa(GlobalRoutines.FormatS(StriSt(10), Fl.wmt)) '"Wmt                           #######.#### [lb]       Pass Part.Gsk Seat.Load"
                End If
            Else
                Call count() : prob.Printa(GlobalRoutines.FormatS(StriSt(11), Fl.wm1 * NIUT, Fl.wm1)) '"Wm1   = #########.##  [N]     #######.#### [lb]       Operating bolt load"
                If A02 > 1 Then
                    Call count() : prob.Printa(GlobalRoutines.FormatS(StriSt(12), Lato, Fl.wot * NIUT, Fl.wot)) '"Wm2   = #########.##  [N]     #######.#### [lb]       Seating bolt load"
                Else
                    Call count() : prob.Printa(GlobalRoutines.FormatS(StriSt(12), Fl.wm2 * NIUT, Fl.wm2)) '"Wm2   = #########.##  [N]     #######.#### [lb]       Seating bolt load"
                End If
            End If
        End With
    End Sub
    Private Sub InitString()
        Nota(0) = "NOTES" : Nota(1) = "    "
        NNOTSW = 0
        NRIGHE = 65
    End Sub
    Public Sub printAA13(ByRef i As Short)
        With Monitor.Motore.Problem
            If i = 1 Then
                If Not iGia Then iGia = True Else .Printa("\page ") : nr = 0
            End If
            ifl = FreeFile()
            Select Case A02
                Case 0 : File = "\RTF\STAMAA13.TXT"
                Case 1 : File = "\RTF\STAMAA1302.TXT"
                Case 2 : File = "\RTF\STAMUHX115.TXT"
                Case Else
                    If Padre.IBW Then
                        File = "\RTF\STAMUHX1151b.TXT"
                    Else
                        File = "\RTF\STAMUHX1151a.TXT"
                    End If
            End Select
            If Not OpenFile(RTrim(Monitor.Motore.Inizio.Archdir) & File, ifl) Then Exit Sub
            If A02 = 1 Then
                Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, Hsh, Hsh / inc))
                Call Assumi(ifl, TIMA)
                If H >= Hsh Then .Printa(GlobalRoutines.FormatS(TIMA, H, Hsh))
                Call Assumi(ifl, TIMA)
                If H < Hsh Then .Printa(GlobalRoutines.FormatS(TIMA, H, Hsh))
            End If
            Select Case i
                Case 1
                    Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, E, E * psi / 1000))
                    Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, MatTubes))
                    Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, Et, Et * psi / 1000))
                    Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, St, St * psi))
                    Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, migrec))
                    Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, R0))
                    If Not Padre.IBW Then
                        Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, rhoi))
                        Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, dstari, dstari / inc))
                    End If
                    Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, pstari))
                    Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, mistari))
                    Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, (H - cs - CT), (H - cs - CT) / inc))
                    Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, hsup))
                    Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, nistar))
                    Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, EstarE))
                    Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, EstarE * E, EstarE * E * psi / 1000))
                    Call Assumi(ifl, TIMA) : FileClose(ifl)
                Case 2
                    Call Assumi(ifl, TIMA, True)
                    Call Assumi(ifl, TIMA, True)
                    Call Assumi(ifl, TIMA, True)
                    Call Assumi(ifl, TIMA, True)
                    Call Assumi(ifl, TIMA, True)
                    Call Assumi(ifl, TIMA, True)
                    If Not Padre.IBW Then
                        Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, rho))
                        Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, dstar, dstar / inc))
                    End If
                    Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, pstar))
                    Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, mistar))
                    Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, hb / p))
                    Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, nistar))
                    Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, EstarE))
                    Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, EstarE * E, EstarE * E * psi / 1000))
                    Call Assumi(ifl, TIMA) : FileClose(ifl)
            End Select
        End With
    End Sub
    Private Sub printAA162()
        Dim ifl As Short
        Dim TIMA As String = ""
        ifl = FreeFile()
        If Not OpenFile(RTrim(Monitor.Motore.Inizio.Archdir) & "\RTF\STAMAA162.TXT", ifl) Then Exit Sub
        With Monitor.Motore.Problem
            Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, di, di / inc))
            Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, EI, EI * psi / 1000))
            Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, Si, Si * psi))
            Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, tI, tI / inc))
            Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, Pressg, Pressg * psi))
            Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, PressI, PressI * psi))
            Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, W / 1000, W / NIUT))
            Call Assumi(ifl, TIMA) : FileClose(ifl)
        End With
    End Sub
    Private Sub printAA163a()
        Dim ifl As Short
        Dim TIMA As String = ""
        With Monitor.Motore.Problem
            If Not iGia Then iGia = True Else .Printa("\page ") : nr = 0
            ifl = FreeFile()
            If Not OpenFile(RTrim(Monitor.Motore.Inizio.Archdir) & "\RTF\STAMAA163.TXT", ifl) Then Exit Sub
            Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, k))
            Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, 2.0#))
            Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, EstarE2))
            Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, nistar2))
            Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, FO))
            Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, MG))
            Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, MI))
            Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, M1i))
            Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, M2i))
            Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, M3i))
            Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, M4i))
            Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, M0i))
            Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, hbi, hbi / inc))
            Call Assumi(ifl, TIMA) : FileClose(ifl)
        End With
    End Sub
    Private Sub printAA163b()
        Dim Nome As String
        'dallo step 6
        If hsup = 2 And rho = rhoi Then
            Nome = RTrim(Monitor.Motore.Inizio.Archdir) & "\RTF\Step6A.TXT"
            Stamp1(Nome)
        ElseIf hsup < 2 And rho = rhoi Then
            Nome = RTrim(Monitor.Motore.Inizio.Archdir) & "\RTF\Step6B.TXT"
            Stamp1(Nome)
        Else
            Nome = RTrim(Monitor.Motore.Inizio.Archdir) & "\RTF\Step6C.TXT"
            Stamp1(Nome)
            Call printAA13(2)
        End If
        Exit Sub
    End Sub
    Private Sub Stamp1(ByVal NOme As String)
        Dim ifl As Short
        Dim TIMA As String = ""
        ifl = FreeFile()
        If Not OpenFile(NOme, ifl) Then Exit Sub
        With Monitor.Motore.Problem
            Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, rho))
            Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, hsup))
            Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, EstarE))
            Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, nistar))
            Call Assumi(ifl, TIMA) : FileClose(ifl)
        End With
    End Sub
    Private Sub printStep7()
        Dim ifl As Short
        Dim TIMA As String = ""
        ifl = FreeFile()
        If Not OpenFile(RTrim(Monitor.Motore.Inizio.Archdir) & "\RTF\Step7.TXT", ifl) Then Exit Sub
        With Monitor.Motore.Problem
            Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, tI))
            Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, 1.77 * System.Math.Sqrt(di * tI)))
            Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, tI / hb))
            Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, di / 2 / tI))
            Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, lambdav))
            Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, f))
            Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, m1))
            Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, m2))
            Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, m3))
            Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, M4))
            Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, m0))
            Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, sigmab, sigmab * psi))
            Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, 1.5 * s, 1.5 * s * psi))
            Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, hb))
            Call Assumi(ifl, TIMA) : FileClose(ifl)
        End With
    End Sub
    Private Sub NewPage()
        Dim nr1, j As Short
        nr1 = nr + 1
        For j = nr1 To NRIGHE : Call count() : Monitor.Motore.Problem.Printa("\par ") : Next ' StriSt$(1): Next
    End Sub
    Private Sub printStep10()
        Dim ifl As Short
        Dim TIMA As String = ""
        ifl = FreeFile()
        If Not OpenFile(RTrim(Monitor.Motore.Inizio.Archdir) & "\RTF\Step10.TXT", ifl) Then Exit Sub
        With Monitor.Motore.Problem
            Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, phig))
            Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, sigma2, sigma2 * psi))
            Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, sigma1G, sigma1G * psi))
            Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, sigma1, sigma1 * psi))
            Call Assumi(ifl, TIMA) : FileClose(ifl)
            If simplif Then
                ifl = FreeFile()
                If Not OpenFile(RTrim(Monitor.Motore.Inizio.Archdir) & "\RTF\Step12.TXT", ifl) Then Exit Sub
                Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, EIvecchio, EIvecchio * psi / 1000.0#, Si, Si * psi))
                Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, EI, EI * psi / 1000.0#))
            Else
                ifl = FreeFile()
                If Not OpenFile(RTrim(Monitor.Motore.Inizio.Archdir) & "\RTF\Step12no.TXT", ifl) Then Exit Sub
                Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, Si, Si * psi))
            End If
            Call Assumi(ifl, TIMA) : FileClose(ifl)
            ifl = FreeFile()
            If Not OpenFile(RTrim(Monitor.Motore.Inizio.Archdir) & "\RTF\Step13.TXT", ifl) Then Exit Sub
            Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, H1, H1 / inc))
            Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, H2, H2 / inc))
            Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, hr, hr / inc))
        End With
        Call Assumi(ifl, TIMA) : FileClose(ifl)
    End Sub
    Private Sub StampAA15()
        Dim ifl As Short
        Dim TIMA As String = ""
        Dim Cod, Tit As String
        If A02 < 2 Then
            Tit = "P.T. App.AA-1.5"
        Else
            Tit = "P.T. UHX-13"
        End If
        If Not PrepRapp(Template, Tit, Involucr(kLato, jInvolucr).Mark.Trim & " (" & Tit.Substring(5) & ")", FileSt, mioApert.lstRapp) Then Exit Sub
        Cod = Space(5)
        Call testaU(Cod, 10, 3)
        Call printa()
        Call printAA13(1)
        ifl = FreeFile()
        If Not OpenFile(RTrim(Monitor.Motore.Inizio.Archdir) & "\RTF\STAMAA152.TXT", ifl) Then Exit Sub
        With Monitor.Motore.Problem
            Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, ts))
            Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, 1.77 * System.Math.Sqrt(Ds * ts)))
            Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, tc, 1.77 * System.Math.Sqrt(DC * tc)))
            Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, Dm, Dm / inc))
            Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, Tm, Tm / inc))
            Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, FIAA152))
            Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, hbs, hbs / inc))
            Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, hbt, hbt / inc))
            Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, hb, hb / inc))
            Call Assumi(ifl, TIMA) : FileClose(ifl)
            ifl = FreeFile()
            If Not OpenFile(RTrim(Monitor.Motore.Inizio.Archdir) & "\RTF\Step13b.TXT", ifl) Then Exit Sub
            Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, H1, H1 / inc))
            Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, H2, H2 / inc))
            Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, hr, hr / inc))
        End With
        Call Assumi(ifl, TIMA) : FileClose(ifl)
    End Sub
    Private Sub StampAA14()
        Dim ifl As Short
        Dim TIMA As String = ""
        Dim Cod, Tit As String
        If A02 < 2 Then
            Tit = "P.T. App.AA-1.4"
        Else
            Tit = "P.T. UHX-1?"
        End If
        If Not PrepRapp(Template, Tit, Involucr(kLato, jInvolucr).Mark.Trim & " (" & Tit.Substring(5) & ")", FileSt, mioApert.lstRapp) Then Exit Sub
        Cod = Space(5)
        Call testaU(Cod, 7, 3)
        Call printa()
        Call printAA13(1)
        ifl = FreeFile()
        If Not OpenFile(RTrim(Monitor.Motore.Inizio.Archdir) & "\RTF\STAMAA142.TXT", ifl) Then Exit Sub
        With Monitor.Motore.Problem
            Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, hb, hb / inc))
            Call Assumi(ifl, TIMA) : FileClose(ifl)
            ifl = FreeFile()
            If Not OpenFile(RTrim(Monitor.Motore.Inizio.Archdir) & "\RTF\Step13a.TXT", ifl) Then Exit Sub
            Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, H1, H1 / inc))
            Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, H2, H2 / inc))
            Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, hr, hr / inc))
        End With
        Call Assumi(ifl, TIMA) : FileClose(ifl)
    End Sub
    Public Sub Stampa(ByRef Tipo As Short, ByRef codice As Short)
        NNOTE = 1
        NNOTSW = 0
        NPAGE = 0
        nr = 0
        If Monitor.Motore.Problem.FileStream Is Nothing Then iGia = False
        If A02 = 0 Then
            Select Case ptTipoAA
                Case 1 : StampAA14()
                Case 2 : StampAA15()
                Case 3, 4 : StampAA16()
            End Select
        Else
            StampAA1(Tipo, codice)
        End If
    End Sub
    Private Function MAWP(ByRef Tipo As Short) As Boolean
        Dim i As Short
        Dim codice As Short
        CalcMAWP = True
        ic = 0
        MAWP = False
        codice = 4
        If Not Cerca(codice, Tipo) Then Exit Function
        If Not ContinuoAuto Then
            Monitor.Motore.Avanzamento = 25
            System.Windows.Forms.Application.DoEvents()
            If InterrompiMAWP Then Exit Function
        End If
        i = 1
        Registra(i)
        codice = 2
        If Not Cerca(codice, Tipo) Then Exit Function
        If Not ContinuoAuto Then
            Monitor.Motore.Avanzamento = 50
            System.Windows.Forms.Application.DoEvents()
            If InterrompiMAWP Then Exit Function
        End If
        i = 2
        Registra(i)
        codice = 3
        If Not Cerca(codice, Tipo) Then Exit Function
        If Not ContinuoAuto Then
            Monitor.Motore.Avanzamento = 75
            System.Windows.Forms.Application.DoEvents()
            If InterrompiMAWP Then Exit Function
        End If
        i = 3
        Registra(i)
        codice = 1
        If Not Cerca(codice, Tipo) Then Exit Function
        If Not ContinuoAuto Then
            Monitor.Motore.Avanzamento = 99
            System.Windows.Forms.Application.DoEvents()
            If InterrompiMAWP Then Exit Function
        End If
        i = 4
        Registra(i)
        MAWP = True
        CalcMAWP = False
    End Function
    Private Sub Registra(ByVal i As Integer)
        If (Problem(Padre.IndProbl).PDIFF = 0) Then
            MAWPChan(i) = Presstd
            MAWPShel(i) = Presssd
            Presstd = Presstd1
            Presssd = Presssd1
        Else
            MAWPChan(i) = Presstd1
            MAWPShel(i) = Presssd1
        End If
    End Sub
    Private Function Cerca(ByVal codice As Integer, ByVal Tipo As Short) As Boolean
        Dim Res As Boolean
        Res = Abbassa(codice)
        ic = 0
        If (Problem(Padre.IndProbl).PDIFF = 0) Then
            Presstd1 = Presstd
            Presssd1 = Presssd
            Do
                Res = Calc(Tipo, codice, 0)
                PressEff = PressEff * ((hb - cs - CT) / hr) ^ 0.4
                If Presssd - PressEff > 0 Then '030506
                    Presstd = Presssd - PressEff
                Else
                    Presssd = Presstd + PressEff
                End If
                ic = ic + 1
            Loop While System.Math.Abs(hb - cs - CT - hr) / (hb - cs - CT) > clsTrigon.TOLER And Res And ic < MaxIter
            If Not Res Then Return False
        Else
            Presstd1 = Presstd
            Presssd1 = Presssd
            Do
                Res = Calc(Tipo, codice, 1)
                Presstd = Presstd * ((hb - cs - CT) / hr) ^ 0.4 '280206
                ic = ic + 1
            Loop While System.Math.Abs(hb - cs - CT - hr) / (hb - cs - CT) > clsTrigon.TOLER And Res And ic < MaxIter '280206
            If Not Res Then Return False
            GlobalRoutines.SWAP(Presstd, Presstd1)
            ic = 0 '280206
            Do
                Res = Calc(Tipo, codice, 2)
                Presssd = Presssd * ((hb - cs - CT) / hr) ^ 0.4 '280206
                ic = ic + 1
            Loop While System.Math.Abs(hb - cs - CT - hr) / (hb - cs - CT) > clsTrigon.TOLER And Res And ic < MaxIter '280206
            If Not Res Then Return False
            GlobalRoutines.SWAP(Presssd, Presssd1)
        End If
        Return True
    End Function
    Public Function Abbassai() As Boolean
        Dim i As Short
        For i = 1 To Config(3).Ninvolucri
            If Involucr(3, i).Tipo = 7 Then
                jtubo = i
                Exit For
            End If
        Next

        If jtubo = 0 Then
            MessageBox.Show("I tubi?")
            Abbassai = False
            Exit Function
        End If
        Abbassai = True
        With Padre
            ltx = .ltx
            ltxperc = .ltxperc
            ptTipoAA = .TipoAA
            p = .TubPass
            dt = .TubDiam
            tt = .TubSpess
            If tt = 0 Then tt = Involucr(kLato, jtubo).Spess
            cortubi = Involucr(kLato, jtubo).cs
            If .TipoPT = 2 Then CType(.Piastra, wn_FTC).Zp(1, 761) = cortubi
            D0 = .OTL
            If D0 = 0 Then D0 = .EquDiam
            If p * dt * tt * D0 <= 0 Then
                MostraAiuto(IDH_PT_DATITUBI)
                Abbassai = False
                Exit Function
            End If
            MatTubes = Matdim(Involucr(kLato, jtubo).indice(1 - 1)).MatStr
            UL = .UL
            If A02 < 3 Then
                If .TipoPT = 2 Then CType(.Piastra, wn_FTC).Zp(1, 754) = .UL
            Else
                If .TipoPT = 2 Then CType(.Piastra, wn_FTC).Zp(1, 754) = .UL
            End If
            Select Case .TipPass
                Case 1 : Alfa = 0.32 'quadr
                Case 0 : Alfa = 0.39 'triang
                Case Else : Stop
            End Select
            g = .FlChanDati(19)
            HG = .CavChan + .CavShel
            H = .TSheThk
        End With
    End Function
    Private Function Calc(ByRef Tipo As Short, ByRef codice As Short, ByVal ic As Integer) As Boolean
        Dim Res As Boolean
        Dim Testo As String
        If A02 < 2 Then
            Titolo = "AsmeVip - App.AA"
        Else
            Titolo = "AsmeVip - UHX"
        End If
        If A02 = 0 Then
            Select Case ptTipoAA
                Case 0
                    Testo = "Calcolo non previsto. Potreste voler cambiare l'addenda ASME VIII applicabile a A02 o successive."
                    MessageBox.Show(Testo, Titolo, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Function
                Case 1 : Res = AA14()
                Case 2 : Res = AA15(Tipo)
                Case 3 : Tipo = 1
                    Res = AA16(Tipo, codice)
                Case 4 : Tipo = 2
                    Res = AA16(Tipo, codice)
                Case 5, 6, 7, 8
                    Res = Padre.CalcTEMA
                    Res = VERIFICA()
            End Select
        Else
            Select Case ptTipoAA
                Case 0, 1 'biflangiata
                    Tipo = 0
                    If Not CalcMAWP Then
                        Fl = FlShel(1)
                        Bulloni = Problem(1).Tiranti(2)
                        If Not Padre.geomguar(0) Then Calc = False : Exit Function
                        FlShel(1) = Fl
                        Fl = FlChan(1)
                        Bulloni = Problem(1).Tiranti(1)
                        If Not Padre.geomguar(0) Then Calc = False : Exit Function
                        FlChan(1) = Fl
                    End If
                    Res = AA15A02(Tipo, codice, ic)
                Case 2 'integrale
                    Tipo = -1
                    Res = AA15A02(Tipo, codice, ic)
                Case 3, 30 'flangiata lato mantello UTEMA
                    Tipo = 1
                    If Not CalcMAWP Then
                        Fl = FlShel(1)
                        Bulloni = Problem(1).Tiranti(2)
                        If Not Padre.geomguar(0) Then Calc = False : Exit Function
                        FlShel(1) = Fl
                    End If
                    Res = AA15A02(Tipo, codice, ic)
                Case 4, 40 'flangiata lato cassa UTEMA
                    Tipo = 2
                    If Not CalcMAWP Then
                        Fl = FlChan(1)
                        Bulloni = Problem(1).Tiranti(1)
                        If Not Padre.geomguar(0) Then Calc = False : Exit Function
                        FlChan(1) = Fl
                    End If
                    Res = AA15A02(Tipo, codice, ic)
                Case 5, 6, 7, 8
                    Res = Padre.CalcTEMA
                    Res = VERIFICA()
            End Select
        End If
        Calc = Res
    End Function
    Public Function ScelSpes() As Boolean
        Dim Testo As String
        Dim Stringa(3) As String
        Dim junk As Short
        Dim Doman(2) As String
        Dim Rispo(2) As String
        Dim Arch(2) As Short
        Dim dAiu(2) As String
        Dim tTEMA As Single
        ScelSpes = True
        If hr = 0 And ptTipoAA > 4 Then
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Padre.Piastra.iCond. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            AA24(Padre.Piastra.iCond, 0, True)
        End If
Rif:
        If hr > 0 Then
            Testo = "Spessore minimo lordo: " & GlobalRoutines.FormatS("####.### " & UnitLength, (hr + cs + CT) * kLength)
        Else
            Testo = "Spessore minimo lordo: N.C."
        End If
        If Padre.Rules = 2 Then
            If ptTipoAA < 5 And Not ptTipoAA = 2 And Not ptTipoAA = 1 Then
                tTEMA = CType(Padre.Piastra, wn_UTEMA).tfmax
            Else
                tTEMA = CType(Padre.Piastra, wn_FTC).Zp(1, 159)
            End If
            If tTEMA > 0 Then
                Testo = Testo & "|Spessore minimo TEMA:" & GlobalRoutines.FormatS("####.### " & UnitLength, tTEMA * kLength)
            Else
                Testo = Testo & "|Spessore minimo TEMA: N.C."
            End If
        End If
        If hb < hr + cs + CT Then hb = (Int((hr + cs + CT) * 1000) + 1) / 1000
        If Padre.TSheThk > hb And A02 >= 3 Then hb = Padre.TSheThk
        If Not ContinuoAuto Then
            Doman(1) = "Spessore adottato [mm]"
            Rispo(1) = GlobalRoutines.myStr(hb * kLength, 4, 3, False)
            Testo = Monitor.Motore.Inizio.ConvertiCr(Testo)
            If Not Monitor.Motore.InputDati(1, "UHX - Spessore adottato", Doman, Rispo, "", Arch, dAiu, Testo) Then ScelSpes = False : Exit Function
            hb = GlobalRoutines.ValVir(Rispo(1)) / kLength
        End If
        H = hb
        If H - (hr + cs + CT) < -clsTrigon.TOLER * H Then
            Testo = "Spessore insufficiente!.|"
            Testo = Testo & "       Cosa vuoi fare ? "
            Stringa(1) = "Modificare i dati di input"
            Stringa(2) = "Selezionare nuovo spessore"
            Stringa(3) = "Confermare i dati attuali"
            junk = Monitor.Motore.Quale(3, "Spessori piastra", Stringa, "", 1, Testo)
            Select Case junk
                Case 1 : ScelSpes = False : Exit Function
                Case 2 : GoTo Rif
                Case Else
            End Select
        End If
        Padre.TSheThk = H
    End Function
    Public Function AA24(ByRef iCond As Short, ByRef Offset As Short, ByRef Itera As Boolean) As Boolean
        Dim it, iload, ish, ig As Short
        Dim iw As Short
        Dim fact, factmax As Single
        Dim hbvec As Single
        Dim Corroso, ic As Short
        Dim Testo As String
        Dim jj, iii As Short
        Dim Sfo, Sfa As Single
        Dim StPos1, StcPos1 As Single
        Dim StPos2, StcPos2 As Single
        Dim quale As String
        Static XaV, Q3V As Single
        Static OffSetV As Short
        If IO.File.Exists(fileErr.Str_Renamed) Then Kill(fileErr.Str_Renamed)
        If Not Abbassai() Then Exit Function
        NumTub = CType(Padre.Piastra, wn_FTC).Zp(1, 29)
        If NumTub = 0 Then
            WarnT(-29)
            Exit Function
        End If
        AA24 = True
        If ptTipoAA > 99 And A02 = 0 Then A02 = 4
        Try
            Environment.CurrentDirectory = Monitor.Motore.Inizio.Basedir & "\Dll"
            For Corroso = 0 To 1
                If Not Abbassa(2 - Corroso) Then AA24 = False : Exit Function
                ic = 0
                With CType(Padre.Piastra, wn_FTC)
                    Lunght = .Zp(1, 30)
                    If Lunght = 0 Then
                        WarnT(-30)
                        Return False
                    End If
                    ES = .Zp(iCond, 8)
                    If Padre.IndAccopp(4) > 0 Then  'mantello saldato alla PT
                        Ind = Involucr(1, Padre.IndAccopp(4)).indice(1 - 1)
                        Esv1 = Matdim(Ind).EmodAlt(.Zp(iCond, 5))
                    End If
                    Et = .Zp(iCond, 9)
                    e = .Zp(iCond, 7)  '+ OffSet ?
                    St = .Zp(iCond, 13)
                    s = .Zp(iCond, 35)
                    If NonTermici() Then
                        SPS = 0
                    Else
                        Indmat = Involucr(kLato, jInvolucr).indice(1 + 2 * (Offset \ 8) - 1)
                        .Zp(iCond + Offset, 591) = Matdim(Indmat).SPS(CodiceStress, .Zp(iCond + Offset, 4))
                        SPS = .Zp(iCond + Offset, 591) '* mpa
                        If SPS = 0 Then AA24 = False : Exit Function
                    End If
                    Tempt = .Zp(iCond, 764)
                    Temps = .Zp(iCond, 777)
                    Tempc = .Zp(iCond + Offset, 322)
                    '--------------------materiale shell--------
                    If Not ElasPlas Then
                        Indmat = Involucr(kLato, jInvolucr).indice(4 - 1)
                        If Indmat > 0 Then
                            Matdim(Indmat).Zitto = ContinuoAuto
                            Matdim(Indmat).YieldTemp(CodiceStress, Temps, Sfa, Sfo)
                            Sys = Sfo
                        Else
                            Sys = 0
                        End If
                        .Zp(iCond, 498) = Sys
                        SS = .Zp(iCond + Offset, 12)  'SI
                        SSS = Sys 'SI
                        .Zp(iCond + Offset, 496) = SS * 1.5
                        If A02 = 0 Then
                            .Zp(iCond + Offset, 497) = SS * 3
                            If 1.5 * SS < SSS Then SSS = 1.5 * SS
                        Else
                            Indmat = Involucr(kLato, jInvolucr).indice(4 - 1)
                            If Indmat > 0 Then
                                .Zp(iCond + Offset, 497) = Matdim(Indmat).SPS(CodiceStress, Temps)
                            Else
                                .Zp(iCond + Offset, 497) = 0
                            End If
                            If .Zp(iCond + Offset, 497) / 2 < SSS Then SSS = .Zp(iCond + Offset, 497) / 2
                        End If
                        .Zp(iCond, 499) = SSS
                    End If
                    '-------------------------------------------
                    If ptTipoAA = 5 Then
                        jj = Involucr(kLato, jInvolucr).IndAccopp(3)  'channel saldato alla PT
                        Indmat = 0
                        If jj > 0 Then
                            Indmat = Involucr(2, jj).indice(1 - 1)
                        Else
                            Indmat = Involucr(kLato, jInvolucr).indice(5 - 1)
                        End If
                        If Indmat = 0 Then
                            MessageBox.Show("Non è stato definito il materiale della cassa accoppiata alla piastra tubiera di testa (fascio tubiero a teste fisse)")
                            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
                            AA24 = False
                            Exit Function
                        End If
                        If Not ValoriChannel(iCond, Offset, Itera) Then Return False
                    ElseIf (ptTipoAA = 101 Or ptTipoAA = 105 Or ptTipoAA = 106) And .GetPiastra = 1 Then
                        jj = Involucr(kLato, jInvolucr).IndAccopp(3)
                        Indmat = 0
                        If jj > 0 Then
                            Indmat = Involucr(2, jj).indice(1 - 1)
                        Else
                            Indmat = Involucr(kLato, jInvolucr).indice(5 - 1)
                        End If
                        If Indmat <= 0 Then
                            MessageBox.Show("Non è stato definito il materiale della cassa accoppiata alla piastra tubiera di testa (fascio tubiero a piastra flottante)")
                            AA24 = False
                            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
                            Exit Function
                        End If
                        If Not ValoriChannel(iCond, Offset, Itera) Then Return False
                    ElseIf (.Flottante = 1 Or .Flottante = 4) And .GetPiastra = 2 Then
                        jj = .IndiceFondo
                        Indmat = 0
                        If jj > 0 Then
                            Select Case .Flottante
                                Case 1 : iii = 2
                                Case Else : iii = 3
                            End Select
                            Indmat = Involucr(iii, jj).indice(1 - 1)
                        Else
                            Indmat = Involucr(kLato, jInvolucr).indice(5)
                        End If
                        If Indmat <= 0 Then
                            Testo = "Non è stato definito il materiale della cassa accoppiata alla piastra tubiera flottante" & vbCrLf
                            If jj = 0 Then
                                Testo = Testo & "E' necessario creare il componente cassa, definirne il materiale, e accoppiarlo" & vbCrLf
                                Testo = Testo & "alla piastra tubiera"
                            End If
                            MessageBox.Show(Testo)
                            AA24 = False
                            Exit Function
                        End If
                        If Not ValoriChannel(iCond, Offset, Itera) Then Return False
                    Else
                        Ec = 0
                        Syc = 0
                    End If
                    '.Zp(iCond + Offset, 326) = Syc
                    .Zp(iCond + Offset, 323) = Ec
                    '.Zp(iCond + Offset, 500) = Scs
                    '.Zp(iCond + Offset, 533) = Scs '?????
                    '-----------------------------------------------------------
                    AA13(iCond)
                    A0 = D0 / 2
                    .Zp(iCond, 376 + Corroso) = A0
                    If Not AA23(iCond, Offset, Corroso) Then AA24 = False : Exit Function
                    rhos = aas / A0
                    rhoc = ac / A0
                    If rhos = 0 Or rhoc = 0 Then
                        If Padre.Piastra.GetPiastra = 1 Then quale = "di testa" Else quale = "di coda"
                        MessageBox.Show("as e/o ac (radial shell/channel dimensions) non definiti per la piastra " & quale)
                        AA24 = False : Exit Function
                    End If
                    .Zp(iCond + Offset, 385 + Corroso) = rhos
                    .Zp(iCond + Offset, 387 + Corroso) = rhoc
                    xt = 1 - NumTub * ((dt - 2 * (tt - cortubi * Corroso)) / 2 / A0) ^ 2
                    xs = 1 - NumTub * (dt / 2 / A0) ^ 2
                    .Zp(iCond + Offset, 389 + Corroso * (792 - 389)) = xt
                    .Zp(iCond + Offset, 390 + Corroso * (799 - 390)) = xs
                    '----------------------------
                    rhoi = rho
                    dstari = dstar
                    pstari = pstar
                    mistari = mistar
                    '----Step 2--------------------------
                    Lungh = Lunght - 2 * H
                    If ptTipoAA < 99 Then
                        If (ptTipoAA = 2 Or ptTipoAA = 4 Or ptTipoAA = 40) And .IndiceFondo <> 0 Then
                        Else
                            If Not ThkAdjacent Then
                                Ks = pi * ts * (Ds + ts) * ES / Lungh
                            Else
                                If .Differing < 2 Then
                                    Lungh1 = Padre.SlShelDati(3)
                                    Lungh1p = Lungh1
                                Else
                                    If Padre.GetPiastra = 1 Then
                                        Lungh1 = Padre.SlShelDati(3)
                                        Padre.SetPiastra(2, False)
                                        Lungh1p = Padre.SlShelDati(3)
                                        Padre.SetPiastra(1, False)
                                    End If
                                End If
                                If (Esv1 * tsv1) = 0 Then
                                    Testo = "Adiacente nullo in AA24"
                                    MessageBox.Show(Testo)
                                    AA24 = False
                                    Exit Function
                                End If
                                Ks = pi * (Ds + ts) / ((Lungh - Lungh1 - Lungh1p) / ES / ts + (Lungh1 + Lungh1p) / Esv1 / tsv1)
                            End If
                        End If
                        kt = pi * (tt - cortubi * Corroso) * (dt - (tt - cortubi * Corroso)) * Et / Lungh
                        .Zp(iCond, 391 + Corroso) = Ks
                        .Zp(iCond, 393 + Corroso) = kt
                        Ksvt = Ks / NumTub / kt
                        .Zp(iCond, 47 + Corroso) = Ksvt
                    End If
                    If .GetPiastra = 1 Then
                        If ptTipoAA = 8 Or ptTipoAA >= 104 Then
                            betas = 0 : kss = 0 : lambdas = 0
                            deltas = 0
                        Else
                            If Not ThkAdjacent Then
                                If ts <= 0 Then
                                    WarnT(-23)
                                    Return False
                                End If
                                betas = (12 * (1 - nis ^ 2)) ^ 0.25 / System.Math.Sqrt((Ds + ts) * ts)
                                deltas = Ds ^ 2 / 4 / ES / ts * (1 - nis / 2)
                            Else
                                betas = (12 * (1 - nis ^ 2)) ^ 0.25 / System.Math.Sqrt((Ds + tsv1) * tsv1)
                                deltas = Ds ^ 2 / 4 / Esv1 / tsv1 * (1 - nis / 2)
                            End If
                        End If
                        If ptTipoAA = 5 Or ptTipoAA = 101 Or ptTipoAA = 105 Or ptTipoAA = 106 Then
                            If tc <= 0 Then
                                WarnT(-24)
                                Return False
                            End If
                            betac = (12 * (1 - nic ^ 2)) ^ 0.25 / System.Math.Sqrt((DC + tc) * tc)
                            deltac = DC ^ 2 / 4 / Ec / tc * (1 - nic / 2)
                        Else
                            betac = 0 : ktt = 0 : lambdac = 0
                            deltac = 0
                        End If
                    Else
                        If ptTipoAA = 8 Or ptTipoAA > 99 Then
                            betas = 0
                        Else
                            betas = (12 * (1 - nis ^ 2)) ^ 0.25 / System.Math.Sqrt((Ds + ts) * ts)
                        End If
                        If ptTipoAA = 5 Or ptTipoAA > 99 And (.Flottante = 1 Or .Flottante = 4) Then
                            betac = (12 * (1 - nic ^ 2)) ^ 0.25 / System.Math.Sqrt((DC + tc) * tc)
                            deltac = DC ^ 2 / 4 / Ec / tc * (1 - nic / 2)
                        Else
                            betac = 0
                            deltac = 0
                        End If
                    End If
                    If Not ThkAdjacent Then
                        kss = betas * ES * ts ^ 3 / 6 / (1 - nis ^ 2)
                    Else
                        kss = betas * Esv1 * tsv1 ^ 3 / 6 / (1 - nis ^ 2)
                    End If
                    lambdas = 6 * Ds / H ^ 3 * kss * (1 + H * betas + (H * betas) ^ 2 / 2)
                    ktt = betac * Ec * tc ^ 3 / 6 / (1 - nic ^ 2)
                    lambdac = 6 * DC / H ^ 3 * ktt * (1 + H * betac + (H * betac) ^ 2 / 2)
                    If ElasPlas Then
                        For iload = 1 To 3
                            If Not ThkAdjacent Then
                                .Zp(iCond + Offset, 542 + iload - 1 + 7 * Corroso) = betas * ES * .Zp(iCond + Offset, 539 + iload - 1 + 7 * Corroso) * ts ^ 3 / 6 / (1 - nis ^ 2)
                            Else
                                .Zp(iCond + Offset, 542 + iload - 1 + 7 * Corroso) = betas * Esv1 * .Zp(iCond + Offset, 539 + iload - 1 + 7 * Corroso) * tsv1 ^ 3 / 6 / (1 - nis ^ 2)
                            End If
                            .Zp(iCond + Offset, 663 + iload - 1 + 7 * Corroso) = 6 * Ds / H ^ 3 * .Zp(iCond + Offset, 542 + iload - 1 + 7 * Corroso) * (1 + H * betas + (H * betas) ^ 2 / 2)
                            .Zp(iCond + Offset, 556 + iload - 1 + 7 * Corroso) = betac * Ec * .Zp(iCond + Offset, 553 + iload - 1 + 7 * Corroso) * tc ^ 3 / 6 / (1 - nic ^ 2)
                            .Zp(iCond + Offset, 666 + iload - 1 + 7 * Corroso) = 6 * DC / H ^ 3 * .Zp(iCond + Offset, 556 + iload - 1 + 7 * Corroso) * (1 + H * betac + (H * betac) ^ 2 / 2)
                        Next
                    End If
                    '-----Step 3------------------
                    .Zp(iCond + Offset, 395 + Corroso) = betas
                    .Zp(iCond + Offset, 397 + Corroso) = betac
                    .Zp(iCond + Offset, 637 + Corroso) = kss
                    .Zp(iCond + Offset, 639 + Corroso) = ktt
                    .Zp(iCond + Offset, 641 + Corroso) = lambdas
                    .Zp(iCond + Offset, 643 + Corroso) = lambdac
                    .Zp(iCond + Offset, 757 + Corroso) = deltas
                    .Zp(iCond + Offset, 759 + Corroso) = deltac
                    If ptTipoAA < 100 Then
                        Kj = .Zp(iCond, 36 + Corroso)
                        If Kj = 0 Then
                            j = 1
                        Else
                            j = 1 / (1 + Ks / Kj)
                        End If
                    Else
                        j = 1
                    End If
                    .Zp(iCond, 57 + Corroso) = j
                    '--------------------------
                    hb = H
                    If hb = 0 Then hb = 50 : Itera = True
                    Testo = "Iterazione su spessore richiesto" & vbCrLf
                    Select Case Corroso
                        Case 0 : Testo = Testo & "in condizioni nuove"
                        Case 1 : Testo = Testo & "in condizioni corrose"
                    End Select
                    If Itera Then
                        Monitor.Motore.ProgrInizio(Testo, "AsmeVip")
                    Else
                        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
                    End If
                    c = Padre.BoltCiD(1)
                    Do
                        Lungh = Lunght - 2 * hb
                        '------Step 4---------------Step 3 per flott
                        If A02 > 2 Then
                            omegas = rhos * kss * betas * deltas * (1 + H * betas)
                            omegass = A0 ^ 2 * (rhos ^ 2 - 1) * (rhos - 1) / 4 - omegas
                            omegac = rhoc * ktt * betac * deltac * (1 + H * betac)
                            omegacs = A0 ^ 2 * ((rhoc ^ 2 + 1) * (rhoc - 1) / 4 - (rhos - 1) / 2) - omegac
                        Else
                            If Not ThkAdjacent Then
                                gammass = betas ^ 2 * ts ^ 2 * rhos ^ 3 * (1 + betas * hb) / 6 / (1 - nis ^ 2) * (1 - nis / 2)
                            Else
                                gammass = betas ^ 2 * tsv1 ^ 2 * rhos ^ 3 * (1 + betas * hb) / 6 / (1 - nis ^ 2) * (1 - nis / 2)
                            End If
                            gammas = (rhos ^ 2 - 1) * (rhos - 1) / 4 - gammass
                            gammacs = betac ^ 2 * tc ^ 2 * rhoc ^ 3 * (1 + betac * hb) / 6 / (1 - nic ^ 2) * (1 - nic / 2)
                            If A02 = 0 Then
                                gammac = (rhoc ^ 2 - 1) * (rhoc + 1) / 4 - (rhoc ^ 3 - rhos) / 2 + gammacs
                            Else
                                gammac = (rhoc ^ 2 + 1) * (rhoc - 1) / 4 - (rhos - 1) / 2 - gammacs
                            End If
                        End If
                        If .Rear = 1 Then
                            Select Case ptTipoAA
                                Case 5 : gammab = 0 'Fig. UHX-13.1 (a)
                                Case 6 : gammab = rhoc - c / 2 / A0 'Fig. UHX-13.1 (b)
                                Case 7 : gammab = rhoc - rhos 'Fig. UHX-13.1 (c) (caso non previsto: da dare G1 in input)
                                Case 8 : gammab = rhoc - rhos 'Fig. UHX-13.1 (d)i
                            End Select
                        Else
                            If Padre.GetPiastra = 1 Then
                                Select Case ptTipoAA
                                    Case 101 : gammab = 0
                                    Case 102 : gammab = rhoc - c / 2 / A0
                                    Case 103 : gammab = rhoc - g / 2 / A0
                                    Case 104 : gammab = rhoc - rhos
                                    Case 105 : gammab = -rhos + c / 2 / A0
                                    Case 106 : gammab = -rhos + g / 2 / A0
                                End Select
                            Else
                                Select Case .Flottante
                                    Case 1 : gammab = 0 'P - outside packed
                                    Case 2 : gammab = rhoc - g / 2 / A0 'S - with back ring
                                    Case 3 : gammab = rhoc - c / 2 / A0 'T - flanged
                                    Case 4 : gammab = 0 'T - integral
                                    Case 5 : gammab = 0 'W
                                End Select
                            End If
                        End If
                        .Zp(iCond + Offset, 535 + Corroso) = gammab
                        hsup = hb / p
                        If hsup > 2 Then hsup = 2
                        If hsup < 0.1 Then hsup = 0.1
                        If Not ltxperc Then AA13(iCond)
                        Calcolastar()
                        .Zp(iCond + Offset, 399) = hsup
                        .Zp(iCond + Offset, 400) = nistar
                        .Zp(iCond + Offset, 401) = EstarE
                        If A02 < 3 Then
                            .Zp(iCond + Offset, 422 + Corroso) = gammass
                            .Zp(iCond + Offset, 424 + Corroso) = gammas
                            .Zp(iCond + Offset, 426 + Corroso) = gammacs
                            .Zp(iCond + Offset, 428 + Corroso) = gammac
                        Else
                            .Zp(iCond + Offset, 422 + Corroso) = omegas
                            .Zp(iCond + Offset, 424 + Corroso) = omegass
                            .Zp(iCond + Offset, 426 + Corroso) = omegac
                            .Zp(iCond + Offset, 428 + Corroso) = omegacs
                        End If
                        alfasm = .Zp(iCond, 14)
                        alfatm = .Zp(iCond, 15)
                        Tempsm = .Zp(iCond, 5)
                        Temptm = .Zp(iCond, 6)
                        temp = .Zp(iCond, 4)
                        gamma = (alfatm * (Temptm - 20) - alfasm * (Tempsm - 20)) * Lungh
                        .Zp(iCond + Offset, 432) = gamma ' / inc
                        Pressg = NumTub * kt / pi / A0 ^ 2 * gamma
                        .Zp(iCond + Offset, 59 + Corroso) = Pressg
                        If .RadialExp Then
                            Tempp = .Zp(iCond + Offset, 594)
                            Tempsp = .Zp(iCond + Offset, 595)
                            Tempcp = .Zp(iCond + Offset, 596)
                            If .Rear = 1 Then 'piastre fisse
                                Select Case ptTipoAA
                                    Case 5 : Tempr = (Tempp + Tempsp + Tempcp) / 3
                                    Case 6, 60 : Tempr = (Tempp + Tempsp) / 2
                                    Case 7 : Tempr = Tempp
                                    Case Else : MessageBox.Show("Impossibile in AA24")
                                End Select
                            ElseIf .GetPiastra = 2 Then  'flottante
                                Select Case .Flottante
                                    Case 1, 4 : Tempr = (Tempp + Tempcp) / 2
                                    Case Else : Tempr = Tempp
                                End Select
                            Else 'fisso di un flottante
                                Select Case ptTipoAA
                                    Case 101 : Tempr = (Tempp + Tempsp + Tempcp) / 3
                                    Case 102, 103 : Tempr = (Tempp + Tempsp) / 2
                                    Case 105, 106 : Tempr = (Tempp + Tempcp) / 2
                                    Case Else : Tempr = Tempp
                                End Select
                            End If
                            Tempss = (Tempsp + Tempr) / 2
                            Tempcs = (Tempcp + Tempr) / 2
                            .Zp(iCond + Offset, 433) = Tempr
                            .Zp(iCond + Offset, 434) = Tempss
                            .Zp(iCond + Offset, 435) = Tempcs
                            alfasp = alfasm
                            alfap = Matdim(Involucr(kLato, jInvolucr).indice(1 - 1)).AlfaTer(Tempp)
                            If alfap = 0 Then
                                AA24 = False
                                If Itera Then
                                    Monitor.Motore.ProgrAmmazza()
                                Else
                                    System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
                                End If
                                Exit Function
                            End If
                            .Zp(iCond + Offset, 321) = alfap
                        Else
                            .Zp(iCond + Offset, 433) = 0
                            .Zp(iCond + Offset, 434) = 0
                            .Zp(iCond + Offset, 435) = 0
                            .Zp(iCond + Offset, 321) = 0
                        End If
                        eta = EstarE * (1 - ni * ni) / (1 - nistar * nistar)
                        .Zp(iCond + Offset, 271) = eta
                        Xa = (24 * (1 - nistar ^ 2) * NumTub * Et * (tt - cortubi * Corroso) * (dt - (tt - cortubi * Corroso)) * A0 ^ 2 / (EstarE * e * Lungh * hb ^ 3)) ^ 0.25
                        .Zp(iCond + Offset, 402 + Corroso) = Xa
                        If Escorr = 0 Then Escorr = ES
                        If Eccorr = 0 Then Eccorr = Ec
                        a = Padre.TSheDes
                        If (a < Ds + 2 * ts Or a < DC + 2 * tc) And Offset = 0 Or a <= 0 Then
                            If Not mioRis.GiaDetto Then
                                If MostraAiuto(IDH_PT_AA_DIAMEXT, RoutBase1.ChiaviMess.MessOKCancel + RoutBase1.ChiaviMess.MessHelpButton) = RoutBase1.ChiaviMess.MessCancel Then
                                    AA24 = False
                                    If Itera Then
                                        Monitor.Motore.ProgrAmmazza()
                                    Else
                                        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
                                    End If
                                    Exit Function
                                End If
                            End If
                            mioRis.GiaDetto = True
                        End If
                        If a <= 0 Then
                            AA24 = False
                            If Itera Then
                                Monitor.Motore.ProgrAmmazza()
                            Else
                                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
                            End If
                            Exit Function
                        End If
                        k = a / D0
                        f = (1 - nistar) / EstarE * ((lambdas + lambdac) / e + System.Math.Log(k))
                        phig = (1 + nistar) * f
                        If XaV <> Xa Or Offset <> OffSetV Then
                            calcZv = Zv(Xa)
                            calcZm = Zm(Xa)
                            calcZd = Zd(Xa)
                            q1 = (rhos - 1 - phig * calcZv) / (1 + phig * calcZm)
                            If ptTipoAA < 100 Then
                                '--------Step 6-----------------
                                QZ1 = (calcZd + q1 * calcZv) * Xa ^ 4 / 2
                                QZ2 = (calcZv + q1 * calcZm) * Xa ^ 4 / 2
                            End If
                            XaV = Xa
                            OffSetV = Offset
                        End If
                        If ElasPlas Then
                            For iload = 1 To 3
                                .Zp(iCond + Offset, 677 + iload - 1 + 7 * Corroso) = (1 - nistar) / EstarE * ((.Zp(iCond + Offset, 663 + iload - 1 + 7 * Corroso) + .Zp(iCond + Offset, 666 + iload - 1 + 7 * Corroso)) / e + System.Math.Log(k))
                                'phig
                                .Zp(iCond + Offset, 680 + iload - 1 + 7 * Corroso) = (1 + nistar) * .Zp(iCond + Offset, 677 + iload - 1 + 7 * Corroso)
                                'Q1
                                .Zp(iCond + Offset, 691 + iload - 1 + 7 * Corroso) = (rhos - 1 - .Zp(iCond + Offset, 680 + iload - 1 + 7 * Corroso) * calcZv) / (1 + .Zp(iCond + Offset, 680 + iload - 1 + 7 * Corroso) * calcZm)
                                If ptTipoAA < 100 Then
                                    'QZ1
                                    .Zp(iCond + Offset, 694 + iload - 1 + 7 * Corroso) = (calcZd + .Zp(iCond + Offset, 691 + iload - 1 + 7 * Corroso) * calcZv) * Xa ^ 4 / 2
                                    'QZ2
                                    .Zp(iCond + Offset, 705 + iload - 1 + 7 * Corroso) = (calcZv + .Zp(iCond + Offset, 691 + iload - 1 + 7 * Corroso) * calcZm) * Xa ^ 4 / 2
                                End If
                            Next
                        End If
                        .Zp(iCond + Offset, 669 + 7 * Corroso) = k
                        .Zp(iCond + Offset, 404 + Corroso) = f
                        .Zp(iCond + Offset, 412 + Corroso) = phig
                        .Zp(iCond + Offset, 414 + Corroso) = q1
                        If ptTipoAA < 100 Then
                            .Zp(iCond + Offset, 416 + Corroso) = QZ1
                            .Zp(iCond + Offset, 418 + Corroso) = QZ2
                        End If
                        .Zp(iCond + Offset, 406 + Corroso) = calcZv
                        .Zp(iCond + Offset, 408 + Corroso) = calcZm
                        .Zp(iCond + Offset, 410 + Corroso) = calcZd
                        If .RadialExp Then
                            If Not ThkAdjacent Then
                                Pressss = ES * ts / aas * (alfasp * (Tempss - 20) - alfap * (Tempr - 20))
                            Else
                                Pressss = ES * tsv1 / aas * (alfasp * (Tempss - 20) - alfap * (Tempr - 20))
                            End If
                            Presscs = Ec * tc / ac * (alfacp * (Tempcs - 20) - alfap * (Tempr - 20))
                        Else
                            Pressss = 0
                            Presscs = 0
                        End If
                        .Zp(iCond + Offset, 597) = Pressss
                        .Zp(iCond + Offset, 598) = Presscs
                        '-------------------------------------------------
                        '   W = .FlChanDati(15) '  .Zp(iCond + Offset, 32)
                        '   If .FlChanDati(16) > W Then W = .FlChanDati(16)
                        '   .Zp(iCond + Offset, 635) = W
                        '   W = .FlShelDati(15)
                        '   If .FlShelDati(16) > W Then W = .FlShelDati(16)
                        '   .Zp(iCond + Offset, 634) = W
                        '------------------------------------------------
                        W = .Zp(iCond + Offset, 634)
                        If .Zp(iCond + Offset, 635) > W Then W = .Zp(iCond + Offset, 635)
                        ' W = .Convert(W, 634, 0)
                        Presssd = .Zp(iCond, 1)
                        Presstd = .Zp(iCond, 2)
                        factmax = 0
                        If ptTipoAA < 100 Then
                            u = (calcZv + (rhos - 1) * calcZm) * Xa ^ 4 / (1 + phig * calcZm)
                            If ElasPlas Then
                                For iload = 1 To 3
                                    'U
                                    .Zp(iCond + Offset, 708 + iload - 1 + 7 * Corroso) = (calcZv + (rhos - 1) * calcZm) * Xa ^ 4 / (1 + .Zp(iCond + Offset, 680 + iload - 1 + 7 * Corroso) * calcZm)
                                Next
                            End If
                            .Zp(iCond + Offset, 420 + Corroso) = u
                            '--------Step 5------------------ ora 6
                            hj = (.Zp(1, 26) - Ds) / 2
                            If hj < 0 Then hj = 0
                            .Zp(iCond, 430 + Corroso) = hj '/ inc
                            If A02 < 3 Then
                                Presssp = (xs + NumTub * (dt - (tt - cortubi * Corroso)) * dt * nit / 2 / A0 ^ 2 + 2 * rhos ^ 2 * nis / Ksvt - (rhos ^ 2 - 1) / j / Ksvt - (1 - j) / j / Ksvt * aas * hj / A0 ^ 2 * (Ds + hj) / Ds) * Presssd
                                Presstp = (xt + NumTub * (dt - (tt - cortubi * Corroso)) * (dt - 2 * (tt - cortubi * Corroso)) / 2 / A0 ^ 2 * nit + 1 / j / Ksvt) * Presstd
                            Else
                                Presssp = (xs + 2 * (1 - xs) * nit + 2 / Ksvt * (Ds / D0) ^ 2 * nis - (rhos ^ 2 - 1) / j / Ksvt - (1 - j) / 2 / j / Ksvt * ((Ds + 2 * hj) ^ 2 - (2 * aas) ^ 2) / D0 ^ 2) * Presssd
                                Presstp = (xt + 2 * (1 - xt) * nit + 1 / j / Ksvt) * Presstd
                            End If
                            .Zp(iCond + Offset, 67 + Corroso) = Presssp
                            .Zp(iCond + Offset, 97 + Corroso) = Presstp
                            If A02 > 2 Then
                                Pressgs = u / A0 ^ 2 * (Pressss * omegas - Presscs * omegac) 'Pomega
                            Else
                                Pressgs = u * (Pressss * gammass - Presscs * gammacs)
                            End If
                            .Zp(iCond + Offset, 61 + Corroso) = Pressgs
                            PressW = -gammab * u * W / 2 / pi / A0 ^ 2
                            If A02 > 2 Then
                                Pressrim = -u / A0 ^ 2 * (Presssd * omegass - Presstd * omegacs)
                            ElseIf A02 = 2 Then
                                Pressrim = -u * (Presssd * gammas - Presstd * gammac)
                            Else
                                Pressrim = -u * (Presssd * gammas + Presstd * gammac)
                            End If
                            .Zp(iCond + Offset, 133 + Corroso) = Pressrim
                            If ElasPlas Then
                                For iload = 1 To 3
                                    Select Case iload
                                        Case 1 : ish = 0 : it = 1 : ig = 0
                                        Case 2 : ish = 1 : it = 0 : ig = 0
                                        Case 3 : ish = 1 : it = 1 : ig = 0
                                    End Select
                                    'PressW
                                    .Zp(iCond + Offset, 719 + iload - 1 + 7 * Corroso) = -gammab * .Zp(iCond + Offset, 708 + iload - 1 + 7 * Corroso) * W / 2 / pi / A0 ^ 2
                                    'Pressrim
                                    If A02 > 2 Then
                                        .Zp(iCond + Offset, 722 + iload - 1 + 7 * Corroso) = -.Zp(iCond + Offset, 708 + iload - 1 + 7 * Corroso) / A0 ^ 2 * (Presssd * omegass * ish - Presstd * omegacs * it)
                                    ElseIf A02 = 2 Then
                                        .Zp(iCond + Offset, 722 + iload - 1 + 7 * Corroso) = -.Zp(iCond + Offset, 708 + iload - 1 + 7 * Corroso) * (Presssd * gammas * ish - Presstd * gammac * it)
                                    Else
                                        .Zp(iCond + Offset, 732 + iload - 1 + 7 * Corroso) = -.Zp(iCond + Offset, 708 + iload - 1 + 7 * Corroso) * (Presssd * gammas + Presstd * gammac)
                                    End If
                                Next
                            End If
                        Else
                            PressW = gammab * W / 2 / pi 'forza
                        End If
                        .Zp(iCond + Offset, 63 + Corroso) = PressW
                        fact = 0
                        StPos1 = 0 : StcPos1 = 0
                        StPos2 = 0 : StcPos2 = 0
                        For iload = 1 To 7
                            If iload < 4 And ElasPlas Then
                                kss = .Zp(iCond + Offset, 542 + iload - 1 + 7 * Corroso)
                                ktt = .Zp(iCond + Offset, 556 + iload - 1 + 7 * Corroso)
                                lambdas = .Zp(iCond + Offset, 663 + iload - 1 + 7 * Corroso)
                                lambdac = .Zp(iCond + Offset, 666 + iload - 1 + 7 * Corroso)
                                phig = .Zp(iCond + Offset, 680 + iload - 1 + 7 * Corroso)
                                q1 = .Zp(iCond + Offset, 691 + iload - 1 + 7 * Corroso)
                                QZ1 = .Zp(iCond + Offset, 694 + iload - 1 + 7 * Corroso)
                                QZ2 = .Zp(iCond + Offset, 705 + iload - 1 + 7 * Corroso)
                                u = .Zp(iCond + Offset, 708 + iload - 1 + 7 * Corroso)
                                PressW = .Zp(iCond + Offset, 719 + iload - 1 + 7 * Corroso)
                                Pressrim = .Zp(iCond + Offset, 722 + iload - 1 + 7 * Corroso)
                            ElseIf ElasPlas Then
                                GoTo jump
                            Else
                                ' kss = .Zp(iCond + Offset, 637 + Corroso)
                                ' ktt = .Zp(iCond + Offset, 639 + Corroso)
                                ' lambdas = .Zp(iCond + Offset, 641 + Corroso)
                                ' lambdac = .Zp(iCond + Offset, 643 + Corroso)
                            End If
                            Select Case iload
                                Case 1 : ish = 0 : it = 1 : ig = 0
                                Case 2 : ish = 1 : it = 0 : ig = 0
                                Case 3 : ish = 1 : it = 1 : ig = 0
                                Case 4 : ish = 0 : it = 0 : ig = 1
                                Case 5 : ish = 0 : it = 1 : ig = 1
                                Case 6 : ish = 1 : it = 0 : ig = 1
                                Case 7 : ish = 1 : it = 1 : ig = 1
                            End Select
                            If .Rear = 1 Then
                                If A02 >= 2 Then
                                    iw = 1
                                    If ElasPlas And iload < 4 Then
                                    Else
                                        If A02 > 2 Then
                                            Pressrim = -u / A0 ^ 2 * (Presssd * omegass * ish - Presstd * omegacs * it)
                                        Else
                                            Pressrim = -u * (Presssd * gammas * ish - Presstd * gammac * it)
                                        End If
                                    End If
                                Else
                                    Select Case ptTipoAA
                                        Case 5 : iw = 0
                                        Case 6 : iw = it
                                        Case 7 : iw = it
                                        Case 8 : iw = ish : If it > iw Then iw = it
                                    End Select
                                    If ElasPlas And iload < 4 Then
                                    Else
                                        Pressrim = -u * (Presssd * gammas * ish + Presstd * gammac * it)
                                    End If
                                End If
                                PressEff = j * Ksvt / (1 + j * Ksvt * (QZ1 + (rhos - 1) * QZ2)) * (Presssp * ish - Presstp * it + Pressg * ig + Pressgs * ig + PressW * iw + Pressrim)
                            ElseIf .Rear = 2 Then
                                Select Case .Flottante
                                    Case 2, 3, 4
                                        PressEff = Presssd * ish - Presstd * it
                                    Case 1
                                        PressEff = (1 - rhos ^ 2) * Presssd * ish - Presstd * it
                                    Case 5 'W
                                        PressEff = (Presssd * ish - Presstd * it) * (1 - rhos ^ 2)
                                End Select
                                iw = 1
                            End If
                            '---------Step 7--------------
                            hpg = HG - CT * Corroso
                            If hpg < 0 Then hpg = 0
                            hpg1 = .GrvChan + .GrvShel
                            If hpg1 > hpg Then hpg = hpg1
                            Select Case iload
                                Case 1, 2, 3
                                    'hpg = HG - CT * Corroso
                                    'If hpg < 0 Then hpg = 0
                                Case 4, 5, 6
                                    'hpg = 0
                                    If NonTermici() Then PressEff = 0
                                Case 7
                                    'hpg = 0
                                    If NonTermici() Then PressEff = .Zp(iCond + Offset, 330 + 3 - 1 + 7 * Corroso)
                            End Select
                            If ElasPlas And iload < 4 Then
                                .Zp(iCond + Offset, 771 + iload - 1 + 7 * Corroso) = PressEff
                            Else
                                .Zp(iCond + Offset, 330 + iload - 1 + 7 * Corroso) = PressEff   'max343
                            End If
                            If PressEff <> 0 And Not (NonTermici() And iload = 7) Then
                                Select Case .Rear
                                    Case 1
                                        If A02 >= 2 Then
                                            If A02 > 2 Then
                                                q2 = ((-Presstd * omegacs * it + Presscs * omegac * ig + Presssd * omegass * ish - Pressss * omegas * ig) + W * gammab * iw / 2 / pi) / (1 + phig * calcZm)
                                            Else
                                                q2 = (A0 ^ 2 * (-Presstd * gammac * it + Presscs * gammacs * ig + Presssd * gammas * ish - Pressss * gammass * ig) + W * gammab * iw / 2 / pi) / (1 + phig * calcZm)
                                            End If
                                            q3 = q1 + 2 * q2 / PressEff / A0 ^ 2
                                            QZ2s = (calcZv + q1 * calcZm) * PressEff + 2 / A0 ^ 2 * calcZm * q2
                                        Else
                                            q3 = q1 + (2 * (Presstd * gammac * it + Presscs * gammacs * ig + Presssd * gammas * ish - Pressss * gammass * ig) + W * gammab * iw / pi / A0 ^ 2) / PressEff / (1 + phig * calcZm)
                                            QZ2s = (calcZv + q3 * calcZm) * Xa ^ 4 / 2
                                        End If
                                        .Zp(iCond + Offset, 645 + iload - 1 + 7 * Corroso) = QZ2s '
                                        Fq = (calcZd + q3 * calcZv) * Xa ^ 4 / 2
                                        .Zp(iCond + Offset, 145 + iload - 1 + 7 * Corroso) = Fq 'max 158
                                        If Xa <> XaV Or q3 <> Q3V Then
                                            calcFm = maxFm(Xa, q3)
                                            XaV = Xa
                                            Q3V = q3
                                        End If
                                        .Zp(iCond + Offset, 450 + iload - 1 + 7 * Corroso) = calcFm
                                        Sigma = 1.5 * calcFm / mistar * (2 * A0 / (hb - hpg)) ^ 2 * PressEff
                                        Tau = 0.5 / migrec * A0 / (hb - CT * Corroso - hpg1) * PressEff
                                    Case 2
                                        If A02 = 0 Then
                                            q2 = (A0 ^ 2 * (Presstd * gammac * it + Presscs * gammacs * ig + Presssd * gammas * ish - Pressss * gammass * ig) + W * gammab * iw / 2 / pi) / (1 + phig * calcZm)
                                        Else
                                            If NonTermici() And iload > 3 Then
                                                q2 = 0
                                            Else
                                                If A02 > 2 Then
                                                    q2 = ((-Presstd * omegacs * it + Presscs * omegac * ig + Presssd * omegass * ish - Pressss * omegas * ig) + W * gammab * iw / 2 / pi) / (1 + phig * calcZm)
                                                Else
                                                    q2 = (A0 ^ 2 * (-Presstd * gammac * it + Presscs * gammacs * ig + Presssd * gammas * ish - Pressss * gammass * ig) + W * gammab * iw / 2 / pi) / (1 + phig * calcZm)
                                                End If
                                            End If
                                        End If
                                        q3 = q1 + 2 * q2 / PressEff / A0 ^ 2
                                        QZ2s = (calcZv + q1 * calcZm) * PressEff + 2 / A0 ^ 2 * calcZm * q2
                                        .Zp(iCond + Offset, 645 + iload - 1 + 7 * Corroso) = QZ2s '
                                        If Xa <> XaV Or q3 <> Q3V Or calcFm = 0 Then
                                            calcFm = maxFm(Xa, q3)
                                            XaV = Xa
                                            Q3V = q3
                                        End If
                                        Sigma = 1.5 * calcFm / mistar * (2 * A0 / (hb - hpg)) ^ 2 * PressEff
                                        Tau = 0.5 / migrec * A0 / (hb - CT * Corroso - hpg1) * PressEff
                                End Select
                            Else
                                'calcFm = 0
                                Select Case .Rear
                                    Case 1
                                        Sigma = 0
                                        Tau = 0
                                    Case 2
                                        If NonTermici() Then
                                            q2 = 0
                                            Tau = 0
                                        Else
                                            If A02 = 0 Then
                                                q2 = (A0 ^ 2 * (Presstd * gammac * it + Presscs * gammacs * ig + Presssd * gammas * ish - Pressss * gammass * ig) + W * gammab * iw / 2 / pi) / (1 + phig * calcZm)
                                            ElseIf A02 < 2 Then
                                                q2 = (A0 ^ 2 * (-Presstd * gammac * it + Presscs * gammacs * ig + Presssd * gammas * ish - Pressss * gammass * ig) + W * gammab * iw / 2 / pi) / (1 + phig * calcZm)
                                            Else
                                                q2 = ((-Presstd * omegacs * it + Presscs * omegac * ig + Presssd * omegass * ish - Pressss * omegas * ig) + W * gammab * iw / 2 / pi) / (1 + phig * calcZm)
                                            End If
                                            Tau = 0.5 / migrec * A0 / (hb - CT * Corroso - hpg1) * PressEff
                                        End If
                                        Sigma = 6 * q2 / mistar / (hb - hpg) ^ 2
                                End Select
                                q3 = 0
                            End If
                            If ElasPlas And iload < 4 Then
                                .Zp(iCond + Offset, 774 + iload - 1 + 7 * Corroso) = q2 ' / NIUT
                                .Zp(iCond + Offset, 785 + iload - 1 + 7 * Corroso) = q3
                                .Zp(iCond + Offset, 788 + iload - 1 + 7 * Corroso) = calcFm
                            Else
                                .Zp(iCond + Offset, 171 + iload - 1 + 7 * Corroso) = q2 ' / NIUT
                                .Zp(iCond + Offset, 436 + iload - 1 + 7 * Corroso) = q3
                                .Zp(iCond + Offset, 450 + iload - 1 + 7 * Corroso) = calcFm
                            End If
                            Select Case iload
                                Case 1, 2, 3
                                    fact = System.Math.Abs(Sigma) / 1.5 / s
                                    .Zp(iCond + Offset, 733 + iload - 1) = 1.5 * s
                                    If Corroso = 0 And System.Math.Abs(Sigma) > StPos1 Then StPos1 = System.Math.Abs(Sigma)
                                    If Corroso = 1 And System.Math.Abs(Sigma) > StcPos1 Then StcPos1 = System.Math.Abs(Sigma)
                                Case Else
                                    If A02 = 0 Then
                                        fact = System.Math.Abs(Sigma) / 3 / s
                                        .Zp(iCond + Offset, 733 + iload - 1) = 3 * s
                                    Else
                                        fact = System.Math.Abs(Sigma) / SPS
                                        .Zp(iCond + Offset, 733 + iload - 1) = SPS
                                    End If
                                    If Corroso = 0 And System.Math.Abs(Sigma) > StPos2 Then StPos2 = System.Math.Abs(Sigma)
                                    If Corroso = 1 And System.Math.Abs(Sigma) > StcPos2 Then StcPos2 = System.Math.Abs(Sigma)
                            End Select
                            If fact > factmax Then factmax = fact
                            fact = System.Math.Abs(Tau) / 0.8 / s
                            If fact > factmax Then factmax = fact
                            If Not ElasPlas Then
                                .Zp(iCond + Offset, 464 + iload - 1 + 7 * Corroso) = Sigma
                                .Zp(iCond + Offset, 478 + iload - 1 + 7 * Corroso) = Tau
                                If iload < 4 Then
                                    .Zp(iCond + Offset, 741 + iload - 1 + 7 * Corroso) = Sigma
                                    .Zp(iCond + Offset, 744 + iload - 1 + 7 * Corroso) = Tau
                                End If
                            ElseIf iload < 4 Then
                                .Zp(iCond + Offset, 741 + iload - 1 + 7 * Corroso) = Sigma
                                .Zp(iCond + Offset, 744 + iload - 1 + 7 * Corroso) = Tau
                            End If
jump:
                        Next iload
                        If Corroso = 0 Then
                            .Zp(iCond + Offset, 690) = StPos1
                            If Not ElasPlas Then .Zp(iCond + Offset, 704) = StPos2
                        Else
                            .Zp(iCond + Offset, 697) = StcPos1
                            If Not ElasPlas Then .Zp(iCond + Offset, 711) = StcPos2
                        End If
                        .Zp(iCond + Offset, 740) = 0.8 * s
                        If fact <= 0 Or Not Itera Or (.Rear = 2 And .GetPiastra = 2) Then Exit Do
                        hbvec = hb
                        hb = factmax ^ 0.66 * hb
                        If System.Math.Abs(hb - hbvec) / hb < 100 * clsTrigon.TOLER Then Exit Do
                        ic = ic + 1
                        Monitor.Motore.Avanzamento = ic * 100 / icMax
                        If ic > icMax Then
                            MessageBox.Show("non convergenza 1")
                            Exit Do
                        End If
                    Loop
                    If Not ElasPlas Then
                        .Zp(iCond + Offset, 537 + Corroso) = factmax
                        .Zp(iCond + Offset, 769 + Corroso) = 0
                    Else
                        .Zp(iCond + Offset, 769 + Corroso) = factmax
                    End If
                    XaV = 0
                    '                    hr = 0
                    hr = hb ': If HG - CT * Corroso > 0 Then hr = hb + HG - CT * Corroso
                    .Zp(iCond + Offset, 159 + Corroso) = hr / inc
                    .Zp(iCond + Offset, 161 + Corroso) = hr
                End With
            Next Corroso
            Dim tauc As Single
            Dim i As Short
            With CType(Padre.Piastra, wn_FTC)
                Tau = 0 : tauc = 0
                For i = 478 To 484
                    If System.Math.Abs(.Zp(iCond + Offset, i)) > Tau Then Tau = System.Math.Abs(.Zp(iCond + Offset, i))
                    If System.Math.Abs(.Zp(iCond + Offset, i + 7)) > tauc Then tauc = System.Math.Abs(.Zp(iCond + Offset, i + 7))
                Next
                .Zp(iCond + Offset, 755) = Tau
                .Zp(iCond + Offset, 756) = tauc
            End With
        Catch e As Exception
            MessageBox.Show(e.Message + vbCrLf + e.StackTrace)
        End Try
        If Itera Then
            Monitor.Motore.ProgrAmmazza()
        Else
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        End If
    End Function
    Private Function ValoriChannel(ByVal icond As Short, ByVal OffSet As Short, ByVal Itera As Boolean) As Boolean
        If ElasPlas Then Return True
        With CType(Padre.Piastra, wn_FTC)
            Ec = Matdim(Indmat).EmodAlt(Tempc)
            alfacp = Matdim(Indmat).AlfaTer(Tempc)
            If alfacp * Ec = 0 Then
                If Itera Then
                    Monitor.Motore.ProgrAmmazza()
                Else
                    System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
                End If
                Return False
            End If
            .Zp(icond + OffSet, 324) = alfacp
            'If Offset = 8 Then .Zp(iCond, 1324) = alfacp
            Matdim(Indmat).SigmaAmm(CodiceStress, Tempc, Sfa, Sfo)
            Sc = Sfo
            .Zp(icond + OffSet, 325) = Sc
            'Sc = .Zp(iCond + Offset, 325)
            Matdim(Indmat).YieldTemp(CodiceStress, Tempc, Sfa, Sfo)
            Syc = Sfo
            Scs = Syc
            .Zp(icond, 326) = Syc
            If A02 = 0 Then
                .Zp(icond + OffSet, 534) = Sc * 3
                If 1.5 * Sc < Scs Then Scs = 1.5 * Sc
            Else
                'Indmat = Involucr(kLato, jInvolucr).indice(5)
                .Zp(icond + OffSet, 534) = Matdim(Indmat).SPS(CodiceStress, Tempc)
                If .Zp(icond + OffSet, 534) / 2 < Scs Then Scs = .Zp(icond + OffSet, 534) / 2
            End If
            .Zp(icond, 500) = Scs
            .Zp(icond, 533) = Scs
        End With
        Return True
    End Function
    Private Function AA23(ByRef iCond As Short, ByVal Offset As Short, ByRef Corroso As Short) As Boolean
        Dim cscodS, ctcodS As Single
        Dim cscodF, ctcodF As Single
        AA23 = True
        CorrCod(cscodS, ctcodS, cscodF, ctcodF)
        cscodS = cscodS * Corroso
        ctcodS = ctcodS * Corroso
        cscodF = cscodF * Corroso
        ctcodF = ctcodF * Corroso
        With Padre
            If CType(.Piastra, wn_FTC).GetPiastra = 2 And ptTipoAA > 99 Then
                Select Case CType(.Piastra, wn_FTC).Flottante
                    Case 1 'P - outside packed
                        DC = .SlChanDati(1) + 2 * ctcodS
                        tc = .SlChanDati(2) - ctcodS
                        ac = DC / 2 '(DC + tc) / 2
                        If Not Check() Then Return False
                    Case 2 'S - with back ring
                        g = .FlChanDati(19)
                        If g = 0 Then g = .FlChanDati(5)
                        ac = g / 2
                    Case 3 'T - flanged
                        g = .FlChanDati(19)
                        If g = 0 Then g = .FlChanDati(5)
                        ac = g / 2
                    Case 4 'T - integral
                        DC = .SlChanDati(1) + 2 * ctcodS
                        tc = .SlChanDati(2) - ctcodS
                        ac = DC / 2 ' (DC + tc) / 2
                        If Not Check() Then Return False
                    Case 5 'W
                        ac = .TSheDes / 2
                End Select
                aas = ac '(vedi nomenclatura)
            Else
                Select Case ptTipoAA
                    Case 5, 101 'saldata
                        Ds = .SlShelDati(1) + 2 * cscodS
                        DC = .SlChanDati(1) + 2 * ctcodS
                        tsv1 = .SlShelDati(2) - cscodS
                        ts = .SpessMant - cscodS
                        tc = .SlChanDati(2) - ctcodS
                        aas = Ds / 2 ' (Ds + ts) / 2
                        ac = DC / 2 ' (DC + tc) / 2
                    Case 6, 102, 103 'flangiata lato cassa
                        Ds = .SlShelDati(1) + 2 * cscodS
                        DC = .FlChanDati(2) + 2 * ctcodF
                        tsv1 = .SlShelDati(2) - cscodS
                        ts = .SpessMant - cscodS
                        tc = .FlChanDati(4) - ctcodF
                        g = .FlChanDati(19)
                        If g = 0 Then
                            WarnT(-293)
                            Return False
                        End If
                        aas = Ds / 2 ' (Ds + ts) / 2
                        ac = g / 2
                    Case 7 'idem senza estensione e con anello
                        MessageBox.Show("senza estensione e con anello da programmare")
                    Case 105, 106
                        Ds = .FlShelDati(2) + 2 * cscodS
                        DC = .SlChanDati(1) + 2 * ctcodF
                        ts = .FlShelDati(4) - cscodS
                        tc = .SlChanDati(2) - ctcodF
                        g = .FlShelDati(19)
                        aas = g / 2
                        ac = DC / 2 ' (DC + tc) / 2
                    Case 8, 104 'biflangiata???
                        Ds = .FlShelDati(2) + 2 * cscodS
                        DC = .FlChanDati(2) + 2 * ctcodF
                        ts = .FlShelDati(4) - cscodS
                        tc = .FlChanDati(4) - ctcodF
                        g = .FlShelDati(19)
                        If .FlChanDati(19) > g Then g = .FlChanDati(19)
                        aas = .FlShelDati(19) / 2
                        ac = .FlChanDati(19) / 2
                End Select
            End If
            CType(.Piastra, wn_FTC).Zp(iCond + Offset, 378 + Corroso) = aas
            CType(.Piastra, wn_FTC).Zp(iCond + Offset, 380 + Corroso) = ac
        End With
    End Function
    Private Function Check() As Boolean
        If DC <= 0 Then
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Padre.Piastra.WarnT. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            Padre.Piastra.WarnT(-312)
            Return False
        End If
        If tc <= 0 Then
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Padre.Piastra.WarnT. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            Padre.Piastra.WarnT(-313)
            Return False
        End If
        Return True
    End Function
    Private Function maxFm(ByRef Xa As Single, ByRef q3 As Single) As Single
        Dim i As Short
        Dim x1, x2 As Single
        Dim IMAX, ic As Short
        Dim delta As Single
        Dim deltamax As Single
        Dim Registro As String
        Dim Valore As Single
        On Error GoTo Errcol
        Registro = Format(Xa, Espr) & Format(q3, Espr)
        Valore = colFM.Item(Registro)
        maxFm = Valore
        Exit Function
First:
        x1 = 0 : x2 = Xa
        Do
            For i = 0 To nMax
                xValues(i) = x1 + i * (x2 - x1) / nMax
                FmValues(i) = System.Math.Abs(Fm(xValues(i), Xa, q3))
                If i > 0 Then
                    delta = System.Math.Abs(FmValues(i) - FmValues(i - 1))
                    If delta > deltamax Then deltamax = delta
                    If FmValues(i) < FmValues(i - 1) Then IMAX = i - 1 Else IMAX = i
                End If
            Next
            If deltamax / FmValues(IMAX) < clsTrigon.TOLER * 15 Or (x2 - x1) / x2 < clsTrigon.TOLER * 15 Then Exit Do
            Select Case IMAX
                Case 0
                    x1 = xValues(IMAX)
                    x2 = xValues(IMAX + 1)
                Case nMax
                    x1 = xValues(IMAX - 1)
                    x2 = xValues(IMAX)
                Case Else
                    x1 = (xValues(IMAX - 1) + xValues(IMAX)) / 2
                    x2 = (xValues(IMAX) + xValues(IMAX + 1)) / 2
            End Select
            ic = ic + 1
            deltamax = 0
            If ic > icMax Then
                MessageBox.Show("non convergenza 2")
                Exit Do
            End If
        Loop
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Valore. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
        Valore = FmValues(IMAX)
        colFM.Add(Valore, Registro)
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Valore. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
        maxFm = Valore
        Exit Function
Errcol: Resume First
    End Function
    Public Sub AA248(ByRef iCond As Short)
        Dim it, iload, ish, ig As Short
        Dim StNeg, StPos, StcPos, StcNeg As Single
        Dim Corroso As Short
        Dim Omega As Single
        With CType(Padre.Piastra, wn_FTC)
            For Corroso = 0 To 1
                For iload = 1 To 7
                    If iCond < 9 Then
                        If NonTermici() And iload > 3 Then
                            sigmatv0 = 0
                        Else
                            Select Case iload
                                Case 1 : ish = 0 : it = 1 : ig = 0
                                Case 2 : ish = 1 : it = 0 : ig = 0
                                Case 3 : ish = 1 : it = 1 : ig = 0
                                Case 4 : ish = 0 : it = 0 : ig = 1
                                Case 5 : ish = 0 : it = 1 : ig = 1
                                Case 6 : ish = 1 : it = 0 : ig = 1
                                Case 7 : ish = 1 : it = 1 : ig = 1
                            End Select
                            PressEff = .Zp(iCond, 330 + iload - 1 + 7 * Corroso)   'max 143
                            If ptTipoAA < 99 Then
                                Fq = .Zp(iCond, 145 + iload - 1 + 7 * Corroso)
                                sigmatv0 = ((Presssd * xs * ish - Presstd * xt * it) - PressEff * Fq) / (xt - xs)
                            Else
                                If .GetPiastra = 2 Then Exit Sub
                                q1 = .Zp(iCond, 414 + Corroso)
                                Xa = .Zp(iCond, 402 + Corroso)
                                calcZv = .Zp(iCond, 406 + Corroso)
                                calcZd = .Zp(iCond, 410 + Corroso)
                                q2 = .Zp(iCond, 171 + iload - 1 + 7 * Corroso)
                                sigmatv0 = (2 * (Presssd * xs * ish - Presstd * xt * it) - Xa ^ 4 * (PressEff * (calcZd + calcZv * q1) + 2 * q2 * calcZv / A0 ^ 2)) / 2 / (xt - xs)
                            End If
                        End If
                        .Zp(iCond, 223 + iload - 1 + 7 * Corroso) = sigmatv0
                    Else
                        .Zp(iCond, 223 + iload - 1 + 7 * Corroso) = .Zp(iCond - 8, 223 + iload - 1 + 7 * Corroso)
                    End If
                Next iload
            Next Corroso
            StPos = -clsTrigon.Infinito : StcPos = -clsTrigon.Infinito
            StNeg = clsTrigon.Infinito : StcNeg = clsTrigon.Infinito
            For iload = 1 To 7
                Omega = 1 : If iload > 3 Then Omega = 2
                If .Zp(iCond, 223 + iload - 1) / Omega > StPos Then StPos = .Zp(iCond, 223 + iload - 1) / Omega
                If .Zp(iCond, 223 + iload + 6) / Omega > StcPos Then StcPos = .Zp(iCond, 223 + iload + 6) / Omega
                If .Zp(iCond, 223 + iload - 1) < StNeg Then StNeg = .Zp(iCond, 223 + iload - 1)
                If .Zp(iCond, 223 + iload + 6) < StcNeg Then StcNeg = .Zp(iCond, 223 + iload + 6)
            Next
            If StPos < 0 Then StPos = 0
            If StcPos < 0 Then StcPos = 0
            If StNeg > 0 Then StNeg = 0
            If StcNeg > 0 Then StcNeg = 0
            .Zp(iCond, 237) = StPos
            .Zp(iCond, 238) = StcPos
            .Zp(iCond, 239) = StNeg
            .Zp(iCond, 240) = StcNeg
            .Zp(iCond, 683) = 2 * .Zp(iCond, 13)
        End With
    End Sub
    Public Sub AA249(ByRef iCond As Short, ByRef Offset As Short)
        Dim it, iload, ish, ig As Short
        Dim StNeg, StPos, StcPos, StcNeg As Single
        Dim Corroso As Short
        Dim Omega As Single
        Dim StPos1, StcPos1 As Single
        Dim StPos2, StcPos2 As Single
        Dim OK As Boolean
        ElasPlas = False
        junctionOK(1, iCond + Offset) = True
        With CType(Padre.Piastra, wn_FTC)
            Select Case ptTipoAA
                Case 0 To 4 : GoTo ExSub
                Case 8 To 99 : GoTo ExSub
                Case 101 To 106
                    If .GetPiastra = 2 Then
                        GoTo ExSub
                    Else
                        Select Case ptTipoAA
                            Case 104 To 106 : GoTo ExSub
                        End Select
                    End If
            End Select
            For Corroso = 0 To 1
                For iload = 1 To 7
                    If NonTermici() And iload > 3 Then
                        sigmas = 0
                        sigmasvm = 0
                        sigmasvb = 0
                    Else
                        Select Case iload
                            Case 1 : ish = 0 : it = 1 : ig = 0
                            Case 2 : ish = 1 : it = 0 : ig = 0
                            Case 3 : ish = 1 : it = 1 : ig = 0
                            Case 4 : ish = 0 : it = 0 : ig = 1
                            Case 5 : ish = 0 : it = 1 : ig = 1
                            Case 6 : ish = 1 : it = 0 : ig = 1
                            Case 7 : ish = 1 : it = 1 : ig = 1
                        End Select
                        PressEff = .Zp(iCond + Offset, 330 + iload - 1 + 7 * Corroso)
                        Presssd = .Zp(iCond, 1)
                        Presstd = .Zp(iCond, 2)
                        If A02 >= 2 Then
                            If Not ThkAdjacent Then
                                sigmasvm = A0 ^ 2 / 2 / (aas + ts) / ts * (PressEff + (rhos ^ 2 - 1) * (Presssd * ish - Presstd * it)) + aas ^ 2 / 2 / (aas + ts) / ts * Presstd * it
                            Else
                                sigmasvm = A0 ^ 2 / 2 / (aas + tsv1) / tsv1 * (PressEff + (rhos ^ 2 - 1) * (Presssd * ish - Presstd * it)) + aas ^ 2 / 2 / (aas + tsv1) / tsv1 * Presstd * it
                            End If
                        Else
                            sigmasvm = A0 ^ 2 * PressEff / 2 / aas / ts + Presstd * it * aas / 2 / ts + (Presssd * ish - Presstd * it) / 2 * A0 * (rhos ^ 2 - 1) / rhos / ts
                        End If
                        If ptTipoAA < 99 Then
                            Xa = .Zp(iCond + Offset, 402 + Corroso)
                            QZ2s = .Zp(iCond + Offset, 645 + iload - 1 + 7 * Corroso) 'max 184
                            If A02 > 2 Then
                                If Not ThkAdjacent Then
                                    sigmasvb = 6 / ts ^ 2 * kss * (betas * (deltas * Presssd * ish + aas ^ 2 / ES / ts * Pressss * ig - nis * sigmasvm * aas / ES) + 6 * (1 - nistar ^ 2) / EstarE / E * A0 ^ 3 / hb ^ 3 * (1 + hb * betas / 2) * QZ2s)
                                Else
                                    sigmasvb = 6 / tsv1 ^ 2 * kss * (betas * (deltas * Presssd * ish + aas ^ 2 / Esv1 / tsv1 * Pressss * ig - nis * sigmasvm * aas / Esv1) + 6 * (1 - nistar ^ 2) / EstarE / E * A0 ^ 3 / hb ^ 3 * (1 + hb * betas / 2) * QZ2s)
                                End If
                            ElseIf A02 = 2 Then
                                If Not ThkAdjacent Then
                                    sigmasvb = 6 / ts ^ 2 * kss * (betas * aas ^ 2 / ES / ts * ((1 - nis / 2) * Presssd * ish + Pressss * ig - nis * sigmasvm * ts / aas) + 6 * (1 - nistar ^ 2) / EstarE / E * A0 ^ 3 / hb ^ 3 * (1 + hb * betas / 2) * QZ2s)
                                Else
                                    sigmasvb = 6 / tsv1 ^ 2 * kss * (betas * aas ^ 2 / Esv1 / tsv1 * ((1 - nis / 2) * Presssd * ish + Pressss * ig - nis * sigmasvm * tsv1 / aas) + 6 * (1 - nistar ^ 2) / EstarE / E * A0 ^ 3 / hb ^ 3 * (1 + hb * betas / 2) * QZ2s)
                                End If
                            Else
                                sigmasvb = 12 * (1 + betas * hb / 2) * ES / E * betas * ts / eta * A0 ^ 3 / hb ^ 3 / Xa ^ 4 * PressEff * QZ2s + 1 / (1 - nis ^ 2) * (Presssd * ish - nis * sigmasvm * ts / aas + Pressss * ig) * betas ^ 2 * aas ^ 2
                            End If
                        Else
                            calcZv = .Zp(iCond + Offset, 406 + Corroso)
                            calcZm = .Zp(iCond + Offset, 408 + Corroso)
                            q1 = .Zp(iCond + Offset, 414 + Corroso)
                            q2 = .Zp(iCond + Offset, 171 + iload - 1 + 7 * Corroso) * NIUT
                            If A02 >= 2 Then
                                QZ2s = .Zp(iCond + Offset, 645 + iload - 1 + 7 * Corroso) 'max 184
                                sigmasvb = 6 / ts ^ 2 * kss * (betas * aas ^ 2 / ES / ts * ((1 - nis / 2) * Presssd * ish + Pressss * ig - nis * sigmasvm * ts / aas) + 6 * (1 - nistar ^ 2) / EstarE / E * A0 ^ 3 / hb ^ 3 * (1 + hb * betas / 2) * QZ2s)
                            Else
                                sigmasvb = 12 * (1 + betas * hb / 2) * ES / E * betas * ts / eta * A0 ^ 3 / hb ^ 3 / 2 * (PressEff * (calcZv + calcZm * q1) + 2 * q2 * calcZm / A0 ^ 2) + 1 / (1 - nis ^ 2) * (Presssd * ish - nis * sigmasvm * ts / aas + Pressss * ig) * betas ^ 2 * aas ^ 2
                            End If
                        End If
                        sigmas = System.Math.Abs(sigmasvm) + System.Math.Abs(sigmasvb)
                    End If
                    .Zp(iCond + Offset, 501 + iload - 1 + 7 * Corroso) = sigmasvm  'max 200
                    .Zp(iCond + Offset, 187 + iload - 1 + 7 * Corroso) = sigmas  'max 80
                    .Zp(iCond + Offset, 567 + iload - 1 + 7 * Corroso) = sigmasvb  'max 200
                Next iload
            Next Corroso
            StPos = -clsTrigon.Infinito : StcPos = -clsTrigon.Infinito
            StNeg = clsTrigon.Infinito : StcNeg = clsTrigon.Infinito
            StPos1 = 0 : StcPos1 = 0
            StPos2 = 0 : StcPos2 = 0
            For iload = 1 To 7
                Omega = 1 : If iload < 4 Then Omega = 2
                If .Zp(iCond + Offset, 187 + iload - 1) * Omega > StPos Then StPos = .Zp(iCond + Offset, 187 + iload - 1) * Omega
                If .Zp(iCond + Offset, 187 + iload + 6) * Omega > StcPos Then StcPos = .Zp(iCond + Offset, 187 + iload + 6) * Omega
                If iload < 4 Then
                    If .Zp(iCond + Offset, 187 + iload - 1) > StPos1 Then StPos1 = .Zp(iCond + Offset, 187 + iload - 1)
                    If .Zp(iCond + Offset, 187 + iload + 6) > StcPos1 Then StcPos1 = .Zp(iCond + Offset, 187 + iload + 6)
                Else
                    If .Zp(iCond + Offset, 187 + iload - 1) > StPos2 Then StPos2 = .Zp(iCond + Offset, 187 + iload - 1)
                    If .Zp(iCond + Offset, 187 + iload + 6) > StcPos2 Then StcPos2 = .Zp(iCond + Offset, 187 + iload + 6)
                End If
                If .Zp(iCond + Offset, 501 + iload - 1) < StNeg Then StNeg = .Zp(iCond + Offset, 501 + iload - 1)
                If .Zp(iCond + Offset, 501 + iload + 6) < StcNeg Then StcNeg = .Zp(iCond + Offset, 501 + iload + 6)
            Next
            If StPos < 0 Then StPos = 0
            If StcPos < 0 Then StcPos = 0
            If StNeg > 0 Then StNeg = 0
            If StcNeg > 0 Then StcNeg = 0
            .Zp(iCond + Offset, 201) = StPos
            .Zp(iCond + Offset, 202) = StcPos
            .Zp(iCond + Offset, 203) = StNeg
            .Zp(iCond + Offset, 204) = StcNeg
            .Zp(iCond + Offset, 492) = StPos1
            .Zp(iCond + Offset, 493) = StcPos1
            .Zp(iCond + Offset, 494) = StPos2
            .Zp(iCond + Offset, 495) = StcPos2
            OK = StPos2 <= .Zp(iCond + Offset, 497) And StcPos2 <= .Zp(iCond + Offset, 497) And StPos1 <= .Zp(iCond + Offset, 496) And StcPos1 <= .Zp(iCond + Offset, 496)
            junctionOK(1, iCond + Offset) = OK
            If ptTipoAA > 99 Then Exit Sub
            ElasPlas = ElasPlas Or OK And (StPos1 > 1.5 * SS Or StcPos1 > 1.5 * SS) And .Zp(iCond + Offset, 496) = .Zp(iCond + Offset, 497)
            ElasPlas = ElasPlas Or Not OK And (Math.Max(StPos1, StPos2) <= .Zp(iCond + Offset, 497) And Math.Max(StcPos1, StcPos2) <= .Zp(iCond + Offset, 497)) And .Zp(iCond + Offset, 496) < .Zp(iCond + Offset, 497)
            If ElasPlas Then
                .Zp(iCond + Offset, 496) = .Zp(iCond + Offset, 497)
                junctionOK(1, iCond + Offset) = 1
            End If
            Escorr = ES
            For Corroso = 0 To 1
                For iload = 1 To 3
                    If ElasPlas Then
                        facts = 1.4 - 0.4 * Math.Abs(.Zp(iCond + Offset, 567 + iload - 1 + 7 * Corroso)) / SSS
                        If facts >= 1 Then
                            facts = 1
                            'ElasPlas = False
                        Else
                            'Escorr = ES * facts
                            retcods = 1
                        End If
                    Else
                        facts = 1
                    End If
                    .Zp(iCond + Offset, 539 + iload - 1 + 7 * Corroso) = facts
                    If ES * facts < Escorr And iload < 4 Then Escorr = ES * facts
                Next iload
            Next Corroso
            If retcods = 0 And ElasPlas Then junctionOK(1, iCond + Offset) = 2
            .Zp(iCond + Offset, 581) = Escorr
            'If Abs(Esvec - Escorr) / Escorr < 100 * TOLER Then retcods = 0
            Esvec = Escorr
            Exit Sub
ExSub:
            For Corroso = 0 To 1
                For iload = 1 To 7
                    .Zp(iCond + Offset, 501 + iload - 1 + 7 * Corroso) = 0
                    .Zp(iCond + Offset, 187 + iload - 1 + 7 * Corroso) = 0
                    .Zp(iCond + Offset, 567 + iload - 1 + 7 * Corroso) = 0
                Next iload
            Next Corroso
            For iload = 492 To 497
                .Zp(iCond + Offset, iload) = 0
            Next
        End With
    End Sub
    Public Sub AA2410(ByRef iCond As Short, ByRef Offset As Short)
        Dim it, iload, ish, ig As Short
        Dim StNeg, StPos, StcPos, StcNeg As Single
        Dim Corroso As Short
        Dim Omega As Single
        Dim StPos1, StcPos1 As Single
        Dim StPos2, StcPos2 As Single
        Dim jj As Short
        Dim OK As Boolean
        Dim iii As Short
        Static Ecvec As Single
        junctionOK(2, iCond + Offset) = True
        ElasPlas = False
        With CType(Padre.Piastra, wn_FTC)
            Select Case ptTipoAA
                Case 0 To 4 : GoTo ExSub
                Case 6 To 99 : GoTo ExSub
                Case 101 To 106
                    If .GetPiastra = 2 Then
                        Select Case .Flottante
                            Case 2, 3, 5 : GoTo ExSub
                        End Select
                    Else
                        Select Case ptTipoAA
                            Case 102 To 104 : GoTo ExSub
                        End Select
                    End If
            End Select
            For Corroso = 0 To 1
                For iload = 1 To 7
                    If NonTermici() And iload > 3 Then
                        Sigmac = 0
                        sigmacvm = 0
                        sigmacvb = 0
                    Else
                        Select Case iload
                            Case 1 : ish = 0 : it = 1 : ig = 0
                            Case 2 : ish = 1 : it = 0 : ig = 0
                            Case 3 : ish = 1 : it = 1 : ig = 0
                            Case 4 : ish = 0 : it = 0 : ig = 1
                            Case 5 : ish = 0 : it = 1 : ig = 1
                            Case 6 : ish = 1 : it = 0 : ig = 1
                            Case 7 : ish = 1 : it = 1 : ig = 1
                        End Select
                        PressEff = .Zp(iCond + Offset, 330 + iload - 1 + 7 * Corroso)
                        Presssd = .Zp(iCond, 1)
                        Presstd = .Zp(iCond, 2)
                        sigmacvm = Presstd * it * ac * ac / (ac + tc) / 2 / tc
                        If ptTipoAA < 99 Then
                            Xa = .Zp(iCond + Offset, 402 + Corroso)
                            QZ2s = .Zp(iCond + Offset, 645 + iload - 1 + 7 * Corroso) 'max 184
                            If A02 > 2 Then
                                sigmacvb = 6 / tc ^ 2 * ktt * (betac * (deltac * Presstd * it + ac ^ 2 / Ec / tc * Presscs * ig) - 6 * (1 - nistar ^ 2) / EstarE / E * A0 ^ 3 / hb ^ 3 * (1 + hb * betac / 2) * QZ2s)
                            ElseIf A02 = 2 Then
                                sigmacvb = 6 / tc ^ 2 * ktt * (betac * ac ^ 2 / Ec / tc * ((1 - nic / 2) * Presstd * it + Presscs * ig) - 6 * (1 - nistar ^ 2) / EstarE / E * A0 ^ 3 / hb ^ 3 * (1 + hb * betac / 2) * QZ2s)
                            Else
                                sigmacvb = -12 * (1 + betac * hb / 2) * Ec / E * betac * tc / eta * A0 ^ 3 / hb ^ 3 / Xa ^ 4 * PressEff * QZ2s + 1 / (1 - nit ^ 2) * (Presstd * it * (1 - nit / 2) + Presscs * ig) * betac ^ 2 * ac ^ 2
                            End If
                        Else
                            QZ2s = .Zp(iCond + Offset, 645 + iload - 1 + 7 * Corroso) 'max 184
                            If A02 > 2 Then
                                sigmacvb = 6 / tc ^ 2 * ktt * (betac * (deltac * Presstd * it + ac ^ 2 / Ec / tc * Presscs * ig) - 6 * (1 - nistar ^ 2) / EstarE / E * A0 ^ 3 / hb ^ 3 * (1 + hb * betac / 2) * QZ2s)
                            ElseIf A02 = 2 Then
                                sigmacvb = 6 / tc ^ 2 * ktt * (betac * ac ^ 2 / Ec / tc * ((1 - nic / 2) * Presstd * it + Presscs * ig) - 6 * (1 - nistar ^ 2) / EstarE / E * A0 ^ 3 / hb ^ 3 * (1 + hb * betac / 2) * QZ2s)
                            Else
                                calcZv = .Zp(iCond + Offset, 406 + Corroso)
                                calcZm = .Zp(iCond + Offset, 408 + Corroso)
                                q1 = .Zp(iCond + Offset, 414 + Corroso)
                                q2 = .Zp(iCond + Offset, 171 + iload - 1 + 7 * Corroso) * NIUT
                                sigmacvb = -12 * (1 + betac * hb / 2) * Ec / E * betac * tc / eta * A0 ^ 3 / hb ^ 3 / 2 * (PressEff * (calcZv + calcZm * q1) + 2 * q2 * calcZm / A0 ^ 2) + 1 / (1 - nit ^ 2) * (Presstd * it * (1 - nit / 2) + Presscs * ig) * betac ^ 2 * ac ^ 2
                            End If
                        End If
                        Sigmac = System.Math.Abs(sigmacvm) + System.Math.Abs(sigmacvb)
                    End If
                    .Zp(iCond + Offset, 344 + iload - 1 + 7 * Corroso) = sigmacvm  'max 357
                    .Zp(iCond + Offset, 358 + iload - 1 + 7 * Corroso) = Sigmac
                    .Zp(iCond + Offset, 515 + iload - 1 + 7 * Corroso) = sigmacvb  'max 200
                Next iload
            Next Corroso
            StPos = -clsTrigon.Infinito : StcPos = -clsTrigon.Infinito
            StNeg = clsTrigon.Infinito : StcNeg = clsTrigon.Infinito
            StPos1 = 0 : StcPos1 = 0
            StPos2 = 0 : StcPos2 = 0
            For iload = 1 To 7
                Omega = 1 : If iload < 4 Then Omega = 2
                If .Zp(iCond + Offset, 358 + iload - 1) * Omega > StPos Then StPos = .Zp(iCond + Offset, 358 + iload - 1) * Omega
                If .Zp(iCond + Offset, 358 + iload + 6) * Omega > StcPos Then StcPos = .Zp(iCond + Offset, 358 + iload + 6) * Omega
                If iload < 4 Then
                    If .Zp(iCond + Offset, 358 + iload - 1) > StPos1 Then StPos1 = .Zp(iCond + Offset, 358 + iload - 1)
                    If .Zp(iCond + Offset, 358 + iload + 6) > StcPos1 Then StcPos1 = .Zp(iCond + Offset, 358 + iload + 6)
                Else
                    If .Zp(iCond + Offset, 358 + iload - 1) > StPos2 Then StPos2 = .Zp(iCond + Offset, 358 + iload - 1)
                    If .Zp(iCond + Offset, 358 + iload + 6) > StcPos2 Then StcPos2 = .Zp(iCond + Offset, 358 + iload + 6)
                End If
                If .Zp(iCond + Offset, 344 + iload - 1) < StNeg Then StNeg = .Zp(iCond + Offset, 344 + iload - 1)
                If .Zp(iCond + Offset, 344 + iload + 6) < StcNeg Then StcNeg = .Zp(iCond + Offset, 344 + iload + 6)
            Next
            If StPos < 0 Then StPos = 0
            If StcPos < 0 Then StcPos = 0
            If StNeg > 0 Then StNeg = 0
            If StcNeg > 0 Then StcNeg = 0
            .Zp(iCond + Offset, 372) = StPos
            .Zp(iCond + Offset, 373) = StcPos
            .Zp(iCond + Offset, 374) = StNeg
            .Zp(iCond + Offset, 375) = StcNeg
            .Zp(iCond + Offset, 529) = StPos1
            .Zp(iCond + Offset, 530) = StcPos1
            .Zp(iCond + Offset, 531) = StPos2
            .Zp(iCond + Offset, 532) = StcPos2
            .Zp(iCond + Offset, 533) = Sc * 1.5
            If .Rear = 2 Then
                If A02 = 0 Then
                    .Zp(iCond + Offset, 534) = Sc * 3
                Else
                    If .Flottante = 1 Or .Flottante = 4 Then
                        jj = Involucr(kLato, jInvolucr).IndAccopp2(3)
                        Indmat = 0
                        If jj > 0 Then
                            Select Case .Flottante
                                Case 1 : iii = 2
                                Case Else : iii = 3
                            End Select
                            Indmat = Involucr(iii, jj).indice(1 - 1)
                            Involucr(kLato, jInvolucr).indice(5) = Indmat
                        Else
                            Indmat = Involucr(kLato, jInvolucr).indice(5)
                        End If
                        If Indmat > 0 Then
                            .Zp(iCond + Offset, 534) = Matdim(Indmat).SPS(CodiceStress, .Zp(iCond + Offset, 5))
                        Else
                            MessageBox.Show("Il materiale della cassa del fondo flottante non è definito")
                        End If
                    End If
                End If
            End If
            OK = StPos2 <= .Zp(iCond + Offset, 534) And StcPos2 <= .Zp(iCond + Offset, 534) And StPos1 <= .Zp(iCond + Offset, 533) And StcPos1 <= .Zp(iCond + Offset, 533)
            junctionOK(2, iCond + Offset) = OK
            If ptTipoAA > 99 Then Exit Sub
            ElasPlas = ElasPlas Or OK And (StPos1 > 1.5 * Sc Or StcPos1 > 1.5 * Sc) And .Zp(iCond + Offset, 533) = .Zp(iCond + Offset, 534)
            ElasPlas = ElasPlas Or Not OK And (StPos1 <= .Zp(iCond + Offset, 534) And StcPos1 <= .Zp(iCond + Offset, 534)) And .Zp(iCond + Offset, 533) < .Zp(iCond + Offset, 534)
            If ElasPlas Then
                .Zp(iCond + Offset, 533) = .Zp(iCond + Offset, 534)
                junctionOK(2, iCond + Offset) = 1
            End If
            Eccorr = Ec
            For Corroso = 0 To 1
                For iload = 1 To 3
                    If ElasPlas Then
                        factc = 1.4 - 0.4 * System.Math.Abs(.Zp(iCond + Offset, 515 + iload - 1 + 7 * Corroso)) / Scs
                        If factc >= 1 Then
                            factc = 1
                            'ElasPlas = False
                        Else
                            'Escorr = ES * facts
                            retcodc = 1
                        End If
                    Else
                        factc = 1
                    End If
                    .Zp(iCond + Offset, 553 + iload - 1 + 7 * Corroso) = factc
                    If Ec * factc < Eccorr And iload < 4 Then Eccorr = Ec * factc
                Next iload
            Next Corroso
            If retcodc = 0 And ElasPlas Then junctionOK(2, iCond + Offset) = 2
            .Zp(iCond + Offset, 582) = Eccorr
            'If Abs(Ecvec - Eccorr) / Eccorr < 100 * TOLER Then retcodc = 0
            Ecvec = Eccorr
            Exit Sub
ExSub:
            For Corroso = 0 To 1
                For iload = 1 To 7
                    .Zp(iCond + Offset, 344 + iload - 1 + 7 * Corroso) = 0
                    .Zp(iCond + Offset, 358 + iload - 1 + 7 * Corroso) = 0
                    .Zp(iCond + Offset, 515 + iload - 1 + 7 * Corroso) = 0
                Next iload
            Next Corroso
            For iload = 529 To 534
                .Zp(iCond + Offset, iload) = 0
            Next
        End With
    End Sub
    Private Sub CorrCod(ByRef cscodS As Single, ByRef ctcodS As Single, ByRef cscodF As Single, ByRef ctcodF As Single)
        Dim j As Short
        Dim PiastraCoda As Boolean
        cscodS = cs : ctcodS = CT : cscodF = cs : ctcodF = CT
        If Padre.TipoPT = 1 Then
            PiastraCoda = False
        Else
            PiastraCoda = CType(Padre.Piastra, wn_FTC).Offset > 0
        End If
        If Not PiastraCoda Then
            j = Involucr(kLato, jInvolucr).IndAccopp(3)
            If j > 0 Then
                ctcodS = Involucr(2, j).cs
                If Involucr(2, j).OS > ctcodS Then ctcodS = Involucr(2, j).OS
            End If
            j = Involucr(kLato, jInvolucr).IndAccopp(4)
            If j > 0 Then
                cscodS = Involucr(1, j).cs
                If Involucr(1, j).OS > cscodS Then cscodS = Involucr(1, j).OS
            End If
            j = Involucr(kLato, jInvolucr).IndAccopp(1)
            If j > 0 Then
                ctcodF = Involucr(2, j).cs
                If Involucr(2, j).OS > ctcodS Then ctcodS = Involucr(2, j).OS
            End If
            j = Involucr(kLato, jInvolucr).IndAccopp(2)
            If j > 0 Then
                cscodF = Involucr(1, j).cs
                If Involucr(1, j).OS > cscodF Then cscodF = Involucr(1, j).OS
            End If
        Else
            j = Involucr(kLato, jInvolucr).IndAccopp2(3)
            If j > 0 Then
                ctcodS = Involucr(2, j).cs
                If Involucr(2, j).OS > ctcodS Then ctcodS = Involucr(2, j).OS
            End If
            j = Involucr(kLato, jInvolucr).IndAccopp2(4)
            If j > 0 Then
                cscodS = Involucr(1, j).cs
                If Involucr(1, j).OS > cscodS Then cscodS = Involucr(1, j).OS
            End If
            j = Involucr(kLato, jInvolucr).IndAccopp2(1)
            If j > 0 Then
                ctcodF = Involucr(2, j).cs
                If Involucr(2, j).OS > ctcodS Then ctcodS = Involucr(2, j).OS
            End If
            j = Involucr(kLato, jInvolucr).IndAccopp2(2)
            If j > 0 Then
                cscodF = Involucr(1, j).cs
                If Involucr(1, j).OS > cscodF Then cscodF = Involucr(1, j).OS
            End If
        End If
    End Sub
    Public Function AA15A02(ByRef Tipo As Short, ByRef codice As Short, ByVal ic As Integer) As Boolean
        Dim Res As Boolean
        Dim Presstdv, Presssdv As Single
        Dim iCond, iStart, iEnd As Short
        Dim suphr As Single
        Try
            iStart = 1 : If Problem(Padre.IndProbl).PDIFF = 0 Then iStart = 3
            iEnd = 3
            If ic > 0 Then iStart = ic : iEnd = ic
            AA15A02 = True
            For iCond = iStart To 3
                Select Case iCond
                    Case 2 'pressione lato mantello
                        '   Presssd = Presss
                        Presstdv = Presstd
                        Presstd = 0 : If Padre.VacuumTS Then Presstd = -Config(2).pxExt
                    Case 1 'pressione lato tubi
                        ' Presstd = Presst
                        Presssdv = Presssd
                        Presssd = 0 : If Padre.VacuumSS Then Presssd = -Config(1).pxExt
                    Case 3 ' entrambe
                        ' Presssd = Presss
                        ' Presstd = Presst
                End Select
                Res = Verifiche(Tipo, codice, iCond, False)
                Select Case iCond
                    Case 2 : Presstd = Presstdv
                    Case 1 : Presssd = Presssdv
                End Select
                If hr > suphr Then suphr = hr
                If Not Res Then AA15A02 = False : Exit Function
            Next iCond
            hr = suphr
        Catch e As Exception
            MessageBox.Show(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Function

    Private Function IntegDiam(ByRef Tipo As Short, ByRef St As Boolean) As Boolean
        Dim cscodS, ctcodS As Single
        Dim cscodF, ctcodF As Single
        CorrCod(cscodS, ctcodS, cscodF, ctcodF)
        With Padre
            Ds = .SlShelDati(1) + 2 * cscodS
            DC = .SlChanDati(1) + 2 * ctcodS
            ts = .SlShelDati(2) - cscodS
            tc = .SlChanDati(2) - ctcodS
        End With
        Select Case Tipo
            Case 0 ' tutto bullonato
            Case -1 'tutto saldato
                If Ds * DC * ts * tc <= 0 Or ts < 0 Or tc < 0 Then
                    If Not St Then MessageBox.Show("Non sono stati forniti dati completi relativamente ai collegamenti saldati della piastra tubiera.")
                    Exit Function
                End If
            Case 1 'flangia lato shell
                If Padre.SlChanDati(1) = -2 Then 'caso di piastra avvitata su fondo cassa
                    DC = Padre.TSheDes 'provvisorio
                    tc = 0.001
                End If
                If DC * tc <= 0 Or tc < 0 Then
                    If Not St Then MessageBox.Show("Non sono stati forniti dati completi relativamente al collegamento saldato lato tubi.")
                    Exit Function
                End If
            Case 2
                If Ds * ts <= 0 Or ts < 0 Then
                    If Not St Then MessageBox.Show("Non sono stati forniti dati completi relativamente ai collegamento saldato lato mantello.")
                    Exit Function
                End If
        End Select
        IntegDiam = True
    End Function
    Private Function FlangedDati(ByRef Tipo As Short, ByRef codice As Short) As Boolean
        Dim cscodS, ctcodS As Single
        Dim cscodF, ctcodF As Single
        Dim j, ii As Short
        FlangedDati = True
        CorrCod(cscodS, ctcodS, cscodF, ctcodF)
        With Padre
            c = .BoltCiD(1)
            Select Case Tipo
                Case -1 'tutto saldato
                    DC = .SlChanDati(1) + 2 * ctcodS
                    tc = .SlChanDati(2) - ctcodS
                    j = .IndAccopp(3)
                    If j > 0 Then
                        ii = 2
                        Retrieve(ii, j, codice)
                    Else
                        Indmat = Involucr(kLato, jInvolucr).indice(5 - 1)
                        Retrieve1(codice)
                    End If
                    If EI * Si = 0 Then
                        FlangedDati = False
                        Exit Function
                    End If
                    Sc = Si
                    SPSc = SPS
                    Ec = EI
                    Ds = .SlShelDati(1) + 2 * cscodS
                    ts = .SlShelDati(2) - cscodS
                    j = .IndAccopp(4)
                    If j > 0 Then
                        ii = 1
                        Retrieve(ii, j, codice)
                    Else
                        Indmat = Involucr(kLato, jInvolucr).indice(4 - 1)
                        Retrieve1(codice)
                    End If
                    If EI * Si = 0 Then
                        FlangedDati = False
                        Exit Function
                    End If
                    SS = Si
                    SPSs = SPS
                    ES = EI
                Case 0 ' tutto bullonato
                    g = .FlShelDati(19)
                    GS = g
                    wm1 = .FlShelDati(15)
                    wm2 = .FlShelDati(16)
                    wot = .FlShelDati(21)
                    Ws = wm1
                    If wm2 > Ws Then Ws = wm2
                    If wot > Ws Then Ws = wot
                    g = .FlChanDati(19)
                    GC = g
                    wm1 = .FlChanDati(15)
                    wm2 = .FlChanDati(16)
                    wot = .FlChanDati(21)
                    Wc = wm1
                    If wm2 > Wc Then Wc = wm2
                    If wot > Wc Then Wc = wot
                Case 1 'flangia lato shell
                    di = .SlChanDati(1) + 2 * ctcodS
                    tI = .SlChanDati(2) - ctcodS
                    tc = tI
                    g = .FlShelDati(19)
                    If g = 0 Then g = .FlShelDati(5)
                    GS = g
                    If .SlChanDati(1) = -2 Then DC = GS '030506
                    wm1 = .FlShelDati(15)
                    wm2 = .FlShelDati(16)
                    wot = .FlShelDati(21)
                    Ws = wm1
                    If wm2 > Ws Then Ws = wm2
                    If wot > Ws Then Ws = wot
                    PressI = Presstd
                    Pressg = Presssd
                    j = .IndAccopp(3)
                    If j > 0 Then
                        ii = 2
                        Retrieve(ii, j, codice)
                    Else
                        Indmat = Involucr(kLato, jInvolucr).indice(5 - 1)
                        If Indmat > 0 Then Retrieve1(codice)
                    End If
                    If EI * Si = 0 Then
                        FlangedDati = .SlChanDati(1) = -2
                        Exit Function
                    End If
                    Sc = Si
                    SPSc = SPS
                    Ec = EI
                Case 2 'flangia lato channel
                    di = .SlShelDati(1) + 2 * cscodS
                    tI = .SlShelDati(2) - cscodS
                    ts = tI
                    g = .FlChanDati(19)
                    GC = g
                    wm1 = .FlChanDati(15)
                    wm2 = .FlChanDati(16)
                    wot = .FlChanDati(21)
                    Wc = wm1
                    If wm2 > Wc Then Wc = wm2
                    If wot > Wc Then Wc = wot
                    PressI = Presssd
                    Pressg = Presstd
                    j = .IndAccopp(4)
                    If j > 0 Then
                        ii = 1
                        Retrieve(ii, j, codice)
                    Else
                        Indmat = Involucr(kLato, jInvolucr).indice(4 - 1)
                        Retrieve1(codice)
                    End If
                    If EI * Si = 0 Then
                        FlangedDati = False
                        Exit Function
                    End If
                    SS = Si
                    SPSs = SPS
                    ES = EI
            End Select
        End With
    End Function
    Private Sub Retrieve1(ByVal codice As Short)
        Matdim(Indmat).SigmaAmm(CodiceStress, TempDes, Sfa, Sfo)
        Select Case codice
            Case 1, 2
                Si = Sfo '* mpa
                EI = Matdim(Indmat).EmodAlt(Destemp)
                If codice = 1 And A02 > 0 Then SPS = Matdim(Indmat).SPS(CodiceStress, Destemp)
            Case 3, 4
                Si = Sfa '* mpa
                EI = Matdim(Indmat).EmodAlt(20)
        End Select
    End Sub
    Private Sub Retrieve(ByVal ii As Short, ByVal j As Short, ByVal codice As Short)
        Indmat = Involucr(ii, j).indice(1 - 1)
        Select Case codice
            Case 1, 2
                Si = Involucr(ii, j).St '* mpa
                EI = Matdim(Indmat).EmodAlt(Destemp)
                If codice = 1 And A02 > 0 Then SPS = Matdim(Indmat).SPS(CodiceStress, Destemp)
            Case 3, 4
                Si = Involucr(ii, j).S0 '* mpa
                EI = Matdim(Indmat).EmodAlt(20)
        End Select
    End Sub
    Private Sub StampAA1(ByRef Tipo As Short, ByRef codice As Short)
        Dim Cod As String
        Dim iCond, iStart As Short
        Dim StriSt(10) As String
        Dim ifl, i As Short
        Dim Res As Boolean
        Dim Tit As String = ""
        Dim File As String = ""
        Dim Presstdv, Presssdv As Single
        If A02 < 2 Then
            Tit = "P.T. App.AA-1"
        Else
            Tit = "P.T. UHX-12"
        End If
        If Not PrepRapp(Template, Tit, Involucr(kLato, jInvolucr).Mark.Trim + " (" + Tit.Substring(5) + ")", FileSt, mioApert.lstRapp) Then Exit Sub
        Cod = Space(5)
        Call testaU(Cod, 7, 3)
        Call printa()
        iStart = 1 : If Problem(Padre.IndProbl).PDIFF = 0 Then iStart = 3
        ifl = FreeFile()
        Select Case A02
            Case 1 : File = "\RTF\STAMAA1402.TXT"
            Case Else : File = "\RTF\STAMUHX124.TXT"
        End Select
        If Not OpenFile(RTrim(Monitor.Motore.Inizio.Archdir) & File, ifl) Then Exit Sub
        For i = 1 To 6
            StriSt(i) = LineInput(ifl)
        Next
        FileClose(ifl)
        With Monitor.Motore.Problem
            For iCond = iStart To 3
                .Printa("\page ")
                .Printa(StriSt(1))
                .Printa(StriSt(iCond + 1))
                Select Case iCond
                    Case 2 'pressione lato mantello
                        'Presssd = Presss
                        Presstdv = Presstd
                        Presstd = 0 : If Padre.VacuumTS Then Presstd = -Config(2).pxExt
                    Case 1 'pressione lato tubi
                        'Presstd = Presst
                        Presssdv = Presssd
                        Presssd = 0 : If Padre.VacuumSS Then Presssd = -Config(1).pxExt
                    Case 3 ' entrambe
                        ' Presssd = Presss
                        ' Presstd = Presst
                End Select
                .Printa(GlobalRoutines.FormatS(StriSt(5), Presssd, Presssd * psi))
                .Printa(GlobalRoutines.FormatS(StriSt(6), Presstd, Presstd * psi))
                Res = Verifiche(Tipo, codice, iCond, True)
                iGia = False
                If Res Then
                    printAA13(1)
                    printAA15302()
                    printAA15402()
                    printAA15502()
                    printAA15802()
                    printAA15902()
                End If
                Select Case iCond
                    Case 2 : Presstd = Presstdv
                    Case 1 : Presssd = Presssdv
                End Select
            Next iCond
        End With
    End Sub
    Public Sub printAA15502()
        Dim ifl As Short
        Dim TIMA As String = ""
        Dim File As String = ""
        Dim Tit As String = ""
        Dim Affix As String = ""
        ifl = FreeFile()
        Affix = ".TXT"
        Select Case A02
            Case 1 : Tit = "AA-1"
            Case 2 : Tit = "UHX.12"
            Case Else : Tit = "UHX.12"
                Affix = "1.TXT"
        End Select
        Select Case ptTipoAA
            Case 0, 1 : File = "\RTF\STAMAA155d" & Affix
            Case 2 : File = "\RTF\STAMAA155a" & Affix
            Case 3 : File = "\RTF\STAMAA155e" & Affix
            Case 30 : File = "\RTF\STAMAA155f" & Affix
            Case 4 : File = "\RTF\STAMAA155b" & Affix
            Case 40 : File = "\RTF\STAMAA155c" & Affix
        End Select
        If Not OpenFile(RTrim(Monitor.Motore.Inizio.Archdir) & File, ifl) Then Exit Sub
        With Monitor.Motore.Problem
            Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, Tit))
            Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, k, k))
            Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, f, f))
            Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, Tit))
            Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, Mstar, Mstar / NIUT))
            Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, Tit))
            Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, Mp, Mp / NIUT))
            Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, m0, m0 / NIUT))
            Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, m1, m1 / NIUT))
        End With
        Call Assumi(ifl, TIMA) : FileClose(ifl)
    End Sub
    Public Sub printAA15402()
        ifl = FreeFile()
        Affix = ".TXT"
        Select Case A02
            Case 1 : Tit = "AA-1.5.4 Step 4"
            Case 2 : Tit = "UHX-12.5.4 Step 4"
            Case Else : Tit = "UHX-12.5.4 Step 4"
                Affix = "1.TXT"
        End Select
        Select Case ptTipoAA
            Case 0, 1
            Case 2
                IntegS()
                IntegC()
            Case 3, 30
                IntegC()
            Case 4, 40
                IntegS()
        End Select
    End Sub
    Private Sub IntegC()
        If Not OpenFile(RTrim(Monitor.Motore.Inizio.Archdir) & "\RTF\STAMAA154c" & Affix, ifl) Then Exit Sub
        With Monitor.Motore.Problem
            Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, Tit))
            Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, betac, betac * inc))
            Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, ktt, ktt / NIUT))
            Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, lambdac, lambdac / mpa))
            If A02 < 3 Then
                Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, Pcprim, Pcprim / inc))
                Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, Mpc, Mpc / NIUT))
            Else
                Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, deltac, deltac / inc * mpa))
                Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, omegac, omegac / inc / inc))
            End If
        End With
        Call Assumi(ifl, TIMA) : FileClose(ifl)
    End Sub
    Private Sub IntegS()
        If Not OpenFile(RTrim(Monitor.Motore.Inizio.Archdir) & "\RTF\STAMAA154s" & Affix, ifl) Then Exit Sub
        With Monitor.Motore.Problem
            Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, Tit))
            Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, betas, betas * inc))
            Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, kss, kss / NIUT))
            Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, lambdas, lambdas / mpa))
            If A02 < 3 Then
                Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, Psprim, Psprim / inc))
                Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, Mps, Mps / NIUT))
            Else
                Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, deltas, deltas / inc * mpa))
                Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, omegas, omegas / inc / inc))
            End If
        End With
        Call Assumi(ifl, TIMA) : FileClose(ifl)
    End Sub
    Public Sub printAA15302()
        Dim ifl As Short
        Dim strs As String = ""
        Dim TIMA As String = ""
        Dim strc As String = ""
        Dim File As String = ""
        ifl = FreeFile()
        Select Case A02
            Case 1 : File = "\RTF\STAA015302.TXT"
            Case Else : File = "\RTF\STUHX1252.TXT"
        End Select
        If Not OpenFile(RTrim(Monitor.Motore.Inizio.Archdir) & File, ifl) Then Exit Sub
        Select Case ptTipoAA
            Case 0, 1 : strs = "G" : strc = "G"
            Case 2 : strs = "D" : strc = "D"
            Case 3, 30 : strs = "G" : strc = "D"
            Case 4, 40 : strs = "D" : strc = "G"
        End Select
        Dim prob As RoutBase1.clsProblem = Monitor.Motore.Problem
        With Padre.Piastra
            Call Assumi(ifl, TIMA) : prob.Printa(GlobalRoutines.FormatS(TIMA, rhos))
            Call Assumi(ifl, TIMA) : prob.Printa(GlobalRoutines.FormatS(TIMA, strs))
            Call Assumi(ifl, TIMA) : prob.Printa(GlobalRoutines.FormatS(TIMA, rhoc))
            Call Assumi(ifl, TIMA)
            If Padre.SlChanDati(1) > -1 Then
                prob.Printa(GlobalRoutines.FormatS(TIMA, strc))
            Else
                prob.Printa("assumed equal to {{\field{\*\fldinst SYMBOL 114 \\f"" Symbol ""\\s 12}{\fldrslt\f3\fs24}}}{\sub s}\par ")
            End If
            Call Assumi(ifl, TIMA) : FileClose(ifl)
            If Not OpenFile(RTrim(Monitor.Motore.Inizio.Archdir) & "\RTF\StamAA15303.TXT", ifl) Then Exit Sub
            Call Assumi(ifl, TIMA) : prob.Printa(GlobalRoutines.FormatS(TIMA, MTS, MTS / NIUT))
            Call Assumi(ifl, TIMA) : FileClose(ifl)
        End With
    End Sub
    Public Sub printAA15802()
        Dim ifl As Short
        Dim strs As String = ""
        Dim TIMA As String = ""
        Dim Tit As String = ""
        Dim fact As Single
        ifl = FreeFile()
        Select Case A02
            Case 1 : Tit = "AA-1"
                fact = 1.5
            Case Else : Tit = "UHX.12"
                fact = 2
        End Select
        If Not OpenFile(RTrim(Monitor.Motore.Inizio.Archdir) & "\RTF\STAMAA158.TXT", ifl) Then Exit Sub
        With Monitor.Motore.Problem
            Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, Tit))
            Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, hgprim, hgprim / inc))
            Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, Sigma, Sigma * psi))
            Call Assumi(ifl, TIMA)
            '??????? S era Si
            If Sigma <= fact * s Then .Printa(GlobalRoutines.FormatS(TIMA, fact, fact * s, fact * s * psi))
            Call Assumi(ifl, TIMA)
            If Sigma > fact * s Then .Printa(GlobalRoutines.FormatS(TIMA, fact, fact * s, fact * s * psi))
            Call Assumi(ifl, TIMA) : FileClose(ifl)
            If A02 >= 2 Then
                fact = 0.8
                If Not OpenFile(RTrim(Monitor.Motore.Inizio.Archdir) & "\RTF\STAMUHX1259.TXT", ifl) Then Exit Sub
                Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, Tit))
                Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, Tau, Tau * psi))
                Call Assumi(ifl, TIMA)
                If Tau <= fact * s Then .Printa(GlobalRoutines.FormatS(TIMA, fact * s, fact * s * psi))
                Call Assumi(ifl, TIMA)
                If Tau > fact * s Then .Printa(GlobalRoutines.FormatS(TIMA, fact * s, fact * s * psi))
                Call Assumi(ifl, TIMA) : FileClose(ifl)
            End If
        End With
    End Sub
    Public Sub printAA15902()
        Dim Tit As String
        Affix = ".TXT"
        Try
            With Padre.Piastra
                Select Case A02
                    Case 1 : Tit = "AA-1.5.9 Step 9"
                    Case Else
                        If A02 >= 3 Then Affix = "1.TXT"
                        Select Case .Rear
                            Case 1 'fisse
                                Tit = "UHX.13"
                            Case 2 'flottanti
                                Tit = "UHX.14"
                            Case 3 'U
                                If Padre.SlChanDati(1) = -2 Then Exit Sub
                                Tit = "UHX.12.5.10 Step 10"
                        End Select
                        ifl = FreeFile()
                        If .GetPiastra = 1 Then
                            Select Case ptTipoAA
                                Case 0, 1, 104 : Exit Sub
                                Case 2, 5, 101
                                    Latos()
                                    Latoc()
                                Case 3, 30, 105, 106
                                    Latoc()
                                Case 4, 40, 6, 7, 102, 103
                                    Latos()
                            End Select
                        Else
                            If .Flottante = 1 Or .Flottante = 4 Then Latoc()
                        End If
                End Select
            End With
        Catch e As Exception
            MessageBox.Show(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Private Sub Latoc()
        File = "\RTF\STAMAA159c" & Affix '030506
        If Not OpenFile(RTrim(Monitor.Motore.Inizio.Archdir) & File, ifl) Then Exit Sub
        With Monitor.Motore.Problem
            Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, Tit))
            Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, tc))
            Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, 1.8 * System.Math.Sqrt(DC * tc)))
            Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, sigmacvm, sigmacvm * psi))
            Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, sigmacvb, sigmacvb * psi))
            Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, Sigmac, Sigmac * psi))
            Call Assumi(ifl, TIMA1) : Call Assumi(ifl, TIMA2) : Call Assumi(ifl, TIMA)
            If Sigmac <= 1.5 * Sc Then
                .Printa(TIMA1) : .Printa(TIMA2)
                .Printa(GlobalRoutines.FormatS(TIMA, 1.5 * Sc, 1.5 * Sc * psi))
            End If
            Call Assumi(ifl, TIMA1) : Call Assumi(ifl, TIMA2) : Call Assumi(ifl, TIMA)
            If sigmas > SPSc Then
                .Printa(TIMA1) : .Printa(TIMA2)
                .Printa(GlobalRoutines.FormatS(TIMA, SPSc, SPSc * psi))
            End If
            Call Assumi(ifl, TIMA1) : Call Assumi(ifl, TIMA2)
            Call Assumi(ifl, TIMA3) : Call Assumi(ifl, TIMA)
            FileClose(ifl)
            If sigmas <= SPSc And Sigmac > 1.5 * Sc Then
                .Printa(TIMA1) : .Printa(TIMA2)
                .Printa(TIMA3) : .Printa(TIMA)
                printAA1510(2)
            End If
        End With
    End Sub
    Private Sub Latos()
        File = "\RTF\STAMAA159s" & Affix '030506
        If Not OpenFile(RTrim(Monitor.Motore.Inizio.Archdir) & File, ifl) Then Exit Sub
        With Monitor.Motore.Problem
            Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, Tit))
            Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, ts))
            Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, 1.8 * System.Math.Sqrt(Ds * ts)))
            Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, sigmasvm, sigmasvm * psi))
            Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, sigmasvb, sigmasvb * psi))
            Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, sigmas, sigmas * psi))
            Call Assumi(ifl, TIMA1) : Call Assumi(ifl, TIMA2) : Call Assumi(ifl, TIMA)
            If sigmas <= 1.5 * SS Then
                .Printa(TIMA1) : .Printa(TIMA2)
                .Printa(GlobalRoutines.FormatS(TIMA, 1.5 * SS, 1.5 * SS * psi))
            End If
            Call Assumi(ifl, TIMA1) : Call Assumi(ifl, TIMA2) : Call Assumi(ifl, TIMA)
            If sigmas > SPSs Then
                .Printa(TIMA1) : .Printa(TIMA2)
                .Printa(GlobalRoutines.FormatS(TIMA, SPSs, SPSs * psi))
            End If
            Call Assumi(ifl, TIMA1) : Call Assumi(ifl, TIMA2)
            Call Assumi(ifl, TIMA3) : Call Assumi(ifl, TIMA)
            FileClose(ifl)
            If sigmas <= SPSs And sigmas > 1.5 * SS Then
                .Printa(TIMA1) : .Printa(TIMA2)
                .Printa(TIMA3) : .Printa(TIMA)
                printAA1510(1)
            End If
        End With
    End Sub
    Private Function Verifiche(ByRef Tipo As Short, ByRef codice As Short, ByRef iCond As Short, ByRef St As Boolean) As Boolean
        Dim Res As Boolean
        Dim innerloop, outerloop As Short
        Dim Testo As String
        Dim OK As Boolean
        Dim fact As Single
        Dim Num As Short
        Dim fact1, fact2 As Single
        Try
            simplif = False
            SuperLoop = False
            Verifiche = True
            If A02 < 2 Then fact = 1.5 Else fact = 2.0#
            'Step 01
            If A02 < 2 Or Not CalcMAWP Then
                If Not Problem(Padre.IndProbl).PDIFF = 0 Then PressEff = System.Math.Abs(Presssd - Presstd)
                Hsh = PressEff * D0 / 3.2 / migrec / s
                If H > Hsh Then
                    hb = H
                    '                    Verificando = True
                Else
                    hb = Int(Hsh + 0.9)
                    Verificando = False
                End If
                H = hb
            Else
                H = hb 'Verificando = True 280206
            End If
            outerloop = 0
            hr = H - cs - CT
            Do
                'Step 02
                AA13()
                hsup = hr / p
                If hsup > 2 Then hsup = 2
                Calcolastar()
                'Step 03
                If Not simplif Then
                    Res = IntegDiam(Tipo, St)
                    If Not Res Then Verifiche = False : Exit Function
                    Res = FlangedDati(Tipo, codice)
                    If Not Res Then Verifiche = False : Exit Function
                    Select Case ptTipoAA
                        Case 0, 1 : rhos = GS / D0 : rhoc = GC / D0
                        Case 2 : rhos = Ds / D0 : rhoc = DC / D0
                        Case 3, 30 : rhos = GS / D0 : rhoc = DC / D0
                        Case 4, 40 : rhos = Ds / D0 : rhoc = GC / D0
                    End Select
                    Esvec = ES : Ecvec = Ec
                End If
                MTS = D0 ^ 2 / 16 * ((rhos - 1) * (rhos ^ 2 + 1) * Presssd - (rhoc - 1) * (rhoc ^ 2 + 1) * Presstd)
                'Step 04
Step04:         innerloop = 0
                Do
                    Psprim = 0
                    Pcprim = 0
                    Mpc = 0
                    Mps = 0
                    lambdas = 0
                    lambdac = 0
                    Select Case ptTipoAA
                        Case 2 'both integral
                            IntegS1()
                            IntegC1()
                        Case 0, 1 'both flanged
                        Case 3, 30 'integral channel side
                            IntegC1()
                        Case 4, 40 'integral shell side
                            IntegS1()
                    End Select
                    'Step 05
                    a = Padre.TSheDes
                    If D0 <= 0 Or a < D0 Then
                        If Verificando Then
                            Testo = "Il diametro esterno della piastra tubiera e/o l'OTL|non sono stati specificati in modo corretto."
                            If Not St Then MessageBox.Show(Monitor.Motore.Inizio.ConvertiCr(Testo), Titolo, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                        Verifiche = False
                        Exit Function
                    End If
                    k = a / D0
                    f = (1 - nistar) / EstarE * ((lambdas + lambdac) / e + System.Math.Log(k))
                    'step 06
                    Select Case ptTipoAA
                        Case 2 'a
                            Mstar = MTS + Mpc - Mps
                        Case 4 'b
                            Mstar = MTS - Mps - Wc * (c - GC) / 2 / pi / D0
                        Case 40 'c
                            Mstar = MTS - Mps - Wc * (c - GC) / 2 / pi / D0 ' in realtà è G1-GC
                        Case 0, 1 'd
                            W = Ws : If Wc > Ws Then W = Wc
                            Mstar = MTS + W * (GC - GS) / 2 / pi / D0
                            With Padre.Piastra
                                If .BullDistinti Then
                                    If Not St Then MessageBox.Show("TS con estensione e bulloni distinti su due lati non prevista in UHX")
                                    Verifiche = False
                                    Exit Function
                                Else
                                    Num = System.Math.Abs(.NumColl(1))
                                    If VerificandoPI Then
                                        If .NumBolt(1) < Num Or c <= 0 Then
                                            MsgBox("I dati relativi al cerchio bulloni e/o ai bulloni con collare non sono validi")
                                        Else
                                            If .NumColl(1) > 0 Then 'collari serrano la guarnizione lato cassa
                                                Mstar = Mstar - Wc * (c - GC) / 2 / pi / D0 * Num / .NumBolt(1)
                                            Else
                                                Mstar = Mstar + Ws * (c - GS) / 2 / pi / D0 * Num / .NumBolt(1)
                                            End If
                                        End If
                                    End If
                                End If
                            End With
                        Case 3 'e
                            Mstar = MTS + Mpc + Ws * (c - GS) / 2 / pi / D0
                        Case 30 'f
                            Mstar = MTS + Mpc + Ws * (c - GS) / 2 / pi / D0 ' in realtà è G1-GC
                    End Select
                    'Step 07
                    Mp = (Mstar - D0 ^ 2 / 32 * f * (Presssd - Presstd)) / (1 + f)
                    m0 = Mp + D0 ^ 2 / 64 * (3 + nistar) * (Presssd - Presstd)
                    m1 = System.Math.Abs(Mp) : If System.Math.Abs(m0) > m1 Then m1 = System.Math.Abs(m0)
                    'step 08
                    hgprim = 0 : If HG - CT > 0 Then hgprim = HG - CT
                    Sigma = 6 * m1 / mistar / (hr - hgprim) ^ 2
                    If Verificando And SuperLoop Then Exit Do
                    If A02 < 2 Then
                        If Sigma <= 1.5 * s + clsTrigon.TOLER Then Exit Do '???? S era Si
                    Else
                        OK = False
                        If Sigma <= fact * s + clsTrigon.TOLER Then OK = True
                        Tau = (1 / 4 / migrec) * D0 / hr * PressEff
                        If Tau > 0.8 * s + clsTrigon.TOLER Then OK = False
                        'If CalcMAWP Then Exit Do
                    End If
                    If St Then Exit Do
                    If Verificando And Not OK And Not CalcMAWP Then
                        Testo = "Lo spessore di piastra " & Format(H) & " è inadeguato.|"
                        Testo = Testo & "La tensione di flessione " & Format(Sigma, FormMpa) & " Mpa eccede|"
                        If A02 < 2 Then
                            Testo = Testo & "il valore ammissibile 1.5 S = " & Format(1.5 * s, FormMpa) & " nella|"
                        Else
                            Testo = Testo & "il valore ammissibile 2.0 S = " & Format(2.0# * s, FormMpa) & " nella|"
                        End If
                        Testo = Testo & "condizione di carico n°" & Str(iCond)
                        Testo = Testo & ".| Per entrare nella modalità di progettazione porre|"
                        Testo = Testo & "lo spessore assunto pari a zero.|"
                        Testo = Testo & "Vuoi calcolare in nuovo spessore minimo richiesto?"
                        If MessageBox.Show(Monitor.Motore.Inizio.ConvertiCr(Testo), Titolo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                            Verifiche = False
                            Exit Function
                        Else
                            Verificando = False
                        End If
                    Else
                        Verificando = False
                    End If
                    fact1 = (Sigma / fact / s) ^ (0.6 - 0.55 * (innerloop / MaxIter) ^ 0.5)
                    fact2 = (Tau / 0.8 / s) ^ (0.9 - 0.35 * innerloop / MaxIter)
                    If fact1 > fact2 Then
                        H = H * fact1 '280206+ hgprim '???? S era Si
                    Else
                        H = H * fact2 '280206+ 0.1
                    End If
                    If (System.Math.Abs(hr - H + cs + CT) / (H - cs - CT) < clsTrigon.TOLER _
                        Or H < clsTrigon.TOLER) And OK Then Exit Do
                    hr = H - cs - CT
                    innerloop = innerloop + 1
                    If innerloop > MaxIter Then
                        Testo = "Non è stato possibile trovare uno spessore di piastra|"
                        Testo = Testo & "che rendesse accettabile la tensione da momento flet-|"
                        Testo = Testo & "tente in periferia e/o al centro della piastra.|"
                        Testo = Testo & "L'ultimo spessore calcolato è stato " & Format(H) & " mm."
                        MessageBox.Show(Monitor.Motore.Inizio.ConvertiCr(Testo), Titolo, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Exit Do
                    End If
                Loop
                If simplif And Sigma < fact * s + clsTrigon.TOLER Then Exit Do '???? S era Si
                'step 9
                If simplif And Sigma >= fact * s + clsTrigon.TOLER Then
                    Dim Risp As DialogResult
                    If CalcMAWP Then
                        Risp = DialogResult.Yes
                    Else
                        If Not St Then
                            Testo = "Dopo aver eseguito l'analisi elasto-plastica semplificata|"
                            Testo = Testo & "(Option 3) la tensione flettente nella piastra (" & Format(Sigma, Fors) & " MPa)|"
                            If A02 < 2 Then
                                Testo = Testo & "risulta superiore al valore ammissibile 1.5 S=" & Format(1.5 * s, Fors) & " .|"
                            Else
                                Testo = Testo & "risulta superiore al valore ammissibile 2.0 S=" & Format(2.0# * s, Fors) & " .|"
                            End If
                            Testo = Testo & "per lo spessore nominale assunto di " & Format(H, Fors) & " mm.|"
                            Testo = Testo & "E' quindi necessario ricorrere all' Option 1 (aumento spessore|"
                            Testo = Testo & "piastra) o all' Option 2 (aumento spessore codoli saldati).|"
                            Testo = Testo & "Vuoi procedere all' Option 1 in automatico?|"
                            Testo = Testo & "In caso di risposta negativa sarà necessario modificare i dati."
                            Risp = MessageBox.Show(Monitor.Motore.Inizio.ConvertiCr(Testo), Titolo, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                        Else
                            Risp = DialogResult.No
                        End If
                    End If
                    If Risp = DialogResult.Yes Then
                        H = H * (Sigma / fact / s) ^ 0.8 '+ hgprim 030506
                        hr = H - cs - CT
                        simplif = False
                        GoTo Step04
                    Else
                        Verifiche = False
                        Exit Function
                    End If
                End If
                rappS = 0 : rappc = 0
                Select Case ptTipoAA
                    Case 0, 1
                    Case 2
                        Juncts()
                        Junctc()
                    Case 3, 30
                        Junctc()
                    Case 4, 40
                        Juncts()
                End Select
                If rappS <= 1.5 + 0.001 And rappc <= 1.5 + 0.001 Then
                    simplif = False
                    Exit Do
                ElseIf rappS = 0 Then
                    If Not Latoc1(iCond) Then Return False
                ElseIf rappc = 0 Then
                    If Not Latos1(iCond) Then Return False
                Else
                    If rappS > rappc Then
                        If Not Latos1(iCond) Then Return False
                    Else
                        If Not Latoc1(iCond) Then Return False
                    End If
                End If
                If outerloop > 50 Or (St And Not simplif) Then
                    Testo = "Non è stato possibile trovare uno spessore di piastra|"
                    Testo = Testo & "che rendesse accettabile le tensioni da momento flet-|"
                    Testo = Testo & "tente agli incastri del mantello e/o della cassa.|"
                    Testo = Testo & "L'ultimo spessore calcolato è stato " & Format(H) & " mm."
                    If Not St Then MessageBox.Show(Monitor.Motore.Inizio.ConvertiCr(Testo), Titolo, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Do
                End If
                outerloop = outerloop + 1
            Loop
            simplif = False
        Catch e As Exception
            MessageBox.Show(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Function
    Private Sub CompletaMsg(ByVal Testo As String)
        Testo = Testo & ".|Aumentare lo spessore della piastra e/o lo spessore|all'incastro."
        MessageBox.Show(Monitor.Motore.Inizio.ConvertiCr(Testo), Titolo, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
    Private Function Latos1(ByVal iCond As Short) As Boolean
        If sigmas < 1.001 * SPSs Or St Then
            If Not simplif Then
                ES = Esvec * System.Math.Sqrt(1.5 * SS / sigmas)
                simplif = True
                SuperLoop = True
            Else
                simplif = False
                SuperLoop = True
                If Verificando Or St Then GoTo Fermas
                H = H * (rappS / 1.5) ^ 0.25
                hr = H - cs - CT
            End If
            Escorr = ES
        Else 'aumentare hb
            simplif = False
            SuperLoop = True
            If Verificando Or St Then GoTo Fermas
            H = H * (sigmas / 0.999 / SPSs) ^ 0.25
            hr = H - cs - CT
        End If
        Return True
Fermas:
        If Not St Then
            Dim Testo As String = "La tensione all'incastro LM " & Format(sigmas, Fors) & " Mpa eccede|"
            Testo = Testo & "il valore ammissibile SPS = " & Format(SPSs, Fors) & " nella|"
            Testo = Testo & "condizione di carico n°" & Str(iCond)
            CompletaMsg(Testo)
        End If
        Return False
    End Function
    Private Function Latoc1(ByVal iCond As Short) As Boolean
        If Sigmac < 1.001 * SPSc Or St Then
            If Not simplif Then
                Ec = Ecvec * System.Math.Sqrt(1.5 * Sc / Sigmac)
                simplif = True
                SuperLoop = True
            Else
                simplif = False
                SuperLoop = True
                If Verificando Or St Then GoTo Fermac
                H = H * (rappc / 1.5) ^ 0.25
                hr = H - cs - CT
            End If
            Eccorr = Ec
        Else 'aumentare hb
            simplif = False
            SuperLoop = True
            If Verificando Or St Then GoTo Fermac
            H = H * (Sigmac / 0.999 / SPSc) ^ 0.25
            hr = H - cs - CT
        End If
        Return True
Fermac:
        If Not St Then
            Dim Testo As String = "La tensione all'incastro LT " & Format(Sigmac, Fors) & " Mpa eccede|"
            Testo = Testo & "il valore ammissibile SPS = " & Format(SPSc, Fors) & " nella|"
            Testo = Testo & "condizione di carico n°" & Str(iCond)
            CompletaMsg(Testo)
        End If
        Return False
    End Function
    Private Sub Junctc()
        If Padre.SlChanDati(1) = -2 Then Exit Sub '030506
        sigmacvm = DC ^ 2 * Presstd / 4 / tc / (DC + tc)
        If A02 < 3 Then
            sigmacvb = 6 / tc ^ 2 * ktt * (betac * Pcprim - 3 * (1 - nistar) / EstarE / E * D0 / hr ^ 2 * (betac + 2 / hr) * (Mp + D0 ^ 2 / 32 * (Presssd - Presstd)))
        Else
            sigmacvb = 6 / tc ^ 2 * ktt * (betac * deltac * Presstd - 6 * (1 - nistar) / EstarE / E * D0 / hr ^ 3 * (1 + betac * hr / 2) * (Mp + D0 ^ 2 / 32 * (Presssd - Presstd)))
        End If
        Sigmac = System.Math.Abs(sigmacvm) + System.Math.Abs(sigmacvb)
        rappc = Sigmac / Sc
    End Sub
    Private Sub Juncts()
        sigmasvm = Ds ^ 2 * Presssd / 4 / ts / (Ds + ts)
        If A02 < 3 Then
            sigmasvb = 6 / ts ^ 2 * kss * (betas * Psprim + 3 * (1 - nistar) / EstarE / E * D0 / hr ^ 2 * (betas + 2 / hr) * (Mp + D0 ^ 2 / 32 * (Presssd - Presstd)))
        Else
            sigmasvb = 6 / ts ^ 2 * kss * (betas * deltas * Presssd + 6 * (1 - nistar) / EstarE / E * D0 / hr ^ 3 * (1 + betas * hr / 2) * (Mp + D0 ^ 2 / 32 * (Presssd - Presstd)))
        End If
        sigmas = System.Math.Abs(sigmasvm) + System.Math.Abs(sigmasvb)
        rappS = sigmas / SS
    End Sub
    Private Sub IntegC1()
        If Padre.SlChanDati(1) = -2 Then Exit Sub '030506
        betac = (12 * (1 - nic ^ 2)) ^ 0.25 / System.Math.Sqrt((DC + tc) * tc)
        ktt = betac * Ec * tc ^ 3 / 6 / (1 - nic ^ 2)
        lambdac = 6 * DC / hr ^ 3 * ktt * (1 + hr * betac + (hr * betac) ^ 2 / 2)
        If A02 < 3 Then
            Pcprim = (2 - nic) / 8 * DC ^ 2 / Ec / tc * Presstd
            Mpc = rhoc * ktt * betac * (1 + hr * betac) * Pcprim
        Else
            deltac = DC * DC / 4 / Ec / tc * (1 - nic / 2)
            omegac = rhoc * ktt * betac * deltac * (1 + hr * betac)
            Mpc = omegac * Presstd
        End If
    End Sub
    Private Sub IntegS1()
        betas = (12 * (1 - nis ^ 2)) ^ 0.25 / System.Math.Sqrt((Ds + ts) * ts)
        kss = betas * ES * ts ^ 3 / 6 / (1 - nis ^ 2)
        lambdas = 6 * Ds / hr ^ 3 * kss * (1 + hr * betas + (hr * betas) ^ 2 / 2)
        If A02 < 3 Then
            Psprim = (2 - nis) / 8 * Ds ^ 2 / ES / ts * Presssd
            Mps = rhos * kss * betas * (1 + hr * betas) * Psprim
        Else
            deltas = Ds * Ds / 4 / ES / ts * (1 - nis / 2)
            omegas = rhos * kss * betas * deltas * (1 + hr * betas)
            Mps = omegas * Presssd
        End If
    End Sub
    Public Sub printAA1510(ByRef i As Short)
        'i=1 shell, i=2 channel
        Dim File As String = ""
        Dim TIMA As String = ""
        Dim ifl As Short
        Select Case i
            Case 1 : File = "\RTF\STAMAA1510s.TXT"
            Case 2 : File = "\RTF\STAMAA1510c.TXT"
        End Select
        ifl = FreeFile()
        If Not OpenFile(RTrim(Monitor.Motore.Inizio.Archdir) & File, ifl) Then Exit Sub
        With Monitor.Motore.Problem
            Select Case i
                Case 1
                    Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, Esvec, Esvec * psi / 1000.0#))
                    Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, SS, SS * psi))
                    Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, Escorr, Escorr * psi / 1000.0#))
                Case 2
                    Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, Ecvec, Ecvec * psi / 1000.0#))
                    Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, Sc, Sc * psi))
                    Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, Eccorr, Eccorr * psi / 1000.0#))
            End Select
        End With
        Call Assumi(ifl, TIMA) : FileClose(ifl)
    End Sub
    Public Property Verbose() As Boolean
        Get

        End Get
        Set(ByVal Value As Boolean)

        End Set
    End Property

    Public WriteOnly Property UniMis() As Short
        Set(ByVal Value As Short)
        End Set
    End Property
    Public Property ThkAdjacent() As Boolean
        Get
            ThkAdjacent = ts <> tsv1 Or ES <> Esv1
        End Get
        Set(ByVal Value As Boolean)

        End Set
    End Property
    Public Property InizPlas() As Boolean
        Get

        End Get
        Set(ByVal Value As Boolean)
            ElasPlas = Value
            Esvec = 0 : Ecvec = 0
        End Set
    End Property


    Public Property ContaPagAgg() As Short
        Get
            ContaPagAgg = prContaPagAgg
        End Get
        Set(ByVal Value As Short)
            prContaPagAgg = Value
        End Set
    End Property
    Public Sub StampaFl(ByRef iCond As Short, ByRef Offset As Short)
        Dim Cod, Tit As String
        Dim Tipo As Short
        Dim Strin(1) As String
        Dim FilePTF, Apice As String
        Dim ifl, i As Short
        Dim Stringa3(2) As String : Stringa3(1) = " NO" : Stringa3(2) = "YES" : Stringa3(0) = " NN"
        Dim Stringa5(3) As String
        Dim Stringa4(3) As String
        Dim Stringa6(9) As String
        Dim Stringa7(6) As String
        Dim Nome As String
        Stringa5(1) = "Fixed TubeSheets" : Stringa5(2) = "Floating head" : Stringa5(3) = "U-tube without extension"
        Stringa4(0) = "Flanged channel-side"
        Stringa4(1) = "Integral both sides"
        Stringa4(2) = "Flanged shell-side"
        Stringa4(3) = "Flanged both sides"
        '   Stringa7$(4) = "Ligth expanded"
        '   Stringa7$(1) = "Expanded with >=2 grooves"
        '   Stringa7$(2) = "Expanded with 1 groove"
        '   Stringa7$(3) = "Strongly expanded without grooves"
        ifl = FreeFile()
        Nome = RTrim(Monitor.Motore.Inizio.Archdir) & "\GIUNTO.DAT"
        If Not OpenFile(Nome, ifl) Then Exit Sub
        For i = 1 To 9 : Stringa6(i) = LineInput(ifl) : Next
        For i = 1 To 4 : Stringa7(i) = LineInput(ifl) : Next
        FileClose(ifl)
        '    Stringa6$(1) = "Welded with a>=1.4t"
        '    Stringa6$(2) = "Welded with t<=a<1.4t"
        '    Stringa6$(3) = "Tightening weld"
        '    Stringa6$(4) = "Brazed 100% examined"
        '    Stringa6$(5) = "Brazed <100% examined"
        '    Stringa6$(6) = "Expanded, with >=2 grooves"
        '    Stringa6$(7) = "Expanded, with 1  groove"
        '    Stringa6$(8) = "Expanded, without grooves"
        Strin(0) = ", front"
        Strin(1) = ", rear"
        If A02 < 2 Then
            Tit = "P.T. App.AA-3" & Strin(Offset \ 8)
        Else
            Tit = "P.T. UHX-14" & Strin(Offset \ 8)
        End If
        If Not PrepRapp(Template, Tit, Involucr(kLato, jInvolucr).Mark.Trim & Strin(Offset \ 8) & " (" & Tit.Substring(5) & ")", FileSt, mioApert.lstRapp) Then Exit Sub
        Cod = Space(5)
        Call testaU(Cod, 7, 2, Offset)
        printAA351(Offset)
        With Monitor.Motore.Problem
            .Printa("\par \par \par ")
            .Printa("\f2\fs18                   fully documented printout sh. 2 of 8\par ")
            Call testaU(Cod, 7, 2, Offset)
            printAA352(iCond, Offset)
            .Printa("\par ")
            .Printa("\f2\fs18                   fully documented printout sh. 3 of 8\par ")
            Call testaU(Cod, 7, 2, Offset)
            printAA353(iCond, Offset)
            printAA355(iCond + Offset)
            .Printa("\par \par \par ")
            .Printa("\f2\fs18                   fully documented printout sh. 4 of 8\par ")
            Call testaU(Cod, 7, 2, Offset)
            printAA356(iCond, Offset, Tipo)
            .Printa("\f2\fs18                   fully documented printout sh. 5/6 of 8\par ")
            If Tipo > 7 Then
                .Printa("\f2\fs18\par \par                                  BLANK PAGES \par \par ")
                .Printa("\f2\fs18                   fully documented printout sh. 7/8 of 8\par ")
                Exit Sub
            End If
            If Tipo < 7 Then
                Call testaU(Cod, 7, 2, Offset)
                printAA357(iCond, Offset)
                .Printa("\f2\fs18                   fully documented printout sh. 7 of 8\par ")
                If A02 > 2 Then
                    Apice = "3.FTC"
                ElseIf A02 > 1 Then
                    Apice = "2.FTC"
                Else
                    Apice = ".FTC"
                End If
                FilePTF = "\RTF\FULL08AA" & Apice
                FilePTF = Trim(Monitor.Motore.Inizio.Archdir) & FilePTF
                ifl = FreeFile()
                If Not OpenFile(FilePTF, ifl) Then Exit Sub
                Call Padre.Piastra.LegScr(ifl, False, Stringa3, Stringa4, Stringa5, Stringa6, Stringa7)
                FileClose(ifl)
            Else
                .Printa("\f2\fs18\par \par                                  BLANK PAGES \par \par ")
                .Printa("\f2\fs18                   fully documented printout sh. 7/8 of 8\par ")
            End If
        End With
        ContaPagAgg = 0
        If Tipo < 4 Then
            'Call testaU(Cod, 7, 2, Offset)
            printAA359(1, iCond, Offset)
            'Print #iout, "\f2\fs18                   fully documented printout sh. 7 of 8\par "
        End If
        If Tipo = 1 Or Tipo = 5 Or Tipo = 6 Or Tipo = 7 Then
            'Call testaU(Cod, 7, 2, Offset)
            printAA359(2, iCond, Offset)
            'Print #iout, "\f2\fs18                   fully documented printout sh. 7A of 8\par "
        End If
    End Sub

    Public Sub printAA351(ByRef Offset As Short)
        Dim ifl As Short
        Dim TIMA As String = ""
        Dim Tit As String = ""
        ifl = FreeFile()
        Select Case A02
            Case 1 : Tit = "AA-3"
            Case Else : Tit = "UHX-14"
        End Select
        If Not OpenFile(RTrim(Monitor.Motore.Inizio.Archdir) & "\RTF\STAMAA351.TXT", ifl) Then Exit Sub
        Dim prob As RoutBase1.clsProblem = Monitor.Motore.Problem
        With Padre.Piastra
            Call Assumi(ifl, TIMA) : prob.Printa(GlobalRoutines.FormatS(TIMA, Tit))
            Call Assumi(ifl, TIMA) : prob.Printa(GlobalRoutines.FormatS(TIMA, H))
            Call Assumi(ifl, TIMA) : prob.Printa(GlobalRoutines.FormatS(TIMA, migrec))
            Call Assumi(ifl, TIMA) : prob.Printa(GlobalRoutines.FormatS(TIMA, R0))
            Call Assumi(ifl, TIMA) : prob.Printa(GlobalRoutines.FormatS(TIMA, rho))
            Call Assumi(ifl, TIMA) : prob.Printa(GlobalRoutines.FormatS(TIMA, dstar, dstar / inc))
            Call Assumi(ifl, TIMA) : prob.Printa(GlobalRoutines.FormatS(TIMA, pstar))
            Call Assumi(ifl, TIMA) : prob.Printa(GlobalRoutines.FormatS(TIMA, mistar))
            Call Assumi(ifl, TIMA) : prob.Printa(GlobalRoutines.FormatS(TIMA, A0, A0 / inc))
            Call Assumi(ifl, TIMA)
            prob.Printa(GlobalRoutines.FormatS(TIMA, .Zp(1 + Offset, 385)))
            Call Assumi(ifl, TIMA)
            prob.Printa(GlobalRoutines.FormatS(TIMA, .Zp(1 + Offset, 387)))
            Call Assumi(ifl, TIMA) : prob.Printa(GlobalRoutines.FormatS(TIMA, xt))
            Call Assumi(ifl, TIMA) : prob.Printa(GlobalRoutines.FormatS(TIMA, xs))
            Call Assumi(ifl, TIMA) : FileClose(ifl)
        End With
    End Sub

    Public Sub printAA352(ByRef iCond As Short, ByRef Offset As Short)
        Dim File As String = ""
        Dim ifl, j As Short
        Dim TIMA As String = ""
        Dim Tit As String = ""
        Dim Suffix As String = ""
        ifl = FreeFile()
        Suffix = ".TXT"
        Select Case A02
            Case 1 : Tit = "AA-3"
            Case 2 : Tit = "UHX-14"
            Case Else : Tit = "UHX-14"
                Suffix = "3.TXT"
        End Select
        With Padre.Piastra
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Padre.Piastra.GetPiastra. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            If .GetPiastra = 1 Then
                Select Case ptTipoAA
                    Case 101 : File = "\RTF\STAMAA351a" & Suffix
                    Case 102 : File = "\RTF\STAMAA351b" & Suffix
                    Case 103 : File = "\RTF\STAMAA351b" & Suffix 'File = "\RTF\STAMAA351c.TXT"
                    Case 104 : File = "\RTF\STAMAA351DD" & Suffix : j = 1 'File = "\RTF\STAMAA351d.TXT": j = 1
                    Case 105 : File = "\RTF\STAMAA351AA" & Suffix 'File = "\RTF\STAMAA351e.TXT"
                    Case 106 : File = "\RTF\STAMAA351AA" & Suffix 'File = "\RTF\STAMAA351f.TXT"
                End Select
            Else
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Padre.Piastra.Flottante. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                Select Case .Flottante
                    Case 1, 4 : File = "\RTF\STAMAA351AA" & Suffix
                    Case 3 : File = "\RTF\STAMAA351DD" & Suffix : j = 1 'File = "\RTF\STAMAA351BB.TXT": j = 1
                    Case 2 : File = "\RTF\STAMAA351DD" & Suffix : j = 1 'File = "\RTF\STAMAA351CC.TXT": j = 1
                    Case 5 : File = "\RTF\STAMAA351DD" & Suffix : j = 1
                End Select
            End If
            If Not OpenFile(RTrim(Monitor.Motore.Inizio.Archdir) & File, ifl) Then Exit Sub
            Dim prob As RoutBase1.clsProblem = Monitor.Motore.Problem
            Call Assumi(ifl, TIMA) : prob.Printa(GlobalRoutines.FormatS(TIMA, Tit))
            Call Assumi(ifl, TIMA)
            prob.Printa(GlobalRoutines.FormatS(TIMA, .Zp(iCond + Offset, 395), .Zp(iCond + Offset, 395) * inc))
            Call Assumi(ifl, TIMA)
            prob.Printa(GlobalRoutines.FormatS(TIMA, .Zp(iCond + Offset, 397), .Zp(iCond + Offset, 397) * inc))
            If Not j = 1 Then
                Call Assumi(ifl, TIMA)
                prob.Printa(GlobalRoutines.FormatS(TIMA, .Zp(iCond + Offset, 396), .Zp(iCond + Offset, 396) * inc))
                Call Assumi(ifl, TIMA)
                prob.Printa(GlobalRoutines.FormatS(TIMA, .Zp(iCond + Offset, 398), .Zp(iCond + Offset, 398) * inc))
            End If
            Call Assumi(ifl, TIMA)
            prob.Printa(GlobalRoutines.FormatS(TIMA, .Zp(iCond + Offset, 637), .Zp(iCond + Offset, 637) / NIUT))
            Call Assumi(ifl, TIMA)
            prob.Printa(GlobalRoutines.FormatS(TIMA, .Zp(iCond + Offset, 639), .Zp(iCond + Offset, 639) / NIUT))
            If Not j = 1 Then
                Call Assumi(ifl, TIMA)
                prob.Printa(GlobalRoutines.FormatS(TIMA, .Zp(iCond + Offset, 638), .Zp(iCond + Offset, 638) / NIUT))
                Call Assumi(ifl, TIMA)
                prob.Printa(GlobalRoutines.FormatS(TIMA, .Zp(iCond + Offset, 640), .Zp(iCond + Offset, 640) / NIUT))
            End If
            Call Assumi(ifl, TIMA)
            prob.Printa(GlobalRoutines.FormatS(TIMA, .Zp(iCond + Offset, 641), .Zp(iCond + Offset, 641) / mpa))
            Call Assumi(ifl, TIMA)
            prob.Printa(GlobalRoutines.FormatS(TIMA, .Zp(iCond + Offset, 643), .Zp(iCond + Offset, 643) / mpa))
            If Not j = 1 Then
                Call Assumi(ifl, TIMA)
                prob.Printa(GlobalRoutines.FormatS(TIMA, .Zp(iCond + Offset, 642), .Zp(iCond + Offset, 642) / mpa))
                Call Assumi(ifl, TIMA)
                prob.Printa(GlobalRoutines.FormatS(TIMA, .Zp(iCond + Offset, 644), .Zp(iCond + Offset, 644) / mpa))
            End If
            If A02 >= 3 Then
                Call Assumi(ifl, TIMA)
                prob.Printa(GlobalRoutines.FormatS(TIMA, .Zp(iCond + Offset, 757), .Zp(iCond + Offset, 757) * mpa / inc))
                Call Assumi(ifl, TIMA)
                prob.Printa(GlobalRoutines.FormatS(TIMA, .Zp(iCond + Offset, 759), .Zp(iCond + Offset, 759) * mpa / inc))
                If Not j = 1 Then
                    Call Assumi(ifl, TIMA)
                    prob.Printa(GlobalRoutines.FormatS(TIMA, .Zp(iCond + Offset, 758), .Zp(iCond + Offset, 758) * mpa / inc))
                    Call Assumi(ifl, TIMA)
                    prob.Printa(GlobalRoutines.FormatS(TIMA, .Zp(iCond + Offset, 760), .Zp(iCond + Offset, 760) * mpa / inc))
                End If
            End If
        End With
        Call Assumi(ifl, TIMA) : FileClose(ifl)
    End Sub

    Public Sub printAA353(ByRef iCond As Short, ByRef Offset As Short)
        Dim ifl As Short
        Dim TIMA As String = ""
        Dim Fig As String = ""
        Dim Tit As String = ""
        ifl = FreeFile()
        Select Case A02
            Case 1 : Tit = "AA-3"
                Fig = "AA-4.3/AA-4.4"
            Case Else : Tit = "UHX-14"
                Fig = "UHX-11.2"
        End Select
        If Not OpenFile(RTrim(Monitor.Motore.Inizio.Archdir) & "\RTF\STAMAA353.TXT", ifl) Then Exit Sub
        With Monitor.Motore.Problem
            Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, Tit))
            Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, hsup))
            Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, Fig))
            Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, nistar))
            Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, EstarE))
            Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, Fig))
            Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, EstarE * E, EstarE * E * psi / 1000))
        End With
        Dim prob As RoutBase1.clsProblem = Monitor.Motore.Problem
        With Padre.Piastra
            Call Assumi(ifl, TIMA)
            prob.Printa(GlobalRoutines.FormatS(TIMA, .Zp(iCond + Offset, 271)))  'eta
            Call Assumi(ifl, TIMA)
            prob.Printa(GlobalRoutines.FormatS(TIMA, .Zp(iCond + Offset, 402), .Zp(iCond + Offset, 403)))  'Xa
            Call Assumi(ifl, TIMA)
            prob.Printa(GlobalRoutines.FormatS(TIMA, .Zp(iCond + Offset, 404), .Zp(iCond + Offset, 405)))  'F
            Call Assumi(ifl, TIMA) : prob.Printa(GlobalRoutines.FormatS(TIMA, Tit))
            Call Assumi(ifl, TIMA)
            prob.Printa(GlobalRoutines.FormatS(TIMA, .Zp(iCond + Offset, 410), .Zp(iCond + Offset, 411)))  'Zd
            Call Assumi(ifl, TIMA)
            prob.Printa(GlobalRoutines.FormatS(TIMA, .Zp(iCond + Offset, 406), .Zp(iCond + Offset, 407)))  'Zv
            Call Assumi(ifl, TIMA)
            prob.Printa(GlobalRoutines.FormatS(TIMA, .Zp(iCond + Offset, 408), .Zp(iCond + Offset, 409)))  'Zm
            Call Assumi(ifl, TIMA)
            prob.Printa(GlobalRoutines.FormatS(TIMA, .Zp(iCond + Offset, 412), .Zp(iCond + Offset, 413)))  'Phig
            Call Assumi(ifl, TIMA)
            prob.Printa(GlobalRoutines.FormatS(TIMA, .Zp(iCond + Offset, 414), .Zp(iCond + Offset, 415)))  'Q1
            Call Assumi(ifl, TIMA) : FileClose(ifl)
        End With
        FileClose(ifl)
    End Sub

    Public Sub printAA355(ByRef i As Short)
        Dim File As String = ""
        Dim p As Single
        Dim ifl As Short
        Dim TIMA As String = ""
        Dim Tit As String = ""
        Dim Tit1 As String = ""
        Select Case A02
            Case 1 : Tit = "AA-3.5.5 Step 5"
                Tit1 = "AA-3.5.5"
            Case Else : Tit = "UHX-14.5.6 Step 6"
                Tit1 = "Fig. UHX-14.1"
        End Select
        ifl = FreeFile()
        Dim prob As RoutBase1.clsProblem = Monitor.Motore.Problem
        With Padre.Piastra
            Select Case .Flottante
                Case 2, 3, 4 : File = "\RTF\STAMAA355a.TXT"
                Case 1 : File = "\RTF\STAMAA355b.TXT"
                Case 5 : File = "\RTF\STAMAA355c.TXT"
            End Select
            If Not OpenFile(RTrim(Monitor.Motore.Inizio.Archdir) & File, ifl) Then Exit Sub
            Call Assumi(ifl, TIMA) : prob.Printa(GlobalRoutines.FormatS(TIMA, Tit))
            Call Assumi(ifl, TIMA) : prob.Printa(GlobalRoutines.FormatS(TIMA, Tit1))
            Call Assumi(ifl, TIMA)
            p = .Zp(i, 336)
            If NonTermici() Then p = 0
            prob.Printa(GlobalRoutines.FormatS(TIMA, .Zp(i, 330) * psi, .Zp(i, 331) * psi, .Zp(i, 332) * psi, .Zp(i, 333) * psi, .Zp(i, 334) * psi, .Zp(i, 335) * psi, p * psi))
            Call Assumi(ifl, TIMA)
            prob.Printa(GlobalRoutines.FormatS(TIMA, .Zp(i, 330), .Zp(i, 331), .Zp(i, 332), .Zp(i, 333), .Zp(i, 334), .Zp(i, 335), p))
            Call Assumi(ifl, TIMA)
        End With
        FileClose(ifl)
    End Sub
    Public Sub printAA356(ByRef iCond As Short, ByRef Offset As Short, ByRef Tipo As Short)
        Dim File As String = ""
        Dim Fil1 As String = ""
        Dim ifl, j As Short
        Dim TIMA As String = ""
        Dim OK1, OK2 As Boolean
        Dim iload, Corroso As Short
        Dim Tit1 As String = ""
        Dim Tit As String = ""
        Dim Note As String = ""
        Select Case A02
            Case 1 : Tit = "AA-3.5.6 Step 6"
                Tit1 = "AA-3.5.6(a)"
            Case 2 : Tit = "UHX-14.5.5 Step 5"
                Tit1 = "UHX-14.5.5(b)"
            Case Else : Tit = "UHX-14.5.5 Step 5"
                Tit1 = "UHX-14.5.5(b)"
        End Select
        ifl = FreeFile()
        With CType(Padre.Piastra, wn_FTC)
            If .GetPiastra = 1 Then
                Select Case ptTipoAA
                    Case 101 : File = "\RTF\STAMAA356a.TXT"
                        Fil1 = "\RTF\STAMAA356Tr1.TXT"
                        j = 1 : Tipo = 1
                    Case 102 : File = "\RTF\STAMAA356b.TXT"
                        Fil1 = "\RTF\STAMAA356Tr2.TXT"
                        j = 2 : Tipo = 2
                    Case 103 : File = "\RTF\STAMAA356c.TXT"
                        Fil1 = "\RTF\STAMAA356Tr2.TXT"
                        j = 2 : Tipo = 3
                    Case 104 : File = "\RTF\STAMAA356d.TXT" : j = 1
                        j = 0 : Tipo = 4
                    Case 105 : File = "\RTF\STAMAA356e.TXT"
                        Fil1 = "\RTF\STAMAA356Tr3.TXT"
                        j = 3 : Tipo = 5
                    Case 106 : File = "\RTF\STAMAA356f.TXT"
                        Fil1 = "\RTF\STAMAA356Tr3.TXT"
                        j = 3 : Tipo = 6
                End Select
            Else
                Select Case .Flottante
                    Case 1, 4 : File = "\RTF\STAMAA356AA.TXT"
                        Fil1 = "\RTF\STAMAA356Tr3.TXT"
                        j = 3 : Tipo = 7
                    Case 3 : File = "\RTF\STAMAA356BB.TXT" : j = 1
                        j = 0 : Tipo = 8
                    Case 2 : File = "\RTF\STAMAA356CC.TXT" : j = 1
                        j = 0 : Tipo = 9
                    Case 5 : File = "\RTF\STAMAA356DD.TXT" : j = 1
                        j = 0 : Tipo = 10
                End Select
            End If
            If A02 > 2 And Not Padre.RadialExp Then j = 0
            If Not OpenFile(RTrim(Monitor.Motore.Inizio.Archdir) & File, ifl) Then Exit Sub
            Dim prob As RoutBase1.clsProblem = Monitor.Motore.Problem
            Call Assumi(ifl, TIMA) : prob.Printa(GlobalRoutines.FormatS(TIMA, Tit))
            Call Assumi(ifl, TIMA) : prob.Printa(GlobalRoutines.FormatS(TIMA, Tit1))
            Call Assumi(ifl, TIMA)
            prob.Printa(GlobalRoutines.FormatS(TIMA, .Zp(iCond + Offset, 535)))  'gammab
            Call Assumi(ifl, TIMA) : FileClose(ifl)
            If j > 0 Then
                If Not OpenFile(RTrim(Monitor.Motore.Inizio.Archdir) & Fil1, ifl) Then Exit Sub
                Select Case A02
                    Case 1 : Tit = "AA-3.5.6 Step 6"
                        Tit1 = "AA-3.5.6(b)"
                    Case 2 : Tit = "UHX-14.5.5 Step 5"
                        Tit1 = "UHX-14.5.5(c)"
                    Case Else : Tit = "UHX-14.5.5 Step 5"
                        Tit1 = "UHX-14.6.4(a)"
                End Select
                Call Assumi(ifl, TIMA) : prob.Printa(GlobalRoutines.FormatS(TIMA, Tit))
                Call Assumi(ifl, TIMA) : prob.Printa(GlobalRoutines.FormatS(TIMA, Tit1))
                Call Assumi(ifl, TIMA)
                prob.Printa(GlobalRoutines.FormatS(TIMA, .Zp(iCond + Offset, 594), .Zp(iCond + Offset, 594) * 1.8 + 32))
            End If
            Select Case j
                Case 1
                    Call Assumi(ifl, TIMA)
                    prob.Printa(GlobalRoutines.FormatS(TIMA, .Zp(iCond + Offset, 595), .Zp(iCond + Offset, 595) * 1.8 + 32))
                    Call Assumi(ifl, TIMA)
                    prob.Printa(GlobalRoutines.FormatS(TIMA, .Zp(iCond + Offset, 596), .Zp(iCond + Offset, 596) * 1.8 + 32))
                    Call Assumi(ifl, TIMA)
                    prob.Printa(GlobalRoutines.FormatS(TIMA, .Zp(iCond + Offset, 433), .Zp(iCond + Offset, 433) * 1.8 + 32))
                    Call Assumi(ifl, TIMA)
                    prob.Printa(GlobalRoutines.FormatS(TIMA, .Zp(iCond + Offset, 434), .Zp(iCond + Offset, 434) * 1.8 + 32))
                    Call Assumi(ifl, TIMA)
                    prob.Printa(GlobalRoutines.FormatS(TIMA, .Zp(iCond + Offset, 435), .Zp(iCond + Offset, 435) * 1.8 + 32))
                    Call Assumi(ifl, TIMA)
                    prob.Printa(GlobalRoutines.FormatS(TIMA, .Zp(iCond + Offset, 321), .Zp(iCond + Offset, 321) / 1.8)) 'alfap
                    Call Assumi(ifl, TIMA)
                    prob.Printa(GlobalRoutines.FormatS(TIMA, .Zp(iCond + Offset, 14), .Zp(iCond + Offset, 14) / 1.8)) 'alfasp
                    Call Assumi(ifl, TIMA)
                    prob.Printa(GlobalRoutines.FormatS(TIMA, .Zp(iCond + Offset, 324), .Zp(iCond + Offset, 324) / 1.8)) 'alfacp
                Case 2
                    Call Assumi(ifl, TIMA)
                    prob.Printa(GlobalRoutines.FormatS(TIMA, .Zp(iCond + Offset, 595), .Zp(iCond + Offset, 595) * 1.8 + 32))
                    Call Assumi(ifl, TIMA)
                    prob.Printa(GlobalRoutines.FormatS(TIMA, .Zp(iCond + Offset, 433), .Zp(iCond + Offset, 433) * 1.8 + 32))
                    Call Assumi(ifl, TIMA)
                    prob.Printa(GlobalRoutines.FormatS(TIMA, .Zp(iCond + Offset, 434), .Zp(iCond + Offset, 434) * 1.8 + 32))
                    Call Assumi(ifl, TIMA)
                    prob.Printa(GlobalRoutines.FormatS(TIMA, .Zp(iCond + Offset, 321), .Zp(iCond + Offset, 321) / 1.8)) 'alfap
                    Call Assumi(ifl, TIMA)
                    prob.Printa(GlobalRoutines.FormatS(TIMA, .Zp(iCond + Offset, 14), .Zp(iCond + Offset, 14) / 1.8)) 'alfasp
                Case 3
                    Call Assumi(ifl, TIMA)
                    prob.Printa(GlobalRoutines.FormatS(TIMA, .Zp(iCond + Offset, 596), .Zp(iCond + Offset, 596) * 1.8 + 32))
                    Call Assumi(ifl, TIMA)
                    prob.Printa(GlobalRoutines.FormatS(TIMA, .Zp(iCond + Offset, 433), .Zp(iCond + Offset, 433) * 1.8 + 32))
                    Call Assumi(ifl, TIMA)
                    prob.Printa(GlobalRoutines.FormatS(TIMA, .Zp(iCond + Offset, 435), .Zp(iCond + Offset, 435) * 1.8 + 32))
                    Call Assumi(ifl, TIMA)
                    prob.Printa(GlobalRoutines.FormatS(TIMA, .Zp(iCond + Offset, 321), .Zp(iCond + Offset, 321) / 1.8)) 'alfap
                    Call Assumi(ifl, TIMA)
                    prob.Printa(GlobalRoutines.FormatS(TIMA, .Zp(iCond + Offset, 324), .Zp(iCond + Offset, 324) / 1.8)) 'alfacp
            End Select
            If j > 0 Then
                Call Assumi(ifl, TIMA) : FileClose(ifl)
            End If
            Select Case A02
                Case 1 : Tit = "AA-3.5.6 Step 6"
                    Tit1 = "AA-3.5.6(b)"
                    File = RTrim(Monitor.Motore.Inizio.Archdir) & "\RTF\STAMAA356Tc.TXT"
                Case 2 : Tit = "UHX-14.5.5 Step 5"
                    Tit1 = "UHX-14.5.5(a)"
                    File = RTrim(Monitor.Motore.Inizio.Archdir) & "\RTF\STAMAA356Tc.TXT"
                Case Else : Tit = "UHX-14.5.5 Step 5"
                    Tit1 = "UHX-14.6.4(c)"
                    File = RTrim(Monitor.Motore.Inizio.Archdir) & "\RTF\STAMAA356Tc3.TXT"
            End Select
            If Not OpenFile(File, ifl) Then Exit Sub
            Call Assumi(ifl, TIMA) : prob.Printa(GlobalRoutines.FormatS(TIMA, Tit1))
            Call Assumi(ifl, TIMA)
            prob.Printa(GlobalRoutines.FormatS(TIMA, .Zp(iCond + Offset, 597), .Zp(iCond + Offset, 597) * psi))  'Pressss
            If A02 > 2 Then
                If Padre.RadialExp Then
                    Note = "For configurations b, c, d, B, C, D P{\sub s}{\super *} =0 by definition"
                Else
                    Note = "Art. UHX-14.6 does not apply to this project, therefore P{\sub s}{\super *} =0"
                End If
                Call Assumi(ifl, TIMA) : prob.Printa(GlobalRoutines.FormatS(TIMA, Note))
            End If
            Call Assumi(ifl, TIMA)
            prob.Printa(GlobalRoutines.FormatS(TIMA, .Zp(iCond + Offset, 598), .Zp(iCond + Offset, 598) * psi))  'Presscs
            If A02 > 2 Then
                If Padre.RadialExp Then
                    Note = "For configurations d, e, f, A, B, C, D P{\sub c}{\super *} =0 by definition"
                Else
                    Note = "Art. UHX-14.6 does not apply to this project, therefore P{\sub c}{\super *} =0"
                End If
                Call Assumi(ifl, TIMA) : prob.Printa(GlobalRoutines.FormatS(TIMA, Note))
            End If
            Select Case A02
                Case 1 : Tit = "AA-3.5.6 Step 6"
                    Tit1 = "AA-3.5.6(c)"
                Case Else : Tit = "UHX-14.5.5 Step 5"
                    Tit1 = "UHX-14.5.5(c)"
            End Select
            Call Assumi(ifl, TIMA) : prob.Printa(GlobalRoutines.FormatS(TIMA, Tit1))
            Call Assumi(ifl, TIMA)
            prob.Printa(GlobalRoutines.FormatS(TIMA, .Zp(iCond + Offset, 422), .Zp(iCond + Offset, 423)))
            Call Assumi(ifl, TIMA)
            prob.Printa(GlobalRoutines.FormatS(TIMA, .Zp(iCond + Offset, 424), .Zp(iCond + Offset, 425)))
            Call Assumi(ifl, TIMA)
            prob.Printa(GlobalRoutines.FormatS(TIMA, .Zp(iCond + Offset, 426), .Zp(iCond + Offset, 427)))
            Call Assumi(ifl, TIMA)
            prob.Printa(GlobalRoutines.FormatS(TIMA, .Zp(iCond + Offset, 428), .Zp(iCond + Offset, 429)))
            j = iCond + Offset
            Select Case A02
                Case 1 : Tit1 = " "
                Case Else : Tit1 = "{\b UHX-14.5.7 Step 7}"
            End Select
            Call Assumi(ifl, TIMA) : prob.Printa(GlobalRoutines.FormatS(TIMA, Tit1))
            Call Assumi(ifl, TIMA)
            prob.Printa(GlobalRoutines.FormatS(TIMA, .Zp(j, 171), .Zp(j, 172), .Zp(j, 173), .Zp(j, 174), .Zp(j, 175), .Zp(j, 176), .Zp(j, 177)))
            Call Assumi(ifl, TIMA)
            prob.Printa(GlobalRoutines.FormatS(TIMA, .Zp(j, 171) * NIUT, .Zp(j, 172) * NIUT, .Zp(j, 173) * NIUT, .Zp(j, 174) * NIUT, .Zp(j, 175) * NIUT, .Zp(j, 176) * NIUT, .Zp(j, 177) * NIUT))
            Call Assumi(ifl, TIMA)
            prob.Printa(GlobalRoutines.FormatS(TIMA, .Zp(j, 178), .Zp(j, 179), .Zp(j, 180), .Zp(j, 181), .Zp(j, 182), .Zp(j, 183), .Zp(j, 184)))
            Call Assumi(ifl, TIMA)
            prob.Printa(GlobalRoutines.FormatS(TIMA, .Zp(j, 178) * NIUT, .Zp(j, 179) * NIUT, .Zp(j, 180) * NIUT, .Zp(j, 181) * NIUT, .Zp(j, 182) * NIUT, .Zp(j, 183) * NIUT, .Zp(j, 184) * NIUT))
            Select Case A02
                Case 1 : Tit1 = "AA-3.5.6(d)"
                Case Else : Tit1 = "{UHX-14.5.7(b)}"
            End Select
            Call Assumi(ifl, TIMA) : prob.Printa(GlobalRoutines.FormatS(TIMA, Tit1))
            Call Assumi(ifl, TIMA)
            prob.Printa(GlobalRoutines.FormatS(TIMA, .Zp(j, 436), .Zp(j, 437), .Zp(j, 438), .Zp(j, 439), .Zp(j, 440), .Zp(j, 441), .Zp(j, 442)))
            Call Assumi(ifl, TIMA)
            prob.Printa(GlobalRoutines.FormatS(TIMA, .Zp(j, 443), .Zp(j, 444), .Zp(j, 445), .Zp(j, 446), .Zp(j, 447), .Zp(j, 448), .Zp(j, 449)))
            Call Assumi(ifl, TIMA)
            prob.Printa(GlobalRoutines.FormatS(TIMA, .Zp(j, 450), .Zp(j, 451), .Zp(j, 452), .Zp(j, 453), .Zp(j, 454), .Zp(j, 455), .Zp(j, 456)))
            Call Assumi(ifl, TIMA)
            prob.Printa(GlobalRoutines.FormatS(TIMA, .Zp(j, 457), .Zp(j, 458), .Zp(j, 459), .Zp(j, 460), .Zp(j, 461), .Zp(j, 462), .Zp(j, 463)))
            Call Assumi(ifl, TIMA)
            prob.Printa(GlobalRoutines.FormatS(TIMA, .Zp(j, 464) * psi, .Zp(j, 465) * psi, .Zp(j, 466) * psi, .Zp(j, 467) * psi, .Zp(j, 468) * psi, .Zp(j, 469) * psi, .Zp(j, 470) * psi))
            Call Assumi(ifl, TIMA)
            prob.Printa(GlobalRoutines.FormatS(TIMA, .Zp(j, 464), .Zp(j, 465), .Zp(j, 466), .Zp(j, 467), .Zp(j, 468), .Zp(j, 469), .Zp(j, 470)))
            Call Assumi(ifl, TIMA)
            prob.Printa(GlobalRoutines.FormatS(TIMA, .Zp(j, 471) * psi, .Zp(j, 472) * psi, .Zp(j, 473) * psi, .Zp(j, 474) * psi, .Zp(j, 475) * psi, .Zp(j, 476) * psi, .Zp(j, 477) * psi))
            Call Assumi(ifl, TIMA)
            prob.Printa(GlobalRoutines.FormatS(TIMA, .Zp(j, 471), .Zp(j, 472), .Zp(j, 473), .Zp(j, 474), .Zp(j, 475), .Zp(j, 476), .Zp(j, 477)))
            Call Assumi(ifl, TIMA) : prob.Printa(TIMA)
            OK1 = True : OK2 = True
            For Corroso = 0 To 1
                For iload = 1 To 3
                    OK1 = OK1 And .Zp(j, 464 + iload - 1 + 7 * Corroso) < 1.5 * .Zp(j, 35)
                Next iload
                For iload = 4 To 7
                    OK2 = OK2 And .Zp(j, 464 + iload - 1 + 7 * Corroso) < .Zp(j, 591)
                Next iload
            Next Corroso
            If OK1 Then
                Call Assumi(ifl, TIMA)
                prob.Printa(GlobalRoutines.FormatS(TIMA, 1.5 * .Zp(j, 35), 1.5 * .Zp(j, 35) * psi))
            Else
                Call Assumi(ifl, TIMA, True)
            End If
            If Not OK1 Then
                Call Assumi(ifl, TIMA)
                prob.Printa(GlobalRoutines.FormatS(TIMA, 1.5 * .Zp(j, 35), 1.5 * .Zp(j, 35) * psi))
            Else
                Call Assumi(ifl, TIMA, True)
            End If
            If OK2 Then
                If Not NonTermici() Then
                    Call Assumi(ifl, TIMA)
                    prob.Printa(GlobalRoutines.FormatS(TIMA, .Zp(j, 591), .Zp(j, 591) * psi))
                Else
                    Call Assumi(ifl, TIMA, True)
                End If
            Else
                Call Assumi(ifl, TIMA, True)
            End If
            If Not OK2 Then
                If Not NonTermici() Then
                    Call Assumi(ifl, TIMA)
                    prob.Printa(GlobalRoutines.FormatS(TIMA, .Zp(j, 591), .Zp(j, 591) * psi))
                Else
                    Call Assumi(ifl, TIMA, True)
                End If
            Else
                Call Assumi(ifl, TIMA, True)
            End If
            Call Assumi(ifl, TIMA) : FileClose(ifl)
            If Tipo > 6 Then Exit Sub
            Select Case A02
                Case 1 : Tit1 = "{\i\f2\fs18 AA-3.5.6(g)}"
                Case Else : Tit1 = "{\b\f2\fs18 UHX-14.5.8 Step 8}"
            End Select
            If Not OpenFile(RTrim(Monitor.Motore.Inizio.Archdir) & "\RTF\STAMAA356tau.TXT", ifl) Then Exit Sub
            Call Assumi(ifl, TIMA) : prob.Printa(GlobalRoutines.FormatS(TIMA, Tit1))
            Call Assumi(ifl, TIMA)
            prob.Printa(GlobalRoutines.FormatS(TIMA, .Zp(j, 478) * psi, .Zp(j, 479) * psi, .Zp(j, 480) * psi, .Zp(j, 481) * psi, .Zp(j, 482) * psi, .Zp(j, 483) * psi, .Zp(j, 484) * psi))
            Call Assumi(ifl, TIMA)
            prob.Printa(GlobalRoutines.FormatS(TIMA, .Zp(j, 478), .Zp(j, 479), .Zp(j, 480), .Zp(j, 481), .Zp(j, 482), .Zp(j, 483), .Zp(j, 484)))
            Call Assumi(ifl, TIMA)
            prob.Printa(GlobalRoutines.FormatS(TIMA, .Zp(j, 478) * psi, .Zp(j, 479) * psi, .Zp(j, 480) * psi, .Zp(j, 481) * psi, .Zp(j, 482) * psi, .Zp(j, 483) * psi, .Zp(j, 484) * psi))
            Call Assumi(ifl, TIMA)
            prob.Printa(GlobalRoutines.FormatS(TIMA, .Zp(j, 478), .Zp(j, 479), .Zp(j, 480), .Zp(j, 481), .Zp(j, 482), .Zp(j, 483), .Zp(j, 484)))
            Call Assumi(ifl, TIMA) : prob.Printa(TIMA)
            OK1 = True
            For Corroso = 0 To 1
                For iload = 1 To 7
                    OK1 = OK1 And .Zp(j, 478 + iload - 1 + 7 * Corroso) < 0.8 * .Zp(j, 35)
                Next iload
            Next Corroso
            If OK1 Then
                Call Assumi(ifl, TIMA)
                prob.Printa(GlobalRoutines.FormatS(TIMA, 0.8 * .Zp(j, 35), 0.8 * .Zp(j, 35) * psi))
            Else
                Call Assumi(ifl, TIMA, True)
            End If
            If Not OK1 Then
                Call Assumi(ifl, TIMA)
                prob.Printa(GlobalRoutines.FormatS(TIMA, 0.8 * .Zp(j, 35), 0.8 * .Zp(j, 35) * psi))
            Else
                Call Assumi(ifl, TIMA, True)
            End If
        End With
        Call Assumi(ifl, TIMA) : FileClose(ifl)
    End Sub

    Public Sub printAA357(ByRef iCond As Short, ByRef Offset As Short)
        Dim ifl, j As Short
        Dim TIMA As String = ""
        Dim iload, Corroso As Short
        Dim OK1, OK2 As Boolean
        Dim Tit As String = ""
        Dim Tit1 As String = ""
        Select Case A02
            Case 1 : Tit = "AA-3.5.7 Step 7"
                Tit1 = "AA-3.5.7"
            Case Else : Tit = "UHX-14.5.9 Step 9"
                Tit1 = "UHX-14.5.9"
        End Select
        ifl = FreeFile()
        j = iCond + Offset
        If Not OpenFile(RTrim(Monitor.Motore.Inizio.Archdir) & "\RTF\STAMAA357.TXT", ifl) Then Exit Sub
        Dim prob As RoutBase1.clsProblem = Monitor.Motore.Problem
        Call Assumi(ifl, TIMA) : prob.Printa(GlobalRoutines.FormatS(TIMA, Tit))
        Call Assumi(ifl, TIMA) : prob.Printa(GlobalRoutines.FormatS(TIMA, Tit1))
        With Padre.Piastra
            Call Assumi(ifl, TIMA)
            prob.Printa(GlobalRoutines.FormatS(TIMA, .Zp(j, 223) * psi, .Zp(j, 224) * psi, .Zp(j, 225) * psi, .Zp(j, 226) * psi, .Zp(j, 227) * psi, .Zp(j, 228) * psi, .Zp(j, 229) * psi))
            Call Assumi(ifl, TIMA)
            prob.Printa(GlobalRoutines.FormatS(TIMA, .Zp(j, 223), .Zp(j, 224), .Zp(j, 225), .Zp(j, 226), .Zp(j, 227), .Zp(j, 228), .Zp(j, 229)))
            Call Assumi(ifl, TIMA)
            prob.Printa(GlobalRoutines.FormatS(TIMA, .Zp(j, 230) * psi, .Zp(j, 231) * psi, .Zp(j, 232) * psi, .Zp(j, 233) * psi, .Zp(j, 234) * psi, .Zp(j, 235) * psi, .Zp(j, 236) * psi))
            Call Assumi(ifl, TIMA)
            prob.Printa(GlobalRoutines.FormatS(TIMA, .Zp(j, 230), .Zp(j, 231), .Zp(j, 232), .Zp(j, 233), .Zp(j, 234), .Zp(j, 235), .Zp(j, 236)))
            Call Assumi(ifl, TIMA) : prob.Printa(TIMA)
            OK1 = True : OK2 = True
            For Corroso = 0 To 1
                For iload = 1 To 3
                    OK1 = OK1 And .Zp(j, 223 + iload - 1 + 7 * Corroso) < .Zp(j, 13)
                Next iload
                For iload = 4 To 7
                    OK2 = OK2 And .Zp(j, 223 + iload - 1 + 7 * Corroso) < 2 * .Zp(j, 13)
                Next iload
            Next Corroso
            If OK1 Then
                Call Assumi(ifl, TIMA)
                prob.Printa(GlobalRoutines.FormatS(TIMA, .Zp(j, 13), .Zp(j, 13) * psi))
            Else
                Call Assumi(ifl, TIMA, True)
            End If
            If Not OK1 Then
                Call Assumi(ifl, TIMA)
                prob.Printa(GlobalRoutines.FormatS(TIMA, .Zp(j, 13), .Zp(j, 13) * psi))
            Else
                Call Assumi(ifl, TIMA, True)
            End If
            If OK2 Then
                If Not NonTermici() Then
                    Call Assumi(ifl, TIMA)
                    prob.Printa(GlobalRoutines.FormatS(TIMA, 2 * .Zp(j, 13), 2 * .Zp(j, 13) * psi))
                Else
                    Call Assumi(ifl, TIMA, True)
                End If
            Else
                Call Assumi(ifl, TIMA, True)
            End If
            If Not OK2 Then
                If Not NonTermici() Then
                    Call Assumi(ifl, TIMA)
                    prob.Printa(GlobalRoutines.FormatS(TIMA, 2 * .Zp(j, 13), 2 * .Zp(j, 13) * psi))
                Else
                    Call Assumi(ifl, TIMA, True)
                End If
            Else
                Call Assumi(ifl, TIMA, True)
            End If
            Call Assumi(ifl, TIMA) : prob.Printa(GlobalRoutines.FormatS(TIMA, Tit1))
            Call Assumi(ifl, TIMA)
            prob.Printa(GlobalRoutines.FormatS(TIMA, .Zp(iCond, 9), .Zp(iCond, 9) * psi / 1000))
            Call Assumi(ifl, TIMA)
            prob.Printa(GlobalRoutines.FormatS(TIMA, .Zp(iCond, 38), .Zp(iCond, 38) * psi))
            Call Assumi(ifl, TIMA)
            prob.Printa(GlobalRoutines.FormatS(TIMA, .Zp(iCond, 242)))
            Call Assumi(ifl, TIMA)
            prob.Printa(GlobalRoutines.FormatS(TIMA, .Zp(iCond, 241), .Zp(iCond, 241) / inc))
            Call Assumi(ifl, TIMA)
            prob.Printa(GlobalRoutines.FormatS(TIMA, .Zp(iCond, 243), .Zp(iCond, 243) / inc))
            Call Assumi(ifl, TIMA)
            prob.Printa(GlobalRoutines.FormatS(TIMA, .Zp(j, 599), .Zp(j, 600), .Zp(j, 601), .Zp(j, 602), .Zp(j, 603), .Zp(j, 604), .Zp(j, 605)))
            Call Assumi(ifl, TIMA)
            prob.Printa(GlobalRoutines.FormatS(TIMA, .Zp(j, 613) * psi, .Zp(j, 614) * psi, .Zp(j, 615) * psi, .Zp(j, 616) * psi, .Zp(j, 617) * psi, .Zp(j, 618) * psi, .Zp(j, 619) * psi))
            Call Assumi(ifl, TIMA)
            prob.Printa(GlobalRoutines.FormatS(TIMA, .Zp(j, 613), .Zp(j, 614), .Zp(j, 615), .Zp(j, 616), .Zp(j, 617), .Zp(j, 618), .Zp(j, 619)))
            Call Assumi(ifl, TIMA) : FileClose(ifl)
        End With
    End Sub
    Public Sub printPlast(ByRef iCond As Short, ByRef Offset As Short)
        Dim ifl, j As Short
        Dim TIMA As String = "" ', m As Integer, b As Integer, t As Integer
        Dim File As String = ""
        Dim Tit As String = "" ', indSSS As Integer, indlam As Integer
        Dim ShCh, PlastOK As Boolean
        Dim Car, Car1 As String
        'If Not ElasPlas Then Exit Sub
        Select Case ptTipoAA
            Case 5 : ShCh = True
                Tit = "Shell & Channel joints"
                If junctionOK(1, iCond) < 1 And junctionOK(2, iCond) < 1 Then Exit Sub
                If junctionOK(1, iCond) = 2 Or junctionOK(2, iCond) = 2 Then PlastOK = True
            Case 6, 7 : ShCh = False
                Tit = "Shell joint"
                If junctionOK(1, iCond) < 1 Then Exit Sub
                If junctionOK(1, iCond) = 2 Then PlastOK = True
            Case 8 : Exit Sub
        End Select
        File = "\RTF\STAMPlas.TXT"
        With CType(Padre.Piastra, wn_FTC)
            .Testatap()
            ifl = FreeFile()
            j = iCond + Offset
            If Not OpenFile(RTrim(Monitor.Motore.Inizio.Archdir) & File, ifl) Then Exit Sub
            Dim prob As RoutBase1.clsProblem = Monitor.Motore.Problem
            Call Assumi(ifl, TIMA) : prob.Printa(GlobalRoutines.FormatS(TIMA, Tit))
            Call Assumi(ifl, TIMA)
            prob.Printa(GlobalRoutines.FormatS(TIMA, .Zp(j, 499), .Zp(j, 499) * psi))
            Call Assumi(ifl, TIMA)
            If ShCh Then
                Call Assumi(ifl, TIMA)
                prob.Printa(GlobalRoutines.FormatS(TIMA, .Zp(j, 500), .Zp(j, 500) * psi))
                Call Assumi(ifl, TIMA)
                Call Assumi(ifl, TIMA)
                Call Assumi(ifl, TIMA)
                Call Assumi(ifl, TIMA)
                prob.Printa(GlobalRoutines.FormatS(TIMA, .Zp(iCond + Offset, 539 + 1 - 1 + 7 * 0), .Zp(iCond + Offset, 539 + 1 - 1 + 7 * 1), .Zp(iCond + Offset, 539 + 2 - 1 + 7 * 0), .Zp(iCond + Offset, 539 + 2 - 1 + 7 * 1), .Zp(iCond + Offset, 539 + 3 - 1 + 7 * 0), .Zp(iCond + Offset, 539 + 3 - 1 + 7 * 1)))
                Call Assumi(ifl, TIMA, PlastOK)
                If Not PlastOK Then _
                   prob.Printa(GlobalRoutines.FormatS(TIMA, .Zp(iCond + Offset, 8) * .Zp(iCond + Offset, 539 + 1 - 1 + 7 * 0), .Zp(iCond + Offset, 8) * .Zp(iCond + Offset, 539 + 1 - 1 + 7 * 1), .Zp(iCond + Offset, 8) * .Zp(iCond + Offset, 539 + 2 - 1 + 7 * 0), .Zp(iCond + Offset, 8) * .Zp(iCond + Offset, 539 + 2 - 1 + 7 * 1), .Zp(iCond + Offset, 8) * .Zp(iCond + Offset, 539 + 3 - 1 + 7 * 0), .Zp(iCond + Offset, 8) * .Zp(iCond + Offset, 539 + 3 - 1 + 7 * 1)))
                Call Assumi(ifl, TIMA, PlastOK)
                If Not PlastOK Then _
                   prob.Printa(GlobalRoutines.FormatS(TIMA, .Zp(iCond + Offset, 542 + 1 - 1 + 7 * 0), .Zp(iCond + Offset, 542 + 1 - 1 + 7 * 1), .Zp(iCond + Offset, 542 + 2 - 1 + 7 * 0), .Zp(iCond + Offset, 542 + 2 - 1 + 7 * 1), .Zp(iCond + Offset, 542 + 3 - 1 + 7 * 0), .Zp(iCond + Offset, 542 + 3 - 1 + 7 * 1)))
                Call Assumi(ifl, TIMA, PlastOK)
                If Not PlastOK Then _
                   prob.Printa(GlobalRoutines.FormatS(TIMA, .Zp(iCond + Offset, 663 + 1 - 1 + 7 * 0), .Zp(iCond + Offset, 663 + 1 - 1 + 7 * 1), .Zp(iCond + Offset, 663 + 2 - 1 + 7 * 0), .Zp(iCond + Offset, 663 + 2 - 1 + 7 * 1), .Zp(iCond + Offset, 663 + 3 - 1 + 7 * 0), .Zp(iCond + Offset, 663 + 3 - 1 + 7 * 1)))
                Call Assumi(ifl, TIMA)
                Call Assumi(ifl, TIMA)
                prob.Printa(GlobalRoutines.FormatS(TIMA, .Zp(iCond + Offset, 553 + 1 - 1 + 7 * 0), .Zp(iCond + Offset, 553 + 1 - 1 + 7 * 1), .Zp(iCond + Offset, 553 + 2 - 1 + 7 * 0), .Zp(iCond + Offset, 553 + 2 - 1 + 7 * 1), .Zp(iCond + Offset, 553 + 3 - 1 + 7 * 0), .Zp(iCond + Offset, 553 + 3 - 1 + 7 * 1)))
                Call Assumi(ifl, TIMA, PlastOK)
                If Not PlastOK Then _
                   prob.Printa(GlobalRoutines.FormatS(TIMA, .Zp(iCond + Offset, 323) * .Zp(iCond + Offset, 553 + 1 - 1 + 7 * 0), .Zp(iCond + Offset, 323) * .Zp(iCond + Offset, 553 + 1 - 1 + 7 * 1), .Zp(iCond + Offset, 323) * .Zp(iCond + Offset, 553 + 2 - 1 + 7 * 0), .Zp(iCond + Offset, 323) * .Zp(iCond + Offset, 553 + 2 - 1 + 7 * 1), .Zp(iCond + Offset, 323) * .Zp(iCond + Offset, 553 + 3 - 1 + 7 * 0), .Zp(iCond + Offset, 323) * .Zp(iCond + Offset, 553 + 3 - 1 + 7 * 1)))
                Call Assumi(ifl, TIMA, PlastOK)
                If Not PlastOK Then _
                   prob.Printa(GlobalRoutines.FormatS(TIMA, .Zp(iCond + Offset, 556 + 1 - 1 + 7 * 0), .Zp(iCond + Offset, 556 + 1 - 1 + 7 * 1), .Zp(iCond + Offset, 556 + 2 - 1 + 7 * 0), .Zp(iCond + Offset, 556 + 2 - 1 + 7 * 1), .Zp(iCond + Offset, 556 + 3 - 1 + 7 * 0), .Zp(iCond + Offset, 556 + 3 - 1 + 7 * 1)))
                Call Assumi(ifl, TIMA, PlastOK)
                If Not PlastOK Then _
                   prob.Printa(GlobalRoutines.FormatS(TIMA, .Zp(iCond + Offset, 666 + 1 - 1 + 7 * 0), .Zp(iCond + Offset, 666 + 1 - 1 + 7 * 1), .Zp(iCond + Offset, 666 + 2 - 1 + 7 * 0), .Zp(iCond + Offset, 666 + 2 - 1 + 7 * 1), .Zp(iCond + Offset, 666 + 3 - 1 + 7 * 0), .Zp(iCond + Offset, 666 + 3 - 1 + 7 * 1)))
                Call Assumi(ifl, TIMA)
            Else
                Call Assumi(ifl, TIMA, True)
                Call Assumi(ifl, TIMA, True)
                Call Assumi(ifl, TIMA, True)
                Call Assumi(ifl, TIMA, True)
                Call Assumi(ifl, TIMA)
                prob.Printa(GlobalRoutines.FormatS(TIMA, .Zp(iCond + Offset, 539 + 1 - 1 + 7 * 0), .Zp(iCond + Offset, 539 + 1 - 1 + 7 * 1), .Zp(iCond + Offset, 539 + 2 - 1 + 7 * 0), .Zp(iCond + Offset, 539 + 2 - 1 + 7 * 1), .Zp(iCond + Offset, 539 + 3 - 1 + 7 * 0), .Zp(iCond + Offset, 539 + 3 - 1 + 7 * 1)))
                Call Assumi(ifl, TIMA, PlastOK)
                If Not PlastOK Then _
                   prob.Printa(GlobalRoutines.FormatS(TIMA, .Zp(iCond + Offset, 8) * .Zp(iCond + Offset, 539 + 1 - 1 + 7 * 0), .Zp(iCond + Offset, 8) * .Zp(iCond + Offset, 539 + 1 - 1 + 7 * 1), .Zp(iCond + Offset, 8) * .Zp(iCond + Offset, 539 + 2 - 1 + 7 * 0), .Zp(iCond + Offset, 8) * .Zp(iCond + Offset, 539 + 2 - 1 + 7 * 1), .Zp(iCond + Offset, 8) * .Zp(iCond + Offset, 539 + 3 - 1 + 7 * 0), .Zp(iCond + Offset, 8) * .Zp(iCond + Offset, 539 + 3 - 1 + 7 * 1)))
                Call Assumi(ifl, TIMA, PlastOK)
                If Not PlastOK Then _
                   prob.Printa(GlobalRoutines.FormatS(TIMA, .Zp(iCond + Offset, 542 + 1 - 1 + 7 * 0), .Zp(iCond + Offset, 542 + 1 - 1 + 7 * 1), .Zp(iCond + Offset, 542 + 2 - 1 + 7 * 0), .Zp(iCond + Offset, 542 + 2 - 1 + 7 * 1), .Zp(iCond + Offset, 542 + 3 - 1 + 7 * 0), .Zp(iCond + Offset, 542 + 3 - 1 + 7 * 1)))
                Call Assumi(ifl, TIMA, PlastOK)
                If Not PlastOK Then _
                   prob.Printa(GlobalRoutines.FormatS(TIMA, .Zp(iCond + Offset, 663 + 1 - 1 + 7 * 0), .Zp(iCond + Offset, 663 + 1 - 1 + 7 * 1), .Zp(iCond + Offset, 663 + 2 - 1 + 7 * 0), .Zp(iCond + Offset, 663 + 2 - 1 + 7 * 1), .Zp(iCond + Offset, 663 + 3 - 1 + 7 * 0), .Zp(iCond + Offset, 663 + 3 - 1 + 7 * 1)))
                Call Assumi(ifl, TIMA)
                Call Assumi(ifl, TIMA, True)
                Call Assumi(ifl, TIMA, True)
                Call Assumi(ifl, TIMA, True)
                Call Assumi(ifl, TIMA, True)
                Call Assumi(ifl, TIMA, True)
            End If
            Call Assumi(ifl, TIMA, PlastOK)
            If Not PlastOK Then _
               prob.Printa(GlobalRoutines.FormatS(TIMA, .Zp(iCond + Offset, 677 + 1 - 1 + 7 * 0), .Zp(iCond + Offset, 677 + 1 - 1 + 7 * 1), .Zp(iCond + Offset, 677 + 2 - 1 + 7 * 0), .Zp(iCond + Offset, 677 + 2 - 1 + 7 * 1), .Zp(iCond + Offset, 677 + 3 - 1 + 7 * 0), .Zp(iCond + Offset, 677 + 3 - 1 + 7 * 1)))
            Call Assumi(ifl, TIMA, PlastOK)
            If Not PlastOK Then _
               prob.Printa(GlobalRoutines.FormatS(TIMA, .Zp(iCond + Offset, 680 + 1 - 1 + 7 * 0), .Zp(iCond + Offset, 680 + 1 - 1 + 7 * 1), .Zp(iCond + Offset, 680 + 2 - 1 + 7 * 0), .Zp(iCond + Offset, 680 + 2 - 1 + 7 * 1), .Zp(iCond + Offset, 680 + 3 - 1 + 7 * 0), .Zp(iCond + Offset, 680 + 3 - 1 + 7 * 1)))
            Call Assumi(ifl, TIMA, PlastOK)
            If Not PlastOK Then _
               prob.Printa(GlobalRoutines.FormatS(TIMA, .Zp(iCond + Offset, 691 + 1 - 1 + 7 * 0), .Zp(iCond + Offset, 691 + 1 - 1 + 7 * 1), .Zp(iCond + Offset, 691 + 2 - 1 + 7 * 0), .Zp(iCond + Offset, 691 + 2 - 1 + 7 * 1), .Zp(iCond + Offset, 691 + 3 - 1 + 7 * 0), .Zp(iCond + Offset, 691 + 3 - 1 + 7 * 1)))
            Call Assumi(ifl, TIMA, PlastOK)
            If Not PlastOK Then _
               prob.Printa(GlobalRoutines.FormatS(TIMA, .Zp(iCond + Offset, 694 + 1 - 1 + 7 * 0), .Zp(iCond + Offset, 694 + 1 - 1 + 7 * 1), .Zp(iCond + Offset, 694 + 2 - 1 + 7 * 0), .Zp(iCond + Offset, 694 + 2 - 1 + 7 * 1), .Zp(iCond + Offset, 694 + 3 - 1 + 7 * 0), .Zp(iCond + Offset, 694 + 3 - 1 + 7 * 1)))
            Call Assumi(ifl, TIMA, PlastOK)
            If Not PlastOK Then _
               prob.Printa(GlobalRoutines.FormatS(TIMA, .Zp(iCond + Offset, 705 + 1 - 1 + 7 * 0), .Zp(iCond + Offset, 705 + 1 - 1 + 7 * 1), .Zp(iCond + Offset, 705 + 2 - 1 + 7 * 0), .Zp(iCond + Offset, 705 + 2 - 1 + 7 * 1), .Zp(iCond + Offset, 705 + 3 - 1 + 7 * 0), .Zp(iCond + Offset, 705 + 3 - 1 + 7 * 1)))
            Call Assumi(ifl, TIMA, PlastOK)
            If Not PlastOK Then _
               prob.Printa(GlobalRoutines.FormatS(TIMA, .Zp(iCond + Offset, 708 + 1 - 1 + 7 * 0), .Zp(iCond + Offset, 708 + 1 - 1 + 7 * 1), .Zp(iCond + Offset, 708 + 2 - 1 + 7 * 0), .Zp(iCond + Offset, 708 + 2 - 1 + 7 * 1), .Zp(iCond + Offset, 708 + 3 - 1 + 7 * 0), .Zp(iCond + Offset, 708 + 3 - 1 + 7 * 1)))
            Call Assumi(ifl, TIMA, PlastOK)
            If Not PlastOK Then _
               prob.Printa(GlobalRoutines.FormatS(TIMA, .Zp(iCond + Offset, 719 + 1 - 1 + 7 * 0), .Zp(iCond + Offset, 719 + 1 - 1 + 7 * 1), .Zp(iCond + Offset, 719 + 2 - 1 + 7 * 0), .Zp(iCond + Offset, 719 + 2 - 1 + 7 * 1), .Zp(iCond + Offset, 719 + 3 - 1 + 7 * 0), .Zp(iCond + Offset, 719 + 3 - 1 + 7 * 1)))
            Call Assumi(ifl, TIMA, PlastOK)
            If Not PlastOK Then _
               prob.Printa(GlobalRoutines.FormatS(TIMA, .Zp(iCond + Offset, 722 + 1 - 1 + 7 * 0), .Zp(iCond + Offset, 722 + 1 - 1 + 7 * 1), .Zp(iCond + Offset, 722 + 2 - 1 + 7 * 0), .Zp(iCond + Offset, 722 + 2 - 1 + 7 * 1), .Zp(iCond + Offset, 722 + 3 - 1 + 7 * 0), .Zp(iCond + Offset, 722 + 3 - 1 + 7 * 1)))
            'PressEff
            Call Assumi(ifl, TIMA, PlastOK)
            If Not PlastOK Then _
               prob.Printa(GlobalRoutines.FormatS(TIMA, .Zp(iCond + Offset, 771 + 1 - 1 + 7 * 0), .Zp(iCond + Offset, 771 + 1 - 1 + 7 * 1), .Zp(iCond + Offset, 771 + 2 - 1 + 7 * 0), .Zp(iCond + Offset, 771 + 2 - 1 + 7 * 1), .Zp(iCond + Offset, 771 + 3 - 1 + 7 * 0), .Zp(iCond + Offset, 771 + 3 - 1 + 7 * 1)))
            'Q2
            Call Assumi(ifl, TIMA, PlastOK)
            If Not PlastOK Then _
               prob.Printa(GlobalRoutines.FormatS(TIMA, .Zp(iCond + Offset, 774 + 1 - 1 + 7 * 0), .Zp(iCond + Offset, 774 + 1 - 1 + 7 * 1), .Zp(iCond + Offset, 774 + 2 - 1 + 7 * 0), .Zp(iCond + Offset, 774 + 2 - 1 + 7 * 1), .Zp(iCond + Offset, 774 + 3 - 1 + 7 * 0), .Zp(iCond + Offset, 774 + 3 - 1 + 7 * 1)))
            'Q3
            Call Assumi(ifl, TIMA, PlastOK)
            If Not PlastOK Then _
               prob.Printa(GlobalRoutines.FormatS(TIMA, .Zp(iCond + Offset, 785 + 1 - 1 + 7 * 0), .Zp(iCond + Offset, 785 + 1 - 1 + 7 * 1), .Zp(iCond + Offset, 785 + 2 - 1 + 7 * 0), .Zp(iCond + Offset, 785 + 2 - 1 + 7 * 1), .Zp(iCond + Offset, 785 + 3 - 1 + 7 * 0), .Zp(iCond + Offset, 785 + 3 - 1 + 7 * 1)))
            'Fm
            Call Assumi(ifl, TIMA, PlastOK)
            If Not PlastOK Then _
               prob.Printa(GlobalRoutines.FormatS(TIMA, .Zp(iCond + Offset, 788 + 1 - 1 + 7 * 0), .Zp(iCond + Offset, 788 + 1 - 1 + 7 * 1), .Zp(iCond + Offset, 788 + 2 - 1 + 7 * 0), .Zp(iCond + Offset, 788 + 2 - 1 + 7 * 1), .Zp(iCond + Offset, 788 + 3 - 1 + 7 * 0), .Zp(iCond + Offset, 788 + 3 - 1 + 7 * 1)))
            'sigma
            Call Assumi(ifl, TIMA, PlastOK)
            If Not PlastOK Then _
               prob.Printa(GlobalRoutines.FormatS(TIMA, .Zp(iCond + Offset, 741 + 1 - 1 + 7 * 0), .Zp(iCond + Offset, 741 + 1 - 1 + 7 * 1), .Zp(iCond + Offset, 741 + 2 - 1 + 7 * 0), .Zp(iCond + Offset, 741 + 2 - 1 + 7 * 1), .Zp(iCond + Offset, 741 + 3 - 1 + 7 * 0), .Zp(iCond + Offset, 741 + 3 - 1 + 7 * 1)))
            Call Assumi(ifl, TIMA, PlastOK)
            If Not PlastOK Then _
               prob.Printa(GlobalRoutines.FormatS(TIMA, .Zp(iCond + Offset, 741 + 1 - 1 + 7 * 0) * psi, .Zp(iCond + Offset, 741 + 1 - 1 + 7 * 1) * psi, .Zp(iCond + Offset, 741 + 2 - 1 + 7 * 0) * psi, .Zp(iCond + Offset, 741 + 2 - 1 + 7 * 1) * psi, .Zp(iCond + Offset, 741 + 3 - 1 + 7 * 0) * psi, .Zp(iCond + Offset, 741 + 3 - 1 + 7 * 1) * psi))
            If .Zp(iCond + Offset, 769) <= 1 And .Zp(iCond + Offset, 770) <= 1 Then
                Car = " "
                Car1 = " "
            Else
                Car = "NOT"
                Car1 = "NO"
            End If
            Call Assumi(ifl, TIMA)
            If Not PlastOK Then _
               prob.Printa(GlobalRoutines.FormatS(TIMA, Car, .Zp(iCond + Offset, 733)))
            Call Assumi(ifl, TIMA, PlastOK)
            If Not PlastOK Then _
               prob.Printa(GlobalRoutines.FormatS(TIMA, Car))
            Call Assumi(ifl, TIMA, PlastOK)
            If Not PlastOK Then _
               prob.Printa(GlobalRoutines.FormatS(TIMA, Car1))
            Call Assumi(ifl, TIMA, Not PlastOK)
            If PlastOK Then prob.Printa(TIMA)
            ContaPagAgg = ContaPagAgg + 1
            Select Case ContaPagAgg
                Case 1 : Car = "8A"
                Case 2 : Car = "8B"
                Case 3 : Car = "8C"
            End Select
            Call Assumi(ifl, TIMA) : prob.Printa(GlobalRoutines.FormatS(TIMA, Car, "8"))
            Call Assumi(ifl, TIMA)
        End With
    End Sub
    'UPGRADE_NOTE: Shell è stato aggiornato a Shell_Renamed. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1061"'
    Public Sub printAA359(ByRef Shell_Renamed As Short, ByRef iCond As Short, ByRef Offset As Short)
        Dim b, j, m, t As Short
        Dim TIMA As String = ""
        Dim File As String
        Dim thk, Diam As Single
        Dim Tit As String
        Dim prob As RoutBase1.clsProblem = Monitor.Motore.Problem
        If Shell_Renamed = 1 Then
            If ptTipoAA = 8 Then Exit Sub
            CType(Padre.Piastra, wn_FTC).Testatap()
            prob.Print("\par ")
            File = "\RTF\STAMAA359s"
            Tit = "AA-3.5.8 Step 8"
            m = 501
            b = 567
            t = 187
            thk = Padre.SlShelDati(2)
            Diam = Padre.SlShelDati(1)
        Else
            If ptTipoAA = 6 Or ptTipoAA = 7 Or ptTipoAA = 8 Then Exit Sub
            CType(Padre.Piastra, wn_FTC).Testatap()
            prob.Print("\par ")
            File = "\RTF\STAMAA359c" '.TXT"
            Tit = "AA-3.5.9 Step 9"
            m = 344
            b = 515
            t = 358
            thk = Padre.SlChanDati(2)
            Diam = Padre.SlChanDati(1)
        End If
        If A02 > 0 Then
            If A02 > 2 Then
                File = File & "3"
            Else
                File = File & "2"
            End If
            Select Case Padre.Piastra.Rear
                Case 1 : Tit = "UHX-13.5.10 Step 10" 'fisse
                Case 2 : Tit = "UHX-14.5.10 Step 10" 'flottanti
            End Select
        End If
        File = File & ".TXT"
        ifl = FreeFile()
        j = iCond + Offset
        If Not OpenFile(RTrim(Monitor.Motore.Inizio.Archdir) & File, ifl) Then Exit Sub
        Call Assumi(ifl, TIMA) : prob.Printa(GlobalRoutines.FormatS(TIMA, Tit))
        Call Assumi(ifl, TIMA) : prob.Printa(GlobalRoutines.FormatS(TIMA, thk))
        Call Assumi(ifl, TIMA) : prob.Printa(GlobalRoutines.FormatS(TIMA, 1.8 * System.Math.Sqrt(Diam * thk)))
        Stamp(j, m, b, t)
        m = m + 7 : b = b + 7 : t = t + 7
        Stamp(j, m, b, t)
        With Padre.Piastra
            If Shell_Renamed = 1 Then m = 496 Else m = 533
            Call Assumi(ifl, TIMA)
            If junctionOK(Shell_Renamed, j) = -1 Then
                Call Assumi(ifl, TIMA)
                prob.Printa(GlobalRoutines.FormatS(TIMA, .Zp(j, m), .Zp(j, m) * psi))
                Call Assumi(ifl, TIMA)
                prob.Printa(GlobalRoutines.FormatS(TIMA, .Zp(j, m + 1), .Zp(j, m + 1) * psi))
                Call Assumi(ifl, TIMA) 'the design is acceptable (fino a dummy)
                Call Assumi(ifl, TIMA, True)
                Call Assumi(ifl, TIMA, True)
                Call Assumi(ifl, TIMA, True, True)
                Call Assumi(ifl, TIMA) 'the design is not acceptable (fino a dummy)
                Call Assumi(ifl, TIMA, True)
                Call Assumi(ifl, TIMA, True)
                Call Assumi(ifl, TIMA, True, True)
            ElseIf junctionOK(Shell_Renamed, j) = 0 Then
                Call Assumi(ifl, TIMA, True)
                Call Assumi(ifl, TIMA, True)
                Call Assumi(ifl, TIMA, True)
                Call Assumi(ifl, TIMA)
                prob.Printa(GlobalRoutines.FormatS(TIMA, .Zp(j, m), .Zp(j, m) * psi))
                Call Assumi(ifl, TIMA)
                prob.Printa(GlobalRoutines.FormatS(TIMA, .Zp(j, m + 1), .Zp(j, m + 1) * psi))
                Call Assumi(ifl, TIMA)
                Call Assumi(ifl, TIMA, True)
                Call Assumi(ifl, TIMA, True)
                Call Assumi(ifl, TIMA, True, True)
            Else
                Call Assumi(ifl, TIMA, True)
                Call Assumi(ifl, TIMA, True)
                Call Assumi(ifl, TIMA, True)
                Call Assumi(ifl, TIMA, True)
                Call Assumi(ifl, TIMA, True)
                Call Assumi(ifl, TIMA, True)
                Call Assumi(ifl, TIMA)
                prob.Printa(GlobalRoutines.FormatS(TIMA, .Zp(j, m) * psi, .Zp(j, m + 1) * psi))
                Call Assumi(ifl, TIMA)
                prob.Printa(GlobalRoutines.FormatS(TIMA, .Zp(j, m + 1), .Zp(j, m + 1) * psi))
                Call Assumi(ifl, TIMA)
            End If
        End With
        Call Assumi(ifl, TIMA) : FileClose(ifl)
        ContaPagAgg = ContaPagAgg + 1
        If ContaPagAgg = 1 Then prob.Printa("\f2\fs18                   fully documented printout sh. 8A of 8\par ")
        If ContaPagAgg = 2 Then prob.Printa("\f2\fs18                   fully documented printout sh. 8B of 8\par ")
        Exit Sub
    End Sub
    Private Sub Stamp(ByVal j As Short, ByVal m As Short, ByVal b As Short, ByVal t As Short)
        Dim prob As RoutBase1.clsProblem = Monitor.Motore.Problem
        With Padre.Piastra
            Call Assumi(ifl, TIMA)
            prob.Printa(GlobalRoutines.FormatS(TIMA, .Zp(j, m), .Zp(j, m + 1), .Zp(j, m + 2), .Zp(j, m + 3), .Zp(j, m + 4), .Zp(j, m + 5), .Zp(j, m + 6)))
            Call Assumi(ifl, TIMA)
            prob.Printa(GlobalRoutines.FormatS(TIMA, .Zp(j, b), .Zp(j, b + 1), .Zp(j, b + 2), .Zp(j, b + 3), .Zp(j, b + 4), .Zp(j, b + 5), .Zp(j, b + 6)))
            Call Assumi(ifl, TIMA)
            prob.Printa(GlobalRoutines.FormatS(TIMA, .Zp(j, t), .Zp(j, t + 1), .Zp(j, t + 2), .Zp(j, t + 3), .Zp(j, t + 4), .Zp(j, t + 5), .Zp(j, t + 6)))
            Call Assumi(ifl, TIMA)
            prob.Printa(GlobalRoutines.FormatS(TIMA, .Zp(j, t) * psi, .Zp(j, t + 1) * psi, .Zp(j, t + 2) * psi, .Zp(j, t + 3) * psi, .Zp(j, t + 4) * psi, .Zp(j, t + 5) * psi, .Zp(j, t + 6) * psi))
        End With
    End Sub
    Public Function PiastraForata(ByRef E As Single, ByRef n As Single) As Boolean
        If Not Abbassai() Then Exit Function
        If Not Abbassa(1) Then Exit Function
        AA13()
        hsup = hr / p
        If hsup > 2 Then hsup = 2
        rhoi = rho
        dstari = dstar
        pstari = pstar
        mistari = mistar
        hb = H
        Calcolastar()
        E = EstarE
        n = nistar
        PiastraForata = True
    End Function
    Public Sub ResetAmm()
        With CType(Padre.Piastra, wn_FTC)
            .Zp(0, 496) = SS * 1.5
            .Zp(0, 533) = Sc * 1.5
        End With
    End Sub
    Protected Overrides Sub Finalize()
        Dim s As Object
        For Each s In colFM
            colFM.Remove(1)
        Next s
        colFM = Nothing
        MyBase.Finalize()
    End Sub
End Class