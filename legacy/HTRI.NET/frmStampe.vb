Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class frmStampe
	Inherits System.Windows.Forms.Form
	Private NoComm As Boolean
	Private BackCol As Integer
    Private job As RoutBase1.clsjob
    Private Sub cmdApri_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdApri.Click
        Dim Node As System.Windows.Forms.TreeNode
        Dim Arch, comm As String
        Dim File, Testo As String
        Dim NoComm As Boolean
        Node = TreeView1.SelectedNode
        If Node Is Nothing Then
            MostraAiuto(IDH_HTRI_TREENONSEL)
            Exit Sub
        End If
        File = Mid(Node.Name, 3, 4) & ".PRV"
        CercaComm(File, Arch, comm, NoComm)
        job.contratto = Arch
        CarPre(True)
        'objDatBase.Arch = Arch
        job1 = job
    End Sub

    Private ReadOnly Property Check1(ByVal i As Short) As CheckBox
        Get
            Select Case i
                Case 0 : Return _Check1_0
                Case 1 : Return _Check1_1
                Case 2 : Return _Check1_2
                Case 3 : Return _Check1_3
                Case 4 : Return _Check1_4
                Case 5 : Return _Check1_5
                Case 6 : Return _Check1_6
                Case 7 : Return _Check1_7
                Case 8 : Return _Check1_8
                Case 9 : Return _Check1_9
                Case 10 : Return _Check1_10
            End Select

        End Get
    End Property
    Private ReadOnly Property Check2(ByVal i As Short)
        Get
            Select Case i
                Case 0 : Return _Check2_0
                Case 1 : Return _Check2_1
                Case 2 : Return _Check2_2
                Case 3 : Return _Check2_3
                Case 4 : Return _Check2_4
                Case 5 : Return _Check2_5
                Case 6 : Return _Check2_6
                Case 7 : Return _Check2_7
                Case 8 : Return _Check2_8
                Case 9 : Return _Check2_9
                Case 10 : Return _Check2_10
                Case Else : Return Nothing
            End Select
        End Get
    End Property
    Private ReadOnly Property List1(ByVal i As Integer) As ListBox
        Get
            Select Case i
                Case 0 : Return _List1_0
                Case 1 : Return _List1_1
                Case 2 : Return _List1_2
                Case 3 : Return _List1_3
                Case 4 : Return _List1_4
                Case 5 : Return _List1_5
                Case 6 : Return _List1_6
                Case 7 : Return _List1_7
                Case 8 : Return _List1_8
                Case 9 : Return _List1_9
                Case 10 : Return _List1_10
                Case Else : Return Nothing
            End Select
        End Get
    End Property
    Private ReadOnly Property List2(ByVal i As Integer) As ListBox
        Get
            Select Case i
                Case 0 : Return _List2_0
                Case 1 : Return _List2_1
                Case 2 : Return _List2_2
                Case 3 : Return _List2_3
                Case 4 : Return _List2_4
                Case 5 : Return _List2_5
                Case 6 : Return _List2_6
                Case 7 : Return _List2_7
                Case 8 : Return _List2_8
                Case 9 : Return _List2_9
                Case 10 : Return _List2_10
                Case Else : Return Nothing
            End Select
        End Get
    End Property
    Private Sub cmdWord_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdWord.Click
        Dim C As System.Windows.Forms.CheckBox
        Dim Selezionato As Boolean
        Dim Stub As StubW2000.clsSW2000
        Dim File As String
        Dim FileStam, FileOrg As String
        Dim i, ij As Short
        Dim n As Short
        'dim P As Word.Paragraph, R As Word.Range
        Dim SottoCo As String
        'Dim Storia As Word.Range
        Dim Testo As String
        Dim iPag As Short ', iPar As Integer
        Try
            For i = 0 To 10
                C = Check1(i)
                If FormMsg.Annullato Then Exit For
                If C.CheckState = 1 Then
                    Select Case i
                        Case 0 To 3 'FUN BIL CAL VEN
                            File = Monitor.Motore.Inizio.Archdir + "\WALDV.DOC"
                        Case 4 'PSW
                            File = ""
                        Case 5 'DS
                            File = Monitor.Motore.Inizio.Archdir + "\WALDV.DOC"
                        Case 6 'VER
                            File = Monitor.Motore.Inizio.Archdir + "\HEADNOT.DOC"
                        Case 7, 8 'PRO DAT
                            File = Monitor.Motore.Inizio.Archdir + "\WALD.DOC"
                        Case 9, 10 'SUM,MAP
                            File = Monitor.Motore.Inizio.Archdir + "\WALD.DOC"
                    End Select
                    For ij = 0 To List1(i).Items.Count - 1
                        If FormMsg.Annullato Then Exit For
                        SottoCo = List1(i).Items(ij).ToString.Substring(0, 6) ' VB.Left(VB6.GetItemString(List1(i), ij), 6)
                        FileOrg = Monitor.Motore.Inizio.Workdir + "\" + List1(i).Items(ij).ToString 'VB6.GetItemString(List1(i), ij)
                        n = InStr(FileOrg, ".")
                        FileStam = VB.Left(FileOrg, n - 1) & "W" & VB.Right(FileOrg, Len(FileOrg) - n + 1)
                        If File = "" Then File = FileOrg
                        If Not Selezionato Then
                            Stub.SuperStampa(File, Monitor.Motore.Inizio.VersOffice) ' Documento
                            Selezionato = True
                            '   Stub.App.Visible = False
                            'Documento.Application.Visible = False
                            Enabled = False
                            FormMsg.Label1.Text = FileStam
                            FormMsg.Show()
                        Else
                            Stub.sOpen(File)
                            FormMsg.Label1.Text = FileStam
                        End If
                        If File = FileOrg Then GoTo Cont
                        Stub.sSaveAs(FileStam)
                        If FormMsg.Annullato Then Exit For
                        If i = 6 Then
                            With Stub
                                FormMsg.Label1.Text = FileStam & vbCrLf & "Pagina di guardia"
                                .SubstitBookM("OrdineCliente", "P.O.") 'Config(0).Item
                                .SubstitBookM("Cliente", job.Comm.Clie)
                                .SubstitBookM("Progetto", "Project")
                                .SubstitBookM("Codice", "")
                                .SubstitBookM("Impianto", "Impianto")
                                .SubstitBookM("Apparecchio", "App")
                                .SubstitBookM("Item", Item(Nrdit))
                                .SubstitBookM("Titolo", "Code Calculations")
                                .SubstitBookM("NoForn", comm)
                                .SubstitBookM("NoClie", "No. Client")
                                .SubstitBookM("Scopo", "For approval")
                                FormMsg.Label1.Text = FileStam & vbCrLf & "Immatricolazione"
                                Monitor.Motore.Inizio.Immatricolazione(Stub, SottoCo, "CK001")
                            End With
                            Stub.VaiInizio("CodeCalculations")
                            Stub.Espandi()
                        End If
                        If FormMsg.Annullato Then Exit For
                        FormMsg.Label1.Text = FileStam & vbCrLf & "Inserimento"
                        Stub.InsertPreRisc(FileOrg)
                        If i <> 6 Then
                            Stub.HTRI(FileStam)
                        End If
                        iPag = Stub.Pulisci
                        If FormMsg.Annullato Then Exit For
