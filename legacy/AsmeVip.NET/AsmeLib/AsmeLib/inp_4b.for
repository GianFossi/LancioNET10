      MODULE mTYPINV
      TYPE ASMERES
	   REAL A
	   REAL AA
	   REAL A1
	   REAL AA1
	   REAL A2
	   REAL A2PROT
	   REAL A3
	   REAL AA3
	   REAL A4
	   REAL SR
 	   REAL AEXT
	   REAL AAEXT
	   REAL AllN
	   CHARACTER*80 MatN
	   REAL SpCop  !Sp cop min
	   REAL SpCopA  !Sp cop adopted
	   REAL Diam !Diam coperchio/vessel
	   REAL CorrCop
	   REAL AllCop
	   INTEGER*2 VerificandoPI
	   CHARACTER*10 Pad 
	END TYPE
      TYPE NozzAd    
         INTEGER *2 TipAbutt
C	   '1 through groove,2 through fillet,3 abutting groove 4 abutting fillet,5 intermedio
         REAL Protusion
         INTEGER *2 UW16
C	                   '1(a)2(a-1)3(a-2)4(a-3)5(b)6(c)7(d)8(e)
C                          '9(f-1)10(f-2)11(f-3)12(f-4)13(g)14(h)
C                          '15(i)16(j)17(k)18(l)19(m)20(n)21(o)
C                          '22(p)23(q)24(r)25(s)26(t)27(u)
         REAL Gola41 
C	        'outward nozzle   min code
         REAL Gola42 
C	        'pad              min code
         REAL Gola43 
C	        'inward nozzle    min code
         REAL Leg41
         REAL Leg42
         REAL Leg43
         REAL Leg44 
         REAL W  
         REAL W11
         REAL W22
         REAL W33
         REAL WCompV 
         REAL Fillets
         REAL GrooTen
         REAL GrooShe
         REAL NozzShe
         REAL Str(9)
         INTEGER*2 i(9)
         REAL Paths( 3)
         REAL Wcomp( 3)
         CHARACTER *1 Pad( 16)
      END TYPE
!!DEC$ ATTRIBUTES
      TYPE NOZZLE
         INTEGER*2 indice
         INTEGER*2 InvolucroSU
         INTEGER*2 RecInd 
         CHARACTER*30 Mark
         CHARACTER*5 Tipo
         CHARACTER*80 MATE
         INTEGER*2 Rati
         REAL DiaN
         REAL DiOn
         REAL DiIn
         REAL Spess
         REAL EffN
         REAL ONn
         REAL CorrA
         REAL AllN
         REAL DCL
         REAL DTL
         REAL beta
         CHARACTER*1 Xacc
         REAL MUN
         REAL LX
         REAL HX
         REAL LSDisp
         REAL Padd
         REAL PadT
         INTEGER*2 SWR
         REAL MNT
         REAL MAWP(4)
         INTEGER*2 Inizio
         INTEGER*2 Fine
         REAL Alfa
         REAL LXdisp
         REAL AllPad
         INTEGER*2 IndiceF
         INTEGER*2 RecIndF
         INTEGER*2 IndexF
	   INTEGER*2 Risult
	   REAL      TransitionAngle
	   REAL      r2
         INTEGER*2 IndiceP
         INTEGER*2 RecIndP
         REAL      Anomal
	   REAL      ShThkNozArea
         REAL DiamExt
         REAL Altezza 
         REAL Spessore 
         INTEGER*2 IndObject
         INTEGER*2 IndiceB
         INTEGER*2 RecIndB
         REAL R1
	   REAL Tdes
	   REAL Pdes
	   CHARACTER*15 MATECop
         REAL alfaShell
         REAL alfaNoz
         REAL alfaPad
         REAL dtAD550f
         INTEGER*2 FlanNonStd 
         REAL AllNPI  
         REAL AllPadPI
	   INTEGER*2 BNoRinf
	   REAL FactVicini
         CHARACTER*97 Pad
      END TYPE
	TYPE Str50
	   CHARACTER*50 Str
	END TYPE
      Type asConfig
         INTEGER*2 LatoProgetto
         INTEGER*2 TipCalc
         INTEGER*2 Verbose 
         INTEGER*2 Ninvolucri
         INTEGER*2 DC    
         INTEGER*2 US  
         CHARACTER *13 DNjob
         CHARACTER*25 lkStr
         INTEGER*2 ms
         INTEGER*2 mv
         REAL dogg
         REAL di 
         REAL dns 
         REAL ES
         REAL TNS
         REAL p0x 
         REAL tdx 
         INTEGER*2 Vacuum
         INTEGER*2 Intest
         REAL tdxMDMT(2)
         REAL pdxMDMT(2)
         REAL pxExt
         REAL txExt
         REAL DensFluido
         INTEGER*2 NMWDT
         INTEGER*2 Versione
         CHARACTER*12 Item
         INTEGER*2 CalcMAWP
         INTEGER*2 NumeroLati
         REAL pxTest 
         REAL Corr
         INTEGER*2 CalcPI
         INTEGER*2 DiverseTemp
         INTEGER*2 SpecialRinf
         INTEGER*2 HTTestVert  !0 orizzontale 1 verticale
         INTEGER*2 MetodoPI    !0 UG-99(b) 1 UG-99(c)
         INTEGER*2 SistCoorCop !0 polare 1 cartesiano
         REAL*4    Efficienza  
         INTEGER*2 VerifPI     !0 non si verifica; 1 si verifica
         INTEGER*2 VerificandoPI 
         CHARACTER*4 Pad
      END TYPE
      TYPE Involucro
          INTEGER*2 indice(8)
          INTEGER*2 Tipo   
