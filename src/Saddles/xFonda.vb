Option Strict Off
Option Explicit On 
Imports RoutBase1
Imports System.String
Module xFonda
	Public TabRoark(4, 9) As Single
    'Program$ = " Program XFONDA Ver.: 3.1R, Nov 18th, 1993."
	Sub CalcolaFonda(ByRef Factor As Single)
		Dim tabe, NonVaBene, i As Short
		Dim sig, neax, xQ As Single
		Dim k, kk As Short
		Dim Delta, x As Single
		Dim NonAccettabile As Short
		Dim Largh, Trasv As Single
		Dim d, Press, Den As Single
        Dim Msgg As String = ""
		Dim ab, dif As Single
		Dim CommentoFinale As String
		Dim beta12, beta11, Facto1 As Single
		Dim beta21, beta22 As Single
		Dim beta31, beta32 As Single
		Dim beta3, beta1, beta2, beta As Single
		Dim mx, rap1, rap2, my As Single
        Dim sfx, sfy As Single
        Dim Normale As Boolean 'falso se e è molto negativo
        If ControlloDati() <> 0 Then Exit Sub
        Try
            xFondaData(iSadd, iCond).Press = xFondaData(iSadd, iCond).n / (xFondaItem(iSadd).a * xFondaItem(iSadd).b)
            mx = System.Math.Abs(xFondaData(iSadd, iCond).mx)
            my = System.Math.Abs(xFondaData(iSadd, iCond).my)
            sfx = System.Math.Abs(xFondaData(iSadd, iCond).sfx)
            sfy = System.Math.Abs(xFondaData(iSadd, iCond).sfy)
            For k = 1 To 2
                'Tag = xFondaItem(iSadd).nb * xFondaItem(iSadd).ag
                If k = 1 Then
                    xFondaData(iSadd, iCond).E(k) = mx / xFondaData(iSadd, iCond).n * 1000
                    Largh = xFondaItem(iSadd).a
                    Trasv = xFondaItem(iSadd).b
                    If Math.Abs(xFondaData(iSadd, iCond).E(k)) > Largh / 6 Then GoTo 1
                Else
                    xFondaData(iSadd, iCond).E(k) = my / xFondaData(iSadd, iCond).n * 1000
                    Largh = xFondaItem(iSadd).b
                    Trasv = xFondaItem(iSadd).a
                    If Math.Abs(xFondaData(iSadd, iCond).E(k)) > Largh / 6 Then GoTo 1
                End If
                If xFondaData(iSadd, iCond).Press > 0 Then
                    xFondaData(iSadd, iCond).sic(k) = xFondaData(iSadd, iCond).Press
                    If k = 1 Then
                        Delta = 6 * mx * 1000 / (Trasv * Largh ^ 2)
                    Else
                        Delta = 6 * my * 1000 / (Trasv * Largh ^ 2)
                    End If
                    xFondaData(iSadd, iCond).sic(k) = xFondaData(iSadd, iCond).sic(k) + Delta
                    xFondaData(iSadd, iCond).X(k) = Largh
                    xFondaData(iSadd, iCond).Coef(k) = (xFondaData(iSadd, iCond).sic(k) - 2 / 3 * Delta) / xFondaData(iSadd, iCond).sic(k)
                    If k = 1 Then
                        If xFondaItem(iSadd).A1 <= xFondaItem(iSadd).a / 2 Then xFondaData(iSadd, iCond).Coef(k) = (1 + xFondaData(iSadd, iCond).Coef(k)) / 2
                    Else
                        If xFondaItem(iSadd).B1 <= xFondaItem(iSadd).b / 2 Then xFondaData(iSadd, iCond).Coef(k) = (1 + xFondaData(iSadd, iCond).Coef(k)) / 2
                    End If
                    xFondaData(iSadd, iCond).sig(k) = 0
                Else
                    If k = 2 And Not xFondaItem(iSadd).Inchiavard Then
                        xFondaItem(iSadd).Inchiavard = True
                        MostraAiuto(IDH_DEVIINCHIAVARDARE, ChiaviMess.MessInformation Or ChiaviMess.MessOkOnly)
                    End If
                    xFondaData(iSadd, iCond).sic(k) = 0
                    xFondaData(iSadd, iCond).sig(k) = -xFondaData(iSadd, iCond).n / xFondaItem(iSadd).nt / xFondaItem(iSadd).ag
                    Dim Somma As Single = 0
                    Dim xQmax As Single = 0
                    For kk = 1 To xFondaItem(iSadd).nt
                        If k = 1 Then
                            xQ = xFondaItem(iSadd).yQuota(kk)
                        Else
                            xQ = xFondaItem(iSadd).xQuota(kk)
                        End If
                        Somma = Somma + xQ ^ 2
                        If Math.Abs(xQ) > xQmax Then xQmax = Math.Abs(xQ)
                    Next kk
                    If xQmax > 0 Then xFondaData(iSadd, iCond).sig(k) = xFondaData(iSadd, iCond).sig(k) + Math.Abs(xFondaData(iSadd, iCond).E(k) * xFondaData(iSadd, iCond).n) * xQmax / Somma / xFondaItem(iSadd).ag
                End If
                GoTo 12
