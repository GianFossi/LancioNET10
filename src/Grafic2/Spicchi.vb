Option Strict Off
Option Explicit On 
Imports System.Math
Imports RoutBase1
<Serializable()> Public Class Spicchi
    Public AF As Single 'che cosa è questo dato?
    Public PesoSp1 As Single
    Public TAGLIO As Single
    Public Rtoro As Single
    Public Rcal As Single
    Public Dcal As Single
    Public PlCal As Single
    Public PnCal As Single
    Public Scal As Single
    Public Tcal As Single
    Public Qcal As Single
    Public TipFon As Short
    Public Piedritto As Single
    Public DM As Single
    Public SpessPar As Single
    Public IncrAlfa As Single
    Public IncrMarg As Single
    Public AlfaSvilCon As Single
    Public NumSpicchi As Short
    Private SP0 As SpicLam
    Private SP1 As SpicLam
    Private SP2 As SpicLam
    Private SP3 As SpicLam
    Private SP4 As SpicLam
    Private SP5 As SpicLam
    Private SP6 As SpicLam
    Private fact As Single
    Private LargM, LungM As Short
    Private Lsald(6) As Single
    Private Numq(6) As Short
    Public RM, RP, RG As Single
    Public Sub ConEq()
        Dim APF, X, AP1, Scon As Single
        Dim DpSfe, DmSfe, DgSfe As Single
        Dim DgCon, DMCON, DpCon As Single
        Dim Alfa1, Svil1, Svilm, Marg As Single
        Dim AlfaP, AlfaPied, AlfaG As Single
        Dim AlfaSpi, AlfaCal, AlfaConEq As Single
        Dim SSPI As Single
        Select Case TipFon
            Case 3, 4
                X = ((DM / 2) - Rtoro) / (Rcal - Rtoro)
                AlfaCal = System.Math.Atan(X / System.Math.Sqrt(1 - X * X))
                Scal = Int(2 * AlfaCal * Rcal) + 1
                AlfaSpi = PI / 2 - AlfaCal
                AlfaConEq = PI / 2 - (AlfaCal + (AlfaSpi / 2)) + IncrAlfa * PI / 180
                AP1 = (Int((2 * AlfaCal * Rcal) - Scal)) / 2 + 1
                If Piedritto >= AP1 Then APF = Piedritto Else APF = AP1
                Scon = AlfaSpi * Rtoro + 2 * APF
                'sviluppo raggio piccolo + 2 volte il colletto effettivo
                DMCON = (Rtoro + Rtoro * System.Math.Cos(AlfaSpi / 2)) * System.Math.Cos(AlfaSpi / 2) + (DM - Rtoro * 2)
                DgCon = (Scon / 2 + SpessPar) * System.Math.Sin(AlfaConEq) * 2 + DMCON
                DpCon = DMCON - Scon / 2 * System.Math.Sin(AlfaConEq) * 2
                RP = (DpCon / 2) / System.Math.Sin(AlfaConEq)
                RM = (DMCON / 2) / System.Math.Sin(AlfaConEq)
                RG = (DgCon / 2) / System.Math.Sin(AlfaConEq)
                'NUOVO-------------------------------------
                DmSfe = Rtoro * System.Math.Cos(AlfaSpi / 2) + (DM - Rtoro * 2)
                Svilm = PI * DmSfe + 2 * NumSpicchi * SpessPar
                AlfaSvilCon = Svilm / RM
                Svil1 = PI * DpCon + 2 * NumSpicchi * SpessPar
                Alfa1 = Svil1 / RP
                If Alfa1 > AlfaSvilCon Then AlfaSvilCon = Alfa1
                '       AlfaSvilCon = ((DGCON / RG) * PI) 'Semiapertura cono 30 gradi
            Case 5
                Marg = SpessPar : If IncrMarg > Marg Then Marg = IncrMarg
                X = Piedritto / Rcal
                AlfaPied = System.Math.Atan(X / System.Math.Sqrt(1 - X * X))
                X = ((System.Math.Abs(Dcal) / 2) / Rcal)
                AlfaCal = System.Math.Atan(X / System.Math.Sqrt(1 - X * X))
                Scal = Int(2 * AlfaCal * Rcal) + 1
                AlfaSpi = PI / 2 - (AlfaPied + AlfaCal)
                AlfaConEq = PI / 2 - (AlfaCal + (AlfaSpi / 2))
                SSPI = Rcal * AlfaSpi / 2 ') 'semisviluppo meridionale « spicchio
                DMCON = ((Rcal + Rcal * System.Math.Cos(AlfaSpi / 2)) * System.Math.Cos(AlfaPied + AlfaSpi / 2))
                DgCon = (((SSPI + 2 * Marg) * System.Math.Sin(AlfaConEq)) * 2) + DMCON
                DpCon = DMCON - ((SSPI + Marg) * System.Math.Sin(AlfaConEq) * 2)
                RP = (DpCon / 2) / System.Math.Sin(AlfaConEq)
                RM = (DMCON / 2) / System.Math.Sin(AlfaConEq)
                RG = (DgCon / 2) / System.Math.Sin(AlfaConEq)
                'NUOVO------------------
                DmSfe = 2 * Rcal * System.Math.Cos(AlfaPied + AlfaSpi / 2)
                Svilm = PI * DmSfe + 2 * NumSpicchi * Marg
                AlfaSvilCon = Svilm / RM
                DpSfe = 2 * Rcal * System.Math.Sin(AlfaCal)
                Svilm = PI * DpSfe + 2 * NumSpicchi * Marg
                AlfaP = Svilm / RP
                If AlfaP > AlfaSvilCon Then AlfaSvilCon = AlfaP
                DgSfe = 2 * Rcal * System.Math.Cos(AlfaPied)
                Svilm = PI * DgSfe + 2 * NumSpicchi * Marg
                AlfaG = Svilm / RG
                If AlfaG > AlfaSvilCon Then AlfaSvilCon = AlfaG
        End Select
    End Sub
    Public Sub New()
        MyBase.New()
        fact = 20
        If IUNL = 5 Or Monitor.Motore.Inizio.LavoriSciolti Then
            LargM = 2500 : LungM = 12000
        Else
            LargM = job.Comm.LargM : LungM = job.Comm.LungM
        End If
        'IniziaSP(SP)
        SP0 = New SpicLam
        SP1 = New SpicLam
        SP2 = New SpicLam
        SP3 = New SpicLam
        SP4 = New SpicLam
        SP5 = New SpicLam
        SP6 = New SpicLam
    End Sub
    Public Sub Ottimizza(ByRef NOpt As Short, ByRef TipOPT As Short)
        Dim SalvaSPI As Short
        Dim Min, Lsald0 As Single
        Dim Mins(6) As Single
        Dim i, j As Short
        Dim jmini(6) As Short
        SalvaSPI = NumSpicchi
        Min = 1.0E+20
        For NumSpicchi = 2 To 6
