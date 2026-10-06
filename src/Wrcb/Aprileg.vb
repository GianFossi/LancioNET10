Option Strict Off
Option Explicit On 
Imports RoutBase1
Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary 'Namespace for BinaryFormatter
Module Aprileg
    Private FileDes As String
    '0 Flangia 1 guarnizione 2 bulloni 3 coperchio 4 piastra  5... bocchelli sul coperchio.
    Private CoorLoc, Vec, DirLoc As RoutBase1.clsVec3
    Private Primo As Boolean
    Private iCarica As Integer
    Private Dist As Single
    Private ifl As Short
    Private j, k, ik, iQ, jk As Short
    Private Nsav, indice, NumInFila As Short
    Private TrasForm(3, 3) As Single
    Function ApriLeggi() As Boolean
        Dim i As Short
        ApriLeggi = True
        Try
            If AddDistinta > 0 Then 'calcolo chiamato da PPSM su una particolare membratura
                Suffix = "NOZ"
                objWRCB.commessa = RTrim(Monitor.clsInizio.Workdir) & "\A" & RTrim(job.Comm.Arch) & Chr(92) & job.Comm.Ind.Item(job.Comm.NumAs).Data.File & Suffix & Monitor.Motore.Problem.Extension
95:             Config.NBocch = 10 : Config.Casi = 2 : objWRCB.Ridimens()
                For iB = 1 To Config.NBocch
                    Geom(iB).Carichi(1).CaseDescription = "Radial thrust outward"
                    Geom(iB).Carichi(2).CaseDescription = "Radial thrust inward"
                Next  'z1
                iB = 0
90:             If IO.File.Exists(objWRCB.commessa) Then Carica()
94:             If Not TransWND() Then Return False
                With Apert.DefInstance
                    ._Frames_1.Visible = True
                    ._Frames_0.Visible = True
                    ._Frames_2.Visible = True
                    .PictureBox1.Visible = False
                End With
                AggAlbero()
                For i = 1 To Config.NBocch
                    Gia297(i) = False
                Next
                TitoloDoc()
                Carica()
            Else 'calcolo stand-alone
                job.Comm.NumAs = 1
                objWRCB.commessa = ""
                If Not CaricaFile() Then objWRCB.commessa = ""
                If objWRCB.commessa.Length = 0 Then ApriLeggi = False : Exit Function
            End If 'ff
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Function
    '    Private Sub CercaPad()
    'CercaPad:
    '89:     indice = Rec2Buf(0).Ind
    '        Do
    '            indice = indice + 1
    '            FileGet(IUNA, Rec2Buf(2), indice)
    '            If Rec2Buf(2).Tipo = -17 Then Exit Do
    '            If EOF(IUNA) Or Rec2Buf(2).Tipo > 0 Then MsgBox("Errore pad in ApriLeggi")
    '        Loop
    '        Geom(Config.NBocch).Padd = Rec2Buf(2).Dati(1)
    '        Geom(Config.NBocch).PadT = Rec2Buf(2).Dati(3)
    '    End Sub
    '    Private Sub Registr()
    '        Geom(Config.NBocch).Mark = Rec2Buf(0).Denom
    '        Geom(Config.NBocch).Size = Rec2Buf(0).DIME
    '        Geom(Config.NBocch).Buco = 0
    '        Geom(Config.NBocch).Forma = 0
    '        Geom(Config.NBocch).Ind = Rec2Buf(0).Ind
    '        Rec2Buf(2) = Rec2Buf(1)
    '2150:   Call RegMatS()
    '    End Sub
    Private Sub Regmat()
        If Primo Or Config.Analisi = 0 Then Exit Sub
91:     Geom(Config.NBocch).NozzMat = Matdim(2 * Config.NBocch).MatStr
        For iC = 1 To Config.Casi
            If Geom(Config.NBocch).Carichi(iC).AllowNoz = 0 Then
