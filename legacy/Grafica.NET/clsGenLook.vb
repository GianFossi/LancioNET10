Option Strict Off
Option Explicit On
<System.Runtime.InteropServices.ProgId("clsGenLook_NET.clsGenLook")> Public Class clsGenLook
	Public K1 As Short
	Public K2 As Short
	Public K3 As Short
	Public t As Single
	Public Adim As Single
	Public H1 As Single
	Public B1 As Single
	Public H2 As Single
	Public B2 As Single
	Public b As Single
	Public SG As Single
	Public d As Single
	Public H3 As Single
	Public B3 As Single
	Public H4 As Single
	Public B4 As Single
	Public SOVRA As Short
	Public ForniFuori As Short
	Public VirolFuori As Short
	Public Dum As Short
	Public TipoV As Short
	Public XVec As Short
	Public T1 As Single
	Public T2 As Single
	Public TF As Single
	Public Dcal As Single
	Public Ddis As Single
	Public g0 As Single
	Public g1 As Single
	Public H As Single
	Public kLam As Short
	Public Lavorato As Short
	Public DG As Single
	Public O As Single
	Public R As Single
	Public c As Single
	Public l As Single
	Public y As Single
	Public x As Single
	Public racc As Single
	Public junk As Short
	Public junk1 As Short
	Public junk2 As Short
	Public junk3 As Short
	Public junk4 As Short
	Public junk5 As Short
	Public junk6 As Short
	Public ALTBOC As Single
	Public DSCAR As Single
	Public TSCAR As Single
	Public DRINF As Single
	Public HRINF As Single
	Public RANZA As Single
	Public HRANZA As Single
	Public HRANZAe As Single
	Public HRANZAi As Single
	Public BC As Single
	Public DF As Single
	Public f As Single
	Public p As Single
	Public E As Single
	Public DFor As Single
	Public ProfCava As Short
	Public LargCava As Short
	Public DIMAX As Single
	Public DIMIN As Single
	Public Onde As Short
	Public nPli As Short
	Public AlungC As Single
	Public LunTira As Single
	Public SpessC As Single
	Public SezRinf As Single
	Public SezTira As Single
	Public Nfield As Short
	Public LC As Short
	Public NVIR As Short
	Public SpostLat As Single
	Public APied As Single
	Public APied1 As Single
	Public D1 As Single
	Public R1 As Single
	Public AlfaCon As Single
	Public NSpicchi As Short
	Public Formafuori As Short
	Public NSAL As Short
	Public NPE As Short
	Public TabFlan As Short
	Public Nfori As Short
	Public NSPI As Short
	Public Facing As Short
	Public TipoF As Short
	Sub RecordFlangione(ByRef Dati() As Single)
		Dati(10) = 1000 * kLam - 100 * Lavorato + TipoV * 10 + XVec
		Dati(1) = Adim
		Dati(2) = b
		Dati(4) = t
		Dati(9) = T1
		Dati(3) = DG
		If TipoV < 4 Then
			Dati(5) = SG
			Dati(6) = g0
			Dati(7) = g1
			Dati(8) = H
		Else
			Dati(11) = d
			Dati(5) = SG + 500 * T2
			Dati(6) = g0 + 500 * B1
			Dati(7) = g1 + 500 * B2
			Dati(8) = H + 500 * H1
		End If
	End Sub
	Sub LookTipoPiastra(ByRef Dati() As Single)
		t = Dati(1)
		Adim = Dati(2)
		H1 = Dati(3)
		B1 = Dati(4)
		H2 = Dati(5)
		B2 = Dati(6)
		H3 = Dati(7)
		B3 = Dati(8)
		SOVRA = -Dati(9) \ 1000
		Dum = Dati(9) + 1000 * SOVRA
		ForniFuori = -Dum \ 100
		Dum = Dum + 100 * ForniFuori
		TipoV = Dum \ 10
		XVec = Dum - 10 * TipoV
		T1 = Dati(10) \ 900
		Dum = Dati(10) - 900 * T1
		LargCava = Dum \ 30
		ProfCava = Dum - 30 * LargCava
		If TipoV = 3 Then
			H1 = Dati(3) \ 100
			H4 = Dati(3) - 100 * H1
			H2 = Dati(5) \ 100
			If H2 < 0 And H2 * 100 > Dati(5) + 1 Then H2 = H2 - 1
			H3 = Dati(5) - 100 * H2
			B4 = Dati(7)
		End If
	End Sub
	Sub LookTipoFlangione(ByRef Dati() As Single)
		Dim Lungo As Integer
		kLam = Dati(10) \ 1000
		Dum = Dati(10) - 1000 * kLam
		Lavorato = -Dum \ 100
		Dum = Dum + 100 * Lavorato
		TipoV = Dum \ 10
		XVec = Dum - 10 * TipoV
		Adim = Dati(1)
		b = Dati(2)
		DG = Dati(3)
		t = Dati(4)
		T1 = Dati(9)
		If TipoV < 4 Then
			SG = Dati(5)
			g0 = Dati(6)
			g1 = Dati(7)
			H = Dati(8)
		Else
			d = Dati(11)
			Lungo = Dati(5) : T2 = Lungo \ 500 : SG = Lungo Mod 500
			Lungo = Dati(6) : B1 = Lungo \ 500 : g0 = Lungo Mod 500
			Lungo = Dati(7) : B2 = Lungo \ 500 : g1 = Lungo Mod 500
			Lungo = Dati(8) : H1 = Lungo \ 500 : H = Lungo Mod 500
		End If
	End Sub
	Sub LookTipoDilat(ByRef Dati() As Single)
		DIMAX = Dati(1)
		DIMIN = Dati(2)
		R = Dati(3) \ 100
		t = Dati(3) - R * 100
		l = Dati(4)
		H = Dati(5)
		AlungC = Dati(6)
		LunTira = Dati(7)
		Onde = Dati(8) \ 1000
		Dum = Dati(8) - 1000 * Onde
		nPli = Dum \ 100
		Dum = Dum - 100 * nPli
		XVec = Dum \ 10
		TipoV = Dum - 10 * XVec
		SpessC = Dati(9)
		SezRinf = Dati(10)
		SezTira = Dati(11)
	End Sub
	Sub LookTipoCon(ByRef Dati() As Single)
		APied = Dati(1)
		d = Dati(2)
		R = Dati(3)
		APied1 = Dati(4)
		D1 = Dati(5)
		R1 = Dati(6)
		H = Dati(7)
		NSAL = Dati(8) \ 100
		AlfaCon = Dati(8) - 100 * NSAL
		T1 = Dati(9) \ 100
		T2 = Dati(9) - 100 * T1
		NSpicchi = Dati(10) \ 1000
		Dati(10) = Dati(10) - 1000 * NSpicchi
		Formafuori = -Dati(10) \ 100
		XVec = Dati(10) + 100 * Formafuori
	End Sub
	Sub LookTipoNStd(ByRef Dati() As Single, ByRef Dati2() As Single)
		Lavorato = Dati(1) \ 100
		TipoV = Dati(1) + 100 * Lavorato '1 senza rip.; 2 con; 3 lining
		b = Dati(3) 'diam.interno
		ALTBOC = Dati(5) 'L
		junk = Dati(7) 'Scarpa
		junk6 = (junk Mod 2) + 1 : junk = junk \ 2 '1 non   cieca 2     cieca
		junk5 = (junk Mod 2) + 1 : junk = junk \ 2 '1 non   cieca 2     cieca
		junk4 = (junk Mod 2) + 1 : junk = junk \ 2 '1 senza accopiata 2 con
		junk3 = (junk Mod 2) + 1 : junk = junk \ 2 'con flangia/stub
		junk2 = (junk Mod 2) + 1 : junk = junk \ 2 'con autorinforzo
		junk1 = (junk Mod 2) + 1 'con scarpa
		H = Dati2(2)
		B1 = Dati2(4) 'F1
		B2 = Dati2(11) 'DI
		If junk1 = 2 Then
			DSCAR = Dati(6) 'diametro alla base (da rivedere) 'Q
			TSCAR = Dati(9)
			B2 = 0 : B1 = 0 : H = 0 'S
		Else
			DSCAR = 0 : TSCAR = 0
		End If 'zzz
		If junk2 = 2 Or junk3 = 2 Then
			DRINF = Dati(2) 'diametro alla base (da rivedere)   'G
			HRINF = Dati(4) 'F
			'        Else
			'           .DRINF = 0: .HRINF = 0
		End If
		RANZA = Dati(8)
		SpostLat = Dati(11)
		d = Dati2(1)
		H1 = Dati2(3)
		Adim = Dati2(5) 'DE
		t = Dati2(6)
		B3 = Dati2(7) 'DB
		LC = Dati2(8) 'NB
		BC = Dati2(9) 'bolt circle
	End Sub
	Sub LookTipoBocch(ByRef Dati() As Single, ByRef Completo As Short, Optional ByRef St As Flangia = Nothing)
		On Error GoTo ErrLookB
		Dim Nuovo, Log1 As Boolean
		Dim Lungo As Integer
		Dim Cera As Boolean
		TabFlan = Dati(1) \ 100
