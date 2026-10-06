Option Strict Off
Option Explicit On
Imports System.math
Public Class clsTeor
    Private De, Di As Single
    Private Control As Short
    Private Errato As Short
    Private Alfa As Single 'calettamento al tip
    Private Alfat As Single 'angolo tra livella e normale al bordo di entrata
    Private Alfas As Single 'angolo tra corda e normale al bordo di entrata
    'UPGRADE_WARNING: È possibile che si debba inizializzare le matrici nella struttura Table4 prima di poterle utilizzare. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
    Private Table4 As dao.Recordset
    'UPGRADE_WARNING: È possibile che si debba inizializzare le matrici nella struttura Table5 prima di poterle utilizzare. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
    Private Table5 As dao.Recordset
    'UPGRADE_WARNING: È possibile che si debba inizializzare le matrici nella struttura Table6 prima di poterle utilizzare. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
    Private Table6 As dao.Recordset
    Private Spinta, Dhub, V1 As Single
    Private IncrPress, PressStat, PressFin As Single
    Private PressMin, PressMax As Single
    Private PressDyn, etaDyn As Single
    Private Num1, Stot, Num2 As Single
    Private Selem As Single 'superficie elementare
    Private Qsonda As Single ' portata in m3/sec
    Private Area, Torque, Raggio As Single
    Private kW, Forza As Single
    Private iC As Short
    Private Pot As Single
    Private AlfaMax, etastat, IncrAlfa As Single
    'UPGRADE_WARNING: È possibile che si debba inizializzare le matrici nella struttura Dati prima di poterle utilizzare. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
    Private AlfaMin As Single
    Private Dati As BufMath
    'UPGRADE_WARNING: Il limite inferiore della matrice Beta è stato cambiato da 1 a 0. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
    Private Beta(10) As Single 'angolo del triangolo di velocità
    'UPGRADE_WARNING: Il limite inferiore della matrice gamma è stato cambiato da 1 a 0. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
    Private gamma(10) As Single 'angolo di attacco
    'UPGRADE_WARNING: Il limite inferiore della matrice vax è stato cambiato da 1 a 0. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
    Private vax(10) As Single 'velocità assiali
    'UPGRADE_WARNING: Il limite inferiore della matrice vom è stato cambiato da 1 a 0. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
    Private vom(10) As Single 'velocità periferiche
    'UPGRADE_WARNING: Il limite inferiore della matrice facta è stato cambiato da 1 a 0. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
    Private facta(10) As Single
    'UPGRADE_WARNING: Il limite inferiore della matrice factb è stato cambiato da 1 a 0. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
    Private factb(10) As Single
    'UPGRADE_WARNING: Il limite inferiore della matrice factp è stato cambiato da 1 a 0. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
    Private factp(10) As Single
    Private uind, Vinf, aind As Single
    'UPGRADE_WARNING: Il limite inferiore della matrice cL è stato cambiato da 1 a 0. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
    Private cL(10) As Single
    Private PressStat1 As Single
    'UPGRADE_WARNING: Il limite inferiore della matrice cD è stato cambiato da 1 a 0. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
    Private cD(10) As Single
    'UPGRADE_WARNING: Il limite inferiore della matrice Tq è stato cambiato da 1 a 0. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
    'UPGRADE_WARNING: Il limite inferiore della matrice SP è stato cambiato da 1 a 0. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
    'UPGRADE_WARNING: Il limite inferiore della matrice Thrust è stato cambiato da 1 a 0. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
    Private Thrust(10) As Single
    Private SP(10) As Single
    Private Tq(10) As Single
    Private vmax(10) As Single
    Private PMAX(10) As Single
    Private Function Calcola() As Short
        Dim i As Short
        Dim Errore, Err1 As Single
        Dim Errv(10) As Single
        Dim Codice As Short
        Dim icm As Short
        Dim fact, Errvec As Single
        icm = 0
        Codice = 0
        'inizio ricerca soluzione: velocità assiali nei tubi di flusso
        Do
            icm = icm + 1
            iC = 0
            Do
                Calcbeta()
                Calcgamma()
                CalcLiftDrag()
                Errore = 0
                For i = 1 To 10
                    Err1 = -(PressStat - SP(i)) / PressStat
                    If System.Math.Abs(Err1) > Errore Then Errore = System.Math.Abs(Err1)
                    If System.Math.Abs(Err1) > System.Math.Abs(Errv(i)) And System.Math.Abs(Err1) > 0.001 And iC > 50 Then
                        Codice = 1
                        Exit Do
                    End If
                    vax(i) = vax(i) + fact * Err1 / 5
                    Errv(i) = Err1
                Next i
                '        Debug.Print "Errore", Errore
                If Errvec - Errore > 0 Then
                    fact = System.Math.Sqrt(System.Math.Abs(Errore / (Errvec - Errore)))
                Else
                    fact = 1
                End If
                Errvec = Errore
                If Errore < 0.0001 Then Exit Do
                iC = iC + 1
                If iC > 150 Then Codice = 2 : Exit Do
            Loop
            If Errore < 0.0001 Then Exit Do
            If icm > 20 Then Codice = 3 : Exit Do
        Loop While Codice > 0
        'potenza all'asse
        kW = Torque * RPM / 60 * 2 * PI / 1000
        'velocità dell'aria nei trafilamenti al gioco
        uind = System.Math.Sqrt(2 / 1.5 * PressStat * Dens)
        'sezione di passaggio trafilamenti
        aind = 0.005 * Diam ^ 2 * 2 / 1000000.0#
        'portata utile ventilatore
        Qsonda = Qsonda - aind * uind
        'potenza aeraulica statica
        Pot = PressStat * Qsonda / 1000
        'rendimento statico
        etastat = Pot / kW
        'sezione retta della portata utile
        Stot = Diam ^ 2 * PI / 4 / 1000000.0#
        'velocità assiale media
        uind = Qsonda / Stot
        ' pressione dinamica
        PressDyn = 1.2 * uind * uind / 2
        'potenza aeraulica totale
        Pot = (PressStat + PressDyn) * Qsonda / 1000
        'rendimento totale
        etaDyn = Pot / kW
        If Codice = 3 Then Stop
    End Function
    Private Function CalcolaN() As Short
        Dim Error2, Error1, Error3 As Single
        Dim Qsondav As Single
        Dim Spintav, Errvec, Torquev As Single
        CalcolaN = True
        Do
            'inizio ricerca soluzione: velocità assiali nei tubi di flusso
            iC = 6
            Do
                CalcbetaN()
                Calcgamma()
                If Not CalcLiftDragN(iC) Then
                    CalcolaN = False
                    Exit Function
                End If
                Error1 = System.Math.Abs((Spinta - Spintav) / Spinta)
                Error2 = System.Math.Abs((Torque - Torquev) / Torque)
                Error3 = System.Math.Abs((Qsonda - Qsondav) / Qsonda)
                Torquev = Torque
                Spintav = Spinta
                Qsondav = Qsonda
                Errvec = Error3
                If Error1 < 0.01 And Error3 < 0.01 Then Exit Do
                iC = iC + 1
                If iC > 150 Then
                    CalcolaN = False
                    MsgBox("non trovata soluzione stabile")
                    Exit Function
                End If
            Loop
            'potenza all'asse
            kW = Torque * RPM / 60 * 2 * PI / 1000
            'velocità dell'aria nei trafilamenti al gioco
            '    PressStat = 0
            uind = System.Math.Sqrt(2 / 1.5 * PressStat * Dens)
            'sezione di passaggio trafilamenti
            aind = 0.005 * Diam ^ 2 * 2 / 1000000.0#
            'portata utile ventilatore
            Qsonda = Qsonda - aind * uind
            'sezione retta della portata utile
            Stot = Diam ^ 2 * PI / 4 / 1000000.0#
            PressStat1 = Spinta / Stot 'non ha niente a che vedere co la pressione statica
            'potenza aeraulica statica
            Pot = PressStat * Qsonda / 1000
            'rendimento statico
            etastat = Pot / kW
            'velocità assiale media
            uind = Qsonda / Stot
            ' pressione dinamica
            PressDyn = Dens * uind * uind / 2
            'potenza aeraulica totale
            Pot = (PressStat + PressDyn) * Qsonda / 1000
            'rendimento totale
            etaDyn = Pot / kW
            If System.Math.Abs((uind - Vinf) / Vinf) < 0.001 Then Exit Do
            'Alfa = 5
            'PressStat = 60
            Vinf = (uind + Vinf) / 2
            'Vinf = 2
        Loop
    End Function
    Private Function CalcolaN1() As Short
        Dim i As Short
        Dim Error2, Error1, Error3 As Single
        Dim Qsondav As Single
        Dim Spintav, Errvec, Torquev As Single
        CalcolaN1 = True
        Do
            'inizio ricerca soluzione: velocità assiali nei tubi di flusso
            iC = 6
            Do
                'area dell'elemento di pala per il n° di pale nel piano della corda
                Selem = (Diam - Dhub) / 2 / 10 * corda * Npal / 1000000.0#
                'sommatoria delle portate
                Qsonda = 0
                'sommatoria delle coppie
                Torque = 0
                'sommatoria delle spinte
                Spinta = 0
                'PressStat = 0
                'Alfa = 30
                For i = 1 To 10
                    CalcbetaN1(i, iC)
                    If Not CalcLiftDragN1(i, iC) Then
                        CalcolaN1 = False
                        Exit Function
                    End If
                Next
                Error1 = System.Math.Abs((Spinta - Spintav) / Spinta)
                Error2 = System.Math.Abs((Torque - Torquev) / Torque)
                Error3 = System.Math.Abs((Qsonda - Qsondav) / Qsonda)
                Torquev = Torque
                Spintav = Spinta
                Qsondav = Qsonda
                Errvec = Error3
                If Error1 < 0.0000001 And Error3 < 0.0000001 Then Exit Do
                iC = iC + 1
                If iC > 150 Then
                    CalcolaN1 = False
                    MsgBox("non trovata soluzione stabile")
                    Exit Function
                End If
            Loop
            'potenza all'asse
            kW = Torque * RPM / 60 * 2 * PI / 1000
            'velocità dell'aria nei trafilamenti al gioco
            '    PressStat = 0
            uind = System.Math.Sqrt(2 / 1.5 * PressStat * Dens)
            'sezione di passaggio trafilamenti
            aind = 0.005 * Diam ^ 2 * 2 / 1000000.0#
            'portata utile ventilatore
            Qsonda = Qsonda - aind * uind
            'sezione retta della portata utile
            Stot = Diam ^ 2 * PI / 4 / 1000000.0#
            PressStat1 = Spinta / Stot 'non ha niente a che vedere co la pressione statica
            'potenza aeraulica statica
            Pot = PressStat * Qsonda / 1000
            'rendimento statico
            etastat = Pot / kW
            'velocità assiale media
            uind = Qsonda / Stot
            ' pressione dinamica
            PressDyn = Dens * uind * uind / 2
            'potenza aeraulica totale
            Pot = (PressStat + PressDyn) * Qsonda / 1000
            'rendimento totale
            etaDyn = Pot / kW
            'If Abs((uind - Vinf) / Vinf) < 0.001 Then Exit Do
            Exit Do
            'Alfa = 5
            ' PressStat = 50
            'Vinf = (uind + Vinf) / 2
            ' Vinf = 0
            'PressStat = 0
        Loop
    End Function
    Private Function CalcolaN2() As Short
        Dim i As Short
        Dim p1, dr As Single
        Dim fact As Single
        Dim corr, corrl As Single
        Dim ic1 As Short
        CalcolaN2 = True
        Selem = (Diam - Dhub) / 2 / 10 * corda * Npal / 1000000.0#
        dr = (Diam - Dhub) / 2 / 10
        'sommatoria delle portate
        Do
            Qsonda = 0
            'sommatoria delle coppie
            Torque = 0
            'sommatoria delle spinte
            Spinta = 0
            corr = 0
            Forza = 0
            Errato = 0
            For i = 10 To 1 Step -1
                Di = (Dhub + (i - 1) * (Diam - Dhub) / 10)
                De = (Dhub + i * (Diam - Dhub) / 10)
                Area = (De ^ 2 - Di ^ 2) * PI / 4 / 1000000.0#
                Raggio = (Di + De) / 4
                Control = 0
                CalcVel(1, i)
                Spinta = Spinta + Thrust(i)
                Qsonda = Qsonda + Area * facta(i)
                Torque = Torque + Tq(i)
                ' Debug.Print i; PressStat; facta(i); factb(i); factp(i); gamma(i); cL(i); cD(i); Error1; iC; Dati.Fnorm; Dati.ErrCode
                If Dati.ErrCode > Errato Then Errato = Dati.ErrCode
                If i < 10 Then
                    p1 = PressStat * factp(i + 1) - 0.5 * Dens * vom(i + 1) ^ 2 * 4 * factb(i + 1) ^ 2 / (Raggio + dr) * dr
                Else
                    p1 = PressStat
                End If
                p1 = p1 - 0.5 * Dens * vom(i) ^ 2 * 4 * factb(i) ^ 2 / Raggio * dr
                fact = p1 / PressStat
                corrl = System.Math.Abs(fact - factp(i)) / fact
                If corrl > corr Then corr = corrl
                factp(i) = fact + (factp(i) - fact) / 2
                Forza = Forza + PressStat * factp(i) * Area
            Next
            If corr < 0.005 Then Exit Do
            ic1 = ic1 + 1
            If ic1 > 30 Then
                Errato = 4
                Exit Function
            End If
        Loop
    End Function
    Public Sub SubDati()
        Dim Risp(50) As String
        Dim iQ As Boolean
        Dim Dom(50) As String
        Dim Tit As String
        Dim Archiv(50) As Short
        Dim dAiu(50) As String
        Dim Aiuto As String = ""
        Tit = "Dati complementari"
        Dom(1) = "Pressione statica min [Pa]"
        Dom(2) = "Incremento Press. stat. [Pa]"
        Dom(3) = "Pressione statica max [Pa]"
        Dom(4) = "Diametro allo hub [mm]"
        Dom(5) = "Angolo di calettamento al tip min"
        Dom(6) = "Angolo di calettamento al tip max"
        Dom(7) = "Incremento Angolo di c. al tip"
        Dom(8) = "Angolo tra livella e normale al bordo di entrata"
        Dom(9) = "Angolo tra corda e normale al bordo di entrata"
        Dom(10) = "Angolo di torcitura [°/m]"
        Torcit = 8.6
        Alfas = 18.9
        Alfat = 17.5
        Dhub = 1314
        AlfaMin = 5
        AlfaMax = 35
        IncrAlfa = 2.5
        Risp(1) = GlobalRoutines.myStr(PressMin, 5, 2, False)
        Risp(2) = GlobalRoutines.myStr(IncrPress, 5, 2, False)
        Risp(3) = GlobalRoutines.myStr(PressMax, 5, 2, False)
        Risp(4) = GlobalRoutines.myStr(Dhub, 5, 2, False)
        Risp(5) = GlobalRoutines.myStr(AlfaMin, 2, 2, False)
        Risp(6) = GlobalRoutines.myStr(AlfaMax, 2, 2, False)
        Risp(7) = GlobalRoutines.myStr(IncrAlfa, 2, 2, False)
        Risp(8) = GlobalRoutines.myStr(Alfat, 2, 2, False)
        Risp(9) = GlobalRoutines.myStr(Alfas, 2, 2, False)
        Risp(10) = GlobalRoutines.myStr(Torcit, 2, 2, False)
        iQ = Monitor.Motore.InputDati(10, Tit, Dom, Risp, Aiuto, Archiv, dAiu)
        PressMin = Val(Risp(1))
        IncrPress = Val(Risp(2))
        PressMax = Val(Risp(3))
        Dhub = Val(Risp(4))
        AlfaMin = Val(Risp(5))
        AlfaMax = Val(Risp(6))
        IncrAlfa = Val(Risp(7))
        Alfat = Val(Risp(8))
        Alfas = Val(Risp(9))
        Torcit = Val(Risp(10))
    End Sub
    Private Sub Calcvom()
        Dim i As Short
        For i = 1 To 10
            vom(i) = (Dhub + (i - 0.5) * (Diam - Dhub) / 10) / 2 * RPM / 60 * 2 * PI / 1000
            factb(i) = 0.0#
            factp(i) = 1
            facta(i) = 0
        Next
    End Sub
    Private Sub Calcbeta()
        Dim i As Short
        For i = 1 To 10
            Beta(i) = 180 / PI * System.Math.Atan(vax(i) / vom(i))
        Next
    End Sub
    Private Sub CalcbetaN()
        Dim i As Short
        For i = 1 To 10
            Beta(i) = 180 / PI * System.Math.Atan(Vinf * (1 + facta(i)) / (vom(i) * (1 - factb(i))))
        Next
    End Sub
    Private Sub CalcbetaN1(ByRef i As Short, ByRef iC As Short)
        Dim A, b, G As Single
        ' facta(i) = 6: factb(i) = 0#
        b = 180 / PI * System.Math.Atan(facta(i) / (vom(i) * (1 - factb(i))))
        ' b = 180 / pi * Atn(facta(i) / (vom(i) * (1)))
        A = Alfa - Alfat + Alfas + (10 - i) / 9 * Torcit * (Diam - Dhub) / 2 / 1000
        G = A - b
        'If i = 1 Then Stop
        If G < -20 Or G > 30 Or System.Math.Abs(facta(i)) < 0.1 Then
            If iC < 7 And System.Math.Abs(facta(i)) < 0.1 Then
                factb(i) = 0.0# ' factb(i) * (iC / 100) ^ 2
                G = 0 ' g * (iC / 100) ^ 2
                b = A - G
                facta(i) = System.Math.Tan(b * PI / 180) * (vom(i) * (1 - factb(i)))
                '         facta(i) = Tan(b * pi / 180) * (vom(i)) '* (1 - factb(i)))
            Else
                ' Stop
            End If
        End If
        'inclinazione della normale al bordo di attacco
        Beta(i) = b
        gamma(i) = G
    End Sub
    Private Sub InitVinf()
        Dim i As Short
        Vinf = 5.0#
        For i = 1 To 10
            facta(i) = 0
        Next
    End Sub
    Private Sub InitVinf1()
        Dim i As Short
        Vinf = 0 ' 5#
        For i = 1 To 10
            facta(i) = 30
            factb(i) = 0.02
        Next
    End Sub
    Private Sub Initvax(ByRef f As Single)
        Dim i As Short
        For i = 1 To 10
            vax(i) = f * 15
        Next
    End Sub
    Private Sub Calcgamma()
        Dim i As Short
        Dim A As Single
        For i = 1 To 10
            A = Alfa - Alfat + Alfas + (10 - i) / 9 * Torcit * (Diam - Dhub) / 2 / 1000
            'inclinazione della normale al bordo di attacco
            gamma(i) = A - Beta(i)
        Next
    End Sub
    Private Function CalcLiftDrag() As Boolean
        'DT = 1/2r V1^2 c (CL cos(f ) - CD sin(f )). B.dr. . . . . . . . .(1)
        'vedi Thrust
        Dim i As Short
        Dim A As Single
        'area dell'elemento di pala per il n° di pale nel piano della corda
        Selem = (Diam - Dhub) / 2 / 10 * corda * Npal / 1000000.0#
        'sommatoria delle portate
        Qsonda = 0
        'sommatoria delle coppie
        Torque = 0
        'sommatoria delle spinte
        Spinta = 0
        For i = 1 To 10 'n° di elementi
            'calcolo dei coefficienti di lift e drag
            '      vom: velocità periferica della pala alla sezione i
            '      vax: velocità assiale dell'aria al raggio i
            cL(i) = intcL(gamma(i), System.Math.Sqrt(vom(i) ^ 2 + vax(i) ^ 2), cD(i))
            'Alfa :  calettamento al tip (definito con la livella)
            'Alfat:  angolo tra livella e normale al bordo di entrata
            'Alfas:  angolo tra corda e normale al bordo di entrata
            A = Alfa - Alfat + Alfas + (10 - i) / 9 * Torcit * (Diam - Dhub) / 2 / 1000
            'inclinazione della corda dell'elemento in esame rispetto all'asse ventilatore
            A = A * PI / 180
            Dens = 1.2
            Thrust(i) = (cL(i) * System.Math.Cos(A) - cD(i) * System.Math.Sin(A)) * Dens * (vom(i) ^ 2 + vax(i) ^ 2) / 2 * Selem
            Di = (Dhub + (i - 1) * (Diam - Dhub) / 10)
            De = (Dhub + i * (Diam - Dhub) / 10)
            Area = (De ^ 2 - Di ^ 2) * PI / 4 / 1000000.0#
            If vax(i) > 0 Then
                SP(i) = Thrust(i) / Area - Dens * vax(i) ^ 2 / 2
            Else
                SP(i) = Thrust(i) / Area + Dens * vax(i) ^ 2 / 2
            End If
            Spinta = Spinta + Thrust(i)
            Qsonda = Qsonda + Area * vax(i)
            Torque = Torque + (cL(i) * System.Math.Sin(A) + cD(i) * System.Math.Cos(A)) * Dens * (vom(i) ^ 2 + vax(i) ^ 2) / 2 * Selem * (Di + De) / 4 / 1000
        Next i
    End Function
    Private Function CalcLiftDragN(ByRef iC As Short) As Boolean
        'DT = 1/2Dens V1^2 c (CL cos(f ) - CD sin(f )). B.dr. . . . . . . . .(1)
        'vedi Thrust
        'DQ = 1/2Dens V1^2 c (CL sin(f ) + CD cos(f )) .B.r.dr . . . . . . .(2)
        'vedi Tq
        'a = theta - tan-1(V0/V2) . . . . . . . . . . . . . . . . . . . . . .(4)
        'vedi Calcgamma
        'DT = Dens 4pi r Vinf^2( 1 + a). a. dr . . . . . . . . . . . . . . . (5)
        'DQ = Dens 4pi r^3 Vinf( 1 + a). b omega . dr .  . . . . . . . . . . (6)
        Dim i As Short
        Dim A As Single
        Dim Sol1, Damping, Sol2 As Single
        Dim iLoop As Short
        CalcLiftDragN = True
        'area dell'elemento di pala per il n° di pale nel piano della corda
        Selem = (Diam - Dhub) / 2 / 10 * corda * Npal / 1000000.0#
        'sommatoria delle portate
        Qsonda = 0
        'sommatoria delle coppie
        Torque = 0
        'sommatoria delle spinte
        Spinta = 0
        For i = 1 To 10 'n° di elementi
            'calcolo dei coefficienti di lift e drag
            '      vom: velocità periferica della pala alla sezione i
            '      vax: velocità assiale dell'aria al raggio i
            V1 = System.Math.Sqrt((vom(i) * (1 - factb(i))) ^ 2 + (Vinf * (1 + facta(i))) ^ 2)
            cL(i) = intcL(gamma(i), V1, cD(i))
            'Alfa :  calettamento al tip (definito con la livella)
            'Alfat:  angolo tra livella e normale al bordo di entrata
            'Alfas:  angolo tra corda e normale al bordo di entrata
            A = Alfa - Alfat + Alfas + (10 - i) / 9 * Torcit * (Diam - Dhub) / 2 / 1000
            'inclinazione della corda dell'elemento in esame rispetto all'asse ventilatore
            A = A * PI / 180
            Dens = 1.2
            Num1 = cL(i) * System.Math.Cos(A) - cD(i) * System.Math.Sin(A)
            Num2 = cL(i) * System.Math.Sin(A) + cD(i) * System.Math.Cos(A)
            Di = (Dhub + (i - 1) * (Diam - Dhub) / 10)
            De = (Dhub + i * (Diam - Dhub) / 10)
            Area = (De ^ 2 - Di ^ 2) * PI / 4 / 1000000.0#
            Raggio = (Di + De) / 4
            If Npal = 0 Then
                CalcLiftDragN = False
                MsgBox("Non è stato fornito il numero di pale")
                Exit Function
            End If
            'Vinf = 5
            With Dati
                '      .Matrix(1, 1) = Vinf ^ 2 / 2 * (Num1 - 8 * pi * Raggio / (corda * Npal))
                '      .Matrix(1, 2) = Vinf ^ 2 * (Num1 - 4 * pi * Raggio / (corda * Npal))
                .Matrix(1, 1) = Vinf ^ 2 / 2 * (Num1 - 8 * PI * Raggio / (corda * Npal))
                .Matrix(1, 2) = Vinf ^ 2 * (Num1 - 4 * PI * Raggio / (corda * Npal))
                '      .Matrix(1, 1) = Vinf ^ 2 / 2 * (Num1 - 16 * pi * Raggio / (corda * Npal))
                '      .Matrix(1, 2) = Vinf ^ 2 * (Num1 - 12 * pi * Raggio / (corda * Npal))
                .Matrix(1, 3) = vom(i) ^ 2 / 2 * Num1
                .Matrix(1, 4) = -vom(i) ^ 2 * Num1
                .Matrix(1, 5) = 0
                .Matrix(1, 6) = (Vinf ^ 2 + vom(i) ^ 2) / 2 * Num1 - PressStat / Dens * Area / Selem - Vinf ^ 2 * 4 * PI * Raggio / (corda * Npal)
                ' .Matrix(1, 6) = (Vinf ^ 2 + vom(i) ^ 2) / 2 * Num1
                .Matrix(2, 1) = Vinf ^ 2 / 2 * Num2
                .Matrix(2, 2) = Vinf ^ 2 * Num2
                .Matrix(2, 3) = vom(i) ^ 2 / 2 * Num2
                .Matrix(2, 4) = -vom(i) ^ 2 * Num2 - 4 * PI * Raggio * Vinf * vom(i) / (corda * Npal)
                .Matrix(2, 5) = -4 * PI * Raggio * Vinf * vom(i) / (corda * Npal)
                .Matrix(2, 6) = (Vinf ^ 2 + vom(i) ^ 2) / 2 * Num2 '- PressStat / Dens * Area / Selem
                .ErrRel = 0.0001
                .ItMax = 200
                .St = Monitor.Motore.Inizio.DiscoRam & "MathVentErr.TXT"
                .STDERR = 33
                .StOut = Monitor.Motore.Inizio.DiscoRam & "MathVentOut.TXT"
                .STDOUT = 34
                .Tipo = 1
                .Xguess(1) = facta(i)
                .Xguess(2) = factb(i)
                '   Debug.Print .Matrix(1, 1) * facta(i) ^ 2 + .Matrix(1, 2) * facta(i) + .Matrix(1, 3) * factb(i) ^ 2 + .Matrix(1, 4) * factb(i) + .Matrix(1, 6)
            End With
            iLoop = 0