250:        PesoSpicchi()
            Lsald0 = (PI * Dcal + NumSpicchi * (RG - RP)) * SpessPar * SpessPar * PesoSp1 * fact
            If Dcal = 0 Then Lsald0 = 0 'caso di cono
            For i = 0 To 5
                Lsald(i) = Lsald0 + SP(i + 1).peso + PlCal
            Next i
255:        Mins(NumSpicchi) = 1.0E+20
            For j = 0 To 5
                If Lsald(j) < Mins(NumSpicchi) Then Mins(NumSpicchi) = Lsald(j) : jmini(NumSpicchi) = j
            Next j
            If Mins(NumSpicchi) < Min Then Min = Mins(NumSpicchi) : NOpt = NumSpicchi : TipOPT = jmini(NumSpicchi)
        Next NumSpicchi
        NumSpicchi = SalvaSPI
    End Sub
    Public WriteOnly Property FattoreOttimizz() As Single
        Set(ByVal Value As Single)
            fact = Value
        End Set
    End Property
    Public Sub PesoSpicchi()
        'FORMATO LAMIERA TIPO 0
        '***************************
        Dim Risp, i As Short
        Dim Pesot As Single
        Try
            Call ConEq()
            ForLam(RG, RP, AlfaSvilCon / NumSpicchi, TAGLIO, 1, LargM, LungM, Risp, SP(1), 2)
            Numq(0) = NumSpicchi
            If NumSpicchi = 1 Then
                '         For i = 1 To 5
                '         'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto SP().Remove. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                '         SP(i + 1).Remove(NSpicchi)
                '         'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto SP().Add. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                '         SP.Item(i + 1).Add(0, NSpicchi)
                '         Next
                GoTo ExSub
            End If
            For i = 1 To 5
                ForLam(RG, RP, AlfaSvilCon / NumSpicchi, TAGLIO, (NumSpicchi), LargM, LungM, Risp, SP(i + 1), i)
                If Risp = 0 Then
                    Numq(i) = 0
                    '            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto SP().Remove. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                    '            SP.Item(i + 1).Remove(NSpicchi)
                    '            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto SP().Add. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                    '            SP.Item(i + 1).Add(0, NSpicchi)
                    '            ' substit SP(i + 1)(NSpicchi), 0
                Else
                    Numq(i) = Int(NumSpicchi) \ Risp
                End If
            Next i
            'PESO LORDO CALOTTA E SPICCHI
            '2870 '****************************
            PlCal = PesoSp1 * Qcal ^ 2 * Tcal
