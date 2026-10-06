Option Strict Off
Option Explicit On
Imports RoutBase1
Imports System.IO
Imports System.Runtime.Serialization
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Runtime.InteropServices
Imports Infralution.Licensing
Module GenHTRI
    'PRIMA DI HTRI23 CHIAMARE NZONE (VEDI NHTRI1.FOR)
    'DOPO HTRI21 E HTRI23 CHIAMARE ZONCOND E HTRI24
    'DOPO HTRI24 CALL CHECK
    Public Declare Sub FORMATF Lib "FormatFORTRAN.dll" Alias "_formatf@4" _
                             (<MarshalAs(UnmanagedType.BStr)> ByRef TRANSFER As String)
    'Declare Sub Sleep Lib "kernel32" (ByVal dwMilliseconds As Integer)
    ' Declare Sub APRIPR Lib "HtriLib.DLL" (ByRef iIn As Short, ByRef iOut As Short, ByRef NP As Str6, ByRef iErr As Short)
    ' Declare Sub CLOSE4 Lib "HtriLib.DLL" ()
    'Declare Sub PUTGEN Lib "HtriLib.DLL" (ByRef P As typPutGen)
    'Declare Sub GETGEN Lib "HtriLib.DLL" (ByRef P As typPutGen)
    'Declare Sub PUTBANK Lib "HtriLib.DLL" Alias "PUTBANKA" (ByRef Pb As StrP4)
    'Declare Sub GETBANK Lib "HtriLib.DLL" Alias "GETBANKA" (ByRef Pb As StrP4)
    'Declare Sub SETRDIT Lib "HtriLib.DLL" (ByRef Item As Str20, ByRef n As Short)
    'Declare Sub NEWITM Lib "HtriLib.DLL" (ByRef n As Short, ByRef M As Short, ByRef Item As Str20)
    ' Declare Sub COPIA Lib "HtriLib.DLL" (ByRef Item As Str20, ByRef Iten As Str20)
    'Declare Sub SEARCHA Lib "HtriLib.DLL" (ByRef Ialt As Alternative)
    'Declare Sub GETPROG Lib "HtriLib.DLL" (ByRef n As Short, ByRef C As Str2)
    Declare Sub SETALT Lib "HtriLib.DLL" (ByRef Ial As Short)
    Declare Sub DELALT Lib "HtriLib.DLL" ()
    Declare Sub DELNOT Lib "HtriLib.DLL" ()
    Declare Sub DELITM Lib "HtriLib.DLL" ()
    ' Declare Sub INIZUPMF Lib "HtriLib.DLL" ()
    'Declare Sub LISTITEM Lib "HtriLib.DLL" (ByRef Buf As typLstItm, ByRef n As Short, ByRef iErr As Short)
    Declare Sub RISCRI Lib "HtriLib.DLL" (ByRef i As Short, ByRef j As Short, ByRef Buf As typRiscri)
    Declare Sub LOOPDOM Lib "HtriLib.DLL" (ByRef i As Short, ByRef j As Short, ByRef Buf As typRiscri)
    'Declare Function SPBWG Lib "HtriLib.DLL" (ByRef A As Str2, ByRef B As Str2) As Single
    'Declare Function IEXIST Lib "HtriLib.DLL" (ByRef A As Single, ByRef B As Single, ByRef C As Single, ByRef D As Single, ByRef Al As Str2, ByRef AB As NumR4) As Short
    'Declare Sub MYSTRF Lib "HtriLib.DLL" (ByRef A As Single, ByRef B As Short, ByRef C As Short, ByRef D As Str20)
    'Declare Sub SETDEBUG Lib "HtriSub.DLL" (ByRef i As Short)
    Declare Sub HTRI1 Lib "HtriSub.DLL" (ByRef i As Short)
    Declare Sub HTRI12 Lib "HtriSub.DLL" (ByRef o As typDatiFun, ByRef i As Short)
    Declare Sub HTRI11 Lib "HtriSub.DLL" (ByRef o As typDatiFun)
    Declare Sub DISPDAT Lib "HtriSub.DLL" ()
    Declare Sub HTRI2 Lib "HtriSub.DLL" (ByRef X As Short, ByRef Y As Short, ByRef n As Short, ByRef i As Short)
    Declare Sub HTRI21 Lib "HtriSub.DLL" ()
    Declare Sub HTRI23 Lib "HtriSub.DLL" (ByRef n As Short, ByRef i As Short)
    Declare Sub HTRI24 Lib "HtriSub.DLL" (ByRef Ib As ZoneCond)
    Declare Sub GETDUT Lib "HtriSub.DLL" (ByRef r As Real8)
    Declare Sub HTRI3 Lib "HtriSub.DLL" (ByRef i As Short, ByRef iErr As Short)
    Declare Sub HTRI4 Lib "HtriSub.DLL" (ByRef i As Short)
    Declare Sub HTRI41 Lib "HtriSub.DLL" ()
    Declare Sub HTRI42 Lib "HtriSub.DLL" ()
    Declare Sub HTRI43 Lib "HtriSub.DLL" (ByRef iOK As Short)
    Declare Sub HTRI6 Lib "HtriSub.DLL" ()
    Declare Sub HTRI61 Lib "HtriSub.DLL" () '(iOK As Integer)
    Declare Sub HTRI62 Lib "HtriSub.DLL" (ByRef iOK As Short)
    Declare Sub HTR6B Lib "HtriSub.DLL" (ByRef Err_Renamed As Short)
    Declare Sub HTR6C Lib "HtriSub.DLL" (ByRef Err_Renamed As Short)
    Declare Sub HTRI7 Lib "HtriSub.DLL" (ByRef Err_Renamed As Short)
    'Declare Sub HTR7C Lib "HtriSub.DLL" (ByRef D As Single, ByRef S1 As Sing12, ByRef s2 As Sing12)
    Declare Sub HTRI8 Lib "HtriSub.DLL" (ByRef M As Short)
    'Declare Sub HTR10 Lib "HtriSub.DLL" (ByRef M As Short, ByRef Ialt As Alternative)
    'Declare Sub HTR10A Lib "HtriSub.DLL" (ByRef Ialt As Alternative)
    Declare Sub HTR10B Lib "HtriSub.DLL" ()
    'Declare Sub LOOPZ Lib "HtriSub.DLL" (ByRef Fact As Sing12)
    Declare Function FCREARA1 Lib "HtriSub.DLL" (ByRef iQ As Short) As Integer
    'Declare Sub DSDS Lib "HtriSub.DLL" (ByRef n As Short, ByRef Item As Str20, ByRef u As Str2)
    Declare Sub MFVC1 Lib "HtriSub.DLL" (ByRef n As Short, ByRef l As ListIt, ByRef A As typListaMon)
    Declare Sub MFVC2 Lib "HtriSub.DLL" (ByRef A As typListaMon)
    Declare Sub MFVC3 Lib "HtriSub.DLL" ()
    Declare Sub UPTX1 Lib "HtriSub.DLL" ()
    'Declare Sub UPTX2 Lib "HtriSub.DLL" (ByRef A As Str2, ByRef B As Str2)
    'Declare Sub UPMGTG Lib "HtriLib.DLL" (ByRef A As Str4, ByRef B As Short, ByRef C As Short, ByRef D As Short)
    'Declare Sub UPMPTG Lib "HtriLib.DLL" ()
    'Declare Sub UPMITM Lib "HtriLib.DLL" (ByRef A As Short, ByRef B As Short)
    'Declare Sub UPMPTM Lib "HtriLib.DLL" (ByRef A As Short)
    'Declare Sub UPMALT Lib "HtriLib.DLL" (ByRef A As Short, ByRef B As Short, ByRef C As Short)
    'Declare Sub UPMPLT Lib "HtriLib.DLL" (ByRef A As Short)
    'Declare Sub SETGET Lib "HtriLib.DLL" (ByRef A As Short, ByRef B As Short)
    'Declare Sub SETPUT Lib "HtriLib.DLL" (ByRef A As Short)
    Declare Sub SPSGET Lib "HtriLib.DLL" ()
    Declare Sub SPSPUT Lib "HtriLib.DLL" (ByRef A As Short)
    '  Declare Sub EFFPLG Lib "HtriLib.DLL" (ByRef A As Str2)
    Declare Sub EFFPLP Lib "HtriLib.DLL" ()
    Declare Sub AZZMEC Lib "HtriLib.DLL" ()
    Declare Sub DATIFIN Lib "HtriLib.DLL" ()
    Declare Sub GETFIN Lib "HtriLib.DLL" ()
    Declare Sub VIDEOUPM Lib "HtriSub.DLL" ()
    Declare Sub PUTTEMPZONE Lib "HtriSub.DLL" (ByRef P As prbWald)
    'Declare Sub FILEFUNZ Lib "HtriLib.DLL" (ByRef A As Short, ByRef B As Short, ByRef C As Short, ByRef D As Short, ByRef e As Filef)
    Declare Sub CALSTR Lib "HtriSub.DLL" (ByRef A As Short, ByRef B As Short, ByRef C As Short, ByRef D As Short)
    'Declare Sub REPORT Lib "HtriSub.DLL" (ByRef A As Short, ByRef B As Short, ByRef C As Str4)
    'Declare Sub ROBFOR Lib "HtriSub.DLL" (ByRef A As Short, ByRef B As Str10, ByRef i As Short, ByRef j As Short, ByRef C As Str4)
    'Declare Sub ROBFO1 Lib "HtriSub.DLL" (ByRef i As Short, ByRef j As Short)
    'Declare Sub ROBFIN Lib "HtriSub.DLL" (ByRef i As Short, ByRef j As Short)
    'Declare Function SPLIT1 Lib "HtriSub.DLL" (ByRef A As Short, ByRef B As Short, ByRef M As Str20, ByRef C As Str4) As Short
    'Declare Function SPLIT2 Lib "HtriSub.DLL" (ByRef A As Short, ByRef B As Short, ByRef M As Str20, ByRef C As Str4) As Short
    Declare Sub FOSTIMA Lib "Fostima.dll" (ByRef Buffer As String)
    Friend NonAncora As Boolean = True
    Friend Const LICENSE_PARAMETERS As String = _
    "<LicenseParameters><RSAKeyValue><Modulus>rHK1o05WsJtXz5t+c08x95ti1Uqlbp1noBUp+uijkwYPns0uHO7rLevnMTg+KxTQye1UgLY/4Qzwahu8+oMIQ+esjS4gJhy/31dZRWfZJ1J7RaF2z0pDmD7HmkmaNsRNOfVNpDaZXpJ8woDrN8dGtcqSzYKsPBKLOdT85iAa4Js=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue><DesignSignature>d7esUGuQjhyLt1O3EM0UkeD1UMbKGDXz0fK/Qm4VkznKBHlFiF1bToPGwZbOW665Gp0S2vTmBj3OCBmT6pxqh9Q7foGAqRRHIZRck6bA615rE33aol4IC0nHk6JQzwkt7DnyOjCP2e+vEuI9OVtzkGMqBxQQubFU8dDiRXRCbfw=</DesignSignature><RuntimeSignature>UngrcpinVlh+DZR+WAv2D0Bbl8PTCIH7z9DFmsE13ugbWmMJq4FWdxxV6zSkOnebXT2WBWeOaWwSdf1IRSRRS+NBL6ECHS6ItOpIgibN0cEjIgKgzOnv4QqbQ76K1FTHJqfgta5lrqrUmhbVNrjz0oYvMrVgV8hh8YhohiygfSE=</RuntimeSignature><KeyStrength>7</KeyStrength></LicenseParameters>"
    Public RadiceHelp As String '= "C:\BASE\ESEGUI\BIN\AiutoISA.chm"
    Public Const IDH_GEN_ERRFILE As Short = 800
    Public Const IDH_MFVC_PROCEDURA As Short = 1011
    Public Const IDH_MFVC_PROCSMONT As Short = 1021
    Public Const IDH_MFVC_NONSEQUENZA As Short = 1030
    Public Const IDH_DB_MANCASTRUTTURA As Short = 1032
    Public Const IDH_DB_NOCOMMESSA As Short = 1034
    Public Const IDH_DB_NOSOTTOCO As Short = 1035
    Public Const IDH_DB_MANCADBITEM As Short = 1036
    Public Const IDH_DB_NOCALCOLITEM As Short = 1038
    Public Const IDH_DB_NOCOMPATT As Short = 1040
    Public Const IDH_DB_SEQUENZA As Short = 1041
    Public Const IDH_DB_ESISTEFILE As Short = 1042
    Public Const IDH_DB_GENERAZIONE As Short = 1043
    Public Const IDH_DB_ESAMINA As Short = 1044
    Public Const IDH_DIS_PREPFILE As Short = 1045
    Public Const IDH_DIS_VISFILE As Short = 1046
    Public Const IDH_DIS_ELIMFILE As Short = 1047
    Public Const IDH_DIS_DISEGNA As Short = 1048
    Public Const IDH_HTRI_CARPROG As Short = 1050
    Public Const IDH_HTRI_CAMINI As Short = 1060
    Public Const IDH_HTRI_ARIAHTRI As Short = 1061
    Public Const IDH_HTRI_NONVALIDO As Short = 1070
    Public Const IDH_HTRI_TREENONSEL As Short = 1080
    Public Const IDH_HTRI_STAMNONSEL As Short = 1090
    Public Const IDH_SOMM_RIPETUTO As Short = 1095
    Public Const IDH_HTRI_ALTNONATT As Short = 1098
    Public Const IDH_HTRI_ITEMNONATT As Short = 1099
    Public Const IDH_THER_GENERICO As Short = 1100
    Public Const IDH_THER_HTRI7_101 As Short = 1101
    Public Const IDH_THER_HTRI7_ALTRI As Short = 1102
    Public Const IDH_THER_GIA_RA1 As Short = 1103
    Public Const IDH_THER_CAMBIOFASE As Short = 1104
    Public Const IDH_THER_PRANDTL As Short = 1105
    Public Const IDH_PROC_ERRNOALT As Short = 1106
    Public Const IDH_UPM_DOMSPLIT As Short = 1200
    Public Const IDH_UPM_DIVUG As Short = 1210
    Public Const IDH_UPM_AZZERA As Short = 1230
    Public Const IDH_UPM_SPLIT As Short = 1231
    Public Const IDH_UPM_TUBI As Short = 1232
    Public Const IDH_UPM_EXT As Short = 1233
    Public Const IDH_UPM_TEST As Short = 1234
    Public Const IDH_UPM_DATI As Short = 1235
    Public Const IDH_UPM_DINIZ As Short = 1236
    Public Const IDH_UPM_STRUTTSETTI As Short = 1239 'New
    Public Const IDH_UPM_CONFIG1 As Short = 1240 'New
    Public Const IDH_UPM_CONFIG2 As Short = 1241 'New
    Public Const IDH_UPM_CONFIG3 As Short = 1242 'New
    Public Const IDH_UPM_CONFIG4 As Short = 1243 'New
    Public Const IDH_UPM_NOFILETT As Short = 1244 'New
    Public Const IDH_UPM_SPLIT_1p As Short = 1245 'New
    Public Const IDH_UPM_NOMETHOD As Short = 1246 'New
    Public Const IDH_UPM_NOMETHOD2 As Short = 1247 'New
    Public Const IDH_STR_NUMCOMM As Short = 1300
    Public Const IDH_STR_AT13 As Short = 1313
    Public Const IDH_STR_AT17 As Short = 1317
    Public Const IDH_STR_AT20 As Short = 1320
    Public Const IDH_STR_AT21 As Short = 1321
    Public Const IDH_STR_AT35 As Short = 1335
    Public Const IDH_STR_AT36 As Short = 1336
    Public Const IDH_STR_AT37 As Short = 1337
    Public Const IDH_STR_AT39 As Short = 1339
    '--------------------------------------------
    Public Const INC As Single = 25.4
    Public Const GRAV As Single = 9.8065
    Public Const PSI As Single = 145.0377
    Public kPress, kTemp, kTemp32, kLength As Single
    '-------------------------------------------------------------
    Public actPRV As clsPRV
    Public actItem As clsItem
    Public actAltern As clsAltern
    'PRINCIP--------------------------------------------
    Public IPRAM(11) As Integer
    Public KCALC(12) As Integer
    Public RZ(125, 12) As Single
    Public ALCAM(14) As Single
    Public NZCAM(14, 16), ICAM, TURB(5) As Short
    '-----------------------------------------------------
    '    Structure tipoBuf   *****************************************************
    ' '  <VBFixedArray(60), MarshalAs(UnmanagedType.ByValArray, SizeConst:=61)> Dim iC() As Short
    ' ' <VBFixedArray(7), MarshalAs(UnmanagedType.ByValArray, SizeConst:=8)> Dim LungStx() As Short
    Public ItemnSt, ItemvSt As String
    ' Dim Domanda As Str50
    ' Dim Ialta As Alternative
    ' Dim NTUB As Short
    Public Tub(4) As Single
    Public TubeTk() As TubeData
    Public AB() As Single 'NumR4
    Public SURFUS() As Single
    Public SURFRQ() As Single
    Public AlSt As String
    ' <VBFixedString(32), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=32)> Public Rig As String
    Public RDUT As Real8
    Public Curva As CondCurva
    Public Curva0 As CondCurva
    ' Public Sub Initialize()
    '     Ialta.Initialize()
    '     ReDim Tub(4)
    '     AB.Initialize()
    '     SURFUS.Initialize()
    '     SURFRQ.Initialize()
    '     Curva.Initialize()
    '     Curva0.Initialize()
    ' End Sub ***********************************************************************************
    Public myAssembly As System.Reflection.Assembly
    'Public rmTestiHTRI As Resources.ResourceManager
    Public rmHelpStrings As Resources.ResourceManager
    Public rmHelpTopics As Resources.ResourceManager
    Public GlobalRoutines As RoutBase1.clsTrigon
    Public objBWG As LibMat.clsBWG
    Public Flangia As Grafica.Flangia
    Public ACADApp As Autodesk.AutoCAD.Interop.AcadApplication
    Public ACADobj As Autodesk.AutoCAD.Interop.AcadDocument
    Friend DAODBEngine As New dao.DBEngine
    '    Friend AutoCADAcadApplication_definst As New AutoCAD.AcadApplication
    Public ActivItem As Short
    Public nuovePar As Boolean
    Public iActBank, ModeAltern, ModeFun As Short
    Public objVentil As Ventil.clsVentil
    Public job, job1 As RoutBase1.clsjob
    'UPGRADE_WARNING: È possibile che si debba inizializzare le matrici nella struttura Ib prima di poterle utilizzare. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
    Public Ib As ZoneCond
    Public Ntipi, iF4 As Short
    'UPGRADE_WARNING: Il limite inferiore della matrice Xtub è stato cambiato da 1 a 0. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
    Public Xtub(2) As Short
    'UPGRADE_WARNING: Il limite inferiore della matrice Xalett è stato cambiato da 1 a 0. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
    Public Xalett(2) As Short
    'UPGRADE_WARNING: Il limite inferiore della matrice xGiun è stato cambiato da 1 a 0. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
    Public xGiun(2) As Short
    'UPGRADE_WARNING: Il limite inferiore della matrice Xturb è stato cambiato da 1 a 0. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
    Public Xturb(2) As Short
    Public Ndom, UpmHtr As Short
    Public NuovaAlt As Boolean
    'UPGRADE_WARNING: È possibile che si debba inizializzare le matrici nella struttura ProblWLD prima di poterle utilizzare. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
    Public ProblWLD As prbWald
    Public OKDati As Boolean
    Public FaseDati, FaseDisegno As Short
    Public comm As String
    Public Monitor As clsMonitor
    Public Funzioni As Grafica.LibGra
    Public Routines As RoutBase1.Routines
    'Public iC(,) As Short
    Public Rispv As typRiscri
    Public NumBank As Short
    Public Contin As Boolean
    Public Bank(,) As String ', BankList As Collection, BankItems As Collection
    Public Esp(14) As Short
    Public InputDaBanco As Boolean
    'Public objLstItm As typLstItm
    Public objDatBase As RoutBase1.DatBase
    Public objDatiFun As typDatiFun ', macr As Integer
    Public iMatS, Npass As Short
    Public RifCli As String
    Public LeggiNITE As Boolean
    Public NonMostrareAlt As Boolean
    Public Item(99) As String
    Public Valor() As Single
    Public LungStt() As Short
    Public Risp() As String
    Public Dom() As String
    Public Archiv() As Short
    Public Aiuto() As String
    Public Help() As String
    Public AddDistinta, Ir As Short
    Public Nrdit, Nrditv As Short
    Public NumIt As Short
    Public ActivAlt() As Short
    Public Ialt(,) As Short
    Public SoloUno As Boolean
    Public NumB As Short
    Public BankR(30) As String
    Public NITEF(100) As Short
    Public NITEB(30) As Short
    Public ItemC(100) As String
    Public NumItConc As Short
    'UPGRADE_WARNING: È possibile che si debba inizializzare le matrici nella struttura Disposiz prima di poterle utilizzare. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
    Public Disposiz As Dispos
    Public Globale, FinitoStampe As Boolean
    '=======================================================================
    Friend FormMsg As frmMsg
    Friend Apert As frmHTRI
    Public objHTRI As clsHTRI
    '=================================Altern================================
    Private X, Nalt1 As Short
    Private LungSt1(12) As Short
    Private i, Nalt As Short
    Private xAlt, yAlt As Short
    Private Titolo As String
    Private Testo, NewF As String
    Private n As Short
    Private iF2, j, iF1, ifl As Short
    Private NewF1, OldF1, Ext As String
    Private iVal, iCSh, Ninput As Short
    Private itp, u As String
    Private Ris As Short
    Private iNear, Origineprop As Short
    '===================================================================
    Private Quad, Quad1 As Single
    Private Fin, Scar As Single
    Private i1, i3, i4 As Short
    '==================================================================
    Private Testo1, Testo2 As String
    Private n1, n2 As Integer
    '===============================================================
    'Public AriaHTRI As String
    Public Function at1(ByVal i As Integer) As String
        Return Helpstringa(i)
    End Function
    Public Function FormatStringa(ByVal id As Integer) As String
        Dim Outstr As String
        Dim Nome As String = "stop" + GlobalRoutines.Str5Cifre(id)
        Outstr = rmHelpStrings.GetString(Nome)
        If Outstr Is Nothing Then Return (Nome)
        If Outstr.IndexOf("$"c) = 0 Then Return Outstr.Substring(1)
        Return Outstr '.Replace("|", vbCrLf)
    End Function
    Public Function Helpstringa(ByVal id As Integer) As String
        Dim Outstr As String
        Dim Nome As String = "str" + GlobalRoutines.Str5Cifre(id)
        Outstr = rmHelpStrings.GetString(Nome)
        If Outstr Is Nothing Then Return (Nome)
        If Outstr.IndexOf("$"c) = 0 Then Return Outstr.Substring(1)
        Return Outstr.Replace("|", vbCrLf)
    End Function
    Function CarPre(Optional ByRef NonConferma As Boolean = False) As Boolean
        Dim Testo As String
        Dim X As Short
        Dim Valido As Boolean
        Dim iErr As Short
        CarPre = True
        If job.Contratto.Length > 0 Then
            job1 = job
            ChiPre()
        End If
        'FileClose(1)
        If Not NonConferma Then
            Monitor.Motore.Inizio.Gancio = Monitor.Motore.Inizio.Workdir & "\DATI.TE1"
            If IO.File.Exists(Monitor.Motore.Inizio.Gancio) Then
                LeggiLav(Monitor.Motore.Inizio.Gancio)
            End If
            job.Comm.Ind(1).Data.Assieme = "$" : job.Comm.Ind(2).Data.Assieme = "0"
            If job.Contratto.Length > 0 Then