Rif:        'Dati.Xguess(2) = 0
            Do
                SOLVEQUAD2(Dati)
                If Dati.ErrCode = 0 And Dati.Fnorm <= Dati.ErrRel Then Exit Do
                Sol1 = Dati.Sol(1)
                Sol2 = Dati.Sol(2)
                GoTo Jump
                ' If iLoop = 1 Then Stop
                ' iLoop = 1
                ' Dati.Matrix(1, 6) = (Vinf ^ 2 + vom(i) ^ 2) / 2 * Num1
                ' GoTo Rif
                iLoop = iLoop + 1
                If iLoop < 5 Then
                    Dati.Xguess(1) = iLoop
                Else
                    Dati.Xguess(1) = 5 - iLoop
                End If
                If iLoop > 7 Then
                    MsgBox("Soluzione sistema quadratico non trovata")
                    CalcLiftDragN = False
                    Exit Function
                End If
            Loop
            If System.Math.Sqrt((Dati.Sol(1) + 1) ^ 2 + (1 - Dati.Sol(2)) ^ 2) < 0.001 Then
                If iLoop = 10 Then
                    Stop
                    facta(i) = 0
                    factb(i) = 0
                    Dati.Sol(1) = 0
                    Dati.Sol(2) = 0
                Else
                    Dati.Xguess(1) = 3
                    Dati.Xguess(2) = 0
                    iLoop = 10
                    GoTo Rif
                End If
            End If
            Sol1 = Dati.Sol(1)
            Sol2 = Dati.Sol(2)
            Dati.Xguess(1) = 3
            Dati.Xguess(2) = 0
            SOLVEQUAD2(Dati)
            If Dati.Sol(1) > Sol1 Then
                Sol1 = Dati.Sol(1)
                Sol2 = Dati.Sol(2)
            End If
