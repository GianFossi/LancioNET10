Option Strict Off
Option Explicit On
Imports RoutBase1
Module mainASME
    Declare Sub COUPS Lib "AsmeLib.DLL" (ByRef NOZ1 As NozzleN, ByRef NOZ2 As NozzleN, ByRef ic As Short, ByRef fit1 As Single, ByRef fit2 As Single, ByRef fit3 As Single, ByRef Issue1 As ASMERES, ByRef Issue2 As ASMERES, ByRef File As Str50, ByRef N1 As NozzAdN, ByRef n2 As NozzAdN)
    Declare Sub Cil Lib "AsmeLib.DLL" Alias "CIL" (ByRef i As Involucro, ByRef c As asConfig, ByRef P0 As Single, ByRef tdtd As Single, ByRef T1 As Single)
    Declare Sub Cono Lib "AsmeLib.DLL" Alias "CONO" (ByRef i As Involucro, ByRef c As asConfig, ByRef P0 As Single, ByRef tdtd As Single, ByRef T1 As Single)
    Declare Sub CILPRI Lib "AsmeLib.DLL" (ByRef i As Involucro, ByRef c As asConfig, ByRef f As Str50)
    Declare Sub CONPRI Lib "AsmeLib.DLL" (ByRef i As Involucro, ByRef c As asConfig, ByRef f As Str50)
    Declare Sub OP Lib "AsmeLib.DLL" (ByRef n As NozzleN, ByRef N1 As NozzAdN, ByRef i As ASMERES)
    Declare Sub OPPRI Lib "AsmeLib.DLL" (ByRef n As NozzleN, ByRef f As Str50)
    Declare Sub Fon Lib "AsmeLib.DLL" Alias "FON" (ByRef i As Involucro, ByRef c As asConfig, ByRef P0 As Single, ByRef tdtd As Single, ByRef T1 As Single)
    Declare Sub FONPRI Lib "AsmeLib.DLL" (ByRef i As Involucro, ByRef c As asConfig, ByRef f As Str50)
    Declare Sub OPSH Lib "AsmeLib.DLL" (ByRef n As NozzleN, ByRef N1 As NozzAdN, ByRef i As ASMERES)
    Declare Sub OPSHPRI Lib "AsmeLib.DLL" (ByRef n As NozzleN, ByRef f As Str50)
    Declare Sub KELVIN Lib "MathAV.DLL" (ByRef x As Single, ByRef Ri As Short, ByRef id As Short, ByRef b As Single, ByRef Unit As Short, ByRef f As Str50)
    Declare Sub ROTFLFOR Lib "AsmeLib.DLL" (ByRef O As typROTFL)
    Public RadiceHelp As String '= "C:\BASE\ESEGUI\BIN\AsmeVIP.chm"
	Public Const IDH_CAPIENZACONDIZIONI As Short = 1000
	Public Const IDH_ELEMENTODUPLICATO As Short = 1010
	Public Const IDH_MANCAASMELIB As Short = 1020
	Public Const IDH_MANCAGEOMFLANGIA As Short = 1030
	Public Const IDH_MANCAAMMISS As Short = 1040
	Public Const IDH_MANCAGUARNIZ As Short = 1050
	Public Const IDH_MANCAMANTDIL As Short = 1051
	Public Const IDH_MANCATABMAWP As Short = 1060
	Public Const IDH_MANCATABMAT As Short = 1070
	Public Const IDH_MANCAINDMAT As Short = 1071
	Public Const IDH_CODICIDIVERSI As Short = 1072
    Public Const IDH_ERR_BADSERIAL As Integer = 1073
    Public Const IDH_MDMT1 As Short = 1080
	Public Const IDH_PT_GUAR_N As Short = 1100
	Public Const IDH_PT_GUAR_D As Short = 1101
	Public Const IDH_PT_FINESTRA As Short = 1102
	Public Const IDH_PT_AVANTINDRE As Short = 1103
	Public Const IDH_PT_AA_DIAMEXT As Short = 1104
	Public Const IDH_PT_NOOPTIM As Short = 1105
	Public Const IDH_PT_DATITUBI As Short = 1106
	Public Const IDH_PT_LEGAMI1 As Short = 1107
	Public Const IDH_PT_LEGAMI2 As Short = 1108
	Public Const IDH_PT_NOMANTELLO As Short = 1109
	Public Const IDH_PT_LEGAMI3 As Short = 1110
	Public Const IDH_PT_LEGAMI4 As Short = 1111
	Public Const IDH_PT_LEGAMI5 As Short = 1112
	Public Const IDH_DIL_DANNOMANTELLO As Short = 1150
	Public Const IDH_DIL_ESCLUDISEZ1 As Short = 1160
	Public Const IDH_XH_NUMEROLATI As Short = 2000
	Public Const IDH_XH_CALCPI As Short = 2010
	Public Const IDH_XH_NONUNIFORM As Short = 2012
	Public Const IDH_XH_RINFAPERTURE As Short = 2020
	Public Const IDH_XH_UNITSYSTEM As Short = 2030
	Public Const IDH_XH_LOADITEM As Short = 2040
	Public Const IDH_XH_MAWPCALC As Short = 2050
	Public Const IDH_XH_VESSELDIA As Short = 2060
	Public Const IDH_XH_VESSELMAT As Short = 2070
	Public Const IDH_XH_TESTPRESSURE As Short = 2080
	Public Const IDH_XH_NUMBERMEMBERS As Short = 2090
	Public Const IDH_XH_NBLOWTEMP As Short = 2100
	Public Const IDH_XH_INDINTEST As Short = 2110
	Public Const IDH_XH_FILERAPPORTO As Short = 2120
	Public Const IDH_XH_RAPPORTO As Short = 2130
	Public Const IDH_XH_RAPPCLEAR As Short = 2140
	Public Const IDH_XH_RAPPVIS As Short = 2150
	Public Const IDH_XH_RAPPVISTUTTO As Short = 2160
	Public Const IDH_XH_STRUTTURA As Short = 2170
	Public Const IDH_XH_STRUTTDATI As Short = 2180
	Public Const IDH_XH_STRUTTCALCOLI As Short = 2190
	Public Const IDH_XH_STRUTTESPANDI As Short = 2200
	Public Const IDH_XH_RISULTATI As Short = 2210
	Public Const IDH_XH_PTDATIGEN As Short = 2220
	Public Const IDH_XH_PTTIPCALC As Short = 2230
	Public Const IDH_XH_PTCONFIG As Short = 2240
	Public Const IDH_XH_PTVALORITUBI As Short = 2250
	Public Const IDH_XH_PTINTERROGATUBI As Short = 2260
	Public Const IDH_XH_PTTRACCIA As Short = 2270
	Public Const IDH_XH_PTDIVERSE As Short = 2280
	Public Const IDH_XH_PTRAPPEST As Short = 2290
	Public Const IDH_XH_PTDILATACCOPP As Short = 2300
	Public Const IDH_XH_PTFLEXESTENS As Short = 2310
	Public Const IDH_XH_PTAUTOMTIR As Short = 2320
	Public Const IDH_XH_PTESECCOMMENT As Short = 2330
	Public Const IDH_XH_PTFULLPRINT As Short = 2340
	Public Const IDH_XH_PTDIAMTIPO7 As Short = 2350
	Public Const IDH_XH_PT1DATIPIASTRA As Short = 2400
	Public Const IDH_XH_PT2DATIBULL As Short = 2500
	Public Const IDH_XH_PT3DATIPROG As Short = 2600
	Public Const IDH_XH_PT3PRESSDIFF As Short = 2610
	Public Const IDH_XH_PT3NBLOADCOND As Short = 2620
	Public Const IDH_XH_PT4FONDOFLOTT As Short = 2700
	Public Const IDH_XH_PT5DATIWELD As Short = 2800
	Public Const IDH_XH_PT6DATIFLANG As Short = 2900
	Public Const IDH_XH_PT7DATIMANT As Short = 3000
	Public Const IDH_XH_TUGENERALE As Short = 3010
	Public Const IDH_XH_TUTIPI As Short = 3020
	Public Const IDH_XH_TUTRACCIATESTO As Short = 3030
	Public Const IDH_XH_TUTRACCIARIPORTA As Short = 3040
	Public Const IDH_XH_TUTRACCIARICHIA As Short = 3050
	Public Const IDH_XH_TURAGGIOMIN As Short = 3060
	Public Const IDH_XH_TULUNGHEZZA As Short = 3070
	Public Const IDH_XH_TUDIV1DIV2 As Short = 3080
	Public Const IDH_TUB_AXIAL1 As Short = 3100
	Public Const IDH_TUB_AXIAL2 As Short = 3101
	Public Const IDH_TUB_AXIAL3 As Short = 3102
	Public Const IDH_TUB_AXIAL4 As Short = 3103
	Public Const IDH_TUB_AXIAL5 As Short = 3104
	Public Const IDH_XR_APFLANGIA As Short = 6105
	Public Const IDH_XR_BASEPIASTRA As Short = 7000
	Public Const IDH_XR_BASECONDIZIONE As Short = 7400
	Public Const IDH_XR_BASEEVENTI As Short = 7401
	Public Const IDH_OP2_SCARPA As Short = 8000
	Public Const IDH_OP2_SCARPA2 As Short = 8001
	Public Const IDH_OP2_TEMPRANGE As Short = 8002
	Public Const IDH_ST_NOANSIB165 As Short = 10000
	Public Const IDH_ST_NOWELDINGNECK As Short = 10001
	Public Const IDH_ST_HYDRDEPTHH As Short = 10002
	Public Const IDH_ST_HYDRDEPTHV As Short = 10003
	Public Const IDH_ST_PI1 As Short = 10004
	Public Const IDH_ST_PI2 As Short = 10005
	Public Const IDH_ST_PI3 As Short = 10006
	Public Const IDH_ST_PI4 As Short = 10007
	Public Const IDH_ST_PI1a As Short = 10014
	Public Const IDH_ST_PI2a As Short = 10015
	Public Const IDH_ST_PI3a As Short = 10016
	Public Const IDH_ST_PI4a As Short = 10017
	Public Const IDH_ST_TUBESHNO As Short = 10008
	Public Const IDH_WN_NOCONVER As Short = 10100
	Public Const IDH_PPSM_1 As Short = 10201
	Public Const EU_TESTINGGROUP1 As Short = 20001
	Public Const EU_TESTINGGROUP2 As Short = 20002
	Public Const EU_TESTINGGROUP3 As Short = 20003
	Public Const EU_TESTINGGROUP4 As Short = 20004
	Public Const EU_TESTINGGROUP5 As Short = 20005
    Public Const gstrSEP_DIR As String = "\"
    '----------------------------------------------------------------------------------
    Public Apparecchio As Grafica.clsApparecchio
    Public Dilatatore As Grafica.Dilat
    Public indici, indiciAttivi As LinkListSh
    Public UnLato As Boolean
	Public swn As Single
	Public iMAWP As Short
	Public UltimoAggiornamento As Short
	Public ContinuoAuto As Boolean
	Public VerificandoPI, VerificandoPext As Boolean
	Public CondizioniCorrose As Short
	Public FractSyPI As Single
	Public FlanBulDiv1 As Boolean
	Public ContBkmk As Short
	Public UG37a As Short
	Public SistCoorCop As Short
    Public OptUG40, OptUG22, OptWordIn As Boolean
	Public nTipiTubi As Short
	Public StoCalcolando As Boolean
	Public colMAWP As Collection
	Public colMDMT As Collection
	Public StoCalcolandoTutto As Boolean
	Public InterrompiMAWP As Boolean
	Public capitoli As Collection
	Public PrimaVoltaMWDT As Boolean
    Public Documento As StubW2000.clsSW2000
	Public Template As String
	Public NoHeader As Boolean
    Public SpxBExt As Single, SpBocchExt As Single '140506
	Public ElencoCollegamenti As New Collection
	Public ElencoInvolucri As Collection
    Public job As RoutBase1.clsjob
	Public objWRCB As Wrcb.clsWrcb
	Public kNozzle, jInvolucr, kLato As Short
    Public Monitor As clsMonitor
    Public FilOpen As String
    Public clsProblem As RoutBase1.clsProblem
    Public clsInizio As RoutBase1.clsInizio
    Public inizio As RoutBase1.clsInizio
    Public Routines As RoutBase1.Routines
    Public Tubo As LibMat.clsPipe
    Public Flangia As Grafica.Flangia
    Public Libgra As Grafica.LibGra
    Public nIndent As Short
    Public NAbu As Short
    Public IUNA As Short
    Public AddDistinta As Short
    Public diamNm(30) As String
    Public n(34) As String
    Public MMM(23, 30) As Single
    Public NNN(9, 34) As Single
    Public Oasme(5, 9) As Single
    Public Pasme(2, 11) As Single
    Public Qasme(2, 17) As Single
    Public x(5, 5) As String
    Public XXX(5, 80) As Single
    Public Const MAXNOZZ As Short = 30
    Public Const JRECMAX As Short = 12
    Public MaxNozAct As Short
    Public Nozzles(,) As NozzleN
    Public Involucr(,) As Involucro
    Public AdditCono(,) As AdditConN
    Public Addition1(,) As Addit1
    Public NozzAdd(,) As NozzAdN
    Public Config() As asConfig
    Public objASME As CalcASME
    Public UnitLength As String
    Public UnitArea As String
    Public UnitPress As String
    Public UnitTemp As String
    Public UnitForce As String
    Public UnitMomI As String
    Public UnitMomF As String
    Public Unitkappa As String
    Public IncrVirgola As Short
    Public kPress, kTemp, kTemp32, kLength, kForce, kMomI, kMomF, kkappa As Single
    Public icome As String
    Public DatProg As strDatiDes
    Public ModifiedData As Short
    Public DatiSh0 As strDatiShe
    Public DatiS1(3) As strDatiSh1
    Public DatiS2 As strDatiSh2
    Friend mioApert As Apert
    Friend mioPT As frmPT
    Friend mioRis As frmRis
    Friend formTab As frmTab
    Friend mioGen As frmGen
    Friend nuovoINP As Boolean
    Public myAssembly As System.Reflection.Assembly
    'Public rmTestiAsmeVip As Resources.ResourceManager
    Public rmHelpStrings As Resources.ResourceManager
    Public rmHelpTopics As Resources.ResourceManager
    Public GlobalRoutines As RoutBase1.clsTrigon
    Public Const DL As String = "----------"
    Public Const pi As Single = 3.14159265
    Public Const inc As Single = 25.4
    Public Const mpa As Single = 0.006894757
    Public Const psi As Single = 145.0377439
    Public Const NIUT As Single = 4.448222
    Public Const GRAV As Single = 9.80655
    Public Const MomToBS As Single = 0.008850748
    '-----------------------------------------------------------------
    Public Const Form1_2 As String = "#.00"
    Public Const FormMpa As String = "####.000"
    Public Const Fors As String = "#####.0"
    Public Const FormTemp As String = "####.00"
    Public Const FormInch As String = "#####.00"
    Public Const FormExp As String = "#.####E+00"
    '------------------------------------------------------------------
    Public Const Conn As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source="
    Public Const ConnFine As String = ";Persist Security Info=False"
    '-----------------------------------------------------------------------
    Public div As Short
    Public Matdim() As LibMat.MaterialeNew1
    Public objMemb() As Object
    Public Classedim() As Short
    '=====================================================================
    Public td, P0, pext As Single
    Public uh, Suffix, STStr, HTStr As String
    Public USStr(2) As String
    Public xsStr, xhStr As String
    Public FileSt As String
    Public A0Int, A0Ext As Single
    Private iGiaPI As Boolean
    Public TRV, A0, DN, RBra As Single
    '                                      2*RN          spessore required shell
    Public TCN, Ffact, AN As Single
    '                                      spess corroso nozzle
    Public TCV, Rn, Ls, TCVSav As Single
    '                                                     spessore corroso  shell
    Public TRN As Single
    '                        spessore required nozzle
    Public LX, E1, A3, a1, a2, A5, LN, Dp As Single
    Public a1ext As Single, a2ext As Single '140506
    Public A43, A41, A42, LXdisp As Single
    Public FR3, FR1, FR2, FR4 As Single
    Public LS1, TE, CN, LS2 As Single
    '                                      corrosione nozzle
    Public LN1, SS, Sn, SP, LN2 As Single
    Public Sm, aneu, Area, Amom, Aine, sb As Single
    Public Rm, tn, TBra, Rshell, Rnoz As Single
    Public Alnoz, Rnm, aepad, Alshe As Single
    Public AlnozB, AlsheB As Single
    Public Caso17b As Short
    Public AreaB As Single '0 niente flangia,1 parzialmente, 2 totalmente
    Public DLN, DCN, AlfaS As Single
    Public Circonf As Short
    Public formDiaframma As frmDiaf
    Public Fprel As Single
    Public pHISS, pHITS As Single
    Public Sub AggiornaLabels(ByVal f As Object, ByVal n As Short)
        Dim i As Integer, l As Label, t, s As String, nn As Short
        For i = 0 To n
            l = f.LabelCil(i)
            If Not l Is Nothing Then
                t = l.Tag
                If Not t Is Nothing Then
                    If t.Length > 0 Then
                        s = l.Text
                        nn = s.IndexOf("[")
                        If nn > 1 Then s = s.Substring(0, nn - 1).Trim
                        Select Case t
                            Case "kPress"
                                l.Text = s & " " & UnitPress
                            Case "kLength"
                                l.Text = s & " " & UnitLength
                            Case "kTemp"
                                l.Text = s & " " & UnitTemp
                            Case "kForce"
                                l.Text = s & " " & UnitForce
                            Case "kArea"
                                l.Text = s & " " & UnitArea
                            Case "kMomI"
                                l.Text = s & " " & UnitMomI
                        End Select
                    End If
                End If
            End If
        Next
    End Sub
    Public Function Helpstringa(ByVal id As Integer) As String
        Dim Outstr As String
        Dim Nome As String = "str" + id.ToString.Trim
        Outstr = rmHelpStrings.GetString(Nome)
        If Outstr Is Nothing Then Return (Nome)
        If Outstr.IndexOf("$"c) = 0 Then Return Outstr.Substring(1)
        Return Outstr.Replace("|", vbCrLf)
    End Function
    Sub Aggiorna()
        Dim Testo As String
        mioApert.StatusBar1.Items(0).Text = "Area di lavoro: " & RTrim(clsInizio.Datidir)
        Testo = "nessuno"
        If Len(icome) = 0 Then icome = " "
        With mioApert
            If Asc(icome) > 32 And NumInvTot() > 0 Then
                Testo = icome
                .mnuChiudi.Enabled = True
                .mnuSalva.Enabled = True
                .mnuSalvaCome.Enabled = True
                .mnuCalc.Enabled = True
                .mnuDati.Enabled = True
                .mnuDatiElem.Enabled = True
                .mnuConvElem.Enabled = True
                .mnuInseElem.Enabled = True
                .mnuElimElemento.Enabled = True
                .cmdDati.Enabled = True
                .cmdCalc.Enabled = True
                .Command1.Enabled = True
                .cmdInserisci.Enabled = True
            ElseIf Asc(icome) > 32 And NumInvTot() = 0 Then
                Testo = icome
                .mnuChiudi.Enabled = True
                .mnuSalva.Enabled = False
                .mnuSalvaCome.Enabled = False
                .mnuCalc.Enabled = False
                .mnuDati.Enabled = True
                .mnuDatiElem.Enabled = False
                .mnuConvElem.Enabled = False
                .mnuInseElem.Enabled = True
                .mnuElimElemento.Enabled = False
                .cmdDati.Enabled = False
                .cmdCalc.Enabled = False
                .Command1.Enabled = False
                .cmdInserisci.Enabled = True
            Else
                .mnuChiudi.Enabled = False
                .mnuCalc.Enabled = False
                .mnuSalva.Enabled = False
                .mnuSalvaCome.Enabled = False
                .mnuDati.Enabled = False
                .mnuDatiElem.Enabled = True
                .mnuConvElem.Enabled = True
                .mnuInseElem.Enabled = True
                .mnuElimElemento.Enabled = True
                .cmdDati.Enabled = False
                .cmdCalc.Enabled = False
                .Command1.Enabled = False
                .cmdInserisci.Enabled = False
            End If
            Testo = " File corrente = " & Testo
            .StatusBar1.Items(1).Text = Testo
            Testo = " Item = " & Config(0).Item
            .StatusBar1.Items(2).Text = Testo
            .Text = GlobalRoutines.StringaInformativaProgramma(myAssembly) & " " & icome
        End With
    End Sub
    ' Public Function at1(ByVal i As Integer) As String
    '     Dim Nome As String = "at1_" + i.ToString.Trim
    '     at1 = rmTestiAsmeVip.GetString(Nome).Replace("|", vbCrLf)
    ' End Function
    Public Sub RidimensionaTutto()
        ReDim Nozzles(4, MaxNozAct)
        ReDim NozzAdd(4, MaxNozAct)
        ReDim Config(4)
        ReDim Involucr(4, MaxNozAct)
        ReDim AdditCono(4, MaxNozAct)
        ReDim Addition1(4, MaxNozAct)
        Dim i, j As Short
        For i = 0 To 4
            Config(i).Initialize()
            For j = 0 To MaxNozAct
                Involucr(i, j).Initialize()
                AdditCono(i, j).Initialize()
                Addition1(i, j).Initialize()
                Nozzles(i, j).Initialize()
                NozzAdd(i, j).Initialize()
            Next
        Next
        ReDim Matdim(2 * MaxNozAct)
        Config(3).Vacuum = 3
        Config(4).Ninvolucri = 0
        FractSyPI = 0.9
        CondizioniCorrose = 1
        Config(0).lkStr = "Design Condition"
        If indici Is Nothing Then
            indici = New LinkListSh
        Else
            indici.RemoveAll()
        End If
        If indiciAttivi Is Nothing Then
            indiciAttivi = New LinkListSh
        Else
            indiciAttivi.RemoveAll()
        End If
    End Sub
    Public Sub Ridimensiona(ByRef n As Short)
        Dim i, j As Short
        Dim nv As Short = UBound(Involucr, 2)
        If n > nv Then
            ReDim Preserve Involucr(4, n + 2)
            ReDim Preserve AdditCono(4, n + 2)
            ReDim Preserve Addition1(4, n + 2)
            For j = nv + 1 To n + 2
                For i = 0 To 4
                    Involucr(i, j).Initialize()
                    AdditCono(i, j).Initialize()
                    Addition1(i, j).Initialize()
                Next
            Next
            If 2 * n + 2 > UBound(Matdim) Then ReDim Preserve Matdim(2 * n + 2)
        End If
    End Sub
    Public Sub RidimensionaN(ByRef n As Short)
        Dim i, j As Short
        For i = 0 To UBound(Matdim)
            Matdim(i) = Nothing
        Next
        ReDim Involucr(4, n + 2)
        ReDim AdditCono(4, n + 2)
        ReDim Addition1(4, n + 2)
        For j = 0 To n + 2
            For i = 0 To 4
                Involucr(i, j).Initialize()
                AdditCono(i, j).Initialize()
                Addition1(i, j).Initialize()
            Next
        Next
        ReDim Matdim(2 * n + 2)
    End Sub
    Public Sub Introduci(ByRef KL As Short, ByRef k As Short)
        Dim kk, j, i As Short
        jInvolucr = k
        kLato = KL
        With Involucr(KL, k)
            .MATE = ""
            .AccoppJ = 0
            .AccoppK = 0
            .Escluso = False
            .Tipo = 0
            .ES = 1
            .cs = Config(KL).Corr
            For i = 1 To 8
                .indice(i - 1) = -1
            Next
            .indice(1 - 1) = NuovoIndice()
            '080706  .RecInd(1 - 1) = 0
            indici.Add(.indice(0))
            For j = 2 To 8
                .indice(j - 1) = -1
                '080706  .RecInd(j - 1) = 0
            Next
            .Mark = "Elemento" & Str(k)
