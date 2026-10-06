Option Strict On
Option Explicit On
Imports System.Math
<Serializable()> Public Class Anello
    Inherits Membratura
    Private prDiamExt As Single
    Private prDiamInt As Single
    Private prSpess As Single
    Public Dmant As Single
    '    Public TipoMat As Short
    '   Public TipoS As Short
    '          5    Pads ?
    Public diGran As Single
    Public deGran As Single 'per pads
    '----------------------
    '  Public GenMem As clsGenMem
    ' Public Variato As Boolean
    Public NumSpicchi As Short
    Public Spicchiat As Spicchi
    Public TipOPT As Short
    'Public TAGLIO     As Single
    Private Sviluppo As Single
    Private prAltezza As Single
    Private x As Single
    Public Overrides Property Spess() As Single
        Get
            Return prSpess
        End Get
        Set(ByVal Value As Single)
            prSpess = Value
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
    Public Overrides Property Diamint() As Single
        Get
            Return prDiamInt
        End Get
        Set(ByVal Value As Single)
            prDiamInt = Value
        End Set
    End Property
    Public Overrides Sub StringMATE()
        Dim M0 As String
        Try
            M0 = GenMem.MaterNome(1).Trim
            If M0 = "" Then M0 = GenMem.Materiale.Trim
            GenMem.Materiale = M0
        Catch
        End Try
    End Sub
    Public Overloads Sub leggi(ByVal DiscoR As String, ByVal Mode As Short)
        Select Case Mode
            Case 0
                If Not Variato Then Exit Sub
                Call Aggancio(DiscoR)
                GenMem.LeggiMat((TipoMat))
                GenMem.PesiSp((TipoMat))
                '  SovraMet
                GenMem.TAGLIO = GenMem.MargTag(Spess)
                Calcoli()
                Pesi()
                GenMem.Leggiprezzi(Int(Spess), 0, 0, Code7)
                StringDIME()
                StringMATE()
                If IUNL < 5 Then CalcGrezzi()
                Variato = False
            Case 1
                Membro = Me
                FormDati.ShowDialog()
        End Select
        SalvaLav()
    End Sub
    Public Sub New()
        MyBase.New()
        GenMem = New clsGenMem
        GenMem.Parent = Me
        TipoMat = 1
        Variato = True
    End Sub
    Protected Overrides Sub Finalize()
        GenMem = Nothing
        Spicchiat = Nothing
        MyBase.Finalize()
    End Sub
    Private Sub Calcoli()
        Dim DiamMed As Single
        Dim y, Z As Single
        Dim Alfa As Single
        Dim Ris As Short
        On Error GoTo ErrCal
        Altezza = (Diamext - Diamint) / 2 'altezza anello
        DiamMed = (Diamext + Diamint) / 2 'diametro medio
        If GenMem.TAGLIO >= (prAltezza / 2) Then x = (DiamMed / 2) - (GenMem.TAGLIO - (prAltezza / 2)) Else x = DiamMed / 2
        If GenMem.TAGLIO = 0 Then x = Diamext / 2 : y = Diamext / 2 : Alfa = PI * 2 ': GoTo 1670
        y = DiamMed / 2 : Z = CSng(System.Math.Sqrt(y * y - x * x))
        Alfa = CSng(System.Math.Atan(Z / x))
        If Alfa > 0 Then Alfa = CSng((PI - Alfa) * 2)
        If Alfa < 0 Then Alfa = System.Math.Abs(Alfa) * 2
        If Alfa = 0 Then Alfa = (PI * 2)
        Sviluppo = (DiamMed / 2) * Alfa 'sviluppo anello
        '*************************************************************
        If Dmant > 0 Then '  anello per pad
            '      If Dmant <= DiamInt And AddDistinta <= 102 Then
            '           junk = Alert(4, Stringa1$(7), 4, 3, 11, 65, at1(33), "", "")
            '           Diametro mantello inferiore diametro bocchello
            '           Gia = True
            '           GoTo RifaiDil
            '      End If
            diGran = Dmant * GlobalRoutines.asin(Diamint / Dmant)
            deGran = diGran + 2 * prAltezza
        Else
            diGran = Diamint
            deGran = Diamext
        End If
        Select Case TipoS
            Case 2
                SpicAn(0)
        End Select
