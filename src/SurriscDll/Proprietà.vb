Option Strict Off
Option Explicit On
Friend Class Proprietà
	Private pgas, pvap As Single
	Private tmin As Single
	Private Tmax As Single
	Private Npunti As Single
	Private CpGasA() As Single
	Private CpVapA() As Single
	Private VolGasA() As Single
	Private VolVapA() As Single
	Private kGasA() As Single
	Private kVapA() As Single
	Private ViscoGasA() As Single
	Private ViscoVapA() As Single
	Private Temp() As Single
	'UPGRADE_NOTE: Class_Initialize è stato aggiornato a Class_Initialize_Renamed. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
	Private Sub Class_Initialize_Renamed()
		'Inizia
	End Sub
	Public Sub New()
		MyBase.New()
		Class_Initialize_Renamed()
	End Sub
	Public ReadOnly Property CpGas(ByVal T As Single) As Single
		Get
			Dim i As Short
			Select Case Problem.FluidiInvertiti
				Case False : i = 1
				Case True : i = 2
			End Select
			CpGas = Interp(T, i)
		End Get
	End Property
	Public ReadOnly Property CpVap(ByVal T As Single) As Single
		Get
			Dim i As Short
			Select Case Problem.FluidiInvertiti
				Case False : i = 2
				Case True : i = 1
			End Select
			CpVap = Interp(T, i)
		End Get
	End Property
	Public ReadOnly Property VolGas(ByVal T As Single) As Single
		Get
			Dim i As Short
			Select Case Problem.FluidiInvertiti
				Case False : i = 3
				Case True : i = 4
			End Select
			VolGas = Interp(T, i)
		End Get
	End Property
	Public ReadOnly Property VolVap(ByVal T As Single) As Single
		Get
			Dim i As Short
			Select Case Problem.FluidiInvertiti
				Case False : i = 4
				Case True : i = 3
			End Select
			VolVap = Interp(T, i)
		End Get
	End Property
	Public ReadOnly Property kGas(ByVal T As Single) As Single
		Get
			Dim i As Short
			Select Case Problem.FluidiInvertiti
				Case False : i = 5
				Case True : i = 6
			End Select
			kGas = Interp(T, i)
		End Get
	End Property
	Public ReadOnly Property kVap(ByVal T As Single) As Single
		Get
			Dim i As Short
			Select Case Problem.FluidiInvertiti
				Case False : i = 6
				Case True : i = 5
			End Select
			kVap = Interp(T, i)
		End Get
	End Property
	Public ReadOnly Property ViscoGas(ByVal T As Single) As Single
		Get
			Dim i As Short
			Select Case Problem.FluidiInvertiti
				Case False : i = 7
				Case True : i = 8
			End Select
			ViscoGas = Interp(T, i)
		End Get
	End Property
	Public ReadOnly Property ViscoVap(ByVal T As Single) As Single
		Get
			Dim i As Short
			Select Case Problem.FluidiInvertiti
				Case False : i = 8
				Case True : i = 7
			End Select
			ViscoVap = Interp(T, i)
		End Get
	End Property
	Public ReadOnly Property CpGasV(ByVal T As Single) As Single
		Get
			CpGasV = Interp(T, 1)
		End Get
	End Property
	Public ReadOnly Property CpVapV(ByVal T As Single) As Single
		Get
			CpVapV = Interp(T, 2)
		End Get
	End Property
	Public ReadOnly Property VolGasV(ByVal T As Single) As Single
		Get
			VolGasV = Interp(T, 3)
		End Get
	End Property
	Public ReadOnly Property VolVapV(ByVal T As Single) As Single
		Get
			VolVapV = Interp(T, 4)
		End Get
	End Property
	Public ReadOnly Property kGasV(ByVal T As Single) As Single
		Get
			kGasV = Interp(T, 5)
		End Get
	End Property
	Public ReadOnly Property kVapV(ByVal T As Single) As Single
		Get
			kVapV = Interp(T, 6)
		End Get
	End Property
	Public ReadOnly Property ViscoGasV(ByVal T As Single) As Single
		Get
			ViscoGasV = Interp(T, 7)
		End Get
	End Property
	Public ReadOnly Property ViscoVapV(ByVal T As Single) As Single
		Get
			ViscoVapV = Interp(T, 8)
		End Get
	End Property
	Public Function Interp(ByRef T As Single, ByRef cod As Short) As Single
		Dim i As Short
		Dim Locale As Single
		If Problem.PressGasIn <= 0 Then
			MsgBox("Non è stata fornita la pressione del gas per il calcolo delle proprietà termodinamiche", MsgBoxStyle.Critical)
			Exit Function
		End If
		If Problem.PressVapIn <= 0 Then
			MsgBox("Non è stata fornita la pressione del vapore per il calcolo delle proprietà termodinamiche", MsgBoxStyle.Critical)
			Exit Function
		End If
		If (pgas <> Problem.PressGasIn Or pvap <> Problem.PressVapIn) Then Inizia(True)
        If CpGasA(0) = 0 Then Exit Function
        Dim i0 As Short
		If T > Temp(Npunti) Then
            i0 = Npunti
        Else
            i0 = 0
        End If
        For i = i0 To Npunti
            If T < Temp(i) Then
                If i = 0 Then i = 1
                Select Case cod
                    Case 1 : Locale = CpGasA(i - 1) + (T - Temp(i - 1)) * (CpGasA(i) - CpGasA(i - 1)) / (Temp(i) - Temp(i - 1))
                    Case 2 : Locale = CpVapA(i - 1) + (T - Temp(i - 1)) * (CpVapA(i) - CpVapA(i - 1)) / (Temp(i) - Temp(i - 1))
                        If Locale < CpVapA(i) / 2 Then Locale = CpVapA(i)
                    Case 3 : Locale = VolGasA(i - 1) + (T - Temp(i - 1)) * (VolGasA(i) - VolGasA(i - 1)) / (Temp(i) - Temp(i - 1))
                    Case 4 : Locale = VolVapA(i - 1) + (T - Temp(i - 1)) * (VolVapA(i) - VolVapA(i - 1)) / (Temp(i) - Temp(i - 1))
                    Case 5 : Locale = kGasA(i - 1) + (T - Temp(i - 1)) * (kGasA(i) - kGasA(i - 1)) / (Temp(i) - Temp(i - 1))
                    Case 6 : Locale = kVapA(i - 1) + (T - Temp(i - 1)) * (kVapA(i) - kVapA(i - 1)) / (Temp(i) - Temp(i - 1))
                    Case 7 : Locale = ViscoGasA(i - 1) + (T - Temp(i - 1)) * (ViscoGasA(i) - ViscoGasA(i - 1)) / (Temp(i) - Temp(i - 1))
                    Case 8 : Locale = ViscoVapA(i - 1) + (T - Temp(i - 1)) * (ViscoVapA(i) - ViscoVapA(i - 1)) / (Temp(i) - Temp(i - 1))
                End Select
                Interp = Locale
                Exit Function
            End If
        Next
    End Function
	
	Public Sub Inizia(ByRef Verboso As Boolean)
		Dim i As Short
		Dim dt As Single
		If Config.Autom Then Npunti = 20 Else Npunti = 1
		If Problem.PressGasIn < 1 Or Problem.PressVapIn < 1 Or Problem.PressGasIn > 1000 Or Problem.PressVapIn > 1000 Then
			If Verboso Then MsgBox("Non sono state definite le pressioni dei fumi e del vapore", MsgBoxStyle.Critical)
			Exit Sub
		End If
		'pgas = Problem.PressGasIn
		'pvap = Problem.PressVapIn
		ReDim CpGasA(Npunti)
		ReDim CpVapA(Npunti)
		ReDim VolGasA(Npunti)
		ReDim VolVapA(Npunti)
		ReDim kGasA(Npunti)
		ReDim kVapA(Npunti)
		ReDim ViscoGasA(Npunti)
		ReDim ViscoVapA(Npunti)
		ReDim Temp(Npunti)
		Gas.Inizializza()
		With Problem
			tmin = .Temp.Tvin
			If .Temp.Tgasout < tmin And .Temp.Tgasout > 0 Then tmin = .Temp.Tgasout
			Tmax = .Temp.Tvout
			If .Temp.Tgasin > Tmax Then Tmax = .Temp.Tgasin
			dt = Tmax - tmin
			If tmin = 0 Or Tmax = 0 Or dt = 0 Then
				If Verboso Then MsgBox("Non sono state definite correttamente le temperature di lavoro dei fluidi", MsgBoxStyle.Critical)
				'pgas = 0: pvap = 0
				Exit Sub
			End If
			'If Not Config.Autom Then Exit Sub
			pgas = Problem.PressGasIn
			pvap = Problem.PressVapIn
			tmin = tmin - dt / 50
			Tmax = Tmax + dt / 50
			dt = Tmax - tmin
			For i = 0 To Npunti
				Temp(i) = tmin + i * dt / Npunti
				CpGasA(i) = Gas.Cp(Temp(i), .PressGasIn)
				If CpGasA(i) = 0 Then
					If Verboso Then MsgBox("Le proprietà del gas non sono definite")
					Exit Sub
				End If
				'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Vap.Cp. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				CpVapA(i) = Vap.Cp(Temp(i), .PressVapIn)
				VolGasA(i) = 1 / Gas.Dens(Temp(i), .PressGasIn)
				'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Vap.Dens. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				VolVapA(i) = 1 / Vap.Dens(Temp(i), .PressVapIn)
				kGasA(i) = Gas.Conduc(Temp(i), .PressGasIn)
				'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Vap.Conduc. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				kVapA(i) = Vap.Conduc(Temp(i), .PressVapIn)
				ViscoGasA(i) = Gas.Visco(Temp(i), .PressGasIn)
				'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Vap.Visco. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ViscoVapA(i) = Vap.Visco(Temp(i), .PressVapIn)
			Next 
		End With
	End Sub
	
	Public Sub Transfer()
		Dim n As Single
		Dim l As Boolean
		On Error GoTo ErrN
		n = Problem.tmin + 0#
		l = n < 0