10: TipoV = Dati(1) - 100 * TabFlan '1 senza rip. 2 con 3 fl.rip. e tr.pl. 4 lining 5 fl.rip. 6 fl non
		K2 = Dati(2) \ 100
		If K2 = 0 Then
			K1 = Dati(2)
			K2 = Dati(3)
			Nuovo = False
		Else
			K1 = Dati(2) - 100 * K2
			b = Dati(3)
			Nuovo = True
		End If
		If Not St Is Nothing Then
			St.K1 = K1
			St.K2 = K2
			St.K3 = K3
			St.Facing = Facing
			St.TabFlan = TabFlan
		End If
		Lavorato = -Dati(4) \ 100
		K3 = Dati(4) + 100 * Lavorato '1 WN  2 SO  3 LJ 4 LWN  5 BLIND
12: ALTBOC = Dati(5)
		junk = Dati(7) 'Scarpa
		junk5 = (junk Mod 2) + 1 : junk = junk \ 2 '=2 la sottodetta Š cieca
		junk4 = (junk Mod 2) + 1 : junk = junk \ 2 '=2 con flangia accoppiata
		junk3 = (junk Mod 2) + 1 : junk = junk \ 2 '=2 con pezza
		junk2 = (junk Mod 2) + 1 : junk = junk \ 2 '=2 da forgiato autorinforzato
		junk1 = (junk Mod 2) + 1 '=2 da forgiato con scarpa
