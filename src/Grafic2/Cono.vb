Option Strict Off
Option Explicit On
Imports RoutBase1
Imports System.Math
<Serializable()> Public Class Cono
    Inherits Membratura
    Public AF As Single '????????
    Private prDgran As Single
    Private prDpicc As Single
    Public PiedG As Single
    Public PiedP As Single
    Public RagG As Single
    Public RagP As Single
    Private prAltezza As Single
    Public AlfaCon As Single
    Private prSpessBase As Single
    Public SpessRive As Single
    Public SpessPar As Single
    Public NumSpicchi As Short
    Public NumSal As Short
    ' Public TipoMat As Short '1,2,3,4
    Public TipOPT As Short
    Public StandardG As LibMat.clsPipe
    Public StandardP As LibMat.clsPipe
    '----------------------
    'Public GenMem As clsGenMem
    'Public Variato As Boolean
    Public Spicchiat As Spicchi
    Public Fitting As Boolean
    Private DgCon As Single
    Private DpCon As Single
    Private IpCon As Single
    Private Formafuori As Boolean
    <NonSerialized()> Private DM01, DM11 As Single
    <NonSerialized()> Private DM0E, DM1E As Single
    <NonSerialized()> Private DM, DM1 As Single
    <NonSerialized()> Private Cal(10) As Short
    <NonSerialized()> Private PLLAM1, PLLAM0, PLLAM2 As Single
    <NonSerialized()> Private x3, x1, x2, x4 As Single
    <NonSerialized()> Private y3, y1, y2, y4 As Single
    <NonSerialized()> Private Mm1, Qq1 As Single
    <NonSerialized()> Private Mm2, Qq2 As Single
    <NonSerialized()> Private Mm3, Qq3 As Single
    <NonSerialized()> Private xa, ya As Single
    <NonSerialized()> Private xb, yb As Single
    <NonSerialized()> Private Lato, Distanza As Single
    <NonSerialized()> Private i As Short
    <NonSerialized()> Private Inizio, Fine As Short
    <NonSerialized()> Private Ret As New RoutBase1.clsVec3
    <NonSerialized()> Private Pun As New RoutBase1.clsVec2
    Public Overrides Property SpessBase() As Single
        Get
            Return prSpessBase
        End Get
        Set(ByVal Value As Single)
            prSpessBase = Value
        End Set
    End Property
    Public Overrides Property Dgran() As Single
        Get
            Return prDgran
        End Get
        Set(ByVal Value As Single)
            prDgran = Value
        End Set
    End Property
    Public Overrides Property Dpicc() As Single
        Get
            Return prDpicc
        End Get
        Set(ByVal Value As Single)
            prDpicc = Value
        End Set
    End Property
    Public Overrides Property Altezza() As Single
        Get
            Return prAltezza
        End Get
        Set(ByVal Value As Single)
            prAltezza = Value
        End Set
    End Property
    Sub CalSvilOid()
        'SUB CalSvilOid (TAGLIO, LATO01, LATO02, LATO11, LATO12, LATO21, LATO22, DELTA)
        '                  0        1      2       3       4       5       6      7
        '***SVILUPPO INTERO***
        'On Local Error GoTo ErrCSO
200:    x1 = p1.Punti0(0).X : y1 = p1.Punti0(0).y
        x2 = p1.Punti0(64).X : y2 = p1.Punti0(64).y
        x3 = P0.Punti0(64).X : y3 = P0.Punti0(64).y
        x4 = P0.Punti0(0).X : y4 = P0.Punti0(0).y
        RettPun()
211:    Cal(1) = Lato + Cal(0)
        Inizio = 0 : Fine = 64
        DistRet()
        Cal(2) = Lato + Cal(0)
        Ret.X = -Mm2 : Ret.y = 1 : Ret.Z = -y3 + Mm2 * x3
        Inizio = 0 : Fine = 32
        DistRet1()
221:    Cal(7) = Lato + Cal(0) - Cal(1)
        Cal(1) = Cal(1) + Cal(7)
        '***SVILUPPO PARTE SUPERIORE***
        x1 = p1.Punti0(0).X : y1 = p1.Punti0(0).y
        x2 = p1.Punti0(32).X : y2 = p1.Punti0(32).y
        x3 = P0.Punti0(32).X : y3 = P0.Punti0(32).y
        x4 = P0.Punti0(0).X : y4 = P0.Punti0(0).y
        RettPun()
        Cal(3) = Lato + Cal(0)
        Inizio = 0 : Fine = 32
        DistRet()
        Cal(4) = Lato + Cal(0)
        '***SVILUPPO PARTE INFERIORE***
        x1 = p1.Punti0(32).X : y1 = p1.Punti0(32).y
        x2 = p1.Punti0(64).X : y2 = p1.Punti0(64).y
        x3 = P0.Punti0(64).X : y3 = P0.Punti0(64).y
        x4 = P0.Punti0(32).X : y4 = P0.Punti0(32).y
        RettPun()
        Cal(5) = Lato + Cal(0)
        Inizio = 32 : Fine = 64
        DistRet()
        Cal(6) = Lato + Cal(0)
    End Sub
    '********************************************************************
    Private Sub RettPun()
        'CALCOLO DELLE COORDINATE DEL RETTANGOLO INSCRIVENTE I PUNTI
        'UPGRADE_WARNING: Return ha un nuovo comportamento. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1041"'
        If System.Math.Abs(x2 - x1) < 1 Then Return
        Mm1 = (y2 - y1) / (x2 - x1)
        Qq1 = y1 - Mm1 * x1
        Mm2 = -1 / Mm1
        Qq2 = y3 - Mm2 * x3
        Mm3 = Mm2
        Qq3 = y4 - Mm3 * x4
        xa = (Qq2 - Qq1) / (Mm1 - Mm2)
        ya = Mm1 * xa + Qq1
        xb = (Qq3 - Qq1) / (Mm1 - Mm3)
        yb = Mm1 * xb + Qq1
        Lato = System.Math.Sqrt((xb - xa) ^ 2 + (yb - ya) ^ 2)
    End Sub
    Private Sub DistRet1()
