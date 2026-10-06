Option Strict Off
Option Explicit On
Module modTipi
    Structure grezzi
        Dim IndRec As Short 'indirizzo in APR
        Public APR As String 'Distinta
        Dim IndFile As Short
        Dim Indmat As Short 'indice del materiale
        Dim NPezzi As Short
        Dim Variab() As Single 'variabili essenziali numeriche
        Dim Vartxt() As String 'variabili essenziali alfabetiche
        Dim Dimens() As Single
        Public Sub Initialize()
            ReDim Vartxt(5)
            ReDim Variab(3)
            ReDim Dimens(4)
        End Sub
    End Structure '6+20+12+12=54
    Structure prezzi
        Dim Indmat As Short
        Dim prezzo() As Integer 'vedi Classe1(0)''
        Public Sub Initialize()
            ReDim prezzo(19)
        End Sub
    End Structure
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
    Structure posizn
        Dim SuChi As Short 'Ind del Componente sul quale
        Public Quota As String 'Quota lungo l'asse del quale
        Public Anomal As String 'Anomalia
        Public Raggio As String '
        Public DirDiritta As String 'Direz nuovo asse
        Public DirTraversa As String
        Public NearFar As String 'Nuovo part.attaccato su N F
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
        Public Denom As String 'V
        Public MATE As String 'V
        Public DIME As String 'V
        Public Note As String 'V
        Public MF As String 'V
        '-----------------------------------------------------------------------
        Dim ForoSecondario As Short
        Dim Cody As Short
        Dim ForoTerziario As Short
        Dim PSP As Short
         Dim Dati() As Single
        Public PipeBuf As String
        Public PipeSch As String
        Public PipeDN As String
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
        Public Denom As String 'V
        Public MATE As String 'V
        Public DIME As String 'V
        Public Note As String 'V
        Public MF As String 'V
        '-----------------------------------------------------------------------
        Dim ForoSecondario As Short
        Dim Npunti As Short
        Dim ForoTerziario As Short
        Dim PSP As Short
        Dim Vertici() As Vec2
        Dim Centri() As Vec2
        Dim Raggi() As Single
        Dim Dati() As Single
        Dim Livello As Short
        Dim intPad As Short
        Public Sub Initialize()
            ReDim Vertici(12)
            ReDim Centri(12)
            ReDim Raggi(12)
            ReDim Dati(3)
        End Sub
    End Structure
    Structure spicchio
        Dim Origin As Vec2
        Dim Direct As Vec2
        Dim RG As Single
        Dim RP As Single
        Dim Alfa As Single
    End Structure
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
 As Vec2
        Dim Lung As Single
        Dim LARG As Single
        Public Sub Initialize()
            ReDim Corners(4)
        End Sub
    End Structure
    Structure IndiceG 'fornisce la sequenza all'interno di mat/spess
        Dim IndinGre() As Short
        Dim Num As Short
        Dim Indmat As Short
        Dim Classe As Short
        Dim SP As Single
        Public Sub Initialize()
            ReDim IndinGre(100)
        End Sub
    End Structure 'LungILM=102+10=112
    Structure IndiceL 'fornisce la sequenza all'interno del formato
        Dim IndinGre() As Short
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
    Structure rrec
        Dim Iniz As Short
        Dim luni As Short
        Public Itip As String
        Public narc As String
        Dim rarc As Short
        Public Desc As String
    End Structure
    Structure Real15
        Dim R() As Single
        Public Sub Initialize()
            ReDim R(15)
        End Sub
    End Structure
End Module