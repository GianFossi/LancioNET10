Option Strict Off
Option Explicit On
Imports System.Math
Imports RoutBase1
Imports System.Data
Imports System.Data.OleDb
<Serializable()> Public Class Sella
    Inherits Membratura
    Public Storta As Boolean
    Private prLarghezza As Single
    Public Rinforzo As Cilindro
    Public PiasBase As Striscia
    Public PiasTesta As Striscia
    Public Ribs As Raggrupp
    Public Costola As clsPolig
    Public SorAngSel As Single
    Private prAltezza As Single
    Public AltSopra As Single
    Public SpesBase As Single
    Public LargBase As Single
    Public LungBase As Single
    Public nribs As Short
    Public DistRib2, DistRib1, DistRib3 As Single
    Public SpRibs As Single
    Public SpCost As Single
    Public SpRinf As Single
    Public LargRinfShell As Single
    Public LargRinfBase As Single
    Public CI As Boolean
    Public FixSlid As Boolean
    Public sempor As Boolean
    'Public TipoMat As Short '1,2,3,4
    Public StandardSEl As Integer
    Public StandardStr As String
    Public Serie As Integer
    Public IndMatRinf As Integer
    '----------------------
    'Public GenMem As clsGenMem
    Public MaterRinf As New LibMat.clsMatCompos
    'Public Variato As Boolean
    Private db As OleDbConnection
    Private cmddb As OleDbDataAdapter
    Private d As Single
    Public Overrides Property Larghezza() As Single
        Get
            Return prLarghezza
        End Get
        Set(ByVal Value As Single)
            prLarghezza = Value
        End Set
    End Property
    Public Overrides Sub StringMATE()
        Dim M0 As String = GenMem.MaterNome(1).Trim
        If M0 = "" Then M0 = GenMem.Materiale.Trim
        GenMem.Materiale = M0
    End Sub
    Public Overrides Property Altezza() As Single
        Get
            Return prAltezza
        End Get
        Set(ByVal Value As Single)
            prAltezza = Value
        End Set
    End Property
    Public Sub StringDIME()
        GenMem.Dimensioni = Str(Altezza) & "x" & Str(LargBase) & "x" & Str(LungBase) & " (HxLxW)"
    End Sub
    Public Sub StringNOTE()
        Dim Note As String
        If sempor Then
            Note = "SELLA SEM. "
        Else
            Note = "SELLA POR. "
        End If
        If FixSlid Then
            Note = Note & "(fissa). Std"
        Else
            Note = Note & "(strisciante). Std "
        End If
        Note = Note & StandardStr & ". Tipo" & Str(Serie)
        GenMem.Note = Note
    End Sub
    Private Sub MettiMeno()
        With FormDati
            If sempor Then
                .lblPara(3).Tag = "nv"
                .txtPara(3).Tag = "nv"
            End If
        End With
    End Sub
    Private Sub PreparaR()
        With FormDati
            '.txtPara(0).Text = "" ' da eliminare Stringa(SottoTipo)
            '.txtPara(1).Text = LTrim$(myStr(DIMAX, 8, 2, False))
            .txtPara(2).Text = LTrim(GlobalRoutines.myStr(Altezza, 8, 2, False))
            .txtPara(3).Text = LTrim(GlobalRoutines.myStr(AltSopra, 8, 0, False))
            .txtPara(4).Text = LTrim(GlobalRoutines.myStr(SpesBase, 8, 0, False))
            .txtPara(5).Text = LTrim(GlobalRoutines.myStr(LargBase, 8, 0, False))
            .txtPara(6).Text = LTrim(GlobalRoutines.myStr(LungBase, 8, 0, False))
            .txtPara(7).Text = LTrim(GlobalRoutines.myStr(SpRibs, 8, 2, False))
            .txtPara(8).Text = LTrim(GlobalRoutines.myStr(SpCost, 8, 2, False))
            .txtPara(9).Text = LTrim(GlobalRoutines.myStr(SpRinf, 8, 2, False))
        End With
    End Sub
    Public Sub PrSeFinDil(ByRef Nfield As Short)
        Dim i As Short
