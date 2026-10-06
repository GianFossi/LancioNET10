Option Strict Off
Option Explicit On
Imports System.Math
<Serializable()> Public Class CalDisc
    Inherits Membratura
    Private prDiamExt As Single
    Public RaggioCal As Single
    Public Ginocchio As Single
    Public Colletto As Single
    Private prSpessBase As Single
    Public SpessRive As Single
    'Public TipoMat As Single
    Public Fuori As Boolean
    Private prSottoTipo As Short
    Public DiscoPar As Single
    Public SpessPar As Single
    'Public GenMem As clsGenMem
    'Public Variato As Boolean
    <NonSerialized()> Private Diam1 As Single
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
    Public Overrides Property Diamext() As Single
        Get
            Return prDiamExt
        End Get
        Set(ByVal Value As Single)
            prDiamExt = Value
        End Set
    End Property
    Private Sub Leggi01()
        Dim ifl, i As Short
        Dim Riga As String
        ifl = FreeFile()
        FileOpen(ifl, RTrim(Inizio.Archdir) & "\CALA02.DAT", OpenMode.Input, , OpenShare.Shared)
        For i = 0 To 5
            Riga = LineInput(ifl)
            FormDati.lblPara(i).Text = Riga
        Next
        FileClose(ifl)
    End Sub
    Private Sub MettiMeno()
        With FormDati
            Select Case SottoTipo
                Case 1 'Calotta
                    .lblPara(2).Text = Chr(45)
                    .lblPara(3).Text = Chr(45)
                Case 2 'Disco
                    .lblPara(1).Text = Chr(45)
                    .lblPara(2).Text = Chr(45)
                    .lblPara(3).Text = Chr(45)
                Case 3 'Fondo piano raccordato
                    .lblPara(1).Text = Chr(45)
            End Select
            If TipoMat = 1 Then .lblPara(6).Text = Chr(45)
            If IUNL = 6 Then
                .cmbTipo.Enabled = False
                .txtDen.Enabled = False
            End If
        End With
    End Sub
    Private Sub PreparaR()
        If SottoTipo = 0 Then SottoTipo = 1
        With FormDati
            .txtPara(0).Text = LTrim(GlobalRoutines.myStr(Diamext, 8, 2, False))
            .txtPara(1).Text = LTrim(GlobalRoutines.myStr(RaggioCal, 8, 2, False))
            .txtPara(2).Text = LTrim(GlobalRoutines.myStr(Ginocchio, 8, 0, False))
            .txtPara(3).Text = LTrim(GlobalRoutines.myStr(Colletto, 8, 0, False))
            .txtPara(4).Text = LTrim(GlobalRoutines.myStr(SpessBase, 8, 0, False))
            .txtPara(5).Text = LTrim(GlobalRoutines.myStr(SpessRive, 8, 0, False))
        End With
    End Sub
    Public Sub Registra(ByRef Index As Short)
        With FormDati
            Select Case Val(.txtPara(Index).Tag)
                Case 0 : Diamext = GlobalRoutines.ValVir(.txtPara(Index).Text)
                Case 1 : RaggioCal = GlobalRoutines.ValVir(.txtPara(Index).Text)
                Case 2 : Ginocchio = GlobalRoutines.ValVir(.txtPara(Index).Text)
                Case 3 : Colletto = GlobalRoutines.ValVir(.txtPara(Index).Text)
                Case 4 : SpessBase = GlobalRoutines.ValVir(.txtPara(Index).Text)
                Case 5 : SpessRive = GlobalRoutines.ValVir(.txtPara(Index).Text)
            End Select
        End With
    End Sub
    Public Sub PrSeFinDil(ByRef Nfield As Short)
        Dim i, j As Short
100:    Call Leggi01()
120:    Call PreparaR()
        Nfield = 6
130:    Call MettiMeno()
        With FormDati
            j = -1
            For i = 0 To Nfield
                If .lblPara(i).Text = Chr(45) Then
                    .lblPara(i).Tag = "0" 'Compr(i) = 0
                Else
                    j = j + 1
                    .lblPara(i).Tag = Str(j) 'Compr(i) = j
                    .txtPara(j).Tag = Str(i) 'Esp(j) = i
                End If 'e
            Next i '1