C		 '0 cilindro 1 fondo 2 cono 3 conoide 4 belt 5 flangione
          CHARACTER * 30 Mark 
          CHARACTER * 80 MATE  
          REAL Spess        
          REAL ES           
          REAL OS           
          REAL CS
		REAL SU      
          REAL S0   
          REAL ST   
          INTEGER*2 Inizio 
          INTEGER*2 Fine 
          INTEGER*2 ms    
C		  'shell product  |tipo di fondo  (HT)
          INTEGER*2 xs    
          REAL di      
          REAL dns    
          REAL H0     
          REAL L0     
          REAL R0     
          CHARACTER*3 Suffix 
          INTEGER*2  RecInd(8)
          REAL MAWP(4) 
          CHARACTER*10 MWDTrule 
          CHARACTER*1 MWDTclause 
          REAL MWDTtemp 
          INTEGER*2 Escluso 
          INTEGER*2 jmemb1 
          INTEGER*2 jmemb2  
          REAL HydrDepth
          INTEGER*2 IndObject
          INTEGER*2 AccoppK 
          INTEGER*2 AccoppJ
	    REAL      DensFluido
		REAL	  DesTemp
		REAL	  HydrDepth2
		INTEGER*2 IndAccopp(5)
		REAL	  PressInt
		REAL	  PressExt
		REAL	  TubeMinT
		REAL	  TubeAdopt
		REAL	  MAWP2(4)
		INTEGER*2 SottoTipo
		REAL*4    Dati1
		REAL*4    Dati2
		REAL*4    Dati3
		INTEGER*2 Norma
		CHARACTER*50 File
		INTEGER*2 IndAccopp2(5)
		REAL*4    UW20St
		REAL*4    UW20Sa
          REAL*4    Dati(4)    !tubi: tens.ax.prim.pr.int.
          REAL*4    MillUndTol
          REAL*4    Dati6    !for future use
          REAL*4    Dati7    !for future use
          REAL*4    Shydr    !tensione ammissibile in HT
	    INTEGER*2 EUTestGroup
      END TYPE
