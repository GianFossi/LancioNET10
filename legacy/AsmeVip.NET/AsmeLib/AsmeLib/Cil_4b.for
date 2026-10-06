      SUBROUTINE CIL(MEMBRATURA,Config,p0,tdtd,T1bas)
	USE mTYPINV
!DEC$ ATTRIBUTES DLLEXPORT::CIL
	USE DFWIN
	IMPLICIT NONE
	REAL*4 p0,tdtd,T1bas
	INTEGER*4 I,xMESS
	CHARACTER*120 DOMANDA
	TYPE(Involucro)::MEMBRATURA
	TYPE(asConfig)::Config
      CALL INP(MEMBRATURA,Config,p0,tdtd)
      TEST=P/(S*E)
	IF(MEMBRATURA%ms==2)THEN
      R=DD/2
      IF(TEST.LE.0.40)THEN
       T=P*R/(S*E+0.50*P)+C
       T1=MM*T
c	 Config%lkStr='Regola 1'
      ELSE
       T=-EXP(-TEST)*R+R+C
       T1=MM*T
c	 Config%lkStr='Regola 2'
      ENDIF
	ELSE
      R=(DD+2*C)/2
      IF(TEST.LE.0.40)THEN
       T=P*R/(S*E-0.50*P)+C
       T1=MM*T
c	 Config%lkStr='Regola 1'
      ELSE
       T=EXP(TEST)*R-R+C
       T1=MM*T
c	 Config%lkStr='Regola 2'
      ENDIF
	ENDIF
	T1bas=(T-C)*MM
	RETURN
	END
c**************************************************************
      SUBROUTINE CILPRI(MEMBRATURA,Config,FILE)
	USE mTYPINV
!DEC$ ATTRIBUTES DLLEXPORT::CILPRI
	TYPE(Involucro)::MEMBRATURA
	TYPE(asConfig)::Config
	TYPE(Str50)::FILE
	REAL*4 MUT
      TD=MEMBRATURA%Spess
      PMPA=P*MPAvar
	TCENT=TMD
      IF(UniMis.EQ.1)TCENT=(TMD-32.0)/1.8
      TD=TD/MM
      D1=DD*MM
      CC=C*MM
      TT=TD*MM
      RR=R*MM
      OPEN(6,FILE=FILE%Str)
      WRITE(6,1000)MEMBRATURA%Mark(1:MIO_LEN_TRIM(MEMBRATURA%Mark))//
     X'                  '
      MUT=MEMBRATURA%MillUndTol
	IF(MEMBRATURA%ms==2)THEN
       WRITE(6,1101)MAT,S*PSIvar,S*MPAvar,DD,D1,R,RR,C,CC,E
	 WRITE(6,1102)MUT/MM,MUT
       IF(TEST.LE.0.40) then
        WRITE(6,1201)T,T1,T+MUT/MM,T1+MUT,TD,TT
       ELSE
        WRITE(6,1301)T,T1,T+MUT/MM,T1+MUT,TD,TT
       ENDIF
      ELSEIF(MEMBRATURA%ms==1)THEN
       WRITE(6,1100)MAT,S*PSIvar,S*MPAvar,DD,D1,R,RR,C,CC,E
       IF(TEST.LE.0.40) then
        WRITE(6,1200)T,T1,TD,TT
       ELSE
        WRITE(6,1300)T,T1,TD,TT
       ENDIF
      ELSE
       WRITE(6,1100)MAT,S*PSIvar,S*MPAvar,DD,D1,R,RR,C,CC,E
	 WRITE(6,1102)MUT/MM,MUT
       IF(TEST.LE.0.40) then
        WRITE(6,1202)T,T1
       ELSE
        WRITE(6,1302)T,T1
       ENDIF
	 WRITE(6,1303).01,.25
	 WRITE(6,1304)T+MUT/MM-.01,T1+MUT-.25,TD,TT
      ENDIF
c       WRITE(6,5000)
	 CLOSE(6)
      RETURN
cDEC$ FREEFORM
1000  FORMAT('\par      CYLINDRICAL SHELL CALCULATION ACCORDING TO ASME VIII Div.2 PARA. AD - 201\par \par ', &
          5X,' SHELL IDENTIFICATION          \tab : ',A30,'\par ')
