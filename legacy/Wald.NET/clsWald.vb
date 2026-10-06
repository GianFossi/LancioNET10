Option Strict Off
Option Explicit On
<System.Runtime.InteropServices.ProgId("clsWald_NET.clsWald")> Public Class clsWald
	Public TipCalc As Short '1,2,3 HTRI,manuale,automatico
	Public NumAltern As Object
    Public Sub New()
        MyBase.New()
        Monitor = New wldMonitor
        Monitor.Ogg = Me
        With ProblWLD
            .iAcqua = 1
            .iEquil = 1
            .iCost = 1
            .iHc = 1
            .iIdeal = 1
            .iUnit = 1
            .X = 1
        End With
        myAssembly = Me.GetType.Assembly
        rmHelpStrings = New _
           System.Resources.ResourceManager("Wald.Resources", myAssembly)
    End Sub
    Public WriteOnly Property DoveRoutines() As RoutBase1.Routines
        Set(ByVal Value As RoutBase1.Routines)
            Routines = Value
        End Set
    End Property
    Public WriteOnly Property DoveMotore() As RoutBase1.clsMotore
        Set(ByVal Value As RoutBase1.clsMotore)
            Monitor.Motore = Value
            Monitor.Motore.InitProb("ASME")
            RadiceHelp = Monitor.Motore.Inizio.AppLancio & rmHelpStrings.GetString("Helpfile") '"\BIN\AsmeVip.chm"
        End Set
    End Property
    Private Sub InitTitForm()

        Titoli(1) = "Temperatura"
        Titoli(2) = "Pressione"
        Titoli(3) = "Frazione gas"
        Titoli(4) = "Entalpia totale"
        Titoli(5) = "Entalpia liquido"
        Titoli(6) = "Entalpia vapore"
        Titoli(7) = "Cp vapore"
        Titoli(8) = "Viscosità vapore"
        Titoli(9) = "Viscosità liquido"
        Titoli(10) = "Conducibilità vapore"
        Titoli(11) = "Conducibilità liquido"
        Titoli(12) = "Fattore di comprimibilità"
        Formati(1) = "####.#,#####."
        Formati(2) = "###.#"
        Formati(3) = ""
        Formati(4) = "####.#"
        Formati(5) = "####.#"
        Formati(6) = "#.####"
        Formati(7) = "#.####"
        Formati(8) = "#.####"
        Formati(9) = "#.####"
        Formati(10) = "#.####"
        Formati(11) = ".#####"
        Formati(12) = "####"
        Formati(13) = "####.##"
        Formati(14) = "####.## ######.##"
        Formati(15) = "\\_,\\_,#### ####"
        Formati(16) = "&_,"
        Formati(17) = "##) & "

    End Sub
	
	
	Private Sub InitFF()
		Dim ifl, i As Short
		Dim t, d As String
		t = Monitor.Motore.Inizio.Archdir & "\IT\TESTIL.TXT"
		ifl = FreeFile
		FileOpen(ifl, t, OpenMode.Input)
		d = LineInput(ifl)
		d = LineInput(ifl)
		d = LineInput(ifl)
		d = LineInput(ifl)
		'        a$ = "   Calcolo caratteristiche fisiche fluidi|"
		'   a$ = a$ + "   --------------------------------------|"
		'   a$ = a$ + "     Opzioni disponibili:                |"
		'   a$ = a$ + "  1 - Dati forniti manualmente in HTRI   |"
		'   a$ = a$ + "  2 - Curva di raffredd. data manualmente|"
		'   a$ = a$ + "  3 - Curva di raffreddamento automatica |"
		d = LineInput(ifl)
		For i = 1 To 5
			d = LineInput(ifl)
			'Line Input #ifl, Riga
			'a$ = a$ + Riga
		Next 
		For i = 1 To 34 : FF(i) = LineInput(ifl) : Next 
		FileClose(ifl)
		
	End Sub
	Public Function EseguiDaPPG(ByRef Radice As String) As Boolean
		DaIsa = 2
		RadiceISA = Radice
		Leggi()
		AddRigaCurva = True
		TipCalc = 2
		ProblWLD.iUnit = 3
		ProblWLD.iAbs = 1
		ProblWLD.iPond = 1
		iQuale = 2
		EseguiDaPPG = True
		Manuale(Radice)
		If iQuale = 1 Then EseguiDaPPG = False
	End Function
	Public Sub EseguiDaISA(ByRef iQ As Short, ByRef Radice As String, ByRef Mode As Short, ByRef UniMis As String)
		'Mode 0 visualuzza,1 no
		DaIsa = 1
		RadiceISA = Radice
		Monitor.Motore.Problem.Commessa = Radice & ".WLD"
		Leggi()
		Select Case iQ
			Case 2 'manuale
				AddRigaCurva = True
				TipCalc = 2
				Select Case UniMis
					Case "SI" : ProblWLD.iUnit = 3
					Case "ME" : ProblWLD.iUnit = 1
					Case "BR" : ProblWLD.iUnit = 2
				End Select
				ProblWLD.iAbs = 1
				iQuale = 2
				Manuale(Radice)
				If iQuale = 1 Then iQ = 0
			Case 3
				AddRigaCurva = False
				TipCalc = 3
				Select Case UniMis
					Case "SI"
						iQ = 0
						MsgBox("Il programma Wald non prevede il sistema di misura SI", MsgBoxStyle.Critical, "WALD")
						Exit Sub
					Case "ME" : ProblWLD.iUnit = 1
					Case "BR" : ProblWLD.iUnit = 2
                End Select
                mioApert = New frmApert
                With mioApert
                    .mnufile(1).Enabled = False
                    .Picture1.Visible = False
                    .cmbTrasf.SelectedIndex = .cmbTrasf.Items.Count - 1
                    If Mode = 0 Then
                        .ShowDialog()
                        .Close()
                    Else
                        .Carica()
                    End If
                End With
                mioApert.Dispose()
		End Select
	End Sub
	Private Sub InitCompon()
		Dim ifl As Short
		Dim Nome As String
		NomiComponenti = New Collection
        ifl = FreeFile()
        Dim FileDati As String = rmHelpStrings.GetString("Componenti")
        If Not ApriFile(FileDati, ifl) Then Exit Sub
		Do 
			Nome = LineInput(ifl)
			If EOF(ifl) Then Exit Do
			If Len(Trim(Nome)) = 0 Then Exit Do
			NomiComponenti.Add(Nome)
		Loop 
		FileClose(ifl)
	End Sub
    Public Sub Esegui()
        DaIsa = 0
        AddRigaCurva = False
        mioApert = New frmApert
        With mioApert
            .Label1(0).Visible = False
            .cmbTipCalc.Visible = False
            .cmdFine.Visible = False
            .cmdProcedi.Enabled = False
            .cmdRapp.Enabled = False
            .ShowDialog()
            .Close()
            .Dispose()
        End With
    End Sub
    Public Sub Inizia()
        InitTitForm()
        InitFF()
        InitCompon()
    End Sub
End Class