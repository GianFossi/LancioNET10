C ----------------------------------------------------------------------
C     - SUBROUTINE LETBAN - 84                                        
C ----------------------------------------------------------------------
      SUBROUTINE LETBAN(STAMPA)
	LOGICAL*2 STAMPA                                              
C....!DEC$ ATTRIBUTES DLLEXPORT::LETBAN
      INCLUDE 'SELVA.FI'
C-------------------------------
	INTEGER*2 LB,KB,K,I,J
C-------------------------------
      DO 35969 LB=1,100
      DO 35999 KB=1,4
      IF(LB.LT.26)              NAMX(LB,KB)=NAM1(KB,LB)
      IF(LB.GE.26.AND.LB.LT.51) NAMX(LB,KB)=NAM2(KB,LB-25)
      IF(LB.GE.51.AND.LB.LT.76) NAMX(LB,KB)=NAM3(KB,LB-50)
      IF(LB.GE.76)              NAMX(LB,KB)=NAM4(KB,LB-75)
35999 CONTINUE
35969 CONTINUE
	DO 35 K=1,NCST
      I=K
      IF(I.EQ.NCST.AND.KW.NE.0) I=NCW
      J=NCOD(I)
      GO TO(5,1),KCRT !1:costanti critiche RPS 2:altre
    1 CONTINUE
      NAME(I,1)=NAMX(J,1)
      NAME(I,2)=NAMX(J,2)
      NAME(I,3)=NAMX(J,3)
      NAME(I,4)=NAMX(J,4)
      NAME(I,5)=NAMX(J,5)
      M(I)=XXMW(J)
      TC(I)=XXTCS(J)
      PC(I)=XXPCS(J)
      ZC(I)=XXZC(J)
      OMEGA(I)=XXWS(J)
      ZRA(I)=XXZRA(J)
      SPG(I)=XXSPG(J) !Specific Gravity
      TD(I)=XXTD(J)
      PD(I)=XXPD(J)
      BP(I)=XXBP(J)
CXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
      IF(STAMPA)CALL STAMPAT(I)
CXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
      TC(I)=TC(I)/1.8
      PC(I)=PC(I)/14.696
      GO TO 10
    5 CONTINUE
      NAME(I,1)=NAMX(J,1)
      NAME(I,2)=NAMX(J,2)
      NAME(I,3)=NAMX(J,3)
      NAME(I,4)=NAMX(J,4)
      NAME(I,5)=NAMX(J,5)
C     WRITE(3,88721) I,(NAME(I,KB),KB=1,5)
      M(I)=XXMW(J)
      TC(I)=XXTC(J)
      PC(I)=XXPC(J)
      ZC(I)=XXZC(J)
      OMEGA(I)=XOMEGA(J)
      ZRA(I)=XXZRA(J)
      SPG(I)=XXSPG(J) !Specific Gravity
      TD(I)=XXTD(J)
      PD(I)=XXPD(J)
      BP(I)=XXBP(J)
CXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
      IF(STAMPA)CALL STAMPAT(I)
CXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
   10 GO TO (20,25,30),IM
   20 CONTINUE
      A(I)=XXA(J)
      B(I)=XXB(J)
      C(I)=XXC(J)
      D(I)=XXD(J)
      E(I)=XXE(J)
      AI(I)=XXAA1(J)
      BI(I)=XXBB1(J)
      CI(I)=XXCC1(J)
      DI(I)=XXDD1(J)
      EI(I)=XXEE1(J)
CXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
      IF(STAMPA)THEN
c	WRITE(IO,44003) A(I),B(I),C(I),D(I),E(I),AI(I),BI(I),CI(I),DI(I),
c     *EI(I)
	WRITE(IO,44003) A(I),B(I),C(I),D(I),E(I),AI(I),BI(I),CI(I),DI(I),
     *EI(I)
      ENDIF
CXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
      GO TO 31
   25 CONTINUE
      A(I)=XXAA(J)
      B(I)=XXBB(J)
      C(I)=XXCC(J)
      D(I)=XXDD(J)
CXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
      IF(STAMPA)WRITE(IO,44004) A(I),B(I),C(I),D(I)
CXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
      GO TO 31
   30 CONTINUE
      IF(T.GT.TLIM) GO TO 56006
      A(I)=XXA1(J)
      B(I)=XXA2(J)
      C(I)=XXA3(J)
      D(I)=XXA4(J)
      GO TO 56007
56006 CONTINUE
      A(I)=XXB1(J)
      B(I)=XXB2(J)
      C(I)=XXB3(J)
      D(I)=XXB4(J)
56007 CONTINUE
CXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
      IF(STAMPA)WRITE(IO,44005) A(I),B(I),C(I),D(I)
CXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
      B(I)=2*B(I)
      C(I)=3*C(I)
      D(I)=4*D(I)
   31 CONTINUE
      PARAK(I)=XXPA(J)
      SIGMA(I)=XXSIG(J)
      EPSUK(I)=XXESUK(J)
      DELTA(I)=XXDEL(J)
      VVB(I)=XXVVB(J)
      VVT0(I)=XXVVTO(J)
      A1CON(I)=XXCTA1(J)
      A2CON(I)=XXCTA2(J)
      A3CON(I)=XXCTA3(J)
      AH(I)=XXAH(J)
      DELH(I)=XXDELH(J)
CXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
      IF(STAMPA)THEN
      WRITE(IO,44006) PARAK(I),SIGMA(I),EPSUK(I),DELTA(I),VVB(I),VVT0(I)
     *,A1CON(I),A2CON(I),A3CON(I),AH(I),DELH(I)
      ENDIF
CXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
   35 CONTINUE
      IF(STAMPA.AND.KIJ.GT.0)CALL STAMPAK(INT(I/14)+1)
      RETURN
