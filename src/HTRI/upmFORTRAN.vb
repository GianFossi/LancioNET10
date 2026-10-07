Option Explicit On
Option Strict Off
Imports System.Math
Module upmFORTRAN
    Sub UPMITM(ByVal MODE As Integer, ByVal ICASSA As Integer)
        Dim IUN, LBL As Integer
        Dim ifl As Integer
        'C---------------------------------------------------------------------
        ' If (ICASSA = 0) Then GoTo 12344
        If Monitor.Motore.Problem.Extension = ".MEC" Then GoTo 12344
        If (MecData(ICASSA).Logic(0) = 0 Or MODE = 0) Then
            ' READ(7, REC = NRDIN + 1)(IB1(J), J = 1, 128)
            ' IF(LLE(ICKNR(1)(1:1),' ')) THEN
            '   DO 115 I=1,6
            '115       ICKNR(I)='  '
            ' ENDIF
            ' DO 111 I=1,20
            'c      IF(I.LT.6)HEADER(I)='  '
            '  IF(I.LT.11)ITEMNO(I)=IB(I)
            'SRVICE(I) = Ib(I + 12)
            '111:    Continue Do
            '      OPEN(13,RECL=34,FORM='FORMATTED',ACCESS='DIRECT'
            '    $     ,FILE=ARCHD(1:LEN_TRIM(ARCHD))//'\ARCH16.DAT'
            '   $     ,STATUS='OLD',MODE='READ')
            '     READ(13, REC = IBI(51), FMT = 990)(RATING(I), I = 1, 10)
            MecData(ICASSA).Rating = rmHelpStrings.GetString("ARCH16_" + GlobalRoutines.Str2Cifre(CShort(actItem.codRatingFlange)))
            '    CLOSE(13)
            Dati.BANCO(1) = actItem.Banco ' Ib(11)
            'BANCO(2) = Ib(12)
            NumIt = Nrdit '/ 2  ???
            MecData(ICASSA).P = actItem.RDIT(52)
            MecData(ICASSA).T = actItem.RDIT(54)
            MecData(ICASSA).CA = actItem.Corrosione
            MecData(ICASSA).IREV = "00"
        End If
        If (MODE = 0 And ICASSA > 0) Then
            'WRITE(8,REC=ICASSA)BUFFER
            'Return
            Exit Sub
        End If
