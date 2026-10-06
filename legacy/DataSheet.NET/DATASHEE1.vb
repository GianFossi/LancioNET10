Option Strict Off
Option Explicit On 
Imports RoutBase1
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.common
Module DATASHEE1
    Public Const Conn As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source="
    Public Const ConnFine As String = ";Persist Security Info=False"
    '-------------
    Public RadiceHelp As String
    '-------------
    Public Const IDH_ERR_NOWMF As Short = 1000
    Public Const IDH_ERR_NOPROTO As Short = 1010
    Public Const IDH_ERR_NODS As Short = 1020
    Public Const IDH_PROTO_AGGCREA As Short = 2000
    Public Const IDH_AVV_PRESERVA As Short = 3000
    Public Const SezPref As String = "Preferenze PPSM"
    '==============================================
    Friend mioApert As Apert
    Private iBookMarkILM, iBookMarkIUNQ As Short
    Public myAssembly As System.Reflection.Assembly
    Public dvIUNQ, dvILM, dvLamiere, dvClassi As DataView
    Public idvIUNQ, idvILM, iLamiere, idvClassi As Short
    Public cmdIUNQ, cmdILM, cmdLamiere, cmdClassi As OleDbDataAdapter
    Public CBIUNQ, CBILM, CBLamiere, CBClassi As OleDbCommandBuilder
    Public objIFST As clsDataSheet
    Public rmHelpStrings As Resources.ResourceManager
    Public rmHelpTopics As Resources.ResourceManager
    Public Verboso As Boolean
    Public Sp As Single
    Public Indmat As Short ', Indv As Integer
    Public IndMatClick As Short
    Public SpClick As Single
    Public GlobalRoutines As RoutBase1.clsTrigon
    Private a1, a, a2 As String
    Private ifl As Short
    Private ListaDupl As DataTable
    Private File, Filev, Nota As String
    Private Polig As Grafica.clsPolig
    Private iC As Short
    Private Num As String
    Private Ang1, Ang2 As Single
    Private Mode, j0 As Short
    Private NRISP As Short
    Private Spic As New Grafica.Spicchi
    Private cono As New Grafica.Cono
    Private Ri, Re, d As Single
    Private jPezziUguali, NumLam As Short
    Private NumLamS, iDisp As Short
    Private Noloop As Boolean
    Private Mat As LibMat.MaterialeNew1
    Private Ifine, Inizio As Short
    Private grezzo1Dimens2 As Single
    Private MaxProva As Short
    Private OK1 As Boolean
    Private IndiciQ As DataTable
    Private Quadrok1 As New Grafica.clsLamQuadr
    Private QuadroS As New Grafica.clsLamQuadr
    Private Quadro1 As New Grafica.clsLamQuadr
    Private MaxAlto(10) As Short
    Private NumP(10) As Short
    Private NumAlto(10) As Short
    Private GiaAlto(10) As Boolean
    Private Maxx As Single
    Private NumPP As Short
    Private IDLamL(10) As Integer
    Private StartC(10) As Short
    Private CercaX(10) As Single
    Private MatVol() As Short
    Private CercaY(10) As Single
    Private ImpLung(10) As Short
    Private ImpLarg(10) As Short
    Private Quadro As New Grafica.clsLamQuadr
    Private Lamiere As DataTable
    Private LungILM As DataTable
    Private g As New Grafica.clsGenMem
    Private varModifProto As Boolean
    Private OKprova As Boolean
    Private CandTL, CandBR As clsVec2
    Private CandTL1, CandBR1 As clsVec2
    Private y, x, Margin As Single
    Private NSPI, Tipo As Short
    Private grezzi As DataTable
    Private SubRect As RoutBase1.Rettangolo
    Private CentX, CentY As Single
    Public PrimaLungDopoLarg As Boolean
    Private K2, K1 As Short
    Private Lung, AngX As Single
    Private Log2, Log1, Log3 As Boolean
    Private Log4, Log5 As Boolean
    Private LBR As Single
    Private Delta1, Delta, Qmax As Single
    Private Noloop1, ii As Short
    Private u, kk As String
    Private OK As Boolean
    Private IDlam As Short
    Private Text As String
    Private IDVec As Integer
    Private Stoppa As Boolean
    Private iDispV As Integer
    Private MaxY As Single
    Private MaxS, MaxD As Short
    Private kMaxD, kMaxS, NumV As Short
    Private Stopp3 As Boolean
    Private Maxk, Maxkx As Short
    Private Procedi As Boolean
    Private i, iSch, jSch As Short
    Private k, iDispMax As Short
    Private off1x, off1y As Single
    Public Monitor As clsMonitor
    Public Routines As RoutBase1.Routines
    Public Funzioni As Grafica.LibGra
    Public dbClassi As OleDbConnection
    Public tbClassi As DataTable
    Public Item As String
    Public job As RoutBase1.clsjob
    Public Contr, icome As String
    Public FileData As String
    Public Flangia As Grafica.Flangia
    Public IUNA As Short
    Public ProtoTyp As String
    Public FileGre As String
    Public GrezziMDB As OleDbConnection
    Public DataSheet As RoutBase1.clsDatiDes
    Const AUTOMATIC As Short = 1
    Const MANUAL As Short = 2
    Const NONE As Short = 0
    Public Indexx As Short
    Public Classe As Short
    Public ModifiedData As Short
    Public Esiste As Short
    Public Stub As StubW2000.clsSW2000
    Private FileSt As String
    'Private R As Word.Range
    Private Rect As New Collection
    Public IUNQ As DataTable
    Private ySmin, xSmin, xSmax, ySmax As Single
    Sub Convert(ByRef NewUnit As Short)
        Dim Index, iRec, i, j As Short
        Dim n2, n1, ifl As Short
        Dim Fact, Valor As Single
        Dim Stringa As String
        Dim Riga0, Riga, Riga1 As String
        Dim Unit, Capt As String
        Select Case DataSheet.DatiPrg.UniMis
            Case 1
                Select Case NewUnit
                    Case 1 : Exit Sub
                    Case 2 : Index = 3
                    Case 3 : Index = 4
                End Select
            Case 2
                Select Case NewUnit
                    Case 1 : Index = 1
                    Case 2 : Exit Sub
                    Case 3 : Index = 2
                End Select
            Case 3
                Select Case NewUnit
                    Case 1 : Index = 6
                    Case 2 : Index = 5
                    Case 3 : Exit Sub
                End Select
        End Select
        ifl = FreeFile()
        FileOpen(ifl, RTrim(Monitor.Motore.Inizio.Archdir) & "\NCOEFF.DAT", OpenMode.Input)
        For i = 1 To Index : Riga = LineInput(ifl) : Next
        For i = Index + 1 To 6 : Riga0 = LineInput(ifl) : Next
        For i = 1 To NewUnit : Riga1 = LineInput(ifl) : Next
        FileClose(ifl)
        For i = 0 To 5
            j = Val(DataShee.DefInstance.ValorM(i).Tag)
            Unit = RTrim(Mid(Riga1, (j - 1) * 12 + 1, 12))
            Capt = DataShee.DefInstance.LabFlui(i).Text
            n1 = InStr(Capt, "(")
            n2 = InStr(Capt, ")")
            Mid(Capt, n1, n2 - n1 + 1) = Space(n2 - n1 + 1)
            n2 = Len(Capt)
            n1 = n2 - Len(Unit) - 1
            Mid(Capt, n1, n2 - n1 + 1) = "(" & Unit & ")"
            DataShee.DefInstance.LabFlui(i).Text = Capt
            Fact = Val(Mid(Riga, (j - 1) * 12 + 1, 12))
            Valor = Val(DataShee.DefInstance.ValorM(i).Text)
            DataShee.DefInstance.ValorM(i).Text = Str(Fact * Valor)
            Valor = Val(DataShee.DefInstance.ValorT(i).Text)
            DataShee.DefInstance.ValorT(i).Text = Str(Fact * Valor)
        Next
        For i = 0 To 15
            If i <> 8 Then j = Val(DataShe1.DefInstance.ValorM(i).Tag) Else j = 0
            If j Then
                Fact = Val(Mid(Riga, (j - 1) * 12 + 1, 12))
                Valor = Val(DataShe1.DefInstance.ValorM(i).Text)
                If j = 2 And Fact < 0.9 Then Valor = Valor - 32
                DataShe1.DefInstance.ValorM(i).Text = Str(Fact * Valor)
                If j = 2 And Fact > 1.1 Then DataShe1.DefInstance.ValorM(i).Text = Str(Fact * Valor + 32)
                If i < 12 Then
                    Valor = Val(DataShe1.DefInstance.ValorT(i).Text)
                    If j = 2 And Fact < 0.9 Then Valor = Valor - 32
                    DataShe1.DefInstance.ValorT(i).Text = Str(Fact * Valor)
                    If j = 2 And Fact > 1.1 Then DataShe1.DefInstance.ValorT(i).Text = Str(Fact * Valor + 32)
                End If
            End If
        Next
        Unit = RTrim(Mid(Riga1, (2 - 1) * 12 + 1, 12))
        Stringa = DataShe1.DefInstance.Label4.Text
        Mid(Stringa, Len(Stringa) - 2, 2) = Unit
        DataShe1.DefInstance.Label4.Text = Stringa
        Unit = Left(Mid(Riga1, (23 - 1) * 12 + 1, 12), 4)
        Stringa = DataShe1.DefInstance.Label5.Text
        Mid(Stringa, Len(Stringa) - 4, 4) = Unit
        DataShe1.DefInstance.Label5.Text = Stringa
        If InStr(DataShe1.DefInstance.cmdPHMant.Text, "C") Then
            Fact = Val(Mid(Riga, (23 - 1) * 12 + 1, 12))
            Valor = Val(DataShe1.DefInstance.ProvIdrMant.Text)
            DataShe1.DefInstance.ProvIdrMant.Text = Str(Fact * Valor)
        End If
        If InStr(DataShe1.DefInstance.cmdPHTubi.Text, "C") Then
            Fact = Val(Mid(Riga, (23 - 1) * 12 + 1, 12))
            Valor = Val(DataShe1.DefInstance.ProvIdrTubi.Text)
            DataShe1.DefInstance.ProvIdrTubi.Text = Str(Fact * Valor)
        End If
        Unit = Left(Mid(Riga1, (20 - 1) * 12 + 1, 12), 2)
        For i = 10 To 17
            If Not (i >= 11 And i <= 13) Then
                Stringa = DataShe1.DefInstance.LabFlui(i).Text
                Mid(Stringa, Len(Stringa) - 2, 2) = Unit
                DataShe1.DefInstance.LabFlui(i).Text = Stringa
            End If
        Next
    End Sub
    Public Sub Salva(ByRef OKpuoiIniziare As Boolean) '13-5-99
        'If Not OKpuoiIniziare Then Exit Sub '13-5-99
        OKpuoiIniziare = False
        If job Is Nothing Then Exit Sub '13-5-99
        If Trim(job.Comm.Arch) = "" Then Exit Sub '13-5-99
        job.Comm.SalvaCom()
        job.Salva()
        Funzioni.PutDes(job, DataSheet)
        ModifiedData = False
        OKpuoiIniziare = True '13-5-99
    End Sub
    Public Sub CreaPrototipo()
        Dim icome As String
        Dim numjob, i As Short
        Dim Workdir As String
        Dim jobProto As RoutBase1.clsjob
        Dim comProto As RoutBase1.clsComm
        Dim Radix, Testo As String
        Dim IndCodice As Short
        Dim Descrizione, Dettagli As String
        Dim OKpuoiIniziare As Boolean
        Dim cString As String = Conn & Monitor.Motore.Inizio.Archdir & "\PROTO\CLASSI.MDB" & ConnFine
        dbClassi = New OleDbConnection(cString)
        cmdClassi = New OleDbDataAdapter("SELECT * FROM Classi", dbClassi)
        tbClassi = New DataTable
        cmdClassi.Fill(tbClassi)
        CBClassi = New OleDbCommandBuilder(cmdClassi)
        dvClassi = tbClassi.DefaultView
        If Len(Trim(ProtoTyp)) = 0 Then
            CalcNumjob(numjob)
            ProtoTyp = VB6.Format(numjob + 1, "0000") & "01"
            dvClassi.RowFilter = "Codice=" & Str(Val(DataSheet.DatiSh0.IndCodice))
            dvClassi.RowFilter = "Categoria='" & DataSheet.DatiSh0.FBMLetter & "'"
            If dvClassi.Count = 0 Then
                MsgBox("Errore1 commessa in CreaPrototipo: " & DataSheet.DatiSh0.FBMLetter & "; " & DataSheet.DatiSh0.IndCodice)
                Exit Sub
            End If
            dvClassi(0).BeginEdit()
            dvClassi(0)("Commessa") = ProtoTyp
            dvClassi(0).EndEdit()
            cmdClassi.Update(tbClassi)
            Aggiorna(jobProto)
        Else
            Testo = Helpstringa(IDH_PROTO_AGGCREA)
            Testo = GlobalRoutines.FormatS(Testo, ProtoTyp)
            If MostraAiuto(IDH_PROTO_AGGCREA, RoutBase1.ChiaviMess.MessQuestion + RoutBase1.ChiaviMess.MessYesNo, Testo) = RoutBase1.ChiaviMess.MessSi Then 'aggiornamento
                Aggiorna(jobProto)
            Else 'creazione
                Dim FormProto As New frmProto
                FormProto.Oper = 1
                CalcNumjob(numjob)
                CalcIndice(dvClassi, IndCodice)
                ProtoTyp = VB6.Format(numjob + 1, "0000") & "01"
                If Not FormProto.Inizializza1() Then
                    MsgBox("Huhm Huhm")
                End If
                FormProto.ShowDialog()
                Descrizione = FormProto.Descrizione
                Dettagli = FormProto.Dettagli
                Dim drv As DataRowView = dvClassi.AddNew()
                drv("Categoria") = DataSheet.DatiSh0.FBMLetter
                drv("Codice") = IndCodice + 1
                drv("Classe") = 0
                drv("TipoTEMA") = DataSheet.DatiSh0.TEMALetter(1) & DataSheet.DatiSh0.TEMALetter(2) & DataSheet.DatiSh0.TEMALetter(3)
                drv("Descrizione") = Descrizione
                drv("Dettagli") = Dettagli
                drv("HV") = job.Comm.Asse
                drv("Commessa") = ProtoTyp
                Select Case DataSheet.DatiSh0.FBMLetter
                    Case "P", "Q" : drv("Lati") = 1
                    Case Else : drv("Lati") = 2
                End Select
                drv("Stop") = "fine"
                drv.EndEdit()
                cmdClassi.Update(tbClassi)
                DataSheet.DatiSh0.IndCodice = Str(IndCodice + 1)
                OKpuoiIniziare = True
                Salva(OKpuoiIniziare) '13-5-99
                If Not OKpuoiIniziare Then '13-5-99
                    Stop
                End If
            End If
        End If
        Aggiorna(jobProto)
        Radix = RTrim(Monitor.Motore.Inizio.Archdir) & "\PROTO\A" & ProtoTyp
        FileCopy(Funzioni.FileDes("APR"), Radix & "\000.APR")
        FileCopy(Funzioni.FileDes("INP"), Radix & "\000.INP")
        FileCopy(Funzioni.FileDes("DES"), Radix & "\000.DES")
        FileCopy(Funzioni.FileDes("TRC"), Radix & "\000.TRC")
        FileCopy(Funzioni.FileDes("TRK"), Radix & "\000.TRK")
        FileCopy(Funzioni.FileDes("BLO"), Radix & "\000.BLO")
        FileCopy(Funzioni.FileDes("ADU"), Radix & "\000.ADU")
        FileCopy(Funzioni.FileDes("WND"), Radix & "\000.WND")
        FileCopy(Funzioni.FileDes("WMF"), Radix & "\000.WMF")
    End Sub
    Public Sub CalcIndice(ByVal dvClassi As DataView, ByRef IndCodice As Short)
        dvClassi.RowFilter = "Categoria='" & DataSheet.DatiSh0.FBMLetter & "'"
        Dim i As Short
        For i = 0 To dvClassi.Count - 1
            If dvClassi(i)("Codice") > IndCodice Then IndCodice = dvClassi(i)("Codice")
        Next
    End Sub
    Public Sub Aggiorna(ByRef jobProto As RoutBase1.clsjob)
        jobProto = New RoutBase1.clsjob(Monitor.Motore)
        jobProto.Motore = Monitor.Motore
        jobProto.Contratto = Left(ProtoTyp, 4)
        Monitor.Motore.Inizio.Workdir = Monitor.Motore.Inizio.Archdir & "\PROTO"
        jobProto.AggiungiCom(ProtoTyp)
        jobProto.Comm.Oggetto = job.Comm.Oggetto
        jobProto.Comm.job = jobProto.Contratto
        jobProto.Comm.Arch = ProtoTyp
        jobProto.Comm.Item = job.Comm.Item
        jobProto.Comm.Impianto = job.Comm.Impianto
        jobProto.Comm.Clie = job.Comm.Clie
        jobProto.Comm.Comp = job.Comm.Comp
        jobProto.Comm.NumAs = 1
        jobProto.Comm.Asse = job.Comm.Asse
        jobProto.Comm.peso = job.Comm.peso
        jobProto.Comm.CalcBaric = job.Comm.CalcBaric
        jobProto.Comm.LungM = job.Comm.LungM
        jobProto.Comm.LargM = job.Comm.LargM
        jobProto.Comm.SalvaCom()
        jobProto.Salva()
    End Sub
    Public Sub CalcNumjob(ByRef numjob As Short)
        Dim i As Short
        Do Until idvClassi < dvClassi.Count - 1
            If IsDBNull(dvClassi(idvClassi)("Commessa")) Then
                icome = ""
            Else
                icome = dvClassi(idvClassi)("Commessa")
            End If
            If Len(Trim(icome)) = 6 Then
                i = Val(Left(icome, 4))
                If i > numjob Then numjob = i
            ElseIf Len(Trim(icome)) > 0 Then
                MsgBox("Errore commessa in CreaPrototipo: " & icome)
                Exit Sub
            End If
            idvClassi += 1
        Loop
    End Sub
    Public Sub CondensaMDB()
        Dim Dupl, Espanso As DataTable
        Dim ListaDupl As DataTable
        Dim iD As Short
        Dim SQL, t As String
        Dim NPezzi As Short
        Dim APR As String
        APR = job.Comm.Arch.Trim & "\" + job.Comm.Ind.Item(job.Comm.indice).Data.File
        Dim cmd As OleDbDataAdapter = New OleDbDataAdapter("SELECT * FROM Duplicati", GrezziMDB)
        Dupl = New DataTable
        cmd.Fill(Dupl)
        Dim CB As OleDbCommandBuilder = New OleDbCommandBuilder(cmd)
        Dim dvDupl As DataView = New DataView(Dupl)
        If Dupl.Rows.Count = 0 Then Exit Sub
        Dim cmdLista As OleDbDataAdapter = New OleDbDataAdapter("SELECT * FROM ListaDuplicati WHERE APR='" & APR & "'", GrezziMDB)
        ListaDupl = New DataTable
        cmdLista.Fill(ListaDupl)
        Dim CBLista As OleDbCommandBuilder = New OleDbCommandBuilder(cmdLista)
        Dim dvLista As DataView = New DataView(ListaDupl)
        For i = 0 To dvLista.Count - 1
            dvLista.Delete(0)
        Next
        For i = 0 To dvDupl.Count
            If Not IsDBNull(dvDupl(i)("CodiceCampo")) Then
                SQL = "SELECT * FROM Grezzi WHERE "
                SQL = SQL & " Codice='" + dvDupl(i)("CodiceCampo") + "' AND "
                SQL = SQL & " IndMat=" & Str(dvDupl(i)("IndMatCampo")) & " AND "
                SQL = SQL & " Variab1=" & Str(dvDupl(i)("Variab1Campo")) & " AND "
                SQL = SQL & " Variab2=" & Str(dvDupl(i)("Variab2Campo")) & " AND "
                SQL = SQL & " Variab3=" & Str(dvDupl(i)("Variab3Campo")) & " AND "
                SQL = SQL & " Variab4=" & Str(dvDupl(i)("Variab4Campo")) & " AND "
                SQL = SQL & " Variab5=" & Str(dvDupl(i)("Variab5Campo")) & " AND "
                If Asc(dvDupl(i)("Txt2Campo")) < 33 Then
                    t = ""
                    SQL = SQL & " Asc(Txt2)<33 AND "
                Else
                    t = dvDupl(i)("Txt2Campo")
                    SQL = SQL & " Txt2='" & t & "' AND "
                End If
                If Asc(dvDupl(i)("Txt3Campo")) < 33 Then
                    t = ""
                    SQL = SQL & " Asc(Txt3)<33 AND "
                Else
                    t = dvDupl(i)("Txt3Campo")
                    SQL = SQL & " Txt3='" & t & "' AND "
                End If
                SQL = SQL & " Dim1=" & Str(dvDupl(i)("Dim1Campo")) & " AND "
                SQL = SQL & " Dim2=" & Str(dvDupl(i)("Dim2Campo")) & " AND "
                SQL = SQL & " Dim3=" & Str(dvDupl(i)("Dim3Campo")) & ";"
                Dim cmdEspanso As OleDbDataAdapter = New OleDbDataAdapter(SQL, GrezziMDB)
                Espanso = New DataTable
                cmdEspanso.Fill(Espanso)
                Dim CBEspanso As OleDbCommandBuilder = New OleDbCommandBuilder(cmdEspanso)
                Dim dvEspanso As DataView = New DataView(Espanso)
                If dvEspanso.Count > 0 Then
                    NPezzi = 0
                    Dim j As Short
                    For j = 0 To dvEspanso.Count - 2
                        iD = dvEspanso(0)("iD")
                        dvEspanso(0).BeginEdit()
                        dvEspanso(0)("NPezzi") = dvEspanso(0)("NPezzi") + NPezzi
                        If dvEspanso(0)("NPezzi") = 0 Then dvEspanso(0)("NPezzi") = 1
                        dvEspanso(0).EndEdit()
                        NPezzi = dvEspanso(0)("NPezzi")
                        If NPezzi = 0 Then NPezzi = 1
                        Dim drv As DataRowView = dvDupl.AddNew()
                        drv.BeginEdit()
                        drv("IDCampo") = iD
                        drv("APR") = dvEspanso(0)("APR")
                        drv("IndRec") = dvEspanso(0)("IndRec")
                        drv.EndEdit()
                        dvEspanso.Delete(0)
                    Next j
                    Dim drvDupl As DataRowView = dvDupl.AddNew()
                    drvDupl.BeginEdit()
                    drvDupl("IDCampo") = iD
                    drvDupl("APR") = dvEspanso(0)("APR")
                    drvDupl("IndRec") = dvEspanso(0)("IndRec")
                    drvDupl.EndEdit()
                    dvEspanso(0).BeginEdit()
                    dvEspanso(0)("APR") = "***"
                    dvEspanso(0)("IndRec") = 0
                    dvEspanso(0).EndEdit()
                End If
                cmdEspanso.Update(Espanso)
            End If
        Next i
        cmdLista.Update(ListaDupl)
    End Sub
    Public Sub AggiungiLamiereMDB()
        Dim Lista, ListaLam As DataTable
        Dim i As Short
        GlobalRoutines.TableDelete("GrezziLam", Conn & FileGre & ConnFine)
        Lista = New DataTable
        Dim cmd As OleDbDataAdapter = New OleDbDataAdapter("SELECT * FROM Grezzi WHERE IndiceL=0", GrezziMDB)
        cmd.Fill(Lista, "Grezzi")
        Dim dvLista As DataView = New DataView(Lista)
        GlobalRoutines.DuplicaTableDef(Lista, "GrezziLam", Conn & FileGre & ConnFine)
        ListaLam = New DataTable
        Dim cmdLam As OleDbDataAdapter = New OleDbDataAdapter("SELECT * FROM GrezziLam", GrezziMDB)
        cmdLam.Fill(ListaLam)
        Dim CBLam As OleDbCommandBuilder = New OleDbCommandBuilder(cmdLam)
        Dim dvListaLam As DataView = New DataView(ListaLam)
        For i = 0 To dvLista.Count - 1
            Dim drv As DataRowView = dvListaLam.AddNew()
            drv.BeginEdit()
            Dim j As Short
            For j = 1 To dvListaLam.Count - 1
                drv(j) = dvLista(i)(j)
            Next
            drv("IndFile") = dvLista(i)("iD")
            drv.EndEdit()
        Next
        Lista = New DataTable
        cmd = New OleDbDataAdapter("SELECT * FROM Lamiere", GrezziMDB)
        cmd.Fill(Lista)
        CBLam = New OleDbCommandBuilder(cmd)
        dvLista = New DataView(Lista)
        For i = 0 To dvLista.Count - 1
            Dim drv As DataRowView = dvListaLam.AddNew()
            drv.beginedit()
            drv("Codice") = "LAM "
            drv("APR") = "$$$"
            drv("Indmat") = dvLista(0)("Indmat")
            drv("NPezzi") = 1
            drv("Variab1") = dvLista(0)("Sp")
            drv("Dim1") = dvLista(0)("LARG")
            drv("Dim2") = dvLista(0)("Lung")
            drv("IndRec") = dvLista(0)("iD")
            drv.endedit()
        Next i
        cmdLam.Update(ListaLam)
    End Sub
    Public Sub ListaMDB()
        Dim Lista As DataTable
        Dim Codice As String
        Dim Codici As DataTable
        Dim Indmat As Short
        Dim i, ifl As Short
        Lista = New DataTable
        Dim cmd As OleDbDataAdapter = New OleDbDataAdapter _
        ("SELECT * FROM GrezziLam INNER JOIN Codici ON GrezziLam.Codice=Codici.Codice ORDER BY Codici.Ordine,IndMat", _
          GrezziMDB)
        Dim dvLista As DataView = New DataView(Lista)
        Codice = ""
        IniziaDoc()
        For i = 0 To dvLista.Count - 1
            If Not Codice = dvLista(i)(1) Then
                Codice = dvLista(i)(1)
                Codici = New DataTable
                Dim cmdCodici As OleDbDataAdapter = New OleDbDataAdapter _
                ("SELECT * FROM Codici WHERE Codice='" & Codice & "'", GrezziMDB)
                cmdCodici.Fill(Codici)
                StampaTesta(Codici)
                Indmat = 0
            End If
            If Not Indmat = dvLista(i)("Indmat") Then
                Indmat = dvLista(i)("Indmat")
                StampaMat(Codici, Indmat)
            End If
            StampaCampi(Codici, Lista, ifl)
        Next i
        FileClose(ifl)
    End Sub
    Public Sub StampaTesta(ByRef Codici As DataTable)
        Dim Testo As String
        Dim dvCodici As DataView = New DataView(Codici)
        Testo = dvCodici(0)("Descrizione")
        Stub.TestaDS(Testo, "Prodotto")
    End Sub
    Public Sub ApriDoc()
        Monitor.Motore.Inizio.SuperStampa(FileSt, Stub) 'Doc
    End Sub
    Public Sub IniziaDoc()
        Dim Testo As String
        FileSt = Monitor.Motore.Inizio.Archdir & "\GRZ.DOC"
        Monitor.Motore.Inizio.SuperStampa(FileSt, Stub) 'Doc
        FileSt = Funzioni.FileDes("GRZ.DOC")