c44001 FORMAT(' FORMAT 1'5X,5A4/
c     *' M        ',E15.7/
c     *' TC       ',E15.7/
c     *' PC       ',E15.7/
c     *' ZC       ',E15.7/
c     *' OMEGA    ',E15.7/
c     *' ZRA      ',E15.7/
c     *' SPG      ',E15.7/
c     *' TD       ',E15.7/
c     *' PD       ',E15.7/
c     *' BP       ',E15.7/)
c44002 FORMAT(' FORMAT 2'5X,5A4/
c     *' M        ',E15.7/
c     *' TC       ',E15.7/
c     *' PC       ',E15.7/
c     *' ZC       ',E15.7/
c     *' OMEGA    ',E15.7/
c     *' ZRA      ',E15.7/
c     *' SPG      ',E15.7/
c     *' TD       ',E15.7/
c     *' PD       ',E15.7/
c     *' BP       ',E15.7/)
44003 FORMAT(26X,'|',10(E10.4,'|'))
C44003 FORMAT(' FORMAT 3'/
C     *' A        ',E15.7/
C     *' B        ',E15.7/
C     *' C        ',E15.7/
C     *' D        ',E15.7/
C     *' E        ',E15.7/
C     *' AI       ',E15.7/
C     *' BI       ',E15.7/
C     *' CI       ',E15.7/
C     *' DI       ',E15.7/
C     *' EI       ',E15.7/)
44004 FORMAT(26X,'|',4(E10.4,'|'))
C4004 FORMAT(' FORMAT 4'/
C    *' A        ',E15.7/
C    *' B        ',E15.7/
C    *' C        ',E15.7/
C    *' D        ',E15.7)
44005 FORMAT(26X,'|',4(E10.4,'|'))
44006 FORMAT(15X,'|',11(E10.4,'|'))
C4005 FORMAT(' FORMAT 3'/
C    *' A        ',E15.7/
C    *' B        ',E15.7/
C    *' C        ',E15.7/
C    *' D        ',E15.7)
C44006 FORMAT(' FORMAT 3'/
C     *' PARAK    ',E15.7/
C     *' SIGMA    ',E15.7/
C     *' EPSUK    ',E15.7/
C     *' DELTA    ',E15.7/
C     *' VVB      ',E15.7/
C     *' VVT0     ',E15.7/
C     *' A1CON    ',E15.7/
C     *' A2CON    ',E15.7/
C     *' A3CON    ',E15.7/
C     *' AH       ',E15.7/
C     *' DELH     ',E15.7)
      END
	SUBROUTINE STAMPAT(I)
	INTEGER*2 I
	INCLUDE 'SELVA.FI'
      IF(MOD(I,14).EQ.1)THEN
	WRITE(IO,100)INT(I/14)+1
	WRITE(IO,54001)
	IF(IM.EQ.1)THEN
	WRITE(IO,54003)
	ELSEIF(IM.EQ.2)THEN
	WRITE(IO,54004)
	ELSE
	WRITE(IO,54005)
	ENDIF
	WRITE(IO,54006)
	ENDIF
      WRITE(IO,44001)I,NAME(I,1),NAME(I,2),NAME(I,3),NAME(I,4),NAME(I,5)
     *,M(I),TC(I),PC(I),ZC(I),OMEGA(I),ZRA(I),SPG(I),TD(I),PD(I),BP(I)
	RETURN
  100 FORMAT('1FBM-Hudson Italiana S.p.A. - Program WALD -',
     *'Library printout',T120,'Page',I3/)
44001 FORMAT(1X,I3,') ',5A4,'|',2X,F6.2,2X,'|',
     *2(2X,F6.1,2X,'|'),4(2X,F6.4,2X,'|'),
     *3(2X,F6.2,2X,'|'))
54001 FORMAT(6X,'Componente',10X,'|    M     |    Tc    |    Pc    |',
     * '    Zc    |  Omega   |',
     * '  ZRA     |  SPG     |  TD      |  PD      |  BP      |')
54003 FORMAT(26X,'|    A     |    B     |    C     |    D     |',
     *            '    E     |',
     *            '    AI    |    BI    |    CI    |    DI    |',
     *            '    EI    |')
54004 FORMAT(26X,'|    A     |    B     |    C     |    D     |')
54005 FORMAT(26X,'|    A     |    B     |    C     |    D     |')
54006 FORMAT(15X,'|  PARAK   |  SIGMA   |  EPSUK   |  DELTA   |',
     *            '   VVB    |   VVT0   |',
     *            '  A1CON   |  A2CON   |  A3CON   |    AH    |',
     *            '   DELH   |')
	END
	SUBROUTINE STAMPAK(ipage)
      INTEGER*2 ipage
	INCLUDE 'SELVA.FI'
C----------------------------------
	INTEGER*2 I,J
C----------------------------------
      ipage=ipage+1
	WRITE(IO,100)ipage
	WRITE(IO,44000)
	DO 1 I=1,NCW
	DO 1 J=I+1,NCW
	IF(KAPPA(I,J).NE.0.)WRITE(IO,44001)I,
     *NAME(I,1),NAME(I,2),NAME(I,3),NAME(I,4),NAME(I,5),J,
     *NAME(J,1),NAME(J,2),NAME(J,3),NAME(J,4),NAME(J,5),
     *KAPPA(I,J)
    1 CONTINUE 
	RETURN
  100 FORMAT('1FBM-Hudson Italiana S.p.A. - Program WALD -',
     *'Library printout. Binary constants',T120,'Page',I3/)
44000 FORMAT(//'  Component 1 ',T26,'  Component 2 ',
     *T51,'|Constant|')
44001 FORMAT(2(1X,I3,') ',5A4),1X,'|',F8.4,'|')
	END