12344:  Dom(1) = Helpstringa(1252) '"Metrico  (ME)"
        Dom(2) = Helpstringa(1253) ' "British  (BR)"
        Dom(3) = Helpstringa(1254) ' "S.I.     (SI)"
        ' If (MecData(ICASSA).UNIMIS = "BR") Then
        ' IUN = 2
        ' ElseIf (MecData(ICASSA).UNIMIS = "SI") Then
        ' IUN = 3
        ' Else
        ' IUN = 1
        ' End If
        If ICASSA < 2 Then
            IUN = UnitMisu()
            IUN = Monitor.Motore.Quale(3, Helpstringa(1251), Dom, "", IUN) ' "Scelta unità di misura", Dom, "", 3)
            If IUN = 0 Then IUN = 1
            Dim iLing As Integer = Lingua()
            Dom(1) = "Italiano"
            Dom(2) = "Inglese"
            Dom(3) = "Francese"
            iLing = Monitor.Motore.Quale(3, "Lingua del rapporto", Dom, "", iLing) ' "Scelta unità di misura", Dom, "", 3)
            Select Case iLing
                Case 1 : MecData(ICASSA).St21 = "IT"
                Case 2 : MecData(ICASSA).St21 = "IN"
                Case 3 : MecData(ICASSA).St21 = "FR"
            End Select
        Else
            MecData(ICASSA).St21 = MecData(1).St21
            MecData(ICASSA).UNIMIS = MecData(1).UNIMIS
            IUN = UnitMisu()
        End If
        Select Case IUN
            Case 1
                MecData(ICASSA).UNIMIS = "ME"
                kPress = 1
                kTemp = 1 : kTemp32 = 0
                kLength = 1
            Case 2
                MecData(ICASSA).UNIMIS = "BR"
                kPress = GRAV / 100 * PSI
                kTemp = 1.8 : kTemp32 = 32
                kLength = 1 / INC
            Case 3
                MecData(ICASSA).UNIMIS = "SI"
                kPress = GRAV * 10
                kTemp = 1 : kTemp32 = 0
                kLength = 1
        End Select
        ifl = FreeFile()
        FileOpen(ifl, FileMec, OpenMode.Random, , , Len(MecData(ICASSA)))
        FilePut(ifl, MecData(ICASSA), Max(ICASSA, 1))
        FileClose(ifl)
        'INQUIRE(FILE='TEXT'//PREVENT,EXIST=ESIST1)
        '  If (ESIST1) Then
        '     OPEN(IRDR,FILE='TEXT'//PREVENT)
        '     CLOSE(IRDR,STATUS='DELETE')
        '  End If
        ifl = FreeFile()
        FileOpen(ifl, Monitor.Motore.Inizio.DiscoTem & job.Contratto + ".TXT", OpenMode.Output, OpenAccess.Write, OpenShare.LockWrite)
        'OPEN(IRDR,FILE='TEXT'//PREVENT,STATUS='NEW')
        'Write(IRDR, 5001)
        'WRITE(IRDR,990)ITEMNO
        PrintLine(ifl, FormatStringa(5001))
        PrintLine(ifl, MecData(ICASSA).ITEMNO)
        'Write(IRDR, 5002)
        'WRITE(IRDR,990)ICKNR
        PrintLine(ifl, FormatStringa(5002))
        PrintLine(ifl, MecData(ICASSA).ICKNR)
        'Write(IRDR, 5003)
        'WRITE(IRDR,990)IREV
        PrintLine(ifl, FormatStringa(5003))
        PrintLine(ifl, MecData(ICASSA).IREV)
        'Write(IRDR, 5004)
        'WRITE(IRDR,990)SRVICE
        PrintLine(ifl, FormatStringa(5004))
        PrintLine(ifl, MecData(ICASSA).SRVICE)
        Select Case (IUN)
            Case (1) : LBL = 5005
                ' ASSIGN 5005 TO LBL
            Case (2) : LBL = 5015
                ' ASSIGN 5015 TO LBL
            Case (3) : LBL = 5025
                ' ASSIGN 5025 TO LBL
        End Select
        '  Write(IRDR, LBL)
        'WRITE(IRDR,991)P
        PrintLine(ifl, FormatStringa(LBL))
        PrintLine(ifl, String.Format("{0,12:#####0.00000}", MecData(ICASSA).P * kPress))
        Select Case (IUN)
            Case (1) : LBL = 5006
                ' ASSIGN 5006 TO LBL
            Case (2) : LBL = 5016
                ' ASSIGN 5016 TO LBL
            Case (3) : LBL = 5026
                ' ASSIGN 5026 TO LBL
        End Select
        ' Write(IRDR, LBL)
        'WRITE(IRDR,991)T
        PrintLine(ifl, FormatStringa(LBL))
        PrintLine(ifl, String.Format("{0,12:#####0.00000}", MecData(ICASSA).T * kTemp + kTemp32))
        Select Case (IUN)
            Case (1) : LBL = 5007
                '         ASSIGN 5007 TO LBL
            Case (2) : LBL = 5017
                '         ASSIGN 5017 TO LBL
            Case (3) : LBL = 5027
                '         ASSIGN 5027 TO LBL
        End Select
        '     WRITE(IRDR,LBL )                                                  UPM01560
        '    WRITE(IRDR,991)CA
        PrintLine(ifl, FormatStringa(LBL))
        PrintLine(ifl, String.Format("{0,12:#####0.00000}", MecData(ICASSA).CA * kLength))
        'WRITE(IRDR,5008)                                                  UPM01590
        '  WRITE(IRDR,990)HEADER
        PrintLine(ifl, FormatStringa(5008))
        PrintLine(ifl, MecData(ICASSA).HEADER)
        FileClose(ifl)
        '   Return
        '990   FORMAT(20A2)
        '991   FORMAT('*',F12.5)
        '5001  FORMAT(' ITEM                   ')
        '5002  FORMAT(' N° DOC. DI CALCOLO     ')
        '5003  FORMAT(' REVISIONE              ')
        '5004  FORMAT(' SERVIZIO               ')
        '5005  FORMAT(' PRESS PROG. (kg/cm2)   ')
        '5006  FORMAT(' TEMP  PROG. (°C)       ')
        '5007  FORMAT(' CORR.       (mm)       ')
        '5008  FORMAT(' TESTATA                ')
        '5015  FORMAT(' PRESS PROG. (PSI)      ')
        '5016  FORMAT(' TEMP  PROG. (°F)       ')
        '5017  FORMAT(' CORR.       (inch)     ')
        '5025  FORMAT(' PRESS PROG. (kPa)      ')
        '5026  FORMAT(' TEMP  PROG. (°C)       ')
        '5027  FORMAT(' CORR.       (mm)       ')
    End Sub
    Sub UPMPTM(ByVal ICASSA As Integer)
        Dim ifl As Integer = FreeFile()
        FileOpen(ifl, Monitor.Motore.Inizio.DiscoTem & job.Contratto + ".TXT", OpenMode.Input, OpenAccess.Read, OpenShare.LockRead)
        With MecData(ICASSA)
            .ITEMNO = LineInput(ifl)
            .ICKNR = LineInput(ifl)
            .IREV = LineInput(ifl)
            .SRVICE = LineInput(ifl)
            .P = GlobalRoutines.ValVir(LineInput(ifl)) / kPress
            .T = (GlobalRoutines.ValVir(LineInput(ifl)) - ktemp32) / ktemp
            .CA = GlobalRoutines.ValVir(LineInput(ifl)) / kLength
            .HEADER = LineInput(ifl)
        End With
        'c      IF(UNIMIS.EQ.'BR'.AND..NOT.ESIS)THEN
        'c         T = (T - 32.) / 1.8
        '        c(P = P / 14.50377 / 0.980655)
        '        c(CA = CA / 25.4)
        'c      ELSEIF(UNIMIS.EQ.'SI'.AND..NOT.ESIS)THEN
        '        c(P = P / 98.0655)
        'c      END IF
        FileClose(ifl)
        '        Call WRITEBUF(ICASSA)
        '        Return
    End Sub
    Sub UPMALT(ByVal MODE As Integer, ByVal ICASSA As Integer, ByVal ITIPO As Integer)
        Dim ifl, i As Integer
        Dim REALN As Single
        'C----------------------------------------------------------------------
        Dim ic As Integer
        'If ICASSA = 0 Then ic = 1 Else ic = Abs(ICASSA)
        ic = Abs(ICASSA)
        If (ICASSA = 0) Then
            GoTo 12346
        End If
        If (MODE = 2 And ICASSA > 0) Then
            '         OPEN(8,FILE=ARCHW(1:LEN_TRIM(ARCHW))//'\'//MEC,
            '    1    FORM='UNFORMATTED',RECL=1500,IOSTAT=IERR,ERR=998,
            '   1    ACCESS='DIRECT',STATUS='UNKNOWN')
            '      READ(8,REC=ICASSA)BUFFER
            '        CLOSE(8)
            ifl = FreeFile()
            FileOpen(ifl, FileMec, OpenMode.Random, , , Len(MecData(1)))
            FileGet(ifl, MecData(Abs(ICASSA)), Max(Abs(ICASSA), 1))
            FileClose(ifl)
            GoTo 12345
        End If
        With MecData(Abs(ICASSA))
            If (ITIPO > 0) Then .TipTest = CShort(ITIPO)
            If (.ESIS And MODE = 0) Then 'toltop not davanti a esis
                .DO_Renamed = actAltern.DiaTubo(1) * INC ' DT(1, 1) * 25.4
                .SPBWG = actAltern.BWG(1).ToString ' IDT(1, 1)
                .SPTOL = actAltern.TipoBWG(1) ' IDT(2, 1)
                .TSP = actAltern.SpessInch(1) * INC ' DT(2, 1) * 25.4
                'ITYP = "NN"
                'C(SPTUB = DT(6, 1) * 25.4)
                'Call BWGSP(.SPBWG, .ITYP, .SPTUB)
                .SPTUB = objBWG.SpFinale(.SPBWG, .SPTOL)
                '.SPTUB = .SPTUB * 25.4
                .NTUB = actAltern.NumTubiFascio(1) ' IDTI(26, 1)
                .DALETT = actAltern.DiAl(1) * INC ' DT(3, 1) * 25.4
                .ALINCH = actAltern.NumAlettxInch(1) ' DT(4, 1)
                .NROWS = CShort(actAltern.NumFile(1)) ' IDTI(25, 1)
                .NFASCI = actAltern.NumFasciParall ' NBDITI(5)
                .nPassi = CShort(actAltern.NumTotPassi) ' NBDITI(7)
                'c(NBOCIN = NBDITI(8))
                'c(NBOCOT = NBDITI(9))
                .HorPas = actAltern.PassiOrizzontali ' NIBDIT(35)
                .DBocIn = actAltern.DBocchIn ' DG(60)
                .DBocOut = actAltern.DbocchOut ' DG(59)
                .TIPAL = actAltern.codAlett(1) ' IDT(22, 1)
                .LUNGF = actAltern.LunghezzaFascio * 12 * INC ' DG(62) * 304.8
                .Largf = actAltern.LarghezzaFascio * 12 * INC ' DG(63) * 304.8
                If (ICASSA = 1) Then
                    .MATUG = rmHelpStrings.GetString("ARCH14_" + CShort(actItem.codMaterTestate).ToString("000", System.Globalization.CultureInfo.InvariantCulture)).Split(CChar("|"))(0)
                    'OPEN(13,RECL=34,FORM='FORMATTED',ACCESS='DIRECT'
                    '    $     ,FILE=ARCHD(1:LEN_TRIM(ARCHD))//'\ARCH14.DAT'
                    '   $     ,STATUS='OLD',BLOCKSIZE=32,MODE='READ')
                    '             READ(13, REC = IBI(48), FMT = 990)(MATUG(I), I = 1, 9)
                    '            CLOSE(13)
                    .MATTAP = rmHelpStrings.GetString("ARCH15_" + CShort(actItem.codmaterTappi).ToString("000", System.Globalization.CultureInfo.InvariantCulture)).Split(CChar("|"))(0)
                    '   OPEN(13,RECL=18,FORM='FORMATTED',ACCESS='DIRECT'
                    '$     ,FILE=ARCHD(1:LEN_TRIM(ARCHD))//'\ARCH15.DAT'
                    '$     ,STATUS='OLD',BLOCKSIZE=32,MODE='READ')
                    '           READ(13, REC = IBI(49), FMT = 990)(MATTAP(I), I = 1, 8)
                    '    MATTAP(9)='  '
                    '           CLOSE(13)
                    .MATTUB = rmHelpStrings.GetString("ARCH23_" + CShort(actAltern.codMater(1)).ToString("000", System.Globalization.CultureInfo.InvariantCulture)).Split(CChar("|"))(0)
                    'OPEN(13,RECL=34,FORM='FORMATTED',ACCESS='DIRECT'
                    '$     ,FILE=ARCHD(1:LEN_TRIM(ARCHD))//'\ARCH23.DAT'
                    '$     ,STATUS='OLD',MODE='READ')
                    '          READ(13, REC = IDTI(4, 1), FMT = 990)(MATTUB(I), I = 1, 9)
                    '         CLOSE(13)
                    If (Not .ESIS) Then
                        '           DO 111 I=1,9
                        .MATEN = .MATUG
                        .MATTP = .MATUG
                        .MATSE = .MATUG
                        .MATSH = .MATUG
                        .SUG = 12.303
                        For i = 0 To 3 'DO 112 I=1,4
                            .Ammiss(i) = 12.303
                        Next
                        If (.Codice = 3) Then ' !ispesl
                            .EWPS = 0.7
                            .EWC = 0.7
                            .e = 1
                        Else
                            .EWPS = 0.6
                            .EWC = 1
                            .e = 1
                        End If
                    End If
                End If
                If (Not .ESIS) Then
                    'For I = 1 To 16
                    'actAltern.Nfile(I) = 0
                    'If (I <= NPAS) Then NFILEF%(R(I) = DG(I))
                    'Next
                    'NPASF = NPAS
                    'NSF = NS
                    'ITIPOFAS = Tipo
                    Call FILEFUNZ(ICASSA) ', ITIPOFAS, NPASF, NSF, NFILEF)
                    '   DO 114 I=1,16
                    '114       NFILE(I)=NFILEF%R(I)
                    'NPAS = NPASF
                    'NS = NSF
                End If
                GoTo 12345
            End If
        End With
