Option Strict Off
Option Explicit On
Imports System.IO
Imports LibMat
Imports RoutBase1
Imports System.Runtime.Serialization
Imports System.Runtime.Serialization.Formatters.Binary 'Namespace for BinaryFormatter
Module Input_Renamed
    Public Saltacombo, SaltaDati As Boolean
    Private TipoPT As Short
    Private Nodbase(3) As TreeNode
    Sub AcqNomi(ByRef Stringa1() As String, ByRef n As Short, Optional ByRef iRisp As Short = 0, Optional ByRef iTipo As Short = -1)
        Dim j, i, jj As Short
        Static Tipo(20) As Short
        Stringa1(1) = "Cilindro"
        Stringa1(2) = "Fondo   "
        Stringa1(3) = "Cono    "
        Stringa1(4) = "Conoide "
        Stringa1(5) = "Belt    "
        Stringa1(6) = "Flangioni/Coperchi"
        Stringa1(7) = "Piastre Tubiere"
        Stringa1(8) = "Tubi di scambio"
        Stringa1(9) = "Dilatatore"
        Stringa1(10) = "Setti partitori"
        For i = 11 To 20
            Stringa1(i) = ""
        Next
        Dim counter As Short
        Select Case n
            Case 0
            Case -1
                n = 10
                For i = 1 To n
                    Tipo(i) = i
                Next
                For i = n + 1 To 20
                    Tipo(i) = 0
                Next
                Select Case kLato
                    Case 1
                        Stringa1(7) = ""
                        Stringa1(8) = ""
                        Stringa1(10) = ""
                    Case 2
                        Stringa1(7) = ""
                        Stringa1(8) = ""
                    Case 3
                        Stringa1(10) = ""
                End Select
                counter = n
                For i = 1 To counter
                    If Stringa1(i) = "" Then
                        n = n - 1
                        For j = i To n
                            Stringa1(j) = Stringa1(j + 1)
                            Tipo(j) = Tipo(j + 1)
                            If Involucr(kLato, jInvolucr).Tipo = Tipo(j) - 1 Then jj = j
                        Next
                        If i > n Then Exit For
                        i = i - 1
                    End If
                Next
                If jj = 0 Then jj = 1
                iRisp = Monitor.Motore.Quale(n, "Tipo membratura", Stringa1, "", jj)
                If iRisp > 0 Then iTipo = Tipo(iRisp) - 1
        End Select
    End Sub

    Sub AdjUnit()
        Dim i, n As Short
        Try
            If Config(0).US = 0 Then
                UnitPress = "[MPa]" : UnitTemp = "[°C]"
                UnitLength = "[mm]" : UnitArea = "[mm2]"
                UnitForce = "[N]" : UnitMomI = "[mm4]"
                UnitMomF = "[Nmm]" : Unitkappa = "[N/mm]"
                kPress = 1
                kTemp = 1
                kTemp32 = 0
                kLength = 1
                kForce = 1
                kMomI = 1
                kMomF = 1
                kkappa = 1
                IncrVirgola = 2
            ElseIf Config(0).US = 1 Then
                UnitPress = "[psi]" : UnitTemp = "[°F]"
                UnitLength = "[mm]" : UnitArea = "[mm2]"
                UnitForce = "[lb]" : UnitMomI = "[mm4]"
                UnitMomF = "[lb.in]" : Unitkappa = "[lb/in]"
                kPress = psi
                kTemp = 1.8
                kTemp32 = 32
                kLength = 1
                kForce = 1 / NIUT
                kMomI = 1
                kMomF = 1 / NIUT / inc
                kkappa = 1 / NIUT * inc
                IncrVirgola = 0
            ElseIf Config(0).US = 2 Then
                UnitPress = "[psi]" : UnitTemp = "[°F]"
                UnitLength = "[in]" : UnitArea = "[in2]"
                UnitForce = "[lb]" : UnitMomI = "[in4]"
                UnitMomF = "[lb.in]" : Unitkappa = "[lb/in]"
                kPress = psi
                kTemp = 1.8
                kTemp32 = 32
                kLength = 1 / inc
                kForce = 1 / NIUT
                kMomI = kLength ^ 4
                kMomF = 1 / NIUT / inc
                kkappa = 1 / NIUT * inc
                IncrVirgola = 0
            End If
            With mioGen
                For i = 0 To 33
                    Select Case i
                        Case 1, 5, 9, 11, 12, 2, 19, 29, 31, 32
                            n = InStr(.Label1(i).Text, "[")
                            If n > 0 Then .Label1(i).Text = Trim(Left(.Label1(i).Text, n - 1))
                            .Label1(i).Text = .Label1(i).Text & " " & UnitPress
                        Case 6, 8, 10, 13, 20, 28, 30, 33
                            n = InStr(.Label1(i).Text, "[")
                            If n > 0 Then .Label1(i).Text = Trim(Left(.Label1(i).Text, n - 1))
                            .Label1(i).Text = .Label1(i).Text & " " & UnitTemp
                        Case 4, 18, 22, 23
                            n = InStr(.Label1(i).Text, "[")
                            If n > 0 Then .Label1(i).Text = Trim(Left(.Label1(i).Text, n - 1))
                            .Label1(i).Text = .Label1(i).Text & " " & UnitLength
                    End Select
                Next
            End With
        Catch e As Exception
            messagebox.show(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub

    Sub AggBocc(ByRef j As Short, ByRef Nvec As Short, ByRef Nnuov As Short)
        Dim Nnozzv, Nfine, Nnozzn As Short
        Dim k, jFine, Ntot As Short
        Dim jj As Short
        Dim NumeroPrima As Short
        Dim Cercanome As clsCercaNome
        If j >= 0 Then
            If Nvec = Nnuov Then
                If Nnuov = 0 Then
                    If j > 1 Then
                        Nfine = Involucr(kLato, j - 1).Fine
                        If Involucr(kLato, j - 1).Fine < Involucr(kLato, j - 1).inizio Then Nfine = Involucr(kLato, j - 1).inizio
                        Involucr(kLato, j).inizio = Nfine
                    Else
                        Involucr(kLato, j).inizio = 1
                    End If
                    Involucr(kLato, j).Fine = Involucr(kLato, j).inizio - 1
                Else
                    If j > 1 Then
                        'bisognerebbe eventualmente cercare all'indietro il primo che ne ha
                        '         Nfine = Involucr(kLato, j - 1).Fine
                        '         If Involucr(kLato, j - 1).Fine < Involucr(kLato, j - 1).Inizio Then Nfine = Involucr(kLato, j - 1).Inizio - 1
                        '         Involucr(kLato, j).Inizio = Nfine + 1
                    Else
                        Involucr(kLato, j).inizio = 1
                    End If
                    Involucr(kLato, j).Fine = Involucr(kLato, j).inizio + Nnuov - 1
                End If
                Ntot = NumBocch(kLato)
                'UPGRADE_WARNING: Return ha un nuovo comportamento. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1041"'
                Return
            ElseIf Nvec < Nnuov Then
                Nnozzv = NumBocch(kLato) + NumBocch2(kLato)
                Nnozzn = Nnozzv + Nnuov - Nvec
                CheckDimNoz(Nnozzn)
                jFine = Involucr(kLato, j).Fine
                If Involucr(kLato, j).Fine < Involucr(kLato, j).inizio Then jFine = Involucr(kLato, j).inizio
                For k = Nnozzv To jFine Step -1
                    If Not ElencoInvolucri Is Nothing Then
                        Cercanome = ElencoInvolucri.Item(Trim(Nozzles(kLato, k).Mark))
                        Cercanome.kNozzle = k + Nnuov - Nvec
                    End If
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Nozzles(kLato, k + Nnuov - Nvec). Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                    Nozzles(kLato, k + Nnuov - Nvec) = Nozzles(kLato, k)
                Next
                For k = Config(kLato).Ninvolucri To j + 1 Step -1
182:                Involucr(kLato, k).inizio = Involucr(kLato, k).inizio + Nnuov - Nvec
                    Involucr(kLato, k).Fine = Involucr(kLato, k).Fine + Nnuov - Nvec
                Next
                For k = 1 To Config(kLato).Ninvolucri
                    If Involucr(kLato, k).inizio = 0 Then Involucr(kLato, k).inizio = 1
                    For jj = Involucr(kLato, k).inizio To Involucr(kLato, k).Fine
                        If Nozzles(kLato, jj).inizio = 0 Then
                            Nozzles(kLato, jj).inizio = Nozzles(kLato, jj).inizio + Nnuov - Nvec
                            Nozzles(kLato, jj).Fine = Nozzles(kLato, jj).Fine + Nnuov - Nvec - 1
                        ElseIf Nozzles(kLato, jj).inizio > 0 Then
                            Nozzles(kLato, jj).inizio = Nozzles(kLato, jj).inizio + Nnuov - Nvec
                            Nozzles(kLato, jj).Fine = Nozzles(kLato, jj).Fine + Nnuov - Nvec
                        End If
                    Next
                Next
                If j = 1 Then
                    If Involucr(kLato, j).inizio < 1 Or Involucr(kLato, j).inizio > 2 * MAXNOZZ Then Involucr(kLato, j).inizio = 1
                Else
                    jj = 0
                    Do
                        jj = jj + 1
                        If j - jj = 1 Then
                            If Involucr(kLato, j - jj).Fine < Involucr(kLato, j - jj).inizio Then
                                Involucr(kLato, j).inizio = 1
                            Else
                                Involucr(kLato, j).inizio = Involucr(kLato, j - jj).Fine + 1
                            End If
                            Exit Do
                        Else
                            If Involucr(kLato, j - jj).Fine >= Involucr(kLato, j - jj).inizio Then
                                Involucr(kLato, j).inizio = Involucr(kLato, j - jj).Fine + 1
                                Exit Do
                            End If
                        End If
                    Loop
                End If
                If Involucr(kLato, j).Fine < Involucr(kLato, j).inizio Then Involucr(kLato, j).Fine = Involucr(kLato, j).inizio + Nnuov - 1 Else Involucr(kLato, j).Fine = Involucr(kLato, j).Fine + Nnuov - Nvec
                For k = Involucr(kLato, j).inizio To Involucr(kLato, j).Fine
184:                Nozzles(kLato, k).InvolucroSU = j
                    If k >= Involucr(kLato, j).Fine - (Nnuov - Nvec - 1) Then
                        InserNN(k)
                    End If
                Next
                Topol(j)
            Else
                Ntot = NumBocch(kLato) + NumBocch2(kLato)
                For k = kNozzle To Ntot - 1 'kNozzle:bocchello da eliminare in EliminBocch
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Nozzles(kLato, k). Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                    If k >= Involucr(kLato, j).inizio Then Nozzles(kLato, k) = Nozzles(kLato, k + Nvec - Nnuov)
                Next
                Call Rearrang(kLato, j, Nvec, Nnuov)
                Topol(j)
            End If
            If Nnuov = 0 Then Involucr(kLato, j).Fine = Involucr(kLato, j).inizio - 1
        Else
            If Nvec = Nnuov Then
                If Nnuov = 0 Then
                    If -j > 1 Then
                        Nfine = Nozzles(kLato, -j - 1).Fine
                        If Nozzles(kLato, -j - 1).Fine < Nozzles(kLato, -j - 1).inizio Then Nfine = Nozzles(kLato, -j - 1).inizio
                        'If Nfine = 0 Then Nfine = NumBocch(kLato) + 1
                        Nozzles(kLato, -j).inizio = Nfine
                    Else
                        Nozzles(kLato, -j).inizio = NumBocch(kLato) + NumBocch2(kLato, -j - 1) + 1
                    End If
                    Nozzles(kLato, -j).Fine = Nozzles(kLato, -j).inizio - 1
                Else
                    If -j > 1 Then
                    Else
                        Nozzles(kLato, -j).inizio = NumBocch(kLato) + NumBocch2(kLato, -j - 1) + 1
                    End If
                    Nozzles(kLato, -j).Fine = Nozzles(kLato, -j).inizio + Nnuov - 1
                End If
                Topol1()
            ElseIf Nvec < Nnuov Then
                Nnozzv = NumBocch(kLato) + NumBocch2(kLato)
                Nnozzn = Nnozzv + Nnuov - Nvec
                CheckDimNoz(Nnozzn)
                jFine = Nozzles(kLato, -j).Fine
                If Nozzles(kLato, -j).Fine < Nozzles(kLato, -j).inizio Then jFine = Nozzles(kLato, -j).inizio
                NumeroPrima = NumBocch(kLato) + NumBocch2(kLato, -j - 1) + Nnuov - Nvec
                If jFine < NumeroPrima Then jFine = NumeroPrima
                'If jFine = 0 Then jFine = NumBocch(kLato) + NumBocch2(kLato) + Nnuov - Nvec
                'jFine = NumBocch(kLato) + NumBocch2(kLato) + Nnuov - Nvec
                For k = Nnozzv To jFine + 1 Step -1
                    If Not ElencoInvolucri Is Nothing Then
                        Cercanome = ElencoInvolucri.Item(Trim(Nozzles(kLato, k).Mark))
                        Cercanome.kNozzle = k + Nnuov - Nvec
                    End If
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Nozzles(kLato, k + Nnuov - Nvec). Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                    Nozzles(kLato, k + Nnuov - Nvec) = Nozzles(kLato, k)
                Next
                If -j < NumBocch(kLato) Then
                    jj = Nozzles(kLato, -j + 1).inizio
                Else
                    jj = 0
                End If
                If jj > 0 Then
                    For k = NumBocch(kLato) + NumBocch2(kLato) To jj Step -1
                        Nozzles(kLato, k).inizio = Nozzles(kLato, k).inizio + Nnuov - Nvec
                        Nozzles(kLato, k).Fine = Nozzles(kLato, k).Fine + Nnuov - Nvec
                    Next
                End If
                If -j = 1 Then
                    If Nozzles(kLato, -j).inizio < 1 Or Nozzles(kLato, -j).inizio > 2 * MAXNOZZ Then Nozzles(kLato, -j).inizio = NumBocch(kLato) + 1
                Else
                    jj = 0
                    Do
                        jj = jj + 1
                        If -j - jj = 1 Then
                            If Nozzles(kLato, -j - jj).Fine < Nozzles(kLato, -j - jj).inizio Or (Nozzles(kLato, -j - jj).Fine = 0 And Nozzles(kLato, -j - jj).inizio = 0) Then
                                Nozzles(kLato, -j).inizio = NumBocch(kLato) + 1
                            Else
                                Nozzles(kLato, -j).inizio = Nozzles(kLato, -j - jj).Fine + 1
                            End If
                            Exit Do
                        Else
                            If Not Nozzles(kLato, -j - jj).Fine = 0 Then
                                If Nozzles(kLato, -j - jj).Fine >= Nozzles(kLato, -j - jj).inizio Then
                                    Nozzles(kLato, -j).inizio = Nozzles(kLato, -j - jj).Fine + 1
                                    Exit Do
                                End If
                            Else
                                messagebox.show("Impossibile in AggBocc")
                                Exit Sub
                            End If
                        End If
                    Loop
                End If
                If Nozzles(kLato, -j).Fine < Nozzles(kLato, -j).inizio Then Nozzles(kLato, -j).Fine = Nozzles(kLato, -j).inizio + Nnuov - 1 Else Nozzles(kLato, -j).Fine = Nozzles(kLato, -j).Fine + Nnuov - Nvec
                For k = Nozzles(kLato, -j).inizio To Nozzles(kLato, -j).Fine
                    Nozzles(kLato, k).InvolucroSU = j
                    If k >= Nozzles(kLato, -j).Fine - (Nnuov - Nvec - 1) Then
                        InserNN(k)
                    End If
                Next
                Topol1()
            Else
                Ntot = NumBocch(kLato) + NumBocch2(kLato)
                For k = kNozzle To Ntot - 1
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Nozzles(kLato, k). Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                    If k >= Nozzles(kLato, -j).inizio Then Nozzles(kLato, k) = Nozzles(kLato, k + Nvec - Nnuov)
                Next
                Call Rearrang(kLato, j, Nvec, Nnuov)
                Topol1()
            End If
            If Nnuov = 0 Then Nozzles(kLato, -j).Fine = Nozzles(kLato, -j).inizio - 1
        End If
    End Sub
    Private Sub Topol(ByVal j As Short)
        Dim k, kk As Short
        For k = j + 1 To Config(kLato).Ninvolucri
            For kk = Involucr(kLato, k).inizio To Involucr(kLato, k).Fine
                Nozzles(kLato, kk).InvolucroSU = k
            Next
        Next
    End Sub
    Private Sub Topol1()
        Dim k, kk As Short
        Dim Nnozzv As Short = NumBocch(kLato)
        For k = 1 To Nnozzv
            If Nozzles(kLato, k).inizio = 0 Then Nozzles(kLato, k).inizio = Nnozzv + 1
            For kk = Nozzles(kLato, k).inizio To Nozzles(kLato, k).Fine
                Nozzles(kLato, kk).InvolucroSU = -k
            Next
        Next
    End Sub
    Private Sub InserNN(ByVal k As Short)
        Nozzles(kLato, k).indice = -1
        Nozzles(kLato, k).IndexF = -1
        Nozzles(kLato, k).IndiceP = -1
        Nozzles(kLato, k).indice = NuovoIndice()
        indici.Add(Nozzles(kLato, k).indice)
        Nozzles(kLato, k).RecInd = 0
        Nozzles(kLato, k).Mark = "Nuovo" & Trim(Str(kLato)) & Trim(Str(k))
        Dim jj As Short
        For jj = 1 To NumBocch(kLato) + NumBocch2(kLato)
            If Nozzles(kLato, k).Mark = Nozzles(kLato, jj).Mark Then
                Nozzles(kLato, k).Mark = Nozzles(kLato, k).Mark & "A"
                Exit For
            End If
        Next
        Nozzles(kLato, k).CorrA = Config(kLato).Corr
        Nozzles(kLato, k).IndexF = NuovoIndice()
        indici.Add(Nozzles(kLato, k).IndexF)
        Nozzles(kLato, k).IndiceP = NuovoIndice()
        indici.Add(Nozzles(kLato, k).IndiceP)
        Nozzles(kLato, k).inizio = 0 : Nozzles(kLato, k).Fine = 0
    End Sub
    Public Sub Ammiss(ByVal j As Short)
        Dim AllFOpe, AllFRoo As Single
        Dim codice As Codes
        Dim AllFHyd As Single
        Select Case Involucr(kLato, j).Tipo
            Case 7 'tubi
                If Involucr(kLato, jInvolucr).Norma = 0 Then
                    Select Case Config(2).DC
                        Case 0, 1, 2, 9, 10, 11
                            Select Case Config(0).US
                                Case 0 : codice = Codes.div1MPa
                                Case Else : codice = Codes.div1psi
                            End Select
                        Case 3, 4, 5
                            Select Case Config(0).US
                                Case 0 : codice = Codes.div2MPa
                                Case Else : codice = Codes.div2psi
                            End Select
                        Case 6, 7, 8 : codice = Codes.EU
                    End Select
                Else
                            codice = CodiceStress()
                End If
            Case Else : codice = CodiceStress()
        End Select
        AllFOpe = Involucr(kLato, j).St
        AllFRoo = Involucr(kLato, j).S0
        AllFHyd = Involucr(kLato, j).Shydr
        If codice = 8 Then
            AllFHyd = AllFHyd * mpa
            AllFRoo = AllFRoo * mpa
            AllFOpe = AllFOpe * mpa
        End If
        With Matdim(Involucr(kLato, j).indice(1 - 1))
            If .Indmat > 0 Or Not .Agganciato Then
                If codice = 8 Then
                    .SigmaAmm(codice, TempDes, AllFRoo, AllFOpe, AllFHyd)
                Else
                    If VerificandoPI Then
                        AllFHyd = .Yield() * FractSyPI
                    Else
                        .SigmaAmm(codice, TempDes, AllFRoo, AllFOpe)
                    End If
                End If
            End If 'n
        End With
        If AllFOpe > 0 Then Involucr(kLato, j).St = AllFOpe
        If AllFRoo > 0 Then Involucr(kLato, j).S0 = AllFRoo
        If AllFHyd > 0 Then Involucr(kLato, j).Shydr = AllFHyd
        MWDTdata(kLato, j)
    End Sub
    Sub Compress(ByRef Nfield As Short, ByRef Stringa() As String, ByRef Risult() As String, ByRef Esp() As Short, ByRef Compr() As Short)
        Dim jj, i As Short
        jj = 0
        For i = 1 To Nfield
            If (Stringa(i)) = Chr(45) Then
                Compr(i) = 0
            Else
                jj = jj + 1
                Compr(i) = jj
                Esp(jj) = i
            End If 'o
        Next i
        Nfield = jj
        For i = 1 To Nfield
            Stringa(i) = Stringa(Esp(i))
            If Len(Risult(i)) > 25 Then Risult(i) = Left(Risult(i), 25)
            Risult(i) = Risult(Esp(i))
        Next i
    End Sub
    Function DatiBocchello(ByRef k As Short) As Short
        Dim j As Short
        DatiBocchello = False
        j = DisplayBocchello(k)
        If j > 0 Then
            j = DatiNozzles(k, Nozzles(k, j).InvolucroSU, j)
            DatiBocchello = j
        End If
    End Function
    Private Function DatiCompBel(ByRef k As Short, ByRef j As Short, ByRef mode As Short) As Short
        If Involucr(k, j).Escluso Then DatiCompBel = True : Exit Function
        DatiCompBel = False
        If mode = 2 Then
            If Not DatiProgBel(k, j) Then Exit Function
            Call MWDTdata(k, j)
            '   FOR k = Involucr(j).Inizio TO Involucr(j).Fine
            '   IF NOT DatiNozzles(j, k) THEN EXIT FUNCTION
            '   NEXT
        Else
            AlberoInv(k, j, 4)
        End If
        DatiCompBel = True
    End Function
    Private Function DatiCompPar(ByRef kk As Short, ByRef j As Short, ByRef mode As Short) As Short
        If Involucr(kk, j).Escluso Then DatiCompPar = True : Exit Function
        DatiCompPar = False
        If mode = 2 Then
            If Not DatiProgPar(kk, j) Then Exit Function
            'Call MWDTdata(kk, j)
            'For k = Involucr(kk, j).Inizio To Involucr(kk, j).Fine
            'If Not DatiNozzles(kk, j, k) Then Exit Function
            'Next
        Else
            AlberoInv(kk, j, 13)
        End If
        DatiCompPar = True
    End Function

    Public Function DatiCompCon(ByRef kk As Short, ByRef j As Short, ByRef mode As Short) As Short
        Dim k As Short
        If Involucr(kk, j).Escluso Then DatiCompCon = True : Exit Function
        DatiCompCon = False
        If mode = 2 Then
            If Not DatiProgCon(kk, j) Then Exit Function
            Call MWDTdata(kk, j)
            For k = Involucr(kk, j).inizio To Involucr(kk, j).Fine
                If Not DatiNozzles(kk, j, k) Then Exit Function
            Next
        Else
            AlberoInv(kk, j, 2)
        End If
        DatiCompCon = True
    End Function

    Public Function DatiCompCyl(ByRef kk As Short, ByRef j As Short, ByRef mode As Short) As Short
        Dim k As Short
        If Involucr(kk, j).Escluso Then DatiCompCyl = True : Exit Function
        DatiCompCyl = False
        If mode = 2 Then
            If Not DatiProgCyl(kk, j) Then Exit Function
            Call MWDTdata(kk, j)
            For k = Involucr(kk, j).inizio To Involucr(kk, j).Fine
                If Not DatiNozzles(kk, j, k) Then Exit Function
            Next
        Else
            AlberoInv(kk, j, 1)
        End If
        DatiCompCyl = True
    End Function 'a
    Public Function DatiCompFla(ByRef kk As Short, ByRef j As Short, ByRef mode As Short) As Short
        Dim k, im As Short
        Dim O As wn_flan
        If Involucr(kk, j).Escluso Then DatiCompFla = True : Exit Function
        DatiCompFla = False
        If mode = 2 Then
            If Not DatiProgFla(kk, j) Then Exit Function
            Call MWDTdata(kk, j)
            If Not (Involucr(kk, j).inizio = 0 And Involucr(kk, j).Fine = 0) Then
                For k = Involucr(kk, j).inizio To Involucr(kk, j).Fine
                    If Not DatiNozzles(kk, j, k) Then Exit Function
                Next
            End If
        Else
            O = objMemb(Involucr(kk, j).IndObject)
            If Not O Is Nothing Then
                Select Case O.Mem.LOOSE
                    Case -1, 2 : im = 17
                    Case 4 : im = 15
                    Case 5 : im = 16
                    Case Else : im = 6
                End Select
            Else
                im = 6
            End If
            AlberoInv(kk, j, im)
        End If
        DatiCompFla = True
    End Function 'a
    Private Function DatiCompPT(ByRef kk As Short, ByRef j As Short, ByRef mode As Short) As Short
        If Involucr(kk, j).Escluso Then DatiCompPT = True : Exit Function
        DatiCompPT = False
        If mode = 2 Then
            If Not DatiProgPT(kk, j) Then Exit Function
            Call MWDTdata(kk, j)
            'For k = Involucr(kk, j).Inizio To Involucr(kk, j).Fine
            '  If Not DatiNozzles(kk, j, k) Then Exit Function
            'Next
        Else
            AlberoInv(kk, j, 10)
        End If
        DatiCompPT = True
    End Function 'a
    Private Function DatiCompTubi(ByRef kk As Short, ByRef j As Short, ByRef mode As Short) As Short
        'Dim k As Integer
        If Involucr(kk, j).Escluso Then DatiCompTubi = True : Exit Function
        DatiCompTubi = False
        If mode = 2 Then
            If Not DatiProgTubi(kk, j) Then Exit Function
            Call MWDTdata(kk, j)
            'For k = Involucr(kk, j).Inizio To Involucr(kk, j).Fine
            '  If Not DatiNozzles(kk, j, k) Then Exit Function
            'Next
        Else
            AlberoInv(kk, j, 11)
        End If
        DatiCompTubi = True
    End Function 'a
    Private Function DatiCompDil(ByRef kk As Short, ByRef j As Short, ByRef mode As Short) As Short
        ' Dim k As Integer
        If Involucr(kk, j).Escluso Then DatiCompDil = True : Exit Function
        DatiCompDil = False
        If mode = 2 Then
            If Not DatiDilat(kk, j) Then Exit Function
            Call MWDTdata(kk, j)
        Else
            AlberoInv(kk, j, 12)
        End If
        DatiCompDil = True
    End Function 'a

    Public Function DatiCompFon(ByRef kk As Short, ByRef j As Short, ByRef mode As Short) As Short
        Dim k As Short
        If Involucr(kk, j).Escluso Then DatiCompFon = True : Exit Function
        DatiCompFon = False
        If mode = 2 Then
            If Not DatiProgFon(kk, j) Then Exit Function
            Call MWDTdata(kk, j)
            For k = Involucr(kk, j).inizio To Involucr(kk, j).Fine
                If Not DatiNozzles(kk, j, k) Then Exit Function
            Next
        Else
            AlberoInv(kk, j, 3)
        End If
        DatiCompFon = True
    End Function 'b

    Function DatiElemento(ByRef KL As Short) As Short
        Dim n, j, kk As Short
        Dim k As String
        DatiElemento = False
        SetDiv(kLato)
        With mioApert
            If .SelNode Is Nothing Then
                Beep()
                .mnuCalcElem.Enabled = False
                .mnuDatiElem.Enabled = False
                .cmdCalc.Enabled = False
                .cmdDati.Enabled = False
                Exit Function
            End If
            k = .SelNode.Tag
        End With
        If InStr(k, "Noz") > 0 Then
            k = Right(k, Len(k) - 3)
            n = InStr(k, "_")
            kLato = GlobalRoutines.ValVir(Left(k, n - 1))
            j = GlobalRoutines.ValVir(Right(k, Len(k) - n))
            kNozzle = j
            If j > 0 Then
                DatiElemento = DatiNozzles(KL, Nozzles(KL, j).InvolucroSU, j)
                For kk = Nozzles(KL, j).inizio To Nozzles(KL, j).Fine
                    If Nozzles(KL, kk).InvolucroSU < 0 Then
                        DatiElemento = DatiNozzles(KL, Nozzles(KL, kk).InvolucroSU, kk)
                    End If
                Next
                Exit Function
            End If
        End If
        If InStr(k, "Inv") > 0 Then
            k = Right(k, Len(k) - 3)
            n = InStr(k, "_")
            kLato = GlobalRoutines.ValVir(Left(k, n - 1))
            j = GlobalRoutines.ValVir(Right(k, Len(k) - n))
            jInvolucr = j
        End If
        If j = 0 Then Exit Function
        Select Case Involucr(KL, j).Tipo
            Case 0 : If Not DatiCompCyl(KL, j, 2) Then Exit Function
            Case 1 : If Not DatiCompFon(KL, j, 2) Then Exit Function
            Case 2, 3 : If Not DatiCompCon(KL, j, 2) Then Exit Function
            Case 4 : If Not DatiCompBel(KL, j, 2) Then Exit Function
            Case 5 : If Not DatiCompFla(KL, j, 2) Then Exit Function
            Case 6 : If Not DatiCompPT(KL, j, 2) Then Exit Function
            Case 7 : If Not DatiCompTubi(KL, j, 2) Then Exit Function
            Case 8 : If Not DatiCompDil(KL, j, 2) Then Exit Function
            Case 9 : If Not DatiCompPar(KL, j, 2) Then Exit Function
        End Select
        DatiElemento = True
    End Function
    Function DatiInputC(ByRef mode As Short) As Boolean
        'Mode=1 treeview'2 input
        Dim j, k As Short
        Dim Testo As String
        DatiInputC = False
        Try
            If mode = 1 Then mioApert.TreeView1.Nodes.Clear()
            For k = 1 To Config(0).NumeroLati
                If mode = 1 And Config(0).NumeroLati > 1 Then
                    Select Case k
                        Case 1
                            Nodbase(k) = mioApert.TreeView1.Nodes.Add("LatoMant")
                            Nodbase(k).Tag = "LM"
                            Nodbase(k).ImageIndex = 7
                            Nodbase(k).SelectedImageIndex = 7
                        Case 2 : Nodbase(k) = mioApert.TreeView1.Nodes.Add("LatoTubi")
                            Nodbase(k).Tag = "LT"
                            Nodbase(k).ImageIndex = 8
                            Nodbase(k).SelectedImageIndex = 8
                        Case 3 : Nodbase(k) = mioApert.TreeView1.Nodes.Add("Fra i due")
                            Nodbase(k).Tag = "LL"
                            Nodbase(k).ImageIndex = 9
                            Nodbase(k).SelectedImageIndex = 9
                    End Select
                End If
                For j = 1 To Config(k).Ninvolucri
                    Select Case Involucr(k, j).Tipo
                        Case 0 : If Not DatiCompCyl(k, j, mode) Then Exit Function
                        Case 1 : If Not DatiCompFon(k, j, mode) Then Exit Function
                        Case 2, 3 : If Not DatiCompCon(k, j, mode) Then Exit Function
                        Case 4 : If Not DatiCompBel(k, j, mode) Then Exit Function
                        Case 5 : If Not DatiCompFla(k, j, mode) Then Exit Function
                        Case 6 : If Not DatiCompPT(k, j, mode) Then Exit Function
                        Case 7 : If Not DatiCompTubi(k, j, mode) Then Exit Function
                        Case 8 : If Not DatiCompDil(k, j, mode) Then Exit Function
                        Case 9 : If Not DatiCompPar(k, j, mode) Then Exit Function
                        Case Else
                            Testo = " Tipo di involucro non previsto. | (" & Str(Involucr(k, j).Tipo)
                            Testo = Testo & " ). File di input inutilizzabile."
                            MessageBox.Show(clsInizio.ConvertiCr(Testo))
                            Exit Function
                    End Select
                Next
            Next k
            If mode = 1 Then
                mioApert.EspCom()
                If Not mioApert.SelNode Is Nothing Then
                    Try
                        mioApert.SelNode.EnsureVisible()
                    Catch
                        Return True
                    End Try
                End If
                CheckCollegamenti()
            End If
            PulisciIndici()
        Catch e As Exception
            messagebox.show(e.Message + vbCrLf + e.StackTrace)
        End Try
        DatiInputC = True
    End Function 'd
    Private Function DatiProgBel(ByRef k As Short, ByRef j As Short) As Short
        DatiProgBel = False
        Involucr(k, j).OS = 0
        jInvolucr = j
        kLato = k
        AggDatiBel(k, j)
        With frmBel.DefInstance
            .ShowDialog()
            DatiProgBel = Not .Cancel
            .Dispose()
        End With
    End Function
    Private Function DatiProgPar(ByRef k As Short, ByRef j As Short) As Short
        DatiProgPar = False
        jInvolucr = j
        kLato = k
        With frmDatiPart.DefInstance
            .ShowDialog()
            DatiProgPar = Not .Cancel
            .Dispose()
        End With
    End Function
    Private Function DatiProgCon(ByRef k As Short, ByRef j As Short) As Short
        Dim indice As Short
        Dim Cono As New Grafica.Cono
        Dim jSav As Short
        Dim Stringa(8) As String
        Dim Risult(8) As String
        DatiProgCon = False
        If Libgra Is Nothing Then
            Libgra = New Grafica.LibGra
            Libgra.DoveMotore = Monitor.Motore
            Libgra.DoveRoutines = Routines
        End If
        jSav = jInvolucr
        Involucr(k, j).ms = 0
        If Not Apparecchio Is Nothing Then Cono = CType(Apparecchio.Elementi(Involucr(k, j).Mark), Grafica.Cono)
        If Cono Is Nothing Then Cono = New Grafica.Cono
        If Cono.Dgran = 0 Then Cono.Dgran = Config(k).di
        With Involucr(k, j)
            indice = .indice(1 - 1)
            Cono.GenMem.Denom = .Mark
            If .Tipo = 2 Then
                Cono.GenMem.Tipo = 7
            Else
                Cono.GenMem.Tipo = 6
            End If
            Matdim(indice).MatStr = RTrim(.MATE)
            Cono.SpessRive = .OS
            Cono.SpessBase = .Spess - Cono.SpessRive
            Cono.Dgran = .di
            Cono.Dpicc = .dns
            Cono.RagG = .H0
            Cono.RagP = .L0
            Cono.AlfaCon = .R0
            Cono.Dati()
            '080706  .RecInd(1 - 1) = Matdim(indice).Indmat
            .Mark = Cono.GenMem.Denom
            .MATE = Matdim(indice).MatStr
            .Spess = Cono.SpessBase + Cono.SpessRive
            .OS = Cono.SpessRive
            .di = Cono.Dgran
            .dns = Cono.Dpicc
            .H0 = Cono.RagG
            .L0 = Cono.RagP
            .R0 = Cono.AlfaCon
            .Dati1 = Cono.Altezza
        End With
        jInvolucr = j
        kLato = k
        Dim f As New frmCon
        f.AggDatiCon(k, j)
        f.ShowDialog()
        f.Dispose()
        Cono = Nothing
        DatiDoub(k, j)
        CheckCon(k, j)
        DatiProgCon = True
        jInvolucr = jSav
    End Function
    Public Function DatiDilat(ByVal k As Short, ByVal j As Short) As Short
        Dim jj, indice, jk As Short
        Dim Vecchio As Boolean
        Dim Stringa(8) As String
        Dim Risult(8) As String
        DatiDilat = False
        If Libgra Is Nothing Then
            Libgra = New Grafica.LibGra
            Libgra.DoveMotore = Monitor.Motore
            Libgra.DoveRoutines = Routines
        End If
        If Not Apparecchio Is Nothing Then Dilatatore = CType(Apparecchio.Elementi(Involucr(k, j).Mark), Grafica.Dilat)
        If Dilatatore Is Nothing Then Dilatatore = New Grafica.Dilat
        jInvolucr = j
        kLato = k
        With Involucr(k, j)
            indice = .indice(1 - 1)
            GenRecDilN(Dilatatore, k, j)
Rif:
            frmDil.DefInstance.ShowDialog()
            If frmDil.DefInstance.Cancel Then GoTo ExDil
            If AddDistinta > 0 Or Dilatatore.DIMAX > 0 Then Vecchio = True
            If Dilatatore.DIMIN = 0 Then Dilatatore.DIMIN = Config(k).di
            Dilatatore.Norma = .Norma
            Dilatatore.SottoTipo = .SottoTipo
            Dilatatore.GenMem.Denom = .Mark
            If .Norma = 2 Then
                Select Case .SottoTipo
                    Case 3 : jk = 2
                    Case 4 : jk = 3
                    Case 4 : jk = 4
                End Select
                For jj = 2 To jk
                    If .indice(jj - 1) < 0 Then
                        .indice(jj - 1) = NuovoIndice()
                        indici.Add(.indice(jj - 1))
                    End If
                    If Matdim(.indice(jj - 1)) Is Nothing Then Matdim(.indice(jj - 1)) = New LibMat.MaterialeNew1
                    Select Case jj
                        Case 2 : Dilatatore.MatColl = Matdim(.indice(jj - 1))
                        Case 3 : Dilatatore.MatAnel = Matdim(.indice(jj - 1))
                        Case 4 : Dilatatore.MatBull = Matdim(.indice(jj - 1))
                    End Select
                Next
            Else
                For jj = 2 To 4
                    If .indice(jj - 1) > 0 Then
                        Matdim(.indice(jj - 1)) = Nothing
                        .indice(jj - 1) = -1
                    End If
                Next
            End If
            Dilatatore.Dati() ' clsInizio.DiscoRam
            If Not Libgra.OKfrmDati Then GoTo Rif
            '080706  .RecInd(1 - 1) = Matdim(indice).Indmat
            .Mark = Dilatatore.GenMem.Denom 'Record(indice).Denom
            .MATE = Matdim(indice).MatStr
            .Spess = Dilatatore.Spess ' Look.t '
            .di = Dilatatore.DIMIN '
            .dns = Dilatatore.DIMAX '
            .R0 = Dilatatore.Raggio
            .L0 = Dilatatore.Lunghezza
            .H0 = Dilatatore.Colletto
            .ms = Dilatatore.nOnde
            .xs = Dilatatore.nPli
            .TubeAdopt = Dilatatore.LungCol 'Look.AlungC
            .TubeMinT = Dilatatore.LunTira
            .SottoTipo = Dilatatore.SottoTipo ' Look.TipoV
            .Dati1 = Dilatatore.SpesCol ' Look.SpessC
            .Dati2 = Dilatatore.SezRinf ' Look.SezRinf
            .Dati3 = Dilatatore.SezTira
            '.Norma = Dilatatore.Norma
            '080706  .RecInd(2 - 1) = Dilatatore.MatColl.Indmat
            '080706  .RecInd(3 - 1) = Dilatatore.MatAnel.Indmat
            '080706  .RecInd(4 - 1) = Dilatatore.MatBull.Indmat
        End With
        DatiDilat = True
        GenRecDilN(Dilatatore, k, j)
        TrasfDilat() 'Look
ExDil:
        frmDil.DefInstance.Dispose()
    End Function
    Private Sub GenRecDilN(ByRef Dilat As Grafica.Dilat, ByRef k As Short, ByRef j As Short)
        With Involucr(k, j)
            Dilat.GenMem.Denom = .Mark
            Dilat.GenMem.Tipo = 18
            Dilat.DIMAX = .dns
            Dilat.DIMIN = .di
            Dilat.Spess = .Spess
            Dilat.Raggio = .R0
            Dilat.Lunghezza = .L0
            Dilat.Colletto = .H0
            Dilat.nOnde = .ms
            Dilat.LungCol = .TubeAdopt
            Dilat.LunTira = .TubeMinT
            Dilat.nPli = .xs
            Dilat.SottoTipo = .SottoTipo
            Dilat.SpesCol = .Dati1
            Dilat.SezRinf = .Dati2
            Dilat.SezTira = .Dati3
        End With
    End Sub
    Sub Design(ByRef junk As DialogResult, ByVal sonda As Boolean)
        Lancio.Legacy.Serialization.LegacyBinarySerializer.EnsureEnabled()
        Dim Confi1 As asConfig
        Dim Testo As String
        Dim Dimen, j, i, ii, ifl As Short
        Dim NumLati, Nnozz, k As Short
        Dim bf As New Lancio.Legacy.Serialization.LegacyBinarySerializer
        Dim fs As FileStream = Nothing
        indici = New LinkListSh
        indiciAttivi = New LinkListSh
        Confi1.Initialize()
        nuovoINP = True
        Try
            junk = DialogResult.Yes
            If AddDistinta > 0 Then
                Testo = " Vuoi caricare i dati registra-|"
                Testo = Testo & "ti nel corso dei calcoli prece-|"
                Testo = Testo & "denti? (" & icome & ")"
                Testo = clsInizio.ConvertiCr(Testo)
                junk = MessageBox.Show(Testo, "AsmeVip", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If junk = DialogResult.No Then Exit Sub
            End If
            If nuovoINP Then
                fs = New FileStream(icome, FileMode.OpenOrCreate)
                Try
                    Confi1 = CType(bf.Deserialize(fs), asConfig)
                Catch ex1 As SerializationException
                    '  MsgBox(ex1.Message)
                    nuovoINP = False
                End Try
                If Not nuovoINP Then
                    fs.Close()
                    ifl = FreeFile()
                    FileOpen(ifl, icome, OpenMode.Binary)
                    FileGet(ifl, Confi1)
                    If Confi1.Versione < 17 Then
                        MostraAiuto(2100)
                        FileClose(ifl)
                        junk = DialogResult.No
                        Exit Sub
                    End If
                End If
            Else
            End If
            If Confi1.Ninvolucri <> Config(0).Ninvolucri And AddDistinta > 0 Then
                Testo = " Il caricamento dei dati registra- |"
                Testo = Testo & "ti nel corso dei calcoli preceden-|"
                Testo = Testo & "ti non è andato a buon fine "
                MessageBox.Show(clsInizio.ConvertiCr(Testo))
                junk = DialogResult.No
                If nuovoINP Then fs.Close() Else FileClose(ifl)
                Exit Sub
            Else
                Config(0) = Confi1
            End If
            If sonda Then
                job.Comm.Item = Config(0).Item
                If nuovoINP Then
                    job = CType(bf.Deserialize(fs), clsjob)
                    job.Motore = Monitor.Motore
                End If
                GoTo ExDes
            Else
                If nuovoINP Then Dim jobdummy As clsjob = CType(bf.Deserialize(fs), clsjob)
            End If
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
219:        Dimen = UBound(Involucr, 2)
            If Config(0).Ninvolucri > Dimen Then Ridimensiona(Config(0).Ninvolucri + 2)
            NumLati = Config(0).NumeroLati + 1
            For k = 1 To NumLati
                mioApert.mnuComment.Checked = Config(0).Verbose = -1
                If nuovoINP Then
                    Config(k) = CType(bf.Deserialize(fs), asConfig)
                Else
                    FileGet(ifl, Config(k))
                End If
                If Config(k).Ninvolucri < 0 Then Config(k).Ninvolucri = 0
                Ridimensiona(Config(k).Ninvolucri)
                For i = 1 To Config(k).Ninvolucri
                    With Involucr(k, i)
                        If nuovoINP Then
                            Involucr(k, i) = CType(bf.Deserialize(fs), Involucro)
                        Else
                            FileGet(ifl, Involucr(k, i))
                        End If
                        kLato = k : jInvolucr = i
                        Select Case .Tipo
                            'Case 1
                        Case 2, 3
                                If nuovoINP Then
                                    If Config(0).Versione < 23 Then
                                        Dim A As AdditCon
                                        A.Initialize()
                                        A = CType(bf.Deserialize(fs), AdditCon)
                                        AdditConAggiorna(AdditCono(k, i), A)
                                    Else
                                        AdditCono(k, i) = CType(bf.Deserialize(fs), AdditConN)
                                    End If
                                Else
                                    Dim A As AdditCon
                                    A.Initialize()
                                    FileGet(ifl, A)
                                    AdditConAggiorna(AdditCono(k, i), A)
                                End If
                                Indice1(k, i)
                            Case 5
                                .IndObject = NuovoIndObj()
                                objMemb(.IndObject) = New wn_flan
                                If nuovoINP Then
                                    If Not CType(objMemb(.IndObject), wn_flan).Leggi(fs) Then GoTo ExDes
                                Else
                                    If Not CType(objMemb(.IndObject), wn_flan).Leggi(ifl) Then GoTo ExDes
                                End If
                                CType(objMemb(.IndObject), wn_flan).LatoProgetto = 3 - k
                                Indice1(k, i)
                            Case 6
                                .IndObject = NuovoIndObj()
                                If nuovoINP Then
                                    TipoPT = CType(bf.Deserialize(fs), Short)
                                Else
                                    FileGet(ifl, TipoPT)
                                End If
                                objMemb(.IndObject) = New wn_PT
                                CType(objMemb(.IndObject), wn_PT).TipoPT = TipoPT
                                Select Case TipoPT
                                    Case 1
                                        CType(objMemb(.IndObject), wn_PT).Piastra = New wn_UTEMA
                                    Case 2
                                        CType(objMemb(.IndObject), wn_PT).Piastra = New wn_FTC
                                        CType(CType(objMemb(.IndObject), wn_PT).Piastra, wn_FTC).SoloDilat = False
                                    Case Else
                                        MessageBox.Show("Valore di TipoPT non previsto in Design (" & Format(TipoPT) & ")")
                                        Exit Sub
                                End Select
                                CType(objMemb(.IndObject), wn_PT).TipoPT = TipoPT
                                For ii = 1 To 4
                                    CType(objMemb(.IndObject), wn_PT).IndAccopp(ii) = .IndAccopp(ii)
                                Next
                                CType(objMemb(.IndObject), wn_PT).SetPiastra(2)
                                For ii = 1 To 4
                                    CType(objMemb(.IndObject), wn_PT).IndAccopp(ii) = .IndAccopp2(ii)
                                Next
                                CType(objMemb(.IndObject), wn_PT).SetPiastra(1)
                                kLato = k : jInvolucr = i
                                If nuovoINP Then
                                    If Not CType(objMemb(.IndObject), wn_PT).Leggi(fs) Then GoTo ExDes
                                Else
                                    If Not CType(objMemb(.IndObject), wn_PT).Leggi(ifl) Then GoTo ExDes
                                End If
                                If TipoPT = 2 Then
                                    If CType(CType(objMemb(.IndObject), wn_PT).Piastra, wn_FTC).IndiceDilat > -1 Then
                                        If Involucr(1, CType(CType(objMemb(.IndObject), wn_PT).Piastra, wn_FTC).IndiceDilat).Tipo = 8 Then
                                            objMemb(Involucr(1, CType(CType(objMemb(.IndObject), wn_PT).Piastra, wn_FTC).IndiceDilat).IndObject) = objMemb(.IndObject)
                                        End If
                                    End If
                                End If
                                Indice1(k, i)
                            Case 7 'tubi
                                .IndObject = NuovoIndObj() 'NuovoIndProbl
                                objMemb(.IndObject) = New wn_Tub
                                Indice1(k, i)
                            Case 8 'dilatatore
                                .IndObject = NuovoIndObj()
                                If nuovoINP Then
                                    TipoPT = CType(bf.Deserialize(fs), Short)
                                Else
                                    FileGet(ifl, TipoPT)
                                End If
                                objMemb(.IndObject) = New wn_PT
                                CType(objMemb(.IndObject), wn_PT).TipoPT = 2
                                CType(objMemb(.IndObject), wn_PT).Piastra = New wn_FTC
                                CType(CType(objMemb(.IndObject), wn_PT).Piastra, wn_FTC).SoloDilat = True
                                kLato = k : jInvolucr = i
                                If nuovoINP Then
                                    If Not CType(objMemb(.IndObject), wn_PT).Leggi(fs) Then GoTo ExDes
                                Else
                                    If Not CType(objMemb(.IndObject), wn_PT).Leggi(ifl) Then GoTo ExDes
                                End If
                                Indice1(k, i)
                                Dilatatore = New Grafica.Dilat
                                GenRecDilN(Dilatatore, k, i)
                            Case 9 'pass partition
                                .IndObject = NuovoIndObj()
                                objMemb(.IndObject) = New wn_Part
                                If nuovoINP Then
                                    If Not CType(objMemb(.IndObject), wn_Part).Leggi(fs) Then GoTo ExDes
                                Else
                                    If Not CType(objMemb(.IndObject), wn_Part).Leggi(ifl) Then GoTo ExDes
                                End If
                                Indice1(k, i)
                            Case Else
                                Indice1(k, i)
                        End Select
                        If .Tipo = 5 Then
                            If .indice(2 - 1) <= 0 Then
                                .indice(2 - 1) = NuovoIndice()
                                .indice(3 - 1) = -1
                            End If
                            indici.Add(.indice(2 - 1))
                        End If
                        If .Tipo = 8 And .Norma = 1 Then
                            If .indice(5 - 1) <= 0 Then
                                .indice(5 - 1) = NuovoIndice()
                            End If
                            indici.Add(.indice(5 - 1))
                        End If
                        If .Tipo = 8 And .Norma = 2 Then
                            If .indice(2 - 1) <= 0 Then
                                .indice(2 - 1) = NuovoIndice()
                            End If
                            indici.Add(.indice(2 - 1))
                        End If
                        If .Tipo = 8 And .Norma = 2 And .SottoTipo > 3 Then
                            If .indice(3 - 1) <= 0 Then
                                .indice(3 - 1) = NuovoIndice()
                            End If
                            indici.Add(.indice(3 - 1))
                        End If
                        If .Tipo = 8 And .Norma = 2 And .SottoTipo = 5 Then
                            If .indice(4 - 1) <= 0 Then
                                .indice(4 - 1) = NuovoIndice()
                                .indice(5 - 1) = -1
                            End If
                            indici.Add(.indice(4 - 1))
                        End If
                        If Not nuovoINP Then
                            For j = 1 To 8
                                If .indice(j - 1) > -1 Then
                                    Dimen = UBound(Matdim)
                                    If .indice(j - 1) > Dimen Then
                                        ReDim Preserve Matdim(2 * .indice(j - 1))
                                    End If
                                    If Matdim(.indice(j - 1)) Is Nothing Then
                                        Matdim(.indice(j - 1)) = New LibMat.MaterialeNew1
                                    End If
                                    If Not nuovoINP Then
                                        If .RecInd(j - 1) > 0 Then
                                            If .indice(j - 1) < 1 And j > 1 Then
                                                .indice(j - 1) = NuovoIndice()
                                            End If
                                            If j > 1 Then indici.Add(.indice(j - 1))
                                            Matdim(.indice(j - 1)).Indmat = .RecInd(j - 1)
                                            Matdim(.indice(j - 1)).RecupMat(clsInizio.Archdir)
                                            .RecInd(j - 1) = Matdim(.indice(j - 1)).Indmat
                                        End If
                                    End If
                                End If
                            Next
                        End If
                    End With
ContNext:
                Next
                Nnozz = NumBocch(k)
                j = 1
                CheckDimNoz(Nnozz)
Finisci:
                For i = j To Nnozz
                    If nuovoINP Then
                        If Config(0).Versione < 22 Then
                            Dim NN As Nozzle
                            NN.Initialize()
                            NN = CType(bf.Deserialize(fs), Nozzle)
                            NozzleAggiorna(Nozzles(k, i), NN)
                        Else
                            Nozzles(k, i) = CType(bf.Deserialize(fs), NozzleN)
                        End If
                    Else
                        Dim NN As Nozzle
                        NN.Initialize()
                        FileGet(ifl, NN)
                        NozzleAggiorna(Nozzles(k, i), NN)
                    End If
                    If Nozzles(k, i).IndObject > 0 Then
                        Nozzles(k, i).IndObject = NuovoIndObj()
                        objMemb(Nozzles(k, i).IndObject) = New wn_flan
                        If nuovoINP Then
                            If Not CType(objMemb(Nozzles(k, i).IndObject), wn_flan).Leggi(fs) Then GoTo ExDes
                        Else
                            If Not CType(objMemb(Nozzles(k, i).IndObject), wn_flan).Leggi(ifl) Then GoTo ExDes
                        End If
                        CType(objMemb(Nozzles(k, i).IndObject), wn_flan).LatoProgetto = 3 - k
                    End If
                    If Nozzles(k, i).SWR > 9 Then
                        If nuovoINP Then
                            If Config(0).Versione < 21 Then
                                Dim Nozzaddv As NozzAd
                                Nozzaddv.Initialize()
                                Nozzaddv = CType(bf.Deserialize(fs), NozzAd)
                                NozzAddAggiorna(NozzAdd(k, i), Nozzaddv)
                            Else
                                NozzAdd(k, i) = CType(bf.Deserialize(fs), NozzAdN)
                            End If
                        Else
                            Dim Nozzaddv As NozzAd
                            Nozzaddv.Initialize()
                            FileGet(ifl, NozzAddv)
                            NozzAddAggiorna(NozzAdd(k, i), Nozzaddv)
                        End If
                    End If
                Next
                If Not nuovoINP Then
                    j = NumBocch2(k)
                    If j > 0 And Nnozz = NumBocch(k) Then
                        Nnozz = j + Nnozz
                        j = NumBocch(k) + 1
                        GoTo Finisci
                    End If
                    For i = 1 To NumBocch(k) + NumBocch2(k)
                        If Nozzles(k, i).indice < 0 Then
                            Nozzles(k, i).indice = NuovoIndice()
                        End If
                        indici.Add(Nozzles(k, i).indice)
                        Dimen = UBound(Matdim)
                        If Nozzles(k, i).indice > Dimen Then
                            ReDim Preserve Matdim(2 * Nozzles(k, i).indice)
                        End If
                        If Matdim(Nozzles(k, i).indice) Is Nothing Then Matdim(Nozzles(k, i).indice) = New LibMat.MaterialeNew1
                        If Nozzles(k, i).RecInd > 0 Then
                            Matdim(Nozzles(k, i).indice).Indmat = Nozzles(k, i).RecInd
                            Matdim(Nozzles(k, i).indice).RecupMat(clsInizio.Archdir)
                            Nozzles(k, i).RecInd = Matdim(Nozzles(k, i).indice).Indmat
                        End If
                        If Nozzles(k, i).IndiceP < 0 Then
                            Nozzles(k, i).IndiceP = NuovoIndice()
                        End If
                        indici.Add(Nozzles(k, i).IndiceP)
                        If Nozzles(k, i).IndiceP > Dimen Then
                            ReDim Preserve Matdim(2 * Nozzles(k, i).IndiceP)
                        End If
                        If Matdim(Nozzles(k, i).IndiceP) Is Nothing Then Matdim(Nozzles(k, i).IndiceP) = New LibMat.MaterialeNew1
                        If Nozzles(k, i).RecIndP > 0 Then
                            Matdim(Nozzles(k, i).IndiceP).Indmat = Nozzles(k, i).RecIndP
                            Matdim(Nozzles(k, i).IndiceP).RecupMat(clsInizio.Archdir)
                            Nozzles(k, i).RecIndP = Matdim(Nozzles(k, i).IndiceP).Indmat
                        End If
                        If Nozzles(k, i).IndiceB > 0 Then
                            Nozzles(k, i).IndiceB = NuovoIndice()
                            indici.Add(Nozzles(k, i).IndiceB)
                            Matdim(Nozzles(k, i).IndiceB) = New LibMat.MaterialeNew1
                            If Nozzles(k, i).RecIndB > 0 Then
                                If Matdim(Nozzles(k, i).IndiceB).Indmat = 0 And Matdim(Nozzles(k, i).IndiceB).Agganciato Then
                                    Matdim(Nozzles(k, i).IndiceB).Indmat = Nozzles(k, i).RecIndB
                                End If
                                Matdim(Nozzles(k, i).IndiceB).RecupMat(clsInizio.Archdir)
                                If Matdim(Nozzles(k, i).IndiceB).MatStr = "?" Then
                                    Testo = "L'errore appena riportato riguarda il materiale" & vbCrLf
                                    Testo = Testo & "dei tiranti della flangia del bocchello " & Trim(Nozzles(k, i).Mark) & vbCrLf
                                    Testo = Testo & "Tale materiale può essere specificato in caso" & vbCrLf
                                    Testo = Testo & "di calcolo secondo App.2 di flangia non std." & vbCrLf
                                    Testo = Testo & "Volete annullare la specifica di questo materiale? "
                                    If MessageBox.Show(Testo, "AsmeVip", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then Nozzles(k, i).IndiceB = 0
                                End If
                            End If
                        End If
                        If Nozzles(k, i).IndexF < 1 Then
                            Nozzles(k, i).IndexF = NuovoIndice()
                        End If
                        indici.Add(Nozzles(k, i).IndexF)
                        If Nozzles(k, i).IndexF > Dimen Then
                            ReDim Preserve Matdim(2 * Nozzles(k, i).IndexF)
                        End If
                        If Matdim(Nozzles(k, i).IndexF) Is Nothing Then Matdim(Nozzles(k, i).IndexF) = New LibMat.MaterialeNew1
                        If Nozzles(k, i).RecIndF > 0 Then
                            Matdim(Nozzles(k, i).IndexF).Indmat = Nozzles(k, i).RecIndF
                            Matdim(Nozzles(k, i).IndexF).RecupMat(clsInizio.Archdir)
                            Nozzles(k, i).RecIndF = Matdim(Nozzles(k, i).IndexF).Indmat
                        End If
                    Next i
                End If
            Next k
            If nuovoINP Then
                Dim indice As Short ', indici1 As LinkListSh
                indici = CType(bf.Deserialize(fs), LinkListSh)
                For i = 1 To indici.Count
                    indice = indici(i).TextData
                    Dimen = UBound(Matdim)
                    If indice > Dimen Then ReDim Preserve Matdim(2 * Dimen)
                    If Config(0).Versione < 24 Then
                        Dim OldMat As New LibMat.Materiale
                        OldMat = CType(bf.Deserialize(fs), LibMat.Materiale)
                        Matdim(indice) = OldMat.Converti
                    ElseIf Config(0).Versione = 24 Then
                        Dim OldMat As New LibMat.MaterialeNew
                        OldMat = CType(bf.Deserialize(fs), LibMat.MaterialeNew)
                        Matdim(indice) = OldMat.Converti
                    Else
                        Matdim(indice) = CType(bf.Deserialize(fs), LibMat.MaterialeNew1)
                    End If
                    If Config(0).Versione < 20 Then
                        Matdim(indice).AlfaYoung = New LibMat.clsAlfaYoung
                    Else
                        Matdim(indice).AlfaYoung = CType(bf.Deserialize(fs), LibMat.clsAlfaYoung)
                    End If
                Next
            End If
        Catch e As SerializationException
            fs.Close()
            If MostraAiuto(IDH_ERR_BADSERIAL, _
            ChiaviMess.MessQuestion Or ChiaviMess.MessYesNo, _
            GlobalRoutines.FormatS(Helpstringa(IDH_ERR_BADSERIAL), icome, e.Message)) _
            = ChiaviMess.MessSi Then
                Kill(icome)
                icome = ""
                Monitor.Motore.Problem.OrdineFile -= 1
            End If
            junk = DialogResult.No
        Catch e As Exception
            MessageBox.Show(e.Message + vbCrLf + e.StackTrace)
            junk = DialogResult.No
        End Try
        Environment.CurrentDirectory = Monitor.Motore.Inizio.Basedir & "\Dll"
ExDes:
        If nuovoINP Then fs.Close() Else FileClose(ifl)
        If Not sonda Then
            If Config(0).SistCoorCop <> SistCoorCop Then
                Config(0).SistCoorCop = SistCoorCop
                ConvertiCop()
            End If
            If System.Math.Abs(Config(1).DC - 7) < 2 Or System.Math.Abs(Config(2).DC - 7) < 2 Then
                mioApert.Check1.CheckState = CheckState.Checked
                mioApert.Check1.Enabled = False
            End If
        End If
        Cursor.Current = Cursors.Default
    End Sub
    Private Sub additconAggiorna(ByVal A As AdditConN, ByVal AA As AdditCon)
        Dim i, k As Short
        For i = 0 To 4
            A.indice(i) = AA.indice(i) 'prog NO ivo nei Record() (dimensionato per il
        Next
        A.Tipo = AA.Tipo '0 cilindro 1 fondo 2 cono 3 conoide
        A.MATE1 = AA.MATE1
        A.MATE2 = AA.MATE2
        For i = 0 To 1
            A.matind(i) = AA.matind(i)
            A.Spess(i) = AA.Spess(i)
            A.E(i) = AA.E(i)
            A.S0(i) = AA.S0(i)
            A.St(i) = AA.St(i)
            A.eff(i) = AA.eff(i)
            A.delta(i) = AA.delta(i)
            A.PSE(i) = AA.PSE(i)
            For k = 0 To 1
                A.f(i, k) = AA.f(i, k)
                A.l(i, k) = AA.l(i, k)
                A.Sploc(i, k) = AA.Sploc(i, k)
            Next
            A.AeL(i) = AA.AeL(i)
            A.ArL(i) = AA.ArL(i)
            A.k(i) = AA.k(i)
            A.Necess(i) = AA.Necess(i)
            A.Rinf(i) = AA.Rinf(i)
            A.Shydr(i) = AA.Shydr(i)
            A.E1(i) = AA.E1(i)
            A.EM(i) = AA.EM(i)
        Next
        For i = 0 To 3
            A.Contr(i) = AA.Contr(i)
        Next
    End Sub
    Private Sub NozzAddAggiorna(ByVal N As NozzAdN, ByVal NN As NozzAd)
        N.Gola41 = NN.Gola41
        N.Gola42 = NN.Gola42
        N.Gola43 = NN.Gola43
        N.GrooShe = NN.GrooShe
        N.GrooTen = NN.GrooTen
        N.TipAbutt = NN.TipAbutt
        N.Protusion = NN.Protusion
        N.UW16 = NN.UW16

    End Sub
    Private Sub NozzleAggiorna(ByRef N As NozzleN, ByRef NN As Nozzle)
        Dim ij As Short
        N.indice = NN.indice
        N.InvolucroSU = NN.InvolucroSU
        N.RecInd = NN.RecInd
        N.Mark = NN.Mark
        N.Tipo = NN.Tipo
        N.MATE = NN.MATE
        N.Rati = NN.Rati
        N.DiaN = NN.DiaN
        N.DiOn = NN.DiOn
        N.DiIn = NN.DiIn
        N.Spess = NN.Spess
        N.EffN = NN.EffN
        N.ONn = NN.ONn
        N.CorrA = NN.CorrA
        N.AllN = NN.AllN
        N.DCL = NN.DCL
        N.DTL = NN.DTL
        N.beta = NN.beta
        N.Xacc = NN.Xacc
        N.MUN = NN.MUN
        N.LX = NN.LX
        N.HX = NN.HX
        N.LSDisp = NN.LSDisp
        N.Padd = NN.Padd
        N.PadT = NN.PadT
        N.SWR = NN.SWR
        N.MNT = NN.MNT
        For ij = 0 To 3
            N.MAWP(ij) = NN.MAWP(ij)
        Next
        N.inizio = NN.inizio
        N.Fine = NN.Fine
        N.Alfa = NN.Alfa
        N.LXdisp = NN.LXdisp
        N.AllPad = NN.AllPad
        N.indiceF = NN.indiceF
        N.RecIndF = NN.RecIndF
        N.IndexF = NN.IndexF
        N.Risult = NN.Risult
        N.TransitionAngle = NN.TransitionAngle
        N.R2 = NN.R2
        N.IndiceP = NN.IndiceP
        N.RecIndP = NN.RecIndP
        N.Anomal = NN.Anomal
        N.ShThkNozArea = NN.ShThkNozArea
        N.DiamExt = NN.DiamExt
        N.Altezza = NN.Altezza
        N.Spessore = NN.Spessore
        N.IndObject = NN.IndObject
        N.IndiceB = NN.IndiceB
        N.RecIndB = NN.RecIndB
        N.R1 = NN.R1
        N.Tdes = NN.Tdes
        N.Pdes = NN.Pdes
        N.alfaShell = NN.alfaShell
        N.alfaNoz = NN.alfaNoz
        N.alfaPad = NN.alfaPad
        N.dtAD550f = NN.dtAD550f
        N.FlanNonStd = NN.FlanNonStd
        N.AllNPI = NN.AllNPI
        N.AllPadPI = NN.AllPadPI
        N.BNoRinf = NN.BNoRinf
        N.FactVicini = NN.FactVicini
    End Sub
    Private Sub Indice1(ByVal k As Short, ByVal i As Short)
        With Involucr(k, i)
            If .indice(1 - 1) <= 0 Then
                .indice(1 - 1) = NuovoIndice()
                .indice(2 - 1) = -1
            End If
            indici.Add(.indice(1 - 1))
        End With
    End Sub
    Sub Diametri(ByRef KL As Short, ByRef k As Short, ByRef mode As Short)
        Dim n, ii, iTipoV As Short
        Dim iTipo As Short
        ii = DiamNom(KL, k, mode)
        'If Nozzles(KL, k).MNT = 0 Then Nozzles(KL, k).MNT = 12.5
12980:  MNT = MMM(3, ii) - Nozzles(KL, k).MNT / 100 * MMM(3, ii)
        If Left(Nozzles(KL, k).Tipo, 1) = "L" Then GoTo 13100
        '     IF Nozzles(   k).DiIn > 0 THEN GOTO 13320
        If Nozzles(KL, k).DiOn = 0 Or mode = 0 Then Nozzles(KL, k).DiOn = MMM(2, ii)
        If Nozzles(KL, k).SWR < 10 Then Nozzles(KL, k).SWR = 11 'tronchetto saldato
        GoTo FinDia
13100:  If Nozzles(KL, k).DiaN = 0 Then Exit Sub
        For ii = 1 To 34
            If Nozzles(KL, k).DiaN = NNN(1, ii) Then GoTo 13140
        Next ii
        If mode = 0 Then Call Erro(1)
        'Nozzles(k).DiIn = 0
        'Nozzles(k).DiOn = 0
        GoTo FinDia
13140:  n = Matdim(Nozzles(KL, k).indice).NRat(Nozzles(KL, k).Rati)
13220:  If Nozzles(KL, k).DiIn = 0 Or mode = 0 Then Nozzles(KL, k).DiIn = NNN(2, ii)
13270:  If Nozzles(KL, k).DiOn = 0 Or mode = 0 Then Nozzles(KL, k).DiOn = NNN(n, ii)
13320:  If Nozzles(KL, k).SWR < 10 Then Nozzles(KL, k).SWR = 10 'LWN
FinDia:
        Dim Stringa3(2) As String
        If mode = 0 Then
            Stringa3(1) = "su diametro interno"
            Stringa3(2) = "su diametro esterno"
            iTipoV = (Nozzles(KL, k).SWR Mod 10) + 1
            iTipo = 1
            'iTipo = Monitor.Motore.Quale(2, "Calcolo sp. minimo", Stringa3$(), "", iTipoV)
            Nozzles(KL, k).SWR = 9 + iTipo
        End If
    End Sub
    Function DiamNom(ByRef KL As Short, ByRef k As Short, ByRef mode As Short) As Short
        Dim ii As Short
        For ii = 1 To 30
            If Nozzles(KL, k).DiaN = MMM(1, ii) Then
                DiamNom = ii : Exit Function
            End If
        Next ii
        If mode = 1 Then Exit Function
        Call Erro(3)
    End Function 'h

    Function DisplayBocchello(ByRef k As Short) As Short
        Dim j, Nnozz, i As Short
        Dim Testo As String
        Dim Stringa1(6) As String
        Dim Stringa(20) As String
        Nnozz = NumBocch(k) + NumBocch2(k)
        If Nnozz = 0 Then
            Testo = " Questo lavoro non prevede bocchelli"
            MessageBox.Show(clsInizio.ConvertiCr(Testo))
            DisplayBocchello = 0
            Exit Function
        End If
        Call AcqNomi(Stringa1, 0)
        For i = 1 To Nnozz
            If Nozzles(k, i).InvolucroSU > -1 Then
                Stringa(i) = GlobalRoutines.Adjust(Nozzles(k, i).Mark, 15) & "| " & GlobalRoutines.Adjust(Involucr(k, Nozzles(k, i).InvolucroSU).Mark, 10)
            Else
                Stringa(i) = GlobalRoutines.Adjust(Nozzles(k, i).Mark, 15) & "| " & GlobalRoutines.Adjust(Nozzles(k, -Nozzles(k, i).InvolucroSU).Mark, 10)
            End If
        Next
        'j = Quale(Nnozz, "Bocchelli", Stringa(), "", 1)
        DisplayBocchello = j
    End Function

    Function DisplayElemento(ByRef k As Short, ByRef Logic As Short) As Short
        Dim i As Short
        Dim Stringa1(6) As String
        Dim Stringa(20) As String
        Dim j As Short
        Call AcqNomi(Stringa1, 0)
        For i = 1 To Config(k).Ninvolucri
            If Involucr(k, i).Tipo < 0 Or Involucr(k, i).Tipo > 4 Then Involucr(k, i).Tipo = 0
            Stringa(i) = "El.nø" & i.ToString & ", tipo:" & Stringa1(Involucr(k, i).Tipo + 1) & ":" & GlobalRoutines.Adjust(Involucr(k, i).Mark, 20)
        Next
        'j = Quale(Config.Ninvolucri, "Involucri", Stringa(), "", 1)
        If j = 0 Then DisplayElemento = j : Exit Function
        If Logic Then
            '   i = Quale(5, "Tipo di elemento", Stringa1$(), "", Involucr(j).Tipo + 1)
            If i > 0 Then Involucr(k, j).Tipo = i - 1
        End If
        DisplayElemento = j
    End Function

    Function EscludiBocchelli(ByRef k As Short) As Short
        Dim Nnozz, i As Short
        Dim Stringa1(6) As String
        Dim Stringa(20) As String
        EscludiBocchelli = True
        If Involucr(k, Config(k).Ninvolucri).Fine < 1 Then Exit Function
        Call AcqNomi(Stringa1, 0)
        Nnozz = NumBocch(k) + NumBocch2(k)
        Dim Scelta(Nnozz) As Short
        For i = 1 To Nnozz
            If Nozzles(k, i).InvolucroSU > -1 Then
                Stringa(i) = GlobalRoutines.Adjust(Nozzles(k, i).Mark, 15) & "| " & GlobalRoutines.Adjust(Involucr(k, Nozzles(k, i).InvolucroSU).Mark, 10)
            Else
                Stringa(i) = GlobalRoutines.Adjust(Nozzles(k, i).Mark, 15) & "| " & GlobalRoutines.Adjust(Nozzles(k, -Nozzles(k, i).InvolucroSU).Mark, 10)
            End If
            Scelta(i) = -CShort(Left(Nozzles(k, i).Mark, 1) = "-")
        Next
        'If mySwitchBox(WindowNext, 1, 1, Stringa(), Scelta(), Nnozz, 0, "Esclusione bocchelli", True) = 0 Then EscludiBocchelli = False: Exit Function
        For i = 1 To Nnozz
            If Scelta(i) Then
                If Not Left(Nozzles(k, i).Mark, 1) = "-" Then Nozzles(k, i).Mark = "-" & RTrim(Nozzles(k, i).Mark)
            Else
                If Left(Nozzles(k, i).Mark, 1) = "-" Then Nozzles(k, i).Mark = Right(Nozzles(k, i).Mark, Len(Nozzles(k, i).Mark) - 1)
            End If
        Next
    End Function

    Function EscludiElementi(ByRef k As Short) As Short
        Dim Stringa1(6) As String
        Dim i As Short
        Dim Stringa(20) As String
        Dim j As Short
        Dim Scelta(Config(k).Ninvolucri) As Short
        EscludiElementi = True
        Call AcqNomi(Stringa1, 0)
        For i = 1 To Config(k).Ninvolucri
            If Involucr(k, i).Tipo < 0 Or Involucr(k, i).Tipo > 4 Then Involucr(k, i).Tipo = 0
            Stringa(i) = "El.nø" & i.ToString & ", tipo:" & Stringa1(Involucr(k, i).Tipo + 1) & ":" & GlobalRoutines.Adjust(Involucr(k, i).Mark, 20)
            Scelta(i) = System.Math.Abs(Involucr(k, i).Escluso)
        Next
        'If mySwitchBox(WindowNext, 1, 1, Stringa(), Scelta(), Config.Ninvolucri, 0, "Esclusione elementi", True) = 0 Then EscludiElementi = False: Exit Function
        For i = 1 To Config(k).Ninvolucri
            Involucr(k, i).Escluso = -Scelta(i)
            If Scelta(i) Then
                For j = Involucr(k, i).inizio To Involucr(k, i).Fine
                    If Not Left(Nozzles(k, j).Mark, 1) = "-" Then Nozzles(k, j).Mark = "-" & RTrim(Nozzles(k, j).Mark)
                Next
            End If
        Next
    End Function
    Sub Rearrang(ByRef KL As Short, ByRef j As Short, ByRef Nvec As Short, ByRef Nnuov As Short)
        Dim kk, k, jj As Short
        If j >= 0 Then
            If Nnuov = 0 Then
                If j > 1 Then
                    Involucr(KL, j).inizio = Involucr(KL, j - 1).Fine
                    If Involucr(KL, j - 1).Fine < Involucr(KL, j - 1).inizio Then Involucr(KL, j).inizio = Involucr(KL, j - 1).inizio
                    Involucr(KL, j).Fine = 0
                Else
                    Involucr(KL, j).inizio = 1 : Involucr(KL, j).Fine = 0
                End If
            Else
                Involucr(KL, j).Fine = Involucr(KL, j).inizio + Nnuov - 1
            End If
            For k = Config(KL).Ninvolucri To j + 1 Step -1
188:            If Involucr(KL, k).inizio > 1 Then Involucr(KL, k).inizio = Involucr(KL, k).inizio + Nnuov - Nvec
                If Involucr(KL, k).Fine > 0 Then Involucr(KL, k).Fine = Involucr(KL, k).Fine + Nnuov - Nvec
            Next
            For k = 1 To Config(KL).Ninvolucri
                For jj = Involucr(KL, k).inizio To Involucr(KL, k).Fine
                    If Nozzles(KL, jj).inizio >= 0 Then
                        Nozzles(KL, jj).inizio = Nozzles(KL, jj).inizio + Nnuov - Nvec
                        Nozzles(KL, jj).Fine = Nozzles(KL, jj).Fine + Nnuov - Nvec
                    End If
                Next
            Next
            For k = j + 1 To Config(KL).Ninvolucri
                For kk = Involucr(KL, k).inizio To Involucr(KL, k).Fine
                    Nozzles(KL, kk).InvolucroSU = k
                Next
            Next
        Else
            If Nnuov = 0 Then
                If -j > 1 Then
                    Nozzles(KL, -j).inizio = Nozzles(KL, -j - 1).Fine
                    If Nozzles(KL, -j - 1).Fine < Nozzles(KL, -j - 1).inizio Then Nozzles(KL, -j).inizio = Nozzles(KL, -j - 1).inizio
                    Nozzles(KL, -j).Fine = 0
                Else
                    Nozzles(KL, -j).inizio = NumBocch(KL) + 1 : Nozzles(KL, -j).Fine = Nozzles(KL, -j).inizio - 1
                End If
            Else
                Nozzles(KL, -j).Fine = Nozzles(KL, -j).inizio + Nnuov - 1
            End If
            For k = NumBocch(KL) To -j + 1 Step -1
                If Nozzles(KL, k).inizio > 1 Then Nozzles(KL, k).inizio = Nozzles(KL, k).inizio + Nnuov - Nvec
                If Nozzles(KL, k).Fine > 0 Then Nozzles(KL, k).Fine = Involucr(KL, k).Fine + Nnuov - Nvec
            Next
            For k = -j + 1 To NumBocch(KL)
                For kk = Nozzles(KL, k).inizio To Nozzles(KL, k).Fine
                    Nozzles(KL, kk).InvolucroSU = -k
                Next
            Next
        End If
    End Sub
    Function TipoElementi(ByRef k As Short) As Short
        Dim Stringa1(6) As String
        Dim Stringa(20) As String
        Dim Risult(20) As String
        Dim i, y As Short
        TipoElementi = True
        Call AcqNomi(Stringa1, 0)
        For i = 1 To Config(k).Ninvolucri
            Stringa(i) = "El. n°" & i.ToString & ":" & Left(Involucr(k, i).Mark, 10)
            Risult(i) = Stringa1(Involucr(k, i).Tipo + 1)
        Next
        'Y = InputDati(2, Config.Ninvolucri, "Scelta elementi", Stringa(), Risult$(), LungStr())
        Do
            Select Case y
                Case -3
                    'a$ = " Clickando su alcuni dei campi della | finestra sottostante si otiene |"
                    'a$ = a$ + " una lista dei valori possibili. Cio' | vale in particolare per i materiali.|"
                    '              junk = Alert(4, at1(59), 4, 3, 11, 48, at1(33), "", "")
                Case -2
                    'WindowClose 2
                    TipoElementi = False : Exit Function
                Case -1
                    'WindowClose 2: Exit Do
                Case Else
                    '    i = Quale(5, "Tipo di elemento", Stringa1$(), "", Involucr(Y).Tipo + 1)
                    If i > 0 Then
                        Involucr(k, y).Tipo = i - 1
                        Risult(y) = Stringa1(i)
                    End If
            End Select
            'Y = InputDati(0, Config.Ninvolucri, "Scelta elementi", Stringa(), Risult$(), LungStr())
        Loop
    End Function
    Public Sub SelMat(Optional ByRef l As Short = -1, Optional ByRef t As Short = -1)
        Dim indice, iClasse, ms As Short
        Dim tt, i, ll, ic As Short
        ll = 1
        If Not l = -1 Then ll = l
        tt = Involucr(kLato, jInvolucr).Tipo
        If Not t = -1 Then tt = t
        indice = Involucr(kLato, jInvolucr).indice(ll - 1)
        If indice < 1 Then
            indice = NuovoIndice()
            indici.Add(indice)
            Involucr(kLato, jInvolucr).indice(ll - 1) = indice
        End If
        Select Case tt
            Case 0
                ms = Involucr(kLato, jInvolucr).ms
                Product(ms, iClasse)
            Case 1, 2, 3, 4
                iClasse = Matdim(indice).Classe
                If iClasse = 0 Then
                    For i = 1 To Config(kLato).Ninvolucri
                        Select Case Involucr(kLato, i).Tipo
                            Case 0
                                ms = Involucr(kLato, i).ms
                                Product(ms, iClasse)
                                Exit For
                        End Select
                    Next
                End If
            Case 5, 6 'flangioni PT
                iClasse = 7
            Case 7 'tubi
                iClasse = 4
            Case 8 'dilat
        End Select
        ic = Matdim(indice).Classe
        If Matdim(indice).Indmat = 0 And Matdim(indice).Agganciato Then ic = iClasse
        MatdimScelta(indice, ic, kLato, jInvolucr)
        If Matdim(indice).Editato Then Uniforma(indice)
        Involucr(kLato, jInvolucr).MATE = Matdim(indice).MatStr
    End Sub
    Private Sub Product(ByVal ms As Short, ByRef iClasse As Short)
        Select Case ms
            Case 0 'plate
                Select Case Config(kLato).mv
                    Case 0 : iClasse = 1
                    Case 1 : iClasse = 2
                End Select
            Case 1 'forging
                iClasse = 7
            Case 2 'pipe
                iClasse = 6
        End Select
    End Sub
    Public Function DatiProgCyl(ByRef k As Short, ByRef j As Short) As Short
        DatiProgCyl = False
        If Involucr(k, j).di = 0 Then Involucr(k, j).di = Config(k).di
        jInvolucr = j
        kLato = k
        AggDatiCil(k, j)
        With frmCil.DefInstance
            .ShowDialog()
            DatiProgCyl = Not .Cancel
            .Dispose()
        End With
    End Function 'f
    Private Function DatiProgFla(ByRef k As Short, ByRef j As Short) As Short
        DatiProgFla = False
        jInvolucr = j
        kLato = k
        With frmFlanAn.DefInstance
            .ShowDialog()
            DatiProgFla = Not .Cancel
            .Dispose()
        End With
    End Function 'f
    Private Function DatiProgPT(ByRef k As Short, ByRef j As Short) As Short
        Try
            DatiProgPT = False
            jInvolucr = j
            kLato = k
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
            If mioPT Is Nothing Then mioPT = New frmPT
            With mioPT
                .ShowDialog()
                DatiProgPT = Not .Cancel
                .Dispose()
            End With
            mioPT = Nothing
        Catch e As Exception
            MessageBox.Show(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Function 'f
    Private Function DatiProgTubi(ByRef k As Short, ByRef j As Short) As Short
        DatiProgTubi = False
        jInvolucr = j
        kLato = k
        With frmTub.DefInstance
            .kLatoLoc = kLato
            .jInvolucrLoc = jInvolucr
            .NumTipo = 1
            .ShowDialog()
            DatiProgTubi = Not .Cancel
            .Dispose()
        End With
    End Function 'f

    Function DatiNozzles(ByRef KL As Short, ByRef ij As Short, ByRef k As Short) As Boolean
        Dim j As Short
        'On Local Error GoTo ErrNozzles
        DatiNozzles = False
        If k = 0 Then Exit Function
        If AddDistinta = 0 And Nozzles(KL, k).indice = 0 Then
            Nozzles(KL, k).indice = NuovoIndice()
            indici.Add(Nozzles(KL, k).indice)
        End If
        If Left(Nozzles(KL, k).Mark, 1) = "-" Then DatiNozzles = True : Exit Function
        If NozzAdd(KL, k).TipAbutt < 1 Or NozzAdd(KL, k).TipAbutt > 5 Then NozzAdd(KL, k).TipAbutt = 1
        'UPGRADE_WARNING: Screen proprietà Screen.MousePointer presenta un nuovo comportamento. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup2065"'
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        If ij > 0 Then
            j = Involucr(KL, ij).Tipo
            frmNoz.DefInstance.Text = "Dati Apertura su " & Involucr(KL, ij).Mark
        Else
            j = 0
        End If
        If (j = 0 Or j = 4) And Nozzles(KL, k).DiaN = 0 And Nozzles(KL, k).DiOn = 0 And Nozzles(KL, k).DiIn = 0 Then Nozzles(KL, k).beta = 90
        Call Diametri(KL, k, 1)
        frmNoz.DefInstance.Diam(KL, k)
        jInvolucr = ij
        kNozzle = k
        kLato = KL
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        frmNoz.DefInstance.ShowDialog()
        DatiNozzles = Not frmNoz.DefInstance.Cancel
    End Function 'e
    Public Sub EliminBocc(ByRef KL As Short, ByRef ij As Short, ByRef k As Short, ByRef Zitto As Boolean)
        Dim NBocch As Short
        Dim junk As DialogResult
        Dim Testo As String
        If Not Zitto Then
            Testo = " Siete sicuri di voler eliminare | questo bocchello ?"
            junk = MessageBox.Show(clsInizio.ConvertiCr(Testo), "asmeVip", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        Else
            junk = DialogResult.Yes
        End If
        If junk = DialogResult.Yes Then
            NBocch = NumLoc(KL, ij)
            If NBocch = 0 Then Exit Sub
            ElimMaterNoz(KL, k)
            kNozzle = k
            Call AggBocc((ij), NBocch, NBocch - 1)
        End If
    End Sub
    Public Function ConvertiElemento(ByRef Tipo As Short) As Boolean
        Dim j As Short
        Dim k As String
        Dim Stringa1(20) As String
        Dim n, i, iRisp As Short
        Dim TipoSav As Short
        ConvertiElemento = True
        If mioApert.SelNode Is Nothing Then
            Beep()
            mioApert.mnuConvElem.Enabled = False
            Exit Function
        End If
        k = mioApert.SelNode.Tag
        If InStr(k, "Inv") > 0 Then
            k = Right(k, Len(k) - 3)
            n = InStr(k, "_")
            kLato = GlobalRoutines.ValVir(Left(k, n - 1))
            j = GlobalRoutines.ValVir(Right(k, Len(k) - n))
        End If
        If j = 0 Then Exit Function
        If Tipo = -1 Then
            If Collega1(j) Then Exit Function
            n = -1
            jInvolucr = j
            '  Call AcqNomi(Stringa1(), n)
            TipoSav = Involucr(kLato, j).Tipo
            AcqNomi(Stringa1, n, iRisp, Involucr(kLato, j).Tipo)
        Else
            Involucr(kLato, j).Tipo = Tipo
        End If
        If iRisp = 0 Then Involucr(kLato, j).Tipo = TipoSav : Exit Function
        If Involucr(kLato, j).Tipo = 6 Or Involucr(kLato, j).Tipo = 7 Then
            For i = 1 To Config(kLato).Ninvolucri
                If i <> j And Involucr(kLato, j).Tipo = Involucr(kLato, i).Tipo Then
                    If Not Monitor.Motore.Inizio.EmsChecked Then
                        MostraAiuto(2108)
                    Else
                        MostraAiuto(IDH_ELEMENTODUPLICATO)
                    End If
                    Involucr(kLato, j).Tipo = TipoSav
                    ConvertiElemento = False
                    Exit Function
                End If
            Next
        End If
        CreaOggetto(j)
    End Function
    Public Sub InseElemento(ByRef KL As Short)
        Dim i As Short
        CambiaColl(1, KL, jInvolucr)
        Config(KL).Ninvolucri = Config(KL).Ninvolucri + 1
        Ridimensiona(Config(KL).Ninvolucri)
        For i = Config(KL).Ninvolucri To jInvolucr + 1 Step -1
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Involucr(KL, i). Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            Involucr(KL, i) = Involucr(KL, i - 1)
        Next
        Introduci(KL, jInvolucr)
    End Sub
    Public Sub ElimElemento(Optional ByRef Zitto As Boolean = False)
        Dim i, j, ii As Short
        Dim k As String
        Dim Testo As String
        Dim NBocch, n As Short
        Dim Cercanome As clsCercaNome
        If mioApert.SelNode Is Nothing Then
            Beep()
            mioApert.mnuElimElemento.Enabled = False
            Exit Sub
        End If
        k = mioApert.SelNode.Tag
        If InStr(k, "Noz") > 0 Then
            Testo = Right(k, Len(k) - 3)
            n = InStr(Testo, "_")
            kLato = GlobalRoutines.ValVir(Left(Testo, n - 1))
            j = GlobalRoutines.ValVir(Right(Testo, Len(Testo) - n))
            EliminBocc(kLato, Nozzles(kLato, j).InvolucroSU, j, Zitto)
            Exit Sub
        End If
        If InStr(k, "Inv") > 0 Then
            Testo = Right(k, Len(k) - 3)
            n = InStr(Testo, "_")
            kLato = GlobalRoutines.ValVir(Left(Testo, n - 1))
            j = GlobalRoutines.ValVir(Right(Testo, Len(Testo) - n))
        End If
        If j = 0 Then Exit Sub
        If Collega1(j) Then Exit Sub
        NBocch = NumLoc(kLato, j)
        If NBocch > 0 And Not Zitto Then
            Testo = "Vuoi eliminare veramente l'elemento " & Trim(Involucr(kLato, j).Mark)
            Testo = Testo & "|e i" & Str(NBocch) & " bocchelli che esso supporta?"
            If MessageBox.Show(clsInizio.ConvertiCr(Testo), "AsmeVip", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Exit Sub
        End If
        For ii = Involucr(kLato, j).inizio To Involucr(kLato, j).Fine
            EliminBocc(kLato, j, ii, Zitto)
        Next
        CambiaColl(-1, kLato, j)
        Config(kLato).Ninvolucri = Config(kLato).Ninvolucri - 1
        ElimMaterInv(kLato, j)
        For i = j To Config(kLato).Ninvolucri
            If Not ElencoInvolucri Is Nothing Then
                Cercanome = ElencoInvolucri.Item(Trim(Involucr(kLato, i + 1).Mark))
                Cercanome.jInvolucr = i
            End If
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Involucr(kLato, i). Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            Involucr(kLato, i) = Involucr(kLato, i + 1)
        Next
        Aggiorna()
    End Sub
    Private Sub ElimMaterInv(ByVal k As Short, ByVal j As Short)
        Dim ii, indice As Short
        For ii = 0 To 7
            indice = Involucr(k, j).indice(ii)
            If Not EsisteIndice(indice, k, j) Then
                Matdim(indice) = Nothing
                indici.RemoveValue(indice)
            End If
        Next
    End Sub
    Private Sub ElimMaterNoz(ByVal k As Short, ByVal j As Short)
        Dim indice As Short
        indice = Nozzles(k, j).IndexF
        If Not EsisteIndice(indice, k, , j) Then Matdim(indice) = Nothing : indici.RemoveValue(indice)
        indice = Nozzles(k, j).indice
        If Not EsisteIndice(indice, k, , j) Then Matdim(indice) = Nothing : indici.RemoveValue(indice)
        indice = Nozzles(k, j).IndiceB
        If Not EsisteIndice(indice, k, , j) Then Matdim(indice) = Nothing : indici.RemoveValue(indice)
        indice = Nozzles(k, j).indiceF
        If Not EsisteIndice(indice, k, , j) Then Matdim(indice) = Nothing : indici.RemoveValue(indice)
        indice = Nozzles(k, j).IndiceP
        If Not EsisteIndice(indice, k, , j) Then Matdim(indice) = Nothing : indici.RemoveValue(indice)
    End Sub
    Public Function NumLoc(ByVal k As Short, ByVal j As Short) As Short
        Dim NBocch As Short
        If j >= 0 Then
            NBocch = Involucr(k, j).Fine - Involucr(k, j).inizio + 1
            If Involucr(k, j).inizio = 0 And Involucr(k, j).Fine = 0 Then NBocch = 0
            If NBocch < 0 Then NBocch = 0
        Else
            NBocch = Nozzles(k, -j).Fine - Nozzles(k, -j).inizio + 1
            If NBocch < 0 Then NBocch = 0
            If Nozzles(k, -j).Fine = 0 And Nozzles(k, -j).inizio = 0 Then NBocch = 0
        End If
        NumLoc = NBocch
    End Function
    Public Function NumBocch2(ByRef k As Short, Optional ByRef j As Short = -1) As Short
        Dim i, Ntot, n As Short
        Dim Log1 As Boolean
        'numero bocchelli di secondo livello fino a j compreso di primo livello
        If j = -1 Then
            Ntot = NumBocch(k)
        Else
            Ntot = j
        End If
        n = 0
        For i = 1 To Ntot
            On Error GoTo ExitF
            If Nozzles(k, i).Fine >= Nozzles(k, i).inizio Then
                If Not (Nozzles(k, i).Fine = 0 And Nozzles(k, i).inizio = 0) Then
                    n = n + Nozzles(k, i).Fine - Nozzles(k, i).inizio + 1
                End If
            End If
        Next
ExitF:
        NumBocch2 = n
    End Function
    Public Function NumBocch(ByRef k As Short) As Short
        Dim i, Nnozzv, jj As Short
        'numero bocchelli di primo livello
        On Error GoTo ErrNB
        '---------correzione errori precedenti
        For i = 1 To Config(k).Ninvolucri - 1
            If Involucr(k, i).Fine >= Involucr(k, i).inizio Then
                If Involucr(k, i + 1).Fine < Involucr(k, i).inizio Then
                    Involucr(k, i + 1).inizio = Involucr(k, i).Fine + 1
                    Involucr(k, i + 1).Fine = Involucr(k, i + 1).inizio - 1
                End If
            Else
                If Involucr(k, i + 1).Fine < Involucr(k, i).inizio Then
                    Involucr(k, i + 1).inizio = Involucr(k, i).inizio
                    Involucr(k, i + 1).Fine = Involucr(k, i).Fine
                End If
            End If
        Next
        '--------------------------------------
        jj = 0
        Do
            If Involucr(k, Config(k).Ninvolucri - jj).Fine >= Involucr(k, Config(k).Ninvolucri - jj).inizio Then
                Nnozzv = Involucr(k, Config(k).Ninvolucri - jj).Fine
                Exit Do
            End If
            jj = jj + 1
            If Config(k).Ninvolucri - jj = 0 Then
                Nnozzv = 0
                Exit Do
            End If
        Loop
        '    For i = 1 To UBound(Nozzles, 2)
        '        If Nozzles(k, i).InvolucroSU < 0 Then Nnozzv = Nnozzv + 1
        '    Next
ResNB:
        NumBocch = Nnozzv
        Exit Function
ErrNB:  Resume ResNB
    End Function
    Private Sub AlberoBocch(ByRef KL As Short, ByRef j As Short, ByRef Nodx As TreeNode)
        Dim k, kk As Short
        Dim Nody, Nodz As TreeNode
        Dim Ce As Boolean
        If Involucr(KL, j).inizio = 0 And Involucr(KL, j).Fine = 0 Then Exit Sub
        For k = Involucr(KL, j).inizio To Involucr(KL, j).Fine
            Nody = Nodx.Nodes.Add(Trim(Nozzles(KL, k).Mark))
            Nody.Tag = "Noz" & Trim(Str(KL)) & "_" & Trim(Str(k))
            Nody.ImageIndex = 5
            Nozzles(KL, k).InvolucroSU = j
            For kk = NumBocch(KL) + 1 To NumBocch(KL) + NumBocch2(KL)
                If Nozzles(KL, kk).InvolucroSU = -k Then
                    Nodz = Nody.Nodes.Add(Trim(Nozzles(KL, kk).Mark))
                    Nodz.Tag = "Noz" & Trim(Str(KL)) & "_" & Trim(Str(kk))
                    Nodz.ImageIndex = 5
                    Ce = True
                    If kk > Nozzles(KL, k).Fine Then Nozzles(KL, k).Fine = kk
                    If kk < Nozzles(KL, k).inizio Then Nozzles(KL, k).inizio = kk
                End If
            Next
            If Not Ce Then Nozzles(KL, k).Fine = Nozzles(KL, k).inizio - 1
        Next
    End Sub

    Public Sub AggiustaHydr(ByVal KL As Short, ByVal j As Short, ByVal k As Short, ByRef P0 As Single, Optional ByRef ht As Boolean = False)
        Dim Hydr As Single
        Dim savK, SU, savJ As Short
        Dim Testo As String
        savK = kLato : savJ = jInvolucr
        If Not ht Then
            If j > 0 Then
                Hydr = Involucr(KL, j).HydrDepth
            ElseIf k > 0 Then
                SU = Nozzles(KL, k).InvolucroSU
Rif:            If SU > 0 Then
                    Hydr = Involucr(KL, SU).HydrDepth
                ElseIf SU < 0 Then
                    SU = Nozzles(KL, -SU).InvolucroSU
                    GoTo Rif
                Else
                    Hydr = 0 ': Exit Sub
                End If
                j = SU
                If j = 0 Then j = 1
            Else
                GoTo Ripristina
            End If
            kLato = KL : jInvolucr = j
            P0 = PressDes()
            P0 = P0 + GRAV * 0.000001 * Involucr(KL, j).DensFluido * Hydr * System.Math.Sign(P0)
        Else
            If Config(0).CalcPI = 0 Then Exit Sub
            If j > 0 Then
                Hydr = Involucr(KL, j).HydrDepth
            ElseIf k > 0 Then
                SU = Nozzles(KL, k).InvolucroSU
Rif1:           If SU > 0 Then
                    Hydr = Involucr(KL, SU).HydrDepth
                ElseIf SU < 0 Then
                    SU = Nozzles(KL, -SU).InvolucroSU
                    GoTo Rif1
                Else
                    Hydr = 0 'Exit Sub
                End If
                j = SU
                If j = 0 Then j = 1
            Else
                GoTo Ripristina
            End If
            If Config(0).HTTestVert = 0 Then Hydr = Config(kLato).di
            If Hydr <= 0 Then
                If Config(0).HTTestVert = 0 Then
                    If KL = 3 Then
                        Hydr = Config(1).di
                        If Config(2).di > Hydr Then Hydr = Config(2).di
                        Config(3).di = Hydr
                    End If
                    If Hydr <= 0 Then
                        '        Testo = "E' stata selezionata la prova idraulica in orizzontale,|"
                        'Testo = Testo + "ma non è stato definito il diametro dell'apparecchio.|"
                        'Testo = Testo + "Fornire la profondità idrostatica in prova idraulica|"
                        'Testo = Testo + "in millimetri"
                        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.inizio.ConvertiCr(). Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                        Testo = Monitor.Motore.Inizio.ConvertiCr(Helpstringa(IDH_ST_HYDRDEPTHH))
                        Hydr = GlobalRoutines.ValVir(InputBox(Testo, "AsmeVip", "      "))
                        Config(KL).di = Hydr
                    End If
                Else
                    '        Testo = "E' stata selezionata la prova idraulica in verticale,|"
                    'Testo = Testo + "ma non è stata definita la profondità idrostatica.|"
                    'Testo = Testo + "della membratura &.|"
                    'Testo = Testo + "Fornire il valore in millimetri."
                    GlobalRoutines.FormatS("non|")
                    Testo = Monitor.Motore.Inizio.ConvertiCr(GlobalRoutines.FormatS(Helpstringa(IDH_ST_HYDRDEPTHV), Involucr(KL, j).Mark))
                    Hydr = GlobalRoutines.ValVir(InputBox(Testo, "AsmeVip", "      "))
                    Involucr(KL, j).HydrDepth = Hydr
                End If
            End If
            If KL < 3 Then
                P0 = Config(KL).pxTest
                P0 = Config(KL).pxTest + GRAV * 0.000001 * Hydr * System.Math.Sign(P0)                  ' * psi
            Else
                P0 = Config(1).pxTest
                If Config(2).pxTest > 0 Then P0 = Config(2).pxTest
                P0 = P0 + GRAV * 0.000001 * Hydr * System.Math.Sign(P0)
            End If
        End If
Ripristina: kLato = savK : jInvolucr = savJ
    End Sub

    Public Sub VariaBocc(ByRef Nuovo As Short, Optional ByVal m As Short = 0)
        Dim NBocch, j As Short
        Dim f As System.Windows.Forms.Form
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        f = System.Windows.Forms.Form.ActiveForm
        If Not f Is Nothing Then f.Enabled = False
        If m = 0 Then j = jInvolucr Else j = -kNozzle
        NBocch = NumLoc(kLato, j)
        If Nuovo < NBocch Then
            MessageBox.Show(clsInizio.ConvertiCr("Per eliminare un bocchello:|selezionarlo sulla struttura e accedere|al menu 'Elimina'"))
        Else
            Call AggBocc(j, NBocch, Nuovo)
            DatiInputC(1)
        End If
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        If Not f Is Nothing Then f.Enabled = True
    End Sub

    Public Sub CheckDimNoz(ByRef Nnozz As Short)
        Dim i, j, Dimen As Short
231:    Dimen = UBound(Nozzles, 2)
        If Nnozz > Dimen Then
            MaxNozAct = 2 * Nnozz
            ReDim Preserve Nozzles(4, MaxNozAct)
            ReDim Preserve NozzAdd(4, MaxNozAct)
            For i = 0 To 4
                For j = Dimen + 1 To MaxNozAct
                    Nozzles(i, j).Initialize()
                    NozzAdd(i, j).Initialize()
                Next
            Next
        End If
    End Sub

    Private Sub AlberoInv(ByRef k As Short, ByRef j As Short, ByRef im As Short)
        Dim Nodx As TreeNode
        If Config(0).NumeroLati = 1 Then
            Nodx = mioApert.TreeView1.Nodes.Add(Trim(Involucr(k, j).Mark))
        Else
            Nodx = Nodbase(k).Nodes.Add(Trim(Involucr(k, j).Mark))
        End If
        Nodx.Tag = "Inv" & Trim(Str(k)) & "_" & Trim(j.ToString)
        Nodx.ImageIndex = im
        If j = jInvolucr And k = kLato Then mioApert.TreeView1_NodeClick(Nodx)
        AlberoBocch(k, j, Nodx)
    End Sub
    Function DatiProgFon(ByRef k As Short, ByRef j As Short) As Short
        Try
            DatiProgFon = False
            If Involucr(k, j).ms < 1 Then Involucr(k, j).ms = 1
            If Involucr(k, j).di = 0 Then Involucr(k, j).di = Config(k).di
            jInvolucr = j
            kLato = k
            AggDatiFon(k, j)
            frmFon.DefInstance.ShowDialog()
            If Involucr(k, j).ms = 6 And Involucr(k, j).L0 > 0 Then
                If (Involucr(k, j).R0 / Involucr(k, j).L0) < 0.06 Then Call Erro(8)
            End If 'q
            DatiProgFon = Not frmFon.DefInstance.Cancel
            frmFon.DefInstance.Dispose()
        Catch e As Exception
            MessageBox.Show(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Function 'g
    Public Sub TrasfDilat()
        Dim O As wn_FTC
        Dim td1, c, pd1 As Single
        With Involucr(kLato, jInvolucr)
            O = CType(CType(objMemb(.IndObject), wn_PT).Piastra, wn_FTC)
            O.TipoDilatp = .SottoTipo
            O.Zp(1, 26) = .dns
            c = .cs * CondizioniCorrose
            If .OS > c Then c = .OS
            O.Zp(1, 19) = c
            If O.SoloDilat Then
                td1 = .Destemp
                If Not VerificandoPI Then
                    If Not Config(0).DiverseTemp Then td1 = Config(kLato).tdx
                End If
                pd1 = Config(kLato).p0x
                O.Zp(1, 1) = pd1
                O.Zp(1, 5) = td1
            End If
            If O.Zp(1, 274) < .St Then
                O.Zp(1, 274) = .St
            Else
                .St = O.Zp(1, 274)
            End If
            If O.Zp(1, 275) < .SU Then
                O.Zp(1, 275) = .SU
            Else
                .SU = O.Zp(1, 275)
            End If
            O.Zp(1, 281) = .Dati2
            O.Zp(1, 282) = .Dati3
        End With
    End Sub

    Public Function Collega1(ByRef j As Short) As Boolean
        Dim k As Short
        Dim Nome As String
        For k = 1 To ElencoCollegamenti.Count()
            With ElencoCollegamenti.Item(k)
                If .Lato1 = kLato And .Membro1 = j And .Membro2 > 0 Then
                    Nome = "L'elemento " & Trim(Involucr(kLato, j).Mark) & vbCrLf
                    Nome = Nome & "non può essere eliminato o convertito, in quanto" & vbCrLf
                    Nome = Nome & "collegato all'elemento " & Trim(Involucr(.Lato2, .Membro2).Mark)
                    MessageBox.Show(Nome)
                    Collega1 = True
                    Exit Function
                End If
                If .Lato2 = kLato And .Membro2 = j And .Membro1 > 0 Then
                    Nome = "L'elemento " & Trim(Involucr(kLato, j).Mark) & vbCrLf
                    Nome = Nome & "non può essere eliminato o convertito, in quanto" & vbCrLf
                    Nome = Nome & "collegato all'elemento " & Trim(Involucr(.Lato1, .Membro1).Mark)
                    MessageBox.Show(Nome)
                    Collega1 = True
                    Exit Function
                End If
            End With
        Next
        Collega1 = False
    End Function

    Private Sub CambiaColl(ByRef piu As Short, ByRef KL As Short, ByRef j As Short)
        Dim i, k As Short
        Dim O As wn_PT
        For i = j To Config(KL).Ninvolucri
            For k = 1 To ElencoCollegamenti.Count()
                With ElencoCollegamenti.Item(k)
                    If .Lato1 = KL And .Membro1 = i Then
                        Select Case .Tipo
                            Case 1

                        End Select
                    End If
                    If .Lato2 = KL And .Membro2 = i Then
                        Select Case .Tipo
                            Case 1
                                Involucr(.Lato1, .Membro1).AccoppJ = .Membro2 + piu
                            Case 2
                                Involucr(.Lato1, .Membro1).jmemb1 = .Membro2 + piu
                            Case 3
                                Involucr(.Lato1, .Membro1).jmemb2 = .Membro2 + piu
                            Case 4
                                O = CType(objMemb(Involucr(.Lato1, .Membro1).IndObject), wn_PT)
                                CType(O.Piastra, wn_FTC).IndiceDilat = .Membro2 + piu
                            Case 10
                                O = CType(objMemb(Involucr(.Lato1, .Membro1).IndObject), wn_PT)
                                CType(O.Piastra, wn_FTC).IndiceFondo = .Membro2 + piu
                            Case 11
                                O = CType(objMemb(Involucr(.Lato1, .Membro1).IndObject), wn_PT)
                                CType(O.Piastra, wn_FTC).IndiceFlanF = .Membro2 + piu
                            Case 12
                                O = CType(objMemb(Involucr(.Lato1, .Membro1).IndObject), wn_PT)
                                CType(O.Piastra, wn_FTC).IndiceShell = .Membro2 + piu
                            Case 13
                                O = CType(objMemb(Involucr(.Lato1, .Membro1).IndObject), wn_PT)
                                CType(O.Piastra, wn_FTC).IndiceSplitR = .Membro2 + piu
                            Case 5 To 8
                                O = CType(objMemb(Involucr(.Lato1, .Membro1).IndObject), wn_PT)
                                O.IndAccopp(.Tipo - 4) = .Membro2 + piu
                        End Select
                    End If
                End With
            Next k
        Next i

    End Sub

    Public Sub CreaOggetto(ByRef j As Short)
        Dim i As Short
        Select Case Involucr(kLato, j).Tipo
            Case 9 'pass partition
                i = NuovoIndObj()
                Involucr(kLato, j).IndObject = i
                Involucr(kLato, jInvolucr).Mark = "Pass partition"
                objMemb(i) = New wn_Part
            Case 6, 8 'P.T.,dil
                i = NuovoIndObj()
                Involucr(kLato, j).IndObject = i
                objMemb(i) = New wn_PT
                CType(objMemb(i), wn_PT).PrimaVolta = True
                CType(objMemb(i), wn_PT).Piastra = New wn_FTC
                CType(objMemb(i), wn_PT).TipoPT = 2
                If Involucr(kLato, j).Tipo = 8 Then
                    CType(CType(objMemb(i), wn_PT).Piastra, wn_FTC).SoloDilat = True
                Else
                    CType(CType(objMemb(i), wn_PT).Piastra, wn_FTC).SoloDilat = False
                    CType(CType(objMemb(i), wn_PT).Piastra, wn_FTC).Rear = 1
                End If
            Case 7
                i = NuovoIndObj()
                Involucr(kLato, jInvolucr).Mark = "Exchanger tubes"
                Involucr(kLato, j).IndObject = i
                objMemb(i) = New wn_Tub
            Case 5 'Flangione
                i = NuovoIndObj()
                Involucr(kLato, j).IndObject = i
                objMemb(i) = New wn_flan
                With CType(objMemb(i), wn_flan)
                    .Mp(1) = Config(kLato).p0x
                    .Mp(2) = Config(kLato).tdx
                    .Zp(1) = Config(kLato).p0x * psi
                    .Zp(2) = 1.8 * Config(kLato).tdx + 32
                    .SicBullp = 1.1
                    .FattBoltSy = 0.69
                    .LatoProgetto = 3 - kLato
                End With
                Involucr(kLato, j).indice(2 - 1) = NuovoIndice()
                indici.Add(Involucr(kLato, j).indice(2 - 1))
                Involucr(kLato, j).indice(3 - 1) = -1
                Matdim(Involucr(kLato, j).indice(2 - 1)) = New LibMat.MaterialeNew1
        End Select
    End Sub
    Public Function PressDes(Optional ByVal k As Short = 0, Optional ByVal j As Short = 0) As Single
        Dim p As Single
        If k = 0 Then k = kLato
        If j = 0 Then j = jInvolucr
        If k < 3 Then
            If VerificandoPI Then
                p = Config(k).pxTest
            Else
                p = Config(k).p0x
            End If
        ElseIf j > 0 Then
            If VerificandoPext Then
                If VerificandoPI Then
                    If Config(1).p0x * Involucr(3, j).PressExt = 0 Then
                        p = -Config(1).pxTest
                    Else
                        p = -Involucr(3, j).PressExt * Config(1).pxTest / Config(1).p0x
                    End If
                Else
                    p = -Involucr(3, j).PressExt
                End If
            ElseIf VerificandoPI Then
                If Config(2).p0x * Involucr(3, j).PressInt = 0 Then
                    p = Config(2).pxTest
                Else
                    p = Involucr(3, j).PressInt * Config(2).pxTest / Config(2).p0x
                End If
            Else
                p = Involucr(3, j).PressInt
            End If
        End If
        PressDes = p
    End Function
    Public Function Pextdes() As Single
        If kLato < 3 Then
            Pextdes = Config(kLato).pxExt ' * psi
        ElseIf jInvolucr > 0 Then
            Pextdes = Involucr(3, jInvolucr).PressExt '* psi
        End If
    End Function
    Public Function Textdes() As Single
        Dim td As Single
        If kLato < 3 Then
            If Config(0).DiverseTemp = 1 Then
                Textdes = TempDes()
            Else
                td = Config(kLato).txExt
                Textdes = td
            End If
        ElseIf jInvolucr > 0 Then
            Textdes = TempDes()
        End If
    End Function
End Module