Rif:    Try
            Stub.sSaveAs(FileSt)
        Catch e As Exception
            Testo = "Impossibile salvare il documento Word " & FileSt & "." & vbCrLf
            Testo = Testo & "E' possibile che esso sia già aperto in WinWord." & vbCrLf
            Testo = Testo & "In tal caso attivare WinWord, chiudere il documento e poi riprovare."
            Select Case MsgBox(Testo, MsgBoxStyle.RetryCancel + MsgBoxStyle.Information, "PPSM")
                Case MsgBoxResult.Retry : GoTo Rif
                Case MsgBoxResult.Cancel
                    Stub.sClose()
                    Exit Sub
            End Select
        End Try
        '----------------------------
        Stub.IntestaGr(job.Comm.Arch, job.Comm.Ind(job.Comm.NumAs).Data.Assieme)
        Stub.VaiInizio()
    End Sub
    Public Sub StampaMat(ByRef Codici As DataTable, ByRef Indmat As Short)
        Dim Mat As LibMat.MaterialeNew1
        Dim Test1 As String
        Dim Testo As String
        Dim i, j As Short
        Mat = New LibMat.MaterialeNew1
        Mat.Indmat = Indmat
        Mat.RecupMat("")
        Testo = "Materiale" & Chr(9) & Mat.MatStr
        Test1 = Chr(9) & "Qta"
        j = 0
        Dim dvCodici As DataView = New DataView(Codici)
        For i = 3 To dvCodici.Count - 3
            If Len(dvCodici(0)(i)) Then
                Test1 = Test1 & Chr(9) + dvCodici(0)(i)
                j = j + 1
            End If
        Next
        For i = j + 1 To 9
            Test1 = Test1 & Chr(9)
        Next
        Test1 = Test1 & Chr(9) & "Dis." & Chr(9) & "Pos." & Chr(9) & "Denominazione"
        With Stub
            .TestaDS(Testo, "Materiale")
            .TestaDS(Test1, "Titoli")
        End With
    End Sub
    Public Sub StampaCampi(ByRef Codici As DataTable, ByRef Lista As DataTable, ByRef ifl As Short)
        Dim i, j As Short
        Dim Test1 As String
        Dim n As Short
        Dim DuplLoc As DataTable
        Dim Secondo As Boolean
        Dim dvLista As DataView = New DataView(Lista)
        Dim dvCodici As DataView = New DataView(Codici)
        Test1 = Chr(9) & Str(dvLista(0)("NPezzi"))
        j = 0
        For i = 3 To dvCodici.Count - 3
            If Len(dvCodici(0)(i)) Then
                If Lista.Columns(i + 5).DataType Is System.Type.GetType("System.String") Then
                    Test1 = Test1 & Chr(9) + dvLista(0)(i + 5)
                Else
                    Test1 = Test1 & Chr(9) & dvLista(0)(i + 5).ToString
                End If
                j = j + 1
            End If
        Next
        For i = j + 1 To 9
            Test1 = Test1 & Chr(9)
        Next
        If dvLista(0)("APR") = "***" Then
            Test1 = Test1 & Chr(9) + dvLista(0)("APR")
        ElseIf dvLista(0)("APR") = "$$$" Then
            Test1 = Test1 & Chr(9) + dvLista(0)("APR")
        Else
            Test1 = Test1 & Chr(9) & Right(dvLista(0)("APR"), 6)
            File = RTrim(Monitor.Motore.Inizio.Workdir) & "\" + dvLista(0)("APR") + ".APR"
            ' If Not File = Filev Then
            ' If ifl Then FileClose(ifl)
            ' ifl = FreeFile()
            ' FileOpen(ifl, File, OpenMode.Random, , , Len(Record))
            ' Filev = File
            'End If
            ' FileGet(ifl, Record, Lista.Fields("IndRec"))
            'Test1 = Test1 & Chr(9) & Str(Record.PosDis)
            'Test1 = Test1 & Chr(9) & Trim(Record.Denom)
        End If
        With Stub
            .TestaDS(Test1, "Normale")
            n = InStr(Test1, "***")
            If n > 0 Then
                DuplLoc = New DataTable
                Dim cmd As OleDbDataAdapter = New OleDbDataAdapter( _
                    "SELECT * FROM ListaDuplicati WHERE IDCampo=" & _
                    dvLista(0)("IndFile").ToString, GrezziMDB)
                cmd.Fill(DuplLoc)
                Secondo = False
                StampaNota(Secondo, File, Filev, Nota, DuplLoc, n)
            End If
            n = InStr(Test1, "$$$")
            If n > 0 Then
                DuplLoc = New DataTable
                Dim cmd As OleDbDataAdapter = New OleDbDataAdapter( _
                    "SELECT * FROM Grezzi WHERE IndiceL=" & _
                    CStr(dvLista(0)("IndRec")), GrezziMDB)
                Secondo = True
                StampaNota(Secondo, File, Filev, Nota, DuplLoc, n)
            End If
        End With
        Exit Sub
    End Sub
    Public Sub StampaNota(ByVal Secondo As Boolean, ByVal File As String, ByVal Filev As String, _
                          ByVal Nota As String, ByVal DuplLoc As DataTable, ByVal n As Short)
        Dim j As Integer, ifl As Integer
        Dim dv As DataView = New DataView(DuplLoc)
        If dv.Count > 0 Then
            For j = 0 To dv.Count - 1
                If Not dv(j)("APR") = "***" Then
                    Nota = Nota & Str(j + 1) & " [" & Right(dv(j)("APR"), 6)
                    '  File = RTrim(Monitor.Motore.Inizio.Workdir) & "\" + DuplLoc.Fields("APR") + ".APR"
                    '  If Not File = Filev Then
                    '  ifl = FreeFile()
                    '  FileOpen(ifl, File, OpenMode.Random, , , Len(Record))
                    '  Filev = File
                    'End If
                    ' FileGet(ifl, Record, DuplLoc.Fields("IndRec"))
                    ' Nota = Nota & ", " & Str(Record.PosDis)
                    ' Nota = Nota & ", " & Trim(Record.Denom) & "];"
                End If
            Next j
        Else
            If Secondo Then
                Nota = "Lamiera priva di impieghi."
            Else
                MsgBox("Errore1")
            End If
        End If
        If Len(Nota) > 0 Then Mid(Nota, Len(Nota), 1) = "."
        Stub.StampaNota(Nota, n)
    End Sub
    Sub Formati()
        Dim listmat As System.Windows.Forms.ListViewItem
        Dim listspess As System.Windows.Forms.ListViewItem
        Dim c As Control
        '################ posiziona su lamiera ###########################
        Sp = 0 : Indmat = 0
        Mat = New LibMat.MaterialeNew1
        dvIUNQ = New DataView(IUNQ)
        dvILM = New DataView(LungILM)
        Dim i As Short
        For i = 0 To dvIUNQ.Count - 1
            Stoppa = False
            If dvIUNQ(i)("Variab1") <> Sp Or dvIUNQ(i)("Indmat") <> Indmat Then
                Indmat = dvIUNQ(i)("Indmat") : Sp = dvIUNQ(i)("Variab1")
