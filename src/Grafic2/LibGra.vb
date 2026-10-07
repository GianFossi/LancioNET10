Option Strict Off
Option Explicit On 
Imports RoutBase1
Imports System.Data
Imports System.Data.oledb
Imports System.IO
Imports System.Runtime.Serialization
Imports System.Runtime.Serialization.Formatters.Binary
Public Class LibGra
    Public CreaProtoTyp As Boolean
    Public DisRut As RoutBase1.Routines
    Public iAPRn As FileStream
    Public iAPRv As FileStream
    Public membratura As Short
    Public Lato As Short
    Public OKfrmDati As Boolean
    Public Sub PutDes(Optional ByVal j As clsjob = Nothing, Optional ByRef d As clsDatiDes = Nothing)
        Lancio.Legacy.Serialization.LegacyBinarySerializer.EnsureEnabled()
        Dim File As String
        If Not j Is Nothing Then job = j
        If Not d Is Nothing Then DataSheet = d
        Try
            File = FileDes("DES")
            If Len(File) = 0 Or InStr(File, "?") Then Exit Sub
            Dim myFileStream As Stream = IO.File.OpenWrite(File)
            Dim deserializer As New Lancio.Legacy.Serialization.LegacyBinarySerializer
            Try
                deserializer.Serialize(myFileStream, DataSheet)
            Catch e As SerializationException
                MsgBox("Failed to serialize" & File & ControlChars.CrLf & "Reason:" & e.Message)
            Finally
                myFileStream.Close()
            End Try
        Catch e1 As Exception
            MsgBox(e1.Message + vbCrLf + e1.StackTrace)
        End Try
    End Sub
    Public Function FileDes(ByRef Ext As String, Optional ByVal j As clsjob = Nothing) As String
        Dim Ext1 As String
        If Not j Is Nothing Then job = j
        If job Is Nothing Then Return ""
        Ext1 = Ext
        If InStr(Ext1, ".") = 0 Then Ext1 = "." & Ext1
        Try
            Select Case Ext
                Case "GRE"
                    FileDes = RTrim(Monitor.Motore.Inizio.Workdir) & "\" & Trim(job.Contratto) & ".MDB"
                Case Else
                    FileDes = Monitor.Motore.Inizio.Workdir.Trim & "\" & job.Comm.Arch.Trim & "\" + job.Comm.Ind.Item(job.Comm.indice).Data.File + Ext1
            End Select
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Function
    Public Sub GetDes(Optional ByRef d As clsDatiDes = Nothing)
        Lancio.Legacy.Serialization.LegacyBinarySerializer.EnsureEnabled()
        Dim File As String
        Try
            File = FileDes("DES")
            If InStr(File, "?") Or Len(File) = 0 Then Exit Sub
            If System.IO.File.Exists(File) Then
                Dim myFileStream As Stream = IO.File.OpenRead(File)
                Dim deserializer As New Lancio.Legacy.Serialization.LegacyBinarySerializer
                DataSheet = CType(deserializer.Deserialize(myFileStream), RoutBase1.clsDatiDes)
                myFileStream.Close()
            End If
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
        If Not d Is Nothing And Not DataSheet Is Nothing Then d = DataSheet
    End Sub
    Public Sub GeneraOggetto(ByRef Tipo As Short, ByRef lMembro As membratura)
        Select Case System.Math.Abs(Tipo)
            Case 0
                lMembro = New Origine
            Case 1, 2, 34
                lMembro = New Cilindro
            Case 3, 4, 5
                lMembro = New Fondo
            Case 6, 7
                lMembro = New Cono
            Case 8
                lMembro = New Tubi
            Case 9
                lMembro = New Tubi
            Case 10 'Call Bocch
                lMembro = New clsBocch
            Case 11 'Flangioni
                lMembro = New Flangione
            Case 12 'Piastre
                lMembro = New Piastrone
            Case 13 'Tiranti
                lMembro = New clsTirante
            Case 14 'Call NonStd
                lMembro = New clsNonStd
            Case 15 'Lamiere piane
                lMembro = New Striscia
            Case 16 'Dischi/Calotte/Fondi piani
                lMembro = New CalDisc
            Case 18 'Call Dilat
                lMembro = New Dilat
            Case 17 'Call Stampati 'Anelli
                lMembro = New Anello
            Case 19 'Call DiafraGlob
                lMembro = New Diaframma
            Case 20, 22
                MsgBox("Da programmare" & Str(Tipo))
            Case 21 'curve a gusci e a spicchi
                lMembro = New Curva
            Case 23
                lMembro = New Tondo
            Case 24 'Call DiafraGlob: 'Varie
            Case 25
                lMembro = New Sella
            Case 31, 32, 33, 37, 38
                lMembro = New Raggrupp
            Case 26
                lMembro = New Fascio
            Case 27, 29 'Call DiafraGlob: ' close #99:Catena "DIAFRAM"
            Case 28 'Call DiafraGlob: ' close #99:Catena "DIAFRAM"
                lMembro = New clsGuarniz
            Case 30
            Case 36 'Call Belts
            Case 46 'Riduzioni
                lMembro = New Cono
                lMembro.GenMem.Tipo = 7
                CType(lMembro, Cono).Fitting = True
                lMembro.GenMem.Lato = Funzioni.Lato
                Exit Sub
            Case 96
                lMembro = New clsPolig
            Case 97
                lMembro = New Foratura
            Case Else
                lMembro = Nothing
        End Select
        If Not lMembro Is Nothing Then
            CType(lMembro.Genmem, clsGenMem).Tipo = Tipo
            CType(lMembro.Genmem, clsGenMem).Lato = Lato
        End If
    End Sub
    Public Function NuovaPosN() As Short
        Dim Oggetto As Membratura = Nothing
        Try
            If Apparecchio Is Nothing Then
                MsgBox("Qualcosa di storto in NuovaPosN")
                NuovaPosN = 1
                Exit Function
            End If
            If Apparecchio.NumeroLati <= 1 Then
                frmMnuMemb.DefInstance.ShowDialog()
                frmMnuMemb.DefInstance.Dispose()
            Else
                frmMnuMemb3.DefInstance.ShowDialog()
                frmMnuMemb3.DefInstance.Dispose()
            End If
            If membratura = 0 Then Exit Function
            If membratura = 37 Then If Not CheckSetti() Then Exit Function
            GeneraOggetto(membratura, Oggetto)
            InitPosSpaN(1, Oggetto.GenMem)
            TrasferisciDati(membratura, Oggetto)
            Oggetto.GenMem.PosDis = Funzioni.SetPosizN
            Dim gm As clsGenMem = Oggetto.GenMem
            Dim Nome As String = gm.Denom.Trim
            gm.Ind = Apparecchio.Elementi.Count()
            If Nome.Length = 0 Then
                Nome = "ELEM" & Trim(Str(gm.Ind))
                gm.Denom = Nome
            End If
            Editing = True
            Oggetto.Leggi(Inizio.DiscoRam, CShort(1))
            Editing = False
            If OKfrmDati Then
                AggiornaApparecchio(Oggetto)
                PostChain(Oggetto.GenMem)
            End If
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Function
    Public Function NuovoBlocco(ByRef membratura As Short, ByRef Acad As AutoCAD.AcadDocument, ByRef f As Object) As Short
        Dim block As AutoCAD.AcadBlock
        Dim BlockRef As AutoCAD.AcadBlockReference
        Dim insPoint(2) As Double
        Dim Nome, Testo As String
        Dim Origine As New Origine
        Dim n As Short
        Dim Appar As New clsApparecchio
        Membro = Nothing
        Monitor.AcadDis = Acad : frmMadre = f
        With Origine.GenMem
            .posizione.DirDiritta = "Ho"
            .posizione.CosDiritta.y = 1
            .posizione.CosOrigine.y = 1
            .posizione.CosTerza.Z = 1
            .Denom = "Orig./Asse apparecchio"
            .Tipo = 0
            .Ind = 1
            .posizione.DirTraversa = "Ho"
            .posizione.CosTraversa.X = 1
        End With
        Appar.Add(Origine)
        GeneraOggetto(membratura, Membro)
        Dim gGen As clsGenMem = Membro.GenMem
        gGen.posizione.SuChi = Origine
        gGen.Ind = 2 ' Ind
        Apparecchio = Appar
        Funzioni.InitPosSpaN(1, gGen)
        Appar.Add(Membro)
        IUNL = 5 : jRec = 0
