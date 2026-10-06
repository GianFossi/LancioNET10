C ----------------------------------------------------------------------
C     - FUNCTION SUMMAT - 18
C ----------------------------------------------------------------------
      FUNCTION SUMMAT(X,Y,NO,N)
      DIMENSION X(50),Y(50),NO(50)
      SOM=0.
      DO 1 I=1,N
      J=NO(I)
    1 SOM=SOM+X(J)*Y(J)
      SUMMAT=SOM
      RETURN
      END
C ----------------------------------------------------------------------
C     - FUNCTION CLU - 20
C ----------------------------------------------------------------------
      FUNCTION CLU(TR,PR)
      COMMON/CLUBLO/B0,B1,B2,B3,B4
      DIMENSION B0(4),B1(4),B2(4),B3(4),B4(4),A(4)
C      DATA B0 /1.6368,-1.9693,2.4638,-1.5841/,
C     *     B1 /-0.04615,0.21874,-0.36461,0.25136/,
C     *     B2 /2.1138E-3,-8.0028E-3,12.8763E-3,-11.3805E-3/,
C     *     B3 /-0.7845E-5,-8.2328E-5,14.8059E-5,9.5672E-5/,
C     *     B4 /-0.6923E-6,5.2604E-6,-8.6895E-6,2.1812E-6/
      DO 1 I=1,4
    1 A(I)=B0(I)+B1(I)*PR+B2(I)*PR*PR+B3(I)*PR*PR*PR+B4(I)*PR*PR*PR*PR
      CLU=A(1)+A(2)*TR+A(3)*TR*TR+A(4)*TR*TR*TR
      RETURN
      END
C ----------------------------------------------------------------------
C     - SUBROUTINE CALMAX - 78
C ----------------------------------------------------------------------
      SUBROUTINE CALMAX(V,N,VMAX,I)
      DIMENSION V(50)
      VMAX=0.
      I=0
      DO 1 K=1,N
      IF(ABS(V(K)).LE.ABS(VMAX))GO TO 1
      VMAX=V(K)
      I=K
    1 CONTINUE
      RETURN
      END
C ----------------------------------------------------------------------
C     - SUBROUTINE CRICOV - 77
C ----------------------------------------------------------------------
      SUBROUTINE CRICOV(ITEST)
	CHARACTER*4 NAME
      COMMON/OPTION/BINAR(50,50),KIJ,IEQ,IM,ISUP,KCRT,KWRT,VL,IOPT1
      COMMON/NCODEX/NCOD(50),NAME(50,5),NCST,NCNST,NCIP,NC,NCW
      COMMON/FER/F(50),FI(50),SNOR,GI,ERRE,SGI,SGR
      COMMON/INDEX/KBDF,KE,KU,KHS,KW
      COMMON/COMPRS/ZCR,ZV,ZL,ZLW
      ITEST=0
      IF(KE.EQ.5) GO TO 15
      IF(KBDF.LT.3) GO TO 5
      DO 1 I=1,NC
      IF(ABS(F(I)).GE.VL) RETURN
    1 CONTINUE
    5 DO 10 I=1,NC
      IF(ABS(FI(I)).GE.VL) RETURN
   10 CONTINUE
      IF(ABS(SNOR).GE.VL) RETURN
   15 IF(KHS.EQ.0) GO TO 20
      IF(ABS(GI).GE.(SGI*VL)) RETURN
   20 IF(KE.GT.2) GO TO 25
      IF(ABS(ERRE).GE.(SGR*VL)) RETURN
   25 GO TO(30,30,30,30,35),KE
   30 IF(ABS(ZV-ZL).LE..001) GO TO 55
      GO TO 50
   35 GO TO(40,45),KBDF
   40 CONTINUE
      GO TO 50
   45 CONTINUE
   50 ITEST=1
      RETURN
   55 ITEST=2
      RETURN
      END
C ---------------------------------------------------------------------
C     - SUBROUTINE CRICOW - 3
C ---------------------------------------------------------------------
      SUBROUTINE CRICOW(ITEST)
      COMMON/OPTION/BINAR(50,50),KIJ,IEQ,IM,ISUP,KCRT,KWRT,VL,IOPT1
      COMMON/FERW/F(50),FW,FIW,GW,RW,SGW,SRW
      COMMON/INDEX/KBDF,KE,KU,KHS,KW
      ITEST=0
      IF(KBDF.EQ.2) GO TO 10
      IF(ABS(FW).GE.VL) GO TO 30
   10 IF(ABS(FIW).GE.VL) GO TO 30
      IF(ABS(GW).GE.(VL*SGW)) GO TO 30
      IF(KE.GT.2) GO TO 20
      IF(ABS(RW).GE.(VL*SRW)) GO TO 30
   20 ITEST=1
   30 RETURN
      END
C ----------------------------------------------------------------------
C     - SUBROUTINE CRISI1 - 79
C ----------------------------------------------------------------------
      SUBROUTINE CRISI1(IFASE)
      COMMON/ACRISI/ICR,ICC,ICK,KSTOP,ISTOP2,IP1,IP2
      COMMON/INDEX/KBDF,KE,KU,KHS,KW
      GO TO (1,1,1,1,2),KE
    2 CALL CRISI5(KU,KBDF)
      GO TO 6
    1 GO TO (3,3,3,5),KU
    3 GO TO (4,5,5),ICC
    4 CALL CRISI3(IFASE,KU)
      GO TO 6
    5 CALL CRISIK
    6 RETURN
      END
C ----------------------------------------------------------------------
C     - SUBROUTINE CRISI2 - 50
C ----------------------------------------------------------------------
      SUBROUTINE CRISI2(TETA,TETAMN,IPAS1,ISTOP1,KSTOP)
      IF(IPAS1) 1,1,2
    1 TETA=TETA/5.
      IF(TETA.GT.TETAMN) GO TO 6
      TETA=1.
      KSTOP=1
      GO TO 6
    2 ISTOP1=1
      GO TO (3,4,5),IPAS1
    3 TETA=TETA/2.
      GO TO 6
    4 TETA=2*TETA/3.
      GO TO 6
    5 TETA=3*TETA/4.
    6 RETURN
      END
C ----------------------------------------------------------------------
C     - SUBROUTINE CRISI3 - 53
C ----------------------------------------------------------------------
      SUBROUTINE CRISI3(IFASE,KU)
      COMMON/ACRISI/ICR,ICC,ICK,KSTOP,ISTOP2,IP1,IP2
      COMMON/TEMPRE/TINP,PINP,T,P
      DATA TMAX,TMIN,PMAX,PMIN/1500.,50.,1000.,0.001/
      ICR=2
      GO TO (55,1,1),KU
    1 GO TO(25,5),IFASE
    5 IP2=1
C     WRITE(6,'('' CRISI30,IFASE,IP1,IP2''3I5,E12.5)')IFASE,IP1,IP2,T
      IF(IP1)10,10,15
   10 T1=T
      T=T+40.
      T2=T
      IF(T-TMAX)100,100,45
   15 T1=T
      DELTA=(T2-T1)/2.
      IF(DELTA-0.5)50,20,20
   20 T=T+DELTA
      GO TO 100
   25 IP1=1
C     WRITE(6,'('' CRISI31,IFASE,IP1,IP2''3I5,E12.5)')IFASE,IP1,IP2,T
      IF(IP2)30,30,35
   30 T2=T
      T=T-40.
      T1=T
      IF(T-TMIN)45,100,100
   35 T2=T
      DELTA=(T2-T1)/2.
      IF(DELTA-0.5)50,40,40
   40 T=T-DELTA
      GO TO 100
   45 ICC=2
      T=TINP
      P=PINP
      GO TO 100
   50 ICC=3
      T=T2
      GO TO 100
   55 GO TO (60,75),IFASE
   60 IP1=1
      IF(IP2)65,65,70
   65 P1=P
      P=P*1.33
      P2=P
      IF(P-PMAX)100,100,45
   70 P1=P
      DELTA=(P2-P1)/2.
      IF(DELTA.LT.(0.01*P)) GO TO 90
      P=P+DELTA
      GO TO 100
   75 IP2=1
      IF(IP1)80,80,85
   80 P2=P
      P=P*0.75
      P1=P
      IF(P-PMIN)45,100,100
   85 P2=P
      DELTA=(P2-P1)/2.
      IF(DELTA.LT.(0.01*P)) GO TO 90
      P=P-DELTA
      GO TO 100
   90 ICC=3
      P=P1
  100 CONTINUE
C     WRITE(6,'('' RET CRISI3,T''4E12.5)')T,T1,T2,DELTA
      RETURN
      END
