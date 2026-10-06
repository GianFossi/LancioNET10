Option Strict Off
Option Explicit On
Imports System.Math
<Serializable()> Public Class Flangione
    Inherits Membratura
    Private prSottoTipo As Short
    Private prDiamExt As Single '   .Adim = Dati(1)
    Private prDiamInt As Single '   .b = Dati(2)
    Public DiamGra As Single '    .DG = Dati(3)
    Private prSpessBase As Single '   .t = Dati(4)
    Public SpessRive As Single '   .T1 = Dati(9)
    Public SpessGra As Single '      .SpessGra = Dati(5)
    Public g0 As Single '      .G0 = Dati(6)
    Public g1 As Single '      .G1 = Dati(7)
    Public H As Single '      .H = Dati(8)
    Public DiamGra2 As Single '      .D = Dati(11)
    Public SpessGra2 As Single ' .T2 = Lungo \ 500
    Public g02 As Single ' .B1 = Lungo \ 500
    Public g12 As Single ' .B2 = Lungo \ 500
    Public H2 As Single ' .H1 = Lungo \ 500
    'Public TipoMat As Short '1,2,3,4
    Public kLam As Short 'da lamiera, 1 quadrotto, 2 anello cilindrato
    '----------------------
    'Public GenMem As clsGenMem
    'Public Variato As Boolean
    <NonSerialized()> Private Mom As Single
    <NonSerialized()> Private G1G, TG, AG, BG, G0G, HG As Single
    Public Overrides Property SpessBase() As Single
        Get
            Return prSpessBase
        End Get
        Set(ByVal Value As Single)
            prSpessBase = Value
        End Set
    End Property
    Public Overrides Property SottoTipo() As Short
        Get
            Return prSottoTipo
        End Get
        Set(ByVal Value As Short)
            prSottoTipo = Value
        End Set
    End Property
    Public Overrides Property Diamint() As Single
        Get
            Return prDiamInt
        End Get
        Set(ByVal Value As Single)
            prDiamInt = Value
        End Set
    End Property
    Public Overrides Property Diamext() As Single
        Get
            Return prDiamExt
        End Get
        Set(ByVal Value As Single)
            prDiamExt = Value
        End Set
    End Property
    Public Overrides Sub StringMATE()
        Dim M1, M0, Riga As String
        Dim i As Short
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
    End Sub
    Public Overloads Sub leggi(ByVal DiscoR As String, ByVal Mode As Short)
        Select Case Mode
            Case 0
                If Not Variato Then Exit Sub
                Call Aggancio(DiscoR)
                GenMem.LeggiMat((TipoMat))
                GenMem.PesiSp((TipoMat))
                Pesi()
                GenMem.Leggiprezzi(Int(Param1), Int(Param2), 0, Code7)
                StringDIME()
                StringMATE()
                StringNOTE()
                CalcGrezzi()
                Variato = False
                'Mode=0 ricalcolo,=1 editaggio
            Case 1
                Membro = Me
                FormDati.ShowDialog()
        End Select
        ' SalvaLav
    End Sub
    Public Overloads Sub Pesi()
        Dim Pes As Single
        'Peso netto
        GenMem.Pnet0 = (Diamext * Diamext - Diamint * Diamint) * PI / 4 * SpessBase
        Mom = GenMem.Pnet0 * (H + SpessBase / 2)
        Select Case SottoTipo
            Case 1
                Pes = (DiamGra * DiamGra - Diamint * Diamint) * (PI / 4) * SpessGra
                Mom = Mom + Pes * (H + SpessBase + SpessGra / 2)
                GenMem.Pnet0 = GenMem.Pnet0 + Pes
                Pes = (Diamint + g0) * PI * g0 * H
                Mom = Mom + Pes * H / 2
                GenMem.Pnet0 = GenMem.Pnet0 + Pes
                Pes = ((g1 - g0) * H / 2) * (Diamint + 2 * g0 + ((g1 - g0) / 1.5)) * PI
                Mom = Mom + Pes * H / 1.5
                GenMem.Pnet0 = GenMem.Pnet0 + Pes
                '      GenMem.PNET0 = GenMem.PNET0 - (csng(DB) ^ 2) * (PI / 4) * SpessBase * NB
            Case 2
                Pes = (Diamext ^ 2 - DiamGra ^ 2) * PI / 4 * SpessGra
                Mom = Mom + Pes * (H + SpessBase + SpessGra / 2)
                GenMem.Pnet0 = GenMem.Pnet0 + Pes
                Pes = (Diamint + g0) * PI * g0 * H
                Mom = Mom + Pes * H / 2
                GenMem.Pnet0 = GenMem.Pnet0 + Pes
                Pes = (g1 - g0) * H / 2 * (Diamint + 2 * g0 + (g1 - g0) / 1.5) * PI
                Mom = Mom + Pes * H / 1.5
                GenMem.Pnet0 = GenMem.Pnet0 + Pes
                '      GenMem.PNET0 = GenMem.PNET0 - (csng(DB) ^ 2) * (PI / 4) * (SpessBase + SpessGra) * NB
            Case 3
                Pes = (Diamext ^ 2 - DiamGra ^ 2) * PI / 4 * SpessGra
                Mom = Mom + Pes * (H + SpessBase + SpessGra / 2)
                GenMem.Pnet0 = GenMem.Pnet0 + Pes
                Pes = (Diamext - g0) * PI * g0 * H
                Mom = Mom + Pes * H / 2
                GenMem.Pnet0 = GenMem.Pnet0 + Pes
                Pes = (((g1 - g0) * H) / 2) * (Diamint + 2 * g0 + (g1 - g0) / 1.5) * PI
                Mom = Mom + Pes * H / 1.5
                GenMem.Pnet0 = GenMem.Pnet0 + Pes
                '      GenMem.PNET0 = GenMem.PNET0 - (DB ^ 2) * (PI / 4) * (DB * 1.5) * NB
            Case 4
                MsgBox("caso 4 in Flangione da fare")
        End Select
        If GenMem.Pnet0 Then Mom = Mom / GenMem.Pnet0
        GenMem.Pnet0 = GenMem.Pnet0 * GenMem.PesoSp1
        If TipoMat > 1 Then
            GenMem.Pnet1 = (Diamint * PI * (SpessBase + SpessGra + H)) * SpessRive * GenMem.PesoSp2
        Else
            GenMem.Pnet1 = 0
        End If
        'Peso lordo
        GenMem.Plor1 = GenMem.Pnet1
        'misure grezze
        If GenMem.LavorEst Then
            AG = Diamext + 6
            BG = Diamint - 6
            TG = SpessBase + SpessGra + 6
            G0G = g0 + 6
            G1G = g1 + 6
            HG = H + 6
            GenMem.plor0 = (AG * AG - BG * BG) * PI / 4 * TG
            Select Case SottoTipo
                Case 1, 2
                    GenMem.plor0 = GenMem.plor0 + (BG + G0G) * PI * G0G * HG
                    GenMem.plor0 = GenMem.plor0 + ((G1G - G0G) * HG / 2) * (BG + 2 * G0G + (G1G - G0G) / 1.5) * PI
                Case 3
                    GenMem.plor0 = GenMem.plor0 + (AG - G0G) * PI * G0G * HG
                    GenMem.plor0 = GenMem.plor0 + ((G1G - G0G) * HG / 2) * (AG - 2 * G0G - (G1G - G0G) / 1.5) * PI
            End Select
            GenMem.plor0 = GenMem.plor0 * GenMem.PesoSp1
        Else
            'sovrametalli anello
            If Diamint >= 150 Then
                Select Case Diamext
                    Case Is <= 400
                        AG = 15 : BG = 15 : TG = 10
                    Case Is <= 700
                        AG = 15 : BG = 15 : TG = 15
                    Case Is <= 1000
                        AG = 20 : BG = 20 : TG = 20
                    Case Is <= 1400
                        AG = 25 : BG = 25 : TG = 20
                    Case Is <= 1800
                        AG = 30 : BG = 30 : TG = 25
                    Case Is <= 2200
                        AG = 35 : BG = 35 : TG = 30
                    Case Is > 2200
                        AG = 35 : BG = 35 : TG = 30
                End Select
            Else
                Select Case Diamext
                    Case Is <= 400
                        AG = 15 : TG = 10
                    Case Is <= 700
                        AG = 15 : TG = 15
                    Case Is <= 1000
                        AG = 20 : TG = 20
                    Case Is <= 1400
                        AG = 25 : TG = 20
                    Case Is <= 1800
                        AG = 30 : TG = 25
                    Case Is <= 2200
                        AG = 40 : TG = 30
                    Case Is > 2200
                        AG = 40 : TG = 30
                End Select
            End If
            AG = Diamext + AG : BG = Diamint - BG : TG = (SpessBase + H + SpessGra + TG)
            If GenMem.Classe1 < 7 Then
                '      "ATTENZIONE FLANGIONE DA LAMIERA !!!!!"
                '-------------------------------------------------------------------
                '        If AddDistinta < 103 Then
                '        Stringa(1) = "PESO LORDO DA QUADROTTO"
                '        Stringa(2) = "PESO LORDO DA ANELLO CILINDRATO"
                '        kLam = Quale%(2, "Flangione da lamiera", Stringa(), "Help non disponibile |", 0)
                '        End If
                '------------------------------------------------------------------------
                TG = Int(SpessBase + H + SpessGra + (Diamext / 100)) + 1 : AG = Diamext + 40 : BG = Diamint - 40
                If kLam = 1 Then GenMem.plor0 = AG * AG * TG * GenMem.PesoSp1
                If kLam = 2 Then GenMem.plor0 = (((AG + BG) / 2 * PI) + (2 * TG)) * TG * ((AG - BG) / 2) * GenMem.PesoSp1
            Else
                Select Case Diamext
                    Case Is <= 400
                        If BG > AG - 100 Then BG = AG - 100 : If Diamint < 170 Then BG = 0
                        If AG / TG < 2 Then FuoriLimit()
                    Case Is <= 700
                        If BG > AG - 120 Then BG = AG - 120 : If Diamint < 200 Then BG = 0
                        If AG / TG < 2.5 Then FuoriLimit()
                    Case Is <= 1000
                        If BG > AG - 140 Then BG = AG - 140 : If Diamint < 300 Then BG = 0
                        If AG / TG < 2.8 Then FuoriLimit()
                    Case Is <= 1400
                        If BG > AG - 170 Then BG = AG - 170 : If Diamint < 400 Then BG = 0
                        If AG / TG < 3.2 Then FuoriLimit()
                    Case Is <= 1800
                        If BG > AG - 200 Then BG = AG - 200 : If Diamint < 500 Then BG = 0
                        If AG / TG < 3.5 Then FuoriLimit()
                    Case Is <= 2200
                        If BG > AG - 240 Then BG = AG - 240 : If Diamint < 500 Then BG = 0
                        If AG / TG < 4 Then FuoriLimit()
                    Case Is > 2200
                        If BG > AG - 240 Then BG = AG - 240 : If Diamint < 500 Then BG = 0
                        If AG / TG < 4 And Inizio.AddDistinta <= 102 Then FuoriLimit()
                End Select
                If BG < 0 Or Diamint < 170 Then BG = 0
                If (AG / 10) > TG Then TG = Int(AG / 10) + 1
                GenMem.plor0 = (AG * AG - BG * BG) * PI / 4 * TG * GenMem.PesoSp1
            End If
        End If
        GenMem.Pnet0 = GenMem.Pnet0 * EXP9
        GenMem.plor0 = GenMem.plor0 * EXP9
        GenMem.Psfri0 = GenMem.plor0 - GenMem.Pnet0
        GenMem.Psfri1 = 0
        GenMem.PNET = GenMem.Pnet0 + GenMem.Pnet1
        'PNET0 = PNET0 * NPE: PSFRI = PSFRI * NPE: PLOR0 = PLOR0 * NPE
        '  GenMem.Converti
    End Sub
    Private Sub FuoriLimit()
        Dim Testo As String
        Testo = " Sei fuori dei parametri del fucinato" & Chr(13)
        Testo = Testo & " Vuoi continuare comunque?       "
        MsgBox(Testo, MsgBoxStyle.YesNo)
    End Sub
    Public Sub StringDIME()
        Dim DIME01, DIME02 As String
        DIME01 = "De=" & Str(Diamext) & " Di=" & Str(Diamint)
        DIME02 = " T=" & Str(SpessBase + SpessGra) & " G0/G1=" & Str(g0) & "/" & Str(g1) & " H=" & Str(H)
        If g0 = 0 And g1 = 0 Then
            GenMem.Dimensioni = DIME01 & " T =" & Str(SpessBase + SpessGra)
        Else
            GenMem.Dimensioni = DIME01 & DIME02
        End If
    End Sub
    Public Sub StringNOTE()
        If TipoMat > 1 Then GenMem.Note = "SPESSORE RIPORTO" & Str(SpessRive)
    End Sub
    Public Overloads Sub CalcGrezzi()
        Dim grezzo As New clsGrezzo1
        GenMem.ClearGrezzi()
        GenMem.IniziaGrezzo(grezzo)
        If grezzo Is Nothing Then Exit Sub
        Select Case GenMem.Classe1
            Case 1, 2
                If kLam = 1 Then
                    grezzo.Vartxt(1) = "DI  "
                    grezzo.Variab(1) = TG
                    grezzo.Dimens(2) = AG
                    grezzo.Dimens(1) = AG
                ElseIf kLam = 2 Then  'da anello cilindrato
                    grezzo.Vartxt(1) = "PL  "
                    grezzo.Dimens(1) = (AG - BG) / 2
                    grezzo.Variab(1) = TG
                    grezzo.Dimens(2) = (AG + BG) / 2 * PI + 2 * TG
                End If
            Case 7
                grezzo.Vartxt(1) = "AF  "
                grezzo.Variab(1) = GenMem.plor0
                grezzo.Dimens(1) = AG
                grezzo.Dimens(2) = BG
                grezzo.Variab(2) = HG
        End Select
    End Sub
    'UPGRADE_NOTE: Class_Initialize è stato aggiornato a Class_Initialize_Renamed. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1061"'
    Private Sub Class_Initialize_Renamed()
        GenMem = New clsGenMem
        GenMem.Parent = Me
        Variato = True
    End Sub
    Public Sub New()
        MyBase.New()
        Class_Initialize_Renamed()
    End Sub
    'UPGRADE_NOTE: Class_Terminate è stato aggiornato a Class_Terminate_Renamed. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1061"'
    Private Sub Class_Terminate_Renamed()
        'UPGRADE_NOTE: È possibile che l'oggetto GenMem non venga eliminato finché non venga raccolto nel Garbage Collector. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1029"'
        GenMem = Nothing
    End Sub
    Protected Overrides Sub Finalize()
        Class_Terminate_Renamed()
        MyBase.Finalize()
    End Sub
    Public Overloads Sub Copia(ByRef A As Flangione)
        If A Is Nothing Then A = New Flangione
        A.SottoTipo = SottoTipo
        A.Diamext = Diamext
        A.Diamint = Diamint
        A.DiamGra = DiamGra
        A.SpessBase = SpessBase
        A.SpessRive = SpessRive
        A.SpessGra = SpessGra
        A.g0 = g0
        A.g1 = g1
        A.H = H
        A.DiamGra2 = DiamGra2
        A.SpessGra2 = SpessGra2
        A.g02 = g02
        A.g12 = g12
        A.H2 = H2
        A.TipoMat = TipoMat
        A.kLam = kLam
        '----------------------
        GenMem.Copia(A.GenMem)
        A.GenMem.Parent = A
    End Sub
    Public Overrides Property Spessore() As Single
        Get
            Spessore = SpessBase + SpessRive
        End Get
        Set(ByVal Value As Single)

        End Set
    End Property
    Public Overrides Property Code7() As Short
        Get
            Code7 = 7 '3 Wn, 4 LWN 7 Flangioni
        End Get
        Set(ByVal Value As Short)

        End Set
    End Property
    Public Overrides Property Param1() As Single
        Get
            Param1 = GenMem.plor0
        End Get
        Set(ByVal Value As Single)

        End Set
    End Property
    Public ReadOnly Property Param2() As Single
        Get
            Param2 = SpessRive
        End Get
    End Property
End Class