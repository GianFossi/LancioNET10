	SUBROUTINE CalcDiamApert(NOZ,ISSUE)
      USE mTYPINV
	USE DFWIN
	IMPLICIT NONE
	TYPE(NOZZLE)::NOZ
	TYPE(ASMERES)::ISSUE
	CHARACTER*120 DOMANDA
	INTEGER*2,EXTERNAL::MIO_LEN_TRIM
	INTEGER*4 xMESS
C----------------------------------------------------------
	SREXT=ISSUE%SR !Spessore minimo a pressione esterna
	IF(NOZ%Risult.LT.0.)NOZ%Risult=0
      POS=NOZ%Mark(1:MIO_LEN_TRIM(NOZ%Mark))//'                   '
      P=NOZ%Pdes
      TMD=NOZ%Tdes
	MAT=MATsave
	IF(ISSUE%SpCop.GT.0.)THEN
	   TS=ISSUE%SpCop/MM
	   IF(ISSUE%SpCopA>0.)TD=ISSUE%SpCopA/MM
	   IF(ISSUE%Diam>0.)DD=ISSUE%Diam/MM
	   C=ISSUE%CorrCop/MM
	   S=ISSUE%AllCop
	   DDsav=0
	   MATsave=MAT
	   MAT=NOZ%MATECop
	   SpCop=ISSUE%SpCop
	ELSE
	   SpCop=0
         TS=T-C     
c	write(domanda,'(''T,C '',2f12.3,A1)')T,C,char(0)
c      xMESS = MessageBoxEx(NULL,DOMANDA,'AsmeVip'C,MB_YESNO+
c     1	                                 +MB_ICONQUESTION+
c     2                                     +MB_SETFOREGROUND,
c     3                     LANG_ITALIAN)
	   IF(NOZ%InvolucroSU.LT.0)THEN
	      DD=D0
	      TD=TKN1
	      TS=TX
	   ELSE
	      DDsav=DD
	      TDsav=TD
	      TSsav=TS
	   ENDIF
	ENDIF
  	VerificandoPI=ISSUE%VerificandoPI
      D0=NOZ%DiIn
	CORRN=NOZ%CorrA
	IF(NOZ%ONn.GT.CORRN)CORRN=NOZ%ONn
	CORRN=CORRN/MM
	IF(D0.EQ.0.)D0=NOZ%DiOn-2*NOZ%Spess
      D0=D0/MM
	END
C**********************************************************************
      SUBROUTINE OP(NOZ,NOZ2,ISSUE)
C
C.....COMPENSAZIONE APERTURE CILINDRICHE ASME VIII D.2 AD 500-540
C
C     Rev.4A - 21/01/98 - 1) Modificato controllo su d/D(basato 
C                            ora sui diam. nominali anziche' cor-
C         CD                 rosi
C                         2) Agggiunta conversione SI
C                         3) Corretto Calcolo Rinforzo disponibile su bocchello
      USE mTYPINV
	USE DFWIN
	IMPLICIT NONE
!DEC$ ATTRIBUTES DLLEXPORT::OP
	TYPE(NOZZLE)::NOZ
	TYPE(NozzAd)::NOZ2
	TYPE(ASMERES)::ISSUE
	CHARACTER*120 DOMANDA
	INTEGER*4 xMESS
	REAL*4 EPS,RN,RM,ALF1,ALF2,AXES
C---------------------------------------------------------------------
      CALL CalcDiamApert(NOZ,ISSUE)
      TEST=(D0)/(DD)
      EPS=.01
C     IF(TEST.GT.0.5)GOTO 99
      RRM=(DD+C+TD)*0.5
      IF(TEST.GT.(0.5+EPS)) THEN
C'd/D > 0.50 USE ASME CODE APPENDIX 4 OR 5 '
C        WRITE(6,1900)
         NOZ%Risult=-1
         RETURN
      ENDIF

      RN=(D0+2*CORRN)*0.5
      ITANG=0
	D0E=D0
      IF(ISSUE%SpCop.EQ.0..AND.NOZ%DCL.NE.0.)THEN
C     VERIFICA SE BISOGNA COMPENSARE NEL PIANO CIRCONFERENZIALE'
       RM=(DD+2*C+TS)*0.5
c      'DISTANCE C/L NOZZLE FROM SHELL AXES (mm)'
       AXES=NOZ%DCL
       AXES=AXES/MM
       ALF1=ACOS((AXES+RN)/RM)
       ALF2=ACOS((AXES-RN)/RM)
       ALFA=ALF2-ALF1
	 F5201=.5
	 IF(NOZ2%UW16.GE.14.AND.NOZ2%UW16.LE.16)F5201=1.
       DTEST=2.*RM*SQRT(1.-COS(ALFA/2.)**2)
	 XLL=AXES
       IF(DTEST*F5201.GE.D0)THEN
        D0E=DTEST*F5201
        ITANG=1
       ENDIF
c      ENDIF
      ELSEIF(ISSUE%SpCop.EQ.0..AND.NOZ%beta.LT.90.)THEN
C     VERIFICA SU BOCCHELLI INCLINATI LONGITUDINALMENTE
       D0E=D0/SIN(NOZ%beta*GreekPI/180.)
	ELSE
	 AXES=0
	 XLL=0
	ENDIF

C     'DESIGN PRESSURE - NOZZLE             (Psi)'
      PN=P
C     'DESIGN TEMPERATURE                   øC'
      TMN=TMD
C     Inizializzazioni .............................................
      MATN=' '
      YPROT='N'
      IPROT=0
      YWELD='N'
      YNZL='N'
      YPAD='N'
      Check='NO'
      CALL OpeningCheck(2.*(RN-CORRN),NOZ,NOZ2,ISSUE)
      ISSUE%AA=AA
      ISSUE%A=A
      ISSUE%A1=A1
      ISSUE%AA1=AA1
      ISSUE%A2=A2
      ISSUE%A2PROT=A2PROT
      ISSUE%A3=A3
      ISSUE%AA3=AA3
      ISSUE%A4=A4
	RETURN
	END
