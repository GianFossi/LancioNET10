Option Strict Off
Option Explicit On
Module DATIDES4
    Structure strMateInform '38
        Dim Tipo As Short '0 mono monopl monoriv mono lin biplacc biriv bilin
        Dim Ind1 As Short '0 inenistente -1 non codificato
        Dim Ind2 As Short
        Dim Ind3 As Short
        Public Descr As String
    End Structure
    Structure strTubiInform
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
    Structure strDatiDes
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
        Dim TubiInform As strTubiInform
        Dim MDMTTempTubi As Single
        Dim MDMTTempMant As Single
        Dim NPassMant As Short
        Dim NPassTubi As Short
    End Structure
    Structure strDatiShe '276
        Public DenomItem As String
        Public Impianto As String
        Dim TEMALetter() As String
        Public FBMLetter As String
        Public IndCodice As String
        Public Padd As String
        Public PassM As String
        Dim PassT As Short
        Dim FaseM As Short 'liq gas gas-liq cond evap
        Dim FaseT As Short
        Dim ValorM() As Single 'non usato
        Dim ValorT() As Single 'non usato
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
        Dim Approved As Short
        Public Sub Initialize()
            ReDim ValorM(1)
            ReDim ValorT(1)
            ReDim TEMALetter(3)
        End Sub
    End Structure
    Structure strDatiSh1
        Dim MateInform() As strMateInform
        Dim FirstIndex As Short
        Public Sub Initialize()
            ReDim MateInform(6)
        End Sub
    End Structure
    Structure strDatiSh2 '276
        Dim ValorM() As Single '1)densità 2)cp 3)visc 4)k
        'in liq,in vap out liq out vap
        Dim ValorT() As Single
        Dim SteamWM() As Single 'in steam,in water,out steam out water
        Dim SteamWT() As Single
        Dim PortVap() As Single
        Dim PortLiq() As Single
        Public Sub Initialize()
            ReDim ValorM(12)
            ReDim ValorT(12)
            ReDim SteamWM(4)
            ReDim SteamWT(4)
            ReDim PortVap(2)
            ReDim PortLiq(2)
        End Sub
    End Structure
End Module