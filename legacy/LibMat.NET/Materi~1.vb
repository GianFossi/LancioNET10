Option Strict On
Option Explicit On 
Imports RoutBase1
Imports System.Collections
Imports System.Collections.Specialized
Imports System.Data
Imports System.Data.OleDb
Imports System.text
Imports RoutBase1.clsInizio
<Serializable()> Public Class Materiale
    Public Indmat As Short
    Public MatStr As String
    Public Composiz As String
    Public Product As String
    Public AlloyUNS As String
    Public PSP As Short
    Public CAT As String
    Public CT As String
    Public CMT As String
    Public Classe As Short
    Public ElasCod As Short
    Public alfacod As Short
    Public ConducTer As Short
    Public MatGroup As Short
    Public NomeComm As String
    Public Caract As LinkListCaratt
    Friend Ind As LinkListSh
    Public Spec As String
    Public Grado As String
    Public ClassTemper As String
    Public Dimensions As String
    Public Editato As Boolean
    Private prAgganciato As Boolean
    Private Silente As Boolean
    Private m_TempDes As Single
    <NonSerialized()> Private Valori As DataTable
    <NonSerialized()> Private GiaCaricatiValori As Boolean
    <NonSerialized()> Private Temper() As Single
    <NonSerialized()> Private Younger() As Single
    <NonSerialized()> Private Yielder() As Single
    <NonSerialized()> Public AlfaYoung As clsAlfaYoung
    Public Property Agganciato() As Boolean
        Get
            Return prAgganciato
        End Get
        Set(ByVal Value As Boolean)
            prAgganciato = Value
        End Set
    End Property
    Public Function Converti() As MaterialeNew1
        Dim m As New MaterialeNew1
        m.Indmat = Indmat
        m.MatStr = MatStr
        m.Composiz = Composiz
        m.Product = Product
        m.AlloyUNS = AlloyUNS
        m.PSP = PSP
        m.CAT = CAT
        m.CT = CT
        m.CMT = CMT
        m.Classe = CType(Classe, ClasseMateriale)
        m.ElasCod = ElasCod
        m.alfacod = alfacod
        m.ConducTer = ConducTer
        m.MatGroup = MatGroup
        m.NomeComm = NomeComm
        m.Caract.remeveall()
        m.Caract.Add(Caract(1).TextData.Converti)
        '      Friend Ind As LinkListSh
        m.Spec = Spec
        m.Grado = Grado
        m.ClassTemper = ClassTemper
        m.Dimensions = Dimensions
        m.Editato = Editato
        m.Agganciato = Agganciato
        '        Private Silente As Boolean
        '       Private m_TempDes As Single
        Return m
    End Function
    Public Sub New()
        MyBase.New()
        MatStr = ""
        Composiz = ""
        Product = ""
        AlloyUNS = ""
        Spec = ""
        Grado = ""
        ClassTemper = ""
        Dimensions = ""
        Caract = New LinkListCaratt
        Ind = New LinkListSh
        Dim Car1 As New CarattMat
        Dim Car2 As New CarattMat
        Dim Car3 As New CarattMat
        Dim Car4 As New CarattMat
        Caract.Add(Car1)
        Caract.Add(Car2)
        Caract.Add(Car3)
        Caract.Add(Car4)
        AlfaYoung = New clsAlfaYoung
    End Sub
End Class
<Serializable()> Public Class MaterialeNew
    Public Indmat As Short
    Public MatStr As String
    Public Composiz As String
    Public Product As String
    Public AlloyUNS As String
    Public PSP As Short
    Public CAT As String
    Public CT As String
    Public CMT As String
    Public Classe As Short
    Public ElasCod As Short
    Public alfacod As Short
    Public ConducTer As Short
    Public MatGroup As Short
    Public NomeComm As String
    Public Caract As LinkListCarattNew
    Friend Ind As LinkListSh
    Public Spec As String
    Public Grado As String
    Public ClassTemper As String
    Public Dimensions As String
    Public Editato As Boolean
    Private prAgganciato As Boolean
    Private Silente As Boolean
    Private m_TempDes As Single
    <NonSerialized()> Private Valori As DataTable
    <NonSerialized()> Private GiaCaricatiValori As Boolean
    <NonSerialized()> Private Temper() As Single
    <NonSerialized()> Private Younger() As Single
    <NonSerialized()> Private Yielder() As Single
    <NonSerialized()> Public AlfaYoung As clsAlfaYoung
    Public Property Agganciato() As Boolean
        Get
            Return prAgganciato
        End Get
        Set(ByVal Value As Boolean)
            prAgganciato = Value
        End Set
    End Property
    Public Function Converti() As MaterialeNew1
        Dim m As New MaterialeNew1
        m.Indmat = Indmat
        m.MatStr = MatStr
        m.Composiz = Composiz
        m.Product = Product
        m.AlloyUNS = AlloyUNS
        m.PSP = PSP
        m.CAT = CAT
        m.CT = CT
        m.CMT = CMT
        m.Classe = CType(Classe, ClasseMateriale)
        m.ElasCod = ElasCod
        m.alfacod = alfacod
        m.ConducTer = ConducTer
        m.MatGroup = MatGroup
        m.NomeComm = NomeComm
        m.Caract = Caract
        m.Spec = Spec
        m.Grado = Grado
        m.ClassTemper = ClassTemper
        m.Dimensions = Dimensions
        m.Editato = Editato
        m.Agganciato = Agganciato
        Return m
    End Function
    Public Sub New()
        MyBase.New()
        MatStr = ""
        Composiz = ""
        Product = ""
        AlloyUNS = ""
        Spec = ""
        Grado = ""
        ClassTemper = ""
        Dimensions = ""
        Caract = New LinkListCarattNew
        Ind = New LinkListSh
        Dim Car1 As New CarattMatNew
        Dim Car2 As New CarattMatNew
        Dim Car3 As New CarattMatNew
        Dim Car4 As New CarattMatNew
        Caract.Add(Car1)
        Caract.Add(Car2)
        Caract.Add(Car3)
        Caract.Add(Car4)
        AlfaYoung = New clsAlfaYoung
    End Sub
End Class
<Serializable()> Public Class MaterialeNew1
    Public Indmat As Short
    Public MatStr As String
    Public Composiz As String
    Public Product As String
    Public AlloyUNS As String
    Public PSP As Short
    Public CAT As String
    Public CT As String
    Public CMT As String
    Public Classe As ClasseMateriale
    Public ElasCod As Short
    Public alfacod As Short
    Public ConducTer As Short
    Public MatGroup As Short
    Public NomeComm As String
    Public Caract As LinkListCarattNew
    Friend Ind As LinkListSh
    Public Spec As String
    Public Grado As String
    Public ClassTemper As String
    Public Dimensions As String
    Public Editato As Boolean
    Private prAgganciato As Boolean
    Private Silente As Boolean
    Private m_TempDes As Single
    <NonSerialized()> Private Valori As DataTable
    <NonSerialized()> Private GiaCaricatiValori As Boolean
    <NonSerialized()> Private Temper() As Single
    <NonSerialized()> Private Younger() As Single
    <NonSerialized()> Private Yielder() As Single
    <NonSerialized()> Public AlfaYoung As clsAlfaYoung
    Public Sub SaveMat()
        Dim r As New DataTable
        Dim c As New DataTable
        Dim V As New DataTable
        Dim l, mm As Short
        Dim i As Short
        Dim Clas As ClasseMateriale
        Dim NoMatch, Nuovo As Boolean
        Dim drvc As DataRowView
        Dim iFoundc As Integer
        Dim drvV As DataRowView
        Dim iFoundV As Integer
        If Not Agganciato Then Exit Sub
        Clas = Classe
        If MatBase Is Nothing Then Exit Sub
        Dim cmd As OleDbDataAdapter = New OleDbDataAdapter _
        ("SELECT * FROM ListaMat WHERE Classe=" & Str(Clas), MatBase)
        Dim custCB As OleDbCommandBuilder = New OleDbCommandBuilder(cmd)
        cmd.Fill(r)
        If r.Rows.Count < 1 Then MsgBox("Put Oopss!")
        Dim dvr As DataView = New DataView(r)
        dvr.Sort = "Ind"
        Dim iFound As Integer = dvr.Find(Indmat)
        If iFound < 0 Then
            MsgBox("Put 2 Oops! Ind=" & Str(Indmat))
            Exit Sub
        End If
        Dim drvr As DataRowView = dvr(iFound)
        drvr.BeginEdit()
        drvr("Mat") = MatStr
        drvr("AlloyUNS") = AlloyUNS
        If AlloyUNS = "" Then drvr("AlloyUNS") = "..."
        drvr("Composiz") = Composiz
        If Composiz = "" Then drvr("Composiz") = "..."
        drvr("Product") = Product
        If Product = "" Then Product = " "
        If Spec = "" Then Spec = " "
        drvr("Spec") = Spec
        If Grado = "" Then Grado = " "
        drvr("TypeGrade") = Grado
        If ClassTemper = "" Then ClassTemper = " "
        drvr("ClassCondTemp") = ClassTemper
        If Dimensions = "" Then Dimensions = " "
        drvr("SizeThk") = Dimensions
        If NomeComm = "" Then NomeComm = " "
        drvr("NomeComm") = NomeComm
        drvr("Ind") = Indmat
        drvr("PSP") = PSP
        drvr("CAT") = CAT
        drvr("CT") = CT
        drvr("CMT") = CMT
        drvr("Classe") = Classe
        drvr("ElasCod") = ElasCod
        drvr("alfacod") = alfacod
        drvr("ConducTer") = ConducTer
        drvr("MatGroup") = MatGroup
        drvr.EndEdit()
        Dim cmdc As OleDbDataAdapter = New OleDbDataAdapter("SELECT * FROM Caract", MatBase)
        cmdc.MissingSchemaAction = MissingSchemaAction.AddWithKey
        Dim custCBc As OleDbCommandBuilder = New OleDbCommandBuilder(cmdc)
        cmdc.Fill(c)
        Dim dvc As DataView = New DataView(c)
        dvc.Sort = "ID"
        Dim cmdV As OleDbDataAdapter = New OleDbDataAdapter("SELECT * FROM Valori", MatBase)
        Dim custCBV As OleDbCommandBuilder = New OleDbCommandBuilder(cmdV)
        cmdV.Fill(V)
        Dim dvV As DataView = New DataView(V)
        dvV.Sort = "ID"
        Try
            For i = 1 To CShort(Caract.Count)
                With Caract.Item(i).TextData
                    iFoundc = dvc.Find(dvr(iFound)(iFieldCaract(i)))
                    If iFoundc < 0 Then
                        If .Codice = Codes.NonDef Then GoTo Cont
                        drvc = dvc.AddNew()
                        drvc.EndEdit()
                        cmdc.Update(c)
                        c = New DataTable
                        cmdc.Fill(c)
                        dvc = New DataView(c)
                        dvc.Sort = "ID"
                        drvc = dvc(c.Rows.Count - 1)
                        drvr.BeginEdit()
                        drvr(iFieldCaract(i)) = drvc("ID")
                        drvr.EndEdit()
                    Else
                        drvc = dvc(iFoundc)
                    End If
                    drvc.BeginEdit()
                    drvc("Codice") = .Codice
                    drvc("Source") = .Source
                    If Len(drvc("Source")) = 0 Then drvc("Source") = " "
                    drvc("Yield") = .Yield
                    drvc("Alfa") = .Alfa
                    drvc("Young") = .Young
                    drvc("US") = .US
                    drvc("IndChart") = .IndChart
                    drvc("IndNote") = .IndNote
                    If Len(Trim(.MWDTrule)) = 0 Then .MWDTrule = " "
                    drvc("MWDTrule") = .MWDTrule
                    If Len(Trim(.MWDTclause)) = 0 Then .MWDTclause = " "
                    drvc("MWDTclause") = .MWDTclause
                    drvc("CreepRange") = .CreepRange
                    drvc("MWDTtemp") = .MWDTtemp
                    drvc("PNumber") = .PNumber
                    If Len(.Group) = 0 Then .Group = "0"
                    drvc("GroupNb") = Left(.Group, c.Columns("GroupNb").MaxLength)
                    drvc.EndEdit()
                    For l = 1 To NumSerieValori
                        If Not IsDBNull(drvc(13 + l)) Then
                            If CInt(drvc(13 + l)) > 0 Then
                                iFoundV = dvV.Find(drvc(13 + l))
                                NoMatch = iFoundV < 0
                            End If
                        Else
                            NoMatch = True
                        End If
                        If NoMatch Then
                            drvV = dvV.AddNew()
                            Nuovo = True
                        Else
                            drvV = dvV(iFoundV)
                            drvV.BeginEdit()
                            Nuovo = False
                        End If
                        For mm = 1 To 24
                            Select Case l
                                Case 1
                                    drvV(mm) = .Temp.Item(mm).TextData
                                Case 2
                                    drvV(mm) = .Ammiss.Item(mm).TextData
                                Case 3
                                    drvV(mm) = .TempY.Item(mm).TextData
                                Case 4
                                    drvV(mm) = .AlfaT.Item(mm).TextData
                                Case 5
                                    drvV(mm) = .TempU.Item(mm).TextData
                                Case 6
                                    drvV(mm) = .Ustrength.Item(mm).TextData
                            End Select
                        Next mm
                        drvV.EndEdit()
                        If Nuovo Then 'l'unico giusto
                            cmdV.Update(V)
                            V = New DataTable
                            cmdV.Fill(V)
                            dvV = New DataView(V)
                            dvV.Sort = "ID"
                            drvV = dvV(V.Rows.Count - 1)
                            drvc.BeginEdit()
                            drvc(13 + l) = drvV("ID")
                            drvc.EndEdit()
                        End If
                    Next l
                End With
Cont:       Next
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
            Exit Sub
        End Try
        Try
            cmd.Update(r)
            custCB.Dispose()
            cmd.Dispose()
            cmdc.Update(c)
            custCBc.Dispose()
            cmdc.Dispose()
            cmdV.Update(V)
            custCBV.Dispose()
            cmdV.Dispose()
            dvr.Dispose()
            r.Dispose()
            dvc.Dispose()
            c.Dispose()
            dvV.Dispose()
            V.Dispose()
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try

    End Sub
    Public Sub New()
        MyBase.New()
        MatStr = ""
        Composiz = ""
        Product = ""
        AlloyUNS = ""
        Spec = ""
        Grado = ""
        ClassTemper = ""
        Dimensions = ""
        Caract = New LinkListCarattNew
        Ind = New LinkListSh
        Dim Car1 As New CarattMatNew
        Dim Car2 As New CarattMatNew
        Dim Car3 As New CarattMatNew
        Dim Car4 As New CarattMatNew
        Caract.Add(Car1)
        Caract.Add(Car2)
        Caract.Add(Car3)
        Caract.Add(Car4)
        AlfaYoung = New clsAlfaYoung
    End Sub
    Public Sub Scelta(ByVal Clas As ClasseMateriale, Optional ByRef Arch As String = "", Optional ByRef DiscoT As String = "", Optional ByRef x As Single = 0, Optional ByRef y As Single = 0)
        If Len(Arch) > 0 Then Archdir = Arch
        If Len(DiscoT) > 0 Then DiscoTem = DiscoT
        Dim Mat As New clsMat
        FormMat.Add(Mat) 'frmMaterP
        With Mat
            .MatCompos = Nothing
            .Compos = 0 ' False
            .MatSolo = Me
            If Not Clas = ClasseMateriale.NonDef Then .MatSolo.Classe = Clas
            .Editato = 0 'False
        End With
        If prAgganciato Then
            Dim frmMaterP As frmMater
            frmMaterP = New frmMater
            Mat.frm = frmMaterP
            frmMaterP.Mat = Mat
            With frmMaterP
                .Frame3D2.Visible = False
                .Frame3D3.Visible = False
                If FormMat.Count() > 1 Then
                    ._cmdEdit_0.Visible = False
                    ._cmdEdit_1.Visible = False
                    ._cmdEdit_2.Visible = False
                    ._cmdEdit_3.Visible = False
                    .cmdStampaListino.Visible = False
                    .cmdLE.Visible = False
                End If
            End With
            If x > 0 And y > 0 Then
                frmMaterP.Left = CInt(x) ' CInt(Funzioni.TwipsToPixelsX(x))
                frmMaterP.Top = CInt(y) ' CInt(Funzioni.TwipsToPixelsY(y))
            End If
            frmMaterP.ShowDialog()
        Else
            Scheda = New frmScheda
            If x > 0 And y > 0 Then
                Scheda.Left = CInt(x) ' CInt(Funzioni.TwipsToPixelsX(x))
                Scheda.Top = CInt(y) ' CInt(Funzioni.TwipsToPixelsY(y))
            End If
            Scheda.consult = False
            Scheda.ShowDialog()
            FormMat.remove(FormMat.Count)
        End If
    End Sub
    Public Function Avalor(ByRef DzSuT As Single, ByRef LSuDZ As Single) As Single
        On Error GoTo ErrAval
        Dim Tabella(23) As Single
        Dim XLSuD(52) As Single
        Dim i, j As Short
        Dim Table As New DataTable
        Dim RdK3, RdK1, RdK2, RdK4 As Single
        Dim B1, A1, c1 As Single
        Dim b2, a2, c2 As Single
        'idat = FreeFile
        '2220 Open RTrim$(Archdir) + "\CH\AB.DAT" For Random Shared As #idat Len = Len(ReadK3)
        If Not IniziaBase() Then Exit Function
        Dim cmd As OleDbDataAdapter = New OleDbDataAdapter("SELECT * FROM AB", MatBase)
        cmd.Fill(Table)
        '        Table.Index = "PrimaryKey"
        For i = 0 To 23
            Tabella(i) = CSng(Table.Rows(0)(i + 1))
            If Tabella(i) > DzSuT Then GoTo 5100
        Next i
        i = CShort(i - 1)
5100:   If i = 0 Or Tabella(i) <= DzSuT Then
            '      PRINT "WARNING !!!  (Do/t) RATIO OUT OF GEOMETRIC CHART RANGE"
            Avalor = -1
            Table.Dispose() 'Close #idat
            Exit Function
        End If
        A1 = Tabella(i - 1)
        a2 = Tabella(i)
        'Get #idat, 2, ReadK3
        For j = 0 To 52
            XLSuD(j) = CSng(Table.Rows(1)(j + 1))
            If XLSuD(j) > LSuDZ Then GoTo 5230
        Next j
        j = CShort(j - 1)
5230:   If j = 0 And LSuDZ <= 0 Then
            '9160      PRINT "WARNING !!!  (L/Do) RATIO OUT OF GEOMETRIC CHART RANGE"
            Avalor = -2
            Table.Dispose() 'Close #idat
            Exit Function
        End If
        If j = 0 Then j = 1
        B1 = XLSuD(j - 1)
        b2 = XLSuD(j)
        Dim dvTable As DataView = New DataView(Table)
        dvTable.Sort = "ID"
        Dim iFound As Integer = dvTable.Find(i + 3)
        'Get #idat, (i + 3), ReadK3
        RdK3 = CSng(dvTable(iFound)(j))
        RdK4 = CSng(dvTable(iFound)(j + 1))
        If b2 = LSuDZ Then c2 = RdK4 : GoTo 5340 'era <=
        If RdK3 = 0 Then c2 = 0 : GoTo 5340
        If LSuDZ = B1 Then c2 = RdK3 : GoTo 5340
        If RdK4 = 0 Then c2 = 0 : GoTo 5340
        'c2 = 2.718282 ^ (LOG(ReadK3) + LOG(ReadK4 / ReadK3) * LOG(LSuDz / b1) / LOG(b2 / b1))
        c2 = Funzioni.InterLogar(LSuDZ, B1, b2, RdK3, RdK4)
5340:   If i = 0 Then Table.Dispose() : Avalor = c2 : Exit Function
        iFound = dvTable.Find(i + 2)
        'Get #idat, (i + 2), ReadK3
        RdK1 = CSng(dvTable(iFound)(j))
        RdK2 = CSng(dvTable(iFound)(j + 1))
        If b2 = LSuDZ Then c1 = RdK4 : GoTo 5440 'era <=
        If RdK1 = 0 Then c1 = 0 : GoTo 5440
        If LSuDZ = B1 Then c1 = RdK1 : GoTo 5440
        If RdK2 = 0 Then c1 = 0 : GoTo 5440
        'c1 = 2.718282 ^ (LOG(ReadK1) + LOG(ReadK2 / ReadK1) * LOG(LSuDz / b1) / LOG(b2 / b1))
        c1 = Funzioni.InterLogar(LSuDZ, B1, b2, RdK1, RdK2)
5440:   If c1 = 0 And c2 = 0 Then
            '       PRINT "WARNING !!!  (L/Do) RATIO OUT OF GEOMETRIC CHART RANGE"
            Avalor = 0.1
            Table.Dispose() 'Close #idat
            Exit Function
        End If
5450:   If c1 > 0 And c2 > 0 Then
            Avalor = c1 + (c2 - c1) * (DzSuT - A1) / (a2 - A1) : Table.Dispose() : Exit Function
        End If
        If c1 = 0 And DzSuT = a2 Then Table.Dispose() : Avalor = c2 : Exit Function
        If DzSuT = A1 Then Table.Dispose() : Avalor = c1 : Exit Function
        '    PRINT "WARNING !!!  (L/Do) RATIO OUT OF GEOMETRIC CHART RANGE"
        Table.Dispose()
        '     Avalor = -3
        Avalor = 0.1
        Exit Function
ErrAval: MsgBox("Avalor " & Err.Description & Str(Erl()))
    End Function
    Public Function Yield() As Single
        Dim i As Short
        For i = 1 To CShort(Caract.Count)
            Select Case Caract.Item(i).TextData.Codice
                Case Codes.div1psi, Codes.div2psi, Codes.BSpsi '1, 6
                    Yield = Caract.Item(i).TextData.Yield * clsTrigon.MPA
                    Exit For
                Case Else '2, 7, 8
                    Yield = Caract.Item(i).TextData.Yield
                    Exit For
            End Select
        Next
    End Function
    Public Function BValor(ByVal Ainp As Single, ByVal Temp As Single, ByVal matind As Short, ByRef Codice As Codes, ByRef Chart As String, ByVal Mode As Short) As Single
        Dim i As Short
        Dim YieldM As Single
        Dim Testa As DataTable
        Dim Tabella As DataTable
        Dim BBout, Bout As Single
        Dim nchart As Short
        Dim Res As Boolean
        Dim iTemp As Short
        Dim Trova, Trovaa As Boolean
        Dim A0, AA0 As Single
        Dim B0, BB0 As Single
        Dim AA1, A1, B1, BB1 As Single
        Dim cmd As OleDbDataAdapter
        If Not IniziaBase() Then Exit Function
        Temp = CSng(Temp * 1.8 + 32)
        'Mode 0 funzione diretta B=f(A)  1 funzione inversa A=f(B)
        'codici di errore
        '      -1 codice di calcolo non ASME imperiali
        '      -2 materiale senza dati ASME imperiali
        '      -3 chart non definita
        '      -4 chart non caricata
        '      -5 temperatura superiore al massimo
        '      -6 snervamento superiore al massimo
        '      -7 chart non valida (formato) nel corpo dati
        '      -8 chart non valida (formato) nell'intestazione
        '      -9 Ainp troppo piccolo
        '     -10 Ainp troppo grande
        '     -11 Errore file
        '     -14 funzione inversa, B<=0
        Try
            If Ainp < 0 Then Bout = Ainp - 20 : GoTo 300
            If Not (Codice = Codes.div1MPa Or Codice = Codes.div1psi Or Codice = Codes.div2MPa Or Codice = Codes.div2psi) Then Bout = -1 : GoTo 300
            For i = 1 To CShort(Caract.Count)
                If Caract.Item(i).TextData.Codice = Codice Then
                    nchart = Caract.Item(i).TextData.IndChart
                    YieldM = Caract.Item(i).TextData.Yield
                    GoTo Cont1
                End If
            Next
            Bout = -2 : GoTo 300
Cont1:
            If Mode = 1 Then Ainp = Ainp * clsTrigon.psi
            If nchart = 3 And Temp > 300 Then nchart = 2
            If nchart = 0 Then Bout = -3 : GoTo 300
            If Not GiaCaricatiValori Then
                Tabella = New DataTable
                Testa = New DataTable
                Valori = New DataTable
                ReDim Temper(9), Yielder(9), Younger(9)
                cmd = New OleDbDataAdapter("SELECT * from DirectCH WHERE ID=" & Str(nchart), MatBase)
                cmd.Fill(Tabella)
                If CStr(Tabella.Rows(0)("Descrizione")) = "Assente" Then Bout = -4 : GoTo 300
                Chart = CStr(Tabella.Rows(0)("Descrizione"))
                cmd = New OleDbDataAdapter("SELECT * FROM " & CStr(Tabella.Rows(0)("tabTesta")), MatBase)
                cmd.Fill(Testa)
                cmd = New OleDbDataAdapter("SELECT * FROM " & CStr(Tabella.Rows(0)("tabDati")), MatBase)
                cmd.Fill(Valori)
                For iTemp = 1 To 9
                    Temper(iTemp) = Funzioni.ValVir(CStr(Testa.Rows(0)(iTemp + 1)))
                Next
                For iTemp = 1 To 9
                    Younger(iTemp) = Funzioni.ValVir(CStr(Testa.Rows(1)(iTemp + 1)))
                Next
                For iTemp = 1 To 9
                    Yielder(iTemp) = Funzioni.ValVir(CStr(Testa.Rows(2)(iTemp + 1)))
                Next
                Testa.Dispose()
                Tabella.Dispose()
                GiaCaricatiValori = True
            End If
            For iTemp = 1 To 9
                If Temper(iTemp) >= Temp Then GoTo Cont2
            Next
            For iTemp = 1 To 9
                If Temper(iTemp) = 0 Then Exit For
            Next
            iTemp = CShort(iTemp - 1)
