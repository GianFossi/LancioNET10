      SUBROUTINE OPSH(NOZ,NOZ2,ISSUE)
C
C.....COMPENSAZIONE APERTURE SU FONDI SFERICI
C     SECONDO ASME VIII D.2 AD 500-540.
C-----------AGGIORNATO IN DATA 24-6-97 DA TOS VEDI REAL .....
C     IND  = INDICE DEL TIPO DI FONDO
C          = 1 - MANTELLI E FONDI EMISFERICI
C          = 2 - FONDI ELLITTICI
C          = 3 - FONDI TOROSFERICI
C
C     DD3XL= RAGGIO FONDO EMISFERICO/MANTELLO SFERICO
C          =    "   FONDO EMISFERICO
C          =    "   DI SOMMITA' FONDO ELLITTICO
C          =    "   PARTE SFERICA FONDO TOROSFERICO
C
      USE mTYPINV
	USE DFWIN
	IMPLICIT NONE
!DEC$ ATTRIBUTES DLLEXPORT::OPSH
	TYPE(NOZZLE)::NOZ
	TYPE(NozzAd)::NOZ2
	TYPE(ASMERES)::ISSUE
	INTEGER*4 I,xMESS
	CHARACTER*120 DOMANDA
	REAL*4 RAGGIO,RM,RN,EPS,ALFA1,ALFA2
C     Rev.4A - 21/01/98 - 1) Modificato controllo su d/D(basato 
C                            ora sui diam. nominali anziche' cor-
C         CD                 rosi
C                         2) Agggiunta conversione SI
C--------------------------------------------------------------------
      CALL CalcDiamApert(NOZ,ISSUE)
C     RM=DD3XL+C3+TSTT*0.5
	CALL RAGGIOCAL(RAGGIO)
	C=C3
      RM=DD3XL+C3+T*0.5
      RN=(D0+2.0*CORRN)*0.5

C      TEST=(D0+2.0*C3)/(2.*DD3XL+2.0*C3)

      TEST=(D0)/(2.*DD3XL)
      EPS=.01
      IF(TEST.GT.(0.50+EPS)) THEN
C       WRITE(*,*)'d/D > 0.50 USE ASME CODE APPENDIX 4 OR 5 '
C        WRITE(6,1900)
         NOZ%Risult=-1
         RETURN
      END IF
c     TS=TSTT-C3
      RRM=(2.*DD3XL+C3+TD3)*0.5
C      WRITE(*,*)'IS THE NOZZLE TANGENTIAL TO HEAD ? '
C      WRITE(*,*)'=>TYPE Y OR N'
C      READ(*,1)YTANG
C      IF(YTANG.EQ.'Y'.OR.YTANG.EQ.'y')THEN
C       WRITE(*,*)'>>TANGENTIAL OPENING ON SPHERICAL HEAD<<'
C       WRITE(*,*)' DISTANCE NOZZLE AXES FROM C.L. AXES OF'
C       WRITE(*,*)' SPHERICAL HEAD (mm)'
      IF (NOZ%DCL.NE.0.) THEN
	   XLL=ABS(NOZ%DCL)
         XLL=XLL/MM
         ALFA1=ACOS((XLL+RN)/RM)
         ALFA2=ACOS((XLL-RN)/RM)
         ALFA=ALFA2-ALFA1
         D0E=2.0*RM*SQRT(1-(COS(ALFA/2.0))**2)
	   YTANG='Y'
      ELSE
         D0E=D0
	   YTANG='N'
	   XLL=0
      ENDIF
C     'DESIGN PRESSURE - NOZZLE             (Psi)'
	P=P3
      PN=P3
C     'DESIGN TEMPERATURE                  øC'
	TMD=TMD3
      TMN=TMD3

      DD=2.*DD3XL

C     Inizializzaioni .............................................
      MATN=' '
      IPROT=0
      Check='NO'
	S=S3
	TD=TD3
	C=C3
      CALL OpeningCheck(2.*(RN-CORRN),NOZ,NOZ2,ISSUE)
C      IF(CHECK.EQ.'NO') THEN
C       write(*,*)'>>>>>>>>>>Opening NOT Reinforced<<<<<<<<<<<<'
C       return
C      ELSE
C       write(*,*)'>>>>>>>>Opening ADEQUATELY REINFORCED!<<<<<<<<<<<<<'
C      ENDIF
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
C
C.....CONVERSIONE UNITA' ANGLOSASSONI IN UNITA INTERNAZIONALI
	SUBROUTINE OPSHPRI(NOZ,FILE)
!DEC$ ATTRIBUTES DLLEXPORT::OPSHPRI
      USE mTYPINV
	TYPE(NOZZLE)::NOZ
	TYPE(Str50)::FILE
      REAL J01,J02,J03,J04,J1
      J01=PN*MPAvar
	J02=TMN
      IF(UniMis.EQ.1)J02=(TMN-32.0)/1.8
	IF(UniMis.EQ.0)TMN=TMN*1.8+32.
      J03=S3*MPAvar
      J04=SN*MPAvar
      J1=DD3XL*MM
      OPEN(6,FILE=FILE%Str)
	CALL PRINTEST
C     STAMPA ED. ASME APPLICABILE.........
C      WRITE(6,1099)

      WRITE(6,1100)PN*PSIvar,J01,TMN,J02,MAT,MATN,S3*PSIvar,J03,
     x SN*PSIvar,J04       
      if(YTANG.EQ.'Y'.OR.YTANG.EQ.'y')WRITE(6,1101)

C     if (IND.EQ.1) then
       WRITE(6,1199)DD3XL,J1