C****************************************************************
C
C      INIZIA LA FASE DI STAMPA...............
C      by CD  -  24/06/98
C.....CONVERSIONE UNITA' ANGLOSASSONI IN UNITA INTERNAZIONALI
	SUBROUTINE OPPRI(NOZ,FILE)
!DEC$ ATTRIBUTES DLLEXPORT::OPPRI
      USE mTYPINV
	TYPE(NOZZLE)::NOZ
	TYPE(Str50)::FILE
      REAL J01,J02,J03,J04,J1
      CHARACTER*5 MEMB
	CHARACTER*5,PARAMETER::strSHELL='SHELL',strCOVER='COVER'
      IF(SpCop.EQ.0)THEN
	MEMB=strSHELL
	ELSE
	MEMB=strCOVER
	ENDIF
	J01=PN*MPAvar
	J02=TMN
      IF(UniMis.EQ.1)J02=(TMN-32.0)/1.8
	IF(UniMis.Eq.0)TMN=1.8*TMN+32.
      J03=S*MPAvar
      J04=SN*MPAvar
      J1=DD*MM
      OPEN(6,FILE=FILE%Str)
      WRITE(6,1000)POS
      IF(AllNOn.EQ.0)THEN
      WRITE(6,1100)PN*PSIvar,J01,TMN,J02,
     x	MAT,MATN,S*PSIvar,J03,SN*PSIvar,J04
	ELSE
      J03=AllNOn*MPAvar
      WRITE(6,1102)PN*PSIvar,J01,TMN,J02,
     x	MATnOn,MATN,AllNOn,J03,SN*PSIvar,J04
	ENDIF
      WRITE(6,1197)DD,J1
	CALL STAMPAGEOM
      AXES=NOZ%DCL/MM
      AXESMM=AXES*MM 
      IF(AXES.GT.0.)THEN
	  WRITE(6,1205) AXES,AXESMM
        IF(ITANG.EQ.1)THEN
	     WRITE(6,1203)F5201,D0E,D0E*MM
        ELSE
	     WRITE(6,1213)DTEST*MM,F5201
	  ENDIF
	ENDIF
	IF(NOZ%beta.LT.90.)THEN
	  WRITE(6,12060)NOZ%beta,D0E,D0E*MM
	ENDIF
	CALL STAMPAR2
	IF(TKN.GT.TKN1)WRITE(6,1207)
	IF(NOZ%Risult.EQ.-2)THEN
	   WRITE(6,5500)
	   CLOSE(6)
	   RETURN
	ENDIF
C.........SALTO PAGINA
      WRITE(6,5000)
      WRITE(6,1000)POS
	CALL STAMPAEXT
	IF(Regola.EQ.5)THEN
	IF(IXL.EQ.1)THEN
         WRITE(6,1499)MEMB,L1,L1*MM,L2,L2*MM,XL,XL*MM,
     $	   FXL,FXL*MM,MEMB,A1,A1*MM**2
      ELSE
         WRITE(6,1498)MEMB,L1,L1*MM,L2,L2*MM,FXL,FXL*MM,
     X	   MEMB,A1,A1*MM**2
      ENDIF
	ELSE
	IF(IXL.EQ.1)THEN
         WRITE(6,1501)MEMB,L1,L1*MM,L2,L2*MM,XL,XL*MM,
     $	   FXL,FXL*MM,MEMB,A1r1,A1r1*MM**2,A1,A1*MM**2
      ELSE
         WRITE(6,1500)MEMB,L1,L1*MM,L2,L2*MM,FXL,FXL*MM,
     X	   MEMB,A1r1,A1r1*MM**2,A1,A1*MM**2
      ENDIF
	ENDIF
C
	CALL STAMPAA2
      if(IPROT.EQ.1)write(6,2203)L3PROT,A2PROT
      IF(Regola.EQ.31.OR.Regola.EQ.3)THEN
        IF(2*FXL.GT.PL) THEN
	   WRITE(6,2500)FRP,PL,PL*MM,TPL,TPL*MM,A3,A3*MM**2
	  ELSE
	   WRITE(6,2501)FRP,2*FXL,2*FXL*MM,TPL,TPL*MM,A3,A3*MM**2
	  ENDIF
	ELSEIF(Regola.EQ.4)THEN
        IF(2*FXL.GT.PL) THEN
	   WRITE(6,2500)FRP,PL,PL*MM,L3final,L3final*MM,A3,A3*MM**2
	  ELSE
	   WRITE(6,2501)FRP,2*FXL,2*FXL*MM,L3final,L3final*MM,A3,A3*MM**2
	  ENDIF
	ENDIF
	CALL STAMPAA4
      WRITE(6,1800)AT,A
C.........SALTO PAGINA
      WRITE(6,5000)

C
C     STAMPA VERIFICA SECONDO AD-540.1(b)
C
      WRITE(6,1000)POS
C     STAMPA ED. ASME APPLICABILE.........
C      WRITE(6,1099)
      CALL STAMPAAEXT
      WRITE(6,3500)L4,L4*MM,L5,L5*MM,L6,L6*MM,AA1,AA1*MM**2
C
	CALL STAMPAA2
      IF(IPROT.EQ.1)write(6,2203)L3PROT,A2PROT
	CALL STAMPAA3
	CALL STAMPAA4
      WRITE(6,1800)ATT,AA
	CLOSE(6)
	IF(NOZ%InvolucroSU.LT.0.AND.DDsav.GT.0.)THEN
	    DD=DDsav
	    TD=TDsav
	    TS=TSsav
	ENDIF
      RETURN
1     FORMAT(A1)
2     FORMAT(A20)
1000  FORMAT('\par \par \par \par \par \par \par \par \par ',5X,
     x'OPENING ON SHELL ASME VIII D.2 PARA. AD 500-540',
     x'  POS.: ',A20,'\PAR ')
1100  FORMAT('\par \par ',5X,
     X'DESIGN PRESSURE        P\tab : ',F10.2,'  Psi  (',F6.2,' MPa)',
     X'\par ',5X,
     X'DESIGN TEMPERATURE     T\tab : ',F10.2,'   \''b0F  ( ',F5.0,
     X'  \''b0C)',/'\par ',5X,
     X'SHELL MATERIAL          \tab : ',A20,'\par ',5X
     X'NOZZLE MATERIAL         \tab : ',A20,/'\par \par ',5X
     X'ALLOWABLE STRESS (shell)\tab : ',F10.1,'  Psi  (',F10.2,' MPa)',
     X/,'\par ',5X,
     X'ALLOWABLE STRESS (nozzle)\tab : ',F10.1,'  Psi  (',
     XF10.2,' MPa)\par ')
