Imports System.math
Module modDiv2
    Private PSiVar As Single
    Private MPAvar As Single
    Private P, S, TMD, DD, E, P1, TMD1, S1, DD1, C1, ALFA, RagG, RagP As Single
    Private C, DD11, TL, T, T1, R, PMPA, TCENT, D1, CC, TT, RR, TD1 As Single
    Private Q, RRLC, RRL, TD3, DD3, C3, S3, E3, P3, TMD3, RK, CROWN, DD3XL As Single
    Private TFT, SNP, FR, FRP, TKN, TKN1, THETA, XLT, LL, LPROT, L3PROT, PL, TPL As Single
    Private L3final, L3, L4, L5, L6, LL1, LL2, ZL3, ABC1, ABC2, ABC3 As Single
    Private R1, R2, FILLET, EN, CORRN, PN, D0, TX, RRM, SREXT, TS As Single
    Private SpCop, DDsav, TDsav, TSsav, D0E, F5201, DTEST, XLL, TMN As Single
    Private MAT, MAT1, MATsave, MATN, POS, YPROT, YWELD, YNZL, YPAD, Check As String
    Private XLdisp, XTPL, chkAD550f, AlfS, AlfR, delt, XL3, TETA, XL1A, XL3A, XL4A, XL6 As Single
    Private MATnOn, YTANG As String
    Private TEST, A, AA, A1, AA1, A2, A2PROT, A3, AA3, A4, AT, ATT, AllNOn, AEXT, AAEXT As Single
    Private AXES, AXESMM, L1, L2, XL, FXL, A1r1, TPLeff, PPL, ShThNzAr, RMN, DE, XL1, XL4 As Single
    Private L, INDFON, Regola, IND, IPROT, IAD540, IAD540PROT, ITANG, UniMis, IXL As Integer
    Private sw As IO.StreamWriter
    Private SetIn As Boolean
    Private Const strSHELL As String = "SHELL"
    Private Const strCOVER As String = "COVER"
    Private Const GreekDeltaMaiusc As String = "{{\field{\*\fldinst SYMBOL  68 \\f ""Symbol"" \\s 10}{\fldrslt\f3\fs20}}}"
    Private Const GreekAlpha As String = "{{\field{\*\fldinst SYMBOL  97 \\f ""Symbol"" \\s 10}{\fldrslt\f3\fs20}}}"
    Private Const GreekTheta As String = "{{\field{\*\fldinst SYMBOL 113 \\f ""Symbol"" \\s 10}{\fldrslt\f3\fs20}}}"
    Private Const MinoreUguale As String = "{{\field{\*\fldinst SYMBOL 163 \\f ""Symbol"" \\s 10}{\fldrslt\f3\fs20}}}"
    Private Const MaggioreUguale As String = "{{\field{\*\fldinst SYMBOL 179 \\f ""Symbol"" \\s 10}{\fldrslt\f3\fs20}}}"
    Private Const RadQ As String = "{{\field{\*\fldinst SYMBOL 214 \\f ""Symbol"" \\s 10}{\fldrslt\f3\fs20}}}"
    Private Const tmtrST As String = "t-t{\sub r}-c"          '
    Private Const tmtrFR As String = "(t-t{\sub r}-c)/F{\sub R}"
    Public Sub INP(ByRef MEMBRATURA As clsInvolucroNew, ByRef Config As asConfig, _
                   ByRef p0 As Single, ByRef tdtd As Single)
        Dim i As Integer
        Dim D1, DGran, DPicc, Aloc, H1 As Single
        'C-------------------------------------------------------------------------------
        '0 cilindro 1 fondo 2 cono 3 conoide 4 belt 5 flangione
        If (Config.US = 0) Then
            PSiVar = 1 / mpa
            MPAvar = 1
        ElseIf (Config.US = 1) Then
            PSiVar = 1
            MPAvar = mpa
        Else
            '	WRITE(DOMANDA,'('' Sistema di misura non previsto'',A1)')'
            '1char(0)
            '  xMESS = MessageBoxEx(NULL,DOMANDA,'ISA'C,MB_OK+
            ' 1	                                 +MB_ICONINFORMATION+
            ' 2                                     +MB_SETFOREGROUND,
            ' 3                     LANG_ITALIAN)
            PSiVar = 1
            MPAvar = 1
        End If
        Select Case (MEMBRATURA.Tipo)
            Case (0)
                i = 1
            Case (1)
                i = 4
            Case (2)
                i = 2
            Case (5)
                i = 5
        End Select
        Select Case (i)

            Case (1)
                'C------------------------------------------------------------------------------
                'C     SHELL CILINDRICI

                'c       WRITE(*,*)' DESIGN PRESSURE                  (Psi)?'
                P = p0
                'C       WRITE(*,*)' DESIGN TEMPERATURE                (øC)?'
                'C       READ(*,*)TMD
                '                C(TMD = TMD * 1.8 + 32.0)
                TMD = tdtd
                'C       WRITE(*,*)'CYLINDRICAL SHELL MATERIAL?'
                MAT = MEMBRATURA.MATE
                MATsave = MAT
                'C       WRITE(*,*)'ALL. STRESS AT DESIGN TEMPERATURE (Psi)?'
                If (VerificandoPI = 0) Then
                    S = MEMBRATURA.St
                Else
                    S = MEMBRATURA.Shydr
                End If
                D1 = MEMBRATURA.di
                If (MEMBRATURA.ms = 2) Then D1 = MEMBRATURA.dns
                DD = D1 / inc
                'C       WRITE(*,*)'CORROSION ALLOWANCE/CLADDING THICKNESS(Inc)?'
                C = MEMBRATURA.cs
                If (C = 0) Then C = MEMBRATURA.OS
                C = C / inc
                'C       WRITE(*,*)'JOINT EFFICIENCY'
                E = MEMBRATURA.ES
            Case (2)
                'C------------------------------------------------------------------------------
                'C     SHELL CONICI
                'C       WRITE(*,*)' DESIGN PRESSURE                  (Psi)?'
                P1 = p0
                'C       WRITE(*,*)' DESIGN TEMPERATURE                (øC)?'
                TMD1 = tdtd
                '                C(TMD1 = TMD1 * 1.8 + 32.0)
                'C       WRITE(*,*)'CONICAL SHELL MATERIAL'
                MAT1 = MEMBRATURA.MATE
                MATsave = MAT1
                'C       WRITE(*,*)'ALL. STRESS AT DESIGN TEMPERATURE (Psi)'
                If (VerificandoPI = 0) Then
                    S1 = MEMBRATURA.St
                Else
                    S1 = MEMBRATURA.Shydr
                End If
                'C       WRITE(*,*)'INSIDE DIAMETER LARGE END         (Inc)'
                DGran = MEMBRATURA.di
                DD1 = DGran / inc
                'C       WRITE(*,*)'INSIDE DIAMETER SMALL END         (Inc)'
                DPicc = MEMBRATURA.dns
                DD11 = DPicc / inc
                'C       WRITE(*,*)'CORROSION ALLOWANCE/CLADDING THICKNESS(Inc)?'
                C1 = MEMBRATURA.cs
                If (C1 = 0) Then C1 = MEMBRATURA.OS
                C1 = C1 / inc
                'C       WRITE(*,*)'JOINT EFFICIENCY'
                E1 = MEMBRATURA.ES
                ALFA = MEMBRATURA.R0 * Math.PI / 180
                RagG = MEMBRATURA.H0
                RagP = MEMBRATURA.L0
                Aloc = (DGran - DPicc) / 2
                If (RagG = 0 And RagP = 0) Then
                    H1 = Aloc / Tan(ALFA)
                    '                   c(Altezza = Int(H1 + PiedG + PiedP + 0.49))
                Else
                    H1 = (Aloc - (RagG + RagP) * (1 - Cos(ALFA))) / Tan(ALFA)
                    H1 = H1 + (RagG + RagP) * Sin(ALFA)
                End If
                TL = H1 / inc
                'C       WRITE(*,*)' HEIGHT TL-TL CONE                 (Inc)'
                'C       READ(*,*)TL
                '                C(TL = TL / Inc)
                'C......CALCOLO DELL'ANGOLO ALFA DEL CONO IN RADIANTI
                '                C(RX = (DD1 - DD11) * 0.5)
                '                C(AL = RX / TL)
                '                C(ALFA = ATAN(AL))
                'C......SE SUPERA I 30 GRADI BISOGNA RIPROGETTARE IL CONO

                'C       IF(ALFA.LE.GreekPi/6.) EXIT
                'C       WRITE(*,*)'HALF APEX ANGLES EXCEED 30 DEGREES-REDESIGN CONE'

                '                C(ENDDO)

            Case (3)
                'C------------------------------------------------------------------------------
                'C     SHELL SFERICI

                'c       WRITE(*,*)' DESIGN PRESSURE                  (Psi)?'
                'c       READ(*,*)P2
                'c       WRITE(*,*)' DESIGN TEMPERATURE                (øC)?'
                'c       READ(*,*)TMD2
                '                c(TMD2 = TMD2 * 1.8 + 32.0)
                'c       WRITE(*,*)'SPHERICAL SHELL MATERIAL'
                'c       READ(*,1)MAT2
                'c       WRITE(*,*)'ALL. STRESS AT DESIGN TEMPERATURE (Psi)?'
                'c       READ(*,*)S2
                'c       WRITE(*,*)'INSIDE DIAMETER                   (Inc)?'
                'c       READ(*,*)D1
                '                c(DD2 = D1 / Inc)
                'c       WRITE(*,*)'CORROSION ALLOWANCE/CLADDING THICKNESS(Inc)?'
                'c       READ(*,*)C2
                '                c(C2 = C2 / Inc)
                'c       WRITE(*,*)'JOINT EFFICIENCY?'
                'c       READ(*,*)E2


                'C------------------------------------------------------------------------------
                'C     Negli altri casi i dati di input vengono richiesti direttamente
                'C     dalle subroutines di calcolo.
                '                C()
        End Select
    End Sub
    Private Function FormatStringa(ByRef id As Integer) As String
        Dim Outstr As String
        Dim Nome As String = "fmt" + GlobalRoutines.Str4Cifre(id)
        Outstr = rmHelpStrings.GetString(Nome)
        If Outstr Is Nothing Then Return (Nome)
        If Outstr.IndexOf("$"c) = 0 Then Return Outstr.Substring(1)
        Return Outstr
    End Function
    Public Sub CIL(ByRef MEMBRATURA As clsInvolucroNew, ByRef Config As asConfig, _
                      ByRef p0 As Single, ByRef tdtd As Single, ByRef T1bas As Single)
        Call INP(MEMBRATURA, Config, p0, tdtd)
        TEST = P / (S * E)
        If (MEMBRATURA.ms = 2) Then
            R = DD / 2
            If (TEST <= 0.4) Then
                T = P * R / (S * E + 0.5 * P) + C
                T1 = inc * T
                'c	 Config%lkStr='Regola 1'
            Else
                T = -Exp(-TEST) * R + R + C
                T1 = inc * T
                'c	 Config%lkStr='Regola 2'
            End If
        Else
            R = (DD + 2 * C) / 2
            If (TEST <= 0.4) Then
                T = P * R / (S * E - 0.5 * P) + C
                T1 = inc * T
                'c	 Config%lkStr='Regola 1'
            Else
                T = Exp(TEST) * R - R + C
                T1 = inc * T
                'c	 Config%lkStr='Regola 2'
            End If
        End If
        T1bas = (T - C) * inc
    End Sub
    Public Sub CILPRI(ByRef MEMBRATURA As clsInvolucroNew, ByRef Config As asConfig, ByRef FILE As String)
        td = MEMBRATURA.Spess
        PMPA = P * MPAvar
        TCENT = TMD
        If (Config.US = 1) Then TCENT = (TMD - 32.0) / 1.8
        td = td / inc
        D1 = DD * inc
        CC = C * inc
        TT = td * inc
        RR = R * inc
        sw = IO.File.CreateText(FILE)
        sw.WriteLine(FormatStringa(1000), MEMBRATURA.Mark)
        If (MEMBRATURA.ms = 2) Then
            sw.WriteLine(FormatStringa(1101), MAT, S * PSiVar, S * MPAvar, DD, D1, R, RR, C, CC, E)
            If (TEST <= 0.4) Then
                sw.WriteLine(FormatStringa(1201), T, T1, td, TT)
            Else
                sw.WriteLine(FormatStringa(1301), T, T1, td, TT)
            End If
        Else
            sw.WriteLine(FormatStringa(1100), MAT, S * PSiVar, S * MPAvar, DD, D1, R, RR, C, CC, E)
            If (TEST <= 0.4) Then
                sw.WriteLine(FormatStringa(1200), T, T1, td, TT)
            Else
                sw.WriteLine(FormatStringa(1300), T, T1, td, TT)
            End If
        End If
        sw.Close()
    End Sub
    Public Sub CONO(ByRef MEMBRATURA As clsInvolucroNew, ByRef Config As asConfig, _
                    ByRef p0 As Single, ByRef tdtd As Single, ByRef T1bas As Single)
        Call INP(MEMBRATURA, Config, p0, tdtd)
        'C.....CALCOLO SPESSORE MINIMO CONO ZONA A DIAMETRO MAGGIORE
        TEST = P1 / (S1 * E1)
        R = (DD1 + 2.0 * C1) * 0.5 / Cos(ALFA)
        If (TEST <= 0.4) Then
            T = P1 * R / (S1 * E1 - 0.5 * P1) + C1
            T1 = T * inc
        Else
            T = Exp(TEST) * R - R + C1
            T1 = inc * T
        End If
        'C.....CONTROLLO SPESSORE SECONDO FIG. AD-211.1
        If (RagG = 0) Then
            Dim ISN As Integer
            Call TEST1(ISN)
            If (ISN > 0) Then Call TEST2(ISN)
        End If
        'c=========================================
        'c	includere calcolo su small end e calcolo giunzioni raggiate
        'c==========================================
        T1bas = (T - C1) * inc
    End Sub
    Private Sub TEST1(ByRef ISN As Integer)
        Dim PS As Single
        'C     ROUTINE DI CALCOLO SECONDO ASME VIII D.2 AD-211
        'C     ALFA MINORE DI 30 GRADI
        'C     ISN=VARIABILE DI CONTROLLO SE E' SODDISFATTO IL GRAFICO
        'C     DI FIG. AD-211.1
        'C.....SETTA ISN IN MANIERA CHE LA VERIFICA NON E' SODDISFATTA
        ISN = 1
        'C.....RETTA 1
        If (ALFA < 15 And ALFA >= 11) Then
            PS = 0.00041666675 * ALFA - 0.00258333425
            'C......SE E' SODDISFATTO SETTA ISN=0
            If (TEST >= PS) Then ISN = 0
        End If
        'C.....RETTA 2
        If (ALFA < 17.5 And ALFA >= 15) Then
            PS = 0.000476132 * ALFA - 0.003475313
            'C......SE E' SODDISFATTO SETTA ISN=0
            If (TEST >= PS) Then ISN = 0
        End If
        'C.....RETTA 3
        If (ALFA < 20 And ALFA >= 17.5) Then
            PS = 0.00094608 * ALFA - 0.0116994
            'C......SE E' SODDISFATTO SETTA ISN=0
            If (TEST >= PS) Then ISN = 0
        End If
        'C.....RETTA 4
        If (ALFA < 25 And ALFA >= 20) Then
            PS = 0.0004127 * ALFA - 0.00103178
            'C......SE E' SODDISFATTO SETTA ISN=0
            If (TEST >= PS) Then ISN = 0
        End If
        'C.....RETTA 5
        If (ALFA < 30 And ALFA >= 25) Then
            PS = 0.0004127 * ALFA - 0.00103178
            'C......SE E' SODDISFATTO SETTA ISN=0
            If (TEST >= PS) Then ISN = 0
        End If
    End Sub
    Private Sub TEST2(ByRef ISN As Integer)
        'C     ROUTINE DI CALCOLO SECONDO ASME VIII D.2 AD-211
        'C     ALFA MINORE DI 30 GRADI
        'C     ISN=VARIABILE DI CONTROLLO SE E' SODDISFATTO IL GRAFICO
        'C     DI FIG. AD-211.1 E DA IL VALORE Q SE E' RICHIESTO
        'C     IL RINFORZO DEL CONO
        Dim Q1, Q2, DX, TR As Single
        Q = 0.0
        If (ISN = 0) Then Exit Sub
        'C.....RETTA 1 E 2 CON ALFA MINORE DI 10 GRADI
        If (ALFA <= 10) Then
            If (TEST < 0.0012 And TEST >= 0.001) Then
                Q = -350 * TEST + 1.52
            End If
            If (TEST < 0.0015 And TEST >= 0.0012) Then
                Q = -266.66667 * TEST + 1.42
            End If
            If (TEST > 0.0015) Then Q = 1.02
        End If
        'C.....RETTA 1 E 2 CON ALFA COMPRESO TRA 10 E 15 GRADI
        If (ALFA < 15 And ALFA > 10) Then
            If (TEST < 0.0012 And TEST >= 0.001) Then
                Q1 = -350 * TEST + 1.52
            End If
            If (TEST < 0.0015 And TEST >= 0.0012) Then
                Q1 = -266.66667 * TEST + 1.42
            End If
            If (TEST > 0.0015) Then Q1 = 1.02
            If (TEST < 0.002 And TEST >= 0.001) Then
                Q2 = -300 * TEST + 1.81
            End If
            If (TEST < 0.0034 And TEST >= 0.002) Then
                Q2 = -114.2857143 * TEST + 1.438571429
            End If
            If (TEST >= 0.0034) Then Q2 = 1.05
            'C......CALCOLA IL VALORE Q IN FUNZIONE DEL VALORE DI ALFA
            DX = (Q2 - Q1) / 5.0
            Q = ALFA * DX + Q1
        End If
        'C.....RETTA 2 E 3 CON ALFA COMPRESO TRA 15 E 20 GRADI
        If (ALFA < 20 And ALFA >= 15.0) Then
            If (TEST < 0.002 And TEST >= 0.001) Then
                Q1 = -300 * TEST + 1.81
            End If
            If (TEST < 0.0034 And TEST >= 0.002) Then
                Q1 = -114.2857143 * TEST + 1.438571429
            End If
            If (TEST >= 0.0034) Then Q1 = 1.05
            If (TEST < 0.0015 And TEST >= 0.001) Then
                Q2 = -500 * TEST + 2.35
            End If
            If (TEST < 0.002 And TEST >= 0.0015) Then
                Q2 = -300 * TEST + 2.05
            End If
            If (TEST < 0.0037 And TEST >= 0.002) Then
                Q2 = -147.0588 * TEST + 1.7441176
            End If
            If (TEST < 0.0058 And TEST >= 0.0037) Then
                Q2 = -66.666667 * TEST + 1.4466667
            End If
            If (TEST >= 0.0034) Then Q2 = 1.06
            'C......CALCOLA IL VALORE Q IN FUNZIONE DEL VALORE DI ALFA
            DX = (Q2 - Q1) / 5.0
            Q = ALFA * DX + Q1
        End If
        'C.....RETTA 2 E 3 CON ALFA COMPRESO TRA 20 E 25 GRADI
        If (ALFA < 20 And ALFA >= 15) Then
            If (TEST < 0.0015 And TEST >= 0.001) Then
                Q1 = -500 * TEST + 2.35
            End If
            If (TEST < 0.002 And TEST >= 0.0015) Then
                Q1 = -300 * TEST + 2.05
            End If
            If (TEST < 0.0037 And TEST >= 0.002) Then
                Q1 = -147.0588 * TEST + 1.7441176
            End If
            If (TEST < 0.0058 And TEST >= 0.0037) Then
                Q1 = -66.666667 * TEST + 1.4466667
            End If
            If (TEST >= 0.0034) Then Q1 = 1.06
            If (TEST < 0.002 And TEST > 0.001) Then
                Q2 = -440 * TEST + 2.6
            End If
            If (TEST < 0.0036 And TEST >= 0.002) Then
                Q2 = -200 * TEST + 2.12
            End If
            If (TEST < 0.005 And TEST > 0.0036) Then
                Q2 = -100 * TEST + 1.76
            End If
            If (TEST < 0.008 And TEST > 0.005) Then
                Q2 = -50 * TEST + 1.51
            End If
            If (TEST >= 8) Then Q2 = 1.11
            'C......CALCOLA IL VALORE Q IN FUNZIONE DEL VALORE DI ALFA
            DX = (Q2 - Q1) / 5.0
            Q = ALFA * DX + Q1
        End If
        'C.....RETTA 2 E 3 CON ALFA COMPRESO TRA 20 E 25 GRADI
        If (ALFA < 20 And ALFA >= 15) Then
            If (TEST < 0.002 And TEST > 0.001) Then
                Q1 = -440 * TEST + 2.6
            End If
            If (TEST < 0.0036 And TEST >= 0.002) Then
                Q1 = -200 * TEST + 2.12
            End If
            If (TEST < 0.005 And TEST > 0.0036) Then
                Q1 = -100 * TEST + 1.76
            End If
            If (TEST < 0.008 And TEST > 0.005) Then
                Q1 = -50 * TEST + 1.51
            End If
            If (TEST >= 8) Then Q1 = 1.11
            If (TEST < 0.003 And TEST > 0.0015) Then
                Q2 = -300 * TEST + 2.6
            End If
            If (TEST < 0.004 And TEST > 0.003) Then
                Q2 = -170 * TEST + 2.21
            End If
            If (TEST < 0.006 And TEST > 0.004) Then
                Q2 = -90 * TEST + 1.89
            End If
            If (TEST < 0.01 And TEST > 0.006) Then
                Q2 = -47.5 * TEST + 1.635
            End If
            If (TEST >= 0.01) Then Q2 = 1.16
            'C......CALCOLA IL VALORE Q IN FUNZIONE DEL VALORE DI ALFA
            DX = (Q2 - Q1) / 5.0
            Q = ALFA * DX + Q1
        End If
        'C.....CALCOLA LO SPESSORE RICHIESTO DEL CONO/CILINDRO
        TR = Q * T
        'C.....CALCOLO DELLA LUNGHEZZA DEL RINFORZO SUL CILINDRO CON DIAM. MAGG.
        rc = (DD1 + 2.0 * C1) * 0.5
        RRLC = 2.0 * Sqrt(TR * rc)
        'C.....CALCOLO DELLA LUNGHEZZA DEL RINFORZO SUL CONO ZONA DIAM. MAGG.
        RRL = 2.0 * Sqrt(R * TR / Cos(ALFA))
        T = TR
    End Sub
    Public Sub CONPRI(ByRef MEMBRATURA As clsInvolucroNew, ByRef Config As asConfig, ByVal FILE As String)
        TD1 = MEMBRATURA.Spess
        TD1 = TD1 / 25.4
        sw = IO.File.CreateText(FILE)
        sw.WriteLine(FormatStringa(1001), MEMBRATURA.Mark)
        CC = C1 * inc
        TT = TD1 * inc
        sw.WriteLine(FormatStringa(1102), MAT1, S1 * PSiVar, S1 * MPAvar, DD1, DD1 * inc, DD11, _
                     DD11 * inc, C1, CC, E1)
        sw.WriteLine(FormatStringa(1108), ALFA * 180 / pi, RagG / inc, RagG, _
                        RagP / inc, RagP, TL, TL * inc, R, R * inc)
        If (TEST <= 0.4) Then
            sw.WriteLine(FormatStringa(1200), T, T1, TD1, TT)
        Else
            sw.WriteLine(FormatStringa(1300), T, T1, TD1, TT)
        End If
        'c================================================
        'c	includere qui risultati calcolo giunzioni	
        'c=================================================
        sw.Close()
    End Sub
    Public Sub COUPS(ByRef NOZ1 As clsNozzleN, ByRef NOZ2 As clsNozzleN, ByRef IC As Integer, _
                      ByRef overFIT1 As Single, ByRef overFIT2 As Single, ByRef overFIT3 As Single, _
                      ByRef ISSUE1 As ASMERES, ByRef ISSUE2 As ASMERES, ByRef FILE As String)
        'C.....COMPENSAZIONE APERTURE ACCOPPIATE LONG. SU FONDI SFERICI
        'C     SECONDO ASME VIII D.2 AD 500-540.
        'C     AGGIUNTO COMPENSAZIONE DI BOCCHELLI NON RADIALI
        'C     IND = INDICE DEL TIPO DI FONDO
        'C     ITSH=INDICE SE L'APERTURA E' TANGENZIALE
        'C     DD3XL=RAGGIO ZONA SFERICA

        Dim DOO(2), ITSH(2), TNNF(2), TNNF1(2) As Single
        Dim ShThNzAr, ShThNzAr1, TCORR, DL, RAGGIO, RM, RN, ALFA1, ALFA2, EPS As Single
        Dim TEST1, XL1, XL2, SOMMAL, DX, DE1, DE2 As Single
        Dim XLL, TKN, DL1, DL2, DL3, DL4, FITL1, FITL2, RRM, DOE As Single
        Dim I As Integer
        Dim DTT(2), CorrNoz(2) As Single
        Dim NOZ(2) As clsNozzleN, ISSUE(2) As ASMERES
        IC = 0
        ShThNzAr = TD3
        ShThNzAr1 = NOZ1.ShThkNozArea / inc
        If (ShThNzAr1 > ShThNzAr / 2 And ShThNzAr1 < ShThNzAr * 2) Then
            ShThNzAr = ShThNzAr1
        End If
        ITSH(1) = 0
        ITSH(2) = 0
        'C     CALCOLA LO SPESSORE MINIMO SENZA CORROSIONE
        'C            era TS=TS-C3
        TCORR = TD3 - C3
        NOZ1.Risult = 0
        NOZ2.Risult = 0
        NOZ(1) = NOZ1
        NOZ(2) = NOZ2
        ISSUE(1) = ISSUE1
        ISSUE(2) = ISSUE2
        Call INTERF(NOZ1, NOZ2, IC, DL, RAGGIO)
        If (IC > 0) Then GoTo 121
        DL = DL / inc
        For I = 1 To 2
            Call VediRegola(NOZ(I))
            DOO(I) = NOZ(I).DiIn
            DOO(I) = DOO(I) / inc
            DTT(I) = DOO(I)
            TNNF(I) = NOZ(I).HX
            If (TNNF(I) = 0) Then TNNF(I) = NOZ(I).Spess
            TNNF(I) = TNNF(I) / inc
            TNNF1(I) = NOZ(I).Spess
            TNNF1(I) = TNNF1(I) / inc
            LXdisp = NOZ(I).LXdisp
            CorrNoz(I) = NOZ(I).CorrA
            If (NOZ(I).ONn > CorrNoz(I)) Then CorrNoz(I) = NOZ(I).ONn
            CorrNoz(I) = CorrNoz(I) / inc
        Next
        If (DL < (DOO(1) + DOO(2) + TNNF(1) + TNNF(2)) / 2) Then
            IC = 3
            overFIT3 = DL * inc
            GoTo 121
        End If
        For I = 1 To 2
            If (IC = -1) Then
                XLL = NOZ(I).DCL
                XLL = XLL / inc
                RM = DD3XL + C3 + TCORR * 0.5
                RN = (DOO(I) + 2.0 * CorrNoz(I)) * 0.5
                ALFA1 = Acos((XLL + RN) / RM)
                ALFA2 = Acos((XLL - RN) / RM)
                ALFA = ALFA2 - ALFA1
                DOE = 2.0 * RM * Sqrt(1 - (Cos(ALFA / 2.0)) ^ 2)
                DOO(I) = DOE
                ITSH(I) = 1
            End If
            EPS = 0.01
            TEST = (DOO(I)) / (2 * DD3XL)
            If (TEST > (0.5 + EPS)) Then
                'C99    CONTINUE
                'C      WRITE(*,*)'d/D > 0.50 USE ASME CODE APPENDIX 4 OR 5 '
                'C	 NOZ(I)%Risult=-1
                'C	 GOTO 121
            End If
            RRM = (2 * DD3XL + C3 + TD3) * 0.5
            TEST1 = 0.2 * Sqrt(RRM * (TD3 - C3))
            If ((DOO(I) + 2 * CorrNoz(I)) < TEST1) Then
                'C       WRITE(*,*)'SINGLE OPENING HAS A DIAMETER < 0.2*SQRT(Rm*T)'
                'C       WRITE(*,*)'YOU WANT REINFORCEMENT THE OPENING Y/N'
                'C	  NOZ(I)%Risult=-2
                'C	  GOTO 121
            End If