Cont2:
            Trova = False : Trovaa = False
            If Yielder(1) = 0 Then
                'funzione della temperatura
            Else
                'funzione dello snervamento
                For iTemp = 1 To 9
                    If Yielder(iTemp) >= YieldM Then GoTo Cont3
                Next
                Bout = -6 : GoTo 300
Cont3:
            End If
            Trova = False
            For i = 0 To CShort(Valori.Rows.Count - 1)
                A0 = CSng(Valori.Rows(i)(iTemp * 2 - 1))
                B0 = CSng(Valori.Rows(i)(iTemp * 2))
                If Mode = 1 Then Funzioni.SWAP(A0, B0)
                If i < Valori.Rows.Count - 1 Then
                    A1 = CSng(Valori.Rows(i + 1)(iTemp * 2 - 1))
                    B1 = CSng(Valori.Rows(i + 1)(iTemp * 2))
                    If Mode = 1 Then Funzioni.SWAP(A1, B1)
                End If
                If Trova Then Exit For
                If A1 = 0 Or i = Valori.Rows.Count - 1 Then
                    i = CShort(i - 2)
                    Trova = True
                Else
                    If A0 <= Ainp And A1 > Ainp Or Ainp <= A0 Then Exit For
                End If
            Next i
            If Not iTemp = 1 Then
                i = 0
                Trova = False
                Do
                    AA0 = CSng(Valori.Rows(i)((iTemp - 1) * 2 - 1))
                    BB0 = CSng(Valori.Rows(i)((iTemp - 1) * 2))
                    If Mode = 1 Then Funzioni.SWAP(AA0, BB0)
                    i = CShort(i + 1)
                    If i < Valori.Rows.Count - 1 Then
                        AA1 = CSng(Valori.Rows(i)((iTemp - 1) * 2 - 1))
                        BB1 = CSng(Valori.Rows(i)((iTemp - 1) * 2))
                        If Mode = 1 Then Funzioni.SWAP(AA1, BB1)
                    End If
                    If Trova Then Exit Do
                    If AA1 = 0 Or i = Valori.Rows.Count - 1 Then
                        i = CShort(i - 2)
                        Trova = True
                    Else
                        If AA0 <= Ainp And AA1 > Ainp Or Ainp <= AA0 Then Exit Do
                    End If
                Loop
            End If
            Valori.Dispose()
            '-----------------------------------------------------
            'Interpolazione su quadrupletta A0,A,B0,B,AA0,AA,BB0,BB
            If A0 = 0 Or (AA0 = 0 And iTemp > 1) Then GoTo 300
            Bout = Funzioni.InterLogar(Ainp, A0, A1, B0, B1)
            If iTemp > 1 Then
                BBout = Funzioni.InterLogar(Ainp, AA0, AA1, BB0, BB1)
                If Yielder(1) = 0 Then
                    Bout = Bout + (Temp - Temper(iTemp)) * (BBout - Bout) / (Temper(iTemp - 1) - Temper(iTemp))
                Else
                    Bout = Bout + (YieldM - Yielder(iTemp)) * (BBout - Bout) / (Yielder(iTemp - 1) - Yielder(iTemp))
                End If
            End If
300:        If Bout <= 0 Then
                If Not Ainp = 10.0! Then
                    Res = DiagnB(Ainp, Bout)
                    Bout = -Bout
                    If Not Res Then Bout = 0
                Else
                    Bout = 0
                End If
            End If
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
        If Mode = 0 Then BValor = Bout * clsTrigon.MPA Else BValor = Bout
    End Function
    Public Function DiagnB(ByRef Ainp As Single, ByRef psig As Single, Optional ByRef testo As String = "", Optional ByRef Arch As String = "") As Boolean
        Dim Stringa5(2) As String
        Dim Ris5(2) As String
        Dim Riga2, Riga As String
        Dim Riga1 As String = ""
        Dim iErr, iHelp, i As Integer
        DiagnB = True
        iHelp = 1000
        '        ifl = FreeFile()
        '       If Len(Archdir) = 0 And Not Arch = "" Then Archdir = Arch
        '      FileOpen(ifl, Archdir.Trim & "\ASME7.DAT", OpenMode.Input, , OpenShare.Shared)
        Riga = rmHelpStrings.GetString(iHelp.ToString) : iHelp += 1 ' LineInput(ifl)
        If Not testo = "" Then Riga = testo + vbCrLf
        iErr = CInt(-psig + 0.0001)
        If iErr < 0 Or iErr > 22 Then iErr = 13
        If iErr > 14 And iErr < 21 Then iErr = 13
        If iErr > 14 Then iErr = iErr - 10
        If iErr = 2 And Indmat = 0 Then iErr = 0
        For i = 0 To 14
            Riga2 = rmHelpStrings.GetString(iHelp.ToString) : iHelp += 1 ' LineInput(ifl)
            If i = iErr Then
                Riga1 = Riga2
                If i >= 2 And i < 8 Then
                    Riga1 = Funzioni.FormatS(Riga1, Trim(MatStr))
                    Exit For
                End If
            End If
        Next
        Stringa5(1) = rmHelpStrings.GetString(iHelp.ToString) : iHelp += 1 ' LineInput(ifl)
        Stringa5(2) = rmHelpStrings.GetString(iHelp.ToString) : iHelp += 1 ' LineInput(ifl)
        Ris5(2) = rmHelpStrings.GetString(iHelp.ToString) : iHelp += 1 ' LineInput(ifl)
        Riga = Riga & Riga1
        If Ainp > 0 Then Riga = Riga & vbCrLf & "( A =" & Str(Ainp) & ")"
        Riga1 = rmHelpStrings.GetString(iHelp.ToString) : iHelp += 1 ' LineInput(ifl)
        Riga = Riga & Riga1
        If MsgBox(Monitor.Motore.Inizio.ConvertiCr(Riga), MsgBoxStyle.OKCancel, "Calcolo a pressione esterna") = MsgBoxResult.Cancel Then
            'FileClose(ifl)
            DiagnB = False
            Exit Function
        End If
        Ris5(1) = ""
        Stringa5(1) = Stringa5(1) & Str(Ainp)
        'FileClose(ifl)
        If Ainp = -1 Then Exit Function
        Try
            psig = Funzioni.ValVir(InputBox(Stringa5(2), Stringa5(1), Ris5(2)))
        Catch
            psig = 0
        End Try
    End Function
    Public Sub MostraPrezzi(Optional ByRef LireKg As Single = 0, Optional ByRef Unit As Short = 0, _
                            Optional ByRef inum As Short = 0, Optional ByRef pID As Integer = 0, _
                            Optional ByRef Code As Short = 0, Optional ByRef Param As Single = 0, _
                            Optional ByRef Param2 As Single = 0)
        Dim sMat As clsMat
        Dim linum, k As Short
        Dim Table As New DataTable
        Dim tableparam As New DataTable
        If Monitor Is Nothing Then Exit Sub
        '0 mostra tutte le unità
        '1 mostra L/Kg lordo
        '2 mostra unità alternativa
        If Classe = ClasseMateriale.Varie Then Exit Sub
        Try
            If Indmat = 0 And Classe < 11 Then Exit Sub
            If FormMat.Count() = 0 Then
                sMat = New clsMat
                sMat.MatSolo = Me
                FormMat.Add(sMat)
            End If
            FormPrezzi = New frmprz
            FormPrezzi.Unit = Unit
            k = CShort(SubClasse(Classe, Param, Code, inum))
            If inum > 0 Then
                linum = inum
                If Classe = ClasseMateriale.Fucinati Then
                    Dim cmd As OleDbDataAdapter = New OleDbDataAdapter("SELECT * FROM Classi WHERE Codice=" & Str(Classe), MatBase)
                    cmd.Fill(Table)
                    cmd = New OleDbDataAdapter("SELECT * FROM " + CStr(Table.Rows(0)("tabParametri")) + " ORDER BY Ordine", MatBase)
                    cmd.Fill(tableparam)
                    Dim dvtableparam As DataView = New DataView(tableparam)
                    dvtableparam.Sort = "Codice"
                    Dim iFound As Integer = dvtableparam.Find(Code)
                    linum = CShort(linum + CInt(dvtableparam(iFound)("Ordine")) - 1)
                    dvtableparam.Dispose()
                    tableparam.Dispose()
                    Table.Dispose()
                End If
                FormPrezzi.BackColor = System.Drawing.ColorTranslator.FromOle(&H80C0FF)
            End If
            If linum = 0 Then linum = 1
            FormPrezzi.linum = linum
            SubClasse2(Classe, Param2, FormPrezzi.linum2)
            FormPrezzi.Inizializza()
            FormPrezzi.ShowDialog() 'eless
            Unit = FormPrezzi.Unit
            LireKg = Funzioni.ValVir(FormPrezzi.ttPrezzo(CShort(linum - 1)).Text)
            If IsDBNull(iflpd(linum)("ID")) Then
                pID = 0
            Else
                pID = CInt(iflpd(linum)("ID"))
            End If
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
        FormPrezzi.Close()
        FormPrezzi.Dispose()
        If FormMat.Count() > 1 Then FormMat.remove(FormMat.Count())
    End Sub
    Public Function prezzo(ByVal Param As Single, ByVal Classe As ClasseMateriale, _
                                    ByVal Arch As String, ByVal DiscoT As String, _
                                    ByVal Code As Short, Optional ByRef Unit As Short = 0, _
                                    Optional ByVal Param2 As Single = 0, Optional ByRef pID As Integer = 0) As Single
        Dim k, k2 As Single
        Dim iflp As New DataTable
        Dim inum As Short
        Dim iFound As Integer
        Dim Filtro As String
        Dim Sotto As Single, Sopra As Single
        Archdir = Arch
        DiscoTem = DiscoT
        If Classe = ClasseMateriale.NonDef Then Exit Function
        If Indmat < 1 Then Exit Function
        If Not IniziaBase() Then Exit Function
        Try
            ParametriPrezzo(Classe)
            Dim cmd As OleDbDataAdapter = New OleDbDataAdapter("SELECT * FROM " + CStr(tbClassi.Rows(0)("tabClasPr")) + " WHERE IdMat = " + Str(Indmat), MatBase)
            cmd.Fill(iflp)
            Dim dviflp As DataView = New DataView(iflp)
            k = SubClasse(Classe, Param, Code, inum, Sotto, Sopra)
            If Classe = ClasseMateriale.TubiScambio Then
                Filtro = "Parametro>" & Funzioni.ConvertiVirgola(Sotto.ToString) & " AND Parametro<" & Funzioni.ConvertiVirgola(Sopra.ToString)
            Else
                If k < 1 Then k = 1
                Filtro = "Parametro=" & Funzioni.ConvertiVirgola(k.ToString)
            End If
            If Classe = ClasseMateriale.Fucinati And Code > 0 Then
                Filtro = Filtro & " AND Codice=" & Code.ToString
            End If
            If NumParamSc > 0 Then
                k2 = SubClasse2(Classe, Param2, , Sotto, Sopra)
                If Classe = ClasseMateriale.TubiScambio Then
                    Filtro = Filtro & " AND Parametro2>" & Funzioni.ConvertiVirgola(Sotto.ToString) & " AND Parametro2<" & Funzioni.ConvertiVirgola(Sopra.ToString)
                Else
                    Filtro = Filtro & " AND Parametro2=" & Funzioni.ConvertiVirgola(k2.ToString)
                End If
            End If
            dviflp.RowFilter = Filtro
            If dviflp.Count = 1 Then
                If Unit = 2 Then
                    prezzo = CSng(dviflp(0)("PrezzoAlt")) ' p.prezzo(k)
                Else
                    prezzo = CSng(dviflp(0)("prezzolkg")) ' p.prezzo(k)
                End If
                pID = CInt(dviflp(0)("ID"))
            Else
                If pID > 0 Then
                    dviflp.Sort = "ID"
                    iFound = dviflp.Find(pID)
                    If iFound = -1 Then
                        MostraPrezzi(prezzo, Unit, inum, pID, Code)
                    Else
                        If Unit = 2 Then
                            prezzo = CSng(dviflp(iFound)("PrezzoAlt")) ' p.prezzo(k)
                        Else
                            prezzo = CSng(dviflp(iFound)("prezzolkg")) ' p.prezzo(k)
                        End If
                        'pID = CInt(dviflp(iFound)("ID"))
                    End If
                Else
                    MostraPrezzi(prezzo, Unit, inum, pID, Code)
                End If
            End If
            dviflp.Dispose()
            iflp.Dispose()
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Function
    Public Property Zitto() As Boolean
        Get
            Zitto = Silente
        End Get
        Set(ByVal Value As Boolean)
            Silente = Value
        End Set
    End Property
    Public Function SigmaTheta(ByRef Codice As Short, Optional ByRef Tempdes As Single = 0, Optional ByRef Gruppo As String = "") As Single
        Dim i As Short
        Dim Ya, Yo As Single
        Select Case Codice
            Case 1, 6 'ASME
            Case 8 'EuroNorm
                For i = 1 To CShort(Caract.Count)
                    If Caract.Item(i).TextData.Codice = Codice Then
                        If Not Gruppo = "" Then
                            Gruppo = Trim(Caract.Item(i).TextData.Group)
                            Exit Function
                        End If
                        Select Case Trim(Caract.Item(i).TextData.Group)
                            Case "6.2"
                                Call LeggiMat(Codice, Tempdes, Ya, Yo, 1)
                                SigmaTheta = Yo
                            Case "6.3", "6.4"
                                Call LeggiMat(Codice, Tempdes, Ya, Yo, 1)
                                SigmaTheta = CSng(Yo / 1.3 / 1.25)
                            Case "" : Call Aler2() : Exit Function
                            Case Else
                                Call Aler3(Trim(Caract.Item(i).TextData.Group)) : Exit Function
                        End Select
                        Exit Function
                    End If
                Next
                Call Aler(0, Codice)
        End Select
    End Function
    Public Sub SigmaAmm(ByRef Codice As Short, ByVal Tempdes As Single, ByRef Sfa As Single, ByRef Sfo As Single, Optional ByRef ftest As Single = 0)
        Dim Ua, Ya, Yo, Uo As Single
        Dim codi As Codes
        Dim i As Short
        codi = CType(Math.Abs(Codice), Codes)
        Select Case codi
            Case Codes.div1psi, Codes.div2psi, Codes.div1MPa, Codes.div2MPa 'ASME
                Call LeggiMat(Codice, Tempdes, Sfa, Sfo, 1)
            Case Codes.EU  'EuroNorm
                For i = 1 To CShort(Caract.Count)
                    If Caract.Item(i).TextData.Codice = Codice Then
                        Call LeggiMat(Codice, Tempdes, Ya, Yo, 1)
                        Call LeggiMat(Codice, Tempdes, Ua, Uo, 2)
                        Ua = Caract.Item(i).TextData.US
                        Ya = Caract.Item(i).TextData.Yield
                        Select Case Trim(Caract.Item(i).TextData.Group)
                            Case "6.2"
                                Sfa = CSng(Ya / 1.5) : If Ua / 2.4 < Sfa Then Sfa = CSng(Ua / 2.4)
                                Sfo = CSng(Yo / 1.5) : If Ua / 2.4 < Sfo Then Sfo = CSng(Ua / 2.4)
                                ftest = CSng(Ya / 1.05)
                            Case "6.3"
                                Sfa = CSng(Ya / 1.5)
                                Sfo = CSng(Yo / 1.5)
                                ftest = CSng(Ya / 1.05)
                            Case "6.4"
                                Sfa = CSng(Ya / 1.5)
                                Sfo = CSng(Yo / 1.5)
                                If Uo > 0 Then
                                    Sfo = Uo / 3 : If Yo / 1.2 < Sfo Then Sfo = CSng(Yo / 1.2)
                                End If
                                ftest = CSng(Ya / 1.05)
                                If Ua > 0 Then
                                    If Ua / 2 < ftest Then ftest = Ua / 2
                                End If
                            Case "Bolts"
                                Sfa = Ya / 3 : If Ua / 4 < Sfa Then Sfa = Ua / 4
                                Sfo = Yo / 3 : If Ua / 4 < Sfo Then Sfo = Ua / 4
                                ftest = CSng(Sfa * 1.5)
                            Case "BolAu"
                                Sfa = Ua / 4
                                Sfo = Uo / 4
                                ftest = CSng(Sfa * 1.5)
                            Case "6.5"
                                MsgBox("Classe 6.5 non prevista ")
                            Case "" : Call Aler2() : Exit Sub
                            Case Else
                                Call Aler3(Trim(Caract.Item(i).TextData.Group)) : Exit Sub
                        End Select
                        Exit Sub
                    End If
                Next
                Call Aler(0, Codice)
                Sfa = 0 : Sfo = 0
        End Select
    End Sub
    Public Sub YieldTemp(ByRef Codice As Short, ByRef Tempdes As Single, ByRef Sfa As Single, ByRef Sfo As Single)
        Call LeggiMat(Codice, Tempdes, Sfa, Sfo, 2)
    End Sub
    Public Sub LeggiMat(ByRef Codi As Short, ByVal Tempdes As Single, ByRef Sfa As Single, ByRef Sfo As Single, ByRef Mode As Short)
        'Dim Stringa5(9) As String, ifl As Integer
        Dim Codice As Codes
        Dim i, j As Short
        Dim TempAct, TempAct1 As Single
        Dim testo As String
        Dim Snerv, SfaSav As Single
        Dim psig As Single
        Dim Chart As String = ""
        Dim qualche As Boolean
        Dim Description As String
        Dim Number, Line As Integer, IDH As Integer
        Dim Gia As Boolean = False
        On Error GoTo ErrLM
        If Codi = 0 Then Codi = 1
        If Indmat = 0 And Agganciato Then
            If Not Silente Then Monitor.Motore.MostraAiuto(IDHS.IDH_ERR_LIBMAT_NOINDMAT, , , Monitor.Motore.HelpStringaG("TitLibmat"))
            Exit Sub
        End If
        Sfo = 0 : qualche = False
        Codice = CType(System.Math.Abs(Codi), Codes)
        'If Mode = 2 And Codice = 6 Then Codice = 1
        'Mode=1 tensione ammissibile,Mode=2 Yield
        If Codice = Codes.div1psi Or Codice = Codes.div2psi Then Tempdes = CSng(1.8 * Tempdes + 32)
nuovo:  For i = 1 To CShort(Caract.Count)
            With Caract.Item(i).TextData
                If Caract.Item(i).TextData.Codice = Codice Then
                    If Mode = 1 Then
                        Sfa = .Ammiss.Item(1).TextData
                    Else
                        Sfa = .AlfaT.Item(1).TextData
                    End If
                    If SfaSav > 0 Then Sfa = SfaSav
                    For j = 1 To 24
                        TempAct = .Temp.Item(j).TextData
                        If Mode = 2 Then TempAct = .TempY.Item(j).TextData
                        If TempAct > 0 Then qualche = True
                        If TempAct >= Tempdes Then
                            If Mode = 1 Then
                                If j > 1 Then
                                    TempAct1 = .Temp.Item(j - 1).TextData
                                    Sfo = .Ammiss.Item(j - 1).TextData
                                    Sfo = Sfo + (.Ammiss.Item(j).TextData - .Ammiss.Item(j - 1).TextData) / (TempAct - TempAct1) * (Tempdes - TempAct1)
                                Else
                                    Sfo = .Ammiss.Item(1).TextData
                                End If
                                GoTo ExitFor
                            Else
                                If j > 1 Then
                                    TempAct1 = .TempY.Item(j - 1).TextData
                                    Sfo = .AlfaT.Item(j - 1).TextData
                                    Sfo = Sfo + (.AlfaT.Item(j).TextData - .AlfaT.Item(j - 1).TextData) / (TempAct - TempAct1) * (Tempdes - TempAct1)
                                Else
                                    Sfo = .AlfaT.Item(1).TextData
                                End If
                                GoTo ExitFor
                            End If
                        ElseIf TempAct = 0 And j > 1 And qualche And Mode = 1 Then
                            TempAct = .Temp.Item(j - 1).TextData
                            Sfo = .Ammiss.Item(j - 1).TextData
                            If Aler1(Tempdes, Mode, Codice, Sfa, SfaSav) = 1 Then GoTo nuovo
                            GoTo ExitFor
                        ElseIf TempAct = 0 And j > 1 And qualche And Mode = 2 Then
                            TempAct = .TempY.Item(j - 1).TextData
                            Sfo = .AlfaT.Item(j - 1).TextData
                            If Aler1(Tempdes, Mode, Codice, Sfa, SfaSav) = 1 Then GoTo nuovo
                            GoTo ExitFor
                        End If
                    Next
                End If
            End With
        Next
        If TempAct = 0 Then
            If Not Gia Then
                RecupMat()
                Gia = True
                GoTo nuovo
            End If
            If Mode = 2 Then GoTo ExitFor
            If Codi = -6 And Codice > Codes.div1psi Then
                Codice = Codes.div1psi
                GoTo nuovo
            Else
                Call Aler(Mode, Codice)
            End If
        Else
            If Codi = -6 And Codice > Codes.div1psi Then
                Codice = Codes.div1psi
                GoTo nuovo
            Else
                If Aler1(Tempdes, Mode, Codice, Sfa, SfaSav) = 1 Then GoTo nuovo
            End If
        End If
ExitFor:
        If Mode = 2 And Indmat > 0 And Sfo = 0 And _
        (Codice = Codes.div1psi Or Codice = Codes.div2psi Or Codice = Codes.div1MPa Or Codice = Codes.div2MPa) Then
            'calcolo di Sy attraverso le curve per il buckling
            psig = System.Math.Abs(BValor(10.0!, Tempdes, Indmat, Codice, Chart, 0))
            If psig = -11 Or psig = 0 Then
                Call Aler(Mode, Codice)
                Exit Sub
            End If
            If psig > 0 Then Sfo = 2 * psig Else Sfo = 0
            psig = System.Math.Abs(BValor(10.0!, 20.0!, Indmat, Codice, Chart, 0))
            If psig > 0 Then Sfa = 2 * psig Else Sfa = 0
            'If Codice = Codes.div1MPa Or Codice = Codes.BSMPa Or Codice = Codes.div2MPa Then Sfa = Sfa / clsTrigon.MPA : Sfo = Sfo / clsTrigon.MPA
            'questo perché le curve di buckling sono (per orea) sempre in psi
        End If
        If Codice = Codes.div1psi Or Codice = Codes.BSpsi Or Codice = Codes.div2psi Then Sfa = Sfa * clsTrigon.MPA : Sfo = Sfo * clsTrigon.MPA
        If Sfo = 0 And TempAct > 0 Then
360:        If Codi = -6 And Codice > Codes.div1psi Then
                Codice = Codes.div1psi
                GoTo nuovo
            Else
                Call Aler(Mode, Codice)
            End If
        End If
361:    Exit Sub
ResErrLM:
        IDH = IDHS.IDH_ERR_LIBMAT_IMPREV1
        If Err.Number = 63 And Erl() = 350 Then IDH = IDHS.IDH_ERR_LIBMAT_IMPREV2
        Monitor.Motore.MostraAiuto2(IDHS.IDH_ERR_LIBMAT_IMPREV1, _
        CType(ChiaviMess.MessCritical + ChiaviMess.MessOkOnly + ChiaviMess.MessHelpButton, ChiaviMess), _
        "", Number.ToString, Description.Trim, Number.ToString)
        Exit Sub
