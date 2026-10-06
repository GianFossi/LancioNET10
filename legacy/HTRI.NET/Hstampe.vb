Option Strict Off
Option Explicit On
Module modStampe
	''Sub Allocat1()
	'Dim at1(45) As String
	'ifl = FreeFile
	'Open RTrim$(Archdir) + "\IT\TESTID" For Input Shared As #ifl
	'For i = 1 To 25: Line Input #ifl, at1(i): Next
	'Close #ifl
	'End Sub
	
	'Function colora(thk, layer$)
	'Select Case thk
	'Case Is > 0.6: colora = 0: layer$ = "0"
	'Case Is < 0.15: colora = 1: layer$ = "1"
	'Case 0.15 To 0.2: colora = 2: layer$ = "2"
	'Case 0.2 To 0.3: colora = 3: layer$ = "3"
	'Case 0.3 To 0.4: colora = 4: layer$ = "4"
	'Case 0.4 To 0.5: colora = 5: layer$ = "5"
	'Case 0.5 To 0.6: colora = 6: layer$ = "6"
	'End Select
	'End Function
	
	'Sub ExamJobs(Nojob As Integer)
	'If Nomi$(1, 1) = "PPSM" Then
	'   Comm$ = RTrim$(Lav(0).Prev)
	'Else
	'   Comm$ = LTrim$(RTrim$(Readreco(1, 46, 2)))
	'End If
	'If Len(Comm$) > 0 Then If Asc(Comm$) < 32 Then Comm$ = ""
	'If Len(Comm$) > 0 Then
	'   Open RTrim$(Workdir) + "\" + Comm$ + ".JOB" For Random As #36 Len = Len(job)
	'   If LOF(36) > 0 Then
	'      Get #36, 1, job
	'      Nojob = False
	'   Else
	'      Nojob = True
	'   End If
	'   Close #36
	'Else
	'   Nojob = True
	'End If
	'If Nojob Then Exit Sub
	'For jj = 1 To job.Njobs
	'   ItemC$(jj) = RTrim$(job.Arch(jj))
	'   Nfas(jj) = 0
	'Next
	'Tit$ = "Scelta commesse"
	'If mySwitchBox(2, 1, 1, ItemC$(), Nfas(), job.Njobs, 0, Tit$, True) = 0 Then Nojob = True
	'End Sub
	'Sub Stampe()
	'On Local Error GoTo ErrStampe
	'Dim Risult%(14)
    ''IF ASC(job.contratto) < 33 THEN IF NOT CarPreG THEN EXIT SUB
    'item$(1) = "Stampe automatiche      "
    'item$(2) = "Visualizzazione e stampa"
    '1000 X = myListBox(2, 1, 1, item$(), 2, 0, "Opzione stampa", True)
    'If X = 0 Then Exit Sub
    'For i = 1 To 14
    'Risult%(i) = False
    'Next i
    'item$(1) = "Dati funzionali    ":  Risp$(1) = "FUN"
    'item$(2) = "Bilanci":              Risp$(2) = "BIL"
    'item$(3) = "Risultati calcolo t.": Risp$(3) = "CAL"
    'item$(4) = "Scelta ventilatori":   Risp$(4) = "VEN"
    'item$(5) = "Data sheets":          Risp$(5) = "DS"
    'item$(6) = "Mappa":                Risp$(6) = "MAP"
    'item$(7) = "Sommario":             Risp$(7) = "SUM"
    'item$(8) = "Check sheet mecc.":    Risp$(8) = "VER"
    'item$(9) = "File General Ass.":    Risp$(9) = "PRO"
    'item$(10) = "Disegno G.A.     ":   Risp$(10) = "PSP"
    'item$(11) = "Curve funz.vent. ":   Risp$(11) = "PSW"
    'item$(12) = "File test./telai ":   Risp$(12) = "DAT"
    'item$(13) = "Scantling        ":   Risp$(13) = "PSK"
    'item$(14) = "Diagramma momenti":   Risp$(14) = "PSR"
    '               a$ = "   Help  non  disponibile                   |"
    'If SwitchDati%(2, 14, "Tipi di stampe", item$(), Risult%(), a$, True) = 2 Then Exit Sub
    '1010 Nojob = False
    'For i = 1 To 14
    'If (Risult%(12) Or Risult%(13)) And i = 12 Then ExamJobs Nojob
    'If Risult%(i) Then
    '1020
    ' If i < 12 Or i = 14 Then
    '      NomeCom$ = Left$(job.contratto, 4)
    '      NomeFile$ = Dir$(RTrim$(Workdir) + "\" + NomeCom$ + "*." + Risp$(i))
    '      GoSub NomItem
    '      j = 0
    '      Do While Len(NomeFile$) > 0
    '        j = j + 1
    '       Dom$(j) = NomeFile$
    '       If Len(item$) > 0 Then Dom$(j) = Dom$(j) + "  |  " + RTrim$(item$)
    '        NomeFile$ = Dir$
    '        GoSub NomItem
    '      Loop
    ' Else
    '1030
    '   j = 0
    '   If Not Nojobs Then
    '     For jj = 1 To job.Njobs
    '       If Nfas(jj) = 1 Then
    '          f$ = RTrim$(Workdir) + "\" + RTrim$(job.Arch(jj)) + ".TEM"
    '          Open f$ For Random As #36 Len = Len(Lav(0))
    '          Get #36, 1, Lav(1)
    '          Close #36
    '          k = 1
    '1040      Do
    '            If Asc(Lav(1).File(k)) < 33 Or Asc(Lav(1).Assieme(k)) < 33 Then Exit Do
    '            Nome1$ = RTrim$(Workdir) + "\A" + RTrim$(Lav(1).Arch) + "\" + Lav(1).File(k) + "." + Risp$(i)
    '            If Len(Dir$(Nome1$)) > 0 Then
    '               j = j + 1
    '               Dom$(j) = job.Arch(jj) + "\" + Lav(1).File(k) + "  |  " + Lav(1).Assieme(k)
    '            End If
    '            k = k + 1
    '          Loop
    '       End If
    '     Next jj
    '   ElseIf X = 2 Then
    '         a$ = "Non e' stata generata la strut-|"
    '    a$ = a$ + "tura della commessa.           |"
    '    a$ = a$ + "Non c'e' niente da stampare.   |"
    '    X = Alert(4, a$, 9, 10, 14, 70, "OK", "", "")
    '   End If
    ' End If
    ' If j = 0 Then
    '      Dom$(1) = "Nessuno !"
    '      j1 = 1: If X = 1 Then j1 = 0
    ' Else
    '      j1 = j
    ' End If 's
    ' If X = 2 Then
    '1050 For j2 = 1 To j1: LungSt(j2) = 0: Next
    '     MouseShow
    '     x1 = mySwitchBox(2, 1, 1, Dom$(), LungSt(), j1, 0, item$(i), True)
    '     If j > 0 Then
    '       For j2 = 1 To j1
    '        If LungSt(j2) = 1 Then
    '          If i > 11 And i < 14 Then Dom$(j2) = "A" + Dom$(j2)
    '1060      n = InStr(Dom$(j2), "|")
    '         If n > 0 Then
    '             NomeFile$ = RTrim$(Workdir) + "\" + Left$(Dom$(j2), n - 3)
    '          Else
    '             NomeFile$ = RTrim$(Workdir) + "\" + Dom$(j2)
    '          End If
    '1070      If i > 11 And i < 14 Then NomeFile$ = NomeFile$ + "." + Risp$(i)
    '          Editore 2, NomeFile$, item$(i)
    '        End If 't
    '       Next
    '     End If 'u
    ' Else
    '     If j1 > 0 Then
    '1080      For j2 = 1 To j1
    '           If i > 11 And i < 14 Then Dom$(j2) = "A" + Dom$(j2)
    '           NomeFile$ = RTrim$(Workdir) + "\" + Left$(Dom$(j2), InStr(Dom$(j2), "|") - 3)
    '           If i > 11 And i < 14 Then NomeFile$ = NomeFile$ + "." + Risp$(i)
    '           Editore 0, NomeFile$, item$(i)
    '          Next
    '     End If 'v
    ' End If 'w
    'End If  'x
    'Next
    'Exit Sub
    'NomItem:
    '     Nrdit = Val(Mid$(NomeFile$, 5, 2))
    '     If Nrdit > 0 And (i < 9 Or i > 10) Then
    '1090 item$ = Datbase(2, 1, Nrdit, 1, itp$, 0)
    '     ElseIf i = 9 Then
    '     item$ = "Banco n." + Globalroutines.mystr(CSng(Nrdit), 3, 0, True)
    '     Else
    '     item$ = ""
    '     End If
    'Return
    'ErrStampe: PRINT "Errore in Stampe"; ERR; ERL: u$ = INPUT$(1): END
    'End Sub
    Public Sub Hstampe()
        'CLOSPREV()
        'FileClose(1)
        job1 = job
        Globale = True
        Apert.Enabled = False
        Dim FormStampe As New frmStampe
        FormStampe.ShowDialog()
        '		Do 
        'System.Windows.Forms.Application.DoEvents()
        'Loop While Not FinitoStampe
        'FinitoStampe = False
        Apert.Enabled = True
        FormStampe.Dispose()
        If Not job.Contratto = job1.Contratto Then
            job = job1
            If Len(Trim(job.Contratto)) Then CarPre(True)
        Else
            Monitor.Motore.Retrievejob("", Monitor.Motore.Inizio.Gancio)
        End If
        Globale = False
    End Sub
End Module