cDEC$ FREEFORM
CHARACTER*71,PARAMETER,PUBLIC::GreekDeltaMaiusc = &
'{{\field{\*\fldinst SYMBOL  68 \\f "Symbol" \\s 10}{\fldrslt\f3\fs20}}}'
CHARACTER*71,PARAMETER,PUBLIC::GreekAlpha = &
'{{\field{\*\fldinst SYMBOL  97 \\f "Symbol" \\s 10}{\fldrslt\f3\fs20}}}'
CHARACTER*71,PARAMETER,PUBLIC::GreekTheta = &
'{{\field{\*\fldinst SYMBOL 113 \\f "Symbol" \\s 10}{\fldrslt\f3\fs20}}}'
CHARACTER*71,PARAMETER,PUBLIC::MinoreUguale = &
'{{\field{\*\fldinst SYMBOL 163 \\f "Symbol" \\s 10}{\fldrslt\f3\fs20}}}'
CHARACTER*71,PARAMETER,PUBLIC::MaggioreUguale = &
'{{\field{\*\fldinst SYMBOL 179 \\f "Symbol" \\s 10}{\fldrslt\f3\fs20}}}'
CHARACTER*71,PARAMETER,PUBLIC::RadQ = &
'{{\field{\*\fldinst SYMBOL 214 \\f "Symbol" \\s 10}{\fldrslt\f3\fs20}}}'
CHARACTER*2,PARAMETER,PUBLIC::crlf=Char(13)//CHAR(10)
CHARACTER*25,PUBLIC,TARGET::  tmtrST='t-t{\sub r}-c            '
CHARACTER*25,PUBLIC,TARGET::  tmtrFR='(t-t{\sub r}-c)/F{\sub R}'
REAL,PARAMETER,PUBLIC::MPA=.00689476
REAL,PARAMETER,PUBLIC::MM=25.4
REAL,PARAMETER,PUBLIC::GreekPI=3.14159265359
INTEGER,PARAMETER,PUBLIC::MAXCount=10000
!DEC$ NOFREEFORM
      REAL*4 RagG,RagP,F5201,DTEST,PSIvar,MPAvar
	INTEGER*4 Regola,SetIn,VerificandoPI,UniMis
      COMMON/WORKG/ITEM,TEST,T,T1
      COMMON/WORKA/DD,C,TD,TMD,S,P,E,MAT,R,D0,D0E,DDsav,TDsav,TSsav,
     X             AllNOn,MATnOn,SpCop,chkAD550f,AlfR,AlfS,delt,
     X             Regola,SetIn,VerificandoPI,UniMis,
     X             PSIvar,MPAvar 
      COMMON/WORKB/DD1,DD11,C1,TD1,TMD1,S1,P1,E1,TL,ALFA,
     X	RagG,RagP,F5201,DTEST,MAT1
      COMMON/WORKC/DD2,C2,TD2,TMD2,S2,P2,E2,MATsave
	COMMON/WORKD/TSTT,IND,DD3XL,C3,TD3,TMD3,S3,P3,DD3,E3
      COMMON/WORKE/TCI,TCO,TSFE,TFH,TFT,TFE,INDFON,CROWN
      CHARACTER*80 MAT,MAT1,ITEM,MATnOn,MATsave
	REAL TEST,chkAD550f,AlfR,AlfS,delt
      COMMON/TOTAL/AT,A,A1,DODO,TKN,TKN1,TX,LL,XL,FR,FRp,L1,L2,TPL,
     X             TPLeff,LL1,LL2,ZL3,XL3,L3,A2,A4,A3,ATT,AA,DOE,XLL,
     X             PL,PN,SN,SNP,DE,L,L4,L5,L6,TMN,AA1,AA3,PPL,POS,
     X             DL1,DL2,DL3,DL4,FITL1,FITL2,FITL6,DTT(2),
     X             XLdisp,CORRN,CorrNoz(2),AEXT,AAEXT,SREXT, 
     X             A1r1,LXdisp,L3final,XAD5402,RRM
      REAL L1,L2,L3,LL1,LL2,LL,L4,L5,L6,LXdisp,L3final
	REAL AT,A,A1,DODO,TKN,TKN1,TX,XL,FR,FRp,A1r1,RRM
	REAL SN,SNP,TPL,TPLeff,DE,PL
C     Nuovi COMMON BLOCKS per la Routine NOZZLE
C     (Calcolo Rinforzo sul Bocchello)
C     by CD  -  26/06/98
C     - IPROT : se YPROT=y allora =1, 0 altrimenti
C     - LPROT : se YPROT=y = Dato di Inout, 0 altrimenti
C     - L3PROT: se YPROT=y = Dato di Input, 0 altrimenti
C                                    26/06/98, by CD
      COMMON/NOZZLEOut/IAD540,ABC1,ABC2,ABC3,TETA,THETA,FILLET,R1,
     x     ShThNzAr,MATH,XLT,R2,EN,MATN,TS,ITANG,YTANG
      CHARACTER*80 POS,MATN 
	CHARACTER*1 YTANG
      COMMON/PROT/LPROT,IPROT,IAD540PROT,L3PROT,A2PROT,X1(2),X1N(2)
      REAL LPROT,L3PROT,R1,R2,ABC1,ABC2,ABC3,TETA,THETA