12347:  If (MODE = 0 And ICASSA > 0) Then
            ' OPEN(8,FILE=ARCHW(1:LEN_TRIM(ARCHW))//'\'//MEC
            ' 1   ,FORM='UNFORMATTED',RECL=1500
            '1   ,ACCESS='DIRECT',STATUS='UNKNOWN',BLOCKSIZE=64)
            '   WRITE(8,REC=ICASSA)BUFFER
            ' CLOSE(8)
            Exit Sub
        End If
        'c      IF(APERTO)CLOSE(7)
12346:  'INQUIRE(FILE='TEXT'//PREVENT,EXIST=ESIST1)
        'If (ESIST1) Then
        '  OPEN(IRDR,FILE='TEXT'//PREVENT)
        ' CLOSE(IRDR,STATUS='DELETE')
        ' End If
        'OPEN(IRDR,FILE='TEXT'//PREVENT,STATUS='NEW')
        ifl = FreeFile()
        FileOpen(ifl, Monitor.Motore.Inizio.DiscoTem & job.Contratto + ".TXT", OpenMode.Output, OpenAccess.Write, OpenShare.LockWrite)
        With MecData(ic)
            .TipTest = ITIPO
            '   Write(IRDR, 5001)
            'WRITE(IRDR,992)DO0
            PrintLine(ifl, FormatStringa(5101))
            PrintLine(ifl, String.Format(FormatStringa(992), .DO_Renamed))
            'Write(IRDR, 5002)
            'WRITE(IRDR,992)TSP
            PrintLine(ifl, FormatStringa(5102))
            PrintLine(ifl, String.Format(FormatStringa(992), .TSP))
            If (.PVERT < .TVERT) Then .PVERT = .TVERT
            'Write(IRDR, 50031)
            'WRITE(IRDR,992)PVERT
            PrintLine(ifl, FormatStringa(50031))
            PrintLine(ifl, String.Format(FormatStringa(992), .PVERT))
            'Write(IRDR, 5003)
            'WRITE(IRDR,992)H
            PrintLine(ifl, FormatStringa(5103))
            PrintLine(ifl, String.Format(FormatStringa(992), .H))
            If (.TipTest = 3 Or .TipTest = 4) Then
                'Write(IRDR, 50062)
                'WRITE(IRDR,992)LARGF
                PrintLine(ifl, FormatStringa(50062))
                PrintLine(ifl, String.Format(FormatStringa(992), .Largf))
            End If
            If (MODE < 2) Then
                'C      OPEN(90,FILE='TEX1'//PREVENT,STATUS='UNKNOWN')
                '               C(Write(90, 5080))
                '              C(CLOSE(90))
                If (.MATHOM < 1 Or .MATHOM > 2) Then .MATHOM = 1
                Dim strin1() As String = {"", FormatStringa(5180)}
                Dim Ris1() As Boolean = {False, .MATHOM = 1}
                Monitor.Motore.CheckQuale(1, "ISA", strin1, Ris1, "")
                If Ris1(1) Then .MATHOM = 1 Else .MATHOM = 2
            End If
            If (.MATHOM = 2) Then GoTo 800
            'WRITE(IRDR,5005)                                                  UPM01830
            'Write(IRDR, 994)(MATUG(I), I = 1, 9)
            PrintLine(ifl, FormatStringa(5105))
            PrintLine(ifl, String.Format(FormatStringa(994), .MATUG))
            'WRITE(IRDR,5006)                                                  UPM01860
            'WRITE(IRDR,992)SUG
            PrintLine(ifl, FormatStringa(5106))
            PrintLine(ifl, String.Format(FormatStringa(992), .SUG))
            If (.TipTest = 3 Or .TipTest = 4) Then
                'Write(IRDR, 50061)
                'WRITE(IRDR,992)SJ0(4)
                PrintLine(ifl, FormatStringa(50061))
                PrintLine(ifl, String.Format(FormatStringa(992), .Ammiss0(3)))
            End If
            'C      IF(J.EQ.2.)GO TO 830
            GoTo 805