500:    Next
        'C     CALCOLO LIMITI DI RINFORZO LUNGO IL MANTELLO SECONDO AD 540.1
        TKN = TNNF(1)
        DL1 = DOO(1) + 2 * CorrNoz(1)
        DL2 = 0.5 * (DOO(1) + 2 * CorrNoz(1)) + (TD3 - C3) + (TKN - CorrNoz(1))
        'C     CALCOLA LA L PER IL PRIMO BOCCHELLO
        XL1 = Max(DL1, DL2)
        TKN = TNNF(2)
        DL3 = DOO(2) + 2 * CorrNoz(2)
        DL4 = 0.5 * (DOO(2) + 2 * CorrNoz(2)) + (TD3 - C3) + (TKN - CorrNoz(2))
        'C     CALCOLA LA L PER IL SECONDO BOCCHELLO
        XL2 = Max(DL3, DL4)
        'C     SOMMA LE DUE L CALCOLATE
        SOMMAL = XL1 + XL2
        'C     CALCOLA LA LUNGHEZZA DI INTERFERENZA
        DX = Abs(SOMMAL - DL)
        'C     TEST SE LE APERTURE INTERFERISCONO
        If (DL > SOMMAL) Then
            overFIT1 = XL1 * inc
            'C       WRITE(*,*)' LIMIT OF REINFORCEMENT ALONG SHELL FOR FIRST NOZZLE:'
            'C       WRITE(*,*)' L = ',XL1,'  inch = ',FIT,' Inc'
            overFIT2 = XL2 * inc
            overFIT3 = DL * inc
            IC = -2
            GoTo 121
        End If
        'C     SE LE APERTURE INTERFERISCONO LIMITA LA L
        If (DL < SOMMAL) Then
            'C     CALCOLA LE NUOVE L E MEMORIZZA LE VECCHIE IN FITL1&FITL2
            FITL1 = XL1
            FITL2 = XL2
            XL1 = XL1 - DX / 2
            XL2 = XL2 - DX / 2
            DE1 = DOO(1) / 2
            DE2 = DOO(2) / 2
            overFIT1 = XL1 * inc
            overFIT2 = XL2 * inc
            overFIT3 = DL * inc
            'C      CONTROLLA CHE I LIMITI DI RINFORZO SUPERINO IL FILO ESTERNO
            'C      DEL BOCCHELLO
            If (XL1 < DE1) Then NOZ(1).Risult = -8
            If (XL2 < DE2) Then NOZ(2).Risult = -8
            IC = -1
            If (XL1 < DE1 Or XL2 < DE2) Then IC = 3
        End If