R:      'Dispaccia membratura, 1
        Call MembroLeggi(Membro, Inizio.DiscoRam, 1)
        If Not OKfrmDati Then GoTo ExNB
        Editing = True
        AggiornaApparecchio(Membro)
        Editing = False
        PostChain(gGen)
        AggCoordN(gGen, Appar)
        Nome = Trim(gGen.Denom)
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
        For Each block In Monitor.AcadDis.Blocks
            If block.Name = Nome Then
                Testo = "Il nome dato al nuovo blocco (" & Nome & ") esiste già. Cambiarlo"
                MsgBox(Testo, MsgBoxStyle.Exclamation)
                GoTo R
            End If
        Next block
        block = Acad.Blocks.Add(insPoint, Nome)
        DisRut.DoveScrivere = IUNL
        Call DisRut.InitAcad(block)
        LungPip = 1 : GraficMain.sezioni.Nsezioni = 1 : GraficMain.sezioni.Tipo(1) = 1
        GraficMain.sezioni.Verso(1) = -1
        Disegno(5, 1, Appar)
        Monitor.Smetti = False
        BlockRef = Acad.ModelSpace.InsertBlock(insPoint, Nome, 1, 1, 1, 0)
        AppActivate(Acad.Application.Caption)
        Acad.Application.ZoomAll()