800:        If (.TipTest = 3 Or .TipTest = 4) Then
                'WRITE(IRDR,50071)                                                  UPM01910
                'WRITE(IRDR,994)MATSH
                PrintLine(ifl, FormatStringa(50071))
                PrintLine(ifl, String.Format(FormatStringa(994), .MATSH))
                'Write(IRDR, 50081)
                'WRITE(IRDR,994)MATTP
                PrintLine(ifl, FormatStringa(50081))
                PrintLine(ifl, String.Format(FormatStringa(994), .MATTP))
                'Write(IRDR, 50091)
                'WRITE(IRDR,994)MATEN
                PrintLine(ifl, FormatStringa(50091))
                PrintLine(ifl, String.Format(FormatStringa(994), .MATEN))
                'WRITE(IRDR,50101)                                                  UPM02000
                'WRITE(IRDR,992)S(1)
                PrintLine(ifl, FormatStringa(50101))
                PrintLine(ifl, String.Format(FormatStringa(994), .Ammiss(0)))
                'WRITE(IRDR,50111)                                                  UPM02030
                'WRITE(IRDR,992)S(2)
                PrintLine(ifl, FormatStringa(50111))
                PrintLine(ifl, String.Format(FormatStringa(992), .Ammiss(1)))
                'WRITE(IRDR,50121)                                                  UPM02060
                'WRITE(IRDR,992)S(3)
                PrintLine(ifl, FormatStringa(50121))
                PrintLine(ifl, String.Format(FormatStringa(992), .Ammiss(2)))
                'WRITE(IRDR,50102)                                                  UPM02000
                'WRITE(IRDR,992)SJ0(1)
                PrintLine(ifl, FormatStringa(50102))
                PrintLine(ifl, String.Format(FormatStringa(992), .Ammiss0(0)))
                'WRITE(IRDR,50112)                                                  UPM02030
                ' WRITE(IRDR,992)SJ0(2)
                PrintLine(ifl, FormatStringa(50112))
                PrintLine(ifl, String.Format(FormatStringa(992), .Ammiss0(1)))
                ' WRITE(IRDR,50122)                                                  UPM02060
                '    WRITE(IRDR,992)SJ0(3)
                PrintLine(ifl, FormatStringa(50122))
                PrintLine(ifl, String.Format(FormatStringa(992), .Ammiss0(2)))
            Else
                ' WRITE(IRDR,5007)                                                  UPM01910
                'WRITE(IRDR,994)MATSH
                PrintLine(ifl, FormatStringa(5107))
                PrintLine(ifl, String.Format(FormatStringa(994), .MATSH))
                'WRITE(IRDR,5008)                                                  UPM01940
                'WRITE(IRDR,994)MATTP
                PrintLine(ifl, FormatStringa(5108))
                PrintLine(ifl, String.Format(FormatStringa(994), .MATTP))
                'WRITE(IRDR,5009)                                                  UPM01970
                'WRITE(IRDR,994)MATEN
                PrintLine(ifl, FormatStringa(5109))
                PrintLine(ifl, String.Format(FormatStringa(994), .MATEN))
                'WRITE(IRDR,5010)                                                  UPM02000
                'WRITE(IRDR,992)S(1)
                PrintLine(ifl, FormatStringa(5110))
                PrintLine(ifl, String.Format(FormatStringa(992), .Ammiss(0)))
                'WRITE(IRDR,5011)                                                  UPM02030
                'WRITE(IRDR,992)S(2)
                PrintLine(ifl, FormatStringa(5111))
                PrintLine(ifl, String.Format(FormatStringa(992), .Ammiss(1)))
                'WRITE(IRDR,5012)                                                  UPM02060
                'WRITE(IRDR,992)S(3)
                PrintLine(ifl, FormatStringa(5112))
                PrintLine(ifl, String.Format(FormatStringa(992), .Ammiss(2)))
            End If
            'C      IF(J.EQ.2.)GO TO 830
805:        If Monitor.Motore.Problem.Extension = ".MEC" Then
                'Write(IRDR, 5112)
                'WRITE(IRDR,993)NS
                PrintLine(ifl, FormatStringa(5212))
                PrintLine(ifl, String.Format(FormatStringa(993), .NS))
            Else
                'WRITE(IRDR,5013)                                                  UPM02100
                'WRITE(IRDR,992)XX
                PrintLine(ifl, FormatStringa(5113))
                PrintLine(ifl, String.Format(FormatStringa(992), .xx))
            End If
            'C      IF(J.EQ.3.AND.NS.EQ.0)GO TO 830                                   UPM02130
            'C      IF(NS.EQ.0.)GO TO 815                                             UPM02140
            If (.MATHOM = 1) Then GoTo 810
            If (Not (.TipTest = 3 Or .TipTest = 4)) Then
                '14    WRITE(IRDR,5014)                                                  UPM02160
                '     WRITE(IRDR,994)MATSE
                PrintLine(ifl, FormatStringa(5114))
                PrintLine(ifl, String.Format(FormatStringa(994), .MATSE))
                'WRITE(IRDR,5015)                                                  UPM02190
                'WRITE(IRDR,992)S(4)
                PrintLine(ifl, FormatStringa(5115))
                PrintLine(ifl, String.Format(FormatStringa(992), .Ammiss(3)))
            End If
            'C      IF(J.EQ.4)GO TO 830                                               UPM02220
            GoTo 811
810:        '   DO 2 I=1,9
            .MATSE = .MATUG
            .Ammiss(3) = .SUG
811:        If (Not (.TipTest = 3 Or .TipTest = 4)) Then
                'WRITE(IRDR,5016)                                                  UPM02280
                'WRITE(IRDR,992)EWPS
                PrintLine(ifl, FormatStringa(5116))
                PrintLine(ifl, String.Format(FormatStringa(992), .EWPS))
                'C      IF(J.EQ.3)GO TO 818                                               UPM02310
                'C      IF(J.EQ.5)GO TO 830                                               UPM02320
                'Write(IRDR, 5019)
                'WRITE(IRDR,992)PASSORINF
                PrintLine(ifl, FormatStringa(5119))
                PrintLine(ifl, String.Format(FormatStringa(992), .PassoRinf))
                If (.BucoRinf = 0) Then
                    'INEAR = 26
                    'JNEAR = 1
                    .BucoRinf = ReadLib(26, 1)
                End If
                'Write(IRDR, 5020)
                'WRITE(IRDR,992)BUCORINF
                PrintLine(ifl, FormatStringa(5120))
                PrintLine(ifl, String.Format(FormatStringa(992), .BucoRinf))
            End If
815:        '   WRITE(IRDR,5017)                                                  UPM02350
            ' WRITE(IRDR,992)EWC
            PrintLine(ifl, FormatStringa(5117))
            PrintLine(ifl, String.Format(FormatStringa(992), .EWC))
            If (Not (.TipTest = 3 Or .TipTest = 4)) Then
                'WRITE(IRDR,5018)                                                  UPM02370
                'WRITE(IRDR,992)E
                PrintLine(ifl, FormatStringa(5118))
                PrintLine(ifl, String.Format(FormatStringa(992), .e))
            End If
            '            CLOSE(IRDR)
            '           Return
            '998   WRITE(DOMANDA,'(9HErrore n°,I5,21H durante apertura di ,
            '     XA40,A1)')IERR,ARCHW(1:LEN_TRIM(ARCHW))//'\'//MEC,CHAR(0)
            '      x = MessageBoxEx(NULL,DOMANDA,'ISA'C,MB_OK+
            '     1	       MB_ICONSTOP,LANG_ITALIAN)
            '            Return
            FileClose(ifl)
            Exit Sub
        End With