ErrLM:
        Description = Err.Description
        Number = Err.Number
        Line = Erl()
        Resume ResErrLM
    End Sub
    Private Sub Aler(ByVal Mode As Integer, ByVal Codice As Integer)
        Dim Table As DataTable
        Dim testo As String
        Dim IDH As Integer
        If Indmat = 0 Or Silente Then Exit Sub
        Table = New DataTable
        Try
            If Not IniziaBase() Then Exit Sub
            Dim cmd As OleDbDataAdapter = New OleDbDataAdapter("SELECT * FROM Codici WHERE Codice=" + Codice.ToString, MatBase)
            Table = New DataTable
            cmd.Fill(Table)
            If Mode <= 1 Then IDH = IDHS.IDH_ERR_LIBMAT_NOVALOR1 Else IDH = IDHS.IDH_ERR_LIBMAT_NOVALOR2
            Funzioni.FormatS("non|")
            testo = CStr(Table.Rows(0)("Descrizione")) 'Stringa5(1) + Space$(1) ' "ATTENZIONE| Volori per "
            testo = Funzioni.FormatS(Monitor.Motore.HelpStringaG(IDH), testo, MatStr.Trim)
            Table.Dispose()
            Monitor.Motore.MostraAiuto(IDH, _
            CType(ChiaviMess.MessInformation + ChiaviMess.MessOkOnly + ChiaviMess.MessHelpButton, ChiaviMess), _
            testo.Trim, Monitor.Motore.HelpStringaG("TitLibmat"))
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Private Function Aler1(ByRef Tempdes As Single, ByRef Mode As Short, ByRef Codice As Codes, _
        ByVal Sfa As Single, ByRef SfaSav As Single) As Integer
        Dim IDH As Integer
        If Silente Then Exit Function
        If Tempdes = m_TempDes Then Exit Function
        m_TempDes = Tempdes
        Funzioni.FormatS("non|")
        IDH = IDHS.IDH_ERR_LIBMAT_NODIV1
        If Mode = 2 Then IDH = IDHS.IDH_ERR_LIBMAT_NODIV1b
        If Codice = 6 And Mode <> 2 Then
            If Silente Then Exit Function
            IDH = IDHS.IDH_ERR_LIBMAT_NODIV1a
            If Monitor.Motore.MostraAiuto(-IDH, _
            CType(ChiaviMess.MessQuestion + ChiaviMess.MessYesNo + ChiaviMess.MessHelpButton, ChiaviMess), _
              MatStr.Trim, Monitor.Motore.HelpStringaG("TitLibmat")) = ChiaviMess.Messno Then Exit Function
            Codice = Codes.div1psi
            SfaSav = Sfa
            Return 1
        Else
            If Not Silente Then Monitor.Motore.MostraAiuto(-IDH, _
            CType(ChiaviMess.MessInformation + ChiaviMess.MessOkOnly + ChiaviMess.MessHelpButton, ChiaviMess), _
            MatStr.Trim, Monitor.Motore.HelpStringaG("TitLibmat"))
        End If
    End Function
    Public Function LegRat(ByRef TDes As Single, ByRef Rati As Short, ByRef MatGr As String, Optional ByRef Parla As Boolean = False) As Single
        Dim n As Short
        Dim iFound As Integer
        Dim File As String
        Dim Pmax As Single
        Dim Table As New DataTable
        Dim dvT As DataView
        Dim cmd As OleDbDataAdapter
        Try
            If Classe <> 7 Then Exit Function
            If MatGroup > 0 Then
                If Not IniziaBase() Then Exit Function
                cmd = New OleDbDataAdapter("SELECT * FROM Groupmt", MatBase)
                cmd.Fill(Table)
                dvT = New DataView(Table)
                dvT.Sort = "ID"
                iFound = dvT.Find(MatGroup)
                If iFound <= 0 Then
                    File = "non definito"
                    Exit Function
                Else
                    File = CStr(dvT(iFound)("Tabella"))
                    MatGr = CStr(dvT(iFound)("Nome"))
                End If
                Table.Dispose()
            Else
                If Parla Then
                    If Not Silente Then Monitor.Motore.MostraAiuto(-IDHS.IDH_ERR_LIBMAT_LEGRAT1, , MatStr.Trim, Monitor.Motore.HelpStringaG("TitLibmat"))
                End If
                Exit Function
            End If
            If Not File = "-1" And MatGroup > 0 Then
                n = CShort(NRat(Rati) - 2)
                Call LegTabella(File, n, CSng(TDes * 1.8 + 32), Pmax)
            Else
                Pmax = 0
                If Parla Then
                    If Not Silente Then Monitor.Motore.MostraAiuto(-IDHS.IDH_ERR_LIBMAT_LEGRAT2, , MatStr.Trim, Monitor.Motore.HelpStringaG("TitLibmat"))
                End If
            End If
            LegRat = Pmax * clsTrigon.MPA
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Function
    Public Function TrasfLegRat() As Single
        'Dim ifl1 As Integer, File As String, i As Integer, n As Integer, Riga As String
        'Dim Dummy As Recordset, Esiste As Boolean, k As Integer, l1 As Integer, l As Integer
        'Dim Pmax As Single, Table As Recordset, TableP As TableDef, TableN As Recordset
        'Dim pr As Single
        'On Local Error GoTo ErrLR
        '    IniziaBase
        '    Set Table = MatBase.OpenRecordset("SELECT * FROM Groupmt")
        '    Do Until Table.EOF
        '       Table.MoveNext
        '       File = Table!Tabella
        '       If Val(File) > -1 Then
        '          For Each TableP In MatBase.TableDefs
        '             If TableP.Name = File Then
        '                 Set TableN = MatBase.OpenRecordset("SELECT * FROM " + File)
        '                 Esiste = True
        '                 GoTo Apri
        '              End If
        '          Next
        '          DuplicaTabDef MatBase, "Pr1P0", File
        '          Set TableN = MatBase.OpenRecordset("SELECT * FROM " + File)
        '          Set Dummy = MatBase.OpenRecordset("SELECT * FROM Pr1p0")
        '          TableN.AddNew
        '          For i = 2 To TableN.Fields.Count - 1
        '             TableN(i) = Dummy(i)
        '          Next
        '          Dummy.Close
        '          TableN.Update
        'Apri:     ifl1 = FreeFile
        '          Open Archdir + "\" + File + ".DAT" For Input Shared As #ifl1
        '          For i = 1 To 5: Line Input #ifl1, Riga: Next
        '          If Esiste Then TableN.MoveNext
        '          Do
        '            If Esiste Then
        '            TableN.Edit
        '            Else
        '            TableN.AddNew
        '            End If
        '            Line Input #ifl1, Riga
        '            l1 = 5
        '            For k = 1 To 8
        '               l = InStr(l1, Riga$, "³") '?????????????????
        '               l1 = l + 1
        '               pr = Val(Mid$(Riga$, l1, 6))
        '               If k = 1 And pr = 0 Then Exit Do
        '               TableN(k) = pr
        '            Next
        '            TableN.Update
        '            If Esiste Then TableN.MoveNext
        '          Loop
        '       TableN.Close
        '       Close #ifl1
        '       End If
        '    Loop
        '    Table.Close ' #ifl1
        'Exit Function
        'ErrLR: MsgBox "TrasfLegRat " + Err.Description + Str(Erl)
        'Stop
        'Resume
    End Function
    Public Function NRat(ByRef rtg As Short) As Short
        Dim testo As String
        If rtg = 150 Then NRat = 3 : Exit Function
        If rtg = 300 Then NRat = 4 : Exit Function
        If rtg = 400 Then NRat = 5 : Exit Function
        If rtg = 600 Then NRat = 6 : Exit Function
        If rtg = 900 Then NRat = 7 : Exit Function
        If rtg = 1500 Then NRat = 8 : Exit Function
        If rtg = 2500 Then NRat = 9 : Exit Function
        If rtg <> 0 Then
            testo = " Avete definito un flange rating | inesistente:" & Str(rtg)
            MsgBox(Monitor.Motore.Inizio.ConvertiCr(testo), MsgBoxStyle.Critical)
            NRat = 0
        End If
    End Function
    Public Sub RecupMat(Optional ByRef Arch As String = "")
        Dim c As OleDbDataReader 'As New DataTable
        Dim V As OleDbDataReader 'As New DataTable
        'Dim r As New DataTable
        Dim r As OleDbDataReader
        Dim i, k, l As Short
        Dim VV As Single
        Dim testo As String
        Dim oc, occ, ocV As OleDbConnection
        If Len(Arch) > 0 Then Archdir = Arch
        Try
            If Indmat > 0 Then
                oc = OpenConn()
                'If Not IniziaBase() Then Exit Sub
                oc.Open()
                Dim command As OleDbCommand = New OleDbCommand("SELECT * FROM ListaMat WHERE Ind=" & Indmat.ToString, oc)
                'Dim cmd As OleDbDataAdapter = New OleDbDataAdapter("SELECT * FROM ListaMat WHERE Ind=" & Str(Indmat), MatBase)
                r = command.ExecuteReader
                'cmd.Fill(r)
                If Not r.HasRows Then
                    '    If r.Rows.Count < 1 Then
                    testo = "Si è tentato di recuperare dalla libreria" & vbCrLf
                    testo = testo & "materiali il materiale con indice" & Str(Indmat) & "." & vbCrLf
                    testo = testo & "Detto materiale non esiste più." & vbCrLf
                    testo = testo & "Reinserire il materiale voluto."
                    If Not Silente Then MsgBox(testo, MsgBoxStyle.Information)
                    MatStr = "?"
                    Classe = 0
                    Indmat = 0
                    r.Close()
                    oc.Close()
                    Exit Sub
                End If
            Else
                MatStr = "?"
                Classe = 0
                Exit Sub
            End If
            r.Read()
            '            MatStr = CStr(r.Rows(0)("Mat"))
            MatStr = r.GetString(2)
            '            If IsDBNull(r.Rows(0)("Composiz")) Then
            '            Composiz = ""
            '            Else
            '                Composiz = CStr(r.Rows(0)("Composiz"))
            '            End If
            If r.IsDBNull(17) Then
                Composiz = ""
            Else
                Composiz = r.GetString(17)
            End If
            'If IsDBNull(r.Rows(0)("AlloyUNS")) Then
            If r.IsDBNull(20) Then
                AlloyUNS = ""
            Else
                AlloyUNS = r.GetString(20)
            End If
            'If IsDBNull(r.Rows(0)("Product")) Then
            If r.IsDBNull(19) Then
                Product = ""
            Else
                Product = r.GetString(19)
            End If
            'If Not IsDBNull(r.Rows(0)("Spec")) Then
            If Not r.IsDBNull(22) Then
                Spec = r.GetString(22)
            Else
                Spec = ""
            End If
            'If Not IsDBNull(r.Rows(0)("TypeGrade")) Then
            If Not r.IsDBNull(23) Then
                Grado = r.GetString(23)
            Else
                Grado = ""
            End If
            'If Not IsDBNull(r.Rows(0)("ClassCondTemp")) Then
            If Not r.IsDBNull(24) Then
                ClassTemper = r.GetString(24)
            Else
                ClassTemper = ""
            End If
            'If Not IsDBNull(r.Rows(0)("SizeThk")) Then
            If Not r.IsDBNull(25) Then
                Dimensions = r.GetString(25)
            Else
                Dimensions = ""
            End If
            Indmat = r.GetInt16(1)
            If Not r.IsDBNull(3) Then PSP = CShort(r.GetFloat(3))
            If Not r.IsDBNull(4) Then CAT = r.GetString(4)
            If Not r.IsDBNull(5) Then CT = r.GetString(5)
            If Not r.IsDBNull(6) Then CMT = r.GetString(6)
            Classe = CType(r.GetInt16(7), ClasseMateriale)
            ElasCod = r.GetInt16(8)
            alfacod = r.GetInt16(9)
            If r.IsDBNull(10) Then ConducTer = 0 Else ConducTer = r.GetInt16(10)
            MatGroup = r.GetInt16(11)
            occ = OpenConn()
            ocV = OpenConn()
            Dim IDCaract As Long
            For i = 1 To NumMaxCaract
                If Not IsDBNull(r.Item(iFieldCaract(i))) Then
                    IDCaract = r.GetInt32(iFieldCaract(i))
                    If IDCaract > 0 Then
                        occ.Open()
                        Dim commandc As OleDbCommand = New OleDbCommand("SELECT * FROM Caract WHERE ID=" & IDCaract.ToString, occ)
                        c = commandc.ExecuteReader
                        If Not c.HasRows Then
                            c.Close()
                            occ.Close()
                            r.Close()
                            oc.Close()
                            Exit Sub
                        End If
                        c.Read()
                        If Caract.Count < i Then Caract.Add(New LibMat.CarattMatNew)
                        With Caract.Item(i).TextData
                            'Dim iFoundc As Integer = dvc.Find(r.GetInt16(12 + i))
                            'Dim drvc As DataRowView = dvc(iFoundc)
                            '  .Codice = CShort(drvc("Codice"))
                            .Codice = CType(c.GetInt16(1), Codes)
                            .Source = c.GetString(2) ' CStr(drvc("Source"))
                            .Yield = c.GetFloat(3) ' CSng(drvc("Yield"))
                            If c.IsDBNull(4) Then
                                .Alfa = 0
                            Else
                                .Alfa = c.GetFloat(4) ' CSng(drvc("Alfa"))
                            End If
                            If c.IsDBNull(5) Then
                                .Young = 0
                            Else
                                .Young = c.GetFloat(5) ' CSng(drvc("Young"))
                            End If
                            .US = c.GetFloat(6) ' CSng(drvc("US"))
                            .IndChart = c.GetInt16(7) 'CShort(drvc("IndChart"))
                            If c.IsDBNull(20) Then
                                .IndNote = 0
                            Else
                                .IndNote = c.GetInt32(20) ' CShort(drvc("IndNote"))
                            End If
                            .MWDTrule = c.GetString(8) 'CStr(drvc("MWDTrule"))
                            .MWDTclause = c.GetString(9) ' ""
                            If c.IsDBNull(11) Then
                                .CreepRange = 0
                            Else
                                .CreepRange = c.GetFloat(11) ' CSng(drvc("CreepRange"))
                            End If
                            If c.IsDBNull(10) Then
                                .MWDTtemp = 0
                            Else
                                .MWDTtemp = c.GetFloat(10) ' CSng(drvc("MWDTtemp"))
                            End If
                            .PNumber = c.GetString(12) ' CStr(drvc("PNumber"))
                            .Group = c.GetString(13) ' CStr(drvc("GroupNb"))
                            For l = 1 To NumSerieValori
                                If Not c.IsDBNull(13 + l) Then
                                    ocV.Open()
                                    Dim commandV As OleDbCommand = New OleDbCommand("SELECT * FROM Valori WHERE ID=" & c.GetInt32(13 + l), ocV)
                                    V = commandV.ExecuteReader
                                    If V.HasRows Then V.Read() '  Dim iFoundV As Integer = dvV.Find(drvc(13 + l)) '!!!! era dvc
                                    For k = 1 To 24
                                        If V.HasRows Then VV = V.GetFloat(k) Else VV = 0
                                        '   If iFoundV = -1 Then VV = 0 Else VV = CSng(dvV(iFoundV)(k))
                                        Select Case l
                                            Case 1
                                                .Temp.Item(k).TextData = VV
                                            Case 2
                                                .Ammiss.Item(k).TextData = VV
                                            Case 3
                                                .TempY.Item(k).TextData = VV
                                            Case 4
                                                .AlfaT.Item(k).TextData = VV
                                        End Select
                                    Next k
                                    V.Close()
                                    ocV.Close()
                                End If
                            Next l
                        End With
                        c.Close()
                        occ.Close()
                    End If
                End If
            Next i
            r.Close()
            oc.Close()
        Catch e As Exception
            MsgBox(e.Message & vbCrLf & e.StackTrace)
        End Try
    End Sub
    Public Function UltStrength(ByRef Temp As Single) As Single
        Dim i As Short
        For i = 1 To CShort(Caract.Count)
            Select Case Caract.Item(i).TextData.Codice
                Case Codes.BSpsi, Codes.div1psi, Codes.div2psi '1, 6
                    UltStrength = Caract.Item(i).TextData.US * clsTrigon.MPA
                    Exit For
                Case Else '2, 7, 8
                    UltStrength = Caract.Item(i).TextData.US
                    Exit For
            End Select
        Next
    End Function
    Public Function SPS(ByRef Codice As Short, ByRef Temp As Single) As Single
        'Primary + Secondary stress limit per UG-23(e)
        Dim i As Short
        Dim Codi As Codes
        Dim CreepRange As Single
        Dim testo As String
        Dim Sfo, Sfa, SPSs As Single
        Dim sMat As clsMat
        Dim UnitTemp As String = ""
        Codi = CType(Math.Abs(Codice), Codes)
        Select Case Codi
            Case Codes.div1psi, Codes.div2psi, Codes.div1MPa, Codes.div2MPa 'ASME
                Select Case Codi
                    Case Codes.div1psi, Codes.div2psi : UnitTemp = "°F"
                    Case Codes.div1MPa, Codes.div2MPa : UnitTemp = "°C"
                End Select
                Call LeggiMat(Codice, Temp, Sfa, Sfo, 1)
                For i = 1 To CShort(Caract.Count)
                    If Caract.Item(i).TextData.Codice = Codi Then
                        SPSs = 3 * Sfo
                        SPS = 3 * Sfo
                        CreepRange = Caract.Item(i).TextData.CreepRange
                        If CreepRange = 0 Then
                            testo = "Per il materiale &|fornire la temperatura in " & UnitTemp
                            testo = testo & "|al di sopra della quale la tensione|ammissibile è "
                            testo = testo & "influenzata dalle|proprietà dipendenti dal tempo."
                            testo = Funzioni.FormatS(Monitor.Motore.Inizio.ConvertiCr(testo), Trim(MatStr))
                            CreepRange = Funzioni.ValVir(InputBox(testo, "AsmeVip - UG-23(e)"))
                            Caract.Item(i).TextData.CreepRange = CreepRange
                            sMat = New clsMat
                            sMat.MatSolo = Me
                            FormMat.Add(sMat)
                            PutMat(0)
                            FormMat.remove(1)
                        End If
                        Select Case Codi
                            Case Codes.div1psi, Codes.div2psi : CreepRange = CSng((CreepRange - 32) / 1.8)
                            Case Codes.div1MPa, Codes.div2MPa
                        End Select
                        If CreepRange = 0 Or Temp > CreepRange Then Exit Function
                        If Caract.Item(i).TextData.US <= 0 Or Caract.Item(i).TextData.Yield <= 0 Then
                            testo = "Non è possibile calcolare la tensione ammissibile" & vbCrLf
                            testo = testo & "per le tensioni primarie più secondarie secondo UG-23(e)" & vbCrLf
                            testo = testo & "per il materiale " & Trim(MatStr) & vbCrLf
                            testo = testo & "perché non è noto lo snervamento e/o la rottura a" & vbCrLf
                            testo = testo & "temperatura ambiente"
                            MsgBox(testo, CType(MsgBoxStyle.OKOnly + MsgBoxStyle.Critical, MsgBoxStyle))
                            SPS = 0
                            Exit Function
                        End If
                        If Caract.Item(i).TextData.Yield / Caract.Item(i).TextData.US > 0.7 Then Exit Function
                        Call LeggiMat(Codice, Temp, Sfa, Sfo, 2)
                        If Sfo <= 0 Then
                            testo = "Non è possibile calcolare la tensione ammissibile" & vbCrLf
                            testo = testo & "per le tensioni primarie più secondarie secondo UG-23(e)" & vbCrLf
                            testo = testo & "per il materiale " & Trim(MatStr) & vbCrLf
                            testo = testo & "perché non sono noti gli snervamenti a temperatura."
                            MsgBox(testo, CType(MsgBoxStyle.OKOnly + MsgBoxStyle.Critical, MsgBoxStyle))
                            Exit Function
                        End If
                        If 2 * Sfo > SPSs Then SPS = 2 * Sfo
                        Exit Function
                    End If
                Next
            Case Codes.EU  'EuroNorm
        End Select
    End Function
    Public Sub IndAdd(ByVal i As Short, ByVal j As Short)
        If j + 1 <= Ind.Count() Then
            Ind.Item(j + 1).TextData = i
        Else
            Ind.Add(i)
        End If
    End Sub
    Public Function EmodAlt(ByRef Temp As Single) As Single
        Dim Valor As Single
        Dim Table As DataTable
        Dim RigaValori As DataRowView = Nothing
        Dim cmd As OleDbDataAdapter = Nothing
        If prAgganciato Then
            Table = New DataTable
            If Not IniziaBase() Then Exit Function
            cmd = New OleDbDataAdapter("SELECT * FROM Modelas", MatBase)
            cmd.Fill(Table)
        Else
            If Me.AlfaYoung Is Nothing Then Return 0
            Table = Me.AlfaYoung.tblEmod
        End If
        Valor = PhysAlt(Temp, ElasCod, Table, RigaValori, Me)
        If Valor > 0 Then
            Valor = Valor * 100000.0!
        Else
            If Indmat = 0 And Agganciato Then
                If Not Silente Then Monitor.Motore.MostraAiuto(IDHS.IDH_ERR_LIBMAT_NOINDMAT, , , Monitor.Motore.HelpStringaG("TitLibmat"))
            ElseIf ElasCod = 0 Then
                If Not Silente Then Monitor.Motore.MostraAiuto(-IDHS.IDH_ERR_LIBMAT_EMODALT1, , MatStr.Trim, Monitor.Motore.HelpStringaG("TitLibmat"))
            Else
                If Not Silente Then Monitor.Motore.MostraAiuto(-IDHS.IDH_ERR_LIBMAT_EMODALT2, , MatStr.Trim, Monitor.Motore.HelpStringaG("TitLibmat"))
            End If
        End If
        EmodAlt = Valor * clsTrigon.MPA
        If prAgganciato Then
            cmd.Dispose()
            Table.Dispose()
        End If
    End Function
    Public Function Conducib(ByRef Temp As Single) As Single
        Dim Table As DataTable
        Dim Valor As Single
        Dim RigaValori As DataRowView = Nothing
        Dim cmd As OleDbDataAdapter = Nothing
        If prAgganciato Then
            Table = New DataTable
            If Not IniziaBase() Then Exit Function
            cmd = New OleDbDataAdapter("SELECT * FROM ConducTer", MatBase)
            cmd.Fill(Table)
        Else
            Table = Me.AlfaYoung.tblCond
        End If
        Valor = clsTrigon.kWATT * PhysAlt(CSng(1.8 * Temp + 32), ConducTer, Table, RigaValori, Me)
        If Valor = 0 Then
            If Indmat = 0 Then
                If Not Silente Then Monitor.Motore.MostraAiuto(IDHS.IDH_ERR_LIBMAT_NOINDMAT, , , Monitor.Motore.HelpStringaG("TitLibmat"))
            ElseIf ConducTer = 0 Then
                If Not Silente Then Monitor.Motore.MostraAiuto(-IDHS.IDH_ERR_LIBMAT_CONDUC1, , MatStr.Trim, Monitor.Motore.HelpStringaG("TitLibmat"))
            Else
                If Not Silente Then Monitor.Motore.MostraAiuto(-IDHS.IDH_ERR_LIBMAT_CONDUC2, , MatStr.Trim, Monitor.Motore.HelpStringaG("TitLibmat"))
            End If
        End If
        Conducib = Valor
        If prAgganciato Then
            Table.Dispose()
            cmd.Dispose()
        End If
    End Function
    Public Function EmodAltNome() As String
        Dim Table As New DataTable
        Dim Nome As String = ""
        If Not IniziaBase() Then Return ""
        Dim cmd As OleDbDataAdapter = New OleDbDataAdapter("SELECT * FROM Modelas", MatBase)
        cmd.Fill(Table)
        Dim dvTable As DataView = New DataView(Table)
        dvTable.Sort = "ID"
        '     Table.Index = "PrimaryKey"
        Dim iFound As Integer = dvTable.Find(ElasCod)
        If iFound > -1 Then
            If Not IsDBNull(dvTable(iFound)("Nome")) Then Nome = CStr(dvTable(iFound)("Nome"))
        End If
        Table.Dispose()
        Return Nome
    End Function
    Public Function ConducNome() As String
        Dim Table As New DataTable
        Dim Nome As String = ""
        If Not IniziaBase() Then Return ""
        Dim cmd As OleDbDataAdapter = New OleDbDataAdapter("SELECT * FROM ConducTer", MatBase)
        cmd.Fill(Table)
        Dim dvTable As DataView = New DataView(Table)
        dvTable.Sort = "ID"
        Dim iFound As Integer = dvTable.Find(ConducTer)
        If iFound > -1 Then
            If Not IsDBNull(dvTable(iFound)("Nome")) Then Nome = CStr(dvTable(iFound)("Nome"))
        End If
        Table.Dispose()
        Return Nome
    End Function
    Public Function AlfaTerNome() As String
        Dim Table As New DataTable
        Dim Nome As String = ""
        If Not IniziaBase() Then Return ""
        Dim cmd As OleDbDataAdapter = New OleDbDataAdapter("SELECT * FROM AlfaTer", MatBase)
        cmd.Fill(Table)
        Dim dvTable As DataView = New DataView(Table)
        dvTable.Sort = "ID"
        Dim iFound As Integer = dvTable.Find(alfacod)
        If iFound > -1 Then
            If Not IsDBNull(dvTable(iFound)("Nome")) Then Nome = CStr(dvTable(iFound)("Nome"))
        End If
        Table.Dispose()
        Return Nome
    End Function
    Public Function AlfaTer(ByRef Temp As Single) As Single
        Dim Valor As Single
        Dim RigaValori As DataRowView = Nothing
        Dim cmd As OleDbDataAdapter = Nothing
        Dim Table As DataTable
        If prAgganciato Then
            Table = New DataTable
            If Not IniziaBase() Then Exit Function
            cmd = New OleDbDataAdapter("SELECT * FROM AlfaTer", MatBase)
            cmd.Fill(Table)
        Else
            If Me.AlfaYoung Is Nothing Then Return 0
            Table = Me.AlfaYoung.tblAlfa
        End If
        Valor = PhysAlt(Temp, alfacod, Table, RigaValori, Me)
        If Valor > 0 Then
            Valor = Valor / 1.0E+7!
        Else
            If Indmat = 0 And Agganciato Then
                If Not Silente Then Monitor.Motore.MostraAiuto(IDHS.IDH_ERR_LIBMAT_NOINDMAT, , , Monitor.Motore.HelpStringaG("TitLibmat"))
            ElseIf alfacod = 0 Then
                If Not Silente Then Monitor.Motore.MostraAiuto(-IDHS.IDH_ERR_LIBMAT_ALFATER1, , MatStr.Trim, Monitor.Motore.HelpStringaG("TitLibmat"))
            Else
                If Not Silente Then Monitor.Motore.MostraAiuto(-IDHS.IDH_ERR_LIBMAT_ALFATER2, , MatStr.Trim, Monitor.Motore.HelpStringaG("TitLibmat"))
            End If
        End If
        AlfaTer = CSng(Valor * 1.8)
        If prAgganciato Then
            cmd.Dispose()
            Table.Dispose()
        End If
    End Function
    Public Sub Edizioni(ByRef agg As Short, ByRef File As String)
        Dim Section As String
        Dim n, j, nn As Short
        Dim colSect(20) As String
        Dim Strin(20) As String
        Dim agg1 As Short
        j = 1
        Section = "Aggiornamenti"
        Do
            colSect(j) = Monitor.Motore.Inizio.ReadIniFile("", Section, "Agg" & Trim(Str(j)))
            If Len(colSect(j)) = 0 Then Exit Do
            j = CShort(j + 1)
        Loop
        n = CShort(j - 1)
        If n = 0 Then
