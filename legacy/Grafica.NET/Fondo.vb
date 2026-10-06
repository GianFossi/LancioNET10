Option Strict Off
Option Explicit On
Imports System.Math
Imports RoutBase1
<Serializable()> Public Class Fondo
    Inherits Membratura
    Public AF As Single '????????
    Private prDiametro As Single
    Public Piedritto As Single
    Private prSpessBase As Single
    Public SpessRive As Single
    Public Dcal As Single
    Public Ddis As Single
    Public Dqua As Single
    Public SpessPar As Single
    '    Public TipoMat As Short '1,2,3,4
    Public TipOPT As Short
    Public SpessCal As Single
    Public NumSpicchi As Short
    Public SovraApe As Single
    Public kRapporto As Single
    Public PreSald As Short '0 non definito, 1 presaldato, 2 a spicchi
    Public ForoCentrale As Boolean
    '----------------------
    '   Public GenMem As clsGenMem
    '  Public Variato As Boolean
    Public Spicchiat As Spicchi
    Private Formafuori As Boolean
    Public Enum FondoPresaldato
        NonDefinito = 0
        PreSaldato = 1
        APetali = 2
        PezzoUnico = 3
        PreSaldSuUnQuadro = 4
        PreSaldSuDueQuadri = 5
    End Enum
    Public Overrides Property SpessBase() As Single
        Get
            Return prSpessBase
        End Get
        Set(ByVal Value As Single)
            prSpessBase = Value
        End Set
    End Property
    Public Overrides Property Diametro() As Single
        Get
            Return prDiametro
        End Get
        Set(ByVal Value As Single)
            prDiametro = Value
        End Set
    End Property
    Public Overloads Sub leggi(ByVal DiscoR As String, ByVal Mode As Short)
        Select Case Mode
            Case 0
                If Not Variato Then Exit Sub
                Call Aggancio(DiscoR)
                GenMem.LeggiMat((TipoMat))
                GenMem.PesiSp((TipoMat))
                SovraMet()
                GenMem.TAGLIO = GenMem.MargTag(SpessBase)
                ' If Caricamento Then
                Calcoli(-1)
                ' Else
                '  Calcoli 1
                ' End If
                Pesi()
                GenMem.Leggiprezzi(Int(SpessPar - SpessRive), Int(SpessRive), 0)
                StringDIME()
                StringMATE()
                StringNOTE()
                CalcGrezzi()
                Variato = False
            Case 1
                Membro = Me
                FormDati.ShowDialog()
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
    Private Sub SovraMet()
        Select Case GenMem.Classe2
            Case 2
                Select Case SpessBase + SpessRive
                    Case Is < 21 : SpessPar = SpessBase + SpessRive + 1
                    Case Is < 41 : SpessPar = SpessBase + SpessRive + 2
                    Case Is < 76 : SpessPar = SpessBase + SpessRive + 3
                    Case Else : SpessPar = SpessBase + SpessRive + 4
                End Select
            Case 0, 9
                Select Case SpessBase + SpessRive
                    Case Is < 21 : SpessPar = SpessBase + 1
                    Case Is < 41 : SpessPar = SpessBase + 2
                    Case Is < 76 : SpessPar = SpessBase + 3
                    Case Else : SpessPar = SpessBase + 4
                End Select
        End Select
    End Sub

    Private Sub Calcoli(Optional ByRef Mode As Short = 0)
        Dim SpessTot, Rapp, DM As Single
        Dim x, Ri, Alfa As Single
        Dim Rtoro, Rcal As Single
        Dim Ris As Short
        Dim SvilCal, QuadCal As Single
        Dim Testo As String
        Select Case GenMem.Tipo
            Case 3, 4 : If SovraApe = 0 Then SovraApe = 1
                If SovraApe > 10 Then SovraApe = 1
            Case 5 : If SovraApe = 0 Then SovraApe = SpessPar
                If SovraApe < SpessPar Then SovraApe = SpessPar
        End Select
        If NumSpicchi = 0 And Editing And Not Caricamento And Mode > 0 Then
            NumSpicchi = NumSpicGen(Formafuori, "Formatura fondi", SovraApe, NumSpicchi)
        End If