12345:  With MecData(Abs(ICASSA))
            .NFMAX = 0
            REALN = 0
            For I = 1 To .NS + 1
                REALN = REALN + Abs(.Nfile(I))
                If (.Nfile(I) > .NFMAX) Then .NFMAX = .Nfile(I)
            Next
            .NROWS = CShort(REALN)
            'C!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            If (.H < 0) Then .H = 100
            .TVERT = CSng(.TSP * Sqrt(3) / 2)
            If (Abs(.TVERT - 55) < 0.1) Then .TVERT = 55
            For I = 1 To 16
                If (.Passo(I) < .TVERT) Then .Passo(I) = .TVERT
            Next
            'C!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        End With
        GoTo 12347
        '990   FORMAT(20A2)
        '991   FORMAT (F12.5)
        '992   FORMAT('*',F12.3)
        '993:    Format(I3)
        '994   FORMAT(9A2,'.')
        '5001  FORMAT(' DIAMETRO TUBI     (MM) ')
        '5002  FORMAT(' PASSO TUBI ORIZZ. (MM) ')
        '50031 FORMAT(' PASSO TUBI VERT.  (MM) ')
        '5003  FORMAT(' LARGHEZZA TESTATA (MM) ')
        'C5004  FORMAT(' ALTEZZA   TESTATA (MM) ')
        '5005  FORMAT(' SIGLA MATERIALE        ')
        '5006  FORMAT(' AMMISS.(TEMP.) MAT. (KG/MM2) ')
        '50061 FORMAT(' AMMISS.(AMB. ) MAT. (KG/MM2) ')
        '50062 FORMAT(' LUNGH.INT.CASSA   (MM) ')
        '5007  FORMAT(' SIGLA MAT P. TUB/TAPPI ')
        '50071 FORMAT(' SIGLA MAT PIASTRA TAP. ')
        '5008  FORMAT(' SIGLA MAT TOP / BTM.   ')
        '5009  FORMAT(' SIGLA MATERIALE END    ')
        '50081 FORMAT(' SIGLA MAT TOP/BTM/END  ')
        '50091 FORMAT(' SIGLA MATERIALE COVER  ')
        '5010  FORMAT(' AMMISS.(TEMP.)P. TUB/TAPPI(KG/MM2) ')
        '5011  FORMAT(' AMMISS.(TEMP.) TOP/BTM    (KG/MM2) ')
        '5012  FORMAT(' AMMISS.(TEMP.) END        (KG/MM2) ')
        '50101 FORMAT(' AMMISS.(TEMP.) PIASTRA TAP(KG/MM2) ')
        '50111 FORMAT(' AMMISS.(TEMP.) TOP/BTM/END(KG/MM2) ')
        '50121 FORMAT(' AMMISS.(TEMP.) COPERCHIO  (KG/MM2) ')
        '50102 FORMAT(' AMMISS.(AMB. ) PIASTRA TAP(KG/MM2) ')
        '50112 FORMAT(' AMMISS.(AMB. ) TOP/BTM/END(KG/MM2) ')
        '50122 FORMAT(' AMMISS.(AMB. ) COPERCHIO  (KG/MM2) ')
        '5112  FORMAT(' NUMERO SETTI   ')
        '5013  FORMAT(' DISTANZA X     ')
        '5014  FORMAT(' SIGLA MATER SETTI      ')
        '5015  FORMAT(' AMMISS.( TEMP.) SETTI     (KGMM2) ')
        '5016  FORMAT(' EFFIC SALD SETTI       ')
        '5017  FORMAT(' EFFIC SALD TOP-BTM     ')
        '5018  FORMAT(' EFFIC SALD     END     ')
        '5019  FORMAT(' PASSO FORI (0=NO FORI) ')
        '5020  FORMAT(' LATO DEI FORI          ')
        '5080  FORMAT(' La testata e'' costituita da pezzi| di materiale omogeneo
        '     1?|'/'Si'/'No')
    End Sub
    Sub FILEFUNZ(ByVal ICASSA As Integer) ', ByVal ITIPO, ByVal NPASF, ByVal NSF, ByVal NFILEF)
        Dim REALN As Single
        Dim i As Integer
        Dim IC As Integer
        If ICASSA < 0 Then IC = 0 Else IC = ICASSA
        With MecData(IC)
            If (.PassFraz = -1) Then
                'For I = 1 To 16
                '11144:          NFILEF%(R(I) = NFILE(I))
                'Next
                Exit Sub
            End If
            Select Case .Tipo
                Case (0)
                    '                C() ' due casse uguali,passi 1
                Case (1)
                    '               C() '  A sing B sing
                    Select Case Abs(ICASSA)
                        Case (1)
                            For i = 2 To .nPassi Step 2
                                '114              NFILEF%R(I/2+1)=NFILEF%R(I)+NFILEF%R(I+1)
                                .Nfile(i \ 2 + 1) = .Nfile(i) + .Nfile(i + 1)
                            Next
                            REALN = CSng((.nPassi + 2) / 2)
                        Case (2)
                            For i = 1 To .nPassi Step 2
                                '115              NFILEF%R(I/2+1)=NFILEF%R(I)+NFILEF%R(I+1)
                                .Nfile(i \ 2 + 1) = .Nfile(i) + .Nfile(i + 1)
                            Next
                            REALN = CSng((.nPassi + 1) / 2)
                    End Select
                    For i = CInt(REALN) + 1 To 16
                        'DO 1114 I=INT(REALN)+1,16
                        '1114:                   NFILEF%(R(I) = 0)
                        .Nfile(i) = 0
                    Next
                Case (3)
                    '                    C() '  A sing B split
                    Select Case (Abs(ICASSA))
                        Case (1)
                            For i = 2 To .nPassi Step 2
                                '116              NFILEF%R(I/2+1)=NFILEF%R(I)+NFILEF%R(I+1)
                                .Nfile(i \ 2 + 1) = .Nfile(i) + .Nfile(i + 1)
                            Next
                            REALN = CSng(.nPassi / 2)
                            For i = CInt(REALN) + 2 To 16
                                '  DO 1116 I=INT(REALN)+2,16
                                '1116:                           NFILEF%(R(I) = 0)
                                .Nfile(i) = 0
                            Next
                        Case (2)
                            '                            c(NFILEF(2 * NSF + 2) = 0)
                            For i = 1 To .NS + 1 Step 2
                                'DO 117 I=1,NSF+1,2
                                '117              NFILEF%R(I/2+1)=NFILEF%R(I)+NFILEF%R(I+1)
                                .Nfile(i \ 2 + 1) = .Nfile(i) + .Nfile(i + 1)
                            Next
                            REALN = CSng((2 * .NS + 1) / 2)
                            'NDUM = 2 * Int(REALN)
                            For i = 2 * CInt(REALN) + 2 To 16
                                '1117:                           NFILEF%(R(I) = 0)
                                .Nfile(i) = 0
                            Next
                        Case (3)
                            Call RECNSF(ICASSA, .NS)
                            For i = 2 * .NS + 3 To .nPassi Step 2
                                '118              NFILEF%R((I-2*NSF-2)/2+1)=NFILEF%R(I)+NFILEF%R(I+1)
                                .Nfile((i - 2 * .NS - 2) \ 2 + 1) = .Nfile(i) + .Nfile(i + 1)
                            Next
                            'REALN = .nPassi / 2
                            'NDUM = 2 * Int(REALN)
                            REALN = CSng((2 * CInt(.nPassi / 2) - 2 * .NS - 2) / 2)
                            For i = CInt(REALN) + 2 To 16
                                '1118:                           NFILEF%(R(I) = 0)
                                .Nfile(i) = 0
                            Next
                    End Select
                Case (2)
                    '                   C() '  A split B sing
                    Select Case (Abs(ICASSA))
                        Case (1)
                            ' NFILEF%(R(2 * NSF + 2) = 0)
                            .Nfile(2 * .NS + 2) = 0
                            For i = 2 To 2 * .NS + 1 Step 2
                                '119              NFILEF%R(I/2+1)=NFILEF%R(I)+NFILEF%R(I+1)
                                .Nfile(i \ 2 + 1) = .Nfile(i) + .Nfile(i + 1)
                            Next
                            REALN = CSng((2 * .NS + 1) / 2)
                            'NDUM = 2 * Int(REALN)
                            For i = 2 * CInt(REALN) + 2 To 16
                                '1119:                           NFILEF%(R(I) = 0)
                                .Nfile(i) = 0
                            Next
                        Case (2)
                            Call RECNSF(ICASSA, .NS)
                            For i = 2 * .NS + 2 To .nPassi Step 2
                                .Nfile((i - 2 * .NS - 1) \ 2 + 1) = .Nfile(i) + .Nfile(i + 1)
                            Next
                            'REALN = NPASF / 2
                            'NDUM = 2 * Int(REALN)
                            REALN = CSng((2 * CInt(.nPassi / 2) - 2 * .NS - 1) / 2)
                            For i = CInt(REALN) + 2 To 16
                                .Nfile(i) = 0
                            Next
                        Case (3)
                            For i = 1 To .nPassi Step 2
                                '121              NFILEF%R(I/2+1)=NFILEF%R(I)+NFILEF%R(I+1)
                                .Nfile(i \ 2 + 1) = .Nfile(i) + .Nfile(i + 1)
                            Next
                            REALN = CSng(.nPassi / 2)
                            For i = CInt(REALN) + 2 To 16
                                .Nfile(i) = 0
                            Next
                    End Select
                Case (4)
                    '                    C() '  A split B split
                    Select Case (Abs(ICASSA))
                        Case (1)
                            .Nfile(2 * .NS + 2) = 0
                            For i = 2 To 2 * .NS + 1 Step 2
                                '122              NFILEF%R(I/2+1)=NFILEF%R(I)+NFILEF%R(I+1)
                                .Nfile(i \ 2 + 1) = .Nfile(i) + .Nfile(i + 1)
                            Next
                            REALN = CSng((2 * .NS + 1) / 2)
                            'NDUM = 2 * Int(REALN)
                            For i = 2 * CInt(REALN) + 2 To 16
                                .Nfile(i) = 0
                            Next
                        Case (2)
                            Call RECNSF(ICASSA, .NS)
                            For i = 2 * .NS + 2 To .nPassi Step 2
                                .Nfile(CInt((i - 2 * .NS - 1) / 2 + 1)) = .Nfile(i) + .Nfile(i + 1)
                            Next
                            ' REALN = .nPassi / 2
                            'NDUM = 2 * Int(REALN)
                            REALN = CSng((2 * CInt(.nPassi / 2) - 2 * .NS - 1) / 2)
                            For i = CInt(REALN) + 2 To 16
                                .Nfile(i) = 0
                            Next
                        Case (3)
                            '                            c(NFILEF(2 * NSF + 2) = 0)
                            For i = 1 To 2 * .NS + 1 Step 2
                                .Nfile(i \ 2 + 1) = .Nfile(i) + .Nfile(i + 1)
                            Next
                            REALN = CSng((2 * .NS + 1) / 2)
                            'NDUM = 2 * Int(REALN)
                            For i = 2 * CInt(REALN) + 2 To 16
                                .Nfile(i) = 0
                            Next
                        Case (4)
                            Call RECNSF(ICASSA, .NS)
                            For i = 2 * .NS + 3 To .nPassi Step 2
                                .Nfile(CInt((i - 2 * .NS - 2) / 2 + 1)) = .Nfile(i) + .Nfile(i + 1)
                            Next
                            'REALN = NPASF / 2
                            'NDUM = 2 * Int(REALN)
                            REALN = CSng((2 * CInt(.nPassi / 2) - 2 * .NS - 2) / 2)
                            For i = CInt(REALN) + 2 To 16
                                .Nfile(i) = 0
                            Next
                    End Select
            End Select
        End With
    End Sub
    Sub RECNSF(ByVal ICASSA As Integer, ByVal NSF As Integer)
        '     OPEN(8,FILE=ARCHW(1:LEN_TRIM(ARCHW))//'\'//MEC
        ' 1   ,FORM='UNFORMATTED',RECL=1500
        '1   ,ACCESS='DIRECT',STATUS='UNKNOWN',BLOCKSIZE=64)
        ' IF (ICASSA.GT.0) WRITE(8,REC=ICASSA)BUFFER
        'READ(8,REC=IABS(ICASSA)-1)BUFFER
        'NSF = NSFUNZ
        ' READ(8,REC=IABS(ICASSA))BUFFER
        'CLOSE(8)
        MecData(Abs(ICASSA) - 1).NS = MecData(Abs(ICASSA) - 1).NsFunz
        '        Return
    End Sub
    Sub UPMPLT(ByVal ICASSA As Integer)
        Dim ifl As Integer = FreeFile()
        FileOpen(ifl, Monitor.Motore.Inizio.DiscoTem & job.Contratto + ".TXT", OpenMode.Input, OpenAccess.Read, OpenShare.LockRead)
        With MecData(ICASSA)
            .DO_Renamed = GlobalRoutines.ValVir(LineInput(ifl))
            .TSP = GlobalRoutines.ValVir(LineInput(ifl))
            .PVERT = GlobalRoutines.ValVir(LineInput(ifl))
            .H = GlobalRoutines.ValVir(LineInput(ifl))
            If (.TipTest = 3 Or .TipTest = 4) Then .Largf = GlobalRoutines.ValVir(LineInput(ifl))
            If (.MATHOM = 2) Then GoTo 800
            .MATUG = LineInput(ifl)
            .SUG = GlobalRoutines.ValVir(LineInput(ifl))
            If (.TipTest = 3 Or .TipTest = 4) Then .Ammiss0(3) = GlobalRoutines.ValVir(LineInput(ifl))
            GoTo 805
