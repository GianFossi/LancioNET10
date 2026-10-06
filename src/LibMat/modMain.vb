Option Strict On
Option Explicit On 
Imports Microsoft.VisualBasic
Imports System.Text
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.common
Imports RoutBase1.clsInizio
Public Enum Codes
    '1 ASME psi 2 ASME MPA 3 VSR 4 BS psi 5 BS MPA 6 div.2 psi 7 Stomweezen 8 EU
    NonDef = 0
    div1psi = 1
    div1MPa = 2
    VSR = 3
    BSpsi = 4
    BSMPa = 5
    div2psi = 6
    Stoomwezen = 7
    EU = 8
    div2MPa = 9
End Enum
Public Enum TipoRivestimento
    Nessuno = 0
    Placcato = 1
    WO = 2
    Lining = 3
    biPlaccato = 4
    biWO = 5
    biLining = 6
End Enum
Public Enum ClasseMateriale
    NonDef = 0
    LamiereCS = 1
    LamiereSS = 2
    Tondi = 3
    TubiScambio = 4
    Distanziali = 5
    TubiPiping = 6
    Fucinati = 7
    Bulloneria = 8
    Riporti = 9
    Varie = 10
    FormaturaFondiEllittici = 11
    FormaturaFondiEmisferici = 12
    Calandratura = 13
End Enum
Module modMain
    Friend Funzioni As New RoutBase1.clsTrigon
    Friend FormGuarn As frmGuarn
    Public RadiceHelp As String
    Public myAssembly As System.Reflection.Assembly
    Public rmHelpStrings As Resources.ResourceManager
    '=========================================================
    Public Const Conn As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source="
    Public Const ConnFine As String = ";Persist Security Info=False"
    Public Const ConnFineExcel As String = ";Extended Properties=excel 8.0;Persist Security Info=False"
    'Provider=Microsoft.Jet.OLEDB.4.0;Data Source=E:\programmi\lancio\arch\mat200102.mdb;Persist Security Info=False
    '-----vedi C:\Documenti\EuroNorm\header.h----
    Public Const EU_CHM_MATGROUP As Short = 25001
    Public Const EU_CHM_MATCATEGORY As Short = 25002
    Public iFieldCaract() As Integer = {0, 13, 14, 15, 16, 51, 52, 53, 54, 55, 56, 57, 58}
    Public Const NumSerieValori As Integer = 6
    Public Const NumMaxCaract As Integer = 12
    '================================================
    Friend Structure piping
        Public DN As String
        Public Diam As String
        Dim Sch() As String
        Dim Spess() As String
        Public Sub initialize()
            ReDim Sch(20), Spess(20)
        End Sub
    End Structure '16+60+100=176
    Public Archdir As String
    Public DiscoTem As String
    '---------------
    Public iprezzi As Integer
    Public Monitor As clsMonitor
    Public InterrompiWinWord As Boolean
    Public Filexls As String
    Public FormMat As New LinkListclsMat
    Public dbsTemp As DataSet
    Public rstLinked As DataTable
    Public MatASME As OleDbConnection
    Public MatBase As OleDbConnection
    Public connPrezzi As OleDbConnection
    Public NumParam, NumParamSc As Short
    Public Param(50) As String
    Public Paramv(50) As Single
    Public Codici(50) As Short
    Public iflm, ifli As Short
    Friend iflp(50) As DataView
    Friend iflpt(50) As DataTable
    Friend iflpd(50) As DataRowView
    Friend Scheda As frmScheda
    Public tbClassi As New DataTable
    Public tableparam As New DataTable
    Public dvtableparam As DataView
    Public TableParamSc As New DataTable
    Public Tirante As clsTira
    Public FormTirante As frmTira
    Public Tubo As clsPipe
    Public Guarniz As clsGuarn
    Public MyFile As String = ""
    Public InsertMode As Short
    Public Nc As Short
    Public Stub As StubW2000.clsSW2000
    Public Stub9 As StubW9.clsSW9
    Public FileStam As String
    Public Flange, Elbows As Boolean
    Public FileAsme, FileMate As String
    Public dsPrezzi As DataSet
    Public prezzi As DataTable
    Public dvprezzi As DataView
    Public cmdprezzi As OleDbDataAdapter
    Public tableprezzi As String
    Public FormPrezzi As frmprz
    Public Metrico As Boolean
    Private Count As Integer
    Private jCount As Integer
    Public Function PhysAlt(ByVal Temp As Single, ByRef ic As Short, ByRef Table As DataTable, ByRef RigaValori As DataRowView, ByVal m As MaterialeNew1) As Single
        Dim Temper(100) As Single
        Dim Valor(100) As Single
        Dim i As Short
        Dim l, k, kmax As Short
        Dim l1, k1, l2 As Short
        Dim testo As String
        If ic <= 0 And m.Agganciato Then PhysAlt = 0 : Exit Function
        kmax = CShort(Table.Columns.Count - 3)
        Temp = CSng(1.8 * Temp + 32)
        For i = 2 To CShort(Table.Columns.Count - 1)
            If Not IsDBNull(Table.Rows(0)(i)) Then
                Temper(i - 2) = CSng(Table.Rows(0)(i))
            Else
                Temper(i - 2) = 0
            End If
        Next
        RigaValori = Nothing
        Dim dvT As DataView = New DataView(Table)
        Dim iFound As Integer
        If m.Agganciato Then
            dvT.Sort = "ID"
            iFound = dvT.Find(ic)
            If iFound = -1 Then GoTo Fine
        Else
            iFound = 1
        End If
        RigaValori = dvT(iFound)
        If m.Agganciato Then
            If IsDBNull(RigaValori("Nome")) Then GoTo Fine
        End If
        For i = 2 To CShort(Table.Columns.Count - 1)
            If Not IsDBNull(RigaValori(i)) Then Valor(i - 2) = CSng(RigaValori(i)) Else Valor(i - 2) = 0
        Next
        k = CShort(Table.Columns.Count - 3)
        For l = k To 1 Step -1
12:         If Valor(l) > 0 Then Exit For
        Next
        k = l
        If k = 0 And Valor(k) = 0 Then PhysAlt = 0 : Exit Function
        For l = 0 To k
            If Valor(l) > 0 Then Exit For
        Next
        k1 = l
        If Temp > Temper(k) Then
            l = k
        Else
            For l = k1 To k
14:             If Temper(l) > Temp Then Exit For
            Next
        End If
        If l = k1 Then l = CShort(l + 1)
        l1 = CShort(l - 1) : l2 = l
        Do While Valor(l1) = 0
16:         l1 = CShort(l1 - 1)
            If l1 < 0 Then PhysAlt = 0 : Exit Function
        Loop
        Do While Valor(l2) = 0
18:         l2 = CShort(l2 + 1)
            If l2 = kmax Then PhysAlt = Valor(l1) : Exit Function
        Loop
        If Valor(l1) = Valor(l2) Then
            PhysAlt = Valor(l1)
        Else
            PhysAlt = Valor(l1) + (Temp - Temper(l1)) / (Temper(l2) - Temper(l1)) * (Valor(l2) - Valor(l1))
        End If
        Exit Function