C
C     Nuovo Include File per le variabili di Ouput per i calcolo 
C     delle aree disponibili sullo SHELL/HEAD
C     by CD  -  26/06/98
      COMMON /SHELLOut/FXL,IXL
	REAL FXL
	INTEGER IXL
C
C     Nuovo Include File per le variabili di Ouput relative al calcolo
C     delle aree disponibili totali e relative al pad di rinforzo e salda_
C     tura
C     by CD  -  01/07/98
C     NOTA.
C     Variabile YPROT : se settata = Y indica la presenza di una protrusione
C                       interna
C         "     CHECK : se settata = OK l' apertura e' verificata
C         "     YPAD  : se settata = Y indica la presenza di un pad

      COMMON /OpCheckOut/XL6,CHECK,YPAD
      CHARACTER*1 YPAD,YNZL,YPROT,YWELD
      CHARACTER*2 CHECK
	END MODULE
C*************************************************************
      SUBROUTINE INP(MEMBRATURA,Config,p0,tdtd)
	USE mTYPINV
	USE DFWIN
	IMPLICIT NONE
	TYPE(Involucro)::MEMBRATURA
	TYPE(asConfig)::Config
	REAL*4 p0,tdtd
	INTEGER*2 I
	CHARACTER*240 DOMANDA
	INTEGER*4 xMESS
	REAL*4 D1,DGran,DPicc,Aloc,H1
C
C     Modificato Messaggio Dati di Input
C     x corrosion/cladding
C     by  CD - 02/07/98

C-------------------------------------------------------------------------------
C  '0 cilindro 1 fondo 2 cono 3 conoide 4 belt 5 flangione


C      CALL CLS
	VerificandoPI=Config%VerificandoPI
	UniMis=Config%US
	IF(UniMis.EQ.0)THEN
	PSIvar=1/MPA
	MPAvar=1.
	ELSEIF(UniMis.EQ.1)THEN
	PSIvar=1
	MPAvar=MPA
	ELSE
	WRITE(DOMANDA,'('' Sistema di misura non previsto'',A1)')
	1char(0)
      xMESS = MessageBoxEx(NULL,DOMANDA,'ISA'C,MB_OK+
     1	                                 +MB_ICONINFORMATION+
     2                                     +MB_SETFOREGROUND,
     3                     LANG_ITALIAN)
	PSIvar=1.
	MPAvar=1.
	ENDIF
	SELECT CASE(MEMBRATURA%Tipo)
	CASE(0)
	   I=1
	CASE(1)
	   I=4 
	CASE(2)
	   I=2
	CASE(5)
	   I=5 
	END SELECT
      Select Case (I)

      case (1)
C------------------------------------------------------------------------------
C     SHELL CILINDRICI

c       WRITE(*,*)' DESIGN PRESSURE                  (Psi)?'
       P=p0
C       WRITE(*,*)' DESIGN TEMPERATURE                (øC)?'
C       READ(*,*)TMD
C       TMD=TMD*1.8+32.0
	TMD=tdtd
C       WRITE(*,*)'CYLINDRICAL SHELL MATERIAL?'
      MAT=MEMBRATURA%MATE
	MATsave=MAT
C       WRITE(*,*)'ALL. STRESS AT DESIGN TEMPERATURE (Psi)?'
      IF(VerificandoPI==0)THEN
	S=MEMBRATURA%ST
	ELSE
	S=MEMBRATURA%Shydr
	ENDIF
c	WRITE(DOMANDA,'(F12.3,I3,A21)')
c	1S,Membratura%SottoTipo,Membratura%PadUlt
c     xMESS = MessageBoxEx(NULL,DOMANDA,'ISA'C,MB_YESNO+
c     1	                                 +MB_ICONQUESTION+
c     2                                     +MB_SETFOREGROUND,
c     3                     LANG_ITALIAN)
C       WRITE(*,*)'INSIDE DIAMETER                   (mm)?'
      D1=MEMBRATURA%di
	IF(MEMBRATURA%ms==2)D1=MEMBRATURA%dns
      DD=D1/MM