800:        .MATSH = LineInput(ifl)
            .MATTP = LineInput(ifl)
            .MATEN = LineInput(ifl)
            .Ammiss(0) = GlobalRoutines.ValVir(LineInput(ifl))
            .Ammiss(1) = GlobalRoutines.ValVir(LineInput(ifl))
            .Ammiss(2) = GlobalRoutines.ValVir(LineInput(ifl))
            If (.TipTest = 3 Or .TipTest = 4) Then
                .Ammiss0(0) = GlobalRoutines.ValVir(LineInput(ifl))
                .Ammiss0(1) = GlobalRoutines.ValVir(LineInput(ifl))
                .Ammiss0(2) = GlobalRoutines.ValVir(LineInput(ifl))
            End If
805:        '      NS1 = NS
            If Monitor.Motore.Problem.Extension = ".MEC" Then
                .NS = GlobalRoutines.ValVir(LineInput(ifl))
            Else
                .xx = GlobalRoutines.ValVir(LineInput(ifl))
            End If
            'C      IF(J.EQ.3.AND.NS.EQ.0)GO TO 830                            
            'C      IF(NS.EQ.0.)GO TO 815                                    
            If (.MATHOM = 1) Then GoTo 810
            If (Not (.TipTest = 3 Or .TipTest = 4)) Then
                .MATSE = LineInput(ifl)
                .Ammiss(3) = GlobalRoutines.ValVir(LineInput(ifl))
            End If
            'C      IF(J.EQ.4)GO TO 830                                      
            GoTo 811
