Option Strict Off
Option Explicit On
Module modMainPpg
	Public Structure typProblem
		Dim Version As Short
		'UPGRADE_WARNING: La dimensione della stringa di lunghezza fissa deve essere contenuta nel buffer. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
		<VBFixedString(20),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=20)> Public ClientPlant() As Char
		'UPGRADE_WARNING: La dimensione della stringa di lunghezza fissa deve essere contenuta nel buffer. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
		<VBFixedString(20),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=20)> Public Item() As Char
		'UPGRADE_WARNING: La dimensione della stringa di lunghezza fissa deve essere contenuta nel buffer. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
		<VBFixedString(10),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=10)> Public Commessa() As Char
		'UPGRADE_WARNING: La dimensione della stringa di lunghezza fissa deve essere contenuta nel buffer. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
		<VBFixedString(3),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=3)> Public Author() As Char
		'UPGRADE_WARNING: La dimensione della stringa di lunghezza fissa deve essere contenuta nel buffer. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
		<VBFixedString(30),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=30)> Public Fluido() As Char
		'UPGRADE_WARNING: La dimensione della stringa di lunghezza fissa deve essere contenuta nel buffer. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
		<VBFixedString(194),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=194)> Public Padding() As Char
	End Structure
	Public Structure typConfig
		Dim Ippgas65 As Short '0=16  1=65 2=manuale
		Dim PercVol As Short '0 volume 1 peso
		Dim Pressione As Single
		Dim idewpoint As Short
		Dim iUnit As Short
		Dim Tmin As Single
		Dim Tmax As Single
		Dim Tincr As Single
		Dim IasmePTC4 As Short
		Dim PesoMoc As Single
		'UPGRADE_WARNING: La dimensione della stringa di lunghezza fissa deve essere contenuta nel buffer. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
		<VBFixedString(196),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=196)> Public Padding() As Char
	End Structure
	Structure CondCurva
		'UPGRADE_WARNING: La dimensione della stringa di lunghezza fissa deve essere contenuta nel buffer. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
		<VBFixedString(1),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=1)> Public Tipo() As Char
		'UPGRADE_WARNING: La dimensione della stringa di lunghezza fissa deve essere contenuta nel buffer. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
		<VBFixedString(1),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=1)> Public PadS() As Char
		Dim Npun As Short
		Dim Temp As Single '1
		Dim Pres As Single '2
		Dim Xgas As Single '3
		Dim Entl As Single '4
		Dim Hliq As Single '5
		Dim Hgas As Single '6
		Dim Cgas As Single '7
		Dim Visg As Single '8
		Dim Visl As Single '9
		Dim Cong As Single '10
		Dim Conl As Single '11
		Dim Cfac As Single '12
		Dim Cliq As Single '13
		Dim DenV As Single '14
		Dim Sgra As Single '15
		Dim MolT As Single '16
		Dim MolL As Single '17
		Dim MolG As Single '18
		Dim XAcq As Single
		Dim HAcq As Single
		<VBFixedArray(10)> Dim Pad() As Single
		
		'UPGRADE_TODO: "Initialize" deve essere chiamato per inizializzare istanze di questa struttura. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="B4BFF9E0-8631-45CF-910E-62AB3970F27B"'
		Public Sub Initialize()
			'UPGRADE_WARNING: Il limite inferiore della matrice Pad è stato cambiato da 1 a 0. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
			ReDim Pad(10)
		End Sub
	End Structure
	
	Public Const CalJ As Single = 4185.5
	Public Const BTUJ As Single = 1000000# '$$$$$$$$$$$$$$$
	Public Const kgmscp As Single = 0.86011 'conducibilità
	Public Const kgmsB As Single = 0.57779 'conducibilità
	Public Const ViscK As Single = 1000
	Public Const ViscB As Single = 1000
	Public Const DensK As Single = 1
	Public Const DensB As Single = 1000 '$$$$$$$$$$$$$$$
	Public Const grav As Single = 0.980665
	Public Const PSI As Single = 145.0377439
    Public Monitor As ppgMonitor
    Public Ifluide As Short
    Public Const FormSci As String = "#.###E+##"
    Public Const FormMu As String = "#.#######"
    Public Const FormCp As String = "####.#"
    Public Const FormDen As String = "###.####"
    Public ApertoCurva As Boolean
    Public CurvPoint() As CondCurva
    Public nPoints As Short
    Public myAssembly As System.Reflection.Assembly
    Friend Funzioni As New RoutBase1.clsTrigon
    Public Function ConvGiu(ByRef v As Single, ByRef var As Short) As Single
        'conversione verso le unità di output
        ConvGiu = v
        Select Case var
            Case 1 'cp
                Select Case Monitor.Ogg.priUnit
                    Case 1 : ConvGiu = v / CalJ
                    Case 3 : ConvGiu = v / BTUJ
                End Select
            Case 2 'conducibilità
                Select Case Monitor.Ogg.priUnit
                    Case 1 : ConvGiu = v * kgmscp
                    Case 3 : ConvGiu = v * kgmsB
                End Select
            Case 3 'viscosità
                Select Case Monitor.Ogg.priUnit
                    Case 1 : ConvGiu = v * ViscK
                    Case 3 : ConvGiu = v * ViscB
                End Select
            Case 4 'densità
                Select Case Monitor.Ogg.priUnit
                    Case 1 : ConvGiu = v * DensK
                    Case 3 : ConvGiu = v * DensB
                End Select
            Case 5 'pressione
                Select Case Monitor.Ogg.priUnit
                    Case 1 : ConvGiu = v / grav
                    Case 3 : ConvGiu = v * PSI / 10
                End Select
            Case 6 'temperatura
                Select Case Monitor.Ogg.priUnit
                    Case 1 : ConvGiu = v
                    Case 3 : ConvGiu = v * 1.8 + 32
                End Select
        End Select
    End Function
    Public Function ConvSu(ByRef v As Single, ByRef var As Short) As Single
        'conversione verso l'unità interna
        ConvSu = v
        Select Case var
            Case 1 'cp
                Select Case Monitor.Ogg.priUnit
                    Case 1 : ConvSu = v * CalJ
                    Case 3 : ConvSu = v * BTUJ
                End Select
            Case 2 'conducibilità
                Select Case Monitor.Ogg.priUnit
                    Case 1 : ConvSu = v / kgmscp
                    Case 3 : ConvSu = v / kgmsB
                End Select
            Case 3 'viscosità
                Select Case Monitor.Ogg.priUnit
                    Case 1 : ConvSu = v / ViscK
                    Case 3 : ConvSu = v / ViscB
                End Select
            Case 4 'densità
                Select Case Monitor.Ogg.priUnit
                    Case 1 : ConvSu = v / DensK
                    Case 3 : ConvSu = v / DensB
                End Select
            Case 5 'pressione
                Select Case Monitor.Ogg.priUnit
                    Case 1 : ConvSu = v * grav
                    Case 3 : ConvSu = v / PSI * 10
                End Select
            Case 6 'temperatura
                Select Case Monitor.Ogg.priUnit
                    Case 1 : ConvSu = v
                    Case 3 : ConvSu = (v - 32) / 1.8
                End Select
        End Select
    End Function
    Public Sub ConvertiDatiSu()
        Dim im, var, i As Short
        With Monitor.Ogg
            If .priUnit = 0 Or .prIppgas65 < 2 Then Exit Sub
            For i = 1 To 13 - Ifluide + 1
                im = i - 1
                Select Case im
                    Case 0 To 3 : var = 1
                    Case 4 To 6 : var = 2
                    Case 7 To 9 : var = 3
                    Case 10 To 13 : var = 4
                End Select
                '   txtMan(i - 1) = Format(.prE3(2 * i), f)
                '   txtTemp1(i - 1) = Format(.prE3(2 * i - 1), FormCp)
                If Not (Ifluide = 1 And im > 9) Then
                    .prE3(2 * i) = ConvSu(.prE3(2 * i), var)
                    .prE3(2 * i - 1) = ConvSu(.prE3(2 * i - 1), 6)
                End If
            Next
            If Ifluide = 2 Then
                .prE3(22) = ConvSu(.prE3(22), 4)
                .prE3(23) = ConvSu(.prE3(23), 6)
                .prE3(21) = ConvSu(.prE3(21), 6)
            End If
        End With
    End Sub
    Public Sub ConvertiDatiGiu()
        Dim im, var, i As Short
        With Monitor.Ogg
            If .priUnit = 0 Or .prIppgas65 < 2 Then Exit Sub
            For i = 1 To 13 - Ifluide + 1
                im = i - 1
                Select Case im
                    Case 0 To 3 : var = 1
                    Case 4 To 6 : var = 2
                    Case 7 To 9 : var = 3
                    Case 10 To 13 : var = 4
                End Select
                '   txtMan(i - 1) = Format(.prE3(2 * i), f)
                '   txtTemp1(i - 1) = Format(.prE3(2 * i - 1), FormCp)
                If Not (Ifluide = 1 And im > 9) Then
                    .prE3(2 * i) = ConvGiu(.prE3(2 * i), var)
                    .prE3(2 * i - 1) = ConvGiu(.prE3(2 * i - 1), 6)
                End If
            Next
            If Ifluide = 2 Then
                .prE3(22) = ConvGiu(.prE3(22), 4)
                .prE3(23) = ConvGiu(.prE3(23), 6)
                .prE3(21) = ConvGiu(.prE3(21), 6)
            End If
        End With
        Monitor.Ogg.ConvUnit()
    End Sub
End Module