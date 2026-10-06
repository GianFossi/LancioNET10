Imports HTRI.UPMdati
Module ReportFORTRAN
    Sub REPORT(ByVal ICASSA As Integer, ByVal ITEST As Integer, ByVal PREVENT As String)
        '        INCLUDE() 'UPM.FI'
        '        INCLUDE() 'CMN1.FI'
        '==============================================================
        '        Dim IGIO, IMES, IANNO As Integer
        Dim L1, IPG, ITERM, ICAS, J, JJ As Integer
        Dim J1, KS9, K, I7, JA, N3, N4, I8, I9, I4, KTR As Integer
        '      Dim N5, NA, NB, J5, ISA As Integer
        '     Dim PJ1, HNC, HXNC, HENC, Y1, Y2, Y1T, Y2T, Y3, Y3T, Y4, Y4T, Y5, Y5T As Single
        'REAL*4 Y6,Y6T,Y7,Y7T,Y8,Y8T,T1NC,T2NC,ES,EQ,T3NC,T5NC,D1,D2,TO
        'REAL*4 TT1,ELG,ELTM,ELTB,XE,STQS,STQL,Y9,Y10,RKUN,Y11,Y12,Y13
        'REAL*4 Y14,Y15,Y15BIS,Y16,Y20,Y22,Y24,TTR,WTR,YB,WBOC,ATR
        Dim Y14, Y15, Y15BIS, Y16, Y20, Y22, Y24, WBOC As Single
        'REAL*4 STR,ST1,DENZ,FNZ,FRF,Y17,RAPP,SBML,SBQL,STML,STL,SML
        'REAL*4 SMS,SMSN,SMSQ,SBNS,SBQS,STNS
        'C--------------------------------------------------------------
        '4555  FORMAT(/1H1)                                                      UPM00230
        '990   FORMAT(20A2)                                                      UPM00240
        '991   FORMAT(BN,I6)                                                     UPM00250
        '992   FORMAT(BN,F12.0)                                                  UPM00260
        '1500  FORMAT(2H1b,I2
        '     a/1X,'* Program name: UPM03A  rev.7.1 (Date: Jun-04-1995) *'
        '     &//5X,'*** ',A20,' ***',35X,'Page',I2,' of',I2//)
        '1520  FORMAT(30X,'PLUG HEADER CHECK SHEET',                              
        '     &/,18X,'(ASME VIII Div. 1 App.13 - 1992 Ed. + 1992 Add.)')
        '1522  FORMAT(20X,'PLUG HEADER CHECK SHEET (OBROUND CROSS SECTION)',
        '     &/,18X,'(ASME VIII Div. 1 App.13 - 1992 Ed. + 1992 Add.)')
        '1521  FORMAT(//,5X,'ENGENEER:',1X,2A2,37X,'DATE  :',1X,2(I2,'/'),I4,
        '     &/,5X,'APPR  BY:',42X,'DOC.N°: ',6A2,                               
        '     &/,5X,'CUSTOMER:',1X,16X,10A2,5X,'JOB No: ',4X,2A2,
        '     &/,5X,'SERVICE :',1X,20A2,1X,'ITEM  :',1X,A32,        
        '     &/,5X,'PLANT   :',1X,4X,10A2,17X,'REVIS.: ',A2,/)
        '1600  FORMAT(32X,'* INPUT DATA *')                                       
        '1602  FORMAT(5X,                                                         
        '     &'DESIGN TEMPER (°C):',F6.1,' (',F7.1,' °F )',2X,                   
        '     & 'MAX VERT SPAN (MM) :',F6.1,'   (',F7.3,' inch)',/,5X,            
        '     &'CORROS. ALLOW (MM):',F6.1,' (',F6.3,' inch)',2X,                  
        '     &'VERT SPAN END (MM) :',F6.1,'   (',F7.3,' inch)',/,46X,'N.',I2,    
        '     &' STAY',A2,'  (APP. 13',2A2 ,')')
        '1620  FORMAT(5X,'TUBE & PLUG PL. :',1X,9A2, 5X,'MEMBR./(M+B):',
        '     &F5.1,'/',F5.1,'  (',F7.0,'/',F7.0,')',                             
        '     &/,5X,'TOP  & BTM  PL. :',1X,9A2, 5X,'MEMBR./(M+B):',
        '     &F5.1,'/',F5.1,'  (',F7.0,'/',F7.0,')',/,5X,'ENDS',8X,'PL. :',1X,   
        '     &10A2,3X,'MEMBRANE', 4X,':',F5.1,'        (',F7.0,')')              
        '1630  FORMAT(5X,'PART & STIF PL. :',1X,9A2, 5X,'MEMBRANE', 4X,':',F5.1,  
        '     &'        (',F7.0,')')                                              
        '1640  FORMAT(5X,'HEADER PLATE    :',1X,9A2, 5X,'MEMBR./(M+B):',
        '     &F5.1,'/',F5.1,'  (',F7.0,'/',F7.0,')')                             
        '1700  FORMAT(/,5X,'HEADER THICKNESS (MM)',20X,'JOINT EFFICIENCY',        
        '     &/,5X,21('-'),20X,16('-'),/,5X,'TUBE & PLUG PL :',F5.1,5X,          
        '     &'(',F6.3,' inch)',2X,                                             
        '     &'CORNER TOP/BTM (EW):',F5.2,/,5X,'TOP &  BTM  PL :',F5.1,5X,      
        '     &'(',F6.3,' inch)',2X,                                              
        '     &'CORNER TUB/PLG (EW):',F5.2,/,5X,'ENDS',8X,'PL :',F5.1,5X,         
        '     &'(',F6.3,' inch)',2X,                                              
        '     &'ENDS',11X,'(EW):',F5.2)                                           
        '1720  FORMAT(5X,'PART & STIF PL :',F5.1,5X,'(',F6.3,' inch)',2X,         
        '     &'PARTIT & STIFF (EW):',F5.2)                                      
        '1750  FORMAT(/,5X,'TUBES PITCH  (MM):',F5.1,3X,'(',F6.3,' inch)',2X,     
        '     &'PLUGS PITCH (MM):',F5.1,7X,'(',F5.3,'")',
        '     &/,5X,'TUBES O.D.   (MM):',F5.1,3X,'(',F6.3,' inch)',2X,
        '     &'PLUGS DO/D1 (MM):',F5.1,'/',F5.1,' (',F5.3,'/ ',F5.3,'")')
        '1751  FORMAT(46X,'PLUGS D2/D3 (MM):',F5.1,'/',F5.1,                      
        '     &' (',F5.3,'/ ',F5.3,'")')                      
        '1752  FORMAT(46X,'PLUGS TO/T1 (MM):',F5.1,'/',F5.1,                      
        '     &' (',F5.3,'/ ',F5.3,'")')                         
        '1753  FORMAT(46X,'PLUGS T2/T3    (MM):',F5.1,'/',F5.1,                   
        '     &' (',F5.3,'/ ',F5.3,'")')                         
        '1781  FORMAT(///)
        '1780  FORMAT(/,29X,'* ANALYSIS RESULTS *',//,5X,                         
        '     &'LIGAM. EFFICIENCY',24X,                                           
        '     &'LIGAM. EFFICIENCY',/,5X,17('-'),24X,17('-'),/,                    
        '     &5X,'TUBE SHEET EM/EB :',F4.2,'/',F4.2,14X,'PLUG SHEET EM/EB :'     
        '     &,F5.2,'/',F5.2,/,46X,'DISTANCE X/C (MM):',F5.1,'/',F5.1,           
        '     &' (',F5.3,'/',F5.3,'")')
        '1800  FORMAT(5X,37('-'),4X,43('-'),/,5X,                                 
        '     &'TOP & BTM PLATE     :',F6.2,2X,'(',F7.1,')',3X,                   
        '     &'TOP&BTM PLATE (Loc.',A1,'):',F6.2,6X,'(',F7.1,')',   
        '     &/,5X,'TUBE SHEET',10X,':',F6.2,2X,'(',F7.1,')',3X,                 
        '     &'TUBE SHEET    (Loc.',A1,'):',F6.2,6X,'(',F7.1,')',
        '     &/,5X,'PLUG SHEET',10X,':',F6.2,2X,'(',F7.1,')',3X,                 
        '     &'PLUG SHEET    (Loc.',A1,'):',F6.2,6X,'(',F7.1,')')
        '1666  FORMAT('END PL.(APP. 13-4.F):',F6.2,2X,'(',F7.1,')')       
        '1820  FORMAT('PARTIT & STIFF      :',F6.2,2X,'(',F7.1,')')       
        '1821  FORMAT('STIFFEN(PERFORATED) :',F6.2,2X,'(',F7.1,')')
        '1824  FORMAT('Top&Btm plate (Loc.',A1,'):',F6.2,6X,'(',F7.1,')')
        '1825  FORMAT('Tube sheet    (Loc.',A1,'):',F6.2,6X,'(',F7.1,')')
        '1826  FORMAT('Plug sheet    (Loc.',A1,'):',F6.2,6X,'(',F7.1,')')
        '1822  FORMAT(84X)
        '1827  FORMAT(5X,A84)
        'C----------------------------------------------------------------------
        '1830  FORMAT(/,
        '     &       5X,'M.A.W.P.(KG/CM2):',F6.2,2X,'(',F7.1,' PSI)',
        '     &       2X,' CONTROLLING COMPONENT : ',A22)
        '1831  FORMAT(/,
        '     &       5X,'M.A.W.P. (BAR)      :',F6.2,2X,'(',F7.1,' PSI)',
        '     &       2X,' CONTROLLING COMPONENT  : ',A22)
        '1832  FORMAT(/,
        '     &       5X,'M.A.W.P. (MPA)      :',F6.2,2X,'(',F7.1,' PSI)',
        '     &       2X,' CONTROLLING COMPONENT  : ',A22)

        '1840  FORMAT(/,
        '     &       1X,'M.A.W.P.(KG/CM2):',F6.2,2X,'(',F7.1,' PSI)',/
        '     &       1X,'CONTROLLING COMPONENT : ',A22)
        '1841  FORMAT(/,
        '     &       1X,'M.A.W.P. (BAR)      :',F6.2,2X,'(',F7.1,' PSI)',/
        '     &       1X,'CONTROLLING COMPONENT  : ',A22)
        '1842  FORMAT(/,
        '     &       1X,'M.A.W.P. (MPA)      :',F6.2,2X,'(',F7.1,' PSI)',/
        '     &       1X,'CONTROLLING COMPONENT  : ',A22)
        '1662  FORMAT(46X,'HOLE/PITCH(mm) :',F6.1,'/',F6.1,2H (,F6.1,1H/,F6.1,
        '&      '")'/)
        '1663  FORMAT(46X,/)
        '7000  FORMAT(/,5X,'DES. PRESS(KG/CM2):',F6.2,' (',F7.1,' PSI)',2X,      
        '     &'HEADER WIDTH  (MM) :',F6.1,'   (',F7.3,' inch)')                 
        '7001  FORMAT(/,5X,'DESIGN PRESS (BAR):',F6.2,' (',F7.1,' PSI)',2X,      
        '     &'HEADER WIDTH  (MM) :',F6.1,'   (',F7.3,' inch)')                 
        '8601  FORMAT(/,5X,'DESIGN PRESS (MPA):',F6.2,' (',F7.1,' PSI)',2X,      
        '     &'HEADER WIDTH  (MM) :',F6.1,'   (',F7.3,' inch)')                 
        '7002  FORMAT(5X,'HEADER MATERIAL',26X,'ALLOWABLE STRESS (KG/MM2)'
        '     &,8X,'(PSI)',/,5X,15('-'),26X,43('-'))                  
        '7003  FORMAT(5X,'HEADER MATERIAL',26X,'ALLOWABLE STRESS ( N/MM2)'
        '     &,8X,'(PSI)',/,5X,15('-'),26X,43('-'))                
        '8602  FORMAT(5X,'HEADER MATERIAL',26X,'ALLOWABLE STRESS  ( MPA )'
        '     &,8X,'(PSI)',/,5X,15('-'),26X,43('-'))       
        '7004  FORMAT(/,5X,'MEMBRANE STRESS    (KG/MM2)',3X,'( PSI )',4X,        
        '     &'MEMBRANE + BEND. STRESS(KG/MM2)',5X,'( PSI )')                   
        '7005  FORMAT(/,5X,'MEMBRANE STRESS     (N/MM2)',3X,'( PSI )',4X,        
        '     &'MEMBRANE + BEND. STRESS (N/MM2)',5X,'( PSI )')                    
        '8603  FORMAT(/,5X,'MEMBRANE STRESS     ( MPA )',3X,'( PSI )',4X,         
        '     &'MEMBRANE + BEND. STRESS ( MPA )',5X,'( PSI )')                   
        '9000  FORMAT(//,5X,17('+'),3X,'CONVERSION FACTORS',3X,17('+'))
        '9001  FORMAT(/,5X,'PSI = Bar * 14.50377',6X,'PSI = N/mm2 * 145.0377',   
        '     &6X,'PSI = Pa * 1.450377 E-04',/,5X,'PSI = kg/cm2 * 14.22334',
        '     &7X,'inch= mm / 25.4',13X,'°F  = °C * 1.8 + 32')                    
        '9002  FORMAT(/,5X,'NOTE : CONVERSION FACTORS TAKEN FROM ASME CODE',1X,  
        '     &'SECT. VIII DIV.1 " SI UNITS "')                                  
        ' 8000  FORMAT(//,28X,'* INPUT DATA NOZZLE *',/)                       
        '8005  FORMAT(5X,'NOZZLE    DIA.',5X,'THICK.    MATERIAL',6X,             
        '     &  'E.W.',4X,'ALLOW. STRESS',4A2)                               
        '8007  FORMAT(/,5X,'DESIGN PRESS ',4A2,':',F6.2,                      
        '     &15X,'CORROSION ALLOW (MM):',F4.1)                             
        '8008  FORMAT(5X,'DESIGN TEMPER',4X,'([C):',F6.1,//)                  
        '8010  FORMAT(5X,6('-'),4X,4('-'),5X,6('-'),4X,8('-'),6X,4('-'),4X,21('-'
        '     &))                                                               
        '8020  FORMAT(5X,3A2,4X,I2,' INCH',2X,F4.1,' MM',3X,6A2,2X,F4.2,        
        '     &  4X,'MEMBRANE    : ',F6.1)                                     
        '8030  FORMAT(5X,'REINF.(',2A2,' SIDE) ',F5.1,' MM',3X,6A2,2X,F4.2,    
        '     &  4X,'MEMBRANE    : ',F6.1)                                      
        '8040  FORMAT(/,28X,'* ANALYSIS RESULTS *',/)                           
        '8050  FORMAT(5X,3A2,' NOZZLE (',4A2,15X,'MEMBRANE STRESS ',4A2,' :',   
        '     &F7.2)                                                             
        '8060  FORMAT(5X,'REINF  (NR',I2,1X,2A2,' SIDE)',15X,'MEMBRANE STRESS ', 
        '     &  4A2,' :',F7.2)                                                  
        'L1 = 9
        'OPEN(L1,FILE='TEXT'//PREVENT%St,STATUS='NEW')
        Dim File As String = "Text" & PREVENT
        Dim sw As IO.StreamWriter = New IO.StreamWriter(File, False)
        If (UPMdati.KTRON = 1) Then IPG = IPG + 1
        ITERM = 1
        'C****************************                                           
        ' Call DATAM(IGIO, IMES, IANNO)
        ICAS = ICASSA
        If (ICASSA = 0) Then ICAS = 1
        Dim Formato As String = FormatStringa(11500)
        sw.WriteLine(String.Format(Formato, ICAS, Monitor.Motore.Inizio.Firma, ICAS, UPMdati.NUMCAS))
        If (ITEST <> 12) Then
            sw.WriteLine(Formato(11520))
        Else
            sw.WriteLine(Formato(11522))
        End If
        J = 0
        '  For JJ = 1 To 10
        ' If (Not ITEMNO(JJ) = "  ") Then
        ' J = J + 2
        '  ITECAS(J:J+1)=ITEMNO(JJ)
        ' End If
        ' Next
        ' J = J + 2
        ' ITECAS(J:J+1)=' /'
        ' DO 334 JJ=1,5
        ' IF(HEADER(JJ).NE.'  ')THEN
        ' J = J + 2
        '  ITECAS(J:J+1)=HEADER(JJ)
        ' End If
        '334:    Continue Do
        With MecData(0)
            UPMdati.ITECAS = MecData(0).ITEMNO.Trim & "\" & .HEADER
            Dim Data As Date = Format(Now, "dd/MM/yy") 'IGIO, IMES, IANNO,
            WriteLine(String.Format(FormatStringa(11521), .ENGR, Data, .ICKNR, _
                       .CUSTMR, .JOBNUM, .SRVICE, UPMdati.ITECAS, .PLTLOC, .IREV))
            '      ------------------------UPM07470)
            If (UPMdati.KTRON <> 1) Then GoTo 8012
            Dim KT1 As Integer
            KT1 = 1
            If (KUN = 2) Then KT1 = 13
            If (KUN = 4) Then KT1 = 9
            If (KT1 <> 1) Then GoTo 8616
            Formato = FormatStringa(18007)
            sw.WriteLine(String.Format(Formato, NMM3(1), NMM3(2), NMM3(3), NMM3(4), PJ1, .CA))
            GoTo 8617
8616:       sw.WriteLine(String.Format(FormatStringa(18007), NMM2(KT1), NMM2(KT1 + 1), NMM2(KT1 + 2), NMM2(KT1 + 3), PJ1, .CA))
8617:       sw.WriteLine(String.Format(FormatStringa(18008), .T))
            GoTo 8009
            ' --------------------------UPM07590)
8012:       sw.WriteLine(FormatStringa(11600))
            KS9 = 2 * K - 1
            If (KUN > 1) Then GoTo 7500
            .KPJ1 = PJ1 * 14.2233
            sw.WriteLine(String.Format(FormatStringa(17000), PJ1, .KPJ1, HNC, HNC / 25.4))
            GoTo 7600
7500:       If (KUN = 4) Then GoTo 7533
            .KPJ1 = PJ1 * 14.503747
            WriteLine(String.Format(FormatStringa(17001), PJ1, .KPJ1, HNC, HNC / 25.4))
            GoTo 7600
7533:       .KPJ1 = PJ1 * 145.03747
            WriteLine(String.Format(FormatStringa(18601), PJ1, .KPJ1, HNC, HNC / 25.4))
7600:       KTEMP = .T * 1.8 + 32
            WriteLine(String.Format(FormatStringa(11602), .T, KTEMP, HXNC, HXNC / 25.4, .CA, .CA / 25.4, _
                      HENC, HENC / 25.4, NS, INSS(K), IABC(KS9), IABC(KS9 + 1)))
            If (.PassoRinf > 0) Then
                WriteLine(String.Format(FormatStringa(11662), .BucoRinf, .PassoRinf, _
                          .BucoRinf / 25.4, .PassoRinf / 25.4))
            Else
                WriteLine(FormatStringa(11663))
            End If
            If (KUN > 1) Then GoTo 7501
            WriteLine(FormatStringa(17002))
            GoTo 7601
7501:       If (KUN > 2) Then GoTo 7534
            WriteLine(FormatStringa(17003))
            GoTo 7601
7534:       WriteLine(FormatStringa(18602))
7601:       If (MATHOM = 2) Then GoTo 1030
            WriteLine(String.Format(FormatStringa(11640), .MATUG, Y1, Y2, Y1T, Y2T))
            GoTo 1035
1030:       WriteLine(String.Format(FormatStringa(11620), .MATSH, Y3, Y4, Y3T, Y4T, .MATTP, _
                       Y5, Y6, Y5T, Y6T, .MATEN, Y7, Y7T))
1035:       If (NS = 0) Then GoTo 1040
            WriteLine(String.Format(FormatStringa(11630), .MATSE, Y8, Y8T))
1040:       WriteLine(String.Format(FormatStringa(11700), T2NC, T2NC / 25.4, ES, _
                     T1NC, T1NC / 25.4, EQ, T5NC, T5NC / 25.4, .e))
            If (NS = 0) Then GoTo 1045
            WriteLine(String.Format(FormatStringa(11720), T3NC, T3NC / 25.4, .EWPS))
1045:       If (.DO_Renamed > 0 And .TSP > 0) Then
                '                If (Not IEL = "SI") Then GoTo 1046
                If (Not .St2(1) = "SI") Then GoTo 1046
                WriteLine(String.Format(FormatStringa(11750), .TSP, .TSP / 25.4, .TSP, .TSP / 25.4, _
                          .DO_Renamed, .DO_Renamed / 25.4, D1, D2, D1 / 25.4, D2 / 25.4))
                WriteLine(String.Format(FormatStringa(11752), TO_Renamed, TT1, TO_Renamed / 25.4, TT1 / 25.4))
                GoTo 1049
1046:           WriteLine(String.Format(FormatStringa(11750), .TSP, .TSP / 25.4, .TSP, .TSP / 25.4, .DO_Renamed, _
                     .DO_Renamed / 25.4, .DF(1 - 1), .DF(2 - 1), .DF(1 - 1) / 25.4, .DF(2 - 1) / 25.4))
                If (.DF(3 - 1) <= 0) Then GoTo 1047
                WriteLine(String.Format(FormatStringa(11751), .DF(3 - 1), .DF(4 - 1), .DF(3 - 1) / 25.4, .DF(4 - 1) / 25.4))
1047:           WriteLine(String.Format(FormatStringa(11752), .TF(1 - 1), .TF(2 - 1), .TF(1 - 1) / 25.4, .TF(2 - 1) / 25.4))
                If (.TK(3 - 1) <= 0) Then GoTo 1049
                WriteLine(String.Format(FormatStringa(11753), .TF(3 - 1), .TF(4 - 1), .TF(3 - 1) / 25.4, .TF(4 - 1) / 25.4))
1049:           WriteLine(String.Format(FormatStringa(11780), ELG, ELG, ELTM, ELTB, XE, C(3), XE / 25.4, C(3) / 25.4))
            Else
                WriteLine(FormatStringa(11781))
            End If
            If (KUN > 1) Then GoTo 7502
            WriteLine(FormatStringa(17004))
            GoTo 7602
7502:       If (KUN > 2) Then GoTo 7535
            WriteLine(FormatStringa(17005))
            GoTo 7602
7535:       WriteLine(FormatStringa(18603))
7602:       If (STQS = 1) Then
                TBMIN = "Q"
                TBMAX = "N"
            Else
                TBMAX = "Q"
                TBMIN = "N"
            End If
            If (STQL(1) = 1) Then
                TSMIN = "Q"
                TSMAX = "M"
            Else
                TSMAX = "Q"
                TSMIN = "M"
            End If
            If (STQL(2) = 1) Then
                PSMIN = "Q"
                PSMAX = "M"
            Else
                PSMAX = "Q"
                PSMIN = "M"
            End If
            WriteLine(String.Format(FormatStringa(11800), Y9, Y9 * RKUN, TBMAX, Y10, Y10 * RKUN, _
                    Y11, Y11 * RKUN, TSMAX, Y12, Y12 * RKUN, Y13, Y13 * RKUN, PSMAX, Y14, Y14 * RKUN))
            RIGA1 = FormatStringa(11822)
            RIGA2 = FormatStringa(11822)
            RIGA3 = FormatStringa(11822)
            If (NS > 0) Then
                RIGA1 = String.Format(FormatStringa(11820), Y15, Y15 * RKUN)
                If (NS >= 1 And .StiffEff < 1) Then
                    RIGA2 = String.Format(FormatStringa(11821), Y15BIS, Y15BIS * RKUN)
                    RIGA3 = String.Format(FormatStringa(11666), Y16, Y16 * RKUN)
                Else
                    RIGA2 = String.Format(FormatStringa(11666), Y16, Y16 * RKUN)
                End If
            End If
            'RIGA1(42:84)=string.Format(Formatstringa(1824),TBMIN,Y20,Y20*RKUN)
            RIGA1 = RIGA1.Substring(0, 41) + String.Format(FormatStringa(11824), TBMIN, Y20, Y20 * RKUN)
            ' WRITE(RIGA2(42:84),1825)TSMIN,Y22,Y22*RKUN
            RIGA2 = RIGA2.Substring(0, 41) + String.Format(FormatStringa(11825), TSMIN, Y22, Y22 * RKUN)
            RIGA3 = RIGA3.Substring(0, 41) + String.Format(FormatStringa(11826), PSMIN, Y24, Y24 * RKUN)
            WriteLine(String.Format(FormatStringa(1827), RIGA1, RIGA2, RIGA3))
            If (KUN = 1) Then WriteLine(String.Format(FormatStringa(11830), MAWP, MAWPPSI, CONTROL))
            If (KUN = 2) Then WriteLine(String.Format(FormatStringa(11831), MAWP, MAWPPSI, CONTROL))
            If (KUN = 3) Then WriteLine(String.Format(FormatStringa(11831), MAWP, MAWPPSI, CONTROL))
            If (KUN = 4) Then WriteLine(String.Format(FormatStringa(11832), MAWP, MAWPPSI, CONTROL))
            '----------------------------------   STAMPA FATTORI CONVERSIONE !!!!   UPM08105                   
            If (ITERM <> 1) Then GoTo 8009
6908:       Write(L1, 9000)
            Write(L1, 9001)
            Write(L1, 9002)
            '        ----------------------------------UPM08109)
            '       ---------------------------------UPM08110)
            '      ----------------------------------UPM08111)
            '* SE CI SONO STAMPA BOCCH.                                             UPM08120
            '       ----------------------------------UPM08130)
            sw.Close()
            Exit Sub
            '        Return
            '???????????????????????????????????????????????????????
8009:       If (INZ1 < 1) Then GoTo 6908
            If (KUN > 2) Then I7 = 5
            If (KUN > 2) Then I7 = 9
            WriteLine(FormatStringa(4555))
            Write(FormatStringa(8000))
            WriteLine(String.Format(FormatStringa(8005), NMM2(I7), NMM2(I7 + 1), NMM2(I7 + 2), NMM2(I7 + 3)))
            Write(FormatStringa(8010))
            For JA = N3 To N4
                I8 = 1
                I9 = 1
                If (JA = 2) Then I9 = 7
                If (JA = 2) Then I8 = 4
                WriteLine(String.Format(FormatStringa(8020), INLE(I8), INLE(I8 + 1), INLE(I8 + 2), _
                          ITR(JA), TTR(JA), MTR(J1), J1 = I9, I9 + 5), WTR(JA), YB(JA + 4))
            Next
            '                           ----------------------UPM08290)
            '* RINFORZI SU BOCCH.                                                   UPM08300
            '                           ----------------------UPM08310)
            For JA = N3 To N4
                If (NTR(JA) < 1) Then GoTo 6886
                I8 = 1
                If (JA = 2) Then I8 = 3
                I9 = 1
                If (JA = 2) Then I9 = 7
                WBOC = 0.65
                WriteLine(String.Format(FormatStringa(8030), INL1(I8), INL1(I8 + 1), ATR(JA), _
                      MST(I9), MST(I9 + 1), MST(I9 + 2), MST(I9 + 3), MST(I9 + 4), MST(I9 + 5), _
                      WBOC, YB(JA + 6)))
6886:       Next
            '    -----------------------UPM08420)
            WriteLine(FormatStringa(8040))
            For JA = N3 To N4
                I8 = 1
                If (JA = 2) Then I8 = 4
                I4 = 1
                If (JTR(JA) = 2) Then I4 = 5
                WriteLine(String.Format(FormatStringa(8050), INLE(I8), INLE(I8 + 1), INLE(I8 + 2), _
                      ISVA(i4), ISVA(i4 + 1), ISVA(i4 + 2), ISVA(i4 + 3), _
                      NMM2(i7), NMM2(i7 + 1), NMM2(i7 + 2), NMM2(i7 + 3), YB(JA)))
            Next
            For JA = N3 To N4
                If (NTR(JA) < 1) Then GoTo 6889
                I8 = 1
                If (JA = 2) Then I8 = 3
                Write(String.Format(FormatStringa(8060), NTR(JA), INL1(I8), INL1(I8 + 1), _
                    NMM2(i7), NMM2(i7 + 1), NMM2(i7 + 2), NMM2(i7 + 3), YB(JA + 2)))
6889:       Next
            GoTo 6908
        End With
    End Sub
End Module
