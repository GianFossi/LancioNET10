Option Strict Off
Option Explicit On
Module Selle
	'Sub SellFBM()
	'Dim Sella1 As Selle, Sella2 As Selle, SellaC As Selle
	'LungAPR = False
	'GoSub RiprDatis
	''IF Record(0).Ind = 0 THEN
	'RifaiSel:
	'If AddDistinta <= 102 Then
	'  GoSub PrFinSel
	'  If Risult%(1) Then XVec = 1 Else If Risult%(2) Then XVec = 2 Else XVec = 3
	'  If Risult%(4) Then XVec = XVec + 10
	'  If Risult%(4) Then Nfield% = 3 Else Nfield% = 2
	'  GoSub SeFinSel
	'End If
	'ifl = FreeFile
	'Open RTrim$(Archdir) + "\CALA13.DAT" For Input Shared As #ifl
	'For i = 1 To 7: Line Input #ifl, Stringa1$(i): Next
	'Close #ifl
	'SearchSella Sella1, Diam, 0, Stringa1$(1) '"SEM"
	'SearchSella Sella2, Diam, 0, Stringa1$(2) '"POR"
	'If Sella1.Diam = 0 Or Sella2.Diam = 0 Then
	'   GoSub NoSella
	'   If junk = 1 Then GoTo RifaiSel Else Record(0).Ind = 0: Exit Sub
	'End If
	'If Risult%(4) Then
	'   SearchSella SellaC, DiamC, 0, Stringa1$(1) ' "SEM"
	'   If SellaC.Diam = 0 Then
	'   GoSub NoSella
	'   If junk = 1 Then GoTo RifaiSel Else Record(0).Ind = 0: Exit Sub
	'End If
	'End If
	'Rec2Buf(0).Qta = myStr(1!, 3, 0, True)
	'Rec2Buf(0).MF$ = " LE "
	'Rec2Buf(0).MATE = Matdim(0).Mat
	'Rec2Buf(0).Tipo = 25
	'LTO# = GuardaPrezzo#(prezzo0&, prezzo1&, 0, 0, Sella1.Spes1, 0, "--", 0!, 0!, 1)
	'Rec2Buf(0).DIME = Str$(Sella1.Altz) + Stringa1$(3) + Str$(Sella1.Lung) + Stringa1$(3) + Str$(Sella1.Larg) + " (HxLxL)"
	'SetPosiz 0
	'PosDis = Rec2Buf(0).PosDis
	'For jRec = 0 To 1
	'   Record(jRec) = Rec2Buf(0)
	'   If jRec = 1 Then PosDis = PosDis + 1
	'   Record(jRec).PosDis = PosDis
	'   Lav(0).Ind(Lav(0).NumAs) = Lav(0).Ind(Lav(0).NumAs) + 1
	'   Record(jRec).Ind = Lav(0).Ind(Lav(0).NumAs)
	'If Risult%(1) Then     'due selle semplici
	'   Rec2Buf(3) = Record(jRec)
	'   peso! = Sella1.peso
	'   Conversion 3, 1!, peso!, peso! * 1.2, peso! * 0.2, prezzo0&, peso! * 1.2 * prezzo0&
	'   Record(jRec) = Rec2Buf(3)
	'   Record(jRec).Denom = Stringa1$(4) + Str$(Sella1.Serie)
	'   Record(jRec).NOTE = Stringa1$(5) + Str$(jRec + 1)
	'   Serie = Sella1.Serie
	'   Record(jRec).Dati(3) = 1
	'ElseIf Risult%(2) Then   'due selle portanti
	'   Rec2Buf(3) = Record(jRec)
	'   peso! = Sella2.peso
	'   Conversion 3, 1, peso!, peso! * 1.2, peso! * 0.2, prezzo0&, peso! * 1.2 * prezzo0&
	'   Record(jRec) = Rec2Buf(3)
	'   Record(jRec).Denom = Stringa1$(6) + Str$(Sella2.Serie)
	'   Record(jRec).NOTE = Stringa1$(5) + Str$(jRec + 1)
	'   Serie = Sella2.Serie
	'   Record(jRec).Dati(3) = 2
	'End If
	'Next
	'If Risult%(3) Then   'una semplice e una portante
	'   Rec2Buf(3) = Record(0)
	'   peso! = Sella1.peso
	'   Conversion 3, 1, peso!, peso! * 1.2, peso! * 0.2, prezzo0&, peso! * 1.2 * prezzo0&
	'   Record(0) = Rec2Buf(3)
	'   Record(0).Denom = Stringa1$(4) + Str$(Sella1.Serie)
	'   Record(0).NOTE = Stringa1$(5) + Str$(1)
	'   Serie = Sella1.Serie
	'   Record(0).Dati(3) = 1
	'   Rec2Buf(3) = Record(1)
	'   peso! = Sella2.peso
	'   Conversion 3, 1, peso!, peso! * 1.2, peso! * 0.2, prezzo0&, peso! * 1.2 * prezzo0&
	'   Record(1) = Rec2Buf(3)
	'   Record(1).Denom = Stringa1$(6) + Str$(Sella2.Serie)
	'   Record(1).NOTE = Stringa1$(5) + Str$(2) '"Sella nø 2"
	'   Serie = Sella2.Serie
	'   Record(1).Dati(3) = 2
	'End If
	'If Risult%(4) Then   'sella supporto cassa
	'   jRec3 = 2
	'   Record(jRec3) = Rec2Buf(0)
	'   Record(jRec3).PosDis = Record(1).PosDis + 1
	'   Lav(0).Ind(Lav(0).NumAs) = Lav(0).Ind(Lav(0).NumAs) + 1
	'   Record(jRec3).Ind = Lav(0).Ind(Lav(0).NumAs)
	'   Rec2Buf(3) = Record(jRec3)
	'   peso! = SellaC.peso
	'   Conversion 3, 1, peso!, peso! * 1.2, peso! * 0.2, prezzo0&, peso! * 1.2 * prezzo0&
	'   Record(jRec3) = Rec2Buf(3)
	'   Record(jRec3).Denom = Stringa1$(7) + Str$(SellaC.Serie)
	'   Record(jRec3).NOTE = Stringa1$(5) + Str$(3) '"Sella nø 3"
	'   Serie = SellaC.Serie
	'   Record(jRec3).Dati(3) = 1
	'   Record(jRec3 + 1).Ind = 0
	'Else
	'   Record(2).Ind = 0
	'End If
	'n = 1: If Risult%(4) Then n = 2
	'For i = 0 To n
	'   Display
	'   GoSub RecDatiS
	'   If i > 0 Then Record(i).Tipo = -Record(i).Tipo
	'If AddDistinta <= 102 Then
	'   Rec2Buf(3) = Record(i)
	'   VideoDati 3, True, k$
	'   If UCase$(k$) = "E" Then Record(0).Ind = 0: Exit Sub
	'   If UCase$(k$) = "R" Then Lav(0).Ind(Lav(0).NumAs) = Lav(0).Ind(Lav(0).NumAs) - 1: GoTo RifaiSel
	'   Record(i) = Rec2Buf(3)
	'End If
	'Next
	'Put #1, 1, Lav(0)
	'LungAPR = True
	'Exit Sub
	'RecDatiS:
	'Record(i).Dati(1) = Serie
	'If Mid$(Record(i).Denom, 8, 1) = "P" Then Record(i).Dati(1) = Record(i).Dati(1) + 100
	'Record(i).Dati(2) = Diam
	''Record(i).Dati(3) = '1 SEM o 2 POR per la specifica sella
	'Record(i).Dati(4) = XVec '1,2,3 11,12,13
	'Record(i).Dati(5) = DiamC
	'Record(i).Dati(5) = Set2
	'Record(i).Dati(6) = Set3
	'Record(i).Dati(7) = Spes1
	'Record(i).Dati(8) = Spes2
	'Record(i).Dati(9) = Spes3
	'Record(i).Dati(10) = Peso!
	'Record(i).posspa.BaricRel.Y = 2 / 3 * Sella1.Altz 'PROVVISORIO
	'Record(i).posspa.BaricRel.X = 0
	'Record(i).posspa.BaricRel.Z = 0
	'Return
	'RiprDatis:
	'If Record(0).Ind > 0 Then
	'Call RecupMat(0)
	'Classedim(0) = Matdim(0).Classe
	'Serie = Record(0).Dati(1)
	'Diam = Record(0).Dati(2)
	'XVec = Record(0).Dati(4)
	'If XVec > 9 Then Risult%(4) = True: X = XVec - 10 Else Risult%(4) = False: X = XVec
	'For i = 1 To 3: Risult%(i) = False: Next
	'Risult%(X) = True
	'DiamC = Record(0).Dati(5)
	'Vecchio = True
	'Else
	'Vecchio = False
	'End If
	'Return
	'PrFinSel:
	'ifl = FreeFile
	'Open RTrim$(Archdir) + "\CALA08.DAT" For Input Shared As #ifl
	'For i = 1 To 5: Line Input #ifl, Stringa1$(i): Next
	''Stringa1$(1) = "Due selle semplici"
	''Stringa1$(2) = "Due selle portanti"
	''Stringa1$(3) = "Una sempl. e una port."
	''Stringa1$(4) = "Sella supporto cassa"
	'If Not Vecchio Then Risult%(1) = True
	'Y = SwitchDati%(2, 4, Stringa1$(5), Stringa1$(), Risult%(), "", False)
	'Do
	'       Select Case Y
	'       Case 3
	'               'a$ = " Help non disponibile    |"
	'               junk = Alert(4, at1(2), 4, 3, 11, 48, at1(33), "", "")
	'       Case 2: WindowClose 2: Close #ifl: Exit Sub
	'       Case 1: WindowClose 2: Exit Do
	'       Case 11, 12, 13
	'         If Risult%(Y - 10) Then
	'            Risult%(1) = False: Risult%(2) = False: Risult%(3) = False
	'            Risult%(Y - 10) = True
	'         End If
	''       CASE 14  e' additiva la  sella sotto la cassa
	''         IF Risult%(y = 10) THEN
	''            Risult%(1) = TRUE: Risult%(2) = FALSE: Risult%(3) = FALSE
	''         END IF
	'       End Select
	'Y = SwitchDati%(0, 4, Stringa1$(5), Stringa1$(), Risult%(), "", False)
	'Loop
	'Return
	'SeFinSel:
	'For i = 1 To 4: Line Input #ifl, Stringa1$(i): Next
	''Stringa1$(1) = "Materiale Sella"
	''Stringa1$(2) = "Diametro mantello [mm]"
	''Stringa1$(3) = "Diametro cassa    [mm]"
	'If Not Vecchio Then
	'Risult$(1) = String$(25, Chr$(32))
	'Risult$(2) = String$(8, Chr$(32)): Risult$(3) = Risult$(2)
	'Else
	'Risult$(1) = Matdim(0).Mat
	'Risult$(2) = myStr(CSng(Diam), 8, 0, False)
	'Risult$(3) = myStr(CSng(DiamC), 8, 0, False)
	'End If
	'For i = 1 To 3: LungStr(i) = Len(Risult$(i)): Next
	'Classedim(0) = 1
	'Y = InputDati%(2, Nfield%, Stringa1$(4), Stringa1$(), Risult$(), LungStr())
	'Do
	'Select Case Y
	'    Case -3
	'               'a$ = " Clickando su alcuni dei campi della | finestra sottostante si otiene |"
	'               'a$ = a$ + " una lista dei valori possibili. Cio' | vale in particolare per i materiali.|"
	'               junk = Alert(4, at1(59), 4, 3, 11, 48, at1(33), "", "")
	'    Case -2
	'               WindowClose 2: Exit Sub
	'    Case -1
	'               WindowClose 2: Exit Do
	'    Case 1
	'         DisplayMat Classedim(0), 0
	'         Risult$(1) = Matdim(0).Mat
	'    Case Else
	''         a$ = " Non e' previsto un menu | per questo valore. |"
	'        junk = Alert(4, at1(55), 4, 3, 11, 48, at1(33), "", "")
	'End Select
	'Y = InputDati%(0, Nfield%, Stringa1$(4), Stringa1$(), Risult$(), LungStr())
	'Loop
	'Rec2Buf(0).Indmat = Matdim(0).Ind
	'Diam = Val(Risult$(2))
	'DiamC = Val(Risult$(3))
	'Close #ifl
	'Return
	'NoSella:
	'     A$ = " Non esiste in libreria una sella adatta.|"
	'A$ = A$ + " Vuoi cambiare qualche dato o abbandonare? |"
	'          junk = Alert(4, A$, 4, 3, 11, 68, "Cambia", "Vai via", "")
	'Return
	'End Sub
	
	Sub SellFBM1()
		'On Local Error GoTo Err1
		'Dim Sella As Selle
		'If UBound(Record) < 36 Then ReDim Preserve Record(36) As RecAPR
		'jRec = 0
		'LungAPR = False
		'GoSub RiprDatis1
		'If AddDistinta <= 102 Then GoSub PrFinSel1
		'RifaiSel1: Sella.Diam = -1
		'SearchSella Sella, Int(Diam), Serie%, RTrim$(Risult$(2))
		'If Sella.Diam = 0 Then
		'   Sella.Diam = -1
		'   SearchSella Sella, Int(Diam), 0, RTrim$(Risult$(2))
		'End If
		'If Sella.Diam = 0 Then
		'   GoSub NoSella1
		'   If junk = 1 Then
		'      GoSub PrFinSel1
		'      GoTo RifaiSel1
		'   Else
		'      Record(0).Ind = 0: Exit Sub
		'   End If
		'Else
		'   Serie% = Sella.Serie
		'End If
		'If Hterra = 0 Then Hterra = Sella.Altz
		'If SpessRinf = 0 Then SpessRinf = Sella.Spes1
		'If Hsopra = 0 Then Hsopra = Sella.Altz
		'Rec2Buf(0).Qta = "   1"
		'Rec2Buf(0).MF$ = " LE "
		'Rec2Buf(0).MATE = Matdim(0).Mat
		'LTO# = GuardaPrezzo#(prezzo0&, prezzo1&, 0, 0, Sella.Spes1, 0, "--", 0!, 0!, 1)
		'Rec2Buf(0).DIME = Str$(Sella.Altz) + Stringa1$(3) + Str$(Sella.Lung) + Stringa1$(3) + Str$(Sella.Larg) + " (HxLxL)"
		'If Rec2Buf(0).Tipo <> -25 Then
		'   Call IncrRiga(0)
		'   Rec2Buf(0).Tipo = 25
		'End If
		'SetPosiz 0
		'PosDis = Rec2Buf(0).PosDis
		'Conversion 0, 1!, 0!, 0!, 0, prezzo0&, 0!
		'GoSub RecDatiS1
		'If AddDistinta <= 102 Then
		'   VideoDati 0, True, k$
		'   If k$ = "E" Or k$ = "e" Then Record(0).Ind = 0: Exit Sub
		'   If k$ = "R" Or k$ = "r" Then Lav(0).Ind(Lav(0).NumAs) = Lav(0).Ind(Lav(0).NumAs) - 1: GoTo RifaiSel1
		'End If
		'Record(0) = Rec2Buf(0)
		'GoSub Rinforzo
		'GoSub PiastraBase
		'If Tipo = 2 Then
		'   GoSub PiastraSopra
		'   GoSub PiastraLato
		'End If
		'GoSub Costole
		'GoSub Nervatura
		'Put #1, 1, Lav(0)
		'LungAPR = True
		'Exit Sub
		''-----------------------------------------------------------------
		'RecDatiS1:
		'Rec2Buf(0).Dati(1) = Serie%
		'Rec2Buf(0).Dati(2) = Diam
		'Rec2Buf(0).Dati(3) = Tipo '1 SEM o 2 POR
		'Rec2Buf(0).Dati(4) = XVec '1,2,3 11,12,13
		'Rec2Buf(0).Dati(5) = Hterra
		'Rec2Buf(0).Dati(6) = Hsopra
		'Rec2Buf(0).Dati(7) = Matdim(1).Ind
		'Rec2Buf(0).Dati(8) = SpessRinf
		'If Tipo = 1 Then Rec2Buf(0).Denom = "SELLA SEMPLICE serie " + Str$(Serie%) Else Rec2Buf(0).Denom = "SELLA PORTANTE serie " + Str$(Serie%)
		'Return
		'RiprDatis1:
		'If Record(0).Ind > 0 Then
		'Call RecupMat(2)
		'Classedim(0) = Matdim(0).Classe
		'Classedim(1) = Matdim(1).Classe
		'Serie% = Record(0).Dati(1)
		'Diam = Record(0).Dati(2)
		'Tipo = Record(0).Dati(3)
		'If Tipo = 1 Then Risult$(2) = "SEM" Else Risult$(2) = "POR"
		'XVec = Record(0).Dati(4)
		'Hterra = Record(0).Dati(5)
		'Hsopra = Record(0).Dati(6)
		'SpessRinf = Record(0).Dati(8)
		'Vecchio = True
		'Rec2Buf(0) = Record(0)
		'Else
		'Vecchio = False
		'End If
		'Return
		'PrFinSel1:
		'ifl = FreeFile
		'Open RTrim$(Archdir) + "\CALA12.Dat" For Input Shared As #ifl
		'For i = 1 To 14
		'   Line Input #ifl, Stringa1$(i)
		'Next
		'Close #ifl
		''Stringa1$(1) = "Materiale Sella"
		''Stringa1$(2) = "Tipo Sella"
		''Stringa1$(3) = "Diametro mantello"
		''Stringa1$(4) = "Materiale rinforzo"
		''Stringa1$(5) = "Spessore rinforzo"
		''Stringa1$(6) = "Altezza da terra"
		''Stringa1$(7) = "Altezza sopra"
		''Stringa1$(8) = "Serie standard"
		'If Not Vecchio Then
		'Risult$(1) = Space$(15)
		'Risult$(2) = Stringa1$(9) '"SEM"
		'Risult$(3) = Stringa1$(10) '"    0.0"
		'Risult$(4) = Risult$(1)
		'Risult$(5) = Stringa1$(10) '"0=Std."
		'Risult$(6) = Risult$(5): Risult$(7) = Risult$(5)
		'Risult$(8) = Stringa1$(11) '"0=Ind."
		'Classedim(0) = 1: Classedim(1) = 1
		'Else
		'Risult$(1) = Adjust(Matdim(0).Mat, 15)
		'If Tipo = 1 Then Risult$(2) = Stringa1$(9) Else Risult$(2) = Stringa1$(13)
		'Risult$(3) = myStr(Diam, 4, 1, False)
		'Risult$(4) = Adjust(Matdim(1).Mat, 15)
		'Risult$(5) = myStr(SpessRinf, 4, 1, False)
		'Risult$(6) = myStr(Hterra, 4, 1, False)
		'Risult$(7) = myStr(Hsopra, 4, 1, False)
		'Risult$(8) = myStr(CSng(Serie%), 5, 0, True)
		'End If
		'Nfield = 8
		'RifaiSel2:
		'For i = 1 To Nfield: LungStr(i) = Len(Risult$(i)): Next
		'Y = InputDati%(2, Nfield, Stringa1$(14), Stringa1$(), Risult$(), LungStr())
		'Do
		'Select Case Y
		'    Case -3
		'               'a$ = " Clickando su alcuni dei campi della | finestra sottostante si otiene |"
		'               'a$ = a$ + " una lista dei valori possibili. Cio' | vale in particolare per i materiali.|"
		'               junk = Alert(4, at1(59), 4, 3, 11, 48, at1(33), "", "")
		'    Case -2
		'               WindowClose 2: Exit Sub
		'    Case -1
		'               WindowClose 2: Exit Do
		'    Case 1
		'         DisplayMat Classedim(0), 0
		'         Risult$(1) = Matdim(0).Mat
		'    Case 4
		'         DisplayMat Classedim(1), 1
		'         Risult$(4) = Matdim(1).Mat
		'    Case 2
		'         Stringa(1) = "SEMPLICE": Stringa(2) = "PORTANTE"
		'         Tipo = Quale(2, "Tipo sella", Stringa(), "", Tipo)
		'         If Tipo = 0 Then Exit Sub
		'         Risult$(2) = Left$(Stringa(Tipo), 3)
		'    Case 8
		'         Stringa(1) = "Leggera ": Stringa(2) = "Media   ": Stringa(3) = "Pesante"
		'         Serie% = Quale(3, "Serie sella", Stringa(), "", Serie%)
		'         If Serie% = 0 Then Exit Sub
		'         Risult$(8) = myStr(CSng(Serie%), 5, 0, True)
		'    Case Else
		''         a$ = " Non e' previsto un menu | per questo valore. |"
		'        junk = Alert(4, at1(55), 4, 3, 11, 48, at1(33), "", "")
		'End Select
		'Y = InputDati%(0, Nfield, Stringa1$(14), Stringa1$(), Risult$(), LungStr())
		'Loop
		'Rec2Buf(0).Indmat = Matdim(0).Ind
		'Diam = Val(Risult$(3))
		'SpessRinf = Val(Risult$(5))
		'Hterra = Val(Risult$(6))
		'Hsopra = Val(Risult$(7))
		'If Left$(Risult$(2), 1) = "S" Then
		'   Tipo = 1
		'ElseIf Left$(Risult$(2), 1) = "P" Then
		'   Tipo = 2
		'Else
		'   Beep
		'   Risult$(2) = "???"
		'   GoTo RifaiSel2
		'End If
		'Return
		''------------------------------------------------
		'PiastraBase:
		'jRec = jRec + 1: PosDis = PosDis + 1
		'Record(jRec).Denom = "PIASTRA DI BASE"
		'Record(jRec).Tipo = -15
		'Record(jRec).DIME = "LAM. " + Str$(Sella.Lung) + " x " + Str$(Sella.Larg) + " sp." + Str$(Sella.Spes3)
		'Record(jRec).Indmat = Matdim(0).Ind
		'Record(jRec).Dati(1) = Sella.Spes3 'spessore
		'Record(jRec).Dati(3) = Sella.Larg 'altezza
		'Record(jRec).Dati(2) = Sella.Lung 'lunghezza
		'Record(jRec).Dati(6) = True 'Disegna
		'Record(jRec).PSP = Matdim(0).PSP
		'Record(jRec).MATE = Matdim(0).Mat
		'Record(jRec).Qta = "  1"
		'PNET = CSng(Sella.Spes3) * Sella.Larg * Sella.Lung * Matdim(0).PSP * EXP9
		'PLOR = CSng(Sella.Spes3) * (Sella.Larg + MargTag(Int(Sella.Spes3), Classedim(0))) * (Sella.Lung + MargTag(Int(Sella.Spes3), Classedim(0))) * Matdim(0).PSP * EXP9
		'PSFRI = PLOR - PNET
		'Rec2Buf(0) = Record(jRec)
		'Call IncrRiga(0)
		'Conversion 0, 1, PNET, PLOR, PSFRI, prezzo0&, LTO#
		'Rec2Buf(0).posspa.SuChi = Record(0).Ind
		'Rec2Buf(0).posspa.BaricRel.Y = Sella.Larg / 2
		'Rec2Buf(0).posspa.BaricRel.X = 0
		'Rec2Buf(0).posspa.BaricRel.Z = 0
		'Rec2Buf(0).posspa.Quota = Str$(Hterra - Sella.Spes3 / 2)
		'Rec2Buf(0).posspa.Raggio = Str$(Sella.Larg / 2)
		'Rec2Buf(0).posspa.Anomal = "-Nel foglio"
		'Rec2Buf(0).posspa.DirDiritta = "Opposta"
		'Rec2Buf(0).posspa.DirTraversa = "Auto"
		'GoSub VidStd
		'Return
		'NoSella1:
		'     A$ = " Non esiste in libreria una sella adatta.|"
		'A$ = A$ + " Vuoi cambiare qualche dato o abbandonare? |"
		'          junk = Alert(4, A$, 4, 3, 11, 68, "Cambia", "Vai via", "")
		'Return
		'PiastraSopra:
		'jRec = jRec + 1: PosDis = PosDis + 1
		'Record(jRec) = Record(jRec - 1)
		'Record(jRec).Denom = "PIASTRA SUPERIORE"
		'Rec2Buf(0) = Record(jRec)
		'Call IncrRiga(0)
		'Conversion 0, 1, PNET, PLOR, PSFRI, prezzo0&, LTO#
		'Rec2Buf(0).posspa.Quota = Str$(-(Hsopra - Sella.Spes3 / 2))
		'GoSub VidStd
		'Return
		'PiastraLato:
		'If Serie% = 1 Then Return
		'For i = -1 To 1 Step 2
		'  Spes = Sella.Spes3
		'  Alung = Hterra + Hsopra - 2 * Spes
		'  Alarg = Sella.Larg
		'  GoSub CostStd
		'  Record(jRec).Denom = "COSTOLA LATERALE"
		'  SpostY = Sella.Lung / 2 - 1.5 * Spes
		'  SpostT = SpostY
		'  GoSub IncrStd
		'  GoSub VidStd
		'Next
		'Return
		''--------------------------------------------------
		'Rinforzo:
		'jRec = jRec + 1: PosDis = PosDis + 1
		'Record(jRec).Denom = "RINFORZO SELLA "
		'Record(jRec).Tipo = -1: If Tipo = 1 Then Record(jRec).Tipo = -34
		'Record(jRec).Dati(1) = Sella.Larg
		'Record(jRec).Dati(2) = Diam
		'Record(jRec).Dati(3) = SpessRinf
		'For i = 5 To 11: Record(jRec).Dati(i) = 0: Next
		'Record(jRec).DIME = "íi" + Str$(Diam) + " sp." + Str$(SpessRinf) + " L." + Str$(Sella.Larg)
		'If Tipo = 1 Then
		'  Angolo = Sella.Alfa * PI / 180
		'  Record(jRec).Dati(8) = Angolo
		'  Svil = CInt((Diam + SpessRinf) / 2 * Angolo)
		'  Record(jRec).DIME = Record(jRec).DIME + " Sv" + Str$(Svil)
		'Else
		'  Angolo = 2 * PI
		'End If
		'Record(jRec).Indmat = Matdim(1).Ind
		'Record(jRec).PSP = Matdim(1).PSP
		'Record(jRec).MATE = Matdim(1).Mat
		'Record(jRec).Qta = "  1"
		'PNET = Angolo / 2 * (Diam + SpessRinf) * Sella.Larg * SpessRinf * Matdim(1).PSP * EXP9
		'PLOR = Angolo / 2 * (Diam + SpessRinf + MargTag(Int(SpessRinf), Classedim(1))) * (Sella.Larg + MargTag(Int(SpessRinf), Classedim(1))) * SpessRinf * Matdim(1).PSP * EXP9
		'PSFRI = PLOR - PNET
		'Rec2Buf(0) = Record(jRec)
		'Call IncrRiga(0)
		'Conversion 0, 1, PNET, PLOR, PSFRI, prezzo1&, LTO#
		'Rec2Buf(0).posspa.SuChi = Record(0).Ind
		'Rec2Buf(0).posspa.BaricRel.Y = Sella.Larg / 2
		'Rec2Buf(0).posspa.BaricRel.X = 0
		'Rec2Buf(0).posspa.BaricRel.Z = 0
		'If Tipo = 1 Then
		'Rec2Buf(0).posspa.BaricRel.Z = -Sin(Angolo / 2) * (Diam + SpessRinf) / 2 / (Angolo / 2)
		'End If
		'Rec2Buf(0).posspa.Quota = Str$(0)
		'Rec2Buf(0).posspa.Raggio = Str$(Sella.Larg / 2)
		'Rec2Buf(0).posspa.Anomal = "+Nel foglio"
		'Rec2Buf(0).posspa.DirDiritta = "Opposta"
		'Rec2Buf(0).posspa.DirTraversa = "Auto"
		'GoSub VidStd
		'Return
		''----------------------------------------------
		'Costole:
		'Spes = Sella.Spes2
		'Alarg = (Sella.Larg - Spes) / 2
		'For k = 1 To Tipo
		'For i = -1 To 1 Step 2
		'For j = -3 To 3
		'If j = 0 Then GoTo contj
		'Select Case Serie%
		'  Case 1: Spost = 0: If j <> 1 Then GoTo contj
		'  Case 2: Spost = Sella.Set1: If Abs(j) > 1 Then GoTo contj
		'  Case 3: Select Case j
		'              Case 1: Spost = Sella.Set1
		'              Case 2: Spost = Sella.Set2
		'              Case 3: Spost = Sella.Set3: If Spost = 0 Then GoTo contj
		'          End Select
		'End Select
		'If Spost > 0 Then Spost = Spost - Spes / 2
		'ang = asin(Spost / (Diam + 2 * Sella.Spes1) * 2)
		'Alung = Hterra - Sella.Spes3 - (Diam + 2 * Sella.Spes1) / 2 * Cos(ang)
		'If k = 2 Then Alung = Alung - Hterra + Hsopra
		'GoSub CostStd
		'Record(jRec).Denom = "COSTOLA"
		'SpostY = (Sella.Larg / 2 + Spes / 2) / 2
		'SpostT = Sqr(Spost * Spost + SpostY * SpostY)
		'anom = acos(SpostY / SpostT) * 180 / PI * Sgn(j)
		'If i = 1 Then anom = 180 - anom
		'GoSub IncrStd
		'Rec2Buf(0).posspa.Anomal = Str$(anom)
		'GoSub VidStd
		'contj: Next j
		'If Serie% = 1 Then Exit For
		'Next i
		'Next k
		'Return
		'CostStd:
		'  jRec = jRec + 1: PosDis = PosDis + 1
		'  Record(jRec) = Record(jRec - 1)
		'  Record(jRec).DIME = "LAM. " + Str$(Alung) + " x " + Str$(Alarg) + " sp." + Str$(Spes)
		'  Record(jRec).Dati(1) = Spes 'spessore
		'  Record(jRec).Dati(3) = Alung 'altezza
		'  Record(jRec).Dati(2) = Alarg 'lunghezza
		'  PNET = Spes * Alarg * Alung * Matdim(0).PSP * EXP9
		'  PLOR = Spes * (Alarg + MargTag(Int(Spes), Classedim(0))) * (Alung + MargTag(Int(Spes), Classedim(0))) * Matdim(0).PSP * EXP9
		'  PSFRI = PLOR - PNET
		'Return
		'IncrStd:
		'Rec2Buf(0) = Record(jRec)
		'Call IncrRiga(0)
		'Conversion 0, 1, PNET, PLOR, PSFRI, prezzo0&, LTO#
		'Rec2Buf(0).Tipo = -15
		'Rec2Buf(0).posspa.BaricRel.Y = Alung / 2
		'Rec2Buf(0).posspa.BaricRel.X = 0
		'Rec2Buf(0).posspa.BaricRel.Z = 0
		'Rec2Buf(0).posspa.SuChi = Record(0).Ind
		'Rec2Buf(0).posspa.Quota = Str$(Hterra - Sella.Spes3)
		'If k = 2 Then Rec2Buf(0).posspa.Quota = Str$(-Hsopra + Sella.Spes3)
		'Rec2Buf(0).posspa.Raggio = Str$(SpostT)
		'If i = -1 Then
		'Rec2Buf(0).posspa.Anomal = "Up"
		'ElseIf i = 1 Then
		'Rec2Buf(0).posspa.Anomal = "Down"
		'Else
		'Rec2Buf(0).posspa.Anomal = "N.A."
		'End If
		'Rec2Buf(0).posspa.DirDiritta = "=-"
		'If k = 2 Then Rec2Buf(0).posspa.DirDiritta = "=+"
		'Rec2Buf(0).posspa.DirTraversa = "Auto"
		'Return
		'VidStd:
		'Rec2Buf(0).PosDis = PosDis
		'If AddDistinta <= 102 Then
		'   VideoDati 0, True, k$
		'   If k$ = "E" Or k$ = "e" Then Record(jRec).Ind = 0: Exit Sub
		'   If k$ = "R" Or k$ = "r" Then Lav(0).Ind(Lav(0).NumAs) = Lav(0).Ind(Lav(0).NumAs) - 1: GoTo RifaiSel1
		'End If
		'Record(jRec) = Rec2Buf(0)
		'Record(jRec + 1).Ind = 0
		'Return
		''------------------------------------------------
		'Nervatura:
		'Spes = Sella.Spes2
		'Dim Recmod As RecAPRm
		'For k = 1 To Tipo '1: semplice; 2= portante
		'Alarg = Sella.Lung
		'If Serie% > 1 And Tipo = 2 Then Alarg = Alarg - 4 * Sella.Spes3
		'Altz = Hterra - Sella.Spes3
		'If k = 2 Then Altz = Hsopra - Sella.Spes3
		'Spost = 0
		'GoSub NervStd
		'SpostT = 0
		'GoSub IncrStd
		'Rec2Buf(0).Tipo = -35
		'Rec2Buf(0).posspa.BaricRel.Y = Altz / 2     'non esatto
		'Rec2Buf(0).posspa.Anomal = "N.A."
		'Rec2Buf(0).posspa.DirTraversa = "Up"
		'GoSub VidStd
		'jRec = jRec + 1
		'     ifl = FreeFile
		'     DirScr$ = DiscoRam + "SCRATCH"
		'     If Len(Dir$(DirScr$)) > 0 Then Kill DirScr$
		'1110 Open DirScr$ For Random As #ifl Len = Len(Recmod)
		'1111 Put #ifl, 1, Recmod
		'1112 Get #ifl, 1, Record(jRec)
		'     Close #ifl
		'     Kill DirScr$
		'     Record(jRec).posspa.SuChi = Record(jRec - 1).Ind
		'     Record(jRec).PosDis = Record(jRec - 1).PosDis
		'     Rec2Buf(0) = Record(jRec)
		'1113 Call IncrRiga(0)
		'1114 Conversion 0, 1, 0!, 0!, 0!, 0&, 0#
		'     Record(jRec) = Rec2Buf(0)
		'     Record(jRec + 1).Ind = 0
		'Next k
		'Return
		''----------------------------------------------
		'NervStd:
		'     jRec = jRec + 1: PosDis = PosDis + 1
		'     Record(jRec) = Record(jRec - k)
		'     Record(jRec).Denom = "NERVATURA"
		'1120 GoSub Rec95
		'     Record(jRec).DIME = "LAM. " + Str$(Altz) + " x " + Str$(Alarg) + " sp." + Str$(Spes)
		'     Record(jRec).NOTE = "POLIGONALE ISCRITTA"
		'     Record(jRec).Dati(1) = Spes 'spessore
		'     Record(jRec).Dati(3) = Altz 'altezza
		'     Record(jRec).Dati(2) = Alarg 'lunghezza
		'     PNET = Spes * area * Matdim(0).PSP * EXP9
		'1121 PLOR = Spes * (Altz + MargTag(Int(Spes), Classedim(0))) * (Alung + MargTag(Int(Spes), Classedim(0))) * Matdim(0).PSP * EXP9
		'     PSFRI = PLOR - PNET
		'Return
		''---------------------------------------------------
		'Rec95:
		'     Recmod.Tipo = 95
		'     Recmod.Npunti = 7
		'     Recmod.Vertice(1).Y = 0!:            Recmod.Vertice(1).X = 0
		'     Recmod.Vertice(2).Y = Alarg / 2:     Recmod.Vertice(2).X = 0
		'     Recmod.Vertice(7).Y = -Alarg / 2:    Recmod.Vertice(7).X = 0
		'1122 ang = Sella.Alfa / 180 * PI / 2 'semiapertura
		'     Raggio = Diam / 2 + SpessRinf
		'1124 ang = ang - SpessRinf / Raggio
		'     X = Raggio * Sin(ang)
		'1126 Y = Altz - Raggio * Cos(ang)
		'     If Tipo = 2 And Serie% > 1 Then
		'1133   Recmod.Vertice(3).Y = Recmod.Vertice(2).Y:   Recmod.Vertice(3).X = Altz
		'       Recmod.Vertice(6).Y = -Recmod.Vertice(3).Y:  Recmod.Vertice(6).X = Altz
		'       Recmod.Vertice(4).Y = Raggio:                Recmod.Vertice(4).X = Altz
		'       Recmod.Vertice(5).Y = -Raggio:               Recmod.Vertice(5).X = Altz
		'       area = Altz * Alarg - PI / 2 * Raggio * Raggio
		'     Else
		'1144   Recmod.Vertice(4).Y = X:                     Recmod.Vertice(4).X = Y
		'       Recmod.Vertice(3) = Recmod.Vertice(4)
		'       Recmod.Vertice(5).Y = -X:                    Recmod.Vertice(5).X = Y
		'       Recmod.Vertice(6) = Recmod.Vertice(5)
		'       area = 2 * X * Y + (Alarg / 2 - X) * Y - Raggio * (2 * ang - Sin(ang) * Cos(ang))
		''     PRINT "Area"; Area; x; y; Alarg; raggio; Ang * 180 / PI: u$ = INPUT$(1)
		'     End If
		'  For i = 1 To 7
		'     Recmod.Raggio(i) = 0: Recmod.Centro(i).X = 0: Recmod.Centro(i).Y = 0
		'  Next
		'  Recmod.Raggio(4) = Raggio
		'  Recmod.Centro(4).Y = 0:                   Recmod.Centro(4).X = Altz
		'' Recmod.Denom = "DATI POLIGONALE"
		'Return
		'Err1: Print "Errore in SellFBM1"; Err; Erl: End
	End Sub
	'Sub SearchSella(Sella As Selle, Diam%, Serie%, Tipo$)
	'Dim Sella1 As Selle
	'If Sella.Diam < 0 Then NonInt = True Else NonInt = False
	'Open RTrim$(Archdir) + "\dimesel.new" For Random Shared As 4 Len = Len(Sella)
	'k = 1
	'Rifai:
	'Do
	'  Get #4, k, Sella
	'  If EOF(4) Then Sella.Diam = 0: Exit Do
	'  If Sella.Tipo = Tipo$ And Diam% < Sella.Diam Then Exit Do
	'  k = k + 1
	'Loop
	'If Sella.Diam = 0 Then
	'   If Serie% > 0 Then Serie% = 0: k = 1: GoTo Rifai Else Close #4: Exit Sub
	'End If
	'If Serie% > 0 And Sella.Serie <> Serie% Then GoTo Rifai
	'If NonInt Then Close #4: Exit Sub
	'If k > 1 Then Get #4, k - 1, Sella1 Else Close #4: Exit Sub
	'If Sella1.Serie <> Sella.Serie Or Sella1.Tipo <> Sella.Tipo Then Close #4: Exit Sub
	''interpola su Diam
	'Sella.DN = "00000"   'non a misure std
	'phi! = CSng(Diam% - Sella1.Diam) / (Sella.Diam - Sella1.Diam)
	'Sella.Diam = Diam%
	'Sella.Altz = Sella1.Altz + phi! * (Sella.Altz - Sella1.Altz)
	'Sella.Lung = Sella1.Lung + phi! * (Sella.Lung - Sella1.Lung)
	'Sella.Larg = Sella1.Larg + phi! * (Sella.Larg - Sella1.Larg)
	'Sella.Fori = Sella1.Fori + phi! * (Sella.Fori - Sella1.Fori)
	'Sella.Set1 = Sella1.Set1 + phi! * (Sella.Set1 - Sella1.Set1)
	'Sella.Set2 = Sella1.Set2 + phi! * (Sella.Set2 - Sella1.Set2)
	'Sella.Set3 = Sella1.Set3 + phi! * (Sella.Set3 - Sella1.Set3)
	'Sella.Spes1 = Sella1.Spes1 + phi! * (Sella.Spes1 - Sella1.Spes1)
	'Sella.Spes2 = Sella1.Spes2 + phi! * (Sella.Spes2 - Sella1.Spes2)
	'Sella.Spes3 = Sella1.Spes3 + phi! * (Sella.Spes3 - Sella1.Spes3)
	'Sella.peso = Sella1.peso + phi! * (Sella.peso - Sella1.peso)
	'Close #4
	'End Sub
	
	Sub Selle()
		'If Lav(0).Asse = "V" Then
		'   MensFBM
		'Else
		'   If Lav(0).CalcBaric Then
		'      SellFBM1
		'   Else
		'      SellFBM
		'   End If
		'End If
	End Sub
	Sub MensFBM()
        'Dim AddDistinta As Object
		'LungAPR = False
		'GoSub RiprMens
        'If AddDistinta <= 102 Then
        '    GoSub PrFinMens
        '    GoSub SeFinMens
        '    GoSub TeFinMens
        'End If
        'Select Case XVec
        '    Case 1
        '    Select Case XVec1
        '     Case 1: GoSub 4280 'peso gonna cilindrica serie leggera (Mens)
        '             NOM0$ = at1(60)
        '     Case 2: GoSub 4570 'peso gonna cilindrica serie pesante (Mens)
        '             NOM0$ = at1(61)
        '     Case 3: GoSub 4860 'peso gonna cilindrica su disegno del cliente (Mens)
        '             NOM0$ = at1(62)
        '    End Select
        '    PNET0 = PNGONNA: PLOR0 = PLGONNA: PSFRI = PLOR0 - PNET0
        '    Case 2
        '    Select Case XVec1
        '     Case 1: GoSub 5110 'peso gonna conica serie leggera (Mens1)
        '             NOM0$ = at1(63)
        '     Case 2: GoSub 5450 'peso gonna conica serie pesante (Mens1)
        '             NOM0$ = at1(64)
        '     Case 3: GoSub 5790 'peso gonna conica su disegno del cliente (Mens1)
        '             NOM0$ = at1(65)
        '    End Select
        '    PNET0 = PNGONNA: PLOR0 = PLGONNA: PSFRI = PLOR0 - PNET0
        '    Case 3
        '    Select Case XVec1
        '     Case 1: GoSub 6260 'peso mensola singola             (Mens2)
        '             NOM0$ = at1(66)
        '     Case 2: GoSub 6450 'peso mensola con anello continuo (Mens2)
        '             NOM0$ = at1(67)
        '     Case 3: GoSub 6640 'peso mensola su disegno del cliente (mens2/Mens3)
        '             NOM0$ = at1(68)
        '    End Select
        '    PNET0 = PNMENSOLA: PLOR0 = PLMENSOLA: PSFRI = PLOR0 - PNET0
        'End Select
        'GoSub RecMens
        'LTO# = GuardaPrezzo#(prezzo0&, prezzo1&, 0, 0, 25, 0, "--", 0!, 0!, 1)
        '   Call IncrRiga(0)
        '   Conversion 0, 1!, PNET0, PLOR0, PSFRI, prezzo0&, PLOR0 * prezzo0&
        '   Rec2Buf(0).Denom = NOM0$
        'Record(0) = Rec2Buf(0)
        'Record(1).Ind = 0
        'If AddDistinta <= 102 Then
        '   VideoDati 0, True, k$
        '   If k$ = "E" Or k$ = "e" Then Record(0).Ind = 0: Exit Sub
        '   If k$ = "R" Or k$ = "r" Then Lav(0).Ind(Lav(0).NumAs) = Lav(0).Ind(Lav(0).NumAs) - 1: GoTo RifaiMen
        'End If
        'Put #1, 1, Lav(0)
        'LungAPR = True
        Exit Sub
        '***********************************************************************