ExSub:  Exit Sub
ErrCal: Resume ExSub
    End Sub
    Public Overloads Function NumSpic(ByRef NumSpicchi As Short) As Short
        NumSpicchi = NumSpicGen(False, "Anelli", 0.0!, NumSpicchi)
        NumSpic = NumSpicchi
    End Function
    Private Sub SpicAn(ByRef Mode As Short) '(Sp() As LamSpicchi, SPESS As Integer)
        Dim Ris, nset, Nrisp As Short
        If Editing And Not Caricamento Then
            nset = NumSpicGen(False, "Anelli", 0.0!, NumSpicchi)
            If nset < 2 Then nset = 2
            NumSpicchi = nset
        Else
            nset = NumSpicchi
        End If
        Spicchiat = New Spicchi
        '        Alfaa! = Alfa!
        '        PesoSp1 = Matdim(0).PSP * EXP9: TF = SPESS
        With Spicchiat
            .TAGLIO = GenMem.TAGLIO
            .RG = Diamext / 2
            .RP = Diamint / 2
            '.Rcal = Rcal + SpessPar / 2
            '.Rtoro = Rtoro + SpessPar / 2
            '.TipFon = GenMem.Tipo
            '.Piedritto = Piedritto
            '.DM = DM
            .AlfaSvilCon = 2 * PI
            .Dcal = 0
            .SpessPar = Spess
            .Tcal = 0
            .NumSpicchi = NumSpicchi
            .PesoSp1 = GenMem.PesoSp1
            If Mode = 1 Then
                Ris = .Spicchiatura(nset, TipOPT)
            Else
                .ConEq()
                If TipOPT = 0 Then TipOPT = 2
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Spicchiat.SP(). Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                ForLam(.RG, .RP, .AlfaSvilCon / nset, .TAGLIO, (nset), job.Comm.LargM, job.Comm.LungM, Nrisp, .SP(TipOPT + 1), TipOPT)
                .PesoSpicchi()
                '.Ottimizza nset, TipOPT
            End If
        End With
    End Sub

    Private Sub StringDIME()
        Dim i, ifl As Integer
        Dim Stringa1(11) As String
        Dim NOTE1, DIMR1, DIMR2 As String
        ifl = FreeFile()
        FileOpen(ifl, RTrim(Inizio.Archdir) & "\STAM14.DAT", OpenMode.Input, , OpenShare.Shared)
        For i = 1 To 11 : Stringa1(i) = LineInput(ifl) : Next
        FileClose(ifl)
        Select Case TipoS
            Case 1
                DIMR1 = Stringa1(1) & Str(Diamext) & Stringa1(2) & LTrim(Str(Diamint)) & Stringa1(3) & LTrim(Str(Sviluppo))
                NOTE1 = Stringa1(4) & Str(Int(Sviluppo + 20)) & Stringa1(5) & Str(Int(prAltezza + 20)) & Stringa1(5) & Str(Spess)
            Case 2
                DIMR1 = Stringa1(6) & Str(NumSpicchi) & Stringa1(7) & LTrim(Str(Int(Diamext))) & Stringa1(2) & Mid(Str(Diamint), 2, Len(Str(Diamint)) - 1) & Stringa1(3) & LTrim(Str(Int(Sviluppo)))
                NOTE1 = Stringa1(8) & Str(Int(Spicchiat.SP(TipOPT + 1).Rettn.Lung)) & Stringa1(5) & Str(Int(Spicchiat.SP(TipOPT + 1).Rettn.LARG)) & Stringa1(5) & Str(Spess)
            Case 3, 4
                If Dmant > 0 Then
                    DIMR1 = Stringa1(9) & Str(Diamint) & Stringa1(10) & LTrim(Str(prAltezza))
                    NOTE1 = Stringa1(8) & Str(Int(Diamext + 20)) & Stringa1(5) & Str(Int(deGran + 20)) & Stringa1(5) & Str(Spess)
                Else 'e
                    DIMR1 = Stringa1(1) & Str(Diamext) & Stringa1(2) & LTrim(Str(Diamint))
                    NOTE1 = Stringa1(8) & Str(Int(Diamext + 20)) & Stringa1(5) & Str(Int(Diamext + 20)) & Stringa1(5) & Str(Spess)
                End If
            Case Else
                DIMR1 = ""
                DIMR2 = ""
                NOTE1 = ""
        End Select
        DIMR2 = Stringa1(11) & LTrim(Str(Spess))
        GenMem.Dimensioni = DIMR1 & DIMR2
        GenMem.Note = NOTE1
    End Sub

    Public Overloads Sub CalcGrezzi()
        Dim grezzo As New clsGrezzo1
        GenMem.ClearGrezzi()
        GenMem.IniziaGrezzo(grezzo)
        If grezzo Is Nothing Then Exit Sub
        Select Case TipoS
            Case 1 'cilindrato
                grezzo.Vartxt(1) = "PL  "
                grezzo.Variab(1) = Spess
            Case 2 'a settori
                grezzo.Variab(1) = Spess
                grezzo.Variab(2) = Spicchiat.RG
                grezzo.Variab(3) = Spicchiat.RP
                grezzo.Dimens(4) = Spicchiat.AlfaSvilCon / Spicchiat.NumSpicchi
                grezzo.Vartxt(1) = "SP  "
                grezzo.Variab(4) = TipoS
                grezzo.Variab(5) = NumSpicchi
                grezzo.Dimens(1) = Spicchiat.SP(TipOPT + 1).Rettn.Lung
                grezzo.Dimens(2) = Spicchiat.SP(TipOPT + 1).Rettn.LARG
                grezzo.Dimens(3) = 1 'N. quadri
            Case 3, 4, 5 'da quadrotto
                grezzo.Variab(1) = Spess
                grezzo.Vartxt(1) = "AN  "
                grezzo.Dimens(1) = Diamext + GenMem.TAGLIO
                If Dmant > 0 Then
                    grezzo.Dimens(2) = deGran + GenMem.TAGLIO
                Else 'g
                    grezzo.Dimens(2) = grezzo.Dimens(1)
                End If
                grezzo.Dimens(3) = 1 'N.quadri
                grezzo.Dimens(4) = Diamint
        End Select
    End Sub
    Public Overloads Sub Pesi()
        Dim Altloc As Single
        On Error GoTo ErrP
        GenMem.Pnet0 = prAltezza * Sviluppo * Spess * GenMem.PesoSp1
        If Dmant > 0 Then GenMem.Pnet0 = CSng(GenMem.Pnet0 * System.Math.Sqrt(diGran / Diamint))
        Select Case TipoS
            Case 1
                If GenMem.Classe1 = 3 Then Altloc = prAltezza - 20 Else Altloc = prAltezza
                GenMem.plor0 = (Altloc + 20) * (Sviluppo + 20) * Spess * GenMem.PesoSp1
            Case 2
                ' LAM1 = Sp(Tipo).Rett.Larg: LAM2 = Sp(Tipo).Rett.Lung
                GenMem.plor0 = Spicchiat.SP(TipOPT + 1).peso 'LAM1 * LAM2 * Spess * Matdim(0).PSP * EXP9
                ' NSET = NSPI
            Case 3
                If Dmant > 0 Then
                    GenMem.plor0 = (Diamext + 20) * (deGran + 20) * Spess * GenMem.PesoSp1
                Else 'd
                    GenMem.plor0 = (Diamext / 2 + x + 20) * (Diamext + 20) * Spess * GenMem.PesoSp1
                End If
            Case 4
                GenMem.plor0 = CSng(((Diamext / 2 + x + 20) * (Diamext + 20) - ((Diamint - 20) ^ 2 * (PI / 4))) * Spess * GenMem.PesoSp1)
            Case 5
                GenMem.plor0 = (Diamext + 20) * (deGran + 20) * Spess * GenMem.PesoSp1
        End Select
        GenMem.Pnet0 = GenMem.Pnet0 * EXP9
        GenMem.plor0 = GenMem.plor0 * EXP9
        GenMem.Psfri0 = GenMem.plor0 - GenMem.Pnet0
        'GenMem.Converti
        GenMem.PNET = GenMem.Pnet0