C ----------------------------------------------------------------------
C     - SUBROUTINE CRISI5 - 51
C ----------------------------------------------------------------------
      SUBROUTINE CRISI5(KU,KBDF)
      COMMON/ACRISI/ICR,ICC,ICK,KSTOP,ISTOP2,IP1,IP2
      COMMON/TEMPRE/TINP,PINP,T,P
      DATA TMAX,TMIN,PMAX,PMIN/1500.,50.,1000.,0.001/
      GO TO (5,8),KU
    5 GO TO (6,7) ,KBDF
    6 P=1.2*P
      IF(P.LE.PMAX) GO TO 12
      GO TO 11
    7 P=0.8*P
      IF(P.GE.PMIN) GO TO 12
      GO TO 11
    8 GO TO (9,10),KBDF
    9 T=0.9*T
      IF(T.GE.TMIN) GO TO 12
      GO TO 11
   10 T=1.1*T
      IF(T.LE.TMAX) GO TO 12
   11 KSTOP=1
      T=TINP
      P=PINP
   12 WRITE(6,'('' CRISI5,T=''E12.5)')T
      RETURN
      END
C ----------------------------------------------------------------------
C     - SUBROUTINE CRISIK - 52
C ----------------------------------------------------------------------
      SUBROUTINE CRISIK
      REAL K
	CHARACTER*4 NAME
      COMMON/NCODEX/NCOD(50),NAME(50,5),NCST,NCNST,NCIP,NC,NCW
      COMMON/KVALUE/DTK(50),DPK(50),DXK(50,50),DYK(50,50),K(50)
      COMMON/ACRISI/ICR,ICC,ICK,KSTOP,ISTOP2,IP1,IP2
      COMMON/TEMPRE/TINP,PINP,T,P
      ICR=1
      KCONT=0
      ICK=ICK+1
      IF(ICK.GT.10) GO TO 5
      DO 3 I=1,NC
      K(I)=K(I)*K(I)
      IF(K(I).LT.1.E5) GO TO 2
      K(I)=1.E5
      KCONT=KCONT+1
    2 IF(K(I).GT.1.E-5) GO TO 3
      K(I)=1.E-5
      KCONT=KCONT+1
    3 CONTINUE
      IF(KCONT.EQ.NC) ICK=10
      GO TO 9
    5 GO TO (8,8,7),ICC
    7 P=PINP
      T=TINP
      ICK=0
      ICC=2
      ICR=2
      GO TO 9
    8 KSTOP=1
      ICR=2
    9 RETURN
      END
C ----------------------------------------------------------------------
C     - SUBROUTINE DECREM - 81
C ----------------------------------------------------------------------
      SUBROUTINE DECREM
      REAL LAMDA,MU,NU
	CHARACTER*4 NAME
      COMMON/NCODEX/NCOD(50),NAME(50,5),NCST,NCNST,NCIP,NC,NCW
      COMMON/INCR1/DEX(50),DEY(50),DET,DE1T,DEP,DE1P,DELAMD
      COMMON/MOLFR/X(50),Y(50),Z(50),ZN(50,2),SUM(2)
      COMMON/INDEX/KBDF,KE,KU,KHS,KW
      COMMON/PARTIZ/LAMDA,MU,NU,YW
      COMMON/TEMPRE/TINP,PINP,T,P
      DO 1 I=1,NC
      X(I)=X(I)-DEX(I)
    1 Y(I)=Y(I)-DEY(I)
      LAMDA=LAMDA-DELAMD
      IF(KE.EQ.4.AND.KU.EQ.2.AND.KBDF.NE.3) GO TO 2
      T=T-DET
      GO TO 4
    2 T=1./(1./T-DE1T)
    4 IF(KE.EQ.4.AND.KU.EQ.1.AND.KBDF.EQ.1) GO TO 5
      P=P-DEP
      GO TO 6
    5 P=1./(1./P-DE1P)
    6 RETURN
      END
C ---------------------------------------------------------------------
C     - SUBROUTINE DECREW - 10
C ---------------------------------------------------------------------
      SUBROUTINE DECREW
      REAL LAMDA,MU,NU
	CHARACTER*4 NAME
      COMMON/NCODEX/NCOD(50),NAME(50,5),NCST,NCNST,NCIP,NC,NCW
      COMMON/MOLFR/X(50),Y(50),Z(50),ZN(50,2),SUM(2)
      COMMON/INCRW1/DEY(50),DEYW,DET,DEP,DELAMD
      COMMON/PARTIZ/LAMDA,MU,NU,YW
      COMMON/TEMPRE/TINP,PINP,T,P
      T=T-DET
      P=P-DEP
      LAMDA=LAMDA-DELAMD
      YW=YW-DEYW
      DO 1 I=1,NC
    1 Y(I)=Y(I)-DEY(I)
      Y(NCW)=YW
      RETURN
      END
C ----------------------------------------------------------------------
C     - SUBROUTINE ELI1 - 39
C ----------------------------------------------------------------------
      SUBROUTINE ELI1(TR,DENPAR,PARCP,AH,DELH,BP,COTL0)
      DELS = DELH/BP+1.9872*ALOG(273./BP)
      COTL0=360.*(((88.-4.94*AH)*1.E-3)/DELS)*(.55/TR)*PARCP*
     *DENPAR**1.333333
      RETURN
      END
C ----------------------------------------------------------------------
C     - SUBROUTINE ELI2 - 40
C ----------------------------------------------------------------------
      SUBROUTINE ELI2 (TR,PR,PR1,COTL0,COTAUS)
      DIMENSION VPR(2),C(2),C1(2),C2(2)
      POL1(X,Y)=(((1.7245*X-1.54365)*X+.49454)*Y)/(((((-5.44583*X+
     *10.39583)*X-6.16004)*X+1.09049)*X+.07539)*Y+1.)+(-5.875*X-3.225)*
     *X+16.48
      POL2(X,Y)=(((((1.51820*X-5.12647)*X+6.49088)*X-3.65201)*X+.770375
     *)*1.E4*Y)/(((((.693267*X-2.35315)*X+2.99428)*X-1.69275)*X+.358717
     *)*1.E4*Y+1)+(-28.125*X+32.125)*X+2.44
      VPR(1)=PR1
      VPR(2)=PR
      DO 10 I=1,2
      IF(TR.LT..4) GO TO 9
      IF(TR.LE..8) GO TO 8
      C(I)=POL2(TR,VPR(I))
      GO TO 10
    8 C(I)=POL1(TR,VPR(I))
      GO TO 10
    9 C1(I)=POL1(.4,VPR(I))
      C2(I)=POL1(.5,VPR(I))
      C(I)=C1(I)+10*(C2(I)-C1(I))*(TR-.4)
   10 CONTINUE
      COTAUS=COTL0*C(2)/C(1)
      RETURN
      END
C ----------------------------------------------------------------------
C     - SUBROUTINE ENTALP - 71
C ----------------------------------------------------------------------
      SUBROUTINE ENTALP(H0,H0I,DTH0I,DTH0,N1,N,IFASE,IM,IH)
      REAL M,KUOP
 	CHARACTER*4 NAME
      COMMON/HYPOT/KIN,KFIN,A1H(50),A2H(50),A3H(50),KUOP(50),API(50)
      COMMON/BANK1/M(50),TC(50),PC(50),ZC(50),OMEGA(50),BP(50)
      COMMON/NCODEX/NCOD(50),NAME(50,5),NCST,NCNST,NCIP,NC,NCW
      COMMON/MOLFR/X(50),Y(50),Z(50),ZN(50,2),SUM(2)
      COMMON/COEFH/A(50),B(50),C(50),D(50),E(50)
      COMMON/TEMPRE/TINP,PINP,T,P
      DIMENSION H0I(50), DTH0I(50)
      DATA R/1.9872/
      H0=0.
      DTH0=0.
      T1=T*1.8
      T2=T1/100.
      GO TO (1,8,8),IM
    1 GO TO (2,5,2),IH
    2 DO 4 I=N1,N
      J=NCOD(I)
      IF(J.GT.500) GO TO 3
      H0I(I)=(A(I)*T2+B(I)*T2**2+C(I)*T2**3+D(I)/T2+E(I))*M(I)/1.8
      GO TO 4
    3 H0I(I)=(A1H(I)*T1+A2H(I)*T1**2+A3H(I)*T1**3)/1.8
    4 H0=H0+H0I(I)*ZN(I,IFASE)
      IF(IH-3)15,5,15
    5 DO 7 I=N1,N
      J=NCOD(I)
      IF(J.GT.500) GO TO 6
      DTH0I(I)=(A(I)+2*B(I)*T2+3*C(I)*T2**2-D(I)/T2**2)*M(I)/100.
      GO TO 7
    6 DTH0I(I)=(A1H(I)+2*A2H(I)*T1+3*A3H(I)*T1**2)
    7 DTH0=DTH0+DTH0I(I)*ZN(I,IFASE)
      GO TO 15
    8 GO TO (9,12,9),IH
    9 DO 11 I=N1,N
      J=NCOD(I)
      IF(J.GT.500)GO TO 10
      H0I(I)=A(I)*T+B(I)*T**2/2.+C(I)*T**3/3.+D(I)*T**4/4.
      GO TO 11
   10 H0I(I)=(A1H(I)*T1+A2H(I)*T1**2+A3H(I)*T1**3)/1.8
   11 H0=H0+H0I(I)*ZN(I,IFASE)
      IF(IH-3)15,12,15
   12 DO 14 I=N1,N
      J=NCOD(I)
      IF(J.GT.500)GO TO 13
      DTH0I(I)=(A(I)+B(I)*T+C(I)*T**2+D(I)*T**3)
      GO TO 14
   13 DTH0I(I)= A1H(I)+2*A2H(I)*T1+3*A3H(I)*T1**2
   14 DTH0=DTH0 +DTH0I(I)*ZN(I,IFASE)
   15 RETURN
      END