1:
                For x = 0 To Largh Step 0.1
                    neax = x ^ 3 + 3 * (xFondaData(iSadd, iCond).E(k) - Largh / 2) * x ^ 2
                    For kk = 1 To xFondaItem(iSadd).nt
                        If k = 1 Then
                            xQ = xFondaItem(iSadd).yQuota(kk)
                            d = xFondaData(iSadd, iCond).E(k) + xQ
                        Else
                            xQ = xFondaItem(iSadd).xQuota(kk)
                            d = xFondaData(iSadd, iCond).E(k) + xQ
                        End If
                        If xQ + Largh / 2 > x And (iSadd = 1 Or xFondaItem(iSadd).Inchiavard) Then
                            neax = neax + 6 * xFondaItem(iSadd).Rm * xFondaItem(iSadd).ag / Trasv * d * (x - xQ - Largh / 2)
                        End If
                    Next kk
                    If x = 0 Then Normale = neax < 0
                    If x > 0 And (neax > 0 And Normale) Or (neax < 0 And Not Normale) Then xFondaData(iSadd, iCond).X(k) = x : GoTo 2
                Next x
                NonVaBene = 0
                If x >= Largh Then
                    NonVaBene = 1
                    Throw New Exception("x risulta superiore a Largh")
                End If

2:
                If x = 0.1 Then
                    Msgg = "La sella n°" & Str(iSadd) & ", nella condizione " & Problem.LoadCond(3, iCond + 1)
                    Msgg = Msgg & ", non è stabile al momento rovesciante laterale. Occorre aumentare lo sforzo normale o ridurre il momento rovesciante."
                    If iSadd = 2 And Not xFondaItem(iSadd).Inchiavard Then
                        Msgg = Msgg & vbCrLf & " Alternativamente è possibile specificare che anche la sella mobile sia inchiavardata al suolo."
                    End If
                    MsgBox(Msgg, MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly)
                End If
                If k = 1 Then
                    xFondaData(iSadd, iCond).Coef(k) = 1
                Else
                    If x < xFondaItem(iSadd).B1 Then
                        xFondaData(iSadd, iCond).Coef(k) = 0.66 * x / xFondaItem(iSadd).B1
                    Else
                        xFondaData(iSadd, iCond).Coef(k) = 0.66 * (1 + 0.515 * (x - xFondaItem(iSadd).B1) / x)
                    End If
                End If
                Den = (Trasv * x / 2)
                For kk = 1 To xFondaItem(iSadd).nt
                    If k = 1 Then
                        xQ = xFondaItem(iSadd).yQuota(kk)
                    Else
                        xQ = xFondaItem(iSadd).xQuota(kk)
                    End If
                    If xQ + Largh / 2 > x And (iSadd = 1 Or xFondaItem(iSadd).Inchiavard) Then
                        Den = Den + (xQ + Largh / 2 - x) * xFondaItem(iSadd).Rm * xFondaItem(iSadd).ag / x
                    End If
                    xFondaData(iSadd, iCond).sic(k) = xFondaData(iSadd, iCond).n / Den
                Next
                sig = 0 : xFondaData(iSadd, iCond).sig(k) = 0
                For kk = 1 To xFondaItem(iSadd).nt
                    If k = 1 Then
                        xQ = xFondaItem(iSadd).yQuota(kk)
                    Else
                        xQ = xFondaItem(iSadd).xQuota(kk)
                    End If
                    If iSadd = 1 Or xFondaItem(iSadd).Inchiavard Then
                        sig = xFondaItem(iSadd).Rm * xFondaData(iSadd, iCond).sic(k) / x * (xQ + Largh / 2 - x)
                    End If
                    If sig > xFondaData(iSadd, iCond).sig(k) Then xFondaData(iSadd, iCond).sig(k) = sig
                Next