280:        PnCal = PesoSp1 * (PI / 4 * Scal ^ 2 - AF) * Tcal
            For i = 0 To 5
                If SP(i + 1).Nspicchi = 0 Then
                    Pesot = 1.0E+20
                Else
                    Pesot = PesoSp1 * SpessPar * SP(i + 1).Rettn.LARG * SP(i + 1).Rettn.Lung * Numq(i)
                    Pesot = Pesot + PesoSp1 * SpessPar * SP(1).Rettn.LARG * SP(1).Rettn.Lung * (NumSpicchi - SP(i + 1).Nspicchi * Numq(i))
                End If
                SP(i + 1).peso = Pesot
            Next i
ExSub:
            For i = 0 To 5
                SP(i + 1).Nquadri = Numq(i)
            Next
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Public Sub Copia(ByRef A As Spicchi)
        If A Is Nothing Then A = New Spicchi
        A.AF = AF
        A.PesoSp1 = PesoSp1
        A.TAGLIO = TAGLIO
        A.Rtoro = Rtoro
        A.Rcal = Rcal
        A.Dcal = Dcal
        A.PlCal = PlCal
        A.PnCal = PnCal
        A.Scal = Scal
        A.Tcal = Tcal
        A.Qcal = Qcal
        A.TipFon = TipFon
        A.Piedritto = Piedritto
        A.DM = DM
        A.SpessPar = SpessPar
        A.IncrAlfa = IncrAlfa
        A.IncrMarg = IncrMarg
        A.AlfaSvilCon = AlfaSvilCon
        A.NumSpicchi = NumSpicchi
        'A.sp As New Collection
        A.RP = RP
        A.RM = RM
        A.RG = RM
    End Sub
    Public Function Spicchiatura(ByRef NOpt As Short, ByRef TipOPT As Short) As Short
        Dim Testo As String
        Dim junk As Integer
        Dim Lsald0 As Single
        Dim i, Ris As Short
        Dim Stringa1(14) As String
        'On Local Error GoTo ErrSpic
        'If AddDistinta = 103 Then
        '   Ottimizza Sp()
        '   junk = 1
        'Else
        Ottimizza(NOpt, TipOPT) 'Sp()
        If NOpt = 0 And TipOPT = 0 Then
            '            SP.Item(1).Remove(NSpicchi)
            '            SP.Item(1).Add(0, NSpicchi)
            Spicchiatura = 0 '"S"
            Exit Function
        End If
        GlobalRoutines.FormatS("non|")
        Testo = GlobalRoutines.FormatS(HelpStringa(IDHG.IDH_SPIC_SCELTAOPT), NOpt, TipOPT)
        '        Testo = "La spicchiatura ottima risulta essere:|"
        'Testo = Testo + "N. spicchi: " + Str(NOpt) + ",Tipo:" + Str$(TipOPT)
        'Testo = Testo + "|Accetti (Si), o vuoi determinare tu la    |"
        'Testo = Testo + "spicchiatura (No)?"
        Testo = Inizio.ConvertiCr(Testo)
        junk = MostraAiuto(IDHG.IDH_SPIC_SCELTAOPT, ChiaviMess.MessYesNo + ChiaviMess.MessQuestion, Testo)
        With frmShowForm.DefInstance
            If junk = ChiaviMess.MessSi Then
                NumSpicchi = NOpt ': Tipo = TipOPT
