Option Strict Off
Option Explicit On
<Serializable()> Public Class Flangia
    Inherits Membratura
    Private prDiamExt As Single
    Private prSpessore As Single
    Public GradExt As Single 'diametro in mm
    Public GradInt As Single
    Public SpessGrad As Single
    Private prAltezza As Single
    Public x As Single
    Public DiamTr As Single
    Public SpessTr As Single
    Private prDiamInt As Single
    Public Raccordo As Single
    Public BC As Single
    Public NumBolts As Single
    Public DiaBolts As String
    Public DiaFori As Single
    Public PesoTir As Single
    Public Pesonet As Single
    Public Pesolor As Single
    Public DiamGr0 As Single
    Public K1 As Short
    Public K2 As Short
    Public K3 As Short
    Public TabFlan As Short
    Public Facing As Short
    'Public TipoMat As Short
    Public strTipo As String
    Public strRati As String
    Public strDiam As String
    Public DNtiranti As String = "1"
    Private Indep1, Indep2 As Short ', Indep3 As Integer
    '-----------------------------------------------
    '----------------------
    'Public GenMem As clsGenMem
    'Public Variato As Boolean
    Public Annullato As Boolean
    Public Overrides Property Spessore() As Single
        Get
            Return prSpessore
        End Get
        Set(ByVal Value As Single)
            prSpessore = Value
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
    Public Overrides Property Altezza() As Single
        Get
            Return prAltezza
        End Get
        Set(ByVal Value As Single)
            prAltezza = Value
        End Set
    End Property
    Public Sub Scelta(ByRef DiscoR As String, Optional ByRef keep As Boolean = False)
        If Len(RTrim(Inizio.Archdir)) = 0 Then
            Inizio.DiscoRam = DiscoR
            Inizio.Standard()
            Funzioni.DisRut.Init200((Inizio.Archdir))
        End If
        If FormFlangia Is Nothing Then FormFlangia = New frmFlange
        FormFlangia.ShowDialog()
        Annullato = FormFlangia.Annullato
        If Not Annullato Then strValori()
        If Not keep Then
            FormFlangia.Close()
            FormFlangia.Dispose()
            FormFlangia = Nothing
        End If
    End Sub
    Public Sub SceltaSyn(ByRef DiscoR As String, ByRef Acad As AutoCAD.AcadDocument, ByRef f As frmFlange)
        Dim block As AutoCAD.AcadBlock
        Dim BlockRef As AutoCAD.AcadBlockReference
        Dim insPoint(2) As Double
        Dim Nome, Testo As String
        Dim n As Short
        ' Dim Record1 As RoutBase1.modTipi.RecAPRn
        Dim Bocch As New clsBocch
        'For i = 0 To JRECMAX
        'RecordD(i) = Record1
        'Next
        'Dim ff As frmFlange = frmFlange.DefInstance 'allo scopo di IniziaBase
        Monitor.AcadDis = Acad
        If Len(RTrim(Inizio.Archdir)) = 0 Then
            Inizio.DiscoRam = DiscoR
            Inizio.Standard()
            Funzioni.DisRut.Init200((Inizio.Archdir))
        End If
        Posiziona(frmScelFla.DefInstance, f)
