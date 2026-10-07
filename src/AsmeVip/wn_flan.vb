Option Strict Off
Option Explicit On 
Imports RoutBase1
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Runtime.Serialization.Formatters.Binary 'Namespace for BinaryFormatter
Friend Class wn_flan
    ' 1  2 P,T
    ' 3, 4 A, C
    ' 5    G, diametro guarnizione
    '7,8   per lj spessore lap spessore shell se -1 split ring
    '9     spessore flangia
    '11    corrosione
    '12,13 diametro e numero bulloni
    '14-15 diametro nocciolo/ diametro foro
    '16-17 Emin,E spazio verso l'esterno
    '18-19 Rmin (spazio bullone verso lo hub-R
    '20-21 BSmin, BS
    '22-23 ammissibili flangia
    '24-25 ammissibili bulloni
    '26    N, larghezza guarn.
    '28    Y
    '29    W. largh. nubbin
    '30    m
    '31    phi, formula larghezza
    '33,34 Wm1imp,Wm2imp
    '35,36 b0, b
    '37    Gef
    '40,41 Wm1,Wm2
    '42    W
    '43,44 Am1,Am2
    '45,46 Am,Ab      m1,m2 nel caso di App.14 per transition piece
    '54 per .LOOSE=-1,2 (?) fattore K
    '54    per .LOOSE=2 (optional .LOOSE) quando per fondo flottante: componente radiale della sollecitazione membranale all'attacco flangia
    '90 Young @design
    '91 max (desw mom op,des mom atm)
    '92,93 R interno R ext
    '105 pressione di prova idraulica calcolata a codice
    '114 target bolt load in N 
    '115 target bolt load in kgf
    '116 bolt stress with pilgrim under pressure
    '117 bolt torque in Nmm
    '118 bolt torque in kgf.m
    '119   spessore
    '122,123 coperchio a o
    '124     Rcurv per fondi su flottanti
    '125,126 hr, beta
    '151 lunghezza rinforzo
    '152-153 rapporti ammissibili copercio/apertura
    '154-159 Aree rinforzo aperture su coperchio
    '160 Tira.Dnom
    '161,162,163 g.Class, g.Tipo, g.Face
    '167,168,169 lungh.traversini, Y trav, b eff. trav.
    '171,172 ammiss bulloni e flangia  in PI
    '173,174 bulloni a o                max(m1,m2) App.14
    '175,176 flangia a o
    '177,178 coperchio a o
    '179,180 bocchelli su coperchio
    '181 ammiss coperchio in PI
    '182,183 MDMT1 MDMT2
    '184,185 Press1 Press2
    '186 extra spazio verso hub
    '187 mod elastico bulloni
    '188 ar (reverse flange)
    '189 Tr (reverse flange)
    '190 Ur (reverse flange)
    '191 Yr (reverse flange)
    '192 ST2(reverse flange)
    '193,194 Wm1 e Wm2 in prova idraulica
    '195 calcolo per flottante 1 1.6d, 2 fondoo conico
    '196,197 vedi 54 per .LOOSE =2
    '198 Diametro di azione della pressione, se diverso da gef
    '199 Se 1 tiranti prigionieri
    '200 rapp
    '201,202,203 Guarn lenticolari, Alfa, R, H
    '    202,203 Guarn Omega            , R, ID seal weld
    '204 minimum bolting-up prestress
    '205 Young flangia at room
    '206,207 Jop,Jatm
    <VBFixedString(5), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=5)> Private F1 As String = New String(" "c, 5) ' * 5
    <VBFixedString(40), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=40)> Private F2 As String = New String(" "c, 40) '* 40
    <VBFixedString(1), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=1)> Private Buffer As String = New String(" "c, 1) '* 1
    Private Structure typwnlj
        Dim H As Single
        Dim H0 As Single
        Dim g As Single
        Dim g0 As Single
        Dim g1 As Single
        Dim co As Single
        Dim b As Single
        Dim bo As Single
        Dim n As Single
        Dim PHI As Single
        Dim W As Single
        Dim y As Single
        Dim m As Single
        Dim wmt As Single
    End Structure
    Private Structure DatiProg
        Dim PressDes As Single ' M(1)
        Dim PressTest As Single ' M(1)
        Dim Temperat As Single ' M(2)
        Dim corrosion As Single ' M(11)
    End Structure
    <Serializable(), StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> Private Structure wnConfig
        Dim SicBull As Single
        Dim PIsuOpe As Single
        Dim LatoProgetto As Short
        Dim CorrProva As Short
        Dim FullBolt As Short
        Dim TipCalc As Short
        Dim Verbose As Short
        Dim CRUSH As Short
        Dim BoltLoadDetail As Boolean
        <VBFixedString(100), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=100)> Public Padding As String
    End Structure
    <Serializable()> Friend Structure typMemoryBank
        Dim M() As Single
        Dim Z() As Single
        Dim TIR As String
        Dim XFil As Short
        Dim Gasket As String
        Dim GasMat As String
        Dim FLID, DOCU, FLMA As String
        Dim COID, TIMA, COMA As String
        Dim NOID, NOMA As String
        Dim Conforme As String
        Dim VERIFICA As String
        Dim File As String
        Dim LOOSE As Short
        Public Sub Initialize()
            ReDim M(300), Z(300)
            TIR = ""
            Gasket = ""
            GasMat = ""
            FLID = ""
            DOCU = ""
            FLMA = ""
            COID = ""
            TIMA = ""
            COMA = ""
            NOID = ""
            NOMA = ""
            Conforme = ""
            VERIFICA = ""
            File = ""
        End Sub
    End Structure
    Friend Mem As typMemoryBank
    Private mems As typMemoryBank
    Private Issue As ASMERES
    Private locInd, jRec As Integer
    Private FattSic1 As Single
    Private i78, j78, j2 As Short
    Private NonVal As Boolean
    Private Intersez As RoutBase1.clsPunti
    Private RoutGraf As Grafica.LibGra
    Private CentroC As RoutBase1.clsVec2
    Private Linea As RoutBase1.clsLinea2
    Private Direz As RoutBase1.clsVec2
    Private Dist, Proiez As Single
    Private ConfermaCP As Boolean
    Private ConfermaBS As Boolean
    Private ConfermaDR As Boolean
    Private ConfermaDE As Boolean
    Private ConfermaLG As Boolean
    Private ConfermaST As Boolean
    Private ConfermaSG As Boolean
    Private Controlling(2) As String
    Private Conferma(1) As Boolean
    Private Z33, Z34 As Single
    Private AbPI, AmPI, FattSicPI As Single
    Private Wm2PI, Wm1PI, Wm2imp As Single
    Private WmHI As Single
    Private DimensM As Boolean
    Private FattSic, rapp As Single
    Private PunPia() As RoutBase1.clsVec2
    Private Stringa() As String
    Private PLORdim(,) As Single
    Private PNETdim() As Single
    Private LTOdim() As Single
    Private Altdim() As Single
    Private SpsBoc() As Single
    Private iUG39e2, iUG39e1 As Boolean
    Private iUG39c, iUG39b3, AD5013 As Boolean
    Private NBocc As Short
    Private efflig As Single
    Private i1, i2 As Short
    Private DistGef(,) As Single
    Private Inters() As RoutBase1.clsVec2
    Private Dispon(,,) As Single
    Private PosVARI() As Short
    Private CVARI() As String
    Private NVARI() As String
    Private TVARI() As String
    Private VVARI() As Short
    Private UVARI() As String
    Private RVARI() As Short
    Public GiaCalc, Calcolo As Boolean
    Private cop, torce As Short
    Public lKlato, lJinvolucr As Short
    Public CoperchioAutoRinforzato As Short
    Public LoadCond As Short
    Private wnlj() As typwnlj
    Public qbflan As Short ', xTir As Integer
    Public pagina As Short
    Public Ind As Short
    Public FFF, WWW, kkk As Short
    Private Fermo, Progetto As Short
    Private Modifica As Boolean
    Private Configwn As wnConfig
    Public SuperOtt As Boolean
    Public Tira As LibMat.clsTira
    Public Diaf As wn_Diaf
    Public Serr As Tiranti.Serraggio
    Private Jop, Jatm As Single
    Private Sub App14()
        Dim a, HC, c As Single
        Dim t, k, u As Single
        Dim V, y, Zf, f As Single
        Dim s, d, E, l As Single
        Dim mo, MT, MD, MPT As Single
        Dim G1g02, fc, ETH As Single
        Dim SR, SH, St As Single
        Dim UNOPIU, b As Single
        Dim MH, x1 As Single
        Dim SRS, SHS, STS As Single
        Dim SRO, SHO, STO As Single
        Dim i As Short
        Dim Sfo As Single
        Dim Testo As String
        Dim RicercaSpessore As Boolean
        RicercaSpessore = Mem.M(9) = 0
9821:   Call Step1()
        MPT = 0
        With Mem
            On Error GoTo 11001
            If .LOOSE = 5 Then
                wnlj(0).co = .M(12)
                Call ProgCod(0, 5, 3, 6, 10)
                If qbflan = 1 Or qbflan = -99 Then Exit Sub
                .M(55) = wnlj(0).H0 : .Z(55) = .M(55) / inc
                .M(56) = wnlj(0).H / wnlj(0).H0 : .Z(56) = .Z(10) / .Z(55)
                .M(45) = .Z(45) / MomToBS : .M(46) = .Z(46) / MomToBS
                MPT = .M(45) : If .M(46) > MPT Then MPT = .M(46)
                .M(173) = MPT : .Z(173) = .M(173) * MomToBS
            End If
9822:       wnlj(1).co = .M(12)
            Call ProgCod(1, 7, 4, 8, 11)
            If qbflan = 1 Or qbflan = -99 Then Exit Sub
            .M(53) = wnlj(1).H0 : .Z(53) = .M(53) / inc
            .M(57) = wnlj(1).H / wnlj(1).H0 : .Z(57) = .Z(10) / .Z(53)
9823:       Call PreliminG()
            'calcolo fattori di forma per flange a codolo
            If .LOOSE = 5 Then
                wnlj(0).g1 = .Z(6) : wnlj(0).g0 = .Z(5) : wnlj(0).co = .Z(12)
                HC = .Z(10) : wnlj(0).H0 = .Z(55)
                a = ((wnlj(0).g1 - wnlj(0).co) / (wnlj(0).g0 - wnlj(0).co)) - 1
                .Z(92) = a : .M(92) = a
                c = 43.68 * (HC / wnlj(0).H0) ^ 4
                .Z(56) = (HC / wnlj(0).H0) : .M(56) = .Z(56)
                Call FattForm(a, c, 65, 66, 67)
            End If
            'calcolo fattori di forma per flange a codolo
9827:       wnlj(0).g1 = .Z(8) : wnlj(0).g0 = .Z(7) : wnlj(0).co = .Z(12)
            HC = .Z(11) : wnlj(0).H0 = .Z(53)
            a = ((wnlj(0).g1 - wnlj(0).co) / (wnlj(0).g0 - wnlj(0).co)) - 1
            .Z(93) = a : .M(93) = a
            c = 43.68 * (HC / wnlj(0).H0) ^ 4
            .Z(57) = (HC / wnlj(0).H0) : .M(57) = .Z(57)
            Call FattForm(a, c, 42, 43, 44)
            'fattori T - U - Y - Z - K per flangie ASME
            a = .Z(4) + 2 * .Z(7) : wnlj(0).b = .Z(3) + 2 * .Z(12)
            k = a / wnlj(0).b
9829:       Call FattTUYZ(k, t, u, y, Zf)
            .Z(54) = k : .Z(61) = t : .Z(62) = u : .Z(63) = y : .Z(64) = 2 * k * k / (k * k - 1) 'da usare solo dopo!
            .M(54) = k : .M(61) = t : .M(62) = u : .M(63) = y : .M(64) = 2 * k * k / (k * k - 1) 'da usare solo dopo!
            .Z(38) = t : .Z(39) = u : .Z(40) = y : .Z(41) = Zf
            .M(38) = t : .M(39) = u : .M(40) = y : .M(41) = Zf
            'calcolo (d-e)
            If .LOOSE = 5 Then
                V = .Z(67) : f = .Z(66)
9830:           wnlj(0).H0 = .M(55) : wnlj(0).g0 = .M(5) : wnlj(0).co = .M(12)
                d = (u / V) * wnlj(0).H0 * (wnlj(0).g0 - wnlj(0).co) ^ 2
                E = f / wnlj(0).H0
                .M(58) = d : .M(59) = E
                wnlj(0).H0 = .Z(55) : wnlj(0).g0 = .Z(5) : wnlj(0).co = .Z(12)
                d = (u / V) * wnlj(0).H0 * (wnlj(0).g0 - wnlj(0).co) ^ 2
                E = f / wnlj(0).H0
                .Z(58) = d : .Z(59) = E
            End If
            'calcolo (d-e)
            V = .Z(44) : f = .Z(43)
            wnlj(0).H0 = .M(53) : wnlj(0).g0 = .M(7) : wnlj(0).co = .M(12)
            d = (u / V) * wnlj(0).H0 * (wnlj(0).g0 - wnlj(0).co) ^ 2
            E = f / wnlj(0).H0
            .M(35) = d : .M(36) = E
            wnlj(0).H0 = .Z(53) : wnlj(0).g0 = .Z(7) : wnlj(0).co = .Z(12)
            d = (u / V) * wnlj(0).H0 * (wnlj(0).g0 - wnlj(0).co) ^ 2
            E = f / wnlj(0).H0
            .Z(35) = d : .Z(36) = E
            'calcolo spessore di progetto e fattore L
            s = .M(9) - .M(12)
            If s <= 0 Then
                Select Case .LOOSE
                    Case 5, 6
                        s = 10
                    Case Else
                        s = .M(8)
                        If .M(6) > .M(8) Then s = .M(6) 'INT((.m(4) - .m(3)) / 4)
                End Select
            End If
9931:       E = .M(59) : t = .M(61) : d = .M(58)
            .M(9) = s + .M(12)
            .Z(9) = .M(9) / inc
            If .LOOSE = 5 Then
                l = ((s * E + 1) / t) + (s ^ 3 / d)
                .M(60) = l : .Z(60) = l
                .M(37) = l : .Z(37) = l
            End If
            'calcolo momenti
            MD = .M(50) * .M(47) : .M(68) = MD : .Z(68) = .M(68) * MomToBS
            MT = .M(51) * .M(48) : .M(69) = MT : .Z(69) = .M(69) * MomToBS
            mo = MD + MT + MPT : .M(74) = mo : .Z(74) = .M(74) * MomToBS
            'calcolo carico per sollecitazioni
9832:       wnlj(0).b = .M(3) + 2 * .M(12)
            wnlj(0).m = .M(74) / wnlj(0).b
            .M(92) = wnlj(0).m : .Z(92) = .M(92) * 0.224808924
            y = .M(63)
            'calcolo sollecitazioni con asterisco
            If .LOOSE = 5 Then
19938:          fc = .M(65) : wnlj(0).g1 = .M(6) - .M(12) : Zf = .M(41)
                'e = .m(59): L = .m(60)
                SH = (fc * wnlj(0).m) / (l * wnlj(0).g1 ^ 2)
                SR = ((1.33 * s * E + 1) * wnlj(0).m) / (l * s ^ 2)
                St = y * wnlj(0).m / s ^ 2 - Zf * SR
            Else
                SH = 0
                SR = 0
                St = y * wnlj(0).m / s ^ 2
            End If
            .M(70) = SH : .M(71) = SR : .M(72) = St
            .Z(70) = SH * psi : .Z(71) = SR * psi : .Z(72) = St * psi
            If .LOOSE = 5 Then
                G1g02 = ((.Z(6) - .Z(12)) / (.Z(5) - .Z(12))) ^ 2
                ETH = 0.91 * G1g02 * (.Z(3) + .Z(5)) * .Z(67) / .Z(65) / .Z(55) * .Z(70)
            Else
19940:          ETH = (.Z(3) + 2 * .Z(12)) / (.Z(9) - .Z(12)) * .Z(72)
            End If
            .Z(73) = ETH : .M(73) = ETH / psi
            a = 1.74 * .Z(53) * .Z(44) / (.Z(7) - .Z(12)) ^ 3 / (.Z(4) + .Z(7) + .Z(12))
            UNOPIU = 1 + .Z(43) * (.Z(9) - .Z(12)) / .Z(53)
19941:      b = .Z(73) / .Z(74) * UNOPIU
            MH = ETH / (a + b)
            .Z(75) = MH : .M(75) = MH / MomToBS
            x1 = (.Z(74) - MH * UNOPIU) / .Z(74)
            .M(52) = x1 : .Z(52) = x1
            ' 14-3(f)
19942:      c = 0.64 * .Z(43) * .Z(75) / (.Z(4) + 2 * .Z(12)) / (.Z(9) - .Z(12)) / .Z(53)
            G1g02 = ((.Z(8) - .Z(12)) / (.Z(7) - .Z(12))) ^ 2
19943:      SHS = x1 * ETH * 1.1 * .Z(53) * .Z(42) / G1g02 / (.Z(4) + 2 * .Z(12)) / .Z(44)
19944:      SRS = 1.91 * .Z(75) * UNOPIU / (.Z(4) + 2 * .Z(12)) / (.Z(9) - .Z(12)) ^ 2 + c
19945:      a = x1 * ETH * (.Z(9) - .Z(12)) / (.Z(4) + 2 * .Z(12))
19946:      b = 0.57 * UNOPIU * .Z(75) / (.Z(4) + 2 * .Z(12)) / (.Z(9) - .Z(12)) ^ 2
            STS = a - b + c * .Z(41)
            SHO = x1 * .Z(70)
            SRO = x1 * .Z(71)
            STO = x1 * .Z(72) + c * .Z(64)
            .Z(76) = SHS : .Z(77) = SRS : .Z(78) = STS : .Z(79) = (SHS + SRS) / 2 : .Z(80) = (SHS + STS) / 2
            .Z(24) = SHO : .Z(25) = SRO : .Z(26) = STO : .Z(27) = (SHO + SRO) / 2 : .Z(28) = (SHO + STO) / 2
            For i = 24 To 28
                .M(i) = .Z(i) / psi
                .M(i + 52) = .Z(i + 52) / psi
            Next
            Sfo = .Z(23)
            If RicercaSpessore Then GoTo 10251 Else GoTo 10271
10251:      If (SHS > (Sfo * 1.5)) Or SRS > Sfo Or STS > Sfo Or .Z(79) > Sfo Or .Z(80) > Sfo Then s = s + 1 : GoTo 9931
            If (SHO > (Sfo * 1.5)) Or SRO > Sfo Or STO > Sfo Or .Z(27) > Sfo Or .Z(28) > Sfo Then s = s + 1 : GoTo 9931
            .M(9) = s + .M(12)
            .Z(9) = .M(9) / inc
10271:      pagina = 7
            Exit Sub
11001:      If Err.Number = 5 Or Err.Number = 6 Then
                Testo = Involucr(kLato, jInvolucr).Mark.Trim & ".|"
                Testo = Testo & "Mancano dati essenziali nell'input"
                Testo = Testo & "|(" & Str(Erl()) & "," & Err.Description & ")"
                MessageBox.Show(formTab, clsInizio.ConvertiCr(Testo))
                qbflan = -99
                Resume 10271
            Else
                Resume
                MessageBox.Show(formTab, "App14 " & Err.Description & Str(Erl()))
            End If
        End With
    End Sub

    Sub FattForm(ByRef a As Single, ByRef c As Single, ByRef Ind65 As Short, ByRef Ind66 As Short, ByRef Ind67 As Short)
        Dim c3, c1, c2, c4 As Single
        Dim c7, C5, c6, c8 As Single
        Dim c11, c9, c10, c12 As Single
        Dim c15, c13, c14, c16 As Single
        Dim c19, c17, c18, c20 As Single
        Dim c23, c21, c22, c24 As Single
        Dim c27, c25, c26, c28 As Single
        Dim c31, c29, c30, c32 As Single
        Dim c35, c33, c34, c36 As Single
        Dim c37 As Single
        Dim E3, E1, E2, E4 As Single
        Dim f, E5, E6, Fl As Single
        Dim VL, V, FMIN As Single
        'fattori di forma
        c1 = 1 / 3 + a / 12
        c2 = 5 / 42 + 17 * a / 336
        c3 = 1 / 210 + a / 360
        c4 = 11 / 360 + 59 * a / 5040 + (1 + 3 * a) / c
        C5 = 1 / 90 + 5 * a / 1008 - (1 + a) ^ 3 / c
        c6 = 1 / 120 + 17 * a / 5040 + 1 / c
        c7 = 215 / 2772 + 51 * a / 1232 + (60 / 7 + 225 * a / 14 + 75 * a ^ 2 / 7 + 5 * a ^ 3 / 2) / c
        c8 = 31 / 6930 + 128 * a / 45045.0! + (6 / 7 + 15 * a / 7 + 12 * a ^ 2 / 7 + 5 * a ^ 3 / 11) / c
        c9 = 533 / 30240 + 653 * a / 73920.0! + (1 / 2 + 33 * a / 14 + 39 * a ^ 2 / 28 + 25 * a ^ 3 / 84) / c
        c10 = 29 / 3780 + 3 * a / 704 - (1 / 2 + 33 * a / 14 + 81 * a ^ 2 / 28 + 13 * a ^ 3 / 12) / c
        c11 = 31 / 6048 + 1763 * a / 665280.0! + (1 / 2 + 6 * a / 7 + 15 * a ^ 2 / 28 + 5 * a ^ 3 / 42) / c
        c12 = 1 / 2925 + 71 * a / 300300.0! + (8 / 35 + 18 * a / 35 + 156 * a ^ 2 / 385 + 6 * a ^ 3 / 55) / c
        c13 = 761 / 831600.0! + 937 * a / 1663200.0! + (1 / 35 + 6 * a / 35 + 11 * a ^ 2 / 70 + 3 * a ^ 3 / 70) / c
        c14 = 197 / 415800.0! + 103 * a / 332640.0! - (1 / 35 + 6 * a / 35 + 17 * a ^ 2 / 70 + a ^ 3 / 10) / c
        c15 = 233 / 831600.0! + 97 * a / 554400.0! + (1 / 35 + 3 * a / 35 + a ^ 2 / 14 + 2 * a ^ 3 / 105) / c
        c16 = c1 * c7 * c12 + c2 * c8 * c3 + c3 * c8 * c2 - (c3 ^ 2 * c7 + c8 ^ 2 * c1 + c2 ^ 2 * c12)
        c17 = (c4 * c7 * c12 + c2 * c8 * c13 + c3 * c8 * c9 - (c13 * c7 * c3 + c8 ^ 2 * c4 + c12 * c2 * c9)) / c16
        c18 = (C5 * c7 * c12 + c2 * c8 * c14 + c3 * c8 * c10 - (c14 * c7 * c3 + c8 ^ 2 * C5 + c12 * c2 * c10)) / c16
        c19 = (c6 * c7 * c12 + c2 * c8 * c15 + c3 * c8 * c11 - (c15 * c7 * c3 + c8 ^ 2 * c6 + c12 * c2 * c11)) / c16
        c20 = (c1 * c9 * c12 + c4 * c8 * c3 + c3 * c13 * c2 - (c3 ^ 2 * c9 + c13 * c8 * c1 + c12 * c4 * c2)) / c16
        c21 = (c1 * c10 * c12 + C5 * c8 * c3 + c3 * c14 * c2 - (c3 ^ 2 * c10 + c14 * c8 * c1 + c12 * C5 * c2)) / c16
        c22 = (c1 * c11 * c12 + c6 * c8 * c3 + c3 * c15 * c2 - (c3 ^ 2 * c11 + c15 * c8 * c1 + c12 * c6 * c2)) / c16
        c23 = (c1 * c7 * c13 + c2 * c9 * c3 + c4 * c8 * c2 - (c3 * c7 * c4 + c8 * c9 * c1 + c2 ^ 2 * c13)) / c16
        c24 = (c1 * c7 * c14 + c2 * c10 * c3 + C5 * c8 * c2 - (c3 * c7 * C5 + c8 * c10 * c1 + c2 ^ 2 * c14)) / c16
        c25 = (c1 * c7 * c15 + c2 * c11 * c3 + c6 * c8 * c2 - (c3 * c7 * c6 + c8 * c11 * c1 + c2 ^ 2 * c15)) / c16
        c26 = -(c / 4) ^ (1 / 4)
        c27 = c20 - c17 - 5 / 12 + (c17 * c26)
        c28 = c22 - c19 - 1 / 12 + (c19 * c26)
        c29 = -(c / 4) ^ (1 / 2)
        c30 = -(c / 4) ^ (3 / 4)
        c31 = 3 * a / 2 - c17 * c30
        c32 = 1 / 2 - c19 * c30
        c33 = 0.5 * c26 * c32 + c28 * c31 * c29 - (0.5 * c30 * c28 + c32 * c27 * c29)
        c34 = 1 / 12 + c18 - c21 - c18 * c26
        c35 = -c18 * (c / 4) ^ (3 / 4)
        c36 = (c28 * c35 * c29 - c32 * c34 * c29) / c33
        c37 = (0.5 * c26 * c35 + c34 * c31 * c29 - (0.5 * c30 * c34 + c35 * c27 * c29)) / c33
        E1 = c17 * c36 + c18 + c19 * c37
        E2 = c20 * c36 + c21 + c22 * c37
        E3 = c23 * c36 + c24 + c25 * c37
        E4 = 1 / 4 + c37 / 12 + c36 / 4 - E3 / 5 - 3 * E2 / 2 - E1
        E5 = E1 * (1 / 2 + a / 6) + E2 * (1 / 4 + 11 * a / 84) + E3 * (1 / 70 + a / 105)
        E6 = E5 - c36 * (7 / 120 + a / 36 + 3 * a / c) - 1 / 40 - a / 72 - c37 * (1 / 60 + a / 120 + 1 / c)
        f = -(E6 / ((c / 2.73) ^ (1 / 4) * ((1 + a) ^ 3 / c)))
        Fl = -(c18 * (1 / 2 + a / 6) + c21 * (1 / 4 + 11 * a / 84) + c24 * (1 / 70 + a / 105) - (1 / 40 + a / 72)) / ((c / 2.73) ^ (1 / 4) * ((1 + a) ^ 3 / c))
        V = E4 / ((2.73 / c) ^ (1 / 4) * (1 + a) ^ 3)
        VL = (1 / 4 - c24 / 5 - 3 * c21 / 2 - c18) / ((2.73 / c) ^ (1 / 4) * (1 + a) ^ 3)
        FMIN = c36 / (1 + a)
        If f < 0.5 Then f = 0.5
        If f > 0.90892 Then f = 0.90892
        If Fl < 0.4 Then Fl = 0.4
        If Fl > 20 Then Fl = 20
        If V < 0 Then V = 0
        If V > 0.550103 Then V = 0.550103
        If VL < 0.01 Then VL = 0.01
        If VL > 120 Then VL = 120
        If FMIN < 1 Then FMIN = 1
        If FMIN > 25 Then FMIN = 25
        If Mem.LOOSE = 1 Then
            FMIN = 1 '.LOOSE with hubs
            V = VL
            f = Fl
        End If
        Mem.Z(Ind65) = FMIN : Mem.Z(Ind66) = f : Mem.Z(Ind67) = V
        Mem.M(Ind65) = Mem.Z(Ind65) : Mem.M(Ind66) = Mem.Z(Ind66) : Mem.M(Ind67) = Mem.Z(Ind67)
    End Sub
    Sub FattTUYZ(ByRef k As Single, ByRef t As Single, ByRef u As Single, ByRef y As Single, ByRef Z As Single)
        t = (k ^ 2 * (1 + 8.55246 * (System.Math.Log10(k))) - 1) / ((1.0472 + 1.9448 * k ^ 2) * (k - 1))
        u = (k ^ 2 * (1 + 8.55246 * (System.Math.Log10(k))) - 1) / (1.36136 * (k ^ 2 - 1) * (k - 1))
        y = (1 / (k - 1)) * (0.66845 + 5.7169 * (k ^ 2 * (System.Math.Log10(k))) / (k ^ 2 - 1))
        Z = (k ^ 2 + 1) / (k ^ 2 - 1)
    End Sub

    Function IndPos(ByRef indice As Short) As Short
        Dim PagSav, pagV As Short
        Dim i As Short
        Try
            PagSav = pagina
            pagina = 0
            Do
                pagV = pagina
                pagina = pagina + 1
                Call formTab.SetPagina(0)
                If pagina = pagV Then Exit Do
                For i = WWW To FFF
                    If PosVARI(i) = indice Then IndPos = i : Exit Do
                Next
            Loop
            pagina = PagSav
            Call formTab.SetPagina(0)
        Catch e As Exception
            MessageBox.Show(formTab, e.Message + vbCrLf + e.StackTrace)
        End Try
    End Function
    Sub PreliminF()
        Dim cB, gef As Single
6090:   Call LarghGua()
        If qbflan = 1 Or qbflan = -99 Then Exit Sub
        Call CalcGef()
        Call CarPress()
        If qbflan = 1 Or qbflan = -99 Then Exit Sub
        If Not ScelTir() Then qbflan = -99 : Exit Sub
        If qbflan = -2 Then
            '  If Abs(1 - m(46) / m(45)) < 0.01 Then Exit Sub
            '  m(1) = m(1) * m(46) / m(45): Z(1) = Z(1) * m(46) / m(45)
            '  icount = icount + 1
            '  If icount > 100 Then Exit Sub
            '  GoTo 6090
        End If
        If qbflan = 1 Or qbflan = 5 Or qbflan = -99 Then Exit Sub
        If qbflan >= 0 Then
            Call SchiaccGuar()
            If qbflan = 1 Or qbflan = -99 Then Exit Sub
            If qbflan = 2 Then qbflan = 0 : GoTo 6090
            Call ContrBS()
            If qbflan = 1 Or qbflan = 3 Or qbflan = -99 Then Exit Sub
            Call DiamExtwn() : If qbflan = -99 Then Exit Sub
            Call DefR() : If qbflan = -99 Then Exit Sub
            If qbflan = 2 Then qbflan = 0 : GoTo 6090
        End If
        cB = Mem.M(4) : gef = Mem.M(37)
        Mem.M(49) = 0.5 * (cB - gef) : Mem.Z(49) = Mem.M(49) / inc
    End Sub

    Sub PreliminG()
        With Mem
            .Z(50) = pi / 4 * .Z(3) * .Z(3) * System.Math.Abs(.Z(1)) 'Hd
            .Z(51) = pi / 4 * (.Z(4) * .Z(4) - .Z(3) * .Z(3)) * System.Math.Abs(.Z(1)) 'Ht
            .M(50) = .Z(50) * NIUT : .M(51) = .Z(51) * NIUT
            .M(47) = (.M(4) - .M(3) - .M(5) + .M(12)) / 2 'hd
            .M(48) = (.M(4) - .M(3)) / 4 'ht
            .Z(47) = .M(47) / inc : .Z(48) = .M(48) / inc
        End With
    End Sub

    Sub ProgCod(ByRef jwn As Short, ByRef IndG0 As Short, ByRef IndB As Short, _
        ByRef IndG1 As Short, ByRef IndH As Short)
        Dim G1V(1) As Single
        Dim G0V(1) As Single
        Dim HV(1) As Single
        Dim Corr As Single
        Dim Ind7, Ind8 As Short
        Dim Testo As String
        Dim Stringa(5) As String
        Dim x As Short
        Dim n As Short
        Dim Testo1 As String = ""
        With Mem
6140:       wnlj(jwn).H = .M(IndH)
            wnlj(jwn).g0 = .M(IndG0)
            wnlj(jwn).g1 = .M(IndG1)
            wnlj(jwn).b = .M(IndB)
6150:       If wnlj(jwn).b = 0 Or wnlj(jwn).g0 = 0 Then
                If wnlj(jwn).g0 = 0 Then
                    Ind = IndPos(IndG0)
                    If InStr(CVARI(Ind), "*") = 0 Then CVARI(Ind) = CVARI(Ind) & "*"
                End If
                If wnlj(jwn).b = 0 Then
                    Ind = IndPos(IndB)
                    If InStr(CVARI(Ind), "*") = 0 Then CVARI(Ind) = CVARI(Ind) & "*"
                End If
                pagina = 1 : qbflan = 1
                Exit Sub
            End If
            If wnlj(jwn).H = 0 Then wnlj(jwn).H = Int(wnlj(jwn).g0 * 1.5) + 1
            If wnlj(jwn).H < 25 Then wnlj(jwn).H = 25
            If .LOOSE = 7 Then Corr = 0 Else Corr = wnlj(jwn).co
            wnlj(jwn).H0 = System.Math.Sqrt((wnlj(jwn).b + 2 * Corr) * (wnlj(jwn).g0 - wnlj(jwn).co))
            If wnlj(jwn).g1 = 0 Then wnlj(jwn).g1 = Int((wnlj(jwn).g0 - wnlj(jwn).co) * 2.718281828 ^ ((0.01 + 3.8 * (wnlj(jwn).H / wnlj(jwn).H0) ^ 4 - 5.83 * (wnlj(jwn).H / wnlj(jwn).H0) ^ 3 + 3.8 * (wnlj(jwn).H / wnlj(jwn).H0) ^ 2 + 1.5 * (wnlj(jwn).H / wnlj(jwn).H0)) / (2 + 5 * 2.718281828 ^ (4 * ((wnlj(jwn).H / wnlj(jwn).H0) - 1.5)))) + wnlj(jwn).co) + 1
            If wnlj(jwn).g1 < wnlj(jwn).g0 Then
                Ind7 = IndPos(IndG0) : Ind8 = IndPos(IndG1)
                If InStr(CVARI(Ind7), "*") = 0 Then CVARI(Ind7) = CVARI(Ind7) & "*"
                If InStr(CVARI(Ind8), "*") = 0 Then CVARI(Ind8) = CVARI(Ind8) & "*"
                MessageBox.Show(formTab, "g1 non può essere inferiore a g0")
                pagina = 1 : qbflan = 1
                Exit Sub
            End If
            If ((wnlj(jwn).g1 - wnlj(jwn).g0) > (wnlj(jwn).H / 3)) And .M(IndH) = 0 Then
                wnlj(jwn).H = Int((wnlj(jwn).g1 - wnlj(jwn).g0) * 3) + 1 : GoTo 6150
            End If
            If ((wnlj(jwn).g1 - wnlj(jwn).g0) > (wnlj(jwn).H / 3)) And .M(IndH) <> 0 Then GoTo 6300
            If .M(IndH) <> 0 And .M(IndH) < 25 Then GoTo 6300
            If .M(IndH) <> 0 And .M(IndH) < wnlj(jwn).g0 * 1.5 Then GoTo 6300
6240:       .M(IndH) = wnlj(jwn).H
            .Z(IndH) = .M(IndH) / inc
            .M(IndG0) = wnlj(jwn).g0 : .Z(IndG0) = .M(IndG0) / inc
            .M(IndG1) = wnlj(jwn).g1 : .Z(IndG1) = .M(IndG1) / inc
            Exit Sub