Jump:
            Damping = System.Math.Sqrt(iC + 1)
            facta(i) = facta(i) + (Sol1 - facta(i)) / Damping
            factb(i) = factb(i) + (Sol2 - factb(i)) / Damping
            Thrust(i) = Num1 * Dens * V1 ^ 2 / 2 * Selem
            SP(i) = Thrust(i) / Area
            Spinta = Spinta + Thrust(i)
            Qsonda = Qsonda + Area * Vinf * (1 + facta(i))
            Tq(i) = Num2 * Dens * V1 ^ 2 / 2 * Selem * Raggio / 1000
            Torque = Torque + Tq(i)
        Next i
    End Function
    Private Function CalcLiftDragN1(ByRef i As Short, ByRef iC As Short) As Boolean
        'DT = 1/2Dens V1^2 c (CL cos(f ) - CD sin(f )). B.dr. . . . . . . . .(1)
        'vedi Thrust
        'DQ = 1/2Dens V1^2 c (CL sin(f ) + CD cos(f )) .B.r.dr . . . . . . .(2)
        'vedi Tq
        'a = theta - tan-1(V0/V2) . . . . . . . . . . . . . . . . . . . . . .(4)
        'vedi Calcgamma
        'DT = Dens 4pi r Vinf^2( 1 + a). a. dr . . . . . . . . . . . . . . . (5)
        'DQ = Dens 4pi r^3 Vinf( 1 + a). b omega . dr .  . . . . . . . . . . (6)
        Dim delta, bmin As Single
        'UPGRADE_WARNING: Il limite inferiore della matrice locM è stato cambiato da 1,1 a 0,0. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
        Dim A, bmax As Single
        Dim locM(2, 6) As Single
        Dim Sol1, Damping, Sol2 As Single
        Dim iLoop As Short
        Dim jj, ii, v As Single
        Dim ccc, aaa, bbb, qac As Single
        Dim Num1p, Num2p As Single
        CalcLiftDragN1 = True
        'For i = 1 To 10 'n° di elementi
        'calcolo dei coefficienti di lift e drag
        '      vom: velocità periferica della pala alla sezione i
        '      vax: velocità assiale dell'aria al raggio i
        V1 = System.Math.Sqrt((vom(i) * (1 - factb(i))) ^ 2 + facta(i) ^ 2)
        cL(i) = intcL(gamma(i), V1, cD(i))
        'Alfa :  calettamento al tip (definito con la livella)
        'Alfat:  angolo tra livella e normale al bordo di entrata
        'Alfas:  angolo tra corda e normale al bordo di entrata
        A = Alfa - Alfat + Alfas + (10 - i) / 9 * Torcit * (Diam - Dhub) / 2 / 1000
        'inclinazione della corda dell'elemento in esame rispetto all'asse ventilatore
        A = A * PI / 180
        Dens = 1.2
        Num1 = cL(i) * System.Math.Cos(A) - cD(i) * System.Math.Sin(A)
        Num2 = cL(i) * System.Math.Sin(A) + cD(i) * System.Math.Cos(A)
        Num1p = cL(i) * System.Math.Cos(A) - cD(i) * System.Math.Sin(A)
        Num2p = cL(i) * System.Math.Sin(A) + cD(i) * System.Math.Cos(A)
        If Npal = 0 Then
            CalcLiftDragN1 = False
            MsgBox("Non è stato fornito il numero di pale")
            Exit Function
        End If
        With Dati
            locM(1, 1) = Num1p / 2 - 2 * PI * Raggio / (corda * Npal) '* Sgn(facta(i))
            locM(1, 2) = 0 ' Vinf * (2 * pi * Raggio / (corda * Npal))
            locM(1, 3) = vom(i) ^ 2 / 2 * Num1p
            locM(1, 4) = -vom(i) ^ 2 * Num1p
            locM(1, 5) = 0
            locM(1, 6) = vom(i) ^ 2 / 2 * Num1p - PressStat * factp(i) / Dens * 2 * PI * Raggio / (corda * Npal) * System.Math.Cos(A)
            locM(2, 1) = 1 / 2 * Num2p
            locM(2, 2) = 0 'Vinf * Num2
            locM(2, 3) = vom(i) ^ 2 / 2 * Num2p
            locM(2, 4) = -vom(i) ^ 2 * Num2p '- 4 * pi * Raggio * vom(i) / (corda * Npal)
            locM(2, 5) = -4 * PI * Raggio * vom(i) / (corda * Npal) ' * Sgn(facta(i))
            locM(2, 6) = vom(i) ^ 2 / 2 * Num2p - 2 * PressStat * factp(i) / Dens * PI * Raggio / (corda * Npal) * System.Math.Sin(A)
            .ErrRel = 0.0001
            .ItMax = 200
            .St = Monitor.Motore.Inizio.DiscoRam & "MathVentErr.TXT"
            .STDERR = 33
            .StOut = Monitor.Motore.Inizio.DiscoRam & "MathVentOut.TXT"
            .STDOUT = 34
            .Tipo = 1
            .Xguess(1) = facta(i)
            .Xguess(2) = factb(i)
            For ii = 1 To 2
                For jj = 1 To 6
                    '        .Matrix(jj, ii) = locM(ii, jj)
                    .Matrix(ii, jj) = locM(ii, jj)
                Next
            Next
        End With
        iLoop = 0
        'facta(i) = -10: factb(i) = 0
        ' Num1 = 1
        SOLVEQUAD2(Dati)
        '      Debug.Print locM(1, 1) * Dati.Sol(1) ^ 2 + locM(1, 2) * Dati.Sol(1) + locM(1, 3) * Dati.Sol(2) ^ 2 + locM(1, 4) * Dati.Sol(2) + locM(1, 6)
        '      Debug.Print locM(2, 1) * Dati.Sol(1) ^ 2 + locM(2, 2) * Dati.Sol(1) + locM(2, 3) * Dati.Sol(2) ^ 2 + locM(2, 4) * Dati.Sol(2) + locM(2, 5) * Dati.Sol(1) * Dati.Sol(2) + locM(2, 6)
        '===================================================================
        aaa = locM(1, 3) - locM(2, 3) * locM(1, 1) / locM(2, 1)
        ccc = locM(1, 6) - locM(2, 6) * locM(1, 1) / locM(2, 1)
        qac = 4 * aaa * ccc
        If qac > 0 Then
            v = -((System.Math.Sqrt(qac) - locM(1, 4)) / (locM(1, 1) / locM(2, 1)) + locM(2, 4)) / locM(2, 5)
        End If
        bbb = locM(1, 4) - (locM(2, 4) + locM(2, 5) * v) * locM(1, 1) / locM(2, 1)
        delta = bbb ^ 2 - qac
        If delta < 0 Then delta = 0
        bmin = (-bbb - System.Math.Sqrt(delta)) / 2 / aaa
        bmax = (-bbb + System.Math.Sqrt(delta)) / 2 / aaa
        v = -(locM(1, 3) * bmin ^ 2 + locM(1, 4) * bmin + locM(1, 6)) / locM(1, 1)
        '     v = Sqr(v)
        '=====================================================================
        If Dati.ErrCode = 0 And Dati.Fnorm <= Dati.ErrRel Then
            Sol1 = Dati.Sol(1)
            Sol2 = Dati.Sol(2)
        Else
            If Control = 0 Then
                'Control = 1
                'facta(i) = -20
                'factb(i) = 0
                'Exit Function
                Sol1 = Dati.Sol(1)
                Sol2 = Dati.Sol(2)
            Else
                Sol1 = Dati.Sol(1)
                Sol2 = Dati.Sol(2)
            End If
        End If
        'facta(i) = 0
        Damping = (iC + 1) ^ 0.25
        'dev = 100 * Sqr((Sol1 - facta(i)) ^ 2 + (Sol2 - factb(i)) ^ 2) / Sqr(facta(i) ^ 2 + factb(i) ^ 2)
        'If dev > 10 Then Damping = De
        'If facta(i) < 1 Then Stop
        facta(i) = facta(i) + (Sol1 - facta(i)) / Damping / 8
        factb(i) = factb(i) + (Sol2 - factb(i)) / Damping / 8
        'facta(i) = 5
        'factb(i) = 0.2
    End Function
    'UPGRADE_NOTE: Class_Initialize è stato aggiornato a Class_Initialize_Renamed. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
    Private Sub Class_Initialize_Renamed()
        LeggiLib()
        z1 = 0 : PFUN = 1 : PEFF = 1
    End Sub
    Public Sub New()
        MyBase.New()
        Class_Initialize_Renamed()
    End Sub
    Private Sub LeggiLib()
        Table4 = myDataBase.OpenRecordset("SELECT * FROM LDcoeff WHERE Rey=10000 ORDER BY alpha")
        Table5 = myDataBase.OpenRecordset("SELECT * FROM LDcoeff WHERE Rey=100000 ORDER BY alpha")
        Table6 = myDataBase.OpenRecordset("SELECT * FROM LDcoeff WHERE Rey=1000000 ORDER BY alpha")
    End Sub
    Private Function intcL(ByRef x As Single, ByRef vr As Single, ByRef cD As Single) As Single
        Dim T1, T2 As dao.Recordset
        Dim cD1, cL1, cL2, cD2 As Single
        Dim cD11, cL11, cL21, cD21 As Single
        Dim cD12, cL12, cL22, cD22 As Single
        Dim alf21, alf11, alf12, alf22 As Single
        Dim Re, Re1, Re2, X1 As Single
        'Do Until i = 30
        '   If xlibLift(i) > x Then
        '      intcL = libLift(i - 1) + (libLift(i) - libLift(i - 1)) * (x - xlibLift(i - 1)) / (xlibLift(i) - xlibLift(i - 1))
        '      Exit Function
        '   End If
        '   i = i + 1
        'Loop
        Re = 1.2 * corda * vr / 0.0000172 / 1000
        'Re = 530 * vr * 70
        If Re < 100000 Then
            T1 = Table4
            T2 = Table5
        Else
            T1 = Table5
            T2 = Table6
        End If
        X1 = x : If X1 > 89 Then X1 = 89
        T1.FindFirst("alpha > " & Str(X1))
        Re1 = T1.Fields("Rey").Value
        cL12 = T1.Fields("cL").Value
        cD12 = T1.Fields("cD").Value
        alf12 = T1.Fields("alpha").Value
        T1.MovePrevious()
        cL11 = T1.Fields("cL").Value
        cD11 = T1.Fields("cD").Value
        alf11 = T1.Fields("alpha").Value
        T2.FindFirst("alpha > " & Str(X1))
        Re2 = T2.Fields("Rey").Value
        cL22 = T2.Fields("cL").Value
        cD22 = T2.Fields("cD").Value
        alf22 = T2.Fields("alpha").Value
        T2.MovePrevious()
        cL21 = T2.Fields("cL").Value
        cD21 = T2.Fields("cD").Value
        alf21 = T2.Fields("alpha").Value
        cL1 = cL11 + (x - alf11) / (alf12 - alf11) * (cL12 - cL11)
        cD1 = cD11 + (x - alf11) / (alf12 - alf11) * (cD12 - cD11)
        cL2 = cL21 + (x - alf21) / (alf22 - alf21) * (cL22 - cL21)
        cD2 = cD21 + (x - alf21) / (alf22 - alf21) * (cD22 - cD21)
        intcL = cL1 + (cL2 - cL1) * System.Math.Log(Re / Re1) / System.Math.Log(Re2 / Re1)
        cD = cD1 + (cD2 - cD1) * System.Math.Log(Re / Re1) / System.Math.Log(Re2 / Re1)
    End Function

    Private Function intcD(ByRef x As Single) As Single
        'Dim i As Short
        'Do Until i = 30
        '   If xlibDrag(i) > x Then
        '      intcD = libDrag(i - 1) + (libDrag(i) - libDrag(i - 1)) * (x - xlibDrag(i - 1)) / (xlibDrag(i) - xlibDrag(i - 1))
        '      Exit Function
        '   End If
        '   i = i + 1
        'Loop
    End Function
    'UPGRADE_NOTE: Class_Terminate è stato aggiornato a Class_Terminate_Renamed. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
    Private Sub Class_Terminate_Renamed()
        Table4.Close()
        Table5.Close()
        Table6.Close()
    End Sub
    Protected Overrides Sub Finalize()
        Class_Terminate_Renamed()
        MyBase.Finalize()
    End Sub
    Public Function SupCalcola() As Short
        Dim savQ As Single
        Calcvom()
        For Alfa = AlfaMin To AlfaMax Step IncrAlfa
            Initvax(1)
            PressStat = PressMin
            Do
                SupCalcola = Calcola()
                If vax(1) < 0 And vax(2) < 0 And vax(3) < 0 Then Exit Do
                If Qsonda <= 0 Then
                    savQ = Qsonda
                    Initvax(-1)
                    SupCalcola = Calcola()
                    Exit Do
                End If
                With TabDati
                    .AddNew()
                    .Fields("idPala").Value = 3
                    .Fields("RPM").Value = RPM
                    .Fields("nPale").Value = Npal
                    .Fields("Diam").Value = Diam
                    .Fields("Torcit").Value = Torcit
                    .Fields("Calett").Value = Alfa
                    .Fields("pstat").Value = PressStat
                    .Fields("Q").Value = Qsonda
                    .Fields("pdyn").Value = PressDyn
                    .Fields("etastat").Value = etastat
                    .Fields("etaDyn").Value = etaDyn
                    .Fields("invers").Value = vax(1) < 0
                    .Fields("kW").Value = kW
                    .Fields("Thrust").Value = Spinta
                    .Fields("Torque").Value = Torque
                    .Update()
                End With
                PressStat = PressStat + IncrPress
            Loop
        Next
    End Function
    Public Function SupCalcolaN() As Short
        Dim ris As Boolean
        Calcvom()
        For Alfa = AlfaMin To AlfaMax Step IncrAlfa
            Alfa = 30
            For PressStat = 0 To PressMax Step IncrPress
                'Alfa = 25
                'PressStat = PressMin
                PressStat = 90
                'For iVinf = 10 To 39
                '  If iVinf < 10 Then
                '     Vinf = iVinf / 10#
                '  Else
                '     Vinf = iVinf - 9
                '  End If
                'PressStat = 280
                InitVinf()
                ris = CalcolaN()
                If Not ris Then GoTo Salto
                SupCalcolaN = ris
                If Qsonda <= 0 Then
                    GoTo Salto
                End If
                GoTo Salto
                With TabDati
                    .AddNew()
                    .Fields("idPala").Value = 4
                    .Fields("RPM").Value = RPM
                    .Fields("nPale").Value = Npal
                    .Fields("Diam").Value = Diam
                    .Fields("Torcit").Value = Torcit
                    .Fields("Calett").Value = Alfa
                    .Fields("pstat").Value = PressStat
                    .Fields("Q").Value = Qsonda
                    .Fields("pdyn").Value = PressDyn
                    .Fields("etastat").Value = etastat
                    .Fields("etaDyn").Value = etaDyn
                    .Fields("invers").Value = SP(1) < 0
                    .Fields("kW").Value = kW
                    .Fields("Thrust").Value = Spinta
                    .Fields("Torque").Value = Torque
                    .Update()
                End With
