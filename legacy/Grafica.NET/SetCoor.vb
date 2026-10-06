Module SetCoor
    Private Recv, Rec As clsGenMem
    Private lMembro, Membrov As Membratura
    Public Function SetCoordN(Optional ByVal g As clsGenMem = Nothing, Optional ByVal gv As clsGenMem = Nothing) As Boolean
        Try
            If g Is Nothing Then
                lMembro = Membro
                Rec = lMembro.GenMem
                If Rec.posizione.SuChi Is Nothing Then Exit Function
                Recv = Rec.posizione.SuChi.GenMem
            Else
                Rec = g
                Recv = gv
            End If
            lMembro = Rec.Parent
            Membrov = Recv.Parent
            SetCoordN = True
            If Editing And FormDati IsNot Nothing Then
                If FormDati.lstCodPos(0).Enabled Then Rec.posizione.Quota = FormDati.cmbCodPos(0).Text
                If FormDati.lstCodPos(1).Enabled Then Rec.posizione.Anomal = FormDati.cmbCodPos(1).Text
                If FormDati.lstCodPos(2).Enabled Then Rec.posizione.Raggio = FormDati.cmbCodPos(2).Text
                If FormDati.lstCodPos(3).Enabled Then Rec.posizione.DirDiritta = FormDati.cmbCodPos(3).Text
                If FormDati.lstCodPos(4).Enabled Then Rec.posizione.DirTraversa = FormDati.cmbCodPos(4).Text
            End If
            Select Case System.Math.Abs(Recv.Tipo)
                '--------------------------------------------------------------
                Case 0
                    ''       If Lav(0).CalcBaric Then
                    ''            Call Selez(5, False, 1)
                    ''       Else
                    ''            GoSub InLineaPiu
                    ''            Exit Function
                    ''       End If
                    '------------------------------------------------------------------------
                Case 1, 34 ' su Cilindri
                    Select Case CType(System.Math.Abs(Rec.Tipo), TipoMembratura)
                        Case TipoMembratura.FondoEllittico, _
                              TipoMembratura.FondoTorico, _
                              TipoMembratura.FondoSferico, _
                              TipoMembratura.DiscCalFondiPiani, _
                              TipoMembratura.Diaframma
                            FonSuCil() 'Fondi su cilindro
                        Case TipoMembratura.Conoide
                            OidSuCil()  'Conoide su cilindro
                        Case TipoMembratura.Cono
                            ConSuCil() 'Cono su cilindro
                        Case TipoMembratura.BocchStd
                            BocSuCil()
                        Case TipoMembratura.BocchNonStd
                            ForgSuCil() 'bocchello son standard
                        Case TipoMembratura.Curva
                            CurSuCil() 'curva su tronchetto
                        Case TipoMembratura.Sella
                            SelSuCil() 'sella su cilindro
                        Case TipoMembratura.Belts, _
                             TipoMembratura.BL_HH
                            InLineaPiu2() 'Belts
                        Case TipoMembratura.Flangione
                            FlanSuCil() 'flangioni su cilindri
                        Case TipoMembratura.Piastrone
                            If Not PiasCil() Then SetCoordN = False 'piastre su cilindri
                        Case Else : SetStop()
                    End Select
                    '-----------------------------------------------------------------
                Case 2
                    Select Case System.Math.Abs(Rec.Tipo)
                        Case 21
                            CurSuCil() 'curva su tronchetto
                    End Select
                    '----------------------------------------------------------------------
                Case 3, 4, 5, 16
                    Select Case System.Math.Abs(Rec.Tipo)
                        '           Case 0, 3, 4, 5, 13:   Print "Err.imp.SetCoord": End
                        '8-5-99 Case 1, 10, 14:        GoSub BocFon           'Cilindro e bocchello su fondo
                        Case 10, 14
                            BocFon()  'bocchello su fondo
                        Case 2 : SetStop() 'Tubo su fondo
                        Case 6 : SetStop() 'Conoide
                        Case 7
                            ConSuFon() 'Cono su fondo
                        Case 11, 12
                            InLineaMeno() 'Flangioni e piastre su fondi
                        Case Else : SetStop()
                    End Select
                    '---------------------------------------------------------------
                Case 6, 7 'su conoidi e Coni
                    Select Case System.Math.Abs(Rec.Tipo)
                        Case 0, 13 : SetStop()
                        Case 1
                            CilSuCO()
                            '           Case 10, 14:         Call Selez(2, False, 1) 'Cilindri e bocchelli su coni
                        Case 3, 4, 5, 16
                            FonSuCil()  'Fondi su Coni
                        Case 7
                            ConSuCil()  'Coni su coni
                        Case 11
                            FlanSuCil()
                        Case 12
                            If Not PiasCil() Then SetCoordN = False : Exit Function
                            PiasCon()  'Piastre/flangioni su coni
                        Case 25
                            SelSuCil()
                            '           Case 34:             Call Selez(2, True, 7)  'tegola
                        Case Else : SetStop()
                    End Select
                    '-------------------------------------------------------------
                Case 8
                    Select Case System.Math.Abs(Rec.Tipo)
                        Case 31, 32, 33 'SS,tondi,rods
                            DiafTub()
                        Case 12
                            TubiDir()  'su Tubi diritti
                        Case Else
                            DiafTub()
                    End Select
                Case 9
                    Select Case System.Math.Abs(Rec.Tipo)
                        Case 31, 32, 33 'SS,tondi,rods
                            DiafTub()
                        Case 12
                            DiafTub()
                    End Select
                Case 26
                    Select Case System.Math.Abs(Rec.Tipo)
                        Case 12
                            TubiDir()  'su Tubi diritti
                        Case 8, 9
                            InLineaPiu()
                        Case Else : MsgBox("Impossibile tipo " & Str(Rec.Tipo) & "su fasci")
                    End Select
                    '-------------------------------------------------------------
                Case 10
                    Select Case System.Math.Abs(Rec.Tipo)
                        Case 2
                            InLineaMeno()
                            '         Case 10:    Call Selez(2, False, 1)    'cilindro o dilatatore o tegola su cilindro
                    End Select
                    '-------------------------------------------------------------
                Case 11, 12 'su Flangioni,Piastre
                    Select Case System.Math.Abs(Rec.Tipo)
                        Case 1, 3, 4, 5, 16, 34
                            If Not Cil1112() Then SetCoordN = False 'Cilindri,fondi su flangioni e piastre
                        Case 6
                            OidSuPia()
                        Case 7
                            ConSuFon() 'coni su flangioni e piastre
                        Case 10
                            Boc1112() 'Bocchelli su flangioni  e piastre
                            '        Case 14:                     Call Selez(8, False, 1) 'bocch non std su flangioni e piastre
                        Case 12
                            PiasFla()  'Piastre su flangioni
                        Case 11
                            FlanFla() 'Flangioni su flangioni e Piastre
                        Case 8, 9, 13, 26
                            TirSuFla() 'Tiranti e tubi su flangioni e piastre
                        Case 28
                            GuarnizFla() 'Guarnizioni su flangioni e piastre
                        Case 37
                            InLineaMeno()
                            'Case 26:                     GoSub FasSuPia
                    End Select
                    '-------------------------------------------------------------
                Case 18 'su dilatatori
                    '     Call Selez(2, False, 1)
                    '-----------------------------------------------------------------
                Case 21
                    Select Case System.Math.Abs(Rec.Tipo)
                        Case 1, 2
                            FonSuCil() 'tronchetto su curva
                    End Select
                    '----------------------------------------------------------------------
                Case 28 'Guarnizioni
                    Select Case System.Math.Abs(Rec.Tipo)
                        Case 11 ' Flangioni
                            If CType(lMembro, Flangione).SottoTipo < 4 Then
                                Rec.posizione.Quota = "Far " 'cmbCodPos(0).Text
                                Rec.posizione.DirDiritta = "=-" 'cmbCodPos(3).Text
                            Else
                                '                Call Selez(24, False, 1)
                                CPiu()
                            End If
                        Case 10, 14 'Bocchelli
                            Rec.posizione.Quota = "Far "
                            Rec.posizione.DirDiritta = "=-"
                        Case 12 'Piastre su guarnizioni
                            Select Case CType(lMembro, Piastrone).SottoTipo
                                Case SottoTipoPiastrone._1_DueCodoliEsterni, SottoTipoPiastrone._2_UnoInternoUnoEsterno
                                    NoPiasGuar()
                                Case SottoTipoPiastrone._3_FlangLMSaldLT : Rec.posizione.DirDiritta = "=+"
                                Case SottoTipoPiastrone._4_BiFlangSenzaEstensione
                                    Piastra6()
                                Case SottoTipoPiastrone._5_TipoCoperchio : Rec.posizione.DirDiritta = "=+"
                                Case SottoTipoPiastrone._6_BiFlangConEstensione, SottoTipoPiastrone._8_AvvitataFondoCassa
                                    Piastra6()
                            End Select
                    End Select
                    '-------------------------------------------------------------------
                    '   Case 13: Call Selez(2, True, 1)  'Tiranti
                    '------------------------------------------------------------------
                Case Else : SetStop()
            End Select
        Catch ex As Exception
            MessageBox.Show(ex.Message + vbCrLf + ex.StackTrace)
        End Try
    End Function
    '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    Private Sub InLineaPiu()
        Rec.posizione.Quota = "Near End"
        InLineaPiu2()
    End Sub
    Private Sub InLineaPiu2()
        Rec.posizione.Anomal = "N.A." 'cmbCodPos(1).Text
        InLineaPiu1()
    End Sub
    Private Sub InLineaPiu1()
        If Rec.posizione.Raggio.IndexOf("Lato") = -1 Then Rec.posizione.Raggio = "N.A." 'cmbCodPos(2).Text
        InLineaPiu3()
    End Sub
    Private Sub InLineaPiu3()
        Rec.posizione.DirDiritta = "=+"
        Rec.posizione.DirTraversa = "Auto"
    End Sub
    Private Sub InLineaMeno()
        InLineaPiu()
        Rec.posizione.DirDiritta = "=-"
    End Sub
    Private Sub InLineaMeno1()
        InLineaPiu1()
        Rec.posizione.DirDiritta = "=-"
    End Sub
    Private Sub InLineaMeno3()
        InLineaPiu3()
        Rec.posizione.DirDiritta = "=-"
    End Sub
    Private Sub CPiu()
        If Mid(Rec.posizione.Quota, 6, 1) = "C" Then
            Rec.posizione.DirDiritta = "=+"
        Else
            Rec.posizione.DirDiritta = "=-"
        End If
    End Sub
    Private Sub Cmeno()
        If Mid(Rec.posizione.Quota, 6, 1) = "C" Then
            Rec.posizione.DirDiritta = "=-"
        Else
            Rec.posizione.DirDiritta = "=+"
        End If
    End Sub
    Private Sub Mmeno()
        If Mid(Rec.posizione.Quota, 6, 1) = "M" Then
            Rec.posizione.DirDiritta = "=-"
        Else
            Rec.posizione.DirDiritta = "=+"
        End If
    End Sub
    Private Sub Piastra6()
        '                Call Selez(13, False, 1)
        CPiu()
    End Sub
    Private Sub Piastra6a()
        '                Call Selez(13, False, 1)
        Cmeno()
    End Sub
    Private Function CilPias() As Boolean
        CilPias = True
        Try
            Select Case CType(Membrov, Piastrone).SottoTipo
                Case SottoTipoPiastrone._4_BiFlangSenzaEstensione, _
                     SottoTipoPiastrone._5_TipoCoperchio, _
                     SottoTipoPiastrone._6_BiFlangConEstensione : CilPias = False
                Case SottoTipoPiastrone._1_DueCodoliEsterni, _
                     SottoTipoPiastrone._2_UnoInternoUnoEsterno
                    Cmeno()
                Case SottoTipoPiastrone._3_FlangLMSaldLT, _
                     SottoTipoPiastrone._7_FlangLTSaldLM
                    Stop
                    If System.Math.Abs(Rec.Tipo) = 34 Then
                        Stop
                        'cmbCodPos(1).Text = cmbCodPos(0).Text
                        'cmbCodPos(0).Text = "N.A."
                        'cmbCodPos(3).Text = "=+"
                    Else
                        'cmbCodPos(3).Text = "=+"
                        'cmbCodPos(0).Text = "Lato Mantello"
                    End If
            End Select
        Catch e As Exception
            MessageBox.Show(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Function
    Private Function PiasCil() As Boolean
        PiasCil = True
        Select Case CType(lMembro, Piastrone).SottoTipo
            Case SottoTipoPiastrone._4_BiFlangSenzaEstensione, _
                 SottoTipoPiastrone._5_TipoCoperchio, _
                 SottoTipoPiastrone._6_BiFlangConEstensione : PiasCil = False
            Case SottoTipoPiastrone._1_DueCodoliEsterni, _
                 SottoTipoPiastrone._2_UnoInternoUnoEsterno ' jAlg = 10  
                Selez10()
            Case SottoTipoPiastrone._3_FlangLMSaldLT, _
                 SottoTipoPiastrone._7_FlangLTSaldLM
                If Rec.posizione.Quota.Substring(0, 1) = "N" Then
                    InLineaPiu1()
                Else
                    InLineaMeno1()
                End If
        End Select
    End Function
    Private Sub Selez10()
        If Rec.posizione.Quota.Substring(0, 2) = "Ne" Then
            If Mid(Rec.posizione.Anomal, 6, 1) = "C" Then
                InLineaMeno3()
            Else
                InLineaPiu3()
            End If
        Else
            If Mid(Rec.posizione.Anomal, 6, 1) = "C" Then
                InLineaPiu1()
            Else
                InLineaMeno1()
            End If
        End If
    End Sub
    Private Sub PiasCon()
        'If Mid(Recv.posizione.Raggio, 6, 1) = "P" Then
        If Rec.posizione.Quota.Substring(0, 2) = "Ne" Then
            Rec.posizione.Raggio = "Lato Grande" 'cmbCodPos(2).Text
        Else
            Rec.posizione.Raggio = "Lato Piccolo"
        End If
    End Sub
    Private Sub ConSuCil()
        '             Call Selez(11, False, 1)
        If Mid(Rec.posizione.Raggio, 6, 1) = "G" Then Rec.posizione.NearFar = "N" Else Rec.posizione.NearFar = "F" 'cmbCodPos(1).Text
        If Rec.posizione.Quota.Substring(0, 1) = Rec.posizione.NearFar.Substring(0, 1) Then
            InLineaMeno1()
        Else
            InLineaPiu1()
        End If
    End Sub
    Private Sub Orienta(ByVal Rec As clsGenMem)
        If Mid(Rec.posizione.Raggio, 6, 1) = "G" Then 'cmbCodPos(0).Text
            Rec.posizione.NearFar = "N"
            InLineaMeno3()
        Else
            Rec.posizione.NearFar = "F"
            InLineaPiu3()
        End If
    End Sub
    Private Sub Orienta1(ByVal Rec As clsGenMem)
        If Mid(Rec.posizione.Raggio, 6, 1) = "G" Then 'cmbCodPos(2).Text
            Rec.posizione.NearFar = "N"
            If Mid(Rec.posizione.Quota, 6, 1) = "C" Then
                InLineaMeno3()
            Else
                InLineaPiu3()
            End If
        Else
            Rec.posizione.NearFar = "F"
            If Mid(Rec.posizione.Quota, 6, 1) = "C" Then
                InLineaPiu3()
            Else
                InLineaMeno3()
            End If
        End If
    End Sub
    Private Sub OidSuPia()
        If System.Math.Abs(Recv.Tipo) = 11 Then
            Stop
            '  cmbCodPos(0).Text = cmbCodPos(2).Text
            '                Call Selez(17, False, 2) 'Conoidi su flangioni
            Orienta(Rec)
            'cmbCodPos(1).Text = "+N"
            'cmbCodPos(2).Text = cmbCodPos(0).Text
            'cmbCodPos(0).Text = "N.A."
        Else
            '            Testo = cmbCodPos(2).Text
            '            cmbCodPos(2).Text = cmbCodPos(1).Text
            '            cmbCodPos(1).Text = cmbCodPos(0).Text
            '            cmbCodPos(0).Text = Testo
            '                Call Selez(18, False, 2) 'Conoidi su piastre
            Orienta1(Rec)
            '            Testo = cmbCodPos(2).Text
            '            cmbCodPos(2).Text = cmbCodPos(0).Text
            '            cmbCodPos(0).Text = cmbCodPos(1).Text
            '            cmbCodPos(1).Text = Testo
        End If
    End Sub
    Private Sub ConSuFon()
        If System.Math.Abs(Recv.Tipo) = 12 Then
            Stop
            '            cmbCodPos(1).Text = cmbCodPos(0).Text
            Orienta1(Rec)
            '           cmbCodPos(0).Text = cmbCodPos(1).Text
        Else
            Stop
            '            cmbCodPos(0).Text = cmbCodPos(1).Text
            Orienta(Rec)
            'cmbCodPos(2).Text = cmbCodPos(0).Text
            '           cmbCodPos(0).Text = "N.A."
        End If
    End Sub
    Private Sub FlanSuCil()
        Dim x As Short
        Dim Correz As Single
        With CType(lMembro, Flangione)
            If .SottoTipo = 4 Then  'Flangione bicodolo
                ' jAlg = 23
                Selez10()
            End If ' Else Call Selez(9, True, 2)
            If .SottoTipo < 4 Then
                If Rec.posizione.Quota.Substring(0, 1) = "N" Then
                    InLineaMeno1()
                Else
                    InLineaPiu1()
                End If
            End If
            If .H = 0 And (.SottoTipo < 4 Or .SottoTipo = 4 And Mid(Rec.posizione.Raggio, 6, 1) = "C") Then 'flangione senza hubcmbCodPos(1).Text
                x = DomSenzaHub()
                If x = 1 Then ' giunzione lap-joint
                    If .SottoTipo = 1 Or .SottoTipo = 4 Then 'Gradino maschio
                        Correz = .SpessBase + .SpessGra
                    Else
                        Correz = .SpessBase - .SpessGra
                    End If
                    SetCorrez(Correz)
                End If
            End If
            If .H2 = 0 And .SottoTipo = 4 And Mid(Rec.posizione.Raggio, 6, 1) = "M" Then 'flangione senza hubcmbCodPos(1).Text
                x = DomSenzaHub()
                If x = 1 Then ' giunzione lap-joint
                    Correz = lMembro.SpessBase + .SpessGra2
                    SetCorrez(Correz)
                End If
            End If
        End With
    End Sub
    Private Sub CilSuCO()
        Select Case System.Math.Abs(Recv.Tipo)
            Case 6 'cilindri su conoidi
                Orienta(Rec)
            Case 7
                ConSuCil()  'cilindri su coni
        End Select
    End Sub
    Private Sub OidSuCil()
        '              Call Selez(16, False, 1)
        If Mid(Rec.posizione.Raggio, 6, 1) = "G" Then 'cmbCodPos(2).Text
            Rec.posizione.NearFar = "N"
            If Rec.posizione.Quota.Substring(0, 1) = "F" Then
                InLineaPiu3()
            Else
                InLineaMeno3()
            End If
        Else
            Rec.posizione.NearFar = "F"
            If Rec.posizione.Quota.Substring(0, 1) = "F" Then
                InLineaMeno3()
            Else
                InLineaPiu3()
            End If
        End If
    End Sub
    Private Sub BocSuCil()
        Dim Correz As Single
        If lMembro.SottoTipo < 5 Then 'bocchello con flangia
            Select Case lMembro.Standard.K3
                Case 1, 2, 3, 4
                    ForgSuCil() 'Bocchello su cilindro,sella su cilindro
                Case Else : MsgBox("Caso 10 n p")
            End Select
        Else 'Flangia da sola
            Select Case lMembro.Standard.K3
                Case 2 'slip-on
                    Correz = lMembro.Standard.Altezza
                    '                       Call Selez(2, True, 6)
                    SetCorrez(Correz)
                Case Else : MsgBox("Caso 10 a n p")
            End Select
            If lMembro.Randa = 0 Then
                Select Case lMembro.GenMem.posizione.Raggio
                    Case "Re"
                        lMembro.Randa = Recv.Parent.Diametro / 2 + Recv.Parent.Spessore
                    Case Else
                        lMembro.Randa = Recv.Parent.Diametro / 2
                End Select
            End If
        End If
    End Sub
    Private Function Cil1112() As Boolean
        Dim x As Short
        Cil1112 = True
        If System.Math.Abs(Recv.Tipo) = 12 Then 'cilindri su piastre
            If Not CilPias() Then Cil1112 = False
        ElseIf System.Math.Abs(Recv.Tipo) = 11 Then  'cilindri su flangioni
            Select Case CType(Membrov, Flangione).SottoTipo
                Case SottoTipoFlangione.GradinoMaschio, SottoTipoFlangione.GradinoFemmina, SottoTipoFlangione.FlangioneRovescio
                    InLineaMeno()
                    'If CType(Membrov, Flangione).H = 0 Then
                    'GoSub DomSenzaHub
                    'cmbCodPos(2).Text = Str$(x)
                    'End If
                Case SottoTipoFlangione.FlangioneBicodolo
                    Cmeno()
                    If CType(Membrov, Flangione).H = 0 And Mid(Rec.posizione.Quota, 6, 1) = "C" Or _
                       CType(Membrov, Flangione).H2 = 0 And Mid(Rec.posizione.Quota, 6, 1) = "M" Then
                        x = DomSenzaHub()
                        Rec.posizione.Raggio = Str(x)
                    End If
                Case SottoTipoFlangione.Transition
                    Mmeno()
                Case SottoTipoFlangione.LockRing
                    Stop
            End Select
        End If
    End Function
    Private Sub BocFon() 'Call Selez(4, False, 1)
        lMembro.SpostLat = GlobalRoutines.ValVir(Rec.posizione.Quota)
    End Sub
    Private Sub BocPiastra()
        Rec.posizione.DirDiritta = "Na" 'cmbCodPos(3).Text
        Rec.posizione.DirTraversa = "Auto" 'cmbCodPos(4).Text
    End Sub
    Private Sub Boc1112()
        If System.Math.Abs(Recv.Tipo) = 12 Then
            Select Case CType(Membrov, Piastrone).SottoTipo
                Case SottoTipoPiastrone._5_TipoCoperchio ' Call Selez(8, False, 1)              'coperchio piano
                Case Else
                    BocPiastra()
            End Select
        Else
            BocPiastra()
        End If
    End Sub
    Private Sub CurSuCil()
        Stop
        'cmbCodPos(4).Text = cmbCodPos(1).Text
        'cmbCodPos(1).Text = "N.A."
    End Sub
    Private Sub PiasFla()
        Select Case CType(lMembro, Piastrone).SottoTipo
            Case SottoTipoPiastrone._1_DueCodoliEsterni, SottoTipoPiastrone._2_UnoInternoUnoEsterno
                NoPiasGuar()
            Case SottoTipoPiastrone._3_FlangLMSaldLT, SottoTipoPiastrone._7_FlangLTSaldLM : Rec.posizione.DirDiritta = "=+"
            Case SottoTipoPiastrone._4_BiFlangSenzaEstensione
                Piastra6()
            Case SottoTipoPiastrone._6_BiFlangConEstensione
                Piastra6()
        End Select
    End Sub
    Private Sub FlanFla()
        If System.Math.Abs(Recv.Tipo) = 11 Then 'flangioni su flangioni
            Rec.posizione.DirDiritta = "=-"
        Else 'flangioni su piastre
            Select Case CType(Membrov, Piastrone).SottoTipo
                Case SottoTipoPiastrone._1_DueCodoliEsterni, _
                     SottoTipoPiastrone._2_UnoInternoUnoEsterno
                    NoPiasGuar()
                Case SottoTipoPiastrone._3_FlangLMSaldLT : Rec.posizione.DirDiritta = "=+"
                Case SottoTipoPiastrone._4_BiFlangSenzaEstensione, _
                     SottoTipoPiastrone._5_TipoCoperchio, _
                     SottoTipoPiastrone._6_BiFlangConEstensione
                    Piastra6()
            End Select
        End If
    End Sub
    Private Sub TirSuFla()
        If Len(RTrim(Rec.posizione.Quota)) = 0 Then InLineaPiu()
        If System.Math.Abs(Recv.Tipo) = 12 Then
            'caso del coperchio piano: orientazione dei bulloni
            If CType(Membrov, Piastrone).SottoTipo = SottoTipoPiastrone._5_TipoCoperchio And _
                Not (System.Math.Abs(Rec.Tipo) = 8 Or System.Math.Abs(Rec.Tipo) = 9 Or _
                                                     System.Math.Abs(Rec.Tipo) = 26) Then
                Rec.posizione.DirDiritta = "=-"
            Else
                Rec.posizione.DirDiritta = "=+"
            End If
        End If
        If System.Math.Abs(Recv.Tipo) = 12 And (System.Math.Abs(Rec.Tipo) = 8 Or System.Math.Abs(Rec.Tipo) = 9 Or System.Math.Abs(Rec.Tipo) = 26) Then
            Select Case CType(Membrov, Piastrone).SottoTipo
                Case SottoTipoPiastrone._7_FlangLTSaldLM 'saldato lato cassa
                    ' If Mid$(cmbCodPos(1).Text, 6, 1) = "C" Then
                    InLineaMeno3()
                Case Else
                    InLineaPiu3()
            End Select
        Else
            '             Acttit% = 1: If Abs(Rec.Tipo) < 13 Then Acttit% = 2
            '             Call Selez(6, False, Acctit%)
        End If
    End Sub
    Private Sub GuarnizFla()
        If Len(RTrim(Rec.posizione.Quota)) = 0 Then InLineaPiu()
        If System.Math.Abs(Recv.Tipo) = 12 Then 'guarnizioni su piastre
            Rec.posizione.DirDiritta = "=-"
            Select Case CType(Membrov, Piastrone).SottoTipo
                Case SottoTipoPiastrone._1_DueCodoliEsterni, _
                     SottoTipoPiastrone._2_UnoInternoUnoEsterno
                    NoPiasGuar()
                Case SottoTipoPiastrone._3_FlangLMSaldLT, _
                      SottoTipoPiastrone._7_FlangLTSaldLM
                    Rec.posizione.DirDiritta = "=-"
                Case SottoTipoPiastrone._4_BiFlangSenzaEstensione, _
                     SottoTipoPiastrone._6_BiFlangConEstensione
                    Piastra6a()
            End Select
        End If
        If System.Math.Abs(Recv.Tipo) = 11 Then 'guarnizioni su flangioni
            If CType(Membrov, Flangione).SottoTipo = 4 Then
                Rec.posizione.DirDiritta = "=-"
                Cmeno()
            End If
        End If
    End Sub
    Private Sub FonSuCil()
        If Rec.posizione.Quota.Length > 0 Then
            If Rec.posizione.Quota.Substring(0, 1) = "N" Then
                InLineaMeno1()
            Else
                InLineaPiu1()
            End If
        Else
            InLineaPiu1()
        End If
    End Sub
    Private Sub ForgSuCil()
        Rec.posizione.DirTraversa = "Auto"
    End Sub
    Private Sub SelSuCil()
        InLineaPiu1()
        Rec.posizione.Anomal = "-N"
    End Sub
    Private Sub DiafTub()
        Rec.posizione.DirDiritta = "=+"
        'TubiDir() da errore perché Rec.Parent è un Raggrupp
    End Sub
    Private Sub TubiDir()
        Select Case CType(Rec.Parent, Piastrone).SottoTipo
            Case SottoTipoPiastrone._7_FlangLTSaldLM
                Select Case Rec.posizione.Quota.Substring(0, 2) 'cmbCodPos(1).Text
                    Case Is = "Ne" : Rec.posizione.DirDiritta = "=-"
                    Case Is = "Fa" : Rec.posizione.DirDiritta = "=+"
                End Select
            Case Else
                Select Case Rec.posizione.Quota.Substring(0, 2) 'cmbCodPos(1).Text
                    Case Is = "Ne" : Rec.posizione.DirDiritta = "=+"
                    Case Is = "Fa" : Rec.posizione.DirDiritta = "=-"
                End Select
        End Select
    End Sub
    Private Sub SetStop()
        'If AddDistinta = 103 Then Return
        Dim Testo As String = HelpStringa(154) + Space$(1) + RTrim$(Rec.Denom) + HelpStringa(155) + Str$(Rec.Tipo)
        Testo = Testo + HelpStringa(156) + Space$(1) + RTrim$(Recv.Denom) + HelpStringa(155) + Str$(Recv.Tipo)
        Testo = Testo + HelpStringa(157) + Space$(1) + RTrim$(Rec.Denom) + HelpStringa(158)
        MsgBox(Inizio.ConvertiCr(Testo))
        Rec.posizione.SuChi = CType(Apparecchio.Elementi(0), Membratura)
    End Sub
    Private Function NoPiasGuar() As Boolean
        NoPiasGuar = False
        MsgBox(" Questo tipo di piastra non ammette guarnizioni o flangioni", MsgBoxStyle.Information)
        Rec.Ind = -Rec.Ind
    End Function
    Private Function DomSenzaHub() As Short
        Dim Stringa(2) As String
        Dim x1 As Short
        x1 = 2 : If Val(Rec.posizione.Raggio) <> 0 Then x1 = 1
        Stringa(1) = HelpStringa(151) '"Giunzione lap-joint"
        Stringa(2) = HelpStringa(152) '"Giunzione set-on"
        Return Monitor.Motore.Quale(2, HelpStringa(153), Stringa, "", x1)
    End Function
    Private Sub SetCorrez(ByVal Correz As Single)
        Select Case Rec.posizione.Quota.Substring(0, 2) '3
            Case Is = "Ne" : Rec.posizione.Raggio = Str(Correz)
            Case Is = "Fa" : Rec.posizione.Raggio = Str(-Correz)
            Case Else
                MsgBox("Caso n p.in SetCoord " & Rec.posizione.Quota)
        End Select '3
    End Sub
End Module