4280:   '** SUBRUTIN peso netto gonna cilindrica tipo leggero **
        'If AddDistinta <= 102 Then
        '     Nfield = 1: GoSub QuFinMens
        'End If
        '     k = H
        '4320 W = d
        '4330 GoSub 9510 'matrice GONNA1
        '4480 '** peso lordo gonna cilindrica tipo leggero **
        '4500 GoSub 9630 'matrice GONNA2
4550:   'UPGRADE_WARNING: Return ha un nuovo comportamento. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1041"'
        Return
4570:   '** SUBRUTIN peso netto gonna cilindrica tipo pesante **
        'If AddDistinta <= 102 Then
        '     Nfield = 1: GoSub QuFinMens
        'End If
        ''4600 LOCATE 20, 20, 0: INPUT "Altezza gonna cilindrica [mm] ", k
        '     k = H
        '4610 W = d
        '4620 GoSub 9750 'matrice GONNA3
        '4770 '** peso lordo gonna cilindrica tipo pesante **
        '4790 GoSub 9870 'matrice GONNA4
        '4840 Return
        '4860 '** SUBRUTIN peso netto e lordo gonna **
        '4880 '***************************************
        'If AddDistinta <= 102 Then
        '     Nfield = 5: GoSub QuFinMens
        'End If
        '4900 LOCATE 15, 20, 0: PRINT "Altezza  gonna          =        [mm]"
        '4910 LOCATE 16, 20, 0: PRINT "Spessore gonna          =        [mm]"
        '4920 LOCATE 17, 20, 0: PRINT "Larghezza base gonna    =        [mm]"
        '4930 LOCATE 18, 20, 0: PRINT "Spessore  base gonna    =        [mm]"
        '4940 LOCATE 19, 20, 0: PRINT "Nøscatole di ancoraggio =        [--]"
        '4950 LOCATE 15, 46, 0: INPUT "", H
        '4960 LOCATE 16, 46, 0: INPUT "", T
        '4970 LOCATE 17, 46, 0: INPUT "", B
        '4980 LOCATE 18, 46, 0: INPUT "", Sp
        '4990 LOCATE 19, 46, 0: INPUT "", N
        '5000 P1N = d * PI * H * t * 8 * 0.000001 '__________peso netto virola gonna
        '5010 P1L = P1N * 1.05 '__________________peso lordo virola gonna
        '5020 p2n = d * PI * b * sp * 8 * 0.000001 '_________peso netto anello di base
        '5030 P2L = p2n * 1.4 '___________________peso lordo anello di base
        '5040 p3n = (b * (2 * d + b) * PI * t * 8 * 0.000001) / 4 'peso netto anello superiore
        '5050 P3L = p3n * 1.4 '___________________peso lordo anello superiore
        '5060 p4n = 300 * b * t * n * 8 * 0.000001 '_________peso netto nervature
        '5070 P4L = p4n * 1.05 '__________________peso lordo nervature
        '5080 PNGONNA = Int(P1N + p2n + p3n + p4n)
        '5090 PLGONNA = Int(P1L + P2L + P3L + P4L)