1101   FORMAT('\par \par \par',5X,
     X'               TANGENTIAL OPENING','\par \par')
1102  FORMAT('\par \par ',5X,
     X'DESIGN PRESSURE        P\tab : ',F10.2,'  Psi  (',F6.2,' MPa)',
     X'\par ',5X,
     X'DESIGN TEMPERATURE     T\tab : ',F10.2,'   \''b0F  ( ',F5.0,
     X'  \''b0C)',/'\par ',5X,
     X'SUPPORTING NOZZLE MAT''L \tab : ',A20,'\par ',5X
     X'NOZZLE MATERIAL         \tab : ',A20,/'\par \par ',5X
     X'ALLOWABLE STRESS (supp.n)\tab : ',F10.1,'  Psi  (',F10.2,' MPa)'
     X,/,'\par ',5X,
     X'ALLOWABLE STRESS (nozzle)\tab : ',F10.1,'  Psi  (',
     XF10.2,' MPa)\par ')
      INCLUDE 'AllFmt.FOR'
      END
C******************************************************
	SUBROUTINE STAMPAA2
	USE mTYPINV
	USE DFWIN
	CHARACTER*120 DOMANDA
	INTEGER*4 IFMT,xMESS,MIO_LEN_TRIM
	CHARACTER*25,POINTER::tmtr
      IF(SetIn.EQ.1.AND.Regola.GT.4.OR.Regola.EQ.31) THEN
	   tmtr => tmtrST
      ELSE
	   tmtr => tmtrFR
      ENDIF
	SELECT CASE(Regola)
	CASE(1,11,12,21)
	IF(IAD540.EQ.1)THEN
         IF(L3final.LE.XLT)THEN
	      WRITE(6,1600)LL1,LL1*MM,LL2,LL2*MM,ZL3,ZL3*MM,
     $		  XL3,XL3*MM,L3,L3*MM,L3final,L3final*MM,
     $          tmtr(1:MIO_LEN_TRIM(tmtr)),A2/FR,A2/FR*MM**2
         ELSEIF(L3final.LT.LL)THEN
            WRITE(6,1601)LL1,LL1*MM,LL2,LL2*MM,ZL3,ZL3*MM,
     X		  XL3,XL3*MM,L3,L3*MM,L3final,L3final*MM,TETA,
     X          tmtr(1:MIO_LEN_TRIM(tmtr)),ABC1,ABC1*MM**2,
     X          ABC2,ABC2*MM**2,A2/FR,A2/FR*MM**2
         ELSE
	      WRITE(6,1602)LL1,LL1*MM,LL2,LL2*MM,ZL3,ZL3*MM,XL3,XL3*MM,
     X		  L3,L3*MM,L3final,L3final*MM,tmtr(1:MIO_LEN_TRIM(tmtr)),
     X          ABC1,ABC1*MM**2,
     X          ABC2,ABC2*MM**2,ABC3,ABC3*MM**2,A2/FR,A2/FR*MM**2
         ENDIF
      ENDIF
      IF(IAD540.EQ.2)THEN
	   IF(L3final.LE.XLT) THEN
	      WRITE(6,1603)LL1,LL1*MM,LL2,LL2*MM,ZL3,ZL3*MM,L3,L3*MM,
     X		  L3final,L3final*MM,tmtr(1:MIO_LEN_TRIM(tmtr)),
     X          A2/FR,A2/FR*MM**2
         ELSEIF(L3final.LT.LL)THEN
            WRITE(6,1604)LL1,LL1*MM,LL2,LL2*MM,ZL3,ZL3*MM,L3,L3*MM,
     X	      L3final,L3final*MM,TETA,
     X		  tmtr(1:MIO_LEN_TRIM(tmtr)),ABC1,ABC1*MM**2,
     X          ABC2,ABC2*MM**2,A2/FR,A2/FR*MM**2
         ELSE
	      WRITE(6,1605)LL1,LL1*MM,LL2,LL2*MM,ZL3,ZL3*MM,XL3,XL3*MM,
     X		  L3final,L3final*MM,tmtr(1:MIO_LEN_TRIM(tmtr)),
     X          ABC1,ABC1*MM**2,
     X          ABC2,ABC2*MM**2,ABC3,ABC3*MM**2,A2/FR,A2/FR*MM**2
         ENDIF
      ENDIF
      IF(Regola.GT.4)WRITE(6,1633)A2,A2*MM**2
	CASE(2)
      IF(IAD540.EQ.1)THEN
      IF(L3final.LE.XLT)THEN
         ASSIGN 1620 TO IFMT
	ELSE
         ASSIGN 1621 TO IFMT
	ENDIF 
	ELSEIF(IAD540.EQ.2)THEN
      IF(L3final.LE.XLT)THEN
         ASSIGN 1622 TO IFMT
	ELSE
         ASSIGN 1623 TO IFMT
	ENDIF 
	ENDIF
	   WRITE(6,IFMT)LL1,LL1*MM,LL2,LL2*MM,ZL3,ZL3*MM,L3,L3*MM,
     X		  L3final,L3final*MM,ABC1,ABC1*MM**2,
     X          ABC2,ABC2*MM**2,A2,A2*MM**2
	CASE(14,15)
	   WRITE(6,1606)LL1,LL1*MM,LL2,LL2*MM,ZL3,ZL3*MM,TPLeff,TPLeff*MM,
     X   L3,L3*MM,L3final,L3final*MM,tmtr(1:MIO_LEN_TRIM(tmtr)),
     X   A2/FR,A2/FR*MM**2
	CASE(4)
	   WRITE(6,1607)LL1,LL1*MM,LL2,LL2*MM,L3,L3*MM,L3final,L3final*MM
	CASE DEFAULT
	WRITE(6,1619)Regola
	END SELECT
	RETURN
      INCLUDE 'AllFmt.FOR'
