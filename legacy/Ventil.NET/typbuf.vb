Option Strict Off
Option Explicit On
Imports System.Runtime.InteropServices
Module typBuf
    Structure Dispos
        <VBFixedArray(30, 100)> Dim Nite(,) As Short
        <VBFixedString(2000), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=2000)> Dim BayNome As String '*20
        <VBFixedArray(100)> Dim jcont() As Short
        Dim NumIt As Short
        <VBFixedString(1978), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=1978)> Dim Pad As String '*1
        Public Sub Initialize()
            ReDim Nite(30, 100)
            ReDim jcont(100)
        End Sub
    End Structure
    Structure Sing12
        <VBFixedArray(11)> Dim r() As Single
        Public Sub Initialize()
            ReDim r(11)
        End Sub
    End Structure
    Structure Str2
        <VBFixedString(2), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=2)> Public St As String
    End Structure
    Structure Str4
        <VBFixedString(4), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=4)> Public St As String
    End Structure
    '    Structure StrP4
    ' 'UPGRADE_ISSUE: Tipo di dichiarazione non supportato: Matrici di stringhe di lunghezza fissa. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="934BD4FF-1FF9-47BD-888F-D411E47E78FA"'
    '		Dim St(4) As String*4
    '    End Structure
    Structure Str6
        <VBFixedString(6), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=6)> Public St As String
    End Structure
    ' Structure ListIt
    ' 'UPGRADE_ISSUE: Tipo di dichiarazione non supportato: Matrici di stringhe di lunghezza fissa. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="934BD4FF-1FF9-47BD-888F-D411E47E78FA"'
    '		Dim St(6) As String*20
    '    End Structure
    Structure Str10
        <VBFixedString(10), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=10)> Public St As String
    End Structure
    Structure Str12
        <VBFixedString(12), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=12)> Public St As String
    End Structure
    Structure Str20
        <VBFixedString(20), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=20)> Public St As String
    End Structure
    Structure Str40
        <VBFixedString(40), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=40)> Public St As String
    End Structure
    '    Structure Str50
    ' <VBFixedString(50), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=50)> Public St() As Char
    ' End Structure
    ' Structure Str512
    ' 'UPGRADE_WARNING: La dimensione della stringa di lunghezza fissa deve essere contenuta nel buffer. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
    ' <VBFixedString(512), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=512)> Public St() As Char
    ' End Structure
    'Structure typPutGen
    ' Dim St1 As Str20
    ' Dim St2 As Str20
    ' Dim St3 As Str20
    ' Dim St4 As Str12
    ' Dim St5 As Str2
    ' Dim St6 As Str2
    ' End Structure
    ' Structure typLstItm
    ' <VBFixedArray(99)> Dim Buffer() As Str20''

    'UPGRADE_TODO: "Initialize" deve essere chiamato per inizializzare istanze di questa struttura. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="B4BFF9E0-8631-45CF-910E-62AB3970F27B"'
    'Public Sub Initialize()
    ' 'UPGRADE_WARNING: Il limite inferiore della matrice Buffer è stato cambiato da 1 a 0. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
    '     ReDim Buffer(99)
    ' End Sub
    ' End Structure
    'Structure typRiscri
    ' <VBFixedArray(40)> Dim Rispv() As Str40

    'UPGRADE_TODO: "Initialize" deve essere chiamato per inizializzare istanze di questa struttura. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="B4BFF9E0-8631-45CF-910E-62AB3970F27B"'
    'Public Sub Initialize()
    ' 'UPGRADE_WARNING: Il limite inferiore della matrice Rispv è stato cambiato da 1 a 0. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
    '     ReDim Rispv(40)
    ' End Sub
    ' End Structure
    ' Structure typDatiFun
    ' <VBFixedArray(88)> Dim Buffer() As Str50

    'UPGRADE_TODO: "Initialize" deve essere chiamato per inizializzare istanze di questa struttura. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="B4BFF9E0-8631-45CF-910E-62AB3970F27B"'
    'Public Sub Initialize()
    'UPGRADE_WARNING: Il limite inferiore della matrice Buffer è stato cambiato da 1 a 0. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
    '     ReDim Buffer(88)
    ' End Sub
    ' End Structure
    ' Structure Alternative 'in htrifin era 1 to 6
    ' <VBFixedArray(5)> Dim Ialt() As Short

    'UPGRADE_TODO: "Initialize" deve essere chiamato per inizializzare istanze di questa struttura. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="B4BFF9E0-8631-45CF-910E-62AB3970F27B"'
    'Public Sub Initialize()
    'UPGRADE_WARNING: Il limite inferiore della matrice Ialt è stato cambiato da 1 a 0. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
    '     ReDim Ialt(5)
    ' End Sub
    ' End Structure
    'Structure typListaMon 'in htrifin era 1 to 6
    '    <VBFixedArray(6)> Dim Ialt() As Short

    'UPGRADE_TODO: "Initialize" deve essere chiamato per inizializzare istanze di questa struttura. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="B4BFF9E0-8631-45CF-910E-62AB3970F27B"'
    'Public Sub Initialize()
    'UPGRADE_WARNING: Il limite inferiore della matrice Ialt è stato cambiato da 1 a 0. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
    '     ReDim Ialt(6)
    'End Sub
    'End Structure
    'Structure ZoneCond
    '<VBFixedArray(12)> Dim Ialt() As Short

    'UPGRADE_TODO: "Initialize" deve essere chiamato per inizializzare istanze di questa struttura. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="B4BFF9E0-8631-45CF-910E-62AB3970F27B"'
    'Public Sub Initialize()
    'UPGRADE_WARNING: Il limite inferiore della matrice Ialt è stato cambiato da 1 a 0. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
    '    ReDim Ialt(12)
    'End Sub
    'End Structure
    'Structure Real1
    'Dim num As Single
    'End Structure
    'Structure Real8
    'Dim Duty As Single
    'Dim Tin As Single
    'Dim TOut As Single
    'Dim LHC As Single
    'Dim VHC As Single
    'Dim NC As Single
    'Dim Steam As Single
    'Dim Water As Single
    'End Structure
    'Structure CondCurva
    'UPGRADE_WARNING: La dimensione della stringa di lunghezza fissa deve essere contenuta nel buffer. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
    ' <VBFixedString(1), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=1)> Public Tipo() As Char
    'UPGRADE_WARNING: La dimensione della stringa di lunghezza fissa deve essere contenuta nel buffer. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
    '<VBFixedString(1), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=1)> Public PadS() As Char
    'Dim Npun As Short
    'Dim Temp As Single '1
    'Dim Pres As Single '2
    'Dim Xgas As Single '3
    'Dim Entl As Single '4
    'Dim Hliq As Single '5
    'Dim Hgas As Single '6
    'Dim Cgas As Single '7
    'Dim Visg As Single '8
    'Dim Visl As Single '9
    'Dim Cong As Single '10
    'Dim Conl As Single '11
    'Dim Cfac As Single '12
    'Dim Cliq As Single '13
    'Dim DenV As Single '14
    'Dim Sgra As Single '15
    'Dim MolT As Single '16
    'Dim MolL As Single '17
    'Dim MolG As Single '18
    'Dim XAcq As Single
    'Dim HAcq As Single
    '<VBFixedArray(10)> Dim Pad() As Single

    'UPGRADE_TODO: "Initialize" deve essere chiamato per inizializzare istanze di questa struttura. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="B4BFF9E0-8631-45CF-910E-62AB3970F27B"'
    'Public Sub Initialize()
    'UPGRADE_WARNING: Il limite inferiore della matrice Pad è stato cambiato da 1 a 0. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
    '    ReDim Pad(10)
    'End Sub
    'End Structure
    'Structure TubeData
    ' Dim bwg As Str2
    ' Dim TOL As Str2
    ' Dim SP As Single
    ' Dim Diam As Single
    ' Dim Dial As Single
    ' Dim PAS As Single
    ' 'UPGRADE_WARNING: La dimensione della stringa di lunghezza fissa deve essere contenuta nel buffer. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
    '  <VBFixedString(2), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=2)> Public TIPAL() As Char
    '  Dim FinInch As Single
    '  Dim SpAl As Single
    '  End Structure
    '  Structure NumR4
    ' <VBFixedArray(4)> Dim A() As Single

    'UPGRADE_TODO: "Initialize" deve essere chiamato per inizializzare istanze di questa struttura. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="B4BFF9E0-8631-45CF-910E-62AB3970F27B"'
    'Public Sub Initialize()
    'UPGRADE_WARNING: Il limite inferiore della matrice A è stato cambiato da 1 a 0. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
    '     ReDim A(4)
    ' End Sub
    ' End Structure
    ' Structure tipoBuf
    ' <VBFixedArray(13, 4)> Dim iC(,) As Short
    ' <VBFixedArray(7)> Dim LungStx() As Short
    ' Dim Itemn As Str20
    ' Dim Itemv As Str20
    ' Dim Domanda As Str50
    ' Dim WorkS As Str40
    ' Dim BaseArch As Str40
    'UPGRADE_WARNING: È possibile che si debba inizializzare le matrici nella struttura Ialta prima di poterle utilizzare. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
    ' Dim Ialta As Alternative
    ' Dim NTUB As Short
    ' <VBFixedArray(4)> Dim Tub() As Single
    ' Dim Ndial As Short
    ' <VBFixedArray(7)> Dim Dial() As Single
    ' <VBFixedArray(4, 4)> Dim iDial(,) As Short
    ' <VBFixedArray(4)> Dim TipoFin() As Str2
    ' <VBFixedArray(6)> Dim FinInch() As Single
    ' <VBFixedArray(4)> Dim TubeTk() As TubeData
    ' Dim Npas As Short
    ' <VBFixedArray(10)> Dim PAS() As Single
    ' 'UPGRADE_WARNING: È possibile che si debba inizializzare le matrici nella struttura AB prima di poterle utilizzare. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
    ' Dim AB As NumR4
    ' 'UPGRADE_WARNING: È possibile che si debba inizializzare le matrici nella struttura SURFUS prima di poterle utilizzare. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
    ' Dim SURFUS As Sing12
    ' 'UPGRADE_WARNING: È possibile che si debba inizializzare le matrici nella struttura SURFRQ prima di poterle utilizzare. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
    ' Dim SURFRQ As Sing12
    ' Dim Al As Str2
    ' 'UPGRADE_WARNING: La dimensione della stringa di lunghezza fissa deve essere contenuta nel buffer. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
    ' <VBFixedString(32), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=32)> Public Rig() As Char
    ' Dim RDUT As Real8
    ' 'UPGRADE_WARNING: È possibile che si debba inizializzare le matrici nella struttura Curva prima di poterle utilizzare. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
    ' Dim Curva As CondCurva
    'UPGRADE_WARNING: È possibile che si debba inizializzare le matrici nella struttura Curva0 prima di poterle utilizzare. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
    ' Dim Curva0 As CondCurva

    'UPGRADE_TODO: "Initialize" deve essere chiamato per inizializzare istanze di questa struttura. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="B4BFF9E0-8631-45CF-910E-62AB3970F27B"'
    'Public Sub Initialize()
    '    ReDim iC(13, 4)
    '    ReDim LungStx(7)
    '    Ialta.Initialize()
    'UPGRADE_WARNING: Il limite inferiore della matrice Tub è stato cambiato da 1 a 0. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
    '    ReDim Tub(4)
    'UPGRADE_WARNING: Il limite inferiore della matrice Dial è stato cambiato da 1 a 0. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
    '    ReDim Dial(7)
    'UPGRADE_WARNING: Il limite inferiore della matrice iDial è stato cambiato da 1,1 a 0,0. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
    '   ReDim iDial(4, 4)
    'UPGRADE_WARNING: Il limite inferiore della matrice TipoFin è stato cambiato da 1 a 0. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
    '  ReDim TipoFin(4)
    'UPGRADE_WARNING: Il limite inferiore della matrice FinInch è stato cambiato da 1 a 0. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
    'ReDim FinInch(6)
    ' ReDim TubeTk(4)
    'ReDim PAS(10)
    'AB.Initialize()
    'SURFUS.Initialize()
    'SURFRQ.Initialize()
    'Curva.Initialize()
    'Curva0.Initialize()
    'End Sub
    'End Structure
End Module