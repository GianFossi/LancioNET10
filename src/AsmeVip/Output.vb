Option Strict Off
Option Explicit On 
Imports Grafica
Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary
Imports RoutBase1
Module Output
    Private jPiastra As Short
    Private PiastraSU As Object
    Private SuChi As clsGenMem
    Private Noz As Grafica.clsBocch
    Private Strin1(50) As String
    Private nposs As Short
    Private Aiuto As String
    Private Candidati As Collection
    Private NearFar As Collection
    Private Dinst, DBul As Single
    Private Guarn As Grafica.clsGuarniz
    Private Stringa(4) As String
    Private IndPad, IndNoz, IndFla As Short
    Private Genmem As Grafica.clsGenMem
    Private Ris As Short
    Private O, O1 As Object
    Private NonPrimoGiro, continua, SecondaPiastra As Boolean
    Private PT As Grafica.Piastrone
    Private Cercanome As clsCercaNome
    Private Piastra As wn_PT
    Private jCV As Short
    Private FlangCh As Grafica.Flangione
    Private BullDistinti As Boolean
    Function ApriLeggiU() As Boolean
        Dim mode As Short
        Dim junk As DialogResult
        Dim Res As Short
        Dim Ext As String
        ApriLeggiU = True
        If AddDistinta > 0 Then 'calcolo chiamato da PPSM su una particolare membratura
            clsProblem.nonSciolto = True
            mode = 0
            icome = clsInizio.Workdir.Trim & "\" & RTrim(job.Comm.Arch) & Chr(92) & job.Comm.Ind.Item(job.Comm.indice).Data.File & Monitor.Motore.Problem.Extension
            'c'era + Suffix
            If IO.File.Exists(icome) Then
                Call Design(junk, False)
            Else
                junk = DialogResult.No
            End If
            If junk = DialogResult.No Then Exit Function
            Res = DomandeU()
            ApriLeggiU = Res
            If Not Res Then Exit Function
            TransWND()
            If Apparecchio.NumeroLati = 0 Then
                ApriLeggiU = False
                Exit Function
            End If
            For kLato = 1 To Config(0).NumeroLati
                Call CarichiU(junk)
            Next
            'AggDatiGenerali
            ' Mode = 1: GoSub TransWND
            ' GoSub Apice
            '-------------------------------------------------------------------
        Else 'calcolo stand-alone
            clsProblem.nonSciolto = False
            Ext = "VIP"
            icome = ""
            Call CaricaFile(icome, Ext)
        End If
        Exit Function
        '--------------------------------------------------
        'TransWND:
        '   For i = 1 To JRECMAX: Record(i).Ind = 0: Record(i).Tipo = 0: Next
        '   jmemb = 1: jRecLoc = 0: jmembh = 1
        '120 Call CercaWND(0, Suffix): Involucr(kLato, jmembh).Suffix = Suffix$
        '   Select Case Record(0).Tipo
        '      Case 1, -1       'cilindri
        '         Involucr(kLato, jmemb).indice(1) = 0
        '         Involucr(kLato, jmemb).indice(2) = -1
        '         If Config(kLato).di = 0 Then Config(kLato).di = Involucr(kLato, jmemb).di
        '         If Config(kLato).TNS = 0 Then Config(kLato).TNS = Involucr(kLato, jmemb).Spess
        '         GoSub CilInFila
        '         kFC = 1: GoSub SuperFonCil
        '         kFC = 1: GoSub SuperConCil
        '         kFC = 1: GoSub SuperBelCil
        '         kFC = 1: GoSub SuperDilCil
        '      Case 36 'Belts
        '         Testo = " Si deve calcolare l'involucro su cui| il belt è posizionato.        |"
        '               messagebox.show clsInizio.ConvertiCr(Testo), vbOKOnly + vbInformation
        '               Exit Function
        '      Case 3, 4, 5, 6, 7 'fondi
        '         Involucr(kLato, jmembh).indice(1) = 0
        '130      kCF = 1: GoSub CercaCilFon
        '         If Rec2Buf(1).Ind > 0 Then
        '            jRecLoc = jRecLoc + 1: jmemb = jmembh + 1
        '            Record(jRecLoc) = Rec2Buf(1)
        '            Involucr(kLato, jmemb).indice(1) = jRecLoc
        '            Involucr(kLato, jmemb).indice(2) = -1
        '140         GoSub CilInFila
        '            jRecAct = jRecLoc 'per il futuro
        ''            jRecLoc = 0
        '            Involucr(kLato, jmembh).indice(1) = 0
        '            Involucr(kLato, jmembh).indice(2) = -1
        '            Select Case Record(0).Tipo
        '               Case 3, 4, 5: GoSub ValoriFon
        '               Case 6, 7: GoSub ValoriCon
        '            End Select
        '143         InvSWAP Involucr(kLato, jmemb), Involucr(kLato, jmembh)
        '         Else
        '            jRecAct = jRecLoc
        '         End If
        '      Case Else
        '   End Select
        'jnozz = 0: jRecLoc = jRecAct
        'For ik = 1 To jmemb
        '' IF Involucr(kLato,ik).Tipo = 4 THEN GOTO ContBocch
        ' If ik = 1 Then
        '    Involucr(kLato, ik).inizio = 1
        '    Involucr(kLato, ik).Fine = 0
        ' Else
        '    If Involucr(kLato, ik - 1).Fine >= Involucr(kLato, ik - 1).inizio Then
        '       Involucr(kLato, ik).inizio = Involucr(kLato, ik - 1).Fine + 1
        '       Involucr(kLato, ik).Fine = Involucr(kLato, ik).inizio - 1
        '    Else
        '       Involucr(kLato, ik).inizio = Involucr(kLato, ik - 1).inizio
        '       Involucr(kLato, ik).Fine = Involucr(kLato, ik).inizio - 1
        '    End If
        ' End If
        ' For k = 1 To Lav(0).Ind(Lav(0).NumAs)
        '         Get #IUNA, k, Rec2Buf(1)
        '         If EOF(IUNA) Or Rec2Buf(1).Ind = 0 Then Exit For
        '         If Rec2Buf(1).Tipo = 10 Or Rec2Buf(1).Tipo = 14 Then
        '150         For ll = 1 To 5
        '              l = Involucr(kLato, ik).indice(ll)
        '              If l < 0 Then Exit For
        '              Log1 = (Rec2Buf(1).posspa.SuChi = Record(l).Ind)
        '              Log2 = (Record(l).posspa.SuChi = Rec2Buf(1).Ind)
        '              If Log1 Or Log2 Then
        '                 If UBound(Nozzles, 2) = jnozz Then ReDim Preserve Nozzles(1 To 4, 1 To 2 * jnozz) As Nozzle, NozzAdd(1 To 4, 1 To 2 * jnozz) As NozzAd
        '                 jnozz = jnozz + 1
        '                 If Involucr(kLato, ik).Fine < Involucr(kLato, ik).inizio Then
        '                    Involucr(kLato, ik).Fine = Involucr(kLato, ik).inizio
        '                 Else
        '                    Involucr(kLato, ik).Fine = Involucr(kLato, ik).Fine + 1
        '                 End If
        '                 Nozzles(kLato, jnozz).InvolucroSU = ik
        '160              jRecLoc = jRecLoc + 1
        '                 If UBound(Record) = jRecLoc Then
        '                     ReDim Preserve Record(2 * jRecLoc) As RecAPRn
        '                     ReDim Preserve Matdim(2 * jRecLoc) As LibMat.Materiale
        '                 End If
        '                 Record(jRecLoc) = Rec2Buf(1)
        '                 Nozzles(kLato, jnozz).indice = jRecLoc
        '              End If
        '            Next
        '         End If
        ' Next k
        'ContBocch:
        'Next ik
        'For ik = 1 To jnozz
        ' If ik = 1 Then
        '    Nozzles(ik).inizio = jnozz
        ' Else
        '    Nozzles(ik).inizio = Nozzles(ik - 1).Fine
        '    If Nozzles(ik - 1).Fine < Nozzles(ik - 1).inizio Then Nozzles(ik).inizio = Nozzles(ik - 1).inizio
        ' End If
        ' Nozzles(ik).Fine = Nozzles(ik).inizio - 1
        ''         GET #IUNA, Nozzles(ik).indice, Rec2Buf(1)
        '         Rec2Buf(1) = Record(Nozzles(ik).indice)
        '            For ll = 1 To Lav(0).Ind(Lav(0).NumAs)
        '              Get #IUNA, ll, Rec2Buf(3)
        '              If EOF(IUNA) Or Rec2Buf(1).Ind = 0 Then Exit For
        '              Log2 = (Rec2Buf(3).posspa.SuChi = Rec2Buf(1).Ind)
        '              Log3 = (Rec2Buf(3).Tipo = 10 Or Rec2Buf(3).Tipo = 14)
        '              Log4 = Rec2Buf(1).Ind <> Rec2Buf(3).Ind
        '              If Log2 And Log3 And Log4 Then
        '                 If UBound(Nozzles) = jnozz Then ReDim Preserve Nozzles(1 To 2 * jnozz) As Nozzle, NozzAdd(1 To 2 * jnozz) As NozzAdN
        '                 jnozz = jnozz + 1
        '                 If Nozzles(ik).Fine < Nozzles(ik).inizio Then
        '                    Nozzles(ik).inizio = Nozzles(ik).inizio + 1
        '                    Nozzles(ik).Fine = Nozzles(ik).inizio
        '                 Else
        '                    Nozzles(ik).Fine = Nozzles(ik).Fine + 1
        '                 End If
        '                 Nozzles(kLato, jnozz).InvolucroSU = -ik
        '165              jRecLoc = jRecLoc + 1
        '                 If UBound(Record) = jRecLoc Then
        '                     ReDim Preserve Record(2 * jRecLoc) As RecAPRn
        '                     ReDim Preserve Matdim(2 * jRecLoc) As LibMat.Materiale
        '                 End If
        '                 Record(jRecLoc) = Rec2Buf(3)
        '                 Nozzles(kLato, jnozz).indice = jRecLoc
        '              End If
        '            Next
        'Next ik
        'iRecmemb = 0
        'For k = 1 To jmemb
        '   For l = 1 To 5
        '166   iRecmemb1 = Involucr(kLato, k).indice(l)
        '      If iRecmemb1 > iRecmemb Then iRecmemb = iRecmemb1
        '   Next
        'Next k
        'Config(kLato).Ninvolucri = jmemb
        'For k = 1 To jnozz
        '168   GoSub LeggiRecBoc
        'Next
        'Return
        'LeggiRecBoc:
        '   iRec = iRecmemb + k
        '   If Nozzles(k).InvolucroSU > 0 Then
        '      TNV = Involucr(Nozzles(k).InvolucroSU).Spess
        '  Else
        '      TNV = Nozzles(-Nozzles(k).InvolucroSU).Spess
        '   End If
        '   Rec2Buf(1) = Record(Nozzles(k).indice)
        '   Nozzles(k).Mark = RTrim$(Rec2Buf(1).Denom) + " Pos." + Str$(Rec2Buf(1).PosDis)
        '   jRec = iRec
        '   Matdim(jRec).RecupMat clsInizio.ArchDir
        '   Nozzles(k).MATE = Matdim(iRec).MatStr
        '   Nozzles(k).RecInd = Matdim(iRec).Indmat
        '   If Rec2Buf(1).Tipo = 10 Then
        '141   Call LookTipoBocch(Rec2Buf(1).Dati(), Look, False)
        '      Nozzles(k).indiceF = Look.TabFlan
        '      If Look.TabFlan > 0 Then GoSub RegisNstd        '?
        'jump:
        '      If Nozzles(k).LXdisp = 0 Then
        '         Select Case Look.K3
        '             Case 1, 2, 3: Nozzles(k).LXdisp = Look.ALTBOC - TNV - Look.y
        '             Case 4:       Nozzles(k).LXdisp = Look.ALTBOC - TNV - Look.c
        '         End Select
        '      End If
        '      If Nozzles(k).LXdisp < 0 Then Nozzles(k).LXdisp = 0
        '      If Look.TipoV > 4 Then
        '           Nozzles(k).Tipo = "Sola"
        '      Else
        '        Select Case Look.K3
        '           Case 1, 2 'WN
        '142        GoSub CercaTronch
        '           If Look.junk3 = 2 Then
        '              Nozzles(k).Tipo = "WN1 "
        '144           GoSub CercaPad
        '              GoSub UW161
        '           Else
        '              Nozzles(k).Tipo = "WN  "
        '              GoSub UW16
        '           End If
        '           GoSub RegRat
        '           Case 3, 5: messagebox.show "Errore Bocchello in ApriLeggiU"
        ''          CASE 2: 'SlipOn
        ''             Nozzles(k).Tipo = "SO  "
        '              GoSub UW16
        '           Case 4: 'LWN
        '              Nozzles(k).DiOn = Look.Adim
        '              Nozzles(k).DiIn = Look.b
        '              Nozzles(k).Spess = (Look.Adim - Look.b) / 2
        '              If Look.junk3 = 2 Then
        '                 Nozzles(k).Tipo = "WN1 "
        '                 GoSub CercaPad
        '                 GoSub UW161
        '              ElseIf Look.junk2 = 2 Then
        '                 Nozzles(k).Tipo = "LWN1"
        '                 Nozzles(k).LX = Look.HRINF - TNV
        '                 Nozzles(k).HX = (Look.DRINF - Nozzles(k).DiIn) / 2
        '                 If Abs(Nozzles(k).HX) < 1 Then
        '                    Nozzles(k).Tipo = "LWN "
        '                    GoSub UW16
        '                 Else
        '                    GoSub UW162
        '                 End If
        '              ElseIf Look.junk1 = 2 Then
        '                 Nozzles(k).Tipo = "LWN2"
        '                 Nozzles(k).PadT = Look.TSCAR
        '                 Nozzles(k).Padd = Look.DSCAR
        '                 GoSub UW163
        '              End If
        '              GoSub RegRat
        '           End Select
        '      End If
        '      Nozzles(k).DiaN = "??" 'Val(C1Fl$(Look.K1))
        '   Else              'rec2Buf(1).Tipo=14
        '      GoSub RegisNstd
        '      Get #IUNA, Rec2Buf(1).Ind + 1, Rec2Buf(2)
        '147   Call LookTipoNStd(Rec2Buf(1).Dati(), Rec2Buf(2).Dati(), Look)
        '      'da registrare TabFlan e K1,K2,K3 ?
        '      If Look.junk2 < 2 Then
        '         messagebox.show "perché‚ non c'é autorinforzo?"
        '      Else
        '         Nozzles(k).LXdisp = Look.ALTBOC - TNV
        '         If Nozzles(k).LXdisp < 0 Then Nozzles(k).LXdisp = 0
        '         Nozzles(k).Tipo = "LWN1"
        '         Nozzles(k).LX = Look.HRINF - TNV
        '         Nozzles(k).HX = (Look.DRINF - Nozzles(k).DiIn) / 2
        '      End If
        '   End If
        '      If Nozzles(k).EffN = 0 Then Nozzles(k).EffN = 1
        '      If Len(Nozzles(k).Xacc) = 0 Then Nozzles(k).Xacc = " "
        ''      Nozzles(k).LSDisp = 999 'provvisorio  !!!!!!!!!!
        'Return
        'CercaCil:
        ' For k = 1 To Lav(0).Ind(Lav(0).NumAs)
        '         Get #IUNA, k, Rec2Buf(1)
        '         If EOF(IUNA) Or Rec2Buf(1).Ind = 0 Then Exit For
        '         If Abs(Rec2Buf(1).Tipo) = 1 Then
        '            For l = jRecLoc To jRecLoc + 1 - Ncil Step -1
        '              Log1 = (Rec2Buf(1).posspa.SuChi = Record(l).Ind And Left$(Rec2Buf(1).posspa.DirDiritta, 1) = "=")
        '              Log2 = (Record(l).posspa.SuChi = Rec2Buf(1).Ind And Left$(Record(l).posspa.DirDiritta, 1) = "=")
        '              Log3 = False
        '              Log4 = (Record(l).Indmat = Rec2Buf(1).Indmat)
        '              Log5 = (Record(l).Dati(2) = Rec2Buf(1).Dati(2))
        '              Log6 = (Record(l).Dati(3) = Rec2Buf(1).Dati(3))
        '              Log7 = (Record(l).Dati(4) = Rec2Buf(1).Dati(4))
        '              For m = jRecLoc To jRecLoc + 1 - Ncil Step -1
        '                 Log3 = Log3 Or (Rec2Buf(1).Ind = Record(m).Ind)
        '              Next
        '              If (Log1 Or Log2) And Log4 And Log5 And Log6 And Log7 And Not Log3 Then Return
        '            Next
        '         End If
        ' Next
        ' Rec2Buf(1).Ind = 0
        'Return
        'CercaCilFon:
        ' For k = kCF To Lav(0).Ind(Lav(0).NumAs)
        '         Get #IUNA, k, Rec2Buf(1)
        '         If EOF(IUNA) Or Rec2Buf(1).Ind = 0 Then Exit For
        '         If Rec2Buf(1).Tipo = 1 Then
        '              Log1 = (Rec2Buf(1).posspa.SuChi = Record(jRecLoc).Ind And Left$(Rec2Buf(1).posspa.DirDiritta, 1) = "=")
        '              Log2 = (Record(jRecLoc).posspa.SuChi = Rec2Buf(1).Ind And Left$(Record(jRecLoc).posspa.DirDiritta, 1) = "=")
        '              If (Log1 Or Log2) Then kCF = k + 1: Return
        '         End If
        ' Next
        ' Rec2Buf(1).Ind = 0
        ' kCF = 1
        'Return
        'CercaFonCil:
        'iF1 = 3: iF2 = 5
        'GoSub CercaFC
        'Return
        'CercaConCil:
        'iF1 = 6: iF2 = 7
        'GoSub CercaFC
        'Return
        'CercaBelCil:
        'iF1 = 36: iF2 = 36
        'GoSub CercaFC
        'Return
        'CercaDilCil:
        'iF1 = 18: iF2 = 18
        'GoSub CercaFC
        'Return
        'CercaFC:
        ' For k = kFC To Lav(0).Ind(Lav(0).NumAs)
        '         Get #IUNA, k, Rec2Buf(1)
        '         If EOF(IUNA) Or Rec2Buf(1).Ind = 0 Then Exit For
        '         If Rec2Buf(1).Tipo >= iF1 And Rec2Buf(1).Tipo <= iF2 Then
        '500          For m = 1 To 5
        '             mm = Involucr(kLato, jmemb).indice(m)
        '             If mm > -1 Then
        '              Log1 = (Rec2Buf(1).posspa.SuChi = Record(mm).Ind And Left$(Rec2Buf(1).posspa.DirDiritta, 1) = "=")
        '              Log2 = (Record(mm).posspa.SuChi = Rec2Buf(1).Ind And Left$(Record(mm).posspa.DirDiritta, 1) = "=")
        '510           If jmembh > jmemb Then Log3 = (Rec2Buf(1).Ind = Record(Involucr(kLato, jmembh).indice(1)).Ind) Else Log3 = False
        '              If jmembh - 1 > jmemb Then Log4 = (Rec2Buf(1).Ind = Record(Involucr(kLato, jmembh - 1).indice(1)).Ind) Else Log4 = False
        '              If jmembh > jmemb Then
        '520              Get #IUNA, Rec2Buf(1).Ind + 1, Rec2Buf(2)
        '                 Log5 = ((Rec2Buf(1).Ind = Record(Involucr(kLato, jmembh).indice(1)).Ind - 1) And (Rec2Buf(2).Tipo = -1))
        '              Else
        '                 Log5 = False
        '              End If
        '              If (Log1 Or Log2) And Not Log3 And Not Log4 And Not Log5 Then kFC = k + 1: Return
        '             Else
        '              Exit For
        '             End If
        '530          Next
        '         End If
        ' Next
        ' Rec2Buf(1).Ind = 0
        ' kFC = k + 1
        'Return
        'CilInFila:
        '         Ncil = 1
        '         Involucr(kLato, jmemb).L0 = Record(jRecLoc).Dati(1)
        '         Do
        '         GoSub CercaCil
        '        If Rec2Buf(1).Ind > 0 Then
        '300         Ncil = Ncil + 1
        '            jRecLoc = jRecLoc + 1
        '320         Record(jRecLoc) = Rec2Buf(1)
        '           Involucr(kLato, jmemb).indice(Ncil) = jRecLoc
        '            Involucr(kLato, jmemb).L0 = Involucr(kLato, jmemb).L0 + Record(jRecLoc).Dati(1)
        '            If Ncil < 5 Then Involucr(kLato, jmemb).indice(Ncil + 1) = -1
        '         Else
        '            Exit Do
        '         End If
        '         Loop
        '322      GoSub ValoriCil
        'Return
        'ValoriCil:
        '         jRec = jRecLoc
        '         Involucr(kLato, jmemb).Mark = RTrim$(Record(jRec).Denom) + " Pos." + Str$(Record(jRec).PosDis)
        '324      For m = jRecLoc - 1 To jRecLoc - Ncil + 1 Step -1
        '            Involucr(kLato, jmemb).Mark = RTrim$(Involucr(kLato, jmemb).Mark) + "/" + LTrim$(Str$(Record(m).PosDis))
        '         Next
        '         Matdim(jRec).RecupMat clsInizio.ArchDir
        '         Select Case Matdim(jRec).Classe
        '               Case 1
        '                  Config(kLato).mv = 0:         Involucr(kLato, jmemb).ms = 0
        '               Case 2
        '                  Config(kLato).mv = 1:         Involucr(kLato, jmemb).ms = 0
        '               Case 6  'pipe
        '                  Config(kLato).mv = 0:         Involucr(kLato, jmemb).ms = 2
        '               Case 7  'fucinati
        '                  Config(kLato).mv = 0:         Involucr(kLato, jmemb).ms = 1
        '         End Select
        '326      Involucr(kLato, jmemb).MATE = Matdim(jRec).MatStr
        '         Involucr(kLato, jmemb).RecInd(1) = Matdim(jRec).Indmat
        '         Involucr(kLato, jmemb).di = Record(jRec).Dati(2) - 2 * Record(jRec).Dati(4)
        '         If Config(kLato).di = 0 Then Config(kLato).di = Involucr(kLato, jmemb).di
        '         Involucr(kLato, jmemb).OS = Record(jRec).Dati(4)
        '         Involucr(kLato, jmemb).Spess = Record(jRec).Dati(3) + Record(jRec).Dati(4)
        '         If Config(kLato).TNS = 0 Then Config(kLato).TNS = Involucr(kLato, jmemb).Spess
        '         If Involucr(kLato, jmemb).ES = 0 Then Involucr(kLato, jmemb).ES = 1
        '328      PosDis = 1000
        '         For m = jRecLoc To jRecLoc - Ncil + 1 Step -1
        '             If Record(m).PosDis < PosDis Then iPos = m: PosDis = Record(m).PosDis
        '         Next
        '         Involucr(kLato, jmemb).Tipo = 0
        'Return
        'ValoriBel:
        '         jRec = jRecLoc
        '         Involucr(kLato, jmembh).Mark = RTrim$(Record(jRec).Denom) + " Pos." + Str$(Record(jRec).PosDis)
        '         For m = jRecLoc - 1 To jRecLoc - Ncil + 1 Step -1
        '            Involucr(kLato, jmembh).Mark = RTrim$(Involucr(kLato, jmembh).Mark) + "/" + LTrim$(Str$(Record(m).PosDis))
        '         Next
        '         Matdim(jRec).RecupMat clsInizio.ArchDir
        '         Involucr(kLato, jmembh).MATE = Matdim(jRec).MatStr
        '         Involucr(kLato, jmembh).RecInd(1) = Matdim(jRec).Indmat
        '         Involucr(kLato, jmembh).di = Record(jRec).Dati(1)
        '         Involucr(kLato, jmembh).dns = Record(jRec).Dati(2)
        '         Involucr(kLato, jmembh).OS = 0
        '         Involucr(kLato, jmembh).L0 = Record(jRec).Dati(3)
        '         Involucr(kLato, jmembh).Spess = Record(jRec).Dati(4)
        '         Involucr(kLato, jmembh).H0 = Record(jRec).Dati(5)
        '         If Involucr(kLato, jmembh).ES = 0 Then Involucr(kLato, jmembh).ES = 1
        '         PosDis = 1000
        '         For m = jRecLoc To jRecLoc - Ncil + 1 Step -1
        '             If Record(m).PosDis < PosDis Then iPos = m: PosDis = Record(m).PosDis
        '         Next
        '         Involucr(kLato, jmembh).Tipo = 4
        'Return
        'CercaTronch:
        '   indice = Rec2Buf(1).Ind
        '   Do
        '      indice = indice + 1
        '      Get #IUNA, indice, Rec2Buf(0)
        '      If Rec2Buf(0).Tipo = -2 Then Exit Do
        '      If EOF(IUNA) Or Rec2Buf(0).Tipo > 0 Then messagebox.show "Errore tronch in ApriLeggiU"
        '   Loop
        '   Nozzles(k).DiOn = Rec2Buf(0).Dati(2)
        '   Nozzles(k).Spess = Rec2Buf(0).Dati(3)
        '   'ifl = FreeFile
        '   'Open RTrim$(Archdir) + "\material.new" For Random Shared As #ifl Len = Len(Matdim(0))
        '   'Get #ifl, Rec2Buf(0).Indmat, Matdim(iRec)
        '   'Close #ifl
        '   Nozzles(k).MATE = Matdim(iRec).MatStr
        '   Nozzles(k).RecInd = Matdim(iRec).Indmat
        'Return
        'CercaPad:
        '   indice = Rec2Buf(1).Ind
        '   Do
        '      indice = indice + 1
        '      Get #IUNA, indice, Rec2Buf(0)
        '      If Rec2Buf(0).Tipo = -17 Then Exit Do
        '      If EOF(IUNA) Or Rec2Buf(0).Tipo > 0 Then messagebox.show "Errore pad    in ApriLeggiU"
        '   Loop
        '   Nozzles(k).Padd = Rec2Buf(0).Dati(1)
        '   Nozzles(k).PadT = Rec2Buf(0).Dati(3)
        'Return
        'SuperFonCil:
        '         jmembh = jmemb
        '         Do
        '401      GoSub CercaFonCil
        '         If Rec2Buf(1).Ind > 0 Then
        '            GoSub Trovato
        ''           valori del fondo
        '            GoSub ValoriFon
        '          Else
        '            Exit Do
        '         End If
        '         Loop
        '411      jmemb = jmembh: jRecAct = jRecLoc
        'Return
        'SuperConCil:
        '         Do
        '         jmembh = jmemb
        '         jmemb = 1
        '421      GoSub CercaConCil
        '         If Rec2Buf(1).Ind > 0 Then
        '            GoSub Trovato
        ''           valori del Cono
        '425         GoSub ValoriCon
        '427         jmemb = jmembh: jRecAct = jRecLoc
        '            GoSub CercaCilSalto
        '          Else
        '            Exit Do
        '         End If
        '         Loop
        '         jmemb = jmembh
        'Return
        'CercaCilSalto:
        '         kCF = 1
        '         Do
        '         GoSub CercaCilFon  'in realt… cerca il Cil su qualsiasi jrecloc
        '         If Rec2Buf(1).Ind > 0 Then
        '            For jj = 0 To jRecLoc
        '              If Record(jj).Ind = Rec2Buf(1).Ind Then GoTo Salta
        '            Next
        '            jRecLoc = jRecLoc + 1: jmemb = jmembh + 1
        '            Record(jRecLoc) = Rec2Buf(1)
        '            Involucr(kLato, jmemb).indice(1) = jRecLoc
        '            Involucr(kLato, jmemb).indice(2) = -1
        '1400        GoSub CilInFila
        ''            jRecAct = jRecLoc'per il futuro
        ''            jRecLoc = 0
        '         Else
        '           Exit Do
        '         End If
        'Salta:   Loop
        'Return
        'SuperBelCil:
        '         jmembh = jmemb
        '         jmemb = 1
        '         Do
        '         GoSub CercaBelCil
        '         If Rec2Buf(1).Ind > 0 Then
        '            GoSub Trovato
        ''           valori del Belt
        '            GoSub ValoriBel
        '            jRecLoc = jRecLoc + 1: jmembh = jmembh + 1
        '            Get #IUNA, Record(jRecLoc - 1).Ind + 1, Rec2Buf(1)
        '            Record(jRecLoc) = Rec2Buf(1)
        '            Involucr(kLato, jmembh).indice(1) = jRecLoc
        '            Involucr(kLato, jmembh).indice(2) = -1
        '            jmembs = jmemb: jmemb = jmembh
        '            GoSub ValoriCil
        '            jmemb = jmembs
        '          Else
        '            Exit Do
        '         End If
        '         Loop
        '         jmemb = jmembh: jRecAct = jRecLoc
        'Return
        'SuperDilCil:
        '         jmembh = jmemb
        '         jmemb = 1
        '         Do
        '         GoSub CercaDilCil
        '         If Rec2Buf(1).Ind > 0 Then
        '            Get #IUNA, Rec2Buf(1).Ind + 1, Rec2Buf(2)
        '            If Rec2Buf(2).Tipo = -1 Then
        '              jRecLoc = jRecLoc + 1: jmembh = jmembh + 1
        '              Record(jRecLoc) = Rec2Buf(2)
        '              Involucr(kLato, jmembh).indice(1) = jRecLoc
        '              Involucr(kLato, jmembh).indice(2) = -1
        '              jmembs = jmemb: jmemb = jmembh
        '              GoSub ValoriCil
        '              jmemb = jmembs
        '            End If
        '            jRecAct = jRecLoc
        '            jRecLoc = jRecLoc + 1: Record(jRecLoc) = Rec2Buf(1)
        '            GoSub CercaCilSalto
        ''            FOR jj = jRecAct TO jRecLoc - 1: Record(jj) = Record(jj + 1): NEXT
        ''            jRecLoc = jRecLoc - 1
        '             jmembh = jmemb
        '         Else
        '            Exit Do
        '         End If
        '         Loop
        '         jmemb = jmembh: jRecAct = jRecLoc
        'Return
        'Trovato:
        '            jmembh = jmembh + 1
        '            jRecLoc = jRecLoc + 1
        '            Involucr(kLato, jmembh).indice(1) = jRecLoc
        '            Involucr(kLato, jmembh).indice(2) = -1
        '            Record(jRecLoc) = Rec2Buf(1)
        '            nh = 0
        'Return
        'ValoriCon:
        '            jRec = jRecLoc
        '            Matdim(jRec).RecupMat clsInizio.ArchDir
        '            Involucr(kLato, jmembh).MATE = Matdim(jRec).MatStr
        '            Involucr(kLato, jmembh).RecInd(1) = Matdim(jRec).Indmat
        '600         Call LookTipoCon(Record(jRec).Dati(), Look)
        '            If Record(jRec).Tipo = 7 Then
        ''               iALFACON = AlfaCon
        ''               Alfa! = AlfaCon * PI / 180
        ''610            Call CalcolCon(Int(Ap), Int(AP1), iALFACON, A1!, H1!)
        ''612            AlfaCon = iALFACON
        '               Involucr(kLato, jmembh).Tipo = 2
        '            ElseIf Record(jRec).Tipo = 6 Then
        ''               HCON! = H: PlfaCC! = AlfaCon
        ''               Alfa! = AlfaCon * PI / 180
        ''               Call CalOidCon(Int(Ap), Int(AP1), DM0E%, DM1E%, DMDM%, DMDM1%, HCON!, PlfaCC!)
        ''               H = HCON!: AlfaCon = PlfaCC! * 180 / PI
        '               Involucr(kLato, jmembh).Tipo = 3
        '            End If
        '614         Involucr(kLato, jmembh).Mark = RTrim$(Record(jRec).Denom) + " Pos." + Str$(Record(jRec).PosDis)
        '            Involucr(kLato, jmembh).RecInd(1) = Matdim(jRec).Indmat
        '            Involucr(kLato, jmembh).Spess = Look.T1 + Look.T2
        '            Involucr(kLato, jmembh).OS = Look.T2
        '            Involucr(kLato, jmembh).di = Look.d
        '            Involucr(kLato, jmembh).dns = Look.D1
        '            Involucr(kLato, jmembh).H0 = Look.R
        '            Involucr(kLato, jmembh).L0 = Look.R1
        '615         Involucr(kLato, jmembh).R0 = Look.AlfaCon
        'Return
        'ValoriFon:  jRec = jRecLoc
        '            Matdim(jRec).RecupMat clsInizio.ArchDir
        '            Involucr(kLato, jmembh).MATE = Matdim(jRec).MatStr
        '            Involucr(kLato, jmembh).RecInd(1) = Matdim(jRec).Indmat
        '            Involucr(kLato, jmembh).Mark = RTrim$(Record(jRec).Denom) + " Pos." + Str$(Record(jRec).PosDis)
        '            Select Case Record(jRec).Tipo
        '               Case 3: Involucr(kLato, jmembh).ms = 1
        '151               'Config(kLato).di = Record(1).Dati(1)
        '                   Involucr(kLato, jmembh).di = Record(jRec).Dati(1) - 2 * Record(jRec).Dati(4)
        '                   Involucr(kLato, jmembh).H0 = (Record(jRec).Dati(1) - 2 * Record(jRec).Dati(4)) / 4 + Record(jRec).Dati(2)
        '               Case 4: Involucr(kLato, jmembh).ms = 4
        ''                 ' Config(kLato).di = Record(1).Dati(1)
        '                   Involucr(kLato, jmembh).di = Record(jRec).Dati(1) - 2 * Record(jRec).Dati(4)
        '                   Involucr(kLato, jmembh).L0 = 0.1 * (Involucr(kLato, jmembh).di - 2 * Record(jRec).Dati(4))
        '                   Involucr(kLato, jmembh).R0 = Involucr(kLato, jmembh).di - 2 * Record(jRec).Dati(4)
        '                   Involucr(kLato, jmembh).H0 = (Record(jRec).Dati(1) - 2 * Record(jRec).Dati(4)) * (1! - Sqr(65!) / 10) + Record(jRec).Dati(2)
        '               Case 5: Involucr(kLato, jmembh).ms = 5
        '                   Involucr(kLato, jmembh).L0 = (Record(jRec).Dati(1) - 2 * Record(jRec).Dati(4)) / 2
        '                   Piedr = Record(jRec).Dati(2)
        '                   Alfa = asin(Piedr / Involucr(kLato, jmembh).L0)
        '                   Involucr(kLato, jmembh).di = CInt(2 * Involucr(kLato, jmembh).L0 * Cos(Alfa))
        '                   Involucr(kLato, jmembh).H0 = (Record(jRec).Dati(1) - 2 * Record(jRec).Dati(4)) / 2 - Record(jRec).Dati(2)
        '            End Select
        '            Involucr(kLato, jmembh).Spess = Record(jRec).Dati(3) + Record(jRec).Dati(4)
        '            Involucr(kLato, jmembh).OS = Record(jRec).Dati(4)
        '            If Involucr(kLato, jmembh).ES = 0 Then Involucr(kLato, jmembh).ES = 1
        '            Involucr(kLato, jmembh).Tipo = 1
        'Return
        'RegRat:
        '        Select Case Look.K2
        '          Case 1: Nozzles(k).Rati = 150
        '          Case 2: Nozzles(k).Rati = 300
        '          Case 3: Nozzles(k).Rati = 400
        '          Case 4: Nozzles(k).Rati = 600
        '          Case 5: Nozzles(k).Rati = 900
        '          Case 6: Nozzles(k).Rati = 1500
        '          Case 7: Nozzles(k).Rati = 2500
        '        End Select
        'Return
        'RegisNstd:
        '         If Classe1(0) = 13 Then Classe1(0) = 0
        '         For ii = 1 To Classe1(0)
        '            If Rec2Buf(1).Ind = Classe1(ii) Then Return 'GOTO jump
        '         Next
        '         Classe1(0) = Classe1(0) + 1
        '         Classe1(Classe1(0)) = Rec2Buf(1).Ind
        'Return
        'Apice:
        '        For k = 1 To Config(kLato).Ninvolucri
        '            If Involucr(kLato, k).Tipo = 2 Or Involucr(kLato, k).Tipo = 3 Then
        '            Get #IUNA, Record(Involucr(kLato, k).indice(1)).Ind, Rec2Buf(2)
        '            For j = 1 To Lav(0).Ind(Lav(0).NumAs)
        '               Get #IUNA, j, Rec2Buf(1)
        '               If Rec2Buf(1).Tipo = 1 Then
        '                  Log1 = Rec2Buf(1).posspa.SuChi = Rec2Buf(2).Ind
        '                  Log2 = Rec2Buf(2).posspa.SuChi = Rec2Buf(1).Ind
        '                  If Log1 Or Log2 Then
        '                     For l = 1 To Config(kLato).Ninvolucri
        '                     If Involucr(l).Tipo = 0 Then
        '                     For m = 1 To 5
        '                        If Involucr(l).indice(m) = -1 Then Exit For
        '                        If Record(Involucr(l).indice(m)).Ind = Rec2Buf(1).Ind Then
        '                           If Abs(Involucr(kLato, k).di - Involucr(l).di) < 1 Then
        '                              Involucr(kLato, k).jmemb1 = l
        '                           ElseIf Abs(Involucr(kLato, k).dns - Involucr(l).di) < 1 Then
        '                              Involucr(kLato, k).jmemb2 = l
        '                           End If
        '                           Exit For
        '                        End If
        '                     Next
        '                     End If
        '                     Next
        '                  End If
        '               End If
        '            Next
        ''            IF Involucr(kLato,k).jmemb1 = 0 OR Involucr(kLato,k).jmemb2 = 0 THEN
        ''         Testo = " Non Š stato trovato uno dei cilindri"
        ''               junk = Alert(4, Testo, 4, 3, 11, 48, at1(33), "", "")
        ''            END IF
        '            If Involucr(kLato, k).jmemb1 = 0 Then Involucr(kLato, k).jmemb1 = -1
        '            If Involucr(kLato, k).jmemb2 = 0 Then Involucr(kLato, k).jmemb2 = -1
        '            End If
        '        Next
        'Return
        ''-------------------------------------------
        ''2431       messagebox.show "ApriLeggiU" + Err.Description + Str(Erl)
        ''Resume
    End Function
    Sub ApriScriviU()
        Dim Stringa(1) As String
        Dim Risult(1) As String
        Dim Archiv(1) As Short
        Dim dAiu(1) As String
        If AddDistinta > 0 Then
            If Len(icome) > 0 Then
                Call SalvaU()
            Else
                messagebox.show("Errore impossibile in ApriScrivi")
            End If
        Else
            If icome.Trim.Length > 0 Then
                Call SalvaU()
            Else
                SalvaCome()
            End If
        End If
        Exit Sub
        'ReTransWND:
        'For k = 1 To Config(kLato).Ninvolucri
        '    iRec = Involucr(kLato, k).indice(1): iTipo = Involucr(kLato, k).Tipo
        '    Select Case iTipo
        '      Case 0 '       cillindri
        '      For l = 1 To 5
        '           ll = Involucr(kLato, k).indice(l)
        '           If ll < 0 Then Exit For
        '           Record(ll).Dati(3) = Involucr(kLato, k).Spess - Involucr(kLato, k).OS
        ''           Record(ll).Dati(2) = Involucr(kLato,k).di
        '2651       Put #IUNA, Record(ll).Ind, Record(ll)
        '      Next
        '      Case 1
        '          Record(iRec).Dati(3) = Involucr(kLato, k).Spess - Involucr(kLato, k).OS
        '          Select Case Involucr(kLato, k).ms
        '             Case 1
        '               Record(iRec).Tipo = 3
        ''               Record(iRec).Dati(1) = Involucr(kLato,k).di
        '             Case 2, 3: messagebox.show "Errore fondo23"
        '             Case 4
        '               Record(iRec).Tipo = 4
        ''               Record(iRec).Dati(1) = Involucr(kLato,k).di
        '             Case 5
        '               Record(iRec).Tipo = 5
        ''               Record(iRec).Dati(1) = 2 * Involucr(kLato,k).L0
        '          End Select
        '    End Select
        '2661 Put #IUNA, Record(iRec).Ind, Record(iRec)
        'Next k
        '   For k = 1 To NumBocch(kLato)
        '2663  If Not Left$(Nozzles(kLato, k).Mark, 1) = "-" Then GoSub ScriviBocch
        '   Next
        'Return
        'ScriviBocch:
        '     iRec = Nozzles(kLato, k).indice
        '     If Nozzles(kLato, k).InvolucroSU > 0 Then
        '      TNV = Involucr(kLato, Nozzles(kLato, k).InvolucroSU).Spess
        '     Else
        '      TNV = Nozzles(kLato, -Nozzles(kLato, k).InvolucroSU).Spess
        '     End If
        '2664 Call LookTipoBocch(Record(iRec).Dati(), Look, False)
        '2665 KindChanged = False
        '2666 'If Look.K1 > 0 And Look.K1 < 5 Then ConvPoll CFl$(K1), DiaN Else DiaN! = 0
        '2667 If Nozzles(kLato, k).DiaN <> DiaN Then KindChanged = True: GoTo FineAp
        '2662 If Left$(Nozzles(kLato, k).Tipo, 1) = "L" Then
        '        If Nozzles(kLato, k).DiOn <> Look.Adim Or Nozzles(kLato, k).DiIn <> Look.b Then
        '           KindChanged = True: GoTo FineAp
        '        End If
        '     End If
        '     Select Case Nozzles(kLato, k).Tipo
        '       Case "WN  "
        '         If Look.junk3 = 2 Or Look.K3 > 1 Then
        '            KindChanged = True
        '         Else
        '            GoSub ScriviTronch
        '         End If
        '       Case "WN1 "
        '         If Not (Look.junk3 = 2 And Look.K3 = 1) Then
        '            KindChanged = True
        '         Else
        '            GoSub ScriviTronch
        '            GoSub ScriviPad
        '         End If
        '       Case "LWN "
        '         If Not (Look.junk1 = 1 And Look.K3 = 4) Then
        '            KindChanged = True
        '         Else
        '           GoSub Rinforzo
        '         End If
        '       Case "LWN1"
        '         If Not (Look.junk1 = 1 And Look.K3 = 4) Then
        '            KindChanged = True
        '         Else
        '           GoSub Rinforzo
        '         End If
        '       Case "LWN2"
        '         If Not (Look.junk2 = 2 And Look.K3 = 4) Then
        '            KindChanged = True
        '         Else
        '           Record(iRec).Dati(9) = Nozzles(kLato, k).PadT
        '           Record(iRec).Dati(6) = Nozzles(kLato, k).Padd
        '         End If
        '     End Select
        'FineAp: If Not KindChanged Then
        '2671     Put #IUNA, Record(iRec).Ind, Record(iRec)
        '      Else
        '2672     Call Erro(19): Return
        '      End If
        'Return
        'ScriviTronch:
        '   indice = Record(iRec).Ind
        '   Do
        '      indice = indice + 1
        '      Get #IUNA, indice, Rec2Buf(0)
        '      If Rec2Buf(0).Tipo = -2 Then Exit Do
        '      If EOF(IUNA) Or Rec2Buf(0).Tipo > 0 Then messagebox.show "Errore tronch in ApriScrivi"
        '   Loop
        '   Rec2Buf(0).Dati(3) = Nozzles(kLato, k).Spess
        '   Rec2Buf(0).Dati(2) = Nozzles(kLato, k).DiOn
        '2681 Put #IUNA, Rec2Buf(0).Ind, Rec2Buf(0)
        'Return
        'ScriviPad:
        '   indice = Record(iRec).Ind
        '   Do
        '      indice = indice + 1
        '      Get #IUNA, indice, Rec2Buf(0)
        '      If Rec2Buf(0).Tipo = -17 Then Exit Do
        '      If EOF(IUNA) Or Rec2Buf(0).Tipo > 0 Then messagebox.show "Errore pad    in ApriScrivi"
        '   Loop
        '     Rec2Buf(0).Dati(1) = Nozzles(kLato, k).Padd
        '     Rec2Buf(0).Dati(3) = Nozzles(kLato, k).PadT
        '2691 Put #IUNA, Rec2Buf(0).Ind, Rec2Buf(0)
        'Return
        'Rinforzo:
        '           If Nozzles(kLato, k).HX > 1 Then
        '              Nozzles(kLato, k).Tipo = "LWN1"
        '              Record(iRec).Dati(6) = 2 * Nozzles(kLato, k).HX + Nozzles(kLato, k).DiIn
        '              Record(iRec).Dati(9) = Nozzles(kLato, k).LX + TNV
        '           Else
        '              Nozzles(kLato, k).Tipo = "LWN "
        '              Record(iRec).Dati(6) = Nozzles(kLato, k).DiOn
        '              Record(iRec).Dati(9) = 0
        '           End If
        'Return
        '2551  If Erl = 2666 And Err = 9 Then
        '          messagebox.show "Call Inizia"
        '          'Call Inizia
        '          Resume
        '      Else
        '          messagebox.show "ApriScriviU" + Err.Description + Str(Erl)
        '          Stop
        '          Resume
        '      End If
    End Sub
    Sub CarichiU(ByRef junk As DialogResult)
        Dim cs, td1 As Single
        Dim i As Short
        Dim iTipo, k, iRec As Short
        Dim SU, Sfa, Sfo, fact As Single
        If kLato > 2 Then Exit Sub
        Try
            If Config(kLato).DC = 0 Or junk = DialogResult.No Then
                Select Case DatProg.CodiceM
                    Case 1 : Config(kLato).DC = 0 'ASME
                    Case 11 : Config(kLato).DC = 1 'ASME + TEMA R
                    Case 12, 13 : Config(kLato).DC = 2 'ASME + TEMA C/B
                    Case Else : Call Erro(18) : Config(kLato).DC = 1
                        DatProg.CodiceM = 1 'provvisorio
                End Select
            End If
            If junk = DialogResult.No Then
                If DatProg.UniMis = 1 Then 'mm/MPa/øC
                    Config(0).US = 0
                    fact = 10
                Else 'mm/psi/øF
                    Config(0).US = 1
                    fact = 1
                End If
            End If
            If junk = DialogResult.No Then
                If Config(kLato).LatoProgetto = 1 Then
                    Config(kLato).p0x = DatProg.PressTubi / fact
                    Config(kLato).tdx = DatProg.TempTubi
                    Config(kLato).tdxMDMT(0) = DatProg.MDMTTempTubi
                    Config(kLato).pdxMDMT(0) = DatProg.PressTubi / fact
                    If Config(kLato).tdxMDMT(1) = 0 And Config(kLato).pdxMDMT(1) = 0 Then
                        Config(kLato).tdxMDMT(1) = DatProg.MDMTTempTubi
                        Config(kLato).pdxMDMT(1) = DatProg.PressTubi / fact
                    End If
                    cs = DatProg.CorrTubi
                    Config(kLato).Corr = cs
                    Config(kLato).Vacuum = (DatProg.Vacuum > 1)
                Else
                    Config(kLato).p0x = DatProg.PressMant / fact
                    Config(kLato).tdx = DatProg.TempMant
                    Config(kLato).tdxMDMT(0) = DatProg.MDMTTempMant
                    Config(kLato).pdxMDMT(0) = DatProg.PressMant / fact
                    If Config(kLato).tdxMDMT(1) = 0 And Config(kLato).pdxMDMT(1) = 0 Then
                        Config(kLato).tdxMDMT(1) = DatProg.MDMTTempMant
                        Config(kLato).pdxMDMT(1) = DatProg.PressMant / fact
                    End If
                    cs = DatProg.CorrMant
                    Config(kLato).Corr = cs
                    Config(kLato).Vacuum = ((DatProg.Vacuum = 1) Or (DatProg.Vacuum = 3))
                End If
                AdjUnit()
                For i = 1 To Config(kLato).Ninvolucri
                    Involucr(kLato, i).cs = cs
                Next
                For i = Involucr(kLato, 1).inizio To NumBocch(kLato) + NumBocch2(kLato)
                    Nozzles(kLato, i).CorrA = cs
                Next
            End If
            AggMWDTdata(1)
            If Config(0).NumeroLati > 1 Then AggMWDTdata(2)
            For k = 1 To Config(kLato).Ninvolucri
                iTipo = Involucr(kLato, k).Tipo : iRec = Involucr(kLato, k).indice(1 - 1)
                Select Case iTipo
                    Case 1
                        If Involucr(kLato, k).SU = 0 Or Involucr(kLato, k).St = 0 Or Involucr(kLato, k).S0 = 0 Then
                            Matdim(iRec).SigmaAmm(CodiceStress, TempDes, Sfa, Sfo)