RedoRedo:
                'GoSub ProxMat :---------------------------------------------
                For ii = 1 To 10
                    NumAlto(ii) = 1
                    MaxAlto(ii) = 0
                    NumP(ii) = 0
                    StartC(ii) = 1
                    CercaX(ii) = 0 : CercaY(ii) = 0
                    IDLamL(ii) = 0
                Next
                MaxProva = 0
                OK = True
                NumLam = 1 : NumLamS = 1 : Inizio = 1 : Ifine = 1
                ' LungILM.AddNew
                ' LungILM!Num = 0: LungILM!Iniz = 0
410:            Do
                    Procedi = False
                    Mat.Indmat = dvIUNQ(i)("Indmat")
                    Mat.RecupMat(Monitor.Motore.Inizio.Archdir)
                    For Each listmat In frmForm.DefInstance.ListViewMat.Items
                        If listmat.Checked Then
                            If Mat.MatStr = listmat.Text Then Procedi = True : Exit For
                        End If
                    Next listmat
                    If Procedi Then
                        '                     Text = "Il prossimo materiale è: " + RTrim$(Mat.matstr) + "," + vbCrLf
                        '              Text = Text + "di spessore " + Str$(IUNQ!Variab1) + " mm." + vbCrLf
                        '              Text = Text + "Vuoi farne i formati (Si) o passare al successivo (No)? " + vbCrLf
                        '              Text = Text + "(se ce n'e' uno)"
                        '               x = MsgBox(Text, vbQuestion + vbYesNoCancel) 'Alert(2, a$, 8, 11, 13, 64, "Procedi", "Salta", "Exit")
                        x = MsgBoxResult.No
                        For Each c In frmForm.DefInstance.Controls
                            If c.Name.IndexOf("ListViewSpess") > -1 Then
                                For Each listspess In CType(c, ListView).Items
                                    If listspess.Checked Then
                                        If dvIUNQ(i)("Variab1") = Val(Right(listspess.Text, Len(listspess.Text) - 8)) Then x = MsgBoxResult.Yes : Exit For
                                    End If
                                Next listspess
                            End If
                        Next
                    Else
                        x = MsgBoxResult.No
                    End If
                    If x = MsgBoxResult.No Then
                        Skippa(OK)
                        If Not OK Then Exit Do
                    ElseIf x = MsgBoxResult.Cancel Then  'Or x = 0 Then