C ----------------------------------------------------------------------
C     - SUBROUTINE ENTROP - 72
C ----------------------------------------------------------------------
      SUBROUTINE ENTROP(S0,S0I,DTS0I,DTS0,N1,N,IFASE,IM,IS)
      REAL M,KUOP
	CHARACTER*4 NAME
      COMMON/HYPOT/KIN,KFIN,A1H(50),A2H(50),A3H(50),KUOP(50),API(50)
      COMMON/BANK1/M(50),TC(50),PC(50),ZC(50),OMEGA(50),BP(50)
      COMMON/NCODEX/NCOD(50),NAME(50,5),NCST,NCNST,NCIP,NC,NCW
      COMMON/COEFS/AI(50),BI(50),CI(50),DI(50),EI(50)
      COMMON/MOLFR/X(50),Y(50),Z(50),ZN(50,2),SUM(2)
      COMMON/COEFH/A(50),B(50),C(50),D(50),E(50)
      COMMON/TEMPRE/TINP,PINP,T,P
      DIMENSION S0I(50), DTS0I(50)
      DATA R/1.9872/
      S0=0.
      DTS0=0.
      T1=T*1.8
      T2=(T1-459.67)/100.
      GO TO (1,8,8),IM
    1 GO TO (2,5,2),IS
    2 DO 4 I=N1,N
      J=NCOD(I)
      IF(J.GT.500) GO TO 3
      S0I(I)=(AI(I)*T2+BI(I)*T2**2+CI(I)*T2**3+DI(I)*T2**4+0.4342944819*
     *EI(I)*ALOG(T1)+1.)*M(I)
      GO TO 4
    3 S0I(I)=A1H(I)*ALOG(T1/1.8)+2*A2H(I)*(T1-1.8)+1.5*A3H(I)*(T1-1.8)*
     *(T1+1.8)
    4  S0=S0+(S0I(I)-R*ALOG(ZN(I,IFASE)))*ZN(I,IFASE)
      IF(IS-3)15,5,15
    5 DO 7 I=N1,N
      J=NCOD(I)
      IF(J.GT.500) GO TO 6
      DTS0I(I)= ((AI(I)+2*BI(I)*T2+3*CI(I)*T2**2+4*DI(I)*T2**3)/100.+
     *0.4342944819*EI(I)/T1)*M(I)*1.8
      GO TO 7
    6 DTS0I(I)= (A1H(I)/T1+2*A2H(I)+3*A3H(I)*T1)*1.8
    7 DTS0=DTS0+DTS0I(I)*ZN(I,IFASE)
      GO TO 15
    8 GO TO (9,12,9),IS
    9 DO 11 I=N1,N
      J=NCOD(I)
      IF(J.GT.500) GO TO 10
      S0I(I)=A(I)*ALOG(T)+B(I)*(T-1.)+0.5*C(I)*(T**2-1.)+1./3.*D(I)*(T**
     *3-1.)
      GO TO 11
   10 S0I(I)=A1H(I)*ALOG(T1/1.8)+2*A2H(I)*(T1-1.8)+1.5*A3H(I)*(T1-1.8)*
     *(T1+1.8)
   11 S0=S0+(S0I(I)-R*ALOG(ZN(I,IFASE)))*ZN(I,IFASE)
      IF(IS-3)15,12,15
   12 DO 14 I=N1,N
      J=NCOD(I)
      IF(J.GT.500) GO TO 13
      DTS0I(I)=A(I)/T+B(I)+C(I)*T+D(I)*T**2
      GO TO 14
   13 DTS0I(I)= (A1H(I)/T1+2*A2H(I)+3*A3H(I)*T1)*1.8
   14 DTS0=DTS0+DTS0I(I)*ZN(I,IFASE)
   15 RETURN
      END
C ----------------------------------------------------------------------
C     - SUBROUTINE FATNOR - 76
C ----------------------------------------------------------------------
      SUBROUTINE FATNOR
	CHARACTER*4 NAME
      COMMON/HFASE/HF,Q,HL,HV,DPHL,DPHV,DTHL,DTHV,DXHL(50),DYHV(50)
      COMMON/SFASE/SF,SL,SV,DPSL,DPSV,DTSL,DTSV,DXSL(50),DYSV(50)
      COMMON/NCODEX/NCOD(50),NAME(50,5),NCST,NCNST,NCIP,NC,NCW
      COMMON/SPECIF/AL(50),AV(50),BL(50),BV(50),C,D,E
      COMMON/WATER/HWL,DTHWL,DPHWL,SWL,DTSWL,DPSWL
      COMMON/FER/F(50),FI(50),SNOR,GI,ERRE,SGI,SGR
      COMMON/INDEX/KBDF,KE,KU,KHS,KW
      SGI=1.
      SGR=1.
      IF(KHS.NE.1) GO TO 2
      SGI=AMAX1(ABS(HV),ABS(HL),ABS(HF),ABS(Q),ABS(HWL))
    2 IF(KHS.NE.2) GO TO 4
      SGI=AMAX1(ABS(SV),ABS(SL),ABS(SF),ABS(SWL))
    4 IF(KE.GT.2) GO TO 7
      SGR=0.
      SGR=AMAX1(ABS(D),ABS(E),SGR)
      DO 5 I=1,NC
    5 SGR =AMAX1(ABS(AV(I)),ABS(BV(I)),ABS(AL(I)),ABS(BL(I)),SGR)
    7 RETURN
      END
C ---------------------------------------------------------------------
C     - SUBROUTINE FERWAT - 4
C ---------------------------------------------------------------------
      SUBROUTINE FERWAT
      REAL LAMDA,MU,NU
	CHARACTER*4 NAME
      COMMON/HFASE/HF,Q,HL,HV,DPHL,DPHV,DTHL,DTHV,DXHL(50),DYHV(50)
      COMMON/SFASE/SF,SL,SV,DPSL,DPSV,DTSL,DTSV,DXSL(50),DYSV(50)
      COMMON/NCODEX/NCOD(50),NAME(50,5),NCST,NCNST,NCIP,NC,NCW
      COMMON/SPECIF/AL(50),AV(50),BL(50),BV(50),C,D,E
      COMMON/MOLFR/X(50),Y(50),Z(50),ZN(50,2),SUM(2)
      COMMON/WATER/HWL,DTHWL,DPHWL,SWL,DTSWL,DPSWL
      COMMON/FERW/F(50),FW,FIW,GW,RW,SGW,SRW
      COMMON/INDEX/KBDF,KE,KU,KHS,KW
      COMMON/PARTIZ/LAMDA,MU,NU,YW
      COMMON/TEMPRE/TINP,PINP,T,P
      DO 5 I=1,NCW
    5 F(I)=0.
      FW=0.
      FIW=0.
      GW=0.
      RW=0.
      IF(KBDF.EQ.2) GO TO 15
      DO 10 I=1,NC
   10 F(I)=LAMDA*Y(I)-Z(I)
      FW=(1.-LAMDA)+LAMDA*YW-Z(NCW)
   15 CALL TENVAP(PW,DTPW,T,1,0)
      FIW=YW-PW/P
      IF(KHS.NE.1) GO TO 20
      GW=LAMDA*HV+(1.-LAMDA)*HWL-Q-HF
   20 IF(KHS.NE.2) GO TO 25
      GW =LAMDA*SV+(1.-LAMDA)*SWL-SF
   25 IF(KE.GT.2) GO TO 35
      SOM=0.
      DO 30 I=1,NC
   30 SOM=SOM+(AV(I)*LAMDA+BV(I))*Z(I)
      RW=SOM/(LAMDA*(1.-C*YW))+D*YW-E
   35 CONTINUE
      RETURN
      END