810:        '  DO 2 I=1,9                                                 
            .MATSE = .MATUG
            .Ammiss(3) = .SUG
811:        If (Not (.TipTest = 3 Or .TipTest = 4)) Then
                .EWPS = GlobalRoutines.ValVir(LineInput(ifl))
                .PassoRinf = GlobalRoutines.ValVir(LineInput(ifl))
                .BucoRinf = GlobalRoutines.ValVir(LineInput(ifl))
                If (.PassoRinf > 0) Then
                    .StiffEff = (.PassoRinf - .BucoRinf) / .PassoRinf
                Else
                    .StiffEff = 1
                End If
            End If
815:        .EWC = GlobalRoutines.ValVir(LineInput(ifl))
            If (Not (.TipTest = 3 Or .TipTest = 4)) Then .e = GlobalRoutines.ValVir(LineInput(ifl))
            FileClose(ifl)
            'Call WRITEBUF(ICASSA)
        End With
        '990   FORMAT(20A2)
        '991   FORMAT (F12.5)
        '992   FORMAT (F12.3)
        '993:    Format(I3)
    End Sub
    Sub SETGET(ByVal ICASSA As Integer, ByVal ITIPO As Integer)
        Dim I, ICSS, ifl As Integer
        With MecData(ICASSA)
            If (ITIPO > 0) Then .Codice = ITIPO
            ifl = FreeFile()
            FileOpen(ifl, Monitor.Motore.Inizio.DiscoTem & job.Contratto + ".TXT", OpenMode.Output, OpenAccess.Write, OpenShare.LockWrite)
            If (ICASSA = 0 And .TipTest <> 3 And .TipTest <> 4) Then GoTo 1444
            '    C(Write(IRDR, 5012))
            'C      WRITE(IRDR,992)XX
            For I = 1 To .NS + 1
                'WRITE(IRDR,5001)I
                'WRITE(IRDR,994)NFILE(I)
                PrintLine(ifl, String.Format(FormatStringa(5201), I))
                PrintLine(ifl, String.Format(FormatStringa(995), .Nfile(I)))
            Next
            'C!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            .NFMAX = 0
            .HX4 = 0
            ICSS = Abs(ICASSA)
            Call AGGVUOTO(ICSS, False)
            Call ARROTONDA(ICSS)
            For I = 1 To .NS + 1
                '      WRITE(IRDR,5011)I
                '     WRITE(IRDR,992)HX5(I)
                PrintLine(ifl, String.Format(FormatStringa(5207), I))
                PrintLine(ifl, String.Format(FormatStringa(992), .HX5(I)))
                If (Abs(.Nfile(I)) > .NFMAX) Then .NFMAX = Abs(.Nfile(I))
                If (.HX5(I) > .HX4) Then .HX4 = .HX5(I)
            Next
            If (.HX4 = 0) Then .HX4 = .HX3
1444:       'Write(IRDR, 5006)
            'WRITE(IRDR,992)HX3
            PrintLine(ifl, FormatStringa(5206))
            PrintLine(ifl, String.Format(FormatStringa(992), .HX3))
            If (.TipTest <> 3 And .TipTest <> 4) Then
                If (.Codice <> 3) Then '!NON ISPESL
                    'Write(IRDR, 5004)
                    'WRITE(IRDR,992)HX4
                    PrintLine(ifl, FormatStringa(5204))
                    PrintLine(ifl, String.Format(FormatStringa(992), .HX4))
                    '         Write(IRDR, 5005)
                    'WRITE(IRDR,992)HE
                    PrintLine(ifl, FormatStringa(5205))
                    PrintLine(ifl, String.Format(FormatStringa(992), .HE))
                End If
            End If
            FileClose(ifl)
        End With
        '992   FORMAT('*',F12.3)
        '993:    Format(I3)
        '994   FORMAT('*',F9.5)
        'c995   FORMAT('*',F4.1)
        '5001  FORMAT(' N° FILE CAMERA ',I2)
        '5004  FORMAT(' MAX SPAN VERT. PIASTRA TUB/TAPPI (MM) ')
        '5005  FORMAT(' MAX SPAN VERT END (MM) ')
        '5006  FORMAT(' ALTEZZA   TESTATA (MM) ')
        '5011  FORMAT(' ALTEZZA CAMERA ',I2)
    End Sub
    Sub SETPUT(ByVal ICASSA As Integer)
        Dim ifl, i As Integer
        'OPEN(IRDR,FILE='TEXT'//PREVENT,STATUS='OLD',ERR=110)
        ifl = FreeFile()
        FileOpen(ifl, Monitor.Motore.Inizio.DiscoTem & job.Contratto + ".TXT", OpenMode.Input, OpenAccess.Read, OpenShare.LockRead)
        With MecData(ICASSA)
            If (ICASSA = 0 And .TipTest <> 3 And .TipTest <> 4) Then GoTo 1444
            'c      IF(NS.EQ.0.)GOTO 818
            .NFMAX = 0
            'c      READ(IRDR,992)XX
            For i = 1 To .NS + 1
                .Nfile(i) = GlobalRoutines.ValVir(LineInput(ifl))
                If (Abs(.Nfile(i)) > .NFMAX) Then .NFMAX = Abs(.Nfile(i))
            Next
818:        For i = 1 To .NS + 1
                .HX5(i) = GlobalRoutines.ValVir(LineInput(ifl))
            Next
            .HX3 = GlobalRoutines.ValVir(LineInput(ifl))
