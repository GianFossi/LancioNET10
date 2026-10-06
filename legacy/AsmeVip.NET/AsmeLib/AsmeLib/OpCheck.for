      SUBROUTINE OpeningCheck(D0E,NOZ,NOZ2,ISSUE)
c      SUBROUTINE OpeningCheck(PN,TMN,DD,D0,D0E,S,C,TD,TS,MATN,SN,TKN,
c     X                        TKN1,XLT,LL,R2,EN,TX)

C
C     CALCOLO LIMITI DI RINFORZO E AREE DISPONIBILI LUNGO IL FONDO
C     SECONDO AD 540.1
C
      USE mTYPINV
	USE DFWIN
	TYPE(NOZZLE)::NOZ
	TYPE(NozzAd)::NOZ2
	TYPE(ASMERES)::ISSUE
	CHARACTER*120 DOMANDA
      INTEGER*4 xMESS
      CHECK='OK'
	CALL VediRegola(NOZ,NOZ2)
      RMN=(D0+CORRN+TKN)*0.5
     
      CAll GetDataforNozzle(NOZ,NOZ2,ISSUE%AllN)
	CALL RINFORZO(NOZ)
      CALL SHELL(NOZ,ISSUE)
	IF(NOZ%Risult.LT.0)RETURN
C     CALCOLO DEL FATTORE DI RIDUZIONE (VEDI AD 551)
      L=0
	FR=1
	IF(ISSUE%AllN.GT.0.)THEN
	AllNOn=ISSUE%AllN
	FR=SN/AllNOn
	MATnOn=ISSUE%MatN
	ELSE
      FR=SN/S
	AllNOn=0
	ENDIF
	IF(FR.GT.1.)FR=1.
	FRP=1
	IF(SNP.GT.0..AND.Regola.EQ.31)THEN
	 IF(AllNOn.GT.0.)THEN
	   FRP=SNP/AllNOn
	 ELSE
	   FRP=SNP/S
	 ENDIF
	ELSEIF(Regola.EQ.3)THEN
	 FRP=FR 
	ENDIF
	IF(FRP.GT.1.)FRP=1.
      IF(FR.LT.1.0.AND.Regola.LE.3) THEN
       L=1
       A=A/FR
       AA=AA/FR
	 ISSUE%AEXT=ISSUE%AEXT/FR
	 AEXT=AEXT/FR
	 ISSUE%AAEXT=ISSUE%AAEXT/FR
	 AAEXT=AAEXT/FR
      ENDIF
c      A3=0.
C      WRITE(*,*)'AREA FROM WELDS? Y/N'
C      READ(*,1)YWELD
	YWELD='Y'

C
C     CALCOLO AREA DI RINFORZO SUL BOCCHELLO
C
      SELECT CASE(Regola)
	CASE(2,21)
	CALL subNOZZLE2
	CASE(3,31)
	CALL subNOZZLE3
	CASE(4)
	CALL subNOZZLE4
	CASE DEFAULT
      CALL subNOZZLE(RMN)
      END SELECT
      XL6=2.0*L6
	CALL subA3
c	IF(Regola.EQ.31)THEN
c	IF(2*FXL.GT.PL) THEN
c       A3=(PL-DE)*TPL*FRP
c	ELSE
c       A3=(2*FXL-DE)*TPL*FRP
c	ENDIF
c	ENDIF
C
C     CALCOLO AREE DI SALDATURA
C
      A4=(R2**2*0.429204)/(MM**2)*(1+IPROT)
	IF(FILLET.GT.0) A4=(R2/MM)**2
	IF(Regola.GT.5)A4=A4*FR
      IF(Regola.EQ.5)A4=0.
      AT=A1+A2+A2PROT+A3+A4
      LS=0
C.....VERIFICA SE IL RINFORZO RISPETTA LE CONDIZIONI AD 540.1.b
C
c      AA3=0.0
c      IF(A3.GT.0.0)THEN
c       IF(PL.GT.XL6)THEN
c        PPL=XL6
c        AA3=(PPL-D0-2.0*TKN)*TPL*FRP
c       ELSE
c        PPL=PL
c        AA3=A3 
c       ENDIF
c      ENDIF

      ATT=AA1+A2+A2PROT+AA3+A4
      IF(AT.LE.A.OR.AT.LE.AEXT) then
	   NOZ%Risult=-3
         CHECK='NO'
	ELSEIF(ATT.LT.AA.OR.ATT.LT.AAEXT) THEN
         CHECK='NO'
	   NOZ%Risult=-4
	ENDIF
      RETURN
