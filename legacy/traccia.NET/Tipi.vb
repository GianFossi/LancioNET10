Option Strict Off
Option Explicit On
Module modTipi
    Structure Vec2
        Dim X As Single
        Dim y As Single
    End Structure
    Structure Vec3
        Dim X As Single
        Dim y As Single
        Dim Z As Single
    End Structure
    Structure Linea2
        Dim P0 As Vec2
        Dim P1 As Vec2
    End Structure
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
        <VBFixedArray(10)> Dim Dati() As Single
        Public Sub Initialize()
            ReDim Dati(10)
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
        <VBFixedArray(51)> Dim Dati() As Single
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
        Public Sub Initialize()
            ReDim Dati(51)
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
        <VBFixedArray(11)> Dim Vertici() As Vec2
        <VBFixedArray(11)> Dim Centri() As Vec2
        <VBFixedArray(11)> Dim Raggi() As Single
        <VBFixedArray(2)> Dim Dati() As Single
        Dim Livello As Short
        Dim intPad As Short
        Public Sub Initialize()
            ReDim Vertici(11)
            ReDim Centri(11)
            ReDim Raggi(11)
            ReDim Dati(2)
        End Sub
    End Structure
    Structure spicchio
        Dim Origin As Vec2
        Dim Direct As Vec2
        Dim RG As Single
        Dim RP As Single
        Dim Alfa As Single
    End Structure
    Structure IndiceG 'fornisce la sequenza all'interno di mat/spess
        <VBFixedArray(100)> Dim IndinGre() As Short
        Dim Num As Short
        Dim Indmat As Short
        Dim Classe As Short
        Dim SP As Single
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
        Public Sub Initialize()
            ReDim IndinGre(600)
        End Sub
    End Structure 'LungLAM=401*2+16=818
End Module