R:      frmScelFla.DefInstance.ShowDialog()
        If frmScelFla.DefInstance.OK Then
            Nome = frmScelFla.DefInstance.Nome.Text
            If Len(Nome) = 0 Then
                Testo = "Non è stato fornito un nome per il nuovo blocco."
                MsgBox(Testo, MsgBoxStyle.Exclamation)
                GoTo R
            End If
            If Asc(Nome) < 33 Then
                Testo = "Non è stato fornito un nome valido per il nuovo blocco."
                MsgBox(Testo, MsgBoxStyle.Exclamation)
                GoTo R
            End If
            Do
                n = InStr(Nome, " ")
                If n = 0 Then Exit Do
                Nome = Left(Nome, n - 1) & Right(Nome, Len(Nome) - n)
            Loop
            block = Acad.Blocks.Add(insPoint, Nome)
            Call Funzioni.DisRut.InitAcad(block)
            Call DisFlangiaSola(Bocch, frmScelFla.DefInstance.cmbFacing.SelectedIndex + 1, 5, frmScelFla.DefInstance.Option2(1).Checked, (frmScelFla.DefInstance.Direzione.SelectedIndex))
            BlockRef = Acad.ModelSpace.InsertBlock(insPoint, Nome, 1, 1, 1, 0)
            Acad.Application.ZoomAll()
            AppActivate(Acad.Application.Caption)
        End If
        frmScelFla.DefInstance.Close()
    End Sub

    Public Sub carica(ByRef DiscoR As String)
        If Len(RTrim(Inizio.Archdir)) = 0 Then
            Inizio.DiscoRam = DiscoR
            Inizio.Standard()
            Funzioni.DisRut.Init200((Inizio.Archdir))
        End If
        FormFlangia = New frmFlange 'allo scopo di IniziaBase
        FormFlangia.Show()
        FormFlangia.Visible = False
    End Sub
    Public Sub SetRating(ByRef Rati As Short)
        Dim i As Short
        With FormFlangia
            For i = 0 To .cmbRating.Items.Count - 1
                If Rati = CShort(Val(.cmbRating.Items(i))) Then
                    .cmbRating.SelectedIndex = i
                    K2 = i + 1
                    Exit Sub
                End If
            Next
        End With
    End Sub
    Public Sub SetDiam(ByRef Diam As Single)
        Dim i As Short
        With FormFlangia
            For i = 0 To .cmbDiaN.Items.Count - 1
                If Diam = GlobalRoutines.ConvPoll(.cmbDiaN.Items(i)) Then
                    .cmbDiaN.SelectedIndex = i
                    K1 = i + 1
                    Exit Sub
                End If
            Next
        End With
    End Sub
    Public Overloads Function leggi(Optional ByRef iDia As Short = -1, Optional ByRef iRat As Short = -1, Optional ByRef iFac As Short = -1, _
    Optional ByRef TabFl As Short = -1, Optional ByRef iTipo As Short = 0, Optional ByRef Visual As Boolean = False, _
    Optional ByRef DiscoR As String = "") As Boolean
        leggi = True
        If Not globFlangia Is Me Then
            globFlangia = Me
        End If
        If Len(RTrim(Inizio.Archdir)) = 0 Then
            Inizio.DiscoRam = DiscoR
            Inizio.Standard()
            Funzioni.DisRut.Init200((Inizio.Archdir))
        End If
        If iTipo > 0 Then
            Variato = Variato Or Not (K3 = iTipo)
            K3 = iTipo
        End If
        If TabFl > -1 Then
            Variato = Variato Or Not (TabFlan = TabFl)
            TabFlan = TabFl
        End If
        If FormFlangia Is Nothing Then FormFlangia = New frmFlange
        With FormFlangia
            If iRat > -1 Then
                .cmbRating.SelectedIndex = iRat - 1
                Variato = Variato Or Not (K2 = iRat)
            Else
                Variato = Variato Or Not .cmbRating.SelectedIndex = K2 - 1
                .cmbRating.SelectedIndex = K2 - 1
            End If
            If iFac > -1 Then
                .cmbFacing.SelectedIndex = iFac - 1
                Variato = Variato Or Not (iFac = Facing)
            Else
                Variato = Variato Or Not .cmbFacing.SelectedIndex = Facing - 1
                .cmbFacing.SelectedIndex = Facing - 1
            End If
            If iDia > -1 Then
                Variato = Variato Or Not (iDia = K1)
                .cmbDiaN.SelectedIndex = iDia - 1
            Else
                Variato = Variato Or Not .cmbDiaN.SelectedIndex = K1 - 1
                .cmbDiaN.SelectedIndex = K1 - 1
            End If
            If Variato Then
                If Not .AggiornaMaschere() Then Return False
                Call LeggiTxt()
            End If
            strValori()
            If Visual Then .Vista() Else If Not .Visible Then .Hide()
        End With
        Variato = False
    End Function

    Public Sub LeggiTxt()
        Dim t(17) As System.Windows.Forms.Control
        Dim i As Short
        For i = 0 To 17
            With FormFlangia
                Select Case K3
                    Case 1 : t(i) = .Text1(i)
                    Case 2 : t(i) = .Text2(i)
                    Case 3 : t(i) = .Text3(i)
                    Case 4 : t(i) = .Text4(i)
                    Case 5 : t(i) = .Text5(i)
                    Case Else : MsgBox("Tipo flangia n°" & Str(K3) & "non previsto", MsgBoxStyle.Exclamation)
                        .Close()
                        .Dispose()
                        Exit Sub
                End Select
            End With
        Next
        Diamext = GlobalRoutines.ValVir(t(0).Text)
        Spessore = GlobalRoutines.ValVir(t(1).Text)
        GradExt = GlobalRoutines.ValVir(t(2).Text)
        SpessGrad = GlobalRoutines.ValVir(t(3).Text)
        Altezza = GlobalRoutines.ValVir(t(4).Text)
        x = GlobalRoutines.ValVir(t(5).Text)
        DiamTr = GlobalRoutines.ValVir(t(6).Text)
        SpessTr = GlobalRoutines.ValVir(t(7).Text)
        Diamint = GlobalRoutines.ValVir(t(8).Text)
        Raccordo = GlobalRoutines.ValVir(t(9).Text)
        BC = GlobalRoutines.ValVir(t(10).Text)
        NumBolts = GlobalRoutines.ValVir(t(11).Text)
        DiaBolts = t(12).Text
        DiaFori = GlobalRoutines.ValVir(t(13).Text)
        PesoTir = GlobalRoutines.ValVir(t(14).Text)
        Pesonet = GlobalRoutines.ValVir(t(15).Text)
        Pesolor = GlobalRoutines.ValVir(t(16).Text)
        DiamGr0 = GlobalRoutines.ValVir(t(17).Text)
        With FormFlangia
            K1 = .cmbDiaN.SelectedIndex + 1
            K2 = .cmbRating.SelectedIndex + 1
            Facing = .cmbFacing.SelectedIndex + 1
        End With
    End Sub
    Private Sub strValori()
        Dim dv As DataView
        Dim dr As DataRowView()
        Try
            If K3 = 0 Then
                strTipo = "non def."
            Else
                dv = New DataView(Tipi)
                dv.Sort = "Indice"
                dr = dv.FindRows(Str(K3))
                strTipo = dr(0)("Tipo")
            End If
            dv = New DataView(Diametri)
            dv.Sort = "Indice"
            dr = dv.FindRows(Str(K1))
            strDiam = dr(0)("DiamNom") 'RecFla.Diametro
            dv = New DataView(Ratings)
            dv.Sort = "Indice"
            dr = dv.FindRows(Str(K2))
            strRati = dr(0)("Rating") 'RecFla.Rating
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Public Sub New()
        MyBase.New()
        Variato = True
        Indep1 = False : Indep2 = False
        If globFlangia Is Nothing Then globFlangia = Me
        '     Set Flangia = Me
        If Funzioni Is Nothing Then
            Funzioni = New LibGra : Indep2 = True
        End If
        If Funzioni.DisRut Is Nothing Then
            Funzioni.DisRut = New RoutBase1.Routines
            Indep1 = True
        End If
        DiaBolts = ""
        GenMem = New clsGenMem
        GenMem.Parent = CType(Me, Flangia)
        TabFlan = 1
        K1 = 1 : K2 = 1 : K3 = 1 : Facing = 1
    End Sub
    Protected Overrides Sub Finalize()
        If globFlangia Is Me Then
            If Not CatalogoR Is Nothing Then CatalogoR.Dispose()
            If Not FacValoriR Is Nothing Then FacValoriR.Dispose()
            If Not CatalogoR1 Is Nothing Then CatalogoR1.Dispose()
            If Not CatalogoR2 Is Nothing Then CatalogoR2.Dispose()
            If Not CatalogoR3 Is Nothing Then CatalogoR3.Dispose()
            If Not CatalogoR4 Is Nothing Then CatalogoR4.Dispose()
            If Not CatalogoR5 Is Nothing Then CatalogoR5.Dispose()
        End If
        MyBase.Finalize()
    End Sub
    Public Sub AggTab(ByRef f As Object)
        Call AggDiaN(f)
        Call AggRatings(f)
        Call AggFacings(f)
        Call AggFlangia(f)
    End Sub
    Public Sub AggFlangia(ByVal f As Object)
        Try
            If K1 = 0 Then K1 = 1
            f.cmbDiaN.SelectedIndex = K1 - 1
            If K2 = 0 Then K2 = 1
            f.cmbRating.SelectedIndex = K2 - 1
            If Facing = 0 Then Facing = 1
            f.cmbFacing.SelectedIndex = Facing - 1
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Public Sub AggFacings(ByVal f As Object)
        Dim i As Short
        With CType(f.cmbFacing, ComboBox)
            .Items.Clear()
            ' .DataBindings.Clear()
            Dim r As DataRowView() = dvFacings.FindRows(TabFlan)
            For i = 0 To r.Length - 1
                .Items.Add(r(i).Item("Descrizione"))
            Next
        End With

    End Sub
    Public Sub AggRatings(ByVal f As Object)
        Dim i As Short
        With CType(f.cmbRating, ComboBox)
            .Items.Clear()
            '  .DataBindings.Clear()
            Dim r As DataRowView() = dvRatings.FindRows(TabFlan)
            For i = 0 To r.Length - 1
                .Items.Add(r(i).Item("Rating"))
            Next
        End With
    End Sub
    Public Sub AggDiaN(ByRef f As Object)
        Dim i As Short
        Try
            With CType(f.cmbdian, ComboBox)
                .Items.Clear()
                Dim r As DataRowView() = dvDiametri.FindRows(TabFlan)
                For i = 0 To r.Length - 1
                    .Items.Add(r(i).Item("DiamNom"))
                Next
            End With
        Catch e As Exception
            MsgBox("AggDiaN:" + vbCrLf + e.Message + e.StackTrace)
        End Try
    End Sub
    '  Public Sub AggText(ByRef f As frmFlange)
    '      On Error Resume Next
    '      Dim k As Short
    '      With f
    '         For k = 1 To 17
    '            If k = 13 Then
    '               .Text1(k - 1).Text = "0"
    '               CatalogoR.FindFirst("indTipo=1")
    '               If Not CatalogoR.NoMatch Then .Text1(k - 1).Text = CatalogoR.Fields("Tiranti").Value
    '               .Text2(k - 1).Text = "0"
    '               CatalogoR.FindFirst("indTipo=2")
    '               If Not CatalogoR.NoMatch Then .Text2(k - 1).Text = CatalogoR.Fields("Tiranti").Value
    '               .Text3(k - 1).Text = "0"
    '               CatalogoR.FindFirst("indTipo=3")
    '                If Not CatalogoR.NoMatch Then .Text3(k - 1).Text = CatalogoR.Fields("Tiranti").Value
    '                .Text4(k - 1).Text = "0"
    '                CatalogoR.FindFirst("indTipo=4")
    '                If Not CatalogoR.NoMatch Then .Text4(k - 1).Text = CatalogoR.Fields("Tiranti").Value
    '                .Text5(k - 1).Text = "0"
    '                CatalogoR.FindFirst("indTipo=5")
    '                If Not CatalogoR.NoMatch Then .Text5(k - 1).Text = CatalogoR.Fields("Tiranti").Value
    '            ElseIf k < 3 Or k > 4 Then
    '                .Text1(k - 1).Text = "0"
    '                CatalogoR.FindFirst("indTipo=1")
    '                If Not CatalogoR.NoMatch Then .Text1(k - 1).Text = GlobalRoutines.myStr(CatalogoR.Fields(k + 3).Value, 5, 2, False)
    '                .Text2(k - 1).Text = "0"
    '                CatalogoR.FindFirst("indTipo=2")
    '                If Not CatalogoR.NoMatch Then
    '                    .Text2(k - 1).Text = GlobalRoutines.myStr(CatalogoR.Fields(k + 3).Value, 5, 2, False)
    '                Else
    '                    .Text3(k - 1).Text = "0"
    '                    .Text3(k - 1).Visible = False
    '                End If
    '                CatalogoR.FindFirst("indTipo=3")
    '                If Not CatalogoR.NoMatch Then
    '                    .Text3(k - 1).Text = GlobalRoutines.myStr(CatalogoR.Fields(k + 3).Value, 5, 2, False)
    '                Else
    '                    .Text4(k - 1).Text = "0"
    '                End If
    '                CatalogoR.FindFirst("indTipo=4")
    '                If Not CatalogoR.NoMatch Then .Text4(k - 1).Text = GlobalRoutines.myStr(CatalogoR.Fields(k + 3).Value, 5, 2, False)
    '                .Text5(k - 1).Text = "0"
    '                CatalogoR.FindFirst("indTipo=5")
    '                If Not CatalogoR.NoMatch Then .Text5(k - 1).Text = GlobalRoutines.myStr(CatalogoR.Fields(k + 3).Value, 5, 2, False)
    '                If k = 6 Then .Text4(5).Text = .Text1(5).Text
    '            End If
    '        Next
    '    End With
    '    On Error GoTo 0
    'End Sub
    Public WriteOnly Property DoveMotore() As RoutBase1.clsMotore
        Set(ByVal Value As RoutBase1.clsMotore)
            Motore = Value
            Inizio = Motore.Inizio
        End Set
    End Property
    Public Function NomeTabella(ByRef TabFlan As Short) As String
        Dim dv As DataView = New DataView(FormFlangia.dsFlange.Tabelle)
        dv.Sort = "Codice"
        dv.Find(Str(TabFlan))
        If dv.Count = 0 Then Return ""
        NomeTabella = CStr(dv(0)("Descrizione"))
    End Function

    Public Overloads Sub Copia(ByRef A As Flangia)
        If A Is Nothing Then A = New Flangia
        A.Diamext = Diamext
        A.Spessore = Spessore
        A.GradExt = GradExt
        A.SpessGrad = SpessGrad
        A.Altezza = Altezza
        A.x = x
        A.DiamTr = DiamTr
        A.SpessTr = SpessTr
        A.Diamint = Diamint
        A.Raccordo = Raccordo
        A.BC = BC
        A.NumBolts = NumBolts
        A.DiaBolts = DiaBolts
        A.DiaFori = DiaFori
        A.PesoTir = PesoTir
        A.Pesonet = Pesonet
        A.Pesolor = Pesolor
        A.DiamGr0 = DiamGr0
        A.K1 = K1
        A.K2 = K2
        A.K3 = K3
        A.TabFlan = TabFlan
        A.Facing = Facing
        A.TipoMat = TipoMat
        A.strTipo = strTipo
        A.strRati = strRati
        A.strDiam = strDiam
        '----------------------
        If Not GenMem Is Nothing Then GenMem.Copia(A.GenMem)
        A.GenMem.Parent = A
    End Sub
    Public Function CercaDiametro(ByRef Diametro As String) As Short
        Dim dv As DataView = New DataView(Diametri)
        dv.RowFilter = "Codice=" & Str(TabFlan) & " AND TRIM(DiamNom)='" & Trim(Diametro) & "'"
        If dv.Count = 0 Then
            MsgBox("Diametro non trovato in CercaDiametro")
            CercaDiametro = 1
        Else
            CercaDiametro = dv(0)("Indice")
        End If
    End Function
End Class