Salto:
            Next
Salto1:
        Next
    End Function
    Public Function SupCalcolaN1() As Short
        Dim ris As Boolean
        Dim Qv, deriv As Single
        For Alfa = AlfaMin To AlfaMax Step IncrAlfa
            Calcvom()
            PressStat = PressMin
            Qv = 0
            Do
                ris = CalcolaN2()
                If Not ris Then GoTo Salto
                If Errato > 0 Then
                    PressStat = PressStat - IncrPress
                    IncrPress = IncrPress / 2
                    GoTo Salto
                End If
                SupCalcolaN1 = ris
                If Qsonda <= 0 Then
                    GoTo Salto
                End If
                Stot = (Diam ^ 2 - Dhub ^ 2) * PI / 4 / 1000000.0#
                PressFin = Forza / Stot
                'potenza all'asse
                kW = Torque * RPM / 60 * 2 * PI / 1000
                'velocità dell'aria nei trafilamenti al gioco
                '    PressStat = 0
                uind = System.Math.Sqrt(2 / 1.5 * PressStat * Dens)
                'sezione di passaggio trafilamenti
                aind = 0.005 * Diam ^ 2 * 2 / 1000000.0#
                'portata utile ventilatore
                Qsonda = Qsonda - aind * uind
                'sezione retta della portata utile
                PressStat1 = Spinta / Stot
                'potenza aeraulica statica
                Pot = PressFin * Qsonda / 1000
                'rendimento statico
                etastat = Pot / kW
                'velocità assiale media
                uind = Qsonda / Stot
                ' pressione dinamica
                PressDyn = Dens * uind * uind / 2
                'potenza aeraulica totale
                Pot = (PressFin + PressDyn) * Qsonda / 1000
                'rendimento totale
                etaDyn = Pot / kW
                'Debug.Print(VB6.TabLayout(etastat, etaDyn, Qsonda, PressFin))
                ' GoTo Salto
                'facta(10) = -20
                With TabDati
                    .AddNew()
                    .Fields("idPala").Value = 4
                    .Fields("RPM").Value = RPM
                    .Fields("nPale").Value = Npal
                    .Fields("Diam").Value = Diam
                    .Fields("Torcit").Value = Torcit
                    .Fields("Calett").Value = Alfa
                    .Fields("pstat").Value = PressStat
                    .Fields("Q").Value = Qsonda
                    .Fields("pdyn").Value = PressDyn
                    .Fields("etastat").Value = etastat
                    .Fields("etaDyn").Value = etaDyn
                    .Fields("invers").Value = facta(1) < 0 'SP(1) < 0
                    .Fields("kW").Value = kW
                    .Fields("Thrust").Value = Spinta
                    .Fields("Torque").Value = Torque
                    .Update()
                End With