1619  FORMAT('\par \par ',5X,
     X'EXCESS AREA FROM NOZZLE     : A{\sub 2}\par '/5X,
     X'=======================\par ',5X,
     X'Stampa da programmare per Regola n\''b0',I2,'\par ')
1620  FORMAT('\par \par ',5X,
     X'EXCESS AREA FROM NOZZLE     : A{\sub 2}\par '/5X,
     X'=======================\par ',5X,
     X'(AD 540.2) The limit of reinforcement measured normal to vessel',
     X'\par '/5X,'wall will be equal to the greater of ',
     £'(AD 540.2(b)(1)):\par \par ',5X,
     X'l{\sub 1} = 0.5*{{\field{\*\fldinst SYMBOL 214 \\f "Symbol"',
     $' \\s 10}{\fldrslt\f3\fs20}}}(r{\sub m}*(t{\sub n}''-c))\tab = ',
     $F10.3,' inch\tab (',F8.1,' mm)\par '/5X,
     X'l{\sub 2} = L''+2.5*(t{\sub p}-c)\tab = ',
     $F10.3,' inch\tab (',F8.1,' mm)\par '/5X,
     X'but not exceed 2.5*(t-c)\tab = ',F10.3,
     X' inch\tab (',F8.1,' mm)\par '/15X,
     X'l\tab = ',F10.3,' inch\tab (',F8.1,' mm)\par '/5X,
     X/15X,'l adopted\tab = ',F10.3,' inch\tab (',F8.1,' mm)\par '/5X,
     X'REINFORCEMENT AVAILABLE IN THE NOZZLE\par \par '/5X
     X'A{\sub 21}=    2(t-t{\sub r}-c)*(t{\sub n}-t{\sub rn}-c)',       
     X'\tab = ',F10.3,' inch{\super 2}\tab (',F8.1,
     X' mm{\super 2})\par '/5X,
     X'A{\sub 22}=(t{\sub p}+t{\sub n}-2t{\sub rn}-2c+(L''-l)*tan{{\fiel
     Xd{\*\fldinst SYMBOL 113 \\f "Symbol" \\s 10}{\fldrslt\f3\fs20}}}+t
     X{\sub n}-t{\sub p})*l\tab = ',F10.3,' inch{\super 2}\tab (',F8.1,
     X' mm{\super 2})\par '/
     X5X,'A{\sub 2} =         A{\sub 21} + A{\sub 22}\tab = '
     $,F10.3,' inch{\super 2}\tab (',F8.1,' mm{\super 2})\par ')
1621  FORMAT('\par \par ',5X,
     X'EXCESS AREA FROM NOZZLE     : A{\sub 2}\par '/5X,
     X'=======================\par ',5X,
     X'(AD 540.2) The limit of reinforcement measured normal to vessel',
     X'\par '/5X,'wall will be equal to the greater of ',
     £'(AD 540.2(b)(1)):\par \par ',5X,
     X'l{\sub 1} = 0.5*{{\field{\*\fldinst SYMBOL 214 \\f "Symbol"',
     $' \\s 10}{\fldrslt\f3\fs20}}}(r{\sub m}*(t{\sub n}''-c))\tab = ',
     $F10.3,' inch\tab (',F8.1,' mm)\par '/5X,
     X'l{\sub 2} = L''+2.5*(t{\sub p}-c)\tab = ',
     $F10.3,' inch\tab (',F8.1,' mm)\par '/5X,
     X'but not exceed 2.5*(t-c)\tab = ',F10.3,
     X' inch\tab (',F8.1,' mm)\par '/15X,
     X'l\tab = ',F10.3,' inch\tab (',F8.1,' mm)\par '/5X,
     X/15X,'l adopted\tab = ',F10.3,' inch\tab (',F8.1,' mm)\par '/5X,
     X'REINFORCEMENT AVAILABLE IN THE NOZZLE\par \par '/5X
     X'A{\sub 21}= 2(t-t{\sub r}-c)*(t{\sub n}-t{\sub rn}-c)+',
     X'L''(t{\sub n}+t{\sub p}-2t{\sub rn}-2c)',       
     X'\tab = ',F10.3,' inch{\super 2}\tab (',F8.1,
     X' mm{\super 2})\par '/5X,
     X'A{\sub 22}=2(t{\sub p}-t{\sub rn}-c)*(l-L'')',
     X'\tab = ',F10.3,' inch{\super 2}\tab (',F8.1,
     X' mm{\super 2})\par '/ 
     X5X,'A{\sub 2} =         A{\sub 21} + A{\sub 22}\tab = '
     $,F10.3,' inch{\super 2}\tab (',F8.1,' mm{\super 2})\par ')
1622  FORMAT('\par \par ',5X,
     X'EXCESS AREA FROM NOZZLE     : A{\sub 2}\par '/5X,
     X'=======================\par ',5X,
     X'(AD 540.2) The limit of reinforcement measured normal to vessel',
     X'\par '/5X,'wall will be equal to the greater of ',
     £'(AD 540.2(b)(1)):\par \par ',5X,
     X'l{\sub 1} = 0.5*{{\field{\*\fldinst SYMBOL 214 \\f "Symbol"',
     $' \\s 10}{\fldrslt\f3\fs20}}}(r{\sub m}*(t{\sub n}''-c))\tab = ',
     $F10.3,' inch\tab (',F8.1,' mm)\par '/5X,
     X'l{\sub 2} = 1.73L''tan{{\field{\*\fldinst SYMBOL',
     X' 113 \\f "Symbol" \\s 10}{\fldrslt\f3\fs20}}}+',
     X'2.5*(t{\sub p}-c)\tab = ',
     $F10.3,' inch\tab (',F8.1,' mm)\par '/5X,
     X'but not exceed 2.5*(t-c)\tab = ',F10.3,
     X' inch\tab (',F8.1,' mm)\par '/15X,
     X'l\tab = ',F10.3,' inch\tab (',F8.1,' mm)\par '/5X,
     X/15X,'l adopted\tab = ',F10.3,' inch\tab (',F8.1,' mm)\par '/5X,
     X'REINFORCEMENT AVAILABLE IN THE NOZZLE\par \par '/5X
     X'A{\sub 21}=    2(t-t{\sub r}-c)*(t{\sub n}-t{\sub rn}-c)',       
     X'\tab = ',F10.3,' inch{\super 2}\tab (',F8.1,
     X' mm{\super 2})\par '/5X,
     X'A{\sub 22}=(t{\sub p}+t{\sub n}-2t{\sub rn}-2c+(L''-l)*tan{{\fiel
     Xd{\*\fldinst SYMBOL 113 \\f "Symbol" \\s 10}{\fldrslt\f3\fs20}}}+t
     X{\sub n}-t{\sub p})*l\tab = ',F10.3,' inch{\super 2}\tab (',F8.1,
     X' mm{\super 2})\par '/
     X5X,'A{\sub 2} =         A{\sub 21} + A{\sub 22}\tab = '
     $,F10.3,' inch{\super 2}\tab (',F8.1,' mm{\super 2})\par ')