415:                        SU = Matdim(iRec).UltStrength(td1)
                            Involucr(kLato, k).St = Sfo
                            Involucr(kLato, k).S0 = Sfo
                            Involucr(kLato, k).SU = SU
                        End If
                    Case Else
                        If Involucr(kLato, k).St = 0 Then
400:                        Matdim(iRec).SigmaAmm(CodiceStress, TempDes, Sfa, Sfo)
                            Involucr(kLato, k).St = Sfo
                            If Involucr(kLato, k).S0 = 0 Then Involucr(kLato, k).S0 = Sfa
                        End If
                End Select
            Next
            For k = 1 To NumBocch(kLato) + NumBocch2(kLato)
                iRec = Nozzles(kLato, k).indice
                If Nozzles(kLato, k).AllN = 0 Then
                    If Matdim(iRec) Is Nothing Then
                        MessageBox.Show("Il materiale dell'apertura " & Trim(Nozzles(kLato, k).Mark) & "non è stato definito.")
                    Else
                        Matdim(iRec).SigmaAmm(CodiceStress, TempDes, Sfa, Sfo)
                        Nozzles(kLato, k).AllN = Sfo '/ mpa
                    End If
                End If
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message + vbCrLf + ex.StackTrace)
        End Try
    End Sub
    Function CheckCianfr(ByRef mode As Short) As Short
        Dim Stringa(11) As String
        Dim junk As Short
        Dim Testo As String
        Dim l, i, ll As Short
        Dim m, j, mm As Short
        Dim jj, ii As Short
        Dim Tnear, di, T1c, Tfar As Single
        Dim Hfar, Hnear, T2c As Single
        Dim T1s, Ds, Ap, T2s As Single
        Dim Q As String
        Dim iNear As Boolean
        Dim Trastr, Hrastr As Single
        Dim Log2, Log1, Log3 As Boolean
        Dim Log5, Log4, Log6 As Boolean
        Dim dsVero, ALFAAP As Single
        Dim HrVero, TrVero, APVero As Single
        Dim GenMemll, GenMemmm As Grafica.clsGenMem
        Dim Cilindro As Grafica.Cilindro
        Dim Fondo As Grafica.Fondo
        CheckCianfr = True
        If AddDistinta = 0 Then Exit Function
        For i = 1 To Config(kLato).Ninvolucri - 1
            For l = 1 To 8
                ll = Involucr(kLato, i).indice(l - 1) : If ll < 0 Then Exit For
                For j = i + 1 To Config(kLato).Ninvolucri
                    For m = 1 To 8
                        mm = Involucr(kLato, j).indice(m - 1) : If mm < 0 Then Exit For
                        GenMemll = Apparecchio.Elementi(ll).Genmem
                        GenMemmm = Apparecchio.Elementi(mm).Genmem
                        Log1 = GenMemll.Tipo = 1 And GenMemmm.Tipo = 5
                        Log2 = GenMemll.Tipo = 5 And GenMemmm.Tipo = 1
                        Log3 = GenMemll.posizione.SuChi Is GenMemmm.Parent
                        Log4 = GenMemmm.posizione.SuChi Is GenMemll.Parent
                        Log5 = GenMemll.Tipo = 1 And GenMemmm.Tipo > 2 And GenMemmm.Tipo < 6
                        Log6 = GenMemll.Tipo > 2 And GenMemll.Tipo < 6 And GenMemmm.Tipo = 1
                        If (Log5 Or Log6) And (Log3 Or Log4) And Config(kLato).Vacuum Then
                            ii = i : jj = j : If Involucr(kLato, ii).Tipo > 0 Then GlobalRoutines.SWAP(ii, jj)
                            Involucr(kLato, ii).R0 = Involucr(kLato, ii).L0 + Involucr(kLato, jj).H0 / 3
                        End If
                        If (Log1 Or Log2) And (Log3 Or Log4) Then
                            If GenMemll.Tipo > 1 Then
                                Cilindro = CType(GenMemmm.Parent, Grafica.Cilindro)
                                Fondo = CType(GenMemll.Parent, Grafica.Fondo)
                            Else
                                Cilindro = CType(GenMemll.Parent, Grafica.Cilindro)
                                Fondo = CType(GenMemmm.Parent, Grafica.Fondo)
                            End If
                            di = Cilindro.Diametro : T1c = Cilindro.SpessBase
                            T2c = Cilindro.SpessRive
                            Tnear = Cilindro.Tnear : Tfar = Cilindro.Tfar
                            Hnear = Cilindro.Hnear : Hfar = Cilindro.Hfar
                            Ds = Fondo.Diametro : T1s = Fondo.SpessBase
                            T2s = Fondo.SpessRive
                            Ap = Fondo.Piedritto
                            If Log3 Then Q = GenMemll.posizione.Quota Else Q = GenMemmm.posizione.Quota
                            Select Case Left(Q, 2)
                                Case "Ne" : iNear = True : Trastr = Tnear : Hrastr = Hnear
                                Case "Fa" : iNear = False : Trastr = Tfar : Hrastr = Hfar
                                Case Else : MessageBox.Show("Errore impossibile in CheckCianfr")
                            End Select
                            dsVero = CShort((di + 2 * T2c + T1c - 2 * T2s - T1s) * 2) / 2
                            ALFAAP = GlobalRoutines.acos(di / dsVero)
                            TrVero = CShort(((di + 2 * T1c + 2 * T2c) - (dsVero + 2 * T1s + 2 * T2s) * System.Math.Cos(ALFAAP)) / 2)
                            HrVero = CShort((T1c - TrVero) / System.Math.Tan(ALFAAP))
                            APVero = CShort(dsVero * System.Math.Sin(ALFAAP)) / 2
                            If System.Math.Sqrt((HrVero - Hrastr) ^ 2 + (TrVero - Trastr) ^ 2 + (dsVero - Ds) ^ 2 + (APVero - Ap) ^ 2) > 1 Then
                                Testo = "   La geometria del collegamento virola/fondo sferico tra"
                                Testo = Testo & "|     " & RTrim(Cilindro.GenMem.Denom)
                                Testo = Testo & "|e    " & RTrim(Fondo.GenMem.Denom)
                                Testo = Testo & "|non è stata specificata correttamente:"
                                Testo = Testo & "|Di sfera: specificato: " & GlobalRoutines.myStr(Ds, 4, 0, False) & ";corretto: " & GlobalRoutines.myStr(dsVero, 4, 0, False)
                                Testo = Testo & "|Altezza rastremazione: " & GlobalRoutines.myStr(Hrastr, 4, 0, False) & ";corretto: " & GlobalRoutines.myStr(HrVero, 4, 0, False)
                                Testo = Testo & "|Spessore alla base:    " & GlobalRoutines.myStr(Trastr, 4, 0, False) & ";corretto: " & GlobalRoutines.myStr(TrVero, 4, 0, False)
                                Testo = Testo & "|Altezza piedritto:     " & GlobalRoutines.myStr(CSng(Ap), 4, 0, False) & ";corretto: " & GlobalRoutines.myStr(APVero, 4, 0, False)
                                Testo = Testo & "|    Che cosa vuoi fare ?"
                                Stringa(1) = "Correggere secondo i valori calcolati"
                                Stringa(1) = "Confermare i dati impostati"
                                junk = Monitor.Motore.Quale(2, "Sfera/Cilindro", Stringa, "", 1, Monitor.Motore.Inizio.ConvertiCr(Testo))
                                If junk = 1 Then
                                    Fondo.Diametro = dsVero
                                    Fondo.Piedritto = APVero
                                    If iNear Then
                                        Cilindro.Tnear = TrVero
                                        Cilindro.Hnear = HrVero
                                    Else
                                        Cilindro.Tfar = TrVero
                                        Cilindro.Hfar = HrVero
                                    End If
                                    Testo = "E' necessario ripassare il calcolo di verifica.|"
                                    Testo = Testo & "E' consigliabile ripassare prima la rigenerazione|dei grezzi"
                                    MessageBox.Show(clsInizio.ConvertiCr(Testo))
                                    CheckCianfr = False
                                End If
                            End If
                        End If
                    Next m
                Next j
            Next l
        Next i
    End Function

    Sub ChiudeFileU()
        Dim Testo As String = ""
        If Not icome Is Nothing Then
            If icome.Length > 0 Then
                If ModifiedData Then
                    Testo = " Vuoi salvare le modifiche al|lavoro corrente conseguenti|alle verifiche effettuate?"
                    If MessageBox.Show(clsInizio.ConvertiCr(Testo), "AsmeVip", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then ApriScriviU()
                End If
            End If
        End If
        'job = Nothing
        CloseioutS((mioApert.lstRapp))
        mioApert.lstRapp.Items.Clear()
        mioApert.lstRes.Items.Clear()
        icome = " "
        ModifiedData = False
        Try
            Erase objMemb
        Catch
        End Try
        RidimensionaTutto()
    End Sub

    Function DomandeU() As Boolean
        Dim FileDes As String
        Dim ifl As Short
        Dim Testo As String
        Dim i As Short
        FileDes = CStr(CDbl(RTrim(clsInizio.Workdir) & "\" & RTrim(job.Comm.Arch) & Chr(92)) + job.Comm.Ind.Item(job.Comm.indice).Data.File + CDbl(".DES"))
        ifl = FreeFile()
        FileOpen(ifl, FileDes, OpenMode.Random, , , Len(DatProg))
        If LOF(ifl) > 0 Then
            FileGet(ifl, DatProg, 1)
            If LOF(ifl) > 2 * Len(DatProg) Then
                FileGet(ifl, DatiSh0, 2)
                For i = 0 To 3
                    FileGet(ifl, DatiS1(i), i + 3) : Next
                FileGet(ifl, DatiS2, 6)
            End If
            DomandeU = True
        Else
            Testo = "Non sono stati forniti i Dati di Progetto. |"
            Testo = Testo & "E' necessario farlo accedendo al menuitem  |"
            Testo = Testo & "'Dati di Progetto' del programma PPSM.     |"
            MessageBox.Show(clsInizio.ConvertiCr(Testo))
            FileClose(ifl)
            DomandeU = False
            Exit Function
        End If
        FileClose(ifl)
    End Function
    Sub AggMWDTdata(ByRef Lato As Short)
        Dim k, j As Short
        k = Lato
        For j = 1 To Config(k).Ninvolucri
            MWDTdata(k, j)
        Next
        If Config(0).NumeroLati > 2 Then
            k = 3
            For j = 1 To Config(k).Ninvolucri
                MWDTdata(k, j)
            Next
        End If
    End Sub
    Sub MWDTdata(ByRef k As Short, ByRef j As Short)
        Dim iRec, l As Short
        Dim i As Short
        Try
            For l = 1 To 8
                iRec = Involucr(k, j).indice(l - 1)
                If iRec = -1 Then Exit For
                If iRec > UBound(Matdim) Then Exit For
                If Matdim(iRec) Is Nothing Then
                Else
                    If Matdim(iRec).Indmat = 0 And Matdim(iRec).Agganciato Then
                        ' If Not Matdim(iRec).DiagnB(-1, 0, "Membratura interessata: " + Involucr(k, j).Mark, clsInizio.ArchDir) Then Exit Sub
                    Else
                        For i = 1 To CShort(Matdim(iRec).Caract.Count)
                            If Matdim(iRec).Caract.Item(i).TextData.Codice = CodiceStress() Then
                                Involucr(k, j).MWDTrule = Matdim(iRec).Caract.Item(i).TextData.MWDTrule
                                Involucr(k, j).MWDTclause = Matdim(iRec).Caract.Item(i).TextData.MWDTclause
                                Involucr(k, j).MWDTtemp = Matdim(iRec).Caract.Item(i).TextData.MWDTtemp
                                Exit For
                            End If
                        Next
                    End If
                End If
            Next
        Catch e As Exception
            MessageBox.Show(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Sub SalvaU()
        Lancio.Legacy.Serialization.LegacyBinarySerializer.EnsureEnabled()
        Dim i As Short
        Dim Nnozz, k As Short
        If icome.Trim.Length = 0 Then Exit Sub
        Dim fs As New FileStream(icome, FileMode.OpenOrCreate)
        Dim bf As New Lancio.Legacy.Serialization.LegacyBinarySerializer
        If Not nuovoINP Then
            If MostraAiuto(2101, ChiaviMess.MessQuestion + ChiaviMess.MessYesNo) = ChiaviMess.Messno Then Exit Sub
        End If
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        Config(0).Versione = 25
        Try
            bf.Serialize(fs, Config(0))
            bf.Serialize(fs, job)
            nuovoINP = True
            For k = 1 To Config(0).NumeroLati + 1
                Config(k).Versione = Config(0).Versione
                bf.Serialize(fs, Config(k))
                For i = 1 To Config(k).Ninvolucri
                    bf.Serialize(fs, Involucr(k, i))
                    Select Case Involucr(k, i).Tipo
                        Case 2, 3
                            bf.Serialize(fs, AdditCono(k, i))
                        Case 5 ' Flangione
                            kLato = k : jInvolucr = i
                            CType(objMemb(Involucr(k, i).IndObject), wn_flan).Salva(fs)
                        Case 6 ' PT
                            kLato = k : jInvolucr = i
                            CType(objMemb(Involucr(k, i).IndObject), wn_PT).Salva(fs)
                        Case 8 ' dilat
                            kLato = k : jInvolucr = i
                            CType(objMemb(Involucr(k, i).IndObject), wn_PT).Salva(fs)
                        Case 9 ' pass partition
                            kLato = k : jInvolucr = i
                            CType(objMemb(Involucr(k, i).IndObject), wn_Part).Salva(fs)
                    End Select
                Next
                Nnozz = NumBocch(k) + NumBocch2(k)
111:            For i = 1 To Nnozz
                    If Nozzles(k, i).SWR < 9 Then Nozzles(k, i).SWR = Nozzles(k, i).SWR + 10
                    bf.Serialize(fs, Nozzles(k, i))
                    If Nozzles(k, i).IndObject > 0 Then
                        kLato = k : kNozzle = i
                        CType(objMemb(Nozzles(k, i).IndObject), wn_flan).Salva(fs)
                    End If
                    bf.Serialize(fs, NozzAdd(k, i))
                Next
            Next
            bf.Serialize(fs, indici)
            For i = 1 To indici.Count
                If Matdim(indici(i).TextData) Is Nothing Then Matdim(indici(i).TextData) = New LibMat.MaterialeNew1
                bf.Serialize(fs, Matdim(indici(i).TextData))
                bf.Serialize(fs, Matdim(indici(i).TextData).AlfaYoung)
            Next
            fs.Close()
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
        'If Not job Is Nothing Then
        'job.Comm.SalvaCom()
        ''            job.Salva()
        'End If
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        Environment.CurrentDirectory = Monitor.Motore.Inizio.Basedir & "\Dll"
        ModifiedData = False
    End Sub
    Public Sub TransWND()
        Dim Tipo As Short
        Dim Flangione As New wn_flan
        Dim Tirante As New Grafica.clsTirante
        Dim Tubi As New Grafica.Tubi
        Dim PT As Boolean
        Dim PrimaPiastra As New Grafica.Piastrone
        Dim Fl1, Fl2 As Grafica.Flangione
        Dim PiastraT As New wn_PT
        Dim Noz As New Grafica.clsBocch
        Dim Partition_Renamed As New wn_Part
        Dim Striscia As New Grafica.Striscia
        Dim Polig As New Grafica.clsPolig
        Dim Tronch As New Grafica.Cilindro
        Dim Larghezza, Lunghezza As Single
        Dim j As Short
        Config(0).DNjob = job.Comm.Arch
        Config(0).Item = job.Comm.Ind.Item(job.Comm.indice).Data.Assieme
        Config(0).lkStr = "Design Condition"
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        Apparecchio = Libgra.Costruisci(job, True)
        If Apparecchio.NumeroLati = 0 Then Exit Sub
        ElencoInvolucri = New Collection
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        Config(0).NumeroLati = Libgra.QuantiLati(DatiSh0.FBMLetter, DatiSh0.IndCodice)
        If Config(0).NumeroLati = 2 Then
            Config(0).NumeroLati = 3
            Config(1).LatoProgetto = 2
            Config(2).LatoProgetto = 1
        Else
            Config(1).LatoProgetto = 1
        End If
        Dim i As Short
        For i = 0 To Apparecchio.Elementi.Count - 1
            O = Apparecchio.Elementi(i)
            Genmem = CType(O.Genmem, clsGenMem)
            Select Case Genmem.Tipo
                Case 1
                    Tipo = 0 'cilindri
                    Membratura(Tipo)
                    With Involucr(kLato, jInvolucr)
                        .di = CType(O, Cilindro).Diametro
                        .Spess = CType(O, Cilindro).SpessBase
                        .OS = CType(O, Cilindro).SpessRive
                        .L0 = CType(O, Cilindro).Lunghezza
                        If Config(kLato).di < .di Then Config(kLato).di = .di
                    End With
                Case 3, 4, 5
                    Tipo = 1 'fondo
                    Membratura(Tipo)
                    ' "Ellipsoidal Head : D/2h=2.0  "
                    ' "Ellipsoidal Head : D/2h<>2.0 "
                    ' "Torisph.Head : r=0.06L & L=Do"
                    ' "Torispherical Head : r>0.06L "
                    ' "Emispherical Head            "
                    ' "Calotta sferica              "
                    With Involucr(kLato, jInvolucr)
                        .di = CType(O, Fondo).Diametro
                        .Spess = CType(O, Fondo).SpessBase
                        .OS = CType(O, Fondo).SpessRive
                        Select Case Genmem.Tipo
                            Case 3 'semiellittico
                                .ms = 1
                                '.H0 = .di / 2
                            Case 4, 5, 6 'torosferico
                                .ms = 3
                            Case 5 'sferico
                                .ms = 7
                                .L0 = System.Math.Sqrt((CType(O, Fondo).Diametro / 2) ^ 2 + CType(O, Fondo).Piedritto ^ 2)
                        End Select
                    End With
                Case 16 'dischi/calotte/fondi
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto O.SottoTipo. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                    Select Case O.SottoTipo
                        Case 1 'calotta
                            Tipo = 1 'fondo
                            Membratura(Tipo)
                        Case 2 'Disco
                        Case 3 'fondo piano raccordato
                    End Select
                Case 6
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto O.Fitting. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                    If Not O.Fitting Then
                        Tipo = 3 'conoide
                        Membratura(Tipo)
                        With Involucr(kLato, jInvolucr)
                            .di = CType(O, Cono).Dgran
                            .dns = CType(O, Cono).Dpicc
                            .H0 = CType(O, Cono).RagG
                            .L0 = CType(O, Cono).RagP
                            .R0 = CType(O, Cono).AlfaCon
                            .Spess = CType(O, Cono).SpessBase
                            .OS = CType(O, Cono).SpessRive
                        End With
                    End If
                Case 7
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto O.Fitting. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                    If Not O.Fitting Then
                        Tipo = 2 'cono
                        Membratura(Tipo)
                        With Involucr(kLato, jInvolucr)
                            .di = CType(O, Cono).Dgran
                            .dns = CType(O, Cono).Dpicc
                            .H0 = CType(O, Cono).RagG
                            .L0 = CType(O, Cono).RagP
                            .R0 = CType(O, Cono).AlfaCon
                            .Spess = CType(O, Cono).SpessBase
                            .OS = CType(O, Cono).SpessRive
                        End With
                    End If
                Case 11 'flangioni
                    Tipo = 5 'flangioni coperchi
                    Membratura(Tipo)
                    CreaOggetto(jInvolucr)
                    Flangione = objMemb(Involucr(kLato, jInvolucr).IndObject)
                    With Flangione
                        'LOOSE WITHOUT HUB
                        'INTEGRAL
                        'LOOSE WITH HUB
                        'OPTIONAL CALCULATED AS LOOSE
                        'OPTIONAL CALCULATED AS INTEGRAL
                        'BOLTED FLAT COVER
                        'FLAT HEAD WITH LARGE OPENING AND INNER HUB
                        'FLAT HEAD WITH LARGE OPENING WITH NO INNER HUB
                        'REVERSE FLANGE per App. 2-13
                        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto O.SottoTipo. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                        Select Case O.SottoTipo
                            Case 1 ' "Gradino maschio"
                                .Mem.LOOSE = 0
                            Case 2 ' "Gradino femmina"
                                .Mem.LOOSE = 0
                            Case 3 ' "Flangione rovescio"
                                .Mem.LOOSE = 7
                            Case 4 ' "Flangione bicodolo"
                                MessageBox.Show("Caso non previsto")
                        End Select
                        CercaTirGua1(Tirante)
                        .Mp(3) = CType(O, Flangione).DiamExt
                        .Mp(4) = Dinst
                        .Mp(5) = Guarn.DiamMed
                        .Mp(6) = CType(O, Flangione).DiamInt
                        .Mp(7) = CType(O, Flangione).g0
                        .Mp(8) = CType(O, Flangione).g1
                        .Mp(9) = CType(O, Flangione).SpessBase - CType(O, Flangione).SpessGra
                        .Mp(10) = CType(O, Flangione).H
                        .Mem.TIR = Tirante.StandardTir.DN
                        .Mem.XFil = Tirante.StandardTir.Xfil
                        .Mp(13) = Tirante.GenMem.Qta
                        .Mp(26) = Guarn.Largh
                        ' .Mp(28) = Guarn.Standard.y
                        .Mp(29) = 0 'Nubbin
                        ' .Mp(30) = Guarn.Standard.m
                        .AggiornaGuar(Guarn.StandardGua)
                        .TipCalc = 2
                    End With
                    If Not Tirante Is Nothing Then
                        Matdim(Involucr(kLato, jInvolucr).indice(2 - 1)).Indmat = Tirante.GenMem.Indmat1
                        Matdim(Involucr(kLato, jInvolucr).indice(2 - 1)).RecupMat(clsInizio.Archdir)
                    End If
                Case 12 'PT/coperchi
                    Tipo = 6 'PT
                    If Tubi Is Nothing Then Tubi = Apparecchio.CercaTubi
                    PT = False
                    If Tubi.GenMem.posizione.SuChi Is O Then
                        PT = True
                    Else
                        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Tubi.Genmem.Posizione.SuChi.Genmem. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                        PT = Tubi.GenMem.posizione.SuChi.Genmem.Posizione.SuChi Is O
                    End If
                    If Not PT Or PT And PrimaPiastra Is Nothing Then
                        If PT And PrimaPiastra Is Nothing Then PrimaPiastra = O
                        Membratura(Tipo)
                        CreaOggetto(jInvolucr) 'TopoPT=2
                        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto O.SottoTipo. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                        Select Case O.SottoTipo
                            Case 1 ' "2 codoli esterni"FTC
                                PiastraT = objMemb(Involucr(kLato, jInvolucr).IndObject)
                            Case 2 ' "1 int. / 1 est."FTC
                                PiastraT = objMemb(Involucr(kLato, jInvolucr).IndObject)
                            Case 3 ' "saldata LM + bulloni"FTC
                                PiastraT = objMemb(Involucr(kLato, jInvolucr).IndObject)
                            Case 4 'cmbTipo.AddItem "senza cod., gr.Sx/Dx"UTEMA?
                                PiastraT = objMemb(Involucr(kLato, jInvolucr).IndObject)
                                CType(PiastraT.Piastra, wn_FTC).Rear = 3
                                CType(PiastraT.Piastra, wn_FTC).Flangiata(1) = 0
                                CType(PiastraT.Piastra, wn_FTC).Gasketed(1) = 1
                            Case 5 'cmbTipo.AddItem "s.cod. e 1/2 gr.a Sx"coperchio
                                If Not PT Then
                                    objMemb(Involucr(kLato, jInvolucr).IndObject) = New wn_flan
                                End If
                            Case 6 'cmbTipo.AddItem "sandwitch+collar blt"UTEMA?
                                If System.Math.Abs(Tubi.GenMem.Tipo) = 9 Then
                                    objMemb(Involucr(kLato, jInvolucr).IndObject).Piastra = New wn_UTEMA
                                    objMemb(Involucr(kLato, jInvolucr).IndObject).TipoPT = 1
                                End If
                                PiastraT = objMemb(Involucr(kLato, jInvolucr).IndObject)
                            Case 7 ' "saldata LC + bulloni"FTC
                                PiastraT = objMemb(Involucr(kLato, jInvolucr).IndObject)
                        End Select
                        If PT Then
                            With PiastraT
                                .TSheDes = PrimaPiastra.DiamExt
                                .TSheThk = PrimaPiastra.SpessBase
                                .TubDiam = Tubi.DiamExt
                                .TubPass = Tubi.Passo
                                .ProgDiffPr = False
                                .TipPass = Tubi.TipoPasso \ 2 '0 triangolare 1 quadrato
                            End With
                            CercaLato()
                        Else
                            CercaTirGua1(Tirante)
                            With objMemb(Involucr(kLato, jInvolucr).IndObject)
                                .LOOSE = 4
                                .Mp(3) = O.DiamExt
                                .Mp(4) = Dinst
                                .Mp(5) = Guarn.DiamMed
                                .Mp(9) = O.SpessBase - O.SpessGra
                                .Mp(12) = Tirante.StandardTir.DN
                                .Mp(13) = Tirante.GenMem.Qta
                                .Mp(26) = Guarn.Largh
                                .Mp(28) = Guarn.StandardGua.y
                                .Mp(29) = 0 'Nubbin
                                .Mp(30) = Guarn.StandardGua.m
                            End With
                        End If
                    ElseIf PT Then
                        '????????
                    End If
                Case 8, 9, -8, -9
                    Tipo = 7 'tubi
                    Membratura(Tipo)
                    CreaOggetto(jInvolucr)
                    Tubi = O
                    With Involucr(kLato, jInvolucr)
                        .Spess = Tubi.Spessore
                        .dns = Tubi.DiamExt
                        .File = GenFileTraccia()
                        .L0 = Tubi.Lunghezza
                    End With
                Case 8
                    Tipo = 8 'Dilatatori
                    Membratura(Tipo)
                    CreaOggetto(jInvolucr)
                Case 37 'set di setti
                    Tipo = 9
                    Dim ii As Short
                    For ii = 0 To CType(O.Genmem, clsGenMem).Appesi.Count - 1
                        O1 = CType(O.Genmem, clsGenMem).Appesi(ii)
                        Membratura(Tipo)
                        CreaOggetto(jInvolucr)
                        Partition_Renamed = objMemb(Involucr(kLato, jInvolucr).IndObject)
                        With Partition_Renamed
                            Select Case System.Math.Abs(CType(O1.Genmem, clsGenMem).Tipo)
                                Case 15
                                    Striscia = O1
                                    Involucr(kLato, jInvolucr).Spess = Striscia.Spessore
                                    .longdim = Striscia.Lunghezza
                                    .transvdim = Striscia.Larghezza
                                Case 96
                                    Polig = O1
                                    Involucr(kLato, jInvolucr).Spess = Polig.Spessore
                                    Polig.CalcInscritto(Larghezza, Lunghezza)
                                    .longdim = Lunghezza
                                    .transvdim = Larghezza
                            End Select
                        End With
                    Next ii
            End Select
        Next i
        For i = 0 To Apparecchio.Elementi.Count - 1
            O = Apparecchio.Elementi(i)
            Genmem = CType(O.Genmem, clsGenMem)
            Select Case Genmem.Tipo
                Case 10, 14, -10, -14
                    O1 = Genmem.posizione.SuChi
                    'O.Leggi "", 0
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto O.TipoF. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                    Select Case O.TipoF
                        Case 1, 2 ' forgiato
                            IndPad = 0
                            IndNoz = Genmem.Indmat1
                            IndFla = Genmem.Indmat1
                        Case 3 'con pad
                            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto O.Pad. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                            IndPad = O.Pad.Genmem.Indmat1
                            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto O.tronchetto. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                            If O.tronchetto Is Nothing Then
                                IndNoz = Genmem.Indmat1
                            Else
                                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto O.tronchetto. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                                IndNoz = O.tronchetto.Genmem.Indmat1
                            End If
                            IndFla = Genmem.Indmat1
                        Case 4 'senza pad
                            IndPad = 0
                            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto O.tronchetto. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                            If O.tronchetto Is Nothing Then
                                IndNoz = Genmem.Indmat1
                            Else
                                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto O.tronchetto. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                                IndNoz = O.tronchetto.Genmem.Indmat1
                            End If
                            IndFla = Genmem.Indmat1
                        Case 5 : GoTo Cont 'Flangia sola
                    End Select
                    If Not SuperApertura() Then Exit Sub
                    Noz = O
                    With Nozzles(kLato, kNozzle)
                        .DiaN = GlobalRoutines.ConvPoll(Noz.Standard.strDiam) 'non si potrà cambiare
                        .Rati = GlobalRoutines.ValVir(Noz.Standard.strRati) 'non si potrà cambiare
                        .DiIn = Noz.DiamInt 'non si potrà cambiare
                        .DiOn = Noz.Standard.DiamTr 'non si potrà cambiare
                        .Spess = (.DiOn - .DiIn) / 2 'non si potrà cambiare
                        Select Case Noz.TipoF
                            '1 "DA FORGIATO CON SCARPA"
                            '2 "DA FORGIATO AUTORINFORZATO"
                            '3 "STANDARD CON RINFORZO"
                            '4 "STANDARD SENZA RINFORZO"
                            '5 "FLANGIA SOLA"
                        Case 2
                                'If Noz.DiamRinf <= Noz.Standard.DiamTr Then
                                '   .Tipo = "LWN "
                                '   GoSub UW16
                                'Else
                                .Tipo = "LWN1"
                                .LX = (Noz.DiamRinf - Noz.DiamInt) / 2
                                .HX = Noz.AltzRinf
                                If NozzAdd(kLato, kNozzle).TipAbutt < 1 Then NozzAdd(kLato, kNozzle).TipAbutt = 1
                                Select Case NozzAdd(kLato, kNozzle).UW16
                                    Case 13, 20, 21
                                    Case Else : NozzAdd(kLato, kNozzle).UW16 = 13
                                End Select
                            Case 1 : .Tipo = "LWN2"
                                If NozzAdd(kLato, kNozzle).TipAbutt < 1 Then NozzAdd(kLato, kNozzle).TipAbutt = 1
                                Select Case NozzAdd(kLato, kNozzle).UW16
                                    Case 9, 10, 11, 12
                                    Case Else : NozzAdd(kLato, kNozzle).UW16 = 12
                                End Select
                            Case 3
                                .Tipo = "WN1 "
                                .Padd = Noz.Pad.DiamExt
                                .PadT = Noz.Pad.Spess
                                If NozzAdd(kLato, kNozzle).TipAbutt < 1 Then NozzAdd(kLato, kNozzle).TipAbutt = 1
                                Select Case NozzAdd(kLato, kNozzle).UW16
                                    Case 2, 4, 14, 23, 24, 25
                                    Case Else : NozzAdd(kLato, kNozzle).UW16 = 23
                                End Select
                            Case 4
                                Select Case Noz.Standard.K3
                                    Case 4
                                        .Tipo = "LWN "
                                        UW16()
                                    Case Else
                                        .Tipo = "WN  "
                                        UW16()
                                End Select
                        End Select
                    End With
                    With Nozzles(kLato, kNozzle)
                        If .InvolucroSU > 0 Then
                            Tipo = Involucr(kLato, .InvolucroSU).Tipo
                        Else
                            Tipo = 0
                        End If
                        Select Case Tipo
                            Case 0 'su cilindro
                                .DTL = 0
                                .DCL = Noz.SpostLat
                                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto O1.Genmem. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                                .beta = GlobalRoutines.acos(System.Math.Abs(Noz.GenMem.posizione.CosDiritta.ProdScalar(O1.Genmem.Posizione.CosDiritta))) * 180 / pi
                                'If .beta = 0 Then .beta = 90
                            Case 1 'su fondo
                                .DTL = 0
                                .DCL = Noz.SpostLat
                                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto O1.Genmem. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                                .beta = GlobalRoutines.acos(System.Math.Abs(Noz.GenMem.posizione.CosDiritta.ProdScalar(O1.Genmem.Posizione.CosDiritta))) * 180 / pi
                                .Anomal = Noz.GenMem.posizione.AnomalR
                            Case 2 'su cono
                                .DTL = 0
                                .DCL = 0
                                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto O1.Genmem. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                                .beta = GlobalRoutines.acos(System.Math.Abs(Noz.GenMem.posizione.CosDiritta.ProdScalar(O1.Genmem.Posizione.CosDiritta))) * 180 / pi
                                'If .beta = 0 Then .beta = 90
                            Case 3 'su conoide
                                .DTL = 0
                                .DCL = 0
                                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto O1.Genmem. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                                .beta = GlobalRoutines.acos(System.Math.Abs(Noz.GenMem.posizione.CosDiritta.ProdScalar(O1.Genmem.Posizione.CosDiritta))) * 180 / pi
                                'If .beta = 0 Then .beta = 90
                        End Select
                    End With
                Case 2
                    O1 = Genmem.posizione.SuChi
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto O1.Genmem. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                    Select Case O1.Genmem.Tipo
                        Case 1, 3, 4, 5
                        Case 6, 7
                            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto O1.Fitting. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                            If O1.Fitting Then GoTo Cont
                        Case Else : GoTo Cont
                    End Select
                    If Not SuperApertura() Then Exit Sub
                    Tronch = O
                    With Nozzles(kLato, kNozzle)
                        .DiaN = GlobalRoutines.ConvPoll(Tronch.StandardPip.DN)
                        .Rati = 0 'Noz.Standard.strRati
                        .DiIn = Tronch.Diametro
                        .DiOn = Tronch.Diametro + 2 * Tronch.Spessore
                        .Spess = (.DiOn - .DiIn) / 2
                    End With
            End Select
Cont:
        Next i
        For kLato = 1 To Config(0).NumeroLati
            For jInvolucr = 1 To Config(kLato).Ninvolucri
                Select Case Involucr(kLato, jInvolucr).Tipo
                    Case 2, 3
                        O = Apparecchio.CercaElemento(Trim(Involucr(kLato, jInvolucr).Mark))
                        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto ctype(O.Genmem,clsGenmem). Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                        Genmem = CType(O.Genmem, clsGenMem)
                        O1 = Genmem.posizione.SuChi
                        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto O1.Genmem. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                        If O1.Genmem.Tipo = 1 Then
                            If Left(Genmem.posizione.DirDiritta, 2) = "=+" Or Left(Genmem.posizione.DirDiritta, 2) = "=-" Then
                                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto O1.Genmem. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                                Cercanome = ElencoInvolucri.Item(Trim(O1.Genmem.Denom))
                                j = Cercanome.jInvolucr
                                If Mid(Genmem.posizione.Raggio, 6, 1) = "G" Then
                                    Involucr(kLato, jInvolucr).jmemb1 = j
                                ElseIf Mid(Genmem.posizione.Raggio, 6, 1) = "P" Then
                                    Involucr(kLato, jInvolucr).jmemb2 = j
                                End If
                                If Mid(Genmem.posizione.Quota, 1, 1) = "N" Then
                                    Involucr(kLato, jInvolucr).jmemb1 = j
                                ElseIf Mid(Genmem.posizione.Quota, 1, 1) = "F" Then
                                    Involucr(kLato, jInvolucr).jmemb2 = j
                                End If
                            End If
                        End If
                        Dim ii As Short
                        For ii = 0 To Apparecchio.Elementi.Count - 1
                            O1 = Apparecchio.Elementi(ii)
                            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto O1.Genmem. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                            If O1.Genmem.Posizione.SuChi Is O Then
                                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto O1.Genmem. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                                If O1.Genmem.Tipo = 1 Then
                                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto O1.Genmem. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                                    Genmem = O1.Genmem
                                    If Left(Genmem.posizione.DirDiritta, 2) = "=+" Or Left(Genmem.posizione.DirDiritta, 2) = "=-" Then
                                        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto O1.Genmem. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                                        Cercanome = ElencoInvolucri.Item(Trim(O1.Genmem.Denom))
                                        j = Cercanome.jInvolucr
                                        If Mid(Genmem.posizione.Raggio, 6, 1) = "G" Then
                                            Involucr(kLato, jInvolucr).jmemb1 = j
                                        ElseIf Mid(Genmem.posizione.Raggio, 6, 1) = "P" Then
                                            Involucr(kLato, jInvolucr).jmemb2 = j
                                        End If
                                    End If
                                End If
                            End If
                        Next ii
                    Case 5
                        Fl1 = Apparecchio.CercaElemento(Trim(Involucr(kLato, jInvolucr).Mark))
                        Fl2 = Apparecchio.CercaAltraFlangia(Fl1)
                        If Not Fl2 Is Nothing Then
                            Cercanome = ElencoInvolucri.Item(Trim(Fl2.GenMem.Denom))
                            Involucr(kLato, jInvolucr).AccoppJ = Cercanome.jInvolucr
                            Involucr(kLato, jInvolucr).AccoppK = Cercanome.kLato
                        End If
                    Case 6 'PT
                        PrimaPiastra = Apparecchio.CercaElemento(Trim(Involucr(kLato, jInvolucr).Mark))
                        PiastraT = objMemb(Involucr(kLato, jInvolucr).IndObject)
                        Select Case PiastraT.TipoPT
                            Case 1 'UTEMA
                            Case 2 'FTC
                                Select Case CType(PiastraT.Piastra, wn_FTC).Rear
                                    Case 1
                                    Case 2
                                    Case 3
                                        If CType(PiastraT.Piastra, wn_FTC).Gasketed(1) = 1 Then
                                            Guarn = Apparecchio.CercaGuar(PrimaPiastra)
                                            Fl1 = Apparecchio.CercaFlan(Guarn)
                                            Fl2 = Apparecchio.CercaAltraFlangia(Fl1)
                                            Cercanome = ElencoInvolucri.Item(Trim(Fl1.GenMem.Denom))
                                            If Cercanome.kLato = 1 Then
                                                PiastraT.IndAccopp(2) = Cercanome.jInvolucr  'indice flangia LM
                                                Cercanome = ElencoInvolucri.Item(Trim(Fl2.GenMem.Denom))
                                                PiastraT.IndAccopp(1) = Cercanome.jInvolucr
                                            Else
                                                PiastraT.IndAccopp(1) = Cercanome.jInvolucr  'indice flangia LM
                                                Cercanome = ElencoInvolucri.Item(Trim(Fl2.GenMem.Denom))
                                                PiastraT.IndAccopp(2) = Cercanome.jInvolucr
                                            End If
                                        Else
                                        End If
                                End Select
                        End Select
                End Select
            Next
        Next
        CheckCollegamenti()
    End Sub
    Private Sub UW16()
        If NozzAdd(kLato, kNozzle).TipAbutt < 1 Then NozzAdd(kLato, kNozzle).TipAbutt = 1
        Select Case NozzAdd(kLato, kNozzle).UW16
            Case 1, 3, 5, 6, 7, 8, 15, 16, 17, 18
            Case Else : NozzAdd(kLato, kNozzle).UW16 = 7
        End Select
    End Sub
    Private Function SuperApertura() As Boolean
        Dim jSU, NBocch, Dimen As Short
        kLato = O1.Genmem.Lato
        jInvolucr = 0
        For jSU = 1 To Config(kLato).Ninvolucri
            If Trim(O1.Genmem.Denom) = Trim(Involucr(kLato, jSU).Mark) Then
                jInvolucr = jSU
                CercaLato()
                NBocch = NumLoc(kLato, jInvolucr)
                AggBocc(jInvolucr, NBocch, NBocch + 1)
                kNozzle = Involucr(kLato, jInvolucr).Fine
                Nozzles(kLato, kNozzle).Mark = Trim(Genmem.Denom)
                If IndNoz > 0 Then
                    If Nozzles(kLato, kNozzle).indice = 0 Then
                        Nozzles(kLato, kNozzle).indice = NuovoIndice()
                        Dimen = UBound(Matdim)
                        If Nozzles(kLato, kNozzle).indice > Dimen Then
                            ReDim Preserve Matdim(2 * Nozzles(kLato, kNozzle).indice)
                        End If
                    End If
                    Matdim(Nozzles(kLato, kNozzle).indice).Indmat = IndNoz
                    Matdim(Nozzles(kLato, kNozzle).indice).RecupMat(clsInizio.Archdir)
                    Nozzles(kLato, kNozzle).MATE = Matdim(Nozzles(kLato, kNozzle).indice).MatStr
                End If
                If IndPad > 0 Then
                    If Nozzles(kLato, kNozzle).IndiceP = 0 Then
                        Nozzles(kLato, kNozzle).IndiceP = NuovoIndice()
                        Dimen = UBound(Matdim)
                        If Nozzles(kLato, kNozzle).IndiceP > Dimen Then
                            ReDim Preserve Matdim(2 * Nozzles(kLato, kNozzle).IndiceP)
                        End If
                    End If
                    Matdim(Nozzles(kLato, kNozzle).IndiceP).Indmat = IndPad
                    Matdim(Nozzles(kLato, kNozzle).IndiceP).RecupMat(clsInizio.Archdir)
                End If
                If IndFla > 0 Then
                    If Nozzles(kLato, kNozzle).IndexF = 0 Then
                        Nozzles(kLato, kNozzle).IndexF = NuovoIndice()
                        Dimen = UBound(Matdim)
                        If Nozzles(kLato, kNozzle).IndexF > Dimen Then
                            ReDim Preserve Matdim(2 * Nozzles(kLato, kNozzle).IndexF)
                        End If
                    End If
                    Matdim(Nozzles(kLato, kNozzle).IndexF).Indmat = IndFla
                    Matdim(Nozzles(kLato, kNozzle).IndexF).RecupMat(clsInizio.Archdir)
                End If
                Cercanome = New clsCercaNome
                Cercanome.kLato = kLato
                Cercanome.kNozzle = kNozzle
                ElencoInvolucri.Add(Cercanome, Trim(Genmem.Denom))
                Exit For
            End If
        Next
        If jInvolucr = 0 Then
            Dim Testo As String = "Non è stata trovata una membratura sulla quale" & vbCrLf
            Testo = Testo & "praticare l'apertura generata dalla membratura" & vbCrLf
            Testo = Testo & CType(O.Genmem, clsGenMem).Denom & ", posizionata relativamente a" & vbCrLf
            Testo = Testo & O1.Genmem.Denom & " (lato" & Str(kLato) & ")."
            MessageBox.Show(Testo, "AsmeVip", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Apparecchio.NumeroLati = 0
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            Return False
        End If
        Return True
    End Function
    Private Sub CercaLato()
        Select Case Genmem.Lato
            Case 0
                If Config(0).NumeroLati = 1 Then
                    Genmem.Lato = 1
                    kLato = 1
                Else
                    Stringa(1) = "Lato Mantello"
                    Stringa(2) = "Lato Tubi"
                    Stringa(3) = "Fra i due"
                    Stringa(4) = "non a pressione"
                    Dim Testo As String = "Alla membratura " & Trim(Genmem.Denom) & " non è stato|"
                    Testo = Testo & "assegnato alcun lato. Specificare un lato."
                    System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
                    Ris = Monitor.Motore.Quale(4, "AsmeVip", Stringa, RadiceHelp & "::/AssegnaLatiPPSM.htm", 1, Testo)
                    If Ris = 0 Then
                        Apparecchio.NumeroLati = 0
                        Exit Sub
                    End If
                    System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
                    Genmem.Lato = Ris
                    kLato = Ris
                End If
            Case 1
                kLato = Genmem.Lato
            Case 2
                kLato = Genmem.Lato
            Case 3
                kLato = Genmem.Lato
            Case 4
                kLato = 0
        End Select
    End Sub
    Private Sub CercaTirGua1(ByRef Tirante As Grafica.clsTirante)
        Tirante = Apparecchio.CercaBul(O, Dinst, DBul)
        Guarn = Apparecchio.CercaGuar(O)
    End Sub
    Private Sub Membratura(ByVal Tipo As Short)
        CercaLato()
        jInvolucr = Config(kLato).Ninvolucri + 1
        InseElemento((kLato))
        Involucr(kLato, jInvolucr).Mark = Trim(Genmem.Denom)
        Involucr(kLato, jInvolucr).Tipo = Tipo
        Matdim(Involucr(kLato, jInvolucr).indice(1 - 1)).Indmat = Genmem.Indmat1
        Matdim(Involucr(kLato, jInvolucr).indice(1 - 1)).RecupMat(clsInizio.Archdir)
        Involucr(kLato, jInvolucr).MATE = Matdim(Involucr(kLato, jInvolucr).indice(1 - 1)).MatStr
        Cercanome = New clsCercaNome
        Cercanome.kLato = kLato
        Cercanome.jInvolucr = jInvolucr
        ElencoInvolucri.Add(Cercanome, Trim(Genmem.Denom))
    End Sub
    Public Sub ReTransWND()
        Dim Cercanome As clsCercaNome
        Dim Res As Boolean
        If ElencoInvolucri Is Nothing Then Exit Sub
        Monitor.Motore.ProgrInizio("", "Generazione apparecchio in formato PPSM")
        NonPrimoGiro = False
        Do
            continua = False
            For Each Cercanome In ElencoInvolucri
                jCV = jCV + 1
                kLato = Cercanome.kLato
                jInvolucr = Cercanome.jInvolucr
                kNozzle = Cercanome.kNozzle
                Monitor.Motore.Avanzamento = jCV * 100 / ElencoInvolucri.Count()
                If kNozzle = 0 Then
                    Monitor.Motore.AvanzTesto = "Membratura in elaborazione:" & vbCrLf & GlobalRoutines.Adjust(Involucr(kLato, jInvolucr).Mark, 25)
                    System.Windows.Forms.Application.DoEvents()
                    Res = ConvertiInvolucro()
                    If Not Res Then Exit Do
                Else
                    Monitor.Motore.AvanzTesto = "Membratura in elaborazione:" & vbCrLf & GlobalRoutines.Adjust(Nozzles(kLato, kNozzle).Mark, 25)
                    System.Windows.Forms.Application.DoEvents()
                    ConvertiNozzle()
                End If
            Next Cercanome
            NonPrimoGiro = True
        Loop While continua
Cont:
        Monitor.Motore.ProgrAmmazza()
    End Sub
    Public Function ConvertiInvolucro() As Boolean
        Dim Cil As Grafica.Cilindro
        Dim Fon As Grafica.Fondo
        Dim Con As Grafica.Cono
        Dim Fl As Grafica.Flangione
        Dim Tirante As Grafica.clsTirante
        Dim Guarn As Grafica.clsGuarniz
        Dim Tubi As Grafica.Tubi
        Dim Fascio As Grafica.Fascio
        Dim File As String = ""
        Dim PTs As Grafica.Piastrone
        Dim Testo As String = ""
        Dim Nuovo As Boolean
        Dim i As Short
        Dim objTraccia As traccia.clsTracciatura
        Dim Res As Short
        ConvertiInvolucro = True
        Try
            With Involucr(kLato, jInvolucr)
                Select Case .Tipo
                    Case 0
                        If PT Is Nothing And kLato = 2 Then
                            jCV = jCV - 1
                            continua = True : Exit Function
                        End If
                        If kLato = 2 Then
                            Select Case PT.SottoTipo
                                Case 6 'sandwitch
                                    If FlangCh Is Nothing Then
                                        jCV = jCV - 1
                                        continua = True : Exit Function
                                    End If
                                Case Else
                                    Stop
                            End Select
                        End If
                        Cil = Apparecchio.CercaElemento(Trim(.Mark))
                        Nuovo = False
                        If Cil Is Nothing Then
                            Libgra.GeneraOggetto(1, Cil)
                            Cil.GenMem.Denom = Trim(.Mark)
                            Cil.GenMem.Lato = kLato
                            Nuovo = True
                        ElseIf NonPrimoGiro Then
                            jCV = jCV - 1
                            Exit Function
                        End If
                        Cil.Diametro = .di
                        Cil.SpessBase = .Spess
                        Cil.SpessRive = .OS
                        If .L0 = 0 Then
                            Testo = "La lunghezza della membratura " & Trim(.Mark) & "risulta non definita." & vbCrLf
                            Testo = Testo & "Fornire un valore accettabile"
                            .L0 = GlobalRoutines.ValVir(InputBox(Testo, "Titolo", "     0.00"))
                        End If
                        Cil.Lunghezza = .L0
                        Cil.GenMem.Indmat1 = Matdim(.indice(1 - 1)).Indmat
                        Cil.Leggi(Monitor.Motore.Inizio.DiscoTem, CShort(0))
                        If Nuovo Then
                            O = Cil
                            PosStd()
                            Traduci()
                        End If
                    Case 1
                        If PT Is Nothing And kLato = 2 Then
                            jCV = jCV - 1
                            continua = True : Exit Function
                        End If
                        If kLato = 2 Then
                            Select Case PT.SottoTipo
                                Case 6 'sandwitch
                                    If FlangCh Is Nothing Then
                                        jCV = jCV - 1
                                        continua = True : Exit Function
                                    End If
                                Case Else
                                    Stop
                            End Select
                        End If
                        Fon = Apparecchio.CercaElemento(Trim(.Mark))
                        Nuovo = False
                        If Fon Is Nothing Then
                            Libgra.GeneraOggetto(3, Fon)
                            Fon.GenMem.Denom = Trim(.Mark)
                            Fon.GenMem.Lato = kLato
                            Nuovo = True
                        ElseIf NonPrimoGiro Then
                            jCV = jCV - 1
                            Exit Function
                        End If
                        Fon.Diametro = .di
                        Fon.SpessBase = .Spess
                        Fon.SpessRive = .OS
                        Fon.GenMem.Indmat1 = Matdim(.indice(1 - 1)).Indmat
                        Select Case .ms
                            Case 1
                                Fon.GenMem.Tipo = 3
                            Case 3, 4, 5
                                Fon.GenMem.Tipo = 4
                            Case 7
                                Fon.GenMem.Tipo = 5
                                Fon.Piedritto = System.Math.Sqrt(.L0 ^ 2 - (Fon.Diametro / 2) ^ 2)
                        End Select
                        Fon.Leggi(Monitor.Motore.Inizio.DiscoTem, CShort(0))
                        If Nuovo Then
                            O = Fon
                            PosStd()
                            Traduci()
                        End If
                    Case 2, 3 'conoide
                        If PT Is Nothing And kLato = 2 Then
                            jCV = jCV - 1
                            continua = True : Exit Function
                        End If
                        Con = Apparecchio.CercaElemento(Trim(.Mark))
                        Nuovo = False
                        If Con Is Nothing Then
                            Libgra.GeneraOggetto(6, Con)
                            Con.GenMem.Denom = Trim(.Mark)
                            Con.GenMem.Lato = kLato
                            Nuovo = True
                        ElseIf NonPrimoGiro Then
                            jCV = jCV - 1
                            Exit Function
                        End If
                        Con.Dgran = .di
                        Con.Dpicc = .dns
                        Con.RagG = .H0
                        Con.RagP = .L0
                        Con.AlfaCon = .R0
                        Con.SpessBase = .Spess
                        Con.SpessRive = .OS
                        Con.GenMem.Indmat1 = Matdim(.indice(1 - 1)).Indmat
                        Con.Leggi(Monitor.Motore.Inizio.DiscoTem, CShort(0))
                        If Nuovo Then
                            O = Con
                            PosStd()
                            Traduci()
                        End If
                    Case 5 'flangioni / anelli fucinati
                        If PT Is Nothing And kLato = 2 Then
                            jCV = jCV - 1
                            continua = True : Exit Function
                        End If
                        Fl = Apparecchio.CercaElemento(Trim(.Mark))
                        If Fl Is Nothing Then
                            Libgra.GeneraOggetto(11, Fl)
                            Fl.GenMem.Denom = Trim(.Mark)
                            Fl.GenMem.Lato = kLato
                            Nuovo = True
                        ElseIf NonPrimoGiro Then
                            jCV = jCV - 1
                            Exit Function
                        End If
                        If kLato = 2 Then FlangCh = Fl
                        Fl.GenMem.Indmat1 = Matdim(.indice(1 - 1)).Indmat
                        CercaTirGua(Fl, Tirante, Guarn)
                        With CType(objMemb(.IndObject), wn_flan)
                            Fl.DiamExt = .Mp(3)
                            Fl.DiamInt = .Mp(6)
                            Fl.g0 = .Mp(7)
                            Fl.g1 = .Mp(8)
                            Fl.SpessBase = .Mp(9) + Fl.SpessGra
                            Fl.H = .Mp(10)
                            If BullDistinti Or kLato = 1 Then
                                Tirante.StandardTir.Xfil = .Mem.XFil
                                Tirante.GenMem.Qta = .Mp(13)
                                Tirante.GenMem.Indmat1 = Matdim(Involucr(kLato, jInvolucr).indice(2 + (kLato - 1) * 4 - 1)).Indmat
                                Tirante.Dinst = .Mp(4)
                                Tirante.StandardTir.Diam = .Mp(14)
                                Tirante.Lunghezza = 2 * Fl.SpessBase + 2 * Tirante.StandardTir.Diam
                                Tirante.Leggi(Monitor.Motore.Inizio.DiscoTem, CShort(0))
                            End If
                            Guarn.Largh = .Mp(26)
                            Guarn.DiamMed = .Mp(5)
                            Guarn.Spess = 3
                            Guarn.StandardGua.Class = 0
                            Guarn.StandardGua.Face = 0
                            Guarn.StandardGua.Formula = 0
                            Guarn.StandardGua.m = 0
                            Guarn.StandardGua.y = 0
                            Guarn.GenMem.Lato = kLato
                            Guarn.Leggi(Monitor.Motore.Inizio.DiscoTem, CShort(0))
                        End With
                        Fl.Leggi(Monitor.Motore.Inizio.DiscoTem, CShort(0))
                        If Nuovo Then
                            O = Fl
                            PosStd()
                            Traduci()
                        End If
                    Case 6 'PT
                        PT = Apparecchio.CercaElemento(Trim(.Mark))
                        Nuovo = False
                        If PT Is Nothing Then
                            Libgra.GeneraOggetto(12, PT)
                            PT.GenMem.Denom = Trim(.Mark)
                            PT.GenMem.Lato = kLato
                            Nuovo = True
                        ElseIf NonPrimoGiro Then
                            jCV = jCV - 1
                            ' continua = True
                            Exit Function
                        End If
                        PT.GenMem.Indmat1 = Matdim(.indice(1 - 1)).Indmat
                        Piastra = objMemb(.IndObject)
                        PT.DiamExt = Piastra.TSheDes
                        PT.SpessBase = Piastra.TSheThk
                        jPiastra = jInvolucr
                        If Piastra.TipoPT = 1 Then 'UTEMA
                            Select Case Piastra.bdice
                                Case 0 : PT.SottoTipo = 6
                                    PT.H1 = (Piastra.TSheThk - Piastra.TExtThk) / 2
                                    PT.B1 = PiastraSU.DiamMed - PiastraSU.Largh - 6
                                    PT.H2 = PT.H1
                                    PT.B2 = PT.B1
                                    O = PT
                                    PosStd()
                                    CType(CType(O.Genmem, clsGenMem), clsGenMem).posizione.Quota = "Fa"
                                    CType(CType(O.Genmem, clsGenMem), clsGenMem).posizione.SuChi = PiastraSU
                                Case 1 : PT.SottoTipo = 3
                                    'Stop
                                Case 2 : PT.SottoTipo = 7
                                    'Stop
                            End Select
                        ElseIf Piastra.TipoPT = 2 Then
                            Select Case CType(Piastra.Piastra, wn_FTC).Rear
                                Case 1, 2
                                    SecondaPiastra = True
                                    Select Case CType(Piastra.Piastra, wn_FTC).Flangiata(1)
                                        Case -1 : PT.SottoTipo = 3
                                        Case 0 : PT.SottoTipo = 1
                                        Case 1 : PT.SottoTipo = 7
                                        Case 2 : PT.SottoTipo = 4 'Biflangiata????
                                    End Select
                                Case 3
                                    SecondaPiastra = False
                                    If CType(Piastra.Piastra, wn_FTC).Gasketed(1) Then PT.SottoTipo = 4 Else PT.SottoTipo = 1
                            End Select
                        Else
                            Stop
                            '1 "2 codoli esterni"
                            '2 "1 int. / 1 est."
                            '3 "saldata LM + bulloni"
                            '4 "senza cod., gr.Sx/Dx"
                            '5 "s.cod. e 1/2 gr.a Sx"
                            '6 "sandwitch+collar blt"
                            '7 "saldata LC + bulloni"
                        End If
                        PT.Leggi(Monitor.Motore.Inizio.DiscoTem, CShort(0))
                        If Nuovo Then
                            O = PT
                            ' GoSub PosStd
                            Traduci()
                        End If
                    Case 7 'tubi
                        If PT Is Nothing Then
                            jCV = jCV - 1
                            continua = True : Exit Function
                        End If
                        Tubi = Apparecchio.CercaElemento(Trim(.Mark))
                        Nuovo = False
                        If Tubi Is Nothing Then
                            Fascio = Apparecchio.CercaFascio()
                            If Fascio Is Nothing Then
                                Libgra.GeneraOggetto(26, Fascio)
                                Fascio.GenMem.Denom = "Fascio tubiero"
                                Fascio.GenMem.Lato = kLato
                                Fascio.GenMem.posizione.SuChi = PT
                            End If
                            With Fascio
                                If Piastra.TipoPT = 1 Then
                                    .TipoFascio = 3
                                ElseIf Piastra.TipoPT = 2 Then
                                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.Piastra.Rear. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                                    .TipoFascio = Piastra.Piastra.Rear
                                Else
                                    Stop
                                End If
                                i = 8
                                If .TipoFascio = 3 Then i = 9
                            End With
                            Libgra.GeneraOggetto(i, Tubi)
                            Tubi.GenMem.Denom = Trim(.Mark)
                            Tubi.GenMem.Lato = kLato
                            O = Tubi
                            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto ctype(O.Genmem,clsGenmem). Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                            CType(O.Genmem, clsGenMem).posizione.SuChi = Fascio
                            'GoSub PosStd
                            'GoSub Traduci
                            Nuovo = True
                            File = GenFile(jInvolucr)
                            If Not File = "" Then
                                objTraccia = New traccia.clsTracciatura
                                objTraccia.DoveMotore = Monitor.Motore
                                Res = objTraccia.Esegui(1, File)
                                If Res = 1 Then
                                    '   messagebox.show "Il file " + File + " non è stato trovato: accedere alla tracciatura nelle finestra relativa ai dati sui tubi di scambio", vbCritical
                                ElseIf Res = 2 Then
                                    '   messagebox.show "La tracciatura " + File + " non possiede i dati finali: accedere alla tracciatura nelle finestra relativa ai dati sui tubi di scambio", vbCritical
                                Else
                                    Fascio.LayOut = objTraccia
                                End If
                            End If
                            Fascio.Tubi_Renamed = Tubi
                        ElseIf NonPrimoGiro Then
                            jCV = jCV - 1
                            Exit Function
                        End If
                        Fascio.Leggi(Monitor.Motore.Inizio.DiscoTem, CShort(0))
                        If Nuovo Then
                            O = Fascio
                            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto ctype(O.Genmem,clsGenmem). Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                            CType(O.Genmem, clsGenMem).posizione.SuChi = PT
                            PosStd()
                            Traduci()
                            Tubi.GenMem.PosDis = Libgra.SetPosizN
                        End If
                        If SecondaPiastra Then
                            Libgra.GeneraOggetto(12, PTs)
                            PTs.GenMem.Denom = Trim(PT.GenMem.Denom) & " B"
                            PTs.GenMem.Indmat1 = Matdim(Involucr(3, jPiastra).indice(1 - 1)).Indmat
                            Piastra = objMemb(Involucr(3, jPiastra).IndObject)
                            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.Piastra.Rear. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                            Select Case Piastra.Piastra.Rear
                                Case 1, 2
                                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.Piastra.Flangiata. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                                    Select Case Piastra.Piastra.Flangiata(2)
                                        Case -1 : PTs.SottoTipo = 3
                                        Case 0 : PTs.SottoTipo = 1
                                        Case 1 : PTs.SottoTipo = 7
                                        Case 2 : PTs.SottoTipo = 4 'Biflangiata????
                                    End Select
                                Case 3
                                    Stop
                            End Select
                            PTs.Leggi(Monitor.Motore.Inizio.DiscoTem, CShort(0))
                            O = PTs
                            PosStd()
                            Traduci()
                        End If
                    Case 8 'dilatatori
                        MessageBox.Show("Dilatatori da programmare in ConvertiInvolucro")
                        ConvertiInvolucro = False
                        Exit Function
                    Case 9 ' setti
                        MessageBox.Show("Setti da programmare in ConvertiInvolucro")
                        ConvertiInvolucro = False
                        Exit Function
                End Select
            End With
        Catch e As Exception
            Testo = "Durante la conversione dell'involucro (" & Trim(Str(kLato)) & "," & Trim(Str(jInvolucr)) & ")."
            Testo = Testo + vbCrLf + e.Message + vbCrLf + e.StackTrace
            MessageBox.Show(Testo)
            ConvertiInvolucro = False
        End Try
    End Function
    Private Sub Scelta()
        Dim i As Integer
        nposs = Candidati.Count()
        Dim g As clsGenMem = CType(O.Genmem, clsGenMem)
        If nposs > 1 Then
            Aiuto = ""
            Dim Testo As String = "Selezionare la membratura (ed eventualmente l'estremità)|sulla quale va posizionata la nuova membratura|("
            Testo = Testo & Trim(g.Denom) & ")."
            For i = 1 To nposs
                Strin1(i) = Trim(Candidati.Item(i).Genmem.Denom)
                If Len(NearFar.Item(i)) > 0 Then Strin1(i) = Strin1(i) & " (" + NearFar.Item(i) + ")"
            Next
            nposs = Monitor.Motore.Quale(nposs, "Costruzione apparecchio", Strin1, Aiuto, 1, Testo, RoutBase1.ChiaviMess.MessOKCancel, IDH_PPSM_1)
            If nposs > 0 Then
                g.posizione.Quota = NearFar.Item(nposs)
                SuChi = Candidati.Item(nposs).Genmem
                If g.posizione.Quota = "Near" Then
                    g.posizione.DirDiritta = "=-"
                Else
                    g.posizione.DirDiritta = "=+"
                End If
            Else
                SuChi = Nothing ' era 1
            End If
        ElseIf nposs = 1 Then
            g.posizione.Quota = NearFar.Item(nposs)
            SuChi = Candidati.Item(nposs).Genmem
            If g.posizione.Quota = "Near" Then
                g.posizione.DirDiritta = "=-"
            Else
                g.posizione.DirDiritta = "=+"
            End If
        Else
            SuChi = Apparecchio.Elementi(0).Genmem  ' era 1
        End If
    End Sub
    Private Sub FaiTir(ByRef Fl As Grafica.Flangione, ByRef Tirante As Grafica.clsTirante)
        Tirante = Apparecchio.CercaBul(Fl, Dinst, DBul)
        If Tirante Is Nothing Then
            Libgra.GeneraOggetto(13, Tirante)
            Tirante.GenMem.Denom = "TIR su " & Trim(Involucr(kLato, jInvolucr).Mark)
            Tirante.GenMem.posizione.SuChi = Fl
            O = Tirante
            PosStd()
            Traduci()
        End If
    End Sub
    Private Sub Traduci()
        Candidati = New Collection 'Candidati a sopportare O
        NearFar = New Collection
        Dim i As Short
        Select Case CType(O.Genmem, clsGenMem).Tipo
            Case 1 To 7, 34
                For i = 0 To Apparecchio.Elementi.Count - 1
                    O1 = Apparecchio.Elementi(i)
                    If Not O1 Is O And ((O1.Genmem.Tipo > 0 And O1.Genmem.Tipo < 8) Or O1.Genmem.Tipo = 11) And O1.Genmem.Lato = CType(O.Genmem, clsGenMem).Lato Then
                        Select Case CType(O1.genmem, clsGenMem).Tipo
                            Case 3, 4, 5 'fondi
                                Candidati.Add(O1)
                                NearFar.Add(CType(O.Genmem, clsGenMem).posizione.Quota)
                            Case 11 ' flangioni
                                Candidati.Add(O1)
                                NearFar.Add(CType(O.Genmem, clsGenMem).posizione.Quota)
                                CType(O.Genmem, clsGenMem).posizione.DirDiritta = "=-"
                            Case 1, 2, 34 'cilindri
                                Candidati.Add(O1)
                                NearFar.Add("Near")
                                Candidati.Add(O1)
                                NearFar.Add("Far")
                            Case 6, 7
                                Candidati.Add(O1)
                                NearFar.Add("Near")
                                Candidati.Add(O1)
                                NearFar.Add("Far")
                        End Select
                    End If
                Next i
                Scelta()
            Case 11 'flangioni
                If kLato = 1 Then
                    For i = 0 To Apparecchio.Elementi.Count - 1
                        O1 = Apparecchio.Elementi(i)
                        If Not O1 Is O And (O1.Genmem.Tipo > 0 And O1.Genmem.Tipo < 8 Or O1.Genmem.Tipo = 28) Then
                            Select Case O1.genmem.tipo

                            End Select
                            If O1.Genmem.Tipo > 2 And O1.Genmem.Tipo < 6 Then 'fondi
                                Candidati.Add(O1)
                                NearFar.Add("")
                            ElseIf O1.Genmem.Tipo = 28 Then 'guarnizione
                                Candidati.Add(O1)
                                NearFar.Add("Far")
                            Else
                                Candidati.Add(O1)
                                NearFar.Add("Near")
                                Candidati.Add(O1)
                                NearFar.Add("Far")
                            End If
                        End If
                    Next i
                    Scelta()
                Else
                    SuChi = PiastraSU.Genmem
                End If
            Case 12 'PT
            Case Else
                If CType(O.Genmem, clsGenMem).posizione.SuChi Is Nothing Then
                    SuChi = Apparecchio.Elementi(0) ' era 1
                Else
                    SuChi = CType(O.Genmem, clsGenMem).posizione.SuChi.Genmem
                End If
        End Select
        Libgra.InitPosSpaN(SuChi, CType(O.Genmem, clsGenMem))
        CType(O.Genmem, clsGenMem).PosDis = Libgra.SetPosizN
        Libgra.AggiornaApparecchio(O)
        Libgra.PostChain(CType(O.Genmem, clsGenMem))
    End Sub
    Private Sub PosStd()
        With CType(O.Genmem, clsGenMem).posizione
            .Quota = "Near"
            .Raggio = "N.A."
            .DirDiritta = "=+"
            .DirTraversa = "Au"
            .Anomal = "N.A."
        End With
    End Sub
    Private Sub CercaTirGua(ByRef Fl As Grafica.Flangione, ByRef Tirante As Grafica.clsTirante, _
                            ByRef Guarn As Grafica.clsGuarniz)
        BullDistinti = False
        If kLato = 2 Then
            If PT.SottoTipo = 6 And Piastra.BullDistinti Then
                BullDistinti = True
                FaiTir(Fl, Tirante)
            End If
        Else
            FaiTir(Fl, Tirante)
        End If
        Guarn = Apparecchio.CercaGuar(Fl)
        If Guarn Is Nothing Then
            Libgra.GeneraOggetto(28, Guarn)
            Guarn.GenMem.Denom = "GSK su " & Trim(Involucr(kLato, jInvolucr).Mark)
            O = Guarn
            If kLato = 1 Then
                Guarn.GenMem.posizione.SuChi = Fl
                PosStd()
            Else
                Guarn.GenMem.posizione.SuChi = PT
                PosStd()
                CType(O.Genmem, clsGenMem).posizione.Quota = "Lato C"
            End If
            Traduci()
            PiastraSU = O
        End If
    End Sub
    Public Sub ConvertiNozzle()
        Dim Nuovo As Boolean
        Dim i As Short
        Dim O As Object = Nothing
        Dim iDisp As Short
        Dim beta As Single
        If PT Is Nothing And kLato = 2 Then
            jCV = jCV - 1
            continua = True : Exit Sub
        End If
        If kLato = 2 Then
            Select Case PT.SottoTipo
                Case 6 'sandwitch
                    If FlangCh Is Nothing Then
                        jCV = jCV - 1
                        continua = True : Exit Sub
                    End If
                Case Else
                    Stop
            End Select
        End If
        With Nozzles(kLato, kNozzle)
            Select Case .Rati
                Case 0
                    MessageBox.Show("errore perché vuole un Noz")
                    'Set Tronch = Apparecchio.CercaElemento(Trim$(.Mark))
                    'Tronch.Diametro = .DiIn
                    'Tronch.SpessBase = .Spess
                Case Else
                    Noz = Apparecchio.CercaElemento(Trim(.Mark))
                    If Noz Is Nothing Then
                        i = .InvolucroSU
                        If i > 0 Then
                            O = Apparecchio.CercaElemento(Trim(Involucr(kLato, i).Mark))
                        Else
                            O = Apparecchio.CercaElemento(Trim(Nozzles(kLato, -i).Mark))
                        End If
                        If O Is Nothing Then
                            jCV = jCV - 1
                            continua = True : Exit Sub
                        End If
                        Libgra.GeneraOggetto(10, Noz)
                        Noz.GenMem.Denom = Trim(.Mark)
                        Nuovo = True
                        If i > 0 Then
                            With Noz.GenMem.posizione
                                Select Case Involucr(kLato, i).Tipo
                                    Case 0 ' su cilindro
                                        If Nozzles(kLato, kNozzle).beta < 90 Then 'inclinato su asse
                                        ElseIf Nozzles(kLato, kNozzle).DCL > 0 Then  'offset rispetto ad asse
                                        Else 'standard
                                            .Quota = "In Mezzo"
                                            .Raggio = "Ri"
                                            .DirDiritta = "Na"
                                            .DirTraversa = "Au"
                                            .Anomal = "+N" '"+N" ?
                                        End If
                                    Case 1 'su fondo
                                        jInvolucr = i
                                        Call RetrDisp(kNozzle, iDisp)
                                        .Raggio = "Ri"
                                        .DirTraversa = "Au"
                                        Select Case iDisp
                                            Case 0 : MessageBox.Show("Errore 1 in ConvertiNozzle")
                                            Case 1 ' "assiale centrato            "
                                                .Quota = " 0"
                                                .DirDiritta = "=+"
                                            Case 2 ' "radiale rispetto al fondo   "
                                                .DirDiritta = Str(Nozzles(kLato, kNozzle).beta)
                                                beta = Nozzles(kLato, kNozzle).beta * pi / 180
                                                .Anomal = Str(Nozzles(kLato, kNozzle).Anomal)
                                                'bisogna calcolare il disassamento come r sinbeta
                                            Case 3 ' "radiale rispetto al cilindro"
                                                .DirDiritta = "90"
                                                .Anomal = Str(Nozzles(kLato, kNozzle).Anomal)
                                                .Quota = "Sul collo"
                                            Case 4 ' "assiale decentrato          "
                                                .Quota = Str(Nozzles(kLato, kNozzle).DCL)
                                                .Anomal = Str(Nozzles(kLato, kNozzle).Anomal)
                                        End Select
                                    Case 2, 3
                                        MessageBox.Show("da fare coni e conoidi")
                                    Case Else
                                        MessageBox.Show("da fare" & Str(Involucr(kLato, i).Tipo))
                                End Select
                            End With
                        Else 'bocchello su bocchello
                            With Noz.GenMem.posizione
                                .Quota = "In Mezzo"
                                .Raggio = "Ri"
                                .DirDiritta = "Na"
                                .DirTraversa = "Au"
                                .Anomal = "+N"
                            End With
                        End If
                        Noz.Sporgenza = .LXdisp + .DiOn / 4
                        If .DiOn > Noz.Sporgenza Then Noz.Sporgenza = .DiOn
                        If i > 0 Then
                            Noz.Randa = Involucr(kLato, i).di / 2
                        Else
                            Noz.Randa = Nozzles(kLato, -i).DiIn / 2
                        End If
                    ElseIf NonPrimoGiro Then
                        jCV = jCV - 1
                        Exit Sub
                    End If
                    If .indiceF = 0 Then .indiceF = 1
                    Noz.Standard.TabFlan = .indiceF
                    Noz.GenMem.Indmat1 = Matdim(.IndexF).Indmat
                    Select Case .Tipo
                        Case "WN  "
                            Noz.TipoF = 4
                            Noz.Standard.K3 = 1
                        Case "WN1 "
                            Noz.TipoF = 3
                            Noz.Standard.K3 = 1
                        Case "LWN "
                            Noz.TipoF = 2
                            Noz.Standard.K3 = 4
                        Case "LWN1"
                            'MessageBox.Show("forse non standard")
                            Noz.TipoF = 1
                            Noz.DiamRinf = Noz.DiamInt + 2 * .LX
                            Noz.AltzRinf = .HX
                            Noz.Standard.K3 = 4
                        Case "LWN2"
                    End Select
                    Noz.Standard.carica((clsInizio.DiscoRam))
                    Noz.Standard.SetDiam(Val(CStr(.DiaN)))
                    Noz.Standard.SetRating(.Rati)
                    Noz.DiamInt = .DiIn
                    If Not O Is Nothing Then
                        Libgra.InitPosSpaN(CType(O.Genmem, clsGenMem), Noz.GenMem)
                    ElseIf Not Nuovo Then
                        Stop
                    Else
                        Stop
                    End If
                    Noz.GenMem.PosDis = Libgra.SetPosizN
                    Noz.Leggi(Monitor.Motore.Inizio.DiscoTem, CShort(0))
                    Select Case .Tipo
                        Case "WN  "
                            SetTronch()
                        Case "WN1 "
                            SetTronch()
                            SetPad()
                        Case "LWN "
                        Case "LWN1"
                        Case "LWN2"
                    End Select
                    Libgra.AggiornaApparecchio(Noz)
                    Libgra.PostChain(Noz.GenMem)
            End Select
        End With
        Exit Sub
    End Sub
    Private Sub SetPad()
        With Noz.Pad
            .GenMem.Denom = "Pad su " & Trim(Noz.GenMem.Denom)
            .DiamExt = Nozzles(kLato, kNozzle).Padd
            .Spess = Nozzles(kLato, kNozzle).PadT
            .GenMem.Indmat1 = Matdim(Nozzles(kLato, kNozzle).IndiceP).Indmat
        End With
    End Sub
    Private Sub SetTronch()
        With Noz.Tronchetto
            .GenMem.Denom = "Tr. su " & Trim(Noz.GenMem.Denom)
            .GenMem.Indmat1 = Matdim(Nozzles(kLato, kNozzle).indice).Indmat
        End With
    End Sub
    Public Sub SalvaCome()
        Dim n, nn As Short
        If clsInizio.LavoriSciolti Then
            With mioApert.CommonDialog2
                .Filter = "Calcoli a codice (*.VIP)|*.VIP"
                .InitialDirectory = clsInizio.Datidir
                On Error GoTo ErrCD
                .ShowDialog()
                On Error GoTo 0
                icome = .FileName
            End With
        Else
            MessageBox.Show("Funzione non implementata per lavori a commessa")
            Exit Sub
            job = New RoutBase1.clsjob(Monitor.Motore)
            If Not job.Selezione Then icome = "" : Exit Sub
            With job.Comm
                If .indice > 0 Then
                    icome = Monitor.Motore.Inizio.Workdir & "\" & .Arch & gstrSEP_DIR & .Ind.Item(.indice).Data.File & ".VIP"
                    Config(0).Item = .Ind.Item(.indice).Data.Assieme
                Else
                    icome = ""
                    Config(0).Item = ""
                End If
            End With
        End If
        If Len(icome) = 0 Then Exit Sub
        nn = 1
        Do
            n = InStr(nn, icome, ".")
            If n = 0 Then Exit Do
            nn = n + 1
        Loop
        If nn > 1 Then icome = Left(icome, nn - 2)
        icome = icome & ".VIP"
        Call SalvaU()
        Aggiorna()
ResCD:
        Exit Sub
ErrCD:  Resume ResCD
    End Sub
    Public Function GenFile(ByRef i As Short) As String
        Dim File As String = ""
        With Involucr(3, i)
            If Len(.File) > 0 Then
                If Asc(.File) < 32 Then
                    CPath(File)
                Else
                    File = Trim(.File)
                End If
            Else
                CPath(File)
            End If
        End With
        GenFile = File
        Exit Function
    End Function
    Private Sub CPath(ByVal File As String)
        Dim Testo As String = "Impossibile procedere, poiché non è stata trovata" & vbCrLf
        Testo = Testo & "una tracciatura associata con l'elemento 'tubi'." & vbCrLf
        Testo = Testo & "Accedere alla finestra dati dei tubi di scambio."
        MessageBox.Show(Testo)
        File = ""
    End Sub
End Module