ExNB:
        Appar = Nothing
    End Function
    Public Sub New()
        MyBase.New()
        Dim myAssembly As System.Reflection.Assembly
        ReDim IndInMezzo(20)
        DaTos.Initialize()
        Funzioni = Me '9-5-99
        Squadratura = New RoutBase1.clsPunti
        Squadratura.Inizia(5)
        myAssembly = Me.GetType.Assembly
        rmHelpStrings = New _
           System.Resources.ResourceManager("Grafica.ProjectResources", myAssembly)
        FunzLibgra = Me
    End Sub
    Protected Overrides Sub Finalize()
        If Not FormDati Is Nothing Then FormDati.Dispose()
        Funzioni = Nothing
        MyBase.Finalize()
    End Sub
    Public Sub DisGeneral()
        If Not job.Comm Is Nothing Then If Not job.Comm.CalcBaric Then Exit Sub
        Disegno(4, 1, Apparecchio)
        If Not Monitor.Smetti Then Disegno(2, 1, Apparecchio)
        Monitor.Smetti = False
        Funzioni.DisRut.DoveDisegno.Refresh()
    End Sub
    Public Sub PPSM(ByRef DiscoR As String, ByRef j As RoutBase1.clsjob, ByRef p As String, ByRef crea As Boolean)
        Try
            ProtoTyp = p
            job = j
            GetDes()
            NonDisegnare = True
            If Not job.Comm Is Nothing Then
                If Not job.Comm.CalcBaric Then
                    NonDisegnare = True
                End If
            End If
            FormDati = New frmDati
            LeggiPrefGen()
            GeneraApparecchio()