Fine:
        testo = "Tabella dei moduli elastici e/o" & vbCrLf
        testo = testo & "dei coefficienti di dilatazione" & vbCrLf
        testo = testo & "termica non definite per il materiale" & vbCrLf & m.MatStr
        MsgBox(testo, CType(MsgBoxStyle.OKOnly + MsgBoxStyle.Critical, MsgBoxStyle))
    End Function
    Public Sub SetInsert(ByRef t As System.Windows.Forms.Control)
        Stop
        If InsertMode <> 0 Then
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto t.SelLength. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            '        t.SelLength = Len(t.Text)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto t.SelStart. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            '       t.SelStart = 0
        Else
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto t.SelLength. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            '      t.SelLength = 0
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto t.SelStart. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            '     t.SelStart = 0
        End If
    End Sub

    Public Sub TrattaCar(ByRef Index As Short, ByRef KeyAscii As Short, ByRef t As System.Windows.Forms.Control, ByRef Text1() As System.Windows.Forms.Control, ByRef Nc As Short)
        Dim i As Short
        Select Case CType(KeyAscii, System.Windows.Forms.Keys)
            Case System.Windows.Forms.Keys.Return, System.Windows.Forms.Keys.Down
                KeyAscii = CShort(System.Windows.Forms.Keys.Down)
                i = 1
                System.Windows.Forms.Application.DoEvents()
                Do
                    If Index + i <= Nc Then
                        If Text1(Index + i).Enabled Then
                            Text1(Index + i).Focus()
                            Exit Do
                        Else
                            i = CShort(i + 1)
                        End If
                    Else
                        Text1(0).Focus()
                        Exit Do
                    End If
                Loop
            Case System.Windows.Forms.Keys.Insert
                InsertMode = Not InsertMode
                Call SetInsert(t)
            Case System.Windows.Forms.Keys.Up
                i = 1
                Do
                    If Index - i >= 0 Then
                        If Text1(Index - i).Enabled Then
                            Text1(Index - i).Focus()
                            Exit Do
                        Else
                            i = CShort(i + 1)
                        End If
                    Else
                        Text1(Nc).Focus()
                        Exit Do
                    End If
                Loop
        End Select
        Exit Sub
    End Sub
    Public Sub SubClassi(ByRef Classe As ClasseMateriale, Optional ByRef Code As Short = 0)
        Dim i As Short
        ' Dim Righe() As DataRowView
        If Classe = ClasseMateriale.NonDef Then Exit Sub
        If Not IniziaBase() Then Exit Sub
        Apriparametri(Classe)
        ' NumParam = CShort(tbClassi.Rows(0)("NumClasPr"))
        Dim dvtp As DataView = New DataView(tableparam)
        Try
            If Classe = ClasseMateriale.Fucinati And Code > 0 Then
                '    dvtp.Sort = "Codice"
                '   Righe = dvtp.FindRows(Code.ToString)
                dvtp.RowFilter = "Codice=" + Code.ToString
                'NumParam = CShort(UBound(Righe) + 1)
            End If
            NumParam = CShort(dvtp.Count)
            For i = 1 To NumParam
                Param(i) = CType(dvtp(i - 1)("Etichetta"), String)
                Paramv(i) = CType(dvtp(i - 1)("Numero"), Single)
                If Classe = ClasseMateriale.Fucinati Then Codici(i) = CShort(dvtp(i - 1)("Codice"))
            Next
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Private Sub Apriparametri(ByVal Classe As ClasseMateriale)
        Dim Aperto As Boolean = (tbClassi.Rows.Count > 0)
        If Aperto Then Aperto = (CShort(tbClassi.Rows(0)("Codice")) = Classe)
        If Not Aperto Then
            tbClassi = New DataTable
            Dim cmd As OleDbDataAdapter = New OleDbDataAdapter("SELECT * FROM Classi WHERE Codice=" & Str(Classe), MatBase)
            cmd.Fill(tbClassi)
            tableparam = New DataTable
            Dim cmdp As OleDbDataAdapter = New OleDbDataAdapter("SELECT * FROM " & CType(tbClassi.Rows(0)("tabParametri"), String) & " ORDER BY Ordine", MatBase)
            cmdp.Fill(tableparam)
            dvtableparam = New DataView(tableparam)
            If IsDBNull(tbClassi.Rows(0)("NumClasSc")) Then
                NumParamSc = 0
            Else
                NumParamSc = CShort(tbClassi.Rows(0)("NumClasSc"))
            End If
            If NumParamSc > 0 Then
                TableParamSc = New DataTable
                Dim cmdSc As OleDbDataAdapter = New OleDbDataAdapter("SELECT * FROM " & CStr(tbClassi.Rows(0)("tabParametriSc")), MatBase)
                cmdSc.Fill(TableParamSc)
            End If
        End If
    End Sub
    Public Function SubClasse(ByRef Classe As ClasseMateriale, ByRef Parametro As Single, ByRef Code As Short, _
                              Optional ByRef inum As Short = 0, Optional ByRef Sotto As Single = -1, Optional ByRef Sopra As Single = -1) As Single
        Dim i As Short
        Call SubClassi(Classe, Code)
        Select Case Classe
            Case ClasseMateriale.LamiereCS, _
                 ClasseMateriale.LamiereSS, _
                 ClasseMateriale.Fucinati, _
                 ClasseMateriale.Bulloneria, _
                 ClasseMateriale.FormaturaFondiEllittici, _
                 ClasseMateriale.FormaturaFondiEmisferici, _
                 ClasseMateriale.Calandratura '1, 2, 7, 8, 11, 12, 13
                For i = 1 To NumParam
                    If Parametro < Paramv(i) Then
                        SubClasse = Paramv(i)
                        inum = i
                        Exit Function
                    End If
                Next i
                SubClasse = Paramv(NumParam)
                inum = NumParam
            Case ClasseMateriale.TubiScambio
                For i = 1 To NumParam
                    Call Limiti(Paramv, i, NumParam, Sotto, Sopra)
                    If Parametro < Sopra And Parametro > Sotto Then
                        SubClasse = Paramv(i)
                        inum = i
                        Exit Function
                    End If
                Next i
                '    Case 7
                '      SubClasse = Parametro
            Case Else
                SubClasse = 1
        End Select
    End Function
    Private Sub Limiti(ByVal Arr() As Single, ByVal i As Short, ByVal n As Short, ByRef Sotto As Single, ByRef Sopra As Single)
        Select Case i
            Case 1
                Sotto = 0
                Sopra = CSng(Math.Sqrt(Arr(i) * Arr(i + 1)))
            Case n
                Sotto = CSng(Math.Sqrt(Arr(n - 1) * Arr(n)))
                Sopra = RoutBase1.clsTrigon.Infinito
            Case Else
                Sotto = CSng(Math.Sqrt(Arr(i - 1) * Arr(i)))
                Sopra = CSng(Math.Sqrt(Arr(i) * Arr(i + 1)))
        End Select
    End Sub
    Public Function SubClasse2(ByRef Classe As ClasseMateriale, ByRef Parametro As Single, _
                              Optional ByRef inum As Short = 0, Optional ByRef Sotto As Single = -1, Optional ByRef Sopra As Single = -1) As Single
        If NumParamSc = 0 Then Exit Function
        With TableParamSc
            Dim i As Short, Arr(CShort(.Rows.Count)) As Single
            For i = 0 To CShort(.Rows.Count - 1)
                Arr(i + 1) = CSng(.Rows(i)("Numero"))
            Next
            For i = 0 To CShort(.Rows.Count - 1)
                Select Case Classe
                    Case ClasseMateriale.TubiScambio
                        Call Limiti(Arr, CShort(i + 1), CShort(.Rows.Count), Sotto, Sopra)
                        If Parametro < Sopra And Parametro > Sotto Then
                            SubClasse2 = CType(.Rows(i)("Numero"), Single)
                            inum = CShort(.Rows(i)("Ordine"))
                            Exit Function
                        End If
                    Case Else
                        If Parametro < CType(.Rows(i)("Numero"), Single) Then
                            SubClasse2 = CType(.Rows(i)("Numero"), Single)
                            inum = CShort(.Rows(i)("Ordine"))
                            Exit Function
                        End If
                End Select
            Next
            SubClasse2 = CType(.Rows(.Rows.Count - 1)("Numero"), Single)
            inum = CShort(.Rows(.Rows.Count - 1)("Ordine"))
        End With
    End Function
    Public Function Decodif(ByRef Riga As String, ByRef A() As String) As Boolean
        Dim l, i, n As Integer
        l = InStr(Riga, Chr(179))
        If l = 0 Then Decodif = False : Exit Function
        Riga = Right(Riga, Len(Riga) - l)
        n = UBound(A)
        If n = 6 Then
            l = InStr(Riga, Chr(179))
            If l = 0 Then Decodif = False : Exit Function
            Riga = Right(Riga, Len(Riga) - l)
        End If
        For i = 1 To n
            l = InStr(Riga, Chr(179))
            If l = 0 Then Decodif = False : Exit Function
            A(i) = Left(Riga, l - 1)
            Riga = Right(Riga, Len(Riga) - l)
        Next
        Decodif = True
    End Function
    Public Function OpenConn() As OleDbConnection
        If MyFile = "" Then MyFile = Monitor.Motore.MatFile
        Dim cString As String = Conn & MyFile & ConnFine
        Dim oc As OleDbConnection = New OleDbConnection(cString)
        Return oc
    End Function
    Public Function IniziaBase() As Boolean
        IniziaBase = True
        If Not MatBase Is Nothing Then Exit Function
        MyFile = Monitor.Motore.MatFile
        If Len(MyFile) = 0 Then
            IniziaBase = False
            MsgBox("Non è stata trovata la libreria materiali")
            Exit Function
        End If
        Try
            Dim cString As String = Conn & MyFile & ConnFine
            MatBase = New OleDbConnection(cString)
        Catch e As Exception
            MsgBox("File " & MyFile & "; errore:" & e.Message & vbCrLf & e.StackTrace)
            IniziaBase = False
        End Try
    End Function
    Public Sub PutMat(ByRef Bas As Short)
        Dim m As LibMat.MaterialeNew1
        With FormMat.Item(FormMat.Count()).TextData
            If .MatCompos Is Nothing Then
                m = .MatSolo
            Else
                m = .MatCompos.Mat(Bas)
            End If
        End With
        m.SaveMat()
    End Sub
    Public Sub TransferR(ByRef r As DataRowView, ByRef Bas As Short)
        Dim m As LibMat.MaterialeNew1
        Try
            With FormMat.Item(FormMat.Count()).TextData
                If .MatCompos Is Nothing Then
                    m = .MatSolo
                Else
                    m = .MatCompos.Mat(Bas)
                End If
            End With
            With m
                .MatStr = CStr(r("Mat"))
                If IsDBNull(r("AlloyUNS")) Then
                    .AlloyUNS = " "
                Else
                    .AlloyUNS = CStr(r("AlloyUNS"))
                End If
                If IsDBNull(r("Product")) Then
                    .Product = " "
                Else
                    .Product = CStr(r("Product"))
                End If
                If IsDBNull(r("Composiz")) Then
                    .Composiz = " "
                Else
                    .Composiz = CStr(r("Composiz"))
                End If
                If IsDBNull(r("NomeComm")) Then
                    .NomeComm = " "
                Else
                    .NomeComm = CStr(r("NomeComm"))
                End If
                If IsDBNull(r("Spec")) Then
                    .Spec = " "
                Else
                    .Spec = CStr(r("Spec"))
                End If
                If IsDBNull(r("TypeGrade")) Then
                    .Grado = " "
                Else
                    .Grado = CStr(r("TypeGrade"))
                End If
                If IsDBNull(r("ClassCondTemp")) Then
                    .ClassTemper = " "
                Else
                    .ClassTemper = CStr(r("ClassCondTemp"))
                End If
                If IsDBNull(r("SizeThk")) Then
                    .Dimensions = " "
                Else
                    .Dimensions = CStr(r("SizeThk"))
                End If
                .Indmat = CShort(r("Ind"))
                If IsDBNull(r("PSP")) Then
                    .PSP = 0
                Else
                    .PSP = CShort(r("PSP"))
                End If
                '.CAT = CStr(r("CAT"))
                '.CT = CStr(r("CT"))
                '.CMT = CStr(r("CMT"))
                .Classe = CType(r("Classe"), ClasseMateriale)
                If IsDBNull(r("ElasCod")) Then
                    .ElasCod = 0
                Else
                    .ElasCod = CShort(r("ElasCod"))
                End If
                If IsDBNull(r("alfacod")) Then
                    .alfacod = 0
                Else
                    .alfacod = CShort(r("alfacod"))
                End If
                If IsDBNull(r("ConducTer")) Then .ConducTer = 0 Else .ConducTer = CShort(r("ConducTer"))
                If IsDBNull(r("MatGroup")) Then .MatGroup = 0 Else .MatGroup = CShort(r("MatGroup"))
            End With
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Public Sub Transferc(ByRef c As DataRowView, ByRef Bas As Short, ByRef i As Short)
        Dim m As LibMat.MaterialeNew1
        m = MaterAct(Bas)
        Try
            If m.Caract.Item(i) Is Nothing Then m.Caract.Add(New CarattMatNew)
            With m.Caract.Item(i).TextData
                .Codice = CType(c("Codice"), Codes)
                .Source = ""
                Try
                    .Source = CStr(c("Source"))
                Catch
                End Try
                Try
                    .Yield = CSng(c("Yield"))
                    .Alfa = CSng(c("Alfa"))
                    .Young = CSng(c("Young"))
                    .US = CSng(c("US"))
                    .IndChart = CShort(c("IndChart"))
                    .IndNote = 0
                    .IndNote = CInt(c("IndNote"))
                Catch
                End Try
                .MWDTrule = ""
                Try
                    .MWDTrule = CStr(c("MWDTrule"))
                Catch
                End Try
                .MWDTclause = ""
                Try
                    .MWDTclause = CStr(c("MWDTclause"))
                Catch
                End Try
                .MWDTtemp = 0
                Try
                    .MWDTtemp = CSng(c("MWDTtemp"))
                Catch
                End Try
                .PNumber = ""
                Try
                    .PNumber = CStr(c("PNumber"))
                Catch
                End Try
                .Group = ""
                Try
                    .Group = CStr(c("GroupNb"))
                Catch
                End Try
            End With
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Public Sub TransferV(ByRef drvV As DataRowView, ByRef Bas As Short, ByRef i As Short, ByRef l As Short)
        Dim m As Short
        Dim VV As Single
        Dim mm As LibMat.MaterialeNew1
        mm = MaterAct(Bas)
        Try
            With mm.Caract.Item(i).TextData
                For m = 1 To 24
                    VV = CSng(drvV(m))
                    If VV = -1 Then VV = 0
                    Select Case l
                        Case 1
                            .Temp.Item(m).TextData = VV
                        Case 2
                            .Ammiss.Item(m).TextData = VV
                        Case 3
                            .TempY.Item(m).TextData = VV
                        Case 4
                            .AlfaT.Item(m).TextData = VV
                    End Select
                Next m
            End With
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Public Sub AnnullV(ByVal Bas As Short, ByVal i As Short, ByVal l As Short)
        Dim m As Short
        Dim mm As LibMat.MaterialeNew1
        mm = MaterAct(Bas)
        Try
            With mm.Caract.Item(i).TextData
                For m = 1 To 24
                    Select Case l
                        Case 1
                            .Temp.Item(m).TextData = 0
                        Case 2
                            .Ammiss.Item(m).TextData = 0
                        Case 3
                            .TempY.Item(m).TextData = 0
                        Case 4
                            .AlfaT.Item(m).TextData = 0
                    End Select
                Next m
            End With
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try

    End Sub
    Public Sub TransferMat(ByRef r As DataRowView, ByRef Bas As Short)
        Dim c As New DataTable
        Dim V As New DataTable
        Dim l, i As Short
        Dim iFoundc, iFoundV As Integer
        TransferR(r, Bas)
        Try
            Dim cmd As OleDbDataAdapter = New OleDbDataAdapter("SELECT * FROM Caract", MatBase)
            cmd.Fill(c)
            Dim dvc As DataView = New DataView(c)
            dvc.Sort = "ID"
            '     c.Index = "PrimaryKey"
            cmd = New OleDbDataAdapter("SELECT * FROM Valori", MatBase)
            cmd.Fill(V)
            Dim dvV As DataView = New DataView(V)
            dvV.Sort = "ID"
            '    V.Index = "PrimaryKey"
            For i = 1 To NumMaxCaract
                iFoundc = dvc.Find(r(iFieldCaract(i)))
                If iFoundc > -1 Then
                    Transferc(dvc(iFoundc), Bas, i)
                    For l = 1 To NumSerieValori
                        If IsDBNull(dvc(iFoundc)(13 + l)) Then
                            iFoundV = -1
                        Else
                            iFoundV = dvV.Find(dvc(iFoundc)(13 + l))
                        End If
                        If iFoundV > -1 Then
                            Dim drvV As DataRowView = dvV(iFoundV)
                            TransferV(drvV, Bas, i, l)
                        Else
                            AnnullV(Bas, i, l)
                        End If
                    Next l
                End If
            Next i
            dvc.Dispose()
            c.Dispose()
            dvV.Dispose()
            V.Dispose()
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Public Sub LegTabella(ByRef File As String, ByRef n As Short, ByRef TDes As Single, ByRef Pmax As Single)
        Dim i, j As Short
        Dim Temp As Single
        Dim Te0, Te1 As Single
        Dim Pr0, Pr1, pr As Single
        Dim Table As New DataTable
        Dim cmd As OleDbDataAdapter = New OleDbDataAdapter("SELECT * FROM " & File, MatBase)
        cmd.Fill(Table)
        Temp = 0
        For i = 1 To CShort(Table.Rows.Count - 1)
            Te0 = Temp
            Temp = CSng(Table.Rows(i)(1))
            If Temp > TDes Then GoTo 420
        Next
        MsgBox("La temperatura di progetto è superiore" & vbCrLf & "alla massima prevista dal Rating", MsgBoxStyle.Critical)
        Pmax = 0
        Exit Sub