92:             Call SubTensAmm(Geom(Config.NBocch).Carichi(iC).DesTemp, Geom(Config.NBocch).Carichi(iC).AllowNoz, 2 * Config.NBocch)
            End If 'a
        Next  'z11
    End Sub
    Private Sub RegMatS()
        If Primo Then Exit Sub
        Geom(Config.NBocch).ShellMat = Matdim(2 * Config.NBocch - 1).MatStr
        For iC = 1 To Config.Casi
            If Geom(Config.NBocch).Carichi(iC).AllowShe = 0 Then
                Call SubTensAmm(Geom(Config.NBocch).Carichi(iC).DesTemp, Geom(Config.NBocch).Carichi(iC).AllowShe, 2 * Config.NBocch - 1)
            End If 'b
        Next  'z12
        'UPGRADE_WARNING: Return ha un nuovo comportamento. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1041"'
    End Sub
    '    Private Sub CercaCil()
    '        indice = Rec2Buf(0).posspa.SuChi
    '        FileGet(IUNA, Rec2Buf(2), indice)
    '        If Rec2Buf(2).Tipo < 1 Or Rec2Buf(2).Tipo > 2 Then
    '            MsgBox("Errore tronchetto")
    '        End If 'www
    '    End Sub
    '    Private Sub CercaTronch()
    '        If Primo Then Exit Sub
    '        indice = Rec2Buf(0).Ind
    '        Do
    '            indice = indice + 1
    '            FileGet(IUNA, Rec2Buf(2), indice)
    '            If Rec2Buf(2).Tipo = -2 Then Exit Do
    '83:         If EOF(IUNA) Or Rec2Buf(2).Tipo > 0 Then
    '                Call CercaCil()
    '                Exit Do
    '            End If
    '        Loop
    '        Geom(Config.NBocch).R0 = Rec2Buf(2).Dati(2) / 2
    '        Geom(Config.NBocch).T0 = Rec2Buf(2).Dati(3)
    '        Call Regmat()
    '    End Sub
    Private Sub TransWND0()
        '      For k = 1 To job.Comm.Ind.Count
        '      FileGet(IUNA, Rec2Buf(0), k)
        '      If EOF(IUNA) Or Rec2Buf(0).Ind = 0 Then Exit For
        '      If Rec2Buf(0).Tipo = 10 Then
        '      Config.NBocch = Config.NBocch + 1
        '      CheckMem()
        '      ElseIf Rec2Buf(0).Tipo = 14 Then
        '          Config.NBocch = Config.NBocch + 1
        '          CheckMem()
        '      End If 'zzz
        'Contk:  Next k
    End Sub
    Private Function Carichi() As Boolean
        Dim ifl As Integer
        Dim a As String
2240:   FileDes = RTrim(Monitor.clsInizio.Workdir) & "\A" & RTrim(job.Comm.Arch) & Chr(92) & job.Comm.Ind.Item(job.Comm.NumAs).Data.File & ".DES"
        ifl = FreeFile()
        FileOpen(ifl, FileDes, OpenMode.Random, , , Len(DatProg))
        If LOF(ifl) > 0 Then
            FileGet(ifl, DatProg, 1)
        Else
            a = "Non sono stati forniti i Dati di Progetto. |"
            a = a & "E' necessario farlo accedendo al menuitem  |"
            a = a & "'Dati di Progetto' del programma PPSM.     |"