No:         Monitor.Motore.MostraAiuto(IDHS.IDH_ERR_LIBMAT_NOFILEAGG)
            '           testo = "Avete problemi con il file LANCIO.INI." + vbCrLf
            '   testo = testo + "Manca, o è corrotta, la sezione [Aggiornamenti]." + vbCrLf
            '   testo = testo + "Richiedere una versione aggiornata." + vbCrLf
            agg = 0
            Exit Sub
        End If
        For j = 1 To n
            nn = CShort(InStr(colSect(j), "|"))
            If nn < 1 Then GoTo No
            Strin(j) = Left(colSect(j), nn - 1)
            colSect(j) = Right(colSect(j), Len(colSect(j)) - nn)
        Next
        If agg = 0 Then agg = 1
        agg1 = Monitor.Motore.Quale(n, "Aggiornamento ASME applicabile", Strin, "", agg)
        If agg1 > 0 Then
            If agg <> agg1 Then
                If MatBase IsNot Nothing Then
                    MatBase.Close()
                    MatBase = Nothing
                End If
            End If
            agg = agg1
        End If
        File = colSect(agg)
    End Sub
    Public Function UG841(ByRef div As Short) As Boolean
        Dim sql As String
        Dim r As New DataTable
        If Not IniziaBase() Then Exit Function
        If div = 1 Then
            sql = "SELECT * FROM [UCS_23] WHERE Spec='" & Spec & "'"
        ElseIf div = 2 Then
            sql = "SELECT * FROM [ACS-1] WHERE Spec='" & Spec & "'"
        Else
            Exit Function
        End If
        Dim cmd As OleDbDataAdapter = New OleDbDataAdapter(sql, MatBase)
        cmd.Fill(r)
        If r.Rows.Count > 0 Then
            UG841 = CBool(r.Rows(0)("UG841"))
        End If
    End Function
    Public Function AQT() As Boolean
        Dim r As New DataTable
        Dim s As New DataTable
        Dim sql As String
        Dim MWDTrule As String = ""
        Dim i As Short
        If Indmat > 0 Then
            For i = 1 To CShort(Caract.Count)
                If Caract.Item(i).TextData.Codice = Codes.div2psi Or Caract.Item(i).TextData.Codice = Codes.div2MPa Then
                    MWDTrule = CStr(Caract.Item(i).TextData.MWDTrule)
                    Exit For
                End If
            Next
            If MWDTrule = "AQT-1" Then
                AQT = True
            ElseIf Len(Trim(MWDTrule)) > 0 Then
                AQT = False
            Else
                Dim cmdr As OleDbDataAdapter = New OleDbDataAdapter("SELECT * FROM ListaMat WHERE Ind=" & Str(Indmat), MatBase)
                cmdr.Fill(r)
                If r.Rows.Count > 0 Then
                    sql = "SELECT * FROM [AQT-1] WHERE Spec='" + CStr(r.Rows(0)("Spec")) + "'"
                    Dim cmds As OleDbDataAdapter = New OleDbDataAdapter(sql, MatBase)
                    cmds.Fill(s)
                    If s.Rows.Count = 0 Then
                    ElseIf s.Rows.Count = 1 Then
                        AQT = True
                    Else
                        Dim dvs As DataView = New DataView(s)
                        dvs.RowFilter = "TypeGrade='" + CStr(r.Rows(0)("TypeGrade")) + "'"
                        If dvs.Count = 0 Then
                        ElseIf dvs.Count = 1 Then
                            AQT = True
                        Else
                            dvs.RowFilter = dvs.RowFilter + " AND ClassCondTemp='" + CStr(r.Rows(0)("ClassCondTemp")) + "'"
                            If dvs.Count = 0 Then
                            ElseIf dvs.Count = 1 Then
                                AQT = True
                            Else
                                'MsgBox "something wrong with AQT-1"
                                AQT = True
                            End If
                        End If
                    End If
                End If
            End If
        End If
    End Function
    Public Sub RegoleMDMT()
        Dim r As New DataTable
        Dim s As New DataTable
        Dim sql As String
        Dim c As New DataTable
        Dim i, ii, j As Short
        Dim iFound As Integer
        Dim cmd As OleDbDataAdapter
        IniziaBase()
        '        modo = 1
        Try
            cmd = New OleDbDataAdapter("SELECT * FROM Caract", MatBase)
            Dim custCB As OleDbCommandBuilder = New OleDbCommandBuilder(cmd)
            cmd.Fill(c)
            Dim indice As Integer
            Dim dvc As DataView = New DataView(c)
            dvc.Sort = "ID"
            '          GoTo Case11
            '       Select Case modo
            '          Case 1
            'step 1 inserimento della regola AQT-1 nei materiali della tabella
            Dim cmdr As OleDbDataAdapter = New OleDbDataAdapter("SELECT * FROM [AQT-1]", MatBase)
            cmdr.Fill(r)
            For i = 0 To CShort(r.Rows.Count - 1)
                sql = "SELECT * FROM ListaMat WHERE Spec='" + CStr(r.Rows(i)("Spec")) + "'"
                If Not IsDBNull(r.Rows(i)("TypeGrade")) Then sql = sql & " AND TypeGrade='" + CStr(r.Rows(i)("TypeGrade")) + "'"
                If Not IsDBNull(r.Rows(i)("ClassCondTemp")) Then sql = sql & " AND ClassCondtemp='" + CStr(r.Rows(i)("ClassCondTemp")) + "'"
                Dim cmds As OleDbDataAdapter = New OleDbDataAdapter(sql, MatBase)
                cmds.Fill(s)
                For j = 0 To CShort(s.Rows.Count - 1)
                    For ii = 1 To NumMaxCaract
                        If Not IsDBNull(s.Rows(j)(iFieldCaract(ii))) Then
                            indice = CInt(s.Rows(j)(iFieldCaract(ii)))
                            If indice > 0 Then
                                iFound = dvc.Find(indice)
                                If iFound > -1 Then
                                    If CType(dvc(iFound)("Codice"), Codes) = Codes.div2MPa Or CType(dvc(iFound)("Codice"), Codes) = Codes.div2psi Then
                                        dvc(iFound).BeginEdit()
                                        dvc(iFound)("MWDTrule") = "AQT-1"
                                        dvc(iFound).EndEdit()
                                    End If
                                End If
                            End If
                        End If
                    Next ii
                Next j
            Next i
            '         Case 2
            'step 2 inserimento della regola ACS-1 nei materiali della tabella
            cmdr = New OleDbDataAdapter("SELECT * FROM [ACS-1] ORDER BY Curve DESC", MatBase)
            r = New DataTable
            cmdr.Fill(r)
            For ii = 0 To CShort(r.Rows.Count - 1)
                sql = "SELECT * FROM ListaMat WHERE Spec='" + CStr(r.Rows(ii)("Spec")) + "'"
                If Not IsDBNull(r.Rows(ii)("TypeGrade")) Then sql = sql & " AND TypeGrade='" + CStr(r.Rows(ii)("TypeGrade")) + "'"
                If Not IsDBNull(r.Rows(ii)("ClassCondTemp")) Then sql = sql & " AND ClassCondtemp='" + CStr(r.Rows(ii)("ClassCondTemp")) + "'"
                Dim cmds As OleDbDataAdapter = New OleDbDataAdapter(sql, MatBase)
                s = New DataTable
                cmds.Fill(s)
                For j = 0 To CShort(s.Rows.Count - 1)
                    For i = 1 To NumMaxCaract
                        iFound = dvc.Find(s.Rows(j)(iFieldCaract(i)))
                        If iFound > -1 Then
                            If CType(dvc(iFound)("Codice"), Codes) = Codes.div2MPa Or CType(dvc(iFound)("Codice"), Codes) = Codes.div2psi Then
                                dvc(iFound).BeginEdit()
                                dvc(iFound)("MWDTrule") = "ACS-1"
                                Select Case CInt(r.Rows(ii)("Curve"))
                                    Case 1 : dvc(iFound)("MWDTclause") = "A"
                                    Case 2 : dvc(iFound)("MWDTclause") = "B"
                                    Case 3 : dvc(iFound)("MWDTclause") = "C"
                                    Case 4 : dvc(iFound)("MWDTclause") = "D"
                                End Select
                                If CSng(r.Rows(ii)("UG841")) <> 0 Then
                                    dvc(iFound)("MWDTtemp") = r.Rows(ii)("MDMT")
                                ElseIf CSng(r.Rows(ii)("MDMT")) <> 0 Then
                                    dvc(iFound)("MWDTtemp") = r.Rows(ii)("MDMT")
                                Else
                                    dvc(iFound)("MWDTtemp") = -1000
                                End If
                                dvc(iFound).EndEdit()
                            End If
                        End If
                    Next i
                Next j
            Next ii
            '        Case 3
            'step 2 inserimento della regola AHA-1 nei materiali della tabella
            cmdr = New OleDbDataAdapter("SELECT * FROM [AHA-1]", MatBase)
            r = New DataTable
            cmdr.Fill(r)
            For ii = 0 To CShort(r.Rows.Count - 1)
                sql = "SELECT * FROM ListaMat WHERE Spec='" + CStr(r.Rows(ii)("Spec")) + "'"
                If Not IsDBNull(r.Rows(ii)("TypeGrade")) Then sql = sql & " AND TypeGrade='" + CStr(r.Rows(ii)("TypeGrade")) + "'"
                If Not IsDBNull(r.Rows(ii)("ClassCondTemp")) Then sql = sql & " AND ClassCondtemp='" + CStr(r.Rows(ii)("ClassCondTemp")) + "'"
                If Not IsDBNull(r.Rows(ii)("UNS")) Then sql = sql & " AND AlloyUNS='" + CStr(r.Rows(ii)("UNS")) + "'"
                Dim cmds As OleDbDataAdapter = New OleDbDataAdapter(sql, MatBase)
                s = New DataTable
                cmds.Fill(s)
                For j = 0 To CShort(s.Rows.Count - 1)
                    For i = 1 To NumMaxCaract
                        iFound = dvc.Find(s.Rows(j)(iFieldCaract(i)))
                        If iFound > -1 Then
                            If CType(dvc(iFound)("Codice"), Codes) = Codes.div2MPa Or CType(dvc(iFound)("Codice"), Codes) = Codes.div2psi Then
                                dvc(iFound).BeginEdit()
                                dvc(iFound)("MWDTrule") = "AHA-1"
                                dvc(iFound)("MWDTtemp") = r.Rows(ii)("MDMT")
                                dvc(iFound).EndEdit()
                            End If
                        End If
                    Next
                Next j
            Next ii
            '       Case 4
            'step 2 inserimento della regola AHA-1 nei materiali della tabella
            cmdr = New OleDbDataAdapter("SELECT * FROM [ANF-1]", MatBase)
            r = New DataTable
            cmdr.Fill(r)
            For ii = 0 To CShort(r.Rows.Count - 1)
                sql = "SELECT * FROM ListaMat WHERE Spec='" + CStr(r.Rows(ii)("Spec")) + "'"
                If Not IsDBNull(r.Rows(ii)("AlloyUNS")) Then sql = sql & " AND AlloyUNS='" + CStr(r.Rows(ii)("AlloyUNS")) + "'"
                Dim cmds As OleDbDataAdapter = New OleDbDataAdapter(sql, MatBase)
                s = New DataTable
                cmds.Fill(s)
                For j = 0 To CShort(s.Rows.Count - 1)
                    For i = 1 To NumMaxCaract
                        iFound = dvc.Find(s.Rows(j)(iFieldCaract(i)))
                        If iFound > -1 Then
                            If CType(dvc(iFound)("Codice"), Codes) = Codes.div2MPa Or CType(dvc(iFound)("Codice"), Codes) = Codes.div2psi Then
                                dvc(iFound).BeginEdit()
                                dvc(iFound)("MWDTrule") = "ANF-1." & CStr(r.Rows(ii)("Classe")).Trim
                                dvc(iFound)("MWDTtemp") = r.Rows(ii)("TempSpec")
                                dvc(iFound).EndEdit()
                            End If
                        End If
                    Next
                Next j
            Next ii
            '      Case 11
            'inserimento della regola UHT-23 nei materiali della tabella
Case11:     cmdr = New OleDbDataAdapter("SELECT * FROM [UHT_23]", MatBase)
            r = New DataTable
            cmdr.Fill(r)
            For ii = 0 To CShort(r.Rows.Count - 1)
                sql = "SELECT * FROM ListaMat WHERE Spec='" + CStr(r.Rows(ii)("Spec")) + "'"
                If Not IsDBNull(r.Rows(ii)("TypeGrade")) Then sql = sql & " AND TypeGrade='" + CStr(r.Rows(ii)("TypeGrade")) + "'"
                If Not IsDBNull(r.Rows(ii)("ClassCondTemp")) Then sql = sql & " AND ClassCondtemp='" + CStr(r.Rows(ii)("ClassCondTemp")) + "'"
                Dim cmds As OleDbDataAdapter = New OleDbDataAdapter(sql, MatBase)
                s = New DataTable
                cmds.Fill(s)
                For j = 0 To CShort(s.Rows.Count - 1)
                    For i = 1 To NumMaxCaract
                        iFound = dvc.Find(s.Rows(j)(iFieldCaract(i)))
                        If iFound > -1 Then
                            If CType(dvc(iFound)("Codice"), Codes) = Codes.div2MPa Or CType(dvc(iFound)("Codice"), Codes) = Codes.div2psi Then
                                dvc(iFound).BeginEdit()
                                dvc(iFound)("MWDTrule") = "UHT-5(c)"
                                dvc(iFound).EndEdit()
                            End If
                        End If
                    Next
                Next j
            Next ii
            '     Case 12
            ' inserimento della regola UCS-66 nei materiali della tabella
            cmdr = New OleDbDataAdapter("SELECT * FROM [UCS_23] ORDER BY Curve DESC", MatBase)
            r = New DataTable
            cmdr.Fill(r)
            For ii = 0 To CShort(r.Rows.Count - 1)
                sql = "SELECT * FROM ListaMat WHERE Spec='" + CStr(r.Rows(ii)("Spec")) + "'"
                If Not IsDBNull(r.Rows(ii)("TypeGrade")) Then sql = sql & " AND TypeGrade='" + CStr(r.Rows(ii)("TypeGrade")) + "'"
                If Not IsDBNull(r.Rows(ii)("ClassCondTemp")) Then sql = sql & " AND ClassCondtemp='" + CStr(r.Rows(ii)("ClassCondTemp")) + "'"
                Dim cmds As OleDbDataAdapter = New OleDbDataAdapter(sql, MatBase)
                s = New DataTable
                cmds.Fill(s)
                For j = 0 To CShort(s.Rows.Count - 1)
                    For i = 1 To NumMaxCaract
                        iFound = dvc.Find(s.Rows(j)(iFieldCaract(i)))
                        If iFound > -1 Then
                            If CType(dvc(iFound)("Codice"), Codes) = Codes.div1MPa Or CType(dvc(iFound)("Codice"), Codes) = Codes.div1psi Then
                                dvc(iFound).BeginEdit()
                                dvc(iFound)("MWDTrule") = "UCS-66"
                                Select Case CInt(r.Rows(ii)("Curve"))
                                    Case 1 : dvc(iFound)("MWDTclause") = "A"
                                    Case 2 : dvc(iFound)("MWDTclause") = "B"
                                    Case 3 : dvc(iFound)("MWDTclause") = "C"
                                    Case 4 : dvc(iFound)("MWDTclause") = "D"
                                    Case 5 : dvc(iFound)("MWDTclause") = "E"
                                End Select
                                If CSng(r.Rows(ii)("UG841")) <> 0 Or CInt(r.Rows(ii)("Curve")) = 5 Then
                                    dvc(iFound)("MWDTtemp") = r.Rows(ii)("MDMT")
                                ElseIf CSng(r.Rows(ii)("MDMT")) <> 0 Then
                                    dvc(iFound)("MWDTtemp") = r.Rows(ii)("MDMT")
                                Else
                                    dvc(iFound)("MWDTtemp") = -1000
                                End If
                                dvc(iFound).EndEdit()
                            End If
                        End If
                    Next
                Next j
            Next ii
            '    Case 13
            'step 2 inserimento della regola AHA-1 nei materiali della tabella
            cmdr = New OleDbDataAdapter("SELECT * FROM [UHA_23]", MatBase)
            r = New DataTable
            cmdr.Fill(r)
            For ii = 0 To CShort(r.Rows.Count - 1)
                sql = "SELECT * FROM ListaMat WHERE Spec='" + CStr(r.Rows(ii)("Spec")) + "'"
                If Not IsDBNull(r.Rows(ii)("TypeGrade")) Then sql = sql & " AND TypeGrade='" + CStr(r.Rows(ii)("TypeGrade")) + "'"
                If Not IsDBNull(r.Rows(ii)("ClassCondTemp")) Then sql = sql & " AND ClassCondtemp='" + CStr(r.Rows(ii)("ClassCondTemp")) + "'"
                If Not IsDBNull(r.Rows(ii)("UNS")) Then sql = sql & " AND AlloyUNS='" + CStr(r.Rows(ii)("UNS")) + "'"
                Dim cmds As OleDbDataAdapter = New OleDbDataAdapter(sql, MatBase)
                s = New DataTable
                cmds.Fill(s)
                For j = 0 To CShort(s.Rows.Count - 1)
                    For i = 1 To NumMaxCaract
                        iFound = dvc.Find(s.Rows(j)(iFieldCaract(i)))
                        If iFound > -1 Then
                            If CType(dvc(iFound)("Codice"), Codes) = Codes.div1MPa Or CType(dvc(iFound)("Codice"), Codes) = Codes.div1psi Then
                                dvc(iFound).BeginEdit()
                                dvc(iFound)("MWDTrule") = "UHA-23"
                                dvc(iFound)("MWDTtemp") = r.Rows(ii)("MDMT")
                                dvc(iFound).EndEdit()
                            End If
                        End If
                    Next
                Next j
            Next ii
            '   Case 14
            'step 2 inserimento della regola AHA-1 nei materiali della tabella
            cmdr = New OleDbDataAdapter("SELECT * FROM [UNF_23]", MatBase)
            r = New DataTable
            cmdr.Fill(r)
            For ii = 0 To CShort(r.Rows.Count - 1)
                sql = "SELECT * FROM ListaMat WHERE Spec='" + CStr(r.Rows(ii)("Spec")) + "'"
                If Not IsDBNull(r.Rows(ii)("AlloyUNS")) Then sql = sql & " AND AlloyUNS='" + CStr(r.Rows(ii)("AlloyUNS")) + "'"
                Dim cmds As OleDbDataAdapter = New OleDbDataAdapter(sql, MatBase)
                s = New DataTable
                cmds.Fill(s)
                For j = 0 To CShort(s.Rows.Count - 1)
                    For i = 1 To NumMaxCaract
                        iFound = dvc.Find(s.Rows(j)(iFieldCaract(i)))
                        If iFound > -1 Then
                            If CType(dvc(iFound)("Codice"), Codes) = Codes.div1MPa Or CType(dvc(iFound)("Codice"), Codes) = Codes.div1psi Then
                                dvc(iFound).BeginEdit()
                                dvc(iFound)("MWDTrule") = "UNF-23." & CStr(r.Rows(ii)("Classe")).Trim
                                dvc(iFound)("MWDTtemp") = r.Rows(ii)("TempSpec")
                                dvc(iFound).EndEdit()
                            End If
                        End If
                    Next
                Next j
            Next ii
            'End Select
            cmd.Update(c)
            dvc.Dispose()
            custCB.Dispose()
            cmd.Dispose()
            c.Dispose()
            s.Dispose()
            r.Dispose()
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Public Function UHA51d(ByRef div As Short) As Short
        Dim sql As String
        Dim r As New DataTable
        Dim s As New DataTable
        If div = 1 Then
            sql = "SELECT * FROM [UHA_23] WHERE Spec='" & Spec & "'"
        ElseIf div = 2 Then
            sql = "SELECT * FROM [AHA-1] WHERE Spec='" & Spec & "'"
        Else
            Exit Function
        End If
        If Indmat = 0 Then Exit Function
        Dim cmd As OleDbDataAdapter = New OleDbDataAdapter("SELECT * FROM ListaMat WHERE Ind=" & Str(Indmat), MatBase)
        cmd.Fill(s)
        If s.Rows.Count = 0 Then Exit Function
        If Not IsDBNull(s.Rows(0)("TypeGrade")) Then sql = sql & " AND TypeGrade='" + CStr(s.Rows(0)("TypeGrade")) + "'"
        If Not IsDBNull(s.Rows(0)("ClassCondTemp")) Then sql = sql & " AND ClassCondTemp='" + CStr(s.Rows(0)("ClassCondTemp")) + "'"
        If Not IsDBNull(s.Rows(0)("AlloyUNS")) Then sql = sql & " AND UNS='" + CStr(s.Rows(0)("AlloyUNS")) + "'"
        cmd = New OleDbDataAdapter(sql, MatBase)
        cmd.Fill(r)
        If r.Rows.Count = 0 Then
            MsgBox("problema UHA51d")
            Exit Function
        End If
        Dim testo As String = CStr(r.Rows(0)("Structure")).ToUpper
        If InStr(testo, "CR-M") > 0 Then
            UHA51d = 1
        ElseIf InStr(testo, "DUPL") > 0 Then
            UHA51d = 2
        ElseIf InStr(testo, "FERR") > 0 Then
            UHA51d = 3
        ElseIf InStr(testo, "MART") > 0 Then
            UHA51d = 4
        ElseIf InStr(testo, "DUPL") > 0 Then
            UHA51d = 0
        End If
    End Function
    Private Sub Aler2()
        MsgBox("EN Gruppo nullo")
    End Sub
    Private Sub Aler3(ByRef Gr As String)
        MsgBox("EN Gruppo " & Gr & "inesistente")
    End Sub
    Public Sub Stampa()
        Stampe()
    End Sub
    Public Function EUMatGroup() As String
        Dim i As Short
        Dim Direct As New DataTable
        Dim nchart As Short
        Dim iFound As Integer
        EUMatGroup = "not defined"
        For i = 1 To CShort(Caract.Count)
            If Caract.Item(i).TextData.Codice = Codes.EU Then
                nchart = Caract.Item(i).TextData.IndChart
                Dim cmd As OleDbDataAdapter = New OleDbDataAdapter("SELECT * FROM GruppiEN", MatBase)
                cmd.Fill(Direct)
                Dim dv As DataView = New DataView(Direct)
                dv.Sort = "ID"
                iFound = dv.Find(nchart)
                If iFound > -1 Then EUMatGroup = CStr(dv(iFound)("Gruppo")) + " " + CStr(dv(iFound)("Descrizione"))
                Direct.Dispose()
                Exit Function
            End If
        Next
    End Function
    Public Property Agganciato() As Boolean
        Get
            Return prAgganciato
        End Get
        Set(ByVal Value As Boolean)
            prAgganciato = Value
        End Set
    End Property
    Public Function CercaMat(ByRef CAT As String, ByRef Cod As String, ByRef MatStr As String) As Short
        Dim r As New DataTable
        Dim s As New DataTable
        Dim iQ As Short
        Dim testo As String = ""
        Dim Aiuto As String = ""
        Dim Strin1() As String
        Dim nInput, i As Short
        If CAT = "" Then Exit Function
        Dim cmdr As OleDbDataAdapter = New OleDbDataAdapter _
        ("SELECT Ind,Mat FROM ListaMat WHERE CMT='" & Cod & "'", MatBase)
        cmdr.Fill(r)
        If r.Rows.Count = 0 Then
            Dim cmds As OleDbDataAdapter = New OleDbDataAdapter _
            ("SELECT * FROM CategorieProdotti WHERE Categoria='" & CAT & "'", MatBase)
            cmds.Fill(s)
            If s.Rows.Count < 1 Then
                MsgBox("Errore impossibile in CercaMat")
                Exit Function
            End If
            Indmat = 0
            Scelta(CType(s.Rows(0)("Classe"), ClasseMateriale))
            s.Dispose()
            cmds = New OleDbDataAdapter("SELECT Ind,Mat,CMT FROM ListaMat WHERE Ind=" & Str(Indmat), MatBase)
            Dim custCB As OleDbCommandBuilder = New OleDbCommandBuilder(cmds)
            cmds.Fill(s)
            If s.Rows.Count = 0 Then Exit Function
            CercaMat = CShort(s.Rows(0)("Ind"))
            MatStr = CStr(s.Rows(0)("Mat"))
            Dim dvs As DataView = New DataView(s)
            Dim drv As DataRowView = dvs(0)
            drv.BeginEdit()
            drv("CMT") = Cod
            drv.EndEdit()
            cmds.Update(s)
            custCB.Dispose()
            cmds.Dispose()
            s.Dispose()
            cmdr.Dispose()
            r.Dispose()
            Exit Function
        Else
            nInput = CShort(r.Rows.Count)
            If nInput > 1 Then
                ReDim Strin1(nInput)
                For i = 1 To nInput
                    Strin1(i) = CStr(r.Rows(i - 1)("Mat"))
                    i = CShort(i + 1)
                Next i
                iQ = Monitor.Motore.Quale(nInput, "Scelta materiale", Strin1, Aiuto, 1, testo)
            End If
        End If
        CercaMat = CShort(r.Rows(iQ - 1)("Ind"))
        MatStr = CStr(r.Rows(iQ - 1)("Mat"))
        cmdr.Dispose()
        r.Dispose()
    End Function
    Public Sub SuperUpDate()
        Dim f As String
        frmUpdate.DefInstance.Mat = Me
        f = Monitor.Motore.Inizio.Archdir & "\UpASME.TXT"
        IO.File.Delete(f)
        frmUpdate.DefInstance.ShowDialog()
        frmUpdate.DefInstance.Close()
    End Sub