1     FORMAT(A1)
      END
	SUBROUTINE VediRegola(NOZ,NOZ2)
      USE mTYPINV
	TYPE(NOZZLE)::NOZ
	TYPE(NozzAd)::NOZ2
	SetIn=0
      SELECT CASE(NOZ2%UW16)
	CASE(1,2)
	Regola=1  !AD-540.2(a)
	CASE(3)
	Regola=2  !AD-540.2(b)
	CASE(4)
	Regola=3  !AD-540.2(c)
	CASE(9)
	!protusion
	NOZ%Risult=-9
	CASE(5,6,12)
	Regola=12  !Set-on e quindi per Fr.... 
	SetIn=0
	CASE(7,8,10,11)
	Regola=11  !Set-in e quindi per Fr....
	SetIn=1
	CASE(13)
	Regola=11  !Set-in autorinf
	SetIn=1
	CASE(14,15)
	Regola=31
	CASE(16)
	NOZ%Risult=-9
	CASE(17)
	SetIn=1
	NOZ%Risult=-9
	CASE(18)
	Regola=4
	SetIn=1
	CASE(19,20,21,22,23,24,25,26,27)
	!si vedrà
	NOZ%Risult=-9
	CASE(28)         !fodero a penetrazione parziale AD-621.1 (c-1)
	Regola=5
	CASE(29,30,31)
	Regola=6
	NOZ%Risult=-9
	SetIn=1
	CASE(32)
	Regola=11  !Set-in
	SetIn=1
	CASE(33)
	Regola=12  !Set-on
	END SELECT
	RETURN
	END
	SUBROUTINE subA3
	USE mTYPINV
	REAL H
	H=TPL
	IF(H.GT.L3final)H=L3final
	A3=0.
	IF(Regola.EQ.31.OR.Regola.EQ.3.OR.Regola.EQ.4)THEN
	IF(2*FXL.GT.PL) THEN
       A3=(PL-DE)*H
	 IF(Regola.EQ.3)A3=A3-H*H/3
	ELSE
       A3=(2*FXL-DE)*H
	IF(Regola.EQ.3.AND.2*FXL.GT.PL-6*H)A3=A3-H*H*3+((PL/2-FXL)/3)**2*3
	ENDIF
	A3=A3*FRP
	ENDIF
      AA3=0.0
      IF(A3.GT.0.0)THEN
       IF(PL.GT.XL6)THEN
        PPL=XL6
        AA3=(PPL-DE)*H
	IF(Regola.EQ.3.AND.PPL.GT.PL-6*H)A3=A3-H*H*3+((PL/2-PPL)/3)**2*3
       ELSE
        PPL=PL
        AA3=A3/FRP
       ENDIF
	AA3=AA3*FRP
      ENDIF
	END
	SUBROUTINE RINFORZO(NOZ)
      USE mTYPINV
	USE DFWIN
	INTEGER*4 xMESS
	CHARACTER*256 DOMANDA
	TYPE(NOZZLE)::NOZ
	PL=0
	SELECT CASE(Regola)
	CASE(3,4,31)
	CASE DEFAULT
	RETURN
	END SELECT
      PL=NOZ%PadD
c      IF(PL.GT.XZ)PL=XZ
c      TPL1=MM*1.5*TD
C       WRITE(*,*)'THICKNESS OF REINFORCING PAD (mm)',TPL1,'(mm) MAXIMUM'
      TPL=NOZ%PadT
	IF(Regola.EQ.3.OR.Regola.EQ.4)THEN
	  TPL=TPL-NOZ%ShThkNozArea
	  IF(NOZ%Risult<0)RETURN
	  IF(TPL.LE.0.)THEN
	  WRITE(DOMANDA,100)crlf,crlf,char(0)
      xMESS = MessageBoxEx(NULL,DOMANDA,'AsmeVip'C,MB_OK+
     1	             +MB_ICONINFORMATION+MB_SETFOREGROUND,
     3                     LANG_ITALIAN)
	  ELSEIF((PL-DE)/2.LE.3.*TPL.AND.Regola.EQ.3)THEN
	  WRITE(DOMANDA,101)crlf,crlf,char(0)
      xMESS = MessageBoxEx(NULL,DOMANDA,'AsmeVip'C,MB_OK+
     1	             +MB_ICONINFORMATION+MB_SETFOREGROUND,
     3                     LANG_ITALIAN)
	  ENDIF
	ENDIF
c      IF(TPL.GT.TPL1)TPL=TPL1
      TPL=TPL/MM
      PL=PL/MM
	RETURN
100   FORMAT('Ci sono probabilmente dati errati:',A2,
     X 'lo spessore della scarpa risulta non superiore',A2,
     X 'allo spessore del mantello',A1)
101   FORMAT('Ci sono probabilmente dati errati:',A2,
     X 'il diametro della scarp anon è abbastanza',A2,
     X 'grande per alloggiare la transizione 1:3.',A1)
	END