C     PROGRAM ROTFLFOR

C-------------------------------------------------------------------------------
C     Originale di Nagliato, modifiche di Presciuttini, modifiche di Polo....
C
C     PROGRAMMA DI CALCOLO ROTAZIONE FLANGIA "WELDING NECK"
C
C     Rev.4, 25 Luglio 1994 :
C     - aggiunto calcolo del "flexibility factor"
C       J come da Appendix S di ASME VIII Div.2 1992 Ed. + 1993 Add.
C     - modificato lettura dati per compatibilitเ con il programma di Pre-
C       Processing : ora legge solo dal file ROTFLFOR.INP (nome fissato)
C       che ha la stessa formattazione dei vecchi files dati .DAT
C     Rev.5, 25 Luglio 1995 :
C     - aggiunta considerazione delle flange senza hub
C     Rev.6, 03 Marzo 2006 :
C     - passaggio al sistema di misura SI
C     Rev.7, 06 Novembre 2006
C     - Addenda 2005 : S-2 diventato 2-14
CC------------------------------------------------------------------------------
	MODULE mTYPROTFL
      TYPE typROTFL
         CHARACTER*6 Arch
         CHARACTER*18 Membr
         CHARACTER*18 Mater
         REAL Temp
         REAL DiamInt
         REAL DiamExt
         REAL Spess 
         REAL g0  
         REAL g1 
         REAL hub 
         REAL E0 
         REAL E1
         REAL W 
         REAL Press 
         REAL BC 
         REAL BoltL
         REAL BoltN 
         REAL BoltA 
         REAL Gef 
         REAL b0  
         REAL N 
         REAL EE  
         REAL SpGuar
	   CHARACTER*40 DiscoRam 
	   CHARACTER*40 ArchDir 
	   CHARACTER*70 Intest
	   CHARACTER*70 Norma
	   REAL Rapp
	   REAL J1
	   REAL Wm2 
	   REAL Estar
	   REAL nistar
	   REAL ts
	   REAL Thet0
	   REAL Thet1
	   REAL SpExt
	END TYPE
	END MODULE
	INTEGER*4 FUNCTION MIO_LEN_TRIM(S)
	CHARACTER(*) S
	INTEGER*4 I
	DO 1 I=1,LEN(S)
	IF(ICHAR(S(I:I)).EQ.0)THEN
	WRITE(S(I:I),'(A1)')' '
	ENDIF
1	CONTINUE
      MIO_LEN_TRIM=LEN_TRIM(S)
	RETURN
	END
c********************************************	 
	SUBROUTINE ROTFLFOR(objROTFL)
	USE mTYPROTFL
	USE DFWIN
!DEC$ ATTRIBUTES DLLEXPORT::ROTFLFOR
	IMPLICIT REAL*8(A-Z)
	TYPE(typROTFL)::objROTFL
      INTEGER ISSS, ICOUNT, ICOUNT0,ISTAT,NUMAR,NARGS
      CHARACTER*24 D$,E$,M$
      CHARACTER*40 DISCORAM,TIPOSTAM,ARCHDIR
	CHARACTER*120 DOMANDA
      INTEGER*4 NBOLT,NDUM,xMESS,MIO_LEN_TRIM
	INTEGER*2 ITIPOST,L
!DEC$ OPTIONS /ALIGN=COMMONS=STANDARD
      COMMON/CARA/D$,E$,M$
      COMMON/WORK1/TEMP,B,A2,T,G0,G1,H,E,EB,M,C0,H0,K0,F,V,X,Y,K,A1,Z,
     *            Z0,EG,TG,FI,ZZZ,YYY,TTT,UUU,LLL,DDD,R1,R2
     *            ,Wm2,Estar,nistar,ts,F1,F3,SpExt,kPTkExt
      COMMON/WORK2/CLP,BLUNG,NBOLT,NDUM,ABOLT,GLP,P,PLP,P0LP,CLCPG,CLCPN
     $,Z1,BB,HHD,HHT,HHG,HD,HT,HG,KB,KG,KF,BBTOT,M1,ITIPOST,ARCHDIR