End Class
<Serializable()> Public Class clsAlfaYoung
    Friend tblEmod As DataTable
    Friend tblAlfa As DataTable
    Friend tblCond As DataTable
    Public Sub New()
        Dim myDataColumn As DataColumn
        Dim myDataRow As DataRow
        Dim i As Integer
        tblEmod = New DataTable
        tblAlfa = New DataTable
        tblCond = New DataTable
        myDataColumn = New DataColumn
        myDataColumn.DataType = GetType(Integer)
        tblEmod.Columns.Add(myDataColumn)
        myDataColumn = New DataColumn
        myDataColumn.DataType = GetType(Integer)
        tblAlfa.Columns.Add(myDataColumn)
        myDataColumn = New DataColumn
        myDataColumn.DataType = GetType(Integer)
        tblCond.Columns.Add(myDataColumn)
        myDataColumn = New DataColumn
        myDataColumn.DataType = GetType(String)
        tblEmod.Columns.Add(myDataColumn)
        myDataColumn = New DataColumn
        myDataColumn.DataType = GetType(String)
        tblAlfa.Columns.Add(myDataColumn)
        myDataColumn = New DataColumn
        myDataColumn.DataType = GetType(String)
        tblCond.Columns.Add(myDataColumn)
        For i = 1 To 5
            myDataColumn = New DataColumn
            myDataColumn.DataType = GetType(Single)
            tblEmod.Columns.Add(myDataColumn)
            myDataColumn = New DataColumn
            myDataColumn.DataType = GetType(Single)
            tblAlfa.Columns.Add(myDataColumn)
            myDataColumn = New DataColumn
            myDataColumn.DataType = GetType(Single)
            tblCond.Columns.Add(myDataColumn)
        Next
        'riga 0 (temperature)
        myDataRow = tblEmod.NewRow()
        myDataRow(0) = 0
        myDataRow(1) = ""
        For i = 2 To 6
            myDataRow(i) = 0
        Next
        tblEmod.Rows.Add(myDataRow)
        myDataRow = tblAlfa.NewRow()
        myDataRow(0) = 0
        myDataRow(1) = ""
        For i = 2 To 6
            myDataRow(i) = 0
        Next
        tblAlfa.Rows.Add(myDataRow)
        myDataRow = tblCond.NewRow()
        myDataRow(0) = 0
        myDataRow(1) = ""
        For i = 2 To 6
            myDataRow(i) = 0
        Next
        tblCond.Rows.Add(myDataRow)
        'riga 1 (valori)
        myDataRow = tblEmod.NewRow()
        myDataRow(0) = 0
        myDataRow(1) = rmHelpStrings.GetString("definito_localmente")
        For i = 2 To 6
            myDataRow(i) = 0
        Next
        tblEmod.Rows.Add(myDataRow)
        myDataRow = tblAlfa.NewRow()
        myDataRow(0) = 0
        myDataRow(1) = rmHelpStrings.GetString("definito_localmente")
        For i = 2 To 6
            myDataRow(i) = 0
        Next
        tblAlfa.Rows.Add(myDataRow)
        myDataRow = tblCond.NewRow()
        myDataRow(0) = 0
        myDataRow(1) = rmHelpStrings.GetString("definito_localmente")
        For i = 2 To 6
            myDataRow(i) = 0
        Next
        tblCond.Rows.Add(myDataRow)
    End Sub
End Class
Module modUpdate
    Public rinnovo As Boolean ' per rinnovare i vettori Valori invece di scriverci sopra se esistono
    Private newmode, verboso As Boolean
    Private Nts As New DataTable
    Private RegNote As New DataTable
    Private dvNts, dvRegNote As DataView
    Private drvNts, drvRegNote As DataRowView
    Private iFoundNts, iFoundRegNote As Integer
    Private T1B As New DataTable
    Private dvT1B As DataView
    Private drvT1B As DataRowView
    Private Testa As New DataTable
    Private iFoundT As Integer
    Private dvTesta As DataView
    Private drvTesta As DataRowView
    Private n As Short
    Private r As New DataTable
    Private c As New DataTable
    Private V As New DataTable
    Private d As New DataTable
    Private dvr, dvc, dvV, dvd As DataView
    Private drvr, drvc, drvV, drvd As DataRowView
    Private iFoundr, iFoundc, iFoundV, iFoundd As Integer
    Private CBr, CBc, CBd, CBV, CBRN As OleDbCommandBuilder
    Private cmdr, cmdc, cmdd, cmdV, cmdRN As OleDbDataAdapter
    Private i As Short
    Private AlloN, Allo1, Allo2 As String
    Private Vera As Boolean
    Private testo As String
    Private Buff As DataTable
    Private icod1 As Short
    Private Gia As Boolean
    Private Spec As String
    Private Yes As Boolean
    Private Ord As Single
    Private Dummy As Integer
    Private SpecN As String
    Private nn As Short
    Private Temp(36) As Single
    Private s(36) As Single
    Private ii, j, k As Short
    Private Ord1 As Single
    Private SpecN1, SpecN2 As String
    Private SpecNN As String
    Private jj, nn1 As Short
    Private Criterio As String
    Private jjj As Short
    Private Fatto As Short
    Private Log1 As Boolean
    Private strNotes As String
    Private strNota, Buffer, TabNota As String
    Private ilog As Integer
    Private Yes1 As Boolean
    Private Tabella As String
    Private Addenda, Sorg As String
    Private Aggior As Boolean
    Private Size, Grado, Classe, UNS As Boolean
    Private strSize, strGrado, strClasse, strUNS As String
    Private SpecNuda, SpecNNN As String
    Private AggNote As Boolean
    Private pagina, Riga As String
    Private icod As Integer, Campo, CampoPr, key As String
    Public CampoCl, CampoSi, CampoTG, CampoAU, CampoNC As String
    Public Campopg, Camporg, CampoAd, CampoMY, CampoUS As String
    Public CampoEP, CampoPN, CampoGN, CampoSN As String
    Public jCodes As Codes
    Public Sorgente As String
    Friend CampiASME, DatiGenerali As StringDictionary
    Private Mille As Single
    Private Const gintNOVERINFO As Integer = 12000
    Private Const Source As String = "ASME II-D 2004"
    Private Declare Function GetPrivateProfileSection Lib "kernel32" Alias "GetPrivateProfileSectionA" _
    (ByVal lpAppName As String, ByVal lpReturnedString As String, ByVal nSize As Integer, ByVal lpFilename As String) As Integer
    Friend Sub CaricaCampi(ByVal Section As String)
        Dim File As String = Monitor.Motore.Inizio.Archdir + "\UpDateASME.ini"
        'Dim Buffer As StringBuilder = New StringBuilder(gintNOVERINFO) ' = Space$(gintNOVERINFO)
        Dim BufferStr As String = Space(gintNOVERINFO)
        'Dim BufferStr As String = Buffer.ToString
        Dim Dato As String, m As Integer
        Dim key, value As String
        Dim n As Integer = GetPrivateProfileSection(Section, BufferStr, gintNOVERINFO, File)
        BufferStr = Left(BufferStr, n)
        CampiASME = New StringDictionary
        Do
            n = InStr(BufferStr, Chr(0))
            If n = 0 Then Exit Do
            Dato = Left(BufferStr, n - 1)
            On Error Resume Next
            BufferStr = Right(BufferStr, Len(BufferStr) - n)
            On Error GoTo 0
            m = InStr(Dato, "=")
            key = Left(Dato, m - 1)
            value = Right(Dato, Len(Dato) - m)
            CampiASME.Add(key, value)
            'If Len(BufferStr) - n <= 0 Then Exit Do
        Loop
    End Sub
    Friend Sub CaricaGenerale(ByVal Section As String)
        Dim File As String = Monitor.Motore.Inizio.Archdir + "\UpDateASME.ini"
        Dim BufferStr As String = Space(gintNOVERINFO)
        Dim Dato As String, m As Integer
        Dim key, value As String
        Try
            Dim n As Integer = GetPrivateProfileSection(Section, BufferStr, gintNOVERINFO, File)
            BufferStr = Left(BufferStr, n)
            DatiGenerali = New StringDictionary
            Do
                n = InStr(BufferStr, Chr(0))
                If n = 0 Then Exit Do
                Dato = Left(BufferStr, n - 1)
                BufferStr = Right(BufferStr, Len(BufferStr) - n)
                m = InStr(Dato, "=")
                key = Left(Dato, m - 1)
                value = Right(Dato, Len(Dato) - m)
                DatiGenerali.Add(key, value)
                'If Len(BufferStr) - n <= 0 Then Exit Do
            Loop
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Private Function CercaCampo(ByVal key As String, ByVal Campo As String, ByVal rs As DataTable) As String
        Dim File As String = Monitor.Motore.Inizio.Archdir + "\UpDateASME.ini"
        Dim i As Integer, Valore As String
        If Campo = "" Then
            Campo = key
        End If
        For i = 0 To rs.Columns.Count - 1
            If Campo = rs.Columns(i).Caption Then
                Return rs.Columns(i).Caption
            End If
        Next
        Dim f As frmUpDateCampi = New frmUpDateCampi
        f.prCampo = Campo
        f.prrs = rs
        f.ShowDialog()
        Valore = f.prValore
        f.Close()
        f.Dispose()
        Monitor.Motore.Inizio.WriteIniFile(File, "Campi" + Tabella, key, Valore)
        Try
            CampiASME.Remove(key)
        Catch ex As Exception

        End Try
        CampiASME.Add(key, Valore)
        Return Valore
    End Function
    Private Sub Pulisci2()
        Dim pagina2 As String = ""
        Dim Riga2 As String = ""
        Dim Tabella2 As String = ""
        Try
            If Not IsDBNull(drvr("P2A")) Then
                pagina2 = CStr(drvr("P2A"))
                Riga2 = CStr(drvr("R2A"))
                Tabella2 = "2A"
            End If
            If pagina2 = "" Then
                If Not IsDBNull(drvr("P2B")) Then
                    pagina2 = CStr(drvr("P2B"))
                    Riga2 = CStr(drvr("R2B"))
                    Tabella2 = "2B"
                End If
            End If
            If pagina2 = "" Then
                If Not IsDBNull(drvr("P4")) Then
                    pagina2 = CStr(drvr("P4"))
                    Riga2 = CStr(drvr("R4"))
                    Tabella2 = "4"
                End If
            End If
            If pagina2 = "" Then VerificaCodici() : Exit Sub
            'Exit Sub
            Dim loccmd As OleDbDataAdapter
            Dim locT1B As New DataTable
            loccmd = New OleDbDataAdapter("SELECT * FROM " & Tabella2, MatASME)
            loccmd.Fill(locT1B)
            Dim dvT1B As DataView = New DataView(locT1B)
            dvT1B.RowFilter = "[" & Campopg & "] = '" & pagina2 & "' AND [" & Camporg & "] = '" & Riga2 & "'"
            If dvT1B.Count = 0 Then VerificaCodici() : Exit Sub
            Dim i As Integer
            For i = 0 To dvT1B.Count - 1
                If Not CStr(dvT1B(i)(CampoSN)).Trim = CStr(drvr("Spec")).Trim Then VerificaCodici() : Exit Sub
                If IsDBNull(drvr("AlloyUNS")) Then
                    drvr.BeginEdit()
                    drvr("AlloyUNS") = " "
                    drvr.EndEdit()
                End If
                If Not IsDBNull(dvT1B(i)(CampoAU)) Then
                    If Not CStr(dvT1B(i)(CampoAU)).Trim = CStr(drvr("AlloyUNS")).Trim Then VerificaCodici() : Exit Sub
                End If
                If IsDBNull(drvr("TypeGrade")) Then
                    drvr.BeginEdit()
                    drvr("TypeGrade") = " "
                    drvr.EndEdit()
                End If
                If Not IsDBNull(dvT1B(i)(CampoTG)) Then
                    If Not CStr(dvT1B(i)(CampoTG)).Trim = CStr(drvr("TypeGrade")).Trim Then VerificaCodici() : Exit Sub
                End If
                If IsDBNull(drvr("SizeThk")) Then
                    drvr.BeginEdit()
                    drvr("SizeThk") = " "
                    drvr.EndEdit()
                End If
                If Not IsDBNull(dvT1B(i)(CampoSi)) Then
                    If Not CStr(dvT1B(i)(CampoSi)).Trim = CStr(drvr("SizeThk")).Trim Then VerificaCodici() : Exit Sub
                End If
            Next
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Private Sub VerificaCodici()
        Dim i, iii As Integer
        For iii = 2 To 2
            Select Case iii
                Case 1 : jCodes = Codes.div2psi
                Case 2 : jCodes = Codes.div2MPa
            End Select
            For i = 1 To NumMaxCaract
                If IsDBNull(drvr(iFieldCaract(i))) Then Exit For
                If CInt(drvr(iFieldCaract(i))) > 0 Then
                    iFoundc = dvc.Find(drvr(iFieldCaract(i)))
                    If iFoundc > -1 Then
                        If CType(dvc(iFoundc)("Codice"), Codes) = jCodes Then
                            drvr.BeginEdit()
                            drvr(iFieldCaract(i)) = 0
                            drvr.EndEdit()
                        End If
                    End If
                End If
            Next

        Next
    End Sub
    Friend Sub UpDateASME(ByRef icodext As Short, ByVal mode As Boolean)
        Dim cmd As OleDbDataAdapter
        Dim iii As Integer
        '--------------------------
        icod = icodext
        newmode = mode
        verboso = False
        '--------------------------
        '1 lam C
        '2 lam inox
        '4 tubi
        If Not IO.File.Exists(FileMate) Then
            Monitor.Motore.MostraAiuto(IDHS.IDH_UPASME_NODBMATE, , , Monitor.Motore.HelpStringaG("TitLibmat"))
            Exit Sub
        End If
        Dim cString As String = Conn & FileMate & ConnFine
        MatBase = New OleDbConnection(cString)
        If Not IO.File.Exists(FileAsme) Then
            Monitor.Motore.MostraAiuto(IDHS.IDH_UPASME_NODBASME, , , Monitor.Motore.HelpStringaG("TitLibmat"))
            Exit Sub
        End If
        cString = Conn & FileAsme & ConnFine
        MatASME = New OleDbConnection(cString)
        ilog = FreeFile()
        FileOpen(ilog, Monitor.Motore.Inizio.Archdir & "\UpASME.TXT", OpenMode.Append)
        Select Case icod
            Case 0
                UpdateNote()
                GoTo Fine
            Case 1 To 7
                Tabella = "1A"
                TabNota = "1A"
            Case 8
                Tabella = "3"
                TabNota = "3"
            Case 11 To 17
                Tabella = "1B"
                TabNota = "1B"
            Case 21
                Tabella = "2A"
                TabNota = "2A"
            Case 22
                Tabella = "2B"
                TabNota = "2B"
            Case 23
                Tabella = "4"
                TabNota = "4"
            Case 24
                Tabella = "Y1"
                TabNota = ""
            Case 25
                Tabella = "U"
                TabNota = ""
            Case Else
                GoTo Fine
        End Select
        Try
            CaricaCampi("Campi" + Tabella)
            cmd = New OleDbDataAdapter("SELECT * FROM " & Tabella, MatASME)
            T1B = New DataTable
            cmd.Fill(T1B)
            PrintLine(ilog, "Aperti " & Str(T1B.Rows.Count) & " records dalla tabella " & TabNota & " del file " & FileAsme)
        Catch e As Exception
            MsgBox("Errore all'apertura della tabella " & Tabella & vbCrLf & e.Message + vbCrLf + e.StackTrace)
            GoTo Fine1
        End Try
        key = "Addenda"
        Campo = CampiASME(key)
        Campo = CercaCampo(key, Campo, T1B)
        If Campo = "" Then Exit Sub
        'Campo = "[" & Campo & "]"
        CampoAd = Campo
        key = "Pagina"
        Campo = CampiASME(key)
        Campo = CercaCampo(key, Campo, T1B)
        If Campo = "" Then Exit Sub
        'Campo = "[" & Campo & "]"
        Campopg = Campo
        key = "Riga"
        Campo = CampiASME(key)
        Campo = CercaCampo(key, Campo, T1B)
        If Campo = "" Then Exit Sub
        'Campo = "[" & Campo & "]"
        Camporg = Campo
        key = "Size"
        Campo = CampiASME(key)
        Campo = CercaCampo(key, Campo, T1B)
        If Campo = "" Then Exit Sub
        'Campo = "[" & Campo & "]"
        CampoSi = Campo
        key = "MinTensileStrength"
        Campo = CampiASME(key)
        Campo = CercaCampo(key, Campo, T1B)
        If Campo = "" Then Exit Sub
        'Campo = "[" & Campo & "]"
        CampoUS = Campo
        If icod <> 25 Then
            key = "MinYieldStrength"
            Campo = CampiASME(key)
            Campo = CercaCampo(key, Campo, T1B)
            If Campo = "" Then Exit Sub
            'Campo = "[" & Campo & "]"
            CampoMY = Campo
        End If
        key = "AlloyUNS"
        Campo = CampiASME(key)
        Campo = CercaCampo(key, Campo, T1B)
        If Campo = "" Then Exit Sub
        'Campo = "[" & Campo & "]"
        CampoAU = Campo
        key = "Class"
        Campo = CampiASME(key)
        Campo = CercaCampo(key, Campo, T1B)
        If Campo = "" Then Exit Sub
        'Campo = "[" & Campo & "]"
        CampoCl = Campo
        If icod <> 22 Then
            key = "TypeGrade"
            Campo = CampiASME(key)
            Campo = CercaCampo(key, Campo, T1B)
            If Campo = "" Then Exit Sub
            'Campo = "[" & Campo & "]"
            CampoTG = Campo
        End If
        If icod <> 23 Then
            key = "ProductForm"
            CampoPr = CampiASME(key)
            CampoPr = CercaCampo(key, CampoPr, T1B)
            If CampoPr = "" Then Exit Sub
            '  CampoPr = "[" & CampoPr & "]"
            Campo = "[" & CampoPr & "]"
        End If
        dvT1B = New DataView(T1B)
        If icod < 20 Then
            Try
                Select Case icod
                    Case 1, 2
                        dvT1B.RowFilter = "(" & Campo & " LIKE '*hee*' OR " & Campo & " LIKE '*lat*')" ' "instr(" & Campo & ",'Sh')>0 OR instr(" & Campo & ",'Pl')>0"
                    Case 11, 12
                        dvT1B.RowFilter = "(" & Campo & " LIKE '*hee*' OR " & Campo & " LIKE '*lat*')" ' "instr(" & Campo & ",'heet')>0 OR instr(" & Campo & ",'late')>0"
                    Case 4, 14
                        dvT1B.RowFilter = Campo & " LIKE '*ub*'" ' "instr(" & Campo & ",'ube')>0"
                    Case 6, 16
                        dvT1B.RowFilter = Campo & " LIKE '*ip*'" '"instr(" & Campo & ",'ipe')>0"
                    Case 7, 17
                        dvT1B.RowFilter = "(" & Campo & " LIKE '*ittin*' OR " & Campo & " LIKE '*orgin*' OR " & Campo & " LIKE '*ar' OR " & Campo & " LIKE '*astin*')" ' "instr(" & Campo & ",'itting')>0 OR instr(" & Campo & ",'orging')>0 OR instr(" & Campo & ",'Bar')>0  OR instr(" & Campo & ",'asting')>0"
                End Select
                PrintLine(ilog, "Selezionati dai precedenti" & Str(dvT1B.Count) & " records per il tipo materiale FBM n°" & Str(icod))
            Catch e As Exception
                MsgBox("Errore nella prima selezione: " & e.message + vbCrLf + e.StackTrace)
                GoTo Fine1
            End Try
        Else
            '   T1B.Filter = ""
            '   T1A = T1B
        End If
        Try
            If icod = 24 Or icod = 25 Then
                '  T1A.Filter = ""
            ElseIf icod < 20 Then
                key = "PermittedVIII1"
                Campo = CampiASME(key)
                Campo = CercaCampo(key, Campo, T1B)
                If Campo = "" Then Exit Sub
                Campo = "[" & Campo & "]"
                If dvT1B.RowFilter.Trim.Length > 0 Then
                    dvT1B.RowFilter = dvT1B.RowFilter & " AND " & Campo & "<>'NP'"
                Else
                    dvT1B.RowFilter = Campo & "<>'NP'"
                End If
            Else
                key = "PermittedVIII2"
                Campo = CampiASME(key)
                Campo = CercaCampo(key, Campo, T1B)
                If Campo = "" Then Exit Sub
                Campo = "[" & Campo & "]"
                If dvT1B.RowFilter.Trim.Length > 0 Then
                    dvT1B.RowFilter = dvT1B.RowFilter & " AND " & Campo & "<>'NP'"
                Else
                    dvT1B.RowFilter = Campo & "<>'NP'"
                End If
            End If
            Try
                PrintLine(ilog, "Selezionati dai precedenti" & Str(dvT1B.Count) & " records per i materiali permessi nella divisione applicabile")
            Catch e As Exception
                MsgBox("Errore alla seconda selezione: " & e.message)
                GoTo Fine1
            End Try
            key = "NominalComposition"
            Campo = CampiASME(key)
            Campo = CercaCampo(key, Campo, T1B)
            If Campo = "" Then Exit Sub
            'Campo = "[" & Campo & "]"
            CampoNC = Campo
            key = "SpecNo"
            Campo = CampiASME(key)
            Campo = CercaCampo(key, Campo, T1B)
            If Campo = "" Then Exit Sub
            'Campo = "[" & Campo & "]"
            CampoSN = Campo
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
        Select Case icod
            Case 1
                Try
                    dvT1B.RowFilter = dvT1B.RowFilter & " AND NOT Alto"
                Catch e As Exception
                    MsgBox("Errore alla terza selezione: " & e.message)
                    GoTo Fine1
                End Try
                PrintLine(ilog, "Selezionati dai precedenti" & Str(dvT1B.Count) & " records per i materiali per lamiere in acciai al C e basso-legati.")
            Case 2
                Try
                    dvT1B.RowFilter = dvT1B.RowFilter & " AND Alto"
                Catch e As Exception
                    MsgBox("Errore alla quarta selezione: " & e.message)
                    GoTo Fine1
                End Try
                PrintLine(ilog, "Selezionati dai precedenti" & Str(dvT1B.Count) & " records per i materiali per lamiere in acciai alto-legati e inossidabili.")
            Case 4, 6, 7, 8, 11 To 19, 21, 22, 23, 24, 25
                '                T1B.Filter = ""
                '               T1A = T1B
        End Select
        PrintLine(ilog, "-----------------------------------------------")
        Try
            cmd = New OleDbDataAdapter("SELECT * FROM Testate", MatASME)
            cmd.Fill(Testa)
            dvTesta = New DataView(Testa)
            dvTesta.Sort = "Tabella"
            iFoundT = dvTesta.Find(Tabella)
            If iFoundT = -1 Then Stop
            drvTesta = dvTesta(iFoundT)
        Catch e As Exception
            MsgBox("Errore all'apertura di Testate: " & e.message)
            GoTo fine1
        End Try
        Try
            'cerca primo indice libero
            cmd = New OleDbDataAdapter("SELECT Ind from ListaMat ORDER BY Ind", MatBase)
            cmd.Fill(r)
            ii = CShort(CShort(r.Rows(r.Rows.Count - 1)("Ind")) + 1)
            ' r.Dispose()
        Catch e As Exception
            MsgBox("Errore alla ricerca del primo indice libero: " & e.message)
            GoTo fine1
        End Try
        PrintLine(ilog, "primo indice libero:" & Str(ii))
        PrintLine(ilog, "---------------------------")
        '-------------------------
        Try
            cmdc = New OleDbDataAdapter("SELECT * FROM Caract", MatBase)
            cmdc.Fill(c)
            CBc = New OleDbCommandBuilder(cmdc)
            dvc = New DataView(c)
            dvc.Sort = "ID"
            cmd = New OleDbDataAdapter("SELECT * FROM Notes", MatBase)
            cmd.Fill(Nts)
            dvNts = New DataView(Nts)
            dvNts.Sort = "ID"
            cmdRN = New OleDbDataAdapter("SELECT * FROM IndNote", MatBase)
            cmdRN.Fill(RegNote)
            CBRN = New OleDbCommandBuilder(cmdRN)
            dvRegNote = New DataView(RegNote)
            dvRegNote.Sort = "ID"
            cmdV = New OleDbDataAdapter("SELECT * FROM Valori", MatBase)
            cmdV.Fill(V)
            CBV = New OleDbCommandBuilder(cmdV)
            dvV = New DataView(V)
            dvV.Sort = "ID"
            Dummy = CInt(V.Rows(0)("ID"))
            cmdd = New OleDbDataAdapter("SELECT * FROM DirectCH", MatBase)
            cmdd.Fill(d)
            CBd = New OleDbCommandBuilder(cmdd)
            dvd = New DataView(d)
        Catch e As Exception
            MsgBox("Errore alle aperture subordinate: " & e.message)
            GoTo fine1
        End Try
        Try
            Apri()
            frmUpdate.DefInstance.txtTotal.Text = dvT1B.Count.ToString
            frmUpdate.DefInstance.txticod.Text = icod.ToString
            For i = 0 To CShort(dvT1B.Count - 1)
                frmUpdate.DefInstance.txti.Text = i.ToString
                If IsDBNull(dvT1B(i)(CampoSN)) Then GoTo Cont
                If Len(Trim$(CStr(dvT1B(i)(CampoSN)))) = 0 Then GoTo cont
                drvT1B = dvT1B(i)
                'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
                'If IsDBNull(T1A.Fields("TypeGrade").Value) Then T1A.MoveNext() : GoTo Cont
                'If InStr(CStr(T1A.Fields("TypeGrade").Value), "26-3-3") = 0 Then T1A.MoveNext() : GoTo cont
                'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
                Dim iFld As Short, drvcID As Integer
                Select Case icod
                    Case 1 To 20
                        SuperSpec(i)
                        If newmode And Yes Then
                            PrintLine(ilog, SpecN + " | " + CStr(drvT1B(CampoSN)))
                            EseguiVariazioni()
                            FaiFai()
                            Pulisci2()
                            cmdc.Update(c)
                            cmdd.Update(d)
                            Apri()
                            GoTo Cont
                        ElseIf Not newmode Then
                            PrintLine(ilog, SpecN)
                            SpecNuda = SpecN
                            ' WildCards()
                            'SpecNuda = Left$(SpecNuda, 9)
                            dvr.RowFilter = "Mat LIKE '" & SpecNuda & "'" ' INNER
                            If icod = 8 Then
                                dvr.RowFilter = dvr.RowFilter & " AND Product LIKE '" & CStr(dvT1B(i)(CampoPr))
                            End If
                        End If
                        Yes = dvr.Count = 1
                        If Not Yes Then
                            Approfondito(i)
                            If Yes Then
                                drvr.BeginEdit()
                                drvr("Mat") = SpecN
                                drvr.EndEdit()
                            End If
                        End If
                        If Yes Then
                            If IsDBNull(dvT1B(i)("notes")) Then strNotes = "" Else strNotes = CStr(dvT1B(i)("notes"))
                            drvr.BeginEdit()
                            drvr("Notes") = strNotes
                            drvr.EndEdit()
                            CercaCodice()
                            If Yes Then RegistraNote()
                        End If
                        If Yes Then
                            EseguiVariazioni()
                            Pagine()
                            If Not Aggior Then
                                FaiFai()
                            End If
                        Else
                            PrintLine(ilog, "Il materiale " & SpecN & " è da aggiungere.")
                            Call Apri() : CercaAlfabeto()
                            If Yes Then
                                Fai()
                                ii = CShort(ii + 1)
                                If ii Mod 12 = 0 Then Ricrea()
                                Yes = False
                                FaiFai()
                            End If
                        End If
                    Case 21, 22, 23
                        If newmode Then
                            SuperSpec(i)
                            If Yes Then
                                EseguiVariazioni()
                                FaiFai()
                                For iii = 1 To dvr.Count - 1
                                    Try
                                        iFld = -1
                                        drvr = dvr(iii)
                                        drvcID = CInt(drvc("ID"))
                                        CercaCodice(iFld)
                                        drvr.BeginEdit()
                                        drvr(iFieldCaract(iFld)) = drvcID
                                        drvr.EndEdit()
                                    Catch e As Exception
                                        MsgBox(e.Message + vbCrLf + e.StackTrace)
                                    End Try
                                Next
                            Else
                                Yes = dvr.Count = 1
                                If Not Yes Then
                                    Approfondito(i)
                                End If
                                If Yes Then
                                    If IsDBNull(dvT1B(i)("notes")) Then strNotes = "" Else strNotes = CStr(dvT1B(i)("notes"))
                                    drvr.BeginEdit()
                                    drvr("Notes2") = strNotes
                                    drvr.EndEdit()
                                    CercaCodice()
                                    If Yes Then RegistraNote()
                                End If
                                If Yes Then
                                    EseguiVariazioni()
                                    Pagine()
                                    If Not Aggior Then
                                        FaiFai()
                                    End If
                                Else
                                    PrintLine(ilog, "Il materiale div.2 " & SpecN & " è da aggiungere.")
                                    Call Apri() : CercaAlfabeto()
                                    If Yes Then
                                        Fai()
                                        ii = CShort(ii + 1)
                                        If ii Mod 12 = 0 Then Ricrea()
                                        Yes = False
                                        FaiFai()
                                    End If
                                End If
                            End If
                        Else
                            Criterio = "Spec='" + CStr(dvT1B(i)(CampoSN)) + "'"
                            If icod <> 22 Then
                                If Not IsDBNull(dvT1B(i)(CampoTG)) Then
                                    If Len(Trim$(CStr(dvT1B(i)(CampoTG)))) > 0 Then
                                        Criterio = Criterio & " AND TypeGrade='" + CStr(dvT1B(i)(CampoTG)) + "'"
                                    End If
                                End If
                            End If
                            If Not IsDBNull(dvT1B(i)(CampoAU)) Then
                                If Len(Trim$(CStr(dvT1B(i)(CampoAU)))) > 0 Then
                                    Criterio = Criterio & " AND AlloyUNS='" + CStr(dvT1B(i)(CampoAU)) + "'"
                                End If
                            End If
                            If Not IsDBNull(dvT1B(i)(CampoCl)) Then
                                If Len(Trim$(CStr(dvT1B(i)(CampoCl)))) > 0 Then
                                    Criterio = Criterio & " AND ClassCondTemp='" + CStr(dvT1B(i)(CampoCl)) + "'"
                                End If
                            End If
                            If icod <> 23 Then
                                If InStr(CStr(dvT1B(i)(CampoPr)), "ube") > 0 Then
                                    Criterio = Criterio & " AND Product='" + CStr(dvT1B(i)(CampoPr)) + "'"
                                End If
                            End If
                            dvr.RowFilter = Criterio
                            Print(ilog, "Ricerca sul Criterio: " & Criterio & ": ")
                            Fai3(i)
                        End If
                        ii = CShort(ii + 1)
                    Case 24, 25
                        Dim div As Integer
                        Dim Indx, Indy As Integer
                        If newmode Then
                            SuperSpec(i)
                            If Yes Then
                                Gia = False
                                For div = 1 To 2
                                    For iii = 0 To dvr.Count - 1
                                        If Not Gia Then
                                            iFld = -1
                                            CercaCodice(iFld, div)
                                            If iFld > -1 Then
                                                Fai4()
                                                drvcID = CInt(drvc("ID"))
                                                Gia = True
                                                Select Case icod
                                                    Case 24
                                                        Indx = CInt(drvc("IndTempy"))
                                                        Indy = CInt(drvc("IndSy"))
                                                    Case 25
                                                        Indx = CInt(drvc("IndTempU"))
                                                        Indy = CInt(drvc("IndU"))
                                                End Select
                                            End If
                                        Else
                                            Try
                                                iFld = -1
                                                drvr = dvr(iii)
                                                CercaCodice(iFld, div)
                                                If iFld > -1 Then
                                                    drvc.BeginEdit()
                                                    Select Case icod
                                                        Case 24
                                                            drvc("IndTempy") = Indx
                                                            drvc("IndSy") = Indy
                                                        Case 25
                                                            drvc("IndTempU") = Indx
                                                            drvc("IndU") = Indy
                                                    End Select
                                                    drvc.EndEdit()
                                                End If
                                            Catch e As Exception
                                                MsgBox(e.Message + vbCrLf + e.StackTrace)
                                            End Try
                                        End If
                                    Next
                                Next div
                            Else
                                Yes = dvr.Count > 0
                                If Not Yes Then
                                    Approfonditoy(i)
                                End If
                                If Yes Then
                                    drvr = dvr(0)
                                    For div = 1 To 2
                                        iFld = -1
                                        CercaCodice(iFld, div)
                                        If iFld > -1 Then
                                            FaiFai()
                                            Pagine()
                                            drvcID = CInt(drvc("ID"))
                                        End If
                                        For iii = 1 To dvr.Count - 1
                                            Try
                                                iFld = -1
                                                drvr = dvr(iii)
                                                CercaCodice(iFld, div)
                                                If iFld > -1 Then
                                                    drvr.BeginEdit()
                                                    drvr(iFieldCaract(iFld)) = drvcID
                                                    drvr.EndEdit()
                                                End If
                                                Pagine()
                                            Catch e As Exception
                                                MsgBox(e.Message + vbCrLf + e.StackTrace)
                                            End Try
                                        Next
                                    Next div
                                Else
                                    ' Stop
                                End If
                            End If
                        ElseIf Not IsDBNull(dvT1B(i)(CampoSN)) Then
                            Criterio = "Spec='" + CStr(dvT1B(i)(CampoSN)) + "'"
                            '  If InStr(Criterio, "/EN") = 0 Then
                            '     T1A.MoveNext
                            '     GoTo Cont
                            '  End If
                            If Not IsDBNull(dvT1B(i)(CampoTG)) Then
                                If Len(Trim(CStr(dvT1B(i)(CampoTG)))) > 0 Then Criterio = Criterio & " AND TypeGrade='" + CStr(dvT1B(i)(CampoTG)) + "'"
                            End If
                            If Not IsDBNull(dvT1B(i)(CampoAU)) Then
                                If Len(Trim(CStr(dvT1B(i)(CampoAU)))) > 0 Then Criterio = Criterio & " AND AlloyUNS='" & CStr(dvT1B(i)(CampoAU)) & "'"
                            End If
                            If Not IsDBNull(dvT1B(i)(CampoCl)) Then
                                If Len(Trim(CStr(dvT1B(i)(CampoCl)))) > 0 Then Criterio = Criterio & " AND ClassCondTemp='" & CStr(dvT1B(i)(CampoCl)) & "'"
                            End If
                            dvr.RowFilter = Criterio
                            Dim Testo(), Product As String
                            Dim iScelta As Boolean, Ris1() As Boolean
                            If Not IsDBNull(dvT1B(i)(CampoSi)) Then
                                If dvr.Count > 1 Then
                                    ReDim Testo(dvr.Count), Ris1(dvr.Count)
                                    For iii = 0 To dvr.Count - 1
                                        Testo(iii + 1) = CStr(dvr(iii)("Mat"))
                                        If Not IsDBNull(dvr(iii)("SizeThk")) Then
                                            If CStr(dvr(iii)("SizeThk")).Trim.Length > 0 Then
                                                Testo(iii + 1) = Testo(iii + 1) + "/" + CStr(dvr(iii)("SizeThk")) + "/"
                                            End If
                                        End If
                                        Product = "" : If Not IsDBNull(dvr(iii)("Product")) Then Product = CStr(dvr(iii)("Product"))
                                        Testo(iii + 1) = Testo(iii + 1) + Product + "/"
                                    Next
                                    iScelta = Monitor.Motore.CheckQuale(CShort(dvr.Count), CStr(dvT1B(i)(CampoSi)) + "|" + CStr(dvT1B(i)(CampoPr)) + "|", Testo, Ris1, "")
                                Else
                                    ReDim Ris1(1)
                                    Ris1(1) = True
                                End If
                            End If
                            Dim ij, ik As Integer
                            If dvr.Count > 0 Then
                                Gia = False
                                For ik = 0 To dvr.Count - 1
                                    If Ris1(ik + 1) Then
                                        drvr = dvr(ik)
                                        Try
                                            Log1 = InStr(CStr(dvr(ik)("Product")), CStr(dvT1B(i)(CampoPr))) > 0 Or _
                                            InStr(CStr(dvr(ik)("Product")), CStr(dvT1B(i)(CampoPr))) > 0
                                            If Not Log1 Then Log1 = InStr(UCase(CStr(dvT1B(i)(CampoPr))), "WLD") > 0 And _
                                            InStr(UCase(CStr(dvT1B(i)(CampoPr))), "WLD") > 0
                                            If Not Log1 Then Log1 = InStr(UCase(CStr(dvT1B(i)(CampoPr))), "SMLS") > 0 _
                                            And InStr(UCase(CStr(dvT1B(i)(CampoPr))), "SMLS") > 0
                                        Catch e As Exception
                                            Log1 = True
                                        End Try
                                        If Log1 Then
                                            For ij = 1 To NumMaxCaract
                                                If Not IsDBNull(dvr(ik)(iFieldCaract(ij))) Then
                                                    If CSng(dvr(ik)(iFieldCaract(ij))) > 0 Then
                                                        iFoundc = dvc.Find(dvr(ik)(iFieldCaract(ij)))
                                                        If Not Gia Then
                                                            If iFoundc > -1 Then
                                                                drvc = dvc(iFoundc)
                                                                Fai4()
                                                                Gia = True
                                                                Select Case icod
                                                                    Case 24
                                                                        Indx = CInt(drvc("IndTempy"))
                                                                        Indy = CInt(drvc("IndSy"))
                                                                    Case 25
                                                                        Indx = CInt(drvc("IndTempU"))
                                                                        Indy = CInt(drvc("IndU"))
                                                                End Select
                                                            End If
                                                        Else
                                                            If iFoundc > -1 Then
                                                                drvc = dvc(iFoundc)
                                                                drvc.BeginEdit()
                                                                Select Case icod
                                                                    Case 24
                                                                        drvc("IndTempy") = Indx
                                                                        drvc("IndSy") = Indy
                                                                    Case 25
                                                                        drvc("IndTempU") = Indx
                                                                        drvc("IndU") = Indy
                                                                End Select
                                                                drvc.EndEdit()
                                                            End If
                                                        End If
                                                    End If
                                                End If
                                            Next
                                            Pagine()
                                        End If
                                    End If
                                Next
                            End If
                        End If
                        ii = CShort(ii + 1)
                End Select
                cmdc.Update(c)
                cmdd.Update(d)
                cmdV.Update(V)
                Apri()
