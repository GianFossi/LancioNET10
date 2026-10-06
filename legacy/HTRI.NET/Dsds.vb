Option Strict Off
Option Explicit On
Imports RoutBase1
Module DataSh
    ' ===========================================================================
    '
    ' HTRI.BAS Copyright (c) 1989-1992 FBM-Hudson Italiana SpA
    '
    ' ===========================================================================
    Private Answer, nItems, i As Short
    Private j, k As Short
    Private SoloUno As Boolean
    Private j1, nn, resto, j2 As Short
    Private Testo As String
    Private k1 As Short
    Private Archiv(99) As Short
    Private OK As Boolean
    Private j3 As Short
    Private Aster, itp As String
    Private NumItCom, NumPrim As Short
    Private Aster1 As String
    Private Esito, Risult As Short
    Private jjjj, jj, jjj, icar As Short
    Private A As String
    ' ==========================================SmontIt=========================
    Private ListCom(6) As Short
    Private ListNew(6) As Short
    Private FascCom(6) As Short
    Private FascNew(6) As Short
    Private Tutti As Boolean
    Private imax As Short
    Private NumNew As Short
    Private nIt As Short
    Private u As String
    '================================================================
    Private Arch(100) As Short
    Private dAiu(100) As String
    '============================MonFVC==================================
    Private TipOper As Boolean
    Private ItemCloc(100) As String
    Private iF3, iF4 As Short
    Private NewF As String
    Private Riga As String
    Private Scelta(6) As Short
    Private NewAlt As Short
    Private NGrupp, l As Short
    Private n As Short
    '====================================================================
    Private k1dim(99) As Short
    Private Tit(7) As String
    Private Dom(100) As String ', Tipo(99) As Integer
    Private Risp(100) As String
    Private Dom2(17) As String
    Private Risp2(17) As String
    Private CodLiq, CodVap As Short
    Private Dom1(10) As String
    Private Risp1(10) As String
    Private Vap(4) As Short
    Private Liq(4) As Short
    Private IUNIUNSt As String 'Str2
    Private Nalt As Short
    ' Private Itemn As Str20
    Private ListIt_Renamed As ListIt
    Private Check, Rev As String
    'UPGRADE_WARNING: È possibile che si debba inizializzare le matrici nella struttura ListaMon prima di poterle utilizzare. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
    Private ListaMon As typListaMon
    '      Case 12: EdiDS
    '      Case 13: 'Mappa
    '      Case 14: 'Sommari
    '   End Select
    'AddDistinta = -1
    Sub EdiDS(ByRef Xtip As Short)
        Dim Testo As String
        Dim j As Short
        Dim Typem(4) As String
        Dim i As Short
        Dim itp As String = ""
        Dim j1, iF1 As Short
        Dim Valido As Boolean
        Dim Archiv(20) As Short
        Dim dAiu(20) As String
        Typem(1) = "Niente        "
        Typem(2) = "solo 1.termine"
        Typem(3) = "solo 2.termine"
        Typem(4) = "Tutto         "
        If job.Contratto = "" Then CarPre()
        Testo = at1(400 + 11) & at1(400 + 12)
        '     Testo = "Vuoi stampare tutti gli items   |"
        'Testo = Testo + "o vuoi stamparne uno solo       |"
        'Testo = Testo + "o vuoi stampare l'item corrente?|"
        '    Xtip = Alert(2, Testo, 8, 11, 13, 64, "Tutti", "Uno", "Corr.")
        'ListAltD Xtip
        'If Xtip = 0 Then Exit Sub
        Sommari(Valido)
        ItemnSt = job.Comm.Ind(1).Data.Assieme
        SETRDIT(ItemnSt, Nrdit)
        n = ActivAlt(Nrdit \ 2)
        If n > 0 Then
            SETALT(n)
        Else
            Testo = "Non è attiva alcuna alternativa per l'item" & vbCrLf
            Testo = Testo & ItemnSt.Trim & ". Operazione rifiutata"
            MsgBox(Testo, MsgBoxStyle.Information)
            Exit Sub
        End If
        FaseDati = 6
        Apert.Enabled = False
        Dom(1) = Helpstringa(1252) '"Metrico  (ME)"
        Dom(2) = Helpstringa(1253) ' "British  (BR)"
        Dom(3) = Helpstringa(1254) ' "S.I.     (SI)"
        Monitor.Motore.QualeM(1, 3, Helpstringa(1251), Dom, "", 3) ' "Scelta unità di misura", Dom, "", 3)
        Monitor.Motore.InputForms(1 - 1).Top = 40
        Monitor.Motore.InputForms(1 - 1).Left = Apert._Frames_1.Width
        Monitor.Motore.InputForms(1 - 1).Option1(2) = True
        '       For j = 1 To NumIt
        '           n = Val(Risp$(j))
        '           If n > 0 Then
        '               Itemn.St = Item$(j)
        '               SETRDIT Itemn, Nrdit
        '               SETALT n
        '           End If
        ''--------------------------------------
        'For i = 1 To 8: Dom1$(i) = at1(400+38 + i): Next
        Dom1(1) = "Liquido: cal.sp."
        Dom1(2) = "         viscos."
        Dom1(3) = "         conduc."
        Dom1(4) = "         densit."
        Dom1(5) = "Vapore : cal.sp."
        Dom1(6) = "         viscos."
        Dom1(7) = "         conduc."
        Dom1(8) = "         compr. "
        With objDatBase
            CodLiq = .CVI(.DatBase(2, 45, Nrdit \ 2, 1, itp, 0))
            CodVap = .CVI(.DatBase(2, 46, Nrdit \ 2, 1, itp, 0))
        End With
        Liq(1) = CodLiq \ 512
        CodLiq = CodLiq - Liq(1) * 512
        Liq(2) = CodLiq \ 64
        CodLiq = CodLiq - Liq(2) * 64
        Liq(3) = CodLiq \ 8
        Liq(4) = CodLiq - Liq(3) * 8
        Vap(1) = CodVap \ 512
        CodVap = CodVap - Vap(1) * 512
        Vap(2) = CodVap \ 64
        CodVap = CodVap - Vap(2) * 64
        Vap(3) = CodVap \ 8
        Vap(4) = CodVap - Vap(3) * 8
        For i = 1 To 4
            For j1 = 1 To 4
                Risp1(i) = Typem(Liq(j1) + 1)
                Risp1(i + 4) = Typem(Vap(j1) + 1)
            Next j1
            '    LungSt1(i) = Len(Risp1$(i))
            '    LungSt1(i + 4) = Len(Risp1$(i + 4))
        Next i
        Testo = "Tipo di output " & Item(j)
        iF1 = FreeFile()
        FileOpen(iF1, RTrim(Monitor.Motore.Inizio.Archdir) & "\ARCH" & "1000.DAT", OpenMode.Output)
        PrintLine(iF1, "  25   0   0   0")
        For i = 1 To 4
            PrintLine(iF1, Typem(i).PadRight(25))
        Next
        FileClose(iF1)
        For i = 1 To 8
            Archiv(i) = 1000
        Next
        Monitor.Motore.Chiamante = Monitor
        Monitor.Motore.InputDatiM(2, 8, Testo, Dom1, Risp1, "", Archiv, dAiu)
        For i = 1 To 8
            Monitor.Motore.InputForms(2 - 1).ComboFisso(i - 1).ListIndex = 3
        Next
    End Sub

    Sub EdiGenD()
        'If Asc(job.contratto) < 33 Then
        'a$ = RTrim$(at1(400+8))
        ''     a$ = "Si prega di aprire  un  preventivo|"
        ''a$ = a$ + "prima di editarne il contenuto !  |"
        '    x = Alert(2, a$, 8, 11, 13, 64, at1(400+37), Space$(0), Space$(0))
        '    Exit Sub
        'End If
        'Prendi
        'InputLav False
        'If Risp$(1) = "0" Then Exit Sub
        'Metti
    End Sub

    Sub InputLav(ByRef Nuovo As Boolean)
        '    Risp$(1) = Space$(4)
        '    ifl = FreeFile
        '    Open monitor.motore.inizio.archdir + "\HTRI03.DAT" For Input Shared As #ifl
        '    For i = 1 To 7: Line Input #ifl, Tit$(i): Next
        ''    Tit$(1) = "Nø Preventivo  :"
        ''    Tit$(2) = "Cliente        :"
        ''    Tit$(3) = "Indirizzo      :"
        ''    Tit$(4) = "Luogo impianto :"
        ''    Tit$(5) = "Rif.  Cliente  :"
        ''    Tit$(6) = "Unita' di mis. :"
        ''    Tit$(7) = "Lingua usata   :"
        '    For i = 1 To 7: LungStx(i) = Len(Risp$(i)): Next
        '    Line Input #ifl, Titolo$
        '    Line Input #ifl, Help$
        '    Close #ifl
        ''    Titolo$ = "Identificazione lavoro"
        ''    Help$ = "Help non disponibile"
        'If Not NUOVO Then LungStx(1) = 0 Else LungStx(1) = 4
        'rifai2:
        'y = InputDati(2, 7, Titolo$, Tit$(), Risp$(), LungStx())
        'Do
        'Select Case y
        '    Case -3
        '               junk = Alert(4, Help$, 4, 3, 10, 58, at1(400+37), Space$(0), Space$(0))
        '    Case -2
        '               WindowClose 2: LungSt(1) = 4: Risp$(1) = "0": Exit Sub
        '    Case -1
        '               WindowClose 2: Exit Do
        '    Case 6
        '             a$ = "Le scelte possibili sono:       |"
        '        a$ = a$ + "    SI :  Sistema Internazionale|"
        '        a$ = a$ + "    ME :  Sistema Tecnico       |"
        '        a$ = a$ + "    BR :  Sistema Imperiale     |"
        '        junk = Alert(4, a$, 4, 3, 10, 58, at1(400+37), Space$(0), Space$(0))
        '    Case 7
        '             a$ = "Le scelte possibili sono:       |"
        '        a$ = a$ + "    IT :  Italiano              |"
        '        a$ = a$ + "    IN :  Inglese               |"
        '        a$ = a$ + "    FR :  Francese              |"
        '        junk = Alert(4, a$, 4, 3, 10, 58, at1(400+37), Space$(0), Space$(0))
        '    Case Else
        '             a$ = "Dato in formato libero          |"
        '        junk = Alert(4, a$, 4, 3, 10, 58, at1(400+37), Space$(0), Space$(0))
        'End Select
        'y = InputDati(0, 7, Titolo$, Tit$(), Risp$(), LungStx())
        'Loop
        'Risp$(6) = UCase$(Risp$(6))
        'Risp$(7) = UCase$(Risp$(7))
        'Log1 = False
        'If Not (Risp$(6) = "BR" Or Risp$(6) = "SI" Or Risp$(6) = "ME") Then Log1 = True
        'If Not (Risp$(7) = "IT" Or Risp$(7) = "IN" Or Risp$(7) = "FR") Then Log1 = True
        'If Log1 Then
        '             a$ = "Dati non accettabili !          |"
        '        junk = Alert(4, a$, 4, 3, 10, 58, at1(400+37), Space$(0), Space$(0))
        '        GoTo rifai2
        'End If
        'If NUOVO Then job.contratto = Risp$(1)
        'Lav(0).Clie = Risp$(2)
        'Lav(0).Item = Risp$(3)
        'Lav(0).Comp = Risp$(4)
        'LungSt(1) = 4
        'DisplayH
    End Sub
    Sub ListAltD(ByRef Xtip As Short)
        ListaItems(nItems, Answer)
        If Answer = MsgBoxResult.No Then
            If Not Globale Then MostraAiuto(IDH_HTRI_NONVALIDO)
            Xtip = 0 : NumB = 0 : Exit Sub
        End If
        NumIt = nItems
        If NumIt = 0 Then
            If Answer = MsgBoxResult.Yes Then
                InputDaBanco = False
                Esito = InserIte(i)
            Else
                Xtip = 0 : NumB = 0 : Exit Sub
            End If
        End If
        If Xtip = 3 Then
            Item(1) = job.Comm.Ind(1).Data.Assieme
            If Asc(Item(1)) < 33 Or Left(Item(1), 1) = "$" Then
                '         Testo = at1(400+15)
                ''         Testo = "Non e' attivo alcun item!  |"
                '    x = Alert(4, Testo, 9, 10, 14, 70, at1(400+37), Space$(0), Space$(0))
                Xtip = 0
                Exit Sub
            End If
            i = 1
        End If
        ReDim ActivAlt(NumIt)
        ReDim Bank(NumIt, 4)
        For j = 1 To NumIt
            SETRDIT(Item(j), Nrdit)
            'SEARCHA(Ialta)
            GETBANK(Bank)
            For k = 1 To 4
                If Bank(j, k) = "    " Then
                    Bank(j, k) = "$$$$"
                ElseIf Not Bank(j, k) = "$$$$" Then
                    Bank(j, k) = "  " + GlobalRoutines.Str2Cifre(Val(Bank(j, k)))
                End If
            Next k
            For k = 1 To 5
                If actItem.indRecDati(k) > 0 Then Ialt(k, j) = k
            Next
        Next
        If Xtip = 2 Then
            Stop
            '   x = myListBox(2, 1, 1, Item$(), i, 0, "Scelta item", True)
            '   i = 1
            '   SWAP Item$(x), Item$(1)
        End If
        SetActAlt()