1623  FORMAT('\par \par ',5X,
     X'EXCESS AREA FROM NOZZLE     : A{\sub 2}\par '/5X,
     X'=======================\par ',5X,
     X'(AD 540.2) The limit of reinforcement measured normal to vessel',
     X'\par '/5X,'wall will be equal to the greater of ',
     £'(AD 540.2(b)(1)):\par \par ',5X,
     X'l{\sub 1} = 0.5*{{\field{\*\fldinst SYMBOL 214 \\f "Symbol"',
     $' \\s 10}{\fldrslt\f3\fs20}}}(r{\sub m}*(t{\sub n}''-c))\tab = ',
     $F10.3,' inch\tab (',F8.1,' mm)\par '/5X,
     X'l{\sub 2} = 1.73L''tan{{\field{\*\fldinst SYMBOL',
     X' 113 \\f "Symbol" \\s 10}{\fldrslt\f3\fs20}}}+',
     X'2.5*(t{\sub p}-c)\tab = ',
     $F10.3,' inch\tab (',F8.1,' mm)\par '/5X,
     X'but not exceed 2.5*(t-c)\tab = ',F10.3,
     X' inch\tab (',F8.1,' mm)\par '/15X,
     X'l\tab = ',F10.3,' inch\tab (',F8.1,' mm)\par '/5X,
     X/15X,'l adopted\tab = ',F10.3,' inch\tab (',F8.1,' mm)\par '/5X,
     X'REINFORCEMENT AVAILABLE IN THE NOZZLE\par \par '/5X
     X'A{\sub 21}= 2(t-t{\sub r}-c)*(t{\sub n}-t{\sub rn}-c)+',
     X'L''(t{\sub n}+t{\sub p}-2t{\sub rn}-2c)',       
     X'\tab = ',F10.3,' inch{\super 2}\tab (',F8.1,
     X' mm{\super 2})\par '/5X,
     X'A{\sub 22}=2(t{\sub p}-t{\sub rn}-c)*(l-L'')',
     X'\tab = ',F10.3,' inch{\super 2}\tab (',F8.1,
     X' mm{\super 2})\par '/ 
     X5X,'A{\sub 2} =         A{\sub 21} + A{\sub 22}\tab = '
     $,F10.3,' inch{\super 2}\tab (',F8.1,' mm{\super 2})\par ')
	END
C******************************************************
	SUBROUTINE STAMPAA3
	USE mTYPINV
      IF(Regola.EQ.31.OR.Regola.EQ.3)THEN
	   IF(PL.EQ.PPL)THEN
	     WRITE(6,2500)FRP,PPL,PPL*MM,TPL,TPL*MM,AA3,AA3*MM**2
	   ELSE
	     WRITE(6,2501)FRP,PPL,PPL*MM,TPL,TPL*MM,AA3,AA3*MM**2
	   ENDIF
	ELSEIF(Regola.EQ.4)THEN
	   IF(PL.EQ.PPL)THEN
	     WRITE(6,2500)FRP,PPL,PPL*MM,L3final,L3final*MM,AA3,AA3*MM**2
	   ELSE
	     WRITE(6,2501)FRP,PPL,PPL*MM,L3final,L3final*MM,AA3,AA3*MM**2
	   ENDIF
	ENDIF
	RETURN
	INCLUDE 'AllFmt.FOR'
	END
	SUBROUTINE STAMPAA4
	USE mTYPINV
	IF(FILLET.GT.0.)THEN
	    WRITE(6,1701)A4,A4*MM**2
	ELSE
	    WRITE(6,1700)A4,A4*MM**2
	ENDIF
	RETURN
	INCLUDE 'AllFmt.FOR'
	END
	SUBROUTINE STAMPAR2
	USE mTYPINV
	WRITE(6,1205)R1/MM,R1
      IF(FILLET.GT.0)THEN
	WRITE(6,1206)R2/MM,R2
	ELSE
	WRITE(6,1207)R2/MM,R2
	ENDIF
	RETURN
cDEC$ FREEFORM
1205  FORMAT( &
      'SPECIFIED FILLET RADIUS,              R{\sub 1}\tab : ',F10.4,' inch\tab (',F10.2   ,'  mm)\par ')
1206  FORMAT( &
      'SPECIFIED WELD FILLET LEG,            R{\sub 2}\tab : ',F10.4,' inch\tab (',F10.2   ,'  mm)\par \par \par \par ')
1207  FORMAT( &
      'SPECIFIED FILLET RADIUS,              R{\sub 2}\tab : ',F10.4,' inch\tab (',F10.2   ,'  mm)\par \par \par \par ')
