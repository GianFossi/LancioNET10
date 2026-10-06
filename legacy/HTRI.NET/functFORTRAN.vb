Option Explicit On
Option Strict On
Imports System.math
Module functFORTRAN
    Function VISCO(ByVal X As Single, ByVal Y() As Single, ByVal Y1() As Single) As Single
        '        INCLUDE() 'PRINCIP.FI'
        Dim TT1, TT2, TT3, TT As Single
        Dim A, B, C As Single
        If (actAltern.Prinop > 0) Then
            VISCO = CSng(RETLI(X, Y, 16))
            Return VISCO
        End If
        If (actAltern.Prinop < 0) Then
            actAltern.Prinop *= -1
        End If
321:    TT1 = Y(2) + 460
        TT2 = Y(4) + 460
        TT3 = Y1(2) + 460
        TT = X + 460
        If ((TT1 - TT2) = 0 Or Y(1) = 0 Or Y(3) = 0) Then Return 0
        If (Y1(1) = 0) Then
            C = 0
        Else
            C = CSng((Log(Y1(1) / Y(1)) - Log(Y(3) / Y(1)) * TT2 * (TT1 - TT3) / _
               TT3 / (TT1 - TT2)) / ((TT1 ^ 2 - TT3 ^ 2) / (TT1 ^ 2 * TT3 ^ 2) - _
               (TT1 + TT2) * (TT1 - TT3) / TT1 ^ 2 / TT2 / TT3))
        End If
        B = CSng(Log(Y(3) / Y(1)) * TT1 * TT2 / (TT1 - TT2) - C * (TT1 + TT2))
        A = CSng(Log(Y(1)) - B / TT1 - C / TT1 ^ 2)
        VISCO = CSng(Exp(A + B / TT + C / TT ^ 2))
    End Function
    'C********************************************************************** HHT08360
    Function FVPPR(ByVal U As Single) As Single '!vapor Prandtl dell'acqua
        'COMMON /ADAT/ADAT(37),IFORM(11),IZ(4)
        'CHARACTER*2 IFORM
        'INTEGER*2 IZ
        ' REAL*8 ADAT
        'U  !Calore Specifico molare (?)
        FVPPR = CSng(Dati.ADAT(1) + Dati.ADAT(2) * U + Dati.ADAT(3) * _
                U ^ 2 + Dati.ADAT(4) * U ^ 3 + Dati.ADAT(5) * U ^ 4 + Dati.ADAT(6) * U ^ 5 + Dati.ADAT(7) * U ^ 6)
    End Function
    'C*********************************************************************
    Function FVISHO(ByVal T As Single) As Single '     !viscosità dell'acqua 
        '      COMMON /ADAT/ADAT(37),IFORM(11),IZ(4)
        '     CHARACTER*2 IFORM
        '	INTEGER*2 IZ
        '     REAL*8 ADAT
        '	REAL*4 T
        FVISHO = CSng(Dati.ADAT(8) + Dati.ADAT(9) * T + Dati.ADAT(10) _
      * T ^ 2 + Dati.ADAT(11) * T ^ 3 + Dati.ADAT(12) * T ^ 4 + Dati.ADAT(13) * T ^ 5 + Dati.ADAT(14) * T ^ 6)
    End Function
    'C***********************************************************************
    Function FCH2O(ByVal T As Single) As Single '     !calore specifico acqua
        '      COMMON /ADAT/ADAT(37),IFORM(11),IZ(4)
        '      CHARACTER*2 IFORM
        '	INTEGER*2 IZ
        '     REAL*8 ADAT
        '	real*4 T
        FCH2O = CSng(Dati.ADAT(15) + T * (Dati.ADAT(16) + T * (Dati.ADAT(17) + T * Dati.ADAT(18))))
    End Function
    'C************************************************************************
    Function FLTH2O(ByVal T As Single) As Single '   !calore latente vapore
        '      COMMON /ADAT/ADAT(37),IFORM(11),IZ(4)
        '     CHARACTER*2 IFORM
        '	INTEGER*2 IZ
        '     REAL*8 ADAT
        '	REAL*4 T
        FLTH2O = CSng(Dati.ADAT(19) + T * (Dati.ADAT(20) + T * (Dati.ADAT(21) + T * Dati.ADAT(22))))
    End Function
    'C***********************************************************************
    Function FSPGR(ByVal T As Single) As Single '  !Specific gravity
        '      COMMON /ADAT/ADAT(37),IFORM(11),IZ(4)
        '      CHARACTER*2 IFORM
        '	INTEGER*2 IZ
        '     REAL*8 ADAT
        '	REAL*4 T
        FSPGR = CSng(Dati.ADAT(23) + Dati.ADAT(24) * T + Dati.ADAT(25) * T ^ 2 + _
          Dati.ADAT(26) * T ^ 3 + Dati.ADAT(27) * T ^ 4)
    End Function
    'C**********************************************************************
    Function FVIST(ByVal T As Single) As Single '  !Viscosità del vapore
        '      COMMON /ADAT/ADAT(37),IFORM(11),IZ(4)
        '      CHARACTER*2 IFORM
        '	INTEGER*2 IZ
        '     REAL*8 ADAT
        '	REAL*4 T
        FVIST = CSng(Dati.ADAT(28) + Dati.ADAT(29) * T + Dati.ADAT(30) * T ^ 2 + Dati.ADAT(31) * T ^ 3 + Dati.ADAT(32) * T ^ 4)
    End Function
    'C***********************************************************************
    Function FCOHO(ByVal T As Single) As Single
        '      COMMON /ADAT/ADAT(37),IFORM(11),IZ(4)
        '     CHARACTER*2 IFORM
        '	INTEGER*2 IZ
        '     REAL*8 ADAT
        '	REAL*4 T
        FCOHO = CSng(Dati.ADAT(33) + Dati.ADAT(34) * T + Dati.ADAT(35) * T ^ 2 + Dati.ADAT(36) * T ^ 3 + Dati.ADAT(37) * T ^ 4)
    End Function
    'C***********************************************************************
    Function INTERP(ByVal X As Single, ByVal X1 As Single, ByVal X2 As Single, _
                    ByVal Y1 As Single, ByVal Y2 As Single) As Single
        If (X1 = X2) Then
            INTERP = 0
        Else
            INTERP = Y1 + (X - X1) / (X2 - X1) * (Y2 - Y1)
        End If
    End Function
    'C**********************************************************
    Function RETLI(ByVal X As Single, ByVal Y() As Single, ByVal I As Integer) As Single
        '        INCLUDE() 'CMN.FI'
        '       INCLUDE() 'CMN1.FI'
        '      INCLUDE() 'PRINCIP.FI'
        '     INCLUDE() 'CMN3.FI'
        Dim A, Bloc, T2, YY2, T1, YY1 As Single
        Dim II, IERR, J, NPUNTI As Integer
        Dim DOMANDA As String
        Dim NUMITE As String
        '        LOGICAL(APERTO)
        If (actAltern.Prinop > 0) Then GoTo 100