Rif:
        Risult = 0
        'objDatBase.Arch = job.contratto
        NumItConc = 0
        For j = 1 To nItems
            If ActivAlt(j) > 0 Then
                Aster = Trim(objDatBase.DatBase(4, 19, j, ActivAlt(j), itp, 0))
                If Aster = "*" Then
                    NumItCom = objDatBase.CVI(objDatBase.DatBase(4, 35, j, ActivAlt(j), itp, 0))
                    If NumItCom < 2 Or NumItCom > 6 Then Debug.Print("NumItCom" & NumItCom) : Stop
                    NumPrim = objDatBase.CVI(objDatBase.DatBase(4, 36, j, ActivAlt(j), itp, 0)) \ 2
                    Aster1 = Trim(objDatBase.DatBase(4, 19, NumPrim, ActivAlt(NumPrim), itp, 0))
                    If NumPrim <> j And Aster1 = "*" Then
                        Bank(j, 1) = Bank(NumPrim, 1)
                        For k = 2 To 4 : Bank(j, k) = "$$$$" : Next
                        GoTo ContCon
                    End If
                End If
            Else
                Aster = " "
            End If
            NumItConc = NumItConc + 1 : ItemC(NumItConc) = Item(j) 'Numero Items concentrati < NumIt
ContCon:
        Next j 'a
        Call Riordina(Xtip)
        If Risult = -1 Then
            Call RimuoviAster()
            GoTo Rif
        End If
    End Sub
    Private Sub RimuoviAster()
RimuoviAster:
        '     CLOSPREV()
        For j = 1 To nItems
            If ActivAlt(j) > 0 Then
                Aster = Trim(objDatBase.DatBase(4, 19, j, ActivAlt(j), itp, 0))
                If Aster = "*" Then
                    objDatBase.PutBasCh(4, 19, j, ActivAlt(j), " ", 0)
                    objDatBase.PutBasCh(4, 35, j, ActivAlt(j), objDatBase.MKI(0), 0)
                    objDatBase.PutBasCh(4, 36, j, ActivAlt(j), objDatBase.MKI(0), 0)
                End If
            End If
        Next
        '    Apri(job.Contratto)
    End Sub
    Private Sub Riordina(ByVal Xtip As Short)