413:                    OK = False
                        Exit Do
                    Else
                        Exit Do
                    End If
                Loop
                '------------------------------------------------------------
                If Not OK Then Exit For
                Sp = dvIUNQ(i)("Variab1")
                AcqForm()
                '	GoSub NewLam!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                Dim drv As DataRowView = dvILM.AddNew()
                drv.BeginEdit()
                drv("Indmat") = dvIUNQ(i)("Indmat")
                drv(i)("Sp") = dvIUNQ(i)("Variab1")
                drv(i)("Num") = 0
                drv(i)("Iniz") = 0
                If NumLamS <= 10 Then
                    drv("LARG") = ImpLarg(NumLamS)
                    drv("Lung") = ImpLung(NumLamS)
                Else
                    drv("LARG") = job.Comm.LargM 'Lav(0).LargM
                    drv("Lung") = job.Comm.LungM 'Lav(0).LungM
                End If
                drv.EndEdit()
                '!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                iSch = 0 : jSch = 0
                Schermo()
            End If
            '?????????????????????????????????????????
            'For i = 1 To Quadr.Num
            Do While dvIUNQ(i)("Indmat") = Indmat And dvIUNQ(i)("Variab1") = Sp
                If Stoppa Then Exit Do 'For
                'posiziona grezzo*NPE su Lamiera ++++++++++++++++++++++++++++
                Noloop = True
                '++++++++++++++++++++++++++++++++++++++++
                If job.Comm.Ind(job.Comm.indice).Data.Qta = 0 Then job.Comm.Ind(job.Comm.indice).Data.Qta = 1
                For jPezziUguali = 1 To dvIUNQ(i)("NPezzi") * job.Comm.Ind(job.Comm.indice).Data.Qta
                    '               NUMERO DI APPARECCHI DA FARE
Riposiz:
                    If Stoppa Then Exit For
80:                 If NumLam = Ifine And Ifine > Inizio And Noloop And dvIUNQ(i)("Dim2") < 0.95 * grezzo1Dimens2 Then
                        Primo()
                        Scancel()
                        cmdILM.Update(LungILM)
                        NumLam = Inizio
                        MaxProva = 0
                        Schermo()
                        Dim ifound As Integer = dvILM.Find("ID=" & Str(IDLamL(NumLam)))
                        Quadro.Apri(GrezziMDB, dvILM(ifound)("iD"))
                        Noloop = False
                        Routines.texts(2, 7, "Lamiera" & Str(NumLam), 0, 0, 0)
                    End If
                    'LungILM.MoveFirst