Cont:
                    Next ij
                End If
            Next
            C = Check2(i)
            For i = 0 To 10
                If FormMsg.Annullato Then Exit For
                If C.CheckState = 1 Then
                    For ij = 0 To List2(i).Items.Count - 1
                        If FormMsg.Annullato Then Exit For
                        FileOrg = Monitor.Motore.Inizio.Workdir + "\" + List2(i).Items(ij).ToString ' VB6.GetItemString(List2(i), ij)
                        If Not Selezionato Then
                            Stub.SuperStampa(FileOrg, Monitor.Motore.Inizio.VersOffice) ' Documento
                            Selezionato = True
                            '          Stub.App.Visible = False
                            Enabled = False
                            FormMsg.Show()
                            FormMsg.Label1.Text = FileStam
                        Else
                            Stub.sOpen(FileOrg)
                            FormMsg.Label1.Text = FileStam
                        End If
                    Next
                End If
            Next i
            Enabled = True
            If Not Selezionato Then
                MostraAiuto(IDH_HTRI_STAMNONSEL)
            Else
                'Stub.App.Visible = True
            End If
ExSub:
            FinitoStampe = True
            FormMsg.Close()
            FormMsg = Nothing
        Catch e As Exception
            '       Stub.App.Visible = True
            Testo = "WinWord non ha potuto salvare il documento|"
            Testo = Testo & FileStam & ". E' possibile che ne sia|"
            Testo = Testo & "caricata una copia precedente. Chiuderla."
            If MsgBox(Monitor.Motore.Inizio.ConvertiCr(Testo), MsgBoxStyle.RetryCancel, "ISA") = MsgBoxResult.Cancel Then
                '          Stub.App.Visible = False
            End If
            '     Stub.App.Quit()
        End Try
    End Sub

    Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
        Dim NomeFile As String
        Dim Node As System.Windows.Forms.TreeNode
        Node = TreeView1.SelectedNode
        If Node Is Nothing Then Exit Sub
        NomeFile = Mid(Node.Name, 3, 4) & ".PRV"
        SottoEliPre(NomeFile)
        TreeView1.Nodes.RemoveAt(Node.Index)
    End Sub

    Private Sub Command2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command2.Click
        System.Windows.Forms.Help.ShowHelp(Me, RadiceHelp, HelpNavigator.Topic, Monitor.HelpTopic(IDH_HTRI_NONVALIDO))
    End Sub
    Private ReadOnly Property Label3(ByVal i As Integer) As Label
        Get
            Select Case i
                Case 0 : Return _Label3_0
                Case 1 : Return _Label3_1
                Case 2 : Return _Label3_2
                Case 3 : Return _Label3_3
                Case 4 : Return _Label3_4
                Case 5 : Return _Label3_5
                Case 6 : Return _Label3_6
                Case 7 : Return _Label3_7
                Case 8 : Return _Label3_8
                Case 9 : Return _Label3_9
                Case 10 : Return _Label3_10
                Case Else : Return Nothing
            End Select
        End Get
    End Property
    Private ReadOnly Property Label4(ByVal i As Integer) As Label
        Get
            Select Case i
                Case 0 : Return _Label4_0
                Case 1 : Return _Label4_1
                Case 2 : Return _Label4_2
                Case 3 : Return _Label4_3
                Case 4 : Return _Label4_4
                Case 5 : Return _Label4_5
                Case 6 : Return _Label4_6
                Case 7 : Return _Label4_7
                Case 8 : Return _Label4_8
                Case 9 : Return _Label4_9
                Case 10 : Return _Label4_10
                Case Else : Return Nothing
            End Select
        End Get
    End Property
    Private Sub frmStampe_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Dim comm, File, Arch As String
        Dim Tit As String
        Dim Node, Nodey As System.Windows.Forms.TreeNode
        Dim NodeIt, Nodex As System.Windows.Forms.TreeNode
        Dim iErr, i, ifl As Integer
        Dim l, j, k, ii As Short
        Dim Valido As Boolean
        Dim Lista As New Collection
        Dim C As System.Windows.Forms.CheckBox
        Dim lab As System.Windows.Forms.Label
        Dim Gia As Boolean
        Top = 600 / 15
        Left = Apert._Frames_1.Width
        BackCol = System.Drawing.ColorTranslator.ToOle(Label3(0).BackColor)
        For i = 0 To 10 'Each C In Check1
            C = Check1(i)
            C.CheckState = System.Windows.Forms.CheckState.Unchecked
            C.Enabled = False
            'If i > 0 Then List1.Load(i)
        Next i
        For i = 0 To 10 'Each C In Check2
            C = Check2(i)
            C.CheckState = System.Windows.Forms.CheckState.Unchecked
            C.Enabled = False
            'If i > 0 Then List2.Load(i)
        Next i
        For i = 0 To 10 'Each lab In Label3
            lab = Label3(i)
            lab.Text = " ASSENTE"
            lab.BackColor = System.Drawing.Color.Red
        Next i
        For i = 0 To 10 'Each lab In Label4
            lab = Label4(i)
            lab.Text = " ASSENTE"
            lab.BackColor = System.Drawing.Color.Red
        Next i
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.Inizio. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'UPGRADE_WARNING: Dir ha un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
        File = Dir(CStr(Monitor.Motore.Inizio.Workdir + "\*.PRV"))
        Do While Len(File) > 0
            Lista.Add(File)
            'UPGRADE_WARNING: Dir ha un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
            File = Dir()
        Loop
        For ii = 1 To Lista.Count()
            File = Lista.Item(ii)
            CercaComm(File, Arch, comm, NoComm)
            If NoComm Then Tit = Arch Else Tit = Arch & "/" & comm
            If PRVValido(Arch) Then
                If NoComm Then
                    LeggiLav(Monitor.Motore.Inizio.Workdir + "\" + Arch + ".TE1")
                    job.Contratto = Arch
                    ApriPRV(Monitor.Motore.Inizio.Workdir + "\" + Arch + ".PRV", actPRV, iErr)
                    If Len(Trim(job.Contratto)) > 0 Then
                        Sommari(Valido, True)
                        If Valido Then
                            Node = TreeView1.Nodes.Add("P_" & Arch & "_PRV", Tit, 1)
                            For i = 1 To NumB
                                Nodex = TreeView1.Nodes.Find(Node.Name, True)(0).Nodes.Add(Node.Name & "_Ban_" & Trim(Str(i)), Trim(BankR(i)), 1)
                                For j = 1 To 99
                                    k = Disposiz.Nite(i, j)
                                    If k > 0 Then
                                        NodeIt = TreeView1.Nodes.Find(Nodex.Name, True)(0).Nodes.Add(Node.Name & "_Ite_" & Trim(Str(k)), Trim(Item(k)), 3)
                                        If Ialt(2, k) > 0 Then
                                            For l = 1 To 5
                                                If Ialt(l, k) > 0 Then
                                                    Nodey = TreeView1.Nodes.Find(NodeIt.Name, True)(0).Nodes.Add(Node.Name & "_Alt_" + GlobalRoutines.Str2Cifre(k) + "_" + Trim(Str(l)), "Alt.n°" & Str(l), 4)
                                                Else
                                                    Exit For
                                                End If
                                            Next
                                        End If
                                    Else
                                        Exit For
                                    End If
                                Next
                            Next
                        Else
                            Node = TreeView1.Nodes.Add("B_" & Arch & "_PRV", Tit, 5)
                        End If
                    End If
                    'CLOSPREV()
                    'FileClose(1)
                Else
                    job = New RoutBase1.clsjob(Monitor.Motore)
                    Dim ContrNome As String
                    LeggiLav(Monitor.Motore.Inizio.Workdir + "\" + Arch + ".TE1")
                    job.Contratto = Arch
                    ApriPRV(Monitor.Motore.Inizio.Workdir + "\" + Arch + ".PRV", actPRV, iErr)
                    If Len(Trim(job.Contratto)) > 0 Then
                        Sommari(Valido, True)
                        If Valido Then
                            Node = TreeView1.Nodes.Add("P_" & Arch & "_PRV", Tit, 1)
                            For i = 1 To job.Coll.Count
                                job.RetrieveCom(i)
                                Nodex = TreeView1.Nodes.Find(Node.Name, True)(0).Nodes.Add(Node.Name & "_Ban_" & Trim(job.Coll(i)) & "_" + GlobalRoutines.Str2Cifre(job.Comm.NBank), Trim(job.Coll(i)) & "/" + GlobalRoutines.Str2Cifre(job.Comm.NBank), 1)
                                For j = 1 To job.Comm.Ind.Count
                                    NodeIt = TreeView1.Nodes.Find(Nodex.Name, True)(0).Nodes.Add(Node.Name & "_Ite_" & Trim(Str(j) & "_c"), Trim(job.Comm.Ind(j).Data.Assieme) & "/" & Trim(job.Comm.Ind(j).Data.File), 3)
                                Next
                            Next
                            For i = 1 To NumB
                                For j = 1 To 99
                                    k = Disposiz.Nite(i, j)
                                    If k > 0 Then
                                        If NonGia(NodeIt, Trim(Item(k))) Then
                                            If Not Gia Then
                                                Nodex = TreeView1.Nodes.Find(Node.Name, True)(0).Nodes.Add(Node.Name & "_Ban_" & Trim(Str(i)), Trim(BankR(i)), 1)
                                                Gia = True
                                            End If
                                            NodeIt = TreeView1.Nodes.Find(Nodex.Name, True)(0).Nodes.Add(Node.Name & "_Ite_" & Trim(Str(k)), Trim(Item(k)), 3)
                                            If Ialt(2, k) > 0 Then
                                                For l = 1 To 5
                                                    If Ialt(l, k) > 0 Then
                                                        Nodey = TreeView1.Nodes.Find(NodeIt.Name, True)(0).Nodes.Add(Node.Name & "_Alt_" + GlobalRoutines.Str2Cifre(k) + "_" + Trim(Str(l)), "Alt.n°" & Str(l), 4)
                                                    Else
                                                        Exit For
                                                    End If
                                                Next
                                            End If
                                        End If
                                    Else
                                        Exit For
                                    End If
                                Next
                                Gia = False
                            Next
                        End If
                    End If
                End If
            End If
        Next
        If Len(Trim(job.Contratto)) > 0 Then
            Node = TreeView1.Nodes.Item(0)
            'UPGRADE_ISSUE: MSComctlLib.Node proprietà Node.Root non è stato aggiornato. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
            '  Node = Node.Root
            'UPGRADE_ISSUE: MSComctlLib.Node proprietà Node.FirstSibling non è stato aggiornato. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
            ' Node = Node.FirstSibling
            Do
                If Mid(Node.Name, 3, 4) = job.Contratto Then
                    TreeView1.SelectedNode = Node
                    TreeView1_Click(TreeView1, New System.EventArgs())
                    Node.Expand()
                    TreeView1.SelectedNode = Node
                    Node.EnsureVisible()
                    Nodex = Node.FirstNode
                    If Not Nodex Is Nothing Then
                        Nodex.Expand()
                        Nodex = Nodex.FirstNode
                        If Not Nodex Is Nothing Then Nodex.EnsureVisible()
                    End If
                    Exit Do
                End If
                Node = Node.NextNode
            Loop Until Node Is Nothing
        End If
    End Sub

    Private Sub frmStampe_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        FinitoStampe = True
    End Sub


    Private Sub TreeView1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TreeView1.Click
        Dim Node As System.Windows.Forms.TreeNode
        Dim File As String
        Dim n As Short
        Dim C As System.Windows.Forms.CheckBox
        Dim l As System.Windows.Forms.Label
        Dim File0 As String
        Dim i, xAlt As Short
        Dim iErr As Integer
        Dim Valido As Boolean
        Static Arch, FileV, comm As String
        Static NoComm As Boolean
        Node = TreeView1.SelectedNode
        For i = 0 To 10 'Each C In Check1
            C = Check1(i)
            C.CheckState = CheckState.Unchecked
            C.Enabled = False
        Next i
        For i = 0 To 10 'Each l In Label3
            l = Label3(i)
            l.Text = ""
        Next i
        If VB.Left(Node.Name, 1) = "B" Then
            Frame4.Visible = True
            Frame4.BringToFront()
            cmdApri.Enabled = False
            cmdWord.Enabled = False
            Exit Sub
        Else
            Frame4.Visible = False
            cmdApri.Enabled = True
            cmdWord.Enabled = True
        End If
        File = Mid(Node.Name, 3, 4) & ".PRV"
        If Not File = FileV Then
            CercaComm(File, Arch, comm, NoComm)
            job.contratto = Arch
            ApriPRV(File, actPRV, iErr)
            objDatBase.Arch = Arch
            If Not NoComm Then
                job.RetrieveCom(i) ' comm)
            End If
            Sommari(Valido, True)
            FileV = File
        End If
        File = Dir(Monitor.Motore.Inizio.Workdir + "\" + Arch + ".SUM")
        List1(10).Items.Clear()
        If Len(File) > 0 Then
            List1(10).Items.Add(Arch & ".SUM")
            Label3(10).Text = File
            Label3(10).BackColor = System.Drawing.ColorTranslator.FromOle(BackCol)
            Check1(10).Enabled = True
        Else
            Label3(10).Text = " ASSENTE"
            Label3(10).BackColor = System.Drawing.Color.Red
            Check1(10).Enabled = False
        End If
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.Inizio. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'UPGRADE_WARNING: Dir ha un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
        File = Dir(CStr(Monitor.Motore.Inizio.Workdir + "\" + CDbl(Arch) + CDbl(".MAP")))
        List1(9).Items.Clear()
        If Len(File) > 0 Then
            List1(9).Items.Add(Arch & ".MAP")
            Label3(9).Text = File
            Label3(9).BackColor = System.Drawing.ColorTranslator.FromOle(BackCol)
            Check1(9).Enabled = True
        Else
            Label3(9).Text = " ASSENTE"
            Label3(9).BackColor = System.Drawing.Color.Red
            Check1(9).Enabled = False
        End If
        If InStr(Node.Name, "_Ban") > 0 Then
            n = InStr(Node.Name, "_Ban")
            NumBank = Val(VB.Right(Node.Name, Len(Node.Name) - n - 4))
            SVerificaEsistenza(0, Arch, NumBank, ".FUN")
            SVerificaEsistenza(1, Arch, NumBank, ".BIL")
            SVerificaEsistenza(2, Arch, NumBank, ".CAL")
            SVerificaEsistenza(3, Arch, NumBank, ".VEN")
            SVerificaEsistenza(4, Arch, NumBank, "W.PSW")
            SVerificaEsistenza(5, Arch, NumBank, ".DS")
            SVerificaEsistenza(8, Arch, NumBank, ".PRO")
            SVerificaEsistenza(6, Arch, NumBank, ".VER")
            If NoComm Then
                '      SVerificaEsistenza 6, Arch, NumBank, ".VER"
            Else
                '         VerificaEsistenza 6, "A" + job.comm.Arch + "\*.VER", 0
                VerificaEsistenza(7, "A" + job.Comm.Arch + "\*.DAT", 0)
            End If
        ElseIf InStr(Node.Name, "_Ite") > 0 Then
            n = InStr(Node.Name, "_Ite")
            Nrdit = Val(VB.Right(Node.Name, Len(Node.Name) - n - 4))
            VerificaEsistenza(0, Arch + GlobalRoutines.Str2Cifre(Nrdit) + "*.FUN", 0)
            VerificaEsistenza(1, Arch + GlobalRoutines.Str2Cifre(Nrdit) + "*.BIL", 0)
            VerificaEsistenza(2, Arch + GlobalRoutines.Str2Cifre(Nrdit) + "*.CAL", 0)
            VerificaEsistenza(3, Arch + GlobalRoutines.Str2Cifre(Nrdit) + "*.VEN", 0)
            VerificaEsistenza(4, Arch + GlobalRoutines.Str2Cifre(Nrdit) + "*W.PSW", 0)
            VerificaEsistenza(5, Arch + GlobalRoutines.Str2Cifre(Nrdit) + "*.DS", 0)
            VerificaEsistenza(6, Arch + GlobalRoutines.Str2Cifre(Nrdit) + ".VER", 0)
            VerificaEsistenza(8, Arch & "*.PRO", 0)
            If NoComm Then
                '     VerificaEsistenza 6, Arch + Globalroutines.Str2Cifre(Nrdit) + "*.VER", 0
                VerificaEsistenza(7, Arch + GlobalRoutines.Str2Cifre(Nrdit) + "*.DAT", 0)
            Else
                '    TVerificaEsistenza 6, "VER"
                TVerificaEsistenza(7, "DAT")
            End If
        ElseIf InStr(Node.Name, "_Alt") > 0 Then
            n = InStr(Node.Name, "_Ite")
            Nrdit = Val(Mid(Node.Name, n + 5, 2))
            xAlt = Val(Mid(Node.Name, n + 8, 1))
            VerificaEsistenza(0, Arch + GlobalRoutines.Str2Cifre(Nrdit) + Trim(Str(xAlt)) + ".FUN", 0)
            VerificaEsistenza(1, Arch + GlobalRoutines.Str2Cifre(Nrdit) + Trim(Str(xAlt)) + ".BIL", 0)
            VerificaEsistenza(2, Arch + GlobalRoutines.Str2Cifre(Nrdit) + Trim(Str(xAlt)) + ".CAL", 0)
            VerificaEsistenza(3, Arch + GlobalRoutines.Str2Cifre(Nrdit) + Trim(Str(xAlt)) + ".VEN", 0)
            VerificaEsistenza(4, Arch + GlobalRoutines.Str2Cifre(Nrdit) + Trim(Str(xAlt)) + "W.PSW", 0)
            VerificaEsistenza(5, Arch + GlobalRoutines.Str2Cifre(Nrdit) + Trim(Str(xAlt)) + ".DS", 0)
            VerificaEsistenza(6, Arch + GlobalRoutines.Str2Cifre(Nrdit) + ".VER", 0)
            VerificaEsistenza(8, Arch & "*.PRO", 0)
            If NoComm Then
                '    VerificaEsistenza 6, Arch + Globalroutines.Str2Cifre(Nrdit) + Trim(Str(xAlt)) + ".VER", 0
                VerificaEsistenza(7, Arch + GlobalRoutines.Str2Cifre(Nrdit) + Trim(Str(xAlt)) + ".DAT", 0)
            Else
                '        TVerificaEsistenza 6, "VER"
                TVerificaEsistenza(7, "DAT")
            End If
        Else
            VerificaEsistenza(0, Arch & "*.FUN", 0)
            VerificaEsistenza(1, Arch & "*.BIL", 0)
            VerificaEsistenza(2, Arch & "*.CAL", 0)
            VerificaEsistenza(3, Arch & "*.VEN", 0)
            VerificaEsistenza(4, Arch & "*W.PSW", 0)
            VerificaEsistenza(5, Arch & "*.DS", 0)
            VerificaEsistenza(6, Arch & "*.VER", 0)
            VerificaEsistenza(8, Arch & "*.PRO", 0)
            If NoComm Then
                '      VerificaEsistenza 6, Arch + "*.VER", 0
                VerificaEsistenza(7, Arch & "*.DAT", 0)
            Else
                '         QVerificaEsistenza 6, "VER"
                QVerificaEsistenza(7, "DAT")
            End If
        End If
    End Sub

    Private Sub TreeView1_AfterCollapse(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.TreeViewEventArgs) Handles TreeView1.AfterCollapse
        Dim Node As System.Windows.Forms.TreeNode = eventArgs.Node
        If InStr(Node.Name, "_PRV") > 0 Or InStr(Node.Name, "_Ban") > 0 Then
            Node.ImageIndex = 1
        End If
    End Sub

    Private Sub TreeView1_AfterExpand(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.TreeViewEventArgs) Handles TreeView1.AfterExpand
        Dim Node As System.Windows.Forms.TreeNode = eventArgs.Node
        If InStr(Node.Name, "_PRV") > 0 Or InStr(Node.Name, "_Ban") > 0 Then
            Node.ImageIndex = 2
        End If
    End Sub



    Public Sub CercaComm(ByRef File As String, ByRef Arch As String, ByRef comm As String, ByRef NoComm As Boolean)
        With objDatBase
            Arch = VB.Left(File, Len(File) - 4)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto objDatBase.Arch. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            .Arch = Arch
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto objDatBase.Readreco. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            comm = .Readreco(1, 46, 2)
            If Len(comm) > 0 Then
                If Asc(comm) < 32 Then
                    comm = ""
                    NoComm = True
                Else
                    NoComm = False
                End If
            Else
                NoComm = True
            End If
        End With

    End Sub

    Private Sub VerificaEsistenza(ByRef nContr As Short, ByRef Appendice As String, ByRef Modo As Short)
        Dim File As String
        Dim M As Short
        Dim Radice As String
        Static n, n2 As Short
        Static File0, File1 As String
        If Len(Appendice) > 0 Then
            If n = 0 Then List1(nContr).Items.Clear()
            If n2 = 0 Then List2(nContr).Items.Clear()
            M = InStr(Appendice, "\")
            If Modo > -2 Then
                If M > 0 Then Radice = VB.Left(Appendice, M) Else Radice = ""
            End If
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.Inizio. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'UPGRADE_WARNING: Dir ha un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
            File = Dir(CStr(Monitor.Motore.Inizio.Workdir + "\" + CDbl(Appendice)))
            Do While Len(File) > 0
                If Bozza(File) Then
                    File0 = File
                    n = n + 1
                    List1(nContr).Items.Add(Radice & File)
                Else
                    File1 = File
                    n2 = n2 + 1
                    List2(nContr).Items.Add(Radice & File)
                End If
                'UPGRADE_WARNING: Dir ha un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
                File = Dir()
            Loop
            If Modo <= -1 Then Exit Sub
        End If
        If Len(Appendice) > 0 Or Modo = 1 Then
            If n > 1 Then
                Label3(nContr).Text = Str(n) & " documenti"
                Label3(nContr).BackColor = System.Drawing.ColorTranslator.FromOle(BackCol)
                Check1(nContr).Enabled = True
            ElseIf n = 1 Then
                Label3(nContr).Text = File0
                Label3(nContr).BackColor = System.Drawing.ColorTranslator.FromOle(BackCol)
                Check1(nContr).Enabled = True
            ElseIf n = 0 Then
                Label3(nContr).Text = " ASSENTE"
                Label3(nContr).BackColor = System.Drawing.Color.Red
                Check1(nContr).Enabled = False
            End If
            If n2 > 1 Then
                Label4(nContr).Text = Str(n2) & " documenti"
                Label4(nContr).BackColor = System.Drawing.ColorTranslator.FromOle(BackCol)
                Check2(nContr).Enabled = True
            ElseIf n2 = 1 Then
                Label4(nContr).Text = File1
                Label4(nContr).BackColor = System.Drawing.ColorTranslator.FromOle(BackCol)
                Check2(nContr).Enabled = True
            ElseIf n2 = 0 Then
                Label4(nContr).Text = " ASSENTE"
                Label4(nContr).BackColor = System.Drawing.Color.Red
                Check2(nContr).Enabled = False
            End If
            n = 0
            n2 = 0
            'List1(nContr).Clear
        End If
    End Sub
    Private Sub SVerificaEsistenza(ByRef Contr As Short, ByRef Arch As String, ByRef NumBank As Short, ByRef Ext As String)
        Dim j, k As Short
        For j = 1 To 99
            k = Disposiz.Nite(NumBank, j)
            If k > 0 Then
                VerificaEsistenza(Contr, Arch + GlobalRoutines.Str2Cifre(k) + Ext, -1)
            Else
                Exit For
            End If
        Next
        VerificaEsistenza(Contr, "", 1)
    End Sub
	
	Private Sub TVerificaEsistenza(ByRef Contr As Short, ByRef Ext As String)
		Dim i As Short
		Dim Testo, comm As String
		Testo = TreeView1.SelectedNode.Text
		Testo = VB.Right(Testo, 3)
		comm = TreeView1.SelectedNode.Parent.Text
		'comm = Right(comm, 6)
		VerificaEsistenza(Contr, "A" & comm & "\" & Testo & "." & Ext, -2)
		VerificaEsistenza(Contr, "", 1)
	End Sub
	Private Sub QVerificaEsistenza(ByRef Contr As Short, ByRef Ext As String)
		Dim i As Short
		'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto job.Coll. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		For i = 1 To job.Coll.Count
			'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto job.Coll. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			VerificaEsistenza(Contr, CStr(CDbl("A") + job.Coll(i) + CDbl("\*.") + CDbl(Ext)), -1)
		Next 
		VerificaEsistenza(Contr, "", 1)
	End Sub
	
	Private Function Bozza(ByRef f As String) As Boolean
		Dim i As Short
		Dim C As String
		Bozza = True
		i = InStr(f, ".")
		If i > 0 Then
			C = Mid(f, i - 1, 1)
			Bozza = Not (C = "W")
		End If
	End Function
	
	Private Function NonGia(ByRef NodeIt As System.Windows.Forms.TreeNode, ByRef It As String) As Boolean
		Dim Node, Nodex As System.Windows.Forms.TreeNode
		Dim Testo As String
		Dim n As Short
		NonGia = True
		If NodeIt Is Nothing Then Exit Function
		Node = NodeIt.Parent
		'UPGRADE_ISSUE: MSComctlLib.Node proprietà Node.FirstSibling non è stato aggiornato. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
        'Node = Node.FirstSibling
		Do 
			Node = Node.FirstNode
			If Node Is Nothing Then Exit Do
			'UPGRADE_ISSUE: MSComctlLib.Node proprietà Node.FirstSibling non è stato aggiornato. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
            'Node = Node.FirstSibling
			Nodex = Node
			Do 
				Testo = Node.Text
				n = InStr(Testo, "/")
				If n = 0 Then Exit Do
				Testo = VB.Left(Testo, n - 1)
				If Testo = It Then NonGia = False : Exit Function
				Node = Node.NextNode
			Loop Until Node Is Nothing
			Node = Nodex.Parent
			Node = Node.NextNode
		Loop Until Node Is Nothing
	End Function

    Private Sub _Check1_0_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Check1_0.CheckStateChanged
        If _Check1_0.CheckState = CheckState.Checked And _Check2_0.Enabled Then _Check2_0.CheckState = CheckState.Unchecked
    End Sub

    Private Sub _Check1_1_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Check1_1.CheckStateChanged
        If _Check1_1.CheckState = CheckState.Checked And _Check2_1.Enabled Then _Check2_1.CheckState = CheckState.Unchecked
    End Sub

    Private Sub _Check1_2_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Check1_2.CheckStateChanged
        If _Check1_2.CheckState = CheckState.Checked And _Check2_2.Enabled Then _Check2_2.CheckState = CheckState.Unchecked
    End Sub

    Private Sub _Check1_3_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Check1_3.CheckStateChanged
        If _Check1_3.CheckState = CheckState.Checked And _Check2_3.Enabled Then _Check2_3.CheckState = CheckState.Unchecked
    End Sub

    Private Sub _Check1_4_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Check1_4.CheckStateChanged
        If _Check1_4.CheckState = CheckState.Checked And _Check2_4.Enabled Then _Check2_4.CheckState = CheckState.Unchecked
    End Sub

    Private Sub _Check1_5_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Check1_5.CheckStateChanged
        If _Check1_5.CheckState = CheckState.Checked And _Check2_5.Enabled Then _Check2_5.CheckState = CheckState.Unchecked
    End Sub

    Private Sub _Check1_6_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Check1_6.CheckStateChanged
        If _Check1_6.CheckState = CheckState.Checked And _Check2_6.Enabled Then _Check2_6.CheckState = CheckState.Unchecked
    End Sub

    Private Sub _Check1_7_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Check1_7.CheckStateChanged
        If _Check1_7.CheckState = CheckState.Checked And _Check2_7.Enabled Then _Check2_7.CheckState = CheckState.Unchecked
    End Sub

    Private Sub _Check1_8_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Check1_8.CheckStateChanged
        If _Check1_8.CheckState = CheckState.Checked And _Check2_8.Enabled Then _Check2_8.CheckState = CheckState.Unchecked
    End Sub

    Private Sub _Check1_9_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Check1_9.CheckStateChanged
        If _Check1_9.CheckState = CheckState.Checked And _Check2_9.Enabled Then _Check2_9.CheckState = CheckState.Unchecked
    End Sub

    Private Sub _Check1_10_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Check1_10.CheckStateChanged
        If _Check1_10.CheckState = CheckState.Checked And _Check2_10.Enabled Then _Check2_10.CheckState = CheckState.Unchecked
    End Sub

    Private Sub _Check2_0_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Check2_0.CheckStateChanged
        If _Check2_0.CheckState = CheckState.Checked And _Check1_0.Enabled Then _Check1_0.CheckState = CheckState.Unchecked
    End Sub
    Private Sub _Check2_1_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Check2_1.CheckStateChanged
        If _Check2_1.CheckState = CheckState.Checked And _Check1_1.Enabled Then _Check1_1.CheckState = CheckState.Unchecked
    End Sub
    Private Sub _Check2_2_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Check2_2.CheckStateChanged
        If _Check2_2.CheckState = CheckState.Checked And _Check1_2.Enabled Then _Check1_2.CheckState = CheckState.Unchecked
    End Sub
    Private Sub _Check2_3_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Check2_3.CheckStateChanged
        If _Check2_3.CheckState = CheckState.Checked And _Check1_3.Enabled Then _Check1_3.CheckState = CheckState.Unchecked
    End Sub
    Private Sub _Check2_4_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Check2_4.CheckStateChanged
        If _Check2_4.CheckState = CheckState.Checked And _Check1_4.Enabled Then _Check1_4.CheckState = CheckState.Unchecked
    End Sub
    Private Sub _Check2_5_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Check2_5.CheckStateChanged
        If _Check2_5.CheckState = CheckState.Checked And _Check1_5.Enabled Then _Check1_5.CheckState = CheckState.Unchecked
    End Sub
    Private Sub _Check2_6_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Check2_6.CheckStateChanged
        If _Check2_6.CheckState = CheckState.Checked And _Check1_6.Enabled Then _Check1_6.CheckState = CheckState.Unchecked
    End Sub
    Private Sub _Check2_7_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Check2_7.CheckStateChanged
        If _Check2_7.CheckState = CheckState.Checked And _Check1_7.Enabled Then _Check1_7.CheckState = CheckState.Unchecked
    End Sub
    Private Sub _Check2_8_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Check2_8.CheckStateChanged
        If _Check2_8.CheckState = CheckState.Checked And _Check1_8.Enabled Then _Check1_8.CheckState = CheckState.Unchecked
    End Sub
    Private Sub _Check2_9_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Check2_9.CheckStateChanged
        If _Check2_9.CheckState = CheckState.Checked And _Check1_9.Enabled Then _Check1_9.CheckState = CheckState.Unchecked
    End Sub
    Private Sub _Check2_10_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Check2_10.CheckStateChanged
        If _Check2_10.CheckState = CheckState.Checked And _Check1_10.Enabled Then _Check1_10.CheckState = CheckState.Unchecked
    End Sub
End Class