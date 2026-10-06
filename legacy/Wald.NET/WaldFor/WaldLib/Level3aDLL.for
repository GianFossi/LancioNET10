C ----------------------------------------------------------------------
C     - SUBROUTINE STANDA - 66
C ----------------------------------------------------------------------
      SUBROUTINE STANDA(RISULT)
	LOGICAL*2 RISULT
	INCLUDE 'GENERAL.FI'
C	CHARACTER*4 NAME
C      COMMON/NCODEX/NCOD(50),NAME(50,5),NCST,NCNST,NCIP,NC,NCW
C      COMMON/INDEX/KBDF,KE,KU,KHS,KW
	INCLUDE 'DETTAGLI.FI'
C      COMMON/HFASE/HF,Q,HL,HV,DPHL,DPHV,DTHL,DTHV,DXHL(50),DYHV(50)
C      COMMON/SFASE/SF,SL,SV,DPSL,DPSV,DTSL,DTSV,DXSL(50),DYSV(50)
C      COMMON/KVALUE/DTK(50),DPK(50),DXK(50,50),DYK(50,50),K(50)
C      COMMON/SPECIF/AL(50),AV(50),BL(50),BV(50),Cspec,Dspec,Espec
	INCLUDE 'INCR1.FI'
C      COMMON/INCR/DT,D1T,DP,D1P,DX(50),DY(50),DLAMDA
	INCLUDE 'SOLUZ.FI'
C      COMMON/MOLFR/X(50),Y(50),Z(50),ZN(50,2),SOMM(2)
	INCLUDE 'WATER.FI'
C      COMMON/WATER/HWL,DTHWL,DPHWL,SWL,DTSWL,DPSWL
	INCLUDE 'FER.FI'
C      COMMON/FER/F(50),FI(50),SNOR,GI,ERRE,SGI,SGR
C      COMMON/PARTIZ/LAMDA,MU,NU,YW
C      REAL LAMDA,MU,NU,K
C      COMMON/TEMPRE/TINP,PINP,T,P
C      COMMON/SYSTEM/IN,IO,KDOS,MDOS,LDOS,NDOS,NUOVER,NOUTP3,KCONV,IDEBUG
C--------------------------------------------------
      REAL Aloc(50),Bloc(50),A1(50),B1(50),AA(50,4),BB(50,4),BETA(50)
	REAL SOMMA(3,4),ALF(3,3),ETA(3),SOLUZ(3)
	REAL ALFA,SOMloc,SOM1,SOM2
	INTEGER*2 I,J,JJ
C------------------------------------------------------
	RISULT=.TRUE.
      DO 1 J=1,4
      DO 1 I=1,50
      AA(I,J)=0.
    1 BB(I,J)=0.
      DO 2 J=1,4
      DO 2 I=1,3
    2 SOMMA(I,J)=0.
      DO 3 J=1,3
      ETA(J)=0.
      DO 3 I=1,3
    3 ALF(I,J)=0.
      GO TO (24,24,24,5,79),KE
    5 GO TO (6,13,20,20),KU
    6 GO TO(7,9,11),KBDF
    7 SOMloc=0.
      DO 8 I=1,NC
      SOMloc=SOMloc+(X(I)*DPK(I))
      Aloc(I)=0.
      A1(I)=0.
      Bloc(I)=-(P**2*X(I)*DPK(I))
      B1(I)=-FI(I)
    8 CONTINUE
      DT=0.
      DLAMDA=0.
      ALFA=SNOR/(P**2*SOMloc)
C	WRITE(IO,'(''8''3E12.5)')SNOR,SOMloc,P
      D1P=ALFA
      GO TO 22
    9 SOMloc=0.
      DO 10 I=1,NC
C     SCHEDE MANCANTI DA DISKETTE INSERITE A MANO BOZZETTI 7.10.86
      SOMloc=SOMloc+(Y(I)/K(I)**2)*DPK(I)
      Bloc(I)=0.
      B1(I)=0.
C-----------------------------------------------------------------------
      Aloc(I)=-X(I)/K(I)*DPK(I)
      A1(I)=FI(I)/K(I)
   10 CONTINUE
      DT=0.
      DLAMDA=0.
      ALFA=SNOR/SOMloc
