Option Strict On
Option Explicit On 
Imports Microsoft.win32
Imports System.io
Public Class modTipi
    ' Structure prezzi
    ' Dim Indmat As Short
    ' Dim prezzo() As Integer 'vedi Classe1(0)''
    ' Public Sub Initialize()
    '     ReDim prezzo(19)
    ' End Sub
    ' End Structure
    'Structure Vec2
    'Dim X As Single
    'Dim y As Single
    'End Structure
    'Structure Vec3
    'Dim X As Single
    'Dim y As Single
    'Dim Z As Single
    'End Structure
    'Structure Linea2 'gruppo di due punti in 2 dimensioni
    'Dim P0 As Vec2
    'Dim p1 As Vec2
    'End Structure
    'Structure posizn
    'Dim SuChi As Short 'Ind del Componente sul quale
    'Public Quota As String 'Quota lungo l'asse del quale
    'Public Anomal As String 'Anomalia
    'Public Raggio As String '
    'Public DirDiritta As String 'Direz nuovo asse
    'Public DirTraversa As String
    'Public NearFar As String 'Nuovo part.attaccato su N F
    'Dim QuotaR As Single
    'Dim AnomalR As Single
    'Dim RaggioR As Single
    'Dim Origine As Vec3
    'Dim CosOrigine As Vec3
    'Dim CosDiritta As Vec3
    'Dim CosTraversa As Vec3
    'Dim CosTerza As Vec3
    'Dim BaricAss As Vec3
    'Dim BaricRel As Vec3
    'End Structure 'Lungh=162
    'Structure RecAPRn
    'Dim posspa As posizn
    'Dim PosDis As Short 'V
    'Dim Ind As Short
    'Dim Tipo As Short '99: posizione fittizia
    ''98: continuazione di posizione
    ''negativo:legato alla precedente
    ''97: foratura
    ''95: poligonale
    'Dim Qta As Integer 'V
    'Dim Indmat As Integer
    'Dim SubClasse As Short
    'Dim UltimoAppeso As Short
    'Dim PNET As Single 'V
    'Dim PSFR As Single 'V
    'Dim PLOR As Single 'V
    'Dim LKG As Single 'V
    'Dim LTO As Single 'V
    'Public Denom As String 'V
    'Public MATE As String 'V
    'Public DIME As String 'V
    'Public Note As String 'V
    'Public MF As String 'V
    ''-----------------------------------------------------------------------
    'Dim ForoSecondario As Short
    'Dim Cody As Short
    'Dim ForoTerziario As Short
    'Dim PSP As Short
    'Dim Dati() As Single
    'Public PipeBuf As String
    'Public PipeSch As String
    'Public PipeDN As String
    'Dim prezzoID As Integer
    'Dim prezzoID2 As Integer
    'Dim prezzoID3 As Integer
    'Dim Unit As Short 'unità 1 o 2 dei prezzi
    'Dim padUnit As Short
    'Dim Lato As Short
    'Dim Bucante As Short
    'Dim IndMat2 As Short
    'Dim IndMat3 As Short
    'Dim LireLETot As Single
    'Dim Livello As Short
    'Dim intPad As Short

    'Public Sub Initialize()
    '    ReDim Dati(52)
    'End Sub
    'End Structure
    'Structure RecAPRm
    'Dim posspa As posizn
    'Dim PosDis As Short 'V
    'Dim Ind As Short
    'Dim Tipo As Short '99: posizione fittizia
    ''98: continuazione di posizione
    ''negativo:legato alla precedente
    ''97: foratura
    ''95: poligonale
    'Dim Qta As Integer 'V
    'Dim Indmat As Integer
    'Dim SubClasse As Short
    'Dim UltimoAppeso As Short
    'Dim PNET As Single 'V
    'Dim PSFR As Single 'V
    'Dim PLOR As Single 'V
    'Dim LKG As Single 'V
    'Dim LTO As Single 'V
    'Public Denom As String 'V
    'Public MATE As String 'V
    'Public DIME As String 'V
    'Public Note As String 'V
    'Public MF As String 'V
    ''-----------------------------------------------------------------------
    'Dim ForoSecondario As Short
    'Dim Npunti As Short
    'Dim ForoTerziario As Short
    'Dim PSP As Short
    'Dim Vertici() As Vec2
    'Dim Centri() As Vec2
    'Dim Raggi() As Single
    'Dim Dati() As Single
    'Dim Livello As Short
    'Dim intPad As Short
    'Public Sub Initialize()
    '    ReDim Vertici(12)
    '    ReDim Centri(12)
    '    ReDim Raggi(12)
    '    ReDim Dati(3)
    'End Sub
    'End Structure
    'Structure spicchio
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
    ' Structure Rectang
    ' Dim Corners() As Vec2
    ' Dim Lung As Single
    ' Dim LARG As Single
    ' Public Sub Initialize()
    '     ReDim Corners(4)
    ' End Sub
    'End Structure
    ' Structure IndiceG 'fornisce la sequenza all'interno di mat/spess
    ' Dim IndinGre() As Short
    ' Dim Num As Short
    ' Dim Indmat As Short
    ' Dim Classe As Short
    ' Dim SP As Single
    ' Public Sub Initialize()
    '     ReDim IndinGre(100)
    ' End Sub
    ' End Structure 'LungILM=102+10=112
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
End Class
Module Generale
    Public myAssembly As System.Reflection.Assembly
    Public rmHelpStrings As Resources.ResourceManager
    Public Vecchio As Boolean
    Public Risult() As Boolean
    Public Strin() As String
    Public UltAiu As String
    Public Abilitato As Boolean
    Public LineaContinua As AutoCAD.AcadLineType
    Public LineaNascosta As AutoCAD.AcadLineType
    Public TrattPunto As AutoCAD.AcadLineType
    Public GiaFatto, GiaFattoB As Boolean
    Public Trigon As clsTrigon
    Public Archdir As String
    Public gInizio As RoutBase1.clsInizio
    '--------------------------------------------------
    Public Const gstrSEP_DIR As String = "\"  ' Directory separator character
    Public Const gstrAT As String = "@"
    Public Const gstrSEP_DRIVE As String = ":" ' Driver separater character, e.g., C:\
    Public Const gstrSEP_DIRALT As String = "/" ' Alternate directory separator character
    Public Const gstrSEP_EXT As String = "." ' Filename extension separator character
    Public Const gstrSEP_URLDIR As String = "/" ' Separator for dividing directories in URL addresses.
    Public Const gstrCOLON As String = ":"
    Public Const gstrSwitchPrefix2 As String = "/"
    Public Const gstrCOMMA As String = ","
    Public Const gstrDECIMAL As String = "."
    Public Const gstrQUOTE As String = """"
    Public Const gstrASSIGN As String = "="
    '---------------------------------------------------
    Const gREGKEYSYSINFOLOC As String = "SOFTWARE\Microsoft\Shared Tools Location"
    Const gREGVALSYSINFOLOC As String = "MSINFO"
    Const gREGKEYSYSINFO As String = "SOFTWARE\Microsoft\Shared Tools\MSINFO"
    Const gREGVALSYSINFO As String = "PATH"
    '-----------------------------------------
    ' Opzioni di protezione per la chiave del registro di configurazione
    '	Public Const READ_CONTROL As Integer = &H20000
    '	Public Const STANDARD_RIGHTS_ALL As Integer = &H1F0000
    '	Public Const KEY_QUERY_VALUE As Short = &H1s
    '	Public Const KEY_SET_VALUE As Short = &H2s
    '	Public Const KEY_CREATE_SUB_KEY As Short = &H4s
    '	Public Const KEY_ENUMERATE_SUB_KEYS As Short = &H8s
    '	Public Const KEY_NOTIFY As Short = &H10s
    '	Public Const KEY_CREATE_LINK As Short = &H20s
    '	Public Const SYNCHRONIZE As Integer = &H100000
    '	Public Const KEY_ALL_ACCESS As Double = KEY_QUERY_VALUE + KEY_SET_VALUE + KEY_CREATE_SUB_KEY + KEY_ENUMERATE_SUB_KEYS + KEY_NOTIFY + KEY_CREATE_LINK + READ_CONTROL

    ' Chiavi principali del registro di configurazione
    '	Public Const HKEY_LOCAL_MACHINE As Integer = &H80000002
    '	Public Const HKEY_CURRENT_USER As Integer = &H80000001
    '	Public Const HKEY_USERS As Integer = &H80000003
    '	Public Const HKEY_DYN_DATA As Integer = &H80000006
    '	Public Const HKEY_CURRENT_CONFIG As Integer = &H80000005
    '	Public Const HKEY_CLASSES_ROOT As Integer = &H80000000
    '	Public Const ERROR_SUCCESS As Short = 0
    '	Public Const REG_NONE As Short = 0
    '	Public Const REG_SZ As Short = 1 ' Stringa Unicode che termina con un carattere Null
    '	Public Const REG_EXPAND_SZ As Short = 2
    '	Public Const REG_BINARY As Short = 3
    '	Public Const REG_DWORD As Short = 4 ' Numero a 32 bit
    'Public Declare Function RegOpenKey Lib "advapi32"  Alias "RegOpenKeyA"(ByVal hKey As Integer, ByVal lpSubKey As String, ByRef phkResult As Integer) As Integer
    'Public Declare Function RegOpenKeyEx Lib "advapi32"  Alias "RegOpenKeyExA"(ByVal hKey As Integer, ByVal lpSubKey As String, ByVal ulOptions As Integer, ByVal samDesired As Integer, ByRef phkResult As Integer) As Integer
    'Public Declare Function RegQueryValueEx Lib "advapi32"  Alias "RegQueryValueExA"(ByVal hKey As Integer, ByVal lpValueName As String, ByVal lpReserved As Integer, ByRef lpType As Integer, ByVal lpData As String, ByRef lpcbData As Integer) As Integer
    'Public Declare Function RegCloseKey Lib "advapi32" (ByVal hKey As Integer) As Integer
    '---------------------------------------------------------------------------------
    'FIXIT: As Any non è supportato in Visual Basic .NET. Utilizzare un tipo specifico.        FixIT90210ae-R5608-H1984
    'UPGRADE_ISSUE: La dichiarazione di un parametro "As Any" non è supportata. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1016"'
    'UPGRADE_ISSUE: La dichiarazione di un parametro "As Any" non è supportata. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1016"'
    '	Public Declare Sub CopyMem Lib "kernel32"  Alias "RtlMoveMemory"(ByRef Destination As Any, ByRef Source As Any, ByVal Length As Integer)
    '-------------------------------------------------------
    'per interrogare la rete
    Structure MungeLong
        Dim X As Integer
        Dim Dummy As Short
    End Structure
    Structure MungeInt
        Dim XLo As Short
        Dim XHi As Short
        Dim Dummy As Short
    End Structure
    ' Structure is 24 bytes long
    Structure SESSION_INFO_1
        Dim sesi1_cname As Integer '4
        Dim sesi1_username As Integer '4
        Dim sesi1_num_opens As Integer
        Dim sesi1_time As Integer
        Dim sesi1_idel_time As Integer
        Dim sesi1_user_flags As Integer
    End Structure
    Public Sub StartSysInfo()
        Dim key As RegistryKey
        Dim SysInfoPath As String
        Try
            key = Registry.LocalMachine.OpenSubKey(gREGKEYSYSINFO)
            SysInfoPath = CType(key.GetValue(gREGVALSYSINFO), String)
            If SysInfoPath = "" Then
                key = Registry.LocalMachine.OpenSubKey(gREGKEYSYSINFOLOC)
                SysInfoPath = CType(key.GetValue(gREGVALSYSINFOLOC), String)
                If File.Exists(SysInfoPath & "\MSINFO32.EXE") Then
                    SysInfoPath = SysInfoPath & "\MSINFO32.EXE"
                Else
                    Throw New Exception("MSINFO32.EXE not found")
                End If
            End If
        Catch err As Security.SecurityException
            MsgBox(err.ToString)
            MsgBox("Le informazioni sul sistema non sono attualmente disponibili.", MsgBoxStyle.OKOnly)
            Exit Sub
        Catch err As UnauthorizedAccessException
            MsgBox(err.ToString)
            MsgBox("Le informazioni sul sistema non sono attualmente disponibili.", MsgBoxStyle.OKOnly)
            Exit Sub
        Catch err As Exception
            MsgBox(err.ToString)
            MsgBox("Le informazioni sul sistema non sono attualmente disponibili.", MsgBoxStyle.OKOnly)
            Exit Sub
        Finally
        End Try
        Call Shell(SysInfoPath, AppWinStyle.NormalFocus)
    End Sub
    Public Function HelpStringa(ByVal id As Integer) As String
        Dim Nome As String = "str" + id.ToString.Trim
        HelpStringa = rmHelpStrings.GetString(Nome).Replace("|", vbCrLf)
    End Function
    Public Function Helptopic(ByVal id As Integer) As String
        Select Case id
            Case clsInizio.IDHS.IDH_AUTOCAD_ASSENTE : Return "AutoCAD.htm"
            Case clsInizio.IDHS.IDH_AUTOCAD_VECCHIO : Return " AutoCAD.htm"
            Case clsInizio.IDHS.IDH_CAP_BANCHEDATI : Return " BancheDati.htm"
            Case clsInizio.IDHS.IDH_CAP_BD_MAT_CLASSE : Return "LibreriaMateriali.htm#Classe"
            Case clsInizio.IDHS.IDH_CAP_BD_MAT_DATIFAT : Return "LibreriaMateriali.htm#Fatto"
            Case clsInizio.IDHS.IDH_CAP_BD_MAT_DATIRIP : Return "LibreriaMateriali.htm#Rip"
                '   Case clsInizio.IDHS.IDH_CAP_BD_MAT_DB : Return "LibreriaMateriali.htm#DB"
            Case clsInizio.IDHS.IDH_CAP_BD_MAT_SCELTA : Return "LibreriaMateriali.htm#Scelta"
            Case clsInizio.IDHS.IDH_CAP_BD_MAT_SCHEDA : Return "LibreriaMateriali.htm#Scheda"
                '  Case clsInizio.IDHS.IDH_CAP_BD_MATERIALI : Return " LibreriaMateriali.htm"
                ' Case clsInizio.IDHS.IDH_CAP_GENERALITA : Return " Generalita.htm"
            Case clsInizio.IDHS.IDH_ERR_AUTOEXECBAT : Return "AutoExecBat.htm"
            Case clsInizio.IDHS.IDH_ERR_AUTOEXECNT : Return "AutoExexNT.htm"
            Case clsInizio.IDHS.IDH_ERR_CHECKDIR : Return "CheckDir.htm"
            Case clsInizio.IDHS.IDH_ERR_LANCIOINI : Return "Lancioini.htm"
            Case clsInizio.IDHS.IDH_ERR_LIBMAT_ALFATER1 : Return "ErrLibMatAlfaTer1.htm"
            Case clsInizio.IDHS.IDH_ERR_LIBMAT_ALFATER2 : Return "ErrLibMatAlfaTer2.htm"
            Case clsInizio.IDHS.IDH_ERR_LIBMAT_EMODALT1 : Return "ErrLibMatEmodAlt1.htm"
            Case clsInizio.IDHS.IDH_ERR_LIBMAT_EMODALT2 : Return "ErrLibMatEmodAlt2.htm"
            Case clsInizio.IDHS.IDH_ERR_LIBMAT_LEGRAT1 : Return "ErrLibMatLegRat1.htm"
            Case clsInizio.IDHS.IDH_ERR_LIBMAT_LEGRAT2 : Return "ErrLibMatLegRat2.htm"
            Case clsInizio.IDHS.IDH_ERR_LIBMAT_NODIV1 : Return "ErrLibMatNoDiv1.htm"
            Case clsInizio.IDHS.IDH_ERR_LIBMAT_NODIV1b : Return "ErrLibMatNoDiv1.htm"
            Case clsInizio.IDHS.IDH_ERR_LIBMAT_NOINDMAT : Return "ErrLibMatNoIndMat.htm"
            Case clsInizio.IDHS.IDH_ERR_LIBMAT_NOLISTINO : Return "ErrLibMatNoPrezzi.htm"
            Case clsInizio.IDHS.IDH_ERR_LIBMAT_NOVALOR1 : Return "ErrLibMatNoTabelle.htm"
            Case clsInizio.IDHS.IDH_FINLANCIO_BOTTAFC : Return "Pulsanti.htm#ISA"
            Case clsInizio.IDHS.IDH_FINLANCIO_BOTTGEST : Return "Pulsanti.ftm#Gest"
            Case clsInizio.IDHS.IDH_FINLANCIO_BOTTPRECONS : Return "Pulsanti.htm#PreCons"
            Case clsInizio.IDHS.IDH_FINLANCIO_BOTTST : Return "Pulsanti.htm#IST"
            Case clsInizio.IDHS.IDH_FINLANCIO_BOTTUTIL : Return "Pulsanti.htm#Util"
            Case clsInizio.IDHS.IDH_FINLANCIO_BOTTWHB : Return "Pulsanti.htm#WHB"
            Case clsInizio.IDHS.IDH_FINLANCIO_BOTTWPS : Return "Pulsanti.htm#WPS"
            Case clsInizio.IDHS.IDH_INIZIO_ARCHIVI : Return "Aree.htm#Archivi"
            Case clsInizio.IDHS.IDH_INIZIO_BRT : Return "Aree.htm#Brt"
            Case clsInizio.IDHS.IDH_INIZIO_CAMBIORETE : Return "FunzRete.htm"
            Case clsInizio.IDHS.IDH_INIZIO_CAMBIORETE1 : Return "FunzRete.htm"
            Case clsInizio.IDHS.IDH_INIZIO_ESEGUIBILI : Return "Aree.htm#eseguibili"
            Case clsInizio.IDHS.IDH_INIZIO_LAVCOMMESS : Return "Aree.htm#lavcomm"
            Case clsInizio.IDHS.IDH_INIZIO_LAVSCIOLTI : Return "Aree.htm#lavsciolti"
            Case clsInizio.IDHS.IDH_INIZIO_RISPOSTASI : Return "FunzRete.htm"
            Case clsInizio.IDHS.IDH_LB_SCHEDA_CARACT : Return "LibreriaMateriali.htm#CARACT"
            Case clsInizio.IDHS.IDH_LB_SCHEDA_CHART : Return "LibreriaMateriali.htm#CHART"
            Case clsInizio.IDHS.IDH_LB_SCHEDA_CLASSIF : Return "LibreriaMateriali.htm#CLASSIF"
            Case clsInizio.IDHS.IDH_LB_SCHEDA_DATICODICE : Return "LibreriaMateriali.htm#DATICODICE"
            Case clsInizio.IDHS.IDH_LB_SCHEDA_DENOM : Return "LibreriaMateriali.htm#DENOM"
            Case clsInizio.IDHS.IDH_LB_SCHEDA_FONTE : Return "LibreriaMateriali.htm#FONTE"
            Case clsInizio.IDHS.IDH_LB_SCHEDA_GRUPPO : Return "LibreriaMateriali.htm#GRUPPO"
            Case clsInizio.IDHS.IDH_LB_SCHEDA_MWDTRULES : Return "LibreriaMateriali.htm#MWDTRULES"
            Case clsInizio.IDHS.IDH_LB_SCHEDA_MWDTRULES1 : Return "LibreriaMateriali.htm#MWDTRULES1"
            Case clsInizio.IDHS.IDH_LB_SCHEDA_MWDTRULES2 : Return "LibreriaMateriali.htm#MWDTRULES2"
            Case clsInizio.IDHS.IDH_LB_SCHEDA_MWDTRULES3 : Return "LibreriaMateriali.htm#MWDTRULES3"
            Case clsInizio.IDHS.IDH_LB_SCHEDA_PNUMBER : Return "LibreriaMateriali.htm#PNUMBER"
            Case clsInizio.IDHS.IDH_LB_SCHEDA_PREZZI : Return "LibreriaMateriali.htm#PREZZI"
            Case clsInizio.IDHS.IDH_LB_SCHEDA_SNERV : Return "LibreriaMateriali.htm#SNERV"
            Case clsInizio.IDHS.IDH_LB_SCHEDA_TABELL1 : Return "LibreriaMateriali.htm#TABELL1"
            Case clsInizio.IDHS.IDH_LB_SCHEDA_TABELL2 : Return "LibreriaMateriali.htm#TABELL2"
            Case clsInizio.IDHS.IDH_LISTINO_HELP : Return "LibreriaMateriali.htm#Listini"
            Case clsInizio.IDHS.IDH_OPZIONE_LAVSCIOLTI : Return "Aree.htm#FinLavSciol"
                'Case clsInizio.IDHS.IDH_PAR_G_AUTENT : Return " Autenticazione.htm"
            Case clsInizio.IDHS.IDH_SIST_LINGUA : Return "Lingua.htm"
            Case clsInizio.IDHS.IDH_SIST_RISOL : Return "Risoluzione.htm"
            Case clsInizio.IDHS.IDH_SIST_SEPDEC : Return "SepDec.htm"
            Case clsInizio.IDHS.IDH_SIST_STAMP : Return "ErrStampante.htm"
            Case clsInizio.IDHS.IDH_WORD_ASSENTE : Return "Word.htm"
            Case clsInizio.IDHS.IDH_WORD_VECCHIO : Return "Word.htm"
            Case clsInizio.IDHS.MSG_ALFACALDO : Return "msgAlfa.htm"
            Case clsInizio.IDHS.MSG_ALFAFREDDO : Return "msgAlfa.htm"
            Case clsInizio.IDHS.MSG_AMMISSCALDO : Return "MsgAmmissC.htm"
            Case clsInizio.IDHS.MSG_AMMISSFREDDO : Return "MsgAmmissF.htm"
            Case clsInizio.IDHS.MSG_YIELDCALDO : Return "MsgSnervC.htm"
            Case clsInizio.IDHS.MSG_YIELDFREDDO : Return "MsgSnervF.htm"
            Case clsInizio.IDHS.MSG_YOUNGCALDO : Return "msgYoung.htm"
            Case clsInizio.IDHS.MSG_YOUNGFREDDO : Return "msgYoung.htm"
            Case clsInizio.IDHS.PIP_HELP : Return "Librpip.htm"
            Case Else : Return ""
        End Select
    End Function
End Module
<Serializable()> Public Class clsDatiDes
    <Serializable()> Public Structure typMateInform '38
        Dim Tipo As Short '0 mono monopl monoriv mono lin biplacc biriv bilin
        Dim Ind1 As Short '0 inenistente -1 non codificato
        Dim Ind2 As Short
        Dim Ind3 As Short
        Dim Descr As String
    End Structure
    <Serializable()> Public Structure typTubiInform
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
    <Serializable()> Public Structure typDatiDes
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
        Dim TubiInform As typTubiInform
        Dim MDMTTempTubi As Single
        Dim MDMTTempMant As Single
        Dim NPassMant As Short
        Dim NPassTubi As Short
    End Structure
    <Serializable()> Public Structure typDatiShe '276
        Public DenomItem As String
        Public Impianto As String
        Dim TEMALetter() As Char
        Public FBMLetter As Char
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
            Dim i As Short
            ReDim ValorM(1)
            ReDim ValorT(1)
            ReDim TEMALetter(3)
            FBMLetter = " "c
            For i = 0 To 3
                TEMALetter(i) = " "c
            Next
            DenomItem = ""
            Impianto = ""
            IndCodice = ""
        End Sub
    End Structure
    <Serializable()> Public Structure typDatiSh1
        Dim MateInform() As typMateInform
        Dim FirstIndex As Short
        Public Sub Initialize()
            ReDim MateInform(6)
        End Sub
    End Structure
    <Serializable()> Public Structure typDatiSh2 '276
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
    Public DatiPrg As typDatiDes
    Public DatiSh0 As typDatiShe
    Public DatiS1() As typDatiSh1
    Public DatiS2 As typDatiSh2
    Public Sub New()
        Dim i As Short
        ReDim DatiS1(3)
        DatiSh0.Initialize()
        For i = 0 To 3
            DatiS1(i).Initialize()
        Next
        DatiS2.Initialize()
    End Sub
End Class