120:    If ((Y(4) - Y(2)) = 0) Then Return 0
        A = (Y(3) - Y(1)) / (Y(4) - Y(2))
        Bloc = Y(1) - A * Y(2)
        RETLI = A * X + Bloc
100:    '  Inquire(4, OPENED = APERTO)
        'IF(NRDIT/2.LT.10)WRITE(NUMITE,'(1H0,2I1)')NRDIT/2,IPRAM(5)
        'IF(NRDIT/2.GE.10)WRITE(NUMITE,'(I2,I1)')NRDIT/2,IPRAM(5)
        'NFIPP=ARCHW(1:LEN_TRIM(ARCHW))//'\'//NF1(1)//NF1(2)
        ' 1//NF1(3)//NF1(4)//NUMITE//'.RA2'
        '    If (.NOT.APERTO) Then
        '  OPEN(4,FILE=NFIPP,RECL=124,FORM='UNFORMATTED',
        ' 1     ACCESS='DIRECT')                                             APA00770
        '    End If
        '  READ(4,REC=1,ERR=190,IOSTAT=IERR)DAT3
        '    NPUNTI = Nrighe
        For II = 1 To NPUNTI
            'c	WRITE(DOMANDA,'(''II ='',I5,A1)')II,char(0)
            'c      YY = MessageBoxEx(NULL,DOMANDA,'ISA'C,MB_OK+
            'c     1	 MB_ICONSTOP,LANG_ITALIAN)
            'READ(4,REC=II,ERR=190,IOSTAT=IERR)DAT3
            'IF(VALL(1).LT.X)GOTO 102
        Next
        II = NPUNTI