C ---------------------------------------------------------------------
C     - SUBROUTINE FOBWAT - 6
C ---------------------------------------------------------------------
      SUBROUTINE FOBWAT(FOBW)
      COMMON/FERW/F(50),FW,FIW,GW,RW,SGW,SRW
      COMMON/INDEX/KBDF,KE,KU,KHS,KW
      SOM=0.
      IF(KBDF.EQ.2) GO TO 1
      SOM=SOM+ABS(FW)
    1 SOM=SOM+ABS(FIW)
      SOM=SOM+ABS(GW)/SGW
      IF(KE.GT.2) GO TO 5
      SOM=SOM+ABS(RW)/SRW
    5 FOBW=SOM
      RETURN
      END
C ----------------------------------------------------------------------
C     - SUBROUTINE FUNZER - 65
C ----------------------------------------------------------------------
      SUBROUTINE FUNZER
      REAL LAMDA,MU,NU,K
	CHARACTER*4 NAME
      COMMON/HFASE/HF,Q,HL,HV,DPHL,DPHV,DTHL,DTHV,DXHL(50),DYHV(50)
      COMMON/SFASE/SF,SL,SV,DPSL,DPSV,DTSL,DTSV,DXSL(50),DYSV(50)
      COMMON/KVALUE/DTK(50),DPK(50),DXK(50,50),DYK(50,50),K(50)
      COMMON/NCODEX/NCOD(50),NAME(50,5),NCST,NCNST,NCIP,NC,NCW
      COMMON/SPECIF/AL(50),AV(50),BL(50),BV(50),C,D,E
      COMMON/MOLFR/X(50),Y(50),Z(50),ZN(50,2),SUM(2)
      COMMON/WATER/HWL,DTHWL,DPHWL,SWL,DTSWL,DPSWL
      COMMON/FER/F(50),FI(50),SNOR,GI,ERRE,SGI,SGR
      COMMON/INDEX/KBDF,KE,KU,KHS,KW
      COMMON/PARTIZ/LAMDA,MU,NU,YW
      DO 100 I=1,NCW
      F(I)=0.
  100 FI(I)=0.
      SNOR=0.
      GI=0.
      ERRE=0.
      IF(KBDF.EQ.1.OR.KBDF.EQ.2.OR.KE.EQ.5) GO TO 2
      DO 1 I=1,NC
    1 F(I)=LAMDA*Y(I)+(1.-LAMDA-MU)*X(I)-Z(I)
    2 GO TO (24,24,24,3,18),KE
    3 GO TO (4,9,14,14),KU
    4 GO TO (5,7,24),KBDF
    5 SOM=0.
      DO 6 I=1,NC
    6 SOM=SOM+K(I)*X(I)
      SNOR=SOM-1.+YW
      GO TO 16
    7 SOM=0.
      DO 8 I=1,NC
    8 SOM=SOM+Y(I)/K(I)
      SNOR=SOM-1.
      GO TO 16
    9 GO TO (10,12,24),KBDF
   10 SOM=0.
      DO 11 I=1,NC
   11 SOM=SOM+K(I)*X(I)
      SNOR=ALOG(SOM+YW)
      GO TO 16
   12 SOM=0.
      DO 13 I=1,NC
   13 SOM=SOM+Y(I)/K(I)
      SNOR=ALOG(SOM)
      GO TO 16
   14 SOM=0.
      DO 15 I=1,NC
   15 SOM=SOM+Z (I)*(K(I)-1.)/(LAMDA*(K(I)-1.)+1.-MU)
      SNOR=SOM+YW
      GO TO 16
   24 SOM=0.
      DO 25 I=1,NC
   25 SOM=SOM+Y(I)-X(I)
      SNOR=SOM+YW
   16 DO 17 I=1,NC
   17 FI(I)=Y(I)-K(I)*X(I)
   18 IF(KHS.NE.1) GO TO 19
      GI=LAMDA*HV+(1.-LAMDA-MU)*HL+MU*HWL-HF-Q
   19 IF(KHS.NE.2) GO TO 20
      GI=LAMDA*SV+(1.-LAMDA-MU)*SL+MU*SWL-SF
   20 IF(KE.GT.2) GO TO 22
      SOM=0.
      DO 21 I=1,NC
   21 SOM=SOM+(AV(I)*LAMDA+BV(I))*Y(I)/(1.-C*YW)+(AL(I)*(1.-LAMDA-MU)+BL
     *(I))*X(I)
      ERRE=SOM+D*YW-E
   22 RETURN
      END
C ----------------------------------------------------------------------
C     - SUBROUTINE FUNZOB - 75
C ----------------------------------------------------------------------
      SUBROUTINE FUNZOB(FOB)
	CHARACTER*4 NAME
      COMMON/NCODEX/NCOD(50),NAME(50,5),NCST,NCNST,NCIP,NC,NCW
      COMMON/FER/F(50),FI(50),SNOR,GI,ERRE,SGI,SGR
      COMMON/INDEX/KBDF,KE,KU,KHS,KW
      SUM=0.
      IF(KE.EQ.5) GO TO 4
      IF(KBDF.LT.3) GO TO 2
      DO 1 I=1,NC
    1 SUM=SUM+ABS(F(I))
    2 DO 3 I=1,NC
    3 SUM=SUM+ABS(FI(I))
      SUM=SUM+ABS(SNOR)
    4 IF(KHS.EQ.0) GO TO 7
    6 SUM=SUM+ABS(GI)/SGI
    7 IF(KE.GT.2) GO TO 8
      SUM=SUM+ABS(ERRE)/SGR
    8 FOB=SUM
      RETURN
      END
C ----------------------------------------------------------------------
C     - SUBROUTINE GAS1 - 37
C ----------------------------------------------------------------------
      SUBROUTINE GAS1 (WM,TC,PC,TR,A1,A2,A3,COTER)
      CT=TC*1.8
      CP=PC*14.7
      IF(TR.GT.5.) GO TO 1
      AKLT=9.96E-5*(EXP(.0464*TR)-1./EXP(.2412*TR))
      GO TO 2
    1 AKLT=3.02275675E-5+1.37423928E-5*TR-1.2605982E-7*TR**2.
    2 AIX=(A1+(A2+A3*TR)*TR)*TR/100000.
      ALANDA=5.441*WM**.5 *CT**.166667/CP**.666667
      COTER=241.9*(AKLT+AIX)/ALANDA
      COTER=COTER/.671999
      RETURN
      END
C ----------------------------------------------------------------------
C     - SUBROUTINE GAS2 - 38
C ----------------------------------------------------------------------
      SUBROUTINE GAS2 (WM,TC,ZC,VC,VOL,COTER,COTAUS)
      PC=82.057*ZC*TC/VC
      CT=TC*1.8
      CP=PC*14.7
      GAM=5.441*WM**.5*CT**.166667/CP**.666667
      ROR=VC/VOL
      IF(ROR.LE..5) GO TO 1
      IF(ROR.LE.2.) GO TO 2
      IF(ROR.LE.2.8) GO TO 3
      COTAUS=COTER+(2.93520E-4+3.140695E-4*(ROR-2.8))/(GAM*ZC**5.)
      GO TO 4
    1 COTAUS=COTER+5.04E-5*(EXP(.535*ROR)-1.)/(GAM*ZC**5.)
      GO TO 4
    2 COTAUS=COTER+4.716E-5*(EXP(.67*ROR)-1.069)/(GAM*ZC**5.)
      GO TO 4
    3 COTAUS=COTER+1.07136E-5*(EXP(1.155*ROR)+2.016)/(GAM*ZC**5.)
    4 RETURN
      END
C ----------------------------------------------------------------------
C     - SUBROUTINE GFP1 - 43
C ----------------------------------------------------------------------
      SUBROUTINE GFP1(AMUG,WM,CVG,COTER)
      EMUG=AMUG*2.419/10000.
      COTER=(EMUG*CVG/WM)*(3.67/CVG+1.272)
      COTER=COTER/.671999
      RETURN
      END
C ----------------------------------------------------------------------
C     - SUBROUTINE HELPR1 - 42
C ----------------------------------------------------------------------
      SUBROUTINE HELPR1(T,EK,DLT,SIG,WM,AMUG)
      DIMENSION A(6)
      DATA A/1.16145,0.14874,0.52487,0.77320,2.16178,2.43787/
      F=T/EK
      C=A(1)/F**A(2)+A(3)/EXP(A(4)*F)+A(5)/EXP(A(6)*F)+0.2*DLT*DLT/F
      AMUG=26.69*SQRT(WM*T)/(SIG*SIG*C)
      RETURN
      END