ExSub:  Exit Sub
ErrP:   Resume ExSub
    End Sub
    Public Overloads Sub Copia(ByRef a As Anello)
        If a Is Nothing Then a = New Anello
        a.Diamext = Diamext
        a.Diamint = Diamint
        a.Spess = Spess
        a.Dmant = Dmant
        a.TipoMat = TipoMat
        a.TipoS = TipoS
        a.diGran = diGran
        a.deGran = deGran
        a.TipOPT = TipOPT
        a.GenMem.TAGLIO = GenMem.TAGLIO
        a.NumSpicchi = NumSpicchi
        GenMem.Copia(a.GenMem)
        a.GenMem.Parent = a
        Spicchiat.Copia(a.Spicchiat)
    End Sub
    Public Overrides Sub Mostrasviluppi()
        Select Case TipoS
            Case 2
                '   IUNL = 0
                If NumSpicchi > 1 Then ShowLam(Spicchiat, 5, TipOPT)
                If NumSpicchi = 1 Then TipOPT = 0 : ShowLam(Spicchiat, 0, TipOPT)
            Case 5
                Call ShowPad(Int(Diamext), Int(Diamint), Dmant)
        End Select
    End Sub
    Public Overrides Property Code7() As Short
        Get
            If GenMem.Classe1 = 7 Then Code7 = 1 Else Code7 = 0
        End Get
        Set(ByVal Value As Short)

        End Set
    End Property
    Public Overrides Property Param1() As Single
        Get
            Param1 = Spess
        End Get
        Set(ByVal Value As Single)

        End Set
    End Property
End Class