Cont:       Next i
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
Fine:   If (Not (icod < 9 And icod > 1) And icod < 21) Or icod = 8 Then EsaminaVecchi()
Fine1:  MatASME.Close()
        MatBase.Close()
        FileClose(ilog)
    End Sub
    Private Sub EsaminaVecchi()
        Dim i, ii, iii As Integer
        Dim Lista As New StringDictionary
        Apri()
        For iii = 1 To 2
            Select Case icod
                Case 21, 22, 23
                    Select Case iii
                        Case 1 : jCodes = Codes.div2psi
                        Case 2 : jCodes = Codes.div2MPa
                    End Select
                Case Else
                    Select Case iii
                        Case 1 : jCodes = Codes.div1psi
                        Case 2 : jCodes = Codes.div1MPa
                    End Select
            End Select
            For ii = 0 To dvr.Count - 1
                drvr = dvr(ii)
                For i = 1 To NumMaxCaract
                    iFoundc = dvc.Find(drvr(iFieldCaract(i)))
                    If iFoundc > -1 Then
                        drvc = dvc(iFoundc)
                        If CType(drvc("Codice"), Codes) = j Then
                            Try
                                If IsDBNull(drvc("Source")) Then
                                    Lista.Add(CStr(drvr("Mat")), CStr(drvr("Ind")))
                                ElseIf InStr(CStr(drvc("Source")), Source) = 0 Then
                                    Lista.Add(CStr(drvr("Mat")), CStr(drvr("Ind")))
                                End If
                            Catch e As ArgumentException
                                Exit For
                            Catch e As Exception
                                MsgBox("EsaminaVecchi: " + e.Message)
                                Exit Sub
                            End Try
                        End If
                    End If
                Next
            Next ii
        Next iii
        Dim f As frmEliminaVecchi = New frmEliminaVecchi
        f.Lista = Lista
        f.ShowDialog()
        f.Close()
    End Sub
    Private Sub Manuale(ByRef Problema As Integer, ByRef Esito As Integer, ByVal ii As Integer)
        Dim rsCandidati As New DataTable("ListaMat")
        ' 1 grado, 2 UNS, 3 Classe, 4 Size, 5 Note
        Dim myDataColumn As DataColumn
        Dim i As Integer
        For i = 1 To 6
            myDataColumn = New DataColumn
            myDataColumn.DataType = System.Type.GetType("System.String")
            Select Case i
                Case 1 : myDataColumn.ColumnName = "Materiale"
                Case 2 : myDataColumn.ColumnName = "Grade"
                Case 3 : myDataColumn.ColumnName = "UNS"
                Case 4 : myDataColumn.ColumnName = "Class"
                Case 5 : myDataColumn.ColumnName = "Size"
                Case 6 : myDataColumn.ColumnName = "Notes"
            End Select
            myDataColumn.ReadOnly = True
            myDataColumn.Unique = False
            rsCandidati.Columns.Add(myDataColumn)
        Next
        Dim dvCandidati As DataView = New DataView(rsCandidati)
        Dim drv As DataRowView
        For i = 0 To dvr.Count - 1
            drv = dvCandidati.AddNew
            '            myDataRow = rsCandidati.NewRow()
            drv(0) = dvr(i)("Mat")
            drv(1) = dvr(i)("TypeGrade")
            drv(2) = dvr(i)("AlloyUNS")
            drv(3) = dvr(i)("ClassCondTemp")
            drv(4) = dvr(i)("SizeThk")
            drv(5) = dvr(i)("Notes")
            drv.EndEdit()
            'rsCandidati.Rows.Add(myDataRow)
        Next
        Try
            Dim f As frmNonTrovato = New frmNonTrovato
            f.rsCandidati = rsCandidati
            f.dvCandidati = dvCandidati
            f.T1a = drvT1B
            f.ShowDialog()
            If f.Nuovo Then
                Esito = 1
            Else
                Esito = 2
                drvr = dvr(f.RowIndex)
                If newmode Then
                    Pagine()
                Else
                    drvr.BeginEdit()
                    If icod <> 22 Then drvr("Typegrade") = drvT1B(CampoTG)
                    drvr("AlloyUNS") = drvT1B(CampoAU)
                    drvr("ClassCondTemp") = drvT1B(CampoCl)
                    drvr("SizeThk") = drvT1B(CampoSi)
                    drvr("Notes") = drvT1B("Notes")
                    ' SuperSpec(CShort(ii))
                    drvr("Mat") = SpecNN
                    drvr.EndEdit()
                End If
            End If
        Catch e As Exception
            MsgBox("Manuale: " + e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Private Sub CercaPoi()
        Dim i As Integer
        Try
            For i = 0 To dvr.Count - 1
                Spec = CStr(dvr(i)("Mat"))
                CercaCodice()
                Ord1 = CSng(dvr(i)("Ordinamento"))
                If Yes Then
                    Select Case icod
                        Case 1 To 9
                            If Left(Spec, 2) = "A " Then Spec = "S" & Spec
                        Case 11 To 19
                            If Left(Spec, 2) = "B " Then Spec = "S" & Spec
                    End Select
                    If Funzioni.Adjust(Spec, CShort(Len(SpecN))) > SpecN Then
                        Exit Sub
                    End If
                    Ord = CSng(dvr(i)("Ordinamento"))
                End If
            Next i
            Ord1 = -1
            Yes = True
        Catch e As Exception
            MsgBox("CercaPoi:" + e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Private Sub CreaSpec()
        Dim n As Integer
        Try
            SpecN = CStr(drvT1B(CampoSN))
            n = InStr(SpecN, "-")
            If n > 0 Then Mid(SpecN, n, 1) = " "
            SpecN = Trim(SpecN)
            SpecNNN = SpecN
            If Vera Then Grado = False : Classe = False : Size = False : UNS = False
            If Not icod = 22 Then
                If Len(Trim(CStr(drvT1B(CampoTG)))) > 0 Then
                    'If CStr(drvT1B(CampoTG)) = "410S" Then Stop
                    SpecN = SpecN & " Gr." & Trim(CStr(drvT1B(CampoTG)))
                    If Vera Then Grado = True
                End If
            End If
            If Len(Trim(CStr(drvT1B(CampoCl)))) > 0 Then
                SpecN = SpecN & " Cl." & Trim(CStr(drvT1B(CampoCl)))
                If Vera Then Classe = True
            End If
            If Len(Trim(CStr(drvT1B(CampoSi)))) > 0 Then
                SpecN = SpecN & " " + CStr(drvT1B(CampoSi))
                If Vera Then [Size] = True
            End If
        Catch e As Exception
            MsgBox("CreaSpec:" + e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Private Sub RegistraNote()
        Dim Buffer As String, nn As Integer, i As Integer, j As Integer
        If Len(Trim(strNotes)) = 0 Then Exit Sub
        If TabNota = "" Then Exit Sub
        Try
            Buffer = strNotes
            i = 0
            Do
                nn = InStr(Buffer, ",")
                If nn > 0 Then
                    strNota = Left(Buffer, nn - 1)
                    Buffer = Trim(Right(Buffer, Len(Buffer) - nn))
                Else
                    If Buffer = strNota Then
                        If i = 0 Then AddNota(i)
                        If i = 0 Then Exit Do
                        For j = i + 1 To 8
                            drvRegNote(j) = 0
                        Next
                        drvRegNote.EndEdit()
                        If iFoundRegNote = -1 Then
                            cmdRN.Update(RegNote)
                            RegNote = New DataTable
                            cmdRN.Fill(RegNote)
                            dvRegNote = New DataView(RegNote)
                            dvRegNote.Sort = "ID"
                            drvRegNote = dvRegNote(RegNote.Rows.Count - 1)
                        End If
                        Dim DeviAggiornare As Boolean = IsDBNull(drvc("IndNote"))
                        If Not DeviAggiornare Then DeviAggiornare = CInt(drvc("IndNote")) <> CInt(drvRegNote("ID"))
                        If DeviAggiornare Then
                            Try
                                If drvc.IsEdit Then
                                    drvc("IndNote") = drvRegNote("ID")
                                Else
                                    drvc.BeginEdit()
                                    drvc("IndNote") = drvRegNote("ID")
                                    drvc.EndEdit()
                                End If
                            Catch e As Exception
                                Stop
                            End Try
                        End If
3020:                   Exit Do
                    End If
                    strNota = Trim(Buffer)
                End If
                AddNota(i)
            Loop
        Catch e As Exception
            MsgBox("RegistraNote:" + e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Private Sub AddNota(ByRef i As Integer)
        Try
            dvNts.RowFilter = "Tabella='" & TabNota & "' AND [note_abrv]='" & strNota & "'"
            If dvNts.Count > 0 Then
                i = i + 1
                If i = 1 Then
                    ' iFoundRegNote = dvRegNote.Find(dvc(iFoundc)("IndNote"))
                    iFoundRegNote = dvRegNote.Find(drvc("IndNote"))
                    If iFoundRegNote = -1 Then
                        drvRegNote = dvRegNote.AddNew()
                    Else
                        drvRegNote = dvRegNote(iFoundRegNote)
                        drvRegNote.BeginEdit()
                    End If
                End If
                If i < 9 Then
                    drvRegNote(i) = dvNts(0)("ID")
                Else
                    PrintLine(ilog, SpecN & ": nota " & strNota & " non registrata")
                End If
            End If
        Catch e As Exception
            MsgBox("AddNota:" + e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Private Sub CercaCodice(Optional ByRef ifield As Short = 0, Optional ByVal div As Integer = 0)
        Dim i, iii As Integer
        Try
            If Metrico Then iii = 2 Else iii = 1
            Select Case icod
                Case 21, 22, 23
                    Select Case iii
                        Case 1 : jCodes = Codes.div2psi
                        Case 2 : jCodes = Codes.div2MPa
                    End Select
                Case 24, 25
                    Select Case div
                        Case 0 : Stop
                        Case 1
                            Select Case iii
                                Case 1 : jCodes = Codes.div1psi
                                Case 2 : jCodes = Codes.div1MPa
                            End Select
                        Case 2
                            Select Case iii
                                Case 1 : jCodes = Codes.div2psi
                                Case 2 : jCodes = Codes.div2MPa
                            End Select
                    End Select
                Case Else
                    Select Case iii
                        Case 1 : jCodes = Codes.div1psi
                        Case 2 : jCodes = Codes.div1MPa
                    End Select
            End Select
            Dim Nuovo As Boolean = True
            drvc = Nothing
            For i = 1 To NumMaxCaract
                If IsDBNull(drvr(iFieldCaract(i))) Then Exit For
                If CInt(drvr(iFieldCaract(i))) > 0 Then
                    iFoundc = dvc.Find(drvr(iFieldCaract(i)))
                    If iFoundc > -1 Then
                        If CType(dvc(iFoundc)("Codice"), Codes) = jCodes Then
                            drvc = dvc(iFoundc)
                            Nuovo = False
                            Yes = True
                            ifield = CShort(i)
                            Exit Sub
                        End If
                    End If
                End If
            Next
            If icod > 23 Then Exit Sub
            For i = 1 To NumMaxCaract
                If IsDBNull(drvr(iFieldCaract(i))) Then Exit For
                If CInt(drvr(iFieldCaract(i))) > 0 Then
                    iFoundc = dvc.Find(drvr(iFieldCaract(i)))
                    If iFoundc = -1 Then Exit For
                    If CType(dvc(iFoundc)("Codice"), Codes) = Codes.NonDef Then
                        drvc = dvc(iFoundc)
                        Nuovo = False
                        Yes = True
                        Exit For
                    End If
                Else
                    Exit For
                End If
            Next
            If ifield = -1 Then ifield = CShort(i) : Exit Sub
            If Not drvc Is Nothing Then
                drvc.BeginEdit()
            Else
                drvc = dvc.AddNew()
            End If
            drvc("Codice") = jCodes
            drvc("Source") = Sorgente
            drvc("MWDTrule") = " "
            drvc("MWDTclause") = " "
            drvc("PNumber") = " "
            drvc("GroupNb") = " "
            drvc.EndEdit()
            If Nuovo Then
                cmdc.Update(c)
                c = New DataTable
                cmdc.Fill(c)
                dvc = New DataView(c)
                dvc.Sort = "ID"
                drvc = dvc(c.Rows.Count - 1)
                drvr.BeginEdit()
                drvr(iFieldCaract(i)) = CInt(drvc("ID"))
                drvr.EndEdit()
            End If
            Yes = True
        Catch e As Exception
            MsgBox("CercaCodice:" + e.Message + vbCrLf + e.StackTrace)
            Yes = False
        End Try
    End Sub
    Private Sub WildCards()
        Dim i As Integer
        Try
            For i = 1 To Len(SpecNuda) - 1
                If Mid(SpecNuda, i, 1) = " " Then
                    If Mid(SpecNuda, i + 1, 1) = " " Then
                        SpecNuda = Left(SpecNuda, i - 1) & Right(SpecNuda, Len(SpecNuda) - i - 1)
                        WildCards()
                    End If
                    ' ElseIf Mid$(SpecNuda, i + 1, 1) = "-" Then
                    '    Mid$(SpecNuda, i + 1, 1) = " "
                End If
            Next
        Catch e As Exception
            MsgBox("WildCards:" + e.Message)
        End Try
    End Sub
    Private Sub Pagine()
        Try
            pagina = "P" & Tabella
            Riga = "R" & Tabella
            ' If Not IsNull(drvr(pagina)) Then Stop
            drvr.BeginEdit()
            drvr(pagina) = drvT1B(Campopg)
            drvr(Riga) = drvT1B(Camporg)
            drvr("Spec") = drvT1B(CampoSN)
            drvr.EndEdit()
        Catch e As Exception
            MsgBox("Pagine:" + e.Message)
        End Try
    End Sub
    Private Sub Apri()
        Dim sql As String = ""
        If Not cmdr Is Nothing Then cmdr.Update(r)
        Try
            Select Case icod
                Case 1
                    sql = "SELECT * from ListaMat WHERE Classe=1 ORDER BY Ordinamento"
                Case 2, 11, 12
                    sql = "SELECT * from ListaMat WHERE Classe=2 ORDER BY Ordinamento"
                Case 4, 14
                    sql = "SELECT * from ListaMat WHERE Classe=4 ORDER BY Ordinamento"
                Case 6, 16
                    sql = "SELECT * from ListaMat WHERE Classe=6 ORDER BY Ordinamento"
                Case 7, 17
                    sql = "SELECT * from ListaMat WHERE Classe=7 ORDER BY Ordinamento"
                Case 8, 23
                    sql = "SELECT * from ListaMat WHERE Classe=8 ORDER BY Ordinamento"
                Case 21, 22, 24, 25
                    sql = "SELECT * from ListaMat ORDER BY Ordinamento"
            End Select
            cmdr = New OleDbDataAdapter(sql, MatBase)
            r = New DataTable
            cmdr.Fill(r)
            dvr = New DataView(r)
            CBr = New OleDbCommandBuilder(cmdr)
        Catch e As Exception
            MsgBox("Apri(): " + e.Message)
        End Try
    End Sub
    Private Sub Ammiss()
        Dim nn As Integer, i As Integer, nn1 As Integer, j As Integer
        Try
            nn = CInt(drvTesta("NumeroDati"))
            Dim nm As Integer = CInt(drvTesta("StartPos")) - 1
            For i = 1 To 36
                Temp(i) = 0 : s(i) = 0
            Next
            For i = 1 To nn
                Temp(i) = Funzioni.ValVir(CStr(drvTesta(3 + i)))
                If IsDBNull(drvT1B(nm + i)) Then
                    s(i) = 0
                    Exit For
                Else
                    s(i) = Funzioni.ValVir(CStr(drvT1B(nm + i)))
                End If
            Next
            nn1 = nn
            For i = 1 To nn
                If s(i) = 0 Then
                    nn1 = nn1 - 1
                    For j = i To nn1
                        Temp(j) = Temp(j + 1)
                        s(j) = s(j + 1)
                    Next
                    i = i - 1
                    If i >= nn1 Then Exit For
                    s(nn1 + 1) = 0
                    Temp(nn1 + 1) = 0
                End If
            Next
            If nn1 < nn Then
                If s(nn1 + 1) = 0 Then Temp(nn1 + 1) = 0
            End If
            nn1 = nn
            For i = 2 To nn - 1
                If s(i) = s(i + 1) And s(i) = s(i - 1) Then
                    nn1 = nn1 - 1
                    For j = i To nn1
                        Temp(j) = Temp(j + 1)
                        s(j) = s(j + 1)
                    Next
                    i = i - 1
                    If i >= nn1 Then Exit For
                    s(nn1) = 0
                    Temp(nn1) = 0
                End If
            Next
        Catch e As Exception
            MsgBox("Ammiss:" + e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Private Sub Fai4()
        Dim i As Integer, Yes1 As Boolean
        Dim c1, c2 As Codes
        Try
            If Metrico Then
                Mille = 1
                c1 = Codes.div1MPa
                c2 = Codes.div2MPa
            Else
                Mille = 1000
                c1 = Codes.div1psi
                c2 = Codes.div2psi
            End If
            If CType(drvc("Codice"), Codes) = c1 Or CType(drvc("Codice"), Codes) = c2 Then
                Ammiss()
                Select Case icod
                    Case 24
                        If CSng(drvc("Yield")) <> CSng(Funzioni.ValVir(CStr(drvT1B(CampoMY))) * Mille) Then
                            ' If CSng(drvc("Yield")) = 0 Then
                            drvc.BeginEdit()
                            drvc("Yield") = CSng(Funzioni.ValVir(CStr(drvT1B(CampoMY))) * Mille)
                            drvc.EndEdit()
                            'Else
                            '   Stop
                            'End If
                        End If
                        ' If CInt(drvc("IndTempy")) = Dummy Then
                        'drvV = dvV.AddNew()
                        'Else
                        iFoundV = dvV.Find(drvc("IndTempy"))
                        If iFoundV = -1 Or rinnovo Then
                            drvV = dvV.AddNew()
                            Yes1 = True
                        Else
                            drvV = dvV(iFoundV)
                            drvV.BeginEdit()
                            Yes1 = False
                        End If
                        'End If
                    Case 25
                        If CSng(drvc("US")) <> CSng(Funzioni.ValVir(CStr(drvT1B(CampoUS))) * Mille) Then
                            ' If CSng(drvc("US")) = 0 Then
                            drvc.BeginEdit()
                            drvc("US") = CSng(Funzioni.ValVir(CStr(drvT1B(CampoUS))) * Mille)
                            drvc.EndEdit()
                            'Else
                            '   Stop
                            'End If
                        End If
                        iFoundV = dvV.Find(drvc("IndTempU"))
                        If iFoundV = -1 Or rinnovo Then
                            drvV = dvV.AddNew()
                            Yes1 = True
                        Else
                            drvV = dvV(iFoundV)
                            drvV.BeginEdit()
                            Yes1 = False
                        End If
                End Select
                For i = 1 To 24
                    drvV(i) = Temp(i)
                Next
                drvV.EndEdit()
                drvc.BeginEdit()
                If Yes1 Then
                    cmdV.Update(V)
                    V = New DataTable
                    cmdV.Fill(V)
                    CBV = New OleDbCommandBuilder(cmdV)
                    dvV = New DataView(V)
                    dvV.Sort = "ID"
                    drvV = dvV(V.Rows.Count - 1)
                    Select Case icod
                        Case 24 : drvc("IndTempY") = drvV("ID")
                        Case 25 : drvc("IndTempU") = drvV("ID")
                    End Select
                End If
                Select Case icod
                    Case 24
                        iFoundV = dvV.Find(drvc("IndSy"))
                    Case 25
                        iFoundV = dvV.Find(drvc("IndU"))
                End Select
                If iFoundV = -1 Or rinnovo Then
                    drvV = dvV.AddNew()
                    Yes1 = True
                Else
                    drvV = dvV(iFoundV)
                    drvV.BeginEdit()
                    Yes1 = False
                End If
                For i = 1 To 24
                    drvV(i) = s(i) * Mille
                Next
                drvV.EndEdit()
                If Yes1 Then
                    cmdV.Update(V)
                    V = New DataTable
                    cmdV.Fill(V)
                    CBV = New OleDbCommandBuilder(cmdV)
                    dvV = New DataView(V)
                    dvV.Sort = "ID"
                    drvV = dvV(V.Rows.Count - 1)
                    Select Case icod
                        Case 24 : drvc("IndSy") = drvV("ID")
                        Case 25 : drvc("IndU") = drvV("ID")
                    End Select
                End If
                drvc.EndEdit()
            End If
        Catch e As Exception
            MsgBox("Fai4:" + e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Private Sub UpDateSource()
        Dim lSource As String = Source
        If Len(Trim(CStr(drvT1B(CampoAd)))) > 3 Then
            lSource = Source & " " & Right(Trim(CStr(drvT1B(CampoAd))), 3)
        ElseIf Len(Trim(CStr(drvT1B(CampoAd)))) > 1 Then
            lSource = Source & " " & Trim(CStr(drvT1B(CampoAd)))
        ElseIf Len(Trim(CStr(drvT1B(CampoAd)))) = 1 Then
            '   Source = Source & " A0" & Trim(CStr(drvT1B(CampoAd)))
        End If
        drvc("Source") = lSource
    End Sub
    Private Sub UpdateCaract()
        Try
            If Metrico Then Mille = 1 Else Mille = 1000
            drvc("Codice") = jCodes
            If Not newmode Then UpDateSource()
            If Not IsDBNull(drvT1B(CampoMY)) Then
                If IsDBNull(drvc("Yield")) Then drvc("Yield") = 0
                If Not CSng(drvc("Yield")) = CSng(Funzioni.ValVir(CStr(drvT1B(CampoMY))) * Mille) Then
                    If Yes Then PrintLine(ilog, "Min Yield Strength was :" & Format(drvc("Yield")) & " updated to:" & Format(Funzioni.ValVir(CStr(drvT1B(CampoMY))) * Mille))
                    drvc("Yield") = Funzioni.ValVir(CStr(drvT1B(CampoMY))) * Mille
                End If
            Else
                drvc("Yield") = 0.0
            End If
            If Not IsDBNull(drvT1B(CampoUS)) Then
                If IsDBNull(drvc("US")) Then drvc("US") = 0
                If Not CSng(Funzioni.ValVir(CStr(drvc("US")))) = CSng(Funzioni.ValVir(CStr(drvT1B(CampoUS))) * Mille) Then
                    If Yes Then PrintLine(ilog, "Min Tensile Strength was :" & Format(drvc("US")) & " updated to:" & Format(Funzioni.ValVir(CStr(drvT1B(CampoUS))) * Mille))
                    drvc("US") = Funzioni.ValVir(CStr(drvT1B(CampoUS))) * Mille
                End If
            Else
                drvc("US") = 0.0
            End If
            If Not (icod = 8 Or icod > 22) Then
                key = "PNumber"
                Campo = CampiASME(key)
                Campo = CercaCampo(key, Campo, T1B)
                If Campo = "" Then Exit Sub
                'Campo = "[" & Campo & "]"
                CampoPN = Campo
                If Not IsDBNull(drvT1B(CampoPN)) Then
                    If IsDBNull(drvc("PNumber")) Then drvc("PNumber") = " "
                    If Not Trim(CStr(drvc("PNumber"))) = Trim(CStr(drvT1B(CampoPN))) Then
                        If Yes Then PrintLine(ilog, "PNumber was :" & CStr(drvc("PNumber")) & " updated to: " & CStr(drvT1B(CampoPN)))
                        drvc("PNumber") = drvT1B(CampoPN)
                    End If
                End If
                If icod > 9 And icod < 20 Or icod = 22 Then
                    drvc("GroupNb") = " "
                Else
                    If Not IsDBNull(drvc("GroupNb")) Then
                        key = "GroupNb"
                        Campo = CampiASME(key)
                        Campo = CercaCampo(key, Campo, T1B)
                        If Campo = "" Then Exit Sub
                        'Campo = "[" & Campo & "]"
                        CampoGN = Campo
                        If Not IsDBNull(drvT1B(CampoGN)) Then
                            If Not Trim(CStr(drvc("GroupNb"))) = Trim(CStr(drvT1B(CampoGN))) Then
                                If Yes Then PrintLine(ilog, "Group Number was :" & Format(drvc("GroupNb")) & " updated to:" & Format(drvT1B(CampoGN)))
                                drvc("GroupNb") = drvT1B(CampoGN)
                            End If
                        End If
                    End If
                End If
            Else
                drvc("PNumber") = " "
                drvc("GroupNb") = " "
            End If
            dvd.Sort = "Codice"
            If Not (icod = 8 Or icod = 23) Then
                key = "ExtPressureChart"
                Campo = CampiASME(key)
                Campo = CercaCampo(key, Campo, T1B)
                If Campo = "" Then Exit Sub
                'Campo = "[" & Campo & "]"
                CampoEP = Campo
                If Not IsDBNull(drvT1B(CampoEP)) Then
                    iFoundd = dvd.Find(CStr(drvT1B(CampoEP)))
                    If iFoundd > -1 Then
                        drvd = dvd(iFoundd)
                        If IsDBNull(drvc("IndChart")) Then drvc("IndChart") = -1
                        If Not CInt(drvc("IndChart")) = CInt(drvd("ID")) Then
                            If Yes Then PrintLine(ilog, "External Pressure Chart index was :" & _
                            Format(drvc("IndChart")) & " updated to:" & Format(drvd("ID")))
                            drvc("IndChart") = drvd("ID")
                        End If
                    Else
                        drvc("IndChart") = 0
                    End If
                Else
                    drvc("IndChart") = 0
                End If
            Else
                drvc("IndChart") = 0
            End If
        Catch e As Exception
            MsgBox("UpdateCaract:" + e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Private Sub EseguiVariazioni()
        Dim Sorg As String
        CercaCodice()
        Try
            If Not Yes Then
                PrintLine(ilog, "Caratteristiche per ASME VIII div.1 non trovate. ATTENZIONE")
                Stop
                Exit Sub
            Else
                If newmode Then
                    drvc.BeginEdit()
                    drvc("Source") = Sorgente
                    drvc.EndEdit()
                Else
                    If IsDBNull(drvT1B(CampoAd)) Then
                        Addenda = "Ed.2006"
                    Else
                        Addenda = CStr(drvT1B(CampoAd))
                    End If
                    If IsDBNull(drvc("Source")) Then Sorg = "" Else Sorg = CStr(drvc("Source"))
                    'Print #ilog, "Dati in memoria: " + Sorg + "; dati aggiornati: " + Addenda;
                    If Len(Trim(Addenda)) = 0 Then
                        Aggior = False
                    ElseIf InStr(Addenda, "A03") > 0 And InStr(Sorg, "A03") = 0 Then
                        Aggior = False
                    ElseIf InStr(Addenda, "A02") > 0 And InStr(Sorg, "A02") = 0 And InStr(Sorg, "A03") = 0 Then
                        Aggior = False
                    ElseIf Addenda = "01" And InStr(Sorg, "A01") = 0 And InStr(Sorg, "A02") = 0 And InStr(Sorg, "A03") = 0 Then
                        Aggior = False
                    ElseIf Addenda = "04" And InStr(Sorg, "A04") = 0 And InStr(Sorg, "A05") = 0 And InStr(Sorg, "A06") = 0 Then
                        Aggior = False
                        PrintLine(ilog, "Addenda: ", Addenda)
                    ElseIf InStr(Addenda, "A05") > 0 And InStr(Sorg, "A05") = 0 Then
                        Aggior = False
                    Else
                        Aggior = True
                    End If
                    If Not Aggior Then
                        PrintLine(ilog, " Dati da aggiornare")
                    Else
                        drvc.BeginEdit()
                        UpDateSource()
                        drvc.EndEdit()
                    End If
                End If
            End If
        Catch e As Exception
            MsgBox("EseguiVariazioni: " + e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Private Sub SuperSpec(ByVal i As Short)
        Dim Prod2, Prod1, prodNN As String
        Try
            pagina = "P" & Tabella
            Riga = "R" & Tabella
            If newmode Then
                dvr.RowFilter = pagina & "='" & CStr(drvT1B(Campopg)) & "' AND " _
                & Riga & "='" & CStr(drvT1B(Camporg)) + "'"
                Select Case icod
                    Case 21, 22, 23, 24, 25
                        Yes = dvr.Count > 0
                    Case Else
                        Yes = dvr.Count = 1
                End Select
                If Yes Then
                    drvr = dvr(0)
                    SpecN = CStr(drvr("Mat"))
                    If verboso Then verboso = Not MsgBox(SpecN + vbCrLf + CStr(drvT1B(CampoSN)), MsgBoxStyle.OKCancel) = MsgBoxResult.Cancel
                    frmUpdate.DefInstance.txtMat.Text = CStr(drvT1B(CampoSN))
                    System.Windows.Forms.Application.DoEvents()
                    Exit Sub
                Else
                    If icod <= 24 Then Exit Sub
                    SpecN = ""
                End If
            End If
            If i > 0 Then drvT1B = dvT1B(i - 1)
            Prod1 = "" : Prod2 = ""
            Vera = False
            CreaSpec()
            SpecN1 = SpecN
            Prod1 = "" : Allo1 = ""
            If icod <> 23 Then
                Prod1 = CStr(drvT1B(CampoPr))
                Allo1 = CStr(drvT1B(CampoAU))
            End If
            drvT1B = dvT1B(i)
            Vera = True
            CreaSpec()
            SpecNuda = SpecNNN
            SpecNN = SpecN
            prodNN = ""
            AlloN = ""
            If icod < 24 Then Exit Sub
            If icod <> 23 Then
                prodNN = CStr(drvT1B(CampoPr))
                AlloN = CStr(drvT1B(CampoAU))
            End If
            If i < dvT1B.Count - 1 Then drvT1B = dvT1B(i + 1)
            Vera = False
            CreaSpec()
            SpecN2 = SpecN
            Prod2 = "" : Allo2 = ""
            If icod <> 23 Then
                Prod2 = CStr(drvT1B(CampoPr))
                Allo2 = CStr(drvT1B(CampoAU))
            End If
            drvT1B = dvT1B(i)
            AggNote = False
            If (SpecN1 = SpecNN And Prod1 = prodNN And Allo1 = AlloN) Or (SpecN2 = SpecNN And Prod2 = prodNN And Allo2 = AlloN) Then
                If icod < 20 Then
                    If Not IsDBNull(drvT1B("Notes")) Then
                        If Not CStr(drvT1B("Notes")).Trim.Length = 0 Then
                            SpecNN = SpecNN & " n:" & Trim(CStr(drvT1B("Notes")))
                            AggNote = True
                        End If
                    Else
                    End If
                Else
                    If Not IsDBNull(drvT1B("Notes")) Then
                        If Not CStr(drvT1B("Notes")).Trim.Length = 0 Then
                            SpecNN = SpecNN & " n2:" & Trim(CStr(drvT1B("Notes")))
                            AggNote = True
                        End If
                    Else
                    End If
                End If
            End If
        Catch e As Exception
            MsgBox("SuperSpec:" + e.Message + vbCrLf + e.StackTrace)
        End Try
        SpecN = SpecNN
    End Sub
    Private Sub FaiFai()
        Dim i As Short
        Try
            If Yes Then
                drvr.BeginEdit()
                drvr("Obsoleto") = False
                ' Print #ilog, "Il materiale esisteva già in versione non obsoleta"
            Else
                PrintLine(ilog)
                PrintLine(ilog, "Il materiale non esisteva.")
                drvr = dvr.AddNew()
                drvr("Mat") = SpecN
                drvr("Ind") = ii
                Calcolaicod() 'Select Case icod
                '    Case 1, 2, 4, 6, 7, 8
                'drvr("Classe") = icod
                '    Case 11, 12
                'drvr("Classe") = 2
                '    Case 13 To 19
                'drvr("Classe") = icod - 10
                '    Case 23
                'drvr("Classe") = 8 ' icod1
                drvr("Classe") = icod1 'End Select
                drvr("Ordinamento") = Ord
                drvr.EndEdit()
                Pagine()
                Apri()
                dvr.Sort = "Mat"
                'dvr.RowFilter = ""
                iFoundr = dvr.Find(SpecN) ' AND NOT Obsoleto"
                'Ord1 = CSng(dvr(iFoundr)("Ordinamento"))
                'dvr.Sort = "Ordinamento"
                'iFoundr = dvr.Find(Ord1)
                'If iFoundr < 0 Then Stop
                'If iFoundr > 0 Then iFoundr -= 1
                drvr = dvr(iFoundr)
                'Ord1 = CSng(drvr("Ordinamento"))
                'If Ord1 = 0 Then
                'Ord1 = CInt(dvr(iFoundr + 1)("Ordinamento"))
                'End If
                'drvr = dvr(iFoundr + 1)
                'drvr("Ordinamento") = Ord1 + 0.25
                drvr.BeginEdit()
                drvr("Spec") = drvT1B(CampoSN)
                If icod = 22 Then
                    drvr("TypeGrade") = " "
                Else
                    drvr("TypeGrade") = CStr(drvT1B(CampoTG)) + " "
                End If
                drvr("ClassCondTemp") = CStr(drvT1B(CampoCl)) + " "
                drvr("SizeThk") = CStr(drvT1B(CampoSi)) + " "
                'r!Ordinamento = Ord
                Select Case icod
                    Case 1, 2
                        drvr("CAT") = "LA "
                    Case Else
                        drvr("CAT") = "XXX"
                End Select
                drvr("CT") = "XX"
                drvr("CMT") = "X00"
            End If
            drvr("Volta") = 1
            If icod < 21 Then
                If IsDBNull(drvr("Composiz")) Then drvr("Composiz") = ""
                If Yes And Not CStr(drvr("Composiz")) = CStr(drvT1B(CampoNC)) Then
                    PrintLine(ilog, "Composizione non aggiornata: " + CStr(drvr("Composiz")) + "; " + CStr(drvT1B(CampoNC)))
                End If
                drvr("Composiz") = drvT1B(CampoNC)
                If Len(drvr("Composiz")) = 0 Then drvr("Composiz") = " "
                If IsDBNull(drvr("Classe")) Then drvr("Classe") = 0
                If icod <> 23 Then
                    If IsDBNull(drvr("Product")) Then drvr("Product") = " "
                    If Yes And Not CStr(drvr("Product")) = CStr(drvT1B(CampoPr)) Then
                        PrintLine(ilog, "Condizioni di fornitura non aggiornate: " + CStr(drvr("Product")) + "; " + CStr(drvT1B(CampoPr)))
                    End If
                    drvr("Product") = drvT1B(CampoPr)
                End If
                If IsDBNull(drvr("AlloyUNS")) Then drvr("AlloyUNS") = ""
                If Yes And Not Trim(CStr(drvr("AlloyUNS"))) = Trim(CStr(drvT1B(CampoAU))) Then
                    PrintLine(ilog, "Codice UNS non aggiornato :" + CStr(drvr("AlloyUNS")) + "; " + CStr(drvT1B(CampoAU)))
                End If
                If Len(Trim(CStr(drvT1B(CampoAU)))) = 0 Then
                    drvr("AlloyUNS") = "..."
                Else
                    drvr("AlloyUNS") = drvT1B(CampoAU)
                End If
                If icod < 20 Then
                    If IsDBNull(drvT1B("notes")) Then strNotes = "" Else strNotes = CStr(drvT1B("notes"))
                    If IsDBNull(drvr("Notes")) Then drvr("Notes") = ""
                    If Yes And Not CStr(drvr("Notes")) = strNotes Then
                        PrintLine(ilog, "Note non aggiornate: " + CStr(drvr("Notes")) + "; " + strNotes)
                    End If
                    drvr("Notes") = strNotes
                ElseIf icod < 24 Then
                    If IsDBNull(drvT1B("notes")) Then strNotes = "" Else strNotes = CStr(drvT1B("notes"))
                    If IsDBNull(drvr("Notes2")) Then drvr("Notes2") = ""
                    If Yes And Not CStr(drvr("Notes2")) = strNotes Then
                        PrintLine(ilog, "Note div 2 non aggiornate: " + CStr(drvr("Notes2")) + "; " + strNotes)
                    End If
                    drvr("Notes2") = strNotes
                End If
                If Not icod = 22 Then
                    If IsDBNull(drvr("TypeGrade")) Then drvr("TypeGrade") = " "
                    If Yes And Not CStr(drvr("TypeGrade")).Trim = CStr(drvT1B(CampoTG)).Trim Then
                        PrintLine(ilog, "Grado non aggiornato: " + CStr(drvr("TypeGrade")) + "; " + CStr(drvT1B(CampoTG)))
                    End If
                    drvr("TypeGrade") = drvT1B(CampoTG)
                End If
                If IsDBNull(drvr("ClassCondTemp")) Then drvr("ClassCondTemp") = " "
                If Yes And Not CStr(drvr("ClassCondTemp")).Trim = CStr(drvT1B(CampoCl)).Trim Then
                    PrintLine(ilog, "Classe non aggiornata: " + CStr(drvr("ClassCondTemp")) + "; " + CStr(drvT1B(CampoCl)))
                End If
                drvr("ClassCondTemp") = drvT1B(CampoCl)
                If Not Metrico Then
                    If IsDBNull(drvr("SizeThk")) Then drvr("SizeThk") = " "
                    If Yes And Not CStr(drvr("SizeThk")) = CStr(drvT1B(CampoSi)) Then
                        PrintLine(ilog, "Grado non aggiornato: " + CStr(drvr("SizeThk")) + "; " + CStr(drvT1B(CampoSi)))
                    End If
                    drvr("SizeThk") = drvT1B(CampoSi)
                End If
            End If
            If Yes Then
                If Not newmode Then
                    iFoundc = dvc.Find(drvr("Caract1"))
                    drvc = dvc(iFoundc)
                End If
                drvc.BeginEdit()
            Else
                drvc = dvc.AddNew() : drvc.EndEdit()
                cmdc.Update(c)
                c = New DataTable : cmdc.Fill(c)
                dvc = New DataView(c)
                dvc.Sort = "ID"
                drvc = dvc(c.Rows.Count - 1)
                drvr("Caract1") = drvc("ID") : drvc.BeginEdit()
            End If
            If icod < 21 Then RegistraNote()
            If icod < 24 Then UpdateCaract()
            Ammiss()
            iFoundV = dvV.Find(drvc("IndTemp"))
            If iFoundV = -1 Or rinnovo Then
                drvV = dvV.AddNew()
                Yes1 = True
                If Yes Then PrintLine(ilog, "Il vettore delle temperature per la tabella degli ammissibili non era presente")
                Gia = True
            Else
                drvV = dvV(iFoundV)
                drvV.BeginEdit()
                Yes1 = False
                Gia = False
            End If
            For i = 1 To 24
                If IsDBNull(drvV(i)) Then drvV(i) = 0
                If Not (CSng(drvV(i)) = Temp(i)) Then
                    If Yes And Not Gia Then PrintLine(ilog, "Il vettore delle temperature per la tabella degli ammissibili non era aggiornato")
                    Gia = True
                    drvV(i) = Temp(i)
                End If
            Next
            drvV.EndEdit()
            If Yes1 Then
                cmdV.Update(V)
                V = New DataTable
                cmdV.Fill(V)
                CBV = New OleDbCommandBuilder(cmdV)
                dvV = New DataView(V)
                dvV.Sort = "ID"
                drvV = dvV(V.Rows.Count - 1)
                drvc("IndTemp") = drvV("ID")
            End If
            Gia = False : Yes1 = False
            iFoundV = dvV.Find(drvc("IndAmmis"))
            If iFoundV = -1 Or rinnovo Then
                drvV = dvV.AddNew()
                Yes1 = True
                If Yes Then PrintLine(ilog, "Il vettore degli ammissibili non era presente")
                Gia = True
            Else
                drvV = dvV(iFoundV)
                drvV.BeginEdit()
                Yes1 = False
            End If
            For i = 1 To 24
                If IsDBNull(drvV(i)) Then drvV(i) = 0
                If Not (CSng(drvV(i)) = s(i) * Mille) Then
                    drvV(i) = s(i) * Mille
                    If Yes And Not Gia Then PrintLine(ilog, "Il vettore degli ammissibili non era aggiornato")
                    Gia = True
                End If
            Next
            drvV.EndEdit()
            cmdV.Update(V)
            If Yes1 Then
                V = New DataTable
                cmdV.Fill(V)
                dvV = New DataView(V)
                dvV.Sort = "ID"
                drvV = dvV(V.Rows.Count - 1)
                drvc("IndAmmis") = drvV("ID")
            End If
            If Not Yes Then
                drvc("MWDTrule") = " "
                drvc("MWDTclause") = " "
            End If
            If Len(drvc("PNumber")) = 0 Then drvc("PNumber") = " "
            If IsDBNull(drvc("GroupNb")) Then drvc("GroupNb") = " "
            If Len(drvc("GroupNb")) = 0 Then drvc("GroupNb") = " "
            drvc.EndEdit()
            'If Not Yes Then
            'drvc = dvc.AddNew()
            'drvr("Caract2") = drvc("ID")
            'drvc("Codice") = 0
            'drvc("IndTemp") = Dummy
            'drvc("IndAmmis") = Dummy
            'drvc("IndTempy") = Dummy
            'drvc("IndSy") = Dummy
            'drvc("MWDTrule") = " "
            'drvc("MWDTclause") = " "
            'drvc("Source") = " "
            'drvc("PNumber") = " "
            'drvc("GroupNb") = " "
            'drvc.EndEdit()
            'drvc = dvc.AddNew()
            'drvr("Caract3") = drvc("ID")
            'drvc("Codice") = 0
            'drvc("IndTemp") = Dummy
            'drvc("IndAmmis") = Dummy
            'drvc("IndTempy") = Dummy
            'drvc("IndSy") = Dummy
            'drvc("MWDTrule") = " "
            'drvc("MWDTclause") = " "
            'drvc("Source") = " "
            'drvc("PNumber") = " "
            'drvc("GroupNb") = " "
            'drvc.EndEdit()
            'drvc = dvc.AddNew()
            'drvr("Caract4") = drvc("ID")
            'drvc("Codice") = 0
            'drvc("IndTemp") = Dummy
            'drvc("IndAmmis") = Dummy
            'drvc("IndTempy") = Dummy
            'drvc("IndSy") = Dummy
            'drvc("MWDTrule") = " "
            'drvc("MWDTclause") = " "
            'drvc("Source") = " "
            'drvc("PNumber") = " "
            'drvc("GroupNb") = " "
            'drvc.EndEdit()
            'End If
            drvr.EndEdit()
        Catch e As Exception
            MsgBox("FaiFai: " + e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Private Sub Approfondito(ByVal ii As Integer)
        Dim Esito As Integer
        Dim Filtro As String
        Apri()
        Try
            dvr.RowFilter = "Mat LIKE '*" & CStr(drvT1B(CampoSN)) & "*'"  '&INSTR(Mat,'" + CStr(drvT1B("SpecNo")) + "')>0" ' AND NOT Obsoleto"
            If dvr.Count = 0 Then
                'SpecNuda = CStr(drvT1B(CampoSN))
                'For i = 1 To CShort(Len(SpecNuda) - 1)
                'If Mid(SpecNuda, i, 1) = "-" Then
                'Mid(SpecNuda, i, 1) = " "
                'End If
                'Next
                dvr.RowFilter = "Spec LIKE '" & CStr(drvT1B(CampoSN)) & "'"
            End If
            If dvr.Count = 0 Then
                Yes = False
                Exit Sub
            End If
            If Grado And icod <> 22 Then
                SpecNuda = Trim(CStr(drvT1B(CampoTG)))
                ' WildCards()
                If dvr.RowFilter.Length > 0 Then Filtro = dvr.RowFilter & " AND " Else Filtro = ""
                dvr.RowFilter = Filtro & "TypeGrade LIKE '" & SpecNuda & "'"
                If dvr.Count = 0 Then
                    Call Manuale(1, Esito, ii)
                    Yes = Esito = 2
                    Exit Sub
                End If
            End If
            'If UNS Then
            SpecNuda = Trim(CStr(drvT1B(CampoAU)))
            If Len(SpecNuda) > 3 Then
                If dvr.RowFilter.Length > 0 Then Filtro = dvr.RowFilter & " AND " Else Filtro = ""
                dvr.RowFilter = Filtro & "AlloyUNS = '" & SpecNuda & "'"
                If dvr.Count = 0 Then
                    Call Manuale(2, Esito, ii)
                    Yes = Esito = 2
                    Exit Sub
                End If
            End If
            'End If
            If Classe Then
                SpecNuda = Trim(CStr(drvT1B(CampoCl)))
                ' WildCards()
                If dvr.RowFilter.Length > 0 Then Filtro = dvr.RowFilter & " AND " Else Filtro = ""
                dvr.RowFilter = Filtro & "classcondtemp LIKE '" & SpecNuda & "'"
                If dvr.Count = 0 Then
                    Call Manuale(3, Esito, ii)
                    Yes = Esito = 2
                    Exit Sub
                End If
            End If
            If [Size] And Not Metrico Then
                SpecNuda = CStr(drvT1B(CampoSi))
                'WildCards()
                If dvr.RowFilter.Length > 0 Then Filtro = dvr.RowFilter & " AND " Else Filtro = ""
                dvr.RowFilter = Filtro & "SizeThk LIKE '" & SpecNuda & "'"
                If dvr.Count = 0 Then
                    Call Manuale(4, Esito, ii)
                    Yes = Esito = 2
                    Exit Sub
                End If
            End If
            If icod < 21 Then
                If dvr.RowFilter.Length > 0 Then Filtro = dvr.RowFilter & " AND " Else Filtro = ""
                dvr.RowFilter = Filtro & "Product LIKE '" & Trim(CStr(drvT1B(CampoPr))) & "'"
                If dvr.Count = 0 Then
                    Call Manuale(6, Esito, ii)
                    Yes = Esito = 2
                    Exit Sub
                End If
            End If
            If AggNote Then
                SpecNuda = Trim(CStr(drvT1B("notes")))
                'For i = 1 To CShort(Len(SpecNuda) - 1)
                'If Mid(SpecNuda, i, 1) = " " Then
                'SpecNuda = Left(SpecNuda, i - 1) & Right(SpecNuda, Len(SpecNuda) - i)
                'End If
                'Next
                If dvr.RowFilter.Length > 0 Then Filtro = dvr.RowFilter & " AND " Else Filtro = ""
                dvr.RowFilter = Filtro & "Notes LIKE '" & SpecNuda & "'"
            End If
            If dvr.Count = 0 Then
                Call Manuale(5, Esito, ii)
                Yes = Esito = 2
                Exit Sub
            End If
            Call Manuale(0, Esito, ii)
            ' Yes = Esito = 2
            'If Not Yes Then Exit Sub
            'If dvr.Count > 1 Then
            'PrintLine(ilog, "trovate" & Str(dvr.Count) & " versioni indistinguibili")
            'dvr.Delete(dvr.Count - 1)
            'End If
            'drvr = dvr(dvr.Count - 1)
        Catch e As Exception
            MsgBox("Approfondito: " + e.Message + vbCrLf + e.StackTrace)
        End Try
        Yes = Esito = 2
    End Sub
    Private Sub Approfonditoy(ByVal ii As Integer)
        Dim Filtro As String
        Apri()
        Try
            'dvr.RowFilter = "Mat LIKE '*" & CStr(drvT1B(CampoSN)) & "*'"  '&INSTR(Mat,'" + CStr(drvT1B("SpecNo")) + "')>0" ' AND NOT Obsoleto"
            'If dvr.Count = 0 Then
            dvr.RowFilter = "Spec LIKE '" & CStr(drvT1B(CampoSN)) & "'"
            'End If
            If dvr.Count = 0 Then
                Yes = False
                Exit Sub
            End If
            If Grado And icod <> 22 Then
                SpecNuda = Trim(CStr(drvT1B(CampoTG)))
                If dvr.RowFilter.Length > 0 Then Filtro = dvr.RowFilter & " AND " Else Filtro = ""
                dvr.RowFilter = Filtro & "TypeGrade LIKE '" & SpecNuda & "'"
                If dvr.Count = 0 Then
                    Yes = False
                    Exit Sub
                End If
            End If
            SpecNuda = Trim(CStr(drvT1B(CampoAU)))
            If Len(SpecNuda) > 3 Then
                If dvr.RowFilter.Length > 0 Then Filtro = dvr.RowFilter & " AND " Else Filtro = ""
                dvr.RowFilter = Filtro & "AlloyUNS = '" & SpecNuda & "'"
                If dvr.Count = 0 Then
                    Yes = False
                    Exit Sub
                End If
            End If
            If Classe Then
                SpecNuda = Trim(CStr(drvT1B(CampoCl)))
                If dvr.RowFilter.Length > 0 Then Filtro = dvr.RowFilter & " AND " Else Filtro = ""
                dvr.RowFilter = Filtro & "classcondtemp LIKE '" & SpecNuda & "'"
                If dvr.Count = 0 Then
                    Yes = False
                    Exit Sub
                End If
            End If
            If [Size] Then
                SpecNuda = CStr(drvT1B(CampoSi))
                If dvr.RowFilter.Length > 0 Then Filtro = dvr.RowFilter & " AND " Else Filtro = ""
                dvr.RowFilter = Filtro & "SizeThkmm LIKE '" & SpecNuda & "'"
                If dvr.Count = 0 Then
                    Yes = False
                    Exit Sub
                End If
            End If
            '            If dvr.RowFilter.Length > 0 Then Filtro = dvr.RowFilter & " AND " Else Filtro = ""
            '           dvr.RowFilter = Filtro & "Product LIKE '" & Trim(CStr(drvT1B(CampoPr))) & "'"
            '          If dvr.Count = 0 Then
            '         Yes = False
            '        Exit Sub
            '       End If
        Catch e As Exception
            MsgBox("Approfondito: " + e.Message + vbCrLf + e.StackTrace)
        End Try
        Yes = True
    End Sub
    Private Sub Fai2()
        Try
            If icod <> 23 Then
            End If
            iFoundc = dvc.Find(drvr("Caract2"))
            If iFoundc = -1 Then
                drvc = dvc.AddNew()
                drvr.BeginEdit()
                drvr("Caract2") = drvc("ID")
                drvr.EndEdit()
            Else
                drvc = dvc(iFoundc)
                drvc.BeginEdit()
            End If
            If IsDBNull(drvT1B("notes")) Then strNotes = "" Else strNotes = CStr(drvT1B("notes"))
            If icod > 20 Then
                RegistraNote()
                drvr.BeginEdit()
                drvr("Notes2") = strNotes
                drvr.EndEdit()
            End If
            Pagine()
            UpdateCaract()
            Ammiss()
            Yes = True
            If CInt(drvc("IndTemp")) = Dummy Then
                drvV = dvV.AddNew()
                Yes1 = True
            Else
                iFoundV = dvV.Find(drvc("IndTemp"))
                If iFoundV = -1 Then
                    drvV = dvV.AddNew()
                    Yes1 = True
                    If Yes Then PrintLine(ilog, "Il vettore delle temperature per la tabella degli ammissibili in Div.2 non era presente")
                    Gia = True
                Else
                    drvV = dvV(iFoundV)
                    drvV.BeginEdit()
                    Yes1 = False
                    Gia = False
                End If
            End If
            For i = 1 To 24
                'If Temp(i) = 0 Then Exit For
                If Not CSng(drvV(i)) = Temp(i) Then
                    If Yes And Not Gia Then PrintLine(ilog, "Il vettore delle temperature per la tabella degli ammissibili in div.2 non era aggiornato")
                    Gia = True
                    drvV(i) = Temp(i)
                End If
            Next
            drvV.EndEdit()
            If Yes1 Then
                drvc("IndTemp") = drvV("ID")
            End If
            If CInt(drvc("IndAmmis")) = Dummy Then
                drvV = dvV.AddNew()
                Yes1 = True
            Else
                iFoundV = dvV.Find(drvc("IndAmmis"))
                If iFoundV = -1 Then
                    drvV = dvV.AddNew()
                    Yes1 = True
                    If Yes Then PrintLine(ilog, "Il vettore degli ammissibili in div.2 non era presente")
                    Gia = True
                Else
                    drvV = dvV(iFoundV)
                    drvV.BeginEdit()
                    Yes1 = False
                End If
            End If
            For i = 1 To 24
                'If s(i) = 0 Then Exit For
                If Not CSng(drvV(i)) = s(i) * Mille Then
                    drvV(i) = s(i) * Mille
                    If Yes And Not Gia Then PrintLine(ilog, "Il vettore degli ammissibili in div.2 non era aggiornato")
                    Gia = True
                End If
            Next
            drvV.EndEdit()
            If Yes1 Then
                drvc("IndAmmis") = drvV("ID")
            End If
            drvc.EndEdit()
        Catch e As Exception
            MsgBox("Fai2:" + e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Private Sub ExamProd()
        Try
            For jjj = 0 To CShort(dvr.Count - 1)
                drvr = dvr(jjj)
                If icod = 23 Then
                    Log1 = False
                Else
                    Log1 = IsDBNull(drvr("Product"))
                    If (Log1) Then
                        drvr.BeginEdit()
                        drvr("Product") = drvT1B(CampoPr)
                        drvr.EndEdit()
                    End If
                    If Not Log1 Then Log1 = InStr(UCase(CStr(drvr("Product"))), UCase(CStr(drvT1B(CampoPr)))) > 0
                    If Not Log1 Then Log1 = InStr(UCase(CStr(drvT1B(CampoPr))), "WLD") > 0 And InStr(UCase(CStr(drvr("Product"))), "WLD") > 0
                    If Not Log1 Then Log1 = InStr(UCase(CStr(drvT1B(CampoPr))), "SMLS") > 0 And InStr(UCase(CStr(drvr("Product"))), "SMLS") > 0
                    If Not Log1 Then Log1 = InStr(UCase(CStr(drvT1B(CampoPr))), "PLAT") > 0 And InStr(UCase(CStr(drvr("Product"))), "PLAT") > 0
                End If
                If Log1 Then
                    Fatto = 0
                    Fai2()
                End If
            Next
        Catch e As Exception
            MsgBox("ExamProd:" + e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Private Sub Fai()
        If Ord1 = -1 Then
            Ord = Ord + 1
        Else
            Ord = (Ord + Ord1) / 2
        End If
        Yes = False
        '        CercaAlfabeto()
    End Sub
    Private Sub CercaAlfabeto()
        Try
            For jj = 0 To CShort(dvr.Count - 1)
                drvr = dvr(jj)
                Ord = CSng(drvr("Ordinamento"))
                Spec = CStr(drvr("Mat"))
                CercaCodice()
                If Yes Then
                    Select Case icod
                        Case 1 To 9
                            If Left(Spec, 2) = "A " Then Spec = "S" & Spec
                        Case 11 To 19
                            If Left(Spec, 2) = "B " Then Spec = "S" & Spec
                    End Select
                    If Funzioni.Adjust(Spec, CShort(Len(SpecN))) <= SpecN Then
                        jj = CShort(jj + 1)
                        drvr = dvr(jj)
                        If jj = dvr.Count - 1 Then
                            Ord1 = CSng(drvr("Ordinamento"))
                            Exit Sub
                        Else
                            Ord1 = CSng(drvr("Ordinamento"))
                        End If
                        CercaPoi()
                        Exit Sub
                    End If
                End If
            Next jj
            Yes = False
        Catch e As Exception
            MsgBox("CercaAlfabeto:" + e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Private Sub Fai3(ByVal i As Integer)
        Dim Filtro As String
        Try
            If dvr.Count > 0 Then
                If dvr.Count > 1 Then
                    PrintLine(ilog, "Trovate" & Str(dvr.Count) & " corrispondenze")
                    If Not IsDBNull(drvT1B(CampoSi)) Then
                        Filtro = dvr.RowFilter
                        If Filtro.Length > 0 Then Filtro = Filtro & " AND "
                        dvr.RowFilter = Filtro & Criterio & " AND SizeThk='" + CStr(drvT1B(CampoSi)) + "'"
                        Yes = dvr.Count > 0
                    Else
                        Yes = False
                    End If
                    If Yes Then
                        If dvr.Count > 1 Then
                            ExamProd()
                        Else
                            drvr = dvr(0)
                            Fai2()
                        End If
                    Else
                        ExamProd()
                    End If
                Else
                    drvr = dvr(0)
                    PrintLine(ilog, "Trovata una corrispondenza")
                    Fai2()
                End If
            Else
                PrintLine(ilog, "Nessuna corrispondenza trovata")
                SuperSpec(CShort(i))
                PrintLine(ilog, "MATERIALE DB ASME: " & SpecN)
                'GoSub CercaAlfabeto
                Yes = False
                Calcolaicod()
                FaiFai()
            End If
        Catch e As Exception
            MsgBox("Fai3:" + e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Private Sub Calcolaicod()
        Select Case icod
            Case 23
                icod1 = 8
            Case 1, 2, 4, 6, 7, 8
                icod1 = CShort(icod)
            Case 11, 12
                icod1 = 2
            Case 13 To 19
                icod1 = CShort(icod - 10)
            Case Else
                Dim Prodotto As String = CStr(drvT1B(CampoPr))
                If InStr(Prodotto, "Sh") > 0 Or _
                   InStr(Prodotto, "Pl") > 0 Or _
                   InStr(Prodotto, "heet") > 0 Or _
                   InStr(Prodotto, "late") > 0 Then
                    If InStr(CStr(drvT1B(CampoSN)), "SB") > 0 Then
                        icod1 = 2
                    ElseIf Val(Left(CStr(drvT1B(CampoNC)), 2)) < 6 Then
                        icod1 = 1
                    Else
                        icod1 = 2
                    End If
                ElseIf InStr(Prodotto, "Rod") > 0 Then
                    icod1 = 7 ' 3
                ElseIf InStr(Prodotto, "ube") > 0 Then
                    icod1 = 4
                ElseIf InStr(Prodotto, "ipe") > 0 Then
                    icod1 = 6
                ElseIf InStr(Prodotto, "itting") > 0 _
                    Or InStr(Prodotto, "orging") > 0 _
                    Or InStr(Prodotto, "Bar") > 0 _
                    Or InStr(Prodotto, "asting") > 0 Then
                    icod1 = 7
                Else
                    Stop
                    Exit Sub
                End If
        End Select
    End Sub
    Private Sub Ricrea()
        jj = 1
        dvr.Sort = "Ordinamento"
        dvr.RowFilter = ""
        For jj = 0 To CShort(dvr.Count - 1)
            drvr = dvr(jj)
            drvr.BeginEdit()
            drvr("Ordinamento") = jj
            drvr.EndEdit()
        Next
        drvr = dvr(0)
    End Sub
End Module