14: If junk1 = 2 Then
			DSCAR = Dati(6) 'diametro alla base (da rivedere)
			TSCAR = Dati(9)
		Else
			DRINF = Dati(6) 'diametro alla base (da rivedere)
			HRINF = Dati(9)
		End If
16: RANZA = Dati(8)
		Lungo = Dati(10)
		t = Int(Lungo / 15) / 15
		'If .t = 0 Then
		'.t = Lungo
		'.Facing = 1
		'Else
		Facing = Lungo - 15 * Int(Lungo / 15)
		'End If
		SpostLat = Dati(11)
		TipoF = Dati(12)
		'--------------------------------------------------------
		If K1 * K2 * K3 = 0 Or Not Completo Then Exit Sub
		If Not St Is Nothing Then
			globFlangia = St
			globFlangia.leggi(K1, K2, Facing, TabFlan, K3, False, Monitor.Motore.Inizio.DiscoRam)
			Cera = True
		Else
			If globFlangia Is Nothing Then
				Cera = False
				globFlangia = New Grafica.Flangia
				globFlangia.DoveMotore = Monitor.Motore
				globFlangia.leggi(K1, K2, Facing, TabFlan, K3, False, Monitor.Motore.Inizio.DiscoRam)
			Else
				Cera = True
				Log1 = (K1 <> globFlangia.K1)
				Log1 = (K2 <> globFlangia.K2) Or Log1
				Log1 = (K3 <> globFlangia.K3) Or Log1
				Log1 = (Facing <> globFlangia.Facing) Or Log1
				Log1 = (TabFlan <> globFlangia.TabFlan) Or Log1
				Log1 = (globFlangia.DiamExt = 0) Or Log1
				If Log1 Then globFlangia.leggi(K1, K2, Facing, TabFlan, K3, False, Monitor.Motore.Inizio.DiscoRam)
			End If
		End If