!DEC$ NOFREEFORM
	END
	SUBROUTINE STAMPAGEOM
	USE mTYPINV
	IMPLICIT NONE
	REAL J11
      J11=LPROT*MM
	IF(Regola.EQ.4)THEN
      WRITE(6,1206)TD,TD*MM,ShThNzAr,ShThNzAr*MM,D0,D0*MM,
     X	(PL-D0)/2,(PL-D0)/2*MM
	WRITE(6,1209)CORRN,CORRN*MM,LXdisp,LXdisp*MM,
     X             TS,TS*MM,XLdisp/MM,XLdisp,TX,TX*MM
	ELSE
      WRITE(6,1200)TD,TD*MM,ShThNzAr,ShThNzAr*MM,D0,D0*MM,
     X	TKN,TKN*MM,TKN1,TKN1*MM
	IF(TKN.GT.TKN1)THEN
	WRITE(6,1202)THETA*180/GreekPI
	WRITE(6,1201)CORRN,CORRN*MM,XLT,XLT*MM,LL,LL*MM,LXdisp,LXdisp*MM,
     X             TS,TS*MM,XLdisp/MM,XLdisp,TX,TX*MM
	ELSE
	WRITE(6,1223)CORRN,CORRN*MM,XLT,XLT*MM,LXdisp,LXdisp*MM,
     X             TS,TS*MM,XLdisp/MM,XLdisp,TX,TX*MM
	ENDIF
	ENDIF
	IF(LXdisp.EQ.0..OR.XLdisp.EQ.0.)WRITE(6,1225)
	IF(SREXT.GT.0)THEN
	WRITE(6,1214)SREXT/MM,SREXT
	ENDIF
      IF(PL.GT.0..AND.TPL.GT.0.)WRITE(6,1208)PL,PL*MM,
     XTPL,TPL*MM	       
      SELECT CASE (IAD540)
       CASE(1) 
      WRITE(6,1211)
       CASE(2)
      WRITE(6,1212)
      END SELECT
      IF(D0E.GT.D0)WRITE(6,1204)D0E,D0E*MM,XLL,XLL*MM

C     Aggiunta Stampa Dati di Input per Protrusione
C     by CD  -  26/06/98

      IF(IPROT.EQ.1) THEN
       WRITE(6,2200) LPROT,J11      
       SELECT CASE (IAD540PROT)
        case (1) 
        WRITE(6,2201)
        case (2)
        WRITE(6,2202)
       END SELECT
      END IF
	IF(chkAD550f.GT.0.)WRITE(6,1226)GreekAlpha,GreekAlpha,
     XGreekDeltaMaiusc,chkAD550f,MinoreUguale,GreekAlpha,AlfR/1.8,AlfR,
     X	GreekAlpha,AlfS/1.8,AlfS,
     X    GreekDeltaMaiusc,1.8*delt+32,delt
	RETURN
cDEC$ FREEFORM
1200  FORMAT( &
      'SHELL/HEAD THICKNESS                  t\tab : ',F10.4,' inch\tab (',F10.2,'  mm)\par '/ &
      'ACTUAL THK IN NOZZLE AREA             t{\sub s}\tab : ',F10.4,' inch\tab (',F10.2,'  mm)\par '/ &
      'NOZZLE INSIDE DIAMETER                d\tab : ',F10.4,' inch\tab (',F10.2,'  mm)\par '/ &
      'NOZZLE THICKNESS                      t{\sub n}\tab : ',F10.4,' inch\tab (',F10.2,'  mm)\par '/ &
      'CONNECTING PIPE/FLANGE NECK THK       t{\sub p}\tab: ',F10.4,' inch\tab (',F10.2,'  mm)\par ')
1201	FORMAT( &
      'CORROSION / CLAD THICKNESS            C\tab : ',F10.4,' inch\tab (',F10.3,'  mm)\par '/ &
      'NOZZLE LENGTH with TK. t{\sub n},            h\tab : ',F10.4,' inch\tab (',F10.2,'  mm)\par '/ &
      'TOTAL NOZZLE LENGTH (*)               L{\sub n}\tab : ',F10.4,' inch\tab (',F10.2,'  mm)\par '/ &
      'AVAILABLE NOZZLE LENGTH               L{\sub a}\tab : ',F10.4,' inch\tab (',F10.2,'  mm)\par '/ &
      'MINIMUM SHELL THICKNESS               t{\sub r}\tab : ',F10.4,' inch\tab (',F10.2,'  mm)\par '/ &
      'AVAILABLE SHELL LENGTH                L{\sub s}\tab : ',F10.4,' inch\tab (',F10.2,'  mm)\par '/ &
      'MINIMUM NOZZLE THICKNESS              t{\sub rn}\tab : ',F10.4,' inch\tab (',F10.2,'  mm)\par ')
1202	FORMAT( &
      'TRANSITION SLOPE BETW.t{\sub n} & t{\sub p}\tab : ',F8.2,'   degrees\par ')
1206  FORMAT( &
      'SHELL/HEAD THICKNESS                  t\tab : ',F10.4,' inch\tab (',F10.2,'  mm)\par '/ &
      'ACTUAL THK IN NOZZLE AREA             t{\sub s}\tab : ',F10.4,' inch\tab (',F10.2,'  mm)\par '/ &
      'NOZZLE INSIDE DIAMETER                d\tab : ',F10.4,' inch\tab (',F10.2,'  mm)\par '/ &
      'PAD WIDTH                             W\tab : ',F10.4,' inch\tab (',F10.2,'  mm)\par ')
1208  FORMAT( &
      'REINFORCING PAD DIAMETER              D{\sub p}:\tab ',F10.4,' inch\tab (',F10.2,'  mm)\par '/ &
      'REINFORCING PAD THICKNESS             t{\sub e}:\tab ',F10.4,' inch\tab (',F10.2,'  mm)\par ')
1209	FORMAT( &
      'CORROSION / CLAD THICKNESS            C\tab : ',F10.4,' inch\tab (',F10.3,'  mm)\par '/ &
      'AVAILABLE NOZZLE LENGTH               L{\sub a}\tab : ',F10.4,' inch\tab (',F10.2,'  mm)\par '/ &
      'MINIMUM SHELL THICKNESS               t{\sub r}\tab : ',F10.4,' inch\tab (',F10.2,'  mm)\par '/ &
      'AVAILABLE SHELL LENGTH                L{\sub s}\tab : ',F10.4,' inch\tab (',F10.2,'  mm)\par '/ &
      'MINIMUM NOZZLE THICKNESS              t{\sub rn}\tab : ',F10.4,' inch\tab (',F10.2,'  mm)\par ')
1214	FORMAT( &
      'MIN SHELL THK for ext.pr.             s{\sub r}\tab : ',F10.4,' inch\tab (',F10.2,'  mm)\par '/) 
