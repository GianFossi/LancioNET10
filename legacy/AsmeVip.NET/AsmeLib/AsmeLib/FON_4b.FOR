      SUBROUTINE FON(MEMBRATURA,Config,p0,tdtd,T1bas)
C
C     Revisionata Sequenza di Introduzione Dati di Input
C     by CD -  02/97/98
	USE mTYPINV
	USE DFWIN
	IMPLICIT NONE
	INTEGER*4 I,xMESS
	CHARACTER*120 DOMANDA
	REAL*4 p0,tdtd,T1bas,D1,RK,XLloc
!DEC$ ATTRIBUTES DLLEXPORT::FON
	TYPE(Involucro)::MEMBRATURA
	TYPE(asConfig)::Config
C      WRITE(*,*)' HEMISPHERICAL HEADS ===> 1'
C      WRITE(*,*)' TORISPHERICAL HEADS ===> 2'
C      WRITE(*,*)' ELLIPSOIDAL   HEADS ===> 3'
      SELECT CASE (MEMBRATURA%ms)
	CASE(1)
C  1 "Ellipsoidal Head : D/2h=2.0  "
	I=3
	CASE(2)
C  2 "Ellipsoidal Head : D/2h<>2.0 "
	I=3
	CASE(3)
C  3 "Torisph.Head : r=0.06L & L=Do" 
	I=2
	CASE(6)
C  4 "Torispherical Head : r>0.06L "
	I=2
	CASE(4)
C  3 "Kloepper" 
	I=2
	CASE(5)
C  4 "Korbbogen"
	I=2
	CASE(7)
	I=1
C  5 "Emispherical Head            "
	CASE(8)
	I=1
C  5 "Calotta sferica     "
	END SELECT
C      WRITE(*,*)' DESIGN PRESSURE                  (Psi)?'
      P3=p0
C      WRITE(*,*)' DESIGN TEMPERATURE                (øC)?'
      TMD3=tdtd
C      TMD3=TMD3*1.8+32.0

      MAT=MEMBRATURA%MATE
	MATsave=MAT

C      WRITE(*,*)'ALL. STRESS AT DESIGN TEMPERATURE (Psi)?'
      IF(Config%VerificandoPI==0)THEN
      S3=MEMBRATURA%ST
	else
	S3=MEMBRATURA%Shydr
	endif
c	WRITE(DOMANDA,'(2HI=,2I3,f12.3)')I,MEMBRATURA%ms,tdtd
c      xMESS = MessageBoxEx(NULL,DOMANDA,'ISA'C,MB_YESNO+
c     1	                                 +MB_ICONQUESTION+
c     2                                     +MB_SETFOREGROUND,
c     3                     LANG_ITALIAN)
C      WRITE(*,*)'INSIDE DIAMETER                   (mm)?'
      D1=MEMBRATURA%di
      IF(I.EQ.1)THEN
	DD3=MEMBRATURA%L0*2/MM
	ELSE
	DD3=D1/MM
      ENDIF

      IF(I.EQ.2)THEN
C       WRITE(*,*)'INSIDE KNUCKLE RADIUS  r           (mm)?'
      RK=MEMBRATURA%R0
      RK=RK/MM
C       WRITE(*,*)'CROWN RADIUS           L           (mm)?'
      XLloc=MEMBRATURA%L0
      XLloc=XLloc/MM
      ENDIF


C      WRITE(*,*)'CORROSION ALLOWANCE/CLADDING THICKNESS(mm)?'
      C3=MEMBRATURA%CS
	IF(C3.EQ.0.)C3=MEMBRATURA%OS
      C3=C3/MM

C      WRITE(*,*)'JOINT EFFICIENCY'
      E3=MEMBRATURA%ES

      select case (I)

       case (1)
       R=MEMBRATURA%L0/MM+C3
       CALL HEM(T1bas)
       case (2)
       CALL TOR(RK,XLloc,T1bas)
	 CROWN=XLloc
       case (3)
       CALL ELL(T1bas)

      end select
	INDFON=I
	IND=I
      RETURN
      END
C***************************************************************
      SUBROUTINE FONPRI(MEMBRATURA,Config,FILE)
	USE mTYPINV