Riordina:
        j = 0
        For jj = 1 To NumItConc
            For jjj = 1 To NumIt
                If ItemC(jj).Substring(0, Len(ItemC(jj)) - 1).PadRight(18) = Item(jjj).PadRight(18) Then Exit For
            Next
            If ActivAlt(jjj) > 0 Then
                Aster = Trim(objDatBase.DatBase(4, 19, jjj, ActivAlt(jjj), itp, 0))
            Else
                Aster = " "
            End If
            If Aster = "*" Then
                NumItCom = objDatBase.CVI(objDatBase.DatBase(4, 35, jjj, ActivAlt(jjj), itp, 0))
                If NumItCom < 2 Or NumItCom > 6 Then Debug.Print("NumItCom1" & NumItCom) : Stop
                For jjjj = 1 To NumItCom
                    NumPrim = objDatBase.CVI(objDatBase.DatBase(4, 35 + jjjj, jjj, ActivAlt(jjj), itp, 0)) \ 2
                    If NumPrim > 0 And NumPrim <= NumIt Then
                        Aster1 = Trim(objDatBase.DatBase(4, 19, NumPrim, ActivAlt(NumPrim), itp, 0))
                        If Aster1 = "*" Then
                            j = j + 1
                            Disposiz.jcont(j) = NumPrim
                            If jjjj = 1 Then Disposiz.BayNome(jjj) = "Vent." & Str(jjj)
                        End If
                    End If
                Next
            Else
                j = j + 1
                Disposiz.BayNome(jjj) = "Vent." & Str(jj)
                Disposiz.jcont(j) = jjj 'lista puntatori agli items riordinati per gruppo e per banko???
                'ItemC$(j) = Item$(jjj)
            End If 'f
        Next jj
        icar = 0
        For j = 1 To NumIt
            jj = Disposiz.jcont(j)
            If jj = 0 Then
                A = "Sono stati specificati in modo |"
                A = A & "contraddittorio dei montaggi di|"
                A = A & "ventilatori a comune. Si propone|"
                A = A & "di smontare tutti i montaggi su|"
                A = A & "ventilatore comune. D'accordo?|"
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.Inizio. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                If MsgBox(Monitor.Motore.Inizio.ConvertiCr(A), MsgBoxStyle.Question + MsgBoxStyle.YesNo, "ISA") = MsgBoxResult.Yes Then
                    LeggiNITE = False
                    Risult = -1
                    'UPGRADE_WARNING: Return ha un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
                    Return
                Else
                    Xtip = 0 : Exit Sub
                End If
            End If
            If ActivAlt(jj) > 0 Then
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto objDatBase.DatBase. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Aster = Trim(objDatBase.DatBase(4, 19, jj, ActivAlt(jj), itp, 0))
            Else
                Aster = " "
            End If
            If Aster = "*" Then
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto objDatBase.DatBase. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto objDatBase.CVI. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                NumItCom = objDatBase.CVI(objDatBase.DatBase(4, 35, jj, ActivAlt(jj), itp, 0))
                If NumItCom < 2 Or NumItCom > 6 Then Debug.Print("NumItCom2" & NumItCom) : Stop
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto objDatBase.DatBase. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto objDatBase.CVI. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                NumPrim = objDatBase.CVI(objDatBase.DatBase(4, 36, jj, ActivAlt(jj), itp, 0)) \ 2
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto objDatBase.DatBase. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Aster1 = Trim(objDatBase.DatBase(4, 19, NumPrim, ActivAlt(NumPrim), itp, 0))
                If NumPrim = jj And Aster1 = "*" Then
                    icar = icar + 1
                    For jjjj = 1 To NumItCom
                        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto objDatBase.DatBase. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto objDatBase.CVI. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        NumPrim = objDatBase.CVI(objDatBase.DatBase(4, 35 + jjjj, jj, ActivAlt(jj), itp, 0)) \ 2
                        If NumPrim > NumIt Or NumPrim < 1 Or NumPrim = jj And jjjj > 1 Then
                            Smonta(jj)
                            j = j - 1
                            Exit For
                        Else
                            ItemC(j + jjjj - 1) = RTrim(Item(NumPrim)) & " |" & Str(icar)
                        End If
                    Next
                End If
            Else
                ItemC(j) = Item(jj)
            End If
        Next
    End Sub
    Public Sub ListaBanks(ByRef nItems As Short)
        'Dim Answer As Integer
        'Dim l As Integer, Testo As String, j As Integer, k As Integer
        'ListaItems nItems, Answer
        'If nItems = 0 Then Exit Sub
        'ReDim Bank(nItems) As StrP4, Ialt(5, nItems) As Integer
        'For j = 1 To nItems
        '  ' Item(j) = Adjust(LTrim(RTrim(Item(j))), 20)
        '   Itemn.St = Item(j)
        '   SETRDIT Itemn, Nrdit
        '   SEARCHA Ialta
        '   GETBANK Bank(j)
        '   For k = 1 To 4
        '   If Bank(j).St(k) = "    " Or Asc(Bank(j).St(k)) < 32 Then Bank(j).St(k) = "$$$$"
        '   Next k
        '   If Bank(j).St(1) = "$$$$" Then Bank(j).St(1) = "BK01"
        '   PUTBANK Bank(j)
        '   If Ialta.Ialt(1) = 0 Then Ialta.Ialt(1) = 1
        '   For k = 2 To 5
        '     If Ialta.Ialt(k) > 0 Then Ialta.Ialt(k) = k
        '   Next
        '   'correzione alternative
        '   For k = 1 To 5
        '     Ialt(k, j) = Ialta.Ialt(k)
        '   Next
        'Next
        'Set BankList = New Collection
        'For j = 1 To nItems
        '   For k = 1 To 4
        '      For l = 1 To BankList.Count
        '         If Bank(j).St(k) = BankList(l)(1) Then
        '            BankList(l).Add j
        '            GoTo Cont
        '         End If
        '      Next
        '      If Not Bank(j).St(k) = "$$$$" Then
        '      Set BankItems = New Collection
        '      Testo = Bank(j).St(k)
        '      BankItems.Add Testo
        '      BankItems.Add j
        '      BankList.Add BankItems
        '      End If
        'Cont:
        '   Next
        'Next
    End Sub
    Public Sub CollectDS()
        Dim i, x, y As Short
        Dim u As String
        Dim Testo, NewF As String
        For i = 0 To 2
            If Monitor.Motore.InputForms(1 - 1).Option1(i) Then
                x = i + 1
            End If
        Next
        Select Case x
            Case 0 : Stop ' Exit Sub
            Case 1 : IUNIUNSt = "ME"
            Case 2 : IUNIUNSt = "BR"
            Case 3 : IUNIUNSt = "SI"
        End Select
        For y = 1 To 8
            x = Monitor.Motore.InputForms(2 - 1).ComboFisso(y - 1).ListIndex + 1
            If y < 5 Then
                Liq(y) = x - 1
            Else
                Vap(y - 4) = x - 1
            End If
        Next y
        '   CLOSPREV()
        CodLiq = Liq(4) + 8 * Liq(3) + 64 * Liq(2) + 512 * Liq(1)
        CodVap = Vap(4) + 8 * Vap(3) + 64 * Vap(2) + 512 * Vap(1)
        With objDatBase
            u = .PutBasCh(2, 45, Nrdit \ 2, 1, .MKI(CodLiq), 0)
            u = .PutBasCh(2, 46, Nrdit \ 2, 1, .MKI(CodVap), 0)
        End With
        'Apri(job.Contratto)
        DSDS(n, ItemnSt, IUNIUNSt)
        SETRDIT(ItemnSt, Nrdit)
        Testo = GlobalRoutines.Str2Cifre(Nrdit \ 2)
        NewF = Monitor.Motore.Inizio.Workdir + "\" + job.Contratto + Testo + ".DS"
        If Len(Dir(NewF)) > 0 Then IO.File.Delete(NewF)
        FileCopy(Monitor.Motore.Inizio.DiscoTem & job.Contratto, NewF)
        IO.File.Delete(Monitor.Motore.Inizio.DiscoTem & job.Contratto)
        Shell("NotePad " & NewF, AppWinStyle.NormalFocus)
        ' SETRDIT Itemn, Nrdit
        ' Testo = Item$(j)
        'If Xtip > 1 Then
        '  EditoreF 2, NewF$, "Data sheet " + Testo
        'ElseIf Xtip = 1 Then
        '  EditoreF 0, NewF$, "Data sheet " + Testo
        'End If
        '  Call Allocat1
        '  End If
        ' SETRDIT Itemn, Nrdit