200:            PesoSpicchi() 'Sp(), Lav(0).LargM, Lav(0).LungM
                Spicchiatura = TipOPT
                Exit Function
            Else
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Membro.NumSpic. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                NumSpicchi = Membro.NumSpic(NumSpicchi)
                If NumSpicchi = 0 Then
                    Spicchiatura = -9
                    Exit Function
                ElseIf NumSpicchi = -1 Then
                    Spicchiatura = -1
                    Exit Function
                End If
                PesoSpicchi() 'Sp(), Lav(0).LargM, Lav(0).LungM
                .Text = CStr(CDbl("Lamieramento ") + Membro.GenMem.Denom)
                Lsald0 = (PI * Dcal + NumSpicchi * (RG - RP)) * SpessPar * SpessPar * PesoSp1 * fact
                For i = 0 To 5
                    Lsald(i) = Lsald0 + SP(i + 1).peso + PlCal
                Next i
                Risultati(Stringa1)
                If SP(1).Nspicchi > 0 Then
                    .cmbScelta.Items.Clear()
                    If NumSpicchi > 1 Then
                        For i = 0 To 5
                            .cmbScelta.Items.Add(Str(i))
                        Next
                    Else
                        .cmbScelta.Items.Add(Str(0))
                    End If
                    .cmbScelta.SelectedIndex = 0
                    Funzioni.DisRut.DoveDisegno = frmShowForm.DefInstance.pctShow
                    ShowLam(Me, 5, TipOPT)
                    .ShowDialog()
                    Ris = .Risult
                    ' Do
                    '   k$ = INPUT$(1)
                    '   If k$ = "C" Or k$ = "c" Then Exit Do
                    '   If k$ = "R" Or k$ = "r" Then Exit Do
                    If Ris >= 0 Then
                        'If Asc(k$) >= 48 And Asc(k$) <= 53 Then
                        If NumSpicchi = 1 Then Ris = 0
                        TipOPT = Ris
                        'If Sp(Tipo).NSpicchi > 0 Or Tipo = 0 Then Exit Do Else Beep: Beep
                    End If
                    'Loop
                End If
                If NumSpicchi < 17 And SP(1).Nspicchi = 0 Then
                    'PRINT "    Prova ad aumentare il numero degli spicchi."
                    'PRINT "      (problemi larghezza formato lamiera)"
                    'Print Stringa1$(12): Print Stringa1$(13)
                    'u$ = INPUT$(1)
                    MostraAiuto(IDHG.IDH_ERR_NOLAMSPIC)
                    MsgBox(Stringa1(12) & vbCrLf & Stringa1(13))
                    'k$ = "C"
                    Ris = -1
                ElseIf NumSpicchi > 16 Then
                    'k$ = "S"
                    Ris = 0
                End If
                Spicchiatura = Ris 'k$
            End If
        End With
    End Function
    Public Sub Risultati(ByRef Stringa1() As String)
        Dim i, ifl As Short
        With frmShowForm.DefInstance
            Dim gpctForm As Drawing.Graphics = Graphics.FromHwnd(.pctForm.Handle)
            gpctForm.Clear(System.Drawing.Color.White)
            .grafics = gpctForm
            .myBrush = New SolidBrush(Color.Green)
            .myBrushW = New SolidBrush(Color.Black)
            .myPen = New Pen(Color.Black)
            .myFont = New Font("Courier New", 8)
            .CarHeight = gpctForm.MeasureString("A", .myFont).Height
            .CarWidth = gpctForm.MeasureString("A", .myFont).Width
            'For i = 5 To 23: LOCATE i, 1, 0: Print String$(80, 32);: Next i: LOCATE 6, 1, 0
            ifl = FreeFile()