100:                If dvILM(i)("Num") = 0 Then '1
                        MaxProva = 0
                        'GoSub LamPos1 ':::::::::::::::::::::::::::::::::::::::::::
                        OK = True
                        'Lamiera.IndinGre(1) = Quadr.IndinGre(i)
                        Quadro.TopLeft.X = 0
                        Quadro.TopLeft.y = 0
                        Quadro.Botrigt.X = dvIUNQ(i)("Dim1")
                        Quadro.Botrigt.y = dvIUNQ(i)("Dim2")
                        If Quadro.Botrigt.X > dvILM(i)("LARG") Or Quadro.Botrigt.y > dvILM(i)("Lung") Then
                            OK = False
                        Else
                            iDisp = dvILM(i)("Iniz") + 1
                            kk = "A"
                            AssegnaLamiera()
                            SubMonitor()
                        End If
                        '::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
                        If Not OK Then
                            CambLam()
                            If Not OK1 Then
                                Text = "Formati lamiera insufficienti in larghezza" & vbCrLf
                                Text = Text & "Vuoi provare a cambiare criterio di ordinamento?"
                                Sp = 0
                                If MsgBox(Text, MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.Yes Then
                                    PrimaLungDopoLarg = Not PrimaLungDopoLarg
                                    OK = True
                                    Riordina()
118:                                GoTo RedoRedo
                                Else
                                    OK = True
                                    Skippa(OK) : If Not OK Then Exit Do
120:                                GoTo RedoRedo
                                End If
                            End If
130:                        GoTo Riposiz
                        End If
                    Else '1
                        LamPosN()
                        If OK Then
                            CambLam()
                            If Not OK1 Then
                                Text = "Servirebbero piu' di dieci lamiere, oppure" & vbCrLf
                                Text = Text & "c'è qualche pezzo troppo largo."
                                MsgBox(Text)
                                '             Quadrv.sp = 0
                                Sp = 0
                                OK = True
                                Skippa(OK) : If Not OK Then Exit Do
160:                            GoTo RedoRedo
                            End If
                            GoTo Riposiz ' ELSE Noloop = TRUE
                        End If
                    End If '1
                    '        If LungILM!Num > 598 Then
                    '         MsgBox "troppi pezzi !"
                    '         Exit Do
                    '        End If
                    dvILM(i).BeginEdit()
                    dvILM(i)("Num") = dvILM(i)("Num") + 1
                    dvILM(i).EndEdit()
                    iBookMarkILM = i
                Next jPezziUguali
                '++++++++++++++++++++++++++++++++++++++++++++++
                grezzo1Dimens2 = dvIUNQ(i)("Dim2")
                'Next i
                i += 1 '.MoveNext()
                'If .EOF Then Exit Do
            Loop
            '??????????????????????????????????????????????
            u = GraphLam()
20:         If u = "C" Then
                i -= 1 '.MovePrevious()
            Else
                'If .EOF Then Exit Do
            End If
            ' Quadro.Chiudi
            ' Quadro.apri
        Next i
        Exit Sub
        '''PiuPiu:
        '''        IDlam = IDlam + 1
        '''        LungILM.Fields("IDlam").Value = IDlam
        '''        On Error GoTo Piu
        '''        LungILM.Update()
        '''        On Error GoTo 0
        '''        LungILM.Bookmark = VB6.CopyArray(LungILM.LastModified)
        '''        IDLamL(NumLam) = LungILM.Fields("iD").Value
        '''        Quadro.Apri(GrezziMDB, LungILM.Fields("iD").Value)
        '''        'UPGRADE_WARNING: Return ha un nuovo comportamento. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1041"'
        '''        Return
        '''Piu:    Resume PiuPiu
    End Sub
    Private Sub Cerca()
        Maxk = 1000 : MaxY = 1000000000.0# : Maxkx = 1000 : Maxx = 1000000000.0#
        If StartC(NumLam) = 0 Then StartC(NumLam) = 1
310:    For k = StartC(NumLam) To dvILM(idvILM)("Num")
            Routines.texts(2, 3, "CERCA" & Str(k), 0, 0, 0)
            Quadro.leggi(dvILM(idvILM)("Iniz") + k)
            CandTL.X = Quadro.TopLeft.X 'in basso
            CandTL.y = Quadro.Botrigt.y
312:        CandBR.X = CandTL.X + dvIUNQ(idvIUNQ)("Dim1")
            CandBR.y = CandTL.y + dvIUNQ(idvIUNQ)("Dim2")
            CandTL1.X = Quadro.Botrigt.X 'a destra
            CandTL1.y = Quadro.TopLeft.y
            CandBR1.X = CandTL1.X + dvIUNQ(idvIUNQ)("Dim1")
            CandBR1.y = CandTL1.y + dvIUNQ(idvIUNQ)("Dim2")
            For K1 = 1 To dvILM(idvILM)("Num")
                Quadrok1.leggi(dvILM(idvILM)("Iniz") + K1)
                If k <> K1 And Sovrap(CandTL, CandBR, Quadrok1.TopLeft, Quadrok1.Botrigt) Then GoTo xx1
                If Not (CandBR.y <= dvILM(idvILM)("Lung") And CandBR.X <= dvILM(idvILM)("LARG")) Then GoTo xx1
            Next K1
            If Quadro.Botrigt.y < MaxY Then MaxY = Quadro.Botrigt.y : Maxk = k : GoTo 329
xx1:
            For K1 = 1 To dvILM(idvILM)("Num")
                Quadrok1.leggi(dvILM(idvILM)("Iniz") + K1)
                If k <> K1 And Sovrap(CandTL1, CandBR1, Quadrok1.TopLeft, Quadrok1.Botrigt) Then GoTo xx2
                If Not (CandBR1.y <= dvILM(idvILM)("Lung") And CandBR1.X <= dvILM(idvILM)("LARG")) Then GoTo xx2
            Next K1
            If Quadro.Botrigt.X < Maxx Then Maxx = Quadro.Botrigt.X : Maxkx = k : GoTo 329
xx2:
            If Stopp3 Then Stopp3 = False : Exit For
        Next k
329:    If Maxkx < 1000 And Maxk < 1000 Then
            Quadro.leggi(dvILM(idvILM)("Iniz") + Maxkx)
331:        If Quadro.TopLeft.y - MaxY < 1.0! Then
332:            CandTL.X = Quadro.Botrigt.X
                CandTL.y = Quadro.TopLeft.y
                CandBR.X = CandTL.X + dvIUNQ(idvIUNQ)("Dim1")
                CandBR.y = CandTL.y + dvIUNQ(idvIUNQ)("Dim2")
                Maxk = Maxkx
            Else
                Quadro.leggi(dvILM(idvILM)("Iniz") + Maxk)
341:            CandTL.X = Quadro.TopLeft.X
                CandTL.y = Quadro.Botrigt.y
                CandBR.X = CandTL.X + dvIUNQ(idvIUNQ)("Dim1")
                CandBR.y = CandTL.y + dvIUNQ(idvIUNQ)("Dim2")
            End If
        ElseIf Maxkx < 1000 Then
            Quadro.leggi(dvILM(idvILM)("Iniz") + Maxkx)
343:        CandTL.X = Quadro.Botrigt.X
            CandTL.y = Quadro.TopLeft.y
            CandBR.X = CandTL.X + dvIUNQ(idvIUNQ)("Dim1")
            CandBR.y = CandTL.y + dvIUNQ(idvIUNQ)("Dim2")
            Maxk = Maxkx
        ElseIf Maxk < 1000 Then
            Quadro.leggi(dvILM(idvILM)("Iniz") + Maxk)
345:        CandTL.X = Quadro.TopLeft.X
            CandTL.y = Quadro.Botrigt.y
            CandBR.X = CandTL.X + dvIUNQ(idvIUNQ)("Dim1")
            CandBR.y = CandTL.y + dvIUNQ(idvIUNQ)("Dim2")
        End If
        '--------------------------------------------------------
    End Sub
    Private Sub Alto()
        If GiaAlto(NumLam) Then Exit Sub
        '+++++++++++++++++++spingi verso l'alto la fila superiore
        '            FOR NumPP = NumP(NumLam) TO Lamiera.Num
        For NumPP = NumAlto(NumLam) To dvILM(idvILM)("Num")
            '  LOCATE 9, 2: Print "Alto"; NumPP
            Routines.texts(2, 9, "Alto" & Str(NumPP), 0, 0, 0)
250:        MaxY = 0 : MaxS = 0 : MaxD = 0
            Quadro.leggi(dvILM(idvILM)("Iniz") + NumPP)
            For K1 = 1 To dvILM(idvILM)("Num") ' o NumPP? ? ? ? ?
                If K1 <> NumPP Then
                    'if un angolo basso di NumPP ha x compresa tra k1 THEN
                    Quadrok1.leggi(dvILM(idvILM)("Iniz") + K1)
260:                If Quadro.TopLeft.y >= Quadrok1.Botrigt.y Then
                        Log1 = Quadro.TopLeft.X > Quadrok1.TopLeft.X And Quadro.TopLeft.X < Quadrok1.Botrigt.X
                        Log2 = Quadro.Botrigt.X > Quadrok1.TopLeft.X And Quadro.Botrigt.X < Quadrok1.Botrigt.X
                        Log3 = System.Math.Abs(Quadro.TopLeft.X - Quadrok1.TopLeft.X) < 1.0! ' AND ABS(Quadro.TopLeft.X - Quadrok1.BotRigt.X) < 1.
                        Log4 = System.Math.Abs(Quadro.Botrigt.X - Quadrok1.Botrigt.X) < 1.0!
                        Log5 = Quadrok1.TopLeft.X > Quadro.TopLeft.X And Quadrok1.Botrigt.X < Quadro.Botrigt.X
                        LBR = Quadrok1.Botrigt.y
                        '                IF (Log1 OR Log2) OR (Log3 AND Log4) OR Log5 THEN
                        If Log1 Or Log2 Or Log3 Or Log4 Or Log5 Then
                            If LBR > MaxY Then MaxY = LBR
                        End If
                        If Log1 And LBR > MaxS Then MaxS = LBR : kMaxS = K1
                        If Log2 And LBR > MaxD Then MaxD = LBR : kMaxD = K1
                    End If
                End If
270:        Next K1
            'studio di un rettangolo sul bordo ++++++++++++++++++++++++++++++++
            Lung = Quadro.Botrigt.y - Quadro.TopLeft.y
280:        OK = False
            If Not (System.Math.Abs(MaxY - MaxS) > 1 And System.Math.Abs(MaxY - MaxD) > 1) Then
                If MaxS - MaxD > 0.9 * Lung Then
                    QuadroS.leggi(dvILM(idvILM)("Iniz") + kMaxS)
                    AngX = QuadroS.Botrigt.X
                    Delta = AngX - Quadro.TopLeft.X
                    If Quadro.Botrigt.X + Delta < dvILM(idvILM)("LARG") Then
                        Delta1 = Quadro.TopLeft.y - MaxD
                        CandTL.X = Quadro.TopLeft.X + Delta
                        CandTL.y = Quadro.TopLeft.y - Delta1
                        CandBR.X = Quadro.Botrigt.X + Delta
                        CandBR.y = Quadro.Botrigt.y - Delta1
                        For K1 = 1 To dvILM(idvILM)("Num")
                            Quadrok1.leggi(dvILM(idvILM)("Iniz") + K1)
                            If K1 <> NumPP And Sovrap(CandTL, CandBR, Quadrok1.TopLeft, Quadrok1.Botrigt) Then GoTo zzz
                            '                             IF Sovrap(CandTL, CandBR, Quadrok1.TopLeft, Quadrok1.BotRigt) THEN GOTO zzz
                        Next K1
                        Quadro.TopLeft.X = CandTL.X
                        Quadro.TopLeft.y = CandTL.y
                        Quadro.Botrigt.X = CandBR.X
                        Quadro.Botrigt.y = CandBR.y
                        iDisp = dvILM(idvILM)("Iniz") + NumPP : kk = "C"
                        AssegnaLamiera()
                        SubMonitor()
                        OK = True
                    End If
                End If
            End If
zzz:
            If Not OK Then
290:            Delta = Quadro.TopLeft.y - MaxY
                If System.Math.Abs(Delta) > 0.5 Then
                    Quadro.TopLeft.y = Quadro.TopLeft.y - Delta
                    Quadro.Botrigt.y = Quadro.Botrigt.y - Delta
                    iDisp = dvILM(idvILM)("Iniz") + NumPP : kk = "D"
                    AssegnaLamiera()
                    SubMonitor()
                End If
            End If
            If Stopp3 Then Stopp3 = False : Exit For
        Next NumPP
        '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++
300:    MaxAlto(NumLam) = 0
        For NumPP = NumP(NumLam) To dvILM(idvILM)("Num")
            MaxY = 0 : MaxS = 0 : MaxD = 0
            Quadro1.leggi(dvILM(idvILM)("Iniz") + NumPP)
            If Quadro1.Botrigt.y > MaxAlto(NumLam) Then MaxAlto(NumLam) = Quadro1.Botrigt.y
        Next
        Quadro1.leggi(dvILM(idvILM)("Iniz") + NumP(NumLam))
        OfSet()
        Quadro1.DrawRE(0, (ImpLarg(NumLam)), 4, 0)
        'LOCATE 9, 2: Print String$(12, Chr$(32))
        If Not GiaAlto(NumLam) Then NumAlto(NumLam) = dvILM(idvILM)("Num")
        GiaAlto(NumLam) = True
    End Sub
    Private Sub Promuovi()
        Quadro.TopLeft.X = CandTL.X
        Quadro.TopLeft.y = CandTL.y
        Quadro.Botrigt.X = CandBR.X
        Quadro.Botrigt.y = CandBR.y
        iDisp = dvILM(idvILM)("Iniz") + dvILM(idvILM)("Num") + 1 : kk = "B"
        AssegnaLamiera()
        SubMonitor()
    End Sub
    Private Sub Promuov1()
        Quadro.TopLeft.X = CandTL.X
        Quadro.TopLeft.y = CandTL.y
        Quadro.Botrigt.X = CandBR.X
        Quadro.Botrigt.y = CandBR.y
        iDisp = dvILM(idvILM)("Iniz") + dvILM(idvILM)("Num") + 1 : kk = "E"
        AssegnaLamiera()
        SubMonitor()
    End Sub
    Private Sub Prova()
        OKprova = True
        If CandBR.y > dvILM(idvILM)("Lung") Then GiaAlto(NumLam) = False
        If CandBR.y > dvILM(idvILM)("Lung") Or CandBR.X > dvILM(idvILM)("LARG") Then
            OKprova = False
            Exit Sub
        End If
        For K1 = 1 To dvILM(idvILM)("Num")
            Quadrok1.leggi(dvILM(idvILM)("Iniz") + K1)
            If Sovrap(CandTL, CandBR, Quadrok1.TopLeft, Quadrok1.Botrigt) Then
                OKprova = False
                Exit Sub
            End If
        Next K1
    End Sub
    Private Sub Cand2()
        Quadro.leggi(dvILM(idvILM)("Iniz") + dvILM(idvILM)("Num"))
200:    CandTL.X = Quadro.TopLeft.X
        CandTL.y = Quadro.Botrigt.y
        CandBR.X = CandTL.X + dvIUNQ(idvIUNQ)("Dim1")
        CandBR.y = CandTL.y + dvIUNQ(idvIUNQ)("Dim2")
        Maxx = 0
        For K2 = 1 To dvILM(idvILM)("Num")
            Quadrok1.leggi(dvILM(idvILM)("Iniz") + K2)
            If Quadrok1.Botrigt.X <= CandTL.X Then
                Log1 = Quadrok1.Botrigt.y < CandBR.y And Quadrok1.Botrigt.y > CandTL.y
                Log2 = Quadrok1.TopLeft.y < CandBR.y And Quadrok1.TopLeft.y > CandTL.y
                Log3 = System.Math.Abs(Quadrok1.Botrigt.y - CandBR.y) < 1
                Log4 = System.Math.Abs(Quadrok1.TopLeft.y - CandTL.y) < 1
                Log5 = Quadrok1.Botrigt.y > CandBR.y And Quadrok1.TopLeft.y < CandTL.y
                LBR = Quadrok1.Botrigt.X
                If Log1 Or Log2 Or Log3 Or Log4 Or Log5 Then
                    If LBR > Maxx Then Maxx = LBR
                End If
            End If
        Next K2
210:    Delta = CandTL.X - Maxx
        If Delta > 0 Then
            CandTL.X = CandTL.X - Delta
            CandBR.X = CandBR.X - Delta
        End If
    End Sub
    Private Sub LamPosN()
        Quadro.leggi(dvILM(idvILM)("Iniz") + dvILM(idvILM)("Num"))
        'UPGRADE_ISSUE: L'istruzione GoSub non è supportata. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1014"'
        'GoSub Cand1 'candidato a destra
        CandTL.X = Quadro.Botrigt.X
        CandTL.y = Quadro.TopLeft.y
        CandBR.X = CandTL.X + dvIUNQ(idvIUNQ)("Dim1")
        CandBR.y = CandTL.y + dvIUNQ(idvIUNQ)("Dim2")
        Noloop1 = 0
402:    Noloop1 = Noloop1 + 1
        If CandBR.X > dvILM(idvILM)("LARG") Or CandBR.y > dvILM(idvILM)("Lung") Then MaxProva = 0 : GoTo yyy
        '-------------- c'e' spazio a destra ----------------
        If MaxProva = 0 Or MaxProva > CandTL.y + 1 Then
            MaxProva = 0
370:        For K1 = 1 To dvILM(idvILM)("Num")
                Routines.texts(2, 6, "Prova" & Str(K1), 0, 0, 0)
                '            LOCATE 6, 2: Print "Prova"; K1
                Quadrok1.leggi(dvILM(idvILM)("Iniz") + K1)
                If Quadrok1.Botrigt.y > MaxProva And Quadrok1.Botrigt.X > CandTL.X Then MaxProva = Quadrok1.Botrigt.y
                If Sovrap(CandTL, CandBR, Quadrok1.TopLeft, Quadrok1.Botrigt) Then
                    Cand2() 'candidato sotto
                    MaxProva = 0
                    GoTo yy1
                End If
            Next K1
        End If
        GoTo OkOK
yy1:    Prova()
        If Not OKprova Then GoTo yyy
OkOK:   Promuovi()
        OK = False
        Exit Sub
        '-----------------------------------------------------
yyy:    Primo() 'ricerca il primo della fila superiore
        If CandBR.y < Quadro.TopLeft.y Then
            Cand2()
            Prova()
            If OKprova Then GoTo OkOK
        End If
        Alto() 'spingi verso l'alto
        'GoSub Cand11 
        CandTL.X = 0
        CandTL.y = MaxAlto(NumLam)
        CandBR.X = CandTL.X + dvIUNQ(idvIUNQ)("Dim1")
        CandBR.y = CandTL.y + dvIUNQ(idvIUNQ)("Dim2")
        If CandBR.y <= dvILM(idvILM)("Lung") And Noloop1 < 2 Then GoTo 402
        Cerca() 'cerca il posto libero piu' in alto
        If Maxk < 1000 And (CandBR.X - CandTL.X) > 0.95 * CercaX(NumLam) And (CandBR.y - CandTL.y) > 0.95 * CercaY(NumLam) Then
            StartC(NumLam) = Maxk
            CercaX(NumLam) = CandBR.X - CandTL.X
            CercaY(NumLam) = CandBR.y - CandTL.y
        ElseIf (CandBR.X - CandTL.X) < 0.85 * CercaX(NumLam) And (CandBR.y - CandTL.y) < 0.85 * CercaY(NumLam) Then
            StartC(NumLam) = 1
        End If
403:    If Maxk < 1000 Then
            Routines.texts(2, 3, New String(Chr(32), 8) & Str(Maxk) & New String(Chr(32), 4), 0, 0, 0)
            Promuov1()
        Else
            Routines.texts(2, 3, "     niente", 0, 0, 0)
            '               LOCATE 3, 2: Print "     niente"
            '------------cambia lamiera (dopo aver compattato ?) per fine spazio sp.
            OK = True
            Exit Sub
        End If
        OK = False
    End Sub
    Private Sub CambLam()
        MaxProva = 0
        OK1 = True
        NumLam = NumLam + 1
        If NumLam > 10 Then
            MsgBox("10")
            OK1 = False
            Exit Sub
        End If
        Schermo()
        If NumLam <= Ifine Then
            'LungILM.MoveFirst
            'LungILM.Move NumLam - 1
            'LungILM.Index = "PrimaryKey"
            'LungILM.Seek "=", IDLamL(NumLam)
            idvILM = dvILM.Find("ID=" & Str(IDLamL(NumLam)))
            Quadro.Apri(GrezziMDB, dvILM(idvILM)("iD"))
            'If LungILM!Iniz <= NumV Then
            '   MsgBox "scontro!": Stop
            'End If
        Else
            'GoSub NewLam '!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            Dim drv As DataRowView = dvILM.AddNew()
            drv("Indmat") = dvIUNQ(idvIUNQ)("Indmat")
            drv("Sp") = dvIUNQ(idvIUNQ)("Variab1")
            drv("Num") = 0 : drv("Iniz") = 0
            If NumLamS <= 10 Then
                drv("LARG") = ImpLarg(NumLamS)
                drv("Lung") = ImpLung(NumLamS)
            Else
                drv("LARG") = job.Comm.LargM 'Lav(0).LargM
                drv("Lung") = job.Comm.LungM 'Lav(0).LungM
            End If
            drv.EndEdit()
            idvILM = dvILM.Count - 1
            '!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            NumLamS = NumLamS + 1 : NumP(NumLam) = 0
            Ifine = Ifine + 1
        End If
        Routines.texts(2, 700, "Lamiera" & Str(NumLam), 0, 0, 0)
    End Sub
    Private Sub SubMonitor()
        If kk = "C" Or kk = "D" And Not GiaAlto(NumLam) Then NumAlto(NumLam) = NumPP
        GiaAlto(NumLam) = True
        If iDisp < iDispMax And Not (kk = "A" Or kk = "B" Or kk = "E") Then
            '   If Not (kk$ = "A" Or kk$ = "B" Or kk$ = "E") Then
            Quadro1.leggi(iDisp)
            OfSet()
            Quadro1.DrawRE(0, (ImpLarg(NumLam)), 3, 0)
        End If
        If iDisp > iDispMax Then iDispMax = iDisp
        Quadro.Scrivi(dvILM(idvILM)("iD"), iDisp)
        If jPezziUguali = 1 Then
            IndiciQ = New DataTable
            Dim cmd As OleDbDataAdapter = New OleDbDataAdapter( _
            "SELECT * FROM IndiciQ WHERE IndGrezzi=" & CStr(dvIUNQ(idvIUNQ)("iD")).ToString, _
            GrezziMDB)
            cmd.Fill(IndiciQ)
            Dim CB As OleDbCommandBuilder = New OleDbCommandBuilder(cmd)
            Dim dvIndiciQ As DataView = New DataView(IndiciQ)
            For i = 0 To dvIndiciQ.Count
                dvIndiciQ.Delete(0)
            Next
            cmd.Update(IndiciQ)
            dvIUNQ(idvIUNQ).BeginEdit()
            dvIUNQ(idvIUNQ)("IndiceQ") = iDisp
            dvIUNQ(idvIUNQ).EndEdit()
            iBookMarkIUNQ = idvIUNQ
            iDispV = iDisp
            IDVec = dvIUNQ(idvIUNQ)("iD")
        Else
            IndiciQ = New DataTable
            Dim cmd As OleDbDataAdapter = New OleDbDataAdapter( _
            "SELECT * FROM IndiciQ", _
            GrezziMDB)
            cmd.Fill(IndiciQ)
            Dim CB As OleDbCommandBuilder = New OleDbCommandBuilder(cmd)
            Dim dvIndiciQ As DataView = New DataView(IndiciQ)
            Dim drv As DataRowView
            If jPezziUguali = 2 Then
                drv = dvIndiciQ.AddNew()
                drv.BeginEdit()
                drv("IndGrezzi") = IDVec
                drv("IndiceQ") = iDispV
                drv.EndEdit()
            End If
            drv = dvIndiciQ.AddNew()
            drv.BeginEdit()
            drv("IndGrezzi") = dvIUNQ(idvIUNQ)("iD")
            drv("IndiceQ") = iDisp
            drv.EndEdit()
            cmd.Update(IndiciQ)
        End If
        Quadro.Copia(Quadro1)
        OfSet()
        Quadro1.DrawRE(0, (ImpLarg(NumLam)), 1, 0)
    End Sub
    Private Sub Scancel()
        If NumP(NumLam) > 0 Then
            Quadro1.leggi(dvILM(idvILM)("Iniz") + NumP(NumLam))
            OfSet()
            Quadro1.DrawRE(0, (ImpLarg(NumLam)), 1, 0)
        End If
    End Sub
    Private Sub OfSet()
        off1x = Rect.Item(NumLam).x(1) + Rect.Item(NumLam).LARG / 2
        '       For ii = iSch To NumLam - 1
        '          off1x = off1x + Rect(ii - iSch + 1).LARG + 250
        '       Next ii
        off1y = 0
        Quadro1.Botrigt.X = Quadro1.Botrigt.X + off1x
        Quadro1.TopLeft.X = Quadro1.TopLeft.X + off1x
        Quadro1.Botrigt.y = Quadro1.Botrigt.y + off1y
        Quadro1.TopLeft.y = Quadro1.TopLeft.y + off1y
    End Sub
    Private Sub Primo()
        '*************************************************************
        'ricerca il primo della fila superiore
        Scancel()
        Qmax = -1.0!
        For K1 = 1 To dvILM(idvILM)("Num")
            Quadro.leggi(dvILM(idvILM)("Iniz") + K1)
            If Quadro.TopLeft.X = 0 Then
                If Quadro.TopLeft.y > Qmax Then
                    Qmax = Quadro.TopLeft.y
                    NumP(NumLam) = K1
                End If
            End If
        Next
        Quadro.leggi(dvILM(idvILM)("Iniz") + NumP(NumLam))
        Quadro.Copia(Quadro1)
        OfSet()
        Quadro1.DrawRE(0, CSng(ImpLarg(NumLam)), 4, 0)
        '*****************************************************************
    End Sub
    Private Sub Schermo()
415:    If NumLam >= iSch And NumLam <= jSch Then
            Exit Sub
        Else
            iSch = 1 + ((NumLam - 1) \ 5) * 5 : jSch = iSch + 4
        End If
        Routines.DoveDisegno = frmForm.DefInstance.pctForm
        RectInizia(jSch - iSch + 1)
        For ii = iSch To jSch
            If ii > 10 Then MsgBox("Errore in Formati" & Str(ii)) : Stop
            Rect(ii - iSch + 1).MakeCorners(ImpLung(ii), ImpLarg(ii))
        Next ii
        DispoFor(jSch - iSch + 1, xSmin, xSmax, ySmin, ySmax, 0)
        Routines.Scala(xSmin, xSmax, ySmin, ySmax, 2)
        For ii = iSch To jSch
            Rect(ii - iSch + 1).RettGraf(Routines, 1)
            Routines.texts(Rect(ii - iSch + 1).x(1), Rect(ii - iSch + 1).y(3) + 10, "lam." & Str(ii), 0, 0, 0)
        Next ii
    End Sub
    Private Sub Skippa(ByRef OK As Boolean)
        Sp = dvIUNQ(idvIUNQ)("Variab1")
        Indmat = dvIUNQ(idvIUNQ)("Indmat")
        Do
            idvIUNQ += 1
            If idvIUNQ > dvIUNQ.Count - 1 Then
                OK = False
                Exit Sub
            End If
        Loop While dvIUNQ(idvIUNQ)("Variab1") = Sp And dvIUNQ(idvIUNQ)("Indmat") = Indmat
        Sp = dvIUNQ(idvIUNQ)("Variab1")
        Indmat = dvIUNQ(idvIUNQ)("Indmat")
    End Sub
    Sub SezVir()
        Dim NVIR, Ncl As Short
        Dim Resto As Single
        Dim j As Short
        Dim f() As Object
        Dim Segno As Short
        idvIUNQ = 0
        Do Until idvIUNQ < dvIUNQ.Count
            If dvIUNQ(idvIUNQ)("Dim4") > 1 And dvIUNQ(idvIUNQ)("Codice") = "RE  " Then
                NVIR = dvIUNQ(idvIUNQ)("Dim4")
                Ncl = Ncl + NVIR - 1
                dvIUNQ(idvIUNQ).BeginEdit()
                dvIUNQ(idvIUNQ)("Dim4") = 1
                Resto = dvIUNQ(idvIUNQ)("Dim1") - job.Comm.LargM + g.MargTag(dvIUNQ(idvIUNQ)("Variab1")) '!!!!! NOOOOOOOOH
                dvIUNQ(idvIUNQ)("Dim1") = Resto
                ReDim f(IUNQ.Columns.Count)
                For j = 1 To IUNQ.Columns.Count - 1
                    f(j) = dvIUNQ(idvIUNQ)(j)
                Next
                dvIUNQ(idvIUNQ).EndEdit()
                'Segno = idvIUNQ INUTILE
                Dim drv As DataRowView = dvIUNQ.AddNew()
                For j = 1 To IUNQ.Columns.Count - 1
                    drv(j) = f(j)
                Next
                drv("Dim1") = job.Comm.LargM - g.MargTag(dvIUNQ(idvIUNQ)("Variab1"))
                drv("NPezzi") = Ncl - NVIR + 2
                drv.EndEdit()
                'idviunq = Segno INUTILE
            End If
            idvIUNQ += 1
        Loop
    End Sub
    Function Sovrap(ByRef TL1 As clsVec2, ByRef BR1 As clsVec2, ByRef TL2 As RoutBase1.clsVec2, ByRef BR2 As RoutBase1.clsVec2) As Short
        Dim Logic As Boolean
        Logic = True
        If TL1.X - BR2.X > -0.01 Or BR1.X - TL2.X < 0.01 Then Logic = False
        If TL1.y - BR2.y > -0.01 Or BR1.y - TL2.y < 0.01 Then Logic = False
        Sovrap = Logic
    End Function
    Sub OffTrap()
        cmdILM.Update(LungILM)
        cmdIUNQ.Update(IUNQ)
        Quadro.Chiudi()
        'Kill Quadro.File 'RTrim$(Monitor.Motore.Inizio.Workdir) + "\PROVVV"
    End Sub
    Sub DrizzRett()
        Dim d As Single
        idvIUNQ = 0
        Do Until idvIUNQ < dvIUNQ.Count
            If dvIUNQ(idvIUNQ)("Dim1") > dvIUNQ(idvIUNQ)("Dim2") Then
                dvIUNQ(idvIUNQ).BeginEdit()
                d = dvIUNQ(idvIUNQ)("Dim1")
                dvIUNQ(idvIUNQ)("Dim1") = dvIUNQ(idvIUNQ)("Dim2")
                dvIUNQ(idvIUNQ)("Dim2") = d
                dvIUNQ(idvIUNQ).EndEdit()
            End If
            idvIUNQ += 1
        Loop
    End Sub
    Function GraphLam() As String
        Dim j, Ilam, i As Short
        Dim Log1, Log2 As Boolean
        Dim u As String
        Dim Log3 As Boolean
        Dim Mat As LibMat.MaterialeNew1
        Mat = New LibMat.MaterialeNew1
        Ilam = 1
        j = 1
        Lamiere = New DataTable
        Dim cmd As OleDbDataAdapter = New OleDbDataAdapter("SELECT * FROM Lamiere", GrezziMDB)
        cmd.Fill(Lamiere)
        GlobalRoutines.DuplicaTableDef(Lamiere, "LamiereN", Conn & FileGre & ConnFine)
        Dim cmdN As OleDbDataAdapter = New OleDbDataAdapter("SELECT * FROM LamiereN", GrezziMDB)
        Lamiere = New DataTable
        cmdN.Fill(Lamiere)
        dvLamiere = New DataView(Lamiere)
        For i = 0 To dvLamiere.Count - 1
            dvLamiere.Delete(0)
        Next
        LungILMMoveFirst(0)
        Mat.Indmat = dvILM(idvILM)("Indmat")
        Mat.RecupMat(Monitor.Motore.Inizio.Archdir)
        frmForm.DefInstance.Text = "Lamieramento " & Mat.MatStr & " Sp." & Str(dvILM(idvILM)("Sp"))
        Do
            Dim drv As DataRowView = dvLamiere.AddNew()
            drv.BeginEdit()
            For i = 1 To LungILM.Columns.Count - 1
                drv(i) = dvILM(idvILM)(i)
            Next
            drv("IDlam") = dvILM(idvILM)("iD")
            drv.EndEdit()
            iLamiere = dvLamiere.Count - 1
            ImpLung(j) = dvLamiere(iLamiere)("Lung")
            ImpLarg(j) = dvLamiere(iLamiere)("LARG")
            idvILM += 1
            Log3 = idvILM > dvILM.Count - 1
            If Not Log3 Then Log1 = dvLamiere(iLamiere)("Sp") <> dvILM(idvILM)("Sp") _
            Or dvLamiere(iLamiere)("Indmat") <> dvILM(idvILM)("Indmat")
            Log2 = j > 3
            If Log1 Or Log2 Or Log3 Then
                If dvLamiere(iLamiere)("Num") = 0 Then j = j - 1
                If j = 0 Then Exit Do
1180:           u = ShowForm(j, Ilam, Log2 And Not Log1)
                GraphLam = u
                If u = "C" Then Exit Function
                j = 0
                If Log3 Or Log1 Then Exit Do
            End If
            j = j + 1
            Ilam = Ilam + 1
        Loop
        LungILMMoveFirst(0)
    End Function
    Function ShowForm(ByRef Nlam As Short, ByRef Ilam As Short, ByRef Log1 As Boolean) As String
        Dim i, j As Short
        Dim k As Short
        Dim CarWidth As Single
        Dim Quadro1 As New Grafica.clsLamQuadr
        Dim IndiciQ As DataTable
        Routines.DoveDisegno = frmForm.DefInstance.pctForm
        RectInizia(Nlam)
        DispoFor(Nlam, xSmin, xSmax, ySmin, ySmax, 1)
        Routines.Scala(xSmin, xSmax, ySmin - (ySmax - ySmin) / 20, ySmax, 2)
        For j = 1 To Nlam
            For i = 0 To 5
                x = Rect(j).x(1) + i * (Rect(j).x(3) - Rect(j).x(1)) / 5
                Routines.tratto(x, ySmin, x, ySmax, 2, 0)
                Num = Trim(Str(i * (Rect(j).x(3) - Rect(j).x(1)) / 5))
                CarWidth = Routines.DoveDisegnog.MeasureString(Num, frmForm.DefInstance.myfont).Width
                Routines.texts(x - CarWidth / 2, ySmin, Num, 0, 0, 0)
            Next
        Next
        For i = 0 To 20
            y = ySmin + i * (ySmax - ySmin) / 20
            Routines.tratto(xSmin, y, xSmax, y, 2, 0)
            Routines.texts(x, y, Str(i * (ySmax - ySmin) / 20), 0, 0, 0)
            'LOCATE Int(y! / pymax * 60), 1: Print i * (ySmax! - ySmin!) / 20
        Next
        iLamiere = 0
        For i = 1 To Nlam
            Margin = g.MargTag(dvLamiere(iLamiere)("Sp"))
            dvIUNQ.RowFilter = "IndiceL=" & Str(dvLamiere(iLamiere)("IDlam"))
            If dvIUNQ.Count = 0 Then Exit Function
            idvIUNQ = 0
            Quadro.Apri(GrezziMDB, dvLamiere(iLamiere)("IDlam"))
            For j = 1 To dvLamiere(iLamiere)("Num")
                IndiciQ = New DataTable
                Dim cmd As OleDbDataAdapter = New OleDbDataAdapter( _
                "SELECT * FROM IndiciQ WHERE IndGrezzi=" & Str(dvIUNQ(idvIUNQ)("iD")), _
                GrezziMDB)
                cmd.Fill(IndiciQ)
                Dim dvIndiciQ = New DataView(IndiciQ)
                If dvIndiciQ.Count = 0 Then
                    Quadro.leggi(dvIUNQ(idvIUNQ)("IndiceQ")) ''Lamiere!Iniz + j
                    Disegna()
                Else
                    Dim jj As Short
                    For jj = 0 To dvIndiciQ.count - 1
                        ListaDupl = New DataTable
                        Dim cmd1 As OleDbDataAdapter = New OleDbDataAdapter( _
                           "SELECT * FROM ListaDuplicati WHERE IDCampo=" & _
                           Str(dvIndiciQ(jj)("IndGrezzi")), GrezziMDB)
                        cmd.Fill(ListaDupl)
                        If ListaDupl.Rows.Count = 0 Then
                            '       LeggiRecord()
                        Else
                            '        LeggiRecordD()
                        End If
                        Quadro.leggi(dvIndiciQ(jj)("IndiceQ")) ''Lamiere!Iniz + j
                        Disegna()
                        jj = jj + 1
                    Next jj
                    jj = jj - 1
                End If
            Next j
            Rect(i).RettGraf(Routines, 5)
            iLamiere += 1
        Next i
        If ifl Then FileClose(ifl)
        Do
            '  LOCATE 60, 20, 1
            If Log1 Then
                MsgBox("Seguono altre lamiere.... <Enter>     ")
                u = "A"
            Else
                'If MsgBox("Accetti (Si) o vuoi cambiare i formati (No)?", vbQuestion + vbYesNo) = vbYes Then u = "A" Else u = "C"
                u = "A"
            End If
            '   u$ = UCASE$(INPUT$(1))
            If u = "A" Or u = "C" Then Exit Do
            '  Beep
        Loop
        'LOCATE , , 0
        Mode = 0 : If Ilam > 4 Then Mode = 1
        If u = "A" Then
            '1926 ShowFormS NLam, Mode
        Else
            '   Screen 0
            '   Display
        End If
        'ShowFormS 0, 0
        ShowForm = u
        Exit Function
    End Function
    Private Sub Disegna()
Disegna:
        Quadro.Copia(Quadro1)
        Quadro1.TopLeft.X = Quadro1.TopLeft.X + Rect(i).x(1)
        Quadro1.Botrigt.X = Quadro1.Botrigt.X + Rect(i).x(1)
        Select Case dvIUNQ(idvIUNQ)("Codice")
            Case "RE  " : Quadro1.DrawRE(Margin, 0, 1, 0)
            Case "DI  " 'disco
                NSPI = dvIUNQ(idvIUNQ)("Variab5")
                ' Tipo = grezzi!Dim4
                If NSPI = 0 Then 'disco intero
                    SubRect = New RoutBase1.Rettangolo
                    Quadro1.MakeRectQuadro(SubRect, Margin, dvLamiere(iLamiere)("LARG"))
                    CentX = (SubRect.x(1) + SubRect.x(3) + dvLamiere(iLamiere)("LARG")) / 2
                    CentY = (SubRect.y(1) + SubRect.y(3)) / 2
                    Re = (dvIUNQ(idvIUNQ)("Dim1") - Margin) / 2 ' * Scal! / 2
                    Routines.cerc(CentX, CentY, Re)
                ElseIf NSPI = 2 Then  'da solo
                    Tipo = 0
                    Spic.clsForLam(dvIUNQ(idvIUNQ)("Dim1"), 0, System.Math.PI, Margin, 1, job.Comm.LargM, job.Comm.LungM, NRISP, Spic.SP(1), Tipo)
                    Spic.clsDisegnSP(Quadro1, 0, 1, Margin, 0, j0, Spic.SP(1))
                Else 'affiancati
                    Tipo = NSPI
                    Spic.clsForLam(dvIUNQ(idvIUNQ)("Dim1"), 0, System.Math.PI, Margin, 2, job.Comm.LargM, job.Comm.LungM, NRISP, Spic.SP(Tipo + 1), Tipo)
                    Spic.clsDisegnSP(Quadro1, 0, 1, Margin, i, 0, Spic.SP(Tipo + 1))
                End If
            Case "AN  " 'anello
                SubRect = New RoutBase1.Rettangolo
                Quadro1.MakeRectQuadro(SubRect, Margin, Int(CDbl(dvLamiere(iLamiere)("LARG"))))
                CentX = (SubRect.x(1) + SubRect.x(3) + dvLamiere(iLamiere)("LARG")) / 2
                CentY = (SubRect.y(1) + SubRect.y(3)) / 2
                Re = (dvIUNQ(idvIUNQ)("Dim1") - Margin) / 2 ' * Scal! / 2
                Ri = dvIUNQ(idvIUNQ)("Dim4") / 2 ' * Scal! / 2
                Routines.cerc(CentX, CentY, Re)
                Routines.cerc(CentX, CentY, Ri)
            Case "SS  " 'diaframmi SS
                SubRect = New RoutBase1.Rettangolo
                Quadro1.MakeRectQuadro(SubRect, Margin, dvLamiere(iLamiere)("LARG"))
                d = dvIUNQ(idvIUNQ)("Dim2") - Margin
                x = dvIUNQ(idvIUNQ)("Dim1") - d / 2 - Margin
                '              d! = d! * Scal!: x! = x! * Scal!
                CentX = (SubRect.x(1) + SubRect.x(3) + dvLamiere(iLamiere)("LARG")) / 2 + d / 4 - x / 2
                CentY = (SubRect.y(1) + SubRect.y(3)) / 2
                Ang1 = System.Math.Acos(x / d * 2)
                Ang2 = 2 * System.Math.PI - Ang1
                y = d / 2 * System.Math.Sin(Ang1)
                If Ang1 = 0 Then
                    Routines.cerc(CentX, CentY, d / 2)
                Else
                    Routines.Cerchio(CentX, CentY, d / 2, Ang1, Ang2, Sp)
                    Routines.tratto(CentX + x, CentY - y, CentX + x, CentY + y, Sp, Tipo)
                End If
            Case "DSA " 'diaframmi DS tipo A
            Case "DSB " 'diaframmi DS tipo B
            Case "OID " 'sviluppo conoidi
                SubRect = New RoutBase1.Rettangolo
                Quadro1.MakeRectQuadro(SubRect, Margin, dvLamiere(iLamiere)("LARG"))
                cono = New Grafica.Cono
                cono.Calcoli()
                For k = 1 To 4
                    SubRect.x(k) = SubRect.x(k) + dvLamiere(iLamiere)("LARG") / 2
                Next
                cono.ShowOid(dvIUNQ(idvIUNQ)("Variab2"), SubRect)
            Case "POLI" 'sviluppo conoidi
                SubRect = New RoutBase1.Rettangolo
                Quadro1.MakeRectQuadro(SubRect, Margin, dvLamiere(iLamiere)("LARG"))
                Polig = New Grafica.clsPolig
                For k = 1 To 4
                    SubRect.x(k) = SubRect.x(k) + dvLamiere(iLamiere)("LARG") / 2
                Next
                Polig.ShowOid(SubRect)
                SubRect.RettGraf((Funzioni.DisRut), 0)
            Case "SP  " 'spicchi
                NSPI = dvIUNQ(idvIUNQ)("Variab5")
                Tipo = dvIUNQ(idvIUNQ)("Variab4")
                If Tipo = 0 Then
                    Spic.clsForLam(dvIUNQ(idvIUNQ)("Variab2"), dvIUNQ(idvIUNQ)("Variab3"), dvIUNQ(idvIUNQ)("Dim4"), Margin, 1, job.Comm.LargM, job.Comm.LungM, NRISP, Spic.SP(1), 2)
                Else
                    Spic.clsForLam(dvIUNQ(idvIUNQ)("Variab2"), dvIUNQ(idvIUNQ)("Variab3"), dvIUNQ(idvIUNQ)("Dim4"), Margin, (NSPI), job.Comm.LargM, job.Comm.LungM, NRISP, Spic.SP(Tipo + 1), Int(Tipo))
                End If
                Spic.clsDisegnSP(Quadro1, 0, 1, Margin, 0, j0, Spic.SP(Tipo + 1))
            Case Else
        End Select
    End Sub
    Sub DispoFor(ByRef n As Short, ByRef xmin As Single, ByRef xmax As Single, ByRef ymin As Single, ByRef ymax As Single, ByRef Mode As Short)
        Dim offx As Single ', Lam As datatable
        Dim j, i, k As Short
        offx = Rect.Item(1).LARG / 2
        ymax = Rect.Item(1).y(3)
        For i = 2 To n
            offx = offx + 250 + Rect(i).LARG / 2
            For j = 1 To 4
                Rect(i).x(j) += offx
            Next j
            offx = offx + Rect(i).LARG / 2
            If Rect(i).y(3) > ymax Then ymax = Rect(i).y(3)
        Next i
        xmin = Rect(1).x(1)
        xmax = Rect(n).x(3)
        ymin = Rect(1).y(1)
    End Sub
    Sub AcqForm()
        Dim idim, Nfield As Short
        Dim Mat As LibMat.MaterialeNew1
        Dim i As Short
        Dim Text, Tit, Help As String
        Dim OK As Boolean
        Dim k, j As Short
        idim = UBound(ImpLarg)
        Dim Stringa1(idim) As String
        Dim Risult(idim) As String
        Dim Archiv(idim) As Short
        Dim dAiu(idim) As String
        Nfield = idim
        'DIM Stringa1$(1 TO Nfield), Risult$(Nfield), LungStr(Nfield) AS INTEGER
        Mat = New LibMat.MaterialeNew1
        Mat.Indmat = dvIUNQ(idvIUNQ)("Indmat")
        Mat.RecupMat("")
        Tit = Left(Mat.MatStr, 10) & " sp." & Str(dvIUNQ(idvIUNQ)("Variab1"))
        For i = 1 To idim
            If ImpLung(i) <= 0 Or ImpLarg(i) <= 0 Then
                ImpLung(i) = job.Comm.LungM 'Lav(0).LungM
                ImpLarg(i) = job.Comm.LargM 'Lav(0).LargM
            End If
        Next i
Rif:
        For i = 1 To idim
            Stringa1(i) = "Lam.N°" & Str(i) & ": Lar.[mm] x Lun.[mm]=" ' at1(26) '": Lar.mm x Lun.mm="
            Risult(i) = GlobalRoutines.myStr(CSng(ImpLarg(i)), 6, 0, True) & " x " & GlobalRoutines.myStr(CSng(ImpLung(i)), 6, 0, True)
        Next
        Text = " La sintassi corretta e' la seguente:" & vbCrLf
        Text = Text & "Largh.[mm] x Lung.[mm]"
        If Not Monitor.Motore.InputDati(Nfield, Tit, Stringa1, Risult, Help, Archiv, dAiu) Then Exit Sub
        For i = 1 To Nfield
            a = Risult(i)
            Retriev()
            If Not OK Then GoTo Rif
        Next
    End Sub
    Private Sub Retriev()
        Dim j As Short
        OK = True
        k = 1
        a1 = "" : a2 = ""
        For j = k + 1 To Len(a) - 2
            If LCase(Mid(a, j, 3)) = " x " Then
                a1 = Mid(a, 1, j - 1)
                k = j + 3
                If k < Len(a) Then
                    a2 = Mid(a, k, Len(a) - k + 1)
                Else
                    OK = False
                    Exit Sub
                End If
            End If
        Next j
        If Len(a1) = 0 Then
            OK = False
            Exit Sub
        End If
        ImpLarg(i) = Val(a1)
        ImpLung(i) = Val(a2)
    End Sub
    Public Sub RectInizia(ByRef Nlam As Short)
        Dim Rectang As RoutBase1.Rettangolo
        Dim i As Short
        While Rect.Count() > 0
            Rect.Remove(1)
        End While
        For i = 1 To Nlam
            Rectang = New RoutBase1.Rettangolo
            Rectang.MakeCorners((ImpLung(i)), (ImpLarg(i)))
            Rect.Add(Rectang)
        Next i
    End Sub

    Public Sub LungILMMoveFirst(ByRef Mode As Short)
        Dim Log As Boolean
        If Mode = 1 Then
            iLamiere = 0
            Exit Sub
        End If
        Do While dvLamiere(iLamiere)("Sp") = Sp And dvLamiere(iLamiere)("Indmat") = Indmat
            Log = True
            iLamiere -= 1
            If iLamiere = 0 Then Exit Do
        Loop
        If Log Then
            iLamiere += 1
        End If
    End Sub
    Public Sub AssegnaLamiera()
        dvIUNQ(idvIUNQ).BeginEdit()
        dvIUNQ(idvIUNQ)("IndiceL") = dvILM(idvILM)("iD") 'Ind
        dvIUNQ(idvIUNQ).EndEdit()
    End Sub
    Public Sub Riordina()
        Dim Mode As Short
        If PrimaLungDopoLarg Then Mode = 2 Else Mode = 1
        If Mode = 1 Then
            dvIUNQ.Sort = "Grezzi.IndMat,Grezzi.Variab1,Grezzi.Dim1 DESC,Grezzi.Dim2 DESC"
        Else
            dvIUNQ.Sort = "Grezzi.IndMat,Grezzi.Variab1,Grezzi.Dim2 DESC,Grezzi.Dim1 DESC"
        End If
    End Sub
    Public Sub Prelimin()
        Dim Tipi As DataTable
        Dim SQL As String
        FileGre = Funzioni.FileDes("GRE")
        Dim cString As String = Conn & FileGre & ConnFine
        GrezziMDB = New OleDbConnection(cString)
        Dim cmd As OleDbDataAdapter = New OleDbDataAdapter("SELECT * FROM Codici WHERE Tipo=1", GrezziMDB)
        SQL = "SELECT * FROM Grezzi WHERE "
        Dim dvTipi As DataView = New DataView(Tipi)
        For i = 0 To dvTipi.Count - 1
            SQL = SQL & "Codice='" + dvTipi(i)("Codice") + "' OR "
        Next
        SQL = Left(SQL, Len(SQL) - 4)
        IUNQ = New DataTable
        cmdIUNQ = New OleDbDataAdapter(SQL, GrezziMDB)
        cmdIUNQ.Fill(IUNQ)
        dvIUNQ = New DataView(IUNQ)
        CBIUNQ = New OleDbCommandBuilder(cmdIUNQ)
        Call DrizzRett()
        Call SezVir()
    End Sub
    Public Sub RiempiLista()
        Dim Mat As LibMat.MaterialeNew1
        Dim Indmat As Short
        Mat = New LibMat.MaterialeNew1
        idvIUNQ = 0
        Do Until idvIUNQ < dvIUNQ.Count
            If dvIUNQ(idvIUNQ)("Indmat") <> Indmat Then
                Indmat = dvIUNQ(idvIUNQ)("Indmat")
                Mat.Indmat = Indmat
                Mat.RecupMat(Monitor.Motore.Inizio.Archdir)
                Dim l As System.Windows.Forms.ListViewItem = frmForm.DefInstance.ListViewMat.Items.Add(Mat.MatStr) ', "A" & Trim(Str(Indmat)), Mat.MatStr)
                l.Tag = "A" & Indmat.ToString
            End If
            idvIUNQ += 1
        Loop
        LungILM = New DataTable
        cmdILM = New OleDbDataAdapter("SELECT * FROM Lamiere", GrezziMDB)
        cmdILM.Fill(LungILM)
        dvILM = New DataView(LungILM)
        CBILM = New OleDbCommandBuilder(cmdILM)
    End Sub
    Public Function Helpstringa(ByVal id As Integer) As String
        Dim Outstr As String
        Dim Nome As String = "str" + id.ToString.Trim
        Outstr = rmHelpStrings.GetString(Nome)
        If Outstr Is Nothing Then Return (Nome)
        If Outstr.IndexOf("$"c) = 0 Then Return Outstr.Substring(1)
        Return Outstr.Replace("|", vbCrLf)
    End Function
    Public Sub PreparaLamiere()
        Dim listmat As System.Windows.Forms.ListViewItem
        Dim ce As Boolean
        Dim ce1 As Boolean
        Dim listspess As System.Windows.Forms.ListViewItem
        Dim SQL, SQL1 As String
        Dim Indmat As Short
        Dim c As Control
        ce1 = False
        SQL = "SELECT * FROM Lamiere WHERE "
        For Each listmat In frmForm.DefInstance.ListViewMat.Items
            If listmat.Checked Then
                Indmat = Val(Right(listmat.Tag, Len(listmat.Tag) - 1))
                SQL1 = "(Indmat=" & Str(Indmat) & " AND ("
                ce = False
                For Each c In frmForm.DefInstance.Controls
                    If c.Name = "ListViewSpess" + "_" + listmat.Index.ToString Then
                        For Each listspess In CType(c, ListView).Items
                            If listspess.Checked Then
                                SQL1 = SQL1 & "Sp=" & Right(listspess.Text, Len(listspess.Text) - 8) & " OR "
                                ce = True
                            End If
                        Next listspess
                        Exit For
                    End If
                Next
                SQL1 = Left(SQL1, Len(SQL1) - 4) & ")) OR "
                If ce Then
                    SQL = SQL & SQL1
                    ce1 = True
                End If
            End If
        Next listmat
        If ce1 Then
            SQL = Left(SQL, Len(SQL) - 4)
            LungILM = New DataTable
            cmdILM = New OleDbDataAdapter(SQL, GrezziMDB)
            cmdILM.Fill(LungILM)
            dvILM = New DataView(LungILM)
            CBILM = New OleDbCommandBuilder(cmdILM)
            For i = 0 To dvILM.Count - 1
                Quadro.Delete(GrezziMDB, dvILM(0)("iD"))
                dvILM.Delete(0)
            Next
            cmdILM.Update(LungILM)
        End If
        LungILM = New DataTable
        cmdILM = New OleDbDataAdapter("SELECT * FROM Lamiere", GrezziMDB)
        cmdILM.Fill(LungILM)
        dvILM = New DataView(LungILM)
        CBILM = New OleDbCommandBuilder(cmdILM)
    End Sub
    Public Sub DisegnaLamiere()
        Dim u As String
        Dim iFound As Short = dvILM.Find("Indmat=" & Str(IndMatClick) & " AND Sp=" & Str(SpClick))
        If iFound = -1 Then
            Routines.DoveDisegnog.Clear(Color.White)
            frmForm.DefInstance.Text = "Lamieramento: assente"
            Exit Sub
        End If
        u = GraphLam()
    End Sub
    Public Function MostraAiuto(ByRef iD As Integer, Optional ByRef Informa As RoutBase1.ChiaviMess = RoutBase1.ChiaviMess.MessCritical + RoutBase1.ChiaviMess.MessOkOnly, _
    Optional ByRef mioTesto As String = "", Optional ByRef mioTitolo As String = "", Optional ByVal Proportional As Boolean = False) As RoutBase1.ChiaviMess
        Dim Testo, Tit As String
        Try
            If iD > 0 Then
                If Len(mioTesto) = 0 Then
                    Testo = Helpstringa(iD) ' "Il gruppo di items da montare su ventilatore a comune non è stato definito correttamente"
                Else
                    Testo = Monitor.Motore.Inizio.ConvertiCr(mioTesto)
                End If
                Tit = "IST - Messaggi di errore"
                If Len(mioTitolo) = 0 Then
                    Tit = "IST - Messaggi di errore"
                    If Not Informa And RoutBase1.ChiaviMess.MessCritical Then Tit = "AsmeVip"
                Else
                    Tit = mioTitolo
                End If
                Dim Topic As String = Monitor.HelpTopic(iD)
                If Topic = "" Then
                    MostraAiuto = Monitor.Motore.Messaggio(Testo, Informa, Tit, RadiceHelp, Topic, Proportional:=Proportional)
                Else
                    MostraAiuto = Monitor.Motore.Messaggio(Testo, Informa Or RoutBase1.ChiaviMess.MessHelpButton, Tit, RadiceHelp, Topic, Proportional:=Proportional)
                End If
            Else
                MsgBox("Errore sconosciuto", MsgBoxStyle.Information, "IST")
            End If
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Function
    Public Function CheckDoc() As Boolean
        FileSt = Funzioni.FileDes("GRZ.DOC")
        If Len(Dir(FileSt)) > 0 Then
            If Stub Is Nothing Then
                CheckDoc = True
            Else
                Try
                    CheckDoc = Not Stub.sFullName = FileSt
                Catch
                End Try
            End If
        End If
    End Function
    Public Sub ScriviPref()
        Dim SiNo As String
        With Monitor.Motore.Inizio
            If Verboso Then SiNo = "Si" Else SiNo = "No"
            .WriteIniFile("", SezPref, "Verboso", SiNo)
        End With
    End Sub
    Public Sub LeggiPrefGen()
        Try
            With Monitor.Motore.Inizio
                Verboso = (.ReadIniFile("", SezPref, "Verboso") = "Si")
            End With
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Public Property ModifProto() As Boolean
        Get
            ModifProto = varModifProto
        End Get
        Set(ByVal Value As Boolean)
            Try
                If Not mioApert Is Nothing Then
                    With mioApert
                        If varModifProto <> Value And Not .ListDisp.Tag = "A" Then
                            If Value Then
                                .Label13.BackColor = System.Drawing.Color.Yellow
                                .mnuFile.Enabled = False
                                .mnuDataSheet.Enabled = False
                                .mnuDistinta.Enabled = False
                                .mnuCalcoli.Enabled = False
                                .mnuFormati.Enabled = False
                                .mnuGrezzi.Enabled = False
                            Else
                                .Label13.BackColor = System.Drawing.ColorTranslator.FromOle(.Color13)
                                .mnuFile.Enabled = True
                                .mnuDataSheet.Enabled = True
                                .mnuDistinta.Enabled = True
                                .mnuCalcoli.Enabled = True
                                .mnuFormati.Enabled = True
                                .mnuGrezzi.Enabled = True
                            End If
                            varModifProto = Value
                        End If
                    End With
                Else
                    varModifProto = Value
                End If
            Catch e As Exception
                MsgBox(e.Message + vbCrLf + e.StackTrace)
            End Try
        End Set
    End Property
End Module