1444:       If (.TipTest <> 3 And .TipTest <> 4 And .Codice <> 3) Then
                .HX4 = GlobalRoutines.ValVir(LineInput(ifl))
                .HE = GlobalRoutines.ValVir(LineInput(ifl))
            End If
            FileClose(ifl)
            '  .ESIS = True '????????????????????
            '          Call WRITEBUF(ICASSA)
        End With
        'Return
        '110  WRITE(DOMANDA,921)CHAR(13),CHAR(10),'TEXT'//PREVENT,CHAR(0)
        '     x = MessageBoxEx(NULL,DOMANDA,'ISA'C,MB_OK+
        '    1	       MB_ICONSTOP,LANG_ITALIAN)
        '       Return
        '921	FORMAT('Errore durante l''apertura del file',2A1,A40,A1)
        '992   FORMAT(F14.4)
        '993:    Format(I3)
        'C994   FORMAT (F9.5)
        'c995 FORMAT(F4.1)
    End Sub
    Sub AGGVUOTO(ByVal ICASSA As Integer, ByVal LOGIC As Boolean)
        Dim REALN As Single
        Dim NFILSOPRA As Integer
        Dim I, NUMFIL, J, NUMPASS As Integer
        Dim ALTZ, PACCANTO, A, BLOC, CC, HMIN As Single
        With MecData(ICASSA)
            .HX3 = 0
            .HX4 = 0
            If .Gap = 0 Then .Gap = ReadLib(24, 1)
            If .TVERT = 0 Then .TVERT = .TSP * Sqrt(3) / 2
            Call FILESOPRA(ICASSA, NFILSOPRA)
            For I = 1 To .NS + 1
103:            .VUOTO(I) = 0
                REALN = Abs(.Nfile(I))
                NUMFIL = CInt(REALN)
                ALTZ = 0
                For J = 1 To NUMFIL - 1
                    ALTZ += .Passo(J + NFILSOPRA)
                Next J
                NUMPASS = NUMFIL + NFILSOPRA
                PACCANTO = .Pacc(NUMPASS)
                If (PACCANTO = 0) Then PACCANTO = .TVERT
                'c      IF((TVERT-T3)/2..LT.GAP.AND.I.LT.NS+1)THEN
                If (I < .NS + 1) Then
                    A = 2 * (.Gap - (.TVERT - .T3) / 2)
                    BLOC = PACCANTO - .TVERT
                    CC = .PVERT - .TVERT
                    If (A > 0) Then .VUOTO(I) = A
                    If (A < BLOC And BLOC > 0) Then .VUOTO(I) = BLOC
                    If (ICASSA > 0 And .VUOTO(I) <> BLOC) Then
                        'WRITE(DOMANDA,5080) I,char(13),A,char(13),BLOC,char(13),char(0)
                        Dim Domanda As String = String.Format(Helpstringa(5280), I, A, BLOC)
                        Dim xMESS As RoutBase1.ChiaviMess = MostraAiuto(5280, _
                                RoutBase1.ChiaviMess.MessQuestion Or _
                                RoutBase1.ChiaviMess.MessHelpButton Or _
                                RoutBase1.ChiaviMess.MessYesNo, Domanda, "ISA")
                        'xMESS=MessageBoxEx(NULL,DOMANDA,'ISA'C,MB_YESNO+
                        '    1	                                 +MB_ICONQUESTION+
                        '   2                                     +MB_SETFOREGROUND,
                        '  3                     LANG_ITALIAN)
                        If (xMESS = RoutBase1.ChiaviMess.MessSi) Then .VUOTO(I) = A
                    End If
                    If (.VUOTO(I) < CC) Then .VUOTO(I) = CC
                End If
                If (.NS = 0) Then
                    REALN = ALTZ + 2 * .xx
                ElseIf (I = 1) Then
                    REALN = ALTZ + .TVERT / 2 + .xx + .VUOTO(1) / 2
                ElseIf (I = .NS + 1) Then
                    REALN = ALTZ + .TVERT / 2 + .xx + .VUOTO(.NS) / 2
                Else
                    REALN = ALTZ + .TVERT + (.VUOTO(I - 1) + .VUOTO(I)) / 2
                End If
                HMIN = ReadLib(24, 3)
                If (.NS > 0) Then
                    If (I = 1 Or I = .NS + 1) Then
                        HMIN = HMIN + .T3 / 2
                    Else
                        HMIN = HMIN + .T3
                    End If
                End If
                If (REALN < HMIN) Then REALN = HMIN
                If (REALN > .HX5(I)) Then .HX5(I) = REALN
                .HX3 += .HX5(I)
                If (.HX5(I) > .HX4) Then .HX4 = .HX5(I)
                NFILSOPRA = NFILSOPRA + NUMFIL
            Next I
        End With
        '5080  FORMAT(' Spessore setto n°',I2,
        '2:      ' troppo grande.'A1,'Passo da aumentare di ',F6.1,'mm.',
        '    1  A1,'(Esigenza altra cassa: 'F6.1,'mm.)',A1,'Si approva?'A1)
    End Sub
    'C*******************************************************************
    Sub ARROTONDA(ByVal Icassa As Integer)
        Dim REALN, AXX As Single
        Dim x, I, IDEL As Integer
        With MecData(Icassa)
            .HX4 = 0
            AXX = 0
            For I = 1 To .NS + 1
                REALN = 2 * .HX5(I)
                .HX5(I) = CSng(CInt(REALN)) / 2
                If (.HX4 < .HX5(I)) Then .HX4 = .HX5(I)
                AXX += .HX5(I)
            Next
            .HX3 = AXX '!INT(REALN)
            .HE = .HX3
        End With
    End Sub
    Sub FILESOPRA(ByVal ICASSA As Integer, ByRef K As Integer)
        Dim IREAD, I As Integer
        Dim REALN As Single
        With MecData(ICASSA)
            If (.Tipo < 1 Or (.Tipo = 2 And ICASSA <> 2) Or _
                        (.Tipo = 3 And ICASSA <> 3) Or _
                        (.Tipo = 4 And ICASSA <> 2 And ICASSA <> 4)) Then
                K = 0
            Else
                If (.Tipo = 2) Then
                    IREAD = 1
                ElseIf (.Tipo = 3) Then
                    IREAD = 2
                ElseIf (.Tipo = 4 And ICASSA = 2) Then
                    IREAD = 1
                Else
                    IREAD = 3
                End If
                '      OPEN(8,FILE=ARCHW(1:LEN_TRIM(ARCHW))//'\'//MEC,
                ' 2       FORM='UNFORMATTED',RECL=1500,
                ' 1       ACCESS='DIRECT',STATUS='UNKNOWN',BLOCKSIZE=64)
                '      WRITE(8,REC=ICASSA)BUFFER
                '      READ(8,REC=IREAD)BUFFER
                K = 0
                For I = 1 To .NS + 1
                    REALN = Abs(MecData(IREAD).Nfile(I))
                    K += CInt(REALN)
                Next
                ' READ(8,REC=ICASSA)BUFFER
                '       CLOSE(8)
            End If
        End With
    End Sub
End Module