120:    Call PreparaR()
130:    Call MettiMeno()
        '  j = -1
        With FormDati
            '   For i = 0 To Nfield
            '     If .lblPara(i).Caption = Chr$(45) Then
            '        .lblPara(i).Tag = "0" 'Compr(i) = 0
            '     Else
            '       j = j + 1
            '        .lblPara(i).Tag = Str$(j) 'Compr(i) = j
            '        .txtPara(j).Tag = Str$(i) 'Esp(j) = i
            '     End If 'e
            '   Next i '1
140:        ' Nfield = j
            'For i = 0 To Nfield
            '   .lblPara(i).Caption = .lblPara(Val(.txtPara(i).Tag)).Caption
            '   .txtPara(i).Text = .txtPara(Val(.txtPara(i).Tag)).Text
            'Next i ' a
            For i = Nfield + 1 To 21
                .lblPara(i).Visible = False
                .txtPara(i).Visible = False
            Next
        End With
    End Sub
    Public Overloads Sub leggi(ByVal DiscoR As String, ByVal Mode As Short)
        'Mode=0 ricalcolo,=1 editaggio
        Select Case Mode
            Case 0
                If Not Variato Then Exit Sub
                Call Aggancio(DiscoR)
                GenMem.TAGLIO = GenMem.MargTag(SpCost)
                ' Calcoli
                Appendi(Mode)
                Pesi()
                GenMem.Leggiprezzi(Int(SpCost), 0, 0)
                StringDIME()
                StringMATE()
                StringNOTE()
                Variato = False
                If IUNL < 5 Then CalcGrezzi()
            Case 1
                Membro = Me
                '  frmDistinta.Hide               '10-5-99
                FormDati.txtMat(1).Text = MaterRinf.Mat(1).MatStr
                FormDati.ShowDialog()
                '  frmDistinta.Show vbModal       '10-5-99
                Appendi(Mode)
        End Select
    End Sub
    Public Overloads Sub Pesi()
        Dim Obj As Membratura
        GenMem.LeggiMat((TipoMat))
        If IndMatRinf > 0 And Not MaterRinf.Mat(1).Indmat = IndMatRinf Then
            MaterRinf.Mat(1).Indmat = IndMatRinf
            MaterRinf.Mat(1).RecupMat(Inizio.Archdir)
        End If
        GenMem.PesiSp((TipoMat))
        GenMem.Pnet0 = 0
        GenMem.plor0 = 0
        Dim n As OggList.NodeP = GenMem.Appesi.nodeHead.Next
        While Not n Is Nothing
            Obj = n.TextData
            Obj.Pesi()
            GenMem.Pnet0 = GenMem.Pnet0 + Obj.GenMem.Pnet0
            GenMem.plor0 = GenMem.plor0 + Obj.GenMem.plor0
            n = n.Next
        End While
    End Sub
    Public Overloads Sub CalcGrezzi()
        Dim grezzo As New clsGrezzo1
        Dim O As Membratura
        If GenMem.MF = "--" Then
            GenMem.ClearGrezzi()
            GenMem.IniziaGrezzo(grezzo)
            If grezzo Is Nothing Then Exit Sub
            grezzo.Vartxt(1) = "SELL"
        Else
            Dim n As OggList.NodeP = GenMem.Appesi.nodeHead.Next
            While Not n Is Nothing
                O = n.TextData
                O.CalcGrezzi()
                n = n.Next
            End While
        End If
    End Sub
    Public Sub Registra(ByRef Index As Short)
        With FormDati
            Select Case Index 'Val(.txtPara(Index).Tag)
                ' Case 1: DIMAX = Val(frmDati.txtPara(Index).Text)
            Case 2 : Altezza = Val(.txtPara(Index).Text)
                Case 3 : AltSopra = Val(.txtPara(Index).Text)
                Case 4 : SpesBase = Val(.txtPara(Index).Text)
                Case 5 : LargBase = Val(.txtPara(Index).Text)
                Case 6 : LungBase = Val(.txtPara(Index).Text)
                Case 7 : SpRibs = Val(.txtPara(Index).Text)
                Case 8 : SpCost = Val(.txtPara(Index).Text)
                Case 9 : SpRinf = Val(.txtPara(Index).Text)
            End Select
        End With
    End Sub
    Public Sub RegistraTutto() '9-5-99  (Index As Integer)
        StandardStr = DbaseSelle.DefInstance.Text1(1).Text
        Serie = Val(DbaseSelle.DefInstance.Text1(2).Text)
        'sempor = Val(DbaseSelle.Text1(3).Text)
        Altezza = Val(DbaseSelle.DefInstance.Text1(5).Text)
        Larghezza = Val(DbaseSelle.DefInstance.Text1(6).Text)
        LungBase = Val(DbaseSelle.DefInstance.Text1(7).Text)
        LargBase = Val(DbaseSelle.DefInstance.Text1(8).Text)
        LargRinfBase = Val(DbaseSelle.DefInstance.Text1(9).Text)
        LargRinfShell = Val(DbaseSelle.DefInstance.Text1(10).Text)
        nribs = Val(DbaseSelle.DefInstance.Text1(15).Text)
        SpCost = Val(DbaseSelle.DefInstance.Text1(19).Text)
        SpRinf = Val(DbaseSelle.DefInstance.Text1(20).Text)
        SpRibs = Val(DbaseSelle.DefInstance.Text1(21).Text)
        SpesBase = Val(DbaseSelle.DefInstance.Text1(22).Text)
        'ci = Val(DbaseSelle.Text1(27).Text)
        SorAngSel = Val(DbaseSelle.DefInstance.Text1(29).Text)
        If Val(DbaseSelle.DefInstance.Text1(30).Text) <> 0 Then
            FixSlid = True
        Else
            FixSlid = False
        End If
        AltSopra = Val(DbaseSelle.DefInstance.Text1(32).Text) - Altezza
        'TipoMat = Val(DbaseSelle.Text1(Index).Text)
        'StandardSEl = Val(DbaseSelle.Text1(1).Text)
    End Sub

    'UPGRADE_NOTE: Class_Initialize è stato aggiornato a Class_Initialize_Renamed. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1061"'
    Private Sub Class_Initialize_Renamed()
        GenMem = New clsGenMem
        GenMem.Parent = Me
        TipoMat = 1
        Variato = True
        sempor = True
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
    Public Sub Appendi(ByRef Mode As Short)
        Dim Ogg As Membratura = Nothing
        Dim i As Short
        If Not Caricamento And Not Editing Then GenMem.ClearAppesi(True)
        If SpRinf > 0 Then
            If Not Editing Then
                If Rinforzo Is Nothing Then Rinforzo = New Cilindro
                SetRinforzo()
            Else
                If Rinforzo Is Nothing Then
                    Dim n As OggList.NodeP = GenMem.Appesi.nodeHead.Next
                    While Not n Is Nothing
                        If Ogg.GenMem.Tipo = -1 Or Ogg.GenMem.Tipo = -34 Then
                            Rinforzo = Ogg
                            Exit While
                        End If
                        n = n.Next
                    End While
                End If
                If Rinforzo Is Nothing Then Rinforzo = New Cilindro
                SetRinforzo()
            End If
        Else
            Rinforzo = Nothing
            i = 1
            Do While i <= GenMem.Appesi.Count()
                Select Case GenMem.Appesi(i).GenMem.Tipo
                    Case -1, -35 : GenMem.AppesiRemove(i, True)
                        'i = i - 1
                End Select
                i = i + 1
            Loop
        End If
        If Not Editing Then
            If PiasBase Is Nothing Then PiasBase = New Striscia
            SetPiasBase()
        Else
            If PiasBase Is Nothing Then
                Dim n As OggList.NodeP = GenMem.Appesi.nodeHead.Next
                While Not n Is Nothing
                    Ogg = n.TextData
                    If Ogg.GenMem.Tipo = -15 Then
                        PiasBase = Ogg
                        Exit While
                    End If
                    n = n.Next
                End While
            End If
            If PiasBase Is Nothing Then PiasBase = New Striscia
            SetPiasBase()
        End If
        If Not sempor Then
            If Not Editing Then
                If PiasTesta Is Nothing Then PiasTesta = New Striscia
                SetPiastesta()
            Else
                If PiasTesta Is Nothing Then
                    Dim n As OggList.NodeP = GenMem.Appesi.nodeHead.Next
                    While Not n Is Nothing
                        Ogg = n.TextData
                        If Ogg.GenMem.Tipo = -15 And Not Ogg Is PiasBase Then
                            PiasTesta = Ogg
                            Exit While
                        End If
                        n = n.Next
                    End While
                End If
                If PiasTesta Is Nothing Then PiasTesta = New Striscia
                SetPiastesta()
            End If
        End If
        If Not Editing Then
            If Costola Is Nothing Then Costola = New clsPolig
            SetCostola()
        Else
            If Costola Is Nothing Then
                Dim n As OggList.NodeP = GenMem.Appesi.nodeHead.Next
                While Not n Is Nothing
                    Ogg = n.TextData
                    If Ogg.GenMem.Tipo = -96 Then
                        Costola = Ogg
                        Exit While
                    End If
                    n = n.Next
                End While
            End If
            If Costola Is Nothing Then Costola = New clsPolig
            SetCostola()
        End If
        If Not Editing Then
            If Ribs Is Nothing Then Ribs = New Raggrupp
            SetRibs(Mode)
        Else
            ' Set Ribs = Nothing
            If Ribs Is Nothing Then
                Dim n As OggList.NodeP = GenMem.Appesi.nodeHead.Next
                While Not n Is Nothing
                    Ogg = n.TextData
                    If Ogg.GenMem.Tipo = -38 Then
                        If CType(Ogg, Raggrupp).Tipo = -15 Then
                            Ribs = Ogg
                            Exit While
                        End If
                    End If
                    n = n.Next
                End While
            End If
            If Ribs Is Nothing Then Ribs = New Raggrupp
            SetRibs(Mode)
        End If
    End Sub
    Private Sub SetRinforzo()
        With Rinforzo
            If sempor Then
                .GenMem.Tipo = -34
                .GenMem.Indmat1 = IndMatRinf
                If SorAngSel = 0 Then SorAngSel = 12
                .AngTegola = 120 + SorAngSel 'apertura in gradi
            Else
                .GenMem.Tipo = -1
            End If
            .GenMem.Lato = 4
            .Lunghezza = LargRinfShell
            .SpessBase = SpRinf
            .Diametro = Diametro
            .GenMem.Denom = "RINFORZO SELLA"
            .GenMem.Qta = 1
            GenMem.AppesiAdd(Rinforzo)
            'Set .GenMem.posizione.SuChi = Me
            If IUNL < 5 Then
                If .GenMem.PosDis <= 0 Then .GenMem.PosDis = Funzioni.SetPosizN(Me) ' RecordD(0).PosDis + jRec
                Funzioni.InitPosSpaN(GenMem, .GenMem)
                '.leggi Inizio.DiscoRam, Mode
                .GenMem.posizione.DirDiritta = "=+"
                .GenMem.posizione.Quota = Str(-LargRinfShell / 2) '"Ne"
                If sempor Then
                    .GenMem.posizione.DirTraversa = "Up"
                End If
                AggCoordN(.GenMem)
            End If
        End With
    End Sub
    Private Sub SetPiastesta()
        With PiasTesta
            .GenMem.Tipo = -15
            .GenMem.Indmat1 = GenMem.Indmat1
            .GenMem.Denom = "Piastra di testa"
            .Lunghezza = LargBase
            .Spessore = SpesBase
            .Larghezza = LungBase
            GenMem.AppesiAdd(PiasTesta)
            .GenMem.posizione.SuChi = Me ' RecordD(0).Ind
            'If .GenMem.PosDis <= 0 Then .GenMem.PosDis = Funzioni.SetPosizN(Me) 'RecordD(0).PosDis + jRec
            Funzioni.InitPosSpaN(GenMem, .GenMem)
            '.leggi Inizio.DiscoRam, Mode
            .GenMem.posizione.DirDiritta = "=+"
            .GenMem.posizione.Quota = Str(-LargBase / 2) '"Ne"
            .GenMem.posizione.Raggio = Str(AltSopra - SpesBase / 2)
            .GenMem.posizione.Anomal = "+N"
            .GenMem.posizione.DirTraversa = "Do"
            AggCoordN(.GenMem)
        End With
    End Sub
    Private Sub SetCostola()
        Dim A, R, X, Y As Single
        With Costola
            .GenMem.Tipo = -96 ' -96
            .GenMem.Lato = 4
            .GenMem.Indmat1 = GenMem.Indmat1
            .GenMem.Denom = "Costola"
            .Rifer = 1
            .Spessore = SpCost
            .Npunti = 4
            .Vertici.Punti.Item(1).TextData.X = Larghezza / 2
            .Vertici.Punti.Item(1).TextData.y = Altezza - SpesBase
            .Vertici.Punti.Item(2).TextData.X = -Larghezza / 2
            .Vertici.Punti.Item(2).TextData.y = Altezza - SpesBase
            R = Diametro / 2 + SpRinf
            If sempor Then
                If Storta Then
                    A = (120) / 2 * PI / 180
                    X = R * System.Math.Sin(A)
                    Y = R * System.Math.Cos(A)
                    .Vertici.Punti.Item(3).TextData.X = -X
                    .Vertici.Punti.Item(3).TextData.y = Y
                    .Vertici.Punti.Item(4).TextData.X = X
                    .Vertici.Punti.Item(4).TextData.y = Y
                Else
                    If R ^ 2 - (Larghezza / 2) ^ 2 >= 0 Then
                        Y = System.Math.Sqrt(R ^ 2 - (Larghezza / 2) ^ 2)
                    Else
                        Y = 0
                    End If
                    .Vertici.Punti.Item(3).TextData.X = -Larghezza / 2
                    .Vertici.Punti.Item(3).TextData.y = Y
                    .Vertici.Punti.Item(4).TextData.X = Larghezza / 2
                    .Vertici.Punti.Item(4).TextData.y = Y
                End If
            Else
                .Vertici.Punti.Item(3).TextData.X = -Larghezza / 2
                .Vertici.Punti.Item(3).TextData.y = 0
                .Vertici.Punti.Item(4).TextData.X = Larghezza / 2
                .Vertici.Punti.Item(4).TextData.y = 0
            End If
            .Raggi(3).TextData = -R
            GenMem.AppesiAdd(Costola)
            ' Set .GenMem.posizione.SuChi = Me     ' RecordD(0).Ind
            Funzioni.InitPosSpaN(GenMem, .GenMem)
            ' .leggi Inizio.DiscoRam, Mode
            .GenMem.posizione.DirDiritta = "-N"
            If CI Then
                .GenMem.posizione.Quota = Str(LargRinfBase / 2 - SpRinf / 2)
            Else
                .GenMem.posizione.Quota = "0"
            End If
            .GenMem.posizione.DirTraversa = "Up"
            AggCoordN(.GenMem)
        End With
    End Sub
    Private Sub SetPiasBase()
        With PiasBase
            .GenMem.Tipo = -15
            .GenMem.Indmat1 = GenMem.Indmat1
            .GenMem.Denom = "Piastra di base"
            .GenMem.Lato = 4
            .Lunghezza = LargBase
            .Spessore = SpesBase
            .Larghezza = LungBase
            GenMem.AppesiAdd(PiasBase)
            'Set .GenMem.posizione.SuChi = Me ' RecordD(0).Ind
            'If .GenMem.PosDis <= 0 Then .GenMem.PosDis = Funzioni.SetPosizN(Me) 'RecordD(0).PosDis + jRec
            Funzioni.InitPosSpaN(GenMem, .GenMem)
            '.leggi Inizio.DiscoRam, Mode
            .GenMem.posizione.DirDiritta = "=+"
            .GenMem.posizione.Quota = Str(-LargBase / 2) '"Ne"
            .GenMem.posizione.Raggio = Str(Altezza - SpesBase / 2)
            .GenMem.posizione.Anomal = "-N"
            .GenMem.posizione.DirTraversa = "Up"
            AggCoordN(.GenMem)
        End With
    End Sub
    Public Overrides Property Diametro() As Single
        Get
            Dim Quota As Single
            Diametro = d
            '7-5-99
            Dim O As Membratura
            O = GenMem.posizione.SuChi
            If O Is Nothing Then
                MsgBox("Posizionare correttamente la sella sulla membratura opportuna prima di continuare", MsgBoxStyle.Information)
                d = 0
            Else
                On Error GoTo Ex
                Select Case O.GenMem.Tipo
                    Case 1
                        d = O.Diametro + 2 * O.Spessore
                    Case 6, 7
                        With O
                            Quota = Val(GenMem.posizione.Quota)
                            d = .Dgran + (.Dpicc - .Dgran) * Quota / .Altezza
                            d = d + 2 * .Spessore
                        End With
                End Select
                If d = 0 Then
                    MsgBox(CDbl("Il diametro della membratura sulla quale è posizionata la sella (") + O.GenMem.Denom + CDbl(") non è correttamente definito."), MsgBoxStyle.Information)
                End If
            End If