Rif:        Distinta = True
            frmDistinta.DefInstance.ShowDialog() 'vbModeless  ', Me
            crea = CreaProtoTyp
            If crea Then
                crea = PreparaProto()
                If Not crea Then
                    CreaProtoTyp = False
                    GoTo Rif
                End If
            End If
            frmDistinta.DefInstance.Dispose()
            If Not Apparecchio Is Nothing Then
                If Not Apparecchio.Salvato Then
                    If MessageBox.Show("Vuoi salvare le modifiche?", "IST", MessageBoxButtons.YesNo, _
                                       MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.Yes Then
                        Apparecchio.ScaricaApparecchio()
                        PutDes()
                    End If
                End If
                Apparecchio.Delete()
                Apparecchio = Nothing
            End If
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Public WriteOnly Property DoveMotore() As RoutBase1.clsMotore
        Set(ByVal Value As RoutBase1.clsMotore)
            If Monitor Is Nothing Then Monitor = New clsMonitor
            Motore = Value
            Monitor.Motore = Value
            Dim InitLibmat As LibMat.clsInitLibMat = New LibMat.clsInitLibMat(Monitor.Motore)
            Inizio = Motore.Inizio
            RadiceHelp = Inizio.AppLancio & rmHelpStrings.GetString("Helpfile")
        End Set
    End Property
    Public WriteOnly Property DoveRoutines() As RoutBase1.Routines
        Set(ByVal Value As RoutBase1.Routines)
            'On Error Resume Next
            DisRut = Value
            'On Error GoTo 0
        End Set
    End Property
    Public WriteOnly Property CodiceOperazione() As Short
        Set(ByVal Value As Short)
            IUNL = Value
        End Set
    End Property
    Public Sub TrasferisciDati(ByRef m As Short, ByRef O As membratura)
        Dim f As Fascio
        Dim g As clsGenMem
        Dim Indexx As Short
        Dim Index1, Index2 As Short
        g = O.GenMem
        g.Qta = 1
        Indexx = IndiceDS(g)
        If Indexx = -1 Then Exit Sub
        Index1 = Indexx \ 7
        Index2 = Indexx Mod 7
        Try
            Select Case m
                Case 26
                    f = O
                    With f
                        If .Tubi_Renamed Is Nothing Then .Tubi_Renamed = New Tubi
                        .Tubi_Renamed.NumeroTubi = DataSheet.DatiPrg.TubiInform.Numero
                        .Tubi_Renamed.DiamExt = DataSheet.DatiPrg.TubiInform.Diam
                        .Tubi_Renamed.Spessore = DataSheet.DatiPrg.TubiInform.Spess
                        .Tubi_Renamed.Lunghezza = DataSheet.DatiPrg.TubiInform.Lungh
                        .Tubi_Renamed.Passo = DataSheet.DatiPrg.TubiInform.Pitch
                        .Tubi_Renamed.Tolleranza = 2 - DataSheet.DatiPrg.TubiInform.Toller
                        .Tubi_Renamed.TipoPasso = DataSheet.DatiPrg.TubiInform.TipoP + 1
                        .Tubi_Renamed.GenMem.Indmat1 = DataSheet.DatiS1(Index1).MateInform(Index2).Ind1
                        .Tubi_Renamed.GenMem.IndMat2 = DataSheet.DatiS1(Index1).MateInform(Index2).Ind2
                        .Tubi_Renamed.GenMem.IndMat3 = DataSheet.DatiS1(Index1).MateInform(Index2).Ind3
                    End With
                    Indexx = 0
                    g.Indmat1 = 0
                    g.IndMat2 = 0
                    g.IndMat3 = 0
                Case Else
                    If Indexx = -1 Then Exit Sub
                    g.Indmat1 = DataSheet.DatiS1(Index1).MateInform(Index2).Ind1
                    g.IndMat2 = DataSheet.DatiS1(Index1).MateInform(Index2).Ind2
                    g.IndMat3 = DataSheet.DatiS1(Index1).MateInform(Index2).Ind3
            End Select
            O.Leggi("", CShort(0))
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Public Function IniziaDocAcad() As Short
        Dim NomeDis As String
        Dim dis As AutoCAD.AcadDocument = Nothing
        Dim App As AutoCAD.AcadApplication
        Dim Res As Short
        NomeDis = FileDes("DWG")
        If Not Monitor.AcadDis Is Nothing Then
            On Error GoTo ErrAuto
            App = Monitor.AcadDis.Application
            For Each dis In App.Documents
                If NomeDis = dis.FullName Then
                    dis.Close(False)
                    'UPGRADE_NOTE: È possibile che l'oggetto Monitor.AcadDis non venga eliminato finché non venga raccolto nel Garbage Collector. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1029"'
                    Monitor.AcadDis = Nothing
                    Exit For
                End If
            Next dis
        End If
Riprendi:
        On Error GoTo 0
        NomeDis = Left(NomeDis, Len(NomeDis) - 4)
        Res = DisRut.ApriPri(NomeDis, "DWG", 0, 3, "", dis, True)
        Monitor.AcadDis = dis
        Inizio.Caricalinee(dis)
        IniziaDocAcad = Res
        Exit Function
ErrAuto:
        If System.Math.Abs(Err.Number) > 100000 Then
            'UPGRADE_NOTE: È possibile che l'oggetto Monitor.AcadDis non venga eliminato finché non venga raccolto nel Garbage Collector. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1029"'
            Monitor.AcadDis = Nothing
            Resume Riprendi
        Else
            Res = 3
        End If
    End Function
    Public Function QuantiLati(Optional ByRef FBM As String = Nothing, Optional ByRef Ind As Short = 0) As Short
        Dim db As OleDbConnection
        Dim tb As New DataTable
        Dim cmd As OleDbDataAdapter
        Dim n As Short
        Dim SQL, FBMLetter As String
        Dim IndCodice As Short
        Dim Strin(2) As String
        Dim Testo As String
        Strin(1) = "1 lato" : Strin(2) = "2 lati"
        If IsNothing(FBM) Then
            FBMLetter = DataSheet.DatiSh0.FBMLetter
            If Asc(DataSheet.DatiSh0.IndCodice) < 32 Then
                DataSheet.DatiSh0.IndCodice = ""
            End If
            IndCodice = Val(DataSheet.DatiSh0.IndCodice)
        Else
            FBMLetter = FBM
            IndCodice = Val(Ind)
        End If
        If Asc(FBMLetter) < 32 Then GoTo Dom
        db = New OleDbConnection(Conn & Monitor.Motore.Inizio.Archdir.Trim & "\PROTO\CLASSI.MDB" & ConnFine)
        SQL = "SELECT * FROM CLASSI WHERE "
        SQL = SQL & "Categoria='" & Trim(FBMLetter) & "' AND "
        SQL = SQL & "Codice=" & Str(IndCodice) & ";"
        cmd = New OleDbDataAdapter(SQL, db)
        cmd.Fill(tb)
        tb.Dispose()
        db.Dispose()
        If tb.Rows.Count = 0 Then
            'MsgBox "Errore 1 in PROTO\CLASSI QuantiLati"
Dom:        Testo = HelpStringa(IDHG.IDH_ERR_NOPROTO)
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            Do
                n = Motore.Quale(2, "Numero di lati", Strin, RadiceHelp, 2, Testo, , IDHG.IDH_ERR_NOPROTO)
            Loop While n < 0 Or n > 2
            QuantiLati = n ' Val(InputBox("N° di lati" + String(200, "-"), "PPSM", String(200, "-"), , , RadiceHelp, IDHG.IDH_ERR_NOLAMQUAD))
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        Else
            If tb.Rows.Count > 1 Then
                Testo = HelpStringa(IDHG.IDH_ERR_2PROTO)
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
                Do
                    n = Motore.Quale(2, "PPSM", Strin, RadiceHelp, 2, Testo, , IDHG.IDH_ERR_2PROTO)
                Loop While n < 1 Or n > 2
                QuantiLati = n ' Val(InputBox("N° di lati" + String(200, "-"), "PPSM", String(200, "-"), , , RadiceHelp, IDHG.IDH_ERR_NOLAMQUAD))
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
            Else
                QuantiLati = CShort(tb.Rows(0)("Lati"))
            End If
        End If
    End Function
    Public Function Costruisci(ByRef j As RoutBase1.clsjob, ByRef nondomandare As Boolean) As clsApparecchio
        job = j
        GetDes()
        FileAPR = FileDes("APR")
        If IO.File.Exists(FileAPR) And Not nondomandare Then
            If Not MostraAiuto(IDHG.IDH_DB_APRESISTEGIA, ChiaviMess.MessQuestion + ChiaviMess.MessYesNo + ChiaviMess.MessHelpButton) = ChiaviMess.MessSi Then
                Kill(FileAPR)
            End If
        End If
        NonDisegnare = True
        GeneraApparecchio()
        Costruisci = Apparecchio
    End Function
    Public Function SetPosizN(Optional ByRef Obj As membratura = Nothing) As Short
        Dim NPos, i As Short
        Dim Cambia As Boolean
        Dim NposV, j As Short
        NPos = 1
        If Apparecchio Is Nothing Then Exit Function
        Try
            Do
                Cambia = False
                For i = 1 To Apparecchio.Elementi.Count
                    NposV = Apparecchio.Elementi(i - 1).GenMem.PosDis
                    If NPos = NposV Then
                        NPos = NPos + 1
                        Cambia = True
                        Exit For
                    End If
                    If Not IsNothing(Obj) Then
                        For j = 0 To Obj.GenMem.Appesi.Count - 1
                            If j = 0 Then
                                NposV = Obj.GenMem.PosDis
                            Else
                                NposV = Obj.GenMem.Appesi(j).GenMem.PosDis
                            End If
                            If NPos = NposV Then
                                NPos = NPos + 1
                                Cambia = True
                                Exit For
                            End If
                        Next
                    End If
                Next
            Loop While Cambia
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
        SetPosizN = NPos
    End Function
    Public Sub InitPosSpaN(ByRef Index As Object, ByRef Rec As clsGenMem)
        Dim Elem As Membratura
        Try
            Select Case VarType(Index)
                Case VariantType.Object
                    Elem = Index.Parent
                Case VariantType.Short, VariantType.Integer
                    If Index = 0 Then
                        Select Case Apparecchio.Asse
                            Case "H"
                                Rec.posizione.DirDiritta = "Ho"
                            Case "V"
                                Rec.posizione.DirDiritta = "+N"
                        End Select
                        Rec.posizione.DirTraversa = "Au"
                        Rec.posizione.Anomal = "N."
                        SetDirittaN(Rec, Nothing)
                        Rec.posizione.CosDiritta.copia((Rec.posizione.CosOrigine))
                        SetTraversaN(Rec, Nothing)
                        Exit Sub
                    Else
                        Elem = Apparecchio.Elementi(Index - 1)
                    End If
                Case Else
                    MsgBox("Errore initposspaN")
                    Exit Sub
            End Select
            With CType(Elem.GenMem, clsGenMem)
                .posizione.CosDiritta.copia(Rec.posizione.CosDiritta)
                .posizione.CosTraversa.copia(Rec.posizione.CosTraversa)
                .posizione.CosTerza.copia(Rec.posizione.CosTerza)
            End With
            Rec.posizione.SuChi = Elem
            Rec.posizione.QuotaR = 0
            Rec.posizione.RaggioR = 0
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Public Sub AggiornaApparecchio(ByRef Oggetto As membratura)
        If Not Editing Or Duplicando Then
            Apparecchio.Add(Oggetto)
        Else
            Oggetto.GenMem.ClearAppesi(False)
        End If
        SuperAppendi(Oggetto)
    End Sub
    Public Sub PostChain(ByRef Record As clsGenMem)
        'nuovo--------------------------------------------
        Dim Recordv, Rec As clsGenMem
        Dim O As Membratura
        If IUNL < 5 Then
            Try
                If Not job.Comm.CalcBaric Then Exit Sub
                Recordv = Record.posizione.SuChi.GenMem
                AggCoordN(Record, Apparecchio)
                Rec = Record
                DeletaForiN((Rec.Parent), True)
                Intersezioni(Rec, Recordv)
                SuperIntersezioni(Rec)
                AggiustaLun(Rec)
                Dim i As Short
                For i = 0 To CType(Record.Appesi, OggList).Count - 1
                    O = Record.Appesi(i)
                    Rec = O.GenMem
                    DeletaForiN((Rec.Parent), True)
                    Intersezioni(Rec, Recordv)
                    SuperIntersezioni(Rec)
                    AggiustaLun(Rec)
                Next i
            Catch e As Exception
                MsgBox(e.Message + vbCrLf + e.StackTrace)
            End Try
        End If
    End Sub
End Class
Module modDisegno
    Private j As Short
    Private Oggetto As Membratura
    Private gm As clsGenMem
    Private Nome As String
    Private block As AutoCAD.AcadBlock
    Private Elem As Membratura
    Private s As spot
    Private Res, n As Short
    Private yMin, xMin, xMax, yMax As Single
    Private BlockRef As AutoCAD.AcadBlockReference
    Private insPoint(2) As Double
    Private iAvan, nAvan As Short
    Private Testo As String
    Public Sub Disegno(ByRef IUNLloc As Short, ByRef Ind As Short, ByRef Appar As clsApparecchio) 'aggiorna
        Try
            'sezioni = New clsSezioni
            ApparProv = Appar
            If Appar.Elementi.Count() = 0 Then Exit Sub
            IUNL = IUNLloc
            If IUNL = -2 Or Ind < 0 Then Exit Sub
            Oggetto = Appar.Elementi(Ind)
            Select Case IUNL
                Case 0 'disegno singolo a video
                    AddMembrat = Oggetto.GenMem.Tipo
                    DispDis()
                Case 2, 3, 4
                    'IUNL 3 file per STRIM/AutoCAD
                    'IUNL 4 calcolo degli spots
                    'IUNL 2 disegno a video
                    If IUNL = 4 Then AzzeraSpot(Appar)
                    lDisgeneral()
                    If IUNL = 4 Then
                        With Squadratura
                            .Punti0(3).X = clsTrigon.Infinito : .Punti0(3).y = clsTrigon.Infinito
                            .Punti0(4).X = -clsTrigon.Infinito : .Punti0(4).y = -clsTrigon.Infinito
                            Dim i As Short
                            For i = 0 To Appar.Elementi.Count - 1
                                Elem = Appar.Elementi(i)
                                gm = Elem.GenMem
                                Dim js As Short
                                For js = 0 To gm.Segnalini.Count - 1
                                    s = gm.Segnalini(js)
                                    Select Case s.Tipo
                                        Case 1 'quadro
                                            .Punti0(0).X = s.Quadro.TopLeft.X
                                            .Punti0(0).y = s.Quadro.TopLeft.y
                                            .Punti0(1).X = s.Quadro.Botrigt.X
                                            .Punti0(1).y = s.Quadro.Botrigt.y
                                        Case 2 'spicchio
                                            .Punti0(0).X = s.spicchio.Origin.X + s.spicchio.RG * _
                                   GlobalRoutines.Minimo(Math.Cos(GlobalRoutines.arco( _
                                                         s.spicchio.Direct.X, s.spicchio.Direct.y)), _
                                                         Math.Cos(GlobalRoutines.arco( _
                                                         s.spicchio.Direct.X, s.spicchio.Direct.y) + s.spicchio.Alfa / 2), _
                                                         Math.Cos(GlobalRoutines.arco( _
                                                         s.spicchio.Direct.X, s.spicchio.Direct.y) - s.spicchio.Alfa / 2))
                                            .Punti0(0).y = s.spicchio.Origin.y + s.spicchio.RG * _
                                   GlobalRoutines.Minimo(Math.Sin(GlobalRoutines.arco( _
                                                         s.spicchio.Direct.X, s.spicchio.Direct.y)), _
                                                         Math.Sin(GlobalRoutines.arco( _
                                                         s.spicchio.Direct.X, s.spicchio.Direct.y) + s.spicchio.Alfa / 2), _
                                                         Math.Sin(GlobalRoutines.arco( _
                                                         s.spicchio.Direct.X, s.spicchio.Direct.y) - s.spicchio.Alfa / 2))
                                            .Punti0(1).X = s.spicchio.Origin.X + s.spicchio.RG * _
                                  GlobalRoutines.Massimo(Math.Cos(GlobalRoutines.arco( _
                                                         s.spicchio.Direct.X, s.spicchio.Direct.y)), _
                                                         Math.Cos(GlobalRoutines.arco( _
                                                         s.spicchio.Direct.X, s.spicchio.Direct.y) + s.spicchio.Alfa / 2), _
                                                         Math.Cos(GlobalRoutines.arco( _
                                                         s.spicchio.Direct.X, s.spicchio.Direct.y) - s.spicchio.Alfa / 2))
                                            .Punti0(1).y = s.spicchio.Origin.y + s.spicchio.RG * _
                                  GlobalRoutines.Massimo(Math.Sin(GlobalRoutines.arco( _
                                                         s.spicchio.Direct.X, s.spicchio.Direct.y)), _
                                                         Math.Sin(GlobalRoutines.arco( _
                                                         s.spicchio.Direct.X, s.spicchio.Direct.y) + s.spicchio.Alfa / 2), _
                                                         Math.Sin(GlobalRoutines.arco( _
                                                         s.spicchio.Direct.X, s.spicchio.Direct.y) - s.spicchio.Alfa / 2))
                                    End Select
                                    If .Punti0(3).X > .Punti0(0).X Then .Punti0(3).X = .Punti0(0).X
                                    If .Punti0(3).y > .Punti0(0).y Then .Punti0(3).y = .Punti0(0).y
                                    If .Punti0(4).X < .Punti0(1).X Then .Punti0(4).X = .Punti0(1).X
                                    If .Punti0(4).y < .Punti0(1).y Then .Punti0(4).y = .Punti0(1).y
                                Next js
                            Next i
                            If .Punti0(3).X = clsTrigon.Infinito Then Exit Sub
                            xMin = .Punti0(3).X - (.Punti0(4).X - .Punti0(3).X) / 20
                            xMax = .Punti0(4).X + (.Punti0(4).X - .Punti0(3).X) / 20
                            yMin = .Punti0(3).y - (.Punti0(4).y - .Punti0(3).y) / 20
                            yMax = .Punti0(4).y + (.Punti0(4).y - .Punti0(3).y) / 20
                            j = Funzioni.DisRut.Scala(xMin, xMax, yMin, yMax)
                        End With
                    End If
                Case 5 'IUNL 5 disegno singolo AutoCAD
                    lDisgeneral()
            End Select
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Private Sub DispDis()
        'Call SwapCoord(3)
        gm = Oggetto.GenMem
        Call SwapCoordN(gm)
        If IUNL = 2 And DisAcad Then
            Nome = Trim(Oggetto.GenMem.Denom)
            n = InStr(Nome, """")
            If n > 0 Then Mid(Nome, n, 1) = "in"
            If InStr(Nome, "Orig.") > 0 Then Nome = "Assi"
            Try
                block = Monitor.AcadDis.Blocks.Add(insPoint, Nome) 'Nome)
            Catch e As Exception
                MsgBox("Something wrong with AutoCad" & vbCrLf & e.Message & vbCrLf & e.StackTrace, MsgBoxStyle.Critical, "PPSM")
                Exit Sub
            End Try
            Call Funzioni.DisRut.InitAcad(block)
        End If
        Select Case AddMembrat
            Case 0 : Call DisAxes(Oggetto)
            Case 1, 2 : Call DisCil(0, CType(Oggetto, Cilindro))
            Case 3, 4, 5
                Call DisFon(CType(Oggetto, Fondo))
            Case 6, 7
                Call DisCon(CType(Oggetto, Cono))
            Case 8, 9
                Call DisTubiDir(Oggetto)
                'Case 26:      Call DisTubiDir(Oggetto.Tubi)
            Case 10, 14 : Call DisBocch(Oggetto)
            Case 11
                Call DisFlan(Oggetto)
            Case 12
                Call DisPia(Oggetto)
            Case 13
                Call DisTira(Oggetto)
            Case 15
                Call DisStri(Oggetto)
            Case 16
                Call DisCalDisc(Oggetto)
            Case 17 : Call DisPads(Oggetto)
            Case 18
                Call DisDilat(Oggetto)
            Case 21
                Call DisCurva(Oggetto)
            Case 23
                Call DisTon(Oggetto)
            Case 28 : Call DisGuar(Oggetto)
            Case 34
                Call DisTegola(Oggetto)
            Case 35 'Call DisPolig
            Case 96
                Call DisPolig(Oggetto)
            Case Else
                If IUNL = 0 Then
                    GlobalRoutines.PlaySoundFile(Monitor.Motore.Inizio.Archdir + "\Errore.WAV")
                    Exit Sub
                End If
        End Select
        If IUNL = 2 And DisAcad Then
            BlockRef = Monitor.AcadDis.ModelSpace.InsertBlock(insPoint, Nome, 1, 1, 1, 0)
        End If
    End Sub
    Private Sub lDisgeneral()
        Dim Res As Integer
        Dim Testo As String
        If IUNL = 2 And DisAcad Then
            Res = Funzioni.IniziaDocAcad()
            With frmDistinta.DefInstance
                Select Case Res
                    Case 1
                        MostraAiuto(IDHG.IDH_ERR_NOAUTOCAD, ChiaviMess.MessOkOnly + ChiaviMess.MessCritical)
                    Case 2
                        MostraAiuto(IDHG.IDH_ERR_NOAUTOVER, ChiaviMess.MessOkOnly + ChiaviMess.MessCritical)
                    Case 3
                        MsgBox("Errore sconosciuto in AutoCAD", MsgBoxStyle.Critical, "PPSM")
                End Select
                Funzioni.DisRut.ChiudiPRI()
                DisAcad = True
                .cmdAcad_Click(Nothing, New EventArgs)
            End With
        End If
        Testo = "Fase: " & Str(IUNL)
        Select Case IUNL
            Case 4 : Testo = Testo & ": Generazione dei segnalini"
            Case 2 : Testo = Testo & ": Fase finale"
        End Select
        If Not Editing Then
            Monitor.Motore.ProgrInizio(Testo, "Generazione disegno in corso")
            nAvan = GraficMain.sezioni.Nsezioni * ApparProv.Elementi.Count()
        End If
        For LungPip = 1 To sezioni.Nsezioni
            For j = 1 To ApparProv.Elementi.Count()
                Oggetto = ApparProv.Elementi(j - 1)
                AddMembrat = System.Math.Abs(Oggetto.GenMem.Tipo)
                If Not Editing Then
                    iAvan = iAvan + 1
                    Monitor.Motore.Avanzamento = 100 * iAvan / nAvan
                End If
                System.Windows.Forms.Application.DoEvents()
                If Monitor.Smetti And Not Editing Then
                    Monitor.Motore.ProgrAmmazza()
                    Exit Sub
                End If
                If AddMembrat > 0 And AddMembrat < 97 Then
                    DispDis()
                ElseIf AddMembrat = 0 And (IUNL = 2 Or IUNL = 5) Then
                    DispDis()
                End If
            Next
        Next LungPip
        LungPip = 1
        If IUNL = 2 And DisAcad Then
            Monitor.AcadDis.Application.ZoomAll()
            Monitor.AcadDis.Save()
        End If
        If Not Editing Then Monitor.Motore.ProgrAmmazza()
        If IUNL = 2 And DisAcad Then
            AppActivate(Monitor.AcadDis.Application.Caption)
        End If
    End Sub

End Module