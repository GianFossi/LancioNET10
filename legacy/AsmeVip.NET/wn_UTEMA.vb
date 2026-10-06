Option Strict Off
Option Explicit On
Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary 'Namespace for BinaryFormatter
Friend Class wn_UTEMA
    'Private Type ProgDesU
    '    Company As String * 80
    '    Name As String * 80
    '    Vers As String * 3
    '    Date As String * 8
    '    Code As String * 80
    'End Type
    '===========================================================================
    '            VARIABILI RELATIVE ALLE FLANGE DELLA CASSA E DEL MANTELLO
    '===========================================================================
    'Private IndObj As Integer
    Public lKlato, lJinvolucr As Short
    Public CalcoloInCorso As Short
    Public Offset As Short
    Public tfmax, temax As Single
    Private Grafico As frmGrafic
    Private junk As Integer
    Private Strin(2) As String
    Private StriSt(88) As String
    Private uu As String
    Private iPr As Short
    Private Res As Boolean
    Private fact, fact1 As Single
    Private gact, gact1 As Single
    Private cc, cs As Single
    Private Star As wn_AA
    Private objROTFL As typROTFL
    Private primo, Secon As Boolean
    Private StampaAnticipata As Boolean
    Private a As String
    Private d As Single
    Private indBul, jLato As Short
    Private rapp0, TF, rapp1 As Single
    Private Ind As Short
    Private mxmin, mxmax As Single
    Private jj, kk As Short
    Private pxmax, pymax As Single
    Private MAWPIncorso As Short
    Private tfopt, passo, tfvec As Single
    Private tshe, rapopt, mxx As Single
    Private Coll, trxc, ctt As Single
    Private ICAL1, ICAL0, ICALT As Short
    Private HDM, HTM, HGM, MMM As Single
    Private HGM1, HGM2 As Single
    Private HTM1, HTM2 As Single
    Private pcal, pscal As Single
    Private fHmSin, fHdSin As Single
    Private fHt1Sin, fHt2Sin As Single
    Private fHg1Sin, fHg2Sin As Single
    Private Braccioc, Braccios, Braccio As Single
    Private Lato As String
    Private iGia As Boolean
    Private Base As wn_PT
    Private IndProbl As Short
    Private TipoPT As Short '1 UTEMA 2 FTC
    Private Titol(8) As String
    Private strp(8) As String
    Private Nota(2) As String
    Private Titol1(8) As String
    Private px1(6) As Single
    Private pb1(6) As Single
    Private ppx1(6) As Single
    Private mx0(6) As Single
    Private mx00(6) As Single
    Private mxx1(6) As Single
    Private ww(6) As Single
    Private Gcalc(6) As Single
    Private m2(6) As Single
    Private tf1(6) As Single
    Private tshe1(6) As Single
    Private trxc1(6) As Single
    Private trxi1(6) As Single
    Private tmax(6, 1) As Single
    Private tRmax(6, 1) As Single
    Private tras(6, 1) As Single
    Private tma1(6, 1) As Single
    Private fHg1(6) As Single
    Private fHg2(6) As Single
    Private fHd(6) As Single
    Private fHt1(6) As Single
    Private fHt2(6) As Single
    Private fHm(6) As Single
    Private rappS(6) As Single
    Private oopp(6) As Single
    Private NNOTE, nr, NPAGE, NRIGHE, Ntot, NNOTSW As Short
    Private phtsal, psal, pression, pHT, wottt As Single
    Private pressdiff As Single
    Private pressdiffHT As Single
    Private px, rappv, opttf, sx As Single
    Private g3w, mx, g2w, W As Single
    Private m1, tfa, pb, trxi, wot, tRa, m2Sin As Single
    Private Suffix As String
    Private ICAL, IMAX As Short
    Private DatiDes() As strDatiDes
    Private temp As Single
    Private wnflan As wn_flan
    Private MAWPChan(4) As Single
    Private MAWPShel(4) As Single
    Private CalcolaRilass As Boolean
    Private rapp As Single
    '        rappSin          'Rapporto spess.estens./spess.piastra
    '        opttf         'Rapporto spess.piastra/spess.ammissibile
    '        px, sx, mx    'Press,ammiss,mom. su estens.(nei calcoli intermedi)
    '        g2w, g3w, w   'Parametri di RCB-7.1342
    '        trxi, pb, wot, tfa, tRa, m1, m2Sin
    Public Sub New()
        MyBase.New()
        'objROTFL.initialize()
        lKlato = kLato
        lJinvolucr = jInvolucr
        IndProbl = CType(objMemb(Involucr(kLato, jInvolucr).IndObject), wn_PT).Indprobl1
        CType(objMemb(Involucr(kLato, jInvolucr).IndObject), wn_PT).SetPiastra(1)
        TipoPT = 1
        'IndObj = Involucr(kLato, jInvolucr).IndObject
        Problem(IndProbl).Commess = Monitor.Motore.Inizio.CommPulita(icome)
        InitString()
        If AddDistinta > 0 Then
            '   If ApriLeggiU Then 'calcolo automatico
            '                Verboso% = True
            '                Call CarichiU
            'RifCa:          If Verboso% Then
            '                If Not DatiInput Then GoTo MainLoop
            '                End If
            '                Call Corrodi
            '                If Not Esecuzione Then Verboso% = True: Call sCorrodi: GoTo RifCa
            '                If Not ScelSpes Then Verboso% = True: Call sCorrodi: GoTo RifCa
            '                Call sCorrodi
            '                Call Stampe
            '                SuffM$ = "": If LoadCase = 2 Then SuffM$ = "M"
            '321             If TipoStam = 3 Then
            '                    File1$ = RTrim$(Workdir) + "\A" + RTrim$(Lav(0).Arch) + Chr$(92) + Lav(0).File(Lav(0).NumAs) + Suffix$ + SuffM$ + ".RTF"
            '                Else
            '                    File1$ = RTrim$(Workdir) + "\A" + RTrim$(Lav(0).Arch) + Chr$(92) + Lav(0).File(Lav(0).NumAs) + ".VER"
            '                End If
            '                Call RegisRepo(File1$, Suffix$, FileSt$)
            '                   a$ = "Approvi il calcolo effettuato?"
            '                junk% = Alert(4, a$, 7, 4, 11, 36, "SI", "NO", "")
            '                If junk% = 1 Then
            '                        Call ApriScriviU
            '                        GoTo Fine
            '                Else
            '                        Verboso% = True
            '                        GoTo RifCa
            '                End If
            '   End If
        End If
    End Sub

    Private Sub InitString()
        Nota(0) = "NOTES" : Nota(1) = "    "
        strp(1) = "0 "
        strp(2) = "P "
        strp(3) = "P1"
        strp(4) = "Pd"
        strp(5) = "Ph"
        strp(6) = "Ph1"
        NNOTSW = 0
        NRIGHE = 65
    End Sub
    Public Sub Corrodi()
        CorrCodoli()
        If FlChan(IndProbl).DintFla > 0 Then FlChan(IndProbl).DintFla = FlChan(IndProbl).DintFla + 2.0! * cc
        FlChan(IndProbl).CodoMin = FlChan(IndProbl).CodoMin - cc
        FlChan(IndProbl).CodoMax = FlChan(IndProbl).CodoMax - cc
        If FlShel(IndProbl).DintFla > 0 Then FlShel(IndProbl).DintFla = FlShel(IndProbl).DintFla + 2.0! * cs
        FlShel(IndProbl).CodoMin = FlShel(IndProbl).CodoMin - cs
        FlShel(IndProbl).CodoMax = FlShel(IndProbl).CodoMax - cs
        cc = Problem(IndProbl).CorChan
        cs = Problem(IndProbl).CorShel
    End Sub
    Public Function Esecuzione() As Boolean
        Dim a As String
        Dim d As Single
        Base = CType(objMemb(Involucr(kLato, jInvolucr).IndObject), wn_PT)
        Esecuzione = True
        On Error GoTo ErrEx
        pression = Problem(IndProbl).PEsChan
        psal = Problem(IndProbl).PEsShel
        pHT = Problem(IndProbl).PHTChan
        phtsal = Problem(IndProbl).PHTShel
        pressdiff = Problem(IndProbl).DiffPress
        pressdiffHT = Problem(IndProbl).DiffPressHT
        '     Interruttore su piastra saldata-------------------------------------
        If Problem(IndProbl).mart < 2 Then
            '   DatiInt(Indprobl).bdice = 0                               'Flangiatura doppia
            '   IF FlShel(Indprobl).DextFla = 0 THEN DatiInt(Indprobl).bdice = 1    'Flangiatura lato channel
            '   IF FlChan(Indprobl).DextFla = 0 THEN DatiInt(Indprobl).bdice = 2    'Flangiatura lato mantello
        End If
        If DatiInt(IndProbl).bdice = 0 And FlChan(IndProbl).PresDes = FlShel(IndProbl).PresDes Then FlChan(IndProbl).PresDes = FlChan(IndProbl).PresDes * 1.00001
        '------------------------------------------------------------------------
999:
        '     Calcolo geometria guarnizione ------------------------------------
        Select Case DatiInt(IndProbl).bdice
            Case 0
                If Not BullDistinti Then Problem(IndProbl).Tiranti(2) = Problem(IndProbl).Tiranti(1)
                Fl = FlShel(IndProbl)
                Bulloni = Problem(IndProbl).Tiranti(2)
                If Not Base.geomguar(0) Then Esecuzione = False : Exit Function
                FlShel(IndProbl) = Fl
                Fl = FlChan(IndProbl)
                Bulloni = Problem(IndProbl).Tiranti(1)
                If Not Base.geomguar(0) Then Esecuzione = False : Exit Function
                FlChan(IndProbl) = Fl
                DatiInt(IndProbl).wm1 = Math.Max(FlShel(IndProbl).wm1, FlChan(IndProbl).wm1)
                DatiInt(IndProbl).wm2 = Math.Max(FlShel(IndProbl).wm2, FlChan(IndProbl).wm2)
                DatiInt(IndProbl).wot = Math.Max(FlShel(IndProbl).wot, FlChan(IndProbl).wot)
                DatiInt(IndProbl).wm1H = Math.Max(FlShel(IndProbl).wm1H, FlChan(IndProbl).wm1H)
                DatiInt(IndProbl).wm2H = Math.Max(FlShel(IndProbl).wm2H, FlChan(IndProbl).wm2H)
                DatiInt(IndProbl).wotH = Math.Max(FlShel(IndProbl).wotH, FlChan(IndProbl).wotH)
                DatiInt(IndProbl).gef = Math.Min(FlChan(IndProbl).gefinc, FlShel(IndProbl).gefinc) * inc
                'If Problem(IndProbl).mart < 2 Then
                DatiInt(IndProbl).HGP = Math.Max(FlShel(IndProbl).HGP, FlChan(IndProbl).HGP)
                DatiInt(IndProbl).H = Math.Max(FlShel(IndProbl).H, FlChan(IndProbl).H)
                DatiInt(IndProbl).am1 = Math.Max(FlShel(IndProbl).am1, FlChan(IndProbl).am1)
                DatiInt(IndProbl).am2 = Math.Max(FlShel(IndProbl).am2, FlChan(IndProbl).am2)
                DatiInt(IndProbl).am = Math.Max(FlShel(IndProbl).am, FlChan(IndProbl).am)
                DatiInt(IndProbl).hHm = (Problem(IndProbl).Tiranti(1).BoltCiD - DatiInt(IndProbl).gef) / 2.0! / inc
                'End If
            Case 1
                Fl = FlChan(IndProbl)
                Bulloni = Problem(IndProbl).Tiranti(1)
                If Not Base.geomguar(0) Then Esecuzione = False : Exit Function
                FlChan(IndProbl) = Fl
                DatiInt(IndProbl).wm1 = FlChan(IndProbl).wm1
                DatiInt(IndProbl).wm2 = FlChan(IndProbl).wm2
                DatiInt(IndProbl).wot = FlChan(IndProbl).wot
                DatiInt(IndProbl).wm1H = FlChan(IndProbl).wm1H
                DatiInt(IndProbl).wm2H = FlChan(IndProbl).wm2H
                DatiInt(IndProbl).wotH = FlChan(IndProbl).wotH
                DatiInt(IndProbl).gef = FlShel(IndProbl).DintFla 'perché????
                DatiInt(IndProbl).ThkShe = FlShel(IndProbl).CodoMin
                'If Problem(IndProbl).mart < 2 Then
                DatiInt(IndProbl).HGP = FlChan(IndProbl).HGP
                DatiInt(IndProbl).H = FlChan(IndProbl).H
                DatiInt(IndProbl).am1 = FlChan(IndProbl).am1
                DatiInt(IndProbl).am2 = FlChan(IndProbl).am2
                DatiInt(IndProbl).am = FlChan(IndProbl).am
                DatiInt(IndProbl).hHm = (Problem(IndProbl).Tiranti(1).BoltCiD - FlShel(IndProbl).DintFla) / 2.0! / inc
                'End If
            Case 2
                Fl = FlShel(IndProbl)
                Bulloni = Problem(IndProbl).Tiranti(2)
                If Not Base.geomguar(0) Then Esecuzione = False : Exit Function
                FlShel(IndProbl) = Fl
                DatiInt(IndProbl).wm1 = FlShel(IndProbl).wm1
                DatiInt(IndProbl).wm2 = FlShel(IndProbl).wm2
                DatiInt(IndProbl).wot = FlShel(IndProbl).wot
                DatiInt(IndProbl).wm1H = FlShel(IndProbl).wm1H
                DatiInt(IndProbl).wm2H = FlShel(IndProbl).wm2H
                DatiInt(IndProbl).wotH = FlShel(IndProbl).wotH
                If FlChan(IndProbl).DintFla < 0 Then
                    DatiInt(IndProbl).gef = 0 ' caso di PT incassata
                Else
                    DatiInt(IndProbl).gef = FlChan(IndProbl).DintFla 'sbagliato: vale solo per calcolo bulloni automatico
                End If
                DatiInt(IndProbl).ThkShe = FlChan(IndProbl).CodoMin
                'If Problem(IndProbl).mart < 2 Then
                DatiInt(IndProbl).HGP = FlShel(IndProbl).HGP
                DatiInt(IndProbl).H = FlShel(IndProbl).H
                DatiInt(IndProbl).am1 = FlShel(IndProbl).am1
                DatiInt(IndProbl).am2 = FlShel(IndProbl).am2
                DatiInt(IndProbl).am = FlShel(IndProbl).am
                DatiInt(IndProbl).hHm = (Problem(IndProbl).Tiranti(2).BoltCiD - FlShel(IndProbl).DintFla) / 2.0! / inc
                'End If
        End Select
        '------------------------------------------------------------------------
        Call SpazBull(DatiInt(IndProbl).BoltSpc, DatiInt(IndProbl).SWITCH_Renamed, 0, 1)
        '----------diametro esterno--------------------------------------------
        If Not DiamExt(0) Then Esecuzione = False : Exit Function
        '------------------------------------------------------------------------
1110:   wot = 0.5 * (DatiInt(IndProbl).am + DatiInt(IndProbl).AreaBol) * Problem(IndProbl).Tiranti(1).AllBRoo
        If Problem(IndProbl).SERRA = 0 Then wot = DatiInt(IndProbl).AreaBol * Problem(IndProbl).Tiranti(1).AllBRoo
        If Problem(IndProbl).mart = 1 And wot > DatiInt(IndProbl).wm1 Then wottt = DatiInt(IndProbl).wm1 Else wottt = wot
        '   wm1: required bolt loat for operating
        '   wot: design bolt load in operating
        '   wottt: =wot se MART=0; =wm1 se MART=1
        '-----------------------------------------------------------------------
        DatiInt(IndProbl).FattoNi = nifact()
        If (DatiInt(IndProbl).FattoNi = 0) Then Exit Function
        d = DatiInt(IndProbl).gef / inc 'perché?
        If d <= 0 Then d = FlShel(IndProbl).gefinc
        W = 0.5 * (Problem(IndProbl).TSheDes / inc - d) 'boh? per bulloni automatici
        g2w = d ^ 2 * W
        g3w = g2w * d
        If Problem(IndProbl).TipCalc = 2 Then
            If Problem(IndProbl).TSheThk = 0 Or Problem(IndProbl).TExtThk = 0 Then
                MessageBox.Show("E' stato impostato un calcolo di verifica," & vbCrLf & "ma non sono stati forniti gli spessori" & vbCrLf & "della piastra e dell'estensione flangiata.")
                Esecuzione = False
                Exit Function
            End If
            Problem(IndProbl).rappSin = Problem(IndProbl).TExtThk / (Problem(IndProbl).TSheThk - Problem(IndProbl).CorShel - Math.Max(Problem(IndProbl).CavChan, Problem(IndProbl).CorChan))
        End If
        rappv = Problem(IndProbl).rappSin
        ' If DatiInt(IndProbl).bdice = 0 Then
        '     DatiInt(IndProbl).FPiastr = 1.25
        ' Else
        '     DatiInt(IndProbl).FPiastr = (17 - 100 * (DatiInt(IndProbl).ThkShe / DatiInt(IndProbl).gef)) / 12
        '     If DatiInt(IndProbl).FPiastr > 1.25 Then DatiInt(IndProbl).FPiastr = 1.25
        '     If DatiInt(IndProbl).FPiastr < 1 Then DatiInt(IndProbl).FPiastr = 1
        ' End If
        '---------------------------------------------------------------------------
        '***********************Inizio loop su condizioni di carico*************
        '      ICAL=1     ricalcolo giunto flangiato
        '      ICAL=2     operating lato flangia
        '      ICAL=3     operating lato saldato
        '      ICAL=4     calcolo a pressione differenziale
        '      ICAL=5     seating
        StampaAnticipata = False
        If Problem(IndProbl).TipCalc = 3 And Not VerificandoPI Then
            Esecuzione = CalcoloRilass()
            VerificandoPI = False
        Else
            Esecuzione = Rifair(0)
        End If
FineX:  Exit Function
ErrEx:  'PRINT "Errore in Esecuzione"; ERR; ERL: u$ = INPUT$(1): END
        Esecuzione = False
        ' Resume
        a = "Consiglio di ricontrollare tutti i dati" & vbCrLf
        a = a & "(" & Err.Description & ")"
        MessageBox.Show(a)
        'Stop
        ' Resume
        Resume FineX
    End Function
    Private Function FinalCheck(ByRef mxx As Single) As Boolean
        Dim Coll, TF, trxc As Single
        Dim tfc As Single
        Dim a As String
        trxi = tRa / inc
        TF = tfa / inc
        mx = mx0(IMAX)
        Manual(IMAX)
        px = ppx1(IMAX)
        Call Moment(px, TF, mxx, pb, Coll)
        'px = ppx1(IMAX) + pb
        trxc = troutin(px, mxx, Coll)
        tfc = tflex(DatiInt(IndProbl).gef / inc, px + pb)
        'ctt = Problem(IndProbl).CavChan: If cc > Problem(IndProbl).CavChan Then ctt = cc
        tfc = tfc * inc + ctt
        trxc = trxc * inc '- Problem(Indprobl).CorChan * DatiInt(Indprobl).Corroso
        'IF DatiInt(Indprobl).bdice = 0 THEN trxc = trxc - Problem(Indprobl).CorShel * DatiInt(Indprobl).Corroso
        TF = TF * inc
        trxi = trxi * inc
        FinalCheck = True
        If (tfc > TF Or trxc > trxi Or trxi > TF) Then
            FinalCheck = False
            a = "Spessori scelti inaccettabili !"
            If (tfc > TF) Then a = a & "|Spessore piastra insufficiente: " & GlobalRoutines.myStr(tfc * kLength, 3, 2, False) & ">" & GlobalRoutines.myStr(TF * kLength, 3, 2, False)
            If (trxc > trxi) Then a = a & "|Spessore estensione insufficiente: " & GlobalRoutines.myStr(trxc * kLength, 3, 2, False) & ">" & GlobalRoutines.myStr(trxi * kLength, 3, 2, False)
            If (trxi > TF) Then a = a & "|Spessore estensione maggiore di spessore piastra: " & GlobalRoutines.myStr(trxi * kLength, 3, 2, False) & ">" & GlobalRoutines.myStr(TF * kLength, 3, 2, False)
            MessageBox.Show(Monitor.Motore.Inizio.ConvertiCr(a))
        End If
    End Function
    Sub MAWP()
        Dim AllFOpeS, AllFRooS As Single
        Dim temaxsav As Single = temax
        Dim tfmaxsav As Single = tfmax
        MAWPIncorso = 1
        tfa = Problem(IndProbl).TSheThk
        tRa = Problem(IndProbl).TExtThk
        AllFOpeS = Problem(IndProbl).AllFOpe
        AllFRooS = Problem(IndProbl).AllFRoo
        Problem(IndProbl).AllFOpe = AllFRooS
        Cerca()
        MAWPChan(1) = pression
        MAWPShel(1) = psal
        If Problem(IndProbl).PDIFF = 0 Then
            MAWPChan(1) = pressdiff
            MAWPShel(1) = pressdiff
        End If
        Problem(IndProbl).AllFOpe = AllFOpeS
        Cerca()
        MAWPChan(2) = pression
        MAWPShel(2) = psal
        If Problem(IndProbl).PDIFF = 0 Then
            MAWPChan(2) = pressdiff
            MAWPShel(2) = pressdiff
        End If
        Call Corrodi()
        Problem(IndProbl).AllFOpe = AllFRooS
        Cerca()
        MAWPChan(3) = pression
        MAWPShel(3) = psal
        If Problem(IndProbl).PDIFF = 0 Then
            MAWPChan(3) = pressdiff
            MAWPShel(3) = pressdiff
        End If
        Problem(IndProbl).AllFOpe = AllFOpeS
        Cerca()
        MAWPChan(4) = pression
        MAWPShel(4) = psal
        If Problem(IndProbl).PDIFF = 0 Then
            MAWPChan(4) = pressdiff
            MAWPShel(4) = pressdiff
        End If
        Problem(IndProbl).AllFOpe = AllFOpeS : Problem(IndProbl).AllFRoo = AllFRooS
        Call sCorrodi()
        MAWPIncorso = 0
        temax = temaxsav : tfmax = tfmaxsav
    End Sub
    Private Sub Cerca()
        Dim ic As Short
        pression = Problem(IndProbl).PEsChan
        psal = Problem(IndProbl).PEsShel
        pressdiff = Problem(IndProbl).DiffPress
        ic = 0
        Res = Rifair(1)
        Do
            If Problem(IndProbl).PDIFF = 0 Then 'press diff
                tfmax = 0
                If (tmax(4, 1) > tfmax) Then tfmax = tmax(4, 1)
                If (tma1(4, 1) > tfmax) Then tfmax = tma1(4, 1)
                fact = tfa / tfmax
                fact1 = tRa / tRmax(4, 1) : If fact1 > fact Then fact = fact1 '030506
                If fact = 0 Then fact = 1 : fact1 = 1
                tfmax = 0
                If (tmax(5, 1) > tfmax) Then tfmax = tmax(5, 1)
                If (tma1(5, 1) > tfmax) Then tfmax = tma1(5, 1)
                gact = tfa / tfmax
                gact1 = tRa / tRmax(5, 1) : If gact1 > gact Then gact = gact1 '030506
                If gact < fact Then gact = fact '030506
                pressdiff = pressdiff * gact ^ 0.7
                If System.Math.Abs(gact - 1) < 0.0001 Or ic > 100 Then Exit Do
                ic = ic + 1
            Else
                tfmax = 0
                If (tmax(2, 1) > tfmax) Then tfmax = tmax(2, 1)
                If (tma1(2, 1) > tfmax) Then tfmax = tma1(2, 1)
                fact = tfa / tfmax
                fact1 = tRa / tRmax(2, 1) : If fact1 > fact Then fact = fact1 '030506
                If fact = 0 Then fact = 1 : fact1 = 1
                pression = pression * fact ^ 0.7
                tfmax = 0
                If (tmax(3, 1) > tfmax) Then tfmax = tmax(3, 1)
                If (tma1(3, 1) > tfmax) Then tfmax = tma1(3, 1)
                gact = tfa / tfmax
                gact1 = tRa / tRmax(3, 1) : If gact1 > gact Then gact = gact1 '030506
                psal = psal * gact ^ 0.7
                If System.Math.Abs(fact - 1) < 0.0001 And System.Math.Abs(gact - 1) < 0.0001 Or ic > 100 Then Exit Do
                ic = ic + 1
            End If
            Res = Rifair(1)
            If Not Res Then Exit Do
        Loop
    End Sub
    Private Sub Moment(ByRef P0 As Single, ByRef TF As Single, ByRef mxx As Single, ByRef pb As Single, ByRef Coll As Single)
        ' Dim mxxs, pbs As Single
        Coll = 1
        mxx = mxroutin(-1.0!, P0, TF, 1.0!)
        pb = pbrou(mxx)
        'If DatiInt(IndProbl).bdice = 0 And Problem(IndProbl).NumColl <> 0 Then
        '   mxxs = mxx: pbs = pb
        '   mxx = mxroutin(-1!, P0, TF, 0!)
        '   pb = pbrou(mxx)
        ' If Abs(pb + P0) < Abs(pbs + P0) Then
        '     pb = pbs
        '     mxx = mxxs
        ' Else
        '   Coll = 0
        ' End If
        'End If
    End Sub
    Private Function mxroutin(ByRef rtx As Single, ByRef pp As Single, ByRef TF As Single, ByRef Coll As Single) As Single
        Dim mx2, mx1, d As Single
        If rtx < 0.0! And TF > 0 Then
            rtx = (trxi / TF) ^ 3
        Else
            If TF > -1000 Then rtx = 1
        End If
        d = DatiInt(IndProbl).gef / inc
        If d <= 0 Then d = FlShel(IndProbl).gefinc
        mx1 = (0.069 / DatiInt(IndProbl).FattoNi) * g3w * DatiInt(IndProbl).FPiastr ^ 3 * pp * rtx - mx * Coll * d - 0.39 * g3w * pp
        mx2 = d + (1.37 / DatiInt(IndProbl).FattoNi) * rtx * W
        mxroutin = mx1 / mx2
    End Function
    Private Function nifact() As Single
        Dim rpade As Single
        Dim a As String
        rpade = Problem(IndProbl).TubPass / Problem(IndProbl).TubDiam
        If Problem(IndProbl).TipPass = 1 Then nifact = 1 - (0.785 / (rpade ^ 2)) : Exit Function
        If Problem(IndProbl).TipPass = 0 Then nifact = 1 - (0.907 / (rpade ^ 2)) : Exit Function
        a = "Tipo passo non contemplato|(sub nifact)    npas= " & Str(Problem(IndProbl).TipPass)
        MessageBox.Show(Monitor.Motore.Inizio.ConvertiCr(a))
        nifact = 0
    End Function
    Private Function pbrou(ByRef mxx As Single) As Single
        Dim d As Single
        d = DatiInt(IndProbl).gef / inc
        If d <= 0 Then d = FlShel(IndProbl).gefinc
        pbrou = -6.2 * mxx / (DatiInt(IndProbl).FPiastr ^ 2 * d ^ 3)
    End Function

    Private Function Rifair(ByRef mode As Short) As Boolean
        Lato = "??"
        Rifair = True
        Try
            Titol(1) = ""
            Titol(2) = "Operating with tube-side pressure  (set P{\sub s}=0) "
            Titol(3) = "Operating with shell-side pressure (set P{\sub t}=0)  "
            Titol(4) = "Operating with differential pressure (max in channel)"
            Titol(5) = "Operating with differential pressure (max in shell)"
            Titol(6) = "Operating with tube-side pressure  (set P{\sub s}=-15 psi)"
            Titol(7) = "Operating with shell-side pressure (set P{\sub t}=-15 psi) "
            Titol(8) = "Seating condition"
            Titol1(1) = ""
            Titol1(2) = "Operating with tube-side pressure"
            Titol1(3) = "Operating with shell-side pressure"
            Titol1(4) = "Operating with differential pressure (max in channel)"
            Titol1(5) = "Operating with differential pressure (max in shell)"
            Titol1(6) = "Operating with tube-side pressure"
            Titol1(7) = "Operating with shell-side pressure"
            Titol1(8) = "Seating condition"
            ICAL0 = 1 : ICAL1 = 6 : If mode = 1 Or Problem(IndProbl).mart = 2 Then ICAL0 = 2 : ICAL1 = 5
            'Select Case DatiInt(IndProbl).bdice        '160206
            '    Case 0                                 '160206
            '    Case 1 : FlChan(IndProbl).DintFla = -1 '160206 030506
            '    Case 2 : FlShel(IndProbl).DintFla = -1 '160206 030506
            'End Select                                 '160206
            If (Problem(IndProbl).NOGRAF = 1) And mode = 0 Then
                Grafico = New frmGrafic
                Routines.DoveDisegno = Grafico.Picture1
            End If
            For ICAL = ICAL0 To ICAL1
                ICALT = ICAL
                ' pcal = pression: pscal = psal errore 07/05/2002
                pcal = 0 : pscal = 0
                If (Problem(IndProbl).Vacuum = 1 Or Problem(IndProbl).Vacuum = 3) And Problem(IndProbl).PDIFF > 0 And ICAL = 2 And Not VerificandoPI Then
                    pscal = -15 : ICALT = 4 ': Problem(Indprobl).PDIFF = 0      ????
                    Titol(2) = Titol(6)
                    Titol1(2) = Titol1(6)
                End If
                If Not (Problem(IndProbl).Vacuum = 2 Or Problem(IndProbl).Vacuum = 3) And Problem(IndProbl).PDIFF > 0 And ICAL = 3 Then
                    pcal = -15 : ICALT = 4 ': Problem(Indprobl).PDIFF = 0       ????
                    Titol(3) = Titol(7)
                    Titol1(3) = Titol1(7)
                End If
                If ICALT = 6 Then
                    Titol(6) = Titol(8)
                    Titol1(6) = Titol1(8)
                End If
                If (Problem(IndProbl).PDIFF <> 0 And (ICAL = 4 Or ICAL = 5)) Then GoTo Contcal
                If (ICAL = 2 And pression = 0.0! Or ICAL = 3 And psal = 0.0!) Then
                    px1(ICAL) = 0.0!
                    GoTo Contcal
                End If
                '-----------AUTOMATICO-/-MANUALE---------------------------------------
                If Problem(IndProbl).mart < 2 Then
                    If Not Autom() Then GoTo Contcal
                Else
                    Manual(ICAL)
                End If
                mx = m1
                If System.Math.Abs(m2Sin) > System.Math.Abs(mx) Then mx = m2Sin 'MOMENTO DI FLANGIA RCB-7.162
                If FlChan(IndProbl).DintFla < 0 Then
                    d = FlShel(IndProbl).gefinc
                Else
                    d = DatiInt(IndProbl).gef / inc
                End If
                If d <= 0 Then
                    'd = FlShel(IndProbl).gefinc
                    MessageBox.Show("Il diametro di calcolo " & Lato & "-side non è definito")
                    Rifair = False
                    Exit Function
                End If
                Gcalc(ICAL) = d * inc
                ww(ICAL) = W
                '--------------------------------------------------------------------------
                If (Problem(IndProbl).PDIFF = 0 And (ICAL = 2 Or ICAL = 3)) Then GoTo Contcal
                If Not Carichi(ICAL) Then Return False
                P0 = px
                '  rapp = 1
                '  If CalcolaRilass Then CalcoloCompleto
                If Not MAWPIncorso = 1 Then
                    mx00(ICAL) = m1 '* rapp
                    m2(ICAL) = m2Sin
                    ppx1(ICAL) = P0
                End If
                '---------------------------------------------------------------------------
                If DatiInt(IndProbl).bdice = 0 Or DatiInt(IndProbl).gef <= 0 Then
                    DatiInt(IndProbl).FPiastr = 1.25
                Else
                    DatiInt(IndProbl).FPiastr = (17 - 100 * (DatiInt(IndProbl).ThkShe / DatiInt(IndProbl).gef)) / 12
                    If DatiInt(IndProbl).FPiastr > 1.25 Then DatiInt(IndProbl).FPiastr = 1.25
                    If DatiInt(IndProbl).FPiastr < 1 Then DatiInt(IndProbl).FPiastr = 1
                End If
                '       SOLUZIONE (RCB-7.1342)
