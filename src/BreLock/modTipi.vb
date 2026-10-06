Option Strict Off
Option Explicit On
<Serializable()> Public Class MaterialF
    Public Mat As String
    Public S As Single
    Public S0 As Single
    Public SY As Single
    Public SY0 As Single
    Public E As Single
    Public E0 As Single
    Public TempDes As Single
    Public Alfa As Single
    Public Classe As Short
    Public IndMat As Short
    Public Autom(7) As Boolean
End Class
<Serializable()> Public Class Filettatura
    Public Passo As Single
    Public Altezza As Single
    Public RootThk As Single
    Public GiocoDiam As Single
    Public DMaxAn As Single
    Public DMaxCas As Single
    Public Dmed As Single
    Public DMinCas As Single
    Public DNocAn As Single
    Public TollDiam As Single
    Public Precision As Integer
    Public Braccio As Integer
    Public Spoglia As Single
End Class
Module modTipi
    '	Structure TuttiDati
    '    Public Sub Initialize()
    '    ReDim Paddin1(46)
    '   ReDim Mater(16)
    '  Filetto.Initialize()
    ' ReDim Padding(101)
    'End Sub
    'End Structure
    Structure St40
        'UPGRADE_WARNING: La dimensione della stringa di lunghezza fissa deve essere contenuta nel buffer. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        'UPGRADE_NOTE: Str è stato aggiornato a Str_Renamed. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
        <VBFixedString(60), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=60)> Public Str_Renamed() As Char
    End Structure
End Module