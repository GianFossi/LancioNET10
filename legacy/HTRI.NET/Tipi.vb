Option Strict Off
Option Explicit On
Imports System.Runtime.InteropServices
Module modTipi
    Structure typUtente
        'UPGRADE_WARNING: La dimensione della stringa di lunghezza fissa deve essere contenuta nel buffer. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(20), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=20)> Public Nome() As Char
        'UPGRADE_WARNING: La dimensione della stringa di lunghezza fissa deve essere contenuta nel buffer. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(10), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=10)> Public PassWord() As Char
    End Structure
    'Structure jobs
    ' Dim Njobs As Short
    ' 'UPGRADE_ISSUE: Tipo di dichiarazione non supportato: Matrici di stringhe di lunghezza fissa. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="934BD4FF-1FF9-47BD-888F-D411E47E78FA"'
    '		Dim Arch(99) As String*6
    '	End Structure
    Structure ProgDes
        'UPGRADE_WARNING: La dimensione della stringa di lunghezza fissa deve essere contenuta nel buffer. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(8), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=8)> Public ProgName() As Char
        'UPGRADE_WARNING: La dimensione della stringa di lunghezza fissa deve essere contenuta nel buffer. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(12), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=12)> Public ProgVers() As Char
        'UPGRADE_WARNING: La dimensione della stringa di lunghezza fissa deve essere contenuta nel buffer. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(8), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=8)> Public VersDate() As Char
        'UPGRADE_WARNING: La dimensione della stringa di lunghezza fissa deve essere contenuta nel buffer. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(35), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=35)> Public ProgDesc() As Char
    End Structure
    'Structure grezzi
    'Dim IndRec As Short 'indirizzo in APR
    'UPGRADE_WARNING: La dimensione della stringa di lunghezza fissa deve essere contenuta nel buffer. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
    '<VBFixedString(10), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=10)> Public APR() As Char 'Distinta
    'Dim IndFile As Short
    'Dim Indmat As Short 'indice del materiale
    'Dim NPezzi As Short
    'FIXIT: Le matrici con limiti inferiori diversi da zero non sono supportate in Visual Basic .NET     FixIT90210ae-R9815-H1984
    '<VBFixedArray(5)> Dim Variab() As Single 'variabili essenziali numeriche
    'UPGRADE_ISSUE: Tipo di dichiarazione non supportato: Matrici di stringhe di lunghezza fissa. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="934BD4FF-1FF9-47BD-888F-D411E47E78FA"'
    '	Dim Vartxt(3) As String*4 'variabili essenziali alfabetiche
    'FIXIT: Le matrici con limiti inferiori diversi da zero non sono supportate in Visual Basic .NET     FixIT90210ae-R9815-H1984
    '  <VBFixedArray(4)> Dim Dimens() As Single

    'UPGRADE_TODO: "Initialize" deve essere chiamato per inizializzare istanze di questa struttura. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="B4BFF9E0-8631-45CF-910E-62AB3970F27B"'
    ' Public Sub Initialize()
    'UPGRADE_WARNING: Il limite inferiore della matrice Variab è stato cambiato da 1 a 0. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
    '    ReDim Variab(5)
    'UPGRADE_WARNING: Il limite inferiore della matrice Dimens è stato cambiato da 1 a 0. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
    '   ReDim Dimens(4)
    'End Sub
    'End Structure '6+20+12+12=54
    'Structure prezzi
    'Dim Indmat As Short
    '<VBFixedArray(19)> Dim prezzo() As Integer 'vedi Classe1(0)

    'UPGRADE_TODO: "Initialize" deve essere chiamato per inizializzare istanze di questa struttura. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="B4BFF9E0-8631-45CF-910E-62AB3970F27B"'
    'Public Sub Initialize()
    'UPGRADE_WARNING: Il limite inferiore della matrice prezzo è stato cambiato da 1 a 0. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
    '    ReDim prezzo(19)
    'End Sub
    ' End Structure
    Structure Vec2
        Dim X As Single
        Dim y As Single
    End Structure
    Structure Vec3
        Dim X As Single
        Dim y As Single
        Dim Z As Single
    End Structure
    Structure Linea2 'gruppo di due punti in 2 dimensioni
        Dim P0 As Vec2
        Dim p1 As Vec2
    End Structure
    '  Structure Identifv
    ' <VBFixedString(8), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=8)> Public Arch As String 'sottocommessa
    ' <VBFixedString(4), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=4)> Public job As String
    ' <VBFixedString(20), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=20)> Public Prev As String 'commessa
    ' <VBFixedString(20), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=20)> Public Item As String 'titolo
    ' <VBFixedString(20), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=20)> Public Clie As String
    ' <VBFixedString(20), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=20)> Public Comp As String 'compilatore                         88
    '<VBFixedArray(97)> Dim Ind() As Short 'indice in APR del record corrente   22
    'Dim NBank As Short
    'Dim IndG As Short
    'Dim NumTot As Short 'Numero totale assiemi
    '<VBFixedArray(99)> Dim pag() As Short 'indice pagina                       22
    'Dim NumAs As Short 'numero assieme attuale
    '<VBFixedString(297), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=297)> Dim File As String '*3 nome file APR                       35
    '<VBFixedString(19800), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=19800)> Private prAssieme As String '*20 denominazioni                    220
    '<VBFixedArray(99)> Dim Qta() As Short ' 387+22
    '<VBFixedString(1), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=1)> Public Asse As String 'H o V                               '  1
    'Dim Baric As Vec3 ' 12
    'Dim peso As Single
    'Dim CalcBaric As Short '  6
    'Dim LungM As Short 'Lunghezza max formati lamiera
    'Dim LargM As Short 'Larghezza max formati lamiera          '  4
    'Public Property Assieme(ByVal i As Integer) As String
    '    Get
    '        Return prAssieme.Substring((i - 1) * 20, 20)
    '    End Get
    '    Set(ByVal value As String)
    '        prAssieme = prAssieme.Substring(0, (i - 1) * 20) & value.PadRight(20) & prAssieme.Substring(i * 20)
    '    End Set
    'End Property
    'Public Sub Initialize()
    '    ReDim Ind(97)
    '    ReDim pag(99)
    '    ReDim Qta(99)
    'End Sub
    'End Structure 'LungTEM=450
    'Structure Identif
    ' <VBFixedString(8), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=8)> Public Arch As String 'sottocommessa
    ' <VBFixedString(4), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=4)> Public job As String
    ' <VBFixedString(20), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=20)> Public Prev As String 'commessa
    ' <VBFixedString(20), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=20)> Public Item As String 'titolo
    ' <VBFixedString(20), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=20)> Public Clie As String
    ' <VBFixedString(20), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=20)> Public Comp As String 'compilatore                         88
    ' <VBFixedArray(97)> Dim Ind() As Short 'indice in APR del record corrente   22
    ' Dim NBank As Short
    ' Dim IndG As Short
    ' Dim NumTot As Short 'Numero totale assiemi
    ' <VBFixedArray(99)> Dim pag() As Short 'indice pagina                       22
    ' Dim NumAs As Short 'numero assieme attuale
    ' <VBFixedString(297), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=297)> Dim File As String '*3 nome file APR                       35
    ' <VBFixedString(19800), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=19800)> Private prAssieme As String '*20 denominazioni                    220
    ' <VBFixedArray(99)> Dim Qta() As Short ' 387+22
    ' <VBFixedString(1), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=1)> Public Asse As String 'H o V                               '  1
    ' Dim Baric As Vec3 ' 12
    ' Dim peso As Single
    ' Dim CalcBaric As Short '  6
    ' Dim LungM As Short 'Lunghezza max formati lamiera
    ' Dim LargM As Short 'Larghezza max formati lamiera          '  4
    ' Dim NumeroLati As Short
    ' <VBFixedString(100), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=100)> Dim Pad As String
    ' Public Property Assieme(ByVal i As Integer) As String
    '     Get
    '         Return prAssieme.Substring((i - 1) * 20, 20)
    '     End Get
    '     Set(ByVal value As String)
    '         prAssieme = prAssieme.Substring(0, (i - 1) * 20) & value.PadRight(20) & prAssieme.Substring(i * 20)
    '     End Set
    ' End Property
    ' Public Sub Initialize()
    '     ReDim Ind(97)
    '     ReDim pag(99)
    '     ReDim Qta(99)
    ' End Sub
    ' End Structure 'LungTEM=450
    Structure posizv
        Dim SuChi As Short 'Ind del Componente sul quale
        'UPGRADE_WARNING: La dimensione della stringa di lunghezza fissa deve essere contenuta nel buffer. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(10), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=10)> Public Quota() As Char 'Quota lungo l'asse del quale
        'UPGRADE_WARNING: La dimensione della stringa di lunghezza fissa deve essere contenuta nel buffer. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(10), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=10)> Public Anomal() As Char 'Anomalia
        'UPGRADE_WARNING: La dimensione della stringa di lunghezza fissa deve essere contenuta nel buffer. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(10), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=10)> Public Raggio() As Char '
        'UPGRADE_WARNING: La dimensione della stringa di lunghezza fissa deve essere contenuta nel buffer. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(10), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=10)> Public DirDiritta() As Char 'Direz nuovo asse
        'UPGRADE_WARNING: La dimensione della stringa di lunghezza fissa deve essere contenuta nel buffer. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(10), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=10)> Public DirTraversa() As Char
        'UPGRADE_WARNING: La dimensione della stringa di lunghezza fissa deve essere contenuta nel buffer. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(1), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=1)> Public NearFar() As Char 'Nuovo part.attaccato su N F
        Dim QuotaR As Single
        Dim AnomalR As Single
        Dim RaggioR As Single
        Dim Origine As Vec3
        Dim CosOrigine As Vec3
        Dim CosDiritta As Vec3
        Dim CosTraversa As Vec3
        Dim CosTerza As Vec3
        Dim BaricAss As Vec3
        Dim BaricRel As Vec3
    End Structure 'Lungh=
    Structure posizn
        Dim SuChi As Short 'Ind del Componente sul quale
        'UPGRADE_WARNING: La dimensione della stringa di lunghezza fissa deve essere contenuta nel buffer. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(12), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=12)> Public Quota() As Char 'Quota lungo l'asse del quale
        'UPGRADE_WARNING: La dimensione della stringa di lunghezza fissa deve essere contenuta nel buffer. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(12), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=12)> Public Anomal() As Char 'Anomalia
        'UPGRADE_WARNING: La dimensione della stringa di lunghezza fissa deve essere contenuta nel buffer. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(12), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=12)> Public Raggio() As Char '
        'UPGRADE_WARNING: La dimensione della stringa di lunghezza fissa deve essere contenuta nel buffer. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(12), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=12)> Public DirDiritta() As Char 'Direz nuovo asse
        'UPGRADE_WARNING: La dimensione della stringa di lunghezza fissa deve essere contenuta nel buffer. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(12), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=12)> Public DirTraversa() As Char
        'UPGRADE_WARNING: La dimensione della stringa di lunghezza fissa deve essere contenuta nel buffer. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(4), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=4)> Public NearFar() As Char 'Nuovo part.attaccato su N F
        Dim QuotaR As Single
        Dim AnomalR As Single
        Dim RaggioR As Single
        Dim Origine As Vec3
        Dim CosOrigine As Vec3
        Dim CosDiritta As Vec3
        Dim CosTraversa As Vec3
        Dim CosTerza As Vec3
        Dim BaricAss As Vec3
        Dim BaricRel As Vec3
    End Structure 'Lungh=162
    Structure RecAPR
        Dim posspa As posizv
        Dim PosDis As Short 'V
        Dim Ind As Short
        'UPGRADE_WARNING: La dimensione della stringa di lunghezza fissa deve essere contenuta nel buffer. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(32), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=32)> Public Denom() As Char 'V
        'UPGRADE_WARNING: La dimensione della stringa di lunghezza fissa deve essere contenuta nel buffer. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(5), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=5)> Public Qta() As Char 'V
        Dim Indmat As Short
        Dim SubClasse As Short
        'UPGRADE_WARNING: La dimensione della stringa di lunghezza fissa deve essere contenuta nel buffer. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(32), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=32)> Public MATE() As Char 'V
        'UPGRADE_WARNING: La dimensione della stringa di lunghezza fissa deve essere contenuta nel buffer. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(53), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=53)> Public DIME() As Char 'V
        'UPGRADE_WARNING: La dimensione della stringa di lunghezza fissa deve essere contenuta nel buffer. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(9), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=9)> Public PNET() As Char 'V
        'UPGRADE_WARNING: La dimensione della stringa di lunghezza fissa deve essere contenuta nel buffer. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(9), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=9)> Public PSFR() As Char 'V
        'UPGRADE_WARNING: La dimensione della stringa di lunghezza fissa deve essere contenuta nel buffer. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(9), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=9)> Public PLOR() As Char 'V
        'UPGRADE_WARNING: La dimensione della stringa di lunghezza fissa deve essere contenuta nel buffer. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(4), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=4)> Public MF() As Char 'V
        'UPGRADE_WARNING: La dimensione della stringa di lunghezza fissa deve essere contenuta nel buffer. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(8), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=8)> Public LKG() As Char 'V
        'UPGRADE_WARNING: La dimensione della stringa di lunghezza fissa deve essere contenuta nel buffer. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(13), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=13)> Public LTO() As Char 'V
        'UPGRADE_WARNING: La dimensione della stringa di lunghezza fissa deve essere contenuta nel buffer. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(32), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=32)> Public Note() As Char 'V
        Dim Tipo As Short '99: posizione fittizia
        '98: continuazione di posizione
        'negativo:legato alla precedente
        '97: foratura
        '95: poligonale
        '-----------------------------------------------------------------------
        Dim ForoSecondario As Short
        Dim Cody As Short
        Dim ForoTerziario As Short
        Dim PSP As Short
        'FIXIT: Le matrici con limiti inferiori diversi da zero non sono supportate in Visual Basic .NET     FixIT90210ae-R9815-H1984
        <VBFixedArray(11)> Dim Dati() As Single

        'UPGRADE_TODO: "Initialize" deve essere chiamato per inizializzare istanze di questa struttura. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="B4BFF9E0-8631-45CF-910E-62AB3970F27B"'
        Public Sub Initialize()
            'UPGRADE_WARNING: Il limite inferiore della matrice Dati è stato cambiato da 1 a 0. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
            ReDim Dati(11)
        End Sub
    End Structure
    Structure RecAPRn
        Dim posspa As posizn
        Dim PosDis As Short 'V
        Dim Ind As Short
        Dim Tipo As Short '99: posizione fittizia
        '98: continuazione di posizione
        'negativo:legato alla precedente
        '97: foratura
        '95: poligonale
        Dim Qta As Integer 'V
        Dim Indmat As Integer
        Dim SubClasse As Short
        Dim UltimoAppeso As Short
        Dim PNET As Single 'V
        Dim PSFR As Single 'V
        Dim PLOR As Single 'V
        Dim LKG As Single 'V
        Dim LTO As Single 'V
        'UPGRADE_WARNING: La dimensione della stringa di lunghezza fissa deve essere contenuta nel buffer. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(32), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=32)> Public Denom() As Char 'V
        'UPGRADE_WARNING: La dimensione della stringa di lunghezza fissa deve essere contenuta nel buffer. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(32), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=32)> Public MATE() As Char 'V
        'UPGRADE_WARNING: La dimensione della stringa di lunghezza fissa deve essere contenuta nel buffer. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(64), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=64)> Public DIME() As Char 'V
        'UPGRADE_WARNING: La dimensione della stringa di lunghezza fissa deve essere contenuta nel buffer. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(36), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=36)> Public Note() As Char 'V
        'UPGRADE_WARNING: La dimensione della stringa di lunghezza fissa deve essere contenuta nel buffer. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(4), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=4)> Public MF() As Char 'V
        '-----------------------------------------------------------------------
        Dim ForoSecondario As Short
        Dim Cody As Short
        Dim ForoTerziario As Short
        Dim PSP As Short
        'FIXIT: Le matrici con limiti inferiori diversi da zero non sono supportate in Visual Basic .NET     FixIT90210ae-R9815-H1984
        <VBFixedArray(52)> Dim Dati() As Single
        'UPGRADE_WARNING: La dimensione della stringa di lunghezza fissa deve essere contenuta nel buffer. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(3), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=3)> Public PipeBuf() As Char
        'UPGRADE_WARNING: La dimensione della stringa di lunghezza fissa deve essere contenuta nel buffer. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(5), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=5)> Public PipeSch() As Char
        'UPGRADE_WARNING: La dimensione della stringa di lunghezza fissa deve essere contenuta nel buffer. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(8), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=8)> Public PipeDN() As Char
        Dim prezzoID As Integer
        Dim prezzoID2 As Integer
        Dim prezzoID3 As Integer
        Dim Unit As Short 'unità 1 o 2 dei prezzi
        Dim padUnit As Short
        Dim Lato As Short
        Dim Bucante As Short
        Dim IndMat2 As Short
        Dim IndMat3 As Short
        Dim LireLETot As Single
        Dim Livello As Short
        Dim intPad As Short

        'UPGRADE_TODO: "Initialize" deve essere chiamato per inizializzare istanze di questa struttura. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="B4BFF9E0-8631-45CF-910E-62AB3970F27B"'
        Public Sub Initialize()
            'UPGRADE_WARNING: Il limite inferiore della matrice Dati è stato cambiato da 1 a 0. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
            ReDim Dati(52)
        End Sub
    End Structure
    Structure RecAPRm
        Dim posspa As posizn
        Dim PosDis As Short 'V
        Dim Ind As Short
        Dim Tipo As Short '99: posizione fittizia
        '98: continuazione di posizione
        'negativo:legato alla precedente
        '97: foratura
        '95: poligonale
        Dim Qta As Integer 'V
        Dim Indmat As Integer
        Dim SubClasse As Short
        Dim UltimoAppeso As Short
        Dim PNET As Single 'V
        Dim PSFR As Single 'V
        Dim PLOR As Single 'V
        Dim LKG As Single 'V
        Dim LTO As Single 'V
        'UPGRADE_WARNING: La dimensione della stringa di lunghezza fissa deve essere contenuta nel buffer. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(32), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=32)> Public Denom() As Char 'V
        'UPGRADE_WARNING: La dimensione della stringa di lunghezza fissa deve essere contenuta nel buffer. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(32), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=32)> Public MATE() As Char 'V
        'UPGRADE_WARNING: La dimensione della stringa di lunghezza fissa deve essere contenuta nel buffer. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(64), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=64)> Public DIME() As Char 'V
        'UPGRADE_WARNING: La dimensione della stringa di lunghezza fissa deve essere contenuta nel buffer. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(36), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=36)> Public Note() As Char 'V
        'UPGRADE_WARNING: La dimensione della stringa di lunghezza fissa deve essere contenuta nel buffer. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(4), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=4)> Public MF() As Char 'V
        '-----------------------------------------------------------------------
        Dim ForoSecondario As Short
        Dim Npunti As Short
        Dim ForoTerziario As Short
        Dim PSP As Short
        'FIXIT: Le matrici con limiti inferiori diversi da zero non sono supportate in Visual Basic .NET     FixIT90210ae-R9815-H1984
        <VBFixedArray(12)> Dim Vertici() As Vec2
        'FIXIT: Le matrici con limiti inferiori diversi da zero non sono supportate in Visual Basic .NET     FixIT90210ae-R9815-H1984
        <VBFixedArray(12)> Dim Centri() As Vec2
        'FIXIT: Le matrici con limiti inferiori diversi da zero non sono supportate in Visual Basic .NET     FixIT90210ae-R9815-H1984
        <VBFixedArray(12)> Dim Raggi() As Single
        'FIXIT: Le matrici con limiti inferiori diversi da zero non sono supportate in Visual Basic .NET     FixIT90210ae-R9815-H1984
        <VBFixedArray(3)> Dim Dati() As Single
        Dim Livello As Short
        Dim intPad As Short

        'UPGRADE_TODO: "Initialize" deve essere chiamato per inizializzare istanze di questa struttura. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="B4BFF9E0-8631-45CF-910E-62AB3970F27B"'
        Public Sub Initialize()
            'UPGRADE_WARNING: Il limite inferiore della matrice Vertici è stato cambiato da 1 a 0. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
            ReDim Vertici(12)
            'UPGRADE_WARNING: Il limite inferiore della matrice Centri è stato cambiato da 1 a 0. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
            ReDim Centri(12)
            'UPGRADE_WARNING: Il limite inferiore della matrice Raggi è stato cambiato da 1 a 0. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
            ReDim Raggi(12)
            'UPGRADE_WARNING: Il limite inferiore della matrice Dati è stato cambiato da 1 a 0. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
            ReDim Dati(3)
        End Sub
    End Structure
    'Type tiranti
    '   DN    As String * 10
    '   Diam  As String * 6  'diametro nocciolo mm
    '   Chia  As String * 5
    '   BSmin As Single
    '   Rmin  As Single      'spaziatura interna
    '   Emin  As Single      'spaziatura esterna
    '   foro  As Single
    '   Dnom  As Single      'diametro nominale mm
    'End Type
    ' Structure piping
    'UPGRADE_WARNING: La dimensione della stringa di lunghezza fissa deve essere contenuta nel buffer. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
    '<VBFixedString(8), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=8)> Public DN() As Char
    'UPGRADE_WARNING: La dimensione della stringa di lunghezza fissa deve essere contenuta nel buffer. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
    '<VBFixedString(8), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=8)> Public Diam() As Char
    'UPGRADE_ISSUE: Tipo di dichiarazione non supportato: Matrici di stringhe di lunghezza fissa. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="934BD4FF-1FF9-47BD-888F-D411E47E78FA"'
    '	Dim Sch(20) As String*3
    'UPGRADE_ISSUE: Tipo di dichiarazione non supportato: Matrici di stringhe di lunghezza fissa. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="934BD4FF-1FF9-47BD-888F-D411E47E78FA"'
    '		Dim Spess(20) As String*5
    '   End Structure '16+60+100=176
    '  Structure spicchio
    'Dim Origin As Vec2
    'Dim Direct As Vec2
    'Dim RG As Single
    'Dim RP As Single
    'Dim Alfa As Single
    'End Structure
    'Type Selle
    '   Serie As Integer     '1,2,3 piccola  media grande
    '   Tipo  As String * 3  'Semplice portante
    '   Alfa  As Integer     'Lung=16
    '   DN    As String * 5
    '   Diam  As Integer     'ID
    '   Altz  As Integer     'A
    '   Lung  As Integer     'B o E
    '   Larg  As Integer     '?
    '   Fori  As Integer     'C
    '   Set1  As Integer
    '   Set2  As Integer
    '   Set3  As Integer
    '   Spes1 As Integer
    '   Spes2 As Integer
    '   Spes3 As Integer
    '   peso  As Single       'Lung=2*11+5=40
    '   Pad As Integer
    'End Type
    Structure Rectang
        'FIXIT: Le matrici con limiti inferiori diversi da zero non sono supportate in Visual Basic .NET     FixIT90210ae-R9815-H1984
        <VBFixedArray(4)> Dim Corners() As Vec2
        Dim Lung As Single
        Dim LARG As Single

        'UPGRADE_TODO: "Initialize" deve essere chiamato per inizializzare istanze di questa struttura. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="B4BFF9E0-8631-45CF-910E-62AB3970F27B"'
        Public Sub Initialize()
            'UPGRADE_WARNING: Il limite inferiore della matrice Corners è stato cambiato da 1 a 0. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
            ReDim Corners(4)
        End Sub
    End Structure
    'Type LamSpicchi
    '   Rett As rectang
    '   Spicchi(1 To 16) As spicchio
    '   NSpicchi As Integer
    'End Type
    Structure IndiceG 'fornisce la sequenza all'interno di mat/spess
        <VBFixedArray(100)> Dim IndinGre() As Short
        Dim Num As Short
        Dim Indmat As Short
        Dim Classe As Short
        Dim SP As Single

        'UPGRADE_TODO: "Initialize" deve essere chiamato per inizializzare istanze di questa struttura. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="B4BFF9E0-8631-45CF-910E-62AB3970F27B"'
        Public Sub Initialize()
            ReDim IndinGre(100)
        End Sub
    End Structure 'LungILM=102+10=112
    Structure IndiceL 'fornisce la sequenza all'interno del formato
        <VBFixedArray(600)> Dim IndinGre() As Short
        Dim Num As Short
        Dim Iniz As Short
        Dim Indmat As Short
        Dim Classe As Short
        Dim SP As Single
        Dim LARG As Short
        Dim Lung As Short

        'UPGRADE_TODO: "Initialize" deve essere chiamato per inizializzare istanze di questa struttura. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="B4BFF9E0-8631-45CF-910E-62AB3970F27B"'
        Public Sub Initialize()
            ReDim IndinGre(600)
        End Sub
    End Structure 'LungLAM=401*2+16=818
    'Type LamQuadr
    '   TopLeft  As Vec2
    '   Botrigt  As Vec2
    'End Type                'LungQLM=8
    Structure rrec
        Dim Iniz As Short
        Dim luni As Short
        'UPGRADE_WARNING: La dimensione della stringa di lunghezza fissa deve essere contenuta nel buffer. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(2), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=2)> Public Itip() As Char
        'UPGRADE_WARNING: La dimensione della stringa di lunghezza fissa deve essere contenuta nel buffer. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(2), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=2)> Public narc() As Char
        Dim rarc As Short
        'UPGRADE_WARNING: La dimensione della stringa di lunghezza fissa deve essere contenuta nel buffer. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(34), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=34)> Public Desc() As Char
    End Structure
    Structure Real15
        'FIXIT: Le matrici con limiti inferiori diversi da zero non sono supportate in Visual Basic .NET     FixIT90210ae-R9815-H1984
        <VBFixedArray(15)> Dim R() As Single

        'UPGRADE_TODO: "Initialize" deve essere chiamato per inizializzare istanze di questa struttura. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="B4BFF9E0-8631-45CF-910E-62AB3970F27B"'
        Public Sub Initialize()
            'UPGRADE_WARNING: Il limite inferiore della matrice R è stato cambiato da 1 a 0. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
            ReDim R(15)
        End Sub
    End Structure
End Module