1320:           TF = tflex(d, px)
                If TF = 0 Then TF = 1.0!
                If rappv > 1 Then rappv = 1
                If rappv > 0 Then
                    rapp0 = rappv : rapp1 = rappv : passo = 0.1
                Else
                    rapp0 = 0.5 : rapp1 = 1.0! : passo = 0.1 : tfopt = 1000000000.0#
                End If
                tfvec = TF
                trxi = TF * (rapp0 + rapp1) / 2
affin:
                For Problem(IndProbl).rappSin = rapp0 To rapp1 Step passo
                    If Not trxno() Then Return False
                    If TF < tfopt Then tfopt = TF : rapopt = Problem(IndProbl).rappSin
                Next
                If rappv = 0 Then
                    If rapopt = 0.5 Or rapopt = 1.0! Or passo < 0.011 Then
                        Problem(IndProbl).rappSin = rapopt
                        If Not trxno() Then Return False
                    Else
                        rapp0 = rapopt - passo : rapp1 = rapopt + passo : passo = passo / 10
                        GoTo affin
                    End If
                Else
                    Problem(IndProbl).rappSin = rappv
                End If
                tshe = tshear(P0)
                If Not MAWPIncorso = 1 Then
                    rappS(ICAL) = Problem(IndProbl).rappSin
                    oopp(ICAL) = opttf
                    px1(ICAL) = px
                    pb1(ICAL) = pb
                    mxx1(ICAL) = mxx
                    tf1(ICAL) = TF
                    tshe1(ICAL) = tshe
                    trxc1(ICAL) = trxc
                    trxi1(ICAL) = trxi
                    mx0(ICAL) = mx * Coll
                End If
                ctt = Problem(IndProbl).CavChan : If cc > Problem(IndProbl).CavChan Then ctt = cc
                tmax(ICAL, MAWPIncorso) = TF * inc + cs + ctt
                tma1(ICAL, MAWPIncorso) = tshe * inc '+ cs + cc
                tRmax(ICAL, MAWPIncorso) = trxi * inc '- Problem(Indprobl).CorChan * DatiInt(Indprobl).Corroso
                'IF DatiInt(Indprobl).bdice = 0 THEN tRmax(ICAL) = tRmax(ICAL) - Problem(Indprobl).CorShel * DatiInt(Indprobl).Corroso
                tras(ICAL, MAWPIncorso) = inc * (d * System.Math.Sqrt(1.9 * System.Math.Abs(mxx) / (Problem(IndProbl).AllFOpe * psi * d ^ 3)))                ' - Problem(Indprobl).CorChan * DatiInt(Indprobl).Corroso
                '--------------------------------------------------------------------
                '                 GENERAZIONE GRAFICO
                px = P0
                If (Problem(IndProbl).NOGRAF = 1) And mode = 0 Then
                    mxmin = -mx - 0.39 * P0 * g2w
                    mxmax = mxroutin(-1.0!, P0, TF, 1.0!)
                    If (mxmax < mxmin) Then mxmin = mxmax : mxmax = -mx - 0.39 * P0 * g2w
                    Routines.Scala(mxmin - (mxmax - mxmin) / 5, mxmax + (mxmax - mxmin) / 5, -TF / 5, 2 * TF + TF / 5, 1)
                    Routines.DoveDisegnog.Clear(Color.White)
                    Call grafic(mxmin, mxmax, 0, 2 * TF, 0, Titol1(ICAL), mxx, TF)
                    '--------------------------------------------------------------------------
                    '        COMPLETAMENTO GRAFICO
                    Call grafic(mxmin, mxmax, 0, 2 * TF, 1, "", mxx, TF)
                    Grafico.ShowDialog()
                    If Not Grafico.OK Then Return False
                    '--------------------------------------------------------------------------
                End If
                '---------------------------------------------------------------------------
Contcal:
            Next ICAL
        Catch e As Exception
            MessageBox.Show(e.Message + vbCrLf + e.StackTrace)
            Rifair = False
        End Try
        If (Problem(IndProbl).NOGRAF = 1) And mode = 0 Then Grafico.Dispose()
    End Function
    Public Function trxno() As Boolean
        trxno = True
        opttf = 1.0!
trxno1:
        trxi = Problem(IndProbl).rappSin * tfvec
        Call Moment(P0, TF, mxx, pb, Coll)
        px = P0 + pb
3111:   trxc = troutin(P0, mxx, Coll)
        If trxc = 0 Then Return False
3114:   TF = tflex(d, px)
        TF = TF * opttf
        If (System.Math.Abs(tfvec - TF) / tfvec > 0.0001) Then
3118:       tfvec = TF
            GoTo trxno1
        End If
        If trxi < trxc Then
3122:       opttf = opttf + 0.02
            GoTo trxno1
        End If
    End Function
    Public Function Autom() As Boolean
        Autom = True
        If (ICAL = 1) Then
            Fl = FlShel(IndProbl)
            Bulloni = Problem(IndProbl).Tiranti(2)
            CType(objMemb(Involucr(kLato, jInvolucr).IndObject), wn_PT).BracFla()
            FlShel(IndProbl) = Fl
            If CType(objMemb(Involucr(kLato, jInvolucr).IndObject), wn_PT).SlChanDati(1) > -2 Then '030506
                Fl = FlChan(IndProbl)
                Bulloni = Problem(IndProbl).Tiranti(1)
                objMemb(Involucr(kLato, jInvolucr).IndObject).BracFla()
                FlChan(IndProbl) = Fl
            End If
            If DatiInt(IndProbl).bdice = 1 Then DatiInt(IndProbl).hHg = FlChan(IndProbl).hHg
            If DatiInt(IndProbl).bdice = 2 Then DatiInt(IndProbl).hHg = FlShel(IndProbl).hHg
        Else
            If DatiInt(IndProbl).bdice > 0 And FlChan(IndProbl).DintFla < 0 Then
                DatiInt(IndProbl).rrr = ((Problem(IndProbl).Tiranti(1).BoltCiD - DatiInt(IndProbl).gef) / 2 - DatiInt(IndProbl).ThkShe) / inc
                DatiInt(IndProbl).hHd = DatiInt(IndProbl).rrr + 0.5 * DatiInt(IndProbl).ThkShe / inc
                DatiInt(IndProbl).hHt = (DatiInt(IndProbl).rrr + DatiInt(IndProbl).ThkShe / inc + DatiInt(IndProbl).hHg) / 2
            End If
        End If
        '--------------------------------------------
        Select Case ICALT
            Case 1
                If Not FlChan(IndProbl).DintFla < 0 Then
1150:               FlChan(IndProbl).fHd = pression * (pi * (FlChan(IndProbl).DintFla / inc) ^ 2 / 4)
                    FlChan(IndProbl).fHt = pression * pi / 4 * (FlChan(IndProbl).gefinc ^ 2 - (FlChan(IndProbl).DintFla / inc) ^ 2)
                    FlChan(IndProbl).fHg = wottt - FlChan(IndProbl).H
                    FlShel(IndProbl).fHd = pression * (pi * (FlShel(IndProbl).DintFla / inc) ^ 2 / 4)
                    FlShel(IndProbl).fHt = pression * pi / 4 * (FlShel(IndProbl).gefinc ^ 2 - (FlShel(IndProbl).DintFla / inc) ^ 2)
                    FlShel(IndProbl).fHg = wottt - FlShel(IndProbl).H
                    fHmSin = 0
                End If
            Case 2
                If Not FlChan(IndProbl).DintFla < 0 Then
                    fHdSin = 0
                    fHmSin = pression * pi / 4 * (DatiInt(IndProbl).gef / inc) ^ 2
                    If DatiInt(IndProbl).bdice = 2 Then fHdSin = -fHmSin
                    fHt1Sin = pression * pi / 4 * (FlChan(IndProbl).gefinc ^ 2 - (DatiInt(IndProbl).gef / inc) ^ 2)
                    If DatiInt(IndProbl).bdice = 2 Then fHt1Sin = 0
                    fHt2Sin = 0
                    fHg1Sin = wottt - (pi / 4) * FlChan(IndProbl).gefinc ^ 2 * pression
                    If DatiInt(IndProbl).bdice = 2 Then fHg1Sin = 0
                    fHg2Sin = -wottt
                    If DatiInt(IndProbl).bdice = 1 Then fHg2Sin = 0
                End If
            Case 3
                If Not FlChan(IndProbl).DintFla < 0 Then
                    fHdSin = 0
                    fHmSin = -psal * pi * (DatiInt(IndProbl).gef / inc) ^ 2 / 4
                    If DatiInt(IndProbl).bdice = 1 Then fHdSin = -fHmSin
                    fHt1Sin = 0
                    fHt2Sin = -psal * pi / 4 * (FlShel(IndProbl).gefinc ^ 2 - (DatiInt(IndProbl).gef / inc) ^ 2)
                    If DatiInt(IndProbl).bdice = 1 Then fHt2Sin = 0
                    fHg1Sin = wottt
                    If DatiInt(IndProbl).bdice = 2 Then fHg1Sin = 0
                    fHg2Sin = -wottt + pi / 4.0! * FlShel(IndProbl).gefinc ^ 2 * psal
                    If DatiInt(IndProbl).bdice = 1 Then fHg2Sin = 0
                End If
            Case 4
                If Not FlChan(IndProbl).DintFla < 0 Then
                    fHdSin = 0
                    fHmSin = pressdiff * pi / 4 * (DatiInt(IndProbl).gef / inc) ^ 2
                    If DatiInt(IndProbl).bdice = 2 Then fHdSin = -fHmSin
                    fHt1Sin = pressdiff * pi / 4 * (FlChan(IndProbl).gefinc ^ 2 - (DatiInt(IndProbl).gef / inc) ^ 2)
                    If DatiInt(IndProbl).bdice = 2 Then fHt1Sin = 0
                    fHt2Sin = 0
                    fHg1Sin = wottt - (pi / 4) * FlChan(IndProbl).gefinc ^ 2 * pression
                    If DatiInt(IndProbl).bdice = 2 Then fHg1Sin = 0
                    fHg2Sin = -wottt + pi / 4.0! * FlShel(IndProbl).gefinc ^ 2 * psal
                    If DatiInt(IndProbl).bdice = 1 Then fHg2Sin = 0
                End If
            Case 5
                If Not FlChan(IndProbl).DintFla < 0 Then
                    fHdSin = 0
                    fHmSin = -pressdiff * pi * (DatiInt(IndProbl).gef / inc) ^ 2 / 4
                    If DatiInt(IndProbl).bdice = 1 Then fHdSin = -fHmSin
                    fHt1Sin = 0
                    fHt2Sin = -pressdiff * pi / 4 * (FlShel(IndProbl).gefinc ^ 2 - (DatiInt(IndProbl).gef / inc) ^ 2)
                    If DatiInt(IndProbl).bdice = 1 Then fHt2Sin = 0
                    fHg1Sin = wottt - (pi / 4) * FlChan(IndProbl).gefinc ^ 2 * pression
                    If DatiInt(IndProbl).bdice = 2 Then fHg1Sin = 0
                    fHg2Sin = -wottt + pi / 4.0! * FlShel(IndProbl).gefinc ^ 2 * psal
                    If DatiInt(IndProbl).bdice = 1 Then fHg2Sin = 0
                End If
            Case 6
                If Not FlChan(IndProbl).DintFla < 0 Then
1190:               fHdSin = 0
                    fHmSin = 0
                    fHt1Sin = 0
                    fHt2Sin = 0
                    fHg1Sin = wot
                    fHg2Sin = -wot
                    If DatiInt(IndProbl).bdice = 2 Then fHg1Sin = 0
                    If DatiInt(IndProbl).bdice = 1 Then fHg2Sin = 0
                    If DatiInt(IndProbl).bdice = 0 Then
                        fHg1Sin = 0
                        fHg2Sin = -wot
                    End If
                End If
        End Select
        If ICALT < 5 And DatiInt(IndProbl).bdice = 0 Then fHg2Sin = fHg2Sin * System.Math.Abs(Problem(IndProbl).Tiranti(1).NumColl) / Problem(IndProbl).Tiranti(1).NumBolt
        '---------------------------------------------
1300:   If ICAL = 1 Then
            If Not FlChan(IndProbl).DintFla < 0 Then
                HDM = FlChan(IndProbl).hHd * FlChan(IndProbl).fHd
                HTM = FlChan(IndProbl).hHt * FlChan(IndProbl).fHt
                HGM = FlChan(IndProbl).hHg * FlChan(IndProbl).fHg
                FlChan(IndProbl).m1 = HDM + HTM + HGM
                FlChan(IndProbl).m2 = wot * FlChan(IndProbl).hHg
                HDM = FlShel(IndProbl).hHd * FlShel(IndProbl).fHd
                HTM = FlShel(IndProbl).hHt * FlShel(IndProbl).fHt
                HGM = FlShel(IndProbl).hHg * FlShel(IndProbl).fHg
                FlShel(IndProbl).m1 = HDM + HTM + HGM
                FlShel(IndProbl).m2 = wot * FlShel(IndProbl).hHg
            Else
                FlShel(IndProbl).m1 = FlShel(IndProbl).wm1 * FlShel(IndProbl).hHg
                FlShel(IndProbl).m2 = FlShel(IndProbl).wm2 * FlShel(IndProbl).hHg
                FlChan(IndProbl).m1 = 0 '160206
                FlChan(IndProbl).m2 = 0 '160206
            End If
            Return False
        Else
            If DatiInt(IndProbl).bdice > 0 Then
                If Not FlChan(IndProbl).DintFla < 0 Then
                    MMM = DatiInt(IndProbl).hHm * fHmSin 'p . Gef
                    HDM = DatiInt(IndProbl).hHd * fHdSin
                    HGM1 = FlChan(IndProbl).hHg * fHg1Sin
                    HGM2 = FlShel(IndProbl).hHg * fHg2Sin
                    HTM1 = FlChan(IndProbl).hHt * fHt1Sin
                    HTM2 = FlShel(IndProbl).hHt * fHt2Sin
                    m1 = HDM + HTM1 + HTM2 + HGM1 + HGM2 + MMM
                Else
                    m1 = -wot * DatiInt(IndProbl).hHg
                End If
            Else
                m1 = -DatiInt(IndProbl).wm1 * FlShel(IndProbl).hHg
                If ICALT < 5 Then m1 = m1 * System.Math.Abs(Problem(IndProbl).Tiranti(1).NumColl) / Problem(IndProbl).Tiranti(1).NumBolt
            End If
        End If
        '--------------------------------------------------------------------------
        fHd(ICAL) = fHdSin
        fHt1(ICAL) = fHt1Sin
        fHt2(ICAL) = fHt2Sin
        fHg1(ICAL) = fHg1Sin
        fHg2(ICAL) = fHg2Sin
        fHm(ICAL) = fHmSin
        '-------------------------------------------------------------------------
        m2Sin = FlChan(IndProbl).m2
        If FlChan(IndProbl).DintFla < 0 Then m2Sin = FlShel(IndProbl).m2
        If DatiInt(IndProbl).bdice = 2 Then m2Sin = -m2Sin
        If DatiInt(IndProbl).bdice = 0 And ICALT < 5 Then
            m2Sin = -wot * FlShel(IndProbl).hHg * System.Math.Abs(Problem(IndProbl).Tiranti(1).NumColl) / Problem(IndProbl).Tiranti(1).NumBolt
        End If
    End Function
    Public Function ScelSpes() As Single
        Dim Testo As String
        Dim Res As Boolean
        Dim Stringa(3) As String
        Dim junk As Short
        Dim Doman(2) As String
        Dim Rispo(2) As String
        Dim Arch(2) As Short
        Dim dAiu(2) As String
        'Dim i As Integer
        Dim Tit As String
        Dim mxmin, mxmax As Single
        Dim mm2, mm1, mxx As Single
        Dim TF As Single
        ScelSpes = True
        If StampaAnticipata Then Exit Function
        Try
            tfa = Problem(IndProbl).TSheThk
            tRa = Problem(IndProbl).TExtThk
1200:
            ' i = 0
            CalcIMAX()
            If Not (rappv >= 0.5) And Problem(IndProbl).TipCalc < 2 Then
                rappv = rappS(IMAX)
1210:           Res = Rifair(0) : If Not Res Then ScelSpes = Res : Exit Function
                GoTo 1200
            End If
            If Not ContinuoAuto Then
                ' Res = Rifair(0)
                ' CalcIMAX
                Testo = "Condizione dimensionante: " & Trim(Titol1(IMAX)) & "|"
                Testo = Testo & GlobalRoutines.FormatS(" t flex + corr. ####.# mm", tmax(IMAX, 0)) & "|"
                Testo = Testo & GlobalRoutines.FormatS(" t tagl.+ corr. ####.# mm", tma1(IMAX, 0)) & "|"
                Testo = Testo & GlobalRoutines.FormatS(" t est.         ####.# mm", tRmax(IMAX, 0)) & "|"
                Testo = Testo & GlobalRoutines.FormatS(" t est.  ASME   ####.# mm", tras(IMAX, 0)) & "|"
                If CType(objMemb(Involucr(kLato, jInvolucr).IndObject), wn_PT).Rules > 0 Then
                    Testo = Testo & "Nota: verrà eseguito in seguito anche un calcolo|"
                    If UltimoAggiornamento < 3 Then
                        Testo = Testo & "secondo App.AA. Tale calcolo potrà portare ad un|"
                    Else
                        Testo = Testo & "secondo Part UHX. Tale calcolo potrà portare ad un|"
                    End If
                    Testo = Testo & "aumento degli spessori minimi.|"
                End If
                Testo = Testo & "Spessori minimi|"
                If VerificandoPI Then
                    Testo = Testo & "(N.B.: le presenti verifiche sono relative alla prova idraulica)|"
                    Tit = "Verifiche in prova idraulica"
                Else
                    Tit = "Spessori assunti"
                End If
                Testo = Testo & GlobalRoutines.FormatS(" t al centro   ####.# ", tfmax * kLength) & UnitLength & "|"
                Testo = Testo & GlobalRoutines.FormatS(" t estensione  ####.# ", temax * kLength) & UnitLength & "|"
                'i = i + 3
                Doman(1) = "Sp. adottato al centro  " & UnitLength
                Rispo(1) = GlobalRoutines.myStr(tfa * kLength, 3, 2, False)
                Doman(2) = "Sp. adottato estensione " & UnitLength
                Rispo(2) = GlobalRoutines.myStr(tRa * kLength, 3, 2, False)
                Testo = Monitor.Motore.Inizio.ConvertiCr(Testo)
                If Not Monitor.Motore.InputDati(2, Tit, Doman, Rispo, "", Arch, dAiu, Testo, CarFissi:=True) Then ScelSpes = False : Exit Function
                tfa = GlobalRoutines.ValVir(Rispo(1)) / kLength
                tRa = GlobalRoutines.ValVir(Rispo(2)) / kLength
            End If
            If tRa < temax Or tfa < tfmax Then
                junk = AskSpessoriInsufficienti()
                If junk = 2 Then
                    GoTo 1200
                Else
                    Exit Function
                End If
            End If
            '------------------------------------------------------------------------
            px = ppx1(IMAX)
            mx = mx0(IMAX)
            If (Problem(IndProbl).NOGRAF = 1) Then
                Grafico = New frmGrafic
                Routines.DoveDisegno = Grafico.Picture1
                mxmin = -mx - 0.39 * px * g2w
                mxmax = mxroutin(-1.0!, px, TF, 1.0!)
                If (mxmax < mxmin) Then mxmin = mxmax : mxmax = -mx - 0.39 * px * g2w
                mm1 = mxx1(IMAX) - (mxmax - mxmin) / 4
                If mm1 < mxmin Then mm1 = mxmin
                mm2 = mxx1(IMAX) + (mxmax - mxmin) / 4
                If mm2 > mxmax Then mm2 = mxmax
                opttf = oopp(IMAX)
                mxx = mxx1(IMAX) : trxi = trxi1(IMAX) : TF = tf1(IMAX)
                Routines.Scala(mm1 - (mm2 - mm1) / 5, mm2 + (mm2 - mm1) / 5, -TF / 5, 2 * TF + TF / 5, 1)
                Routines.DoveDisegnog.Clear(Color.White)
