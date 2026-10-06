Option Strict On
Option Explicit On 
Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Drawing
Imports System.Reflection
Imports RoutBase1
Module Tr13
    Public Enum ControlloFilaMezzeria
        NessunControllo = 0
        FilaCentrataTuboCentrato = 1
        FilaCentrataTuboFuori = 2
        FilaFuori = 3
    End Enum
    Public Enum ControlloZonaUscita
        AltezzaData = 0
        Simmetria = 1
        SimmetriaTuboInAsse = 2
        SimmetriaTuboFuoriAsse = 3
        OttimizzTuboInAsse = 4
        OttimizzTuboFuoriAsse = 5
    End Enum
    Friend GlobalRoutines As RoutBase1.clsTrigon
    Friend XSC1, XSC2, YSC1, YSC2 As Single
    Friend bmRisult As Bitmap
    Friend gRisult As Graphics
    Friend MainForm As frmTracciat
    Public VariatiDati, Aggiornando As Boolean
    Public VariatiOpfin As Boolean
    Public GiaInitDaTos As Boolean
    Public job As RoutBase1.clsjob
    Public Monitor As traccia.clsMonitor
    Public gencommes As String = ""
    Public QualeCorona As Short
    Public iDat As Short
    Public OTC, starty As Single
    Public kwrite, kdati, imi0 As Short
    Public Epsil1, Epsilo As Single
    Public dx As Single
    Public xcsi, ypsi As Single
    Public jsect, Ni, nstart, Indexx As Short
    Public ymaxd, xmind, dy As Single
    Public FilaMezzeria As ControlloFilaMezzeria
    Public ZonaUscita As ControlloZonaUscita
    Public DisegnaSoloPerif As Boolean
    Public IncrementoDiametro As Short
    Public GiuntoSaldato As Boolean
    Public MargineVersoCava As Single
    Public LarghezzaCavaPerSetto As Single
    Public NumForcellePerFila() As Short
    Public PassoVdecimm As Integer
    Public kteor, nteor As Short
    Public DeltaPasso As Single
    Public GiocoDiaframmi As Single
    Public NumFileU As Short
    Public NumeroSetti As Short
    Public EpariNumeroSetti As Boolean
    Public SpostXSettore(12) As Single
    Public FuoriReticolo As Boolean
    Public jSettoreCritico As Short
    Public idelp As Short
    Public delp(5, 2) As Single
    Public jt6iutuvec As Boolean
    Public Ips2vec As Boolean
    Public divec As Single
    Public dtivec As Single
    Public dtovec As Single
    Public roivec As Single
    Public winvec As Single
    Public roovec As Single
    Public wouvec As Single
    Public y0ivec As Single
    Public y0ovec As Single
    Public ntuvec As Short
    Public jpvec As traccia.clsTracciatura.TipiPasso
    Public jtvec As traccia.clsTracciatura.PassiFascio
    Public jshvec As traccia.clsTracciatura.TipiFascio
    Public dtubvec As Single
    Public pasvec As Single
    Public pdiavec As Single
    Public p1vec As Single
    Public matuvec As Short
    Public jsvec As Boolean
    Public radvec As Single
    Public jinvec As Short
    Public tcavec As Single
    Public DistSuSettoHorvec As Single
    Public DistSuSettoVervec As Single
    Public MassimizzaOTLvec As Boolean
    Public FilaMezzeriavec As ControlloFilaMezzeria
    Public corivec As Single
    Public dt42vec, dt34vec, dt44vec As Single
    Public RadiceHelp As String
    Public Fact As Single
    '===============================================================
    Public DaTos(1) As traccia.clsTracciatura.typDaTos
    Public Tracciatura As traccia.clsTracciatura
    Public Gia, iForzat As Short
    Public Ncontr As Short
    Public StampaF As String
    Public iPagina As Short
    Public iAction, iAgg As Short
    Public PesoSpTubi As Single
    Public Mat As LibMat.MaterialeNew1
    Public Annullato As Boolean
    Public StubWord As StubW2000.clsSW2000
    Public myAssembly As System.Reflection.Assembly
    Public rmTestiTraccia As Resources.ResourceManager
    Public rmHelpStrings As Resources.ResourceManager
    Public rmHelpTopics As Resources.ResourceManager
    Public Dtub0() As Single = {0, 6.35, 9.525, 12.7, 15.875, 16, 19.05, 20, 25, 25.4, 27, 31.75, 38.1, 50.8}
    Public idelt() As Short = {0, 1, 1, 2, 2, 2, 1, 2, 3, 4, 3, 4}
    Public Tlmax1() As Single = {660.5, 889, 1117.5, 1321, 1321, 1524, 1524, 1750, 1879, 1879, 2235, 2540, 3000}
    Public Tlmax2() As Single = {559, 762, 965, 1143, 1143, 1321, 1321, 1625.5, 1625.5, 1750, 1930, 2210, 3000}
    Public alfajp() As Single = {Math.PI / 6, Math.PI / 3, Math.PI / 2, Math.PI / 4}
    '==========================================================
    Public Const IDH_ATT_ELIMINADATIFINALI As Integer = 200
    Public Const IDH_HID_COMMESSA As Integer = 9
    Public Const IDH_HID_DIAMINTMANT As Integer = 10
    Public Const IDH_HID_DIBOCIN As Integer = 11
    Public Const IDH_HID_DIBOCOUT As Integer = 12
    Public Const IDH_HID_ROBOCIN As Integer = 13
    Public Const IDH_HID_WIN As Integer = 14
    Public Const IDH_HID_ROBOCOUT As Integer = 15
    Public Const IDH_HID_WOUT As Integer = 16
    Public Const IDH_HID_ZLIBIN As Integer = 17
    Public Const IDH_HID_ZLIBOUT As Integer = 18
    Public Const IDH_HID_NUMEROTUBI As Integer = 19
    Public Const IDH_HID_TIPOPASSO As Integer = 20
    Public Const IDH_HID_TIPOTRACCIATURA As Integer = 21
    Public Const IDH_HID_TIPOFASCIO As Integer = 22
    Public Const IDH_HID_DTUBO As Integer = 23
    Public Const IDH_HID_PASSOTUBI As Integer = 24
    Public Const IDH_HID_PASSODIAF As Integer = 25
    Public Const IDH_HID_PASSO1 As Integer = 26
    Public Const IDH_HID_MATTUBI As Integer = 27
    Public Const IDH_HID_GIUNTOTP As Integer = 28
    Public Const IDH_HID_RAGGIOU As Integer = 29
    Public Const IDH_HID_PASSOITER As Integer = 30
    Public Const IDH_HID_LARGHCAVA As Integer = 31
    Public Const IDH_HID_SPESSMM As Integer = 32
    Public Const IDH_HID_SPESSBWG As Integer = 33
    Public Const IDH_HID_LUNGHTUBI As Integer = 34
    Public Const IDH_HID_TOLLTUBI As Integer = 35
    Public Const IDH_HID_GIUNTOTP1 As Integer = 36
    Public Const IDH_HID_FATTRID As Integer = 37
    Public Const IDH_HID_PERCTAGLIO As Integer = 38
    Public Const IDH_HID_ANGTAGLIO As Integer = 39
    Public Const IDH_HID_TIPODIAF As Integer = 40
    Public Const IDH_HID_URTO As Integer = 41
    Public Const IDH_HID_EVDIAMINTCOR As Integer = 42
    Public Const IDH_HID_NUMSS As Integer = 43
    Public Const IDH_HID_NUMRODS As Integer = 44
    Public Const IDH_HID_TACCHE As Integer = 45
    Public Const IDH_HID_DISTFILEH As Integer = 46
    Public Const IDH_HID_DISTFILEV As Integer = 47
    Public Const IDH_HID_CALCOTL As Integer = 48
    Public Const IDH_HID_NUMPASSIMANT As Integer = 49
    Public Const IDH_HID_DIAMINTCORINT As Integer = 50
    Public Const IDH_HID_PASSOINT As Integer = 51
    Public Const IDH_HID_DIAMEXTCORINT As Integer = 52
    Public Const IDH_HID_CONTROLLOMEZZ As Integer = 53
    Public Const IDH_HID_STORTA As Integer = 54
    Public Const IDH_HID_INTERF As Integer = 55
    Public Const IDH_HID_GIOCO As Integer = 56
    Public Const IDH_HID_ANGVARCO As Integer = 57
    Public Const IDH_HID_ANOMVARCO As Integer = 58
    Public Const IDH_HID_CURVEVERT As Integer = 59
    Public Const IDH_HID_DIAMINTCOREXT As Integer = 60
    Public Const IDH_HID_PASSOEXT As Integer = 61
    Public Const IDH_HID_ELIMDATIFINALI As Integer = 100
    Public Const IDH_HID_RIPRISTINA As Integer = 101
    Public Const IDH_HID_SALVA As Integer = 102
    Public Const IDH_HID_BARRASTATO As Integer = 103
    Public Const IDH_HID_AREAGRAFICA As Integer = 104
    Public Const IDH_HID_MAPPA As Integer = 105
    Public Const IDH_HID_BILANCIA As Integer = 106
    Public Const IDH_HID_AGGANCIA As Integer = 107
    Public Const IDH_HID_INFILA As Integer = 108
    Public Const IDH_HID_SEQUENZA As Integer = 109
    Public Const IDH_HID_AUTOCAD As Integer = 110
    Public Const IDH_HID_AUTOCAD1 As Integer = 120
    Public Const IDH_HID_AUTOCAD2 As Integer = 121
    Public Const IDH_HID_AUTOCAD3 As Integer = 122
    Public Const IDH_HID_AUTOCAD4 As Integer = 123
    Public Const IDH_ERR_MATTUBI As Integer = 2001
    Public Const IDH_ERR_TIPOPASSO As Integer = 2002
    Public Const IDH_ERR_TIPOGIUNTO As Integer = 2003
    Public Const IDH_ERR_NUMPASSI As Integer = 2004
    Public Const IDH_ERR_TIPOFASCIO As Integer = 2005
    Public Const IDH_ERR_DIAMBOC1 As Integer = 2006
    Public Const IDH_ERR_DIAMBOC2 As Integer = 2007
    Public Const IDH_ERR_DENS1noPORT As Integer = 2008
    Public Const IDH_ERR_DENS1noDIAM As Integer = 2009
    Public Const IDH_ERR_DENS2noPORT As Integer = 2010
    Public Const IDH_ERR_DENS2noDIAM As Integer = 2011
    Public Const IDH_ERR_PASSOnoU As Integer = 2012
    Public Const IDH_ERR_DIAMGRANDE As Integer = 2013
    Public Const IDH_ERR_NUMPASSInoFONT As Integer = 2014
    Public Const IDH_ERR_noDIAMnoTUBI As Integer = 2015
    Public Const IDH_ERR_FONTCORONA As Integer = 2016
    Public Const IDH_ERR_PASSOSBAGL As Integer = 2017
    Public Const IDH_ERR_DIAMTUBISBAGL As Integer = 2018
    Public Const IDH_ERR_CORINTCOREXT As Integer = 2019
    Public Const IDH_ERR_TRAPPOLA As Integer = 2020
    Public Const IDH_ERR_BADSYMM As Integer = 2021
    Public Const IDH_ERR_BADSERIAL As Integer = 2022
    Public Const IDH_BOT_DATIGEN As Integer = 2500
    Public Const IDH_BOT_DATIPROG As Integer = 2501
    Public Const IDH_BOT_TRACCIA As Integer = 2502
    Public Const IDH_BOT_VISTRACCIA As Integer = 2503
    Public Const IDH_BOT_TIRANTI As Integer = 2504
    Public Const IDH_BOT_TONDI As Integer = 2505
    Public Const IDH_BOT_SS As Integer = 2506
    Public Const IDH_BOT_TAGLI As Integer = 2507
    Public Const IDH_PREF_FACT As Integer = 3000
    Public Const IDH_CAP_INTRODUZIONE As Integer = 9000
    Public Const IDH_CAP_INT_FININIZ As Integer = 9020
    '=====================================================================
    Public Const NumFileMax As Short = 100
    '=====================================================================
    Public Inizializzando As Boolean
    Sub scalavi(Optional ByVal fatty As Single = 1)
        Dim Xsc, Ysc As Single
        Ysc = CSng(1.15 * DaTos(iDat).di1)
        Xsc = Ysc
        Xsc = Xsc / 2 : Ysc = Ysc / 2
        XSC1 = CSng(Xsc * 1.5)
        XSC2 = Xsc
        YSC1 = Ysc
        YSC2 = Ysc * fatty
        Monitor.Routines.Scala(-XSC1, XSC2, -YSC1, YSC2, , True)
    End Sub

    Sub InitDaTos()
        Dim SavCom As String
        If GiaInitDaTos Then Exit Sub
        GiaInitDaTos = True
        Try
            If gencommes.Length = 0 Then gencommes = " "
            If Asc(gencommes) < 32 Then gencommes = " "
            SavCom = gencommes
            ReDim DaTos(1)
            With DaTos(0)
                .Initialize()
                .Elimin = 1
                .ILFINAL = 0
                .dt(10) = 1
                .dt(12) = 1
                .dt(13) = 1
                .dt(14) = 1
                .dt(27) = 1
                .dt(28) = 1
            End With
            With DaTos(1)
                .Initialize()
                .Elimin = 1
                .ILFINAL = 0
                .dt(10) = 1
                .dt(12) = 1
                .dt(13) = 1
                .dt(14) = 1
                .dt(27) = 1
                .dt(28) = 1
            End With

            gencommes = SavCom
        Catch e As Exception
            e.ToString()
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Public Sub Carica(Optional ByRef Modo As Integer = 0)
        Dim Res As Boolean
        Dim icome1 As String
        DaTos(iDat).ILFINAL = 0
        QualeCorona = 1 : iDat = 0
        If Modo = 1 Then
            icome1 = RTrim(gencommes) & ".TMP"
        Else
            icome1 = RTrim(gencommes) & ".INP"
        End If
        If Not IO.File.Exists(icome1) Then Exit Sub
        Dim fs As New FileStream(icome1, FileMode.OpenOrCreate)
        Dim bf As New BinaryFormatter
        Try
            Monitor.Motore.Problem = CType(bf.Deserialize(fs), RoutBase1.clsProblem)
            DaTos(0) = CType(bf.Deserialize(fs), traccia.clsTracciatura.typDaTos)
        Catch e As Runtime.Serialization.SerializationException
            gencommes = ""
            fs.Close()
            If MostraAiuto(IDH_ERR_BADSERIAL, _
            ChiaviMess.MessQuestion Or ChiaviMess.MessYesNo, _
            GlobalRoutines.FormatS(Helpstringa(IDH_ERR_BADSERIAL), icome1, e.Message)) _
            = ChiaviMess.MessSi Then
                Kill(icome1)
                Monitor.Motore.Problem.OrdineFile -= 1
            End If
            Exit Sub
        Catch e As Exception
            MsgBox(e.Message)
            gencommes = ""
            fs.Close()
            Exit Sub
        End Try
        DaTos(iDat).CurveInPianoVert = DaTos(iDat).Passi4CurveVert
        If DaTos(0).TipoFascio = clsTracciatura.TipiFascio.Fontana Then
            DaTos(1) = CType(bf.Deserialize(fs), traccia.clsTracciatura.typDaTos)
            If DaTos(1).dt Is Nothing Then DaTos(1).Initialize()
        End If
        fs.Close()
        DaTos(iDat).ILFINAL = 1
        Res = Dati(True)
        Call vecchi()
        VariatiDati = False
    End Sub
    Public Function Loadd() As Boolean
        Loadd = True
        If VariatiDati Then
            If Chiudi() = MsgBoxResult.Cancel Then Exit Function
        End If
        Call InitDaTos()
        If Tracciatura.Modo > 0 Then
            If IO.File.Exists(gencommes & ".INP") Then
                Carica()
                Exit Function
            End If
        End If
        Monitor.Motore.Mostra(Reflection.Assembly.GetExecutingAssembly, 2)
    End Function

    Public Function Chiudi() As MsgBoxResult
        Dim Domanda As String = ""
        Dim junk As MsgBoxResult
        If VariatiDati Then
            Domanda = rmHelpStrings.GetString("DomandaChiudi1") ' "Vuoi salvare il lavoro in corso ?"
        ElseIf VariatiOpfin Then
            Domanda = rmHelpStrings.GetString("DomandaChiudi2") ' "Vuoi salvare i dati per l'elaborazione della Richiesta Materiali dei tubi di scambio?"
        Else
            junk = MsgBoxResult.Abort
        End If
        If Not junk = MsgBoxResult.Abort Then junk = MsgBox(Domanda, MsgBoxStyle.YesNoCancel)
        If Not junk = MsgBoxResult.Abort Then
            If junk = MsgBoxResult.Cancel Then
                Return junk
            ElseIf junk = MsgBoxResult.Yes Then
                SaveAll()
                OpFin()
            End If
        End If
        VariatiDati = False
        GiaInitDaTos = False
        Call InitDaTos()
        gencommes = ""
        Return junk
    End Function
    Public Sub SaveAll()
        Dim icome1 As String
        If gencommes.Trim.Length = 0 Then
            MainForm.mnuSalvaCome_Click(New Object, New EventArgs)
            'MsgBox("Non è stato definito il numero di commessa", MsgBoxStyle.Critical)
            Exit Sub
        End If
        Dati(True)
        icome1 = gencommes.Trim
        icome1 = icome1 & ".INP" 'RTrim$(Monitor.Motore.Inizio.Datidir) + "\" + RTrim$(gencommes) + ".INP"
        If IO.File.Exists(icome1) Then
            FileCopy(icome1, Left(icome1, Len(icome1) - 3) & "TMP")
        End If
        Dim fs As New FileStream(icome1, FileMode.OpenOrCreate)
        Dim bf As New BinaryFormatter
        bf.Serialize(fs, Monitor.Motore.Problem)
        inverti(0)
        bf.Serialize(fs, DaTos(0))
        If DaTos(0).TipoFascio = clsTracciatura.TipiFascio.Fontana Then
            bf.Serialize(fs, DaTos(1))
            inverti(1)
        End If
        fs.Close()
        VariatiDati = False
    End Sub
    Public Function at1(ByVal i As Integer) As String
        Dim Nome As String = "at1_" + i.ToString.Trim
        at1 = rmTestiTraccia.GetString(Nome).Replace("|", vbCrLf)
    End Function
    Public Function HelpTopic(ByVal id As Integer) As String
        Dim Nome As String = "str" + id.ToString.Trim
        Dim Stringa As String
        Try
            Stringa = rmHelpTopics.GetString(Nome)
            If Stringa Is Nothing Then
                Stringa = ""
            End If
        Catch e As Exception
            Stringa = ""
        End Try
        Return Stringa
    End Function
    Public Function Helpstringa(ByVal id As Integer) As String
        Dim Nome As String = "str" + id.ToString.Trim
        Helpstringa = rmHelpStrings.GetString(Nome).Replace("|", vbCrLf)
    End Function
    Public Sub Elimina()
        Dim icome1 As String, ldt(51) As Single
        Dim i As Integer
        icome1 = gencommes.Trim & ".ADU"
        IO.File.Delete(icome1)
        icome1 = gencommes.Trim & ".RMT"
        IO.File.Delete(icome1)
        GiaInitDaTos = False
        For i = 0 To 51
            ldt(i) = DaTos(0).dt(i)
        Next
        Call InitDaTos()
        For i = 0 To 51
            DaTos(0).dt(i) = ldt(i)
        Next
        Dati()
        vecchi()
        DaTos(0).Elimin = 1
    End Sub
    Public Sub InizializzaGen()
        Try
            Inizializzando = True
            Monitor.Motore.Problem.Extension = ".INP"
            Monitor.Motore.Problem.TipoFile = "Tracciatura "
            ' About.Code = " TEMA 7th Edition"
            If Monitor.Routines Is Nothing Then
                Monitor.Routines = New RoutBase1.Routines
                Monitor.Routines.Init200(Monitor.Motore.Inizio.Archdir)
            End If
            MainForm = New frmTracciat
            Monitor.Routines.DoveDisegno = MainForm.Picture1
            Monitor.Routines.DoveInizio = Monitor.Motore.Inizio
            MainForm.g = Monitor.Routines.DoveDisegnog
            bmRisult = New Bitmap(MainForm.pctRisult.ClientRectangle.Width, MainForm.pctRisult.ClientRectangle.Height)
            gRisult = Graphics.FromImage(bmRisult)
            MainForm.pctRisult.Image = bmRisult
            Inizializzando = False
            DisegnaFontana()
        Catch e As Exception
            MessageBox.Show(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Public Sub DisegnaFontana()
        Try
            Dim bm As New Bitmap(Monitor.Motore.Inizio.Archdir & "\Fontana.jpg")
            With MainForm
                .g.Clear(Color.LightCyan)
                Dim x As Integer = CInt((.Picture1.ClientRectangle.Width - bm.Width) / 2)
                Dim y As Integer = CInt((.Picture1.ClientRectangle.Height - bm.Height) / 2)
                .g.DrawImage(bm, x, y, CInt(bm.Width), CInt(bm.Height))
            End With
        Catch
            Exit Sub
        End Try
    End Sub
    Public Sub ControlADU(ByRef cotub As String)
        With frmGruppi.DefInstance
            .cotub = cotub
            .ShowDialog()
            cotub = .cotub
            .Close()
            .Dispose()
        End With
    End Sub
    Public Sub qualy(ByRef xprov As Single, ByRef yprov As Single, ByRef xtub As Single, ByRef ytub As Single, ByRef isek As Short, ByRef H As Short, ByRef j As Short, ByRef k As Short)
        Dim yj, sgy As Single
        Dim i As Short
        Dim xx As Single
        iDat = CShort(QualeCorona - 1)
        'cerca un tubo di coordinate (xtub,ytub) vicino a (xprov,yprov)
        'isek=0 a sx, 1 a dx
        FuoriReticolo = False
        For j = 1 To DaTos(iDat).kymax
1:          yj = DaTos(iDat).y(j)
            'If yj >= yprov - (DaTos(iDat).dtubo / 2) And yprov >= yj - (DaTos(iDat).dtubo / 2) Then sgy = 1 : GoTo qualset
            If Math.Abs(yj - yprov) <= DaTos(iDat).dtubo / 2 Then sgy = 1 : GoTo qualset
            If DaTos(iDat).CurveInPianoVert Then
                '   If -yj + 2 * DaTos(iDat).delcl >= yprov - (DaTos(iDat).dtubo / 2) And yprov >= -yj + 2 * DaTos(iDat).delcl - (DaTos(iDat).dtubo / 2) Then sgy = -1 : GoTo qualset
                If Math.Abs(yj + yprov) <= DaTos(iDat).dtubo / 2 Then sgy = -1 : GoTo qualset
            End If
        Next j
        FuoriReticolo = True
        Exit Sub
qualset:
        For k = 1 To DaTos(iDat).NumeroSettori
            ytub = sgy * DaTos(iDat).y(j)
            ' If sgy = -1 Then ytub = ytub + 2 * DaTos(iDat).delcl
            If DaTos(iDat).hsym(k) = 1 Then k = CShort(k + 1)
3:          For i = DaTos(iDat).FilaIniziale(k) To DaTos(iDat).FilaFinale(k)
                If i = j Then GoTo qualx
            Next i
        Next k
        FuoriReticolo = True
        Exit Sub
qualx:
        isek = 0
        xx = DaTos(iDat).x(j)
        For H = 1 To DaTos(iDat).ici(j)
            If xx >= xprov - (DaTos(iDat).dtubo / 2) And xprov >= xx - (DaTos(iDat).dtubo / 2) Then
                xtub = xx
                If DaTos(iDat).FilaCentraleStorta And j = DaTos(iDat).kymax Then
                    If ytub < 0 Then
                        If H > DaTos(iDat).ici(j) / 2 Then H = CShort(H - 1)
                        If H = 1 Then
                            FuoriReticolo = True
                        Else
                            If DaTos(iDat).bu(j, H) = "0" Then
                                FuoriReticolo = True
                                For i = CShort(H - 1) To 1 Step -1
                                    If DaTos(iDat).bu(j, i) = "1" Then FuoriReticolo = False
                                    If DaTos(iDat).bu(j, i) = "9" Then Exit For
                                Next
                                If FuoriReticolo Then
                                    For i = CShort(H + 1) To DaTos(iDat).ici(j)
                                        If DaTos(iDat).bu(j, i) = "1" Then FuoriReticolo = False
                                        If DaTos(iDat).bu(j, i) = "9" Then Exit For
                                    Next
                                End If
                            End If
                        End If
                    Else
                        If H < DaTos(iDat).ici(j) / 2 Then H = CShort(H + 1)
                        If H = DaTos(iDat).ici(j) Then
                            FuoriReticolo = True
                        Else
                            If DaTos(iDat).bu(j, H) = "0" Then
                                FuoriReticolo = True
                                For i = CShort(H - 1) To 1 Step -1
                                    If DaTos(iDat).bu(j, i) = "1" Then FuoriReticolo = False
                                    If DaTos(iDat).bu(j, i) = "9" Then Exit For
                                Next
                                If FuoriReticolo Then
                                    For i = CShort(H + 1) To CShort(DaTos(iDat).ici(j) - 1)
                                        If DaTos(iDat).bu(j, i) = "1" Then FuoriReticolo = False
                                        If DaTos(iDat).bu(j, i) = "9" Then Exit For
                                    Next
                                End If
                            End If
                        End If
                    End If
                End If
                Exit Sub
            End If
            If DaTos(iDat).bu(j, H + 1) = "9" Then xx = -xx : isek = 1 : H = CShort(H + 1) : GoTo 1235
            xx = xx + DaTos(iDat).PassoOrizzontale
1235:   Next H
        FuoriReticolo = True
    End Sub
End Module