ErrDs:
    End Sub
    Sub GruppIt()
        'Dim i, NewAlt As Short
        'Dim Testo As String
        Dim j As Short
        Stop
        'On Local Error GoTo ErrGI
        'If Len(Dir$("TEXT" + Trim(job.contratto))) > 0 Then Kill "TEXT" + Trim(job.contratto)
        'LISTITEM 0, 0
        'Open at1(400+22) + RTrim$(job.contratto) For Input As #3
        'If LOF(3) = 0 Then
        '    Close #3
        'If NumIt < 2 Then
        '   If NumIt = 0 Then
        '   Testo = Monitor.Motore.inizio.ConvertiCr(at1(400+7) + at1(400+8))
        '   Else
        '   Testo = Monitor.Motore.inizio.ConvertiCr(at1(400+9) + at1(400+10))
        '   End If
        ''         a$ = "In questo preventivo non e'  |"
        ''    a$ = a$ + "stato inserito ancora nessun |"
        ''    a$ = a$ + "Item. Operazione impossibile!|"
        '   MsgBox Testo, vbCritical
        '   Exit Sub
        'End If
        'For i = 1 To 99
        '   Line Input #3, Item$(i)
        '   If EOF(3) Then Exit For
        'Next
        'Close #3
        'Kill at1(400+22) + RTrim$(job.contratto)
        'If i < 2 Then
        '         a$ = at1(400+9) + at1(400+10)
        ''         a$ = "In questo preventivo e' stato|"
        ''    a$ = a$ + "inserito un solo item.       |"
        ''    a$ = a$ + "      Operazione impossibile!|"
        '    x = Alert(4, a$, 9, 10, 14, 70, at1(400+34), Space$(0), Space$(0))
        '    Exit Sub
        'End If
        '    Call Allocat3
        '    Handle = Messaggio(1, at1(400+35), 8, 8, 12, 50)
        '    Xalt = -1
        '300 ListAlt Xalt
        '    WindowClose Handle
        '310 Call Allocat1
        For j = 1 To NumIt
            '   ItemC$(j) = Adjust$(LTrim$(RTrim$(ItemC$(j))), 20) + "Banco" + Bank(j).St(1)
            '   scelta(j) = 0
        Next
        'x = mySwitchBox(2, 1, 1, ItemC$(), scelta(), i, 0, at1(400+25), True)
        'Do
        'For j = 1 To i
        '  If scelta(j) = 0 Then
        '    For k = j To i - 1
        '      scelta(k) = scelta(k + 1)
        '      Item$(k) = Item$(k + 1)
        '      ItemC$(k) = ItemC$(k + 1)
        '    Next k
        '    i = i - 1
        '    GoTo Cont
        '  End If
        'Next j
        'Exit Do
        'Cont:
        '330 Loop
        'TipOper = (InStr(ItemC$(1), Chr$(179)) > 0)
        'For j = 2 To i
        '    If TipOper <> (InStr(ItemC$(j), Chr$(179)) > 0) Then
        '    x = Alert(4, at1(400+49), 9, 10, 14, 70, at1(400+34), Space$(0), Space$(0))
        '    Exit Sub
        '    End If
        'Next
        'If i > 6 Then
        '         a$ = at1(400+11)
        ''         a$ = "Hai scelto troppi item da rag-|"
        ''    a$ = a$ + "gruppare. Il numero max e' 6. |"
        '    x = Alert(4, a$, 9, 10, 14, 70, at1(400+34), Space$(0), Space$(0))
        '    Exit Sub
        'ElseIf i < 2 And Not TipOper Then  '?????????????????
        '         a$ = at1(400+16)              '??????????????????
        ''         a$ = "Non hai scelto almeno due items|"
        ''    a$ = a$ + "da raggruppare.              . |"
        '    x = Alert(4, a$, 9, 10, 14, 70, at1(400+34), Space$(0), Space$(0))
        '    Exit Sub
        'ElseIf i < 1 Then
        '    Exit Sub
        'End If
        'If Not TipOper Then
        '   x = myListBox(2, 1, 1, Item$(), i, 0, at1(400+26), True)
        '   If x = 0 Then Exit Sub
        '   SWAP Item$(x), Item$(1)
        'End If
        'For j = 1 To i
        'Itemn.St = Item$(j)
        'SETRDIT Itemn, Nrdit
        'SEARCHA Ialta
        'For k = 1 To 5
        ' If ListaMon.Ialt(k) > 0 Then Ialt(k, j) = k Else Ialt(k, j) = 0
        'Next
        'Next j
        '360 OK = False
        'For j = 1 To i
        'If Ialt(2, j) > 0 Then OK = True
        'Next
        'If OK Then
        'For j = 1 To i
        'Dom$(j) = RTrim$(Item$(j)) + ". Alt.:"
        'For k = 1 To 5
        'If Ialt(k, j) > 0 Then Dom$(j) = Dom$(j) + Str$(Ialt(k, j)) + ";"
        'Next k
        'Dom$(j) = Adjust(Dom$(j) + " scegli:", 40)
        'Risp$(j) = "1"
        'LungSt(j) = 1
        'Next j
        'Rifa3:
        'a$ = at1(400+27) ' "Scelta alternative"
        'Y = InputDati(2, i, a$, Dom$(), Risp$(), LungSt())
        'Do
        'Select Case Y
        '    Case -3
        '            '   Help$ = "Help non disponibile"
        '               junk = Alert(4, at1(400+23), 4, 3, 10, 58, at1(400+34), Space$(0), Space$(0))
        '    Case -2
        '               WindowClose 2: Exit Sub
        '    Case -1
        '               WindowClose 2: Exit Do
        'End Select
        'Y = InputDati(0, i, a$, Dom$(), Risp$(), LungSt())
        'Loop
        'OK = True
        'For j = 1 To i
        'If Val(Risp$(j)) > 0 And Val(Risp$(j)) <= 5 Then
        'If Ialt(Val(Risp$(j)), j) = 0 Then OK = False
        'Else
        'OK = False
        'End If
        'Next
        'If Not OK Then
        '          a$ = at1(400+12)
        ''         a$ = "Valori forniti in modo errato|"
        '    x = Alert(4, a$, 9, 10, 14, 70, at1(400+34), Space$(0), Space$(0))
        '    GoTo Rifa3
        'End If
        'For j = 1 To i
        ' ListaMon.Ialt(j) = Val(Risp$(j))
        ' ListIt.St(j) = Item$(j)
        'Next j
        'Else
        'For j = 1 To i
        ' ListaMon.Ialt(j) = 1
        ' ListIt.St(j) = Item$(j)
        'Next j
        'End If
        'NewAlt = ListaMon.Ialt(1)
        'For j = 2 To i
        '  If ListaMon.Ialt(j) <> NewAlt And ListaMon.Ialt(j) > 0 Then
        '          a$ = at1(400+50)
        '    x = Alert(4, a$, 9, 10, 14, 70, at1(400+34), Space$(0), Space$(0))
        '    GoTo Rifa3
        '  End If
        'Next
        'If TipOper Then
        '   Call Allocat3
        '   Handle = Messaggio(1, at1(400+35), 8, 8, 12, 50)
        '   Call Allocat1
        '  Call SmontIt(i, NewAlt)
        '   WindowClose Handle
        '   Exit Sub
        'End If
        'MFVC1 i, ListIt, Ialta
        'Open at1(400+22) + RTrim$(job.contratto) For Input As #3
        'For j = 1 To 6: Line Input #3, Riga$: Next
        'For j = 1 To i
        '   Line Input #3, Riga$
        '   If Mid$(Riga$, 2, 2) = ">>" Then
        '    GoSub CondErr
        '    Close (3)
        '    Kill at1(400+22) + RTrim$(job.contratto)
        '    GoSub Riprist
        '    Exit Sub
        '   End If
        '   scelta(j) = Val(Mid$(Riga$, 49, 3))
        '   Dom$(j) = RTrim$(Item$(j)) + ": Nø fasci tot.:" + Str$(scelta(j))
        '   Risp$(j) = "  1"
        '   LungSt(j) = 3
        'Next
        'Close #3
        'Rifa6:
        'a$ = at1(400+28) ' "Prelievo fasci"
        'Y = InputDati(2, i, a$, Dom$(), Risp$(), LungSt())
        'Do
        'Select Case Y
        '    Case -3
        '         '      Help$ = "Help non disponibile"
        '               junk = Alert(4, at1(400+23), 4, 3, 10, 58, at1(400+34), Space$(0), Space$(0))
        '    Case -2
        '               WindowClose 2: Exit Sub
        '    Case -1
        '               WindowClose 2: Exit Do
        'End Select
        'Y = InputDati(0, i, a$, Dom$(), Risp$(), LungSt())
        'Loop
        'OK = True
        'For j = 1 To i
        'ListaMon.Ialt(j) = Val(Risp$(j))
        'If ListaMon.Ialt(j) = 0 Or ListaMon.Ialt(j) > scelta(j) Then OK = False
        'Next j
        'If Not OK Then GoTo Rifa6
        'If ListaMon.Ialt(1) <> scelta(1) Then
        '         a$ = at1(400+15)
        ''         a$ = "  Devi   prendere tutti i fasci|"
        ''    a$ = a$ + "dal primo item. Cambialo       |"
        '    x = Alert(4, a$, 9, 10, 14, 70, at1(400+34), Space$(0), Space$(0))
        '    Kill at1(400+22) + RTrim$(job.contratto)
        '    Exit Sub
        'End If
        'MFVC2 Ialta
        'Itemn.St = Item$(1)
        'SETRDIT Itemn, Nrdit
        'a$ = Globalroutines.mystr(CSng(Nrdit \ 2), 2, 0, True): If Left$(a$, 1) = Space$(1) Then Mid$(a$, 1, 1) = Chr$(48)
        'NewF$ = monitor.motore.inizio.workdir + Chr$(92) + Left$(job.contratto, 4) + a$ + ".MFV"
        'If Len(Dir$(NewF$)) > 0 Then Kill NewF$
        'Open at1(400+22) + RTrim$(job.contratto) For Input As #3
        'Open NewF$ For Output As #4
        'Do
        '   Line Input #3, Riga$
        '   If Mid$(Riga$, 2, 2) = ">>" Then
        '    GoSub CondErr
        '    Close (3): Kill at1(400+22) + RTrim$(job.contratto)
        '    Close (4): Kill NewF$
        '    GoSub Riprist
        '    Exit Sub
        '   End If
        '   Print #4, Riga$
        '   If EOF(3) Then Exit Do
        'Loop
        'Close #3: Close #4: Kill at1(400+22) + RTrim$(job.contratto)
        'a$ = at1(400+29)
        'Call Deallocat1
        'EditoreF 2, NewF$, a$ '"Raggruppamento items"
        'GoSub Riprist
        'SALVA
        'CLOSPREV
        AddDistinta = 3 : ScelMot()
        'Catena "HTRI"
        'Riprist:
        'job.Comm.Ind(1).Data.Assieme = RTrim$(ListIt.St(1)): job.Comm.Ind(2).Data.Assieme = Str$(NewAlt)
        'Itemn.St = LTrim$(job.Comm.Ind(1).Data.Assieme)
        'SETRDIT Itemn, Nrdit
        'SETALT NewAlt
        'Put #1, 1, Lav(0)
        'DisplayH
        'Return
        'CondErr:
        '          a$ = RTrim$(at1(400+14))
        ''         a$ = "|Si e' determinata una condizione di errore.| |"
        '         L = Len(Riga$)
        '         For k = 1 To L Step 44
        '         a$ = a$ + Mid$(Riga$, k, 44) + "|"
        '         Next
        '    x = Alert(4, a$, 9, 10, 16, 70, at1(400+34), Space$(0), Space$(0))
        'Return
        'ErrGI: Print "Err GruppIt"; Err; Erl: End
    End Sub
    Sub SmontIt(ByRef Ngrup As Short, ByRef NewAlt As Short)
        Tutti = False
        NewAlt = 1 'provvisorio
        'Stop
        n = InStr(Apert.TreeView1.SelectedNode.Text, "|")
        If n = 0 Then
            MostraAiuto(IDH_MFVC_PROCSMONT)
            Exit Sub
        End If
        ItemnSt = job.Comm.Ind(1).Data.Assieme
        SETRDIT(ItemnSt, Nrdit)
        NumPrim = objDatBase.CVI(objDatBase.DatBase(4, 36, Nrdit \ 2, NewAlt, itp, 0)) \ 2
        Tutti = NumPrim = Nrdit \ 2
        'For i = 1 To Ngrup
        '       Itemn.St = ListIt.St(i)
        '       SETRDIT Itemn, Nrdit
        '       NumPrim = objDatBase.CVI(objDatBase.Datbase(4, 36, Nrdit \ 2, NewAlt, itp$, 0)) \ 2
        '       If NumPrim = Nrdit \ 2 Then Tutti = True: Exit For
        'Next
        '---------------------------
        NumItCom = objDatBase.CVI(objDatBase.DatBase(4, 35, NumPrim, NewAlt, itp, 0))
        For i = 1 To NumItCom
            ListCom(i) = objDatBase.CVI(objDatBase.DatBase(4, 35 + i, NumPrim, NewAlt, itp, 0)) \ 2
            FascCom(i) = objDatBase.CVI(objDatBase.DatBase(4, 41 + i, NumPrim, NewAlt, itp, 0)) '??????????\ 2
            ListIt_Renamed.St(i) = Item(ListCom(i))
        Next
        '---------------------------
        If Tutti Then
            NumNew = 0
            Call Aggiorna(NewAlt)
        Else
            NumNew = NumItCom
            For i = 1 To 6 : ListNew(i) = ListCom(i) : FascNew(i) = FascCom(i) : Next
            For i = 1 To Ngrup
                ItemnSt = ListIt_Renamed.St(i)
                SETRDIT(ItemnSt, Nrdit)
                NumNew = NumNew - 1
                For j = 1 To 6
                    If ListNew(j) = Nrdit \ 2 Then
                        If j = 6 Then
                            ListNew(j) = 0
                            FascNew(j) = 0
                        Else
                            For k = j To 5
                                ListNew(k) = ListNew(k + 1)
                                FascNew(k) = FascNew(k + 1)
                            Next
                            If j = 5 Then ListNew(6) = 0 : FascNew(6) = 0
                        End If
                        Exit For
                    End If
                Next
            Next
            Call Aggiorna(NewAlt)
        End If
        ' MsgBox at1(400+51)
        FillTree(1)
        Exit Sub
    End Sub
    Private Sub Aggiorna(ByVal NewAlt As Short)
        imax = 0
        For i = 1 To NumIt
            j = TrovaNumero(Disposiz.BayNome(i))
            If j = 0 Then j = i
            If j > imax Then imax = j
        Next
        ' CLOSPREV()
        For i = 1 To NumItCom
            For j = 1 To NumNew
                If ListCom(i) = ListNew(j) Then GoTo Cons
            Next
            nIt = ListCom(i)
            n = InStr(ItemC(nIt), "|")
            If n = 0 Then Stop
            ItemC(nIt) = Left(ItemC(nIt), n - 1)
            imax = imax + 1
            If i > 1 Or Not Tutti Then Disposiz.BayNome(nIt) = "Vent." & Str(imax)
            u = objDatBase.PutBasCh(5, 15, nIt, NewAlt, objDatBase.MKS(0.0!), 0)
            u = objDatBase.PutBasCh(4, 19, nIt, NewAlt, Space(2), 0)