C ----------------------------------------------------------------------
C     - SUBROUTINE HELPRO - 41
C ----------------------------------------------------------------------
      SUBROUTINE HELPRO (ZC,TC,PC,TR,WM,ZRA,DENPAR,OM,CIPI0I,PARCP)
      VC=82.057*ZC*TC/PC
      AUSTR=(1.-TR)**.285714
      DENPAR=1./(VC*ZRA**AUSTR)
      AL=-1.+2.*(TR-0.2)/0.7
      DELC0=((((((2.72*AL+6.53499273)*AL+3.20)*AL-3.20874091)*AL-3.73)*
     *AL+7.11374818)*AL+15.75)/3.
      DELC1=((((((18.40*AL-9.578572)*AL-48.80)*AL+26.97321499)*AL+77.65
     *)*AL-65.24464299)*AL+78.9)/3.
      PARCP=CIPI0I+DELC0+OM*DELC1
      RETURN
      END
C ----------------------------------------------------------------------
C     - SUBROUTINE INCREM - 80
C ----------------------------------------------------------------------
      SUBROUTINE INCREM
      REAL LAMDA,MU,NU
	CHARACTER*4 NAME
      COMMON/NCODEX/NCOD(50),NAME(50,5),NCST,NCNST,NCIP,NC,NCW
      COMMON/INCR1/DEX(50),DEY(50),DET,DE1T,DEP,DE1P,DELAMD
      COMMON/MOLFR/X(50),Y(50),Z(50),ZN(50,2),SUM(2)
      COMMON/INDEX/KBDF,KE,KU,KHS,KW
      COMMON/PARTIZ/LAMDA,MU,NU,YW
      COMMON/TEMPRE/TINP,PINP,T,P
      DO 1 I=1,NC
      X(I)=X(I)+DEX(I)
    1 Y(I)=Y(I)+DEY(I)
      LAMDA=LAMDA+DELAMD
      IF(KE.EQ.4.AND.KU.EQ.2.AND.KBDF.NE.3) GO TO 2
      T=T+DET
      GO TO 4
    2 T=1./(1./T+DE1T)
    4 IF(KE.EQ.4.AND.KU.EQ.1.AND.KBDF.EQ.1) GO TO 5
      P=P+DEP
      GO TO 6
    5 P=1./(1./P+DE1P)
    6 RETURN
      END
C ---------------------------------------------------------------------
C     - SUBROUTINE INCREW - 9
C ---------------------------------------------------------------------
      SUBROUTINE INCREW
      REAL LAMDA,MU,NU
	CHARACTER*4 NAME
      COMMON/NCODEX/NCOD(50),NAME(50,5),NCST,NCNST,NCIP,NC,NCW
      COMMON/MOLFR/X(50),Y(50),Z(50),ZN(50,2),SUM(2)
      COMMON/INCRW1/DEY(50),DEYW,DET,DEP,DELAMD
      COMMON/PARTIZ/LAMDA,MU,NU,YW
      COMMON/TEMPRE/TINP,PINP,T,P
      T=T+DET
      P=P+DEP
      LAMDA=LAMDA+DELAMD
      YW=YW+DEYW
      DO 1 I=1,NC
    1 Y(I)=Y(I)+DEY(I)
      Y(NCW)=YW
      RETURN
      END
C ----------------------------------------------------------------------
C     - SUBROUTINE INVERS - 28
C ----------------------------------------------------------------------
      SUBROUTINE INVERS(FOB)
      REAL LAMDA,NU,MU
	CHARACTER*4 NAME
      COMMON/OPTION/BINAR(50,50),KIJ,IEQ,IM,ISUP,KCRT,KWRT,VL,IOPT1
      COMMON/NCODEX/NCOD(50),NAME(50,5),NCST,NCNST,NCIP,NC,NCW
      COMMON/MOLFR/X(50),Y(50),Z(50),ZN(50,2),SUM(2)
      COMMON/PARTIZ/LAMDA,MU,NU,YW
      V=LAMDA
      LAMDA=NU
      NU=V
      DO 5 I=1,NC
      V=X(I)
      X(I)=Y(I)
      Y(I)=V
    5 CONTINUE
      CALL THERMO(3)
      CALL FUNZER
      CALL FUNZOB(FOB)
      RETURN
      END
C ----------------------------------------------------------------------
C     - SUBROUTINE KIDEAL - 61
C ----------------------------------------------------------------------
      SUBROUTINE KIDEAL
      REAL KID,M
	CHARACTER*4 NAME
      COMMON/KVALUE/DTK(50),DPK(50),DXK(50,50),DYK(50,50),KID(50)
      COMMON/BANK1/M(50),TC(50),PC(50),ZC(50),OMEGA(50),BP(50)
      COMMON/NCODEX/NCOD(50),NAME(50,5),NCST,NCNST,NCIP,NC,NCW
      COMMON/K00K/ITER,RHOL,KIDL,K006
      COMMON/INDEX/KBDF,KE,KU,KHS,KW
      COMMON/TEMPRE/TINP,PINP,T,P
      COMMON/KAPID/AKID(50)
	REAL AKID
      COMMON/KAPBLO/A1,A2,A3,A4,A5,A6,A7,A8,A9,A10,A11,A12,A13,A14,A15
      DIMENSION A1(6),A2(6),A3(6),A4(6),A5(6),A6(6),A7(6),A8(6),A9(6),
     *A10(6),A11(6),A12(6),A13(6),A14(6),A15(6)
C      DATA  A1/4.72341,3.150443,3.470203,6.301147,-69.21772,7.041584/,
C     *A2 /-4.85613,-3.565116,6.3156,-4.563335,14.14014,-6.09999/,
C     *A3 /2*0.,-.04845,-1.185539,104.22244,.862501/,
C     *A4 /-.44661,.0665217,.0002533,.0977931,-62.86751,-3.37262/,
C     *A5 /.052545,-.024776,0.,-.00648036,13.620377,1.053082/,
C     *A6 /.203825,.241449,.0197677,-.067868,.8482362,-2.204073/,
C     *A7 /0.,-0.58232,0.,.049496,-1.563842,3.2863987/,
C     *A8 /-.02008,3*0.,.357968,-1.156870/,
C     *A9 /-.00813,4*0.,.7796330/,
C     *A10/0.00467,3*0.,.206226,-.6142948/,
C     *A11/-9.7604970,5*0./,
C     *A12/19.935970,5*0./,
C     *A13/-2.810540,5*0./,
C     *A14/-7.258300,5*0./,
C     *A15/-0.057565,5*0./
      DO 1 I=1,50
    1 KID(I)=0.
      IF(KE.EQ.5) RETURN
      IF(KIDL) 15,15,5
    5 DO 10 I=1,NC
   10 KID(I)=AKID(I)
      RETURN
   15 CONTINUE
      TT=T
      PP=P
      IF(PP.GT.50.)  PP=50.
      IF(TT.LT.260.) TT=260.
      IF(TT.GT.500.) TT=500.
      DO 20 I=1,NC
      J=NCOD(I)
      L=1
      IF(J.EQ.2) L=2
      IF(J.EQ.1) L=3
      IF(J.EQ.46) L=4
      IF(J.EQ.49) L=5
      IF(J.EQ.50) L=6
      TR=TT/TC(I)
      PR=PP/PC(I)
      FP0=A1(L)+A2(L)/TR+A3(L)*TR+A4(L)*TR*TR+A5(L)*TR*TR*TR+(A6(L)+A7(L
     *)*TR+A8(L)*TR*TR)*PR+(A9(L)+A10(L)*TR)*PR*PR-ALOG(PR)
      FP1=A11(L)+A12(L)*TR+A13(L)/TR+A14(L)*TR*TR*TR+A15(L)*(PR-0.6)
      KID(I)=FP0+OMEGA(I)*FP1
      KID(I)=EXP(KID(I))
   20 CONTINUE
      RETURN
      END
C ---------------------------------------------------------------------
C     - SUBROUTINE NORWAT - 8
C ---------------------------------------------------------------------
      SUBROUTINE NORWAT
	CHARACTER*4 NAME
      COMMON/HFASE/HF,Q,HL,HV,DPHL,DPHV,DTHL,DTHV,DXHL(50),DYHV(50)
      COMMON/SFASE/SF,SL,SV,DPSL,DPSV,DTSL,DTSV,DXSL(50),DYSV(50)
      COMMON/NCODEX/NCOD(50),NAME(50,5),NCST,NCNST,NCIP,NC,NCW
      COMMON/SPECIF/AL(50),AV(50),BL(50),BV(50),C,D,E
      COMMON/WATER/HWL,DTHWL,DPHWL,SWL,DTSWL,DPSWL
      COMMON/INDEX/KBDF,KE,KU,KHS,KW
      COMMON/FERW/F(50),FW,FIW,GW,RW,SGW,SRW
      SGW=1.
      SRW=1.
      IF(KHS.NE.1) GO TO 2
      SGW=AMAX1(ABS(HV),ABS(HWL),ABS(HF),ABS(Q))
    2 IF(KHS.NE.2) GO TO 3
      SGW =AMAX1(ABS(SV),ABS(SWL),ABS(SF))
    3 IF(KE.GT.2) GO TO 5
      SRW=0.
      SRW=AMAX1(ABS(D),ABS(E),SRW)
      DO 4 I=1,NC
    4 SRW=AMAX1(ABS(AV(I)),ABS(BV(I)),SRW)
    5 CONTINUE
      RETURN
      END