121:    NOZ1 = NOZ(1)
        NOZ2 = NOZ(2)
        ISSUE1 = ISSUE(1)
        ISSUE2 = ISSUE(2)
    End Sub
    Private Sub INTERF(ByRef NOZ1 As clsNozzleN, ByRef NOZ2 As clsNozzleN, ByRef I As Integer, ByRef DIST As Single, ByRef RAGGIO As Single)
        Dim AZIMUT1, ANOMAL1, posX1, posY1, posZ1 As Single
        Dim AZIMUT2, ANOMAL2, posX2, posY2, posZ2, ANG As Single
        Call RAGGIOCAL(RAGGIO)
        Call POSIZ(NOZ1, AZIMUT1, ANOMAL1, RAGGIO, I)
        If (I > 0) Then Exit Sub 'RETURN
        posX1 = RAGGIO * Cos(ANOMAL1) * Sin(AZIMUT1)
        posY1 = RAGGIO * Sin(ANOMAL1) * Sin(AZIMUT1)
        posZ1 = RAGGIO * Cos(AZIMUT1)
        Call POSIZ(NOZ2, AZIMUT2, ANOMAL2, RAGGIO, I)
        If (I > 0) Then
            If (I = 1) Then I = 11
            Exit Sub
        End If
        posX2 = RAGGIO * Cos(ANOMAL2) * Sin(AZIMUT2)
        posY2 = RAGGIO * Sin(ANOMAL2) * Sin(AZIMUT2)
        posZ2 = RAGGIO * Cos(AZIMUT2)
        DIST = Sqrt((posX1 - posX2) ^ 2 + (posY1 - posY2) ^ 2 + (posZ1 - posZ2) ^ 2)
        ANG = 2 * Asin(DIST / 2 / RAGGIO)
        DIST = RAGGIO * ANG
        RAGGIO = RAGGIO - TD3 * inc / 2
    End Sub
    Private Sub RAGGIOCAL(ByRef RAGGIO As Single)
        Select Case (INDFON)
            Case (1)
                RAGGIO = DD3 * inc / 2
            Case (2)
                RAGGIO = CROWN * inc
            Case (3)
                RAGGIO = 0.85 * DD3 * inc
        End Select
        RAGGIO = RAGGIO + TD3 * inc / 2 '!correzione Villa/Presciuttini 10/06/2002
        DD3XL = RAGGIO / inc
    End Sub
    Private Sub POSIZ(ByRef NOZ As clsNozzleN, ByRef AZIMUT As Single, ByRef ANOMAL As Single, ByRef RAGGIO As Single, ByRef I As Integer)
        I = 0
        If (NOZ.DCL = 0 And NOZ.DTL = 0 And NOZ.beta = 0) Then
            '      'assiale centrato
            AZIMUT = 0
            ANOMAL = 0
        ElseIf (NOZ.DCL = 0 And NOZ.DTL = 0) Then
            'radiale rispetto al fondo
            AZIMUT = NOZ.beta * pi / 180
            ANOMAL = NOZ.Anomal * pi / 180
        ElseIf (NOZ.DCL = 0 And NOZ.beta = 0) Then
            'radiale rispetto al cilindro
            If (INDFON = 1) Then
                ANOMAL = NOZ.Anomal * pi / 180
                AZIMUT = Acos(NOZ.DTL / RAGGIO)
            Else
                I = 1
            End If
        ElseIf (NOZ.DTL = 0 And NOZ.beta = 0) Then
            'assiale decentrato
            ANOMAL = NOZ.Anomal * pi / 180
            I = -1
            If (NOZ.DCL >= RAGGIO) Then
                I = 2
            Else
                AZIMUT = Asin(NOZ.DCL / RAGGIO)
            End If
        End If
    End Sub
    Public Sub FON(ByRef MEMBRATURA As clsInvolucroNew, ByRef Config As asConfig, _
                   ByRef p0 As Single, ByRef tdtd As Single, ByRef T1bas As Single)
        Dim I As Integer
        Dim D1, RK, XLloc As Single
        Select Case (MEMBRATURA.ms)
            Case (1)
                'C  1 "Ellipsoidal Head : D/2h=2.0  "
                I = 3
            Case (2)
                'C  2 "Ellipsoidal Head : D/2h<>2.0 "
                I = 3
            Case (3)
                'C  3 "Torisph.Head : r=0.06L & L=Do" 
                I = 2
            Case (6)
                'C  4 "Torispherical Head : r>0.06L "
                I = 2
            Case (4)
                'C  3 "Kloepper" 
                I = 2
            Case (5)
                'C  4 "Korbbogen"
                I = 2
            Case (7)
                I = 1
                'C  5 "Emispherical Head            "
            Case (8)
                I = 1
                'C  5 "Calotta sferica     "
        End Select
        P3 = p0
        TMD3 = tdtd
        MAT = MEMBRATURA.MATE
        MATsave = MAT
        If (Config.VerificandoPI = 0) Then
            S3 = MEMBRATURA.St
        Else
            S3 = MEMBRATURA.Shydr
        End If
        D1 = MEMBRATURA.di
        If (I = 1) Then
            DD3 = MEMBRATURA.L0 * 2 / inc
        Else
            DD3 = D1 / inc
        End If
        If (I = 2) Then
            RK = MEMBRATURA.R0
            RK = RK / inc
            XLloc = MEMBRATURA.L0
            XLloc = XLloc / inc
        End If
        C3 = MEMBRATURA.cs
        If (C3 = 0) Then C3 = MEMBRATURA.OS
        C3 = C3 / inc
        E3 = MEMBRATURA.ES
        Select Case (I)
            Case (1)
                R = MEMBRATURA.L0 / inc + C3
                Call HEM(T1bas)
            Case (2)
                Call TOR(RK, XLloc, T1bas)
                CROWN = XLloc
            Case (3)
                Call ELL(T1bas)
        End Select
        INDFON = I
        IND = I
    End Sub
    Public Sub FONPRI(ByRef MEMBRATURA As clsInvolucroNew, ByRef Config As asConfig, ByVal FILE As String)
        Select Case (INDFON)
            Case (1)
                Call HEMPRI(MEMBRATURA, Config, FILE)
            Case (2)
                Call TORPRI(MEMBRATURA, Config, FILE)
            Case (3)
                Call ELLPRI(MEMBRATURA, Config, FILE)
        End Select
    End Sub
    Public Sub ELL(ByRef T1bas As Single)
        Dim ellA, ellA1, ellA2, ellA3, ellB1, ellB2, ellB3, ellC1, ellC2, ellCC3 As Double
        Dim X, Y, Y2 As Double
        'C     Rev.4A - 21/01/98 - Aggiunta conversione SI
        TEST = P3 / (S3 * E3)
        If (TEST <= 0.08) Then
            X = 0.17
            Y = Log(P3 / (S3 * E3))
            Y2 = Y * Y
            ellA1 = -1.2617702
            ellA2 = -4.5524592
            ellA3 = 28.933179
            ellB1 = 0.66298796
            ellB2 = -2.2470836
            ellB3 = 15.682985
            ellC1 = 0.000026878909
            ellC2 = -0.42262179
            ellCC3 = 1.8878333
            ellA = ellA1 + ellA2 * X + ellA3 * X * X + _
                   (ellB1 + ellB2 * X + ellB3 * X * X) * Y + _
                   (ellC1 + ellC2 * X + ellCC3 * X * X) * Y2
            TL = Exp(ellA)
            T = TL * 0.9 * (DD3 + 2 * C3) + C3
            T1 = inc * T
        Else
            T = 0.5 * (DD3 + 2.0 * C3) * (Exp(TEST) - 1.0) + C3
            T1 = inc * T
        End If
        T1bas = (T - C3) * inc
    End Sub
    Public Sub ELLPRI(ByRef MEMBRATURA As clsInvolucroNew, ByRef Config As asConfig, ByVal FILE As String)
        TD3 = MEMBRATURA.Spess
        TD3 = TD3 / inc
        sw = IO.File.CreateText(FILE)
        sw.WriteLine(FormatStringa(1002), MEMBRATURA.Mark)
        PMPA = P3 * MPAvar
        TCENT = TMD3
        If (Config.US = 1) Then TCENT = (TMD3 - 32.0) / 1.8
        If (Config.US = 0) Then TMD3 = 1.8 * TMD3 + 32
        D1 = DD3 * inc
        CC = C3 * inc
        TT = TD3 * inc
        sw.WriteLine(FormatStringa(1103), P3 * PSiVar, PMPA, TMD3, TCENT, MAT, S3 * PSiVar, S3 * MPAvar, _
                    DD3, D1, C3, CC, E3)
        If (TEST <= 0.08) Then
            sw.WriteLine(FormatStringa(1203), TEST, TL, _
               0.9 * (DD3 + 2 * C3), 0.9 * (DD3 + 2 * C3) * inc, T, T1, TD3, TT)
        Else
            sw.WriteLine(FormatStringa(1303), T, T1, TD3, TT)
        End If
        sw.Close()
    End Sub
    Public Sub HEM(ByRef T1bas As Single)
        'C     CALCOLA I FONDI SFERICI
        'C     ---------------------------------------------------------------------
        'C     Revisionata il 13-09-94 (calcolo del raggio interno della sfera
        'C     DD3XL) su segnalazione d'errore di Re Calegari.
        'C     ---------------------------------------------------------------------
        TEST = P3 / (S3 * E3)
        If (TEST <= 0.4) Then
            T = 0.5 * P3 * R / (S3 * E3 - 0.25 * P3) + C3
            T1 = inc * T
        Else
            T = Exp(TEST * 0.5) * R - R + C3
            T1 = inc * T
        End If
        T1bas = (T - C3) * inc
    End Sub
    Public Sub HEMPRI(ByRef MEMBRATURA As clsInvolucroNew, ByRef Config As asConfig, ByVal FILE As String)
        TD3 = MEMBRATURA.Spess
        TD3 = TD3 / inc
        sw = IO.File.CreateText(FILE)
        sw.WriteLine(FormatStringa(1004), MEMBRATURA.Mark)
        PMPA = P3 * MPAvar
        TCENT = TMD3
        If (Config.US = 1) Then TCENT = (TMD3 - 32) / 1.8
        If (Config.US = 0) Then TMD3 = 1.8 * TMD3 + 32
        D1 = DD3 * inc
        CC = C3 * inc
        TT = TD3 * inc
        RR = R * inc
        sw.WriteLine(FormatStringa(1104), P3 * PSiVar, PMPA, TMD3, TCENT, MAT, S3 * PSiVar, S3 * MPAvar, _
                    DD3, D1, R, RR, C3, CC, E3)
        If (TEST < 0.4) Then
            sw.WriteLine(FormatStringa(1204), T, T1, TD3, TT)
        Else
            sw.WriteLine(FormatStringa(1304), T, T1, TD3, TT)
        End If
        sw.Close()
    End Sub
    Public Sub TOR(ByRef RK As Single, ByRef XLloc As Single, ByRef T1bas As Single)
        Dim torA, torA1, torA2, torA3, torB1, torB2, torB3, _
          torC1, torC2, torCC3 As Double
        Dim X, Y As Double
        TEST = P3 / (S3 * E3)
        If (TEST <= 0.08) Then
            X = RK / (DD3 + 2.0 * C3)
            Y = Log(P3 / (S3 * E3))
            torA1 = -1.2617702
            torA2 = -4.5524592
            torA3 = 28.933179
            torB1 = 0.66298796
            torB2 = -2.2470836
            torB3 = 15.682985
            torC1 = 0.000026878909
            torC2 = -0.42262179
            torCC3 = 1.8878333
            torA = torA1 + torA2 * X + torA3 * X * X + _
                   (torB1 + torB2 * X + torB3 * X * X) * Y + _
                   (torC1 + torC2 * X + torCC3 * X * X) * Y * Y
            TL = Exp(torA)
            T = TL * XLloc + C3
            T1 = inc * TFT
        Else
            T = 0.5 * (DD3 + 2.0 * C3) * (Exp(TEST) - 1.0) + C3
            T1 = inc * TFT
        End If
        T1bas = (T - C3) * inc
    End Sub
    Public Sub TORPRI(ByRef MEMBRATURA As clsInvolucroNew, ByRef Config As asConfig, ByVal FILE As String)
        TD3 = MEMBRATURA.Spess
        TD3 = TD3 / inc
        sw = IO.File.CreateText(FILE)
        sw.WriteLine(FormatStringa(1005), MEMBRATURA.Mark)
        PMPA = P3 * MPAvar
        TCENT = TMD3
        If (Config.US = 1) Then TCENT = (TMD3 - 32.0) / 1.8
        If (Config.US = 0) Then TMD3 = 1.8 * TMD3 + 32
        D1 = DD3 * inc
        CC = C3 * inc
        TT = TD3 * inc
        RK = MEMBRATURA.R0 / inc
        sw.WriteLine(FormatStringa(1105), P3 * PSiVar, PMPA, TMD3, TCENT, MAT, S3 * PSiVar, S3 * MPAvar, _
                     DD3, D1, RK, RK * inc, CROWN, CROWN * inc, C3, CC, E3)
        If (TEST <= 0.08) Then
            sw.WriteLine(FormatStringa(1205), A, TL, T, T1, TD3, TT)
        Else
            sw.WriteLine(FormatStringa(1305), T, T1, TD3, TT)
        End If
        sw.Close()
    End Sub
    Public Sub GetDataforNozzle(ByRef NOZ As clsNozzleN, ByRef AllN As Single)
        'C     Nuova Routine di Acquisizione dati Geometrici Bocchelli
        'C     by CD  -  26/06/98
        Dim TEST1 As Single
        MATN = NOZ.MATE
        If (VerificandoPI = 0) Then
            Sn = NOZ.AllN
            SNP = NOZ.AllPad
        Else
            Sn = NOZ.AllNPI
            SNP = NOZ.AllPadPI
        End If
        'C     CALCOLO DEL FATTORE DI RIDUZIONE (VEDI AD-551)
        FR = 1
        If (AllN > 0) Then
            FR = Sn / AllN
        Else
            FR = Sn / S
        End If
        If (FR < 0.8 And Not VerificandoPI) Then
            NOZ.Risult = -5
            Exit Sub
        End If
        'C     CALCOLO DEL FATTORE DI RIDUZIONE PAD (VEDI AD-551)
        FRP = 1
        If (SNP > 0 And Regola = 31 Or Regola = 4) Then
            If (AllN > 0) Then
                FRP = SNP / AllN
            Else
                FRP = SNP / S
            End If
        Else
            FRP = FR
        End If
        'C     VERIFICA AD-550 (f)
        AlfR = NOZ.alfaNoz
        AlfS = NOZ.alfaShell
        delt = NOZ.dtAD550f
        chkAD550f = 0
        If (AlfR * AlfS * (AlfR - AlfS) * delt = 0) Then GoTo 1
        chkAD550f = Abs((AlfR - AlfS) * delt)
        If (chkAD550f > 0.0008) Then
            NOZ.Risult = -10
            Exit Sub
        End If