Rif:        For kk = 1 To Config(0).NumeroLati
                For j = 1 To Config(kk).Ninvolucri
                    If Not (j = k And kk = KL) Then
                        If Involucr(kk, j).Mark = .Mark And InStr(.Mark, "Elemento") > 0 Then
                            If GlobalRoutines.ValVir(Right(Trim(.Mark), 1)) > 0 Then
                                .Mark = Trim(.Mark) & "A"
                                GoTo Rif
                            Else
                                .Mark = Left(Trim(.Mark), Len(Trim(.Mark)) - 1) & Chr(Asc(Right(Trim(.Mark), 1)) + 1)
                            End If
                            Exit For
                        End If
                    End If
                Next
            Next
            If k > 1 Then
                .inizio = Involucr(KL, k - 1).Fine
                If .inizio = 0 Then
                    .inizio = Involucr(KL, k - 1).inizio
                End If
            Else
                .inizio = 1
            End If
            If .inizio = 0 Then .inizio = 1
            .Fine = .inizio - 1
        End With
    End Sub
    Sub Libreria()
        Dim i, ifl, j As Short
        Dim Testo As String
        ifl = FreeFile()
        FileOpen(ifl, RTrim(clsInizio.Archdir) & "\ASME1.DAT", OpenMode.Input, , OpenShare.Shared)
        Testo = LineInput(ifl) : For i = 1 To 30 : Input(ifl, diamNm(i)) : Next
        Testo = LineInput(ifl) : For j = 1 To 23 : For i = 1 To 30 : Input(ifl, MMM(j, i))
            Next i
            Testo = LineInput(ifl) : Next j
        For i = 1 To 34 : Input(ifl, n(i)) : Next i
        Testo = LineInput(ifl) : For j = 1 To 9 : For i = 1 To 34 : Input(ifl, NNN(j, i))
            Next i : Testo = LineInput(ifl) : Next j
        For j = 1 To 5 : For i = 1 To 9 : Input(ifl, Oasme(j, i)) : Next i : Next j
        Testo = LineInput(ifl) : For j = 1 To 2 : For i = 1 To 11
                Input(ifl, Pasme(j, i)) : Next i : Next j
        Testo = LineInput(ifl) : For j = 1 To 2 : For i = 1 To 17 : Input(ifl, Qasme(j, i))
            Next i : Next j
        FileClose(ifl)
    End Sub
    Public Function CaricaFile(ByRef icome As String, ByRef Ext As String) As Boolean
        Dim n As Short
        Dim Strin(20) As String
        Dim Contr As String = ""
        Dim ContrFile As String = ""
        Dim nn As String
        Try
            If clsInizio.LavoriSciolti Then
                CaricaFile = Monitor.Motore.Mostra(myAssembly, 2)
            Else
                job = New RoutBase1.clsjob(Monitor.Motore)
                Monitor.Motore.Sceglijob(Contr, ContrFile)
                If Len(ContrFile) = 0 Then Exit Function
                If Not job.Selezione Then icome = "" : Exit Function
                With job.Comm
                    If .indice > 0 Then
                        icome = Monitor.Motore.Inizio.Workdir & "\" & .Arch & gstrSEP_DIR & .Ind.Item(.indice).Data.File & ".VIP"
                        Config(0).Item = .Ind.Item(.indice).Data.Assieme
                    Else
                        icome = ""
                        Config(0).Item = ""
                    End If
                End With
                Aggiorna()
            End If
            If icome.Trim.Length = 0 Then Exit Function
            nn = CStr(1)
            Do
                n = InStr(CShort(nn), icome, ".")
                If n = 0 Then Exit Do
                nn = CStr(n + 1)
            Loop
            If CDbl(nn) > 1 Then icome = Left(icome, CDbl(nn) - 2)
            icome = icome & ".VIP"
            If Not IO.File.Exists(icome) Then SalvaU()
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Function
    ' Sub CercaWND(ByRef Ind As Short, ByRef Suffix As String)
    '     Suffix = Str(Record(Ind).PosDis)
    '     Mid(Suffix, 1, 1) = "0"
    '     If Len(Suffix) < 3 Then Suffix = "0" & Suffix
    '     If Len(Suffix) > 3 Then Suffix = Right(Suffix, 3)
    ' End Sub
    Sub CalcCorr(ByRef iExempt As Short, ByRef i As Short, ByRef Ratio As Single, ByVal tMDMT As Single, ByRef CorrF As Single, ByRef TempF As Single)
        Dim StriSt(4) As String
        Dim ifl As Short
        Dim Rtf As String
        Dim ii As Short
        Dim letter As String
        ifl = FreeFile()
        Rtf = "\RTF" : tMDMT = tMDMT * 1.8 + 32
        letter = "" : If div = 1 Then letter = "2"
        FileOpen(ifl, RTrim(clsInizio.Archdir) & Rtf & "\ASME30" & letter & ".DAT", OpenMode.Input, , OpenShare.Shared)
        For ii = 1 To 4 : StriSt(ii) = LineInput(ifl) : Next
        FileClose(ifl)
        With Monitor.Motore.Problem
            .Printa(GlobalRoutines.FormatS(StriSt(2), i, Ratio))  '"     Stress Ratio _## per Fig. UCS-66.1   = #.###"
            If TempF = -500.0! Then
                iExempt = (Ratio < 0.35 And div = 0) Or (Ratio < 0.3 And div = 1)
                Exit Sub
            End If
            If tMDMT >= -55.0! Then
340:            CorrF = Correction(Ratio)
                'PRINT #iout, "     Temperat. reduction per UCS-66(b)(1)=";
                .Printa(GlobalRoutines.FormatS(StriSt(3), CorrF / 1.8, CorrF))
            ElseIf tMDMT >= -155.0! Then
                'PRINT #iout, "     Min metal temperat. per UCS-66(b)(2)=";
                If Ratio < 0.35 And div = 0 Or Ratio < 0.3 And div = 1 Then
                    CorrF = 155 + TempF
                    .Printa(GlobalRoutines.FormatS(StriSt(4), (-155 - 32) / 1.8, -155))
                Else
                    CorrF = 55 + TempF
                    .Printa(GlobalRoutines.FormatS(StriSt(4), (-55 - 32) / 1.8, -55))
                End If
            Else
                CorrF = 0
            End If
        End With
        If TempF - CorrF > tMDMT Then iExempt = False
    End Sub
    Sub MinTempCalc(ByRef nn As Short, ByRef jmemb As Short, ByRef R As Single, ByRef SWR As Single, ByRef Aspp As Single, ByRef MWDTrule As String, ByRef MWDTclause As String, ByRef TempSpec As Single, ByRef tgov As Single, ByRef YieldMWDT As Object, ByRef PNumber As String, ByRef iGr As Short, ByRef Num As String, ByRef tdMDMT() As Single)
        Dim Gradf, Subd, GradC As String
        Dim StriSt(16) As String
        Dim ifl, i As Short
        Dim n As Short
        Dim K1 As String
        Dim TempF As Single
        Dim Carbon01 As Boolean
        Dim NTemp, iExempt As Short
        Dim iExUG20f As Boolean
        Dim ia2, iUCS66g, ia3 As Boolean
        Dim k As String
        Dim ic3, iUCS67d As Boolean
        Dim letter As String
        Dim Mat As LibMat.MaterialeNew1
        Dim Dum, SMYS, minMDMT As Single
        'UPGRADE_WARNING: Il limite inferiore della matrice MDMTdata è stato cambiato da 1 a 0. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1033"'
        Dim MDMTdata(2) As clsValoriMDMT
        Dim Mark As String
        'jmemb negativo: senza saldature
        'nn negativo: n-esimo bocchello su coperchio
        If nn = 0 Then
            If jInvolucr > 0 Then
                Mat = Matdim(Involucr(kLato, jInvolucr).indice(1 - 1))
                Mark = Involucr(kLato, jInvolucr).Mark
            Else
                Mat = Matdim(Nozzles(kLato, kNozzle).IndexF)
                Mark = Trim(Nozzles(kLato, kNozzle).Mark) & " (fl.)"
            End If
        Else
            Mat = Matdim(Nozzles(kLato, System.Math.Abs(nn)).indice)
            Mark = Nozzles(kLato, System.Math.Abs(nn)).Mark
        End If
        Subd = "\RTF" : Gradf = " [\'b0F]" : GradC = " [\'b0C]"
        ifl = FreeFile()
        letter = "" : If div = 1 Then letter = "2"
        FileOpen(ifl, RTrim(clsInizio.Archdir) & Subd & "\ASME24" & letter & ".DAT", OpenMode.Input, , OpenShare.Shared)
        For i = 1 To 16 : StriSt(i) = LineInput(ifl) : Next
        FileClose(ifl)
        NTemp = Config(kLato).NMWDT
        If kLato = 3 Then
            NTemp = Config(1).NMWDT
            If Config(2).NMWDT > NTemp Then NTemp = Config(2).NMWDT
        End If
        MDMTdata(1) = New clsValoriMDMT
        With MDMTdata(1)
            .i = nn
            .k = kLato
            .Secondo = False
            .Mark = Mark
            .Rule = MWDTrule
        End With
        If NTemp = 2 Then
            MDMTdata(2) = New clsValoriMDMT
            With MDMTdata(2)
                .i = nn
                .k = kLato
                .Secondo = True
                .Mark = Mark
                .Rule = MWDTrule
            End With
        End If
        If InStr(MWDTrule, "CS") Then
            Select Case LTrim(RTrim(MWDTclause))
                Case "A" : n = 1
                Case "B" : n = 2
                Case "C" : n = 3
                Case "D" : n = 4
                Case "E" : n = 5 'bulloni in CS in div.1
                Case Else : n = 0
                    MessageBox.Show("Curva per l'esenzione dagli impact test non definita per " & Mark, "AsmeVip", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Select
            If n > 0 And n < 5 Then
                K1 = "(UCS-67(a))" : If div = 1 Then K1 = "(AM-218.2(a))"
                Monitor.Motore.Problem.Print(GlobalRoutines.FormatS(StriSt(7), Num))  '"Governing thickness                tg&   ="
                Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(StriSt(8), tgov * inc, " [mm]", tgov, " [in]"))  '"######.## &   ######.## &"