Rifai:
        If NumSpicchi = 0 Then
            Dcal = 0
            If SpessBase = 0 Then Exit Sub
            Select Case GenMem.Classe2
                Case 0, 9 : SpessTot = SpessBase
                Case 2 : SpessTot = SpessBase + SpessRive
            End Select
            Rapp = Diametro / SpessBase
            Select Case GenMem.Tipo
                Case Is < 5
                    Select Case Rapp
                        Case Is < 20 : SpessPar = SpessTot * 1.15
                        Case Else : SpessPar = SpessTot * 1.05
                    End Select
                Case Else
                    Select Case Rapp
                        Case Is >= 12 : SpessPar = 1.15 * SpessTot
                        Case Is >= 10.5 : SpessPar = 1.16 * SpessTot
                        Case Is >= 9.5 : SpessPar = 1.175 * SpessTot
                        Case Is >= 8 : SpessPar = 1.19 * SpessTot
                        Case Else : SpessPar = 1.22 * SpessTot
                    End Select
            End Select
            SpessPar = CShort(SpessPar)
            DM = Diametro + SpessPar
            Select Case GenMem.Tipo
                Case 3
                    Ddis = Int(DM * 1.216 + 2 * Piedritto) + 1
                    Dqua = Int(Ddis * 1.025) + 1
                Case 4
                    Ddis = Int(DM * 1.145 + 2 * Piedritto) + 1
                    Dqua = Int(Ddis * 1.025) + 1
                Case 5
                    Ddis = Int(DM * 1.57 - 2 * Piedritto) + 1 'Int(Sqr(2) * (DM - Sqr(Abs(DM / 2 * Piedritto)))) + 1
                    Dqua = Int(DM * 1.5 + 70) + 1
            End Select
            If job Is Nothing Then Exit Sub
            If Dqua > job.Comm.LargM And Editing And Not Caricamento And PreSald = 0 Then
                '               Testo = "Il lato del quadrotto di partenza (" + Str$(Dqua) + " mm)," + vbCrLf
                '       Testo = Testo + "per un disco di partenza D=" + Str$(Ddis) + " mm)," + vbCrLf
                '       Testo = Testo + "è superiore alla larghezza della lamiera (" + Str$(job.Comm.LargM) + ")." + vbCrLf
                '       Testo = Testo + "Vuoi adottare la soluzione presaldata (Si)," + vbCrLf
                '       Testo = Testo + "o vuoi adottare una soluzione a petali (No)?"
                GlobalRoutines.FormatS("non|")
                Testo = GlobalRoutines.FormatS(HelpStringa(IDHG.IDH_ERR_NOLAMQUAD), Dqua, Ddis, job.Comm.LargM)
                Testo = Inizio.ConvertiCr(Testo)
                If MostraAiuto(IDHG.IDH_ERR_NOLAMQUAD, ChiaviMess.MessQuestion + ChiaviMess.MessYesNo, Testo) = ChiaviMess.MessSi Then
                    PreSald = FondoPresaldato.PreSaldato ' 1
                Else
                    PreSald = FondoPresaldato.APetali ' 2
                    NumSpicchi = 4
                End If
            End If
            If NumSpicchi > 0 Then GoTo Rifai
        Else
            PreSald = FondoPresaldato.PezzoUnico ' False
            If NumSpicchi = 1 Then NumSpicchi = 2
            If Not ForoCentrale Then
                Select Case GenMem.Tipo
                    Case 3, 4
                        Dcal = Int(Diametro * 0.8)
                        SpessCal = SpessBase
                    Case 5
                        Ri = Diametro / 2
                        x = Piedritto / Ri
                        Alfa = System.Math.Atan(x / System.Math.Sqrt(1 - x * x))
                        Dcal = Int((Ri * System.Math.Sin(0.5236 - Alfa)) * 2)
                        SpessCal = SpessBase
                End Select
            End If
            DM = Diametro + SpessPar
            Select Case GenMem.Tipo
                Case 3
                    'sina=(Rc-r)/(R-r)
                    'h=R-(R-r)cosa=R-sqr((R-r)^2-(Rc-r)^2)=R-sqr(R^2-2rR-Rc^2+2rRc)
                    '=.85-sqr(.85^2-2*.161*.85-.5^2+.161)=.250167
                    'korbbogen                              .254473
                    Rtoro = Diametro * 0.161 'korbbogen .154 (non dovrebbe essere .146 per avere 2:1?)
                    Ddis = Int(DM * 1.216 + 2 * Piedritto) + 1
                    Rcal = Diametro * 0.85 'korbbogen .8
                Case 4
                    Rtoro = Diametro * 0.1
                    Ddis = Int(DM * 1.145 + 2 * Piedritto) + 1
                    Rcal = Diametro
                Case 5
                    Rtoro = Diametro * 0.5
                    Ddis = Int(DM * 1.57 - 2 * Piedritto) + 1
                    Rcal = Diametro * 0.5
            End Select
            Spicchiat = New Spicchi
            With Spicchiat
                .TAGLIO = GenMem.TAGLIO
                .Rcal = Rcal + SpessPar / 2
                .Rtoro = Rtoro + SpessPar / 2
                .TipFon = GenMem.Tipo
                .Piedritto = Piedritto
                .DM = DM
                .Dcal = Dcal
                .SpessPar = SpessPar
                .Tcal = SpessPar
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto ctype(Membro.Genmem,clsGenmem). Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                Select Case System.Math.Abs(Membro.GenMem.Tipo)
                    Case 3, 4
                        .IncrAlfa = SovraApe
                        .IncrMarg = 0
                    Case 5
                        .IncrAlfa = 0
                        .IncrMarg = SovraApe
                End Select
                .NumSpicchi = NumSpicchi
                .PesoSp1 = GenMem.PesoSp1
                .ConEq()
                SvilCal = .Scal
                QuadCal = SvilCal + 80
                .Qcal = QuadCal
                If Mode = 1 Then
                    Ris = .Spicchiatura(NumSpicchi, TipOPT)
                Else
                    '.ConEq
                    If TipOPT = 0 Then TipOPT = 2
                    '.ForLam .RG, .RP, .AlfaSvilCon / NumSpicchi, .TAGLIO, (NumSpicchi), job.Comm.LargM, job.Comm.LungM, Nrisp, .Sp(TipOPT + 1), TipOPT
                    .PesoSpicchi()
                    '.Ottimizza NumSpicchi, TipOPT
                End If
            End With
            If Ris = -9 Then
                NumSpicchi = 0
                GoTo Rifai
            ElseIf Ris = -1 Then
                Exit Sub
            End If
            If Mode = 1 Then
                Select Case Ris
                    Case -1 'cambia spicchi
                        NumSpicchi = NumSpicGen(Formafuori, "Formatura fondi", SovraApe, NumSpicchi)
                        GoTo Rifai
                    Case -2 'rifai
                End Select
            End If
        End If
    End Sub
    Protected Overrides Sub Finalize()
        GenMem = Nothing
        Spicchiat = Nothing
        MyBase.Finalize()
    End Sub
    Public Overloads Sub Pesi()
        If GenMem.Classe1 = 7 Then PreSald = FondoPresaldato.PezzoUnico ' False
        If GenMem.Classe2 = 9 Then
            GenMem.Pnet0 = (PI / 4 * Ddis ^ 2 - AF) * SpessBase * GenMem.PesoSp1 'fondo riportato senza riporto in un sol pezzo
            GenMem.Pnet1 = (PI / 4 * Ddis ^ 2 - AF) * SpessRive * GenMem.PesoSp2 'riporto su fondoin un sol pezzo
            If ForoCentrale Then
                GenMem.Pnet0 = GenMem.Pnet0 - PI / 4 * Spicchiat.Scal ^ 2 * SpessCal * GenMem.PesoSp1
                GenMem.Pnet1 = GenMem.Pnet1 - PI / 4 * Spicchiat.Scal ^ 2 * SpessRive * GenMem.PesoSp2
            End If
        Else
            GenMem.Pnet0 = (Ddis ^ 2 * PI / 4 - AF) * (SpessBase * GenMem.PesoSp1 + SpessRive * GenMem.PesoSp2) 'fondo semplice o placato in un sol pezzo
            If ForoCentrale And Not Spicchiat Is Nothing Then
                GenMem.Pnet0 = GenMem.Pnet0 - PI / 4 * Spicchiat.Scal ^ 2 * (SpessCal * GenMem.PesoSp1 + SpessRive * GenMem.PesoSp2)
            Else
                ForoCentrale = False
            End If
        End If
        If NumSpicchi = 0 Then
            '*************************************************************************
            '3480 'PESO LORDO FONDO IN UN SOL PEZZO
            If Not GenMem.LavorEst Then
                GenMem.plor0 = (Dqua ^ 2 * SpessPar * GenMem.PesoSp1) 'Peso lordo fondo in un sol pezzo
            Else 'y
                If GenMem.Classe2 = 2 Then
                    GenMem.plor0 = Ddis ^ 2 * PI / 4 * (SpessBase + SpessRive) * GenMem.PesoSp1
                Else 'z
                    GenMem.plor0 = Ddis ^ 2 * PI / 4 * SpessBase * GenMem.PesoSp1
                End If
            End If
        Else 'aa
            '3510 '*************************************************************************