C	WRITE(IO,'(''10''2E12.5)')SNOR,SOMloc
      DP=ALFA
      GO TO 22
  11  SOM1=0.
      SOM2=0.
      DO 12 I=1,NC
      BETA(I)=LAMDA*K(I)+1-LAMDA-MU
      Aloc(I)=-(LAMDA/BETA(I)*X(I)*DPK(I))
      A1(I)=-F(I)/BETA(I)+LAMDA*FI(I)/BETA(I)
      Bloc(I)=(1.-LAMDA-MU)/BETA(I)*X(I)*DPK(I)
      B1(I)=-(F(I)*K(I)/BETA(I))-(1-LAMDA-MU)/BETA(I)*FI(I)
      SOM1=SOM1+B1(I)-A1(I)
      SOM2=SOM2+Bloc(I)-Aloc(I)
   12 CONTINUE
      DT=0.
      DLAMDA=0.
      ALFA=(-SNOR-SOM1)/SOM2
C	WRITE(IO,'(''12''3E12.5)')SNOR,SOM1,SOM2
      DP=ALFA
      GO TO 22
   13 GO TO (14,16,18),KBDF
   14 SOM1=0.
      SOM2=0.
      DO 15 I=1,NC
      Aloc(I)=0.
      A1(I)=0.
      Bloc(I)=-(T**2*X(I)*DTK(I))
      B1(I)=-FI(I)
      SOM1=SOM1+X(I)*DTK(I)
      SOM2=SOM2+K(I)*X(I)
   15 CONTINUE
      DP=0.
      DLAMDA=0.
      ALFA=SNOR/((T**2*SOM1)/(SOM2+YW))
C	WRITE(IO,'(''15''5E12.5)')SNOR,SOM1,SOM2,YW
      D1T=ALFA
      GO TO 22
   16 SOM1=0.
      SOM2=0.
      DO 17 I=1,NC
      SOM1=SOM1+Y(I)/K(I)**2*DTK(I)
C	WRITE(IO,'(''**DTK**''E12.5)')DTK(I)
      SOM2=SOM2+Y(I)/K(I)
      Aloc(I)=T**2/K(I)*X(I)*DTK(I)
      A1(I)=FI(I)/K(I)
      Bloc(I)=0.
      B1(I)=0.
  17  CONTINUE
      DP=0.
      DLAMDA=0.
	IF(SOM1*SOM2.NE.0.)THEN
      ALFA=-SNOR /(T**2*SOM1/SOM2)
	ENDIF
C	WRITE(IO,'(''17''4E12.5)')SNOR,SOM1,SOM2,T
      D1T=ALFA
      GO TO 22
  18  SOM1=0.
      SOM2=0.
      DO 19 I=1,NC
      BETA(I)=LAMDA*K(I)+1-LAMDA-MU
      Aloc(I)=-(LAMDA/BETA(I)*X(I)*DTK(I))
      A1(I)=-F(I)/BETA(I)+LAMDA*FI(I)/BETA(I)
      Bloc(I)=(1.-LAMDA-MU)/BETA(I)*X(I)*DTK(I)
      B1(I)=-(F(I)*K(I)/BETA(I))-(1-LAMDA-MU)/BETA(I)*FI(I)
      SOM1=SOM1+B1(I)-A1(I)
      SOM2=SOM2+Bloc(I)-Aloc(I)
  19  CONTINUE
      DP=0.
      DLAMDA=0.
      ALFA=(-SNOR-SOM1)/SOM2
C	WRITE(IO,'(''19''3E12.5)')SNOR,SOM1,SOM2
      DT=ALFA
      GO TO 22
  20  SOMloc=0.
      DO 21 I=1,NC
      BETA(I)=LAMDA*K(I)+1.-LAMDA-MU
      Aloc(I)=-(Y(I)-X(I))/BETA(I)
      A1(I)=-F(I)/BETA(I)+LAMDA/BETA(I)*FI(I)
      Bloc(I)=-K(I)/BETA(I)*(Y(I)-X(I))
      B1(I)=-(F(I)*K(I)/BETA(I))-(1.-LAMDA-MU)/BETA(I)*FI(I)
      SOMloc=SOMloc+(Z(I)*(K(I)-1.)*(K(I)-1.))/(BETA(I)*BETA(I))
  21  CONTINUE
      DP=0.
      DT=0.
      ALFA=SNOR/SOMloc
