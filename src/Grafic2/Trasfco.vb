Option Strict Off
Option Explicit On
Imports System.Math
Module Trasfco
    Private Alpha, DRaggio, Spost As Single
    Private Vector As RoutBase1.clsVec3
    Private errtrasf As Short
    Private Dint, Desax, AP As Single
    Private Alfa, Spess, Rgin As Single
    Private NewDesax, Quota, ProdQ As Single
    Private Rvec, Ropening As Single
    Private ProdR, ProdS, HH As Single
    Private Sporgenza, Lung, DS As Single
    Private TipoV1, ifl As Short
    Private txta2, txta1, txta As String
    Private i, junk As Short
    Private Stritxt(5) As String
    Private Correz, Lung1 As Single
    Private Membron, Membrov As Membratura
    Private Piastra As Membratura
    Private Testo As String
    Private Mem As Membratura
    Private Sporgen As Single
    Private Record, Recordv As clsGenMem
    Sub TrasfCoordN(ByRef R As clsGenMem, ByRef Rv As clsGenMem)
        Record = R
        Recordv = Rv
        Try
            If Record.Tipo > 96 Or Record.Tipo = 0 Then Exit Sub
            Vector = New RoutBase1.clsVec3
            Membron = Record.Parent
            Membrov = Recordv.Parent
            'If Record.Tipo = -96 Or Record.Tipo = -19 Then Stop
            Select Case System.Math.Abs(Recordv.Tipo) '1
                '----------------------------------------------------------------------
            Case 0, 1, 6, 7, 18, 34 ' su Cilindri /coni/tubi /dilatatori
                    Record.posizione.RaggioR = Val(Record.posizione.Raggio)
                    Select Case System.Math.Abs(Record.Tipo) '2
                        Case 1
                            If System.Math.Abs(Recordv.Tipo) = 6 Or System.Math.Abs(Recordv.Tipo) = 7 Then
                                Record.posizione.QuotaR = 0
                                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Membrov.Altezza. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                                If Record.posizione.NearFar = "F" Then Record.posizione.QuotaR = Membrov.Altezza
                                Offsetv()
                            Else
                                Altro()
                            End If
                        Case 6
                            Prelim()
                            OffSet()
                        Case 7
                            Prelim()
                        Case 10
                            BocCil()
                        Case 11
                            Prelim() 'Flangioni su cilindri
                            Record.posizione.QuotaR = Record.posizione.QuotaR + Val(Record.posizione.Anomal)
                        Case 12 : If Recordv.Tipo = 0 Then
                                Record.posizione.QuotaR = 0
                            Else
                                PiasSuCil()
                            End If 'piastre su cilindri
                        Case 21
                            Prelim()
                        Case 25
                            Selle()
                        Case 96, 13
                        Case Else
                            Altro()
                    End Select
                    '--------------------------------------------------------------------
                Case 2
                    Select Case System.Math.Abs(Record.Tipo)
                        Case 21, 10
                            Prelim()
                        Case 6
                            Prelim()
                            OffSet()
                        Case 7
                            Prelim()
                        Case Else
                            TrasfStop()
                    End Select
                    '-----------------------------------------------------------------------
                Case 3, 4, 5 'su fondi
                    Select Case System.Math.Abs(Record.Tipo)
                        Case 12 'GOSUB PiasSuCil
                            Record.posizione.QuotaR = 0
                            '             Record.posizione.QuotaR = Record.posizione.QuotaR - Recordv.Dati(2) 'Piedritto
                        Case Else
                            Select Case Left(Record.posizione.Quota, 2) '3
                                Case Is = "Su"
                                    Record.posizione.QuotaR = 0
                                    If Record.posizione.NearFar = "F" Then
                                        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Membrov.Altezza. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                                        Record.posizione.QuotaR = Val(Record.posizione.Quota) + Membrov.Altezza
                                    End If
                                Case Else
                                    Desax = Val(Record.posizione.Quota)
                                    Dint = Membrov.Diametro
                                    AP = CType(Membrov, Fondo).Piedritto '8-5-99
                                    Spess = Membrov.Spessore
                                    If Desax >= Dint / 2 Then
                                        errtrasf = 1
                                        MsgBox("ERRTrasfCoord" & Str(Dint) & Str(Desax))
                                    End If
                                    Record.posizione.RaggioR = Desax
                                    If Left(Record.posizione.Raggio, 2) = "Ri" Then Spess = 0
                                    Select Case Recordv.Tipo '4
                                        Case 3 : Alfa = GlobalRoutines.acos(5.0! / 13) : Rgin = 3 / 16.0! * Dint + Spess
                                        Case 4 : Alfa = GlobalRoutines.acos(4.0! / 9) : Rgin = 1 / 10.0! * Dint + Spess
                                        Case 5 : Alfa = 0 : Quota = System.Math.Sqrt((Dint / 2 + Spess) ^ 2 - Desax ^ 2) - AP
                                    End Select '4
                                    If Alfa > 0 Then
                                        If Desax < Dint * System.Math.Sin(Alfa) Then
                                            Quota = System.Math.Sqrt((Dint + Spess) ^ 2 - Desax ^ 2) + AP - (Dint + Spess - Rgin) * System.Math.Sin(Alfa)
                                        Else
                                            NewDesax = Desax - (Dint / 2 + Spess - Rgin)
                                            Quota = System.Math.Sqrt(Rgin ^ 2 - NewDesax ^ 2) + AP
                                        End If
                                    End If
                                    Record.posizione.QuotaR = Quota
                                    If System.Math.Abs(Record.Tipo) = 10 Or Record.Tipo = 14 Then
                                        Sporg()
                                        Membron.SpostLat = Desax
                                        '           Record.Dati(8) = Dint
                                        '           PUT #IUNA, Record.Ind, Record
                                    End If
                            End Select '3
                    End Select
                    '-------------------------------------------------------------------------
                Case 8, 9
                    Select Case System.Math.Abs(Record.Tipo)
                        Case 31, 32, 33
                            Record.posizione.RaggioR = Val(Record.posizione.Raggio)
                            SSTu() 'SS,tondi,rods su tubi
                        Case 15
                            Record.posizione.RaggioR = Val(Record.posizione.Raggio)
                            DiafTu() 'diaframmi su tubi
                        Case 19
                            DiafTu() 'diaframmi su tubi
                        Case Else
                            SuTubi() 'piastre e piatti su tubi
                    End Select
                    '-------------------------------------------------------------------------
                Case 21 'su curve
                    Select Case System.Math.Abs(Record.Tipo) '3
                        Case 1, 2
                            Prelim()
                            Record.posizione.RaggioR = CType(Membrov, Curva).Raggio * (1 - System.Math.Cos(Membrov.Apertura * PI / 180))
                        Case Else
                            TrasfStop()
                    End Select
                    '-------------------------------------------------------------------------
                Case 26
                    Select Case System.Math.Abs(Record.Tipo) '3
                        Case 8, 9
                            TubPiaS() 'Tubi
                        Case 12
                            SuTubi() 'Piastre su fasci
                    End Select
                Case 10, 11, 12, 14 ' su Flangioni e piastre
                    Select Case System.Math.Abs(Record.Tipo) '3
                        Case 1, 2, 17
                            CilTroBoc() 'Cilindri e tronchetti su bocchelli
                        Case 6, 7
                            ConOidPia() 'Coni e conoidi su piastre e flangioni
                        Case 13
                            TirFla() 'Tiranti
                        Case 8, 9, 37
                            TubPia() 'Tubi e setti
                        Case 10, 14
                            BocCil() 'VisualbasicGoSub BocchPia  'Bocchelli
                        Case 11
                            FlanPia() 'Flangioni su piastre e flangioni:flangioni su flangioni tutto fatto
                        Case 12
                            PiasSuFla() 'Piastre su flangioni
                        Case 16
                            CalPia() 'calotte e dischi
                        Case 28
                            GuarPia() 'Guarnizioni
                        Case 26
                            TubPia()
                    End Select '3
                    '--------------------------------------------------------------------------
                Case 13 'su tiranti
                    Select Case System.Math.Abs(Record.Tipo)
                        Case 11, 12
                            Select Case Left(Record.posizione.Quota, 2)
                                Case Is = Chr(78) & Chr(101)
                                    Record.posizione.QuotaR = 2 * CType(Membrov, clsTirante).StandardTir.Dnom + Val(Record.posizione.Quota)
                                Case Is = Chr(70) & Chr(97)
                                    Record.posizione.QuotaR = Membrov.Lunghezza - 2.0! * CType(Membrov, clsTirante).StandardTir.Dnom + Val(Record.posizione.Quota)
                            End Select
                        Case Else
                            TrasfStop()
                    End Select
                    '----------------------------------------------------------------------------
                Case 25, 19, 37, 38 'su selle e set diaframmi
                    Record.posizione.QuotaR = Val(Record.posizione.Quota)
                    Record.posizione.RaggioR = Val(Record.posizione.Raggio)
                    '----------------------------------------------------------------------------
                Case 28 'su guarnizioni
                    Select Case System.Math.Abs(Record.Tipo)
                        Case 10 'flange
                            '              Y = aFl!(5, K3): C = aFl!(2, K3): L = aFl!(4, K3)
                            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Membron.Standard. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                            If Membron.Standard.K3 = 5 Then Membron.Standard.Altezza = Membron.Standard.Spessore + Membron.Standard.SpessGrad
                            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Membrov.Spess. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Membron.Standard. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                            Record.posizione.QuotaR = Membron.Standard.Altezza + Membrov.Spess
                        Case 14
                            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Membrov.Spess. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Membron.Sporgenza. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                            Record.posizione.QuotaR = Membron.Sporgenza + Membrov.Spess
                        Case 11 'flangioni
                            'Call LookTipoFlangione(Record.Dati(), Look)
                            Select Case Left(Record.posizione.Quota, 2)
                                Case Is = "Ne"
                                    Record.posizione.QuotaR = -CType(Membron, Flangione).H - Membron.Spessore
                                    If Record.Tipo = 11 Then 'flangioni
                                    Else
                                        If Membron.SottoTipo = 1 Then 'Gradino maschio
                                            Record.posizione.QuotaR = Record.posizione.QuotaR - CType(Membron, Flangione).SpessGra
                                        Else
                                            Record.posizione.QuotaR = Record.posizione.QuotaR + CType(Membron, Flangione).SpessGra
                                        End If
                                    End If
                                Case Is = "Fa"
                                    Record.posizione.QuotaR = Membrov.Spess + CType(Membron, Flangione).H + Membron.Spessore
                                    If Record.Tipo = 11 Then 'flangioni
                                    Else
                                        If Membron.SottoTipo = 1 Then 'Gradino maschio
                                            Record.posizione.QuotaR = Record.posizione.QuotaR + CType(Membron, Flangione).SpessGra
                                        Else
                                            Record.posizione.QuotaR = Record.posizione.QuotaR - CType(Membron, Flangione).SpessGra
                                        End If
                                    End If
                            End Select
                        Case 12 'vedi SetCoord
                            Select Case Membron.SottoTipo
                                Case 1, 2 : MsgBox("NoPiasGuar TrasfCoord") : Stop ': u$ = INPUT$(1)' GOSUB NoPiasGuar
                                Case 3, 7
                                    Record.posizione.QuotaR = -CType(Membron, Piastrone).H1 + Membrov.Spess
                                Case 4, 6
                                    Tpiastra4()
                                    Record.posizione.QuotaR = Record.posizione.QuotaR + Membrov.Spess
                                Case 5
                                    Record.posizione.QuotaR = -CType(Membron, Piastrone).H2 + Membrov.Spess
                            End Select
                        Case Else
                            TrasfStop()
                    End Select
                    '----------------------------------------------------------------------------
                Case 31, 32 'su raggrupp
                    Record.posizione.QuotaR = Val(Record.posizione.Quota)
                    Record.posizione.RaggioR = Val(Record.posizione.Raggio)
                Case 36 'su belts
                    Record.posizione.QuotaR = Val(Record.posizione.Quota)
                    '----------------------------------------------------------------------------
            End Select
            Exit Sub