Cons:       u = objDatBase.PutBasCh(4, 35, nIt, NewAlt, objDatBase.MKI(NumNew), 0)
            For j = 1 To 6
                u = objDatBase.PutBasCh(4, 35 + j, nIt, NewAlt, objDatBase.MKI(2 * ListNew(j)), 0)
                u = objDatBase.PutBasCh(4, 41 + j, nIt, NewAlt, objDatBase.MKI(FascNew(j)), 0)
            Next
        Next
        '  Apri(job.Contratto)
    End Sub
    Sub Sommari(ByRef Valido As Boolean, Optional ByRef NoVideo As Boolean = False)
        Dim Xtip As Short
        Dim j, jj As Short
        Dim k, k1 As Short
        Valido = True
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        If job.Contratto.Trim.Length = 0 Then If Not CarPre() Then Exit Sub
        If job.Comm.Ind(1).Data.Assieme.Trim.Length > 0 And Left(job.Comm.Ind(1).Data.Assieme, 1) <> "$" And Val(job.Comm.Ind(2).Data.Assieme) > 0 Then
            ItemnSt = job.Comm.Ind(1).Data.Assieme
            Nalt = Val(job.Comm.Ind(2).Data.Assieme)
            SETRDIT(ItemnSt, Nrdit)
            ' GETPROG(Nalt, Check)
            Check = actAltern.Engineer
        End If 'h
        Xtip = 1
        ListAltD(Xtip)
        If Xtip = 0 Then
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            Valido = False
            Exit Sub
        End If
        NumB = 1
        For k = 1 To 30 : BankR(k) = Space(4) : Next
Riv:
        For j = 1 To NumIt
            jj = Disposiz.jcont(j)
            If jj = 0 Then jj = j : Disposiz.jcont(j) = jj
            For k1 = 1 To 4
                For k = 1 To NumB
                    If Bank(j, k1) = "$$$$" Then GoTo Cont
                    If LTrim(RTrim(BankR(k))) = LTrim(RTrim(Bank(j, k1))) Then GoTo Cont
                Next k
                BankR(NumB) = Bank(jj, k1) 'BankR è semplicemente la lista dei banchi
                NumB = NumB + 1
                GoTo Riv
