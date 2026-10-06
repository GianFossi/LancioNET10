      SUBROUTINE SHELL(NOZ,ISSUE)
      USE mTYPINV
	USE DFWIN
	REAL ShThNzAr1                 
	TYPE(NOZZLE)::NOZ
	TYPE(ASMERES)::ISSUE
	CHARACTER*120 DOMANDA
	INTEGER*4 xMESS
C
C     CALCOLO LIMITI DI RINFORZO LUNGO IL MANTELLO SECONDO AD 540.1
C     by CD  -  24/06/98
C
C.....CALCOLO DEL RINFORZO SECONDO AD 540 1.a
C     100% DEL RINFORZO DENTRO L
C
      ShThNzAr=TD
	ShThNzAr1=NOZ%ShThkNozArea/MM
	IF(ShThNzAr1.GT.ShThNzAr/2.AND.ShThNzAr1.LT.ShThNzAr*2)
     *   ShThNzAr=ShThNzAr1
	A=TS*(D0E+2.*CORRN)
	IF(Regola.EQ.5)THEN
	A=A+2.*TS*(TKN-CORRN)
	ELSEIF(Regola.EQ.4)THEN
	A=A+2.*TS*((PL-D0)/2-CORRN)*(1.-FRP)
	ELSEIF(SetIn.EQ.1)THEN
	A=A+2.*TS*(TKN-CORRN)*(1.-FR)
	ENDIF
	IF(ISSUE%SpCop.GT.0.)A=A/2.
	ISSUE%AEXT=.5*(ISSUE%SR)*(D0+2.*CORRN)/MM
      AEXT=ISSUE%AEXT
	L1=D0+2.*CORRN
      L2=0.5*(D0+2.*CORRN)+(TD-C)+(TKN-CORRN)
      IF(Regola.EQ.4)L2=0.5*(D0+2.*CORRN)+(TD-C)+((PL-D0)/2-CORRN)
	XL=AMAX1(L1,L2)
      FXL=XL*MM
      IXL=0
	XLdisp=0
      IF(NOZ%FactVicini.GT.0..AND.NOZ%FactVicini.LT.1.)THEN
        FXL=FXL*NOZ%FactVicini
        XL=XL*NOZ%FactVicini
	ENDIF
	IF(NOZ%LSdisp.GT.0.)XLdisp=NOZ%LSdisp+D0/2*MM
	IF(XLdisp.LT.FXL.AND.NOZ%LSdisp.GT.0.) THEN
          IXL=1
      	FXL=XLdisp
	ENDIF
C      WRITE(*,*)'L AVAILABLE ON SHELL',XL,' (inch)= ',FXL,' (mm)'
C      WRITE(*,*)'(GIVEN FROM NOZZLE C.L.)'
C      WRITE(*,*)'TO CONFIRM PRESS y /TO CHANGE PRESS n'
      FXL=FXL/MM
C     Diam.Esterno Bocchello - Zona Autorinforzo
      DE=D0+2.*TKN
C
C     CALCOLO AREA DISPONIBILE NEL MANTELLO
C
      A1r1=(1.-GreekPI/4)*(R1/MM)**2
	IF(Regola.EQ.5)THEN
      A1=(2.*FXL-DE)*(ShThNzAr-TS-C)
	ELSE
      A1=(2.*FXL-DE)*(ShThNzAr-TS-C)-A1r1
	ENDIF
c	write(domanda,111)R1/MM,A1r1,Regola,A1,FXL,DE,ShThNzAr,TS,C,
c	1char(0)
c111   format(2f12.2,i5,6f12.2,A1)
c      xMESS = MessageBoxEx(NULL,DOMANDA,'AsmeVip'C,MB_YESNO+
c     1	                                 +MB_ICONQUESTION+
c     2                                     +MB_SETFOREGROUND,
c     3                     LANG_ITALIAN)
C
C.....CALCOLO DEL RINFORZO SECONDO AD 540 1.b
C     2/3 DEL RINFORZO DENTRO L
C
      AA=2.*A/3.
	ISSUE%AAEXT=2./3.*ISSUE%AEXT
	AAEXT=ISSUE%AAEXT
      L4=(D0+2*CORRN)/2.+.5*SQRT((DD+C+TD)*.5*(TD-C))
      L5=(D0+2*CORRN)/2.+(TD-C)+(TKN-CORRN)
	IF(Regola.EQ.4)L5=(D0+2*CORRN)/2.+(TD-C)+((PL-D0)/2-CORRN)
      L6=AMAX1(L4,L5)