C     ELSE
C      WRITE(6,1198)2.*DD3XL,J1
C      WRITE(6,1199)DD3XL,J1/2.
C     ENDIF
	TD=TD3
	C=C3
	CALL STAMPAGEOM
	CALL STAMPAR2
      IF(TKN.GT.TKN1)WRITE(6,1207)
	IF(NOZ%Risult.EQ.-2)THEN
         WRITE(6,1207)
	   WRITE(6,5500)
	   CLOSE(6)
	   RETURN
	ENDIF

C.........SALTO PAGINA
      WRITE(6,5000)
	CALL PRINTEST
C     STAMPA ED. ASME APPLICABILE.........
C      WRITE(6,1099)

	CALL STAMPAEXT
      IF(IXL.EQ.1)THEN
       WRITE(6,1503)L1,L1*MM,L2,L2*MM,XLdisp/MM,XLdisp,
     $       FXL,FXL*MM,A1r1,A1r1*MM**2,A1,A1*MM**2
      ELSE
       WRITE(6,1502)L1,L1*MM,L2,L2*MM,FXL,FXL*MM,
     X	 A1r1,A1r1*MM**2,A1,A1*MM**2
      ENDIF
	IF(NOZ%FactVicini.GT.0..AND.NOZ%FactVicini.LT.1.)THEN
	WRITE(6,1504)NOZ%FactVicini
	ENDIF
C
	CALL STAMPAA2
      if(IPROT.EQ.1)write(6,2203)L3PROT,A2PROT


C.........SALTO PAGINA
C      WRITE(6,5000)

C      select case (IND)

C      CASE (1)
C.....STAMPA INTESTAZIONE FONDO SFERICO
C       WRITE(6,1000)POS

C      CASE (2)
C.....STAMPA INTESTAZIONE FONDO TOROSFERICO
C       WRITE(6,1001)POS

C      CASE (3)
C.....STAMPA INTESTAZIONE FONDO ELLITTICO
C       WRITE(6,1002)POS

C      END SELECT
      
C     STAMPA ED. ASME APPLICABILE.........
C      WRITE(6,1099)

      IF(A3.GT.0.)THEN
        IF(2*FXL.GT.PL) THEN
	   WRITE(6,2500)PL,TPL,A3
	  ELSE
	   WRITE(6,2501)2*FXL,TPL,A3
	  ENDIF
	ENDIF
	CALL STAMPAA4
      WRITE(6,1800)AT,A
C
C.....STAMPA VERIFICA SECONDO AD 540-1.(b)
C

C.........SALTO PAGINA
      WRITE(6,5000)
	CALL PRINTEST
C     STAMPA ED. ASME APPLICABILE.........
C      WRITE(6,1099)
C
      CALL STAMPAAEXT
      WRITE(6,3501)L4,L4*MM,L5,L5*MM,L6,L6*MM,
     X	AA1,AA1*MM**2
C
	CALL STAMPAA2
C.........SALTO PAGINA
C      WRITE(6,5000)

C      select case (IND)

C      CASE (1)
C.....STAMPA INTESTAZIONE FONDO SFERICO
C       WRITE(6,1000)POS

C      CASE (2)
C.....STAMPA INTESTAZIONE FONDO TOROSFERICO
C       WRITE(6,1001)POS

C      CASE (3)
C.....STAMPA INTESTAZIONE FONDO ELLITTICO
C       WRITE(6,1002)POS

C      END SELECT
      
C     STAMPA ED. ASME APPLICABILE.........
C      WRITE(6,1099)
      CALL STAMPAA3
	CALL STAMPAA4
      WRITE(6,1800)ATT,AA
C.........SALTO PAGINA
C      WRITE(6,5000)
	CLOSE(6)
	IF(NOZ%InvolucroSU.LT.0)THEN
	    DD=DDsav
	    TD=TDsav
	    TS=TSsav
	ENDIF
      RETURN
cDEC$ FREEFORM
1100  FORMAT('\par \par \par ',5X, &
      'DESIGN PRESSURE                       P\tab : ',F10.2,'  Psi  (',F6.2,' )MPa\par ',/,5X, &
      'DESIGN TEMPERATURE                    T\tab : ',F10.2,'   \''b0F  ( ',F5.0,'  \''b0C)\par ',/,5X, &
      'SHELL MATERIAL          \tab : ',A20,'\par ',5X, &
	'NOZZLE MATERIAL         \tab : ',A20,'\par \par \par ',5X &
      'ALLOWABLE STRESS (shell) \tab : ',F10.1,'  Psi  (',F10.2,' N/mm{\super 2})\par ',/,5X, &
      'ALLOWABLE STRESS (nozzle)\tab : ',F10.1,'  Psi  (',F10.2,' N/mm{\super 2})\par ')
1101  FORMAT('\par ',5X, &
      'NOZZLE ORIENTATION      \tab : TANGENTIAL\par ')
!DEC$ NOFREEFORM
      INCLUDE 'AllFmt.FOR'
      END
	SUBROUTINE PRINTEST
	USE mTYPINV
      select case (IND)
      CASE (1)
C.....STAMPA INTESTAZIONE FONDO SFERICO
       WRITE(6,1000)POS
      CASE (2)
C.....STAMPA INTESTAZIONE FONDO TOROSFERICO
       WRITE(6,1001)POS
      CASE (3)
C.....STAMPA INTESTAZIONE FONDO ELLITTICO
       WRITE(6,1002)POS
      END SELECT
	RETURN
      INCLUDE '1000OPSH.FOR'
	END