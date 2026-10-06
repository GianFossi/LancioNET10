Option Strict Off
Option Explicit On
Module DATIDES4
    Structure typMateInform '38
        Dim Tipo As Short '0 mono monopl monoriv mono lin biplacc biriv bilin
        Dim Ind1 As Short '0 inenistente -1 non codificato
        Dim Ind2 As Short
        Dim Ind3 As Short
        Public Descr As String
    End Structure
    Structure typTubiInform
        Dim Numero As Short
        Dim Diam As Single
        Dim Spess As Single
        Dim BWG As Short
        Dim Lungh As Single
        Dim Pitch As Single
        Dim TipoP As Short
        Dim TipoG As Short '10-80
        Dim TipoMat As Short '1 Cu  Al/0 C.S./ 2 other
        Dim Toller As Short '0 AW 1 MW
    End Structure
    Structure typDatiDes
        Dim PressTubi As Single
        Dim TempTubi As Single
        Dim PressMant As Single
        Dim TempMant As Single
        Dim DiffPress As Short
        Dim PadDiff As Short
        Dim PHyTubi As Single
        Dim PHyMant As Single
        Dim CorrTubi As Single
        Dim CorrMant As Single
        Public FluidoTubi As String
        Public FluidoMant As String
        Public ClasseCostr As String
        Public TipoTEMA As String
        Dim UniMis As Short '1 mm/MPa/øC  2 mm/psi/øF 3 tecnico
        Dim Vacuum As Short 'VACUUM: 0=NO;1=SHELL,2=TUBE;3=BOTH
        '11-19 10-90%,21-29,31-39
        Dim CodiceM As Short '1 ASME  11 ASME+TEMAR 12 ASME+TEMACB
        Dim CodiceT As Short
        Dim Lati As Short 'Nø di lati (camere)
        Dim EffMant As Single
        Dim EffTubi As Single
        Dim CorrExtMant As Single
        Dim CorrExtTubi As Single
        'UPGRADE_NOTE: TubiInform è stato aggiornato a TubiInform_Renamed. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1061"'
        Dim TubiInform_Renamed As TubiInform
        Dim MDMTTempTubi As Single
        Dim MDMTTempMant As Single
        Dim NPassMant As Short
        Dim NPassTubi As Short
        <VBFixedArray(31)> Dim Padding() As Single

        'UPGRADE_TODO: "Initialize" deve essere chiamato per inizializzare istanze di questa struttura. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1026"'
        Public Sub Initialize()
            ReDim Padding(31)
        End Sub
    End Structure
    Structure DatiShe '276
        <VBFixedString(40), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst:=40)> Public DenomItem As String
        <VBFixedString(20), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst:=20)> Public Impianto As String
        'UPGRADE_ISSUE: Tipo di dichiarazione non supportato: Matrici di stringhe di lunghezza fissa. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1051"'
		Dim TEMALetter(3) As String*1
        <VBFixedString(1), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst:=1)> Public FBMLetter As String
        <VBFixedString(4), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst:=4)> Public IndCodice As String
        <VBFixedString(15), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst:=15)> Public Padd As String
        <VBFixedString(20), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst:=20)> Public PassM As String
        Dim PassT As Short
        Dim FaseM As Short 'liq gas gas-liq cond evap
        Dim FaseT As Short
        <VBFixedArray(1)> Dim ValorM() As Single 'non usato
        <VBFixedArray(1)> Dim ValorT() As Single 'non usato
        Dim PortataM As Single
        Dim PortataT As Single
        Dim VolumeM As Single
        Dim VolumeT As Single
        Dim LatenteM As Single
        Dim LatenteT As Single
        Dim FoulingM As Single
        Dim FoulingT As Single
        Dim Duty As Single
        Dim MTD As Single
        Dim TempTubiMin As Single
        Dim TempMantMin As Single
        Dim TempTubiEse As Single
        Dim TempMantEse As Single
        Dim TempTubiStTubi As Single
        Dim TempTubiStMant As Single
        Dim TempMantStTubi As Single
        Dim TempMantStMant As Single
        Dim TempProgPiastra As Single
        Dim PressTubiEse As Single
        Dim PressMantEse As Single
        Dim PHWTTubi As Short '0 no 1 si
        Dim PHWTMant As Short
        Dim RXTubi As Short 'no spot 100%
        Dim RXMant As Short 'no spot 100%
        <VBFixedArray(13)> Dim Pdding() As Single
        Dim Approved As Short
        'UPGRADE_ISSUE: Tipo di dichiarazione non supportato: Matrici di stringhe di lunghezza fissa. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1051"'
		Dim Padding(5) As String*1

        'UPGRADE_TODO: "Initialize" deve essere chiamato per inizializzare istanze di questa struttura. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1026"'
        Public Sub Initialize()
            ReDim ValorM(1)
            ReDim ValorT(1)
            'UPGRADE_WARNING: Il limite inferiore della matrice Pdding è stato cambiato da 1 a 0. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1033"'
            ReDim Pdding(13)
        End Sub
    End Structure
    Structure DatiSh1
        'UPGRADE_NOTE: MateInform è stato aggiornato a MateInform_Renamed. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1061"'
        <VBFixedArray(6)> Dim MateInform_Renamed() As MateInform
        Dim FirstIndex As Short
        <VBFixedString(8), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst:=8)> Public Padding As String

        'UPGRADE_TODO: "Initialize" deve essere chiamato per inizializzare istanze di questa struttura. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1026"'
        Public Sub Initialize()
            ReDim MateInform(6)
        End Sub
    End Structure
    Structure DatiSh2 '276
        <VBFixedArray(12)> Dim ValorM() As Single '1)densità 2)cp 3)visc 4)k
        'in liq,in vap out liq out vap
        <VBFixedArray(12)> Dim ValorT() As Single
        <VBFixedArray(4)> Dim SteamWM() As Single 'in steam,in water,out steam out water
        <VBFixedArray(4)> Dim SteamWT() As Single
        <VBFixedArray(2)> Dim PortVap() As Single
        <VBFixedArray(2)> Dim PortLiq() As Single
        'UPGRADE_ISSUE: Tipo di dichiarazione non supportato: Matrici di stringhe di lunghezza fissa. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1051"'
		Dim Padd(132) As String*1

        'UPGRADE_TODO: "Initialize" deve essere chiamato per inizializzare istanze di questa struttura. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1026"'
        Public Sub Initialize()
            'UPGRADE_WARNING: Il limite inferiore della matrice ValorM è stato cambiato da 1 a 0. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1033"'
            ReDim ValorM(12)
            'UPGRADE_WARNING: Il limite inferiore della matrice ValorT è stato cambiato da 1 a 0. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1033"'
            ReDim ValorT(12)
            'UPGRADE_WARNING: Il limite inferiore della matrice SteamWM è stato cambiato da 1 a 0. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1033"'
            ReDim SteamWM(4)
            'UPGRADE_WARNING: Il limite inferiore della matrice SteamWT è stato cambiato da 1 a 0. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1033"'
            ReDim SteamWT(4)
            'UPGRADE_WARNING: Il limite inferiore della matrice PortVap è stato cambiato da 1 a 0. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1033"'
            ReDim PortVap(2)
            'UPGRADE_WARNING: Il limite inferiore della matrice PortLiq è stato cambiato da 1 a 0. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1033"'
            ReDim PortLiq(2)
        End Sub
    End Structure
End Module