900:    Lato = 0
        On Error Resume Next
        For i = Inizio To Fine
            Pun.X = P0.Punti0(i).X : Pun.y = P0.Punti0(i).y
            Distanza = DistPunRet(Pun, Ret)
            If Distanza >= Lato Then Lato = Distanza
        Next i
        On Error GoTo 0
    End Sub
    'CALCOLO DISTANZA TRA UN PUNTO E UNA RETTA
    '*****************************************
    Private Sub DistRet()
        Lato = 0
        On Error Resume Next
        For i = Inizio To Fine
            Distanza = System.Math.Abs(((Mm1 * P0.Punti0(i).X) - P0.Punti0(i).y + Qq1) / System.Math.Sqrt(Mm1 ^ 2 + 1))
            If Distanza >= Lato Then Lato = Distanza
        Next i
        On Error GoTo 0
    End Sub

    Sub CalP0P1(ByRef Svil0 As Single, ByRef DS0() As Single, ByRef DS1() As Single)
        'DIM DS1(36) AS SINGLE, DS0(36) AS SINGLE, dist0(65) AS SINGLE, dist1(65) AS SINGLE
        'COSTRUZIONE VETTORE CONTENENTE LE DISTANZE DAL VERTICE DELLE GENERATRICI
        'IL VETTORE VA DA 1 A 65 CHE COINCIDE CON 1
        Dim dist0(65) As Single
        Dim dist1(65) As Single
        Dim CosBeta, TotBeta, Beta As Single
        Dim i, k As Short
        P0 = New RoutBase1.clsPunti : p1 = New RoutBase1.clsPunti
        P0.Inizia(65) : p1.Inizia(65)
        k = 15
        For i = 1 To 17
            dist0(i) = DS0(k + i) : dist1(i) = DS1(k + i)
        Next i
        k = 31
        For i = 18 To 49
            dist0(i) = DS0(k) : dist1(i) = DS1(k)
            k = k - 1
        Next i
        k = 1
        For i = 50 To 65
            dist0(i) = DS0(k) : dist1(i) = DS1(k)
            k = k + 1
        Next i
        'CALCOLO DELLE COORDINATE IN PIANO
        '*********************************
        'CON UNA SOLA SALDATURA IL VETTORE DISTANZE VA DA 1 A 65
        'CON 2 SALDATURE IL VETTORE PER LA LAMIERA DI SOPRA VA DA 1 A 29
        'CON 2 SALDATURE IL VETTORE PER LA LAMIERA DI SOTTO VA DA 29 A 65
        'I PUNTI ESTERNI VANNO DA P0(0) A P0(64)   0,32;32;64
        'I PUNTI INTERNI VANNO DA P1(0) A P1(64)
        TotBeta = 0
        For i = 1 To 64
            CosBeta = ((dist0(i) ^ 2 + dist0(i + 1) ^ 2 - Svil0 ^ 2) / (2 * dist0(i) * dist0(i + 1)))
            Beta = GlobalRoutines.acos(CosBeta)
            TotBeta = TotBeta + Beta
            P0.Punti0(i).X = dist0(i + 1) * System.Math.Cos(TotBeta)
            P0.Punti0(i).y = dist0(i + 1) * System.Math.Sin(TotBeta)
            p1.Punti0(i).X = dist1(i + 1) * System.Math.Cos(TotBeta)
            p1.Punti0(i).y = dist1(i + 1) * System.Math.Sin(TotBeta)
        Next i
        P0.Punti0(0).X = dist0(1)
        P0.Punti0(0).y = 0
        p1.Punti0(0).X = dist1(1)
        p1.Punti0(0).y = 0
    End Sub
    Sub CalOidCon()
        Dim RM, RM1 As Single
        Dim Cloc, Aloc, Bloc, det As Single
        Dim cosa As Single
        Dim H1, Alfa, H0 As Single
        If AlfaCon = 0 And Altezza = 0 Then Exit Sub
        Call Diametri(RM, RM1)
        If AlfaCon * Altezza > 0 Then Altezza = 0
        If AlfaCon = 0 Then
            Aloc = DM - DM1 - RM - RM1
            Bloc = RM + RM1
            Cloc = Altezza - PiedG - PiedP
            If RagG = 0 And RagP = 0 Then
                Aloc = Dgran - Dpicc
                Alfa = System.Math.Atan(Aloc / Altezza)
            Else
                det = Aloc * Aloc * Bloc * Bloc - (Aloc * Aloc + Cloc * Cloc) * (Bloc * Bloc - Cloc * Cloc)
                cosa = (-Aloc * Bloc + System.Math.Sqrt(det)) / (Aloc * Aloc + Cloc * Cloc)
                Alfa = GlobalRoutines.acos(cosa)
            End If
            AlfaCon = Alfa * 180 / PI
            'Else
            'End If                          '?????????????
            'cono di cui si conosce solo angolo
        ElseIf Altezza = 0 Then
            Alfa = AlfaCon * PI / 180
            If RagG = 0 And RagP = 0 Then
                Aloc = Dgran - Dpicc
                H1 = Aloc / System.Math.Tan(Alfa)
                Altezza = Int(H1 + PiedG + PiedP + 0.49)
            Else
                H1 = (DM - DM1 - (RM + RM1) * (1 - System.Math.Cos(Alfa))) / System.Math.Tan(Alfa)
                Altezza = H1 + (RM + RM1) * System.Math.Sin(Alfa) + PiedG + PiedP
            End If
        End If
4020:   H0 = RM * System.Math.Sin(Alfa)
        H1 = RM1 * System.Math.Sin(Alfa)
        DM01 = (DM - RM) + RM * System.Math.Cos(Alfa)
        DM11 = (DM1 + RM1) - RM1 * System.Math.Cos(Alfa)
        If RagG > 0 Or RagP > 0 Then