1:      TKN = NOZ.HX
        If (TKN = 0) Then TKN = NOZ.Spess
        TKN = TKN / inc
        TKN1 = NOZ.Spess / inc
        THETA = NOZ.TransitionAngle
        LXdisp = NOZ.LXdisp / inc
        If (TKN > TKN1 Or Regola = 2 Or Regola = 21) Then
            If (THETA = 0) Then THETA = 45
            If (THETA > 45) Then
                NOZ.Risult = -6
                Exit Sub
            End If
            THETA = THETA / 180 * pi
            XLT = NOZ.LX   '!Disp-NOZ%LX-(TKN-TKN1)/TAN(THETA)*Inc
            If (XLT < 0) Then
                NOZ.Risult = -7
                Exit Sub
            End If
            If (Not (Regola = 2 Or Regola = 21)) Then _
                LL = NOZ.LX + (TKN - TKN1) / Tan(THETA) * inc
        Else
            LL = NOZ.LXdisp
            XLT = LL
        End If
        LL = LL / inc
        XLT = XLT / inc
        'C     Introdotta Variante per Protrusione - by CD 25/6798
        If (NOZ.Protusion > 0) Then
            IPROT = 1
        Else
            IPROT = 0
        End If
        'C         WRITE(*,*) 'ENTER PROTRUDING LENGTH FROM INSIDE OF SHELL(Inc)'
        LPROT = NOZ.Protusion
        LPROT = LPROT / inc
        'C      WRITE(*,*)'EXTERNAL CONNECTING RADIUS R2 -  NOZZLE TO SHELL(Inc)'
        R2 = NOZ.R2
        R1 = NOZ.R1
        FILLET = 0
        If (R2 = 0) Then
            FILLET = NOZ.Leg41
            R2 = FILLET
        End If
        EN = NOZ.EffN
        'C     CALCOLO DELLO SPESSORE MINIMO DEL TRONCHETTO
        TEST = PN / (Sn * EN)
        R = (D0 + 2.0 * CORRN) * 0.5
        If (TEST < 0.4) Then
            TX = PN * R / (Sn * EN - 0.5 * PN)
        End If
        If (TEST > 0.4) Then
            TX = Exp(TEST) * R - R
        End If
        TEST1 = 0.2 * Sqrt(RRM * (td - C))
        If ((D0 + 2 * CORRN) < TEST1) Then
            'C       WRITE(*,*)'SINGLE OPENING HAS A DIAMETER < 0.2*SQRT(Rm*T)'
            'C       WRITE(*,*)'CIRCULAR OPENING NOT REQUIRING REINFORCEMENT'
            If (NOZ.Risult <> 2 And NOZ.Risult > -3) Then
                NOZ.Risult = -2
                IAD540 = 0
                Exit Sub
            Else
                NOZ.Risult = 0
            End If
        End If
    End Sub
    Private Sub CalcDiamApert(ByRef NOZ As clsNozzleN, ByRef ISSUE As ASMERES)
        SREXT = ISSUE.SR '!Spessore minimo a pressione esterna
        If (NOZ.Risult < 0) Then NOZ.Risult = 0
        POS = NOZ.Mark.Trim '//'                   '
        P = NOZ.Pdes
        TMD = NOZ.Tdes
        MAT = MATsave
        If (ISSUE.SpCop > 0) Then
            TS = ISSUE.SpCop / inc
            If (ISSUE.SpCopA > 0) Then td = ISSUE.SpCopA / inc
            If (ISSUE.Diam > 0) Then DD = ISSUE.Diam / inc
            C = ISSUE.CorrCop / inc
            S = ISSUE.AllCop
            DDsav = 0
            MATsave = MAT
            MAT = NOZ.MateCop
            SpCop = ISSUE.SpCop
        Else
            SpCop = 0
            TS = T - C
            If (NOZ.InvolucroSU < 0) Then
                DD = D0
                td = TKN1
                TS = TX
            Else
                DDsav = DD
                TDsav = td
                TSsav = TS
            End If
        End If
        VerificandoPI = ISSUE.VerificandoPI
        D0 = NOZ.DiIn
        CORRN = NOZ.CorrA
        If (NOZ.ONn > CORRN) Then CORRN = NOZ.ONn
        CORRN = CORRN / inc
        If (D0 = 0) Then D0 = NOZ.DiOn - 2 * NOZ.Spess
        D0 = D0 / inc
    End Sub
    Public Sub OP(ByRef NOZ As clsNozzleN, ByRef ISSUE As ASMERES)
        'C.....COMPENSAZIONE APERTURE CILINDRICHE ASME VIII D.2 AD 500-540
        'C     Rev.4A - 21/01/98 - 1) Modificato controllo su d/D(basato 
        'C                            ora sui diam. nominali anziche' cor-
        'C         CD                 rosi
        'C                         2) Agggiunta conversione SI
        'C                         3) Corretto Calcolo Rinforzo disponibile su bocchello
        Dim EPS, RN, RM, ALF1, ALF2, AXES As Single
        'C---------------------------------------------------------------------
        Call CalcDiamApert(NOZ, ISSUE)
        TEST = (D0) / (DD)
        EPS = 0.01
        RRM = (DD + C + td) * 0.5
        If (TEST > (0.5 + EPS)) Then
            '          C() 'd/D > 0.50 USE ASME CODE APPENDIX 4 OR 5 '
            NOZ.Risult = -1
            Exit Sub
        End If
        RN = (D0 + 2 * CORRN) * 0.5
        ITANG = 0
        D0E = D0
        If (ISSUE.SpCop = 0 And NOZ.DCL <> 0) Then
            'C     VERIFICA SE BISOGNA COMPENSARE NEL PIANO CIRCONFERENZIALE'
            RM = (DD + 2 * C + TS) * 0.5
            '            C()      'DISTANCE C/L NOZZLE FROM SHELL AXES (Inc)'
            AXES = NOZ.DCL
            AXES = AXES / inc
            ALF1 = Acos((AXES + RN) / RM)
            ALF2 = Acos((AXES - RN) / RM)
            ALFA = ALF2 - ALF1
            F5201 = 0.5
            If (NOZ.UW16 >= 14 And NOZ.UW16 <= 16) Then F5201 = 1
            DTEST = 2 * RM * Sqrt(1 - Cos(ALFA / 2) ^ 2)
            XLL = AXES
            If (DTEST * F5201 >= D0) Then
                D0E = DTEST * F5201
                ITANG = 1
            End If
        ElseIf (ISSUE.SpCop = 0 And NOZ.beta < 90) Then
            'C     VERIFICA SU BOCCHELLI INCLINATI LONGITUDINALMENTE
            D0E = D0 / Sin(NOZ.beta * pi / 180)
        Else
            AXES = 0
            XLL = 0
        End If
        '        C()     'DESIGN PRESSURE - NOZZLE             (Psi)'
        PN = P
        '        C()     'DESIGN TEMPERATURE                   øC'
        TMN = TMD
        'C     Inizializzazioni .............................................
        MATN = " "
        YPROT = "N"
        IPROT = 0
        YWELD = "N"
        YNZL = "N"
        YPAD = "N"
        Check = "NO"
        Call OpeningCheck(2 * (RN - CORRN), NOZ, ISSUE)
        ISSUE.Aa = AA
        ISSUE.a = A
        ISSUE.a1 = A1
        ISSUE.AA1 = AA1
        ISSUE.a2 = A2
        ISSUE.A2PROT = A2PROT
        ISSUE.A3 = A3
        ISSUE.AA3 = AA3
        ISSUE.A4 = A4
    End Sub
    Public Sub OPPRI(ByRef NOZ As clsNozzleN, ByRef FILE As String)
        Dim J01, J02, J03, J04, J1 As Single
        Dim MEMB As String
        If (SpCop = 0) Then
            MEMB = strSHELL
        Else
            MEMB = strCOVER
        End If
        J01 = PN * MPAvar
        J02 = TMN
        If (UniMis = 1) Then J02 = (TMN - 32) / 1.8
        If (UniMis = 0) Then TMN = 1.8 * TMN + 32
        J03 = S * MPAvar
        J04 = Sn * MPAvar
        J1 = DD * inc
        sw = IO.File.CreateText(FILE)
        sw.WriteLine(FormatStringa(1006), POS)
        If (AllNOn = 0) Then
            sw.WriteLine(FormatStringa(1106), PN * PSiVar, J01, TMN, J02, _
                  MAT, MATN, S * PSiVar, J03, Sn * PSiVar, J04)
        Else
            J03 = AllNOn * MPAvar
            sw.WriteLine(FormatStringa(1112), PN * PSiVar, J01, TMN, J02, _
                  MATnOn, MATN, AllNOn, J03, Sn * PSiVar, J04)
        End If
        sw.WriteLine(FormatStringa(1197), DD, J1)
        Call STAMPAGEOM()
        AXES = NOZ.DCL / inc
        AXESMM = AXES * inc
        If (AXES > 0) Then
            sw.WriteLine(FormatStringa(1225), AXES, AXESMM)
            If (ITANG = 1) Then
                sw.WriteLine(FormatStringa(1223), F5201, D0E, D0E * inc)
            Else
                sw.WriteLine(FormatStringa(1213), DTEST * inc, F5201)
            End If
        End If
        If (NOZ.beta < 90) Then
            sw.WriteLine(FormatStringa(1260), NOZ.beta, D0E, D0E * inc)
        End If
        Call STAMPAR2()
        If (TKN > TKN1) Then sw.WriteLine(FormatStringa(1207))
        If (NOZ.Risult = -2) Then
            sw.WriteLine(rmHelpStrings.GetString("fmt5500"))
            sw.Close()
            Exit Sub
        End If
        'C.........SALTO PAGINA
        sw.WriteLine("\page ")
        sw.WriteLine(FormatStringa(1006), POS)
        Call STAMPAEXT()
        If (Regola = 5) Then
            If (IXL = 1) Then
                sw.WriteLine(FormatStringa(1499), MEMB, L1, L1 * inc, L2, L2 * inc, XL, XL * inc, _
                FXL, FXL * inc, MEMB, A1, A1 * inc ^ 2)
            Else
                sw.WriteLine(FormatStringa(1498), MEMB, L1, L1 * inc, L2, L2 * inc, FXL, FXL * inc, _
                MEMB, A1, A1 * inc ^ 2)
            End If
        Else
            If (IXL = 1) Then
                sw.WriteLine(FormatStringa(1501), MEMB, L1, L1 * inc, L2, L2 * inc, XL, XL * inc, _
                FXL, FXL * inc, MEMB, A1r1, A1r1 * inc ^ 2, A1, A1 * inc ^ 2)
            Else
                sw.WriteLine(FormatStringa(1500), MEMB, L1, L1 * inc, L2, L2 * inc, FXL, FXL * inc, _
                   MEMB, A1r1, A1r1 * inc ^ 2, A1, A1 * inc ^ 2)
            End If
        End If
        Call STAMPAA2()
        If (IPROT = 1) Then sw.WriteLine(FormatStringa(2203), L3PROT, A2PROT)
        If (Regola = 31 Or Regola = 3) Then
            If (2 * FXL > PL) Then
                sw.WriteLine(FormatStringa(2500), FRP, PL, PL * inc, TPL, TPL * inc, A3, A3 * inc ^ 2)
            Else
                sw.WriteLine(FormatStringa(2501), FRP, 2 * FXL, 2 * FXL * inc, TPL, TPL * inc, A3, A3 * inc ^ 2)
            End If
        ElseIf (Regola = 4) Then
            If (2 * FXL > PL) Then
                sw.WriteLine(FormatStringa(2500), FRP, PL, PL * inc, L3final, L3final * inc, A3, A3 * inc ^ 2)
            Else
                sw.WriteLine(FormatStringa(2501), FRP, 2 * FXL, 2 * FXL * inc, L3final, L3final * inc, A3, A3 * inc ^ 2)
            End If
        End If
        Call STAMPAA4()
        sw.WriteLine(FormatStringa(1800), AT, A)
        'C.........SALTO PAGINA
        sw.WriteLine("\page ")
        'C     STAMPA VERIFICA SECONDO AD-540.1(b)
        sw.WriteLine(FormatStringa(1006), POS)
        Call STAMPAAEXT()
        sw.WriteLine(FormatStringa(3500), L4, L4 * inc, L5, L5 * inc, L6, L6 * inc, AA1, AA1 * inc ^ 2, RadQ)
        Call STAMPAA2()
        If (IPROT = 1) Then sw.WriteLine(FormatStringa(2203), L3PROT, A2PROT)
        Call STAMPAA3()
        Call STAMPAA4()
        sw.WriteLine(FormatStringa(1800), ATT, AA)
        sw.Close()
        If (NOZ.InvolucroSU < 0 And DDsav > 0) Then
            DD = DDsav
            td = TDsav
            TS = TSsav
        End If
    End Sub
    Public Sub STAMPAA2()
        Dim tmtr As String
        Dim IFMT As Integer
        If (SetIn = 1 And Regola > 4 Or Regola = 31) Then
            tmtr = tmtrST
        Else
            tmtr = tmtrFR
        End If
        Select Case (Regola)
            Case 1, 11, 12, 21
                If (IAD540 = 1) Then
                    If (L3final <= XLT) Then
                        sw.WriteLine(FormatStringa(1600), LL1, LL1 * inc, _
                          LL2, LL2 * inc, ZL3, ZL3 * inc, _
                          XL3, XL3 * inc, L3, L3 * inc, L3final, L3final * inc, _
                          tmtr, A2 / FR, A2 / FR * inc ^ 2, RadQ)
                    ElseIf (L3final < LL) Then
                        sw.WriteLine(FormatStringa(1601), LL1, LL1 * inc, LL2, LL2 * inc, _
                        ZL3, ZL3 * inc, XL3, XL3 * inc, _
                        L3, L3 * inc, L3final, L3final * inc, TETA, _
                        tmtr, ABC1, ABC1 * inc ^ 2, _
                        ABC2, ABC2 * inc ^ 2, A2 / FR, A2 / FR * inc ^ 2, RadQ, GreekTheta)
                    Else
                        sw.WriteLine(FormatStringa(1602), LL1, LL1 * inc, _
                        LL2, LL2 * inc, ZL3, ZL3 * inc, XL3, XL3 * inc, _
                        L3, L3 * inc, L3final, L3final * inc, _
                        tmtr, ABC1, ABC1 * inc ^ 2, ABC2, ABC2 * inc ^ 2, _
                        ABC3, ABC3 * inc ^ 2, A2 / FR, A2 / FR * inc ^ 2, RadQ)
                    End If
                End If
                If (IAD540 = 2) Then
                    If (L3final <= XLT) Then
                        sw.WriteLine(FormatStringa(1603), LL1, LL1 * inc, LL2, LL2 * inc, _
                        ZL3, ZL3 * inc, L3, L3 * inc, _
                        L3final, L3final * inc, _
                        tmtr, A2 / FR, A2 / FR * inc ^ 2, RadQ)
                    ElseIf (L3final < LL) Then
                        sw.WriteLine(FormatStringa(1604), LL1, LL1 * inc, LL2, LL2 * inc, _
                        ZL3, ZL3 * inc, L3, L3 * inc, L3final, L3final * inc, TETA, _
                        tmtr, ABC1, ABC1 * inc ^ 2, ABC2, ABC2 * inc ^ 2, _
                        A2 / FR, A2 / FR * inc ^ 2, RadQ)
                    Else
                        sw.WriteLine(FormatStringa(1605), LL1, LL1 * inc, LL2, LL2 * inc, _
                        ZL3, ZL3 * inc, XL3, XL3 * inc, _
                        L3final, L3final * inc, _
                        tmtr, ABC1, ABC1 * inc ^ 2, _
                        ABC2, ABC2 * inc ^ 2, ABC3, ABC3 * inc ^ 2, _
                        A2 / FR, A2 / FR * inc ^ 2, RadQ)
                    End If
                End If
                If (Regola > 4) Then sw.WriteLine(FormatStringa(1633), A2, A2 * inc ^ 2)
            Case (2)
                Dim Pad As String = GreekTheta
                If (IAD540 = 1) Then
                    If (L3final <= XLT) Then
                        IFMT = 1620
                    Else
                        IFMT = 1621
                        Pad = " "
                    End If
                ElseIf (IAD540 = 2) Then
                    If (L3final <= XLT) Then
                        IFMT = 1622
                    Else
                        IFMT = 1623
                    End If
                End If
                sw.WriteLine(FormatStringa(IFMT), LL1, LL1 * inc, LL2, LL2 * inc, _
                    ZL3, ZL3 * inc, L3, L3 * inc, _
                    L3final, L3final * inc, ABC1, ABC1 * inc ^ 2, _
                    ABC2, ABC2 * inc ^ 2, A2, A2 * inc ^ 2, RadQ, Pad)
            Case 14, 15
                sw.WriteLine(FormatStringa(1606), LL1, LL1 * inc, LL2, LL2 * inc, _
                    ZL3, ZL3 * inc, TPLeff, TPLeff * inc, _
                    L3, L3 * inc, L3final, L3final * inc, _
                    tmtr, A2 / FR, A2 / FR * inc ^ 2, RadQ)
            Case (4)
                sw.WriteLine(FormatStringa(1607), LL1, LL1 * inc, LL2, LL2 * inc, _
                    L3, L3 * inc, L3final, L3final * inc)
            Case Else
                sw.WriteLine(FormatStringa(1619), Regola)
        End Select
    End Sub
    Public Sub STAMPAA3()
        If (Regola = 31 Or Regola = 3) Then
            If (PL = PPL) Then
                sw.WriteLine(FormatStringa(2500), FRP, PPL, PPL * inc, _
                    TPL, TPL * inc, AA3, AA3 * inc ^ 2)
            Else
                sw.WriteLine(FormatStringa(2501), FRP, PPL, PPL * inc, _
                    TPL, TPL * inc, AA3, AA3 * inc ^ 2)
            End If
        ElseIf (Regola = 4) Then
            If (PL = PPL) Then
                sw.WriteLine(FormatStringa(2500), FRP, PPL, PPL * inc, _
                    L3final, L3final * inc, AA3, AA3 * inc ^ 2)
            Else
                sw.WriteLine(FormatStringa(2501), FRP, PPL, PPL * inc, _
                    L3final, L3final * inc, AA3, AA3 * inc ^ 2)
            End If
        End If
    End Sub
    Public Sub STAMPAA4()
        If (FILLET > 0) Then
            sw.WriteLine(FormatStringa(1701), A4, A4 * inc ^ 2)
        Else
            sw.WriteLine(FormatStringa(1700), A4, A4 * inc ^ 2)
        End If
    End Sub
    Public Sub STAMPAR2()
        sw.WriteLine(FormatStringa(1285), R1 / inc, R1)
        If (FILLET > 0) Then
            sw.WriteLine(FormatStringa(1286), R2 / inc, R2)
        Else
            sw.WriteLine(FormatStringa(1287), R2 / inc, R2)
        End If
    End Sub
    Public Sub STAMPAGEOM()
        Dim J11 As Single
        J11 = LPROT * inc
        If (Regola = 4) Then
            sw.WriteLine(FormatStringa(8206), td, td * inc, ShThNzAr, ShThNzAr * inc, D0, D0 * inc, _
                         (PL - D0) / 2, (PL - D0) / 2 * inc)
            sw.WriteLine(FormatStringa(8209), CORRN, CORRN * inc, LXdisp, LXdisp * inc, _
                         TS, TS * inc, XLdisp / inc, XLdisp, TX, TX * inc)
        Else
            sw.WriteLine(FormatStringa(8200), td, td * inc, ShThNzAr, ShThNzAr * inc, D0, D0 * inc, _
                         TKN, TKN * inc, TKN1, TKN1 * inc)
            If (TKN > TKN1) Then
                sw.WriteLine(FormatStringa(8202), THETA * 180 / pi)
                sw.WriteLine(FormatStringa(8201), CORRN, CORRN * inc, XLT, XLT * inc, LL, LL * inc, _
                     LXdisp, LXdisp * inc, TS, TS * inc, XLdisp / inc, XLdisp, TX, TX * inc)
            Else
                sw.WriteLine(FormatStringa(8223), CORRN, CORRN * inc, XLT, XLT * inc, LXdisp, LXdisp * inc, _
                     TS, TS * inc, XLdisp / inc, XLdisp, TX, TX * inc)
            End If
        End If
        If (LXdisp = 0 Or XLdisp = 0) Then sw.WriteLine(rmHelpStrings.GetString("fmt8225"))
        If (SREXT > 0) Then
            sw.WriteLine(FormatStringa(8214), SREXT / inc, SREXT)
        End If
        If (PL > 0 And TPL > 0) Then sw.WriteLine(FormatStringa(8208), PL, PL * inc, _
            XTPL, TPL * inc)
        Select Case (IAD540)
            Case (1)
                sw.WriteLine(rmHelpStrings.GetString("fmt8211"))
            Case (2)
                sw.WriteLine(rmHelpStrings.GetString("fmt8212"))
        End Select
        If (D0E > D0) Then sw.WriteLine(FormatStringa(8204), D0E, D0E * inc, XLL, XLL * inc)
        If (IPROT = 1) Then
            sw.WriteLine(FormatStringa(2200), LPROT, J11)
            Select Case (IAD540PROT)
                Case (1)
                    sw.WriteLine(rmHelpStrings.GetString("fmt2201"))
                Case (2)
                    sw.WriteLine(rmHelpStrings.GetString("fmt2202"))
            End Select
        End If
        If (chkAD550f > 0) Then sw.WriteLine(FormatStringa(8226), GreekAlpha, GreekAlpha, _
             GreekDeltaMaiusc, chkAD550f, MinoreUguale, GreekAlpha, AlfR / 1.8, AlfR, _
             GreekAlpha, AlfS / 1.8, AlfS, _
             GreekDeltaMaiusc, 1.8 * delt + 32, delt)
    End Sub
    Public Sub STAMPAEXT()
        If (SpCop = 0 And D0E > D0) Then sw.WriteLine(rmHelpStrings.GetString("fmt1306"))
        If (Regola = 5) Then
            If (SpCop = 0) Then
                sw.WriteLine(FormatStringa(1344), A, A * inc ^ 2)
                If (AEXT > 0) Then sw.WriteLine(FormatStringa(1404), AEXT, AEXT * inc ^ 2)
            Else
                sw.WriteLine(FormatStringa(1345), A, A * inc ^ 2)
                If (AEXT > 0) Then sw.WriteLine(FormatStringa(1405), AEXT, AEXT * inc ^ 2)
            End If
            Exit Sub
        End If
        If (L = 1) Then
            If (SpCop = 0) Then
                sw.WriteLine(FormatStringa(1340), FR, A, A * inc ^ 2)
            Else
                sw.WriteLine(FormatStringa(1342), FR, A, A * inc ^ 2)
            End If
            If (AEXT > 0) Then sw.WriteLine(FormatStringa(1341), FR, AEXT, AEXT * inc ^ 2)
        End If
        If (L = 0) Then
            If (Regola > 3) Then sw.WriteLine(FormatStringa(1343), FR)
            Dim IFMT As Integer
            If (SpCop = 0) Then
                IFMT = 1400
                If (FR < 1 And SetIn) Then
                    If (Regola = 4) Then
                        IFMT = 1411
                    Else
                        IFMT = 1410
                    End If
                End If
            Else
                IFMT = 1402
                If (FR < 1 And SetIn) Then IFMT = 1412
            End If
            sw.WriteLine(FormatStringa(IFMT), A, A * inc ^ 2)
            If (AEXT > 0) Then sw.WriteLine(FormatStringa(1401), AEXT, AEXT * inc ^ 2)
        End If
    End Sub
    Public Sub STAMPAAEXT()
        If (L = 1) Then
            sw.WriteLine(FormatStringa(2300), FR, AA, AA * inc ^ 2)
            If (AAEXT > 0) Then sw.WriteLine(FormatStringa(2301), AAEXT, AAEXT * inc ^ 2)
        Else
            sw.WriteLine(FormatStringa(2400), AA, AA * inc ^ 2)
            If (AAEXT > 0) Then sw.WriteLine(FormatStringa(2401), AAEXT, AEXT * inc ^ 2)
        End If
    End Sub
    Private Sub SHELL(ByRef NOZ As clsNozzleN, ByRef ISSUE As ASMERES)
        'C     CALCOLO LIMITI DI RINFORZO LUNGO IL MANTELLO SECONDO AD 540.1
        'C     by CD  -  24/06/98
        'C.....CALCOLO DEL RINFORZO SECONDO AD 540 1.a
        'C     100% DEL RINFORZO DENTRO L
        ShThNzAr = td
        Dim ShThNzAr1 As Single = NOZ.ShThkNozArea / inc
        If (ShThNzAr1 > ShThNzAr / 2 And ShThNzAr1 < ShThNzAr * 2) Then ShThNzAr = ShThNzAr1
        A = TS * (D0E + 2 * CORRN)
        If (Regola = 5) Then
            A = A + 2 * TS * (TKN - CORRN)
        ElseIf (Regola = 4) Then
            A = A + 2 * TS * ((PL - D0) / 2 - CORRN) * (1 - FRP)
        ElseIf (SetIn) Then
            A = A + 2 * TS * (TKN - CORRN) * (1 - FR)
        End If
        If (ISSUE.SpCop > 0) Then A = A / 2
        ISSUE.AExt = 0.5 * (ISSUE.SR) * (D0 + 2 * CORRN) / inc
        AEXT = ISSUE.AExt
        L1 = D0 + 2 * CORRN
        L2 = 0.5 * (D0 + 2 * CORRN) + (td - C) + (TKN - CORRN)
        If (Regola = 4) Then L2 = 0.5 * (D0 + 2 * CORRN) + (td - C) + ((PL - D0) / 2 - CORRN)
        XL = Max(L1, L2)
        FXL = XL * inc
        IXL = 0
        XLdisp = 0
        If (NOZ.FactVicini > 0 And NOZ.FactVicini < 1) Then
            FXL = FXL * NOZ.FactVicini
            XL = XL * NOZ.FactVicini
        End If
        If (NOZ.LSDisp > 0) Then XLdisp = NOZ.LSDisp + D0 / 2 * inc
        If (XLdisp < FXL And NOZ.LSDisp > 0) Then
            IXL = 1
            FXL = XLdisp
        End If
        FXL = FXL / inc
        'C     Diam.Esterno Bocchello - Zona Autorinforzo
        DE = D0 + 2 * TKN
        'C     CALCOLO AREA DISPONIBILE NEL MANTELLO
        A1r1 = (1 - pi / 4) * (R1 / inc) ^ 2
        If (Regola = 5) Then
            A1 = (2 * FXL - DE) * (ShThNzAr - TS - C)
        Else
            A1 = (2 * FXL - DE) * (ShThNzAr - TS - C) - A1r1
        End If
        'C.....CALCOLO DEL RINFORZO SECONDO AD 540 1.b
        'C     2/3 DEL RINFORZO DENTRO L
        AA = 2 * A / 3
        ISSUE.AAExt = 2 / 3 * ISSUE.AExt
        AAEXT = ISSUE.AAExt
        L4 = (D0 + 2 * CORRN) / 2 + 0.5 * Sqrt((DD + C + td) * 0.5 * (td - C))
        L5 = (D0 + 2 * CORRN) / 2 + (td - C) + (TKN - CORRN)
        If (Regola = 4) Then L5 = (D0 + 2 * CORRN) / 2 + (td - C) + ((PL - D0) / 2 - CORRN)
        L6 = Max(L4, L5)
        'C     CONTROLLA SE EFETTIVAMENTE RISULTA L'<L
        'C     ALTRIMENTI PONE L'=L
        If (L6 > FXL) Then L6 = FXL
        If (Regola = 5) Then
            AA1 = (2 * L6 - DE) * (ShThNzAr - TS - C)
        Else
            AA1 = (2 * L6 - DE) * (ShThNzAr - TS - C) - A1r1
        End If
    End Sub
    Private Sub subNOZZLE(ByRef RMN As Single)
        'C     CALCOLO LIMITI DI RINFORZO SUL BOCCHELLO SECONDO AD 540.2
        'C     ASME VIII DIV.2
        'C     Nuova Routine by CD   -   25/06/98
        Dim LL2A, FRloc As Single
        If (Regola = 5) Then
            A2 = 0
            Exit Sub
        End If
        Dim TESTN As Single = 2.5 * (TKN - CORRN) + 0.73 * R2 / inc
        LL1 = 0.5 * Sqrt(RMN * (TKN - CORRN)) + 0.73 * R2 / inc
        XL3 = LL + 2.5 * (TKN1 - CORRN)
        If (XLT < TESTN) Then
            'C     AD 540.2 SKECTHES a & b PUNTO 1
            IAD540 = 1
            LL2 = 1.73 * (TKN - TKN1) + 2.5 * (TKN1 - CORRN) + 0.73 * R2 / inc
            XL1 = Max(LL1, LL2)
            ZL3 = 2.5 * (td - C)
            XL4 = Min(ZL3, XL3)
            L3 = Min(XL1, XL4)
        Else
            'C     AD 540.2 SKECTHES a & b PUNTO 2
            IAD540 = 2
            LL2 = 2.5 * (TKN - CORRN)
            XL1 = Max(LL1, LL2)
            ZL3 = 2.5 * (td - C)
            L3 = Min(XL1, ZL3)
        End If
        L3final = L3
        If (LXdisp > 0 And L3 > LXdisp) Then L3final = LXdisp
        'C     CALCOLO LUNGHEZZA DISPONIBILE SU PROTRUSIONE L3PROT
        If (LPROT < TESTN Or LPROT = 0) Then
            'C     AD 540.2 SKECTHES a & b PUNTO 1
            LL2A = 1.73 * (TKN - TKN1) + 2.5 * (TKN1 - CORRN) + 0.73 * R2 / inc
            XL1A = Max(LL1, LL2A)
            XL3A = LPROT + 2.5 * (TKN1 - CORRN)
            XL4A = Min(ZL3, XL3)
            L3PROT = GlobalRoutines.Minimo(XL1A, XL4A, LPROT)
            IAD540PROT = 1
        Else
            'C     AD 540.2 SKECTHES a & b PUNTO 2
            LL2A = 2.5 * (TKN - CORRN)
            XL1A = Max(LL1, LL2A)
            Dim ZL3A As Single = 2.5 * (td - C)
            L3PROT = GlobalRoutines.Minimo(XL1A, ZL3A, L3PROT)
            IAD540PROT = 2
        End If
        'C     CALCOLO AREA DI RINFORZO SUL BOCCHELLO
        FRloc = 1
        If (SetIn And Regola > 4) Then FRloc = FR
        If (L3final <= XLT) Then
            A2 = 2.0 * (L3final + (td - TS - C) / FRloc) * (TKN - TX - CORRN)
        ElseIf (L3final < LL) Then
            TETA = THETA
            Dim B1 As Single = (LL - L3final) * Tan(TETA)
            Dim B2 As Single = TKN - TKN1
            ABC1 = 2.0 * (XLT + (td - TS - C) / FRloc) * (TKN - TX - CORRN)
            ABC2 = (B1 + B2) * (L3final - XLT) + 2.0 * (TKN1 - TX - CORRN) * (L3final - XLT)
            A2 = ABC1 + ABC2
            TETA = TETA * 180.0 / pi
        Else
            ABC1 = 2 * (XLT + (td - TS - C) / FRloc) * (TKN - TX - CORRN)
            ABC2 = (TKN - TKN1) * (LL - XLT)
            ABC3 = 2 * (L3final - XLT) * (TKN1 - TX - CORRN)
            A2 = ABC1 + ABC2 + ABC3
        End If
        If (Regola > 4) Then A2 = A2 * FR
        A2PROT = 2.0 * L3PROT * (TKN - 2 * CORRN)
    End Sub
    Private Sub subNOZZLE2()
        Dim XAD5402a As Single
        'C     CALCOLO LIMITI DI RINFORZO SUL BOCCHELLO SECONDO AD 540.2
        'C     ASME VIII DIV.2  AD.540.2(b)
        'C     Nuova Routine by LP   -   25/06/02
        Dim XAD5402 As Single = XLT * Tan(THETA)
        TKN = TKN1 + 0.667 * XAD5402
        RMN = (D0 + CORRN + TKN) / 2
        LL1 = 0.5 * Sqrt(RMN * (TKN - CORRN))
        'C(XL3 = LL + 2.5 * (TKN1 - CORRN))
        If (THETA < 30 * pi / 180) Then
            'C     AD 540.2 SKECTHES c PUNTO 2
            IAD540 = 2
            LL2 = 1.73 * XAD5402 + 2.5 * (TKN1 - CORRN)
            XL1 = Max(LL1, LL2)
            ZL3 = 2.5 * (td - C)
            L3 = Min(XL1, ZL3)
        Else
            'C     AD 540.2 SKECTHES c PUNTO 1
            IAD540 = 1
            LL2 = XLT + 2.5 * (TKN1 - CORRN)
            XL1 = Max(LL1, LL2)
            ZL3 = 2.5 * (td - C)
            L3 = Min(XL1, ZL3)
        End If
        L3final = L3
        If (LXdisp > 0 And L3 > LXdisp) Then L3final = LXdisp
        ''C     CALCOLO LUNGHEZZA DISPONIBILE SU PROTRUSIONE L3PROT
        ''C     AD 540.2 SKECTHES a & b PUNTO 1
        '!LL2A = 1.73 * (TKN - TKN1) + 2.5 * (TKN1 - CORRN) + 0.73 * R2 / Inc
        '!XL1A = AMAX1(LL1, LL2A)
        '!XL3A = LPROT + 2.5 * (TKN1 - CORRN)
        '!XL4A = AMIN1(ZL3, XL3)
        '!L3PROT = AMIN1(XL1A, XL4A, LPROT)
        '!IAD540PROT = 1
        '!else()
        ''C     AD 540.2 SKECTHES a & b PUNTO 2
        '!LL2A = 2.5 * (TKN - CORRN)
        '!XL1A = AMAX1(LL1, LL2A)
        '!ZL3A = 2.5 * (td - C)
        '!L3PROT = AMIN1(XL1A, ZL3A, L3PROT)
        '!IAD540PROT = 2
        '!      end if

        'C     CALCOLO AREA DI RINFORZO SUL BOCCHELLO
        If (L3final <= XLT) Then
            ABC1 = 2 * (td - TS - C) * (TKN - TX - CORRN)
            XAD5402a = (XLT - L3final) * Tan(THETA)
            ABC2 = 2 * L3final * ((TKN - TX - CORRN) + (XAD5402a + TKN1 - TX - CORRN)) / 2
            A2 = ABC1 + ABC2
        Else
            ABC1 = 2.0 * (td - TS - C) * (TKN - TX - CORRN)
            ABC1 = ABC1 + 2 * XLT * ((TKN - TX - CORRN) + (TKN1 - TX - CORRN)) / 2
            ABC2 = 2 * (TKN1 - TX - CORRN) * (L3final - XLT)
            A2 = ABC1 + ABC2
        End If
        If (Regola = 21) Then A2 = A2 * FR
        '        C(A2PROT = 2.0 * L3PROT * (TKN - 2 * CORRN))
    End Sub
    Private Sub subNOZZLE3()
        Dim W As Single
        'C     CALCOLO LIMITI DI RINFORZO SUL BOCCHELLO SECONDO AD 540.2
        'C     ASME VIII DIV.2  AD.540.2(c)
        'C     Nuova Routine by LP   -   25/06/02
        RMN = (D0 + CORRN + TKN) / 2
        W = (PL - DE) / 2
        TPLeff = TPL
        If (TPLeff > 1.73 * W) Then TPLeff = 1.73 * W
        If (TPLeff > 1.5 * td) Then TPLeff = 1.5 * td
        LL1 = 0.5 * Sqrt(RMN * (TKN - CORRN)) + TPLeff + 0.73 * R2 / inc
        LL2 = 2.5 * (TKN1 - CORRN) + TPLeff + 0.73 * R2 / inc
        XL1 = Max(LL1, LL2)
        ZL3 = 2.5 * (td - C)
        L3 = Min(ZL3, XL1)
        L3final = L3
        If (LXdisp > 0 And L3 > LXdisp) Then L3final = LXdisp
        'C     CALCOLO LUNGHEZZA DISPONIBILE SU PROTRUSIONE L3PROT

        '!      if(LPROT.LT.TESTN.OR.LPROT.EQ.0.) then
        'C     AD 540.2 SKECTHES a & b PUNTO 1
        '       !LL2A = 1.73 * (TKN - TKN1) + 2.5 * (TKN1 - CORRN) + 0.73 * R2 / Inc
        '       !XL1A = AMAX1(LL1, LL2A)
        '       !XL3A = LPROT + 2.5 * (TKN1 - CORRN)
        '       !XL4A = AMIN1(ZL3, XL3)
        '       !L3PROT = AMIN1(XL1A, XL4A, LPROT)
        '       !IAD540PROT = 1
        '       !else()
        '       C()
        'C     AD 540.2 SKECTHES a & b PUNTO 2
        '        C()
        '        !LL2A = 2.5 * (TKN - CORRN)
        '        !XL1A = AMAX1(LL1, LL2A)
        '        !ZL3A = 2.5 * (td - C)
        '        !L3PROT = AMIN1(XL1A, ZL3A, L3PROT)
        '        !IAD540PROT = 2
        '!      end if

        'C     CALCOLO AREA DI RINFORZO SUL BOCCHELLO
        A2 = 2 * (L3final + (td - TS - C)) * (TKN - TX - CORRN)
        If (Regola = 31) Then A2 = A2 * FR
        'C(A2PROT = 2.0 * L3PROT * (TKN - 2 * CORRN))
    End Sub
    Private Sub subNOZZLE4()
        Dim W As Single
        'C     CALCOLO LIMITI DI RINFORZO SUL BOCCHELLO SECONDO AD 540.2
        'C     ASME VIII DIV.2  AD.540.2(d)
        'C     Nuova Routine by LP   -   03/10/02
        RMN = (D0 + CORRN + TKN) / 2
        W = (PL - DE) / 2
        TPLeff = TPL
        LL1 = 1.73 * W
        LL2 = 1.5 * td
        If (TPLeff > LL1) Then TPLeff = LL1
        If (TPLeff > LL2) Then TPLeff = LL2
        XL1 = 0
        ZL3 = 0
        L3 = TPLeff
        L3final = L3
        If (LXdisp > 0 And L3 > LXdisp) Then L3final = LXdisp
        'C     CALCOLO AREA DI RINFORZO SUL BOCCHELLO
        A2 = 0
    End Sub
    Private Sub OpeningCheck(ByRef D0E As Single, ByRef NOZ As clsNozzleN, _
                              ByRef ISSUE As ASMERES)
        'C     CALCOLO LIMITI DI RINFORZO E AREE DISPONIBILI LUNGO IL FONDO
        'C     SECONDO AD 540.1
        Check = "OK"
        Call VediRegola(NOZ)
        RMN = (D0 + CORRN + TKN) * 0.5
        Call GetDataforNozzle(NOZ, ISSUE.AllN)
        Call RINFORZO(NOZ)
        Call SHELL(NOZ, ISSUE)
        If (NOZ.Risult < 0) Then Exit Sub
        'C     CALCOLO DEL FATTORE DI RIDUZIONE (VEDI AD 551)
        L = 0
        FR = 1
        If (ISSUE.AllN > 0) Then
            AllNOn = ISSUE.AllN
            FR = Sn / AllNOn
            MATnOn = ISSUE.MatN
        Else
            FR = Sn / S
            AllNOn = 0
        End If
        If (FR > 1) Then FR = 1
        FRP = 1
        If (SNP > 0 And Regola = 31) Then
            If (AllNOn > 0) Then
                FRP = SNP / AllNOn
            Else
                FRP = SNP / S
            End If
        ElseIf (Regola = 3) Then
            FRP = FR
        End If
        If (FRP > 1) Then FRP = 1
        If (FR > 1 And Regola < 3) Then
            L = 1
            A = A / FR
            AA = AA / FR
            ISSUE.AExt = ISSUE.AExt / FR
            AEXT = AEXT / FR
            ISSUE.AAExt = ISSUE.AAExt / FR
            AAEXT = AAEXT / FR
        End If
        YWELD = "Y"
        'C     CALCOLO AREA DI RINFORZO SUL BOCCHELLO
        Select Case (Regola)
            Case 2, 21
                Call subNOZZLE2()
            Case 3, 31
                Call subNOZZLE3()
            Case (4)
                Call subNOZZLE4()
            Case Else
                Call subNOZZLE(RMN)
        End Select
        XL6 = 20 * L6
        Call subA3()
        'c	IF(Regola.EQ.31)THEN
        'c	IF(2*FXL.GT.PL) THEN
        'C(A3 = (PL - DE) * TPL * FRP)
        'c	ELSE
        'C(A3 = (2 * FXL - DE) * TPL * FRP)
        'c	ENDIF
        'c	ENDIF
        'C     CALCOLO AREE DI SALDATURA
        A4 = (R2 ^ 2 * 0.429204) / (inc ^ 2) * (1 + IPROT)
        If (FILLET > 0) Then A4 = (R2 / inc) ^ 2
        If (Regola > 5) Then A4 = A4 * FR
        If (Regola = 5) Then A4 = 0
        AT = A1 + A2 + A2PROT + A3 + A4
        Ls = 0
        'C.....VERIFICA SE IL RINFORZO RISPETTA LE CONDIZIONI AD 540.1.b
        '        C(PPL = XL6)
        '        C(AA3 = (PPL - D0 - 2.0 * TKN) * TPL * FRP)
        'c       ELSE
        '        C(PPL = PL)
        '        C(AA3 = A3)
        'c       ENDIF
        'c      ENDIF
        ATT = AA1 + A2 + A2PROT + AA3 + A4
        If (AT <= A Or AT <= AEXT) Then
            NOZ.Risult = -3
            Check = "NO"
        ElseIf (ATT < AA Or ATT < AAEXT) Then
            Check = "NO"
            NOZ.Risult = -4
        End If
    End Sub
    Private Sub VediRegola(ByRef NOZ As clsNozzleN)
        SetIn = False
        Select Case (NOZ.UW16)
            Case 1, 2
                Regola = 1 '!AD - 540.2(a)
            Case (3)
                Regola = 2 '!AD - 540.2(b)
            Case (4)
                Regola = 3 '!AD - 540.2(c)
            Case (9)
                '!protusion()
                NOZ.Risult = -9
            Case 5, 6, 12
                Regola = 12 ' !Set-on e quindi per Fr.... 
                SetIn = False
            Case 7, 8, 10, 11
                Regola = 11 ' !Set-in e quindi per Fr....
                SetIn = True
            Case (13)
                Regola = 11 '  !Set-in autorinf
                SetIn = True
            Case 14, 15
                Regola = 31
            Case 16
                NOZ.Risult = -9
            Case (17)
                SetIn = True
                NOZ.Risult = -9
            Case (18)
                Regola = 4
                SetIn = 1
            Case 19, 20, 21, 22, 23, 24, 25, 26, 27
                '                !si(vedrà)
                NOZ.Risult = -9
            Case 28 '        !fodero a penetrazione parziale AD-621.1 (c-1)
                Regola = 5
            Case 29, 30, 31
                Regola = 6
                NOZ.Risult = -9
                SetIn = True
            Case (32)
                Regola = 11 ' !Set-in
                SetIn = True
            Case (33)
                Regola = 12  '!Set-on
        End Select
    End Sub
    Private Sub subA3()
        Dim H As Single = TPL
        If (H > L3final) Then H = L3final
        A3 = 0
        If (Regola = 31 Or Regola = 3 Or Regola = 4) Then
            If (2 * FXL > PL) Then
                A3 = (PL - DE) * H
                If (Regola = 3) Then A3 = A3 - H * H / 3
            Else
                A3 = (2 * FXL - DE) * H
                If (Regola = 3 And 2 * FXL > PL - 6 * H) Then A3 = A3 - H * H * 3 + ((PL / 2 - FXL) / 3) ^ 2 * 3
            End If
            A3 = A3 * FRP
        End If
        AA3 = 0.0
        If (A3 > 0) Then
            If (PL > XL6) Then
                PPL = XL6
                AA3 = (PPL - DE) * H
                If (Regola = 3 And PPL > PL - 6 * H) Then A3 = A3 - H * H * 3 + ((PL / 2 - PPL) / 3) ^ 2 * 3
            Else
                PPL = PL
                AA3 = A3 / FRP
            End If
            AA3 = AA3 * FRP
        End If
    End Sub
    Private Sub RINFORZO(ByRef NOZ As clsNozzleN)
        PL = 0
        Select Case (Regola)
            Case 3, 4, 31
            Case Else
                Exit Sub
        End Select
        PL = NOZ.Padd
        'c      IF(PL>XZ)then PL=XZ
        '        C(TPL1 = Inc * 1.5 * td)
        'C       WRITE(*,*)'THICKNESS OF REINFORCING PAD (Inc)',TPL1,'(Inc) MAXIMUM'
        TPL = NOZ.PadT
        If (Regola > 3 Or Regola = 4) Then
            TPL = TPL - NOZ.ShThkNozArea
            If (NOZ.Risult < 0) Then Exit Sub
            If (TPL < 0) Then
            ElseIf ((PL - DE) / 2 <= 3 * TPL And Regola = 3) Then
            End If
        End If
        'c      IF(TPL.GT.TPL1)TPL=TPL1
        TPL = TPL / inc
        PL = PL / inc
        '100   FORMAT('Ci sono probabilmente dati errati:',A2,
        '        X() 'lo spessore della scarpa risulta non superiore',A2,
        '        X() 'allo spessore del mantello',A1)
        '101   FORMAT('Ci sono probabilmente dati errati:',A2,
        '        X() 'il diametro della scarp anon è abbastanza',A2,
        '        X() 'grande per alloggiare la transizione 1:3.',A1)
    End Sub
    Public Sub OPSH(ByRef NOZ As clsNozzleN, ByRef ISSUE As ASMERES)
        'C.....COMPENSAZIONE APERTURE SU FONDI SFERICI
        'C     SECONDO ASME VIII D.2 AD 500-540.
        'C-----------AGGIORNATO IN DATA 24-6-97 DA TOS VEDI REAL .....
        'C     IND  = INDICE DEL TIPO DI FONDO
        'C          = 1 - MANTELLI E FONDI EMISFERICI
        'C          = 2 - FONDI ELLITTICI
        'C          = 3 - FONDI TOROSFERICI
        '        C()
        'C     DD3XL= RAGGIO FONDO EMISFERICO/MANTELLO SFERICO
        '        C = "   FONDO EMISFERICO"
        '        C = "   DI SOMMITA' FONDO ELLITTICO"
        '        C = "   PARTE SFERICA FONDO TOROSFERICO"
        '        C()
        Dim RAGGIO, RM, RN, EPS, ALFA1, ALFA2 As Single
        'C     Rev.4A - 21/01/98 - 1) Modificato controllo su d/D(basato 
        'C                            ora sui diam. nominali anziche' cor-
        'C         CD                 rosi
        'C                         2) Agggiunta conversione SI
        'C--------------------------------------------------------------------
        Call CalcDiamApert(NOZ, ISSUE)
        '       C(Rm = DD3XL + C3 + TSTT * 0.5)
        Call RAGGIOCAL(RAGGIO)
        C = C3
        RM = DD3XL + C3 + T * 0.5
        RN = (D0 + 2.0 * CORRN) * 0.5

        'C      TEST=(D0+2.0*C3)/(2.*DD3XL+2.0*C3)

        TEST = (D0) / (2 * DD3XL)
        EPS = 0.01
        If (TEST > (0.5 + EPS)) Then
            NOZ.Risult = -1
            Exit Sub
        End If
        '        C(TS = TSTT - C3)
        RRM = (2 * DD3XL + C3 + TD3) * 0.5
        'C      WRITE(*,*)'IS THE NOZZLE TANGENTIAL TO HEAD ? '
        'C      WRITE(*,*)'=>TYPE Y OR N'
        'C      READ(*,1)YTANG
        'C      IF(YTANG.EQ.'Y'.OR.YTANG.EQ.'y')THEN
        'C       WRITE(*,*)'>>TANGENTIAL OPENING ON SPHERICAL HEAD<<'
        'C       WRITE(*,*)' DISTANCE NOZZLE AXES FROM C.L. AXES OF'
        'C       WRITE(*,*)' SPHERICAL HEAD (Inc)'
        If (NOZ.DCL <> 0) Then
            XLL = Abs(NOZ.DCL)
            XLL = XLL / inc
            ALFA1 = Acos((XLL + RN) / RM)
            ALFA2 = Acos((XLL - RN) / RM)
            ALFA = ALFA2 - ALFA1
            D0E = 2 * RM * Sqrt(1 - (Cos(ALFA / 2.0)) ^ 2)
            YTANG = "Y"
        Else
            D0E = D0
            YTANG = "N"
            XLL = 0
        End If
        '        C()     'DESIGN PRESSURE - NOZZLE             (Psi)'
        P = P3
        PN = P3
        '       C()     'DESIGN TEMPERATURE                  øC'
        TMD = TMD3
        TMN = TMD3

        DD = 2 * DD3XL

        'C     Inizializzaioni .............................................
        MATN = " "
        IPROT = 0
        Check = "NO"
        S = S3
        td = TD3
        C = C3
        Call OpeningCheck(2 * (RN - CORRN), NOZ, ISSUE)
        'C      IF(CHECK.EQ.'NO') THEN
        'C       write(*,*)'>>>>>>>>>>Opening NOT Reinforced<<<<<<<<<<<<'
        'C       return
        'C      ELSE
        'C       write(*,*)'>>>>>>>>Opening ADEQUATELY REINFORCED!<<<<<<<<<<<<<'
        'C      ENDIF
        ISSUE.Aa = AA
        ISSUE.a = A
        ISSUE.a1 = A1
        ISSUE.AA1 = AA1
        ISSUE.a2 = A2
        ISSUE.A2PROT = A2PROT
        ISSUE.A3 = A3
        ISSUE.AA3 = AA3
        ISSUE.A4 = A4
    End Sub
    Public Sub OPSHPRI(ByRef NOZ As clsNozzleN, ByRef FILE As String)
        Dim J01, J02, J03, J04, J1 As Single
        J01 = PN * MPAvar
        J02 = TMN
        If (UniMis = 1) Then J02 = (TMN - 32) / 1.8
        If (UniMis = 0) Then TMN = TMN * 1.8 + 32
        J03 = S3 * MPAvar
        J04 = Sn * MPAvar
        J1 = DD3XL * inc
        sw = IO.File.CreateText(FILE)
        Call PRINTEST()
        sw.WriteLine(FormatStringa(1107), PN * PSiVar, J01, TMN, J02, MAT, MATN, _
                     S3 * PSiVar, J03, Sn * PSiVar, J04)
        If (UCase(YTANG) = "Y") Then sw.WriteLine(rmHelpStrings.GetString("fmt1109"))
        'C     if (IND.EQ.1) then
        sw.WriteLine(FormatStringa(1199), DD3XL, J1)
        'C     ELSE
        'C      WRITE(6,1198)2.*DD3XL,J1
        'C      WRITE(6,1199)DD3XL,J1/2.
        'C     ENDIF
        td = TD3
        ' C = C3
        Call STAMPAGEOM()
        Call STAMPAR2()
        If (TKN > TKN1) Then sw.WriteLine(rmHelpStrings.GetString("fmt1207"))
        If (NOZ.Risult = -2) Then
            sw.WriteLine(rmHelpStrings.GetString("fmt1207"))
            sw.WriteLine(FormatStringa(5500), RadQ)
            sw.Close()
            Exit Sub
        End If

        'C.........SALTO PAGINA
        sw.WriteLine("\page ")
        Call PRINTEST()
        Call STAMPAEXT()
        If (IXL = 1) Then
            sw.WriteLine(FormatStringa(1503), L1, L1 * inc, L2, L2 * inc, _
                 XLdisp / inc, XLdisp, FXL, FXL * inc, _
                 A1r1, A1r1 * inc ^ 2, A1, A1 * inc ^ 2)
        Else
            sw.WriteLine(FormatStringa(1502), L1, L1 * inc, L2, L2 * inc, _
                 FXL, FXL * inc, A1r1, A1r1 * inc ^ 2, A1, A1 * inc ^ 2)
        End If
        If (NOZ.FactVicini > 0 And NOZ.FactVicini < 1) Then
            sw.WriteLine(FormatStringa(1504), NOZ.FactVicini)
        End If
        '        C()
        Call STAMPAA2()
        If (IPROT = 1) Then sw.WriteLine(FormatStringa(2203), L3PROT, A2PROT)

        If (A3 > 0) Then
            If (2 * FXL > PL) Then
                sw.WriteLine(FormatStringa(2500), PL, TPL, A3)
            Else
                sw.WriteLine(FormatStringa(2501), 2 * FXL, TPL, A3)
            End If
        End If
        Call STAMPAA4()
        sw.WriteLine(FormatStringa(1800), AT, A)
        'C.....STAMPA VERIFICA SECONDO AD 540-1.(b)

        sw.WriteLine("\page ")
        Call PRINTEST()
        Call STAMPAAEXT()
        sw.WriteLine(FormatStringa(3501), L4, L4 * inc, L5, L5 * inc, L6, L6 * inc, _
              AA1, AA1 * inc ^ 2, RadQ)
        Call STAMPAA2()
        Call STAMPAA3()
        Call STAMPAA4()
        sw.WriteLine(FormatStringa(1800), ATT, AA)
        sw.Close()
        If (NOZ.InvolucroSU < 0) Then
            DD = DDsav
            td = TDsav
            TS = TSsav
        End If
    End Sub
    Private Sub PRINTEST()
        Select Case (IND)
            Case (1)
                'C.....STAMPA INTESTAZIONE FONDO SFERICO
                sw.WriteLine(FormatStringa(1010), POS)
            Case (2)
                'C.....STAMPA INTESTAZIONE FONDO TOROSFERICO
                sw.WriteLine(FormatStringa(1011), POS)
            Case (3)
                'C.....STAMPA INTESTAZIONE FONDO ELLITTICO
                sw.WriteLine(FormatStringa(1012), POS)
        End Select
    End Sub
End Module