3520:       'PESO LORDO FONDO A SPICCHI
            GenMem.plor0 = Spicchiat.PlCal + Spicchiat.SP(TipOPT + 1).peso ': PLSPI = PLSPI(Tipo)
            If Not ForoCentrale And Dcal > 0 Then GenMem.Pnet0 = GenMem.Pnet0 - (Spicchiat.PnCal / SpessCal) * SpessBase + Spicchiat.PnCal
        End If
        GenMem.Psfri0 = GenMem.plor0 - GenMem.Pnet0
        'GenMem.PNET0 = GenMem.PNET0 * GenMem.Qta
        'GenMem.Psfri0 = GenMem.Psfri0 * GenMem.Qta
        'GenMem.PLOR0 = GenMem.PLOR0 * GenMem.Qta
        If TipoMat = 4 Then
            GenMem.Pnet1 = GenMem.Pnet0 * SpessRive / SpessBase * GenMem.PesoSp2 / GenMem.PesoSp1
            GenMem.Plor1 = GenMem.Pnet1
            GenMem.Psfri1 = 0
        Else
            GenMem.Pnet1 = 0
        End If
        GenMem.PNET = GenMem.Pnet0 + GenMem.Pnet1
    End Sub

    Public Sub StringDIME()
        Dim Note(20) As String
        If ForoCentrale Then SpessCal = 0
        Note(4) = Str(Diametro)
        Note(6) = Str(SpessBase)
        Note(7) = Str(SpessRive)
        If NumSpicchi > 0 Then
            If SpessRive <> 0 And GenMem.Classe2 = 2 Then
                If SpessCal > SpessPar Then
                    Note(2) = "Di" & Note(4) & " sp." & Note(6) & "+" & Note(7) & " /" & Str(SpessCal - SpessRive) & "+" & Mid(Str(SpessRive), 2, Len(Str(SpessRive)) - 1) & " h." & Str(Piedritto)
                Else 'bb
                    Note(2) = "Di" & Note(4) & " sp." & Note(6) & "+" & Note(7) & " /" & Note(6) & "+" & Mid(Str(SpessRive), 2, Len(Str(SpessRive)) - 1) & " h." & Str(Piedritto)
                End If
            Else 'cc
                Note(2) = "Di" & Note(4) & " sp." & Note(6) & " /" & Note(6) & " h." & Str(Piedritto)
                If ForoCentrale Or Dcal = 0 Then Note(2) = "Di" & Note(4) & " sp." & Note(6) & "+" & Note(7) & " /no calotta h." & Str(Piedritto)
            End If
        Else 'dd
            If SpessCal > SpessPar Then
                Note(2) = "Di" & Note(4) & " sp." & Note(6) & " /" & Str(SpessCal) & " h." & Str(Piedritto)
            Else 'ee
                Note(2) = "Di" & Note(4) & " sp." & Note(6) & " /" & Note(6) & " h." & Str(Piedritto)
                If ForoCentrale Or Dcal = 0 Then Note(2) = "Di" & Note(4) & " sp." & Note(6) & " /no calotta  h." & Str(Piedritto)
            End If
        End If
        If Len(Note(2)) < 51 Then Note(2) = Chr(32) & Note(2) & New String(Chr(32), 51 - Len(Note(2))) & Chr(32) Else Note(2) = Chr(32) & Mid(Note(2), 1, 51) & Chr(32)
        GenMem.Dimensioni = Note(2)
    End Sub
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
    Private Sub StringNOTE()
        Dim Riga As String = ""
        If NumSpicchi > 0 Then
            Riga = "N°SETTORI" & Str(NumSpicchi) & " tipo trac." & Str(TipOPT)
        Else 'ii
            If Not PreSald = FondoPresaldato.PezzoUnico Then
                If SpessPar <> 0 And SpessPar <> SpessBase Then Riga = "LAMIERA" & Str(Dqua) & " x" & Str(Dqua) & " x" & Str(SpessPar)
            Else 'jj
                If SpessPar <> 0 And SpessPar <> SpessBase Then Riga = "LAMIERA" & Str(Dqua) & " x" & Str(Dqua) & " x" & GlobalRoutines.myStr(CSng(SpessPar), 3, 0, True) & " presald."
            End If
        End If
        If Len(Riga) >= 32 Then Riga = Mid(Riga, 1, 32) Else Riga = Riga & New String(Chr(32), 32 - Len(Riga))
        GenMem.Note = Riga
    End Sub
    Public Overloads Sub CalcGrezzi()
        Dim grezzo As New clsGrezzo1
        Dim x As Integer
        Dim grezzo1 As New clsGrezzo1
        Dim Stringa(2) As String
        Dim Nrisp As Short
        GenMem.ClearGrezzi()
        GenMem.IniziaGrezzo(grezzo)
        If grezzo Is Nothing Then Exit Sub
        grezzo.Variab(1) = SpessPar 'Spicchi.Tcal
        If GenMem.Classe2 = 2 Then
            grezzo.Variab(2) = SpessRive
            grezzo.Variab(3) = GenMem.IndMat2
        End If
        If NumSpicchi > 0 Then
            If Not ForoCentrale Or Dcal = 0 Then
                grezzo.Variab(1) = Spicchiat.Tcal
                grezzo.Vartxt(1) = "DI  "
                grezzo.Dimens(1) = Spicchiat.Qcal
                grezzo.Dimens(2) = Spicchiat.Qcal
                grezzo.Dimens(3) = 1 'N. quadri
                grezzo.Variab(5) = 0
                GenMem.IniziaGrezzo(grezzo)
            End If
            grezzo.Variab(1) = SpessPar
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
                        grezzo.Variab(1) = SpessPar
                        grezzo.Vartxt(1) = "SP  "
                        grezzo.Dimens(1) = Spicchiat.SP(1).Rettn.Lung
                        grezzo.Dimens(2) = Spicchiat.SP(1).Rettn.LARG
                        grezzo.Dimens(3) = 1 'n. quadri
                        grezzo.Variab(2) = Spicchiat.RG
                        grezzo.Variab(3) = Spicchiat.RP
                        grezzo.Dimens(4) = Spicchiat.AlfaSvilCon / Spicchiat.NumSpicchi
                        grezzo.Variab(4) = 0
                        grezzo.Variab(5) = NumSpicchi 'serve per ricalcolare l'angolo
                    End If
            End Select
        Else 'oo
            grezzo.Vartxt(1) = "DI  "
            grezzo.Dimens(1) = Dqua
            grezzo.Dimens(2) = Dqua
            grezzo.Dimens(3) = 1 'N.quadri
            grezzo.Dimens(4) = 0 'Tipo spicchiatura
            grezzo.Variab(5) = 0 'disco intero
            If PreSald = FondoPresaldato.PreSaldato Then
                'grezzo.Variab(5) = 2 'NSPI:due spicchi
                Stringa(1) = "Sullo stesso quadro"
                Stringa(2) = "Su quadri separati"
                Monitor.Motore.ProgrVisible = False
                System.Windows.Forms.Application.DoEvents()
                x = Monitor.Motore.Quale(2, "Disposizione semidischi", Stringa, "", 1)
                Monitor.Motore.ProgrVisible = True
                If x = 1 Then
                    Spicchiat = New Spicchi
                    ForLam(Dqua / 2, 0, PI, (GenMem.TAGLIO), 2, job.Comm.LargM, job.Comm.LungM, Nrisp, Spicchiat.SP(1), 4)
                    grezzo.Dimens(1) = Spicchiat.SP(1).Rettn.Lung
                    grezzo.Dimens(2) = Spicchiat.SP(1).Rettn.LARG
                    'grezzo.Dimens(3) = 1 'N.quadri
                    grezzo.Variab(5) = 4 'Tipo spicchiatura'due spicchi su stesso quadro
                    PreSald = FondoPresaldato.PreSaldSuUnQuadro
                Else
                    grezzo.Dimens(2) = Dqua / 2
                    'grezzo.Dimens(3) = 2 'N.quadri
                    'grezzo.Dimens(4) = 2 'Tipo
                    grezzo.Variab(5) = 2 'due quadri con semidisco
                    GenMem.IniziaGrezzo(grezzo1)
                    grezzo.Copia(grezzo1)
                    PreSald = FondoPresaldato.PreSaldSuDueQuadri
                End If
            End If
        End If
        Select Case TipoMat
            Case 3 ' WO
                GenMem.IniziaGrezzo(grezzo)
                grezzo.Vartxt(1) = "WO  "
                GenMem.WOGrezzo(grezzo)
        End Select
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
    Public Overloads Sub Copia(ByRef A As Fondo)
        If A Is Nothing Then A = New Fondo
        A.AF = AF
        A.Diametro = Diametro
        A.Piedritto = Piedritto
        A.SpessBase = SpessBase
        A.SpessRive = SpessRive
        A.Dcal = Dcal
        A.Ddis = Ddis
        A.Dqua = Dqua
        A.SpessPar = SpessPar
        A.TipoMat = TipoMat
        A.TipOPT = TipOPT
        A.SpessCal = SpessCal
        A.NumSpicchi = NumSpicchi
        A.SovraApe = SovraApe
        A.kRapporto = kRapporto
        A.ForoCentrale = ForoCentrale
        '----------------------
        GenMem.Copia(A.GenMem)
        A.GenMem.Parent = A
        If Not Spicchiat Is Nothing Then Spicchiat.Copia(A.Spicchiat)
    End Sub
    Public Overrides Sub Mostrasviluppi()
        Funzioni.DisRut.DoveDisegno = frmShowForm.DefInstance.pctForm
        Calcoli(1)
        Pesi()
    End Sub
    Public Overrides Function NumSpic(ByRef NumSpicchi As Short) As Short
        NumSpicchi = NumSpicGen(Formafuori, "Fondi a spicchi", SovraApe, NumSpicchi)
        NumSpic = NumSpicchi
    End Function
End Class