Salto:
                deriv = (Qv - Qsonda) / IncrPress 'non va bene: deriv risp pr reale
                If PressStat > PressMax Then Exit Do
                Qv = Qsonda
                'IncrPress = 25 'IncrPress / 2
                PressStat = PressStat + IncrPress
            Loop
Salto1:
        Next
    End Function
    Public Function CalcVel(ByRef m As Short, ByRef i As Short) As Boolean
        iC = 6
        vmax(i) = 1000
        Do
            CalcbetaN1(i, iC)
            If Not CalcLiftDragN1(i, iC) Then
                CalcVel = False
                Stop
                Exit Function
            End If
            iC = iC + 1
            If System.Math.Abs(facta(i) - Dati.Sol(1)) < 0.0001 And Dati.ErrCode = 0 Then Exit Do
            If iC > 1850 Then
                '  MsgBox "non trovata soluzione stabile"
                '  Exit Function
                Stop
                Exit Do
                'facta(i) = -20
                iC = 6
                'Exit Do
            End If
        Loop
        Thrust(i) = Num1 * Dens * V1 ^ 2 / 2 * Selem
        SP(i) = Thrust(i) / Area - Dens * facta(i) ^ 2 / 2
        Tq(i) = Num2 * Dens * V1 ^ 2 / 2 * Selem * Raggio / 1000
    End Function
End Class