Option Strict Off
Option Explicit On
Imports System.Runtime.InteropServices
Module typBuf
    Structure Dispos
        <VBFixedArray(30, 100)> Dim Nite(,) As Short
        <VBFixedString(20), MarshalAs(UnmanagedType.ByValArray, SizeConst:=20)> Dim BayNome() As String
        <VBFixedArray(100)> Dim jcont() As Short
        Dim NumIt As Short
        <VBFixedString(1798), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=1798)> Dim Pad As String
        Public Sub Initialize()
            ReDim Nite(30, 100)
            ReDim jcont(100)
        End Sub
    End Structure
    ' Structure Sing12
    ' <VBFixedArray(12)> Dim r() As Single
    ' Public Sub Initialize()
    '     ReDim r(12)
    ' End Sub
    'End Structure
    'Structure Str2
    ' <VBFixedString(2), MarshalAs(UnmanagedType.ByValArray, SizeConst:=2)> Public St() As Char
    ' End Structure
    'Structure Str4
    ' <VBFixedString(4), MarshalAs(UnmanagedType.ByValArray, SizeConst:=4)> Public St() As Char
    ' End Structure
    'Structure StrP4
    ' Dim St() As String
    ' Public Sub Initialize()
    '     ReDim St(4)
    ' End Sub
    'End Structure
    'Structure Str6
    ' <VBFixedString(6), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=6)> Public St As String
    ' End Structure
    Structure ListIt
        Dim St() As String '*20
        Public Sub Initialize()
            ReDim St(6)
        End Sub
    End Structure
    Structure Str10
        <VBFixedString(10), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=10)> Public St() As Char
    End Structure
    Structure Str12
        'UPGRADE_WARNING: La dimensione della stringa di lunghezza fissa deve essere contenuta nel buffer. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(12), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=12)> Public St() As Char
    End Structure
    'Structure Str20
    ' <VBFixedString(20), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=20)> Public St As String
    'End Structure
    Structure Str40
        'UPGRADE_WARNING: La dimensione della stringa di lunghezza fissa deve essere contenuta nel buffer. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(40), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=40)> Public St() As Char
    End Structure
    Structure Str50
        'UPGRADE_WARNING: La dimensione della stringa di lunghezza fissa deve essere contenuta nel buffer. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(50), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=50)> Public St() As Char
    End Structure
    Structure Str512
        'UPGRADE_WARNING: La dimensione della stringa di lunghezza fissa deve essere contenuta nel buffer. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(512), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=512)> Public St() As Char
    End Structure
    Structure typRiscri
        <VBFixedArray(40)> Dim Rispv() As Str40

        'UPGRADE_TODO: "Initialize" deve essere chiamato per inizializzare istanze di questa struttura. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="B4BFF9E0-8631-45CF-910E-62AB3970F27B"'
        Public Sub Initialize()
            'UPGRADE_WARNING: Il limite inferiore della matrice Rispv è stato cambiato da 1 a 0. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
            ReDim Rispv(40)
        End Sub
    End Structure
    Structure typDatiFun
        <VBFixedArray(88)> Dim Buffer() As Str50

        'UPGRADE_TODO: "Initialize" deve essere chiamato per inizializzare istanze di questa struttura. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="B4BFF9E0-8631-45CF-910E-62AB3970F27B"'
        Public Sub Initialize()
            'UPGRADE_WARNING: Il limite inferiore della matrice Buffer è stato cambiato da 1 a 0. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
            ReDim Buffer(88)
        End Sub
    End Structure
    '    Structure Alternative 'in htrifin era 1 to 6
    ' <VBFixedArray(5)> Dim Ialt() As Short
    ' Public Sub Initialize()
    '     ReDim Ialt(5)
    ' End Sub
    ' End Structure
    Structure typListaMon 'in htrifin era 1 to 6
        <VBFixedArray(6)> Dim Ialt() As Short

        'UPGRADE_TODO: "Initialize" deve essere chiamato per inizializzare istanze di questa struttura. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="B4BFF9E0-8631-45CF-910E-62AB3970F27B"'
        Public Sub Initialize()
            'UPGRADE_WARNING: Il limite inferiore della matrice Ialt è stato cambiato da 1 a 0. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
            ReDim Ialt(6)
        End Sub
    End Structure
    Structure ZoneCond
        <VBFixedArray(12)> Dim Ialt() As Short

        'UPGRADE_TODO: "Initialize" deve essere chiamato per inizializzare istanze di questa struttura. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="B4BFF9E0-8631-45CF-910E-62AB3970F27B"'
        Public Sub Initialize()
            'UPGRADE_WARNING: Il limite inferiore della matrice Ialt è stato cambiato da 1 a 0. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
            ReDim Ialt(12)
        End Sub
    End Structure
    Structure Real1
        Dim num As Single
    End Structure
    Structure Real8
        Dim Duty As Single
        Dim Tin As Single
        Dim TOut As Single
        Dim LHC As Single
        Dim VHC As Single
        Dim NC As Single
        Dim Steam As Single
        Dim Water As Single
    End Structure
    Structure CondCurva
        <VBFixedString(1), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=1)> Public Tipo() As Char
        <VBFixedString(1), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=1)> Public PadS() As Char
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
    Structure TubeData
        Dim bwg As String
        Dim TOL As String
        Dim SP As Single
        Dim Diam As Single
        Dim Dial As Single
        Dim PAS As Single
        <VBFixedString(2), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=2)> Public TIPAL() As Char
        Dim FinInch As Single
        Dim SpAl As Single
    End Structure
    'Structure NumR4
    '<VBFixedArray(4)> Dim A() As Single
    'Public Sub Initialize()
    '     ReDim A(4)
    'End Sub
    'End Structure
    '    Structure tipoBuf
    ' '  <VBFixedArray(60), MarshalAs(UnmanagedType.ByValArray, SizeConst:=61)> Dim iC() As Short
    ' ' <VBFixedArray(7), MarshalAs(UnmanagedType.ByValArray, SizeConst:=8)> Dim LungStx() As Short
    ' Dim Itemn As Str20
    ' Dim Itemv As Str20
    ' Dim Domanda As Str50
    ' Dim Ialta As Alternative
    ' Dim NTUB As Short
    ' <VBFixedArray(4), MarshalAs(UnmanagedType.ByValArray, SizeConst:=5)> Dim Tub() As Single
    ' <VBFixedArray(4), MarshalAs(UnmanagedType.ByValArray, SizeConst:=5)> Dim TubeTk() As TubeData
    ' Dim AB As NumR4
    ' Dim SURFUS As Sing12
    ' Dim SURFRQ As Sing12
    ' Dim Al As Str2
    ' <VBFixedString(32), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=32)> Public Rig As String
    ' Dim RDUT As Real8
    ' Dim Curva As CondCurva
    ' Dim Curva0 As CondCurva
    ' Public Sub Initialize()
    '     Ialta.Initialize()
    '     ReDim Tub(4)
    '     AB.Initialize()
    '     SURFUS.Initialize()
    '     SURFRQ.Initialize()
    '     Curva.Initialize()
    '     Curva0.Initialize()
    ' End Sub
    ' End Structure
End Module