4021:       Altezza = (DM01 - DM11) / (System.Math.Tan(Alfa))
        End If
        DM0E = DM01 + (H0 + PiedG) * System.Math.Tan(Alfa)
        DM1E = DM11 - (H1 + PiedP) * System.Math.Tan(Alfa)
    End Sub
    Public Overrides Sub StringMATE()
        Dim M1, M0, Riga As String
        Dim i As Short
        Try
            M0 = GenMem.MaterNome(1).Trim
            If M0 = "" Then M0 = GenMem.Materiale.Trim
            If SpessRive <> 0 And GenMem.Classe2 = 2 Then
                M1 = GenMem.MaterNome(2).Trim
                Riga = M0 & " + " & M1
            Else 'hh
                Riga = M0
            End If
            If Len(Riga) < 30 Then Riga = Chr(32) & Riga & New String(Chr(32), 30 - Len(Riga)) & Chr(32) Else Riga = Chr(32) & Mid(Riga, 1, 30) & Chr(32)
            GenMem.Materiale = Riga
        Catch
        End Try
    End Sub
    Private Sub StringNOTE()
        If Fitting Then
            GenMem.Note = "Riduzione standard"
        Else
            Select Case System.Math.Abs(GenMem.Tipo)
                Case 7
                    GenMem.Note = "N°SETTORI" & Str(NumSpicchi) & " tipo trac." & Str(TipOPT)
                    'If Len(Riga) >= 32 Then Riga = Mid$(Riga, 1, 32) Else Riga = Riga + String$((32 - Len(Riga)), 32)
                Case 6
                    Select Case NumSal
                        Case 1 : GenMem.Note = "LAMIERA" & Str(Cal(1)) & " x" & Str(Cal(2)) & " x" & Str(SpessPar)
                        Case 2 : GenMem.Note = "da scrivere"
                    End Select
            End Select
        End If
    End Sub
    Public Sub Dati()
        IUNL = 6
        Membro = Me
        If FormDati Is Nothing Then FormDati = New frmDati
        FormDati.cmbTipo.Enabled = False
        FormDati.txtDen.Enabled = False
        FormDati.ShowDialog()
        Calcoli0()
        Membro = Nothing
    End Sub
    Public Overloads Sub leggi(ByVal DiscoR As String, ByVal Mode As Short)
        Select Case Mode
            Case 0
                If Not Variato Then Exit Sub
                Call Aggancio(DiscoR)
                Pesi()
                If IUNL < 5 Then GenMem.Leggiprezzi(Int(SpessPar - SpessRive), Int(SpessRive), 0)
                StringDIME()
                StringMATE()
                StringNOTE()
                If IUNL < 5 Then CalcGrezzi()
                Variato = False
                'Mode=0 ricalcolo,=1 editaggio
            Case 1
                Membro = Me
                FormDati.ShowDialog()
        End Select
        ' SalvaLav
    End Sub

    Public Sub CalcolCon() '(AlfaCC As Integer, a1 As Single, H1 As Single)
        Dim RM, RM1 As Single
        Dim Cloc, Aloc, Bloc, det As Single
        Dim Srm, Dcono0, cosa, Dcono1, Srm1 As Single
        Dim H1, Alfa, a1 As Single
        If AlfaCon = 0 And Altezza = 0 Then Exit Sub
        Call Diametri(RM, RM1)
        If AlfaCon * Altezza > 0 Then AlfaCon = 0
        If AlfaCon = 0 Then
            Aloc = (DM - DM1) / 2 - RM - RM1
            Bloc = RM + RM1
            Cloc = Altezza - PiedG - PiedP
            If RagG = 0 And RagP = 0 Then
                Aloc = (Dgran - Dpicc) / 2
                Alfa = System.Math.Atan(Aloc / Altezza)
            Else
                det = Aloc * Aloc * Bloc * Bloc - (Aloc * Aloc + Cloc * Cloc) * (Bloc * Bloc - Cloc * Cloc)
                If det > 0 Then
                    cosa = (-Aloc * Bloc + System.Math.Sqrt(det)) / (Aloc * Aloc + Cloc * Cloc)
                    Alfa = GlobalRoutines.acos(cosa)
                Else
                    Alfa = 30 * PI / 180
                End If
            End If
            AlfaCon = Alfa * 180 / PI
        Else
            Alfa = AlfaCon * PI / 180
        End If '?????????????
        'cono di cui si conosce solo angolo
        'ELSEIF Altezza = 0 THEN              '?????????????
        If RagG = 0 And RagP = 0 Then
            Aloc = (Dgran - Dpicc) / 2
            H1 = Aloc / System.Math.Tan(Alfa)
            Altezza = Int(H1 + PiedG + PiedP + 0.49)
        Else
            H1 = ((DM - DM1) / 2 - (RM + RM1) * (1 - System.Math.Cos(Alfa))) / System.Math.Tan(Alfa)
            Altezza = H1 + (RM + RM1) * System.Math.Sin(Alfa) + PiedG + PiedP
        End If
        'END IF                      '????????????
        'conosciamo angolo e altezza
        IpCon = (a1 / System.Math.Cos(PI / 2 - Alfa)) + RM * Alfa + RM1 * Alfa + PiedG + PiedP
        Dcono1 = (((DM1 / 2) + RM1) - RM1 * System.Math.Cos(Alfa)) * 2
        Dcono0 = (((DM / 2) - RM) + RM * System.Math.Cos(Alfa)) * 2
        Srm = RM * Alfa + PiedG
        Srm1 = RM1 * Alfa + PiedP
        DgCon = (Srm * System.Math.Cos(PI / 2 - Alfa)) * 2 + Dcono0
        DpCon = Dcono1 - (Srm1 * System.Math.Cos(PI / 2 - Alfa)) * 2
        'If Fitting Then Exit Sub
        'HE = ((DGCON - DPCONO) / 2) / TAN(ALFA!)
        Spicchiat.RG = (DgCon / 2) / System.Math.Sin(Alfa)
        Spicchiat.RP = (DpCon / 2) / System.Math.Sin(Alfa)
        'ALFAA! = DGCON / RG * PI
        Spicchiat.AlfaSvilCon = 2 * PI * System.Math.Sin(Alfa)
    End Sub
    Public Sub SovraMet()
        'Provvisorio
        SpessPar = SpessBase
    End Sub
    Public Overloads Function NumSpic(ByRef NumSpicchi As Short) As Short
        NumSpicchi = NumSpicGen(Formafuori, "Coni", 0, NumSpicchi)
        NumSpic = NumSpicchi
    End Function

    Public Sub Calcoli()
        Dim Alfa, dAlfa As Single
        Dim i As Short
        Dim z0, x0, y0, Svil0 As Single
        Dim y1, x1, z1 As Single
        Dim DS0(36) As Single
        Dim DS1(36) As Single
        If Fitting Then Exit Sub
        Select Case System.Math.Abs(GenMem.Tipo)
            Case 7
                If NumSpicchi = 0 Then NumSpicchi = 2
                If Editing And Not Caricamento Then
                    'NumSpicchi = NumSpicGen(Formafuori, "Coni", 0, NumSpicchi)
                End If
                Spicchiat = New Spicchi
                Spicchiat.SpessPar = SpessPar
                Spicchiat.NumSpicchi = NumSpicchi
                Spicchiat.PesoSp1 = GenMem.PesoSp1
                CalcolCon()
                If Not (AlfaCon = 0 And Altezza = 0) Then
                    'Ris = Spicchi.Spicchiatura(NumSpicchi, TipOPT)
                    Call Spicchiat.Ottimizza(NumSpicchi, TipOPT)
                End If
            Case 6
                CalOidCon()
                Alfa = AlfaCon * PI / 180
                If Alfa = 0 Then Exit Sub
                dAlfa = PI / 32 '5,625øin radianti uguale a uno svipluppo di 98 mm su í2000
                x1 = DM1E / System.Math.Tan(Alfa) 'x1 (1)
                x0 = DM0E / System.Math.Tan(Alfa) 'x0  (4)