12:
                xFondaData(iSadd, iCond).si(k) = xFondaData(iSadd, iCond).sig(k) * xFondaItem(iSadd).ag / xFondaItem(iSadd).an
                xFondaData(iSadd, iCond).sipb(k) = xFondaData(iSadd, iCond).sig(k) * xFondaItem(iSadd).ag / (xFondaItem(iSadd).nc * 2 * xFondaItem(iSadd).SP ^ 2 / 6)
                If k = 1 Then
                    xFondaData(iSadd, iCond).sh(k) = sfy / xFondaItem(iSadd).nt / xFondaItem(iSadd).an
                Else
                    xFondaData(iSadd, iCond).sh(k) = sfx / xFondaItem(iSadd).nt / xFondaItem(iSadd).an
                End If
            Next k

            ab = xFondaItem(iSadd).A1 / xFondaItem(iSadd).B1
            For tabe = 0 To 9
                If ab <= TabRoark(1, tabe) Then Exit For
            Next tabe
            beta12 = TabRoark(2, tabe)
            beta11 = TabRoark(2, tabe - 1)
            beta22 = TabRoark(3, tabe)
            beta21 = TabRoark(3, tabe - 1)
            beta32 = TabRoark(4, tabe)
            beta31 = TabRoark(4, tabe - 1)
            dif = ab - TabRoark(1, tabe - 1)
            beta1 = beta11 + (beta12 - beta11) * dif / (TabRoark(1, tabe) - TabRoark(1, tabe - 1))
            beta2 = beta21 + (beta22 - beta21) * dif / (TabRoark(1, tabe) - TabRoark(1, tabe - 1))
            beta3 = beta31 + (beta32 - beta31) * dif / (TabRoark(1, tabe) - TabRoark(1, tabe - 1))
            If beta1 > beta2 And beta1 > beta3 Then beta = beta1
            If beta2 > beta3 Then beta = beta2 Else beta = beta3
            xFondaData(iSadd, iCond).beta = beta
            Press = (xFondaData(iSadd, iCond).sic(1) - xFondaData(iSadd, iCond).Press) * xFondaData(iSadd, iCond).Coef(1) + (xFondaData(iSadd, iCond).sic(2) - xFondaData(iSadd, iCond).Press) * xFondaData(iSadd, iCond).Coef(2) + xFondaData(iSadd, iCond).Press
            xFondaData(iSadd, iCond).sipc(1) = beta * Press * xFondaItem(iSadd).B1 ^ 2 / xFondaItem(iSadd).SP ^ 2
            'sipc1 = xFondaData(iSadd,iCond).Coef(k) * 6 / 12 * Press * xFondaItem(iSadd).B1 ^ 2 / xFondaItem(iSadd).sp ^ 2
            'If sipc1 > xFondaData(iSadd, iCond).sipc(1) Then xFondaData(iSadd, iCond).sipc(1) = sipc1

            rap1 = (xFondaData(iSadd, iCond).sh(1) ^ 2 + xFondaData(iSadd, iCond).sh(2) ^ 2) / xFondaData(iSadd, iCond).albs ^ 2
            rap2 = ((xFondaData(iSadd, iCond).si(1) + xFondaData(iSadd, iCond).si(2)) / xFondaData(iSadd, iCond).alb) ^ 2
            xFondaData(iSadd, iCond).rap = System.Math.Sqrt(rap1 + rap2)
            For i = 1 To 6
                DoveEccede(iSadd, i, iCond) = ""
            Next i
            Factor = Press / xFondaData(iSadd, iCond).alc
            If Factor > 1 Then
                DoveEccede(iSadd, 1, iCond) = "(*)"
            End If
            Facto1 = xFondaData(iSadd, iCond).sipc(1) / (xFondaData(iSadd, iCond).albp * 1.5)
            If Facto1 > Factor Then Factor = Facto1
            If Facto1 > 1 Then
                DoveEccede(iSadd, 2, iCond) = "(*)"
            End If
            Facto1 = (xFondaData(iSadd, iCond).sipb(1) + xFondaData(iSadd, iCond).sipb(2)) / (xFondaData(iSadd, iCond).albp * 1.5)
            If Facto1 > Factor Then Factor = Facto1
            If Facto1 > 1 Then
                DoveEccede(iSadd, 3, iCond) = "(*)"
            End If
            Facto1 = (xFondaData(iSadd, iCond).si(1) + xFondaData(iSadd, iCond).si(2)) / xFondaData(iSadd, iCond).alb
            If Facto1 > Factor Then Factor = Facto1
            If Facto1 > 1 Then
                DoveEccede(iSadd, 4, iCond) = "(*)"
            End If
            Facto1 = System.Math.Sqrt(xFondaData(iSadd, iCond).sh(1) ^ 2 + xFondaData(iSadd, iCond).sh(2) ^ 2) / xFondaData(iSadd, iCond).albs
            If Facto1 > Factor Then Factor = Facto1
            If Facto1 > 1 Then
                DoveEccede(iSadd, 5, iCond) = "(*)"
            End If
            Facto1 = xFondaData(iSadd, iCond).rap
            If Facto1 > Factor Then Factor = Facto1
            If Facto1 > 1 Then
                DoveEccede(iSadd, 6, iCond) = "(*)"
            End If
            NonAccettabile = 0
            For i = 1 To 6
                If DoveEccede(iSadd, i, iCond) = "(*)" Then NonAccettabile = 1
            Next i
            If NonAccettabile = 0 Then
                FinalComment(iCond, iSadd) = "Acceptable stresses."
                CommentoFinale = "Sforzi accettabili."
            Else
                FinalComment(iCond, iSadd) = "(*) : LIMIT EXCEEDED. NOT ACCEPTABLE STRESSES"
                CommentoFinale = "LIMITE SUPERATO. SFORZO NON ACCETTABILE !!!"
            End If
            xFondaData(iSadd, iCond).Pressb = Press
            RisultatiAVideo(Msgg, CommentoFinale, Press, NonAccettabile)
        Catch e As Exception
            If NonVaBene = 0 Then
                MsgBox(e.Message + vbCrLf + e.StackTrace)
            Else
                Msgg = "L'asse neutro esce dalla piastra di base" & vbCrLf
                Msgg = Msgg & "Aumentare la larghezza della piastra di base.  "
                MsgBox(Msgg, MsgBoxStyle.Exclamation)
            End If
        End Try
    End Sub
    Private Sub RisultatiAVideo(ByVal Msgg As String, ByVal CommentoFinale As String, ByVal Press As Single, ByVal NonAccettabile As Short)
        Dim t As TabPage
        Dim l As Label
        If Len(RTrim(Problem.LoadCond(3, iCond + 1))) = 0 Then Problem.LoadCond(3, iCond + 1) = "Senza Nome"
        Msgg = "---- RISULTATI -----Condizione: " & RTrim(Problem.LoadCond(3, iCond + 1)) & "----Sella n°:" & Str(iSadd) & vbCrLf
        Msgg = Msgg & ("Posizione dell'asse neutro          Yn=  " & GlobalRoutines.FormatS("#####.0", xFondaData(iSadd, iCond).X(1)) & " [mm]").PadRight(60) & "." & vbCrLf
        Msgg = Msgg & ("Posizione dell'asse neutro          Xn=  " & GlobalRoutines.FormatS("#####.0", xFondaData(iSadd, iCond).X(2)) & " [mm]").PadRight(60) & "." & vbCrLf
        Msgg = Msgg & ("Eccentricità della pressoflessione  Ye=  " & GlobalRoutines.FormatS("#####.0", xFondaData(iSadd, iCond).E(1)) & " [mm]").PadRight(60) & "." & vbCrLf
        Msgg = Msgg & ("Eccentricità della pressoflessione  Xe=  " & GlobalRoutines.FormatS("#####.0", xFondaData(iSadd, iCond).E(2)) & " [mm]").PadRight(60) & "." & vbCrLf
        Msgg = Msgg & ("Max compressione calcestruzzo     " & GlobalRoutines.FormatS("#####.0", Press) & " < " & GlobalRoutines.FormatS("#####.0", xFondaData(iSadd, iCond).alc) & " [MPa] " & DoveEccede(iSadd, 1, iCond)).PadRight(60) & "." & vbCrLf
        Msgg = Msgg & ("Sforzo piastra base (compr.cem.)  " & GlobalRoutines.FormatS("#####.0", xFondaData(iSadd, iCond).sipc(1)) & " < " & GlobalRoutines.FormatS("#####.0", xFondaData(iSadd, iCond).albp * 1.5) & " [MPa] " & DoveEccede(iSadd, 2, iCond)).PadRight(60) & "." & vbCrLf
        Msgg = Msgg & ("Sforzo piastra base (traz.bull.)  " & GlobalRoutines.FormatS("#####.0", xFondaData(iSadd, iCond).sipb(1) + xFondaData(iSadd, iCond).sipb(2)) & " < " & GlobalRoutines.FormatS("#####.0", xFondaData(iSadd, iCond).albp * 1.5) & " [MPa] " & DoveEccede(iSadd, 3, iCond)).PadRight(60) & "." & vbCrLf
        Msgg = Msgg & ("Sforzo trazione bulloni           " & GlobalRoutines.FormatS("#####.0", xFondaData(iSadd, iCond).si(1) + xFondaData(iSadd, iCond).si(2)) & " < " & GlobalRoutines.FormatS("#####.0", xFondaData(iSadd, iCond).alb) & " [MPa] " & DoveEccede(iSadd, 4, iCond)).PadRight(60) & "." & vbCrLf
        Msgg = Msgg & ("Sforzo taglio bulloni             " & GlobalRoutines.FormatS("#####.0", System.Math.Sqrt(xFondaData(iSadd, iCond).sh(1) ^ 2 + xFondaData(iSadd, iCond).sh(2) ^ 2)) & " < " & GlobalRoutines.FormatS("#####.0", xFondaData(iSadd, iCond).albs) & " [MPa] " & DoveEccede(iSadd, 5, iCond)).PadRight(60) & "." & vbCrLf
        Msgg = Msgg & ("Fattore d'uso del bullone         " & GlobalRoutines.FormatS("###.000", xFondaData(iSadd, iCond).rap) & "  <  1.0 " & DoveEccede(iSadd, 6, iCond)).PadRight(60) & "." & vbCrLf
        If NonAccettabile = 1 Then
            Msgg = Msgg & "(*) :" & CommentoFinale
        Else
            Msgg = Msgg & CommentoFinale
        End If
        Try
            With Form3
                If iCond > 0 And iSadd = 1 Then
                    t = New TabPage("Cond." + (iCond + 1).ToString)
                    l = New Label
                    l.Height = .Labelup1.Height
                    l.Width = .Labelup1.Width
                    l.Top = .Labelup1.Top
                    l.Left = .Labelup1.Left
                    l.TextAlign = .Labelup1.TextAlign
                    l.BorderStyle = .Labelup1.BorderStyle
                    l.Font = .Labelup1.Font
                    t.Controls.Add(l)
                    l = New Label
                    l.Height = .Labeldo1.Height
                    l.Width = .Labeldo1.Width
                    l.Top = .Labeldo1.Top
                    l.Left = .Labeldo1.Left
                    l.TextAlign = .Labeldo1.TextAlign
                    l.BorderStyle = .Labeldo1.BorderStyle
                    l.Font = .Labeldo1.Font
                    t.Controls.Add(l)
                    .TabControl1.TabPages.Add(t)
                End If
                t = .TabControl1.TabPages(iCond)
                If NonAccettabile = 1 Then t.Tag = "rosso" Else t.Tag = ""
                CType(t.Controls(iSadd - 1), Label).Text = Msgg
            End With
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Function ControlloDati() As Short
        Dim IndiceErrore, i As Short
        Dim Msgg As String = ""
        IndiceErrore = 0
        Try
            For i = 1 To xFondaItem(iSadd).nt
                If xFondaItem(iSadd).a / 2 <= System.Math.Abs(xFondaItem(iSadd).yQuota(i)) Then IndiceErrore = 1
                If xFondaItem(iSadd).b / 2 <= System.Math.Abs(xFondaItem(iSadd).xQuota(i)) Then IndiceErrore = 1
            Next
            If xFondaData(iSadd, iCond).n = 0 Then IndiceErrore = 2
            If xFondaData(iSadd, iCond).albs = 0 Or xFondaData(iSadd, iCond).alb = 0 Then
                xFondaData(iSadd, iCond).albs = xFondaData(iSadd, 0).albs
                xFondaData(iSadd, iCond).alb = xFondaData(iSadd, 0).alb
                If xFondaData(iSadd, iCond).albs = 0 Or xFondaData(iSadd, iCond).alb = 0 Then IndiceErrore = 3 'ammissibili bulloni nulli
            End If
            If xFondaData(iSadd, iCond).albp = 0 Then
                xFondaData(iSadd, iCond).albp = xFondaData(iSadd, 0).albp
                If xFondaData(iSadd, iCond).albp = 0 Then IndiceErrore = 4
            End If
            Select Case IndiceErrore
                Case 0 : Return 0
                Case 1
                    Msgg = Helpstringa(3000 + IndiceErrore) & iSadd.ToString
                    'Msgg = "Ci sono bulloni che cadono fuori della piastra di base n° " & iSadd.ToString
                Case 2, 3, 4
                    Msgg = GlobalRoutines.FormatS(Helpstringa(3000 + IndiceErrore), Problem.LoadCond(3, iCond + 1), Str(iSadd))
                    '                Msgg = "Condizione: " & Problem.LoadCond(3, iCond + 1) & " Sella n°" & Str(iSadd) & vbCrLf
                    'Msgg = Msgg & "I dati di carico sono incompleti."
            End Select
            MostraAiuto(3000 + IndiceErrore, ChiaviMess.MessExclamation Or ChiaviMess.MessOkOnly, Msgg)
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
        Return IndiceErrore
    End Function
    Public Sub LeggiRoark()
        'caso 10a pag.397
        Dim j, i, ifl As Short
        ifl = FreeFile()
        FileOpen(ifl, RTrim(Monitor.Motore.Inizio.Archdir) & "\ROARK.DAT", OpenMode.Input, , OpenShare.Shared)
        For i = 1 To 4
            For j = 0 To 9
                Input(ifl, TabRoark(i, j))
            Next j
        Next i
        'Data 0.25, 0.5, 0.75, 1, 1.5, 2, 3
        'Data 0.02, 0.081, 0.173, 0.321, 0.727, 1.226, 2.105
        'Data 0.016, 0.066, 0.148, 0.259, 0.484, 0.605, 0.519
        'Data 0.031, 0.126, 0.286, 0.511, 1.073, 1.568, 1.982
        FileClose(ifl)
    End Sub
    Public Sub StampaFonda()
        Dim ifl, i As Short
        Dim Par, Riga As String
        Par = "\par "
        Call StLoadC(3)
        If iSadd = 1 Then
            Monitor.Motore.Problem.Printa("------ INPUT DATA FOR FIXED SADDLE --------------------------------------- " & Par)
        Else
            Monitor.Motore.Problem.Printa("------ INPUT DATA FOR SLIDING SADDLE ------------------------------------- " & Par)
        End If
        ifl = FreeFile()
        FileOpen(ifl, RTrim(Monitor.Motore.Inizio.Archdir) & "\WR\FIGFON.SDD", OpenMode.Input, , OpenShare.Shared)
        Do
            Riga = LineInput(ifl)
            If InStr(Riga, "fine") Then Exit Do
            Monitor.Motore.Problem.Printa(Riga)
        Loop
        FileClose(ifl)
        With Monitor.Motore.Problem
            .Printa("\pard \s15\qj\widctlpar\tx4250\tqr\tx5600\tql\tx5900\tx7000 ")
            .Printa("Bolt size                            \tab = \tab " & xFondaItem(iSadd).BoltSize & Par)
            .Printa("Bolt material                        \tab = \tab " & xFondaItem(iSadd).BoltMat & Par)
            .Printa("Base plate material                  \tab = \tab " & xFondaItem(iSadd).BaseMat & Par & Par)
            .Printa("Base plate lenght                  A \tab = \tab " & GlobalRoutines.FormatS("#######0.0", xFondaItem(iSadd).a) & "\tab [mm]" & Par)
            .Printa("Base plate width                   B \tab = \tab " & GlobalRoutines.FormatS("#######0.0", xFondaItem(iSadd).b) & "\tab [mm]" & Par)
            .Printa("Base plate thickness               t \tab = \tab " & GlobalRoutines.FormatS("#######0.0", xFondaItem(iSadd).SP) & "\tab [mm]" & Par)
            .Printa("Number of bolts                    n{\sub t} \tab = \tab " & GlobalRoutines.FormatS("#######0", xFondaItem(iSadd).nt) & Par)
            .Printa("Bolt root area                     A{\sub r} \tab = \tab " & GlobalRoutines.FormatS("#######0.0", xFondaItem(iSadd).an) & "\tab [mm{\super 2}]" & Par)
            .Printa("\pard \s15\qj\widctlpar\tqr\tx3640\tx5040 ")
            If xFondaItem(iSadd).Inchiavard Then
                .Printa("   {\b Note:} The sliding saddle shall be designed to be locked against lifting forces \par          due to lateral actions imposed to the equipment" & Par)
            End If
            .Printa("Bolt positions\tab x\tab y" & Par)
            For i = 1 To xFondaItem(iSadd).nt
                .Printa("\tab " & GlobalRoutines.FormatS("####0", xFondaItem(iSadd).xQuota(i)))
                .Printa("\tab " & GlobalRoutines.FormatS("####0", xFondaItem(iSadd).yQuota(i)) & Par)
            Next
            .Printa("\pard \s15\qj\widctlpar\tx4250\tqr\tx5600\tql\tx5900\tx7000 ")
            .Printa("Longitudinal base plate span        b \tab =\tab " & GlobalRoutines.FormatS("#######0.0", xFondaItem(iSadd).B1) & "\tab [mm]" & " (relative to eq.nt axis)" & Par)
            .Printa("Transversal base plate span         a \tab =\tab " & GlobalRoutines.FormatS("#######0.0", xFondaItem(iSadd).A1) & "\tab [mm]" & " (relative to eq.nt axis)" & Par)
            .Printa("Number of fixed edges of the span   n{\sub f} \tab =\tab " & GlobalRoutines.FormatS("#######0", xFondaItem(iSadd).nc) & Par)
            .Printa("Allow.bearing stress in concr.      {{\field{\*\fldinst SYMBOL 115 \\f ""Symbol"" \\s 9}{\fldrslt\f1\fs18}}}{\sub call} \tab =\tab " & GlobalRoutines.FormatS("#######0.0", xFondaData(iSadd, iCond).alc) & "\tab [MPa] " & Par)
            .Printa("Allow.tensile stress in bolts       {{\field{\*\fldinst SYMBOL 115 \\f ""Symbol"" \\s 9}{\fldrslt\f1\fs18}}}{\sub ball} \tab =\tab " & GlobalRoutines.FormatS("#######0.0", xFondaData(iSadd, iCond).alb) & "\tab [MPa] " & Par)
            .Printa("Allow.shear stress in bolts         {{\field{\*\fldinst SYMBOL 116 \\f ""Symbol"" \\s 9}{\fldrslt\f1\fs18}}}{\sub ball} \tab =\tab " & GlobalRoutines.FormatS("#######0.0", xFondaData(iSadd, iCond).albs) & "\tab [MPa] " & Par)
            .Printa("Allow.stress in the base plate      {{\field{\*\fldinst SYMBOL 115 \\f ""Symbol"" \\s 9}{\fldrslt\f1\fs18}}}{\sub pall} \tab =\tab " & GlobalRoutines.FormatS("#######0.0", xFondaData(iSadd, iCond).albp) & "\tab [MPa] " & Par)
            .Printa("Young Modulus ratio                 m \tab = \tab " & GlobalRoutines.FormatS("#######0.0", xFondaItem(iSadd).Rm) & Par)
            .Printa("Vertical force                      N \tab = \tab " & GlobalRoutines.FormatS("#######0.0", xFondaData(iSadd, iCond).n) & "\tab [N]" & Par)
            .Printa("Shear force                         T{\sub x} \tab =\tab " & GlobalRoutines.FormatS("#######0.0", xFondaData(iSadd, iCond).sfx) & "\tab [N]" & Par)
            .Printa("Shear force                         T{\sub y} \tab =\tab " & GlobalRoutines.FormatS("#######0.0", xFondaData(iSadd, iCond).sfy) & "\tab [N]" & Par)
            .Printa("Bending moment                      M{\sub x} \tab =\tab " & GlobalRoutines.FormatS("#######0.0", xFondaData(iSadd, iCond).mx) & "\tab [Nm]" & Par)
            .Printa("Bending moment                      M{\sub y} \tab =\tab " & GlobalRoutines.FormatS("#######0.0", xFondaData(iSadd, iCond).my) & "\tab [Nm]" & Par & Par)
            .Printa("---- RESULTS -----------------------------------------------------------------  " & Par & Par)
            .Printa("Neutral axis position               x{\sub n} \tab =\tab " & GlobalRoutines.FormatS("####0.0", xFondaData(iSadd, iCond).X(1)) & "\tab [mm] (counted from compressed edge)" & Par)
            .Printa("Neutral axis position               y{\sub n} \tab =\tab " & GlobalRoutines.FormatS("####0.0", xFondaData(iSadd, iCond).X(2)) & "\tab [mm] (counted from compressed edge)" & Par)
            .Printa("External loads excentricity         e{\sub x} \tab =\tab " & GlobalRoutines.FormatS("####0.0", xFondaData(iSadd, iCond).E(1)) & "\tab [mm]" & Par)
            .Printa("External loads excentricity         e{\sub y} \tab =\tab " & GlobalRoutines.FormatS("####0.0", xFondaData(iSadd, iCond).E(2)) & "\tab [mm]" & Par)
            .Printa("Factor from Roark Table 26,10a      {{\field{\*\fldinst SYMBOL 98 \\f ""Symbol"" \\s 9}{\fldrslt\f1\fs18}}}\tab =\tab " & GlobalRoutines.FormatS("##.0000", xFondaData(iSadd, iCond).beta) & Par)
            .Printa("Inhomogeneity factor                C{\sub x} \tab =\tab " & GlobalRoutines.FormatS("#0.0000", xFondaData(iSadd, iCond).Coef(1)) & "\tab [--]" & Par)
            .Printa("Inhomogeneity factor                C{\sub y} \tab =\tab " & GlobalRoutines.FormatS("#0.0000", xFondaData(iSadd, iCond).Coef(2)) & "\tab [--]" & Par & Par)
            .Printa("Bearing stress in concrete          {{\field{\*\fldinst SYMBOL 115 \\f ""Symbol"" \\s 9}{\fldrslt\f1\fs18}}}{\sub c} \tab =\tab " & GlobalRoutines.FormatS("####0.0", xFondaData(iSadd, iCond).Pressb) & "\tab [MPa] < {{\field{\*\fldinst SYMBOL 115 \\f ""Symbol"" \\s 9}{\fldrslt\f1\fs18}}}{\sub call}  " & DoveEccede(iSadd, 1, iCond) & Par)
            .Printa("Stress in plate (compr.side)       {{\field{\*\fldinst SYMBOL 115 \\f ""Symbol"" \\s 9}{\fldrslt\f1\fs18}}}{\sub bc} \tab =\tab " & GlobalRoutines.FormatS("####0.0", xFondaData(iSadd, iCond).sipc(1)) & "\tab [MPa] < 1.5*{{\field{\*\fldinst SYMBOL 115 \\f ""Symbol"" \\s 9}{\fldrslt\f1\fs18}}}{\sub pall}  " & DoveEccede(iSadd, 2, iCond) & Par)
            .Printa("Stress in plate (tens.side)        {{\field{\*\fldinst SYMBOL 115 \\f ""Symbol"" \\s 9}{\fldrslt\f1\fs18}}}{\sub bt} \tab =\tab " & GlobalRoutines.FormatS("####0.0", xFondaData(iSadd, iCond).sipb(1) + xFondaData(iSadd, iCond).sipb(2)) & "\tab [MPa] < 1.5*{{\field{\*\fldinst SYMBOL 115 \\f ""Symbol"" \\s 9}{\fldrslt\f1\fs18}}}{\sub pall}  " & DoveEccede(iSadd, 3, iCond) & Par)
            .Printa("Tensile stress in bolts             {{\field{\*\fldinst SYMBOL 115 \\f ""Symbol"" \\s 9}{\fldrslt\f1\fs18}}}{\sub b} \tab =\tab " & GlobalRoutines.FormatS("####0.0", xFondaData(iSadd, iCond).si(1) + xFondaData(iSadd, iCond).si(2)) & "\tab [MPa] < {{\field{\*\fldinst SYMBOL 115 \\f ""Symbol"" \\s 9}{\fldrslt\f1\fs18}}}{\sub ball}  " & DoveEccede(iSadd, 4, iCond) & Par)
            .Printa("Shear stress in bolts               {{\field{\*\fldinst SYMBOL 116 \\f ""Symbol"" \\s 9}{\fldrslt\f1\fs18}}}{\sub b} \tab =\tab " & GlobalRoutines.FormatS("####0.0", System.Math.Sqrt(xFondaData(iSadd, iCond).sh(1) ^ 2 + xFondaData(iSadd, iCond).sh(2) ^ 2)) & "\tab [MPa] < {{\field{\*\fldinst SYMBOL 116 \\f ""Symbol"" \\s 9}{\fldrslt\f1\fs18}}}{\sub ball}  " & DoveEccede(iSadd, 5, iCond) & Par)
            .Printa("Usage factor of bolts               r =" & GlobalRoutines.FormatS("#0.000", xFondaData(iSadd, iCond).rap) & "  < 1" & DoveEccede(iSadd, 6, iCond) & Par & Par)
            .Printa(FinalComment(iCond, iSadd) & Par)
        End With
        'LPRINT TAB(6)+ "EXPLANATION OF RESULTS :"
        'LPRINT
        'LPRINT TAB(6); "The neutral axis position xFondaData(iSadd,iCond).X is referred to base plate compressed edge."
        'LPRINT TAB(6); "If xFondaData(iSadd,iCond).X = base plate width, then no tension arises on bolts and all the"
        'LPRINT TAB(6); "base plate is subject to compression."
        'LPRINT TAB(6); "The neutral axis position xFondaData(iSadd,iCond).X is calculated solving the following equation:"
        'LPRINT TAB(6); "xFondaData(iSadd,iCond).X^3+3*(xFondaData(iSadd,iCond).e-xFondaItem(iSadd).b/2)*xFondaData(iSadd,iCond).X^2 + 6 * xFondaData(iSadd,iCond).m * Af / xFondaItem(iSadd).a * xFondaData(iSadd,iCond).d * xFondaData(iSadd,iCond).X - 6 * xFondaData(iSadd,iCond).m * Af / xFondaItem(iSadd).a * xFondaData(iSadd,iCond).d * xFondaItem(iSadd).h = 0 "
        'LPRINT TAB(6); "Besides the symbols defined in the calculation sheet we have :"
        'LPRINT TAB(6); "xFondaData(iSadd,iCond).e = xFondaData(iSadd,iCond).m/xFondaData(iSadd,iCond).n"
        'LPRINT TAB(6); "xFondaData(iSadd,iCond).d = e+h-xFondaItem(iSadd).b/2"
        'LPRINT TAB(6); "Af = xFondaData(iSadd,iCond).n*Ar"
        'LPRINT
        'LPRINT TAB(6); "Stress in base plate (compressed side) åbc :"
        'LPRINT TAB(6); "This is the stress due to bending moment in base plate arising from "
        'LPRINT TAB(6); "compressive reaction . "
        'LPRINT TAB(6); "Base plate is considered either as xFondaItem(iSadd).a beam clamped or as plate clamped"
        'LPRINT TAB(6); "on three edge and free on the fourth, whichever is the worst"
        'LPRINT
        'LPRINT TAB(6); "Stress in base plate (tensile side) åbt :"
        'LPRINT TAB(6); "This is the stress due to bending moment in base plate arising from "
        'LPRINT TAB(6); "tensile reaction (if any) on bolts . "
        'LPRINT TAB(6); "Base plate is considered as xFondaItem(iSadd).a cantilever beam clamped at the  "
        'LPRINT TAB(6); "rib . For verification we consider xFondaItem(iSadd).a distribution of the load"
        'LPRINT TAB(6); "on bolt at 45ø "

    End Sub
End Module