1220:           Call grafic(mm1, mm2, 0, 2 * TF, 2, "", mxx, TF)
1230:           Call grafic(mm1, mm2, 0, 2 * TF, 1, "", mxx, TF)
            End If
            If Not FinalCheck(mxx) Then
                junk = AskSpessoriInsufficienti()
                If junk = 2 Then
                    GoTo 1200
                Else
                    Exit Function
                End If
            End If
            If Problem(IndProbl).NOGRAF = 1 Then
                TF = tfa / inc
                Call grafic(mm1, mm2, 0, 2 * TF, 3, "", mxx, TF)
                Grafico.ShowDialog()
                Grafico.Dispose()
            End If
            Problem(IndProbl).TSheThk = tfa
            Problem(IndProbl).TExtThk = tRa
        Catch e As Exception
            MessageBox.Show(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Function
    Private Function AskSpessoriInsufficienti() As Integer
        Dim Testo As String = "Spessori insufficienti!.|"
        Dim Stringa(3) As String
        Testo = Testo & "       Cosa vuoi fare ? "
        Stringa(1) = "Modificare i dati di input"
        Stringa(2) = "Selezionare nuovi spessori"
        Stringa(3) = "Confermare i dati attuali"
        Return Monitor.Motore.Quale(3, "Spessori piastra", Stringa, "", 1, Testo)
    End Function
    Public Sub sCorrodi()
        CorrCodoli()
        If FlChan(IndProbl).DintFla > 0 Then FlChan(IndProbl).DintFla = FlChan(IndProbl).DintFla - 2.0! * cc
        FlChan(IndProbl).CodoMin = FlChan(IndProbl).CodoMin + cc
        FlChan(IndProbl).CodoMax = FlChan(IndProbl).CodoMax + cc
        If FlShel(IndProbl).DintFla > 0 Then FlShel(IndProbl).DintFla = FlShel(IndProbl).DintFla - 2.0! * cs
        FlShel(IndProbl).CodoMin = FlShel(IndProbl).CodoMin + cs
        FlShel(IndProbl).CodoMax = FlShel(IndProbl).CodoMax + cs
        cc = 0
        cs = 0
    End Sub
    Public Sub Stampe()
        Dim Fin, Cod, FinS As String
        Dim i As Short
        If StampaAnticipata Then Exit Sub
        NNOTE = 1
        NPAGE = 0
10669:  If Not PrepRapp(Template, "P.T. U-TEMA", Involucr(kLato, jInvolucr).Mark.Trim + " (U-TEMA)", FileSt, mioApert.lstRapp) Then Exit Sub
        nr = 0 : Call printa()
        Call printb(IMAX) : nr = NRIGHE + 1
        For ICAL = 2 To 5
            If (Problem(IndProbl).PDIFF = 0 And (ICAL = 2 Or ICAL = 3)) Then GoTo contca2
            If (Problem(IndProbl).PDIFF <> 0 And ICAL = 4) Then GoTo contca2
            If Problem(IndProbl).mart = 2 And ICAL = 5 Then GoTo contca2
            If (ICAL = IMAX) Then GoTo contca2
            If (ICAL = 2 Or ICAL = 3) And px1(ICAL) = 0.0! Then GoTo contca2
            Call printb(ICAL) : nr = NRIGHE + 1
contca2: Next ICAL
        If Not VerificandoPI Then Call Monitor.Motore.Problem.copia(RTrim(Monitor.Motore.Inizio.Archdir) & "\RTF\STAM08.EXT") Else NewPage()
        If Config(0).CalcMAWP = 1 And Not VerificandoPI Then
            Call MAWP()
            If MAWPShel(1) = 0 Then MessageBox.Show("Errore in wn_UTEMA")
            Cod = Space(5)
            Call testaU(Cod)
            Fin = "\par" : FinS = "_\par"
            With Monitor.Motore.Problem
                .Printa(Fin)
                .Printa(New String(CChar(" "), 29) & "MAWP CALCULATION [psi]" & Fin)
                .Printa(New String(CChar(" "), 29) & "======================" & Fin)
                .Printa(Fin)
                .Printa(New String(CChar(" "), 15) & "New&Cold      New&Hot   Corroded&Cold Corroded&Hot " & Fin)
                If Problem(IndProbl).PDIFF = 0 Then
                    .Printa(GlobalRoutines.FormatS("Differential  ######.#      ######.#     ######.#     ######.#" & FinS, MAWPShel(1), MAWPShel(2), MAWPShel(3), MAWPShel(4)))
                Else
                    .Printa(GlobalRoutines.FormatS("Shell-side    ######.#      ######.#     ######.#     ######.#" & FinS, MAWPShel(1), MAWPShel(2), MAWPShel(3), MAWPShel(4)))
                    .Printa(GlobalRoutines.FormatS("Tube-side     ######.#      ######.#     ######.#     ######.#" & FinS, MAWPChan(1), MAWPChan(2), MAWPChan(3), MAWPChan(4)))
                End If
            End With
            For i = 1 To 4
                If System.Math.Abs(Involucr(kLato, jInvolucr).MAWP(i - 1)) > System.Math.Abs(MAWPShel(i)) Then Involucr(kLato, jInvolucr).MAWP(i - 1) = MAWPShel(i)
                If System.Math.Abs(Involucr(kLato, jInvolucr).MAWP2(i - 1)) > System.Math.Abs(MAWPChan(i)) Then Involucr(kLato, jInvolucr).MAWP2(i - 1) = MAWPChan(i)
            Next
        End If
    End Sub
    Private Function tflex(ByVal GOBI As Single, ByRef pression As Single) As Single
        If GOBI <= 0 Then GOBI = FlShel(IndProbl).gefinc
        tflex = (DatiInt(IndProbl).FPiastr * GOBI / 3) * System.Math.Sqrt(System.Math.Abs(pression / (DatiInt(IndProbl).FattoNi * sx)))
    End Function
    Private Function troutin(ByRef pp As Single, ByRef mm As Single, ByRef Coll As Single) As Single
        Dim trou, trx1, trx2, d As Single
        trx1 = mm + mx * Coll + 0.39 * pp * g2w
        d = DatiInt(IndProbl).gef / inc
        If d <= 0 Then d = FlShel(IndProbl).gefinc
        trx2 = (Problem(IndProbl).TSheDes / inc - d) * sx
        If trx2 <= 0 Then
            MessageBox.Show("I diametri dell'estensione e della guarnizione sono incongruenti")
        Else
            trou = 1.38 * System.Math.Sqrt(System.Math.Abs(trx1) / trx2)
            troutin = trou
            If (Problem(IndProbl).FLEX = 0) Then Exit Function
        End If
        '       da rivedere --------------UG-34 c(2)
        'PRINT "troutin"; SQR(6! / 3.14159 * ABS(mm) / DatiInt(Indprobl).gef * inc / sx)
        'IF (T1 > trou) THEN troutin = T1
    End Function

    Private Function tshear(ByRef pbo As Single) As Single
        Dim ratdep As Single
        ratdep = 1 - Problem(IndProbl).TubDiam / Problem(IndProbl).TubPass
        tshear = 0.31 * (Problem(IndProbl).EquDiam / inc) * System.Math.Abs(pbo) / (sx * ratdep)
    End Function

    'Sub converti()
    'Problem(IndObj).Commess = dt(1)       'COMMESSA
    'Problem(IndObj).TipPias = dt(2)       'ID PT
    'Problem(IndObj).MatPias = dt(3)       'TUBESHEET MATERIAL
    'FlChan(IndObj).TipGuar = dt(4)        'GASKET TYPE
    'FlChan(IndObj).MatGuar = dt(5)        'GASKET MATERIAL
    'FlShel(IndObj).TipGuar = dt(6)        'GASKET TYPE
    'FlShel(IndObj).MatGuar = dt(7)        'GASKET MATERIAL
    'Problem(IndObj).MatBull = dt(8)       'STUD BOLTS MATERIAL
    'Problem(IndObj).DiNBull = dt(9)       'DN
    'Problem(IndObj).PEsChan = GlobaLroutines.ValVir(dt(10)) 'P. LATO TUBI
    'FlChan(IndObj).PresDes = Problem(IndObj).PEsChan
    'Problem(IndObj).PEsShel = GlobaLroutines.ValVir(dt(11)) 'P. LATO MANTELLO
    'FlShel(IndObj).PresDes = Problem(IndObj).PEsShel
    'Problem(IndObj).PHTChan = GlobaLroutines.ValVir(dt(12)) 'P. IDR. LATO TUBI
    'If Problem(IndObj).PHTChan < Problem(IndObj).PEsChan Then Problem(IndObj).PHTChan = 1.5 * Problem(IndObj).PEsChan
    'FlChan(IndObj).PresHyT = Problem(IndObj).PHTChan
    'Problem(IndObj).PHTShel = GlobaLroutines.ValVir(dt(13)) 'P. IDR. LATO MANTELLO
    'If Problem(IndObj).PHTShel < Problem(IndObj).PEsShel Then Problem(IndObj).PHTShel = 1.5 * Problem(IndObj).PEsShel
    'FlShel(IndObj).PresHyT = Problem(IndObj).PHTShel
    'Problem(IndObj).DesTemp = GlobaLroutines.ValVir(dt(14)) 'TEMPERATURE    §F
    'Problem(IndObj).AllFRoo = GlobaLroutines.ValVir(dt(15)) 'SFa             psi
    'Problem(IndObj).AllFOpe = GlobaLroutines.ValVir(dt(16)) 'SFo             psi
    'Problem(IndObj).AllBRoo = GlobaLroutines.ValVir(dt(17)) 'Sba             psi
    'Problem(IndObj).AllBOpe = GlobaLroutines.ValVir(dt(18)) 'Sbo             psi
    'Problem(IndObj).fSicBul = GlobaLroutines.ValVir(dt(19)) 'fattore sicurezza bulloni
    'Problem(IndObj).NumBolt = GlobaLroutines.ValVir(dt(20)) 'NB
    'Problem(IndObj).BoltCiD = GlobaLroutines.ValVir(dt(21)) 'BCD             MM
    'Problem(IndObj).AreBolt = GlobaLroutines.ValVir(dt(22)) 'Aunitaria       sq.in.
    'Problem(IndObj).BSpcMin = GlobaLroutines.ValVir(dt(23)) 'bs min          MM
    'Problem(IndObj).TSheDes = GlobaLroutines.ValVir(dt(24)) 'TSDE d.e.P.T.   MM
    'Problem(IndObj).TubDiam = GlobaLroutines.ValVir(dt(25)) 'D.E.T.          MM
    'Problem(IndObj).TubPass = GlobaLroutines.ValVir(dt(26)) 'P               MM
    'Problem(IndObj).TipPass = GlobaLroutines.ValVir(dt(27)) 'TIPO  passo 1q 2t
    'Problem(IndObj).EquDiam = GlobaLroutines.ValVir(dt(28)) 'diametro equivalente  MM
    'Problem(IndObj).CorShel = GlobaLroutines.ValVir(dt(29)) 'CORR. CORPO     MM
    'Problem(IndObj).CorChan = GlobaLroutines.ValVir(dt(30)) 'CORR. CASSA     MM
    'Problem(IndObj).CavChan = GlobaLroutines.ValVir(dt(31)) 'CAVA CASSA      MM
    'FlChan(IndObj).DextFla = GlobaLroutines.ValVir(dt(32))  'A  d.e. flangia MM
    'FlChan(IndObj).DintFla = GlobaLroutines.ValVir(dt(33))  'B d.i. flangia  MM non corroso
    'FlChan(IndObj).CodoMax = GlobaLroutines.ValVir(dt(34))  'sp. codolo max  MM lato flangia,non corroso
    'FlChan(IndObj).CodoMin = GlobaLroutines.ValVir(dt(35))  'sp. codolo min  MM lato flangia,non corroso
    'FlChan(IndObj).DmedGua = GlobaLroutines.ValVir(dt(36))  'G               MM
    'FlChan(IndObj).LargGua = GlobaLroutines.ValVir(dt(37))  'NG              MM
    'FlChan(IndObj).mguar = GlobaLroutines.ValVir(dt(38))    'M
    'FlChan(IndObj).Y = GlobaLroutines.ValVir(dt(39))        'Y               psi
    'FlChan(IndObj).PHI = GlobaLroutines.ValVir(dt(40))      'TIPO FACCIA
    'FlChan(IndObj).wn = GlobaLroutines.ValVir(dt(41))       'nubbin
    'FlShel(IndObj).DextFla = GlobaLroutines.ValVir(dt(42))  'A  d.e. flangia MM
    'FlShel(IndObj).DintFla = GlobaLroutines.ValVir(dt(43))  'B d.i. flangia  MM non corroso
    'FlShel(IndObj).CodoMax = GlobaLroutines.ValVir(dt(44))  'sp. codolo max  MM lato flangia,non corroso
    'FlShel(IndObj).CodoMin = GlobaLroutines.ValVir(dt(45))  'sp. codolo min  MM lato flangia,non corroso
    'FlShel(IndObj).DmedGua = GlobaLroutines.ValVir(dt(46))  'G               MM
    'FlShel(IndObj).LargGua = GlobaLroutines.ValVir(dt(47))  'NG              MM
    'FlShel(IndObj).mguar = GlobaLroutines.ValVir(dt(48))    'M
    'FlShel(IndObj).Y = GlobaLroutines.ValVir(dt(49))        'Y               psi
    'FlShel(IndObj).PHI = GlobaLroutines.ValVir(dt(50))      'TIPO FACCIA
    'FlShel(IndObj).wn = GlobaLroutines.ValVir(dt(51))       'nubbin
    'Problem(IndObj).NumColl = GlobaLroutines.ValVir(dt(52)) 'N.bulloni con collare
    'Problem(IndObj).Vacuum = GlobaLroutines.ValVir(dt(53)) '0=nesssun calcolo sotto vuoto
    '1=sotto vuoto shell side  | se VACUUM>0,
    '2=sotto vuoto tube side   | allora PDIFF=1.
    '3=sotto vuoto both sides
    'rappSin = GlobaLroutines.ValVir(dt(54))            'Rapporto sp.ext/sp.piastra
    'If (rappSin < 0.5 Or rappSin > 1!) Then rappSin = 0!
    'Problem(IndObj).SERRA = GlobaLroutines.ValVir(dt(55))           'Interruttore per serraggio massimo
    'Problem(IndObj).mart = GlobaLroutines.ValVir(dt(56))            'Interruttore per uso bolt load fr-caldo
    'Problem(IndObj).SPHT = GlobaLroutines.ValVir(dt(57))            'Interruttore per uso press p.i. per b.l. a fr.
    'If (Not (Problem(IndObj).SPHT = 0 Or Problem(IndObj).SPHT = 1)) Then Problem(IndObj).SPHT = 1
    'Problem(IndObj).PDIFF = GlobaLroutines.ValVir(dt(58))           'Interruttore per calcolo a pdiff (0=si;1=no)
    'If Problem(IndObj).Vacuum > 0 Then Problem(IndObj).PDIFF = 1
    'Problem(IndObj).FLEX = GlobaLroutines.ValVir(dt(59))            'Interruttore per calcolo flessione rim
    'Problem(IndObj).CRUSH = GlobaLroutines.ValVir(dt(60))           'Inerruttore per stampa verifica a
    'gasket crush (0=si;1=no)
    'Problem(IndObj).NOGRAF = GlobaLroutines.ValVir(dt(61))          'Interruttore per grafico (0=no;1=si)
    'Problem(IndObj).XFil = GlobaLroutines.ValVir(dt(62))
    'End Sub
    Function DatiAmm() As Boolean
        DatiAmm = True
        If (Matdim(Involucr(kLato, jInvolucr).indice(1 - 1)).Indmat > 0 Or Not _
            Matdim(Involucr(kLato, jInvolucr).indice(1 - 1)).Agganciato) And _
            Problem(IndProbl).AllFRoo * Problem(IndProbl).AllFOpe = 0 Then
            Matdim(Involucr(kLato, jInvolucr).indice(1 - 1)).SigmaAmm(CodiceStress, Problem(IndProbl).Destemp, Problem(IndProbl).AllFRoo, Problem(IndProbl).AllFOpe)
        End If
        If (Matdim(Involucr(kLato, jInvolucr).indice(2 - 1)).Indmat > 0 Or Not _
            Matdim(Involucr(kLato, jInvolucr).indice(2 - 1)).Agganciato) And _
            Problem(IndProbl).Tiranti(1).AllBRoo * Problem(IndProbl).Tiranti(1).AllBOpe = 0 And _
            Problem(IndProbl).mart < 2 Then
            Matdim(Involucr(kLato, jInvolucr).indice(2 - 1)).SigmaAmm(CodiceStress, Problem(IndProbl).Destemp, Problem(IndProbl).Tiranti(1).AllBRoo, Problem(IndProbl).Tiranti(1).AllBOpe)
        End If
        If (Matdim(Involucr(kLato, jInvolucr).indice(7 - 1)).Indmat > 0 Or Not _
            Matdim(Involucr(kLato, jInvolucr).indice(7 - 1)).Agganciato) And _
            Problem(IndProbl).Tiranti(2).AllBRoo * Problem(IndProbl).Tiranti(2).AllBOpe = 0 And _
            Problem(IndProbl).mart < 2 Then
            Matdim(Involucr(kLato, jInvolucr).indice(7 - 1)).SigmaAmm(CodiceStress, Problem(IndProbl).Destemp, Problem(IndProbl).Tiranti(2).AllBRoo, Problem(IndProbl).Tiranti(2).AllBOpe)
        End If
        If Problem(IndProbl).Tiranti(1).fSicBul < 1 Then
            Dim t As DatiBull = Problem(IndProbl).Tiranti(1)
            t.fSicBul = 1
            Problem(IndProbl).Tiranti(1) = t
        End If
        If Problem(IndProbl).Tiranti(2).fSicBul < 1 Then
            Dim t As DatiBull = Problem(IndProbl).Tiranti(2)
            t.fSicBul = 1
            Problem(IndProbl).Tiranti(2) = t
        End If
        'Risult$(1) = myStr(Problem(Indprobl).AllFRoo, 6, 2, False): Stringa(1) = "Amm.piastra ambiente    [psi]"
        'Risult$(2) = myStr(Problem(Indprobl).AllFOpe, 6, 2, False): Stringa(2) = "Amm.piastra esercizio   [psi]"
        'Risult$(3) = myStr(Problem(Indprobl).AllBRoo, 6, 2, False): Stringa(3) = "Amm.tiranti ambiente    [psi]"
        'Risult$(4) = myStr(Problem(Indprobl).AllBOpe, 6, 2, False): Stringa(4) = "Amm.tiranti esercizio   [psi]"
        If Problem(IndProbl).mart < 2 Then
            Problem(IndProbl).mart = 0 '
        Else
            '   For i = 3 To 6: Stringa(i) = "-": Next
        End If
        'Nfield = 6
        'Call Comprimi(Nfield)
        'y = InputDati(2, Nfield, "Ammissibili", Stringa(), Risult$(), LungStr())
        'Do
        'Select Case Esp(y)
        '    Case -3
        '               'a$ = " Clickando su alcuni dei campi della | finestra sottostante si otiene |"
        '               'a$ = a$ + " una lista dei valori possibili. Cio' | vale in particolare per i materiali.|"
        '               junk = Alert(4, at1(59), 4, 3, 11, 48, at1(33), "", "")
        '    Case -2
        '               WindowClose 2: DatiAmm = False: Exit Function
        '    Case -1
        '               WindowClose 2: Exit Do
        'End Select
        'y = InputDati%(0, Nfield, "Ammissibili", Stringa(), Risult$(), LungStr())
        'Loop
        'Problem(Indprobl).AllFRoo = GlobaLroutines.ValVir(Risult$(Compr(1)))
        'Problem(Indprobl).AllFOpe = GlobaLroutines.ValVir(Risult$(Compr(2)))
        'Problem(Indprobl).AllBRoo = GlobaLroutines.ValVir(Risult$(Compr(3)))
        'Problem(Indprobl).AllBOpe = GlobaLroutines.ValVir(Risult$(Compr(4)))
        MessageBox.Show("Lavori in corso 1")
    End Function
    Function DatiInput() As Boolean
        DatiInput = False
        If Not DatiAmm() Then Exit Function
        If Not CType(objMemb(Involucr(kLato, jInvolucr).IndObject), wn_PT).DatiFlange Then Exit Function
        DatiInput = True
    End Function
    'Private Sub AmmissBull()
    'Dim Sfa As Single, Sfo As Single
    'Dim jRec As Integer, locInd As Integer
    ''   If Problem(Indprobl).DesTemp = 0 Then
    ''        Dim StRis$(1), StDom$(1), StLun(1) As Integer
    ''        StRis$(1) = myStr(Problem(Indprobl).DesTemp, 4, 2, False): StDom$(1) = "Temperatura di progetto  [øC]"
    ''        j = VisuInput(1, "", "", StDom$(), StRis$(), StLun())
    ''        Problem(Indprobl).DesTemp = GlobaLroutines.ValVir(StRis$(1))
    ''   End If
    '   locInd = 2
    '   jRec = Involucr(kLato, jInvolucr).indice(locInd)
    '   If CerMat(jRec, locInd) = -1 Then Exit Sub
    '   Matdim(jRec).SigmaAmm CodiceStress, Problem(IndProbl).Destemp * 1.8 + 32, Sfa!, Sfo!
    '   Problem(IndProbl).AllFRoo = Sfa * psi 'Tens.ammiss.flangi/piastra @room     [psi]
    '   Problem(IndProbl).AllFOpe = Sfo * psi 'Tens.ammiss.flangia/piastra @temp    [psi]
    ''   Problem(Indprobl).fSicBul = 1          'Fattore addiz. sicurezza bulloni     [--]
    'End Sub
    'Sub CercaCal(i1 As Integer, i2 As Integer)
    'Dim Suff As String, icomeF As String, Nofl As Boolean
    'If i1 > 0 Then
    'If Record(i1).ind > 0 Then
    '   Call CercaWNDU(i1, Suff$)
    '   icomeF$ = RTrim$(Monitor.Motore.Inizio.Workdir) + "\A" + RTrim$(Lav(0).Arch) + Chr$(92) + Lav(0).File(Lav(0).NumAs) + Suff$ + ".WND"
    '   If Len(Dir$(icomeF$)) = 0 Then Nofl = True
    'End If
    'End If
    'If i2 > 0 Then
    'If Record(i2).ind > 0 Then
    '   Call CercaWNDU(i2, Suff$)
    '   icomeF$ = RTrim$(Monitor.Motore.Inizio.Workdir) + "\A" + RTrim$(Lav(0).Arch) + Chr$(92) + Lav(0).File(Lav(0).NumAs) + Suff$ + ".WND"
    '   If Len(Dir$(icomeF$)) = 0 And Nofl Then Nofl = True
    'End If
    'End If
    'If Nofl Then
    ''         a$ = "Non risultano essere state calcolate|"
    ''    a$ = a$ + "le flange e i tiranti collegati a questa|"
    ''    a$ = a$ + "piastra. E' opportuno farlo prima.      |"
    ''    a$ = a$ + "Vuoi procedere in tal senso?            |"
    ''    junk = Alert(4, a$, 4, 3, 13, 68, "Si", "No", "")'
    ''    If junk = 1 Then
    ''       If Record(i1).ind > 0 Then Record(0) = Record(i1) Else Record(0) = Record(i2)
    ''       AddDistinta = Record(0).ind
    ''       Catena "WNLJ"
    ''    End If
    'End If
    'End Sub

    Private Sub CercaFla(ByRef iPia As Short, ByRef iTir As Short, ByRef iShe As Short, ByRef iCha As Short, ByRef Chan As Boolean, ByRef mode As Short, ByRef Flangia As datiFlangia)
        'iChaGia = Chan
        'For k = 1 To Lav(0).ind(Lav(0).NumAs)
        '                Get #IUNA, k, Record(JRECMAX)
        '                If EOF(IUNA) Or Record(JRECMAX).ind = 0 Then Exit For
        '                If Record(JRECMAX).Tipo = 11 Then
        '                     Log1 = (Record(iTir).PosSpa.SuChi = Record(JRECMAX).ind Or Record(JRECMAX).PosSpa.SuChi = Record(iTir).ind)
        '                     Log2 = (Record(iTir).ForoSecondario = Record(JRECMAX).ind Or Record(JRECMAX).ForoSecondario = Record(iTir).ind)
        '                     Log3 = (Record(iTir).ForoTerziario = Record(JRECMAX).ind Or Record(JRECMAX).ForoTerziario = Record(iTir).ind)
        '                     If (Log1 Or Log2 Or Log3) And Record(JRECMAX).ind <> Record(iPia).ind Then
        '                        Prod = ProdScalar(Record(JRECMAX).PosSpa.CosDiritta, Record(iPia).PosSpa.CosDiritta)
        '                        If Prod < 0 Then Chan = False: Nguar = iShe Else Chan = True: Nguar = iCha
        '                        IF Mode = 1 AND NOT Chan THEN PRINT "Errore impossibile in CercaFla": u$ = INPUT$(1)
        '                        If Mode = 2 And Chan <> iChaGia Or Mode <> 2 Then
        '                           Record(Nguar) = Record(JRECMAX)  'controflangione 1
        '                           Call LookTipoFlangione(Record(Nguar).Dati())
        '                           Flangia.Identif = RTrim$(Record(Nguar).Denom) + " Pos." + Str$(Record(Nguar).PosDis)
        '                           Flangia.DextFla = Adim      'Diametro esterno della flangia          [mm]
        '                           Flangia.DintFla = b         'Diametro interno della flangia         [mm]
        '                           Flangia.CodoMax = g1        'Spessore codolo massimo                [mm]
        '                           Flangia.CodoMin = g0        'Spessore codolo minimo                 [mm]
        '                           Exit For
        '                        End If
        '                     End If
        '                End If
        'Next k
    End Sub

    Private Sub CercaGuar(ByRef iPias As Short, ByRef iFShel As Short, ByRef iFChan As Short, ByRef Shel As Boolean, ByRef Chan As Boolean, ByRef iGShel As Short, ByRef iGChan As Short, ByRef Flangia As datiFlangia)
        'For j = 1 To Lav(0).ind(Lav(0).NumAs)
        '92  Get #IUNA, j, Record(JRECMAX)
        '    If EOF(IUNA) Or Record(JRECMAX).ind = 0 Then Exit For
        '    If Record(JRECMAX).Tipo = 28 And (Record(iPias).PosSpa.SuChi = Record(JRECMAX).ind Or Record(JRECMAX).PosSpa.SuChi = Record(iPias).ind) Then
        '    Log1% = ((Record(iFShel).PosSpa.SuChi = Record(JRECMAX).ind) Or (Record(iFShel).ind = Record(JRECMAX).PosSpa.SuChi)) And Shel
        '    Log2% = ((Record(iFChan).PosSpa.SuChi = Record(JRECMAX).ind) Or (Record(iFChan).ind = Record(JRECMAX).PosSpa.SuChi)) And Chan = True
        '         If Not Chan Then Nguar = iGShel Else Nguar = iGChan
        '         If Log1% Or Log2% Then
        '            Record(Nguar) = Record(JRECMAX)
        '            Deguar = Record(Nguar).Dati(7)
        '            Diguar = Record(Nguar).Dati(8)
        '            SpGuar = Record(Nguar).Dati(3)
        '            ClassGsk% = Record(Nguar).Dati(4)
        '            TipGsk% = Record(Nguar).Dati(5)
        '            IndFac% = Record(Nguar).Dati(6)
        '            GasMat$ = Record(Nguar).MATE
        '            i% = GaskCar(ClassGsk%, TipGsk%, IndFac%, m!, y!, Faccia%, Gasket$, GasMat$, 1)
        '            Flangia.ClassGsk = ClassGsk%
        '            Flangia.TipGsk = TipGsk%
        '            Flangia.IndFac = IndGac%
        '            Flangia.TipGuar = Gasket$
        '            Flangia.MatGuar = GasMat$
        '            Flangia.LargGua = (Deguar - Diguar) / 2
        '            Flangia.DmedGua = (Deguar + Diguar) / 2
        '            Flangia.mguar = m!
        '            Flangia.y = y!
        '            Flangia.PHI = Faccia%
        '            Exit Sub
        '         End If
        '    End If
        'Next j
        'Shel = False: Chan = False
    End Sub

    Private Sub CercaTir(ByRef iPias As Short, ByRef iBull As Short)
        'For k = 1 To Lav(0).ind(Lav(0).NumAs)
        '    Get #IUNA, k, Record(JRECMAX)
        '    If EOF(IUNA) Or Record(JRECMAX).ind = 0 Then Exit For
        '    If Record(JRECMAX).Tipo = 13 Then
        '    Log1 = (Record(iPias).PosSpa.SuChi = Record(JRECMAX).ind Or Record(JRECMAX).PosSpa.SuChi = Record(iPias).ind)
        '    Log2 = (Record(iPias).ForoSecondario = Record(JRECMAX).ind Or Record(JRECMAX).ForoSecondario = Record(iPias).ind)
        '    Log3 = (Record(iPias).ForoTerziario = Record(JRECMAX).ind Or Record(JRECMAX).ForoTerziario = Record(iPias).ind)
        '    If Log1 Or Log2 Or Log3 Then
        '         Record(iBull) = Record(JRECMAX)
        '         LuBull = Record(iBull).Dati(1)
        '         CercDm = Record(iBull).Dati(4)
        '         XFil% = Record(iBull).Dati(6)
        '         DBull = Record(iBull).Dati(5)
        '         NBull = GlobaLroutines.ValVir(Record(iBull).Qta)
        '         TIMA$ = Record(iBull).MATE
        '         Pil% = Record(iBull).Dati(8)
        '         If Pil% = 1 Then XFil% = XFil% + 2
        '         SearchTiraS Tira, CSng(DBull), XFil%
        '         Problem(Indprobl).XFil = XFil%
        '         Problem(Indprobl).MatBull = TIMA$
        '         Problem(Indprobl).DiNBull = Tira.DN
        '         Problem(Indprobl).NumBolt = NBull
        '         Problem(Indprobl).BoltCiD = CercDm
        '         Problem(Indprobl).AreBolt = PI / 4 * Tira.Dnom ^ 2 / inc / inc
        '         DatiInt(Indprobl).AreaBol = Problem(Indprobl).NumBolt * Problem(Indprobl).AreBolt
        '         Problem(Indprobl).BSpcMin = Tira.BSmin
        '         Problem(Indprobl).BRadMin = Tira.Emin
        '    End If
        '    End If
        'Next k
    End Sub
    'Sub CercaWNDU(ind As Integer, Suffix$)
    'Suffix$ = Str$(Record(ind).PosDis)
    'Mid$(Suffix$, 1, 1) = "0"
    'If Len(Suffix$) < 3 Then Suffix$ = "0" + Suffix$
    'If Len(Suffix$) > 3 Then Suffix$ = Right$(Suffix$, 3)
    'End Sub
    'Private Function DatiBull(Problem(Indprobl) As DatiGeneral, Titolo$, Mode As Integer) As Boolean
    'DatiBull = True
    ''Mode 0 chiamato da UTEMA >0 chiamato da PTFF
    'Esp(-1) = -1: Esp(-2) = -2: Esp(-3) = -3
    'Risult$(4) = Adjust(Problem(Indprobl).DiNBull, 10):       Stringa(4) = "DN bulloni"
    'Risult$(5) = myStr(CSng(Problem(Indprobl).NumBolt), 3, 2, True): Stringa(5) = "Numero bulloni"
    'Risult$(6) = myStr(Problem(Indprobl).AreBolt, 3, 4, False): Stringa(6) = "Sezione bullone [iný]"
    'Risult$(7) = myStr(Problem(Indprobl).BSpcMin, 4, 2, False): Stringa(7) = "B.S. minimo      [mm]"
    'Risult$(8) = myStr(Problem(Indprobl).BRadMin, 4, 2, False): Stringa(8) = "Spazio esterno min. [mm]"
    'Risult$(11) = myStr(Problem(Indprobl).BoltCiD, 4, 2, False): Stringa(11) = "Diametro istall.bull.[mm]"                                                                                               'pr
    'Risult$(12) = myStr(Problem(Indprobl).AllBRoo, 6, 2, False): Stringa(12) = "Amm.tiranti ambiente    [psi]"
    'Risult$(13) = myStr(Problem(Indprobl).AllBOpe, 6, 2, False): Stringa(13) = "Amm.tiranti esercizio   [psi]"
    'Nf = 14
    'If Mode > 0 Then
    '   Stringa(1) = Chr$(45)
    '   Stringa(2) = Chr$(45)
    '   Stringa(3) = Chr$(45)
    '   Stringa(10) = Chr$(45)
    'Else
    '   For i = 11 To 14: Stringa(i) = Chr$(45): Next
    'End If
    'If Problem(Indprobl).mart = 2 Then
    '   Stringa(4) = Chr$(45)
    '   For i = 6 To 9: Stringa(i) = Chr$(45): Next
    '   For i = 12 To 14: Stringa(i) = Chr$(45): Next
    'End If
    'Call Comprimi(Nf)
    'y = InputDati(2, Nf, Titolo$, Stringa(), Risult$(), LungStr())
    'Do
    'Select Case Esp(y)
    '    Case -3
    'a$ = " Clickando su alcuni dei campi della | finestra sottostante si otiene |"
    '               'a$ = a$ + " una lista dei valori possibili. Cio' | vale in particolare per i materiali.|"
    '               junk = Alert(4, at1(59), 4, 3, 11, 48, at1(33), "", "")
    '    Case -2
    '               WindowClose 2: DatBull = False: Exit Function
    '    Case -1
    '               WindowClose 2: Exit Do
    '    Case 3 'materiale piastra
    '         Classedim = DisplayClasse(1, 1, 0, 0, 0, 0, 1, 0, 0)
    '         If Classedim = 0 Then DatiBull = False: WindowClose 2: Exit Function
    '         DisplayMat Classedim, 0
    '         Risult$(y) = Matdim(0).Mat
    '    Case 4 'DN bulloni
    '         XFil = Problem(Indprobl).XFil
    '         DisplayTira Tira, XFil
    '         Risult$(Compr(4)) = Tira.DN
    '         Problem(Indprobl).XFil = XFil
    '         Risult$(Compr(6)) = myStr((Val(Tira.Diam) / inc) ^ 2 * PI / 4, 3, 4, False)
    '         Risult$(Compr(7)) = myStr(Tira.BSmin, 3, 4, False)
    '         Risult$(Compr(8)) = myStr(Tira.Emin, 3, 4, False)
    '    Case 6
    '         XFil = Problem(Indprobl).XFil
    '         SearchTira Tira, Risult$(Compr(4)), XFil
    '         Problem(Indprobl).XFil = XFil
    '         Risult$(y) = myStr((Val(Tira.Diam) / inc) ^ 2 * PI / 4, 3, 4, False)
    '    Case 7
    '         XFil = Problem(Indprobl).XFil
    '         SearchTira Tira, Risult$(Compr(4)), XFil
    '        Problem(Indprobl).XFil = XFil
    '         Risult$(y) = myStr(Tira.BSmin, 3, 4, False)
    '    Case 8
    '         XFil = Problem(Indprobl).XFil
    '         SearchTira Tira, Risult$(Compr(4)), XFil
    '         Problem(Indprobl).XFil = XFil
    '         Risult$(y) = myStr(Tira.Emin, 3, 4, False)
    '    Case 9 'materiale bulloni
    '         i1 = 1: If Mode > 0 Then i1 = Mode
    '         DisplayMat 8, i1
    '         Risult$(y) = Matdim(i1).Mat
    '         If Mode > 0 Then Record(i1).Indmat = Matdim(i1).ind
    '    Case 10 'tipo flangiatura
    '         DatiInt(Indprobl).bdice = Quale(3, "Flangiature", Stringa1$(), "", DatiInt(Indprobl).bdice + 1) - 1
    '         Risult$(y) = Stringa1$(DatiInt(Indprobl).bdice + 1)
    '    Case 12, 13 'ammissibili tiranti
    '         Call AmmissBull(Problem(Indprobl))
    '         Risult$(Compr(12)) = myStr(Problem(Indprobl).AllBRoo, 6, 2, False)
    '         Risult$(Compr(13)) = myStr(Problem(Indprobl).AllBOpe, 6, 2, False)
    '    Case 14
    '         Problem(Indprobl).SERRA = Quale(2, "Bolting   ", Stringa1$(), "", Problem(Indprobl).SERRA + 1) - 1
    '         Risult$(Compr(14)) = Stringa1$(Problem(Indprobl).SERRA + 1)
    'End Select
    'y = InputDati%(0, Nf, Titolo$, Stringa(), Risult$(), LungStr())
    'Loop
    'If Compr(1) > 0 Then Problem(Indprobl).Commess = Risult$(Compr(1))
    'If Compr(2) > 0 Then Problem(Indprobl).TipPias = Risult$(Compr(2))
    'If Compr(3) > 0 Then Problem(Indprobl).MatPias = Risult$(Compr(3))
    'Problem(Indprobl).DiNBull = Risult$(Compr(4))
    'Problem(Indprobl).NumBolt = GlobaLroutines.ValVir(Risult$(Compr(5)))
    'Problem(Indprobl).AreBolt = GlobaLroutines.ValVir(Risult$(Compr(6)))
    'Problem(Indprobl).BSpcMin = GlobaLroutines.ValVir(Risult$(Compr(7)))
    'Problem(Indprobl).BRadMin = GlobaLroutines.ValVir(Risult$(Compr(8)))
    'Problem(Indprobl).MatBull = Risult$(Compr(9))
    'If Compr(11) > 0 Then Problem(Indprobl).BoltCiD = GlobaLroutines.ValVir(Risult$(Compr(11)))
    'If Compr(12) > 0 Then Problem(Indprobl).AllBRoo = GlobaLroutines.ValVir(Risult$(Compr(12)))
    'If Compr(13) > 0 Then Problem(Indprobl).AllBOpe = GlobaLroutines.ValVir(Risult$(Compr(13)))
    'Exit Function
    'End Function
    Private Function DiamExt(ByRef mode As Short) As Boolean
        Dim Eact As Single
        Dim Testo As String
        Dim Stringa(2) As String
        Dim junk As Short
        DiamExt = True
        If Problem(IndProbl).mart = 2 Then Exit Function
        If Problem(IndProbl).Tiranti(1).BRadMin > 0 Then
            If Problem(IndProbl).TSheDes < Problem(IndProbl).Tiranti(1).BoltCiD + 2 * Problem(IndProbl).Tiranti(1).BRadMin Then
                Eact = (Problem(IndProbl).TSheDes - Problem(IndProbl).Tiranti(1).BoltCiD) / 2
                Testo = "La spaziatura bulloni radiale |"
                Testo = Testo & "verso l' esterno è insufficiente|"
                Testo = Testo & "E   (minimo)    = " & GlobalRoutines.myStr(Problem(IndProbl).Tiranti(1).BRadMin * kLength, 7, 2, False) & " E  attuale    = " & GlobalRoutines.myStr(Eact * kLength, 7, 2, False)
                Testo = Testo & "|Diam.est.minimo = " & GlobalRoutines.myStr((Problem(IndProbl).Tiranti(1).BoltCiD + 2 * Problem(IndProbl).Tiranti(1).BRadMin) * kLength, 5, 0, True) & " Diam.attuale  = " & GlobalRoutines.myStr(Problem(IndProbl).TSheDes * kLength, 5, 0, False)
                Testo = Testo & "|       Cosa vuoi fare ? "
                Stringa(1) = "Modificare il diametro esterno"
                Stringa(2) = "Confermare il valore attuale di E"
                junk = Monitor.Motore.Quale(2, "Controllo E ", Stringa, "", 1, Testo)
                Select Case junk
                    Case 1
                        Problem(IndProbl).TSheDes = Problem(IndProbl).Tiranti(1).BoltCiD + 2 * Problem(IndProbl).Tiranti(1).BRadMin
                    Case 2
                    Case 0
                        DiamExt = False
                End Select
            End If
        End If
    End Function
    Private Sub SpazBull(ByRef BoltSpc As Single, ByRef SWITCH_Renamed As Short, ByRef mode As Short, ByRef i As Short)
        Dim Testo As String
        Dim junk As Short
        Dim Stringa(2) As String
        If Problem(IndProbl).mart = 2 Then Exit Sub
1100:   BoltSpc = (Problem(IndProbl).Tiranti(i).BoltCiD * pi) / Problem(IndProbl).Tiranti(i).NumBolt
        If Problem(IndProbl).Tiranti(i).BSpcMin > BoltSpc Then
            Testo = "Spaziatura bulloni insufficiente "
            Testo = Testo & "| bs minimo=" & GlobalRoutines.myStr(Problem(IndProbl).Tiranti(i).BSpcMin * kLength, 4, 2, False) & "; bs attuale=" & GlobalRoutines.myStr(DatiInt(IndProbl).BoltSpc * kLength, 4, 2, False)
            Testo = Testo & "|       Cosa vuoi fare ? "
            Stringa(1) = "Modificare i dati"
            Stringa(2) = "Confermare i dati impostati"
            junk = Monitor.Motore.Quale(2, "Bolt spacing", Stringa, "", 1, Testo)
            Select Case junk
                Case 1
                    ' If Not DatiBull(Problem(Indprobl), "Dati Bulloni", Mode) Then SWITCH = 1
                Case Else
                    SWITCH_Renamed = 1
            End Select
        End If
    End Sub
    Private Sub count()
        nr = nr + 1
        If (nr < NRIGHE + 1) Then Exit Sub
        nr = 0
        NPAGE = NPAGE + 1
        If (Ntot < NPAGE) Then Ntot = NPAGE
        iGia = False
        Monitor.Motore.Problem.Printa("\par " & GlobalRoutines.FormatS("         -TubeSheet Calculation page ## ", NPAGE) & "\par \page ")
    End Sub
    Private Sub pringuar()
        Dim StriSt(12) As String
        Dim ifl As Short
        Dim i As Short
        ifl = FreeFile()
        FileOpen(ifl, RTrim(Monitor.Motore.Inizio.Archdir) & "\RTF\STAM04.EXT", OpenMode.Input, , OpenShare.Shared)
        For i = 1 To 12
            StriSt(i) = LineInput(ifl)
        Next
        FileClose(ifl)
        With Monitor.Motore.Problem
            If Problem(IndProbl).mart < 2 Then
                Call count() : .Printa(GlobalRoutines.FormatS(StriSt(2), Fl.LargGua, Fl.LargGua / inc)) '"N     = #########.## [mm]     #######.#### [in]       Gasket width"
                Call count() : .Printa(GlobalRoutines.FormatS(StriSt(3), Fl.mguar)) '"m     =                       #########.## [--]       Gasket factor"
                Call count() : .Printa(GlobalRoutines.FormatS(StriSt(4), Fl.y)) '"y     =                       #######.#### [psi]      Gasket min.design seating load"
                Call count() : .Printa(GlobalRoutines.FormatS(StriSt(5), Fl.wn, Fl.wn / inc)) '"w     = #########.## [mm]     #######.#### [in]       Nubbin width"
                Call count() : .Printa(GlobalRoutines.FormatS(StriSt(6), Fl.PHI)) '"Phi   =                       #########    [--]       Type of the gasketed joint"
                If Fl.ytrav > 0 Then
                    Call count() : .Printa(GlobalRoutines.FormatS(StriSt(7), Fl.btrav, Fl.btrav / inc)) '"Ntrav = #########.## [mm]     #######.#### [in]       Pass Part.Gasket width"
                    Call count() : .Printa(GlobalRoutines.FormatS(StriSt(8), Fl.ltrav, Fl.ltrav / inc)) '"Ltrav = #########.## [mm]     #######.#### [in]       Pass Part.Gasket length"
                    Call count() : .Printa(GlobalRoutines.FormatS(StriSt(9), Fl.ytrav)) '"ytrav                         #######.#### [psi]      Pass Part.Gsk Seat.Load"
                    Call count() : .Printa(GlobalRoutines.FormatS(StriSt(10), Fl.wmt)) '"Wmt                           #######.#### [lb]       Pass Part.Gsk Seat.Load"
                End If
            Else
                If VerificandoPI Then
                    Call count() : .Printa(GlobalRoutines.FormatS(StriSt(11), Fl.wm1H * NIUT, Fl.wm1H)) '"Wm1   = #########.##  [N]     #######.#### [lb]       Operating bolt load"
                    Call count() : .Printa(GlobalRoutines.FormatS(StriSt(12), Fl.wm2H * NIUT, Fl.wm2H)) '"Wm2   = #########.##  [N]     #######.#### [lb]       Seating bolt load"
                Else
                    Call count() : .Printa(GlobalRoutines.FormatS(StriSt(11), Fl.wm1 * NIUT, Fl.wm1)) '"Wm1   = #########.##  [N]     #######.#### [lb]       Operating bolt load"
                    Call count() : .Printa(GlobalRoutines.FormatS(StriSt(12), Fl.wm2 * NIUT, Fl.wm2)) '"Wm2   = #########.##  [N]     #######.#### [lb]       Seating bolt load"
                End If
            End If
        End With
    End Sub
    Private Sub printa()
        Dim Flangia(2) As String
        Dim Cod As String
        Dim ifl As Short
        Dim i, j As Short ', nr1 As Integer
        Dim jFlan, iFlan As Short
        Dim Lato As String
        Flangia(0) = "tube"
        Flangia(1) = "shell"
        Cod = Space(5)
        Call testaU(Cod)
        ifl = FreeFile()
        FileOpen(ifl, RTrim(Monitor.Motore.Inizio.Archdir) & "\RTF\STAM01.EXT", OpenMode.Input, , OpenShare.Shared)
        For i = 1 To 88
            StriSt(i) = LineInput(ifl)
        Next
        FileClose(ifl)
        With Monitor.Motore.Problem
            .Printa(StriSt(80))
            For j = 1 To 2 : Call count() : .Printa(StriSt(1)) : Next
            If VerificandoPI Then
                Call count() : .Printa(StriSt(87))
            Else
                Call count() : .Printa(StriSt(88))
                Call count()
            End If
            Call count() : .Printa(GlobalRoutines.FormatS(StriSt(2), Problem(IndProbl).TipPias(1))) '"T. SHEET IDENTIF.     : &"
            Call count() : .Printa(GlobalRoutines.FormatS(StriSt(3), Problem(IndProbl).MatPias(1))) '"T. SHEET MATERIAL     : &"
            If Problem(IndProbl).mart < 2 Then
                Select Case DatiInt(IndProbl).bdice
                    Case 1
                        Call count() : .Printa(GlobalRoutines.FormatS(StriSt(4), FlChan(IndProbl).TipGuar)) '"GASKET TYPE           : &"
                        Call count() : .Printa(GlobalRoutines.FormatS(StriSt(5), FlChan(IndProbl).MatGuar)) '"GASKET MATERIAL       : &"
                        Call count() : .Printa(GlobalRoutines.FormatS(StriSt(6), Problem(IndProbl).Tiranti(1).MatBull)) '"STUDS  MATERIAL       : &"
                        Call count() : .Printa(StriSt(1))
                    Case 2
                        Call count() : .Printa(GlobalRoutines.FormatS(StriSt(4), FlShel(IndProbl).TipGuar)) '"GASKET TYPE           : &"
                        Call count() : .Printa(GlobalRoutines.FormatS(StriSt(5), FlShel(IndProbl).MatGuar)) '"GASKET MATERIAL       : &"
                        Call count() : .Printa(GlobalRoutines.FormatS(StriSt(6), Problem(IndProbl).Tiranti(2).MatBull)) '"STUDS  MATERIAL       : &"
                        Call count() : .Printa(StriSt(1))
                End Select
            End If
            Call count() : .Printa(StriSt(7)) '"                                  INPUT DATA"
            Call count() : .Printa(StriSt(8)) '"                                  =========="
            For j = 1 To 2 : Call count() : .Printa(StriSt(1)) : Next
            Call count() : .Printa(GlobalRoutines.FormatS(StriSt(9), Problem(IndProbl).PEsChan / psi, Problem(IndProbl).PEsChan)) '"Ps    =    ###.#### [MPa]     #######.#### [psi]      Design pressure  (tube-side)"
            Call count() : .Printa(GlobalRoutines.FormatS(StriSt(10), Problem(IndProbl).PEsShel / psi, Problem(IndProbl).PEsShel)) '"Pt    =    ###.#### [MPa]     #######.#### [psi]      Design pressure (shell-side)"
            If (Problem(IndProbl).SPHT = 0) Then
                If DatiInt(IndProbl).bdice = 0 Then
                    Call count() : .Printa(GlobalRoutines.FormatS(StriSt(11), Problem(IndProbl).PHTChan / psi, Problem(IndProbl).PHTChan)) '"Psh   =  #####.#### [MPa]     #######.#### [psi]      Hydr.t.pressure  (tube-side)"
                    Call count() : .Printa(GlobalRoutines.FormatS(StriSt(12), Problem(IndProbl).PHTShel / psi, Problem(IndProbl).PHTShel)) '"Pth   =  #####.#### [MPa]     #######.#### [psi]      Hydr.t.pressure (shell side)"
                Else
                    Call count() : .Printa(GlobalRoutines.FormatS(StriSt(13), Problem(IndProbl).PHTChan / psi, Problem(IndProbl).PHTChan)) '"Psh   =  #####.#### [MPa]     #######.#### [psi]      Hydr.t.pressure (flanged side)"
                    Call count() : .Printa(GlobalRoutines.FormatS(StriSt(14), Problem(IndProbl).PHTShel / psi, Problem(IndProbl).PHTShel)) '"Pth   =  #####.#### [MPa]     #######.#### [psi]      Hydr.t.pressure(welded side)"
                End If
            End If
            Call count() : .Printa(GlobalRoutines.FormatS(StriSt(15), (Problem(IndProbl).Destemp - 32) / 1.8, Problem(IndProbl).Destemp)) '"Tp    =  #####.#### [øC]      #######.#### [øF]       Design temperature"
            If Problem(IndProbl).mart < 2 Then
                If DatiInt(IndProbl).bdice < 2 Then Call count() : .Printa(GlobalRoutines.FormatS(StriSt(16), FlChan(IndProbl).DextFla, FlChan(IndProbl).DextFla / inc)) '"At    = #########.## [mm]     #######.#### [in]       Flange outside diameter (T.S.)"
                If DatiInt(IndProbl).bdice <> 1 Then Call count() : .Printa(GlobalRoutines.FormatS(StriSt(17), FlShel(IndProbl).DextFla, FlShel(IndProbl).DextFla / inc)) '"As    = #########.## [mm]     #######.#### [in]       Flange outside diameter (S.S.)"
            End If
            Call count() : .Printa(GlobalRoutines.FormatS(StriSt(18), Problem(IndProbl).TSheDes, Problem(IndProbl).TSheDes / inc)) '"A     = #########.## [mm]     #######.#### [in]       T.S. outside diameter"
            Call count() : .Printa(GlobalRoutines.FormatS(StriSt(19), Problem(IndProbl).Tiranti(1).BoltCiD, Problem(IndProbl).Tiranti(1).BoltCiD / inc)) '"C     = #########.## [mm]     #######.#### [in]       Bolt-Circle diameter"
            If DatiInt(IndProbl).bdice < 2 Then Call count() : .Printa(GlobalRoutines.FormatS(StriSt(20), FlChan(IndProbl).DmedGua, FlChan(IndProbl).DmedGua / inc)) '"Gt    = #########.## [mm]     #######.#### [in]       Gasket mean diameter,T.S."
            If DatiInt(IndProbl).bdice <> 1 Then Call count() : .Printa(GlobalRoutines.FormatS(StriSt(21), FlShel(IndProbl).DmedGua, FlShel(IndProbl).DmedGua / inc)) '"Gs    = #########.## [mm]     #######.#### [in]       Gasket mean diameter,S.S."
            If DatiInt(IndProbl).bdice < 2 Then Call count() : .Printa(GlobalRoutines.FormatS(StriSt(22), FlShel(IndProbl).DintFla, FlShel(IndProbl).DintFla / inc)) '"Bt    = #########.## [mm]     #######.#### [in]       Inter. flange  dia., T.S."
            If DatiInt(IndProbl).bdice <> 1 Then If FlChan(IndProbl).DintFla > 0 Then Call count() : .Printa(GlobalRoutines.FormatS(StriSt(23), FlChan(IndProbl).DintFla, FlChan(IndProbl).DintFla / inc)) '"Bs    = #########.## [mm]     #######.#### [in]       Inter. flange  dia., S.S."
            If Problem(IndProbl).mart < 2 And FlChan(IndProbl).DintFla > 0 Then
                If DatiInt(IndProbl).bdice < 2 Then Call count() : .Printa(GlobalRoutines.FormatS(StriSt(24), FlChan(IndProbl).CodoMax, FlChan(IndProbl).CodoMax / inc)) '"g1t   = #########.## [mm]     #######.#### [in]       Flange hub max thickness, T.S."
                If DatiInt(IndProbl).bdice <> 1 Then Call count() : .Printa(GlobalRoutines.FormatS(StriSt(25), FlShel(IndProbl).CodoMax, FlShel(IndProbl).CodoMax / inc)) '"g1s   = #########.## [mm]     #######.#### [in]       Flange hub max thickness, S.S."
                If DatiInt(IndProbl).bdice < 2 Then Call count() : .Printa(GlobalRoutines.FormatS(StriSt(26), FlChan(IndProbl).CodoMin, FlChan(IndProbl).CodoMin / inc)) '"g0t   = #########.## [mm]     #######.#### [in]       Flange hub min thickness, T.S."
                If DatiInt(IndProbl).bdice <> 1 Then Call count() : .Printa(GlobalRoutines.FormatS(StriSt(27), FlShel(IndProbl).CodoMin, FlShel(IndProbl).CodoMin / inc)) '"g0s   = #########.## [mm]     #######.#### [in]       Flange hub min thickness, S.S."
            End If
            If DatiInt(IndProbl).bdice > 0 Then
                'CALL count: PRINT #iout, USING StriSt$(28); DatiInt(Indprobl).gef; DatiInt(Indprobl).gef / INC'"Bs    = #########.## [mm]     #######.#### [in]       Inter. tube-sh. dia.(Corroded)"
                Call count() : .Printa(GlobalRoutines.FormatS(StriSt(29), DatiInt(IndProbl).ThkShe, DatiInt(IndProbl).ThkShe / inc)) '"Ts    = #########.## [mm]     #######.#### [in]       Shell thickness (Corroded)"
            Else
                'CALL count: PRINT #iout, USING StriSt$(30); DatiInt(Indprobl).gef; DatiInt(Indprobl).gef / inc'"Bs    = #########.## [mm]     #######.#### [in]       Mean gsk dia.(minimum on sides)"
            End If
            Call count() : .Printa(GlobalRoutines.FormatS(StriSt(31), tfa, tfa / inc)) '"T     = #########.## [mm]     #######.#### [in]       T. sheet thk. adopted (center)"
            Call count() : .Printa(GlobalRoutines.FormatS(StriSt(32), tRa, tRa / inc)) '"Tr    = #########.## [mm]     #######.#### [in]       T. sheet thk. adopted (ext.)"
            Call count() : .Printa(GlobalRoutines.FormatS(StriSt(33), Problem(IndProbl).CorShel, Problem(IndProbl).CorShel / inc)) '"Cs    = #########.## [mm]     #######.#### [in]       Shell side corrosion"
            Call count() : .Printa(GlobalRoutines.FormatS(StriSt(34), Problem(IndProbl).CorChan, Problem(IndProbl).CorChan / inc)) '"Ct    = #########.## [mm]     #######.#### [in]       Tube side corrosion"
            Call count() : .Printa(GlobalRoutines.FormatS(StriSt(35), Problem(IndProbl).CavChan, Problem(IndProbl).CavChan / inc)) '"Gr    = #########.## [mm]     #######.#### [in]       Tube side corr. or groove"
            Lato = "tube-side"
            If Problem(IndProbl).Tiranti(1).NumColl < 0 Then Lato = "shell-side"
            If Problem(IndProbl).mart < 2 Then
                Call count() : .Printa(GlobalRoutines.FormatS(StriSt(36), Problem(IndProbl).Tiranti(1).DiNBull)) '"d     =                \                 \ [--]       Bolts nominal diameter"
                Call count() : .Printa(GlobalRoutines.FormatS(StriSt(37), Problem(IndProbl).Tiranti(1).NumBolt)) '"Nø    =                       #########    [--]       Number of bolts"
                Call count() : .Printa(GlobalRoutines.FormatS(StriSt(38), Problem(IndProbl).Tiranti(1).AreBolt)) '"Ab1   =                       #######.#### [iný]      Area of one bolt"
                PrintBull()
                Call count() : .Printa(GlobalRoutines.FormatS(StriSt(40), Problem(IndProbl).Tiranti(1).BSpcMin, Problem(IndProbl).Tiranti(1).BSpcMin / inc)) '"BSmin = #########.## [mm]     #######.#### [in]       Minimum bolt spacing"
                Call count() : .Printa(GlobalRoutines.FormatS(StriSt(41), DatiInt(IndProbl).BoltSpc, DatiInt(IndProbl).BoltSpc / inc)) '"BS    = #########.## [mm]     #######.#### [in]       Actual  bolt spacing"
                For j = 1 To 2 : Call count() : .Printa(StriSt(1)) : Next
                If VerificandoPI Then
                    Call count() : .Printa(GlobalRoutines.FormatS(StriSt(42), sx / psi, sx)) '"Sfa   =  #####.#### [MPa]     #######.#### [psi]      All.Des.Stress, t.sheet at room"
                Else
                    If VerificandoPI Then
                        Call count() : .Printa(GlobalRoutines.FormatS(StriSt(42), sx / psi, sx)) '"Sfa   =  #####.#### [MPa]     #######.#### [psi]      All.Des.Stress, t.sheet at room"
                    Else
                        Call count() : .Printa(GlobalRoutines.FormatS(StriSt(42), Problem(IndProbl).AllFRoo / psi, Problem(IndProbl).AllFRoo)) '"Sfa   =  #####.#### [MPa]     #######.#### [psi]      All.Des.Stress, t.sheet at room"
                        Call count() : .Printa(GlobalRoutines.FormatS(StriSt(43), Problem(IndProbl).AllFOpe / psi, Problem(IndProbl).AllFOpe)) '"Sfo   =  #####.#### [MPa]     #######.#### [psi]      All.Des.Stress, t.sheet at temp."
                    End If
                End If
                Call count() : .Printa(GlobalRoutines.FormatS(StriSt(44), Problem(IndProbl).Tiranti(1).AllBRoo / psi, Problem(IndProbl).Tiranti(1).AllBRoo)) '"Sba   =  #####.#### [MPa]     #######.#### [psi]      All.Des.Stress, bolts  at room"
                Call count() : .Printa(GlobalRoutines.FormatS(StriSt(45), Problem(IndProbl).Tiranti(1).AllBOpe / psi, Problem(IndProbl).Tiranti(1).AllBOpe)) '"Sbo   =  #####.#### [MPa]     #######.#### [psi]      All.Des.Stress, bolts  at temp."
                Call count() : .Printa(GlobalRoutines.FormatS(StriSt(46), Problem(IndProbl).Tiranti(1).fSicBul)) '"k     =                       #######.#### [--]       Safety factor for bolts"
            Else
                PrintBull()
                Call count() : .Printa(StriSt(82))
                For j = 1 To 2 : Call count() : .Printa(StriSt(1)) : Next
                If VerificandoPI Then
                    Call count() : .Printa(GlobalRoutines.FormatS(StriSt(42), sx / psi, sx)) '"Sfa   =  #####.#### [MPa]     #######.#### [psi]      All.Des.Stress, t.sheet at room"
                Else
                    Call count() : .Printa(GlobalRoutines.FormatS(StriSt(42), Problem(IndProbl).AllFRoo / psi, Problem(IndProbl).AllFRoo)) '"Sfa   =  #####.#### [MPa]     #######.#### [psi]      All.Des.Stress, t.sheet at room"
                    Call count() : .Printa(GlobalRoutines.FormatS(StriSt(43), Problem(IndProbl).AllFOpe / psi, Problem(IndProbl).AllFOpe)) '"Sfo   =  #####.#### [MPa]     #######.#### [psi]      All.Des.Stress, t.sheet at temp."
                End If
            End If
            Call count() : .Printa(GlobalRoutines.FormatS(StriSt(47), Problem(IndProbl).TubDiam, Problem(IndProbl).TubDiam / inc)) '"do    = #########.## [mm]     #######.#### [in]       Tube O.D."
            Call count() : .Printa(GlobalRoutines.FormatS(StriSt(48), Problem(IndProbl).TubPass, Problem(IndProbl).TubPass / inc)) '"p     = #########.## [mm]     #######.#### [in]       Tube pitch"
            Call count() : .Printa(GlobalRoutines.FormatS(StriSt(49), Problem(IndProbl).EquDiam, Problem(IndProbl).EquDiam / inc)) '"Dl    = #########.## [mm]     #######.#### [in]       Equiv. dia. of tube center limit"
            Call count() : .Printa(GlobalRoutines.FormatS(StriSt(50), 2 - Problem(IndProbl).TipPass)) '"Pitch =                       #########    [--]       1=square  2=triang."
            If (Problem(IndProbl).TipPass = 0) Then Call count() : .Printa(GlobalRoutines.FormatS(StriSt(52), DatiInt(IndProbl).FattoNi)) '"ïFact =                       #######.#### [--]       ï=1-(0.785/(p/do)ý)"
            If (Problem(IndProbl).TipPass = 1) Then Call count() : .Printa(GlobalRoutines.FormatS(StriSt(51), DatiInt(IndProbl).FattoNi)) '"ïFact =                       #######.#### [--]       ï=1-(0.907/(p/do)ý)"
            If DatiInt(IndProbl).bdice > 0 Then
                Call count() : .Printa(GlobalRoutines.FormatS(StriSt(53), DatiInt(IndProbl).FPiastr)) '"F     =                       #######.##   [--]       Value of F (17-100(g0s/Bs))/12    1.25 >= F >= 1"
            Else
                Call count() : .Printa(GlobalRoutines.FormatS(StriSt(54), DatiInt(IndProbl).FPiastr)) '"F     =                       #######.##   [--]       Value of F (RCB-7.132)"
            End If
            Call count() : .Printa(StriSt(1))
            Cod = "Data for bolt load calculation "
            If Problem(IndProbl).mart = 2 Then Cod = "Bolt Loads "
            Select Case DatiInt(IndProbl).bdice
                Case 0
                    Call count() : .Printa(GlobalRoutines.FormatS(StriSt(55), Cod)) '; "       "; Cod$; "channel-side"
                    Fl = FlChan(IndProbl)
                    pringuar()
                    Call count() : .Printa(StriSt(1))
                    Call count() : .Printa(GlobalRoutines.FormatS(StriSt(56), Cod)) '"       "; Cod$; "T.S."
                    Fl = FlShel(IndProbl)
                    pringuar()
                Case 1
                    Call count() : .Printa(GlobalRoutines.FormatS(StriSt(55), Cod)) 'channel side
                    Fl = FlChan(IndProbl)
                    pringuar()
                Case 2
                    Call count() : .Printa(GlobalRoutines.FormatS(StriSt(56), Cod)) 'bolt tube side
                    Fl = FlShel(IndProbl)
                    pringuar()
            End Select
            For j = 1 To 2 : Call count() : .Printa(StriSt(1)) : Next
            Call count() : .Printa(GlobalRoutines.FormatS(StriSt(57), Nota(NNOTSW), NNOTE)) '"\   \ : ## - Input of geometric dimensions in [ mm ]. - Displayed values in [ in ]"
            Call count() : .Printa(StriSt(58)) '"                   are fixed by conversion factors."
            NNOTE = NNOTE + 1 : NNOTSW = 1
            If (Problem(IndProbl).SERRA = 0) And Problem(IndProbl).mart < 2 Then
                For j = 1 To 2 : Call count() : .Printa(StriSt(1)) : Next
                Call count() : .Printa(GlobalRoutines.FormatS(StriSt(59), Nota(NNOTSW), NNOTE)) '"\   \ : ## - The rule contained in the note 2 to ASME VIII div.1, App.2-5, will be applied."
                NNOTE = NNOTE + 1
            End If
            If (Problem(IndProbl).SPHT = 0) Then
                For j = 1 To 2 : Call count() : .Printa(StriSt(1)) : Next
                Call count() : .Printa(GlobalRoutines.FormatS(StriSt(60), Nota(NNOTSW), NNOTE)) '"\   \ : ## - The tightness of the flanged joint will be assured up to the hydraulic test pressure."
                Call count() : .Printa(StriSt(61)) '"                   (This is an additional requirement to the code requirements)"
                NNOTE = NNOTE + 1
            End If
            If (Problem(IndProbl).mart = 0) Then
                '   FOR j = 1 TO 2: CALL count: PRINT #iout,StriSt$(1) : NEXT
                '   CALL count: PRINT #iout, USING StriSt$(62); Nota$(NNOTSW); NNOTE'"\   \ : ## - The operating bolt load will not be allowed to be less than seating bolt load."
                '   CALL count: PRINT #iout, StriSt$(61)'"                   (This is an additional requirement to the code requirements)"
                '   NNOTE = NNOTE + 1
            End If
            If (Problem(IndProbl).PDIFF = 0) Then
                For j = 1 To 2 : Call count() : .Printa(StriSt(1)) : Next
                Call count() : .Printa(GlobalRoutines.FormatS(StriSt(63), Nota(NNOTSW), NNOTE)) '"\   \ : ## - The equipment will be dimensioned under differential pressure only."
                Call count() : .Printa(GlobalRoutines.FormatS(StriSt(79), Problem(IndProbl).DiffPress / psi, Problem(IndProbl).DiffPress))
                If (Problem(IndProbl).SPHT = 0) Then
                    Call count() : .Printa(GlobalRoutines.FormatS(StriSt(84), Problem(IndProbl).DiffPressHT / psi, Problem(IndProbl).DiffPressHT))
                End If
                'Call count: Print #iout, StriSt$(64) '"                   (This is an additional requirement to the TEMA rules)"
                NNOTE = NNOTE + 1
            End If
            If (Problem(IndProbl).FLEX > 0) Then
                '   For j = 1 To 2: Call count: Print #iout, StriSt$(1): Next
                '   Call count: Print #iout, FormatS(StriSt$(64), Nota(NNOTSW), NNOTE)  '"\   \ : ## - When calculating the stresses in the extension, also radial bending will be accounted."
                '   Call count: Print #iout, StriSt$(65) '"                   (This is an additional requirement to the TEMA rules)"
                '   NNOTE = NNOTE + 1
            End If
            If (Problem(IndProbl).Vacuum > 0 And Problem(IndProbl).PDIFF > 0) Then
                For j = 1 To 2 : Call count() : .Printa(StriSt(1)) : Next
                Select Case Problem(IndProbl).Vacuum
                    Case 1
                        Call count() : .Printa(GlobalRoutines.FormatS(StriSt(65), Nota(NNOTSW), NNOTE)) '"\   \ : ## - The shell side may operate under vacuum."
                    Case 2
                        Call count() : .Printa(GlobalRoutines.FormatS(StriSt(66), Nota(NNOTSW), NNOTE)) '"\   \ : ## - The tube side may operate under vacuum."
                    Case 3
                        Call count() : .Printa(GlobalRoutines.FormatS(StriSt(67), Nota(NNOTSW), NNOTE)) '"\   \ : ## - Both tube and shell sides may operate under vacuum."
                End Select
                NNOTE = NNOTE + 1
            End If
            NNOTSW = 0
            For j = 1 To 2 : Call count() : .Printa(StriSt(1)) : Next
            If Problem(IndProbl).mart < 2 Then
                NewPage()
                jFlan = 0
                For iFlan = 0 To 1
                    If DatiInt(IndProbl).bdice = 1 And iFlan = 1 Or DatiInt(IndProbl).bdice = 2 And iFlan = 0 Then GoTo Cont2
                    If jFlan = 0 Then
                        Cod = Space(5)
                        Call testaU(Cod)
                        Call count() : .Printa(GlobalRoutines.FormatS(StriSt(68), Titol(1))) '"                            OUTPUT  DATA (check of the bolted joint sizeing)\\"
                        Call count() : .Printa(StriSt(69)) '"                            ============"
                        jFlan = 1
                    End If
                    Call count() : .Printa(StriSt(1))
                    If Not FlChan(IndProbl).DintFla < 0 Then Call count() : .Printa(GlobalRoutines.FormatS(StriSt(70), Flangia(iFlan))) '"                      (Data for the flange \  \-side)"
                    If iFlan = 0 Then
                        Fl = FlChan(IndProbl) : printc(iFlan) : nr = NRIGHE + 1
                    End If
                    If iFlan = 1 Then
                        Fl = FlShel(IndProbl) : printc(iFlan)
                    End If
                    For j = 1 To 2 : Call count() : .Printa(StriSt(1)) : Next
Cont2:
                Next iFlan
                Call count() : .Printa(GlobalRoutines.FormatS(StriSt(71), Nota(NNOTSW), NNOTE)) '"\   \ : ## - Calculation performed using values in Imperial Units. Displayed values in ISU"
                Call count() : .Printa(StriSt(72)) '"                   are fixed by conversion factors."
                NNOTE = NNOTE + 1 : NNOTSW = 1
                If (Problem(IndProbl).CRUSH = 0 And FlChan(IndProbl).SWCRUS = 1) Then
                    For j = 1 To 2 : Call count() : .Printa(StriSt(1)) : Next
                    Call count() : .Printa(GlobalRoutines.FormatS(StriSt(73), Nota(NNOTSW), NNOTE)) '"\   \ : ## - The gasket channel-side could be overstressed, according to VSR code."
                    NNOTE = NNOTE + 1
                End If
                If (Problem(IndProbl).CRUSH = 0 And FlShel(IndProbl).SWCRUS = 1) Then
                    For j = 1 To 2 : Call count() : .Printa(StriSt(1)) : Next
                    Call count() : .Printa(GlobalRoutines.FormatS(StriSt(74), Nota(NNOTSW), NNOTE)) '"\   \ : ## - The gasket shell-side could be overstressed, according to VSR code."
                    NNOTE = NNOTE + 1
                End If
                If (DatiInt(IndProbl).SWITCH_Renamed = 1) Then
                    For j = 1 To 2 : Call count() : .Printa(StriSt(1)) : Next
                    Call count() : .Printa(GlobalRoutines.FormatS(StriSt(75), Nota(NNOTSW), NNOTE)) '"\   \ : ## - CAUTION: The bolt spacing could be isuffucient!"
                    NNOTE = NNOTE + 1
                End If
                If (FlChan(IndProbl).SWITCH_Renamed = 1 And Not FlChan(IndProbl).DintFla < 0) Then
                    For j = 1 To 2 : Call count() : .Printa(StriSt(1)) : Next
                    Call count() : .Printa(GlobalRoutines.FormatS(StriSt(76), Nota(NNOTSW), NNOTE)) '"\   \ : ## - CAUTION: The bolt area is insufficient for the flange channel-side!"
                    NNOTE = NNOTE + 1
                End If
                If (FlShel(IndProbl).SWITCH_Renamed = 1 And Not FlChan(IndProbl).DintFla < 0) Then
                    For j = 1 To 2 : Call count() : .Printa(StriSt(1)) : Next
                    Call count() : .Printa(GlobalRoutines.FormatS(StriSt(77), Nota(NNOTSW), NNOTE)) '"\   \ : ## - CAUTION: The bolt area is insufficient for the flange shell-side!"
                    NNOTE = NNOTE + 1
                End If
            End If
            For j = 1 To 2 : Call count() : .Printa(StriSt(1)) : Next
            Call count() : .Printa(GlobalRoutines.FormatS(StriSt(78), Nota(NNOTSW), NNOTE, Titol(DatiInt(IndProbl).IMAX))) '"\   \ : ## - The dimensioning load case is: \                                 \"
            NNOTE = NNOTE + 1
            NNOTSW = 0
            For j = 1 To 2 : Call count() : .Printa(StriSt(1)) : Next
        End With
        If nr = 0 Then Exit Sub
        NewPage()
    End Sub
    Private Sub PrintBull()
        With Monitor.Motore.Problem
            If DatiInt(IndProbl).bdice = 0 Then
                If BullDistinti Then
                    Call count() : .Printa(StriSt(83))
                    If BullIndip Then
                        Call count() : .Printa(StriSt(85))
                    Else
                        Call count() : .Printa(StriSt(86))
                    End If
                Else
                    Call count() : .Printa(GlobalRoutines.FormatS(StriSt(39), System.Math.Abs(Problem(IndProbl).Tiranti(1).NumColl))) '"Nø    =                       #########    [--]       Number of bolts with collars"
                    Call count() : .Printa(GlobalRoutines.FormatS(StriSt(81), Lato))
                End If
            End If
        End With
    End Sub
    Private Sub printb(ByRef ic As Short)
        Dim StriSt(65) As String
        Dim Cod As String = ""
        Dim i, ifl, Nf As Short
        Dim j As Short
        Dim Ped As String = ""
        Dim DiamCalc As String = ""
        Dim Codst As String
        Dim NNOTW As Short ', nr1 As Integer
        If nr < 3 Then
            Cod = Space(5)
            Call testaU(Cod)
        End If
        ifl = FreeFile()
        Nf = 65
        FileOpen(ifl, RTrim(Monitor.Motore.Inizio.Archdir) & "\RTF\STAM02.EXT", OpenMode.Input, , OpenShare.Shared)
        For i = 1 To Nf
            StriSt(i) = LineInput(ifl)
        Next
        FileClose(ifl)
        With Monitor.Motore.Problem
            Call count() : .Printa(GlobalRoutines.FormatS(StriSt(2), Titol(ic))) '"         VERIFICATIONS   in '\                                                    \'"
            Call count() : .Printa(StriSt(3)) '"         ============="
            For j = 1 To 2 : Call count() : .Printa(StriSt(1)) : Next
            If Problem(IndProbl).mart < 2 Then
                Call count() : .Printa(StriSt(4)) ' "   FOR GASKET DATA SEE PRECEEDING SHEETS"
                For j = 1 To 2 : Call count() : .Printa(StriSt(1)) : Next
                If DatiInt(IndProbl).bdice > 0 Then
                    Call count() : .Printa(GlobalRoutines.FormatS(StriSt(5), DatiInt(IndProbl).HGP, DatiInt(IndProbl).am1)) '"Hp   =             #########.# [lb]  (Recalling)  º Am1   =  ######.#### [iný]  Wm1/Sbo.k"
                    Call count() : .Printa(GlobalRoutines.FormatS(StriSt(6), DatiInt(IndProbl).H, DatiInt(IndProbl).am2)) '"H    =             #########.# [lb]  (Recalling)  º Am2   =  ######.#### [iný]  Wm2/Sba.k"
                    Call count() : .Printa(GlobalRoutines.FormatS(StriSt(7), DatiInt(IndProbl).wm1, DatiInt(IndProbl).am)) '"Wm1  =             #########.# [lb]  H+Hp         º Am    =  ######.#### [iný]  max.Am1.Am2"
                    Call count() : .Printa(GlobalRoutines.FormatS(StriSt(8), DatiInt(IndProbl).wm2, DatiInt(IndProbl).AreaBol)) '"Wm2  =             #########.# [lb]  (Recalling)  º Ab    =  ######.#### [iný]  Ab1.Nø"
                Else
                    Call count() : .Printa(GlobalRoutines.FormatS(StriSt(9), FlChan(IndProbl).HGP, FlChan(IndProbl).am1)) '"Hp   =(tube-side)  #########.# [lb]  (Recalling)  º Am1   =  ######.#### [iný]  Wm1/Sbo.k"
                    Call count() : .Printa(GlobalRoutines.FormatS(StriSt(10), FlChan(IndProbl).H, FlChan(IndProbl).am2)) '"H    =( =    =  )  #########.# [lb]  (Recalling)  º Am2   =  ######.#### [iný]  Wm2/Sba.k"
                    Call count() : .Printa(GlobalRoutines.FormatS(StriSt(11), FlChan(IndProbl).wm1, FlChan(IndProbl).am)) '"Wm1  =( =    =  )  #########.# [lb]  H+Hp         º Am    =  ######.#### [iný]  max.Am1.Am2"
                    Call count() : .Printa(GlobalRoutines.FormatS(StriSt(12), FlChan(IndProbl).wm2, DatiInt(IndProbl).AreaBol)) '"Wm2  =( =    =  )  #########.# [lb]  (Recalling)  º Ab    =  ######.#### [iný]  Ab1.Nø"
                    Call count() : .Printa(GlobalRoutines.FormatS(StriSt(13), FlChan(IndProbl).wmt)) '"Wmt  =(tube-side)  #########.# [lb]  (Recalling)"
                    Call count() : .Printa(GlobalRoutines.FormatS(StriSt(14), FlShel(IndProbl).HGP, FlShel(IndProbl).am1)) '"Hp   =(shell-side) #########.# [lb]  (Recalling)  º Am1   =  ######.#### [iný]  Wm1/Sbo.k"
                    Call count() : .Printa(GlobalRoutines.FormatS(StriSt(15), FlShel(IndProbl).H, FlShel(IndProbl).am2)) '"H    =( =    =   ) #########.# [lb]  (Recalling)  º Am2   =  ######.#### [iný]  Wm2/Sba.k"
                    Call count() : .Printa(GlobalRoutines.FormatS(StriSt(16), FlShel(IndProbl).wm1, FlShel(IndProbl).am)) '"Wm1  =( =    =   ) #########.# [lb]  H+Hp         º Am    =  ######.#### [iný]  max.Am1.Am2"
                    Call count() : .Printa(GlobalRoutines.FormatS(StriSt(17), FlShel(IndProbl).wm2, DatiInt(IndProbl).AreaBol)) '"Wm2  =(shell-side) #########.# [lb]  (Recalling)  º Ab    =  ######.#### [iný]  Ab1.Nø"
                End If
                Select Case Problem(IndProbl).SERRA
                    Case 0 : Call count() : .Printa(GlobalRoutines.FormatS(StriSt(18), wot)) '"W    =             #########.# [lb]  Ab.«Sba "
                    Case 1 : Call count() : .Printa(GlobalRoutines.FormatS(StriSt(19), wot)) '"W    =             #########.# [lb]  (Am+Ab).«Sba "
                        If DatiInt(IndProbl).bdice = 0 Then .Printa(StriSt(20)) Else .Printa(StriSt(1))
                    Case 3 'da fare
                End Select
                If Not (FlChan(IndProbl).DintFla < 0 And DatiInt(IndProbl).bdice = 2) Then
                    If DatiInt(IndProbl).bdice > 0 Then
                        Call count() : .Printa(GlobalRoutines.FormatS(StriSt(21), DatiInt(IndProbl).hHg)) '"hG    =                   ######.#### [in]  «(C-Gef)     "
                        Call count() : .Printa(GlobalRoutines.FormatS(StriSt(22), DatiInt(IndProbl).rrr)) '"R     =                   ######.#### [in]  (C-Bs-Ts)/2"
                        If DatiInt(IndProbl).hHd > 0 Then Call count() : .Printa(GlobalRoutines.FormatS(StriSt(23), DatiInt(IndProbl).hHd)) '"hD    =                   ######.#### [in]  R+0.5Ts"
                        If DatiInt(IndProbl).bdice < 2 Then Call count() : .Printa(GlobalRoutines.FormatS(StriSt(24), FlChan(IndProbl).hHt)) '"hT    =  (T.S.)      ######.#### [in]  (R+Ts+hG)/2"
                        If DatiInt(IndProbl).bdice <> 1 Then Call count() : .Printa(GlobalRoutines.FormatS(StriSt(25), FlShel(IndProbl).hHt)) '"hT    =  (S.S.)     ######.#### [in]  (R+Ts+hG)/2"
                        Call count() : .Printa(GlobalRoutines.FormatS(StriSt(26), DatiInt(IndProbl).hHm)) '"hM    =                   ######.#### [in]  (C-Bs)/2"
                        If Problem(IndProbl).mart = 0 Then
                            If DatiInt(IndProbl).bdice < 2 Then Call count() : .Printa(GlobalRoutines.FormatS(StriSt(27), fHg1(ic))) '"HG    =  (T.S.)      #########.# [lb]  W-0.785GefýP"
                            If DatiInt(IndProbl).bdice <> 1 Then Call count() : .Printa(GlobalRoutines.FormatS(StriSt(28), fHg2(ic))) '"HG    =  (S.S.)     #########.# [lb]  W-0.785GefýP1"
                        Else
                            If DatiInt(IndProbl).bdice < 2 Then Call count() : .Printa(GlobalRoutines.FormatS(StriSt(29), fHg1(ic))) '"HG    =  (T.S.)      #########.# [lb]  Wm1-0.785GefýP"
                            If DatiInt(IndProbl).bdice <> 1 Then Call count() : .Printa(GlobalRoutines.FormatS(StriSt(30), fHg2(ic))) '"HG    =  (S.S.)     #########.# [lb]  Wm1-0.785GefýP1"
                        End If
                        If DatiInt(IndProbl).bdice = 1 Then Call count() : .Printa(GlobalRoutines.FormatS(StriSt(31), fHd(ic))) '"HD    =                   #########.# [lb]  0.785BsýP1"
                        If DatiInt(IndProbl).bdice = 2 Then Call count() : .Printa(GlobalRoutines.FormatS(StriSt(32), fHd(ic))) '"HD    =                   #########.# [lb]  0.785BsýP"
                        If DatiInt(IndProbl).bdice < 2 Then Call count() : .Printa(GlobalRoutines.FormatS(StriSt(33), fHt1(ic))) '"HT    =  (T.S.)      #########.# [lb]  0.785(Gefý-Bsý)P"
                        If DatiInt(IndProbl).bdice <> 1 Then Call count() : .Printa(GlobalRoutines.FormatS(StriSt(34), fHt1(ic))) '"HT    =  (S.S.)     #########.# [lb]  0.785(Gefý-Bsý)P1"
                        Call count() : .Printa(GlobalRoutines.FormatS(StriSt(35), fHm(ic))) '"HM    =                   #########.# [lb]  0.785Bsý(P-P1)"
                    Else
                        Call count() : .Printa(GlobalRoutines.FormatS(StriSt(36), FlChan(IndProbl).hHg)) '"hG    =    (T.S.)    ######.#### [in]  «(C-Gef)     "
                        Call count() : .Printa(GlobalRoutines.FormatS(StriSt(37), FlShel(IndProbl).hHg)) '"hG    =    (S.S.)   ######.#### [in]  «(C-Gef)     "
                        '  CALL count: PRINT #iout, USING StriSt$(38), FlChan(Indprobl).rrr'"R     =    (T.S.)    ######.#### [in]  (C-Bs-Ts)/2"
                        '  CALL count: PRINT #iout, USING StriSt$(39), FlShel(Indprobl).rrr'"R     =    (S.S.)   ######.#### [in]  (C-Bs-Ts)/2"
                    End If
                End If
            End If
            Select Case DatiInt(IndProbl).bdice
                Case 0
                    Select Case ic
                        Case 2 : Ped = "t"
                        Case 3 : Ped = "s"
                        Case 4, 5 : Ped = "m" 'biflangiata
                    End Select
                    DiamCalc = "G"
                Case 1 : Ped = "t" 'flangia tube-side
                    Select Case ic
                        Case 2 : DiamCalc = "G" 'lato tubi
                        Case 3 : DiamCalc = "B" 'lato shell
                        Case 4 : DiamCalc = "M" 'pdiff
                        Case 5 : DiamCalc = "M" 'seating
                    End Select
                Case 2 : Ped = "s" 'flangia shell-side
                    Select Case ic
                        Case 2 : DiamCalc = "B" 'lato tubi
                        Case 3 : DiamCalc = "G" 'lato shell
                        Case 4 : DiamCalc = "M" 'pdiff
                        Case 5 : DiamCalc = "M" 'seating
                    End Select
            End Select
            Call count() : .Printa(GlobalRoutines.FormatS(StriSt(58), DiamCalc, Ped, Gcalc(ic), Gcalc(ic) / inc)) '"w     =  #####.## [mm] ######.#### [in]  «(As-Bs) RCB-7.1342"
            Call count() : .Printa(GlobalRoutines.FormatS(StriSt(40), ww(ic) * inc, ww(ic))) '"w     =  #####.## [mm] ######.#### [in]  «(As-Bs) RCB-7.1342"
            If Problem(IndProbl).mart < 2 Then
                If DatiInt(IndProbl).bdice = 0 Then
                    Call count() : .Printa(GlobalRoutines.FormatS(StriSt(41), mx00(ic))) '"M1    =                    #########.# [lb.in]  (RCB-7.162)   (*) "
                    Call count() : .Printa(GlobalRoutines.FormatS(StriSt(42), m2(ic))) '"M2    =                    #########.# [lb.in]  (RCB-7.162)   (*) "
                    Call count() : .Printa(GlobalRoutines.FormatS(StriSt(43), mx0(ic))) '"M     =                    #########.# [lb.in]  (RCB-7.1342)  (*) "
                    Call count() : .Printa(StriSt(44)) '"(*) scaled down by number of bolts with collars, when applicable"
                Else
                    If FlChan(IndProbl).DintFla < 0 Then
                        Call count() : .Printa(GlobalRoutines.FormatS(StriSt(65), mx00(ic))) '"M1    =                   #########.# [lb.in]  HG*hG+HD*hD+HT*hT+HM*hM"
                    Else
                        Call count() : .Printa(GlobalRoutines.FormatS(StriSt(45), mx00(ic))) '"M1    =                   #########.# [lb.in]  HG*hG+HD*hD+HT*hT+HM*hM"
                    End If
                    'For j = 1 To 2: Call count: Print #iout, StriSt$(1): Next
                    If m2(ic) = 0 Then
                        Call count() : .Printa(GlobalRoutines.FormatS(StriSt(46), mx0(ic))) '"M     =                   #########.# [lb.in]  =M1 (M2 is zero)"
                    Else
                        Call count() : .Printa(GlobalRoutines.FormatS(StriSt(47), m2(ic))) '"M2    =                   #########.# [lb.in]  hg.W       "
                        Call count() : .Printa(GlobalRoutines.FormatS(StriSt(48), mx0(ic))) '"M     =                   #########.# [lb.in]  Greater of M1,M2"
                    End If
                End If
            Else
                Call count() : .Printa(GlobalRoutines.FormatS(StriSt(49), mx00(ic) * NIUT * inc / 1000, mx00(ic), Ped)) '"M1    = #########.# [N.m] #########.# [lb.in]  Wm1.w             "
                Call count() : .Printa(GlobalRoutines.FormatS(StriSt(50), m2(ic) * NIUT * inc / 1000, m2(ic), Ped)) '"M2    = #########.# [N.m] #########.# [lb.in]  Wm2.w             "
                Call count() : .Printa(GlobalRoutines.FormatS(StriSt(51), mx0(ic) * NIUT * inc / 1000, mx0(ic))) '"M     = #########.# [N.m] #########.# [lb.in]  Greatest(M1,M2)   "
                If DatiInt(IndProbl).bdice = 0 And Problem(IndProbl).Tiranti(1).NumColl < Problem(IndProbl).Tiranti(1).NumBolt And Problem(IndProbl).Tiranti(1).NumColl > 0 And ic < 5 And (m2(ic) <> 0 Or mx0(ic) <> 0) Then Call count() : .Printa(StriSt(64))
            End If
            Call count() : .Printa(GlobalRoutines.FormatS(StriSt(52), trxi1(ic) * inc, trxi1(ic))) '"Tri   = #####.# [mm]  ####.#### [in]     Assumed extend. port. thk."
            Call count() : .Printa(GlobalRoutines.FormatS(StriSt(53), mxx1(ic) * NIUT * inc / 1000, mxx1(ic))) '"M*    =#########.#  [N.m] #######.# [lb.in]  RCB-7.1342 "
            Call .copia(RTrim(Monitor.Motore.Inizio.Archdir) & "\RTF\FIG01.EXT")
            Call count() : .Printa(GlobalRoutines.FormatS(StriSt(54), pb1(ic) / psi, pb1(ic))) '"Pb    =#######.#### [MPa] #######.# [psi]  -6.2M*/FýBsü Equivalent bolt pressure"
            Select Case ic
                Case 2, 3 : Codst = "(P{\sub t}-P{\sub s})"
                    'Case 3: Codst = "(P-P{_\sub t})"
                Case Else : Codst = "P{\sub d}"
            End Select
            Call count() : .Printa(GlobalRoutines.FormatS(StriSt(55), px1(ic) / psi, px1(ic), Codst)) '"P'    =#######.#### [MPa] #######.# [psi]  (P-P1) + Pb          Adopted pressure"
            'If ic = 2 Or ic = 3 Then Call count:      Print #iout, StriSt$(56) '"       Note: P is the pressure on this side, P1 the pressure on the other side"
            Call count() : .Printa(GlobalRoutines.FormatS(StriSt(57), tf1(ic) * inc, tf1(ic))) '"Tf    = #####.# [mm] #####.#### [in]     (FGef/3)û(P'/ïSfo)    Bending thk."
            If DatiInt(IndProbl).bdice = 0 Then
                Call count() : .Printa(GlobalRoutines.FormatS(StriSt(59), tshe1(ic) * inc, tshe1(ic))) '"Ts    = #####.# [mm] #####.#### [in]     0.31Dl*P/(1-do/p)Sfo  Shear thk."
            Else
                Call count() : .Printa(GlobalRoutines.FormatS(StriSt(60), tshe1(ic) * inc, tshe1(ic))) '"Ts    = #####.# [mm] #####.#### [in]     0.31Dl*P/(1-do/p)Sfo  Shear thk."
            End If
            Call count() : .Printa(GlobalRoutines.FormatS(StriSt(61), trxc1(ic) * inc, trxc1(ic))) '"Trc   = #####.# [mm]  ####.#### [in]     Minimum ext. port. thk.(Tr RCB-7-1342"
            Call .copia(Monitor.Motore.Inizio.Archdir.Trim & "\RTF\FIG02.EXT")
            Call count() : .Printa(GlobalRoutines.FormatS(StriSt(62), tmax(ic, 0), tmax(ic, 0) / inc)) '"tmin  = #####.# [mm]  ####.#### [in]     Max(Tf,Ts)+Cs+Max(Ct,Gr)  Min thk. at center"
            Call count() : .Printa(GlobalRoutines.FormatS(StriSt(63), tRmax(ic, 0), tRmax(ic, 0) / inc)) '"trmin = #####.# [mm]  ####.#### [in]     Tri                                         "
            If (tras(ic, 0) > tRmax(ic, 0)) Then
                '   FOR j = 1 TO 2: CALL count: PRINT #iout, : NEXT
                '   CALL count: PRINT #iout, USING "\   \ : ## - Warning. The second formula of UG-34(c)(2) is not satisfied.(Hint: set FLEX=1)", Nota$(NNOTSW), NNOTE
            End If
            NNOTW = 0
            If nr > 35 Then
                NewPage()
            End If
        End With
    End Sub

    Private Sub printc(ByRef iFlan As Short)
        Dim StriSt(29) As String
        Dim ifl, i As Short
        Dim j As Short
        Dim a As String
        ifl = FreeFile()
        FileOpen(ifl, RTrim(Monitor.Motore.Inizio.Archdir) & "\RTF\STAM03.EXT", OpenMode.Input, , OpenShare.Shared)
        For i = 1 To 29
            StriSt(i) = LineInput(ifl)
        Next
        FileClose(ifl)
        With Monitor.Motore.Problem
            Call count() : .Printa(GlobalRoutines.FormatS(StriSt(2), Fl.bo, Fl.bo / inc)) '"bo    = #######.#### [mm]     #######.#### [in]       Basic gasket seating width"
            Call count() : .Printa(GlobalRoutines.FormatS(StriSt(3), Fl.b1inc * inc, Fl.b1inc)) '"b     = #######.#### [mm]     #######.#### [in]       Effective gasket seating width"
            Call count() : .Printa(GlobalRoutines.FormatS(StriSt(4), Fl.gefinc * inc, Fl.gefinc)) '"Gef   = #######.#### [mm]     #######.#### [in]       Dia. of gasket load reaction"
            For j = 1 To 2 : Call count() : .Printa(StriSt(1)) : Next
            Call count() : .Printa(StriSt(5)) '"Phi = 1  _  bo = N/2        º Phi = 5  _  bo = 3N/8       º boó¬  _    b = bo"
            Call count() : .Printa(StriSt(6)) '"Phi = 2  _  bo = (w+N)/4    º Phi = 6  _  bo = 7N/16      º boó¬  _  Gef = G"
            Call count() : .Printa(StriSt(7)) '"Phi = 3  _  bo = (w+3N)/8   º Phi = 7  _  bo = N/8        º bo>¬  _    b = 0,5.ûbo"
            Call count() : .Printa(StriSt(8)) '"Phi = 4  _  bo = N/4        º                             º bo>¬  _  Gef = G+N-2b"
            For j = 1 To 2 : Call count() : Next
            a = strp(2 + iFlan + (1 - Problem(IndProbl).SPHT) * 3)
            If Problem(IndProbl).PDIFF = 0 Then a = strp(4)
            Call count() : .Printa(GlobalRoutines.FormatS(StriSt(9), Fl.HGP, a, Fl.am1)) '"Hp    =      #########.# [lb]  ã.2b.Gef.m.\\º Am1   =  ######.#### [iný]  Wm1/Sbo.k"
            Call count() : .Printa(GlobalRoutines.FormatS(StriSt(10), Fl.H, a, Fl.am2)) '"H     =      #########.# [lb]  ¬ã.Gefý.\\   º Am2   =  ######.#### [iný]  Wm2/Sba.k"
            If Fl.wmt = 0 Then
                Call count() : .Printa(GlobalRoutines.FormatS(StriSt(11), Fl.wm1, Fl.am)) '"Wm1   =      #########.# [lb]  H+Hp         º Am    =  ######.#### [iný]  max.Am1.Am2"
                Call count() : .Printa(GlobalRoutines.FormatS(StriSt(12), Fl.wm2, DatiInt(IndProbl).AreaBol)) '"Wm2   =      #########.# [lb]  ã.b.Gef.y    º Ab    =  ######.#### [iný]  Ab1.Nø"
            Else
                Call count() : .Printa(GlobalRoutines.FormatS(StriSt(13), Fl.wm1, Fl.am)) '"Wm1   =      #########.# [lb]  H+Hp+Wmt'    º Am    =  ######.#### [iný]  max.Am1.Am2"
                Call count() : .Printa(GlobalRoutines.FormatS(StriSt(14), Fl.wm2, DatiInt(IndProbl).AreaBol)) '"Wm2   =      #########.# [lb]  ã.b.Gef.y+Wmtº Ab    =  ######.#### [iný]  Ab1.Nø"
            End If
            If Problem(IndProbl).SERRA = 0 Then
                Call count() : .Printa(GlobalRoutines.FormatS(StriSt(15), wot)) '"W     =      #########.# [lb]     Ab.«Sba "
            Else
                Call count() : .Printa(GlobalRoutines.FormatS(StriSt(16), wot)) '"W     =      #########.# [lb]     (Am+Ab).«Sba "
                If DatiInt(IndProbl).bdice = 0 Then .Printa(StriSt(17)) Else .Printa(StriSt(1))
            End If
            If Problem(IndProbl).CRUSH = 0 Then
                Call count() : .Printa(GlobalRoutines.FormatS(StriSt(18), Fl.AreaCrs)) '"Amax  =      ######.#### [iný]    2ãyN/Sba Bolt area for gasket crush"
            End If
            Call count() : .Printa(GlobalRoutines.FormatS(StriSt(19), Fl.hHg)) 'hG    =      ######.#### [in]     «(C-Gef)
            If FlChan(IndProbl).DintFla > 0 Then
                Call count() : .Printa(GlobalRoutines.FormatS(StriSt(20), Fl.rrr)) '"R     =      ######.#### [in]  (C-B)/2-g1"
                If DatiInt(IndProbl).bdice > 0 Then Call count() : .Printa(GlobalRoutines.FormatS(StriSt(21), Fl.hHd)) '"hD    =       ######.#### [in]  R+0.5g1"
                Call count() : .Printa(GlobalRoutines.FormatS(StriSt(22), Fl.hHt)) '"hT    =      ######.#### [in]  (R+g1+hG)/2"
                If Problem(IndProbl).mart = 0 Then
                    Call count() : .Printa(GlobalRoutines.FormatS(StriSt(23), Fl.fHg)) '"HG    =      #########.# [lb]  W-H"
                Else
                    Call count() : .Printa(GlobalRoutines.FormatS(StriSt(24), Fl.fHg)) '"HG    =      #########.# [lb]  Wm1-H"
                End If
                If DatiInt(IndProbl).bdice > 0 Then Call count() : .Printa(GlobalRoutines.FormatS(StriSt(25), Fl.fHd)) '"HD    =      #########.# [lb]  0.785BýP"
                Call count() : .Printa(GlobalRoutines.FormatS(StriSt(26), Fl.fHt)) '"HT    =      #########.# [lb]  H-HD"
            End If
            If FlChan(IndProbl).DintFla < 0 Then
                Call count() : .Printa(GlobalRoutines.FormatS(StriSt(29), Fl.m1)) '"M0 (oper.)=  #########.# [lb.in]  HG*hG+HD*hD+HT*hT"
            Else
                Call count() : .Printa(GlobalRoutines.FormatS(StriSt(27), Fl.m1)) '"M0 (oper.)=  #########.# [lb.in]  HG*hG+HD*hD+HT*hT"
            End If
            Call count() : .Printa(GlobalRoutines.FormatS(StriSt(28), Fl.m2)) '"M0 (seat.)=  #########.# [lb.in]  hg.W       "
            For j = 1 To 2 : Call count() : .Printa(StriSt(1)) : Next
        End With
    End Sub

    Private Sub testaU(ByRef Cod As String)
        Dim i, ifl As Short
        Dim StriSt(9) As String
        ifl = FreeFile()
        FileOpen(ifl, RTrim(Monitor.Motore.Inizio.Archdir) & "\RTF\STAM05.EXT", OpenMode.Input, , OpenShare.Shared)
        For i = 1 To 9
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
            ' Call count() : .Printa(StriSt(3)) '"              ==========================                                         "
            Call count() : .Printa(StriSt(4)) '"      TUBULAR EXCHANGER MANUFACTURER ASSOCIATION 1988 7th ed. + add.92"
            Call count() : .Printa(StriSt(5)) '"      ================================================================"
            Call count() : .Printa(StriSt(6)) '"                  RCB-7.132 RCB-7.1342 RCB-7.162"
            Call count() : .Printa(StriSt(7)) '"           U  TUBESHEETS  WITH EXTENSION AS A FLANGE"
            Call count() : .Printa(StriSt(8)) '"           ==============================================="
        End With
    End Sub
    'Function ApriLeggiU() As Boolean
    '        Dim Ext As String, i As Integer, Res As Boolean
    '        Dim Log1 As Boolean, Log2 As Boolean, Log3 As Boolean
    '        Dim Look As Look, Chan As Boolean, Shel As Boolean
    '        Dim k As Integer, Nguar As Integer, a As String
    '        Dim Flangia As datiFlangia, j As Integer, JP As Integer
    '        Problem(Indprobl).SERRA = 1
    '        ApriLeggiU = True
    '        On Local Error GoTo 2430
    'If AddDistinta > 0 Then 'calcolo chiamato da PPSM su una particolare membratura
    '82      Call CercaWNDU(0, Suffix$)  'genera Suffix$
    '        Ext$ = ".EXT"
    '        icome$ = RTrim$(Monitor.Motore.Inizio.Workdir) + "\A" + RTrim$(Lav(0).Arch) + Chr$(92) + Lav(0).File(Lav(0).NumAs) + Suffix$ + Ext$
    '        GoSub TransWND
    '90      If Len(Dir$(icome$)) > 0 Then GoSub Carica ': Call converti
    ''-------------------------------------------------------------------
    'Else                   'calcolo stand-alone
    ''      Ext$ = "EXT"
    ''      icome$ = ""
    ''      LOCATE 23, 19
    ''      Print " CARICAMENTO DATI DI LAVORI GIA' ESEGUITI ": Color 7, 1
    ''      LOCATE 24, 19
    ''      Print "SCEGLINE UNO DA CARICARE, OPPURE BATTI <Esc>";
    ''      icome$ = ScegliFile$("Lista lavori", RTrim$(Datidir), Ext$, True)
    ''      If icome$ = "" Then
    ''         icome$ = NewLavU
    ''         If Len(icome$) = 0 Then ApriLeggiU = False: Exit Function
    ''         icome$ = RTrim$(Datidir) + "\" + RTrim$(icome$) + ".EXT"
    ''      Else
    ''         icome$ = RTrim$(Datidir) + "\" + icome$
    ''         GoSub Carica
    ''         Call converti
    ''      End If
    ' End If
    'Exit Function
    ''--------------------------------------------------
    'TransWND:
    '   For i = 1 To JRECMAX: Record(i).ind = 0: Record(i).Tipo = 0: Next
    '   Res = DomandeU
    '   ApriLeggiU = Res
    '  If Not Res Then Return
    '  Call LookTipoPiastra(Record(0).Dati(), Look)
    '   Select Case Look.TipoV
    '      Case 3 'codolo lato shell     'NON VA
    '         If Mid$(Record(0).PosSpa.Anomal, 6, 1) = "C" Then
    '         DatiInt(Indprobl).bdice = 2
    '         ElseIf Mid$(Record(0).PosSpa.Anomal, 6, 1) = "M" Then
    '         DatiInt(Indprobl).bdice = 1
    '         End If
    '         Problem(Indprobl).TExtThk = Look.t - Look.H3 - Look.H4
    '      Case 6 'sandwitch
    '         DatiInt(Indprobl).bdice = 0
    '         Problem(Indprobl).TExtThk = Look.t - 2 * Look.H1
    '      Case Else
    '        messagebox.show "Errore 2 in ApriLeggiU TipoV="
    '        Stop '; TipoV: u$ = INPUT$(1): END
    '   End Select
    '   Problem(IndObj).Commess = Lav(0).Arch
    '   Problem(IndObj).TSheDes = Look.Adim
    '   Problem(IndObj).TSheThk = Look.t
    '   Problem(IndObj).CavChan = Look.ProfCava
    '   Problem(IndObj).TipPias(1) = RTrim$(Record(0).Denom) + " Pos." + Str$(Record(0).PosDis)
    '   Problem(IndObj).MatPias(1) = Record(0).MATE
    '   If DatiDes(0).DiffPress Then Problem(IndObj).PDIFF = 0 Else Problem(IndObj).PDIFF = 1
    '   Problem(IndObj).Vacuum = DatiDes(0).Vacuum
    'Nguar = 0
    '    'Record(0) piastra 1 guarn Sh 2 guarn Ch  3 bull 4 fl Sh 5 fl Ch 6 tubi
    '    'ricerca tiranti
    'Call CercaTir(0, 3)
    ''ricerca flangioni
    'Call CercaFla(0, 3, 4, 5, Chan, 0, Flangia)
    '                        If DatiInt(IndObj).bdice = 1 Then
    '                           FlChan(IndObj) = Flangia
    '                        Else
    '                           If Chan Then FlChan(IndObj) = Flangia Else FlShel(IndObj) = Flangia
    '                           Call CercaFla(0, 3, 4, 5, Chan, 2, Flangia)
    '                           If Chan Then FlChan(IndObj) = Flangia Else FlShel(IndObj) = Flangia
    '                        End If
    ''ricerca calcolo flangioni
    'Call CercaCal(4, 5)
    ''ricerca mantello
    'If DatiInt(IndObj).bdice = 1 Then
    'For j = 1 To Lav(0).ind(Lav(0).NumAs)
    '    Get #IUNA, j, Record(JRECMAX)
    '    If EOF(IUNA) Or Record(JRECMAX).ind = 0 Then Exit For
    '    If Record(JRECMAX).Tipo = 1 And (Record(0).PosSpa.SuChi = Record(JRECMAX).ind Or Record(JRECMAX).PosSpa.SuChi = Record(0).ind) Then
    '       Record(4) = Record(JRECMAX)
    '       FlShel(IndObj).Identif = RTrim$(Record(4).Denom) + " Pos." + Str$(Record(4).PosDis)
    '       FlShel(IndObj).DextFla = 0
    '       FlShel(IndObj).DintFla = Record(4).Dati(2)
    '       FlShel(IndObj).CodoMax = Record(4).Dati(3)
    '       FlShel(IndObj).CodoMin = Record(4).Dati(3)
    '    End If
    'Next j
    'End If
    'Nguar = 0
    ''ricerca guarnizioni
    'Chan = True: Shel = False
    'Call CercaGuar(0, 4, 5, Shel, Chan, 1, 2, FlChan(IndObj))
    '    If DatiInt(IndObj).bdice = 1 Then
    '       If Not Chan Then messagebox.show "Errore impossibile 1 in ApriLeggiU": Stop ': u$ = INPUT$(1)
    '    Else
    '       If Not Chan Then messagebox.show "Errore impossibile 2 in ApriLeggiU": Stop ' u$ = INPUT$(1)
    '    End If
    '         If DatiInt(IndObj).bdice = 0 Then
    '            Chan = False: Shel = True
    '            Call CercaGuar(0, 4, 5, Shel, Chan, 1, 2, FlShel(IndObj))
    '            If Not Shel Then messagebox.show "Errore impossibile 3 in ApriLeggiU": Stop ' u$ = INPUT$(1)
    '         End If
    ''ricerca tubi
    'For j = 1 To Lav(0).ind(Lav(0).NumAs)
    '    Get #IUNA, j, Record(JRECMAX)
    '    If EOF(IUNA) Or Record(JRECMAX).ind = 0 Then Exit For
    '    If (Record(JRECMAX).Tipo = 8 Or Record(JRECMAX).Tipo = 9) And (Record(0).PosSpa.SuChi = Record(JRECMAX).ind Or Record(JRECMAX).PosSpa.SuChi = Record(0).ind) Then
    '       Record(6) = Record(JRECMAX)
    '       If Record(6).Tipo = 8 Then       'Tubi diritti
    '          Record(7).ind = 0
    '          GoSub CercaAltraPiastra
    '          If Record(7).ind = 0 Then
    '                a$ = " Non sono stati trovati i dati |"
    '           a$ = a$ + "relativi alla piastra opposta  |"
    '           a$ = a$ + "a quella selezionata.          |"
    '         messagebox.show Monitor.Motore.Inizio.ConvertiCr(a), vbInformation
    '                ApriLeggiU = False
    '                Exit Function
    '          End If
    '       End If
    '       Problem(IndObj).TubDiam = Record(6).Dati(1)      'Diametro tubi scambiatori            [mm]
    '       Problem(IndObj).TubPass = Record(6).Dati(11)     'Passo foratura                       [mm]
    '       JP = Record(6).Dati(4) \ 100
    '       If JP > 2 Then Problem(IndObj).TipPass = 1 Else Problem(IndObj).TipPass = 2 '1=passo quadrato; 2=passo triangolare
    '       Problem(IndObj).EquDiam = Record(6).Dati(6) - Problem(IndObj).TubDiam  'Dl (secondo Table RCB-7.133) approx           [mm]
    '    End If
    'Next j
    'Return
    ''-------------------------------------------
    'Carica:
    ''a$ = "A"
    ''80      ifl = FREEFILE: OPEN "i", #ifl, icome$
    ''nix = 0
    ''    Loop di lettura---------------------------------------------------
    ''leggi:
    ''200   If Mid$(a$, 1, 1) = "<" Then GoTo lAgg
    ''      Line Input #ifl, a$: in10 = InStr(a$, "Ý"): If in10 = 0 Then GoTo leggi
    ''      nix = nix + 1
    ''      dt(nix) = Mid$(a$, 1, 30)
    ''      GoTo leggi
    ''lAgg:
    ''        Do
    ''          Line Input #ifl, a$
    ''          If EOF(ifl) Or Not Left$(a$, 1) = "<" Then Exit Do
    ''        Loop
    ''        Problem(IndObj).TSheThk = GlobaLroutines.ValVir(a$)
    ''        'INPUT #ifl, Problem(IndObj).TSheThk
    ''201     Input #ifl, Problem(IndObj).TExtThk
    ''        Input #ifl, Problem(IndObj).TipCalc
    ''        Input #ifl, FlShel(IndObj).gefinc
    ''        Input #ifl, FlShel(IndObj).wm1
    ''        Input #ifl, FlShel(IndObj).wm2
    ''        Input #ifl, FlChan(IndObj).gefinc
    ''        Input #ifl, FlChan(IndObj).wm1
    ''        Input #ifl, FlChan(IndObj).wm2
    ''        Input #ifl, DatiInt(IndObj).bdice
    ''210     Close #ifl
    'Return
    'CercaAltraPiastra:
    'For k = 1 To Lav(0).ind(Lav(0).NumAs)
    '                Get #IUNA, k, Record(JRECMAX)
    '                If EOF(IUNA) Or Record(JRECMAX).ind = 0 Then Exit For
    '                If Record(JRECMAX).Tipo = 12 Then
    '                     Log1 = (Record(6).PosSpa.SuChi = Record(JRECMAX).ind Or Record(JRECMAX).PosSpa.SuChi = Record(6).ind)
    '                     Log2 = (Record(6).ForoSecondario = Record(JRECMAX).ind Or Record(JRECMAX).ForoSecondario = Record(6).ind)
    '                     Log3 = (Record(6).ForoTerziario = Record(JRECMAX).ind Or Record(JRECMAX).ForoTerziario = Record(6).ind)
    '                     If (Log1 Or Log2 Or Log3) And Record(JRECMAX).ind <> Record(0).ind Then
    '                        Record(7) = Record(JRECMAX)
    '                        Call LookTipoPiastra(Record(7).Dati(), Look)
    '                        If Look.TipoV = 3 Then 'siccome c'Š un codolo lato shell trattasi di piastre fisse
    '       '                   Catena "PTFF"
    '                        End If
    '                     End If
    '                End If
    'Next k
    'Return
    ''-------------------------------------
    '2430    'If Erl = 201 Then Resume 210
    '        messagebox.show "Errore in ApriLeggiU"
    '        Stop
    '        Resume '; ERR; ERL: u$ = INPUT$(1): END
    'End Function
    Sub ApriScriviU()
        ' Dim Look As Look, tt As Integer
        'Dim Tira As tiranti
        ' On Local Error GoTo 2550                 'intercetto gli errori
        If AddDistinta > 0 Then
            If Len(icome) > 0 Then
                Call SalvaU()
                'GoSub ReTransWND
            Else
                MessageBox.Show("Errore impossibile in ApriScrivi") ': Stop
            End If
        Else
            '   If Len(icome$) > 0 Then
            '      File$ = icome$
            '      Do
            '      l = InStr(File$, "\")
            '      If l > 0 Then File$ = Right$(File$, Len(File$) - l) Else Exit Do
            '      Loop
            '      File$ = Left$(File$, Len(File$) - 4)
            '      a$ = " Vuoi riscrivere sul lavoro " + UCase$(File$) + "| o vuoi salvare sotto a•tro nome?"
            '    junk = Alert(4, a$, 4, 3, 8, 58, "Riscrivi", "Nuovo", "")
            '      If junk = 2 Then GoTo 2545
            '      If junk = 0 Then Exit Sub
            '      Call SalvaU
            '   Else
            '2545  Stringa(1) = "Nome del file (senza est.)": Risult$(1) = Space$(6)
            'RiEs: Esito% = Cartigli(1, 1, "Salvataggio", "", Stringa(), Risult$())
            '      If Esito% = 2 Then Exit Sub
            '      If Len(Risult$(1)) > 8 Or Len(Risult$(1)) < 1 Then Beep:  GoTo 2545
            '      icome$ = RTrim$(Datidir) + "\" + UCase$(RTrim$(Risult$(1)))
            '      icome$ = icome$ + ".EXT"
            '      Call SalvaU
            '   End If
        End If
        Exit Sub