420:    pr = CSng(Table.Rows(i)(n + 1))
        j = CShort(i - 1)
        If j > -1 Then
            Pr1 = pr : Te1 = Temp
            Te0 = CSng(Table.Rows(j)(1))
            Pr0 = CSng(Table.Rows(j)(n + 1))
            Pmax = (TDes - Te0) / (Te1 - Te0) * (Pr1 - Pr0) + Pr0
        Else
            Pmax = pr
        End If
        Table.Dispose()
    End Sub
    Public Function MatElem() As MaterialeNew1
        Dim Mat As clsMat
        If FormMat.Count() = 0 Then Return Nothing
        Mat = FormMat.Item(FormMat.Count()).TextData
        With Mat
            If .MatCompos Is Nothing Then
                MatElem = .MatSolo
            Else
                If .IndiceLista > 0 And .IndiceLista < 4 Then
                    MatElem = .MatCompos.Mat(.IndiceLista)
                Else
                    MsgBox("Selezionare un materiale", CType(MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, MsgBoxStyle))
                    MatElem = Nothing
                End If
            End If
        End With
    End Function
    Public Function ApriPrezzi() As Boolean
        Dim FileMdb As String
        Dim i As Integer
        Dim cmd As OleDbDataAdapter
        FileMdb = Monitor.Motore.Inizio.Archdir & "\PrezziLp.mdb"
        Filexls = Monitor.Motore.Inizio.Archdir & "\PrezziLp.xls"
        connPrezzi = New OleDbConnection(Conn & FileMdb & ConnFine)
        connPrezzi.Open()
        Dim schemaTable As DataTable = connPrezzi.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, _
                                             New Object() {Nothing, Nothing, Nothing, "TABLE"})
        '  dbsTemp = New DataSet
        For i = 0 To schemaTable.Rows.Count - 1
            cmd = New OleDbDataAdapter("SELECT * FROM" & CStr(schemaTable.Rows(i)(2)), connPrezzi)
            cmd.Fill(dbsTemp)
            dbsTemp.Tables(i).TableName = CStr(schemaTable.Rows(i)(2))
        Next
    End Function
    Public Sub AggiornaXLS(ByVal Prodotto As String)
        Dim oldCursor As System.Windows.Forms.Cursor = System.Windows.Forms.Cursor.Current
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        Try
            Using materiali As DataTable = Lancio.Data.Access.AccessDatabase.ReadDistinctMaterials(Conn & Filexls & ConnFineExcel, Prodotto)
                FormPrezzi.cmbMatExc.Items.Clear()
                For Each row As DataRow In materiali.Rows
                    FormPrezzi.cmbMatExc.Items.Add(row("MATERIAL"))
                Next
                FormPrezzi.cmbMatExc.Visible = True
                If FormPrezzi.cmbMatExc.Items.Count > 0 Then
                    FormPrezzi.cmbMatExc.SelectedIndex = 0
                End If
            End Using
        Finally
            System.Windows.Forms.Cursor.Current = oldCursor
        End Try
    End Sub
    Public Sub ParametriPrezzo(ByRef Classe As ClasseMateriale)
        ' Apriparametri(Classe)
        Call SubClassi(Classe)
    End Sub
    Public Function MaterAct(ByRef Bas As Short) As LibMat.MaterialeNew1
        With FormMat.Item(FormMat.Count()).TextData
            If .MatCompos Is Nothing Then
                MaterAct = .MatSolo
            Else
                MaterAct = .MatCompos.Mat(Bas)
            End If
        End With
    End Function
    Public Sub PreparaListino()
        Dim Mat As clsMat
        Mat = FormMat.Item(1).TextData
        If Mat.Classe = 0 Then
            MsgBox("No in PreparaListino")
            Exit Sub
        End If
        If Not IniziaBase() Then Exit Sub
        ParametriPrezzo(Mat.Classe)
    End Sub
    Public Sub StampaListino(ByRef Descr As String)
        Dim logo As String
        Dim Primo As Boolean
        Dim testo As String
        Dim Mat As clsMat = FormMat.Item(1).TextData
        Try
            If Monitor.Motore.Inizio.VersOffice < 11 Then
                Stub9 = New StubW9.clsSW9
                Stub9.SuperStampa(Monitor.Motore.Inizio.Archdir & "\PREZZI.DOC", Monitor.Motore.Inizio.VersOffice) ' Doc
                If Stub9 Is Nothing Then Exit Sub
                If FileStam = "" Then
                    FileStam = Monitor.Motore.Inizio.Archdir & "\LibPrez" & Trim(Str(Mat.Classe)) & ".DOC"
                End If
                Stub9.sSaveAs(FileStam)
                logo = Monitor.Motore.Inizio.Archdir & "\" & Monitor.Motore.Inizio.ReadIniFile("", "Azienda", "Logo")
                Stub9.IntestLogo(logo, 0.9)
                Stub9.ScriviBM("Sezione", Descr)
                Stub9.ScriviBM("Start", "")
                Primo = True
                Mat.frm.Hide()
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
                InterrompiWinWord = False
                Monitor.Motore.ProgrInizio(Monitor.Motore.HelpStringaG(IDHS.IDH_LISTINO_MSG), Monitor.Motore.HelpStringaG(IDHS.IDH_LISTINO_TIT))
                Fai9(Mat, Primo)
            Else
                Stub = New StubW2000.clsSW2000
                Stub.SuperStampa(Monitor.Motore.Inizio.Archdir & "\PREZZI.DOC", Monitor.Motore.Inizio.VersOffice) ' Doc
                If Stub Is Nothing Then Exit Sub
                If FileStam = "" Then
                    FileStam = Monitor.Motore.Inizio.Archdir & "\LibPrez" & Trim(Str(Mat.Classe)) & ".DOC"
                End If
                Stub.sSaveAs(FileStam)
                logo = Monitor.Motore.Inizio.Archdir & "\" & Monitor.Motore.Inizio.ReadIniFile("", "Azienda", "Logo")
                Stub.IntestLogo(logo, 0.9)
                Stub.ScriviBM("Sezione", Descr)
                Stub.ScriviBM("Start", "")
                Primo = True
                Mat.frm.Hide()
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
                InterrompiWinWord = False
                Monitor.Motore.ProgrInizio(Monitor.Motore.HelpStringaG(IDHS.IDH_LISTINO_MSG), Monitor.Motore.HelpStringaG(IDHS.IDH_LISTINO_TIT))
                Fai(Mat, Primo)
            End If
            Monitor.Motore.ProgrAmmazza()
        Catch e As Exception
            Select Case Err.Number
                Case 5153
                    testo = "Si è generato il seguente errore:" & vbCrLf
                    testo = testo & Err.Description & vbCrLf & vbCrLf
                    testo = testo & "E' probabile che sia necessario accedere a" & vbCrLf
                    testo = testo & "Winword per liberare il file e poi riprovare."
                    If MsgBox(testo, MsgBoxStyle.RetryCancel, "Errore da WinWord") = MsgBoxResult.Retry Then
                        StampaListino(Descr)
                    End If
                Case 5825
                    testo = "Si è generato il seguente errore:" & vbCrLf
                    testo = testo & Err.Description & vbCrLf & vbCrLf
                    testo = testo & "E' possibile che l'utente abbia interagito" & vbCrLf
                    testo = testo & "in modo improprio con WinWord." & vbCrLf
                    testo = testo & "La generazione del listino prezzi viene terminata."
                    MsgBox(testo, CType(MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, MsgBoxStyle))
                    Monitor.Motore.ProgrAmmazza()
                    Mat.frm.ShowDialog()
                Case Else
                    MsgBox(Err.Description & Str(Err.Number))
            End Select
        End Try
    End Sub
    Public Sub GenPrezzi(ByVal Cod As Integer, ByVal Classe As Integer)
        Dim SQL, Ordine As String
        tableprezzi = CStr(tbClassi.Rows(0)("tabClasPr")) & "Qmat"
        SQL = "SELECT * FROM " & tableprezzi & " WHERE prezzolkg>0"
        Ordine = " ORDER BY "
        If Classe = 1 Then Ordine &= "Tipo,"
        Select Case Cod
            Case 1
                If NumParamSc > 0 Then
                    SQL = SQL & Ordine & "Ordinamento,Parametro,Parametro2,DataRev"
                Else
                    SQL = SQL & Ordine & "Ordinamento,Parametro,Datarev"
                End If
            Case 2 : SQL = SQL & Ordine & "Ordinamento,Parametro2"
            Case 3 : SQL = SQL & Ordine & "Ordinamento,PrezzoLkg,DataRev"
            Case 4 : SQL = SQL & Ordine & "Ordinamento,DataRev"
            Case 5 : SQL = SQL & Ordine & "Ordinamento,Fornitore,DataRev"
            Case 6 : SQL = SQL & Ordine & "Ordinamento,Firmato,DataRev"
                '         IDHS.IDH_INTERNO_LISTINO1 , "per parametro primario"
                '         IDHS.IDH_INTERNO_LISTINO2 , "per parametro secondario"
                '         IDHS.IDH_INTERNO_LISTINO3 , "per prezzo al chilo"
                '         IDHS.IDH_INTERNO_LISTINO4 , "per data"
                '         IDHS.IDH_INTERNO_LISTINO5 , "per fornitore"
                '         IDHS.IDH_INTERNO_LISTINO6 , "per progettista"
        End Select
        Dim cmd As OleDbDataAdapter = New OleDbDataAdapter(SQL, MatBase)
        Try
            fillprezzi(SQL, CStr(tbClassi.Rows(0)("tabClasPr")))
        Catch e As Exception
            MsgBox(e.Message)
        End Try

    End Sub
    Private Sub Fai(ByVal Mat As clsMat, ByVal Primo As Boolean)
        Dim testo As String = ""
        Dim MatStr As String = ""
        Dim MatStrV As String = ""
        Dim n, ii, iFound As Integer
        If Mat.Classe > 10 Then
            Fai1(Primo)
            Exit Sub
        End If
        Count = prezzi.Rows.Count
        If Count > 0 Then
            For ii = 0 To Count - 1
                MatStr = CStr(prezzi.Rows(ii)("Mat"))
                If Not MatStr = MatStrV Then
                    Stub.LibMatScrivi(Primo, MatStr)
                    MatStrV = MatStr
                End If
                Select Case Mat.Classe
                    Case ClasseMateriale.Fucinati
                        dvtableparam.Sort = "Numero,Codice"
                        iFound = dvtableparam.Find(New Object() {prezzi.Rows(ii)("Parametro"), prezzi.Rows(ii)("Codice")})
                        If iFound < 0 Then
                            dvtableparam.Sort = "Codice"
                            iFound = dvtableparam.Find(prezzi.Rows(ii)("Codice"))
                            If iFound < 0 Then Stop
                        End If
                        Stub.Testo(CStr(dvtableparam(iFound)("Etichetta")))
                    Case Else
                        dvtableparam.Sort = "Numero"
                        iFound = dvtableparam.Find(prezzi.Rows(ii)("Parametro"))
                        If iFound < 0 Then Stop
                        Stub.Testo(CStr(dvtableparam(iFound)("Etichetta")))
                End Select
                Stub.MuoviCella(1)
                'parametro sec.
                If NumParamSc > 0 Then Stub.Testo(Str(prezzi.Rows(ii)("Parametro2")))
                '              r.Move wdCell, 1
                Stub.MuoviCella(1)
                '              r.Text = Trim$(myStr(!prezzolkg, 6, 0, False))
                Stub.Testo(Trim(Funzioni.myStr(CSng(prezzi.Rows(ii)("prezzolkg")), 6, 0, 0)))
                '              r.Move wdCell, 1
                Stub.MuoviCella(1)
                If Not CStr(tbClassi.Rows(0)("unitAlt")) = "-" Then
                    '                 r.Text = Trim$(myStr(!PrezzoAlt, 6, 0, False))
                    Stub.Testo(Trim(Funzioni.myStr(CSng(prezzi.Rows(ii)("PrezzoAlt")), 6, 0, 0)))
                End If
                '              r.Move wdCell, 1
                Stub.MuoviCella(1)
                Stub.Testo(Format(prezzi.Rows(ii)("Datarev"), "dd/MM/yy"))
                Stub.MuoviCella(1)
                If Not IsDBNull(prezzi.Rows(ii)("Fornitore")) Then Stub.Testo(CStr(prezzi.Rows(ii)("Fornitore")))
                Stub.MuoviCella(1)
                If Not IsDBNull(prezzi.Rows(ii)("Firmato")) Then Stub.Testo(CStr(prezzi.Rows(ii)("Firmato")))
                Stub.MuoviCella(1)
                If Not IsDBNull(prezzi.Rows(ii)("NoteMie")) Then
                    testo = CStr(prezzi.Rows(ii)("NoteMie"))
                    Do
                        n = InStr(n + 1, testo, Chr(13))
                        If n > 0 Then Mid(testo, n, 2) = "; "
                    Loop Until n = 0
                    Stub.Testo(testo)
                End If
                Stub.LibMatDestra()
                jCount = jCount + 1
                Monitor.Motore.Avanzamento = CSng(jCount * 100.0# / Count)
                System.Windows.Forms.Application.DoEvents()
                If InterrompiWinWord Then Exit For
            Next ii
        End If
    End Sub
    Private Sub Fai9(ByVal Mat As clsMat, ByVal Primo As Boolean)
        Dim testo As String = ""
        Dim MatStr As String = ""
        Dim MatStrV As String = ""
        Dim n, ii, iFound As Integer
        If Mat.Classe > 10 Then
            Fai19(Primo)
            Exit Sub
        End If
        Count = prezzi.Rows.Count
        If Count > 0 Then
            For ii = 0 To Count - 1
                MatStr = CStr(prezzi.Rows(ii)("Mat"))
                If Not MatStr = MatStrV Then
                    Stub9.LibMatScrivi(Primo, MatStr)
                    MatStrV = MatStr
                End If
                Select Case Mat.Classe
                    Case ClasseMateriale.Fucinati
                        dvtableparam.Sort = "Numero,Codice"
                        iFound = dvtableparam.Find(New Object() {prezzi.Rows(ii)("Parametro"), prezzi.Rows(ii)("Codice")})
                        If iFound < 0 Then
                            dvtableparam.Sort = "Codice"
                            iFound = dvtableparam.Find(prezzi.Rows(ii)("Codice"))
                            If iFound < 0 Then Stop
                        End If
                        Stub9.Testo(CStr(dvtableparam(iFound)("Etichetta")))
                    Case Else
                        dvtableparam.Sort = "Numero"
                        iFound = dvtableparam.Find(prezzi.Rows(ii)("Parametro"))
                        If iFound < 0 Then Stop
                        Stub9.Testo(CStr(dvtableparam(iFound)("Etichetta")))
                End Select
                Stub9.MuoviCella(1)
                'parametro sec.
                If NumParamSc > 0 Then Stub9.Testo(Str(prezzi.Rows(ii)("Parametro2")))
                '              r.Move wdCell, 1
                Stub9.MuoviCella(1)
                '              r.Text = Trim$(myStr(!prezzolkg, 6, 0, False))
                Stub9.Testo(Trim(Funzioni.myStr(CSng(prezzi.Rows(ii)("prezzolkg")), 6, 0, 0)))
                '              r.Move wdCell, 1
                Stub9.MuoviCella(1)
                If Not CStr(tbClassi.Rows(0)("unitAlt")) = "-" Then
                    '                 r.Text = Trim$(myStr(!PrezzoAlt, 6, 0, False))
                    Stub9.Testo(Trim(Funzioni.myStr(CSng(prezzi.Rows(ii)("PrezzoAlt")), 6, 0, 0)))
                End If
                '              r.Move wdCell, 1
                Stub9.MuoviCella(1)
                Stub9.Testo(Format(prezzi.Rows(ii)("Datarev"), "dd/MM/yy"))
                Stub9.MuoviCella(1)
                If Not IsDBNull(prezzi.Rows(ii)("Fornitore")) Then Stub9.Testo(CStr(prezzi.Rows(ii)("Fornitore")))
                Stub9.MuoviCella(1)
                If Not IsDBNull(prezzi.Rows(ii)("Firmato")) Then Stub9.Testo(CStr(prezzi.Rows(ii)("Firmato")))
                Stub9.MuoviCella(1)
                If Not IsDBNull(prezzi.Rows(ii)("NoteMie")) Then
                    testo = CStr(prezzi.Rows(ii)("NoteMie"))
                    Do
                        n = InStr(n + 1, testo, Chr(13))
                        If n > 0 Then Mid(testo, n, 2) = "; "
                    Loop Until n = 0
                    Stub9.Testo(testo)
                End If
                Stub9.LibMatDestra()
                jCount = jCount + 1
                Monitor.Motore.Avanzamento = CSng(jCount * 100.0# / Count)
                System.Windows.Forms.Application.DoEvents()
                If InterrompiWinWord Then Exit For
            Next ii
        End If
    End Sub
    Public Sub Genprezzi1(ByVal Cod As Integer)
        Dim SQL As String
        tableprezzi = CStr(tbClassi.Rows(0)("tabClasPr"))
        SQL = "SELECT * FROM " & tableprezzi & " WHERE prezzolkg>0"
        Select Case Cod
            Case 1
                If NumParamSc > 0 Then
                    SQL = SQL & " ORDER BY Parametro,Parametro2,DataRev"
                Else
                    SQL = SQL & " ORDER BY Parametro,Datarev"
                End If
            Case 2 : SQL = SQL & " ORDER BY Parametro2"
            Case 3 : SQL = SQL & " ORDER BY PrezzoLkg,DataRev"
            Case 4 : SQL = SQL & " ORDER BY DataRev"
            Case 5 : SQL = SQL & " ORDER BY Fornitore,DataRev"
            Case 6 : SQL = SQL & " ORDER BY Firmato,DataRev"
                '         IDHS.IDH_INTERNO_LISTINO1 , "per parametro primario"
                '         IDHS.IDH_INTERNO_LISTINO2 , "per parametro secondario"
                '         IDHS.IDH_INTERNO_LISTINO3 , "per prezzo al chilo"
                '         IDHS.IDH_INTERNO_LISTINO4 , "per data"
                '         IDHS.IDH_INTERNO_LISTINO5 , "per fornitore"
                '         IDHS.IDH_INTERNO_LISTINO6 , "per progettista"
        End Select
        fillprezzi(SQL, tableprezzi)
    End Sub
    Private Sub fillprezzi(ByVal SQL As String, ByVal originaltable As String)
        If Not cmdprezzi Is Nothing Then cmdprezzi.Update(prezzi)
        cmdprezzi = New OleDbDataAdapter(SQL, MatBase)
        cmdprezzi.MissingMappingAction = MissingMappingAction.Passthrough ' MissingMappingAction.Ignore
        Dim custMap As DataTableMapping = cmdprezzi.TableMappings.Add("Table", tableprezzi)
        Try
            'custMap.ColumnMappings.Add("prezzi1_ID", "prezzi1_ID")
            'custMap.ColumnMappings.Add("Parametro", "Parametro")
            'custMap.ColumnMappings.Add("PrezzoLkg", "PrezzoLkg")
            ' custMap.ColumnMappings.Add("Descrizione", "Note")
            ' custMap.ColumnMappings.Add("Firma", "Firmato")
            ' custMap.ColumnMappings.Add("Data", "DataRev")
            dsPrezzi = New DataSet
            cmdprezzi.DeleteCommand = New OleDbCommand("DELETE FROM " & originaltable & " WHERE ID = ?", MatBase)
            Dim param As OleDbParameter = cmdprezzi.DeleteCommand.Parameters.Add("ID", OleDbType.Integer)
            param.SourceColumn = "prezzi1_ID"
            param.SourceVersion = DataRowVersion.Original
            cmdprezzi.Fill(dsPrezzi)
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
        prezzi = dsPrezzi.Tables(0)
        prezzi.TableName = "tabPrezzi"
        dvprezzi = New DataView(prezzi)
        dvprezzi.AllowDelete = True
        dvprezzi.AllowNew = False
        dvprezzi.AllowEdit = True
    End Sub
    Private Sub Fai1(ByVal Primo As Boolean)
        Dim testo As String, n As Integer
        Dim i, iFind As Integer
        Dim dvtableparam As DataView = New DataView(tableparam)
        Count = prezzi.Rows.Count
        If Count > 0 Then
            Stub.LibMatScrivi(Primo, "ANNOTAZIONE")
            For i = 0 To CShort(Count - 1)
                dvtableparam.Sort = "Numero"
                iFind = dvtableparam.Find(prezzi.Rows(i)("Parametro"))
                If iFind < 0 Then Stop
                Stub.Testo(CStr(dvtableparam(iFind)("Etichetta")))
                Stub.MuoviCella(1)
                'parametro sec.
                If NumParamSc > 0 Then Stub.Testo(Str(prezzi.Rows(i)("Parametro2")))
                Stub.MuoviCella(1)
                Stub.Testo(Trim(Funzioni.myStr(CSng(prezzi.Rows(i)("prezzolkg")), 6, 0, 0)))
                Stub.MuoviCella(1)
                If Not CStr(tbClassi.Rows(0)("unitAlt")) = "-" Then
                    Stub.Testo(Trim(Funzioni.myStr(CSng(prezzi.Rows(i)("PrezzoAlt")), 6, 0, 0)))
                End If
                Stub.MuoviCella(1)
                Stub.Testo(Format(prezzi.Rows(i)("Datarev"), "dd/MM/yy"))
                Stub.MuoviCella(1)
                If Not IsDBNull(prezzi.Rows(i)("Fornitore")) Then Stub.Testo(CStr(prezzi.Rows(i)("Fornitore")))
                Stub.MuoviCella(1)
                If Not IsDBNull(prezzi.Rows(i)("Firmato")) Then Stub.Testo(CStr(prezzi.Rows(i)("Firmato")))
                Stub.MuoviCella(1)
                If Not IsDBNull(prezzi.Rows(i)("NoteMie")) Then
                    testo = CStr(prezzi.Rows(i)("NoteMie"))
                    Do
                        n = InStr(n + 1, testo, Chr(13))
                        If n > 0 Then Mid(testo, n, 2) = "  "
                    Loop Until n = 0
                    Stub.Testo(testo)
                End If
                '              r.Select
                Stub.LibMatDestra()
                jCount = jCount + 1
                Monitor.Motore.Avanzamento = CSng(jCount * 100.0# / Count)
                System.Windows.Forms.Application.DoEvents()
                If InterrompiWinWord Then Exit For
            Next
        End If
    End Sub
    Private Sub Fai19(ByVal Primo As Boolean)
        Dim testo As String, n As Integer
        Dim i, iFind As Integer
        Dim dvtableparam As DataView = New DataView(tableparam)
        Count = prezzi.Rows.Count
        If Count > 0 Then
            Stub9.LibMatScrivi(Primo, "ANNOTAZIONE")
            For i = 0 To CShort(Count - 1)
                dvtableparam.Sort = "Numero"
                iFind = dvtableparam.Find(prezzi.Rows(i)("Parametro"))
                If iFind < 0 Then Stop
                Stub9.Testo(CStr(dvtableparam(iFind)("Etichetta")))
                Stub9.MuoviCella(1)
                'parametro sec.
                If NumParamSc > 0 Then Stub9.Testo(Str(prezzi.Rows(i)("Parametro2")))
                Stub9.MuoviCella(1)
                Stub9.Testo(Trim(Funzioni.myStr(CSng(prezzi.Rows(i)("prezzolkg")), 6, 0, 0)))
                Stub9.MuoviCella(1)
                If Not CStr(tbClassi.Rows(0)("unitAlt")) = "-" Then
                    Stub9.Testo(Trim(Funzioni.myStr(CSng(prezzi.Rows(i)("PrezzoAlt")), 6, 0, 0)))
                End If
                Stub9.MuoviCella(1)
                Stub9.Testo(Format(prezzi.Rows(i)("Datarev"), "dd/MM/yy"))
                Stub9.MuoviCella(1)
                If Not IsDBNull(prezzi.Rows(i)("Fornitore")) Then Stub9.Testo(CStr(prezzi.Rows(i)("Fornitore")))
                Stub9.MuoviCella(1)
                If Not IsDBNull(prezzi.Rows(i)("Firmato")) Then Stub9.Testo(CStr(prezzi.Rows(i)("Firmato")))
                Stub9.MuoviCella(1)
                If Not IsDBNull(prezzi.Rows(i)("NoteMie")) Then
                    testo = CStr(prezzi.Rows(i)("NoteMie"))
                    Do
                        n = InStr(n + 1, testo, Chr(13))
                        If n > 0 Then Mid(testo, n, 2) = "  "
                    Loop Until n = 0
                    Stub9.Testo(testo)
                End If
                '              r.Select
                Stub9.LibMatDestra()
                jCount = jCount + 1
                Monitor.Motore.Avanzamento = CSng(jCount * 100.0# / Count)
                System.Windows.Forms.Application.DoEvents()
                If InterrompiWinWord Then Exit For
            Next
        End If
    End Sub
    Public Sub EliminaDB(ByRef r As DataRowView, ByRef Indmat As Short, ByRef Classe As ClasseMateriale)
        Dim c As New DataTable
        Dim V As New DataTable
        Dim RegNote As DataTable
        Dim prezzi As New DataTable
        Dim i, l As Short
        Dim iFindc, iFindV, iFindRegNote As Integer
        Dim CBr As OleDbCommandBuilder '19/09/07
        Try
            Dim cmd As OleDbDataAdapter = New OleDbDataAdapter("SELECT * FROM Caract", MatBase)
            cmd.Fill(c)
            CBr = New OleDbCommandBuilder(cmd) '19/09/07
            Dim dvc As DataView = New DataView(c)
            dvc.Sort = c.Columns(0).Caption
            ' c.Index = "PrimaryKey"
            Dim cmdV As OleDbDataAdapter = New OleDbDataAdapter("SELECT * FROM Valori", MatBase) '19/09/07
            cmdV.Fill(V)
            Dim CBrV As OleDbCommandBuilder = New OleDbCommandBuilder(cmdV) '19/09/07
            Dim dvV As DataView = New DataView(V)
            dvV.Sort = V.Columns(0).Caption
            'V.Index = "PrimaryKey"
            Dim cmdN As OleDbDataAdapter = New OleDbDataAdapter("SELECT * FROM IndNote", MatBase)
            RegNote = New DataTable
            cmdN.Fill(RegNote) '19/09/07
            Dim CBrN As OleDbCommandBuilder = New OleDbCommandBuilder(cmdN) '19/09/07
            '     RegNote.Index = "PrimaryKey"
            Dim dvRegNote As DataView = New DataView(RegNote)
            dvRegNote.Sort = RegNote.Columns(0).Caption
            For i = 1 To NumMaxCaract
                iFindc = dvc.Find(r(iFieldCaract(i)))
                If iFindc > -1 Then
                    For l = 1 To NumSerieValori
                        iFindV = dvV.Find(dvc(iFindc)(13 + l))
                        If iFindV > -1 Then
                            If CSng(dvV(iFindV)(1)) > -1 Then dvV.Delete(iFindV)
                        End If
                    Next
                    iFindRegNote = dvRegNote.Find(dvc(iFindc)("IndNote"))
                    If iFindRegNote > 0 Then
                        dvRegNote.Delete(iFindRegNote)
                    End If
                    dvc.Delete(iFindc)
                End If
            Next
            cmdN.Update(RegNote)
            cmdV.Update(V)
            cmd.Update(c)
            r.Delete()
            ParametriPrezzo(Classe)
            cmd = New OleDbDataAdapter("SELECT * FROM " & CStr(tbClassi.Rows(0)("tabClasPr")) & _
            " WHERE IdMat = " + Str(Indmat), MatBase)
            cmd.Fill(prezzi)
            CBr = New OleDbCommandBuilder(cmd) '19/09/07
            For i = 0 To CShort(prezzi.Rows.Count - 1)
                prezzi.Rows(0).Delete()
            Next
            Indmat = 0
            cmd.Update(prezzi)
            prezzi.Dispose()
        Catch e As Exception
            MsgBox("EliminaDB: " & e.Message & vbCrLf & e.StackTrace)
        End Try
    End Sub
    Public Sub UpdateNote()
        Dim i, ii As Short
        Dim Nota As String = ""
        Dim Tabella As String = ""
        Dim NoteN As DataTable
        Dim NoteV As DataTable
        Dim GenNot As String = ""
        Dim testo As String = ""
        Dim lGen As Short
        Dim drv As DataRowView
        Dim cmd As OleDbDataAdapter = New OleDbDataAdapter("SELECT * FROM Notes", MatBase)
        NoteV = New DataTable
        cmd.Fill(NoteV)
        Dim dvNoteV As DataView = New DataView(NoteV)
        For i = 1 To 6
            Select Case i
                Case 1 : Nota = "Note1A"
                    Tabella = "1A"
                Case 2 : Nota = "Note1B"
                    Tabella = "1B"
                Case 3 : Nota = "Note2A"
                    Tabella = "2A"
                Case 4 : Nota = "Note2B"
                    Tabella = "2B"
                Case 5 : Nota = "Note3"
                    Tabella = "3"
                Case 6 : Nota = "Note4"
                    Tabella = "4"
            End Select
            cmd = New OleDbDataAdapter("SELECT * FROM " & Nota, MatASME)
            Dim custCB As OleDbCommandBuilder = New OleDbCommandBuilder(cmd)
            NoteN = New DataTable
            cmd.Fill(NoteN)
            For ii = 0 To CShort(NoteN.Rows.Count - 1)
                If Not IsDBNull(NoteN.Rows(ii)("Campo2")) Then
                    testo = CStr(NoteN.Rows(ii)("Campo2"))
                Else
                    testo = ""
                End If
                lGen = CShort(Len(testo))
                If lGen > 4 Then
                    GenNot = testo
                ElseIf lGen = 0 Then
                    drv = dvNoteV(0)
                    drv.BeginEdit()
                    drv("note_text") = CStr(drv("note_text")) & vbCrLf & CStr(NoteN.Rows(ii)("campo4"))
                    drv.EndEdit()
                Else
                    drv = dvNoteV.AddNew()
                    drv("Notes Group") = GenNot
                    drv("Addenda") = NoteN.Rows(ii)("Campo1")
                    drv("note_abrv") = NoteN.Rows(ii)("Campo2")
                    drv("note_text") = NoteN.Rows(ii)("Campo4")
                    drv("Tabella") = Tabella
                    drv.EndEdit()
                End If
            Next ii
            cmd.Update(NoteN)
            custCB.Dispose()
            cmd.Dispose()
        Next
    End Sub
    Public Sub AggiustaNote()
        Dim r As New DataTable
        Dim c As New DataTable
        Dim note As New DataTable
        Dim notetxt As New DataTable
        Dim i, ir As Short
        Dim j As Short
        Dim iFindc, iFindnote, iFindNoteTxt As Integer
        IniziaBase()
        Dim cmdr As OleDbDataAdapter = New OleDbDataAdapter("SELECT * FROM Listamat", MatBase)
        Dim custCBr As OleDbCommandBuilder = New OleDbCommandBuilder(cmdr)
        cmdr.Fill(r)
        Dim cmdc As OleDbDataAdapter = New OleDbDataAdapter("Caract", MatBase)
        Dim custCBc As OleDbCommandBuilder = New OleDbCommandBuilder(cmdc)
        cmdc.Fill(c)
        Dim cmdn As OleDbDataAdapter = New OleDbDataAdapter("IndNote", MatBase)
        cmdn.Fill(note)
        Dim cmdx As OleDbDataAdapter = New OleDbDataAdapter("select * from Notes", MatBase)
        cmdx.Fill(notetxt)
        'c.Index = "PrimaryKey"
        'note.Index = "PrimaryKey"
        Dim dvr As DataView = New DataView(r)
        Dim dvc As DataView = New DataView(c)
        Dim dvnote As DataView = New DataView(note)
        Dim dvnotetxt As DataView = New DataView(notetxt)
        For ir = 0 To CShort(r.Rows.Count - 1)
            For i = 1 To NumMaxCaract
                dvc.Sort = c.Columns(0).Caption
                iFindc = dvc.Find(dvr(ir)(iFieldCaract(i)))
                If iFindc > -1 Then
                    If CInt(dvc(iFindc)("IndNote")) > 0 Then
                        dvnote.Sort = note.Columns(0).Caption
                        iFindnote = dvnote.Find(dvc(iFindc)("IndNote"))
                        If iFindnote > -1 Then
                            For j = 1 To CShort(note.Columns.Count - 1)
                                If CInt(dvnote(iFindnote)(j)) > 0 Then
                                    dvnote.Sort = notetxt.Columns(0).Caption
                                    iFindNoteTxt = dvnotetxt.Find(dvnote(iFindnote)(j))
                                    If iFindNoteTxt < 0 Then
                                        Riscrivi(note, dvr(ir), dvc(iFindc), False)
                                        Exit For
                                    End If
                                Else
                                    Exit For
                                End If
                            Next
                        Else
                            Riscrivi(note, dvr(ir), dvc(iFindc), True)
                        End If
                    End If
                End If
            Next
        Next ir
        cmdc.Update(c)
    End Sub
    Private Sub Riscrivi(ByRef note As DataTable, ByRef r As DataRowView, ByRef c As DataRowView, ByRef nuovo As Boolean)
        Dim listNote As String = ""
        Dim TabNota As String = ""
        Dim n, i, iFind As Integer
        Dim t As New DataTable
        Dim notetxt As New DataTable
        Dim sql, Spec As String
        Dim NF As String = ""
        Dim Nota As String = ""
        Dim cmd As OleDbDataAdapter
        Spec = CStr(r("Spec"))
        sql = ""
        If CInt(c("Codice")) = 6 Then
            If Not IsDBNull(r("Notes2")) Then listNote = CStr(r("Notes2"))
            TabNota = "2"
            If CInt(r("Classe")) = 8 Then TabNota = "4"
            If Len(Spec) > 0 Then sql = "SELECT * FROM [ANF-1] WHERE Spec='" & Trim(Spec) & "'"
        Else
            If Not IsDBNull(r("notes")) Then listNote = CStr(r("notes"))
            TabNota = "1"
            If CInt(r("Classe")) = 8 Then TabNota = "3"
            If Len(Spec) > 0 Then sql = "SELECT * FROM [UNF-23] WHERE Spec='" & Trim(Spec) & "'"
        End If
        If Len(listNote) = 0 Then Exit Sub
        If CInt(r("Classe")) <> 8 Then
            cmd = New OleDbDataAdapter(sql, MatBase)
            cmd.Fill(t)
            If t.Rows.Count > 0 Then NF = "B" Else NF = "A"
        End If
        TabNota = TabNota & NF
        cmd = New OleDbDataAdapter("SELECT * FROM Notes WHERE Tabella='" & TabNota & "'", MatBase)
        Dim custCB As OleDbCommandBuilder = New OleDbCommandBuilder(cmd)
        cmd.Fill(notetxt)
        Dim dvnote As DataView = New DataView(notetxt)
        Dim drv As DataRowView
        If nuovo Then
            drv = dvnote.AddNew()
        Else
            drv = dvnote(0)
            drv.BeginEdit()
        End If
        Do
            n = InStr(listNote, ",")
            If n > 0 Then
                Nota = Left(listNote, n - 1)
                listNote = Right(listNote, Len(listNote) - n)
                dvnote.Sort = "note_abrv"
                iFind = dvnote.Find(Nota.Trim)
                If iFind > -1 Then
                    i = i + 1
                    drv(i) = dvnote(iFind)("ID")
                End If
            Else
                Nota = listNote
                dvnote.Sort = "note_abrv"
                iFind = dvnote.Find(Nota.Trim)
                If iFind > -1 Then
                    i = i + 1
                    drv(i) = dvnote(iFind)("ID")
                End If
                Exit Do
            End If
        Loop
        drv.EndEdit()
        cmd.Update(notetxt)
        If nuovo Then
            c.BeginEdit()
            c("IndNote") = drv("ID")
            c.EndEdit()
        End If
    End Sub
    Public Sub PulisciValori()
        Dim V As New DataTable
        Dim c As New DataTable
        Dim i, iFindc As Integer
        Dim cmd As OleDbDataAdapter = New OleDbDataAdapter("SELECT * FROM Valori", MatBase)
        cmd.Fill(V)
        Dim custCB As OleDbCommandBuilder = New OleDbCommandBuilder(cmd)
        Dim cmdc As OleDbDataAdapter = New OleDbDataAdapter("SELECT * FROM Caract", MatBase)
        cmdc.Fill(c)
        Dim dvc As DataView = New DataView(c)
        Do
            dvc.Sort = "Indtemp"
            iFindc = dvc.Find(V.Rows(i)("ID"))
            If iFindc < 0 Then
                dvc.Sort = "IndAmmis"
                iFindc = dvc.Find(V.Rows(i)("ID"))
                If iFindc < 0 Then
                    dvc.Sort = "IndTempy"
                    iFindc = dvc.Find(V.Rows(i)("ID"))
                    If iFindc < 0 Then
                        dvc.Sort = "IndSy"
                        iFindc = dvc.Find(V.Rows(i)("ID"))
                        If iFindc < 0 Then
                            dvc.Sort = "IndTempU"
                            iFindc = dvc.Find(V.Rows(i)("ID"))
                            If iFindc < 0 Then
                                dvc.Sort = "IndU"
                                iFindc = dvc.Find(V.Rows(i)("ID"))
                                If iFindc < 0 Then V.Rows(i).Delete() : i -= 1
                            End If
                        End If
                    End If
                End If
            End If
            i += 1
        Loop While i < V.Rows.Count
        cmd.Update(V)
        dvc.Dispose()
        V.Dispose()
        c.Dispose()
    End Sub
    Public Sub PulisciCaract()
        Dim r As New DataTable
        Dim c As New DataTable
        Dim i, iFound As Integer
        Dim cmd As OleDbDataAdapter = New OleDbDataAdapter("SELECT * FROM ListaMat", MatBase)
        cmd.Fill(r)
        Dim dvr As DataView = New DataView(r)
        cmd = New OleDbDataAdapter("SELECT * FROM Caract", MatBase)
        cmd.Fill(c)
        For i = 0 To c.Rows.Count - 1
            dvr.Sort = "Caract1"
            iFound = dvr.Find(CStr(c.Rows(i)("ID")))
            If iFound = -1 Then
                dvr.Sort = "Caract2"
                iFound = dvr.Find(CStr(c.Rows(i)("ID")))
                If iFound = -1 Then
                    dvr.Sort = "Caract3"
                    iFound = dvr.Find(CStr(c.Rows(i)("ID")))
                    If iFound = -1 Then
                        dvr.Sort = "Caract4"
                        iFound = dvr.Find(CStr(c.Rows(i)("ID")))
                        If iFound = -1 Then
                            c.Rows(i).Delete()
                        End If
                    End If
                End If
            End If
        Next
        dvr.Dispose()
        c.Dispose()
        r.Dispose()
    End Sub
    Public Sub Stampe()
        Dim Documento As StubW2000.clsSW2000 = Nothing
        Dim Documento9 As StubW9.clsSW9 = Nothing
        Dim FileSt, FileLb As String
        Dim Riga As String
        Dim t As New DataTable
        Dim c As New DataTable
        Dim d As New DataTable
        Dim pagina As String
        Dim i, it, j As Short
        Dim iFind, iFindd As Integer
        Try
            If Not IniziaBase() Then Exit Sub
            FileSt = Monitor.Motore.Inizio.Datidir & "\StLibMat.doc"
            FileLb = Monitor.Motore.Inizio.Archdir & "\ASMEtable.doc"
            If Monitor.Motore.Inizio.VersOffice < 11 Then
                Documento9 = New StubW9.clsSW9
                Documento9.SuperStampa(FileLb, Monitor.Motore.Inizio.VersOffice)
            Else
                Documento = New StubW2000.clsSW2000
                Documento.SuperStampa(FileLb, Monitor.Motore.Inizio.VersOffice)
            End If
            Dim cmd As OleDbDataAdapter = New OleDbDataAdapter("SELECT * FROM ListaMat WHERE Len(R1A)>0 ORDER BY val(P1A) ,val(R1A)", MatBase)
            cmd.Fill(t)
            cmd = New OleDbDataAdapter("SELECT * FROM Caract", MatBase)
            cmd.Fill(c)
            Dim dvc As DataView = New DataView(c)
            dvc.Sort = "ID"
            cmd = New OleDbDataAdapter("SELECT * FROM directCH", MatBase)
            cmd.Fill(d)
            Dim dvd As DataView = New DataView(d)
            dvd.Sort = "ID"
            InterrompiWinWord = False
            Monitor.Motore.ProgrInizio(Monitor.Motore.HelpStringaG(IDHS.IDH_LISTINO_MSG), Monitor.Motore.HelpStringaG(IDHS.IDH_LISTINO_TIT1))
            If Monitor.Motore.Inizio.VersOffice < 11 Then
                With Documento9
                    .sOpen(FileLb, True)
                    .SubstitBookM("Sta", CStr(t.Rows(0)("R1A")), True)
                    .sSaveAs(FileSt)
                    For it = 0 To CShort(t.Rows.Count - 1)
                        .MuoviCella(1)
                        .Testo(CStr(t.Rows(it)("Composiz")))
                        .MuoviCella(1)
                        .Testo(CStr(t.Rows(it)("Product")))
                        .MuoviCella(1)
                        .Testo(CStr(t.Rows(it)("Spec")))
                        .MuoviCella(1)
                        If Not IsDBNull(t.Rows(it)("TypeGrade")) Then
                            .Testo(CStr(t.Rows(it)("TypeGrade")))
                        Else
                            .Testo(" ")
                        End If
                        .MuoviCella(1)
                        If Not IsDBNull(t.Rows(0)("AlloyUNS")) Then
                            .Testo(CStr(t.Rows(it)("AlloyUNS")))
                        Else
                            .Testo("...")
                        End If
                        .MuoviCella(1)
                        If Not IsDBNull(t.Rows(it)("ClassCondTemp")) Then
                            .Testo(CStr(t.Rows(it)("ClassCondTemp")))
                        Else
                            .Testo(" ")
                        End If
                        .MuoviCella(1)
                        If Not IsDBNull(t.Rows(it)("SizeThk")) Then
                            .Testo(CStr(t.Rows(it)("SizeThk")))
                        Else
                            .Testo(" ")
                        End If
                        .MuoviCella(1)
                        iFind = dvc.Find((t.Rows(0)("Caract1")))
                        If iFind < 0 Then Stop
                        .Testo(CStr(dvc(iFind)("PNumber")))
                        .MuoviCella(1)
                        .Testo(CStr(dvc(iFind)("GroupNb")))
                        .MuoviCella(1)
                        .Testo(CStr(dvc(iFind)("Yield")))
                        .MuoviCella(1)
                        .Testo(CStr(dvc(iFind)("US")))
                        .MuoviCella(1)
                        iFindd = dvd.Find((dvc(iFind)("IndChart")))
                        .Testo(CStr(dvd(iFindd)("Codice")))
                        .MuoviCella(1)
                        .Testo(CStr(t.Rows(it)("notes")))
                        pagina = CStr(t.Rows(it)("P1A"))
                        Riga = CStr(t.Rows(it)("R1A"))
                        If CStr(t.Rows(it)("P1A")) <> pagina Then
                            .VaiInizio("\EndOfDoc")
                            .sInsertBreak()
                            .sOpen(FileLb, True, 1)
                            .VaiInizio("", 1)
                            .Copia(1)
                            .sClose(, 1)
                            .VaiInizio("\EndOfDoc")
                            .sPaste()
                            .SubstitBookM("Sta", CStr(t.Rows(it)("R1A")), True)
                        Else
                            For i = CShort(CShort(Val(Riga)) + 1) To CShort(CShort(Val(t.Rows(it)("R1A"))) - 1)
                                .TastoTab()
                                .Testo(Str(i))
                                For j = 1 To 13
                                    .MuoviCella(1)
                                    .Testo(" ")
                                Next
                            Next
                            .TastoTab()
                            .Testo(CStr(t.Rows(it)("R1A")))
                        End If
                        Monitor.Motore.Avanzamento = CSng(it * 100.0# / (t.Rows.Count - 1))
                        System.Windows.Forms.Application.DoEvents()
                        If InterrompiWinWord Then Exit For
                    Next it
                    Monitor.Motore.ProgrAmmazza()
                End With
            Else
                With Documento
                    .sOpen(FileLb, True)
                    .SubstitBookM("Sta", CStr(t.Rows(0)("R1A")), True)
                    .sSaveAs(FileSt)
                    For it = 0 To CShort(t.Rows.Count - 1)
                        .MuoviCella(1)
                        .Testo(CStr(t.Rows(it)("Composiz")))
                        .MuoviCella(1)
                        .Testo(CStr(t.Rows(it)("Product")))
                        .MuoviCella(1)
                        .Testo(CStr(t.Rows(it)("Spec")))
                        .MuoviCella(1)
                        If Not IsDBNull(t.Rows(it)("TypeGrade")) Then
                            .Testo(CStr(t.Rows(it)("TypeGrade")))
                        Else
                            .Testo(" ")
                        End If
                        .MuoviCella(1)
                        If Not IsDBNull(t.Rows(0)("AlloyUNS")) Then
                            .Testo(CStr(t.Rows(it)("AlloyUNS")))
                        Else
                            .Testo("...")
                        End If
                        .MuoviCella(1)
                        If Not IsDBNull(t.Rows(it)("ClassCondTemp")) Then
                            .Testo(CStr(t.Rows(it)("ClassCondTemp")))
                        Else
                            .Testo(" ")
                        End If
                        .MuoviCella(1)
                        If Not IsDBNull(t.Rows(it)("SizeThk")) Then
                            .Testo(CStr(t.Rows(it)("SizeThk")))
                        Else
                            .Testo(" ")
                        End If
                        .MuoviCella(1)
                        iFind = dvc.Find((t.Rows(0)("Caract1")))
                        If iFind < 0 Then Stop
                        .Testo(CStr(dvc(iFind)("PNumber")))
                        .MuoviCella(1)
                        .Testo(CStr(dvc(iFind)("GroupNb")))
                        .MuoviCella(1)
                        .Testo(CStr(dvc(iFind)("Yield")))
                        .MuoviCella(1)
                        .Testo(CStr(dvc(iFind)("US")))
                        .MuoviCella(1)
                        iFindd = dvd.Find((dvc(iFind)("IndChart")))
                        .Testo(CStr(dvd(iFindd)("Codice")))
                        .MuoviCella(1)
                        .Testo(CStr(t.Rows(it)("notes")))
                        pagina = CStr(t.Rows(it)("P1A"))
                        Riga = CStr(t.Rows(it)("R1A"))
                        If CStr(t.Rows(it)("P1A")) <> pagina Then
                            .VaiInizio("\EndOfDoc")
                            .sInsertBreak()
                            .sOpen(FileLb, True, 1)
                            .VaiInizio("", 1)
                            .Copia(1)
                            .sClose(, 1)
                            .VaiInizio("\EndOfDoc")
                            .sPaste()
                            .SubstitBookM("Sta", CStr(t.Rows(it)("R1A")), True)
                        Else
                            For i = CShort(CShort(Val(Riga)) + 1) To CShort(CShort(Val(t.Rows(it)("R1A"))) - 1)
                                .TastoTab()
                                .Testo(Str(i))
                                For j = 1 To 13
                                    .MuoviCella(1)
                                    .Testo(" ")
                                Next
                            Next
                            .TastoTab()
                            .Testo(CStr(t.Rows(it)("R1A")))
                        End If
                        Monitor.Motore.Avanzamento = CSng(it * 100.0# / (t.Rows.Count - 1))
                        System.Windows.Forms.Application.DoEvents()
                        If InterrompiWinWord Then Exit For
                    Next it
                    Monitor.Motore.ProgrAmmazza()
                End With
            End If
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub

    Public Sub AggEU(ByRef Classe As Short, ByRef Ord As Short)
        Dim Materiali As New DataTable
        Dim MatEU As New DataTable
        Dim Caract As New DataTable
        Dim GruppiEN As New DataTable
        Dim dvMaterRistretto As DataView
        Dim Riga, Rigac As DataRowView
        Dim cmd As OleDbDataAdapter
        Dim i As Short
        Dim Ind As Short
        Dim iFound As Integer
        Dim Dimen As String
        Dim indice As Short
        If Len(Dir(FileMate)) = 0 Or Len(FileMate) = 0 Then
            Monitor.Motore.MostraAiuto(IDHS.IDH_UPASME_NODBMATE)
            Exit Sub
        End If
        On Error GoTo Errerr
        Dim cString As String = Conn & FileMate & ConnFine
        MatBase = New OleDbConnection(cString)
        cmd = New OleDbDataAdapter("SELECT * FROM ListaMat ORDER BY Ind", MatBase) ' WHERE Classe =" + Str$(Classe)) ' + " ORDER BY Ordinamento")
        Dim custCB As OleDbCommandBuilder = New OleDbCommandBuilder(cmd)
        cmd.Fill(Materiali)
        Dim dvMateriali As DataView = New DataView(Materiali)
        dvMateriali.Sort = "Ind"
        Dim cmdEU As OleDbDataAdapter = New OleDbDataAdapter("SELECT * FROM EuroMaterials WHERE Classe =" & Str(Classe) & " ORDER BY OldID", MatBase)
        cmdEU.Fill(MatEU)
        Dim dvMatEU As DataView = New DataView(MatEU)
        Dim cmdc As OleDbDataAdapter = New OleDbDataAdapter("SELECT * FROM Caract", MatBase)
        Dim custCBc As OleDbCommandBuilder = New OleDbCommandBuilder(cmdc)
        cmdc.Fill(Caract)
        Dim dvCaract As DataView = New DataView(Caract)
        Dim cmdEN As OleDbDataAdapter = New OleDbDataAdapter("SELECT * FROM GruppiEN", MatBase)
        cmdEN.Fill(GruppiEN)
        Dim dvGruppiEN As DataView = New DataView(GruppiEN)
        dvGruppiEN.Sort = "Gruppo"
        i = 0
        Ind = 0
        With dvMateriali
            Do
                dvMaterRistretto = New DataView(MatEU)
                dvMaterRistretto.RowFilter = "Spec='" & CStr(MatEU.Rows(i)("Spec")) & "' AND Grade='" & CStr(MatEU.Rows(i)("Grade")) & "'"
                Do
                    Ind = CShort(Ind + 1)
                    iFound = .Find(Ind)
                    If iFound < 0 Then Exit Do
                Loop
                Riga = .AddNew()
                Riga("Ind") = Ind
                Dimen = " "
                If dvMaterRistretto.Count > 0 Then
                    If CInt(MatEU.Rows(i)("Min")) = 0 Then
                        Dimen = " <" & Str(MatEU.Rows(i)("Max"))
                    Else
                        Dimen = Str(MatEU.Rows(i)("Min")) & " < e <" & Str(MatEU.Rows(i)("Max"))
                    End If
                End If
                Riga("Mat") = CStr(MatEU.Rows(i)("Spec")) & " Gr. " & CStr(MatEU.Rows(i)("Grade")) & Dimen
                Riga("TypeGrade") = MatEU.Rows(i)("Grade")
                Riga("ClassCondTemp") = MatEU.Rows(i)("Heat treatment")
                Riga("SizeThk") = Dimen
                Riga("Spec") = MatEU.Rows(i)("Spec")
                Riga("Product") = Trim(Funzioni.Adjust(CStr(MatEU.Rows(i)("Product form")), 25))
                Riga("Classe") = Classe
                Riga("notes") = MatEU.Rows(i)("notes")
                Riga("Description") = MatEU.Rows(i)("Material description")
                Riga("AlloyUNS") = MatEU.Rows(i)("Material number")
                Riga("Ordinamento") = Ord + (i + 1) / 1000.0#
                Riga("matID") = "EU" & Trim(Str(MatEU.Rows(i)("OldID")))
                Rigac = dvCaract.AddNew()
                Rigac("Codice") = 8
                Rigac("Source") = "EN-13345"
                If Classe = 8 Then
                    Rigac("GroupNb") = "Bolts"
                    indice = -1
                Else
                    iFound = dvGruppiEN.Find(CStr(MatEU.Rows(i)("GroupNb")))
                    If iFound < 0 Then Stop
                    indice = CShort(CShort(dvGruppiEN(iFound)("ID")) - 1)
                    Rigac("GroupNb") = "6.2"
                    If CStr(MatEU.Rows(i)("GroupNb")) = "8.1" Or CStr(MatEU.Rows(i)("GroupNb")) = "8.2" Then Rigac("GroupNb") = "6.3"
                End If
                Rigac("IndChart") = indice
                Rigac("MWDTrule") = " "
                Rigac("MWDTclause") = " "
                Rigac("PNumber") = " "
                Rigac.EndEdit()
                Riga("Caract1") = Rigac("ID")
                Riga.EndEdit()
                i = CShort(i + 1)
            Loop While i < MatEU.Rows.Count
            .Dispose()
        End With
        cmdc.Update(Caract)
        custCBc.Dispose()
        cmdc.Dispose()
        cmd.Update(Materiali)
        custCB.Dispose()
        cmd.Dispose()
        cmd = New OleDbDataAdapter _
        ("SELECT * FROM ListaMat WHERE Classe=" & Str(Classe) & " ORDER BY Ordinamento", MatBase)
        custCB = New OleDbCommandBuilder(cmd)
        cmd.Fill(Materiali)
        dvMateriali = New DataView(Materiali)
        For i = 0 To CShort(dvMateriali.Count - 1)
            dvMateriali(i).BeginEdit()
            dvMateriali(i)("Ordinamento") = i
            dvMateriali(i).EndEdit()
        Next
        cmd.Update(Materiali)
        dvMateriali.Dispose()
        custCB.Dispose()
        cmd.Dispose()
        Materiali.Dispose()
        Exit Sub
Errerr:
        System.Diagnostics.Debug.WriteLine(Err.Description)
        Stop
        Resume
    End Sub
    Public Function NumeroRiga(ByVal drv As DataRowView, ByVal dv As DataView) As Integer
        Dim j As Integer
        For j = 0 To dv.Count - 1
            If dv(j).Equals(drv) Then Return j
        Next
        Return 0
    End Function
End Module
Friend Class LinkListclsMat
    ' Reference to the empty head node
    Friend nodeHead As NodeP
    Friend nodeActual As NodeP
    ' Construct an empty LinkedList
    Public Sub New()
        nodeHead = New NodeP
    End Sub 'New
    ' Represent the LinkedList as a string
    Public Overrides Function ToString() As String
        Dim list As New StringBuilder("List:" & ControlChars.CrLf)
        Dim index As Integer = 0
        Dim iterator As NodeP = nodeHead.Next
        While Not (iterator Is Nothing)
            list.Append(("Node #" & index.ToString() & ControlChars.CrLf & iterator.ToString() & ControlChars.CrLf))
            index = index + 1
            iterator = iterator.Next
        End While
        Return list.ToString()
    End Function 'ToString
    ' Add a node
    Public Sub Add(ByVal point As clsMat)
        If nodeHead.TextData Is Nothing Then
            nodeHead.TextData = point
            nodeActual = nodeHead
        Else
            Dim node As New NodeP
            node.TextData = point
            node.Add(nodeHead)
            nodeActual = node
        End If
    End Sub 'Add
    Public Function Count() As Integer
        Dim index As Integer = 1
        Dim iterator As NodeP = nodeHead.Next
        If nodeHead.TextData Is Nothing Then
            Return 0
        Else
            While Not (iterator Is Nothing)
                index = index + 1
                iterator = iterator.Next
            End While
            Return index
        End If
    End Function
    Public Function Item(ByVal i As Integer) As NodeP
        Dim iterator As NodeP = nodeHead
        Dim index As Integer = 1
        While Not (iterator Is Nothing) And i <> index
            index = index + 1
            iterator = iterator.Next
        End While
        Return iterator
    End Function
    Public Sub remove(ByVal i As Integer)
        If i = 1 Then
            If Not nodeHead.Next Is Nothing Then
                nodeHead = nodeHead.Next
            Else
                nodeHead.TextData = Nothing
            End If
        Else
            Item(i - 1).Next = Item(i + 1)
        End If
    End Sub
    ' This nested type is also attributed as serializable
    Friend Class NodeP
        ' Private field referencing the next node in the list
        Private nextField As NodeP
        ' Private fields containing node data
        Private DataField As clsMat
        ' Construct a Node object
        Public Sub New()
            nextField = Nothing
        End Sub 'New
        ' Add a node object to a list
        Public Sub Add(ByVal nodeHead As NodeP)
            Dim iterator As NodeP = nodeHead
            While Not (iterator.nextField Is Nothing)
                iterator = iterator.Next
            End While
            iterator.nextField = Me
            nextField = Nothing
        End Sub 'Add
        ' Accessor property for textData private field
        Public Property TextData() As clsMat
            Get
                Return DataField
            End Get
            Set(ByVal Value As clsMat)
                DataField = Value
            End Set
        End Property
        ' Read-only property for next private field
        Public Property [Next]() As NodeP
            Get
                Return nextField
            End Get
            Set(ByVal Value As NodeP)
                nextField = Value
            End Set
        End Property
        ' Represent the node as a string
        Public Overrides Function ToString() As String
            Return ControlChars.Tab & "TextData   " & ChrW(61) & " """ & TextData.ToString
        End Function 'ToString
    End Class 'Node
End Class 'LinkedListPublic Class LinkedList
<Serializable()> Public Class LinkListCarattNew
    ' Reference to the empty head node
    Private nodeHead As NodeCarattNew
    Private nodeActual As NodeCarattNew
    ' Construct an empty LinkedList
    Public Sub New()
        nodeHead = New NodeCarattNew
    End Sub 'New
    ' Represent the LinkedList as a string
    Public Overrides Function ToString() As String
        Dim list As New StringBuilder("List:" & ControlChars.CrLf)
        Dim index As Integer = 0
        Dim iterator As NodeCarattNew = nodeHead.Next
        While Not (iterator Is Nothing)
            list.Append(("Node #" & index.ToString() & ControlChars.CrLf & iterator.ToString() & ControlChars.CrLf))
            index = index + 1
            iterator = iterator.Next
        End While
        Return list.ToString()
    End Function 'ToString
    ' Add a node
    Public Sub Add(ByVal point As CarattMatNew)
        If nodeHead.TextData Is Nothing Then
            nodeHead.TextData = point
            nodeActual = nodeHead
        Else
            Dim node As New NodeCarattNew
            node.TextData = point
            node.Add(nodeHead)
            nodeActual = node
        End If
    End Sub 'Add
    Public Function Count() As Integer
        Dim index As Integer = 1
        Dim iterator As NodeCarattNew = nodeHead.Next
        If nodeHead.TextData Is Nothing Then
            Return 0
        Else
            While Not (iterator Is Nothing)
                index = index + 1
                iterator = iterator.Next
            End While
            Return index
        End If
    End Function
    Default Public ReadOnly Property Item(ByVal i As Integer) As NodeCarattNew
        Get
            Dim iterator As NodeCarattNew = nodeHead
            Dim index As Integer = 1
            While Not (iterator Is Nothing) And i <> index
                index = index + 1
                iterator = iterator.Next
            End While
            Return iterator
        End Get
    End Property
    Public Sub remove(ByVal i As Integer)
        If i = 1 Then
            If Not nodeHead.Next Is Nothing Then
                nodeHead = nodeHead.Next
            Else
                nodeHead.TextData = Nothing
            End If
        Else
            Item(i - 1).Next = Item(i + 1)
        End If
    End Sub
    Public Sub remeveall()
        nodeHead.Next = Nothing
        nodeHead.TextData = Nothing
    End Sub
End Class
<Serializable()> Public Class LinkListCaratt
    ' Reference to the empty head node
    Private nodeHead As NodeCaratt
    Private nodeActual As NodeCaratt
    ' Construct an empty LinkedList
    Public Sub New()
        nodeHead = New NodeCaratt
    End Sub 'New
    Public Sub Add(ByVal point As CarattMat)
        If nodeHead.TextData Is Nothing Then
            nodeHead.TextData = point
            nodeActual = nodeHead
        Else
            Dim node As New NodeCaratt
            node.TextData = point
            node.Add(nodeHead)
            nodeActual = node
        End If
    End Sub 'Add
    Public Function Count() As Integer
        Dim index As Integer = 1
        Dim iterator As NodeCaratt = nodeHead.Next
        If nodeHead.TextData Is Nothing Then
            Return 0
        Else
            While Not (iterator Is Nothing)
                index = index + 1
                iterator = iterator.Next
            End While
            Return index
        End If
    End Function
    Default Public ReadOnly Property Item(ByVal i As Integer) As NodeCaratt
        Get
            Dim iterator As NodeCaratt = nodeHead
            Dim index As Integer = 1
            While Not (iterator Is Nothing) And i <> index
                index = index + 1
                iterator = iterator.Next
            End While
            Return iterator
        End Get
    End Property
    Public Sub remove(ByVal i As Integer)
        If i = 1 Then
            If Not nodeHead.Next Is Nothing Then
                nodeHead = nodeHead.Next
            Else
                nodeHead.TextData = Nothing
            End If
        Else
            Item(i - 1).Next = Item(i + 1)
        End If
    End Sub
    Public Sub remeveall()
        nodeHead.Next = Nothing
        nodeHead.TextData = Nothing
    End Sub
End Class
<Serializable()> Public Class NodeCarattNew
    Private nextField As NodeCarattNew
    Private DataField As CarattMatNew
    Public Sub New()
        nextField = Nothing
    End Sub 'New
    Public Sub Add(ByVal nodeHead As NodeCarattNew)
        Dim iterator As NodeCarattNew = nodeHead
        While Not (iterator.nextField Is Nothing)
            iterator = iterator.Next
        End While
        iterator.nextField = Me
        nextField = Nothing
    End Sub 'Add
    Public Property TextData() As CarattMatNew
        Get
            Return DataField
        End Get
        Set(ByVal Value As CarattMatNew)
            DataField = Value
        End Set
    End Property
    Public Property [Next]() As NodeCarattNew
        Get
            Return nextField
        End Get
        Set(ByVal Value As NodeCarattNew)
            nextField = Value
        End Set
    End Property
    Public Overrides Function ToString() As String
        Return ControlChars.Tab & "TextData   " & ChrW(61) & " """ & TextData.ToString
    End Function 'ToString
End Class 'Node
<Serializable()> Public Class NodeCaratt
    Private nextField As NodeCaratt
    Private DataField As CarattMat
    Public Sub New()
        nextField = Nothing
    End Sub 'New
    Public Sub Add(ByVal nodeHead As NodeCaratt)
        Dim iterator As NodeCaratt = nodeHead
        While Not (iterator.nextField Is Nothing)
            iterator = iterator.Next
        End While
        iterator.nextField = Me
        nextField = Nothing
    End Sub 'Add
    Public Property TextData() As CarattMat
        Get
            Return DataField
        End Get
        Set(ByVal Value As CarattMat)
            DataField = Value
        End Set
    End Property
    Public Property [Next]() As NodeCaratt
        Get
            Return nextField
        End Get
        Set(ByVal Value As NodeCaratt)
            nextField = Value
        End Set
    End Property
End Class
'Friend Class LinkListRS
'' Reference to the empty head node
'Friend nodeHead As NodeP
'Friend nodeActual As NodeP
'' Construct an empty LinkedList
'Public Sub New()
'    nodeHead = New NodeP
'End Sub 'New
'' Represent the LinkedList as a string
'Public Overrides Function ToString() As String
'    Dim list As New StringBuilder("List:" & ControlChars.CrLf)
'    Dim index As Integer = 0
'    Dim iterator As NodeP = nodeHead.Next
'    While Not (iterator Is Nothing)
'        list.Append(("Node #" & index.ToString() & ControlChars.CrLf & iterator.ToString() & ControlChars.CrLf))
'        index = index + 1
'        iterator = iterator.Next
'    End While
'    Return list.ToString()
'End Function 'ToString
'' Add a node
'Public Sub Add(ByVal point As DataView, Optional ByVal key As String = "", Optional ByVal Before As Integer = 0, Optional ByVal After As Integer = 0)
'    If nodeHead.TextData Is Nothing Then
'        nodeHead.TextData = point
'        nodeActual = nodeHead
'    Else
'        Dim node As New NodeP
'        node.TextData = point
'        node.Add(nodeHead, key, Before, After)
'        nodeActual = node
'    End If
'End Sub 'Add
'Public Function Count() As Integer
'    Dim index As Integer = 1
'    Dim iterator As NodeP = nodeHead.Next
'    If nodeHead.TextData Is Nothing Then
'        Return 0
'    Else
'        While Not (iterator Is Nothing)
'            index = index + 1
'            iterator = iterator.Next
'        End While
'        Return index
'    End If
'End Function
'Public Function Item(ByVal i As Integer) As NodeP
'    Dim iterator As NodeP = nodeHead
'    Dim index As Integer = 1
'    While Not (iterator Is Nothing) And i <> index
'        index = index + 1
'        iterator = iterator.Next
'    End While
'    Return iterator
'End Function
'Public Sub remove(ByVal i As Integer)
'    If i = 1 Then
'        If Not nodeHead.Next Is Nothing Then
'            nodeHead = nodeHead.Next
'        Else
'            nodeHead.TextData = Nothing
'        End If
'    Else
'        Item(i - 1).Next = Item(i + 1)
'    End If
'End Sub
'' This nested type is also attributed as serializable
'Friend Class NodeP
'' Private field referencing the next node in the list
'Private nextField As NodeP
'' Private fields containing node data
'Private DataField As DataView
'' Construct a Node object
'Public Sub New()
'    nextField = Nothing
'End Sub 'New
'' Add a node object to a list
'Public Sub Add(ByRef nodeHead As NodeP, Optional ByVal key As String = "", Optional ByVal Before As Integer = 0, Optional ByVal After As Integer = 0)
'    Dim iterator As NodeP = nodeHead
'    Dim index As Integer = 1
'    If Before = 1 Then
'        nextField = nodeHead
'        nodeHead = Me
'    Else
'        While Not (iterator.nextField Is Nothing)
'            If index = After Or index + 1 = Before Then
'                nextField = iterator.Next
'                iterator.Next = Me
'                Exit Sub
'            End If
'           index = index + 1
'           iterator = iterator.Next
'        End While
'        iterator.nextField = Me
'        nextField = Nothing
'    End If
'End Sub 'Add
'' Accessor property for textData private field
'Public Property TextData() As DataView
'    Get
'        Return DataField
'    End Get
'    Set(ByVal Value As DataView)
'        DataField = Value
'   End Set
'End Property
'' Read-only property for next private field
'Public Property [Next]() As NodeP
'    Get
'        Return nextField
'    End Get
'    Set(ByVal Value As NodeP)
'        nextField = Value
'    End Set
'End Property
'' Represent the node as a string
'Public Overrides Function ToString() As String
'    Return "not available for the moment" 'ControlChars.Tab & "TextData   " & ChrW(61) & " """ & TextData.ToString
'End Function 'ToString
'End Class 'Node
'End Class
'Friend Class LinkListTB
'' Reference to the empty head node
'Friend nodeHead As NodeP
'Friend nodeActual As NodeP
'' Construct an empty LinkedList
'Public Sub New()
'    nodeHead = New NodeP
'End Sub 'New
'' Represent the LinkedList as a string
'Public Overrides Function ToString() As String
'    Dim list As New StringBuilder("List:" & ControlChars.CrLf)
'    Dim index As Integer = 0
'    Dim iterator As NodeP = nodeHead.Next
'    While Not (iterator Is Nothing)
'        list.Append(("Node #" & index.ToString() & ControlChars.CrLf & iterator.ToString() & ControlChars.CrLf))
'        index = index + 1
'        iterator = iterator.Next
'    End While
'    Return list.ToString()
'End Function 'ToString
'' Add a node
'Public Sub Add(ByVal point As DataTable, Optional ByVal key As String = "", Optional ByVal Before As Integer = 0, Optional ByVal After As Integer = 0)
'    If nodeHead.TextData Is Nothing Then
'        nodeHead.TextData = point
'        nodeActual = nodeHead
'    Else
'        Dim node As New NodeP
'        node.TextData = point
'        node.Add(nodeHead, key, Before, After)
'        nodeActual = node
'    End If
'End Sub 'Add
'Public Function Count() As Integer
'    Dim index As Integer = 1
'    Dim iterator As NodeP = nodeHead.Next
'    If nodeHead.TextData Is Nothing Then
'        Return 0
'    Else
'        While Not (iterator Is Nothing)
'            index = index + 1
'            iterator = iterator.Next
'        End While
'        Return index
'    End If
'End Function
'Public Function Item(ByVal i As Integer) As NodeP
'    Dim iterator As NodeP = nodeHead
'    Dim index As Integer = 1
'    While Not (iterator Is Nothing) And i <> index
'        index = index + 1
'       iterator = iterator.Next
'   End While
'    Return iterator
'End Function
'Public Sub remove(ByVal i As Integer)
'    If i = 1 Then
'        If Not nodeHead.Next Is Nothing Then
'            nodeHead = nodeHead.Next
'        Else
'            nodeHead.TextData = Nothing
'        End If
'    Else
'        Item(i - 1).Next = Item(i + 1)
'    End If
'End Sub
'' This nested type is also attributed as serializable
'Friend Class NodeP
'' Private field referencing the next node in the list
'Private nextField As NodeP
'' Private fields containing node data
'Private DataField As DataTable
'' Construct a Node object
'Public Sub New()
'    nextField = Nothing
'End Sub 'New
'' Add a node object to a list
'Public Sub Add(ByRef nodeHead As NodeP, Optional ByVal key As String = "", Optional ByVal Before As Integer = 0, Optional ByVal After As Integer = 0)
'    Dim iterator As NodeP = nodeHead
'    Dim index As Integer = 1
'    If Before = 1 Then
'        nextField = nodeHead
'        nodeHead = Me
'    Else
'        While Not (iterator.nextField Is Nothing)
'            If index = After Or index + 1 = Before Then
'                nextField = iterator.Next
'                iterator.Next = Me
'                Exit Sub
'            End If
'            index = index + 1
'            iterator = iterator.Next
'        End While
'        iterator.nextField = Me
'        nextField = Nothing
'    End If
'End Sub 'Add
'' Accessor property for textData private field
'Public Property TextData() As DataTable
'    Get
'        Return DataField
'    End Get
'    Set(ByVal Value As DataTable)
'        DataField = Value
'    End Set
'End Property
'' Read-only property for next private field
'Public Property [Next]() As NodeP
'    Get
'        Return nextField
'    End Get
'    Set(ByVal Value As NodeP)
'        nextField = Value
'    End Set
'End Property
'' Represent the node as a string
'Public Overrides Function ToString() As String
'    Return "not available for the moment" 'ControlChars.Tab & "TextData   " & ChrW(61) & " """ & TextData.ToString
'End Function 'ToString
'End Class 'Node
'End Class