5100:   'UPGRADE_WARNING: Return ha un nuovo comportamento. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1041"'
        Return
        '5110 '**********************************************
5120:   '** SUBRUTIN peso netto e lordo gonna conica **
5130:   '** di tipo leggero                          **
5140:   '**********************************************
        'If AddDistinta <= 102 Then
        '     For i = 1 To 6: Line Input #ifl, Stringa1$(1): Next
        '     Nfield = 2: GoSub QuFinMens1
        'End If
        '5160 LOCATE 20, 20, 0: PRINT "Altezza gonna conica    =       [mm]"
        '5170 LOCATE 21, 20, 0: PRINT "Angolo del cono         =       [deg]"
        '5180 LOCATE 20, 46, 0: INPUT "", k
        '5190 LOCATE 21, 46, 0: INPUT "", ALFADEG
        '     k = H
        '5200 AlfaRad = ALFADEG * PI / 180
        '5210 W = d + 2 * k * Tan(AlfaRad) 'diametro maggiore cono
        '5220 GoSub 9510 '_________matrice GONNA1
        '5360 GoSub 9630 'matrice GONNA2
        '5410 Q = (Cos(AlfaRad) / ((1 - ((k / W) * Tan(AlfaRad))))) 'fattore di riduzione tra cilindro e cono di diametro maggiore = al diametro del cilindro
        '5420 PNGONNA = Int(PNGONNA / Q)
        '5430 PLGONNA = Int(PLGONNA / Q)
        '5440 Return
        '5450 '**********************************************
        '5460 '** SUBRUTIN peso netto e lordo gonna conica **
        '5470 '** di tipo pesante                          **
        '5480 '**********************************************
        'If AddDistinta <= 102 Then
        '     For i = 1 To 6: Line Input #ifl, Stringa1$(1): Next
        '     Nfield = 2: GoSub QuFinMens1
        'End If
        ''5500 LOCATE 20, 20, 0: PRINT "Altezza gonna conica    =       [mm]"
        ''5510 LOCATE 21, 20, 0: PRINT "Angolo del cono         =       [deg]"
        ''5520 LOCATE 20, 46, 0: INPUT "", k
        ''5530 LOCATE 21, 46, 0: INPUT "", ALFADEG
        '     k = H
        '5540 AlfaRad = ALFADEG * PI / 180
        '5550 W = d + 2 * k * Tan(AlfaRad) 'diametro maggiore cono
        '5560 GoSub 9750 '_________matrice GONNA3