1223	FORMAT( &
      'CORROSION / CLAD THICKNESS            C\tab : ',F10.4,' inch\tab (',F10.3,'  mm)\par '/ &
      'NOZZLE LENGTH with TK. t{\sub n},            h\tab : ',F10.4,' inch\tab (',F10.2,'  mm)\par '/ &
      'AVAILABLE NOZZLE LENGTH               L{\sub a}\tab : ',F10.4,' inch\tab (',F10.2,'  mm)\par '/ &
      'MINIMUM SHELL THICKNESS               t{\sub r}\tab : ',F10.4,' inch\tab (',F10.2,'  mm)\par '/ &
      'AVAILABLE SHELL LENGTH                L{\sub s}\tab : ',F10.4,' inch\tab (',F10.2,'  mm)\par '/ &
      'MINIMUM NOZZLE THICKNESS              t{\sub rn}\tab : ',F10.4,' inch\tab (',F10.2,'  mm)\par ')
1225  FORMAT( &
      '   (Note: a zero available length stands for no additional limits\par ', &
	'          with respect to Code requirements in AD-560)\par ') 
1226  FORMAT(5X,'\par ', &
'Rule AD-550(f) shall apply as follows:\par '/10X, &
'|(',A71,'{\sub R} - ',A71,'{\sub V})',A71,'T| =',F10.7,1X,A71,' 0.0008\par'/15X, &
A71,'{\sub R} \tab : ',E9.3,'\''b0F{\super -1}\tab (',1PE10.3,'\''b0C{\super -1})\par '/15X, &
A71,'{\sub V} \tab : ',0PE9.3,'\''b0F{\super -1}\tab (',1PE10.3,'\''b0C{\super -1})\par '/15X, &
A71,'T \tab : ',0PF6.1,'\''b0F\tab (',F5.1,'\''b0C)\par \par ')
!DEC$ NOFREEFORM
2200  FORMAT('\par ',5X,
     X'NOZZLE PROTRUDING LENGTH Lprot: ',F10.4,' inch ('
     X,F10.4,' mm)\par ')
2201  FORMAT(3X,'(Note: Lprot< 2.5(tn-c)+K)\par ')
2202  FORMAT(3X,'(Note: Lprot> 2.5(tn-c)+K)\par ')
	INCLUDE 'Allfmt.for'
	END
	SUBROUTINE STAMPAEXT
	USE mTYPINV
	INTEGER*4 IFMT
	IF(SpCop.EQ.0..AND.D0E.GT.D0)WRITE(6,13040)
      IF(Regola.EQ.5)THEN
	  IF(SpCop.EQ.0.)THEN
	   WRITE(6,1304)A,A*MM**2
         IF(AEXT.GT.0)WRITE(6,1404)AEXT,AEXT*MM**2
        ELSE
	   WRITE(6,1305)A,A*MM**2
         IF(AEXT.GT.0)WRITE(6,1405)AEXT,AEXT*MM**2
	  ENDIF
	  RETURN
	ENDIF
	IF(L.EQ.1)THEN 
	   IF(SpCop.EQ.0)THEN
	   WRITE(6,1300)FR,A,A*MM**2
	   ELSE
	   WRITE(6,1302)FR,A,A*MM**2
	   ENDIF
         IF(AEXT.GT.0)WRITE(6,1301)FR,AEXT,AEXT*MM**2
	ENDIF
	IF(L.EQ.0)THEN
	   IF(Regola.GT.3)WRITE(6,1303)FR
	   IF(SpCop.EQ.0)THEN
	      ASSIGN 1400 TO IFMT
	      IF(FR.LT.1..AND.SetIn)THEN
		    IF(Regola==4)THEN
			 ASSIGN 1411 TO IFMT
	        ELSE
			 ASSIGN 1410 TO IFMT
	        ENDIF
            ENDIF
	   ELSE
 	      ASSIGN 1402 TO IFMT
	      IF(FR.LT.1..AND.SetIn)ASSIGN 1412 TO IFMT
	   ENDIF
	   WRITE(6,IFMT)A,A*MM**2
         IF(AEXT.GT.0)WRITE(6,1401)AEXT,AEXT*MM**2
      ENDIF
	RETURN
1300  FORMAT('\par ',5X,
     X'{\ul REINFORCEMENT AREA REQUIRED} : ',
     X'A/F{\sub R} (AD.540.1.a)\par ',5X,
     X'STRENGTH REDUCTION FACTOR F{\sub R}:',F5.2,'\par ',5X,
     X'F{\sub R} > 0.80 (see AD 551)\par \par ',5X,
     X'A = (d+2c) * t{\sub r} / F{\sub R}\tab =',
     XF10.3,' inch{\super 2}\tab (',F10.1,' mm{\super 2})\par ')
1301  FORMAT('\par ',5X,
     X'{\ul REINFORCEMENT AREA REQUIRED for external pressure} : ',
     X'A/F{\sub R} (AD.520.(b))\par ',5X,
     X'STRENGTH REDUCTION FACTOR F{\sub R}:',F5.2,'\par ',5X,
     X'F{\sub R} > 0.80 (see AD 551)\par \par ',5X,
     X'A = 0.5 (d+2c) * s{\sub r} / F{\sub R}\tab =',
     XF10.3,' inch{\super 2}\tab (',F10.1,' mm{\super 2})\par ')
1302  FORMAT('\par ',5X,
     X'{\ul REINFORCEMENT AREA REQUIRED} : ',
     X'A/F{\sub R} (AD.540.1.a)\par ',5X,
     X'STRENGTH REDUCTION FACTOR F{\sub R}:',F5.2,'\par ',5X,
     X'F{\sub R} > 0.80 (see AD 551)\par \par ',5X,
     X'A = 0.5 * (d+2c) * t{\sub r} / F{\sub R}\tab =',
     XF10.3,' inch{\super 2}\tab (',F10.1,' mm{\super 2})\par ')
1303  FORMAT('\par ',5X,
     X'STRENGTH REDUCTION FACTOR F{\sub R}:',F5.2,'\par ',5X,
     X'F{\sub R} > 0.80 (see AD 551)\par ')
13040 FORMAT('\par ',5X,
     X'Note: Inclined nozzle. In the following formulas'/
     X'\par ',10X,'please read d{\sub ch} in lieu of d.')
1304  FORMAT('\par ',5X,
     X'{\ul REINFORCEMENT AREA REQUIRED} : ',
     X'A (AD.540.1.a)\par ',5X,
     X'A = (d+2t{\sub n}) * t{\sub r}\tab =',
     XF10.3,' inch{\super 2}\tab (',F10.1,' mm{\super 2})\par ')
1305  FORMAT('\par ',5X,
     X'{\ul REINFORCEMENT AREA REQUIRED} : ',
     X'A (AD.530)\par ',5X,
     X'A = 0.5(d+2t{\sub n}) * t{\sub r}\tab =',
     XF10.3,' inch{\super 2}\tab (',F10.1,' mm{\super 2})\par ')
1400  FORMAT('\par ',5X,
     X'{\ul REINFORCEMENT AREA REQUIRED} : ',
     X'A    (AD.540.1.a)\par \par '/5X,
     X'A = (d+2c)t{\sub r}\tab =',F10.3
     £,' inch{\super 2}\tab (',F10.1,' mm{\super 2})\par ')
1401  FORMAT('\par ',5X,
     X'{\ul REINFORCEMENT AREA REQUIRED for external pressure} : ',
     X'A    (AD.520.(b))\par \par '/5X,
     X'A = 0.5 (d+2c) * s{\sub r}      =',F10.3
     £,' inch{\super 2}\tab (',F10.1,' mm{\super 2})\par \par ')
1402  FORMAT('\par ',5X,
     X'{\ul REINFORCEMENT AREA REQUIRED} : ',
     X'A    (AD.540.1.a)\par \par '/5X,
     X'A = 0.5(d+2c)t{\sub r}\tab =',F10.3
     £,' inch{\super 2}\tab (',F10.1,' mm{\super 2})\par ')
1404  FORMAT('\par ',5X,
     X'{\ul REINFORCEMENT AREA REQUIRED for external pressure} : ',
     X'A (AD.520.(b))\par ',5X,
     X'A = 0.5 (d+2t{\sub n}) * t{\sub r}\tab =',
     XF10.3,' inch{\super 2}\tab (',F10.1,' mm{\super 2})\par ')
1405  FORMAT('\par ',5X,
     X'{\ul REINFORCEMENT AREA REQUIRED for external pressure} : ',
     X'apertura su coperchio a press.ext. senza senso\par ',5X,
     X'A = 0.5 (d+2t{\sub n}) * t{\sub r}\tab =',
     XF10.3,' inch{\super 2}\tab (',F10.1,' mm{\super 2})\par ')
1410  FORMAT('\par ',5X,
     X'{\ul REINFORCEMENT AREA REQUIRED} : ',
     X'A    (AD.540.1.a)\par \par '/5X,
     X'A=(d+2c)t{\sub r}+2t{\sub r}(t{\sub n}-c)(1-F{\sub R})\tab ='
     X,F10.3,' inch{\super 2}\tab (',F10.1,' mm{\super 2})\par ')
1411  FORMAT('\par ',5X,
     X'{\ul REINFORCEMENT AREA REQUIRED} : ',
     X'A    (AD.540.1.a)\par \par '/5X,
     X'A=(d+2c)t{\sub r}+2t{\sub r}(W-c)(1-F{\sub R})\tab ='
     X,F10.3,' inch{\super 2}\tab (',F10.1,' mm{\super 2})\par ')
1412  FORMAT('\par ',5X,
     X'{\ul REINFORCEMENT AREA REQUIRED} : ',
     X'A    (AD.540.1.a)\par \par '/
     X'A=0.5[(d+2c)t{\sub r}+2t{\sub r}(t{\sub n}-c)(1-F{\sub R})]',
     X'\tab =',F10.3,' inch{\super 2}\tab (',F10.1,
     X' mm{\super 2})\par ')
	END
	SUBROUTINE STAMPAAEXT
	USE mTYPINV
      IF(L.EQ.1) then
        WRITE(6,2300)FR,AA,AA*MM**2
        IF(AAEXT.GT.0)WRITE(6,2301)AAEXT,AAEXT*MM**2
      ELSE
        WRITE(6,2400)AA,AA*MM**2
        IF(AAEXT.GT.0)WRITE(6,2401)AAEXT,AEXT*MM**2
      ENDIF
	RETURN
2300  FORMAT('\par ',5X,
     X'{\ul REINFORCEMENT AREA REQUIRED} : ',
     X'A''/FR (AD.540.1.b)\par ',5X,
     X'STRENGTH REDUCTION FACTOR FR:',F5.2,'\par ',5X,
     X'FR > 0.80 (see AD 551)\par \par ',5X,
     X'          A'' = 2/3 A \tab = ',
     XF10.3,' inch{\super 2}\tab (',F10.1,' mm{\super 2})\par ')
2400  FORMAT('\par ',5X,
     X'{\ul REINFORCEMENT AREA REQUIRED} : ',
     X'A''    (AD.540.1.b)\par \par '/5X,
     X'          A'' = 2/3 A\tab = ',F10.3
     £,' inch{\super 2}\tab (',F10.1,' mm{\super 2})\par ')
2301  FORMAT('\par ',5X,
     X'{\ul REINFORCEMENT AREA REQUIRED for external pressure} : ',
     X'A/FR (AD.520.(b))\par ',5X,
     X'STRENGTH REDUCTION FACTOR FR:',F5.2,'\par ',5X,
     X'FR > 0.80 (see AD 551)\par \par ',5X,
     X'          A = 1/3 (d+2c) * s{\sub r} / FR =',
     XF10.3,' inch{\super 2}\tab (',F10.1,' mm{\super 2})\par ')
2401  FORMAT('\par ',5X,
     X'{\ul REINFORCEMENT AREA REQUIRED for external pressure} : ',
     X'A    (AD.520.(b))\par \par '/5X,
     X'          A = 1/3 (d+2c) * s{\sub r}      =',F10.3
     £,' inch{\super 2}\tab (',F10.1,' mm{\super 2})\par ')
	END