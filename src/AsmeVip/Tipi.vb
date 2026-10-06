Option Strict Off
Option Explicit On
Module modTipi
    Structure ProgDes
        <VBFixedString(8), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst:=8)> Public ProgName As String
        <VBFixedString(12), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst:=12)> Public ProgVers As String
        <VBFixedString(8), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst:=8)> Public VersDate As String
        <VBFixedString(35), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst:=35)> Public ProgDesc As String
    End Structure
    Structure prezzi
        Dim Indmat As Short
        <VBFixedArray(19)> Dim prezzo() As Integer 'vedi Classe1(0)

        'UPGRADE_TODO: "Initialize" deve essere chiamato per inizializzare istanze di questa struttura. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1026"'
        Public Sub Initialize()
            'UPGRADE_WARNING: Il limite inferiore della matrice prezzo è stato cambiato da 1 a 0. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1033"'
            ReDim prezzo(19)
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

        'UPGRADE_TODO: "Initialize" deve essere chiamato per inizializzare istanze di questa struttura. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1026"'
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

        'UPGRADE_TODO: "Initialize" deve essere chiamato per inizializzare istanze di questa struttura. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1026"'
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
        <VBFixedString(2), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst:=2)> Public Itip As String
        <VBFixedString(2), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst:=2)> Public narc As String
        Dim rarc As Short
        <VBFixedString(34), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst:=34)> Public Desc As String
    End Structure
    Structure Real15
        'FIXIT: Le matrici con limiti inferiori diversi da zero non sono supportate in Visual Basic .NET     FixIT90210ae-R9815-H1984
        <VBFixedArray(15)> Dim R() As Single

        'UPGRADE_TODO: "Initialize" deve essere chiamato per inizializzare istanze di questa struttura. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1026"'
        Public Sub Initialize()
            'UPGRADE_WARNING: Il limite inferiore della matrice R è stato cambiato da 1 a 0. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1033"'
            ReDim R(15)
        End Sub
    End Structure
End Module