!DEC$ END OPTIONS
C  A2  diametro esterno flangia  B dia int
	CALL INPUT1(objROTFL)
      DISCORAM=objROTFL%DiscoRam
      ARCHDIR=objROTFL%ArchDir
      ITIPOST=3
      L=MIO_LEN_TRIM(DISCORAM)
      IF(L.EQ.0) L=1
      OPEN(67,FILE=DISCORAM(1:L)//'ROTFLFOR.OUT')
      N=.3
      P=3.14159265359
      HG=(CLP-GLP)/2
      R1=B/2
      R2=A2/2
C     M=P0LP*HG
      M=1.E06
      IF(R1.GT.0.) THEN
        K=R2/R1
        IF(G0.GT.0..AND.G1.GT.0.)THEN
          C0=G1/G0
          H0=SQRT(2*R1*G0)
          K0=H/H0
          CALL CASM
          X=12*(1-N**2)*H**4/(R1**2*G0**2)
          Y=(G1-G0)/G0
          C1=(K**2-1)/(((1+N)/(1-N))*K**2+1)
          C2=2*R1*X/((1+Y)**3*E*G0*H**2)
          C3=M/(4*P*(R2-R1))
          C4=.5+((1+N)/(1-N))*(K**2/(K**2-1))*LOG(K)  ! giusto LogNat ???
          C5=1+((T/G0)/SQRT(2*R1/G0))*F
          C6=(1+N)*(K**2-1)*(T/G0)**3*V
          C7=(((1+N)/(1-N))*K**2+1)*SQRT(2*R1/G0)
          A1=(C1*C2*C3)*(C4/(C5+C6/C7))
          Z=A1*((R1/H)*(3*(1-N**2)/X)**.25*(1+N)**3)*V
          KQ = K*K
          ZZZ = (KQ+1.)/(KQ-1.)
          K1 = KQ*LOG10(K)/(KQ-1.)
          YYY = (1./(K-1.))*(0.66845+5.7169*K1)
          K2 = KQ*(1.+8.55246*LOG10(K))-1.
          TTT = K2/((1.04720+1.9448*KQ)*(K-1.))
          UUU = K2/(1.36136*(KQ-1.)*(K-1.))
          EEE = F/H0
          DDD = UUU/V*H0*G0*G0
          LLL = (T*EEE+1.)/TTT + T*T*T/DDD
	  ELSE
          G0=0.
          G1=0.
          Z=6*M/P/(E*T*T*T)/LOG(K)
        ENDIF
      ELSEIF(Estar.GT.0.)THEN
	  CALL CalcF1F3
	  R1=GLP/2
	  R2=A2/2
        IF(R1.EQ.0..OR.R2.EQ.0..OR.R2.LE.R1)RETURN
	  K=R2/R1
	  IF(SpExt.EQ.0.)SpExt=T
	  kPTkExt=1.+F3*LOG(K)/6/Estar*(SpExt/T)**3
        Z=2*M/(E*Estar*T*T*T)*F3/kPTkExt
c      write(domanda,'(3e12.5)')Z,M,KF
c      xMESS = MessageBoxEx(NULL,DOMANDA,'ISA'C,MB_YESNO+
c     1	                                 +MB_ICONQUESTION+
c     2                                     +MB_SETFOREGROUND,
c     3                     LANG_ITALIAN)
	ELSE
        Z=2*M/(E*T*T*T)
      ENDIF
      Z0=180*Z/P
      KF=M/Z

C----- Coefficients of Fig.2-7.1 of ASME VIII Div.1 :
C      (Added for calculation of flexibility factor, J)

      CALL MOMFLAN
      CALL STP(objROTFL)
      CALL VARCAR 
      CALL STP1(objROTFL)
      objROTFL%Thet0=Z1*180./P
      objROTFL%Thet1=Z*180./P
	CLOSE(67)
      RETURN
C-----------------------------------------------------------------
c    1 FORMAT(A24)
c    2 FORMAT(A1)
      END
C********************************************************************
      SUBROUTINE MOMFLAN
	USE DFWIN
      IMPLICIT REAL*8(A-Z)
      INTEGER*4 NBOLT,NDUM
      INTEGER*2 ITIPOST
      CHARACTER*40 ARCHDIR
!DEC$ OPTIONS /ALIGN=COMMONS=STANDARD
      COMMON/WORK1/TEMP,B,A2,T,G0,G1,H,E,EB,M,C0,H0,K0,F,V,X,Y,K,A1,Z,
     *            Z0,EG,TG,FI,ZZZ,YYY,TTT,UUU,LLL,DDD,R1,R2
     *            ,Wm2,Estar,nistar,ts,F1,F3,SpExt,kPTkExt
      COMMON/WORK2/CLP,BLUNG,NBOLT,NDUM,ABOLT,GLP,P,PLP,P0LP,CLCPG,CLCPN
     $,Z2,BB,HHD,HHT,HHG,HD,HT,HG,KB,KG,KF,BBTOT,M1,ITIPOST,ARCHDIR
	CHARACTER*120 DOMANDA
	INTEGER*4 xMESS
!DEC$ END OPTIONS
C-----------------------------------
      IF(B.GT.0.)THEN
         R=(CLP-B)/2-G1
         HT=(R+G1+HG)/2
         HD=R+0.5*G1
         HHD=PLP*P*B**2/4
         HHT=PLP*P*GLP**2/4-HHD
         HHG=CLCPN-PLP*P*GLP**2/4
         M1=HT*HHT+HG*HHG+HD*HHD
      ELSEIF(Estar.GT.0.)THEN
         HT=HG
         HD=0
!         HHG=CLCPN
         HHG=CLCPN-PLP*P*GLP**2/4
         HHD=0
         HHT=PLP*P*GLP**2/4-HHD
         M1=(CLCPN-0.*PLP*P*GLP**2/4)*HG*F3/2/P+0.5*F1/8*GLP**3*PLP
	ELSE
         HT=HG
         HD=0
!         HHG=CLCPN
         HHG=CLCPN-PLP*P*GLP**2/4
         HHD=0
         HHT=PLP*P*GLP**2/4-HHD
         M1=(CLCPN-0.*PLP*P*GLP**2/4)*HG+.087*GLP**3*PLP
c	WRITE(DOMANDA,'(''M1''4E12.5)')M1,CLCPN,PLP*P*GLP**2/4,HG
c      xMESS = MessageBoxEx(NULL,DOMANDA,'ISA'C,MB_YESNO+
c     1	                                 +MB_ICONQUESTION+
c     2                                     +MB_SETFOREGROUND,
c     3                     LANG_ITALIAN)
      ENDIF
      Z=Z*M1/M
      Z0=Z0*M1/M
      A1=A1*M1/M
      CLCPG=HHG
c      write(domanda,'(''Z sec'',3e12.5)')Z,M1,KF
c      xMESS = MessageBoxEx(NULL,DOMANDA,'ISA'C,MB_YESNO+
c     1	                                 +MB_ICONQUESTION+
c     2                                     +MB_SETFOREGROUND,
c     3                     LANG_ITALIAN)
      RETURN
      END
C********************************************************************
      SUBROUTINE VARCAR
	USE DFWIN
      IMPLICIT REAL*8(A-Z)
      INTEGER*4 NBOLT,NDUM
      INTEGER*2 ITIPOST
      CHARACTER*40 ARCHDIR
!DEC$ OPTIONS /ALIGN=COMMONS=STANDARD
      COMMON/WORK1/TEMP,B,A2,T,G0,G1,H,E,EB,M,C0,H0,K0,F,V,X,Y,K,A1,
     *          Z,Z0,EG,TG,FI,ZZZ,YYY,TTT,UUU,LLL,DDD,R1,R2
     *            ,Wm2,Estar,nistar,ts,F1,F3,SpExt,kPTkExt
      COMMON/WORK2/CLP,BLUNG,NBOLT,NDUM,ABOLT,GLP,P,PLP,P0LP,CLCPG,CLCPN
     $,Z2,BB,HHD,HHT,HHG,HD,HT,HG,KB,KG,KF,BBTOT,M1,ITIPOST,ARCHDIR
	CHARACTER*120 DOMANDA
	INTEGER*4 xMESS
!DEC$ END OPTIONS
C------------------------------------------------------
      KB=EB*ABOLT*NBOLT/BLUNG
      KG=EG*P*GLP*BBTOT/TG
      KF=M1/Z
      IF(PLP.EQ.0.)THEN
         R=1
         M=M1
         P0LP=CLCPN
         Z2=Z
         RETURN
      ENDIF
      IF(B.EQ.0.)THEN
         IF(Estar.EQ.0.)THEN
	   ANUM=KB/KF*(.087*GLP**3-0.*P*GLP**2*HG/4)*PLP*HG
	   ELSE
	   ANUM=KB/KF*(.5*F1/8*GLP**3-0.*P*GLP**2*HG/4*F3/2/P)*PLP*HG
	   ENDIF
	   ADEN=1.+KB*HG*HG/KF
	   DELTAW=ANUM/ADEN
	   RAPP=(CLCPN+DELTAW)/CLCPN
      ELSE
        ALFA=1+P/4/CLCPN/HG*(GLP*GLP*(HT-HG)+B*B*(HD-HT))*PLP
        BETA=1-P/4*GLP*GLP*PLP/CLCPN
        ANUM=ALFA*HG*HG/KF+1/KB+BETA/KG
        ADEN=HG*HG/KF+1/KB+1/KG
        RAPP=ANUM/ADEN
      ENDIF
c      write(domanda,'(6e12.5)')KB,KF,GLP,HG,.5*F1/8*GLP**3,
c     *  P*GLP**2*HG/4*F3
c      xMESS = MessageBoxEx(NULL,DOMANDA,'ISA'C,MB_YESNO+
c     1	                                 +MB_ICONQUESTION+
c     2                                     +MB_SETFOREGROUND,
c     3                     LANG_ITALIAN)
c	WRITE(DOMANDA,'(''RAPP''6E12.5)')ANUM,ADEN,RAPP,CLCPN
c     X,(CLCPN-KB/KF*(.087*GLP**3-P*GLP**2*HG/4)*PLP*HG)
c     X,(CLCPN-KB/KF*(.5*F1/8*GLP**3-P*GLP**2*HG/4*F3)*PLP*HG)
c      xMESS = MessageBoxEx(NULL,DOMANDA,'ISA'C,MB_YESNO+
c     1	                                 +MB_ICONQUESTION+
c     2                                     +MB_SETFOREGROUND,
c     3                     LANG_ITALIAN)
      P0LP=CLCPN*RAPP
      M=P0LP*HG
	IF(B.EQ.0.AND.Estar.GT.0.)M=M/2/P
      Z2=M/KF
c	IF(B.EQ.0.AND.Estar.GT.0.)Z2=Z2/2/P
c      write(domanda,'(5e12.5)')Z2,P0LP,HG,M,KF
c      xMESS = MessageBoxEx(NULL,DOMANDA,'ISA'C,MB_YESNO+
c     1	                                 +MB_ICONQUESTION+
c     2                                     +MB_SETFOREGROUND,
c     3                     LANG_ITALIAN)
      RETURN
      END
C******************************************************************
      SUBROUTINE STP1(OBJROTFL)
	USE DFWIN
	USE mTYPROTFL
      IMPLICIT REAL*8(A-Z)
      INTEGER*4 NBOLT,NDUM,MIO_LEN_TRIM
      CHARACTER*40 ARCHDIR
      CHARACTER*24 D$,E$,M$
      CHARACTER*6 TITOL
	CHARACTER*240 DOMANDA
	TYPE(typROTFL)::OBJROTFL
      COMMON/CARA/D$,E$,M$
      INTEGER*2 ITIPOST
	REAL*4 CARICO
!DEC$ OPTIONS /ALIGN=COMMONS=STANDARD
      COMMON/WORK1/TEMP,B,A2,T,G0,G1,H,E,EB,M,C0,H0,K0,F,V,X,Y,K,A1,Z,
     *            Z0,EG,TG,FI,ZZZ,YYY,TTT,UUU,LLL,DDD,R1,R2
     *            ,Wm2,Estar,nistar,ts,F1,F3,SpExt,kPTkExt
      COMMON/WORK2/CLP,BLUNG,NBOLT,NDUM,ABOLT,GLP,P,PLP,P0LP,CLCPG,CLCPN
     $,Z2,BB,HHD,HHT,HHG,HD,HT,HG,KB,KG,KF,BBTOT,M1,ITIPOST,ARCHDIR
!DEC$ END OPTIONS
      CHARACTER*60 FILARC
      CHARACTER*80 FRMT(30)
      FILARC=ARCHDIR(1:MIO_LEN_TRIM(ARCHDIR))//'\WN5\ROTFL.WNF'
      OPEN(50,FILE=FILARC,STATUS='OLD')
      IF(B.EQ.0.)THEN
      	IF(Estar.EQ.0.)THEN
             TITOL='COVER '
          ELSE
             TITOL='TUBESH'
	    ENDIF
      ELSE
        TITOL='FLANGE'
      ENDIF
      CALL FORMA(1,FRMT)
      WRITE(67,FRMT)TITOL
      CALL FORMA(2,FRMT)
      WRITE(67,FRMT)D$,E$
      CALL FORMA(3,FRMT)
      WRITE(67,FRMT)CLP,BLUNG,NBOLT,ABOLT,GLP,BB,BBTOT,EG,TG
      CALL FORMA(4,FRMT)
      WRITE(67,FRMT)KF,KB,KG,1/(HG*HG/KF+1/KG),P0LP/CLCPN
	OBJROTFL%Rapp=P0LP/CLCPN
	IF(P0LP/CLCPN.LT.1.)THEN
      CALL FORMA(10,FRMT)
	WRITE(67,FRMT)
	ENDIF
      IF(PLP.GT.0.)THEN
	CARICO=CLCPN
c	IF(Wm2.GT.CARICO)CARICO=Wm2
      MTHEOR=(CARICO-(P0LP-CLCPN)-HHT-HHD)/(2.*BB*P*GLP*PLP)
      MEFFEC=(CARICO-HHT-HHD)/(2.*BB*P*GLP*PLP)
c	WRITE(DOMANDA,'(''m''10E12.5)')CARICO,CLCPN,P0LP,HHT,
c     1MTHEOR,MEFFEC,PLP,P,GLP,HHD
c      xMESS = MessageBoxEx(NULL,DOMANDA,'ISA'C,MB_YESNO+
c     1	                                 +MB_ICONQUESTION+
c     2                                     +MB_SETFOREGROUND,
c     3                     LANG_ITALIAN)
	IF(MEFFEC.LT.MTHEOR)MEFFEC=MTHEOR
c     CLCPN   bolt target load under pressure 
c     GLP     diametro efficace guarnizione
c     P0LP    P0LP carico dato al bolt-up
      ELSE
      MTHEOR=0
      MEFFEC=0
      ENDIF
C----- Flexibility Factor (ASME VIII Div.1 Appendix 2-14) : ------------
      IF(B.GT.0.)THEN
      IF(G0.GT.0..AND.G1.GT.0.)THEN
      KI = 0.3                                ! integral flanges only
      J0 = 52.14*M*V/(LLL*E*G0*G0*H0*KI)      ! initial
      J1 = J0*M1/M                            ! in-service
      ELSE
      KI = 0.2
      J0 = 109.4*M/E/T**3/LOG(K)/KI
      J1 = J0*M1/M                            ! in-service
      ENDIF
      ENDIF
C----------------------------------------------------------------------
      IF(G0.GT.0..AND.G1.GT.0..OR.B.EQ.0.)THEN
         IF(Estar.GT.0.) THEN
	   CALL FORMA(11,FRMT)
	   ELSE
	   CALL FORMA(5,FRMT)
	   ENDIF
         WRITE(67,FRMT)P0LP,TITOL,M,CLCPN,TITOL,M1,CLCPG,MTHEOR,MEFFEC,
     *    TITOL,   Z2*180/P,TITOL,Z*180/P
         IF(B.GT.0.)THEN
           CALL FORMA(6,FRMT)
           WRITE(67,FRMT) UUU,V,DDD,TTT,LLL
           CALL FORMA(8,FRMT)
           WRITE(67,FRMT)KI,J0,J1
         ENDIF
      ELSE
      CALL FORMA(7,FRMT)
      WRITE(67,FRMT)P0LP,M,CLCPN,M1,CLCPG,MTHEOR,MEFFEC,
     *             Z2*180/P,Z*180/P
      CALL FORMA(9,FRMT)
      WRITE(67,FRMT)KI,J0,J1
      ENDIF
      CLOSE(50)
	OBJROTFL%J1=J1
      RETURN

C1000 FORMAT(1H1/,5X,
C    X'  * Program name: ROTFL   rev.5.1 (Date: Jun-06-1996) *'/5X,
C    X'(ref:Brownell-Young,EQUIPMENT DESIGN,Wiley & Sonson,London',/5X,
C    X'   & ASME VIII Div.1 Appendix S 1995 Ed.+ 1995 Add.)',/5X,
C    X'    FBM - Hudson Italiana SpA   ',37X,'sheet   of',/,5X,
C    X'                                  ',/,10X,
C    X'ีออออออออออออออออออออออออออออออออธ',/,10X,
C    X'ณ CALCULATION OF ',A6,' ROTATION ณ',/,10X,
C    X'ณ 2nd sheet : bolting-up         ณ',/,10X,
C    X'ิออออออออออออออออออออออออออออออออพ')
C
C1100 FORMAT(5X,'Job  :    ',A24,/,5X,'Item :  ',A24,/)
C1200 FORMAT(/
C    X,5X,'BOLT CIRCLE DIAMETER            [mm]    C  =',F15.2,/
C    X,5X,'EFFECTIVE BOLT LENGTH           [mm]    Bl =',F15.2,/
C    X,5X,'NUMBER OF BOLTS                         n  =',I15,/
C    X,5X,'AREA OF ONE BOLT                [mm2]   Ab =',F15.2,/
C    X,5X,'EFFECTIVE GASKET DIAMETER       [mm]    Ge =',F15.2,/
C    X,5X,'EFFECTIVE GASKET WIDTH          [mm]    b  =',F15.2,/
C    X,5X,'GASKET WIDTH,   (OD-ID)/2       [mm]    bt =',F15.2,/
C    X,5X,'GASKET ELASTIC MODULUS      [Kgf/mm2]   Eg =',F15.2,/
C    X,5X,'GASKET THICKNESS                [mm]    Tg =',F15.2)
C
C1250 FORMAT(/
C    $'       Calculated stiffnesses of flange, bolts, and gasket :'//
C    $'       kF = ',E12.5,' [kgf*mm/rad],'/
C    $'       kB = ',E12.5,' [kgf/mm],'/
C    $'       kG = ',E12.5,' [kgf/mm].'//
C    $'       Resulting ratio of bolt loads bolt-up/pressurized   :'//
C    $'          R  = ',F15.3,'   [--]')
C
C1300 FORMAT(/,
C    1'     --------------------- FINAL RESULTS ---------------------'/
C    X5X, 'INITIAL BOLT LOAD           [Kgf]     W0 =',F15.2/
C    X5X, 'INITIAL FLANGE MOMENT       [Kgf*mm]  M0 =',F15.2/
C    25X, 'BOLT LOAD (in-service)      [Kgf]     W  =',F15.2/
C    X5X, A6,   ' MOMENT (in-service)  [Kgf*mm]  M  =',F15.2/
C    35X, 'GASKET LOAD (in-service)    [Kgf]     HG =',F15.2/
C    45X, 'm RESULTING FROM ASME  PROCEDURE      m  =',F15.2/
C    55X, 'm OBTAINED WITH THIS PROCEDURE        m  =',F15.2/
C    65X, 'INITIAL ',A6,' ROTATION     [deg]  Theta =',F15.3/
C    75X, A6,   ' ROTATION (in-service)[deg]  Thet1 =',F15.3/
C    $'     ---------------------------------------------------------')
C1301 FORMAT(
C    $5X, '--- ASME VIII Div.1 Appendix S para.S-2 calculation -----'/
C    $5X, 'FACTOR                                 U =',F15.5/
C    $5X, 'FACTOR                                 V =',F15.5/
C    $5X, 'FACTOR                    d = U/V*ho*goý =',F15.1/
C    $5X, 'FACTOR                                 T =',F15.5/
C    $5X, 'FACTOR                  L=(te+1)/T+t^3/d =',F15.5)
C1305 FORMAT(/,
C    1'     --------------------- FINAL RESULTS ---------------------'/
C    X5X, 'INITIAL BOLT LOAD           [Kgf]     W0 =',F15.2/
C    X5X, 'INITIAL FLANGE MOMENT       [Kgf*mm]  M0 =',F15.2/
C    25X, 'BOLT LOAD (in-service)      [Kgf]     W  =',F15.2/
C    X5X, 'FLANGE MOMENT (in-service)  [Kgf*mm]  M  =',F15.2/
C    35X, 'GASKET LOAD (in-service)    [Kgf]     HG =',F15.2/
C    45X, 'm RESULTING FROM ASME  PROCEDURE      m  =',F15.2/
C    55X, 'm OBTAINED WITH THIS PROCEDURE        m  =',F15.2/
C    65X, 'INITIAL FLANGE ROTATION     [deg]  Theta =',F15.3/
C    75X, 'FLANGE ROTATION (in-service)[deg]  Thet1 =',F15.3/
C    $'     ---------------------------------------------------------')
C1310 FORMAT(
C    $5X, 'RIGIDITY FACTOR (INTEGRAL TYPE)       KI =',F15.2/
C    $5X, 'FLEXIBILITY FACTOR (initial)          J0 =',F15.3/
C    $5X, 'FLEXIBILITY FACTOR (in-service)        J =',F15.3/)
C1320 FORMAT(
C    $5X, 'RIGIDITY FACTOR (LOOSE TYPE)          KL =',F15.2/
C    $5X, 'FLEXIBILITY FACTOR (initial)          J0 =',F15.3/
C    $5X, 'FLEXIBILITY FACTOR (in-service)        J =',F15.3/)
C
C
      END
c*******************************************************
      SUBROUTINE STP(OBJROTFL)
	USE mTYPROTFL
      IMPLICIT REAL*8(A-Z)
      INTEGER*4 NBOLT,NDUM,MIO_LEN_TRIM
      CHARACTER*40 ARCHDIR
      CHARACTER*24 D$,E$,M$
      CHARACTER*6 TITOL
	TYPE(typROTFL)::OBJROTFL
!DEC$ OPTIONS /ALIGN=COMMONS=STANDARD
      COMMON/CARA/D$,E$,M$
      INTEGER*2 ITIPOST
      COMMON/WORK1/TEMP,B,A2,T,G0,G1,H,E,EB,M,C0,H0,K0,F,V,X,Y,K,A1,Z,
     *            Z0,EG,TG,FI,ZZZ,YYY,TTT,UUU,LLL,DDD,R1,R2
     *            ,Wm2,Estar,nistar,ts,F1,F3,SpExt,kPTkExt
      COMMON/WORK2/CLP,BLUNG,NBOLT,NDUM,ABOLT,GLP,P,PLP,P0LP,CLCPG,CLCPN
     $,Z1,BB,HHD,HHT,HHG,HD,HT,HG,KB,KG,KF,BBTOT,M1,ITIPOST,ARCHDIR
C
!DEC$ END OPTIONS
      CHARACTER*60 FILARC
      CHARACTER*80 FRMT(30)
      FILARC=ARCHDIR(1:MIO_LEN_TRIM(ARCHDIR))//'\WN5\ROTFL0.WNF'
      OPEN(50,FILE=FILARC,STATUS='OLD')
      IF(B.EQ.0.)THEN
      	IF(Estar.EQ.0.)THEN
             TITOL='COVER '
          ELSE
             TITOL='TUBESH'
	    ENDIF
      ELSE
        TITOL='FLANGE'
      ENDIF
      IF(G0.GT.0..AND.G1.GT.0.)THEN
      CALL FORMA(1,FRMT)
      ELSE
	CALL FORMA(22,FRMT)
	ENDIF
c      WRITE(67,FRMT)OBJROTFL%Intest,OBJROTFL%Norma,TITOL
      WRITE(67,FRMT)TITOL
      CALL FORMA(2,FRMT)
      WRITE(67,FRMT)D$,E$
      IF(G0.GT.0..AND.G1.GT.0.)THEN
         CALL FORMA(3,FRMT)
         WRITE(67,FRMT)M$,TEMP,PLP,B,A2,T,G0,G1,H,E,EB,CLCPN,M1
         CALL FORMA(4,FRMT)
            WRITE(67,FRMT)M1/(R2-R1),C0,H0,K0,F,V
            FILARC=ARCHDIR(1:MIO_LEN_TRIM(ARCHDIR))//'\RTF\FIG1.RTF'
            CALL FIGUR(FILARC)
            CALL FORMA(10,FRMT)
            WRITE(67,FRMT)X
            FILARC=ARCHDIR(1:MIO_LEN_TRIM(ARCHDIR))//'\RTF\FIG2.RTF'
            CALL FIGUR(FILARC)
            CALL FORMA(11,FRMT)
            WRITE(67,FRMT)Y
            FILARC=ARCHDIR(1:MIO_LEN_TRIM(ARCHDIR))//'\RTF\FIG3.RTF'
            CALL FIGUR(FILARC)
            CALL FORMA(12,FRMT)
            WRITE(67,FRMT)K
            FILARC=ARCHDIR(1:MIO_LEN_TRIM(ARCHDIR))//'\RTF\FIG4.RTF'
            CALL FIGUR(FILARC)
            CALL FORMA(13,FRMT)
            WRITE(67,FRMT)A1
            FILARC=ARCHDIR(1:MIO_LEN_TRIM(ARCHDIR))//'\RTF\FIG5.RTF'
            CALL FIGUR(FILARC)
            CALL FORMA(14,FRMT)
            WRITE(67,FRMT)Z,Z0
      ELSEIF(B.GT.0.)THEN
         CALL FORMA(6,FRMT)
         WRITE(67,FRMT)M$,TEMP,PLP,B,A2,T,E,EB,CLCPN,M1
         CALL FORMA(7,FRMT)
         WRITE(67,FRMT)Z,Z0
      ELSE
        IF(Estar.EQ.0.)THEN
	   CALL FORMA(8,FRMT)
         WRITE(67,FRMT)M$,TEMP,PLP,A2,GLP,T,E,EB,CLCPN
         CALL FORMA(9,FRMT)
         WRITE(67,FRMT)
         FILARC=ARCHDIR(1:MIO_LEN_TRIM(ARCHDIR))//'\RTF\FIG6.RTF'
         CALL FIGUR(FILARC)
         CALL FORMA(15,FRMT)
         WRITE(67,FRMT)Z,Z0
	  ELSE
	   CALL FORMA(16,FRMT)
         WRITE(67,FRMT)M$,TEMP,PLP,A2,CLP,GLP,T,SpExt,ts,
     1	   E,EB,CLCPN,Estar,nistar
         CALL FORMA(17,FRMT)
         WRITE(67,FRMT)
         FILARC=ARCHDIR(1:MIO_LEN_TRIM(ARCHDIR))//'\RTF\FIG7.RTF'
         CALL FIGUR(FILARC)
         CALL FORMA(18,FRMT)
         WRITE(67,FRMT)F
         FILARC=ARCHDIR(1:MIO_LEN_TRIM(ARCHDIR))//'\RTF\FIG8.RTF'
         CALL FIGUR(FILARC)
         CALL FORMA(19,FRMT)
         WRITE(67,FRMT)F1
         FILARC=ARCHDIR(1:MIO_LEN_TRIM(ARCHDIR))//'\RTF\FIG9.RTF'
         CALL FIGUR(FILARC)
         CALL FORMA(19,FRMT)
         WRITE(67,FRMT)F3
         FILARC=ARCHDIR(1:MIO_LEN_TRIM(ARCHDIR))//'\RTF\FIG10.RTF'
         CALL FIGUR(FILARC)
         CALL FORMA(19,FRMT)
         WRITE(67,FRMT)kPTkExt
         CALL FORMA(21,FRMT)
         WRITE(67,FRMT)K,HG
         CALL FORMA(20,FRMT)
         WRITE(67,FRMT)Z,Z0
	  ENDIF
      ENDIF
      CLOSE(50)
      RETURN
      END
C*************************************************************************
      SUBROUTINE CASM
C     **************************************
C     ** fattori di forma per flange ASME **
C     **************************************
      IMPLICIT REAL*8(A-Z)
!DEC$ OPTIONS /ALIGN=COMMONS=STANDARD
      COMMON/WORK1/TEMP,B,A2,T,G0,G1,H,E,EB,M,C0,H0,K0,F,V,X,Y,K,A1,Z,
     *            Z0,EG,TG,FI,ZZZ,YYY,TTT,UUU,LLL,DDD,R1,R2
     *            ,Wm2,Estar,nistar,ts,F1,F3,SpExt,kPTkExt
!DEC$ END OPTIONS
      A=(G1/G0)-1
      C=43.68*(H/H0)**4
      C1=1/3.+A/12
      C2=5/42.+17*A/336
      C3=1/210.+A/360
      C4=11/360.+59*A/5040+(1+3*A)/C
      C5=1/90.+5*A/1008-(1+A)**3/C
      C6=1/120.+17*A/5040+1/C
      C7=215/2772.+51*A/1232+(60/7.+225*A/14+75*A**2/7+5*A**3/2)/C
      C8=31/6930.+128*A/45045.+(6/7.+15*A/7+12*A**2/7+5*A**3/11)/C
      C9=533/30240.+653*A/73920.+(.5+33*A/14+39*A**2/28+25*A**3/84)/C
      C10=29/3780.+3*A/704-(.5+33*A/14+81*A**2/28+13*A**3/12)/C
      C11=31/6048.+1763*A/665280.+(.5+6*A/7+15*A**2/28+5*A**3/42)/C
      C12=1/2925.+71*A/300300.+(8/35.+18*A/35+156*A**2/385+6*A**3/55)/C
      C13=761/831600.+937*A/1663200.+(1/35.+6*A/35+11*A**2/70+3*A**3/70)
     X    /C
      C14=197/415800.+103*A/332640.-(1/35.+6*A/35+17*A**2/70+A**3/10)/C
      C15=233/831600.+97*A/554400.+(1/35.+3*A/35+A**2/14+2*A**3/105)/C
      C16=C1*C7*C12+C2*C8*C3+C3*C8*C2-(C3**2*C7+C8**2*C1+C2**2*C12)
      C17=(C4*C7*C12+C2*C8*C13+C3*C8*C9-(C13*C7*C3+C8**2*C4+C12*C2*C9))
     X    /C16
      C18=(C5*C7*C12+C2*C8*C14+C3*C8*C10-(C14*C7*C3+C8**2*C5+C12*C2*C10)
     X    )/C16
      C19=(C6*C7*C12+C2*C8*C15+C3*C8*C11-(C15*C7*C3+C8**2*C6+C12*C2*C11)
     X    )/C16
      C20=(C1*C9*C12+C4*C8*C3+C3*C13*C2-(C3**2*C9+C13*C8*C1+C12*C4*C2))
     X    /C16
      C21=(C1*C10*C12+C5*C8*C3+C3*C14*C2-(C3**2*C10+C14*C8*C1+C12*C5*C2
     X    ))/C16
      C22=(C1*C11*C12+C6*C8*C3+C3*C15*C2-(C3**2*C11+C15*C8*C1+C12*C6*C2
     X    ))/C16
      C23=(C1*C7*C13+C2*C9*C3+C4*C8*C2-(C3*C7*C4+C8*C9*C1+C2**2*C13))
     X    /C16
      C24=(C1*C7*C14+C2*C10*C3+C5*C8*C2-(C3*C7*C5+C8*C10*C1+C2**2*C14))
     X    /C16
      C25=(C1*C7*C15+C2*C11*C3+C6*C8*C2-(C3*C7*C6+C8*C11*C1+C2**2*C15))
     X    /C16
      C26=-(C/4)**0.25
      C27=C20-C17-5/12.+C17*C26
      C28=C22-C19-1/12.+C19*C26
      C29=-(C/4.)**0.50
      C30=-(C/4.)**0.75
      C31=3*A/2-C17*C30
      C32=0.5-C19*C30
      C33=.5*C26*C32+C28*C31*C29-(.5*C30*C28+C32*C27*C29)
      C34=1/12.+C18-C21-C18*C26
      C35=-C18*(C/4)**0.75
      C36=(C28*C35*C29-C32*C34*C29)/C33
      C37=(.5*C26*C35+C34*C31*C29-(.5*C30*C34+C35*C27*C29))/C33
      E1=C17*C36+C18+C19*C37
      E2=C20*C36+C21+C22*C37
      E3=C23*C36+C24+C25*C37
      E4=0.25+C37/12+C36/4-E3/5-3*E2/2-E1
      E5=E1*(0.5+A/6)+E2*(0.25+11*A/84)+E3*(1/70.+A/105)
      E6=E5-C36*(7./120.+A/36+3*A/C)-1./40.-A/72-C37*(1./60.+A/120.+1/C)
      F=-(E6/((C/2.73)**0.25*((1+A)**3/C)))
      FL=-(C18*(.5+A/6)+C21*(.25+11*A/84)+C24*(1/70.+A/105)-(1/40.+A/72)
     X   )/((C/2.73)**0.25*((1+A)**3/C))
      V=E4/((2.73/C)**0.25*(1+A)**3)
      VL=(1/4.-C24/5-3*C21/2-C18)/((2.73/C)**0.25*(1+A)**3)
      FMIN=C36/(1+A)

      RETURN
      END
C******************************************************************************
      SUBROUTINE FICO (KB, KG, KF, HD, HT, HG, B, GLP, H1T, FI)

      IMPLICIT REAL*8(A-Z)

C-----------------------------------------------------------------
C     Calculates FI-coefficient :
C
C        HHG = W0 - FI * HH
C        W = W0 + (1 - FI) * HH         where : HH = PIGR/4 * GLP ** 2 * PLP
C-----------------------------------------------------------------

      ALPHA = (KB + KG)/KG
      BETA = HG*HG * KB/KF
      X = (B/GLP)**2.
      H1T = X*HD + (1. - X)*HT

      FI = (1. + BETA*H1T/HG)/(ALPHA + BETA)

      RETURN
      END
C******************************************************************************
      SUBROUTINE INPUT1(objROTFL)
	USE mTYPROTFL
      IMPLICIT REAL*8(A-Z)
      CHARACTER*24 D$,E$,M$
      CHARACTER*30 DUMMY$
      CHARACTER*40 ARCHDIR
!DEC$ OPTIONS /ALIGN=COMMONS=STANDARD
      COMMON/CARA/D$,E$,M$
      INTEGER*4 NBOLT,NDUM
      INTEGER*2 ITIPOST
      COMMON/WORK1/TEMP,B,A2,T,G0,G1,H,E,EB,M,C0,H0,K0,F,V,X,Y,K,A1,Z,
     *            Z0,EG,TG,FI,ZZZ,YYY,TTT,UUU,LLL,DDD,R1,R2
     *            ,Wm2,Estar,nistar,ts,F1,F3,SpExt,kPTkExt
      COMMON/WORK2/CLP,BLUNG,NBOLT,NDUM,ABOLT,GLP,P,PLP,P0LP,CLCPG,CLCPN
     $,Z1,BB,HHD,HHT,HHG,HD,HT,HG,KB,KG,KF,BBTOT,M1,ITIPOST,ARCHDIR
!DEC$ END OPTIONS

      TYPE(typROTFL)::objROTFL
	D$=     objROTFL%Arch
      E$=     objROTFL%Membr
      M$=     objROTFL%Mater
      TEMP=   objROTFL%Temp
      B=      objROTFL%DiamInt
      A2=     objROTFL%DiamExt
      T=      objROTFL%Spess
      G0=     objROTFL%g0
      G1=     objROTFL%g1
      H=      objROTFL%hub
      EB=     objROTFL%E0
	E=      objROTFL%E1
  993 IF(EB.EQ.0.)EB=E
      CLCPN=  objROTFL%W
      PLP=    objROTFL%Press
      CLP=    objROTFL%BC
      BLUNG=  objROTFL%BoltL
      NBOLT=  objROTFL%BoltN
      ABOLT=  objROTFL%BoltA
      GLP=    objROTFL%Gef
      BB=     objROTFL%b0
      BBTOT=  objROTFL%N
      EG=     objROTFL%EE
      TG=     objROTFL%SpGuar
	Wm2=    objROTFL%Wm2
	Estar=  objROTFL%Estar
	nistar= objROTFL%nistar
      ts=     objROTFL%ts
	SpExt=  objROTFL%SpExt
      RETURN
      END
C******************************************************************************
      SUBROUTINE FORMA(I,FRMT)
      INTEGER*4 I,K,MIO_LEN_TRIM
      CHARACTER*80 FRMT(1),RIGA
      REWIND 50
      DO 22 K=1,I
      DO 2 WHILE (RIGA(1:4).NE.'stop')
    2 READ(50,100)RIGA
   22 READ(50,100)RIGA
      BACKSPACE 50
      DO 3 K=1,30
      READ(50,100)FRMT(K) 
      IF(FRMT(K)(1:4).EQ.'stop')GOTO5
    3 CONTINUE
    5 DO 6 KK=K,30
      DO 6 KKK=1,80
    6 FRMT(KK)(KKK:KKK)=' '
      RETURN
  100 FORMAT(A80)
      END
C******************************************************************************
      SUBROUTINE FIGUR(FILARC)
      CHARACTER*60 FILARC
      CHARACTER*255 RIGA
	INTEGER*2 K
      OPEN(58,FILE=FILARC)
      DO 2 WHILE(.TRUE.)
      READ(58,100,END=1)RIGA
    2 WRITE(67,101)(RIGA(K:K),K=1,MIO_LEN_TRIM(RIGA))
    1 CLOSE(58)
      RETURN
  100 FORMAT(A255)
  101 FORMAT(255A1)
      END
C**************************************************************************
	SUBROUTINE CalcF1F3
C  ASME-VIII div.2 App. 4-540 Fattori F1 F3  
      IMPLICIT REAL*8(A-Z)
!DEC$ OPTIONS /ALIGN=COMMONS=STANDARD
      COMMON/WORK1/TEMP,B,A2,T,G0,G1,H,E,EB,M,C0,H0,K0,F,V,X,Y,K,A1,Z,
     *            Z0,EG,TG,FI,ZZZ,YYY,TTT,UUU,LLL,DDD,R1,R2
     *            ,Wm2,Estar,nistar,ts,F1,F3,SpExt,kPTkExt
      COMMON/WORK2/CLP,BLUNG,NBOLT,NDUM,ABOLT,GLP,P,PLP,P0LP,CLCPG,CLCPN
     $,Z1,BB,HHD,HHT,HHG,HD,HT,HG,KB,KG,KF,BBTOT,M1,ITIPOST,ARCHDIR
!DEC$ END OPTIONS
	F=ts*2/GLP/Estar
	F1=3*(1-nistar)*(2-F*F)*(1-F)**2*(8-F*(4-F)*(1-nistar))/16/(2-F)
	F3=3./8.*(1-nistar)*(2-F)*(8-F*(4-F)*(1-nistar))
	RETURN	
	END