ReTransWND:
        ''   Call LookTipoPiastra(Record(0).Dati())
        '   tt = CInt(Problem(IndProbl).TSheThk)
        '   Select Case Look.TipoV
        '      Case 3 'codolo lato shell
        '         Record(0).Dati(7) = -Problem(IndProbl).TExtThk + Look.t - Look.H4
        '      Case 6 'sandwitch
        '         Look.H1 = CInt((tt - Problem(IndProbl).TExtThk) / 2)
        '         Record(0).Dati(3) = Look.H1
        '   End Select
        '   Look.Adim = Problem(IndProbl).TSheDes
        '   Record(0).Dati(1) = Look.t
        '   Record(0).Dati(2) = Look.Adim
        '2560   Put #IUNA, Record(0).Ind, Record(0)
        '   Record(3).Dati(4) = CInt(Problem(IndProbl).BoltCiD)
        '   Record(3).Dati(3) = Problem(IndProbl).XFil
        '   Record(3).Qta = Str$(Problem(IndProbl).NumBolt)
        '   Record(3).Dati(5) = 0 'Val(Tira.Diam)
        '2570   Put #IUNA, Record(3).Ind, Record(3)
        '   If Record(1).Ind > 0 Then
        '      If FlChan(IndProbl).ClassGsk > 0 Then Record(1).Dati(4) = FlChan(IndProbl).ClassGsk
        '      If FlChan(IndProbl).TipGsk > 0 Then Record(1).Dati(5) = FlChan(IndProbl).TipGsk
        '      If FlChan(IndProbl).IndFac > 0 Then Record(1).Dati(6) = FlChan(IndProbl).IndFac
        '      Record(1).Dati(7) = FlChan(IndProbl).DmedGua + FlChan(IndProbl).LargGua
        '      Record(1).Dati(8) = FlChan(IndProbl).DmedGua - FlChan(IndProbl).LargGua
        '2580  Put #IUNA, Record(1).Ind, Record(1)
        '   End If
        '   If Record(2).Ind > 0 Then
        '      If FlShel(IndProbl).ClassGsk > 0 Then Record(2).Dati(4) = FlShel(IndProbl).ClassGsk
        '      If FlShel(IndProbl).TipGsk > 0 Then Record(2).Dati(5) = FlShel(IndProbl).TipGsk
        '      If FlShel(IndProbl).IndFac > 0 Then Record(2).Dati(6) = FlShel(IndProbl).IndFac
        '      Record(2).Dati(7) = FlShel(IndProbl).DmedGua + FlShel(IndProbl).LargGua
        '      Record(2).Dati(8) = FlShel(IndProbl).DmedGua - FlShel(IndProbl).LargGua
        '2590  Put #IUNA, Record(2).Ind, Record(2)
        '   End If
        'Return
        '2550  messagebox.show "Errore in ApriScriviU " + Err.dexription
        '      Stop
        '      Resume '; ERL: u$ = INPUT$(1): END
    End Sub
    Sub Asse(ByRef x1 As Single, ByRef y1 As Single, ByRef x2 As Single, ByRef y2 As Single, ByRef ntick As Short, ByRef ltick As Single, ByRef Form As String)
        Dim ly, LX, vv As Single
        Dim i As Short
        Dim xx, yy As Single
        Dim St As String
        Routines.tratto(x1, y1, x2, y2, 0, 0)
        Dim g As Graphics = Routines.DoveDisegnog
        Dim f As Font = Grafico.Picture1.Font
        For i = 0 To ntick
            xx = x1 + i / ntick * (x2 - x1)
            yy = y1 + i / ntick * (y2 - y1)
            If (x1 = x2) Then
                LX = -ltick + xx : ly = yy
                vv = yy * inc
            ElseIf (y1 = y2) Then
                LX = xx : ly = -ltick + yy
                vv = xx
            End If
            St = GlobalRoutines.FormatS(Form, vv)
            Dim LarghTesto As Single = g.MeasureString(St, f).Width
            Dim AltezTesto As Single = g.MeasureString(St, f).Height
            Routines.tratto(xx, yy, LX, ly, 0, 0)
            Routines.ECRIR(St)
            If x1 = x2 Then
                LX = LX - System.Math.Abs(LarghTesto) * Routines.mioFx
                ly = ly + System.Math.Abs(AltezTesto) * Routines.mioFy / 2
            Else
                LX = LX - System.Math.Abs(LarghTesto) * Routines.mioFx / 2
            End If
            Routines.texte0(LX, ly, 0, 0, 0)
        Next i
    End Sub
    Private Sub grafic(ByRef m1 As Single, ByRef m2 As Single, ByRef x As Single, ByRef y As Single, ByRef sw As Short, ByRef Title As String, ByRef mxx As Single, ByRef TF As Single)
        Static tmin, tmax As Single
        Dim d As Single
        Dim mtrxi, mtrxc As Single
        Dim m10, trxc, passo, m20 As Single
        Dim mtf, mmxx As Single
        Dim swsw, i As Short
        Dim px0 As Single
        Dim rtx, trx As Single
        Dim g As Graphics = Routines.DoveDisegnog
        Dim f As Font = Grafico.Picture1.Font
        Dim LarghTesto As Single = g.MeasureString("M", f).Width
        Dim AltezTesto As Single = g.MeasureString("M", f).Height
        d = DatiInt(IndProbl).gef / inc
        If d <= 0 Then d = FlShel(IndProbl).gefinc
        If (sw = 0 Or sw = 2) Then GoTo primo
        If (sw = 1) Then
            Routines.cerc(mxx, trxi, (m2 - m1) / 100) ' (m, tf1), 3, 2
            Routines.cerc(mxx, TF, (m2 - m1) / 50)
        End If
        If (sw = 3) Then
            Routines.quadrato(mxx - (m2 - m1) / 30, (TF - TF / 20), mxx + (m2 - m1) / 30, (TF + TF / 20), 0.1, 0, 0) ' (m - 5, tf1 - 5)-(m + 5, tf1 + 5), 2, B
            trxi = tRa / inc
            Routines.quadrato(mxx - (m2 - m1) / 45, (trxi - trxi / 30), mxx + (m2 - m1) / 45, (trxi + trxi / 30), 0.1, 0, 0) ' (m - 5, tf1 - 5)-(m + 5, tf1 + 5), 2, B
        End If
        Exit Sub