140:        Nfield = j
            For i = 0 To Nfield
                .lblPara(i).Text = .lblPara(Val(.txtPara(i).Tag)).Text
                .txtPara(i).Text = .txtPara(Val(.txtPara(i).Tag)).Text
            Next i ' a
            For i = Nfield + 1 To 6
                .lblPara(i).Visible = False
                .txtPara(i).Visible = False
            Next
        End With
    End Sub
    Public Overloads Sub Pesi()
        Dim x, Alfa As Single
        If RaggioCal = 0 Then
            If Ginocchio = 0 Then
                DiscoPar = Diamext
            Else
                DiscoPar = (Ginocchio + (SpessBase + SpessRive) / 2) * PI + 2 * Colletto + Diam1
                DiscoPar = Int(DiscoPar)
            End If
        Else
            x = (Diamext / 2) / RaggioCal : Alfa = 2 * (System.Math.Atan(x / System.Math.Sqrt(1 - x * x)))
            DiscoPar = (RaggioCal + (SpessBase + SpessRive) / 2) * Alfa : DiscoPar = Int(DiscoPar)
        End If
        GenMem.Pnet0 = (DiscoPar ^ 2 * PI / 4) * (SpessBase - SpessRive) * GenMem.PesoSp1
        GenMem.plor0 = (DiscoPar + 30) ^ 2 * (SpessPar - SpessRive) * GenMem.PesoSp1
        GenMem.Pnet1 = (DiscoPar ^ 2 * PI / 4) * SpessRive * GenMem.PesoSp2
        GenMem.Plor1 = DiscoPar ^ 2 * PI / 4 * SpessRive * GenMem.PesoSp2
        If GenMem.Classe2 <> 9 Then
            GenMem.Pnet0 = GenMem.Pnet0 + GenMem.Pnet1
            GenMem.plor0 = GenMem.plor0 + GenMem.Plor1
            GenMem.Pnet1 = 0
            GenMem.Plor1 = 0
        End If
        GenMem.Psfri0 = GenMem.plor0 - GenMem.Pnet0
        GenMem.Psfri1 = GenMem.Plor1 - GenMem.Pnet1
        If GenMem.LavorEst Then
            GenMem.plor0 = (DiscoPar ^ 2 * PI / 4) * (CSng(SpessBase) - SpessRive * CShort(GenMem.Classe2 = 2)) * GenMem.PesoSp1
            GenMem.Psfri0 = GenMem.plor0 - GenMem.Pnet0
        End If
        GenMem.PNET = GenMem.Pnet0 + GenMem.Pnet1
        'GenMem.PSFRI = GenMem.PLOR - GenMem.PNET
        'PNET0 = PNET0 * NPE: PSFRI = PSFRI * NPE: PLOR0 = PLOR0 * NPE
    End Sub
    Public Overrides Sub StringMATE()
        Dim NOTE7 As String = ""
        Dim NOTE3 As String = ""
        Dim NOTE8 As String = ""
        Try
            NOTE7 = GenMem.MaterNome(1).Trim
            If NOTE7 = "" Then NOTE7 = GenMem.Materiale.Trim
            If SpessRive > 0 Then
                NOTE8 = GenMem.MaterNome(2).Trim
            Else
                NOTE3 = NOTE7
            End If
        Catch
        End Try
        If SpessRive <> 0 And GenMem.Classe2 = 2 Then
            NOTE3 = NOTE7 & " + " & NOTE8
        ElseIf SpessRive <> 0 Then
            NOTE3 = NOTE7 & " clad " & NOTE8
        End If
        GenMem.Materiale = NOTE3
    End Sub
    Public Sub StringDIME()
        Dim ifl As Short
        Dim Stringa1(7) As String
        Dim Note4 As String = ""
        Dim Note5 As String = ""
        Dim i As Short
        ifl = FreeFile()
        FileOpen(ifl, RTrim(Inizio.Archdir) & "\CALA14.DAT", OpenMode.Input, , OpenShare.Shared)
        For i = 1 To 7 : Stringa1(i) = LineInput(ifl) : Next
        FileClose(ifl)
        If RaggioCal = 0 And Ginocchio = 0 Then Note4 = Stringa1(1) & Mid(Str(Diamext), 2, Len(Str(Diamext)) - 1)
        If RaggioCal <> 0 Then Note4 = Stringa1(2) & Mid(Str(Diamext), 2, Len(Str(Diamext)) - 1) & Stringa1(5) & Str(RaggioCal)
        If Ginocchio <> 0 Then Note4 = Stringa1(3) & Mid(Str(Diam1 + Ginocchio * 2), 2, Len(Str(Diamext + Ginocchio * 2)) - 1) & Stringa1(5) & Str(Ginocchio) & Stringa1(6) & Str(Colletto)
        If GenMem.Classe2 = 0 Then
            Note5 = Stringa1(4) & Mid(Str(SpessBase), 2, Len(Str(SpessBase)) - 1)
        Else
            Note5 = Stringa1(4) & Mid(Str(SpessBase), 2, Len(Str(SpessBase)) - 1) & Stringa1(7) & Mid(Str(SpessRive), 2, Len(Str(SpessRive)) - 1)
        End If