BocchPia:
            If System.Math.Abs(Recordv.Tipo) = 11 Then 'bocchelli su flangioni
                BocchRad()
            Else
                Select Case CType(Membrov, Piastrone).SottoTipo '4
                    Case 5 'coperchio piano
                        If Left(Record.posizione.DirDiritta, 2) = Chr(61) & Chr(43) Then
                            BocchDritt()
                        Else
                            BocchRad()
                        End If
                    Case Else
                        BocchRad()
                End Select '4
            End If
        Catch e As Exception
            MessageBox.Show(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Public Function RaggioN(ByRef Record As clsGenMem, ByRef Recordv As clsGenMem) As Single
        Dim Rvec, Dpiccolo As Single
        Membron = Record.Parent
        Membrov = Recordv.Parent
        If System.Math.Abs(Recordv.Tipo) = 7 Then
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Membrov.Altezza. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            If Membrov.Altezza = 0 Then
                Rvec = 1000
            Else
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Membrov.Altezza. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Membrov.Dgran. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Membrov.Dpicc. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                Rvec = (Membrov.Dgran + (Membrov.Dpicc - Membrov.Dgran) * Record.posizione.QuotaR / Membrov.Altezza) / 2
            End If
        ElseIf System.Math.Abs(Recordv.Tipo) = 6 Then
            Call DpicN(Record, Recordv, Dpiccolo)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Membrov.Altezza. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            If Membrov.Altezza = 0 Then
                Rvec = 1000
            Else
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Membrov.Altezza. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Membrov.Dgran. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                Rvec = (Membrov.Dgran + (Dpiccolo - Membrov.Dgran) * Record.posizione.QuotaR / Membrov.Altezza) / 2
            End If
        ElseIf System.Math.Abs(Recordv.Tipo) = 10 Then  'VisualBasic
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Membrov.DiamInt. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            Rvec = Membrov.DiamInt / 2
        ElseIf Recordv.Tipo = 0 Then
            Rvec = 0
        Else
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Membrov.Diametro. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            Rvec = Membrov.Diametro / 2.0!
        End If
        RaggioN = Rvec
    End Function
    Private Sub BocchRad()
        If Left(Record.posizione.Quota, 1) = "I" Then
            If System.Math.Abs(Recordv.Tipo) = 11 Then Record.posizione.QuotaR = (CType(Membrov, Flangione).H + Membrov.Spessore) / 2
            If System.Math.Abs(Recordv.Tipo) = 12 Then Record.posizione.QuotaR = (CType(Membrov, Piastrone).H1 + Membrov.Spessore) / 2
        End If
        If Left(Record.posizione.Raggio, 2) = "Re" Or Left(Record.posizione.Raggio, 2) = "Bu" Then
            Record.posizione.RaggioR = Membrov.Diamext / 2
            Sporg()
        End If
    End Sub
    Private Sub Sporg()
Sporg:
        'UPGRADE_WARNING: Return ha un nuovo comportamento. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1041"'
        If Recordv.Tipo = 0 Then Exit Sub
300:    If Record.Tipo = 10 Then
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Membron.Standard. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Membron.Sporgenza. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            If Membron.Standard.K3 = 4 Then Membron.Standard.Altezza = Membron.Sporgenza
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Membron.Standard. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Membron.Sporgenza. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            Sporgen = Membron.Sporgenza - Membron.Standard.Altezza
        ElseIf Record.Tipo = 14 Then
            Sporgen = 0
            'Membron.Standard.Altezza = 0: Membron.Sporgenza = 0
        Else
            'UPGRADE_WARNING: Return ha un nuovo comportamento. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1041"'
            Return
        End If
        Select Case System.Math.Abs(Recordv.Tipo)
            Case 0, 1, 11, 34, 10 'VisualBasic
                ProdQ = Record.posizione.CosDiritta.ProdScalar((Record.posizione.CosOrigine))
                If System.Math.Abs(1 - ProdQ) < TOLER Then
                    Record.posizione.RaggioR = Record.posizione.RaggioR + Sporgen
                Else
                    ProdS = Record.posizione.CosDiritta.ProdScalar((Recordv.posizione.CosDiritta))
                    If System.Math.Abs(ProdS) < TOLER Then 'bisogna cambiare angolo
                        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Membron.Standard. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Membron.Sporgenza. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                        Vector.X = Record.posizione.RaggioR * Record.posizione.CosOrigine.X + (Membron.Sporgenza - Membron.Standard.Altezza) * Record.posizione.CosDiritta.X
                        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Membron.Standard. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Membron.Sporgenza. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                        Vector.y = Record.posizione.RaggioR * Record.posizione.CosOrigine.y + (Membron.Sporgenza - Membron.Standard.Altezza) * Record.posizione.CosDiritta.y
                        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Membron.Standard. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Membron.Sporgenza. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                        Vector.Z = Record.posizione.RaggioR * Record.posizione.CosOrigine.Z + (Membron.Sporgenza - Membron.Standard.Altezza) * Record.posizione.CosDiritta.Z
                        Record.posizione.RaggioR = System.Math.Sqrt(Vector.ProdScalar(Vector))
                        Record.posizione.CosOrigine.X = Vector.X / Record.posizione.RaggioR
                        Record.posizione.CosOrigine.y = Vector.y / Record.posizione.RaggioR
                        Record.posizione.CosOrigine.Z = Vector.Z / Record.posizione.RaggioR
                    Else
                        'i due assi non sono perpendicolari (bocchello inclinato longitudinalmente)
                        'bisogna cambiare angolo e quotar
                    End If
                End If
            Case 6, 7
                ProdQ = System.Math.Abs(Record.posizione.CosDiritta.ProdScalar((Recordv.posizione.CosDiritta)))
                ProdR = System.Math.Sqrt(1 - ProdQ * ProdQ)
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Membron.Standard. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Membron.Sporgenza. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                Record.posizione.RaggioR = Record.posizione.RaggioR + (Membron.Sporgenza - Membron.Standard.Altezza) * ProdR
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Membron.Standard. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Membron.Sporgenza. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                Record.posizione.QuotaR = Record.posizione.QuotaR + (Membron.Sporgenza - Membron.Standard.Altezza) * ProdQ
                'per coni e conoidi bisogna correggere anche quotar secondo l'angolo
            Case 3, 4, 5
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Membron.Standard. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Membron.Sporgenza. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                Record.posizione.QuotaR = Record.posizione.QuotaR + Membron.Sporgenza - Membron.Standard.Altezza
            Case 12 'piastre
                If Left(Record.posizione.DirDiritta, 2) = Chr(61) & Chr(43) Then '"=+"
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Membron.Standard. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Membron.Sporgenza. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                    Record.posizione.QuotaR = Record.posizione.QuotaR + Membron.Sporgenza - Membron.Standard.Altezza
                    If Left(Record.posizione.Raggio, 2) = "Re" Then
                        Record.posizione.QuotaR = Record.posizione.QuotaR + CType(Membrov, Piastrone).Spessore
                    End If
                Else
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Membron.Standard. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Membron.Sporgenza. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                    Record.posizione.RaggioR = Record.posizione.RaggioR + Membron.Sporgenza - Membron.Standard.Altezza
                End If
        End Select
    End Sub
    Private Sub Prelim()
        Select Case Left(Record.posizione.Quota, 2) '3
            Case Is = "Ne"
                Record.posizione.QuotaR = 0
                If Record.posizione.NearFar = "F" Then
                    Record.posizione.QuotaR = -Membron.Altezza * Record.posizione.CosDiritta.ProdScalar((Recordv.posizione.CosDiritta))
                End If
            Case Is = "Fa"
                Select Case System.Math.Abs(Recordv.Tipo)
                    Case 6, 7
                        Record.posizione.QuotaR = CType(Membrov, Cono).Altezza
                        'Case 18:      Record.posizione.QuotaR = Recordv.Dati(4)
                    Case 21
                        Record.posizione.QuotaR = CType(Membrov, Curva).Raggio * System.Math.Sin(CType(Membrov, Curva).Apertura * PI / 180)
                    Case Else
                        Record.posizione.QuotaR = Membrov.Lunghezza
                End Select
                If Record.posizione.NearFar = "F" Then
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Membron.Altezza. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                    Record.posizione.QuotaR = Record.posizione.QuotaR - Membron.Altezza * Record.posizione.CosDiritta.ProdScalar((Recordv.posizione.CosDiritta))
                End If
            Case Is = "In"
                CalcLung()
                Record.posizione.QuotaR = Lung / 2
            Case Else
                CalcLung()
                If Val(Record.posizione.Quota) < 0.0! Or (Val(Record.posizione.Quota) > Lung And Recordv.Tipo <> 0) Then
                    '???        EditoreF WindowNext, RTrim$(Archdir) + "\ALGEW1.DAT", "Avviso"
                    Record.posizione.Quota = Str(Lung / 2)
                End If
3170:           Record.posizione.QuotaR = Val(Record.posizione.Quota)
        End Select '3
    End Sub
    Private Sub Altro()
Altro:  Prelim() 'valore preliminare di QuotaR
        Rvec = RaggioN(Record, Recordv)
3205:   Opening() 'Raggio dell'apertura
        Select Case Left(Record.posizione.Raggio, 2) '4
            Case "Ri"
3207:           Record.posizione.RaggioR = Rvec
                If Record.posizione.NearFar = "F" Then
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Membron.Altezza. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                    Record.posizione.RaggioR = Val(Record.posizione.Raggio) + Membron.Altezza
                End If
3209:           SuperSporg()
            Case "Re", "Bu"
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Membrov.Spessore. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                Record.posizione.RaggioR = Rvec + Membrov.Spessore
                If Record.posizione.NearFar = "F" Then
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Membron.Altezza. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                    Record.posizione.RaggioR = Val(Record.posizione.Raggio) + Membron.Altezza
                End If
                SuperSporg()
            Case Is = "N."
                Record.posizione.RaggioR = 0
            Case Else
                Record.posizione.RaggioR = Val(Record.posizione.Raggio)
                If System.Math.Abs(Record.Tipo) = 10 Or System.Math.Abs(Record.Tipo) = 14 Then Sporg()
        End Select '4
    End Sub
    Private Sub Opening()
        If System.Math.Abs(Record.Tipo) = 7 And Record.posizione.NearFar = "F" Then
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Membron.Dpicc. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            Ropening = Membron.Dpicc / 2.0!
        ElseIf System.Math.Abs(Record.Tipo) = 10 Or System.Math.Abs(Record.Tipo) = 14 Then
5001:       Ropening = RaggioBocN(Record)
        ElseIf System.Math.Abs(Record.Tipo) = 17 Then
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Membron.DiamInt. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            Ropening = Membron.DiamInt / 2.0!
        ElseIf System.Math.Abs(Record.Tipo) = 13 Then
            'UPGRADE_WARNING: Return ha un nuovo comportamento. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1041"'
            Exit Sub
        ElseIf Record.Tipo <> 25 Then
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Membron.Diametro. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            Ropening = Membron.Diametro / 2.0!
        End If
    End Sub
    Private Sub SuperSporg()
SuperSporg:
3300:   Sporg()
        '             Record.Dati(11) = 0!    ??????????????????????
        '              PUT #IUNA, Record.Ind, Record
    End Sub
    Private Sub CalcLung()
        Select Case System.Math.Abs(Recordv.Tipo) '4
            Case 1, 34
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Membrov.Lunghezza. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                Lung = Membrov.Lunghezza
            Case 6, 7
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Membrov.Altezza. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                Lung = Membrov.Altezza
                '            Case 8:     Lung = Recordv.Dati(2)
            Case 10
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Membrov.SpesScarpa. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Membrov.Sporgenza. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                Lung = Membrov.Sporgenza - Membrov.SpesScarpa 'VisualBasic
        End Select '4
    End Sub
    Private Sub SporPiastra()
        Piastra = Recordv.posizione.SuChi 'Recordv sono i tubi
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.GenMem. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
        If Piastra.GenMem.Tipo = 26 Then Piastra = Piastra.GenMem.posizione.SuChi
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.GenMem. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
        If Not (Piastra.GenMem.Tipo = 12 Or Piastra.GenMem.Tipo = 0) Then
            Testo = "I tubi di scambio non sono posizionati su una piastra tubiera." & vbCrLf
            Testo = Testo & "Non si può quindi procedere al posizionamento esatto dei diaframmi."
            MsgBox(Testo, MsgBoxStyle.Information)
            Sporgenza = 0
        Else
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.Spessore. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            Sporgenza = Piastra.Spessore
        End If
    End Sub
    Private Sub Standard()
        If Left(Record.posizione.Quota, 2) = "St" Then
            If System.Math.Abs(Record.Tipo) = 13 Then
                Sporgenza = 1.2 * CType(Membron, clsTirante).StandardTir.Dnom
            Else
                Sporgenza = 3
            End If
        Else
            Sporgenza = Val(Record.posizione.Quota)
        End If
    End Sub
    Private Sub OffSet()
        If Mid(Record.posizione.Raggio, 6, 1) = "P" And System.Math.Abs(Record.Tipo) = 6 Then
            Record.posizione.RaggioR = (Membron.Dgran - Membron.Dpicc) / 2
        Else
            Record.posizione.RaggioR = 0
        End If
    End Sub
    Private Sub Tpiastra4v()
        Mem = Membrov
        Tpiastra44()
    End Sub
    Private Sub Tpiastra44()
        If Mem.SottoTipo = 4 Then
            If Mid(Record.posizione.Quota, 6, 1) = Chr(67) Then
                HH = CType(Mem, Piastrone).H1
            Else
                HH = CType(Mem, Piastrone).H2
            End If
        ElseIf Mem.SottoTipo = 6 Then
            HH = CType(Mem, Piastrone).H2
        End If
        If Mid(Record.posizione.Quota, 6, 1) = Chr(67) Then
            Record.posizione.QuotaR = HH 'non c'era il meno
        Else
            Record.posizione.QuotaR = -HH + Mem.Spessore
            '?????????          Risult$(4) = Chr$(61) + Chr$(45)
        End If
    End Sub
    Private Sub Tpiastra4()
        Mem = Membron
        Tpiastra44()
    End Sub
    Private Sub QuotaSuPiastra()
        Select Case Membrov.SottoTipo
            Case 1, 2
                If Mid(Record.posizione.Quota, 6, 1) = "C" Then
                    Record.posizione.QuotaR = 0
                Else
                    Record.posizione.QuotaR = CType(Membrov, Piastrone).H1 + CType(Membrov, Piastrone).H2 + Membrov.Spessore
                End If
            Case 3, 7
                Record.posizione.QuotaR = CType(Membrov, Piastrone).H2 + Membrov.Spessore '- Membrov.H1
        End Select
    End Sub
    Private Sub Offsetv()
        If Mid(Record.posizione.Raggio, 6, 1) = "P" Then
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Membrov.Dpicc. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Membrov.Dgran. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            Record.posizione.RaggioR = -(Membrov.Dgran - Membrov.Dpicc) / 2
        Else
            Record.posizione.RaggioR = 0
        End If
    End Sub
    Private Sub BocCil()
        'UPGRADE_WARNING: Return ha un nuovo comportamento. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1041"'
        If Recordv.Tipo = 0 Then Return
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Membron.TipoMat. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
        If Membron.TipoMat < 5 Then
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Membron.Standard. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            Select Case Membron.Standard.K3
                Case 1, 2, 3, 4
                    Altro()
                Case Else : MsgBox("Caso n p.10 TrasfCoord") : Stop ' u$ = INPUT$(1)
            End Select
        Else
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Membron.Standard. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            Select Case Membron.Standard.K3
                Case 2
                    Prelim()
                    Record.posizione.QuotaR = Record.posizione.QuotaR + Val(Record.posizione.Anomal)
                Case Else : MsgBox("Caso n p.10a TrasfCoord") : Stop ' u$ = INPUT$(1)
            End Select
        End If
    End Sub
    Private Sub PiasSuCil()
        Prelim()
        Select Case CType(Membron, Piastrone).SottoTipo '3
            Case 1, 2
                If Left(Record.posizione.Quota, 2) = "Ne" Then
                    If Mid(Record.posizione.Anomal, 6, 1) = "C" Then
                        '                       Record.posizione.QuotaR = 0
                    Else
                        Record.posizione.QuotaR = Record.posizione.QuotaR - CType(Membron, Piastrone).H1 - CType(Membron, Piastrone).H2 - CType(Membron, Piastrone).Spessore
                    End If
                Else
                    If Mid(Record.posizione.Anomal, 6, 1) = "C" Then
                        '                       Record.posizione.QuotaR = 0
                    Else
                        Record.posizione.QuotaR = Record.posizione.QuotaR + CType(Membron, Piastrone).H1 + CType(Membron, Piastrone).H2 + CType(Membron, Piastrone).Spessore
                    End If
                End If
            Case 3, 7
                If Left(Record.posizione.Quota, 2) = "Ne" Then
                    Record.posizione.QuotaR = Record.posizione.QuotaR - CType(Membron, Piastrone).H2 - CType(Membron, Piastrone).Spessore
                Else
                    Record.posizione.QuotaR = Record.posizione.QuotaR + CType(Membron, Piastrone).H2 + CType(Membron, Piastrone).Spessore
                End If
        End Select '3
        If System.Math.Abs(Recordv.Tipo) = 6 Then Offset1()
    End Sub
    Private Sub Offset1()
        If Mid(Record.posizione.Raggio, 6, 1) = "P" Then
            Record.posizione.RaggioR = (CType(Membrov, Cono).Dgran - CType(Membrov, Cono).Dpicc) / 2
        Else
            Record.posizione.RaggioR = 0
        End If
        'Record.posizione.CosOrigine.X = -Recordv.posizione.CosOrigine.X
        'Record.posizione.CosOrigine.y = -Recordv.posizione.CosOrigine.y
        'Record.posizione.CosOrigine.Z = -Recordv.posizione.CosOrigine.Z
    End Sub
    Private Sub Selle()
        Prelim()
        Select Case Recordv.Tipo
            Case 1, 7
                Record.posizione.RaggioR = 0
            Case 6
                With Recordv.Parent
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Recordv.Parent.Altezza. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Recordv.Parent.Dpicc. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Recordv.Parent.Dgran. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                    Record.posizione.RaggioR = (.Dgran - .Dpicc) * Record.posizione.QuotaR / .Altezza / 2
                End With
        End Select
    End Sub
    Private Sub TrasfStop()
        txta = "Collegamento di " & RTrim(Record.Denom) & " su " & Str(Recordv.Tipo) & vbCrLf
        txta = txta & " non previsto in TrasfCoord. "
        MsgBox(txta, MsgBoxStyle.Critical)
    End Sub
    Private Sub SSTu()
        SporPiastra()
        Record.posizione.QuotaR = -Recordv.posizione.QuotaR + Sporgenza
    End Sub
    Private Sub DiafTu()
        SporPiastra()
        Record.posizione.QuotaR = -Recordv.posizione.QuotaR + Sporgenza
    End Sub
    Private Sub SuTubi()
        Select Case Record.Tipo '3
            Case -15 'setto longitudinale o sealing strips
                ifl = FreeFile()
                FileOpen(ifl, RTrim(Inizio.Archdir) & "\ALGE07.DAT", OpenMode.Input, , OpenShare.Shared)
                txta1 = LineInput(ifl) : txta2 = LineInput(ifl)
                For i = 1 To 5 : Stritxt(i) = LineInput(ifl) : Next
                FileClose(ifl)
                If Record.posizione.QuotaR < Recordv.posizione.QuotaR Then
                    Mem = Record.posizione.SuChi
                    txta = RTrim(Record.Denom) & txta1 '"interferisce con |"
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto ctype(Membron.Genmem,clsGenmem). Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                    txta = txta & RTrim(CType(Membron.Genmem, clsGenMem).Denom) & txta2 ' ". Vuoi correggere?"
                    junk = MsgBox(txta, MsgBoxStyle.YesNo + MsgBoxStyle.Question)
                    If junk = MsgBoxResult.Yes Then
                        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Membron.Lunghezza. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                        Lung = Membron.Lunghezza
                        Correz = Recordv.posizione.QuotaR
                        Lung1 = Lung - 2 * Correz
                        Quota = Correz
                        '                    Stritxt(1) = Stritxt(1) + myStr(Lung, 5, 0, False)
                        '                    Stritxt(2) = Stringtxta2(2) + myStr(Val(Record.posizione.quota), 3, 1, False)
                        '                    Stritxt(3) = Stringtxta2(3) + myStr(Recordv.Dati(2), 5, 0, False)
                        '                    Stritxt(4) = "Lunghezza proposta:"
                        '                    Stritxt(5) = "Quota proposta    :"
                        '                    Risult$(1) = "": Risult$(2) = "": Risult$(3) = ""
                        '                    Risult$(4) = myStr(Lung1, 5, 0, False)
                        '                    Risult$(5) = myStr(quota, 3, 1, False):  LungStr(5) = Len(Risult$(3))
                        '                    For i = 1 To 5: LungStr(i) = Len(Risult$(i)): Next
                        '                    If VisuInput(5, "", "", Stritxt(), Risult$(), LungStr()) = -2 Then Return
                        '                    quota = Val(Risult$(5)): Lung1 = Val(Risult$(4))
                        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Membron.Lunghezza. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                        Membron.Lunghezza = Lung1
                        Record.Pnet0 = CSng(Str(Int(Val(CStr(Record.Pnet0)) * Lung1 / Lung)))
                        Record.posizione.BaricRel.y = Lung1 / 2
                        Record.Note = "correzione"
                        Record.posizione.Quota = Str(Quota)
                        Record.posizione.QuotaR = Quota
                        '                    PUT #IUNA, Record.Ind, Record
                    End If
                End If
            Case 12 'piastre su tubi diritti
                Standard()
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Membron.SottoTipo. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                Select Case Membron.SottoTipo
                    Case 7
                        Select Case Left(Record.posizione.Anomal, 2)
                            Case "Ne"
                                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Membron.Spessore. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                                Record.posizione.QuotaR = Membron.Spessore + Sporgenza
                            Case "Fa"
                                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Membron.Spessore. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Membrov.Lunghezza. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                                Record.posizione.QuotaR = Membrov.Lunghezza - Membron.Spessore - Sporgenza
                        End Select
                    Case Else
                        Select Case Left(Record.posizione.Anomal, 2)
                            Case "Ne" : Record.posizione.QuotaR = Sporgenza
                            Case "Fa"
                                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Membrov.Lunghezza. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                                Record.posizione.QuotaR = Membrov.Lunghezza - Sporgenza
                        End Select
                End Select
        End Select '3
    End Sub
    Private Sub TubPiaS()
        Record.posizione.RaggioR = Val(Record.posizione.Raggio)
        Record.posizione.QuotaR = Val(Record.posizione.Quota)
        '  Set Membrov = Membrov.GenMem.posizione.SuChi
        '  GoSub TubPia
    End Sub
    Private Sub CilTroBoc()
        Record.posizione.QuotaR = Val(Record.posizione.Quota)
        If System.Math.Abs(Recordv.Tipo) = 10 Or System.Math.Abs(Recordv.Tipo) = 14 Then 'su bocchelli
            Record.posizione.RaggioR = 0
        ElseIf System.Math.Abs(Recordv.Tipo) = 11 Then  'su flangioni
            If LTrim(RTrim(Record.posizione.Anomal)) = "1" Then
                Record.posizione.QuotaR = Membrov.Spessore
                If Membrov.SottoTipo = 1 Then 'Gradino maschio
                    Record.posizione.QuotaR = Record.posizione.QuotaR + CType(Membrov, Flangione).SpessGra
                Else
                    Record.posizione.QuotaR = Record.posizione.QuotaR - CType(Membrov, Flangione).SpessGra
                End If
            End If
        Else 'su piastre
            QuotaSuPiastra()
        End If
    End Sub
    Private Sub ConOidPia()
        If System.Math.Abs(Recordv.Tipo) = 12 Then
            QuotaSuPiastra()
        Else
            Record.posizione.QuotaR = 0
        End If
        If Trim(Record.posizione.NearFar) = "F" Then
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Membron.Altezza. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            Spost = Membron.Altezza
            If Mid(Record.posizione.Quota, 6, 1) = "C" Then Spost = -Spost
            Record.posizione.QuotaR = Record.posizione.QuotaR + Spost
        End If
        If System.Math.Abs(Recordv.Tipo) = 11 Then Record.posizione.QuotaR = -Record.posizione.QuotaR
        OffSet()
    End Sub
    Private Sub TirFla()
        Record.posizione.RaggioR = 0
        Standard()
        If System.Math.Abs(Recordv.Tipo) = 11 Then
            Record.posizione.QuotaR = CType(Membrov, Flangione).H - Sporgenza
            'indietro di due diametri bullone
        ElseIf System.Math.Abs(Recordv.Tipo) = 12 Then
            If Membrov.TipoMat > 1 Then Sporgenza = Sporgenza + CType(Membrov, Piastrone).SpessRive
            If Membrov.SottoTipo = 3 Or Membrov.SottoTipo = 7 Then
                If Mid(Record.posizione.Anomal, 6, 1) = "C" Then
                    Record.posizione.QuotaR = Membrov.Spessore + Sporgenza
                Else
                    Record.posizione.QuotaR = -Sporgenza
                End If
            ElseIf Membrov.SottoTipo < 4 Then
                '                   Record.posizione.QuotaR = Look.H1 + Look.T + Sporgenza
                Record.posizione.QuotaR = CType(Membrov, Piastrone).H1 - Sporgenza
            ElseIf Membrov.SottoTipo = 5 Then
                Record.posizione.QuotaR = Membrov.Spessore + Sporgenza
            Else
                Record.posizione.QuotaR = -Sporgenza
            End If
        ElseIf System.Math.Abs(Recordv.Tipo) = 10 Then
            If Membrov.Standard.K3 = 5 Then Membrov.Standard.Altezza = Membrov.Standard.Spessore + Membrov.Standard.SpessGrad
            DS = Membrov.Standard.Altezza - Membrov.Standard.Spessore - Membrov.Standard.SpessGrad - Sporgenza
            If Membrov.Standard.K3 = 4 Then DS = Membrov.Sporgenza - Membrov.Standard.Spessore - Membrov.Standard.SpessGrad - Sporgenza
            Record.posizione.QuotaR = DS
            'indietro di un diametro bullone
        ElseIf System.Math.Abs(Recordv.Tipo) = 14 Then
            Record.posizione.QuotaR = Membrov.Sporgenza - Membrov.Spessore - Sporgenza
        End If
    End Sub
    Private Sub TubPia()
        Record.posizione.RaggioR = Val(Record.posizione.Raggio)
        If Left(Record.posizione.Quota, 2) = "St" Then
            Sporgenza = -3
        Else
            Sporgenza = Val(Record.posizione.Quota)
        End If
        If Not Membrov.GenMem.Tipo = 0 Then
            Select Case Membrov.SottoTipo
                Case 3 'saldata LM+bulloni
                    Sporgenza = -Sporgenza
                Case 5 's.cod. e 1/2 grad a sinistra
                    Sporgenza = Membrov.Spessore + Sporgenza
                Case Is < 3 '2 codoli
                    Sporgenza = CType(Membrov, Piastrone).H1 - Sporgenza
                Case 6 'sandwitch+collar bolts ???
                    Sporgenza = -Sporgenza ' Membrov.Spessore - Sporgenza
                Case 7 'saldatura LC +bullloni ???
                    Sporgenza = -Membrov.Spessore + Sporgenza
                Case 4 'senza codoli gradini a sinistra e destra(come 6?) ???
                    Sporgenza = -Sporgenza 'Membrov.Spessore - Sporgenza
                Case Else
            End Select
        End If
        Record.posizione.QuotaR = -Sporgenza
    End Sub
    Private Sub FlanPia()
        If System.Math.Abs(Recordv.Tipo) = 11 Then 'flangioni su flangioni
            Record.posizione.QuotaR = CType(Membron, Flangione).H + Membron.Spessore
            If Membron.SottoTipo = 2 Then Record.posizione.QuotaR = Record.posizione.QuotaR - CType(Membron, Flangione).SpessGra
            TipoV1 = Membron.SottoTipo
            If Membrov.SottoTipo + TipoV1 <> 3 Then Record.Ind = -Record.Ind : MsgBox("STRANO") : Stop
            Record.posizione.QuotaR = Record.posizione.QuotaR + CType(Membron, Flangione).H + CType(Membrov, Flangione).Spessore
            If Membrov.SottoTipo = 2 Then Record.posizione.QuotaR = Record.posizione.QuotaR - CType(Membrov, Flangione).SpessGra
        Else 'flangioni su piastre
            Select Case Membrov.SottoTipo '4
                Case 3, 7
                    Record.posizione.QuotaR = CType(Membrov, Piastrone).H1 '??
                    TipoV1 = Membrov.SottoTipo
                    Record.posizione.QuotaR = Record.posizione.QuotaR + CType(Membron, Flangione).H + Membron.Spessore
                    If Membron.SottoTipo = 2 Then Record.posizione.QuotaR = Record.posizione.QuotaR - CType(Membron, Flangione).SpessGra
                Case 4, 6
                    Tpiastra4v()
                    Record.posizione.QuotaR = Record.posizione.QuotaR + CType(Membron, Flangione).H + Membron.Spessore
                    If Membron.SottoTipo = 2 Then Record.posizione.QuotaR = Record.posizione.QuotaR - CType(Membron, Flangione).SpessGra
            End Select '4
        End If
    End Sub
    Private Sub PiasSuFla()
        Select Case Membron.SottoTipo '4
            Case 3, 7
                Record.posizione.QuotaR = -CType(Membron, Piastrone).H1 '??
                Record.posizione.QuotaR = Record.posizione.QuotaR + CType(Membrov, Flangione).H + Membrov.Spessore
                If Membrov.SottoTipo = 2 Then Record.posizione.QuotaR = Record.posizione.QuotaR - CType(Membrov, Flangione).SpessGra
                'Look.TipoV = TipoV1
            Case 4, 6
                Tpiastra4()
                Record.posizione.QuotaR = Record.posizione.QuotaR + CType(Membrov, Flangione).H + Membrov.Spessore
                If Membrov.SottoTipo = 2 Then Record.posizione.QuotaR = Record.posizione.QuotaR - CType(Membrov, Flangione).SpessGra
        End Select '4
    End Sub
    Private Sub CalPia()
        If Membron.SottoTipo = 1 Then 'calotta su anello
            ' Alpha = asin(Membron.DiamExt / 2 / (Membron.RaggioCal + Membron.SpessGra))
            ' DRaggio = (Membron.DiamExt - Membron.DiamInt) / 4
            ' Record.posizione.QuotaR = Membron.Spessore / 2 - DRaggio / Tan(Pi / 2 - Alpha)
            Record.posizione.QuotaR = 0 'Membrov.Spessore + Membrov.SpessRive
        ElseIf Membron.SottoTipo = 2 Then  'disco su flangioni e piastre
            MsgBox("Da programmare CalPia in TrasfCoordN")
        ElseIf Membron.SottoTipo = 3 Then  'fondo piano raccordato su flangioni e piastre
            MsgBox("Da programmare CalPia in TrasfCoordN")
        End If
    End Sub
    Private Sub GuarPia()
        Record.posizione.RaggioR = 0
        If System.Math.Abs(Recordv.Tipo) = 11 Then 'guarnizioni su flangioni/anelli fuc.
            Record.posizione.QuotaR = CType(Membrov, Flangione).H + Membrov.Spessore
            If Membrov.SottoTipo = 1 Then 'Gradino maschio
                Record.posizione.QuotaR = Record.posizione.QuotaR + CType(Membrov, Flangione).SpessGra
            Else
                Record.posizione.QuotaR = Record.posizione.QuotaR - CType(Membrov, Flangione).SpessGra
            End If
        ElseIf System.Math.Abs(Recordv.Tipo) = 10 Then  'Bocchelli
            If Membrov.Standard.K3 < 4 Then
                Record.posizione.QuotaR = Membrov.Standard.Altezza
            Else
                Record.posizione.QuotaR = Membrov.Sporgenza
            End If 'aFl!(5, K3)
        ElseIf System.Math.Abs(Recordv.Tipo) = 14 Then  'Bocchelli
            Record.posizione.QuotaR = Membrov.Sporgenza
        ElseIf System.Math.Abs(Recordv.Tipo) = 12 Then  'Guarnizioni su piastre
            Select Case Membrov.SottoTipo '4
                Case 3, 7 'piastra con un codolo
                    '                  Record.posizione.QuotaR = Recordv.Dati(3) + Recordv.Dati(1) + 2! * Record.Dati(5)
                    Record.posizione.QuotaR = CType(Membrov, Piastrone).H1
                Case 4, 6
                    Tpiastra4v() 'piastra senza codoli
            End Select '4
        End If
    End Sub
    Private Sub BocchDritt()
        Record.posizione.QuotaR = 0
        Sporg()
        Record.posizione.RaggioR = Val(Record.posizione.Quota)
    End Sub
End Module