C       WRITE(*,*)'CORROSION ALLOWANCE/CLADDING THICKNESS(mm)?'
      C=MEMBRATURA%CS
	IF(C.EQ.0.)C=MEMBRATURA%OS
       C=C/MM
C       WRITE(*,*)'JOINT EFFICIENCY'
      E=MEMBRATURA%ES
      case (2)
C------------------------------------------------------------------------------
C     SHELL CONICI

C       WRITE(*,*)' DESIGN PRESSURE                  (Psi)?'
      P1=p0
C       WRITE(*,*)' DESIGN TEMPERATURE                (øC)?'
      TMD1=tdtd
C       TMD1=TMD1*1.8+32.0
C       WRITE(*,*)'CONICAL SHELL MATERIAL'
      MAT1=MEMBRATURA%MATE
	MATsave=MAT1
C       WRITE(*,*)'ALL. STRESS AT DESIGN TEMPERATURE (Psi)'
      IF(VerificandoPI==0)THEN
	S1=MEMBRATURA%ST
	ELSE
	S1=MEMBRATURA%Shydr
	ENDIF
C       WRITE(*,*)'INSIDE DIAMETER LARGE END         (mm)'
      DGran=MEMBRATURA%di
      DD1=DGran/MM
C       WRITE(*,*)'INSIDE DIAMETER SMALL END         (mm)'
      DPicc=MEMBRATURA%dns
      DD11=DPicc/MM
C       WRITE(*,*)'CORROSION ALLOWANCE/CLADDING THICKNESS(mm)?'
      C1=MEMBRATURA%CS
	IF(C1.EQ.0.)C1=MEMBRATURA%OS
      C1=C1/MM
C       WRITE(*,*)'JOINT EFFICIENCY'
      E1=MEMBRATURA%ES
	ALFA=MEMBRATURA%R0*GreekPi/180
	RagG=MEMBRATURA%H0
	RagP=MEMBRATURA%L0
      Aloc = (Dgran - Dpicc) / 2
      If (RagG.EQ.0.AND.RagP.EQ.0) Then
         H1 = Aloc / Tan(ALFA)
c         Altezza = Int(H1 + PiedG + PiedP + 0.49)
      Else
         H1 = (Aloc - (RagG + RagP) * (1 - Cos(Alfa))) / Tan(Alfa)
         H1 = H1 + (RagG + RagP) * Sin(Alfa) 
      End If
	TL=H1/MM
C       WRITE(*,*)' HEIGHT TL-TL CONE                 (mm)'
C       READ(*,*)TL
C       TL=TL/MM

C......CALCOLO DELL'ANGOLO ALFA DEL CONO IN RADIANTI

C       RX=(DD1-DD11)*0.50
C       AL=RX/TL
C       ALFA=ATAN(AL)
C......SE SUPERA I 30 GRADI BISOGNA RIPROGETTARE IL CONO

C       IF(ALFA.LE.GreekPi/6.) EXIT
C       WRITE(*,*)'HALF APEX ANGLES EXCEED 30 DEGREES-REDESIGN CONE'

C      ENDDO

      case (3)
C------------------------------------------------------------------------------
C     SHELL SFERICI

c       WRITE(*,*)' DESIGN PRESSURE                  (Psi)?'
c       READ(*,*)P2
c       WRITE(*,*)' DESIGN TEMPERATURE                (øC)?'
c       READ(*,*)TMD2
c       TMD2=TMD2*1.8+32.0
c       WRITE(*,*)'SPHERICAL SHELL MATERIAL'
c       READ(*,1)MAT2
c       WRITE(*,*)'ALL. STRESS AT DESIGN TEMPERATURE (Psi)?'
c       READ(*,*)S2
c       WRITE(*,*)'INSIDE DIAMETER                   (mm)?'
c       READ(*,*)D1
c       DD2=D1/MM
c       WRITE(*,*)'CORROSION ALLOWANCE/CLADDING THICKNESS(mm)?'
c       READ(*,*)C2
c       C2=C2/MM
c       WRITE(*,*)'JOINT EFFICIENCY?'
c       READ(*,*)E2


C------------------------------------------------------------------------------
C     Negli altri casi i dati di input vengono richiesti direttamente
C     dalle subroutines di calcolo.
C
      end select

      return
      END