C
C     CONTROLLA SE EFETTIVAMENTE RISULTA L'<L
C     ALTRIMENTI PONE L'=L
C
      IF(L6.GT.FXL)L6=FXL
	IF(Regola.EQ.5)THEN
	AA1=(2.0*L6-DE)*(ShThNzAr-TS-C)
      ELSE
	AA1=(2.0*L6-DE)*(ShThNzAr-TS-C)-A1r1
	ENDIF
      RETURN
1     FORMAT(A1)
      END
C************************************************************************
      SUBROUTINE subNOZZLE(RMN)
	USE mTYPINV
	USE DFWIN
	CHARACTER*120 DOMANDA
C
C     CALCOLO LIMITI DI RINFORZO SUL BOCCHELLO SECONDO AD 540.2
C     ASME VIII DIV.2
C
C     Nuova Routine by CD   -   25/06/98
	REAL LL2A,FRloc
      IF(Regola.EQ.5)THEN
	   A2=0.
	   RETURN
      ENDIF
	TESTN=2.5*(TKN-CORRN)+0.73*R2/MM
      LL1=0.5*SQRT(RMN*(TKN-CORRN))+0.73*R2/MM

      XL3=LL+2.5*(TKN1-CORRN)

!      IF(XLT.LT.TESTN.AND.Regola.NE.11) THEN
      IF(XLT.LT.TESTN) THEN
C
C     AD 540.2 SKECTHES a & b PUNTO 1
C

        IAD540=1
        LL2=1.73*(TKN-TKN1)+2.5*(TKN1-CORRN)+0.73*R2/MM
        XL1=AMAX1(LL1,LL2)
        ZL3=2.5*(TD-C)
        XL4=AMIN1(ZL3,XL3)
        L3=AMIN1(XL1,XL4)

      Else
C
C     AD 540.2 SKECTHES a & b PUNTO 2
C

        IAD540=2
        LL2=2.5*(TKN-CORRN)
        XL1=AMAX1(LL1,LL2)
        ZL3=2.5*(TD-C)
        L3=AMIN1(XL1,ZL3)

      ENDIF
	L3final=L3
	IF(LXdisp.GT.0.AND.L3.GT.LXdisp)L3final=LXdisp
C     CALCOLO LUNGHEZZA DISPONIBILE SU PROTRUSIONE L3PROT

      if(LPROT.LT.TESTN.OR.LPROT.EQ.0.) then
C
C     AD 540.2 SKECTHES a & b PUNTO 1
C
        LL2A=1.73*(TKN-TKN1)+2.5*(TKN1-CORRN)+0.73*R2/MM        
        XL1A=AMAX1(LL1,LL2A)
        XL3A=LPROT+2.5*(TKN1-CORRN)
        XL4A=AMIN1(ZL3,XL3)
        L3PROT=AMIN1(XL1A,XL4A,LPROT)        
        IAD540PROT=1
      else
C
C     AD 540.2 SKECTHES a & b PUNTO 2
C
        LL2A=2.5*(TKN-CORRN)
        XL1A=AMAX1(LL1,LL2A)
        ZL3A=2.5*(TD-C)
        L3PROT=AMIN1(XL1A,ZL3A,L3PROT)
        IAD540PROT=2
      end if

c	write(99,'(I5,5F12.5)')IAD540PROT,LL2A,XL1A,ZL3A,XL4A
c     X,LL2A	
c	 CLOSE(99)
C
C     CALCOLO AREA DI RINFORZO SUL BOCCHELLO
C
	FRloc=1
	IF(SetIn.EQ.1.AND.Regola.GT.4)FRloc=FR
      IF(L3final.LE.XLT)THEN
       A2=2.0*(L3final+(TD-TS-C)/FRloc)*(TKN-TX-CORRN)
      ELSEIF(L3final.LT.LL)THEN