primo:
        tmin = 0 : tmax = 2 * TF * inc
        mtrxi = trxi : mtrxc = trxc : mtf = TF : mmxx = mxx
        If sw = 2 Then tmin = (trxi - TF / 2) * inc : tmax = (trxi + TF / 2) * inc
        Call Asse(m1, x, m1, y, 8, (m2 - m1) / 50, "###.")
        Call Asse(m1, x, m2, x, 5, (y - x) / 50, "+#.##^^^^")
        If sw = 0 Then
            Routines.ECRIR(Title)
            Routines.texte0(m1 + 5 * System.Math.Abs(LarghTesto) * Routines.mioFx, y + 1.5 * System.Math.Abs(AltezTesto) * Routines.mioFy, 0, 0, 0)
        End If
        Routines.ECRIR("M*")
        Routines.texte0(m2 + 2 * System.Math.Abs(LarghTesto) * Routines.mioFx, x + System.Math.Abs(AltezTesto) * Routines.mioFy / 2, 0, 0, 0)
        Routines.ECRIR("Thk")
        Routines.texte0(m1 - 2 * System.Math.Abs(LarghTesto) * Routines.mioFx, y + 1.5 * System.Math.Abs(AltezTesto) * Routines.mioFy, 0, 0, 0)
        Routines.ctrait(0, 0.2)
        Routines.ECRIR("----  :  Spessore estensione soddisfacente la resistenza")
        Routines.texte0(m1 + 4 * System.Math.Abs(LarghTesto) * Routines.mioFx, x + 1.5 * System.Math.Abs(AltezTesto) * Routines.mioFy, 0, 0, 0)
        Routines.ctrait(0, 0.3)
        If (opttf > 1.001) Then
            Routines.ECRIR("----  :  Spessore piastra soddisfacente la resistenza")
        Else
            Routines.ECRIR("----  :  Spessore piastra per congruenza e resistenza")
        End If
        Routines.texte0(m1 + 4 * System.Math.Abs(LarghTesto) * Routines.mioFx, x + 3 * System.Math.Abs(AltezTesto) * Routines.mioFy, 0, 0, 0)
        Routines.ctrait(0, 0.4)
        Routines.ECRIR("----  :  Spessore estensione soddisfacente la congruenza")
        Routines.texte0(m1 + 4 * System.Math.Abs(LarghTesto) * Routines.mioFx, x + 4.5 * System.Math.Abs(AltezTesto) * Routines.mioFy, 0, 0, 0)
        passo = (m2 - m1) / 200 : m10 = m1 : m20 = m1 + (m2 - m1) / 4
        swsw = 0 : px0 = px
        Routines.ctrait(0, 0.2)
        For i = 1 To 2
            For mxx = m10 To m20 Step passo
                trxc = troutin(px0, mxx, 1)
                If trxc * inc > tmax Or trxc * inc < tmin Then GoTo Cont
                If (swsw = 0) Then
                    Routines.tratto(mxx, trxc, mxx, trxc, 0, 0)
                    swsw = 1
                Else
                    Routines.tratto(-1, -1, mxx, trxc, 0, 0)
                End If
