Option Strict Off
Option Explicit On
Module modTipi
    '	Structure jobs
    '    Dim Njobs As Short
    '   'UPGRADE_ISSUE: Tipo di dichiarazione non supportato: Matrici di stringhe di lunghezza fissa. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1051"'
    '		Dim Arch(99) As String*6
    '	End Structure
    '  Structure Identif
    '  <VBFixedString(8), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst:=8)> Public Arch As String 'sottocommessa
    '  'UPGRADE_NOTE: job è stato aggiornato a job. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1061"'
    '  <VBFixedString(4), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst:=4)> Public job As String
    '  <VBFixedString(20), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst:=20)> Public Prev As String 'commessa
    '  <VBFixedString(20), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst:=20)> Public Item As String 'titolo
    '  <VBFixedString(20), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst:=20)> Public Clie As String
    '  <VBFixedString(20), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst:=20)> Public Comp As String 'compilatore                         88
    '  <VBFixedArray(97)> Dim Ind() As Short 'indice in APR del record corrente   22
    '  Dim NBank As Short
    '  Dim IndG As Short
    '  Dim NumTot As Short 'Numero totale assiemi
    '  <VBFixedArray(99)> Dim pag() As Short 'indice pagina                       22
    '  Dim NumAs As Short 'numero assieme attuale
    '  'UPGRADE_ISSUE: Tipo di dichiarazione non supportato: Matrici di stringhe di lunghezza fissa. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1051"'
    '		Dim File(99) As String*3 'nome file APR                       35
    '    'UPGRADE_ISSUE: Tipo di dichiarazione non supportato: Matrici di stringhe di lunghezza fissa. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1051"'
    '		Dim Assieme(99) As String*20 'denominazioni                    220
    '   <VBFixedArray(99)> Dim Qta() As Short ' 387+22
    '   <VBFixedString(1), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst:=1)> Public Asse As String 'H o V                               '  1
    '   Dim Baric As Vec3 ' 12
    '   Dim peso As Single
    '   Dim CalcBaric As Short '  6
    '   Dim LungM As Short 'Lunghezza max formati lamiera
    '   Dim LargM As Short 'Larghezza max formati lamiera          '  4
    '   Dim NumeroLati As Short
    '   'UPGRADE_ISSUE: Tipo di dichiarazione non supportato: Matrici di stringhe di lunghezza fissa. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1051"'
    '		Dim Pad(100) As String*1
    '
    '   'UPGRADE_TODO: "Initialize" deve essere chiamato per inizializzare istanze di questa struttura. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1026"'
    '   Public Sub Initialize()
    '       ReDim Ind(97)
    '       ReDim pag(99)
    '       ReDim Qta(99)
    '   End Sub
    '   End Structure 'LungTEM=450
    Structure posizv
        Dim SuChi As Short 'Ind del Componente sul quale
        <VBFixedString(10), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst:=10)> Public Quota As String 'Quota lungo l'asse del quale
        <VBFixedString(10), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst:=10)> Public Anomal As String 'Anomalia
        <VBFixedString(10), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst:=10)> Public Raggio As String '
        <VBFixedString(10), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst:=10)> Public DirDiritta As String 'Direz nuovo asse
        <VBFixedString(10), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst:=10)> Public DirTraversa As String
        <VBFixedString(1), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst:=1)> Public NearFar As String 'Nuovo part.attaccato su N F
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
        <VBFixedString(12), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst:=12)> Public Quota As String 'Quota lungo l'asse del quale
        <VBFixedString(12), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst:=12)> Public Anomal As String 'Anomalia
        <VBFixedString(12), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst:=12)> Public Raggio As String '
        <VBFixedString(12), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst:=12)> Public DirDiritta As String 'Direz nuovo asse
        <VBFixedString(12), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst:=12)> Public DirTraversa As String
        <VBFixedString(4), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst:=4)> Public NearFar As String 'Nuovo part.attaccato su N F
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
        <VBFixedString(32), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst:=32)> Public Denom As String 'V
        <VBFixedString(5), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst:=5)> Public Qta As String 'V
        Dim Indmat As Short
        Dim SubClasse As Short
        <VBFixedString(32), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst:=32)> Public MATE As String 'V
        <VBFixedString(53), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst:=53)> Public DIME As String 'V
        <VBFixedString(9), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst:=9)> Public PNET As String 'V
        <VBFixedString(9), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst:=9)> Public PSFR As String 'V
        <VBFixedString(9), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst:=9)> Public PLOR As String 'V
        <VBFixedString(4), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst:=4)> Public MF As String 'V
        <VBFixedString(8), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst:=8)> Public LKG As String 'V
        <VBFixedString(13), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst:=13)> Public LTO As String 'V
        <VBFixedString(32), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst:=32)> Public Note As String 'V
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

        'UPGRADE_TODO: "Initialize" deve essere chiamato per inizializzare istanze di questa struttura. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1026"'
        Public Sub Initialize()
            'UPGRADE_WARNING: Il limite inferiore della matrice Dati è stato cambiato da 1 a 0. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1033"'
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
        <VBFixedString(32), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst:=32)> Public Denom As String 'V
        <VBFixedString(32), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst:=32)> Public MATE As String 'V
        <VBFixedString(64), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst:=64)> Public DIME As String 'V
        <VBFixedString(36), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst:=36)> Public Note As String 'V
        <VBFixedString(4), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst:=4)> Public MF As String 'V
        '-----------------------------------------------------------------------
        Dim ForoSecondario As Short
        Dim Cody As Short
        Dim ForoTerziario As Short
        Dim PSP As Short
        'FIXIT: Le matrici con limiti inferiori diversi da zero non sono supportate in Visual Basic .NET     FixIT90210ae-R9815-H1984
        <VBFixedArray(52)> Dim Dati() As Single
        <VBFixedString(3), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst:=3)> Public PipeBuf As String
        <VBFixedString(5), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst:=5)> Public PipeSch As String
        <VBFixedString(8), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst:=8)> Public PipeDN As String
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

        'UPGRADE_TODO: "Initialize" deve essere chiamato per inizializzare istanze di questa struttura. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1026"'
        Public Sub Initialize()
            'UPGRADE_WARNING: Il limite inferiore della matrice Dati è stato cambiato da 1 a 0. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1033"'
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
        <VBFixedString(32), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst:=32)> Public Denom As String 'V
        <VBFixedString(32), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst:=32)> Public MATE As String 'V
        <VBFixedString(64), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst:=64)> Public DIME As String 'V
        <VBFixedString(36), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst:=36)> Public Note As String 'V
        <VBFixedString(4), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst:=4)> Public MF As String 'V
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

        'UPGRADE_TODO: "Initialize" deve essere chiamato per inizializzare istanze di questa struttura. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1026"'
        Public Sub Initialize()
            'UPGRADE_WARNING: Il limite inferiore della matrice Vertici è stato cambiato da 1 a 0. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1033"'
            ReDim Vertici(12)
            'UPGRADE_WARNING: Il limite inferiore della matrice Centri è stato cambiato da 1 a 0. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1033"'
            ReDim Centri(12)
            'UPGRADE_WARNING: Il limite inferiore della matrice Raggi è stato cambiato da 1 a 0. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1033"'
            ReDim Raggi(12)
            'UPGRADE_WARNING: Il limite inferiore della matrice Dati è stato cambiato da 1 a 0. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1033"'
            ReDim Dati(3)
        End Sub
    End Structure
End Module