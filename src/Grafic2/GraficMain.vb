Option Strict Off
Option Explicit On
Imports System.Data
Imports System.Data.OleDb
Imports System.Math
Imports RoutBase1
Imports System.IO
Imports System.Runtime.Serialization
Imports System.Runtime.Serialization.Formatters.Binary
<Serializable()> Public Class clsSezioni
    Public Nsezioni As Short
    Public Tipo() As Short '1=perp.a X 2=perp. a Y 3 perp. a Z
    Public Quota() As Single 'distanza da Oxyz
    Public Spost() As RoutBase1.clsVec2
    Public Verso() As Short '- o +
    Public Sub New()
        Dim i As Short
        ReDim Tipo(5)
        ReDim Quota(5)
        ReDim Spost(5)
        ReDim Verso(5)
        For i = 0 To 4
            Spost(i) = New RoutBase1.clsVec2
        Next
        Tipo(1) = 1
        Verso(1) = -1
        Nsezioni = 1
    End Sub
    Public Function Clone() As clsSezioni
        Dim S As New clsSezioni
        Dim i As Short
        For i = 0 To 5
            S.Tipo(i) = Tipo(i)
            S.Quota(i) = Quota(i)
            S.Spost(i) = Spost(i)
            S.Verso(i) = Verso(i)
            If i < 5 Then Spost(i).copia(S.Spost(i))
        Next
        Return S
    End Function
End Class
Module GraficMain
    Public FunzLibgra As LibGra
    Public FormFlangia As frmFlange
    Public ButtonClick As Boolean
    Public Const SezPref As String = "Preferenze PPSM"
    Public Const INC As Single = 25.4
    Public Const TOLER As Single = 0.0001
    Public Const EXP9 As Single = 0.000000001
	Public IUN As Short
	Public IUNS As Short
	Public IUNA As Short
	Public IUNG As Short
	Public IUNQ As Short
	Public IUNL As Short
    Public EditingSezioni As Boolean
    Public SecondaVolta As Boolean
    Public LungPip As Short
	Public Distinta As Boolean
	Public AddMembrat As Short
	Public jRec As Short 'Record da revisionare
	Public ForzaPrezzo As Boolean
	Public Nojobs As Short
    'Public Record As clsGenMem 'RecAPRn
	Public ProtoTyp As String
	Public timer0 As Single
	'-------------------------------------------------
    Public Tipi As DataSet1.TipiDataTable ' DataTable
    Public Diametri As DataSet1.DiametriDataTable ' DataTable
    Public Ratings As DataSet1.RatingsDataTable
    Public Facings As DataSet1.FacingsDataTable 'DataTable
    Public dvFacings, dvRatings, dvDiametri As DataView
    Public CatalogoR1 As DataView
    Public CatalogoR2 As DataView
    Public CatalogoR3 As DataView
    Public CatalogoR4 As DataView
    Public CatalogoR5 As DataView
    Public CatalogoR As DataView
    Public FacValoriR As DataView
    Public FacValori As DataTable
    Public rmHelpStrings As Resources.ResourceManager
    Public Const Conn As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source="
    Public Const ConnFine As String = ";Persist Security Info=False"
    Public RadiceHelp As String
    '------------------------------------------------
    Public Enum IDHG
        IDH_ERR_CONOGRANDE = 990
        IDH_ERR_NOFASCIO = 1000
        IDH_ERR_NOTEMALETTER = 1010
        IDH_ERR_NOFILETRAC = 1020
        IDH_ERR_UNSOLOPASSO = 1030
        IDH_ERR_INCONGRUENZA = 1040
        IDH_ERR_NOPT = 1050
        IDH_ERR_NO2PT = 1055
        IDH_ERR_NOCASSA = 1060
        IDH_ERR_NOAUTOCAD = 1061
        IDH_ERR_NOAUTOVER = 1062
        IDH_ERR_NODISEGNO = 1063
        IDH_ERR_NOITEMSELECTED = 1064
        IDH_ERR_NOLAMSPIC = 1070
        IDH_ERR_NOLAMQUAD = 1071
        IDH_ERR_NOPROTO = 1072
        IDH_ERR_2PROTO = 1073
        IDH_STR_4PASSI1 = 2000
        IDH_STR_4PASSI2 = 2001
        IDH_SPIC_SCELTAOPT = 2002
        IDH_PROTO_ESISTEGIA = 3000
        IDH_DB_VERBOSO = 3050
        IDH_DB_APRESISTEGIA = 3051
        IDH_DS_NONCONGRUO = 3100
        IDH_dati = 3500
        IDH_dati_frampos = 3510
        IDH_dati_frampos_cmbSuChi = 3520
        IDH_dati_frampos_cmbFinoA = 3530
        IDH_dati_frampos_cmbPreDef = 3540
        IDH_dati_frampos_cmbLato = 3550
        IDH_dati_frampos_cmbCodPos = 3560
    end enum
    Public DaTos As traccia.clsTracciatura.typDaTos
	Public FileAPR As String
	Public NonDisegnare As Boolean
	Public Squadratura As RoutBase1.clsPunti
	Public FileGre As String
	Public FacSav As Short
    Public Inizio As RoutBase1.clsInizio
    Public Motore As RoutBase1.clsMotore
    Public job As RoutBase1.clsjob
    Public Monitor As clsMonitor
    Public Membro As Membratura
    Public frmMadre As Object
	Public DisAcad As Boolean
	Public QuadrInd As Short
	Public Salva() As Short
    Public sezvec, sezioni, sezsalva As clsSezioni
    Public ifl As Short
    Public idMax, iRatMax As Short
    Public InsertMode As Boolean
    Public FormDati As frmDati
    Public globFlangia As Flangia
    Public Editing, Duplicando As Boolean
    Public Caricamento As Boolean
    Public Funzioni As Grafica.LibGra
    Public FileProv, File As String ', DirScr As String
    Public Apparecchio, ApparProv As clsApparecchio
    Public DataSheet As RoutBase1.clsDatiDes
    Public P0, p1 As RoutBase1.clsPunti
    Public Lamiere() As RoutBase1.modTipi.IndiceL
    Public Lamiera_Renamed, Lamiera1 As RoutBase1.modTipi.IndiceL ', Spp AS LamSpicchi
    Public IndInMezzo() As spot
    Public iflLamQuadr As DataTable
    Public cmdLamQuadr As OleDbDataAdapter
    Public CBLAmQuadr As OleDbCommandBuilder
    '------------------------------------
    Public AggiornamentoAutomatico As Boolean
    Public Verboso As Boolean
    '--------------------------------
    Public Declare Function BitBlt Lib "gdi32" (ByVal hDestDC As Integer, ByVal x As Integer, ByVal y As Integer, ByVal nWidth As Integer, ByVal nHeight As Integer, ByVal hSrcDC As Integer, ByVal xSrc As Integer, ByVal ySrc As Integer, ByVal dwRop As Integer) As Integer
    Public Const SRCAND As Integer = &H8800C6
    Public Const SRCCOPY As Integer = &HCC0020
    Public Const SRCERASE As Integer = &H440328
    Public Const SRCINVERT As Integer = &H660046
    Public Const SRCPAINT As Integer = &HEE0086
    Public Const DSTINVERT As Integer = &H550009
    Public Const NOTSRCCOPY As Integer = &H330008
    Public Const NOTSRCERASE As Integer = &H1100A6
    Public DbaseFatto As Boolean
    Friend GlobalRoutines As New RoutBase1.clsTrigon
    Public Nfori(2) As Short
    Public RibCL() As Single
    Private xSmax, xSmin, ySmin, ySmax As Single
    Private Direzione As New RoutBase1.clsVec3
    Private DirR As New RoutBase1.clsVec2
    Private j, j1 As Short
    Private prod, Verso, det As Single
    Private i, InMezzo As Short
    Private Vista As Short
    Private y, x, Alfaa As Single
    Private z1, SpostX, SpostY, z2 As Single
    Private RiG, Ri, Re, ReG As Single
    Private XLung, xb, xa, xSpess, Dum As Single
    Private RintSup, xa0, RintInf As Single
    Private ya, yb As Single
    Private posspa As Posizione
    Private Spots As spot
    Private Spessore, Diametro, Lunghezza As Single
    Private Cil As Cilindro
    Private Npunti, Nvol As Short
    Private PPP, Centri As RoutBase1.clsPunti3
    'Private Recmod As RecAPRm
    Private PZ1, dist, PZ2 As Single
    Private PP As New RoutBase1.clsVec3
    Private Cen As New RoutBase1.clsVec3
    Private Dir1 As New RoutBase1.clsVec2
    Private Dir2 As New RoutBase1.clsVec2
    Private Dir3 As New RoutBase1.clsVec3
    Private Cosy, Cosx, Cosz As RoutBase1.clsVec3
    Private Punto As RoutBase1.clsVec2
    Private i1, k As Short
    Private ii, K1, ii1 As Short
    Private delx, dely As Single
    Private ang, ang1, ang2, delz As Single
    Private Ang1p, Alfa As Single
    Private d, b, A, c, E As Single
    Private f, g As Single
    Private Swapped As Boolean
    Private e1, c1, D1, f1 As Single
    Private delta As Single
    Private Sol As New RoutBase1.clsVec3
    Private PuntoSect As New RoutBase1.clsVec3
    Private cosP1 As New RoutBase1.clsVec3
    Private cosP2 As New RoutBase1.clsVec3
    Private Direz1 As New RoutBase1.clsVec2
    Private Direz As New RoutBase1.clsVec2
    Private PuntiS As New RoutBase1.clsPunti
    Private PuntiD As New RoutBase1.clsPunti
    Private Rett As New RoutBase1.clsRectang
    Private Zsup, Alfax, Zinf, Z As Single
    Private Ainf, Asup As Single
    Private TipoDiaf As Short
    Private PercTaglio As Single
    Private Ogg4 As Diaframma
    Private Ogg As Membratura
    Private VerticlTaglio As Boolean
    Private Aotl1, SpessTub, DTub, Aotl, Aotlm As Single
    Private Alung As Single
    Private NpassShell As Short
    Private yfmax, yfmin, RagG As Single
    Private pdiaf, Ddiaf, pdiaf1 As Single
    Private n1 As Short
    Private n2, n As Short
    Private t As Single
    Private Fine, Iniz, FineS As Single
    Private VerticalTaglio As Boolean
    Private InPiastra As Single
    Private PrimoTipo As Short
    Private SpessPiastra As Single
    Private Fascio As Fascio
    Private icome, trk As String
    Private QQQ As New RoutBase1.clsPunti3
    Private Npuntj As Short
    Private Res As Boolean
    Private i2, i3, i4 As Short
    Private Linea1 As RoutBase1.clsLinea2
    Private Linea2 As RoutBase1.clsLinea2
    Private Inters As RoutBase1.clsVec2
    Private SP As New Spicchio4
    Private Orig As New RoutBase1.clsVec2
    Private SpOrig As New RoutBase1.clsVec2
    Private di, de As Single
    Private Dmant As Single
    Private R, Hfon, AP As Single
    Private dAlfa, cosa As Single
    Private AlfaP, AlfaG As Single
    Private Punti As New RoutBase1.clsPunti
    Private Linea As New RoutBase1.clsLinea2
    Private Punti0, Punti1 As RoutBase1.clsPunti
    Private Direz2 As New RoutBase1.clsVec2
    Private Vect As New RoutBase1.clsVec3
    Private DiamB, DbulB As Single
    Private DBuco(5) As Single
    Private OrigiB, DirB As RoutBase1.clsPunti
    Private Look As New clsLook
    Private XvecP As Short
    Private racc As Single
    Private BCsave As Single
    Private jB As Short
    Private Dtub1, Dtub0, HH As Single
    Private iDir As Short
    Private OTL, DELTAY As Single
    Private Fl1, Fl2 As Flangione
    Private Rett1 As New RoutBase1.clsRectang
    Private Rett2 As New RoutBase1.clsRectang
    Private Point3 As New RoutBase1.clsPunti3
    Private peso, Raggio, Quota, anom, DFor As Single
    Private NB As Short
    Private BCircle, Lung As Single
    Private H, Proiez, HS As Single
    Private W As Single
    Private imin0 As Membratura
    Private area0 As Single
    Private imin As Membratura
    Private Area As Single
    Private Interno As Short
    Private raggiop As Single
    Private aelliss, CosAlfa, CosBeta, belliss As Single
    Private Spess As Single
    Private iProcedi As Boolean
    Private Testo As String
    Private Modulo As Single
    Private O As Membratura
    Private DBul As Single
    Private RecTubi, RecPiastra As clsGenMem
    Private NBull As Short
    Private dx, dy As Single
    Private Np As Short
    Private phi3, phi1, phi2, Chiave As Single
    Private Diam, DS As Single
    Private DADI, xFilv As Short
    Private quosopra(10) As Single
    Private quosotto(10) As Single
    Private DBucosopra(10) As Single
    Private DBucosotto(10) As Single
    Private jsopra, jsotto As Short
    Private R2, R1, Dint1, Dint2 As Single
    Private quotlinea As Single
    Private Al, An As Single
    Private Direz11 As New RoutBase1.clsVec2
    Private Direz21 As New RoutBase1.clsVec2
    Private iOff As Short, Alfa1 As Single, Displ As Single
    Private SGhub, Hhub, Thub, Dint As Single
    Private SGhub1, Hhub1, Thub1, ADG1 As Single
    Private Rec2v As clsGenMem
    Private Alpha As Single
    Private Origine As New RoutBase1.clsVec2
    Private Centr As New RoutBase1.clsVec2
    Private Logic As Boolean
    Private Alfa2 As Single
    Private DesSin(,) As Short
    Private jj As Short
    Private Raggio1 As Single
    Private Ginocchio As Single
    Private ik, kRP, kRG, kkk As Short
    Private T1sav, zerox, zeroy, GinSav As Single
    Private iAng As Short
    Private Tcal As Single
    Private kRapporto As Single
    Private iSwSez As Boolean
    Private OrigB, Punti2 As RoutBase1.clsPunti
    Private Punti12 As RoutBase1.clsPunti
    Private n1Int(), n2Int() As Short
    Private Denom As Single
    Private segno As Short
    Private Riga As String
    Private iasc As Short
    Private TanAlfa As Single
    Private disass As Single
    Private Centr1 As New RoutBase1.clsVec2
    Private AlfaInt As Short
    Private Alf(2) As Single
    Private a1 As Single
    Private Rextp, Rext, rr As Single
    Private x1, y1 As Single
    Private isign As Short
    Private dist1, dist2, Gener As Single
    Private RagP, SpessBase As Single
    Private Dpic, Dgran As Single
    Private iSwap, iFuori As Short
    Private jcaso(4) As Short
    Private a2 As Single
    Private iPs, iDentro As Short
    Private Spot2, Spot1, Spot3 As spot
    Private Ogg0 As Membratura
    Private iDentrotutti As Boolean
    Private PuntoVec As RoutBase1.clsVec2
    Private Sp1 As New Spicchio4
    Private Sp2 As New Spicchio4
    Private Mode As Short
    Private D11 As Single
    Private Coincid As Short
    Private StessDir1, StessDir As Single
    Private Re4, Re2, Re1, Re3, Re5 As Single
    Private Re8, Re6, Re0, Re7, Re9 As Single
    Private Re10, Re11 As Single
    Private Elem As Membratura
    Private Risp, yymax As Single
    Private Appeso As Membratura
    Private Tubi As Tubi
    Private Rcal As Single
    Private Oggetto As Membratura
    Private GenMem As clsGenMem
    Private B1 As Single
    Private Tipo As Short
    Private Piastra As Piastrone
    Private Flangione As Flangione
    Private Cal As CalDisc
    Private DeltaOr As New RoutBase1.clsVec3
    Private CosDeltaOr As New RoutBase1.clsVec3
    Private Prod3, Prod1, Prod2, Prod4 As Single
    Private i0 As Short
    Private racc1 As Single
    Private iswRanda, iSwBul As Boolean
    Private Dext As Single
    Private Dfori, Dguar, BoltCir As Single
    Private Nf As Short, icolor As Short
    Private Direz3 As New RoutBase1.clsVec2
    Private Vector As New RoutBase1.clsVec2
    Private posspaM As Posizione
    Private xc, yc As Single
    Private corda As Single
    Private x2, y2 As Single
    Private phi, gamma, TanBeta As Single
    Private AC, BB, Beta, AA, AB, cosb As Single
    Private fact, Passo As Single
    Private Spicchio4 As Spicchio4
    Private senso, LLun, LCor As Short
    Private Alfa3 As Single
    Private DScal, LScal As Single
    Private LC1, Tnear, Tfar, LC2 As Single
    Private T2loc, Hnear, Hfar, Dloc As Single
    Private iswBocch As Short
    Private DeltaX1, DeltaX2 As Single
    Private Ind As Short
    Private Ogg5 As Membratura
    Private Rovescia As Boolean
    Private Spost As Single
    Private HRANZAi, HRANZAe, Spessmant As Single
    Private SpessGra0, Adim, H1, DiamGr0 As Single
    Private Fondo As Fondo
    Private NearFar As Boolean
    Private DiamFon, DiamCil As Single
    Private bRastr, hRastr As Single
    Friend Sub MembroLeggi(ByVal O As Membratura, ByVal s As String, ByVal m As Short)
        Dim g As clsGenMem = O.GenMem
        Membro.Variato = True
        Select Case Math.Abs(g.Tipo)
            Case 1, 2, 34 : CType(O, Cilindro).leggi(s, m)
            Case 3, 4, 5 : CType(O, Fondo).leggi(s, m)
            Case 6, 7, 46 : CType(O, Cono).leggi(s, m)
            Case 8, 9 : CType(O, Tubi).leggi(s, m)
            Case 10 : CType(O, clsBocch).leggi(s, m)
            Case 11 : CType(O, Flangione).leggi(s, m)
            Case 12 : CType(O, Piastrone).leggi(s, m)
            Case 13 : CType(O, clsTirante).leggi(s, m)
            Case 14 : CType(O, clsNonStd).leggi(s, m)
            Case 15 : CType(O, Striscia).leggi(s, m)
            Case 16 : CType(O, CalDisc).leggi(s, m)
            Case 18 : CType(O, Dilat).leggi(s, m)
            Case 17 : CType(O, Anello).leggi(s, m)
            Case 19 : CType(O, Diaframma).leggi(s, m)
            Case 20, 22
                MsgBox("Da programmare" & Str(Tipo) & " in Membroleggi")
            Case 21 : CType(O, Curva).leggi(s, m)
            Case 23 : CType(O, Tondo).leggi(s, m)
            Case 24 'Call DiafraGlob: 'Varie
                Stop
            Case 25 : CType(O, Sella).leggi(s, m)
            Case 31, 32, 33, 37, 38 : CType(O, Raggrupp).leggi(s, m)
            Case 26 : CType(O, Fascio).leggi(s, m)
            Case 27, 29 'Call DiafraGlob: ' close #99:Catena "DIAFRAM"
            Case 28 : CType(O, clsGuarniz).leggi(s, m)
            Case 30
            Case 36 'Call Belts
            Case 96 : CType(O, clsPolig).leggi(s, m)
            Case 97 : CType(O, Foratura).leggi(s, m)
        End Select
    End Sub
    Public Sub ScegliClassiPossibili(ByVal Mat As LibMat.clsMatCompos)
        Dim i As Short
        Select Case System.Math.Abs(Membro.GenMem.Tipo)
            Case 1, 3, 4, 5, 11
                For i = 0 To 9
                    Select Case i + 1
                        Case 1, 2, 7 : Mat.IndAdd(1, i)
                        Case Else : Mat.IndAdd(0, i)
                    End Select
                Next
            Case 12 'Piastroni,coperchi
                For i = 0 To 9
                    Select Case i + 1
                        Case 1, 2, 7 : Mat.IndAdd(1, i)
                        Case Else : Mat.IndAdd(0, i)
                    End Select
                Next
            Case 10, 14
                For i = 0 To 9
                    Select Case i + 1
                        Case 7 : Mat.IndAdd(1, i)
                        Case Else : Mat.IndAdd(0, i)
                    End Select
                Next
            Case 2 'tronchetti
                For i = 0 To 9
                    Select Case i + 1
                        Case 6 : Mat.IndAdd(1, i)
                        Case Else : Mat.IndAdd(0, i)
                    End Select
                Next
            Case 6, 7
                For i = 0 To 9
                    Select Case i + 1
                        Case 1, 2 : Mat.IndAdd(1, i)
                        Case 6
                            If CType(Membro, Cono).Fitting Then Mat.IndAdd(1, i)
                        Case Else : Mat.IndAdd(0, i)
                    End Select
                Next
            Case 15, 17, 18, 19, 25, 34
                For i = 0 To 9
                    Select Case i + 1
                        Case 1, 2 : Mat.IndAdd(1, i)
                        Case Else : Mat.IndAdd(0, i)
                    End Select
                Next
            Case 13 'tiranti
                For i = 0 To 9
                    Select Case i + 1
                        Case 8 : Mat.IndAdd(1, i)
                        Case Else : Mat.IndAdd(0, i)
                    End Select
                Next
            Case 28 'guarnizioni
                For i = 0 To 9
                    Select Case i + 1
                        Case 10 : Mat.IndAdd(1, i)
                        Case Else : Mat.IndAdd(0, i)
                    End Select
                Next
            Case 8, 9, 26 'tubi scambiatori
                For i = 0 To 9
                    Select Case i + 1
                        Case 4 : Mat.IndAdd(1, i)
                        Case Else : Mat.IndAdd(0, i)
                    End Select
                Next
            Case Else
                For i = 0 To 9
                    Mat.IndAdd(1, i)
                Next
        End Select
    End Sub
    Sub DisDilat(ByRef Oggetto As Dilat)
        'On Local Error GoTo ErrDisDilat
        posspa = Oggetto.GenMem.SwappedPos
        With Oggetto
            If .nPli = 0 Then .nPli = 1
            If IUNL = 0 Then
                xSmin = -.Lunghezza / 5 : ySmin = 1.2 * (-(.DIMAX + .Spess * .nPli * 2) / 2) : xSmax = 1.2 * .Lunghezza : ySmax = -ySmin
                If Not Funzioni.DisRut.Scala(xSmin, xSmax, ySmin, ySmax) Then Exit Sub
            End If
            Direzione.X = 0 : Direzione.y = 0 : Direzione.Z = 1
            prod = posspa.CosDiritta.ProdScalar(Direzione)
            Verso = posspa.Origine.Z
            If System.Math.Abs(prod) < TOLER Then
                SezLunDilat(Oggetto)
            Else
                SezRettDilat(Oggetto)
            End If
        End With
    End Sub
    Private Sub SezLunDilat(ByVal Oggetto As Dilat)
        With Oggetto
            If Verso < -.DIMAX / 2 Then Exit Sub
            If IUNL = 4 Then
                Diametro = .DIMIN
                Spessore = (.DIMAX - .DIMIN) / 2
                Lunghezza = .Lunghezza
                Call SpotCil(Oggetto, Verso, Diametro, Spessore, Lunghezza)
                Exit Sub
            End If
            '-----------------------------------------------collari
            If .SottoTipo > 2 And .SottoTipo < 6 Then
                Cil = New Cilindro
                Cil.Lunghezza = .Colletto
                Cil.Diametro = .DIMIN
                Cil.SpessBase = .nPli * .Spess
                posspa.Copia((Cil.GenMem.SwappedPos))
410:            Call DisCil(0, Cil)
                Cil.GenMem.SwappedPos.Origine.X = posspa.Origine.X + (.Lunghezza - .Colletto) * posspa.CosDiritta.X
                Cil.GenMem.SwappedPos.Origine.y = posspa.Origine.y + (.Lunghezza - .Colletto) * posspa.CosDiritta.y
420:            Call DisCil(0, Cil)
                'AddMembrat = AddSav
            End If
            '--------------------------------------------------------
            If Verso > .DIMAX / 2 Then 'dilatatore in vista
                Call Infilata(Oggetto, Verso, InMezzo)
                If InMezzo > 1 Then Exit Sub
                If InMezzo = 1 Then Call Funzioni.DisRut.ctrait(3, 0.1) Else Call Funzioni.DisRut.ctrait(0, 0.1)
                Vista = True
            Else
                Vista = False
            End If
            x = posspa.Origine.X '* Scalb!
            y = posspa.Origine.y ' * Scalb!
430:        Call Funzioni.DisRut.refabs()
            DirR.X = posspa.CosDiritta.X
            DirR.y = posspa.CosDiritta.y
            Alfaa = GlobalRoutines.arco((DirR.X), (DirR.y)) * 180 / Pi
            'Call Funzioni.DisRut.refere(x! + offx!, y! + offy!, Alfaa!)
            Call Funzioni.DisRut.refere(x, y, Alfaa)
            If .SottoTipo > 2 And .SottoTipo < 6 Then
                SpostX = .Colletto * posspa.CosDiritta.X '* Scalb!
                SpostY = .Colletto * posspa.CosDiritta.y '* Scalb!
                Call Funzioni.DisRut.refere(SpostX, SpostY, 0.0!)
            End If
            x = 2 * .Raggio + .nPli * .Spess
            If .SottoTipo = 1 Then x = x + 2 * .Colletto
            If .SottoTipo = 6 Then x = x + .LungCol + .Colletto
            SpostX = 2 * x * posspa.CosDiritta.X ' * Scalb!
            SpostY = 2 * x * posspa.CosDiritta.y '* Scalb!
            RintSup = .Raggio
            RintInf = .Raggio
            If .SottoTipo = 1 Then RintSup = .SezRinf
            For i = 1 To .nOnde
                For j = -1 To 1 Step 2
                    SemiOnda(Oggetto)
                    Call Funzioni.DisRut.refere(SpostX, SpostY, 180.0!)
                    SemiOnda(Oggetto)
                    Call Funzioni.DisRut.refere(-SpostX, -SpostY, -180.0!)
                Next
                Call Funzioni.DisRut.refere(SpostX, SpostY, 0.0!)
            Next
            Call Funzioni.DisRut.refabs()
        End With
    End Sub
    Private Sub SezRettDilat(ByVal Oggetto As Dilat)
        With Oggetto
            z1 = posspa.Origine.Z
            z2 = posspa.Origine.Z + .Lunghezza * posspa.CosDiritta.Z
            Verso = posspa.Origine.Z
            If z1 < 0 And z2 < 0 Then
                Exit Sub
            Else
                x = posspa.Origine.X '* Scalb!
                y = posspa.Origine.y '* Scalb!
                Ri = .DIMIN / 2 '* Scalb!
                Re = (.DIMIN / 2 + .nPli * .Spess) ' * Scalb!
                RiG = .DIMAX / 2 '* Scalb!
                ReG = (.DIMAX / 2 + .nPli * .Spess) ' * Scalb!
                If IUNL = 4 Then
                    Spots = New spot
                    Spots.Tipo = 2
                    Spots.Quota = (z1 + z2) / 2
                    Spots.spicchio.Origin.X = x ' offx! + x!
                    Spots.spicchio.Origin.y = y ' offy! + y!
                    Spots.spicchio.RG = ReG
                    Spots.spicchio.RP = Ri
                    Spots.spicchio.Alfa = 2 * Pi
                    RegisterSpot(Spots, Oggetto)
                    Exit Sub
                End If
                If z1 > 0 And z2 > 0 Then
                    Call Infilata(Oggetto, Verso, InMezzo)
                    If InMezzo > 1 Then Exit Sub
                    If InMezzo = 1 Then Call Funzioni.DisRut.ctrait(3, 0.1) Else Call Funzioni.DisRut.ctrait(0, 0.1)
                End If
                Call Funzioni.DisRut.refabs()
163:            'Call Funzioni.DisRut.refere(offx!, offy!, 0)
                Call Funzioni.DisRut.ctrait(0, 0.1)
                If z1 * z2 < 0 Then
                    Call Funzioni.DisRut.cerc(x, y, Ri)
                    Call Funzioni.DisRut.cerc(x, y, Re)
                    Call Funzioni.DisRut.cerc(x, y, ReG)
                Else
                    Call Funzioni.DisRut.cerc(x, y, Ri)
                    Call Funzioni.DisRut.cerc(x, y, ReG)
                End If
164:            Call Funzioni.DisRut.refabs()
            End If
        End With
    End Sub
    Private Sub SemiOnda(ByVal Oggetto As Dilat)
        With Oggetto
            'cilindro minore
            If (.SottoTipo = 1 Or .SottoTipo = 6) And .Colletto > 0 Then
                xa = 0 : xb = .Colletto ' * Scalb!
                xSpess = .nPli * .Spess
                If .SottoTipo = 6 Then xSpess = .SpesCol
                ya = j * (.DIMIN / 2 + xSpess) ' * Scalb!
                yb = ya
                Call Funzioni.DisRut.segm(xa, ya, xb, yb)
                If Not Vista Then
                    ya = ya - j * xSpess ' * Scalb!
                    yb = yb - j * xSpess '* Scalb!
                    Call Funzioni.DisRut.segm(xa, ya, xb, yb)
                End If
                xa0 = xb
            Else
                xa0 = 0
            End If
            'primo raggio
            xa = xa0
            ya = j * (.DIMIN / 2 + .nPli * .Spess + RintInf) ' * Scalb!
            xb = xa0
            yb = j * (.DIMIN / 2 + .nPli * .Spess) ' * Scalb!
            Call Funzioni.DisRut.arc(xa, ya, xb, yb, 90.0! * j)
            If Not Vista Then
                xb = xa0
                yb = j * .DIMIN / 2 ' * Scalb!
                Call Funzioni.DisRut.arc(xa, ya, xb, yb, 90.0! * j)
            End If
            'verticale
            xa = xa0 + RintInf ' * Scalb!
            ya = j * (.DIMIN / 2 + .nPli * .Spess + RintInf) ' * Scalb!
            xb = xa0 + RintInf ' * Scalb!
            Dum = .DIMAX / 2 - RintSup
            If .SottoTipo = 6 Then Dum = Dum + .SezRinf - .Spess
            yb = j * (.DIMAX / 2 - RintSup) ' * Scalb!
            Call Funzioni.DisRut.segm(xa, ya, xb, yb)
            If Not Vista Then
                xa = xa + .nPli * .Spess ' * Scalb!
                xb = xb + .nPli * .Spess '* Scalb!
            Else
                ya = j * (.DIMIN / 2 + .nPli * .Spess + RintInf / 2) ' * Scalb!
                yb = 0
            End If
            Call Funzioni.DisRut.segm(xa, ya, xb, yb)
            'secondo raggio
            xa = xa0 + (2 * RintSup + .nPli * .Spess) ' * Scalb!
            ya = j * (.DIMAX / 2 - RintSup) ' * Scalb!
            xb = xa0 + RintSup ' * Scalb!
            yb = j * (.DIMAX / 2 - RintSup) ' * Scalb!
            Call Funzioni.DisRut.arc(xa, ya, xb, yb, -90.0! * j)
            If Not Vista Then
                xb = xb + .nPli * .Spess '* Scalb!
                Call Funzioni.DisRut.arc(xa, ya, xb, yb, -90.0! * j)
            End If
            If .SottoTipo = 1 Or .SottoTipo = 6 Then
                'orizzontale
                xSpess = .nPli * .Spess
                If .SottoTipo = 6 Then xSpess = .SezRinf
                xa = xa0 + (2 * RintSup + xSpess) ' * Scalb!
                ya = j * (.DIMAX / 2 + xSpess) ' * Scalb!
                XLung = .Colletto : If .SottoTipo = 6 Then XLung = .LungCol
                xb = xa + XLung ' * Scalb!
                yb = ya
                If .SottoTipo < 6 Then Call Funzioni.DisRut.segm(xa, ya, xb, yb)
                If Not Vista Then
                    ya = ya - j * xSpess ' * Scalb!
                    yb = yb - j * xSpess '* Scalb!
                    If .SottoTipo < 6 Then Call Funzioni.DisRut.segm(xa, ya, xb, yb)
                End If
            End If
        End With
    End Sub
    Sub DisStri(ByRef Oggetto As Striscia)
        Dim Alung, SP, Alt As Single
        Dim Npunti, Np As Short
        Dim Verso As Single
        Dim isW As Boolean
        Dim Spots As spot
        Dim Punti As New RoutBase1.clsPunti
        Dim posspa As Posizione
        posspa = Oggetto.GenMem.SwappedPos
        SP = Oggetto.Spessore
        Alt = Oggetto.Larghezza
        Alung = Oggetto.Lunghezza
        isW = Oggetto.isW 'interruttore di disegnazione
        If Not isW Or IUNL < 1 Then Exit Sub
        Call Interseca(Npunti, Punti, SP, Alt, Alung, posspa, Verso)
        If Npunti < 0 Then 'calcola linee nascoste.Punti proiettati su Oxy da spigoli ad esso perpendicolari
            Call DisTaglio(Npunti, Punti, Verso, Oggetto)
        ElseIf Npunti > 0 Then  ' spigolo interseca Oxy
            Np = System.Math.Abs(Npunti) + 1
            If Np > 1 Then
                Punti.Punti.Add(Punti.Punti.Item(1).TextData)
175:            If IUNL < 4 Then
                    Punti.SpezzGraf(0, Np - 1, Funzioni.DisRut)
                    ' MembroDebug Oggetto
                Else
                    Spots = New spot
                    Spots.Tipo = 1
                    Spots.Quota = 0.0!
                    Punti.Punti.Item(1).TextData.copia(Spots.Quadro.TopLeft)
                    Punti.Punti.Item(3).TextData.copia(Spots.Quadro.Botrigt)
                    RegisterSpot(Spots, Oggetto)
                End If 'aa
            End If 'bb
        End If 'cc
    End Sub 'b
    'Sub MaxMin(Npunti As Integer, Punti As clsPunti, posspa As posizione)
    '      Dim xSmin As Single, ySmin As Single
    '      Dim xSmax As Single, ySmax As Single
    '      Dim i As Integer
    '      If Npunti = 0 Then Exit Sub
    '      xSmin = Infinito: ySmin = Infinito: xSmax = -xSmin: ySmax = -ySmin
    '      For i = 1 To Abs(Npunti) 'Npunti<0 se in vista fuori piano Oxy
    '        If Punti.Punti(i).x < xSmin Then xSmin = Punti.Punti(i).x
    '        If Punti.Punti(i).y < ySmin Then ySmin = Punti.Punti(i).y
    '        If Punti.Punti(i).x > xSmax Then xSmax = Punti.Punti(i).x
    '        If Punti.Punti(i).y > ySmax Then ySmax = Punti.Punti(i).y
    '      Next
    '172   Call ScalaRel(posspa, xSmin, ySmin, xSmax, ySmax, True)
    'End Sub 'h

    Sub DisTaglio(ByRef Npunti As Short, ByRef Punti As RoutBase1.clsPunti, ByRef Verso As Single, ByRef Oggetto As Membratura)
        'On Local Error GoTo ErrDisTaglio
        'UPGRADE_NOTE: Dir è stato aggiornato a DirR. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1061"'
        Dim Nascosto(20) As Short
        Dim DirR As New RoutBase1.clsVec2
        Dim det As Single
        Dim Dint1, Dint2 As Single
        Dim i, j As Short
        Dim i1, Np, i2 As Short
        Dim R1 As Single
        Dim j1 As Short
        Dim Res As Boolean
        Dim posspa As Posizione
        Dim dist1, dist, dist2 As Single
        Dim InMezzo As Short
        Dim Spots As spot
        Dim Ogg4 As Membratura
        Dim DentroTutti As Boolean
        Dim Tipo As Short
        'risali fino al primo cilindro (o 0) e ponilo in Rec2Buf(4)
        Dim Originale As New Posizione
        posspa = Oggetto.GenMem.SwappedPos
        posspa.Copia(Originale)
        Ogg4 = Oggetto
        Ogg4 = Ogg4.GenMem.posizione.SuChi
        SwapCoordN(Ogg4.GenMem) ' 4
        Ogg4.GenMem.SwappedPos.Origine.Copia(posspa.Origine)
        Ogg4.GenMem.SwappedPos.CosDiritta.Copia(posspa.CosDiritta)
        Dint2 = 0
        For i = 1 To System.Math.Abs(Npunti)
            R1 = Punti.Punti.Item(i).TextData.X * posspa.CosDiritta.X + Punti.Punti.Item(i).TextData.y * posspa.CosDiritta.y
            Call CercaInt(Oggetto, R1, Dint1, 10000.0!) ' fai 4 volte
            If Dint1 > Dint2 Then Dint2 = Dint1
        Next
        Np = System.Math.Abs(Npunti)
        If Dint2 = 0 Then GoTo Jump
        Dim P0 As New RoutBase1.clsVec2
        Dim p1 As New RoutBase1.clsVec2
        Dim Inters As New RoutBase1.clsVec2
        Dim Linea1 As New RoutBase1.clsLinea2
        Dim Linea2 As New RoutBase1.clsLinea2
        For j = -1 To 1 Step 2
            P0.X = posspa.Origine.X - j * Dint2 / 2 * posspa.CosDiritta.y
            P0.y = posspa.Origine.y + j * Dint2 / 2 * posspa.CosDiritta.X
            p1.X = P0.X + 1000.0! * posspa.CosDiritta.X
            p1.y = P0.y + 1000.0! * posspa.CosDiritta.y
            i = 1
            Do
                i1 = i + 1 : If i1 > Np Then i1 = 1
                Linea1.P0 = P0 : Linea1.p1 = p1
                Linea2.P0 = New RoutBase1.clsVec2
                Linea2.p1 = New RoutBase1.clsVec2
                Linea2.P0.X = Punti.Punti.Item(i).TextData.X
                Linea2.P0.y = Punti.Punti.Item(i).TextData.y
                Linea2.p1.X = Punti.Punti.Item(i1).TextData.X
                Linea2.p1.y = Punti.Punti.Item(i1).TextData.y
                Linea1.CalcolaDir()
                Linea2.CalcolaDir()
                Res = Linea1.InterRettRett(Linea2, Inters)
                If Res Then
                    If ((Inters.X - Punti.Punti.Item(i).TextData.X) * (Inters.X - Punti.Punti.Item(i1).TextData.X) < 0 Or (Inters.y - Punti.Punti.Item(i).TextData.y) * (Inters.y - Punti.Punti.Item(i1).TextData.y) < 0) Then
                        Np = Np + 1
                        For i2 = Np - 1 To i + 1 Step -1
                            Punti.Punti.Item(i2 + 1).TextData = Punti.Punti.Item(i2).TextData
                        Next
                        Punti.Punti.Item(i + 1).TextData = Inters
                        i = i + 1
                    End If
                End If 'a
193:            i = i + 1
            Loop While i <= Np
        Next j
        Dim Punti1 As New RoutBase1.clsPunti
        Punti1.Inizia(2)
        For j = 1 To 2
            j1 = -1 : If j = 2 Then j1 = 1
            Punti1.Punti.Item(j).TextData.X = posspa.Origine.X - j1 * Dint2 / 2 * posspa.CosDiritta.y
            Punti1.Punti.Item(j).TextData.y = posspa.Origine.y + j1 * Dint2 / 2 * posspa.CosDiritta.X
        Next
        det = System.Math.Sqrt((Punti1.Punti.Item(1).TextData.X - Punti1.Punti.Item(2).TextData.X) ^ 2 + (Punti1.Punti.Item(1).TextData.y - Punti1.Punti.Item(2).TextData.y) ^ 2)
        If System.Math.Abs(det) < TOLER Then GoTo Jump
        DirR.X = (Punti1.Punti.Item(2).TextData.X - Punti1.Punti.Item(1).TextData.X) / det
        DirR.y = (Punti1.Punti.Item(2).TextData.y - Punti1.Punti.Item(1).TextData.y) / det
        dist1 = Punti1.Punti.Item(1).TextData.X * DirR.X + Punti1.Punti.Item(1).TextData.y * DirR.y
        dist2 = Punti1.Punti.Item(2).TextData.X * DirR.X + Punti1.Punti.Item(2).TextData.y * DirR.y
        DentroTutti = True
        For j = 1 To Np
            dist = Punti.Punti.Item(j).TextData.X * DirR.X + Punti.Punti.Item(j).TextData.y * DirR.y
            If (dist1 - dist) * (dist2 - dist) < 0 Then Nascosto(j) = True
            If System.Math.Abs(dist1) < System.Math.Abs(dist) Then DentroTutti = False
        Next
        If DentroTutti Then
            For j = 1 To Np
                Nascosto(j) = False
            Next
        End If
Jump:
        Originale.Copia(posspa)
        If IUNL < 4 Then
            Verso = posspa.Origine.Z
198:        Call Infilata(Oggetto, Verso, InMezzo)
            If InMezzo > 1 Then Exit Sub
            If InMezzo = 1 Then Funzioni.DisRut.ctrait(3, 0.1)
        End If 'b
        If IUNL < 4 Then
            For j = 1 To Np
                j1 = j + 1 : If j = Np Then j1 = 1
197:            If Nascosto(j) Or Nascosto(j1) Then Tipo = 1 Else Tipo = 0
                Funzioni.DisRut.tratto(Punti.Punti.Item(j).TextData.X, Punti.Punti.Item(j).TextData.y, Punti.Punti.Item(j1).TextData.X, Punti.Punti.Item(j1).TextData.y, 0.1, Tipo)
            Next
            Call Funzioni.DisRut.ctrait(0, 0.1)
        Else
            Spots = New spot
            Spots.Tipo = 1
            Spots.Quota = Verso
            Punti.Punti.Item(1).TextData.copia(Spots.Quadro.TopLeft)
            Punti.Punti.Item(3).TextData.copia(Spots.Quadro.Botrigt)
            RegisterSpot(Spots, Oggetto)
        End If 'c
    End Sub 'c
    Sub IntersPol(ByRef Polig As clsPolig, ByRef Npuntif As Short, ByRef Puntif As RoutBase1.clsPunti, ByRef Puntif1 As RoutBase1.clsPunti, ByRef Verso As Single, ByRef CoszSW As RoutBase1.clsVec3)
        Dim DirR As New RoutBase1.clsVec3
        posspa = Polig.GenMem.posizione
        If Polig.Rifer = 1 Then 'terza perpend.alla lamiera
            Cosy = posspa.CosDiritta
            Cosx = posspa.CosTraversa
            Cosz = posspa.CosTerza
            CoszSW = Polig.GenMem.SwappedPos.CosTerza
        Else 'If Polig.Rifer = 0 Then 'diritta perpend.alla lamiera
            Cosz = posspa.CosDiritta
            Cosx = posspa.CosTraversa
            Cosy = posspa.CosTerza
            CoszSW = Polig.GenMem.SwappedPos.CosDiritta
        End If
        Puntif = New RoutBase1.clsPunti
        Puntif1 = New RoutBase1.clsPunti
        Npuntif = 0
        DirR.X = 0 : DirR.y = 1 : DirR.Z = 0
        Dir3.X = 1 : Dir3.y = 0 : Dir3.Z = 0
        prod = CoszSW.ProdTripl(DirR, Dir3)
        If System.Math.Abs(prod) < TOLER Then 'sezione attraverso lo spessore perché la perpendicolare alla lamiera giace in XY swapped
            Verso = 0
            Leggipunti(Polig)
            For i = 1 To Npunti
                If i > 1 Then
                    i1 = i - 1
                    dist = System.Math.Sqrt((PPP.Punti.Item(i).TextData.X - PPP.Punti.Item(i1).TextData.X) ^ 2 + _
                           (PPP.Punti.Item(i).TextData.y - PPP.Punti.Item(i1).TextData.y) ^ 2 + _
                           (PPP.Punti.Item(i).TextData.Z - PPP.Punti.Item(i1).TextData.Z) ^ 2)
                    If dist < TOLER Then GoTo ContNpu
                End If 'o
                i1 = i + 1
Dinu:           If i1 > Npunti Then i1 = 1
                dist = System.Math.Sqrt((PPP.Punti.Item(i).TextData.X - PPP.Punti.Item(i1).TextData.X) ^ 2 _
                     + (PPP.Punti.Item(i).TextData.y - PPP.Punti.Item(i1).TextData.y) ^ 2 + _
                       (PPP.Punti.Item(i).TextData.Z - PPP.Punti.Item(i1).TextData.Z) ^ 2)
                If dist < TOLER Then
                    i1 = i1 + 1
                    If i1 <= Npunti Then
                        GoTo Dinu
                    Else
                        GoTo ContNpu
                    End If
                End If
                PZ1 = PPP.Punti.Item(i).TextData.Z
                PZ2 = PPP.Punti.Item(i1).TextData.Z
                If PZ1 <= 0 And PZ2 > 0 Or PZ1 > 0 And PZ2 <= 0 Then
                    Nvol = Nvol + 1
                    Npuntif = Npuntif + 1
                    Punto = New RoutBase1.clsVec2
                    Puntif.Punti.Add(Punto)
                    k = i : K1 = i1
                    DelxDely(Polig, CoszSW)
                    Punto.X = PPP.Punti.Item(i).TextData.X + delx
                    Punto.y = PPP.Punti.Item(i).TextData.y + dely
                    Npuntif = Npuntif + 1
                    Punto = New RoutBase1.clsVec2
                    Puntif.Punti.Add(Punto)
                    ii = i + Npunti : ii1 = i1 + Npunti
                    k = ii : K1 = ii1
                    DelxDely(Polig, CoszSW)
                    Punto.X = PPP.Punti.Item(ii).TextData.X + delx
                    Punto.y = PPP.Punti.Item(ii).TextData.y + dely
                    If Nvol Mod 2 = 1 Then Puntif.SWAP(Npuntif, Npuntif - 1)
                    'Puntif1.Punti(Npuntif).X = 0 '                niente cerchio (ehm, ehm !)
                End If 'p
ContNpu:
            Next
            Npuntif = -Npuntif 'di taglio
        Else 'vista in piano
            Leggipunti(Polig)
            If PPP.Punti.Count = 0 Then Verso = -1000 : Exit Sub
            PZ1 = PPP.Punti.Item(1).TextData.Z
            PZ2 = PPP.Punti.Item(Npunti + 1).TextData.Z
            If PZ1 < 0 And PZ2 < 0 Then Verso = -1000 : Exit Sub
            Verso = (PZ1 + PZ2) / 2
            Npuntif = Npunti
            For i = 1 To Npuntif
                'Puntif.Punti(i).X = PPP.Punti(i).X:         Puntif.Punti(i).Y = PPP.Punti(i).Y
                'Puntif1.Punti(i).X = Centri.Punti(i).X:      Puntif1.Punti(i).Y = Centri.Punti(i).Y
                Punto = New RoutBase1.clsVec2
                Punto.X = PPP.Punti.Item(i).TextData.X
                Punto.y = PPP.Punti.Item(i).TextData.y
                Puntif.Punti.Add(Punto)
                Punto = New RoutBase1.clsVec2
                Punto.X = Centri.Punti.Item(i).TextData.X
                Punto.y = Centri.Punti.Item(i).TextData.y
                Puntif1.Punti.Add(Punto)
            Next
            'ELSE
            '   PRINT "Poligonale sghemba": u$ = INPUT$(1): EXIT SUB
        End If 'q
    End Sub
    Private Sub Leggipunti(ByVal Polig As clsPolig)
        With Polig
            Npunti = .Vertici.Punti.Count
            PPP = New RoutBase1.clsPunti3
            PPP.Inizia(Npunti * 2)
            Centri = New RoutBase1.clsPunti3
            Centri.Inizia(Npunti * 2)
            For i = 1 To Npunti
                For k = -1 To 1 Step 2
                    j = i + Npunti * (k + 1) / 2
                    PP.X = .Vertici.Punti.Item(i).TextData.X
                    PP.y = .Vertici.Punti.Item(i).TextData.y
                    PP.Z = k * .Spessore / 2
                    Cen.X = .Centri.Punti.Item(i).TextData.X
                    Cen.y = .Centri.Punti.Item(i).TextData.y
                    Cen.Z = k * .Spessore / 2 'sistema non swappato con y asse e z verticale
                    PPP.Punti.Item(j).TextData.X = PP.X * Cosx.X + PP.y * Cosy.X + PP.Z * Cosz.X
                    PPP.Punti.Item(j).TextData.y = PP.X * Cosx.y + PP.y * Cosy.y + PP.Z * Cosz.y
                    PPP.Punti.Item(j).TextData.Z = PP.X * Cosx.Z + PP.y * Cosy.Z + PP.Z * Cosz.Z
                    PPP.Punti.Item(j).TextData.X = PPP.Punti.Item(j).TextData.X + posspa.Origine.X
                    PPP.Punti.Item(j).TextData.y = PPP.Punti.Item(j).TextData.y + posspa.Origine.y
                    PPP.Punti.Item(j).TextData.Z = PPP.Punti.Item(j).TextData.Z + posspa.Origine.Z
                    If System.Math.Abs(.Raggi.Item(i).TextData) > TOLER Then
                        Centri.Punti.Item(j).TextData.X = Cen.X * Cosx.X + Cen.y * Cosy.X + Cen.Z * Cosz.X
                        Centri.Punti.Item(j).TextData.y = Cen.X * Cosx.y + Cen.y * Cosy.y + Cen.Z * Cosz.y
                        Centri.Punti.Item(j).TextData.Z = Cen.X * Cosx.Z + Cen.y * Cosy.Z + Cen.Z * Cosz.Z
                        Centri.Punti.Item(j).TextData.X = Centri.Punti.Item(j).TextData.X + posspa.Origine.X
                        Centri.Punti.Item(j).TextData.y = Centri.Punti.Item(j).TextData.y + posspa.Origine.y
                        Centri.Punti.Item(j).TextData.Z = Centri.Punti.Item(j).TextData.Z + posspa.Origine.Z
                    Else
                        Centri.Punti.Item(j).TextData.X = 0
                        Centri.Punti.Item(j).TextData.y = 0
                        Centri.Punti.Item(j).TextData.Z = 0
                    End If 'r
                    Swap3(PPP.Punti.Item(j).TextData, 1) 'sistema swappato con z perpendicolare al piano della sezione
                    Swap3(Centri.Punti.Item(j).TextData, 1)
                Next k
                ' Polig.Raggi(i) = Recmod.Raggio(i)
            Next
        End With
    End Sub
    Private Sub DelxDely(ByVal Polig As clsPolig, ByVal CoszSW As RoutBase1.clsVec3)
        With Polig
            If System.Math.Abs(.Raggi.Item(i).TextData) < TOLER Then
                delx = (PPP.Punti.Item(K1).TextData.X - PPP.Punti.Item(k).TextData.X) * System.Math.Abs(PZ1) / (System.Math.Abs(PZ1) + System.Math.Abs(PZ2))
                dely = (PPP.Punti.Item(K1).TextData.y - PPP.Punti.Item(k).TextData.y) * System.Math.Abs(PZ1) / (System.Math.Abs(PZ1) + System.Math.Abs(PZ2))
            Else
                cosP1.X = (PPP.Punti.Item(k).TextData.X - Centri.Punti.Item(k).TextData.X) / System.Math.Abs(.Raggi.Item(i).TextData)
                cosP1.y = (PPP.Punti.Item(k).TextData.y - Centri.Punti.Item(k).TextData.y) / System.Math.Abs(.Raggi.Item(i).TextData)
                cosP1.Z = (PPP.Punti.Item(k).TextData.Z - Centri.Punti.Item(k).TextData.Z) / System.Math.Abs(.Raggi.Item(i).TextData)
                cosP2.X = (PPP.Punti.Item(K1).TextData.X - Centri.Punti.Item(k).TextData.X) / System.Math.Abs(.Raggi.Item(i).TextData)
                cosP2.y = (PPP.Punti.Item(K1).TextData.y - Centri.Punti.Item(k).TextData.y) / System.Math.Abs(.Raggi.Item(i).TextData)
                cosP2.Z = (PPP.Punti.Item(K1).TextData.Z - Centri.Punti.Item(k).TextData.Z) / System.Math.Abs(.Raggi.Item(i).TextData)
                dist = PPP.Punti.Item(k).TextData.DistPunPun(PPP.Punti.Item(K1).TextData)
                Alfa = GlobalRoutines.asin(dist / 2 / System.Math.Abs(.Raggi.Item(i).TextData))
                '            Debug.Print cosP1.ProdScalar(CoszSW)
                Alfax = -2 * Alfa
                cosP1.DirAlpha(CoszSW, Sol, Alfax)
                PuntoSect.X = Centri.Punti.Item(k).TextData.X + Sol.X * System.Math.Abs(.Raggi.Item(i).TextData)
                PuntoSect.y = Centri.Punti.Item(k).TextData.y + Sol.y * System.Math.Abs(.Raggi.Item(i).TextData)
                PuntoSect.Z = Centri.Punti.Item(k).TextData.Z + Sol.Z * System.Math.Abs(.Raggi.Item(i).TextData)
                If System.Math.Abs(PPP.Punti.Item(K1).TextData.DistPunPun(PuntoSect)) > 100 * TOLER Then
                    Alfax = 2 * Alfa
                    cosP1.DirAlpha(CoszSW, Sol, Alfax)
                    PuntoSect.X = Centri.Punti.Item(k).TextData.X + Sol.X * System.Math.Abs(.Raggi.Item(i).TextData)
                    PuntoSect.y = Centri.Punti.Item(k).TextData.y + Sol.y * System.Math.Abs(.Raggi.Item(i).TextData)
                    PuntoSect.Z = Centri.Punti.Item(k).TextData.Z + Sol.Z * System.Math.Abs(.Raggi.Item(i).TextData)
                End If
                If System.Math.Abs(PPP.Punti.Item(K1).TextData.DistPunPun(PuntoSect)) > 100 * TOLER Then
                    MsgBox("Errore imp. Interspol")
                End If
                Ainf = 0
                Asup = Alfax
                Zinf = PPP.Punti.Item(k).TextData.Z
                Zsup = PuntoSect.Z
                Do
                    Alfax = Ainf + (Asup - Ainf) * (-Zinf) / (Zsup - Zinf)
                    cosP1.DirAlpha(CoszSW, Sol, Alfax)
                    PuntoSect.X = Centri.Punti.Item(k).TextData.X + Sol.X * System.Math.Abs(.Raggi.Item(i).TextData)
                    PuntoSect.y = Centri.Punti.Item(k).TextData.y + Sol.y * System.Math.Abs(.Raggi.Item(i).TextData)
                    PuntoSect.Z = Centri.Punti.Item(k).TextData.Z + Sol.Z * System.Math.Abs(.Raggi.Item(i).TextData)
                    Z = PuntoSect.Z
                    If System.Math.Abs(Z) < 1 Then Exit Do
                    If System.Math.Sign(Z) = System.Math.Sign(Zsup) Then
                        Zsup = Z
                        Asup = Alfax
                    Else
                        Zinf = Z
                        Ainf = Alfax
                    End If
                Loop
                delx = PuntoSect.X - PPP.Punti.Item(k).TextData.X
                dely = PuntoSect.y - PPP.Punti.Item(k).TextData.y
                '  Debug.Print PPP.Punti(k).DistPunPun(Centri.Punti(k)), PPP.Punti(K1).DistPunPun(Centri.Punti(k)), .Raggi(i)
                '  Debug.Print "cosP1"; cosP1.x, cosP1.y, cosP1.Z
                '  Debug.Print "Sol"; Sol.x, Sol.y, Sol.Z
                '  Debug.Print PPP.Punti(k).x, PPP.Punti(K1).x, Centri.Punti(k).x + Sol.x * .Raggi(i)
                '  Debug.Print PPP.Punti(k).y, PPP.Punti(K1).y, Centri.Punti(k).y + Sol.y * .Raggi(i)
                '  Debug.Print PPP.Punti(k).Z, PPP.Punti(K1).Z, Centri.Punti(k).Z + Sol.Z * .Raggi(i)
                '  a = PPP.Punti(K1).y - PPP.Punti(k).y
                '  b = PPP.Punti(K1).x - PPP.Punti(k).x
                '  If Abs(a) < TOLER Then Swap a, b: Swapped = True Else Swapped = False
                '  d = b / a
                '  c = b * PPP.Punti(k).y / a - PPP.Punti(k).x
                '  E = 1 + d * d
                '  f = -2 * (c * d + Centri.Punti(k).x * d + Centri.Punti(k).y)
                '  g = c * c + Centri.Punti(k).x ^ 2 + 2 * c * Centri.Punti(k).x + Centri.Punti(k).y ^ 2 - .Raggi(i) ^ 2 + Centri.Punti(k).Z ^ 2
                '  delta = Sqr(f * f - 4 * E * g)
                '  y = (-f + delta) / 2 / E
                '  x = d * y - c
                'X e Y:intersezione dell'arco con il piano della sezione
                '  If Swapped Then Swap x, y
                '  a = PPP.Punti(k).x
                '  b = PPP.Punti(k).y
                '  c1 = Centri.Punti(k).x
                '  D1 = Centri.Punti(k).y
                '  e1 = Sgn(a - c1): If e1 = 0 Then e1 = 1
                '  f1 = Sgn(b - D1): If f1 = 0 Then f1 = 1
                '1230        Dir1.x = Sqr((a - c1) ^ 2 + (b - D1) ^ 2) * e1 * f1 / Abs(.Raggi(i))
                '  Dir1.y = (PPP.Punti(k).Z - Centri.Punti(k).Z) / Abs(.Raggi(i))
                '  ang1 = arco(Dir1.x, Dir1.y)
                '  'angolo goniometrico  nel piano dell'arco del primo punto terminale
                '  'If ang1 >= PI Then ang1 = ang1 - 2 * PI
                '  a = PPP.Punti(K1).x
                '  b = PPP.Punti(K1).y
                '  e1 = Sgn(a - c1): If e1 = 0 Then e1 = 1
                '  f1 = Sgn(b - D1): If f1 = 0 Then f1 = 1
                '  Dir1.x = Sqr((a - c1) ^ 2 + (b - D1) ^ 2) * e1 * f1 / Abs(.Raggi(i))
                '  Dir1.y = (PPP.Punti(K1).Z - Centri.Punti(k).Z) / Abs(.Raggi(i))
                '  ang2 = arco(Dir1.x, Dir1.y)
                '  'angolo goniometrico nel piano dell'arco del secondo punto terminale
                '  'If ang2 > PI Then ang2 = ang2 - 2 * PI
                '  a = x
                '  b = y
                '  e1 = Sgn(a - c1): If e1 = 0 Then e1 = 1
                '  f1 = Sgn(b - D1): If f1 = 0 Then f1 = 1
                '  Dir1.x = Sqr((a - c1) ^ 2 + (b - D1) ^ 2) * e1 * f1 / Abs(.Raggi(i))
                '  Dir1.y = (-Centri.Punti(k).Z) / Abs(.Raggi(i))
                '  ang = arco(Dir1.x, Dir1.y)
                '  'angolo goniometrico nel piano dell'arco del punto intermedio X,Y
                '  'If ang > PI Then ang = ang - 2 * PI
                '  Select Case (ang1 - ang2)
                '      Case Is > Pi
                '             ang1 = ang1 - 2 * Pi
                '      Case Is < -Pi
                '             ang2 = ang2 - 2 * Pi
                '  End Select
                '  Select Case (ang1 - ang)
                '      Case Is > Pi
                '         '   ang1 = ang1 - 2 * PI
                '      Case Is < -Pi
                '             ang = ang - 2 * Pi
                '  End Select
                '  Select Case (ang - ang2)
                '      Case Is > Pi
                '             ang = ang - 2 * Pi
                '      Case Is < -Pi
                '          '  ang2 = ang2 - 2 * PI
                '  End Select
                '  If (ang1 - ang) * (ang - ang2) < 0 Then
                '     y = (-f - delta) / 2 / E
                '     x = d * y - c
                '     If Swapped Then Swap x, y
                '  End If
                '  delx = x - PPP.Punti(k).x
                '  dely = y - PPP.Punti(k).y
            End If 's
        End With
        'UPGRADE_WARNING: Return ha un nuovo comportamento. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1041"'
        Return
        'ErrPol: PRINT "Err IntersPol"; ERR; ERL: u$ = INPUT$(1): END
    End Sub 'g
    Sub SpezzSpecial(ByRef Np As Short, ByRef Puntif As RoutBase1.clsPunti, ByRef Puntif1 As RoutBase1.clsPunti, ByRef Raggi As RoutBase1.LinkListS, ByRef CoszSW As RoutBase1.clsVec3)
        Dim i, i1 As Short
        Dim dist As Single
        Dim ang, ang1, ang2, Alfa As Single
        Dim Dir1 As New RoutBase1.clsVec2
        Dim Dir2 As New RoutBase1.clsVec2
        Dim RagG As Single
        For i = 1 To Np
            i1 = i + 1 : If i1 > Np Then i1 = 1
            dist = (Puntif.Punti.Item(i).TextData.X - Puntif.Punti.Item(i1).TextData.X) ^ 2 + (Puntif.Punti.Item(i).TextData.y - Puntif.Punti.Item(i1).TextData.y) ^ 2
            If Raggi.Item(i).TextData = 0 And dist > TOLER Then Funzioni.DisRut.tratto(Puntif.Punti.Item(i).TextData.X, Puntif.Punti.Item(i).TextData.y, Puntif.Punti.Item(i1).TextData.X, Puntif.Punti.Item(i1).TextData.y, 0.1, 0)
            If dist > TOLER And Raggi.Item(i).TextData <> 0 Then
                RagG = System.Math.Sqrt((Puntif1.Punti.Item(i).TextData.X - Puntif.Punti.Item(i).TextData.X) ^ 2 + (Puntif1.Punti.Item(i).TextData.y - Puntif.Punti.Item(i).TextData.y) ^ 2)
                Dir1.X = (Puntif.Punti.Item(i).TextData.X - Puntif1.Punti.Item(i).TextData.X) / RagG
                Dir1.y = (Puntif.Punti.Item(i).TextData.y - Puntif1.Punti.Item(i).TextData.y) / RagG
1160:           ang1 = GlobalRoutines.arco((Dir1.X), (Dir1.y))
                Dir2.X = (Puntif.Punti.Item(i1).TextData.X - Puntif1.Punti.Item(i).TextData.X) / RagG
                Dir2.y = (Puntif.Punti.Item(i1).TextData.y - Puntif1.Punti.Item(i).TextData.y) / RagG
1170:           ang2 = GlobalRoutines.arco((Dir2.X), (Dir2.y))
                Alfa = System.Math.Abs(ang1 - ang2)
                ang = (ang1 + ang2) / 2
                If (ang2 - ang1) * Raggi.Item(i).TextData * CoszSW.Z > 0 Then
                    Alfa = 2 * PI - Alfa
                    ang = ang + PI
                    If ang >= 2 * PI Then ang = ang - 2 * PI
                End If 't
                Dir2.X = System.Math.Cos(ang) : Dir2.y = System.Math.Sin(ang)
                ArcoGraf(Puntif1.Punti.Item(i).TextData, RagG, Dir2, Alfa, IUNL - 1)
            End If 'u
        Next
    End Sub 'i
    Sub Interseca(ByRef Npunti As Short, ByRef Punti As RoutBase1.clsPunti, ByRef SP As Single, ByRef Alt As Single, ByRef Alung As Single, ByRef posspa As Posizione, ByRef Verso As Single)
        Dim P0 As RoutBase1.clsVec2
        Cosx = posspa.CosDiritta
        Cosy = posspa.CosTerza
        Cosz = posspa.CosTraversa
        'calcola gli Npunti di intersezione degli spigoli di un paralelepipedo
        'con il piano xy
        PPP.Inizia(8) : QQQ.Inizia(8)
        Npunti = 0 : Npuntj = 0
180:    For j = 1 To 2
            For i = 1 To 4
                PPP.Punti.Item((j - 1) * 4 + i).TextData.X = (j - 1) * Alung
            Next
            PPP.Punti.Item((j - 1) * 4 + 1).TextData.y = SP / 2
            PPP.Punti.Item((j - 1) * 4 + 1).TextData.Z = Alt / 2
            PPP.Punti.Item((j - 1) * 4 + 2).TextData.y = -SP / 2
            PPP.Punti.Item((j - 1) * 4 + 2).TextData.Z = Alt / 2
            PPP.Punti.Item((j - 1) * 4 + 3).TextData.y = -SP / 2
            PPP.Punti.Item((j - 1) * 4 + 3).TextData.Z = -Alt / 2
            PPP.Punti.Item((j - 1) * 4 + 4).TextData.y = SP / 2
            PPP.Punti.Item((j - 1) * 4 + 4).TextData.Z = -Alt / 2
        Next
181:    For i = 1 To 8
            QQQ.Punti.Item(i).TextData.X = PPP.Punti.Item(i).TextData.X * Cosx.X + _
                  PPP.Punti.Item(i).TextData.y * Cosy.X + PPP.Punti.Item(i).TextData.Z * Cosz.X
            QQQ.Punti.Item(i).TextData.y = PPP.Punti.Item(i).TextData.X * Cosx.y + _
                  PPP.Punti.Item(i).TextData.y * Cosy.y + PPP.Punti.Item(i).TextData.Z * Cosz.y
            QQQ.Punti.Item(i).TextData.Z = PPP.Punti.Item(i).TextData.X * Cosx.Z + _
                  PPP.Punti.Item(i).TextData.y * Cosy.Z + PPP.Punti.Item(i).TextData.Z * Cosz.Z
            QQQ.Punti.Item(i).TextData.X = QQQ.Punti.Item(i).TextData.X + posspa.Origine.X
            QQQ.Punti.Item(i).TextData.y = QQQ.Punti.Item(i).TextData.y + posspa.Origine.y
            QQQ.Punti.Item(i).TextData.Z = QQQ.Punti.Item(i).TextData.Z + posspa.Origine.Z
        Next
        Verso = clsTrigon.Infinito
182:    For i = 1 To 7
            For j = i + 1 To 8
                If j - i = 4 Or (j - i = 3 And (i = 1 Or i = 5)) Or (j - i = 1 And i <> 4) Then
                    If QQQ.Punti.Item(i).TextData.Z * QQQ.Punti.Item(j).TextData.Z < 0 Then 'spigolo interseca Oxy
183:                    Npunti = Npunti + 1
                        Verso = 0
                        P0 = New RoutBase1.clsVec2
                        P0.X = QQQ.Punti.Item(i).TextData.X - QQQ.Punti.Item(i).TextData.Z / (QQQ.Punti.Item(j).TextData.Z - _
                               QQQ.Punti.Item(i).TextData.Z) * (QQQ.Punti.Item(j).TextData.X - QQQ.Punti.Item(i).TextData.X)
                        P0.y = QQQ.Punti.Item(i).TextData.y - QQQ.Punti.Item(i).TextData.Z / (QQQ.Punti.Item(j).TextData.Z - _
                               QQQ.Punti.Item(i).TextData.Z) * (QQQ.Punti.Item(j).TextData.y - QQQ.Punti.Item(i).TextData.y)
                        Punti.Punti.Add(P0)
                    ElseIf (QQQ.Punti.Item(i).TextData.X - QQQ.Punti.Item(j).TextData.X) ^ 2 + (QQQ.Punti.Item(i).TextData.y - _
                            QQQ.Punti.Item(j).TextData.y) ^ 2 < 1.0! And QQQ.Punti.Item(i).TextData.Z > 0 And QQQ.Punti.Item(j).TextData.Z > 0 Then 'spigolo perpend. a Oxy e in vista
                        If (QQQ.Punti.Item(i).TextData.Z + QQQ.Punti.Item(j).TextData.Z) / 2 < Verso Then Verso = (QQQ.Punti.Item(i).TextData.Z + QQQ.Punti.Item(j).TextData.Z) / 2
                        Npuntj = Npuntj + 1
                        P0 = New RoutBase1.clsVec2
                        P0.X = QQQ.Punti.Item(i).TextData.X
                        P0.y = QQQ.Punti.Item(i).TextData.y
                        Punti.Punti.Add(P0)
                    End If 'j
                End If 'k
            Next j
        Next i
        If Npunti > 0 And Npuntj > 0 Then
            ' PRINT "Err imp Interseca": u$ = INPUT$(1)
        End If 'l
        If Npunti = 0 Then Npunti = -Npuntj
        If System.Math.Abs(Npunti) = 4 Then
184:        i1 = 1 : i2 = 2 : i3 = 3 : i4 = 4
            Incrocio()
185:        i1 = 1 : i2 = 3 : i3 = 2 : i4 = 4
            Incrocio()
        End If 'm
    End Sub
    Private Sub Incrocio()
        Linea1 = New RoutBase1.clsLinea2
        Linea2 = New RoutBase1.clsLinea2
        Inters = New RoutBase1.clsVec2
        Linea1.P0 = New RoutBase1.clsVec2 ' Punti.Punti(i1)
        Linea1.p1 = New RoutBase1.clsVec2 'Punti.Punti(i3)
        Linea2.P0 = New RoutBase1.clsVec2 'Punti.Punti(i2)
        Linea2.p1 = New RoutBase1.clsVec2 'Punti.Punti(i4)
        Punti.Punti.Item(i1).TextData.copia(Linea1.P0)
        Punti.Punti.Item(i3).TextData.copia(Linea1.p1)
        Punti.Punti.Item(i2).TextData.copia(Linea2.P0)
        Punti.Punti.Item(i4).TextData.copia(Linea2.p1)
        Linea1.CalcolaDir()
        Linea2.CalcolaDir()
        Res = Linea1.InterRettRett(Linea2, Inters)
        If Not Res And i2 = 2 Then
            '186 SWAP P0(i2), P0(i1)
            Punti.SWAP(i1, i2)
            '     Dummy = P0(i2)
            '     P0(i2) = P0(i1)
            '     P0(i1) = Dummy
        ElseIf Res Then
            If (Punti.Punti.Item(i3).TextData.X - Inters.X) * (Punti.Punti.Item(i1).TextData.X - Inters.X) > 0 Or _
               (Punti.Punti.Item(i3).TextData.y - Inters.y) * (Punti.Punti.Item(i1).TextData.y - Inters.y) > 0 Then
                'SWAP P0(i2), P0(i1)
                Punti.SWAP(i1, i2)
                '        Dummy = P0(i2)
                '        P0(i2) = P0(i1)
                '        P0(i1) = Dummy
            End If
        End If 'n
    End Sub 'f
    Sub DisTubiDir(ByRef Oggetto As Tubi)
        Try
            posspa = Oggetto.GenMem.SwappedPos
            Dim gm As clsGenMem = Oggetto.GenMem
            If CType(gm.posizione.SuChi.GenMem, clsGenMem).Tipo = 12 Then
                SpessPiastra = gm.posizione.SuChi.Spessore
            ElseIf CType(gm.posizione.SuChi.GenMem, clsGenMem).Tipo = 26 Then
                SpessPiastra = CType(gm.posizione.SuChi.GenMem, clsGenMem).posizione.SuChi.Spessore
            End If
            DTub = Oggetto.DiamExt : SpessTub = Oggetto.Spessore
            Aotl = Oggetto.OTL - DTub
            yfmin = Oggetto.yPrimaFila : yfmax = Oggetto.yUltimFila
            If yfmax > 0 And 2 * yfmax < Aotl Then Aotl = 2 * yfmax
            If System.Math.Abs(Oggetto.GenMem.Tipo) = 9 Then
                Aotlm = 2 * yfmin
            End If
            Alung = Oggetto.Lunghezza
            NpassShell = Oggetto.NpassShell
            Direzione.X = 0 : Direzione.y = 0 : Direzione.Z = 1
            prod = posspa.CosDiritta.ProdScalar(Direzione)
            If System.Math.Abs(prod) < TOLER Then
                TubLun(Oggetto)
            Else
                TubSez(Oggetto)
            End If
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Private Sub TubSez(ByVal Oggetto As Tubi)
        z1 = posspa.Origine.Z
        z2 = posspa.Origine.Z + Alung * posspa.CosDiritta.Z
        If z1 * z2 < 0 Then
            If IUNL = 4 Then
                x = posspa.Origine.X '* Scalb!
                y = posspa.Origine.y ' * Scalb!
                Spots = New spot
                Spots.Tipo = 2
                Spots.Quota = 0
                Spots.spicchio.Origin.X = x ' offx! + x!
                Spots.spicchio.Origin.y = y ' offy! + y!
                Spots.spicchio.Direct.X = 1 : Spots.spicchio.Direct.y = 0
                Spots.spicchio.RG = Aotl / 2 '* Scalb!
                Spots.spicchio.RP = 0
                Spots.spicchio.Alfa = 2 * PI
                RegisterSpot(Spots, Oggetto)
                Exit Sub
            End If
            If Oggetto.GenMem.posizione.SuChi.GenMem.Tipo = 26 Then
                Fascio = Oggetto.GenMem.posizione.SuChi
                If Fascio.LayOut Is Nothing Then
                    Fascio.LayOut = New traccia.clsTracciatura
                    Fascio.LayOut.DoveMotore = Motore
                    Fascio.LayOut.DoveRoutines = Funzioni.DisRut
                    'Funzioni.DisRut.Init200 Inizio.Archdir
                    icome = FunzLibgra.FileDes("INP")
                    Fascio.LayOut.Esegui(2, icome)
                End If
                Funzioni.DisRut.refere((posspa.Origine.X), (posspa.Origine.y), 0)
                Funzioni.DisRut.Init200((Inizio.Archdir))
                trk = FunzLibgra.FileDes("TRK")
                If Not IO.File.Exists(trk) Then
                    MsgBox(trk)
                Else
                    Fascio.LayOut.DisTrk(trk, "", 0, 1)
                    '  Fascio.LayOut.Class_Terminate()
                    'UPGRADE_NOTE: È possibile che l'oggetto Fascio.LayOut non venga eliminato finché non venga raccolto nel Garbage Collector. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1029"'
                    ' Fascio.LayOut = Nothing
                    Funzioni.DisRut.DoveDisegno = frmDistinta.DefInstance.pictAssieme
                End If
            End If
        End If
    End Sub
    Private Sub TubLun(ByVal Oggetto As Tubi)
        Verso = posspa.Origine.Z
        If IUNL = 4 Then
            SpotsTub(Oggetto)
            Exit Sub
        End If
        If Verso < -Aotl / 2 Then Exit Sub
        If IUNL = 0 Then
            xSmin = -Alung / 5 : ySmin = 1.2 * (-Aotl / 2) : xSmax = 1.2 * Alung
            If System.Math.Abs(Oggetto.GenMem.Tipo) = 9 Then xSmax = xSmax + 1.2 * Aotl / 2
            ySmax = -ySmin
            If Not Funzioni.DisRut.Scala(xSmin, xSmax, ySmin, ySmax) Then Exit Sub
        End If
        If Verso > Aotl / 2 Then ' fascio in vista
            Call Infilata(Oggetto, Verso, InMezzo)
            If InMezzo > 1 Then Exit Sub
            If InMezzo = 1 Then
                Call Funzioni.DisRut.ctrait(3, 0.1)
            Else
                Call Funzioni.DisRut.ctrait(0, 0.1)
            End If
        End If
        Dim i As Short
        Dim nod As OggList.NodeP = ApparProv.Elementi.nodeHead.Next
        While Not nod Is Nothing
            Ogg = nod.TextData
            If System.Math.Abs(Ogg.GenMem.Tipo) = 19 Then
                Ogg4 = Ogg
                Ddiaf = Ogg4.DiamExt
                pdiaf = Ogg4.Passo
                pdiaf1 = Ogg4.Passo1
                n1 = Ogg4.NumTipoA '(4).Dati(11) \ 100
                n2 = Ogg4.NumTipoB
                n = n1 + n2
                t = Ogg4.Spessore '.Dati(4)
                If Ogg4.TipoDiafr < 1 Then Ogg4.TipoDiafr = 1
                TipoDiaf = Ogg4.TipoDiafr
                PercTaglio = Ogg4.Percento
                VerticalTaglio = Ogg4.DirezVert
                InPiastra = Ogg4.GenMem.posizione.Origine.ProdScalar((Ogg4.GenMem.posizione.CosDiritta)) - Oggetto.GenMem.posizione.Origine.ProdScalar((Oggetto.GenMem.posizione.CosDiritta))
                PrimoTipo = Ogg4.SottoTipo
                Exit While
            End If
            nod = nod.Next
        End While
        For j = 1 To 2
            Aotl1 = Aotl
            If j = 2 Then Aotl1 = Aotlm
            For i = 0 To n
                k = 0
                InizFine(Oggetto)
                If j = 1 Or (j = 2 And i = n And System.Math.Abs(Oggetto.GenMem.Tipo) = 9) Then
                    Cil = New Cilindro
                    Cil.GenMem.Tipo = Oggetto.GenMem.Tipo
                    Cil.Lunghezza = Fine - Iniz
                    Cil.Diametro = DTub - 2 * SpessTub
                    Cil.SpessBase = SpessTub
                    Oggetto.GenMem.posizione.Copia((Cil.GenMem.posizione))
                    'Cil.GenMem.posizione.Quota = "Ne"
                    If InStr(Oggetto.GenMem.posizione.Quota, "St") > 0 Then Oggetto.GenMem.posizione.Quota = "-3"
                    Cil.GenMem.posizione.Quota = Str(Iniz - Val(Oggetto.GenMem.posizione.Quota))
                    'sottratta la sporgenza
                    Cil.GenMem.posizione.Raggio = Str(Aotl1 / 2)
                    Cil.GenMem.posizione.Anomal = "+N"
                    AggCoordN((Cil.GenMem))
                    SwapCoordN((Cil.GenMem))
                    Call DisCil(1, Cil)
                    k = 1
                    InizFine(Oggetto)
                    Cil.Lunghezza = FineS - Iniz
                    Cil.GenMem.posizione.Anomal = "-N"
                    AggCoordN((Cil.GenMem))
                    SwapCoordN((Cil.GenMem))
                    Call DisCil(1, Cil)
                End If
            Next
        Next j
        '------disegno curve
        If System.Math.Abs(Oggetto.GenMem.Tipo) = 9 Then
            PuntiS.Inizia(1)
            PuntiS.Punti.Item(0).TextData.X = 0
            PuntiS.Punti.Item(0).TextData.y = 0
            prod = Oggetto.GenMem.posizione.CosDiritta.ProdScalar(Oggetto.GenMem.posizione.SuChi.GenMem.posizione.CosDiritta)
            If Oggetto.GenMem.Tipo < 0 Then
                prod = Oggetto.GenMem.posizione.SuChi.GenMem.posizione.CosDiritta.ProdScalar(Oggetto.GenMem.posizione.SuChi.GenMem.posizione.SuChi.GenMem.posizione.CosDiritta)
            End If
            'c'è un errore dopo aggiunge due volte 3
            PuntiS.Punti.Item(1).TextData.X = Alung - 2 * Oggetto.GenMem.posizione.QuotaR * prod
            PuntiS.Punti.Item(1).TextData.y = 0
            Call TrasfGen(posspa, PuntiS, PuntiD, 0, 1, True)
            If IUNL >= 2 Then
                Direz.X = 1 : Direz.y = 0
                Direz1.X = posspa.CosDiritta.X
                Direz1.y = posspa.CosDiritta.y
                GlobalRoutines.ComposDir(Direz, Direz1)
            End If
            For j = 1 To 2
                Aotl1 = Aotl
                If j = 2 Then Aotl1 = Aotlm
                For i = 1 To 4
                    Select Case i
                        Case 1 : RagG = (Aotl1 + DTub) / 2
                        Case 2 : RagG = ((Aotl1 + DTub) / 2 - SpessTub)
                        Case 3 : RagG = (Aotl1 - DTub) / 2
                        Case 4 : RagG = ((Aotl1 - DTub) / 2 + SpessTub)
                    End Select
                    ArcoGraf(PuntiS.Punti.Item(1).TextData, RagG, Direz, PI, IUNL - 1) 'era (2)
                Next
            Next j
        End If
        '-----------------------------
        '------disegno diaframmi---
        '   PuntiS.inizia 5: PuntiD.inizia 5
        '281 For i = 0 To n
        'GoSub InizFine
        'If i > 0 Then
        '282 PuntiS.Punti(1).X = 0:               PuntiS.Punti(1).Y = 0
        '    PuntiS.Punti(2).X = Iniz - t:       If NpassShell < 2 Then PuntiS.Punti(2).Y = 0 Else PuntiS.Punti(2).Y = t / 2
        '    PuntiS.Punti(3).X = PuntiS.Punti(2).X:         PuntiS.Punti(3).Y = Ddiaf / 2
        '    PuntiS.Punti(4).X = PuntiS.Punti(2).X + t:     PuntiS.Punti(4).Y = PuntiS.Punti(3).Y
        '    PuntiS.Punti(5).X = PuntiS.Punti(4).X:         PuntiS.Punti(5).Y = PuntiS.Punti(2).Y
        '    PuntiD.Punti(1).X = PuntiS.Punti(1).X
        '    PuntiD.Punti(1).Y = PuntiS.Punti(1).Y
        '    For j = 2 To 5
        '       PuntiD.Punti(j).X = PuntiS.Punti(j).X:     PuntiD.Punti(j).Y = -PuntiS.Punti(j).Y
        '    Next
        '284 Call TrasfGen(posspa, PuntiS, PuntiD, 0, 4, False)
        '286 PuntiS.SpezzGraf 2, 5, Funzioni.DisRut: PuntiD.SpezzGraf 2, 5, Funzioni.DisRut
        'End If
        'Next
        '--------------------------
    End Sub
    Private Sub SpotsTub(ByVal Oggetto As Tubi)
        MakeCorners(Rett, Aotl, Alung)
        TrasfRett(Rett, 1.0!, Alung / 2, -Aotl / 2)
        TrasfRett(Rett, 1.0!, (posspa.Origine.X), (posspa.Origine.y))
        Direz1.X = posspa.CosDiritta.X : Direz1.y = posspa.CosDiritta.y
        RotRett(Rett, (posspa.Origine.X), (posspa.Origine.y), GlobalRoutines.arco((Direz1.X), (Direz1.y)))
        'TrasfRett Rett, Scalb!, offx!, offy!
        Spots = New spot
        Spots.Tipo = 1
        Spots.Quota = Verso
        Spots.Quadro.TopLeft.X = GlobalRoutines.Minimo(Rett1.Corners(1).X, Rett1.Corners(2).X, Rett1.Corners(3).X, Rett1.Corners(4).X)
        Spots.Quadro.TopLeft.y = GlobalRoutines.Minimo(Rett1.Corners(1).y, Rett1.Corners(2).y, Rett1.Corners(3).y, Rett1.Corners(4).y)
        Spots.Quadro.Botrigt.X = GlobalRoutines.Massimo(Rett1.Corners(1).X, Rett1.Corners(2).X, Rett1.Corners(3).X, Rett1.Corners(4).X)
        Spots.Quadro.Botrigt.y = GlobalRoutines.Massimo(Rett1.Corners(1).y, Rett1.Corners(2).y, Rett1.Corners(3).y, Rett1.Corners(4).y)
        RegisterSpot(Spots, Oggetto)
    End Sub
    Private Sub InizFine(ByVal Oggetto As Tubi)
        Fine = i * pdiaf + pdiaf1 + SpessPiastra + Val(Oggetto.GenMem.posizione.Quota) 'che sarebbe la sporgenza
        Iniz = Fine - pdiaf
        If i = n Then Fine = Alung
        If i = 0 Then Iniz = 0
        If i < n Then Fine = Fine - t / 2
        If i > 0 Then Iniz = Iniz + t / 2
        FineS = Fine
        If i < n Then
            Select Case TipoDiaf
                Case 1, 2
                    If j = 1 Then
                        If ((i + PrimoTipo - 1) Mod 2 = 0 And k = 0) Or ((i + PrimoTipo - 1) Mod 2 = 1 And k = 1) Then
                            Fine = Fine + t
                            FineS = Fine '+ t
                        Else
                            FineS = Fine
                        End If
                    Else
                        FineS = Fine
                    End If
                Case 3
                    'da fare
            End Select
        End If
    End Sub

    Sub SpotPia(ByRef Ri As Single, ByRef Re As Single)
    End Sub
    Sub PiasInVista(ByRef GenMem As clsGenMem, ByRef Mode As Short, ByRef t As Single, ByRef Adim As Single) 'Mode=1 Piastra
        Dim z2, z1, Verso As Single
        Dim y, x, Re As Single
        Dim InMezzo As Short
        Dim Spots As spot
        Dim posspa As Posizione
        posspa = GenMem.SwappedPos
        Try
            z1 = posspa.Origine.Z
            z2 = posspa.Origine.Z + t * posspa.CosDiritta.Z
            If z1 * z2 < 0 Then Verso = 0 Else Verso = (z1 + z2) / 2
            If Verso < 0 Then Exit Sub
            x = posspa.Origine.X ' * Scalb!
            y = posspa.Origine.y ' * Scalb!
            Re = Adim / 2 '* Scalb!
            If IUNL < 4 Then
                Call Infilata((GenMem.Parent), Verso, InMezzo)
                If InMezzo > 1 Then Exit Sub
                If InMezzo = 1 Then Call Funzioni.DisRut.ctrait(3, 0.1)
                'Call Funzioni.DisRut.refere(offx!, offy!, 0)
                Call Funzioni.DisRut.cerc(x, y, Re)
                Call Funzioni.DisRut.refabs()
                Call Funzioni.DisRut.ctrait(0, 0.1)
            End If
            If IUNL = 4 Then
                Spots = New spot
                Spots.Tipo = 2
                Spots.Quota = Verso
                Spots.spicchio.Origin.X = x ' offx! + x!
                Spots.spicchio.Origin.y = y 'offy! + y!
                Spots.spicchio.RG = Re
                Spots.spicchio.RP = 0
                Spots.spicchio.Alfa = 2 * PI
                RegisterSpot(Spots, (GenMem.Parent))
            End If
        Catch e As Exception
            MessageBox.Show(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Sub DisPia(ByRef Oggetto As Piastrone)
        posspa = Oggetto.GenMem.SwappedPos
        XvecP = Oggetto.TipoMat
        Oggetto.Traduci(Look)
        racc = Oggetto.B1 : If Oggetto.B2 < racc Then racc = Oggetto.B2
        If racc < 38 Then
            racc = 10
        Else
            racc = CShort(racc / 4)
        End If
        If racc > 38 Then racc = 38
        With Look
            If .H2 < racc Then racc = 0
            If Oggetto.SottoTipo < 3 And .H1 < racc Then racc = 0
        End With
        Direzione.X = 0 : Direzione.y = 0 : Direzione.Z = 1
        prod = posspa.CosDiritta.ProdScalar(Direzione)
        If System.Math.Abs(prod) > TOLER Then Call PiasInVista((Oggetto.GenMem), 1, (Oggetto.Spessore), (Oggetto.DiamExt)) : Exit Sub
        If IUNL = 0 Then
            With Look
                xSmin = -(Oggetto.Spessore + .H1 + .H2) / 10 : ySmin = -0.6 * Oggetto.DiamExt : xSmax = 1.2 * (Oggetto.Spessore + .H1 + .H2) : ySmax = -ySmin
            End With
            If Not Funzioni.DisRut.Scala(xSmin, xSmax, ySmin, ySmax) Then Exit Sub
        End If
        Call Apparecchio.CercaBul(Oggetto, DiamB, DbulB)
        Look.BC = DiamB : Look.DFor = DbulB
        Call CercaTubi(Oggetto, OTL, DTub, yfmin, yfmax)
        Dtub0 = DTub : Dtub1 = DTub
        BCsave = Look.BC
        If Oggetto.SottoTipo = 5 Then CerBoc(Oggetto) Else jB = 0
        Look.BC = BCsave
        If yfmax > 0 And 2 * yfmax < OTL Then OTL = 2 * yfmax
        Look.DFor = Look.DFor * 1.2
        If Look.BC > Oggetto.DiamExt - Look.DFor Then Look.BC = 0 : Look.DFor = 0
        If Look.BC = 0 Then
            If Oggetto.SottoTipo < 3 Then
                Look.BC = Oggetto.DiamExt - 2.0! * (racc + Oggetto.B1) 'dovrebbe essere SBAGLIATO
            ElseIf Oggetto.SottoTipo = 3 Or Oggetto.SottoTipo = 7 Then
                Look.BC = (Oggetto.DiamExt + Look.B4) / 2
            Else
                Look.BC = (Oggetto.DiamExt + Look.B1) / 2
            End If
        End If
        If jB > 0 Then
            For j = 1 To jB
                iDir = 1
                'UPGRADE_ISSUE: L'istruzione GoSub non è supportata. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1014"'
                Subdelta()
                If DELTAY > 0 Then
                    Dtub0 = DBuco(j)
                    OTL = 2 * DELTAY - Dtub0
                    Exit For
                End If
            Next
        End If
        If OTL > Oggetto.DiamExt Then OTL = 0
        If OTL = 0 Then OTL = Oggetto.DiamExt / 2
        If Oggetto.SottoTipo < 3 Then HH = Look.H1 Else HH = 0
        Dim PuntiS As New RoutBase1.clsPunti
        Dim PuntiD As New RoutBase1.clsPunti
        Verso = posspa.Origine.Z
        If Verso > Oggetto.DiamExt / 2 Then
            Dtub0 = 0
            Select Case Oggetto.SottoTipo
                Case 1 '"2 codoli esterni"
                Case 2 ' "1 int. / 1 est."
                Case 3 ' "saldata LM + bulloni"
                Case 4 ' "senza cod., gr.Sx/Dx"
                    If IUNL = 2 Then
                        CercaFlangioni(Oggetto, Fl1, Fl2)
                        SwapCoordN((Fl1.GenMem))
                        SwapCoordN((Fl2.GenMem))
                        PuntiS.Inizia(2) : PuntiD.Inizia(2)
                        With Fl1.GenMem.SwappedPos
                            PuntiS.Punti0(0).X = .Origine.X + (Fl1.SpessBase + Fl1.H) * .CosDiritta.X + Oggetto.DiamExt / 2 * .CosDiritta.y
                            PuntiS.Punti0(0).y = .Origine.y - (Fl1.SpessBase + Fl1.H) * .CosDiritta.y + Oggetto.DiamExt / 2 * .CosDiritta.X
                            PuntiD.Punti0(0).X = .Origine.X + (Fl1.SpessBase + Fl1.H) * .CosDiritta.X - Oggetto.DiamExt / 2 * .CosDiritta.y
                            PuntiD.Punti0(0).y = .Origine.y - (Fl1.SpessBase + Fl1.H) * .CosDiritta.y - Oggetto.DiamExt / 2 * .CosDiritta.X
                        End With
                        prod = Fl1.GenMem.SwappedPos.CosDiritta.ProdScalar((Fl2.GenMem.SwappedPos.CosDiritta))
                        With Fl2.GenMem.SwappedPos
                            PuntiS.Punti0(1).X = .Origine.X + (Fl2.SpessBase + Fl2.H) * .CosDiritta.X + System.Math.Sign(prod) * Oggetto.DiamExt / 2 * .CosDiritta.y
                            PuntiS.Punti0(1).y = .Origine.y - (Fl2.SpessBase + Fl2.H) * .CosDiritta.y + System.Math.Sign(prod) * Oggetto.DiamExt / 2 * .CosDiritta.X
                            PuntiD.Punti0(1).X = .Origine.X + (Fl2.SpessBase + Fl2.H) * .CosDiritta.X - System.Math.Sign(prod) * Oggetto.DiamExt / 2 * .CosDiritta.y
                            PuntiD.Punti0(1).y = .Origine.y - (Fl2.SpessBase + Fl2.H) * .CosDiritta.y - System.Math.Sign(prod) * Oggetto.DiamExt / 2 * .CosDiritta.X
                        End With
                        PuntiS.SpezzGraf(0, 1, Funzioni.DisRut)
                        PuntiD.SpezzGraf(0, 1, Funzioni.DisRut)
                        Exit Sub
                    End If
                Case 5 ' "s.cod. e 1/2 gr.a Sx"
                Case 6 ' "sandwitch+collar blt"
                Case 7 ' "saldata LC + bulloni"
            End Select
        End If
        With Look
            PuntiS.Inizia(29) : PuntiD.Inizia(29)
            PuntiS.Punti.Item(0).TextData.X = HH
            PuntiS.Punti.Item(0).TextData.y = 0
            PuntiS.Punti.Item(1).TextData.X = PuntiS.Punti.Item(0).TextData.X
            PuntiS.Punti.Item(1).TextData.y = (OTL - Dtub0) / 2
            PuntiS.Punti.Item(2).TextData.X = PuntiS.Punti.Item(0).TextData.X
            PuntiS.Punti.Item(2).TextData.y = (OTL + Dtub0) / 2
            If PuntiS.Punti.Item(1).TextData.y * PuntiS.Punti.Item(2).TextData.y < 0 Then
                PuntiS.Punti.Item(0).TextData.X = PuntiS.Punti.Item(2).TextData.X
                PuntiS.Punti.Item(0).TextData.y = PuntiS.Punti.Item(2).TextData.y
                PuntiS.Punti.Item(1).TextData.X = PuntiS.Punti.Item(2).TextData.X
                PuntiS.Punti.Item(1).TextData.y = PuntiS.Punti.Item(2).TextData.y
            End If
            If Oggetto.SottoTipo < 3 Then
                PuntiS.Punti.Item(3).TextData.X = PuntiS.Punti.Item(0).TextData.X
                PuntiS.Punti.Item(3).TextData.y = (.BC - .DFor) / 2
                PuntiS.Punti.Item(4).TextData.X = PuntiS.Punti.Item(0).TextData.X
                PuntiS.Punti.Item(4).TextData.y = (.BC + .DFor) / 2
                PuntiS.Punti.Item(5).TextData.X = PuntiS.Punti.Item(0).TextData.X
                PuntiS.Punti.Item(5).TextData.y = Oggetto.DiamExt / 2 - Oggetto.B1 - racc
                PuntiS.Punti.Item(6).TextData.X = PuntiS.Punti.Item(0).TextData.X - racc
                PuntiS.Punti.Item(6).TextData.y = Oggetto.DiamExt / 2 - Oggetto.B1
            ElseIf Oggetto.SottoTipo = 4 Then
                PuntiS.Punti.Item(3).TextData.X = PuntiS.Punti.Item(0).TextData.X
                PuntiS.Punti.Item(3).TextData.y = Oggetto.B1 / 2
                PuntiS.Punti.Item(4).TextData.X = .H1
                PuntiS.Punti.Item(4).TextData.y = PuntiS.Punti.Item(3).TextData.y
                PuntiS.Punti.Item(5).TextData.X = PuntiS.Punti.Item(4).TextData.X
                PuntiS.Punti.Item(5).TextData.y = (.BC - .DFor) / 2
                PuntiS.Punti.Item(6).TextData.X = PuntiS.Punti.Item(4).TextData.X
                PuntiS.Punti.Item(6).TextData.y = (.BC + .DFor) / 2
            ElseIf Oggetto.SottoTipo = 3 Or Oggetto.SottoTipo = 7 Then
                PuntiS.Punti.Item(3).TextData.X = PuntiS.Punti.Item(0).TextData.X
                PuntiS.Punti.Item(3).TextData.y = Oggetto.B1 / 2
                PuntiS.Punti.Item(4).TextData.X = .H1
                PuntiS.Punti.Item(4).TextData.y = PuntiS.Punti.Item(3).TextData.y
                PuntiS.Punti.Item(5).TextData.X = .H1
                PuntiS.Punti.Item(5).TextData.y = Oggetto.B4 / 2
                PuntiS.Punti.Item(6).TextData.X = .H4
                PuntiS.Punti.Item(6).TextData.y = PuntiS.Punti.Item(5).TextData.y
                PuntiS.Punti.Item(7).TextData.X = PuntiS.Punti.Item(6).TextData.X
                PuntiS.Punti.Item(7).TextData.y = (.BC - .DFor) / 2
                PuntiS.Punti.Item(8).TextData.X = PuntiS.Punti.Item(6).TextData.X
                PuntiS.Punti.Item(8).TextData.y = (.BC + .DFor) / 2
            ElseIf Oggetto.SottoTipo > 4 Then
                PuntiS.Punti.Item(3).TextData.X = PuntiS.Punti.Item(0).TextData.X
                PuntiS.Punti.Item(3).TextData.y = Oggetto.B2 / 2
                PuntiS.Punti.Item(4).TextData.X = .H2
                PuntiS.Punti.Item(4).TextData.y = PuntiS.Punti.Item(3).TextData.y
                PuntiS.Punti.Item(5).TextData.X = PuntiS.Punti.Item(4).TextData.X
                PuntiS.Punti.Item(5).TextData.y = Oggetto.B1 / 2
                PuntiS.Punti.Item(6).TextData.X = .H1
                PuntiS.Punti.Item(6).TextData.y = PuntiS.Punti.Item(5).TextData.y
                PuntiS.Punti.Item(7).TextData.X = PuntiS.Punti.Item(6).TextData.X
                PuntiS.Punti.Item(7).TextData.y = (.BC - .DFor) / 2
                PuntiS.Punti.Item(8).TextData.X = PuntiS.Punti.Item(6).TextData.X
                PuntiS.Punti.Item(8).TextData.y = (.BC + .DFor) / 2
            End If
            If Oggetto.SottoTipo < 4 Then HH = 0 Else HH = .H1
            'siamo in cima----------------------------------------
            If Oggetto.SottoTipo = 4 Or Oggetto.SottoTipo < 3 Then
                PuntiS.Punti.Item(7).TextData.X = HH
                PuntiS.Punti.Item(7).TextData.y = PuntiS.Punti.Item(6).TextData.y
                PuntiS.Punti.Item(8).TextData.X = PuntiS.Punti.Item(7).TextData.X
                PuntiS.Punti.Item(8).TextData.y = Oggetto.DiamExt / 2
            End If
            PuntiS.Punti.Item(9).TextData.X = PuntiS.Punti.Item(8).TextData.X
            PuntiS.Punti.Item(9).TextData.y = Oggetto.DiamExt / 2
            '----------------------------------------------------
            Select Case Oggetto.SottoTipo
                Case 1 '2 codoli esterni
                    HH = Oggetto.Spessore + .H1 + .H2
                    .BC = Oggetto.DiamExt
                Case 2 '1 int/1 ext
                    HH = .H1 + Oggetto.H3
                Case 3, 7 '1 int + bulloni
                    HH = .H1 + Oggetto.H3
                Case 4 's.cod. Sx/Dx
                    HH = Oggetto.Spessore - .H2
                Case 5 's.cod 2 grad Sx
                    HH = Oggetto.Spessore - .H2
                Case 6 'sandwitch + collar bolts
                    For i = 0 To 9
                        PuntiS.Punti.Item(21 - i).TextData.y = PuntiS.Punti.Item(i).TextData.y
                        PuntiS.Punti.Item(21 - i).TextData.X = Oggetto.Spessore - PuntiS.Punti.Item(i).TextData.X
                    Next
                    PuntiS.Punti.Item(20).TextData.X = PuntiS.Punti.Item(19).TextData.X
                    PuntiS.Punti.Item(20).TextData.y = PuntiS.Punti.Item(19).TextData.y
                    k = 0
                    GoTo Cont6
            End Select
            Select Case XvecP '!!!!!!!aggiunta
                Case 2, 3, 4 'monopl,monoriv,monol
                    'HH = HH + Oggetto.SpessRive
                Case 5, 6, 7
                    'HH = HH + 2 * Oggetto.SpessRive
            End Select '!!!!!!!!!
            If Oggetto.SottoTipo = 4 Or Oggetto.SottoTipo < 3 Then
                PuntiS.Punti.Item(9).TextData.X = HH
                PuntiS.Punti.Item(9).TextData.y = PuntiS.Punti.Item(8).TextData.y
                PuntiS.Punti.Item(10).TextData.X = PuntiS.Punti.Item(9).TextData.X
                PuntiS.Punti.Item(10).TextData.y = (.BC + .DFor) / 2
                PuntiS.Punti.Item(11).TextData.X = PuntiS.Punti.Item(9).TextData.X
                PuntiS.Punti.Item(11).TextData.y = (.BC - .DFor) / 2
            ElseIf Oggetto.SottoTipo = 3 Or Oggetto.SottoTipo = 7 Then
                PuntiS.Punti.Item(10).TextData.X = HH
                PuntiS.Punti.Item(10).TextData.y = PuntiS.Punti.Item(9).TextData.y
                PuntiS.Punti.Item(11).TextData.X = PuntiS.Punti.Item(10).TextData.X
                PuntiS.Punti.Item(11).TextData.y = (.BC + .DFor) / 2
                PuntiS.Punti.Item(12).TextData.X = PuntiS.Punti.Item(10).TextData.X
                PuntiS.Punti.Item(12).TextData.y = (.BC - .DFor) / 2
            Else
                PuntiS.Punti.Item(10).TextData.X = HH
                PuntiS.Punti.Item(10).TextData.y = PuntiS.Punti.Item(9).TextData.y
                PuntiS.Punti.Item(11).TextData.X = PuntiS.Punti.Item(10).TextData.X
                PuntiS.Punti.Item(11).TextData.y = (.BC + .DFor) / 2
                PuntiS.Punti.Item(12).TextData.X = PuntiS.Punti.Item(10).TextData.X
                PuntiS.Punti.Item(12).TextData.y = (.BC - .DFor) / 2
            End If
            If Oggetto.SottoTipo = 1 Then
                PuntiS.Punti.Item(12).TextData.X = PuntiS.Punti.Item(11).TextData.X
                PuntiS.Punti.Item(12).TextData.y = PuntiS.Punti.Item(11).TextData.y
                PuntiS.Punti.Item(13).TextData.X = PuntiS.Punti.Item(12).TextData.X
                PuntiS.Punti.Item(13).TextData.y = PuntiS.Punti.Item(12).TextData.y
            ElseIf Oggetto.SottoTipo >= 5 And Oggetto.SottoTipo < 7 Then
                PuntiS.Punti.Item(13).TextData.X = PuntiS.Punti.Item(12).TextData.X
                PuntiS.Punti.Item(13).TextData.y = PuntiS.Punti.Item(12).TextData.y
            ElseIf Oggetto.SottoTipo = 3 Or Oggetto.SottoTipo = 7 Then
                PuntiS.Punti.Item(13).TextData.X = PuntiS.Punti.Item(10).TextData.X
                PuntiS.Punti.Item(13).TextData.y = Oggetto.B3 / 2 + Oggetto.B2 + racc
                PuntiS.Punti.Item(14).TextData.X = PuntiS.Punti.Item(13).TextData.X + racc
                PuntiS.Punti.Item(14).TextData.y = PuntiS.Punti.Item(13).TextData.y - racc
            ElseIf Oggetto.SottoTipo < 3 Then
                PuntiS.Punti.Item(12).TextData.X = PuntiS.Punti.Item(9).TextData.X
                PuntiS.Punti.Item(12).TextData.y = Oggetto.B3 / 2 + Oggetto.B2 + racc
                PuntiS.Punti.Item(13).TextData.X = PuntiS.Punti.Item(12).TextData.X + racc
                PuntiS.Punti.Item(13).TextData.y = PuntiS.Punti.Item(12).TextData.y - racc
            Else
                PuntiS.Punti.Item(12).TextData.X = PuntiS.Punti.Item(9).TextData.X
                PuntiS.Punti.Item(12).TextData.y = Oggetto.B2 / 2
                PuntiS.Punti.Item(13).TextData.X = Oggetto.Spessore
                PuntiS.Punti.Item(13).TextData.y = PuntiS.Punti.Item(12).TextData.y
            End If
            If Oggetto.SottoTipo = 3 Or Oggetto.SottoTipo = 7 Then
                HH = Oggetto.Spessore + .H2
                PuntiS.Punti.Item(15).TextData.X = HH
                PuntiS.Punti.Item(15).TextData.y = PuntiS.Punti.Item(14).TextData.y
                PuntiS.Punti.Item(16).TextData.X = PuntiS.Punti.Item(15).TextData.X
                PuntiS.Punti.Item(16).TextData.y = Oggetto.B3 / 2
                HH = Oggetto.Spessore + racc
                PuntiS.Punti.Item(17).TextData.X = HH
                PuntiS.Punti.Item(17).TextData.y = PuntiS.Punti.Item(16).TextData.y
                HH = Oggetto.Spessore
                PuntiS.Punti.Item(18).TextData.X = HH
                PuntiS.Punti.Item(18).TextData.y = Oggetto.B3 / 2 - racc
            ElseIf Oggetto.SottoTipo < 3 Then
545:            HH = .H1 + Oggetto.Spessore + .H2
                PuntiS.Punti.Item(14).TextData.X = HH
                PuntiS.Punti.Item(14).TextData.y = PuntiS.Punti.Item(13).TextData.y
                PuntiS.Punti.Item(15).TextData.X = PuntiS.Punti.Item(14).TextData.X
                PuntiS.Punti.Item(15).TextData.y = Oggetto.B3 / 2
                HH = .H1 + Oggetto.Spessore + racc
                PuntiS.Punti.Item(16).TextData.X = HH
                PuntiS.Punti.Item(16).TextData.y = PuntiS.Punti.Item(15).TextData.y
                HH = .H1 + Oggetto.Spessore
                PuntiS.Punti.Item(17).TextData.X = HH
                PuntiS.Punti.Item(17).TextData.y = Oggetto.B3 / 2 - racc
            Else
                For k = 14 To 17
                    PuntiS.Punti.Item(k).TextData.X = PuntiS.Punti.Item(13).TextData.X
                    PuntiS.Punti.Item(k).TextData.y = PuntiS.Punti.Item(13).TextData.y
                Next
            End If
            k = 0 : If Oggetto.SottoTipo = 3 Or Oggetto.SottoTipo = 7 Then k = 1
            PuntiS.Punti.Item(18 + k).TextData.X = PuntiS.Punti.Item(17 + k).TextData.X
            PuntiS.Punti.Item(18 + k).TextData.y = (OTL + Dtub0) / 2
            PuntiS.Punti.Item(19 + k).TextData.X = PuntiS.Punti.Item(17 + k).TextData.X
            PuntiS.Punti.Item(19 + k).TextData.y = (OTL - Dtub0) / 2
            PuntiS.Punti.Item(20 + k).TextData.X = PuntiS.Punti.Item(17 + k).TextData.X
            PuntiS.Punti.Item(20 + k).TextData.y = 0
            If PuntiS.Punti.Item(18 + k).TextData.y * PuntiS.Punti.Item(19 + k).TextData.y < 0 Then
                PuntiS.Punti.Item(20 + k).TextData.X = PuntiS.Punti.Item(18 + k).TextData.X
                PuntiS.Punti.Item(20 + k).TextData.y = PuntiS.Punti.Item(18 + k).TextData.y
                PuntiS.Punti.Item(19 + k).TextData.X = PuntiS.Punti.Item(18 + k).TextData.X
                PuntiS.Punti.Item(19 + k).TextData.y = PuntiS.Punti.Item(18 + k).TextData.y
            End If
            '--------centri raccordi
Cont6:      If k = 0 Then
                PuntiS.Punti.Item(21).TextData.X = PuntiS.Punti.Item(6).TextData.X
                PuntiS.Punti.Item(21).TextData.y = PuntiS.Punti.Item(5).TextData.y
            End If
            PuntiS.Punti.Item(22).TextData.X = PuntiS.Punti.Item(13 + k).TextData.X
            PuntiS.Punti.Item(22).TextData.y = PuntiS.Punti.Item(12 + k).TextData.y
            PuntiS.Punti.Item(23).TextData.X = PuntiS.Punti.Item(16 + k).TextData.X
            PuntiS.Punti.Item(23).TextData.y = PuntiS.Punti.Item(17 + k).TextData.y
            PuntiS.Punti.Item(24).TextData.X = 0
            PuntiS.Punti.Item(24).TextData.y = 0 'origine locale
            'asse fori
            PuntiS.Punti.Item(25).TextData.X = -Oggetto.Spessore / 10
            PuntiS.Punti.Item(25).TextData.y = .BC / 2
            PuntiS.Punti.Item(26).TextData.X = PuntiS.Punti.Item(15).TextData.X + Oggetto.Spessore / 10
            PuntiS.Punti.Item(26).TextData.y = .BC / 2
            Alfa = PI / 2
        End With
        Npunti = 26
        Rivestimento(Oggetto)
        For i = 0 To Npunti
            PuntiD.Punti.Item(i).TextData.X = PuntiS.Punti.Item(i).TextData.X
            PuntiD.Punti.Item(i).TextData.y = -PuntiS.Punti.Item(i).TextData.y
        Next
        If jB > 0 Then BucoBoc(Oggetto)
        Call TrasfGen(posspa, PuntiS, PuntiD, 24, Npunti, False)
        'racc = racc * Scalb!
        If IUNL = 1 Then Exit Sub
        If IUNL = 4 Then
            Spots = New spot
            Spots.Tipo = 1
            Spots.Quadro.TopLeft.X = GlobalRoutines.Minimo(PuntiS.Punti.Item(14).TextData.X, PuntiD.Punti.Item(7).TextData.X)
            Spots.Quadro.TopLeft.y = GlobalRoutines.Minimo(PuntiS.Punti.Item(14).TextData.y, PuntiD.Punti.Item(7).TextData.y)
            Spots.Quadro.Botrigt.X = GlobalRoutines.Massimo(PuntiS.Punti.Item(14).TextData.X, PuntiD.Punti.Item(7).TextData.X)
            Spots.Quadro.Botrigt.y = GlobalRoutines.Massimo(PuntiS.Punti.Item(14).TextData.y, PuntiD.Punti.Item(7).TextData.y)
            Spots.Quota = 0
            RegisterSpot(Spots, Oggetto)
            Exit Sub
        End If
        If Verso < -Oggetto.DiamExt / 2 Then Exit Sub
        Call DisSpezPia((Oggetto.SottoTipo), Look.DFor, Dtub0, PuntiS, Npunti)
        Call DisSpezPia((Oggetto.SottoTipo), Look.DFor, Dtub1, PuntiD, Npunti)
        DirR.X = posspa.CosDiritta.X
        DirR.y = posspa.CosDiritta.y
        Select Case Oggetto.SottoTipo
            Case 1
                Arco1(PuntiS, PuntiD)
                Arco3(PuntiS, PuntiD)
            Case 2
                Arco1(PuntiS, PuntiD)
                Arco2(PuntiS, PuntiD)
                Arco3(PuntiS, PuntiD)
            Case 3, 7
                Arco2(PuntiS, PuntiD)
                Arco3(PuntiS, PuntiD)
            Case 4, 5
        End Select
        If IUNL = 3 Then Exit Sub
    End Sub
    Private Sub Arco1(ByVal PuntiS As clsPunti, ByVal PuntiD As clsPunti)
        Try
            Direz1.X = System.Math.Cos(Alfa / 2) : Direz2.X = Direz1.X
            '???Direz1.y = -Sin(Alfa / 2):       Direz2.y = -Direz1.y
            Direz1.y = System.Math.Sin(Alfa / 2) : Direz2.y = -Direz1.y
            If IUNL >= 2 Then
                GlobalRoutines.ComposDir(Direz1, DirR)
                GlobalRoutines.ComposDir(Direz2, DirR)
            End If
            ArcoGraf(PuntiS.Punti.Item(21).TextData, racc, Direz1, Alfa, IUNL - 1)
            ArcoGraf(PuntiD.Punti.Item(21).TextData, racc, Direz2, Alfa, IUNL - 1)
        Catch e As Exception
            MessageBox.Show(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Private Sub Arco2(ByVal PuntiS As clsPunti, ByVal PuntiD As clsPunti)
        Direz1.X = -System.Math.Cos(Alfa / 2) : Direz2.X = Direz1.X
        Direz1.y = -System.Math.Sin(Alfa / 2) : Direz2.y = -Direz1.y
        '???     If Direz1.X * PuntiS.Punti(23).X + Direz1.Y * PuntiS.Punti(23).Y > 0 Then
        '???        Direz1.Y = -Direz1.Y
        '???        Direz2.Y = -Direz2.Y
        '???     End If
        If IUNL >= 2 Then
            GlobalRoutines.ComposDir(Direz1, DirR)
            GlobalRoutines.ComposDir(Direz2, DirR)
        End If
        ArcoGraf(PuntiS.Punti.Item(22).TextData, racc, Direz1, Alfa, IUNL - 1)
        ArcoGraf(PuntiD.Punti.Item(22).TextData, racc, Direz2, Alfa, IUNL - 1)
    End Sub
    Private Sub Arco3(ByVal PuntiS As clsPunti, ByVal PuntiD As clsPunti)
        Direz1.X = -System.Math.Cos(Alfa / 2) : Direz2.X = Direz1.X
        Direz1.y = System.Math.Sin(Alfa / 2) : Direz2.y = -Direz1.y
        '???    If Direz1.X * PuntiS.Punti(24).X + Direz1.Y * PuntiS.Punti(24).Y < 0 Then
        '???       Direz1.Y = -Direz1.Y
        '???       Direz2.Y = -Direz2.Y
        '???    End If
        If IUNL >= 2 Then
            GlobalRoutines.ComposDir(Direz1, DirR)
            GlobalRoutines.ComposDir(Direz2, DirR)
        End If
        ArcoGraf(PuntiS.Punti.Item(23).TextData, racc, Direz1, Alfa, IUNL - 1)
        ArcoGraf(PuntiD.Punti.Item(23).TextData, racc, Direz2, Alfa, IUNL - 1)
    End Sub
    Private Sub CerBoc(ByVal Oggetto As Piastrone)
        Call CercaBocchelli(Oggetto, jB, DBuco, OrigiB, DirB)
        Dim counter As Short
        counter = jB
        For j = 1 To counter
            DirR.X = posspa.CosDiritta.X
            DirR.y = posspa.CosDiritta.y
            If System.Math.Abs(System.Math.Abs(DirR.X * DirB.Punti.Item(j).TextData.X + DirR.y * DirB.Punti.Item(j).TextData.y) - 1) > TOLER Then
                For k = j To jB - 1
                    DBuco(k) = DBuco(k + 1)
                    OrigiB.Punti.Item(k).TextData = OrigiB.Punti.Item(k + 1).TextData
                    DirB.Punti.Item(k).TextData = DirB.Punti.Item(k + 1).TextData
                Next
                jB = jB - 1
            End If
        Next
        If jB * OTL > 0 Then
            MsgBox("Err imp. DisPia" & Str(jB) & Str(OTL))
        End If
    End Sub
    Private Sub BucoBoc(ByVal Oggetto As Piastrone)
        OTL = 0
        For j = 1 To jB
            iDir = -1
            Subdelta()
            If DELTAY < 0 Then
                Dtub1 = DBuco(j)
                OTL = -2 * DELTAY - Dtub1
                Exit For
            End If
        Next
        If OTL = 0 Then OTL = Oggetto.DiamExt / 2
        PuntiD.Punti.Item(1).TextData.y = -(OTL - Dtub1) / 2
        PuntiD.Punti.Item(2).TextData.y = -(OTL + Dtub1) / 2
        If PuntiD.Punti.Item(1).TextData.y * PuntiD.Punti.Item(2).TextData.y < 0 Then
            PuntiD.Punti.Item(0).TextData = PuntiD.Punti.Item(2).TextData
            PuntiD.Punti.Item(1).TextData = PuntiD.Punti.Item(2).TextData
        End If
        PuntiD.Punti.Item(18).TextData.y = -(OTL + Dtub1) / 2
        PuntiD.Punti.Item(19).TextData.y = -(OTL - Dtub1) / 2
        If PuntiD.Punti.Item(18).TextData.y * PuntiD.Punti.Item(19).TextData.y < 0 Then
            PuntiD.Punti.Item(20).TextData = PuntiD.Punti.Item(18).TextData
            PuntiD.Punti.Item(19).TextData = PuntiD.Punti.Item(18).TextData
        End If
    End Sub
    Private Sub Subdelta()
        Direzione.X = DirB.Punti.Item(j).TextData.X
        Direzione.y = DirB.Punti.Item(j).TextData.y
        Direzione.Z = 0
        GlobalRoutines.RotateZ(Direzione, PI / 2 * iDir)
        Vect.X = OrigiB.Punti.Item(j).TextData.X - posspa.Origine.X + DBuco(j) / 2 * Direzione.X
        Vect.y = OrigiB.Punti.Item(j).TextData.y - posspa.Origine.y + DBuco(j) / 2 * Direzione.y
        Vect.Z = 0
        posspa.CosDiritta.copia(Direzione)
        GlobalRoutines.RotateZ(Direzione, PI / 2)
        DELTAY = Vect.ProdScalar(Direzione)
    End Sub
    Private Sub Rivestimento(ByVal Oggetto As Piastrone)
        Select Case Oggetto.TipoMat
            Case 1
            Case 2, 3, 4
                MonoRiv(Oggetto)
            Case 5, 6, 7
                MonoRiv(Oggetto)
                BiRiv(Oggetto)
        End Select
    End Sub
    Private Sub BiRiv(ByVal Oggetto As Piastrone)
    End Sub
    Private Sub MonoRiv(ByVal Oggetto As Piastrone)
        With Look
            Select Case Oggetto.SottoTipo
                Case 5 'coperchio con due gradini
                    Npunti = Npunti + 2
                    PuntiS.Punti.Item(Npunti).TextData.X = Oggetto.SpessRive
                    PuntiS.Punti.Item(Npunti + 1).TextData.X = PuntiS.Punti.Item(Npunti).TextData.X ' HH - T1
                    If Oggetto.SpessRive < .H2 Then
                        PuntiS.Punti.Item(Npunti).TextData.y = Oggetto.B2 / 2
                        PuntiS.Punti.Item(Npunti + 1).TextData.y = 0
                    ElseIf Oggetto.SpessRive < .H1 Then
                        PuntiS.Punti.Item(Npunti).TextData.y = Oggetto.B1 / 2
                        PuntiS.Punti.Item(Npunti + 1).TextData.y = 0
                    Else
                        PuntiS.Punti.Item(Npunti).TextData.y = Oggetto.DiamExt / 2
                        PuntiS.Punti.Item(Npunti + 1).TextData.y = 0
                    End If
            End Select
        End With
        Return
    End Sub

    Sub DisGuar(ByRef Oggetto As Membratura)
        posspa = Oggetto.GenMem.SwappedPos
        Direzione.X = 0 : Direzione.y = 0 : Direzione.Z = 1
        prod = posspa.CosDiritta.ProdScalar(Direzione)
        If System.Math.Abs(prod) > TOLER Then Exit Sub
        de = Oggetto.Diamext
        di = Oggetto.Diamint
        t = Oggetto.Spess
        If posspa.Origine.Z < -de / 2 Or posspa.Origine.Z > de / 2 Then Exit Sub
        If IUNL = 0 Then
            xSmin = -t / 5 : ySmin = 1.2 * (-de / 2) : xSmax = 1.2 * t : ySmax = -ySmin
            If Not Funzioni.DisRut.Scala(xSmin, xSmax, ySmin, ySmax) Then Exit Sub
        End If
        DisGuar1(Oggetto)
        If IUNL = 0 Then
            Funzioni.DisRut.tratto(Rett1.Corners(4).X, Rett1.Corners(4).y, Rett2.Corners(1).X, Rett2.Corners(1).y, 0.1, 0)
            Funzioni.DisRut.tratto(Rett1.Corners(3).X, Rett1.Corners(3).y, Rett2.Corners(2).X, Rett2.Corners(2).y, 0.1, 0)
            'CALL Axes(Rett1, Rett2)      errore!
        End If
    End Sub
    Private Sub DisGuar1(ByVal Oggetto As Membratura)
        MakeCorners(Rett1, (de - di) / 2, t)
        TrasfRett(Rett1, 1, t / 2, di / 2)
        If IUNL >= 2 Then
            TrasfRett(Rett1, 1.0!, (posspa.Origine.X), (posspa.Origine.y))
            DirR.X = posspa.CosDiritta.X : DirR.y = posspa.CosDiritta.y
            RotRett(Rett1, (posspa.Origine.X), (posspa.Origine.y), GlobalRoutines.arco((DirR.X), (DirR.y)))
        End If
        'P0(0) = Rett1.Corners(1)??????????????
        If IUNL <> 4 Then
            RettGraf(Rett1, IUNL - 1)
        Else
            Spots = New spot
            Spots.Tipo = 1
            Spots.Quota = 0
            Spots.Quadro.TopLeft.X = GlobalRoutines.Minimo(Rett1.Corners(1).X, Rett1.Corners(2).X, Rett1.Corners(3).X, Rett1.Corners(4).X)
            Spots.Quadro.TopLeft.y = GlobalRoutines.Minimo(Rett1.Corners(1).y, Rett1.Corners(2).y, Rett1.Corners(3).y, Rett1.Corners(4).y)
            Spots.Quadro.Botrigt.X = GlobalRoutines.Massimo(Rett1.Corners(1).X, Rett1.Corners(2).X, Rett1.Corners(3).X, Rett1.Corners(4).X)
            Spots.Quadro.Botrigt.y = GlobalRoutines.Massimo(Rett1.Corners(1).y, Rett1.Corners(2).y, Rett1.Corners(3).y, Rett1.Corners(4).y)
            RegisterSpot(Spots, Oggetto)
        End If
        '---------------------
        MakeCorners(Rett2, (de - di) / 2, t)
        TrasfRett(Rett2, 1, t / 2, -di / 2 - (de - di) / 2)
        If IUNL >= 2 Then
            TrasfRett(Rett2, 1, (posspa.Origine.X), (posspa.Origine.y))
            DirR.X = posspa.CosDiritta.X : DirR.y = posspa.CosDiritta.y
            RotRett(Rett2, (posspa.Origine.X), (posspa.Origine.y), GlobalRoutines.arco((DirR.X), (DirR.y)))
        End If
        'P0(0) = Rett2.Corners(1)??????????????????
        If IUNL <> 4 Then
            RettGraf(Rett2, IUNL - 1)
        Else
            Spots = New spot
            Spots.Tipo = 1
            Spots.Quota = 0
            Spots.Quadro.TopLeft.X = GlobalRoutines.Minimo(Rett2.Corners(1).X, Rett1.Corners(2).X, Rett2.Corners(3).X, Rett1.Corners(4).X)
            Spots.Quadro.TopLeft.y = GlobalRoutines.Minimo(Rett2.Corners(1).y, Rett1.Corners(2).y, Rett2.Corners(3).y, Rett1.Corners(4).y)
            Spots.Quadro.Botrigt.X = GlobalRoutines.Massimo(Rett2.Corners(1).X, Rett1.Corners(2).X, Rett2.Corners(3).X, Rett1.Corners(4).X)
            Spots.Quadro.Botrigt.y = GlobalRoutines.Massimo(Rett2.Corners(1).y, Rett1.Corners(2).y, Rett2.Corners(3).y, Rett1.Corners(4).y)
            RegisterSpot(Spots, Oggetto)
            Exit Sub
        End If
        'UPGRADE_WARNING: Return ha un nuovo comportamento. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1041"'
        Return
    End Sub

    Sub DisPads(ByRef Oggetto As Anello)
        Dim Cil As Membratura
        posspa = Oggetto.GenMem.SwappedPos
        Direzione.X = 0 : Direzione.y = 0 : Direzione.Z = 1
        de = Oggetto.DiamExt
        di = Oggetto.DiamInt
        t = Oggetto.Spess
        Dmant = Oggetto.Dmant
        'If Dmant = 0 Then Dmant = 1000
        prod = posspa.CosDiritta.ProdScalar(Direzione)
        If System.Math.Abs(prod) > TOLER Then
            Pianta(Oggetto)
            Exit Sub
        End If
        prod = posspa.CosTraversa.ProdScalar(Direzione)
        If Dmant = 0 Then Call DisGuar(Oggetto) : Exit Sub
        If System.Math.Abs(prod) < TOLER Then
            Cil = posspa.SuChi
            If Cil.GenMem.Tipo = 1 Or Cil.GenMem.Tipo = 10 Or Cil.GenMem.Tipo = 14 Or Cil.GenMem.Tipo = 34 Then Call DisGuar(Oggetto) : Exit Sub
        End If
        'caso visto secondo l'asse del mantello , oppure sfera
        z1 = posspa.Origine.Z + de / 2
        z2 = posspa.Origine.Z - de / 2
        If z1 * z2 < 0 Then Verso = 0 Else Verso = (z1 + z2) / 2
        If Verso < 0 Then Exit Sub
        'If IUNL = 1 Then
        '     Call ScalaRel(posspa, xSmin, ySmin, xSmax, ySmax)
        '     Exit Sub
        'End If
        If IUNL = 0 Then
            xSmin = 1.2 * (-de) / 2 : ySmin = Dmant / 6 : xSmax = -xSmin : ySmax = Dmant / 2 + t
            If Not Funzioni.DisRut.Scala(xSmin, xSmax, ySmin, ySmax) Then Exit Sub
        End If
        Cil = posspa.SuChi
        SwapCoordN(Cil.GenMem)
        Select Case Cil.GenMem.Tipo
            Case 1
                SpOrig.X = Cil.GenMem.SwappedPos.Origine.X
                SpOrig.y = Cil.GenMem.SwappedPos.Origine.y
                Direz.X = posspa.CosDiritta.X
                Direz.y = posspa.CosDiritta.y
                R = Cil.Diametro / 2 : Hfon = R
                i = 1
            Case 3, 4, 5
                d = Cil.Diametro
                AP = CType(Cil, Fondo).Piedritto
                Select Case Cil.GenMem.Tipo
                    Case 3 'ell
                        Hfon = d / 4 + AP
                        R = d
                    Case 4 'tor
                        Hfon = d * (1.0! - System.Math.Sqrt(65.0!) / 10) + AP
                        R = d
                    Case 5 'sfe
                        Hfon = d / 2 + AP
                        R = d / 2
                End Select
                SpOrig.X = Cil.GenMem.SwappedPos.Origine.X - (R - Hfon) * Cil.GenMem.SwappedPos.CosDiritta.X
                SpOrig.y = Cil.GenMem.SwappedPos.Origine.y - (R - Hfon) * Cil.GenMem.SwappedPos.CosDiritta.y
                i = 1
            Case 10 'dovrebbe essere il caso solo se IUNL=5
                R = Dmant / 2 + t
                Hfon = R
                SpOrig.X = posspa.Origine.X + R * posspa.CosDiritta.X
                SpOrig.y = posspa.Origine.y + R * posspa.CosDiritta.y
                i = -1
        End Select
        Orig.X = posspa.Origine.X
        Orig.y = posspa.Origine.y
        Direz.X = i * posspa.CosDiritta.X
        Direz.y = i * posspa.CosDiritta.y
        Linea.P0 = Orig
        Linea.Direz = Direz
        Punti.Inizia(4)
        Linea.InterRettCerch(0.0!, SpOrig, R, Punti, n1, n2)
        prod = (Punti.Punti.Item(1).TextData.X - SpOrig.X) * Direz.X + (Punti.Punti.Item(1).TextData.y - SpOrig.y) * Direz.y
        If prod < 0 Then Punti.SWAP(1, 2)
        Punti.Punti.Item(1).TextData.X = Punti.Punti.Item(1).TextData.X - SpOrig.X
        Punti.Punti.Item(1).TextData.y = Punti.Punti.Item(1).TextData.y - SpOrig.y
        Direz.X = Punti.Punti.Item(1).TextData.X / R
        Direz.y = Punti.Punti.Item(1).TextData.y / R
        dAlfa = GlobalRoutines.arco((Direz.X), (Direz.y))
        Punti.Punti.Item(1).TextData.X = Punti.Punti.Item(1).TextData.X + _
               (R - Hfon) * Cil.GenMem.SwappedPos.CosDiritta.X
        Punti.Punti.Item(1).TextData.y = Punti.Punti.Item(1).TextData.y + _
               (R - Hfon) * Cil.GenMem.SwappedPos.CosDiritta.y
        prod = Punti.Punti.Item(1).TextData.X * posspa.CosDiritta.X + _
               Punti.Punti.Item(1).TextData.y * posspa.CosDiritta.y
        cosa = System.Math.Abs(prod) / System.Math.Sqrt(Punti.Punti.Item(1).TextData.X ^ 2 + _
               Punti.Punti.Item(1).TextData.y ^ 2)
        If cosa = 0 Then
            MsgBox("Errore 1 in DisPads") ' è accaduto quando voleva disegnare secondo l'asse del cilindro e invece
            Exit Sub
        End If
        If Verso = 0 Then
            For i = -1 To 1 Step 2
                SP.RG = Dmant / 2 + t : SP.RP = Dmant / 2
                SpOrig.copia((SP.Origin))
                AlfaP = dAlfa + i * GlobalRoutines.asin(di / cosa / Dmant)
                AlfaG = AlfaP + i * (de - di) / Dmant
                SP.Direct.X = System.Math.Cos((AlfaG + AlfaP) / 2) : SP.Direct.y = System.Math.Sin((AlfaG + AlfaP) / 2)
                SP.Alfa = System.Math.Abs(AlfaG - AlfaP) : If SP.Alfa > 2 * PI Then SP.Alfa = SP.Alfa - 2 * PI
                '    Trasfspicchio Sp, Scalb!, offx!, offy!
                TracPad(Oggetto)
            Next
        Else
            AlfaP = dAlfa + GlobalRoutines.asin(di / Dmant)
            AlfaG = AlfaP + (de - di) / Dmant
            AlfaP = dAlfa - (AlfaG - dAlfa)
            SP.Direct.X = System.Math.Cos(dAlfa) : SP.Direct.y = System.Math.Sin(dAlfa)
            SP.Alfa = System.Math.Abs(AlfaG - AlfaP) : If SP.Alfa > 2 * PI Then SP.Alfa = SP.Alfa - 2 * PI
            '    Trasfspicchio Sp, Scalb!, offx!, offy!
            i = -1
            'UPGRADE_ISSUE: L'istruzione GoSub non è supportata. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1014"'
            TracPad(Oggetto)
        End If
    End Sub
    Private Sub TracPad(ByVal Oggetto As Membratura)
        If IUNL <> 4 Then
            If Verso > 0 Then
                Call Infilata(Oggetto, Verso, InMezzo)
                If InMezzo > 1 Then Exit Sub
                '          If InMezzo = 1 Then Call Funzioni.DisRut.ctrait(3, 0.1)
            End If
            SP.SpicGraf(2, Punti0, Punti1)
            '        Call Funzioni.DisRut.ctrait(0, 0.1)
        Else
            Spots = New spot
            Spots.Tipo = 2
            Spots.Quota = Verso
            Spots.spicchio = SP
            RegisterSpot(Spots, Oggetto)
        End If
    End Sub
    Private Sub Pianta(ByVal Oggetto As Membratura)
        z1 = posspa.Origine.Z
        z2 = posspa.Origine.Z + t * posspa.CosDiritta.Z
        If z1 * z2 < 0 Then Verso = 0 Else Verso = (z1 + z2) / 2
        If Verso < 0 Then Exit Sub
        x = posspa.Origine.X '* Scalb!
        y = posspa.Origine.y '* Scalb!
        Ri = di / 2 '* Scalb!
        Re = de / 2 '* Scalb!
        If IUNL < 4 Then
            Call Infilata(Oggetto, Verso, InMezzo)
            If InMezzo > 1 Then Exit Sub
            If InMezzo = 1 Then Call Funzioni.DisRut.ctrait(3, 0.1)
            '        Call Funzioni.DisRut.refere(offx!, offy!, 0)
            Call Funzioni.DisRut.cerc(x, y, Ri)
            Call Funzioni.DisRut.cerc(x, y, Re)
            Call Funzioni.DisRut.refabs()
            Call Funzioni.DisRut.ctrait(0, 0.1)
        End If
        If IUNL = 4 Then
            Spots = New spot
            Spots.Tipo = 2
            Spots.Quota = Verso
            Spots.spicchio.Origin.X = x
            Spots.spicchio.Origin.y = y
            Spots.spicchio.RG = Re
            Spots.spicchio.RP = Ri
            Spots.spicchio.Alfa = 2 * PI
            RegisterSpot(Spots, Oggetto)
        End If
    End Sub

    Sub DisCalDisc(ByRef Oggetto As CalDisc)
        Dim Spots As spot
        Dim zerox, Alfa, zeroy As Single
        Dim SP As New Spicchio4
        Dim Centr As New RoutBase1.clsVec2
        Dim DirR As New RoutBase1.clsVec2
        Dim posspa As Posizione
        Dim Direzione As New RoutBase1.clsVec3
        Dim Punti0, Punti1 As RoutBase1.clsPunti
        Dim prod, Verso As Single
        posspa = Oggetto.GenMem.SwappedPos
        If IUNL = 0 Then
            xSmin = -Oggetto.DiamExt / 10 : ySmin = -0.6 * (Oggetto.DiamExt + 2 * Oggetto.SpessRive) : xSmax = 0.6 * Oggetto.DiamExt : ySmax = -ySmin
            If Not Funzioni.DisRut.Scala(xSmin, xSmax, ySmin, ySmax) Then Exit Sub
        End If
        Direzione.X = 0 : Direzione.y = 0 : Direzione.Z = 1
        prod = posspa.CosDiritta.ProdScalar(Direzione)
        Verso = posspa.Origine.Z
        If System.Math.Abs(prod) > TOLER Then
SezRett:    Exit Sub
        End If
        '-----------------------------------------------------------
        If Oggetto.Ginocchio * Oggetto.Colletto > 0 Then 'fondo piano con colletto
            '-----------------------------------------------------------
        ElseIf Oggetto.RaggioCal > 0 Then  'calotta
            SP.Direct.X = 1 : SP.Direct.y = 0
            Alfa = GlobalRoutines.asin(Oggetto.DiamExt / 2 / (Oggetto.RaggioCal + Oggetto.SpessBase))
            SP.Alfa = 2 * Alfa
            SP.Origin.X = -(Oggetto.RaggioCal + Oggetto.SpessBase) * System.Math.Cos(Alfa)
            SP.RP = Oggetto.RaggioCal : SP.RG = Oggetto.RaggioCal + Oggetto.SpessBase
            If IUNL >= 2 Then
                DirR.X = posspa.CosDiritta.X
                DirR.y = posspa.CosDiritta.y
                Centr.X = 0 : Centr.y = 0
                TraslRot((SP.Origin), Centr, DirR)
                SP.Origin.X = SP.Origin.X + posspa.Origine.X
                SP.Origin.y = SP.Origin.y + posspa.Origine.y
                GlobalRoutines.ComposDir((SP.Direct), DirR)
            End If
            '   Trasfspicchio Sp, Scalb!, offx!, offy!
            If IUNL = 4 Then
                Spots = New spot
                Spots.Tipo = 2
                Spots.spicchio = SP
                Spots.Quota = 0
                RegisterSpot(Spots, Oggetto)
                Exit Sub
            End If
            SP.SpicGraf(1, Punti0, Punti1)
            If IUNL = 0 Then
                Funzioni.DisRut.tratto((Punti0.Punti.Item(1).TextData.X + Punti1.Punti.Item(1).TextData.X) / 2, _
                                       (Punti0.Punti.Item(1).TextData.y + Punti1.Punti.Item(1).TextData.y) / 2, _
                                       (Punti0.Punti.Item(3).TextData.X + Punti1.Punti.Item(3).TextData.X) / 2, _
                                       (Punti0.Punti.Item(3).TextData.y + Punti1.Punti.Item(3).TextData.y) / 2, 0.1, 3)
                zerox = ((Punti0.Punti.Item(1).TextData.X + Punti1.Punti.Item(1).TextData.X) / 2 + _
                         (Punti0.Punti.Item(3).TextData.X + Punti1.Punti.Item(3).TextData.X) / 2) / 2
                zeroy = ((Punti0.Punti.Item(1).TextData.y + Punti1.Punti.Item(1).TextData.y) / 2 + _
                         (Punti0.Punti.Item(3).TextData.y + Punti1.Punti.Item(3).TextData.y) / 2) / 2
                Funzioni.DisRut.tratto(zerox - SP.RG / 5, zeroy, zerox + SP.RG * 1.2, zeroy, 0.1, 3)
                Funzioni.DisRut.Freccia(Int(zerox + SP.RG * 1.2), Int(zeroy))
            End If
            Funzioni.DisRut.tratto(Punti0.Punti.Item(1).TextData.X, Punti0.Punti.Item(1).TextData.y, _
                                   Punti0.Punti.Item(3).TextData.X, Punti0.Punti.Item(3).TextData.y, 0.1, 0) 'riga da tagliare
        Else 'disco
            '----------------------------------------------------------------
        End If
    End Sub
    Public Sub AggiustaLun(ByRef Record As clsGenMem)
        Dim Vector As New RoutBase1.clsVec3
        Dim Ind As Membratura
        Dim prod, delta As Single
        Select Case Record.Tipo
            Case 12
                Ind = Record.posizione.ForoSecondario
                If Ind Is Nothing Then Exit Sub
                With Ind.GenMem.posizione
                    Vector.X = .Origine.X - Record.posizione.Origine.X
                    Vector.y = .Origine.y - Record.posizione.Origine.y
                    Vector.Z = .Origine.Z - Record.posizione.Origine.Z
                    prod = Vector.ProdScalar(.CosDiritta)
                End With
                With CType(Record.Parent, Piastrone)
                    Select Case .SottoTipo
                        Case 1, 2 'due codoli
                            If prod > 0 Then delta = .SpessBase + .H2 Else delta = 0
                        Case 3, 7 'un codolo lato shell)
                            delta = .SpessBase + .H2
                        Case 4, 5, 6
                            MsgBox("Err.AggiustaLun")
                    End Select
                    delta = System.Math.Abs(prod - delta)
                    .SpessBase = Int(delta)
                End With
            Case Else
                '???????????
        End Select
    End Sub
    Public Sub CercaForoS(ByRef Record As clsGenMem, ByRef indice As clsGenMem)
        Dim Dir1, Dir2 As Single
        If indice.Tipo = 26 Then indice = indice.posizione.SuChi.GenMem
        Select Case System.Math.Abs(Record.Tipo)
            Case 13
                BCircle = CType(Record.Parent, clsTirante).Dinst
                Lung = Record.Parent.Lunghezza
            Case 8 : BCircle = 0
                Lung = Record.Parent.Lunghezza
            Case Else : GoTo FinSub
        End Select
        Point3.Inizia(6)
        Record.posizione.Origine.copia(Point3.Punti.Item(1).TextData)
        Point3.Punti.Item(2).TextData.X = Point3.Punti.Item(1).TextData.X + Lung * Record.posizione.CosDiritta.X
        Point3.Punti.Item(2).TextData.y = Point3.Punti.Item(1).TextData.y + Lung * Record.posizione.CosDiritta.y
        Point3.Punti.Item(2).TextData.Z = Point3.Punti.Item(1).TextData.Z + Lung * Record.posizione.CosDiritta.Z
        For j = 1 To Apparecchio.Elementi.Count()
            Select Case System.Math.Abs(Record.Tipo)
                Case 13
                    Dim Tipo As Short = System.Math.Abs(Apparecchio.Elementi(j - 1).GenMem.Tipo)
                    If Tipo = 11 And Not Apparecchio.Elementi(j - 1).GenMem Is indice Then
                        Proiez = Record.posizione.CosDiritta.ProdScalar(Apparecchio.Elementi(j - 1).GenMem.posizione.CosDiritta)
                        If System.Math.Abs(System.Math.Abs(Proiez) - 1) < TOLER Then
                            Dim Flangione As Flangione = Apparecchio.Elementi(j - 1)
                            If BCircle > Flangione.DiamInt And BCircle < Flangione.DiamExt Then
                                H = Flangione.H
                                HS = H + Flangione.SpessBase
                                With Flangione.GenMem.posizione
                                    Point3.Punti.Item(3).TextData.X = .Origine.X + H * .CosDiritta.X
                                    Point3.Punti.Item(3).TextData.y = .Origine.y + H * .CosDiritta.y
                                    Point3.Punti.Item(3).TextData.Z = .Origine.Z + H * .CosDiritta.Z
                                    Point3.Punti.Item(4).TextData.X = .Origine.X + HS * .CosDiritta.X
                                    Point3.Punti.Item(4).TextData.y = .Origine.y + HS * .CosDiritta.y
                                    Point3.Punti.Item(4).TextData.Z = .Origine.Z + HS * .CosDiritta.Z
                                End With
                                LavLav(Dir1, Dir2)
                                If Dir1 < 0 Or Dir2 < 0 Then
                                    Record.posizione.ForoSecondario = Flangione
                                    Call BucoTirFlan(Record, Flangione.GenMem, Quota, Raggio, anom, NB, DFor, peso)
                                    Call ForaVecchio(1, Record, Flangione.GenMem, Quota, Raggio, anom, NB, DFor, DFor / 2, peso)
                                End If
                            End If
                        End If
                    ElseIf Tipo = 10 And Not Apparecchio.Elementi(j - 1).GenMem Is indice Then
                        Proiez = Record.posizione.CosDiritta.ProdScalar(Apparecchio.Elementi(j - 1).GenMem.posizione.CosDiritta)
                        If System.Math.Abs(System.Math.Abs(Proiez) - 1) < TOLER Then
                            Dim Bocch As clsBocch = Apparecchio.Elementi(j - 1)
                            If BCircle > Bocch.DiamInt And BCircle < Bocch.Standard.DiamExt Then
                                H = Bocch.Standard.Altezza
                                HS = H + Bocch.Standard.Spessore
                                With Bocch.GenMem.posizione
                                    Point3.Punti.Item(3).TextData.X = .Origine.X + H * .CosDiritta.X
                                    Point3.Punti.Item(3).TextData.y = .Origine.y + H * .CosDiritta.y
                                    Point3.Punti.Item(3).TextData.Z = .Origine.Z + H * .CosDiritta.Z
                                    Point3.Punti.Item(4).TextData.X = .Origine.X + HS * .CosDiritta.X
                                    Point3.Punti.Item(4).TextData.y = .Origine.y + HS * .CosDiritta.y
                                    Point3.Punti.Item(4).TextData.Z = .Origine.Z + HS * .CosDiritta.Z
                                End With
                                LavLav(Dir1, Dir2)
                                If Dir1 < 0 Or Dir2 < 0 Then
                                    Record.posizione.ForoSecondario = Bocch
                                    'Call BucoTirFlan(Record, Bocch.GenMem, Quota, Raggio, anom, NB, DFor, peso)
                                    'Call ForaVecchio(1, Record, Bocch.GenMem, Quota, Raggio, anom, NB, DFor, DFor / 2, peso)
                                End If
                            End If
                        End If
                    ElseIf Tipo = 12 And Not Apparecchio.Elementi(j - 1).GenMem Is indice Then
                        With Apparecchio.Elementi(j - 1)
                            If .SottoTipo = 6 Or .SottoTipo = 3 Or .SottoTipo = 5 Or .SottoTipo = 7 Then
                                Proiez = Record.posizione.CosDiritta.ProdScalar(.GenMem.posizione.CosDiritta)
                                If System.Math.Abs(System.Math.Abs(Proiez) - 1) < TOLER Then
                                    If BCircle < .DiamExt Then
                                        .GenMem.posizione.Origine.Copia(Point3.Punti.Item(3))
                                        Point3.Punti.Item(4).TextData.X = Point3.Punti.Item(3).TextData.X + .SpessBase * .GenMem.posizione.CosDiritta.x
                                        Point3.Punti.Item(4).TextData.y = Point3.Punti.Item(3).TextData.y + .SpessBase * .GenMem.posizione.CosDiritta.y
                                        Point3.Punti.Item(4).TextData.Z = Point3.Punti.Item(3).TextData.Z + .SpessBase * .GenMem.posizione.CosDiritta.Z
                                        LavLav(Dir1, Dir2)
                                        If Dir1 < 0 Or Dir2 < 0 Then
                                            Record.posizione.ForoTerziario = Apparecchio.Elementi(j - 1)
                                            Call BucoTirFlan(Record, .GenMem, Quota, Raggio, anom, NB, DFor, peso)
                                            Call ForaVecchio(1, Record, .GenMem, Quota, Raggio, anom, NB, DFor, DFor / 2, peso)
                                        End If
                                    End If
                                End If
                            End If
                        End With
                    End If
                Case 8
                    If System.Math.Abs(Apparecchio.Elementi(j - 1).GenMem.Tipo) = 12 And Not Apparecchio.Elementi(j - 1).GenMem Is indice Then
                        With Apparecchio.Elementi(j - 1)
                            Proiez = Record.posizione.CosDiritta.ProdScalar(.GenMem.posizione.CosDiritta)
                            If System.Math.Abs(System.Math.Abs(Proiez) - 1) < TOLER Then
                                .GenMem.posizione.Origine.Copia(Point3.Punti.Item(3))
                                Point3.Punti.Item(4).TextData.X = Point3.Punti.Item(3).TextData.X + .SpessBase * .GenMem.posizione.CosDiritta.x
                                Point3.Punti.Item(4).TextData.y = Point3.Punti.Item(3).TextData.y + .SpessBase * .GenMem.posizione.CosDiritta.y
                                Point3.Punti.Item(4).TextData.Z = Point3.Punti.Item(3).TextData.Z + .SpessBase * .GenMem.posizione.CosDiritta.Z
                                LavLav(Dir1, Dir2)
                                If Dir1 < 0 Or Dir2 < 0 Then
                                    Record.posizione.ForoTerziario = Apparecchio.Elementi(j)
                                    NB = Record.Qta
                                    DFor = Record.Parent.Diamext
                                    peso = PI / 4 * NB * DFor * DFor * .SpessBase * .GenMem.PesoSp1 '* EXP9
                                    Quota = .SpessBase / 2 : Raggio = 0 : anom = 0
                                    Call Buco(.GenMem, peso, Quota, Raggio, anom)
                                    Call ForaVecchio(1, Record, .GenMem, Quota, Raggio, anom, NB, DFor, DFor / 2, peso, .SpessBase)
                                End If
                            End If
                        End With
                    End If
            End Select
        Next j
FinSub:  'Erase Point3
    End Sub
    Private Sub LavLav(ByVal Dir1 As Single, ByVal Dir2 As Single)
        Point3.Punti.Item(5).TextData.X = Point3.Punti.Item(1).TextData.X - Point3.Punti.Item(3).TextData.X
        Point3.Punti.Item(5).TextData.y = Point3.Punti.Item(1).TextData.y - Point3.Punti.Item(3).TextData.y
        Point3.Punti.Item(5).TextData.Z = Point3.Punti.Item(1).TextData.Z - Point3.Punti.Item(3).TextData.Z
        Point3.Punti.Item(6).TextData.X = Point3.Punti.Item(2).TextData.X - Point3.Punti.Item(3).TextData.X
        Point3.Punti.Item(6).TextData.y = Point3.Punti.Item(2).TextData.y - Point3.Punti.Item(3).TextData.y
        Point3.Punti.Item(6).TextData.Z = Point3.Punti.Item(2).TextData.Z - Point3.Punti.Item(3).TextData.Z
        Dir1 = Point3.Punti.Item(5).TextData.ProdScalar(Point3.Punti.Item(6).TextData)
        Point3.Punti.Item(5).TextData.X = Point3.Punti.Item(1).TextData.X - Point3.Punti.Item(4).TextData.X
        Point3.Punti.Item(5).TextData.y = Point3.Punti.Item(1).TextData.y - Point3.Punti.Item(4).TextData.y
        Point3.Punti.Item(5).TextData.Z = Point3.Punti.Item(1).TextData.Z - Point3.Punti.Item(4).TextData.Z
        Point3.Punti.Item(6).TextData.X = Point3.Punti.Item(2).TextData.X - Point3.Punti.Item(4).TextData.X
        Point3.Punti.Item(6).TextData.y = Point3.Punti.Item(2).TextData.y - Point3.Punti.Item(4).TextData.y
        Point3.Punti.Item(6).TextData.Z = Point3.Punti.Item(2).TextData.Z - Point3.Punti.Item(4).TextData.Z
        Dir2 = Point3.Punti.Item(5).TextData.ProdScalar(Point3.Punti.Item(6).TextData)
    End Sub
    Private Sub VerifBordo(ByRef Record As clsGenMem, ByRef Recordv As clsGenMem, ByRef iProcedi As Boolean)
        iProcedi = True
        If Inizio.AddDistinta = 103 Then Exit Sub
        Dim PAusil As New RoutBase1.clsVec3
        Dim PAusim As New RoutBase1.clsVec3
        Dim PAusil3 As New RoutBase1.clsVec3
        Dim Pausim3 As New RoutBase1.clsVec3
        Dim CentroTegola3 As New RoutBase1.clsVec3
        Dim PAusil2 As New RoutBase1.clsVec2
        Dim CentroBocch2 As New RoutBase1.clsVec2
        Dim VerticeTegola2 As New RoutBase1.clsVec2
        Dim DirBocch As New RoutBase1.clsVec2
        Dim CentroC2 As New RoutBase1.clsVec2
        Dim DirVertice As New RoutBase1.clsVec2
        Dim Diam, AlungAusil As Single
        Dim dist, dist1 As Single
        Dim n1, n2 As Short
        Dim i1 As Short
        Dim ang1, ang, ang2 As Single
        Dim Dang1, Dang2 As Single
        Dim Linea As New RoutBase1.clsLinea2
        Dim Punti As New RoutBase1.clsPunti
        If System.Math.Abs(Record.Tipo) = 10 Then
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Record.Parent.Standard. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            Diam = Record.Parent.Standard.DiamTr
        Else
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Record.Parent.Diametro. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            Diam = Record.Parent.Diametro
            '???If Record.Dati(6) > Diam Then Diam = Record.Dati(6)
        End If
        AlungAusil = 300
        ' prendi su asse bocchello su punto oltre l'origine:PAusil
        PAusil.X = Record.posizione.Origine.X + AlungAusil * Record.posizione.CosDiritta.X
        PAusil.y = Record.posizione.Origine.y + AlungAusil * Record.posizione.CosDiritta.y
        PAusil.Z = Record.posizione.Origine.Z + AlungAusil * Record.posizione.CosDiritta.Z
        ' prendi su asse Origine tegola unpunto            :PAusim
        PAusim.X = Recordv.posizione.Origine.X + AlungAusil * Recordv.posizione.CosOrigine.X
        PAusim.y = Recordv.posizione.Origine.y + AlungAusil * Recordv.posizione.CosOrigine.y
        PAusim.Z = Recordv.posizione.Origine.Z + AlungAusil * Recordv.posizione.CosOrigine.Z
        ' proietta PAusil sul piano perpendicolare all'asse della tegola:PAusil3
        Call GlobalRoutines.Proietta((Record.posizione.Origine), (Recordv.posizione.CosDiritta), PAusil, PAusil3)
        Call GlobalRoutines.Proietta((Record.posizione.Origine), (Recordv.posizione.CosDiritta), (Recordv.posizione.Origine), CentroTegola3)
        Call GlobalRoutines.Proietta((Record.posizione.Origine), (Recordv.posizione.CosDiritta), PAusim, Pausim3)
        Call GlobalRoutines.CoorPIa(CentroTegola3, PAusil3, PAusil3, PAusil2, (Recordv.posizione.CosDiritta))
        Call GlobalRoutines.CoorPIa(CentroTegola3, PAusil3, (Record.posizione.Origine), CentroBocch2, (Recordv.posizione.CosDiritta))
        Call GlobalRoutines.CoorPIa(CentroTegola3, PAusil3, Pausim3, VerticeTegola2, (Recordv.posizione.CosDiritta))
        dist = System.Math.Sqrt((CentroBocch2.X - PAusil2.X) ^ 2 + (CentroBocch2.y - PAusil2.y) ^ 2)
        DirBocch.X = (CentroBocch2.X - PAusil2.X) / dist
        DirBocch.y = (CentroBocch2.y - PAusil2.y) / dist
        CentroC2.X = 0 : CentroC2.y = 0
        Linea.P0 = CentroBocch2
        Linea.Direz = DirBocch
        Punti.Inizia(4)
        Linea.InterRettCerch(Diam / 2, CentroC2, Recordv.Parent.Diametro, Punti, n1, n2)
        If n1 < 2 Or n2 < 2 Then
            iProcedi = False
        Else
            dist = System.Math.Sqrt((Punti.Punti.Item(1).TextData.X - CentroBocch2.X) ^ 2 + (Punti.Punti.Item(1).TextData.y - CentroBocch2.y) ^ 2)
            dist1 = System.Math.Sqrt((Punti.Punti.Item(2).TextData.X - CentroBocch2.X) ^ 2 + (Punti.Punti.Item(2).TextData.y - CentroBocch2.y) ^ 2)
            If dist1 < dist Then dist = dist1 : i1 = 1 Else i1 = 0
            dist1 = System.Math.Sqrt(VerticeTegola2.X * VerticeTegola2.X + VerticeTegola2.y * VerticeTegola2.y)
            DirVertice.X = VerticeTegola2.X / dist1
            DirVertice.y = VerticeTegola2.y / dist1
            ang = GlobalRoutines.arco((DirVertice.X), (DirVertice.y))
            dist1 = System.Math.Sqrt(Punti.Punti.Item(1 + i1).TextData.X * Punti.Punti.Item(1 + i1).TextData.X + Punti.Punti.Item(1 + i1).TextData.y * Punti.Punti.Item(1 + i1).TextData.y)
            DirVertice.X = Punti.Punti.Item(1 + i1).TextData.X / dist1
            DirVertice.y = Punti.Punti.Item(1 + i1).TextData.y / dist1
            ang1 = GlobalRoutines.arco((DirVertice.X), (DirVertice.y))
            dist1 = System.Math.Sqrt(Punti.Punti.Item(3 + i1).TextData.X * Punti.Punti.Item(3 + i1).TextData.X + Punti.Punti.Item(3 + i1).TextData.y * Punti.Punti.Item(3 + i1).TextData.y)
            DirVertice.X = Punti.Punti.Item(3 + i1).TextData.X / dist1
            DirVertice.y = Punti.Punti.Item(3 + i1).TextData.y / dist1
            ang2 = GlobalRoutines.arco((DirVertice.X), (DirVertice.y))
            Dang1 = System.Math.Abs(ang - ang1) : If Dang1 > PI Then Dang1 = Dang1 - PI
            Dang2 = System.Math.Abs(ang - ang2) : If Dang2 > PI Then Dang2 = Dang2 - PI
            If Dang1 > CType(Recordv.Parent, Cono).AlfaCon / 2 Or Dang2 > CType(Recordv.Parent, Cono).AlfaCon / 2 Then iProcedi = False
        End If
    End Sub
    Public Sub ForaVecchio(ByRef isW As Short, ByRef Record As clsGenMem, ByRef Recordv As clsGenMem, ByRef Quota As Single, ByRef Raggio As Single, ByRef anom As Single, ByRef NB As Short, ByRef DFor As Single, ByRef rag As Single, ByRef peso As Single, Optional ByRef p As Single = 0)
        Dim Foro As Foratura
        Dim Nuovo As Boolean
        Foro = Apparecchio.CercaForo(Record, Recordv)
        If Foro Is Nothing Then
            Foro = New Foratura
            Nuovo = True
        Else
            Buco(Recordv, -Foro.GenMem.PNET, (Foro.Quota), (Foro.Raggio), (Foro.anom))
        End If
        With Foro
            .Quota = Quota
            .Raggio = Raggio
            .anom = anom
            .DiamFor = 2 * rag
            .isW = isW
            .Profon = p
            If Nuovo Then .Bucante = Record.Parent
        End With
        With Foro.GenMem
            If Nuovo Then
                .posizione.SuChi = Recordv.Parent
                .PosDis = 999
            End If
            .Denom = "FORATURA POS." & Recordv.PosDis.ToString & " PER POS." & Record.PosDis.ToString
            .Dimensioni = " N°" & NB.ToString & " fori D" & DFor.ToString
            .Materiale = Recordv.Materiale
            .PNET = peso
            .Qta = NB
        End With
        If Nuovo Then Apparecchio.Add(Foro)
    End Sub
    Public Sub Intersect(ByRef Record As clsGenMem, ByRef Recordv As clsGenMem, ByRef isW As Short)
        If System.Math.Abs(Record.Tipo) = 99 Then Exit Sub
        isW = 0
        Try
            If Recordv.Tipo = 0 Then Exit Sub
            If Record.Tipo = -2 Then Exit Sub
            If Record.Tipo = -10 Then Exit Sub
            Dim n As OggList.NodeP = Apparecchio.Elementi.nodeHead.Next
            While Not n Is Nothing
                O = n.TextData
                If O.GenMem.Tipo = 97 Then
                    If O.Bucante Is Recordv.Parent And O.GenMem.posizione.SuChi Is Record.Parent Then Exit Sub
                End If
                n = n.Next
            End While
            Select Case System.Math.Abs(Record.Tipo)
                Case 0
                    Exit Sub
                    '--------------------------------------------------------------------------
                Case 1, 10, 14 ' Cilindri e bocchelli
                    Select Case System.Math.Abs(Recordv.Tipo)
                        Case 1, 2, 6, 7, 34
                            CilForCil(Record, Recordv) ' su cilindri tubi e coni
                        Case 3, 4, 5
                            CilForFon(Record, Recordv) 'Cilindri su fondi (approx al caso sferico)
                        Case 10
                            CilForCil(Record, Recordv) ' VisualBasic
                        Case 12
                            CilForPia(Record, Recordv) 'Cilindri e bocchelli su  piastre
                        Case 11, 18, 25, 28, 36 'Cilindri e bocchelli su piastre ,dilatatori, flangioni  e guarn
                        Case Else
                            IntStop(Record, Recordv)
                    End Select
                Case 2 'Tubi
                    Select Case System.Math.Abs(Recordv.Tipo)
                        Case 1
                            CilCil(Record, Recordv) 'Tubi su cilindri
                            '         CASE 10:                GOSUB IntStop 'Tubi su Bocchelli
                            '         CASE ELSE:              GOSUB IntStop
                    End Select
                Case 3, 4, 5 'Fondi
                    Select Case System.Math.Abs(Recordv.Tipo)
                        Case 1, 7 : Exit Sub ' Fondi su cilindri e coni
                        Case 2 : Exit Sub ' Fondi su tubi
                        Case 3, 4, 5
                            IntStop(Record, Recordv) ' Fondi su fondi
                        Case 13
                            IntStop(Record, Recordv) 'Fondi su tiranti
                        Case Else
                            IntStop(Record, Recordv)
                    End Select
                    '-----------------------------------------------------------------------
                Case 6, 7 'Conoidi,Coni
                    '--------------------------------------------------------------------------
                Case 8, 9 : RecTubi = Record
                    If Recordv.Tipo = 12 Then
                        RecPiastra = Recordv
                    ElseIf Recordv.Tipo = 26 Then
                        RecPiastra = Recordv.posizione.SuChi.GenMem
                    Else
                        Exit Sub
                    End If
                    If RecPiastra.Tipo = 12 Then
                        TubiFora() 'Tubi
                        isW = 1
                    End If
                Case 26
                    'Set RecTubi = Membro.Tubi.GenMem
                    'Set RecPiastra = ctype(Membro.Genmem,clsGenmem).posizione.SuChi.GenMem
                    'If RecPiastra.Tipo = 12 Then GoSub TubiFora 'Tubi
                    'isW = 1 'CALL CercaForoS(Record, Recordv.ind)
                    '------------------------------------------------------------------------
                Case 11, 12 'Flangioni
                    Select Case System.Math.Abs(Recordv.Tipo)
                        Case 13
                            FlanForTir(Record, Recordv, isW) 'Flangioni/piastre su tiranti
                        Case 8
                            FlanForTub(Record, Recordv) 'Flangioni/piastre su tubi
                    End Select
                Case 13 'Tiranti
                    Select Case Recordv.Tipo
                        Case 1, 2, 3, 4, 5, 6, 7 : Exit Sub
                        Case 10, 14 'Tiranti su flange
                        Case 11, 12
                            TirForFlan(Record, Recordv) 'Tiranti su flangioni
                        Case Else
                            IntStop(Record, Recordv)
                    End Select
                    isW = 1 'CALL CercaForoS(Record, Recordv.ind)
            End Select
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Private Sub CilCil(ByVal Record As clsGenMem, ByVal Recordv As clsGenMem)
2010:   CosAlfa = Record.posizione.CosDiritta.ProdScalar((Recordv.posizione.CosDiritta))
        If System.Math.Abs(CosAlfa) < 0.9 Then
            Raggio = Record.posizione.RaggioR
            '           IF ABS(Recordv.Tipo) = 7 THEN
            '2020          raggio = (Recordv.Dati(2) + (Recordv.Dati(5) - Recordv.Dati(2)) * Record.PosSpa.QuotaR / Recordv.Dati(7)) / 2
            '              ProdVect Record.PosSpa.CosDiritta, Recordv.PosSpa.CosDiritta, Vect
            '              DirAlpha Recordv.PosSpa.CosDiritta, Vect, Sol, (90 - Recordv.Dati(8)) * PI / 180
            '              cosbeta = ABS(ProdScalar(Record.PosSpa.CosDiritta, Sol))
            '              'Sol e' la normale alla superficie del cono
            '           ELSE
            '2030          raggio = Recordv.Dati(2) / 2
            CosBeta = 1.0!
            '           END IF
            If System.Math.Abs(Record.Tipo) = 10 Or System.Math.Abs(Record.Tipo) = 14 Then
                'Rec2Buf(1) = Record
                '??????????    If RecordD(0).Denom = Record.Denom Then Rec2Buf(1).Ind = 0
                raggiop = RaggioBocN(Record)
            Else
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Record.Parent.SpessBase. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Record.Parent.Diametro. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                raggiop = Record.Parent.Diametro / 2 + Record.Parent.SpessBase
            End If
2040:       aelliss = (raggiop) / CosBeta 'longitud
            Raggio = Raggio + CType(Recordv.Parent, Cilindro).Spessore
            ang = System.Math.Atan(aelliss / System.Math.Sqrt(Raggio ^ 2 - aelliss ^ 2))
            belliss = Raggio * ang
            If Record.Qta = 0 Then Record.Qta = 1
            NB = Record.Qta
            peso = PI * aelliss * belliss * Recordv.PesoSp1 * CType(Recordv.Parent, Cilindro).SpessBase * NB '* EXP9
            anom = Record.posizione.AnomalR * PI / 180
            Quota = Record.posizione.QuotaR
2050:       Buco(Recordv, peso, Quota, Raggio, anom)
            DFor = 2 * System.Math.Sqrt(aelliss * belliss)
            Call ForaVecchio(1, Record, Recordv, Quota, Raggio, anom, NB, DFor, raggiop, peso, CType(Recordv.Parent, Cilindro).SpessBase)
        Else
            MsgBox(" caso in linea CilCil")
        End If
    End Sub
    Private Sub EseguiForo(ByVal Record As clsGenMem, ByVal Recordv As clsGenMem)
        NB = Record.Qta
2100:   peso = PI * aelliss * belliss * Recordv.PesoSp1 * Spess * NB '* EXP9
        anom = Record.posizione.AnomalR * PI / 180
        Quota = Record.posizione.QuotaR
        Raggio = Record.posizione.RaggioR
        Buco(Recordv, peso, Quota, Raggio, anom)
2110:   DFor = 2 * System.Math.Sqrt(aelliss * belliss)
        Call ForaVecchio(1, Record, Recordv, Quota, Raggio, anom, NB, DFor, raggiop, peso, Spess)
    End Sub
    Private Sub CilForCil(ByVal Record As clsGenMem, ByVal Recordv As clsGenMem)
        iProcedi = True
        If Record.Tipo = 10 Then
            If Record.Parent.TipoF > 4 Then If Record.Parent.Standard.K3 = 2 Then iProcedi = False
        End If
        If System.Math.Abs(Recordv.Tipo) = 34 And (System.Math.Abs(Record.Tipo) = 10 Or System.Math.Abs(Record.Tipo) = 14) And iProcedi Then
            Call VerifBordo(Record, Recordv, iProcedi)
            If Not iProcedi Then
                '                 Testo = at1(149) ' "Attenzione: il Bocchello                 |"
                '            Testo = Testo + RTrim$(Record.Denom) + at1(150) + Space$(1) + RTrim$(Recordv.Denom) ' " cade fuori del  |"
                '            Testo = Testo + "perimetro della membratura" + RTRIM$(Recordv.Denom)
                '         junk = Alert(4, Testo, 7, 9, 15, 59, at1(33), "", "")
            End If
        End If
        If iProcedi Then CilCil(Record, Recordv)
    End Sub
    Private Sub CilForFon(ByVal Record As clsGenMem, ByVal Recordv As clsGenMem)
        '           Prod = ProdScalar(Recordv.PosSpa.CosDiritta, Record.PosSpa.CosDiritta)
        '           IF ABS(Prod) < .9 THEN
        If Not Left(Record.posizione.DirDiritta, 2) = "=-" Then 'non sul collo
            If System.Math.Abs(Record.Tipo) = 10 Or System.Math.Abs(Record.Tipo) = 14 Then
                ' Rec2Buf(1) = Record
                ' If RecordD(0).Denom = Record.Denom Then Rec2Buf(1).Ind = 0
                aelliss = RaggioBocN(Record)
                raggiop = aelliss
            Else
                aelliss = Record.Parent.Diametro / 2 + Record.Parent.SpessBase
                raggiop = aelliss
            End If
            Raggio = Recordv.Parent.Diametro / 2 + CType(Recordv.Parent, Fondo).Piedritto
            If Raggio < aelliss Then
                Testo = "Messaggio di errore: non risulta possibile|"
                Testo = Testo & "intersecare il cilindro sul fondo.        |"
                MsgBox(Testo, MsgBoxResult.OK + MsgBoxStyle.Exclamation)
                Exit Sub
            End If
            If Recordv.Tipo < 5 Then Raggio = Raggio * 2
            ang = System.Math.Atan(aelliss / System.Math.Sqrt(Raggio ^ 2 - aelliss ^ 2))
2090:       aelliss = Raggio * ang
            Vect.X = Recordv.posizione.CosDiritta.X * Record.posizione.QuotaR + Record.posizione.CosOrigine.X * Record.posizione.RaggioR
            Vect.y = Recordv.posizione.CosDiritta.y * Record.posizione.QuotaR + Record.posizione.CosOrigine.y * Record.posizione.RaggioR
            Vect.Z = Recordv.posizione.CosDiritta.Z * Record.posizione.QuotaR + Record.posizione.CosOrigine.Z * Record.posizione.RaggioR
2310:       Modulo = System.Math.Sqrt(Vect.ProdScalar(Vect))
            If Modulo > TOLER Then
                CosAlfa = System.Math.Abs(Vect.ProdScalar((Record.posizione.CosDiritta))) / Modulo
2320:           belliss = aelliss / CosAlfa
            Else
                belliss = aelliss
            End If
            Spess = Recordv.Parent.SpessBase
            DFor = 2 * System.Math.Sqrt(aelliss * belliss)
            EseguiForo(Record, Recordv)
        Else
            MsgBox("Boc/cil su f in l")
        End If
    End Sub
    Private Sub CilForPia(ByVal Record As clsGenMem, ByVal Recordv As clsGenMem)
        If Left(Record.posizione.DirDiritta, 2) = Chr(61) & Chr(43) Then
            aelliss = Record.Parent.Diametro / 2 + Record.Parent.SpessBase
            If System.Math.Abs(Record.Tipo) = 10 Or System.Math.Abs(Record.Tipo) = 14 Then
                'Rec2Buf(1) = Record: If RecordD(0).Denom = Record.Denom Then Rec2Buf(1).Ind = 0
                aelliss = RaggioBocN(Record)
            End If
            belliss = aelliss
            raggiop = aelliss
            DFor = 2 * aelliss
            Spess = Recordv.Parent.SpessBase
            If Not (Mid(Record.posizione.Quota, 6, 1) = Chr(67) Or Mid(Record.posizione.Quota, 6, 1) = Chr(77) Or Mid(Record.posizione.Anomal, 6, 1) = Chr(67) Or Mid(Record.posizione.Anomal, 6, 1) = Chr(77)) Then EseguiForo(Record, Recordv)
            'GOSUB EseguiForo
        End If
    End Sub
    Private Sub IntStop(ByVal Record As clsGenMem, ByVal Recordv As clsGenMem)
        Testo = "La foratura di " & RTrim(Recordv.Denom) & " (tipo" & Str(Recordv.Tipo)
        Testo = Testo & ")| da parte di " & RTrim(Record.Denom) & " (tipo" & Str(Record.Tipo) & ") non è|"
        Testo = Testo & "stata prevista."
        MsgBox(Inizio.ConvertiCr(Testo), MsgBoxResult.OK + MsgBoxStyle.Exclamation)
    End Sub
    Private Sub TubiFora()
        NB = RecTubi.Qta
        If System.Math.Abs(RecTubi.Tipo) = 9 Then NB = NB * 2
        DFor = RecTubi.Parent.Diamext
        peso = PI / 4 * NB * DFor * DFor * RecPiastra.Parent.SpessBase * RecPiastra.PesoSp1 '* EXP9
        Quota = RecPiastra.Parent.SpessBase / 2 : Raggio = 0 : anom = 0
        Buco(RecPiastra, peso, Quota, Raggio, anom)
        Call ForaVecchio(1, RecTubi, RecPiastra, Quota, Raggio, anom, NB, DFor, DFor / 2, peso, RecPiastra.Parent.SpessBase)
    End Sub
    Private Sub FlanForTub(ByVal Record As clsGenMem, ByVal Recordv As clsGenMem)
        NB = Recordv.Qta
        If System.Math.Abs(Recordv.Tipo) = 9 Then NB = NB * 2
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Recordv.Parent.DiamExt. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
        DFor = Recordv.Parent.Diamext
2170:   'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Record.Parent.SpessBase. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
        peso = PI / 4 * NB * DFor * DFor * Record.Parent.SpessBase * Record.PesoSp1 '* EXP9
        Buco(Record, peso, (Recordv.posizione.QuotaR), 0.0!, 0.0!)
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Record.Parent.SpessBase. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
        Call ForaVecchio(-1, Recordv, Record, Quota, Raggio, anom, NB, DFor, DFor / 2, peso, Record.Parent.SpessBase)
    End Sub
    Private Sub TirForFlan(ByVal Record As clsGenMem, ByVal Recordv As clsGenMem)
        Call BucoTirFlan(Record, Recordv, Quota, Raggio, anom, NB, DFor, peso)
        Call ForaVecchio(1, Record, Recordv, Quota, Raggio, anom, NB, DFor, DFor / 2, peso)
    End Sub
    Private Sub FlanForTir(ByVal Record As clsGenMem, ByVal Recordv As clsGenMem, ByVal iSW As Short)
        DBul = CType(Recordv.Parent, clsTirante).StandardTir.Dnom
        DFor = 1.1 * DBul '????????????????????????????
        NB = Recordv.Qta
        If System.Math.Abs(Record.Tipo) = 11 Then
            Dim f As Flangione = Record.Parent
            With f
                Select Case Recordv.Parent.SottoTipo
                    Case 1
                        peso = PI / 4 * DFor * DFor * .SpessBase * NB
                    Case 2
                        peso = PI / 4 * DFor * DFor * (.SpessBase + .SpessGra) * NB
                    Case 3
                        peso = PI / 4 * DFor * DFor * DFor / 1.5 * NB
                End Select
                Quota = .H + .SpessBase / 2
            End With
        Else
            Dim p As Piastrone = Record.Parent
            With p
                Select Case .SottoTipo
                    Case 1, 2
                        peso = PI / 4 * DFor * DFor * .H3 * NB
                        Quota = .H1 + .H3 / 2
                    Case 3, 7
                        peso = PI / 4 * DFor * DFor * (.SpessBase - (.H3 - .H2) - .H4) * NB
                        Quota = .H4 + (.SpessBase - (.H3 - .H2) - .H4) / 2
                    Case 4, 6
                        peso = PI / 4 * DFor * DFor * (.SpessBase - 2 * .H1) * NB
                        Quota = .H1 + (.SpessBase - 2 * .H1) / 2
                    Case 5
                        peso = PI / 4 * DFor * DFor * (.SpessBase - .H1) * NB
                        Quota = .H1 + (.SpessBase - .H1) / 2
                End Select
            End With
        End If
        peso = peso * Record.PesoSp1 '* EXP9
        Buco(Record, peso, Quota, 0.0!, 0.0!)
        Call ForaVecchio(-1, Recordv, Record, Quota, Raggio, anom, NB, DFor, DFor / 2, peso)
        iSW = 2 'CALL CercaForoS(Recordv, Record.ind)
    End Sub
    Function CercaPos(ByVal x As Single, ByVal y As Single) As Membratura
        If IUNL <> 2 Then Return Nothing
        area0 = clsTrigon.Infinito
        imin = Nothing
        Dim n As OggList.NodeP = Apparecchio.Elementi.nodeHead.Next
        While Not n Is Nothing
            Dim gm As clsGenMem = n.TextData.genmem
            Dim nn As OggList.NodeP = gm.Segnalini.nodeHead.Next
            While Not nn Is Nothing
                Spots = nn.TextData
                Select Case Spots.Tipo
                    Case 1
                        Cerca1(x, y)
                    Case 2
                        Cerca2(x, y)
                    Case Is < 0 'non far niente
                End Select
                nn = nn.Next
            End While
            n = n.Next
        End While
        CercaPos = imin
    End Function
    Private Sub Cerca1(ByVal x As Single, ByVal y As Single)
        If Spots.Quadro.TopLeft.X > Spots.Quadro.Botrigt.X Then
            Dum = Spots.Quadro.TopLeft.X
            Spots.Quadro.TopLeft.X = Spots.Quadro.Botrigt.X
            Spots.Quadro.Botrigt.X = Dum
        End If
        If Spots.Quadro.TopLeft.y > Spots.Quadro.Botrigt.y Then
            Dum = Spots.Quadro.TopLeft.y
            Spots.Quadro.TopLeft.y = Spots.Quadro.Botrigt.y
            Spots.Quadro.Botrigt.y = Dum
        End If
        If Spots.Quadro.TopLeft.X < x And Spots.Quadro.Botrigt.X > x And Spots.Quadro.TopLeft.y < y And Spots.Quadro.Botrigt.y > y Then
            imin = Spots.indice
            Area = System.Math.Abs((Spots.Quadro.TopLeft.X - Spots.Quadro.Botrigt.X) * (Spots.Quadro.TopLeft.y - Spots.Quadro.Botrigt.y))
            If Area > area0 Then Area = area0 : imin = imin0
            area0 = Area : imin0 = imin
        End If
    End Sub
    Private Sub Cerca2(ByVal x As Single, ByVal y As Single)
        Dim Punto As New RoutBase1.clsVec2
        Punto.X = x : Punto.y = y
        If PunSpicchio(Punto, Spots.spicchio) = 2 Then Interno = True Else Interno = False
        If Interno Then
            imin = Spots.indice
            Area = (Spots.spicchio.RG - Spots.spicchio.RP) * Spots.spicchio.Alfa
            If Area > area0 Then Area = area0 : imin = imin0
            area0 = Area : imin0 = imin
        End If
    End Sub
    Public Sub SetInsert(ByRef t As System.Windows.Forms.Control)
        '   If InsertMode Then
        '   'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto t.SelLength. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
        '   t.SelLength = Len(t.Text)
        '   'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto t.SelStart. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
        '   t.SelStart = 0
        '   Else
        '       'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto t.SelLength. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
        '       t.SelLength = 0
        '       'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto t.SelStart. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
        '       t.SelStart = 0
        '   End If
    End Sub
    Public Sub TrattaCar(ByRef Index As Short, ByRef KeyAscii As Short, ByRef t As System.Windows.Forms.Control, ByRef Text1() As System.Windows.Forms.Control, ByRef Nc As Short)
        Dim i As Short
        On Error Resume Next
        Select Case KeyAscii
            Case System.Windows.Forms.Keys.Return, System.Windows.Forms.Keys.Down
                KeyAscii = System.Windows.Forms.Keys.Down : i = 1
                System.Windows.Forms.Application.DoEvents()
                Do
                    If Index + i <= Nc Then
                        If Text1(Index + i).Enabled Then
                            Text1(Index + i).Focus()
                            Exit Do
                        Else
                            i = i + 1
                        End If
                    Else
                        Text1(0).Focus()
                        Exit Do
                    End If
                Loop
            Case System.Windows.Forms.Keys.Insert
                InsertMode = Not InsertMode
                Call SetInsert(t)
            Case System.Windows.Forms.Keys.Up
                i = 1
                Do
                    If Index - i >= 0 Then
                        If Text1(Index - i).Enabled Then
                            Text1(Index - i).Focus()
                            Exit Do
                        Else
                            i = i + 1
                        End If
                    Else
                        Text1(Nc).Focus()
                        Exit Do
                    End If
                Loop
        End Select
        On Error GoTo 0
        Exit Sub
    End Sub
    Public Sub TrattaCar(ByRef Index As Short, ByRef KeyAscii As Short, ByRef t As System.Windows.Forms.Control, ByRef Text1 As ControlArray, ByRef Nc As Short)
        Dim i As Short
        On Error Resume Next
        Select Case KeyAscii
            Case System.Windows.Forms.Keys.Return, System.Windows.Forms.Keys.Down
                KeyAscii = System.Windows.Forms.Keys.Down : i = 1
                System.Windows.Forms.Application.DoEvents()
                Do
                    If Index + i <= Nc Then
                        If Text1(Index + i).Enabled Then
                            Text1(Index + i).Focus()
                            Exit Do
                        Else
                            i = i + 1
                        End If
                    Else
                        Text1(0).Focus()
                        Exit Do
                    End If
                Loop
            Case System.Windows.Forms.Keys.Insert
                InsertMode = Not InsertMode
                Call SetInsert(t)
            Case System.Windows.Forms.Keys.Up
                i = 1
                Do
                    If Index - i >= 0 Then
                        If Text1(Index - i).Enabled Then
                            Text1(Index - i).Focus()
                            Exit Do
                        Else
                            i = i + 1
                        End If
                    Else
                        Text1(Nc).Focus()
                        Exit Do
                    End If
                Loop
        End Select
        On Error GoTo 0
        Exit Sub
    End Sub
    Sub DisTira(ByRef Oggetto As clsTirante)
        '  On Local Error GoTo ErrTira
        posspa = Oggetto.GenMem.SwappedPos
        With Oggetto
            Lunghezza = .Lunghezza
            DADI = .nDadi 'n. di dadi
            Diam = .Dinst 'diametro di istallazione
            DBul = .StandardTir.Dnom 'Diametro bullone
            xFilv = .StandardTir.Xfil
            DS = .DiamScar 'diametro scarico
            If DS > DBul Then
                .DiamScar = 0
                DS = 0
            End If
            Chiave = .StandardTir.Chia 'Chiave
        End With
        If IUNL = 0 Then
            xSmin = -Lunghezza / 10 : ySmin = -0.6 * (Diam + DBul) : xSmax = 1.1 * Lunghezza : ySmax = -ySmin
            If Not Funzioni.DisRut.Scala(xSmin, xSmax, ySmin, ySmax) Then Exit Sub
        End If
        Direzione.X = 0 : Direzione.y = 0 : Direzione.Z = 1
        prod = posspa.CosDiritta.ProdScalar(Direzione)
        If System.Math.Abs(prod) > TOLER Then
            TiraSez(Oggetto)
        Else
            TiraLun(Oggetto)
        End If
    End Sub
    Private Sub TiraSez(ByVal Oggetto As clsTirante)
        NBull = Oggetto.GenMem.Qta
        z1 = posspa.Origine.Z
        z2 = posspa.Origine.Z + Lunghezza * posspa.CosDiritta.Z
        If z1 * z2 < 0 Then
            Verso = 0
        Else
            Verso = z1 : If z2 < z1 Then Verso = z2
            If Verso < 0 Then Exit Sub
        End If
        x = posspa.Origine.X '* Scalb!
        y = posspa.Origine.y '* Scalb!
        Ri = (Diam - DBul) / 2 ' * Scalb!
        Re = (Diam + DBul) / 2 '* Scalb!
        If IUNL = 4 Then
            Spots = New spot
500:        Spots.Tipo = 2
            Spots.Quota = Verso
            Spots.spicchio.Origin.X = x
            Spots.spicchio.Origin.y = y
            Spots.spicchio.RG = Re
            Spots.spicchio.RP = Ri
            Spots.spicchio.Alfa = 2 * PI
            RegisterSpot(Spots, Oggetto)
            Exit Sub
        End If
510:    Call Infilata(Oggetto, Verso, InMezzo)
        If InMezzo > 1 Then Exit Sub
        If InMezzo = 1 Then Call Funzioni.DisRut.ctrait(3, 0.1)
        Call Funzioni.DisRut.refere(x, y, 0)
        For i = 1 To NBull
            Alfa = (CSng(i) - 0.5) * 2 * PI / NBull
            dx = Diam / 2 * System.Math.Sin(Alfa) ' * Scalb!
            dy = Diam / 2 * System.Math.Cos(Alfa) '* Scalb!
            If DS > 0 And DS < DBul Then
                Raggio = DS / 2 '* Scalb!
                Call Funzioni.DisRut.cerc(dx, dy, Raggio)
            Else
                Raggio = DBul / 2 ' * Scalb!
                Call Funzioni.DisRut.cerc(dx, dy, Raggio)
                Raggio = Raggio * 0.8
                Call Funzioni.DisRut.arc(dx, dy, dx + Raggio, dy, 270.0!)
            End If
        Next
        If Verso > 0 And DADI > 0 Then
            For i = 1 To NBull
                Alfa = (CSng(i) - 0.5) * 2 * PI / NBull
                dx = Diam / 2 * System.Math.Sin(Alfa) ' * Scalb!
                dy = Diam / 2 * System.Math.Cos(Alfa) '* Scalb!
                Raggio = Chiave / 2 '* Scalb!
                Call Funzioni.DisRut.cerc(dx, dy, Raggio)
                Raggio = Raggio * 2 / System.Math.Sqrt(3)
                PuntiS = New RoutBase1.clsPunti
                PuntiS.Inizia(7)
                For j = 0 To 6
                    Alfa = j * PI / 3
                    PuntiS.Punti.Item(j + 1).TextData.X = dx + Raggio * System.Math.Sin(Alfa)
                    PuntiS.Punti.Item(j + 1).TextData.y = dy + Raggio * System.Math.Cos(Alfa)
                Next
                PuntiS.SpezzGraf(0, 6, Funzioni.DisRut)
            Next
        End If
        Call Funzioni.DisRut.refabs()
        Call Funzioni.DisRut.ctrait(0, 0.1)
    End Sub
    Private Sub TiraLun(ByVal Oggetto As clsTirante)
        Verso = posspa.Origine.Z
        If Verso < -DBul / 2 And IUNL < 4 Then Exit Sub
        If Verso > DBul / 2 And IUNL < 4 Then
            Call Infilata(Oggetto, Verso, InMezzo)
            If InMezzo > 1 Then Exit Sub
            If InMezzo = 1 Then Call Funzioni.DisRut.ctrait(3, 0.1)
        End If
        PuntiS = New RoutBase1.clsPunti : PuntiD = New RoutBase1.clsPunti
        PuntiS.Inizia(30) : PuntiD.Inizia(30)
        If DS = 0 Or System.Math.Abs(DBul - DS) < 1 Then
            Np = 12 : phi1 = 0.8 : phi2 = 0.9
            PuntiS.Punti0(1).y = DBul / 2 * phi1 : PuntiS.Punti0(1).X = 0
            PuntiS.Punti0(2).y = DBul / 2 * phi2 : PuntiS.Punti0(2).X = DBul / 2 * (phi2 - phi1)
            PuntiS.Punti0(3).y = DBul / 2 : PuntiS.Punti0(3).X = DBul / 2 * (1 - phi1)
            For i = 4 To 6
                PuntiS.Punti0(i).y = PuntiS.Punti0(7 - i).y : PuntiS.Punti0(i).X = Lunghezza - PuntiS.Punti0(7 - i).X
            Next
            For i = 7 To 12
                PuntiS.Punti0(i).X = PuntiS.Punti0(13 - i).X : PuntiS.Punti0(i).y = -PuntiS.Punti0(13 - i).y
            Next
        Else
            Np = 24 : phi1 = DS / DBul : phi2 = (1 + phi1) / 2 : phi3 = 0.25
            PuntiS.Punti0(1).y = DBul / 2 * phi1 : PuntiS.Punti0(1).X = 0
            PuntiS.Punti0(2).y = DBul / 2 * phi2 : PuntiS.Punti0(2).X = DBul / 2 * (phi2 - phi1)
            PuntiS.Punti0(3).y = DBul / 2 : PuntiS.Punti0(3).X = DBul / 2 * (1 - phi1)
            PuntiS.Punti0(4).y = PuntiS.Punti0(3).y : PuntiS.Punti0(4).X = DBul / 2 * (1 - phi1) + Lunghezza * phi3
            PuntiS.Punti0(5).y = PuntiS.Punti0(2).y : PuntiS.Punti0(5).X = PuntiS.Punti0(4).X + PuntiS.Punti0(3).X - PuntiS.Punti0(2).X
            PuntiS.Punti0(6).y = PuntiS.Punti0(1).y : PuntiS.Punti0(6).X = PuntiS.Punti0(4).X + PuntiS.Punti0(3).X
            For i = 7 To 12
                PuntiS.Punti0(i).y = PuntiS.Punti0(13 - i).y : PuntiS.Punti0(i).X = Lunghezza - PuntiS.Punti0(13 - i).X
            Next
            For i = 13 To 24
                PuntiS.Punti0(i).X = PuntiS.Punti0(25 - i).X : PuntiS.Punti0(i).y = -PuntiS.Punti0(25 - i).y
            Next
        End If
        PuntiS.Punti0(0).X = 0 : PuntiS.Punti0(0).y = 0 'origine locale
        For i = 1 To Np
            PuntiS.Punti0(i).y = PuntiS.Punti0(i).y + Diam / 2
        Next
        Call TrasfGen(posspa, PuntiS, PuntiD, 0, Np, True)
        'PuntiS.Punti0(Np).x = PuntiS.Punti0(0).x
        'PuntiS.Punti0(Np).y = PuntiS.Punti0(0).y
        'PuntiD.Punti0(Np).x = PuntiD.Punti0(0).x
        'PuntiD.Punti0(Np).y = PuntiD.Punti0(0).y
        If IUNL = 4 Then
            Spots = New spot
            Spots.Tipo = 1
            Spots.Quota = Verso
            Spots.Quadro.TopLeft.X = GlobalRoutines.Minimo(PuntiS.Punti0(1).X, PuntiS.Punti0(Np \ 2 + 1).X)
            Spots.Quadro.TopLeft.y = GlobalRoutines.Minimo(PuntiS.Punti0(1).y, PuntiS.Punti0(Np \ 2 + 1).y)
            Spots.Quadro.Botrigt.X = GlobalRoutines.Massimo(PuntiS.Punti0(1).X, PuntiS.Punti0(Np \ 2 + 1).X)
            Spots.Quadro.Botrigt.y = GlobalRoutines.Massimo(PuntiS.Punti0(1).y, PuntiS.Punti0(Np \ 2 + 1).y)
            RegisterSpot(Spots, Oggetto)
            Spots = New spot
            Spots.Tipo = 1
            Spots.Quota = 0
            Spots.Quadro.TopLeft.X = GlobalRoutines.Minimo(PuntiD.Punti0(1).X, PuntiD.Punti0(Np \ 2 + 1).X)
            Spots.Quadro.TopLeft.y = GlobalRoutines.Minimo(PuntiD.Punti0(1).y, PuntiD.Punti0(Np \ 2 + 1).y)
            Spots.Quadro.Botrigt.X = GlobalRoutines.Massimo(PuntiD.Punti0(1).X, PuntiD.Punti0(Np \ 2 + 1).X)
            Spots.Quadro.Botrigt.y = GlobalRoutines.Massimo(PuntiD.Punti0(1).y, PuntiD.Punti0(Np \ 2 + 1).y)
            RegisterSpot(Spots, Oggetto)
            Exit Sub
        End If
        PuntiS.SpezzGraf(1, Np, Funzioni.DisRut) : PuntiD.SpezzGraf(1, Np, Funzioni.DisRut)
        Funzioni.DisRut.tratto((PuntiS.Punti0(1).X), (PuntiS.Punti0(1).y), (PuntiS.Punti0(Np).X), (PuntiS.Punti0(Np).y), 0.1, 0)
        Funzioni.DisRut.tratto((PuntiD.Punti0(1).X), (PuntiD.Punti0(1).y), (PuntiD.Punti0(Np).X), (PuntiD.Punti0(Np).y), 0.1, 0)
        If IUNL < 3 Then
        End If
440:    Funzioni.DisRut.tratto((PuntiS.Punti0(2).X), (PuntiS.Punti0(2).y), (PuntiS.Punti0(5).X), (PuntiS.Punti0(5).y), 0.1, 0)
        Funzioni.DisRut.tratto((PuntiS.Punti0(8).X), (PuntiS.Punti0(8).y), (PuntiS.Punti0(11).X), (PuntiS.Punti0(11).y), 0.1, 0)
        If Np = 24 Then
            Funzioni.DisRut.tratto((PuntiS.Punti0(14).X), (PuntiS.Punti0(14).y), (PuntiS.Punti0(17).X), (PuntiS.Punti0(17).y), 0.1, 0)
            Funzioni.DisRut.tratto((PuntiS.Punti0(20).X), (PuntiS.Punti0(20).y), (PuntiS.Punti0(23).X), (PuntiS.Punti0(23).y), 0.1, 0)
        End If
        Funzioni.DisRut.tratto((PuntiD.Punti0(2).X), (PuntiD.Punti0(2).y), (PuntiD.Punti0(5).X), (PuntiD.Punti0(5).y), 0.1, 0)
        Funzioni.DisRut.tratto((PuntiD.Punti0(8).X), (PuntiD.Punti0(8).y), (PuntiD.Punti0(11).X), (PuntiD.Punti0(11).y), 0.1, 0)
        If Np = 24 Then
            Funzioni.DisRut.tratto((PuntiD.Punti0(14).X), (PuntiD.Punti0(14).y), (PuntiD.Punti0(17).X), (PuntiD.Punti0(17).y), 0.1, 0)
            Funzioni.DisRut.tratto((PuntiD.Punti0(20).X), (PuntiD.Punti0(20).y), (PuntiD.Punti0(23).X), (PuntiD.Punti0(23).y), 0.1, 0)
        End If
        Funzioni.DisRut.tratto((PuntiS.Punti0(1).X + PuntiS.Punti0(Np).X) / 2, (PuntiS.Punti0(1).y + PuntiS.Punti0(Np).y) / 2, (PuntiS.Punti0(Np \ 2).X + PuntiS.Punti0(Np \ 2 + 1).X) / 2, (PuntiS.Punti0(Np \ 2).y + PuntiS.Punti0(Np \ 2 + 1).y) / 2, 0.1, 3)
        Funzioni.DisRut.tratto((PuntiD.Punti0(1).X + PuntiD.Punti0(Np).X) / 2, (PuntiD.Punti0(1).y + PuntiD.Punti0(Np).y) / 2, (PuntiD.Punti0(Np \ 2).X + PuntiD.Punti0(Np \ 2 + 1).X) / 2, (PuntiD.Punti0(Np \ 2).y + PuntiD.Punti0(Np \ 2 + 1).y) / 2, 0.1, 3)
        'UPGRADE_WARNING: Return ha un nuovo comportamento. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1041"'
        Return
    End Sub
    Sub DisTegola(ByRef Oggetto As Cilindro)
        posspa = Oggetto.GenMem.SwappedPos
        With Oggetto
            Al = .Lunghezza
            d = .Diametro
            t = .SpessBase
            An = .AngTegola * PI / 180
        End With
        If IUNL < 1 Then Exit Sub
        Direzione.X = 0 : Direzione.y = 0 : Direzione.Z = 1
        prod = posspa.CosDiritta.ProdScalar(Direzione)
        If System.Math.Abs(prod) < TOLER Then
            SezLun()
        Else
            SezRettT()
        End If
    End Sub
    Private Sub SezLun()
        If IUNL = 0 Then
            xSmin = -Al / 5 : ySmin = 1.2 * (-(d + t * 2) / 2) : xSmax = 1.5 * Al : ySmax = -ySmin
            If Not Funzioni.DisRut.Scala(xSmin, xSmax, ySmin, ySmax) Then Exit Sub
        End If
        DirR.X = posspa.CosTerza.Z : DirR.y = posspa.CosTerza.y
        anom = GlobalRoutines.arco((DirR.X), (DirR.y))
        If anom + An / 2 > 1.5 * PI And anom - An / 2 < 1.5 * PI Then
            Raggio = d / 2 + t
        ElseIf anom + An / 2 > 0.5 * PI And anom - An / 2 < 0.5 * PI Then
            Raggio = d / 2 + t
        Else
            'in vista
            Exit Sub
        End If 'd
        Call LeggiBuchi(Oggetto, jsopra, quosopra, DBucosopra, jsotto, quosotto, DBucosotto, (Al), (Al))
        Raggio = Raggio * posspa.CosTerza.y
        If Raggio > 0 Then
            Call SemiCil(posspa, jsopra, quosopra, DBucosopra, (t), Raggio, (d), Rett, 0.0!, 0.0!, 0.0!, 0.0!)
        Else
            Call SemiCil(posspa, jsotto, quosotto, DBucosotto, (t), Raggio, (d), Rett, 0.0!, 0.0!, 0.0!, 0.0!)
        End If
        R1 = posspa.Origine.ProdScalar((posspa.CosDiritta))
        Call CercaInt(Oggetto, R1, Dint1, d)
        Direzione.X = posspa.Origine.X + Al * posspa.CosDiritta.X
        Direzione.y = posspa.Origine.y + Al * posspa.CosDiritta.y
        Direzione.Z = posspa.Origine.Z + Al * posspa.CosDiritta.Z
        R2 = Direzione.ProdScalar((posspa.CosDiritta))
        Call CercaInt(Oggetto, R2, Dint2, d)
        If Dint2 > Dint1 Then Dint1 = Dint2
        quotlinea = d / 2 * System.Math.Abs(System.Math.Sin(anom - An / 2)) * System.Math.Sign(Raggio)
        If An > PI Then quotlinea = -quotlinea
        If System.Math.Abs(quotlinea) > Dint1 Then
            PuntiS = New RoutBase1.clsPunti
            PuntiS.Inizia(5)
            PuntiS.Punti0(0).X = 0 : PuntiS.Punti0(0).y = Raggio
            PuntiS.Punti0(1).X = 0 : PuntiS.Punti0(1).y = quotlinea
            PuntiS.Punti0(2).X = Al : PuntiS.Punti0(2).y = quotlinea
            PuntiS.Punti0(3).X = Al : PuntiS.Punti0(3).y = Raggio
            PuntiS.Punti0(4).X = 0 : PuntiS.Punti0(4).y = 0
            Call TrasfGen(posspa, PuntiS, Nothing, 4, 3, False) '-
            If IUNL < 4 Then PuntiS.SpezzGraf(0, 3, Funzioni.DisRut)
        End If
        If IUNL = 4 Then
            Spots = New spot
            Spots.Tipo = 1
            Spots.Quadro.TopLeft.X = GlobalRoutines.Minimo(Rett.Corners(1).X, Rett1.Corners(2).X, Rett.Corners(3).X, Rett1.Corners(4).X)
            Spots.Quadro.TopLeft.y = GlobalRoutines.Minimo(Rett.Corners(1).y, Rett1.Corners(2).y, Rett.Corners(3).y, Rett1.Corners(4).y)
            Spots.Quadro.Botrigt.X = GlobalRoutines.Massimo(Rett.Corners(1).X, Rett1.Corners(2).X, Rett.Corners(3).X, Rett1.Corners(4).X)
            Spots.Quadro.Botrigt.y = GlobalRoutines.Massimo(Rett.Corners(1).y, Rett1.Corners(2).y, Rett.Corners(3).y, Rett1.Corners(4).y)
            If System.Math.Abs(quotlinea) > Dint1 Then
                Spots.Quadro.Botrigt.X = PuntiS.Punti0(2).X
                Spots.Quadro.Botrigt.y = PuntiS.Punti0(2).y
            End If
            RegisterSpot(Spots, Oggetto)
            Exit Sub
        End If 'g
    End Sub
    Private Sub SezRettT()
        If IUNL = 1 Then Exit Sub
        z1 = posspa.Origine.Z
        z2 = posspa.Origine.Z + Al * posspa.CosDiritta.Z
        If z1 * z2 < 0 Then Verso = 0 Else Verso = (z1 + z2) / 2
        If Verso < 0 Then Return
        If IUNL < 4 Then
            Call Infilata(Oggetto, Verso, InMezzo)
            If InMezzo > 1 Then Return
            '         If inMezzo = 1 Then Call Funzioni.DisRut.ctrait(3, 0.1)
        End If
        SP = New Spicchio4
        SP.RG = d / 2 + t : SP.RP = d / 2
        SP.Alfa = An
        SP.Origin.X = posspa.Origine.X
        SP.Origin.y = posspa.Origine.y
        SP.Direct.X = posspa.CosTerza.X
        SP.Direct.y = posspa.CosTerza.y
        '         Trasfspicchio Sp, Scalb!, offx!, offy!
        If IUNL = 4 Then
            Spots = New spot
            Spots.Tipo = 2
            Spots.Quota = Verso
            Spots.spicchio = SP
            RegisterSpot(Spots, Oggetto)
            Exit Sub
        Else
            SP.SpicGraf(0, PuntiS, PuntiD) ' non pittura 1 pittura
            '            Call Funzioni.DisRut.ctrait(0, 0.1)
        End If 'h
    End Sub 'd
    Sub DisFlan(ByRef Oggetto As Flangione)
        posspa = Oggetto.GenMem.SwappedPos
        '-----------------------------------
        R = 10 'raggio raccordo
        '----------------------------------
        With Oggetto
            If .g0 = 0 Or .g1 = 0 Then .H = 0
            If .DiamGra = 0 Then .DiamGra = .DiamExt
            Hhub = .H : Thub = .SpessBase : SGhub = .SpessGra
            If .SottoTipo = 4 Then
                If .g02 = 0 Or .g12 = 0 Then .H2 = 0
                Hhub1 = .H2 : SGhub1 = .SpessGra2 : ADG1 = .DiamGra2
                If ADG1 = 0 Then ADG1 = .DiamExt
            End If
            'If IUNL = 1 Then
            '   Call ScalaRel(posspa, xSmin, ySmin, xSmax, ySmax)
            '   Exit Sub
            'End If
            Direzione.X = 0 : Direzione.y = 0 : Direzione.Z = 1
            prod = posspa.CosDiritta.ProdScalar(Direzione)
2010:       If System.Math.Abs(prod) > TOLER Then
                InVista(Oggetto)
                Exit Sub
            End If
            If IUNL = 0 Then
                xSmin = -.SpessBase / 10 : ySmin = -0.6 * .DiamExt
                xSmax = 1.2 * (.SpessBase + .H + .SpessGra) : ySmax = -ySmin
                If Not Funzioni.DisRut.Scala(xSmin, xSmax, ySmin, ySmax) Then Exit Sub
            End If
            PuntiS = New RoutBase1.clsPunti : PuntiD = New RoutBase1.clsPunti
            PuntiS.Inizia(40) : PuntiD.Inizia(40)
            Verso = posspa.Origine.Z
            If Verso < -.DiamExt / 2 And Not IUNL = 4 Then Exit Sub
            If Verso > .DiamExt / 2 Then
                If .SottoTipo < 4 Then
                    Tipo123S(Oggetto)
                Else
                    Tipo4S()
                End If
            Else
                If .SottoTipo < 4 Then
                    Tipo123(Oggetto)
                Else
                    Tipo4(Oggetto)
                End If
            End If
        End With
    End Sub
    Private Sub CalcolR()
        Dim Fine3 As New RoutBase1.clsVec3
        Fine3.X = posspa.Origine.X + Displ * posspa.CosDiritta.X
        Fine3.y = posspa.Origine.y + Displ * posspa.CosDiritta.y
        Fine3.Z = posspa.Origine.Z + Displ * posspa.CosDiritta.Z
        R1 = Fine3.ProdScalar((posspa.CosDiritta))
    End Sub
    Private Sub InVista(ByVal Oggetto As Flangione)
162:    z1 = posspa.Origine.Z
261:    z2 = posspa.Origine.Z + (Oggetto.SpessBase + Hhub) * posspa.CosDiritta.Z
        If z1 * z2 < 0 Then Verso = 0 Else Verso = (z1 + z2) / 2
        If Verso < 0 Then Exit Sub
        x = posspa.Origine.X '* Scalb!
        y = posspa.Origine.y '* Scalb!
        Ri = Oggetto.DiamInt / 2 '* Scalb!
        Re = Oggetto.DiamExt / 2 '* Scalb!
        If IUNL < 4 Then
            Call Infilata(Oggetto, Verso, InMezzo)
            If InMezzo > 1 Then Exit Sub
            If InMezzo = 1 Then Call Funzioni.DisRut.ctrait(3, 0.1)
            '163      Call Funzioni.DisRut.refere(offx!, offy!, 0)
            Call Funzioni.DisRut.cerc(x, y, Ri)
            Call Funzioni.DisRut.cerc(x, y, Re)
164:        Call Funzioni.DisRut.refabs()
            Call Funzioni.DisRut.ctrait(0, 0.1)
        End If
        If IUNL = 4 Then
            Spots = New spot
            Spots.Tipo = 2
            Spots.Quota = Verso
            Spots.spicchio.Origin.X = x
            Spots.spicchio.Origin.y = y
            Spots.spicchio.RG = Re
            Spots.spicchio.RP = Ri
            Spots.spicchio.Alfa = 2 * PI
            RegisterSpot(Spots, Oggetto)
        End If
    End Sub
    Private Sub ConSenHub(ByVal Oggetto As Flangione)
        If Hhub * (Oggetto.g1 - Oggetto.g0) > 0 Then
            Alfa = System.Math.Atan(Hhub / (Oggetto.g1 - Oggetto.g0))
            PuntiS.Punti0(6 + iOff).X = Hhub : PuntiS.Punti0(6 + iOff).y = Oggetto.DiamInt / 2 + Oggetto.g1 + R * System.Math.Sin(Alfa)
            PuntiS.Punti0(7 + iOff).X = Hhub - R * (1 - System.Math.Cos(Alfa)) : PuntiS.Punti0(7 + iOff).y = Oggetto.DiamInt / 2 + Oggetto.g1
            PuntiS.Punti0(8 + iOff).X = 0 : PuntiS.Punti0(8 + iOff).y = Oggetto.DiamInt / 2 + Oggetto.g0
            PuntiS.Punti0(0).copia(PuntiS.Punti0(9 + iOff))
            PuntiS.Punti0(10 + iOff).X = PuntiS.Punti0(6 + iOff).X - R : PuntiS.Punti0(10 + iOff).y = PuntiS.Punti0(6 + iOff).y 'centro raccordo
            Direz1.X = System.Math.Cos(Alfa / 2) : Direz2.X = Direz1.X
            Direz1.y = -System.Math.Sin(Alfa / 2) : Direz2.y = -Direz1.y
            'Direz1.y = Sin(Alfa / 2):       Direz2.y = -Direz1.y
        ElseIf Hhub > 0 And Oggetto.g1 = Oggetto.g0 Then
            If R > 0.5 * Hhub Then R = 0.5 * Hhub
            PuntiS.Punti0(6 + iOff).X = Hhub : PuntiS.Punti0(6 + iOff).y = Oggetto.DiamInt / 2 + Oggetto.g1 + R
            PuntiS.Punti0(7 + iOff).X = Hhub - R : PuntiS.Punti0(7 + iOff).y = Oggetto.DiamInt / 2 + Oggetto.g1
            PuntiS.Punti0(8 + iOff).X = 0 : PuntiS.Punti0(8 + iOff).y = Oggetto.DiamInt / 2 + Oggetto.g0
            PuntiS.Punti0(0).copia(PuntiS.Punti0(9 + iOff))
            PuntiS.Punti0(10 + iOff).X = PuntiS.Punti0(6 + iOff).X - R : PuntiS.Punti0(10 + iOff).y = PuntiS.Punti0(6 + iOff).y 'centro raccordo
            Alfa = PI / 2
            Direz1.X = System.Math.Cos(Alfa / 2) : Direz2.X = Direz1.X
            Direz1.y = -System.Math.Sin(Alfa / 2) : Direz2.y = -Direz1.y
        ElseIf Hhub = 0 Then
            PuntiS.Punti0(0).copia(PuntiS.Punti0(6 + iOff))
            PuntiS.Punti0(0).copia(PuntiS.Punti0(7 + iOff))
            PuntiS.Punti0(0).copia(PuntiS.Punti0(8 + iOff))
            PuntiS.Punti0(0).copia(PuntiS.Punti0(9 + iOff))
        End If
    End Sub
    Private Sub ConSenHub1(ByVal Oggetto As Flangione)
        If Hhub1 * (Oggetto.g12 - Oggetto.g02) > 0 Then
            Alfa1 = System.Math.Atan(Hhub1 / (Oggetto.g12 - Oggetto.g02))
            PuntiS.Punti0(5).X = PuntiS.Punti0(1).X - Hhub1 : PuntiS.Punti0(5).y = Oggetto.DiamInt / 2 + Oggetto.g12 + R * System.Math.Sin(Alfa)
            PuntiS.Punti0(3).X = PuntiS.Punti0(1).X - (Hhub1 - R * (1 - System.Math.Cos(Alfa1))) : PuntiS.Punti0(3).y = Oggetto.DiamInt / 2 + Oggetto.g12
            PuntiS.Punti0(2).X = PuntiS.Punti0(1).X : PuntiS.Punti0(2).y = Oggetto.DiamInt / 2 + Oggetto.g02
            PuntiS.Punti0(4).X = PuntiS.Punti0(5).X + R : PuntiS.Punti0(4).y = PuntiS.Punti0(5).y 'centro raccordo
            Direz11.X = -System.Math.Cos(Alfa1 / 2) : Direz21.X = Direz11.X
            Direz11.y = -System.Math.Sin(Alfa1 / 2) : Direz21.y = -Direz11.y
            '        IF IUNL = 3 THEN Direz1.y = -Direz1.y: Direz2.y = -Direz2.y
        ElseIf Hhub1 > 0 And Oggetto.g12 = Oggetto.g02 Then
            If R > 0.5 * Hhub1 Then R = 0.5 * Hhub
            PuntiS.Punti0(5).X = PuntiS.Punti0(1).X - Hhub1 : PuntiS.Punti0(5).y = Oggetto.DiamInt / 2 + Oggetto.g12 + R
            PuntiS.Punti0(3).X = PuntiS.Punti0(1).X - (Hhub1 - R) : PuntiS.Punti0(3).y = Oggetto.DiamInt / 2 + Oggetto.g12
            PuntiS.Punti0(2).X = PuntiS.Punti0(1).X : PuntiS.Punti0(2).y = Oggetto.DiamInt / 2 + Oggetto.g02
            PuntiS.Punti0(4).X = PuntiS.Punti0(5).X + R : PuntiS.Punti0(4).y = PuntiS.Punti0(5).y 'centro raccordo
            Alfa1 = PI / 2
            Direz11.X = -System.Math.Cos(Alfa1 / 2) : Direz21.X = Direz11.X
            Direz11.y = -System.Math.Sin(Alfa1 / 2) : Direz21.y = -Direz11.y
        ElseIf Hhub1 = 0 Then
            PuntiS.Punti0(1).copia(PuntiS.Punti0(2))
            PuntiS.Punti0(1).copia(PuntiS.Punti0(3))
            PuntiS.Punti0(1).copia(PuntiS.Punti0(4))
            PuntiS.Punti0(1).copia(PuntiS.Punti0(5))
        End If
    End Sub
    Private Sub Tipo123S(ByVal Oggetto As Flangione)
        With Oggetto
            PuntiS.Punti0(0).X = 0 : PuntiS.Punti0(0).y = Oggetto.DiamInt / 2
            Select Case .SottoTipo
                Case 1 'gradino maschio
                    PuntiS.Punti0(1).X = .SpessBase - .SpessGra + Hhub
                    PuntiS.Punti0(1).y = 0
                Case 2 'gradino femmina
                    PuntiS.Punti0(1).X = .SpessBase + Hhub
                    PuntiS.Punti0(1).y = 0
                Case 3 'rovescio/femmina
                    MsgBox("rovescio/femmina")
                    Exit Sub
            End Select
            PuntiS.Punti0(2).X = PuntiS.Punti0(1).X : PuntiS.Punti0(2).y = .DiamExt / 2
            PuntiS.Punti0(3).X = PuntiS.Punti0(2).X - .SpessBase : PuntiS.Punti0(3).y = PuntiS.Punti0(2).y
            PuntiS.Punti0(4).X = PuntiS.Punti0(3).X : PuntiS.Punti0(4).y = 0
            iOff = 0
            ConSenHub(Oggetto) ' 10 centro dell'arco; 6,7 astremi dell'arco 8 piede hub
            PuntiS.Punti0(13).X = 0 : PuntiS.Punti0(13).y = 0 'origine locale
            Call TrasfGen(posspa, PuntiS, PuntiD, 13, 12, True)
            If IUNL = 4 Then
                Spots = New spot
                Spots.Tipo = 1
                Spots.Quota = Verso
                Spots.Quadro.TopLeft.X = GlobalRoutines.Minimo(PuntiS.Punti0(0).X, PuntiD.Punti0(2).X)
                Spots.Quadro.TopLeft.y = GlobalRoutines.Minimo(PuntiS.Punti0(0).y, PuntiD.Punti0(2).y)
                Spots.Quadro.Botrigt.X = GlobalRoutines.Massimo(PuntiS.Punti0(0).X, PuntiD.Punti0(2).X)
                Spots.Quadro.Botrigt.y = GlobalRoutines.Massimo(PuntiS.Punti0(0).y, PuntiD.Punti0(2).y)
                RegisterSpot(Spots, Oggetto)
                Exit Sub
            End If
            PuntiS.SpezzGraf(1, 4, Funzioni.DisRut)
            PuntiD.SpezzGraf(1, 4, Funzioni.DisRut)
            DisArco()
            Funzioni.DisRut.tratto((PuntiS.Punti0(7).X), (PuntiS.Punti0(7).y), (PuntiS.Punti0(8).X), (PuntiS.Punti0(8).y), 0.1, 0)
            Funzioni.DisRut.tratto((PuntiD.Punti0(7).X), (PuntiD.Punti0(7).y), (PuntiD.Punti0(8).X), (PuntiD.Punti0(8).y), 0.1, 0)
            Funzioni.DisRut.tratto((PuntiS.Punti0(8).X), (PuntiS.Punti0(8).y), (PuntiS.Punti0(5).X), (PuntiS.Punti0(5).y), 0.1, 0)
            Funzioni.DisRut.tratto((PuntiD.Punti0(8).X), (PuntiD.Punti0(8).y), (PuntiD.Punti0(5).X), (PuntiD.Punti0(5).y), 0.1, 0)
        End With
    End Sub
    Private Sub Tipo123(ByVal Oggetto As Flangione)
        PuntiS.Punti0(0).X = 0 : PuntiS.Punti0(0).y = Oggetto.DiamInt / 2
        PuntiS.Punti0(1).X = Oggetto.SpessBase - Oggetto.SpessGra + Hhub : PuntiS.Punti0(1).y = Oggetto.DiamInt / 2
        PuntiS.Punti0(2).X = Oggetto.SpessBase - Oggetto.SpessGra + Hhub : PuntiS.Punti0(2).y = Oggetto.DiamGra / 2
        PuntiS.Punti0(3).X = Oggetto.SpessBase + Hhub : PuntiS.Punti0(3).y = Oggetto.DiamGra / 2
        PuntiS.Punti0(4).X = Oggetto.SpessBase + Hhub : PuntiS.Punti0(4).y = Oggetto.DiamExt / 2
        PuntiS.Punti0(5).X = Hhub : PuntiS.Punti0(5).y = Oggetto.DiamExt / 2
        Select Case Oggetto.SottoTipo
            Case 1 'gradino maschio
                PuntiS.Punti0(1).X = Oggetto.SpessBase + Oggetto.SpessGra + Hhub : PuntiS.Punti0(1).y = Oggetto.DiamInt / 2
                PuntiS.Punti0(2).X = Oggetto.SpessBase + Oggetto.SpessGra + Hhub : PuntiS.Punti0(2).y = Oggetto.DiamGra / 2
            Case 2 'gradino femmina
            Case 3 'rovescio/femmina
                PuntiS.Punti0(0).X = 0 : PuntiS.Punti0(0).y = Oggetto.DiamExt / 2
                PuntiS.Punti0(1).X = Oggetto.SpessBase + Oggetto.SpessGra + Hhub : PuntiS.Punti0(1).y = Oggetto.DiamExt / 2
                PuntiS.Punti0(2).X = Oggetto.SpessBase + Oggetto.SpessGra + Hhub : PuntiS.Punti0(2).y = Oggetto.DiamGra / 2
                PuntiS.Punti0(4).X = Oggetto.SpessBase + Hhub : PuntiS.Punti0(4).y = Oggetto.DiamInt / 2
                PuntiS.Punti0(5).X = Hhub : PuntiS.Punti0(5).y = Oggetto.DiamInt / 2
        End Select
        iOff = 0
        ConSenHub(Oggetto)
        PuntiS.Punti0(11).X = PuntiS.Punti0(0).X : PuntiS.Punti0(11).y = PuntiS.Punti0(0).y - Oggetto.SpessRive
        PuntiS.Punti0(12).X = PuntiS.Punti0(1).X : PuntiS.Punti0(12).y = PuntiS.Punti0(1).y - Oggetto.SpessRive
        PuntiS.Punti0(13).X = 0 : PuntiS.Punti0(13).y = 0 'origine locale
2030:   Diam = 0
        If IUNL = 2 Or IUNL = 3 Then
            Call Apparecchio.CercaBul(Oggetto, Diam, DBul)
            Select Case Oggetto.SottoTipo
                Case 1
                    Displ = PuntiS.Punti0(0).X
                    CalcolR()
                    Call CercaInt(Oggetto, R1, Dint, (Oggetto.DiamInt)) : PuntiS.Punti0(20).X = PuntiS.Punti0(0).X : PuntiS.Punti0(20).y = Dint / 2
                    Displ = PuntiS.Punti0(1).X
                    CalcolR()
                    Call CercaInt(Oggetto, R1, Dint, (Oggetto.DiamInt)) : PuntiS.Punti0(21).X = PuntiS.Punti0(1).X : PuntiS.Punti0(21).y = Dint / 2
                Case 2
                    Displ = PuntiS.Punti0(0).X
                    CalcolR()
                    Call CercaInt(Oggetto, R1, Dint, (Oggetto.DiamInt)) : PuntiS.Punti0(20).X = PuntiS.Punti0(0).X : PuntiS.Punti0(20).y = Dint / 2
                    Displ = PuntiS.Punti0(1).X
                    CalcolR()
                    Call CercaInt(Oggetto, R1, Dint, (Oggetto.DiamInt)) : PuntiS.Punti0(21).X = PuntiS.Punti0(1).X : PuntiS.Punti0(21).y = Dint / 2
                    Displ = PuntiS.Punti0(3).X
                    CalcolR()
                    Call CercaInt(Oggetto, R1, Dint, (Oggetto.DiamGra)) : PuntiS.Punti0(23).X = PuntiS.Punti0(3).X : PuntiS.Punti0(23).y = Dint / 2
                Case 3
                    Displ = PuntiS.Punti0(2).X
                    CalcolR()
                    Call CercaInt(Oggetto, R1, Dint, (Oggetto.DiamGra)) : PuntiS.Punti0(22).X = PuntiS.Punti0(2).X : PuntiS.Punti0(22).y = Dint / 2
                    Displ = PuntiS.Punti0(4).X
                    CalcolR()
                    Call CercaInt(Oggetto, R1, Dint, (Oggetto.DiamInt)) : PuntiS.Punti0(24).X = PuntiS.Punti0(4).X : PuntiS.Punti0(24).y = Dint / 2
                    Displ = PuntiS.Punti0(5).X
                    CalcolR()
                    Call CercaInt(Oggetto, R1, Dint, (Oggetto.DiamInt)) : PuntiS.Punti0(25).X = PuntiS.Punti0(5).X : PuntiS.Punti0(25).y = Dint / 2
                    Displ = PuntiS.Punti0(8).X
                    CalcolR()
                    Call CercaInt(Oggetto, R1, Dint, Oggetto.DiamExt - 2 * Oggetto.g0) : PuntiS.Punti0(28).X = PuntiS.Punti0(8).X : PuntiS.Punti0(28).y = Dint / 2
            End Select
        End If
        If Diam > 0 Then
2040:       PuntiS.Punti0(14).X = PuntiS.Punti0(3).X : PuntiS.Punti0(15).X = PuntiS.Punti0(3).X : PuntiS.Punti0(16).X = PuntiS.Punti0(5).X : PuntiS.Punti0(17).X = PuntiS.Punti0(5).X
            PuntiS.Punti0(14).y = Diam / 2 - 0.6 * DBul : PuntiS.Punti0(17).y = PuntiS.Punti0(14).y : PuntiS.Punti0(15).y = Diam / 2 + 0.6 * DBul : PuntiS.Punti0(16).y = PuntiS.Punti0(15).y
        End If
        Call TrasfGen(posspa, PuntiS, PuntiD, 13, 28, True)
        If IUNL = 4 Then
            Spots = New spot
            Spots.Tipo = 1
            Spots.Quota = Verso
            Spots.Quadro.TopLeft.X = GlobalRoutines.Minimo(PuntiS.Punti0(5).X, PuntiD.Punti0(4).X)
            Spots.Quadro.TopLeft.y = GlobalRoutines.Minimo(PuntiS.Punti0(5).y, PuntiD.Punti0(4).y)
            Spots.Quadro.Botrigt.X = GlobalRoutines.Massimo(PuntiS.Punti0(5).X, PuntiD.Punti0(4).X)
            Spots.Quadro.Botrigt.y = GlobalRoutines.Massimo(PuntiS.Punti0(5).y, PuntiD.Punti0(4).y)
            RegisterSpot(Spots, Oggetto)
            Exit Sub
        End If
        If Diam = 0 Then
            PuntiS.SpezzGraf(0, 6, Funzioni.DisRut) : PuntiS.SpezzGraf(7, 9, Funzioni.DisRut)
            PuntiD.SpezzGraf(0, 6, Funzioni.DisRut) : PuntiD.SpezzGraf(7, 9, Funzioni.DisRut)
        Else
2052:       PuntiS.SpezzGraf(0, 3, Funzioni.DisRut)
            Funzioni.DisRut.tratto((PuntiS.Punti0(3).X), (PuntiS.Punti0(3).y), (PuntiS.Punti0(14).X), (PuntiS.Punti0(14).y), 0.1, 0)
            Funzioni.DisRut.tratto((PuntiS.Punti0(14).X), (PuntiS.Punti0(14).y), (PuntiS.Punti0(17).X), (PuntiS.Punti0(17).y), 0.1, 0)
            Funzioni.DisRut.tratto((PuntiS.Punti0(17).X), (PuntiS.Punti0(17).y), (PuntiS.Punti0(6).X), (PuntiS.Punti0(6).y), 0.1, 0)
            '--------------
            Funzioni.DisRut.tratto((PuntiS.Punti0(15).X), (PuntiS.Punti0(15).y), (PuntiS.Punti0(4).X), (PuntiS.Punti0(4).y), 0.1, 0)
            Funzioni.DisRut.tratto((PuntiS.Punti0(4).X), (PuntiS.Punti0(4).y), (PuntiS.Punti0(5).X), (PuntiS.Punti0(5).y), 0.1, 0)
            Funzioni.DisRut.tratto((PuntiS.Punti0(5).X), (PuntiS.Punti0(5).y), (PuntiS.Punti0(16).X), (PuntiS.Punti0(16).y), 0.1, 0)
            Funzioni.DisRut.tratto((PuntiS.Punti0(16).X), (PuntiS.Punti0(16).y), (PuntiS.Punti0(15).X), (PuntiS.Punti0(15).y), 0.1, 0)
            PuntiS.SpezzGraf(7, 9, Funzioni.DisRut)
            PuntiD.SpezzGraf(0, 3, Funzioni.DisRut)
            Funzioni.DisRut.tratto((PuntiD.Punti0(3).X), (PuntiD.Punti0(3).y), (PuntiD.Punti0(14).X), (PuntiD.Punti0(14).y), 0.1, 0)
            Funzioni.DisRut.tratto((PuntiD.Punti0(14).X), (PuntiD.Punti0(14).y), (PuntiD.Punti0(17).X), (PuntiD.Punti0(17).y), 0.1, 0)
            Funzioni.DisRut.tratto((PuntiD.Punti0(17).X), (PuntiD.Punti0(17).y), (PuntiD.Punti0(6).X), (PuntiD.Punti0(6).y), 0.1, 0)
            '--------------
            Funzioni.DisRut.tratto((PuntiD.Punti0(15).X), (PuntiD.Punti0(15).y), (PuntiD.Punti0(4).X), (PuntiD.Punti0(4).y), 0.1, 0)
            Funzioni.DisRut.tratto((PuntiD.Punti0(4).X), (PuntiD.Punti0(4).y), (PuntiD.Punti0(5).X), (PuntiD.Punti0(5).y), 0.1, 0)
            Funzioni.DisRut.tratto((PuntiD.Punti0(5).X), (PuntiD.Punti0(5).y), (PuntiD.Punti0(16).X), (PuntiD.Punti0(16).y), 0.1, 0)
            Funzioni.DisRut.tratto((PuntiD.Punti0(16).X), (PuntiD.Punti0(16).y), (PuntiD.Punti0(15).X), (PuntiD.Punti0(15).y), 0.1, 0)
            PuntiD.SpezzGraf(7, 9, Funzioni.DisRut)
        End If
        DisArco()
        Select Case Oggetto.SottoTipo
            Case 1
                Funzioni.DisRut.tratto((PuntiS.Punti0(0).X), (PuntiS.Punti0(0).y), (PuntiS.Punti0(20).X), (PuntiS.Punti0(20).y), 0.1, 0) : Funzioni.DisRut.tratto((PuntiD.Punti0(0).X), (PuntiD.Punti0(0).y), (PuntiD.Punti0(20).X), (PuntiD.Punti0(20).y), 0.1, 0)
                Funzioni.DisRut.tratto((PuntiS.Punti0(1).X), (PuntiS.Punti0(1).y), (PuntiS.Punti0(21).X), (PuntiS.Punti0(21).y), 0.1, 0) : Funzioni.DisRut.tratto((PuntiD.Punti0(1).X), (PuntiD.Punti0(1).y), (PuntiD.Punti0(21).X), (PuntiD.Punti0(21).y), 0.1, 0)
            Case 2
                Funzioni.DisRut.tratto((PuntiS.Punti0(0).X), (PuntiS.Punti0(0).y), (PuntiS.Punti0(20).X), (PuntiS.Punti0(20).y), 0.1, 0) : Funzioni.DisRut.tratto((PuntiD.Punti0(0).X), (PuntiD.Punti0(0).y), (PuntiD.Punti0(20).X), (PuntiD.Punti0(20).y), 0.1, 0)
                Funzioni.DisRut.tratto((PuntiS.Punti0(1).X), (PuntiS.Punti0(1).y), (PuntiS.Punti0(21).X), (PuntiS.Punti0(21).y), 0.1, 0) : Funzioni.DisRut.tratto((PuntiD.Punti0(1).X), (PuntiD.Punti0(1).y), (PuntiD.Punti0(21).X), (PuntiD.Punti0(21).y), 0.1, 0)
                Funzioni.DisRut.tratto((PuntiS.Punti0(3).X), (PuntiS.Punti0(3).y), (PuntiS.Punti0(23).X), (PuntiS.Punti0(23).y), 0.1, 0) : Funzioni.DisRut.tratto((PuntiD.Punti0(3).X), (PuntiD.Punti0(3).y), (PuntiD.Punti0(23).X), (PuntiD.Punti0(23).y), 0.1, 0)
            Case 3
                Funzioni.DisRut.tratto((PuntiS.Punti0(8).X), (PuntiS.Punti0(8).y), (PuntiS.Punti0(28).X), (PuntiS.Punti0(28).y), 0.1, 0) : Funzioni.DisRut.tratto((PuntiD.Punti0(8).X), (PuntiD.Punti0(8).y), (PuntiD.Punti0(28).X), (PuntiD.Punti0(28).y), 0.1, 0)
                Funzioni.DisRut.tratto((PuntiS.Punti0(5).X), (PuntiS.Punti0(5).y), (PuntiS.Punti0(25).X), (PuntiS.Punti0(25).y), 0.1, 0) : Funzioni.DisRut.tratto((PuntiD.Punti0(5).X), (PuntiD.Punti0(5).y), (PuntiD.Punti0(25).X), (PuntiD.Punti0(25).y), 0.1, 0)
                Funzioni.DisRut.tratto((PuntiS.Punti0(4).X), (PuntiS.Punti0(4).y), (PuntiS.Punti0(24).X), (PuntiS.Punti0(24).y), 0.1, 0) : Funzioni.DisRut.tratto((PuntiD.Punti0(4).X), (PuntiD.Punti0(4).y), (PuntiD.Punti0(24).X), (PuntiD.Punti0(24).y), 0.1, 0)
                Funzioni.DisRut.tratto((PuntiS.Punti0(2).X), (PuntiS.Punti0(2).y), (PuntiS.Punti0(22).X), (PuntiS.Punti0(22).y), 0.1, 0) : Funzioni.DisRut.tratto((PuntiD.Punti0(2).X), (PuntiD.Punti0(2).y), (PuntiD.Punti0(22).X), (PuntiD.Punti0(22).y), 0.1, 0)
        End Select
        If Oggetto.SpessRive > 0 And Oggetto.SottoTipo < 3 Then 'rivestimento (da COMPLETARE)
            Funzioni.DisRut.tratto((PuntiS.Punti0(0).X), (PuntiS.Punti0(0).y), (PuntiS.Punti0(11).X), (PuntiS.Punti0(11).y), 0.1, 0)
            Funzioni.DisRut.tratto((PuntiS.Punti0(11).X), (PuntiS.Punti0(11).y), (PuntiS.Punti0(12).X), (PuntiS.Punti0(12).y), 0.1, 0)
            Funzioni.DisRut.tratto((PuntiS.Punti0(12).X), (PuntiS.Punti0(12).y), (PuntiS.Punti0(1).X), (PuntiS.Punti0(1).y), 0.1, 0)
            Funzioni.DisRut.tratto((PuntiD.Punti0(0).X), (PuntiD.Punti0(0).y), (PuntiD.Punti0(11).X), (PuntiD.Punti0(11).y), 0.1, 0)
            Funzioni.DisRut.tratto((PuntiD.Punti0(11).X), (PuntiD.Punti0(11).y), (PuntiD.Punti0(12).X), (PuntiD.Punti0(12).y), 0.1, 0)
            Funzioni.DisRut.tratto((PuntiD.Punti0(12).X), (PuntiD.Punti0(12).y), (PuntiD.Punti0(1).X), (PuntiD.Punti0(1).y), 0.1, 0)
        End If
    End Sub
    Private Sub DisArco()
        If Hhub > 0 Then
            If IUNL >= 2 Then
                DirR.X = posspa.CosDiritta.X
                DirR.y = posspa.CosDiritta.y
                GlobalRoutines.ComposDir(Direz1, DirR)
            End If
            ArcoGraf(PuntiS.Punti0(10), R, Direz1, Alfa, IUNL - 1)
            If IUNL >= 2 Then
                DirR.X = posspa.CosDiritta.X
                DirR.y = posspa.CosDiritta.y
                GlobalRoutines.ComposDir(Direz2, DirR)
            End If
            ArcoGraf(PuntiD.Punti0(10), R, Direz2, Alfa, IUNL - 1)
        End If
    End Sub
    Private Sub Tipo4S()
        MsgBox("Tipo4S da programmare in DisFlan")
    End Sub
    Private Sub Tipo4(ByVal Oggetto As Flangione)
        PuntiS.Punti0(0).X = 0 : PuntiS.Punti0(0).y = Oggetto.DiamInt / 2
        PuntiS.Punti0(1).X = Oggetto.SpessBase + SGhub + SGhub1 + Hhub + Hhub1 : PuntiS.Punti0(1).y = Oggetto.DiamInt / 2
        'UPGRADE_ISSUE: L'istruzione GoSub non è supportata. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1014"'
        ConSenHub1(Oggetto)
        PuntiS.Punti0(6).X = PuntiS.Punti0(1).X - Hhub1 : PuntiS.Punti0(6).y = ADG1 / 2
        PuntiS.Punti0(7).X = PuntiS.Punti0(6).X - SGhub1 : PuntiS.Punti0(7).y = ADG1 / 2
        PuntiS.Punti0(8).X = PuntiS.Punti0(7).X : PuntiS.Punti0(8).y = Oggetto.DiamExt / 2
        PuntiS.Punti0(9).X = Hhub + SGhub : PuntiS.Punti0(9).y = Oggetto.DiamExt / 2
        PuntiS.Punti0(10).X = PuntiS.Punti0(9).X : PuntiS.Punti0(10).y = Oggetto.DiamGra / 2
        PuntiS.Punti0(11).X = Hhub : PuntiS.Punti0(11).y = Oggetto.DiamGra / 2
        iOff = 12 - 6
        ConSenHub(Oggetto) 'fine giro PuntiS.Punti0(15)=P0(0)
        PuntiS.Punti0(20).X = 0 : PuntiS.Punti0(20).y = 0 'origine locale
        Diam = 0
        If IUNL = 2 Or IUNL = 3 Then
            Call Apparecchio.CercaBul(Oggetto, Diam, DBul)
            '  DIM Fine AS Vec3
            '  Displ! = PuntiS.Punti0(0).x: GOSUB CalcolR
            '  CALL CercaInt(Oggetto,R1, DInt!, B + 0): PuntiS.Punti0(20).x = PuntiS.Punti0(0).x: PuntiS.Punti0(20).Y = DInt! / 2
            '  Displ! = PuntiS.Punti0(1).x: GOSUB CalcolR
            '  CALL CercaInt(Oggetto,R1, DInt!, B + 0): PuntiS.Punti0(21).x = PuntiS.Punti0(1).x: PuntiS.Punti0(21).Y = DInt! / 2
        End If
        If Diam > 0 Then
            PuntiS.Punti0(21).X = PuntiS.Punti0(6).X : PuntiS.Punti0(17).X = PuntiS.Punti0(6).X : PuntiS.Punti0(18).X = PuntiS.Punti0(11).X : PuntiS.Punti0(19).X = PuntiS.Punti0(11).X
            PuntiS.Punti0(21).y = Diam / 2 - 0.6 * DBul : PuntiS.Punti0(19).y = PuntiS.Punti0(21).y : PuntiS.Punti0(17).y = Diam / 2 + 0.6 * DBul : PuntiS.Punti0(18).y = PuntiS.Punti0(17).y
        End If
        Call TrasfGen(posspa, PuntiS, PuntiD, 20, 21, True)
        If IUNL = 4 Then
            Spots = New spot
            Spots.Tipo = 1
            Spots.Quota = 0
            Spots.Quadro.TopLeft.X = GlobalRoutines.Minimo(PuntiS.Punti0(9).X, PuntiD.Punti0(8).X)
            Spots.Quadro.TopLeft.y = GlobalRoutines.Minimo(PuntiS.Punti0(9).y, PuntiD.Punti0(8).y)
            Spots.Quadro.Botrigt.X = GlobalRoutines.Massimo(PuntiS.Punti0(9).X, PuntiD.Punti0(8).X)
            Spots.Quadro.Botrigt.y = GlobalRoutines.Massimo(PuntiS.Punti0(9).y, PuntiD.Punti0(8).y)
            RegisterSpot(Spots, Oggetto)
            Exit Sub
        End If
        If Diam = 0 Then
            PuntiS.SpezzGraf(0, 3, Funzioni.DisRut) : PuntiS.SpezzGraf(5, 12, Funzioni.DisRut)
            PuntiS.SpezzGraf(13, 15, Funzioni.DisRut)
            PuntiD.SpezzGraf(0, 3, Funzioni.DisRut) : PuntiD.SpezzGraf(5, 12, Funzioni.DisRut)
            PuntiD.SpezzGraf(13, 15, Funzioni.DisRut)
        Else
            If Diam < PuntiS.Punti0(6).y * 2 Then
                PuntiS.SpezzGraf(0, 3, Funzioni.DisRut)
                Funzioni.DisRut.tratto((PuntiS.Punti0(5).X), (PuntiS.Punti0(5).y), (PuntiS.Punti0(21).X), (PuntiS.Punti0(21).y), 0.1, 0)
                Funzioni.DisRut.tratto((PuntiS.Punti0(17).X), (PuntiS.Punti0(17).y), (PuntiS.Punti0(6).X), (PuntiS.Punti0(6).y), 0.1, 0)
                PuntiS.SpezzGraf(6, 11, Funzioni.DisRut)
                Funzioni.DisRut.tratto((PuntiS.Punti0(11).X), (PuntiS.Punti0(11).y), (PuntiS.Punti0(18).X), (PuntiS.Punti0(18).y), 0.1, 0)
                Funzioni.DisRut.tratto((PuntiS.Punti0(19).X), (PuntiS.Punti0(19).y), (PuntiS.Punti0(12).X), (PuntiS.Punti0(12).y), 0.1, 0)
                PuntiS.SpezzGraf(13, 15, Funzioni.DisRut)
                '--------------
                Funzioni.DisRut.tratto((PuntiS.Punti0(17).X), (PuntiS.Punti0(17).y), (PuntiS.Punti0(18).X), (PuntiS.Punti0(18).y), 0.1, 0)
                Funzioni.DisRut.tratto((PuntiS.Punti0(21).X), (PuntiS.Punti0(21).y), (PuntiS.Punti0(19).X), (PuntiS.Punti0(19).y), 0.1, 0)
                PuntiD.SpezzGraf(0, 3, Funzioni.DisRut)
                Funzioni.DisRut.tratto((PuntiD.Punti0(5).X), (PuntiD.Punti0(5).y), (PuntiD.Punti0(21).X), (PuntiD.Punti0(21).y), 0.1, 0)
                Funzioni.DisRut.tratto((PuntiD.Punti0(17).X), (PuntiD.Punti0(17).y), (PuntiD.Punti0(6).X), (PuntiD.Punti0(6).y), 0.1, 0)
                PuntiD.SpezzGraf(6, 11, Funzioni.DisRut)
                Funzioni.DisRut.tratto((PuntiD.Punti0(11).X), (PuntiD.Punti0(11).y), (PuntiD.Punti0(18).X), (PuntiD.Punti0(18).y), 0.1, 0)
                Funzioni.DisRut.tratto((PuntiD.Punti0(19).X), (PuntiD.Punti0(19).y), (PuntiD.Punti0(12).X), (PuntiD.Punti0(12).y), 0.1, 0)
                PuntiD.SpezzGraf(13, 15, Funzioni.DisRut)
                '--------------
                Funzioni.DisRut.tratto((PuntiD.Punti0(17).X), (PuntiD.Punti0(17).y), (PuntiD.Punti0(18).X), (PuntiD.Punti0(18).y), 0.1, 0)
                Funzioni.DisRut.tratto((PuntiD.Punti0(21).X), (PuntiD.Punti0(21).y), (PuntiD.Punti0(19).X), (PuntiD.Punti0(19).y), 0.1, 0)
            Else
                PuntiS.SpezzGraf(0, 3, Funzioni.DisRut) : PuntiS.SpezzGraf(5, 7, Funzioni.DisRut)
                Funzioni.DisRut.tratto((PuntiS.Punti0(7).X), (PuntiS.Punti0(7).y), (PuntiS.Punti0(21).X), (PuntiS.Punti0(21).y), 0.1, 0)
                Funzioni.DisRut.tratto((PuntiS.Punti0(21).X), (PuntiS.Punti0(21).y), (PuntiS.Punti0(19).X), (PuntiS.Punti0(19).y), 0.1, 0)
                Funzioni.DisRut.tratto((PuntiS.Punti0(19).X), (PuntiS.Punti0(19).y), (PuntiS.Punti0(10).X), (PuntiS.Punti0(10).y), 0.1, 0)
                '--------------
                Funzioni.DisRut.tratto((PuntiS.Punti0(17).X), (PuntiS.Punti0(17).y), (PuntiS.Punti0(8).X), (PuntiS.Punti0(8).y), 0.1, 0)
                Funzioni.DisRut.tratto((PuntiS.Punti0(8).X), (PuntiS.Punti0(8).y), (PuntiS.Punti0(9).X), (PuntiS.Punti0(9).y), 0.1, 0)
                Funzioni.DisRut.tratto((PuntiS.Punti0(9).X), (PuntiS.Punti0(9).y), (PuntiS.Punti0(18).X), (PuntiS.Punti0(18).y), 0.1, 0)
                Funzioni.DisRut.tratto((PuntiS.Punti0(18).X), (PuntiS.Punti0(18).y), (PuntiS.Punti0(21).X), (PuntiS.Punti0(21).y), 0.1, 0)
                PuntiS.SpezzGraf(10, 12, Funzioni.DisRut) : PuntiS.SpezzGraf(13, 15, Funzioni.DisRut)
                PuntiD.SpezzGraf(0, 3, Funzioni.DisRut) : PuntiD.SpezzGraf(5, 7, Funzioni.DisRut)
                Funzioni.DisRut.tratto((PuntiD.Punti0(7).X), (PuntiD.Punti0(7).y), (PuntiD.Punti0(21).X), (PuntiD.Punti0(21).y), 0.1, 0)
                Funzioni.DisRut.tratto((PuntiD.Punti0(21).X), (PuntiD.Punti0(21).y), (PuntiD.Punti0(19).X), (PuntiD.Punti0(19).y), 0.1, 0)
                Funzioni.DisRut.tratto((PuntiD.Punti0(19).X), (PuntiD.Punti0(19).y), (PuntiD.Punti0(10).X), (PuntiD.Punti0(10).y), 0.1, 0)
                '--------------
                Funzioni.DisRut.tratto((PuntiD.Punti0(17).X), (PuntiD.Punti0(17).y), (PuntiD.Punti0(8).X), (PuntiD.Punti0(8).y), 0.1, 0)
                Funzioni.DisRut.tratto((PuntiD.Punti0(8).X), (PuntiD.Punti0(8).y), (PuntiD.Punti0(9).X), (PuntiD.Punti0(9).y), 0.1, 0)
                Funzioni.DisRut.tratto((PuntiD.Punti0(9).X), (PuntiD.Punti0(9).y), (PuntiD.Punti0(18).X), (PuntiD.Punti0(18).y), 0.1, 0)
                Funzioni.DisRut.tratto((PuntiD.Punti0(18).X), (PuntiD.Punti0(18).y), (PuntiD.Punti0(21).X), (PuntiD.Punti0(21).y), 0.1, 0)
                PuntiD.SpezzGraf(10, 12, Funzioni.DisRut) : PuntiD.SpezzGraf(13, 15, Funzioni.DisRut)
            End If
        End If
        If Hhub > 0 Then
            If IUNL >= 2 Then
                DirR.X = posspa.CosDiritta.X
                DirR.y = posspa.CosDiritta.y
                GlobalRoutines.ComposDir(Direz1, DirR)
            End If
            ArcoGraf(PuntiS.Punti0(16), R, Direz1, Alfa, IUNL - 1)
            If IUNL >= 2 Then
                DirR.X = posspa.CosDiritta.X
                DirR.y = posspa.CosDiritta.y
                GlobalRoutines.ComposDir(Direz2, DirR)
            End If
            ArcoGraf(PuntiD.Punti0(16), R, Direz2, Alfa, IUNL - 1)
        End If
        If Hhub1 > 0 Then
            If IUNL >= 2 Then
                DirR.X = posspa.CosDiritta.X
                DirR.y = posspa.CosDiritta.y
                GlobalRoutines.ComposDir(Direz11, DirR)
            End If
            ArcoGraf(PuntiS.Punti0(4), R, Direz11, Alfa1, IUNL - 1)
            If IUNL >= 2 Then
                DirR.X = posspa.CosDiritta.X
                DirR.y = posspa.CosDiritta.y
                GlobalRoutines.ComposDir(Direz21, DirR)
            End If
            ArcoGraf(PuntiD.Punti0(4), R, Direz21, Alfa1, IUNL - 1)
        End If
        'SELECT CASE TipoV
        'CASE 1
        'DisRut.tratto PuntiS.Punti0(0).X, PuntiS.Punti0(0).Y, PuntiS.Punti0(20).X, PuntiS.Punti0(20).Y, .1, 0: Funzioni.DisRut.tratto PuntiD.Punti0(0).X, PuntiD.Punti0(0).Y, PuntiD.Punti0(20).X, PuntiD.Punti0(20).Y, .1, 0
        'DisRut.tratto PuntiS.Punti0(1).X, PuntiS.Punti0(1).Y, PuntiS.Punti0(21).X, PuntiS.Punti0(21).Y, .1, 0: Funzioni.DisRut.tratto PuntiD.Punti0(1).X, PuntiD.Punti0(1).Y, PuntiD.Punti0(21).X, PuntiD.Punti0(21).Y, .1, 0
        'CASE 2
        'DisRut.tratto PuntiS.Punti0(0).X, PuntiS.Punti0(0).Y, PuntiS.Punti0(20).X, PuntiS.Punti0(20).Y, .1, 0: Funzioni.DisRut.tratto PuntiD.Punti0(0).X, PuntiD.Punti0(0).Y, PuntiD.Punti0(20).X, PuntiD.Punti0(20).Y, .1, 0
        'DisRut.tratto PuntiS.Punti0(1).X, PuntiS.Punti0(1).Y, PuntiS.Punti0(21).X, PuntiS.Punti0(21).Y, .1, 0: Funzioni.DisRut.tratto PuntiD.Punti0(1).X, PuntiD.Punti0(1).Y, PuntiD.Punti0(21).X, PuntiD.Punti0(21).Y, .1, 0
        'DisRut.tratto PuntiS.Punti0(3).X, PuntiS.Punti0(3).Y, PuntiS.Punti0(23).X, PuntiS.Punti0(23).Y, .1, 0: Funzioni.DisRut.tratto PuntiD.Punti0(3).X, PuntiD.Punti0(3).Y, PuntiD.Punti0(23).X, PuntiD.Punti0(23).Y, .1, 0
        'CASE 3
        'DisRut.tratto PuntiS.Punti0(8).X, PuntiS.Punti0(8).Y, PuntiS.Punti0(28).X, PuntiS.Punti0(28).Y, .1, 0: Funzioni.DisRut.tratto PuntiD.Punti0(8).X, PuntiD.Punti0(8).Y, PuntiD.Punti0(28).X, PuntiD.Punti0(28).Y, .1, 0
        'DisRut.tratto PuntiS.Punti0(5).X, PuntiS.Punti0(5).Y, PuntiS.Punti0(25).X, PuntiS.Punti0(25).Y, .1, 0: Funzioni.DisRut.tratto PuntiD.Punti0(5).X, PuntiD.Punti0(5).Y, PuntiD.Punti0(25).X, PuntiD.Punti0(25).Y, .1, 0
        'DisRut.tratto PuntiS.Punti0(4).X, PuntiS.Punti0(4).Y, PuntiS.Punti0(24).X, PuntiS.Punti0(24).Y, .1, 0: Funzioni.DisRut.tratto PuntiD.Punti0(4).X, PuntiD.Punti0(4).Y, PuntiD.Punti0(24).X, PuntiD.Punti0(24).Y, .1, 0
        'DisRut.tratto PuntiS.Punti0(2).X, PuntiS.Punti0(2).Y, PuntiS.Punti0(22).X, PuntiS.Punti0(22).Y, .1, 0: Funzioni.DisRut.tratto PuntiD.Punti0(2).X, PuntiD.Punti0(2).Y, PuntiD.Punti0(22).X, PuntiD.Punti0(22).Y, .1, 0
        'END SELECT
        If IUNL < 3 Then
            If Diam = 0 Then
                '406  PAINT ((PuntiS.Punti0(1).X + PuntiS.Punti0(9).X) / 2, ymax + ymin - (PuntiS.Punti0(1).Y + PuntiS.Punti0(9).Y) / 2), 0, 15
                '     PAINT ((PuntiD.Punti0(1).X + PuntiD.Punti0(9).X) / 2, ymax + ymin - (PuntiD.Punti0(1).Y + PuntiD.Punti0(9).Y) / 2), 0, 15
            Else
                '411  PAINT ((PuntiS.Punti0(1).X + PuntiS.Punti0(13).X) / 2, ymax + ymin - (PuntiS.Punti0(1).Y + PuntiS.Punti0(13).Y) / 2), 0, 15
                '     PAINT ((PuntiS.Punti0(17).X + PuntiS.Punti0(9).X) / 2, ymax + ymin - (PuntiS.Punti0(17).Y + PuntiS.Punti0(9).Y) / 2), 0, 15
                '     PAINT ((PuntiD.Punti0(1).X + PuntiD.Punti0(13).X) / 2, ymax + ymin - (PuntiD.Punti0(1).Y + PuntiD.Punti0(13).Y) / 2), 0, 15
                '     PAINT ((PuntiD.Punti0(17).X + PuntiD.Punti0(9).X) / 2, ymax + ymin - (PuntiD.Punti0(17).Y + PuntiD.Punti0(9).Y) / 2), 0, 15
            End If
        End If
    End Sub
    Function Preleva(ByRef OldInd As Membratura) As Boolean
        Dim Testo As String
        Preleva = True
        If OldInd Is Nothing Then
            Testo = " Non è stata selezionata alcuna posizione"
            MsgBox(Testo, MsgBoxStyle.Information)
            Preleva = False : Exit Function
        End If
        If CType(OldInd.GenMem, clsGenMem).posizione.SuChi Is Nothing Then
            CType(OldInd.GenMem, clsGenMem).posizione.SuChi = Apparecchio.Elementi(0)
            MsgBox("Dati non validi nella definizione del posizionamento", MsgBoxStyle.Exclamation)
        End If
        'OldInd.GenMem.Tipo = 26
        If CType(OldInd.GenMem, clsGenMem).Tipo > 90 Or CType(OldInd.GenMem, clsGenMem).Tipo = 0 Then
            Testo = " Questa posizione non e' editabile  in  quanto   " & Chr(13)
            Testo = Testo & " posizione informativa o sottoposizione.         "
            MsgBox(Testo, MsgBoxStyle.Information)
            Preleva = False : Exit Function
        End If
    End Function
    Public Sub Dispaccia(ByRef Button As Short, ByRef Mode As Short) 'aggiorna
        Dim MembroLoc As Membratura 'New Grafica.Cilindro
        'On Local Error GoTo ErrDisp
        'Mode=0 ricalcolo
        'Mode=1 editaggio
        AddMembrat = Button '?????????
        Select Case Button
            Case 1, 2 'Call Cilindri
                Membro = New Cilindro
            Case 3, 4, 5
                Membro = New Fondo
            Case 6, 7 'Call Stampati ' close #99:Catena "STAMPATI"
                Membro = New Cono
            Case 8, 9
                Membro = New Fascio
                '   If AddDistinta < 100 Then
                '     a$ = "E' disponibile il menu' 26 (fasci tubieri), che |"
                'a$ = a$ + "e' preferibile in quanto calcola la tracciatura.|"
                'a$ = a$ + "Vuoi utilizzarlo ?                              |"
                '         junk = Alert(4, at1(69), 7, 9, 15, 59, "SI", "NO", "")
                '   Else
                '         junk = 1
                '   End If
                '   If junk = 2 Then
                '       RecordD(1).Ind = 0
                '       AddMembrat = 8: Call Tubi 'close #99:Catena "CALANDR"
                '   Else
                '       If RecordD(0).Dati(11) > 0 Then
                '            KEY(3) OFF: KEY OFF
                '            AddMembrat = 26: Close #99: Catena "TR13"
                '       Else
                '            AddMembrat = 8: Call Tubi
                '       End If
                '   End If
                '   Case 9
                'If AddDistinta < 100 Then
                '     a$ = "Usare  il menu' 26  (fasci tubieri)    |"
                'a$ = a$ + "(Esso funziona anche per i tubi diritti)"
                '         junk = Alert(4, at1(70), 7, 9, 15, 59, at1(33), "", "")
                'End If
                'RecordD(1).Ind = 0
                'KEY(3) OFF: KEY OFF
                'AddMembrat = 26
                'Close #99: Catena "TR13"
            Case 10 'Call Bocch
                Membro = New clsBocch
            Case 11 'Call Piastron 'Flangioni
                Membro = New Flangione
            Case 12 'Call Piastron 'Piastre
                Membro = New Piastrone
            Case 13 'Call Piastron 'Tiranti
                Membro = New clsTirante
            Case 14 'Call NonStd
                Membro = New clsNonStd
            Case 15 'Call DiafraGlob: 'Lamiere piane
                Membro = New Striscia
            Case 16 'Call CalDisc 'Dischi/Calotte/Fondi piani
                Membro = New CalDisc
            Case 18 'Call Dilat
                Membro = New Dilat
            Case 17 'Call Stampati 'Anelli
                Membro = New Anello
            Case 19 'Call DiafraGlob
                Membro = New Diaframma
            Case 20, 21, 22
                Corso()
            Case 23 'Call DiafraGlob
            Case 24 'Call DiafraGlob: 'Varie
            Case 25, 31, 32, 33
                'AddMembrat = 25: Call Selle ': close #99:Catena "CALANDR"
            Case 26
                Membro = New Fascio
            Case 27, 29 'Call DiafraGlob: ' close #99:Catena "DIAFRAM"
            Case 28 'Call DiafraGlob: ' close #99:Catena "DIAFRAM"
                Membro = New clsGuarniz
            Case 30
                '   Rec2Buf(3) = RecordD(jRec)
                '   indice = StandGre(3, False, 0)
                '   grezzo.Vartxt(1) = "DU  "
                '   grezzo.Dimens(1) = 0
                '   grezzo.Variab(2) = 0
                '   grezzo.Variab(1) = 0
            Case 34 'Call Cilindri
            Case 36 'Call Belts
            Case 37
                Corso()
        End Select
        Membro.GenMem.Tipo = Button
        MembroLoc = Membro
        Call MembroLeggi(Membro, Inizio.DiscoRam, Mode)
        ' jRec = 0
        Membro = MembroLoc
    End Sub
    Private Sub Corso()
        Testo = " LAVORI IN CORSO !"
        MsgBox(Testo)
    End Sub
    Sub DeletaForiN(ByRef OldInd As Membratura, Optional ByRef AnchePeso As Boolean = True)
        Dim j, i As Short
        Dim peso As Single
        Dim OldMembro As Membratura
        If AnchePeso Then
            For j = 1 To Apparecchio.Elementi.Count()
                OldMembro = Apparecchio.Elementi(j - 1)
                If CType(OldMembro.GenMem, clsGenMem).Tipo = 97 Then
                    If (OldInd Is Nothing Or CType(OldMembro.GenMem, clsGenMem).posizione.SuChi Is OldInd Or OldMembro.Bucante Is OldInd) Then
                        peso = -CType(OldMembro.GenMem, clsGenMem).PNET
                        With CType(OldMembro.GenMem, clsGenMem).posizione
                            Buco(.SuChi.GenMem, CSng(peso), CType(OldMembro, Foratura).Quota, CType(OldMembro, Foratura).Raggio, CType(OldMembro, Foratura).anom)
                            If .SuChi.GenMem.posizione.ForoSecondario Is OldMembro.Bucante Then
                                .SuChi.GenMem.posizione.ForoSecondario = Nothing
                            End If
                            If .SuChi.GenMem.posizione.ForoTerziario Is OldMembro.Bucante Then
                                .SuChi.GenMem.posizione.ForoTerziario = Nothing
                            End If
                        End With
                    End If
                End If
            Next
            'annullati i pesi
        End If
        Dim n As OggList.NodeP = Apparecchio.Elementi.nodeHead.Next
        While Not n Is Nothing
            OldMembro = n.TextData ' Apparecchio.Elementi(i)
            Select Case CType(OldMembro.GenMem, clsGenMem).Tipo
                Case 97
                    If (OldInd Is Nothing Or CType(OldMembro.GenMem, clsGenMem).posizione.SuChi Is OldInd Or OldMembro.Bucante Is OldInd) Then
4041:                   CancPosN(OldMembro)
                        n = n.Previous
                    End If
                Case 1 'Forosecondario usato per seconda estremità di virola
                Case Else
                    If OldInd Is Nothing Then
                        CType(OldMembro.GenMem, clsGenMem).posizione.ForoSecondario = Nothing
                        CType(OldMembro.GenMem, clsGenMem).posizione.ForoTerziario = Nothing
                    End If
            End Select
            n = n.Next
        End While
    End Sub
    Public Function EditaPos(ByRef OldInd As Membratura) As Short
        Try
            If Not Preleva(OldInd) Then Exit Function
            EditaPos = True
            '  DeletaForiN OldInd
            OldInd.Leggi(Inizio.DiscoRam, CShort(1))
            System.Windows.Forms.Application.DoEvents()
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
            If Funzioni.OKfrmDati Then
                Funzioni.AggiornaApparecchio(OldInd)
                Funzioni.PostChain(OldInd.GenMem)
            End If
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Function
    Public Function DuplicaPos(ByRef Origine As Membratura) As Short
        Dim Copia As Membratura = Nothing
        Funzioni.GeneraOggetto(Origine.GenMem.Tipo, Copia)
        Origine.Copia(Copia)
        Copia.GenMem.PosDis = Funzioni.SetPosizN
        Apparecchio.Add(Copia)
        DuplicaPos = Apparecchio.Elementi.Count()
    End Function
    Sub CancPosN(ByRef Arg As Object)
        Dim junk As Short
        Dim Testo As String
        Dim OldInd As Short
        Dim SopraMembro As Membratura = Nothing
        Dim OldMembro As Membratura = Nothing
        Select Case VarType(Arg)
            Case VariantType.Object : OldInd = 0
                OldMembro = Arg
            Case VariantType.Short
                OldInd = Arg
                OldMembro = Apparecchio.Elementi(OldInd)
        End Select
        Try
            If Inizio.AddDistinta < 103 Then
                Dim n As OggList.NodeP = Apparecchio.Elementi.nodeHead.Next
                While Not n Is Nothing
                    SopraMembro = n.TextData
                    If CType(SopraMembro.GenMem, clsGenMem).posizione.SuChi Is OldMembro And _
                       CType(OldMembro.GenMem, clsGenMem).Tipo > 0 And _
                       CType(SopraMembro.GenMem, clsGenMem).Tipo < 90 And _
                       CType(SopraMembro.GenMem, clsGenMem).Tipo > 0 Then
                        Testo = " E' pericoloso cancellare questa posizione in quanto "
                        Testo = Testo & " vi si appoggia sopra la posizione "
                        Testo = Testo & Str(CType(SopraMembro.GenMem, clsGenMem).PosDis) & ") " + CType(SopraMembro.GenMem, clsGenMem).Denom + vbCrLf
                        Testo = Testo & "La vuoi cancellare lo stesso?"
                        If MsgBox(Testo, MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.Yes Then junk = 2 Else junk = 0 'junk = Alert(4, Testo, 7, 9, 19, 69, "NO", "SI", "")
                        If junk = 2 Then
                            CType(SopraMembro.GenMem, clsGenMem).posizione.SuChi = Apparecchio.Elementi(0)
                        Else
                            Exit Sub 'GoTo RifaiCanc
                        End If
                    End If
                    n = n.Next
                End While
            End If
            If CType(OldMembro.GenMem, clsGenMem).Tipo < 90 Then
                Call DeletaForiN(OldMembro)
                CancGre()
                Cancella(OldMembro, SopraMembro)
                Apparecchio.BaricGen()
            Else
                Cancella(OldMembro, SopraMembro)
            End If
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    '-------------------------------------------------------------------
    Private Sub Cancella(ByVal OldMembro As Membratura, ByVal SopraMembro As Membratura)
        Try
            If CType(OldMembro.GenMem, clsGenMem).Tipo < 0 Then
                SopraMembro = CType(OldMembro.GenMem, clsGenMem).Superiore
                If Not SopraMembro Is Nothing Then
                    CType(CType(SopraMembro.GenMem, clsGenMem).Appesi, OggList).remove(CType(OldMembro.GenMem, clsGenMem).key)
                    Select Case CType(SopraMembro.GenMem, clsGenMem).Tipo
                        Case 10, 14, 25, 26
                            SopraMembro.RimuoviSpeciali(OldMembro)
                    End Select
                End If
            End If
            For i = 1 To CType(CType(OldMembro.GenMem, clsGenMem).Appesi, OggList).Count
                Apparecchio.RemoveElem(CType(CType(OldMembro.GenMem, clsGenMem).Appesi(i - 1).GenMem, clsGenMem).Denom.Trim)
            Next
            Apparecchio.RemoveElem(Trim(CType(OldMembro.GenMem, clsGenMem).Denom))
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Private Sub CancGre()
    End Sub
    Public Sub ResetFori()
        Dim j As Short
        For j = 0 To Apparecchio.Elementi.Count() - 1
            With CType(Apparecchio.Elementi(j).GenMem, clsGenMem)
                If .Tipo < 90 Then
                    If Not .posizione.SuChi Is Nothing Then
                        Select Case .posizione.SuChi.GenMem.Tipo
                            Case 0
                            Case Else
                                If Apparecchio.Elementi(j).GenMem.Tipo > 0 Then AggCoordN(Apparecchio.Elementi(j).GenMem, Apparecchio)
                                Intersezioni(Apparecchio.Elementi(j).GenMem, .posizione.SuChi.GenMem)
                        End Select
                    End If
                End If
            End With
        Next
    End Sub
    Sub BucoTirFlan(ByRef Record As clsGenMem, ByRef Recordv As clsGenMem, ByRef Quota As Single, ByRef Raggio As Single, ByRef anom As Single, ByRef NB As Short, ByRef DFor As Single, ByRef peso As Single)
        Dim DBul As Single
        DBul = CType(Record.Parent, clsTirante).StandardTir.Dnom
        DFor = 1.1 * DBul '????????????????????????????
2180:   NB = Record.Qta
        If System.Math.Abs(Recordv.Tipo) = 11 Then 'Flangia
            With CType(Recordv.Parent, Flangione)
                Select Case .SottoTipo
                    Case 1
                        peso = PI / 4 * DFor * DFor * .SpessBase * NB
                    Case 2
                        peso = PI / 4 * DFor * DFor * (.SpessBase + .SpessGra) * NB
                    Case 3
                        peso = PI / 4 * DFor * DFor * DFor / 1.5 * NB
                End Select
                Quota = .H + .SpessBase / 2
            End With
        Else 'Piastra
            With CType(Recordv.Parent, Piastrone)
                Select Case .SottoTipo
                    Case 3, 7
                        peso = PI / 4 * DFor * DFor * (.SpessBase - (.H3 - .H2) - .H4) * NB
                        Quota = .H4 + (.SpessBase - (.H3 - .H2) - .H4) / 2
                    Case 6
                        peso = PI / 4 * DFor * DFor * (.SpessBase - 2 * .H1) * NB
                        Quota = .SpessBase / 2
                End Select
            End With
        End If
        peso = peso * Recordv.PesoSp1 '* EXP9
        Raggio = 0 : anom = 0
2210:   Buco(Recordv, peso, Quota, Raggio, anom)
    End Sub
    Sub TogliFS()
        Dim Testo As String
        If Asc(job.Comm.Arch) < 33 Then
            Testo = " Bisogna prima inizializzare una nuova distinta |"
            Testo = Testo & " oppure attivare una distinta in corso di lavorazione.|"
            MsgBox(Testo, MsgBoxResult.OK) 'junk = Alert(4, Testo, 7, 9, 19, 69, at1(33), "", "")
            Exit Sub
        End If
        Call DeletaForiN(Nothing)
        Call ResetFori()
    End Sub
    Public Function RaggioBocN(ByRef Rec As clsGenMem) As Single
        Dim Adim1, BBB, raggiop As Single
        Try
            If Rec.Tipo = 10 Then
                BBB = CType(Rec.Parent, clsBocch).DiamInt
                Adim1 = CType(Rec.Parent, clsBocch).Standard.DiamExt
            ElseIf Rec.Tipo = 14 Then
                BBB = CType(Rec.Parent, clsNonStd).DiamInt
                Adim1 = CType(Rec.Parent, clsNonStd).DiamExt
            End If
            If Rec.Parent.DiamScarpa > 0 Then
                raggiop = Rec.Parent.DiamScarpa / 2
            ElseIf Rec.Parent.DiamRinf > 0 And (Not (Left(Rec.posizione.Raggio, 2) = Chr(82) & Chr(101) Or Left(Rec.posizione.Raggio, 2) = "Bu")) Then
                raggiop = Rec.Parent.DiamRinf / 2
            Else
                If Left(Rec.posizione.Raggio, 2) = Chr(82) & Chr(101) Or Left(Rec.posizione.Raggio, 2) = "Bu" Then
                    raggiop = BBB / 2
                Else
                    raggiop = Adim1 / 2
                    If Rec.Parent.DiamRinf > Adim1 Then raggiop = Rec.Parent.DiamRinf / 2
                End If
            End If
            RaggioBocN = raggiop
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Function
    Private Sub SetXYZN(ByRef Rec As clsGenMem, ByRef Recv As clsGenMem)
        Rec.posizione.Origine.X = Recv.posizione.Origine.X + Recv.posizione.CosDiritta.X * Rec.posizione.QuotaR + Rec.posizione.CosOrigine.X * Rec.posizione.RaggioR
        Rec.posizione.Origine.y = Recv.posizione.Origine.y + Recv.posizione.CosDiritta.y * Rec.posizione.QuotaR + Rec.posizione.CosOrigine.y * Rec.posizione.RaggioR
        Rec.posizione.Origine.Z = Recv.posizione.Origine.Z + Recv.posizione.CosDiritta.Z * Rec.posizione.QuotaR + Rec.posizione.CosOrigine.Z * Rec.posizione.RaggioR
        SetBaricAssN(Rec)
    End Sub
    Public Sub SetTraversaN(ByRef Record As clsGenMem, ByRef Recordv As clsGenMem)
        Select Case Left(Record.posizione.DirTraversa, 2)
            Case "=+"
                Recordv.posizione.CosDiritta.copia((Record.posizione.CosTraversa))
            Case "=-"
                Record.posizione.CosTraversa.X = -Recordv.posizione.CosDiritta.X
                Record.posizione.CosTraversa.y = -Recordv.posizione.CosDiritta.y
                Record.posizione.CosTraversa.Z = -Recordv.posizione.CosDiritta.Z
            Case "Up"
                If Record.posizione.CosTraversa.MaxDir((Record.posizione.CosDiritta), 1) = 1 Then
                    MsgBox("SetTraversaN")
                    Record.posizione.CosTraversa.X = 1
                    Record.posizione.CosTraversa.y = 0
                    Record.posizione.CosTraversa.Z = 0
                End If
            Case "Do"
                'Debug.Print Record.posizione.CosTraversa.x, Record.posizione.CosTraversa.y, Record.posizione.CosTraversa.Z
                'Debug.Print Record.posizione.CosDiritta.x, Record.posizione.CosDiritta.y, Record.posizione.CosDiritta.Z
                If Record.posizione.CosTraversa.MaxDir((Record.posizione.CosDiritta), 2) = 1 Then
                    MsgBox("SetTraversaN")
                    Record.posizione.CosTraversa.X = -1
                    Record.posizione.CosTraversa.y = 0
                    Record.posizione.CosTraversa.Z = 0
                End If
            Case "+N"
                If Record.posizione.CosTraversa.MaxDir((Record.posizione.CosDiritta), 5) Then
                    MsgBox("SetTraversaN")
                    Record.posizione.CosTraversa.X = 0
                    Record.posizione.CosTraversa.y = 0
                    Record.posizione.CosTraversa.Z = 1
                End If
            Case "-N"
                If Record.posizione.CosTraversa.MaxDir((Record.posizione.CosDiritta), 6) Then
                    Record.posizione.CosTraversa.X = 0
                    Record.posizione.CosTraversa.y = 0
                    MsgBox("SetTraversaN")
                    Record.posizione.CosTraversa.Z = -1
                End If
            Case "Pe"
                prod = Recordv.posizione.CosDiritta.ProdScalar((Record.posizione.CosDiritta))
                If System.Math.Abs(prod) < TOLER Then 'nuovo e vecchio perpendicolari
                    Recordv.posizione.CosDiritta.DirAlpha((Record.posizione.CosDiritta), (Record.posizione.CosTraversa), PI / 2)
                Else 'nuovo e vecchio paralleli
                    Random(Record)
                End If
            Case "Au"
                Select Case Record.Tipo
                    Case Is < 0
                        If Record.Tipo = -17 Then
                            'Recordv.posizione.CosDiritta.Copia Record.posizione.CosTraversa
                            TravPad(Record, Recordv)
                        Else
                            Select Case Left(Record.posizione.DirDiritta, 2)
                                Case Is = "=+"
                                    Recordv.posizione.CosTraversa.copia((Record.posizione.CosTraversa))
                                Case Is = "=-"
                                    Record.posizione.CosTraversa.X = -Recordv.posizione.CosTraversa.X
                                    Record.posizione.CosTraversa.y = -Recordv.posizione.CosTraversa.y
                                    Record.posizione.CosTraversa.Z = -Recordv.posizione.CosTraversa.Z
                                Case Else
                                    StdTrav(Record, Recordv)
                            End Select
                        End If
                    Case 10, 14
                        TravPad(Record, Recordv)
                    Case Else
                        If System.Math.Abs(Record.Tipo) = 1 Or System.Math.Abs(Record.Tipo) = 2 Then
                            If RandaPossibile((Record.Parent)) Then
                                TravPad(Record, Recordv)
                            Else
                                StdTrav(Record, Recordv)
                            End If
                        Else
                            StdTrav(Record, Recordv)
                        End If
                End Select
            Case "Ho"
                MsgBox("SetTraversa: lavori in corso", MsgBoxResult.OK + MsgBoxStyle.Exclamation)
            Case "Ve"
                MsgBox("SetTraversa: lavori in corso", MsgBoxResult.OK + MsgBoxStyle.Exclamation)
            Case "N.", "  "
            Case Else
                Alpha = Val(Record.posizione.DirTraversa) * PI / 180
                Select Case Left(Record.posizione.DirDiritta, 2)
                    Case "=+"
                        Recordv.posizione.CosTraversa.DirAlpha((Recordv.posizione.CosDiritta), (Record.posizione.CosTraversa), Alpha)
                    Case Else
                        MsgBox("Caso non previsto in SetTraversa")
                End Select
        End Select
        Record.posizione.CosTraversa.DirAlpha(Record.posizione.CosDiritta, Record.posizione.CosTerza, PI / 2.0!)
        If Record.posizione.CosDiritta.ProdTripl(Record.posizione.CosTraversa, Record.posizione.CosTerza) < 0 Then
            Record.posizione.CosTerza.X = -Record.posizione.CosTerza.X
            Record.posizione.CosTerza.y = -Record.posizione.CosTerza.y
            Record.posizione.CosTerza.Z = -Record.posizione.CosTerza.Z
        End If
    End Sub
    Private Sub TravPad(ByRef Record As clsGenMem, ByRef Recordv As clsGenMem)
        Dim Dir3 As RoutBase1.clsVec3
        If Recordv.posizione.SuChi Is Nothing Then Exit Sub
        Rec2v = Recordv.posizione.SuChi.GenMem
        If Rec2v Is Nothing Then Exit Sub
        Select Case System.Math.Abs(Rec2v.Tipo)
            Case 3, 4, 5
                ' Debug.Print Record.posizione.CosOrigine.x, Record.posizione.CosOrigine.y, Record.posizione.CosOrigine.Z
                ' Debug.Print Recordv.posizione.CosDiritta.x, Recordv.posizione.CosDiritta.y, Recordv.posizione.CosDiritta.Z
                prod = Record.posizione.CosOrigine.ProdScalar((Rec2v.posizione.CosDiritta))
                If System.Math.Abs(System.Math.Abs(prod) - 1) < TOLER Then
                    Record.posizione.CosDiritta.DirTrav((Record.posizione.CosOrigine), (Rec2v.posizione.CosTraversa), (Record.posizione.CosTraversa))
                Else
                    Record.posizione.CosDiritta.DirTrav((Record.posizione.CosOrigine), (Rec2v.posizione.CosDiritta), (Record.posizione.CosTraversa))
                End If
                Dir3 = Record.posizione.CosTraversa
                Dir3.DirAlpha((Record.posizione.CosDiritta), (Record.posizione.CosTraversa), PI / 2)
            Case 1, 2
                prod = Recordv.posizione.CosDiritta.ProdScalar((Rec2v.posizione.CosDiritta))
                If System.Math.Abs(prod) < TOLER Then
                    Rec2v.posizione.CosDiritta.copia((Record.posizione.CosTraversa))
                    'Recordv.posizione.CosTraversa.diralpha
                Else
                    StdTrav(Record, Recordv)
                End If
            Case Else
                StdTrav(Record, Recordv)
        End Select
    End Sub
    Private Sub StdTrav(ByRef Record As clsGenMem, ByRef Recordv As clsGenMem)
        prod = Record.posizione.CosOrigine.ProdScalar((Record.posizione.CosDiritta))
        'Debug.Print Record.Denom; Record.posizione.CosOrigine.X; Record.posizione.CosOrigine.Y; Record.posizione.CosOrigine.Z
        If System.Math.Abs(prod) < TOLER Then
            Record.posizione.CosOrigine.DirAlpha((Record.posizione.CosDiritta), (Record.posizione.CosTraversa), PI / 2)
            Exit Sub
        End If
        If Apparecchio.Asse = "H" Then
            Random(Record)
        Else
            Record.posizione.CosTraversa.y = 0
            det = Record.posizione.CosDiritta.X * Record.posizione.CosDiritta.X + Record.posizione.CosDiritta.Z * Record.posizione.CosDiritta.Z
            If det < TOLER Then
                Record.posizione.CosTraversa.X = 0
                Record.posizione.CosTraversa.Z = 1
            Else
                det = System.Math.Sqrt(det)
                Record.posizione.CosTraversa.X = Record.posizione.CosDiritta.Z / det
                Record.posizione.CosTraversa.Z = -Record.posizione.CosDiritta.X / det
            End If
        End If
    End Sub
    Private Sub Random(ByRef Record As clsGenMem)
        Record.posizione.CosTraversa.Z = 0
        det = Record.posizione.CosDiritta.X * Record.posizione.CosDiritta.X + Record.posizione.CosDiritta.y * Record.posizione.CosDiritta.y
        If det < TOLER Then
            Record.posizione.CosTraversa.X = 0
            Record.posizione.CosTraversa.y = 1
        Else
            det = System.Math.Sqrt(det)
            Record.posizione.CosTraversa.X = Record.posizione.CosDiritta.y / det
            Record.posizione.CosTraversa.y = -Record.posizione.CosDiritta.X / det
        End If
    End Sub
    Public Sub SetBaricAssN(ByRef Rec As clsGenMem)
        Rec.posizione.BaricAss.X = Rec.posizione.Origine.X + Rec.posizione.CosTraversa.X * Rec.posizione.BaricRel.X + Rec.posizione.CosDiritta.X * Rec.posizione.BaricRel.y + Rec.posizione.CosTerza.X * Rec.posizione.BaricRel.Z
        Rec.posizione.BaricAss.y = Rec.posizione.Origine.y + Rec.posizione.CosTraversa.y * Rec.posizione.BaricRel.X + Rec.posizione.CosDiritta.y * Rec.posizione.BaricRel.y + Rec.posizione.CosTerza.y * Rec.posizione.BaricRel.Z
        Rec.posizione.BaricAss.Z = Rec.posizione.Origine.Z + Rec.posizione.CosTraversa.Z * Rec.posizione.BaricRel.X + Rec.posizione.CosDiritta.Z * Rec.posizione.BaricRel.y + Rec.posizione.CosTerza.Z * Rec.posizione.BaricRel.Z
    End Sub

    Sub SubDpic(ByRef Record As clsGenMem, ByRef Recordv As clsGenMem, ByRef Dpiccolo As Single)
        Dim CentroC2 As New RoutBase1.clsVec2
        Dim DirBocch As New RoutBase1.clsVec2
        Dim CentroBocch As New RoutBase1.clsVec2
        Dim Punti As RoutBase1.clsPunti
        Dim n2, n1, i1 As Short
        Dim Linea As RoutBase1.clsLinea2
        CentroBocch.X = 0 : CentroBocch.y = 0
        CentroC2.X = 0
        CentroC2.y = -(CType(Recordv.Parent, Cono).Dgran - CType(Recordv.Parent, Cono).Dpicc) / 2
        DirBocch.X = System.Math.Cos(Record.posizione.AnomalR * PI / 180)
        DirBocch.y = System.Math.Sin(Record.posizione.AnomalR * PI / 180)
        Linea = New RoutBase1.clsLinea2
        Linea.P0 = CentroBocch
        Linea.Direz = DirBocch
        Punti = New RoutBase1.clsPunti
        Punti.Inizia(4)
        Linea.InterRettCerch(0.0!, CentroC2, CType(Recordv.Parent, Cono).Dpicc / 2, Punti, n1, n2)
        If n1 < 1 Then
            Dpiccolo = Recordv.Parent.Dgran / 10 : Exit Sub
        End If
        If Punti.Punti.Item(1).TextData.X * DirBocch.X + Punti.Punti.Item(1).TextData.y * DirBocch.y > 0 Then i1 = 1 Else i1 = 2
        Dpiccolo = 2 * System.Math.Sqrt(Punti.Punti.Item(i1).TextData.X * Punti.Punti.Item(i1).TextData.X + _
                                        Punti.Punti.Item(i1).TextData.y * Punti.Punti.Item(i1).TextData.y)
    End Sub
    Sub DpicN(ByRef Record As clsGenMem, ByRef Recordv As clsGenMem, ByRef Dpiccolo As Single)
        Dim DirBocch As New RoutBase1.clsVec2
        Dim CentroBocch As New RoutBase1.clsVec2
        Dim Punti(4) As RoutBase1.clsVec2
        Dim i1 As Short
        CentroBocch.X = 0 : CentroBocch.y = 0
        'CentroC2.X = 0: CentroC2.Y = -(Recordv.Dati(2) - Recordv.Dati(5)) / 2
        DirBocch.X = System.Math.Cos(Record.posizione.AnomalR * PI / 180)
        DirBocch.y = System.Math.Sin(Record.posizione.AnomalR * PI / 180)
        'Call InterRettCerch(CentroBocch, DirBocch, 0!, CentroC2, Recordv.Dati(5) / 2, Punti(), n1, n2)
        'If n1 < 1 Then Dpiccolo = Recordv.Dati(2) / 10: Exit Sub
        If Punti(1).X * DirBocch.X + Punti(1).y * DirBocch.y > 0 Then i1 = 1 Else i1 = 2
        Dpiccolo = 2 * System.Math.Sqrt(Punti(i1).X * Punti(i1).X + Punti(i1).y * Punti(i1).y)
    End Sub

    Public Sub SetDirittaN(ByRef Rec As clsGenMem, ByRef Recv As clsGenMem)
        Dim Alfa As Single
        Dim Dpiccolo, AngOrig As Single
        Select Case Left(Rec.posizione.DirDiritta, 2)
            Case "=+"
                If System.Math.Abs(Recv.Tipo) = 21 Then
                    Recv.posizione.CosDiritta.DirAlpha((Recv.posizione.CosTerza), (Rec.posizione.CosDiritta), Recv.Parent.Apertura * PI / 180)
                    ' Debug.Print Recv.posizione.CosDiritta.ProdTripl(Recv.posizione.CosTraversa, Recv.posizione.CosTerza)
                Else
                    Recv.posizione.CosDiritta.copia((Rec.posizione.CosDiritta))
                End If
            Case "=-"
                If System.Math.Abs(Recv.Tipo) = 21 And Left(Rec.posizione.Quota, 2) = "Fa" Then
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Recv.Parent.Apertura. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                    Recv.posizione.CosTerza.DirAlpha((Recv.posizione.CosDiritta), (Rec.posizione.CosDiritta), Recv.Parent.Apertura * PI / 180)
                Else
                    Recv.posizione.CosDiritta.copia((Rec.posizione.CosDiritta))
                End If
                Rec.posizione.CosDiritta.X = -Rec.posizione.CosDiritta.X
                Rec.posizione.CosDiritta.y = -Rec.posizione.CosDiritta.y
                Rec.posizione.CosDiritta.Z = -Rec.posizione.CosDiritta.Z
            Case "Na" : Rec.posizione.CosOrigine.copia((Rec.posizione.CosDiritta))
                If System.Math.Abs(Recv.Tipo) = 7 Then
                    Alfa = CType(Recv.Parent, Cono).AlfaCon * PI / 180
                    Rec.posizione.CosOrigine.DirAlpha((Recv.posizione.CosDiritta), (Rec.posizione.CosTraversa), PI / 2)
                    Rec.posizione.CosOrigine.DirAlpha((Rec.posizione.CosTraversa), (Rec.posizione.CosDiritta), Alfa - PI / 2)
                ElseIf System.Math.Abs(Recv.Tipo) = 6 Then
                    Call DpicN(Rec, Recv, Dpiccolo)
                    AngOrig = CType(Recv.Parent, Cono).AlfaCon
                    Alfa = System.Math.Atan((Recv.Parent.Dgran - Dpiccolo) / 2 / Recv.Parent.Altezza) * AngOrig / System.Math.Atan((Recv.Parent.Dgran - Recv.Parent.Dpicc) / Recv.Parent.Altezza) * PI / 180
                    Rec.posizione.CosOrigine.DirAlpha((Recv.posizione.CosDiritta), (Rec.posizione.CosTraversa), PI / 2)
                    Rec.posizione.CosOrigine.DirAlpha((Rec.posizione.CosTraversa), (Rec.posizione.CosDiritta), -Alfa)
                End If
            Case "Op" : Rec.posizione.CosDiritta.X = -Rec.posizione.CosOrigine.X
                Rec.posizione.CosDiritta.y = -Rec.posizione.CosOrigine.y
                Rec.posizione.CosDiritta.Z = -Rec.posizione.CosOrigine.Z
            Case "+N" '   Recv.posizione.CosTerza.Copia Rec.posizione.CosDiritta
                Rec.posizione.CosDiritta.X = 0
                Rec.posizione.CosDiritta.y = 0
                Rec.posizione.CosDiritta.Z = 1
            Case "-N" 'Rec.posizione.CosDiritta.x = -Recv.posizione.CosTerza.x
                'Rec.posizione.CosDiritta.y = -Recv.posizione.CosTerza.y
                'Rec.posizione.CosDiritta.Z = -Recv.posizione.CosTerza.Z
                Rec.posizione.CosDiritta.X = 0
                Rec.posizione.CosDiritta.y = 0
                Rec.posizione.CosDiritta.Z = -1
            Case "Up" 'Recv.posizione.CosTraversa.Copia Rec.posizione.CosDiritta
                Rec.posizione.CosDiritta.X = 1
                Rec.posizione.CosDiritta.y = 0
                Rec.posizione.CosDiritta.Z = 0
            Case "Do" 'Rec.posizione.CosDiritta.x = -Recv.posizione.CosTraversa.x
                'Rec.posizione.CosDiritta.y = -Recv.posizione.CosTraversa.y
                'Rec.posizione.CosDiritta.Z = -Recv.posizione.CosTraversa.Z
                Rec.posizione.CosDiritta.X = -1
                Rec.posizione.CosDiritta.y = 0
                Rec.posizione.CosDiritta.Z = 0
            Case "Ho"
                Rec.posizione.CosDiritta.X = 0
                Rec.posizione.CosDiritta.y = 1
                Rec.posizione.CosDiritta.Z = 0
                '   CASE "Ho"
                '      SELECT CASE MID$(Rec.posizione.DirDiritta, 6, 2)
                '         CASE "X+"
                '           Rec.posizione.CosDiritta.X = 1
                '           Rec.posizione.CosDiritta.Y = 0
                '           Rec.posizione.CosDiritta.Z = 0
                '         CASE "X-"
                '           Rec.posizione.CosDiritta.X = -1
                '           Rec.posizione.CosDiritta.Y = 0
                '           Rec.posizione.CosDiritta.Z = 0
                '         CASE "Y+"
                '           Rec.posizione.CosDiritta.X = 0
                '           Rec.posizione.CosDiritta.Y = 1
                '           Rec.posizione.CosDiritta.Z = 0
                '         CASE "Y-"
                '           Rec.posizione.CosDiritta.X = 0
                '           Rec.posizione.CosDiritta.Y = -1
                '           Rec.posizione.CosDiritta.Z = 0
                '         END SELECT
            Case "Ve"
                Select Case Mid(Rec.posizione.DirDiritta, 6, 2)
                    Case "Z-"
                        Rec.posizione.CosDiritta.X = 0
                        Rec.posizione.CosDiritta.y = 0
                        Rec.posizione.CosDiritta.Z = -1
                    Case Else
                        Rec.posizione.CosDiritta.X = 0
                        Rec.posizione.CosDiritta.y = 0
                        Rec.posizione.CosDiritta.Z = 1
                End Select
        End Select
    End Sub
    Public Sub SetOriginN(ByRef Rec As clsGenMem, ByRef Recv As clsGenMem) ', Dati2 As Single, Dati3 As Single)
        Select Case Left(Rec.posizione.Anomal, 2)
            Case "+N"
                Denom = Recv.posizione.CosDiritta.y * Recv.posizione.CosDiritta.y + Recv.posizione.CosDiritta.Z * Recv.posizione.CosDiritta.Z
                If Denom < TOLER Then
                    Rec.posizione.CosOrigine.X = 0
                    Rec.posizione.CosOrigine.y = 0
                    Rec.posizione.CosOrigine.Z = 1
                Else
                    Denom = System.Math.Sqrt(Denom)
                    segno = System.Math.Sign(Recv.posizione.CosDiritta.y) : If segno = 0 Then segno = 1
                    Rec.posizione.CosOrigine.X = 0
                    Rec.posizione.CosOrigine.y = -Recv.posizione.CosDiritta.Z * segno / Denom
                    Rec.posizione.CosOrigine.Z = System.Math.Abs(Recv.posizione.CosDiritta.y) / Denom
                End If
            Case "-N"
                Denom = Recv.posizione.CosDiritta.y * Recv.posizione.CosDiritta.y + Recv.posizione.CosDiritta.Z * Recv.posizione.CosDiritta.Z
                If Denom < TOLER Then
                    Rec.posizione.CosOrigine.X = 0
                    Rec.posizione.CosOrigine.y = 0
                    Rec.posizione.CosOrigine.Z = -1
                Else
                    Denom = System.Math.Sqrt(Denom)
                    segno = System.Math.Sign(Recv.posizione.CosDiritta.y) : If segno = 0 Then segno = 1
                    Rec.posizione.CosOrigine.X = 0
                    Rec.posizione.CosOrigine.y = Recv.posizione.CosDiritta.Z * segno / Denom
                    Rec.posizione.CosOrigine.Z = -System.Math.Abs(Recv.posizione.CosDiritta.y) / Denom
                End If
            Case "Up"
                Denom = Recv.posizione.CosDiritta.y * Recv.posizione.CosDiritta.y + Recv.posizione.CosDiritta.X * Recv.posizione.CosDiritta.X
                If Denom < TOLER Then
                    Rec.posizione.CosOrigine.X = 1
                    Rec.posizione.CosOrigine.y = 0
                    Rec.posizione.CosOrigine.Z = 0
                Else
                    Denom = System.Math.Sqrt(Denom)
                    segno = System.Math.Sign(Recv.posizione.CosDiritta.y) : If segno = 0 Then segno = 1
                    Rec.posizione.CosOrigine.Z = 0
                    Rec.posizione.CosOrigine.y = -Recv.posizione.CosDiritta.Z * segno / Denom
                    Rec.posizione.CosOrigine.X = System.Math.Abs(Recv.posizione.CosDiritta.y) / Denom
                End If
            Case "Do"
                Denom = Recv.posizione.CosDiritta.y * Recv.posizione.CosDiritta.y + Recv.posizione.CosDiritta.X * Recv.posizione.CosDiritta.X
                If Denom < TOLER Then
                    Rec.posizione.CosOrigine.X = -1
                    Rec.posizione.CosOrigine.y = 0
                    Rec.posizione.CosOrigine.Z = 0
                Else
                    Denom = System.Math.Sqrt(Denom)
                    segno = System.Math.Sign(Recv.posizione.CosDiritta.y) : If segno = 0 Then segno = 1
                    Rec.posizione.CosOrigine.Z = 0
                    Rec.posizione.CosOrigine.y = Recv.posizione.CosDiritta.Z * segno / Denom
                    Rec.posizione.CosOrigine.X = -System.Math.Abs(Recv.posizione.CosDiritta.y) / Denom
                End If
            Case "La", "N." 'Lato Piccolo o Grande
                Rec.posizione.AnomalR = 0
                Alfa = Rec.posizione.AnomalR * PI / 180
                If Not Recv Is Nothing Then
                    If System.Math.Abs(Recv.Tipo) = 21 And Left(Rec.posizione.Quota, 2) = "Fa" Then 'curva
                        'Recv.posizione.CosTerza.DirAlpha Recv.posizione.CosDiritta, Rec.posizione.CosOrigine, Recv.Parent.Apertura * Pi / 180
                        Recv.posizione.CosTraversa.copia((Rec.posizione.CosOrigine))
                        Stop
                    Else
                        Recv.posizione.CosDiritta.copia((Rec.posizione.CosOrigine))
                    End If
                    If System.Math.Abs(Recv.Tipo) = 6 And Left(Rec.posizione.Quota, 2) = "Fa" Then 'conoide
                        Recv.posizione.CosTerza.copia((Rec.posizione.CosOrigine))
                    Else
                        Recv.posizione.CosDiritta.copia((Rec.posizione.CosOrigine))
                    End If
                End If
            Case Else
                Riga = RTrim(Rec.posizione.Anomal)
                Lung = Len(Riga)
                For i = 1 To Lung
                    iasc = Asc(Mid(Riga, i, 1))
                    If Not (iasc = 43 Or iasc = 45 Or iasc = 46 Or (iasc > 47 And iasc < 58)) Then
                        Estrai(Rec, Recv)
                        Rec.posizione.AnomalR = Alfa * 180 / PI
                        GoTo ConSet
                    End If
                Next
                Rec.posizione.AnomalR = Val(Rec.posizione.Anomal)
ConSet:         Alfa = Rec.posizione.AnomalR * PI / 180
                'Debug.Print "Rec.posizione.CosOrigine", Rec.posizione.CosOrigine.x, Rec.posizione.CosOrigine.y, Rec.posizione.CosOrigine.Z
                Recv.posizione.CosTraversa.DirAlpha((Recv.posizione.CosDiritta), (Rec.posizione.CosOrigine), Alfa)
        End Select
        If Recv Is Nothing Then Exit Sub
        CosAlfa = Recv.posizione.CosTraversa.ProdScalar((Rec.posizione.CosOrigine))
        prod = Recv.posizione.CosTraversa.ProdTripl((Recv.posizione.CosDiritta), (Rec.posizione.CosOrigine))
        If System.Math.Abs(CosAlfa) < TOLER Then
            Alfa = System.Math.Sign(prod) * PI / 2
        Else
            TanAlfa = System.Math.Sign(prod) * System.Math.Sqrt(1 - CosAlfa * CosAlfa) / CosAlfa
            Alfa = System.Math.Atan(TanAlfa)
            If CosAlfa < 0.0! Then Alfa = PI - Alfa
        End If
        Rec.posizione.AnomalR = Alfa * 180 / PI
    End Sub
    Private Sub Estrai(ByVal Rec As clsGenMem, ByVal Recv As clsGenMem)
        If Len(Riga) < i + 1 Then Exit Sub
        If Not (Mid(Riga, i, 2) = "ZD" Or Mid(Riga, i, 2) = "XD") Then
            Alfa = Val(Riga) * PI / 180
            Exit Sub
        End If
        disass = Val(Riga)
        If Rec.Tipo = 10 Or Rec.Tipo = 2 Then
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Rec.Parent.SpostLat. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            Rec.Parent.SpostLat = System.Math.Abs(disass)
        End If
        'Select Case Left$(Rec.posizione.Raggio, 2) '4
        '  Case "Ri":             Raggio = Dati2 / 2
        '  Case "Re", "Bu":       Raggio = Dati2 / 2 + Dati3
        '  Case Is = "N.":        Raggio = 0
        '  Case Else:             Raggio = Val(Rec.posizione.Raggio)
        'End Select
        Raggio = RaggioN(Rec, Recv)
        If Raggio = 0 Then
            Attenz(Rec)
            '            Raggio = 2 * Disass
            '            Record.Ind = -Record.Ind
            Exit Sub
        End If
        Alfa = GlobalRoutines.asin(disass / Raggio)
        Select Case Left(Rec.posizione.DirDiritta, 2)
            Case "+N"
                DecidAlfa(Rec, Recv)
            Case "-N" : Alfa = PI - Alfa
                DecidAlfa(Rec, Recv)
            Case "Do" : Alfa = PI - Alfa
                DecidAlfa(Rec, Recv)
            Case "Up"
                DecidAlfa(Rec, Recv)
                '        CASE "Ho":
                '           Rec.posizione.CosOrigine.Z = 0
                '           SELECT CASE MID$(Rec.posizione.DirDiritta, 6, 2)
                '              CASE "X+"
                '              CASE "X-"
                '              CASE "Y+"
                '              CASE "Y-"
                '           END SELECT
                '        CASE "Ve":
                '           Rec.posizione.CosOrigine.X = 0
                '           Rec.posizione.CosOrigine.Y = 0
                '           SELECT CASE MID$(Rec.posizione.DirDiritta, 6, 2)
                '              CASE "Z+"
                '              CASE "Z-"
                '           END SELECT
            Case Else
                Attenz(Rec)
        End Select
    End Sub
    Private Sub DecidAlfa(ByVal Rec As clsGenMem, ByVal Recv As clsGenMem)
        'decidi tra Alfa e PI-Alfa
        If Mid(Riga, i, 2) = "ZD" Then 'Disassamento su asse X della membratura prec.
            Recv.posizione.CosTraversa.DirAlpha((Recv.posizione.CosDiritta), (Rec.posizione.CosOrigine), Alfa)
        ElseIf Mid(Riga, i, 2) = "XD" Then
            Recv.posizione.CosTerza.DirAlpha((Recv.posizione.CosDiritta), (Rec.posizione.CosOrigine), Alfa)
        End If
    End Sub
    Private Sub Attenz(ByVal Rec As clsGenMem)
        'If Inizio.AddDistinta = 103 Then Return
        Testo = "Attenzione: il dati di posizionamento" & vbCrLf
        Testo = Testo & "del bocchello sono stati dati in modo errato." & vbCrLf
        Testo = Testo & "Raggio= " & Left(Rec.posizione.Raggio, 2) & "; Dirdiritta= " & Left(Rec.posizione.DirDiritta, 2)
        MsgBox(Testo, MsgBoxResult.OK + MsgBoxStyle.Exclamation)
    End Sub
    Public Sub Buco(ByRef Recordv As clsGenMem, ByRef peso As Single, ByRef Quota As Single, ByRef Raggio As Single, ByRef anom As Single)
        Dim yg, pesov, xg, zg As Single
        pesov = Recordv.PNET
        yg = Quota
        xg = Raggio * System.Math.Cos(anom)
        zg = Raggio * System.Math.Sin(anom)
        If pesov - peso > 0 Then
            Recordv.posizione.BaricRel.X = (Recordv.posizione.BaricRel.X * pesov - xg * peso) / (pesov - peso)
            Recordv.posizione.BaricRel.y = (Recordv.posizione.BaricRel.y * pesov - yg * peso) / (pesov - peso)
            Recordv.posizione.BaricRel.Z = (Recordv.posizione.BaricRel.Z * pesov - zg * peso) / (pesov - peso)
        End If
        SetBaricAssN(Recordv)
        pesov = pesov - peso
        Recordv.PNET = pesov
        'pesov = Recordv.PSFR + peso
        'Recordv.PSFR = pesov
    End Sub
    Sub SezRetFon(ByRef Oggetto As Membratura, ByRef d As Single, ByRef AP As Single, ByRef T1 As Single)
        Dim z2, z1, Verso As Single
        Dim y, x, Re As Single
        Dim InMezzo As Short
        Dim posspa As Posizione
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Oggetto.GenMem. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
        posspa = Oggetto.GenMem.SwappedPos
        z1 = posspa.Origine.Z
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Oggetto.GenMem. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
        If Oggetto.GenMem.Tipo = 5 Then
            z2 = z1 + (d - AP) * posspa.CosDiritta.Z
        Else
            z2 = z1 + (d / 2 + AP) * posspa.CosDiritta.Z
        End If
        Verso = (z1 + z2) / 2
        If z1 < 0 And z2 < 0 Then
            Exit Sub
        Else
            x = posspa.Origine.X ' * Scalb!
            y = posspa.Origine.y ' * Scalb!
1631:       Re = (d / 2 + T1) '* Scalb!
            If IUNL = 4 Then
                SpotFon1()
                Exit Sub
            End If
            '       IF z1 > 0 AND z2 > 0 THEN
            Call Infilata(Oggetto, Verso, InMezzo)
            If InMezzo > 1 Then Exit Sub
            If InMezzo = 1 Then Call Funzioni.DisRut.ctrait(3, 0.1) Else Call Funzioni.DisRut.ctrait(0, 0.1)
            '       END IF
            '       Call Funzioni.DisRut.refabs
            '       Call Funzioni.DisRut.refere(offx!, offy!, 0)
            Call Funzioni.DisRut.ctrait(0, 0.1)
            Call Funzioni.DisRut.cerc(x, y, Re)
            Call Funzioni.DisRut.refabs()
        End If
        Exit Sub
SpotFon1:
        Spots = New spot
2402:   Spots.Tipo = 2
        Spots.Quota = Verso
        Spots.spicchio.Origin.X = x
        Spots.spicchio.Origin.y = y
        Spots.spicchio.RG = Re
        Spots.spicchio.RP = 0
        Spots.spicchio.Alfa = 2 * PI
        RegisterSpot(Spots, Oggetto)
    End Sub
    Sub DisFon(ByRef Oggetto As Fondo)
        If Oggetto.Diametro = 0 Then Exit Sub
        posspa = Oggetto.GenMem.SwappedPos
        kRapporto = Oggetto.kRapporto
        If kRapporto = 0 Then kRapporto = 0.85
        Tcal = Oggetto.SpessCal
        Direzione.X = 0 : Direzione.y = 0 : Direzione.Z = 1
        prod = posspa.CosDiritta.ProdScalar(Direzione)
        If IUNL = 0 Then
            If System.Math.Abs(prod) > TOLER Then 'pianta
                xSmin = -0.6 * (Oggetto.Diametro + 2 * Oggetto.SpessBase)
                ySmin = xSmin : xSmax = -xSmin : ySmax = -ySmin
            Else
                xSmin = -Oggetto.Diametro / 10 : ySmin = -0.6 * (Oggetto.Diametro + 2 * Oggetto.SpessBase) : xSmax = 0.6 * Oggetto.Diametro : ySmax = -ySmin
            End If
            If Not Funzioni.DisRut.Scala(xSmin, xSmax, ySmin, ySmax) Then Exit Sub
        End If
        If System.Math.Abs(prod) > TOLER Then Call SezRetFon(Oggetto, (Oggetto.Diametro), (Oggetto.Piedritto), (Oggetto.SpessBase)) : Exit Sub
        z1 = posspa.Origine.Z
        If z1 < -Oggetto.Diametro / 2 Then Exit Sub 'fondo indietro
        If z1 > Oggetto.Diametro / 2 Then 'fondo in vista
            iSwSez = False
            Call Infilata(Oggetto, z1, InMezzo)
            If InMezzo > 1 And Not IUNL = 4 Then Exit Sub
        Else 'fondo in sezione
            iSwSez = True
        End If '111
        Call CercaBocchelli(Oggetto, jB, DBuco, OrigB, DirB)
830:    ReDim Preserve n1Int(2 * jB)
        ReDim Preserve n2Int(2 * jB)
        ReDim Preserve DesSin(2, 2 * jB)
        Punti1 = New RoutBase1.clsPunti : Punti2 = New RoutBase1.clsPunti
        Punti1.Inizia(2 * jB) : Punti2.Inizia(2 * jB)
        ' Call Funzioni.DisRut.ctrait(0, 0.1)
        Select Case Oggetto.GenMem.Tipo
            Case 3
                DisEll(Oggetto)
                DisChiu(Oggetto)
            Case 4
                DisTor(Oggetto)
                DisChiu(Oggetto)
            Case 5
                DisSfe(Oggetto)
        End Select
    End Sub
    Private Sub DisChiu(ByVal Oggetto As Fondo)
        If iSwSez Then Exit Sub
        PuntiS = New RoutBase1.clsPunti
        PuntiS.Inizia(2)
        PuntiS.Punti.Item(0).TextData.X = 0
        PuntiS.Punti.Item(0).TextData.y = 0
        PuntiS.Punti.Item(1).TextData.X = 0
        PuntiS.Punti.Item(1).TextData.y = Oggetto.Diametro / 2 + Oggetto.SpessBase + Oggetto.SpessRive
        PuntiS.Punti.Item(2).TextData.X = 0
        PuntiS.Punti.Item(2).TextData.y = -Oggetto.Diametro / 2 - Oggetto.SpessBase - Oggetto.SpessRive
        TrasfGen(posspa, PuntiS, Nothing, 0, 2, False)
        Funzioni.DisRut.tratto(PuntiS.Punti.Item(1).TextData.X, PuntiS.Punti.Item(1).TextData.y, _
                               PuntiS.Punti.Item(2).TextData.X, PuntiS.Punti.Item(2).TextData.y, 0.1, 1)
    End Sub
    Private Sub DisEll(ByVal Oggetto As Fondo)
        'toro equivalente: r=3/16*Oggetto.diametro R=D  cos ginocchio=5/13
        'r=(8k-5)/16/(2k-1)D con R=kD
        'cos ginocchio=(8k-3)/(32k^2-24k+5)
        Ginocchio = (8 * kRapporto - 5) / 16 / (2 * kRapporto - 1) * Oggetto.Diametro
        Hfon = Oggetto.Diametro / 4.0!
        Alfa = Math.Acos((8 * kRapporto - 3) / (32 * kRapporto ^ 2 - 24 * kRapporto + 5))
        If Ginocchio * Hfon * Alfa <= 0 Then Exit Sub
        DisSfe3(Oggetto)
    End Sub
    Private Sub DisTor(ByVal Oggetto As Fondo)
        'r= 1/10*Oggetto.diametro R=D cos ginocchio=4/9
        Ginocchio = 1.0! / 10 * Oggetto.Diametro
        Hfon = Oggetto.Diametro * (1.0! - System.Math.Sqrt(65.0!) / 10)
        Alfa = GlobalRoutines.acos(4.0! / 9.0!)
        kRapporto = 1 '????
        DisSfe3(Oggetto)
    End Sub
    Private Sub DisSfe(ByVal Oggetto As Fondo)
        i1 = 1 : If Not iSwSez Then i1 = -1
        R = Oggetto.Diametro / 2 + Oggetto.SpessBase / 2
        Alfa = PI - 2 * GlobalRoutines.asin(Oggetto.Piedritto / (R - Oggetto.SpessBase / 2))
        DirR.X = 1.0! : DirR.y = 0.0!
        Origine.X = -Oggetto.Piedritto : Origine.y = 0
        DisSfe1(Oggetto)
        If IUNL = 4 Then
            SpotsSfe(Oggetto)
            Exit Sub
        End If
        If Oggetto.SpessRive = 0 Then Funzioni.DisRut.tratto((PuntiS.Punti0(0).X), (PuntiS.Punti0(0).y), (PuntiS.Punti0(2).X), (PuntiS.Punti0(2).y), 0.1, 0) 'chiusura
        If IUNL = 0 Then
            Funzioni.DisRut.tratto((PuntiS.Punti0(0).X + PuntiD.Punti0(0).X) / 2, (PuntiS.Punti0(0).y + PuntiD.Punti0(0).y) / 2, (PuntiS.Punti0(2).X + PuntiD.Punti0(2).X) / 2, (PuntiS.Punti0(2).y + PuntiD.Punti0(2).y) / 2, 0.1, 3)
            zerox = ((PuntiS.Punti0(0).X + PuntiD.Punti0(0).X) / 2 + (PuntiS.Punti0(2).X + PuntiD.Punti0(2).X) / 2) / 2
            zeroy = ((PuntiS.Punti0(0).y + PuntiD.Punti0(0).y) / 2 + (PuntiS.Punti0(2).y + PuntiD.Punti0(2).y) / 2) / 2
            Funzioni.DisRut.tratto(zerox - SP.RG / 5, zeroy, zerox + SP.RG * 1.2, zeroy, 0.1, 3)
            Funzioni.DisRut.Freccia(Int(zerox + SP.RG * 1.2), Int(zeroy))
        End If
        If Oggetto.SpessRive = 0 Then Return
        Oggetto.Diametro = Oggetto.Diametro - 2 * Oggetto.SpessRive
        Oggetto.SpessBase = Oggetto.SpessRive
        R = Oggetto.Diametro / 2 + Oggetto.SpessBase / 2
        DisSfe1(Oggetto)
        Funzioni.DisRut.tratto((PuntiS.Punti0(0).X), (PuntiS.Punti0(0).y), (PuntiS.Punti0(2).X), (PuntiS.Punti0(2).y), 0.1, 0)
    End Sub
    Private Sub DisSfe1(ByVal Oggetto As Fondo)
        SP = New Spicchio4
        Origine.copia((SP.Origin))
        SP.RG = R + Oggetto.SpessBase / 2
        SP.RP = R - Oggetto.SpessBase / 2
        DirR.copia((SP.Direct))
        SP.Alfa = Alfa
        kRP = 0 : kRG = 0
        If IUNL >= 2 Then
            '      Set Dir = New clsvec2
510:        DirR.X = posspa.CosDiritta.X
            DirR.y = posspa.CosDiritta.y
            Centr.X = 0 : Centr.y = 0
            TraslRot((SP.Origin), Centr, DirR)
            SP.Origin.X = SP.Origin.X + posspa.Origine.X
            SP.Origin.y = SP.Origin.y + posspa.Origine.y
            GlobalRoutines.ComposDir((SP.Direct), DirR)
            Raggio = SP.RG : ik = 1
            Intersec()
            kRG = k 'in Punti(1,k) le intersezioni ordinate
            Raggio = SP.RP : ik = 2
            Intersec()
            kRP = k 'in Punti(2,k) le intersezioni ordinate
        End If
        If kRG = 0 And kRP = 0 And IUNL <> 4 Then
            SP.SpicGraf(i1, PuntiS, PuntiD)
        ElseIf IUNL <> 4 Then
            If i1 < 2 Then
                ang = GlobalRoutines.arco((SP.Direct.X), (SP.Direct.y))
                PuntiS = New RoutBase1.clsPunti : PuntiD = New RoutBase1.clsPunti
                PuntiS.Inizia(3) : PuntiD.Inizia(3)
                For i = 0 To 2
                    PuntiS.Punti.Item(i + 1).TextData.X = SP.Origin.X + SP.RP * _
                                            System.Math.Cos(ang + (i - 1) * SP.Alfa / 2)
                    PuntiD.Punti.Item(i + 1).TextData.X = SP.Origin.X + SP.RG * _
                                            System.Math.Cos(ang + (i - 1) * SP.Alfa / 2)
                    PuntiS.Punti.Item(i + 1).TextData.y = SP.Origin.y + SP.RP * _
                                            System.Math.Sin(ang + (i - 1) * SP.Alfa / 2)
                    PuntiD.Punti.Item(i + 1).TextData.y = SP.Origin.y + SP.RG * _
                                            System.Math.Sin(ang + (i - 1) * SP.Alfa / 2)
                    If i <> 1 Then Funzioni.DisRut.tratto(PuntiS.Punti.Item(i + 1).TextData.X, _
                                                          PuntiS.Punti.Item(i + 1).TextData.y, _
                                                          PuntiD.Punti.Item(i + 1).TextData.X, _
                                                          PuntiD.Punti.Item(i + 1).TextData.y, 0.1, 0)
                Next
            End If
            If kRG = kRP Then
540:            For i = 1 To kRG
                    Funzioni.DisRut.tratto(Punti1.Punti.Item(i).TextData.X, Punti1.Punti.Item(i).TextData.y, _
                                           Punti2.Punti.Item(i).TextData.X, Punti2.Punti.Item(i).TextData.y, 0.1, 0)
                Next
            Else
                MsgBox("Da completare in DisFon" & Str(kRG) & Str(kRP))
            End If
            kkk = kRG : ik = 1 : Raggio = SP.RG
            TracArc()
            kkk = kRP : ik = 2 : Raggio = SP.RP
            TracArc()
        End If
    End Sub
    Private Sub DisSfe2(ByVal Oggetto As Fondo)
        i1 = 2 : If Not iSwSez Then i1 = -1
        Alfa = PI - 2 * Alfa
        DirR.X = 1 : DirR.y = 0
        Origine.X = Oggetto.Piedritto - (kRapporto * Oggetto.Diametro - Hfon)
        Origine.y = 0
        DisSfe1(Oggetto)
        If IUNL = 4 Then
            SpotsSfe(Oggetto)
        End If
        R = Ginocchio + Oggetto.SpessBase / 2
        Alfa = PI / 2 - Alfa / 2
        'Set Dir = New clsvec2
        DirR.X = System.Math.Cos(PI / 2 - Alfa / 2)
        DirR.y = System.Math.Sin(PI / 2 - Alfa / 2)
        Origine.X = Oggetto.Piedritto
        Origine.y = Oggetto.Diametro / 2 - Ginocchio
        DisSfe1(Oggetto)
        If IUNL = 4 Then
            SpotsSfe(Oggetto)
        End If
        DirR = New RoutBase1.clsVec2
        DirR.X = System.Math.Cos(PI / 2 - Alfa / 2)
        DirR.y = -System.Math.Sin(PI / 2 - Alfa / 2)
        Origine.y = -Origine.y
        DisSfe1(Oggetto)
        If IUNL = 4 Then
            SpotsSfe(Oggetto)
        End If
    End Sub
    Private Sub Piedi(ByVal Oggetto As Fondo)
        MakeCorners(Rett1, (Oggetto.SpessBase), (Oggetto.Piedritto))
        Rett2 = Rett1.Clone
        TrasfRett(Rett1, 1.0!, Oggetto.Piedritto / 2, Oggetto.Diametro / 2)
        If IUNL >= 2 Then
            TrasfRett(Rett1, 1.0!, (posspa.Origine.X), (posspa.Origine.y))
            DirR.X = posspa.CosDiritta.X : DirR.y = posspa.CosDiritta.y
            RotRett(Rett1, (posspa.Origine.X), (posspa.Origine.y), GlobalRoutines.arco((DirR.X), (DirR.y)))
        End If
        If iSwSez Then
            RettGraf(Rett1, 2)
        Else
            Funzioni.DisRut.tratto(Rett1.Corners(3).X, Rett1.Corners(3).y, Rett1.Corners(4).X, Rett1.Corners(4).y, 0.1, 0)
        End If
        TrasfRett(Rett2, 1.0!, Oggetto.Piedritto / 2, -Oggetto.Diametro / 2 - Oggetto.SpessBase)
        If IUNL >= 2 Then
            TrasfRett(Rett2, 1.0!, (posspa.Origine.X), (posspa.Origine.y))
            DirR.X = posspa.CosDiritta.X : DirR.y = posspa.CosDiritta.y
            RotRett(Rett2, (posspa.Origine.X), (posspa.Origine.y), GlobalRoutines.arco((DirR.X), (DirR.y)))
        End If
        If iSwSez Then
            RettGraf(Rett2, 2)
        Else
            Funzioni.DisRut.tratto(Rett2.Corners(1).X, Rett2.Corners(1).y, Rett2.Corners(2).X, Rett2.Corners(2).y, 0.1, 0)
        End If
        '      IF Oggetto.piedritto > 0 THEN
        '         Funzioni.DisRut.tratto Rett2.Corners(2).X, Rett2.Corners(2).Y, Rett2.Corners(3).X, Rett2.Corners(3).Y, .1, 0
        '         IF IUNL < 3 THEN PSET (Rett2.Corners(2).X, ymax + ymin - Rett2.Corners(2).Y): PSET (Rett2.Corners(3).X, ymax + ymin - Rett2.Corners(3).Y)
        '      END IF
        '    Direzione.X = Rec2Buf(3).PosSpa.Origine.X + Oggetto.piedritto * Rec2Buf(3).PosSpa.CosDiritta.X
        '    Direzione.Y = Rec2Buf(3).PosSpa.Origine.Y + Oggetto.piedritto * Rec2Buf(3).PosSpa.CosDiritta.Y
        '    Direzione.Z = Rec2Buf(3).PosSpa.Origine.Z + Oggetto.piedritto * Rec2Buf(3).PosSpa.CosDiritta.Z
        '      r1 = ProdScalar(Direzione, Rec2Buf(3).PosSpa.CosDiritta)
        '      CALL CercaInt(Oggetto,R1 + 0, Dint1, Oggetto.diametro + 0)
        '      Xout1 = Rett1.Corners(3).X: Yout1 = Rett1.Corners(3).Y
        '      Xout2 = Rett2.Corners(2).X: Yout2 = Rett2.Corners(2).Y
        '      Xin1 = Xout1 + (Xout2 - Xout1) * (Oggetto.diametro - Dint1) / Oggetto.diametro / 2
        '      Yin1 = Yout1 + (Yout2 - Yout1) * (Oggetto.diametro - Dint1) / Oggetto.diametro / 2
        '      Xin2 = Xout2 - (Xout2 - Xout1) * (Oggetto.diametro - Dint1) / Oggetto.diametro / 2
        '      Yin2 = Yout2 - (Yout2 - Yout1) * (Oggetto.diametro - Dint1) / Oggetto.diametro / 2
        '      Funzioni.DisRut.tratto Xout1, Yout1, Xin1, Yin1, .1, 3
        '      Funzioni.DisRut.tratto Xout2, Yout2, Xin2, Yin2, .1, 3
    End Sub
    Private Sub DisSfe3(ByVal Oggetto As Fondo)
        R = kRapporto * Oggetto.Diametro + Oggetto.SpessBase / 2
        DisSfe2(Oggetto)
        If Oggetto.SpessRive > 0 Then
            T1sav = Oggetto.SpessBase : GinSav = Ginocchio
            Oggetto.SpessBase = Oggetto.SpessRive : R = Oggetto.Diametro - Oggetto.SpessBase / 2
            Ginocchio = Ginocchio - Oggetto.SpessBase
            DisSfe2(Oggetto)
            Oggetto.SpessBase = T1sav : Ginocchio = GinSav
        End If
        Piedi(Oggetto)
        MakeCorners(Rett1, CSng(Oggetto.SpessBase), Oggetto.Piedritto + Hfon * 1.2)
        Rett2 = Rett1.Clone
        TrasfRett(Rett1, 1.0!, (1.2 * Hfon + Oggetto.Piedritto) / 2, CSng(Oggetto.Diametro) / 2)
        If IUNL >= 2 Then
            TrasfRett(Rett1, 1.0!, (posspa.Origine.X), (posspa.Origine.y))
            DirR.X = posspa.CosDiritta.X : DirR.y = posspa.CosDiritta.y
            RotRett(Rett1, (posspa.Origine.X), (posspa.Origine.y), GlobalRoutines.arco((DirR.X), (DirR.y)))
        End If
        TrasfRett(Rett2, 1.0!, (1.2 * Hfon + Oggetto.Piedritto) / 2, -CSng(Oggetto.Diametro) / 2 - Oggetto.SpessBase)
        If IUNL >= 2 Then
            TrasfRett(Rett2, 1.0!, (posspa.Origine.X), (posspa.Origine.y))
            DirR.X = posspa.CosDiritta.X : DirR.y = posspa.CosDiritta.y
            RotRett(Rett2, (posspa.Origine.X), (posspa.Origine.y), GlobalRoutines.arco((DirR.X), (DirR.y)))
        End If
        If Oggetto.SpessRive > 0 Then
            Oggetto.Diametro = Oggetto.Diametro - Oggetto.SpessRive
            Oggetto.SpessBase = Oggetto.SpessRive
            Piedi(Oggetto)
        End If
    End Sub
    Private Sub SpotsSfe(ByVal Oggetto As Fondo)
        Spots = New spot
        Spots.Tipo = 2
        Spots.spicchio = SP
        Spots.Quota = 0
        RegisterSpot(Spots, Oggetto)
    End Sub
    Private Sub Angoli()
        Raggio = System.Math.Sqrt((Punti.Punti.Item(iAng).TextData.X - SP.Origin.X) ^ 2 + (Punti.Punti.Item(iAng).TextData.y - SP.Origin.y) ^ 2)
        DirR.X = (Punti.Punti.Item(iAng).TextData.X - SP.Origin.X) / Raggio
        DirR.y = (Punti.Punti.Item(iAng).TextData.y - SP.Origin.y) / Raggio
        anom = GlobalRoutines.arco((DirR.X), (DirR.y))
        If anom > GlobalRoutines.arco((SP.Direct.X), (SP.Direct.y)) - SP.Alfa / 2 And anom < GlobalRoutines.arco((SP.Direct.X), (SP.Direct.y)) + SP.Alfa / 2 Then Return
        anom = -1.0!
    End Sub
    Private Sub Intersec()
        k = 0
        For j = 1 To jB
            Linea = New RoutBase1.clsLinea2
            Linea.P0 = OrigB.Punti.Item(j).TextData
            Linea.Direz = DirB.Punti.Item(j).TextData
            Punti = New RoutBase1.clsPunti
            Punti.Inizia(4)
600:        Linea.InterRettCerch(DBuco(j) / 2, (SP.Origin), Raggio, Punti, n1Int(j), n2Int(j))
601:        If n1Int(j) > 0 Then
                iAng = 1
                Angoli()
                If anom = -1.0! Then
                    n1Int(j) = n1Int(j) - 1
                    Punti.SWAP(1, 2)
                    '            SWAP P0(1).Y, P0(2).Y
                    GoTo 601
                End If
            End If
            If n1Int(j) = 2 Then
                iAng = 2
                Angoli()
                If anom = -1 Then n1Int(j) = 1
            End If
603:        If n2Int(j) > 0 Then
                iAng = 3
                Angoli()
                If anom = -1 Then
                    n2Int(j) = n2Int(j) - 1
                    Punti.SWAP(3, 4)
                    '              SWAP P0(3).Y, P0(4).Y
                    GoTo 603
                End If
            End If
            If n2Int(j) = 2 Then
                iAng = 4
                Angoli()
                If anom = -1 Then n2Int(j) = 1
            End If
            Select Case ik
                Case 1
610:                If n1Int(j) > 0 Then
                        k = k + 1
                        Punti.Punti.Item(1).TextData.copia(Punti1.Punti.Item(k).TextData)
                        DesSin(ik, k) = -1
                    End If
                    If n1Int(j) = 2 Then
                        k = k + 1
                        Punti.Punti.Item(2).TextData.copia(Punti1.Punti.Item(k).TextData)
                        DesSin(ik, k) = -1
                    End If
                    If n2Int(j) > 0 Then
                        k = k + 1
                        Punti.Punti.Item(3).TextData.copia(Punti1.Punti.Item(k).TextData)
                        DesSin(ik, k) = 1
                    End If
620:                If n2Int(j) = 2 Then
                        k = k + 1
                        Punti.Punti.Item(4).TextData.copia(Punti1.Punti.Item(k).TextData)
                        DesSin(ik, k) = 1
                    End If
                Case 2
                    If n1Int(j) > 0 Then
                        k = k + 1
                        Punti.Punti.Item(1).TextData.copia(Punti2.Punti.Item(k).TextData)
                        DesSin(ik, k) = -1
                    End If
                    If n1Int(j) = 2 Then
                        k = k + 1
                        Punti.Punti.Item(2).TextData.copia(Punti2.Punti.Item(k).TextData)
                        DesSin(ik, k) = -1
                    End If
                    If n2Int(j) > 0 Then
                        k = k + 1
                        Punti.Punti.Item(3).TextData.copia(Punti2.Punti.Item(k).TextData)
                        DesSin(ik, k) = 1
                    End If
                    If n2Int(j) = 2 Then
                        k = k + 1
                        Punti.Punti.Item(4).TextData.copia(Punti2.Punti.Item(k).TextData)
                        DesSin(ik, k) = 1
                    End If
            End Select
        Next
        'ordinare per alfa crescente
RifOrd:
        For j = 1 To k - 1
            Select Case ik
                Case 1
                    Raggio1 = System.Math.Sqrt((Punti1.Punti.Item(j).TextData.X - SP.Origin.X) ^ 2 + (Punti1.Punti.Item(j).TextData.y - SP.Origin.y) ^ 2)
                    DirR.X = (Punti1.Punti.Item(j).TextData.X - SP.Origin.X) / Raggio1
                    DirR.y = (Punti1.Punti.Item(j).TextData.y - SP.Origin.y) / Raggio1
                    Alfa1 = GlobalRoutines.arco((DirR.X), (DirR.y))
                    For jj = j + 1 To k
                        Raggio1 = System.Math.Sqrt((Punti1.Punti.Item(jj).TextData.X - SP.Origin.X) ^ 2 + (Punti1.Punti.Item(jj).TextData.y - SP.Origin.y) ^ 2)
                        DirR.X = (Punti1.Punti.Item(jj).TextData.X - SP.Origin.X) / Raggio1
                        DirR.y = (Punti1.Punti.Item(jj).TextData.y - SP.Origin.y) / Raggio1
                        Alfa2 = GlobalRoutines.arco((DirR.X), (DirR.y))
                        If Alfa2 < Alfa1 Then
                            Punti1.SWAP(j, jj)
                            '          SWAP Punti(ik, j).TextData.y, Punti(ik, jj).TextData.y
                            GoTo RifOrd
                        End If
                    Next jj
                Case 2
                    Raggio1 = System.Math.Sqrt((Punti2.Punti.Item(j).TextData.X - SP.Origin.X) ^ 2 + (Punti2.Punti.Item(j).TextData.y - SP.Origin.y) ^ 2)
                    DirR.X = (Punti2.Punti.Item(j).TextData.X - SP.Origin.X) / Raggio1
                    DirR.y = (Punti2.Punti.Item(j).TextData.y - SP.Origin.y) / Raggio1
                    Alfa1 = GlobalRoutines.arco((DirR.X), (DirR.y))
                    For jj = j + 1 To k
                        Raggio1 = System.Math.Sqrt((Punti2.Punti.Item(jj).TextData.X - SP.Origin.X) ^ 2 + (Punti2.Punti.Item(jj).TextData.y - SP.Origin.y) ^ 2)
                        DirR.X = (Punti2.Punti.Item(jj).TextData.X - SP.Origin.X) / Raggio1
                        DirR.y = (Punti2.Punti.Item(jj).TextData.y - SP.Origin.y) / Raggio1
                        Alfa2 = GlobalRoutines.arco((DirR.X), (DirR.y))
                        If Alfa2 < Alfa1 Then
                            Punti2.SWAP(j, jj)
                            '          SWAP Punti(ik, j).TextData.y, Punti(ik, jj).TextData.y
                            GoTo RifOrd
                        End If
                    Next jj
            End Select
        Next
    End Sub
    Private Sub TracArc()
        For i = 0 To kkk
            If i > 0 And i < kkk Then
                Logic = (DesSin(ik, i) = -1 And DesSin(ik, i + 1) = 1)
            End If
550:        If i = 0 Or i = kkk Or (i > 0 And i < kkk And Not Logic) Then
                Select Case ik
                    Case 1 : Punti12 = Punti1
                    Case 2 : Punti12 = Punti2
                End Select
                If i = 0 Then
                    Alfa1 = GlobalRoutines.arco((SP.Direct.X), (SP.Direct.y)) - SP.Alfa / 2
                    If kkk = 0 Then
                        Alfa2 = GlobalRoutines.arco((SP.Direct.X), (SP.Direct.y)) + SP.Alfa / 2
                    Else
                        Raggio1 = System.Math.Sqrt((Punti12.Punti.Item(i + 1).TextData.X - SP.Origin.X) ^ 2 + (Punti12.Punti.Item(i + 1).TextData.y - SP.Origin.y) ^ 2)
                        DirR.X = (Punti12.Punti.Item(i + 1).TextData.X - SP.Origin.X) / Raggio1
                        DirR.y = (Punti12.Punti.Item(i + 1).TextData.y - SP.Origin.y) / Raggio1
                        Alfa2 = GlobalRoutines.arco((DirR.X), (DirR.y))
                    End If
                ElseIf i = kkk Then
                    Raggio1 = System.Math.Sqrt((Punti12.Punti.Item(i).TextData.X - SP.Origin.X) ^ 2 + (Punti12.Punti.Item(i).TextData.y - SP.Origin.y) ^ 2)
                    DirR.X = (Punti12.Punti.Item(i).TextData.X - SP.Origin.X) / Raggio1
                    DirR.y = (Punti12.Punti.Item(i).TextData.y - SP.Origin.y) / Raggio1
                    Alfa1 = GlobalRoutines.arco((DirR.X), (DirR.y))
                    Alfa2 = GlobalRoutines.arco((SP.Direct.X), (SP.Direct.y)) + SP.Alfa / 2
                Else
                    Raggio1 = System.Math.Sqrt((Punti12.Punti.Item(i).TextData.X - SP.Origin.X) ^ 2 + (Punti12.Punti.Item(i).TextData.y - SP.Origin.y) ^ 2)
                    DirR.X = (Punti12.Punti.Item(i).TextData.X - SP.Origin.X) / Raggio1
                    DirR.y = (Punti12.Punti.Item(i).TextData.y - SP.Origin.y) / Raggio1
                    Alfa1 = GlobalRoutines.arco((DirR.X), (DirR.y))
                    Raggio1 = System.Math.Sqrt((Punti12.Punti.Item(i + 1).TextData.X - SP.Origin.X) ^ 2 + (Punti12.Punti.Item(i + 1).TextData.y - SP.Origin.y) ^ 2)
                    DirR.X = (Punti12.Punti.Item(i + 1).TextData.X - SP.Origin.X) / Raggio1
                    DirR.y = (Punti12.Punti.Item(i + 1).TextData.y - SP.Origin.y) / Raggio1
                    Alfa2 = GlobalRoutines.arco((DirR.X), (DirR.y))
                End If
                DirR.X = System.Math.Cos((Alfa1 + Alfa2) / 2)
                DirR.y = System.Math.Sin((Alfa1 + Alfa2) / 2)
560:            ArcoGraf((SP.Origin), Raggio, DirR, Alfa2 - Alfa1, IUNL - 1)
            End If
570:    Next
        If i1 > 0 And SP.RP = Raggio And SP.RG - SP.RP > 2 And IUNL < 3 Then
            x = SP.Origin.X + (SP.RG + SP.RP) / 2 * DirR.X
            y = SP.Origin.y + (SP.RG + SP.RP) / 2 * DirR.y
            '580     PAINT (x, ymax + ymin - y), 0, 15
        End If
    End Sub
    Sub LeggiBuchi(ByRef Oggetto As Membratura, ByRef jsopra As Short, ByRef quosopra() As Single, ByRef DBucosopra() As Single, ByRef jsotto As Short, ByRef quosotto() As Single, ByRef DBucosotto() As Single, ByRef LC1 As Short, ByRef LC2 As Short)
        Dim Direzione As New RoutBase1.clsVec3
        Dim j As Short
        Dim Quota, anom As Single
        Dim j1 As Short
        Dim DBuco As Single
        Dim Bucante As Membratura
        Dim posspa As Posizione
        If IUNL >= 2 Then
            jsopra = 0 : jsotto = 0 : Direzione.X = 0 : Direzione.y = 0 : Direzione.Z = 1
            ReDim DBucosopra(10), DBucosotto(10)
            ReDim quosopra(10), quosotto(10)
            Dim n As OggList.NodeP = ApparProv.Elementi.nodeHead.Next
            Dim gm As clsGenMem
            Dim Ogg As Membratura
            While Not n Is Nothing
                Ogg = n.TextData
                gm = Ogg.GenMem
                If gm.Tipo = 97 Then
                    If gm.posizione.SuChi Is Oggetto Then
                        Quota = CType(Ogg, Foratura).Quota
                        anom = CType(Ogg, Foratura).anom
                        Bucante = CType(Ogg, Foratura).Bucante
                        SwapCoordN(Bucante.GenMem)
                        posspa = Bucante.GenMem.SwappedPos
                        If System.Math.Abs(posspa.CosDiritta.Z) < TOLER Then
                            If Bucante.GenMem.Tipo = 14 Or Bucante.GenMem.Tipo = 10 Then
                                DBuco = Bucante.Diamint + 2 * Bucante.Standard.SpessTr
                                If Bucante.DiamRinf > DBuco Then DBuco = Bucante.DiamRinf
                                If Bucante.DiamScarpa > DBuco Then DBuco = Bucante.DiamScarpa
                            Else
                                DBuco = Bucante.Diametro + Bucante.Spessore * 2
                            End If
                            If Oggetto.GenMem.SwappedPos.CosDiritta.ProdTripl(posspa.CosDiritta, Direzione) > 0 Then
                                jsopra = jsopra + 1
                                quosopra(jsopra) = Quota
                                DBucosopra(jsopra) = DBuco
                            Else
                                jsotto = jsotto + 1
                                quosotto(jsotto) = Quota
                                DBucosotto(jsotto) = DBuco
                            End If
                        End If
                    End If
                End If
                n = n.Next
            End While
        End If
        'ordinamento-----------------------
        For j = 1 To jsopra
            For j1 = j + 1 To jsopra
                If quosopra(j1) < quosopra(j) Then
2002:               GlobalRoutines.SWAP(quosopra(j1), quosopra(j))
                    GlobalRoutines.SWAP(DBucosopra(j1), DBucosopra(j))
                End If
            Next j1
        Next j
        quosopra(jsopra + 1) = LC1
        For j = 1 To jsotto
            For j1 = j + 1 To jsotto
                If quosotto(j1) < quosotto(j) Then
                    GlobalRoutines.SWAP(quosotto(j1), quosotto(j))
                    GlobalRoutines.SWAP(DBucosotto(j1), DBucosotto(j))
                End If
            Next j1
        Next j
        quosotto(jsotto + 1) = LC2
    End Sub
    Sub DisSpicchi(ByRef Oggetto As Cono, ByRef Alfa As Single, ByRef Gener As Single)
        With Oggetto
            posspa = .GenMem.SwappedPos
            If System.Math.Abs(Alfa) < TOLER Then Exit Sub
            PrepSpicchi(Oggetto)
            If IUNL >= 2 Then
                DirR.X = posspa.CosDiritta.X : DirR.y = posspa.CosDiritta.y
                TrasfSpicchi(Oggetto)
            End If
            If IUNL <> 4 Then
                If System.Math.Abs(Alfa) > TOLER Then
                    If .RagG = 0 Then Mode = 2 Else Mode = 0
                    Sp1.SpicGraf(Mode, PuntiS, PuntiD)
                    If .RagP = 0 Then Mode = 2 Else Mode = 0
320:                Sp2.SpicGraf(Mode, PuntiS, PuntiD)
                End If
            End If
        End With
    End Sub
    Private Sub PrepSpicchi(ByVal Oggetto As Cono)
        With Oggetto
330:        Sp1.Origin.X = .PiedG
            If .Fitting Then
                Sp1.Origin.y = (.Dgran / 2 - .RagG - .SpessBase) * System.Math.Sign(Alfa)
                D11 = (.Dpicc / 2 + .RagP)
            Else
                Sp1.Origin.y = (.Dgran / 2 - .RagG) * System.Math.Sign(Alfa)
                D11 = (.Dpicc / 2 + .RagP + .SpessBase)
            End If
            Sp2.Origin.X = .Altezza - .PiedP
            If .GenMem.Tipo = 6 Then
                If .Fitting Then
                    D11 = .Dgran / 2 - (.RagG + .RagP) * (1.0! - System.Math.Cos(Alfa)) - Gener * System.Math.Sin(System.Math.Abs(Alfa)) + .RagP
                Else
                    D11 = .Dgran / 2 - (.RagG + .RagP + .SpessBase) * (1.0! - System.Math.Cos(Alfa)) - Gener * System.Math.Sin(System.Math.Abs(Alfa)) + .RagP + .SpessBase
                End If
            End If
332:        Sp2.Origin.y = D11 * System.Math.Sign(Alfa)
            Sp1.RG = .RagG + .SpessBase : Sp1.RP = .RagG
            Sp2.RG = .RagP + .SpessBase : Sp2.RP = .RagP
            Sp1.Direct.X = System.Math.Sin(Alfa / 2) * System.Math.Sign(Alfa) : Sp1.Direct.y = System.Math.Cos(Alfa / 2) * System.Math.Sign(Alfa)
            Sp2.Direct.X = -Sp1.Direct.X : Sp2.Direct.y = -Sp1.Direct.y
333:        Sp1.Alfa = System.Math.Abs(Alfa) : Sp2.Alfa = System.Math.Abs(Alfa)
        End With
    End Sub
    Private Sub TrasfSpicchi(ByVal Oggetto As Cono)
340:    Centr.X = 0 : Centr.y = 0
        TraslRot((Sp1.Origin), Centr, DirR)
        TraslRot((Sp2.Origin), Centr, DirR)
        Sp1.Origin.X = Sp1.Origin.X + posspa.Origine.X
        Sp1.Origin.y = Sp1.Origin.y + posspa.Origine.y
        Sp2.Origin.X = Sp2.Origin.X + posspa.Origine.X 'meno
        Sp2.Origin.y = Sp2.Origin.y + posspa.Origine.y 'meno
        Call GlobalRoutines.ComposDir((Sp1.Direct), DirR)
        Call GlobalRoutines.ComposDir((Sp2.Direct), DirR)
    End Sub
    Sub DisPiedritti(ByRef Oggetto As Cono, ByRef Rett1 As RoutBase1.clsRectang, ByRef Rett2 As RoutBase1.clsRectang, ByRef Alfa As Single, ByRef j As Short, ByRef Gener As Single)
        Dim Rext As Single
        With Oggetto
            If .PiedG > 0 Then
                MakeCorners(Rett1, .SpessBase, .PiedG)
                If .Fitting Then
                    Rext = (.Dgran / 2) * j
                Else
                    Rext = (.Dgran / 2 + .SpessBase) * j
                End If
                Call DisGener((.GenMem.SwappedPos), Rett1, .PiedG, 0.0!, Rext, 0.0!, .SpessBase)
            End If
            If .PiedP > 0 Then
                MakeCorners(Rett2, .SpessBase, .PiedP)
                If .Fitting Then
                    Rext = (.Dpicc / 2)
                Else
                    Rext = (.Dpicc / 2 + .SpessBase)
                End If
                If .GenMem.Tipo = 6 Then
                    '       Rext = Look.d / 2 - (Look.R + Look.R1 + Look.T1) * (1 - Cos(Alfa)) - Gener * Sin(Abs(Alfa)) + Look.R1
                    If .Fitting Then
                        Rext = .Dgran / 2 - (.RagG + .RagP + .SpessBase) * (1 - System.Math.Cos(Alfa)) - Gener * System.Math.Sin(System.Math.Abs(Alfa)) '+ Look.T1
                    Else
                        Rext = .Dgran / 2 + .SpessBase - (.RagG + .RagP + .SpessBase) * (1 - System.Math.Cos(Alfa)) - Gener * System.Math.Sin(System.Math.Abs(Alfa)) '+ Look.T1
                    End If
                End If
                Rext = Rext * j
                Call DisGener((.GenMem.SwappedPos), Rett2, -.PiedP, .Altezza, Rext, 0.0!, .SpessBase)
            End If
        End With
    End Sub
    Sub DisCon(ByRef Oggetto As Cono)
        posspa = Oggetto.GenMem.SwappedPos
        Alfa = Oggetto.AlfaCon * PI / 180
        If IUNL = 0 Then
            xSmin = -Oggetto.Altezza / 5 : ySmin = 1.2 * (-(Oggetto.Dgran + Oggetto.SpessBase * 2) / 2) : xSmax = 1.5 * Oggetto.Altezza : ySmax = -ySmin
            If Not Funzioni.DisRut.Scala(xSmin, xSmax, ySmin, ySmax) Then
                '      If Not MembroLoc Is Nothing Then Set Membro = MembroLoc
                Exit Sub
            End If
        End If
        Direzione.X = 0 : Direzione.y = 0 : Direzione.Z = 1
        prod = posspa.CosDiritta.ProdScalar(Direzione)
        Verso = posspa.Origine.Z
        If System.Math.Abs(prod) < TOLER Then
            ConLun(Oggetto)
        Else
            ConRett(Oggetto)
        End If
    End Sub
    Private Sub ConRett(ByVal Oggetto As Membratura)
101:    z1 = posspa.Origine.Z
        z2 = posspa.Origine.Z + Oggetto.Altezza * posspa.CosDiritta.Z
        x = posspa.Origine.X
102:    y = posspa.Origine.y
        If z1 * z2 < 0 Then
            GeomSezCon(Oggetto)
            'Call Funzioni.DisRut.ctrait(0, 0.1)
            Dis2Cerchi(Oggetto)
            BordoInVista(Oggetto)
            SpotsCon(Oggetto)
            If IUNL = 4 Then Spots.Quota = 0
        ElseIf z1 > 0 And z2 > 0 Then  '(cono davanti)
1107:       Call Infilata(Oggetto, (z1 + z2) / 2, InMezzo)
            If InMezzo > 1 Then
                '  If Not MembroLoc Is Nothing Then Set Membro = MembroLoc
                Exit Sub
            End If
            '       If inMezzo = 1 Then Call Funzioni.DisRut.ctrait(3, 0.1) Else Call Funzioni.DisRut.ctrait(0, 0.1)
            GeomVistaCon(Oggetto)
            Dis2Cerchi(Oggetto)
            BordoInVista(Oggetto)
            'Call Funzioni.DisRut.ctrait(0, 0.1)
            SpotsCon(Oggetto)
            If IUNL = 4 Then Spots.Quota = (z1 + z2) / 2
        End If
    End Sub
    Private Sub Dis2Cerchi(ByVal Oggetto As Cono)
        x = x ' * Scalb!
        y = y ' * Scalb!
        If IUNL < 4 Then
            '   Call Funzioni.DisRut.refere(offx, offy, 0)
            Call Funzioni.DisRut.cerc(x, y, Ri)
            Call Funzioni.DisRut.cerc(x, y, Re)
            Call Funzioni.DisRut.refabs()
        End If
    End Sub
    Private Sub ConLun(ByVal Oggetto As Cono)
        With Oggetto
            RagP = .RagP
            SpessBase = .SpessBase
            Dgran = .Dgran
            Dpic = .Dpicc
            RagG = .RagG
            If .Fitting Then
                Dgran = Dgran - 2 * SpessBase
                Dpic = Dpic - 2 * SpessBase
            End If
            If Verso < -Dpic / 2 Then Exit Sub
            If Verso > Dpic / 2 Then ' cono in vista
                Call Infilata(Oggetto, Verso, InMezzo)
                If InMezzo > 1 And Not IUNL = 4 Then Exit Sub
                If InMezzo = 1 Then
                    Call Funzioni.DisRut.ctrait(3, 0.1)
                Else
                    Call Funzioni.DisRut.ctrait(0, 0.1)
                End If
                ConSezione(Oggetto)
            Else
                ConSezione(Oggetto)
            End If
        End With
    End Sub
    Private Sub ConSezione(ByVal Oggetto As Cono)
        DisCon1(Oggetto)
        With Oggetto
            If .SpessRive > 0 Then
                RagP = .RagP + .SpessBase
                SpessBase = .SpessRive
                Dgran = .Dgran - 2 * .SpessRive
                Dpic = .Dpicc - 2 * .SpessRive
                RagG = .RagG - .SpessRive
                If RagG < 0 Then RagG = 0
                If RagP < 0 Then RagP = 0
                DisCon1(Oggetto)
            End If
        End With
    End Sub
    Private Sub DisCon1(ByVal Oggetto As Cono)
        Alf(1) = Alfa : Alf(2) = Alfa
        If AddMembrat = 6 Then
            If RagG = 0 And RagP = 0 Then
                Rext = Dgran / 2
                Rextp = Dpic / 2
            Else
                Rext = Dgran / 2 + SpessBase - (RagG + SpessBase / 2) * (1 - System.Math.Cos(Alfa)) / 2
                Rextp = Dpic / 2 + SpessBase + (RagP + SpessBase / 2) * (1 - System.Math.Cos(Alfa)) / 2
            End If
            Centr1.X = 0 : Centr1.y = 0
            Centr.X = 0
            Centr.y = -(Rext - Rextp)
            DirR.X = posspa.CosTraversa.X : DirR.y = posspa.CosTraversa.Z
            Linea = New RoutBase1.clsLinea2
            Linea.P0 = Centr1 : Linea.Direz = DirR
            'da rimettere a posto, prima faceva con CosOrigine
            '  Dir.X = 0: Dir.Y = 1
            Punti = New RoutBase1.clsPunti
            Punti.Inizia(4)
            Linea.InterRettCerch(0, Centr, Rextp, Punti, n1, n2)
            If n1 > 0 Then
                '          Set Linea1 = New clslinea2
                '          Set Linea1.P0 = Punti.Punti(1)
                '          Set Linea1.p1 = Punti.Punti(2)
                '          Linea1.CalcolaDir
                dist1 = System.Math.Sqrt(Punti.Punti.Item(1).TextData.X ^ 2 + Punti.Punti.Item(1).TextData.y ^ 2)
                dist2 = System.Math.Sqrt(Punti.Punti.Item(2).TextData.X ^ 2 + Punti.Punti.Item(2).TextData.y ^ 2)
                dist1 = DirR.X * Punti.Punti.Item(1).TextData.X + DirR.y * Punti.Punti.Item(1).TextData.y
                dist2 = DirR.X * Punti.Punti.Item(2).TextData.X + DirR.y * Punti.Punti.Item(2).TextData.y
                If Oggetto.Altezza = 0 Then Exit Sub
                Alf(1) = System.Math.Atan((Rext - dist1) / Oggetto.Altezza)
                Alf(2) = System.Math.Atan((Rext + dist2) / Oggetto.Altezza)
                If System.Math.Abs(dist2) < System.Math.Abs(dist1) Then GlobalRoutines.SWAP(Alf(1), Alf(2))
            End If
        End If
        If posspa.CosTraversa.Z > 0 Then GlobalRoutines.SWAP(Alf(1), Alf(2))
        Dim RettCon(2) As RoutBase1.clsRectang
        For i = 1 To 2
            Rext = Dgran / 2 + SpessBase - (RagG + SpessBase / 2) * (1 - System.Math.Cos(Alf(i)))
            dy = Oggetto.PiedG + (RagG + SpessBase / 2) * System.Math.Sin(Alf(i))
            If RagG = 0 And RagP = 0 Then
                Gener = Oggetto.Altezza / System.Math.Cos(Alf(i))
            Else
                Gener = (Oggetto.Altezza - Oggetto.PiedG - Oggetto.PiedP - (RagG + SpessBase / 2 + RagP + SpessBase / 2) * System.Math.Sin(Alf(i))) / System.Math.Cos(Alf(i))
                'Gener = Membro.Altezza / Cos(Alf(i)) + (Oggetto.RagG + Oggetto.Spessbase / 2 + Oggetto.RagP + Oggetto.Spessbase / 2) * (Sin(Alfa) - Sin(Alf(i)))
            End If
            RettCon(i) = New clsRectang
            MakeCorners(RettCon(i), SpessBase, Gener)
            If i = 1 Then isign = 1 Else isign = -1
            Call DisGener(posspa, RettCon(i), Gener, dy, isign * Rext, isign * Alf(i), SpessBase)
            If Not IUNL = 4 Then
                If RagG > 0 Then Call DisSpicchi(Oggetto, isign * Alf(i), Gener)
                'piedritti
                'Gener = Membro.Altezza / Cos(Alf(i)) + (Oggetto.RagG + Oggetto.Spessbase / 2 + Oggetto.RagP + Oggetto.Spessbase / 2) * (Sin(Alfa) - Sin(Alf(i)))
                Call DisPiedritti(Oggetto, Rett1, Rett2, Alf(i), -(2 * i - 3), Gener)
                Funzioni.DisRut.tratto(Rett1.Corners(2).X, Rett1.Corners(2).y, Rett1.Corners(3).X, Rett1.Corners(3).y, 0.1, 0)
                Funzioni.DisRut.tratto(Rett2.Corners(1).X, Rett2.Corners(2).y, Rett2.Corners(4).X, Rett2.Corners(3).y, 0.1, 0)
            End If
        Next
        If IUNL = 4 Then
            j = 1
            MinMax(RettCon)
            SetSpot()
            RegisterSpot(Spots, Oggetto)
            j = 2
            MinMax(RettCon)
            SetSpot()
            RegisterSpot(Spots, Oggetto)
        End If
    End Sub
    Private Sub SetSpot()
        Spots = New spot
        Spots.Tipo = 1
        Spots.Quota = Verso
        Spots.Quadro.TopLeft.X = xSmin
        Spots.Quadro.TopLeft.y = ySmin
        Spots.Quadro.Botrigt.X = xSmax
        Spots.Quadro.Botrigt.y = ySmax
    End Sub
    Private Sub MinMax(ByVal RettCon)
        xSmin = clsTrigon.Infinito
        xSmax = -clsTrigon.Infinito
        ySmin = clsTrigon.Infinito
        ySmax = -clsTrigon.Infinito
        For i = 1 To 4
            If RettCon(j).Corners(i).X < xSmin Then xSmin = RettCon(j).Corners(i).X
            If RettCon(j).Corners(i).X > xSmax Then xSmax = RettCon(j).Corners(i).X
            If RettCon(j).Corners(i).y < ySmin Then ySmin = RettCon(j).Corners(i).y
            If RettCon(j).Corners(i).y > ySmax Then ySmax = RettCon(j).Corners(i).y
        Next
    End Sub
    Private Sub GeomSezCon(ByVal Oggetto As Cono)
        Select Case System.Math.Abs(z1)
            Case Is < RagG * System.Math.Cos(Alfa)
103:            delta = (RagG - System.Math.Sqrt(RagG * RagG - z1 * z1))
                If Oggetto.GenMem.Tipo = 6 Then
105:                y = y - delta / 2 * posspa.CosTerza.y
                    x = x - delta / 2 * posspa.CosTerza.X
                    Ri = (Dgran - delta) / 2
                Else
                    Ri = Dgran / 2 - delta
                End If
            Case Is > Oggetto.Altezza - RagP * System.Math.Cos(Alfa)
107:            delta = (RagP - System.Math.Sqrt(RagP * RagP - z2 * z2))
                If Oggetto.GenMem.Tipo = 6 Then
108:                y = y - ((Dgran - Dpic) / 2 - delta / 2) * posspa.CosTerza.y
                    x = x - ((Dgran - Dpic) / 2 - delta / 2) * posspa.CosTerza.X
                    Ri = (Dpic + delta) / 2
                Else
                    Ri = Dpic / 2 + delta
                End If
            Case Else
                delta = RagG * (1 - System.Math.Sin(Alfa)) / 2 - (Oggetto.Altezza - System.Math.Abs(z1) - RagG * System.Math.Cos(Alfa)) * System.Math.Tan(Alfa)
                If Oggetto.GenMem.Tipo = 6 Then
110:                y = y - delta * posspa.CosTerza.y
                    x = x - delta * posspa.CosTerza.X
                    Ri = Dgran / 2 - delta
                Else
                    Ri = Dgran / 2 - 2 * delta
                End If
        End Select
112:    Re = Ri + SpessBase
        Ri = Ri '* Scalb!
        Re = Re ' * Scalb!
    End Sub
    Private Sub GeomVistaCon(ByVal Oggetto As Cono)
        Ri = Dgran / 2
        Re = Ri + SpessBase
        Ri = Ri '* Scalb!
        Re = Re '* Scalb!
    End Sub
    Private Sub BordoInVista(ByVal Oggetto As Cono)
        x1 = posspa.Origine.X
122:    y1 = posspa.Origine.y
        If Oggetto.GenMem.Tipo = 6 Then
            delta = (Dgran - Dpic) / 2
            y1 = y1 - delta * posspa.CosTerza.y
            x1 = x1 - delta * posspa.CosTerza.X
        End If
        x1 = x1 ' * Scalb!
        y1 = y1 '* Scalb!
        rr = Dpic / 2 '* Scalb!
        If IUNL < 4 Then
            '         Call Funzioni.DisRut.refere(offx, offy, 0)
            Call Funzioni.DisRut.ctrait(0, 0.1)
            Call Funzioni.DisRut.cerc(x1, y1, rr)
            Call Funzioni.DisRut.refabs()
        End If
    End Sub
    Private Sub SpotsCon(ByVal Oggetto As Membratura)
        If IUNL = 4 Then
            If rr > Re Then Re = rr
            If rr < Ri Then Ri = rr
            Spots = New spot
114:        Spots.Tipo = 2
            Spots.spicchio.Origin.X = x 'offx + X
            Spots.spicchio.Origin.y = y 'offy + Y
            Spots.spicchio.RG = Re
            Spots.spicchio.RP = Ri
            Spots.spicchio.Alfa = 2 * PI
            Spots.spicchio.Direct.X = 0
            Spots.spicchio.Direct.y = 1
            RegisterSpot(Spots, Oggetto)
        End If
    End Sub
    Sub DisGener(ByRef posspa As Posizione, ByRef Rett1 As RoutBase1.clsRectang, ByRef Gener As Single, ByRef dy As Single, ByRef Rext As Single, ByRef Alfa As Single, ByRef Thick As Single)
        Dim DirR As New RoutBase1.clsVec2
        Dim Rext1 As Single
        If Rext > 0 Then Rext1 = Rext - Thick Else Rext1 = Rext
        TrasfRett(Rett1, 1, Gener / 2 + dy, Rext1)
        RotRett(Rett1, dy, Rext - System.Math.Sign(Rext) * Thick / 2, -Alfa)
        If IUNL >= 2 Then
            TrasfRett(Rett1, 1, (posspa.Origine.X), (posspa.Origine.y))
            DirR.X = posspa.CosDiritta.X : DirR.y = posspa.CosDiritta.y
            RotRett(Rett1, (posspa.Origine.X), (posspa.Origine.y), GlobalRoutines.arco(DirR.X, DirR.y))
        End If
        '    TrasfRett Rett1, Scalb!, offx!, offy!
        If IUNL <> 4 Then
            RettGraf(Rett1, IUNL - 1)
            '      IF R > 0 THEN
            '         Funzioni.DisRut.tratto Rett1.Corners(1).X, Rett1.Corners(1).Y, Rett1.Corners(4).X, Rett1.Corners(4).Y, .1, 0
            '      endif
            '      IF R1 > 0 THEN
            '          Funzioni.DisRut.tratto Rett1.Corners(2).X, Rett1.Corners(2).Y, Rett1.Corners(3).X, Rett1.Corners(3).Y, .1, 0
            '      endif
        End If
    End Sub
    Sub SpotCil(ByRef Oggetto As Membratura, ByRef Verso As Single, ByRef Diametro As Single, ByRef Spessore As Single, ByRef Lunghezza As Single)
        Dim Rett1 As New RoutBase1.clsRectang
        Dim DirR As New RoutBase1.clsVec2
        Dim Spots As New spot
        Dim posspa As Posizione
        posspa = Oggetto.GenMem.SwappedPos
        DirR.X = posspa.CosDiritta.X : DirR.y = posspa.CosDiritta.y
2202:   MakeCorners(Rett1, CSng(Diametro + 2 * Spessore), Lunghezza)
        TrasfRett(Rett1, 1.0!, Lunghezza / 2, -(Diametro + 2 * Spessore) / 2)
        TrasfRett(Rett1, 1.0!, (posspa.Origine.X), (posspa.Origine.y))
        RotRett(Rett1, (posspa.Origine.X), (posspa.Origine.y), GlobalRoutines.arco(DirR.X, DirR.y))
        '      TrasfRett Rett1, Scalb!, offx!, offy!
        Spots = New spot
        Spots.Tipo = 1
        Spots.Quota = Verso
        Spots.Quadro.TopLeft.X = GlobalRoutines.Minimo(Rett1.Corners(1).X, Rett1.Corners(2).X, Rett1.Corners(3).X, Rett1.Corners(4).X)
        Spots.Quadro.TopLeft.y = GlobalRoutines.Minimo(Rett1.Corners(1).y, Rett1.Corners(2).y, Rett1.Corners(3).y, Rett1.Corners(4).y)
        Spots.Quadro.Botrigt.X = GlobalRoutines.Massimo(Rett1.Corners(1).X, Rett1.Corners(2).X, Rett1.Corners(3).X, Rett1.Corners(4).X)
        Spots.Quadro.Botrigt.y = GlobalRoutines.Massimo(Rett1.Corners(1).y, Rett1.Corners(2).y, Rett1.Corners(3).y, Rett1.Corners(4).y)
        RegisterSpot(Spots, Oggetto)
    End Sub
    Sub RastrCil(ByRef posspa As Posizione, ByRef j As Short, ByRef js As Short, ByRef ax As Single, ByRef Lungh As Short, ByRef t As Single, ByRef d As Single, ByRef Diam As Single, ByRef Hnear As Short, ByRef Hfar As Short, ByRef Tnear As Single, ByRef Tfar As Single)
        Dim PuntiS As New RoutBase1.clsPunti
        Dim PuntiD As New RoutBase1.clsPunti
        If j = 1 And js = 0 Then 'virola completa senza buchi
            If Hfar = 0 Then Tfar = t
            If Hnear = 0 Then Tnear = t
        ElseIf j = 1 Then  'virola a sinistra
            Hfar = 0 : Tfar = t
        ElseIf j = js Then  'virola a destra
            Hnear = 0 : Tnear = t
        Else 'impossibile
        End If
        PuntiS.Inizia(8) : PuntiD.Inizia(8)
        PuntiS.Punti0(7).X = 0 : PuntiS.Punti0(7).y = 0
        PuntiS.Punti0(0).X = ax : PuntiS.Punti0(0).y = Diam / 2 * System.Math.Sign(d)
        PuntiS.Punti0(1).X = ax : PuntiS.Punti0(1).y = (Diam / 2 + Tnear) * System.Math.Sign(d)
        PuntiS.Punti0(2).X = ax + Hnear : PuntiS.Punti0(2).y = (Diam / 2 + t) * System.Math.Sign(d)
        PuntiS.Punti0(3).X = ax + Lungh - Hfar : PuntiS.Punti0(3).y = PuntiS.Punti0(2).y
        PuntiS.Punti0(4).X = ax + Lungh : PuntiS.Punti0(4).y = (Diam / 2 + Tfar) * System.Math.Sign(d)
        PuntiS.Punti0(5).X = ax + Lungh : PuntiS.Punti0(5).y = PuntiS.Punti0(0).y
        PuntiS.Punti0(6).X = PuntiS.Punti0(0).X : PuntiS.Punti0(6).y = PuntiS.Punti0(0).y
        Call TrasfGen(posspa, PuntiS, PuntiD, 7, 6, False)
        PuntiS.SpezzGraf(0, 6, Funzioni.DisRut)
    End Sub
    Sub SemiCil(ByRef posspa As Posizione, ByRef js As Short, ByRef quos() As Single, ByRef db() As Single, _
                ByRef t As Single, ByRef d As Single, ByRef Diam As Single, ByRef Rett As RoutBase1.clsRectang, _
                ByRef Hnear As Short, ByRef Hfar As Short, ByRef Tnear As Single, ByRef Tfar As Single)
        Dim j As Short
        Dim ax, Lungh As Single
        For j = 1 To js + 1
            ax = quos(j - 1) + db(j - 1) / 2
            Lungh = quos(j) - db(j) / 2 - ax
            '    IF j = js + 1 THEN lungh = lungh '- DELTAX1
            MakeCorners(Rett, t, CSng(Lungh))
            If (j > 1 Or Hnear = 0) And (j < js + 1 Or Hfar = 0) Then
                Call DisGener(posspa, Rett, (Lungh), ax, d, 0, (t))
            Else
                Call RastrCil(posspa, j, js, ax, (Lungh), t, d, Diam, Hnear, Hfar, Tnear, Tfar)
            End If
        Next
    End Sub
    Sub DisCil(ByRef Mode As Short, ByRef Oggetto As Cilindro)
        'Mode 1 non cerca buchi e interni
        Try
            posspa = Oggetto.GenMem.SwappedPos
            If AddMembrat = 1 Then
                Tnear = Oggetto.Tnear
                Tfar = Oggetto.Tfar
                Hnear = Oggetto.Hnear
                Hfar = Oggetto.Hfar
            End If
            LC1 = Oggetto.Lunghezza : LC2 = Oggetto.Lunghezza
            If Oggetto.TipoMat = 1 Then Oggetto.SpessRive = 0
            Dloc = Oggetto.Diametro
            If AddMembrat = 1 Then
                T2loc = Oggetto.SpessRive
            ElseIf AddMembrat = 2 Then
                T2loc = Oggetto.SpessRive
                Dloc = Oggetto.Diametro - 2 * Oggetto.SpessBase
            ElseIf AddMembrat = 8 Then
                T2loc = 0
            End If
            If Oggetto.Lunghezza * Oggetto.Diametro = 0 Then
                Exit Sub
            End If
            If Mode = 1 And IUNL = 0 Then Exit Sub
            DirR.X = posspa.CosDiritta.X : DirR.y = posspa.CosDiritta.y
            If IUNL = 0 Then
                xSmin = -Oggetto.Lunghezza / 5 : ySmin = 1.2 * (-(Dloc + Oggetto.SpessBase * 2) / 2) : xSmax = 1.2 * Oggetto.Lunghezza : ySmax = -ySmin
                If Not Funzioni.DisRut.Scala(xSmin, xSmax, ySmin, ySmax) Then Exit Sub
            End If
            Direzione.X = 0 : Direzione.y = 0 : Direzione.Z = 1
            prod = posspa.CosDiritta.ProdScalar(Direzione)
            Verso = posspa.Origine.Z
            If Mode = 1 Then
                If System.Math.Abs(prod) < TOLER Then SezLunCil(Oggetto) Else Exit Sub
            Else
                If System.Math.Abs(prod) > TOLER Then
                    SezRettCil(Oggetto)
                    Exit Sub
                End If
                If Oggetto.GenMem.Tipo < 0 Then ChkBocch(Oggetto)
                ChkOpening(Oggetto)
                If iswBocch Then
                    DirR.X = posspa.CosDiritta.X : DirR.y = posspa.CosDiritta.y
                    If Oggetto.SpostLat = 0 Then
                        If iswRanda And Verso < Dloc / 2 Then
                            LC1 = Oggetto.Lunghezza + Oggetto.HRANZA
                            DeltaX1 = Oggetto.HRANZA
                        Else
                            DeltaX1 = 0
                        End If
                        DeltaX2 = DeltaX1 : LC2 = LC1
                        Alfa2 = 0
                        Alfa = 0
                        Prod2 = 1
                    Else
                        If Oggetto.Randa > 0 Then
                            With Ogg5.GenMem.SwappedPos
                                Prod2 = -(posspa.Origine.X - .Origine.X) * posspa.CosDiritta.y + (posspa.Origine.y - .Origine.y) * posspa.CosDiritta.X
                            End With
                            Prod2 = System.Math.Sign(Prod2)
                            Oggetto.SpostLat = System.Math.Abs(Oggetto.SpostLat) * Prod2
1621:                       Alfa1 = GlobalRoutines.asin((Oggetto.SpostLat + Prod2 * Dloc / 2) / Oggetto.Randa)
                            Alfa2 = GlobalRoutines.asin(Oggetto.SpostLat / Oggetto.Randa)
                            Alfa3 = GlobalRoutines.asin((Oggetto.SpostLat - Prod2 * Dloc / 2) / Oggetto.Randa)
                            If Not iswRanda And Verso < Dloc / 2 Then
                                Oggetto.HRANZA = Oggetto.Randa * (System.Math.Cos(Alfa2) - System.Math.Cos(Alfa1))
                                LC1 = Oggetto.Lunghezza - Oggetto.HRANZA : LC2 = LC1
                                DeltaX1 = Oggetto.HRANZA
                                DeltaX2 = Oggetto.HRANZA
                            ElseIf iswRanda Then
                                DeltaX1 = Oggetto.Randa * (System.Math.Cos(Alfa2) - System.Math.Cos(Alfa1))
                                DeltaX2 = Oggetto.Randa * (System.Math.Cos(Alfa2) - System.Math.Cos(Alfa3))
                                LC1 = Oggetto.Lunghezza + DeltaX1
                                LC2 = Oggetto.Lunghezza + DeltaX2
                            End If
                            Alfa = System.Math.Abs(Alfa1 - Alfa3) : If Alfa > PI Then Alfa = 2 * PI - Alfa
                            If Prod2 < 0 Then GlobalRoutines.SWAP(LC1, LC2) : GlobalRoutines.SWAP(DeltaX1, DeltaX2)
                        End If
                    End If
                Else
                    DeltaX1 = 0 : DeltaX2 = 0
                End If
                SezLunCil(Oggetto)
            End If
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Private Sub SezRettCil(ByRef Oggetto As Membratura)
162:    z1 = posspa.Origine.Z
261:    z2 = posspa.Origine.Z + Oggetto.Lunghezza * posspa.CosDiritta.Z
        Verso = posspa.Origine.Z
        If z1 < 0 And z2 < 0 Then
            Exit Sub
        Else
            x = posspa.Origine.X ' * Scalb!
            y = posspa.Origine.y ' * Scalb!
1631:       Ri = Dloc / 2 '* Scalb!
            Re = (Dloc / 2 + Oggetto.SpessBase) ' * Scalb!
            If IUNL = 4 Then
                SpotCil1()
                Exit Sub
            End If
            If z1 > 0 And z2 > 0 Then
                Call Infilata(Oggetto, Verso, InMezzo)
                If InMezzo > 1 Then Exit Sub
                If InMezzo = 1 Then Call Funzioni.DisRut.ctrait(3, 0.1) Else Call Funzioni.DisRut.ctrait(0, 0.1)
            Else
                Call Funzioni.DisRut.ctrait(0, 0.1)
            End If
            Call Funzioni.DisRut.refabs()
            If Oggetto.SpessBase > 0 Then Call Funzioni.DisRut.cerc(x, y, Ri)
            Call Funzioni.DisRut.cerc(x, y, Re)
            Call Funzioni.DisRut.ctrait(0, 0.1)
            Call Funzioni.DisRut.refabs()
        End If
    End Sub
    Private Sub SezLunCil(ByRef Oggetto As Cilindro)
        If Verso < -Dloc / 2 Then Exit Sub
        If IUNL = 4 Then
            Call SpotCil(Oggetto, Verso, Oggetto.Diametro, Oggetto.SpessBase, Oggetto.Lunghezza) : Exit Sub
        End If
        If Verso > Dloc / 2 Then 'cilindro in vista
            Call Infilata(Oggetto, Verso, InMezzo)
            If InMezzo > 1 Then Exit Sub
            '   If inMezzo = 1 Then Call Funzioni.DisRut.ctrait(3, 0.1) Else Call Funzioni.DisRut.ctrait(0, 0.1)
            x = posspa.Origine.X '* Scalb!
            y = posspa.Origine.y '* Scalb!
            If IUNL < 4 Then DisQuadr(Oggetto)
        Else
            Call LeggiBuchi(Oggetto, jsopra, quosopra, DBucosopra, jsotto, quosotto, DBucosotto, (LC1), (LC2))
            If Rovescia Then
                posspa.Origine.X = posspa.Origine.X + Oggetto.Lunghezza * DirR.X
                posspa.Origine.y = posspa.Origine.y + Oggetto.Lunghezza * DirR.y
                posspa.CosDiritta.X = -posspa.CosDiritta.X
                posspa.CosDiritta.y = -posspa.CosDiritta.y
            End If
            DisCil1(Oggetto)
            If IUNL = 0 Then
                Funzioni.DisRut.tratto(Rett1.Corners(4).X, Rett1.Corners(4).y, Rett2.Corners(1).X, Rett2.Corners(1).y, 0.1, 0)
                Funzioni.DisRut.tratto(Rett1.Corners(3).X, Rett1.Corners(3).y, Rett2.Corners(2).X, Rett2.Corners(2).y, 0.1, 0)
                ' Call Axes(Rett1, Rett2)
            Else
                R1 = posspa.Origine.ProdScalar((posspa.CosDiritta))
                If Mode = 0 Then
                    Call CercaInt(Oggetto, R1, Dint1, Dloc)
                    Direzione.X = posspa.Origine.X + Oggetto.Lunghezza * posspa.CosDiritta.X
                    Direzione.y = posspa.Origine.y + Oggetto.Lunghezza * posspa.CosDiritta.y
                    Direzione.Z = posspa.Origine.Z + Oggetto.Lunghezza * posspa.CosDiritta.Z
                    R2 = Direzione.ProdScalar((posspa.CosDiritta))
                    Call CercaInt(Oggetto, R2, Dint2, Dloc)
                Else
                    Dint1 = 0 : Dint2 = 0
                End If
                PuntiS = New RoutBase1.clsPunti
                PuntiD = New RoutBase1.clsPunti
                PuntiS.Inizia(6) : PuntiD.Inizia(6)
                PuntiS.Punti0(0).X = 0 : PuntiS.Punti0(0).y = Dloc / 2 'segmenti finali
                PuntiS.Punti0(1).X = 0 : PuntiS.Punti0(1).y = Dint1 / 2 '-
                PuntiS.Punti0(2).X = LC1 : PuntiS.Punti0(2).y = Dloc / 2 '-
                PuntiS.Punti0(3).X = LC1 : PuntiS.Punti0(3).y = Dint2 / 2 '-
                PuntiS.Punti0(6).X = 0 : PuntiS.Punti0(6).y = 0 '-
                PuntiS.Punti0(5).X = 0 : PuntiS.Punti0(5).y = -Oggetto.SpostLat
                PuntiS.Punti0(4).X = Oggetto.Lunghezza + Oggetto.Randa
                PuntiS.Punti0(4).y = 0 'centro dell'arco
                If Oggetto.SpostLat <> 0 Then
                    Direzione.X = 0 : Direzione.y = 0 : Direzione.Z = 1
                    PuntiS.Punti0(4).y = -Oggetto.SpostLat
                    PuntiS.Punti0(4).X = Oggetto.Lunghezza + Oggetto.Randa * System.Math.Cos(Alfa2)
                    '              FOR i = 0 TO 6: PuntiS.Punti0(i).Y = Prod2! * PuntiS.Punti0(i).Y: NEXT
                End If
                Call TrasfGen(posspa, PuntiS, PuntiD, 6, 5, True)
                PuntiS.SpezzGraf(0, 1, Funzioni.DisRut) : PuntiD.SpezzGraf(0, 1, Funzioni.DisRut)
                If iswBocch And iswRanda And Oggetto.HRANZA > 0 Then
                    If Alfa = 0 Then Alfa = 2 * System.Math.Atan(Dloc / 2 / (Oggetto.Randa - Oggetto.HRANZA))
                    racc = Oggetto.Randa
                    Direz.X = -System.Math.Cos(Alfa2) : Direz.y = System.Math.Sin(Alfa2) ' * SGN(Prod2!)
                    If IUNL >= 2 Then GlobalRoutines.ComposDir(Direz, DirR)
                    'croce del    Funzioni.DisRut.tratto P0(4).X - 10, P0(4).Y, P0(4).X + 10, P0(4).Y, .1, 0
                    'centro       Funzioni.DisRut.tratto P0(4).X, P0(4).Y - 10, P0(4).X, P0(4).Y + 10, .1, 0
                    ArcoGraf(PuntiS.Punti0(4), racc, Direz, Alfa, IUNL - 1)
                Else
                    PuntiS.SpezzGraf(2, 3, Funzioni.DisRut) : PuntiD.SpezzGraf(2, 3, Funzioni.DisRut) '-
                End If
            End If
            If T2loc > 0 Then
                Oggetto.SpessBase = T2loc : Dloc = Dloc - 2 * Oggetto.SpessBase
                DisCil1(Oggetto)
            End If
        End If
    End Sub
    Private Sub DisCil1(ByVal Oggetto As Membratura)
        If Oggetto.SpessBase = 0 Then
            Call SemiCil(posspa, 0, quosopra, DBucosopra, Dloc, Dloc / 2, 0, Rett1, 0, 0, 0, 0)
        Else
            '  -----sopra--------------
            prod = Dloc / 2 + Oggetto.SpessBase
            If Rovescia Then
                prod = -prod
                For i = 1 To jsopra
                    quosopra(i) = Oggetto.Lunghezza - quosopra(i)
                Next
                For i = 1 To jsotto
                    quosotto(i) = Oggetto.Lunghezza - quosotto(i)
                Next
            End If
            Call SemiCil(posspa, jsopra, quosopra, DBucosopra, (Oggetto.SpessBase), prod, Dloc, Rett1, (Hnear), (Hfar), Tnear, Tfar)
            '  -----sotto--------------
            Call SemiCil(posspa, jsotto, quosotto, DBucosotto, (Oggetto.SpessBase), -prod, Dloc, Rett2, (Hnear), (Hfar), Tnear, Tfar)
        End If
    End Sub
    Private Sub ChkBocch(ByRef Oggetto As Cilindro)
        iswBocch = False
        Dim Ogg4 As Membratura = Oggetto.GenMem.posizione.SuChi
        If Ogg4 Is Nothing Then Exit Sub
        If Ogg4.GenMem.Tipo <> 10 Then Exit Sub
        SwapCoordN(Ogg4.GenMem)
        iswBocch = True
        Prod1 = Ogg4.GenMem.SwappedPos.CosTraversa.ProdScalar(Direzione)
        If System.Math.Abs(Prod1) > 0.5 Then iswRanda = True Else iswRanda = False 'visibilit… randa
        Dim Bocch As clsBocch = CType(Ogg4, clsBocch)
        Oggetto.Randa = Bocch.Randa
        Oggetto.SpostLat = Bocch.SpostLat
        If Bocch.DiamRinf = 0 Then Bocch.DiamRinf = Oggetto.Diametro
        If Oggetto.Randa > 0 Then Oggetto.HRANZA = Oggetto.Randa - System.Math.Sqrt(Oggetto.Randa * Oggetto.Randa - (Bocch.DiamRinf / 2) ^ 2)
        Ogg5 = Ogg4.GenMem.posizione.SuChi
        If Ogg5 Is Nothing Then Exit Sub
        SwapCoordN(Ogg5.GenMem)
    End Sub
    Private Sub ChkOpening(ByRef Oggetto As Cilindro)
        iswBocch = False
        If Not RandaPossibile(Oggetto) Then Exit Sub
        iswBocch = True
        Prod1 = posspa.CosTraversa.ProdScalar(Direzione)
        If System.Math.Abs(Prod1) > 0.5 Then iswRanda = True Else iswRanda = False 'visibilit… randa
        If Oggetto.Randa > 0 Then Oggetto.HRANZA = Oggetto.Randa - System.Math.Sqrt( _
                       Oggetto.Randa * Oggetto.Randa - ((Oggetto.Diametro + 2 * Oggetto.Spessore) / 2) ^ 2)
        Ogg5 = Oggetto.GenMem.posizione.SuChi
        If Ogg5 Is Nothing Then Exit Sub
        SwapCoordN(Ogg5.GenMem)
        Rovescia = True
    End Sub
    Private Sub SpotCil1()
        Spots = New spot
2402:   Spots.Tipo = 2
        Spots.Quota = (z1 + z2) / 2
        Spots.spicchio.Origin.X = 0 ' offx! + x!
        Spots.spicchio.Origin.y = 0 ' offy! + y!
        Spots.spicchio.RG = Dloc / 2 + Oggetto.SpessBase
        If Oggetto.SpessBase = 0 Then
            Spots.spicchio.RP = 0
        Else
            Spots.spicchio.RP = Ri
        End If
        Spots.spicchio.Alfa = 2 * PI
        Spots.spicchio.Direct.X = 0
        Spots.spicchio.Direct.y = 1
        RegisterSpot(Spots, Oggetto)
    End Sub
    Private Sub DisQuadr(ByVal Oggetto As Cilindro)
        DScal = (Dloc + 2 * Oggetto.SpessBase) '* Scalb!
        LScal = LC1 'Oggetto.Lunghezza '* Scalb!
        Dim Centr As Single = LC1 + Oggetto.Randa - Oggetto.HRANZA
        Call Funzioni.DisRut.refabs()
        DirR.X = posspa.CosDiritta.X
        DirR.y = posspa.CosDiritta.y
        Alfaa = GlobalRoutines.arco((DirR.X), (DirR.y)) * 180 / PI
        '--------------------
        If Rovescia Then
            x = x + Oggetto.Lunghezza * DirR.X
            y = y + Oggetto.Lunghezza * DirR.y
            Alfaa = Alfaa + 180
        End If
        If Alfaa > 360 Then Alfaa = Alfaa - 360
        '---------------------
        Call Funzioni.DisRut.refere(x, y, Alfaa)
        Call Funzioni.DisRut.segm(0.0!, 0.0!, 0.0!, DScal / 2)
        Call Funzioni.DisRut.segm(0.0!, DScal / 2, LScal, DScal / 2)
        If iswBocch And iswRanda And Oggetto.Randa > 0 Then
            If Alfa = 0 Then Alfa = 2 * System.Math.Atan(Dloc / 2 / (Oggetto.Randa - Oggetto.HRANZA))
            Call Funzioni.DisRut.arc(Centr, (Oggetto.SpostLat), LScal, DScal / 2, Alfa * 180 / PI)
        Else
            Call Funzioni.DisRut.segm(LScal, DScal / 2, LScal, -DScal / 2)
        End If
        Call Funzioni.DisRut.segm(LScal, -DScal / 2, 0.0!, -DScal / 2)
        Call Funzioni.DisRut.segm(0.0!, -DScal / 2, 0.0!, 0.0!)
        Call Funzioni.DisRut.refabs()
        Call Funzioni.DisRut.ctrait(0, 0.1)
    End Sub
    Sub AzzeraSpot(ByRef Appar As clsApparecchio)
        Dim i, j As Short
        For i = 0 To Appar.Elementi.Count - 1
            Appar.Elementi(i).GenMem.Segnalini.RemoveAll()
        Next
    End Sub
    Sub RegisterSpot(ByRef Spots As spot, ByRef Obj As Membratura)
        If Spots Is Nothing Then Exit Sub
        If Spots.Tipo = 0 Then Exit Sub
        Spots.indice = Obj
        Spots.Sezione = LungPip
        Obj.GenMem.Segnalini.Add(Spots)
    End Sub
    Sub ArcoGraf(ByRef Centro As RoutBase1.clsVec2, ByRef Raggio As Single, ByRef Direz As RoutBase1.clsVec2, ByRef Alfa As Single, ByRef m As Single)
        Dim Alfa1, ang, Alfa2 As Single
        If Raggio <= 0 Then Exit Sub
        ang = GlobalRoutines.arco((Direz.X), (Direz.y))
        If IUNL = 3 Then ang = -ang
        Alfa1 = -ang - Alfa / 2
        Alfa2 = -ang + Alfa / 2
        'If (Alfa1 < 0) Then Alfa1 = Alfa1 + 2 * Pi
        'If (Alfa1 < 0) Then Alfa1 = Alfa1 + 2 * Pi
        'If (Alfa2 < 0) Then Alfa2 = Alfa2 + 2 * Pi
        'If (Alfa2 < 0) Then Alfa2 = Alfa2 + 2 * Pi
        'If (Alfa1 > 2 * Pi) Then Alfa1 = Alfa1 - 2 * Pi
        'If (Alfa1 > 2 * Pi) Then Alfa1 = Alfa1 - 2 * Pi
        'If (Alfa2 > 2 * Pi) Then Alfa2 = Alfa2 - 2 * Pi
        'If (Alfa2 > 2 * Pi) Then Alfa2 = Alfa2 - 2 * Pi
        If m <= 1 Or m = 4 Then
            Funzioni.DisRut.Cerchio((Centro.X), (Centro.y), Raggio, 2 * PI - Alfa2, 2 * PI - Alfa1, 0.0#)
        ElseIf m = 2 Then
            Funzioni.DisRut.Cerchio((Centro.X), (Centro.y), Raggio, Alfa1, Alfa2, 0.1)
        End If
    End Sub
    Sub TrasfGen(ByRef posspa As Posizione, ByRef PuntiS As RoutBase1.clsPunti, ByRef PuntiD As RoutBase1.clsPunti, ByVal nzero As Short, ByVal nmax As Short, ByRef Duplica As Boolean)
        Dim DirR As New RoutBase1.clsVec2
        Dim i As Short
        Dim Destra As Boolean
        If Duplica Then
            PuntiD = New RoutBase1.clsPunti
            PuntiD.Inizia(Math.Max(nmax, nzero))
            For i = 0 To Math.Max(nmax, nzero)
                PuntiD.Punti.Item(i).TextData.X = PuntiS.Punti.Item(i).TextData.X
                PuntiD.Punti.Item(i).TextData.y = -PuntiS.Punti.Item(i).TextData.y
            Next
        End If
        For i = 0 To nmax
            If IUNL >= 2 And i <> nzero Then
                DirR.X = posspa.CosDiritta.X
                DirR.y = posspa.CosDiritta.y
                TraslRot(PuntiS.Punti.Item(i).TextData, PuntiS.Punti.Item(nzero).TextData, DirR)
                Destra = Not PuntiD Is Nothing
                If Destra Then Destra = PuntiD.Punti.Count > 0
                If Duplica Or Destra Then TraslRot(PuntiD.Punti.Item(i).TextData, PuntiS.Punti.Item(nzero).TextData, DirR)
                PuntiS.Punti.Item(i).TextData.X = PuntiS.Punti.Item(i).TextData.X + posspa.Origine.X
                PuntiS.Punti.Item(i).TextData.y = PuntiS.Punti.Item(i).TextData.y + posspa.Origine.y
                If Duplica Or Destra Then
                    PuntiD.Punti.Item(i).TextData.X = PuntiD.Punti.Item(i).TextData.X + posspa.Origine.X
                    PuntiD.Punti.Item(i).TextData.y = PuntiD.Punti.Item(i).TextData.y + posspa.Origine.y
                End If
            End If
        Next
    End Sub 'h
    Function Sovrap(ByRef Spots As spot, ByRef indice As Membratura, ByRef iDentrotutti As Short) As Boolean
        Dim Sovr, Sovr1 As Short
        Dim Spot0 As spot
        Dim i As Short
        Try
            Sovrap = False
            Dim gMem As clsGenMem = indice.GenMem
            For i = 1 To gMem.Segnalini.Count
                If gMem.Segnalini(i - 1).Sezione = LungPip Then
                    Spot0 = gMem.Segnalini(i - 1)
                    Sovr = Guarda(Spots, Spot0, iDentrotutti)
                    Sovr1 = Sovr1 Or Sovr
                End If
            Next
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
        Sovrap = Sovr1
    End Function
    Function Guarda(ByRef Spots As spot, ByRef Spot0 As spot, ByRef iDentrotutti As Short) As Boolean
        If System.Math.Abs(Spots.Tipo) = 2 And System.Math.Abs(Spot0.Tipo) = 1 Then
            iSwap = True
            Spot2 = Spots : Spot1 = Spot0
            'in 1 c'Š quello pi— lontano
        Else
            iSwap = False
            Spot1 = Spots : Spot2 = Spot0
            'in 1 c'Š quello pi— vicino
        End If
        Select Case System.Math.Abs(Spot1.Tipo) + System.Math.Abs(Spot2.Tipo)
            Case 2
2100:           iDentro = False
                Esamina()
                If Not iDentro Then
                    SwapBuff()
                    Esamina()
                    iDentrotutti = False
                End If
                If Not iDentro Then
                    Croce()
                    iDentrotutti = False
                End If
                Guarda = iDentro
            Case 3 '1 Funzioni.DisRut.quadrato 2 spicchio
                FaiRett()
                iDentro = False : iFuori = False
                For j = 1 To 4
                    jcaso(j) = PunSpicchio(Rett.Corners(j), Spot2.spicchio)
                    If jcaso(j) = 2 Then
                        iDentro = True
                        If Not iFuori Then iFuori = False
                    Else
                        iFuori = True
                    End If
                Next
                For j = 1 To 4
                    For k = 1 To 4
                        If j <> k Then
                            If jcaso(j) = 1 And jcaso(k) = 3 Then iDentro = True : GoTo Esci
                        End If
                    Next k
                Next j
Esci:           If Not iSwap Then
                    iDentrotutti = Not iFuori And iDentro
                    Guarda = iDentro
                    Exit Function
                End If
                iFuori = False
                ang = GlobalRoutines.arco((Spot2.spicchio.Direct.X), (Spot2.spicchio.Direct.y))
                For i = 0 To 2
                    Punto.X = Spot2.spicchio.Origin.X + Spot2.spicchio.RP * System.Math.Cos(ang + (i - 1) * Spot2.spicchio.Alfa / 2)
                    Punto.y = Spot2.spicchio.Origin.y + Spot2.spicchio.RP * System.Math.Sin(ang + (i - 1) * Spot2.spicchio.Alfa / 2)
                    If (Punto.X - Spot1.Quadro.TopLeft.X) * (Punto.X - Spot1.Quadro.TopLeft.y) < 0 And (Punto.y - Spot1.Quadro.TopLeft.y) * (Punto.y - Spot1.Quadro.TopLeft.y) < 0 Then
                        iDentro = True
                        If Not iFuori Then iFuori = False
                    Else
                        iFuori = True
                    End If
                Next
                Guarda = iDentro
                If iSwap Then iDentrotutti = (Not iFuori) And iDentro Else iDentrotutti = False
            Case 4
                iDentro = False
                EsaminSp()
                If Not iDentro Then
                    SwapBuff()
                    EsaminSp()
                    iDentrotutti = False
                End If
                Guarda = iDentro
        End Select
    End Function
    Private Sub Esamina()
        FaiRett()
        iFuori = False
2160:   For i = 1 To 4
            PuntoVec = Rett.Corners(i)
2162:       a1 = (PuntoVec.X - Spot2.Quadro.TopLeft.X) * (PuntoVec.X - Spot2.Quadro.Botrigt.X)
2164:       a2 = (PuntoVec.y - Spot2.Quadro.TopLeft.y) * (PuntoVec.y - Spot2.Quadro.Botrigt.y)
            If a1 < 0 And a2 < 0 Then
                iDentro = True
                If Not iFuori Then iFuori = False
            Else
                iFuori = True
            End If
2168:   Next
        iDentrotutti = Not iFuori
    End Sub
    Private Sub EsaminSp()
        iFuori = False
        If System.Math.Abs(Spot2.spicchio.Alfa - 2 * PI) < TOLER And System.Math.Abs(Spot1.spicchio.Alfa - 2 * PI) < TOLER Then
            dist = System.Math.Sqrt((Spot1.spicchio.Origin.X - Spot2.spicchio.Origin.X) ^ 2 + (Spot1.spicchio.Origin.y - Spot2.spicchio.Origin.y) ^ 2)
            If dist > Spot1.spicchio.RG + Spot2.spicchio.RG Then
                iDentro = False
                iDentrotutti = False
            Else
                iDentro = Spot1.spicchio.RP > Spot2.spicchio.RG Or Spot1.spicchio.RG < Spot2.spicchio.RP
                If Not iDentro Then
                    iDentrotutti = False
                Else
                    iDentrotutti = Not ((Spot1.spicchio.RG - Spot2.spicchio.RG) * (Spot1.spicchio.RP - Spot2.spicchio.RG) < 0 Or (Spot1.spicchio.RG - Spot2.spicchio.RP) * (Spot1.spicchio.RP - Spot2.spicchio.RP) < 0)
                End If
            End If
        Else
2180:       ang = GlobalRoutines.arco((Spot1.spicchio.Direct.X), (Spot1.spicchio.Direct.y))
            For j = 1 To 2
                If j = 1 Then Raggio = Spot1.spicchio.RP Else Raggio = Spot1.spicchio.RG
                For i = 0 To 4
2182:               PuntoVec.X = Spot1.spicchio.Origin.X + Raggio * System.Math.Cos(ang + (i - 1) * Spot2.spicchio.Alfa / 4)
                    PuntoVec.y = Spot1.spicchio.Origin.y + Raggio * System.Math.Sin(ang + (i - 1) * Spot2.spicchio.Alfa / 4)
                    iPs = PunSpicchio(PuntoVec, (Spot2.spicchio))
2184:               If iPs = 2 Then
                        iDentro = True
                        If Not iFuori Then iFuori = False
                    Else
                        iFuori = True
                    End If
                Next
            Next j
2186:       iDentrotutti = Not iFuori
        End If
    End Sub
    Private Sub Croce()
        a1 = (Spot1.Quadro.TopLeft.X - Spot2.Quadro.TopLeft.X) * (Spot1.Quadro.Botrigt.X - Spot2.Quadro.TopLeft.X)
        a2 = (Spot2.Quadro.TopLeft.y - Spot1.Quadro.TopLeft.y) * (Spot2.Quadro.Botrigt.y - Spot1.Quadro.TopLeft.y)
        iDentro = (a1 < 0 And a2 < 0)
    End Sub
    Private Sub FaiRett()
        Rett = New clsRectang
        Rett.Corners(1).X = Spot1.Quadro.TopLeft.X
        Rett.Corners(1).y = Spot1.Quadro.TopLeft.y
2170:   Rett.Corners(2).X = Spot1.Quadro.Botrigt.X
        Rett.Corners(2).y = Spot1.Quadro.TopLeft.y
        Rett.Corners(3).X = Spot1.Quadro.Botrigt.X
        Rett.Corners(3).y = Spot1.Quadro.Botrigt.y
        Rett.Corners(4).X = Spot1.Quadro.TopLeft.X
        Rett.Corners(4).y = Spot1.Quadro.Botrigt.y
    End Sub
    Private Sub SwapBuff()
        Spot3 = Spot1
        Spot1 = Spot2
        Spot2 = Spot3
    End Sub
    Function PunSpicchio(ByVal Punto As RoutBase1.clsVec2, ByVal SP As Spicchio4) As Short
        Dim dy, dx, dist As Single
        Dim ang, ang1, dang As Single
        Dim Direz As New RoutBase1.clsVec2
        dx = Punto.X - SP.Origin.X
        dy = Punto.y - SP.Origin.y
        dist = System.Math.Sqrt(dx * dx + dy * dy)
        If dist < SP.RP - TOLER Then
            PunSpicchio = 1
        ElseIf dist < SP.RG + TOLER Then
            PunSpicchio = 2
        Else
            PunSpicchio = 3
        End If
        If dist < TOLER Then Exit Function
        If System.Math.Abs(2 * PI - SP.Alfa) < TOLER Then Exit Function
        ang = GlobalRoutines.arco(SP.Direct.X, SP.Direct.y)
        Direz.X = dx / dist
        Direz.y = dy / dist
        ang1 = GlobalRoutines.arco(Direz.X, Direz.y)
        dang = Math.Abs(ang - ang1)
        If dang > Math.PI Then dang -= 2 * Math.PI
        If dang > Math.PI Then dang -= 2 * Math.PI
        If Math.Abs(dang) > SP.Alfa / 2 Then Return PunSpicchio = 0
    End Function
    Sub Infilata(ByRef indice As Membratura, ByRef Verso As Single, ByRef InMezzo As Short)
        Dim i, j, iD As Short
        Dim iDisgiunti As Short
        Dim i1, iDentrotutti, j1 As Short
        Dim Spots As spot
        If Verso = 0 Or IUNL = 5 Then InMezzo = 0 : Exit Sub
        i = 1 : InMezzo = 0
        Dim n As OggList.NodeP = ApparProv.Elementi.nodeHead.Next
        While Not n Is Nothing
            For j = 0 To n.TextData.GenMem.Segnalini.Count - 1
                If Not indice Is n.TextData Then
                    Spots = n.TextData.GenMem.Segnalini(j)
                    If Spots.Sezione = LungPip And Spots.Quota >= 0 And Spots.Quota < Verso Then
                        If Sovrap(Spots, indice, iDentrotutti) Then
                            If Not iDentrotutti Then
                                InMezzo = InMezzo + 1
                                If InMezzo > UBound(IndInMezzo) Then ReDim Preserve IndInMezzo(2 * InMezzo)
                                IndInMezzo(InMezzo) = Spots
                            End If
                        End If
                    End If
                End If
            Next
            n = n.Next
        End While
        If InMezzo > 1 Then
            iDisgiunti = True
            For i = 1 To InMezzo - 1
                For j = i + 1 To InMezzo
                    If IndInMezzo(i).Quota < IndInMezzo(j).Quota Then
                        i1 = i : j1 = j
                    Else
                        i1 = j : j1 = i
                    End If
                    If Guarda(IndInMezzo(i1), IndInMezzo(j1), iD) Then iDisgiunti = False : Exit For
                Next j
                If Not iDisgiunti Then Exit For
            Next i
            If iDisgiunti Then InMezzo = 1
        End If
    End Sub 'e
    Sub DisSpezPia(ByRef TipoV As Short, ByRef DFor As Short, ByRef DTub As Single, ByRef Punti As RoutBase1.clsPunti, ByRef Npunti As Short)
        Select Case TipoV
            Case 1, 2
                Punti.SpezzGraf(0, 1, Funzioni.DisRut)
                Punti.SpezzGraf(2, 3, Funzioni.DisRut)
                Punti.SpezzGraf(4, 5, Funzioni.DisRut)
                Punti.SpezzGraf(6, 10, Funzioni.DisRut)
                Punti.SpezzGraf(11, 12, Funzioni.DisRut)
                Punti.SpezzGraf(13, 16, Funzioni.DisRut)
                Punti.SpezzGraf(17, 18, Funzioni.DisRut)
                Punti.SpezzGraf(19, 20, Funzioni.DisRut)
            Case 3, 7
                Punti.SpezzGraf(0, 1, Funzioni.DisRut)
                Punti.SpezzGraf(2, 7, Funzioni.DisRut)
                Punti.SpezzGraf(8, 11, Funzioni.DisRut)
                Punti.SpezzGraf(12, 13, Funzioni.DisRut)
                Punti.SpezzGraf(14, 17, Funzioni.DisRut)
                Punti.SpezzGraf(18, 19, Funzioni.DisRut)
                Punti.SpezzGraf(20, 21, Funzioni.DisRut)
            Case 4
                Punti.SpezzGraf(0, 1, Funzioni.DisRut)
                Punti.SpezzGraf(2, 5, Funzioni.DisRut)
                Punti.SpezzGraf(6, 10, Funzioni.DisRut)
                Punti.SpezzGraf(11, 18, Funzioni.DisRut)
                Punti.SpezzGraf(19, 20, Funzioni.DisRut)
            Case 5
                Punti.SpezzGraf(0, 1, Funzioni.DisRut)
                Punti.SpezzGraf(2, 7, Funzioni.DisRut)
                Punti.SpezzGraf(8, 11, Funzioni.DisRut)
                Punti.SpezzGraf(12, 18, Funzioni.DisRut)
                Punti.SpezzGraf(19, 20, Funzioni.DisRut)
            Case 6
                Punti.SpezzGraf(0, 1, Funzioni.DisRut)
                Punti.SpezzGraf(2, 7, Funzioni.DisRut)
                Punti.SpezzGraf(8, 11, Funzioni.DisRut)
                Punti.SpezzGraf(12, 17, Funzioni.DisRut)
                Punti.SpezzGraf(18, 20, Funzioni.DisRut)
        End Select
        If DFor = 0 Then
            If TipoV = 3 Or TipoV = 7 Then
                Punti.SpezzGraf(7, 8, Funzioni.DisRut)
                Punti.SpezzGraf(11, 12, Funzioni.DisRut)
            ElseIf TipoV < 3 Then
                Punti.SpezzGraf(3, 4, Funzioni.DisRut)
                Punti.SpezzGraf(10, 11, Funzioni.DisRut)
            ElseIf TipoV = 4 Then
                Punti.SpezzGraf(5, 6, Funzioni.DisRut)
                Punti.SpezzGraf(10, 11, Funzioni.DisRut)
            Else
                Punti.SpezzGraf(7, 8, Funzioni.DisRut)
                Punti.SpezzGraf(11, 12, Funzioni.DisRut)
            End If
        Else
            If TipoV = 3 Or TipoV = 7 Then
                Funzioni.DisRut.tratto(Punti.Punti.Item(9).TextData.X, Punti.Punti.Item(9).TextData.y, Punti.Punti.Item(12).TextData.X, Punti.Punti.Item(12).TextData.y, 0.1, 0)
                Funzioni.DisRut.tratto(Punti.Punti.Item(8).TextData.X, Punti.Punti.Item(8).TextData.y, Punti.Punti.Item(13).TextData.X, Punti.Punti.Item(13).TextData.y, 0.1, 0)
            ElseIf TipoV < 3 Then
                Funzioni.DisRut.tratto(Punti.Punti.Item(5).TextData.X, Punti.Punti.Item(5).TextData.y, Punti.Punti.Item(11).TextData.X, Punti.Punti.Item(11).TextData.y, 0.1, 0)
                Funzioni.DisRut.tratto(Punti.Punti.Item(4).TextData.X, Punti.Punti.Item(4).TextData.y, Punti.Punti.Item(12).TextData.X, Punti.Punti.Item(12).TextData.y, 0.1, 0)
            ElseIf TipoV = 4 Then
                Funzioni.DisRut.tratto(Punti.Punti.Item(7).TextData.X, Punti.Punti.Item(7).TextData.y, Punti.Punti.Item(11).TextData.X, Punti.Punti.Item(11).TextData.y, 0.1, 0)
                Funzioni.DisRut.tratto(Punti.Punti.Item(6).TextData.X, Punti.Punti.Item(6).TextData.y, Punti.Punti.Item(12).TextData.X, Punti.Punti.Item(12).TextData.y, 0.1, 0)
            Else
                Funzioni.DisRut.tratto(Punti.Punti.Item(9).TextData.X, Punti.Punti.Item(9).TextData.y, Punti.Punti.Item(12).TextData.X, Punti.Punti.Item(12).TextData.y, 0.1, 0)
                Funzioni.DisRut.tratto(Punti.Punti.Item(8).TextData.X, Punti.Punti.Item(8).TextData.y, Punti.Punti.Item(13).TextData.X, Punti.Punti.Item(13).TextData.y, 0.1, 0)
            End If
            Funzioni.DisRut.tratto(Punti.Punti.Item(26).TextData.X, Punti.Punti.Item(26).TextData.y, Punti.Punti.Item(27).TextData.X, Punti.Punti.Item(27).TextData.y, 0.1, 3)
        End If
        If DTub = 0 Then
            If TipoV = 3 Or TipoV = 7 Then
                Punti.SpezzGraf(1, 2, Funzioni.DisRut)
                Punti.SpezzGraf(19, 20, Funzioni.DisRut)
            ElseIf TipoV = 6 Then
                Punti.SpezzGraf(1, 2, Funzioni.DisRut)
                Punti.SpezzGraf(17, 18, Funzioni.DisRut)
            Else
                Punti.SpezzGraf(1, 2, Funzioni.DisRut)
                Punti.SpezzGraf(18, 19, Funzioni.DisRut)
            End If
        Else
            If TipoV = 3 Or TipoV = 7 Then
                Funzioni.DisRut.tratto(Punti.Punti.Item(2).TextData.X, Punti.Punti.Item(2).TextData.y, Punti.Punti.Item(21).TextData.X, Punti.Punti.Item(21).TextData.y, 0.1, 0)
                Funzioni.DisRut.tratto(Punti.Punti.Item(3).TextData.X, Punti.Punti.Item(3).TextData.y, Punti.Punti.Item(20).TextData.X, Punti.Punti.Item(20).TextData.y, 0.1, 0)
            ElseIf TipoV = 6 Then
                Funzioni.DisRut.tratto(Punti.Punti.Item(2).TextData.X, Punti.Punti.Item(2).TextData.y, Punti.Punti.Item(19).TextData.X, Punti.Punti.Item(19).TextData.y, 0.1, 0)
                Funzioni.DisRut.tratto(Punti.Punti.Item(3).TextData.X, Punti.Punti.Item(3).TextData.y, Punti.Punti.Item(18).TextData.X, Punti.Punti.Item(18).TextData.y, 0.1, 0)
            Else
                Funzioni.DisRut.tratto(Punti.Punti.Item(2).TextData.X, Punti.Punti.Item(2).TextData.y, Punti.Punti.Item(20).TextData.X, Punti.Punti.Item(20).TextData.y, 0.1, 0)
                Funzioni.DisRut.tratto(Punti.Punti.Item(3).TextData.X, Punti.Punti.Item(3).TextData.y, Punti.Punti.Item(19).TextData.X, Punti.Punti.Item(19).TextData.y, 0.1, 0)
            End If
        End If
        If Npunti > 26 Then 'monoplaccato
            Funzioni.DisRut.tratto(Punti.Punti.Item(Npunti).TextData.X, Punti.Punti.Item(Npunti).TextData.y, Punti.Punti.Item(Npunti + 1).TextData.X, Punti.Punti.Item(Npunti + 1).TextData.y, 0.1, 0)
            '    Funzioni.DisRut.tratto P1(Npunti - 1).X, P1(Npunti - 1).Y, P1(Npunti).X, P1(Npunti).Y, 0.1, 0
        End If
    End Sub
    Sub CercaTubi(ByRef Oggetto As Membratura, ByRef OTL As Single, ByRef DTub As Single, ByRef yfmin As Single, ByRef yfmax As Single)
        Dim j, Tipo As Short
        Dim Log2, Log1, Log3 As Boolean
        Dim Ogg As Tubi
        OTL = 0 : DTub = 0
        If Oggetto Is Nothing Then Exit Sub
        Try
            For j = 1 To Apparecchio.Elementi.Count() - 1
                Dim lGenmem As clsGenMem = Apparecchio.Elementi(j).GenMem
                Tipo = System.Math.Abs(lGenmem.Tipo)
                If Tipo = 8 Or Tipo = 9 Or Tipo = 26 Then
                    If Tipo = 26 Then
                        Ogg = Apparecchio.Elementi(j).Tubi
                    Else
                        Ogg = Apparecchio.Elementi(j)
                    End If
                    Log1 = (lGenmem.posizione.SuChi Is Oggetto) Or (Oggetto.GenMem.posizione.SuChi Is Apparecchio.Elementi(j))
                    Log2 = (lGenmem.posizione.ForoSecondario Is Oggetto) Or (Oggetto.GenMem.posizione.ForoSecondario Is Apparecchio.Elementi(j))
                    Log3 = (lGenmem.posizione.ForoTerziario Is Oggetto) Or (Oggetto.GenMem.posizione.ForoTerziario Is Apparecchio.Elementi(j))
                    If Log1 Or Log2 Or Log3 Then
                        DTub = Ogg.DiamExt
                        OTL = Ogg.OTL - DTub
                        yfmin = Ogg.yPrimaFila
                        yfmax = Ogg.yUltimFila
                        Exit For
                    End If
                End If
            Next
        Catch e As Exception
            MessageBox.Show(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub 'c
    Sub CercaInt(ByRef Elem1 As Membratura, ByRef R As Single, ByRef d As Single, ByRef Dgran As Single)
        Dim n As OggList.NodeP
        Dim i As Integer
        d = 0
        Elem = Elem1
        If Elem Is Nothing Then Exit Sub
        '---------------------------
        If Elem.GenMem.Tipo = -96 Or Elem.GenMem.Tipo = -15 Then
            n = ApparProv.Elementi.nodeHead.Next
            While Not n Is Nothing
                Ogg = n.TextData
                If Ogg.GenMem.Tipo = 25 Then
                    For i = 1 To Ogg.GenMem.Appesi.Count
                        Appeso = Ogg.GenMem.Appesi(i - 1)
                        If Appeso Is Elem Then
                            Elem = Ogg
                            Exit For
                        End If
                    Next i
                End If
                n = n.Next
            End While
        ElseIf System.Math.Abs(Elem.GenMem.Tipo) > 90 Then
            Exit Sub
        End If
        '---------------------------
        n = ApparProv.Elementi.nodeHead.Next
        Dim lposspa As Posizione
        While Not n Is Nothing
            Oggetto = n.TextData
            GenMem = Oggetto.GenMem
            If GenMem.Tipo < 90 And Not Oggetto Is Elem Then
                SwapCoordN(GenMem)
                lposspa = GenMem.SwappedPos
                StessDir = lposspa.CosDiritta.ProdScalar(Elem.GenMem.SwappedPos.CosDiritta)
                If System.Math.Abs(System.Math.Abs(StessDir) - 1) < 0.01 Then
                    DeltaOr.X = lposspa.Origine.X - Elem.GenMem.SwappedPos.Origine.X
                    DeltaOr.y = lposspa.Origine.y - Elem.GenMem.SwappedPos.Origine.y
                    DeltaOr.Z = lposspa.Origine.Z - Elem.GenMem.SwappedPos.Origine.Z
300:                dist = DeltaOr.ProdScalar(DeltaOr)
                    Coincid = True
                    If dist > 0.1 Then
                        dist = System.Math.Sqrt(dist)
                        CosDeltaOr.X = DeltaOr.X / dist
                        CosDeltaOr.y = DeltaOr.y / dist
                        CosDeltaOr.Z = DeltaOr.Z / dist
                        StessDir1 = lposspa.CosDiritta.ProdScalar(CosDeltaOr)
                        If System.Math.Abs(System.Math.Abs(StessDir1) - 1) > 0.01 Then Coincid = False
                    End If
                    If Coincid Then
                        Ri = lposspa.Origine.ProdScalar(Elem.GenMem.SwappedPos.CosDiritta)
                        Select Case System.Math.Abs(GenMem.Tipo)
                            Case 8, 9
                                Tubi = Oggetto
                                Tipo = System.Math.Abs(Tubi.GenMem.Tipo)
                            Case 26
                                Tubi = CType(Oggetto, Fascio).Tubi_Renamed
                                Tipo = System.Math.Abs(Tubi.GenMem.Tipo)
                            Case Else
                                Tipo = System.Math.Abs(GenMem.Tipo)
                        End Select
                        Select Case Tipo
                            Case 1, 34 'cilindri  tegole
                                Alung = Oggetto.Lunghezza
                                OTL = Oggetto.Diametro + 2 * Oggetto.Spessore
                                delta = Alung
                                agg()
                                Re1 = Risp
                                If (Ri - R) * (Re1 - R) <= 0 Then
                                    If OTL <= Dgran And OTL > d Then d = OTL
                                End If
                            Case 8 'tubi diritti
320:                            Alung = Tubi.Lunghezza
                                OTL = Tubi.DiamExt
                                delta = Alung
                                agg()
                                Re1 = Risp
                                If (Ri - R) * (Re1 - R) <= 0 Then
                                    If OTL < Dgran And OTL > d Then d = OTL
                                End If
                            Case 9 'tubi a U
                                Alung = Tubi.Lunghezza
                                yymax = Tubi.yUltimFila + Tubi.DiamExt / 2
                                delta = Alung
                                agg()
                                Re1 = Risp
                                delta = Alung + yymax
                                agg()
                                Re2 = Risp
                                If (Ri - R) * (Re1 - R) <= 0 Then
                                    If 2 * yymax < Dgran And 2 * yymax > d Then d = 2 * yymax
                                End If
                                If (Re1 - R) * (Re2 - R) <= 0 Then 'esterno
                                    If yymax <> 0 Then Alfa1 = GlobalRoutines.acos(System.Math.Abs(Re1 - R) / yymax)
                                    Dint = 2 * yymax * System.Math.Sin(Alfa1)
                                    If Dint < Dgran And Dint > d Then d = Dint
                                End If
                            Case 11 'Flangioni
                                Flangione = Oggetto
331:                            With Flangione
                                    delta = .H
                                    agg()
                                    Re1 = Risp
                                    delta = .H + .Spessore
                                    agg()
                                    Re2 = Risp
                                    delta = .H + .Spessore + .SpessGra
                                    agg()
                                    Re3 = Risp
                                    Select Case .SottoTipo
                                        Case 1 'gradino maschio
335:                                        If (Ri - R) * (Re1 - R) <= 0 And .H > 0 Then 'sullo hub
                                                B1 = .DiamInt + 2 * .g0 + 2 * (.g1 - .g0) * System.Math.Abs(Ri - R) / .H
                                                If B1 < Dgran And B1 > d Then d = B1
                                            End If
337:                                        If (Re1 - R) * (Re2 - R) <= 0 Then 'esterno
                                                If .DiamExt < Dgran And .DiamExt > d Then d = .DiamExt
                                            End If
                                            If (Re2 - R) * (Re3 - R) <= 0 Then
                                                If .DiamGra < Dgran And .DiamGra > d Then d = .DiamGra
                                            End If
                                        Case 2 'gradino femmina
                                            If (Ri - R) * (Re1 - R) <= 0 And .H > 0 Then 'sullo hub
                                                B1 = .DiamInt + 2 * .g0 + 2 * (.g1 - .g0) * System.Math.Abs(Ri - R) / .H
                                                If B1 < Dgran And B1 > d Then d = B1
                                            End If
                                            If (Re1 - R) * (Re2 - R) <= 0 Then 'esterno
                                                If .DiamExt < Dgran And .DiamExt > d Then d = .DiamExt
                                            End If
                                        Case 3 'flangia rovescia
                                            If (Ri - R) * (Re2 - R) <= 0 Then 'sullo hub
                                                If .DiamExt < Dgran And .DiamExt > d Then d = .DiamExt
                                            End If
                                    End Select
                                End With
                            Case 12 'piastre
340:                            'Call LookTipoPiastra(Rec2Buf(2).Dati(), Look)
                                Piastra = Oggetto
                                With Piastra
                                    delta = .H1
                                    agg()
                                    Re0 = Risp
                                    delta = .H2
                                    agg()
                                    Re7 = Risp
                                    delta = .H3
                                    agg()
                                    Re1 = Risp
                                    delta = .H1 + .Spessore
                                    agg()
                                    Re2 = Risp
                                    delta = .H2 + .Spessore
                                    agg()
                                    Re4 = Risp
                                    delta = .H1 + .Spessore + .H2
                                    agg()
                                    Re3 = Risp
                                    delta = -.H2 + .Spessore
                                    agg()
                                    Re5 = Risp
                                    delta = -.H1 - .H2 + .Spessore
                                    agg()
                                    Re8 = Risp
                                    delta = .Spessore
                                    agg()
                                    Re6 = Risp
                                    delta = -.H1 + .Spessore
                                    agg()
                                    Re9 = Risp
                                    delta = .H4
                                    agg()
                                    Re10 = Risp
                                    delta = .H1
                                    agg()
                                    Re11 = Risp
                                    Select Case .SottoTipo
                                        Case 1 '2 codoli esterni
                                            If (Ri - R) * (Re3 - R) <= 0 Then
                                                If .DiamExt < Dgran And .DiamExt > d Then d = .DiamExt
                                            End If
                                        Case 2 '1 int. / 1 est.
                                            If (Ri - R) * (Re2 - R) <= 0 Then
                                                If .DiamExt < Dgran And .DiamExt > d Then d = .DiamExt
                                            End If
                                            If (Re2 - R) * (Re3 - R) <= 0 Then
                                                If .B3 + 2 * .B2 < Dgran And .B3 + 2 * .B2 > d Then d = .B3 + 2 * .B2
                                            End If
                                        Case 3, 7 '1 int. + bulloni
                                            If (Ri - R) * (Re11 - R) <= 0 Then 'sul gradino interno
                                                If .B1 < Dgran And .B1 > d Then d = .B1
                                            End If
                                            If (Re11 - R) * (Re10 - R) <= 0 Then 'sul gradino esterno
                                                If .B4 < Dgran And .B4 > d Then d = .B4
                                            End If
                                            If (Re10 - R) * (Re1 - R) <= 0 Then 'sull'esterno
                                                If .DiamExt < Dgran And .DiamExt > d Then d = .DiamExt
                                            End If
                                            If (Re1 - R) * (Re4 - R) <= 0 Then
                                                If .B3 + 2 * .B2 < Dgran And .B3 + 2 * .B2 > d Then d = .B3 + 2 * .B2
                                            End If
                                        Case 4 'senza codoli 1 grad a sin 1 a des
                                            If (Ri - R) * (Re0 - R) <= 0 Then
                                                If .B1 < Dgran And .B1 > d Then d = .B1
                                            End If
                                            If (Re0 - R) * (Re5 - R) <= 0 Then
                                                If .DiamExt < Dgran And .DiamExt > d Then d = .DiamExt
                                            End If
                                            If (Re5 - R) * (Re6 - R) <= 0 Then
                                                If .B2 < Dgran And .B2 > d Then d = .B2
                                            End If
                                        Case 5 'senza codoli 2 grad a sin
                                            If (Ri - R) * (Re7 - R) <= 0 Then
                                                If .B2 < Dgran And .B2 > d Then d = .B2
                                            End If
                                            If (Re0 - R) * (Re7 - R) <= 0 Then
                                                If .B1 < Dgran And .B1 > d Then d = .B1
                                            End If
                                            If (Re0 - R) * (Re6 - R) <= 0 Then
                                                If .DiamExt < Dgran And .DiamExt > d Then d = .DiamExt
                                            End If
                                        Case 6
                                            If (Ri - R) * (Re7 - R) <= 0 Or (Re5 - R) * (Re6 - R) <= 0 Then
                                                If .B2 < Dgran And .B2 > d Then d = .B2
                                            End If
                                            If (Re0 - R) * (Re7 - R) <= 0 Or (Re5 - R) * (Re9 - R) <= 0 Then
                                                If .B1 < Dgran And .B1 > d Then d = .B1
                                            End If
                                            If (Re0 - R) * (Re9 - R) <= 0 Then
                                                If .DiamExt < Dgran And .DiamExt > d Then d = .DiamExt
                                            End If
                                    End Select
                                End With
                            Case 16 'calotte
                                Cal = Oggetto
                                With Cal
                                    de = .DiamExt
                                    Rcal = .RaggioCal
                                    R1 = .Ginocchio 'raccordo fondi piani
                                    A = .Colletto 'colletto fondi piani
                                    t = .Spessore
                                End With
                                If Rcal = 0 Then
                                    delta = t + A
                                    agg()
                                    Re1 = Risp
                                    If (Ri - R) * (Re1 - R) <= 0 Then
                                        If de < Dgran And de > d Then d = de
                                    End If
                                Else
                                    Rcal = Rcal + t
                                    Alfa = GlobalRoutines.asin(de / 2 / Rcal)
                                    delta = Rcal * (1 - System.Math.Cos(Alfa))
                                    agg()
                                    Re1 = Risp
                                    If (Ri - R) * (Re1 - R) <= 0 Then
                                        Alfa1 = GlobalRoutines.acos((Rcal * System.Math.Cos(Alfa) + System.Math.Abs(Ri - R)) / Rcal)
                                        Dint = 2 * Rcal * System.Math.Sin(Alfa1)
                                        If Dint < Dgran And Dint > d Then d = Dint
                                    End If
                                    delta = -t * System.Math.Cos(Alfa)
                                    agg()
                                    Re1 = Risp
                                    If (Ri - R) * (Re1 - R) <= 0 Then
                                        Dint = 2 * (Rcal - System.Math.Abs(Ri - R) / System.Math.Cos(Alfa)) * System.Math.Sin(Alfa)
                                        If Dint < Dgran And Dint > d Then d = Dint
                                    End If
                                End If
                            Case 28 'guarnizioni
                                With CType(Oggetto, clsGuarniz)
                                    Alung = .DiamMed + .Largh + 2 * .LarghExt
                                    OTL = .Spess
                                End With
                                delta = Alung
                                agg()
                                Re1 = Risp
                                If (Ri - R) * (Re1 - R) <= 0 Then
                                    If OTL <= Dgran And OTL > d Then d = OTL
                                End If
                        End Select
                    End If
                End If
            End If
            n = n.Next
        End While
        Exit Sub
ErrCercaInt: System.Diagnostics.Debug.WriteLine(Err.Description)
        Stop
        Resume
    End Sub
    Private Sub agg()
        'Fine.X = Rec2Buf(2).PosSpa.Origine.X + delta * Rec2Buf(2).PosSpa.CosDiritta.X
        'Fine.Y = Rec2Buf(2).PosSpa.Origine.Y + delta * Rec2Buf(2).PosSpa.CosDiritta.Y
        'Fine.Z = Rec2Buf(2).PosSpa.Origine.Z + delta * Rec2Buf(2).PosSpa.CosDiritta.Z
        'Risp = ProdScalar(Fine, Rec2Buf(3).PosSpa.CosDiritta)
        Risp = Ri + StessDir * delta
    End Sub 'b
    Sub CercaBocchelli(ByRef Oggetto As Membratura, ByRef jB As Short, ByRef DBuco() As Single, ByRef OrigiB As RoutBase1.clsPunti, ByRef DirB As RoutBase1.clsPunti)
        Dim Bucante As Membratura
        Dim posspa As Posizione
        If IUNL < 2 Then Exit Sub
        Dim j As Short
        Dim prod As Single
        jB = 0
        For j = 1 To Apparecchio.Elementi.Count() - 1
            If Apparecchio.Elementi(j).GenMem.Tipo = 97 Then
                If Apparecchio.Elementi(j).GenMem.posizione.SuChi Is Oggetto Then
                    Bucante = Apparecchio.Elementi(j).Bucante
                    If Bucante.GenMem.Tipo = 10 Or Bucante.GenMem.Tipo = 14 Then
                        SwapCoordN(Bucante.GenMem)
                        posspa = Bucante.GenMem.SwappedPos
                        If System.Math.Abs(posspa.CosDiritta.Z) < TOLER And System.Math.Abs(posspa.Origine.Z) < TOLER Then
                            prod = posspa.CosDiritta.ProdScalar(Oggetto.GenMem.SwappedPos.CosDiritta)
                            If System.Math.Abs(prod) > TOLER Then
                                jB = jB + 1
800:                            If jB > UBound(DBuco) Then ReDim Preserve DBuco(2 * jB)
                                OrigiB = New RoutBase1.clsPunti
                                DirB = New RoutBase1.clsPunti
                                OrigiB.Inizia(2 * jB) : DirB.Inizia(2 * jB)
                                DBuco(jB) = Apparecchio.Elementi(j).DiamFor
                                OrigiB.Punti.Item(jB).TextData.X = posspa.Origine.X
                                OrigiB.Punti.Item(jB).TextData.y = posspa.Origine.y
                                DirB.Punti.Item(jB).TextData.X = posspa.CosDiritta.X
                                DirB.Punti.Item(jB).TextData.y = posspa.CosDiritta.y
                            End If
                        End If
                    End If
                End If
            End If
        Next
    End Sub
    Sub GeomNStd(ByRef Oggetto As clsNonStd, ByRef PuntiS As RoutBase1.clsPunti, ByRef PuntiD As RoutBase1.clsPunti, ByRef Direz1 As RoutBase1.clsVec2, ByRef Direz2 As RoutBase1.clsVec2, ByRef racc As Single, ByRef Alfa As Single, ByRef iSwBul As Boolean, ByRef iswRanda As Boolean)
        Dim i As Short
        Dim posspa As Posizione
        Dim xSmax, xSmin, ySmin, ySmax As Single
        posspa = Oggetto.GenMem.SwappedPos
        With Oggetto
            If .Randa = 0 Then iswRanda = False
            If IUNL = 0 Then
                xSmin = -.Sporgenza / 10 : ySmin = -0.6 * .DiamFl
                xSmax = 1.2 * .Sporgenza : ySmax = -ySmin
                If Not Funzioni.DisRut.Scala(xSmin, xSmax, ySmin, ySmax) Then Exit Sub
            End If
            PuntiS = New RoutBase1.clsPunti : PuntiD = New RoutBase1.clsPunti
            PuntiS.Inizia(40) : PuntiD.Inizia(40)
            If .B2 > .DiamInt Then
                PuntiS.Punti0(0).X = 0 : PuntiS.Punti0(0).y = .B2 / 2
                PuntiS.Punti0(1).X = .B1 : PuntiS.Punti0(1).y = .B2 / 2
                PuntiS.Punti0(2).X = .B1 + .H1 : PuntiS.Punti0(2).y = .DiamInt / 2
            Else
                PuntiS.Punti0(0).X = 0 : PuntiS.Punti0(0).y = .DiamInt / 2
                PuntiS.Punti0(0).copia(PuntiS.Punti0(1))
                PuntiS.Punti0(0).copia(PuntiS.Punti0(2))
            End If
            PuntiS.Punti0(3).X = .Sporgenza : PuntiS.Punti0(3).y = .DiamInt / 2
            If .DiamFl > .DiamExt Then
                PuntiS.Punti0(4).X = .Sporgenza : PuntiS.Punti0(4).y = .BoltCir / 2 - .B3 / 2
                PuntiS.Punti0(5).X = .Sporgenza : PuntiS.Punti0(5).y = .BoltCir / 2
                PuntiS.Punti0(6).X = .Sporgenza : PuntiS.Punti0(6).y = .BoltCir / 2 + .B3 / 2
                PuntiS.Punti0(7).X = .Sporgenza : PuntiS.Punti0(7).y = .DiamFl / 2
                PuntiS.Punti0(8).X = .Sporgenza - .SpessFl : PuntiS.Punti0(8).y = .DiamFl / 2
                PuntiS.Punti0(9).X = .Sporgenza - .SpessFl : PuntiS.Punti0(9).y = .BoltCir / 2 + .B3 / 2
                PuntiS.Punti0(10).X = .Sporgenza - .SpessFl : PuntiS.Punti0(10).y = .BoltCir / 2
                PuntiS.Punti0(11).X = .Sporgenza - .SpessFl : PuntiS.Punti0(11).y = .BoltCir / 2 - .B3 / 2
                PuntiS.Punti0(12).X = .Sporgenza - .SpessFl : PuntiS.Punti0(12).y = .DiamExt / 2
            Else
                PuntiS.Punti0(4).X = .Sporgenza : PuntiS.Punti0(4).y = .DiamExt / 2
                For i = 5 To 12
                    PuntiS.Punti0(4).copia(PuntiS.Punti0(i))
                Next
            End If
            If .DiamRinf > .DiamExt Then
                PuntiS.Punti0(13).X = .AltzRinf + .H : PuntiS.Punti0(13).y = .DiamExt / 2
                PuntiS.Punti0(14).X = .AltzRinf : PuntiS.Punti0(14).y = .DiamRinf / 2
                If .DiamScarpa > .DiamRinf Then
                    PuntiS.Punti0(15).X = .SpesScarpa : PuntiS.Punti0(15).y = .DiamRinf / 2
                    PuntiS.Punti0(16).X = .SpesScarpa : PuntiS.Punti0(16).y = .DiamScarpa / 2
                    PuntiS.Punti0(17).X = 0 : PuntiS.Punti0(17).y = .DiamScarpa / 2
                Else
                    PuntiS.Punti0(15).X = 0 : PuntiS.Punti0(15).y = .DiamRinf / 2
                    PuntiS.Punti0(15).copia(PuntiS.Punti0(16))
                    PuntiS.Punti0(15).copia(PuntiS.Punti0(17))
                End If
            Else
                PuntiS.Punti0(12).copia(PuntiS.Punti0(13))
                PuntiS.Punti0(12).copia(PuntiS.Punti0(14))
                If .DiamScarpa > .DiamExt Then
                    PuntiS.Punti0(15).X = .SpesScarpa : PuntiS.Punti0(15).y = .DiamExt / 2
                    PuntiS.Punti0(16).X = .SpesScarpa : PuntiS.Punti0(16).y = .DiamScarpa / 2
                    PuntiS.Punti0(17).X = 0 : PuntiS.Punti0(17).y = .DiamScarpa / 2
                Else
                    PuntiS.Punti0(15).X = 0 : PuntiS.Punti0(15).y = .DiamExt / 2
                    PuntiS.Punti0(15).copia(PuntiS.Punti0(16))
                    PuntiS.Punti0(15).copia(PuntiS.Punti0(17))
                End If
            End If
            PuntiS.Punti0(18).X = 0 : PuntiS.Punti0(18).y = 0 'origine locale
            PuntiS.Punti0(19).y = PuntiS.Punti0(7).y : PuntiS.Punti0(19).X = (PuntiS.Punti0(7).X + PuntiS.Punti0(17).X) / 2
            PuntiS.Punti0(20).X = -.SpessFl : PuntiS.Punti0(20).y = 0 'primo estremo asse
            PuntiS.Punti0(21).X = .Sporgenza + .SpessFl : PuntiS.Punti0(22).y = 0 'secon estremo asse
        End With
        Call TrasfGen(posspa, PuntiS, PuntiD, 18, 21, True)
    End Sub
    Sub GeomBocch(ByRef Oggetto As clsBocch, ByRef PuntiS As RoutBase1.clsPunti, ByRef PuntiD As RoutBase1.clsPunti, ByRef Direz1 As RoutBase1.clsVec2, ByRef Direz2 As RoutBase1.clsVec2, ByRef racc As Single, ByRef Alfa As Single, ByRef iSwBul As Boolean, ByRef iswRanda As Boolean)
        GenMem = Oggetto.GenMem : posspa = GenMem.SwappedPos
        Try
            With Oggetto
                If .Randa = 0 Then iswRanda = False
23:             If IUNL = 0 Then
                    xSmin = -.Standard.Altezza / 10 : ySmin = -0.6 * .Standard.DiamExt : xSmax = 1.2 * .Standard.Altezza : ySmax = -ySmin
                    If .Standard.K3 = 5 Then xSmin = -.Standard.Spessore / 10 : xSmax = 1.2 * .Standard.Spessore
                    If Not Funzioni.DisRut.Scala(xSmin, xSmax, ySmin, ySmax) Then Exit Sub
                End If
                Adim = .Standard.DiamTr
                If .Standard.K3 = 3 Then .Standard.SpessGrad = 0
                If .Standard.K3 = 2 Or .Standard.K3 = 3 Then Adim = (.Standard.Altezza - .Standard.Spessore - .Standard.SpessGrad) * 4.0! / 5 + .DiamInt
                If .Standard.K3 = 5 Then .Standard.Altezza = .Standard.Spessore + .Standard.SpessGrad : .DiamInt = 0
                PuntiS = New RoutBase1.clsPunti : PuntiD = New RoutBase1.clsPunti
                PuntiS.Inizia(40) : PuntiD.Inizia(40)
                '29      For i = 0 To 27: PuntiD.Punti0(i).X = 0: PuntiD.Punti0(i).Y = 0: Next
30:             PuntiS.Punti0(0).X = 0 : PuntiS.Punti0(0).y = .DiamInt / 2
                If .Standard.K3 = 4 And iswRanda Then
                    Alfa1 = GlobalRoutines.asin((.SpostLat + .DiamInt / 2) / .Randa)
                    Alfa2 = GlobalRoutines.asin(.SpostLat / .Randa)
                    HRANZAi = .Randa * (System.Math.Cos(Alfa1) - System.Math.Cos(Alfa2))
                    PuntiS.Punti0(0).X = HRANZAi
                    Alfa1 = GlobalRoutines.asin((.SpostLat - .DiamInt / 2) / .Randa)
                    HRANZAi = .Randa * (System.Math.Cos(Alfa1) - System.Math.Cos(Alfa2))
                    PuntiD.Punti0(0).X = HRANZAi : PuntiD.Punti0(0).y = -PuntiS.Punti0(0).y
                End If
                SpessGra0 = .Standard.SpessGrad
                DiamGr0 = .Standard.DiamGr0
                If DiamGr0 = 0 Then
                    SpessGra0 = 0
                    DiamGr0 = (.DiamInt + .Standard.GradExt) / 2
                End If
                PuntiS.Punti0(1).X = .Standard.Altezza : PuntiS.Punti0(1).y = .DiamInt / 2
                PuntiS.Punti0(2).X = .Standard.Altezza : PuntiS.Punti0(2).y = (DiamGr0 - SpessGra0 * 1.3) / 2
                PuntiS.Punti0(3).X = .Standard.Altezza - SpessGra0 : PuntiS.Punti0(3).y = PuntiS.Punti0(2).y + SpessGra0 * (1.0! / 4.8)
                PuntiS.Punti0(5).X = .Standard.Altezza : PuntiS.Punti0(5).y = (DiamGr0 + SpessGra0 * 1.3) / 2
                PuntiS.Punti0(4).X = .Standard.Altezza - SpessGra0 : PuntiS.Punti0(4).y = PuntiS.Punti0(5).y - SpessGra0 * (1.0! / 4.8)
                PuntiS.Punti0(6).X = .Standard.Altezza : PuntiS.Punti0(6).y = .Standard.GradExt / 2
                PuntiS.Punti0(7).X = .Standard.Altezza - .Standard.SpessGrad : PuntiS.Punti0(7).y = .Standard.GradExt / 2
                PuntiS.Punti0(8).X = PuntiS.Punti0(7).X : PuntiS.Punti0(8).y = (.Standard.BC - .Standard.DiaFori) / 2
                PuntiS.Punti0(9).X = PuntiS.Punti0(7).X : PuntiS.Punti0(9).y = (.Standard.BC + .Standard.DiaFori) / 2
                PuntiS.Punti0(10).X = PuntiS.Punti0(7).X : PuntiS.Punti0(10).y = .Standard.DiamExt / 2
                PuntiS.Punti0(11).X = .Standard.Altezza - .Standard.SpessGrad - .Standard.Spessore : PuntiS.Punti0(11).y = .Standard.DiamExt / 2
                PuntiS.Punti0(12).X = PuntiS.Punti0(11).X : PuntiS.Punti0(12).y = (.Standard.BC + .Standard.DiaFori) / 2
                PuntiS.Punti0(13).X = PuntiS.Punti0(11).X : PuntiS.Punti0(13).y = (.Standard.BC - .Standard.DiaFori) / 2
                If .Standard.K3 = 5 Then
                    PuntiS.Punti0(14) = PuntiS.Punti0(0)
                Else
                    If Adim = 0 Then Exit Sub
                    If .Standard.K3 = 4 Then
                        Alfa = PI / 2
                        TanAlfa = 0
                        .Standard.x = Adim + 2 * .Standard.Raccordo
                    ElseIf .Standard.K3 = 1 Then
                        H1 = .Standard.Altezza - .Standard.SpessGrad - .Standard.Spessore - (Adim - .DiamInt) / 2 * System.Math.Sqrt(3.0!) / 2 - 25.4 / 4
                        Alfa = System.Math.Atan(H1 / (.Standard.x - Adim) * 2)
                        TanAlfa = (H1 / (.Standard.x - Adim) * 2)
                    ElseIf .Standard.K3 = 2 Then  'slip on
                        H1 = .Standard.Altezza - .Standard.SpessGrad - .Standard.Spessore
                        Alfa = System.Math.Atan(H1 / (.Standard.x - Adim) * 2)
                        TanAlfa = (H1 / (.Standard.x - Adim) * 2)
                    Else 'da verificare   L.J.
                        H1 = .Standard.Altezza - .Standard.SpessGrad - .Standard.Spessore
                        Alfa = System.Math.Atan(H1 / (.Standard.x - Adim) * 2)
                        TanAlfa = (H1 / (.Standard.x - Adim) * 2)
                    End If
                    PuntiS.Punti0(14).X = PuntiS.Punti0(11).X : PuntiS.Punti0(14).y = .Standard.x / 2
                    PuntiS.Punti0(15).X = PuntiS.Punti0(14).X - .Standard.Raccordo * (1.0! - System.Math.Cos(Alfa)) : PuntiS.Punti0(15).y = .Standard.x / 2 - .Standard.Raccordo * System.Math.Sin(Alfa)
                    PuntiS.Punti0(16).X = PuntiS.Punti0(14).X - (.Standard.x - Adim) / 2 * TanAlfa
                    PuntiS.Punti0(16).y = Adim / 2
                    If .Standard.K3 = 4 Then PuntiS.Punti0(16).X = PuntiS.Punti0(16).X - .Standard.Raccordo
                    PuntiS.Punti0(17).X = 0.0! : PuntiS.Punti0(17).y = Adim / 2
                    PuntiS.Punti0(17).copia(PuntiS.Punti0(18))
                    PuntiS.Punti0(0).copia(PuntiS.Punti0(19))
                    PuntiS.Punti0(0).copia(PuntiS.Punti0(20))
                    If .Standard.K3 = 4 And iswRanda Then
                        Dext = Adim
                        HZAe(Oggetto)
                        PuntiS.Punti0(17) = PuntiS.Punti0(18)
                        PuntiD.Punti0(17) = PuntiD.Punti0(18)
                    End If
                    If .Standard.K3 = 2 Then PuntiS.Punti0(0).copia(PuntiS.Punti0(17))
                    If .TipoF = 2 Then 'autorinforzato
                        Spost = .Sporgenza - .Standard.Altezza
                        PuntiS.Punti0(16).X = .AltzRinf + .DiamRinf / 2 - PuntiS.Punti0(15).y - Spost '(.DiamRinf - Adim) / 2
                        PuntiS.Punti0(16).y = PuntiS.Punti0(15).y
                        PuntiS.Punti0(17).X = .AltzRinf - Spost : PuntiS.Punti0(17).y = .DiamRinf / 2
                        PuntiS.Punti0(18).X = -Spost : PuntiS.Punti0(18).y = .DiamRinf / 2
                        PuntiS.Punti0(19).X = -Spost : PuntiS.Punti0(19).y = .DiamInt / 2
                        PuntiS.Punti0(20).X = -Spost : PuntiS.Punti0(20).y = .DiamInt / 2
                        If .Standard.K3 = 4 And iswRanda Then
                            Dext = .DiamRinf
                            HZAe(Oggetto)
                            PuntiD.Punti0(17).X = PuntiS.Punti0(17).X : PuntiD.Punti0(17).y = -PuntiS.Punti0(17).y
                        End If
                    ElseIf .TipoF = 1 Then  'scarpa
                        Spessmant = Oggetto.GenMem.posizione.SuChi.SpessBase
                        Spost = .Sporgenza - .Standard.Altezza
                        PuntiS.Punti0(16).X = .SpesScarpa + .Standard.Raccordo - Spost
                        PuntiS.Punti0(16).y = PuntiS.Punti0(15).y
                        PuntiS.Punti0(17).X = .SpesScarpa - Spost : PuntiS.Punti0(17).y = PuntiS.Punti0(15).y + .Standard.Raccordo
                        PuntiS.Punti0(25).X = PuntiS.Punti0(16).X : PuntiS.Punti0(25).y = PuntiS.Punti0(17).y 'centro
                        PuntiS.Punti0(18).X = .SpesScarpa - Spost : PuntiS.Punti0(18).y = .DiamScarpa / 2 - (.SpesScarpa - Spessmant) * 3
                        PuntiS.Punti0(30).X = Spessmant - Spost : PuntiS.Punti0(30).y = .DiamScarpa / 2
                        PuntiS.Punti0(19).X = -Spost : PuntiS.Punti0(19).y = .DiamScarpa / 2
                        PuntiS.Punti0(20).X = -Spost : PuntiS.Punti0(20).y = .DiamInt / 2
                    End If
                    'centro del raggio di raccordo
                    PuntiS.Punti0(21).X = PuntiS.Punti0(14).X - .Standard.Raccordo
                    PuntiS.Punti0(21).y = PuntiS.Punti0(14).y '+ .Standard.Raccordo 'centro raccordo
                    Direz1.X = System.Math.Cos(Alfa / 2) : Direz2.X = Direz1.X
                    Direz1.y = -System.Math.Sin(Alfa / 2) : Direz2.y = -Direz1.y
                End If
                PuntiS.Punti0(22).X = 0 : PuntiS.Punti0(22).y = 0 'origine locale
                PuntiS.Punti0(26) = PuntiS.Punti0(0) 'centro randa
                If iswRanda Then
                    PuntiS.Punti0(26).X = -System.Math.Sqrt(.Randa * .Randa - .SpostLat * .SpostLat) : PuntiS.Punti0(26).y = -.SpostLat
                End If
                PuntiS.Punti0(26).copia(PuntiD.Punti0(26))
                'asse fori
                PuntiS.Punti0(23).X = PuntiS.Punti0(8).X + .Standard.Spessore / 2
                PuntiS.Punti0(23).y = .Standard.BC / 2
                PuntiS.Punti0(24).X = PuntiS.Punti0(12).X - .Standard.Spessore / 2
                PuntiS.Punti0(24).y = .Standard.BC / 2
                PuntiS.Punti0(27).X = PuntiS.Punti0(18).X
                PuntiS.Punti0(27).y = (PuntiS.Punti0(14).y + PuntiS.Punti0(18).y) / 2 'per lo spot
                PuntiS.Punti0(28).X = -.Standard.Spessore
                PuntiS.Punti0(28).y = 0 'primo estremo asse
                PuntiS.Punti0(29).X = .Standard.Altezza + .Standard.Spessore
                PuntiS.Punti0(29).y = 0 'secon estremo asse
                DiamB = 0
                Call ApparProv.CercaBul(Oggetto, DiamB, DbulB)
                iSwBul = (DiamB > 0)
                If iswRanda And .Standard.K3 = 4 Then
                    For i = 0 To 27
                        If PuntiD.Punti0(i).X = 0 And PuntiD.Punti0(i).y = 0 Then
                            PuntiD.Punti0(i).X = PuntiS.Punti0(i).X
                            PuntiD.Punti0(i).y = -PuntiS.Punti0(i).y
                        End If
                    Next
                    Call TrasfGen(posspa, PuntiS, PuntiD, 22, 30, False)
                Else
                    Call TrasfGen(posspa, PuntiS, PuntiD, 22, 30, True)
                End If
                racc = .Standard.Raccordo
            End With
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Private Sub HZAe(ByVal oggetto As clsBocch)
        With oggetto
            Alfa1 = GlobalRoutines.asin((.SpostLat + Dext / 2) / .Randa)
            Alfa2 = GlobalRoutines.asin(.SpostLat / .Randa)
            HRANZAe = .Randa * (System.Math.Cos(Alfa1) - System.Math.Cos(Alfa2))
            PuntiS.Punti0(18).X = HRANZAe
            Alfa1 = GlobalRoutines.asin((.SpostLat - Dext / 2) / .Randa)
            HRANZAe = .Randa * (System.Math.Cos(Alfa1) - System.Math.Cos(Alfa2))
            PuntiD.Punti0(18).X = HRANZAe : PuntiD.Punti0(18).y = -PuntiS.Punti0(18).y
        End With
    End Sub 'd
    Sub DisBocch(ByRef Oggetto As Membratura)
        posspa = Oggetto.GenMem.SwappedPos
        Direzione.X = 0 : Direzione.y = 0 : Direzione.Z = 1
        prod = posspa.CosDiritta.ProdScalar(Direzione)
1:      If System.Math.Abs(prod) < TOLER Then
            Prod1 = posspa.CosTraversa.ProdScalar(Direzione)
            If System.Math.Abs(Prod1) > 0.5 Then iswRanda = True Else iswRanda = False 'visibilit… randa
            If System.Math.Abs(Oggetto.GenMem.Tipo) = 10 Then
                Call GeomBocch(Oggetto, PuntiS, PuntiD, Direz1, Direz2, racc, Alfa, iSwBul, iswRanda)
                '  If IUNL = 1 Then Exit Sub
                '  xSmin = PuntiS.Punti.Item(11).TextData.X
                '  ySmin = PuntiS.Punti.Item(11).TextData.y
                '  xSmax = PuntiD.Punti.Item(19).TextData.X
                '  ySmax = PuntiD.Punti.Item(19).TextData.y
                '  Dext = Oggetto.Standard.DiamExt
            Else
                Call GeomNStd(Oggetto, PuntiS, PuntiD, Direz1, Direz2, racc, Alfa, iSwBul, iswRanda)
                ' If IUNL = 1 Then Exit Sub
                ' Dext = Oggetto.DiamFl ': If Look.Adim > Dext Then Dext = Look.Adim
                ' xSmin = PuntiS.Punti.Item(18).TextData.X
                ' ySmin = PuntiS.Punti.Item(18).TextData.y
                ' xSmax = PuntiD.Punti.Item(8).TextData.X
                ' ySmax = PuntiD.Punti.Item(8).TextData.y
            End If
        Else
            If System.Math.Abs(Oggetto.GenMem.Tipo) = 10 Then
                Dext = Oggetto.Standard.DiamExt
            Else
                Dext = Oggetto.DiamFl
            End If
            If Dext = 0 Then Exit Sub
        End If
        If System.Math.Abs(prod) > TOLER Then
            SezRettBocch()
            Exit Sub
        End If 'asse bocchello perpendicolare al foglio
        z1 = posspa.Origine.Z
        If z1 < -Dext / 2 Then Exit Sub 'bocchello indietro
        If IUNL = 4 Then
            SpotsBocch(Oggetto)
            Exit Sub
        End If
        If z1 > Dext / 2 Then 'bocchello in vista
            iSwSez = False
221:        Call Infilata(Oggetto, z1, InMezzo)
            If InMezzo > 1 Then Exit Sub
            If InMezzo = 1 Then
                Call Funzioni.DisRut.ctrait(3, 0.1)
                icolor = 3
            Else
                Call Funzioni.DisRut.ctrait(0, 0.1)
                icolor = 0
            End If
            SezBocch(Oggetto)
            Call Funzioni.DisRut.ctrait(0, 0.1)
            icolor = 0
        Else 'bocchello in sezione
            iSwSez = True
            SezBocch(Oggetto)
        End If '111
    End Sub
    Private Sub SezBocch(ByVal Oggetto As Membratura)
        If IUNL = 4 Then Exit Sub
        If Oggetto.GenMem.Tipo = 14 Then
            SezNStd()
        Else
            SezStd(Oggetto)
        End If
    End Sub
    Private Sub SezNStd()
        If Not iSwSez Then
            Funzioni.DisRut.tratto(PuntiS.Punti.Item(8).TextData.X, PuntiS.Punti.Item(8).TextData.y, PuntiD.Punti.Item(8).TextData.X, PuntiD.Punti.Item(8).TextData.y, 0.1, icolor)
            Funzioni.DisRut.tratto(PuntiS.Punti.Item(9).TextData.X, PuntiS.Punti.Item(9).TextData.y, PuntiD.Punti.Item(9).TextData.X, PuntiD.Punti.Item(9).TextData.y, 0.1, icolor)
            PuntiS.SpezzGraf(7, 17, Funzioni.DisRut) : PuntiD.SpezzGraf(7, 17, Funzioni.DisRut)
            Funzioni.DisRut.tratto(PuntiS.Punti.Item(18).TextData.X, PuntiS.Punti.Item(18).TextData.y, PuntiD.Punti.Item(18).TextData.X, PuntiD.Punti.Item(18).TextData.y, 0.1, icolor)
            Exit Sub
        End If
        PuntiS.SpezzGraf(0, 4, Funzioni.DisRut) : PuntiD.SpezzGraf(0, 4, Funzioni.DisRut)
        Funzioni.DisRut.tratto(PuntiS.Punti.Item(5).TextData.X, PuntiS.Punti.Item(5).TextData.y, PuntiS.Punti.Item(12).TextData.X, PuntiS.Punti.Item(12).TextData.y, 0.1, 0)
        Funzioni.DisRut.tratto(PuntiD.Punti.Item(5).TextData.X, PuntiD.Punti.Item(5).TextData.y, PuntiD.Punti.Item(12).TextData.X, PuntiD.Punti.Item(12).TextData.y, 0.1, 0)
        PuntiS.SpezzGraf(11, 17, Funzioni.DisRut) : PuntiD.SpezzGraf(11, 17, Funzioni.DisRut)
        Funzioni.DisRut.tratto(PuntiS.Punti.Item(18).TextData.X, PuntiS.Punti.Item(18).TextData.y, PuntiS.Punti.Item(1).TextData.X, PuntiS.Punti.Item(1).TextData.y, 0.1, 0)
        Funzioni.DisRut.tratto(PuntiD.Punti.Item(18).TextData.X, PuntiD.Punti.Item(18).TextData.y, PuntiD.Punti.Item(1).TextData.X, PuntiD.Punti.Item(1).TextData.y, 0.1, 0)
        PuntiS.SpezzGraf(4, 11, Funzioni.DisRut) : PuntiD.SpezzGraf(4, 11, Funzioni.DisRut)
        Funzioni.DisRut.tratto(PuntiS.Punti.Item(7).TextData.X, PuntiS.Punti.Item(7).TextData.y, PuntiS.Punti.Item(10).TextData.X, PuntiS.Punti.Item(10).TextData.y, 0.1, 0)
        Funzioni.DisRut.tratto(PuntiD.Punti.Item(7).TextData.X, PuntiD.Punti.Item(7).TextData.y, PuntiD.Punti.Item(10).TextData.X, PuntiD.Punti.Item(10).TextData.y, 0.1, 0)
        Funzioni.DisRut.tratto(PuntiS.Punti.Item(6).TextData.X, PuntiS.Punti.Item(6).TextData.y, PuntiS.Punti.Item(11).TextData.X, PuntiS.Punti.Item(11).TextData.y, 0.1, 3) 'asse fori
        Funzioni.DisRut.tratto(PuntiD.Punti.Item(6).TextData.X, PuntiD.Punti.Item(6).TextData.y, PuntiD.Punti.Item(11).TextData.X, PuntiD.Punti.Item(11).TextData.y, 0.1, 3)
        Funzioni.DisRut.tratto(PuntiS.Punti.Item(1).TextData.X, PuntiS.Punti.Item(1).TextData.y, PuntiD.Punti.Item(1).TextData.X, PuntiD.Punti.Item(1).TextData.y, 0.1, 0)
        Funzioni.DisRut.tratto(PuntiS.Punti.Item(4).TextData.X, PuntiS.Punti.Item(4).TextData.y, PuntiD.Punti.Item(4).TextData.X, PuntiD.Punti.Item(4).TextData.y, 0.1, 0)
        Funzioni.DisRut.tratto(PuntiS.Punti.Item(21).TextData.X, PuntiS.Punti.Item(21).TextData.y, PuntiS.Punti.Item(22).TextData.X, PuntiS.Punti.Item(22).TextData.y, 0.1, 3) 'asse bocchello
    End Sub
    Private Sub SezStd(ByVal Oggetto As Membratura)
        Try
            If iswRanda Then
                SwapCoordN(posspa.SuChi.GenMem)
                posspaM = posspa.SuChi.GenMem.SwappedPos
                Prod1 = System.Math.Abs((PuntiS.Punti.Item(19).TextData.X - posspaM.Origine.X) * posspa.CosDiritta.X + (PuntiS.Punti.Item(19).TextData.y - posspaM.Origine.y) * posspa.CosDiritta.y)
                Prod2 = System.Math.Abs((PuntiD.Punti.Item(19).TextData.X - posspaM.Origine.X) * posspa.CosDiritta.X + (PuntiD.Punti.Item(19).TextData.y - posspaM.Origine.y) * posspa.CosDiritta.y)
                Prod3 = System.Math.Abs(-(PuntiS.Punti.Item(19).TextData.X - posspaM.Origine.X) * posspa.CosDiritta.y + (PuntiS.Punti.Item(19).TextData.y - posspaM.Origine.y) * posspa.CosDiritta.X)
                Prod4 = System.Math.Abs(-(PuntiD.Punti.Item(19).TextData.X - posspaM.Origine.X) * posspa.CosDiritta.y + (PuntiD.Punti.Item(19).TextData.y - posspaM.Origine.y) * posspa.CosDiritta.X)
                If (Prod1 - Prod2) * (Prod3 - Prod4) > 0 Then
                    For i = 0 To 29
                        Vector.X = -(PuntiS.Punti.Item(29).TextData.X - PuntiS.Punti.Item(i + 1).TextData.X) * posspa.CosDiritta.y
                        Vector.y = (PuntiS.Punti.Item(29).TextData.y - PuntiS.Punti.Item(i + 1).TextData.y) * posspa.CosDiritta.X
                        PuntiS.Punti.Item(i + 1).TextData.X = PuntiS.Punti.Item(i + 1).TextData.X + 2 * Vector.X
                        PuntiS.Punti.Item(i + 1).TextData.y = PuntiS.Punti.Item(i + 1).TextData.y + 2 * Vector.y
                        Vector.X = -(PuntiS.Punti.Item(29).TextData.X - PuntiD.Punti.Item(i + 1).TextData.X) * posspa.CosDiritta.y
                        Vector.y = (PuntiS.Punti.Item(29).TextData.y - PuntiD.Punti.Item(i + 1).TextData.y) * posspa.CosDiritta.X
                        PuntiD.Punti.Item(i + 1).TextData.X = PuntiD.Punti.Item(i + 1).TextData.X + 2 * Vector.X
                        PuntiD.Punti.Item(i + 1).TextData.y = PuntiD.Punti.Item(i + 1).TextData.y + 2 * Vector.y
                    Next
                    Direz3 = Direz1
                    Direz1 = Direz2
                    Direz2 = Direz3
                End If
            End If
            If Oggetto.Standard.K3 = 5 Then i0 = 1 Else i0 = 0
            If Not iSwSez Then i0 = 1
            PuntiS.SpezzGraf(i0, 8, Funzioni.DisRut) : PuntiS.SpezzGraf(9, 12, Funzioni.DisRut)
            PuntiS.SpezzGraf(13, 14, Funzioni.DisRut)
            If Oggetto.TipoF = 1 Then 'da forgiato con scarpa
                PuntiS.SpezzGraf(15, 16, Funzioni.DisRut) : PuntiS.SpezzGraf(17, 18, Funzioni.DisRut)
                Funzioni.DisRut.tratto((PuntiS.Punti0(18).X), (PuntiS.Punti0(18).y), (PuntiS.Punti0(30).X), (PuntiS.Punti0(30).y), 0.1, 0)
                Funzioni.DisRut.tratto((PuntiS.Punti0(30).X), (PuntiS.Punti0(30).y), (PuntiS.Punti0(19).X), (PuntiS.Punti0(19).y), 0.1, 0)
                PuntiS.SpezzGraf(19, 20, Funzioni.DisRut)
                Funzioni.DisRut.tratto((PuntiS.Punti0(20).X), (PuntiS.Punti0(20).y), (PuntiS.Punti0(1).X), (PuntiS.Punti0(1).y), 0.1, 0)
            Else
                If Oggetto.Standard.K3 < 4 Or (Oggetto.Standard.K3 = 4 And Not iswRanda) Then
516:                PuntiS.SpezzGraf(15, 20, Funzioni.DisRut)
                    Funzioni.DisRut.tratto((PuntiS.Punti0(20).X), (PuntiS.Punti0(20).y), (PuntiS.Punti0(1).X), (PuntiS.Punti0(1).y), 0.1, 0)
                ElseIf Oggetto.Standard.K3 < 5 Then
517:                PuntiS.SpezzGraf(15, 18, Funzioni.DisRut)
                End If
            End If '333
52:         PuntiD.SpezzGraf(i0, 8, Funzioni.DisRut) : PuntiD.SpezzGraf(9, 12, Funzioni.DisRut)
            PuntiD.SpezzGraf(13, 14, Funzioni.DisRut)
            If Oggetto.TipoF = 1 Then 'da forgiato con scarpa
                PuntiD.SpezzGraf(15, 16, Funzioni.DisRut) : PuntiD.SpezzGraf(17, 18, Funzioni.DisRut)
                Funzioni.DisRut.tratto((PuntiD.Punti0(18).X), (PuntiD.Punti0(18).y), (PuntiD.Punti0(30).X), (PuntiD.Punti0(30).y), 0.1, 0)
                Funzioni.DisRut.tratto((PuntiD.Punti0(30).X), (PuntiD.Punti0(30).y), (PuntiD.Punti0(19).X), (PuntiD.Punti0(19).y), 0.1, 0)
                PuntiD.SpezzGraf(19, 20, Funzioni.DisRut)
                Funzioni.DisRut.tratto((PuntiD.Punti0(20).X), (PuntiD.Punti0(20).y), (PuntiD.Punti0(1).X), (PuntiD.Punti0(1).y), 0.1, 0)
            Else
                If Oggetto.Standard.K3 < 4 Or (Oggetto.Standard.K3 = 4 And Not iswRanda) Then
                    PuntiD.SpezzGraf(15, 20, Funzioni.DisRut)
                    Funzioni.DisRut.tratto((PuntiD.Punti0(20).X), (PuntiD.Punti0(20).y), (PuntiD.Punti0(1).X), (PuntiD.Punti0(1).y), 0.1, 0)
                ElseIf Oggetto.Standard.K3 < 5 Then
                    PuntiD.SpezzGraf(15, 18, Funzioni.DisRut)
                End If
            End If '444
            If iSwSez Then
                Funzioni.DisRut.tratto(PuntiS.Punti.Item(8).TextData.X, PuntiS.Punti.Item(8).TextData.y, PuntiS.Punti.Item(13).TextData.X, PuntiS.Punti.Item(13).TextData.y, 0.1, 0)
                Funzioni.DisRut.tratto(PuntiS.Punti.Item(9).TextData.X, PuntiS.Punti.Item(9).TextData.y, PuntiS.Punti.Item(12).TextData.X, PuntiS.Punti.Item(12).TextData.y, 0.1, 0)
                Funzioni.DisRut.tratto(PuntiD.Punti.Item(8).TextData.X, PuntiD.Punti.Item(8).TextData.y, PuntiD.Punti.Item(13).TextData.X, PuntiD.Punti.Item(13).TextData.y, 0.1, 0)
                Funzioni.DisRut.tratto(PuntiD.Punti.Item(9).TextData.X, PuntiD.Punti.Item(9).TextData.y, PuntiD.Punti.Item(12).TextData.X, PuntiD.Punti.Item(12).TextData.y, 0.1, 0)
            Else
                Funzioni.DisRut.tratto(PuntiS.Punti.Item(8).TextData.X, PuntiS.Punti.Item(8).TextData.y, PuntiS.Punti.Item(9).TextData.X, PuntiS.Punti.Item(9).TextData.y, 0.1, 0)
                Funzioni.DisRut.tratto(PuntiS.Punti.Item(13).TextData.X, PuntiS.Punti.Item(13).TextData.y, PuntiS.Punti.Item(12).TextData.X, PuntiS.Punti.Item(12).TextData.y, 0.1, 0)
                Funzioni.DisRut.tratto(PuntiD.Punti.Item(8).TextData.X, PuntiD.Punti.Item(8).TextData.y, PuntiD.Punti.Item(9).TextData.X, PuntiD.Punti.Item(9).TextData.y, 0.1, 0)
                Funzioni.DisRut.tratto(PuntiD.Punti.Item(13).TextData.X, PuntiD.Punti.Item(13).TextData.y, PuntiD.Punti.Item(12).TextData.X, PuntiD.Punti.Item(12).TextData.y, 0.1, 0)
            End If
            If Not iSwBul Then
                If iSwSez Then
                    Funzioni.DisRut.tratto(PuntiS.Punti.Item(8).TextData.X, PuntiS.Punti.Item(8).TextData.y, PuntiS.Punti.Item(9).TextData.X, PuntiS.Punti.Item(9).TextData.y, 0.1, 0)
                    Funzioni.DisRut.tratto(PuntiS.Punti.Item(13).TextData.X, PuntiS.Punti.Item(13).TextData.y, PuntiS.Punti.Item(12).TextData.X, PuntiS.Punti.Item(12).TextData.y, 0.1, 0)
                    Funzioni.DisRut.tratto(PuntiD.Punti.Item(8).TextData.X, PuntiD.Punti.Item(8).TextData.y, PuntiD.Punti.Item(9).TextData.X, PuntiD.Punti.Item(9).TextData.y, 0.1, 0)
                    Funzioni.DisRut.tratto(PuntiD.Punti.Item(13).TextData.X, PuntiD.Punti.Item(13).TextData.y, PuntiD.Punti.Item(12).TextData.X, PuntiD.Punti.Item(12).TextData.y, 0.1, 0)
                    Funzioni.DisRut.tratto(PuntiS.Punti.Item(23).TextData.X, PuntiS.Punti.Item(23).TextData.y, PuntiS.Punti.Item(24).TextData.X, PuntiS.Punti.Item(24).TextData.y, 0.1, 3)
                    Funzioni.DisRut.tratto(PuntiD.Punti.Item(23).TextData.X, PuntiD.Punti.Item(23).TextData.y, PuntiD.Punti.Item(24).TextData.X, PuntiD.Punti.Item(24).TextData.y, 0.1, 3)
                End If '555
            Else 'ci sono dei bulloni
            End If '666
            DirR.X = posspa.CosDiritta.X
            DirR.y = posspa.CosDiritta.y
            If Oggetto.Standard.K3 < 5 And Alfa > 0 Then
                If IUNL >= 2 Then GlobalRoutines.ComposDir(Direz1, DirR)
                ArcoGraf(PuntiS.Punti.Item(21).TextData, racc, Direz1, Alfa, IUNL - 1)
                If IUNL >= 2 Then GlobalRoutines.ComposDir(Direz2, DirR)
                ArcoGraf(PuntiD.Punti.Item(21).TextData, racc, Direz2, Alfa, IUNL - 1)
                If Oggetto.Standard.K3 = 4 And iswRanda Then 'RAGGIO DELLA RANDA
                    racc1 = System.Math.Sqrt((PuntiS.Punti.Item(18).TextData.X - PuntiS.Punti.Item(26).TextData.X) ^ 2 + (PuntiS.Punti.Item(18).TextData.y - PuntiS.Punti.Item(26).TextData.y) ^ 2)
                    Vector.X = (PuntiS.Punti.Item(18).TextData.X - PuntiS.Punti.Item(26).TextData.X) / racc1
                    Vector.y = (PuntiS.Punti.Item(18).TextData.y - PuntiS.Punti.Item(26).TextData.y) / racc1
                    Alfa1 = GlobalRoutines.arco((Vector.X), (Vector.y))
                    If Alfa1 < 0 Then Alfa1 = Alfa1 + 2 * PI 'VisualBasic
                    Vector.X = (PuntiD.Punti.Item(18).TextData.X - PuntiD.Punti.Item(26).TextData.X) / racc1
                    Vector.y = (PuntiD.Punti.Item(18).TextData.y - PuntiD.Punti.Item(26).TextData.y) / racc1
                    Alfa2 = GlobalRoutines.arco((Vector.X), (Vector.y))
                    If Alfa2 < 0 Then Alfa2 = Alfa2 + 2 * PI 'VisualBasic
                    Alfa = (Alfa1 + Alfa2) / 2
                    Direz1.X = System.Math.Cos(Alfa) : Direz1.y = System.Math.Sin(Alfa)
                    Alfa = System.Math.Abs(Alfa1 - Alfa2) : If Alfa > 2 * PI Then Alfa = Alfa - 2 * PI
                    ArcoGraf(PuntiS.Punti.Item(26).TextData, racc1, Direz1, Alfa, IUNL - 1)
                    If Alfa > PI Then 'VisualBasic
                        Alfa = 2 * PI - Alfa 'VisualBasic
                        Direz1.X = -Direz1.X : Direz1.y = -Direz1.y 'VisualBasic
                    End If 'VisualBasic
                End If
                If Oggetto.TipoF = 1 Then 'da forgiato con scarpa
                    Direz1.X = -System.Math.Cos(Alfa / 2) : Direz2.X = Direz1.X
                    Direz1.y = -System.Math.Sin(Alfa / 2) : Direz2.y = -Direz1.y
                    If IUNL >= 2 Then GlobalRoutines.ComposDir(Direz1, DirR)
                    ArcoGraf(PuntiS.Punti.Item(25).TextData, racc, Direz1, Alfa, IUNL - 1)
                    If IUNL >= 2 Then GlobalRoutines.ComposDir(Direz2, DirR)
                    ArcoGraf(PuntiD.Punti.Item(25).TextData, racc, Direz2, Alfa, IUNL - 1)
                End If 'aaa
            End If 'bbb
            Funzioni.DisRut.tratto(PuntiS.Punti.Item(1).TextData.X, PuntiS.Punti.Item(1).TextData.y, PuntiD.Punti.Item(1).TextData.X, PuntiD.Punti.Item(1).TextData.y, 0.1, 0) 'CHIUSURA SOPRA
            If Not iswRanda And Oggetto.TipoF > 2 Then Funzioni.DisRut.tratto(PuntiS.Punti.Item(0).TextData.X, PuntiS.Punti.Item(0).TextData.y, PuntiD.Punti.Item(0).TextData.X, PuntiD.Punti.Item(0).TextData.y, 0.1, 0) 'CHIUSURA SOTTO
            Funzioni.DisRut.tratto(PuntiS.Punti.Item(28).TextData.X, PuntiS.Punti.Item(28).TextData.y, PuntiS.Punti.Item(29).TextData.X, PuntiS.Punti.Item(29).TextData.y, 0.1, 3) 'asse bocchello
            If IUNL < 3 Then
                If iSwSez Then
                End If
            End If '888
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Private Sub SpotsBocch(ByVal Oggetto As Membratura)
        Try
            Spots = New spot
            Spots.Tipo = 1
            Spots.Quota = z1
            If System.Math.Abs(CType(Oggetto.GenMem, clsGenMem).Tipo) = 10 Then
                Spots.Quadro.TopLeft.X = GlobalRoutines.Minimo(PuntiS.Punti.Item(11).TextData.X, PuntiD.Punti.Item(10).TextData.X)
                Spots.Quadro.TopLeft.y = GlobalRoutines.Minimo(PuntiS.Punti.Item(11).TextData.y, PuntiD.Punti.Item(10).TextData.y)
                Spots.Quadro.Botrigt.X = GlobalRoutines.Massimo(PuntiS.Punti.Item(11).TextData.X, PuntiD.Punti.Item(10).TextData.X)
                Spots.Quadro.Botrigt.y = GlobalRoutines.Massimo(PuntiS.Punti.Item(11).TextData.y, PuntiD.Punti.Item(10).TextData.y)
                Call RegisterSpot(Spots, Oggetto)
                Spots = New spot
                Spots.Tipo = 1
                Spots.Quota = z1 '17,15
                Spots.Quadro.TopLeft.X = GlobalRoutines.Minimo(PuntiS.Punti.Item(17).TextData.X, PuntiD.Punti.Item(15).TextData.X)
                Spots.Quadro.TopLeft.y = GlobalRoutines.Minimo(PuntiS.Punti.Item(17).TextData.y, PuntiD.Punti.Item(15).TextData.y)
                Spots.Quadro.Botrigt.X = GlobalRoutines.Massimo(PuntiS.Punti.Item(17).TextData.X, PuntiD.Punti.Item(15).TextData.X)
                Spots.Quadro.Botrigt.y = GlobalRoutines.Massimo(PuntiS.Punti.Item(17).TextData.y, PuntiD.Punti.Item(15).TextData.y)
                Call RegisterSpot(Spots, Oggetto)
            Else
                Spots.Quadro.TopLeft.X = PuntiS.Punti.Item(8).TextData.X
                Spots.Quadro.TopLeft.y = PuntiS.Punti.Item(9).TextData.y
                Spots.Quadro.Botrigt.X = PuntiD.Punti.Item(20).TextData.X
                Spots.Quadro.Botrigt.y = PuntiD.Punti.Item(20).TextData.y
                Call RegisterSpot(Spots, Oggetto)
            End If
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Private Sub SezRettBocch()
        Try
            z1 = posspa.Origine.Z
            Verso = posspa.Origine.Z
            z2 = posspa.Origine.Z + Oggetto.Sporgenza * posspa.CosDiritta.Z
            If z1 < 0 And z2 < 0 Then
                Exit Sub
            Else
                x = posspa.Origine.X
                y = posspa.Origine.y
                If Oggetto.GenMem.Tipo = 10 Then
                    Dext = Oggetto.Standard.DiamExt
                    Dint = Oggetto.Diamint 'aFl!(9, K3) * Scalb!
                    Dguar = Oggetto.Standard.GradExt
                    Dfori = Oggetto.Standard.DiaFori
                    BoltCir = Oggetto.Standard.BC
                    Nf = Oggetto.Standard.NumBolts
                Else
                    Dint = Oggetto.Diamint
                    If Oggetto.DiamFl > Oggetto.Diamext Then 'c'è una flangia
                        Dfori = Oggetto.B3
                        Dext = Oggetto.DiamFl
                        Nf = Oggetto.LC
                        BoltCir = Oggetto.BoltCir 'stub
                    Else
                        Dext = Oggetto.Diamext
                        Nf = 0
                    End If
                End If
                If IUNL = 4 Then
                    SpotFon1()
                    Exit Sub
                End If
                If z1 > 0 And z2 > 0 Then
                    Call Infilata(Oggetto, Verso, InMezzo)
                    If InMezzo > 1 Then Return
                End If
                Call Funzioni.DisRut.refabs()
                Call Funzioni.DisRut.ctrait(0, 0.1)
1632:           Call Funzioni.DisRut.cerc(x, y, Dext / 2)
                Call Funzioni.DisRut.cerc(x, y, Dint / 2)
                If Dguar > 0 Then Call Funzioni.DisRut.cerc(x, y, Dguar / 2)
                For i = 1 To Nf
                    A = (i - 0.5) * 2 * PI / Nf
                    x1 = x + BoltCir / 2 * System.Math.Cos(A) : y1 = y + BoltCir / 2 * System.Math.Sin(A)
                    Call Funzioni.DisRut.cerc(x1, y1, Dfori / 2)
                Next
            End If
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Private Sub SpotFon1()
        Spots = New spot
2402:   Spots.Tipo = 2
        Spots.Quota = z2
        Spots.spicchio.Origin.X = x
        Spots.spicchio.Origin.y = y
        Spots.spicchio.Direct.X = 1 : Spots.spicchio.Direct.y = 0
        Spots.spicchio.RG = Dext / 2
        Spots.spicchio.RP = Dint / 2
        Spots.spicchio.Alfa = 2 * PI
        RegisterSpot(Spots, Oggetto)
    End Sub
    Sub SwapCoordN(ByRef g As clsGenMem)
        Dim Vec As New RoutBase1.clsVec3
        Dim icoor As Short
        g.SwappedPos = New Posizione
        g.posizione.Copia((g.SwappedPos))
        icoor = 1 : g.posizione.Origine.copia(Vec) : Swap3(Vec, icoor) : Vec.copia((g.SwappedPos.Origine))
        icoor = 2 : g.posizione.CosDiritta.copia(Vec) : Swap3(Vec, icoor) : Vec.copia((g.SwappedPos.CosDiritta))
        icoor = 3 : g.posizione.CosTraversa.copia(Vec) : Swap3(Vec, icoor) : Vec.copia((g.SwappedPos.CosTraversa))
        icoor = 4 : g.posizione.CosTerza.copia(Vec) : Swap3(Vec, icoor) : Vec.copia((g.SwappedPos.CosTerza))
        icoor = 5 : g.posizione.CosOrigine.copia(Vec) : Swap3(Vec, icoor) : Vec.copia((g.SwappedPos.CosOrigine))
    End Sub 'g
    Sub Swap3(ByRef Vec As RoutBase1.clsVec3, ByRef icoor As Short)
        Dim Dumt As Single
        Dim segno As Short
        Try
            segno = sezioni.Verso(LungPip)
            Select Case sezioni.Tipo(LungPip)
                Case 1 'sezione longitudinale
                    Dumt = Vec.X
                    If icoor = 1 Then
                        sezioni = sezvec.Clone
                        Dumt = Dumt - sezioni.Quota(LungPip)
                    End If
                    Vec.X = Vec.y
                    Vec.y = Vec.Z
                    Vec.Z = Dumt * segno
                    If icoor = 1 Then
                        Vec.X = Vec.X + sezioni.Spost(LungPip).X
                        Vec.y = Vec.y + sezioni.Spost(LungPip).y
                    End If
                Case 2 'sezione perpendicolare a Y
                    Dumt = Vec.y
                    If icoor = 1 Then
                        sezioni = sezvec.Clone
                        Dumt = Dumt - sezioni.Quota(LungPip)
                    End If
                    Vec.y = Vec.Z
                    Vec.Z = Dumt * segno
                    If icoor = 1 Then
                        Vec.X = Vec.X * segno + sezioni.Spost(LungPip).X + sezioni.Quota(LungPip)
                        Vec.y = Vec.y + sezioni.Spost(LungPip).y
                    Else
                        Vec.X = Vec.X * segno
                    End If
                Case 3 'sezione perpendicolare a Z
                    Dumt = Vec.Z
                    If icoor = 1 Then
                        sezioni = sezvec.Clone
                        Dumt = Dumt - sezioni.Quota(LungPip)
                    End If
                    Vec.Z = Dumt * segno
                    Dumt = Vec.X
                    Vec.X = Vec.y
                    Vec.y = -Dumt * segno
                    If icoor = 1 Then
                        Vec.X = Vec.X + sezioni.Spost(LungPip).X
                        Vec.y = Vec.y + sezioni.Spost(LungPip).y
                    End If
            End Select
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Public Sub Aggancio(ByRef DiscoR As String)
        If Len(DiscoR) = 0 Then Exit Sub
        If Len(RTrim(Inizio.Archdir)) = 0 Then
            Inizio.DiscoRam = DiscoR
            Inizio.Standard()
            Funzioni.DisRut.Init200((Inizio.Archdir))
        End If
    End Sub
    Public Sub SalvaLav()
        If Not job Is Nothing Then job.Comm.SalvaCom()
    End Sub
    Public Sub AggCoordN(ByRef Record As clsGenMem, Optional ByRef A As clsApparecchio = Nothing)
        Dim Recordv As clsGenMem
        Dim Ogg As Membratura
        Try
            If Record.Tipo = 0 Or Record.Tipo = 97 Then Exit Sub
            Recordv = CType(Record.posizione, Posizione).SuChi.GenMem
            If Recordv Is Nothing Then Stop
            If Recordv.posizione.CosDiritta.ProdScalar((Recordv.posizione.CosDiritta)) = 0 Then Exit Sub
            SetOriginN(Record, Recordv) ', 1, 1 ' RecordV.Dati(3), RecordV.Dati(10) 'Coseni retta quota/origine
            SetDirittaN(Record, Recordv) 'Coseni asse nuovo
            SetTraversaN(Record, Recordv) 'Coseni direzione traversa e z
            TrasfCoordN(Record, Recordv)
            SetXYZN(Record, Recordv) 'Coordinate origine
            PostPos(Record, Recordv)
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
        If Not A Is Nothing Then
            Dim n As OggList.NodeP = A.Elementi.nodeHead.Next
            While Not n Is Nothing
                Ogg = n.TextData
                If Ogg.GenMem.posizione.SuChi Is Record.Parent Then
                    AggCoordN(Ogg.GenMem, A)
                End If
                n = n.Next
            End While
        End If
    End Sub
    Public Sub DisAxes(ByRef O As Membratura)
        Dim PunPia As New RoutBase1.clsVec3
        Dim NorPia As New RoutBase1.clsVec3
        Dim Punto As New RoutBase1.clsVec3
        Dim PunPro As New RoutBase1.clsVec3
        Dim Lung As Single
        Dim posspa As Posizione
        If IUNL = 1 Or IUNL = 4 Then Exit Sub
        If Squadratura.Punti0(3).y = clsTrigon.Infinito Then Exit Sub
        posspa = CType(O.GenMem, clsGenMem).SwappedPos
        NorPia.X = 0
        NorPia.y = 0
        NorPia.Z = 1
        'traccia asse Y
        Lung = Squadratura.Punti0(4).y - Squadratura.Punti0(3).y
        'If Lung = 0 Then Exit Sub
        'Punto.x = Lung * posspa.CosDiritta.x
        'Punto.y = Lung * posspa.CosDiritta.y
        'Punto.Z = Lung * posspa.CosDiritta.Z
        'Proietta PunPia, NorPia, Punto, PunPro
        'Funzioni.DisRut.tratto 0, 0, PunPro.x, PunPro.y, 4, 3
        Funzioni.DisRut.tratto(0, Squadratura.Punti0(3).y - 0.1 * Lung, 0, Squadratura.Punti0(4).y + 0.1 * Lung, 4, 3)
        'traccia asse X
        Lung = Squadratura.Punti0(4).X - Squadratura.Punti0(3).X
        ' Punto.x = Lung * posspa.CosTraversa.x
        ' Punto.y = Lung * posspa.CosTraversa.y
        ' Punto.Z = Lung * posspa.CosTraversa.Z
        ' Proietta PunPia, NorPia, Punto, PunPro
        ' Funzioni.DisRut.tratto 0, 0, PunPro.x, PunPro.y, 4, 3
        Funzioni.DisRut.tratto(Squadratura.Punti0(3).X - 0.1 * Lung, 0, Squadratura.Punti0(4).X + 0.1 * Lung, 0, 4, 3)
        'traccia asse Z
        'Lung = Squadratura.Punti0(4).y - Squadratura.Punti0(3).y
        'Punto.x = Lung * posspa.CosTerza.x
        'Punto.y = Lung * posspa.CosTerza.y
        'Punto.Z = Lung * posspa.CosTerza.Z
        'Proietta PunPia, NorPia, Punto, PunPro
        'Funzioni.DisRut.tratto 0, 0, PunPro.x, PunPro.y, 4, 3
    End Sub
    Public Sub DisFlangiaSola(ByVal Oggetto As clsBocch, ByRef Facing As Short, ByRef ModIUNL As Short, ByRef Sezione As Boolean, ByRef Direzione As Short)
        Dim Appar As clsApparecchio
        sezioni = New clsSezioni
        Oggetto = New clsBocch
        Oggetto.GenMem.Tipo = 10
        globFlangia.leggi()
        With Oggetto
            .TipoF = 5
            .Standard = globFlangia
            .DiamInt = globFlangia.DiamInt
            .Standard.Facing = Facing 'frmFlange.cmbFacing.ListIndex + 1
            globFlangia.Variato = False
        End With
        jRec = 0
        Set4Dir(Oggetto, Direzione, Sezione)
        sezsalva = sezioni.Clone
        LungPip = 1 : sezioni.Nsezioni = 1 : sezioni.Tipo(1) = 1
        sezioni.Verso(1) = -1
        sezvec = sezioni.Clone
        Appar = New clsApparecchio
        Appar.Add(Oggetto)
        Disegno(ModIUNL, 0, Appar)
        sezioni = sezsalva
    End Sub
    Public Sub Posiziona(ByRef f1 As Object, ByRef f2 As Object)
        f2.Left = f1.Left
        f2.Top = f1.Top + f1.Height
        If f2.Left + f2.Width > System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width Then
            f2.Left = f2.Left - (f2.Left + f2.Width - System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width)
        End If
        If f2.Top + f2.Height > System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height Then
            f2.Top = f1.Top - f2.Height
            If f2.Top < 0 Then f2.Top = 0
        End If
    End Sub
    Public Sub Set4Dir(ByRef lMembro As Membratura, ByRef Direzione As Short, ByRef Sezione As Boolean)
        With CType(lMembro.GenMem, clsGenMem).posizione
            .CosDiritta.X = 0
            .CosDiritta.y = 0
            .CosDiritta.Z = 0
            .CosTraversa.X = 0
            .CosTraversa.y = 0
            .CosTraversa.Z = 0
            .CosTerza.X = 0
            .CosTerza.y = 0
            .CosTerza.Z = 0
            .DirTraversa = "Au"
            Select Case Direzione
                Case 0
                    .DirDiritta = "+N"
                    .CosDiritta.Z = 1
                    .CosTraversa.y = 1
                    .CosTerza.X = 1
                Case 1
                    .DirDiritta = "-N"
                    .CosDiritta.Z = -1
                    .CosTraversa.y = -1
                    .CosTerza.X = -1
                Case 2
                    .DirDiritta = "=+"
                    .CosDiritta.y = 1
                    .CosTraversa.Z = 1
                    .CosTerza.X = 1
                Case 3
                    .DirDiritta = "=-"
                    .CosDiritta.y = -1
                    .CosTraversa.Z = -1
                    .CosTerza.X = -1
                Case 4
                    .DirDiritta = "Do"
                    .CosDiritta.X = -1
                    .CosTraversa.y = -1
                    .CosTerza.Z = -1
                Case 5
                    .DirDiritta = "Up"
                    .CosDiritta.X = 1
                    .CosTraversa.y = 1
                    .CosTerza.Z = 1
            End Select
            .Origine.X = 0
            .Origine.y = 0
            .Origine.Z = 0
            If Not Sezione Then .Origine.X = -10000
        End With
    End Sub
    Public Sub GeneraApparecchio()
        Lancio.Legacy.Serialization.LegacyBinarySerializer.EnsureEnabled()
        Dim Mat As LibMat.MaterialeNew1
        Mat = New LibMat.MaterialeNew1
        Try
            Apparecchio = New clsApparecchio
            Apparecchio.Asse = job.Comm.Asse
            Dim nLati As Short = job.Comm.NumeroLati
            If nLati > 0 Then
                Apparecchio.NumeroLati = nLati
            Else
                Apparecchio.NumeroLati = Funzioni.QuantiLati
            End If
            If Apparecchio.NumeroLati = 0 Then
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
                Exit Sub
            End If
            job.Comm.NumeroLati = Apparecchio.NumeroLati
            FileAPR = Funzioni.FileDes("APR")
            Try
                Funzioni.iAPRn = New FileStream(FileAPR, FileMode.OpenOrCreate, FileAccess.Read)
            Catch e As Exception
                MsgBox(e.Message + vbCrLf + e.StackTrace)
            End Try
            If Funzioni.iAPRn.Length = 0 Then
                Funzioni.GeneraOggetto(0, Membro)
                Membro.GenMem.Denom = "Origine apparecchio"
                Funzioni.InitPosSpaN(0, Membro.GenMem)
                Apparecchio.Add(Membro)
                GoTo FinePrematura
            End If
            Dim bf As New Lancio.Legacy.Serialization.LegacyBinarySerializer
            Try
                Apparecchio = CType(bf.Deserialize(Funzioni.iAPRn), clsApparecchio)
            Catch e As Exception
                Testo = "Si è determinato durante la lettura dei dati l'errore seguente:" + vbCrLf
                Testo = Testo + e.Message + "." + vbCrLf
                Testo = Testo + "I dati sono irrecuperabili e quindi sarà aperta una distinta vuota."
                MessageBox.Show(Testo)
                Funzioni.GeneraOggetto(0, Membro)
                Membro.GenMem.Denom = "Origine apparecchio"
                Funzioni.InitPosSpaN(0, Membro.GenMem)
                Apparecchio.Add(Membro)
                GoTo FinePrematura
            End Try
            Editing = True : Caricamento = True : IUNL = 0
            Monitor.Motore.ProgrInizio("Generazione legami in corso", "Generazione apparecchio")
            Apparecchio.LeggiApparecchio(False)
            Monitor.Motore.ProgrAmmazza()
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
FinePrematura:
        Funzioni.iAPRn.Close()
        Funzioni.iAPRn = Nothing
    End Sub
    Sub DisPolig(ByRef Polig As clsPolig)
        Dim Puntif As New RoutBase1.clsPunti
        Dim Spots As New spot
        Dim Puntif1 As New RoutBase1.clsPunti
        Dim CoszSW As New RoutBase1.clsVec3
        Dim InMezzo, Npunti, jmax As Short
        Dim Verso As Single
        Dim Area, area0 As Single
        Dim i, imax, j As Short
        Dim posspa As Posizione
        posspa = Polig.GenMem.SwappedPos
2130:   Call IntersPol(Polig, Npunti, Puntif, Puntif1, Verso, CoszSW)
        If Verso = -1000 Or Npunti = 0 Then Exit Sub
        '2140 If IUNL = 1 Then
        '      Call MaxMin(Npunti, Puntif, posspa)
        '      Exit Sub
        '     End If 'v
        If Npunti < 0 Then 'calcola linee nascoste
2150:       Call DisTaglio(Npunti, Puntif, Verso, Polig) 'Verso?
        ElseIf Npunti > 0 Then
            If IUNL < 4 Then
                Verso = posspa.Origine.Z
                Call Infilata(Polig, Verso, InMezzo)
                If InMezzo > 1 Then Exit Sub
                If InMezzo = 1 Then Call Funzioni.DisRut.ctrait(3, 0.1)
2160:           Call SpezzSpecial(Npunti, Puntif, Puntif1, (Polig.Raggi), CoszSW)
                Call Funzioni.DisRut.ctrait(0, 0.1)
            Else
                Spots = New spot
                Spots.Tipo = 1
                Spots.Quota = Verso
                area0 = 0
                For i = 1 To Npunti - 1
                    For j = i + 1 To Npunti
                        Area = System.Math.Abs((Puntif.Punti.Item(i).TextData.X - Puntif.Punti.Item(j).TextData.X) * (Puntif.Punti.Item(i).TextData.y - Puntif.Punti.Item(j).TextData.y))
                        If Area > area0 Then imax = i : jmax = j : area0 = Area
                    Next j
                Next i
                If imax > 0 Then
                    Spots.Quadro.TopLeft.X = GlobalRoutines.Minimo(Puntif.Punti.Item(imax).TextData.X, Puntif.Punti.Item(jmax).TextData.X)
                    Spots.Quadro.TopLeft.y = GlobalRoutines.Minimo(Puntif.Punti.Item(imax).TextData.y, Puntif.Punti.Item(jmax).TextData.y)
                    Spots.Quadro.Botrigt.X = GlobalRoutines.Massimo(Puntif.Punti.Item(imax).TextData.X, Puntif.Punti.Item(jmax).TextData.X)
                    Spots.Quadro.Botrigt.y = GlobalRoutines.Massimo(Puntif.Punti.Item(imax).TextData.y, Puntif.Punti.Item(jmax).TextData.y)
                    RegisterSpot(Spots, Polig)
                End If
            End If 'z
        End If 'x
    End Sub 'a
    Public Sub SecondaRiga(ByRef lMembro As Membratura)
        Dim XVec As Short
        'stampa seconda riga solo se la membratura è riportata
        With lMembro
            XVec = .TipoMat
            If XVec < 2 Then Exit Sub
            jRec = jRec + 1
            Select Case XVec
                Case 2
                    '       RecordD(jRec).Denom = "PLACCATURA"
                    '       RecordD(jRec).LTO = CSng(Str(0))
                Case 3
                    '      RecordD(jRec).Denom = "RIPORTO SALDATURA"
                    '     RecordD(jRec).LTO = CSng(Str(.GenMem.LireKg2 * .GenMem.Pnet1))
                Case 4
                    '    RecordD(jRec).Denom = "LINING"
                    '   RecordD(jRec).LTO = CSng(Str(.GenMem.LireKg2 * .GenMem.Pnet1))
            End Select
            '     RecordD(jRec) = Rec2Buf(4)
            '     RecordD(jRec).Tipo = 99
            '     RecordD(jRec).Note = Chr(32)
            '    RecordD(jRec).DIME = "SPESSORE RIPORTO" & Str(.SpessRive)
            '   RecordD(jRec).Indmat = .GenMem.IndMat2
            '   RecordD(jRec).PosDis = RecordD(jRec - 1).PosDis
            '   RecordD(jRec).posspa.SuChi = RecordD(jRec - 1).Ind
            '   RecordD(jRec).MF = "--"
        End With
    End Sub
    Public Sub DisTon(ByRef Oggetto As Tondo)
        Dim Cil As New Cilindro
        If Not Oggetto.isW Or IUNL < 1 Then Exit Sub 'interruttore di disegnazione
        Cil = New Cilindro
        'Oggetto.GenMem.Copia Cil.GenMem
        Cil.GenMem.SwappedPos = Oggetto.GenMem.SwappedPos
        Cil.GenMem.posizione = Oggetto.GenMem.posizione
        Cil.Diametro = Oggetto.Diametro
        Cil.SpessBase = 0
        Cil.Lunghezza = Oggetto.Lunghezza
        DisCil(1, Cil)
    End Sub

    Public Sub SuperAppendi(ByRef Oggetto As Membratura)
        Dim key As String
        Dim i, j As Short
        Dim g As clsGenMem = Oggetto.GenMem
        Try
            key = g.keyG
            For i = 1 To g.Appesi.Count
                Dim gAppeso As clsGenMem = CType(g.Appesi(i - 1).GenMem, clsGenMem)
                Apparecchio.Add(g.Appesi(i - 1), key)
                key = gAppeso.keyG
            Next
            '            For i = 1 To CType(g.Appesi, OggList).Count
            '            Dim gAppeso As clsGenMem = CType(g.Appesi(i - 1).GenMem, clsGenMem)
            '            If i = 1 Then
            '            key = g.keyG
            '            ' If Oggetto.GenMem.Appesi.Count > 0 Then
            '            '    key = Oggetto.GenMem.Appesi(Oggetto.GenMem.Appesi.Count).GenMem.Denom
            '            ' End If
            '            Else
            '                key = gAppeso.keyG
            '                If CType(gAppeso.Appesi, OggList).Count > 0 Then
            '            key = CType(gAppeso.Appesi(CType(gAppeso.Appesi, OggList).Count - 1).GenMem, clsGenMem).keyG
            '                End If
            '            End If
            '            Apparecchio.Add(g.Appesi(i - 1), key)
            '            Dim gAppeso0 As clsGenMem = CType(g.Appesi(i).GenMem, clsGenMem)
            '            gAppeso0.ClearAppesi(False)
            '            For j = 1 To gAppeso0.Appesi.Count
            '            If j = 1 Then
            '            key = gAppeso0.keyG
            '            Else
            '                key = CType(gAppeso0.Appesi(j - 2).GenMem, clsGenMem).keyG
            '            End If
            '            Apparecchio.Add(gAppeso0.Appesi(j - 1), key)
            '            Next
            '            Next
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Public Sub MembroDebug(ByRef m As Membratura)
        Dim posspa, Swap As Posizione
        posspa = CType(m.GenMem, clsGenMem).posizione
        Swap = CType(m.GenMem, clsGenMem).SwappedPos
        System.Diagnostics.Debug.WriteLine(CType(m.GenMem, clsGenMem).Denom & CType(m.GenMem, clsGenMem).Tipo & CType(CType(m.GenMem, clsGenMem).posizione.SuChi.GenMem, clsGenMem).Denom)
        With posspa
            System.Diagnostics.Debug.WriteLine("Dirdiritta" & .DirDiritta)
            System.Diagnostics.Debug.WriteLine("Quota" & .Quota & .QuotaR)
            System.Diagnostics.Debug.WriteLine("Raggio" & .Raggio & .RaggioR)
            System.Diagnostics.Debug.WriteLine("Anomal" & .Anomal & .AnomalR)
            System.Diagnostics.Debug.WriteLine("DirTraversa" & .DirTraversa)
            System.Diagnostics.Debug.WriteLine(LegacyUiUnits.TabLayout(.Origine.X, .Origine.y & .Origine.Z))
        End With
        System.Diagnostics.Debug.WriteLine("---------")
        With Swap
            System.Diagnostics.Debug.WriteLine(LegacyUiUnits.TabLayout(.Origine.X, .Origine.y & .Origine.Z))
            System.Diagnostics.Debug.WriteLine(LegacyUiUnits.TabLayout(.CosDiritta.X, .CosDiritta.y & .CosDiritta.Z))
            System.Diagnostics.Debug.WriteLine(LegacyUiUnits.TabLayout(.CosTraversa.X, .CosTraversa.y & .CosTraversa.Z))
            System.Diagnostics.Debug.WriteLine(LegacyUiUnits.TabLayout(.CosTerza.X, .CosTerza.y & .CosTerza.Z))
        End With
        Stop
    End Sub
    Public Sub ScaricaGrezzi()
        Dim i As Short
        'Dim grezzo As grezzi
        Dim Table As New DataTable
        Dim dvTable As DataView
        Dim drv As DataRowView
        Dim Dupl As New DataTable
        Dim db As New OleDbConnection
        Dim cmd As OleDbDataAdapter
        Dim CB As OleDbCommandBuilder
        Dim APR As String
        Dim j As Short
        Dim g As clsGenMem
        If Apparecchio Is Nothing Then Exit Sub
        FileGre = FunzLibgra.FileDes("GRE")
        InizGre(db)
        APR = job.Comm.Arch.Trim & "\" + job.Comm.Ind.Item(job.Comm.indice).Data.File
        cmd = New OleDbDataAdapter("SELECT * FROM Grezzi WHERE APR = '" & APR & "'", db)
        cmd.Fill(Table) '= db.OpenRecordset("SELECT * FROM Grezzi WHERE APR = '" & APR & "'")
        dvTable = New DataView(Table)
        CB = New OleDbCommandBuilder(cmd)
        For i = 0 To CShort(Table.Rows.Count - 1)
            drv = dvTable(0)
            drv.Delete()
        Next
        cmd.Update(Table)
        Table.Dispose()
        cmd = New OleDbDataAdapter("SELECT * FROM Grezzi WHERE APR = '***'", db)
        cmd.Fill(Table) '= db.OpenRecordset("SELECT * FROM Grezzi WHERE APR = '***'")
        CB = New OleDbCommandBuilder(cmd)
        dvTable = New DataView(Table)
        Dim cmd1 As New OleDbDataAdapter("SELECT * FROM ListaDuplicati", db)
        cmd1.Fill(Dupl)
        Dim dvDupl As New DataView(Dupl)
        For i = 0 To CShort(Table.Rows.Count - 1)
            dvDupl.RowFilter = "IDCampo = " & CStr(Table.Rows(i)("iD")) & "AND APR='" & APR & "'"
            If dvDupl.Count > 0 Then
                dvTable(i).Delete()
                i = -1
            End If
        Next
        Dupl.Dispose()
        Dim n As OggList.NodeP = Apparecchio.Elementi.nodeHead.Next
        While Not n Is Nothing
            g = n.TextData.GenMem
            For j = 0 To g.grezzi.Count() - 1
                drv = dvTable.AddNew()
                ScaricaGrezzo(g.grezzi(j), drv, APR)
                drv.EndEdit()
            Next
            n = n.Next
        End While
        cmd.Update(Table)
        Table.Dispose()
        db.Dispose()
    End Sub
    Public Sub InizGre(ByRef db As OleDbConnection)
        If Not IO.File.Exists(FileGre) Then IO.File.Copy(Monitor.Motore.Inizio.Archdir & "\GREZZI.MDB", FileGre)
        db = New OleDbConnection(Conn & FileGre & ConnFine)
    End Sub
    Public Sub ScaricaGrezzo(ByRef g As clsGrezzo1, ByRef t As DataRowView, ByRef APR As String)
        t("IndRec") = g.IndRec
        t("APR") = APR ' g.APR = "" '    As String  'Distinta
        t("Codice") = g.Vartxt(1)
        t("IndFile") = g.IndFile
        t("Indmat") = g.Indmat 'indice del materiale
        t("NPezzi") = g.NPezzi
        t("Variab1") = g.Variab(1) ' As Single 'variabili essenziali numeriche
        t("Variab2") = g.Variab(2) ' As Single 'variabili essenziali numeriche
        t("Variab3") = g.Variab(3) ' As Single 'variabili essenziali numeriche
        t("Variab4") = g.Variab(4) ' As Single 'variabili essenziali numeriche
        t("Variab5") = g.Variab(5) ' As Single 'variabili essenziali numeriche
        t("Txt2") = g.Vartxt(2) ' As String * 4 'variabili essenziali alfabetiche
        t("Txt3") = g.Vartxt(3) ' As String * 4 'variabili essenziali alfabetiche
        t("Dim1") = g.Dimens(1) ' As Single
        t("Dim2") = g.Dimens(2) ' As Single
        t("Dim3") = g.Dimens(3) ' As Single
        t("Dim4") = g.Dimens(4) ' As Single
    End Sub
    Public Sub StampaDistinta()
        Dim FileSt As String
        Dim Stub As Object = Nothing 'Doc As Word.Document
        Dim O As Membratura
        Dim FileMate As String
        Dim g As clsGenMem
        Dim Form, FormL As String
        Dim db As OleDbConnection
        Dim Table As New DataTable
        Dim cmd As OleDbDataAdapter
        Dim n As OggList.NodeP
        Form = "#####0.0" : FormL = "#####0"
        FileSt = Monitor.Motore.Inizio.Archdir & "\PPSM.DOC"
        Monitor.Motore.Inizio.SuperStampa(FileSt, Stub) ' Doc
        FileSt = FunzLibgra.FileDes("PPSM.DOC")
        Stub.VaiInizio()
        Stub.IntestaGr(job.Comm.Arch, job.Comm.Ind.Item(job.Comm.NumAs).Data.Assieme)
        Stub.VaiInizio("Start")
        With Stub 'Selection
            n = Apparecchio.Elementi.nodeHead.Next
            While Not n Is Nothing
                O = n.TextData
                g = O.GenMem
                If g.PosDis > 0 And Not g.Tipo = 26 Then
                    .TastoTab() '.MuoviCella 1
                    .Testo(g.PosDis)
                    .TastoTab() '.MuoviCella 1
                    .Testo(Trim(g.Denom))
                    .TastoTab() '.MuoviCella 1
                    .Testo(g.Qta)
                    .TastoTab() '.MuoviCella 1
                    .Testo(Trim(g.Materiale))
                    .TastoTab() '.MuoviCella 1
                    .Testo(Trim(g.Dimensioni))
                    .TastoTab() '.MuoviCella 1
                    .Testo(Trim(g.Note))
                    .TastoTab() '.MuoviCella 1
                    .Testo(g.MF)
                    .TastoTab() '.MuoviCella 1
                    .Testo(Microsoft.VisualBasic.Strings.Format(g.LireLETot, FormL))
                    .TastoTab() '.MuoviCella 1
                    .Testo(Microsoft.VisualBasic.Strings.Format(g.PNET, Form))
                    .TastoTab() '.MuoviCella 1
                    .Testo(Microsoft.VisualBasic.Strings.Format(g.plor0, Form))
                    .TastoTab() '.MuoviCella 1
                    .Testo(Microsoft.VisualBasic.Strings.Format(g.LireKg1, FormL))
                    .TastoTab() '.MuoviCella 1
                    .Testo(Microsoft.VisualBasic.Strings.Format(g.LireTot / 1000000.0#, Form))
                End If
                n = n.Next
            End While
            Apparecchio.BaricGen()
            .TastoTab()
            .MuoviCella(1)
            .Testo("TOTALE")
            .MuoviCella(7)
            .Testo(Microsoft.VisualBasic.Strings.Format(Apparecchio.peso, Form))
            .MuoviCella(3)
            .Testo(Microsoft.VisualBasic.Strings.Format(Apparecchio.CostoMat / 1000000.0#, Form))
        End With
        FileMate = Monitor.Motore.MatFile
        If Len(FileMate) = 0 Then
            MsgBox("Database materiali non trovato")
            Exit Sub
        End If
        db = New OleDbConnection(Conn & FileMate & ConnFine) ' Funzioni.MyWorkspace.OpenDatabase(FileMate, False, True)
        cmd = New OleDbDataAdapter("SELECT * FROM LavorEst ORDER BY Codice", db)
        cmd.Fill(Table)
        Stub.VaiInizio("Descr")
        With Stub 'Selection
            For i = 0 To Table.Rows.Count - 1
                .TastoTab() '.MuoviCella 1
                .Testo(Table.Rows(i)("Codice"))
                .TastoTab() '.MuoviCella 1
                .Testo(Table.Rows(i)("Descrizione"))
            Next
        End With
        Table.Dispose()
        db.Close()
        Stub.sClose()
        'ErrCD:
        '        Testo = "Impossibile salvare il documento Word " & FileSt & "." & vbCrLf
        '        Testo = Testo & "E' possibile che esso sia già aperto in WinWord." & vbCrLf
        '        Testo = Testo & "In tal caso attivare WinWord, chiudere il documento e poi riprovare."
        '        Select Case MsgBox(Testo, MsgBoxStyle.RetryCancel + MsgBoxStyle.Information, "PPSM")
        '            Case MsgBoxResult.Retry : Resume
        '            Case MsgBoxResult.Cancel : Resume ExClose
        '        End Select
    End Sub
    Public Function LeggiFlanBase(ByVal k As Short, ByVal TabFlan As Short, ByVal iDiam As Short, ByVal iRat As Short, ByVal iTipo As Short) As Single
        'k=16 pnet k=17 plor
        Static dv, CatView As DataView
        Static dr As DataRowView()
        Static v1, v2, v3, v4 As Short
        If v1 - TabFlan <> 0 Or v2 - iDiam <> 0 Or v3 - iRat <> 0 Or v4 - iTipo <> 0 Then
            If FormFlangia Is Nothing Then FormFlangia = New frmFlange 'allo scopo di IniziaBase
            dv = New DataView(FormFlangia.dsFlange.Tabelle)
            dv.Sort = "Codice"
            dr = dv.FindRows(TabFlan.ToString)
            CatView = New DataView(FormFlangia.dsFlange.Query1)
            CatView.RowFilter = "Tabella=" & TabFlan.ToString & _
                                " AND indDiametro =" & Str(iDiam) & _
                                " AND indRating=" & Str(iRat) & _
                                " AND indTipo=" & Str(iTipo)
        End If
        LeggiFlanBase = 0
        v1 = TabFlan
        v2 = iDiam
        v3 = iRat
        v4 = iTipo
        If CatView.Count = 0 Then
        ElseIf CatView.Count > 1 Then
            MsgBox("impossibile in LeggiFlanBase")
        Else
            Select Case k
                Case 16
                    LeggiFlanBase = CSng(CatView(0).Item("Pesonet"))
                Case 17
                    LeggiFlanBase = CSng(CatView(0).Item("Pesolor"))
            End Select
            LeggiFlanBase = CSng(CatView(0).Item(k + 3))
        End If
    End Function
    Public Sub Intersezioni(ByRef Rec As clsGenMem, ByRef Recordv As clsGenMem)
        Dim isW As Short
        Intersect(Rec, Recordv, isW)
        If isW = 1 Then
            Call CercaForoS(Rec, Recordv)
        Else
            If isW = 2 Then Call CercaForoS(Recordv, Rec)
        End If
    End Sub
    Public Function CheckSetti() As Boolean
        Dim O As Membratura
        Dim n As OggList.NodeP = Apparecchio.Elementi.nodeHead.Next
        While Not n Is Nothing
            O = n.TextData
            If O.GenMem.Tipo = 26 Then
                CheckSetti = True
                Exit Function
            End If
            n = n.Next
        End While
        MostraAiuto(IDHG.IDH_ERR_NOFASCIO)
    End Function
    Public Function MostraAiuto(ByRef iD As Integer, Optional ByRef Informa As Integer = ChiaviMess.MessCritical + ChiaviMess.MessOkOnly, Optional ByRef mioTesto As String = "", Optional ByRef mioTitolo As String = "") As Integer
        Dim Testo, Tit As String
        On Error GoTo ErrAiuto
        If iD > 0 Then
            If Len(mioTesto) = 0 Then
                Testo = Monitor.Motore.Inizio.ConvertiCr(HelpStringa(iD)) ' "Il gruppo di items da montare su ventilatore a comune non è stato definito correttamente"
            Else
                Testo = Monitor.Motore.Inizio.ConvertiCr(mioTesto)
            End If
            If Len(mioTitolo) = 0 Then
                Tit = "PPSM - Messaggi di errore"
                If Not Informa And ChiaviMess.MessCritical Then Tit = "PPSM"
            Else
                Tit = mioTitolo
            End If
            MostraAiuto = Monitor.Motore.Messaggio(Testo, Informa + ChiaviMess.MessHelpButton, Tit, RadiceHelp, iD)
        Else
            MsgBox("Errore sconosciuto", MsgBoxStyle.Information, "PPSM")
        End If
        Exit Function
ExAiuto:
        MsgBox(Testo, MsgBoxStyle.Critical, "PPSM")
        Exit Function
ErrAiuto:
        Testo = Err.Description
        Resume ExAiuto
    End Function
    Public Sub CercaFondo(ByRef Cassa As Cilindro, ByRef PT As Piastrone, ByRef Fondo As Fondo, ByRef Coperchio As Piastrone)
        Dim o1, O, o2 As Membratura
        Dim Guarn As clsGuarniz
        Dim Fl1 As Flangione
        Dim nn1, nn2 As OggList.NodeP
        Dim n As OggList.NodeP = Apparecchio.Elementi.nodeHead.Next
        While Not n Is Nothing
            O = n.TextData
            If O.GenMem.posizione.SuChi Is Cassa Or Cassa.GenMem.posizione.SuChi Is O Then
                Select Case O.GenMem.Tipo
                    Case 3, 4, 5
                        Fondo = O
                        Exit Sub
                    Case 11
                        Fl1 = O
                        nn1 = Apparecchio.Elementi.nodeHead.Next
                        While Not nn1 Is Nothing
                            o1 = nn1.TextData
                            If (o1.GenMem.posizione.SuChi Is Fl1) Or (Fl1.GenMem.posizione.SuChi Is o1) Then
                                If o1.GenMem.Tipo = 28 Then
                                    Guarn = o1
                                    nn2 = Apparecchio.Elementi.nodeHead.Next
                                    While Not nn2 Is Nothing
                                        o2 = nn2.TextData
                                        If (o2.GenMem.posizione.SuChi Is Guarn) Or (Guarn.GenMem.posizione.SuChi Is o2) Then
                                            If o2.GenMem.Tipo = 12 And Not o2 Is PT Then
                                                Coperchio = o2
                                                Exit Sub
                                            End If
                                        End If
                                        nn2 = nn2.Next
                                    End While
                                End If
                            End If
                            nn1 = nn1.Next
                        End While
                End Select
            End If
            n = n.Next
        End While
        MsgBox("Errore CercaFondo")
    End Sub

    Public Function PreparaProto() As Boolean
        Dim NomeDis As String
        Dim dis As AutoCAD.AcadDocument = Nothing
        Dim App As AutoCAD.AcadApplication = Nothing
        Dim sset As AutoCAD.AcadSelectionSet = Nothing
        Dim entity() As AutoCAD.AcadEntity = Nothing
        Dim i As Short
        Dim preferences As AutoCAD.AcadPreferences = Nothing
        Dim W, H As Single
        NomeDis = FunzLibgra.FileDes("DWG")
        PreparaProto = True
        If DisAcad And Not Monitor.AcadDis Is Nothing Then
            On Error GoTo ErrProto
            App = Monitor.AcadDis.Application
            If Not App Is Nothing Then
                For Each dis In App.Documents
                    If NomeDis = dis.FullName Then
                        Monitor.AcadDis = dis
                        Monitor.AcadDis.Activate()
                        PreparaProto = Procedi(entity, preferences, sset, NomeDis)
                        Exit Function
                    End If
                Next dis
            End If
        Else
ResProto:
            On Error GoTo 0
            'UPGRADE_WARNING: Dir ha un nuovo comportamento. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1041"'
            If Len(Dir(NomeDis)) = 0 Then
                MostraAiuto(IDHG.IDH_ERR_NODISEGNO, ChiaviMess.MessInformation)
                'MsgBox "Operazione rifiutata perché non è stato fatto il disegno"
                PreparaProto = False
                Exit Function
            Else
                Inizio.LanciaAutoCAD(dis)
                Monitor.AcadDis = dis
                If Monitor.AcadDis Is Nothing Then
                    PreparaProto = False
                    Exit Function
                End If
                If Not Monitor.AcadDis.FullName = NomeDis Then
                    Monitor.AcadDis.Application.Documents.Open(NomeDis)
                    Monitor.AcadDis = Monitor.AcadDis.Application.ActiveDocument
                End If
                PreparaProto = Procedi(entity, preferences, sset, NomeDis)
            End If
        End If
        Exit Function
ErrProto:
        Monitor.AcadDis = Nothing
        Resume ResProto
    End Function
    Private Function Procedi(ByVal entity() As AutoCAD.AcadEntity, ByVal preferences As AutoCAD.AcadPreferences, _
                        ByVal sset As AutoCAD.AcadSelectionSet, ByVal NomeDis As String) As Boolean
        Dim NomeWMF As String
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        On Error GoTo 0
        ReDim entity(Monitor.AcadDis.ModelSpace.Count - 1)
        preferences = Monitor.AcadDis.Application.Preferences
        If Not System.Drawing.ColorTranslator.FromOle(System.Convert.ToInt32(preferences.Display.GraphicsWinModelBackgrndColor)).Equals(System.Drawing.Color.White) Then preferences.Display.GraphicsWinModelBackgrndColor = System.Convert.ToUInt32(System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White))
        For i = 0 To Monitor.AcadDis.ModelSpace.Count - 1
            entity(i) = Monitor.AcadDis.ModelSpace.Item(i)
        Next
        On Error Resume Next
        sset = Monitor.AcadDis.SelectionSets.Item("Tutto")
        If Not sset Is Nothing Then sset.Delete()
        On Error GoTo 0
        sset = Monitor.AcadDis.SelectionSets.Add("Tutto")
        sset.AddItems(entity)
        NomeWMF = Left(NomeDis, Len(NomeDis) - 4)
        Monitor.AcadDis.Export(NomeWMF, "WMF", sset)
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        NomeWMF = NomeWMF & ".WMF"
        With frmWMF.DefInstance.pctIn
            .SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
            .Image = System.Drawing.Image.FromFile(NomeWMF)
            W = .Width
            H = .Height
            .SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
            .Width = frmWMF.DefInstance.Width - .Left - GlobalRoutines.TwipsToPixelsX(200)
            .Height = .Width * H / W
        End With
        frmWMF.DefInstance.ShowDialog()
        Procedi = Not frmWMF.DefInstance.Cancel
        frmWMF.DefInstance.Dispose()
    End Function
    Public Sub CopiaSP(ByRef SPvc As Spicchi, ByRef SPc As Spicchi)
        Dim i, ii As Short
        Dim s As Spicchio4
        For i = 0 To 6
            SPvc.SP(i).Rettn.copia(SPc.SP(i).Rettn)
            SPc.SP(i).Nspicchi = SPvc.SP(i).Nspicchi
            SPc.SP(i).Nquadri = SPvc.SP(i).Nquadri
            SPc.SP(i).peso = SPvc.SP(i).peso
            For ii = 1 To SPvc.SP(i).Nspicchi
                s = New Spicchio4
                SPvc.SP(i + 1).LamSp(ii - 1).Copia(s)
                SPc.SP(i + 1).LamSp.Add(s)
            Next
        Next
    End Sub
    Public Sub copiaCollSp(ByRef Lv As OggList, ByRef l As OggList)
        Dim s As Spicchio4
        Dim i As Short
        For i = 0 To Lv.Count - 1
            s = New Spicchio4
            Lv(i).Copia(s)
            l.Add(s)
        Next
    End Sub
    'Public Sub IniziaSP(ByRef SP As Collection)
    '		Dim Rettn As RoutBase1.Rettangolo
    '		Dim LamSp As Collection
    '		Dim i As Short
    '		Dim n(6) As Short
    '		Dim Nq(6) As Short
    '		Dim p(6) As Single
    '		For i = 0 To 6
    '			Rettn = New RoutBase1.Rettangolo
    '			LamSp = New Collection
    '			SP.Add(LamSp)
    '			LamSp = New Collection
    '			'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto SP().Add. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
    '			SP.Item(i + 1).Add(Rettn, Rett)
    '			'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto SP().Add. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
    '			SP.Item(i + 1).Add(LamSp, Spicchi)
    '			'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto SP().Add. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
    '			SP.Item(i + 1).Add(n(i), NSpicchi)
    '			'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto SP().Add. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
    '			SP.Item(i + 1).Add(p(i), peso)
    '			'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto SP().Add. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
    '			SP.Item(i + 1).Add(Nq(i), Nquadri)
    '		Next 
    '	End Sub

    Public Sub PostPos(ByRef Record As clsGenMem, ByRef Recordv As clsGenMem)
        Select Case System.Math.Abs(Recordv.Tipo) '1
            Case 1 'su cilindri
                Select Case System.Math.Abs(Record.Tipo)
                    Case 5 'fondi sferici
                        Fondo = Record.Parent
                        If Fondo.Piedritto = 0 Then Exit Sub
                        Cil = Recordv.Parent
                        NearFar = Left(Fondo.GenMem.posizione.Quota, 2) = "Ne"
                        DiamFon = Int(2 * System.Math.Sqrt(Cil.Diametro ^ 2 / 4 + Fondo.Piedritto ^ 2))
                        DiamCil = Int(Cil.Diametro)
                        If DiamFon <> Int(Fondo.Diametro) Then
                            Testo = "Il diametro del fondo (" & Str(Int(Fondo.Diametro)) & ") non è compatibile" & vbCrLf
                            Testo = Testo & "con il diametro del cilindro (" & Str(DiamCil) & "). Il valore " & vbCrLf
                            Testo = Testo & "è" & Str(DiamFon) & ". Accetti la proposta?"
                            Risp = MsgBox(Testo, MsgBoxStyle.Question + MsgBoxStyle.YesNo)
                            If Risp = MsgBoxResult.Yes Then
                                Fondo.Diametro = DiamFon
                            Else
                                Exit Sub
                            End If
                        End If
                        Rastrem()
                End Select
            Case 5 'su fondi sferici
                Select Case System.Math.Abs(Record.Tipo)
                    Case 1 'cilindri
                        Fondo = Recordv.Parent
                        If Fondo.Piedritto = 0 Then Exit Sub
                        Cil = Record.Parent
                        NearFar = True
                        DiamCil = Int(2 * System.Math.Sqrt(Fondo.Diametro ^ 2 / 4 - Fondo.Piedritto ^ 2))
                        DiamFon = Int(Fondo.Diametro)
                        If DiamCil <> Int(Cil.Diametro) Then
                            Testo = "Il diametro del cilindro (" & Str(Int(Cil.Diametro)) & ") non è compatibile" & vbCrLf
                            Testo = Testo & "con il diametro del fondo (" & Str(DiamFon) & "). Il valore " & vbCrLf
                            Testo = Testo & "è" & Str(DiamCil) & ". Accetti la proposta?"
                            Risp = MsgBox(Testo, MsgBoxStyle.Question + MsgBoxStyle.YesNo)
                            If Risp = MsgBoxResult.Yes Then
                                Cil.Diametro = DiamCil
                            Else
                                Exit Sub
                            End If
                        End If
                        Rastrem()
                End Select
        End Select
    End Sub
    Private Sub Rastrem()
        Alfa = GlobalRoutines.acos(DiamCil / DiamFon)
        bRastr = Int(Cil.Spessore - Fondo.Spessore * System.Math.Cos(Alfa))
        hRastr = Int(bRastr / System.Math.Tan(Alfa))
        If NearFar Then
            Cil.Hnear = hRastr
            Cil.Tnear = Cil.Spessore - bRastr
        Else
            Cil.Hfar = hRastr
            Cil.Tfar = Cil.Spessore - bRastr
        End If

    End Sub
    Public Function RandaPossibile(ByRef Oggetto As Membratura) As Boolean
        Dim Ogg4 As Membratura
        Try
            Ogg4 = CType(Oggetto.GenMem, clsGenMem).posizione.SuChi
            If Ogg4 Is Nothing Then Exit Function
            Select Case System.Math.Abs(CType(Ogg4.GenMem, clsGenMem).Tipo)
                Case 1, 2
                    If Val(CType(Oggetto.GenMem, clsGenMem).posizione.Quota) <= 0 Then Exit Function
                Case 3, 4, 5
                    If Left(CType(Oggetto.GenMem, clsGenMem).posizione.Quota, 2) = "Ne" Then Exit Function
                Case Else
                    Return False
            End Select
            RandaPossibile = True
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Function
    Public Sub DisCurva(ByRef Oggetto As Curva)
        Select Case Oggetto.TipoS
            Case 0 : Call DisCurvaG(Oggetto)
            Case 1 : Call DisCurvaS(Oggetto)
        End Select
    End Sub
    Public Sub DisCurvaG(ByRef Oggetto As Curva)
        posspa = Oggetto.GenMem.SwappedPos
        If IUNL = 0 Then
            MsgBox("DisCurvaG: IUNL=0")
        End If
        Direzione.X = 0 : Direzione.y = 0 : Direzione.Z = 1
        prod = posspa.CosTraversa.ProdScalar(Direzione)
        Verso = posspa.Origine.Z
        If System.Math.Abs(prod) < TOLER Then
            SezLunD(Oggetto)
        Else
            SezRettD(Oggetto)
        End If
    End Sub
    Private Sub SpotCur1(ByVal Oggetto As Curva)
        Spots = New spot
        Spots.Tipo = 1
        Spots.Quota = Verso
        With Oggetto
            Spots.Quadro.TopLeft.X = x1 - .Diametro / 2 - .Spessore
            Spots.Quadro.TopLeft.y = y1 - .Diametro / 2 + .Spessore
            Spots.Quadro.Botrigt.X = x2 + .Diametro / 2 + .Spessore
            Spots.Quadro.Botrigt.y = y2 + .Diametro / 2 - .Spessore
        End With
        RegisterSpot(Spots, Oggetto)
    End Sub
    Private Sub SpotCur(ByVal Oggetto As Curva)
        Spots = New spot
        Spots.Tipo = 2
        Spots.Quota = Verso
        Spots.spicchio.Origin.X = xc
        Spots.spicchio.Origin.y = yc
        With Oggetto
            Spots.spicchio.RG = .Raggio + .Diametro / 2
            Spots.spicchio.RP = .Raggio - .Diametro / 2
            Spots.spicchio.Alfa = .Apertura * PI / 180
            RegisterSpot(Spots, Oggetto)
        End With
    End Sub
    Private Sub SezLunD(ByVal Oggetto As Curva)
        With Oggetto
            If Verso < -.Diametro / 2 Then Exit Sub
            xc = posspa.Origine.X + posspa.CosTraversa.X * .Raggio
            yc = posspa.Origine.y + posspa.CosTraversa.y * .Raggio
            If IUNL = 4 Then
                SpotCur(Oggetto)
                Exit Sub
            End If
            SP = New Spicchio4
            SP.Origin.X = xc
            SP.Origin.y = yc
            Dir1.X = -posspa.CosTraversa.X
            Dir1.y = -posspa.CosTraversa.y
            Alfa = GlobalRoutines.arco((Dir1.X), (Dir1.y))
            prod = posspa.CosTraversa.ProdTripl((posspa.CosDiritta), Direzione)
            Alfa1 = Alfa - System.Math.Sign(prod) * .Apertura * PI / 180 / 2
            Dir2.X = System.Math.Cos(Alfa1)
            Dir2.y = System.Math.Sin(Alfa1)
            Dir1.X = posspa.CosDiritta.X
            Dir1.y = posspa.CosDiritta.y
            prod = Dir1.X * Dir2.X + Dir1.y * Dir2.y
            If prod < 0 Then
                Alfa1 = Alfa + .Apertura * PI / 180 / 2
                Dir2.X = System.Math.Cos(Alfa1)
                Dir2.y = System.Math.Sin(Alfa1)
            End If
            SP.Direct.X = Dir2.X
            SP.Direct.y = Dir2.y
            SP.Alfa = .Apertura * PI / 180
            If Verso > .Diametro / 2 Then 'curva in vista
                Call Infilata(Oggetto, Verso, InMezzo)
                If InMezzo > 1 Then Exit Sub
                If InMezzo = 1 Then Call Funzioni.DisRut.ctrait(3, 0.1) Else Call Funzioni.DisRut.ctrait(0, 0.1)
                SP.RG = .Raggio + .Diametro / 2
                SP.RP = .Raggio - .Diametro / 2
                SP.SpicGraf(2, Punti0, Punti1)
            Else
                SP.RG = .Raggio + .Diametro / 2
                SP.RP = SP.RG - .Spessore
                SP.SpicGraf(2, Punti0, Punti1)
                SP.RP = .Raggio - .Diametro / 2
                SP.RG = SP.RP + .Spessore
                SP.SpicGraf(2, Punti0, Punti1)
            End If
        End With
    End Sub
    Private Sub SezRettD(ByVal Oggetto As Curva)
        With Oggetto
            x1 = posspa.Origine.X
            y1 = posspa.Origine.y
            z1 = posspa.Origine.Z
            corda = 2 * .Raggio * System.Math.Sin(.Apertura * PI / 180 / 2)
            Quota = corda * System.Math.Cos((90 - (180 - .Apertura) / 2) * PI / 180)
            Raggio = corda * System.Math.Sin((90 - (180 - .Apertura) / 2) * PI / 180)
            x2 = x1 + Quota * posspa.CosDiritta.X + Raggio * posspa.CosTraversa.X
            y2 = y1 + Quota * posspa.CosDiritta.y + Raggio * posspa.CosTraversa.y
            z2 = z1 + Quota * posspa.CosDiritta.Z + Raggio * posspa.CosTraversa.Z
            If z1 < 0 And z2 < 0 Then Exit Sub
            Verso = (z1 + z2) / 2
            If IUNL = 4 Then
                SpotCur1(Oggetto)
                Exit Sub
            End If
            If z1 > 0 And z2 > 0 Then
                Call Infilata(Oggetto, Verso, InMezzo)
                If InMezzo > 1 Then Exit Sub
                If InMezzo = 1 Then Call Funzioni.DisRut.ctrait(3, 0.1) Else Call Funzioni.DisRut.ctrait(0, 0.1)
            End If
            Funzioni.DisRut.cerc(x1, y1, .Diametro / 2 + .Spessore)
            Punti0 = New RoutBase1.clsPunti
            Punti0.Inizia(4)
            Punti0.Punti0(0).X = x1 - (.Diametro / 2 + .Spessore) * posspa.CosTerza.X
            Punti0.Punti0(0).y = y1 - (.Diametro / 2 + .Spessore) * posspa.CosTerza.y
            Punti0.Punti0(1).X = x2 - (.Diametro / 2 + .Spessore) * posspa.CosTerza.X
            Punti0.Punti0(1).y = y2 - (.Diametro / 2 + .Spessore) * posspa.CosTerza.y
            Punti0.Punti0(2).X = x2 + (.Diametro / 2 + .Spessore) * posspa.CosTerza.X
            Punti0.Punti0(2).y = y2 + (.Diametro / 2 + .Spessore) * posspa.CosTerza.y
            Punti0.Punti0(3).X = x1 + (.Diametro / 2 + .Spessore) * posspa.CosTerza.X
            Punti0.Punti0(3).y = y1 + (.Diametro / 2 + .Spessore) * posspa.CosTerza.y
            Punti0.SpezzGraf(0, 3, Funzioni.DisRut)
        End With
    End Sub
    Public Sub DisCurvaS(ByRef Oggetto As Curva)
        'curve a spicchi
        MsgBox("DisCurvaS")
    End Sub
    Public Sub CercaFlangioni(ByRef p As Piastrone, ByRef Fl1 As Flangione, ByRef Fl2 As Flangione)
        Dim g1 As clsGuarniz
        Dim g2 As New clsGuarniz
        Dim g As clsGenMem
        Dim O As Membratura
        Dim n As OggList.NodeP
        O = p.GenMem.posizione.SuChi
        If O Is Nothing Then Exit Sub
        If Not O.GenMem.Tipo = 28 Then
            g1 = Nothing
        Else
            g1 = O
        End If
        n = Apparecchio.Elementi.nodeHead.Next
        While Not n Is Nothing
            g = n.TextData.GenMem
            If g.Tipo = 28 And g.posizione.SuChi Is p Then
                If g1 Is Nothing Then
                    g1 = g.Parent
                Else
                    If Not g.Parent Is g1 Then
                        g2 = g.Parent
                        Exit While
                    End If
                End If
            End If
            n = n.Next
        End While
        O = g1.GenMem.posizione.SuChi
        If O.GenMem.Tipo = 11 Then
            Fl1 = O
        Else
            n = Apparecchio.Elementi.nodeHead.Next
            While Not n Is Nothing
                If n.TextData.GenMem.posizione.SuChi Is g1 Then
                    If n.TextData.GenMem.Tipo = 11 Then
                        Fl1 = n.TextData
                        Exit While
                    End If
                End If
                n = n.Next
            End While
        End If
        O = g2.GenMem.posizione.SuChi
        If O.GenMem.Tipo = 11 Then
            Fl2 = O
        Else
            n = Apparecchio.Elementi.nodeHead.Next
            While Not n Is Nothing
                If n.TextData.GenMem.posizione.SuChi Is g2 Then
                    If n.TextData.GenMem.Tipo = 11 Then
                        Fl2 = n.TextData
                        Exit While
                    End If
                End If
                n = n.Next
            End While
        End If
    End Sub
    Public Sub SuperIntersezioni(ByRef Rec As clsGenMem)
        Dim O As Membratura
        Dim RecSopra As clsGenMem
        Dim n As OggList.NodeP = Apparecchio.Elementi.nodeHead.Next
        While Not n Is Nothing
            O = n.TextData
            RecSopra = O.GenMem
            If RecSopra.Tipo < 97 Then
                If RecSopra.posizione.SuChi Is Rec.Parent Then
                    Intersezioni(RecSopra, Rec)
                    If RecSopra.Tipo = 26 Then Intersezioni(CType(RecSopra.Parent, Fascio).Tubi_Renamed.GenMem, Rec)
                End If
            End If
            n = n.Next
        End While
    End Sub
    Public Function IndiceDS(ByRef g As clsGenMem) As Short
        Dim Indexx, m As Short
        Indexx = -1
        m = System.Math.Abs(g.Tipo)
        Select Case m
            Case 1, 3, 4, 5 'cilindri
                Select Case g.Lato
                    Case 0, 1 : Indexx = 1
                    Case 2 : Indexx = 2
                End Select
            Case 2, 21
                Select Case g.Lato
                    Case 0, 1 : Indexx = 15
                    Case 2 : Indexx = 12
                End Select
            Case 6, 7
                If CType(g.Parent, Cono).Fitting Then
                    Select Case g.Lato
                        Case 0, 1 : Indexx = 15
                        Case 2 : Indexx = 12
                    End Select
                Else
                    Select Case g.Lato
                        Case 0, 1 : Indexx = 1
                        Case 2 : Indexx = 2
                    End Select
                End If
            Case 10, 14
                Select Case g.Lato
                    Case 0, 1 : Indexx = 16
                    Case 2 : Indexx = 13
                    Case 3 : Indexx = -1
                End Select
            Case 11
                Select Case g.Lato
                    Case 0, 1 : Indexx = 17
                    Case 2 : Indexx = 18
                    Case 3 : Indexx = -1
                End Select
            Case 12 'PT
                Select Case g.Lato
                    Case 0, 1 : Indexx = -1
                    Case 2 : Indexx = 3
                    Case 3 : Indexx = 7
                End Select
            Case 13 'tiranti
                Select Case g.Lato
                    Case 0, 1 : Indexx = 20
                    Case 2 : Indexx = 21
                    Case 3 : Indexx = -1
                End Select
            Case 18 'dilat
                Select Case g.Lato
                    Case 0, 1 : Indexx = 5
                    Case 2 : Indexx = -1
                    Case 3 : Indexx = -1
                End Select
            Case 19
                Select Case g.Lato
                    Case 0, 1 : Indexx = 8
                    Case 2 : Indexx = -1
                    Case 3 : Indexx = -1
                End Select
            Case 25 'sella
                Select Case g.Lato
                    Case 4 : Indexx = 26
                End Select
            Case 28 'guarniz
                Select Case g.Lato
                    Case 0, 1 : Indexx = 22
                    Case 2 : Indexx = 23
                    Case 3 : Indexx = -1
                End Select
            Case 26 'fasci
                Indexx = 0
            Case 8, 9
                Indexx = 0
        End Select
        IndiceDS = Indexx
    End Function

    Public Function AccordoDS(ByRef g As clsGenMem) As Boolean
        Dim Index1, Indexx, Index2 As Short
        Dim IndMat2, Indmat1, IndMat3 As Short
        Dim Matstr2, Matstr1, Matstr3 As String
        Dim lMatstr2, lMatstr1, lMatstr3 As String
        Dim Mat As LibMat.MaterialeNew1
        Dim gIndMat1 As Short
        If IUNL = 5 Then Exit Function
        Indexx = IndiceDS(g)
        'Indexx = 20
        If Indexx = -1 Then Exit Function
        Index1 = Indexx \ 7
        Index2 = Indexx Mod 7
        Indmat1 = DataSheet.DatiS1(Index1).MateInform(Index2).Ind1
        IndMat2 = DataSheet.DatiS1(Index1).MateInform(Index2).Ind2
        IndMat3 = DataSheet.DatiS1(Index1).MateInform(Index2).Ind3
        If Indmat1 = 0 Then Exit Function
        gIndMat1 = g.Indmat1
        If g.Tipo = 26 Then gIndMat1 = CType(g.Parent, Tubi).GenMem.Indmat1
        If Indmat1 = gIndMat1 And IndMat2 = g.IndMat2 And IndMat2 = g.IndMat2 Then Exit Function
        Mat = New LibMat.MaterialeNew1
        Mat.Indmat = Indmat1
        Mat.Zitto = True
        Mat.RecupMat("")
        Matstr1 = Mat.MatStr
        If IndMat2 > 0 Then
            Mat.Indmat = IndMat2
            Mat.RecupMat("")
            Matstr2 = Mat.MatStr
        Else
            Matstr2 = "nessuno"
        End If
        If IndMat3 > 0 Then
            Mat.Indmat = IndMat3
            Mat.RecupMat("")
            Matstr3 = Mat.MatStr
        Else
            Matstr3 = "nessuno"
        End If
        If gIndMat1 > 0 Then
            Mat.Indmat = gIndMat1
            Mat.RecupMat("")
            lMatstr1 = Mat.MatStr
        Else
            lMatstr1 = "nessuno"
        End If
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto g.Parent.TipoMat. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
        If g.Parent.TipoMat > 1 Then
            If g.IndMat2 > 0 Then
                Mat.Indmat = g.IndMat2
                Mat.RecupMat("")
                lMatstr2 = Mat.MatStr
            Else
                lMatstr2 = "nessuno"
            End If
            If g.IndMat3 > 0 Then
                Mat.Indmat = g.IndMat3
                Mat.RecupMat("")
                lMatstr3 = Mat.MatStr
            Else
                lMatstr3 = "nessuno"
            End If
        Else
            g.IndMat2 = 0
            g.IndMat3 = 0
            lMatstr2 = "nessuno"
            lMatstr3 = "nessuno"
        End If
        'UPGRADE_NOTE: È possibile che l'oggetto Mat non venga eliminato finché non venga raccolto nel Garbage Collector. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1029"'
        'Mat = Nothing
        With frmMatDS.DefInstance
            .Label3.Text = g.Denom
            .Text1(0).Text = lMatstr1
            .Text1(5).Text = Matstr1
            If lMatstr2 = "nessuno" And Matstr2 = "nessuno" Then
                .Text1(1).Visible = False
                .Text1(4).Visible = False
                .Label2(1).Visible = False
                .Label2(4).Visible = False
            Else
                .Text1(1).Text = lMatstr2
                .Text1(4).Text = Matstr2
            End If
            If lMatstr3 = "nessuno" And Matstr3 = "nessuno" Then
                .Text1(2).Visible = False
                .Text1(3).Visible = False
                .Label2(2).Visible = False
                .Label2(3).Visible = False
            Else
                .Text1(2).Text = lMatstr3
                .Text1(3).Text = Matstr3
            End If
            .ShowDialog()
            If .OK Then
                If g.Tipo = 26 Then
                    CType(g.Parent, Fascio).Tubi_Renamed.GenMem.Indmat1 = Indmat1
                Else
                    g.Indmat1 = Indmat1
                End If
                g.IndMat2 = IndMat2
                g.IndMat3 = IndMat3
                AccordoDS = True
            End If
        End With
        frmMatDS.DefInstance.Dispose()
    End Function
    Public Sub ScriviPref()
        Dim SiNo As String
        With Monitor.Motore.Inizio
            If AggiornamentoAutomatico Then SiNo = "Si" Else SiNo = "No"
            .WriteIniFile("", SezPref, "AggiornamentoAutomatico", SiNo)
            If Verboso Then SiNo = "Si" Else SiNo = "No"
            .WriteIniFile("", SezPref, "Verboso", SiNo)
        End With
    End Sub
    Public Sub LeggiPrefGen()
        With Monitor.Motore.Inizio
            AggiornamentoAutomatico = (.ReadIniFile("", SezPref, "AggiornamentoAutomatico") = "Si")
            Verboso = (.ReadIniFile("", SezPref, "Verboso") = "Si")
        End With
    End Sub
    Public Sub ForLam(ByRef RG As Single, ByRef RP As Single, ByRef Alfa As Single, ByRef TAGLIO As Single, _
                      ByRef n As Single, ByRef LaMAX As Short, ByRef LMAX As Short, ByRef Nrisp As Short, _
                      ByRef SP As SpicLam, ByRef Tipo As Short)
        Try
            Select Case Tipo
                Case 1
                    Nrisp = 2
                    A = RP * 2 * System.Math.Sin(Alfa / 2)
                    x = System.Math.Sqrt(A * A + CSng(RG) * RG - 2 * A * RG * System.Math.Cos((PI + Alfa) / 2))
                    gamma = GlobalRoutines.asin(RG / x * System.Math.Sin((PI + Alfa) / 2))
                    phi = GlobalRoutines.asin(RG / x)
                    Beta = phi - gamma
                    cosa = System.Math.Cos(Alfa / 2 - Beta)
                    AB = 2 * RG - (RG + RP) * cosa
                    Iniz = RG * System.Math.Sin(Alfa / 2 + Beta)
                    AC = (RG + RP) * System.Math.Sin(Alfa / 2 - Beta) + 2 * Iniz
                    fact = 1 + 1 / cosa ': IF fact < 3 THEN fact = 3
                    LLun = Int(AC + fact * TAGLIO)
                    LCor = Int(AB + TAGLIO)
                    If Alfa / 2 + Beta > PI / 2 Then Nrisp = 0 : Exit Sub 'sp(NSpicchi)=0
                    SpAggior(Nrisp, SP)
                    SP.LamSp(1 - 1).Origin.y = Iniz + fact * TAGLIO / 2
                    SP.LamSp(2 - 1).Origin.y = LLun - Iniz - fact * TAGLIO / 2
                    SP.LamSp(1 - 1).Origin.X = AB / 2 + RP * System.Math.Cos(Alfa / 2 + Beta) - TAGLIO / 2
                    SP.LamSp(2 - 1).Origin.X = -SP.LamSp(1).Origin.X
                    SP.LamSp(1 - 1).Direct.X = -System.Math.Cos(Beta)
                    SP.LamSp(1 - 1).Direct.y = -System.Math.Sin(Beta)
                    SP.LamSp(2 - 1).Direct.X = -SP.LamSp(1).Direct.X
                    SP.LamSp(2 - 1).Direct.y = -SP.LamSp(1).Direct.y
                    For i = 1 To Nrisp
                        SP.LamSp(i - 1).RG = RG
                        SP.LamSp(i - 1).RP = RP
                        SP.LamSp(i - 1).Alfa = Alfa
                    Next i
                    If SP.Rettn.LARG > SP.Rettn.Lung Then Rota90(SP)
                    If SP.Rettn.LARG < LaMAX And SP.Rettn.Lung < LMAX Then Exit Sub
                    '   SP.Remove(NSpicchi)
                    '   SP.Add(0, NSpicchi)
                Case 2
16:                 Nrisp = n
                    If Nrisp > 12 Then Nrisp = 12
21:                 cosa = System.Math.Cos(Alfa / 2)
22:                 AC = (RG * System.Math.Sin(Alfa / 2)) * 2
23:                 cosb = System.Math.Sqrt(1 - (RP / RG * System.Math.Sin(Alfa / 2)) ^ 2)
                    Passo = RG * cosb - RP * cosa + TAGLIO
                    AB = RG - RP * cosa - Passo + TAGLIO
                    Iniz = -RP * cosa + TAGLIO / 2
                    LCor = Int(AC) + TAGLIO
                    Do
                        AB = AB + Passo
                        LLun = Int(AB)
                        Nrisp = Nrisp - 1
                    Loop While LLun + Passo < LMAX And Nrisp > 0
                    Nrisp = n - Nrisp
                    SpAggior(Nrisp, SP)
                    SP.LamSp(1 - 1).Origin.y = Iniz
                    For i = 1 To Nrisp
                        SP.LamSp(i - 1).RG = RG
                        SP.LamSp(i - 1).RP = RP
                        SP.LamSp(i - 1).Alfa = Alfa
                        SP.LamSp(i - 1).Origin.X = 0
                        If i > 1 Then SP.LamSp(i - 1).Origin.y = SP.LamSp(i - 2).Origin.y + Passo
                        SP.LamSp(i - 1).Direct.X = 0
                        SP.LamSp(i - 1).Direct.y = 1
                    Next i
                    If SP.Rettn.LARG > SP.Rettn.Lung Then Rota90(SP)
                    If SP.Rettn.LARG < LaMAX And SP.Rettn.Lung < LMAX Then Exit Sub
                    'SP.Remove(NSpicchi)
                    'SP.Add(0, NSpicchi)
                Case 3
                    Nrisp = 2
                    If Alfa > PI / 2 Then
                        AB = RG
                        LCor = AB + TAGLIO
190:                    If System.Math.Sin(Alfa) < 0.5 Then
                            AC = (2 + System.Math.Sqrt(3)) * RG
                            LLun = Int(AC + 2 * TAGLIO)
                        Else
                            AC = 2 * RG + RG * System.Math.Tan(Alfa - PI / 2)
                            LLun = Int(AC + (1 + 1.0! / System.Math.Sin(Alfa)) * TAGLIO)
                        End If
                    Else
191:                    AB = RG * System.Math.Sin(Alfa)
                        AC = 2 * RG - (RG * System.Math.Cos(Alfa))
                        LLun = Int(AC + (1 + 1.0! / System.Math.Sin(Alfa)) * TAGLIO)
                        LCor = Int(AB + 2 * TAGLIO)
                    End If
                    If RP * System.Math.Sin(Alfa) > AB / 2 Then
192:                    AA = (RG - RP) * System.Math.Sin(Alfa)
                        BB = System.Math.Sqrt(RP * RP - AA * AA) - (RG - RP) * System.Math.Cos(Alfa)
                        LLun = Int(AC + 2.0! * TAGLIO) - BB
                    End If
                    SpAggior(Nrisp, SP)
                    SP.LamSp(1 - 1).Origin.y = RG + TAGLIO / 2
                    SP.LamSp(2 - 1).Origin.y = LLun - RG - TAGLIO / 2
                    SP.LamSp(1 - 1).Origin.X = LCor / 2 - TAGLIO / 2
                    SP.LamSp(2 - 1).Origin.X = -SP.LamSp(1).Origin.X
                    SP.LamSp(1 - 1).Direct.X = -System.Math.Sin(Alfa / 2)
                    SP.LamSp(1 - 1).Direct.y = -System.Math.Cos(Alfa / 2)
                    SP.LamSp(2 - 1).Direct.X = -SP.LamSp(1).Direct.X
                    SP.LamSp(2 - 1).Direct.y = -SP.LamSp(1).Direct.y
                    For i = 1 To Nrisp
                        SP.LamSp(i - 1).RG = RG
                        SP.LamSp(i - 1).RP = RP
                        SP.LamSp(i - 1).Alfa = Alfa
                    Next i
                    If SP.Rettn.LARG > SP.Rettn.Lung Then Rota90(SP)
                    If SP.Rettn.LARG < LaMAX And SP.Rettn.Lung < LMAX Then Exit Sub
                    ' SP.Remove(NSpicchi)
                    ' SP.Add(0, NSpicchi)
                Case 4
19:                 Nrisp = n
                    If Nrisp > 12 Then Nrisp = 12
                    AB = RG - RP * System.Math.Cos(Alfa / 2)
                    Passo = (RG + RP * System.Math.Cos(Alfa / 2)) * System.Math.Tan(Alfa / 2) + TAGLIO
                    If 2 * (RG - RP) * System.Math.Cos(Alfa / 2) < AB Then
                        Passo = System.Math.Sqrt(4 * RG * RG - (AB + 2 * RP * System.Math.Cos(Alfa / 2)) ^ 2) + TAGLIO
                    End If
                    AC = -Passo + 2 * RG * System.Math.Sin(Alfa / 2) + TAGLIO
                    Iniz = TAGLIO / 2 + RG * System.Math.Sin(Alfa / 2)
                    LCor = Int(AB) + TAGLIO
                    Do
                        AC = AC + Passo
                        LLun = Int(AC)
                        Nrisp = Nrisp - 1
                    Loop While LLun + Passo < LMAX And Nrisp > 0
                    Nrisp = n - Nrisp
                    SpAggior(Nrisp, SP)
                    senso = 1
                    SP.LamSp(1 - 1).Origin.y = Iniz
                    For i = 1 To Nrisp
                        SP.LamSp(i - 1).RG = RG
                        SP.LamSp(i - 1).RP = RP
                        SP.LamSp(i - 1).Alfa = Alfa
                        SP.LamSp(i - 1).Origin.X = (AB / 2 - RG + TAGLIO / 2) * senso
                        SP.LamSp(i - 1).Direct.X = senso
                        SP.LamSp(i - 1).Direct.y = 0
                        senso = -senso
                        If i > 1 Then SP.LamSp(i - 1).Origin.y = SP.LamSp(i - 2).Origin.y + Passo
                    Next i
                    If SP.Rettn.LARG > SP.Rettn.Lung Then Rota90(SP)
                    If SP.Rettn.LARG < LaMAX And SP.Rettn.Lung < LMAX Then Exit Sub
                    ' SP.Remove(NSpicchi)
                    ' SP.Add(0, NSpicchi)
                Case 5
                    Nrisp = 2
                    If Alfa > PI / 2 Then
210:                    AB = RG * (1 - System.Math.Cos(Alfa))
                        TanBeta = (1 + System.Math.Cos(Alfa)) / 2 '??????????
                        AC = System.Math.Sqrt(4.0! - (1 + System.Math.Cos(Alfa)) ^ 2) * RG
                        fact = 2
                    ElseIf (RG - RP) * System.Math.Cos(Alfa) < (RG - RP * System.Math.Cos(Alfa)) / 2 Then
                        AB = RG - RP * System.Math.Cos(Alfa)
                        AC = System.Math.Sqrt(4 * RG * RG - (2 * RG - AB) ^ 2)
                        fact = 2
                    Else
                        AB = RG - RP * System.Math.Cos(Alfa)
                        AC = RG * System.Math.Tan(Alfa) + RP * System.Math.Sin(Alfa)
                        fact = 1 + 1 / System.Math.Cos(Alfa)
                    End If
                    LLun = Int(AC + fact * TAGLIO)
                    LCor = Int(AB) + TAGLIO
                    SpAggior(Nrisp, SP)
                    SP.LamSp(1 - 1).Origin.y = TAGLIO / 2
                    SP.LamSp(2 - 1).Origin.y = LLun - TAGLIO / 2
                    SP.LamSp(1 - 1).Origin.X = LCor / 2 - RG - TAGLIO / 2
                    SP.LamSp(2 - 1).Origin.X = -SP.LamSp(1).Origin.X
                    SP.LamSp(1 - 1).Direct.X = System.Math.Cos(Alfa / 2)
                    SP.LamSp(1 - 1).Direct.y = System.Math.Sin(Alfa / 2)
                    SP.LamSp(2 - 1).Direct.X = -SP.LamSp(1).Direct.X
                    SP.LamSp(2 - 1).Direct.y = -SP.LamSp(1).Direct.y
                    For i = 1 To Nrisp
                        SP.LamSp(i - 1).RG = RG
                        SP.LamSp(i - 1).RP = RP
                        SP.LamSp(i - 1).Alfa = Alfa
                    Next i
                    If SP.Rettn.LARG > SP.Rettn.Lung Then Rota90(SP)
                    If SP.Rettn.LARG < LaMAX And SP.Rettn.Lung < LMAX Then Exit Sub
                    ' SP.Remove(NSpicchi)
                    ' SP.Add(0, NSpicchi)
            End Select
        Catch e As Exception
        End Try
    End Sub
    Private Sub SpAggior(ByVal Nrisp As Integer, ByVal SP As SpicLam)
        SP.Rettn.MakeCorners(LLun, LCor)
        If Nrisp > SP.Nspicchi Then
            n = Nrisp - SP.Nspicchi
            For i = 1 To n
                Spicchio4 = New Spicchio4
                SP.LamSp.Add(Spicchio4)
            Next
        End If
        SP.Nspicchi = Nrisp
    End Sub
    Public Sub Rota90(ByRef SP As SpicLam)
        Dim i As Short
        Dim Dum As Single
        Dum = SP.Rettn.Lung
        SP.Rettn.Lung = SP.Rettn.LARG
        SP.Rettn.LARG = Dum
        SP.Rettn.MakeCorners(SP.Rettn.Lung, SP.Rettn.LARG)
        For i = 1 To SP.Nspicchi
            Dum = SP.LamSp(i - 1).Origin.X
            SP.LamSp(i - 1).Origin.X = SP.LamSp(i - 1).Origin.y
            SP.LamSp(i - 1).Origin.y = Dum
            SP.LamSp(i - 1).Origin.X = SP.LamSp(i - 1).Origin.X - SP.Rettn.LARG / 2
            SP.LamSp(i - 1).Origin.y = SP.LamSp(i - 1).Origin.y + SP.Rettn.Lung / 2
            Dum = SP.LamSp(i - 1).Direct.X
            SP.LamSp(i - 1).Direct.X = SP.LamSp(i - 1).Direct.y
            SP.LamSp(i - 1).Direct.y = Dum
        Next i
    End Sub
    Sub DisegnSP(ByRef Quadro As clsLamQuadr, ByRef LARG As Single, ByRef Mode As Short, ByRef Margin As Single, ByRef i As Short, ByRef j0 As Short, ByRef SP As SpicLam)
        Dim k As Short
        Dim Punti0, Punti1 As RoutBase1.clsPunti
        Dim y1, x1, x2, y2 As Single
        Dim ang As Single
        Static jfatto As Short
        For k = 1 To 4
            SP.Rettn.x(k) = SP.Rettn.x(k) + Quadro.TopLeft.X + (Quadro.Botrigt.X - Quadro.TopLeft.X - LARG) / 2
            SP.Rettn.y(k) = SP.Rettn.y(k) + Quadro.TopLeft.y
        Next k
        If SP.Nspicchi > 0 Then
            For k = 1 To SP.Nspicchi
                SP.LamSp(k - 1).Origin.X = SP.LamSp(k - 1).Origin.X + Quadro.TopLeft.X + (Quadro.Botrigt.X - Quadro.TopLeft.X - LARG) / 2
                SP.LamSp(k - 1).Origin.y = SP.LamSp(k - 1).Origin.y + Quadro.TopLeft.y
            Next k
        Else
            SP.LamSp(1 - 1).Origin.X = SP.LamSp(1).Origin.X + Quadro.TopLeft.X + (Quadro.Botrigt.X - Quadro.TopLeft.X - LARG) / 2
            SP.LamSp(1 - 1).Origin.y = SP.LamSp(1 - 1).Origin.y + Quadro.TopLeft.y
        End If
        If Mode = 1 Then
            If SP.Nspicchi > 0 Then
                For k = 1 To SP.Nspicchi
                    SP.LamSp(k - 1).SpicGraf(0, Punti0, Punti1)
                Next k
            Else
                SP.LamSp(1 - 1).SpicGraf(0, Punti0, Punti1)
            End If
        Else
            If SP.Nspicchi > 0 Then
                For k = 1 To SP.Nspicchi
                    SP.LamSp(k - 1).SpicGraf(0, Punti0, Punti1)
                    ang = GlobalRoutines.arco(SP.LamSp(k - 1).Direct.X, SP.LamSp(k).Direct.y)
                    x1 = SP.LamSp(k - 1).Origin.X + SP.LamSp(k - 1).RP * System.Math.Cos(-ang + SP.LamSp(k - 1).Alfa / 2)
                    y1 = SP.LamSp(k - 1).Origin.y - SP.LamSp(k - 1).RP * System.Math.Sin(-ang + SP.LamSp(k - 1).Alfa / 2)
                    x2 = SP.LamSp(k - 1).Origin.X + SP.LamSp(k - 1).RG * System.Math.Cos(-ang - SP.LamSp(k - 1).Alfa / 2)
                    y2 = SP.LamSp(k - 1).Origin.y - SP.LamSp(k - 1).RG * System.Math.Sin(-ang - SP.LamSp(k - 1).Alfa / 2)
                    x1 = (x1 + x2) / 2 : y1 = (y1 + y2) / 2
                    If j0 + 100 * i <> jfatto Then
                        DatiGeom(SP)
                        jfatto = j0 + 100 * i
                    Else
                        Funzioni.DisRut.texts(x1 - 3.0!, y1 - 3.0!, Str(j0 + 100 * i), 4.0!, PI / 2.0!, 0.15)
                    End If
                Next k
            Else
                SP.LamSp(1 - 1).SpicGraf(0, Punti0, Punti1)
                ang = GlobalRoutines.arco(SP.LamSp(1).Direct.X, SP.LamSp(1).Direct.y)
                x1 = SP.LamSp(1 - 1).Origin.X + SP.LamSp(1 - 1).RP * System.Math.Cos(-ang + SP.LamSp(1 - 1).Alfa / 2)
                y1 = SP.LamSp(1 - 1).Origin.y - SP.LamSp(1 - 1).RP * System.Math.Sin(-ang + SP.LamSp(1 - 1).Alfa / 2)
                x2 = SP.LamSp(1 - 1).Origin.X + SP.LamSp(1 - 1).RG * System.Math.Cos(-ang - SP.LamSp(1 - 1).Alfa / 2)
                y2 = SP.LamSp(1 - 1).Origin.y - SP.LamSp(1 - 1).RG * System.Math.Sin(-ang - SP.LamSp(1 - 1).Alfa / 2)
                x1 = (x1 + x2) / 2 : y1 = (y1 + y2) / 2
                DatiGeom(SP)
            End If
        End If
    End Sub
    Private Sub DatiGeom(ByVal SP As SpicLam)
        Funzioni.DisRut.texts(x1 - 4.0!, y1 - 3.0!, "RP" & Str(Int(SP.LamSp(1 - 1).RP)), 4.0!, PI / 2.0!, 0.1)
        Funzioni.DisRut.texts(x1 + 1.0!, y1 - 3.0!, "RG" & Str(Int(SP.LamSp(1 - 1).RG)), 4.0!, PI / 2.0!, 0.1)
        Funzioni.DisRut.texts(x1 + 6.0!, y1 - 3.0!, "A." & GlobalRoutines.myStr(SP.LamSp(1 - 1).Alfa * 180 / PI + 0.05, 3, 1, False), 4.0!, PI / 2.0!, 0.1)
    End Sub
    Sub RettGraf(ByRef Rett As RoutBase1.clsRectang, ByRef Mode As Short)
        Dim i, j As Short
        'On Local Error GoTo ErrRett
        If Mode <= 1 Then
            Funzioni.DisRut.tratto(Rett.Corners(4).X, Rett.Corners(4).y, Rett.Corners(1).X, Rett.Corners(1).y, 0.1, 0)
            For i = 2 To 4
                Funzioni.DisRut.tratto(-1, -1, Rett.Corners(i).X, Rett.Corners(i).y, 0.1, 0)
            Next
        ElseIf Mode = 2 Or Mode = 4 Then
            For i = 1 To 4
                j = i + 1 : If j = 5 Then j = 1
                Funzioni.DisRut.tratto(Rett.Corners(i).X, Rett.Corners(i).y, Rett.Corners(j).X, Rett.Corners(j).y, 0.1, 0)
            Next i
        ElseIf Mode = 3 Then
            Funzioni.DisRut.quadrato(Rett.Corners(1).X, Rett.Corners(1).y, Rett.Corners(3).X, Rett.Corners(3).y, 0.1, 0, False)
        ElseIf Mode = 5 Then
            Funzioni.DisRut.quadrato(Rett.Corners(1).X, Rett.Corners(1).y, Rett.Corners(3).X, Rett.Corners(3).y, 0.1, 0, False)
        End If
    End Sub
    Public Function HelpStringa(ByVal id As Integer) As String
        Dim Nome As String = "str" + id.ToString.Trim
        HelpStringa = rmHelpStrings.GetString(Nome).Replace("|", vbCrLf)
    End Function
End Module