!DEC$ NOFREEFORM
1100  FORMAT('\par ',
     X5X,
     X' MATERIAL                        \tab : ',A20,'\par ',5X,
     X' ALLOWABLE STRESS @ DESIGN T.   S\tab = ',F10.1,' psi  (',F10.2,
     X' MPa)\par \par ',/,5X,
     X' Internal diameter              D\tab = ',F10.3,' inch (',F10.2,
     X' mm)\par ',/,5X,
     X' Internal radius R = (D+2*C)/2   \tab = ',F10.3,' inch (',F10.2,
     X' mm)\par ',/,5X,
     X' Corrosion / Clad Thickness     C\tab = ',F10.4,' inch (',F10.3,
     X' mm)\par ',/,5X,
     X' Joint efficiency               E\tab =      ',F5.2,'\par ')
1101  FORMAT('\par ',
     X5X,
     X' MATERIAL                        \tab : ',A20,'\par ',5X,
     X' ALLOWABLE STRESS @ DESIGN T.   S\tab = ',F10.1,' psi  (',F10.2,
     X' MPa)\par \par ',/,5X,
     X' External diameter              D\tab = ',F10.3,' inch (',F10.2,
     X' mm)\par ',/,5X,
     X' External radius       R = D/2   \tab = ',F10.3,' inch (',F10.2,
     X' mm)\par ',/,5X,
     X' Corrosion / Clad Thickness     C\tab = ',F10.4,' inch (',F10.3,
     X' mm)\par ',/,5X,
     X' Joint efficiency               E\tab =      ',F5.2,'\par ')
1102  FORMAT(5X,
     X' Specified Mill Undertolerance  u\tab = ',F10.4,' inch (',F10.3,
     X' mm)\par ') 
cDEC$ FREEFORM
1200  FORMAT(5X,'    Note: P < 0.40*S*E\par ',5X, &
      ' t{\sub r} = P*R/(S*E-0.5*P)+C         t{\sub r}\tab = ',F10.3,' inch', &
      '  (',F10.3' mm)\par ',/,5X, &
      ' Adopted thickness              t\tab = ',F10.3, &
      ' inch  (',F10.3' mm)\par ')
1201  FORMAT(5X,'    Note: P < 0.40*S*E\par ',5X, &
      ' t{\sub r} = P*R/(S*E+0.5*P)+C         t{\sub r}\tab = ',F10.3,' inch', &
      '  (',F10.3' mm)\par ',/,5X, &
      ' Min. thickness to AF-105.2   t{\sub r}+u\tab = ',F10.3,' inch', &
      '  (',F10.3' mm)\par ',/,5X, &
      ' Adopted thickness              t\tab = ',F10.3, &
      ' inch  (',F10.3' mm)\par ')
1202  FORMAT(5X,'    Note: P < 0.40*S*E\par ',5X, &
      ' t{\sub r} = P*R/(S*E-0.5*P)+C         t{\sub r}\tab = ',F10.3,' inch', &
      '  (',F10.3' mm)\par ')
1203  FORMAT(5X, &
      ' Adopted thickness              t\tab = ',F10.3, &
      ' inch  (',F10.3' mm)\par ')
1300  FORMAT(5X,'    Note: P > 0.40*S*E\par ',5X, &
      ' T = R*exp(P/S*E)-R+C           T\tab = ',F10.3,' inch', &
      '  (',F10.3' mm)\par ',/,5X, &
      ' Adopted thickness              t\tab = ',F10.3, &
      ' inch  (',F10.3' mm)\par ')
1301  FORMAT(5X,'    Note: P > 0.40*S*E\par ',5X, &
      ' T =-R*exp(-P/S*E)+R+C          T\tab = ',F10.3,' inch', &
      '  (',F10.3' mm)\par ',/,5X, &
      ' Min. thickness to AF-105.2   t{\sub r}+u\tab = ',F10.3,' inch', &
      '  (',F10.3' mm)\par ',/,5X, &
      ' Adopted thickness              t\tab = ',F10.3, &
      ' inch  (',F10.3' mm)\par ')
1302  FORMAT(5X,'    Note: P < 0.40*S*E\par ',5X, &
      ' t{\sub r} = P*R/(S*E-0.5*P)+C         t{\sub r}\tab = ',F10.3,' inch', &
      '  (',F10.3' mm)\par ')
1303  FORMAT(5X, &
      ' Tolerated undert. to AF-105.1  u{\sub t}\tab = ',F10.3, &
      ' inch  (',F10.3' mm)\par ')
1304  FORMAT(5X, &
      ' Min. thk to AF-105.1:     t{\sub r}+u-u{\sub t}\tab = ',F10.3, &
      ' inch  (',F10.3' mm)\par ',/,5X, &
      ' Adopted thickness              t\tab = ',F10.3, &
      ' inch  (',F10.3' mm)\par ')
	END
