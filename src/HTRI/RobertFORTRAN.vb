Imports system.math
Module RobertFORTRAN
    'c********** UPM.FI ***********************************************
    '      COMMON/SERVIZ/INZ1,IN3,RATIO(2,4),MAWP,MAWPKGCM2,MAWPPSI,
    '    $   CONTROL,STIFFEXX,NUMCAS,KTEMP,XI1,XI2
    'Private CONTROL As String
    'Private MAWP, MAWPKGCM2, MAWPPSI, KTEMP As Single
    '      COMMON/UPM1/BUFFER(750)
    'Private BUFFER As clsMecData
    'Private KPJ1, LUNGF, LARGF, NFILE(16), NFMAX, PASSO(16), NASELLO, TOLL As Single
    'Private FBOCIN, FBOCOT, DO0, TSP, DALETT, ALINCH, SPTUB As Single
    'Private TVERT, H, HE, HX3, HX4, SUG, EWPS, EWC, E, HX5(16), EL(3), C(3) As Single
    'Private DINMM, DOUTMM, SPINMM, SPOUTMM, PVERT, VUOTA, VUOTB As Single
    'Private ALTBOCIN, ALTBOCOUT, ALTFLIN, ALTFLOUT, ALARGHINTEL, XXCORR As Single
    'Private VUOTO(32), PACC(16), P, PJ, T, CA, T1, T2, T3, T5, XX As Single
    'Private BUCORINF, PASSORINF, GAP, STIFFEFF, STIFFEXX As Single
    'Private BF(5), DF(5), TK(5), TF(5), RATIO, XI1, XI2, .Ammiss0(4), S(4), SJ(2) As Single
    'Private NS, NFASCI, NTUB, MATHOM, IN4, NUMCAS As Integer
    'Private NROWS, NBOCIN, NBOCOT, NPAS, TIPO, NUMIT, NDUM, BCGL(2) _
    '     , TIPTEST, NSFUNZ, RICORDA(4), PASSFRAZ _
    '     , PADDING(197), SALDATURA(16), CODICE _
    '     , iMATUG, iMATSH, iMATTP, iMATEN, iMATSE, iMATTUB, iMATTAP _
    '     , iMATGUAR As Integer
    'Private INZ1, IN3 As Integer
    'Private ESIS, APERTO As Boolean
    'Private CUSTMR, PLTLOC, ENGR, HEADER, SRVICE, UNIMIS, SPBWG, SPTOL, _
    '       TIPAL, BANCO(2), LINGUA, RATING(10), HORPAS, _
    '       IRIS, IEL, IVK, ITEMNO, JOBNUM(2), ICKNR, IREV, _
    '       MATUG, MATSH, MATTP, MATEN, MATSE, MATTUB, MATTAP, MATGUAR As String
    'Private SCHIN, SCHOUT As String
    'c***********************************************************************
    'c******************ROBW************************************
    '  COMMON/ROBW/SHDR,SRTHDR,SCOV,SRTCOV,PRESS,
    ' &ALTHDR,TEMP,HDRLAR,CORR,GSSPAN,GLSPAN,EFSALD,FACTC,
    ' &TUBDIA,TUBPAS,PN,ROWNUM,GASTHK,ARIA,
    ' &G1,G2,G3,G4,G5,G6,G7
    ' $,AM2,AB,TC1,TC2,TC3,TC4,TF1,TF2
    ' $,AM,ZULU,BEFF,TP1,WM1,WM2,TC,W,ECO
    ' $,TP2B,TT1,TP3B,TP4B,BENDP1,BY,BENDP2
    ' $,TT2B,TT3B,WG,TSETTO,TP2M,TP,TP3M,TT2M,EFFLEG,BENDMF,BENDMG,B0
    ' $,B1,B2,B3,EFFSALD,FACTZ,PERIM,AM1,BMAXAPI,BASS,FACTAPI
    ' $,TC2P,TC2PP,HF
    '  CHARACTER*18 BLTMAT,GSKMAT,BLTDIA
    'REAL*4 G1,G2,G3,G4,G5,G6,G7,BLTARE,BLTNUM,SBLT,SRTBLT,YGASK
    'REAL*4 FACTM,RISLAR,GASLAR,TOLLAV,HG,ARMI,XSPAN,TFTF,TT
    Private GASTHK, ARIA, FACTC, SHDR, SRTHDR, SCOV, SRTCOV As Single
    'REAL*4 GASTHK,READLIB,ARIA,STAND(6),FACTC,SHDR,SRTHDR,SCOV,SRTCOV
    Private TEMP, PRESS, ALTHDR, HDRLAR, BMAXAPI, CORR, B0, BEFF, HF, GSSPAN As Single
    'REAL*4 TEMP,PRESS,ALTHDR,HDRLAR,BMAXAPI,CORR,B0,BEFF,HF,GSSPAN
    Private GLSPAN, EFSALD, TUBDIA, TUBPAS, PN, ROWNUM, GGG(7), A, AB, EFFLEG As Single
    'REAL*4 GLSPAN,EFSALD,TUBDIA,TUBPAS,PN,ROWNUM,GGG(7),A,AB,EFFLEG
    Private PERIM, BASS, B3, FACTAPI, FACTZ, ZULU, WG, RIS, ECO, BENDMF As Single
    'REAL*4 PERIM,BASS,B3,FACTAPI,FACTZ,ZULU,WG,RIS,ECO,BENDMF
    Private BENDP1, BENDP2, WM1, WM2, AM1, AM2, AM, W, BY, BENDMG, TP1, TP2G As Single
    'REAL*4 BENDP1,BENDP2,WM1,WM2,AM1,AM2,AM,W,BY,BENDMG,TP1,TP2G
    Private TP2M, TP3B, TP3M, TP4B, TT1, TT2B, TT2M, TT3B, TF1, TF2, TC1, TC2 As Single
    'REAL*4 TP2M,TP3B,TP3M,TP4B,TT1,TT2B,TT2M,TT3B,TF1,TF2,TC1,TC2
    Private TP2B, TC2P, TC3, TC4, TC2PP, B1, B2, TP, TC, TSETTO, EFFSALD As Single
    'REAL*4 TP2B,TC2P,TC3,TC4,TC2PP,B1,B2,AMAX4,TP,TC,TSETTO
    'REAL*4 EFFSALD
    '  EQUIVALENCE(G1,GGG(1)),(G2,GGG(2)),(G3,GGG(3)),
    ' 1           (G4,GGG(4)),(G5,GGG(5)),(G6,GGG(6)),(G7,GGG(7))
    '  EQUIVALENCE(BF(2),BLTARE),(BF(3),BLTNUM)
    '  EQUIVALENCE(BF(4),SBLT),(BF(5),SRTBLT),(DF(1),YGASK)
    '  EQUIVALENCE(DF(2),FACTM),(DF(3),RISLAR),(DF(4),GASLAR)
    '  EQUIVALENCE(DF(5),TOLLAV),(TK(1),HG),(TK(2),ARMI),(TK(3),XSPAN)
    '  EQUIVALENCE(TK(4),TFTF),(TK(5),TT)
    '  EQUIVALENCE(MATTAP(1),BLTMAT),(MATGUAR(1),GSKMAT)
    'EQUIVALENCE(MATTP(1),BLTDIA)
    '  EQUIVALENCE(STAND(1),DF(3))
    'c**********************************************************
    Sub ROBFOR(ByVal ICASSA As Integer, ByVal IUNIT As Integer, ByVal ISW As Integer, ByVal PREV As String)
        'C***********************************************
        Dim ifl As Integer
        Dim IREC, IPOS As Integer
        'C********************************************************************
        ifl = FreeFile()
        FileOpen(ifl, FileMec, OpenMode.Random, , , Len(MecData(0)))
        ''''If (ICASSA > 0) Then
        ''''FileGet(ifl, MecData(ICASSA), ICASSA)   'READ(8,REC=ICASSA)BUFFER
        ''''Else
        ''''FileGet(ifl, MecData(ICASSA), 1)   '      READ(8,REC=1)BUFFER
        ''''End If
        FileClose(ifl)
        IREC = 22 + ISW
        With MecData(ICASSA)
            If (.XSPAN = 0) Then .XSPAN = .xx
            If (.TFTF = 0) Then .TFTF = 20
            If (.TT = 0) Then .TT = 25
            IPOS = 8
            GASTHK = ReadLib(IREC, IPOS)
            IPOS = 9
            ARIA = ReadLib(IREC, IPOS)
            For IPOS = 1 To 6
                If (IPOS = 5 And ISW = 1 And .STAND(IPOS) <= 0) Then _
                    .STAND(IPOS) = ReadLib(IREC, IPOS) - .CA / 2
                If (.STAND(IPOS) = 0) Then _
                    .STAND(IPOS) = ReadLib(IREC, IPOS)
                'If (.CA >= GASTHK And IPOS = 3) Then
                '.TOLLAV = .TOLLAV + .CA
                'ElseIf (IPOS = 3) Then
                '.TOLLAV = .TOLLAV + GASTHK
                'End If
            Next IPOS
            ifl = FreeFile()
            FileOpen(ifl, Monitor.Motore.Inizio.DiscoTem & PREV, OpenMode.Output)
            Dim i As Integer
            For i = 0 To 4 : PrintLine(ifl, GlobalRoutines.myStr(.BF(i), 8, 3, 0)) : Next
            For i = 0 To 4 : PrintLine(ifl, GlobalRoutines.myStr(.DF(i), 8, 3, 0)) : Next
            PrintLine(ifl, GlobalRoutines.myStr(.H, 8, 3, 0))
            For i = 0 To 4 : PrintLine(ifl, GlobalRoutines.myStr(.TK(i), 8, 3, 0)) : Next
            ' WRITE(1,'(F12.3)')BF(1),BF(2),BF(3),BF(4),BF(5),_
            '  DF, H, TK
        End With
        FileClose(ifl)
    End Sub
    Sub ROBFO1(ByVal ICASSA As Integer, ByVal ISW As Integer)
        'C***********************************************
        '  INCLUDE() 'UPM.FI'
        '  INCLUDE() 'CMN.FI'
        '  INCLUDE() 'CMN1.FI'
        '  INCLUDE() 'ROBW.FOR'
        Dim ifl, I, IPN, NEWBOL As Integer
        Dim REWBOL As Single
        'C********************************************************************
        ifl = FreeFile()
        'FileOpen(ifl, FileMec, OpenMode.Random, , , Len(MecData(0)))
        '      OPEN(8,FILE=ARCHW(1:LEN_TRIM(ARCHW))//'\'//MEC,
        '     2    FORM='UNFORMATTED',RECL=1500,ERR=133,IOSTAT=IERR,
        '     1    ACCESS='DIRECT',STATUS='UNKNOWN')
        'If (Abs(ICASSA) > 0) Then
        'FileGet(ifl, BUFFER, Abs(ICASSA)) 'BUFFER
        'Else
        'FileGet(ifl, BUFFER, 1) 'BUFFER
        'End If
        'FileClose(ifl)
        '      OPEN (1,FILE='TEXT'//PREVENT,STATUS='OLD',ERR=134,IOSTAT=IERR)                                                          ROB00110
        FileOpen(ifl, Monitor.Motore.Inizio.DiscoTem & RTrim(job.Contratto), OpenMode.Input)
        With MecData(ICASSA)
            '     READ(1,'(A10)')BLTDIA
            .MATTP = LineInput(ifl)
            For I = 2 To 5 : .BF(I - 1) = GlobalRoutines.ValVir(LineInput(ifl)) : Next
            For I = 1 To 5 : .DF(I - 1) = GlobalRoutines.ValVir(LineInput(ifl)) : Next
            .H = GlobalRoutines.ValVir(LineInput(ifl))
            For I = 1 To 5 : .TK(I - 1) = GlobalRoutines.ValVir(LineInput(ifl)) : Next
            .MATTAP = LineInput(ifl)
            .MATGUAR = LineInput(ifl)
            '    READ(1,'(F12.3)') BLTARE,BLTNUM,SBLT,SRTBLT,
            '  *YGASK,FACTM,RISLAR,GASLAR,
            ' &TOLLAV,H,HG,ARMI,XSPAN,
            '&TFTF,TT
            'READ(1,'(A18)')BLTMAT,GSKMAT
        End With
        FileClose(ifl)
        FileOpen(ifl, FileMec, OpenMode.Random, , , Len(MecData(0)))
        '  OPEN(8,FILE=ARCHW(1:LEN_TRIM(ARCHW))//'\'//MECC%St,
        '2    FORM='UNFORMATTED',RECL=1500,ERR=132,IOSTAT=IERR,
        '1    ACCESS='DIRECT',STATUS='UNKNOWN')
        If (ICASSA > 0) Then
            FilePut(ifl, MecData(ICASSA), ICASSA)   'READ(8,REC=ICASSA)BUFFER
        Else
            FilePut(ifl, MecData(ICASSA), 1)   '      READ(8,REC=1)BUFFER
        End If
        FileClose(ifl)
        If (ISW = 1) Then Exit Sub
        With MecData(ICASSA)
            If (.RISLAR > 0) Then
                .Nasello = .TOLLAV - GASTHK + ARIA
            Else
                .Nasello = 0
            End If
            FACTC = 0.3
            .SBLT = .SBLT * 9.80665
            .SRTBLT = .SRTBLT * 9.80655
            .YGASK = .YGASK * 9.80655
            If (.MATHOM = 1) Then
                SHDR = .SUG * 9.80655
                SRTHDR = .Ammiss0(4) * 9.80655
                SCOV = .SUG * 9.80655
                SRTCOV = .Ammiss0(4) * 9.80655
            Else
                SHDR = .Ammiss(1) * 9.80655
                SRTHDR = .Ammiss0(1) * 9.80655
                SCOV = .Ammiss(3) * 9.80655
                SRTCOV = .Ammiss0(3) * 9.80655
            End If
            TEMP = .T
            PRESS = .P * 0.980655
            ALTHDR = .HX3
            HDRLAR = .H + .Nasello
            BMAXAPI = 2 * Sqrt(4 / PI * .BLTARE) + 6 * .TFTF / (.FACTM + 0.5)
            CORR = .CA
            B0 = (.RISLAR + .GASLAR) / 4
            If (.RISLAR <= 0) Then B0 = .GASLAR / 2
            If (B0 <= 25.4 / 4) Then
                BEFF = B0
                HF = .HG
            Else
                BEFF = 25.4 / 2 * Sqrt(25.4 * B0)
                If (.RISLAR <= 0) Then
                    HF = .HG - .GASLAR / 2 + BEFF
                Else
                    HF = .HG - .RISLAR / 2 + BEFF
                End If
            End If
            GSSPAN = ALTHDR + 2 * (.TT + .ARMI - HF)
            GLSPAN = .Largf + 2 * (.TT + .ARMI - HF)
            EFSALD = .EWC
            TUBDIA = .DO_Renamed
            TUBPAS = .TSP
            PN = .NS
            ROWNUM = .NROWS
            If (ROWNUM = 0) Then
                For I = 1 To .NS + 1
                    ROWNUM = ROWNUM + .Nfile(I - 1)
                Next
            End If
            For I = 1 To .NS + 1
                GGG(I) = .HX5(I)
            Next
            GGG(1) = GGG(1) + .TT + .ARMI - HF
            GGG(.NS + 1) = GGG(.NS + 1) + .TT + .ARMI - HF
            If (GGG(1) > GGG(.NS + 1)) Then
                For I = 1 To (.NS + 1) / 2
                    A = GGG(I)
                    GGG(I) = GGG(.NS + 2 - I)
                    GGG(.NS + 2 - I) = A
                Next
            End If
            For I = .NS + 1 To 7
                GGG(I) = 0
            Next
            '      OPEN(1,FILE='TEXT'//PREVENT)
            AB = .BLTNUM * .BLTARE
            EFFLEG = (TUBPAS - TUBDIA) / TUBPAS
            PERIM = ((GSSPAN + 2 * HF) + (GLSPAN + 2 * HF)) * 2
            BMAXAPI = 2 * Sqrt(4 / PI * .BLTARE) + 6 * .TFTF / (.FACTM + 0.5)
            BASS = B3
            If (BASS = 0) Then BASS = PERIM / .BLTNUM
            FACTAPI = 1
            If (BASS > BMAXAPI) Then FACTAPI = Sqrt(BASS / BMAXAPI)
            FACTZ = 3.4 - 2.4 * GSSPAN / GLSPAN
            If (FACTZ > 2.5) Then FACTZ = 2.5
            ZULU = PN * (GGG(1) + HF) + (PN - 1) * GGG(2) + (PN - 2) * GGG(3) + _
                  (PN - 3) * GGG(4) + (PN - 4) * GGG(5) + (PN - 5) * GGG(6) + (PN - 6) * GGG(7)
            WG = (BEFF * .YGASK * (1 + PN / 6) - (BEFF * .YGASK / _
                 (6 * (GSSPAN + 2 * HF)) * ZULU)) * FACTAPI
            RIS = .RISLAR
            If (RIS <= 0) Then RIS = .GASLAR
            ECO = (.ARMI + .TT - CORR - HF - RIS / 2) * (HF / 2 - .ARMI / 2 + RIS / 4)
            BENDMF = PRESS / 10 * (2 * BEFF * .FACTM * HF + _
                    (GSSPAN / 2 * (.ARMI + .TT / 2 - CORR / 2)) + ECO)
            BENDP1 = PRESS / 20 * (HDRLAR + CORR) ^ 2 - BENDMF
            BENDP2 = PRESS / 20 * (.TFTF + .TOLLAV + 2) ^ 2 - BENDMF
            WM1 = 4 * BEFF * .FACTM * (GSSPAN + GLSPAN) * PRESS / 10 _
                  * FACTAPI + (GSSPAN * GLSPAN * PRESS / 10)
            WM2 = 2 * BEFF * .YGASK * (GSSPAN + GLSPAN) * FACTAPI
            AM1 = WM1 / .SBLT
            AM2 = WM2 / .SRTBLT
            AM = Max(AM1, AM2)
            If (AM < AB) Then GoTo 105
            ' WRITE(1,6000)AM,AB
            '6000  FORMAT('>>AREA BULLONI INSUFFICIENTE: AM='F10.0,' AB='F10.0)
            '   CLOSE(1)
            Exit Sub 'return
105:        W = (AM + AB) / 2 * .SRTBLT
            BY = BEFF * .YGASK
            BENDMG = WG * .HG
            REWBOL = PN
            IPN = Int(REWBOL)
            For I = 1 To IPN
                BENDMG = BENDMG + (WG - BY * (5 + I) / 6) * GGG(I)
            Next
            'c      IF (WG.GT.2.*BY) GOTO 106                                         ROB00500
            'c      IF (WG.GT.11/6.*BY) GOTO 107                                      ROB00510
            'c      IF (WG.GT.10/6.*BY) GOTO 108                                      ROB00520
            'c      IF (WG.GT.9/6.*BY) GOTO 109                                       ROB00530
            'c      IF (WG.GT.8/6.*BY) GOTO 110                                       ROB00540
            'c      IF (WG.GT.7/6.*BY) GOTO 111                                       ROB00550
            'c      IF (WG.GE.BY) GOTO 112
            '        c106(Write(1, 6001))
            'c6001  FORMAT('>>MOMENTO MG PER CALCOLO COPERCHIO MAGGIORE DI 2 B Y')
            '        CLOSE(1))
            'c      RETURN
            'c107   BENDMG=WG*(HF+GGG(1)+GGG(2)+GGG(3)+GGG(4)+GGG(5)+GGG(6))-BY*(GGG(1)+7/6.*GGG(2)+4/3.*GGG(3)+3/2.*GGG(4)+  ROB00590
            'c     &5/3.*GGG(5)+11/6.*GGG(6))                                                 ROB00600
            'c      GOTO 113                                                          ROB00610
            'c108   BENDMG=WG*(HF+GGG(1)+GGG(2)+GGG(3)+GGG(4)+GGG(5))-BY*(GGG(1)+7/6.*GGG(2)+4/3.*GGG(3)+3/2.*GGG(4)+5/3.*ROB00620
            'c     &GGG(5))                                                               ROB00630
            'c      GOTO 113                                                          ROB00640
            'c109   BENDMG=WG*(HF+GGG(1)+GGG(2)+GGG(3)+GGG(4))-BY*(GGG(1)+7/6.*GGG(2)+4/3.*GGG(3)+3/2.*GGG(4))        ROB00650
            'c      GOTO 113                                                          ROB00660
            'c110   BENDMG=WG*(HF+GGG(1)+GGG(2)+GGG(3))-BY*(GGG(1)+7/6.*GGG(2)+4/3.*GGG(3))                   ROB00670
            'c      GOTO 113                                                          ROB00680
            'c111   BENDMG=WG*(HF+GGG(1)+GGG(2))-BY*(GGG(1)+7/6.*GGG(2))                              ROB00690
            'c      GOTO 113                                                          ROB00700
            'c112   BENDMG=WG*(HF+GGG(1))-BY*GGG(1)                                           ROB00710
113:        If (Abs(SRTHDR) < 1) Then SRTHDR = SHDR
            TP1 = (6 * WG * HF / 1.5 / SRTHDR / EFFLEG) ^ 0.5
            TP2B = (6 * Abs(BENDP1) / 1.5 / SHDR / EFSALD) ^ 0.5
            TP2M = PRESS * (HDRLAR + CORR) / SHDR / EFSALD / 10
            TP3B = (PRESS * ((ALTHDR + 2 * CORR) ^ 2) / 80 - BENDP1) / 1.5 / SHDR / EFFLEG
            TP3B = (6 * Abs(TP3B)) ^ 0.5
            TP3M = PRESS * (HDRLAR + 2 * CORR) / SHDR / EFFLEG / 10
            TP4B = (BENDP1 - PRESS / 20 * .XSPAN * (ALTHDR + 2 * CORR - .XSPAN)) / 1.5 / SHDR / EFFLEG
            TP4B = (6 * Abs(TP4B)) ^ 0.5
            Dim p As RoutBase1.clsProblem = Monitor.Motore.Problem
            p.Printa(FormatStringa(1)) 'S P E S S O R I  P I A S T R A  T U B I E R A'         
            p.Printa(String.Format(FormatStringa(1006), (TP1 + CORR), _
                     (TP2B + TP2M + CORR), (TP3B + TP3M + CORR), (TP4B + TP3M + CORR)))
            '1006  FORMAT (F6.2,3(3X,F6.2))                                          
            TT1 = (6 * WG * HF / 1.5 / SRTHDR / EFSALD) ^ 0.5
            TT2B = (6 * Abs(BENDP1) / 1.5 / SHDR / EFSALD) ^ 0.5
            TT2M = PRESS * (ALTHDR + 2 * CORR) / 20 / SHDR / EFSALD
            TT3B = (6 * Abs(BENDP2) / 1.5 / SHDR / EFSALD) ^ 0.5
            p.Printa(FormatStringa(2)) 'Spessori Top & Bottom & End MINIMI/ASSUNTO'
            p.Printa(String.Format(FormatStringa(1007), (TT1 + CORR), _
                 (TT2B + TT2M + CORR), (TT3B + TT2M + CORR), .TT))
            '1007  FORMAT (F6.2,2(3X,F6.2),12X,F6.2)                               
            TF1 = (6 * WG * .ARMI / 1.5 / SRTHDR / EFSALD) ^ 0.5
            TF2 = (6 * PRESS / 10 * (2 * .FACTM * BEFF + GSSPAN / 2) * .ARMI / 1.5 / SHDR / EFSALD) ^ 0.5
            p.Printa(FormatStringa(3)) 'Spessori Flangia            MINIMI/ASSUNTO'
            p.Printa(String.Format(FormatStringa(1008), TF1, TF2, .TFTF))
            '1008  FORMAT (F6.2,3X,F6.2,21X,F6.2)                                   
            TC1 = (FACTZ * FACTC * PRESS / 10 / SCOV) + (6 * WM1 * HF / SCOV / PERIM / (GSSPAN ^ 2))
            TC1 = GSSPAN * (TC1 ^ 0.5)
            TC2 = (6 * W * HF / SRTCOV / PERIM) ^ 0.5
            If (.RISLAR < 0) Then TC2P = (6 * W * (HF - .GASLAR / 2) / SCOV / PERIM) ^ 0.5
            TC3 = (6 * BENDMG / SRTCOV) ^ 0.5
            TC4 = GSSPAN ^ 2 / 8 + (GSSPAN / 2 + 2 * BEFF * .FACTM) * HF
            TC4 = (6 * PRESS / 10 * TC4 / SCOV) ^ 0.5
            TC2PP = TC2P + .TOLLAV
            If (.RISLAR < 0) Then TC2PP = TC2PP - .RISLAR
            p.Printa(String.Format(FormatStringa(1009), (TC1 + .TOLLAV), _
               (TC2 + .TOLLAV), TC2PP, (TC3 + .TOLLAV), (TC4 + .TOLLAV)))
            '1009  FORMAT ('SPESSORI COPERCHIO ASME      SPESSORI COPERCHIO H.I.'/
            '    1 F7.2,2X,F7.2,2X,F7.2,6X,F7.2,5X,F7.2)
            B1 = .BLTARE * .SRTBLT / WG
            B2 = .BLTARE * .SBLT * 10 / PRESS / (GSSPAN / 2 + 2 * BEFF * .FACTM)
            p.Printa(FormatStringa(4)) 'PASSO TIRANTI : BOLTING UP OPER. CONDITION MAX.API'
            p.Printa(String.Format(FormatStringa(1010), B1, B2, BMAXAPI))
            '1010  FORMAT (1H.,15X,F8.1,7X,F8.1,7X,F8.1)                  
            If (.SP(2 - 1) < 0) Then .SP(2 - 1) = GlobalRoutines.Massimo( _
                       TP1 + CORR, TP2B + TP2M + CORR, _
                       TP3B + TP3M + CORR, TP4B + TP3M + CORR) ' sp(2) era T2
            If (.SP(5 - 1) <= 0) Then
                .SP(5 - 1) = GlobalRoutines.Massimo(TC1 + .TOLLAV, TC2 + .TOLLAV, _
                                     TC3 + .TOLLAV, TC4 + .TOLLAV) ' SP(5) era T5
                If (TC2PP > .SP(5 - 1)) Then .SP(5 - 1) = TC2PP
            End If
            If (.SP(3 - 1) <= 0) Then .SP(3 - 1) = RIS + 2 * CORR
            If (B3 <= 0) Then
                B3 = TUBPAS
                If (B2 < B3) Then B3 = B2
                If (B1 < B3) Then B3 = B1
            End If
            REWBOL = PERIM / B3
            NEWBOL = CInt(REWBOL + 1)
            p.Printa(String.Format(FormatStringa(1110), .BLTNUM, NEWBOL))
            '1110  FORMAT(' Numero bulloni  ipotizzato/risultante ',F4.0,'/',I4)
            p.Printa(String.Format(FormatStringa(5), .SP(2 - 1))) '(''> SPESSORE PIASTRA TUBIERA'',F10.2)')T2
            p.Printa(String.Format(FormatStringa(6), .SP(5 - 1))) '(''> SPESSORE COVER          '',F10.2)')T5
            p.Printa(String.Format(FormatStringa(7), .SP(3 - 1))) '(''> SPESSORE SETTI          '',F10.2)')T3
            p.Printa(String.Format(FormatStringa(8), B3)) '(''> PASSO BULLONI           '',F10.2)')B3
            '   CLOSE(1)
            ifl = FreeFile()
            FileOpen(ifl, FileMec, OpenMode.Random)
            'OPEN(8,FILE=ARCHW(1:LEN_TRIM(ARCHW))//'\'//MEC,
            '    2    FORM='UNFORMATTED',RECL=1500,
            '   1    ACCESS='DIRECT',STATUS='UNKNOWN')
        End With
        If (Abs(ICASSA) > 0) Then
            FilePut(ifl, MecData(ICASSA), Abs(ICASSA))
        Else
            FilePut(ifl, MecData(ICASSA), 1)
        End If
        FileClose(ifl)
        '        Return
        '133   WRITE(DOMANDA,'(9HErrore n°,I5,21H durante apertura di ,2A1,
        '     XA40,'' (ROBFO1)'',A1)')IERR,CHAR(13),CHAR(10),
        '     1ARCHW(1:LEN_TRIM(ARCHW))//'\'//MEC,CHAR(0)
        '      X=MessageBoxEx(NULL,DOMANDA,'ISA'C,MB_OK+
        '     1	 MB_ICONSTOP,LANG_ITALIAN)
        '        Return
        '134   WRITE(DOMANDA,'(9HErrore n°,I5,21H durante apertura di ,2A1,
        '     XA40,'' (ROBFO1)'',A1)')IERR,CHAR(13),CHAR(10),'TEXT'//PREVENT
        '     x     ,CHAR(0)
        '      X=MessageBoxEx(NULL,DOMANDA,'ISA'C,MB_OK+
        '     1	 MB_ICONSTOP,LANG_ITALIAN)
        '        Return
    End Sub
    Sub ROBFIN(ByVal ICASSA As Integer, ByVal nCasse As Integer)
'C***********************************************
 '       INCLUDE() 'UPM.FI'
        '      INCLUDE() 'CMN.FI'
        '     INCLUDE() 'CMN1.FI'
        '    INCLUDE() 'ROBW.FOR'
        Dim REWBOL As Single
        Dim IC As Integer
        Dim Ifl As Integer
        'C********************************************************************
        '     OPEN(1,FILE='TEXT'//PREVENT,STATUS='OLD',ERR=101,IOSTAT=IERR)
        '     READ(1,'(F12.3)',ERR=102,IOSTAT=IERR) TP,TC,TSETTO,B3
        '     CLOSE(1,STATUS='DELETE')
        Ifl = FreeFile()
        FileOpen(Ifl, FileMec, OpenMode.Random)
        '  OPEN(8,FILE=ARCHW(1:LEN_TRIM(ARCHW))//'\'//MEC,
        ' 2    FORM='UNFORMATTED',RECL=1500,
        '1    ACCESS='DIRECT',STATUS='UNKNOWN')
        FileGet(Ifl, MecData(Abs(ICASSA)), Max(Abs(ICASSA), 1))
        With MecData(Abs(ICASSA))
            .SP(1 - 1) = .TT
            .SP(2 - 1) = TP
            .SP(3 - 1) = TSETTO
            .SP(5 - 1) = TC
            REWBOL = PERIM / B3
            'c      BLTNUM=INTERO(REWBOL+1.)
            .HE = B3
        End With
        'c da registrare B3 passo bulloni
        FilePut(Ifl, MecData(Abs(ICASSA)), Max(Abs(ICASSA), 1))
        FileClose(Ifl)
        If (ICASSA < 0) Then Exit Sub
        '      OPEN(1,FILE='TEXT'//PREVENT)
        IC = ICASSA
        If (IC = 0) Then IC = 1
        '         WRITE(1,1011)IC,TRIM(FIRMA),IC,NCASSE
        '1011  FORMAT(2H1a,I2
        'a /5X,'* Program name: ROBFOR  rev.1 (Date: Jan-07-1995)'
        '& /5X,'*** ',A20,' ***',20X,'Page',I2,' of',I2
        '1    /5X,'THRU-BOLTS TYPE HEADER (CONFINED GASKET) CHECK SHEET'//)
        '   Call DATAM(IGIO, IMES, IANNO)
        ' WRITE(1,1520)ENGR,IGIO,IMES,IANNO,ICKNR,CUSTMR,JOBNUM,
        '&SRVICE,ITEMNO,PLTLOC,IREV,HEADER
        '1520  FORMAT(5X,'ENGR    :',1X,2A2,33X,'DATE  :',1X,2(I2,'/'),I4,
        '    &/,5X,'APPR  BY:',38X,'DOC.No: ',6A2,                              UPM00320
        '    &/,5X,'CUSTOMER:',1X,16X,10A2,1X,'JOB No: ',4X,2A2,
        '    &/,5X,'SERVICE :',1X,20A2,1X,'ITEM  :',1X,10A2,
        '    &/,5X,'PLANT   :',1X,4X,10A2,13X,'REVIS.: ',A2/20X,'HEADER: ',5A2)
        '       Write(1, 1519)
        '1519  FORMAT(23X,'***** INPUT DATA *****')
        '      WRITE(1,1000)MATSH,
        '     &            SHDR,SRTHDR,MATEN,SCOV,SRTCOV,BLTMAT,
        '     1SBLT,SRTBLT,GSKMAT,YGASK,GASTHK,FACTM,PRESS,
        '     &ALTHDR,TEMP,HDRLAR,CORR,GSSPAN,TOLLAV,GLSPAN,EFSALD,HF,FACTC,ARMI
        '      IF(RISLAR.GT.0.)THEN
        '      WRITE(1,1001)TUBDIA,RISLAR
        '        Else
        '      WRITE(1,1003)TUBDIA,-RISLAR
        '        End If
        '      WRITE(1,1002) TUBPAS,GASLAR,BLTDIA,XSPAN,BLTARE,BLTNUM,
        '1:      PN, ROWNUM, TFTF, TT, GGG(1), GGG(2), GGG(3), GGG(4), GGG(5), GGG(6), GGG(7)
        '1000  FORMAT(5X,'HEADER MAT=',9A2,2X,'ALLOW.STRESS S/SRT (N/MM2)=',
        '     1F7.2,1H/,F7.2/5X,'COVER  MAT=',9A2,2X,
        '2:      'ALLOW.STRESS S/SRT (N/MM2)='F7.2,1H/,F7.2/5X,'BOLT   MAT=',
        '     3A18,2X,'ALLOW.STRESS S/SRT (N/MM2)='F7.2,1H/,F7.2/
        '     45X,'GASKET MAT=',A18,2X,'DES. SEAT.STRESS Y (N/MM2)='8X,F7.2/
        '     55X,'GASKET THICKNES (MM)='F8.2, 2X,'GASKET FACTOR           M =',
        '     5         8X,F7.2//
        '     65X,'DESIGN PRESS. (BARG)='F8.2,13X,'HEADER INS.HEIGHT (MM)='F8.2/
        '     75X,'DESIGN TEMP.    (øC)='F8.2,13X,'HEADER INS. WIDTH (MM)='F8.2/
        '     95X,'CORROSION ALLOW.(MM)='F8.2,13X,'SHORT GASK. SPAN  (MM)='F8.2/
        '     *5X,'MACHINING ALLOW.(MM)='F8.2,13X,'LONG GASK. SPAN   (MM)='F8.2/
        '     &5X,'JOINT EFFICIENCY    ='F8.2,13X,'BOLT MOMENT ARM HG(MM)='F8.2/
        '     %5X,'C FACTOR  ASME UG-34='F8.2,13X,'FLANGE MOM. ARM I (MM)='F8.2)
        '1001  FORMAT(5X,
        '     ^'TUBES O.D.      (MM)='F8.2,13X,'TONGUE FACE WIDTH (MM)='F8.2)
        '1003  FORMAT(5X,
        '     ^'TUBES O.D.      (MM)='F8.2,13X,'COVER STEP HEIGHT (MM)='F8.2)
        '1002  FORMAT(
        '     15X,'TUBES PITCH     (MM)='F8.2,13X,'GASKET WIDTH      (MM)='F8.2/
        '     25X,'BOLTS SIZE     :   '  A10 ,13X,'END SPAN          (MM)='F8.2/
        '     35X,'ROOT AREA      (MM2)='F8.2,13X,'BOLTS NUMBER          ='F8.2/
        '        c(3) '                      '8X  ,13X,'BOLT PITCH        (MM)='F8.2/
        '     45X,'PARTITIONS NUMBER   ='F8.2,13X,'ROWS NUMBER           ='F8.2/
        '     55X,'FLANGE THK      (MM)='F8.2,13X,'TOP & BTM PL. THK (MM)='F8.2/
        '     65X,'POSITION       :    G1      G2      G3      G4      G5      G'
        '7:      '6      G7'/5X,'PART. SPAN (MM)=  '6(F5.1,3H  /),F5.1/ )
        '      WRITE(1,*)'                   ***** ANALYSIS  RESULTS *****'      ROB01160
        '      WRITE(1,*)'     ******     SYMBOLS AND FORMULAS ARE SHOWN ON EXPLAROB01170
        '     &NATION LIST     ******'                                           ROB01180
        '      WRITE(1,1012) BEFF,EFFLEG,FACTZ                                   ROB01190
        '1012  FORMAT (5X,12HB      (MM)=,F6.3,10X,9HEL      =,F6.3,11X,10HZ
        '     &   =,F6.3)                                                        ROB01210
        '      WRITE(1,1014)BENDP1,WM1,AM1,BENDP2,WM2,AM2,BENDMF,
        '     1 W,AM,PERIM,WG,
        '     &AB,B1,B2,BMAXAPI,BASS,FACTAPI
        '1014  FORMAT(5X,12HMP1  (N*MM)=,F9.1,7X,9HWM1  (N)=,F10.1,7X,10HAM1 (MM2
        '     &)=,F9.1,/5X,12HMP2  (N*MM)=,F9.1,7X,9HWM2  (N)=,F10.1,7X,10HAM2 (M
        '     &M2)=,F9.1,/5X,12HMF   (N*MM)=,F9.1,7X,9HW    (N)=,F10.1,7X,10HAM  ROBxxxx
        '     &(MM2)=,F9.1,/5X,12HPERIM. (MM)=,F9.1,7X,9HWG(N/MM)=,F10.1,7X,10HAB
        '     &  (MM2)=,F9.1,//5X,28HMAX.BOLT P.[MM]:BOLTING-UP =,F6.1,
        '     $11H;OPERATING=,
        '     $F6.1,15H;API4.1.6.2.9 =,F6.1/5X,'ASSUMED BOLT PITCH = ',F8.2,
        '     $' MM; CORRECTIVE FACTOR API4.1.6.2.9 = ',F6.3)
        '      WRITE(1,1015) TP1,CORR,(TP1+CORR),TP,TP2B,TP2M,CORR,(TP2B+TP2M+   ROB01300
        '     &CORR),TP,TP3B,TP3M,CORR,(TP3B+TP3M+CORR),TP,TP4B,TP3M,CORR,(TP4B+ ROB01310
        '     &TP3M+CORR),TP                                                     
        '1015  FORMAT(5X,34HTUBESHEET THICKNESS       (MM): 1=,F5.1,9X,2H+ ,F5.1,ROB01330
        '     &3H = ,F5.1,4H  < ,F5.1,/37X,2H2= ,F5.1,3H + ,F5.1,3H + ,F5.1,     ROB01340
        '     &3H = ,F5.1,4H  < ,F5.1,/37X,2H3= ,F5.1,3H + ,F5.1,3H + ,F5.1,     ROB01350
        '     &3H = ,F5.1,4H  < ,F5.1,/37X,2H4= ,F5.1,3H + ,F5.1,3H + ,F5.1,     ROB01360
        '     &3H = ,F5.1,4H  < ,F5.1)                                           ROB01370
        '      WRITE(1,1016)TT1,CORR,(TT1+CORR),TT,TT2B,TT2M,CORR,(TT2B+TT2M+    ROB01380
        '     &CORR),TT,TT3B,TT2M,CORR,(TT3B+TT2M+CORR),TT                       ROB01390
        '1016  FORMAT(/5X,34HTOP & BTM & END PLATE THK.(MM): 1=,F5.1,9X,2H+ ,F5.1ROB01400
        '     &,3H = ,F5.1,4H  < ,F5.1,/37X,2H2= ,F5.1,3H + ,F5.1,3H + ,F5.1,    ROB01410
        '     &3H = ,F5.1,4H  < ,F5.1,/37X,2H3= ,F5.1,3H + ,F5.1,3H + ,F5.1,     ROB01420
        '     &3H = ,F5.1,4H  < ,F5.1)                                           ROB01430
        '      WRITE(1,1017) TF1,TFTF,TF2,TFTF                                   ROB01440
        '1017  FORMAT(/5X,34HFLANGE  THICKNESS         (MM): 1=,F5.1,2X,1H<,2X,  ROB01450
        '     &F5.1,3X,20HMIN. AFTER MACHINING,                                  ROB01460
        '     &/37X,2H2=,F5.1,5H  <  ,F5.1,3X,20HMIN. AFTER MACHINING)           ROB01470
        '      IF (PN.EQ.0.) GOTO 114                                            ROB01480
        '      WRITE(1,1018) TSETTO                                              ROB01490
        '1018  FORMAT (/5X,34HPARTITION PLATE THICKNESS (MM): 1=,33X,F5.1)       ROB01500
        ' 114  WRITE (1,1019) TC1,TOLLAV,(TC1+TOLLAV),TC,TC2,TOLLAV,(TC2+TOLLAV),ROB01510
        '     &TC
        '      IF(RISLAR.LT.0.)WRITE(1,1119)TC2P,-RISLAR,TOLLAV,TC2PP,TC
        '1019  FORMAT(/5X,34HCOVER PLATE THK. (ASME)   (MM): 1=,F5.1,9X,2H+ ,F5.1ROB01530
        '     &,3H = ,F5.1,2X,2H< ,F5.1,                                         ROB01540
        '     &/22X,6H(ASME),3X,8H(MM): 2=,F5.1,9X,2H+ ,F5.1,3H = ,F5.1,4H  < ,  ROB01550
        '     &F5.1)
        '1119  FORMAT(22X,6H(ASME),3X,8H(MM):2'=,F5.1,3H + ,F5.1,3H + ,F5.1,     ROB01560
        '     1 3H = ,F5.1,4H  < ,F5.1)
        '      WRITE (1,1020) BENDMG,TC3,TOLLAV,(TC3+TOLLAV),TC,TC4,TOLLAV,
        '     &(TC4+TOLLAV),TC                                              
        '1020  FORMAT(/5X,'MG=MOMENT ACTING ON COVER PLATE',5X,8H    (N)=,
        '     3F8.1,//5X,34HCOVER PLATE THK. (CUSTOM) (MM): 3=,
        '     2F5.1,9X,2H+ ,F5.1,3H = ,F5.1,2X,2H< ,F5.1,/22X,9H(CUSTOM) ,
        '     1  8H(MM): 4=,F5.1,9X,2H+ ,F5.1,3H = ,F5.1,4H  < ,F5.1)         
        '        CLOSE(1)
        '        Return
        '101   WRITE(DOMANDA,'(9HErrore n°,I5,21H durante apertura di ,2A1,
        '     XA40,'' (ROBFIN)'',A1)')IERR,CHAR(13),CHAR(10),'TEXT'//PREVENT
        '     x     ,CHAR(0)
        '      X=MessageBoxEx(NULL,DOMANDA,'ISA'C,MB_OK+
        '     1	 MB_ICONSTOP,LANG_ITALIAN)
        '        Return
        '102   WRITE(DOMANDA,'(9HErrore n°,I5,23H durante la lettura di ,2A1,
        '     XA40,'' (ROBFIN)'',A1)')IERR,CHAR(13),CHAR(10),'TEXT'//PREVENT
        '     x     ,CHAR(0)
        '      X=MessageBoxEx(NULL,DOMANDA,'ISA'C,MB_OK+
        '     1	 MB_ICONSTOP,LANG_ITALIAN)
        '        Return
    End Sub
End Module