!DEC$ ATTRIBUTES DLLEXPORT::FONPRI
	TYPE(Involucro)::MEMBRATURA
	TYPE(asConfig)::Config
	TYPE(Str50)::FILE
      select case (INDFON)
       case (1)
       CALL HEMPRI(MEMBRATURA,Config,FILE)

       case (2)
       CALL TORPRI(MEMBRATURA,Config,FILE)

       case (3)
       CALL ELLPRI(MEMBRATURA,Config,FILE)

      end select
	RETURN
	END
C***************************************************************
      SUBROUTINE ELL(T1bas)
	USE mTYPINV
      DOUBLE PRECISION ellA,ellA1,ellA2,ellA3,ellB1,ellB2,
     X	ellB3,ellC1,ellC2,ellCC3
C
C     Rev.4A - 21/01/98 - Aggiunta conversione SI
C
      TEST=P3/(S3*E3)
      IF(TEST.LE.0.080)THEN
       X=0.170
       Y=LOG(P3/(S3*E3))
       Y2=Y*Y
       ellA1=-1.2617702
       ellA2=-4.5524592
       ellA3=28.933179
       ellB1=0.66298796
       ellB2=-2.2470836
       ellB3=15.682985
       ellC1=0.26878909D-04
       ellC2=-0.42262179
       ellCC3=1.8878333
       ellA=ellA1+ellA2*X+ellA3*X*X+
     X	 (ellB1+ellB2*X+ellB3*X*X)*Y+
     X     (ellC1+ellC2*X+ellCC3*X*X)*Y2
       TL=EXP(ellA)
       T=TL*0.90*(DD3+2*C3) + C3
       T1=MM*T
      ELSE
       T=0.50*(DD3+2.0*C3)*(EXP(TEST)-1.0) + C3
       T1=MM*T
      ENDIF
	T1bas=(T-C3)*MM
	RETURN
	END
C*************************************************************
	SUBROUTINE ELLPRI(MEMBRATURA,Config,FILE)
	USE mTYPINV
	TYPE(Involucro)::MEMBRATURA
	TYPE(asConfig)::Config
	TYPE(Str50)::FILE

C      WRITE(*,*)'REQUIRED THICKNESS IS :',T1,' mm'
C      WRITE(*,*)'ADOPTED THICKNESS (mm)?'
      TD3=MEMBRATURA%Spess
      TD3=TD3/MM
	 OPEN(6,FILE=FILE%Str)
        WRITE(6,1000)MEMBRATURA%Mark
C   STAMPA ED. ASME APPLICABILE.........
C        WRITE(6,1099)
        PMPA=P3*MPAvar
	  TCENT=TMD3
        IF(UniMis.EQ.1)TCENT=(TMD3-32.0)/1.8
	  IF(UniMis.EQ.0)TMD3=1.8*TMD3+32.
        D1=DD3*MM
        CC=C3*MM
        TT=TD3*MM
        WRITE(6,1100)P3*PSIvar,PMPA,TMD3,TCENT,MAT,S3*PSIvar,S3*MPAvar,
     x                  DD3,D1,C3,CC,E3
        if(TEST.LE.0.080) then
         WRITE(6,1200)TEST,TL,
     x	   0.90*(DD3+2*C3),0.90*(DD3+2*C3)*MM,T,T1,TD3,TT
        else 
         WRITE(6,1300)T,T1,TD3,TT
        endif
	CLOSE(6)
C        WRITE(6,5000)
C      WRITE(*,*)'OPENING ON ELLIPSOIDAL HEAD?===> Y/N'
C      READ(*,1)ANSWER
C       XL=0.90*(DD3+2.0*C3)
C        DO WHILE ((ANSWER.EQ.'Y'.OR.ANSWER.EQ.'y'))
C         CALL OPSH(TFE,I,XL,C3,TD3,TMD3,S3,P3,MAT3)
C          WRITE(*,*)'ANOTHER OPENING ON ELLIPSOIDAL HEAD? ===> Y/N'
C           READ(*,1)ANSWER
C       ENDDO

      RETURN
      INCLUDE '1000ELL.FOR'
      INCLUDE '1100ELL.FOR'

1200  FORMAT(5X,'    P < 0.08*S*E\par ',5X,
     X'  P/S  (  to Fig.AD-204.1)      = ',F8.5,'\par '/,5X,
     X'  t/L  (from Fig.AD-204.1)      = ',F8.5,'\par '/,5X,
     X'  L = 0.9*(D+2*C)             L = ',F10.4,' inch',
     X'  (',F10.3,' mm)\par '/5X,
     X'  T = (t/L)*L + C               = ',F10.3,
     x' inch  (',F10.3,' mm)\par '/5X
     X' Adopted thickness            t = ',F10.3,' inch  (',F10.3,
     x' mm)\par ')