2260:       MsgBox(Monitor.clsInizio.ConvertiCr(a))
            FileClose(ifl)
            Return False
        End If 'r
        FileClose(ifl)
        If DatProg.UniMis = 2 Then Config.UnitSis = 1 Else Config.UnitSis = 0
        If Config.Casi = 0 Then Config.Casi = 1
        If Config.Chart < 1 Then Config.Chart = 1
        Config.Docu = RTrim(job.Comm.Arch) & "-SC-001"
        Call SubConfig()
        Select Case DatProg.UniMis
            Case 2
                DatProg.PressTubi = DatProg.PressTubi / PSI
                DatProg.PressMant = DatProg.PressMant / PSI
                DatProg.TempTubi = (DatProg.TempTubi - 32) / 1.8
                DatProg.TempMant = (DatProg.TempMant - 32) / 1.8
        End Select
        If DatProg.Lati <= 1 Then
            For iB = 1 To Config.NBocch
                For iC = 1 To Config.Casi
                    Geom(iB).Carichi(iC).DesPress = DatProg.PressMant
                    Geom(iB).Carichi(iC).DesTemp = DatProg.TempMant
                Next  'z5
                Geom(iB).Corr = DatProg.CorrMant
                Geom(iB).CorrN = DatProg.CorrMant
                If DatProg.Vacuum = 0 Then
                    Geom(iB).Carichi(2).DesPress = 0
                Else
                    Geom(iB).Carichi(2).DesPress = -15
                    If Config.UnitSis < 2 Then
                        Geom(iB).Carichi(2).DesPress = -15 * MPA
                        If Config.UnitSis = 1 Then Geom(iB).Carichi(2).DesPress = Geom(iB).Carichi(2).DesPress / GRAV
                    End If 's
                End If 't
            Next  'z6
        Else
            Call DeterminLato()
            For iB = 1 To Config.NBocch
                For iC = 1 To Config.Casi
                    If Geom(iB).Lato <= 1 Then
                        Geom(iB).Carichi(iC).DesPress = DatProg.PressTubi
                        Geom(iB).Carichi(iC).DesTemp = DatProg.TempTubi
                        Geom(iB).Corr = DatProg.CorrTubi
                        Geom(iB).CorrN = DatProg.CorrTubi
                    Else
                        Geom(iB).Carichi(iC).DesPress = DatProg.PressMant
                        Geom(iB).Carichi(iC).DesTemp = DatProg.TempMant
                        Geom(iB).Corr = DatProg.CorrMant
                        Geom(iB).CorrN = DatProg.CorrMant
                    End If 'u
                Next  'z7
                Geom(iB).Carichi(2).DesPress = 0
                Select Case DatProg.Vacuum
                    Case 3
                        Geom(iB).Carichi(2).DesPress = -15
                    Case 1
                        If Geom(iB).Lato = 1 Then Geom(iB).Carichi(2).DesPress = -15
                    Case 2
                        If Geom(iB).Lato = 2 Then Geom(iB).Carichi(2).DesPress = -15
                End Select
                If Config.UnitSis < 2 Then
                    Geom(iB).Carichi(2).DesPress = Geom(iB).Carichi(2).DesPress * MPA
                    If Config.UnitSis = 1 Then Geom(iB).Carichi(2).DesPress = Geom(iB).Carichi(2).DesPress / GRAV
                End If 'v
            Next  'z8
        End If 'x
        Return True
    End Function
    Private Sub ProximStudy()
        '        For iB = 1 To Config.NBocch
        '        If Geom(iB).ShellType = 0 And Geom(iB).Incluso = 1 Then
        '2340:       'UPGRADE_WARNING: Get è stato aggiornato a FileGet e ha un nuovo comportamento. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1041"'
        '            FileGet(IUNA, Rec2Buf(0), Geom(iB).IndiceC) 'shell su cui
        '            'UPGRADE_WARNING: Get è stato aggiornato a FileGet e ha un nuovo comportamento. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1041"'
        '            FileGet(IUNA, Rec2Buf(1), Geom(iB).IndiceB) 'record bocchello
        '            TrasForm(1, 1) = Rec2Buf(0).posspa.CosTraversa.X : TrasForm(1, 2) = Rec2Buf(0).posspa.CosTraversa.y : TrasForm(1, 3) = Rec2Buf(0).posspa.CosTraversa.Z
        '            TrasForm(2, 1) = Rec2Buf(0).posspa.CosDiritta.X : TrasForm(2, 2) = Rec2Buf(0).posspa.CosDiritta.y : TrasForm(2, 3) = Rec2Buf(0).posspa.CosDiritta.Z
        '            TrasForm(3, 1) = Rec2Buf(0).posspa.CosTerza.X : TrasForm(3, 2) = Rec2Buf(0).posspa.CosTerza.y : TrasForm(3, 3) = Rec2Buf(0).posspa.CosTerza.Z
        '        End If '11
        '        Next  'z2
        '        For iB = 1 To Config.NBocch
        '2375:   If Geom(iB).Incluso = 1 Then
        '        ik = 0
        '        'UPGRADE_WARNING: Get è stato aggiornato a FileGet e ha un nuovo comportamento. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1041"'
        '        FileGet(IUNA, Rec2Buf(0), Geom(iB).IndiceC)
        '        For iQ = 1 To 4 : Geom(iB).iB(iQ) = 0 : Next
        '        For iC = 1 To Config.NBocch
        '        If Geom(iB).ShellType = 0 And Geom(iB).IndiceC = Geom(iC).IndiceC And iB <> iC And Geom(iB).Incluso = 1 And Geom(iC).Incluso = 1 Then
        '2377:   iQ = Quadrante(iB, iC, Dist)
        '        If Geom(iB).iB(iQ) = 0 Then
        '        Geom(iB).iB(iQ) = iC : Geom(iB).Dist(iQ) = Dist
        '        Else
        '            If Dist < Geom(iB).Dist(iQ) Then
        '        Geom(iB).iB(iQ) = iC : Geom(iB).Dist(iQ) = Dist
        '            End If '22
        '        End If '33
        '        End If '44
        '        Next  'z3
        '        End If
        '        Next  'z4
    End Sub
    Private Sub CheckMem()
        If UBound(Geom) < Config.NBocch Then
            Nsav = Config.NBocch
            Config.NBocch = 2 * Config.NBocch
            Call objWRCB.Ridimens()
            Config.NBocch = Nsav
        End If 'z
    End Sub
    Private Function TransWND() As Boolean
        Dim a As String
        Config.NBocch = 0
