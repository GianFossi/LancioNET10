Option Strict Off
Option Explicit On
Module typWald
	Structure prbWald
		Dim iV1 As Short
		Dim iV2 As Short
		Dim iCode As Short
		Dim iUnit As Short
		'UPGRADE_WARNING: La dimensione della stringa di lunghezza fissa deve essere contenuta nel buffer. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
		<VBFixedString(1),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=1)> Public ABC() As Char
		Dim iAcqua As Short
		Dim iPond As Short
		Dim iH2 As Short
		Dim iAbs As Short
		Dim iEquil As Short
		Dim iCost As Short
		Dim iIdeal As Short
		Dim precEntalp As Boolean
		Dim precEntrop As Boolean
		Dim Tequi As Short
		Dim Pequi As Short
		Dim iHc As Short
		<VBFixedArray(100)> Dim Compos() As Single
		<VBFixedArray(100)> Dim Sceltaf() As Short
		<VBFixedArray(100)> Dim SceltaComponenti() As Boolean
		'UPGRADE_WARNING: La dimensione della stringa di lunghezza fissa deve essere contenuta nel buffer. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
		<VBFixedString(40),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=40)> Public ClientPlant() As Char
		'UPGRADE_WARNING: La dimensione della stringa di lunghezza fissa deve essere contenuta nel buffer. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
		<VBFixedString(10),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=10)> Public Item() As Char
		'UPGRADE_WARNING: La dimensione della stringa di lunghezza fissa deve essere contenuta nel buffer. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
		<VBFixedString(40),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=40)> Public Problema() As Char
		'UPGRADE_WARNING: La dimensione della stringa di lunghezza fissa deve essere contenuta nel buffer. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
		<VBFixedString(10),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=10)> Public Author() As Char
		Dim deltaT As Single
		Dim deltaP As Single
		Dim Npun As Short
		Dim X As Short
		<VBFixedArray(8)> Dim Variab() As Single
		Dim Ncom As Short
		Dim NZONE As Short
		<VBFixedArray(13)> Dim Tzone() As Single
		<VBFixedArray(13)> Dim Hzone() As Single
        Dim TipZone() As String
		<VBFixedArray(13)> Dim PassZone() As Short
		Dim Y As Short 'variabili della trasformazione
		Dim Z As Short
		Dim nIter As Short
		Dim iPrecis As Short
		Dim kwrt As Short
		Dim iDebug As Short
		Dim iSetCost As Short
		Dim iStLib As Short
        <VBFixedString(203), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=203)> Public Pad As String
        Public Sub Initialize()
            ReDim Compos(100)
            ReDim Sceltaf(100)
            ReDim SceltaComponenti(100)
            ReDim Variab(8)
            ReDim Tzone(13)
            ReDim Hzone(13)
            ReDim PassZone(13)
            ReDim TipZone(13)
        End Sub
	End Structure
End Module