c       TETA=ATAN((TKN-TKN1)/(LL-XLT))
	 TETA=THETA
       B1=(LL-L3final)*TAN(TETA)
       B2=TKN-TKN1
       ABC1=2.0*(XLT+(TD-TS-C)/FRloc)*(TKN-TX-CORRN)
       ABC2=(B1+B2)*(L3final-XLT) + 2.0*(TKN1-TX-CORRN)*(L3final-XLT)
       A2=ABC1+ABC2
       TETA=TETA*180.0/GreekPI
      ELSE
       ABC1=2*(XLT+(TD-TS-C)/FRloc)*(TKN-TX-CORRN)
       ABC2=(TKN-TKN1)*(LL-XLT)
	 ABC3=2*(L3final-XLT)*(TKN1-TX-CORRN)
       A2=ABC1+ABC2+ABC3
      ENDIF
      IF(Regola.GT.4)A2=A2*FR
	A2PROT=2.0*L3PROT*(TKN-2*CORRN)
c	WRITE(DOMANDA,'(3F12.3,I3)')ABC1,ABC2,ABC3,IAD540
c      xMESS = MessageBoxEx(NULL,DOMANDA,'ISA'C,MB_YESNO+
c     1	                                 +MB_ICONQUESTION+
c     2                                     +MB_SETFOREGROUND,
c     3                     LANG_ITALIAN)
      return
      end
C************************************************************************
      SUBROUTINE subNOZZLE2
	USE mTYPINV
	REAL*4 XAD5402a
C
C     CALCOLO LIMITI DI RINFORZO SUL BOCCHELLO SECONDO AD 540.2
C     ASME VIII DIV.2  AD.540.2(b)
C
C     Nuova Routine by LP   -   25/06/02
	XAD5402=XLT*TAN(THETA)
	TKN=TKN1+.667*XAD5402
	RMN=(D0+CORRN+TKN)/2
      LL1=0.5*SQRT(RMN*(TKN-CORRN))
C      XL3=LL+2.5*(TKN1-CORRN)

      IF(THETA.LT.30.*GreekPI/180.) THEN
C
C     AD 540.2 SKECTHES c PUNTO 2
C
        IAD540=2
        LL2=1.73*XAD5402+2.5*(TKN1-CORRN)
        XL1=AMAX1(LL1,LL2)
        ZL3=2.5*(TD-C)
        L3=AMIN1(XL1,ZL3)
      Else
C
C     AD 540.2 SKECTHES c PUNTO 1
C
        IAD540=1
        LL2=XLT+2.5*(TKN1-CORRN)
        XL1=AMAX1(LL1,LL2)
        ZL3=2.5*(TD-C)
        L3=AMIN1(XL1,ZL3)
      ENDIF
	L3final=L3
	IF(LXdisp.GT.0.AND.L3.GT.LXdisp)L3final=LXdisp
C     CALCOLO LUNGHEZZA DISPONIBILE SU PROTRUSIONE L3PROT

!      if(LPROT.LT.TESTN.OR.LPROT.EQ.0.) then
C
C     AD 540.2 SKECTHES a & b PUNTO 1
C
!        LL2A=1.73*(TKN-TKN1)+2.5*(TKN1-CORRN)+0.73*R2/MM        
!        XL1A=AMAX1(LL1,LL2A)
!        XL3A=LPROT+2.5*(TKN1-CORRN)
!        XL4A=AMIN1(ZL3,XL3)
!        L3PROT=AMIN1(XL1A,XL4A,LPROT)        
!        IAD540PROT=1
!      else
C
C     AD 540.2 SKECTHES a & b PUNTO 2
C
!        LL2A=2.5*(TKN-CORRN)
!        XL1A=AMAX1(LL1,LL2A)
!        ZL3A=2.5*(TD-C)
!        L3PROT=AMIN1(XL1A,ZL3A,L3PROT)
!        IAD540PROT=2
!      end if