21: O = globFlangia.DiamExt 'diametro esterno
		c = globFlangia.Spessore 'Spessore flangia
		R = globFlangia.GradExt 'Diametro gradino
		l = globFlangia.SpessGrad 'Spessore gradino
		y = globFlangia.Altezza 'Altezza flangia
		x = globFlangia.x 'diam max codolo
		Adim = globFlangia.DiamTr 'diametro esterno del piede
		If DRINF < Adim Then DRINF = Adim
		If t > 0 Then
			globFlangia.SpessTr = t
		Else
			t = globFlangia.SpessTr 'spessore tronchetto schedulato
		End If
		If Not Nuovo Or b = 0 Then b = globFlangia.DiamInt 'diam.interno del piede
		racc = globFlangia.Raccordo
		If RANZA > 0 Then
			HRANZAe = RANZA - System.Math.Sqrt(RANZA * RANZA - (Dati(6) / 2) ^ 2)
			HRANZAi = RANZA - System.Math.Sqrt(RANZA * RANZA - (b / 2) ^ 2)
		End If
22: If K3 = 4 Then
			x = Adim + 2 * racc
			If ALTBOC > 0 Then y = ALTBOC '+ HRANZAe * -iSwRanda
		End If
		BC = globFlangia.BC
		DF = globFlangia.DiaFori
		If Facing = 12 Then
			f = globFlangia.SpessGrad * 1.3 '5!               'larghezza gola RJ
			p = globFlangia.DiamGr0 '(.R + .B) / 2      'diametro RJ
			E = globFlangia.SpessGrad '0!               'profondit… gola
		Else
			E = 0
			f = 0
			p = globFlangia.GradExt
		End If
		Nfori = globFlangia.NumBolts
		If Not Cera Then
            'globFlangia.Class_Terminate_Renamed()
			'UPGRADE_NOTE: È possibile che l'oggetto globFlangia non venga eliminato finché non venga raccolto nel Garbage Collector. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1029"'
            'globFlangia = Nothing
		End If
		Exit Sub
ErrLookB: MsgBox("Errore in LookTipoBocch" & ErrorToString() & Str(Erl()))
		Stop 'End
	End Sub
	Public Sub RecordDatiDilat(ByRef Dati() As Single)
		Dati(1) = DIMAX
		Dati(2) = DIMIN
		Dati(3) = 100 * R + t
		Dati(4) = l
		Dati(5) = H
		Dati(6) = AlungC 'llare
		Dati(7) = LunTira
		Dati(8) = 1000 * Onde + 100 * nPli + 10 * XVec + TipoV
		Dati(9) = SpessC
		Dati(10) = SezRinf
		Dati(11) = SezTira
	End Sub
	Public Sub RecordBocch(ByRef Dati() As Single)
		Dati(1) = 100 * TabFlan + TipoV
		Dati(2) = 100 * K2 + K1
		Dati(3) = b
		Dati(4) = K3 - 100 * Lavorato
		Dati(5) = ALTBOC
		Dati(7) = junk5 - 1 + (junk4 - 1) * 2 + (junk3 - 1) * 4 + (junk2 - 1) * 8 + (junk1 - 1) * 16
		Dati(8) = RANZA
		If junk1 = 2 Then
			Dati(6) = DSCAR
			Dati(9) = TSCAR
		Else
			Dati(6) = DRINF
			Dati(9) = HRINF
		End If
		Dati(10) = Int(t * 15) * 15 + Facing
		Dati(11) = SpostLat
	End Sub
	Public Sub RecDatiCon(ByRef Dati() As Single)
		Dati(1) = APied
		Dati(2) = d
		Dati(3) = R
		Dati(4) = APied1
		Dati(5) = D1
		Dati(6) = R1
		Dati(7) = H
		Dati(8) = AlfaCon + 100 * NSAL
		Dati(9) = T1 * 100 + T2
		Dati(10) = XVec - 100 * Formafuori + 1000 * NSPI
		'Dati(11) = Matdim(1).Ind
	End Sub
End Class