Ex:         'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Diametro. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            Diametro = d
            '7-5-99
        End Get
        Set(ByVal Value As Single)
            Dim O As Membratura
            O = GenMem.posizione.SuChi
            If O Is Nothing Then
                MsgBox("Posizionare correttamente la sella sulla membratura opportuna prima di continuare", MsgBoxStyle.Information)
                d = 0
            Else
                d = O.Diametro + 2 * O.Spessore
                If d = 0 Then
                    MsgBox("Il diametro della membratura sulla quale è posizioneta la sella " + O.GenMem.Denom + " non è corretamente definito.", MsgBoxStyle.Information)
                End If
            End If
            d = Value
        End Set
    End Property
    Private Sub SetRibs(ByRef Mode As Short)
        Dim i, j As Short
        Dim d As Single
        Dim s As Striscia
        Dim n, k As Short
        Dim s1 As Striscia
        Dim Tag As String
        Dim K1 As Short
        Dim Y, R, dy As Single
        If FixSlid Then Tag = "F" Else Tag = "S"
        j = 1
        If CI Then n = 1 Else n = 2
        With Ribs
            .Base = Me
            .Tipo = -15
            .GenMem.Tipo = -38
            GenMem.posizione.Copia((.GenMem.posizione))
            'If .GenMem.PosDis <= 0 Then .GenMem.PosDis = Funzioni.SetPosizN(Me) ' RecordD(0).PosDis + 1
            .GenMem.posizione.SuChi = Me 'RecordD(0).Ind
            .GenMem.Ind = 0 ' jRec + RecordD(0).Ind
            .GenMem.Denom = "COSTOLE x " & Trim(GenMem.Denom)
            .GenMem.Qta = 1
            .GenMem.posizione.DirDiritta = "=+"
            .GenMem.posizione.Quota = "Ne"
            GenMem.AppesiAdd(Ribs)
            If Not Caricamento Then
                .GenMem.ClearAppesi(True)
                For k = 1 To n
                    If k = 1 Then K1 = 1 Else K1 = -1
                    For i = 1 To nribs \ 2
                        Select Case i
                            Case 1 : d = DistRib1
                            Case 2 : d = DistRib2
                            Case 3 : d = DistRib3
                        End Select
                        s = New Striscia
                        With s
                            Ribs.GenMem.Copia(.GenMem)
                            .GenMem.Parent = s
                            .GenMem.Tipo = -15
                            .GenMem.Lato = 4
                            .GenMem.Indmat1 = GenMem.Indmat1
                            .GenMem.Denom = "Ribs" & Trim(Str(j)) & Tag
                            .GenMem.PosDis = 0 ' SealStrips.GenMem.PosDis
                            .GenMem.posizione.SuChi = Ribs
                            .GenMem.Qta = 1
                            .GenMem.posizione.DirDiritta = "+N"
                            If CI Then
                                .GenMem.posizione.Quota = Str(-SpCost / 2)
                                .Larghezza = LargRinfBase - SpCost
                            Else
                                .GenMem.posizione.Quota = Str(K1 * (LargRinfBase - SpCost) / 4 + K1 * SpCost / 2)
                                .Larghezza = (LargRinfBase - SpCost) / 2
                            End If
                            .Spessore = SpRibs
                            R = Diametro / 2 + SpCost
                            If R > d Then dy = System.Math.Sqrt(R ^ 2 - d ^ 2) Else dy = 0
                            Y = Altezza - SpesBase - dy
                            .Lunghezza = Y
                            .GenMem.posizione.Raggio = Str(System.Math.Sqrt(d ^ 2 + (Altezza - SpesBase) ^ 2))
                            .GenMem.posizione.Anomal = Str(-180 / PI * GlobalRoutines.arco(d / Val(.GenMem.posizione.Raggio), (Altezza - SpesBase) / Val(.GenMem.posizione.Raggio)))
                            .GenMem.posizione.DirTraversa = "=+"
                            Ribs.GenMem.AppesiAdd(s)
                            ' Funzioni.InitposSpaN GenMem, .GenMem
                            AggCoordN(.GenMem)
                        End With
                        j = j + 1
                        s1 = New Striscia
                        s.Copia(s1)
                        With s1
                            .GenMem.posizione.Anomal = Str(-180 / PI * GlobalRoutines.arco(-d / Val(.GenMem.posizione.Raggio), (Altezza - SpesBase) / Val(.GenMem.posizione.Raggio)))
                            .GenMem.Denom = "Ribs" & Trim(Str(j)) & Tag
                            .GenMem.Tipo = -15
                            .GenMem.Parent = s1
                            Ribs.GenMem.AppesiAdd(s1)
                            AggCoordN(.GenMem)
                        End With
                        j = j + 1
                    Next
                    '??????????????????????????????????
                    'chi è s dopo il ciclo precedente ?
                    '??????????????????????????????????
                    'If nribs Mod 2 = 1 Then
                    ' s1 = New Striscia
                    ' s.Copia(s1)
                    ' With s1
                    ' .GenMem.posizione.Anomal = Str(-90)
                    ' .GenMem.Denom = "Ribs" & Trim(Str(j)) & Tag
                    ' .GenMem.Tipo = -15
                    ' .GenMem.Parent = s1
                    ' Ribs.GenMem.AppesiAdd(s1)
                    ' dy = R
                    ' Y = Altezza - SpesBase - dy
                    ' .Lunghezza = Y
                    ' AggCoordN(.GenMem)
                    ' End With
                    ' j = j + 1
                    ' End If
                Next
            End If
            .Leggi(Inizio.DiscoRam, CShort(0))
        End With
    End Sub
    Public Sub AltriDati()
        Dim d As Single
        Dim t As New DataTable
        Dim SP, Tabella, SQL As String
        Dim tSerie As New DataTable
        Dim tt As DataView
        Dim i As Integer
        d = Diametro
        If d = 0 Then Exit Sub
        db = New OleDbConnection(Conn & Monitor.Motore.Inizio.Archdir & "\Selle.mdb" & ConnFine)
        cmddb = New OleDbDataAdapter("SELECT * FROM Catalogo WHERE Listindex =" & Str(StandardSEl - 1), db)
        cmddb.Fill(t)
        On Error GoTo ErrSt
        StandardStr = CStr(t.Rows(0)("StandardSEl"))
        Tabella = CStr(t.Rows(0)("Tabella"))
        t.Dispose()
        On Error GoTo ErrTab
        If sempor Then SP = "SEM" Else SP = "POR"
        SQL = "SELECT * FROM " & Tabella & " WHERE StandardSEl =" & Str(StandardSEl)
        SQL = SQL & " AND SemplicePortante ='" & SP & "'"
        cmddb = New OleDbDataAdapter(SQL, db)
        cmddb.Fill(t)
        SQL = "SELECT DISTINCT Serie FROM " & Tabella & " WHERE StandardSEl =" & Str(StandardSEl)
        SQL = SQL & " AND SemplicePortante ='" & SP & "'"
        Dim cmddbS As New OleDbDataAdapter(SQL, db)
        cmddbS.Fill(tSerie)
        tt = New DataView(t)
        For i = 0 To tSerie.Rows.Count - 1
            '????????????????????
            tt.RowFilter = "Serie =" & CStr(tSerie.Rows(i)("Serie"))
            '?????????????????
        Next