C
C     CALCOLO AREA DI RINFORZO SUL BOCCHELLO
C
      IF(L3final.LE.XLT)THEN
	 ABC1=2*(TD-TS-C)*(TKN-TX-CORRN)
	 XAD5402a=(XLT-L3final)*TAN(THETA)
	 ABC2=2.*L3final*((TKN-TX-CORRN)+(XAD5402a+TKN1-TX-CORRN))/2.
       A2=ABC1+ABC2
      ELSE
       ABC1=2.0*(TD-TS-C)*(TKN-TX-CORRN)
	 ABC1=ABC1+2.*XLT*((TKN-TX-CORRN)+(TKN1-TX-CORRN))/2.
       ABC2=2.*(TKN1-TX-CORRN)*(L3final-XLT)
       A2=ABC1+ABC2
      ENDIF
      IF(Regola.EQ.21)A2=A2*FR
C	A2PROT=2.0*L3PROT*(TKN-2*CORRN)
      return
      end
C************************************************************************
      SUBROUTINE subNOZZLE3
	USE mTYPINV
	REAL W
C
C     CALCOLO LIMITI DI RINFORZO SUL BOCCHELLO SECONDO AD 540.2
C     ASME VIII DIV.2  AD.540.2(c)
C
C     Nuova Routine by LP   -   25/06/02
	RMN=(D0+CORRN+TKN)/2
	W=(PL-DE)/2
	TPLeff=TPL
	IF(TPLeff.GT.1.73*W)TPLeff=1.73*W
	IF(TPLeff.GT.1.5*TD)TPLeff=1.5*TD
      LL1=0.5*SQRT(RMN*(TKN-CORRN))+TPLeff+0.73*R2/MM
      LL2=2.5*(TKN1-CORRN)+TPLeff+0.73*R2/MM
      XL1=AMAX1(LL1,LL2)
      ZL3=2.5*(TD-C)
      L3=AMIN1(ZL3,XL1)
	L3final=L3
	IF(LXdisp.GT.0.AND.L3.GT.LXdisp)L3final=LXdisp
C     CALCOLO LUNGHEZZA DISPONIBILE SU PROTRUSIONE L3PROT

!      if(LPROT.LT.TESTN.OR.LPROT.EQ.0.) then
C
C     AD 540.2 SKECTHES a & b PUNTO 1
C
!        LL2A=1.73*(TKN-TKN1)+2.5*(TKN1-CORRN)+0.73*R2/MM        
!        XL1A=AMAX1(LL1,LL2A)
!        XL3A=LPROT+2.5*(TKN1-CORRN)
!        XL4A=AMIN1(ZL3,XL3)
!        L3PROT=AMIN1(XL1A,XL4A,LPROT)        
!        IAD540PROT=1
!      else
C
C     AD 540.2 SKECTHES a & b PUNTO 2
C
!        LL2A=2.5*(TKN-CORRN)
!        XL1A=AMAX1(LL1,LL2A)
!        ZL3A=2.5*(TD-C)
!        L3PROT=AMIN1(XL1A,ZL3A,L3PROT)
!        IAD540PROT=2
!      end if

C
C     CALCOLO AREA DI RINFORZO SUL BOCCHELLO
C
      A2=2*(L3final+(TD-TS-C))*(TKN-TX-CORRN)
      IF(Regola.EQ.31)A2=A2*FR
C	A2PROT=2.0*L3PROT*(TKN-2*CORRN)
      return
      end
C************************************************************************
      SUBROUTINE subNOZZLE4
	USE mTYPINV
	REAL W
C
C     CALCOLO LIMITI DI RINFORZO SUL BOCCHELLO SECONDO AD 540.2
C     ASME VIII DIV.2  AD.540.2(d)
C
C     Nuova Routine by LP   -   03/10/02
	RMN=(D0+CORRN+TKN)/2
	W=(PL-DE)/2
	TPLeff=TPL
      LL1=1.73*W
      LL2=1.5*TD
	IF(TPLeff.GT.LL1)TPLeff=LL1
	IF(TPLeff.GT.LL2)TPLeff=LL2
      XL1=0
      ZL3=0
      L3=TPLeff
	L3final=L3
	IF(LXdisp.GT.0.AND.L3.GT.LXdisp)L3final=LXdisp
C
C     CALCOLO AREA DI RINFORZO SUL BOCCHELLO
C
      A2=0
      return
      end