310:            Call LegTabella(RTrim(clsInizio.Archdir) & "\UCS66" & letter & ".DAT", n, 6, tgov, TempF)
                Monitor.Motore.Problem.Print(StriSt(9))  '"Calculated min. temp. per UCS-66 (a)     =";
                Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(StriSt(8), (TempF - 32) / 1.8, GradC, TempF, Gradf))  '"######.## &   ######.## &"
                For i = 1 To NTemp
                    Monitor.Motore.Problem.Print(StriSt(1))
                    Monitor.Motore.Problem.Print(StriSt(10))  '"     Metal temperature                   =";
                    Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(StriSt(8), tdMDMT(i), GradC, tdMDMT(i) * 1.8 + 32, Gradf))
                    If div = 1 Or n = 1 And tgov > 0.5 Or n > 1 And tgov > 1.0! Or _
                    PNumber.Trim <> "1" Or iGr > 2 Or iGr < 1 Or tdMDMT(i) * 1.8 + 32 < -20 Or td * 1.8 + 32 > 650 Then
                        iExUG20f = False
                    Else
                        iExUG20f = True
                    End If
                    If iExUG20f Then
                        iExempt = True
                        K1 = "per UG-20(f)"
                    Else
                        If tgov <= 4 Or (div = 0 And tdMDMT(i) * 1.8 + 32 >= 120) Or (div = 1 And tdMDMT(i) * 1.8 + 32 >= 90) Then
                            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto YieldMWDT. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                            If YieldMWDT <= 65000 Then
                                Call EsenzStress(nn, System.Math.Abs(jmemb), R, SWR, iExempt, Aspp, i, TempF)
                                K1 = ""
                            Else
                                iExempt = (TempF <= tdMDMT(i) * 1.8 + 32)
                                K1 = "UCS-66(f)" : If div = 1 Then K1 = "AM-218.4(d)"
                            End If
                        Else
                            iExempt = False
                            K1 = "UCS-66(a)(1)(d)" : If div = 1 Then K1 = "AM-218.1(a)"
                        End If
                    End If
                    iUCS66g = False
                    If Not iExempt Then
                        If TempSpec > -1000 And Mat.UG841(div + 1) And tdMDMT(i) * 1.8 + 32 >= TempSpec - 5 Then
                            iExempt = True : iUCS66g = True
                            K1 = "UCS-66(g)" : If div = 1 Then K1 = "AM-218.4(e)"
                        End If
                    End If
                    If Not iExempt Then
                        If tgov <= 0.1 And tdMDMT(i) * 1.8 + 32 >= -55 Then
                            iExempt = True
                            K1 = "UCS-66(d)" : If div = 1 Then K1 = "AM-218.4(b)"
                            If Not iExempt And (Mat.Classe = 4 Or Mat.Classe = 6) Then
                                If tdMDMT(i) * 1.8 + 32 > -155 Then
                                    Mat.YieldTemp(5 * div + 1, 0, SMYS, Dum)
                                    If tgov <= 0.1 Then
                                        iExempt = True
                                    ElseIf tgov <= 0.125 Then
                                        iExempt = SMYS <= 45000
                                    ElseIf tgov <= 0.237 Then
                                        iExempt = SMYS <= 35000
                                    End If
                                    If iExempt Then
                                        K1 = "UCS-66(d) 2{\super nd}" : If div = 1 Then K1 = "AM-218.4(b) 2{\super nd}"
                                    End If
                                End If
                            End If
                        End If
                    End If
                    If Not iExempt And nn > 0 Then
                        If Nozzles(kLato, nn).Rati > 0 And InStr(Nozzles(kLato, nn).Tipo, "WN") > 0 Then
                            If tdMDMT(i) * 1.8 + 32 >= -20 Then
                                iExempt = True
                                K1 = "UCS-66(b)(4)" : If div = 1 Then K1 = "AM-218.4(a)"
                            End If
                        End If
                    End If
                    Monitor.Motore.Problem.Print(StriSt(1))
                    If Not iExempt Then k = "NOT " Else k = ""
                    Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(StriSt(2), k, K1))  '"The material is &exempted from impact testing &"
                    MDMTdata(i).Exempt(1) = iExempt
                    MDMTdata(i).Articl(1) = K1
                    If jmemb < 0 Then Exit Sub
                    k = "" : K1 = "UCS-67(a)" : If div = 1 Then K1 = "AM-218.2(a)"
                    ia2 = (n > 2 And tdMDMT(i) * 1.8 + 32 < -20)
                    ia3 = iUCS66g And tdMDMT(i) * 1.8 + 32 < -55
                    If iExempt Then
                        If ia2 Then
                            k = "NOT " : K1 = "UCS-67(a)(2)"
                            If div = 1 Then K1 = "AM-218.2(a)(2)"
                        Else
                            If ia3 Then
                                k = "NOT "
                                K1 = "UCS-67(a)(3)"
                                If div = 1 Then K1 = "AM-218.2(a)(3)"
                            End If
                        End If
                    Else
                        k = "NOT " : K1 = "UCS-67(a)(1)"
                        If div = 1 Then K1 = "AM-218.2(a)(1)"
                    End If
                    Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(StriSt(6), k, K1))  '"Welds with filler metal are &exempted from impact testing &")
                    MDMTdata(i).Exempt(5) = iExempt
                    MDMTdata(i).Articl(5) = K1
                    K1 = "UCS-67(c)(1)" : If div = 1 Then K1 = "AM-218.4(c)"
                    ic3 = (iUCS66g And tdMDMT(i) * 1.8 + 32 < -55)
                    If iExempt Then
                        k = ""
                        If ic3 Then
                            k = "NOT "
                            K1 = "UCS-67(c)(3)" : If div = 1 Then K1 = "AM-218.4(c)(3)"
                        End If
                    Else
                        k = "NOT "
                    End If
                    Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(StriSt(3), k, K1))  '"HAZ zones are &exempted from impact testing &"
                    MDMTdata(i).Exempt(2) = iExempt
                    MDMTdata(i).Articl(2) = K1
                    iUCS67d = False : K1 = ""
                    If iExempt And tdMDMT(i) * 1.8 + 32 >= -20 Then
                        iUCS67d = True : K1 = "UCS-67(d)(1)"
                        If div = 1 Then K1 = "AM-218.4(d)(1)"
                    End If
                    If Not iUCS67d And (iUCS66g Or (n > 2 And tdMDMT(i) * 1.8 + 32 >= -55)) Then
                        iUCS67d = True : K1 = "UCS-67(d)(2)"
                        If div = 1 Then K1 = "AM-218.4(d)(2)"
                    End If
                    If iUCS67d Then k = "" Else k = "NOT "
                    Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(StriSt(4), k, K1))  '"Welds are &exempted from production impact testing &"
                    MDMTdata(i).Exempt(3) = iExempt
                    MDMTdata(i).Articl(3) = K1
                    K1 = "UCS-67(d)(3)" : If div = 1 Then K1 = "AM-218.4(d)(3)"
                    If iExempt And Not ic3 Then
                        k = ""
                    Else
                        k = "NOT "
                    End If
                    Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(StriSt(5), k, K1))  '"HAZ zones are &exempted from production impact testing &"
                    MDMTdata(i).Exempt(4) = iExempt
                    MDMTdata(i).Articl(4) = K1
                Next
            Else
                minMDMT = tdMDMT(1)
                If NTemp = 2 And tdMDMT(2) < minMDMT Then minMDMT = tdMDMT(2)
                K1 = "Fig. UCS-66, note (e)"
                iExempt = True
                If minMDMT < TempSpec Or TempSpec = 100 Then iExempt = False
                If Not iExempt Then k = "NOT " Else k = ""
                Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(StriSt(2), k, K1))  '"The material is &exempted from impact testing &"
                MDMTdata(1).Exempt(1) = iExempt
                MDMTdata(1).Articl(1) = K1
                If NTemp = 2 Then
                    MDMTdata(2).Exempt(1) = iExempt
                    MDMTdata(2).Articl(1) = K1
                End If
            End If
        ElseIf InStr(MWDTrule, "HA") Then
            'If MWDTclause = "Y" Then
            If tgov < 0.099 Then
                K1 = "(UHA-51)" : k = ""
                If div = 1 Then K1 = "(AM-213)"
                Monitor.Motore.Problem.Print(GlobalRoutines.FormatS(StriSt(7), Num))  '"Governing thickness                tg&   ="
                Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(StriSt(8), tgov * inc, " [mm]", tgov, " [in]"))  '"######.## &   ######.## &"
                Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(StriSt(2), k, K1))
                MDMTdata(1).Exempt(1) = iExempt
                MDMTdata(1).Articl(1) = K1
                If NTemp = 2 Then
                    MDMTdata(2).Exempt(1) = iExempt
                    MDMTdata(2).Articl(1) = K1
                End If
            Else
                'NTemp = 1: If tdMDMT(1) <> tdMDMT(2) Then NTemp = 2
                For i = 1 To NTemp
                    Monitor.Motore.Problem.Print(StriSt(1))
                    Monitor.Motore.Problem.Print(StriSt(10))  '"     Metal temperature                   =";
                    Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(StriSt(8), tdMDMT(i), GradC, tdMDMT(i) * 1.8 + 32, Gradf))
                    Monitor.Motore.Problem.Print(GlobalRoutines.FormatS(StriSt(7), Num))  '"Governing thickness                tg&   ="
                    Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(StriSt(8), tgov * inc, " [mm]", tgov, " [in]"))  '"######.## &   ######.## &"
                    Call EsenzStress(nn, System.Math.Abs(jmemb), R, SWR, iExempt, Aspp, i, -500.0!)
                    If iExempt Then
                        K1 = "(UHA-51(g))" : k = ""
                        If div = 1 Then K1 = "(AM-213.1)"
                        Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(StriSt(2), k, K1))
                    Else
                        i = Mat.UHA51d(div + 1)
                        K1 = "UHA-51(d)" : If div = 1 Then K1 = "AM-213(b)"
                        iExempt = True
                        Select Case i
                            Case 0 'austenitico
                                K1 = K1 & "(1)"
                                If tdMDMT(i) * 1.8 + 32 < TempSpec Then iExempt = False
                                Carbon01 = TempSpec = -55
                            Case 1 'austenitico Cr-Mn
                                K1 = K1 & "(2)"
                                If tdMDMT(i) * 1.8 + 32 < TempSpec Then iExempt = False
                                Carbon01 = TempSpec = -55
                            Case 2 'duplex
                                K1 = K1 & "(3)"
                                If tdMDMT(i) * 1.8 + 32 < TempSpec Or tgov > 3.0# / 8 Then iExempt = False
                            Case 3 'ferritico
                                K1 = K1 & "(3)"
                                If tdMDMT(i) * 1.8 + 32 < TempSpec Or tgov > 1.0# / 8 Then iExempt = False
                            Case 4 'martensitico
                                K1 = K1 & "(3)"
                                If tdMDMT(i) * 1.8 + 32 < TempSpec Or tgov > 0.25 Then iExempt = False
                        End Select
                        If iExempt Then k = "" Else k = "NOT"
                        Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(StriSt(2), k, K1))
                        MDMTdata(i).Exempt(1) = iExempt
                        MDMTdata(i).Articl(1) = K1
                        Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(StriSt(3), k, K1))
                        MDMTdata(i).Exempt(2) = iExempt
                        MDMTdata(i).Articl(2) = K1
                        If k = "NOT" Then
                            Monitor.Motore.Problem.Printa(StriSt(12))
                            Monitor.Motore.Problem.Printa(StriSt(16))
                        Else
                            Monitor.Motore.Problem.Printa(StriSt(13))
                        End If
                    End If
                Next
            End If
            'Else
            '  Print #iout, StriSt$(11)
            'End If
        ElseIf InStr(MWDTrule, "NF") Then
            Monitor.Motore.Problem.Print(StriSt(10))  '"     Metal temperature                   =";
            Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(StriSt(8), tdMDMT(1), GradC, tdMDMT(1) * 1.8 + 32, Gradf))
            Monitor.Motore.Problem.Print(StriSt(11))
            Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(StriSt(14), TempSpec, GradC, TempSpec * 1.8 + 32, Gradf))
        ElseIf InStr(MWDTrule, "UHT") Then
            Monitor.Motore.Problem.Print(StriSt(10))  '"     Metal temperature                   =";
            Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(StriSt(8), tdMDMT(1), GradC, tdMDMT(1) * 1.8 + 32, Gradf))
            Monitor.Motore.Problem.Print(StriSt(11))
            Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(StriSt(14), TempSpec, GradC, TempSpec * 1.8 + 32, Gradf))
            Monitor.Motore.Problem.Printa("PROVVISORIO " & StriSt(15))
        ElseIf InStr(MWDTrule, "AQT") Then
            Monitor.Motore.Problem.Print(StriSt(10))  '"     Metal temperature                   =";
            Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(StriSt(8), tdMDMT(1), GradC, tdMDMT(1) * 1.8 + 32, Gradf))
            Monitor.Motore.Problem.Print(StriSt(11))
            Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(StriSt(14), TempSpec, GradC, TempSpec * 1.8 + 32, Gradf))
            Monitor.Motore.Problem.Printa("PROVVISORIO " & StriSt(15))
        End If
        colMDMT.Add(MDMTdata(1))
        If NTemp = 2 Then colMDMT.Add(MDMTdata(2))
    End Sub
    Function Correction(ByRef R As Single) As Single
        If R <= 0.35 And div = 0 Or R <= 0.3 And div = 1 Then
            Correction = 105
        ElseIf R > 0.6 Then
            Correction = 100 * (1.0! - R)
        Else
            Correction = 1250.0! * R * R - 1575.0! * R + 535
        End If
    End Function
    Public Sub FillDatiGenerali()
        Dim i As Short
        AggMetodo()
        With mioGen
            For i = 1 To 3
                .cmbCode(i).Items.Clear()
                .cmbCode(i).Items.Add("ASME VIII div.1")
                .cmbCode(i).Items.Add("div.1 + TEMA R  ")
                .cmbCode(i).Items.Add("div.1 + TEMA C/B")
                .cmbCode(i).Items.Add("ASME VIII div.2")
                .cmbCode(i).Items.Add("div.2 + TEMA R  ")
                .cmbCode(i).Items.Add("div.2 + TEMA C/B")
                .cmbCode(i).Items.Add("PED/EN-13445")
                .cmbCode(i).Items.Add("PED/EN-13445+TEMA R  ")
                .cmbCode(i).Items.Add("PED/EN-13445+TEMA C/B")
                .cmbCode(i).Items.Add("PED/div.1")
                .cmbCode(i).Items.Add("PED/div.1+TEMA R  ")
                .cmbCode(i).Items.Add("PED/div.1+TEMA C/B")
            Next
            .cmbUnit.Items.Clear()
            .cmbUnit.Items.Add("[mm],[MPa],[°C]")
            .cmbUnit.Items.Add("[mm],[psi],[°F]")
            .cmbUnit.Items.Add("[in],[psi],[°F]")
            .cmbLoadCase.Items.Clear()
            .cmbLoadCase.Items.Add("Design Condition   ")
            .cmbLoadCase.Items.Add("Operating Condition")
            .cmbLoadCase.Items.Add("Hydrotest Condition")
            .cmbLoadCase.Items.Add("MAWP   ")
            .cmbLoadCase.SelectedIndex = 0
            ._cmbVessMat_1.Items.Clear()
            ._cmbVessMat_1.Items.Add("Carbon Steel")
            ._cmbVessMat_1.Items.Add("Alloy Steel ")
            ._cmbVessMat_2.Items.Clear()
            ._cmbVessMat_2.Items.Add("Carbon Steel")
            ._cmbVessMat_2.Items.Add("Alloy Steel ")
        End With
    End Sub

    Public Sub AggDatiGenerali()
        Dim i As Short
        Try
            With mioGen
                For i = 1 To 3
                    .cmbCode(i).SelectedIndex = Config(i).DC
                Next
                .cmbUnit.SelectedIndex = Config(0).US
                For i = 0 To .cmbLoadCase.Items.Count - 1
                    If CStr(.cmbLoadCase.Items(i)).Trim = Config(0).lkStr.Trim Then
                        .cmbLoadCase.SelectedIndex = i
                        Exit For
                    End If
                Next
                For i = 1 To 2
                    .Check1(i).CheckState = -Config(i).Vacuum
                Next
                .ChkMAWP.CheckState = Config(0).CalcMAWP
                .chkPI.CheckState = Config(0).CalcPI
                .chkPIverif.CheckState = Config(0).VerifPI
                If Config(0).CalcPI = 1 Then
                    If Config(0).HTTestVert < 0 Or Config(0).HTTestVert > 1 Then Config(0).HTTestVert = 0
                    .chkHTVert.CheckState = Config(0).HTTestVert
                    .cmbMetodoPI.SelectedIndex = Config(0).MetodoPI
                End If
                .chKDiversi.CheckState = Config(0).DiverseTemp
                For i = 1 To Config(0).NumeroLati
                    .txtNb(i).Value = Config(i).Ninvolucri
                    If i < 3 Then
                        .txtNbLC(i).Text = GlobalRoutines.myStr(CSng(Config(i).NMWDT), 2, 0, True)
                        .cmbVessMat(i).SelectedIndex = Config(i).mv
                    End If
                Next
                i = 1 : If Config(0).NumeroLati > 1 Then i = 2
                .NLati(i).Checked = True
            End With
        Catch e As Exception
            MessageBox.Show(e.Message + vbCrLf + e.StackTrace)
        End Try
        AggDatiTesto()
        DatiInputC(1)
    End Sub
    Public Sub AggDatiTesto()
        Dim i, n As Short
        n = 1 : If Config(0).NumeroLati > 1 Then n = 2
        Try
            With mioGen
                For i = 0 To n - 1
                    .Text1(0 + i * 20).Text = GlobalRoutines.myStr(Config(i + 1).di * kLength, 5, 2, False)
                    .Text1(1 + i * 20).Text = GlobalRoutines.myStr(Config(i + 1).p0x * kPress, 6 - IncrVirgola, 1 + IncrVirgola, 0)
                    .Text1(2 + i * 20).Text = GlobalRoutines.myStr(Config(i + 1).tdx * kTemp + kTemp32, 4, 2, False)
                    .Text1(3 + i * 20).Text = GlobalRoutines.myStr(Config(i + 1).tdxMDMT(0) * kTemp + kTemp32, 4, 2, False)
                    .Text1(4 + i * 20).Text = GlobalRoutines.myStr(Config(i + 1).pdxMDMT(0) * kPress, 6 - IncrVirgola, 1 + IncrVirgola, 0)
                    .Text1(5 + i * 20).Text = GlobalRoutines.myStr(Config(i + 1).tdxMDMT(1) * kTemp + kTemp32, 4, 2, False)
                    .Text1(6 + i * 20).Text = GlobalRoutines.myStr(Config(i + 1).pdxMDMT(1) * kPress, 6 - IncrVirgola, 1 + IncrVirgola, 0)
                    .Text1(7 + i * 20).Text = GlobalRoutines.myStr(Config(i + 1).pxExt * kPress, 6 - IncrVirgola, 1 + IncrVirgola, 0)
                    .Text1(8 + i * 20).Text = GlobalRoutines.myStr(Config(i + 1).txExt * kTemp + kTemp32, 5, 3, False)
                    .Text1(9 + i * 20).Text = GlobalRoutines.myStr(Config(i + 1).DensFluido, 5, 3, False)
                    .Text1(10 + i * 20).Text = GlobalRoutines.myStr(Config(i + 1).pxTest * kPress, 6 - IncrVirgola, 1 + IncrVirgola, 0)
                    .Text1(11 + i * 20).Text = GlobalRoutines.myStr(Config(i + 1).Corr * kLength, 5, 3, False)
                    If Config(i + 1).Efficienza = 0 Then Config(i + 1).Efficienza = 1
                    .Text1(12 + i * 20).Text = GlobalRoutines.myStr(Config(i + 1).Efficienza, 2, 2, False)
                Next
                .txtItem.Text = Config(0).Item
            End With
        Catch e As Exception
            MessageBox.Show(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Public Sub Popola(ByRef c As ComboBox)
        Dim i As Short, m As LibMat.MaterialeNew1
        Try
            c.Items.Clear()
            indiciAttivi.RemoveAll()
            For i = 1 To indici.Count
                m = Matdim(indici(i).TextData)
                If Not m Is Nothing Then
                    If Not m.MatStr Is Nothing Then
                        If m.MatStr.Trim.Length > 0 Then
                            c.Items.Add(m.MatStr.Trim)
                            indiciAttivi.Add(indici(i).TextData)
                        End If
                    End If
                End If
            Next
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
        c.Items.Add("(nuovo materiale)")
    End Sub
    Public Sub PostSelMat(ByRef c As ComboBox, ByVal indice As Short)
        Dim i As Short
        Popola(c)
        If indice = -1 Then c.SelectedIndex = -1 : Exit Sub
        For i = 0 To c.Items.Count - 2
            If indiciAttivi(i + 1).TextData = indice Then c.SelectedIndex = i : Exit Sub
        Next
        'se non l'hai trovato prova a riparare
        If Not Matdim(indice) Is Nothing Then
            If Not Matdim(indice).MatStr Is Nothing Then
                indici.Add(indice)
                Popola(c)
                c.Text = Matdim(indice).MatStr.Trim
            End If
        End If
    End Sub
    Public Sub PulisciIndici()
        Dim i, j, indice, ind1, ind2 As Short
        If indici Is Nothing Then indici = New LinkListSh
        Try
Rif:        For i = 1 To indici.Count
                For j = 1 To indici.Count
                    If i <> j Then
                        ind1 = indici(i).TextData
                        ind2 = indici(j).TextData
                        If ind1 = ind2 Then
                            indici.Remove(j)
                            GoTo Rif
                        End If
                        If ind1 >= 0 AndAlso ind1 <= UBound(Matdim) AndAlso
                           ind2 >= 0 AndAlso ind2 <= UBound(Matdim) AndAlso
                           Matdim(ind1) IsNot Nothing AndAlso Matdim(ind2) IsNot Nothing Then
                            If Matdim(ind1).MatStr IsNot Nothing AndAlso Matdim(ind2).MatStr IsNot Nothing Then
                                If Matdim(ind1).Indmat = Matdim(ind2).Indmat And _
                                   (Matdim(ind1).Agganciato And Matdim(ind2).Agganciato Or _
                                   Not Matdim(ind1).Agganciato And Not Matdim(ind2).Agganciato And _
                                   Matdim(ind1).MatStr.Trim = Matdim(ind2).MatStr.Trim) Then
                                    CambiaIndice(ind2, ind1)
                                    Matdim(ind2) = Nothing
                                    indici.RemoveValue(ind2)
                                    GoTo Rif
                                End If
                            End If
                        End If
                    End If
                Next
                indice = indici(i).TextData
                If Not EsisteIndice(indice) Then
                    Matdim(indice) = Nothing
                    indici.RemoveValue(indice)
                    GoTo Rif
                End If
            Next
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Public Sub RestoreApplicationDirectory()
        Dim applicationDirectory = AppContext.BaseDirectory
        If IO.Directory.Exists(applicationDirectory) Then
            Environment.CurrentDirectory = applicationDirectory
        End If
    End Sub
    Public Sub SelPopMat(ByVal c As ComboBox, ByRef indice As Short, ByVal inv As Boolean, ByRef nuovoSelect As Short)
        Dim Selected As Short = c.SelectedIndex
        Dim rimosso As Boolean = False
        Dim minore As Boolean
        If Selected = -1 Then Exit Sub
        If Selected = c.Items.Count - 1 Then
            indice = NuovoIndice()
            indici.Add(indice)
            Matdim(indice).MatStr = "Materiale n." & indice.ToString
            PostSelMat(c, indice)
            nuovoSelect = c.Items.Count - 2
            Exit Sub
        End If
        Dim indiceN As Short = indiciAttivi(Selected + 1).TextData
        If indiceN <> indice Then
            If inv Then
                If Not EsisteIndice(indice, kLato, jInvolucr) Then
                    If indice <= UBound(Matdim) Then Matdim(indice) = Nothing
                    indici.RemoveValue(indice)
                    rimosso = True
                End If
            Else
                If Not EsisteIndice(indice, kLato, , kNozzle) Then
                    Matdim(indice) = Nothing
                    indici.RemoveValue(indice)
                    rimosso = True
                End If
            End If
            minore = indiceN < indice
            indice = indiceN
            If rimosso Then
                Dim Num As Short = c.Items.Count
                If minore Or Num = c.Items.Count Then
                    nuovoSelect = Selected
                Else
                    nuovoSelect = Selected - 1
                End If
            Else
                nuovoSelect = -1
            End If
        Else
            nuovoSelect = -1
        End If
    End Sub
    Public Sub AggDatiCil(ByRef k As Short, ByRef j As Short)
        Dim NBocch As Short
        NBocch = Involucr(k, j).Fine - Involucr(k, j).inizio + 1
        If NBocch < 0 Or Involucr(k, j).Fine < 1 Then NBocch = 0
        With frmCil.DefInstance
            ._cmbCil_0.Text = Involucr(k, j).Mark.Trim
            If Involucr(k, j).ms > ._cmbCil_1.Items.Count - 1 Then Involucr(k, j).ms = 0
            ._cmbCil_1.SelectedIndex = Involucr(k, j).ms
            Popola(.cmbMat)
            .cmbMat.Text = Involucr(k, j).MATE.Trim
            .chkAgganciato.Checked = Matdim(Involucr(kLato, jInvolucr).indice(0)).Agganciato
            If Involucr(k, j).ms = 2 Then
                ._TextCil_1.Text = GlobalRoutines.myStr(Involucr(k, j).dns * kLength, 5, 2, False)
            Else
                ._TextCil_2.Text = GlobalRoutines.myStr(Involucr(k, j).di * kLength, 5, 2, False)
            End If
            If Involucr(k, j).ES = 0 Then Involucr(k, j).ES = Config(k).Efficienza
            ._TextCil_3.Text = GlobalRoutines.myStr(Involucr(k, j).ES, 2, 2, False)
            ._TextCil_4.Text = GlobalRoutines.myStr(Involucr(k, j).OS * kLength, 2, 2, False)
            ._TextCil_5.Text = GlobalRoutines.myStr(Involucr(k, j).cs * kLength, 2, 2, False)
            If VerificandoPI Then
                ._TextCil_6.Text = GlobalRoutines.myStr(Involucr(k, j).Shydr * kPress, 6 - IncrVirgola, 1 + IncrVirgola, 0)
            Else
                ._TextCil_6.Text = GlobalRoutines.myStr(Involucr(k, j).S0 * kPress, 6 - IncrVirgola, 1 + IncrVirgola, 0)
            End If
            ._TextCil_7.Text = GlobalRoutines.myStr(Involucr(k, j).St * kPress, 6 - IncrVirgola, 1 + IncrVirgola, 0)
            ._TextCil_8.Text = GlobalRoutines.myStr(Involucr(k, j).L0 * kLength, 5, 3, False)
            ._TextCil_10.Text = GlobalRoutines.myStr(Involucr(k, j).HydrDepth * kLength, 5, 3, False)
            ._TextCil_9.Value = NBocch
            ._TextCil_11.Text = GlobalRoutines.myStr(Involucr(k, j).DensFluido, 5, 3, False)
            ._TextCil_12.Text = GlobalRoutines.myStr(Involucr(k, j).Destemp * kTemp + kTemp32, 5, 3, False)
            ._TextCil_13.Text = GlobalRoutines.myStr(Involucr(k, j).Spess * kLength, 4, 2, False)
            ._TextCil_14.Text = GlobalRoutines.myStr(Involucr(k, j).PressInt * kPress, 6 - IncrVirgola, 1 + IncrVirgola, 0)
            ._TextCil_15.Text = GlobalRoutines.myStr(Involucr(k, j).PressExt * kPress, 6 - IncrVirgola, 1 + IncrVirgola, 0)
            ._TextCil_16.Value = Involucr(k, j).SottoTipo
            If Config(0).DiverseTemp = 0 Or VerificandoPI Then
                .LabelCil(14).Visible = False
                ._TextCil_12.Visible = False
                ._cmdCil_5.Visible = False
            End If
            If Involucr(kLato, jInvolucr).ms = 2 Then
                ._LabelCil_3.Visible = True
                ._TextCil_1.Visible = True
                ._cmdCil_3.Visible = True
                ._LabelCil_4.Visible = False
                ._TextCil_2.Visible = False
                ' ._LabelCil_5.Visible = False
                ' ._TextCil_3.Visible = False
                ' Involucr(kLato, jInvolucr).ES = 1
            Else
                ._LabelCil_3.Visible = False
                ._TextCil_1.Visible = False
                ._cmdCil_3.Visible = False
                ._LabelCil_4.Visible = True
                ._TextCil_2.Visible = True
                ' ._LabelCil_5.Visible = True
                ' ._TextCil_3.Visible = True
            End If 'k
        End With
    End Sub
    Public Sub AggDatiFon(ByRef k As Short, ByRef j As Short)
        Dim NBocch As Short
        NBocch = Involucr(k, j).Fine - Involucr(k, j).inizio + 1
        If NBocch < 0 Or Involucr(k, j).Fine < 1 Then NBocch = 0
        With frmFon.DefInstance
            ._cmbCil_0.Text = Involucr(k, j).Mark.Trim
            ._cmbCil_1.SelectedIndex = Involucr(k, j).ms - 1
            Popola(.cmbMat)
            .cmbMat.Text = Involucr(k, j).MATE.Trim
            .chkAgganciato.Checked = Matdim(Involucr(kLato, jInvolucr).indice(0)).Agganciato
            If div = 2 Then
                ._TextCil_1.Text = GlobalRoutines.myStr(Involucr(k, j).Dati(4 - 4) * kPress, 6 - IncrVirgola, 1 + IncrVirgola, 0)
            Else
                ._TextCil_1.Text = GlobalRoutines.myStr(Involucr(k, j).SU * kPress, 6 - IncrVirgola, 1 + IncrVirgola, 0)
            End If
            ._TextCil_2.Text = GlobalRoutines.myStr(Involucr(k, j).L0 * kLength, 5, 2, False)
            If Involucr(k, j).ES = 0 Then Involucr(k, j).ES = Config(k).Efficienza
            ._TextCil_3.Text = GlobalRoutines.myStr(Involucr(k, j).ES, 2, 2, False)
            ._TextCil_4.Text = GlobalRoutines.myStr(Involucr(k, j).OS * kLength, 2, 2, False)
            ._TextCil_5.Text = GlobalRoutines.myStr(Involucr(k, j).cs * kLength, 2, 2, False)
            If VerificandoPI Then
                ._TextCil_6.Text = GlobalRoutines.myStr(Involucr(k, j).Shydr * kPress, 6 - IncrVirgola, 1 + IncrVirgola, 0)
            Else
                ._TextCil_6.Text = GlobalRoutines.myStr(Involucr(k, j).S0 * kPress, 6 - IncrVirgola, 1 + IncrVirgola, 0)
            End If
            ._TextCil_7.Text = GlobalRoutines.myStr(Involucr(k, j).St * kPress, 6 - IncrVirgola, 1 + IncrVirgola, 0)
            ._TextCil_8.Text = GlobalRoutines.myStr(Involucr(k, j).H0 * kLength, 5, 3, False)
            ._TextCil_10.Text = GlobalRoutines.myStr(Involucr(k, j).HydrDepth * kLength, 5, 3, False)
            ._TextCil_9.Value = NBocch
            ._TextCil_11.Text = GlobalRoutines.myStr(Involucr(k, j).R0 * kLength, 5, 3, False)
            ._TextCil_12.Text = GlobalRoutines.myStr(Involucr(k, j).di * kLength, 5, 3, False)
            ._TextCil_13.Text = GlobalRoutines.myStr(Involucr(k, j).DensFluido, 5, 3, False)
            ._TextCil_14.Text = GlobalRoutines.myStr(Involucr(k, j).Destemp * kTemp + kTemp32, 5, 3, False)
            ._TextCil_15.Text = GlobalRoutines.myStr(Involucr(k, j).PressInt * kPress, 6 - IncrVirgola, 1 + IncrVirgola, 0)
            ._TextCil_16.Text = GlobalRoutines.myStr(Involucr(k, j).PressExt * kPress, 6 - IncrVirgola, 1 + IncrVirgola, 0)
            ._TextCil_17.Text = GlobalRoutines.myStr(Involucr(k, j).Spess * kLength, 5, 2, False)
            If Config(0).DiverseTemp = 0 And k < 3 Or VerificandoPI Then
                ._LabelCil_16.Visible = False
                ._TextCil_14.Visible = False
                ._cmdCil_5.Visible = False
            End If
        End With
    End Sub
    Public Sub MostraFrame()
        With mioApert
            .PictureBox1.Visible = False
            .Frames(0).Visible = True
            .Frames(1).Visible = True
            ._Frames_2.Visible = True
            .Frames(0).BringToFront()
            .Frames(1).BringToFront()
            ._Frames_2.BringToFront()
            .StatusBar1.BringToFront()
            .MainMenu1.BringToFront()
        End With
    End Sub
    Public Sub AggDatiBel(ByRef k As Short, ByRef j As Short)
        Dim NBocch As Short
        NBocch = Involucr(k, j).Fine - Involucr(k, j).inizio + 1
        If NBocch < 0 Or Involucr(k, j).Fine < 1 Then NBocch = 0
        With frmBel.DefInstance
            ._cmbCil_0.Text = Involucr(k, j).Mark.Trim
            Popola(.cmbMat)
            .cmbMat.Text = Involucr(k, j).MATE.Trim
            .chkAgganciato.Checked = Matdim(Involucr(kLato, jInvolucr).indice(0)).Agganciato
            '  ._TextCil_1 = Str$(Involucr(j).dns)
            ._TextCil_2.Text = GlobalRoutines.myStr(Involucr(k, j).dns * kLength, 5, 2, False)
            If Involucr(k, j).ES = 0 Then Involucr(k, j).ES = Config(k).Efficienza
            ._TextCil_3.Text = GlobalRoutines.myStr(Involucr(k, j).ES, 2, 2, False)
            ._TextCil_4.Text = GlobalRoutines.myStr(Involucr(k, j).OS * kLength, 2, 2, False)
            ._TextCil_5.Text = GlobalRoutines.myStr(Involucr(k, j).cs * kLength, 2, 2, False)
            If VerificandoPI Then
                ._TextCil_6.Text = GlobalRoutines.myStr(Involucr(k, j).Shydr * kPress, 6 - IncrVirgola, 1 + IncrVirgola, 0)
            Else
                ._TextCil_6.Text = GlobalRoutines.myStr(Involucr(k, j).S0 * kPress, 6 - IncrVirgola, 1 + IncrVirgola, 0)
            End If
            ._TextCil_7.Text = GlobalRoutines.myStr(Involucr(k, j).St * kPress, 6 - IncrVirgola, 1 + IncrVirgola, 0)
            ._TextCil_8.Text = GlobalRoutines.myStr(Involucr(k, j).di * kLength, 5, 3, False)
            ._TextCil_10.Text = GlobalRoutines.myStr(Involucr(k, j).HydrDepth * kLength, 5, 3, False)
            ._TextCil_9.Value = NBocch
            ._TextCil_11.Text = GlobalRoutines.myStr(Involucr(k, j).L0 * kLength, 5, 3, False)
            ._TextCil_12.Text = GlobalRoutines.myStr(Involucr(k, j).Spess * kLength, 5, 3, False)
            ._TextCil_13.Text = GlobalRoutines.myStr(Involucr(k, j).H0 * kLength, 5, 3, False)
        End With
    End Sub
    Public Function NuovoIndObj() As Short
        Dim Dimen As Short
        On Error GoTo ErrNIO
        Dimen = UBound(objMemb)
        Dimen = Dimen + 1
Rn:     On Error GoTo 0
        ReDim Preserve objMemb(Dimen)
        NuovoIndObj = Dimen
        Exit Function
ErrNIO:
        Dimen = 1
        Resume Rn
    End Function
    Public Function NuovoIndProbl() As Short
        Dim Dimen As Short
        On Error GoTo ErrNIO
        Dimen = UBound(Problem)
        Dimen = Dimen + 1
Rn:     On Error GoTo 0
        ReDim Preserve DatiInt(Dimen)
        ReDim Preserve Problem(Dimen) 'strutture dati e azzeramento
        Problem(Dimen).Initialize()
        ReDim Preserve FlChan(Dimen)
        FlChan(Dimen).Initialize()
        ReDim Preserve FlShel(Dimen)
        FlShel(Dimen).Initialize()
        NuovoIndProbl = Dimen
        Exit Function
ErrNIO:
        Dimen = 0
        Resume Rn
    End Function
    Public Function NuovoIndice() As Short
        Dim i As Short
        Dim Dimen As Short
        Try
            Dimen = UBound(Matdim)
            For i = 1 To Dimen
                If Not EsisteIndice(i) Then
                    NuovoIndice = i
                    Matdim(i) = New LibMat.MaterialeNew1
                    Exit Function
                End If
            Next i
            If i > Dimen Then ReDim Preserve Matdim(2 * Dimen)
            NuovoIndice = i
            Matdim(i) = New LibMat.MaterialeNew1
        Catch e As Exception
            MessageBox.Show(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Function
    Public Sub CambiaIndice(ByVal i As Short, ByVal j As Short)
        Dim l, k, kk, Nnozz As Short
        For kk = 1 To Config(0).NumeroLati
            If Config(kk).Ninvolucri = 0 Then GoTo jumpk
            For k = 1 To Config(kk).Ninvolucri
                For l = 1 To 8
                    If Involucr(kk, k).indice(l - 1) = i Then Involucr(kk, k).indice(l - 1) = j
                Next
                If Involucr(kk, k).Tipo = 5 Then
                    If Not CType(objMemb(Involucr(kk, k).IndObject), wn_flan).Diaf Is Nothing Then
                        With CType(objMemb(Involucr(kk, k).IndObject), wn_flan).Diaf
                            If .pindiceW = i Then .pindiceW = j
                            If .pindiceB = i Then .pindiceB = j
                            If .pindiceC = i Then .pindiceC = j
                            If .pindiceD = i Then .pindiceD = j
                            If .pindiceF = i Then .pindiceF = j
                        End With
                    End If
                End If
            Next
            Nnozz = NumBocch(kk) + NumBocch2(kk)
            If Nnozz > 0 Then ' Exit Function
                CheckDimNoz(Nnozz)
                For k = 1 To Nnozz
                    If Nozzles(kk, k).indice = i Then Nozzles(kk, k).indice = j
                    If Nozzles(kk, k).IndiceP = i Then Nozzles(kk, k).IndiceP = j
                    If Nozzles(kk, k).IndiceB = i Then Nozzles(kk, k).IndiceB = j
                    If Nozzles(kk, k).IndexF = i Then Nozzles(kk, k).IndexF = j
                Next k
            End If
jumpk:
        Next kk
    End Sub
    Public Function EsisteIndice(ByVal i As Short, Optional ByVal klEscludi As Short = -1, _
           Optional ByVal jEscludi As Short = -1, Optional ByVal kEscludi As Short = -1) As Boolean
        Dim l, k, kk, Nnozz As Short
        For kk = 1 To Config(0).NumeroLati
            If Config(kk).Ninvolucri = 0 Then GoTo jumpk
            For k = 1 To Config(kk).Ninvolucri
                If Not (klEscludi = kk And jEscludi = k) Then
                    For l = 1 To 8
                        If Involucr(kk, k).indice(l - 1) = i Then Return True
                    Next
                    If Involucr(kk, k).Tipo = 5 Then
                        If Not CType(objMemb(Involucr(kk, k).IndObject), wn_flan).Diaf Is Nothing Then
                            With CType(objMemb(Involucr(kk, k).IndObject), wn_flan).Diaf
                                If .pindiceW = i Then Return True
                                If .pindiceB = i Then Return True
                                If .pindiceC = i Then Return True
                                If .pindiceD = i Then Return True
                                If .pindiceF = i Then Return True
                            End With
                        End If
                    End If
                End If
            Next
            Nnozz = NumBocch(kk) + NumBocch2(kk)
            If Nnozz > 0 Then ' Exit Function
                CheckDimNoz(Nnozz)
                For k = 1 To Nnozz
                    If Not (klEscludi = kk And kEscludi = k) Then
                        If Nozzles(kk, k).indice = i Then Return True
                        If Nozzles(kk, k).IndiceP = i Then Return True
                        If Nozzles(kk, k).IndiceB = i Then Return True
                        If Nozzles(kk, k).IndexF = i Then Return True
                    End If
                Next k
            End If
jumpk:
        Next kk
        Return False
    End Function
    Public Sub MatdimScelta(ByVal indice As Short, ByVal Classe As Short, ByVal k As Short, _
                            Optional ByVal j As Short = -1, Optional ByVal n As Short = -1, _
                            Optional ByVal x As Single = 0, Optional ByVal y As Single = 0)
        Static Conteggio As Short
        Dim i As Short
        Dim l As LinkedList = ListaIndici(indice, k, j, n)
        Dim lCount As Short = l.Count
        If lCount > 0 Then
            If Config(0).Verbose Then
                Dim Testo As String = Helpstringa(1151) ' "Con questa operazione si cambierà anche il materiale|delle seguenti membrature (o di un loro particolare):|"
                For i = 1 To lCount - 1
                    Testo = Testo + l(i) + ",|"
                Next
                Testo = Testo + l(lCount) + Helpstringa(1152) '".|Se invece si vuole definire un materiale specifico per la|presente membratura bisogna scegliere 'Nuovo materiale'|dal menu a discesa, e, normalmente, contrassegnarlo 'bound',|ed infine cliccare nuovamente sul pulsante per|la ricerca del materiale."
                If MostraAiuto(1151, ChiaviMess.MessInformation + ChiaviMess.MessOKCancel, Testo, Helpstringa(1153)) = ChiaviMess.MessCancel Then Exit Sub
            Else
                Conteggio += 1
                If Conteggio > 2 Then
                    Conteggio = 0
                    Config(0).Verbose = True
                End If
            End If
        End If
        Matdim(indice).Scelta(Classe, x:=x, y:=y)
    End Sub
    Public Function ListaIndici(ByVal i As Short, Optional ByVal klEscludi As Short = -1, _
           Optional ByVal jEscludi As Short = -1, Optional ByVal kEscludi As Short = -1) As LinkedList
        Dim lista As New LinkedList(1)
        Dim l, k, kk, Nnozz As Short
        For kk = 1 To Config(0).NumeroLati
            If Config(kk).Ninvolucri = 0 Then GoTo jumpk
            For k = 1 To Config(kk).Ninvolucri
                If Not (klEscludi = kk And jEscludi = k) Then
                    For l = 1 To 8
                        If Involucr(kk, k).indice(l - 1) = i Then lista.AddSingolo(Involucr(kk, k).Mark)
                    Next
                    If Involucr(kk, k).Tipo = 5 Then
                        If Not CType(objMemb(Involucr(kk, k).IndObject), wn_flan).Diaf Is Nothing Then
                            With CType(objMemb(Involucr(kk, k).IndObject), wn_flan).Diaf
                                If .pindiceW = i Then lista.AddSingolo(Involucr(kk, k).Mark)
                                If .pindiceB = i Then lista.AddSingolo(Involucr(kk, k).Mark)
                                If .pindiceC = i Then lista.AddSingolo(Involucr(kk, k).Mark)
                                If .pindiceD = i Then lista.AddSingolo(Involucr(kk, k).Mark)
                                If .pindiceF = i Then lista.AddSingolo(Involucr(kk, k).Mark)
                            End With
                        End If
                    End If
                End If
            Next
            Nnozz = NumBocch(kk) + NumBocch2(kk)
            If Nnozz > 0 Then ' Exit Function
                CheckDimNoz(Nnozz)
                For k = 1 To Nnozz
                    If Not (klEscludi = kk And kEscludi = k) Then
                        If Nozzles(kk, k).indice = i Then lista.AddSingolo(Nozzles(kk, k).Mark)
                        If Nozzles(kk, k).IndiceP = i Then lista.AddSingolo(Nozzles(kk, k).Mark)
                        If Nozzles(kk, k).IndiceB = i Then lista.AddSingolo(Nozzles(kk, k).Mark)
                        If Nozzles(kk, k).IndexF = i Then lista.AddSingolo(Nozzles(kk, k).Mark)
                    End If
                Next k
            End If
jumpk:
        Next kk
        Return lista
    End Function
    Public Function CodiceCalc() As String
        Dim Testo As String = ""
        Dim l As Short
        Select Case Config(kLato).DC
            Case 0, 1, 2
                Testo = clsInizio.ReadIniFile("", "Preferenze AsmeVip", "Division1")
                If Len(Trim(Testo)) = 0 Then
                    Testo = " ASME VIII Div.1 2000 Ed.+2002 Add."
                    clsInizio.WriteIniFile("", "Preferenze AsmeVip", "Division1", Testo)
                End If
            Case 3, 4, 5
                Testo = clsInizio.ReadIniFile("", "Preferenze AsmeVip", "Division2")
                If Len(Trim(Testo)) = 0 Then
                    Testo = " ASME VIII Div.2 2000 Ed.+2002 Add."
                    clsInizio.WriteIniFile("", "Preferenze AsmeVip", "Division2", Testo)
                End If
            Case 6, 7, 8
                Testo = clsInizio.ReadIniFile("", "Preferenze AsmeVip", "EuroCode")
                If Len(Trim(Testo)) = 0 Then
                    Testo = " EN-13345-3 rev.4 15-10-2001"
                    clsInizio.WriteIniFile("", "Preferenze AsmeVip", "EuroCode", Testo)
                End If
            Case 9, 10, 11
                Testo = clsInizio.ReadIniFile("", "Preferenze AsmeVip", "ped/div.1")
                If Len(Trim(Testo)) = 0 Then
                    Testo = "PED/ASME VIII Div.1 2000 Ed.+2002 Add."
                    clsInizio.WriteIniFile("", "Preferenze AsmeVip", "ped/div.1", Testo)
                End If
        End Select
        l = Len(Testo)
        If l < 40 Then
            Testo = New String(" ", (40 - l) / 2) & Testo & New String(" ", (40 - l) / 2)
        End If
        CodiceCalc = Testo
    End Function
    Public Function CodiceStress(Optional ByRef f As Boolean = False) As Short
        Select Case Config(kLato).DC
            Case 0, 1, 2, 9, 10, 11
                Select Case Config(0).US
                    Case 0
                        CodiceStress = CShort(LibMat.Codes.div1MPa)
                    Case Else
                        CodiceStress = CShort(LibMat.Codes.div1psi)
                End Select
            Case 3, 4, 5
                If f Then
                    Select Case Config(0).US
                        Case 0
                            CodiceStress = CShort(LibMat.Codes.div1MPa)
                        Case Else
                            CodiceStress = CShort(LibMat.Codes.div1psi)
                    End Select
                Else
                    Select Case Config(0).US
                        Case 0
                            CodiceStress = CShort(LibMat.Codes.div2MPa)
                        Case Else
                            CodiceStress = CShort(LibMat.Codes.div2psi)
                    End Select
                End If
            Case 6 To 8
                CodiceStress = CShort(LibMat.Codes.EU) ' 8
        End Select
    End Function
    Public Function RulePI() As String
        RulePI = ""
        Select Case Config(0).MetodoPI
            Case 0
                Select Case Config(kLato).DC
                    Case 0, 1, 2, 9, 10, 11
                        RulePI = "UG-99(b)"
                    Case 3, 4, 5
                        RulePI = "AT-300"
                    Case 6
                        MessageBox.Show("EuroNOrm in RulePI")
                End Select
            Case 1
                Select Case Config(kLato).DC
                    Case 0, 1, 2, 9, 10, 11
                        RulePI = "UG-99(c)"
                    Case 3, 4, 5
                        RulePI = "AT-301"
                    Case 6
                        MessageBox.Show("EuroNOrm in RulePI")
                End Select
        End Select
    End Function
    Public Function RappPI() As Single
        Select Case Config(kLato).DC
            Case 0, 1, 2
                RappPI = 1.3
            Case 3, 4, 5
                RappPI = 1.25
            Case 6 To 11
                RappPI = 1.25
            Case Else
                RappPI = 1
        End Select
    End Function
    Public Function RappPIx() As Single
        Select Case Config(kLato).DC
            Case 0, 1, 2
                RappPIx = 1.3
            Case 3, 4, 5
                RappPIx = 1.25
            Case 6 To 11
                RappPIx = 1.43
            Case Else
                RappPIx = 1
        End Select
    End Function
    Public Sub Stamparo(ByRef Titolo As String, Optional ByRef File As Object = Nothing)
        Dim ifl, n As Short
        Dim Testo, Filep As String
        If IsNothing(File) Then
            Filep = clsInizio.DiscoRam & "ROTFLFOR.OUT"
        Else
            Filep = File
        End If
        If Len(Titolo) > 0 Then
            If Not PrepRapp(Template, Titolo, Involucr(kLato, jInvolucr).Mark.Trim, FileSt, mioApert.lstRapp) Then Exit Sub
        End If
        If IsNothing(File) Then Monitor.Motore.Testata()
        FileClose(ifl)
        ifl = FreeFile()
        FileOpen(ifl, Filep, OpenMode.Input)
        If Not Template = "HEADER" Then
            Testo = LineInput(ifl)
            n = InStr(Testo, "\page")
            If n > 0 Then Testo = "\pard\plain \s18\qj\widctlpar\tx4536 \f2\fs18\lang1040 " & Testo 'Right(Testo, Len(Testo) - n - 4)
            Monitor.Motore.Problem.Printa(Testo)
        End If
        Do
            If EOF(ifl) Then Exit Do
            Testo = LineInput(ifl)
            Monitor.Motore.Problem.Printa(Testo)
        Loop
        FileClose(ifl)
    End Sub


    Public Function NumInvTot() As Short
        If Config(0).NumeroLati = 1 Then
            NumInvTot = Config(1).Ninvolucri
        ElseIf Config(0).NumeroLati = 3 Then
            NumInvTot = Config(1).Ninvolucri + Config(2).Ninvolucri + Config(3).Ninvolucri
        End If
    End Function

    Public Function TempDes() As Single
        Dim td1, td2 As Single
        Dim SU As Short
        If VerificandoPI Then
            td1 = 20
        Else
            If kLato < 3 Then
                td1 = Config(kLato).tdx
            Else
                td1 = Config(1).tdx
                If Config(2).tdx > td1 Then td1 = Config(2).tdx
                td2 = Involucr(kLato, jInvolucr).Destemp
                If td2 >= Config(1).tdx Or td2 >= Config(2).tdx Then td1 = td2
            End If
            If Config(0).DiverseTemp <> 0 Then
                If jInvolucr > 0 Then
                    td1 = Involucr(kLato, jInvolucr).Destemp
                ElseIf jInvolucr < 0 Then
                    SU = Nozzles(kLato, -jInvolucr).InvolucroSU
                    If SU < 0 Then SU = Nozzles(kLato, -SU).InvolucroSU
                    td1 = Involucr(kLato, SU).Destemp
                Else
                    If kLato = 0 Then Exit Function
                    SU = Nozzles(kLato, kNozzle).InvolucroSU
                    If SU > 0 Then td1 = Involucr(kLato, SU).Destemp
                End If
            End If
        End If
        TempDes = td1
    End Function
    Public Function PrepRapp(ByRef Templ As String, ByRef Tipo As String, ByVal Elemento As String, _
                             ByRef FileSt As String, ByRef lstRapp As ListView, Optional ByVal livello As Short = 0) As Boolean
        Dim obj As Lancio.Office.Word.WinForms.WordReportPanel
        mioApert.Check1.Enabled = False
        mioApert.Text1.Enabled = False
        FileSt = mioApert.Text1.Text
        If OptWordIn Then
            obj = mioApert.wordPanel
        End If
        PrepRapp = Monitor.Motore.PrepRapp(FileSt, Templ, Tipo, Elemento, lstRapp, livello, obj)
    End Function
    Public Function PrepRappMEMO(ByRef Templ As String, ByRef Tipo As String, ByVal Elemento As String, ByRef FileSt As String, ByRef lstRapp As ListView) As Boolean
        mioApert.Check1.Enabled = False
        mioApert.Text1.Enabled = False
        PrepRappMEMO = Monitor.Motore.PrepRapp(FileSt, Templ, Tipo, Elemento, lstRapp)
    End Function
    Sub CloseioutS(ByRef lstRapp As ListView, Optional ByRef anche As Boolean = False)
        Dim Appl As Object 'Application
        Monitor.Motore.Problem.ChiudiRapp()
        If Not lstRapp Is Nothing Then lstRapp.Items.Clear()
        If Not mioApert Is Nothing Then
            If Not div = 2 Then mioApert.Check1.Enabled = True
            mioApert.Text1.Enabled = True
        End If
        If Not Documento Is Nothing Then
            If OptWordIn Then
                mioApert.wordPanel.CloseDocument()
            Else
                Appl = Documento.App 'lication
                Documento.sClose(1) 'wdSaveChanges
                If mioApert.Check1.CheckState = 1 Then
                    Documento.sCloseAll(2)
                End If
                If anche Then Appl.Quit()
            End If
            Documento = Nothing
        End If
    End Sub
    Public Function IndiceRat(ByRef R As Short) As Short
        Select Case R
            Case 150 : IndiceRat = 1
            Case 300 : IndiceRat = 2
            Case 400 : IndiceRat = 3
            Case 600 : IndiceRat = 4
            Case 900 : IndiceRat = 5
            Case 1500 : IndiceRat = 6
            Case 2500 : IndiceRat = 7
            Case Else : IndiceRat = 0
        End Select
    End Function
    Public Function CerMat(ByRef jRec As Short, ByRef locInd As Short) As Short
        If Matdim(jRec).Indmat > 0 Or Not Matdim(jRec).Agganciato Then Exit Function
        If locInd > 0 Then
            If Config(0).Verbose And Not formTab.GiaDetto Then
                Select Case locInd
                    Case 2
                        MessageBox.Show("Materiale dei bulloni non definito")
                    Case Else
                        MessageBox.Show("Materiale non definito")
                End Select
                formTab.GiaDetto = True
            End If
            CerMat = -1
        ElseIf locInd = -1 Then
            If Nozzles(kLato, kNozzle).RecIndF > 0 Then
                Matdim(jRec).Indmat = Nozzles(kLato, kNozzle).RecIndF
                Matdim(jRec).RecupMat(clsInizio.Archdir)
            Else
                If Config(0).Verbose And Not formTab.GiaDetto Then
                    MessageBox.Show("Materiale non definito per la flangia del bocchello " & Nozzles(kLato, kNozzle).Mark)
                    formTab.GiaDetto = True
                End If
                CerMat = -1
            End If
        ElseIf locInd = -2 Then
            If Nozzles(kLato, kNozzle).RecIndB > 0 Then
                Matdim(jRec).Indmat = Nozzles(kLato, kNozzle).RecIndB
                Matdim(jRec).RecupMat(clsInizio.Archdir)
            Else
                If Config(0).Verbose And Not formTab.GiaDetto Then
                    If jInvolucr > 0 Then MessageBox.Show("Materiale non definito per i bulloni della flangia")
                    formTab.GiaDetto = True
                End If
                CerMat = -1
            End If
        End If
    End Function
    Public Function CercaPadre(ByRef k As Short, ByRef j As Short) As Collegamento
        Dim i As Short
        CercaPadre = Nothing
        With ElencoCollegamenti
            For i = 1 To .Count()
                If .Item(i).Lato1 = k And .Item(i).Membro1 = j Then
                    CercaPadre = .Item(i)
                    Exit Function
                End If
            Next
        End With
    End Function
    Public Function CercaFiglio(ByRef k As Short, ByRef j As Short) As Collegamento
        Dim i As Short
        CercaFiglio = Nothing
        With ElencoCollegamenti
            For i = 1 To .Count()
                If .Item(i).Lato2 = k And .Item(i).Membro2 = j Then
                    CercaFiglio = .Item(i)
                    Exit Function
                End If
            Next
        End With
    End Function
    Public Sub CheckCollegamenti()
        Dim j, k, i As Short
        Dim O As wn_PT
        Dim c As Collegamento
        Dim iii As Short
        Do Until ElencoCollegamenti.Count() = 0
            ElencoCollegamenti.Remove(1)
        Loop
        For k = 1 To Config(0).NumeroLati
            For j = 1 To Config(k).Ninvolucri
                If Involucr(k, j).AccoppK > 0 Then
                    c = New Collegamento
                    c.Tipo = 1
                    c.Lato1 = k : c.Membro1 = j
                    c.Lato2 = Involucr(k, j).AccoppK
                    c.Membro2 = Involucr(k, j).AccoppJ
                    ElencoCollegamenti.Add(c)
                End If
                Select Case Involucr(k, j).Tipo
                    Case 2, 3 'cono
                        If Involucr(k, j).jmemb1 > 0 Then
                            c = New Collegamento
                            c.Tipo = 2
                            c.Lato1 = k : c.Membro1 = j
                            c.Lato2 = k
                            c.Membro2 = Involucr(k, j).jmemb1
                            ElencoCollegamenti.Add(c)
                        End If
                        If Involucr(k, j).jmemb2 > 0 Then
                            c = New Collegamento
                            c.Tipo = 3
                            c.Lato1 = k : c.Membro1 = j
                            c.Lato2 = k
                            c.Membro2 = Involucr(k, j).jmemb2
                            ElencoCollegamenti.Add(c)
                        End If
                    Case 5 'Flangione
                    Case 6 'Piastra tubiera
                        O = CType(objMemb(Involucr(k, j).IndObject), wn_PT)
                        If O.TipoPT = 2 Then
                            If CType(O.Piastra, wn_FTC).IndiceDilat > 0 Then
                                c = New Collegamento
                                c.Tipo = 4
                                c.Lato1 = k : c.Membro1 = j
                                c.Lato2 = 1
                                c.Membro2 = CType(O.Piastra, wn_FTC).IndiceDilat
                                ElencoCollegamenti.Add(c)
                            End If
                            For i = 1 To 4
                                If O.IndAccopp(i) > 0 Then
                                    c = New Collegamento
                                    c.Tipo = 4 + i
                                    c.Lato1 = k : c.Membro1 = j
                                    Select Case i
                                        Case 2 'FlShel
                                            c.Lato2 = 1
                                        Case 1 'FlChan
                                            c.Lato2 = 2
                                        Case 4 'SlShel
                                            c.Lato2 = 1
                                        Case 3 'SlChan
                                            c.Lato2 = 2
                                    End Select
                                    c.Membro2 = O.IndAccopp(i)
                                    ElencoCollegamenti.Add(c)
                                End If
                            Next
                            If CType(O.Piastra, wn_FTC).IndiceFondo > 0 Then
                                c = New Collegamento
                                c.Tipo = 10
                                c.Lato1 = k : c.Membro1 = j
                                Select Case CType(O.Piastra, wn_FTC).Flottante
                                    Case 1 : iii = 2
                                    Case Else : iii = 3
                                End Select
                                c.Lato2 = iii
                                c.Membro2 = CType(O.Piastra, wn_FTC).IndiceFondo
                                ElencoCollegamenti.Add(c)
                            End If
                            If CType(O.Piastra, wn_FTC).IndiceFlanF > 0 Then
                                c = New Collegamento
                                c.Tipo = 11
                                c.Lato1 = k : c.Membro1 = j
                                c.Lato2 = 3
                                c.Membro2 = CType(O.Piastra, wn_FTC).IndiceFlanF
                                ElencoCollegamenti.Add(c)
                            End If
                            If CType(O.Piastra, wn_FTC).IndiceSplitR > 0 Then
                                c = New Collegamento
                                c.Tipo = 13
                                c.Lato1 = k : c.Membro1 = j
                                c.Lato2 = 3
                                c.Membro2 = CType(O.Piastra, wn_FTC).IndiceSplitR
                                ElencoCollegamenti.Add(c)
                            End If
                            If CType(O.Piastra, wn_FTC).IndiceShell > 0 Then
                                c = New Collegamento
                                c.Tipo = 12
                                c.Lato1 = k : c.Membro1 = j
                                c.Lato2 = 1
                                c.Membro2 = CType(O.Piastra, wn_FTC).IndiceShell
                                ElencoCollegamenti.Add(c)
                            End If
                        End If
                    Case 7 'Tubi
                    Case 8 'Dilatatore
                        'vale il caso generale
                End Select
            Next j
        Next k
    End Sub
    Public Sub LegTabella(ByRef File As String, ByRef n As Short, ByRef i6 As Short, ByRef Tdes As Single, ByRef Pmax As Single)
        Dim ifl1, i As Short
        Dim Riga As String = ""
        Dim temp As Single
        Dim Riga0 As String
        Dim Te0, Te1 As Single
        Dim pr0, Pr1, pr As Single
        ifl1 = FreeFile()
410:    FileOpen(ifl1, File, OpenMode.Input, , OpenShare.Shared)
        For i = 1 To 5 : Riga = LineInput(ifl1) : Next
        temp = 0
        Do
            Te0 = temp : Riga0 = Riga
            Riga = LineInput(ifl1) : Riga = LTrim(Riga)
            temp = GlobalRoutines.ValVir(Mid(Riga, 2, i6))
            If temp > Tdes Then Exit Do
            If EOF(ifl1) Then Exit Do
        Loop
        FileClose(ifl1)
420:    ValPre(Riga, n, pr)
        If Te0 > 0 Then
            Pr1 = pr : Te1 = temp : Riga = Riga0
            ValPre(Riga, n, pr)
            pr0 = pr
            Pmax = (Tdes - Te0) / (Te1 - Te0) * (Pr1 - pr0) + pr0
        Else
            Pmax = pr
        End If
        Exit Sub
    End Sub
    Private Sub ValPre(ByVal Riga As String, ByVal n As Short, ByRef pr As Single)
        Dim k, l1, l As Short
        l1 = 5
        For k = 1 To n
            l = InStr(l1, Riga, "³") '?????????????????
            l1 = l + 1
        Next
        pr = GlobalRoutines.ValVir(Mid(Riga, l1, 6))
    End Sub
    Public Function GenFileTraccia() As String
        With Involucr(kLato, jInvolucr)
            If .File Is Nothing Then
                CPath(.File)
            ElseIf .File.Trim.Length > 0 Then
                .File = .File.Trim
            Else
                CPath(.File)
            End If
            GenFileTraccia = .File
        End With
        Exit Function
    End Function
    Private Sub CPath(ByRef File As String)
        Dim Path As String
        Select Case Monitor.Motore.Inizio.LavoriSciolti
            Case False
                Path = Monitor.Motore.Inizio.Workdir & "\" & Trim(job.Comm.Arch)
                File = Path & gstrSEP_DIR & job.Comm.Ind.Item(job.Comm.indice).Data.File & ".INP"
            Case True
                File = Left(icome, Len(icome) - 4) & ".INP"
        End Select
    End Sub
    Public Function TogliBlank(ByRef s As String) As String
        Dim i As Short
        Dim SS As String
        SS = Trim(s)
        For i = 1 To Len(SS)
            If Mid(SS, i, 1) = " " Or Mid(SS, i, 1) = "." Or Mid(SS, i, 1) = "-" Or Mid(SS, i, 1) = "+" Then Mid(SS, i, 1) = "_"
        Next
        TogliBlank = SS
    End Function
    Public Sub PrintlstRes(ByRef a2 As String)
        Dim a1, a As String
        Dim n As Short
        Dim l As ListViewItem
        Dim N1 As Short
        a = RTrim(a2)
        If Right(a, 1) = "|" Then a = Left(a, Len(a) - 1)
        If Right(a, 2) = vbCrLf Then a = Left(a, Len(a) - 2)
        If Right(a, 1) = vbCr Then a = Left(a, Len(a) - 1)
        Do
            a1 = New String(Chr(32), nIndent) & a
            n = InStr(a, "|")
            N1 = 0
            If n = 0 Then
                n = InStr(a, vbCrLf)
                N1 = 1
                If n = 0 Then
                    n = InStr(a, vbCr)
                    N1 = 0
                    If n = 0 Then Exit Do
                End If
            End If
            a1 = New String(Chr(32), nIndent) & Left(a, n - 1)
            l = mioApert.lstRes.Items.Add(a1)
            a = Right(a, Len(a) - n - N1)
            a1 = New String(Chr(32), nIndent) & a
        Loop
        l = mioApert.lstRes.Items.Add(a1)
        l.EnsureVisible()
    End Sub
    Public Sub WarnT(ByRef m As Short)
        Dim Riga As String = ""
        Dim id As Integer
        Select Case m
            Case 1
                id = 4998 ' "ATTENZIONE !           temperatura troppo elevata|"
                'a = a & "      CAMBIA IL MATERIALE O LA TEMPERATURA       "
            Case -9999
                Exit Sub
            Case Is < 0
                Riga = Helpstringa(4000) ' " ATTENZIONE ! MANCANO DEI DATI FONDAMENTALI NELL'INPUT "
                id = 4000 - m
                Riga = Riga & "|" & Helpstringa(id) ' Right(Riga, Len(Riga) - 3)
            Case Else
                id = 4999
                Riga = String.Format(Helpstringa(id), m) ' "ATTENZIONE !           ci sono problemi per il    |"
                'a = a & "calcolo automatico di valori relativi ai materiali|"
                'a = a & "Codice errore: " & Str(m) & "|"
        End Select
        MostraAiuto(id, , Riga)
    End Sub
    Public Function MostraAiuto(ByRef id As Integer, Optional ByRef Informa As RoutBase1.ChiaviMess = RoutBase1.ChiaviMess.MessCritical + RoutBase1.ChiaviMess.MessOkOnly, _
    Optional ByRef mioTesto As String = "", Optional ByRef mioTitolo As String = "", Optional ByVal Proportional As Boolean = False) As RoutBase1.ChiaviMess
        Dim Testo, Tit As String
        If id > 0 Then
            If Len(mioTesto) = 0 Then
                Testo = Monitor.Motore.Inizio.ConvertiCr(Helpstringa(id))
            Else
                Testo = Monitor.Motore.Inizio.ConvertiCr(mioTesto)
            End If
            If Len(mioTitolo) = 0 Then
                Tit = "AsmeVip - Messaggi di errore"
                If Not Informa And RoutBase1.ChiaviMess.MessCritical Then Tit = "AsmeVip"
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
    Public Function CalcolaPIb() As Boolean
        Dim Stringa(1) As String
        Dim Risult(1) As String
        Dim Arch(1) As Short
        Dim dAiu(1) As String
        Dim Ris As Boolean
        Dim vMAWP As clsValoriMAWP
        Dim Hydr As Single
        Dim SU As Short
        Dim vMAWP1 As clsValoriMAWP
        Dim Press As Single
        Dim j As Short
        Dim Testo As String
        pHISS = clsTrigon.Infinito : pHITS = clsTrigon.Infinito
        'Pressione di prova secondo UG-99b
        If colMAWP Is Nothing Then
            mioApert.Enabled = True
            'UPGRADE_WARNING: Screen proprietà Screen.MousePointer presenta un nuovo comportamento. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup2065"'
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            AppActivate(mioApert.Text)
            MostraAiuto(IDH_MANCATABMAT)
            Exit Function
        End If
        For Each vMAWP In colMAWP
            If vMAWP.Sa = 0 Then
                mioApert.Enabled = True
                'UPGRADE_WARNING: Screen proprietà Screen.MousePointer presenta un nuovo comportamento. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup2065"'
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
                AppActivate(mioApert.Text)
                MostraAiuto(IDH_MANCATABMAT)
                Exit Function
            End If
        Next vMAWP
        If Config(0).CalcMAWP = 1 Then
            For Each vMAWP In colMAWP
                If vMAWP.MAWPSS = 0 And vMAWP.MAWPTS = 0 Then
                    Select Case Involucr(vMAWP.k, vMAWP.i).Tipo
                        Case 8 'dilatatore
                            For j = 1 To Config(3).Ninvolucri
                                If Involucr(3, j).Tipo = 6 Then
                                    vMAWP1 = CercavMAWP(3, j, True)
                                    vMAWP.MAWPSS = vMAWP1.MAWPSS
                                    vMAWP.MAWPTS = vMAWP1.MAWPTS
                                    Exit For
                                End If
                            Next
                        Case 9
                            GoTo Cont
                    End Select
                    If vMAWP.MAWPSS = 0 And vMAWP.MAWPTS = 0 Then
                        AppActivate(mioApert.Text)
                        MostraAiuto(IDH_MANCATABMAWP)
                        '  Debug.Print vMAWP.Mark
                        Exit Function
                    End If
                End If
Cont:
            Next vMAWP
        End If
        For Each vMAWP In colMAWP
            With vMAWP
                If .Inv And Not .Bolt Then
                    j = .i
                    Hydr = Involucr(.k, j).HydrDepth
                ElseIf Not .Inv And Not .Bolt And Not .Flangia Then
                    SU = Nozzles(.k, .i).InvolucroSU
Rif1:               If SU > 0 Then
                        j = SU
                        Hydr = Involucr(.k, SU).HydrDepth
                    ElseIf SU < 0 Then
                        SU = Nozzles(.k, -SU).InvolucroSU
                        GoTo Rif1
                    End If
                ElseIf .Inv And .Bolt Then
                    vMAWP1 = CercavMAWP(.k, j, .Inv, False)
                    Hydr = Involucr(vMAWP1.k, vMAWP1.i).HydrDepth
                ElseIf Not .Inv And (.Flangia Or .Bolt) Then
                    vMAWP1 = CercavMAWP(.k, j, .Inv, False, False)
                    If Not vMAWP1 Is Nothing Then 'se è la flangia non sa dove sta
                        SU = Nozzles(vMAWP1.k, vMAWP1.i).InvolucroSU
Rif2:                   If SU > 0 Then
                            j = SU
                            Hydr = Involucr(vMAWP1.k, SU).HydrDepth
                        ElseIf SU < 0 Then
                            SU = Nozzles(vMAWP1.k, -SU).InvolucroSU
                            GoTo Rif2
                        End If
                    End If
                End If
                If Config(0).HTTestVert = 0 Then Hydr = Config(.k).di
                If Hydr <= 0 Then
                    If Config(0).HTTestVert = 0 Then
                        If .k = 3 Then
                            Hydr = Config(1).di
                            If Config(2).di > Hydr Then Hydr = Config(2).di
                            Config(3).di = Hydr
                        End If
                        '       If Hydr <= 0 Then
                        '        Testo = "E' stata selezionata la prova idraulica in orizzontale,|"
                        'Testo = Testo + "ma non è stato definito il diametro dell'apparecchio.|"
                        'Testo = Testo + "Fornire la profondità idrostatica in prova idraulica|"
                        'Testo = Testo + "in millimetri"
                        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.inizio.ConvertiCr(). Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                        Testo = Monitor.Motore.Inizio.ConvertiCr(Helpstringa(IDH_ST_HYDRDEPTHH))
                        '       Hydr = GlobaLroutines.ValVir(InputBox(Testo, "AsmeVip", "      "))
                        Risult(1) = Format(Hydr, FormInch)
                        Stringa(1) = "Profondità idrostatica [mm]"
                        'UPGRADE_WARNING: Screen proprietà Screen.MousePointer presenta un nuovo comportamento. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup2065"'
                        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
                        Ris = Monitor.Motore.InputDati(1, "Prova idraulica in orizzontale", Stringa, Risult, "", Arch, dAiu, Testo)
                        If Not Ris Then CalcolaPIb = False : Exit Function
                        Hydr = GlobalRoutines.ValVir(Risult(1))
                        Config(.k).di = Hydr
                        'UPGRADE_WARNING: Screen proprietà Screen.MousePointer presenta un nuovo comportamento. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup2065"'
                        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
                        ' End If
                    Else
                        '        Testo = "E' stata selezionata la prova idraulica in verticale,|"
                        'Testo = Testo + "ma non è stata definita la profondità idrostatica.|"
                        'Testo = Testo + "della membratura &.|"
                        'Testo = Testo + "Fornire il valore in millimetri."
                        GlobalRoutines.FormatS("non|")
                        Testo = Monitor.Motore.Inizio.ConvertiCr(GlobalRoutines.FormatS(Helpstringa(IDH_ST_HYDRDEPTHV), Involucr(.k, j).Mark))
                        Risult(1) = Format(Hydr, FormInch)
                        Stringa(1) = "Profondità idrostatica [mm]"
                        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
                        Ris = Monitor.Motore.InputDati(1, "Prova idraulica in verticale", Stringa, Risult, "", Arch, dAiu, Testo)
                        If Not Ris Then CalcolaPIb = False : Exit Function
                        Hydr = GlobalRoutines.ValVir(Risult(1))
                        Involucr(.k, j).HydrDepth = Hydr
                        'UPGRADE_WARNING: Screen proprietà Screen.MousePointer presenta un nuovo comportamento. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup2065"'
                        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
                    End If
                End If
                If Config(0).CalcMAWP = 0 Then
                    Select Case .k
                        Case 1
                            Press = Config(1).p0x
                            .corrMAWPSS = RappPI() * Press * .Sa / .St - GRAV * 0.000001 * Hydr
                            .corrMAWPTS = 0
                        Case 2
                            Press = Config(2).p0x
                            .corrMAWPSS = 0
                            .corrMAWPTS = RappPI() * Press * .Sa / .St - GRAV * 0.000001 * Hydr
                        Case 3
                            Press = Config(1).p0x
                            .corrMAWPSS = RappPI() * Press * .Sa / .St - GRAV * 0.000001 * Hydr
                            Press = Config(2).p0x
                            .corrMAWPTS = RappPI() * Press * .Sa / .St - GRAV * 0.000001 * Hydr
                    End Select
                    If .corrMAWPSS < pHISS And .corrMAWPSS > 0 Then pHISS = .corrMAWPSS
                    If .corrMAWPTS < pHITS And .corrMAWPTS > 0 Then pHITS = .corrMAWPTS
                Else
                    If .MAWPSS > 0 Then
                        .corrMAWPSS = RappPI() * .MAWPSS * .Sa / .St - GRAV * 0.000001 * Hydr
                        If .corrMAWPSS < pHISS And .corrMAWPSS > 0 Then pHISS = .corrMAWPSS
                        '         Debug.Print .Mark
                    End If
                    If .MAWPTS > 0 Then
                        .corrMAWPTS = RappPI() * .MAWPTS * .Sa / .St - GRAV * 0.000001 * Hydr
                        If .corrMAWPTS < pHITS And .corrMAWPTS > 0 Then pHITS = .corrMAWPTS
                    End If
                End If
            End With
        Next vMAWP
        DisplayPI()
        CalcolaPIb = True
    End Function
    Public Function CalcolaPIc() As Boolean
        Dim vMAWP As clsValoriMAWP
        Dim Hydr As Single
        Dim SU As Short
        Dim j As Short
        Dim Testo As String
        pHISS = clsTrigon.Infinito : pHITS = clsTrigon.Infinito
        'Pressione di prova secondo UG-99c
        If colMAWP Is Nothing Then
            AppActivate(mioApert.Text)
            MostraAiuto(IDH_MANCATABMAWP)
            Exit Function
        End If
        For Each vMAWP In colMAWP
            With vMAWP
                If .Inv Then
                    j = .i
                    Hydr = Involucr(.k, j).HydrDepth
                Else
                    SU = Nozzles(.k, .i).InvolucroSU
Rif1:               If SU > 0 Then
                        j = SU
                        Hydr = Involucr(.k, SU).HydrDepth
                    ElseIf SU < 0 Then
                        SU = Nozzles(.k, -SU).InvolucroSU
                        GoTo Rif1
                    End If
                End If
                If Config(0).HTTestVert = 0 Then Hydr = Config(.k).di
                If Hydr <= 0 Then
                    If Config(0).HTTestVert = 0 Then
                        If .k = 3 Then
                            Hydr = Config(1).di
                            If Config(2).di > Hydr Then Hydr = Config(2).di
                            Config(3).di = Hydr
                        End If
                        If Hydr <= 0 Then
                            '        Testo = "E' stata selezionata la prova idraulica in orizzontale,|"
                            'Testo = Testo + "ma non è stato definito il diametro dell'apparecchio.|"
                            'Testo = Testo + "Fornire la profondità idrostatica in prova idraulica|"
                            'Testo = Testo + "in millimetri"
                            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.inizio.ConvertiCr(). Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                            Testo = Monitor.Motore.Inizio.ConvertiCr(Helpstringa(IDH_ST_HYDRDEPTHH))
                            Hydr = GlobalRoutines.ValVir(InputBox(Testo, "AsmeVip", "      "))
                            Config(.k).di = Hydr
                        End If
                    Else
                        '        Testo = "E' stata selezionata la prova idraulica in verticale,|"
                        'Testo = Testo + "ma non è stata definita la profondità idrostatica.|"
                        'Testo = Testo + "della membratura &.|"
                        'Testo = Testo + "Fornire il valore in millimetri."
                        GlobalRoutines.FormatS("non|")
                        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.inizio.ConvertiCr(). Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                        Testo = Monitor.Motore.Inizio.ConvertiCr(GlobalRoutines.FormatS(Helpstringa(IDH_ST_HYDRDEPTHV), Involucr(.k, j).Mark))
                        Hydr = GlobalRoutines.ValVir(InputBox(Testo, "AsmeVip", "      "))
                        Involucr(.k, j).HydrDepth = Hydr
                    End If
                End If
                If .MAWPSS > 0 Then
                    .corrMAWPSS = RappPI() * .MAWPSS - GRAV * 0.000001 * Hydr
                    If .corrMAWPSS < pHISS Then pHISS = .corrMAWPSS
                End If
                If .MAWPTS > 0 Then
                    .corrMAWPTS = RappPI() * .MAWPTS - GRAV * 0.000001 * Hydr
                    If .corrMAWPTS < pHITS Then pHITS = .corrMAWPTS
                End If
            End With
        Next vMAWP
        DisplayPI()
        CalcolaPIc = True
    End Function
    Public Sub CostrMDMT(ByRef col As Collection)
        Dim K1, k As Short
        Dim No As Boolean
        K1 = Config(0).NumeroLati
        If K1 > 2 Then K1 = 2
        No = True
        For k = 1 To K1
            No = No And Config(k).NMWDT = 0
        Next
        If No Then Exit Sub
        col = New Collection
    End Sub
    Public Sub Distruggi(ByRef col As Collection)
        Dim k As Short
        If col Is Nothing Then Exit Sub
        Do While col.Count() > 0
            col.Remove(1)
        Loop
        'UPGRADE_NOTE: È possibile che l'oggetto col non venga eliminato finché non venga raccolto nel Garbage Collector. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1029"'
        col = Nothing
        For k = 1 To 3
            RappMax(k) = 0
        Next
    End Sub

    Public Function CercavMAWP(ByRef k As Short, ByRef i As Short, ByRef Inv As Boolean, Optional ByRef Bolt As Boolean = False, Optional ByRef Flangia As Boolean = False) As clsValoriMAWP
        Dim c As clsValoriMAWP
        CercavMAWP = Nothing
        For Each c In colMAWP
            If c.k = k And c.i = i And c.Inv = Inv And c.Flangia = Flangia Then
                'UPGRADE_NOTE: IsMissing() è stata cambiata in IsNothing(). Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1021"'
                If Not IsNothing(Bolt) Then
                    If c.Bolt = Bolt Then
                        CercavMAWP = c
                        Exit Function
                    End If
                Else
                    CercavMAWP = c
                    Exit Function
                End If
            End If
        Next c
    End Function

    Public Sub DisplayPI()
        Dim Testo, uu As String
        If UnLato Then
            If System.Math.Abs(Config(1).pxTest - pHISS) / pHISS > 0.01 Then
                Testo = Helpstringa(IDH_ST_PI1a) & vbCrLf '"I valori delle pressioni di prova idraulica precedentemente registrati sono:|"
                Testo = Testo & GlobalRoutines.FormatS(Helpstringa(IDH_ST_PI2a), Config(1).pxTest * psi, Config(1).pxTest) & vbCrLf '"#######.## [psi] lato mantello, e #######.## [psi] lato tubi.|"
                Testo = Testo & Helpstringa(IDH_ST_PI3a) & vbCrLf '"I valori attualmente calcolati sono:|"
                Testo = Testo & GlobalRoutines.FormatS(Helpstringa(IDH_ST_PI2a), pHISS * psi, pHISS) & vbCrLf '"#######.## [psi] lato mantello, e #######.## [psi] lato tubi.|"
                uu = "ATTENZIONE|" & Testo
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.inizio.ConvertiCr(). Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                Testo = Testo + Monitor.Motore.Inizio.ConvertiCr(Helpstringa(IDH_ST_PI4a)) '"I valori precedenti vengono scartati: è opportuno verificare|nuovamente i giunti flangiati."
                If ContinuoAuto Then
                    nIndent = 6
                    PrintlstRes(uu)
                    nIndent = 0
                Else
                    If MessageBox.Show(Testo, "AsmeVip - Calcolo della pressione di P.I.", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) = DialogResult.OK Then
                        Config(1).pxTest = pHISS
                    End If
                End If
            End If
        Else
            If System.Math.Abs(Config(1).pxTest - pHISS) / pHISS > 0.01 Or System.Math.Abs(Config(2).pxTest - pHITS) / pHITS > 0.01 Then
                Testo = Helpstringa(IDH_ST_PI1) & vbCrLf '"I valori delle pressioni di prova idraulica precedentemente registrati sono:|"
                Testo = Testo & GlobalRoutines.FormatS(Helpstringa(IDH_ST_PI2), Config(1).pxTest, Config(2).pxTest) & vbCrLf  '"#######.## [psi] lato mantello, e #######.## [psi] lato tubi.|"
                Testo = Testo & Helpstringa(IDH_ST_PI3) & vbCrLf '"I valori attualmente calcolati sono:|"
                Testo = Testo & GlobalRoutines.FormatS(Helpstringa(IDH_ST_PI2), pHISS, pHITS) & vbCrLf '"#######.## [psi] lato mantello, e #######.## [psi] lato tubi.|"
                uu = "ATTENZIONE|" & Testo
                Testo = Testo + Monitor.Motore.Inizio.ConvertiCr(Helpstringa(IDH_ST_PI4)) '"I valori precedenti vengono scartati: è opportuno verificare|nuovamente i giunti flangiati."
                If ContinuoAuto Then
                    nIndent = 6
                    PrintlstRes(uu)
                    nIndent = 0
                Else
                    If MessageBox.Show(Testo, "AsmeVip - Calcolo della pressione di P.I.", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) = DialogResult.OK Then
                        Config(1).pxTest = pHISS
                        Config(2).pxTest = pHITS
                    End If
                End If
            End If
        End If
    End Sub

    Public Sub TransferMAWP(ByRef V As clsValoriMAWP)
        Dim vv As clsValoriMAWP
        For Each vv In colMAWP
            If vv.Inv = V.Inv And vv.i = V.i And vv.k = V.k Then
                If Not vv Is V Then
                    vv.MAWPSS = V.MAWPSS
                    vv.MAWPTS = V.MAWPTS
                End If
            End If
        Next vv
    End Sub
    Public Function Visualizza() As Boolean
        Dim Testo, LogoFile As String
        Dim BookM, Comm, Figur As String
        Dim i As Short
        Dim FigurName, indirFile As String
        Visualizza = True
        If clsInizio.LavoriSciolti Then
            Comm = clsInizio.CommPulita(icome)
        Else
            Comm = job.Comm.Arch
        End If
        If Monitor.Motore.Problem.FileStream Is Nothing Then
            Testo = " Bisogna prima (ri)eseguire il calcolo |"
            MessageBox.Show(inizio.ConvertiCr(Testo), "Compilazione tabelle", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Visualizza = False
            Exit Function
        End If
        Monitor.Motore.Problem.FineRapp()
        capitoli = New Collection
        InterrompiMAWP = False
        Monitor.Motore.ProgrInizio("Attendere la compilazione del rapporto", "AsmeVip")
        Documento = Nothing
        mioApert.wordPanel.Enabled = OptWordIn
        clsInizio.SuperStampa(FileSt, Documento, True, mioApert.wordPanel)
        If Documento Is Nothing Then Monitor.Motore.ProgrAmmazza() : Return False
        If Not mioApert Is Nothing Then mioApert.Enabled = False
        Try
            Monitor.Motore.Avanzamento = 25
            If InterrompiMAWP Then GoTo ExitSub
            If Not mioApert Is Nothing Then
                If mioApert.Check1.CheckState = 1 Then
                    LogoFile = clsInizio.Archdir & gstrSEP_DIR & clsInizio.ReadIniFile("", "Azienda", "Logo")
                    indirFile = clsInizio.Archdir & gstrSEP_DIR & clsInizio.ReadIniFile("", "Azienda", "Indirizzo")
                    If Len(indirFile) > 0 Then
                        If Not IO.File.Exists(indirFile) Then indirFile = ""
                    End If
                    If Len(LogoFile) > 0 Then
                        If IO.File.Exists(LogoFile) Then
                            If Not Documento.Shapes7(LogoFile, indirFile) Then GoTo ExitSub
                        End If
                    End If
                    With Documento
                        If .SubstitBookM("OrdineCliente", "?") > 0 Then 'Config(0).Item
                            GoTo ExitSub
                        End If
                        .SubstitBookM("NomeDitta", clsInizio.Firma)
                        .SubstitBookM("Cliente", "??")
                        .SubstitBookM("Progetto", "???")
                        .SubstitBookM("Codice", "CCC")
                        .SubstitBookM("Impianto", "Imp")
                        .SubstitBookM("Apparecchio", "App")
                        .SubstitBookM("Item", Config(0).Item)
                        .SubstitBookM("Titolo", "Code Calculations")
                        .SubstitBookM("NoForn", Comm)
                        .SubstitBookM("NoClie", "567")
                        .SubstitBookM("Scopo", "For approval")
                        clsInizio.Immatricolazione(Documento, Comm, "SC001")
                        If OptUG22 Then
                            '                    .VaiInizio("OtherLoadings", Del:=True)
                            .SubstitBookM("OtherLoadings", "", True)
                            .sOpen(clsInizio.Archdir & "\OtherLoadings", True, 1)
                            .VaiInizio("", 1)
                            .Copia(1)
                            .sClose(, 1)
                            .sPaste()
                        End If
                    End With
                End If
            End If
            Monitor.Motore.Avanzamento = 50
            If InterrompiMAWP Then GoTo ExitSub
            If Not mioApert Is Nothing Then mioApert.Enabled = True
            With Documento.Doc
                If div < 2 Then
                    For i = 1 To .Bookmarks.Count
                        BookM = .Bookmarks.Item(i).Name
                        If Left(BookM, 4) = "Bkmk" Then
                            '             Documento.sShowAll True
                            Documento.VediTestoNascosto()
                            Documento.VaiInizio(BookM, , True)  ' False
                            Figur = Documento.GetTesto
                            Documento.NascondiTestoNascosto()
                            FigurName = Monitor.Motore.Inizio.DiscoTem & Figur
                            frmNoz.DefInstance.TagImages(Figur).Save(FigurName)
                            Documento.sAddPicture(FigurName)
                            Kill(FigurName)
                        ElseIf Left(BookM, 4) = "bkml" Then
                            Documento.VediTestoNascosto()
                            Documento.VaiInizio(BookM, , False)
                            Figur = Documento.GetTesto
                            Documento.NascondiTestoNascosto()
                            FigurName = Monitor.Motore.Inizio.DiscoTem & Figur
                            frmStiff.DefInstance.TagImages(Figur).Save(FigurName)
                            Documento.sAddPicture(FigurName)
                            Kill(FigurName)
                        End If
                        Monitor.Motore.Avanzamento = 50 + i * 50 / .Bookmarks.Count
                        If InterrompiMAWP Then GoTo ExitSub
                    Next
                End If
                If Config(0).VerifPI = 1 Then
                    If Documento.VaiInizio("VerifichePI") = 0 Then
                        Documento.ApplicaStile("Titolo 1")
                    End If
                End If
            End With
        Catch e As Exception
            MessageBox.Show(e.Message + vbCrLf + e.StackTrace)
            Monitor.Motore.ProgrAmmazza() '  Screen.MousePointer = vbDefault
            CloseioutS(mioApert.lstRapp, True)
            If Not mioApert Is Nothing Then mioApert.Enabled = True
            Exit Function
        End Try
ExitSub:
        Monitor.Motore.ProgrAmmazza() 'Screen.MousePointer = vbDefault
        Documento.sShowAll(False)
    End Function
    Public Sub ConvertiCop()
        Dim O As wn_flan
        Dim R As Single
        Dim j, k As Short
        For k = 1 To Config(0).NumeroLati
            For j = 1 To NumBocch(k)
                If Involucr(k, Nozzles(k, j).InvolucroSU).Tipo = 5 Then
                    O = objMemb(Involucr(k, Nozzles(k, j).InvolucroSU).IndObject)
                    If O.Mem.LOOSE = 4 Then
                        Select Case SistCoorCop
                            Case 0 ' da cartesiano a polare
                                R = System.Math.Sqrt(Nozzles(k, j).DTL ^ 2 + Nozzles(k, j).DCL ^ 2)
                                Nozzles(k, j).Anomal = GlobalRoutines.arco(Nozzles(k, j).DCL / R, Nozzles(k, j).DTL / R) * 180 / pi
                                Nozzles(k, j).DCL = R
                            Case 1 'da polare a cartesiano
                                R = Nozzles(k, j).DTL
                                Nozzles(k, j).DCL = R * System.Math.Sin(Nozzles(k, j).Anomal * pi / 180)
                                Nozzles(k, j).DTL = R * System.Math.Cos(Nozzles(k, j).Anomal * pi / 180)
                                Nozzles(k, j).Anomal = 0
                        End Select
                    End If
                End If
            Next j
        Next k
    End Sub
    Public Sub AvvertiDT()
        Dim Testo As String
        If Config(0).DiverseTemp = 0 Then
            Testo = Helpstringa(IDH_XH_NONUNIFORM)
            GlobalRoutines.FormatS("non|")
            Testo = Monitor.Motore.Inizio.ConvertiCr(GlobalRoutines.FormatS(Testo, Trim(Involucr(kLato, jInvolucr).Mark)))
            MostraAiuto(IDH_XH_NONUNIFORM, CShort(RoutBase1.ChiaviMess.MessInformation & RoutBase1.ChiaviMess.MessHelpButton), Testo, "AsmeVip")
        End If
    End Sub
    Public Sub AD550f(ByRef nn As Short)
        Dim t, AlfR, AlfV As Single
        Dim Testo As String
        t = TempDes()
        AlfR = Matdim(Nozzles(kLato, nn).indice).AlfaTer(t)
        If AlfR = 0 Then
            Testo = Trim(Matdim(Nozzles(kLato, nn).indice).MatStr)
            If Testo = "" Then Testo = "del bocchello " & Trim(Nozzles(kLato, nn).Mark)
            MessageBox.Show("Il coefficiente di dilatazione termica del materiale " & Testo & " non è definito.")
        End If
        AlfV = Matdim(Involucr(kLato, System.Math.Abs(jInvolucr)).indice(1 - 1)).AlfaTer(t)
        If AlfV = 0 Then
            Testo = Trim(Matdim(Involucr(kLato, System.Math.Abs(jInvolucr)).indice(1 - 1)).MatStr)
            If Testo = "" Then Testo = "del componente " & Trim(Involucr(kLato, System.Math.Abs(jInvolucr)).Mark)
            MessageBox.Show("Il coefficiente di dilatazione termica del materiale " & Testo & " non è definito.")
        End If
        'dt = (t - 70) / 1.8
        Nozzles(kLato, nn).alfaNoz = AlfR
        Nozzles(kLato, nn).alfaShell = AlfV
        'If Nozzles(kLato, nn).dtAD550f = 0 Then Nozzles(kLato, nn).dtAD550f = dt
    End Sub
    Public Sub AggMetodo()
        Dim oldind As Short
        Config(0).DC = Config(1).DC
        If Config(2).DC < Config(1).DC And Config(0).NumeroLati > 1 Then
            MostraAiuto(IDH_CODICIDIVERSI)
            Config(0).DC = Config(2).DC
        End If
        With mioGen
            oldind = .cmbMetodoPI.SelectedIndex
            .cmbMetodoPI.Items.Clear()
            Select Case Config(0).DC
                Case 0, 1, 2
                    .cmbMetodoPI.Items.Add("UG-99(b)-Standard")
                    .cmbMetodoPI.Items.Add("UG-99(c)-Calculated")
                Case 3, 4, 5
                    .cmbMetodoPI.Items.Add("AT-300-Standard")
                    .cmbMetodoPI.Items.Add("AT-301-Calculated")
                Case 6, 7, 8
                    .cmbMetodoPI.Items.Add("Standard Rule")
                Case 9, 10, 11
                    .cmbMetodoPI.Items.Add("Standard Rule")
            End Select
            .cmbMetodoPI.SelectedIndex = oldind
        End With
    End Sub
    Public Function Uguale(ByVal a As Single, ByVal b As Single) As Boolean
        Dim media, diff As Single
        media = System.Math.Abs((a + b) / 2)
        If media = 0 Then
            Uguale = True
            Exit Function
        End If
        diff = System.Math.Abs(a - b)
        Uguale = diff < clsTrigon.TOLER * media
    End Function
    Public Function Minore(ByVal a As Single, ByVal b As Single) As Boolean
        Return a < b - Math.Abs((a + b) / 2) * clsTrigon.TOLER
    End Function
    Public Function Maggiore(ByVal a As Single, ByVal b As Single) As Boolean
        Return a > b + Math.Abs((a + b) / 2) * clsTrigon.TOLER
    End Function
    Public Sub CheckPI()
        Dim k, K1 As Short
        Dim Strin(2) As String
        Dim i As Short
        Dim Testo As String
        Dim rapp As Single
        If div = 2 Then Exit Sub
        Strin(0) = ""
        Strin(1) = "lato mantello"
        Strin(2) = "lato tubi"
        K1 = Config(0).NumeroLati
        If K1 > 2 Then K1 = 2
        rapp = RappPIx()
        For k = 1 To K1
            If Config(k).pxTest - Config(k).p0x * rapp < -0.00001 * Config(k).pxTest Then
                If Config(0).Verbose Then
                    i = k : If K1 = 1 Then i = 0
                    Testo = "La pressione di prova idraulica " & Strin(i) & " è stata corretta d'ufficio." & vbCrLf
                    Testo = Testo & "Essa era infatti inferiore alla pressione di progetto moltiplicata per " & Format(rapp, "#.##")
                    MessageBox.Show(Testo, "AsmeVip", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Config(k).pxTest = 1.000011 * Config(k).p0x * rapp
                End If
            End If
        Next
    End Sub
    Public Sub Uniforma(ByRef indice As Short)
        Dim i, Dimen As Short
        On Error GoTo ErrH
        Matdim(indice).Editato = False
        Dimen = UBound(Matdim)
        For i = 1 To Dimen
            If i <> indice Then
                If Matdim(i).Indmat = Matdim(indice).Indmat Then Matdim(i).RecupMat()
            End If
        Next
ErrH:
        Exit Sub
    End Sub
    Public Sub SelezionaJob()
        Dim Comm As String = ""
        Dim Contr As String = ""
        Dim oldIcome As String = ""
        Dim ContrFile As String = ""
        Dim propComm As String = ""
        Dim propItem As String = ""
        ' If job Is Nothing Then job = New RoutBase1.clsjob(Monitor.Motore)
        oldIcome = icome
        Contr = IO.Path.GetFileName(icome)
        Contr = IO.Path.GetFileNameWithoutExtension(Contr)
        Comm = clsInizio.CommPulita(Contr)
        If Len(Contr) > 4 Then Contr = Left(Contr, 4)
        job = Monitor.Motore.Sceglijob(Contr, ContrFile)
        If Len(ContrFile) = 0 Then Exit Sub
        If Len(Comm) <> 6 Then
            MessageBox.Show(Comm & ": Nome non standard. Seguiranno spiegazioni")
            If Len(Comm) > 6 Then propComm = Left(Comm, 6)
        Else
            propComm = Comm
        End If
        propItem = Config(0).Item
        If Not job.Selezione(propComm, propItem) Then icome = "" : Exit Sub
        With job.Comm
            If .indice > 0 Then
                If .Ind.Count >= .indice Then
                    icome = Monitor.Motore.Inizio.Workdir & "\" & .Arch & gstrSEP_DIR & .Ind.Item(.indice).Data.File & ".VIP"
                    Config(0).Item = .Ind.Item(.indice).Data.Assieme
                Else
                    icome = ""
                    Config(0).Item = ""
                End If
            Else
                icome = ""
                Config(0).Item = ""
            End If
        End With
        job.Comm.CalcBaric = True
        job.Comm.NumeroLati = Config(0).NumeroLati
        GeneraElencoInvolucri()
        Apparecchio = Libgra.Costruisci(job, False)
        ReTransWND()
        job.Comm.SalvaCom()
        job.Salva()
        FileCopy(oldIcome, icome)
        '-----------------------
        Apparecchio.ScaricaApparecchio()
        Apparecchio.Delete()
    End Sub
    Public Sub GeneraElencoInvolucri()
        Dim Cercanome As clsCercaNome
        Dim i, k As Short
        Dim Ntot As Short
        If ElencoInvolucri Is Nothing Then
            ElencoInvolucri = New Collection
        Else
            SvuotaElencoinvolucri()
        End If
        For k = 1 To Config(0).NumeroLati
            For i = 1 To Config(k).Ninvolucri
                Cercanome = New clsCercaNome
                Cercanome.jInvolucr = i
                Cercanome.kLato = k
                ElencoInvolucri.Add(Cercanome, Involucr(k, i).Mark.Trim)
            Next
            Ntot = NumBocch(k) + NumBocch2(k)
            For i = 1 To Ntot
                Cercanome = New clsCercaNome
                Cercanome.kNozzle = i
                Cercanome.kLato = k
                ElencoInvolucri.Add(Cercanome, Nozzles(k, i).Mark.Trim)
            Next
        Next
    End Sub
    Public Sub SvuotaElencoinvolucri()
        Do While ElencoInvolucri.Count() > 0
            ElencoInvolucri.Remove(1)
        Loop
    End Sub
    Public Sub RetrDisp(ByRef k As Short, ByRef iDisp As Short)
        Dim Tipo As Short
        If jInvolucr > 0 Then Tipo = Involucr(kLato, jInvolucr).Tipo Else Tipo = 0
        Select Case Tipo
            Case 0 'cilindro
                If Nozzles(kLato, k).DCL = 0 And Nozzles(kLato, k).beta = 90 Then
                    iDisp = 1
                ElseIf Nozzles(kLato, k).beta <> 0 Then
                    iDisp = 2
                ElseIf Nozzles(kLato, k).DCL <> 0 Then
                    iDisp = 3
                Else
                    iDisp = 0
                End If
            Case 1 'fondo
                If Nozzles(kLato, k).DCL = 0 And Nozzles(kLato, k).beta = 0 And Nozzles(kLato, k).DTL = 0 Then
                    iDisp = 1
                ElseIf Nozzles(kLato, k).DCL = 0 And Nozzles(kLato, k).DTL = 0 Then
                    iDisp = 2
                ElseIf Nozzles(kLato, k).DTL = 0 Then
                    iDisp = 4
                ElseIf Nozzles(kLato, k).DCL = 0 Then
                    iDisp = 3
                Else
                    iDisp = 0
                End If
            Case 2 'su cono
                If Nozzles(kLato, k).beta = 90 Then
                    iDisp = 1
                ElseIf Nozzles(kLato, k).DCL > 0 Then
                    iDisp = 2
                Else
                    iDisp = 0
                End If
            Case 3 ' su conoide
                If Nozzles(kLato, k).DTL = 180 And Nozzles(kLato, k).beta = 90 Then
                    iDisp = 1
                ElseIf Nozzles(kLato, k).DTL = 180 Then
                    iDisp = 2
                ElseIf Nozzles(kLato, k).DTL = 0 And Nozzles(kLato, k).beta = 90 Then
                    iDisp = 3
                ElseIf Nozzles(kLato, k).DTL = 90 And Nozzles(kLato, k).beta = 90 Then
                    iDisp = 4
                ElseIf Nozzles(kLato, k).DTL = 90 Then
                    iDisp = 5
                End If
            Case 5 ' su gr.fuc.
                Select Case CType(objMemb(Involucr(kLato, jInvolucr).IndObject), wn_flan).Mem.LOOSE
                    Case 4 'coperchio
                        Select Case SistCoorCop
                            Case 0 'polare
                                If Nozzles(kLato, k).DTL = 0 Then
                                    iDisp = 1
                                Else
                                    iDisp = 2
                                End If
                            Case 1 'cartesiano
                                If Nozzles(kLato, k).DCL = 0 And Nozzles(kLato, k).DTL = 0 Then
                                    iDisp = 1
                                Else
                                    iDisp = 2
                                End If
                        End Select
                    Case 5, 6 'flat head with large opening
                        iDisp = 1 'decentrato
                        If Nozzles(kLato, k).DCL = -1 Then iDisp = 2
                        If Nozzles(kLato, k).DCL = -2 Then iDisp = 3
                    Case 7
                        MessageBox.Show("da programmare in RetrDisp")
                    Case Else
                        If Nozzles(kLato, k).DCL = 0 And Nozzles(kLato, k).beta = 0 And Nozzles(kLato, k).DTL = 0 Then
                            iDisp = 1
                        ElseIf Nozzles(kLato, k).DCL = 0 And Nozzles(kLato, k).DTL = 0 Then
                            iDisp = 2
                        ElseIf Nozzles(kLato, k).DTL = 0 Then
                            iDisp = 4
                        ElseIf Nozzles(kLato, k).DCL = 0 Then
                            iDisp = 3
                        Else
                            iDisp = 0
                        End If
                End Select
        End Select
    End Sub
    Public Sub TrasferFlanCh(ByRef O As wn_PT, ByRef wn As wn_flan, ByRef j As Short, ByRef Indexx As Short)
        With O
            If Not wn Is Nothing And j > 0 Then
                If Not wn.Mem.LOOSE = 5 Then
                    .FlChanDati(1) = wn.Mp(3) 'A, diametro esterno
                    Select Case wn.Mem.LOOSE
                        Case -1, 2
                            If wn.Mp(10) > 0 Then
                                .FlChanDati(2) = wn.Mp(10) - 2 * wn.Mp(8)
                            Else
                                .FlChanDati(2) = wn.Mp(6) 'B, diametro interno
                            End If
                            .FlChanDati(3) = wn.Mp(8) 'g1
                        Case Else
                            .FlChanDati(2) = wn.Mp(6)
                            .FlChanDati(3) = wn.Mp(8)
                    End Select
                    .FlChanDati(4) = wn.Mp(7)
                    .FlChanDati(5) = wn.Mp(5)
                    .FlChanDati(6) = wn.Mp(26)
                    .FlChanDati(7) = wn.Mem.Gasket ' Tipo gua
                    .FlChanDati(8) = wn.Mem.GasMat 'mat gua
                    .FlChanDati(9) = wn.Mp(30)
                    .FlChanDati(10) = wn.Mp(28)
                    .FlChanDati(11) = wn.Mp(30)
                    .FlChanDati(12) = wn.Mp(168)
                    .FlChanDati(13) = wn.Mp(167)
                    .FlChanDati(14) = wn.Mp(169)
                    .FlChanDati(15) = wn.Mp(40) 'Wm1
                    .FlChanDati(16) = wn.Mp(41) 'Wm2
                    .FlChanDati(17) = wn.Mp(193) 'Wm1 HT
                    .FlChanDati(18) = wn.Mp(194) 'Wm2 HT
                    .FlChanDati(19) = wn.Mp(37) 'Gef
                    .FlChanDati(20) = wn.Mp(163) 'phi
                    .FlChanDati(21) = wn.Mp(42) 'W
                    .wn(1) = wn.Mp(29)
                    TrasferBull(O, wn, Indexx)
                End If
            Else
                .FlChanDati(15) = 0 ' wn.Mp(40) 'Wm1
                .FlChanDati(16) = 0 ' wn.Mp(41) 'Wm2
                .FlChanDati(17) = 0 ' wn.Mp(193) 'Wm1 HT
                .FlChanDati(18) = 0 ' wn.Mp(194) 'Wm2 HT
            End If
        End With
    End Sub
    Public Sub TrasferFlanSh(ByRef O As wn_PT, ByRef wn As wn_flan, ByRef j As Short, ByRef Indexx As Short)
        With O
            If Not wn Is Nothing And j > 0 Then
                If Not wn.Mem.LOOSE = 5 Then
                    .FlShelDati(1) = wn.Mp(3) 'DextFla
                    Select Case wn.Mem.LOOSE
                        Case -1, 2
                            If wn.Mp(10) > 0 Then
                                .FlShelDati(2) = wn.Mp(10) - 2 * wn.Mp(8)
                            Else
                                .FlShelDati(2) = wn.Mp(6) 'DintFla
                            End If
                            .FlShelDati(3) = wn.Mp(8) 'g1
                        Case Else
                            .FlShelDati(2) = wn.Mp(6)
                            .FlShelDati(3) = wn.Mp(8)
                    End Select
                    .FlShelDati(4) = wn.Mp(7) 'g0
                    .FlShelDati(5) = wn.Mp(5) 'Dmed gua
                    .FlShelDati(6) = wn.Mp(26) 'N
                    .FlShelDati(7) = wn.Mem.Gasket 'Tipo gua
                    .FlShelDati(8) = wn.Mem.GasMat 'mat gua
                    .FlShelDati(9) = wn.Mp(30) 'm
                    .FlShelDati(10) = wn.Mp(28) 'Y
                    .FlShelDati(11) = wn.Mp(30) 'm trav
                    .FlShelDati(12) = wn.Mp(168) 'Y trav
                    .FlShelDati(13) = wn.Mp(167) 'l trav
                    .FlShelDati(14) = wn.Mp(169) 'b trav
                    .FlShelDati(15) = wn.Mp(40) 'Wm1
                    .FlShelDati(16) = wn.Mp(41) 'W o Wm2?
                    .FlShelDati(17) = wn.Mp(193) 'Wm1 HT
                    .FlShelDati(18) = wn.Mp(194) 'Wm2 HT
                    .FlShelDati(19) = wn.Mp(37) 'Gef
                    .FlShelDati(20) = wn.Mp(163) 'phi
                    .FlShelDati(21) = wn.Mp(42) 'W
                    .wn(2) = wn.Mp(29)
                    TrasferBull(O, wn, Indexx)
                End If
            Else
                .FlShelDati(15) = 0 ' wn.Mp(40) 'Wm1
                .FlShelDati(16) = 0 ' wn.Mp(41) 'Wm2
                .FlShelDati(17) = 0 ' wn.Mp(193) 'Wm1 HT
                .FlShelDati(18) = 0 ' wn.Mp(194) 'Wm2 HT
            End If
        End With
    End Sub
    Public Sub TrasferBull(ByRef O As wn_PT, ByRef wn As wn_flan, ByRef Indexx As Short)
        With O
            If wn.Mp(13) > 0 Then
                .DiNBull(Indexx) = wn.Mem.TIR
                .NumBolt(Indexx) = wn.Mp(13)
                .BoltCiD(Indexx) = wn.Mp(4)
                .AreBolt(Indexx) = wn.Mp(46) / wn.Mp(13)
                .BSpcMin(Indexx) = wn.Mp(20)
                .BRadMin(Indexx) = wn.Mp(16)
                '      .NumColl = GlobaLroutines.ValVir(TextCil(Index))
                .AllBRoo(Indexx) = wn.Mp(24)
                .AllBOpe(Indexx) = wn.Mp(25) 'amm bull @temp
            End If
        End With
    End Sub
    Public Sub Caricajob()
        Dim Comm, Contr, oldIcome, ContrFile As String
        Dim propItem As String = ""
        Dim propComm As String = ""
        Dim Testo As String = ""
        If Not job Is Nothing Then Exit Sub
        job = New RoutBase1.clsjob(Monitor.Motore)
        oldIcome = icome
        Contr = IO.Path.GetFileName(icome)
        Contr = IO.Path.GetFileNameWithoutExtension(Contr)
        Comm = Contr
        If Len(Contr) > 4 Then Contr = Left(Contr, 4)
        job.Contratto = Contr
        ContrFile = Monitor.Motore.Inizio.Workdir & "\" & Contr & ".JOB"
        If Not IO.File.Exists(ContrFile) = 0 Then
            Testo = "Non è stato creato il file " & ContrFile
            MessageBox.Show(Testo)
            Exit Sub
        Else
            job = Monitor.Motore.Retrievejob(Contr, ContrFile)
        End If
        If Len(Comm) <> 6 Then
            '   messagebox.show Comm + "è un nome non standard. Seguiranno spiegazioni"
            If Len(Comm) > 6 Then propComm = Left(Comm, 6)
        Else
            propComm = Comm
        End If
        propItem = Config(0).Item
        If Not job.Selezione(propComm, propItem, False) Then icome = "" : Exit Sub
        With job.Comm
            If .indice > 0 Then
                If .Ind.Count >= .indice Then
                    icome = Monitor.Motore.Inizio.Workdir & "\" & .Arch & gstrSEP_DIR & .Ind.Item(.indice).Data.File & ".VIP"
                    Config(0).Item = .Ind(.indice).Data.Assieme
                Else
                    icome = ""
                    Config(0).Item = ""
                End If
            Else
                icome = ""
                Config(0).Item = ""
            End If
        End With
    End Sub
    Public Sub StiffRings()
        ' Dim Dom(2) As String, Risp(2) As String
        ' Dim Arch(2) As Integer, dAiu(2) As String
        ' Dom(1) = "Altezza degli anelli [mm]"
        ' Dom(2) = "Spessore degli anelli [mm]"
        ' With Involucr(kLato, jInvolucr)
        ' Risp(1) = mystr(.Dati1, 4, 2, False)
        ' Risp(2) = mystr(.Dati2, 4, 2, False)
        ' If Not Monitor.Motore.InputDati(2, "Anelli di rinforzo", Dom(), Risp(), "", Arch(), dAiu(), , xPos, yPos) Then Exit Sub
        ' .Dati1 = GlobaLroutines.ValVir(Risp(1))
        ' .Dati2 = GlobaLroutines.ValVir(Risp(2))
        ' End With
        frmStiff.DefInstance.ShowDialog()
        frmStiff.DefInstance.Dispose()
    End Sub
    Public Sub SetDiv(ByRef k As Short)
        Select Case Config(k).DC
            Case 0, 1, 2, 9, 10, 11 : div = 0
            Case 3, 4, 5 : div = 1
            Case 6, 7, 8 : div = 2
            Case Else : div = -1
        End Select
    End Sub

    Public Function OpenFile(ByRef NomFile As String, ByRef ifl As Short) As Boolean
        Dim Testo As String
        Try
            FileOpen(ifl, NomFile, OpenMode.Input, , OpenShare.Shared)
            Return True
        Catch e As Exception
            Testo = "Si è prodotto l'errore: " & e.Message & vbCrLf
            Testo = Testo & "all'apertura del file " & NomFile
            MessageBox.Show(Testo, "AsmeVip", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Function
End Module
Public Class NoLinkFFException
    Inherits System.Exception

    Sub New()
        MyBase.New()
    End Sub

    Sub New(ByVal message As String)
        MyBase.New(message) ' pass control to the parent constructor of the same signature
    End Sub

    Sub New(ByVal message As String, ByVal inner As Exception)
        MyBase.New(message, inner) ' pass control to the parent constructor of the same signature
    End Sub
End Class