2200:   Primo = True
        Call TransWND0()
        If Config.NBocch = 0 Then
            a = "Non è stato trovato alcun bocchello da     |"
            a = a & "calcolare.                                 |"
            MsgBox(Monitor.clsInizio.ConvertiCr(a), MsgBoxStyle.Critical)
            FileClose(ifl)
            Return False
        End If
2220:   If IO.File.Exists(objWRCB.commessa) Or iCarica = 1 Then If Not Carichi() Then Return False
        Config.NBocch = 0
2230:   Primo = False
        Call TransWND0()
        Call ProximStudy()
        Return True
    End Function
    Function Quadrante(ByRef iB As Short, ByRef iC As Short, ByRef Dist As Single) As Short
        'Dim Dir1, Dir2 As RoutBase1.clsVec2
        'DistLong = Abs(IntersLoc(iB).Y - IntersLoc(iC).Y)
        'DistCirc = Sqr((IntersLoc(iB).X - IntersLoc(iC).X) ^ 2 + (IntersLoc(iB).Z - IntersLoc(iC).Z) ^ 2)
        'Raggio = Rec2Buf(0).Dati(2) / 2
        'DistCirc = 2 * Raggio * asin(DistCirc / 2 / Raggio)
        'If DistLong > DistCirc Then
        '   If IntersLoc(iC).Y < IntersLoc(iB).Y Then Quadrante = 1 Else Quadrante = 3
        '   Dist = DistLong
        'Else
        '   Dist1 = Sqr(IntersLoc(iB).X * IntersLoc(iB).X + IntersLoc(iB).Y * IntersLoc(iB).Y)
        '   Dir1.X = IntersLoc(iB).X / Dist1: Dir1.Y = IntersLoc(iB).Y / Dist1
        '   Dist2 = Sqr(IntersLoc(iC).X * IntersLoc(iC).X + IntersLoc(iC).Y * IntersLoc(iC).Y)
        '   Dir2.X = IntersLoc(iC).X / Dist2: Dir2.Y = IntersLoc(iC).Y / Dist2
        '   ang1 = arco(Dir1): ang2 = arco(Dir2)
        '   If ang2 > ang1 Then Quadrante = 2 Else Quadrante = 4
        '   Dist = DistCirc
        'End If
    End Function
    Private Sub Carica()
        Dim a As String
        If AddDistinta > 0 Then
            a = " Vuoi caricare i dati registra-|"
            a = a & "ti nel corso dei calcoli prece-|"
            a = a & "denti?                         |"
            iCarica = MsgBox(Monitor.clsInizio.ConvertiCr(a), MsgBoxStyle.Question + MsgBoxStyle.YesNo)
            If iCarica <> MsgBoxResult.No Then Exit Sub
        End If
        LeggiW(False)
    End Sub
    Private Function CaricaFile() As Boolean
        Dim ContrNome As String = ""
        Dim ContrFile As String = ""
        If Monitor.Motore.Inizio.LavoriSciolti Then
            CaricaFile = Monitor.Motore.Mostra(myAssembly, 2)
        Else
            job = Monitor.Motore.Sceglijob(ContrNome, ContrFile)
            If Len(ContrFile) = 0 Then Exit Function
            If Not job.Selezione Then objWRCB.commessa = "" : Exit Function
            With job.Comm
                If .indice > 0 Then
                    objWRCB.commessa = Monitor.Motore.Inizio.Workdir & "\A" & .Arch & "\" & .Ind.Item(.indice).Data.File & Monitor.Motore.Problem.Extension
                Else
                    objWRCB.commessa = ""
                    Exit Function
                End If
            End With
            ' gencommes = icome.Substring(0, icome.Length - 4)
            '  PrimaPagina = LeggiData()
            Carica()
        End If
    End Function
    Public Function LeggiW(ByVal sonda As Boolean) As Boolean
        Dim j As Short
        Dim Indmat As Short
        Dim fs As New FileStream(objWRCB.commessa, FileMode.Open)
        Try
            Dim bf As New BinaryFormatter
            Config = CType(bf.Deserialize(fs), wrcConfig)
            If sonda Then
                fs.Close()
                Return True
            End If
            Call objWRCB.Ridimens()
            For j = 1 To Config.NBocch
                Geom(j) = CType(bf.Deserialize(fs), typGeom)
                StressLim(1, j) = CType(bf.Deserialize(fs), typStressLim)
            Next  'z9
            For j = 1 To 2 * Config.NBocch
                Matdim(j) = New LibMat.MaterialeNew1
                Indmat = CShort(bf.Deserialize(fs))
                Matdim(j).Indmat = Indmat
                If Matdim(j).Indmat > 0 Then
                    Matdim(j).RecupMat(Trim(Monitor.Motore.Inizio.Archdir))
                End If
            Next  'z10
            job = CType(bf.Deserialize(fs), RoutBase1.clsjob)
            If job.Comm.NumAs < 1 Then job.Comm.NumAs = 1
        Catch e As Exception
            fs.Close()
            If MostraAiuto(IDH_ERR_BADSERIAL, _
            ChiaviMess.MessQuestion Or ChiaviMess.MessYesNo, _
            globalRoutines.FormatS(Helpstringa(IDH_ERR_BADSERIAL), objWRCB.commessa, e.Message)) _
            = ChiaviMess.MessSi Then
                Kill(objWRCB.commessa)
                objWRCB.commessa = ""
                Monitor.Motore.Problem.OrdineFile -= 1
                objWRCB.RiRidimens()
                AggiornaApert()
            End If
            Return False
        End Try
        fs.Close()
        AggiornaApert()
        Return True
    End Function
End Module