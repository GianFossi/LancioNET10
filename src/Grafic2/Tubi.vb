Option Strict Off
Option Explicit On
Imports System.Math
<Serializable()> Public Class Tubi
    Inherits Membratura
    Private prDiamExt As Single
    Private prSpessore As Single
    Private prLunghezza As Single
    Public LungTot As Single
    Public NpassShell As Short
    'Public GenMem As clsGenMem
    'Public Variato As Boolean
    Public Tolleranza As Short '1 MW 2 AW
    Public TipoMateriale As Short '1 CS 2 SPECIALE
    Public TipoPasso As Short
    Public OTL As Single
    Public yPrimaFila As Single
    Public yUltimFila As Single
    Public NumeroSettori As Short
    Public NumeroTubi As Short
    Public Passo As Single
    'Public TipoMat As Short
    Public LayOut As traccia.clsTracciatura
    <NonSerialized()> Private Mom As Single
    Public Sub New()
        MyBase.New()
        GenMem = New clsGenMem
        GenMem.Parent = Me
        TipoMat = 1
        TipoMateriale = 1
        Tolleranza = 1
        Variato = True
    End Sub
    Public Overrides Property Spessore() As Single
        Get
            Return prSpessore
        End Get
        Set(ByVal Value As Single)
            prSpessore = Value
        End Set
    End Property
    Public Overrides Property Lunghezza() As Single
        Get
            Return prLunghezza
        End Get
        Set(ByVal Value As Single)
            prLunghezza = Value
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
    Public Overloads Sub leggi(ByVal DiscoR As String, ByVal Mode As Short)
        'Mode=0 ricalcolo,=1 editaggio
        Select Case Mode
            Case 0
                If Not Variato Then Exit Sub
                Call Aggancio(DiscoR)
                Calcola()
                Pesi()
                GenMem.Leggiprezzi(Param1, 0, 0, , Param2)
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
    Public Sub StringDIME()
        Dim TOLE As String = ""
        Dim Note As String = ""
        Dim Denom As String = ""
        Dim Den1, NOTE1, Note2, Den2 As String
        Select Case Tolleranza
            Case 1 : TOLE = " MW"
            Case 2 : TOLE = " AW"
        End Select
        NOTE1 = "N°" & Str(NumeroTubi) & " Tubi De." & LTrim(Str(Diamext)) & " sp." & Str(Spessore) & TOLE
        Den1 = "TUBI SCAMBIATORI"
        Note2 = "N°" & Str(NumeroTubi) & " Forcelle De." & LTrim(Str(Diamext)) & " sp." & Str(Spessore) & TOLE
        Den2 = "SERIE DI TUBI AD U"
        Select Case System.Math.Abs(GenMem.Tipo)
            Case 8
                Note = NOTE1
                Denom = Den1
            Case 9
                Note = Note2
                Denom = Den2
        End Select
        GenMem.Dimensioni = Note
        If Len(RTrim(GenMem.Denom)) = 0 Then GenMem.Denom = Denom
    End Sub
    Public Overrides Sub StringMATE()
        Dim M1, M0, Riga As String
        Dim i As Short
        'sistemare il materiale della seconda riga caso tubi bimetallici
        Try
            M0 = GenMem.MaterNome(1).Trim
            If M0 = "" Then M0 = GenMem.Materiale.Trim
            If GenMem.Classe2 = 2 Then
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
        Dim Note As String = ""
        GenMem.Note = Note
    End Sub
    Public Overloads Sub CalcGrezzi()
        Dim grezzo As New clsGrezzo1
        GenMem.ClearGrezzi()
        GenMem.IniziaGrezzo(grezzo)
        If grezzo Is Nothing Then Exit Sub
        grezzo.Vartxt(1) = "TU"
        grezzo.Variab(1) = Diamext
        grezzo.Variab(2) = Lunghezza
        grezzo.Variab(3) = Spessore
    End Sub
    Public Overloads Sub Pesi()
        Dim iRes, Mode As Short
        Dim plor0, Pnet0, psfri As Single
        Dim lTot As Single
        GenMem.LeggiMat(1) 'da prevedere in seguito tubi bimetallici(TipoMat)
        GenMem.PesiSp(1) '(TipoMat)
        Select Case System.Math.Abs(GenMem.Tipo)
            Case 8
                LungTot = Lunghezza * NumeroTubi
                GenMem.Pnet0 = LungTot * PI * (Diamext ^ 2 - (Diamext - 2 * Spessore) ^ 2) / 4 * GenMem.PesoSp1 * EXP9
                LungTot = LungTot / 1000
                If Tolleranza = 1 Then GenMem.Pnet0 = GenMem.Pnet0 * 1.07
                '1770    If Tolleranza = "MW" And Inox = "SI" Then PNET(i, k) = PNET(i, k) * 1.05 Else If Tolleranza = "MW" And Inox = "NO" Then PNET(i, k) = PNET(i, k) * 1.07
                GenMem.plor0 = GenMem.Pnet0 * 1.003
                '1790    If Inox = "SI" Then PLOR(i, k) = PLOR(i, k) * 1.002 Else PLOR(i, k) = PLOR(i, k) * 1.003
            Case 9
                If System.IO.File.Exists(File) Then
                    If Not GenMem.posizione.SuChi Is Nothing Then
                        If CType(GenMem.posizione.SuChi.GenMem, clsGenMem).Tipo = 26 Then
                            LayOut = CType(GenMem.posizione.SuChi, Fascio).LayOut
                        End If
                    End If
                    If LayOut Is Nothing Then
                        LayOut = New traccia.clsTracciatura
                        LayOut.DoveMotore = Motore
                        LayOut.DoveRoutines = Funzioni.DisRut
                        LayOut.DaPPSM = True
                    End If
                    LayOut.StubMakeRMT(FunzLibgra.FileDes("ADU"), iRes, Mom, Pnet0, plor0, _
                                  psfri, GenMem.MaterNome(1), GenMem.PesoSp1, Mode, , lTot)
                    If lTot = 0 Then
                        LungTot = 2 * (Lunghezza + PI * OTL / 4) * NumeroTubi
                        GenMem.Pnet0 = LungTot * PI * (Diamext ^ 2 - (Diamext - 2 * Spessore) ^ 2) / 4 * GenMem.PesoSp1 * EXP9
                        GenMem.plor0 = GenMem.Pnet0 * 1.05
                    Else
                        LungTot = lTot '/ 1000
                        GenMem.Pnet0 = Pnet0
                        GenMem.plor0 = plor0
                        GenMem.Psfri0 = psfri
                    End If
                Else
                    LungTot = 2 * (Lunghezza + PI * OTL / 4) * NumeroTubi
                    GenMem.Pnet0 = LungTot * PI * (Diamext ^ 2 - (Diamext - 2 * Spessore) ^ 2) / 4 * GenMem.PesoSp1 * EXP9
                    GenMem.plor0 = GenMem.Pnet0 * 1.05
                End If
        End Select
        GenMem.Psfri0 = GenMem.plor0 - GenMem.Pnet0
        GenMem.PNET = GenMem.Pnet0
        '  GenMem.PSFRI = GenMem.PLOR - GenMem.PNET
        'GenMem.Converti
    End Sub
    Public Overrides Property Diametro() As Single
        Get
            Diametro = Diamext
        End Get
        Set(ByVal Value As Single)

        End Set
    End Property
    Public Overrides Property Code7() As Short
        Get
            Code7 = 0
        End Get
        Set(ByVal Value As Short)

        End Set
    End Property
    Public Overrides Property Param1() As Single
        Get
            Param1 = Diamext
        End Get
        Set(ByVal Value As Single)

        End Set
    End Property
    Public ReadOnly Property Param2() As Single
        Get
            Param2 = Spessore
        End Get
    End Property
    Private Sub Calcola()
        GenMem.Qta = NumeroTubi
        If yPrimaFila = 0 Or GenMem.Tipo > 0 Then yPrimaFila = 1.5 * Diamext
        If yUltimFila <= 0 Or GenMem.Tipo > 0 Then yUltimFila = (OTL - Diamext) / 2
    End Sub
End Class