C	WRITE(IO,'(''22''2E12.5)')SNOR,SOMloc
      DLAMDA=ALFA
  22  CONTINUE
      DO 23 I=1,NC
      DX(I)=Aloc(I)*ALFA+A1(I)
C	WRITE(IO,'(''STANDA''4E12.5)')DX(I),Aloc(I),ALFA,A1(I)
  23  DY(I)=Bloc(I)*ALFA+B1(I)
      GO TO 90
  24  CONTINUE
      DO 50 I=1,NC
      BETA(I)=LAMDA*K(I)+1.-LAMDA-MU
      DO 50 J=1,4
      IF(KE.EQ.1) GO TO 29
      IF(KBDF.EQ.1) GO TO 34
      IF(J.EQ.KU) GO TO 34
  29  GO TO (30,31,32,33),J
  30  AA(I,J)=-(LAMDA/BETA(I)*X(I)*DTK(I))
      GO TO 34
  31  AA(I,J)=-(LAMDA/BETA(I)*X(I)*DPK(I))
      GO TO 34
  32  AA(I,J)=-(1./BETA(I)*(Y(I)-X(I)))
      GO TO 34
  33  AA(I,J)=-F(I)/BETA(I)+LAMDA*FI(I)/BETA(I)
  34  IF(KBDF.EQ.2) GO TO 39
      IF(J.EQ.KU) GO TO 39
      GO TO (35,36,37,38),J
  35  BB(I,J)=(1.-LAMDA-MU)/BETA(I)*X(I)*DTK(I)
      GO TO 39
  36  BB(I,J)=(1.-LAMDA-MU)/BETA(I)*X(I)*DPK(I)
      GO TO 39
  37  BB(I,J)=-(K(I)/BETA(I)*(Y(I)-X(I)))
      GO TO 39
  38  BB(I,J)=-K(I)*F(I)/BETA(I)-(1.-LAMDA-MU)/BETA(I)*FI(I)
  39  CONTINUE
      DO 50 JJ=1,3
      GO TO (40,41,44),JJ
  40  SOMMA(JJ,J)=SOMMA(JJ,J)+(BB(I,J)-AA(I,J))
      GO TO 50
  41  IF(KHS.EQ.0) GO TO 50
      GO TO (42,43),KHS
  42  SOMMA(JJ,J)=SOMMA(JJ,J)+(LAMDA*DYHV(I)*BB(I,J)+(1.-LAMDA-MU)*DXHL(
     *I)*AA(I,J))
      GO TO 50
  43  SOMMA(JJ,J)=SOMMA(JJ,J)+(LAMDA*DYSV(I)*BB(I,J)+(1.-LAMDA-MU)*DXSL(
     *I)*AA(I,J))
      GO TO 50
  44  IF(KE.GT.2) GO TO 50
      SOMMA(JJ,J)=SOMMA(JJ,J)+(AV(I)*LAMDA+BV(I))*BB(I,J)/(1.-Cspec*YW)
     *	+(AL(I)*(1.-LAMDA-MU)+BL(I))*AA(I,J)
      IF(J.EQ.3) SOMMA(JJ,J)=SOMMA(JJ,J)+(AV(I)*Y(I)/(1.-Cspec*YW)
     *	-AL(I)*X(I))
  50  CONTINUE
      DO 63 JJ=1,3
      DO 63 J=1,3
      IF(KE.EQ.1) GO TO 51
      IF(JJ.EQ.KE.AND.J.NE.KU) GO TO 63
      IF(JJ.NE.KE.AND.J.EQ.KU) GO TO 63
      IF(JJ.EQ.KE.AND.J.EQ.KU) GO TO 47
  51  GO TO (52,53,62),JJ
  52  ALF(JJ,J)=SOMMA(JJ,J)
      GO TO 63
   53 IF(KHS.EQ.0) GO TO 63
      GO TO (54,56),KHS
  54  GO TO (55,58,60),J
  55  ALF(JJ,J)=SOMMA(JJ,J)+(LAMDA*DTHV+(1.-LAMDA-MU)*DTHL+MU*DTHWL)
      GO TO 63
  56  GO TO (57,59,61),J
  57  ALF(JJ,J)=SOMMA(JJ,J)+(LAMDA*DTSV+(1.-LAMDA-MU)*DTSL+MU*DTSWL)
      GO TO 63
  58  ALF(JJ,J)=SOMMA(JJ,J)+(LAMDA*DPHV+(1.-LAMDA-MU)*DPHL+MU*DPHWL)
      GO TO 63
  59  ALF(JJ,J)=SOMMA(JJ,J)+(LAMDA*DPSV+(1.-LAMDA-MU)*DPSL+MU*DPSWL)
      GO TO 63
  60  ALF(JJ,J)=SOMMA(JJ,J)+(HV-HL)
      GO TO 63
  61  ALF(JJ,J)=SOMMA(JJ,J)+(SV-SL)
      GO TO 63
  62  IF(KE.GT.2) GO TO 63
      ALF(JJ,J)=SOMMA(JJ,J)
      GO TO 63
   47 ALF(KE,KU)=1.
  63  CONTINUE
      DO 70 JJ=1,3
      IF(KE.EQ.1)  GO TO 64
      IF(JJ.EQ.KE) GO TO 70
  64  GO TO (65,66,69),JJ
  65  ETA(JJ)=-SNOR-SOMMA(JJ,4)
      GO TO 70
   66 IF(KHS.EQ.0) GO TO 70
  67  ETA(JJ)=-GI-SOMMA(JJ,4)
      GO TO 70
  69  IF(KE.GT.2) GO TO 70
      ETA(JJ)=-ERRE-SOMMA(JJ,4)
  70  CONTINUE
      CALL SISLIN(ALF,ETA,SOLUZ,3,3,RISULT)
	IF(.NOT.RISULT)THEN
	   IF(IDEBUG.GE.4)WRITE(IO,2000)
	   RETURN
      ENDIF
      DT=SOLUZ(1)
      DP=SOLUZ(2)
      DLAMDA=SOLUZ(3)
      DO 72 I=1,NC
      DX(I)=AA(I,1)*DT+AA(I,2)*DP+AA(I,3)*DLAMDA+AA(I,4)
  72  DY(I)=BB(I,1)*DT+BB(I,2)*DP+BB(I,3)*DLAMDA+BB(I,4)
      GO TO 90
  79  CONTINUE
      GO TO (80,85),KHS
  80  GO TO (81,83),KU
  81  DT=0.
      DLAMDA=0.
      DO 82 I=1,NC
      DX(I)=0.
  82  DY(I)=0.
      IF(KBDF.EQ.1) DP=-GI/((1.-MU)*DPHL+MU*DPHWL)
      IF(KBDF.EQ.2) DP=-GI/DPHV
      GO TO 90
  83  DP=0.
      DLAMDA=0.
      DO 84 I=1,NC
      DX(I)=0.
  84  DY(I)=0.
      IF(KBDF.EQ.1) DT=-GI/((1.-MU)*DTHL+MU*DTHWL)
      IF(KBDF.EQ.2) DT=-GI/DTHV
      GO TO 90
  85  GO TO (86,88),KU
  86  DT=0.
      DLAMDA=0.
      DO 87 I=1,NC
      DX(I)=0.
  87  DY(I)=0.
      IF(KBDF.EQ.1)  DP=-GI/((1.-MU)*DPSL+MU*DPSWL)
      IF(KBDF.EQ.2)  DP=-GI/DPSV
      GO TO 90
  88  DP=0.
      DLAMDA=0.
      DO 89 I=1,NC
      DX(I)=0.
  89  DY(I)=0.
      IF(KBDF.EQ.1)  DT=-GI/((1.-MU)*DTSL+MU*DTSWL)
      IF(KBDF.EQ.2)  DT=-GI/DTSV
   90 RETURN
 2000 FORMAT('       444 SUBROUTINE STANDA 444. SISLIN ha dato esito neg
     1ativo.')
      END
C----------------------------------------------------------------------
C     - SUBROUTINE STANDW - 2
C----------------------------------------------------------------------
      SUBROUTINE STANDW(RISULT)
	LOGICAL*2 RISULT
	INCLUDE 'GENERAL.FI'
C	CHARACTER*4 NAME
C      COMMON/NCODEX/NCOD(50),NAME(50,5),NCST,NCNST,NCIP,NC,NCW
C      COMMON/INDEX/KBDF,KE,KU,KHS,KW
	INCLUDE 'DETTAGLI.FI'
C      COMMON/HFASE/HF,Q,HL,HV,DPHL,DPHV,DTHL,DTHV,DXHL(50),DYHV(50)
C      COMMON/SFASE/SF,SL,SV,DPSL,DPSV,DTSL,DTSV,DXSL(50),DYSV(50)
C      COMMON/SPECIF/AL(50),AV(50),BL(50),BV(50),Cspec,Dspec,Espec
	INCLUDE 'SOLUZ.FI'
C      COMMON/MOLFR/X(50),Y(50),Z(50),ZN(50,2),SOMM(2)
	INCLUDE 'WATER.FI'
C      COMMON/WATER/HWL,DTHWL,DPHWL,SWL,DTSWL,DPSWL
	INCLUDE 'FERW.FI'
C      COMMON/FERW/F(50),FW,FIW,GW,RW,SGW,SRW
	INCLUDE 'INCRW1.FI'
C      COMMON/INCRW/DY(50),DYW,DT,DP,DLAMDA
C      COMMON/PARTIZ/LAMDA,MU,NU,YW
C      REAL LAMDA,MU,NU
C      COMMON/TEMPRE/TINP,PINP,T,P
C      COMMON/SYSTEM/IN,IO,KDOS,MDOS,LDOS,NDOS,NUOVER,NOUTP3,KCONV,IDEBUG
C------------------------------------------------------
      REAL ALFA(3,3),ETA(3),SOLUZ(3),Bloc(4),Aloc(50,4)
	REAL SOMloc,SOM1,SOM2,PW,DTPW
	INTEGER*2 I,J,K1
C------------------------------------------------------
	RISULT=.TRUE.
      DO 1 J=1,3
      ETA(J)=0.
      DO 1 I=1,3
    1 ALFA(I,J)=0.
      DO 2  J=1,4
      Bloc(J)=0.
      DO 2  I=1,NCW
    2 Aloc(I,J)=0.
      CALL TENVAP(PW,DTPW,T,1,1)
      ALFA(1,1)=-DTPW/P
      ALFA(1,2)=PW/(P*P)
      ALFA(1,3)=(1.-YW)/LAMDA
      ETA(1)=-FIW+FW/LAMDA
      SOM1=0.
      SOM2=0.
      IF(KHS.NE.1) GO TO 8
      ALFA(2,1)=LAMDA*DTHV+(1.-LAMDA)*DTHWL
      ALFA(2,2)=LAMDA*DPHV+(1.-LAMDA)*DPHWL
      DO 6 I=1,NC
      SOM1=SOM1+Y(I)*DYHV(I)
    6 SOM2=SOM2+F(I)*DYHV(I)
      ALFA(2,3)=HV-HWL-SOM1+(1.-YW)*DYHV(NCW)
      ETA(2)=-GW +SOM2+FW*DYHV(NCW)
    8 IF(KHS.NE.2) GO TO 10
      ALFA(2,1)=LAMDA*DTSV+(1.-LAMDA)*DTSWL
      ALFA(2,2)=LAMDA*DPSV+(1.-LAMDA)*DPSWL
      DO 9 I=1,NC
      SOM1=SOM1+Y(I)*DYSV(I)
    9 SOM2=SOM2+F(I)*DYSV(I)
      ALFA(2,3)=SV-SWL-SOM1+(1.-YW)*DYSV(NCW)
      ETA(2)=-GW +SOM2+FW*DYSV(NCW)
   10 SOMloc=0.
      DO 12 I=1,NC
   12 SOMloc=SOMloc+BV(I)*Z(I)
      ALFA(3,3)=(Cspec*(RW-Dspec*YW+Espec)+
     *	Dspec*(1-Cspec*YW))*(1.-YW)-SOMloc/LAMDA
      ETA(3)=-RW*LAMDA*(1.-Cspec*YW)+FW*
     *	(Cspec*(RW-Dspec*YW+Espec)+Dspec*(1.-Cspec*YW))
      IF(KE.EQ.1) GO TO 16
      IF(KBDF.EQ.2) GO TO 22
   16 DO 18 I=1,NC
      Aloc(I,3)=-Y(I)/LAMDA
   18 Aloc(I,4)=-F(I)/LAMDA
      Bloc(3)=(1.-YW)/LAMDA
      Bloc(4)=-FW/LAMDA
      IF(KE.EQ.1) GO TO 30
      DO 20 I=1,NC
   20 Aloc(I,KU)=0.
      Bloc(KU)=0.
   22 ALFA(KE,KU)=1.
      DO 25 I=1,3
      IF(I.EQ.KU) GO TO 24
      ALFA(KE,I)=0.
   24 IF(I.EQ.KE) GO TO 25
      ALFA(I,KU)=0.
   25 CONTINUE
      ETA(KE)=0.
   30 CONTINUE
      CALL SISLIN(ALFA,ETA,SOLUZ,3,3,RISULT)
	IF(.NOT.RISULT)THEN
	   IF(IDEBUG.GE.4)WRITE(IO,2000)
	   RETURN
      ENDIF
      DT=SOLUZ(1)
      DP=SOLUZ(2)
      DLAMDA=SOLUZ(3)
      DO 35 I=1,NC
   35 DY(I)=Aloc(I,1)*DT+Aloc(I,2)*DP+Aloc(I,3)*DLAMDA+Aloc(I,4)
      DYW=Bloc(1)*DT+Bloc(2)*DP+Bloc(3)*DLAMDA+Bloc(4)
      RETURN
 2000 FORMAT('       444 SUBROUTINE STANDW 444. SISLIN ha dato esito neg
     1ativo.')
      END
C ---------------------------------------------------------------------
C     - SUBROUTINE TERMOW - 7
C ---------------------------------------------------------------------
      SUBROUTINE TERMOW(NCR)
	INTEGER*2 NCR
	INCLUDE 'GENERAL.FI'
C-----------------------------------------
	INTEGER*2 K1,K2
C------------------------------------------
      K1=2
      K2=2
      GO TO(5,10),IEQ
    5 CALL SOAVEH(K1,K2,NCR)
      CALL SOAVEW
      GO TO 15
   10 CALL PENROH(K1,K2,NCR)
      CALL PENROW
   15 RETURN
      END
C ----------------------------------------------------------------------
C     - SUBROUTINE THERMO - 69
C ----------------------------------------------------------------------
      SUBROUTINE THERMO(NCR)
	INTEGER*2 NCR
	INCLUDE 'GENERAL.FI'
	INCLUDE 'ACRISI.FI'
C      COMMON/ACRISI/ICR,ICC,ICK,KSTOP,ISTOP2,IP1,IP2
	INCLUDE 'WATER.FI'
C      COMMON/WATER/HWL,DTHWL,DPHWL,SWL,DTSWL,DPSWL
C      COMMON/INDEX/KBDF,KE,KU,KHS,KW
C-------------------------------------------------
	INTEGER*2 K1,K2
C-------------------------------------------------
	IF(IDEBUG.GE.4)WRITE(IO,2000)NCR,IEQ
      HWL=0.
      SWL=0.
      DTHWL=0.
      DPHWL=0.
      DTSWL=0.
      DPSWL=0.
      K1=1
      K2=2
      IF(KE.NE.5) GO TO 3
      GO TO (1,2),KBDF
    1 K2=1
      GO TO 3
    2 K1=2
    3 IF(IEQ.EQ.1) CALL SOAVEH(K1,K2,NCR)
      IF(IEQ.EQ.2) CALL PENROH(K1,K2,NCR)
      IF(ICR.NE.0.OR.KW.EQ.0.OR.KHS.EQ.0.OR.KBDF.EQ.2)RETURN
      IF(IEQ.EQ.1) CALL SOAVEW
      IF(IEQ.EQ.2) CALL PENROW
      RETURN
 2000 FORMAT(T15,'444 THERMO 444 - Entrata. NCR=',I3,',IEQ=',I3)
      END