C ----------------------------------------------------------------------
C     - SUBROUTINE PRESAT - 19
C ----------------------------------------------------------------------
      SUBROUTINE PRESAT(PST,IOK,P1)
      REAL LAMDA,MU,NU
	CHARACTER*4 NAME
      COMMON/TITLE/TIT(18),IUF,IUM,IUP,INDI,FTM,WTF,HFT,QT,SFT,AFHS(3,4)
      COMMON/OPTION/BINAR(50,50),KIJ,IEQ,IM,ISUP,KCRT,KWRT,VL,IOPT1
      COMMON/HFASE/HF,Q,HL,HV,DPHL,DPHV,DTHL,DTHV,DXHL(50),DYHV(50)
      COMMON/SFASE/SF,SL,SV,DPSL,DPSV,DTSL,DTSV,DXSL(50),DYSV(50)
      COMMON/KVALUE/DTK(50),DPK(50),DXK(50,50),DYK(50,50),AK(50)
      COMMON/NCODEX/NCOD(50),NAME(50,5),NCST,NCNST,NCIP,NC,NCW
      COMMON/MOLFR/X(50),Y(50),Z(50),ZN(50,2),SUM(2)
      COMMON/WATER/HWL,DTHWL,DPHWL,SWL,DTSWL,DPSWL
      COMMON/INDEX/KBDF,KE,KU,KHS,KW
      COMMON/PARTIZ/LAMDA,MU,NU,YW
      COMMON/SHIDL/H0L,H0V,S0L,S0V
      COMMON/TEMPRE/TINP,PINP,T,P
      COMMON/COMPRS/ZCR,ZV,ZL,ZW
      COMMON/SYSTEM/IN,IO,KDOS,MDOS,LDOS,NDOS,NUOVER,NOUTP3,KCONV,IDEBUG
      DIMENSION YO(50),XO(50)
      IOK=1
      PST=0.
      KKWRT=KWRT
      KNCW=NCW
      KKE=KE
      KKW=KW
      HHL=HL
      HHV=HV
      HHWL=HWL
      SSL=SL
      SSV=SV
      SSWL=SWL
      HH0L=H0L
      HH0V=H0V
      SS0L=S0L
      SS0V=S0V
      ZZL=ZL
      ZZV=ZV
      AMDA=LAMDA
      AMU=MU
      ANU=NU
      KWRT=0
      NCW=NC
      KW=0
      DO 1 I=1,NC
      XO(I)=X(I)
    1 YO(I)=Y(I)
      CALL PROCEL(1)
      IF(KCONV) 10,10,5
    5 IOK=0
      PST=P
   10 P=P1/14.696
      KWRT=KKWRT
      NCW=KNCW
      KW=KKW
      KE=KKE
      HL=HHL
      HV=HHV
      HWL=HHWL
      SL=SSL
      SV=SSV
      SWL=SSWL
      H0L=HH0L
      H0V=HH0V
      S0L=SS0L
      S0V=SS0V
      ZL=ZZL
      ZV=ZZV
      LAMDA=AMDA
      NU=ANU
      MU=AMU
      DO 15 I=1,NC
      AK(I)=0.
      X(I)=XO(I)
   15 Y(I)=YO(I)
      RETURN
      END