300:        FileOpen(ifl, RTrim(Inizio.Archdir) & "\STAM08.DAT", OpenMode.Input, , OpenShare.Shared)
            For i = 1 To 14
                Stringa1(i) = LineInput(ifl)
                '      Stringa1$(i) = Adjust(Stringa1$(i), 67)
            Next
            FileClose(ifl)
            'PRINT "                DIMENSIONI DELLE LAMIERE E PESI LORDI"
            'PRINT "                ====================================="
            'PRINT "                    (Numero di spicchi = "; NSPI; ")"
            .Scrivi(Stringa1(1)) : .Scrivi(Stringa1(2))
            .Scrivi(Stringa1(3), , , , True)
            .Scrivi(Str(NumSpicchi) & ")" & Space(22) & "Costo eq.    Peso")
            'Print Stringa1$(1): Print Stringa1$(2)
            'Print Stringa1$(3); Chr$(32); NSPI; ")"
            If Qcal > 0 Then
                ' PRINT USING "CALOTTA CENTRALE     ##### x ##### mm                    ####### Kg"; QCAL; QCAL; PLCAL
                .Scrivi(GlobalRoutines.FormatS(Stringa1(4), Qcal, Qcal, PlCal * EXP9))
            End If
            If SP(1).Nspicchi > 0 Then
                .Scrivi("")
                'Print:  'PRINT USING "SPICCHI TIPO 0       ##### x ##### mm  Nø###             ####### Kg"; Sp(0).Rett.Lung; Sp(0).Rett.Larg; NSPI; PLSPI(0)
                .Scrivi(GlobalRoutines.FormatS(Stringa1(5), SP(1).Rettn.Lung, SP(1).Rettn.LARG, NumSpicchi, Lsald(0) * EXP9, SP(1).peso * EXP9))
                If NumSpicchi > 1 Then
                    For i = 1 To 5
                        'Print:  'PRINT USING "SPICCHI TIPO #       ##### x ##### mm  Nø###+## tipo 0   ####### Kg"; i; Sp(i).Rett.Lung; Sp(i).Rett.Larg; Sp(i).NSpicchi; NSPI - Sp(i).NSpicchi; PLSPI(i)
                        .Scrivi("")
                        If SP(i + 1).Nspicchi > 0 Then
                            .Scrivi(GlobalRoutines.FormatS(Stringa1(6), i, SP(i + 1).Rettn.Lung, SP(i + 1).Rettn.LARG, Numq(i), NumSpicchi - SP(i + 1).Nspicchi * Numq(i), Lsald(i) * EXP9, SP(i + 1).peso * EXP9))
                        Else
                            .Scrivi(GlobalRoutines.FormatS(Stringa1(14), i))
                        End If
                    Next i
                End If
                '        If APF > 0 Then
                If Piedritto > 0 Then
                    .Scrivi("") ': PRINT USING "Piedritto Reale      ##### mm"; APF
                    .Scrivi(GlobalRoutines.FormatS(Stringa1(7), Piedritto))
                End If
            End If
            .myFont.Dispose()
            .myBrushW.Dispose()
            .myBrush.Dispose()
            .myPen.Dispose()
            gpctForm.Dispose()
            .grafics = Nothing
        End With
    End Sub
    Public Property SP(ByVal i As Integer) As SpicLam
        Get
            Select Case i
                Case 1 : SP = SP0
                Case 2 : SP = SP1
                Case 3 : SP = SP2
                Case 4 : SP = SP3
                Case 5 : SP = SP4
                Case 6 : SP = SP5
                Case 7 : SP = SP6
                Case Else : Return Nothing
            End Select
        End Get
        Set(ByVal Value As SpicLam)
            Select Case i
                Case 1 : SP0 = Value
                Case 2 : SP1 = Value
                Case 3 : SP2 = Value
                Case 4 : SP3 = Value
                Case 5 : SP4 = Value
                Case 6 : SP5 = Value
                Case 7 : SP6 = Value
            End Select
        End Set
    End Property
    Public Sub clsForLam(ByRef RG As Single, ByRef RP As Single, ByRef Alfa As Single, ByRef TAGLIO As Single, _
                      ByRef n As Single, ByRef LaMAX As Short, ByRef LMAX As Short, ByRef Nrisp As Short, _
                      ByRef SP As SpicLam, ByRef Tipo As Short)
        ForLam(RG, RP, Alfa, TAGLIO, n, LaMAX, LMAX, Nrisp, SP, Tipo)
    End Sub
    Sub clsDisegnSP(ByRef Quadro As clsLamQuadr, ByRef LARG As Single, ByRef Mode As Short, ByRef Margin As Single, ByRef i As Short, ByRef j0 As Short, ByRef SP As SpicLam)
        DisegnSP(Quadro, LARG, Mode, Margin, i, j0, SP)
    End Sub
End Class