ExSt:
        t.Dispose()
        db.Close()
        Exit Sub
ErrSt:
        MsgBox("Non è stato trovato lo StandardSEl n°" & Str(StandardSEl) & "in libreria", MsgBoxStyle.Critical)
        Resume ExSt
ErrTab:
        MsgBox("Non sono stati trovati valori StandardSEl nella tabella" & Tabella, MsgBoxStyle.Critical)
        Resume ExSt
    End Sub
    Public Overloads Sub Copia(ByRef A As Sella)
        If A Is Nothing Then A = New Sella
        A.Storta = Storta
        A.Larghezza = Larghezza
        A.SorAngSel = SorAngSel
        A.Altezza = Altezza
        A.AltSopra = AltSopra
        A.SpesBase = SpesBase
        A.LargBase = LargBase
        A.LungBase = LungBase
        A.nribs = nribs
        A.DistRib1 = DistRib1
        A.DistRib2 = DistRib2
        A.DistRib3 = DistRib3
        A.SpRibs = SpRibs
        A.SpCost = SpCost
        A.SpRinf = SpRinf
        A.LargRinfShell = LargRinfShell
        A.LargRinfBase = LargRinfBase
        A.CI = CI
        A.FixSlid = FixSlid
        A.sempor = sempor
        A.TipoMat = TipoMat
        A.StandardSEl = StandardSEl
        A.StandardStr = StandardStr
        A.Serie = Serie
        A.IndMatRinf = IndMatRinf
        GenMem.Copia(A.GenMem)
        A.GenMem.Parent = A
        If Not Rinforzo Is Nothing Then
            A.Rinforzo = New Cilindro
            Rinforzo.Copia((A.Rinforzo))
            A.Rinforzo.GenMem.posizione.SuChi = A
            A.GenMem.AppesiAdd((A.Rinforzo))
        End If
        If Not PiasBase Is Nothing Then
            A.PiasBase = New Striscia
            PiasBase.Copia((A.PiasBase))
            A.PiasBase.GenMem.posizione.SuChi = A
            A.GenMem.AppesiAdd((A.PiasBase))
        End If
        If Not PiasTesta Is Nothing Then
            A.PiasTesta = New Striscia
            PiasTesta.Copia((A.PiasTesta))
            A.PiasTesta.GenMem.posizione.SuChi = A
            A.GenMem.AppesiAdd((A.PiasTesta))
        End If
        If Not Costola Is Nothing Then
            A.Costola = New clsPolig
            Costola.Copia((A.Costola))
            A.Costola.GenMem.posizione.SuChi = A
            A.GenMem.AppesiAdd((A.Costola))
        End If
        If Not Ribs Is Nothing Then
            A.Ribs = New Raggrupp
            Ribs.Copia((A.Ribs))
            A.Ribs.GenMem.posizione.SuChi = A
            A.GenMem.AppesiAdd((A.Ribs))
        End If
    End Sub
    Public Overloads Sub RimuoviSpeciali(ByRef O As Membratura)
        If O Is Rinforzo Then Rinforzo = Nothing
        If O Is PiasTesta Then PiasTesta = Nothing
        If O Is PiasBase Then PiasBase = Nothing
        If O Is Costola Then Costola = Nothing
        If O Is Ribs Then Ribs = Nothing
    End Sub
End Class