Cont:       Next mxx
            m10 = m20 : m20 = m2 : passo = (m2 - m1) / 10
        Next i
        '------------------------------------------------------------
        Routines.ctrait(0, 0.3)
        swsw = 0
        For mxx = m1 To m2 Step passo
            pb = pbrou(mxx)
            px = px0 + pb
            TF = tflex(d, px)
            If TF * inc > tmax Or TF * inc < tmin Then GoTo cont1
            If (swsw = 0) Then
                Routines.tratto(mxx, TF, mxx, TF, 0, 0)
                swsw = 1
            Else
                Routines.tratto(-1, -1, mxx, TF, 0, 0)
            End If
cont1:  Next mxx
        '-------------------------------------------------------------
        Routines.ctrait(0, 0.4)
        swsw = 0
        For rtx = 0 To 2 Step 0.05
            mxx = mxroutin(rtx ^ 3, px0, -1000, 1)
            pb = pbrou(mxx)
            px = px0 + pb
            TF = tflex(d, px)
            trx = rtx * TF
            If (mxx < m1 Or mxx > m2) Then GoTo cont3
            If (swsw = 0) Then
                Routines.tratto(mxx, trx, mxx, trx, 0, 0)
                swsw = 1
            Else
                Routines.tratto(-1, -1, mxx, trx, 0, 0)
            End If