ResN: 
		On Error GoTo 0
		Gas.tmin = Problem.tmin
		Gas.Tmax = Problem.Tmax
		Gas.VolMin = Problem.VolMin
		Gas.VolMax = Problem.VolMax
		Gas.ViscoMin = Problem.ViscoMin
		Gas.ViscoMax = Problem.ViscoMax
		Gas.CpMin = Problem.CpMin
		Gas.CpMax = Problem.CpMax
		Gas.kMin = Problem.kMin
		Gas.kMax = Problem.kMax
		Exit Sub
ErrN: 
		Problem.tmin = 0
		Problem.Tmax = 0
		Problem.VolMin = 0
		Problem.VolMax = 0
		Problem.ViscoMin = 0
		Problem.ViscoMax = 0
		Problem.CpMin = 0
		Problem.CpMax = 0
		Problem.kMin = 0
		Problem.kMax = 0
		Problem.PressGasIn = 0
		Problem.PressVapIn = 0
		Problem.dpAllGas = 0
		Problem.dpAllVap = 0
		Problem.Qgas = 0
		Problem.Qvap = 0
		Problem.QminReg = 0
		Config.Autom = True
		Config.Progetto = 0
		Config.VariabIndProg = 0
		Config.TipoCalc = 0
		Geom.TipoPassoInt = 0
		Geom.TipoPassoExt = 0
		Resume ResN
	End Sub
End Class