4030:           For i = 0 To 32
4031:               y1 = DM1E / 2 * (1 - System.Math.Cos(dAlfa * i)) 'y1  (2)
                    y0 = DM0E / 2 * (1 - System.Math.Cos(dAlfa * i)) 'y0    (3)
                    z1 = DM1E / 2 * System.Math.Sin(dAlfa * i) 'z1         (5)
                    z0 = DM0E / 2 * System.Math.Sin(dAlfa * i) 'z0         (6)
4038:               DS1(i) = System.Math.Sqrt(x1 * x1 + y1 * y1 + z1 * z1)
4039:               DS0(i) = System.Math.Sqrt(x0 * x0 + y0 * y0 + z0 * z0)
                Next i
4040:           Svil0 = (DM0E / 2) * dAlfa 'SVI0! (8)
                '    SVI1! = (DM1E / 2) * xyz(7)     non  usato?
4042:           CalP0P1(Svil0, DS0, DS1)
                '            PUNTI SVILUPPO INTERO = P1(0),P0(0),P1(64),P0(64)
                '            PUNTI SVILUPPO PARTE SUPERIORE = P1(0),P0(0),P1(32),P0(32)
                '            PUNTI SVILUPPO PARTE INFERIORE = P1(32),P0(32),P1(64),P0(64)
                '    Classedim(0) = MargTag(TF, Classedim(0))
                Cal(0) = GenMem.TAGLIO
                CalSvilOid() ' Cal()
        End Select
    End Sub

    Public Overloads Sub Pesi()
        GenMem.LeggiMat((TipoMat))
        GenMem.PesiSp((TipoMat))
        SovraMet()
        GenMem.TAGLIO = GenMem.MargTag(SpessBase)
        Calcoli()
        If AlfaCon = 0 And Altezza = 0 Then Exit Sub
        Select Case System.Math.Abs(GenMem.Tipo)
            Case 7
                Select Case GenMem.Classe2
                    Case 9
                        GenMem.Pnet0 = (((DgCon + DpCon) / 2 * IpCon * PI) - AF) * SpessBase * GenMem.PesoSp1
                        'cono riportato senza riporto in un sol pezzo
                        GenMem.Pnet1 = (((DgCon + DpCon) / 2 * IpCon * PI) - AF) * SpessRive * GenMem.PesoSp2
                        'riporto su cono in un sol pezzo
                    Case Else
                        GenMem.Pnet0 = (((DgCon + DpCon) / 2 * IpCon * PI) - AF) * (SpessBase * GenMem.PesoSp1 + SpessRive * GenMem.PesoSp2)
                        'cono semplice o placato in un sol pezzo
                End Select
                If Fitting Then
                    GenMem.plor0 = GenMem.Pnet0
                Else
                    GenMem.plor0 = Spicchiat.SP(TipOPT + 1).peso
                End If
            Case 6
                Select Case GenMem.Classe2
                    Case 9
                        GenMem.Pnet0 = (((Dgran + Dpicc) / 2 * Altezza * PI) - AF) * SpessBase * GenMem.PesoSp1
                        'cono riportato senza riporto in un sol pezzo
                        GenMem.Pnet1 = (((Dgran + Dpicc) / 2 * Altezza * PI) - AF) * SpessRive * GenMem.PesoSp2
                        'riporto su cono in un sol pezzo
                    Case Else
                        GenMem.Pnet0 = (((Dgran + Dpicc) / 2 * Altezza * PI) - AF) * (SpessBase * GenMem.PesoSp1 + SpessRive * GenMem.PesoSp2)
                        'cono semplice o placato in un sol pezzo
                End Select
                PLLAM0 = CSng(Cal(1)) * Cal(2) * SpessPar * GenMem.PesoSp1 'PLLAM0
                PLLAM1 = CSng(Cal(3)) * Cal(4) * SpessPar * GenMem.PesoSp1 'PLLAM0
                PLLAM2 = CSng(Cal(5)) * Cal(6) * SpessPar * GenMem.PesoSp1 'PLLAM0
                If NumSal = 0 Then NumSal = 1
                Select Case NumSal
                    Case 1 : GenMem.plor0 = PLLAM0
                    Case 2 : GenMem.plor0 = PLLAM1 + PLLAM2
                End Select
        End Select
        GenMem.plor0 = GenMem.plor0 * EXP9
        GenMem.Pnet0 = GenMem.Pnet0 * EXP9
        GenMem.Psfri0 = GenMem.plor0 - GenMem.Pnet0
        'GenMem.Converti
        GenMem.PNET = GenMem.Pnet0
    End Sub

    Public Sub StringDIME()
        'If Classedim(1) = 9 Then D = D + 2 * T2: D1 = D1 + 2 * T2
        If SpessRive <> 0 And GenMem.Classe2 = 2 Then
            GenMem.Dimensioni = "Di" & Str(Dgran) & "/" & Str(Dpicc) & " sp." & Str(SpessBase) & "+" & Str(SpessRive) & " h." & Str(Altezza)
        Else
            GenMem.Dimensioni = "Di" & Str(Dgran) & "/" & Str(Dpicc) & " sp." & Str(SpessBase) & " h." & Str(Altezza)
        End If
        'If Len(DIME$) < 51 Then DIME$ = Chr$(32) + DIME$ + String$(51 - Len(DIME$), 32) + Chr$(32) Else DIME$ = Chr$(32) + Mid$(DIME$, 1, 51) + Chr$(32)
        'Rec2Buf(0).DIME = DIME$
    End Sub

    Public Overloads Sub CalcGrezzi()
        Dim grezzo As New clsGrezzo1
        If AlfaCon = 0 And Altezza = 0 Then Exit Sub
        GenMem.ClearGrezzi()
        GenMem.IniziaGrezzo(grezzo)
        If grezzo Is Nothing Then Exit Sub
        If Fitting Then
            Select Case System.Math.Abs(GenMem.Tipo)
                Case 7
                    grezzo.Vartxt(1) = "RIEC"
                Case 6
                    grezzo.Vartxt(1) = "RICO"
            End Select
            grezzo.Variab(1) = SpessBase
            grezzo.Variab(2) = Dgran
            grezzo.Variab(3) = Dpicc
            grezzo.Variab(4) = Altezza
            Exit Sub
        End If
        Select Case System.Math.Abs(GenMem.Tipo)
            Case 7
                grezzo.Variab(1) = SpessPar 'Spicchi.Tcal
                grezzo.Vartxt(1) = "SP  "
                grezzo.Variab(2) = Spicchiat.RG
                grezzo.Variab(3) = Spicchiat.RP
                grezzo.Dimens(4) = Spicchiat.AlfaSvilCon / Spicchiat.NumSpicchi
                grezzo.Variab(4) = TipOPT
                Select Case TipOPT
                    Case 0
                        grezzo.Dimens(1) = Spicchiat.SP(1).Rettn.Lung
                        grezzo.Dimens(2) = Spicchiat.SP(1).Rettn.LARG
                        grezzo.Dimens(3) = NumSpicchi 'N. quadri
                        grezzo.Variab(5) = NumSpicchi 'serve per ricalcolare
                    Case Else
                        grezzo.Dimens(1) = Spicchiat.SP(TipOPT + 1).Rettn.Lung
                        grezzo.Dimens(2) = Spicchiat.SP(TipOPT + 1).Rettn.LARG
                        grezzo.Dimens(3) = Spicchiat.SP(TipOPT + 1).Nquadri 'N. quadri
                        grezzo.Variab(5) = NumSpicchi 'serve per ricalcolare
                        If NumSpicchi > Spicchiat.SP(TipOPT + 1).Nquadri * Spicchiat.SP(TipOPT + 1).Nspicchi Then
                            GenMem.IniziaGrezzo(grezzo)
                            If grezzo Is Nothing Then Exit Sub
                            grezzo.Variab(1) = SpessPar 'Spicchi.Tcal
                            grezzo.Vartxt(1) = "SP  "
                            grezzo.Variab(2) = Spicchiat.RG
                            grezzo.Variab(3) = Spicchiat.RP
                            grezzo.Dimens(4) = Spicchiat.AlfaSvilCon / Spicchiat.NumSpicchi
                            grezzo.Dimens(1) = Spicchiat.SP(1).Rettn.Lung
                            grezzo.Dimens(2) = Spicchiat.SP(1).Rettn.LARG
                            grezzo.Dimens(3) = 1 'n. quadri
                            grezzo.Variab(4) = 0
                            grezzo.Variab(5) = NumSpicchi 'serve per ricalcolare l'angolo
                        End If
                End Select
            Case 6
                grezzo.Variab(1) = SpessPar
                grezzo.Vartxt(1) = "OID "
                Select Case NumSal
                    Case 1
                        grezzo.Dimens(1) = Cal(1)
                        grezzo.Dimens(2) = Cal(2)
                        grezzo.Dimens(3) = 1 'N. quadri
                        grezzo.Variab(2) = 0 ' Tipo intero
                    Case 2
                        grezzo.Dimens(1) = Cal(3)
                        grezzo.Dimens(2) = Cal(4)
                        grezzo.Dimens(3) = 1 'N.quadri
                        grezzo.Variab(2) = 1
                        GenMem.IniziaGrezzo(grezzo)
                        If grezzo Is Nothing Then Exit Sub
                        grezzo.Variab(1) = SpessPar
                        grezzo.Vartxt(1) = "OID "
                        grezzo.Dimens(1) = Cal(5)
                        grezzo.Dimens(2) = Cal(6)
                        grezzo.Dimens(3) = 1 'N.quadri
                        grezzo.Variab(2) = 2
                End Select
        End Select
        Select Case TipoMat
            Case 3 ' WO
                GenMem.IniziaGrezzo(grezzo)
                If grezzo Is Nothing Then Exit Sub
                grezzo.Vartxt(1) = "WO  "
                GenMem.WOGrezzo(grezzo)
        End Select
    End Sub

    Private Sub Diametri(ByRef RM As Single, ByRef RM1 As Single)
        Select Case TipoMat
            Case 1
                DM = Dgran + SpessBase
                DM1 = Dpicc + SpessBase
                RM = RagG + SpessBase / 2
                RM1 = RagP + SpessBase / 2
            Case Else
                DM = Dgran + SpessBase + SpessRive
                DM1 = Dpicc + SpessBase + SpessRive
                RM = RagG + (SpessBase + SpessRive) / 2
                RM1 = RagP + (SpessBase + SpessRive) / 2
        End Select

    End Sub
    Public Sub New()
        MyBase.New()
        GenMem = New clsGenMem
        GenMem.Parent = Me
        Variato = True
        StandardG = New LibMat.clsPipe
        StandardP = New LibMat.clsPipe
    End Sub
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
    Public Overloads Sub Copia(ByRef a As Cono)
        If a Is Nothing Then a = New Cono
        a.AF = AF
        a.Dgran = Dgran
        a.Dpicc = Dpicc
        a.PiedG = PiedG
        a.PiedP = PiedP
        a.RagG = RagG
        a.RagP = RagP
        a.Altezza = Altezza
        a.AlfaCon = AlfaCon
        a.SpessBase = SpessBase
        a.SpessRive = SpessRive
        a.SpessPar = SpessPar
        a.NumSpicchi = NumSpicchi
        a.NumSal = NumSal
        a.TipoMat = TipoMat
        a.TipOPT = TipOPT
        a.Fitting = Fitting
        '----------------------
        GenMem.Copia(a.GenMem)
        a.GenMem.Parent = a
        If GenMem.Tipo = 7 Then
            If a.Spicchiat Is Nothing Then
                a.Spicchiat = New Spicchi
                a.Spicchiat.SpessPar = SpessPar
                a.Spicchiat.NumSpicchi = NumSpicchi
                a.Spicchiat.PesoSp1 = GenMem.PesoSp1
            End If
            If Spicchiat Is Nothing Then
                Spicchiat = New Spicchi
                Spicchiat.SpessPar = SpessPar
                Spicchiat.NumSpicchi = NumSpicchi
                Spicchiat.PesoSp1 = GenMem.PesoSp1
            End If
            Spicchiat.Copia(a.Spicchiat)
        End If
    End Sub

    Public Sub Calcoli0()
        Select Case GenMem.Tipo
            Case 6 : CalOidCon()
            Case 7
                If Spicchiat Is Nothing Then
                    Spicchiat = New Spicchi
                    Spicchiat.SpessPar = SpessPar
                    Spicchiat.NumSpicchi = NumSpicchi
                    Spicchiat.PesoSp1 = GenMem.PesoSp1
                End If
                CalcolCon()
        End Select

    End Sub
    'SUB ShowOid (L01, L02, L11, L12, L21, L22, DELTA, PLLAM0, PLLAM1, PLLAM2, NSAL)
    '             1    2    3   4     5    6    7             Sc
    Public Function ShowOid(ByRef NSAL As Short, Optional ByRef SubRect As RoutBase1.Rettangolo = Nothing) As Short
        Dim Rett As New OggList(0)
        Dim R As RoutBase1.Rettangolo
        'Dim Ext0(0 To 64) As Vec2, Int0(0 To 64) As Vec2
        'Dim Ext1(0 To 32) As Vec2, Int1(0 To 32) As Vec2
        'Dim Ext2(32 To 64) As Vec2, Int2(32 To 64) As Vec2
        Dim Ext0 As New RoutBase1.clsPunti
        Dim Int0 As New RoutBase1.clsPunti
        Dim Ext1 As New RoutBase1.clsPunti
        Dim Int1 As New RoutBase1.clsPunti
        Dim Ext2 As New RoutBase1.clsPunti
        Dim Int2 As New RoutBase1.clsPunti
        Dim xSmin, ySmin As Single
        Dim xSmax, ySmax As Single
        Dim Rq, Distq, Rgq As Single
        Dim Rotaz, Theta, Theta1 As Single
        Dim Theta2 As Single
        Dim i, k As Short
        Dim TAGLIO As Single
        Ext0.Inizia(66)
        Int0.Inizia(66)
        Ext1.Inizia(34)
        Int1.Inizia(34)
        Ext2.Inizia(66)
        Int2.Inizia(66)
        If NSAL = 0 Then
            R = SubRect
        Else
            R = New RoutBase1.Rettangolo
            R.MakeCorners((Cal(1)), (Cal(2)))
        End If
        Rett.Add(R)
        If NSAL = 1 Then
            R = SubRect
        Else
            R = New RoutBase1.Rettangolo
            R.MakeCorners((Cal(3)), (Cal(4)))
        End If
        Rett.Add(R)
        If NSAL = 2 Then
            R = SubRect
        Else
            R = New RoutBase1.Rettangolo
            R.MakeCorners((Cal(5)), (Cal(6)))
        End If
        Rett.Add(R)
        If NSAL = -1 Then
            xSmin = Rett(1).x(1)
            ySmin = Rett(1).y(1)
            For i = 2 To 3
                For k = 1 To 4
                    Rett(i).x(k) = Rett(i).x(k) + (Rett(1).LARG + Rett(2).LARG)
                Next k
            Next i
            For k = 1 To 4
                Rett(3).y(k) = Rett(3).y(k) + Rett(2).Lung + 50
            Next k
            xSmax = Rett(3).x(3)
            ySmax = Rett(3).y(3)
        End If
        Distq = (p1.Punti0(0).X - p1.Punti0(32).X) ^ 2 + (p1.Punti0(0).y - p1.Punti0(32).y) ^ 2
        Rq = p1.Punti0(0).X ^ 2 + p1.Punti0(0).y ^ 2
        Rgq = P0.Punti0(0).X ^ 2 + P0.Punti0(0).y ^ 2
        Theta = GlobalRoutines.acos(1 - Distq / 2 / Rq)
        Rotaz = -Theta / 2
        TAGLIO = GenMem.TAGLIO
        For i = 0 To 32
            Ext1.Punti0(i).X = P0.Punti0(i).X * System.Math.Cos(Rotaz) - P0.Punti0(i).y * System.Math.Sin(Rotaz) + Rett(2).x(1) - System.Math.Sqrt(Rq) * System.Math.Cos(Rotaz) + TAGLIO / 2
            Int1.Punti0(i).X = p1.Punti0(i).X * System.Math.Cos(Rotaz) - p1.Punti0(i).y * System.Math.Sin(Rotaz) + Rett(2).x(1) - System.Math.Sqrt(Rq) * System.Math.Cos(Rotaz) + TAGLIO / 2
            If NSAL > -1 Then
                Ext1.Punti0(i).y = P0.Punti0(i).X * System.Math.Sin(Rotaz) + P0.Punti0(i).y * System.Math.Cos(Rotaz) + Rett(2).y(1) - System.Math.Sqrt(Rgq) * System.Math.Sin(Rotaz) + TAGLIO / 2
                Int1.Punti0(i).y = p1.Punti0(i).X * System.Math.Sin(Rotaz) + p1.Punti0(i).y * System.Math.Cos(Rotaz) + Rett(2).y(1) - System.Math.Sqrt(Rgq) * System.Math.Sin(Rotaz) + TAGLIO / 2
            Else
                Ext1.Punti0(i).y = P0.Punti0(i).X * System.Math.Sin(Rotaz) + P0.Punti0(i).y * System.Math.Cos(Rotaz) - System.Math.Sqrt(Rgq) * System.Math.Sin(Rotaz) + TAGLIO / 2
                Int1.Punti0(i).y = p1.Punti0(i).X * System.Math.Sin(Rotaz) + p1.Punti0(i).y * System.Math.Cos(Rotaz) - System.Math.Sqrt(Rgq) * System.Math.Sin(Rotaz) + TAGLIO / 2
            End If
        Next i
        Distq = (p1.Punti0(32).X - p1.Punti0(64).X) ^ 2 + (p1.Punti0(32).y - p1.Punti0(64).y) ^ 2
        Theta1 = GlobalRoutines.acos(1 - Distq / 2 / Rq)
        Rotaz = -Theta - Theta1 / 2
        For i = 32 To 64
            Ext2.Punti0(i).X = P0.Punti0(i).X * System.Math.Cos(Rotaz) - P0.Punti0(i).y * System.Math.Sin(Rotaz) + Rett(3).x(1) - System.Math.Sqrt(Rq) * System.Math.Cos(-Theta1 / 2) + TAGLIO / 2
            Int2.Punti0(i).X = p1.Punti0(i).X * System.Math.Cos(Rotaz) - p1.Punti0(i).y * System.Math.Sin(Rotaz) + Rett(3).x(1) - System.Math.Sqrt(Rq) * System.Math.Cos(-Theta1 / 2) + TAGLIO / 2
            If NSAL > -1 Then
                Ext2.Punti0(i).y = P0.Punti0(i).X * System.Math.Sin(Rotaz) + P0.Punti0(i).y * System.Math.Cos(Rotaz) + Rett(3).y(1) - System.Math.Sqrt(Rgq) * System.Math.Sin(-Theta1 / 2) + TAGLIO / 2 '+ Rett(3).y(1)
                Int2.Punti0(i).y = p1.Punti0(i).X * System.Math.Sin(Rotaz) + p1.Punti0(i).y * System.Math.Cos(Rotaz) + Rett(3).y(1) - System.Math.Sqrt(Rgq) * System.Math.Sin(-Theta1 / 2) + TAGLIO / 2 '+ Rett(3).y(1)
            Else
                Ext2.Punti0(i).y = P0.Punti0(i).X * System.Math.Sin(Rotaz) + P0.Punti0(i).y * System.Math.Cos(Rotaz) - System.Math.Sqrt(Rgq) * System.Math.Sin(-Theta1 / 2) + Rett(3).y(1) + TAGLIO / 2
                Int2.Punti0(i).y = p1.Punti0(i).X * System.Math.Sin(Rotaz) + p1.Punti0(i).y * System.Math.Cos(Rotaz) - System.Math.Sqrt(Rgq) * System.Math.Sin(-Theta1 / 2) + Rett(3).y(1) + TAGLIO / 2
            End If
        Next i
        Theta2 = GlobalRoutines.acos(System.Math.Sqrt(((p1.Punti0(0).X - p1.Punti0(64).X) ^ 2 + (p1.Punti0(0).y - p1.Punti0(64).y) ^ 2) / Rq) / 2)
        Rotaz = -PI / 2 + Theta2
        For i = 0 To 64
            Ext0.Punti0(i).X = P0.Punti0(i).X * System.Math.Cos(Rotaz) - P0.Punti0(i).y * System.Math.Sin(Rotaz) + Rett(1).x(1) - System.Math.Sqrt(Rq) * System.Math.Cos(Rotaz) + TAGLIO / 2
            Int0.Punti0(i).X = p1.Punti0(i).X * System.Math.Cos(Rotaz) - p1.Punti0(i).y * System.Math.Sin(Rotaz) + Rett(1).x(1) - System.Math.Sqrt(Rq) * System.Math.Cos(Rotaz) + TAGLIO / 2
            If NSAL > -1 Then
                Ext0.Punti0(i).y = P0.Punti0(i).X * System.Math.Sin(Rotaz) + P0.Punti0(i).y * System.Math.Cos(Rotaz) + Rett(1).y(1) - System.Math.Sqrt(Rgq) * System.Math.Sin(Rotaz) + TAGLIO / 2 + Cal(7)
                Int0.Punti0(i).y = p1.Punti0(i).X * System.Math.Sin(Rotaz) + p1.Punti0(i).y * System.Math.Cos(Rotaz) + Rett(1).y(1) - System.Math.Sqrt(Rgq) * System.Math.Sin(Rotaz) + TAGLIO / 2 + Cal(7)
            Else
                Ext0.Punti0(i).y = P0.Punti0(i).X * System.Math.Sin(Rotaz) + P0.Punti0(i).y * System.Math.Cos(Rotaz) - System.Math.Sqrt(Rgq) * System.Math.Sin(Rotaz) + TAGLIO / 2 + Cal(7)
                Int0.Punti0(i).y = p1.Punti0(i).X * System.Math.Sin(Rotaz) + p1.Punti0(i).y * System.Math.Cos(Rotaz) - System.Math.Sqrt(Rgq) * System.Math.Sin(Rotaz) + TAGLIO / 2 + Cal(7)
            End If
        Next i
        If NSAL = -1 Then
            Funzioni.DisRut.Scala(xSmin - (xSmax - xSmin) / 20, xSmax + (xSmax - xSmin) / 20, ySmin - (ySmax - ySmin) / 20, ySmax + (ySmax - ySmin) / 20)
            For i = 1 To 3
                Rett(i).RettGraf(Funzioni.DisRut, 1)
            Next
        End If
        If NSAL = -1 Or NSAL = 0 Then
            Int0.Punti0(64).copia(Ext0.Punti0(65))
            Ext0.SpezzGraf(0, 65, Funzioni.DisRut)
            'Ext0.Punti0(64).Copia Int0.Punti0(65)
            Int0.SpezzGraf(0, 64, Funzioni.DisRut)
            Funzioni.DisRut.tratto((Int0.Punti0(0).X), (Int0.Punti0(0).y), (Ext0.Punti0(0).X), (Ext0.Punti0(0).y), 0.1, 0)
        End If
        '----------------------------------------------------------
        If NSAL = -1 Or NSAL = 1 Then
            Int1.Punti0(32).copia(Ext1.Punti0(33))
            Ext1.SpezzGraf(0, 33, Funzioni.DisRut)
            'Ext1.Punti0(32).Copia Int1.Punti0(33)
            Int1.SpezzGraf(0, 32, Funzioni.DisRut)
            Funzioni.DisRut.tratto((Int1.Punti0(0).X), (Int1.Punti0(0).y), (Ext1.Punti0(0).X), (Ext1.Punti0(0).y), 0.1, 0)
        End If
        '-------------------------------------------------------------------------
        If NSAL = -1 Or NSAL = 2 Then
            Int2.Punti0(64).copia(Ext2.Punti0(65))
            Ext2.SpezzGraf(32, 65, Funzioni.DisRut)
            'Int2.Punti0(32).Copia Int0.Punti0(65)
            Int2.SpezzGraf(32, 64, Funzioni.DisRut)
            Funzioni.DisRut.tratto((Int2.Punti0(32).X), (Int2.Punti0(32).y), (Ext2.Punti0(32).X), (Ext2.Punti0(32).y), 0.1, 0)
        End If
        '--------------------------------------------------------------------------
    End Function

    Public Overrides Sub Mostrasviluppi()
        Dim Ris As Short
        Dim Stringa1(14) As String
        If Fitting Then Exit Sub
        Funzioni.DisRut.DoveDisegno = frmShowForm.DefInstance.pctForm
        Select Case GenMem.Tipo
            Case 6
                Ris = ShowOid(-1)
                With frmShowForm.DefInstance
                    .TabStrip1.Visible = False
                    .Text = "Lamieramento " & GenMem.Denom
                    .framOid.Visible = True
                    .framSpicchi.Visible = False
                    .txtOid(0).Text = GlobalRoutines.FormatS("SVIL.INTERO##### x ##### mm; ####### Kg", Cal(1), Cal(2), PLLAM0 * EXP9)
                    .txtOid(1).Text = GlobalRoutines.FormatS("SVIL.SUP.  ##### x ##### mm; ####### Kg", Cal(3), Cal(4), PLLAM1 * EXP9)
                    .txtOid(2).Text = GlobalRoutines.FormatS("SVIL.INF.  ##### x ##### mm; ####### Kg", Cal(5), Cal(6), PLLAM2 * EXP9)
                    .txtOid(3).Text = GlobalRoutines.FormatS("PESO TOTALE CON UNA SALDATURA####### Kg", PLLAM0 * EXP9)
                    .txtOid(4).Text = GlobalRoutines.FormatS("PESO TOTALE CON DUE SALDATURE####### Kg", PLLAM1 * EXP9 + PLLAM2 * EXP9)
                    .txtNumSal.Text = Str(NumSal)
                    .ShowDialog()
                    NumSal = Val(.txtNumSal.Text)
                End With
            Case 7
                If Spicchiat.SP(1).Nspicchi = 0 Then 'And k$ = "S" Then
                    '      a$ = " Il cono e' troppo grande per essere | realizzato senza saldature cir-|"
                    ' a$ = a$ + " conferenziali intermedie. Suddivide-| re il cono in piu' tronconi.   |"
                    MostraAiuto(IDHG.IDH_ERR_CONOGRANDE)
                    Exit Sub
                End If
                If NumSpicchi > 1 Then ShowLam((Spicchiat), 5, TipOPT)
                If NumSpicchi = 1 Then TipOPT = 0 : ShowLam((Spicchiat), 0, TipOPT)
                Spicchiat.Risultati(Stringa1)
                With frmShowForm.DefInstance
                    .ShowDialog()
                    Ris = .Risult
                End With
                If Ris > 0 Then TipOPT = Ris
                GenMem.plor0 = Spicchiat.SP(TipOPT + 1).peso * EXP9
                GenMem.Psfri0 = GenMem.plor0 - GenMem.Pnet0
        End Select
        CalcGrezzi()
        Funzioni.DisRut.DoveDisegno = Nothing ' frmDistinta.pictAssieme
        frmShowForm.DefInstance.Dispose()
    End Sub
    Public Overrides Property Spessore() As Single
        Get
            Spessore = SpessBase + SpessRive
        End Get
        Set(ByVal Value As Single)

        End Set
    End Property
    'Sub FormOid(Classedim() As Integer, NSAL, iLam, Quadro As LamQuadr, Scal!, offx!, offy!)
    'Dim Rett(0 To 2) As rectang
    'MakeCorners Rett(0), CSng(Classedim(1)), CSng(Classedim(2))
    'MakeCorners Rett(1), CSng(Classedim(3)), CSng(Classedim(4))
    'MakeCorners Rett(2), CSng(Classedim(5)), CSng(Classedim(6))
    'For k = 1 To 4
    '  Rett(2).Corners(k).y = Rett(2).Corners(k).y + Rett(1).Lung + 50
    'Next k
    'Dim Ext0(0 To 64) As Vec2, Int0(0 To 64) As Vec2
    'Select Case NSAL
    '   Case 0
    '     Iniz = 0: Ifin = 64
    '   Case 1
    '     Iniz = 0: Ifin = 32
    '   Case 2
    '     Iniz = 32: Ifin = 64
    'End Select
    '     Rq! = p1(0).x ^ 2 + p1(0).y ^ 2
    '     Rgq! = P0(0).x ^ 2 + P0(0).y ^ 2
    '     Rq0! = p1(0).x ^ 2 + p1(0).y ^ 2
    '     Rq1! = p1(32).x ^ 2 + p1(32).y ^ 2
    '     Rq2! = p1(0).x ^ 2 + p1(0).y ^ 2
    '     Distq0! = (p1(0).x - p1(32).x) ^ 2 + (p1(0).y - p1(32).y) ^ 2
    '     Distq1! = (p1(32).x - p1(64).x) ^ 2 + (p1(32).y - p1(64).y) ^ 2
    '     Distq2! = (p1(0).x - p1(64).x) ^ 2 + (p1(0).y - p1(64).y) ^ 2
    '     Theta! = acos(1 - Distq0! / 2 / Rq0!)
    '     Theta1! = acos(1 - Distq1! / 2 / Rq0!)
    '     Theta2! = acos(Sqr(Distq2! / Rq2!) / 2)
    '     Select Case NSAL
    '        Case 0
    'Rotaz! = -Pi / 2 + Theta2!: Rotaz1! = Rotaz!
    '        Case 1
    'Rotaz! = -Theta! / 2: Rotaz1! = Rotaz!
    '        Case 2
    'Rotaz! = -Theta! - Theta1! / 2: Rotaz1! = -Theta1! / 2
    '     End Select
    '     For i = Iniz To Ifin
    '       Ext0(i).x = P0(i).x * Cos(Rotaz!) - P0(i).y * Sin(Rotaz!) + Rett(NSAL).Corners(1).x - Sqr(Rq!) * Cos(Rotaz1!) + TAGLIO / 2
    '       Int0(i).x = p1(i).x * Cos(Rotaz!) - p1(i).y * Sin(Rotaz!) + Rett(NSAL).Corners(1).x - Sqr(Rq!) * Cos(Rotaz1!) + TAGLIO / 2
    '       Ext0(i).y = P0(i).x * Sin(Rotaz!) + P0(i).y * Cos(Rotaz!) - Sqr(Rgq!) * Sin(Rotaz1!) + TAGLIO / 2 + Rett(NSAL).Corners(1).y
    '       Int0(i).y = p1(i).x * Sin(Rotaz!) + p1(i).y * Cos(Rotaz!) - Sqr(Rgq!) * Sin(Rotaz1!) + TAGLIO / 2 + Rett(NSAL).Corners(1).y
    '     Next i
    '   For k = Iniz To Ifin
    '       Ext0(k).x = (Ext0(k).x + Quadro.TopLeft.x + TAGLIO + (Quadro.Botrigt.x - Quadro.TopLeft.x - 2 * TAGLIO - Lamiere(iLam).LARG) / 2) * Scal! + offx!
    '       Ext0(k).y = (Ext0(k).y + Quadro.TopLeft.y + TAGLIO) * Scal! + offy!
    '       Int0(k).x = (Int0(k).x + Quadro.TopLeft.x + TAGLIO + (Quadro.Botrigt.x - Quadro.TopLeft.x - 2 * TAGLIO - Lamiere(iLam).LARG) / 2) * Scal! + offx!
    '       Int0(k).y = (Int0(k).y + Quadro.TopLeft.y + TAGLIO) * Scal! + offy!
    '   Next k
    'PSet (Int(Ext0(Iniz).x), Int(Ext0(Iniz).y))
    'For i = Iniz + 1 To Ifin
    'Line -(Int(Ext0(i).x), Int(Ext0(i).y))
    'Next i
    'Line -(Int(Int0(Ifin).x), Int(Int0(Ifin).y))
    'PSet (Int(Int0(Iniz).x), Int(Int0(Iniz).y))
    'For i = Iniz + 1 To Ifin
    'Line -(Int(Int0(i).x), Int(Int0(i).y))
    'Next i
    'Line (Int(Int0(Iniz).x), Int(Int0(Iniz).y))-(Int(Ext0(Iniz).x), Int(Ext0(Iniz).y))
    'End Sub

    Public Overrides Property Code7() As Short
        Get
            Code7 = 0 'If GenMem.Classe1 = 7 Then Code7 = 2 Else Code7 = 0
        End Get
        Set(ByVal Value As Short)

        End Set
    End Property
    Public Overrides Property Param1() As Single
        Get
            Param1 = Spessore
        End Get
        Set(ByVal Value As Single)

        End Set
    End Property
End Class