Cont:
            Next
        Next j
        NumB = NumB - 1
        If NumB = 0 Then NumB = 1
        Call CNIT()
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
    End Sub
    Private Sub AggBank()
        Dim Yit, k2 As Integer
        For k1 = 1 To 4
            If LTrim(RTrim(Bank(Yit, k1))) = LTrim(RTrim(BankR(k))) Then
                If k1 < 4 Then
                    For k2 = k1 To 3 : Bank(Yit, k2) = Bank(Yit, k2 + 1) : Next k2
                End If 'p
                Bank(Yit, 4) = "$$$$"
                Exit For
            End If 'q
        Next k1
    End Sub
    Sub Aggk1()
        Dim j1, kk1 As Short
        For j1 = 1 To 99
            'k1(j1) = 1
            k1dim(j1) = 0
        Next j1
        For j1 = 1 To 99
            For kk1 = 1 To NumB
                If Disposiz.Nite(kk1, j1) <= NumIt And Disposiz.Nite(kk1, j1) > 0 Then k1dim(Disposiz.Nite(kk1, j1)) = k1dim(Disposiz.Nite(kk1, j1)) + 1
            Next kk1
        Next j1
        For j1 = 1 To NumIt
            If k1dim(j1) < 4 Then
                For kk1 = k1dim(j1) + 1 To 4 : Bank(j1, kk1) = "$$$$" : Next kk1
            End If 'o
        Next j1
    End Sub

    Sub CNIT()
        Dim j1, kk1, j2 As Short
        Dim icount As Short
        Dim jcontLoc(99) As Short
        For kk1 = 1 To NumB
            For j1 = 1 To 99 : Disposiz.Nite(kk1, j1) = 0 : Next
            icount = 0
            For j1 = 1 To NumIt
                For j2 = 1 To 4
                    If BankR(kk1) = Bank(j1, j2) Then
                        icount = icount + 1
                        Disposiz.Nite(kk1, icount) = j1 'Nite(k,j) lista items montati sul banco k
                    End If 'm
                Next j2
            Next j1
            If Disposiz.Nite(kk1, 1) = 0 Then Disposiz.Nite(kk1, 1) = NumIt + 4
        Next kk1
        'icount = 0
        'For kk1 = 1 To NumB
        '    For j1 = 1 To 99
        '      If Disposiz.Nite(kk1, j1) = 0 Then Exit For
        '      For j2 = 1 To NumIt
        '         If Disposiz.jcont(j2) = Disposiz.Nite(kk1, j1) Then
        '            icount = icount + 1
        '           jcontLoc(icount) = Disposiz.jcont(j2)
        '           Exit For
        '         End If
        '      Next
        '    Next
        'Next
        'For j2 = 1 To NumIt
        '   Disposiz.jcont(j2) = jcontLoc(j2)
        '   ItemC(j2) = Item(jcontLoc(j2))
        'Next
        If LeggiNITE Then Call RetrNITE()
        Call AggNITEF()
    End Sub

    Sub AggNITEF()
        Dim kk1, icount, j1 As Short
        icount = 0
        NITEB(0) = 0
        For kk1 = 1 To NumB
            For j1 = 1 To 99
                If Disposiz.Nite(kk1, j1) > 0 Then
                    icount = icount + 1
                    NITEF(icount) = Disposiz.Nite(kk1, j1)
                End If 'n
            Next j1
            NITEB(kk1) = icount
        Next kk1
    End Sub
    Sub RetrNITE()
        Dim File1 As String
        Dim iff As Short
        Dim D As Dispos = New typBuf.Dispos
        D.Initialize()
        File1 = Monitor.Motore.Inizio.Workdir + "\" + RTrim(job.Contratto) + ".ST1"
        If Not IO.File.Exists(File1) Then Exit Sub
        iff = FreeFile()
        FileOpen(iff, File1, OpenMode.Binary)
        If LOF(iff) = 0 Then FileClose(iff) : Exit Sub
        FileGet(iff, D)
        FileClose(iff)
        If D.NumIt = NumIt Then Disposiz = D
    End Sub
    Public Sub SceltaActAlt()
        Dim j, k As Short
        Dim Testo As String
        Dim iF1 As Short
        Dim Archiv(99) As Short
        Dim dAiu(99) As String
        If SoloUno Then
            Testo = "Tutti gli items hanno al più una alternativa." & vbCrLf
            Testo = Testo & "Non vi sono quindi scelte da operare."
            MsgBox(Testo, MsgBoxStyle.OkOnly + MsgBoxStyle.Information)
            Exit Sub
        End If
        For j = 1 To NumIt
            Dom(j) = "Item " & Item(j)
            If Ialt(2, j) = 0 Then
                Archiv(j) = 0
                Risp(j) = ""
            Else
                iF1 = FreeFile()
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.Inizio. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                FileOpen(iF1, RTrim(Monitor.Motore.Inizio.Archdir) & "\ARCH" & Trim(Str(1000 + j)) & ".DAT", OpenMode.Output)
                PrintLine(iF1, "  25   0   0   0")
                For k = 1 To 5
                    If Ialt(k, j) > 0 Then PrintLine(iF1, Str(Ialt(k, j)))
                Next
                FileClose(iF1)
                Risp(j) = Str(ActivAlt(j))
                Archiv(j) = 1000 + j
            End If
        Next j
        Testo = "Scelta alternative attive"
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.Chiamante. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        Monitor.Motore.Chiamante = Monitor
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.InputDati. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        Monitor.Motore.InputDati(NumIt, Testo, Dom, Risp, "", Archiv, dAiu)
        For j = 1 To NumIt
            ActivAlt(j) = Val(Risp(j))
        Next
    End Sub
    Public Sub SetActAlt()
        Dim j, k As Short
        SoloUno = True
        For j = 1 To NumIt
            For k = 2 To 5
                If Ialt(k, j) > 0 Then SoloUno = False
                Exit For
            Next k
        Next j
        If SoloUno Then
            For j = 1 To NumIt
                ActivAlt(j) = Ialt(1, j)
            Next
        Else
            For j = 1 To NumIt
                If ActivAlt(j) = 0 Then ActivAlt(j) = Ialt(1, j)
            Next
        End If
    End Sub
    Public Sub SalvaNITE()
        Dim iff As Short
        iff = FreeFile()
        FileOpen(iff, Monitor.Motore.Inizio.Workdir + "\" + RTrim(job.Contratto) + ".ST1", OpenMode.Binary)
        Disposiz.NumIt = NumIt
        FilePut(iff, Disposiz)
        FileClose(iff)
    End Sub
    Public Sub LanciaUPTX2()
        Dim j, ifl, jj As Short
        Dim k As Short
        Dim NewF As String
        ifl = FreeFile()
        FileOpen(ifl, Monitor.Motore.Inizio.DiscoTem & RTrim(job.Contratto), OpenMode.Output)
        For j = 1 To NumIt
            jj = Disposiz.jcont(j)
            ' Tipo(j) = ActivAlt(jj) 'Val(Risp$(jj))
            PrintLine(ifl, Str(ActivAlt(jj))) ' Risp$(jj)
        Next
        PrintLine(ifl, NumB)
        For k = 1 To NumB
            For j = NITEB(k - 1) + 1 To NITEB(k)
                Print(ifl, Disposiz.jcont(NITEF(j)) & ",")
            Next j 'd
            For j = NITEB(k) + 1 To 100
                Print(ifl, "0,")
            Next j 'e
            PrintLine(ifl)
        Next k
        For j = 1 To NumB : PrintLine(ifl, BankR(j)) : Next j
        FileClose(ifl)
        'UPGRADE_WARNING: Dir ha un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
        If Len(Dir("TEX1" & RTrim(job.Contratto))) > 0 Then IO.File.Delete("TEX1" & RTrim(job.Contratto))
        UPTX2(Check, Rev)
        IO.File.Delete(Monitor.Motore.Inizio.DiscoTem & Trim(job.Contratto))
        NewF = CStr(Monitor.Motore.Inizio.Workdir + Chr(92) + CDbl(Left(job.Contratto, 4)) + CDbl(".SUM"))
        FileCopy("TEX1" & Trim(job.Contratto), NewF)
        IO.File.Delete("TEX1" & Trim(job.Contratto))
        Shell("NotePad " & NewF, AppWinStyle.NormalFocus)
    End Sub

    Public Sub CambiaDispBank()
        Dim NumBN, iff, j As Short
        Dim OKStr As Boolean
        Dim Fstr As String
        Call Aggk1()
        Call Inq(NumBN) ' chiede il numero di banchi: da cambiare
        If NumBN > NumB Then
            For j = NumB + 1 To NumBN
                BankR(j) = GlobalRoutines.myStr(CSng(j), 4, 0, True)
            Next j 'c
        End If 'i
        NumB = NumBN
        ItemC(NumIt + 1) = "Elimina"
        ItemC(NumIt + 2) = "Aggiungi prima"
        ItemC(NumIt + 3) = "Aggiungi in f."
        ItemC(NumIt + 4) = "????"
        'For k = 1 To NumB
        'GoSub Stringh
        'Monitor.Motore.InputDatiM k, Nposs, Tit, Dom$(), Risp$(), "", Arch(), dAiu()
        'Next k
        'WindowSetCurrent kvec
        'Nposs = NITEB(kvec) - NITEB(kvec - 1)
        'k = kvec
        'GoSub Stringh
        'y = InputDati(0, Nposs, a$, Dom$(), Risp$(), LungSt())
        'Do
        'Select Case y
        '    Case -3
        '               Help$ = at1(400+34) '"Help non disponibile"
        '               junk = Alert(4, Help$, 4, 3, 10, 58, "OK", "", "")
        '    Case -2
        '               GoSub WClose: Xtip = 0: Close #ifl: Exit Sub
        '    Case -1
        '               GoSub WClose: Exit Do
        ''    Case 1000
        ''    k = WindowCurrent
        ''Nposs = NITEB(k) - NITEB(k - 1)
        ''GoSub Stringh
        ''Case Else
        ''k = WindowCurrent
        ''y = y - NITEB(k - 1)
        ''For k2 = 1 To k
        ''      If NITEB(k2) = NITEB(k2 - 1) Then y = y - 1
        ''  Next
        ''    For k2 = 1 To NumIt
        ''If RTrim$(ItemC$(k2)) = RTrim$(Risp$(y)) Then Yit = k2: Exit For
        ''Next k2
        ''x = myListBox(NumB + 1, 1, 1, ItemC$(), NumIt + 3, 0, "Scelta item", True)
        ''If x = 0 Then
        ''ElseIf x < NumIt + 1 Then
        ''If NITEB(k) = NITEB(k - 1) Then NITEB(k) = NITEB(k) + 1
        ''If k1(x) >= 4 Then
        ''GoSub Wwarn
        ''Else
        ''Nite(k, y) = x
        ''k1(x) = k1(x) + 1
        ''Bank(x).St(k1(x)) = BankR(k).St
        ''Risp$(y) = Adjust(ItemC$(Nite(k, y)), 20)
        ''Nposs = NITEB(k) - NITEB(k - 1)
        ''End If 'j
        ''GoSub AggBank
        ''ElseIf x = NumIt + 1 Then 'Elimina
        ''Nposs = NITEB(k) - NITEB(k - 1)
        ''If y < Nposs Then
        ''For j1 = y To Nposs - 1
        ''Nite(k, j1) = Nite(k, j1 + 1)
        ''Next
        ''End If   'k
        ''For kkk = Nposs To 99: Nite(k, kkk) = 0: Next
        ''k1(Yit) = k1(Yit) - 1
        ''GoSub AggBank
        ''NITEB(k) = NITEB(k) - 1
        ''Nposs = NITEB(k) - NITEB(k - 1)
        ''GoSub WClose
        ''If Nposs < 1 Then Exit Do
        ''GoTo Rifa6
        ''ElseIf x = NumIt + 2 Then   'Aggiungi  prima
        ''NITEB(k) = NITEB(k) + 1
        ''Nposs = NITEB(k) - NITEB(k - 1)
        ''For j = Nposs To y + 1 Step -1
        ''Nite(k, j) = Nite(k, j - 1)
        ''Next
        ''x = myListBox(NumB + 1, 1, 1, ItemC$(), NumIt, 0, "Aggiungi quale?", True)
        ''If x = 0 Then GoSub WClose: GoTo Rifa6
        ''Nite(k, y) = x
        ''If k1(x) >= 4 Then GoSub Wwarn: Close #ifl: GoTo Rifa6
        ''k1(x) = k1(x) + 1
        ''Bank(x).St(k1(x)) = BankR(k).St
        ''GoSub WClose: GoTo Rifa6
        ''Else                'Aggiungi in fondo
        ''NITEB(k) = NITEB(k) + 1
        ''Nposs = NITEB(k) - NITEB(k - 1)
        ''x = myListBox(NumB + 1, 1, 1, ItemC$(), NumIt, 0, "Aggiungi quale?", True)
        ''If x = 0 Then GoSub WClose: GoTo Rifa6
        ''Nite(k, Nposs) = x
        ''If k1(x) >= 4 Then GoSub Wwarn: GoTo Rifa6
        ''k1(x) = k1(x) + 1
        ''Bank(x).St(k1(x)) = BankR(k).St
        ''GoSub WClose: GoTo Rifa6
        ''End If 'l
        ''End Select
        ''y = InputDati(0, Nposs, a$, Dom$(), Risp$(), LungSt())
        ''Loop
        Call AggNITEF()
        SalvaSTR()
        SalvaNITE()
        Call FixFin()
        iff = FreeFile()
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.Inizio. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        Fstr = CStr(Monitor.Motore.Inizio.Workdir + "\" + CDbl(RTrim(job.Contratto)) + CDbl(".STR"))
        'UPGRADE_WARNING: Dir ha un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
        If Len(Dir(Fstr)) > 0 Then
            FileOpen(iff, Fstr, OpenMode.Input)
            OKStr = (LOF(iff) > 0)
            FileClose(iff)
        Else
            OKStr = False
        End If
        'in Bank(j) c'e' il banco di ItemC$(j)
        If OKStr Then
            MostraAiuto(IDH_SOMM_RIPETUTO, ChiaviMess.MessInformation Or ChiaviMess.MessOK Or ChiaviMess.MessHelpButton, "ISA - Avvertenza")
            'Monitor.Motore.RetrHelp Monitor.Motore.Inizio.Archdir + "\IT\SOMM01.DAT"
        End If
        'Exit Sub
        'Wwarn:
        '        '               Help$ = "Non sono ammesse piu' di quattro |"
        '        '       Help$ = Help$ + "ripetizioni dello stesso item    |"
        '        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.Inizio. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '        Riga = Monitor.Motore.Inizio.ConvertiCr(at1(400 + 32))
        '        MsgBox(Riga)
        '        'UPGRADE_WARNING: Return ha un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
        '        Return
        'Stringh:
        '        A = "Banco nø" & Str(k) & ": '" & BankR(k).St & "'"
        '        If NITEB(k - 1) = NITEB(k) Then
        ' Nposs = 1
        ' Dom(1) = "Nuovo Item"
        ' Risp(1) = ItemC(NumIt + 4)
        ' 'LungSt(1) = -20
        ' Else
        ' Nposs = NITEB(k) - NITEB(k - 1)
        ' For j = 1 To Nposs
        ' Dom(j) = "Item " & Str(j) & ":"
        ' 'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Adjust(). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        ' Risp(j) = ItemC(Disposiz.Nite(k, j)).PadRight(20)
        ' Itemn.St = Risp(j)
        ' 'LungSt(j) = -20
        ' Next j 'h
        ' End If 'r
        ''UPGRADE_WARNING: Return ha un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
        'Return
    End Sub
    Private Sub FixFin()
FixFin:
        For j = 1 To NumB
            For k = 1 To 99
                If Disposiz.Nite(j, k) = 0 Then Exit For
                Bank(Disposiz.Nite(j, k), 1) = BankR(j)
            Next k
        Next j
        For j = 1 To NumIt
            ItemnSt = Item(j)
            For k = 1 To 3
                For k1 = k + 1 To 4
                    If Bank(j, k) = "$$$$" And Bank(j, k1) <> "$$$$" Then GlobalRoutines.SWAP(Bank(j, k), Bank(j, k1))
                    Exit For
                Next k1
            Next k
            SETRDIT(ItemnSt, Nrdit)
            PUTBANK(Bank)
        Next
    End Sub
    Private Sub Inq(ByRef NumBN As Integer)
        Dom(1) = "Progettista"
        Dom(2) = "Revisione"
        Dom(3) = "Numero banchi"
        Risp(1) = Check
        Risp(2) = " 0"
        Risp(3) = " " & Str(NumB)
        'For i = 1 To 3: LungSt(i) = Len(Risp$(i)): Next
        A = "Sommario"
        Monitor.Motore.Chiamante = Monitor
        Monitor.Motore.InputDati(3, A, Dom, Risp, "", Arch, dAiu)
        Check = Risp(1)
        Rev = Risp(2)
        NumBN = Val(Risp(3))
    End Sub

    Public Sub MonFVC()
        If Apert.SelezioneMultipla.Count() = 1 Then
            SmontIt(0, 0)
            Exit Sub
        End If
        If Apert.SelezioneMultipla.Count() < 2 Or Apert.SelezioneMultipla.Count() > 6 Then
            MostraAiuto(IDH_MFVC_PROCEDURA)
            Exit Sub
        End If
        NGrupp = Apert.SelezioneMultipla.Count()
        For i = 1 To NGrupp
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Apert.SelezioneMultipla().Text. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            ItemCloc(i) = Apert.SelezioneMultipla.Item(i).Text
            ListIt_Renamed.St(i) = ItemCloc(i)
        Next
        For j = 1 To NGrupp
            TipOper = (InStr(ItemCloc(1), "|") > 0)
            If TipOper Then
                'Errore sono stati scelti items già montati
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.Inizio. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                MsgBox(Monitor.Motore.Inizio.ConvertiCr(at1(400 + 49)))
                '    x = Alert(4, at1(400+49), 9, 10, 14, 70, at1(400+34), Space$(0), Space$(0))
                Exit Sub
            End If
        Next
        For i = 1 To NumIt
            For j = 1 To NGrupp
                If Trim(ItemCloc(j)) = Trim(Item(i)) Then
                    ListaMon.Ialt(j) = ActivAlt(i)
                    If j < NGrupp Then
                        If Disposiz.jcont(i + 1) <> Disposiz.jcont(i) + 1 Then
                            MostraAiuto(IDH_MFVC_NONSEQUENZA)
                            Exit Sub
                        End If
                    End If
                    If j = 1 Then
                        job.Comm.Ind(1).Data.Assieme = Str(i)
                        job.Comm.Ind(2).Data.Assieme = CStr(ActivAlt(i))
                        NewAlt = ActivAlt(i)
                    End If
                End If
            Next
        Next
        'TipOper = (InStr(ItemC(1), "|") > 0)
        'Controllare che Ialt(k,j) sia già definito
        'For j = 1 To i
        'Itemn.St = Item$(j)
        'SETRDIT Itemn, Nrdit
        'SEARCHA Ialta
        'For k = 1 To 5
        ' If ListaMon.Ialt(k) > 0 Then Ialt(k, j) = k Else Ialt(k, j) = 0
        'Next
        'Next j
        'Controllare che Listit sia già definito
        'For j = 1 To i
        ' ListaMon.Ialt(j) = Val(Risp$(j))
        ' ListIt.St(j) = Item$(j)
        'Next j
        'Else
        'For j = 1 To i
        ' ListaMon.Ialt(j) = 1
        ' ListIt.St(j) = Item$(j)
        'Next j
        '===============================================
        MFVC1(NGrupp, ListIt_Renamed, ListaMon)
        iF3 = FreeFile()
        FileOpen(iF3, Monitor.Motore.Inizio.DiscoTem & Trim(job.Contratto), OpenMode.Input)
        For j = 1 To 6 : Riga = LineInput(iF3) : Next
        For j = 1 To NGrupp
            Riga = LineInput(iF3)
            If Mid(Riga, 2, 2) = ">>" Then
                Call CondErr()
                FileClose(iF3)
                Kill(Monitor.Motore.Inizio.DiscoTem & Trim(job.Contratto))
                Call Riprist(NewAlt)
                Exit Sub
            End If
            Scelta(j) = Val(Mid(Riga, 49, 3))
            Dom(j) = RTrim(ItemCloc(j)) & ": N° fasci tot.:" & Str(Scelta(j))
            Risp(j) = "  1"
            '   LungSt(j) = 3
        Next
        FileClose(iF3)
Rifa6:
        A = "Prelievo fasci"
        Monitor.Motore.Chiamante = Monitor
        If Not Monitor.Motore.InputDati(NGrupp, A, Dom, Risp, "", Archiv, dAiu) Then Exit Sub
        OK = True
        For j = 1 To NGrupp
            ListaMon.Ialt(j) = Val(Risp(j))
            If ListaMon.Ialt(j) = 0 Or ListaMon.Ialt(j) > Scelta(j) Then OK = False
        Next j
        If Not OK Then GoTo Rifa6
        If ListaMon.Ialt(1) <> Scelta(1) Then
            Stop
            '         a$ = at1(15)
            ''         a$ = "  Devi   prendere tutti i fasci|"
            ''    a$ = a$ + "dal primo item. Cambialo       |"
            '    x = Alert(4, a$, 9, 10, 14, 70, at1(34), Space$(0), Space$(0))
            '    Kill at1(22) + RTrim$(job.contratto)
            '    Exit Sub
        End If
        MFVC2(ListaMon)
        ItemnSt = ItemCloc(1)
        SETRDIT(ItemnSt, Nrdit)
        SETALT(NewAlt)
        A = GlobalRoutines.myStr(CSng(Nrdit \ 2), 2, 0, True)
        If Left(A, 1) = Space(1) Then Mid(A, 1, 1) = Chr(48)
        NewF = Monitor.Motore.Inizio.Workdir + "\" + Left(job.Contratto, 4) + A + ".MFV"
        IO.File.Delete(NewF)
        iF3 = FreeFile()
        FileOpen(iF3, Monitor.Motore.Inizio.DiscoTem & Trim(job.Contratto), OpenMode.Input)
        iF4 = FreeFile()
        FileOpen(iF4, NewF, OpenMode.Output)
        Do
            Riga = LineInput(iF3)
            If Mid(Riga, 2, 2) = ">>" Then
                Call CondErr()
                FileClose(iF3) : IO.File.Delete(Monitor.Motore.Inizio.DiscoTem & Trim(job.Contratto))
                FileClose(iF4) : IO.File.Delete(NewF)
                Call Riprist(NewAlt)
                Exit Sub
            End If
            PrintLine(iF4, Riga)
            If EOF(iF3) Then Exit Do
        Loop
        FileClose(iF3) : FileClose(iF4) : IO.File.Delete(Monitor.Motore.Inizio.DiscoTem & RTrim(job.Contratto))
        'a$ = at1(29)
        'Call Deallocat1
        'EditoreF 2, NewF$, a$ '"Raggruppamento items"
        'GoSub Riprist
        'SALVA
        'CLOSPREV
        Shell("NotePad " & NewF, AppWinStyle.NormalFocus)
        AddDistinta = 3 : ScelMot()
        'Catena "HTRI"
        icar = 0
        For i = 1 To NumIt
            n = InStr(ItemC(i), "|")
            If n > 0 Then
                j = Val(Right(ItemC(i), Len(ItemC(i)) - n))
                If icar < j Then icar = j
            End If
        Next
        icar = icar + 1
        For i = 1 To NumIt
            For j = 1 To NGrupp
                If Trim(ItemCloc(j)) = Trim(Item(i)) Then
                    ItemC(i) = Trim(ItemC(i)) & " |" & Str(icar)
                    Exit For
                End If
            Next
        Next
        FillTree(1)
        Exit Sub
    End Sub
    Private Sub Riprist(ByVal NewAlt As Integer)
        job.Comm.Ind(1).Data.Assieme = RTrim(ListIt_Renamed.St(1))
        job.Comm.Ind(2).Data.Assieme = Str(NewAlt)
        ItemnSt = LTrim(job.Comm.Ind(1).Data.Assieme)
        SETRDIT(ItemnSt, Nrdit)
        SETALT(NewAlt)
        job.Salva()
    End Sub
    Private Sub CondErr()
        '          a$ = RTrim$(at1(14))
        A = "|Si e' determinata una condizione di errore.| |"
        l = Len(Riga)
        For k = 1 To l Step 44
            A = A & Mid(Riga, k, 44) & "|"
        Next
        MsgBox(Monitor.Motore.Inizio.ConvertiCr(A))
    End Sub
    Public Function TrovaNumero(ByRef A As String) As Short
        Dim i As Short
        For i = 1 To Len(A)
            If Val(Mid(A, i, 1)) > 0 Then
                TrovaNumero = Val(Right(A, Len(A) - i + 1))
                Exit Function
            End If
        Next
    End Function
    Sub Compatta()
        Dim j, Xtip, k As Short
        Dim k1, k2 As Short
        Dim A As String
        ReDim Ialt(5, 99)
        Ialt(5, 99) = 33
        If Asc(job.Contratto) < 33 Then Exit Sub
        'a$ = "Ricerca degli items e|"
        'a$ = a$ + "delle alternative in corso"
        'Handle = Messaggio(1, at1(35), 8, 8, 12, 50)
        Xtip = 1
        ListAltD(Xtip)
        If Xtip = 0 Then Exit Sub
        For j = 1 To NumIt
            If Ialt(1, j) = 0 Then
                A = at1(400 + 26)
                '         a$ = "Ci sono degli items senza al-|"
                '    a$ = a$ + "ternative. Operazione negata.|"
                MsgBox(Monitor.Motore.Inizio.ConvertiCr(A))
                Exit Sub
            End If
        Next
        'a$ = at1(400+27) ' "Compattamento in corso,|"
        'a$ = a$ + "grazie per la pazienza..."
        'Handle = Messaggio(1, a$, 8, 8, 12, 50)
        For j = 1 To NumIt
            k = ActivAlt(j)
            For k1 = 1 To 5
                If Ialt(k1, j) > 0 And Ialt(k1, j) <> k Then
                    ItemnSt = Item(j)
                    SETRDIT(ItemnSt, Nrdit)
                    SETALT(Ialt(k1, j))
                    DELNOT()
                    DELALT()
                    If k > Ialt(k1, j) Then k = k - 1
                    For k2 = k1 + 1 To 5
                        If Ialt(k2, j) > 0 Then Ialt(k2, j) = Ialt(k2, j) - 1
                    Next
                End If
            Next k1
        Next j 'l
        job.Comm.Ind(3).Data.Assieme = "*" 'distinta compattata
        job.Salva()
    End Sub
    Public Sub CheckGruppo(ByRef BANCO As String)
        Dim Aster As String
        Dim itp As String = ""
        Dim NumPrim As Short
        Dim NumGrupp, NumItCom, j As Short
        Dim u As String
        Aster = LTrim(RTrim(objDatBase.DatBase(4, 19, Nrdit \ 2, 1, itp, 0)))
        If Aster <> "*" Then Exit Sub
        NumPrim = objDatBase.CVI(objDatBase.DatBase(4, 36, Nrdit \ 2, 1, itp, 0)) \ 2
        NumItCom = objDatBase.CVI(objDatBase.DatBase(4, 35, NumPrim, 1, itp, 0))
        ' CLOSPREV()
        For j = 1 To NumItCom
            NumGrupp = objDatBase.CVI(objDatBase.DatBase(4, 35 + j, NumPrim, 1, itp, 0)) \ 2
            If NumGrupp <> Nrdit \ 2 Then
                u = objDatBase.PutBasCh(2, 2, NumGrupp, 1, BANCO, 0)
            End If
        Next
        '  Apri(Trim(job.Contratto))
    End Sub

    Public Sub Smonta(ByRef jj As Short)
        Dim NumItCom, i, Lista As Short
        Dim itp As String = ""
        ' CLOSPREV()
        NumItCom = objDatBase.CVI(objDatBase.DatBase(4, 35, jj, ActivAlt(jj), itp, 0))
        For i = 1 To NumItCom
            Lista = objDatBase.CVI(objDatBase.DatBase(4, 35 + i, jj, ActivAlt(jj), itp, 0)) \ 2
            If Lista > 0 And Lista <= NumIt Then objDatBase.PutBasCh(4, 19, Lista, ActivAlt(Lista), "  ", 0)
        Next
        '  Apri(Trim(job.Contratto))
    End Sub

    Public Sub SalvaSTR()
        Dim k, iff, j As Short
        Dim A As String
        Dim Nposs, n As Short
        Dim Items As String
        iff = FreeFile()
        FileOpen(iff, CStr(Monitor.Motore.Inizio.Workdir + Chr(92) + CDbl(RTrim(job.Contratto)) + CDbl(".STR")), OpenMode.Output)
        For k = 1 To NumB
            A = "Banco " & BankR(k)
            PrintLine(iff, A)
            Nposs = NITEB(k) - NITEB(k - 1)
            PrintLine(iff, Nposs)
            For j = 1 To Nposs
                Dom(j) = "Item " & Str(j) & ":"
                Items = ItemC(Disposiz.Nite(k, j))
                n = InStr(Items, Chr(179))
                If n > 0 Then Items = Left(Items, n - 1)
                Risp(j) = Items.PadRight(20)
                ItemnSt = Risp(j)
                SETRDIT(ItemnSt, Nrdit)
                PrintLine(iff, Dom(j) & Risp(j) & "|" & Str(Nrdit \ 2))
            Next j 'h
        Next k
        FileClose(iff)
    End Sub
End Module