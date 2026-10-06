      SUBROUTINE CONO(MEMBRATURA,Config,p0,tdtd,T1bas)
	USE mTYPINV
!DEC$ ATTRIBUTES DLLEXPORT::CONO
	TYPE(Involucro)::MEMBRATURA
	TYPE(asConfig)::Config
      CALL INP(MEMBRATURA,Config,p0,tdtd)
C.....CALCOLO SPESSORE MINIMO CONO ZONA A DIAMETRO MAGGIORE
      TEST=P1/(S1*E1)
      R=(DD1+2.0*C1)*0.50/COS(ALFA)
      IF(TEST.LE.0.40)THEN
       T=P1*R/(S1*E1-0.50*P1)+C1
       T1=T*MM
      ELSE
       T=EXP(TEST)*R-R+C1
       T1=MM*T
	ENDIF
C.....CONTROLLO SPESSORE SECONDO FIG. AD-211.1
      IF(RagG.EQ.0)THEN
	   CALL TEST1(ISN)
         IF(ISN.GT.0) CALL TEST2(ISN,Q,RRLC,RRL)
      ENDIF
C        WRITE(*,*)'THICKNESS IS ADEQUATE WITH AD-201/203'
C        WRITE(*,*)'REQUIRED THICKNESS IS :',T1,' mm'
C        WRITE(*,*)'ADOPTED THICKNESS (mm)'
C       ELSE
C        CALL TEST2(ISN,ALFA,TEST,Q,RRLC,RRL,R)
C        WRITE(*,*)'THICKNESS MUST BE INCREASED WITH AD-201/203'
C        WRITE(*,*)'REQUIRED THICKNESS > :',T1,' mm'
C        WRITE(*,*)'ADOPTED THICKNESS (mm)'
C       ENDIF
c=========================================
c	includere calcolo su small end e calcolo giunzioni raggiate
c==========================================
	T1bas=(T-C1)*MM
	RETURN
	END
C***************************************************
      SUBROUTINE CONPRI(MEMBRATURA,Config,FILE)
	USE mTYPINV
!DEC$ ATTRIBUTES DLLEXPORT::CONPRI
	TYPE(Involucro)::MEMBRATURA
	TYPE(asConfig)::Config
	TYPE(Str50)::FILE
      TD1=MEMBRATURA%Spess
       TD1=TD1/25.40
	 OPEN(6,FILE=FILE%Str)
       WRITE(6,1000)
C   STAMPA ED. ASME APPLICABILE.........
C       WRITE(6,1099)
       
       CC=C1*MM
       TT=TD1*MM
       WRITE(6,1100)MAT1,S1*PSIvar,S1*MPAvar,DD1,DD1*MM,DD11,
     x DD11*MM,C1,CC,E1
	 WRITE(6,11018)ALFA*180/GreekPI,RagG/MM,RagG,
     x	RagP/MM,RagP,TL,TL*MM,R,R*MM
	IF(TEST.LE..4)THEN
       WRITE(6,1200)T,T1,TD1,TT
      ELSE
       WRITE(6,1300)T,T1,TD1,TT
	ENDIF
c      WRITE(6,5000)
c================================================
c	includere qui risultati calcolo giunzioni	
c=================================================
	CLOSE(6)
	RETURN

C      WRITE(*,*)'OPENING ON SHELL ===> Y/N'
C      READ(*,1)Y
C      DO WHILE ((Y.EQ.'Y'.OR.Y.EQ."y"))
C         CALL OP(T)
C          WRITE(*,*)'ANOTHER OPENING ON SHELL? ===> Y/N'
C           READ(*,1)Y
C            CALL CLS
C       ENDDO
C      RETURN
1000  FORMAT('\par      CONICAL SHELL CALCULATION ACCORDING TO',
     X' ASME VIII Div.2',
     X' PARA. AD - 203\par ')
C      INCLUDE'ASME_ED.fmt'
1100  FORMAT('\par ',
     X5X,
     X' MATERIAL                       : ',A20,'\par ',5X,
     X' ALLOWABLE STRESS @ DESIGN T. S = ',F10.1,' psi  (',F10.2,
     X' MPa)\par \par ',/,5X,
     X' Internal diameter large end Dg = ',F10.3,' inch (',F10.2,
     X' mm)\par ',/,5X,
     X' Internal diameter small end Dp = ',F10.3,' inch (',F10.2,
     X' mm)\par ',/,5X,
     X' Corrosion / Clad Thickness   C = ',F10.4,' inch (',F10.3,
     X' mm)\par ',/,5X,
     X' Joint efficiency             E =      ',F5.2,'\par ')
11018 FORMAT('\par ',
     X5X,
     X' Half-apex angle                : ',F10.2,'\par ',5X,
     X' Knuckle radius large end    Rg = ',F10.3,' inch (',F10.2,
     X' mm)\par ',/,5X,
     X' Knuckle radius small end    Rp = ',F10.3,' inch (',F10.2,
     X' mm)\par ',/,5X,
     X' TL-TL height                 H = ',F10.4,' inch (',F10.3,
     X' mm)\par '/5X,
     X' Radius  R = (D+2*C)/(2cos(a))  = ',F10.3,' inch (',F10.2,
     X' mm)\par ')
1200  FORMAT(5X,'    P < 0.40*S*E\par '/5X,
     X'  T = P*R/(S*E-0.5*P)+C         = ',F10.3,' inch',
     X'  (',F10.3' mm)\par '/5X,
     X' Adopted thickness            t = ',F10.3,
     x' inch  (',F10.3' mm)\par ')
1300  FORMAT(5X,'    P > 0.40*S*E\par '/5X,
     X'  T = R*e**(P/S*E)-R+C          = ',F10.3,' inch',
     X'  (',F10.3' mm)\par '/5X,
     X' Adopted thickness            t = ',F10.3,
     x' inch  (',F10.3' mm)\par ')
      RETURN
      END