1300  FORMAT(5X,'    P > 0.08*S*E','\par ',5X,
     X'  T = R*e**(0.5*P/S*E)-R + C    = ',F10.3,' inch',
     X'  (',F10.3' mm)\par ',/,5X,
     X' Adopted thickness            t = ',F10.3,' inch  (',
     xF10.3,' mm)\par ')
      END
C*****************************************************************************
      SUBROUTINE HEM(T1bas)
C
C     CALCOLA I FONDI SFERICI
C     ---------------------------------------------------------------------
C     Revisionata il 13-09-94 (calcolo del raggio interno della sfera
C     DD3XL) su segnalazione d'errore di Re Calegari.
C     ---------------------------------------------------------------------
C
	USE mTYPINV

C       Rev.4A - 21/01/97 - Aggiunta conversione dati SI
C
      TEST=P3/(S3*E3)
c      R=(DD3+2.0*C3)*0.50
c      RR=R*MM
      IF(TEST.LE.0.40) THEN
       T=0.5*P3*R/(S3*E3-0.25*P3)+C3
       T1=MM*T
      ELSE
       T=EXP(TEST*0.50)*R-R+C3
       T1=MM*T
      ENDIF
	T1bas=(T-C3)*MM
	RETURN
	END
C*************************************************************
	SUBROUTINE HEMPRI(MEMBRATURA,Config,FILE)
	USE mTYPINV
	TYPE(Involucro)::MEMBRATURA
	TYPE(asConfig)::Config
	TYPE(Str50)::FILE

C      WRITE(*,*)'REQUIRED THICKNESS IS :',T1,' mm'
C      WRITE(*,*)'ADOPTED THICKNESS (mm)?'
      TD3=MEMBRATURA%Spess
      TD3=TD3/MM
	 OPEN(6,FILE=FILE%Str)
       WRITE(6,1000)MEMBRATURA%Mark
C   STAMPA ED. ASME APPLICABILE.........
C       WRITE(6,1099)
       PMPA=P3*MPAvar
	  TCENT=TMD3
        IF(UniMis.EQ.1)TCENT=(TMD3-32.0)/1.8
	  IF(UniMis.EQ.0)TMD3=1.8*TMD3+32.
       D1=DD3*MM
       CC=C3*MM
       TT=TD3*MM
	 RR=R*MM 
       WRITE(6,1100)P3*PSIvar,PMPA,TMD3,TCENT,MAT,S3*PSIvar,S3*MPAvar,
     x	 DD3,D1,R,RR,C3,CC,E3
       if(TEST.LE.0.40) then
        WRITE(6,1200)T,T1,TD3,TT
       else 
        WRITE(6,1300)T,T1,TD3,TT
       endif
	CLOSE(6)
C       WRITE(6,5000)

C      WRITE(*,*)'OPENING ON SPHERICAL HEAD ===> Y/N'
C      READ(*,1)Y

C      DO WHILE ((Y.EQ.'Y'.OR.Y.EQ."y"))
C       DD3XL=(DD3/2.0)                                    ! 13-09-94
C        CALL OPSH(TFH,I,DD3XL,C3,TD3,TMD3,S3,P3,MAT3)     ! 13-09-94
C        WRITE(*,*)'ANOTHER OPENING ON SPHERICAL HEAD? ===> Y/N'
C         READ(*,1)Y
C      ENDDO

      RETURN
      INCLUDE '1000HEM.FOR'
      INCLUDE '1100HEM.FOR'
1200  FORMAT(5X,'    P < 0.40*S*E\par ',5X,
     X'  T = 0.5*P*R/(S*E-0.25*P) +C   = ',F10.3,' inch',
     X'  (',F10.2' mm)\par ',/,5X,
     X' Adopted thickness            t = ',F10.3,
     x' inch  (',F10.2' mm)\par ')
1300  FORMAT(5X,'    P > 0.40*S*E\par ',5X,
     X'  T = R*e**(0.5*P/S*E)-R +C     = ',F10.3,' inch',
     X'  (',F10.2' mm)\par '/5X,
     X' Adopted thickness            t = ',F10.3,
     x' inch  (',F10.2' mm)\par ')
      END