6300:       'AVVISO controllo altezza G1 e H
            If Conferma(jwn) And HV(jwn) = .M(IndH) And G0V(jwn) = .M(IndG0) And G1V(jwn) = .M(IndG1) Then GoTo 6240
            HV(jwn) = .M(IndH) : G0V(jwn) = .M(IndG0) : G1V(jwn) = .M(IndG1)
            Testo = "Le dimensioni g0, g1 e h dello hub"
            If .LOOSE > 4 Then
                If jwn = 0 Then Testo = Testo & "(opening)"
                If jwn = 1 Then Testo = Testo & "(shell)"
            End If
            Testo = Testo & "|non sono compatibili."
            Testo1 = Testo
            Testo = Testo & "|     Cosa vuoi fare ?            "
            Stringa(1) = "con  h (impostato) = " & GlobalRoutines.myStr(CSng(wnlj(jwn).H), 4, 2, False) & ": g1 = " & GlobalRoutines.myStr(CSng(Int((wnlj(jwn).H / 3) + wnlj(jwn).g0)), 4, 2, True)
            Testo1 = Testo1 & "|" & Stringa(1)
            Stringa(2) = "con g1 (impostato) = " & GlobalRoutines.myStr(CSng(wnlj(jwn).g1), 4, 2, False) & ": h  = " & GlobalRoutines.myStr(CSng(Int((wnlj(jwn).g1 - wnlj(jwn).g0) * 3) + 1), 4, 2, True)
            Testo1 = Testo1 & "|" & Stringa(2)
            Stringa(3) = "Imposta  nuovi  dati"
            Stringa(4) = "Conferma i dati impostati"
            n = 4
            Dim nn As String = 4
            Dim Testo2 As String = ""
            If .M(IndH) <> 0 And .M(IndH) < 25 Then
                Testo2 = "| N.B.: La lunghezza minima del codolo è 25 mm "
                Stringa(1) = "con  h (impostato) = " & GlobalRoutines.myStr(CSng(wnlj(jwn).H), 4, 2, False) & ": g0 = " & GlobalRoutines.myStr(CSng(CShort(wnlj(jwn).H / 1.5)), 4, 2, True)
                Stringa(2) = "con g0 (impostato) = " & GlobalRoutines.myStr(CSng(wnlj(jwn).g0), 4, 2, False) & ": h  = " & GlobalRoutines.myStr(CSng(Int((wnlj(jwn).g0) * 1.5) + 1), 4, 2, True)
                Stringa(3) = "Imposta  nuovi  dati"
                Stringa(4) = "Conferma i dati impostati"
                n = 4
                nn = 2
            End If
            If .M(IndH) <> 0 And .M(IndH) < wnlj(jwn).g0 * 1.5 Then
                Testo2 = "| N.B.: La lunghezza minima del codolo è 1.5 * g0"
                Stringa(1) = "con  h (impostato) = " & GlobalRoutines.myStr(CSng(wnlj(jwn).H), 4, 2, False) & ": g0 = " & GlobalRoutines.myStr(CSng(CShort(wnlj(jwn).H / 1.5)), 4, 2, True)
                Stringa(2) = "con g0 (impostato) = " & GlobalRoutines.myStr(CSng(wnlj(jwn).g0), 4, 2, False) & ": h  = " & GlobalRoutines.myStr(CSng(Int((wnlj(jwn).g0) * 1.5) + 1), 4, 2, True)
                Stringa(3) = "Imposta  nuovi  dati"
                Stringa(4) = "Conferma i dati impostati"
                n = 4
                nn = 2
            End If
            Testo = Testo & Testo2
            x = 4
            If Not Conferma(jwn) Then
                If qbflan > -1 Then
                    If Not ContinuoAuto Then
                        x = Monitor.Motore.Quale(n, "Controllo hub", Stringa, "", 1, clsInizio.ConvertiCr(Testo))
                    Else
                        PrintlstRes(Testo1)
                        x = 4
                    End If
                Else
                    x = 4
                End If
            End If
            Select Case x
                Case 0 : qbflan = -99 : Exit Sub
                Case 1
                    If nn = 2 Then
                        .M(IndG0) = CSng(Int((wnlj(jwn).g0) * 1.5) + 1)
                    Else
                        .M(IndG1) = Int((wnlj(jwn).H / 3) + wnlj(jwn).g0)
                    End If
                    GoTo 6140
                Case 2
                    If nn = 2 Then
                        .M(IndH) = CSng(Int((wnlj(jwn).g0) * 1.5) + 1)
                        If .M(IndH) < 25 And wnlj(jwn).g1 > wnlj(jwn).g0 Then .M(IndH) = 25
                    Else
                        .M(IndH) = Int((wnlj(jwn).g1 - wnlj(jwn).g0) * 3) + 1
                    End If
                    GoTo 6140
                Case 3
                    pagina = 1 : .M(IndG1) = 0
                    .M(IndH) = 0 : qbflan = 1
                    Exit Sub
                Case 4 : .Conforme = "NO"
                    Conferma(jwn) = True
                    GoTo 6240
            End Select
        End With
    End Sub

    Private Sub Step1()
        With Mem
            If qbflan > 0 Then qbflan = 0
6091:       If .Z(22) = 0 Then .Z(22) = .Z(23) : .M(22) = .M(23)
            If .Z(23) = 0 Then .Z(23) = .Z(22) : .M(23) = .M(22)
            .Z(82) = .Z(23) * 1.5 : .M(82) = .M(23) * 1.5
            .VERIFICA = "SI" : .Conforme = "SI" : Fermo = 0
        End With
    End Sub

    Sub wnflan()
        Dim IndB As Short
        Dim jwn As Short 'NON DEFINITO
        Dim R, cB As Single
        Dim ht, HD, HG As Single
        Dim gef As Single
        Dim HC, wm1, a As Single
        Dim k, c, t As Single
        Dim y, u, Zf As Single
        Dim d, V, E As Single
        Dim s, f, l As Single
        Dim MT, MD, MG As Single
        Dim mo, j, MW As Single
        Dim Cf, m0, fc As Single
        Dim SR, Sfo, Sfa, SH, St As Single
        Dim SM1, fact, St2, SM2 As Single
        Dim Sn As Single
        With Mem
            Try
                Call Step1()
                '       IF .LOOSE=-1 THEN GOTO 6490    ??????????????
6130:           'PROGETTO DIMENSIONI CODOLO FLANGIA
                wnlj(0).co = .M(11)
                IndB = 6 : If .LOOSE = 7 Then IndB = 3
                Call ProgCod(0, 7, IndB, 8, 10)
                If qbflan = 1 Or qbflan = -99 Then Exit Sub
                .M(55) = wnlj(jwn).H0 : .Z(55) = .M(55) / inc
6241:           .M(56) = wnlj(jwn).H / wnlj(jwn).H0 : .Z(56) = .Z(10) / .Z(55)
6490:           Call PreliminF()
                If qbflan = 1 Or qbflan = 3 Or qbflan = 5 Or qbflan = -99 Then Exit Sub
9030:           'definizione dei bracci per i momenti
                R = .M(19) : wnlj(0).g1 = .M(8)
                cB = .M(4) : gef = .M(37) : wnlj(0).co = .M(11)
                HG = 0.5 * (cB - gef)
                If .LOOSE = 7 Then
                    HD = (cB - .M(3) + wnlj(0).g1 - wnlj(0).co) / 2
                    ht = 0.5 * (cB - (.M(3) - 2 * wnlj(0).g0 + 2 * wnlj(0).co + gef) / 2)
                Else
                    HD = R + 0.5 * (wnlj(0).g1 - wnlj(0).co)
                    ht = 0.5 * (R + wnlj(0).g1 + HG - wnlj(0).co)
                End If
                .M(47) = HD : .Z(47) = .M(47) / inc
                .M(49) = HG : .Z(49) = .M(49) / inc
                .M(48) = ht : .Z(48) = .M(48) / inc
                'definizione carichi per i momenti
                If .LOOSE = 7 Then
                    wnlj(0).b = .Z(3) - 2 * .Z(7) + 2 * .Z(11)
                Else
                    wnlj(0).b = .Z(6) + 2 * .Z(11)
                End If
                wnlj(0).H = .Z(39) : wnlj(0).W = .Z(42)
                HD = (pi / 4) * wnlj(0).b ^ 2 * System.Math.Abs(.Z(1))
                ht = wnlj(0).H - HD
                .Z(50) = HD : .M(50) = .Z(50) * NIUT
                .Z(51) = ht : .M(51) = .Z(51) * NIUT
                If Z33 >= .Z(40) Then wm1 = Z33 Else wm1 = .Z(40)
                'HG = .z(38): .z(52) = HG: .m(52) = .m(38)'???????????????
                'HG = .z(42) - .z(39): .z(52) = HG: .m(52) = .m(42) - .m(39)
                If .Z(1) > 0 Then
                    HG = wm1 - .Z(39)
                Else
                    HG = 0
                End If
                .Z(52) = HG : .M(52) = .Z(52) * NIUT
9032:           'calcolo fattori di forma per flange a codolo
                wnlj(0).g1 = .Z(8) : wnlj(0).g0 = .Z(7) : wnlj(0).co = .Z(11)
                HC = .Z(10) : wnlj(0).H0 = .Z(55)
                a = ((wnlj(0).g1 - wnlj(0).co) / (wnlj(0).g0 - wnlj(0).co)) - 1
                .Z(57) = a : .M(57) = a
                c = 43.68 * (HC / wnlj(0).H0) ^ 4
                .Z(56) = (HC / wnlj(0).H0) : .M(56) = .Z(56)
                Call FattForm(a, c, 65, 66, 67)
                'fattori T - U - Y - Z - K per flangie ASME
9034:           a = .Z(3) : wnlj(0).b = .Z(6) + 2 * .Z(11)
                k = a / wnlj(0).b
                Call FattTUYZ(k, t, u, y, Zf)
                .Z(54) = k : .Z(61) = t : .Z(62) = u : .Z(63) = y : .Z(64) = Zf
                .M(54) = k : .M(61) = t : .M(62) = u : .M(63) = y : .M(64) = Zf
9035:           If .LOOSE = 7 Then
                    .Z(188) = (1 + 0.668 * (k + 1) / y) / k / k 'alfar
                    .Z(189) = (Zf + 0.3) / (Zf - 0.3) * .Z(188) * t 'Tr
                    .Z(190) = .Z(188) * u
                    .Z(191) = .Z(188) * y
                    .M(188) = .Z(188) : .M(189) = .Z(189) : .M(190) = .Z(190) : .M(191) = .Z(191)
                    u = .Z(190)
                    t = .Z(189)
                    y = .Z(191)
                End If
                'calcolo (d-e)
9036:           V = .Z(67) : f = .Z(66)
                wnlj(0).H0 = .M(55) : wnlj(0).g0 = .M(7) : wnlj(0).co = .M(11)
                d = (u / V) * wnlj(0).H0 * (wnlj(0).g0 - wnlj(0).co) ^ 2
                E = f / wnlj(0).H0
                .M(58) = d : .M(59) = E
                wnlj(0).H0 = .Z(55) : wnlj(0).g0 = .Z(7) : wnlj(0).co = .Z(11)
                d = (u / V) * wnlj(0).H0 * (wnlj(0).g0 - wnlj(0).co) ^ 2
                E = f / wnlj(0).H0
                .Z(58) = d : .Z(59) = E
                'calcolo spessore di progetto e fattore L
                s = .M(9) : If .LOOSE = 7 Then s = .M(9) - .M(11)
                If s <= 0 Then
                    s = (Int(.M(14) / 5) + 1) * 5
                    If .LOOSE = 7 Then s = s + .M(11)
                End If
9930:           E = .M(59) : d = .M(58) 'T = .m(61):
                l = ((s * E + 1) / t) + (s ^ 3 / d) : .M(60) = l : .Z(60) = l
                '       LOCATE 10, 25, 0: PRINT "Spessore flangia in verifica :"
                '       LOCATE 12, 33, 0: COLOR 0, 7: PRINT USING " ####.##   mm "; S: COLOR 7, 0
                'calcolo momenti
                If .Z(1) > 0 Then
                    MD = .M(50) * .M(47)
                    MT = .M(51) * .M(48)
                    MG = .M(52) * .M(49)
                Else
                    MD = (.M(47) - .M(49)) * .M(50)
                    MT = (.M(48) - .M(49)) * .M(51)
                    MG = 0
                End If
                .M(68) = MD
                .M(69) = MT
                .M(70) = MG
                .Z(68) = .M(68) * MomToBS
                .Z(69) = .M(69) * MomToBS
                .Z(70) = .M(70) * MomToBS
9932:           j = .M(23) / .M(22) : .M(71) = j : .Z(71) = j
                mo = System.Math.Abs(MD + MT + MG) : .M(72) = mo : .Z(72) = .M(72) * MomToBS
9933:           MW = .M(42) * .M(49) : .M(73) = MW : .Z(73) = .M(73) * MomToBS
                If mo > (MW * j) Then m0 = mo Else m0 = (MW * j)
                .M(74) = m0 : .Z(74) = .M(74) * MomToBS
                'calcolo fattore Cf
9934:           c = .M(4) : wnlj(0).n = .M(13) : DN = .M(14) : wnlj(0).m = .M(30)
                Cf = System.Math.Sqrt((pi * c) / ((wnlj(0).n * (2 * DN + (6 * s / (wnlj(0).m + 0.5)))))) : If Cf < 1 Then Cf = 1
                .M(53) = Cf : .Z(53) = Cf
                'calcolo carico per sollecitazioni
                wnlj(0).b = .M(6) + 2 * .M(11) : m0 = .M(74)
                wnlj(0).m = (m0 * Cf) / wnlj(0).b : .M(75) = wnlj(0).m : .Z(75) = wnlj(0).m * 0.224808924
                'calcolo sollecitazioni
9938:           fc = .M(65) : wnlj(0).g1 = .M(8) - .M(11) ': Y = .m(63): Z = .m(64)
                E = .M(59) : l = .M(60)
                Sfa = .M(22) : Sfo = .M(23)
                SH = (fc * wnlj(0).m) / (l * wnlj(0).g1 ^ 2)
                SR = ((1.33 * s * E + 1) * wnlj(0).m) / (l * s * s)
                fact = 1
                If .LOOSE = 7 Then
                    fact = (0.67 * s * E + 1) / (1.33 * s * E + 1)
                    St2 = wnlj(0).m / s / s * (.M(63) - 2 * k * k * (1 + 2 / 3 * s * E) / (k * k - 1) / l)
                    .M(192) = St2 : .Z(192) = St2 * psi
                End If
                St = (y * wnlj(0).m / s ^ 2) - Zf * SR * fact
                SM1 = (SH + SR) / 2
                SM2 = (SH + St) / 2
                Sn = SH / 2.5
                .M(76) = SH : .M(77) = SR : .M(78) = St : .M(79) = SM1 : .M(80) = SM2 : .M(81) = Sn
                .Z(76) = SH * psi : .Z(77) = SR * psi : .Z(78) = St * psi : .Z(79) = SM1 * psi : .Z(80) = SM2 * psi : .Z(81) = Sn * psi
                If .M(9) = 0 Then GoTo 10250 Else GoTo 10270
10250:          If (SH > (Sfo * 1.5)) Or SR > Sfo Or St > Sfo Or (.LOOSE = 7 And St2 > Sfo) Or SM1 > Sfo Or SM2 > Sfo Then s = s + 1 : GoTo 9930
                .M(9) = s : If .LOOSE = 7 Then .M(119) = s : .M(9) = s + .M(11) : .Z(119) = .M(119) / inc
                .Z(9) = .M(9) / inc
10270:          pagina = 9
            Catch ex As Exception
                MessageBox.Show(formTab, ex.Message + vbCrLf + ex.StackTrace)
            End Try
        End With
    End Sub
    Private Sub CalcGef()
        Dim gef As Single
        With Mem
            wnlj(0).PHI = .M(31) : wnlj(0).n = .M(26) : wnlj(0).W = .M(29) : wnlj(0).g = .M(5)
            If wnlj(0).PHI = 1 Then wnlj(0).bo = wnlj(0).n / 2
            If wnlj(0).PHI = 2 Then wnlj(0).bo = (wnlj(0).W + wnlj(0).n) / 4
            If wnlj(0).PHI = 3 Then wnlj(0).bo = (wnlj(0).W + wnlj(0).n) / 4
            If wnlj(0).PHI = 4 Then wnlj(0).bo = (wnlj(0).W + 3 * wnlj(0).n) / 8
            If wnlj(0).PHI = 5 Then wnlj(0).bo = wnlj(0).n / 4
            If wnlj(0).PHI = 6 Then wnlj(0).bo = 3 * wnlj(0).n / 8
            If wnlj(0).PHI = 7 Then wnlj(0).bo = 7 * wnlj(0).n / 16
            If wnlj(0).PHI = 8 Then wnlj(0).bo = wnlj(0).n / 8
            .M(35) = wnlj(0).bo : .Z(35) = .M(35) / inc
            If .Z(35) < 0.25 Then wnlj(0).b = .Z(35) Else wnlj(0).b = 0.5 * System.Math.Sqrt(.Z(35))
            .Z(36) = wnlj(0).b : .M(36) = .Z(36) * inc
            If .Z(28) = 0 And Not .M(161) <= 14 Then
                gef = wnlj(0).g
            Else
6993:           If .Z(35) < 0.25 Then gef = wnlj(0).g Else gef = wnlj(0).g + wnlj(0).n - 2 * .M(36)
            End If