cont3:  Next rtx
        px = px0
        trxi = mtrxi : trxc = mtrxc : TF = mtf : mxx = mmxx
    End Sub
    Public Property TipoPiastra() As Short
        Get
            TipoPiastra = TipoPT
        End Get
        Set(ByVal Value As Short)
            'sola lettura
        End Set
    End Property
    Public Property FullBolt() As Short
        Get
            Select Case Problem(IndProbl).SERRA
                Case 0 : FullBolt = 1
                Case 1 : FullBolt = 0
                Case 2 : FullBolt = 2
            End Select
        End Get
        Set(ByVal Value As Short)
            Select Case Value
                Case 0 : Problem(IndProbl).SERRA = 1
                Case 1 : Problem(IndProbl).SERRA = 0
                Case 2 : Problem(IndProbl).SERRA = 2
            End Select
        End Set
    End Property
    Public Property XFil(ByVal i As Short) As Short
        Get
            XFil = Problem(IndProbl).Tiranti(i).XFil
        End Get
        Set(ByVal Value As Short)
            Dim t As DatiBull = Problem(IndProbl).Tiranti(i)
            t.XFil = Value
            Problem(IndProbl).Tiranti(i) = t
        End Set
    End Property
    Public Property TipCalc() As Short
        Get
            TipCalc = Problem(IndProbl).TipCalc - 1
        End Get
        Set(ByVal Value As Short)
            Problem(IndProbl).TipCalc = Value + 1 'progetto,verifica,P.I.+
        End Set
    End Property
    Public Property Verbose() As Boolean
        Get
            Verbose = Problem(IndProbl).NOGRAF = 1
        End Get
        Set(ByVal Value As Boolean)
            If Value Then Problem(IndProbl).NOGRAF = 1 Else Problem(IndProbl).NOGRAF = 0
        End Set
    End Property
    Public Property SicBullp(ByVal i As Short) As Single
        Get
            SicBullp(i) = Problem(IndProbl).Tiranti(i).fSicBul
        End Get
        Set(ByVal Value As Single)
            Dim t As DatiBull = Problem(IndProbl).Tiranti(i)
            t.fSicBul = Value
            Problem(IndProbl).Tiranti(i) = t
        End Set
    End Property
    Public Property DiffPIese(ByVal i As Short) As Boolean
        Get
            DiffPIese = Problem(IndProbl).Tiranti(i).SPHT = 1
        End Get
        Set(ByVal Value As Boolean)
            Dim t As DatiBull = Problem(IndProbl).Tiranti(i)
            If Value Then
                t.SPHT = 1
            Else
                t.SPHT = 0
            End If
            Problem(IndProbl).Tiranti(i) = t
        End Set
    End Property
    Public Property CRUSH(ByVal i As Short) As Boolean
        Get
            CRUSH = Problem(IndProbl).Tiranti(i).CRUSH = 0
        End Get
        Set(ByVal Value As Boolean)
            Dim t As DatiBull = Problem(IndProbl).Tiranti(i)
            If Value Then
                t.CRUSH = 0
            Else
                t.CRUSH = 1
            End If
            Problem(IndProbl).Tiranti(i) = t
        End Set
    End Property
    Public Property FLEX() As Boolean
        Get
            FLEX = Problem(IndProbl).FLEX = 1
        End Get
        Set(ByVal Value As Boolean)
            If Value Then Problem(IndProbl).FLEX = 1 Else Problem(IndProbl).FLEX = 0
        End Set
    End Property
    Public Property mart() As Boolean
        Get
            mart = Problem(IndProbl).mart = 1
        End Get
        Set(ByVal Value As Boolean)
            If Value Then Problem(IndProbl).mart = 1 Else Problem(IndProbl).mart = 2
        End Set
    End Property
    Public Property Rapporto(ByVal i As Short) As Single
        Get
            Rapporto = Problem(IndProbl).rappSin
        End Get
        Set(ByVal Value As Single)
            Problem(IndProbl).rappSin = Value
            If Problem(IndProbl).rappSin > 1 Then Problem(IndProbl).rappSin = 1
        End Set
    End Property
    Public Property bdice() As Short
        Get
            bdice = DatiInt(IndProbl).bdice
        End Get
        Set(ByVal Value As Short)
            DatiInt(IndProbl).bdice = Value
        End Set
    End Property
    Public Property NumColl(ByVal i As Short) As Short
        Get
            NumColl = Problem(IndProbl).Tiranti(i).NumColl
        End Get
        Set(ByVal Value As Short)
            Dim t As DatiBull = Problem(IndProbl).Tiranti(i)
            t.NumColl = Value
            Problem(IndProbl).Tiranti(i) = t
        End Set
    End Property
    Public Property NumBolt(ByVal i As Short) As Short
        Get
            NumBolt = Problem(IndProbl).Tiranti(i).NumBolt
        End Get
        Set(ByVal Value As Short)
            Dim t As DatiBull = Problem(IndProbl).Tiranti(i)
            t.NumBolt = Value
            Problem(IndProbl).Tiranti(i) = t
        End Set
    End Property
    Public Property TipoPias(ByVal i As Short) As String
        Get
            TipoPias = Problem(IndProbl).TipPias(1)
        End Get
        Set(ByVal Value As String)
            Problem(IndProbl).TipPias(1) = Value
        End Set
    End Property
    Public Property MatPias(ByVal i As Short) As String
        Get
            MatPias = Problem(IndProbl).MatPias(i)
        End Get
        Set(ByVal Value As String)
            Problem(IndProbl).MatPias(i) = Value
        End Set
    End Property
    Public Property MatBull(ByVal i As Short) As String
        Get
            MatBull = Problem(IndProbl).Tiranti(i).MatBull
        End Get
        Set(ByVal Value As String)
            Dim t As DatiBull = Problem(IndProbl).Tiranti(i)
            t.MatBull = Value
            Problem(IndProbl).Tiranti(i) = t
        End Set
    End Property
    Public Property DiNBull(ByVal i As Short) As String
        Get
            DiNBull = Problem(IndProbl).Tiranti(i).DiNBull
        End Get
        Set(ByVal Value As String)
            Dim t As DatiBull = Problem(IndProbl).Tiranti(i)
            t.DiNBull = Value
            Problem(IndProbl).Tiranti(i) = t
        End Set
    End Property
    Public Property BoltCiD(ByVal i As Short) As Single
        Get
            BoltCiD = Problem(IndProbl).Tiranti(i).BoltCiD
        End Get
        Set(ByVal Value As Single)
            Dim t As DatiBull = Problem(IndProbl).Tiranti(i)
            t.BoltCiD = Value
            Problem(IndProbl).Tiranti(i) = t
        End Set
    End Property
    Public Property AreBolt(ByVal i As Short) As Single
        Get
            AreBolt = Problem(IndProbl).Tiranti(i).AreBolt
        End Get
        Set(ByVal Value As Single)
            Dim t As DatiBull = Problem(IndProbl).Tiranti(i)
            t.AreBolt = Value
            Problem(IndProbl).Tiranti(i) = t
        End Set
    End Property
    Public Property BSpcMin(ByVal i As Short) As Single
        Get
            BSpcMin = Problem(IndProbl).Tiranti(i).BSpcMin
        End Get
        Set(ByVal Value As Single)
            Dim t As DatiBull = Problem(IndProbl).Tiranti(i)
            t.BSpcMin = Value
            Problem(IndProbl).Tiranti(i) = t
        End Set
    End Property
    Public Property BRadMin(ByVal i As Short) As Single
        Get
            BRadMin = Problem(IndProbl).Tiranti(i).BRadMin
        End Get
        Set(ByVal Value As Single)
            Dim t As DatiBull = Problem(IndProbl).Tiranti(i)
            t.BRadMin = Value
            Problem(IndProbl).Tiranti(i) = t
        End Set
    End Property
    Public Property FattBoltSy(ByVal i As Short) As Single
        Get
            FattBoltSy = Problem(IndProbl).FattBoltSy
        End Get
        Set(ByVal Value As Single)
            Problem(IndProbl).FattBoltSy = Value
        End Set
    End Property
    Public Property TSheDes() As Single
        Get
            TSheDes = Problem(IndProbl).TSheDes
        End Get
        Set(ByVal Value As Single)
            Problem(IndProbl).TSheDes = Value
        End Set
    End Property
    Public Property TSheThk() As Single
        Get
            TSheThk = Problem(IndProbl).TSheThk
        End Get
        Set(ByVal Value As Single)
            Problem(IndProbl).TSheThk = Value
        End Set
    End Property
    Public Property TExtThk() As Single
        Get
            TExtThk = Problem(IndProbl).TExtThk
        End Get
        Set(ByVal Value As Single)
            Problem(IndProbl).TExtThk = Value
        End Set
    End Property
    Public Property TubSpess() As Single
        Get
            TubSpess = Problem(IndProbl).TubSpess
        End Get
        Set(ByVal Value As Single)
            Problem(IndProbl).TubSpess = Value
        End Set
    End Property
    Public Property TubDiam() As Single
        Get
            TubDiam = Problem(IndProbl).TubDiam
        End Get
        Set(ByVal Value As Single)
            Problem(IndProbl).TubDiam = Value
        End Set
    End Property
    Public Property TubPass() As Single
        Get
            TubPass = Problem(IndProbl).TubPass
        End Get
        Set(ByVal Value As Single)
            Problem(IndProbl).TubPass = Value
        End Set
    End Property
    Public Property EquDiam() As Single
        Get
            EquDiam = Problem(IndProbl).EquDiam
        End Get
        Set(ByVal Value As Single)
            Problem(IndProbl).EquDiam = Value
        End Set
    End Property
    Public Property CavChan() As Single
        Get
            CavChan = Problem(IndProbl).CavChan
        End Get
        Set(ByVal Value As Single)
            Problem(IndProbl).CavChan = Value
        End Set
    End Property
    Public Property CavShel() As Single
        Get
            'CavShel = Piastra.CavShel
        End Get
        Set(ByVal Value As Single)
            'Piastra.CavShel = vNewValue
        End Set
    End Property
    Public Property GrvChan() As Single
        Get
            GrvChan = Problem(IndProbl).GrvChan
        End Get
        Set(ByVal Value As Single)
            Problem(IndProbl).GrvChan = Value
        End Set
    End Property
    Public Property GrvShel() As Single
        Get
            'CavShel = Piastra.CavShel
        End Get
        Set(ByVal Value As Single)
            'Piastra.CavShel = vNewValue
        End Set
    End Property
    Public Property CavChan1() As Single
        Get
            CavChan1 = Problem(IndProbl).CavChan
        End Get
        Set(ByVal Value As Single)
            Problem(IndProbl).CavChan = Value
        End Set
    End Property
    Public Property CavShel1() As Single
        Get
            'CavShel1 = Piastra.CavShel
        End Get
        Set(ByVal Value As Single)
            'Piastra.CavShel = vNewValue
        End Set
    End Property
    Public Property AllFRoo() As Single
        Get
            AllFRoo = Problem(IndProbl).AllFRoo
        End Get
        Set(ByVal Value As Single)
            Problem(IndProbl).AllFRoo = Value
        End Set
    End Property
    Public Property AllBRoo(ByVal i As Short) As Single
        Get
            AllBRoo = Problem(IndProbl).Tiranti(i).AllBRoo
        End Get
        Set(ByVal Value As Single)
            Dim t As DatiBull = Problem(IndProbl).Tiranti(i)
            t.AllBRoo = Value
            Problem(IndProbl).Tiranti(i) = t
        End Set
    End Property
    Public Property Rules() As Short
        Get
            Rules = Problem(IndProbl).Rules
        End Get
        Set(ByVal Value As Short)
            Problem(IndProbl).Rules = Value
        End Set
    End Property
    Public Property AllFOpe() As Single
        Get
            If VerificandoPI Then
                AllFOpe = Problem(IndProbl).AllFHyd
            Else
                AllFOpe = Problem(IndProbl).AllFOpe
            End If
        End Get
        Set(ByVal Value As Single)
            If VerificandoPI Then
                Problem(IndProbl).AllFHyd = Value
            Else
                Problem(IndProbl).AllFOpe = Value
            End If
        End Set
    End Property
    Public Property Calc7133() As Boolean
        Get
            '    Calc7133 = pt_Config.Calc7133
        End Get
        Set(ByVal Value As Boolean)
            '    pt_Config.Calc7133 = vNewValue
        End Set
    End Property
    Public Property AllBOpe(ByVal i As Short) As Single
        Get
            AllBOpe = Problem(IndProbl).Tiranti(i).AllBOpe
        End Get
        Set(ByVal Value As Single)
            Dim t As DatiBull = Problem(IndProbl).Tiranti(i)
            t.AllBOpe = Value
            Problem(IndProbl).Tiranti(i) = t
        End Set
    End Property
    Public Property UL() As Single
        Get
            UL = Problem(IndProbl).UL
        End Get
        Set(ByVal Value As Single)
            Problem(IndProbl).UL = Value
        End Set
    End Property
    Public Property OTL() As Single
        Get
            OTL = Problem(IndProbl).OTL
        End Get
        Set(ByVal Value As Single)
            Problem(IndProbl).OTL = Value
        End Set
    End Property
    Public Property TipPass() As Short
        Get
            TipPass = Problem(IndProbl).TipPass
        End Get
        Set(ByVal Value As Short)
            Problem(IndProbl).TipPass = Value
        End Set
    End Property
    Public Property PDesChan() As Single
        Get
            PDesChan = Problem(IndProbl).PEsChan / psi
        End Get
        Set(ByVal Value As Single)
            Problem(IndProbl).PEsChan = Value * psi
            FlChan(IndProbl).PresDes = Value * psi
        End Set
    End Property
    Public Property PDesShel() As Single
        Get
            PDesShel = Problem(IndProbl).PEsShel / psi
        End Get
        Set(ByVal Value As Single)
            Problem(IndProbl).PEsShel = Value * psi
            FlShel(IndProbl).PresDes = Value * psi
        End Set
    End Property
    Public Property PHTChan() As Single
        Get
            PHTChan = Problem(IndProbl).PHTChan / psi
        End Get
        Set(ByVal Value As Single)
            Problem(IndProbl).PHTChan = Value * psi
            FlChan(IndProbl).PresHyT = Value * psi
        End Set
    End Property
    Public Property PHTShel() As Single
        Get
            PHTShel = Problem(IndProbl).PHTShel / psi
        End Get
        Set(ByVal Value As Single)
            Problem(IndProbl).PHTShel = Value * psi
            FlShel(IndProbl).PresHyT = Value * psi
        End Set
    End Property
    Public Property CorChan() As Single
        Get
            CorChan = Problem(IndProbl).CorChan
        End Get
        Set(ByVal Value As Single)
            Problem(IndProbl).CorChan = Value
        End Set
    End Property
    Public Property CorShel() As Single
        Get
            CorShel = Problem(IndProbl).CorShel
        End Get
        Set(ByVal Value As Single)
            Problem(IndProbl).CorShel = Value
        End Set
    End Property
    Public Property DiffPress() As Single
        Get
            DiffPress = Problem(IndProbl).DiffPress / psi
        End Get
        Set(ByVal Value As Single)
            Problem(IndProbl).DiffPress = Value * psi
        End Set
    End Property
    Public Property DiffPressHT() As Single
        Get
            DiffPressHT = Problem(IndProbl).DiffPressHT / psi
        End Get
        Set(ByVal Value As Single)
            Problem(IndProbl).DiffPressHT = Value * psi
        End Set
    End Property
    Public WriteOnly Property UniMis() As Short
        Set(ByVal Value As Short)
        End Set
    End Property
    Public Property Destemp() As Single
        Get
            Destemp = (Problem(IndProbl).Destemp - 32) / 1.8
        End Get
        Set(ByVal Value As Single)
            Problem(IndProbl).Destemp = Value * 1.8 + 32
        End Set
    End Property
    Public Property ProgDiffPr() As Boolean
        Get
            ProgDiffPr = Problem(IndProbl).PDIFF = 0
        End Get
        Set(ByVal Value As Boolean)
            If Value Then Problem(IndProbl).PDIFF = 0 Else Problem(IndProbl).PDIFF = 1
        End Set
    End Property
    Public Property VacuumTS() As Boolean
        Get
            VacuumTS = Problem(IndProbl).Vacuum > 1
        End Get
        Set(ByVal Value As Boolean)
            If Value Then
                If VacuumSS Then Problem(IndProbl).Vacuum = 3 Else Problem(IndProbl).Vacuum = 2
            Else
                If VacuumSS Then Problem(IndProbl).Vacuum = 1 Else Problem(IndProbl).Vacuum = 0
            End If
        End Set
    End Property
    Public Property VacuumSS() As Boolean
        Get
            VacuumSS = Problem(IndProbl).Vacuum = 1 Or Problem(IndProbl).Vacuum = 3
        End Get
        Set(ByVal Value As Boolean)
            If Value Then
                If VacuumTS Then Problem(IndProbl).Vacuum = 3 Else Problem(IndProbl).Vacuum = 1
            Else
                If VacuumTS Then Problem(IndProbl).Vacuum = 2 Else Problem(IndProbl).Vacuum = 0
            End If
        End Set
    End Property
    Public Property FlChanNome() As String
        Get
            FlChanNome = FlChan(IndProbl).Identif
        End Get
        Set(ByVal Value As String)
            FlChan(IndProbl).Identif = Value
        End Set
    End Property
    Public Property FlShelNome() As String
        Get
            FlShelNome = FlShel(IndProbl).Identif
        End Get
        Set(ByVal Value As String)
            FlShel(IndProbl).Identif = Value
        End Set
    End Property
    Public Property SlChanNome() As String
        Get
            SlChanNome = FlChan(IndProbl).Identif
        End Get
        Set(ByVal Value As String)
            FlChan(IndProbl).Identif = Value
        End Set
    End Property
    Public Property SlShelNome() As String
        Get
            SlShelNome = FlShel(IndProbl).Identif
        End Get
        Set(ByVal Value As String)
            FlShel(IndProbl).Identif = Value
        End Set
    End Property
    Public Property FlChanDati(ByVal i As Short) As Object
        Get
            Select Case i
                Case 1
                    FlChanDati = FlChan(IndProbl).DextFla 'De Fl A
                Case 2
                    FlChanDati = FlChan(IndProbl).DintFla 'Di Fl A
                Case 3
                    FlChanDati = FlChan(IndProbl).CodoMax 'g1 Fl A
                Case 4
                    FlChanDati = FlChan(IndProbl).CodoMin 'g0 Fl A
                Case 5
                    FlChanDati = FlChan(IndProbl).DmedGua 'Dmed gua A
                Case 6
                    FlChanDati = FlChan(IndProbl).LargGua 'N     A
                Case 7
                    If FlChan(IndProbl).TipGuar Is Nothing Then
                        Return "not defined"
                    Else
                        Return FlChan(IndProbl).TipGuar.Trim 'Tip gua  A
                    End If
                Case 8
                    If FlChan(IndProbl).MatGuar Is Nothing Then
                        Return "not defined"
                    Else
                        Return FlChan(IndProbl).MatGuar.Trim 'Mat gua  A
                    End If
                Case 9
                    FlChanDati = FlChan(IndProbl).mguar 'm        A
                Case 10
                    FlChanDati = FlChan(IndProbl).y 'Y     A
                Case 11
                    FlChanDati = FlChan(IndProbl).mtrav 'm trav   A
                Case 12
                    FlChanDati = FlChan(IndProbl).ytrav 'Y trav   A
                Case 13
                    FlChanDati = FlChan(IndProbl).ltrav 'l trav   A
                Case 14
                    FlChanDati = FlChan(IndProbl).btrav 'b trav   A
                Case 15
                    FlChanDati = FlChan(IndProbl).wm1 'Wm1      A
                Case 16
                    FlChanDati = FlChan(IndProbl).wm2 'Wm2      A
                Case 17
                    FlChanDati = FlChan(IndProbl).wm1H 'Wm1 HT   A
                Case 18
                    FlChanDati = FlChan(IndProbl).wm2H 'Wm2 HT   A
                Case 19
                    FlChanDati = FlChan(IndProbl).gefinc * inc 'Gef  Fl A
                Case 20
                    FlChanDati = FlChan(IndProbl).PHI
                Case 21
                    FlChanDati = FlChan(IndProbl).wot 'Wm1 HT   A
                Case 22
                    FlChanDati = FlChan(IndProbl).wotH 'Wm2 HT   A
                Case Else
                    FlChanDati = 0
            End Select
        End Get
        Set(ByVal Value As Object)
            Select Case i
                Case 1
                    FlChan(IndProbl).DextFla = Value 'De Fl A
                Case 2
                    FlChan(IndProbl).DintFla = Value 'Di Fl A
                Case 3
                    FlChan(IndProbl).CodoMax = Value 'g1 Fl A
                Case 4
                    FlChan(IndProbl).CodoMin = Value 'g0 Fl A
                Case 5
                    FlChan(IndProbl).DmedGua = Value 'Dmed gua A
                Case 6
                    FlChan(IndProbl).LargGua = Value 'N     A
                Case 7
                    FlChan(IndProbl).TipGuar = Value 'Tip gua  A
                Case 8
                    FlChan(IndProbl).MatGuar = Value 'Mat gua  A
                Case 9
                    FlChan(IndProbl).mguar = Value 'm        A
                Case 10
                    FlChan(IndProbl).y = Value 'Y     A
                Case 11
                    FlChan(IndProbl).mtrav = Value 'm trav   A
                Case 12
                    FlChan(IndProbl).ytrav = Value 'Y trav   A
                Case 13
                    FlChan(IndProbl).ltrav = Value 'l trav   A
                Case 14
                    FlChan(IndProbl).btrav = Value 'b trav   A
                Case 15
                    FlChan(IndProbl).wm1 = Value 'Wm1      A
                Case 16
                    FlChan(IndProbl).wm2 = Value 'Wm2      A
                Case 17
                    FlChan(IndProbl).wm1H = Value 'Wm1 HT   A
                Case 18
                    FlChan(IndProbl).wm2H = Value 'Wm2 HT   A
                Case 19
                    FlChan(IndProbl).gefinc = Value / inc 'Gef  Fl A
                Case 20
                    FlChan(IndProbl).PHI = Value
                Case 21
                    FlChan(IndProbl).wot = Value
                Case 22
                    FlChan(IndProbl).wotH = Value
            End Select
        End Set
    End Property
    Public Property SlChanDati(ByVal i As Short) As Single
        Get
            Select Case i
                Case 1
                    SlChanDati = FlChan(IndProbl).DintFla
                Case 2
                    SlChanDati = FlChan(IndProbl).CodoMin
            End Select
        End Get
        Set(ByVal Value As Single)
            Select Case i
                Case 1
                    FlChan(IndProbl).DintFla = Value
                Case 2
                    FlChan(IndProbl).CodoMin = Value
            End Select
        End Set
    End Property
    Public Property FlShelDati(ByVal i As Short) As Object
        Get
            Select Case i
                Case 1
                    FlShelDati = FlShel(IndProbl).DextFla 'De Fl A
                Case 2
                    FlShelDati = FlShel(IndProbl).DintFla 'Di Fl A
                Case 3
                    FlShelDati = FlShel(IndProbl).CodoMax 'g1 Fl A
                Case 4
                    FlShelDati = FlShel(IndProbl).CodoMin 'g0 Fl A
                Case 5
                    FlShelDati = FlShel(IndProbl).DmedGua 'Dmed gua A
                Case 6
                    FlShelDati = FlShel(IndProbl).LargGua 'N     A
                Case 7 : FlShelDati = Trim(FlShel(IndProbl).TipGuar) 'Tip gua  A
                Case 8 : FlShelDati = Trim(FlShel(IndProbl).MatGuar) 'Mat gua  A
                Case 9
                    FlShelDati = FlShel(IndProbl).mguar 'm        A
                Case 10
                    FlShelDati = FlShel(IndProbl).y 'Y     A
                Case 11
                    FlShelDati = FlShel(IndProbl).mtrav 'm trav   A
                Case 12
                    FlShelDati = FlShel(IndProbl).ytrav 'Y trav   A
                Case 13
                    FlShelDati = FlShel(IndProbl).ltrav 'l trav   A
                Case 14
                    FlShelDati = FlShel(IndProbl).btrav 'b trav   A
                Case 15
                    FlShelDati = FlShel(IndProbl).wm1 'Wm1      A
                Case 16
                    FlShelDati = FlShel(IndProbl).wm2 'Wm2      A
                Case 17
                    FlShelDati = FlShel(IndProbl).wm1H 'Wm1 HT   A
                Case 18
                    FlShelDati = FlShel(IndProbl).wm2H 'Wm2 HT   A
                Case 19
                    FlShelDati = FlShel(IndProbl).gefinc * inc 'Gef  Fl A
                Case 20
                    FlShelDati = FlShel(IndProbl).PHI
                Case 21
                    FlShelDati = FlShel(IndProbl).wot 'Wm1 HT   A
                Case 22
                    FlShelDati = FlShel(IndProbl).wotH 'Wm2 HT   A
                Case Else
                    FlShelDati = 0
            End Select
        End Get
        Set(ByVal Value As Object)
            Select Case i
                Case 1
                    FlShel(IndProbl).DextFla = Value 'De Fl A
                Case 2
                    FlShel(IndProbl).DintFla = Value 'Di Fl A
                Case 3
                    FlShel(IndProbl).CodoMax = Value 'g1 Fl A
                Case 4
                    FlShel(IndProbl).CodoMin = Value 'g0 Fl A
                Case 5
                    FlShel(IndProbl).DmedGua = Value 'Dmed gua A
                Case 6
                    FlShel(IndProbl).LargGua = Value 'N     A
                Case 7
                    FlShel(IndProbl).TipGuar = Value 'Tip gua  A
                Case 8
                    FlShel(IndProbl).MatGuar = Value 'Mat gua  A
                Case 9
                    FlShel(IndProbl).mguar = Value 'm        A
                Case 10
                    FlShel(IndProbl).y = Value 'Y     A
                Case 11
                    FlShel(IndProbl).mtrav = Value 'm trav   A
                Case 12
                    FlShel(IndProbl).ytrav = Value 'Y trav   A
                Case 13
                    FlShel(IndProbl).ltrav = Value 'l trav   A
                Case 14
                    FlShel(IndProbl).btrav = Value 'b trav   A
                Case 15
                    FlShel(IndProbl).wm1 = Value 'Wm1      A
                Case 16
                    FlShel(IndProbl).wm2 = Value 'Wm2      A
                Case 17
                    FlShel(IndProbl).wm1H = Value 'Wm1 HT   A
                Case 18
                    FlShel(IndProbl).wm2H = Value 'Wm2 HT   A
                Case 19
                    FlShel(IndProbl).gefinc = Value / inc 'Gef  Fl A
                Case 20
                    FlShel(IndProbl).PHI = Value
                Case 21
                    FlShel(IndProbl).wot = Value 'Wm1 HT   A
                Case 22
                    FlShel(IndProbl).wotH = Value 'Wm2 HT   A
            End Select
        End Set
    End Property
    Public Property SlShelDati(ByVal i As Short) As Single
        Get
            Select Case i
                Case 1
                    SlShelDati = FlShel(IndProbl).DintFla
                Case 2
                    SlShelDati = FlShel(IndProbl).CodoMin
            End Select
        End Get
        Set(ByVal Value As Single)
            Select Case i
                Case 1
                    FlShel(IndProbl).DintFla = Value
                Case 2
                    FlShel(IndProbl).CodoMin = Value
            End Select
        End Set
    End Property
    Public Property PHI(ByVal i As Short) As Single
        Get
            Select Case i
                Case 1 : PHI = FlChan(IndProbl).PHI
                Case 2 : PHI = FlShel(IndProbl).PHI
            End Select
        End Get
        Set(ByVal Value As Single)
            Select Case i
                Case 1 : FlChan(IndProbl).PHI = Value
                Case 2 : FlShel(IndProbl).PHI = Value
            End Select
        End Set
    End Property
    Public Property wn(ByVal i As Short) As Single
        Get
            Select Case i
                Case 1 : wn = FlChan(IndProbl).wn
                Case 2 : wn = FlShel(IndProbl).wn
            End Select
        End Get
        Set(ByVal Value As Single)
            Select Case i
                Case 1 : FlChan(IndProbl).wn = Value
                Case 2 : FlShel(IndProbl).wn = Value
            End Select
        End Set
    End Property
    Public Property IndFac(ByVal i As Short) As Short
        Get
            If FlChan(IndProbl).PHI < 1 Or FlChan(IndProbl).PHI > 8 Then FlChan(IndProbl).PHI = 1
            If FlShel(IndProbl).PHI < 1 Or FlShel(IndProbl).PHI > 8 Then FlShel(IndProbl).PHI = 1
            Select Case i
                Case 1 : IndFac = FlChan(IndProbl).PHI 'IndFac
                Case 2 : IndFac = FlShel(IndProbl).PHI 'IndFac
            End Select
        End Get
        Set(ByVal Value As Short)
            Select Case i
                Case 1 : FlChan(IndProbl).PHI = Value
                Case 2 : FlShel(IndProbl).PHI = Value
            End Select
        End Set
    End Property
    Public Property TipGsk(ByVal i As Short) As Short
        Get
            Select Case i
                Case 1 : TipGsk = FlChan(IndProbl).TipGsk
                Case 2 : TipGsk = FlShel(IndProbl).TipGsk
            End Select
        End Get
        Set(ByVal Value As Short)
            Select Case i
                Case 1 : FlChan(IndProbl).TipGsk = Value
                Case 2 : FlShel(IndProbl).TipGsk = Value
            End Select
        End Set
    End Property
    Public Property ClassGsk(ByVal i As Short) As Short
        Get
            Select Case i
                Case 1 : ClassGsk = FlChan(IndProbl).ClassGsk
                Case 2 : ClassGsk = FlShel(IndProbl).ClassGsk
            End Select
        End Get
        Set(ByVal Value As Short)
            Select Case i
                Case 1 : FlChan(IndProbl).ClassGsk = Value
                Case 2 : FlShel(IndProbl).ClassGsk = Value
            End Select
        End Set
    End Property
    Public ReadOnly Property Rear() As Short
        Get
            Rear = 3
        End Get
    End Property
    Public ReadOnly Property GetPiastra() As Short
        Get
            GetPiastra = 1
        End Get
    End Property
    Public Property BiFlangiata() As Boolean
        Get
            BiFlangiata = DatiInt(IndProbl).bdice = 0
        End Get
        Set(ByVal Value As Boolean)

        End Set
    End Property
    Public ReadOnly Property Mom1() As Single
        Get
            Mom1 = FlShel(IndProbl).m1
        End Get
    End Property
    Public ReadOnly Property Mom2() As Single
        Get
            Mom2 = FlShel(IndProbl).m2
        End Get
    End Property
    Public Property Flottante() As Short
        Get
            Flottante = Problem(IndProbl).Flottante
        End Get
        Set(ByVal Value As Short)
            Problem(IndProbl).Flottante = Value
        End Set
    End Property
    Public Property TipoFF() As Short
        Get
            TipoFF = Problem(IndProbl).TipoFF
        End Get
        Set(ByVal Value As Short)
            Problem(IndProbl).TipoFF = Value
        End Set
    End Property
    Public Property hr() As Single
        Get
            hr = Problem(IndProbl).hr
        End Get
        Set(ByVal Value As Single)
            Problem(IndProbl).hr = Value
        End Set
    End Property
    Public Property IndiceFlanF() As Short
        Get
            IndiceFlanF = Problem(IndProbl).IndiceFlanF
        End Get
        Set(ByVal Value As Short)
            Problem(IndProbl).IndiceFlanF = Value
        End Set
    End Property
    Public Property IndiceSplitR() As Short
        Get
            IndiceSplitR = Problem(IndProbl).IndiceSplitR
        End Get
        Set(ByVal Value As Short)
            Problem(IndProbl).IndiceSplitR = Value
        End Set
    End Property
    Public Property IndiceChanF() As Short
        Get
            IndiceChanF = Problem(IndProbl).IndiceChanF
        End Get
        Set(ByVal Value As Short)
            Problem(IndProbl).IndiceChanF = Value
        End Set
    End Property
    Public Property IndiceFondo() As Short
        Get
            IndiceFondo = Problem(IndProbl).IndiceFondo
        End Get
        Set(ByVal Value As Short)
            Problem(IndProbl).IndiceFondo = Value
        End Set
    End Property
    Public Property BullDistinti() As Boolean
        Get
            BullDistinti = Problem(IndProbl).BullDistinti <> 0
        End Get
        Set(ByVal Value As Boolean)
            If Value And Problem(IndProbl).BullDistinti < 1 Then
                Problem(IndProbl).BullDistinti = 1
            ElseIf Not Value Then
                Problem(IndProbl).BullDistinti = 0
            End If
        End Set
    End Property
    Public Property IBW() As Boolean
        Get
            IBW = Problem(IndProbl).IBW
        End Get
        Set(ByVal Value As Boolean)
            Problem(IndProbl).IBW = Value
        End Set
    End Property
    Public Property RadialExp() As Boolean
        Get
            RadialExp = Problem(IndProbl).RadialExp
        End Get
        Set(ByVal Value As Boolean)
            Problem(IndProbl).RadialExp = Value
        End Set
    End Property
    Public Property diamIBW() As Single
        Get
            diamIBW = Problem(IndProbl).diamIBW
        End Get
        Set(ByVal Value As Single)
            Problem(IndProbl).diamIBW = Value
        End Set
    End Property
    Public Property BullIndip() As Boolean
        Get
            BullIndip = Problem(IndProbl).BullDistinti = 1
        End Get
        Set(ByVal Value As Boolean)
            If Value Then Problem(IndProbl).BullDistinti = 1 Else Problem(IndProbl).BullDistinti = 0
        End Set
    End Property
    Public ReadOnly Property Documented() As Short
        Get
            Documented = 0
        End Get
    End Property
    Public Property SpessMant() As Single
        Get
            ' Stop
        End Get
        Set(ByVal Value As Single)
            ' Stop
        End Set
    End Property
    Private Sub AmmissFlan()
        Dim Sfa, Sfo As Single
        Dim jRec, locInd As Short
        locInd = 1
        jRec = Involucr(kLato, jInvolucr).indice(locInd - 1)
        If CerMat(jRec, locInd) = -1 Then Exit Sub
        Matdim(jRec).SigmaAmm(CodiceStress, Problem(IndProbl).Destemp, Sfa, Sfo)
        Problem(IndProbl).AllFRoo = Sfa
        Problem(IndProbl).AllFOpe = Sfo
    End Sub
    Public Overloads Function Leggi(ByVal ifl As Short) As Boolean
        Leggi = True
        FileGet(ifl, Problem(IndProbl))
        FileGet(ifl, FlShel(IndProbl))
        FileGet(ifl, FlChan(IndProbl))
        FileGet(ifl, DatiInt(IndProbl))
    End Function
    Public Overloads Function Leggi(ByVal fs As FileStream) As Boolean
        Dim bf As New BinaryFormatter
        Leggi = True
        Problem(IndProbl) = CType(bf.Deserialize(fs), DatiGeneral)
        FlShel(IndProbl) = CType(bf.Deserialize(fs), datiFlangia)
        FlChan(IndProbl) = CType(bf.Deserialize(fs), datiFlangia)
        DatiInt(IndProbl) = CType(bf.Deserialize(fs), DatiCalc)
    End Function
    Public Sub Salva(ByVal fs As FileStream)
        Dim bf As New BinaryFormatter
        bf.Serialize(fs, Problem(IndProbl))
        bf.Serialize(fs, FlShel(IndProbl))
        bf.Serialize(fs, FlChan(IndProbl))
        bf.Serialize(fs, DatiInt(IndProbl))
    End Sub
    Private Sub NewPage()
        Dim nr1, j As Short
        nr1 = nr + 1
        For j = nr1 To NRIGHE : Call count() : Monitor.Motore.Problem.Printa("\par ") : Next ' StriSt$(1): Next
    End Sub
    Private Sub CorrCodoli()
        Dim j As Short
        cc = 0 : cs = 0 '030506
        j = Involucr(kLato, jInvolucr).IndAccopp(1)
        If j = 0 Then j = Involucr(kLato, jInvolucr).IndAccopp(3) '030506
        If j > 0 Then
            cc = Involucr(2, j).cs
            If Involucr(2, j).OS > cc Then cc = Involucr(2, j).OS
            If VerificandoPI Then cs = Involucr(2, j).OS
        End If
        j = Involucr(kLato, jInvolucr).IndAccopp(2)
        If j = 0 Then j = Involucr(kLato, jInvolucr).IndAccopp(4) '030506
        If j > 0 Then
            cs = Involucr(1, j).cs
            If Involucr(1, j).OS > cs Then cs = Involucr(1, j).OS
            If VerificandoPI Then cs = Involucr(1, j).OS
        End If
    End Sub
    Private Sub Manual(ByRef ICAL As Short)
        Dim n As Short
        Braccios = (Problem(IndProbl).Tiranti(2).BoltCiD / inc - FlShel(IndProbl).gefinc) / 2
        Braccioc = (Problem(IndProbl).Tiranti(1).BoltCiD / inc - FlChan(IndProbl).gefinc) / 2
        If VerificandoPI Then
            FlShel(IndProbl).m1 = -FlShel(IndProbl).wm1H * Braccios
            FlChan(IndProbl).m1 = FlChan(IndProbl).wm1H * Braccioc
            FlChan(IndProbl).m2 = FlChan(IndProbl).wm2H * Braccioc
            FlShel(IndProbl).m2 = -FlShel(IndProbl).wm2H * Braccios
        Else
            FlShel(IndProbl).m1 = -FlShel(IndProbl).wm1 * Braccios
            FlChan(IndProbl).m1 = FlChan(IndProbl).wm1 * Braccioc
            FlChan(IndProbl).m2 = FlChan(IndProbl).wm2 * Braccioc '160206 Math.Max(FlChan(IndProbl).wm2, FlChan(IndProbl).wm2H) * Braccioc
            FlShel(IndProbl).m2 = FlShel(IndProbl).wm2 * Braccios '160206 -Math.Max(FlShel(IndProbl).wm2, FlShel(IndProbl).wm2H) * Braccios
        End If
        Select Case DatiInt(IndProbl).bdice
            Case 0 'flangiatura doppia
                Select Case ICAL
                    Case 3, 5 'operating lato shell
                        DatiInt(IndProbl).gef = FlShel(IndProbl).gefinc * inc
                        Lato = "shell"
                        If BullDistinti Then
                            If BullIndip Then
                                m1 = FlShel(IndProbl).m1
                                m2Sin = FlShel(IndProbl).m2
                            Else
                                m1 = FlShel(IndProbl).m1 + FlChan(IndProbl).m2
                                m2Sin = FlShel(IndProbl).m2 + FlChan(IndProbl).m2
                            End If
                        Else
                            n = System.Math.Abs(Problem(IndProbl).Tiranti(1).NumColl)
                            If Not VerificandoPI Then n = 0
                            If Problem(IndProbl).Tiranti(1).NumColl > 0 Then 'collari serrano guarn lato channel
                                m1 = FlChan(IndProbl).m1 * n / Problem(IndProbl).Tiranti(1).NumBolt
                                m2Sin = FlChan(IndProbl).m2 * n / Problem(IndProbl).Tiranti(1).NumBolt
                            Else
                                m1 = FlShel(IndProbl).m1 * n / Problem(IndProbl).Tiranti(1).NumBolt
                                m2Sin = FlShel(IndProbl).m2 * n / Problem(IndProbl).Tiranti(1).NumBolt
                            End If
                        End If
                    Case 2, 4 'operating lato tubi
                        DatiInt(IndProbl).gef = FlChan(IndProbl).gefinc * inc
                        Lato = "tube"
                        If BullDistinti Then
                            If BullIndip Then
                                m1 = FlChan(IndProbl).m1
                                m2Sin = FlChan(IndProbl).m2
                            Else
                                m1 = FlShel(IndProbl).m2 + FlChan(IndProbl).m1
                                m2Sin = FlShel(IndProbl).m2 + FlChan(IndProbl).m2
                            End If
                        Else
                            n = System.Math.Abs(Problem(IndProbl).Tiranti(1).NumColl)
                            If Not VerificandoPI Then n = 0
                            If Problem(IndProbl).Tiranti(1).NumColl > 0 Then 'collari serrano guarn lato channel
                                m1 = FlChan(IndProbl).m1 * n / Problem(IndProbl).Tiranti(1).NumBolt
                                m2Sin = FlChan(IndProbl).m2 * n / Problem(IndProbl).Tiranti(1).NumBolt
                            Else
                                m1 = FlShel(IndProbl).m1 * n / Problem(IndProbl).Tiranti(1).NumBolt
                                m2Sin = FlShel(IndProbl).m2 * n / Problem(IndProbl).Tiranti(1).NumBolt
                            End If
                        End If
                        '                Case 4 'pdiff
                        '                   DatiInt(IndProbl).gef = Math.Max(FlChan(IndProbl).gefinc, FlShel(IndProbl).gefinc) * inc
                        ''                  w = .5 * (Problem(Indprobl).TSheDes / INC - DatiInt(Indprobl).gef / INC)
                        '                   messagebox.show "da completare": Stop
                    Case 6 'seating
                        DatiInt(IndProbl).gef = Math.Max(FlChan(IndProbl).gefinc, FlShel(IndProbl).gefinc) * inc
                        '                  w = .5 * (Problem(Indprobl).TSheDes / INC - DatiInt(Indprobl).gef / INC)
                        m1 = 0
                        m2Sin = FlChan(IndProbl).m2
                        DatiInt(IndProbl).gef = FlChan(IndProbl).gefinc * inc
                        If System.Math.Abs(FlShel(IndProbl).m2) > m2Sin Then
                            m2Sin = System.Math.Abs(FlShel(IndProbl).m2)
                            DatiInt(IndProbl).gef = FlShel(IndProbl).gefinc * inc
                        End If
                End Select
            Case 1 'flangiatura lato channel
                m1 = FlChan(IndProbl).m1
                m2Sin = FlChan(IndProbl).m2
                Select Case ICAL
                    Case 2, 4 'operating lato tubi
                        DatiInt(IndProbl).gef = FlChan(IndProbl).gefinc * inc
                        Lato = "tube"
                    Case 3, 5 : m1 = 0 'operating lato shell
                        DatiInt(IndProbl).gef = FlShel(IndProbl).DintFla
                        Lato = "shell"
                        ' Case 4 'pdiff
                        '       DatiInt(IndProbl).gef = Math.Max(FlChan(IndProbl).gefinc * inc, FlShel(IndProbl).DintFla)
                    Case 6 : m1 = 0 'seating
                        DatiInt(IndProbl).gef = Math.Max(FlChan(IndProbl).gefinc * inc, FlShel(IndProbl).DintFla)
                End Select
            Case 2 'flangiatura lato mantello
                m1 = FlShel(IndProbl).m1
                m2Sin = FlShel(IndProbl).m2
                Select Case ICAL
                    Case 2, 4 : m1 = 0 'operating lato tubi
                        DatiInt(IndProbl).gef = FlChan(IndProbl).DintFla
                        Lato = "tube"
                    Case 3, 5 'operating lato shell
                        DatiInt(IndProbl).gef = FlShel(IndProbl).gefinc * inc
                        Lato = "shell"
                        ' Case 4: 'pdiff
                        '       DatiInt(IndProbl).gef = Math.Max(FlShel(IndProbl).gefinc * inc, FlChan(IndProbl).DintFla)
                    Case 6 : m1 = 0 'seating
                        DatiInt(IndProbl).gef = Math.Max(FlShel(IndProbl).gefinc * inc, FlChan(IndProbl).DintFla)
                End Select
        End Select
        d = DatiInt(IndProbl).gef / inc
        If d <= 0 Then
            'd = FlShel(IndProbl).gefinc
        End If
        W = 0.5 * (Problem(IndProbl).TSheDes - d * inc) / inc
        g2w = d ^ 2 * W
        g3w = g2w * d
    End Sub
    Public Function CalcoloRilass() As Boolean
        Dim Res As Boolean
        Dim ic As Short
        Dim Testo As String
        Dim rappvecchio As Single
        Dim a As String
        Dim Verb As Boolean
        Dim Stringa(3) As String
        Dim junk As Short
        On Error GoTo ErrEx
        Star = New wn_AA
        Star.Padre = Base
        VerificandoPI = True
        sCorrodi()
        Res = Rifair(0)
        If Not Res Then Exit Function
        CalcolaRilass = True
        rapp = 1
        If Res Then
            If Verbose Then
                a = " Si va a calcolare la rotazione |"
                a = a & "della PT e il rilassamento dei bulloni |"
                a = a & "dovuto alla pressurizzazione|"
                MessageBox.Show(clsInizio.ConvertiCr(a))
            End If
            Verb = Verbose
            Verbose = False
            Do
                CalcIMAX()
                Res = CalcoloCompleto()
                If Not Res Then
                    VerificandoPI = False
                    CalcoloRilass = False
                    Exit Function
                End If
                rapp = objROTFL.rapp
                If System.Math.Abs(rapp - rappvecchio) < 0.001 Then Exit Do
                If ic > 100 Then
                    MessageBox.Show("Non è stata raggiunta la convergenza nel calcolo del rapporto di scarico bulloni.")
                    Exit Do
                End If
                rappvecchio = rapp
                ic = ic + 1
                Res = Rifair(0)
            Loop
            Verbose = Verb
            tfa = Problem(IndProbl).TSheThk
            tRa = Problem(IndProbl).TExtThk
            If tRa < temax Or tfa < tfmax And Not Config(0).VerifPI = 1 Then
                Testo = "Spessori insufficienti per la prova idraulica.|"
                Testo = Testo & "       Cosa vuoi fare ? "
                Stringa(1) = "Modificare i dati di input"
                Stringa(2) = "Confermare i dati attuali"
                junk = Monitor.Motore.Quale(2, "Spessori piastra", Stringa, "", 1, Testo)
                Select Case junk
                    Case 1 : CalcoloRilass = False
                        Exit Function
                    Case 2
                End Select
            End If
            If Verbose Then
                Testo = "Rotazioni dell'estensione PT in prova idraulica|"
                Testo = Testo & "Rotazione in radianti = " & GlobalRoutines.myStr(objROTFL.Thet0, 5, 4, False)
                Testo = Testo & "|Rotazione in gradi    = " & GlobalRoutines.myStr(objROTFL.Thet1, 5, 4, False)
                MessageBox.Show(clsInizio.ConvertiCr(Testo))
            End If '0
            Stampe()
            Star.printAA13(1)
            Stamparo("")
            VerificandoPI = False
            Corrodi()
            CalcolaRilass = False
            If Verbose Then
                a = " Si va a verificare la tenuta  della|"
                a = a & "Piastra Tubiera in condizioni di progetto.|"
                MessageBox.Show(clsInizio.ConvertiCr(a))
            End If
            Res = Rifair(0)
            CalcoloRilass = Res
            CalcIMAX()
            Stampe()
            CalcRota()
            Stamparo("")
        End If
        Res = ScelSpes()
        If Res Then CheckAccoppiata()
        'UPGRADE_NOTE: È possibile che l'oggetto Star non venga eliminato finché non venga raccolto nel Garbage Collector. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1029"'
        Star = Nothing
        StampaAnticipata = True