C*******************************************************************
      SUBROUTINE TOR(RK,XLloc,T1bas)
	USE mTYPINV
      DOUBLE PRECISION torA,torA1,torA2,torA3,torB1,torB2,torB3,
     x	torC1,torC2,torCC3
C
C
      TEST=P3/(S3*E3)
      IF(TEST.LE.0.080)THEN
       X=RK/(DD3+2.0*C3)
       Y=LOG(P3/(S3*E3))
       torA1=-1.2617702
       torA2=-4.5524592
       torA3=28.933179
       torB1=0.66298796
       torB2=-2.2470836
       torB3=15.682985
       torC1=0.26878909E-04
       torC2=-0.42262179
       torCC3=1.8878333
       torA=torA1+torA2*X+torA3*X*X+
     x	 (torB1+torB2*X+torB3*X*X)*Y+
     x     (torC1+torC2*X+torCC3*X*X)*Y*Y
       TL=EXP(torA)
       T=TL*XLloc + C3
       T1=MM*TFT
      ELSE
       T=0.50*(DD3+2.0*C3)*(EXP(TEST)-1.0) + C3
       T1=MM*TFT
      ENDIF
	T1bas=(T-C3)*MM
	RETURN
	END
C*************************************************************
	SUBROUTINE TORPRI(MEMBRATURA,Config,FILE)
	USE mTYPINV
	TYPE(Involucro)::MEMBRATURA
	TYPE(asConfig)::Config
	TYPE(Str50)::FILE

c      WRITE(*,*)'REQUIRED THICKNESS IS :',T1,' mm'
C      WRITE(*,*)'ADOPTED THICKNESS (mm)?'
      TD3=MEMBRATURA%Spess
      TD3=TD3/MM
	 OPEN(6,FILE=FILE%Str)
       WRITE(6,1000)MEMBRATURA%Mark
C     STAMPA ED. ASME APPLICABILE.........
C       WRITE(6,1099)
       PMPA=P3*MPAvar
	  TCENT=TMD3
        IF(UniMis.EQ.1)TCENT=(TMD3-32.0)/1.8
	  IF(UniMis.EQ.0)TMD3=1.8*TMD3+32.
       D1=DD3*MM
       CC=C3*MM
       TT=TD3*MM 
       RK=MEMBRATURA%R0/MM
       WRITE(6,1100)P3*PSIvar,PMPA,TMD3,TCENT,MAT,S3*PSIvar,S3*MPAvar,
     X            DD3,D1,RK,RK*MM,CROWN,CROWN*MM,C3,CC,E3
       if(TEST.LE.0.080) then
        WRITE(6,1200)A,TL,T,T1,TD3,TT
       else
        WRITE(6,1300)T,T1,TD3,TT
       endif
	CLOSE(6)
C       WRITE(6,5000)

C      WRITE(*,*)'OPENING ON TORISPHERICAL HEAD ===> Y/N'
C      READ(*,1)YN
C      DO WHILE ((YN.EQ.'Y'.OR.YN.EQ."y"))
C         CALL OPSH(TFT,I,XL,C3,TD3,TMD3,S3,P3,MAT3)
C          WRITE(*,*)'ANOTHER OPENING ON TORISPHER.HEAD ? ===> Y/N'
C           READ(*,1)YN
C            CALL CLS
C      ENDDO

      RETURN
      INCLUDE '1000TOR.FOR'
      INCLUDE '1100TOR.FOR'
1200  FORMAT(5X,'    P < 0.08*S*E\par ',5X,
     X'  A                             = ',F10.6, ' (from Art.4-4 ',
     X'para.4-431)\par '/5X,
     X'  t/L = exp(A)                  = ',F10.5,
     X'\par '/,5X,
     X'  T = (t/L)*L + C               = ',F10.3,' inch  (',
     XF10.2,' mm)\par ',
     X /,5X,
     X' Adopted thickness            t = ',F10.3,' inch  (',
     XF10.2,' mm)\par ')
1300  FORMAT(5X,'    P > 0.08*S*E\par ',5X,
     X'  T = R*(exp(P/S*E)-1) + C      = ',F10.3,' inch',
     X'  (',F10.2,' mm)\par '/5X,
     X' Adopted thickness            t = ',F10.3,' inch  (',
     XF10.2,' mm)\par ')
      END