5:      '700 GoSub 9870 'matrice GONNA4
        '5750 Q = (Cos(AlfaRad) / ((1 - ((k / W) * Tan(AlfaRad))))) 'fattore di riduzione tra cilindro e cono di diametro maggiore = al diametro del cilindro
        '5760 PNGONNA = Int(PNGONNA / Q)
        '5770 PLGONNA = Int(PLGONNA / Q)
        '5780 Return
        '5790 '***************************************
        '5800 '** SUBRUTIN peso netto e lordo gonna **
        '5810 '** conica su disegno del cliente     **
        '5820 '***************************************
        'i 'f AddDistinta <= 102 Then
        '     For i = 1 To 6: Line Input #ifl, Stringa1$(1): Next
        '     Nfield = 6: GoSub QuFinMens1
        'End If
        ''5840 LOCATE 14, 20, 0: PRINT "Altezza  gonna              =        [mm]"
        ''5850 LOCATE 15, 20, 0: PRINT "Spessore gonna              =        [mm]"
        ''5860 LOCATE 16, 20, 0: PRINT "Larghezza base gonna        =        [mm]"
        ''5870 LOCATE 17, 20, 0: PRINT "Spessore  base gonna        =        [mm]"
        ''5880 LOCATE 18, 20, 0: PRINT "Nøscatole di ancoraggio     =        [--]"
        ''5890 LOCATE 19, 20, 0: PRINT "Angolo del cono             =        [deg]"
        ''5900 LOCATE 14, 50, 0: INPUT "", H
        ''5910 LOCATE 15, 50, 0: INPUT "", T
        ''5920 LOCATE 16, 50, 0: INPUT "", B
        ''5930 LOCATE 17, 50, 0: INPUT "", Sp
        ''5940 LOCATE 18, 50, 0: INPUT "", N
        ''5950 LOCATE 19, 50, 0: INPUT "", ALFADEG
        'If AddDistinta <= 102 Then
        'Line Input #ifl, Stringa(1)
        'Line Input #ifl, Stringa(2)
        'Line Input #ifl, k$
        'If Vecchio Then
        '   If H1 > 0 Then X = 2 Else X = 1
        'Else
        '   X = 1
        'End If
        'X = Quale(2, k$, Stringa(), "", Int(X))
        'If X = 1 Then H1 = 0
        'End If
        ''5960 LOCATE 20, 20, 0: PRINT "Attacco gonna :"
        ''5970 LOCATE 21, 20, 0: PRINT "               A senza nessun rinforzo"
        ''5980 LOCATE 22, 20, 0: PRINT "               B con fascia di rinforzo"
        'If AddDistinta <= 102 Then
        'Line Input #ifl, Stringa1$(1)
        'Line Input #ifl, Stringa1$(2)
        'End If
        'If X <> 2 Then GoTo 6090
        ''6040 FOR i = 20 TO 22: LOCATE i, 1, 0: PRINT STRING$(80, 32): NEXT i
        ''6050 LOCATE 21, 20, 0: PRINT "Altezza  fascia di rinforzo =        [mm]"
        ''6060 LOCATE 22, 20, 0: PRINT "Spessore fascia di rinforzo =        [mm]"
        ''6070 LOCATE 21, 50, 0: INPUT "", H1
        ''6080 LOCATE 22, 50, 0: INPUT "", SP1
        'If AddDistinta <= 102 Then
        'For i = 1 To 2: Risult$(i) = String$(8, 32): LungStr(i) = 8: Next
        'Y = VisuInput(2, "", "", Stringa1$(), Risult$(), LungStr())
        'H1 = Val(Risult$(1))
        'Sp1 = Val(Risult$(2))
        'End If
        '6090 AlfaRad = ALFADEG * PI / 180
        '6100 W = d + 2 * H * Tan(AlfaRad) 'diametro maggiore cono
        '6110 l = H / Cos(AlfaRad) '    ipotenusa cono
        '6120 P1N = ((d + W) / 2) * PI * l * t * 8 * 0.000001 'peso netto virola cono
        '6130 P1L = P1N * 1.2 '_________________peso lordo virola cono
        '6140 p2n = W * PI * b * sp * 8 * 0.000001 '_______peso netto anello di base
        '6150 P2L = p2n * 1.4 '_________________peso lordo anello di base
        '6160 p3n = ((W + b) - ((b / 2) + (300 + t) * Tan(AlfaRad))) * PI * ((b / 2) + (300 + t) * Tan(AlfaRad)) * t * 8 * 0.000001 '___________________________peso netto anello superiore
        '6170 P3L = p3n * 1.4 '_________________peso lordo anello superiore
        '6180 p4n = ((((b / 2) + (300 + t) * Tan(AlfaRad)) + (b / 2)) / 2) * 300 * t * n * 16 * 0.000001
        '6190 '____________________________peso netto nervature di rinforzo
        '6200 P4L = p4n * 1.05 '________________peso lordo nervature di rinforzo
        '6210 p5n = (d + Sp1) * PI * H1 * Sp1 * 8 * 0.000001 'peso netto fascia di rinforzo
        '6220 P5L = p5n * 1.05
        '230 PNGONNA = Int(P1N + p2n + p3n + p4n + p5n)
        '6240 PLGONNA = Int(P1L + P2L + P3L + P4L + P5L)
        '6250 Return
        '6260 '***********************************************
        '6270 '** SUBRUTIN peso netto/lordo mensole singole **
        '6280 '***********************************************
        'If AddDistinta <= 102 Then
        '     For i = 1 To 17: Line Input #ifl, Stringa1$(1): Next
        '     Line Input #ifl, Stringa(1)
        '     Line Input #ifl, Stringa(2)
        '     Line Input #ifl, k$
        '     Nfield = 2: GoSub QuFinMens2
        'End If
        ''6300 LOCATE 15, 20, 0: PRINT "Sporgenza mensola     =       [mm]"
        ''6310 LOCATE 16, 20, 0: PRINT "Nø mensole            =       [--]"
        ''6320 LOCATE 15, 44, 0: INPUT "", W
        ''6330 LOCATE 16, 44, 0: INPUT "", N
        '6340 m = W - 87
        '6350 If m < 75 Then m = 75
        '6360 P1N = (m + 85) * 200 * 12 * 8 * 0.000001 '_peso netto base mensola
        '6370 P1L = P1N * 1.05 '______________peso lordo base mensola
        '6380 p2n = 250 * (m + 135) * 12 * 8 * 0.000001 'peso netto piastra fasciame-mensola
        '6390 P2L = p2n * 1.05 '______________peso lordo piastra fasciame-mensola
        '6400 p3n = (((m + 63) ^ 2) - ((m + 25) ^ 2 / 2)) * 12 * 16 * 0.000001 'peso netto nervature
        '6410 P3L = (m + 85) ^ 2 * 12 * 16 * 0.000001 '_________________peso lordo nervature
        '6420 PNMENSOLA = Int((P1N + p2n + p3n)): NPE = n
        '6430 PLMENSOLA = Int((P1L + P2L + P3L))
        '6440 Return
        '6450 '**************************************************
        '6460 '** SUBRUTIN peso netto/lordo mensole con anello **
        '6470 '**************************************************
        'If AddDistinta <= 102 Then
        '     For i = 1 To 17: Line Input #ifl, Stringa1$(1): Next
        '     Line Input #ifl, Stringa(1)
        '     Line Input #ifl, Stringa(2)
        '     Line Input #ifl, k$
        '     Nfield = 2: GoSub QuFinMens2
        'End If
        ''6490 LOCATE 15, 20, 0: PRINT "Sporgenza mensola     =       [mm]"
        ''6500 LOCATE 16, 20, 0: PRINT "Nø mensole            =       [--]"
        '6510 LOCATE 15, 44, 0: INPUT "", W
        '6520 LOCATE 16, 44, 0: INPUT "", N
        '6530 m = W - 75
        '6540 If m < 125 Then m = 125
        '6550 P1N = ((d + (m - 75)) * PI * (m - 75) * 32 * 8 * 0.000001) 'peso netto anello infer.&superiore
        '6560 P1L = P1N * 1.4 '__________________________peso lordo anello infer.&superiore
        '6570 p2n = ((m - 75) * 340 + 27750) * 12 * 16 * 0.000001 * n '_peso netto nervature
        '6580 P2L = (m + 85) * 350 * 12 * 16 * 0.000001 * n '_________peso lordo nervature
        '6590 p3n = 170! * 200 * 20 * 8 * 0.000001 * n '_____________peso netto base mensola
        '6600 P3L = p3n * 1.05 '_________________________peso lordo base mensola
        '6610 PNMENSOLA = Int((P1N + p2n + p3n) / n): NPE = n
        '6620 PLMENSOLA = Int((P1L + P2L + P3L) / n): NPE = n
        '6630 Return
        '6640 '*****************************************
        '6650 '** SUBRUTIN peso netto e lordo mensole **
        '6660 '** su disegno del cliente              **
        '6670 '*****************************************
        'If AddDistinta <= 102 Then
        '     For i = 1 To 17: Line Input #ifl, Stringa1$(1): Next
        '     Line Input #ifl, Stringa(1)
        '     Line Input #ifl, Stringa(2)
        '     Line Input #ifl, k$
        '     If Vecchio Then
        '        If D2 > 0 Then X = 2 Else X = 1
        '     Else
        '        X = 1
        '     End If
        '     X = Quale(2, k$, Stringa(), "", Int(X))
        '     If X = 1 Then D2 = 0
        'End If
        ''6680 LOCATE 13, 20, 0: PRINT "Scelta tipo di mensola :"
        ''6690 LOCATE 14, 20, 0: PRINT "                        A  mensola singola"
        ''6700 LOCATE 15, 20, 0: PRINT "                        B  mensola con anelli continui"
        '6710 DEF SEG = 0: POKE 1050, PEEK(1052)
        '6720 k$ = INKEY$
        '6730 IF k$ = "A" OR k$ = "a" THEN GOTO 6760
        ' If X = 1 Then GoTo 6760 Else GoTo 6980
        '6740 IF k$ = "B" OR k$ = "b" THEN GOTO 6980
        '6750 GOTO 6720
        '6760 'FOR i = 13 TO 15: LOCATE i, 1, 0: PRINT STRING$(80, 32): NEXT i
        'If AddDistinta <= 102 Then
        '     Nfield = 10: GoSub QuFinMens2
        'End If
        ''6770 LOCATE 14, 1, 0: PRINT "Sporgenza mensole         =      [mm] º"
        ''6780 LOCATE 15, 1, 0: PRINT "Nø mensole                =      [--] º"
        ''6790 LOCATE 16, 1, 0: PRINT "Sp.piastra di rinforzo    =      [mm] º"
        ''6800 LOCATE 17, 1, 0: PRINT "Altezza piastra rinforzo  =      [mm] º"
        ''6810 LOCATE 18, 1, 0: PRINT "Largh.piastra di rinforzo =      [mm] º"
        ''6820 LOCATE 14, 40, 0: PRINT "Larghezza mensola         =      [mm]"
        ''6830 LOCATE 15, 40, 0: PRINT "Altezza mensola           =      [mm]"
        ''6840 LOCATE 16, 40, 0: PRINT "Nø nervature per mensola  =      [--]"
        ''6850 LOCATE 17, 40, 0: PRINT "Sp.base mensola           =      [mm]"
        ''6860 LOCATE 18, 40, 0: PRINT "Sp.nervature              =      [mm]"
        ''6870 LOCATE 14, 29, 0: INPUT "", L
        ''6880 LOCATE 15, 29, 0: INPUT "", N
        ''6890 LOCATE 16, 29, 0: INPUT "", T
        ''6900 LOCATE 17, 29, 0: INPUT "", Z
        ''6910 LOCATE 18, 29, 0: INPUT "", Z1
        ''6920 LOCATE 14, 68, 0: INPUT "", B
        ''6930 LOCATE 15, 68, 0: INPUT "", H
        ''6940 LOCATE 16, 68, 0: INPUT "", n1
        ''6950 LOCATE 17, 68, 0: INPUT "", T1
        ''6960 LOCATE 18, 68, 0: INPUT "", T2
        '6970 GoTo 7240
        '6980 'FOR i = 13 TO 15: LOCATE i, 1, 0: PRINT STRING$(80, 32): NEXT i
        'If AddDistinta <= 102 Then
        '    Nfield = 12: GoSub QuFinMens2
        'End If
        ''6990 LOCATE 14, 1, 0: PRINT "Sporgenza mensole         =      [mm] º"
        '7000 LOCATE 15, 1, 0: PRINT "Nø mensole                =      [--] º"
        '7010 LOCATE 16, 1, 0: PRINT "Sp.piastra di rinforzo    =      [mm] º"
        '7020 LOCATE 17, 1, 0: PRINT "Altezza piastra rinforzo  =      [mm] º"
        '7030 LOCATE 18, 1, 0: PRINT "Larghezza mensola         =      [mm] º"
        '7040 LOCATE 19, 1, 0: PRINT "Altezza mensola           =      [mm] º"
        '7050 LOCATE 14, 40, 0: PRINT "Nø nrvature per mensola   =      [--]"
        '7060 LOCATE 15, 40, 0: PRINT "Sp.base mensola           =      [mm]"
        '7070 LOCATE 16, 40, 0: PRINT "Sp.anello superiore       =      [mm]"
        '7080 LOCATE 17, 40, 0: PRINT "Diametro anello superiore =      [mm]"
        '7090 LOCATE 18, 40, 0: PRINT "Diametro anello inferiore =      [mm]"
        '7100 LOCATE 19, 40, 0: PRINT "Sp. nervature             =      [mm]"
        '7110 LOCATE 14, 29, 0: INPUT "", L
        '7120 LOCATE 15, 29, 0: INPUT "", N
        '7130 LOCATE 16, 29, 0: INPUT "", T
        '7140 LOCATE 17, 29, 0: INPUT "", Z
        '7150 LOCATE 18, 29, 0: INPUT "", B
        '7160 LOCATE 19, 29, 0: INPUT "", H
        '7170 LOCATE 14, 68, 0: INPUT "", n1
        '7180 LOCATE 15, 68, 0: INPUT "", T1
        '7190 LOCATE 16, 68, 0: INPUT "", T3
        '7200 LOCATE 17, 68, 0: INPUT "", D1
        '7210 LOCATE 18, 68, 0: INPUT "", D2
        '7220 LOCATE 19, 68, 0: INPUT "", T2
        '7230 GoTo 7360
        '7240 '**************************
        '7250 '** peso mensola singola **
        '7260 '**************************
        '7270 P1N = Z * z1 * t * 8 * 0.000001 * n '________________peso netto piastra di rinforzo
        '7280 P1L = P1N * 1.05 '________________________peso lordo piastra di rinforzo
        '7290 p2n = (l + 20) * b * T1 * 8 * 0.000001 * n '___________peso netto base mensola
        '7300 P2L = p2n * 1.05 '________________________peso lordo base mensola
        '7310 p3n = ((H * l) + (((l - 50) * (H - 50)) / 2)) * T2 * 8 * 0.000001 * n * n1 'peso netto nervature
        '7320 P3L = H * l * T2 * 8 * 0.000001 * n * n1 '________________________peso lordo nervature
        '7330 PNMENSOLA = Int((P1N + p2n + p3n) / n): NPE = n
        '7340 PLMENSOLA = Int((P1L + P2L + P3L) / n): NPE = n
        '7350 Return
        '7360 '**************************************
        '7370 '** peso mensola con anelli continui **
        '7380 '**************************************
        '7390 z1 = (d + t) * PI
        '7400 P1N = Z * z1 * t * 8 * 0.000001 '__________________peso netto piastra di rinforzo
        '7410 P1L = P1N * 1.05 '________________________peso lordo piastra di rinforzo
        '7420 p2n = (D1 ^ 2 - d ^ 2) * (PI / 4) * T3 * 8 * 0.000001 '____peso netto anello superiore
        '7430 P2L = p2n * 1.4 '_________________________peso lordo anello superiore
        '7440 p3n = (D2 ^ 2 - d ^ 2) * (PI / 4) * T1 * 8 * 0.000001 '____peso netto anello inferiore
        '7450 P3L = p3n * 1.4 '_________________________peso lordo anello inferiore
        '7460 p4n = ((l + 20) - ((D2 - d) / 2)) * b * T1 * 8 * 0.000001 * n 'peso netto base mensola
        '7470 P4L = p4n * 1.05 '__________________________peso lordo base mensola
        '7480 p5n = ((l * H) - ((((d + 2 * l) - D1) / 2) * (H - 30))) * T2 * 8 * 0.000001 * n1 * n 'peso netto netvature
        '7490 P5L = l * H * T2 * 8 * 0.000001 * n1 * n '______________________________peso lordo nervature
        '7500 PNMENSOLA = Int((P1N + p2n + p3n + p4n + p5n) / n): NPE = n
        '7510 PLMENSOLA = Int((P1L + P2L + P3L + P4L + P5L) / n): NPE = n
        '7520 Return
        '9480 '********************************
        '9490 '** Costruzione matrice GONNA1 **
        '9500 '********************************
        '9510 Dim GONNA1(27, 10)
        '9520 Mark$ = "S1:" 'RESTORE Sel105
        '9530 'FOR i = 0 TO 27
        '9540 'FOR j = 0 TO 10
        '9550 'READ a
        '9560 'GONNA1(i, j) = a
        '9570 'NEXT j
        '9580 'NEXT i
        '     ReadGonna Mark$, GONNA1()
        '4340 For i = 0 To 27
        '4350 If k < 400 Then GoTo 4390
        '4360 If k < GONNA1(i, 0) Then GoTo 4390
        '4370 If k >= 3000 Then i = 27: GoTo 4390
        '4380 Next i
        '4390 For j = 0 To 10
        '4400 If d < 1000 Then GoTo 4440
        '4410 If d < GONNA1(0, j) Then GoTo 4440
        '4420 If d >= 6000 Then j = 10: GoTo 4440
        '4430 Next j
        '4440 D1 = GONNA1(0, j - 1): D2 = GONNA1(0, j): H1 = GONNA1(i - 1, 0): H2 = GONNA1(i, 0): C11 = GONNA1(i - 1, j - 1): C12 = GONNA1(i, j - 1): C21 = GONNA1(i - 1, j): C22 = GONNA1(i, j)
        '4450 GoSub 8990 ',INTERPOLAZIONE DOPPIA
        '4460 PNGONNA = R: Alt% = i: Dia% = j
        '9590 Return
        '9600 '********************************
        '9610 '** Costruzione matrice GONNA2 **
        '9620 '********************************
        '9630 Dim GONNA2(27, 10)
        '9640 Mark$ = "S2:" 'RESTORE Sel106
        '9650 'FOR i = 0 TO 27
        '9660 'FOR j = 0 TO 10'
        '9670 'READ a
        '9680 'GONNA2(i, j) = a
        '9690 'NEXT j
        '9700 'NEXT i
        '     ReadGonna Mark$, GONNA2()
        '     PRINT "i,j"; i; j: u$ = INPUT$(1)
        '4510 i = Alt%: j = Dia%: C11 = GONNA2(i - 1, j - 1): C12 = GONNA2(i, j - 1): C21 = GONNA2(i - 1, j): C22 = GONNA2(i, j)
        '4520 GoSub 8990 ',INTERPOLAZIONE DOPPIA
        '4530 PLGONNA = R
        '4540 Erase GONNA1, GONNA2
        '9710 Return
        '9720 '********************************
        '9730 '** Costruzione matrice GONNA3 **
        '9740 '********************************
        '9750 Dim GONNA3(27, 10)
        '9760 Mark$ = "S3:" ' RESTORE Sel107
        '9770 'FOR i = 0 TO 27
        '9780 'FOR j = 0 TO 10
        '9790 'READ a
        '9800 'GONNA3(i, j) = a
        '9810 'NEXT j
        '9820 'NEXT i
        '     ReadGonna Mark$, GONNA3()
        '4630 For i = 0 To 27
        '4640 If k < 400 Then GoTo 4680
        '4650 If k < GONNA3(i, 0) Then GoTo 4680
        '4660 If k >= 3000 Then i = 27: GoTo 4680
        '4670 Next i
        '4680 For j = 0 To 10
        '4690 If d < 1000 Then GoTo 4730
        '4700 If d < GONNA3(0, j) Then GoTo 4730
        '4710 If d >= 6000 Then j = 10: GoTo 4730
        '4720 Next j
        '4730 D1 = GONNA3(0, j - 1): D2 = GONNA3(0, j): H1 = GONNA3(i - 1, 0): H2 = GONNA3(i, 0): C11 = GONNA3(i - 1, j - 1): C12 = GONNA3(i, j - 1): C21 = GONNA3(i - 1, j): C22 = GONNA3(i, j)
        '4740 GoSub 8990 ',INTERPOLAZIONE DOPPIA
        '4750 PNGONNA = R: Alt% = i: Dia% = j
        '9830 Return
        '9840 '********************************
        '9850 '** Costruzione matrice GONNA4 **
        '9860 '********************************
        '9870 Dim GONNA4(27, 10)
        '9880 Mark$ = "S4:" 'RESTORE Sel108
        '9890 'FOR i = 0 TO 27
        '9900 'FOR j = 0 TO 10
        '9910 'READ a
        '9920 'GONNA4(i, j) = a
        '9930 'NEXT j
        '9940 'NEXT i
        '     ReadGonna Mark$, GONNA4()
        '     PRINT "i,j"; i; j: u$ = INPUT$(1)
        '4800 i = Alt%: j = Dia%: C11 = GONNA4(i - 1, j - 1): C12 = GONNA4(i, j - 1): C21 = GONNA4(i - 1, j): C22 = GONNA4(i, j)
        '4810 GoSub 8990 ',INTERPOLAZIONE DOPPIA
        '4820 PLGONNA = R
        '4830 Erase GONNA3, GONNA4
        '9950 Return
        '8990 'INTERPOLAZIONE DOPPIA
        '     '*********************
        '     'W  =diametro effettivo
        '     'D1 =diametro inferiore
        '     'D2 =diametro superiore
        '     'K  =altezza effettiva
        '     'H1 =altezza inferiore
        '     'H2 =altezza superiore
        '     'C11=peso D1,H1
        '     'C12=peso D1,H2
        '     'C21=peso D2,H1
        '     'C22=peso D2,H2
        '     'Q1 =peso intermedio
        '     'Q2 =peso intermedio
        '     'R  =peso effettivo
        '9140 Q1 = (((C21 - C11) / (D2 - D1)) * (W - D1)) + C11
        '9150 Q2 = (((C22 - C12) / (D2 - D1)) * (W - D1)) + C12
        '9160 R = (((Q2 - Q1) / (H2 - H1)) * (k - H1)) + Q1
        '9170 Return
        'RiprMens:
        'If Record(jRec).Ind > 0 Then
        'ifl = FreeFile
        '9175:
        'Call RecupMat(0)
        '9176:
        'Close #ifl
        'XVec = Record(jRec).Tipo - 30 'tipo
        'XVec1 = Record(jRec).Dati(1)  'leggera,pesante,cliente
        'If XVec1 > 3 Then XVec1 = XVec1 \ 100
        'Select Case XVec
        '   Case 1 '  gonna cilindrica
        '      H = Record(jRec).Dati(2)
        '      t = Record(jRec).Dati(3)
        '      b = Record(jRec).Dati(4)
        '      sp = Record(jRec).Dati(5)
        '      n = Record(jRec).Dati(6)
        '      Diam = Record(jRec).Dati(7)
        '      d = Diam
        '      H1 = Rec2Buf(jRec).Dati(8)
        '      Sp1 = Rec2Buf(jRec).Dati(9)
        '   Case 2 '  gonna conica
        '      H = Record(jRec).Dati(2)
        '      ALFADEG = Record(jRec).Dati(3)
        '      t = Record(jRec).Dati(4)
        '      b = Record(jRec).Dati(5)
        '      sp = Record(jRec).Dati(6)
        '      n = Record(jRec).Dati(7)
        '      Diam = Record(jRec).Dati(8)
        '      d = Diam
        '      H1 = Rec2Buf(jRec).Dati(9)
        '      Sp1 = Rec2Buf(jRec).Dati(10)
        '   Case 3 '   mensole
        '      l = Record(jRec).Dati(2)
        '      n = (Record(jRec).Dati(1) - XVec1 * 100) \ 10
        '      D1 = Record(jRec).Dati(3)
        '      t = Record(jRec).Dati(4)
        '      Z = Record(jRec).Dati(5)
        '      z1 = Record(jRec).Dati(6)
        '      b = Record(jRec).Dati(7)
        '      H = Record(jRec).Dati(8)
        '      n1 = Record(jRec).Dati(1) - 100 * XVec1 - 10 * n
        '      D2 = Record(jRec).Dati(9)
        '      T1 = Int(Record(jRec).Dati(10) / 100!)
        '      T2 = Record(jRec).Dati(10) - 100! * T1
        '     Diam = Record(jRec).Dati(11)
        '      d = Diam
        'End Select
        'Vecchio = True
        'Else
        'Vecchio = False
        'End If
        'Return
        'PrFinMens:
        'ifl = FreeFile
        'Open RTrim$(Archdir) + "\cala10.DAT" For Input Shared As #ifl
        'For i = 1 To 4: Line Input #ifl, Stringa1$(i): Next
        ''Stringa1$(1) = "Gonna cilindrica  "
        ''Stringa1$(2) = "Gonna conica      "
        ''Stringa1$(3) = "Mensole           "
        'If Not Vecchio Then XVec = 1
        'For i = 1 To 3: Risult%(i) = False: Next
        'Risult%(XVec) = True
        'RifaiMen:
        'Y = SwitchDati%(2, 3, Stringa1$(4), Stringa1$(), Risult%(), "", False)
        'Do
        '       Select Case Y
        '       Case 3
        '               'A$ = " Help non disponibile    |"
        '               junk = Alert(4, at1(2), 4, 3, 11, 48, at1(33), "", "")
        '       Case 2: WindowClose 2: Exit Sub
        '       Case 1: WindowClose 2: Exit Do
        '       Case 11, 12, 13
        '         If Risult%(Y - 10) Then
        '            Risult%(1) = False: Risult%(2) = False: Risult%(3) = False
        '            Risult%(Y - 10) = True
        '         End If
        '       End Select
        'Y = SwitchDati%(0, 3, Stringa1$(4), Stringa1$(), Risult%(), "", False)
        'Loop
        'If Risult%(1) Then XVec = 1 Else If Risult%(2) Then XVec = 2 Else XVec = 3
        'Return
        'SeFinMens:
        'Nfield = 2
        'For i = 1 To 3: Line Input #ifl, Stringa1$(i): Next
        ''Stringa1$(1) = "Materiale Sella"
        ''Stringa1$(2) = "Diametro mantello [mm]"
        'If Not Vecchio Then
        'Risult$(1) = String$(25, " ")
        'Risult$(2) = String$(8, Chr$(32)) ': Risult$(4) = Risult$(2)
        'Else
        'Risult$(1) = Matdim(0).Mat
        'Risult$(2) = myStr(CSng(Diam), 8, 0, False)
        'End If
        'For i = 1 To Nfield: LungStr(i) = Len(Risult$(i)): Next
        'Classe0 = 1
        'Y = InputDati%(2, Nfield, Stringa1$(3), Stringa1$(), Risult$(), LungStr())
        'Do
        'Select Case Y
        '    Case -3
        '               'A$ = " Clickando su alcuni dei campi della | finestra sottostante si otiene |"
        '               'A$ = A$ + " una lista dei valori possibili. Cio' | vale in particolare per i materiali.|"
        '               junk = Alert(4, at1(59), 4, 3, 11, 48, at1(33), "", "")
        '    Case -2
        '               WindowClose 2: Exit Sub
        '    Case -1
        '               WindowClose 2: Exit Do
        '    Case 1
        '         DisplayMat Classe0, 0
        '         Risult$(1) = Matdim(0).Mat
        '    Case Else
        '         'A$ = " Non e' previsto un menu | per questo valore. |"
        '        junk = Alert(4, at1(55), 4, 3, 11, 48, at1(33), "", "")
        'End Select
        'Y = InputDati%(0, Nfield, Stringa1$(3), Stringa1$(), Risult$(), LungStr())
        'Loop
        'Rec2Buf(0).Indmat = Matdim(0).Ind
        'Diam = Val(Risult$(2))
        'd = Diam
        'Return
        'TeFinMens:
        'For i = 1 To (XVec - 1) * 4: Line Input #ifl, Stringa1$(1): Next
        'For i = 1 To 4: Line Input #ifl, Stringa1$(i): Next
        ''Stringa1$(1) = "Mensole singole             "
        ''Stringa1$(2) = "Mensole con anello continuo "
        ''Stringa1$(3) = "Mensole su disegno cliente  "
        'If Not Vecchio Then XVec1 = 1
        'For i = 1 To 3: Risult%(i) = False: Next
        'Risult%(XVec1) = True
        'Y = SwitchDati%(2, 3, Stringa1$(4), Stringa1$(), Risult%(), "", False)
        'Do
        '       Select Case Y
        '       Case 3
        '               'A$ = " Help non disponibile    |"
        '               junk = Alert(4, at1(2), 4, 3, 11, 48, at1(33), "", "")
        '       Case 2: WindowClose 2: Exit Sub
        '       Case 1: WindowClose 2: Exit Do
        '       Case 11, 12, 13
        '         If Risult%(Y - 10) Then
        '            Risult%(1) = False: Risult%(2) = False: Risult%(3) = False
        '            Risult%(Y - 10) = True
        '         End If
        '       End Select
        'Y = SwitchDati%(0, 3, Stringa1$(4), Stringa1$(), Risult%(), "", False)
        'Loop
        'If Risult%(1) Then XVec1 = 1 Else If Risult%(2) Then XVec1 = 2 Else XVec1 = 3
        'For i = 1 To (3 - XVec) * 4: Line Input #ifl, Stringa1$(1): Next
        'Return
        'QuFinMens:
        'For i = 1 To 6: Line Input #ifl, Stringa1$(i): Next
        'If Not Vecchio Then
        'For i = 1 To 5: Risult$(i) = String$(8, 32): Next
        'Else
        'Risult$(1) = myStr$(CSng(H), 8, 0, False)
        'Risult$(2) = myStr$(CSng(t), 8, 0, False)
        'Risult$(3) = myStr$(CSng(b), 8, 0, False)
        'Risult$(4) = myStr$(CSng(sp), 8, 0, False)
        'Risult$(5) = Adjust(Str$(n), 4)
        'End If
        'For i = 1 To Nfield: LungStr(i) = Len(Risult$(i)): Next
        'Y = VisuInput(Nfield, "", "", Stringa1$(), Risult$(), LungStr())
        'H = Val(Risult$(1))
        't = Val(Risult$(2))
        'b = Val(Risult$(3))
        'sp = Val(Risult$(4))
        'n = Val(Risult$(5))
        'Return
        'QuFinMens1:
        'For i = 1 To 6: Line Input #ifl, Stringa1$(i): Next
        'If Not Vecchio Then
        'For i = 1 To 6: Risult$(i) = String$(8, 32): Next
        'Else
        'Risult$(1) = myStr$(CSng(H), 8, 0, False)
        'Risult$(2) = myStr(CSng(ALFADEG), 8, 0, False)
        'Risult$(3) = myStr$(CSng(t), 8, 0, False)
        'Risult$(4) = myStr$(CSng(b), 8, 0, False)
        'Risult$(5) = myStr$(CSng(sp), 8, 0, False)
        'Risult$(6) = Adjust(Str$(n), 4)
        'End If
        'For i = 1 To Nfield: LungStr(i) = Len(Risult$(i)): Next
        'Y = VisuInput(Nfield, "", "", Stringa1$(), Risult$(), LungStr())
        'H = Val(Risult$(1))
        'ALFADEG = Val(Risult$(2))
        't = Val(Risult$(3))
        'b = Val(Risult$(4))
        'sp = Val(Risult$(5))
        'n = Val(Risult$(6))
        'Return
        'QuFinMens2:
        'For i = 1 To Nfield: Line Input #ifl, Stringa1$(i): Next
        'If Not Vecchio Then
        'For i = 1 To Nfield: Risult$(i) = String$(8, 32): Next
        'Else
        'Risult$(1) = myStr(CSng(l), 8, 0, False)
        'Risult$(2) = myStr(CSng(n), 4, 0, True)
        'Risult$(3) = myStr(CSng(t), 8, 0, False)
        'Risult$(4) = myStr(CSng(Z), 8, 0, False)
        'Risult$(5) = myStr(CSng(z1), 8, 0, False)
        'Risult$(6) = myStr(CSng(b), 8, 0, False)
        'isult$(7) = myStr(CSng(H), 8, 0, False)
        'Risult$(8) = myStr(CSng(n1), 4, 0, True)
        'Risult$(9) = myStr(CSng(T1), 8, 0, False)
        'Risult$(10) = myStr(CSng(T2), 8, 0, False)
        'If Nfield = 12 Then
        '  Risult$(11) = myStr(CSng(D1), 8, 0, False)
        '  Risult$(12) = myStr(CSng(D2), 8, 0, False)
        'End If
        'End If
        'For i = 1 To Nfield: LungStr(i) = Len(Risult$(i)): Next
        'Y = VisuInput(Nfield, "", "", Stringa1$(), Risult$(), LungStr())
        'l = Val(Risult$(1))
        'n = Val(Risult$(2))
        't = Val(Risult$(3))
        'Z = Val(Risult$(4))
        'z1 = Val(Risult$(5))
        'b = Val(Risult$(6))
        'H = Val(Risult$(7))
        'n1 = Val(Risult$(8))
        'T1 = Val(Risult$(9))
        'T2 = Val(Risult$(10))
        'If Nfield = 12 Then
        '  D1 = Val(Risult$(11))
        '  D2 = Val(Risult$(12))
        'End If
        'Return
        'RecMens:
        'Rec2Buf(0).Qta = Str$(NPE)
        'Rec2Buf(0).MF$ = " LE "
        'Rec2Buf(0).MATE = Matdim(0).Mat
        'Rec2Buf(0).Tipo = 30 + XVec
        ''Record(jRec).Dati(1) = XVec'tipo
        'Rec2Buf(jRec).Dati(1) = XVec1 'leggera,pesante,cliente
        'Select Case XVec
        '   Case 1 '  gonna cilindrica
        '          Rec2Buf(jRec).Dati(2) = H
        '          Rec2Buf(jRec).Dati(3) = t
        '          Rec2Buf(jRec).Dati(4) = b
        '          Rec2Buf(jRec).Dati(5) = sp
        '          Rec2Buf(jRec).Dati(6) = n
        '          Rec2Buf(jRec).Dati(7) = d
        '          Rec2Buf(jRec).Dati(8) = H1
        '          Rec2Buf(jRec).Dati(9) = Sp1
        '   Case 2 '  gonna conica
        '          Rec2Buf(jRec).Dati(2) = H
        '         Rec2Buf(jRec).Dati(3) = ALFADEG
        '          Rec2Buf(jRec).Dati(4) = t
        '          Rec2Buf(jRec).Dati(5) = b
        '          Rec2Buf(jRec).Dati(6) = sp
        '          Rec2Buf(jRec).Dati(7) = n
        '          Rec2Buf(jRec).Dati(8) = d
        '          Rec2Buf(jRec).Dati(9) = H1
        '          Rec2Buf(jRec).Dati(10) = Sp1
        '   Case 3 '   mensole
        '          Rec2Buf(jRec).Dati(1) = XVec1 * 100 + n * 10 + n1
        '          Rec2Buf(jRec).Dati(2) = l
        '          Rec2Buf(jRec).Dati(3) = D1
        '          Rec2Buf(jRec).Dati(4) = t
        '          Rec2Buf(jRec).Dati(5) = Z
        '          Rec2Buf(jRec).Dati(6) = z1
        '          Rec2Buf(jRec).Dati(7) = b
        '         Rec2Buf(jRec).Dati(8) = H
        '         Rec2Buf(jRec).Dati(9) = D2
        '          Rec2Buf(jRec).Dati(10) = T1 * 100 + T2
        '          Rec2Buf(jRec).Dati(11) = d
        'End Select
        'Return
        'ErrMens:
        'Print "Errore in MensFBM"; Err; Erl
        'Stop
	End Sub
	Sub ReadGonna(ByRef Mark As String, ByRef Gonna() As Object)
		'ifl = FreeFile
		'Open RTrim$(Archdir) + "\GONNE.DAT" For Input Shared As #ifl
		'Do
		'  Line Input #ifl, Riga$
		'  If Riga$ = Mark$ Then Exit Do
		'Loop
		'For i = 0 To 27
		'Line Input #ifl, Riga$
		'For j = 0 To 10
		'Gonna(i, j) = Val(Riga$)
		'Riga$ = Right$(Riga$, Len(Riga$) - InStr(Riga$, ","))
		'Next
		'Next
		'Close #ifl
	End Sub
End Module