2101:           ApriPRV(Monitor.Motore.Inizio.Workdir & "\" & job.Contratto & ".PRV", actPRV, iErr)
                If iErr = -4 Or iErr = -3 Then
                    X = ChiaviMess.Messno
                    GoTo Lista
                End If
                If job.Contratto.Trim.Length = 0 Then
                    'Get #1, 1, Lav(0)
                    Stop
                    ' If Len(Dir(Monitor.Motore.Inizio.Workdir + "\" + Trim(job.contratto) + ".PRV")) > 0 Then Kill Monitor.Motore.Inizio.Workdir + "\" + Trim(job.contratto) + ".PRV"
                    job.Contratto = ""
                    'Put #1, 1, Lav(0)
                    CarPre = False
                    Exit Function
                End If
                Prendi()
                Testo = "        LAVORO CORRENTE:  " & vbCrLf & vbCrLf
                Testo = Testo & " Numero Preventivo: " & job.Contratto & "|"
                Testo = Testo & " Cliente          : " & job.Comm.Clie & "|"
                Testo = Testo & " Indirizzo        : " & job.Comm.Indirizzo & "|"
                Testo = Testo & " Luogo impianto   : " & job.Comm.Impianto & "|"
                '   Testo = Testo + at1(111) + job.contratto + vbCrLf
                '   Testo = Testo + at1(112) + Lav(0).Clie + vbCrLf
                '   Testo = Testo + at1(113) + Lav(0).Item + vbCrLf
                '   Testo = Testo + at1(114) + Lav(0).Prev + vbCrLf
                Testo = Monitor.Motore.Inizio.ConvertiCr(Testo)
                X = Monitor.Motore.Messaggio(Testo, ChiaviMess.MessYesNo Or ChiaviMess.MessQuestion Or ChiaviMess.MessHelpButton, "ISA - Caricamento di un progetto", RadiceHelp, IDH_HTRI_CARPROG)
            Else
                X = ChiaviMess.Messno
            End If
        Else
            X = ChiaviMess.MessSi
            job = job1
        End If
Lista:
        If X = ChiaviMess.MessSi Then
            Apert._Frames_4.Visible = True
            OpzCamini()
        Else
            job.Contratto = Space(1)
            Monitor.Motore.Mostra(myAssembly, 1)
        End If
        Apert._Frames_1.Visible = False
        If job.Contratto.Trim.Length = 0 Then CarPre = False : Exit Function
        FineCarica()
        Apert._Frames_1.Visible = True
        LeggiNITE = True
        Sommari(Valido)
        'If NumIt = 0 Then Stop: Exit Function
        FillTree(1)
        Apert._Frames_8.Visible = True
        LeggiNITE = False
        KUN = 0
        AbilitaMenu(True)
    End Function
    Friend Function CheckLicenza() As Boolean
        Dim DllDir As String = Monitor.Motore.Inizio.Basedir & "\Dll" 'Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData)
        Dim licenseFile As String = DllDir + "\LicensedApp\HTRI.lic"
        Dim sProvider As New EncryptedLicenseProvider
        Dim sLicense As EncryptedLicense = sProvider.GetLicense(LICENSE_PARAMETERS, licenseFile)
        If sLicense Is Nothing Then
            ' if there is no valid license then display the standard license install form 
            ' to allow the user to enter a license key
            '
            Dim licenseForm As New LicenseInstallForm
            sLicense = licenseForm.ShowDialog("ISA", "www.ssap.biz", licenseFile)
        End If

        ' if there is still no license check for evaluation mode
        '
        If sLicense Is Nothing Then

            ' use the EvaluationMonitor class to check whether the evaluation has expired
            '
            '' Dim monitor As New EvaluationMonitor("BreLock")

            ''If monitor.DaysInUse > 30 Or monitor.Invalid Then
            ''MessageBox.Show("Your evaluation has expired")
            ''Return False 'Application.Exit()
            ''Else
            ''MessageBox.Show(String.Format("You are on day {0} of your 30 day evaluation", Monitor.DaysInUse))
            ''Return True
            ''End If
            Return False
        Else
            Return True
        End If
    End Function
    Sub Apri1(ByRef File As String, ByRef iErr As Integer)
        objDatBase.Arch = File
        ApriPRV(Monitor.Motore.Inizio.Workdir + "\" + File + ".PRV", actPRV, iErr) '     APRIPR(-1, 0, Nome, iErr)
    End Sub
    Sub ExitAll()
        FineFlangia()
        ChiPre()
        FileClose()
        Monitor.Motore.Ammazza("HTRI")
        Monitor = Nothing
        objDatBase = Nothing
    End Sub
    Sub ChiPre()
        Dim Testo, File As String
        comm = ""
        Apert._Frames_8.Visible = False
        Apert.TreeView1.Nodes.Clear()
        Apert._Frames_1.Visible = False
        If job IsNot Nothing Then
            If job.Contratto.Length > 0 Then
                File = Monitor.Motore.Inizio.Workdir & "\" & job.Contratto & ".TE1"
                Try
                    job.Salva(File)
                Catch ex As Exception
                    Testo = Monitor.Motore.Inizio.ConvertiCr(GlobalRoutines.FormatS _
                    (Helpstringa(800), File, ex.Message))
                    MostraAiuto(IDH_GEN_ERRFILE, , Testo)
                    Exit Sub
                End Try
                ' CLOSPREV()
                AggStatusB()
                Apert._Frames_2.Visible = False
                Apert._Frames_3.Visible = False
                Apert._Frames_4.Visible = False
                Apert._Frames_5.Visible = False
                SalvaNITE()
                job.Contratto = Space(4)
                job.Comm.Ind(1).Data.Assieme = "$" : job.Comm.Ind(2).Data.Assieme = Chr(48)
            End If
        End If
        AbilitaMenu(False)
    End Sub
    'Sub Metti()
    ' Dim objPutGen As typPutGen
    ' Dim Buf, itp As String
    '     objPutGen.St1.St = job.Comm.Clie
    '     objPutGen.St2.St = job.Comm.Item
    '     objPutGen.St3.St = job.Comm.Comp
    '     objPutGen.St4.St = job.Comm.Clie
    '     objPutGen.St5.St = UNIMIS
    '     objPutGen.St6.St = Lingua
    '     PUTGEN(objPutGen)
    '     CLOSPREV()
    ' 'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto objDatBase.PutReco. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '     Buf = objDatBase.PutReco(1, 50, 4, DataPr, itp)
    ' 'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto objDatBase.PutReco. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '     Buf = objDatBase.PutReco(1, 62, 4, Protoc, itp)
    '     Apri(RTrim(job.Contratto))
    ' End Sub

    Sub Prendi()
        job.Comm.Clie = actPRV.NomeClien
        job.Comm.Indirizzo = actPRV.IndirClie
        job.Comm.Impianto = actPRV.LuogoImpi
    End Sub
    Public Sub FineCarica()
        If job.Contratto.Length = 0 Then Exit Sub
        If Monitor.Motore.Problem.Extension = ".MEC" Then Exit Sub
        job.Comm.Ind(1).Data.Assieme = "$"
        job.Comm.Ind(2).Data.Assieme = "0"
        Try
            job.Salva()
            job.Comm.SalvaCom(, True)
        Catch ex As Exception
            Monitor.Motore.Inizio.Gancio = RTrim(Monitor.Motore.Inizio.Workdir) & "\DATI.TE1"
            job.Salva(Monitor.Motore.Inizio.Gancio)
        Finally
            objDatBase.Arch = Monitor.Motore.Inizio.Workdir + "\" + job.Contratto + ".PRV"
        End Try
    End Sub
    Sub Deleta()
        Dim i As Short
        Dim Testo, NewF As String
        Dim Ext, NewF1 As String
        Dim Valido As Boolean
        SETRDIT(ItemnSt, Nrdit)
        'SEARCHA(Ialta)
        For i = 5 To 1 Step -1
            If actItem.indRecDati(i) > 0 Then
                SETALT(i)
                DELNOT()
                DELALT()
            End If
        Next
        DELITM()
        Testo = GlobalRoutines.myStr(CSng(Nrdit \ 2), 2, 0, True)
        If Left(Testo, 1) = Chr(32) Then Testo = Chr(64) & Right(Testo, 1)
        NewF = RTrim(Monitor.Motore.Inizio.Workdir) & Chr(92) & Left(job.Contratto, 4) & Testo & "*.*"
        NewF = Dir(NewF)
        Do
            If Len(NewF) > 0 Then
                ' If Right(NewF, 3) = "RA2" Then CLOSE4()
                IO.File.Delete(RTrim(Monitor.Motore.Inizio.Workdir) & Chr(92) & NewF)
                NewF = Dir()
            Else
                Exit Do
            End If
        Loop
        For i = Nrdit \ 2 + 1 To 99
            Testo = GlobalRoutines.Str2Cifre(i)
            NewF = RTrim(Monitor.Motore.Inizio.Workdir) & Chr(92) & Left(job.Contratto, 4) & Testo & ".*"
            'UPGRADE_WARNING: Dir ha un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
            NewF = Dir(NewF)
            Do
                If Len(NewF) > 0 Then
                    Ext = Right(NewF, Len(NewF) - InStr(NewF, "."))
                    If Len(Ext) = 2 Then Ext = Ext & Space(1) : NewF = NewF & Space(1)
                    Testo = GlobalRoutines.Str2Cifre(i - 1)
                    NewF1 = Left(NewF, Len(NewF) - 6) & Testo & Right(NewF, 4)
                    FileCopy(Trim(Monitor.Motore.Inizio.Workdir) & "\" & NewF, Trim(Monitor.Motore.Inizio.Workdir) & "\" & NewF1)
                    IO.File.Delete(Trim(Monitor.Motore.Inizio.Workdir) & "\" & NewF)
                    NewF = Dir()
                Else
                    Exit Do
                End If
            Loop
        Next
        Sommari(Valido)
        FillTree(1)
        SalvaNITE()
        Exit Sub
        'Verif:
        'With objDatBase
        '       Numit = .CVI(.Readreco(1, 43, 1))
        '       Numrec = .CVI(.Readreco(1, 45, 1))
        'End With
        'Return
    End Sub

    Sub EdiGen()
2300:   If Asc(job.Contratto) < 33 Then CarPre()
        If Asc(job.Contratto) < 33 Then Exit Sub
        Prendi()
2320:   If Not InputLav(False) Then ChiPre() : Exit Sub
        '2330:   Metti()
    End Sub

    Sub EliAlt()
        Dim Testo As String
        Dim X As Short
        Dim Curva As CondCurva = New CondCurva
        Curva.Initialize()
        'On Local Error GoTo ErrEliAlt
        If Asc(LTrim(job.Comm.Ind(2).Data.Assieme)) < 33 Or Val(job.Comm.Ind(2).Data.Assieme) = 0 Then
            Testo = RTrim(at1(46))
            '     Testo = "Si prega di aprire un'alternativa |"
            'Testo = Testo + "prima di tentare di eliminarla    |"
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.Inizio. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Testo = Monitor.Motore.Inizio.ConvertiCr(Testo)
            MsgBox(Testo, MsgBoxStyle.OkCancel + MsgBoxStyle.Information)
            Exit Sub
        End If
        Testo = "Prego confermare la cancellazione|"
        Testo = Testo & "dell'alternativa n°" & job.Comm.Ind(2).Data.Assieme
        Testo = Testo & "|dell'item " & Trim(job.Comm.Ind(1).Data.Assieme)
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.Inizio. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        X = MsgBox(Monitor.Motore.Inizio.ConvertiCr(Testo), MsgBoxStyle.YesNo, "ISA")
        If Not X = MsgBoxResult.Yes Then Exit Sub
        SETALT(Val(job.Comm.Ind(2).Data.Assieme))
        DELNOT()
        DELALT()
        ItemnSt = LTrim(job.Comm.Ind(1).Data.Assieme)
        SETRDIT(ItemnSt, Nrdit)
        '    m = Val(job.Comm.Ind(2).Data.Assieme)
        '    Testo = Globalroutines.Str2Cifre(Nrdit \ 2)
        '    OldF1 = RTrim$(Monitor.Motore.inizio.Workdir) + Chr$(92) + Left$(job.contratto, 4) + Testo + Right$(Str$(m), 1) + ".RA*"
        '    OldF1 = Dir$(OldF1)
        '    Do
        '      If Len(OldF1) = 0 Then Exit Do
        '190   Kill RTrim$(Monitor.Motore.inizio.Workdir) + Chr$(92) + OldF1
        '      OldF1 = Dir$
        '    Loop
        '    For m1 = m + 1 To 5
        '     OldF1 = RTrim$(Monitor.Motore.inizio.Workdir) + Chr$(92) + Left$(job.contratto, 4) + Testo + Right$(Str$(m1), 1) + ".RA*"
        '     OldF1 = Dir$(OldF1)
        '     If Len(OldF1) = 0 Then Exit For
        '     NewF1 = OldF1
        '     If Len(NewF1) > 0 Then Mid$(NewF1, InStr(NewF1, ".") - 1, 1) = Right$(Str$(m), 1)
        '   Do
        '     If Len(OldF1) = 0 Then Exit Do
        '         If Ext = "RA1" Or Ext = "RA2" Then
        '         iF1 = FreeFile
        '200      Open RTrim$(Monitor.Motore.inizio.Workdir) + Chr$(92) + OldF1 For Random As #iF1 Len = 18 * 4 + 1
        '         iF2 = FreeFile
        '210      Open RTrim$(Monitor.Motore.inizio.Workdir) + Chr$(92) + NewF1 For Random As #iF2 Len = 18 * 4 + 1
        '         j = 1
        '         Do
        '            Get #iF1, j, Curva
        '            If EOF(iF1) Then Exit Do
        '            Put #iF2, j, Curva
        '            j = j + 1
        '         Loop
        '         Else
        '         iF1 = FreeFile
        '220      Open RTrim$(Monitor.Motore.inizio.Workdir) + Chr$(92) + OldF1 For Input As #iF1
        '         iF2 = FreeFile
        '230      Open RTrim$(Monitor.Motore.inizio.Workdir) + Chr$(92) + NewF1 For Output As #iF2
        '         Do
        '           Line Input #iF1, Testo
        '           Print #iF2, Testo
        '           If EOF(iF1) Then Exit Do
        '         Loop
        '         End If
        '         Close #iF1
        '         Close #iF2
        '     OldF1 = Dir$
        '   Loop
        'Next
        'm1 = m1 - 1
        'If m1 > m Then
        '   OldF1 = RTrim$(Monitor.Motore.inizio.Workdir) + Chr$(92) + Left$(job.contratto, 4) + Testo + Right$(Str$(m1), 1) + ".RA*"
        '   OldF1 = Dir$(OldF1)
        '   Do
        '     If Len(OldF1) = 0 Then Exit Do
        '     Kill RTrim$(Monitor.Motore.inizio.Workdir) + Chr$(92) + OldF1
        '     OldF1 = Dir$
        '   Loop
        'End If
        job.Comm.Ind(2).Data.Assieme = Chr(48)
        Exit Sub
        'ErrEliAlt: Print "Errore in EliALt"; Err; Erl: End
    End Sub
    Sub ListaItems(ByRef nItems As Short, ByRef Answer As Short)
        Dim i, j As Short
        Dim u As String
        Dim Testo As String
        Dim icount As Short
        nItems = actPRV.Items.Count
        If nItems = 0 Then
            If Not Globale Then
                'Testo = RTrim$(at1(10) + at1(11))
                Testo = "In questo preventivo non e'  |"
                Testo = Testo & "stato inserito ancora nessun |"
                Testo = Testo & "Item. Vuoi inserirne uno ?   |"
                Testo = Monitor.Motore.Inizio.ConvertiCr(Testo)
                If Not Answer = -1 Then
                    Answer = MsgBox(Testo, MsgBoxStyle.YesNo + MsgBoxStyle.Information, "ISA")
                Else
                    Testo = Left(Testo, Len(Testo) - 24) & Space(23) ' + "|"
                    MsgBox(Testo, MsgBoxResult.Ok + MsgBoxStyle.Information, "ISA")
                End If
                nItems = 0
                Exit Sub
            Else
                Answer = MsgBoxResult.No
            End If
        Else
            For i = 1 To nItems
                Item(i) = CType(actPRV.Items(i), clsItem).Sigla.Trim 'Trim(objLstItm.Buffer(i).St)
                If Len(Item(i)) = 0 Then
                    Answer = MsgBoxResult.No
                    Exit Sub
                ElseIf Asc(Item(i)) < 32 Then
                    Answer = MsgBoxResult.No
                    Exit Sub
                End If
                Item(i) = Item(i).PadRight(20)
                If Trim(objDatBase.Arch) = Trim(job.Contratto) Then
                    For j = 1 To i - 1
                        If Item(j) = Item(i) Then
                            icount = icount + 1
                            Item(i) = (Item(i).Trim & Chr(64 + icount)).PadRight(20)
                            Testo = "Gli items n°" & Str(j) & " e n°" & Str(i) & " hanno "
                            Testo = Testo & "lo stesso nome (" & Trim(Item(j)) & ")." & vbCrLf
                            Testo = Testo & "Poiché ciò non è ammesso, il nome dell'item n°" & Str(i) & vbCrLf
                            Testo = Testo & "è stato cambiato in " & Item(i)
                            MsgBox(Testo, MsgBoxStyle.Information)
                            'CLOSPREV()
                            u = objDatBase.PutBasCh(2, 1, i, 1, Item(i), 0)
                            ' Apri(Trim(job.Contratto))
                        End If
                    Next
                End If
            Next
        End If
    End Sub
    Sub EliIte(Optional ByRef iItem As Short = 0)
        Dim X As Short
        Dim Fstr As String
        Dim i As Short
        Dim Testo As String
        Dim Valido As Boolean
        If Asc(job.Contratto) < 33 Then CarPre()
        If Asc(job.Contratto) < 33 Then Exit Sub
        '     a$ = "Prego confermare cancellazione|"
        'a$ = a$ + "item                          |"
        If iItem = 0 And ActivItem > 0 Then iItem = ActivItem
        If iItem > 0 Then
            Testo = "Prego confermare la cancellazione definitiva" & vbCrLf
            Testo = Testo & "dell'item " & Trim(Item(iItem))
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.Inizio. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Testo = Monitor.Motore.Inizio.ConvertiCr(Testo)
            X = MsgBox(Testo, MsgBoxStyle.YesNo, "ISA")
            If Not X = MsgBoxResult.Yes Then Exit Sub
        End If
        job.Comm.Ind(2).Data.Assieme = Chr(48)
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.Inizio. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        Fstr = RTrim(Monitor.Motore.Inizio.Workdir) & Chr(92) & RTrim(job.Contratto) & ".STR"
        'UPGRADE_WARNING: Dir ha un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
        If Len(Dir(Fstr)) > 0 Then IO.File.Delete(Fstr)
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.Inizio. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        Fstr = RTrim(Monitor.Motore.Inizio.Workdir) & Chr(92) & RTrim(job.Contratto) & ".SUM"
        'UPGRADE_WARNING: Dir ha un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
        If Len(Dir(Fstr)) > 0 Then IO.File.Delete(Fstr)
        If iItem = 0 Then
            ListaItems(i, -1)
            If i = 0 Then Exit Sub
            X = Monitor.Motore.Quale(i, "Elimimazione Item", Item, "", 0)
            Select Case X
                Case 0
                    Exit Sub
                Case Else
                    ItemnSt = Item(X)
            End Select
        Else
            ItemnSt = Item(iItem)
        End If
        Deleta()
        Sommari(Valido)
        FillTree(1)
        job.Comm.Ind(1).Data.Assieme = Chr(36)
        job.Comm.Ind(2).Data.Assieme = Chr(48)
        job.Salva(Monitor.Motore.Inizio.Workdir & "\" & job.Contratto & ".TE1")
    End Sub

    Sub EliPre()
        Dim NomeFile, Testo As String
        Monitor.Motore.Inizio.Gancio = RTrim(Monitor.Motore.Inizio.Workdir) & "\DATI.TE1"
        LeggiLav(Monitor.Motore.Inizio.Gancio)
        NomeFile = Monitor.Motore.ScegliFile("Eliminazione lavoro", RTrim(Monitor.Motore.Inizio.Workdir), "PRV", "", True)
        If Len(NomeFile) = 0 Then Exit Sub
        If Left(NomeFile, 4) = RTrim(job.Contratto) Then
            'a$ = " Mi rifiuto di cancellare | la distinta corrente! |"
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.Inizio. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Testo = Monitor.Motore.Inizio.ConvertiCr(at1(38))
            MsgBox(Testo, MsgBoxStyle.Information)
            Exit Sub
        End If
        LeggiLav(NomeFile)
        SottoEliPre(NomeFile)
    End Sub
    Function InputLav(ByRef Nuovo As Boolean) As Boolean
        InputLav = False
        Dim frmnuovolav As New nuovoLav
        frmnuovolav.Nuovo = Nuovo
        If Not Nuovo Then
            With frmnuovolav
                ._Text1_0.Text = job.Contratto
                ._Text1_1.Text = job.Comm.Clie
                ._Text1_2.Text = job.Comm.Item
                ._Text1_3.Text = job.Comm.Comp
                ._Text1_4.Text = RifCli
                Select Case actPRV.UnitaMisu
                    Case "ME" : ._Combo1_5.SelectedIndex = 1
                    Case "BR" : ._Combo1_5.SelectedIndex = 2
                    Case Else : ._Combo1_5.SelectedIndex = 0
                End Select
                Select Case actPRV.Linguaggi
                    Case "IN" : ._Combo1_6.SelectedIndex = 1
                    Case "FR" : ._Combo1_6.SelectedIndex = 2
                    Case Else : ._Combo1_6.SelectedIndex = 0
                End Select
                ._Text1_7.Text = actPRV.NumerProt
                If actPRV.DataPreve.Trim = "" Then actPRV.DataPreve = Format(Today, "dd/MM/yy")
                .MaskEdBox1.Text = actPRV.DataPreve
            End With
        End If
        frmnuovolav.ShowDialog()
        If frmnuovolav.Canceled Then
            frmnuovolav.Close()
            frmnuovolav.Dispose()
            Exit Function
        End If
        InputLav = True
        If Nuovo Then job.Contratto = frmnuovolav._Text1_0.Text
        With frmnuovolav
            job.Comm.Clie = ._Text1_1.Text
            job.Comm.Item = ._Text1_2.Text
            job.Comm.Comp = ._Text1_3.Text
            RifCli = ._Text1_4.Text
            actPRV.UnitaMisu = ._Combo1_5.Text
            actPRV.Linguaggi = ._Combo1_6.Text
            actPRV.NumerProt = ._Text1_7.Text
            actPRV.DataPreve = .MaskEdBox1.Text
            .Close()
            .Dispose()
        End With
        frmnuovolav = Nothing
    End Function

    Sub NuoPre()
        Dim Testo, NomeFile, iiStr As String
        Dim ii As Short
        Dim X, iC As Short
        Dim Nome As String
        Dim ifl, ifl1 As Short
        Dim Valido As Boolean
        Dim iErr As Integer
        ChiPre()
        Try
            Monitor.Motore.Inizio.Gancio = RTrim(Monitor.Motore.Inizio.Workdir) & "\DATI.TE1"
            'FileOpen(1, Monitor.Motore.Inizio.Gancio, OpenMode.Random, , , Len(Lav(0)))
            If Asc(job.Contratto) > 32 Then
                '      Testo = RTrim$(at1(14))
                '     Testo = "Si prega di chiudere il preventivo|"
                'Testo = Testo + "corrente prima di aprirne un'altro|"
                'x = Alert(2, Testo, 8, 11, 13, 64, at1(73), Space$(0), Space$(0))
                ChiPre()
            End If
            If Not InputLav(True) Then Exit Sub
            NomeFile = Monitor.Motore.Inizio.Workdir & "\" & job.Contratto & ".PRV"
            If IO.File.Exists(NomeFile) > 0 Then
                '     Testo = " Esiste gia' una preventivo" + job.contratto + " |"
                'Testo = Testo + " Cambia il nuovo o cancella il vecchio.     |"
                Testo = Monitor.Motore.Inizio.ConvertiCr(at1(39) & job.Contratto & at1(40))
                MsgBox(Testo, MsgBoxStyle.Information)
                Exit Sub
            End If
            '---------------------modificare
            'Testo = " Vuoi utilizzare un preventivo| esistente da modificare ? |"
            Testo = Monitor.Motore.Inizio.ConvertiCr(at1(41))
            X = MsgBox(Testo, MsgBoxStyle.Question + MsgBoxStyle.YesNo, "ISA")
            If X = MsgBoxResult.Yes Then
                NomeFile = Monitor.Motore.ScegliFile("Scelta lavoro esistente", RTrim(Monitor.Motore.Inizio.Workdir), "PRV", "", True)
                If Len(NomeFile) > 0 Then
                    actPRV = New clsPRV(Monitor.Motore.Inizio.Workdir & "\" & NomeFile)
                    ApriPRV(Monitor.Motore.Inizio.Workdir & "\" & NomeFile, actPRV, iErr)
                    SalvaPRVas(Monitor.Motore.Inizio.Workdir & "\" & job.Contratto & ".PRV", actPRV)
                    NomeFile = Left(NomeFile, Len(NomeFile) - 4)
                    For ii = 1 To 3
                        iiStr = Right(Str(ii), 1)
                        Nome = Dir(NomeFile & "*.RA" & iiStr)
                        Do While Len(Nome) > 0
                            ifl = FreeFile()
                            If ii = 1 Then
                                FileOpen(ifl, RTrim(Monitor.Motore.Inizio.Workdir) & Chr(92) & Nome, OpenMode.Input)
                                ifl1 = FreeFile()
                                FileOpen(ifl1, RTrim(Monitor.Motore.Inizio.Workdir) & Chr(92) & job.Contratto & Left(Right(Nome, 7), 3) & ".RA" & iiStr, OpenMode.Output)
                                Do
                                    Testo = LineInput(ifl)
                                    PrintLine(ifl1, Testo)
                                    If EOF(ifl) Then Exit Do
                                Loop
                            Else
                                FileOpen(ifl, RTrim(Monitor.Motore.Inizio.Workdir) & Chr(92) & Nome, OpenMode.Binary, OpenAccess.Read)
                                ifl1 = FreeFile()
                                FileOpen(ifl1, RTrim(Monitor.Motore.Inizio.Workdir) & Chr(92) & job.Contratto & Left(Right(Nome, 7), 3) & ".RA" & iiStr, OpenMode.Binary, OpenAccess.Write)
                                iC = 1
                                Do
                                    Testo = InputString(ifl, 14 * 18 + 1)
                                    FilePut(ifl1, Testo, (iC - 1) * 128 + 1)
                                    iC = iC + 1
                                    If EOF(ifl) Then Exit Do
                                Loop
                            End If
                            FileClose(ifl) : FileClose(ifl1)
                            Nome = Dir()
                        Loop
                    Next ii
                End If
            End If
            ' Apri(RTrim(job.Contratto), True)
            'Metti()
            job.Salva()
            'FilePut(1, Lav(0), 1)
            objDatBase.Arch = job.Contratto
            LeggiNITE = False
            Sommari(Valido)
            FillTree(1)
            Apert._Frames_8.Visible = True
            Apert._Frames_1.Visible = True
            KUN = 0
            AbilitaMenu(True)
        Catch ex As Exception
            MessageBox.Show(ex.Message + vbCrLf + ex.StackTrace)
        End Try
    End Sub

    Public Function CopyAltro(ByRef Nome As String) As Boolean
        Dim iErr As Integer
        CopyAltro = False
        Apri1(Nome, iErr)
        COPIA(ItemvSt, ItemnSt)
        job.Comm.Ind(2).Data.Assieme = Str(1)
        'ifl = FreeFile()
        'FileOpen(ifl, RTrim(Monitor.Motore.Inizio.Workdir) & Chr(92) & Nome & ".TE1", OpenMode.Random, , , Len(Lav(0)))
        Dim ContrFile As String = Monitor.Motore.Inizio.Workdir & "\" & Nome & ".TE1"
        job1 = Monitor.Motore.Retrievejob(Nome, ContrFile)
        If Not job1 Is Nothing Then
            '  If LOF(ifl) > 0 Then
            'FileGet(ifl, Lav(1), 1)
            job1.Comm.Ind(1).Data.Assieme = job.Comm.Ind(1).Data.Assieme
            job1.Comm.Ind(2).Data.Assieme = job.Comm.Ind(2).Data.Assieme
        Else
            job1 = job
        End If
        '        FileClose(ifl)
        job1.Contratto = Nome
        SupportFiles(1)
        CopyAltro = True
    End Function

    Public Function CopyIte(ByRef i As Short) As Boolean
        Dim Testo As String
        Dim X As Short
        CopyIte = False
        '  Testo = RTrim$(at1(13))
        Testo = "Vuoi copiare i dati da un altro|"
        Testo = Testo & "item per poi editarli?         |"
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.Inizio. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        Testo = Monitor.Motore.Inizio.ConvertiCr(Testo)
        X = MsgBox(Testo, MsgBoxStyle.YesNo + MsgBoxStyle.Question)
        '                 a$ = "Vuoi copiare i dati da un altro|"
        '            a$ = a$ + "item per poi editarli?         |"
        If X = MsgBoxResult.Yes Then
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.Quale. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            X = Monitor.Motore.Quale(i, "Items da copiare", Item, "", 0)
            ItemvSt = Item(X)
            'SETRDIT Itemv, j
            'j = j \ 2
            'l = ActivAlt(j)
            'If l = 0 Then l = 1
            'Aster = Trim(objDatBase.DatBase(4, 19, j, l, itp, 0))
            'If Aster = "*" Then
            '             Testo = "Hai selezionato un item montato|"
            '     Testo = Testo + "su ventilatore a comune.|"
            '     Testo = Testo + "La copia non sarà effettuata.|"
            '     Testo = Monitor.Motore.Inizio.ConvertiCr(Testo)
            '     MsgBox Testo, vbInformation
            '     CopyIte = True
            '     Exit Function
            'End If
            COPIA(ItemvSt, ItemnSt)
            job.Comm.Ind(2).Data.Assieme = Str(1)
            job1 = job
            SupportFiles(0)
        End If
        CopyIte = True
    End Function
    Public Function EdiIte() As Short
        Dim Testo As String
        Dim Esito As Boolean
        Dim X As Short
        Dim i, Answer As Short
        Dim Valido As Boolean
        Try
            EdiIte = 1
            '-----Tit$(1) = "Sigla Item : "
            If Asc(job.Contratto) < 33 Then CarPre()
            If Asc(job.Contratto) < 33 Then Exit Function
            If Asc(job.Comm.Ind(1).Data.Assieme) > 32 And Left(job.Comm.Ind(1).Data.Assieme, 1) <> Chr(36) Then
                Testo = "Vuoi lavorare sull'item corrente (Si)" & vbCrLf
                Testo = Testo & "(" & RTrim(job.Comm.Ind(1).Data.Assieme) & ")" & ", o vuoi cambiare item (No)?" & vbCrLf
                'Testo = Monitor.Motore.inizio.ConvertiCr(at1(36))
                X = MsgBox(Testo, MsgBoxStyle.Question + MsgBoxStyle.YesNo)
50:             If X = MsgBoxResult.Yes Then
                    '-----      Risp$(1) = job.Comm.Ind(1).Data.Assieme
                    '-----      Help$ = at1(56)
                    '-----      Do
                    '-----      Esito = Cartigli(1, 1, "Item attuale", Help$, Tit$(), Risp$())
                    '-----      Risp$(1) = LTrim$(Risp$(1))
                    '-----      Loop Until Len(Risp$(1)) > 0 And Asc(Risp$(1)) > 32
                    '-----      job.Comm.Ind(1).Data.Assieme = Risp$(1)
                    ItemnSt = job.Comm.Ind(1).Data.Assieme 'Item(i + 1)
                    ' Nrdit = -2
                    Esito = EditEdit()
                    Exit Function
                End If
            End If
            job.Comm.Ind(2).Data.Assieme = Chr(48)
            If Len(Dir(Monitor.Motore.Inizio.DiscoTem & RTrim(job.Contratto))) > 0 Then IO.File.Delete(Monitor.Motore.Inizio.DiscoTem & RTrim(job.Contratto))
            ListaItems(i, Answer)
            If i = 0 Then
                If Answer = MsgBoxResult.No Then Exit Function
                InputDaBanco = False
70:             Esito = InserIte(i)
            Else
                Item(i + 1) = "Nuovo Item"
                X = Monitor.Motore.Quale(i + 1, "Scelta Item", Item, "", 1)
                Select Case X
                    Case 0
                        EdiIte = 0 : Exit Function
                    Case i + 1
                        InputDaBanco = False
80:                     Esito = InserIte(i)
                        If Esito Then
                            Sommari(Valido)
                            FillTree(1)
                        End If
                    Case Else
81:                     job.Comm.Ind(1).Data.Assieme = Item(X)
                        ItemnSt = Item(X)
                        Esito = EditEdit()
                End Select
            End If
            job.Comm.IndG = Nrdit \ 2
        Catch e As Exception
            MessageBox.Show(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Function

    Public Function EditEdit() As Boolean
        On Error GoTo ErrEE
        Dim j, i, ifl As Short
        'ReDim iC(13, 4)
        Dim ifl2 As Short
        EditEdit = False
        '        FilePut(1, Lav(0), 1)
        '1999:   ifl = FreeFile()
        'FileOpen(ifl, RTrim(Monitor.Motore.Inizio.Archdir) & "\HTRI10.DAT", OpenMode.Input, , OpenShare.Shared)
        'For i = 1 To 7 : Input(ifl, LungStx(i)) : Next
        'For j = 1 To 4 : For i = 1 To 13 : Input(ifl, iC(i, j)) : Next
        'Next j
        'FileClose(ifl)
        ItemnSt = LTrim(job.Comm.Ind(1).Data.Assieme)
2000:   SETRDIT(ItemnSt, Nrdit)
        RISCRI(0, 0, Rispv)
        Apert.Enabled = False
        FaseDati = 1
        For j = 1 To 4
            Prepara(j)
        Next j
        Do
            System.Windows.Forms.Application.DoEvents()
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        Loop Until Monitor.Motore.InputForms Is Nothing
        EditEdit = True
        Exit Function
ErrEE:  MsgBox("Err EditEdit" & ErrorToString() & Str(Erl())) ': End
        Resume  ' Next
    End Function

    Public Function InserIte(ByRef i As Short) As Boolean
37:     Dim LungSt1(12) As Short
        Dim x1 As Short
        Dim Testo, NomeFile As String
        Dim Nome As String
        Dim X, ii As Short
        Dim Fstr, DefItem, itp As String
        Dim Aster, u As String
        Dim NumItCom As Short
        Dim Esito As Boolean
        Dim Bank As String
        Dim Nrditn, j As Short
        Dim iErr As Integer
        ReDim Risp(30)
        ReDim Dom(30)
        Try
            InserIte = False
            Testo = "Vuoi importare il nuovo item da|"
            Testo = Testo & "un altro progetto ?"
            Testo = Monitor.Motore.Inizio.ConvertiCr(Testo)
            x1 = MsgBox(Testo, MsgBoxStyle.Question + MsgBoxStyle.YesNoCancel, "ISA - Inserimento Unità/Item")
            If x1 = MsgBoxResult.Cancel Then Exit Function
            If x1 = MsgBoxResult.Yes Then
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
                NomeFile = Monitor.Motore.ScegliFile("Scelta progetto per l'importazione", RTrim(Monitor.Motore.Inizio.Workdir), "PRV", "", True)
                If Len(NomeFile) = 0 Then x1 = MsgBoxResult.No : GoTo Cont
                Nome = Left(NomeFile, Len(NomeFile) - 4)
                Apri1(Nome, iErr)
                NewList(ii, x1)
                If ii = 0 Then
                    Testo = "Nel progetto scelto per l'importazione|"
                    Testo = Testo & "non ci sono items "
                    Testo = Monitor.Motore.Inizio.ConvertiCr(Testo)
                    MsgBox(Testo, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "ISA")
                    x1 = MsgBoxResult.No : GoTo Cont 'Exit Function
                End If
                X = Monitor.Motore.Quale(ii, "Item da copiare", Dom, "", 1)
                If X = 0 Then x1 = MsgBoxResult.No : GoTo Cont
                ItemvSt = Dom(X)
                '----Risp$(1) = Dom(x)
                DefItem = Dom(X)
                SETRDIT(ItemvSt, Nrditv)
                ' CLOSPREV() 'chiude il secondo PRV (IINP=77)
                objDatBase.Arch = Trim(job.Contratto)
            Else
Cont:           DefItem = Space(20)
                ii = i
            End If
            '----Help$ = at1(56)
            DefItem = InputBox("Nuovo Item", "", DefItem)
            If Len(Trim(DefItem)) = 0 Then Exit Function
            DefItem = DefItem.PadRight(20)
            ItemnSt = DefItem
            SETRDIT(ItemnSt, Nrdit)
            If Nrdit > 0 Then
                Testo = "L'item " & RTrim(DefItem) & " esiste già." & vbCrLf
                Testo = Testo & "Vuoi editarlo?"
                X = MsgBox(Testo, MsgBoxStyle.Question + MsgBoxStyle.YesNo)
                If X = MsgBoxResult.No Then Exit Function
            Else
                Fstr = RTrim(Monitor.Motore.Inizio.Workdir) & Chr(92) & RTrim(job.Contratto) & ".STR"
                IO.File.Delete(Fstr)
                Fstr = RTrim(Monitor.Motore.Inizio.Workdir) & Chr(92) & RTrim(job.Contratto) & ".SUM"
                IO.File.Delete(Fstr)
            End If
            job.Comm.Ind(1).Data.Assieme = DefItem
            ItemnSt = DefItem
            If Nrdit = 0 Then
                If ii > 0 Then
                    If x1 = MsgBoxResult.Yes Then
                        job1.Contratto = job.Contratto
                        job.Contratto = Nome
                        objDatBase.Arch = Nome
                        'Aster = Trim(objDatBase.DatBase(4, 19, Nrditv \ 2, 1, itp, 0))
                        'If Aster = "*" Then
                        '   NumPrim = objDatBase.CVI(objDatBase.DatBase(4, 36, Nrditv \ 2, 1, itp$, 0)) \ 2
                        '   If NumPrim <> Nrditv \ 2 Then
                        '      Testo = Monitor.Motore.Inizio.ConvertiCr("Operazione rifiutata in quanto|trattasi di item schiavo")
                        '      MsgBox Testo, vbExclamation + vbOKOnly
                        '      job.contratto = Lav(1).Arch
                        '      objDatBase.Arch = Trim(job.contratto)
                        '      Exit Function
                        '   Else
                        '      NumItCom = objDatBase.CVI(objDatBase.DatBase(4, 35, Nrditv \ 2, 1, itp, 0))
                        '      For j = 1 To NumItCom
                        '        LungSt1(j) = objDatBase.CVI(objDatBase.DatBase(4, 35 + j, Nrditv \ 2, 1, itp, 0)) \ 2
                        '      Next
                        '   End If
                        'End If
                        job.Contratto = job1.Contratto
                        objDatBase.Arch = job.Contratto
30:                     NEWITM(ItemnSt)
32:                     Esito = CopyAltro(Nome)
                        objDatBase.Arch = job.Contratto
                    Else
                        NewList(ii, x1)
                        NEWITM(ItemnSt)
38:                     Esito = CopyIte(ii)
                    End If
                Else
                    NEWITM(ItemnSt)
                End If
            Else
                Exit Function
            End If
39:         Esito = EditEdit()
            If Aster = "*" Then
                '            CLOSPREV()
                Bank = objDatBase.DatBase(2, 2, Nrditn \ 2, 1, itp, 0)
                For j = 2 To NumItCom
                    u = objDatBase.PutBasCh(2, 2, Nrditn \ 2 + j - 1, 1, Bank, 0)
                Next
                '           Apri(Trim(job.Contratto))
            End If
            'Sommari Valido
            FillTree(1)
            SalvaNITE()
            InserIte = True
        Catch ex As Exception
            MessageBox.Show(ex.Message + vbCrLf + ex.StackTrace)
        End Try
    End Function
    Private Sub NewList(ByVal ii As Integer, ByVal x1 As MsgBoxResult)
        Dim j As Integer
        ListaItems(ii, -1)
        If ii = 0 Then
            Exit Sub
        Else
            For j = 1 To ii
                If x1 = MsgBoxResult.Yes Then
                    Dom(j) = Item(j)
                Else
                    'Item(i)=Item(i)
                End If
            Next
        End If
    End Sub
    Public Sub AggStatusB()
        Dim Arch As String
        Arch = job.Contratto
        If Arch = "" Then Arch = "Nessuno"
        With Apert.StatusBar1
            .Items.Item(0).Text = "Area di lavoro: " & RTrim(Monitor.Motore.Inizio.Workdir)
            .Items.Item(1).Text = "Prev.: " & Arch
            If job.Comm.Ind(1).Data.Assieme.Length > 0 Then
                If Left(job.Comm.Ind(1).Data.Assieme, 1) <> "$" And job.Contratto.Length Then
                    .Items.Item(2).Text = "Item: " & RTrim(LTrim(job.Comm.Ind(1).Data.Assieme))
                Else
                    .Items.Item(2).Text = "Item: "
                End If
            End If
            If Val(job.Comm.Ind(2).Data.Assieme) > 0 And job.Contratto.Length > 0 Then
                .Items.Item(3).Text = "Alternativa:" & Str(Val(job.Comm.Ind(2).Data.Assieme))
            Else
                .Items.Item(3).Text = "Alternativa:"
            End If
        End With
    End Sub
    Public Sub LeggiLav(ByVal ContrFile As String)
        Try
            job = Monitor.Motore.Retrievejob("", ContrFile)
            objDatBase.Arch = job.Contratto
            Monitor.Motore.Problem.ClientPlant = job.Comm.Clie
        Catch e As Exception
        End Try
    End Sub
    Sub SupportFiles(ByRef Mode As Short)
        Dim Testo, NewF1 As String
        Dim M As Short
        Dim Testob As String
        Dim NewF2 As String
        Dim Origineprop As Short
        Dim u, itp As String
        Dim iErr As Integer
        SETRDIT(ItemvSt, Nrditv)
        SETRDIT(ItemnSt, Nrdit)
        M = Val(job1.Comm.Ind(2).Data.Assieme) 'N. alternativa
        If M = 0 Then
            Testo = GlobalRoutines.FormatS(Monitor.Motore.Inizio.ConvertiCr(Helpstringa(1098)), "SupportFiles")
            MostraAiuto(IDH_HTRI_ALTNONATT, ChiaviMess.MessCritical Or ChiaviMess.MessOkOnly Or ChiaviMess.MessHelpButton, Testo)
            Exit Sub
        End If
        Origineprop = objDatBase.CVI(objDatBase.DatBase(4, 74, Nrditv \ 2, M, itp, 0))
        If Origineprop < 0 Or Origineprop > 2 Then Origineprop = 2
        u = objDatBase.PutBasCh(4, 74, Nrdit \ 2, 1, objDatBase.MKI(Origineprop), 0)
        If Mode <> 1 Then ApriPRV(Monitor.Motore.Inizio.Workdir & "\" & job.Contratto & ".PRV", actPRV, iErr)
        Testo = GlobalRoutines.Str2Cifre(Nrditv \ 2) + Trim(Str(M))
        Testob = GlobalRoutines.Str2Cifre(Nrdit \ 2) + "1"
        NewF1 = Monitor.Motore.Inizio.Workdir & "\" & job.Contratto & Testo & ".RA1"
        NewF2 = RTrim(Monitor.Motore.Inizio.Workdir) & Chr(92) & job.Contratto & Testob & ".RA1"
        If IO.File.Exists(NewF1) Then FileCopy(NewF1, NewF2)
        NewF1 = Trim(Monitor.Motore.Inizio.Workdir) & "\" & job1.Contratto & Testo & ".WLD"
        NewF2 = RTrim(Monitor.Motore.Inizio.Workdir) & Chr(92) & job.Contratto & Testob & ".WLD"
        If IO.File.Exists(NewF1) Then FileCopy(NewF1, NewF2)
    End Sub
    Sub Bilancio()
        Dim n, iErr As Short
        Dim Testo As String
        Dim NewF As String
        Dim iF3, iF4 As Short
        If Val(job.Comm.Ind(2).Data.Assieme) = 0 Then
            NonMostrareAlt = True
            altern(0)
        End If
        job.Comm.peso = 0.0!
        n = Val(job.Comm.Ind(2).Data.Assieme)
        ItemnSt = LTrim(job.Comm.Ind(1).Data.Assieme)
        SETRDIT(ItemnSt, Nrdit)
        IO.File.Delete(Monitor.Motore.Inizio.DiscoTem & RTrim(job.Contratto))
        SETALT(n)
        Call HTRI3(n, iErr)
        If iErr = 100 Then
            MostraAiuto(IDH_THER_PRANDTL)
            Exit Sub
        End If
        Testo = GlobalRoutines.myStr(CSng(Nrdit \ 2), 2, 0, True)
        If Left(Testo, 1) = Chr(32) Then Testo = Chr(48) & Right(Testo, 1)
        NewF = RTrim(Monitor.Motore.Inizio.Workdir) & Chr(92) & Left(job.Contratto, 4) & Testo & ".BIL"
        If Len(Dir(NewF)) > 0 Then IO.File.Delete(NewF)
        iF3 = FreeFile()
        FileOpen(iF3, Monitor.Motore.Inizio.DiscoTem & RTrim(job.Contratto), OpenMode.Input)
        iF4 = FreeFile()
        FileOpen(iF4, NewF, OpenMode.Output)
        Do
            Testo = LineInput(iF3)
            PrintLine(iF4, Testo)
            If EOF(iF3) Then Exit Do
        Loop
        FileClose(iF3) : FileClose(iF4)
        Shell("NotePad " & NewF, AppWinStyle.NormalFocus)
    End Sub

    Sub DatiCos()
        Dim n, iErr As Short
        Dim Diff As Single
        'On Error Resume Next
        If (Asc(LTrim(job.Comm.Ind(2).Data.Assieme)) < 33 Or Val(job.Comm.Ind(2).Data.Assieme) < 1) Then
            NonMostrareAlt = True
            altern(0)
            Do
                System.Windows.Forms.Application.DoEvents()
            Loop Until Monitor.Motore.InputForms Is Nothing
        End If
        If Asc(LTrim(job.Comm.Ind(2).Data.Assieme)) < 33 Or Val(job.Comm.Ind(2).Data.Assieme) < 1 Then Exit Sub
201:    n = Val(job.Comm.Ind(2).Data.Assieme)
        ItemnSt = LTrim(job.Comm.Ind(1).Data.Assieme)
202:    SETRDIT(ItemnSt, Nrdit)
        IO.File.Delete(Monitor.Motore.Inizio.DiscoTem & RTrim(job.Contratto))
        SETALT(n)
203:    If Not UpmHtr Then Call HTRI3(n, iErr)
        If iErr = 100 Then
            MostraAiuto(IDH_THER_PRANDTL)
        End If
        If UpmHtr And AddDistinta = 4 Then
            DatiCos4(0, 0)
            DatiCos5(0, 0)
        ElseIf UpmHtr Then
            DatiCos4(0, 0)
            DatiCos5(1, 0)
            Do
                System.Windows.Forms.Application.DoEvents()
            Loop Until Monitor.Motore.InputForms Is Nothing
        ElseIf AddDistinta = 305 Then
            Exit Sub
        ElseIf AddDistinta = 2 Then
            DatiCos4(0, 0)
            Do
                System.Windows.Forms.Application.DoEvents()
            Loop Until Monitor.Motore.InputForms Is Nothing
            If OKDati Then
                DatiCos5(0, 0)
                Do
                    System.Windows.Forms.Application.DoEvents()
                Loop Until Monitor.Motore.InputForms Is Nothing
            End If
            If OKDati Then
                DatiCos6(0, 0)
                Do
                    System.Windows.Forms.Application.DoEvents()
                Loop Until Monitor.Motore.InputForms Is Nothing
            End If
            If OKDati Then Solve(0, Diff)
            If Not OKDati Then
                Apert.ListView2.Items.Add("Calcolo non completato.")
            End If
        Else
            DatiCos4(1, 0)
            Do
                System.Windows.Forms.Application.DoEvents()
            Loop Until Monitor.Motore.InputForms Is Nothing
            If Not OKDati Then Exit Sub
            DatiCos5(1, 0)
            Do
                System.Windows.Forms.Application.DoEvents()
            Loop Until Monitor.Motore.InputForms Is Nothing
            If Not OKDati Then Exit Sub
            DatiCos6(1, 0)
        End If
    End Sub
    Sub DatiFun()
        ReDim Valor(130)
        ReDim LungStt(200)
        ReDim Risp(130)
        ReDim Dom(65)
        ReDim Archiv(65)
        ReDim Aiuto(65)
        Dim Testo, NewF As String
        If Not Presente() Then Exit Sub
        Testo = GlobalRoutines.myStr(CSng(Nrdit \ 2), 2, 0, True)
        If Left(Testo, 1) = Chr(32) Then Testo = Chr(48) & Right(Testo, 1)
        NewF = Monitor.Motore.Inizio.Workdir & "\" & job.Contratto & Testo & ".FUN"
        If Len(Dir(NewF)) > 0 Then IO.File.Delete(NewF)
        ItemnSt = LTrim(job.Comm.Ind(1).Data.Assieme)
        job.Comm.peso = 0.0!
        SETRDIT(ItemnSt, Nrdit)
        HTRI1(-1) 'se >0 riversa gli estremi
        HTRI12(objDatiFun, 0)
        FaseDati = 2
        Apert.Enabled = False
        SottoDatiFun(0)
    End Sub

    Function Presente() As Boolean
        Dim Testo As String
        Presente = True
        If Asc(job.Contratto) < 33 Then
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.Inizio. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Testo = Monitor.Motore.Inizio.ConvertiCr(RTrim(at1(8)))
            '     Testo = "Si prega di aprire  un  preventivo|"
            'Testo = Testo + "prima di editarne il contenuto !  |"
            MsgBox(Testo, MsgBoxStyle.Information)
            Presente = False
            Exit Function
        End If
        If Asc(LTrim(job.Comm.Ind(1).Data.Assieme)) < 33 Or Left(LTrim(job.Comm.Ind(1).Data.Assieme), 1) = "$" Then
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.Inizio. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Testo = Monitor.Motore.Inizio.ConvertiCr(RTrim(at1(9)))
            '     Testo = "Si prega di aprire  un  item prima|"
            'Testo = Testo + "di inserirvi i dati costruttivi!  |"
            MsgBox(Testo, MsgBoxStyle.Information)
            Presente = False
            Exit Function
        End If
    End Function
    Sub Readzone(ByRef NewF As String)
        Dim iF2 As Short
        'UPGRADE_WARNING: Dir ha un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
        If Len(Dir(NewF)) = 0 Then Exit Sub
        iF2 = FreeFile()
        FileOpen(iF2, NewF, OpenMode.Binary)
        FileGet(iF2, ProblWLD)
        FileClose(iF2)
    End Sub
    Sub SaveZone()
        Dim Testo, NewF As String
        Dim n, iF2 As Short
        n = Val(job.Comm.Ind(2).Data.Assieme)
        If n = 0 Then
            Testo = GlobalRoutines.FormatS(Monitor.Motore.Inizio.ConvertiCr(Helpstringa(1098)), "SaveZone")
            MostraAiuto(IDH_HTRI_ALTNONATT, ChiaviMess.MessCritical Or ChiaviMess.MessOkOnly Or ChiaviMess.MessHelpButton, Testo)
            Exit Sub
        End If
        Testo = GlobalRoutines.Str2Cifre(Nrdit \ 2) + Trim(Str(n))
        NewF = RTrim(Monitor.Motore.Inizio.Workdir) & Chr(92) & Left(job.Contratto, 4) & Testo & ".WLD"
        iF2 = FreeFile()
        FileOpen(iF2, NewF, OpenMode.Binary)
        FilePut(iF2, ProblWLD)
        FileClose(iF2)
    End Sub
    Sub altern(ByRef Mode As Integer, Optional ByRef Nuovo As Boolean = False)
        ReDim Dom(2), Risp(2), Archiv(12), Help(12), Valor(65)
        NuovaAlt = False
        If Len(Trim(job.Comm.Ind(1).Data.Assieme)) = 0 Then
            Prima()
        ElseIf Asc(LTrim(job.Comm.Ind(1).Data.Assieme)) < 33 Or Left(LTrim(job.Comm.Ind(1).Data.Assieme), 1) = Chr(36) And Mode > -1 Then
            Prima()
        End If 'G
        ItemnSt = LTrim(job.Comm.Ind(1).Data.Assieme)
        SETRDIT(ItemnSt, Nrdit)
        If Mode <= 0 Then
            'LungSt1(1) = 21
            '          SEARCHA(Ialta)
            For i = 1 To 5 : LungSt1(i) = actItem.indRecDati(i) : Next ' Ialta.Ialt(i) : Next
            Nalt = 0
            For i = 1 To 5
                If LungSt1(i) > 0 Then Nalt = Nalt + 1
            Next i
            Nalt1 = Nalt + 1 : If Nalt1 > 5 Then Nalt1 = 5
Rif:
            If Not NonMostrareAlt And Nalt > 0 Then
                If Mode > -1 Then
                    Dom(1) = RTrim("N° dell'alternativa da editare") '"Nø dell'alternativa da editare"
                    Dom(2) = RTrim("N° alternativa modello        ") '"Nø alternativa modello        "
                    Risp(1) = Str(Val(job.Comm.Ind(2).Data.Assieme))
                    If Val(Risp(1)) = 0 Then Risp(1) = " 1" : NuovaAlt = True
                    If Nalt = 0 Then Risp(1) = "Nuova alternativa:" & Risp(1) Else Risp(1) = "Alternativa esistente:" & Risp(1)
                    Risp(2) = "NN"
                    Archiv(1) = 1000 : Archiv(2) = 1001
                    iF1 = FreeFile()
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.Inizio. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    FileOpen(iF1, RTrim(Monitor.Motore.Inizio.Archdir) & "\ARCH" & "1000.DAT", OpenMode.Output)
                    PrintLine(iF1, "  25   0   0   0")
                    For i = 1 To Nalt
                        PrintLine(iF1, ("Alternativa esistente:" & i.ToString).PadRight(25))
                    Next
                    PrintLine(iF1, ("Nuova alternativa:" & Nalt1.ToString).PadRight(25))
                    FileClose(iF1)
                    If Nuovo Then
                        Risp(1) = ("Nuova alternativa:" & Nalt1.ToString).PadRight(25) : NuovaAlt = True
                    End If
                    If Nalt > 0 Then
                        FileOpen(iF1, RTrim(Monitor.Motore.Inizio.Archdir) & "\ARCH" & "1001.DAT", OpenMode.Output)
                        PrintLine(iF1, "  02   0   0   0")
                        PrintLine(iF1, "NN")
                        For i = 1 To Nalt
                            PrintLine(iF1, Trim(Str(i)))
                        Next
                        FileClose(iF1)
                    End If
                    xAlt = 0
                    Titolo = "Inserimento alternativa" 'RTrim$(at1(25)) '"Inserimento alternativa"
                    Ninput = 2 : If Nalt = 0 Then Ninput = 1
                    Monitor.Motore.Chiamante = Monitor
                    If Not Monitor.Motore.InputDati(Ninput, Titolo, Dom, Risp, "", Archiv, Help) Then Exit Sub
                    xAlt = Val(Right(Trim(Risp(1)), 2))
                    yAlt = Val(Right(Trim(Risp(2)), 2))
                    If xAlt = Nalt1 Then NuovaAlt = True
                    If xAlt < 1 Or xAlt > 5 Or yAlt < 0 Or yAlt > 5 Or xAlt = yAlt Then
                        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.Inizio. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Testo = Monitor.Motore.Inizio.ConvertiCr(RTrim(at1(28) & at1(29)))
                        '     Testo = "Dati errati! Si suggerisce di inse-|"
                        'Testo = Testo + "rire i dati clickando sugli spazi  |"
                        'Testo = Testo + "bianchi riservati ai dati.         |"
                        '   x = Alert(2, Testo, 8, 11, 13, 64, at1(73), Space$(0), Space$(0))
                        MsgBox(Testo, MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation)
                        GoTo Rif
                    End If
                End If
            Else
                xAlt = 1 : yAlt = 0
            End If
        Else
            xAlt = Val(job.Comm.Ind(2).Data.Assieme)
            If xAlt = 0 Then xAlt = 1
            yAlt = 0
            NuovaAlt = False
        End If
        If Mode > -1 Then
            job.Comm.Ind(2).Data.Assieme = Str(xAlt)
        Else
            xAlt = Val(job.Comm.Ind(2).Data.Assieme) : yAlt = 0
        End If
        'SETALT xAlt
        GETDUT(RDUT)
        n = Val(job.Comm.Ind(2).Data.Assieme)
        If n = 0 Then
            Testo = GlobalRoutines.FormatS(Monitor.Motore.Inizio.ConvertiCr(Helpstringa(1098)), "altern")
            MostraAiuto(IDH_HTRI_ALTNONATT, ChiaviMess.MessCritical Or ChiaviMess.MessOkOnly Or ChiaviMess.MessHelpButton, Testo)
            Exit Sub
        End If
        If NuovaAlt Then
            Origineprop = objDatBase.CVI(objDatBase.DatBase(4, 74, Nrdit \ 2, xAlt, itp, 0))
        Else
            Origineprop = objDatBase.CVI(objDatBase.DatBase(4, 74, Nrdit \ 2, n, itp, 0))
        End If
        If Origineprop > 2 Then Origineprop = 0
        If Origineprop > 0 Then
            Testo = GlobalRoutines.Str2Cifre(Nrdit \ 2) + Trim(Str(n))
            NewF = Trim(Monitor.Motore.Inizio.Workdir) & "\" & Left(job.Contratto, 4) & Testo & ".WLD" 'RA3
            Readzone(NewF)
        End If
        If Origineprop > 0 And Mode <= 0 Then
            NewF = Left(NewF, Len(NewF) - 3) & "RA1" 'RA1
            FileOpen(100, NewF, OpenMode.Random, , , Len(Curva))
            If ProblWLD.NZONE = 1 Then
                With ProblWLD
                    .Tzone(1) = RDUT.Tin : .Tzone(2) = RDUT.TOut
                    .Hzone(1) = Interp(RDUT.Tin)
                    .Hzone(2) = Interp(RDUT.TOut)
                End With
            ElseIf System.Math.Abs(RDUT.Tin - ProblWLD.Tzone(1)) < 1.0! Then
                ProblWLD.Tzone(1) = RDUT.Tin
            ElseIf RDUT.Tin < ProblWLD.Tzone(1) Then
                With ProblWLD
                    For i = 1 To .NZONE
                        If RDUT.Tin > .Tzone(i) Then Exit For
                    Next
                    If i > 1 Then
                        .NZONE = .NZONE - i + 1
                        For j = 1 To .NZONE
                            .Tzone(j) = .Tzone(j + i)
                            .Hzone(j) = .Hzone(j + i)
                            .TipZone(j) = .TipZone(j + i)
                        Next
                    End If 'H
                    .Hzone(1) = Interp(RDUT.Tin)
                    .Tzone(1) = RDUT.Tin
                End With
            Else
                With ProblWLD
                    '  .NZONE = .NZONE + 1
                    '  For i = .NZONE To 2 Step -1
                    '     .Tzone(i) = .Tzone(i - 1)
                    '     .Hzone(i) = .Hzone(i - 1)
                    '     .TipZone(i) = .TipZone(i - 1)
                    '  Next
                    '  .Hzone(1) = Interp(RDUT.Tin)
                    '  .Tzone(1) = RDUT.Tin
                End With
            End If 'I
            With ProblWLD
                ' If Abs(RDUT.TOut - .Tzone(.NZONE)) < 1! Then
                .Tzone(.NZONE) = RDUT.TOut
                ' ElseIf RDUT.TOut > .Tzone(.NZONE) Then
                '     For i = .NZONE To 1 Step -1
                '     If RDUT.TOut < .Tzone(i) Then Exit For
                '     Next
                '     If i < .NZONE Then .NZONE = i
                '     .Hzone(.NZONE) = Interp(RDUT.TOut)
                '     .Tzone(.NZONE) = RDUT.TOut
                ' Else
                '     .NZONE = .NZONE + 1
                '     .Hzone(.NZONE) = Interp(RDUT.TOut)
                '     .Tzone(.NZONE) = RDUT.TOut
                ' End If  'L
                ' .NZONE = .NZONE - 1
            End With
            FileClose(100)
        ElseIf Origineprop = 0 Then
            '   n = Val(job.Comm.Ind(2).Data.Assieme)
            If n > 0 And n < 6 Then
                Testo = GlobalRoutines.Str2Cifre(Nrdit \ 2) + Trim(Str(n))
                NewF = RTrim(Monitor.Motore.Inizio.Workdir) & Chr(92) & Left(job.Contratto, 4) & Testo & ".WLD"
                Readzone(NewF)
            End If
        End If 'A
        'FilePut(1, Lav(0), 1)
        IO.File.Delete(Monitor.Motore.Inizio.DiscoTem & RTrim(job.Contratto))
        If xAlt > 1 Then
            job.Comm.Ind(3).Data.Assieme = " " 'distinta con più alternative
            'FilePut(1, Lav(0), 1)
        End If
        HTRI2(xAlt, yAlt, ProblWLD.NZONE, 0)
        If Mode = 1 Then
            ' CLOSPREV()
            ProblWLD.NZONE = objDatBase.CVI(objDatBase.DatBase(4, 14, Nrdit \ 2, xAlt, itp, 0))
            If ProblWLD.NZONE < 1 Or ProblWLD.NZONE > 12 Then
                ProblWLD.NZONE = 1
                u = objDatBase.PutBasCh(4, 14, Nrdit \ 2, xAlt, objDatBase.MKI(ProblWLD.NZONE), 0)
            End If
            ' Apri(Trim(job.Contratto))
            Exit Sub
        End If
RifRif:
        If Apert.optTM(1).Checked Then Exit Sub
        Apert.Enabled = False
        FaseDati = 3
        Ris = NZONE(ProblWLD.NZONE)
        TempZone()
        ZONCOND()
        Exit Sub
    End Sub
    Private Sub Prima()
        X = EdiIte()
        Do
            System.Windows.Forms.Application.DoEvents()
        Loop While Not Monitor.Motore.InputForms Is Nothing
        If FaseDati = -1 Then FaseDati = 0 : Exit Sub
    End Sub
    Sub Librerie()
        If Asc(job.Contratto) > 32 Then ChiPre() : FileClose()
        '   Catena "LIBR"
    End Sub
    Public Sub SalvaPRVas(ByVal NomeFile As String, ByRef objPRV As clsPRV)
        Dim fs As FileStream = New FileStream(NomeFile, FileMode.OpenOrCreate, FileAccess.ReadWrite)
        Dim bf As New BinaryFormatter
        bf.Serialize(fs, objPRV)
        objPRV.prNomeFile = NomeFile
        fs.Close()
    End Sub
    Public Sub ApriPRV(ByVal NomeFile As String, ByRef objPRV As clsPRV, ByRef iErr As Integer)
        Dim itp As String = ""
        Dim VecchioInput As Boolean = False
        Dim fs As FileStream
        objPRV = New clsPRV(job.Contratto)
        fs = New FileStream(NomeFile, FileMode.Open, FileAccess.Read)
        Try
            Dim bf As New BinaryFormatter
            objPRV = CType(bf.Deserialize(fs), clsPRV)
        Catch ex As Exception
            VecchioInput = True
        End Try
        fs.Close()
        If Not VecchioInput Then Exit Sub
        '-------------------versione antica------------------------
        If Not PRVValido(NomeFile) Then
            Stop
        End If
        Dim i, j, k, recIalt As Integer
        With objDatBase
            .Open(NomeFile)
            objPRV.SiglaPrev = .DatBase(1, 1, 1, 1, itp, 0)
            objPRV.NomeClien = .DatBase(1, 2, 1, 1, itp, 0)
            objPRV.IndirClie = .DatBase(1, 3, 1, 1, itp, 0)
            objPRV.LuogoImpi = .DatBase(1, 4, 1, 1, itp, 0)
            objPRV.RiferClie = .DatBase(1, 5, 1, 1, itp, 0)
            objPRV.UnitaMisu = .DatBase(1, 6, 1, 1, itp, 0)
            objPRV.Linguaggi = .DatBase(1, 7, 1, 1, itp, 0)
            objPRV.NumerItm = .CVI(.DatBase(1, 8, 1, 1, itp, 0))
            objPRV.UltimRec = .CVI(.DatBase(1, 9, 1, 1, itp, 0))
            objPRV.NumerComm = .DatBase(1, 10, 1, 1, itp, 0)
            objPRV.Ventiltor = .DatBase(1, 11, 1, 1, itp, 0)
            objPRV.MaterPale = .DatBase(1, 12, 1, 1, itp, 0)
            objPRV.MaterMozz = .DatBase(1, 13, 1, 1, itp, 0)
            objPRV.OpCamini = .CVI(.DatBase(1, 14, 1, 1, itp, 0))
            objPRV.DataPreve = .DatBase(1, 15, 1, 1, itp, 0)
            objPRV.DataApCom = .DatBase(1, 16, 1, 1, itp, 0)
            objPRV.DataChius = .DatBase(1, 17, 1, 1, itp, 0)
            objPRV.NumerProt = .DatBase(1, 18, 1, 1, itp, 0)
            For i = 1 To objPRV.NumerItm
                Dim NewItem As clsItem = New clsItem
                NewItem.Sigla = .DatBase(2, 1, 10, i, 1) '  10    S,  00,   0   ,Sigla item
                NewItem.Banco = .DatBase(2, 11, 2, i, 1) '    2    S,  00,   0   ,Banco
                NewItem.Servizio = .DatBase(2, 13, 20, i, 1) '    20    S,  00,   0   ,Servizio
                NewItem.Fluido = .DatBase(2, 33, 10, i, 1) '  10    S,  00,   0   ,Fluido circolante
                NewItem.codMontaggio = .CVI(.DatBase(2, 43, 1, i, 1)) '    1    I,  11,   0   ,Codice montaggio
                NewItem.codTelaio = .CVI(.DatBase(2, 44, 1, i, 1)) '    I,  12,   0   ,Codice telaio
                NewItem.codStutture = .CVI(.DatBase(2, 45, 1, i, 1)) '    I,  12,   0   ,Codice strutture
                NewItem.codCamereAria = .CVI(.DatBase(2, 46, 1, i, 1)) '    I,  12,   0   ,Codice camere aria
                NewItem.codTestate = .CVI(.DatBase(2, 47, 1, i, 1)) '   I,  13,   0   ,Codice testate
                NewItem.codMaterTestate = .CVI(.DatBase(2, 48, 1, i, 1)) '    I,  14,   0   ,Cod. materiale testate
                NewItem.codmaterTappi = .CVI(.DatBase(2, 49, 1, i, 1)) '    I,  15,   0   ,Cod. materiale tappi
                '                                   2   12    50     1    I,  00,   0   ,-----
                NewItem.codRatingFlange = .CVI(.DatBase(2, 51, 1, i, 1)) '   I,  16,   0   ,Rating flange
                NewItem.codCollaudi = .CVI(.DatBase(2, 52, 1, i, 1)) '   I,  17,   0   ,Cod. collaudi
                NewItem.codPasserelle = .CVI(.DatBase(2, 53, 1, i, 1)) '   I,  18,   0   ,Cod. passerelle
                '                                   2   16    54     1    I,  00,   0   ,-----
                NewItem.codIsolamentoMotore = .CVI(.DatBase(2, 55, 1, i, 1)) '    I,  19,   0   ,Cod. isolamento motore
                NewItem.codTipoMotore = .CVI(.DatBase(2, 56, 1, i, 1)) '    I,  27,   0   ,Cod. tipo motore
                NewItem.codRicircolo = .CVI(.DatBase(2, 57, 1, i, 1)) '   I,  21,   0   ,Cod. ricircolo
                NewItem.codPersiane = .CVI(.DatBase(2, 58, 1, i, 1)) '   I,  22,   0   ,Cod. persiane
                NewItem.codSpecifiche = .CVI(.DatBase(2, 59, 1, i, 1)) '    I,  17,   0   ,Cod. specifiche
                NewItem.codMaterialeGuarnizioni = .CVI(.DatBase(2, 60, 1, i, 1)) '  I,  24,   0   ,Cod. materiale guarnizioni
                NewItem.codMaterTubiSC = .CVI(.DatBase(2, 61, 1, i, 1)) '   I,  23,   0   ,Cod. mat. tubi st. coil
                NewItem.codVoltCicliFase = .CVI(.DatBase(2, 62, 1, i, 1)) '    I,  26,   0   ,Cod. volt-cicli-fasi motore
                NewItem.codRatingFlangeSC = .CVI(.DatBase(2, 63, 1, i, 1)) '   I,  16,   0   ,Cod. rating flange st. coil
                '                                   2   26    64     1    I,  00,   0   ,-----
                NewItem.codScalePioli = .CVI(.DatBase(2, 65, 1, i, 1)) '  I,  29,   0   ,Cod. scale pioli
                NewItem.codScaleGradini = .CVI(.DatBase(2, 66, 1, i, 1)) '   I,  29,   0   ,Cod. scale gradini
                NewItem.codInterrVibrazioni = .CVI(.DatBase(2, 67, 1, i, 1)) '    I,  29,   0   ,Cod. interr. vibrazioni
                NewItem.codmaterAlette = .CVI(.DatBase(2, 73, 1, i, 1)) '   I,  00,   0   ,Cod. materiale alette
                NewItem.BWGtubiSC = .CVI(.DatBase(2, 74, 1, i, 1)) '  I,  00,   0   ,BWG tubi steam coil
                NewItem.TipoBWGSC = .DatBase(2, 75, 2, i, 1) '   2    S,  00,   0   ,Tipo BWG tubi s.c.
                NewItem.TipoAletteSC = .CVI(.DatBase(2, 77, 1, i, 1)) '   1    I,  00,   0   ,Tipo alette st. coil
                NewItem.NAlettexPollice = .CVS(.DatBase(2, 81, 2, i, 1)) '    2    R,  00,   0   ,N. alette 1" St. coil
                NewItem.PressInSC = .CVS(.DatBase(2, 83, 2, i, 1)) '    2    R,  00,   0   ,Pressione ingresso st. coil
                NewItem.PressDesSC = .CVS(.DatBase(2, 85, 2, i, 1)) '     2    R,  00,   0   ,Pressione progetto st. coil
                NewItem.TempInSC = .CVS(.DatBase(2, 87, 2, i, 1)) '     2    R,  00,   0   ,Temperat. ingresso st. coil
                NewItem.TempDesSC = .CVS(.DatBase(2, 89, 2, i, 1)) '    2    R,  00,   0   ,Temperat. progetto st. coil
                NewItem.DiamInSC = .CVS(.DatBase(2, 91, 2, i, 1)) '   2    R,  00,   0   ,Dia. boc. ingresso st. coil
                NewItem.DiamOutSC = .CVS(.DatBase(2, 93, 2, i, 1)) '   2    R,  00,   0   ,Dia. boc. uscita st. coil
                NewItem.Corrosione = .CVS(.DatBase(2, 95, 2, i, 1)) '   2    R,  00,   0   ,Corrosione
                NewItem.Banco2 = .DatBase(2, 97, 2, i, 1) '    2    S,  00,   0   ,Banco 2
                NewItem.Banco3 = .DatBase(2, 99, 2, i, 1) '    2    S,  00,   0   ,Banco 3
                NewItem.Banco4 = .DatBase(2, 101, 2, i, 1) '   2    S,  00,   0   ,Banco 4
                NewItem.codProprietaLiquido = .CVI(.DatBase(2, 103, 1, i, 1)) '    1    I,  00,   0   ,Codice proprieta' liquido
                NewItem.codproprietaVapore = .CVI(.DatBase(2, 104, 1, i, 1)) '    1    I,  00,   0   ,Codice proprieta' vapore
                NewItem.NumRev = .CVI(.DatBase(2, 105, 1, i, 1)) '    1    I,  00,   0   ,N. revisione
                NewItem.indNote(1) = .CVI(.DatBase(2, 106, 1, i, 1)) '   1    I,  00,   0   ,N. rec. note 1ø alternativa
                NewItem.indNote(2) = .CVI(.DatBase(2, 107, 1, i, 1)) '    1    I,  00,   0   ,N. rec. note 2ø alternativa
                NewItem.indNote(3) = .CVI(.DatBase(2, 108, 1, i, 1)) '   1    I,  00,   0   ,N. rec. note 3ø alternativa
                NewItem.indNote(4) = .CVI(.DatBase(2, 109, 1, i, 1)) '    1    I,  00,   0   ,N. rec. note 4ø alternativa
                NewItem.indNote(5) = .CVI(.DatBase(2, 110, 1, i, 1)) '    1    I,  00,   0   ,N. rec. note 5ø alternativa
                NewItem.DatiManuali = .CVI(.DatBase(2, 113, 1, i, 1)) '   1    I,  00,   0   ,Dati manuali ..............
                NewItem.SteamCoil = .DatBase(2, 114, 1, i, 1) '   1    S,  00,   0   ,Steam coil (YE NO)
                NewItem.ChiaveDatiItem = .CVI(.DatBase(2, 117, 1, i, 1)) '    1    I,  00,   0   ,Chiave dati item
                NewItem.NumTotCalcReg = .CVI(.DatBase(2, 118, 1, i, 1)) '   1    I,  00,   0   ,N. totale calcoli registrati
                NewItem.indRecDati(1) = .CVI(.DatBase(2, 119, 1, i, 1)) '     1    I,  00,   0   ,N. 1ø rec. dati
                NewItem.ChiaveVali(1) = .CVI(.DatBase(2, 120, 1, i, 1)) '   1    I,  00,   0   ,N. 1ø chiave validita'
                NewItem.indRecDati(2) = .CVI(.DatBase(2, 121, 1, i, 1)) '    1    I,  00,   0   ,N. 2ø rec. dati
                NewItem.ChiaveVali(2) = .CVI(.DatBase(2, 122, 1, i, 1)) '    1    I,  00,   0   ,N. 2ø chiave validita'
                NewItem.indRecDati(3) = .CVI(.DatBase(2, 123, 1, i, 1)) '   1    I,  00,   0   ,N. 3ø rec. dati
                NewItem.ChiaveVali(3) = .CVI(.DatBase(2, 124, 1, i, 1)) '   1    I,  00,   0   ,N. 3ø chiave validita'
                NewItem.indRecDati(4) = .CVI(.DatBase(2, 125, 1, i, 1)) '   1    I,  00,   0   ,N. 4ø rec. dati
                NewItem.ChiaveVali(4) = .CVI(.DatBase(2, 126, 1, i, 1)) '   1    I,  00,   0   ,N. 4ø chiave validita'
                NewItem.indRecDati(5) = .CVI(.DatBase(2, 127, 1, i, 1)) '   1    I,  00,   0   ,N. 5ø rec. dati
                NewItem.ChiaveVali(5) = .CVI(.DatBase(2, 128, 1, i, 1)) '    1    I,  00,   0   ,N. 5ø chiave validita'
                NewItem.VENT = .DatBase(2, 68, 1, i, 1) '   1    S,  00,   0   ,VENT       (n.tot size)
                NewItem.DRAIN = .DatBase(2, 69, 1, i, 1) '     1    S,  00,   0   ,DRAIN      (n.tot size)
                NewItem.THERMOWELL = .DatBase(2, 70, 1, i, 1) ' 1    S,  00,   0   ,THERMOWELL (n.tot size)
                NewItem.PRESSGAUGES = .DatBase(2, 71, 1, i, 1) '   1    S,  00,   0   ,PRESS.G.   (n.tot size)
                NewItem.Automatico = .CVI(.DatBase(2, 115, 1, i, 1)) '   1    I,  00,   0   ,Automatico 0 NO 1 SI
                NewItem.Nrepliche = .CVI(.DatBase(2, 116, 1, i, 1)) '  1    I,  00,   0   ,N° repliche
                NewItem.DutyRDIT = .CVS(.DatBase(3, 1, 2, i, 1)) '   2    R,  00,   0   ,Duty totale
                NewItem.TempIn = .CVS(.DatBase(3, 3, 2, i, 1)) '  2    R,  00,   0   ,Temp. in
                NewItem.TempOut = .CVS(.DatBase(3, 5, 2, i, 1)) '   2    R,  00,   0   ,Temp. out
                NewItem.LiqHCIn = .CVS(.DatBase(3, 7, 2, i, 1)) '   2    R,  00,   0   ,Liq. HC in
                NewItem.VapHCIn = .CVS(.DatBase(3, 9, 2, i, 1)) '  2    R,  00,   0   ,Vap. HC in
                NewItem.NonCondIn = .CVS(.DatBase(3, 11, 2, i, 1)) '     2    R,  00,   0   ,Non-Cond in
                NewItem.SteamIn = .CVS(.DatBase(3, 13, 2, i, 1)) '   2    R,  00,   0   ,Steam in
                NewItem.WaterIn = .CVS(.DatBase(3, 15, 2, i, 1)) '  2    R,  00,   0   ,Water in
                NewItem.PressIn = .CVS(.DatBase(3, 17, 2, i, 1)) '  2    R,  00,   0   ,Pressione in
                NewItem.dpAllowable = .CVS(.DatBase(3, 19, 2, i, 1)) '  2    R,  00,   0   ,D.P allowable
                NewItem.TempAirIn = .CVS(.DatBase(3, 21, 2, i, 1)) '    2    R,  00,   0   ,Temp. air in
                NewItem.Fouling = .CVS(.DatBase(3, 23, 2, i, 1)) '  2    R,  00,   0   ,Fouling
                NewItem.MWNonCond = .CVS(.DatBase(3, 25, 2, i, 1)) '   2    R,  00,   0   ,MW incond.
                NewItem.MWVapIn = .CVS(.DatBase(3, 27, 2, i, 1)) '  2    R,  00,   0   ,MW vap. in
                NewItem.MWVapOut = .CVS(.DatBase(3, 29, 2, i, 1)) '   2    R,  00,   0   ,MW vap out
                NewItem.vLiq1 = .CVS(.DatBase(3, 31, 2, i, 1)) '   2    R,  00,   0   ,Visc. liq. HC
                NewItem.T_vLiq1 = .CVS(.DatBase(3, 33, 2, i, 1)) '  2    R,  00,   0   ,Temp.
                NewItem.vLiq2 = .CVS(.DatBase(3, 35, 2, i, 1)) '    2    R,  00,   0   ,Visc. liq. HC
                NewItem.T_vLiq2 = .CVS(.DatBase(3, 37, 2, i, 1)) '   2    R,  00,   0   ,Temp.
                NewItem.kLiq1 = .CVS(.DatBase(3, 39, 2, i, 1)) '   2    R,  00,   0   ,Cond. liq.
                NewItem.T_kLiq1 = .CVS(.DatBase(3, 41, 2, i, 1)) ' 2    R,  00,   0   ,Temp.
                NewItem.kLiq2 = .CVS(.DatBase(3, 43, 2, i, 1)) '  2    R,  00,   0   ,Cond. liq.
                NewItem.T_kLiq2 = .CVS(.DatBase(3, 45, 2, i, 1)) '    2    R,  00,   0   ,Temp.
                NewItem.Grav1 = .CVS(.DatBase(3, 47, 2, i, 1)) '    2    R,  00,   0   ,Gravità sp. liq
                NewItem.T_Grav1 = .CVS(.DatBase(3, 49, 2, i, 1)) '   2    R,  00,   0   ,Temp.
                NewItem.Grav2 = .CVS(.DatBase(3, 51, 2, i, 1)) '   2    R,  00,   0   ,Gravità sp. liq
                NewItem.T_Grav2 = .CVS(.DatBase(3, 53, 2, i, 1)) '   2    R,  00,   0   ,Temp.
                NewItem.SpLiq1 = .CVS(.DatBase(3, 55, 2, i, 1)) '  2    R,  00,   0   ,Calore sp. liq.
                NewItem.T_SpLiq1 = .CVS(.DatBase(3, 57, 2, i, 1)) ' 2    R,  00,   0   ,Temp.
                NewItem.SpLiq2 = .CVS(.DatBase(3, 59, 2, i, 1)) '  2    R,  00,   0   ,Calore sp. liq.
                NewItem.T_SpLiq2 = .CVS(.DatBase(3, 61, 2, i, 1)) '   2    R,  00,   0   ,Temp.
                NewItem.SpNonCond1 = .CVS(.DatBase(3, 63, 2, i, 1)) ' 2    R,  00,   0   ,Cal. sp. NC  
                NewItem.T_SpNonCond1 = .CVS(.DatBase(3, 65, 2, i, 1)) '  2    R,  00,   0   ,Temp.
                NewItem.SpNonCond2 = .CVS(.DatBase(3, 67, 2, i, 1)) '   2    R,  00,   0   ,Cal. sp. NC  
                NewItem.T_SpNonCond2 = .CVS(.DatBase(3, 69, 2, i, 1)) '   2    R,  00,   0   ,Temp.
                NewItem.vVap1 = .CVS(.DatBase(3, 71, 2, i, 1)) '  2    R,  00,   0   ,           
                NewItem.T_vVap1 = .CVS(.DatBase(3, 73, 2, i, 1)) ' 2    R,  00,   0   ,Temp.
                NewItem.vVap2 = .CVS(.DatBase(3, 75, 2, i, 1)) '   2    R,  00,   0   ,             
                NewItem.T_vVap2 = .CVS(.DatBase(3, 77, 2, i, 1)) '   2    R,  00,   0   ,Temp.
                NewItem.kVap1 = .CVS(.DatBase(3, 79, 2, i, 1)) '  2    R,  00,   0   ,               
                NewItem.T_kVap1 = .CVS(.DatBase(3, 81, 2, i, 1)) '   2    R,  00,   0   ,Temp.
                NewItem.kVap2 = .CVS(.DatBase(3, 83, 2, i, 1)) '   2    R,  00,   0   ,                
                NewItem.T_kVap2 = .CVS(.DatBase(3, 85, 2, i, 1)) ' 2    R,  00,   0   ,Temp.
                NewItem.SpVap1 = .CVS(.DatBase(3, 87, 2, i, 1)) ' 2    R,  00,   0   ,
                NewItem.T_SpVap1 = .CVS(.DatBase(3, 89, 2, i, 1)) '  2    R,  00,   0   ,Temp.
                NewItem.SpVap2 = .CVS(.DatBase(3, 91, 2, i, 1)) ' 2    R,  00,   0   ,               
                NewItem.T_SpVap2 = .CVS(.DatBase(3, 93, 2, i, 1)) '  2    R,  00,   0   ,Temp.
                NewItem.ComprFactor1 = .CVS(.DatBase(3, 95, 2, i, 1)) '   2    R,  00,   0   ,
                NewItem.T_ComprFactor1 = .CVS(.DatBase(3, 97, 2, i, 1)) '   2    R,  00,   0   ,Temp.
                NewItem.ComprFactor2 = .CVS(.DatBase(3, 99, 2, i, 1)) '   2    R,  00,   0   ,                
                NewItem.T_ComprFactor2 = .CVS(.DatBase(3, 101, 2, i, 1)) '   2    R,  00,   0   ,Temp.
                NewItem.DesignPressure = .CVS(.DatBase(3, 103, 2, i, 1)) '  2    R,  00,   0   ,Design Pressure
                NewItem.TestPressure = .CVS(.DatBase(3, 105, 2, i, 1)) '   2    R,  00,   0   ,Test Pressure
                NewItem.Provvisorio3 = .CVS(.DatBase(3, 107, 2, i, 1)) '   2    R,  00,   0   ,Design Temperature
                NewItem.CaloreLatente = .CVS(.DatBase(3, 109, 2, i, 1)) '  2    R,  00,   0   ,
                NewItem.Provvisorio4 = .CVS(.DatBase(3, 111, 2, i, 1)) '   2    R,  00,   0   ,
                NewItem.TempMinAria = .CVS(.DatBase(3, 113, 2, i, 1)) '   2    R,  00,   0   ,Temp min.aria
                NewItem.Provvisorio1 = .CVS(.DatBase(3, 115, 2, i, 1)) '    2    R,  00,   0   ,
                NewItem.Provvisorio2 = .CVS(.DatBase(3, 117, 2, i, 1)) '    2    R,  00,   0   ,
                NewItem.CondenHC = .CVS(.DatBase(3, 119, 2, i, 1)) '     2    R,  00,   0   ,
                NewItem.CondSteam = .CVS(.DatBase(3, 121, 2, i, 1)) '   2    R,  00,   0   ,
                NewItem.Elevaz = .CVS(.DatBase(3, 123, 2, i, 1)) '  2    R,  00,   0   ,
                NewItem.vLiq3 = .CVS(.DatBase(3, 125, 2, i, 1)) '   2    R,  00,   0   ,Visc. liq. HC
                NewItem.T_vLiq3 = .CVS(.DatBase(3, 127, 2, i, 1)) '   2    R,  00,   0   ,Temp.
                NewItem.NumALt = 0
                For j = 1 To 5
                    recIalt = NewItem.indRecDati(j)
                    If recIalt > 0 Then
                        Dim NewAlt As clsAltern = New clsAltern
                        NewAlt.Engineer = .DatBase(4, 1, 1, i, recIalt) '    S,  00,   0   ,Engineer
                        NewAlt.TipoUnita = .DatBase(4, 2, 3, i, recIalt) '    S,  00,   0   ,Tipo unita'
                        NewAlt.NumFasciParall = .CVI(.DatBase(4, 5, 1, i, recIalt)) '   I,  00,   0   ,N. fasci in parallelo
                        NewAlt.NFPAlberoPassante = .CVI(.DatBase(4, 6, 1, i, recIalt)) '    I,  00,   0   ,N. fasci in par. con albero pass.
                        NewAlt.NumTotPassi = .CVI(.DatBase(4, 7, 1, i, recIalt)) '   0   ,N. totale passi
                        NewAlt.NbocIn = .CVI(.DatBase(4, 8, 1, i, recIalt)) '   0   ,N. bocchelli in
                        NewAlt.NBocOut = .CVI(.DatBase(4, 9, 1, i, recIalt)) '   0   ,N. bocchelli out
                        NewAlt.NumTipiTubi = .CVI(.DatBase(4, 10, 1, i, recIalt)) '   0   ,N. tipi di tubi
                        NewAlt.RPMVentilatore = .CVI(.DatBase(4, 11, 1, i, recIalt)) '   0   ,R.P.M. Ventilatore
                        NewAlt.TipoVentilatore = .DatBase(4, 12, 1, i, recIalt) '   S,  00,   0   ,Tipo Ventilatore
                        NewAlt.PerCentoAV = .CVI(.DatBase(4, 13, 1, i, recIalt)) '   0   ,% Passo AV
                        NewAlt.Positioner_Rele = .DatBase(4, 14, 2, i, recIalt) '    S,  00,   0   ,Posizion. o rele'
                        NewAlt.TipoPale = .DatBase(4, 16, 2, i, recIalt) ' S,  00,   0   ,Tipo pale
                        NewAlt.NumZone = .CVI(.DatBase(4, 18, 1, i, recIalt)) '   0   ,N. Zone di calcolo
                        NewAlt.RPMmotore = .CVI(.DatBase(4, 19, 1, i, recIalt)) '   0   ,RPM Motore
                        NewAlt.codSlope = .CVI(.DatBase(4, 20, 1, i, recIalt)) '  I,  25,   0   ,Codice slope
                        NewAlt.codRiduttore = .CVI(.DatBase(4, 21, 1, i, recIalt)) '   0   ,Codice riduttore
                        NewAlt.Autom = .DatBase(4, 22, 1, i, recIalt) ' S,  00,   0   ,Autom (SI/NO)
                        NewAlt.codSplit = .DatBase(4, 23, 1, i, recIalt) '   0   ,Codice split
                        NewAlt.codImbocco = .CVI(.DatBase(4, 24, 1, i, recIalt)) '  I,  43,   0   ,Codice imbocco       
                        NewAlt.NunitaxDS = .DatBase(4, 25, 1, i, recIalt) '    S,  00,   0   ,N. Unita' per D.S.
                        NewAlt.codAsterisco = .DatBase(4, 26, 1, i, recIalt) '    S,  00,   0   ,Codice asterisco
                        NewAlt.NoteBocchelli = .CVI(.DatBase(4, 27, 1, i, recIalt)) '   0   ,Note per bocchelli
                        NewAlt.NoteGenerali = .CVI(.DatBase(4, 28, 1, i, recIalt)) '   0   ,Note generali
                        NewAlt.GiornoCalcolo = .CVI(.DatBase(4, 29, 1, i, recIalt)) '   0   ,Giorno
                        NewAlt.MeseCalcolo = .CVI(.DatBase(4, 30, 1, i, recIalt)) '   0   ,Mese
                        NewAlt.AnnoCalcolo = .CVI(.DatBase(4, 31, 1, i, recIalt)) '   0   ,Anno
                        NewAlt.codTestate = .CVI(.DatBase(4, 32, 1, i, recIalt)) '   0   ,Codice testate
                        NewAlt.codSC = .CVI(.DatBase(4, 33, 1, i, recIalt)) '   0   ,Codice St. Coil
                        NewAlt.NumPale = .CVI(.DatBase(4, 34, 1, i, recIalt)) '   0   ,N. pale ventilatore
                        NewAlt.PassiOrizzontali = .DatBase(4, 35, 1, i, recIalt) '   0   ,N. passi orizzontali
                        NewAlt.NumFasciStacked = .CVI(.DatBase(4, 36, 1, i, recIalt)) '   0   ,N. fasci stacked
                        NewAlt.NumRowsTopB = .CVI(.DatBase(4, 37, 1, i, recIalt)) '   0   ,N. rows (Top ... 1)
                        NewAlt.NumRowsMediumB = .CVI(.DatBase(4, 38, 1, i, recIalt)) '   0   ,N. rows (Top ... 2)
                        NewAlt.NumRowsBottomB = .CVI(.DatBase(4, 39, 1, i, recIalt)) '   0   ,N. rows (Top ... 3)
                        NewAlt.NumFileUnitaAccopp = .CVI(.DatBase(4, 40, 1, i, recIalt)) '   0   ,N. file per unita' accoppiate
                        NewAlt.SwitchScriviVent = .CVI(.DatBase(4, 41, 1, i, recIalt)) '   0   ,Chiave per Vent=1 se da scrivere
                        NewAlt.NumItemsxUnita = .CVI(.DatBase(4, 42, 1, i, recIalt)) '   0   ,N. items su stessa unita'
                        For k = 1 To 6
                            NewAlt.indRecDatiItem(k) = .CVI(.DatBase(4, 43 + k - 1, 1, i, recIalt)) '   0   ,N. 1ø record dati item 1
                            '   4   37    44     1,i,j))'   0   ,N. 1ø record dati item 2
                            '   4   38    45     1,i,j))'   0   ,N. 1ø record dati item 3
                            '   4   39    46     1,i,j))'   0   ,N. 1ø record dati item 4
                            '   4   40    47     1,i,j))'   0   ,N. 1ø record dati item 5
                            '   4   41    48     1,i,j))'   0   ,N. 1ø record dati item 6
                            NewAlt.NumFasciItem(k) = .CVI(.DatBase(4, 49 + k - 1, 1, i, recIalt)) '   0   ,N. fasci in comune 1ø item
                            '    4   43    50     1,i,j))'   0   ,N. fasci in comune 2ø item
                            '    4   44    51     1,i,j))'   0   ,N. fasci in comune 3ø item
                            '    4   45    52     1,i,j))'   0   ,N. fasci in comune 4ø item
                            '    4   46    53     1,i,j))'   0   ,N. fasci in comune 5ø item
                            '    4   47    54     1,i,j))'   0   ,N. fasci in comune 6ø item
                        Next
                        NewAlt.GiuntoTP = .CVI(.DatBase(4, 55, 1, i, recIalt)) '  I,  30,   0   ,Giunto t/p. (WE/EX)
                        NewAlt.switchSerpentino = .CVI(.DatBase(4, 56, 1, i, recIalt)) '   0   ,1 se serpentino
                        NewAlt.switchFasciAccoppiati = .CVI(.DatBase(4, 57, 1, i, recIalt)) '   0   ,1 se fasci accoppiati e width da non toccare
                        NewAlt.switchPersianeAUt = .CVI(.DatBase(4, 58, 1, i, recIalt)) '   0   ,1 se persiane automatiche
                        NewAlt.AirSupplyFan = .CVI(.DatBase(4, 59, 1, i, recIalt)) '   0   ,(psi)
                        NewAlt.AirSupplyPers = .CVI(.DatBase(4, 60, 1, i, recIalt)) '   0   ,(psi)
                        NewAlt.CorrelAria = .CVI(.DatBase(4, 61, 1, i, recIalt)) '   0   ,Correlazioni lato aria (0=ISA; 1=HTRI)
                        NewAlt.Prinop = .CVI(.DatBase(4, 62, 1, i, recIalt)) '   0   ,Origine proprietà fluido 0,1,2
                        '          4   73    63     1,i,j))'   0  tipo tubi zona 3
                        '          4   73    64     1,i,j))'   0  tipo tubi zona 4
                        NewAlt.BWG(2) = .CVI(.DatBase(4, 65, 1, i, recIalt)) '   0   ,BWG 1.tipo
                        '                                       4   61    97     1,i,j))'   0   ,BWG 2.tipo
                        For k = 0 To 1
                            NewAlt.TipoBWG(k + 1) = .DatBase(4, 66 + k * 32, 2, i, j) '    S,  00,   0   ,Tipo bwg 1. tipo
                            '                                       4   62    98     2    S,  00,   0   ,Tipo bwg 2. tipo
                            NewAlt.codMater(k + 1) = .CVI(.DatBase(4, 68 + k * 32, 1, i, j)) '    I,  23,   0   ,Mater    1. tipo
                            '                                       4   63   100     1    I,  23,   0   ,Mater    2. tipo
                            NewAlt.Conduc(k + 1) = .CVI(.DatBase(4, 85 + k * 32, 1, i, j)) '   0   ,cond.    1. tipo
                            '                                       4   64   117     1,i,j))'   0   ,cond.    2. tipo
                            NewAlt.codAlett(k + 1) = .DatBase(4, 86 + k * 32, 1, i, j) '    S,  00,   0   ,CodAlett 1. tipo
                            '                                       4   65   118     1    S,  00,   0   ,CodAlett 2. tipo
                            NewAlt.SpAlett(k + 1) = .DatBase(4, 87 + k * 32, 2, i, j) '    S,  00,   0   ,SpAlett  1. tipo
                            '                                       4   66   119     2    S,  00,   0   ,SpAlett  2. tipo
                            NewAlt.NumFile(k + 1) = .CVI(.DatBase(4, 89 + k * 32, 1, i, j)) '   0   ,N. file tubi
                            '                                       4   52   121     1,i,j))'   0   ,N. file tubi     2.tipo
                            NewAlt.NumTubiFascio(k + 1) = .CVI(.DatBase(4, 90 + k * 32, 1, i, j)) '   0   ,N. tubi/fascio
                            '                                       4   53   122     1,i,j))'   0   ,N. tubi/fascio   2.tipo
                            NewAlt.NumTubiSC(k + 1) = .CVI(.DatBase(4, 91 + k * 32, 1, i, j)) '   0   ,N.tubi/fascio S.T.
                            '                                       4   67   123     1,i,j))'   0   ,N.tubi/fascio S.T.
                            NewAlt.codTurbolators(k + 1) = .CVI(.DatBase(4, 92 + k * 32, 1, i, j)) '   I,  10,   0   ,Turbol   1. tipo
                            '                                       4   69   124     1    I,  10,   0   ,Turbol   2. tipo
                            NewAlt.GiuntiTP(k + 1) = .CVI(.DatBase(4, 93, 1, i, j)) '    I,  10,   0   ,
                            '                                       4   70   125     1    I,  30,   0   ,Giunto t/p 2. tipo 
                        Next k
                        NewAlt.ChiaveCondens = .CVI(.DatBase(5, 1, 1, i, recIalt)) '   0   ,Chiave per condensatori
                        NewAlt.TipoCalcolo = .CVI(.DatBase(5, 2, 1, i, recIalt)) '   0   ,1=calcolo HTRI 2=CSIN
                        NewAlt.AdditStaticPr = .CVS(.DatBase(5, 3, 2, i, recIalt)) '    R,  00,   0   ,Addit. static pr. per MFVC
                        For k = 1 To 12
                            NewAlt.TipoTubi(k) = .CVI(.DatBase(5, 5 + k - 1, 1, i, recIalt)) '   0   ,Tipo tubi zona 1         
                            '                                       5   17     6     1,i,j))'   0   ,Tipo tubi zona 2
                            '                                       5   18     7     1,i,j))'   0   ,Tipo tubi zona 3
                            '                                       5   19     8     1,i,j))'   0   ,Tipo tubi zona 4
                            '                                       5   20     9     1,i,j))'   0   ,Tipo tubi zona 5
                            '                                       5   21    10     1,i,j))'   0   ,Tipo tubi zona 6
                            '                                       5   22    11     1,i,j))'   0   ,Tipo tubi zona 7
                            '                                       5   23    12     1,i,j))'   0   ,Tipo tubi zona 8
                            '                                       5   24    13     1,i,j))'   0   ,Tipo tubi zona 9
                            '                                       5   25    14     1,i,j))'   0   ,Tipo tubi zona 10
                            '                                       5   26    15     1,i,j))'   0   ,Tipo tubi zona 11
                            '                                       5   27    16     1,i,j))'   0   ,Tipo tubi zona 12
                        Next
                        For k = 0 To 1
                            NewAlt.DiaTubo(k + 1) = .CVS(.DatBase(5, 17 + k * 24, 2, i, recIalt)) ',   0   ,Dia. tubo
                            '                                       5    7    41     ,2,i,j))',   0   ,Dia. tubo   2.
                            NewAlt.Passo(k + 1) = .CVS(.DatBase(5, 19 + k * 24, 2, i, recIalt)) ',   0   ,Passo tubi
                            '                                       5    8    43     ,2,i,j))',   0   ,Passo tubi  2.
                            NewAlt.DiAl(k + 1) = .CVS(.DatBase(5, 21 + k * 24, 2, i, recIalt)) ',   0   ,Dia. alette
                            '                                       5    9    45     ,2,i,j))',   0   ,Dia. alette 2.
                            NewAlt.NumAlettxInch(k + 1) = .CVS(.DatBase(5, 23 + k * 24, 2, i, recIalt)) ',   0   ,N.alette x 1"
                            '                                       5   10    47     ,2,i,j))',   0   ,N.alette x 1" 2.
                            NewAlt.NtotTubi(k + 1) = .CVS(.DatBase(5, 25 + k * 24, 2, i, recIalt)) ',   0   ,N.tot.tubi
                            '                                       5   11    49     ,2,i,j))',   0   ,N.tot.tubi  2.
                            NewAlt.SpessInch(k + 1) = .CVS(.DatBase(5, 27 + k * 24, 2, i, recIalt)) ',   0   ,Sp.tubi inch
                            '                                       5   12    51     ,2,i,j))',   0   ,Sp.tubi inch 2.
                            NewAlt.SurfRatio(k + 1) = .CVS(.DatBase(5, 29 + k * 24, 2, i, recIalt)) ',   0   ,
                            '                                       5   12    53     ,2,i,j))',   0   ,
                            NewAlt.SurfRatioA(k + 1) = .CVS(.DatBase(5, 31 + k * 24, 2, i, recIalt)) ',   0   ,
                            '                                       5   12    55     ,2,i,j))',   0   ,
                            NewAlt.CoeffSP_A(k + 1) = .CVS(.DatBase(5, 33 + k * 24, 2, i, recIalt)) ',   0   ,Coeff Static Pressure -A
                            '                                       5   12    57     ,2,i,j))',   0   ,
                            NewAlt.CoeffSP_B(k + 1) = .CVS(.DatBase(5, 35 + k * 24, 2, i, recIalt)) ',   0   ,Coeff Static Pressure -B
                            '                                       5   12    59     ,2,i,j))',   0   ,
                            NewAlt.CoeffAR_A(k + 1) = .CVS(.DatBase(5, 37 + k * 24, 2, i, recIalt)) ',   0   ,Coeff Air Resistance -A
                            '                                       5   12    61     ,2,i,j))',   0   ,
                            NewAlt.CoeffAR_B(k + 1) = .CVS(.DatBase(5, 39 + k * 24, 2, i, recIalt)) ',   0   ,Coeff Air Resistance -B
                            '                                       5   12    63     ,2,i,j))',   0   ,
                        Next
                        For k = 1 To 4
                            NewAlt.DutyZone(k) = .CVS(.DatBase(5, 65 + (k - 1) * 16, 2, i, recIalt)) ',   0   ,65+(i-1)*16 oppure 1+(i-5)*16 della SK 6
                            NewAlt.TempOut(k) = .CVS(.DatBase(5, 67 + (k - 1) * 16, 2, i, recIalt)) ',   0   ,
                            NewAlt.MWHCOut(k) = .CVS(.DatBase(5, 69 + (k - 1) * 16, 2, i, recIalt)) ',   0   ,
                            NewAlt.CondHC(k) = .CVS(.DatBase(5, 71 + (k - 1) * 16, 2, i, recIalt)) ',   0   ,
                            NewAlt.CondST(k) = .CVS(.DatBase(5, 73 + (k - 1) * 16, 2, i, recIalt)) ',   0   ,
                            NewAlt.LunghZona(k) = .CVS(.DatBase(5, 75 + (k - 1) * 16, 2, i, recIalt)) ',   0   ,
                            NewAlt.Reserved(k) = .CVS(.DatBase(5, 77 + (k - 1) * 16, 2, i, recIalt)) ',   0   ,
                            NewAlt.codZona(k) = .CVS(.DatBase(5, 79 + (k - 1) * 16, 2, i, recIalt)) ',   0   ,1 cond., 0 no
                            '   6    1     1     ,2,i,j))',   0   ,dummy
                        Next
                        For k = 5 To 12
                            NewAlt.DutyZone(k) = .CVS(.DatBase(6, 65 + (k - 9) * 16, 2, i, recIalt)) ',   0   ,65+(i-1)*16 oppure 1+(i-5)*16 della SK 6
                            NewAlt.TempOut(k) = .CVS(.DatBase(6, 67 + (k - 9) * 16, 2, i, recIalt)) ',   0   ,
                            NewAlt.MWHCOut(k) = .CVS(.DatBase(6, 69 + (k - 9) * 16, 2, i, recIalt)) ',   0   ,
                            NewAlt.CondHC(k) = .CVS(.DatBase(6, 71 + (k - 9) * 16, 2, i, recIalt)) ',   0   ,
                            NewAlt.CondST(k) = .CVS(.DatBase(6, 73 + (k - 9) * 16, 2, i, recIalt)) ',   0   ,
                            NewAlt.LunghZona(k) = .CVS(.DatBase(6, 75 + (k - 9) * 16, 2, i, recIalt)) ',   0   ,
                            NewAlt.Reserved(k) = .CVS(.DatBase(6, 77 + (k - 9) * 16, 2, i, recIalt)) ',   0   ,
                            NewAlt.codZona(k) = .CVS(.DatBase(6, 79 + (k - 9) * 16, 2, i, recIalt)) ',   0   ,1 cond., 0 no
                        Next
                        For k = 1 To 16
                            NewAlt.Nfile(k) = .CVS(.DatBase(7, 1 + 2 * (k - 1), 2, i, recIalt)) ',   0   ,N. file 1  passo
                            '                                       7    3     3     ,2,i,j))',   0   ,N. file 2  passo
                            '                                       7    4     5     ,2,i,j))',   0   ,N. file 3  passo
                            '                                       7    5     7     ,2,i,j))',   0   ,N. file 4  passo
                            '                                       7    6     9     ,2,i,j))',   0   ,N. file 5  passo
                            '                                       7    7    11     ,2,i,j))',   0   ,N. file 6  passo
                            '                                       7    8    13     ,2,i,j))',   0   ,N. file 7  passo
                            '                                       7    9    15     ,2,i,j))',   0   ,N. file 8  passo
                            '                                       7   10    17     ,2,i,j))',   0   ,N. file 9  passo
                            '                                       7   11    19     ,2,i,j))',   0   ,N. file 10 passo
                            '                                       7   12    21     ,2,i,j))',   0   ,N. file 11 passo
                            '                                       7   13    23     ,2,i,j))',   0   ,N. file 12 passo
                            '                                       7   14    25     ,2,i,j))',   0   ,N. file 13 passo
                            '                                       7   15    27     ,2,i,j))',   0   ,N. file 14 passo
                            '                                       7   16    29     ,2,i,j))',   0   ,N. file 15 passo
                            '                                       7   17    31     ,2,i,j))',   0   ,N. file 16 passo
                            NewAlt.Tmedia(k) = .CVS(.DatBase(7, 33 + 2 * (k - 1), 2, i, recIalt)) ',   0   ,T. med. 1  passo
                            '                                       7   26    35     ,2,i,j))',   0   ,T. med. 2  passo
                            '                                       7   27    37     ,2,i,j))',   0   ,T. med. 3  passo
                            '                                       7   28    39     ,2,i,j))',   0   ,T. med. 4  passo
                            '                                       7   29    41     ,2,i,j))',   0   ,T. med. 5  passo
                            '                                       7   30    43     ,2,i,j))',   0   ,T. med. 6  passo
                            '                                       7   31    45     ,2,i,j))',   0   ,T. med. 7  passo
                            '                                       7   32    47     ,2,i,j))',   0   ,T. med. 8  passo
                            '                                       7   33    49     ,2,i,j))',   0   ,T. med. 9  passo
                            '                                       7   34    51     ,2,i,j))',   0   ,T. med. 10 passo
                            '                                       7   35    53     ,2,i,j))',   0   ,T. med. 11 passo
                            '                                       7   36    55     ,2,i,j))',   0   ,T. med. 12 passo
                            '                                       7   37    57     ,2,i,j))',   0   ,T. med. 13 passo
                            '                                       7   38    59     ,2,i,j))',   0   ,T. med. 14 passo
                            '                                       7   39    61     ,2,i,j))',   0   ,T. med. 15 passo
                            '                                       7   40    63     ,2,i,j))',   0   ,T. med. 16 passo
                        Next
                        NewAlt.WidthMFVC = .CVS(.DatBase(7, 65, 2, i, recIalt)) ',   0   ,Width x fasci sotto vent.comune
                        NewAlt.AltzDivergente = .CVS(.DatBase(7, 67, 2, i, recIalt)) ',   0   ,Altezza divergente
                        NewAlt.GiocosuDiametro = .CVS(.DatBase(7, 69, 2, i, recIalt)) ',   0   ,Rapporto gioco/diametro
                        NewAlt.LunghFascioEff = .CVS(.DatBase(7, 71, 2, i, recIalt)) ',   0   ,Lunghezza efficace fascio
                        NewAlt.Tarpal = .CVS(.DatBase(7, 73, 2, i, recIalt)) ',   0   ,Temp aria sulle pale
                        NewAlt.HPmotor = .CVS(.DatBase(7, 75, 2, i, recIalt)) ',   0   ,HP-Motor
                        NewAlt.AddStaticPressure = .CVS(.DatBase(7, 77, 2, i, recIalt)) ',   0   ,Addit. static pressure
                        NewAlt.UExternal = .CVS(.DatBase(7, 79, 2, i, recIalt)) ',   0   ,U-External
                        NewAlt.UBare = .CVS(.DatBase(7, 81, 2, i, recIalt)) ',   0   ,U-Bare
                        NewAlt.Vfan = .CVS(.DatBase(7, 83, 2, i, recIalt)) ',   0   ,V@fan
                        NewAlt.NtotVentilatori = .CVS(.DatBase(7, 85, 2, i, recIalt)) ',   0   ,N. tot. ventilatori
                        NewAlt.WidtheffFST = .CVS(.DatBase(7, 87, 2, i, recIalt)) ',   0   ,width eff. con F.S.T.
                        NewAlt.Widtheff = .CVS(.DatBase(7, 89, 2, i, recIalt)) ',   0   ,width effective    
                        NewAlt.percdifftot = .CVS(.DatBase(7, 91, 2, i, recIalt)) ',   0   ,% diff tot          
                        NewAlt.MTD_AVG = .CVS(.DatBase(7, 93, 2, i, recIalt)) ',   0   ,MTD-AVG            
                        NewAlt.deltaPtot = .CVS(.DatBase(7, 95, 2, i, recIalt)) ',   0   ,deltaP totali      
                        NewAlt.SupLisciaTot = .CVS(.DatBase(7, 97, 2, i, recIalt)) ',   0   ,Superficie liscia totale
                        NewAlt.SupEstesaTot = .CVS(.DatBase(7, 99, 2, i, recIalt)) ',   0   ,Superficie esterna totale
                        NewAlt.SCFM = .CVS(.DatBase(7, 101, 2, i, recIalt)) ',   0   ,SCFM
                        NewAlt.ACFM = .CVS(.DatBase(7, 103, 2, i, recIalt)) ',   0   ,ACFM
                        NewAlt.TipSpeed = .CVS(.DatBase(7, 105, 2, i, recIalt)) ',   0   ,Tip speed
                        NewAlt.HPfan = .CVS(.DatBase(7, 107, 2, i, recIalt)) ',   0   ,HP-Fan
                        NewAlt.StaticPressure = .CVS(.DatBase(7, 109, 2, i, recIalt)) ',   0   ,Static Pressure Tot
                        NewAlt.AngoloPale = .CVS(.DatBase(7, 111, 2, i, recIalt)) ',   0   ,Angolo pale 
                        NewAlt.TariaOut = .CVS(.DatBase(7, 113, 2, i, recIalt)) ',   0   ,T aria out
                        NewAlt.DiaVent = .CVS(.DatBase(7, 115, 2, i, recIalt)) ',   0   ,Dia. ventilatore
                        NewAlt.DbocchOut = .CVS(.DatBase(7, 117, 2, i, recIalt)) ',   0   ,Dbocch.out
                        NewAlt.DBocchIn = .CVS(.DatBase(7, 119, 2, i, recIalt)) ',   0   ,Dbocch.in
                        NewAlt.FaceVelocity = .CVS(.DatBase(7, 121, 2, i, recIalt)) ',   0   ,Face Velocity
                        NewAlt.LunghezzaFascio = .CVS(.DatBase(7, 123, 2, i, recIalt)) ',   0   ,Lunghezza fascio
                        NewAlt.LarghezzaFascio = .CVS(.DatBase(7, 125, 2, i, recIalt)) ',   0   ,Larghezza fascio
                        NewAlt.NumUnit = .CVS(.DatBase(7, 127, 2, i, recIalt)) ',   0   ,N. di unità
                        NewItem.NumALt += 1
                        NewItem.Alterns.Add(NewAlt)
                    End If
                Next
                objPRV.Items.Add(NewItem)
            Next
            .Close()
        End With
        AggStatusB()
    End Sub
    Sub OpzCamini()
        If actPRV.OpCamini < 1 Or actPRV.OpCamini > 2 Then actPRV.OpCamini = 1
        Apert.optCamini(actPRV.OpCamini - 1).Checked = True
    End Sub
    Sub Riversx(ByRef Dom As String, ByRef Risp As String, ByRef iF2 As Integer)
        Static Xg(2) As Single
        Static Nzona As Short
        Static Testo As String
        Static i As Short
        Static Dt, D, M As Single
        Static j As Short
        Static dH, Con As Single
        Nzona = Val(Mid(Dom, 6, 2))
        Testo = Mid(Dom, 22, 2)
        Select Case Testo
            Case "IA" 'duty
                D = RDUT.Duty * (ProblWLD.Hzone(Nzona + 1) - ProblWLD.Hzone(Nzona)) / (ProblWLD.Hzone(ProblWLD.NZONE + 1) - ProblWLD.Hzone(1))
                Risp = D.ToString.PadRight(12)
            Case "DO" 'Tout
                Risp = ProblWLD.Tzone(Nzona).ToString.PadRight(12)
            Case "VA" 'peso mol
                i = 1
                Do
                    FileGet(iF2, Curva, i)
                    If Curva.Temp < ProblWLD.Tzone(Nzona + 1) Then Exit Do
                    If EOF(iF2) Then Exit Do
                    i = i + 1
                Loop
                FileGet(iF2, Curva0, i - 1)
                Dt = Curva.Temp - Curva0.Temp
                M = 0.0!
                If Dt <> 0.0! Then M = Curva0.MolG + (ProblWLD.Tzone(Nzona + 1) - Curva0.Temp) / Dt * (Curva.MolG - Curva0.MolG)
                If M = 0.0! Then M = Curva.MolG
                Risp = M.ToString.PadRight(12)
            Case "ID" 'Cond HC
                For j = 1 To 2
                    i = 1
                    Do
                        FileGet(iF2, Curva, i)
                        If Curva.Entl < ProblWLD.Hzone(Nzona + j - 1) Then Exit Do
                        If EOF(iF2) Then Exit Do
                        i = i + 1
                    Loop
                    FileGet(iF2, Curva0, i - 1)
                    dH = Curva.Entl - Curva0.Entl
                    Xg(j) = 0.0!
                    If Dt <> 0.0! Then Xg(j) = Curva0.Xgas + (ProblWLD.Hzone(Nzona + j - 1) - Curva0.Entl) / dH * (Curva.Xgas - Curva0.Xgas)
                    If Xg(j) = 0.0! Then Xg(j) = Curva.Xgas
                    If Xg(j) > 100.0! Then Xg(j) = 100.0!
                    If Xg(j) < 0.0! Then Xg(j) = 0.0!
                Next j
                Con = (Xg(1) - Xg(2)) * RDUT.VHC / 100.0!
                Risp = Con.ToString.PadRight(12)
            Case "AC" 'Cond acqua
        End Select
    End Sub
    Sub DatiCos4(ByRef Mode As Short, ByRef iVec As Short)
        Dim Tit(10) As String
        Dim Testo As String
        Dim Dom1(27) As String
        Dim Risp1(27) As String
        Dim Risposta As String
        Dim icount, k As Short
        Dim Mat(100) As String
        Dim iMat(100) As Short
        Dim cMat(100) As Short
        Dim Cod As Short
        Dim ALt(32) As String
        ReDim Archiv(27)
        ReDim Aiuto(27)
        ReDim Risp(100)
        ReDim Dom(27)
        Dim iF2, n, iMostra As Short
        Dim i, j As Short
        Dim dinu As Boolean
        Dim locjob As RoutBase1.clsjob
        Select Case iVec
            Case 0 : locjob = job
            Case 1 : locjob = job1
            Case Else : Stop
        End Select
        '-----------------
        OKDati = True
        If Asc(locjob.Comm.Ind(2).Data.Assieme) < 33 Then
            altern(0)
            Do
                System.Windows.Forms.Application.DoEvents()
            Loop Until Monitor.Motore.InputForms Is Nothing
        End If
        If Mode = 0 Then iMostra = -1 Else iMostra = 1
1000:   locjob.Comm.peso = 0.0! 'non si calcola
        n = Val(locjob.Comm.Ind(2).Data.Assieme)
        ItemnSt = locjob.Comm.Ind(1).Data.Assieme.Trim
        SETRDIT(ItemnSt, Nrdit)
        SETALT(n)
        IO.File.Delete(Monitor.Motore.Inizio.DiscoTem & RTrim(job.Contratto))
1010:   HTRI4(n)
        iF2 = FreeFile()
1020:   FileOpen(iF2, Monitor.Motore.Inizio.DiscoTem & RTrim(job.Contratto), OpenMode.Input)
        Risposta = LineInput(iF2)
        If Left(Risposta, 1) = "<" Then
            '     Testo = "Si e' determinata la seguente condizione di errore:|" + Risp + chr$(124)
            'Testo = Testo + "Ricontrollare i dati di input.                     |"
            Testo = at1(200 + 34) & Risposta & Chr(124) & at1(200 + 35)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.Inizio. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Testo = Monitor.Motore.Inizio.ConvertiCr(Testo)
            MsgBox(Testo, MsgBoxStyle.Information)
        Else
            FileClose(iF2)
            FileOpen(iF2, Monitor.Motore.Inizio.DiscoTem & RTrim(job.Contratto), OpenMode.Input)
        End If
1030:   For i = 1 To 27
            Dom(i) = LineInput(iF2)
            If i = 24 Then
                Do
                    Testo = LineInput(iF2)
                    If Left(Testo, 2) = " C" Then Exit Do
                    Testo = Right(Testo, Len(Testo) - 1)
                    For k = 0 To 2
                        Mat(icount) = Mid(Testo, 6 + k * 21, 16)
                        iMat(icount) = Val(Mid(Testo, 1 + k * 21, 4))
                        cMat(iMat(icount)) = icount
                        If Asc(Mat(icount)) > 32 Then icount = icount + 1
                    Next k
                Loop
                k = InStr(Testo, ":")
                Cod = Val(Right(Testo, Len(Testo) - k))
                If Cod < 2 Or Cod > 5 Then Cod = 2
                Risp(i) = "(" & Trim(Mat(cMat(Cod))) & ")"
                icount = icount - 1
            Else
                Risp(i) = LineInput(iF2)
            End If
        Next i
        FileClose(iF2)
        IO.File.Delete(Monitor.Motore.Inizio.DiscoTem & RTrim(job.Contratto))
        'Tit$(1) = "Unita'"
        'Tit$(2) = "Sezioni"
        'Tit$(3) = "Ventilatori"
        Tit(1) = at1(200 + 65) : Tit(2) = at1(200 + 66) : Tit(3) = at1(200 + 67)
        dinu = False
rifa:
        '-------------------------------------------------------
        Apert.Enabled = False
        FaseDati = 4
        For j = 1 To 3
            For i = 1 To Dati.iC(13, j)
                Dom1(i) = Dom(Dati.iC(i, j))
                Risp1(i) = Left(Risp(Dati.iC(i, j)), Len(Risp(Dati.iC(i, j))) - 1)
                Risp1(i) = Right(Risp1(i), Len(Risp1(i)) - 1)
            Next i
501:        Select Case j
                Case 1
                    If Not dinu Then Risposta = Risp1(2)
                    Risp1(2) = Left(Risposta, 1)
                    'Dom1$(2) = " N. OF FANS/UNIT"
                    Dom1(2) = at1(200 + 58)
                    Archiv(2) = 109
                    Risp1(3) = Mid(Risposta, 2, 1)
                    Archiv(3) = 100
                    'Dom1$(3) = " KIND OF DRAFT"
                    Dom1(3) = at1(200 + 59)
                    Risp1(4) = Mid(Risposta, 3, 1)
                    Archiv(4) = 101
                    'Dom1$(4) = " AIR PLENUM"
                    Dom1(4) = at1(200 + 60)
                    Risp1(5) = Mid(Risposta, 4, 1)
                    Archiv(5) = 102
                    'Dom1$(5) = " TRANSMISSION"
                    Dom1(5) = at1(200 + 61)
                    Risp1(6) = Mid(Risposta, 5, 1)
                    Archiv(6) = 103
                    'Dom1$(6) = " POSITION OF DRIVE"
                    Dom1(6) = at1(200 + 62)
                Case 2
503:                If Risp1(8) <> "NO" And Risp1(8) <> "YE" Then Risp1(8) = "NO"
                    For i = 1 To Dati.iC(13, j) : Archiv(i) = 0 : Next
                    Archiv(8) = 105 : Archiv(6) = 108
                    'DA COMPLETARE
                    'N° di sections shaft pass-through
                    ''' Archiv(2) = 9999 'codice per un bottone con evento
                Case 3
                    For i = 1 To Dati.iC(13, j) : Archiv(i) = 0 : Next
                    Archiv(4) = 106
                    Archiv(8) = 107
                    Archiv(10) = 43
            End Select
RIFA2:
505:        If Not (AddDistinta = 300 And (j = 1 Or j = 3) Or AddDistinta = 3 And (j = 1 Or j = 2)) Then
                Monitor.Motore.Chiamante = Monitor
                Monitor.Motore.InputDatiM(j * iMostra, Dati.iC(13, j), Tit(j), Dom1, Risp1, "", Archiv, Aiuto)
                If j = 1 Then
                    Monitor.Motore.InputForms(1 - 1).Top = 40
                    Monitor.Motore.InputForms(1 - 1).Left = Apert._Frames_1.Width
                End If
            End If
        Next j
        '512 If Not OK Then Mode = 1: dinu = True: GoTo rifa
        'Close #iF2
        '-------------------------------------
        Risp1(1) = Mid(Risp(1), 2, 2)
        '513 If AddDistinta <> 3 Then
        Dom1(1) = at1(200 + 106) '"ENGINEER  :"
        'Help$ = "Sigla dell'autore del preventivo"
514:    Testo = at1(200 + 80) : Archiv(1) = 0
        If AddDistinta < 300 Then
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.Chiamante. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Monitor.Motore.Chiamante = Monitor
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.InputDatiM. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Monitor.Motore.InputDatiM(4 * iMostra, 1, Testo, Dom1, Risp1, "", Archiv, Aiuto)
        End If
        'End If
        '-------------------------------------------
        If Mode = 0 Then Monitor.Motore_OkInput(Monitor.Motore.InputForms.Count)
        Exit Sub
ErrCos4: MsgBox("Err DatiCos4" & ErrorToString() & Str(Erl())) ': End
        Resume Next
    End Sub
    Sub DatiCos6(ByRef Mode As Short, ByRef iVec As Short)
        Dim Dom2(6, 4) As String
        Dim Risp2(6, 4) As String
        Dim iF2 As Short
        Dim iTipo, i As Short
        Dim Dom(6) As String
        Dim Risp(6) As String
        Dim Testo As String
        Dim Diam, Dial
        Dim i5, i6 As Short
        Dim PAS, srat As Single
        Dim Tit As String
        Dim iF3 As Short
        Dim j, i2, iOKPRO As Short
        ReDim Archiv(6)
        ReDim Aiuto(6)
        Try
            OKDati = True
            If IO.File.Exists(Monitor.Motore.Inizio.DiscoTem & RTrim(job.Contratto)) Then
                FileClose(iF3)
                IO.File.Delete(Monitor.Motore.Inizio.DiscoTem & RTrim(job.Contratto))
            End If
352:        HTRI6()
            iF2 = FreeFile()
353:        FileOpen(iF2, Monitor.Motore.Inizio.DiscoTem & RTrim(job.Contratto), OpenMode.Input)
            If LOF(iF2) > 0 Then
                iTipo = 1
                Do
                    For i = 1 To 6
                        Dom2(i, iTipo) = LineInput(iF2)
                        Risp2(i, iTipo) = LineInput(iF2)
                        If EOF(iF2) Then Exit Do
                    Next i
                    iTipo = iTipo + 1
                Loop
                FileClose(iF2)
                IO.File.Delete(Monitor.Motore.Inizio.DiscoTem & RTrim(job.Contratto))
360:            FileOpen(iF2, Monitor.Motore.Inizio.DiscoTem & RTrim(job.Contratto), OpenMode.Output)
                For j = 1 To iTipo
                    For i = 1 To 6
                        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Dom2(i, j). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Dom(i) = Dom2(i, j)
                        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Risp2(i, j). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Risp(i) = Risp2(i, j)
                    Next
361:                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Globalroutines.mystr(). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    If Val(Risp(1)) <= 0.0! Then Risp(1) = GlobalRoutines.myStr(TubeTk(j).SP, 6, 5, False)
                    If Mode = 1 Then
                        Testo = at1(200 + 54) & at1(200 + 55)
                        '    Testo = "Sono stati scelti dati geometrici non  |"
                        'Testo = Testo + "standard. Saranno quindi proposti dei  |"
                        'Testo = Testo + "valori approssimati per i coefficienti,|"
                        'Testo = Testo + "che l'utente potra' modificare.        |"
                        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.Inizio. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        MsgBox(Monitor.Motore.Inizio.ConvertiCr(Testo), MsgBoxStyle.Information)
                    End If
                    Quad = 1000.0!
                    For i1 = 1 To 6
                        If (Dati.FinInch(i1) - TubeTk(j).FinInch) ^ 2 < Quad Then
                            i2 = i1
362:                        Quad = (Dati.FinInch(i1) - TubeTk(j).FinInch) ^ 2
                        End If
                    Next
                    Fin = Dati.FinInch(i2) 'Alette/inch tubo piu prossimo
                    Quad = 1000.0!
365:                For i1 = 1 To Dati.Ntub
                        If (Dati.Tub(i1) - TubeTk(j).Diam) ^ 2 < Quad Then
                            i2 = i1
                            Quad = (Dati.Tub(i1) - TubeTk(j).Diam) ^ 2
                        End If
                    Next
                    Diam = Dati.Tub(i2) 'Diametro tubo piu prossimo
                    If TubeTk(j).Dial > 0.0! Then
                        Quad = 1000.0!
                        For i1 = 1 To 4
                            If Dati.iDial(i2, i1) > 0 Then
367:                            Scar = (Dati.Dial(Dati.iDial(i2, i1)) / Diam - TubeTk(j).Dial / TubeTk(j).Diam) ^ 2
                                If Scar < Quad Then
                                    Quad = Scar
                                    i3 = i1
                                End If
                            End If
                        Next
370:                    Dial = Dati.Dial(Dati.iDial(i2, i3))
                    Else
                        Diam = 1.5
                        Dial = 0.0!
                    End If
                    AlSt = TubeTk(j).TIPAL
                    Quad = 1000.0!
                    Cerca(Diam, Dial)
                    If Quad = 1000.0! Then
                        Quad1 = 1000.0!
                        For i5 = 1 To 4
                            AlSt = Dati.TipoFin(i5)
                            Cerca(Diam, Dial)
                            If Quad1 < Quad Then Quad = Quad1 : i6 = i5
                        Next
                        If Quad < 1000.0! Then
                            AlSt = Dati.TipoFin(i6)
                        Else
                            AlSt = TubeTk(j).TIPAL
                        End If
                    End If
                    If Quad < 1000.0! Then
                        PAS = Dati.Pas(i4)
                    Else
                        PAS = TubeTk(j).PAS
                    End If
390:                srat = (1.0! - TubeTk(j).SpAl * TubeTk(j).FinInch) * TubeTk(j).Diam
                    srat = srat + 2.0! * TubeTk(j).FinInch * (TubeTk(j).Dial ^ 2 - TubeTk(j).Diam ^ 2) / 4.0!
                    srat = srat + TubeTk(j).FinInch * TubeTk(j).Dial * TubeTk(j).SpAl
                    srat = srat / TubeTk(j).Diam
                    Risp(6) = GlobalRoutines.myStr(srat, 6, 5, False)
                    i3 = IEXIST(Diam, Dial, PAS, Fin, AlSt, AB)
                    For i1 = 1 To 4
                        If i3 = 1 Then
                            'MYSTRF(AB.A(i1), 6, 5, Itemv)
                            Risp(i1 + 1) = GlobalRoutines.myStr(AB(i1), 6, 5, 0) ' RTrim(Itemv.St)
                        Else
                            Risp(i1 + 1) = GlobalRoutines.myStr(0.0!, 6, 5, False) ' "     0.00000"
                        End If
                    Next
                    '   For i = 1 To 6: LungSt(i) = Len(Risp(i)): Next i
                    Tit = at1(200 + 109) & Str(j) ' "Tubi tipo"
rifa1:
                    If Mode = 1 Then
                        Monitor.Motore.Chiamante = Monitor
                        If Not Monitor.Motore.InputDati(6, Tit, Dom, Risp, RadiceHelp & "::/Correlaz.htm", Archiv, Aiuto) Then
                            Exit Sub
                        End If
                    End If
                    For i = 1 To 6
                        If Val(Risp(i)) = 0.0! Then
                            Testo = "I valori forniti non possono essere nulli."
                            'Testo = Testo + "     Rifai.                         |"
                            'Testo = at1(52)
                            If MsgBox(Testo, MsgBoxStyle.Critical + MsgBoxStyle.OkCancel) = MsgBoxResult.Cancel Then FileClose(iF2) : Exit Sub
                            Mode = 1
                            GoTo rifa1
                        End If
                    Next i
                    For i = 1 To 6 : PrintLine(iF2, GlobalRoutines.myStr(Val(Risp(i)), 6, 5, False)) : Next
                Next j
            End If
            FileClose(iF2)
            HTRI61() 'iOKPRO
            If IO.File.Exists(Monitor.Motore.Inizio.DiscoTem & Trim(job.Contratto)) Then
                FileOpen(iF2, Monitor.Motore.Inizio.DiscoTem & RTrim(job.Contratto), OpenMode.Input)
                If LOF(iF2) > 0 Then
                    Testo = LineInput(iF2)
                    FileClose(iF2)
                    Testo = Testo & at1(200 + 53)
                    MsgBox(Monitor.Motore.Inizio.ConvertiCr(Testo), MsgBoxStyle.Information)
                    OKDati = False
                Else
                    FileClose(iF2)
                    SubOK(iVec, OKDati)
                End If
            Else
                SubOK(iVec, OKDati)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message + vbCrLf + ex.StackTrace)
        End Try
    End Sub
    Private Sub SubOK(ByVal iVec As Integer, ByRef OKDati As Boolean)
        Dim locjob As RoutBase1.clsjob
        Select Case iVec
            Case 0 : locjob = job
            Case 1 : locjob = job1
            Case Else : Stop
        End Select
        locjob.Comm.peso = 1.0! 'si puo calcolare
        '  FilePut(1, Lav(iVec), 1 + iVec)
        OKDati = True
    End Sub
    Private Sub Cerca(ByVal Diam As Single, ByVal Dial As Single)
        Dim i1 As Integer
        For i1 = 1 To Dati.Npas
            If Dati.Pas(i1) >= Diam And Dati.Pas(i1) >= Dial Then
                i3 = IEXIST(Diam, Dial, Dati.Pas(i1), Fin, AlSt, AB)
                If i3 = 1 Then
                    Scar = (Dati.Pas(i1) / Diam - TubeTk(j).PAS / TubeTk(j).Diam) ^ 2
                    If Scar < Quad Then
                        Quad1 = Scar
                        i4 = i1
                    End If
                End If
            End If
        Next
    End Sub
    Function Interp(ByRef T As Single) As Single
        Dim i As Short
        Dim Dt, H As Single
        If LOF(100) > 0 Then
            i = 1
            Do
                FileGet(100, Curva, i)
                If Curva.Temp < T Then Exit Do
                If EOF(100) Then Exit Do
                i = i + 1
            Loop
            If i = 1 Then
                i = i + 1
                FileGet(100, Curva, i)
            End If
            FileGet(100, Curva0, i - 1)
            Dt = Curva0.Temp - Curva.Temp
            H = 0.0!
            If Dt <> 0.0! Then H = Curva.Entl + (T - Curva.Temp) / Dt * (Curva0.Entl - Curva.Entl)
            If H = 0.0! Then H = Curva.Entl
        End If
        'Close #100
        Interp = H
    End Function
    Function NZONE(ByRef Nzz As Short) As Short
        Dim Dom(2) As String
        Dim Risp(2) As String
        Dim Aiuto(2) As String
        Dim Archiv(2) As Short
        Dim Testo, Help As String
        Dim u, itp As String
        Dim n, Origineprop As Short
        n = Val(job.Comm.Ind(2).Data.Assieme)
        '   CLOSPREV()
        Ir = -CShort(objDatBase.DatBase(4, 50, Nrdit \ 2, n, itp, 0) = "SI")
        NZONE = 0
        If Nzz = 0 Then Nzz = 1
        Origineprop = objDatBase.CVI(objDatBase.DatBase(4, 74, Nrdit \ 2, n, itp, 0))
Rif1:
        If Origineprop = 0 Then
            Help = Monitor.Motore.Inizio.ConvertiCr(at1(79) & at1(80))
            Risp(2) = at1(100)
            If Ir = 0 Then Risp(2) = at1(101)
        Else
            'Dom(1) = "State lavorando in modo 'superauto-"
            Help = Monitor.Motore.Inizio.ConvertiCr(at1(57) & "|" & at1(58) & "|" & at1(59))
            'Dom(2) = "matico'. Non cambiate quindi niente"
            'Dom(3) = "delle opzioni sotto proposte! "
            Nzz = ProblWLD.NZONE
            Risp(2) = at1(100)
            Ir = 1
        End If 'C
        Risp(1) = Str(Nzz)
        Dom(1) = "Numero di zone :    " 'at1(106) ' "Numero di zone :    "
        Dom(2) = "Calcolo automatico? " 'at1(107) ' "Calcolo automatico? "
        Aiuto(1) = "" ' Monitor.Motore.Inizio.ConvertiCr(at1(65))
        Aiuto(2) = "" ' Monitor.Motore.inizio.converticr(at1(66))
        Archiv(2) = 49
        '        Apri(Trim(job.Contratto))
        IO.File.Delete("ZON1" & RTrim(job.Contratto))
        HTRI23(ProblWLD.NZONE, Ir) '0 manuale, 1 automatico
        With Monitor.Motore
            Monitor.Motore.Chiamante = Monitor
            .InputDatiM(1, 2, "Inserimento n° di zone", Dom, Risp, RadiceHelp & "::/Zone.htm", Archiv, Aiuto, Help)
            .InputForms(1 - 1).Top = 40
            .InputForms(1 - 1).Left = Apert._Frames_1.Width
            If Val(Risp(1)) = 1 Then
                .InputForms(1 - 1).ComboFisso(1).ListIndex = 0
                .InputForms(1 - 1).ComboFisso(1).Enabled = False
            End If
        End With
        'If Val(Lav(0).Assieme(4 + Nrdit \ 2 - 1)) > 0 Then Monitor.Motore.InputForms(1).Enabled = False
    End Function
    Function ZONCOND() As Boolean
        Dim LungSt1(12) As Boolean
        Dim n, i, j As Short
        Dim Dom(12) As String
        Dim Testo As String
        Dim iF2, iF1 As Short
        Dim NewF As String
        ZONCOND = True
        If RDUT.VHC = 0 And RDUT.Steam = 0 Then Exit Function
        If Ir = 0 Then Exit Function
        For i = 1 To ProblWLD.NZONE
            LungSt1(i) = False
            If Left(ProblWLD.TipZone(i), 1) = "C" Then LungSt1(i) = True
            Dom(i) = "Zona n°" & Str(i) & " condensante" ' "Zona nø" + STR$(i) + " condensante"
        Next
        Monitor.Motore.CheckQualeM(3, ProblWLD.NZONE, "Selezione zone condensanti", Dom, LungSt1, RadiceHelp & "::/ZoneAutomatiche.htm")
    End Function
    Function Check() As Short
        Dim j, j1 As Short
        Dim Testo, Testob As String
        Dim j3, j2, j4 As Short
        Dim ifl, nn, i As Short
        For i = 1 To ProblWLD.NZONE
            If ProblWLD.TipZone(i) = "C" Then
                Ib.Ialt(i) = 1
            Else
                Ib.Ialt(i) = 0
            End If
        Next
        HTRI24(Ib)
        ReDim Dom(50)
        ifl = FreeFile()
        FileOpen(ifl, Monitor.Motore.Inizio.DiscoTem & RTrim(job.Contratto), OpenMode.Input)
        i = 0
        If LOF(ifl) > 0 Then
            j = 0 : j1 = 1
            Do
                Dom(j1) = LineInput(ifl)
                Dom(j1) = Dom(j1).PadRight(25 + 3 * 44)
                j1 = j1 + 1
                If j = 0 Then nn = Val(Mid(Dom(1), 49, 2)) : j = 1
                If EOF(ifl) Then Exit Do
            Loop
            Testo = Space(0) : j4 = 0
            Apert.ListView1.Items.Clear()
            For j2 = 1 To ProblWLD.NZONE Step 4
                j4 = j4 + 1
                For j3 = 1 To j1 - 1
                    '   Testo = Testo + Mid$(Dom(j3), 1, 24) + Mid$(Dom(j3), 25 + (j4 - 1) * 44, 44) + "|"
                    Testo = Mid(Dom(j3), 1, 24) & Mid(Dom(j3), 25 + (j4 - 1) * 44, 44)
                    Apert.ListView1.Items.Add(RTrim(Testo))
                Next
            Next j2
            FileClose(ifl)
            'Testo = Monitor.Motore.inizio.ConvertiCr(Testo)
            'Testob = vbOKOnly: If nn > 0 Then Testob = vbOKCancel
            'If MsgBox(Testo, Testob) = vbCancel Then i = 1
        End If
        Check = i
    End Function
    Sub Solve(ByRef Mode As Short, ByRef Diff As Single)
        Static ErrH6 As Short
        Static Errore, Errore2 As Single
        Static Errore1 As Single
        Static NewF As String
        Static iErr As Short
        Static SR, SU As Single
        Static Riga, Help As String
        Static X As Integer
        Static iOKPRO, i, ContLoop As Short
        Static itp As String
        Static n As Short
        'On Local Error GoTo ErrSolve
        OKDati = True
        Errore2 = 0
        If Asc(LTrim(job.Comm.Ind(2).Data.Assieme)) < 33 Or Val(job.Comm.Ind(2).Data.Assieme) = 0 Then altern(0)
        n = Val(job.Comm.Ind(2).Data.Assieme)
        Ir = -CShort(objDatBase.DatBase(4, 50, Nrdit \ 2, n, itp, 0) = "SI")
        ContLoop = 0 'contatore loop
LopLop:
        ''Riga = "Iterazione sulle zone |"
        ''Riga = Riga + "numero" + STR$(BufBuf(0).Ntub)
        'Riga = at1(200+94) + Str$(BufBuf(0).Ntub)
        'Handle = Messaggio(1, Riga, 8, 8, 12, 50)
        IO.File.Delete(Monitor.Motore.Inizio.DiscoTem & RTrim(job.Contratto))
401:    HTR6B(ErrH6)
        'TrapErrFortran
        If ErrH6 > 0 Then
            MsgBox("Err HTR6B" & Str(ErrH6))
            '  CLOSE4()
            OKDati = False
            Exit Sub
        End If
402:    HTR6C(ErrH6)
        'TrapErrFortran
        If ErrH6 > 0 Then
            MsgBox("Err HTR6C" & Str(ErrH6))
            '  CLOSE4()
            OKDati = False
            Exit Sub
        End If
403:    HTRI7(ErrH6)
        'TrapErrFortran
        If ErrH6 > 0 Then
            If ErrH6 = 101 Then
                MostraAiuto(IDH_THER_HTRI7_101)
                'Monitor.Motore.RetrHelp Monitor.Motore.Inizio.Archdir + "\IT\HTRI141.TXT", , "ISA"
                'CLOSE4
                'OKDati = False
                'Exit Sub
            Else
                MostraAiuto(IDH_THER_HTRI7_ALTRI)
                'MsgBox "Errore in HTRI7 n°" + Str(ErrH6), vbCritical, "ISA"
            End If
            Apert.ListView2.Items.Clear()
            OKDati = False
            '  CLOSE4()
            Exit Sub
        End If
        FileOpen(2, Monitor.Motore.Inizio.DiscoTem & RTrim(job.Contratto), OpenMode.Input)
        If LOF(2) > 0 Then
            Help = Space(0)
            Do
                Riga = LineInput(2)
                Help = Help & Riga & "|"
                If EOF(2) Then Exit Do
            Loop
            MsgBox(Monitor.Motore.Inizio.ConvertiCr(Help), MsgBoxStyle.Information, "ISA")
        End If
        FileClose(2)
        IO.File.Delete(Monitor.Motore.Inizio.DiscoTem & RTrim(job.Contratto))
405:    HTR7C(Diff, SURFUS, SURFRQ)
        If ProblWLD.NZONE > 1 And Ir = 1 Then
            SR = 0.0! : SU = 0.0!
            For i = 1 To ProblWLD.NZONE
                SR = SR + SURFRQ(i)
                SU = SU + SURFUS(i)
            Next
            Errore = 0.0!
            For i = 1 To ProblWLD.NZONE
                SURFUS(i) = SURFUS(i) / SU
                SURFRQ(i) = SURFRQ(i) / SR
                Errore1 = System.Math.Abs((SURFUS(i) - SURFRQ(i)) / SURFUS(i))
                If Errore1 > Errore Then Errore = Errore1
                SURFRQ(i) = SURFUS(i) + 0.4 * (SURFRQ(i) - SURFUS(i))
            Next
            ContLoop = ContLoop + 1
            'SURFRQ.R(4) = 0.1
            If ContLoop < 60 And (Errore > 0.01 And System.Math.Abs((Errore - Errore2) / Errore) > 0.01) Then
                Errore2 = Errore
406:            LOOPZ(SURFRQ)
                IO.File.Delete(Monitor.Motore.Inizio.DiscoTem & RTrim(job.Contratto))
407:            HTRI62(iOKPRO)
                If iOKPRO > 1 Then
                    Apert.ListView2.Items.Clear()
                    '  CLOSE4()
                    OKDati = False
                    Exit Sub
                End If
                ' Open at1(200+64) + RTrim$(job.contratto) For Input As #2
                ' If LOF(2) > 0 Then
                '    Line Input #2, Riga$
                '    Close #2
                '      Riga$ = Riga$ + "|    Problema di convergenza:      |"
                '      Riga$ = Riga$ + "rientra in Dati Costr. e cambia la |"
                '      Riga$ = Riga$ + "lunghezza iniziale delle zone.     |"
                '     Riga = Riga + at1(200+86) + "(Sbilancio=" + Str$(Diff!) + "%)       |"
                '     MsgBox Monitor.Motore.Inizio.ConvertiCr(Riga)
                '    Close #2
                '    Call Allocat1
                '    Exit Sub
                ' End If
                ' Close #2
                ' If Len(Dir$(at1(200+64) + RTrim$(job.contratto))) > 0 Then Kill at1(200+64) + RTrim$(job.contratto)
408:            Call HTRI3(0, iErr)
                If iErr = 100 Then
                    MostraAiuto(IDH_THER_PRANDTL)
                Else
                    GoTo LopLop
                End If
            End If
        End If
        If iOKPRO = -1 Then MsgBox("Non va!")
        If Mode = 0 Then
            Apert.ListView2.Items.Clear()
            Apert.ListView2.Items.Add("Lo sbilancio calore scambiato/duty")
            Apert.ListView2.Items.Add("è del " & Str(Diff) & "%.")
            'Riga = Riga + at1(200+85)  ' "il progetto o vuoi proseguire?|    "
            '   X = MsgBox(Monitor.Motore.Inizio.converticr(Riga), vbYesNo) ' "Rifai", "Prosegui", Space$(0))
            'If X = vbNo Then Call Allocat1: Exit Sub
            Progetto(0)
            ' CLOSE4()
        End If
    End Sub
    Sub Progetto(ByRef Mode As Short)
        Dim A, NewF As String
        If Asc(LTrim(job.Comm.Ind(2).Data.Assieme)) < 33 Or Val(job.Comm.Ind(2).Data.Assieme) = 0 Then
            A = RTrim(at1(17))
            '     a$ = "Prima di eseguire un calcolo biso-|"
            'a$ = a$ + "gna identificare un'alternativa.  |"
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.Inizio. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            MsgBox(Monitor.Motore.Inizio.ConvertiCr(A))
            Exit Sub
        End If
        IO.File.Delete(Monitor.Motore.Inizio.DiscoTem & RTrim(job.Contratto))
        HTRI8(0)
        GeneraCAL(NewF)
        If Mode = 1 Then Shell("NotePad " & NewF, AppWinStyle.NormalFocus)
        'EditoreF 2, NewF$, "Risultati item " + RTrim$(job.Comm.Ind(1).Data.Assieme)
    End Sub
    Sub GeneraCAL(ByRef NewF As String)
        Dim A As String
        Dim Riga As String
        A = GlobalRoutines.myStr(CSng(Nrdit \ 2), 2, 0, True)
        If Left(A, 1) = Space(1) Then A = Chr(48) & Right(A, 1)
        NewF = CStr(Monitor.Motore.Inizio.Workdir + Chr(92) + CDbl(Left(job.Contratto, 4)) + CDbl(A) + CDbl(".CAL"))
        IO.File.Delete(NewF)
        FileCopy(Monitor.Motore.Inizio.DiscoTem & RTrim(job.Contratto), NewF)
        IO.File.Delete(Monitor.Motore.Inizio.DiscoTem & RTrim(job.Contratto))
    End Sub
    Function FillTree(ByRef Mode As Short) As Boolean
        'Mode=1 treeview'2 input
        Dim j, k As Short
        Dim Testo As String
        Dim Nodx As System.Windows.Forms.TreeNode
        Dim nItems, Answer As Short
        Dim NodBase, Nody As System.Windows.Forms.TreeNode
        Dim l As Short
        Dim ItemLoc As String
        Dim nItem As Short
        Dim Nodv As System.Windows.Forms.TreeNode
        Dim Primo, Valido As Boolean
        Dim Ventloc As String
Riprendi:
        FillTree = False
        If Mode = 1 Then Apert.TreeView1.Nodes.Clear()
        Primo = True
        For k = 1 To NumB
            NodBase = Apert.TreeView1.Nodes.Add("Ban_" & Trim(Str(k)), BankR(k), 2)
            For j = 1 To NITEB(k) - NITEB(k - 1)
                nItem = Disposiz.jcont(Disposiz.Nite(k, j))
                ItemLoc = Trim(ItemC(nItem))
                Ventloc = Trim(Disposiz.BayNome(nItem))
                'If Len(Trim(Ventloc)) = 0 Then casomai Asc(
                '   Disposiz.BayNome(nItem) = "Ven." + Trim(Str(nItem))
                '   Ventloc = Disposiz.BayNome(nItem)
                'End If
                If InStr(ItemLoc, "|") > 0 Then
                    If Primo Then
                        Nodv = Apert.TreeView1.Nodes.Find(NodBase.Name, True)(0).Nodes.Add("Ven_" & Trim(Str(nItem)), Ventloc, 4)
                        Nodx = Apert.TreeView1.Nodes.Find(Nodv.Name, True)(0).Nodes.Add("Ite_" & Trim(Str(nItem)), ItemLoc, 1)
                        Primo = False
                    Else
                        Nodx = Apert.TreeView1.Nodes.Find(Nodv.Name, True)(0).Nodes.Add("Ite_" & Trim(Str(nItem)), ItemLoc, 1)
                    End If
                Else
                    Primo = True
                    On Error GoTo ErrUniv
                    Nodv = Apert.TreeView1.Nodes.Find(NodBase.Name, True)(0).Nodes.Add("Ven_" & Trim(Str(nItem)), Ventloc, 4)
                    Nodx = Apert.TreeView1.Nodes.Find(Nodv.Name, True)(0).Nodes.Add("Ite_" & Trim(Str(nItem)), ItemLoc, 1)
                    On Error GoTo 0
                End If
                For l = 1 To 5
                    If Ialt(l, nItem) > 0 Then
                        Nody = Apert.TreeView1.Nodes.Find(Nodx.Name, True)(0).Nodes.Add("Alt_" & Trim(Str(nItem)) & "_" & Trim(Str(l)), "Alt.n°" & Str(l), 3, 3)
                    End If
                Next
            Next
        Next
        If Mode = 1 Then
            Apert.EspCom()
            If Not Apert.Ricordo Is Nothing Then
                For Each Nodx In Apert.TreeView1.Nodes
                    If Nodx.Text = Apert.Ricordo.Text Then
                        Apert.Ricordo = Nodx
                        Exit For
                    End If
                Next Nodx
                On Error Resume Next
                Apert.TreeView1_NodeClick(Nothing, New System.Windows.Forms.TreeNodeMouseClickEventArgs(Apert.Ricordo, System.Windows.Forms.MouseButtons.None, 0, 0, 0))
                Apert.Ricordo.EnsureVisible()
                'UPGRADE_NOTE: È possibile che l'oggetto Apert.Ricordo non venga eliminato in modo permanente finché non venga raccolto nel Garbage Collector. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
                Apert.Ricordo = Nothing
                On Error GoTo 0
            ElseIf Not Apert.SelNode Is Nothing Then
                For Each Nodx In Apert.TreeView1.Nodes
                    If Nodx.Text = Apert.SelNode.Text Then
                        Apert.SelNode = Nodx
                        GoTo ExFor
                    End If
                Next Nodx
                'UPGRADE_NOTE: È possibile che l'oggetto Apert.SelNode non venga eliminato in modo permanente finché non venga raccolto nel Garbage Collector. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
                Apert.SelNode = Nothing
                Exit Function
ExFor:          On Error Resume Next
                Apert.TreeView1_NodeClick(Nothing, New System.Windows.Forms.TreeNodeMouseClickEventArgs(Apert.SelNode, System.Windows.Forms.MouseButtons.None, 0, 0, 0))
                Apert.SelNode.EnsureVisible()
                On Error GoTo 0
            End If
        End If
        Apert.Command1_Click(Nothing, New System.EventArgs())
        FillTree = True
        Exit Function
Ricostruisci:
        LeggiNITE = False
        Sommari(Valido)
        GoTo Riprendi
ErrUniv:
        Select Case Err.Number
            Case 32602
                Resume Ricostruisci
            Case Else
                Testo = "Errore " & Err.Description & " durante la generazione dell'albero." & vbCrLf
                Testo = Testo & "Operazione terminata"
                MsgBox(Testo, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ISA")
        End Select
    End Function 'd
    Public Sub Prepara(ByRef j As Short)
        Dim i As Short
        Dim Tit As String
        Dim Risp(40) As String
        Dim Dom(40) As String
        Dim Tipo(14) As Short
        Dim Archiv(14) As Short
        Dim Aiuto(14) As String
        Dim Testo As String
        Select Case j
            Case 1 : Tit = "Dati generali"
            Case 2 : Tit = "Scelte di base"
            Case 3 : Tit = "Accessori"
            Case 4
                If Not Contin Then Exit Sub
                Tit = "Steam  coils"
        End Select
        For i = 1 To Dati.iC1(13, j)
            Risp(i) = Rispv.Rispv(Dati.iC1(i, j)).St
            Dom(i) = Dati.CMN1_DOM(Dati.iC1(i, j))
            Tipo(i) = Dati.CMN1_IDO(Dati.iC1(i, j), 1) ' Val(Mid(Dom(i), 21, 5))
            Archiv(i) = Dati.CMN1_IDO(Dati.iC1(i, j), 3) ' Val(Mid(Dom(i), 31, 5)) '?31
            If Tipo(i) <> 1 Then Archiv(i) = 0
            If j = 1 Then
                If i = 1 And InputDaBanco Then
                    Risp(i) = "  " + GlobalRoutines.Str2Cifre(Val(BankR(iActBank)))
                ElseIf i = 1 Then
                    Risp(i) = "  " + GlobalRoutines.Str2Cifre(Val(Risp(i)))
                End If
                If i = 6 And Len(Trim(Risp(i))) = 0 Then Risp(i) = "AL"
                If i = 7 Then
                    Select Case Trim(Risp(i))
                        Case "YES" : Contin = True
                        Case Else : Risp(i) = "NO" : Contin = False
                    End Select
                End If
            End If
            If j = 4 Then
                Dom(i) = Right(Dom(i), Len(Dom(i)) - 3)
                If Not (Dati.iC1(i, j) < 34 Or Dati.iC1(i, j) > 37) Then
                    If Dati.iC1(i, j) > 35 Then
                        Testo = objDatBase.Misur(actPRV.UnitaMisu, 1)
                    Else
                        Testo = objDatBase.Misur(actPRV.UnitaMisu, 2)
                    End If
                    Dom(i) = Dom(i) & Testo
                End If
            End If
        Next i
        If j = 1 Then
            Archiv(1) = 121
            Archiv(6) = -122
        End If
        If j = 4 Then
            Archiv(2) = 111 'BWG
            Archiv(3) = 112 'Min AVG
            Archiv(4) = 115
            Archiv(5) = -117
        End If
        With Monitor.Motore
            .Chiamante = Monitor
            .InputDatiM(j, Dati.iC1(13, j), Tit, Dom, Risp, "", Archiv, Aiuto)
            If j = 1 Then
                .InputForms(1 - 1).Top = 40
                .InputForms(1 - 1).Left = Apert._Frames_1.Width
                If InputDaBanco Then .InputForms(1 - 1).ComboFisso(0).Enabled = False
            End If
        End With
    End Sub

    Public Sub InputFun(ByRef Tit As String, ByRef iC As Short, ByRef nFin As Short)
        Dim nCol, j, n, iVal As Short
        Dim j1, savLung As Short
        Dim savRisp As String
        Dim iCv As Short
        For j = 1 To iC
            If Len(Dom(j)) > 43 Then
                Risp(j) = Dom(j).Substring(Dom(j).Length - 1 - 12)
                Dom(j) = Mid(Dom(j), 2, Len(Dom(j)) - 13)
            Else
                Risp(j) = Dom(j).Substring(Dom(j).Length - 1 - 6)
                Dom(j) = Mid(Dom(j), 2, Len(Dom(j)) - 6)
            End If
            Archiv(j) = 0
        Next j
        If ModeFun = 1 Then n = -nFin Else n = nFin
        If nFin = 3 Then
            nCol = 2
            iVal = Monitor.Motore.InputForms(2 - 1).pNinput
            For j = iC To 1 Step -1
                Dom(j + 1) = Dom(j)
                Risp(j + 1) = Risp(j)
                LungStt(j + 1 + iVal) = LungStt(j + iVal)
            Next
            Dom(1) = "" : LungStt(iVal + 1) = 0 : Risp(1) = "Valori"
            iC = iC + 1
            For j = iC + 1 To 2 * iC
                Risp(j) = ""
                LungStt(j + iVal) = 0
            Next
            Risp(iC + 1) = "@ temp."
            j = 2
            iCv = iC
            Do
                If Left(Trim(Dom(j)), 2) = ",@" Then
                    savRisp = Risp(j)
                    savLung = LungStt(j + iVal)
                    For j1 = j To iC - 1
                        Dom(j1) = Dom(j1 + 1)
                        Risp(j1) = Risp(j1 + 1)
                        LungStt(j1 + iVal) = LungStt(j1 + 1 + iVal)
                    Next
                    j1 = iCv + j - 1
                    Risp(j1) = savRisp
                    LungStt(j1 + iVal) = savLung
                    iC = iC - 1
                End If
                j = j + 1
            Loop Until j > iC
            For j = iC + 1 To 2 * iC
                Risp(j) = Risp(j + iCv - iC)
                LungStt(iVal + j) = LungStt(iVal + j + iCv - iC)
            Next
        Else
            nCol = 1
        End If
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.Chiamante. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        Monitor.Motore.Chiamante = Monitor
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.InputDatiM. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        Monitor.Motore.InputDatiM(n, iC, Tit, Dom, Risp, "", Archiv, Aiuto, , nCol)
    End Sub
    Public Sub InputD(ByRef Tit As String, ByRef iC As Short, ByRef nFin As Short)
        Dim j, iVal As Short
        InputFun(Tit, iC, nFin)
        For j = 1 To 64
            iVal = iVal + 1
            If nFin = 2 Or (nFin = 3 And j > iC) Then Valor(LungStt(iVal)) = Val(Risp(j))
        Next
    End Sub
    Public Sub SottoDatiFun(ByRef Mode As Short)
        Dim i, nFin As Short
        Dim Tit As String
        Dim Strin1(3) As String
        Dim iVal1, iQ, iC, ic1 As Short
        Dim u, Testo, itp As String
        Dim n As Short
        n = Val(job.Comm.Ind(2).Data.Assieme)
        If n = 0 Then n = 1
        If Mode = 0 Then
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto objDatBase.DatBase. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto objDatBase.CVI. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            iQ = objDatBase.CVI(objDatBase.DatBase(4, 74, Nrdit \ 2, n, itp, 0)) + 1
            If iQ > 3 Or iQ < 1 Then iQ = 1
            Strin1(1) = "Gestite da ISA"
            Strin1(2) = "Curva manuale"
            Strin1(3) = "Curva automatica"
            nFin = 1
            If ModeFun = 1 Then nFin = -1
            Monitor.Motore.QualeM(nFin, 3, "Origine proprietà del fluido", Strin1, RadiceHelp & "::/Processo.htm", iQ)
            Monitor.Motore.InputForms(1 - 1).Top = 600
            Monitor.Motore.InputForms(1 - 1).Left = Apert._Frames_1.Width
            nFin = 1
        ElseIf Mode = 1 Then
            nFin = 1
        End If
        iC = 1
        For i = 1 To 64
            If i >= 17 And i < 22 And Valor(6) = 0 Then GoTo Cont
            If i = 22 And Valor(5) = 0 Then GoTo Cont
            If i >= 23 And i <= 36 And Valor(6) = 0 And Valor(5) = 0 Then GoTo Cont
            If i >= 37 And i <= 40 And Valor(6) = 0 And Valor(5) = 0 And Valor(7) = 0 Then GoTo Cont
            If i >= 41 And i <= 42 And Valor(5) = 0 Then GoTo Cont
            If i = 44 Then
                If Valor(7) = 0 And iQ = 1 Then GoTo Cont
            End If
            If i >= 45 And Valor(4) = 0 And Valor(5) = 0 Then GoTo Cont
            Testo = objDatiFun.Buffer(i).St
            Testo = Trim(Right(Testo, Len(Testo) - 3))
            If Left(Testo, 2) = "**" Then GoTo Cont
            If Len(Trim(objDatiFun.Buffer(i).St)) = 0 Then Exit For
            If Asc(Trim(objDatiFun.Buffer(i).St)) < 32 Then Exit For
            Dom(iC) = RTrim(objDatiFun.Buffer(i).St)
            iVal1 = iVal1 + 1
            LungStt(iVal1) = i ' Val(Left$(Dom(ic), 2))
            Dom(iC) = Right(Dom(iC), Len(Dom(iC)) - 2)
            If i = 16 Then
                ic1 = 0
                If Left(Dom(iC), 1) = "2" Then iC = iC - 1 : ic1 = 1
                Tit = "Dati di processo" '(" + RIGHT$(STR$(macr), 1) + "ø giro)"
                nFin = nFin + 1
                If Mode = 0 Then
                    InputD(Tit, iC, nFin)
                End If
                If ic1 = 1 Then Dom(ic1) = Dom(iC + ic1)
                iC = ic1
            End If 'B
            iC = iC + 1
Cont:   Next i
        If iC > 1 Then
            iC = iC - 1
            Tit = "Proprietà dei fluidi" '(" + RIGHT$(STR$(macr), 1) + "ø giro)"
            nFin = nFin + 1
            InputD(Tit, iC, nFin)
        End If
        Monitor.Motore.InputForms(1 - 1).Rinfresca()
        If ModeFun = 1 And Not Monitor.Motore.InputForms Is Nothing Then Monitor.Motore_OkInput(Monitor.Motore.InputForms.Count)
    End Sub
    Public Sub TempZone()
        Dim iF1, i, j As Short
        Dim k As Short
        Dim iC, iZona As Short
        Dim Testo As String
        Dim Valor As Single
        Dim Aiuto As String
        Dim GiaL As Boolean
        ReDim Dom(50)
        ReDim Risp(100)
        ReDim Archiv(50)
        ReDim Help(50)
        If Ir = 0 And ProblWLD.NZONE > 1 Then
            iF1 = FreeFile()
            FileOpen(iF1, "ZON1" & RTrim(job.Contratto), OpenMode.Input)
            Dom(1) = ""
            For i = 1 To ProblWLD.NZONE - 1
                j = 0
                Do
                    If Not GiaL Then
                        If EOF(iF1) Then Exit Do
                        Testo = LineInput(iF1)
                        Testo = Right(Testo, Len(Testo) - 5)
                        iZona = Val(Left(Testo, 2))
                        Testo = Right(Testo, Len(Testo) - 3)
                    Else
                        GiaL = False
                    End If
                    If Not iZona = i Then GiaL = True : Exit Do
                    If j = 0 Then
                        Dom(i + 1) = "ZONA N°" & Str(i)
                    End If
                    If i = 1 Then
                        TrattaTesto()
                        Risp(j * ProblWLD.NZONE + 1) = Testo1
                    End If
                    Valor = Val(Right(Testo, 12))
                    If Valor < 10000.0# And Valor > -10000 Then
                        Testo1 = GlobalRoutines.myStr(Valor, 6, 2, False)
                    Else
                        Testo1 = Right(Testo, 12)
                    End If
                    Risp(j * ProblWLD.NZONE + i + 1) = Testo1
                    j = j + 1
                Loop
                Archiv(i) = 0 : Help(i) = ""
            Next i
            FileClose(iF1)
            Aiuto = RadiceHelp & "::/ZoneManuali.htm"
            Monitor.Motore.Chiamante = Monitor
            Monitor.Motore.InputDatiM(2, ProblWLD.NZONE, "Dati di zona", Dom, Risp, Aiuto, Archiv, Help, , j)
        Else
            If ProblWLD.NZONE > 1 Then
                iF1 = FreeFile()
                FileOpen(iF1, "ZON1" & RTrim(job.Contratto), OpenMode.Input)
                For i = 1 To ProblWLD.NZONE - 1
                    Dom(i) = LineInput(iF1)
                    If EOF(iF1) Then Exit For
                Next i
                FileClose(iF1)
                For j = 1 To ProblWLD.NZONE - 1
                    Risp(j) = Dom(j).Substring(Dom(j).Length - 1 - 12)
                    Testo = Left(Dom(j), Len(Dom(j)) - 12)
                    TrattaTesto()
                    Dom(j) = Testo1 'Left$(Dom(j), 44)
                    Archiv(j) = 0 : Help(j) = ""
                Next j
                iC = ProblWLD.NZONE - 1
            Else
                Dom(1) = "Temperatura uscita fascio"
                Risp(1) = GlobalRoutines.myStr(RDUT.TOut, 4, 2, False)
                iC = 1
            End If
            Aiuto = RadiceHelp & "::/ZoneAutomatiche.htm"
            Monitor.Motore.Chiamante = Monitor
            Monitor.Motore.InputDatiM(2, iC, "Dati di zona", Dom, Risp, Aiuto, Archiv, Help)
            If ProblWLD.NZONE = 1 Then Monitor.Motore.InputForms(2 - 1)._Text1_0.Enabled = False
        End If
        Exit Sub
    End Sub
    Private Sub TrattaTesto()
        Testo1 = Left(Testo, Len(Testo) - 12)
        n1 = InStr(Testo, "[")
        n2 = InStr(Testo, "]")
        If n1 > 0 And n2 > 0 Then
            Testo2 = Trim(Mid(Testo1, n1 + 1, n2 - n1 - 1))
            Testo1 = Left(Testo1, n1) & Testo2 & "]"
        End If
    End Sub
    Public Sub DatiCos5(ByRef Mode As Short, ByRef iVec As Short)
        Dim iF3, n As Short
        Dim SpAl As Single
        Dim i, nFin As Short
        Dim itp, u As String
        Dim j, j1 As Short
        Dim Testo As String
        Dim icount, k As Short
        Dim Mat(100) As String
        Dim iMat(100) As Short
        Dim cMat(100) As Short
        Dim Cod, i2 As Short
        Dim ALt(32) As String
        Dim i1 As Short
        Dim Dom1(32) As String
        Dim Risp1(32) As String ', Risposta As String
        Dim NewF1 As String
        ReDim Archiv(32)
        ReDim Aiuto(32)
        ReDim Risp(100)
        Dim Archiv1(32) As Short
        Dim iMostra As Short
        If AddDistinta = 3 Then Exit Sub
        Dim locjob As RoutBase1.clsjob
        Select Case iVec
            Case 0 : locjob = job
            Case 1 : locjob = job1
            Case Else : Stop
        End Select
        n = Val(locjob.Comm.Ind(2).Data.Assieme)
        If Mode = 0 Then iMostra = -1 Else iMostra = 1
        iF3 = FreeFile()
        FileOpen(iF3, Monitor.Motore.Inizio.DiscoTem & RTrim(job.Contratto), OpenMode.Input)
        IO.File.Delete("TEX1" & RTrim(job.Contratto))
        For i = 1 To Ntipi
            'AUTORIZZAZIONE NEGATA
            'CLOSPREV()
            If objDatBase.CVI(objDatBase.DatBase(4, 67 + i, Nrdit \ 2, n, itp, 0)) < 2 Then u = objDatBase.PutBasCh(4, 67 + i, Nrdit \ 2, n, objDatBase.MKI(2), 0)
            ' Apri(Trim(job.Contratto))
            For j = 1 To 12
                j1 = j : If j > 3 Then j1 = j + 1
                Testo = LineInput(iF3)
                If EOF(iF3) Then GoTo Errore
                Dom(j1) = LineInput(iF3)
                If Left(LTrim(Testo), 2) = ">>" Or Left(LTrim(Dom(j1)), 2) = ">>" Then
Errore:
                    Testo = "Errore: |" & Testo & Chr(124) & Dom(j1)
                    MsgBox(Monitor.Motore.Inizio.ConvertiCr(Testo))
                    FileClose(iF3)
                    IO.File.Delete(Monitor.Motore.Inizio.DiscoTem & RTrim(job.Contratto))
                    IO.File.Delete("TEX1" & RTrim(job.Contratto))
                    Exit Sub
                End If
                If j = 4 Then
                    Archiv(j1) = 23
                    icount = 1
                    Do
                        Testo = LineInput(iF3)
                        If Left(Testo, 2) = " C" Then Exit Do
                        Testo = Right(Testo, Len(Testo) - 1)
                        For k = 0 To 2
                            Mat(icount) = Mid(Testo, 6 + k * 23, 18)
                            iMat(icount) = Val(Mid(Testo, 1 + k * 23, 4))
                            cMat(iMat(icount)) = icount
                            If Asc(Mat(icount)) > 32 Then icount = icount + 1
                        Next k
                    Loop
                    Cod = Val(Right(Testo, Len(Testo) - 9))
                    If Cod < 2 Then Risp(j1) = Space(18) Else Risp(j1) = Mat(cMat(Cod))
                    icount = icount - 1
                ElseIf j = 12 Then
                    Do
                        Testo = LineInput(iF3)
                        If Left(Testo, 2) = " C" Then Exit Do
                    Loop
                    Cod = Val(Right(Testo, Len(Testo) - 9))
                    'If Cod < 2 Then Risp(j1) = Space$(18) Else Risp(j1) = ReadArch(10, -Cod)
                Else
                    Risp(j1) = LineInput(iF3)
                    If j <> 5 Then Risp(j1) = Right(Risp(j1), Len(Risp(j1)) - 1)
                    If j <> 5 Then Risp(j1) = Left(Risp(j1), Len(Risp(j1)) - 1)
                End If
                If j = 5 And Mid(Risp(j1), 2, 1) = "+" Then Risp(j1) = Right(Risp(j1), 5)
            Next j
            If Len(LTrim(Risp(3))) = 0 Then Risp(3) = "MIN."
            If Len(LTrim(Risp(11))) = 0 Then Risp(11) = "STD."
            Archiv(1) = -110 'tubo dia
            Archiv(2) = 111 'BWG
            Archiv(3) = 112 'Min AVG
            Archiv(10) = -113 'Diam aletta
            Archiv(7) = -114 'Pitch
            Archiv(8) = 115 'tipo alettatura
            Archiv(9) = -117 'ALETTE/INCH
            Archiv(11) = 116 'stock thickness fins
            Archiv(13) = 10 'turbolators
            Archiv(14) = 30 'T.S.joint
            Dom(4) = at1(200 + 83) '" TUBE THK. [in]"
            Risp(4) = Space(14)
            Dom(14) = at1(200 + 108) ' " TUBE/T.S. JOINT"
            Risp(14) = objDatBase.DatBase(4, 51, Nrdit \ 2, n, itp, 1).PadRight(16)
            Ndom = 14
            For i1 = 1 To Ndom
                If i1 < 7 Then
                    Esp(i1) = i1
                ElseIf i1 = 7 Then
                    Esp(i1) = 10
                ElseIf i1 > 10 Then
                    Esp(i1) = i1
                Else
                    Esp(i1) = i1 - 1
                End If
            Next
            'UpmHtr = (AddDistinta > 299)
            If UpmHtr Then
                Ndom = 13
                For i1 = 6 To Ndom : Esp(i1) = Esp(i1 + 1) : Next
            End If
            For i1 = 1 To Ndom
                Dom1(i1) = Dom(Esp(i1))
                Risp1(i1) = Risp(Esp(i1))
                Archiv1(i1) = Archiv(Esp(i1))
            Next i1
            For i1 = 1 To Ndom
                Risp(i1) = Risp1(i1)
            Next i1
            Xtub(i) = 0
            For i1 = 1 To Dati.Ntub
                If System.Math.Abs(Val(Risp(1)) - Tub(i1)) < 0.1 Then Xtub(i) = i1 : Exit For
            Next i1
            i1 = 51 : If i = 2 Then i1 = 70
            xGiun(i) = objDatBase.CVI(objDatBase.DatBase(4, i1, Nrdit \ 2, n, itp, 0)) - 1
            If xGiun(i) < 0 Or xGiun(i) > 5 Then xGiun(i) = 0
            i1 = 68 + i - 1
            Xturb(i) = objDatBase.CVI(objDatBase.DatBase(4, i1, Nrdit \ 2, n, itp, 0)) - 1
            If Xturb(i) < 0 Or Xturb(i) > 3 Then Xturb(i) = 0
            Monitor.Motore.Chiamante = Monitor
            Monitor.Motore.InputDatiM(i * iMostra, Ndom, at1(200 + 109) & Str(i), Dom1, Risp, "", Archiv1, Aiuto)
            If i = 1 Then
                Monitor.Motore.InputForms(1 - 1).Top = 40
                Monitor.Motore.InputForms(1 - 1).Left = Apert._Frames_1.Width
            End If
            If Not UpmHtr Then Monitor.Motore.InputForms(i - 1).Text1(6 - 1).Enabled = False
            Testo = Monitor.Motore.InputForms(i - 1).Combolibero(7 + UpmHtr - 1).Text
            AggiornaListaAlette(i)
            Monitor.Motore.InputForms(i - 1).Combolibero(7 + UpmHtr - 1).Text = Testo
            Testo = Monitor.Motore.InputForms(i - 1).Combolibero(8 + UpmHtr - 1).Text
            AggiornaListaPassi(i)
            Monitor.Motore.InputForms(i - 1).Combolibero(8 + UpmHtr - 1).Text = Testo
            AggiornaSpessore(i)
        Next i
        FaseDati = 5
        Apert.Enabled = False
        Dom(1) = "" : Risp(1) = "L.zona [ft]" : Risp(ProblWLD.NZONE + 1) = "N° passi"
        Archiv(1) = 0
        For i = 2 To ProblWLD.NZONE
            Dom(i) = LineInput(iF3)
            Testo = LineInput(iF3)
            Risp(i) = LineInput(iF3)
            Archiv(i) = 0
            Risp(i) = Mid(Risp(i), 2, 12)
        Next
        For i = ProblWLD.NZONE + 2 To 2 * ProblWLD.NZONE
            Risp(i) = LineInput(iF3)
        Next
        FileClose(iF3)
        nFin = Ntipi
        If ProblWLD.NZONE > 1 Then
            'If AddDistinta < 1000 Then
            Testo = "Lunghezze di zona"
            Monitor.Motore.Chiamante = Monitor
            Monitor.Motore.InputDatiM(iMostra * (Ntipi + 1), ProblWLD.NZONE, Testo, Dom, Risp, RadiceHelp & "::/ZoneLung.htm", Archiv, Aiuto, , 2)
            If Ir = 0 Then
                For i = ProblWLD.NZONE + 1 To 2 * ProblWLD.NZONE
                    Monitor.Motore.InputForms(Ntipi + 1 - 1).Text1(i - 1).Visible = False
                Next
            End If
            nFin = nFin + 1
        End If
        SalvaTEX1()
        HTRI42()
        'legge da TEX1 i dati tubi e lunghezze zona e scrive su TEXT le file per zona
        FileOpen(iF3, Monitor.Motore.Inizio.DiscoTem & RTrim(job.Contratto), OpenMode.Input)
        If LOF(iF3) > 0 Then
            i = 0
            Do
                Testo = LineInput(iF3)
                If Left(Testo, 5) = " PASS" Then
                    i = i + 1
                    Dom1(i) = LineInput(iF3)
                    Risp1(i) = LineInput(iF3)
                    Dom1(i) = Left(Dom1(i), 10) & "per" & Testo
                    Risp1(i) = Mid(Risp1(i), 3, 10)
                    Archiv(i) = 0
                    If EOF(iF3) Then Exit Do
                Else
                    '    Print "LAVORI in corso": Stop
                End If
            Loop
            Npass = i
            Testo = "N° di file per passo" '  "File / passo"
            Monitor.Motore.Chiamante = Monitor
            Monitor.Motore.InputDatiM(iMostra * (nFin + 1), i, Testo, Dom1, Risp1, "", Archiv, Aiuto)
        End If
        FileClose(iF3)
        IO.File.Delete(Monitor.Motore.Inizio.DiscoTem & RTrim(job.Contratto))
        If Mode = 0 Then Monitor.Motore_OkInput(Monitor.Motore.InputForms.Count)
        Exit Sub
        'DiaTub:
        '         For i1 = 1 To Ntub
        '         Alt(i1) = Globalroutines.mystr(Tub(i1), 6, 5, False)
        '         Next i1
        '         'Xtub = myListBox(1, 1, 1, Alt$(), Ntub, 0, at1(200+98), True)          'Diam.tubi
        '         If xTub > 0 Then Risp(1) = Alt(xTub)
        'Return
    End Sub

    Public Sub Alette(ByRef ALt() As String, ByRef Nal As Short, ByRef nFin As Short)
        'Passo in funzione di dia alett e dia tubo
        Select Case Xalett(nFin)
            Case 0 'libero
            Case 1 'noal
                If Xtub(nFin) = 1 Then
                    ALt(1) = "1.666" : ALt(2) = "1.75 "
                    ALt(3) = "1.85 " : ALt(4) = "2.00 "
                    Nal = 4
                Else
                    ALt(1) = "2.00 "
                    ALt(2) = "2.50 " : Nal = 2
                End If
                '         Xpitch = myListBox(1, 1, 1, Alt$(), Nal, 0, "Passo", True)
                '         If Xpitch > 0 Then Risp(y) = Alt$(Xpitch)
            Case 2 '1.62
                ALt(1) = "1.875"
                ALt(2) = "2.00 " : Nal = 2
                '         Xpitch = myListBox(1, 1, 1, Alt$(), 2, 0, "Passo", True)
                '         If Xpitch > 0 Then Risp(y) = Alt$(Xpitch)
            Case 3 '2.25
                ALt(1) = "2.375"
                ALt(2) = "2.50 " : Nal = 2
                '         Xpitch = myListBox(1, 1, 1, Alt$(), 2, 0, "Passo", True)
                '         If Xpitch > 0 Then Risp(y) = Alt$(Xpitch)
            Case 4 '2.5
                ALt(1) = " 2.75 "
                Nal = 1
            Case 5 '2.75
                ALt(1) = "2.75 "
                ALt(2) = "3.00 " : Nal = 2
                '         Xpitch = myListBox(1, 1, 1, Alt$(), 2, 0, "Passo", True)
                '         If Xpitch > 0 Then Risp(y) = Alt$(Xpitch)
            Case 6, 7 '3.25 3.5
                ALt(1) = " 4.00 "
                Nal = 1
        End Select

    End Sub

    Public Sub Dialett(ByRef ALt() As String, ByRef Nal As Short, ByRef nFin As Short)
        Dim i1, i2 As Short
        If Xtub(nFin) > 0 Then
            i2 = 0
            For i1 = 1 To 4
                If Dati.iDial(Xtub(nFin), i1) > 0 Then
                    i2 = i2 + 1
                    If Dati.iDial(Xtub(nFin), i1) = 1 Then
                        ALt(i2) = "Tubo nudo"
                    Else
                        ALt(i2) = GlobalRoutines.myStr(Dati.Dial(Dati.iDial(Xtub(nFin), i1)), 1, 2, False)
                    End If
                End If
            Next i1
            Nal = i2
        Else
        End If
    End Sub

    Public Sub SalvaTEX1()
        Dim i, iF4, i1 As Short
        Dim SpAl As Single
        Dim Risp1(20) As String
        Dim u As String
        Dim n As Short
        iF4 = FreeFile()
        FileOpen(iF4, "TEX1" & RTrim(job.Contratto), OpenMode.Output)
        With Monitor.Motore
            For i = 1 To Ntipi
                TubeTk(i).Diam = Val(.InputForms(i - 1).prisposte(1))
                TubeTk(i).Dial = Val(.InputForms(i - 1).prisposte(7 + UpmHtr))
                TubeTk(i).PAS = Val(.InputForms(i - 1).prisposte(8 + UpmHtr))
                TubeTk(i).TIPAL = .InputForms(i - 1).prisposte(9 + UpmHtr)
                TubeTk(i).FinInch = Val(.InputForms(i - 1).prisposte(10 + UpmHtr))
                SpAl = Val(.InputForms(i - 1).prisposte(11 + UpmHtr))
                If SpAl = 0.0! Then SpAl = 0.4 / 25.4
                TubeTk(i).SpAl = SpAl
                iMatS = .InputForms(i - 1).pComboList(5) + 2
                For i1 = 1 To Ndom
                    Risp1(Esp(i1)) = .InputForms(i - 1).prisposte(i1) : Next
                For i1 = 4 To 12 : Risp1(i1) = Risp1(i1 + 1) : Next i1
                For i1 = 1 To 12
                    If i1 <> 5 Then
                        If i1 = 4 And iMatS > 0 Then
                            PrintLine(iF4, LTrim(Str(iMatS)))
                        Else
                            PrintLine(iF4, Trim(Risp1(i1)) & "  ")
                        End If
                    End If
                Next
            Next i
            'CLOSPREV()
            n = Val(job.Comm.Ind(2).Data.Assieme)
            u = objDatBase.PutBasCh(4, 51, Nrdit \ 2, n, objDatBase.MKI(xGiun(1) + 1), 0)
            u = objDatBase.PutBasCh(4, 68, Nrdit \ 2, n, objDatBase.MKI(Xturb(1) + 1), 0)
            If Ntipi = 2 Then
                u = objDatBase.PutBasCh(4, 70, Nrdit \ 2, n, objDatBase.MKI(xGiun(2) + 1), 0)
                u = objDatBase.PutBasCh(4, 69, Nrdit \ 2, n, objDatBase.MKI(Xturb(2) + 1), 0)
            End If
            ' Apri(Trim(job.Contratto))
            i1 = Ntipi + 1
            For i = 1 To ProblWLD.NZONE - 1
                PrintLine(iF4, CStr(.InputForms(i1 - 1).prisposte(i + 1)).PadRight(12))
            Next
            For i = 1 To ProblWLD.NZONE - 1
                PrintLine(iF4, Int(.InputForms(i1 - 1).prisposte(ProblWLD.NZONE + i + 1)).ToString.PadLeft(3))
                ProblWLD.PassZone(i) = Int(.InputForms(i1 - 1).prisposte(ProblWLD.NZONE + i + 1))
            Next
            FileClose(iF4)
        End With
        SaveZone()
    End Sub
    Public Sub AggiornaListaAlette(ByRef nFin As Short)
        Dim ALt(5) As String
        Dim Nalt, i As Short
        Dialett(ALt, Nalt, nFin)
        Monitor.Motore.InputForms(nFin - 1).Combolibero(7 + UpmHtr - 1).Clear()
        For i = 1 To Nalt
            Monitor.Motore.InputForms(nFin - 1).Combolibero(7 + UpmHtr - 1).AddItem(ALt(i))
        Next
    End Sub
    Public Sub AggiornaListaPassi(ByRef nFin As Short)
        Dim ALt(5) As String
        Dim Nalt, i As Short
        SetXAlette(nFin)
        Alette(ALt, Nalt, nFin)
        Monitor.Motore.InputForms(nFin - 1).Combolibero(8 + UpmHtr - 1).Clear()
        For i = 1 To Nalt
            Monitor.Motore.InputForms(nFin - 1).Combolibero(8 + UpmHtr - 1).AddItem(ALt(i))
        Next
    End Sub
    Public Sub SetXAlette(ByRef i As Short)
        Dim i1 As Short
        Dim Testo As String
        Xalett(i) = 0
        Testo = Monitor.Motore.InputForms(i - 1).prisposte(7 + UpmHtr)
        For i1 = 1 To Dati.Ndial
            If Len(Trim(Testo)) > 0 And System.Math.Abs(Val(Testo) - Dati.Dial(i1)) < 0.1 Then Xalett(i) = i1
        Next i1
    End Sub
    Public Sub AggiornaSpessore(ByRef i As Short)
        TubeTk(i).bwg = Monitor.Motore.InputForms(i - 1).prisposte(2) ' Risp(2)
        TubeTk(i).TOL = Monitor.Motore.InputForms(i - 1).prisposte(3) 'Risp(3)
        TubeTk(i).SP = objBWG.SpFinale(TubeTk(i).bwg, TubeTk(i).TOL)
        Monitor.Motore.InputForms(i - 1).prisposte(4) = GlobalRoutines.myStr(TubeTk(i).SP, 1, 5, False) + " in"
    End Sub
    Sub Ventil1()
        Dim Testo As String
        Dim n, iErr As Short
        Dim Risult As Boolean
        If Asc(LTrim(job.Comm.Ind(2).Data.Assieme)) < 33 Or Val(job.Comm.Ind(2).Data.Assieme) = 0 Then altern(0)
        n = Val(job.Comm.Ind(2).Data.Assieme)
        ItemnSt = job.Comm.Ind(1).Data.Assieme.Trim
        SETRDIT(ItemnSt, Nrdit)
        IO.File.Delete(Monitor.Motore.Inizio.DiscoTem & RTrim(job.Contratto))
        If AddDistinta < 106 Then
            SETALT(n)
            Call HTRI3(n, iErr)
            If iErr = 100 Then
                MostraAiuto(IDH_THER_PRANDTL)
                Exit Sub
            End If
            Risult = objVentil.Esegui(AddDistinta, Nrdit, n, Trim(job.Contratto), False)
            If Risult Then OpFin()
        Else
            Stop
        End If
    End Sub
    Sub ScelMot()
        Dim itp, NewF As String
        Dim n As Short
        Dim HPFan As Single
        Dim Dom(2) As String
        Dim Risp(2) As String
        Dim Arch(2) As Short
        Dim dAiu(2) As String
        Dim Tit As String
        Dim Y As Boolean
        Dim u, Testo As String
        Dim iF3, iF4 As Short
        Dim Help As String
        n = Val(job.Comm.Ind(2).Data.Assieme)
        If Not objVentil.Esegui(101, Nrdit, n, Trim(job.Contratto), False) Then Exit Sub
        HPFan = objDatBase.CVS(objDatBase.DatBase(7, 22, Nrdit \ 2, n, itp, 0))
        Dom(1) = "Potenza all'asse ventilatore [HP]"
        Risp(1) = GlobalRoutines.myStr(HPFan, 5, 1, False)
        Dom(2) = "Potenza motore [HP]"
        Risp(2) = GlobalRoutines.myStr(HPFan * 1.07, 5, 1, False)
        Tit = "Scelta motore"
        Help = at1(23)
        Monitor.Motore.Chiamante = Monitor
        Y = Monitor.Motore.InputDati(2, Tit, Dom, Risp, Help, Arch, dAiu)
        ' CLOSPREV()
        u = objDatBase.PutBasCh(7, 23, Nrdit \ 2, n, objDatBase.MKS(Val(Risp(2))), 0)
        ' Apri(Trim(job.Contratto))
        AddDistinta = 0
        MFVC3()
        Testo = GlobalRoutines.myStr(CSng(Nrdit \ 2), 2, 0, True)
        If Left(Testo, 1) = Chr(32) Then Testo = Chr(48) & Right(Testo, 1)
        NewF = CStr(Monitor.Motore.Inizio.Workdir + Chr(92) + CDbl(Left(job.Contratto, 4)) + CDbl(Testo) + CDbl(".VEN"))
        iF3 = FreeFile()
        FileOpen(iF3, Monitor.Motore.Inizio.DiscoTem & RTrim(job.Contratto), OpenMode.Input)
        iF4 = FreeFile()
        FileOpen(iF4, NewF, OpenMode.Append)
        Do
            Testo = LineInput(iF3)
            If Len(Testo) = 0 Then Testo = Chr(32)
            If Len(Testo) < 40 And Asc(Testo) <> 49 Then Testo = Space(5) & Testo
            PrintLine(iF4, Testo)
            If EOF(iF3) Then Exit Do
        Loop
        FileClose(iF3) : FileClose(iF4) : IO.File.Delete(Monitor.Motore.Inizio.DiscoTem & Trim(job.Contratto))
        'Testo = at1(24)
        'Call Deallocat1
        Shell("NotePad " & NewF, AppWinStyle.NormalFocus)
        'EditoreF 2, NewF$, Testo + RTrim$(job.Comm.Ind(1).Data.Assieme)
        'Call Allocat1
    End Sub
    Public Sub Mappa()
        Dim NewF As String
        UPTX1()
        NewF = CStr(Monitor.Motore.Inizio.Workdir + Chr(92) + CDbl(Left(job.Contratto, 4)) + CDbl(".MAP"))
        If Len(Dir(NewF)) > 0 Then IO.File.Delete(NewF)
        FileCopy(Monitor.Motore.Inizio.DiscoTem & Trim(job.Contratto), NewF)
        Shell("NotePad " & NewF, AppWinStyle.NormalFocus)
    End Sub

    Public Sub SostNomeBanco(ByRef Vecchio As String, ByRef Nuovo As String)
        Dim i, k, n As Short
        Dim u As String
        ' CLOSPREV()
        For i = 1 To NumIt
            For k = 1 To 4
                If Bank(i, k) = Vecchio Then
                    Bank(i, k) = Nuovo
                    Select Case k
                        Case 1 : n = 2
                        Case 2 : n = 42
                        Case 3 : n = 43
                        Case 4 : n = 44
                    End Select
                    u = objDatBase.PutBasCh(2, n, i, 1, Nuovo, 0)
                End If
            Next
        Next
        '  Apri(Trim(job.Contratto))
    End Sub
    Public Function MostraAiuto(ByRef id As Integer, Optional ByRef Informa As RoutBase1.ChiaviMess = RoutBase1.ChiaviMess.MessCritical + RoutBase1.ChiaviMess.MessOkOnly, _
    Optional ByRef mioTesto As String = "", Optional ByRef mioTitolo As String = "", Optional ByVal Proportional As Boolean = False) As RoutBase1.ChiaviMess
        Dim Testo, Tit As String
        If id > 0 Then
            If Len(mioTesto) = 0 Then
                Testo = Helpstringa(id)
            Else
                Testo = Monitor.Motore.Inizio.ConvertiCr(mioTesto)
            End If
            If Len(mioTitolo) = 0 Then
                Tit = "ISA - Messaggi di errore"
                If Not Informa And RoutBase1.ChiaviMess.MessCritical Then Tit = "ISA"
            Else
                Tit = mioTitolo
            End If
            Dim Topic As String = Monitor.HelpTopic(id)
            If Topic = "" Then
                MostraAiuto = Monitor.Motore.Messaggio(Testo, Informa, Tit, RadiceHelp, Topic, Proportional:=Proportional)
            Else
                MostraAiuto = Monitor.Motore.Messaggio(Testo, Informa Or RoutBase1.ChiaviMess.MessHelpButton, Tit, RadiceHelp, Topic, Proportional:=Proportional)
            End If
        Else
            MessageBox.Show("Errore sconosciuto")
        End If
    End Function
    Public Sub ExamDBGen()
        MsgBox("Lavori in corso")
    End Sub
    Public Sub ExamDB()
        If Not PreliminItem() Then Exit Sub
        InitFlangia()
        Monitor.Motore.Inizio.Gancio = Monitor.Motore.Inizio.Workdir + "\" + CDbl("DATI.TEM")
        Funzioni.PPSM(Monitor.Motore.Inizio.DiscoRam, job, "", False)
        FineFlangia()
        Monitor.Motore.Inizio.Gancio = Monitor.Motore.Inizio.Workdir + "\" + CDbl("DATI.TE1")
    End Sub

    Public Function PreliminItem() As Boolean
        Dim Nome As String
        Dim i, j As Short
        Dim Item As String
        PreliminItem = False
        If Len(comm) = 0 Then comm = objDatBase.Readreco(1, 46, 2)
        If Len(Trim(comm)) = 0 Or Asc(comm) < 32 Then
            MostraAiuto(IDH_DB_NOCOMMESSA)
            Exit Function
        End If
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.Inizio. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        Nome = CStr(Monitor.Motore.Inizio.Workdir + "\" + CDbl(comm) + CDbl(".JOB"))
        'UPGRADE_WARNING: Dir ha un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
        If Len(Dir(Nome)) = 0 Then
            MostraAiuto(IDH_DB_MANCASTRUTTURA)
            Exit Function
        End If
        If job Is Nothing Then
            job = New RoutBase1.clsjob(Monitor.Motore)
        End If
        Item = Trim(job.Comm.Ind(1).Data.Assieme)
        If Item = "$" Then
            MostraAiuto(IDH_HTRI_ITEMNONATT)
        Else
            Dim ContrFile As String
            Monitor.Motore.Retrievejob(Nome, ContrFile)
            For i = 1 To job.Coll.Count
                job.RetrieveCom(i)
                For j = 1 To job.Comm.Ind.Count
                    If Item = Trim(job.Comm.Ind.Item(j).Data.Assieme) Then
                        job.Comm.indice = j
                        PreliminItem = True
                        Exit Function
                    End If
                Next
            Next
            MostraAiuto(IDH_DB_MANCADBITEM)
        End If
    End Function
    Public Sub SottoEliPre(ByRef NomeFile As String)
        Dim NomeCom As String
        If Len(Dir(RTrim(Monitor.Motore.Inizio.Workdir) & Chr(92) & NomeFile)) > 0 Then
            IO.File.Delete(RTrim(Monitor.Motore.Inizio.Workdir) & Chr(92) & NomeFile)
        End If
        NomeCom = Left(NomeFile, Len(NomeFile) - 4)
        NomeFile = Dir(RTrim(Monitor.Motore.Inizio.Workdir) & Chr(92) & NomeCom & ".*")
        Do While Len(NomeFile) > 0
            IO.File.Delete(RTrim(Monitor.Motore.Inizio.Workdir) & Chr(92) & NomeFile)
            NomeFile = Dir()
        Loop
        NomeFile = Dir(RTrim(Monitor.Motore.Inizio.Workdir) & Chr(92) & NomeCom & "*.*")
        Do While Len(NomeFile) > 0
            IO.File.Delete(RTrim(Monitor.Motore.Inizio.Workdir) & Chr(92) & NomeFile)
            NomeFile = Dir()
        Loop
    End Sub
    Public Sub AlternDati(ByRef n As Short)
        Dim itp As String = ""
        Dim iErr, i As Integer
        '               Ir = objDatBase.CVI(objDatBase.DatBase(2, 71, Nrdit \ 2, 1, itp, 0))
        Ir = -CShort(objDatBase.DatBase(4, 50, Nrdit \ 2, 1, itp, 0) = "SI")
        '               If Not (Ir = 0 Or Ir = 1) Then Ir = 1
        ApriPRV(Monitor.Motore.Inizio.Workdir & "\" & job.Contratto & ".PRV", actPRV, iErr)
        IO.File.Delete("ZON1" & RTrim(job.Contratto))
        HTRI23(ProblWLD.NZONE, Ir) '0 manuale, 1 automatico
        SalvaZON2()
        If ModeFun = 0 Then Apert._Frames_4.Visible = ProblWLD.NZONE > 1
        If RDUT.Duty = 0 Then
            Stop
            Exit Sub
        End If
        HTRI21()
        Check()
        If ModeFun = 0 Then
            Apert._Frames_3.Visible = True
            Apert._Frames_5.Visible = True
        End If
        SETALT(n)
        HTRI3(n, iErr)
        If iErr = 100 Then
            MostraAiuto(IDH_THER_PRANDTL)
        End If
        i = objDatBase.CVI(objDatBase.DatBase(4, 73, Nrdit \ 2, n, itp, 0))
        Apert.chkHTRI.CheckState = i
    End Sub
    Public Sub Dati4()
        Dim n, iErr As Short
        n = Val(job.Comm.Ind(2).Data.Assieme)
        ItemnSt = job.Comm.Ind(1).Data.Assieme.Trim
        SETRDIT(ItemnSt, Nrdit)
        IO.File.Delete(Monitor.Motore.Inizio.DiscoTem & RTrim(job.Contratto))
        SETALT(n)
        Call HTRI3(n, iErr)
        If iErr = 100 Then
            MostraAiuto(IDH_THER_PRANDTL)
        End If
        DatiCos4(1, 0)
    End Sub

    Public Sub Dati56()
        Dim n, iErr As Short
        n = Val(job.Comm.Ind(2).Data.Assieme)
        ItemnSt = job.Comm.Ind(1).Data.Assieme.Trim
        SETRDIT(ItemnSt, Nrdit)
        IO.File.Delete(Monitor.Motore.Inizio.DiscoTem & RTrim(job.Contratto))
        SETALT(n)
        Call HTRI3(n, iErr)
        If iErr = 100 Then
            MostraAiuto(IDH_THER_PRANDTL)
        End If
        DatiCos4(0, 0)
        Do
            System.Windows.Forms.Application.DoEvents()
        Loop Until Monitor.Motore.InputForms Is Nothing
        If Not OKDati Then Exit Sub
        DatiCos5(1, 0)
        Do
            System.Windows.Forms.Application.DoEvents()
        Loop Until Monitor.Motore.InputForms Is Nothing
        If Not OKDati Then Exit Sub
        DatiCos6(1, 0)
    End Sub

    Public Sub DefZone()
        Dim u, r As String
        'CLOSPREV()
        If Ir = 0 Then r = "NO" Else r = "SI"
        u = objDatBase.PutBasCh(4, 50, Nrdit \ 2, 1, r, 0)
        'Apri(Trim(job.Contratto))
        If Len(Dir("ZON1" & RTrim(job.Contratto))) > 0 Then IO.File.Delete("ZON1" & RTrim(job.Contratto))
        HTRI23(ProblWLD.NZONE, Ir) '0 manuale, 1 automatico
        With Monitor.Motore
            If .InputForms.Count = 3 Then
                .InputForms(3 - 1).close()
                .InputForms.Remove(3 - 1)
            End If
            .InputForms(2 - 1).close()
            .InputForms.Remove(2 - 1)
            TempZone()
            ZONCOND()
            AppActivate(.InputForms(1 - 1).Caption)
        End With
    End Sub

    Public Sub SalvaZON2()
        Dim jj, iF1, k As Short
        iF1 = FreeFile()
        IO.File.Delete("ZON2" & RTrim(job.Contratto))
        FileOpen(iF1, "ZON2" & RTrim(job.Contratto), OpenMode.Output)
        If Ir = 0 Then
            If Monitor.Motore.InputForms Is Nothing Then
                For jj = 1 To ProblWLD.NZONE * 5
                    PrintLine(iF1, "-1111.")
                Next
            Else
                For jj = 1 To ProblWLD.NZONE - 1
                    For k = 1 To Monitor.Motore.InputForms(2 - 1).nCol
                        PrintLine(iF1, Format(Val(Monitor.Motore.InputForms(2 - 1).prisposte((k - 1) * ProblWLD.NZONE + jj + 1)), "##.#########E+00"))
                    Next
                Next
            End If
        Else
            For jj = 1 To ProblWLD.NZONE
                PrintLine(iF1, ProblWLD.Tzone(jj).ToString.PadLeft(25))
            Next jj
        End If
        FileClose(iF1)
    End Sub

    Public Sub ElaboraFS()
        Dim Testo, NewF, NewF1 As String
        Dim Buffer As String
        If Len(Trim(job.Contratto)) = 0 Then
            Testo = "Non essendo aperto alcun preventivo" & vbCrLf
            Testo = Testo & "questa funzione non è disponibile"
            MsgBox(Testo, MsgBoxStyle.Information, "ISA")
            Exit Sub
        End If
        NewF = CStr(Monitor.Motore.Inizio.Workdir + "\" + CDbl(Trim(job.Contratto)) + CDbl(".TXT"))
        With Apert.CommonDialog1Save
            .InitialDirectory = Monitor.Motore.Inizio.Workdir
            .Filter = "File di testo (*.txt)|*.txt"
            .FileName = NewF
            '    .CancelError = True
            .ShowDialog()
            NewF1 = .FileName
            If Len(NewF1) = 0 Then Exit Sub
        End With
        Buffer = job.Contratto
        FOSTIMA(Buffer)
        On Error GoTo ErrCopy
        If Not UCase(NewF) = UCase(NewF1) Then
            IO.File.Delete(NewF1)
            FileCopy(NewF, NewF1)
        End If
        On Error GoTo ErrShell
        Shell("NotePad " & NewF1, AppWinStyle.NormalFocus)
ErrSave: Exit Sub
ErrCopy: MsgBox("Errore in FileCopy: " & NewF & " " & NewF1 & vbCrLf & Err.Description)
        Exit Sub
ErrShell: MsgBox("Errore al lancio di NotePad: " & Err.Description)
    End Sub


    Public Sub AbilitMenu()

    End Sub
    Public Sub AbilitaMenu0(ByRef f As Boolean)
        With Apert
            ._bigMenu_0.Enabled = f
        End With
    End Sub

    Public Sub AbilitaMenu(ByRef f As Boolean)
        With Apert
            ._bigMenu_1.Enabled = f
            ._bigMenu_2.Enabled = f
            ._bigMenu_3.Enabled = f
            ._bigMenu_4.Enabled = Not f
            ._bigMenu_5.Enabled = Not f
        End With
    End Sub
    Public Function EstrapolaRA1(ByRef Testo As String) As Integer
        Dim ifl As Short
        Dim Help As String
        If Not IO.File.Exists(Testo & ".RA1") Then
            EstrapolaRA1 = FCREARA1(1)
        Else
            ifl = FreeFile()
            FileOpen(ifl, Testo & ".RA1", OpenMode.Random, OpenAccess.ReadWrite, , Len(Curva))
            If LOF(ifl) < Len(Curva) Then
                FileClose(ifl)
                IO.File.Delete(Testo & ".RA1")
                '                               SaveZone
                EstrapolaRA1 = FCREARA1(1)
            Else
                FileClose(ifl)
                Help = GlobalRoutines.FormatS(Monitor.Motore.Inizio.ConvertiCr(Helpstringa(1103)), Testo & ".RA1")
                If MostraAiuto(IDH_THER_GIA_RA1, ChiaviMess.MessQuestion Or ChiaviMess.MessHelpButton Or ChiaviMess.MessYesNo, Help) = ChiaviMess.MessSi Then
                    IO.File.Delete(Testo & ".RA1")
                    '                               SaveZone
                    EstrapolaRA1 = FCREARA1(1)
                End If
            End If
        End If
    End Function
    Public Sub ISAWald()
        Dim n As Short
        Dim Testo As String
        Dim objWald As Wald.clsWald
        Dim iQv, iQ As Short
        Dim NewF, itp As String
        Dim u As String
        n = Val(job.Comm.Ind(2).Data.Assieme)
        If n = 0 Then
            Testo = GlobalRoutines.FormatS(Monitor.Motore.Inizio.ConvertiCr(Helpstringa(1098)), "ISAWald")
            MostraAiuto(IDH_HTRI_ALTNONATT, ChiaviMess.MessCritical Or ChiaviMess.MessOkOnly Or ChiaviMess.MessHelpButton, Testo)
            Exit Sub
        End If
        iQ = objDatBase.CVI(objDatBase.DatBase(4, 74, Nrdit \ 2, n, itp, 0)) + 1
        If iQ < 1 Or iQ > 3 Then
            iQ = 1 ': MsgBox "Errore in ISAWald, iQ=" + Str$(iQ): Exit Sub
            'CLOSPREV()
            objDatBase.PutBasCh(4, 74, Nrdit \ 2, n, objDatBase.MKI(0), 0)
            'Apri(Trim(job.Contratto))
        End If
        If iQ > 1 Then
            objWald = New Wald.clsWald
            objWald.DoveMotore = New RoutBase1.clsMotore("Wald")
            '            objWald.DoveInizio = Monitor.Motore.Inizio
            '           objWald.DoveProblem = New RoutBase1.Problem
            '          objWald.DoveAbout = New RoutBase1.About
            objWald.Inizia()
            Testo = GlobalRoutines.Str2Cifre(Nrdit \ 2)
            Testo = Testo & Trim(Str(n))
            Testo = Trim(Monitor.Motore.Inizio.Workdir) & "\" & Left(job.Contratto, 4) & Testo
            If iQ = 2 Then
                If EstrapolaRA1(Testo) Then
                    ' CLOSPREV()
                    u = objDatBase.PutBasCh(4, 74, Nrdit \ 2, n, objDatBase.MKI(0), 0)
                    'Apri(Trim(job.Contratto))
                    GoTo Fine
                End If
            End If
            objWald.EseguiDaISA(iQ, Testo, ModeAltern, actPRV.UnitaMisu)
            If iQ = 0 Then GoTo Fine
            HTRI1(-1)
            HTRI12(objDatiFun, 0)
            NewF = Testo & ".WLD" 'RA3
            Readzone(NewF)
            '------------------
            PUTTEMPZONE(ProblWLD)
Fine:
            '   objWald.DoveProblem = Nothing
            '  objWald.DoveAbout = Nothing
            ' objWald.DoveMotore = Nothing
            objWald = Nothing
        Else
            HTRI1(-1)
        End If
    End Sub
End Module
Namespace Dati
    Public Module modDati
        '-------------------------------ADAT
        Public ADAT() As Double = {0, _
           0.56481829, 0.029119593, -0.001497084756, _
           0.00003985051804, -0.0000005645177385, 0.000000004042585489, _
          -0.00000000001149269445, _
           2.8626597, -0.04455256183, 0.0003384340457, _
          -0.000001391985123, 0.00000000313480744, -0.000000000003621998523, _
           0.000000000000001675407154, _
           0.91367, 0.001315, -0.000005696, 0.000000008537, _
           1094.8, -0.59014, 0.00025118, -0.0000011016, _
           1.00054, 0.000066097489, -0.0000018453961, _
           +0.000000003066462655, -0.00000000000280482582, _
           0.00841606, 0.000018510867, 0.000000026795807, _
          -0.00000000006910134, +0.000000000000052199265, _
           0.300628, 0.000750246643, -0.0000015981408, _
           0.00000000058907225, 0.00000000000010626026}
        '--------------------------------EditEdit-----------------------
        Public LungStx1() As Integer = {0, 4, 20, 20, 20, 12, 2, 2}
        Public iC1(,) As Integer = { _
         {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, _
         {0, 2, 3, 4, 5, 16, 27, 28, 0, 0, 0, 0, 0, 7}, _
         {0, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 0, 0, 10}, _
         {0, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 0, 0, 10}, _
         {0, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 12}}
        '------------------------------ALETTC--DatiCos4-------------
        Public LungStx() As Integer = {0, 4, 20, 20, 20, 12, 2, 2}
        Public iC(,) As Integer = { _
         {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, _
         {0, 3, 2, 2, 2, 2, 2, 0, 0, 0, 0, 0, 0, 6}, _
         {0, 7, 8, 4, 5, 27, 14, 9, 22, 10, 11, 12, 13, 12}, _
         {0, 6, 15, 16, 17, 20, 21, 18, 19, 23, 24, 25, 26, 12}, _
         {0, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 12}}
        Public Ntub As Integer = 4
        Public Tub() As Single = {0, 1.0, 1.25, 1.5, 2.0}
        Public Ndial As Integer = 7
        Public Dial() As Single = {0, 0.0, 1.62, 2.25, 2.5, 2.75, 3.25, 3.5}
        Public Npas As Integer = 10
        Public Pas() As Single = {0, 1.666, 1.75, 1.85, 1.875, 2.0, 2.375, 2.5, 2.75, 3.0, 4.0}
        Public iDial(,) As Integer = { _
                                     {0, 0, 0, 0, 0}, _
                                     {0, 3, 2, 1, 0}, _
                                     {0, 4, 0, 0, 0}, _
                                     {0, 5, 1, 0, 0}, _
                                     {0, 6, 7, 0, 0}}
        Public FinInch() As Single = {0, 11.0, 10.0, 9.0, 8.5, 8.0, 7.8}
        Public TipoFin() As String = {"", "SE", "EX", "EM", "WO"}
        Public RATIO() As Single = {0, 21.18, 9.438, 1.0, 19.9, 18.6, 21.6, 16.5}
        'CF(4,13)
        Public CF(,) As Single = { _
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, _
        {0, 1.713, 0.00000165, -0.485, 0.114, 1.7528, 0.0000015, -0.66096, 0.84613, 1.76178, 0.00000088326, -0.66216, 1.01177, 1.78892}, _
        {0, 0.00000041962, -0.65227, 3.93827, 1.73444, 0.00000048, -0.63577, 3.82106, 1.63263, 0.00000073788, -0.62946, 3.88999, 1.644, 0.0000033}, _
        {0, -0.463, 0.1215, 1.593, 0.00000567, -0.424, 0.1056, 1.837, 0.00000102196, -0.63904, 2.62217, 1.79698, 0.00000054227, -0.64158}, _
        {0, 3.59272, 1.57572, 0.00000552368, -0.44886, 0.11217, 1.58704, 0.00000452936, -0.45025, 0.14016, 1.83895, 0.000000413525, -0.56328, 2.21}}
        'CCF(2,52)
        Public CCF(,) As Single = { _
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, _
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, _
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, _
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, _
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, _
        {0, 0.929, 0.96, 1.06, 0.91, 0.947, 1.04, 0.899, 1.06, 1.0, 1.0, _
                1.18, 0.847, 1.231, 0.74, 0.884, 1.155, 0.854, 1.15, 0.854, 1.279, _
                0.92, 1.22, 1.086, 1.033, 1.148, 0.89, 1.121, 0.937, 1.317, 0.892, _
                1.176, 1.019, 1.066, 1.035, 1.242, 0.98, 1.466, 0.83, 1.766, 0.735, _
                1.055, 1.133, 0.989, 1.123, 0.981, 1.253, 1.099, 1.19, 1.297, 1.008, 1.318, 0.85}, _
        {0, 0.952, 0.952, 0.952, 1.022, 0.89, 1.0, 0.89, 1.115, 0.838, 1.09, _
                0.838, 1.222, 0.925, 1.17, 0.949, 0.966, 0.942, 1.02, 0.899, 1.051, _
                1.381, 0.78, 0.892, 1.12, 0.807, 1.126, 0.807, 1.205, 0.886, 1.084, _
                1.332, 0.884, 1.294, 0.907, 1.226, 0.947, 1.227, 0.986, 1.333, 0.928, _
                2.041, 0.725, 1.222, 1.084, 1.112, 1.084, 1.112, 1.184, 1.222, 1.03, 1.601, 0.817}}
        '--------------------CMN1---------------------------------------
        '--------------------FINCOM---------------------------------------
        Public N1() As Integer = {0, 103, 105, 106, 68, 102, 72, 59, 121, 64, 66, 112, 61, 94, 93, _
                                  107, 111, 98, 77, 79, 125, 81, 82, 15, 50, 74, 49, 48}
        Public N2() As Integer = {0, 104, 96, 97, 69, 71, 70, 60, 63, 61, 88, 70, 122, 95, 109, 110, 90, _
                                  91, 78, 80, 75, 120, 92, 108, 73, 43, 18, 45}
        Public RM(2) As Single
        '-------------------------------------------------------------------------------
        Public IPC() As Integer = {0, 1, 2, 2, 3, 3, 3, 3, 3, 4, 4, 2, 6, 19, 19, 19, 7, 2, 7, 2, 8, 2, 8, 2, 9, 2, 9, 2, _
                              10, 2, 10, 2, 10, 2, 10, 2, 7, 2, 7, 2, 8, 2, 8, 2, 10, 2, 10, 2, 19, 2, 19, 2, _
                              4, 4, 2, 18, 2, 7, 2, 3, 3, 16}
        '-------------------------------------------------------------------------------
        Public NCOEFF As Integer
        Public COEFF(,) As Single = { _
 {0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}, _
 {0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}, _
 {0, 0.252, 0.55556, 0.4536, 0.070323, 1.0, 0.20482, 1.0, 1.4884, 1000.0, 1.0, 4.8824, 1.577, 1.699, 0.0047158, 25.4, 0.3048, 0.092903, 0.55552, 1.0, 25.4, 0.00508}, _
 {0, 0.29307, 0.55556, 0.4536, 6.8948, 0.7457, 0.17611, 0.001, 1.7307, 1000.0, 4.1868, 5.6783, 1.577, 1.699, 0.0047158, 0.24888, 0.3048, 0.092903, 2.326, 1.0, 25.4, 0.00508}, _
 {0, 3.9682, 1.8, 2.2046, 14.22, 1.0, 4.8824, 1.0, 0.67186, 0.001, 1.0, 0.20482, 0.63411, 0.58858, 212.05, 0.03937, 3.2808, 10.764, 1.8001, 1.0, 0.03937, 196.85}, _
 {0, 1.163, 1.0, 1.0, 98.043, 0.7457, 0.85984, 0.001, 1.1628, 1.0, 4.1868, 1.163, 1.0, 1.0, 1.0, 0.0097984, 1.0, 1.0, 4.187, 1.0, 1.0, 1.0}, _
 {0, 3.4121, 1.8, 2.2046, 0.14504, 1.341, 5.6783, 1000.0, 0.57779, 0.001, 0.23885, 0.17611, 0.63411, 0.58858, 212.05, 4.018, 3.2808, 10.764, 0.4299, 1.0, 0.03937, 196.85} _
}
        '--------------------FINCOM---------------------------------------
        '----------------------PRINCIP-----------------------------------------
        Public R(94) As Single
        Public RZ(125, 12) As Single
        '----------------HTRDU4-------------------------------
        Public LZ(12) As Integer
        '---------------------------FARFAR--------------------------------
        Public KEYP As Integer 'numero di passi con il primo tipo di tubi
        Public ICONTR As Integer
        Public NRD(8), LIM(8) As Integer
        Public DUTY, DUTYC, CHCL, CH2O, CHCV, CHIN, CONHC, CONHO, CONDST, CONDHC, _
                TAV, T, X, DUM1, DUM2, DUM3 As Single
        Public HIn, HOUT, XIN, XOUT, XVIN, XVOUT As Single
        '---------------------------FARFAR---di HTRI4-----------------------------
        'COMMON/FARFAR/IBDO,NP1,NP2,LEN1,LEN2,LEN3,LF,NR,NT,NZ,NPAS,
        '1 KEYPDM,I1,M1,M2,RKEYL,U2,U3,U4,CLEN1,CLEN2,TOTLEN,RL,RLC,RO,
        '2 RP,CLXN1,CLXN2,ROW,ROWT1,DELTAS,DELTAD,M,LZZ,KEYP
        Public IBDOI(16), OK, iOKPRO, NT, I1, NR, M1, M2, LZZ(3) As Integer
        Public NZ, LF1, LF, LEN1, LEN2, NP1, NP2, LEN3, M, KEYPDM As Integer
        'CHARACTER*2 IBDO(16)
        'EQUIVALENCE(IBDO,IBDOI)
        Public ROW, RP, U1, U2, U3, ROWT1, TUBMED, RLC, RL, RO, TOTLEN As Single
        Public RKEYL, DELTAS, DELTAD, CLEN1, CLEN2, CLXN1, CLXN2, A, U4 As Single
        '----------------------------CHX----------------------------------
        Public IPRAW(5) As Integer
        Public LOUT As Integer
        Public DatBig As String
        Public ICAL, NFAN As String
        Public NAM1(3) As String
        Public IPRE(4) As String
        Public NWPRE(3) As String
        Public ITEM1(10) As String
        Public IRISQ, MISUNI, QUOTATION As String
        Public KEY(10), NRIT(100), NITAN(100), NTAL(100), IAL(5), _
            NRAL(5, 100), NRNOT(5, 100), KEI1(5, 100) As Integer
        '------------------------CHX1-----------------------------------
        Public TOT(7, 2) As Single
        'DATA COEF/1.,1.,9.290304E-02,0.7457/                              UPT00370
        Public COEF(,) As Single = {{0, 0, 0}, _
                                   {0, 1, 0.09290304}, _
                                   {0, 1, 0.7457}}
        Public NLST(100), N1CHX1(4) As Integer
        Public IALT(100), K1(5), NITE(101), NITB(30), ITOT(7, 2) As Integer
        Public ICH, IREV As String
        Public IFO1 As String = New String("=", 116)
        Public IFO2 As String = New String("-", 116)
        Public IFO3 As String = New String(" ", 116)
        Public MIS1(2, 2), MIS2(2), ITEMDU(70), IBUF1, IBUF2 As String
        Public ISECT() As String = {"", "SECTIONS  ", _
                                        "FASCI     ", _
                                        "FAISCEAUX "}
        Public IBAY() As String = {"", "BAYS      ", _
                                       "SEZIONI   ", _
                                       "SECTIONS  "}
        Public IFAN() As String = {"", "FANS      ", _
                                       "VENTILAT. ", _
                                       "VENTILAT. "}
        Public IT1() As String = {"", " SUBTOTAL     ", _
                                      " TOTALE       ", _
                                      " TOTAL        "}
        Public IT2() As String = {"", " GRAND TOTAL  ", _
                                      " TOT. GENERALE", _
                                      " TOTAL GENERAL"}
        Public ISEE() As String = {"", "     SEE ITEM", _
                                       " VEDERE SIGLA", _
                                       "VOIR APPAREIL"}
        Public ISTCO(,) As String = {{"", "    ", "    "}, _
                                    {"", "YES ", "NO  "}, _
                                    {"", "SI  ", "NO  "}, _
                                    {"", "OUI ", "NON "}}
        Public IFMT1, IFMT2 As String
        Public BANCO(30) As String
        'Public FORMADU(70) As String
        'INTEGER*2 IBUF1I(17),IBUF2I(17)
        'EQUIVALENCE(IBUF1,IBUF1I),(IBUF2,IBUF2I)
        '  EQUIVALENCE(ITEMDU, FORMADU)
        '--------------------CHXLOC------------------------------------
        Public IA, IG, IM, NALT, ICO1, ICO2, IPR, NRF, KTOT, KOD, NL, INRA, NRA, NB As Integer
        Public KBEN, NROW, NRCD, IDG62, NGM, NUNI, NROS, N2CHXLOC, NTPAG, NR5, NR6, NWD As Integer
        Public KITE, NREAL, NPAG, NCALC, MRESTO, KK, NTOIT, K2, I2 As Integer
        Public IDG43, IDG58, LUNG, IK, NR1, J1, IK1 As Integer
        Public DROP, ASP, W As Single
        Public FORMATO, PASSERELLE, SLOPE, FORZIND As String
        '--------------------------------------------------------------------
        Public ReadOnly Property CMN1_DOM(ByVal i As Integer) As String
            Get
                Return Helpstringa(600 + i)
            End Get
        End Property
        Public CMN1_IDO(,) As Integer = { _
                                    {0, 0, 0, 0, 0, 0, 0}, _
                                    {1, 0, 1, 10, 0, 10, 0}, _
                                    {2, 0, 11, 12, 0, 2, 0}, _
                                    {3, 0, 13, 32, 0, 20, 0}, _
                                    {4, 0, 33, 42, 0, 10, 0}, _
                                    {5, 0, 105, 105, 0, 1, 0}, _
                                    {6, 1, 43, 11, 8, 7, 16}, _
                                    {7, 1, 44, 12, 8, 4, 16}, _
                                    {8, 1, 45, 12, 8, 4, 16}, _
                                    {9, 1, 46, 12, 8, 4, 16}, _
                                    {10, 1, 65, 29, 4, 2, 32}, _
                                    {11, 1, 66, 29, 4, 2, 32}, _
                                    {12, 1, 47, 13, 16, 12, 16}, _
                                    {13, 1, 48, 14, 16, 9, 192}, _
                                    {14, 1, 49, 15, 8, 8, 32}, _
                                    {15, 1, 60, 24, 16, 10, 32}, _
                                    {16, 2, 8, 0, 0, 0, 0}, _
                                    {17, 1, 51, 16, 16, 10, 48}, _
                                    {18, 1, 59, 17, 8, 8, 16}, _
                                    {19, 1, 52, 17, 8, 8, 16}, _
                                    {20, 1, 53, 18, 16, 10, 8}, _
                                    {21, 1, 67, 29, 4, 2, 32}, _
                                    {22, 1, 55, 19, 8, 8, 16}, _
                                    {23, 1, 62, 26, 8, 4, 16}, _
                                    {24, 1, 56, 27, 16, 12, 8}, _
                                    {25, 1, 58, 22, 16, 10, 8}, _
                                    {26, 1, 57, 21, 8, 8, 16}, _
                                    {27, 0, 73, 73, 0, 1, 0}, _
                                    {28, 1, 114, 29, 4, 2, 32}, _
                                    {29, 1, 61, 23, 16, 9, 96}, _
                                    {30, 0, 74, 74, 0, 1, 0}, _
                                    {31, 0, 75, 76, 0, 2, 0}, _
                                    {32, 0, 77, 77, 0, 1, 0}, _
                                    {33, 2, 1, 0, 0, 0, 0}, _
                                    {34, 2, 2, 0, 0, 0, 0}, _
                                    {35, 2, 3, 0, 0, 0, 0}, _
                                    {36, 2, 4, 0, 0, 0, 0}, _
                                    {37, 2, 5, 0, 0, 0, 0}, _
                                    {38, 1, 63, 16, 16, 10, 48}, _
                                    {39, 2, 6, 0, 0, 0, 0}, _
                                    {40, 2, 7, 0, 0, 0, 0}}
    End Module
End Namespace
Namespace UPMdati
    Module UPMDati
        '--------------UPM2------------------------------------------------
        '  COMMON/UPM2/ITR,KTR,MTR,STR,TTR,WTR,JTR,NTR,ATR,MST,ST1,DENZ,
        ' 1    YB,FNZ,FRF
        Public ITR(2), KTR(2), MTR(12), JTR(2), NTR(2), MST(12) As Integer
        Public STR(2), TTR(2), WTR(2), ST1(2), DENZ(2), YB(8), FNZ(2), FRF(2), ATR(2) As Single
        '      DIMENSION ITR(2),KTR(2),MTR(12),STR(2),TTR(2),WTR(2),JTR(2),
        '    a  NTR (2),ATR(2),MST(12),ST1(2),DENZ(2),YB(8),FNZ(2),
        '   &      FRF(2)
        '--------------UPM3------------------------------------------------
        '   COMMON/UPM3/Y1,Y2,Y3,Y4,Y5,Y6,Y7,Y8,Y9,Y10,Y11,Y12,Y13,Y14,Y15,Y16
        '1  ,Y17,D1,D2,PJ1,RKUN,KUN,Y1T,Y2T,Y3T,Y4T,Y5T,Y6T,Y7T,Y8T,XE,
        '2   ELTB,ELTM,HNC,HXNC,T1NC,T2NC,T3NC,T5NC,TO,TT1,N3,N4,N5,NA,NB,
        '3   K,KT1,I8,I9,J1,J5,JA,ELG,EQ,ES,RAPP(8),KTRON,Y15BIS,HENC
        Public N3, N4, N5, NA, NB, K, KT1, I8, I9, J1, J5, JA, KUN, KTRON As Integer
        Public Y1, Y2, Y3, Y4, Y5, Y6, Y7, Y8, Y9, Y10, Y11, Y12, Y13, Y14, Y15, Y16 As Single
        Public Y17, D1, D2, PJ1, RKUN, Y1T, Y2T, Y3T, Y4T, Y5T, Y6T, Y7T, Y8T, XE As Single
        Public ELTB, ELTM, HNC, HXNC, T1NC, T2NC, T3NC, T5NC, TO_Renamed, TT1 As Single
        Public ELG, EQ, ES, RAPP, Y15BIS, HENC As Single
        '----------UPM4-------------------------
        '  COMMON/UPM4/SBML(2),SBQL(2),STML(2),STQL(2),STL(2),SML(2)
        '     1   ,SMS,SMSN,SMSQ,SBNS,SBQS,STNS,STQS,
        '     2            TBMAX,TBMIN,TSMAX,TSMIN,PSMAX,PSMIN,
        '3:      RIGA1, RIGA2, RIGA3, ITECAS
        Public SBML(2), SBQL(2), STML(2), STQL(2), STL(2), SML(2) _
              , SMS, SMSN, SMSQ, SBNS, SBQS, STNS, STQS As Single
        Public TBMAX, TBMIN, TSMAX, TSMIN, PSMAX, PSMIN, _
                RIGA1, RIGA2, RIGA3, ITECAS As String
        'CHARACTER*1 TBMAX,TBMIN,TSMAX,TSMIN,PSMAX,PSMIN
        'CHARACTER*84 RIGA1,RIGA2,RIGA3
        'CHARACTER*32 ITECAS
        '---------------DATUPM-------------------
        '      COMMON /DATUPM/ NMM2, NMM3, INLE, INL1, ISA, IABC, INSS, ISVA
        '      CHARACTER*2 NMM2(16),NMM3(4),INLE(6),INL1(4),ISVA(8),
        '	1IABC(6),INSS(3)
        Public NMM2(16), NMM3(4), INLE(6), INL1(4), ISVA(8), _
               IABC(6), INSS(3) As String

        Public CONTROL As String 'attenzione !
        'Public MAWP, MAWPKGCM2, MAWPPSI, KTEMP, _
        ' KPJ1, LUNGF, LARGF, NFILE(16), NFMAX, PASSO(16), NASELLO, TOLL, _
        ' FBOCIN, FBOCOT, DO0, TSP, DALETT, ALINCH, SPTUB, _
        ' TVERT, H, HE, HX3, HX4, SUG, EWPS, EWC, E, HX5(16), EL(2), C(3), _
        Public C(3) As Single 'attenzione!
        ' DINMM, DOUTMM, SPINMM, SPOUTMM, PVERT, VUOTA, VUOTB, _
        ' ALTBOCIN, ALTBOCOUT, ALTFLIN, ALTFLOUT, ALARGHINTEL, XXCORR, _
        ' VUOTO(32), PACC(16), P, PJ, T, CA, T1, T2, T3, T5, XX, _
        ' BUCORINF, PASSORINF, GAP, STIFFEFF, STIFFEXX, _
        ' BF(5), DF(5), TK(5), TF(5), RATIO, XI1, XI2, SJ0(4), S(4), SJ(2) As Single
        Public NS, NFASCI, NTUB, MATHOM, IN4, NUMCAS As Integer
        'Public NROWS, NBOCIN, NBOCOT, NPAS, TIPO, NUMIT, NDUM, BCGL(2), _
        ' TIPTEST, NSFUNZ, RICORDA(4), PASSFRAZ, _
        ' PADDING(197), SALDATURA(16), CODICE, _
        ' iMATUG, iMATSH, iMATTP, iMATEN, iMATSE, iMATTUB, iMATTAP, _
        ' iMATGUAR As Short
        Public INZ1, IN3 As Short
        'Public ESIS, APERTO As Boolean
        'Public CUSTMR, PLTLOC, ENGR, HEADER, SRVICE, UNIMIS, SPBWG, SPTOL, _
        ' TIPAL, BANCO(2), LINGUA, RATING(10), HORPAS, _
        ' IRIS, IEL, IVK, ITEMNO, JOBNUM, ICKNR, IREV, _
        ' MATUG, MATSH, MATTP, MATEN, MATSE, MATTUB, MATTAP, MATGUAR As String
        'Public SCHIN, SCHOUT As String
        'Public MEC As String
        'Common/Serviz/ from RobertFORTRAN
        Public MAWP, MAWPKGCM2, MAWPPSI, KTEMP As Single
    End Module
End Namespace