102:    If (II <= 1 And I > 3 And I <> 16) Then GoTo 120
        If (II = 1) Then
            II = 2
            'READ(4,REC=2,ERR=190,IOSTAT=IERR)DAT3
        End If
        Select Case (I)
            Case (1)
                J = 4 '! ENTALPIA TOTALE
            Case (2)
                J = 3 '! TITOLO PONDERALE FASE AERIFORME
            Case (3)
                J = 18 '! PESO MOLECOLARE GAS
            Case (4)
                J = 19 '!TITOLO PONDERALE ACQUA LIQUIDA
            Case (5)
                J = 20 '!ENTALPIA ACQUA LIQUIDA
            Case (6)
                J = 5 '!ENTALPIA GAS
            Case (7)
                J = 6 '!ENTALPIA FASE LIQUIDA IDROCARBURICA
            Case (16)
                J = 9 '!da qui in poi l'indice I è quello dell'array R(*)
            Case (20)
                J = 11
            Case (24)
                J = 15
            Case (28)
                J = 13
            Case (32)
                J = 14
            Case (36)
                J = 8
            Case (40)
                J = 10
            Case (44)
                J = 7
            Case (48)
                J = 12
            Case Else
                GoTo 120
        End Select
        '        T2 = VALL(1)
        '       YY2 = VALL(J)
        '	     IF(ISNAN(YY2))YY2=0.
        '          READ(4,REC=II-1)DAT3
        '      T1 = VALL(1)
        '     YY1 = VALL(J)
        '     IF(ISNAN(YY1))YY1=0.
        If ((T2 - T1) = 0) Then
            If (I > 3 And I <> 16) Then
                GoTo 120
            Else
                Return 0
            End If
        End If
        Dim RET As Single
        RET = YY1 + (X - T1) / (T2 - T1) * (YY2 - YY1)
        '!           IF (J=15) then RET*=1000
        If (J <> 19 And J <> 3) Then
            If (RET = 0 Or YY2 = 0 Or YY1 = 0) Then
                If (I = 16) Then
                    actAltern.Prinop *= -1
                    Return RET
                End If
                If (I > 3 And I <> 16) Then GoTo 120
            End If
        End If
        Return RET
        '  190 IF(IERR.EQ.36.AND.II.GT.1)THEN !tentativo leggere record inesistente
        '        II = II - 1
        '         READ(4,REC=II,ERR=195,IOSTAT=IERR)DAT3
        '        GoTo 102
        '        Else
        '        Return
        '       End If
        '  195 WRITE(DOMANDA,'(9HErrore n°,I5,24H durante la lettura del ,
        '    X10Hrecord n° ,I3,16H della libreria ,A40,A1)')IERR,II,
        '   xNFIPP(1:len_trim(NFIPP)),char(0)
        '   YY = MessageBoxEx(NULL,DOMANDA,'ISA'C,MB_OK+
        ' 1	 MB_ICONSTOP,LANG_ITALIAN)
        '   GoTo 120
    End Function
End Module