2330:   If SpessRive <> 0 Then
            Note5 = Stringa1(4) & Str(SpessRive)
        End If
        GenMem.Dimensioni = Note4 & Note5
    End Sub

    Public Sub StringNOTE()
        GenMem.Note = "Quadrotto " & Str(DiscoPar + GenMem.MargTag(SpessPar)) & " x" & Str(DiscoPar + GenMem.MargTag(SpessPar)) & " x" & Str(SpessPar - SpessRive * CShort(GenMem.Classe2 = 2))
    End Sub
    Public Overloads Sub leggi(ByVal DiscoR As String, ByVal Mode As Short)
        Select Case Mode
            Case 0
                If Not Variato Then Exit Sub
                GenMem.LeggiMat((TipoMat))
                GenMem.PesiSp((TipoMat))
                GenMem.TAGLIO = GenMem.MargTag(SpessBase)
                Calcoli()
                Pesi()
                GenMem.Leggiprezzi(Int(SpessBase), 0, 0)
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
        MyBase.Finalize()
    End Sub
    Public Sub Calcoli()
        Diam1 = Diamext
        If Ginocchio > 0 Then
            Diam1 = Diamext - Ginocchio * 2
            SpessPar = CShort(SpessBase * 1.05)
        ElseIf RaggioCal > 0 Then
            SpessPar = CShort(SpessBase * 1.15)
        End If
    End Sub

    Public Overloads Sub CalcGrezzi()
        Dim grezzo As New clsGrezzo1
        GenMem.ClearGrezzi()
        GenMem.IniziaGrezzo(grezzo)
        If grezzo Is Nothing Then Exit Sub
        grezzo.Variab(1) = SpessPar
        grezzo.Dimens(3) = 1
        If GenMem.Classe1 <= 2 Then
            grezzo.Vartxt(1) = "DI  "
            grezzo.Dimens(1) = DiscoPar + 2 * GenMem.MargTag(SpessPar) ', GenMem.Classe1)
            grezzo.Dimens(2) = DiscoPar + 2 * GenMem.MargTag(SpessPar) ', GenMem.Classe1)
            grezzo.Variab(1) = SpessPar
        Else
            grezzo.Vartxt(1) = "DF  "
            grezzo.Dimens(1) = DiscoPar
            grezzo.Dimens(2) = SpessPar
        End If
    End Sub
    Public Overloads Sub Copia(ByRef A As CalDisc)
        If A Is Nothing Then A = New CalDisc
        A.Diamext = Diamext
        A.RaggioCal = RaggioCal
        A.Ginocchio = Ginocchio
        A.Colletto = Colletto
        A.SpessBase = SpessBase
        A.SpessRive = SpessRive
        A.TipoMat = TipoMat
        A.Fuori = Fuori
        A.SottoTipo = SottoTipo
        A.DiscoPar = DiscoPar
        A.SpessPar = SpessPar
        GenMem.Copia(A.GenMem)
        A.GenMem.Parent = A
    End Sub
    Public Overrides Property Diametro() As Single
        Get
            Diametro = Diamext
        End Get
        Set(ByVal Value As Single)
            Diamext = Value
        End Set
    End Property
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
End Class