FineX:  Exit Function
ErrEx:
        CalcoloRilass = False
        a = "Consiglio di ricontrollare tutti i dati" & vbCrLf
        a = a & "(" & Err.Description & ")"
        MessageBox.Show(a)
        Resume FineX
    End Function
    Public Function CalcoloCompleto() As Boolean
        Dim Wm2PI As Single
        'VerificandoPI = True
        Ind = Involucr(kLato, jInvolucr).indice(1 - 1)
        'Res = Rifair(0)
        px = ppx1(IMAX)
        objROTFL.wm2 = DatiInt(IndProbl).wm2H / GRAV * NIUT
        objROTFL.W = DatiInt(IndProbl).wm1H / GRAV * NIUT
        '     rappvecchio = pi / 4 * DatiInt(IndProbl).gef ^ 2 * px / GRAV / psi
        objROTFL.Press = System.Math.Abs(px) / GRAV / psi 'Press
        objROTFL.temp = temp
        If Not ROTFL(objROTFL) Then Exit Function
        CalcoloCompleto = True
        '     rappvecchio = 0: ic = 0
        '     Do
        '    Res = Rifair(0)
        ROTFLFOR(objROTFL)
        rapp = objROTFL.rapp
        objROTFL.W = DatiInt(IndProbl).wm1H / GRAV * NIUT
        '      If Abs(rapp - rappvecchio) < 0.001 Then Exit Do
        '      If ic > 100 Then
        '          messagebox.show "Non è stata raggiunta la convergenza nel calcolo del rapporto di scarico bulloni.", vbInformation
        '          Exit Do
        '      End If
        '      rappvecchio = rapp
        '      ic = ic + 1
        '    Loop
        If rapp < 1 Then rapp = 1
        Wm2PI = DatiInt(IndProbl).wm1H * rapp * wnflan.SicBullp
        If Wm2PI > DatiInt(IndProbl).wm2H Then DatiInt(IndProbl).wm2H = Wm2PI
        ' VerificandoPI = false
        '  Res = Rifair(0)
    End Function
    Private Function ROTFL(ByRef objROTFL As typROTFL) As Boolean
        Dim Area As Single
        Dim Testo As String
        Dim j, IndObj As Short
        Dim Estar, nistar As Single
        ROTFL = True
        '  Ind = Involucr(kLato, jInvolucr).indice(1)
        Select Case DatiInt(IndProbl).bdice
            Case 0
                If FlShel(IndProbl).wm1 > FlChan(IndProbl).wm1 Then
                    jLato = 2
                    kk = 1
                Else
                    jLato = 1
                    kk = 2
                End If
                j = Involucr(kLato, jInvolucr).IndAccopp(jLato)
            Case 1 'flangiata lato tubi
                kk = 2
                j = Involucr(kLato, jInvolucr).IndAccopp(1)
            Case 2 'flangiata lato M
                kk = 1
                j = Involucr(kLato, jInvolucr).IndAccopp(2)
        End Select
        indBul = Involucr(kk, j).indice(2 - 1)
        IndObj = Involucr(kk, j).IndObject
        wnflan = objMemb(IndObj)
        jj = j
        With objROTFL
            .Arch = Config(0).DNjob
            .Membr = Involucr(kLato, jInvolucr).Mark
            .Mater = Matdim(Ind).MatStr
            .temp = temp
            .DiamInt = 0.0#
            .DiamExt = Problem(IndProbl).TSheDes
            If .DiamExt <= .DiamInt Then GoTo No
            .Spess = Problem(IndProbl).TSheThk - cc - cs
            .SpExt = Problem(IndProbl).TExtThk
            If .Spess <= 0 Then GoTo No
            .g1 = 0.0#
            .hub = 0.0#
            .g0 = 0.0#
            .E0 = Matdim(indBul).EmodAlt(temp) '/ psi / GRAV 'Young bulloni
            .E1 = Matdim(Ind).EmodAlt(temp) ' / psi / GRAV 'Young flangia
            '  .W = DatiInt(IndProbl).wm1H / GRAV              'Wm1
            '  .wm2 = DatiInt(IndProbl).wm2H / GRAV
            If .W <= 0 Then GoTo No
            '  .Press = Abs(px) / GRAV / psi                        'Press
            If .Press = 0 Then GoTo No
            .BC = Problem(IndProbl).Tiranti(1).BoltCiD 'Bolt circle
            If .BC <= 0 Then GoTo No
            .BoltL = Problem(IndProbl).TSheDes 'Bolt length
            .BoltN = wnflan.Mp(13) 'Bolt number
            Area = pi / 4 * wnflan.Mp(14) ^ 2
            .BoltA = Area
            If .BoltA <= 0 Then GoTo No
            .gef = wnflan.Mp(37) ' DatiInt(IndProbl).gef  'Diam.eff.guarn
            If .gef <= 0 Then GoTo No
            .b0 = wnflan.Mp(36) 'Largh.eff.guarniz
            If .b0 <= 0 Then GoTo No
            .n = wnflan.Mp(26) 'Largh.tot.guarn
            If .n <= 0 Then GoTo No
            .EE = .E1 'Young della guarnizione
            .SpGuar = 3.0# 'Spess.guarn.
            .DiscoRam = Monitor.Motore.Inizio.DiscoRam
            .ArchDir = Monitor.Motore.Inizio.Archdir
            .Intest = Monitor.Motore.About.ProgName & "(Vers. " & Monitor.Motore.About.ProgVers & ", " & Monitor.Motore.About.ProgDate & ")"
            .Norma = CodiceCalc() & ")"
            Star.Padre.ltxperc = True
            Star.Padre.ltx = 100
            If Not Star.PiastraForata(Estar, nistar) Then GoTo No1
            .Estar = Estar
            .nistar = nistar
        End With
        Exit Function
No:     ROTFL = False
        Testo = "  Alcuni dei dati necessari per il calcolo" & vbCrLf
        Testo = Testo & "della rotazione non sono definiti." & vbCrLf
        Testo = Testo & "  In particolare, porre attenzione al fatto" & vbCrLf
        Testo = Testo & "che la rotazione non può essere calcolata" & vbCrLf
        Testo = Testo & "per una flangia non ancora verificata."
        MessageBox.Show(Testo)
        Exit Function
No1:    ROTFL = False
        Testo = " Non è stato possibile calcolare le costanti" & vbCrLf
        Testo = Testo & "elastiche equivalenti della piastra forata."
        MessageBox.Show(Testo)
        Exit Function
    End Function

    Public Function Carichi(ByRef ICAL As Short) As Boolean
        Carichi = True
        If Not VerificandoPI Then
            Select Case ICAL
                Case 1
                    px = 0
                    sx = Problem(IndProbl).AllFRoo * psi
                Case 2 'tube side
                    px = pression - pscal
                    sx = Problem(IndProbl).AllFOpe * psi
                Case 3 'shell side
                    px = -psal + pcal
                    sx = Problem(IndProbl).AllFOpe * psi
                Case 4 'tube side
                    px = pressdiff
                    sx = Problem(IndProbl).AllFOpe * psi
                Case 5 'shell side
                    px = -pressdiff
                    sx = Problem(IndProbl).AllFOpe * psi
                Case 6
                    px = 0
                    sx = Problem(IndProbl).AllFRoo * psi
            End Select
            temp = (TempDes() - 32) / 1.8
        Else
            Select Case ICAL
                Case 1
                    px = 0
                    sx = Involucr(kLato, jInvolucr).Shydr * psi
                Case 2 'tube side
                    px = pHT - pscal
                    sx = Involucr(kLato, jInvolucr).Shydr * psi 'Problem(IndProbl).AllFOpe
                Case 3 'shell side
                    px = -phtsal + pcal
                    sx = Involucr(kLato, jInvolucr).Shydr * psi 'Problem(IndProbl).AllFOpe
                Case 4 'tube side
                    px = pressdiffHT
                    sx = Involucr(kLato, jInvolucr).Shydr * psi 'Problem(IndProbl).AllFOpe
                Case 5 'shell side
                    px = -pressdiffHT
                    sx = Involucr(kLato, jInvolucr).Shydr * psi 'Problem(IndProbl).AllFOpe
                Case 6
                    px = 0
                    sx = Problem(IndProbl).AllFRoo * psi
            End Select
            temp = 20.0#
        End If
        If sx = 0 Then
            If Not VerificandoPI Then
                MessageBox.Show("Gli ammissibili della Piastra non sono definiti correttamente")
            Else
                MessageBox.Show("L'ammissibile in prova idraulica della Piastra non è definito")
            End If
            Carichi = False
        End If
    End Function

    Public Sub CalcRota()
        px = ppx1(IMAX)
        With objROTFL
            .W = DatiInt(IndProbl).wm1H * NIUT
            .wm2 = DatiInt(IndProbl).wm2H * NIUT
            .Press = System.Math.Abs(px) ' / GRAV / psi 'Press
            .temp = temp
            .E0 = Matdim(indBul).EmodAlt(temp) '/ psi / GRAV 'Young bulloni
            .E1 = Matdim(Ind).EmodAlt(temp) ' / psi / GRAV 'Young flangia
        End With
        ROTFLFOR(objROTFL)
    End Sub

    Public Sub CalcIMAX()
        Dim ICAL As Short
        tfmax = 0.0! : temax = 0.0!
        For ICAL = 2 To 6
            If (Problem(IndProbl).PDIFF = 0 And (ICAL = 2 Or ICAL = 3)) Then GoTo contca1
            If (Problem(IndProbl).PDIFF <> 0 And (ICAL = 4 Or ICAL = 5)) Then GoTo contca1
            If (ICAL = 2 Or ICAL = 3) And px1(ICAL) = 0.0! Then GoTo contca1
            If (tmax(ICAL, MAWPIncorso) > tfmax) Then tfmax = tmax(ICAL, MAWPIncorso) : IMAX = ICAL : DatiInt(IndProbl).IMAX = IMAX
            If (tma1(ICAL, MAWPIncorso) > tfmax) Then tfmax = tma1(ICAL, MAWPIncorso)
            If (tRmax(ICAL, MAWPIncorso) > temax) Then temax = tRmax(ICAL, MAWPIncorso)
            '   IF (tras(ICAL) > temax) THEN temax = tras(ICAL)
            '    i = i + 4
contca1: Next ICAL

    End Sub
    Public Sub CheckAccoppiata()
        Dim TuttokPI As Boolean
        Dim Max2PI As Single
        Strin(1) = " in prova idraulica.|"
        Strin(2) = " in esercizio.|"
        '  Tuttok = Uguale(wnflan.Zp(34), Base.FlDati(16))
        '  If Not Tuttok Then
        '     Max2 = wnflan.Zp(34)
        '     If wnflan.Zp(41) > Max2 Then Max2 = wnflan.Zp(41)
        '     If Base.FlDati(16) > Max2 Then Max2 = Base.FlDati(16)
        '  End If
        TuttokPI = True
        If Config(0).CalcPI = 1 Then
            TuttokPI = Uguale(wnflan.Zp(194), DatiInt(IndProbl).wm2H)
            If Not TuttokPI Then
                Max2PI = wnflan.Zp(194)
                If DatiInt(IndProbl).wm2H > Max2PI Then Max2PI = DatiInt(IndProbl).wm2H
            End If
        End If
        '  If Not Tuttok Then
        '     primo = Base.FlDati(16) < Max2
        '     Secon = wnflan.Zp(41) < Max2
        '     iPr = 2
        '     If primo Or Secon Then GoSub WarnWm
        '     If primo Then
        '        Base.FlDati(16) = Max2
        '     ElseIf Secon Then
        '        wnflan.Mp(41) = Max2 * NIUT
        '        wnflan.Zp(41) = Max2
        '     End If
        '  End If
        If Not TuttokPI Then
            primo = DatiInt(IndProbl).wm2H < Max2PI
            Secon = wnflan.Zp(194) < Max2PI
            iPr = 1
            WarnWm()
            If primo Then
                DatiInt(IndProbl).wm2H = Max2PI
            ElseIf Secon Then
                wnflan.Mp(194) = Max2PI * NIUT
                wnflan.Zp(194) = Max2PI
            End If
            If kk = 1 Then
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Base.FlShelDati. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                Base.FlShelDati(18) = Max2PI
            Else
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Base.FlChanDati. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                Base.FlChanDati(18) = Max2PI
            End If
        End If
        Exit Sub
    End Sub
    Private Sub WarnWm()
        Dim Testo As String = ""
        If primo And Secon Then
            Testo = "La presente membratura " & Trim(Involucr(kLato, jInvolucr).Mark)
            Testo = Testo & "|e la membratura accoppiata " & Trim(Involucr(kk, jj).Mark)
            Testo = Testo & "|devono entrambe essere ricalcolate in quanto"
            Testo = Testo & "|il tiro Wm2 dei tiranti a comune non è congruente"
        ElseIf primo Then
            Testo = "La presente membratura " & Trim(Involucr(kLato, jInvolucr).Mark)
            Testo = Testo & "|deve essere ricalcolata in quanto il tiro"
            Testo = Testo & "|Wm2 dei tiranti a comune con la|membratura "
            Testo = Testo & Trim(Involucr(kk, jj).Mark) & " non corrisponde"
            Testo = Testo & "|al calcolo di quest'ultima "
        ElseIf Secon Then
            Testo = "La membratura " & Trim(Involucr(kk, jj).Mark)
            Testo = Testo & " deve essere|ricalcolata in quanto il tiro"
            Testo = Testo & "|Wm2 dei tiranti a comune con la presente|membratura "
            Testo = Testo & Trim(Involucr(kLato, jInvolucr).Mark) & " non corrisponde"
            Testo = Testo & "|al calcolo di quest'ultima "
        End If
        Testo = Testo & Strin(iPr)
        uu = Testo
        Testo = Testo & "Devo correggere i dati della membratura da ricalcolare? "
        Dim junk As DialogResult = DialogResult.No
        If Not ContinuoAuto Then
            junk = MessageBox.Show(clsInizio.ConvertiCr(Testo), "AsmeVip", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        Else
            junk = DialogResult.Yes
            PrintlstRes(uu)
        End If
        If junk = DialogResult.No Then primo = False : Secon = False
    End Sub
End Class