C ----------------------------------------------------------------------
C     - SUBROUTINE PROCOV - 45
C ----------------------------------------------------------------------
      SUBROUTINE PROCOV(KTEST,TETA,TETAMN,FOB,IND)
      REAL LAMDA,MU,NU
	CHARACTER*4 NAME
      COMMON/SYSTEM/IN,IO,KDOS,MDOS,LDOS,NDOS,NUOVER
      COMMON/BANK1/WM(50),TC(50),PC(50),ZC(50),OMEGA(50),BP(50)
      COMMON/OPTION/BINAR(50,50),KIJ,IEQ,IM,ISUP,KCRT,KWRT,VL,IOPT1
      COMMON/NCODEX/NCOD(50),NAME(50,5),NCST,NCNST,NCIP,NC,NCW
      COMMON/INCR1/DEX(50),DEY(50),DET,DE1T,DEP,DE1P,DELAMD
      COMMON/INCR/DT,D1T,DP,D1P,DX(50),DY(50),DLAMDA
      COMMON/ACRISI/ICR,ICC,ICK,KSTOP,ISTOP2,IP1,IP2
      COMMON/MOLFR/X(50),Y(50),Z(50),ZN(50,2),SUM(2)
      COMMON/FER/F(50),FI(50),SNOR,GI,ERRE,SGI,SGR
      COMMON/INDEX/KBDF,KE,KU,KHS,KW
      COMMON/PARTIZ/LAMDA,MU,NU,YW
      COMMON/COMPRS/ZCR,ZV,ZL,ZLWT
      COMMON/TEMPRE/TINP,PINP,T,P
      DIMENSION VFOB(3),NOCT(50)
      KTEST=0
      TETA=1.
      TETAX=1.
      TETAY=1.
      TETAT=1.
      TETAP=1.
      TETAL=1.
      TETAMN=1.
      IPAS1=0
      IPAS2=0
      ISTOP1=0
      ITIN=1
      CALL FUNZOB(FOB)
      VFOB(ITIN)=FOB
      IF(KE.EQ.4.AND.KU.EQ.2.AND.KBDF.NE.3) GO TO 3
      IF(DT.EQ.0.) GO TO 4
      TETAT=.05/ABS(DT)
      GO TO 4
    3 IF(D1T.EQ.0.) GO TO 4
      TETAT=(1./(T-.05)-1./T)/ABS(D1T)
    4 IF(KE.EQ.4.AND.KU.EQ.1.AND.KBDF.EQ.1) GO TO 5
      IF(DP.EQ.0.) GO TO 6
      TETAP=.005*P/ABS(DP)
      GO TO 6
    5 IF(D1P.EQ.0.) GO TO 6
      TETAP=(1./(.995*P)-1./P)/ABS(D1P)
    6 IF(DLAMDA.EQ.0.) GO TO 7
      TETAL=.0005/ABS(DLAMDA)
    7 TETAMN=AMIN1(TETAT,TETAP,TETAL,TETAMN)
      DO 2 I=1,NC
      IF(DX(I).EQ.0.) GO TO 1
      TETAX=  0.0005/ABS(DX(I))
    1 IF(DY(I).EQ.0.) GO TO 2
      TETAY=  0.0005/ABS(DY(I))
    2 TETAMN=AMIN1(TETAX,TETAY,TETAMN)
      IF(TETAMN.GT.0.19) TETAMN=0.19
   10 ITIN=ITIN+1
      DO 11 I=1,NC
      DEX(I)=TETA*DX(I)
      IF(DEX(I).GT.0.3) DEX(I)=0.3
      IF(DEX(I).LT.-X(I))DEX(I)=-X(I)+0.0001
      DEY(I)=TETA*DY(I)
      IF(DEY(I).GT.0.3) DEY(I)=0.3
      IF(DEY(I).LT.-Y(I)) DEY(I)=-Y(I)+0.0001
   11 CONTINUE
      IF(KE.EQ.4.AND.KU.EQ.2.AND.KBDF.NE.3) GO TO 12
      DET=TETA*DT
      IF(DET.GT.30.) DET=30.
      IF(DET.LT.-30.) DET=-30.
      IF(DET.LT.-(T/2.)) DET=-T/2.
      GO TO 13
   12 DE1T=TETA*D1T
      IF(DE1T.LT.(1./(T+30.)-1./T)) DE1T=1./(T+30.)-1./T
      IF(T.LE.30.AND.DE1T.GT.1./T) DE1T=1./T
      IF(T.GT.30.AND.DE1T.GT.(1./(T-30.)-1./T)) DE1T=1./(T-30.)-1./T
   13 CONTINUE
      IF(KE.EQ.4.AND.KU.EQ.1.AND.KBDF.EQ.1) GO TO 14
      DEP=TETA*DP
      IF(DEP.GT.P) DEP=P
      IF(DEP.LT.(-0.4*P)) DEP=-0.4*P
      GO TO 15
   14 DE1P=TETA*D1P
      IF(DE1P.GT.(0.6/P)) DE1P=0.6/P
      IF(DE1P.LT.(-0.5/P)) DE1P=-0.5/P
   15 CONTINUE
      DELAMD=TETA*DLAMDA
      IF(ABS(DELAMD).GT.0.3) DELAMD=0.3*DELAMD/ABS(DELAMD)
      IF(DELAMD.GT.(1.-LAMDA)) DELAMD=0.9999-LAMDA
      IF(DELAMD.LT.-LAMDA) DELAMD=0.0001-LAMDA
      IF(KW.NE.0) GO TO 21
   20 YW=0.
      MU=0.
      NU=1.-(LAMDA+DELAMD)
      GO TO 100
   21 TCW=647.3
      ZW=Z(NCW)
      GO TO(22,27,28),KBDF
   22 IF(KE.EQ.4.AND.KU.EQ.2)GO TO 23
      IF((T+DET).GE.TCW) DET=TCW-0.01-T
      TT=T+DET
      GO TO 24
   23 IF((1./T+DE1T).LE.(1./TCW)) DE1T=1./(TCW-.01)-1./T
      TT=1./(1./T+DE1T)
   24 CALL TENVAP(PW,DTPW,TT,1,0)
      IF(KE.EQ.4.AND.KU.EQ.1) GO TO 25
      PP=P+DEP
      GO TO 26
   25 PP=1./(1./P+DE1P)
   26 YW=PW/PP
      MU=ZW
      NU=1.-MU
      GO TO 100
   27 YW=ZW
      MU=0.
      NU=0.
      GO TO 100
   28 GO TO (30,40,50,60),KW
   30 IF((T+DET).LT.TCW) GO TO 34
      IF((LAMDA+DELAMD).LE.ZW) DELAMD=ZW-LAMDA+.0001
      YW=ZW/(LAMDA+DELAMD)
      MU=0.
      NU=1.-(LAMDA+DELAMD)
      GO TO 100
   34 TT=T+DET
      CALL TENVAP(PW,DTPW,TT,1,0)
      YW=PW/(P+DEP)
      MU=ZW-YW*(LAMDA+DELAMD)
      IF(MU.GE.0.) GO TO 36
      YW=ZW/(LAMDA+DELAMD)
      MU=0.
   36 NU=1.-(LAMDA+DELAMD)-MU
      IF(NU.GE.0.) GO TO 100
      GO TO 80
   40 IF((T+DET).LT.TCW) GO TO 44
      IF(LAMDA.LE.ZW) GO TO 42
      YW=ZW/LAMDA
      MU=0.
      NU=1.-LAMDA
      GO TO 100
   42 DET=TCW-.01-T
   44 TT=T+DET
      CALL TENVAP(PW,DTPW,TT,1,0)
      YW=PW/(P+DEP)
      MU=ZW-YW*LAMDA
      IF(MU.GE.0.) GO TO 46
      YW=ZW/LAMDA
      MU=0.
   46 NU=1.-LAMDA-MU
      IF(NU.GE.0.) GO TO 100
      GO TO 80
   50 IF((T+DET).GE.TCW) DET=TCW-.01-T
      TT=T+DET
      CALL TENVAP(PW,DTPW,TT,1,0)
      YW=PW/(P+DEP)
      DELAMD=(ZW-MU)/YW-LAMDA
   52 NU=1.-(LAMDA+DELAMD)-MU
      IF(MU.EQ.0..AND.NU.LE.0.) GO TO 80
      IF(MU.GT.0..AND.NU.LT.0.) GO TO 80
      GO TO 100
   60 IF((T+DET).LT.TCW) GO TO 66
      IF(NU) 64,64,62
   62 MU=0.
      DELAMD=1.-NU-LAMDA
      YW=ZW/(LAMDA+DELAMD)
      GO TO  100
   64 DET=TCW-.01-T
   66 TT=T+DET
      CALL TENVAP(PW,DTPW,TT,1,0)
      YW=PW/(P+DEP)
      IF(YW.EQ.1.) YW=0.99
      DELAMD=(1.-ZW-NU)/(1.-YW)-LAMDA
      MU=1.-(LAMDA+DELAMD)-NU
      IF(NU) 68,68,70
   68 IF(MU.GT.0.) GO TO 100
      MU=.0001
      DELAMD=.9999-LAMDA
      YW=1.-(1.-ZW)/(LAMDA+DELAMD)
      GO TO 100
   70 IF(MU.GE.0.) GO TO 100
      MU=0.
      DELAMD=1.-NU-LAMDA
      YW=ZW/LAMDA
      GO TO 100
   80 TETA=TETA/5.
      IF(TETA-TETAMN)150,150,84
   84 ITIN=ITIN-1
      GO TO 10
  100 IF(KW.NE.0) Y(NCW)=YW
      CALL INCREM
      CALL THERMO(2)
      NUOVER=0
      IF(ICR.EQ.0) GO TO 90
      CALL CRISI2(TETA,TETAMN,IPAS1,ISTOP1,KSTOP)
      CALL DECREM
      ITIN=ITIN-1
      GO TO 10
   90 CALL FUNZER
      IF(ISTOP1.EQ.1.OR.IPAS2.EQ.1)GO TO 155
      CALL FUNZOB(FOB)
      VFOB(ITIN)=FOB
      IF(VFOB(ITIN).LT.VFOB(ITIN-1)) GO TO 125
      CALL DECREM
      IF(IPAS1.NE.0) GO TO 101
      TETA=TETA/5.
      IF(TETA.LE.TETAMN) GO TO 105
      ITIN=ITIN-1
      GO TO 10
  101 ISTOP1=1
      GO TO (102,103,104),IPAS1
  102 TETA=TETA/2.
      GO TO 10
  103 TETA=2.*TETA/3.
      GO TO 10
  104 TETA=3.*TETA/4.
      GO TO 10
  105 KSTOP=1
      IF(ISTOP2.EQ.1) GO TO 150
      IF(LAMDA.GT.0..AND.LAMDA.LE.0.0001) GO TO 150
      IF(LAMDA.GE.0.9999.AND.LAMDA.LT.1.) GO TO 150
      IF(NU.LT.0.) GO TO 150
      IPAS2=1
      ISTOP2=1
      TETA=0.5
      GO TO 10
  125 IF(IPAS1.NE.0) GO TO 127
      IF(TETA.EQ.1.) GO TO 160
  127 IPAS1=IPAS1+1
      IF(IPAS1.EQ.4) GO TO 160
      CALL DECREM
      GO TO(128,130,132),IPAS1
  128 TETA=2.*TETA
      GO TO 10
  130 TETA=3.*TETA/2.
      VFOB((ITIN-1))=VFOB(ITIN)
      ITIN=ITIN-1
      GO TO 10
  132 TETA=4.*TETA/3.
      VFOB((ITIN-1))=VFOB(ITIN)
      ITIN=ITIN-1
      GO TO 10
  150 KTEST=1
      RETURN
  155 CALL FUNZOB(FOB)
      RETURN
  160 AAA=0.
      BBB=0.
      DO 201 I=1,NCW
      NOCT(I)=I
      AAA=AAA+Y(I)
      IF(I.GT.NC) GO TO 201
      BBB=BBB+X(I)
  201 CONTINUE
      WEIML=SUMMAT(WM,X,NOCT,NC)
      WEIMV=SUMMAT(WM,Y,NOCT,NCW)
      AUSLIC=0.
      AUSVAP=0.
      IF(ZL*BBB.GT.0.) AUSLIC=WEIML/(ZL*BBB)
      IF(ZV*AAA.GT.0.) AUSVAP=WEIMV/(ZV*AAA)
      IF(IND.GT.24)RETURN
      GO TO(203,203,203,203,203,203,202,203,203,202,202,203,203,203,
     *202,202,203,203,203,202,202,203,202,202),IND
  202 IF(KW.EQ.0.AND.AUSVAP.GT.AUSLIC) CALL INVERS(FOB)
  203 RETURN
      END