6994:       .M(37) = gef : .Z(37) = .M(37) / inc
        End With
    End Sub
    Private Sub CarPress()
        Dim Testo As String
        Dim Stringa(2) As String
        Dim factor As Single
        Dim I22, I24, I25, I23 As Short
        Dim I122, I123 As Short
        Dim HGY, HGP As Single
        Dim wm1, wm2 As Single
        Dim Sba, sbo As Single
        Dim am2, am1, am As Single
        Dim saldato As Boolean
        Static Wm1p, Wm2p As Single
        'calcolo carichi di pressione e di tenuta
        saldato = True
        With Mem
            If .M(161) = 14 And .Z(1) > 0 Then 'diaframma saldato
                wnlj(0).g = .Z(5) + .Z(26)
                .Z(198) = wnlj(0).g : .M(198) = .Z(198) * inc
            ElseIf .M(161) = 15 And .Z(1) > 0 Then  'labbra saldate
                wnlj(0).g = .Z(203)
                .Z(198) = wnlj(0).g : .M(198) = .Z(198) * inc
                If Not Check203() Then Exit Sub
            ElseIf .M(161) = 16 And .Z(1) > 0 Then  'omega
                wnlj(0).g = .Z(203) - 2 * .Z(202)
                .Z(198) = wnlj(0).g : .M(198) = .Z(198) * inc
                If Not Check203() Then Exit Sub
            Else
                wnlj(0).g = .Z(37)
                .M(198) = 0 : .Z(198) = 0
                saldato = False
            End If
            wnlj(0).b = .Z(36)
            wnlj(0).y = .Z(28)
            wnlj(0).m = .Z(30)
            If .M(161) = 1 And .M(162) >= 2 And .M(162) <= 4 Then
                'guarnizioni lenticolari
                'm richiesto dai bulloni meno effetto di fondo è pari all'm richiesto al
                'materiale - m messo a disposizione dall'effetto autoenergizzante:
                '     m'=m-W/(4b*tanalfa)
                ' si potrà in seguito aggiungere la considerazione della pressione di Hertz (da Roark):
                '       se p è il carico per unità di circonferenza:
                '        b=1.6sqr(pDC) con D 2 raggio di curv. e C=(1-ni**2)/E1+(1-ni**2)/E2)
                '        Y=.798sqr(p/(DC))  max press
                '        b=1.6*YDC/.798
                wnlj(0).m = .Z(30) - .Z(203) / (4 * .Z(36) * System.Math.Tan(.Z(201) * pi / 180))
            End If
            wnlj(0).wmt = .Z(32)
            If (.Z(28) = 0 And .Z(34) = 0 And .M(161) <> 1 And .M(161) < 14) Then
                Testo = "Non hai definito né l'Y "
                Testo = Testo & "|di guarnizione né Wm2"
                If Not ContinuoAuto Then
                    Testo = Testo & "|       Cosa vuoi fare ? "
                    Stringa(1) = "Definire Y"
                    Stringa(2) = "Definire Wm2"
                    Dim junk1 As Integer = Monitor.Motore.Quale(2, "Carico di serraggio " + Mem.FLID, Stringa, "", 1, clsInizio.ConvertiCr(Testo))
                    Select Case junk1
                        Case 0 : qbflan = -99 : Exit Sub
                        Case 1
                            Ind = IndPos(28)
                            If InStr(CVARI(Ind), "*") = 0 Then CVARI(Ind) = CVARI(Ind) & "*"
                            qbflan = 1
                            pagina = 3
                            Exit Sub
                        Case 2
                            Ind = IndPos(28)
                            If InStr(CVARI(Ind), "*") = 0 Then CVARI(Ind) = CVARI(Ind) & "*"
                            qbflan = 1
                            pagina = 4
                            Exit Sub
                    End Select
                Else
                    Testo = clsInizio.ConvertiCr(Testo + "|per la flangia " + Mem.FLID)
                    PrintlstRes(Testo)
                    MessageBox.Show(Testo, "Carico di serraggio", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    qbflan = -99
                    Exit Sub
                End If
            End If
7190:       '*****************************
            If .Z(1) < 0 Then
                HGY = (pi * wnlj(0).b * wnlj(0).g * wnlj(0).y) + wnlj(0).wmt
                HGP = 0
                .Z(38) = HGP : .M(38) = .Z(38) * NIUT
                wnlj(0).H = -pi / 4 * wnlj(0).g ^ 2 * .Z(1)
                .Z(39) = wnlj(0).H : .M(39) = .Z(39) * NIUT
                wm1 = 0
                wm2 = HGY
            Else
                HGY = (pi * wnlj(0).b * .Z(37) * wnlj(0).y) + wnlj(0).wmt
                If LoadCond = 1 Or VerificandoPI Or Not saldato Then
                    HGP = 2 * (pi * .Z(37) * wnlj(0).b + .Z(167) * .Z(169) / 2) * wnlj(0).m * .Z(1)
                    wnlj(0).H = pi / 4 * .Z(37) ^ 2 * .Z(1)
                Else
                    HGP = 0
                    wnlj(0).H = pi / 4 * wnlj(0).g ^ 2 * .Z(1)
                End If
                .Z(38) = HGP : .M(38) = .Z(38) * NIUT
                .Z(39) = wnlj(0).H : .M(39) = .Z(39) * NIUT
                wm1 = wnlj(0).H + HGP
                wm2 = HGY
            End If
            wnlj(0).g = .Z(37)
            If Configwn.FullBolt = 2 And LoadCond > 1 And Configwn.LatoProgetto > 0 Then 'Fluor Daniel
                If Config(1).pxTest = 0 Then Config(1).pxTest = 1.5 * Config(1).p0x
                If Config(2).pxTest = 0 Then Config(2).pxTest = 1.5 * Config(2).p0x
                If Configwn.LatoProgetto = 1 Then factor = Config(2).pxTest / Config(2).p0x Else factor = Config(1).pxTest / Config(1).p0x
                wm2 = wm1 + wm2
                wm1 = wm1 * factor
            End If
            .Z(40) = wm1 : .M(40) = .Z(40) * NIUT
            .Z(41) = wm2 : .M(41) = .Z(41) * NIUT
            If LoadCond = 1 Or VerificandoPI Then
                Z33 = .Z(193)
                Z34 = .Z(194)
            Else
                Z33 = .Z(33)
                Z34 = .Z(34)
            End If
            Dim junk As ChiaviMess
            If VerificandoPI Or SuperOtt Then
                junk = ChiaviMess.Messno
            Else
                If qbflan > -1 And (((.Z(40) > Z33 * 1.0001) And Z33 <> 0) Or ((.Z(41) > Z34 * 1.0001) And Z34 <> 0) And (Not ConfermaCP Or Not (Wm1p = Z33 And Wm2p = Z34))) Then
7270:               ConfermaCP = False : Wm1p = Z33 : Wm2p = Z34 'AVVISO Wm1 o Wm2 calcolato maggiore di quelli imposti
                    Testo = "Wm1 o Wm2 calcolato è maggiore di quello imposto: (carichi in kN)|"
                    Testo = Testo & " Wm1 (imposto) =" & GlobalRoutines.myStr(Z33 * NIUT / 1000, 9, 2, False) & " Wm1 calcolato = " & GlobalRoutines.myStr(.Z(40) * NIUT / 1000, 9, 2, False)
                    Testo = Testo & "|Wm2 (imposto) =" & GlobalRoutines.myStr(Z34 * NIUT / 1000, 9, 2, False) & " Wm2 calcolato = " & GlobalRoutines.myStr(.Z(41) * NIUT / 1000, 9, 2, False)
                    Testo = Testo & "|Vuoi modificare (Si) gli imposti o confermare (No) i calcolati?"
                    If ContinuoAuto Then
                        junk = ChiaviMess.Messno
                    Else
                        junk = Monitor.Motore.Messaggio(clsInizio.ConvertiCr(Testo), _
                        ChiaviMess.MessQuestion Or ChiaviMess.MessYesNo Or ChiaviMess.MessHelpButton, _
                        "AsmeVip", RadiceHelp, "AvvCaricoImposto.htm#CalcInfImposto", True)
                    End If
                End If
                If junk = ChiaviMess.MessSi Then
                    pagina = 4
                    If LoadCond = 1 Then
                        .Z(193) = 0 : .Z(194) = 0
                    Else
                        .Z(33) = 0 : .Z(34) = 0
                    End If
                    qbflan = 1
                    Exit Sub
                End If
                ConfermaCP = True
            End If
7390:       'scelta del Wm1 e del Wm2 da usare nel calcolo
            If LoadCond <= 2 Then
                If Z33 >= .Z(40) Then wm1 = Z33 Else wm1 = .Z(40)
                If Z34 >= .Z(41) Then wm2 = Z34 Else wm2 = .Z(41)
            End If
            'calcolo area dei tiranti
            Z33 = wm1 : Z34 = wm2 ': .z(34) = Z34
            If LoadCond = 1 Or VerificandoPI Then
                .Z(193) = Z33 : .Z(194) = Z34
                .M(193) = .Z(193) * NIUT : .M(194) = .Z(194) * NIUT
            Else
                .Z(33) = Z33 : .Z(34) = Z34
                .M(33) = .Z(33) * NIUT : .M(34) = .Z(34) * NIUT
            End If
            If .Z(24) = 0 Then .Z(24) = .Z(25) : .M(24) = .M(25)
            If .Z(25) = 0 Then .Z(25) = .Z(24) : .M(25) = .M(24)
            If .LOOSE = 4 And (.Z(22) = 0 Or .Z(23) = 0) Then .Z(22) = .Z(122) : .Z(23) = .Z(123)
            If .Z(24) = 0 Or .Z(25) = 0 Or .Z(22) = 0 Or .Z(23) = 0 Then
                I24 = IndPos(24) : I25 = IndPos(25) : I22 = IndPos(22) : I23 = IndPos(23)
                If Not .LOOSE = 4 Then
                    If .Z(22) = 0 Then If InStr(CVARI(I22), "*") = 0 Then CVARI(I22) = CVARI(I22) & "*"
                    If .Z(23) = 0 Then If InStr(CVARI(I23), "*") = 0 Then CVARI(I23) = CVARI(I23) & "*"
                Else
                    I122 = IndPos(122) : I123 = IndPos(123)
                    If .Z(22) = 0 Then If InStr(CVARI(I122), "*") = 0 Then CVARI(I122) = CVARI(I122) & "*"
                    If .Z(23) = 0 Then If InStr(CVARI(I123), "*") = 0 Then CVARI(I123) = CVARI(I123) & "*"
                End If
                If .Z(24) = 0 Then If InStr(CVARI(I24), "*") = 0 Then CVARI(I24) = CVARI(I24) & "*"
                If .Z(25) = 0 Then If InStr(CVARI(I25), "*") = 0 Then CVARI(I25) = CVARI(I25) & "*"
                pagina = 3 : qbflan = 1
                Exit Sub
            End If
            If VerificandoPI Then
                Sba = .Z(171) : sbo = .Z(171)
            Else
                Sba = .Z(24) : sbo = .Z(25)
            End If
            am1 = wm1 / sbo
            am2 = wm2 / Sba
            If am1 > am2 Then am = am1 Else am = am2
            'If .z(1) < 0 Then am = am2
            .Z(43) = am1 : .Z(44) = am2 : .Z(45) = am : .M(43) = .Z(43) * inc * inc
            .M(44) = .Z(44) * inc * inc : .M(45) = .Z(45) * inc * inc
        End With
    End Sub
    Private Function Check203() As Boolean
        If wnlj(0).g <= 0 Then
            Dim Testo As String = "Risulta una guarnizione di tipo assoluto, per|"
            Testo = Testo & "la quale non è stato assegnato il diametro del|"
            Testo = Testo & "sigillo. Accedere al pulsante di pag.3 del cal-|"
            Testo = Testo & "colo di flangia."
            Testo = clsInizio.ConvertiCr(Testo)
            MessageBox.Show(formTab, Testo, "AsmeVip - Calcolo Grandi Fucinati", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            qbflan = -99
            Return False
        End If
        Return True
    End Function
    Private Sub ContrBS()
        Dim BS, cB, BSmin As Single
        Dim nt As Short
        Dim Testo As String
        Dim Stringa(5) As String
        Dim junk, I13 As Short
        Static CentroFori, DiaN As Single
        Static NumBull As Short
        Static uu As String
        With Mem
8490:       'controllo del BS
            cB = .M(4) : BSmin = .M(20) : nt = .M(13)
            BS = (cB * pi) / nt : .M(21) = BS : .Z(21) = .M(21) / inc
            If BSmin <= BS And (BSmin * 2) >= BS Then Exit Sub
            If ConfermaBS And .M(4) = CentroFori And .M(14) = DiaN And .M(13) = NumBull Then Exit Sub
            CentroFori = .M(4) : DiaN = .M(14) : NumBull = .M(13)
            If BSmin > BS Then
8530:           Testo = "La spaziatura bulloni circonferenziale"
                Testo = Testo & "|è troppo bassa. "
                Testo = Testo & "| Bs (minimo) =" & GlobalRoutines.myStr(CSng(.M(20)), 6, 2, False) & ";Bs effettivo = " & GlobalRoutines.myStr(CSng(BS), 6, 2, False)
                uu = Testo
                Testo = Testo & "|       Cosa vuoi fare ?"
                If Not ContinuoAuto Then
                    Stringa(1) = " Scegliere automaticamente nuovi tiranti"
                    Stringa(2) = " Modificare i dati flangia"
                    Stringa(3) = " Modificare N° tiranti"
                    Stringa(4) = " Confermare il Bs attuale"
                    Stringa(5) = " Scegliere automaticamente il nuovo B.C."
                    junk = Monitor.Motore.Quale(5, "Controllo Bs", Stringa, "", 1, clsInizio.ConvertiCr(Testo))
                Else
                    junk = 4
                    PrintlstRes(uu)
                End If
                ConfermaBS = False
                Select Case junk
                    Case 0 : qbflan = -99 : Exit Sub
                    Case 1
                        .M(14) = 0
                        qbflan = 3 : Exit Sub
                    Case 2
                        pagina = 1 : qbflan = 1 : Modifica = True
                    Case 3
                        qbflan = 1 : Modifica = True
                        I13 = IndPos(13)
                        If InStr(CVARI(I13), "*") = 0 Then CVARI(I13) = CVARI(I13) & "*"
                        pagina = 2
                    Case 4
                        ConfermaBS = True
                    Case 5
                        .M(4) = 0
                        qbflan = 3 : Exit Sub
                End Select
            ElseIf 2 * BSmin < BS Then
                Testo = "La spaziatura bulloni circonferenziale"
                Testo = Testo & "|è più elevata della norma (2 BSmin). "
                Testo = Testo & "|2 Bs (minimo) =" & GlobalRoutines.myStr(CSng(2 * .M(20)), 6, 2, False) & ";Bs effettivo = " & GlobalRoutines.myStr(CSng(BS), 6, 2, False)
                uu = Testo
                Testo = Testo & "|       Cosa vuoi fare ?"
                If Not ContinuoAuto Then
                    Stringa(1) = " Modificare i dati flangia"
                    Stringa(2) = " Confermare il Bs attuale"
                    junk = Monitor.Motore.Quale(2, "Controllo Bs", Stringa, "", 1, clsInizio.ConvertiCr(Testo))
                Else
                    junk = 2
                    PrintlstRes(uu)
                End If
                ConfermaBS = False
                Select Case junk
                    Case 0 : qbflan = -99 : Exit Sub
                    Case 1
                        pagina = 1 : qbflan = 1 : Modifica = True
                    Case 2
                        ConfermaBS = True
                End Select
            End If
        End With
    End Sub

    Private Sub DefR()
        Dim Bhub, cB, Rm As Single
        Dim R As Single
        Dim Testo As String
        Dim Stringa(2) As String
        Dim junk As Short
        Dim CBG As Single
        Dim Testo1 As String
        Static Nguar, Guno, CentroFori, DiamInt, DiamGuar, DiaFori As Single
        '8830   'definizione e controllo R
        With Mem
            cB = .M(4) : Bhub = .M(6) : Rm = .M(18)
            If Not (.LOOSE = -1 Or .LOOSE = 2 Or .LOOSE = 7) Then Bhub = .M(6) + 2 * .M(8)
            If .LOOSE = 4 Then Bhub = 0
            R = (cB - Bhub) / 2
            .M(19) = R : .Z(19) = .M(19) / inc
            If Not (.LOOSE = -1 Or .LOOSE = 2 Or .LOOSE = 7) And .M(199) = 1 Then
                Bhub = .M(6)
                R = (cB - Bhub) / 2
            End If
            If ConfermaDR And .M(6) = DiamInt And .M(4) = CentroFori And (.LOOSE = -1 Or .LOOSE = 2 Or (.LOOSE > -1 And .M(8) = Guno)) Then GoTo DefR2
            DiamInt = .M(6)
            CentroFori = .M(4)
            Guno = .M(8)
            If R < Rm + .M(186) Then
                If qbflan > -1 Then
8880:               Testo = "La spaziatura bulloni radiale "
                    Testo = Testo & "|verso l' interno è insufficiente"
                    Testo = Testo & "|R   (minimo)    = " & GlobalRoutines.myStr(CSng(Rm + .M(186)), 7, 2, False) & " R  effettivo  = " & GlobalRoutines.myStr(CSng(R), 7, 2, False)
                    Testo = Testo & "|CB  (minimo)    = " & GlobalRoutines.myStr(CSng(Bhub + 2 * .M(18) + 2 * .M(186)), 7, 2, False) & " CB effettivo  = " & GlobalRoutines.myStr(CSng(.M(4)), 7, 2, False)
                    Testo1 = Testo
                    Testo = Testo & "|       Cosa vuoi fare ? "
                    Stringa(1) = "Modificare il diametro centro fori"
                    Stringa(2) = "Confermare il valore attuale di R"
                    If Not ContinuoAuto Then
                        junk = Monitor.Motore.Quale(2, "Controllo R ", Stringa, "", 1, clsInizio.ConvertiCr(Testo))
                    Else
                        PrintlstRes(Testo1)
                        junk = 2
                    End If
                Else
                    junk = 2
                End If
                ConfermaDR = False
                Select Case junk
                    Case 0 : qbflan = -99 : Exit Sub
                    Case 1
                        .M(4) = Bhub + 2 * (.M(18) + .M(186)) : .Z(4) = .M(4) / inc
                        cB = .M(4)
                        qbflan = 2 : Modifica = True
                    Case 2
                        .Conforme = "NO"
                        ConfermaDR = True
                End Select
            End If
DefR2:      CBG = .M(5) + .M(26) + 15 + .M(15)
            If ConfermaDR And .M(5) = DiamGuar And .M(4) = CentroFori And .M(26) = Nguar And DiaFori = .M(15) Then Exit Sub
            DiamGuar = .M(5)
            CentroFori = .M(4)
            Nguar = .M(26)
            DiaFori = .M(15)
            If CBG > cB Then
                If qbflan > -1 Then
                    Testo = "La spaziatura bulloni radiale ver-"
                    Testo = Testo & "|so la guarnizione è insufficiente"
                    Testo = Testo & "|spazio minimo   = " & GlobalRoutines.myStr(15.0! / 2, 7, 2, False) & " sp. effettivo = " & GlobalRoutines.myStr(CSng(cB - CBG + 15) / 2, 7, 2, False)
                    Testo1 = Testo
                    Testo = Testo & "|       Cosa vuoi fare ? "
                    If Not ContinuoAuto Then
                        Stringa(1) = "Modificare il diametro centro fori"
                        Stringa(2) = "Confermare i  dati attuali       "
                        junk = Monitor.Motore.Quale(2, "Controllo R ", Stringa, "", 1, clsInizio.ConvertiCr(Testo))
                    Else
                        junk = 2
                        PrintlstRes(Testo1)
                    End If
                Else
                    junk = 2
                End If
                ConfermaDR = False
                Select Case junk
                    Case 0 : qbflan = -99 : Exit Sub
                    Case 1
                        .M(4) = CBG : .Z(4) = .M(4) / inc
                        qbflan = 2 : Modifica = True
                    Case 2
                        .Conforme = "NO"
                        ConfermaDR = True
                End Select
            End If
        End With
    End Sub

    Private Sub DiamExtwn()
        Dim a, cB, EM As Single
        Dim junk As Short
        Dim E As Single
        Dim Testo As String
        Dim Stringa(2) As String
        Static CentroFori, DiamExt As Single
        '8660   'definizione e controllo diametro esterno
        With Mem
8670:       cB = .M(4) : a = .M(3) : EM = .M(16)
            If a <= cB Then a = cB + 2 * EM : E = EM
            If a <> 0 Then E = (a - cB) / 2
            .M(3) = a : .M(17) = E : .Z(3) = .M(3) / inc : .Z(17) = .M(17) / inc
            If E - EM > -0.0001 Or qbflan < 0 Then Exit Sub
            If ConfermaDE And CentroFori = .M(4) And DiamExt = .M(5) Then Exit Sub
            CentroFori = .M(4) : DiamExt = .M(5)
            Testo = "La spaziatura bulloni radiale "
            Testo = Testo & "|verso l' esterno è insufficiente"
            Testo = Testo & "|E   (minimo)    = " & GlobalRoutines.myStr(CSng(.M(16)), 7, 2, False) & " E  attuale    = " & GlobalRoutines.myStr(CSng(E), 7, 2, False)
            Testo = Testo & "|Diam.est.minimo = " & GlobalRoutines.myStr(CSng(.M(4) + 2 * .M(16)), 7, 2, False) & " Diam.attuale  = " & GlobalRoutines.myStr(CSng(.M(3)), 7, 2, False)
            If Not ContinuoAuto Then
                Testo = Testo & "|       Cosa vuoi fare ? "
                Stringa(1) = "Modificare il diametro esterno"
                Stringa(2) = "Confermare il valore attuale di E"
                junk = Monitor.Motore.Quale(2, "Controllo E " & Involucr(kLato, jInvolucr).Mark.Trim, Stringa, "", 1, clsInizio.ConvertiCr(Testo))
            Else
                junk = 2
                PrintlstRes(Testo)
            End If
            ConfermaDE = False
            Select Case junk
                Case 0 : qbflan = -99 : Exit Sub
                Case 1
                    .M(3) = .M(4) + 2 * .M(16) : .Z(3) = .M(3) / inc
                    Modifica = True
                    GoTo 8670
                Case 2
                    .Conforme = "NO"
                    ConfermaDE = True
            End Select
        End With
    End Sub

    Private Sub LarghGua()
        Dim Testo As String
        Dim Stringa(6) As String
        Dim I26, junk, i5 As Short
        Dim ts, DL, tl, Ds As Single
        Dim Gmin As Single
        Dim uu, Testo1 As String
        Static DiamInt, LargGua, DiamG As Single
        Static Dato8, Dato7, Dato10 As Single
        Static Dato11, Dato31 As Single
        With Mem
            '6490   'larghezza guarnizione
6500:       wnlj(0).n = .M(26) : wnlj(0).b = .M(6)
            If .LOOSE = -1 Or .LOOSE = 2 Then
                If wnlj(0).b = 0 Then wnlj(0).b = .M(10) + 6 : .M(6) = wnlj(0).b : .Z(6) = wnlj(0).b / inc
            End If
            If wnlj(0).n = 0 And .Z(28) = 0 Then GoTo 6540
            If wnlj(0).n = 0 And wnlj(0).b <= 584 Then wnlj(0).n = 10
            If wnlj(0).n = 0 And wnlj(0).b > 584 Then wnlj(0).n = 13
            If .M(161) < 14 Then 'diaframma elastico
                If wnlj(0).n <> 0 And wnlj(0).b > 584 And wnlj(0).n < 13 And qbflan > -1 Then GoTo 6560
            End If
6540:       .M(26) = wnlj(0).n : .Z(26) = .M(26) / inc
            GoTo 6690
6560:       'AVVISO larghezza guarnizione non conforme
            'If Not Configwn.Crush Then GoTo 6690
            If ConfermaLG And LargGua = .M(26) And DiamInt = .M(6) Then GoTo 6690
            LargGua = .M(26) : DiamInt = .M(6)
            Testo = "|La larghezza della guarnizione"
            Testo = Testo & "|è inferiore al minimo tabella-"
            Testo = Testo & "|re (" & GlobalRoutines.myStr(CSng(wnlj(0).n), 3, 2, False) & " mm)."
            uu = Testo
            Testo = Testo & "|       Cosa vuoi fare ? "
            If Not ContinuoAuto Then
                If wnlj(0).b <= 584 Then
                    Stringa(1) = "Adottare il valore minimo (10 mm)"
                Else
                    Stringa(1) = "Adottare il valore minimo (13 mm)"
                End If
                Stringa(2) = "Inserire un nuovo dato"
                Stringa(3) = "Confermare il dato impostato"
                junk = Monitor.Motore.Quale(3, "Controllo guarnizione", Stringa, "", 1, clsInizio.ConvertiCr(Testo))
            Else
                junk = 3
                PrintlstRes(uu)
            End If
            ConfermaLG = False
            Select Case junk
                Case 0 : qbflan = -99 : Exit Sub
                Case 1
                    Modifica = True
                    wnlj(0).n = 13 : GoTo 6540
                Case 2
                    I26 = IndPos(26)
                    If InStr(CVARI(I26), "*") = 0 Then CVARI(I26) = CVARI(I26) & "*"
                    qbflan = 1
                    Modifica = True
                    pagina = 3
                    Exit Sub
                Case 3
                    ConfermaLG = True
                    .Conforme = "NO"
            End Select
6690:       'diametro medio guarnizione
            wnlj(0).g = .M(5) : wnlj(0).n = .M(26) : wnlj(0).PHI = .M(31) : wnlj(0).b = .M(6)
            If (.LOOSE = -1 Or .LOOSE = 2) And Not (.File = ".cop" Or .File = ".cob") Then
                DL = .M(11) : Ds = .M(10) : ts = .M(8) : tl = .Z(7) * inc
                If .LOOSE = -1 And DL = 0 And Ds > 0 Then DL = (Ds - (2 * ts)) + 60
                If tl >= 0 Then
                    If tl = 0 And ts > 0 Then tl = Int(ts) + 1
                    If .LOOSE = 2 Then tl = 0
                Else
                    ts = 0
                End If
                If .LOOSE = -1 And wnlj(0).g = 0 And DL > 0 Then wnlj(0).g = Int(DL - wnlj(0).n)
                If .LOOSE = 2 And wnlj(0).g = 0 Then wnlj(0).g = Int((wnlj(0).b + 20) + wnlj(0).n) + 1
            Else
                If wnlj(0).g = 0 Then wnlj(0).g = Int((wnlj(0).b + 20) + wnlj(0).n) + 1
                If .M(5) = 0 And wnlj(0).PHI = 8 Then wnlj(0).g = Int(wnlj(0).b + 3 * wnlj(0).n + wnlj(0).n) + 1
            End If
            .M(5) = wnlj(0).g : .Z(5) = .M(5) / inc : .M(26) = wnlj(0).n : .Z(26) = .M(26) / inc
            If (.LOOSE = -1 Or .LOOSE = 2) And Not (.File = ".cop" Or .File = ".cob") Then
                If .M(195) = 0 Then .M(11) = DL : .Z(11) = DL / inc
                If .Z(7) > 0 Then
                    .M(7) = tl : .Z(7) = tl / inc
                End If
                If (wnlj(0).g - wnlj(0).n) < wnlj(0).b Then Gmin = wnlj(0).b + wnlj(0).n : GoTo 6770
            Else
                If (wnlj(0).g - wnlj(0).n) < wnlj(0).b Then Gmin = wnlj(0).b + wnlj(0).n : GoTo 6770
                If wnlj(0).PHI = 8 And ((wnlj(0).g - wnlj(0).n) < (wnlj(0).b + 3 * wnlj(0).n)) Then Gmin = (wnlj(0).b + 3 * wnlj(0).n + wnlj(0).n) : GoTo 6770
            End If
            Exit Sub
6770:       'AVVISO diametro medio guarnizione non conforme
            If SuperOtt Then Exit Sub
            If .LOOSE = -1 Or .LOOSE = 2 Then
                If ConfermaLG And LargGua = .M(26) And DiamG = .M(5) And DiamInt = .M(6) And Dato31 = .M(31) And Dato7 = .M(7) And Dato8 = .M(8) And Dato10 = .M(10) And Dato11 = .M(11) Then Exit Sub
                Dato7 = .M(7) : Dato8 = .M(8) : Dato10 = .M(10) : Dato11 = .M(11)
            Else
                If ConfermaLG And LargGua = .M(26) And DiamG = .M(5) And DiamInt = .M(6) And Dato31 = .M(31) Then Exit Sub
            End If
            LargGua = .M(26) : DiamG = .M(5) : DiamInt = .M(6) : Dato31 = .M(31)
            Testo = "Il diametro medio della guarnizione è troppo basso"
            Testo = Testo & "|in confronto al diametro interno della flangia."
            Testo1 = Testo
            If wnlj(0).PHI = 8 Then Testo = Testo & "|(E' possibile che il problema sia connesso con|la scelta di phi=8).|"
            Testo = Testo & "|       Cosa vuoi fare ? "
            Stringa(1) = " G guarnizione (impostato)= " & GlobalRoutines.myStr(CSng(wnlj(0).g), 4, 2, False) & "    N max =" & GlobalRoutines.myStr(CSng(Int(wnlj(0).g - wnlj(0).b)), 5, 2, True)
            Testo1 = Testo1 & "|" & Stringa(1)
            Stringa(2) = " N guarnizione (impostato)= " & GlobalRoutines.myStr(CSng(wnlj(0).n), 4, 2, False) & "    G min =" & GlobalRoutines.myStr(CSng(Gmin), 5, 2, False)
            Testo1 = Testo1 & "|" & Stringa(2)
            Stringa(3) = " Accettare il dato G min"
            Stringa(4) = " Accettare il dato N max"
            Stringa(5) = " Modificare entrambi i dati"
            Stringa(6) = " Confermare i dati impostati"
            If qbflan > -1 Then
                If Not ContinuoAuto Then
                    junk = Monitor.Motore.Quale(6, "Controllo dati guarnizione", Stringa, "", 1, clsInizio.ConvertiCr(Testo))
                Else
                    PrintlstRes(Testo1)
                    junk = 4
                End If
            Else
                junk = 2
            End If
            ConfermaLG = False
            Select Case junk
                Case 0 : qbflan = -99 : Exit Sub
                Case 2
                    Modifica = True
                    .M(26) = Int(wnlj(0).g - wnlj(0).b) : GoTo 6500
                Case 1
                    Modifica = True
                    .M(5) = Gmin : Exit Sub
                Case 3
                    i5 = IndPos(5) : I26 = IndPos(26)
                    If InStr(CVARI(i5), "*") = 0 Then CVARI(i5) = CVARI(i5) & "*"
                    If InStr(CVARI(I26), "*") = 0 Then CVARI(I26) = CVARI(I26) & "*"
                    pagina = 1
                    qbflan = 1 : Exit Sub
                Case 4
                    ConfermaLG = True
                    .Conforme = "NO"
                Case 5 : qbflan = 1 : Exit Sub 'modifica
                Case 6
                    ConfermaLG = True
            End Select
        End With
    End Sub

    Public Sub ljflan()
        Dim ht, HD, HG, hr As Single
        Dim gef, cB, wm1 As Single
        Dim Ds, a, tl As Single
        Dim k, c, t As Single
        Dim y, u, Zf As Single
        Dim s, f, l As Single
        Dim MG, MD, MT, MR As Single
        Dim mo, j, MW As Single
        Dim Cf, m0, fc As Single
        Dim SL, J16 As Single
        Dim Testo As String
        Dim SR, Sfo, Sfa, SH, St As Single
        Dim SM1, fact, St2, SM2 As Single
        With Mem
            On Error GoTo Errlj
            If qbflan > 0 Then qbflan = 0
            If .Z(22) = 0 Then .Z(22) = .Z(23) : .M(22) = .M(23)
            If .Z(23) = 0 Then .Z(23) = .Z(22) : .M(23) = .M(22)
            .Z(82) = .Z(23) * 1.5 : .M(82) = .M(23) * 1.5
            .VERIFICA = "SI" : .Conforme = "SI" : Fermo = 0
            Call PreliminF()
            If qbflan = 1 Or qbflan = 3 Or qbflan = -99 Then Exit Sub
9030:       'definizione dei bracci per i momenti
            wnlj(0).b = .M(6) ' + 2 * .m(11)
            If .Z(7) < 0 Then wnlj(0).b = .M(6) + 2 * .M(11) 'floating head
            cB = .M(4) : gef = .M(37)
            HD = (cB - wnlj(0).b) / 2
            HG = (cB - gef) / 2
            If .Z(7) > 0 And .LOOSE = -1 Then 'con lap
                ht = (cB - gef) / 2
            Else
                ht = (HD + HG) / 2
            End If
            .M(47) = HD : .Z(47) = .M(47) / inc
            .M(48) = ht : .Z(48) = .M(48) / inc
            .M(49) = HG : .Z(49) = .M(49) / inc
            'definizione carichi per i momenti
            wnlj(0).b = .Z(6) + 2 * .Z(11) : wnlj(0).H = .Z(39) : wnlj(0).W = .Z(42)
            HD = (pi / 4) * wnlj(0).b ^ 2 * System.Math.Abs(.Z(1)) : .Z(50) = HD
            .M(50) = .Z(50) * NIUT
            ht = wnlj(0).H - HD : .Z(51) = ht : .M(51) = .Z(51) * NIUT
            If .Z(33) >= .Z(40) Then wm1 = .Z(33) Else wm1 = .Z(40)
            'HG = .z(38): .z(52) = HG: .m(52) = .m(38)'????????????
            'HG = .z(42) - .z(39): .z(52) = HG: .m(52) = .m(42) - .m(39)
            If .Z(1) > 0 Then
                HG = wm1 - .Z(39)
            Else
                HG = 0
            End If
            .Z(52) = HG : .M(52) = .Z(52) * NIUT
            If .LOOSE = 2 And .M(195) > 0 Then
                hr = HD / System.Math.Tan(.M(126) * pi / 180)
                .Z(196) = hr : .M(196) = .Z(196) * NIUT
            End If
            'fattori T - U - Y - Z - K per flangie ASME
            a = .Z(3) : wnlj(0).b = .Z(6)
            k = a / wnlj(0).b
            y = (1 / (k - 1)) * (0.66845 + 5.7169 * (k ^ 2 * (System.Math.Log10(k))) / (k ^ 2 - 1))
            .Z(54) = k : .Z(63) = y
            .M(54) = k : .M(63) = y
            'calcolo spessore di progetto e fattore L
            s = .M(9)
9930:       If s = 0 Then s = (Int(.M(14) / 5) + 1) * 5
            'calcolo momenti
            If .Z(1) > 0 Then
                MD = .M(50) * .M(47)
                MT = .M(51) * .M(48)
                MG = .M(52) * .M(49)
            Else
                MD = (.M(47) - .M(49)) * .M(50)
                MT = (.M(48) - .M(49)) * .M(51)
                MG = 0
            End If
            If .LOOSE = 2 And .M(195) > 0 Then
                MR = .M(196) * .M(125)
                .M(78) = MR
                .Z(78) = .M(78) * MomToBS
            Else
                MR = 0
            End If
            .M(68) = MD
            .M(69) = MT
            .M(70) = MG
            .Z(68) = .M(68) * MomToBS
            .Z(69) = .M(69) * MomToBS
            .Z(70) = .M(70) * MomToBS
9931:       j = .M(23) / .M(22) : .M(71) = j : .Z(71) = j
            mo = System.Math.Abs(MD + MT + MG - MR)
            MW = .M(42) * .M(49)
            If .LOOSE = -1 And .Z(7) = -1 Then
                mo = mo * 2
                MW = MW * 2
            End If
            .M(72) = mo : .Z(72) = .M(72) * MomToBS
            .M(73) = MW : .Z(73) = .M(73) * MomToBS
            If mo > (MW * j) Then m0 = mo Else m0 = (MW * j)
9934:       .M(74) = m0 : .Z(74) = .M(74) * MomToBS
            '--------------------------------
            Sfa = .Z(22) : Sfo = .Z(23)
            If .LOOSE = 2 And .M(195) = 1 Then
                a = .Z(3) - 2 * .Z(11) : wnlj(0).b = .Z(6) + 2 * .Z(11)
                m0 = .Z(74)
                J16 = m0 / Sfo / wnlj(0).b * (a + wnlj(0).b) / (a - wnlj(0).b)
                .Z(75) = J16 : .M(75) = J16 * inc * inc
                f = System.Math.Abs(.Z(1)) * wnlj(0).b * System.Math.Sqrt(4 * .Z(124) * .Z(124) - wnlj(0).b ^ 2) / wnlj(0).b / Sfo / (a - wnlj(0).b)
                .Z(81) = f : .M(81) = f * inc
                .Z(82) = f + System.Math.Sqrt(f * f + J16)
                .M(82) = .Z(82) * inc
                If .M(9) = 0 Then .M(9) = Int(.M(82) + .M(11) + 0.99) : .Z(9) = .M(9) / inc
            Else
                'calcolo fattore Cf
                c = .M(4) : wnlj(0).n = .M(13) : DN = .M(14) : wnlj(0).m = .M(30)
                Cf = System.Math.Sqrt((pi * c) / ((wnlj(0).n * (2 * DN + (6 * s / (wnlj(0).m + 0.5)))))) : If Cf < 1 Then Cf = 1
                .M(53) = Cf : .Z(53) = Cf
                'calcolo carico per sollecitazioni
                wnlj(0).b = .M(6) : m0 = .M(74)
                wnlj(0).m = (m0 * Cf) / wnlj(0).b : .M(75) = wnlj(0).m
                .Z(75) = wnlj(0).m * 0.224808924
                'calcolo sollecitazioni
                y = .Z(63) : wnlj(0).H = .Z(39) : Ds = .Z(10)
                If .Z(7) >= 0 Then tl = .Z(7)
                s = s / 25.4 : wnlj(0).m = .Z(75)
                St = (y * wnlj(0).m) / s ^ 2
                If Ds * tl > 0 Then SL = (wnlj(0).H / (Ds * pi * tl)) / 0.8 Else SL = 0
                .Z(78) = St : .Z(81) = SL
                .M(78) = St / psi : .M(81) = SL / psi
                If .M(9) = 0 Then GoTo 10250 Else GoTo 10270
10250:          If St > Sfo Then s = s * 25.4 + 5 : GoTo 9930
                .Z(9) = s : .M(9) = .Z(9) * inc
            End If
10270:      pagina = 7
10271:      Exit Sub
Errlj:
            If Err.Number = 6 Or Err.Number = 11 Then
                Testo = Involucr(kLato, jInvolucr).Mark.Trim & "." & vbCrLf
                Testo = Testo & "Mancano dati essenziali nell'input"
                MessageBox.Show(formTab, Testo, "AsmeVip - Calcolo Grandi Fucinati", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                pagina = 1 : qbflan = -99
                Resume 10271
            Else
                MessageBox.Show(formTab, "ljflan " & Err.Description & Str(Erl()))
                ' Stop
                ' Resume
            End If
        End With
    End Sub
    Private Function ScelTir() As Boolean
        Dim giro, iTir As Short
        Dim TIRP As String = ""
        Dim BS, DN, W As Single
        Dim DNP, BSP As Single
        Dim E, R, DF As Single
        Dim nt As Short
        Dim CBR As Single
        Dim EP, RP, DFP As Single
        Dim ntP As Short
        Dim CBP As Single
        Dim CBS, CBG, cB As Single
        Dim NTI As Short
        Dim Testo As String
        Dim ab As Single
        Dim Stringa(3) As String
        Dim I12, x, I13 As Short
        Dim am, Sba As Single
        Dim uu As String
        Static DTir, NTir As Single
        ScelTir = True
        'scelta dei tiranti
        Try
            With Mem
                If Not (.LOOSE = -1 Or .LOOSE = 2) Then
                    wnlj(0).b = .M(6) + 2 * .M(11)
                    wnlj(0).g1 = .M(8) - .M(11)
                Else
                    wnlj(0).b = .M(6)
                End If
                wnlj(0).g = .M(5)
                wnlj(0).n = .M(26)
                If .M(14) = 0 Then Progetto = 1 Else Progetto = 0 : GoTo 7890
                If Tira Is Nothing Then Tira = New LibMat.clsTira
                If .XFil = 0 Then .XFil = 2
                Tira.Xfil = .XFil
7541:           'Tira.Scelta clsInizio.Archdir, clsInizio.discotem
                If Tira.Xfil = 0 Then
                    Tira.Scelfil((clsInizio.Archdir), (clsInizio.DiscoTem))
                    If Tira.Xfil = 0 Then qbflan = -99 : Exit Function
                End If
                .XFil = Tira.Xfil
                giro = 1
                '       Ricerca del Centro fori Ideale
                iTir = 1
                If Config(kLato).DC Mod 3 = 0 Then
                    Testo = "TEMA class not defined." & vbCrLf
                    Testo = Testo & "Assuming TEMA-R"
                    If MessageBox.Show(formTab, Testo, "AsmeVip - Calcolo Grandi Fucinati", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) = DialogResult.OK Then
                        Config(kLato).DC = Config(kLato).DC + 1
                    End If
                End If
                Select Case Config(kLato).DC Mod 3
                    Case 1 : iTir = 3
                    Case 2 : iTir = 2
                End Select
7560:           If Not Tira.Preleva(iTir) Then
                    If Not ContinuoAuto Then MostraAiuto(2102, ChiaviMess.MessOK + ChiaviMess.MessInformation + ChiaviMess.MessHelpButton)
                    GoTo 7820
                End If
                .TIR = Tira.DN.Trim
                DN = Tira.Diam
                If DN = 0 Then
                    '  Set Tira = Nothing
                    GoTo 7820
                End If
                BS = Tira.BSmin
                R = Tira.Rmin
                E = Tira.Emin
                DF = Tira.foro
                If BS * R * E * DF = 0 Then
                    MessageBox.Show(formTab, "I valori di libreria per il tirante " & .TIR & " non sono validi", "AsmeVip - Calcolo Grandi Fucinati")
                    ScelTir = False
                    Exit Function
                End If
7561:           'calcolo numero dei tiranti
7562:           nt = .M(45) / ((DN ^ 2) * (pi / 4))
7563:           If DN < 72 Then nt = (Int(nt / 4) + 1) * 4 Else nt = (Int(nt / 2) + 1) * 2
7564:           'IF .z(13) <> 0 THEN NT = .z(13)
7565:           If giro = 1 Then
                    TIRP = .TIR
                    DNP = DN
                    BSP = BS
                    RP = R
                    EP = E
                    DFP = DF
                    ntP = nt
                    CBP = 1000000.0!
                End If
                If Not (.LOOSE = -1 Or .LOOSE = 2 Or .LOOSE = 7) Then
7566:               CBR = wnlj(0).b + 2 * (wnlj(0).g1 + R + .M(186)) 'Diametro centro fori partendo dal codolo
                    If .M(199) = 1 Then CBR = wnlj(0).b + 2 * (R + .M(186))
                Else
                    CBR = wnlj(0).b + 2 * (R + .M(186)) 'Diametro centro fori partendo dal codolo
                End If
                CBG = wnlj(0).g + wnlj(0).n + 15 + DF 'Diametro centro fori partendo dalla guarnizione
                CBS = BS * nt / pi 'Diametro centro fori partendo dal BS
                'scelta del centro fori maggiore
                If CBR < CBG Then cB = CBG Else cB = CBR
                If cB < CBS Then cB = CBS
                cB = Int(cB) + 1
                'scelta centro fori ideale
                If cB >= CBP Then GoTo 7820
                TIRP = .TIR : DNP = DN : BSP = BS : RP = R : EP = E : DFP = DF : ntP = nt : CBP = cB : giro = giro + 1
                iTir = iTir + 1
                GoTo 7560 'letture altri tiranti
7820:           'scelta nø tiranti ideale
                .TIR = TIRP : DN = DNP : BS = BSP : R = RP : E = EP : DF = DFP : cB = CBP
                NTI = (cB * pi) / (BS * 2)
                If DN < 72 Then NTI = (Int(NTI / 4) + 1) * 4 Else NTI = (Int(NTI / 2) + 1) * 2
                If ntP < NTI Then nt = NTI Else nt = ntP
                .M(12) = 1 : .M(13) = nt : .M(14) = DN : .M(15) = DF : .M(16) = E : .M(18) = R : .M(20) = BS : .M(4) = cB
                .Z(12) = 1 : .Z(13) = nt : .Z(14) = DN / inc : .Z(15) = DF / inc : .Z(16) = E / inc : .Z(18) = R / inc : .Z(20) = BS / inc : .Z(4) = cB / inc
7890:           'area effettiva dei tiranti e carico sui tiranti al serraggio
                nt = .M(13) : DN = .M(14) : DF = .M(15) : E = .M(16) : R = .M(18) : BS = .M(20) : cB = .M(4)
                If DF = 0 Or E = 0 Or R = 0 Or BS = 0 Then
                    pagina = 2 : qbflan = 1
                    Testo = "I dati forniti per i tiranti sono insufficienti"
                    MessageBox.Show(formTab, Testo, "AsmeVip - Calcolo Grandi Fucinati")
                    Exit Function
                End If
                If nt = 0 Then GoTo 7930 Else GoTo 7960
7930:           nt = .M(45) / ((DN ^ 2) * (pi / 4))
                If DN < 72 Then nt = (Int(nt / 4) + 1) * 4 Else nt = (Int(nt / 2) + 1) * 2
                .Z(13) = nt : .M(13) = nt
7960:           If cB = 0 Then GoTo 7970 Else GoTo 8010
7970:           If Not (.LOOSE = -1 Or .LOOSE = 2) Then
                    CBR = .M(6) + 2 * (.M(8) + R + .M(186)) : CBG = .M(5) + .M(26) + 15 + DF : CBS = BS * nt / pi
                Else
                    CBR = .M(6) + 2 * (R + .M(186)) : CBG = .M(5) + .M(26) + 15 + DF : CBS = BS * nt / pi
                End If
                If .M(199) = 1 Then CBR = 0 'tiranti prigionieri
                If CBR < CBG Then cB = CBG Else cB = CBR
                If cB < CBS Then cB = CBS Else cB = cB
                cB = Int(cB) + 1 : .M(4) = cB : .Z(4) = .M(4) / inc
8010:           ab = nt * (DN ^ 2) * (pi / 4) : .M(46) = ab : .Z(46) = ab / inc / inc
                If .M(45) > .M(46) Then
                    If qbflan < 0 Then GoTo 8180
8030:               'AVVISO area tiranti insufficente
                    If ConfermaST And DTir = .M(14) And NTir = .M(15) Then GoTo 8180
                    DTir = .M(14)
                    NTir = .M(15)
                    Testo = "Area tiranti insufficiente"
                    Testo = Testo & "|N° " & Str(nt) & " tiranti da :" & .TIR & " area = " & GlobalRoutines.myStr(CSng(.M(46)), 9, 2, False) & " mm2"
                    Testo = Testo & "|" & Space(15) & "area minima richiesta = " & GlobalRoutines.myStr(CSng(.M(45)), 7, 2, False) & " mm2"
                    uu = Testo
                    Testo = Testo & "|    Cosa vuoi fare?"
                    Stringa(1) = "Modifica i tiranti"
                    Stringa(2) = "Modifica il N° di tiranti"
                    Stringa(3) = "Conferma i dati impostati"
                    x = Monitor.Motore.Quale(3, "Area tiranti " & Mem.FLID, Stringa, "", 1, clsInizio.ConvertiCr(Testo))
                    ConfermaST = False
                    Select Case x
                        Case 0 : qbflan = -99 : Exit Function
                        Case 1
                            Modifica = True
                            I12 = IndPos(12)
                            If InStr(CVARI(I12), "*") = 0 Then CVARI(I12) = CVARI(I12) & "*"
                            pagina = 2
                            '                frmTab.Schedario.Tabs(2).Selected = True
                            qbflan = 1
                            If Not formTab.Visible Then qbflan = 5
                            Exit Function
                        Case 2
                            Modifica = True
                            I13 = IndPos(13)
                            If InStr(CVARI(I13), "*") = 0 Then CVARI(I13) = CVARI(I13) & "*"
                            pagina = 2
                            qbflan = 1
                            If Not formTab.Visible Then qbflan = 5
                            Exit Function
                        Case 3
                            ConfermaST = True
                            .VERIFICA = "NO"
                            nIndent = 6
                            PrintlstRes(uu)
                            nIndent = 0
                    End Select
                End If
8180:           am = .Z(45) : ab = .Z(46) : Sba = .Z(173) ' .z(24)
                ' .z(173) è l'ammissibile in design, .z(24) è l'ammissibile secondo la condizione (PI o design) in corso di calcolo
                wnlj(0).W = (am + ab) * Sba * 0.5
                If Configwn.FullBolt = 1 Then wnlj(0).W = ab * Sba 'Full Bolt
                If Configwn.FullBolt = 3 And (LoadCond = 1 Or VerificandoPI) Then
                    W = .Z(204) * .Z(46)
                    If W > wnlj(0).W Then wnlj(0).W = W
                End If
                .Z(42) = wnlj(0).W : .M(42) = wnlj(0).W * NIUT
            End With
        Catch ex As Exception
            MessageBox.Show(formTab, ex.Message + vbCrLf + ex.StackTrace)
        End Try
    End Function
    Private Sub SchiaccGuar()
        Dim Sba, ab, Nmin As Single
        Dim Gmin, CBmin As Single
        Dim junk As Short
        Dim Testo As String
        Dim Stringa(3) As String
        Dim i5, i4, I26 As Short
        Static AreaB, NGua, GuarY As Single
        Static BolSba, GuaGef, BolWMT As Single
        'controllo schiacciamento guarnizione
        With Mem
            wnlj(0).n = .M(26) : ab = .M(46) : wnlj(0).y = .M(28)
            wnlj(0).g = .M(37) : Sba = .M(24) : wnlj(0).wmt = .M(32)
            If wnlj(0).y = 0 Then Exit Sub
            Nmin = ((ab * Sba) - wnlj(0).wmt) / (2 * wnlj(0).y * wnlj(0).g * pi)
            .M(27) = Nmin : .Z(27) = .M(27) / inc
            If Nmin > wnlj(0).n Then GoTo 8260 Else Exit Sub
8260:       'AVVISO larghezza guarnizione non conforme
            Nmin = Int(Nmin) + 1
            Gmin = Int((.M(6) + 2 * .M(11)) + Nmin) + 1 'diam int.flangia+2*corr
            CBmin = Gmin + 15 + .M(15)
            If .M(5) > Gmin Then Gmin = .M(5)
            If .M(4) > CBmin Then CBmin = .M(4)
            If qbflan > -1 Then
                If Not Configwn.CRUSH Then Exit Sub
                If ConfermaSG And .M(26) = NGua And .M(46) = AreaB And .M(37) = GuaGef And .M(28) = GuarY And .M(24) = BolSba And .M(32) = BolWMT Then Exit Sub
                NGua = .M(26) : AreaB = .M(46) : GuaGef = .M(37) : GuarY = .M(28) : BolSba = .M(24) : BolWMT = .M(32)
                Testo = "Pericolo di schiacciamento della guarnizione."
                Testo = Testo & "|       Cosa vuoi fare ? "
                Testo = Testo & "|N guarnizione (impostato) = " & GlobalRoutines.myStr(CSng(.M(26)), 6, 2, False) & "      N minimo = " & GlobalRoutines.myStr(CSng(Nmin), 6, 2, False)
                Testo = Testo & "|G guarnizione (impostato) = " & GlobalRoutines.myStr(CSng(.M(5)), 6, 2, False) & "      G minimo = " & GlobalRoutines.myStr(CSng(Gmin), 6, 2, False)
                Testo = Testo & "|CB            (impostato) = " & GlobalRoutines.myStr(CSng(.M(4)), 6, 2, False) & "     CB minimo = " & GlobalRoutines.myStr(CSng(CBmin), 6, 2, False)
                If Not ContinuoAuto Then
                    Testo = Testo & "|       Cosa vuoi fare ? "
                    Stringa(1) = "Modificare i dati"
                    Stringa(2) = "Confermare i dati minimi calcolati"
                    Stringa(3) = "Confermare i dati impostati"
                    junk = Monitor.Motore.Quale(3, "Controllo dati guarnizione", Stringa, "", 1, clsInizio.ConvertiCr(Testo))
                Else
                    junk = 3
                    PrintlstRes(Testo)
                End If
            Else
                junk = 3
            End If
            ConfermaSG = False
            Select Case junk
                Case 0 : qbflan = -99 : Exit Sub
                Case 1
                    Modifica = True
                    i4 = IndPos(4) : i5 = IndPos(5) : I26 = IndPos(26)
                    If InStr(CVARI(i4), "*") = 0 Then CVARI(i4) = CVARI(i4) & "*"
                    If InStr(CVARI(i5), "*") = 0 Then CVARI(i5) = CVARI(i5) & "*"
                    If InStr(CVARI(I26), "*") = 0 Then CVARI(I26) = CVARI(I26) & "*"
                    pagina = 1
                    qbflan = 1 : Exit Sub
                Case 2
                    Modifica = True
                    .M(26) = Nmin : .M(5) = Gmin : .M(4) = CBmin
                    .Z(26) = .M(26) / inc : .Z(5) = .M(5) / inc : .Z(4) = .M(4) / inc
                    qbflan = 2
                Case 3
                    ConfermaSG = True
                    Exit Sub
            End Select
        End With
    End Sub

    Public Sub Traversini()
        Dim YTRA, wmt As Single
        Dim Stringa(3) As String
        Dim Risult(3) As String
        Dim Arch(3) As Short
        Dim dAiu(3) As String
        With Mem
            If .M(169) = 0 Then .M(169) = .M(36)
            If .Z(168) = 0 Then .Z(168) = .Z(28) '168    Y trav
            YTRA = .Z(168) '167 lungh.traversini
            'calcolo Wmt                             '169 b eff.traversini
            Stringa(1) = "Lunghezza totale traversini [mm]"
            Risult(1) = GlobalRoutines.myStr(CSng(.M(167)), 5, 0, False)
            Stringa(2) = "Larghezza efficace travers. [mm]"
            Risult(2) = GlobalRoutines.myStr(CSng(.M(169)), 2, 0, False)
            Stringa(3) = "Design Seating Stress      [psi]"
            Risult(3) = GlobalRoutines.myStr(CSng(YTRA), 6, 2, False)
            If Not Monitor.Motore.InputDati(3, "Dati traversini", Stringa, Risult, "", Arch, dAiu) Then Exit Sub
            .M(167) = GlobalRoutines.ValVir(Risult(1)) : .Z(167) = .M(167) / inc
            .M(169) = GlobalRoutines.ValVir(Risult(2)) : .Z(169) = .M(169) / inc
            .Z(168) = GlobalRoutines.ValVir(Risult(3)) : .M(168) = .Z(168) * mpa
            wmt = .Z(167) * .Z(168) * .Z(169)
            .Z(32) = wmt : .M(32) = .Z(32) * NIUT
        End With
    End Sub
    Public Sub New()
        MyBase.New()
        Mem.Initialize()
        mems.Initialize()
        ReDim wnlj(1)
        ReDim PosVARI(300)
        ReDim CVARI(300)
        ReDim NVARI(300)
        ReDim TVARI(300)
        ReDim VVARI(300)
        ReDim UVARI(300)
        ReDim RVARI(300)
        ReDim Classedim(6)
        Vari()
        lKlato = kLato
        lJinvolucr = jInvolucr
    End Sub
    Public Property TipCalc() As Short
        Get
            TipCalc = Configwn.TipCalc
        End Get
        Set(ByVal Value As Short)
            Configwn.TipCalc = Value
        End Set
    End Property
    Public Property CRUSH() As Short
        Get
            CRUSH = Configwn.CRUSH
        End Get
        Set(ByVal Value As Short)
            Configwn.CRUSH = Value
        End Set
    End Property
    Public Property FullBolt() As Object
        Get
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto FullBolt. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            FullBolt = Configwn.FullBolt
        End Get
        Set(ByVal Value As Object)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto vNewValue. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            Configwn.FullBolt = Value
        End Set
    End Property
    Public Property LatoProgetto() As Object
        Get
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto LatoProgetto. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            LatoProgetto = Configwn.LatoProgetto
        End Get
        Set(ByVal Value As Object)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto vNewValue. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            Configwn.LatoProgetto = Value
        End Set
    End Property
    Public ReadOnly Property PosVARIp(ByVal i As Short) As Short
        Get
            PosVARIp = PosVARI(i)
        End Get
    End Property

    Public Property Zp(ByVal i As Short) As Single
        Get
            '  If i = 120 Then Stop
            Zp = Mem.Z(i)
        End Get
        Set(ByVal Value As Single)
            '  If i = 194 Then Stop
            Mem.Z(i) = Value
        End Set
    End Property
    Public Property Mp(ByVal i As Short) As Single
        Get
            Mp = Mem.M(i)
        End Get
        Set(ByVal Value As Single)
            Dim jPT, k, j, kPT, ii As Short
            With Mem
                '   If i = 120 Then Stop
                .M(i) = Value
                If i = 125 And .LOOSE = 2 And .M(195) > 0 Then
                    j = Involucr(lKlato, lJinvolucr).AccoppJ
                    k = Involucr(lKlato, lJinvolucr).AccoppK
                    kPT = k : jPT = j
                    If j = 0 Or k = 0 And Configwn.Verbose Then
                        MostraAiuto(IDH_PT_LEGAMI4, , , "AsmeVip - " & Involucr(lKlato, lJinvolucr).Mark.Trim)
                        Throw New NoLinkFFException
                    End If
                    If k <> 3 Or Not (Involucr(k, j).Tipo = 6 Or Involucr(k, j).Tipo = 1 Or Involucr(k, j).Tipo = 2 Or Involucr(k, j).Tipo = 5) Then
                        MostraAiuto(IDH_PT_LEGAMI3, , , "AsmeVip - " & Involucr(lKlato, lJinvolucr).Mark.Trim)
                        Throw New NoLinkFFException
                    ElseIf Involucr(k, j).Tipo <> 6 Then  'non PT
                        kPT = 0
                        For ii = 1 To Config(3).Ninvolucri
                            If Involucr(3, ii).Tipo = 6 Then
                                If CType(objMemb(Involucr(3, ii).IndObject), wn_PT).TipoPT = 2 Then
                                    If CType(CType(objMemb(Involucr(3, ii).IndObject), wn_PT).Piastra, wn_FTC).Rear = 2 Then
                                        jPT = ii
                                        kPT = 3
                                        Exit For
                                    End If
                                End If
                            End If
                        Next
                        If kPT = 0 Then
                            MostraAiuto(IDH_PT_LEGAMI5, , , "AsmeVip - " & Involucr(lKlato, lJinvolucr).Mark.Trim)
                            Throw New NoLinkFFException
                        End If
                    End If
                    CType(CType(objMemb(Involucr(kPT, jPT).IndObject), wn_PT).Piastra, wn_FTC).hr = Value
                End If
            End With
        End Set
    End Property
    Public ReadOnly Property TVARIp(ByVal i As Short) As String
        Get
            TVARIp = TVARI(i)
        End Get
    End Property
    Public Property CVARIp(ByVal i As Short) As String
        Get
            CVARIp = CVARI(i)
        End Get
        Set(ByVal Value As String)
            CVARI(i) = Value
        End Set
    End Property
    Public ReadOnly Property UVARIp(ByVal i As Short) As String
        Get
            UVARIp = UVARI(i)
        End Get
    End Property
    Public ReadOnly Property NVARIp(ByVal i As Short) As String
        Get
            NVARIp = NVARI(i)
        End Get
    End Property



    Public Property SicBullp() As Single
        Get
            SicBullp = Configwn.SicBull
        End Get
        Set(ByVal Value As Single)
            Configwn.SicBull = Value
        End Set
    End Property


    Public Property Verbose() As Boolean
        Get
            Verbose = Configwn.Verbose
        End Get
        Set(ByVal Value As Boolean)
            Configwn.Verbose = Value
        End Set
    End Property


    Public Property FattBoltSy() As Single
        Get
            FattBoltSy = Configwn.PIsuOpe
        End Get
        Set(ByVal Value As Single)
            Configwn.PIsuOpe = Value
        End Set
    End Property


    Public Property BoltLoadDetail() As Boolean
        Get
            BoltLoadDetail = Configwn.BoltLoadDetail
        End Get
        Set(ByVal Value As Boolean)
            Configwn.BoltLoadDetail = Value
        End Set
    End Property
    Public WriteOnly Property UniMis() As Short
        Set(ByVal Value As Short)
        End Set
    End Property
    Public Sub Vari()
        Dim i, ifl As Short
        Dim k As String
        ifl = FreeFile()
        With Mem
225:        If .LOOSE = -1 Or .LOOSE = 2 Then
227:            .File = ".ljf"
                If .M(195) = 1 And .LOOSE = 2 Then
                    FileOpen(ifl, clsInizio.Archdir.Trim & "\WN5\fh_VARI.ljf", OpenMode.Input, , OpenShare.Shared)
                    For i = 1 To 73
                        Sub230(ifl, i)
                    Next i
                    For i = 74 To 104 : k = LineInput(ifl) : Next i
                ElseIf .M(195) = 2 And .LOOSE = 2 Then
                    FileOpen(ifl, clsInizio.Archdir.Trim & "\WN5\fk_VARI.ljf", OpenMode.Input, , OpenShare.Shared)
                    For i = 1 To 73
                        Sub230(ifl, i)
                    Next i
                    For i = 74 To 104 : k = LineInput(ifl) : Next i
                Else
                    FileOpen(ifl, clsInizio.Archdir.Trim & "\WN5\lj_VARI.ljf", OpenMode.Input, , OpenShare.Shared)
                    For i = 1 To 72
                        Sub230(ifl, i)
                    Next i
                    For i = 73 To 104 : k = LineInput(ifl) : Next i
                End If
                For i = 105 To 155
                    Sub230(ifl, i)
                Next i
            ElseIf .LOOSE = 5 Then
                .File = ".A14"
                FileOpen(ifl, clsInizio.Archdir.Trim & "\WN5\wn_VARI.A14", OpenMode.Input, , OpenShare.Shared)
                For i = 1 To 66
                    Sub230(ifl, i)
                Next i
            ElseIf .LOOSE = 6 Then
                .File = ".A15"
                FileOpen(ifl, clsInizio.Archdir.Trim & "\WN5\wn_VARI.A15", OpenMode.Input, , OpenShare.Shared)
                For i = 1 To 66
                    Sub230(ifl, i)
                Next i
            ElseIf .LOOSE = 7 Then
                .File = ".REV"
                FileOpen(ifl, clsInizio.Archdir.Trim & "\WN5\wn_VARI.REV", OpenMode.Input, , OpenShare.Shared)
                For i = 1 To 93
                    Sub230(ifl, i)
                Next i
            Else
229:            If .LOOSE = 4 Then .File = ".cop" Else .File = ".wnf"
                FileOpen(ifl, clsInizio.Archdir.Trim & "\WN5\wn_VARI.WNF", OpenMode.Input, , OpenShare.Shared)
                For i = 1 To 88
                    Sub230(ifl, i)
                Next i
                For i = 89 To 120 : k = LineInput(ifl) : Next i
                For i = 121 To 180
                    Sub230(ifl, i)
                Next i
            End If 'l
        End With
        FileClose(ifl)
    End Sub
    Private Sub Sub230(ByVal ifl As Integer, ByVal i As Integer)
        Dim n As Integer
        Dim k As String = LineInput(ifl)
        If Len(k) > 0 Then
            TVARI(i) = Mid(k, 1, 1) 'tipo variabile
            PosVARI(i) = GlobalRoutines.ValVir(Mid(k, 2, 3)) 'posizione vettore dati
            k = Right(k, Len(k) - 5)
            n = InStr(k, "³")
            NVARI(i) = Left(k, n - 1) 'nome variabile
            k = Right(k, Len(k) - n)
            n = InStr(k, "³")
            UVARI(i) = Left(k, n - 1) 'unità di misura
            k = Right(k, Len(k) - n)
            n = InStr(k, "³")
            VVARI(i) = GlobalRoutines.ValVir(Left(k, n - 1)) 'pagina video
            If Mid(k, 17, 1) = "A" Then VVARI(i) = 10
            k = Right(k, Len(k) - n)
            n = InStr(k, "³")
            RVARI(i) = GlobalRoutines.ValVir(Left(k, n - 1)) 'riga video
            k = Right(Trim(k), Len(k) - n)
            CVARI(i) = k ' Mid$(k$, 22, 1)  'tipo conversione
        Else
            '????????
        End If
    End Sub
    Sub wncope()
        Dim p, d, c, Sco As Single
        Dim HG, sca, W, mm As Single
        Dim ab, E, db, wm1 As Single
        Dim T2Cope, co, T1Cope, T3Cope As Single
        Dim T0, tc, TP, t As Single
        Dim Testo As String
        Dim Stringa(2) As String
        Dim junk As Short
        With Mem
            On Error GoTo ErrCope
            If qbflan > 0 Then qbflan = 0
            '       IF .m(37) = 0 THEN
            Call PreliminF()
            If qbflan = 1 Or qbflan = 3 Or qbflan = -99 Then Exit Sub
            '       END IF
15039:      'inizio verifica coperchio piano
            If .Z(122) = 0 Then .Z(122) = .Z(123) : .M(122) = .Z(123) * psi
            If .Z(123) = 0 Then .Z(123) = .Z(122) : .M(123) = .Z(122) * psi
            If .Z(122) = 0 Then .Z(122) = .Z(22) : .M(122) = .M(22)
            If .Z(123) = 0 Then .Z(123) = .Z(23) : .M(123) = .M(23)
            d = .Z(37) : c = 0.3 : p = .Z(1) : Sco = .Z(123)
            sca = .Z(122) : W = .Z(42) : HG = .Z(49) : mm = .Z(30)
            E = .Z(124) : db = .Z(14) : ab = .Z(46)
            If .Z(33) < .Z(40) Then wm1 = .Z(40) Else wm1 = .Z(33)
            If .Z(120) < .Z(121) Then co = .Z(121) Else co = .Z(120)
            Call CopeMin(T1Cope, T2Cope, T3Cope, .Z(1))
            If T1Cope < T2Cope Then tc = T2Cope Else tc = T1Cope
            If T2Cope < T3Cope Then TP = T3Cope Else TP = T2Cope
            tc = tc + co
            '-------------TEMA RCB-9.21
            If Not (E = 0 Or .Z(32) = 0) Then 'Wmt=0
                sb = .Z(25) 'allowable for bolts at temp
                T0 = .Z(37) / 800 'recommended deflection limit
                If T0 < 0.03 Then T0 = 0.03
                t = d / E / (.Z(119) - co) ^ 3 * (0.0435 * d ^ 3 * p + 0.5 * sb * ab * HG) '?????+ CO
            End If
            '---------------------------------------------------------------
15044:      .Z(125) = T1Cope : .Z(126) = T2Cope : .Z(127) = T3Cope : .Z(128) = tc : .Z(129) = TP : .Z(130) = T0
            .Z(131) = t : .Z(134) = .Z(119) - co : .Z(133) = wm1
            .M(125) = T1Cope * inc : .M(126) = T2Cope * inc : .M(127) = T3Cope * inc : .M(128) = tc * inc : .M(129) = TP * inc : .M(130) = T0 * inc
            .M(131) = t * inc : .M(134) = .Z(134) * inc : .M(133) = wm1 * NIUT
            If qbflan < 0 Then Exit Sub
            If .M(128) > .M(119) Then
                'Testo = clsInizio.ConvertiCr("Attenzione: spessore adottato|insufficiente!")
                'messagebox.show Testo, vbCritical
                pagina = 6
                .Conforme = "NO"
                qbflan = 1
            Else
                pagina = 1
            End If
            If .Z(32) > 0 Then
                If .Z(131) > .Z(130) Then
                    Testo = "La freccia del coperchio al centro"
                    Testo = Testo & "|è superiore al limite RCB-9.21.   "
                    Testo = Testo & "|  Limite raccomandato: " & GlobalRoutines.myStr(CSng(.M(130)), 3, 2, False) & " mm"
                    Testo = Testo & "|  Valore calcolato   : " & GlobalRoutines.myStr(CSng(.M(131)), 3, 2, False) & " mm"
                    If ContinuoAuto Then
                        Testo = Testo & "|       Cosa vuoi fare ? "
                        Stringa(1) = "Cambiare qualche dato"
                        Stringa(2) = "Confermare i dati impostati"
                        junk = Monitor.Motore.Quale(2, "Deflessione coperchio", Stringa, "", 1, clsInizio.ConvertiCr(Testo))
                    Else
                        junk = 2
                        PrintlstRes(Testo)
                    End If
                    Select Case junk
                        Case 0 : qbflan = -99 : Exit Sub
                        Case 1 : pagina = 6
                        Case 2 : pagina = 1
                    End Select
                End If
            End If
            '   cop = 1
15045:      Exit Sub
ErrCope:    If Err.Number = 6 Or Err.Number = 11 Then
                Testo = Involucr(kLato, jInvolucr).Mark.Trim & "." & vbCrLf
                Testo = Testo & "Mancano dati essenziali nell'input"
                MessageBox.Show(formTab, Testo, "AsmeVip - Calcolo Grandi Fucinati")
                pagina = 1
                Resume 15045
            Else
                MessageBox.Show(formTab, "wncope " & Err.Description & Str(Erl()))
                ' Stop
                ' Resume
            End If
        End With
    End Sub

    Public Function wnrota(ByRef Z0 As Single, ByRef ZZ As Single, ByRef J1 As Single, ByRef rapp As Single, Optional ByRef mostra As Boolean = False) As Boolean
        Dim gef, W, HG, mm As Single
        Dim g1, b, g0, H As Single
        Dim f, a, t, V As Single
        Dim m1, m2 As Single
        Dim Testo As String
        Dim Stringa(2) As String
        Dim Risult(2) As String
        Dim Arch(2) As Short
        Dim dAiu(2) As String
        Dim c0, R1, E, R2, H0 As Single
        Dim k, K0, n, x As Single
        Dim c2, y, c1, c3 As Single
        Dim c6, c4, C5, c7 As Single
        Dim Flangia As String
        Dim objROTFL As New typROTFL
        'objROTFL.initialize()
        wnrota = True
        With Mem
            If .File = ".cop" Then
                W = .M(40) '.m(42)
                HG = .M(49) : gef = .M(37)
                mm = HG * (W - pi / 4 * gef ^ 2 * .M(1)) + 0.087 * gef ^ 3 * .M(1)
                t = .M(119)
                Flangia = "del coperchio"
            Else
                Flangia = "della flangia"
                If Not (.LOOSE = -1 Or .LOOSE = 2) Then
                    b = .M(6) + 2 * .M(11)
                    g0 = .M(7) - .M(11)
                    g1 = .M(8) - .M(11)
                    H = .M(10)
                    If b * g0 * g1 * H = 0 Then Exit Function
                End If
                a = .M(3) : t = .M(9)
                f = .M(66) : V = .M(67)
                m1 = .M(72) : m2 = .M(73)
                If m1 > m2 Then mm = m1 Else mm = m2
                '        M = .m(47) * .m(50) + .m(48) * .m(51) + .m(49) * (.m(42) - PI / 4 * .m(37) * .m(37) * .m(1))
            End If
            If AddDistinta > 0 Then
                If Matdim(0).ElasCod > 0 Then
                    .M(90) = .Z(90) / psi
                End If
                If Matdim(2).ElasCod > 0 Then
                    .M(187) = .Z(90) / psi
                End If
            End If
            If .M(90) = 0 Then
                .M(90) = Matdim(Involucr(kLato, jInvolucr).indice(0)).EmodAlt(.M(2))
                .Z(90) = .M(90) * psi
            End If
            If .M(187) = 0 Then
                .M(187) = Matdim(Involucr(kLato, jInvolucr).indice(1 - 1)).EmodAlt(.M(2))
                .Z(187) = .M(187) * psi
            End If
            If .M(90) = 0 Or .M(187) = 0 Then
23070:          Stringa(1) = "Modulo di Young flangia, a " & GlobalRoutines.myStr(CSng(.M(2)), 3, 0, False) & "°C [MPa]"
                Risult(1) = GlobalRoutines.myStr(CSng(.M(90)), 9, 0, False)
                Stringa(2) = "Modulo di Young bulloni, a " & GlobalRoutines.myStr(CSng(.M(2)), 3, 0, False) & "°C [MPa]"
                Risult(2) = GlobalRoutines.myStr(CSng(.M(187)), 9, 0, False)
                If Not Monitor.Motore.InputDati(2, "AsmeVip", Stringa, Risult, "", Arch, dAiu) Then wnrota = False : Exit Function
                .M(90) = GlobalRoutines.ValVir(Risult(1)) : .Z(90) = .M(90) * psi
                .M(187) = GlobalRoutines.ValVir(Risult(2)) : .Z(187) = .M(187) * psi
            End If
            If E = 0 Then E = .M(90)
            'rotazio = 1
            If .File = ".cop" Then
                If Not ROTFL(objROTFL) Then
                    wnrota = False
                    Exit Function
                End If
                Environment.CurrentDirectory = Monitor.Motore.Inizio.Basedir & "\Dll"
                ROTFLFOR(objROTFL)
                J1 = 0 ' objROTFL.J1
                rapp = objROTFL.rapp
                If rapp < 1 Then rapp = 1
                ZZ = 2 * mm / E / t ^ 3
                Z0 = 180 * ZZ / pi
            Else
                If Not (.LOOSE = -1 Or .LOOSE = 2) Then
                    If Not ROTFL(objROTFL) Then
                        wnrota = False
                        Exit Function
                    End If
                    Environment.CurrentDirectory = Monitor.Motore.Inizio.Basedir & "\Dll"
                    ROTFLFOR(objROTFL)
23074:              R1 = b / 2
                    R2 = a / 2
                    c0 = g1 / g0
                    H0 = System.Math.Sqrt(2 * R1 * g0)
                    K0 = H / H0
                    n = 0.3
                    k = R2 / R1
                    x = (12 * (1 - n ^ 2) * H ^ 4) / (R1 ^ 2 * g0 ^ 2)
                    y = (g1 - g0) / g0
                    c1 = (k ^ 2 - 1) / (((1 + n) / (1 - n)) * k ^ 2 + 1)
                    c2 = 2 * R1 * x / ((1 + y) ^ 3 * E * g0 * H ^ 2)
                    c3 = mm / (4 * pi * (R2 - R1))
                    c4 = 0.5 + ((1 + n) / (1 - n)) * (k ^ 2 / (k ^ 2 - 1)) * System.Math.Log(k)
                    C5 = 1 + ((t / g0) / System.Math.Sqrt(2 * R1 / g0)) * f
                    c6 = (1 + n) * (k ^ 2 - 1) * (t / g0) ^ 3 * V 'il secondo * era un +
                    c7 = (((1 + n) / (1 - n)) * k ^ 2 + 1) * System.Math.Sqrt(2 * R1 / g0)
                    a1 = (c1 * c2 * c3) * (c4 / (C5 + c6 / c7))
                    ZZ = a1 * ((R1 / H) * (3 * (1 - n ^ 2) / x) ^ 0.25 * (1 + n) ^ 3) * V 'era (1-N)^3
                    Z0 = 180 * ZZ / pi
                    .M(94) = (mm / (R2 - R1)) : .M(95) = x : .M(96) = y
                    .M(103) = g0 : .M(104) = g1
                    .M(97) = (1 + 0.3) / (1 - 0.3) : .M(98) = R2 / R1
                    .Z(92) = R1 / inc
                    .Z(93) = R2 / inc : .Z(94) = (mm / (R2 - R1))
                    .Z(97) = (1 + 0.3) / (1 - 0.3) : .Z(98) = R2 / R1
                    .Z(95) = x
                    .Z(96) = y
                    .Z(103) = g0 / inc : .Z(104) = g1 / inc
                    J1 = objROTFL.J1
                    rapp = objROTFL.rapp
                    If rapp < 1 Then rapp = 1
                Else
23076:              b = .M(6)
                    If b = 0 Then Exit Function
                    ZZ = 12 * mm / E / (a - b) * 2 / t ^ 3 * (a + b) / 2 / 2 / pi
                    J1 = 109.4 * mm / E / t ^ 3 / 0.2 / System.Math.Log(a / b)
                    Z0 = 180 * ZZ / pi
                    If Not ROTFL(objROTFL) Then Exit Function
                    Environment.CurrentDirectory = Monitor.Motore.Inizio.Basedir & "\Dll"
                    ROTFLFOR(objROTFL)
                    J1 = objROTFL.J1
                    rapp = objROTFL.rapp
                    If rapp < 1 Then rapp = 1
                End If
            End If
            .Z(90) = E * psi : .Z(91) = mm * MomToBS
            .Z(99) = a1 : .Z(100) = ZZ : .Z(101) = Z0 : .Z(102) = b / inc
            .M(99) = a1 : .M(100) = ZZ : .M(101) = Z0 : .M(102) = b
23320:      .M(90) = E : .M(91) = mm : .M(92) = R1 : .M(93) = R2
            If mostra Then
                Testo = "   Rotazioni in condizioni di progetto:|"
                Testo = Testo & "Rotazione " & Flangia & " in radianti = " & GlobalRoutines.myStr(CSng(ZZ), 5, 4, False)
                Testo = Testo & "|Rotazione " & Flangia & " in gradi    = " & GlobalRoutines.myStr(CSng(Z0), 5, 4, False)
                If Not ContinuoAuto Then Monitor.Motore.Messaggio(clsInizio.ConvertiCr(Testo), Tit:="AsmeVip", Proportional:=True)
            End If '0
        End With
    End Function
    Sub CopeMin(ByRef T1Cope As Single, ByRef T2Cope As Single, ByRef T3Cope As Single, ByRef PCope As Single)
        Dim CCope, DCope, Sco As Single
        Dim WCope, sca, HGCope As Single
        Dim ECope, MCope, DBCope As Single
        Dim co, ABCope, wm1 As Single
        With Mem
            DCope = .Z(37) : CCope = 0.3 : Sco = .Z(123)
            sca = .Z(122) : WCope = .Z(42) : HGCope = .Z(49) : MCope = .Z(30)
            ECope = .Z(124) : DBCope = .Z(14) : ABCope = .Z(46)
            If .Z(33) < .Z(40) Then wm1 = .Z(40) Else wm1 = .Z(33)
            If .Z(120) < .Z(121) Then co = .Z(121) Else co = .Z(120) 'o WCope
15043:      T1Cope = DCope * System.Math.Sqrt((CCope * PCope / Sco) + (1.9 * wm1 * HGCope / (Sco * DCope ^ 3)))
            T2Cope = DCope * System.Math.Sqrt(1.9 * WCope * HGCope / (sca * DCope ^ 3))
            T3Cope = DCope * System.Math.Sqrt(1.9 * wm1 * HGCope / (Sco * DCope ^ 3))
        End With
    End Sub
    Sub Salva(ByRef fs As FileStream)
        Lancio.Legacy.Serialization.LegacyBinarySerializer.EnsureEnabled()
        Dim bf As New Lancio.Legacy.Serialization.LegacyBinarySerializer
        If Str(Mem.M(165)) = " 25.4" And Str(Mem.Z(165)) = " 645.16" Then Mem.M(165) = 0 : Mem.Z(165) = 0
        bf.Serialize(fs, Mem)
        If Configwn.BoltLoadDetail And Serr Is Nothing Then Configwn.BoltLoadDetail = False
        bf.Serialize(fs, Configwn)
        If Not Diaf Is Nothing Then Diaf.Salva(fs)
        If Configwn.BoltLoadDetail And Not Serr Is Nothing Then
            Dim nomefile As String
            nomefile = Left(icome, Len(icome) - 4)
            nomefile = nomefile & Trim(Str(Involucr(kLato, jInvolucr).IndObject))
            nomefile = nomefile & ".TIR"
            Serr.scrivi(nomefile)
        End If
    End Sub
    Public Overloads Function Leggi(ByRef ifl As Short) As Boolean
        Dim nomefile As String
        Dim i, nMem As Short
        Leggi = True
        nMem = 300
        For i = 1 To nMem
            FileGet(ifl, Mem.M(i))
            FileGet(ifl, Mem.Z(i))
        Next
        FileGet(ifl, F1) : Mem.File = F1.Trim
        FileGet(ifl, F1) : Mem.TIR = F1.Trim
        FileGet(ifl, Mem.XFil)
        FileGet(ifl, F2) : Mem.Gasket = F2.Trim
        FileGet(ifl, F2) : Mem.GasMat = F2.Trim
        FileGet(ifl, F1) : Mem.VERIFICA = F1.Trim
        FileGet(ifl, F1) : Mem.Conforme = F1.Trim
        FileGet(ifl, F2) : Mem.DOCU = F2.Trim
        FileGet(ifl, F2) : Mem.FLID = F2.Trim
        FileGet(ifl, F2) : Mem.FLMA = F2.Trim
        FileGet(ifl, F2) : Mem.TIMA = F2.Trim
        FileGet(ifl, F2) : Mem.COID = F2.Trim
        FileGet(ifl, F2) : Mem.COMA = F2.Trim
        FileGet(ifl, F2) : Mem.NOID = F2.Trim
        FileGet(ifl, F2) : Mem.NOMA = F2.Trim
        FileGet(ifl, F2)
        FileGet(ifl, F2)
        FileGet(ifl, Mem.LOOSE)
        FileGet(ifl, Configwn)
        If Not Mem.M(161) = 14 Then
            Diaf = Nothing
        ElseIf Not Mem.LOOSE = 4 Then
            Diaf = Nothing
        Else
            Diaf = New wn_Diaf
            Leggi = Diaf.Leggi(ifl)
        End If
        If Configwn.BoltLoadDetail Then
            Serr = New Tiranti.Serraggio
            Serr.DoveMotore = Monitor.Motore
            nomefile = Left(icome, Len(icome) - 4)
            nomefile = nomefile & Trim(Str(Involucr(kLato, jInvolucr).IndObject))
            nomefile = nomefile & ".TIR"
            Serr.Sciolto = False
            Leggi = Serr.apri(nomefile)
        End If
    End Function
    Public Overloads Function Leggi(ByRef fs As FileStream) As Boolean
        Lancio.Legacy.Serialization.LegacyBinarySerializer.EnsureEnabled()
        Dim bf As New Lancio.Legacy.Serialization.LegacyBinarySerializer
        Dim nomefile As String
        Mem = CType(bf.Deserialize(fs), typMemoryBank)
        Leggi = True
        Configwn = CType(bf.Deserialize(fs), wnConfig)
        If Not Mem.M(161) = 14 Then
            Diaf = Nothing
        ElseIf Not Mem.LOOSE = 4 Then
            Diaf = Nothing
        Else
            Diaf = New wn_Diaf
            Leggi = Diaf.Leggi(fs)
        End If
        If Configwn.BoltLoadDetail Then
            Serr = New Tiranti.Serraggio
            Serr.DoveMotore = Monitor.Motore
            nomefile = Left(icome, Len(icome) - 4)
            nomefile = nomefile & Trim(Str(Involucr(kLato, jInvolucr).IndObject))
            nomefile = nomefile & ".TIR"
            Serr.Sciolto = False
            Leggi = Serr.apri(nomefile)
        End If
    End Function
    Public Sub CambioUnita(ByRef Ind As Short)
        '2240    'cambio unità di misura
        Select Case CVARI(Ind)
            Case "A"
                CVARI(Ind) = "D" : TVARI(Ind) = "X"
                UVARI(Ind) = " [Mpa]"
            Case "-A"
                CVARI(Ind) = "-D" : TVARI(Ind) = "X"
                UVARI(Ind) = " [Mpa]"
            Case "B"
                CVARI(Ind) = "E" : TVARI(Ind) = "X"
                UVARI(Ind) = " [°C] "
            Case "D"
                CVARI(Ind) = "A" : TVARI(Ind) = "C"
                UVARI(Ind) = " [psi]"
            Case "-D"
                CVARI(Ind) = "-A" : TVARI(Ind) = "C"
                UVARI(Ind) = " [psi]"
            Case "E"
                CVARI(Ind) = "B" : TVARI(Ind) = "C"
                UVARI(Ind) = " [°F] "
        End Select
    End Sub
    Public Sub SupCalcola()
        Mem.Conforme = "SI"
        Do
            Calcola()
            If qbflan = -99 Then Mem.Conforme = "NO"
            If qbflan = 1 Or qbflan = 5 Or qbflan <= -98 Then GiaCalc = False : Exit Sub
        Loop While qbflan = 4
        GiaCalc = Calcolo
        ' If Not qbflan = 1 Then pagina = 99
        ' Call frmTab.SetPagina(1)
    End Sub
    Public Function Calcola() As Boolean
        Dim icont As Short
        Dim Sn As Single
        Dim Stringa(3) As String
        Dim Testo As String
        Dim junk As Short
        Dim i As Short
        Dim lll, j As Short
        Dim jj As Short
        Dim ii, Ncont As Short
        Ncont = 300
        Calcola = True
        With Mem
            On Error GoTo ErrCalcola
            If qbflan = 0 Then
                .Conforme = "SI"
                PulisciAsterischi()
            End If
            If qbflan > 0 Then qbflan = 0
            If .File = ".cop" Then
                icont = 0
RifCop:         cop = 1 : Call wncope() : cop = 0 'goto 1000
                If qbflan = 1 Then formTab.SetPagina(1) : Exit Function
                If qbflan = -99 Then Exit Function
7000:           If qbflan <= 0 Then
                    pagina = 0
7080:               NonVal = False
                    FattSic = .Z(128) / .Z(119)
7090:               If FattSic > 1 Then NonVal = True
                    If qbflan < 0 Then
                        '                  IF qbflan = -2 THEN EXIT SUB
                        FattSic1 = (.M(45) / .M(46))
                        If FattSic1 > FattSic And .Z(1) > 0 Then
                            qbflan = -2
                            FattSic = FattSic1 ^ 0.75
                        Else
                            qbflan = -1
                        End If
                        'FattSic = 1 / FattSic
                        If System.Math.Abs(FattSic - 1) < 0.001 Then
                            NonVal = False : Exit Function
                        End If
                        .M(1) = .M(1) / FattSic ^ (0.333333 ^ (2 * icont / Ncont))
                        .Z(1) = .M(1) * psi
                        icont = icont + 1
                        If icont > Ncont Then
                            Calcola = False
                            Exit Function
                        End If
                        GoTo RifCop
                    End If
                End If
            ElseIf .File = ".cob" Then
                icont = 10
7010:           '      cob = 1
                Select Case Config(kLato).DC
                    Case 0, 1, 2, 9, 10, 11
                        Call wncobu()
                    Case 3, 4, 5
                        Call wncope()
                        Issue.SR = 0
                        Issue.SpCopA = .M(119)
                        Issue.SpCop = .M(125)
                        Issue.Diam = .M(37)
                        Issue.CorrCop = .M(120)
                        Issue.AllCop = .Z(123)
                        Issue.VerificandoPI = VerificandoPI
                        If .M(121) > .M(120) Then Issue.CorrCop = .M(121)
                        Issue.AllN = 0
                        Nozzles(kLato, kNozzle).Pdes = .Z(1)
                        Nozzles(kLato, kNozzle).Tdes = .Z(2)
                        Nozzles(kLato, kNozzle).MateCop = Involucr(kLato, jInvolucr).MATE
                        Nozzles(kLato, kNozzle).Risult = 0
                        Do
                            If Not VerificaAllN(kNozzle, jInvolucr, Sn) Then Calcola = False : Exit Function
                        Loop Until Sn > 0
                        If Not ContinuoAuto Then Nozzles(kLato, kNozzle).BNoRinf = False
Rif:                    OP(Nozzles(kLato, kNozzle), NozzAdd(kLato, kNozzle), Issue)
                        Select Case ExamRis(kNozzle, Nozzles(kLato, kNozzle).InvolucroSU, Issue, LoadCond > 2)
                            Case -2 : qbflan = -1 : Exit Function
                            Case -1 : qbflan = -1 ': Exit Function
                            Case 0
                            Case 1 : GoTo Rif
                            Case 2 : qbflan = -98 'procedi ugualmente
                            Case 11 ' si vuole calcolare comunque
                                Nozzles(kLato, kNozzle).Risult = 2
                                Nozzles(kLato, kNozzle).BNoRinf = True
                                GoTo Rif
                        End Select
                End Select
                If qbflan = 1 Then formTab.SetPagina(1) : Exit Function
                If qbflan = -99 Then Exit Function
                If qbflan <= 0 Then
                    NonVal = False ': Exit Sub
                    Select Case Config(kLato).DC
                        Case 0, 1, 2, 9, 10, 11
                            FattSic1 = -1
                        Case 3, 4, 5
                            With Issue
                                FattSic = .a / (.a1 + .a2 + .A2PROT + .A3 + .A4)
                                FattSic1 = .Aa / (.AA1 + .a2 + .A2PROT + .AA3 + .A4)
                                If FattSic1 > FattSic Then FattSic = FattSic1
                            End With
                    End Select
                    If FattSic1 = -1 Then Exit Function
                    If qbflan < 0 Then
                        '                  IF qbflan = -2 THEN EXIT SUB
                        FattSic1 = (.M(45) / .M(46))
                        If FattSic1 > FattSic And .Z(1) > 0 Then
                            qbflan = -2
                            FattSic = FattSic1 ^ 0.75
                        Else
                            qbflan = -1
                        End If
                        'FattSic = 1 / FattSic
                        If System.Math.Abs(FattSic - 1) < 0.001 Then
                            NonVal = False : Exit Function
                        End If
                        .M(1) = .M(1) / FattSic ^ 0.333333 : .Z(1) = .M(1) * psi
                        icont = icont + 1
                        If icont > Ncont Then
                            Calcola = False
                            Exit Function
                        End If
                        GoTo 7010
                    End If
                End If
            Else
                If jInvolucr = 0 Then
                    .FLID = Nozzles(kLato, kNozzle).Mark
                    .FLMA = Matdim(Nozzles(kLato, kNozzle).IndexF).MatStr
                Else
                    .FLID = Involucr(kLato, jInvolucr).Mark
                    .FLMA = Matdim(Involucr(kLato, jInvolucr).indice(0)).MatStr
                End If
                icont = 10
                If LoadCond > 2 And .M(46) > 0 And (.LOOSE < 5 Or .LOOSE > 6) Then
                    If .M(45) / .M(46) > 1.0001 Then
                        .M(1) = 0 : .Z(1) = 0
                        qbflan = -2
                        Exit Function
                    End If
                End If
RifC:           Do
                    If .LOOSE = -1 Or .LOOSE = 2 Then
                        Call ljflan() : If qbflan = 1 Then formTab.SetPagina(1) : Exit Function
                    ElseIf .LOOSE = 5 Or .LOOSE = 6 Then
                        Call App14()
                        If qbflan = 1 Then formTab.SetPagina(1) : Exit Function
                    Else
                        For i = 78 To 82
                            j = 0 : If .LOOSE = 5 Or .LOOSE = 6 Then j = 21
                            lll = InStr(CVARI(i - j), "*")
                            If lll > 0 Then CVARI(i - j) = Left(CVARI(i - j), lll - 1)
                            If .LOOSE = 5 Or .LOOSE = 6 Then
                                lll = InStr(CVARI(i - 16), "*")
                                If lll > 0 Then CVARI(i - 16) = Left(CVARI(i - 16), lll - 1)
                            End If
                        Next
                        Call wnflan()
                        If qbflan = 5 Then Exit Function
                        If qbflan = 1 Then formTab.SetPagina(1) : Exit Function
                    End If
                    If qbflan = -99 Then Exit Function
                Loop While qbflan = 3
                If qbflan <= 0 Then
                    pagina = 0
                    NonVal = False
                    If .LOOSE = -1 Or .LOOSE = 2 Then
                        If .M(195) = 1 Then
                            If .Z(9) = 0 Then .Z(9) = 0.1
                            FattSic = (.Z(82) + .Z(11)) / .Z(9)
                        Else
                            FattSic = .Z(78) / .Z(23)
                        End If
                        If FattSic > 1 Then
                            NonVal = True
                        End If
                    ElseIf .LOOSE = 5 Or .LOOSE = 6 Then
                        FattSic = 0
                        j78 = 57 : j2 = -19 : jj = 0
                        ColorWarn(jj)
                        j78 = 62 : j2 = -14 : jj = 52
                        ColorWarn(jj)
                    Else
                        FattSic = 0
                        j78 = 78 : j2 = 2 : jj = 0
                        ColorWarn(jj)
                    End If
                    If qbflan < 0 Then
                        If .LOOSE < 5 Or .LOOSE > 6 Then
                            FattSic1 = .M(45) / .M(46)
                            If FattSic1 > FattSic Then FattSic = FattSic1 : qbflan = -2
                            'j# = .m(71): MO# = .m(72): MW# = .m(73)
                            'IF MW# * j# > MO# AND FattSic > 1 THEN FattSic = SQR(FattSic * MO# / (MW# * j#)): qbflan = -2
                        End If
                        If System.Math.Abs(FattSic - 1) < 0.0001 Then NonVal = False : Exit Function
                        .M(1) = .M(1) / FattSic : .Z(1) = .Z(1) / FattSic
                        icont = icont + 1
                        If icont > Ncont Then
                            Calcola = False
                            Exit Function
                        End If
                        GoTo RifC
                    End If
                    If NonVal Then
                        Testo = "La flangia non è verificata"
                        Testo = Testo & "|       Cosa vuoi fare ? "
                        Stringa(1) = "Cambiare qualche dato"
                        Stringa(2) = "Calcolare il nuovo spessore minimo"
                        Stringa(3) = "Confermare i dati impostati"
                        junk = Monitor.Motore.Quale(3, "Risultati del calcolo", Stringa, "", 1, clsInizio.ConvertiCr(Testo))
                        Select Case junk
                            Case 0 : qbflan = -99 : Exit Function
                            Case 1 : pagina = 1
                                formTab.SetPagina(1)
                                qbflan = 1
                                Exit Function
                            Case 2 : .M(9) = 0
                                qbflan = 4
                                Exit Function
                            Case 3
                                NonVal = False
                        End Select
                    Else
                        Call wnrota05()
                    End If
                Else
                    NonVal = True
                End If
                formTab.SetPagina(1)
            End If
            Calcolo = True
Rexit:
            Exit Function
Riprendi:
            Testo = Involucr(kLato, jInvolucr).Mark.Trim & ".|"
            Testo = Testo & " Ci sono probabilmente degli er- |"
            Testo = Testo & "rori nei dati o dei dati mancanti.|"
            MessageBox.Show(formTab, clsInizio.ConvertiCr(Testo), "AsmeVip - Calcolo Grandi Fucinati")
            qbflan = 1 ':qbflan = -99
            Exit Function
ErrCalcola:
            If Err.Number = 11 Then
                Resume Riprendi
            Else
                MessageBox.Show(formTab, "Errore in Calcola, modulo wn_flan." & vbCrLf & Err.Description & Str(Erl()))
                Calcola = False
                Resume Rexit
            End If
        End With
    End Function
    Private Sub wnrota05()
        Dim KI As Single = 0.3
        Dim KL As Single = 0.2
        Dim V, VL, M0op, M0atm, L, Eop, Eatm, g0, h0, t, k As Single
        Dim Testo As String
        With Mem
            .M(90) = Matdim(Involucr(kLato, jInvolucr).indice(0)).EmodAlt(.M(2))
            Eop = .M(90)
            If Eop = 0 Then Exit Sub
            .M(205) = Matdim(Involucr(kLato, jInvolucr).indice(0)).EmodAlt(20)
            Eatm = .M(205)
            If Eop = 0 Or Eatm = 0 Then Exit Sub
            M0op = .M(72)
            M0atm = .M(73)
            Select Case .LOOSE
                Case -1, 2 'loose without hub, optional as loose, optional as integral
                    k = .M(54)
                    t = .M(9)
                    Jop = 109.4 * M0op / (Eop * t ^ 3 * KL * Math.Log(k))
                    Jatm = 109.4 * M0atm / (Eatm * t ^ 3 * KL * Math.Log(k))
                Case 1 'loose with hubs
                    VL = .Z(67)
                    L = .M(60)
                    g0 = .M(7) - .M(11)
                    h0 = .M(55)
                    Jop = 52.14 * VL * M0op / (L * Eop * g0 ^ 2 * KL * h0)
                    Jatm = 52.14 * VL * M0atm / (L * Eatm * g0 ^ 2 * KL * h0)
                Case 0, 3 ' integral, optional as integral
                    V = .Z(67)
                    L = .M(60)
                    g0 = .M(7) - .M(11)
                    h0 = .M(55)
                    Jop = 52.14 * V * M0op / (L * Eop * g0 ^ 2 * KI * h0)
                    Jatm = 52.14 * V * M0atm / (L * Eatm * g0 ^ 2 * KI * h0)
            End Select
            .M(206) = Jop
            .M(207) = Jatm
        End With
        If Jop > 1 Or Jatm > 1 Then
            'Testo = "Il fattore di rigidezza richiesto da 2-14|non è stato ottenuto per" + Mem.FLID
            'Testo = Testo + ".|J, fattore in operating = " + GlobalRoutines.myStr(Jop, 3, 2, 0)
            'Testo = Testo + "|J, fattore in seating   = " + GlobalRoutines.myStr(Jatm, 3, 2, 0)
            Testo = GlobalRoutines.FormatS(Helpstringa(2522), Mem.FLID, GlobalRoutines.myStr(Jop, 3, 2, 0), GlobalRoutines.myStr(Jatm, 3, 2, 0))
            If ContinuoAuto Then
                PrintlstRes(Testo)
            Else
                MostraAiuto(2522, , Testo, "AsmeVip - " & Involucr(kLato, jInvolucr).Mark.Trim, True)
            End If
        Else
            Testo = GlobalRoutines.FormatS(Helpstringa(2523), Mem.FLID, GlobalRoutines.myStr(Jop, 3, 2, 0), GlobalRoutines.myStr(Jatm, 3, 2, 0))
            If Config(0).Verbose And Not ContinuoAuto Then
                MostraAiuto(2522, RoutBase1.ChiaviMess.MessInformation + RoutBase1.ChiaviMess.MessOkOnly, Testo, "AsmeVip - " & Involucr(kLato, jInvolucr).Mark.Trim, True)
            End If
            nIndent = 6
            PrintlstRes(Testo)
            nIndent = 0
        End If
    End Sub
    Private Sub ColorWarn(ByVal jj As Integer)
        With Mem
            FattSic1 = .Z(76 - jj) / .Z(82)
            If FattSic1 > FattSic Then FattSic = FattSic1
            If FattSic1 > 1 Then
                NonVal = True
                i78 = IndPos(j78)
                If InStr(CVARI(i78), "*") = 0 Then CVARI(i78) = CVARI(i78) & "*"
            End If
            Dim ii As Integer
            For ii = 77 To 80
                FattSic1 = .Z(ii - jj) / .Z(23)
                If FattSic1 > 1 Then
                    NonVal = True
                    Ind = IndPos(ii + j2)
                    If InStr(CVARI(Ind), "*") = 0 Then CVARI(Ind) = CVARI(Ind) & "*"
                End If
                If FattSic1 > FattSic Then FattSic = FattSic1
            Next
            If .LOOSE = 7 Then
                For ii = 192 To 192
                    FattSic1 = .Z(ii - jj) / .Z(23)
                    If FattSic1 > 1 Then
                        NonVal = True
                        Ind = IndPos(ii + j2)
                        If InStr(CVARI(Ind), "*") = 0 Then CVARI(Ind) = CVARI(Ind) & "*"
                    End If
                    If FattSic1 > FattSic Then FattSic = FattSic1
                Next
            End If
        End With
    End Sub
    Private Sub MAWP(ByRef mode As Short)
        Dim i As Short
        Dim Stringa1(2) As String
        Dim a As String
        Dim M1Sav, Z1sav As Single
        Dim Z33sav, Z40sav As Single
        Dim Mark As String
        Dim GiaDetto, Converge As Boolean
        ReDim PNETdim(6)
        For i = 1 To 300
            mems.M(i) = Mem.M(i)
            mems.Z(i) = Mem.Z(i)
        Next
        Stringa1(1) = "Tiranti   "
        Stringa1(2) = "Flangia   "
        If mode > 0 Then Stringa1(2) = "Coperchio "
        qbflan = -1
        If jInvolucr > 0 Then
            Mark = Involucr(kLato, jInvolucr).Mark
        Else
            Mark = Nozzles(kLato, kNozzle).Mark
        End If
        With Mem
            If mode > 3 Then Mem.File = ".cob"
            For i = 3 To 6
                iMAWP = i - 2
                LoadCond = i
                M1Sav = .M(1) : Z1sav = .Z(1)
                Z33sav = .Z(33) : Z40sav = .Z(40)
                Call Carichi(i, mode - 3)
                Converge = Calcola()
                If Not Converge Then
                    If Not GiaDetto Then
                        GiaDetto = True
                        If Not ContinuoAuto Then MostraAiuto(IDH_WN_NOCONVER, , , "AsmeVip - " & Mark.Trim)
                    End If
                    qbflan = -99
                    Ripristina()
                End If
                If qbflan = -99 Then iMAWP = 0 : Exit Sub 'Or qbflan = -1 Then Exit Sub
                PNETdim(i) = .Z(1) / psi
                If mode < 2 Then
                    Classedim(i) = qbflan '-2 bulloni limitanti -1 flangia limitante
                    qbflan = -1
                Else
                    Classedim(i) = -3
                End If
                .M(1) = M1Sav : .Z(1) = Z1sav
                .Z(33) = Z33sav : .Z(40) = Z40sav
            Next
        End With
        a = "                RISULTATI MAWP  " & UnitPress & "||"
        a = a & "      N.F.      N.C.      C.F.      C.C.  |"
        a = a & GlobalRoutines.myStr(PNETdim(3) * kPress, 8 - IncrVirgola, 1 + IncrVirgola, 0) & _
                GlobalRoutines.myStr(PNETdim(4) * kPress, 8 - IncrVirgola, 1 + IncrVirgola, 0) & _
                GlobalRoutines.myStr(PNETdim(5) * kPress, 8 - IncrVirgola, 1 + IncrVirgola, 0) & _
                GlobalRoutines.myStr(PNETdim(6) * kPress, 8 - IncrVirgola, 1 + IncrVirgola, 0)
        If mode < 2 Then
            a = a & "|    " & Stringa1(Classedim(3) + 3) & Stringa1(Classedim(4) + 3) & Stringa1(Classedim(5) + 3) & Stringa1(Classedim(6) + 3)
        End If
        If Not ContinuoAuto Then Monitor.Motore.Messaggio(clsInizio.ConvertiCr(a), Tit:="AsmeVip - " & Mark.Trim, Proportional:=True)
        Ripristina()
        qbflan = 0
    End Sub
    Private Sub Ripristina()
        Dim i As Integer
        iMAWP = 0
        For i = 1 To 300
            Mem.M(i) = mems.M(i)
            Mem.Z(i) = mems.Z(i)
        Next
        LoadCond = 2
        'formTab.VisualTipo = 2
        If jInvolucr > 0 Then
            For i = 1 To 4
                If Mem.Z(1) < 0 And kLato = 3 Then
                    Involucr(kLato, jInvolucr).MAWP2(i - 1) = PNETdim(2 + i)
                Else
                    Involucr(kLato, jInvolucr).MAWP(i - 1) = PNETdim(2 + i)
                End If
            Next
        Else
            For i = 1 To 4
                If Nozzles(kLato, kNozzle).MAWP(i - 1) > PNETdim(2 + i) Then Nozzles(kLato, kNozzle).MAWP(i - 1) = PNETdim(2 + i)
            Next
        End If
    End Sub
    Sub Carichi(ByRef mode As Short, ByRef nn As Short)
        Dim Ind11 As Short
        Dim P0, P0H As Single
        Dim Sfa, Sfo As Single
        Dim Sba, sbo As Single
        Dim sca, Sco As Single
        Dim Sna, Sno As Single
        Dim CorrN, CorrV As Single
        LoadCond = mode
        With Mem
            If jInvolucr > 0 Then
                CorrV = Involucr(kLato, jInvolucr).cs
                If Involucr(kLato, jInvolucr).OS > CorrV Then CorrV = Involucr(kLato, jInvolucr).OS
                CorrN = Involucr(kLato, jInvolucr).OS
                Ind11 = 11
                If .LOOSE = 5 Or .LOOSE = 6 Then Ind11 = 12
                AggiustaHydr(kLato, jInvolucr, 0, P0H, True)
                AggiustaHydr(kLato, jInvolucr, 0, P0)
            Else
                CorrV = Nozzles(kLato, kNozzle).CorrA
                If Nozzles(kLato, kNozzle).ONn > CorrV Then CorrV = Nozzles(kLato, kNozzle).ONn
                CorrN = Nozzles(kLato, kNozzle).ONn
                Ind11 = 11
                AggiustaHydr(kLato, 0, kNozzle, P0H, True)
                AggiustaHydr(kLato, 0, kNozzle, P0)
            End If
            Select Case mode
                Case 1 'prova idraulica
                    .M(1) = P0H
                    .M(2) = 20
                    If Configwn.LatoProgetto = 1 Then
                        '330  .m(1) = Config(2).pxTest
                        .M(Ind11) = CorrN
                        TempMin1()
                    Else
                        '340  .m(1) = Config(1).pxTest
                        .M(Ind11) = CorrN
                        TempMin2()
                    End If
                    If Configwn.CorrProva = 1 Then .M(Ind11) = 0
                Case 2 ' pressione di progetto
                    .M(1) = P0
                    .M(Ind11) = CorrV
                    .M(2) = TempDes()
                    If Configwn.LatoProgetto = 1 Then
                        '.m(2) = Config(2).tdx
                        TempMin1()
                    Else
                        '.m(2) = Config(1).tdx
                        TempMin2()
                    End If
                Case 3 'nuovo e freddo
                    .M(2) = 20 : .M(Ind11) = CorrN
                    .M(1) = P0
                Case 4 'nuovo e caldo
                    .M(Ind11) = CorrN
                    .M(1) = P0
                    .M(2) = TempDes()
                Case 5 'corroso e freddo
                    .M(2) = 20
                    .M(1) = P0
                    .M(Ind11) = CorrV
                Case 6 'corroso e caldo
                    .M(1) = P0
                    .M(2) = TempDes()
                    .M(Ind11) = CorrV
            End Select
            .M(138) = .M(Ind11)
            .M(120) = .M(Ind11)
            .Z(2) = .M(2) * 1.8 + 32
412:        Call Ammiss(nn, Sfa, Sfo, Sba, sbo, sca, Sco, Sna, Sno, 0, False)
            .M(22) = Sfa : .Z(22) = .M(22) / mpa
            .M(23) = Sfo : .Z(23) = .M(23) / mpa
            If Not (.LOOSE = 5 Or .LOOSE = 6) Then
                .M(24) = Sba : .Z(24) = .M(24) / mpa
                .M(25) = sbo : .Z(25) = .M(25) / mpa
                .M(141) = Sna : .Z(141) = .M(141) / mpa
                .M(142) = Sno : .Z(142) = .M(142) / mpa
                .M(122) = sca : .Z(122) = .M(122) / mpa
414:            .M(123) = Sco : .Z(123) = .M(123) / mpa
            End If
            .Z(1) = .M(1) * psi
            .Z(2) = .M(2) * 1.8 + 32 : .Z(Ind11) = .M(Ind11) / inc
            .Z(120) = .M(120) / inc
            .Z(138) = .M(138) / inc
            .Z(182) = .M(182) * 1.8 + 32
            .Z(183) = .M(183) * 1.8 + 32
            .Z(184) = .M(184) * psi
            .Z(185) = .M(185) * psi
            If .LOOSE = 4 Then .M(22) = .M(122) : .M(23) = .M(123) : .Z(22) = .Z(122) : .Z(23) = .Z(123)
        End With
        SetCarLoad()
    End Sub
    Private Sub TempMin1()
        With Mem
            .M(182) = Config(2).tdxMDMT(0) '.MDMTTempTubi
            .M(184) = .M(1)
            .M(183) = .M(182)
            .M(185) = .M(183)
        End With
    End Sub
    Private Sub TempMin2()
        With Mem
            .M(182) = Config(1).tdxMDMT(0) '.MDMTTempMant
            .M(184) = .M(1)
            .M(183) = .M(182)
            .M(185) = .M(183)
        End With
    End Sub
    Sub MAWPcop()
        Dim M125sav, M126sav As Single
        Dim Z33sav, Z40sav, Z133sav As Single
        Dim Z34sav, Z41sav, Z42sav As Single
        With Mem
            M125sav = .M(125) : M126sav = .M(126)
            Z40sav = .Z(40) : Z33sav = .Z(33) : Z133sav = .Z(133)
            Z41sav = .Z(41) : Z34sav = .Z(34) : Z42sav = .Z(42)
1914:       Call MAWP(1)
            If qbflan = -99 Then Exit Sub
            Call StamMAWPF(1)
            .M(125) = M125sav : .M(126) = M126sav
            .Z(125) = .M(125) / inc : .Z(126) = .M(126) / inc
            .Z(40) = Z40sav : .Z(33) = Z33sav : .Z(133) = Z133sav
            .Z(41) = Z41sav : .Z(34) = Z34sav : .Z(42) = Z42sav
            .M(40) = .Z(40) * NIUT : .M(33) = .Z(33) * NIUT : .M(133) = .Z(133) * NIUT
            .M(41) = .Z(41) * NIUT : .M(34) = .Z(34) * NIUT : .M(42) = .Z(42) * NIUT
        End With
    End Sub
    Sub MinTempF(ByRef mode As Short)
        '1 flangia non B16.5 chiamata da ASME-Vip
        '2 flangia calcolo manuale
        'negativo n-esimo bocchello su coperchio
        '3 coperchio
        '4 flangia automatica
        'UPGRADE_WARNING: Il limite inferiore della matrice Temper è stato cambiato da 1 a 0. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1033"'
        Dim Temper(2) As Single
        Dim i As Short
        Dim iMat As Short
        Dim StriSt(20) As String
        Dim tgov As Single
        Dim Aspp, R As Single
        Dim MWDTrule As String = ""
        Dim MWDTclause As String = ""
        Dim MWDTtemp As Single
        Dim YieldMWDT As Single
        Dim PNumber As String = ""
        Dim iGr As Short
        Dim SWR As Single
        With Mem
            If mode >= 0 Then
                If jInvolucr = 0 Then
                    iMat = Nozzles(kLato, kNozzle).IndexF
                Else
                    iMat = Involucr(kLato, jInvolucr).indice(0)
                End If
                Select Case .LOOSE
                    Case -1 '.LOOSE without hub
                    Case 0 : tgov = .Z(7) 'integral
                        R = .Z(6) / 2
                        Aspp = .Z(11)
                        If mode = 3 Then
                            tgov = .Z(119) / 4
                            R = 0 ': iMat = 3
                        End If
                    Case 1 '.LOOSE with hub
                    Case 2 'optional calculated as loose
                    Case 3 'optional calculated as integral
                    Case 4 : tgov = .Z(119) / 4 'coperchi
                        R = 0
                    Case 5, 6
                        tgov = .Z(7) 'integral
                        R = .Z(4) / 2
                        Aspp = .Z(12)
                        If .Z(5) < .Z(7) And .LOOSE = 6 Then
                            tgov = .Z(5) 'integral
                            R = .Z(3) / 2
                        End If
                End Select
                For i = 1 To Matdim(iMat).Caract.Count
                    If Matdim(iMat).Caract.Item(i).TextData.Codice = CodiceStress() Then
                        MWDTrule = Matdim(iMat).Caract.Item(i).TextData.MWDTrule
                        MWDTclause = Matdim(iMat).Caract.Item(i).TextData.MWDTclause
                        MWDTtemp = Matdim(iMat).Caract.Item(i).TextData.MWDTtemp
                        YieldMWDT = Matdim(iMat).Caract.Item(i).TextData.Yield
                        PNumber = Matdim(iMat).Caract.Item(i).TextData.PNumber
                        iGr = GlobalRoutines.ValVir(Matdim(iMat).Caract.Item(i).TextData.Group)
                        Exit For
                    End If
                Next
            End If
            If NotApplicable(MWDTrule, StriSt) Then Exit Sub
            If InStr(MWDTrule, "UCS") Then
                Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(StriSt(5), MWDTrule.Trim, MWDTclause))  '"Low Temperature Operation. Rules: "
            ElseIf InStr(MWDTrule, "UNF") Or InStr(MWDTrule, "UHT") Then
                Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(StriSt(6), MWDTrule.Trim))  '"xxxxxxxxxxxx"
            Else
                Monitor.Motore.Problem.Printa(StriSt(7))
            End If
            If mode >= 0 Then
                Temper(1) = .Z(182) : Temper(2) = .Z(183)
                Call MinTempCalc(0, (jInvolucr), R, SWR, Aspp, MWDTrule, MWDTclause, MWDTtemp, tgov, YieldMWDT, PNumber, iGr, " ", Temper)
            Else
            End If
        End With
    End Sub

    Sub wncobu()
        Dim Arch(3) As Short
        Dim dAiu(3) As String
        Dim M125sav, M126sav As Single
        Dim Z40sav, Z33sav As Single
        Dim ta, p, Top As Single
        Dim Massimo As Single
        Dim Testo As String
        Dim Stringa(4) As String
        Dim Risult(3) As String
        Dim Sna, Sno, k As Single
        Dim tRa, t, d, tro As Single
        Dim T2wn, T1wn, T3 As Single
        Dim VerifAlt As Boolean
        Dim NBocc As Short
        Dim DE, di As Single
        Dim CN, tn, Al As Single
        Dim Sco, sca, l As Single
        Dim j, n As Short
        Dim Aa, H, Ao As Single
        Dim Al1, Al2 As Single
        Dim jo, ja, pvec1 As Single
        Dim A1a, A1o, A2o, A2a As Single
        Dim ARinf, Areq, fact As Single
        Dim ARinf1, AReq1, fact1 As Single
        Dim ARinfv, AReqv, pvec As Single
        Dim icount As Short
        Dim ARo, ARa As Single
        Dim SpCop, SPNOZ As Single
        Dim strSPCOP As String = ""
        Dim strSPNOZ As String = ""
        Dim thk As Single
        Dim Testok As String = ""
        Dim ic, junk As Short
16001:  'COMPENSAZIONE APERTURA SU COPERCHIO PIANO
        'PRIMA VERIFICA DELL'APERTURA
        With Mem
            Try
                M125sav = .M(125) : M126sav = .M(126)
                Z40sav = .Z(40) : Z33sav = .Z(33)
                If qbflan < 0 Then p = .M(1)
16040:          ta = .M(126) * System.Math.Sqrt(2)
                Top = .M(125) * System.Math.Sqrt(2)
                If iUG39e2 Then ta = ta * System.Math.Sqrt(0.5 / efflig) : Top = Top * System.Math.Sqrt(0.5 / efflig)
                .M(143) = ta : .Z(143) = ta / inc
                .M(144) = Top : .Z(144) = Top / inc
                If .M(120) > .M(121) Then Massimo = .M(120) Else Massimo = .M(121)
                .M(134) = .M(119) - Massimo : .Z(134) = .M(134) / inc 'spessore corroso
                VerifAlt = .M(140) <= .M(37) / 2 And (NBocc = 0 Or iUG39e1 Or iUG39e2)
                If .M(134) > ta And .M(134) > Top And VerifAlt Then CoperchioAutoRinforzato = True : GoTo 18001
                CoperchioAutoRinforzato = False
                If Nozzles(kLato, kNozzle).Tipo.IndexOf("OPEN") = -1 Then
16041:              'inizio verifica compensazione
                    If .Z(141) = 0 Then .Z(141) = .Z(142)
                    If .Z(142) = 0 Then .Z(142) = .Z(141)
                    If .Z(141) = 0 Or .Z(142) = 0 Then pagina = 1 : Beep() : GoTo 17000
                    .M(141) = .Z(141) * mpa : .M(142) = .Z(142) * mpa
                    di = .M(135) : DE = .M(136) : tn = .M(137) : CN = .M(138)
                    p = .M(1)
                    Sno = .M(142) : Sna = .M(141)
16045:              'de - di - Tn   tutti definiti
                    If di <> 0 And DE <> 0 Then
                        If ((DE - di) / 2) <> tn Then
                            .M(137) = (DE - di) / 2
                            .Z(137) = .M(137) / inc
                            GoTo 16041
                        End If
                    End If
                    'de = 0 e di - Tn   definiti
                    If DE = 0 And di <> 0 And tn <> 0 Then DE = di + tn * 2
                    'di = 0 e de - Tn   definiti
                    If di = 0 And DE <> 0 And tn <> 0 Then di = DE - tn * 2
                    'Tn = 0 e di - de   definiti
                    If tn = 0 And DE <> 0 And di <> 0 Then tn = (DE - di) / 2
                    'de = 0
                    .M(135) = di : .Z(135) = di / inc
                    .M(136) = DE : .Z(136) = DE / inc
16069:              If di <> 0 Then
16070:                  'Sessore minimo tronchetto dall'interno
                        TRN = (p * (di + 2 * CN) / 2) / (Sno - 0.6 * p)
                    Else
16080:                  'Sessore minimo tronchetto dall'esterno
                        TRN = (p * (DE) / 2) / (Sno + 0.4 * p)
                    End If 'a
16085:              'Verifica spessore minimo di calcolo
                    If (TRN + CN) > tn Then GoTo 16090 Else GoTo 16100
16090:              If qbflan > -1 Then
                        Testo = "Lo spessore minimo di calcolo è"
                        Testo = Testo & "| maggiore di quello nominale."
                        Testo = Testo & "|Spessore minimo   = " & GlobalRoutines.myStr(CSng(TRN + CN), 4, 3, False)
                        Stringa(1) = "Spessore nominale = "
                        Risult(1) = GlobalRoutines.myStr(.M(137), 4, 3, False)
                        If Not Monitor.Motore.InputDati(1, "Spessore tronchetto", Stringa, Risult, Testo, Arch, dAiu, Testo) Then
                            qbflan = -99
                            GoTo fincob
                        End If
                        k = GlobalRoutines.ValVir(Risult(1))
                        If k <> 0 Then
                            .M(137) = k
                            SpsBoc(kNozzle - i1) = .M(137)
                        Else
                            .M(137) = TRN + CN
                        End If
                        tn = .M(137)
                        .Z(137) = .M(137) / inc
                        If di = 0 Then di = DE - 2 * tn
                        If DE = 0 Then DE = di + 2 * tn
                        GoTo 16041
                    Else
16092:                  If di <> 0 Then
                            'Sessore minimo tronchetto dall'interno
                            p = Sno * (tn - CN) / ((di + 2 * CN) / 2 + 0.6 * (tn - CN))
                        Else
                            'Sessore minimo tronchetto dall'esterno
                            p = Sno * (tn - CN) / (DE / 2 - 0.4 * (tn - CN))
                        End If 'b
                        qbflan = -2
                        .M(1) = p : .Z(1) = p * psi : GoTo FinCob
                    End If 'c
16100:              If qbflan < 0 Then GoTo 16140
16140:              If .Z(135) = 0 Then di = DE - 2 * tn
                    If .Z(136) = 0 Then DE = di + 2 * tn
                    .M(139) = tn - CN : .M(140) = di + 2 * CN
                    .Z(139) = .M(139) / inc : .Z(140) = .M(140) / inc
                    .M(147) = TRN : .Z(147) = .M(147) / inc
                Else
                    di = .M(135) : DE = .M(135) : tn = 0 : CN = .M(138)
                    p = .M(1)
                    .M(137) = tn : .M(136) = DE
                    .M(139) = 0 : .M(140) = di + 2 * CN
                    .Z(136) = .M(136) / inc : .Z(137) = .M(137) / inc
                    .Z(139) = .M(139) / inc : .Z(140) = .M(140) / inc
                    .M(147) = 0 : .Z(147) = .M(147) / inc : TRN = 0
                End If
                'SECONDA VERIFICA DELL'APERTURA UG-39(b)(1)  'T spess cop D dia ape
                t = .M(134) : d = di + 2 * CN
                tn = .M(139)
                If qbflan > -1 Then
                    tRa = .M(126) : tro = .M(125)
                Else
16141:              Call CopeMin(T1wn, T2wn, T3, p * psi)
                    tRa = T2wn * inc : tro = T1wn * inc
                End If 'd
16143:          sca = .M(122) : Sco = .M(123)
                Aa = 0.5 * d * tRa : .M(145) = Aa : .Z(145) = Aa / inc / inc
                Ao = 0.5 * d * tro : .M(146) = Ao : .Z(146) = Ao / inc / inc
                If 2.5 * t < 2.5 * tn Then H = 2.5 * t Else H = 2.5 * tn
                .M(148) = H : .Z(148) = H / inc
                If d > ((d / 2) + tn + t) Then l = d Else l = (d / 2) + tn + t 'UG-40(b)
                .M(149) = l : .Z(149) = l / inc
                If .M(165) < 0 Then
                    Testo = " L'altezza disponibile sul tronchetto|"
                    Testo = Testo & .NOID & " non è stata definita.|"
                    Testo = Testo & "Altezza massima a codice: " & GlobalRoutines.myStr(H * kLength, 4, 2, False) & " " & UnitLength
                    Testo = Testo & "|Altezza disponibile     : "
                    Risult(1) = GlobalRoutines.myStr(.M(165) * kLength, 4, 2, False) & " " & UnitLength
                    .M(165) = GlobalRoutines.ValVir(InputBox(Testo, .NOID, Risult(1))) / kLength ' = -2 Then GoTo FinCob
                    '.m(165) = GlobaLroutines.ValVir(Risult$(4))
                    .Z(165) = .M(165) / inc
                End If 'e
                If H > .M(165) Then H = .M(165)
                .M(150) = H : .Z(150) = H / inc
                Al = 9999
                Dim ii1 As Integer = Involucr(kLato, jInvolucr).inizio
                For j = Involucr(kLato, jInvolucr).inizio To Involucr(kLato, jInvolucr).Fine
                    If Dispon(kNozzle - ii1, j - ii1, 1) < .M(149) Then
                        Al1 = Dispon(kNozzle - ii1, j - ii1, 1)
                        If Configwn.Verbose And iMAWP = 0 And Not VerificandoPI Then
                            Testo = "La distanza del bocchello " & Nozzles(kLato, kNozzle).Mark & " dal perimetro esterno|"
                            Testo = Testo & "(" & GlobalRoutines.myStr(Al1 * kLength, 4, 2, 0) & " " & UnitLength & ") è minore delle lunghezza|"
                            Testo = Testo & "massima per il rinforzo. (" & "(" & GlobalRoutines.myStr(.M(149) * kLength, 4, 2, 0) & " " & UnitLength & ")"
                            If MostraAiuto(1, RoutBase1.ChiaviMess.MessInformation Or ChiaviMess.MessOKCancel, clsInizio.ConvertiCr(Testo), , True) = ChiaviMess.MessCancel Then
                                qbflan = -99
                                GoTo FinCob
                            End If
                        End If
                    Else
                        Al1 = l
                    End If
                    If Dispon(kNozzle - ii1, j - ii1, 2) < .M(149) Then
                        Al2 = Dispon(kNozzle - ii1, j - ii1, 2)
                        If Configwn.Verbose And iMAWP = 0 And Not VerificandoPI Then
                            Testo = "La distanza del bocchello " & Nozzles(kLato, kNozzle).Mark & " dal bocchello " & Nozzles(kLato, j).Mark
                            Testo = Testo & "|(" & GlobalRoutines.myStr(Al2 * kLength, 4, 2, 0) & " " & UnitLength & ") è minore delle lunghezza|"
                            Testo = Testo & "massima per il rinforzo. (" & GlobalRoutines.myStr(.M(149) * kLength, 4, 2, 0) & " " & UnitLength & ")"
                            If MostraAiuto(1, RoutBase1.ChiaviMess.MessInformation Or ChiaviMess.MessOKCancel, clsInizio.ConvertiCr(Testo), , True) = ChiaviMess.MessCancel Then
                                qbflan = -99
                                GoTo FinCob
                            End If
                        End If
                    Else
                        Al2 = l
                    End If
                    Al1 = (Al1 + Al2) / 2 : If Al1 < Al Then Al = Al1
                Next
                l = Al
                '  If .M(151) = 0 Or .M(151) > l Or qbflan <> 0 Then
                .M(151) = l
                .Z(151) = l / inc
                '  End If
                If Sna = 0 Then ja = 1 Else ja = sca / Sna
                If Sno = 0 Then jo = 1 Else jo = Sco / Sno
                If ja < 1 Then ja = 1
                If jo < 1 Then jo = 1
                .M(152) = ja : .M(153) = jo : .Z(152) = ja : .Z(153) = jo
                A1o = (l - d / 2) * (t - tro)
                A2o = (H * (tn - TRN)) / jo
                A1a = (l - d / 2) * (t - tRa)
                A2a = (H * tn) / ja
16148:          If qbflan < 0 Then
                    Areq = Ao : ARinf = 2 * (A1o + A2o)
                    fact = (Areq - ARinf) / Areq
                    AReq1 = Aa : ARinf1 = 2 * (A1a + A2a)
16149:              fact1 = (AReq1 - ARinf1) / AReq1
                    If fact1 > fact Then Areq = AReq1 : ARinf = ARinf1 : fact = fact1
                    If (System.Math.Abs(fact) < 0.0001 Or icount > 100) And icount > 1 Then .M(1) = p : .Z(1) = p * psi : GoTo FinCob
                    icount = icount + 1
                    pvec1 = pvec
                    pvec = p
                    If icount = 1 Then
                        If fact > 0 Then p = p * 0.9 Else p = p * 1.1
                    Else
                        If System.Math.Abs(AReqv - ARinfv - Areq + ARinf) > 0.00001 * Areq Then
                            p = pvec1 + (AReqv - ARinfv) / (AReqv - ARinfv - Areq + ARinf) * (p - pvec1)
                            If p < 0 Then p = pvec / 2
                        Else
                            p = pvec1
                        End If
                    End If
                    AReqv = Areq : ARinfv = ARinf
                    .M(1) = p : .Z(1) = p * psi
                    ' Call PreliminF
                    If qbflan = -99 Then GoTo fincob
                    If Sno > 0 Then GoTo 16069 Else GoTo 16141
                End If 'h
                ARo = Ao - (A1o + A2o) * 2
                ARa = Aa - (A1a + A2a) * 2
                .M(154) = A1o : .Z(154) = A1o / inc / inc
                .M(155) = A2o : .Z(155) = A2o / inc / inc
                .M(156) = A1a : .Z(156) = A1a / inc / inc
                .M(157) = A2a : .Z(157) = A2a / inc / inc
                .M(158) = ARo : .Z(158) = ARo / inc / inc
                .M(159) = ARa : .Z(159) = ARa / inc / inc
                If ARo <= 0 And ARa <= 0 Then GoTo 16500
                If ARo > ARa Then Area = ARo Else Area = ARa
                SpCop = .M(119) + 1
                If strSPCOP = "SI" Then Testok = "A" : GoTo 16147
                SPNOZ = .M(137) + 1
                If strSPNOZ = "SI" Then Testok = "B" : GoTo 16147
16147:          If ic = 0 Then
                    Testo = "L'apertura sul coperchio non è verificata"
                    Testo = Testo & "|Esercizio: A0=" & _
                    GlobalRoutines.myStr(Ao * kLength ^ 2, 6, 0, False) & "<A1 (" & _
                    GlobalRoutines.myStr(2 * A1o * kLength ^ 2, 6, 0, False) & ")  +2*A2 (" & _
                    GlobalRoutines.myStr(2 * A2o * kLength ^ 2, 6, 0, False) & ") = " & _
                    GlobalRoutines.myStr((2 * A1o + 2 * A2o) * kLength ^ 2, 6, 0, False) & " " & UnitArea
                    Testo = Testo & "|Serraggio: A0=" & _
                    GlobalRoutines.myStr(Aa * kLength ^ 2, 6, 0, False) & "<A1 (" & _
                    GlobalRoutines.myStr(2 * A1a * kLength ^ 2, 6, 0, False) & ")  +2*A2 (" & _
                    GlobalRoutines.myStr(2 * A2a * kLength ^ 2, 6, 0, False) & ") = " & _
                    GlobalRoutines.myStr((2 * A1a + 2 * A2a) * kLength ^ 2, 6, 0, False) & " " & UnitArea
                    Testo = Testo & "|       Cosa vuoi fare ? "
                    Stringa(1) = "Calcolare lo spess. min. coperchio  (valore attuale=" & GlobalRoutines.myStr(.M(119) + 0, 4, 2, False) & ")"
                    Stringa(2) = "Calcolare lo spess. min. tronchetto (valore attuale=" & GlobalRoutines.myStr(.M(137) + 0, 4, 2, False) & ")"
                    Stringa(3) = "Modificare i dati di input"
                    Stringa(4) = "Confermare i dati attuali"
                    n = 4
                    If Nozzles(kLato, kNozzle).Tipo = "OPEN" Then
                        n = 3
                        Stringa(2) = Stringa(3)
                        Stringa(3) = Stringa(4)
                    End If
                    .Conforme = "NO"
                    junk = Monitor.Motore.Quale(n, .NOID, Stringa, "", 1, clsInizio.ConvertiCr(Testo), 1)
                    If junk = 0 Then
                        qbflan = -99
                        GoTo FinCob
                    ElseIf junk = 1 Then
                        Testok = "A"
                    ElseIf junk = 2 And n = 4 Then
                        Testok = "B"
                    ElseIf junk = 2 And n = 3 Then
                        Testok = "C"
                        qbflan = 1
                        Modifica = True
                    ElseIf junk = 3 And n = 4 Then
                        Testok = "C"
                        qbflan = 1
                        Modifica = True
                    ElseIf junk = n Then
                        .Conforme = "SI"
                        qbflan = -98
                        If Configwn.Verbose And Configwn.TipCalc <> 2 And Config(0).CalcMAWP <> 0 Then
                            Testo = "Poiché è stata forzata in accettazione una" & vbCrLf
                            Testo = Testo & "condizione non completamente verificata," & vbCrLf
                            Testo = Testo & "il calcolo delle MAWP non sarà eseguito per" & vbCrLf
                            Testo = Testo & "l'apertura " & .NOID
                            MessageBox.Show(formTab, Testo, "AsmeVip - Calcolo Coperchi piani")
                        End If
                        GoTo 16501
                    Else
                        GoTo FinCob
                    End If
                End If 'h
                If Testok = "A" Or Testok = "B" Then
                    ic = ic + 1
                    If ic > 250 Then
                        Testo = "L'opzione " & Testok & " non da risultati.|"
                        Testo = Testo & "|Cambiare strategia"
                        MessageBox.Show(formTab, clsInizio.ConvertiCr(Testo), "AsmeVip - Calcolo Grandi Fucinati")
                        Testok = "" : strSPCOP = "NO" : strSPNOZ = "NO" : ic = 0
                    End If 'i
                End If 'j
                If Testok = "A" Then
                    .M(119) = SpCop : .Z(119) = .M(119) / inc
                    strSPCOP = "SI" : strSPNOZ = "NO" : GoTo 16001
                End If 'k
                If Testok = "B" Then
                    If .Z(136) = 0 Or .Z(136) * .Z(135) > 0 Then DE = di + SPNOZ * 2
                    If .Z(135) = 0 Then di = DE - SPNOZ * 2
                    tn = SPNOZ : .M(137) = tn : .Z(137) = tn / inc
                    strSPNOZ = "SI" : strSPCOP = "NO"
                    GoTo 16045
                End If 'l
                If Testok = "C" Or Testok = "c" Then GoTo 16501
16500:          If Not ContinuoAuto Then
                    Select Case junk
                        Case 1
                            Testo = "L'apertura " & .NOID & " è ora verificata con uno spessore coperchio|"
                            Testo = Testo + "pari a " + GlobalRoutines.myStr(.M(119) * kLength, 4, 2, False) + UnitLength
                        Case 2
                            Testo = "L'apertura " & .NOID & " è ora verificata con uno spessore tronchetto|"
                            Testo = Testo + "pari a " + GlobalRoutines.myStr(.M(139) * kLength, 4, 2, False) + UnitLength
                        Case Else
                            Testo = "L'apertura " & .NOID & " è verificata:"
                    End Select
                    Testo = Testo & "|Esercizio: A0=" & _
                    GlobalRoutines.myStr(Ao * kLength ^ 2, 6, 0, False) & "<A1 (" & _
                    GlobalRoutines.myStr(2 * A1o * kLength ^ 2, 6, 0, False) & ")+2*A2 (" & _
                    GlobalRoutines.myStr(2 * A2o * kLength ^ 2, 6, 0, False) & ") = " & _
                    GlobalRoutines.myStr((2 * A1o + 2 * A2o) * kLength ^ 2, 6, 0, False) & " " & UnitArea
                    Testo = Testo & "|Serraggio: A0=" & _
                    GlobalRoutines.myStr(Aa, 6, 0, False) & "<A1 (" & _
                    GlobalRoutines.myStr(2 * A1a * kLength ^ 2, 6, 0, False) & ")+2*A2 (" & _
                    GlobalRoutines.myStr(2 * A2a * kLength ^ 2, 6, 0, False) & ") = " & _
                    GlobalRoutines.myStr((2 * A1a + 2 * A2a) * kLength ^ 2, 6, 0, False) & " " & UnitArea
                    Testo = Testo + "|Si approva?"
                    Testo = Monitor.Motore.Inizio.ConvertiCr(Testo)
                    If Monitor.Motore.Messaggio(Testo, ChiaviMess.MessQuestion Or ChiaviMess.MessYesNo, _
                    Tit:="AsmeVip - Coperchi piani", Proportional:=True) = ChiaviMess.Messno Then
                        qbflan = -99
                        Select Case junk
                            Case 1
                                .M(119) = SpCop
                                GoTo FinCob
                            Case 2
                                .M(139) = tn
                                GoTo 16501
                            Case Else
                                GoTo fincob
                        End Select
                    Else
                        Select Case junk
                            Case 2
                        End Select
                    End If
                End If
16501:          .M(135) = di : .M(136) = DE
                .Z(135) = di / inc : .Z(136) = DE / inc
                .M(137) = tn + CN : .Z(137) = (tn + CN) / inc
17000:          'ritorno
                GoTo FinCob
18001:          'VERIFICA VALIDA CON UG-39(d)(2)
                If qbflan > -1 Then
                    If Not ContinuoAuto Then
                        Testo = " Apertura Verificata secondo UG-39(d)(2).|"
                        Testo = Testo & "spessore coperchio                   = " & _
                        GlobalRoutines.myStr(.M(134) * kLength, 4, 2, False) & " " & UnitLength
                        Testo = Testo & "|spessore minimo coperchio operating  = " & _
                        GlobalRoutines.myStr(.M(144) * kLength, 4, 2, False) & " " & UnitLength
                        Testo = Testo & "|spessore minimo coperchio serraggio  = " & _
                        GlobalRoutines.myStr(.M(143) * kLength, 4, 2, False) & " " & UnitLength
                        Testo = clsInizio.ConvertiCr(Testo)
                        Monitor.Motore.Messaggio(Testo, Tit:="AsmeVip - Coperchi piani", Proportional:=True)
                        If .M(134) > .M(144) And .M(134) > .M(143) Then CoperchioAutoRinforzato = True : GoTo FinCob
                        CoperchioAutoRinforzato = False
                        GoTo 16041
                    End If 'm
                Else
                    thk = .M(144) : If .M(143) > thk Then thk = .M(143)
                    fact = .M(134) / thk
                    If (System.Math.Abs(fact - 1) < 0.001 Or icount > 100) And icount > 1 Then .M(1) = p : .Z(1) = p * psi : GoTo FinCob
                    icount = icount + 1
                    p = p * fact ^ 1.5
                    .M(1) = p : .Z(1) = p * psi
                    Call PreliminF()
                    If qbflan = -99 Then GoTo FinCob
                    Call CopeMin(T1wn, T2wn, T3, p * psi)
                    .M(126) = T2wn * inc : .M(125) = T1wn * inc
                    GoTo 16040
                End If
FinCob:
                If qbflan < 0 Then
                    .M(125) = M125sav : .M(126) = M126sav
                    .Z(125) = .M(125) / inc : .Z(126) = .M(126) / inc
                End If
            Catch e As Exception
                MsgBox(e.Message + vbCrLf + e.StackTrace)
            End Try
        End With
    End Sub

    Public Function wntorc(ByRef WmHI As Single) As Boolean
        Dim ab, DN As Single
        Dim n As Short
        Dim Sfa, p, Sfo As Single
        Dim b, Sba, gef As Single
        Dim y, my, wmt As Single
        Dim HPI, PHI, hi As Single
        Dim WM2I, WM1I, WI As Single
        Dim PHy As Single
        Dim Testo As String
        With Mem
            'WM1=max(.z(33),.z(40)  WM2=max(.z(34),.z(41))
            wntorc = True
14001:      'CALCOLO CARICO SUI TIRANTI PER PILGRIM E M.TORCENTE
            ab = .M(46)
            n = .M(13)
            DN = .M(14)
            If WmHI = 0 Then
14021:          p = .M(1)
                Sfa = .M(22)
                Sfo = .M(23)
                Sba = .M(24)
                b = .M(36)
                gef = .M(37)
                my = .M(30)
                If .M(161) = 1 And .M(162) >= 2 And .M(162) <= 4 Then
                    'guarnizioni lenticolari
                    my = .Z(30) - .Z(203) / (4 * .Z(36) * System.Math.Tan(.Z(201) * Math.PI / 180))
                End If
                y = .M(28)
                wmt = .M(32)
                If Sfo = 0 Then Exit Function
                PHy = Config(kLato).pxTest
                If PHy = 0 Then
                    PHI = p * RappPI() * (Sfa / Sfo)
                Else
                    PHI = PHy
                End If
                .M(105) = PHI : .Z(105) = PHI * psi
                HPI = 2 * b * (pi * gef + .M(167) + .M(169)) * my * PHI
                .M(106) = HPI : .Z(106) = HPI / NIUT
                hi = (pi / 4) * gef ^ 2 * PHI : .M(107) = hi : .Z(107) = hi / NIUT
                WM1I = hi + HPI : .M(108) = WM1I : .Z(108) = WM1I / NIUT
                WM2I = pi * b * gef * y + wmt : .M(109) = WM2I : .Z(109) = WM2I / NIUT
                '  AM1I = WM1I / (Sba * RappPI): .m(110) = AM1I: .z(110) = AM1I / inc / inc
                '  AM2I = WM2I / (Sba * RappPI): .m(111) = AM2I: .z(111) = AM2I / inc / inc
                '  If AM1I > AM2I Then AMI = AM1I Else AMI = AM2I
                '  .m(112) = AMI: .z(112) = AMI / inc / inc
                '  WI = (AMI + ab) * (Sba * RappPI) / 2
                WI = WM1I : If WM2I > WI Then WI = WM2I
            Else
                'If Configwn.LatoProgetto = 1 Then PHy = Config(2).pxExt Else PHy = Config(2).pxExt
                PHy = Config(kLato).pxTest
                .M(105) = PHy : .Z(105) = PHy * psi
                WI = WmHI * NIUT
            End If 'o
            .M(113) = WI : .Z(113) = WI / NIUT
            .M(114) = (WI * 1.3) / n : .Z(114) = .M(114) / NIUT
            .M(115) = .M(114) : .Z(115) = .M(115)
            .M(117) = (0.17 * WI * DN) / n : .Z(117) = .M(117) * MomToBS
            '  .m(117) = .m(116) / 9.80665: .z(117) = .m(117)
            .M(118) = .M(117) / 9.80655 / 1000 ': .z(118) = .m(118)
            'IF WmHI > 0 THEN
            ' .z(118) = .z(116)
            If .Z(46) = 0 Then wntorc = False : Exit Function
            .Z(116) = .Z(114) / .Z(46) * n : .M(116) = .Z(116) / psi 'divide check
            'END IF
            If Configwn.BoltLoadDetail Then
                If Serr Is Nothing Then
                    Serr = New Tiranti.Serraggio
                    Serr.DoveMotore = Monitor.Motore
                    AggiustaHydr(kLato, jInvolucr, 0, PHy, True)
                    With Serr
                        If Config(kLato).US = 0 Then
                            .prunmi = 1
                            .prp(0) = Mem.M(1)
                            .prt(0) = Mem.M(2)
                            .prDiamExtGuar = Mem.M(5) + Mem.M(26)
                            .prN = Mem.M(26)
                            .prwNubbin = Mem.M(29)
                            .prsa1 = Mem.M(25) 'prog
                            .prsa2(0) = Mem.M(24) 'amb
                            .pryy = Mem.M(28)
                            .prphydr(0) = PHy / psi
                            .prwm1 = Mem.M(108)
                            .prwm2 = Mem.M(109)
                            .prv(0) = Mem.M(108)
                            If Mem.M(109) > Mem.M(108) Then .prv(0) = Mem.M(109)
                            '.prAreaPist(0)=
                        Else
                            .prunmi = 3
                            .prp(0) = Mem.Z(1)
                            .prt(0) = Mem.Z(2)
                            .prDiamExtGuar = Mem.Z(5) + 2 * Mem.Z(13)
                            .prN = Mem.Z(13)
                            .prwNubbin = Mem.Z(29)
                            .prsa1 = Mem.Z(25) 'prog
                            .prsa2(0) = Mem.Z(24) 'amb
                            .pryy = Mem.Z(28)
                            .prphydr(0) = PHy
                            .prwm1 = Mem.Z(108)
                            .prwm2 = Mem.Z(109)
                            .prv(0) = Mem.Z(108)
                            If Mem.Z(109) > Mem.Z(108) Then .prv(0) = Mem.Z(109)
                            '.prAreaPist(0)=
                        End If
                        .prClasseGuarnizione = Mem.M(161)
                        .prTipoGuarnizione = Mem.M(162)
                        .prm = Mem.M(30)
                        If Mem.M(161) = 1 And Mem.M(162) >= 2 And Mem.M(162) <= 4 Then
                            'guarnizioni lenticolari
                            .prm = Mem.Z(30) - Mem.Z(203) / (4 * Mem.Z(36) * System.Math.Tan(Mem.Z(201) * Math.PI / 180))
                        End If
                        .prstrClasseGuarnizione = Mem.Gasket
                        .prstrTipoGuarnizione = Mem.GasMat
                        .prMatTira = Matdim(Involucr(kLato, jInvolucr).indice(2 - 1)).MatStr
                        .prindMat = Matdim(Involucr(kLato, jInvolucr).indice(2 - 1)).Indmat
                        .prxFil = Mem.XFil
                        .prDN = Mem.TIR
                        .prnb = Mem.M(13)
                        .prk1 = Mem.M(200)
                        .prk2Pilgrim = Configwn.SicBull
                        .prk2Torque = Configwn.SicBull
                        .prk3 = 1.3
                    End With
                End If
                Serr.EseguidaASME()
            ElseIf Not ContinuoAuto Then
                Testo = "Bolt stress under Pilgrim    " & _
                GlobalRoutines.myStr(CSng(.Z(114) / .Z(46)) * n, 10, 0, False) & "[psi]|"
                Testo = Testo & "Pilgrim Load each bolt       " & _
                GlobalRoutines.myStr(.M(114), 10, 0, False) & " [N]|"
                Testo = Testo & "Pilgrim Load each bolt       " & _
                GlobalRoutines.myStr(.Z(114), 10, 0, False) & " [lb]||"
                Testo = Testo & "Bolt Torque moment each bolt " & _
                GlobalRoutines.myStr(.M(117) / 1000, 10, 0, False) & "  [N.m]|"
                Testo = Testo & "Bolt Torque moment each bolt " & _
                GlobalRoutines.myStr(.Z(117), 10, 0, False) & " [lb.in]"
                Monitor.Motore.Messaggio(clsInizio.ConvertiCr(Testo), Tit:="AsmeVip - Serraggio tiranti", Proportional:=True)
            End If
            torce = 1
        End With
    End Function

    Sub Caract(ByRef n As Short)
        Dim Bocch As Grafica.clsBocch
        Dim Ogg As Object = Nothing
        Dim Tronch As Grafica.Cilindro
        Dim i As Short
        If AddDistinta > 0 Then
900:        Bocch = CType(Apparecchio.Elementi(5 + n), Grafica.clsBocch) 'Look.LookTipoBocch(Record(5 + n).Dati, 0)
            With Bocch
                Select Case .Standard.K3
                    Case 1, 2, 3
                        Mem.M(165) = .Sporgenza - .Standard.Altezza
                    Case 4
                        Mem.M(165) = .Sporgenza '?????????? - aFl!(5, 1)
                End Select
                If Left(.GenMem.posizione.Raggio, 2) = "Bu" Then Mem.M(165) = 0
910:            Mem.Z(165) = Mem.M(165) / inc 'h maxima
                Mem.M(138) = Mem.M(120) : Mem.Z(138) = Mem.M(138) / inc 'corrosione
                Select Case .Standard.K3
                    Case 1 'WN
                        For i = 0 To .GenMem.Appesi.Count - 1
                            Ogg = .GenMem.Appesi(i)
                            If System.Math.Abs(Ogg.genmem.Tipo) = 2 Then Exit For
                        Next
                        Tronch = CType(Ogg, Grafica.Cilindro)
                        Mem.M(136) = Tronch.Diametro : Mem.Z(136) = Tronch.Diametro / inc 'De
                        Mem.M(137) = Tronch.SpessBase : Mem.Z(137) = Mem.M(137) / inc 'Tn
                        Mem.M(135) = Mem.M(136) - 2 * Mem.M(137) : Mem.Z(135) = Mem.M(135) / inc 'di
                    Case 2 'SO
                    Case 3 'LJ
                    Case 4 'LWN
940:                    Mem.M(136) = .DiamRinf : Mem.Z(136) = Mem.M(136) / inc 'De
                        Mem.M(135) = .DiamInt : Mem.Z(135) = Mem.M(135) / inc 'Di
                    Case 5 'BLIND
                        MessageBox.Show(formTab, "Errore impossibile 2 in Caract")
                End Select
            End With
            Mem.NOID = Bocch.GenMem.Denom.Trim
        Else
            Mem.M(135) = LTOdim(n - Involucr(kLato, jInvolucr).inizio) 'Nozzles(kLato, n).DiIn '
            Mem.M(165) = Altdim(n - Involucr(kLato, jInvolucr).inizio) 'Nozzles(kLato, n).LXDisp '
            Mem.M(137) = SpsBoc(n - Involucr(kLato, jInvolucr).inizio) 'Nozzles(kLato, n).Spess
            Mem.M(136) = 0
        End If
    End Sub

    Function Conteggio(ByRef iBocc As Short, ByRef iSWstam As Boolean) As Boolean 'PLORdim() distanze mutue  LTOdim() diametri interni  'PNETdim distanze da Gef
        Dim Vec As New RoutBase1.clsVec3
        Dim i As Short
        Dim Testo As String
        Dim j, ifl As Short
        Dim Adim, efflig1
        Dim Valor, Piano, Valos As String
        Dim Par As String
        Dim File As String = ""
        Dim div2 As Boolean
        Dim y1, x1, x2, y2 As Single
        Dim Ogg As New Grafica.clsGenMem
        Dim GenOgg As New Grafica.clsGenMem
        ReDim PLORdim(NBocc, NBocc)
        ReDim PNETdim(NBocc)
        ReDim Stringa(NBocc)
        ReDim Preserve LTOdim(NBocc)
        ReDim Preserve Altdim(NBocc)
        ReDim Preserve SpsBoc(NBocc)
        'On Local Error GoTo ErrCont
        Par = "\par "
        Conteggio = False
        i1 = 0 : i2 = NBocc - 1
        If AddDistinta = 0 Then If Not InpSint(iBocc) Then Exit Function
        For i = 1 To NBocc : Stringa(i) = "" : Next
        iUG39b3 = False
        iUG39c = False
        iUG39e1 = True
        AD5013 = True
        iUG39e2 = False
        efflig = 1.0E+20
        Select Case Config(kLato).DC
            Case 0, 1, 2, 9, 10, 11 : File = "\WN5\wn_UG39.cop" : div2 = False
            Case 3, 4, 5 : File = "\WN5\wn_UG39d2.cop" : div2 = True
        End Select
        For i = i1 To i2
            If AddDistinta > 0 Then
700:            Call Caract(i)
701:            LTOdim(i - i1) = Mem.M(135) '** diametri interni
                Altdim(i - i1) = Mem.M(165) 'Altdim(N) = m(165)
                SpsBoc(i - i1) = Mem.M(137) 'SpsBoc(N) = m(137)
            End If
702:        If LTOdim(i - i1) > Mem.M(37) / 2 Then iUG39c = True
703:        If AddDistinta > 0 Then
                GenOgg = CType(Apparecchio.Elementi(5 + i).Genmem, Grafica.clsGenMem) '
                Ogg = GenOgg.posizione.SuChi.Genmem
                Vec.X = (Ogg.posizione.Origine.X - Ogg.posizione.Origine.X)
                Vec.y = (Ogg.posizione.Origine.y - Ogg.posizione.Origine.y)
                Vec.Z = (Ogg.posizione.Origine.Z - Ogg.posizione.Origine.Z)
                Dist = System.Math.Sqrt(Vec.ProdScalar(Vec))
                If Dist > 0 Then
710:                Vec.X = Vec.X / Dist
                    Vec.y = Vec.y / Dist
                    Vec.Z = Vec.Z / Dist
                    Proiez = Vec.ProdScalar(Ogg.posizione.CosDiritta)
                    Dist = Dist * System.Math.Sqrt(1 - Proiez * Proiez)
                End If 'B
            Else
                If SistCoorCop = 0 Then
                    Dist = Nozzles(kLato, i).DTL
                Else
                    Dist = System.Math.Sqrt(Nozzles(kLato, i).DTL ^ 2 + Nozzles(kLato, i).DCL ^ 2)
                End If
            End If
            PNETdim(i - i1) = Mem.M(37) / 2 - Dist
            If PNETdim(i - i1) < LTOdim(i - i1) / 2 Then
720:            Testo = "La distanza fra l'asse del bocchello     |"
                Testo = Testo & Nozzles(kLato, i).Mark.Trim & " e il diametro guarnizione"
                Testo = Testo & "|è minore del raggio dell'apertura.         |"
                Testo = Testo & "Rivedere il posizionamento bocchelli.      |"
                MessageBox.Show(formTab, clsInizio.ConvertiCr(Testo), "AsmeVip - Calcolo Grandi Fucinati")
                Exit Function
            End If
            If PNETdim(i - i1) - LTOdim(i - i1) / 2 < LTOdim(i - i1) / 4 Then
730:            iUG39b3 = True
                Stringa(i) = "UG-39(b)(3)"
            End If 'A
            For j = i + 1 To i2
                If AddDistinta > 0 Then
                    Vec.X = (GenOgg.posizione.Origine.X - GenOgg.posizione.Origine.X)
                    Vec.y = (GenOgg.posizione.Origine.y - GenOgg.posizione.Origine.y)
                    Vec.Z = (GenOgg.posizione.Origine.Z - GenOgg.posizione.Origine.Z)
                    Dist = System.Math.Sqrt(Vec.ProdScalar(Vec))
                    If Dist > 0 Then
740:                    Vec.X = Vec.X / Dist
                        Vec.y = Vec.y / Dist
                        Vec.Z = Vec.Z / Dist
                        Proiez = Vec.ProdScalar(GenOgg.posizione.CosDiritta)
                        Dist = Dist * System.Math.Sqrt(1 - Proiez * Proiez)
                    End If 'n
                Else
                    If SistCoorCop = 0 Then
                        x1 = Nozzles(kLato, j).DTL * System.Math.Cos(Nozzles(kLato, j).Anomal * pi / 180)
                        y1 = Nozzles(kLato, j).DTL * System.Math.Sin(Nozzles(kLato, j).Anomal * pi / 180)
                        x2 = Nozzles(kLato, i).DTL * System.Math.Cos(Nozzles(kLato, i).Anomal * pi / 180)
                        y2 = Nozzles(kLato, i).DTL * System.Math.Sin(Nozzles(kLato, i).Anomal * pi / 180)
                        Dist = System.Math.Sqrt((x1 - x2) ^ 2 + (y1 - y2) ^ 2)
                    Else
                        Dist = System.Math.Sqrt((Nozzles(kLato, j).DTL - Nozzles(kLato, i).DTL) ^ 2 + (Nozzles(kLato, j).DCL - Nozzles(kLato, i).DCL) ^ 2)
                    End If
                End If
                PLORdim(i - i1, j - i1) = Dist : PLORdim(j - i1, i - i1) = Dist
                If PLORdim(i - i1, j - i1) < (LTOdim(i - i1) + LTOdim(j - i1)) / 2 + clsTrigon.TOLER Then
750:                Testo = "La distanza fra gli assi dei bocchelli     |"
                    Testo = Testo & RTrim(Nozzles(kLato, i).Mark) & " e " & RTrim(Nozzles(kLato, j).Mark)
                    Testo = Testo & "|è tale da dare un istmo minore di zero.    |"
                    Testo = Testo & "Rivedere il posizionamento bocchelli.      |"
                    MessageBox.Show(formTab, clsInizio.ConvertiCr(Testo), "AsmeVip - Calcolo Grandi Fucinati")
                    Exit Function
                End If 'm
                If div2 And PLORdim(i - i1, j - i1) < 3 * (LTOdim(i - i1) + LTOdim(j - i1)) / 2 Then
                    Testo = "La distanza fra gli assi dei bocchelli     |"
                    Testo = Testo & RTrim(Nozzles(kLato, i).Mark) & " e " & RTrim(Nozzles(kLato, j).Mark)
                    Testo = Testo & "|non è conforme alla regola AD-501(3).    |"
                    Testo = Testo & "(" & Str(Int(PLORdim(i - i1, j - i1))) & ">" & Str(Int(3 * (LTOdim(i - i1) + LTOdim(j - i1)) / 2)) & " mm)|"
                    Testo = Testo & "Si vuole rivedere il posizionamento bocchelli.?"
                    If MessageBox.Show(formTab, clsInizio.ConvertiCr(Testo), "AsmeVip - Calcolo Grandi Fucinati", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then Exit Function
                    AD5013 = False
                    Stringa(i - i1) = "AD-501(3)" : Stringa(j - i1) = "AD-501(3)"
                End If
                If PLORdim(i - i1, j - i1) < (LTOdim(i - i1) + LTOdim(j - i1)) And Not div2 Then
                    iUG39e1 = False
                    If PLORdim(i - i1, j - i1) < 1.25 * (LTOdim(i - i1) + LTOdim(j - i1)) / 2 Then
                    Else
760:                    efflig1 = (PLORdim(i - i1, j - i1) - (LTOdim(i - i1) + LTOdim(j - i1)) / 2) / PLORdim(i - i1, j - i1)
                        If efflig1 < efflig Then efflig = efflig1
                        iUG39e2 = True
                        Stringa(i - i1) = "UG-39(e)(2)" : Stringa(j - i1) = "UG-39(e)(2)"
                    End If 'l
                End If 'i
                If (LTOdim(i - i1) + LTOdim(j - i1)) / 2 > Mem.M(37) / 4 Then
770:                iUG39e1 = False
                End If 'h
                Adim = Math.Min(LTOdim(i - i1), LTOdim(j - i1))
                If PLORdim(i - i1, j - i1) - (LTOdim(i - i1) + LTOdim(j - i1)) / 2 < Adim / 4 Then
                    iUG39b3 = True
                    Stringa(i - i1) = "UG-39(b)(3)"
780:                Stringa(j - i1) = "UG-39(b)(3)"
                End If
            Next  'aa
        Next  'bb
        Conteggio = True
        If NBocc < 2 Then
            Distanze()
            Exit Function
        End If
        If Not PrepRapp(Template, "Conteggio aperture", "Conteggio aperture su " + Mem.COID, FileSt, mioApert.lstRapp) Then Exit Function
        ifl = FreeFile()
790:    FileOpen(ifl, RTrim(clsInizio.Archdir) & File, OpenMode.Input, , OpenShare.Shared)
        Call Sub11(ifl)
        FileClose(ifl)
        Dim mFormato As String = "  ##) \                     \ _| ####.#_| ####.#_|####.## mm  _|####.## mm  _|\          \"
        With Monitor.Motore.Problem
            .Printa(Par)
            .Printa("NUMBER OF OPENINGS ON THE COVER " & NBocc & Par)
            .Printa(Par)
            If SistCoorCop = 0 Then
                .Printa(" Pos. Nozzle Mark             |   R   | alfa  |  Int.dia.  |Dist.to Gef |Rules " & Par)
            Else
                .Printa(" Pos. Nozzle Mark             |   X   |   Y   |  Int.dia.  |Dist.to Gef |Rules " & Par)
            End If
            For i = i1 To i2
                If iUG39c Then
                    If Len(RTrim(Stringa(i - i1))) = 0 Then Stringa(i - i1) = "UG-39(c)"
                ElseIf iUG39e1 Then
                    If Len(RTrim(Stringa(i - i1))) = 0 Then Stringa(i - i1) = "UG-39(e)(1)"
                End If
                If SistCoorCop = 0 Then
                    .Printa(GlobalRoutines.FormatS(mFormato, _
                    i - i1 + 1, Nozzles(kLato, i).Mark, _
                    Nozzles(kLato, i).DTL, Nozzles(kLato, i).Anomal, _
                    LTOdim(i - i1), PNETdim(i - i1), Stringa(i - i1)) & Par)
                Else
                End If
            Next  'cc
            If div2 Then
                Testo = "The rule about minimum distance between openings (AD-501(3)) is"
                If Not AD5013 Then Testo = Testo & " NOT "
                Testo = Testo & "respected."
                .Printa(Testo & Par)
            End If
            .Printa(Par)
            .Printa(" Study of all the pairs of openings" & Par)
            .Printa(" Pos1 Pos2         Spacing       Average diameter" & Par)
            For i = 0 To NBocc - 2
                For j = i + 1 To NBocc - 1
                    .Printa(GlobalRoutines.FormatS( _
                    "  ##   ##    _|    ####.##  mm  _|    ####.##  mm  _|", _
                    i + 1, j + 1, PLORdim(i, j), (LTOdim(i) + LTOdim(j)) / 2) & Par)
                Next j
            Next i 'dd
            Distanze()
            Dim Al As Single
            Dim Al1, Al2 As Single
            If NBocc > 1 Then
                .Printa(Par)
                .Printa(" Study of all planes passing through the openings" & Par)
                .Printa(" ------------------------------------------------" & Par)
                For i = 0 To NBocc - 1
                    Al = 9999
                    .Printa(Par)
                    .Printa(" Nozzle pos." & Str(i + 1) & Par)
                    For j = 0 To NBocc - 1
                        If i = j Then Piano = "diametral   " Else Piano = "throu pos." & Str(j + 1)
                        Valor = GlobalRoutines.myStr(Dispon(i, j, 1), 5, 2, False)
                        Valos = GlobalRoutines.myStr(Dispon(i, j, 2), 5, 2, False)
                        .Printa("Plane: " & Piano & "; Avail. length side 1: " & Valor & "; Avail. length side 2: " & Valos & Par)
                        Al1 = Dispon(i, j, 1)
                        Al2 = Dispon(i, j, 2)
                        Al1 = (Al1 + Al2) / 2
                        If Al1 < Al Then Al = Al1
                    Next
                    .Printa("{\b Minimum sum of the available lengths along the cover:" & GlobalRoutines.myStr(Al, 4, 1, 0) & " mm.}" & Par)
                Next
            End If
        End With
    End Function
    Private Sub Distanze()
        Dim i, j As Integer
        Dim n1, n2 As Short
        ReDim DistGef(NBocc, NBocc)
        ReDim Dispon(NBocc, NBocc, 2)
        ReDim PunPia(NBocc)
        Intersez = New RoutBase1.clsPunti
        RoutGraf = New Grafica.LibGra
        CentroC = New RoutBase1.clsVec2
        Direz = New RoutBase1.clsVec2
        Linea = New RoutBase1.clsLinea2
        Intersez.Inizia(4)
        For i = 0 To NBocc - 1 : PunPia(i) = New RoutBase1.clsVec2 : Next
        If NBocc > 1 Then
            Call CoorBuc1(PunPia)
            For i = 0 To NBocc - 1
                For j = 0 To NBocc - 1
                    If i <> j Then
                        Direz.X = PunPia(i).X - PunPia(j).X
                        Direz.y = PunPia(i).y - PunPia(j).y
1100:                   Dist = System.Math.Sqrt(Direz.X * Direz.X + Direz.y * Direz.y)
                        Direz.X = Direz.X / Dist
                        Direz.y = Direz.y / Dist
                        Linea.P0 = PunPia(i)
                        Linea.Direz = Direz
1110:                   Linea.InterRettCerch(0.0!, CentroC, Mem.M(37) / 2, Intersez, n1, n2)
                        DistGef(i, j) = System.Math.Sqrt((Intersez.Punti.Item(1).TextData.X - PunPia(i).X) ^ 2 + (Intersez.Punti.Item(1).TextData.y - PunPia(i).y) ^ 2)
                        If n1 = 2 Then Dist = System.Math.Sqrt((Intersez.Punti.Item(2).TextData.X - PunPia(i).X) ^ 2 + (Intersez.Punti.Item(2).TextData.y - PunPia(i).y) ^ 2)
                        If Dist < DistGef(i, j) Then DistGef(i, j) = Dist
                    End If
                Next j
            Next i
            RoutGraf = Nothing
            Intersez = Nothing
            For i = 0 To NBocc
                PunPia(i) = Nothing
            Next
            For i = 0 To NBocc - 1
                For j = 0 To NBocc - 1
                    If i = j Then
                        Dispon(i, j, 1) = PNETdim(i) : Dispon(i, j, 2) = Mem.M(37) - PNETdim(i)
                    Else
                        Dispon(i, j, 1) = DistGef(i, j)
                        '     Dispon(i, j, 2) = LTOdim(i) / 2 + (PLORdim(i, j) - (LTOdim(i) + LTOdim(j)) / 2) / 2
                        Dispon(i, j, 2) = PLORdim(i, j) * LTOdim(i) / (LTOdim(i) + LTOdim(j))
                    End If
                Next
                '   LTOdim(i) = (PNETdim(i) + AminLTO(i)) / 2
            Next
        Else ' un solo buco
            Dispon(0, 0, 1) = PNETdim(0) : Dispon(0, 0, 2) = Mem.M(37) - PNETdim(0)
        End If
    End Sub
    'Private Sub CoorBuc(ByRef PunPia() As RoutBase1.clsVec2)
    ' Dim j, i As Short
    ' Dim PunPro(NBocc) As RoutBase1.clsVec3
    ' For j = 0 To NBocc - 1
    ' If System.Math.Sqrt((PunPro(j).X - Rec2Buf(0).posspa.Origine.X) ^ 2 + (PunPro(j).y - Rec2Buf(0).posspa.Origine.y) ^ 2 + (PunPro(j).Z - Rec2Buf(0).posspa.Origine.Z) ^ 2) > clsTrigon.TOLER Then Exit For
    ' '''  'errore se bocchello 0 sta al centro
    ' Next
    ' For i = 0 To NBocc - 1
    ' '''  ' Call CoorPia(Rec2Buf(0).PosSpa.Origine, PunPro(j), Record(5 + i).PosSpa.Origine, PunPia(i), Rec2Buf(0).PosSpa.CosDiritta)
    ' Next
    'End Sub

    Private Function InpSint(ByRef iBocc As Short) As Boolean
        Dim Stringa1(10) As String
        Dim i As Short
        Dim Arch(10) As Short
        Dim dAiu(10) As String
        Dim Res As Boolean
        Dim Risult(10) As String
        Dim Tit As String
        Dim n As Short
        Dim GenOgg As New Grafica.clsGenMem
        'chiedere LTOdim(i)  'Origine.X,Origine.Y  .Denom
        If qbflan < 0 Then Exit Function
        InpSint = True
        Stringa1(1) = "Denominazione apertura"
        Stringa1(2) = "D.interno apertura [mm]"
        If SistCoorCop = 0 Then
            Stringa1(3) = "Elongazione       [mm]"
            Stringa1(4) = "Anomalia          [° ]"
        Else
            Stringa1(3) = "Coordinata X      [mm]"
            Stringa1(4) = "Coordinata Y      [mm]"
        End If
        Stringa1(5) = "Spessore tronch.  [mm]"
        Stringa1(6) = "Altezza utile     [mm]"
        i1 = Involucr(kLato, jInvolucr).inizio
        i2 = Involucr(kLato, jInvolucr).Fine
        If AddDistinta = 0 Then
            For i = i1 To i2
                LTOdim(i - i1) = Nozzles(kLato, i).DiIn
                If LTOdim(i - i1) = 0 Then LTOdim(i - i1) = Nozzles(kLato, i).DiOn
            Next
        End If
        If iBocc > 0 Then i1 = iBocc : i2 = iBocc
        For i = i1 To i2
            Risult(2) = GlobalRoutines.myStr(LTOdim(i - Involucr(kLato, jInvolucr).inizio), 5, 2, False)
            If AddDistinta > 0 Then
                GenOgg = CType(Apparecchio.Elementi(5 + i).genmem, Grafica.clsGenMem)
                GenOgg.posizione.CosDiritta.X = 0
                GenOgg.posizione.CosDiritta.y = 0
                GenOgg.posizione.CosDiritta.Z = 1
                Risult(1) = GenOgg.Denom.Trim
                Risult(3) = GlobalRoutines.myStr(GenOgg.posizione.Origine.X, 5, 2, False)
                Risult(4) = GlobalRoutines.myStr(GenOgg.posizione.Origine.y, 5, 2, False)
                Risult(5) = GlobalRoutines.myStr(SpsBoc(i - Involucr(kLato, jInvolucr).inizio), 5, 2, False)
                Risult(6) = GlobalRoutines.myStr(Altdim(i - Involucr(kLato, jInvolucr).inizio), 5, 2, False)
                Tit = "Apertura " & Str(i + 1) & "/" & LTrim(Str(NBocc))
            Else
                Risult(1) = Nozzles(kLato, i).Mark.Trim
                If SistCoorCop = 0 Then
                    Risult(3) = GlobalRoutines.myStr(Nozzles(kLato, i).DTL, 5, 2, False)
                    Risult(4) = GlobalRoutines.myStr(Nozzles(kLato, i).Anomal, 5, 2, False)
                Else
                    Risult(3) = GlobalRoutines.myStr(Nozzles(kLato, i).DCL, 5, 2, False)
                    Risult(4) = GlobalRoutines.myStr(Nozzles(kLato, i).DTL, 5, 2, False)
                End If
                If Nozzles(kLato, i).Tipo = "LWN1" Then
                    Risult(5) = GlobalRoutines.myStr(Nozzles(kLato, i).HX, 5, 2, False)
                    Risult(6) = GlobalRoutines.myStr(Nozzles(kLato, i).LX, 5, 2, False)
                    Stringa1(5) = "Spessore rinforzo [mm]"
                    Stringa1(6) = "Altezza rinforzo  [mm]"
                Else
                    If Nozzles(kLato, i).Spess = 0 Then Nozzles(kLato, i).Spess = (Nozzles(kLato, i).DiOn - Nozzles(kLato, i).DiIn) / 2
                    Risult(5) = GlobalRoutines.myStr(Nozzles(kLato, i).Spess, 5, 2, False)
                    Risult(6) = GlobalRoutines.myStr(Nozzles(kLato, i).LXdisp, 5, 2, False)
                End If
                Tit = "Apertura " & Str(i + 1 - Involucr(kLato, jInvolucr).inizio) & "/" & LTrim(Str(NBocc))
            End If
            n = 6 : If InStr(Nozzles(kLato, i).Tipo, "OPEN") > 0 Then n = 4
            If Not ContinuoAuto Then
                Res = Monitor.Motore.InputDati(n, Tit, Stringa1, Risult, "", Arch, dAiu, CarFissi:=True)
            Else
                Res = True
            End If
            InpSint = Res
            If Not Res Then Exit Function
            'If AddDistinta > 0 Then
            GenOgg.Denom = Risult(1)
            Nozzles(kLato, i).Mark = Risult(1)
            GenOgg.posizione.Origine.X = GlobalRoutines.ValVir(Risult(3))
            GenOgg.posizione.Origine.y = GlobalRoutines.ValVir(Risult(4))
            If SistCoorCop = 0 Then
                Nozzles(kLato, i).DTL = GlobalRoutines.ValVir(Risult(3))
                Nozzles(kLato, i).Anomal = GlobalRoutines.ValVir(Risult(4))
            Else
                Nozzles(kLato, i).DTL = GlobalRoutines.ValVir(Risult(4))
                Nozzles(kLato, i).DCL = GlobalRoutines.ValVir(Risult(3))
            End If
            GenOgg.posizione.Origine.Z = 0
            LTOdim(i - Involucr(kLato, jInvolucr).inizio) = GlobalRoutines.ValVir(Risult(2))
            SpsBoc(i - Involucr(kLato, jInvolucr).inizio) = GlobalRoutines.ValVir(Risult(5))
            Altdim(i - Involucr(kLato, jInvolucr).inizio) = GlobalRoutines.ValVir(Risult(6))
        Next
        i1 = Involucr(kLato, jInvolucr).inizio
        i2 = Involucr(kLato, jInvolucr).Fine
    End Function
    Protected Overrides Sub Finalize()
        Tira = Nothing
        Serr = Nothing
        Diaf = Nothing
        MyBase.Finalize()
    End Sub
    Public Sub Ammiss(ByRef nn As Short, ByRef Sfa As Single, ByRef Sfo As Single, ByRef Sba As Single, ByRef sbo As Single, ByRef sca As Single, ByRef Sco As Single, ByRef Sna As Single, ByRef Sno As Single, ByRef indice As Short, ByRef visual As Boolean, Optional ByRef Forza As Boolean = False)
        Dim i As Short
        Select Case indice
            Case 142 : indice = 141
            Case 123 : indice = 122
            Case 23 : indice = 22
            Case 25 : indice = 24
        End Select
        With Mem
            Select Case LoadCond
                Case 1
                    'bulloni---------------------
                    If Not (.LOOSE = 5 Or .LOOSE = 6) Then
                        If .M(171) = 0 Or indice = 24 Then
                            If jInvolucr = 0 Then
                                locInd = -2
                                jRec = Nozzles(kLato, kNozzle).IndiceB
                                DisplayMat(Forza, indice, visual And Not ContinuoAuto)
                            Else
                                locInd = 2
                                jRec = Involucr(kLato, jInvolucr).indice(locInd - 1)
                            End If
                            If CerMat(jRec, locInd) = -1 Then LoadCond = -1 : Exit Sub
                            For i = 1 To Matdim(jRec).Caract.Count
                                If Matdim(jRec).Caract.Item(i).TextData.Codice = CodiceStress(True) Then
                                    Sba = Configwn.PIsuOpe * Matdim(jRec).Caract.Item(i).TextData.Yield * mpa
                                    '  End If
                                    sbo = Sba
                                    Exit For
                                End If
                            Next
                            .M(171) = Sba : .Z(171) = Sba * psi
                        Else
                            Sba = .M(171)
                            sbo = Sba
                        End If
                    End If
                    'flangia----------------------
                    If Not .LOOSE = 4 Then
                        If .M(172) = 0 Or indice = 22 Then
                            If jInvolucr = 0 Then
                                locInd = -1
                                jRec = Nozzles(kLato, kNozzle).IndexF
                            Else
                                locInd = 1
                                jRec = Involucr(kLato, jInvolucr).indice(locInd - 1)
                            End If
                            If CerMat(jRec, locInd) = -1 Then LoadCond = -1 : Exit Sub
                            For i = 1 To Matdim(jRec).Caract.Count
                                If Matdim(jRec).Caract.Item(i).TextData.Codice = CodiceStress() Then
                                    Sfa = FractSyPI * Matdim(jRec).Caract.Item(i).TextData.Yield * mpa
                                    Sfo = Sfa
                                    Exit For
                                End If
                            Next
                            .M(172) = Sfa
                        Else
                            Sfa = .M(172) : Sfo = .M(172)
                        End If
                    Else
                        'coperchio-----------------------
                        If .M(181) = 0 Or indice = 122 Then
                            locInd = 1
                            jRec = Involucr(kLato, jInvolucr).indice(locInd - 1)
                            If CerMat(jRec, locInd) = -1 Then LoadCond = -1 : Exit Sub
                            For i = 1 To Matdim(jRec).Caract.Count
                                If Matdim(jRec).Caract.Item(i).TextData.Codice = CodiceStress() Then
                                    sca = FractSyPI * Matdim(jRec).Caract.Item(i).TextData.Yield * mpa : Sco = sca
                                    Exit For
                                End If
                            Next
                            .M(181) = sca
                        Else
                            sca = .M(181) : Sco = .M(181)
                        End If
                    End If
                    'bocchelli----------------------------------
                    If nn > 0 Then
                        If .M(179) * .M(180) = 0 Or indice = 141 Then
                            If InStr(Nozzles(kLato, nn).Tipo, "OPEN") = 0 Then
                                jRec = Nozzles(kLato, nn).indice
                                If Not CerMatF(nn) Then Exit Sub
                                For i = 1 To Matdim(jRec).Caract.Count
                                    If Matdim(jRec).Caract.Item(i).TextData.Codice = CodiceStress() Then
                                        Sna = FractSyPI * Matdim(jRec).Caract.Item(i).TextData.Yield * mpa
                                        Exit For
                                    End If
                                Next
                                Sno = Sna
                                .M(179) = Sna : .M(180) = Sno
                            Else
                                Sna = .M(179) : Sno = .M(180)
                            End If
                        Else
                            .M(179) = 0 : .M(180) = 0
                        End If
                    End If
                Case Else
                    'bulloni---------------------
                    If Not (.LOOSE = 5 Or .LOOSE = 6) Or indice = 24 Then
                        If jInvolucr = 0 Then
                            locInd = -2
                            jRec = Nozzles(kLato, kNozzle).IndiceB
                            DisplayMat(Forza, indice, visual And Not ContinuoAuto)
                        Else
                            locInd = 2
                            jRec = Involucr(kLato, jInvolucr).indice(locInd - 1)
                        End If
                        'GoSub DisplayMat
                        If .M(173) * .M(174) = 0 Then
                            If CerMat(jRec, locInd) = -1 Then LoadCond = -1 : Exit Sub
                            Matdim(jRec).SigmaAmm(CodiceStress(FlanBulDiv1), (.M(2)), Sba, sbo)
                            .M(173) = Sba : .M(174) = sbo
                        Else
                            Sba = .M(173) : sbo = .M(174)
                            If LoadCond Mod 2 = 1 Then sbo = Sba
                        End If
                        If .M(124) = 0 And Matdim(jRec).ElasCod > 0 Then
470:                        .M(124) = Matdim(jRec).EmodAlt(.M(2))
                            .Z(124) = .M(124) * psi
                        End If
                    End If
                    If Not .LOOSE = 4 Or indice = 22 Then
                        'flangia----------------------
                        If .M(175) * .M(176) = 0 Or jInvolucr = 0 Then
                            If jInvolucr = 0 Then
                                locInd = -1
                                jRec = Nozzles(kLato, kNozzle).IndexF
                                DisplayMatF(Forza, indice, visual And Not ContinuoAuto)
                            Else
                                locInd = 1
                                jRec = Involucr(kLato, jInvolucr).indice(locInd - 1)
                            End If
                            If CerMat(jRec, locInd) = -1 Then LoadCond = -1 : Exit Sub
                            Matdim(jRec).SigmaAmm(CodiceStress(FlanBulDiv1), .M(2), Sfa, Sfo)
                            .M(175) = Sfa : .M(176) = Sfo
                        Else
                            Sfa = .M(175) : Sfo = .M(176)
                            If LoadCond Mod 2 = 1 Then Sfo = Sfa
                        End If
                        If LoadCond = 2 Then
                            Involucr(kLato, jInvolucr).St = Sfo
                            Involucr(kLato, jInvolucr).S0 = Sfa
                        End If
                    Else
                        'coperchio-------------------
                        If .LOOSE = 4 Then
                            If .M(177) * .M(178) = 0 Or indice = 122 Then
                                locInd = 1
                                jRec = Involucr(kLato, jInvolucr).indice(locInd - 1)
                                If CerMat(jRec, locInd) = -1 Then LoadCond = -1 : Exit Sub
                                Matdim(jRec).SigmaAmm(CodiceStress(FlanBulDiv1), (.M(2)), sca, Sco)
                                .M(124) = Matdim(jRec).EmodAlt(CSng(.M(2)))
                                .Z(124) = .M(124) * psi
                                .M(177) = sca : .M(178) = Sco
                            Else
                                sca = .M(177) : Sco = .M(178)
                                If LoadCond Mod 2 = 1 Then Sco = sca
                            End If
                            If LoadCond = 2 Then
                                Involucr(kLato, jInvolucr).St = Sco
                                Involucr(kLato, jInvolucr).S0 = sca
                            End If
                        End If
                    End If
                    'bocchelli----------------------------------
                    If nn > 0 Then
                        If .M(179) * .M(180) = 0 Or indice = 141 Then
                            If InStr(Nozzles(kLato, nn).Tipo, "OPEN") = 0 Then
                                jRec = Nozzles(kLato, nn).indice
                                If Not CerMatF(nn) Then Exit Sub
                                Matdim(jRec).SigmaAmm(CodiceStress(FlanBulDiv1), (.M(2)), Sna, Sno)
                                .M(179) = Sna : .M(180) = Sno
                                If LoadCond Mod 2 = 1 Then Sno = Sna
                            Else
                                .M(179) = 0 : .M(180) = 0
                            End If
                        Else
                            Sna = .M(179) : Sno = .M(180)
                        End If
                    End If
            End Select
        End With
    End Sub
    Private Sub DisplayMatF(ByVal Forza As Boolean, ByVal indice As Short, ByVal visual As Boolean)
        If jRec = 0 Then
            jRec = NuovoIndice()
            indici.Add(jRec)
            Nozzles(kLato, kNozzle).IndexF = jRec
            If Matdim(jRec) Is Nothing Then
                Matdim(jRec) = New LibMat.MaterialeNew1
                If Nozzles(kLato, kNozzle).RecIndF > 0 Then
                    Matdim(jRec).Indmat = Nozzles(kLato, kNozzle).RecIndF
                    Matdim(jRec).RecupMat(Monitor.Motore.Inizio.Archdir)
                End If
            End If
        End If
        If Not visual Or Not indice = 22 Then Exit Sub
        If Nozzles(kLato, kNozzle).RecIndF > 0 And Not Forza Then Exit Sub
        Dim frmMess As frmMessage = New frmMessage
        frmMess.Label1.Text = "Materiale della flangia del bocchello " & Trim(Nozzles(kLato, kNozzle).Mark)
        frmMess.Top = GlobalRoutines.TwipsToPixelsY(1000) - frmMess.Height
        frmMess.Left = GlobalRoutines.TwipsToPixelsX(1300)
        frmMess.Show()
        MatdimScelta(jRec, Matdim(jRec).Classe, _
             kLato, , _
             kNozzle, _
             GlobalRoutines.TwipsToPixelsX(1300), _
             GlobalRoutines.TwipsToPixelsY(1000))
        If Matdim(jRec).Editato Then Uniforma(jRec)
        frmMess.Dispose()
        '      Nozzles(kLato, kNozzle).RecIndF = Matdim(jRec).Indmat
    End Sub
    Private Sub DisplayMat(ByVal Forza As Boolean, ByVal indice As Short, ByVal visual As Boolean)
        If jRec = 0 Then
            jRec = NuovoIndice()
            indici.Add(jRec)
            Nozzles(kLato, kNozzle).IndiceB = jRec
            If Matdim(jRec) Is Nothing Then
                Matdim(jRec) = New LibMat.MaterialeNew1
                If Nozzles(kLato, kNozzle).RecIndB > 0 Then
                    Matdim(jRec).Indmat = Nozzles(kLato, kNozzle).RecIndB
                    Matdim(jRec).RecupMat(Monitor.Motore.Inizio.Archdir)
                End If
            End If
        End If
        Matdim(jRec).Agganciato = True
        If Not visual Or Not indice = 24 Then Exit Sub
        If Nozzles(kLato, kNozzle).RecIndB <= 0 Or Forza Then
            Dim frmMess As frmMessage = New frmMessage
            frmMess.Label1.Text = "Tiranti associati alla flangia " & Trim(Nozzles(kLato, kNozzle).Mark)
            frmMess.Top = GlobalRoutines.TwipsToPixelsY(1000) - frmMess.Height
            frmMess.Left = GlobalRoutines.TwipsToPixelsX(1300)
            frmMess.Show()
            MatdimScelta(jRec, 8, kLato, _
                , kNozzle, _
                GlobalRoutines.TwipsToPixelsX(1300), _
                GlobalRoutines.TwipsToPixelsY(1000))
            If Matdim(jRec).Editato Then Uniforma(jRec)
            frmMess.Dispose()
            Nozzles(kLato, kNozzle).RecIndB = Matdim(jRec).Indmat
        End If
    End Sub
    Private Function CerMatF(ByVal nn As Short) As Boolean
        If Matdim(jRec).Indmat > 0 Or Not Matdim(jRec).Agganciato Then Return True
        If Nozzles(kLato, nn).RecIndF > 0 Then
            Matdim(jRec).Indmat = Nozzles(kLato, nn).RecIndF
            Matdim(jRec).RecupMat(clsInizio.Archdir)
        Else
            MessageBox.Show(formTab, "Materiale non definito per la flangia del bocchello " & Nozzles(kLato, nn).Mark)
            LoadCond = -1
            Return False
        End If
        Return True
    End Function
    Public Sub Stampa(ByRef continua As Boolean)
        Dim InFile As String
        Dim ifl As Short
        Dim Tit As String
        If jInvolucr = 0 Then
            Mem.TIMA = Matdim(Nozzles(kLato, kNozzle).IndiceB).MatStr
        Else
            If Involucr(kLato, jInvolucr).indice(2 - 1) > 0 Then
                Mem.TIMA = Matdim(Involucr(kLato, jInvolucr).indice(2 - 1)).MatStr
            Else
                Mem.TIMA = "N.A."
            End If
        End If
        If Mem.File = ".cop" Then
            Mem.COID = Involucr(kLato, jInvolucr).Mark
            Mem.COMA = Matdim(Involucr(kLato, jInvolucr).indice(0)).MatStr
            If Not continua Then
                If Not PrepRapp(Template, "Coperchio", Mem.COID, FileSt, mioApert.lstRapp) Then Exit Sub
            End If
            Stampaco()
            'If wntorc(0) Then Stampato 1, False '((WmHI))
        ElseIf Mem.File = ".cob" Then
            Stampacob(kNozzle, True)
        Else
            If jInvolucr = 0 Then
                'Mem.FLID = Nozzles(kLato, kNozzle).Mark
                'Mem.FLMA = Matdim(Nozzles(kLato, kNozzle).IndexF).MatStr
                Tit = "Flangia"
            Else
                'Mem.FLID = Involucr(kLato, jInvolucr).Mark
                'Mem.FLMA = Matdim(Involucr(kLato, jInvolucr).indice(0)).MatStr
                Tit = "Flangione"
            End If
            If Not continua And jInvolucr > 0 Then
                If Not PrepRapp(Template, Tit, Mem.FLID, FileSt, mioApert.lstRapp) Then Exit Sub
            End If
            Select Case Mem.LOOSE
                Case -1
                    If Mem.Z(7) = -1 Then
                        InFile = "\WN5\LJ_STAMsl.LJF"
                    Else
                        InFile = "\WN5\LJ_STAM.LJF"
                    End If
                Case 2
                    If Mem.M(195) = 1 Then
                        InFile = "\WN5\FH_STAM.LJF"
                    ElseIf Mem.M(195) = 2 Then
                        InFile = "\WN5\FK_STAM.LJF"
                    Else
                        InFile = "\WN5\OP_STAM.LJF"
                    End If
                Case Else : InFile = "\WN5\WN_STAM" & Mem.File
            End Select
            If Mem.LOOSE = 5 And Involucr(kLato, jInvolucr).AccoppK = 3 Then InFile = InFile & "s"
            ifl = FreeFile()
            If Not OpenFile(clsInizio.Archdir.Trim & InFile, ifl) Then Exit Sub
            Sub11(ifl)
        End If
    End Sub
    Private Sub Sub11(ByRef ifl As Short, Optional ByVal salta As Boolean = False)
        Dim SpecCar(10) As Char
        Dim Substit(10) As String
        Dim nSpecCar As Short
        Dim ioutl As Short
        Dim Stringa5(4) As String
        Dim Twn, Tipo As String
        Dim POS2, POS1, n As Short
        Dim k As String
        Dim Dupl As Boolean
        Dim Numb As String = ""
        Dim Numb1 As String = ""
        Dim POS3 As Short
        Dim Load As String = ""
        Dim Scrit As String = ""
        Dim i, N1 As Short
        Dim TIR1, Riga, TIR2 As String
        Dim Stringa1(9) As String
        Dim iSpec As Short
        Dim Saltal As Boolean
        Dim s As Single
        Stringa5(1) = "per Code"
        Stringa5(2) = "Full Bolting"
        Stringa5(3) = "Fluor Daniel"
        Stringa5(4) = "Min Prestress"
        ioutl = FreeFile()
        FileOpen(ioutl, clsInizio.Archdir.Trim & "\WN5\WNLJ01.DAT", OpenMode.Input)
        For i = 1 To 9 : Stringa1(i) = LineInput(ioutl) : Next
        FileClose(ioutl)
        FileOpen(ioutl, clsInizio.DiscoRam & "SCRATCH", OpenMode.Output)
        '       Width #ioutl, 255
        nSpecCar = -1
        With Mem
            Do
420:            If EOF(ifl) Then FileClose(ifl) : Exit Do
                Twn = LineInput(ifl)
                Tipo = Mid(Twn, 1, 1)
                POS1 = GlobalRoutines.ValVir(Mid(Twn, 2, 3))
                POS2 = GlobalRoutines.ValVir(Mid(Twn, 5, 3))
                k = Mid(Twn, 9, Len(Twn) - 8)
                Select Case Tipo
                    Case "0" : FileClose(ifl) : Exit Do
                    Case "1" : PrintLine(ioutl, k)
                    Case "A"
                        Saltal = (.LOOSE = 4) And (POS1 = 137 Or POS1 = 139 Or POS1 = 141 Or POS1 = 142) And .Z(141) = 0
                        If Not Saltal Then
                            If POS1 = 41 And Configwn.FullBolt = 2 And LoadCond <> 1 Then
                                k = k.Trim & "+.785G{\sub ef}{_\super 2}P"
                                PrintLine(ioutl, GlobalRoutines.FormatS(k, .M(POS1), .Z(POS1)))
                            ElseIf (POS1 <> 164 Or .M(164) > 0) And (POS1 < 167 Or POS1 > 169 Or .M(POS1) > 0) Then
                                If (POS1 = 33 Or POS1 = 34) And LoadCond = 1 Then POS1 = POS1 + 160
                                PrintLine(ioutl, GlobalRoutines.FormatS(k, .M(POS1), .Z(POS1)))
                            Else
                                PrintLine(ioutl, "\par")
                            End If
                        End If
                    Case "a"
430:                    If LoadCond = 0 Or LoadCond = 2 Then
                            Dupl = Config(kLato).NMWDT = 2
                            If POS1 = 182 Or POS1 = 184 Then
                                If Dupl Then Numb = "1" : Numb1 = "Cond.#1" Else Numb = " " : Numb1 = ""
                                If Config(kLato).NMWDT > 0 Then PrintLine(ioutl, GlobalRoutines.FormatS(k, Numb, .M(POS1), .Z(POS1), Numb1))
                            Else
                                If Dupl Then
                                    Numb = "2" : Numb1 = "Cond.#2"
                                    If Config(kLato).NMWDT > 1 Then PrintLine(ioutl, GlobalRoutines.FormatS(k, Numb, .M(POS1), .Z(POS1), Numb1))
                                End If
                            End If
                        End If
                    Case "B"
                        '                           IF POS1 = 38 AND Configwn.FullBolt = 3 THEN GOSUB AggHydr
                        '                           IF POS1 = 39 AND Configwn.FullBolt = 3 THEN GOSUB AggHydr
                        POS3 = POS1 + POS2
                        If POS1 = 40 And Configwn.FullBolt = 2 And LoadCond <> 1 Then
                            n = InStr(k, "H+")
                            k = Left(k, n - 1) & "(" & Right(k, Len(k) - n + 1)
                            n = InStr(k, "p}")
                            k = Left(k, n + 1) & ").P/P{_\sub hydr}" & Right(k, Len(k) - n - 1)
                            '                               k$ = RTRIM$(k$) + ".P/P{_\sub hydr}"
                            'GOSUB AggHydr
                        End If
                        If (POS1 = 33 Or POS1 = 34) And LoadCond = 1 Then POS1 = POS1 + 160
                        PrintLine(ioutl, GlobalRoutines.FormatS(k, .M(POS1), .Z(POS1), .M(POS3), .Z(POS3)))
                    Case "b"
440:                    If LoadCond = 0 Or LoadCond = 2 Then
                            For i = 1 To Matdim(Involucr(kLato, jInvolucr).indice(0)).Caract.Count
                                If Matdim(Involucr(kLato, jInvolucr).indice(0)).Caract.Item(i).TextData.Codice = CodiceStress() Then
                                    Print(ioutl, GlobalRoutines.FormatS(k, Matdim(Involucr(kLato, jInvolucr).indice(0)).Caract.Item(i).TextData.MWDTrule))
                                    If InStr(Matdim(Involucr(kLato, jInvolucr).indice(0)).Caract.Item(i).TextData.MWDTrule, "UCS") Then
                                        PrintLine(ioutl, " Curve" & Matdim(Involucr(kLato, jInvolucr).indice(0)).Caract.Item(i).TextData.MWDTclause)
                                    Else
                                        PrintLine(ioutl)
                                    End If
                                    Exit For
                                End If
                            Next
                        End If
                    Case "C" : PrintLine(ioutl, GlobalRoutines.FormatS(k, .M(POS1), .M(POS1 + POS2)))
                    Case "c" : nSpecCar = nSpecCar + 1
                        SpecCar(nSpecCar) = Left(k, 1)
                        Substit(nSpecCar) = Right(k, Len(k) - 1)
                    Case "D" : PrintLine(ioutl, GlobalRoutines.FormatS(k, .M(POS1), .Z(POS1), .M(POS1 + POS2)))
                    Case "d" : PrintLine(ioutl, GlobalRoutines.FormatS(k, Stringa5(Configwn.FullBolt + 1)))
                    Case "E"
                        If POS1 = 206 Or POS1 = 207 Then
                            If .M(POS1) > 1 Then Twn = "NO" Else Twn = ""
                            PrintLine(ioutl, GlobalRoutines.FormatS(k, .M(POS1), Twn))
                        Else
                            PrintLine(ioutl, GlobalRoutines.FormatS(k, .M(POS1)))
                        End If
                    Case "e" : PrintLine(ioutl, GlobalRoutines.FormatS(k, .M(POS1), .M(POS2)))
                    Case "F" : If .XFil = 1 Or .XFil = 3 Then TIR1 = .TIR : TIR2 = "" Else TIR1 = "" : TIR2 = .TIR
450:                    PrintLine(ioutl, GlobalRoutines.FormatS(k, TIR1, TIR2))
                    Case "f" : PrintLine(ioutl, GlobalRoutines.FormatS(k, .Z(POS1)))
                    Case "G" : PrintLine(ioutl, GlobalRoutines.FormatS(k, .FLID)) 'ELSE PRINT #iout%,
                    Case "g"
                        Select Case .M(161)
                            Case 14 'diaframma saldato
                                PrintLine(ioutl, GlobalRoutines.FormatS(k, .M(POS1), .Z(POS1)))
                            Case 15
                                If LoadCond = 2 Then
                                    PrintLine(ioutl, GlobalRoutines.FormatS(k, .M(POS1), .Z(POS1)))
                                End If
                            Case 16
                                If LoadCond = 2 Then
                                    PrintLine(ioutl, GlobalRoutines.FormatS(k, .M(POS1) - 2 * .M(202), .Z(POS1) - 2 * .Z(202)))
                                    PrintLine(ioutl, "      Note : G' is equal to the seal weld ID minus twice the torus radius (" & Format(.M(202), "##.") & " mm)\par ")
                                End If
                        End Select
                    Case "H" : PrintLine(ioutl, GlobalRoutines.FormatS(k, .FLMA)) 'ELSE PRINT #iout%,
                    Case "I" : PrintLine(ioutl, GlobalRoutines.FormatS(k, .Gasket))
                    Case "J"
                        Select Case LoadCond
                            Case 0, 2 : Load = "Design"
                            Case 1 : Load = "Test"
                        End Select
                        PrintLine(ioutl, GlobalRoutines.FormatS(k, .M(POS1), .Z(POS1), Load))
                    Case "K" : PrintLine(ioutl, GlobalRoutines.FormatS(k, .M(POS1), .Z(POS1), .Z(POS1 + POS2)))
                    Case "k" : PrintLine(ioutl, GlobalRoutines.FormatS(k, .M(POS1), .Z(POS1), .Z(POS2)))
                    Case "L" : PrintLine(ioutl, GlobalRoutines.FormatS(k, .GasMat))
                    Case "M" : PrintLine(ioutl, GlobalRoutines.FormatS(k, .TIMA))
                    Case "N" : PrintLine(ioutl, GlobalRoutines.FormatS(k, .COID))
                    Case "O" : PrintLine(ioutl, GlobalRoutines.FormatS(k, .COMA))
                    Case "P" : PrintLine(ioutl, GlobalRoutines.FormatS(k, .NOID))
                    Case "Q" : PrintLine(ioutl, GlobalRoutines.FormatS(k, .NOMA))
                    Case "S"
                        Monitor.Motore.Problem.pag += 1
                        If Monitor.Motore.Problem.pag > 1 And Not mioApert.Check1.Checked Or jInvolucr = 0 Or salta Then Print(ioutl, "\par \page ")
                        PrintLine(ioutl, GlobalRoutines.FormatS(k, clsInizio.Firma))
                    Case "s"
                        PrintLine(ioutl, Left(k, 58))
                    Case "T", "t"
                        Select Case LoadCond
                            Case 0, 2 : Load = Space(4)
                            Case 1 : Load = "#" & Suffix
                        End Select
                        If Tipo = "t" Then
                            Load = Space(4)
                            Print(ioutl, "\par ")
                        Else
                            Load = Space(4)
                        End If
                        PrintLine(ioutl, GlobalRoutines.FormatS(k, Load, Monitor.Motore.About.ProgName, Monitor.Motore.About.ProgVers, Monitor.Motore.About.ProgDate))
                    Case "U" : PrintLine(ioutl, GlobalRoutines.FormatS(k, PNETdim(POS1), PNETdim(POS1) * psi, Controlling(Classedim(POS1) + 3)))
                    Case "V" : PrintLine(ioutl, GlobalRoutines.FormatS(k, CodiceCalc))
                    Case "W"
470:                    If Configwn.FullBolt = 2 Then
                            Scrit = "A{\sub b}S{\sub ba}"
                        ElseIf Configwn.FullBolt = 3 And (LoadCond = 1 Or VerificandoPI) Then
                            Scrit = "A{\sub b}S{\sub min}"
                        Else
                            Scrit = "(A{\sub m}+A{\sub b})S{\sub ba}/2"
                        End If
                        PrintLine(ioutl, GlobalRoutines.FormatS(k, .M(POS1), .Z(POS1), Scrit))
                        If (LoadCond = 1 Or VerificandoPI) Then
                            If Not Configwn.FullBolt = 3 Then
                                PrintLine(ioutl, GlobalRoutines.FormatS("_\par (Note: in this formula S{_\sub ba}=######.# psi)", .Z(173)))
                            Else
                                PrintLine(ioutl, GlobalRoutines.FormatS("_\par (Note: S{_\sub min}=######.# psi, minimum bolting-up prestress)", .Z(204)))
                            End If
                        End If
                    Case "X" : PrintLine(ioutl, GlobalRoutines.FormatS(k, Monitor.Motore.About.ProgName, Monitor.Motore.About.ProgVers, Monitor.Motore.About.ProgDate))
                    Case "Y" : PrintLine(ioutl, GlobalRoutines.FormatS(k, Stringa1(.LOOSE + 2)))
                    Case "Z"
                        Select Case LoadCond
                            '  Case 0: Load = "not defined"
                        Case 1 : Load = "Hydraulic Test"
                            Case 0, 2 : Load = "Design"
                        End Select
                        PrintLine(ioutl, GlobalRoutines.FormatS(k, Load))
                    Case "x"
                        With Serr
                            Select Case POS1
                                Case 1 : s = .prp(1) 'p
                                Case 2 : s = .prt(1) 't
                                Case 3 : s = .prphydr(1) 'x
                                Case 6 : s = .prDiam(1) 'x
                                Case 7 : s = .prsa2(1) 'x
                                Case 8 : s = .prv(1) * .prnb 'x
                                Case 9 : s = .prv(1) 'x
                                Case 11 : s = .prv(1) * .prk1 'x
                                Case 13 : s = .prv(1) * .prk1 * .prk2Pilgrim
                                Case 15 : s = .prvPilgrim(1)
                                Case 16 : s = .prvPilgrim(1) / .prArea(1)
                                Case 17 : s = .prAreaPist(1)
                                Case 18 : s = .prPresPist(1)
                                Case 20 : s = .prv(1) * .prk1 * .prk2Torque
                                Case 21 : s = .prpassofil(1)
                                Case 29 : s = .prDiammed(1)
                                Case 31 : s = .prChiave(1)
                                Case 30 : s = .prTorque(1)
                            End Select
                            Select Case POS1
                                Case 1, 3, 7, 16
                                    PrintLine(ioutl, GlobalRoutines.FormatS(k, s, s * psi))
                                Case 2
                                    PrintLine(ioutl, GlobalRoutines.FormatS(k, s, s * 1.8 + 32))
                                Case 6, 21, 29, 31
                                    PrintLine(ioutl, GlobalRoutines.FormatS(k, s, s / inc))
                                Case 8, 9, 11, 13, 15
                                    PrintLine(ioutl, GlobalRoutines.FormatS(k, s, s / NIUT))
                                Case 17
                                    PrintLine(ioutl, GlobalRoutines.FormatS(k, s, s / inc ^ 2))
                                Case 18
                                    PrintLine(ioutl, GlobalRoutines.FormatS(k, s * 10, s * psi))
                                Case 20, 30
                                    PrintLine(ioutl, GlobalRoutines.FormatS(k, s, s / NIUT / inc * 1000))
                            End Select
                        End With
                    Case "y"
                        With Serr
                            Select Case POS1
                                Case 4 : PrintLine(ioutl, GlobalRoutines.FormatS(k, .prDN, .prDN))
                            End Select
                        End With
                    Case "z"
                        With Serr
                            Select Case POS1
                                Case 10 : PrintLine(ioutl, GlobalRoutines.FormatS(k, .prk1))
                                Case 12 : PrintLine(ioutl, GlobalRoutines.FormatS(k, .prk2Pilgrim))
                                Case 14 : PrintLine(ioutl, GlobalRoutines.FormatS(k, .prk3))
                                Case 19 : PrintLine(ioutl, GlobalRoutines.FormatS(k, .prk2Torque))
                                Case 5 : PrintLine(ioutl, GlobalRoutines.FormatS(k, .prnb))
                                Case 22 : PrintLine(ioutl, GlobalRoutines.FormatS(k, .prAlf))
                                Case 23 : PrintLine(ioutl, GlobalRoutines.FormatS(k, .prAlfa * 180 / pi))
                                Case 24 : PrintLine(ioutl, GlobalRoutines.FormatS(k, .prbeta * 180 / pi))
                                Case 27 : PrintLine(ioutl, GlobalRoutines.FormatS(k, .prfGlob))
                            End Select
                        End With
                    Case "w"
                        Select Case POS1
                            Case 25 : PrintLine(ioutl, GlobalRoutines.FormatS(k, Serr.prfDado, Serr.prfNomeDado))
                            Case 26 : PrintLine(ioutl, GlobalRoutines.FormatS(k, Serr.prfFil, Serr.prfNomeFil))
                        End Select
                End Select
            Loop
            FileClose(ioutl)
            FileOpen(ioutl, clsInizio.DiscoRam & "SCRATCH", OpenMode.Input)
            Do
                If EOF(ioutl) Then Exit Do
                Riga = LineInput(ioutl)
                If nSpecCar > -1 Then
                    Do
                        n = 0
                        For i = 0 To nSpecCar
                            N1 = InStr(Riga, SpecCar(i))
                            If N1 > 0 And (n = 0 Or n > 0 And N1 < n) Then
                                iSpec = i : n = N1
                            End If
                        Next
490:                    If n = 0 Then Exit Do
                        If n > 1 Then Monitor.Motore.Problem.Printa(Left(Riga, n - 1))
                        Monitor.Motore.Problem.Print(Substit(iSpec))
                        Riga = Right(Riga, Len(Riga) - n)
                    Loop
                End If
                Monitor.Motore.Problem.Printa(Riga)
            Loop
        End With
        FileClose(ioutl)
        Kill(clsInizio.DiscoRam & "SCRATCH")
    End Sub
    Public Sub CalcMAWP()
        If Config(0).CalcMAWP = 0 Then Exit Sub
        '1913:   Call AggCorr()
        If Mem.File = ".cop" Then
            Call MAWPcop()
            If qbflan = -99 Then Exit Sub
        Else
            Call MAWP(0)
            If qbflan = -99 Then Exit Sub
            Call StamMAWPF(0)
        End If
    End Sub
    Private Sub StamMAWPF(ByRef mode As Short)
        Dim ifl As Short
        Dim File As String = ""
        Controlling(0) = "          "
        Controlling(1) = "Bolts     "
        Controlling(2) = "Flange    "
        If mode = 1 Then Controlling(2) = "Cover     "
        ifl = FreeFile()
        With Mem
            If mode = 0 Then
                If .LOOSE = 5 Or .LOOSE = 6 Then
                    File = RTrim(clsInizio.Archdir) & "\WN5\WN_MAWP.A14"
                Else
                    File = RTrim(clsInizio.Archdir) & "\WN5\WN_MAWP.WNF"
                End If
            ElseIf mode = 1 Then
                File = RTrim(clsInizio.Archdir) & "\WN5\WN_MAWP.COP"
            ElseIf mode = 2 Then
                File = RTrim(clsInizio.Archdir) & "\WN5\WN_MAWP.COB"
            End If
            If OpenFile(File, ifl) Then
                Sub11(ifl)
                FileClose(ifl)
            End If
        End With
    End Sub

    '    Sub AggCorr()
    '        Dim I11 As Short
    '        If Mem.File = ".cop" Then
    '            If Configwn.LatoProgetto = 1 Then Config(2).Corr = Mem.M(120) Else Config(1).Corr = Mem.M(120)
    '        Else
    '            If Not (Mem.LOOSE = -1 Or Mem.LOOSE = 2) Then
    '                I11 = 11 : If Mem.LOOSE = 5 Or Mem.LOOSE = 6 Then I11 = 12
    '                If Configwn.LatoProgetto = 1 Then Config(2).Corr = Mem.M(I11) Else Config(1).Corr = Mem.M(I11)
    '            End If
    '        End If
    '    End Sub
    Public Sub CalcMinTemp()
        If Mem.File = ".cop" Then
            Call MinTempF(3)
        Else
            Call MinTempF(4)
        End If
    End Sub
    Private Function ROTFL(ByRef objROTFL As typROTFL) As Boolean
        '---------------------------------------------------------------------------
        ' Scrive i dati correnti sul file ROTFLFOR.INP opportunamente formattato
        ' in modo da poter esser letto dal programma ROTFLFOR.EXE.
        '---------------------------------------------------------------------------
        Dim Area, MLungB As Single
        Dim Testo As String
        ROTFL = True
        With objROTFL
            .Arch = Config(0).DNjob
            .Membr = Involucr(kLato, jInvolucr).Mark
            If Mem.File = ".cop" Then
                .Mater = Mem.COMA
            Else
                .Mater = Mem.FLMA
            End If
            .temp = Mem.M(2) 'temp
            If Mem.File = ".cop" Then
                .DiamInt = 0.0# '0 myStr(0!, 11, 6, False)           'diam.int
                'If .DiamInt <= 0 Then GoTo No
                .DiamExt = Mem.M(37) ' myStr(CSng(Mem.m(37)), 11, 6, False)   'diam.ext
                If .DiamExt <= .DiamInt Then GoTo No
                .Spess = Mem.M(119) - Mem.M(11) ' myStr(CSng(Mem.m(119)), 11, 6, False)    'spessore
                If .Spess <= 0 Then GoTo No
                MLungB = Mem.M(119) + Mem.M(15)
                .g1 = 0.0# ' myStr(0!, 11, 6, False)               'g1
                'If .g1 <= 0 Then GoTo No
                .hub = 0.0# ' myStr(0!, 11, 6, False)             'hub length
                'If .hub <= 0 Then GoTo No
            Else
                .DiamInt = Mem.M(6) + 2 * Mem.M(11) ' myStr(CSng(Mem.m(6)), 11, 6, False)  'diam.int
                If .DiamInt <= 0 Then GoTo No
                .DiamExt = Mem.M(3) ' myStr(CSng(Mem.m(3)), 11, 6, False)   'diam.ext
                If .DiamExt <= .DiamInt Then GoTo No
                .Spess = Mem.M(9) ' myStr(CSng(Mem.m(9)), 11, 6, False)    'spessore
                If .Spess <= 0 Then GoTo No
                MLungB = Mem.M(9) + Mem.M(15)
                .g1 = Mem.M(8) - Mem.M(11) ' myStr(CSng(Mem.m(8)), 11, 6, False)        'g1
                If .g1 < 0 Then GoTo No
                .hub = Mem.M(10) - Mem.M(11) ' myStr(CSng(Mem.m(10)), 11, 6, False)    'hub length
                If .hub < 0 Then GoTo No
            End If
            If Mem.LOOSE = -1 Or Mem.LOOSE = 2 Or Mem.File = ".cop" Then
                .g0 = 0.0# ' myStr(0!, 11, 6, False)      'g0
                'If .g0 <= 0 Then GoTo No
            Else
                .g0 = Mem.M(7) ' myStr(CSng(Mem.m(7)), 11, 6, False)      'g0
                If .g0 <= 0 Then GoTo No
            End If
            .E0 = Mem.M(90) ' / GRAV 'myStr(CSng(Mem.m(90)) / GRAV, 11, 6, False))    'Young
            .E1 = Mem.M(187) ' / GRAV ' myStr(CSng(Mem.m(187)) / GRAV, 11, 3, False)    'Young
            '   .W = Mem.m(42) / GRAV 'myStr(CSng(Mem.m(42)) / GRAV, 11, 6, False)   'W
            '     If Mem.m(41) > Mem.m(40) Then
            .W = Mem.M(40) ' / GRAV 'Wm1
            '     Else
            .wm2 = Mem.M(41) ' / GRAV
            '     End If
            If .W <= 0 Then GoTo No
            .Press = Mem.M(1) ' / GRAV 'myStr(CSng(Mem.m(1)) / GRAV, 11, 6, False)    'press
            If .Press <= 0 Then GoTo No
            .BC = Mem.M(4) ' myStr(CSng(Mem.m(4)), 11, 6, False)          'Bolt circle
            If .BC <= 0 Then GoTo No
            .BoltL = MLungB ' myStr(CSng(MLungB), 11, 6, False)    'Bolt length
            .BoltN = Mem.M(13) ' myStr(CSng(Mem.m(13)), 11, 6, False)
            Area = pi / 4 * Mem.M(14) * Mem.M(14)
            .BoltA = Area ' myStr(Area, 11, 6, False)
            If .BoltA <= 0 Then GoTo No
            .gef = Mem.M(37) ' myStr(CSng(Mem.m(37)), 11, 6, False)     'Diam.eff.guarn
            If .gef <= 0 Then GoTo No
            .b0 = Mem.M(36) ' myStr(CSng(Mem.m(36)), 11, 6, False)     'Largh.eff.guarniz
            If .b0 <= 0 Then GoTo No
            .n = Mem.M(26) ' myStr(CSng(Mem.m(26)), 11, 6, False)     'Largh.tot.guarn
            If .n <= 0 Then GoTo No
            .EE = Mem.M(90) ' / GRAV 'myStr(CSng(Mem.m(90)) / GRAV, 11, 6, False)  'E???
            .SpGuar = 3.0# ' myStr(3!, 11, 6, False)           'Spess.guarn.
            .DiscoRam = clsInizio.DiscoRam.PadRight(40)
            .ArchDir = clsInizio.Archdir.PadRight(40)
            .Intest = Monitor.Motore.About.ProgName & "(Vers. " & Monitor.Motore.About.ProgVers & ", " & Monitor.Motore.About.ProgDate & ")"
            .Norma = CodiceCalc() & ")"
        End With
        Exit Function
No:     ROTFL = False
        Testo = "  Alcuni dei dati necessari per il calcolo" & vbCrLf
        Testo = Testo & "della rotazione non sono definiti." & vbCrLf
        Testo = Testo & "  In particolare, porre attenzione al fatto" & vbCrLf
        Testo = Testo & "che la rotazione non può essere calcolata" & vbCrLf
        Testo = Testo & "per una flangia non ancora verificata."
        MessageBox.Show(formTab, Testo, "AsmeVip - Calcolo Grandi Fucinati")
    End Function
    Public Function RilBull0() As Boolean
        Dim mm As Short
        RilBull0 = True
        If Not qbflan = -98 Then qbflan = 0
        mm = 1 : LoadCond = 1
        Call Carichi(mm, 0)
        If mm = -1 Then GiaCalc = False : Call WarnCar() : RilBull0 = False : Exit Function
        Mem.M(105) = Mem.M(1) : Mem.Z(105) = Mem.Z(1)
    End Function
    Public Function RilBull1() As Boolean
        Dim mm, ic As Short
        Dim Z0 As Single
        Dim a As String
        Dim ZZ, J1 As Single
        Dim junk As Integer
        Dim rappvecchio, m14 As Single
        Dim Flangia1, Flangia, Testo As String
        Dim kAcc, jAcc As Short
        Dim Accoppiato As New wn_flan
        Dim AccoppiataPT As New wn_PT
        Dim rappExt, Wm2Ext As Single
        m14 = Mem.M(14)
        kAcc = Involucr(kLato, jInvolucr).AccoppK
        jAcc = Involucr(kLato, jInvolucr).AccoppJ
        If jAcc > 0 Then
            If Involucr(kAcc, jAcc).IndObject > -1 Then
                If Involucr(kAcc, jAcc).Tipo = 6 Then
                    AccoppiataPT = objMemb(Involucr(kAcc, jAcc).IndObject)
                Else
                    Accoppiato = objMemb(Involucr(kAcc, jAcc).IndObject)
                End If
            End If
        End If
        With Mem
            Modifica = False
            If .LOOSE = 4 Then
                Flangia = "del coperchio"
                Flangia1 = "coperchio"
            Else
                Flangia = "della flangia"
                Flangia1 = "flangia"
            End If
            RilBull1 = True
            On Error GoTo ErrRil
            'CloseioutS iout, mioAPert.lstRapp
1811:       If m14 = 0 Then .M(14) = 0
            SupCalcola()
            If qbflan = -99 Or qbflan = 1 Or qbflan = 5 Then RilBull1 = False : Exit Function
            If Not GiaCalc Then Exit Function
            '     CALL AggCorr
            If Configwn.Verbose Then
                a = " Si va a calcolare la rotazione |"
                a = a & Flangia & " e il rilassamento dei bulloni |"
                a = a & "dovuto alla pressurizzazione|"
                MessageBox.Show(formTab, clsInizio.ConvertiCr(a), "AsmeVip - Calcolo Grandi Fucinati")
            End If
            rappvecchio = 0 : ic = 0
            Do
1813:           If Not wnrota(Z0, ZZ, J1, rapp) Then
                    RilBull1 = False
                    Exit Function
                End If
                Wm1PI = Z33 * NIUT ' .m(40)   'carico bulloni per la tenuta in P.I.
                Wm2PI = Z34 * NIUT '.m(41)   'carico bulloni per il seating
                If Not Accoppiato Is Nothing Then
                    If Wm2Ext < Accoppiato.Mp(194) Then Wm2Ext = Accoppiato.Mp(194)
                ElseIf Not AccoppiataPT Is Nothing Then
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto AccoppiataPT.FlDati(18). Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto AccoppiataPT.FlDati(). Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                    If Wm2Ext < AccoppiataPT.FlDati(18) * NIUT Then Wm2Ext = AccoppiataPT.FlDati(18) * NIUT
                End If
                rappExt = Wm2Ext / Wm1PI / Configwn.SicBull
                If rappExt <= rapp Then
                    .M(200) = rapp
                    ic = ic + 1
                    Wm2imp = Wm1PI * rapp * Configwn.SicBull 'carico bulloni corretto per la tenuta in p.i.
                    If Configwn.FullBolt = 3 Then
                        If .M(42) > Wm1PI * rapp * Configwn.SicBull Then Wm2imp = .M(42)
                    End If
                    If System.Math.Abs(rapp - rappvecchio) < 0.001 Then Exit Do
                    If ic > 100 Then
                        MessageBox.Show(formTab, "Non è stata raggiunta la convergenza nel calcolo del rapporto di scarico bulloni.", "AsmeVip - Calcolo Grandi Fucinati")
                        Exit Do
                    End If
                    rappvecchio = rapp
                Else
                    .M(200) = rappExt
                    Wm2imp = Wm2Ext
                    .M(194) = Wm2imp : .Z(194) = .M(194) / NIUT
                    Exit Do
                End If
                If Not Accoppiato Is Nothing Then
                    If Wm2imp < Accoppiato.Mp(194) Then Wm2imp = Accoppiato.Mp(194)
                ElseIf Not AccoppiataPT Is Nothing Then
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto AccoppiataPT.FlDati(18). Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto AccoppiataPT.FlDati(). Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                    If Wm2imp < AccoppiataPT.FlDati(18) * NIUT Then Wm2imp = AccoppiataPT.FlDati(18) * NIUT
                End If
                .M(194) = Wm2imp : .Z(194) = .M(194) / NIUT
                If m14 = 0 Then .M(14) = 0
                SupCalcola()
                If qbflan = -99 Or qbflan = 1 Then RilBull1 = False : Exit Function
            Loop
            If J1 > 1 Then
                Testo = "ATTENZIONE : fattore di flessibilità J = "
                Testo = Testo & Str(J1) & " > 1.0 !|"
                Testo = Testo & "Il requisito di minima rigidezza di flangia|"
                Testo = Testo & "secondo ASME VIII Div.1 Appendix S para.S-2|"
                Testo = Testo & "non è soddisfatto (però l'App.S è non-mandatory)."
                If Not ContinuoAuto Then
                    MessageBox.Show(formTab, clsInizio.ConvertiCr(Testo))
                Else
                    nIndent = 6
                    PrintlstRes(Testo)
                    nIndent = 0
                End If
            End If 'aa
            If Configwn.Verbose Then
                Testo = "Rotazioni in prova idraulica|"
                Testo = Testo & "Rotazione " & Flangia & " in radianti = " & GlobalRoutines.myStr(CSng(ZZ), 5, 4, False)
                Testo = Testo & "|Rotazione " & Flangia & " in gradi    = " & GlobalRoutines.myStr(CSng(Z0), 5, 4, False)
                Monitor.Motore.Messaggio(clsInizio.ConvertiCr(Testo), Tit:="AsmeVip", Proportional:=True)
            End If '0
            If Wm2imp > Wm2PI Then
                If Configwn.Verbose Then
                    a = " Si va a verificare la tenuta  |"
                    a = a & Flangia & " in P.I. a seguito|"
                    a = a & "del carico dei bulloni 'sicuro'|"
                    MessageBox.Show(formTab, clsInizio.ConvertiCr(a), "AsmeVip - Calcolo Grandi Fucinati")
                End If
                DimensM = True 'l'm di guarnizione Š dimensionante
                If Wm2imp > .M(194) Then .M(194) = Wm2imp : .Z(194) = .M(194) / NIUT
                If m14 = 0 Then .M(14) = 0
1815:           SupCalcola()
                'If Z34 / NIUT > Wm2imp Then Wm2imp = Z34 / NIUT
                'If Z33 > .z(193) Then .z(193) = Z33
                'If Z34 > .z(194) Then .z(194) = Z34
                '.m(193) = .z(193) * NIUT: .m(194) = .z(194) * NIUT
                If qbflan = -99 Then RilBull1 = False : Exit Function
                If Not GiaCalc Then Exit Function
                If Modifica Then
                    .M(34) = 0 : .Z(34) = 0
                    Modifica = False
                    CloseioutS((mioApert.lstRapp))
                    GoTo 1811
                End If
            Else
                Wm2imp = Wm2PI
                .M(194) = Wm2imp : .Z(194) = .M(194) / NIUT
                DimensM = False 'l'Y di guarnizione Š dimensionante
            End If
            AmPI = .M(45) : AbPI = .M(46) : FattSicPI = 1 / FattSic
            Stampa(False)
            If Monitor.Motore.Problem.FileStream Is Nothing Then
                RilBull1 = False : Exit Function
            End If
            Stamparo("")
            WmHI = .Z(193)
            If .Z(194) > WmHI Then WmHI = .Z(194)
            If .Z(40) > WmHI Then WmHI = .Z(40)
            If .Z(41) > WmHI Then WmHI = .Z(41)
        End With
        If Configwn.Verbose Then
            a = " Si va a verificare la tenuta  |"
            a = a & Flangia & " in condizioni di progetto.|"
            MessageBox.Show(formTab, clsInizio.ConvertiCr(a), "AsmeVip - Calcolo Grandi Fucinati")
        End If
        mm = 2 : LoadCond = 2
        formTab.VisualTipo = 2
        Call Carichi(mm, 0)
        If mm = -1 Then
            GiaCalc = False : Call WarnCar()
            qbflan = -99 : Exit Function
        End If
        formTab.SetPagina(1)
10270:  Exit Function
ErrRil:
        If Err.Number = 5 Or Err.Number = 6 Then
            a = Involucr(kLato, jInvolucr).Mark.Trim & ".|"
            a = a & "Mancano dati essenziali nell'input"
            MessageBox.Show(formTab, clsInizio.ConvertiCr(a), "AsmeVip - Calcolo Grandi Fucinati")
            qbflan = -99
            Resume 10270
        Else
            MessageBox.Show(formTab, "RilBull " & Err.Description & Str(Erl()))
            'Resume
            Resume Next
        End If
    End Function
    Public Function CalcolaProgetto() As Short
        Dim a As String
        Dim AmOp, Wm1Op, AbOp As Single
        Dim SurB, FattSicOp As Single
        Dim Flangia, Flangia1 As String
        Dim Z0, rapp, j, Rotaz As Single
        CalcolaProgetto = True
        Modifica = False
        If Mem.LOOSE = 4 Then
            Flangia = "del coperchio"
            Flangia1 = "coperchio"
        Else
            Flangia = "della flangia"
            Flangia1 = "flangia"
        End If
        '-------------------------------------------------------
        ''''    m(34) = 0: Z(34) = 0
        '---------------------------------------------------------
        SupCalcola()
        If qbflan = -99 Then Exit Function
        If Not GiaCalc Then Exit Function
        '       Call AggCorr()
        Stampa(Not Monitor.Motore.Problem.FileStream Is Nothing)
        If Modifica Then
            Mem.M(34) = 0 : Mem.Z(34) = 0
            CloseioutS((mioApert.lstRapp))
            CalcolaProgetto = 1
            Exit Function
        End If
        Dim junk As ChiaviMess
        If Configwn.Verbose Then
            Wm1Op = Mem.M(40) 'carico bulloni per la tenuta in Operating
            AmOp = Mem.M(45) : AbOp = Mem.M(46) : FattSicOp = 1 / FattSic
            SurB = AbPI / AmPI : If AbOp / AmOp < SurB Then SurB = AbOp / AmOp
            a = "                RISULTATI DELLA VERIFICA     ||"
            a = a & "                                        Carico Bulloni [kN]"
            a = a & "|per la tenuta in P.I. (nominale)  " & GlobalRoutines.myStr(Wm1PI / 1000.0!, 6, 2, False)
            a = a & "|per la tenuta in P.I. (effettivo) " & GlobalRoutines.myStr(Wm2imp / 1000.0!, 6, 2, False)
            a = a & "|per il seating                    " & GlobalRoutines.myStr(Wm2PI / 1000.0!, 6, 2, False)
            a = a & "|per la tenuta in Oper.(nominale)  " & GlobalRoutines.myStr(Wm1Op / 1000.0!, 6, 2, False)
            a = a & "|                                       Margini di verifica  "
            a = a & "|bulloni                           " & GlobalRoutines.myStr((SurB - 1) * 100.0!, 6, 2, False) & " %"
            a = a & "|" & Flangia1 & " in P.I.                   " & GlobalRoutines.myStr((FattSicPI - 1) * 100.0!, 6, 2, False) & " %"
            a = a & "|" & Flangia1 & " in Operating              " & GlobalRoutines.myStr((FattSicOp - 1) * 100.0!, 6, 2, False) & " %"
            a = a & "|     è dimensionante  :           "
            If DimensM Then
                a = a & "   m di guarnizione"
            Else
                a = a & "   Y di guarnizione"
            End If
            a = a & "|     Rapporto di scarico bulloni  " & GlobalRoutines.myStr(rapp, 1, 3, False)
            a = a & "|Si approva?"
            junk = Monitor.Motore.Messaggio(clsInizio.ConvertiCr(a), ChiaviMess.MessQuestion Or ChiaviMess.MessYesNo, "AsmeVip", , , True)
        Else
            junk = ChiaviMess.MessSi
        End If
        If junk = ChiaviMess.Messno Then
            qbflan = 0
            Mem.M(34) = 0 : Mem.Z(34) = 0 ': Mode = 1
            CalcolaProgetto = 1 : Exit Function
        Else
            CalcMAWP()
        End If
        If TipCalc = 3 Then
            If wnrota(Rotaz, Z0, j, rapp, True) Then Stamparo("")
        End If
        Call wntorc(WmHI)
        Call Stampato(1, False)
        qbflan = 0
        Exit Function
    End Function
    Private Sub Stampaco()
        Dim ifl As Short
        Dim File As String = ""
        ifl = FreeFile()
        Select Case Config(kLato).DC
            Case 0, 1, 2, 9, 10, 11 : File = "\WN5\wn_stam.cop"
            Case 3, 4, 5 : File = "\WN5\wn_stam2.cop"
        End Select
        File = RTrim(clsInizio.Archdir) & File
        If Not OpenFile(File, ifl) Then Exit Sub
        Call Sub11(ifl)
        FileClose(ifl)
        If Mem.Z(32) > 0 Then 'Wmt>0
            File = RTrim(clsInizio.Archdir) & "\WN5\wn1stam.cop"
        Else
            File = RTrim(clsInizio.Archdir) & "\WN5\wn3stam.cop"
        End If 'u
        If Not OpenFile(File, ifl) Then Exit Sub
        Call Sub11(ifl)
        FileClose(ifl)
        File = RTrim(clsInizio.Archdir) & "\WN5\wn2stam.cop"
        If Not OpenFile(File, ifl) Then Exit Sub
        Call Sub11(ifl)
        FileClose(ifl)
    End Sub
    Public Sub Stampato(ByRef mode As Short, ByRef Capitolo As Boolean)
        Dim ifl As Short
        Dim Nome As String
        If Capitolo Then If Not PrepRapp(Template, "Serraggio bulloni", Involucr(kLato, jInvolucr).Mark.Trim, FileSt, mioApert.lstRapp, livello:=2) Then Exit Sub
        ifl = FreeFile()
        Nome = RTrim(clsInizio.Archdir) & "\WN5\"
        If mode = 0 Then
            Nome = Nome & "wn_st_to"
            If Configwn.BoltLoadDetail Then Nome = Nome & "S"
            Nome = Nome & ".WNF"
        Else
            If Mem.File = ".cop" Then
                Nome = Nome & "wn1st_to"
                If Configwn.BoltLoadDetail Then Nome = Nome & "S"
                Nome = Nome & ".COP"
            Else
                Nome = Nome & "wn1st_to"
                If Configwn.BoltLoadDetail Then Nome = Nome & "S"
                Nome = Nome & ".WNF"
            End If
        End If 'x
        If Not OpenFile(Nome, ifl) Then Exit Sub
    End Sub
    Sub WarnCar()
        '    Dim Stringa3(4) As String
        '    Stringa3$(0) = "per la flangia": Stringa3$(2) = "dei bulloni"
        '    Stringa3$(3) = "per il coperchio"
        '    Stringa3$(4) = "dei bocchelli"
        '    If jRec > 4 Then jRec = 4
        '    a$ = "Il materiale " + Stringa3$(jRec) + "|non Š stato definito"
        '         junk = Alert(4, a$, 7, 9, 15, 49, "OK", "", "")
        '    Call Materiali
        MessageBox.Show(formTab, "BOH!?")
    End Sub
    Public Function Supercont(ByRef iBocc As Short) As Boolean
        Dim a As String
        Dim nn, mm As Short
        '          If Record(5).Ind > 0 Or AddDistinta = 0 Then 'bocchello
        qbflan = 0
        Supercont = True
        NBocc = Involucr(kLato, jInvolucr).Fine - Involucr(kLato, jInvolucr).inizio + 1
        If iBocc = 0 Then
            If Configwn.Verbose Then
                a = " Si va a conteggiare le distanze|"
                a = a & "relative tra le aperture secondo|"
                a = a & "UG-39  .|"
                MessageBox.Show(formTab, clsInizio.ConvertiCr(a))
            End If
        End If
1912:   If Not Conteggio(iBocc, False) Then qbflan = -99 : Supercont = False : Exit Function
        If iUG39b3 Or iUG39c Then Exit Function
        If Configwn.Verbose And iBocc = 0 Then
            a = " Si va a verificare la compen-|"
            a = a & "sazione delle aperture sul co- |"
            a = a & "perchio piano.                |"
            MessageBox.Show(formTab, clsInizio.ConvertiCr(a))
        End If
        i1 = 0 : i2 = NBocc - 1 : If AddDistinta = 0 Then i1 = Involucr(kLato, jInvolucr).inizio : i2 = Involucr(kLato, jInvolucr).Fine
        If iBocc > 0 Then i1 = iBocc : i2 = iBocc
        For nn = i1 To i2
            kNozzle = nn
            Mem.NOID = RTrim(Nozzles(kLato, nn).Mark) ' + " Pos." + Str$(Record(5 + nn%).PosDis)
            If Not InStr(Nozzles(kLato, nn).Tipo, "OPEN") > 0 Then
                Mem.NOMA = Matdim(Nozzles(kLato, nn).indice).MatStr
            End If
            qbflan = 0
            If VerificandoPI Then
                mm = 1 : LoadCond = 1
                Call Carichi(mm, nn)
            Else
                mm = 2 : LoadCond = 2
                Call Carichi(mm, nn)
            End If
            If mm = -1 Then GiaCalc = False : Call WarnCar() : qbflan = -99 : Supercont = False : Exit Function
Rif:        Call Caract(nn)
            Mem.File = ".cob" : pagina = 1 : SupCalcola()
            Mem.File = ".cop"
            If qbflan = -99 Then Supercont = False : Exit Function
            If Not ContinuoAuto Then
                Dim Risult As System.Windows.Forms.DialogResult
                If iBocc = 0 Then
                    If Configwn.Verbose Then
                        a = " Vuoi ispezionare i dati dettagliati|"
                        a = a & "relativi al calcolo della compensazione|dell'apertura " & Mem.NOID.Trim & "?"
                        Risult = MessageBox.Show(formTab, clsInizio.ConvertiCr(a), "AsmeVip - Calcolo Grandi Fucinati", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    Else
                        Risult = DialogResult.No
                    End If
                Else
                    Risult = DialogResult.Yes
                End If
                If Risult = DialogResult.Yes Then
                    Mem.File = ".cob"
                    With formTab
                        .Compensazione = True
                        .SetPagina(1)
                        .cmdOk.Visible = False
                        .cmdCancel.Text = "OK"
                        .cmdCalc.Visible = False
                        Dim Testo As String = .Text
                        .Text = "AsmeVip - Calcolo apertura " + Mem.NOID.Trim + " su coperchio"
                        .TopMost = True
                        .Show()
                        .Finito = False
                        Do
                            System.Windows.Forms.Application.DoEvents()
                        Loop Until .Finito
                        .OK = True
                        .Text = Testo
                        .Finito = False
                    End With
                End If
            End If
            If Mem.Conforme = "NO" Then GoTo Rif
            If Not Stampacob(nn, True) Then Supercont = False : Exit Function
            Select Case Nozzles(kLato, kNozzle).Tipo
                Case "WN", "LWN"
                    Nozzles(kLato, kNozzle).DiOn = Nozzles(kLato, kNozzle).DiIn + 2 * Mem.M(137)
                    Nozzles(kLato, kNozzle).Spess = Mem.M(137)
                Case "LWN1"
                    Nozzles(kLato, kNozzle).HX = Mem.M(137)
            End Select
            If Configwn.TipCalc <> 2 And Not qbflan = -98 And Not VerificandoPI And Config(0).CalcMAWP <> 0 Then
                Call MAWP(3 + nn)
                '   CoperchioAutoRinforzato = True
                If qbflan = -1 Then Exit Function
                Call StamMAWPF(2)
            End If
            If Configwn.TipCalc <> 2 And Config(0).NMWDT > 0 And Not VerificandoPI Then Call MinTempF(-nn)
        Next
        If formTab.Finito = False Then
            Mem.File = ".cop"
            formTab.SetPagina(1)
            formTab.Show()
        End If
        If qbflan = -98 Then qbflan = 0
    End Function
    Private Sub Stampaar(ByRef l As Short, ByRef jB As Short, ByRef Capitolo As Boolean)
        Dim ifl As Short
        If Capitolo Then If Not PrepRapp(Template, "Cop.piano autor.", Involucr(kLato, jInvolucr).Mark.Trim, _
                             FileSt, mioApert.lstRapp, 2) Then Exit Sub
16400:  'stampa coperchio piano auto-rinforzante
        ifl = FreeFile()
        FileOpen(ifl, RTrim(clsInizio.Archdir) & "\WN5\wn_stam1.cob", OpenMode.Input, , OpenShare.Shared)
        'Res = RichSta(jB)
        'Stampaar = Res
        'If Res = -2 Then Close #ifl%: Exit Sub
        Call Sub11(ifl) '(ifl,L)
    End Sub
    Private Sub Stampaap(ByRef l As Short, ByRef jB As Short, ByRef Capitolo As Boolean)
        Dim ifl As Short
        Dim File As String
        If Capitolo Then If Not PrepRapp(Template, "Rinf.Ap.Cop.", Nozzles(kLato, jB).Mark + " su " + Involucr(kLato, jInvolucr).Mark.Trim, FileSt, mioApert.lstRapp, 2) Then Exit Sub
        'stampa coperchio piano con apertura rinforzata
        ifl = FreeFile()
        File = RTrim(clsInizio.Archdir) & "\WN5\wn_stam2.cob"
        If Not OpenFile(File, ifl) Then Exit Sub
        Call Sub11(ifl, True) '%, L)
    End Sub
    Private Sub CoorBuc1(ByRef PunPia() As RoutBase1.clsVec2)
        Dim j, jj As Short
        For j = Involucr(kLato, jInvolucr).inizio To Involucr(kLato, jInvolucr).Fine
            jj = j - Involucr(kLato, jInvolucr).inizio
            If SistCoorCop = 0 Then
                PunPia(jj).X = Nozzles(kLato, j).DTL * Math.Cos(Nozzles(kLato, j).Anomal * pi / 180)
                PunPia(jj).y = Nozzles(kLato, j).DTL * Math.Sin(Nozzles(kLato, j).Anomal * pi / 180)
            Else
                PunPia(jj).X = Nozzles(kLato, j).DCL
                PunPia(jj).y = Nozzles(kLato, j).DTL
            End If
        Next
    End Sub
    Public Function OptimTir() As Boolean
        OptimTir = True
        qbflan = 0
        Mem.M(14) = 0
        If TipCalc = 3 Then
            If Not RilBull1() Then OptimTir = False
        Else
            Carichi(LoadCond, 0)
            SupCalcola() 'GoSub 6000 riesegui tutto il calcolo
        End If
        If qbflan = -99 Then OptimTir = False
    End Function

    Private Function Stampacob(ByRef nn As Short, ByRef Capitolo As Boolean) As Boolean
        Dim FileFor As Str50
        Stampacob = True
        Mem.COID = Involucr(kLato, jInvolucr).Mark
        Mem.COMA = Matdim(Involucr(kLato, jInvolucr).indice(0)).MatStr 'da qui
        Call PrepRapp(Template, "Apertura su coperchio", Nozzles(kLato, nn).Mark, FileSt, mioApert.lstRapp)
        If div = 1 Then
            Call BraPrint(nn, jInvolucr, False, 0, 0, 0, "", 0, 0.0#)
            FileFor.Str_Renamed = RTrim(clsInizio.DiscoRam) & "ROTFLFOR.OUT"
            OPPRI(Nozzles(kLato, nn), FileFor)
            Stamparo("", FileFor.Str_Renamed)
        Else
            If Not BranchesCal(0, 0, 0, 0, 0, 0, 0, 0, 1, 0, nn, jInvolucr, False, True) Then Stampacob = False : Exit Function
            Mem.NOID = Nozzles(kLato, nn).Mark
            If CoperchioAutoRinforzato Then
                Stampaar(0, nn, Capitolo)
            Else
                Stampaap(0, nn, Capitolo)
            End If
        End If
    End Function
    Public Sub AzzeraImposti()
        Dim kAcc, jAcc As Short
        Dim Accoppiato As wn_flan = Nothing
        Dim AccoppiatoPT As wn_PT = Nothing 'devono stare così
        If Mem.LOOSE = 5 Or Mem.LOOSE = 6 Then Exit Sub
        kAcc = Involucr(kLato, jInvolucr).AccoppK
        jAcc = Involucr(kLato, jInvolucr).AccoppJ
        If kAcc = 0 Or jAcc = 0 Then Exit Sub
        'If Involucr(kAcc, jAcc).Tipo = 6 Then 'Piastra Tubiera
        '   Exit Sub
        'End If
        With Mem
            .M(33) = 0 : .M(34) = 0
            .Z(33) = 0 : .Z(34) = 0
            .M(193) = 0 : .M(194) = 0
            .Z(193) = 0 : .Z(194) = 0
        End With
        If jAcc = 0 Then Exit Sub
        If Involucr(kAcc, jAcc).IndObject > 0 Then
            If Involucr(kAcc, jAcc).Tipo = 6 Then
                AccoppiatoPT = objMemb(Involucr(kAcc, jAcc).IndObject)
            Else
                Accoppiato = objMemb(Involucr(kAcc, jAcc).IndObject)
            End If
        End If
        If Not Accoppiato Is Nothing Then
            With Accoppiato
                .Mp(33) = 0 : .Mp(34) = 0
                .Zp(33) = 0 : .Zp(34) = 0
                .Mp(193) = 0 : .Mp(194) = 0
                .Zp(193) = 0 : .Zp(194) = 0
            End With
        End If
        If Not AccoppiatoPT Is Nothing Then
            With AccoppiatoPT
                If kLato = 1 Then
                    .FlShelDati(18) = 0
                Else
                    .FlChanDati(18) = 0
                End If
            End With
        End If
    End Sub
    Public Sub AzzeraConferme()
        ConfermaCP = False
        ConfermaBS = False
        ConfermaDR = False
        ConfermaDE = False
        ConfermaLG = False
        ConfermaST = False
        ConfermaSG = False
    End Sub

    Private Sub PulisciAsterischi()
        Dim i, n As Short
        For i = 1 To 200
            n = InStr(CVARI(i), "*")
            If n > 1 Then CVARI(i) = Left(CVARI(i), Len(CVARI(i)) - 1)
        Next
    End Sub

    Public Sub RichiaTir()
        If Tira Is Nothing Then Tira = New LibMat.clsTira
        Tira.Xfil = Mem.XFil
        If Mem.M(14) > 0 Then
            Tira.Diam = Mem.M(14)
            Tira.Cerca("Diam")
        Else
            Tira.DN = Mem.TIR
            Tira.CercaDN()
        End If
        If Not ContinuoAuto Then Tira.Scelta(clsInizio.Archdir, clsInizio.DiscoTem)
        Mem.XFil = Tira.Xfil
        Mem.TIR = Tira.DN
        With Mem
            .M(14) = GlobalRoutines.ValVir(CStr(Tira.Diam))
            .M(20) = Tira.BSmin
            .M(18) = Tira.Rmin
            .M(16) = Tira.Emin
            .M(15) = Tira.foro
            .M(160) = Tira.Dnom
            .Z(12) = 1 : .M(12) = 1
            .Z(14) = .M(14) / inc
            .Z(20) = .M(20) / inc
            .Z(18) = .M(18) / inc
            .Z(16) = .M(16) / inc
            .Z(15) = .M(15) / inc
            .Z(160) = .M(160) / inc
        End With
    End Sub

    Public Sub AggiornaGuar(ByRef g As LibMat.clsGuarn)
        With Mem
            .Gasket = g.ClassS
            .GasMat = g.TipoS
            .M(161) = g.Class : .M(162) = g.Tipo
            .M(163) = g.Face
            .Z(28) = g.y : .M(28) = .Z(28) * mpa
            .Z(30) = g.m : .M(30) = .Z(30)
            .Z(31) = g.Formula : .M(31) = .Z(31)
            If .M(161) = 1 And .M(162) >= 2 And .M(162) <= 4 Then
                .M(201) = g.Alfa : .Z(201) = .M(201)
                .M(202) = g.Radius : .Z(202) = .M(202) / inc
                .M(203) = g.Height : .Z(203) = .M(203) / inc
            End If
            If .M(161) = 14 Or .M(161) = 15 Or .M(161) = 16 Then 'diaframma elastico / labbra saldate / omega
                .M(202) = g.Radius : .Z(202) = .M(202) / inc
                .M(203) = g.Height : .Z(203) = .M(203) / inc
            End If
        End With
    End Sub

    Private Sub SetCarLoad()
        Dim I11 As Short
        If LoadCond = 1 Then
            '             m(172) = m(22): m(172) = m(23)    'flangia
            '             m(171) = m(24): m(171) = m(25)    'bulloni
            '             m(181) = m(122): m(181) = m(123)    'coperchio
            '???             M(179) = M(141): M(180) = M(142)    'bocchelli
        ElseIf LoadCond = 2 Then  'design
            '             m(175) = m(22): m(176) = m(23)    'flangia
            '             m(173) = m(24): m(174) = m(25)    'bulloni
            '             m(177) = m(122): m(178) = m(123)    'coperchio
            '             m(179) = m(141): m(180) = m(142)    'bocchelli
            I11 = 11 : If Mem.LOOSE = 5 Or Mem.LOOSE = 6 Then I11 = 12
            If AddDistinta = 0 Then
                ' MenuSetState 2, 8, 1
                With Mem
                    If Configwn.LatoProgetto = 1 Then
                        If DatProg.UniMis = 1 Then
                            DatProg.PressTubi = .M(1) : DatProg.TempTubi = .M(2)
                            DatProg.PHyTubi = .M(1) * RappPI()
                            DatProg.CorrTubi = .M(I11)
                        Else
                            DatProg.PressTubi = .Z(1) : DatProg.TempTubi = .Z(2)
                            DatProg.PHyTubi = .Z(1) * RappPI()
                            DatProg.CorrTubi = .Z(I11)
                        End If
                    Else
                        If DatProg.UniMis = 1 Then
                            DatProg.PressMant = .M(1) : DatProg.TempMant = .M(2)
                            DatProg.CorrMant = .M(I11)
                        Else
                            DatProg.PressMant = .Z(1) : DatProg.TempMant = .Z(2)
                            DatProg.CorrMant = .Z(I11)
                        End If
                    End If
                End With
            End If
        End If

    End Sub
End Class