C ---------------------------------------------------------------------
C     - SUBROUTINE PROCOW - 5
C ---------------------------------------------------------------------
      SUBROUTINE PROCOW(KTEST,TETA,TETAMN,FOBW)
      REAL LAMDA,MU,NU
	CHARACTER*4 NAME
      COMMON/OPTION/BINAR(50,50),KIJ,IEQ,IM,ISUP,KCRT,KWRT,VL,IOPT1
      COMMON/NCODEX/NCOD(50),NAME(50,5),NCST,NCNST,NCIP,NC,NCW
      COMMON/MOLFR/X(50),Y(50),Z(50),ZN(50,2),SUM(2)
      COMMON/INCRW1/DEY(50),DEYW,DET,DEP,DELAMD
      COMMON/INCRW/DY(50),DYW,DT,DP,DLAMDA
      COMMON/PARTIZ/LAMDA,MU,NU,YW
      COMMON/TEMPRE/TINP,PINP,T,P
      DIMENSION WFOB(3)
      TCW=647.3
      TETAMN=1.
      TETA=1.
      TETAT=1.
      TETAP=1.
      TETAL=1.
      TETAYW=1.
      TETAY=1.
      ITIN=1
      IPAS1=0
      ISTOP1=0
      KTEST=0
      CALL FOBWAT(FOBW)
      WFOB(ITIN)=FOBW
      IF(DT.EQ.0.)GO TO 2
      TETAT=0.05/ABS(DT)
    2 IF(DP.EQ.0.)GO TO 4
      TETAP=0.005*P/ABS(DP)
    4 IF(DLAMDA.EQ.0.)GO TO 6
      TETAL=0.0005/ABS(DLAMDA)
    6 IF(DYW.EQ.0.)GO TO 8
      TETAYW=0.0005/ABS(DYW)
    8 TETAMN=AMIN1(TETAT,TETAP,TETAL,TETAYW,TETAMN)
      DO 12 I=1,NC
      IF(DY(I).EQ.0.)GO TO 12
      TETAY=0.0005/ABS(DY(I))
   12 TETAMN=AMIN1(TETAY,TETAMN)
      IF(TETAMN.GT.0.19) TETAMN=0.19
   10 ITIN=ITIN+1
      DET=TETA*DT
      IF(DET.GT.(TCW-T-.01)) DET=TCW-T-0.01
      IF(DET.GT.30.) DET=30.
      IF(DET.LT.-30.) DET=-30.
      IF(DET.LT.(-T/2.)) DET=-T/2.
      DEP=TETA*DP
      IF(DEP.GT.P) DEP=P
      IF(DEP.LT.(-0.4*P)) DEP=-0.4*P
      DELAMD=TETA*DLAMDA
      IF(ABS(DELAMD).GT.0.3) DELAMD=0.3*ABS(DELAMD)/DELAMD
      IF(DELAMD.GT.(1.-LAMDA)) DELAMD=0.9999-LAMDA
      IF(DELAMD.LT.-LAMDA) DELAMD=0.0001-LAMDA
      DEYW=TETA*DYW
      IF(DEYW.GT.0.3) DEYW=0.3
      IF(DEYW.LT.-YW) DEYW=-YW+0.0001
      DO 17 I=1,NC
      DEY(I)=TETA*DY(I)
      IF(DEY(I).GT.0.3) DEY(I)=0.3
      IF(DEY(I).LT.-Y(I)) DEY(I)=-Y(I)+0.0001
   17 CONTINUE
      MU=1.-(LAMDA+DELAMD)
      CALL INCREW
      CALL TERMOW(IEQ,IM,ISUP,3)
      CALL FERWAT
      IF(ISTOP1.EQ.1) GO TO 155
      CALL FOBWAT(FOBW)
      WFOB(ITIN)=FOBW
      IF(WFOB(ITIN).LT.WFOB(ITIN-1)) GO TO 125
      CALL DECREW
      IF(IPAS1.NE.0) GO TO 101
      TETA=TETA/5.
      IF(TETA.LE.TETAMN) GO TO 150
      ITIN=ITIN-1
      GO TO 10
  101 ISTOP1=1
      TETA=(IPAS1*TETA)/(1.+IPAS1)
      GO TO 10
  125 IF(IPAS1.NE.0) GO TO 127
      IF(TETA.EQ.1) GO TO 160
  127 IPAS1=IPAS1+1
      IF(IPAS1.EQ.4) GO TO 160
      CALL DECREW
      GO TO (128,130,132),IPAS1
  128 TETA=2.*TETA
      GO TO 10
  130 TETA=3.*TETA/2.
      WFOB(ITIN-1)=WFOB(ITIN)
      ITIN=ITIN-1
      GO TO 10
  132 TETA=4.*TETA/3.
      WFOB(ITIN-1)=WFOB(ITIN)
      ITIN=ITIN-1
      GO TO 10
  150 KTEST=1
      RETURN
  155 CALL FOBWAT(FOBW)
  160 RETURN
      END
C ----------------------------------------------------------------------
C     - SUBROUTINE PSEUCR - 17
C ----------------------------------------------------------------------
      SUBROUTINE PSEUCR(PPC,TPC,VPC,OPC,ZPC,VC,NO,N,ITS)
      COMMON/BANK1/W(50),TC(50),PC(50),ZC(50),OMEGA(50),BP(50)
      COMMON/MOLFR/X(50),Y(50),Z(50),ZN(50,2),SUM(2)
      COMMON/BANK2/ZRA(50),SPG(50),TD(50),PD(50)
      DIMENSION NO(50),VC(50),PHI(50)
      PPC=SUMMAT(X,PC,NO,N)
      VPC=SUMMAT(X,VC,NO,N)
      DO 1 J=1,N
      I=NO(J)
    1 PHI(I)=X(I)*VC(I)/VPC
      IF(ITS) 5,5,10
    5 ZPC=SUMMAT(X,ZRA,NO,N)
      OPC=SUMMAT(X,OMEGA,NO,N)
   10 TPC=0.
      DO 15 II=1,N
      DO 15 JJ=1,N
      I=NO(II)
      J=NO(JJ)
      TP=SQRT(VC(I)**0.333333*VC(J)**0.333333)
      TP=TP/((VC(I)**0.333333+VC(J)**0.333333)/2.)
      TP=TP*TP*TP
      TP=1.-TP
      TP=SQRT(TC(I)*TC(J))*(1.-TP)
      TPC=TPC+PHI(I)*PHI(J)*TP
   15 CONTINUE
      RETURN
      END
C ----------------------------------------------------------------------
C     - SUBROUTINE QUART - 34
C ----------------------------------------------------------------------
      SUBROUTINE QUART(A,X,Y,Z)
      DIMENSION A(15)
      Z=A(1)+X*(A(2)+X*(A(3)+X*(A(4)+X*A(5))))+Y*(A(6)+Y*(A(7)+Y*(A(8)+Y
     1*A(9))))+X*Y*(A(10)+X*(A(11)*Y+A(12)+A(13)*X)+Y*(A(14)+A(15)*Y))
      RETURN
      END
C ----------------------------------------------------------------------
C     - SUBROUTINE SOLUZ - 68
C ----------------------------------------------------------------------
      SUBROUTINE SOLUZ(ZSOL,DELT1,A1,B1,IEQ,IFASE)
      DOUBLE PRECISION A,B,ARGM1,ARGM2,P,Q,DELTA
C     WRITE(6,'('' SOLUZ A1,B1,IEQ,IFASE''2E12.5,2I3)')A1,B1,IEQ,IFASE
      A=A1
      B=B1
      GO TO (1,6) ,IEQ
    1 P=0.11111111111111-(A-B-B**2)/3.
      Q=0.03703703703703-(A-B-B**2)/6.+A*B/2.
      DELTA=Q*Q-P*P*P
      DELT1=DELTA
      IF (DELTA)4,3,2
    2 SUM1=Q+DSQRT(DELTA)
      SUM2=Q-DSQRT(DELTA)
      DEN1=ABS(SUM1)
      DEN2=ABS(SUM2)
      ZSOL=.33333333+(SUM1/DEN1)*(DEN1**.33333333)+(SUM2/DEN2)*(DEN2**
     *.33333333)
C     WRITE(6,'('' ZSOL=''E12.5)')ZSOL
      GO TO 12
    3 ZV=1./3.+2*DSQRT(P)
      ZL=1./3.-DSQRT(P)
      GO TO 10
    4 ARGM1=0.333333333333333*DACOS(Q/(P*DSQRT(P)))
      ARGM2=3.14159265369
      ZV=1./3.+2*DSQRT(P)*DCOS(ARGM1)
      ZL=1./3.+2*DSQRT(P)*DCOS(ARGM1+0.66666666666666*ARGM2)
      GO TO 10
    6 P=(1.-B)**2/9.-(A-3*B**2-2*B)/3.
      Q=(1.-B)**3/27.-(1.-B)*(A-3*B**2-2*B)/6.+(A*B-B**2-B**3)/2.
      DELTA=Q*Q-P*P*P
      DELT1=DELTA
      IF(DELTA) 9,8,7
    7 SUM1=Q+DSQRT(DELTA)
      SUM2=Q-DSQRT(DELTA)
      DEN1=ABS(SUM1)
      DEN2=ABS(SUM2)
      ZSOL=(1.-B)/3.+(SUM1/DEN1)*(DEN1**.33333333)+(SUM2/DEN2)*(DEN2**
     *.33333333)
      GO TO 12
    8 ZV=(1.-B)/3.+2*DSQRT(P)
      ZL=(1.-B)/3.-DSQRT(P)
      GO TO 10
    9 ARGM1=0.33333333333333*DACOS(Q/(P*DSQRT(P)))
      ARGM2=3.14159265369
      ZV=(1.-B)/3.+2*DSQRT(P)*DCOS(ARGM1)
      ZL=(1.-B)/3.+ 2*DSQRT(P)*DCOS(ARGM1+0.666666666666666*ARGM2)
   10 IF(IFASE.EQ.1) ZSOL=ZL
      IF(IFASE.EQ.2) ZSOL=ZV
   12 RETURN
      END

