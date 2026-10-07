Option Strict On
Option Explicit On 
Imports System
Imports System.String
Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary 'Namespace for BinaryFormatter
Imports RoutBase1
<Serializable()> Class typSforziN
    Public f(,) As Single
    Public Sub New()
        ReDim f(12, 6)
    End Sub
End Class
<Serializable()> Class typNozzleData
    Private NB As Short, NCB As Short
    Public NozzleNames() As String
    Public NozzleForces(,,) As Single
    Public PositionX() As Single
    Public PositionZ() As Single
    Public NozzleForcesR(,) As Single
    Public Sub Initialize(ByVal Up As Boolean)
        Dim PNB, PNCB As Short
        If Up Then
            PNB = SaddlesItemT.NumBocch
            PNCB = SaddlesItemT.NumCondBocchT
        Else
            PNB = SaddlesItem.NumBocch
            PNCB = SaddlesItem.NumCondBocch
        End If
        If NB = PNB And NCB = PNCB Then Exit Sub
        If NB = 0 Then NB = -1
        If NCB = 0 Then NCB = -1
        ReDim Preserve NozzleNames(PNB)
        ReDim Preserve PositionX(PNB)
        ReDim Preserve PositionZ(PNB)
        Dim lNozzleForces(,,) As Single
        Dim lNozzleForcesR(,) As Single
        Dim i, j, k As Short
        Dim NBm As Short = CShort(Math.Min(NB, PNB))
        Dim NCBm As Short = CShort(Math.Min(NCB, PNCB))
        ReDim lNozzleForces(NBm, NCBm, 6)
        ReDim lNozzleForcesR(NCBm, 6)
        For j = 0 To NCBm
            For k = 0 To 6
                For i = 0 To NBm
                    lNozzleForces(i, j, k) = NozzleForces(i, j, k)
                Next
                lNozzleForcesR(j, k) = NozzleForcesR(j, k)
            Next
        Next
        ReDim NozzleForces(PNB, PNCB, 6)
        ReDim NozzleForcesR(PNCB, 6)
        For j = 0 To NCBm
            For k = 0 To 6
                For i = 0 To NBm
                    NozzleForces(i, j, k) = lNozzleForces(i, j, k)
                Next
                NozzleForcesR(j, k) = lNozzleForcesR(j, k)
            Next
        Next
        NB = PNB
        NCB = PNCB
    End Sub
End Class
<Serializable()> Class typLoadFoundDataN
    Public Pesi() As Single 'empty,operating,full of water,bundle
    Public Sforzi() As typSforziN
    Public LateralForce As Single
    Public FrontForce As Single
    Public LateralForceS As Single
    Public FrontForceS As Single
    Public Sub New()
        ReDim Pesi(3)
        ReDim Sforzi(2)
        Sforzi(1) = New typSforziN
        Sforzi(2) = New typSforziN
    End Sub
End Class
<Serializable()> Class typxSupportItem
    Public Tipo As String
    Public SaddlThk As Single
    Public SaddlLength As Single
    Public SaddlWidth As Single
    Public NumeroRibs As Short
    Public RibsThk As Single
    Public Dist() As Single
    Public material As String
    Public Sub New()
        ReDim Dist(5)
    End Sub
End Class
<Serializable()> Class typxFondaItem
    Public Commessa As String
    Public Item As String
    Public LoadCase As String
    Public BoltSize As String
    Public BoltMat As String
    Public BaseMat As String
    Public a As Single 'base plate length direzione Y
    Public b As Single 'base plate width  direzione X
    Public h As Single 'distance bolts/edgeNON PIU' USATO
    Public xQuota() As Single
    Public yQuota() As Single
    Public an As Single 'bolt root area
    Public nt As Short 'total number of bolts
    Public nb As Short 'bolts subject to tensionNON PIU' USATO
    Public ag As Single 'area gambo
    Public A1 As Single ' transversal span
    Public B1 As Single 'long span
    Public nc As Short 'numero di costole fixed edges
    Public SP As Single 'base plate thk
    Public Rm As Single 'Young Modulus ratio
    Public Inchiavard As Boolean 'sella mobile inchiavardata
    Public Sub New()
        ReDim xQuota(16)
        ReDim yQuota(16)
        Commessa = ""
        Item = ""
        LoadCase = ""
        BoltSize = ""
        BoltMat = ""
        BaseMat = ""
    End Sub
End Class
<Serializable()> Class typxFondaData
    Public alc As Single 'compress calc.
    Public alb As Single 'tensione bulloni
    Public albs As Single 'taglio bulloni
    Public albp As Single 'ammissibile piastra
    Public n As Single 'N
    Public sfx As Single 'T direzione asse apparecchio
    Public mx As Single 'M
    Public sfy As Single 'T direzione trasversa
    Public my As Single 'M
    Public E(2) As Single
    Public X(2) As Single
    Public sic(2) As Single 'pressione cemento
    Public sig(2) As Single 'tensione bulloni
    Public si(2) As Single 'tensione bulloni
    Public sipc(2) As Single
    Public sipb(2) As Single
    Public sh(2) As Single
    Public rap As Single
    Public Press As Single
    Public Pressb As Single
    Public Coef(2) As Single
    Public beta As Single
End Class
<Serializable()> Class typxSupportData
    Public Allow As Single
    Public NormalForce As Single
    Public ShearLong As Single
    Public ShearTrasv As Single
    Public MomLong As Single
    Public MomTrasv As Single
    Public MomTorc As Single
End Class
<Serializable()> Class typxSupportResult
    Public a As Single
    Public Az As Single
    Public Ay As Single
    Public Iz As Single
    Public Iy As Single
    Public j As Single
    Public sfx As Single
    Public SMy As Single
    Public SMz As Single
    Public TFy As Single
    Public TFz As Single
    Public TMx As Single
    Public Stress As Single
End Class
<Serializable()> Class typGeomSadd
    Public AxialWidth As Single
    Public IncluAngle As Single
    Public PlateWidth As Single
    Public PlateAngle As Single
    Public PlateThk As Single
    Public SaddlThk As Single
    Public SaddHeight As Single
    Public SupRing As Boolean
    Public Ix As Single
    Public rCrown As Single
    Public rBottom As Single
    Public Ax As Single
End Class
<Serializable()> Friend Class typProblem
    Public ClientPlant As String
    Public Item As String
    Public Author As String
    Public PadStr As String
    Public Doc As String
    Public NumBocch As Short
    Public NCond() As Short 'Saddles,xSupport,xFonda
    Public Stacked As Boolean
    Public Codice As Short '0 BS 1 Stoomwezen
    Public Versione As Short '2 
    Public Verbose As Boolean
    Public NumCondElem As Short
    Public Condiz() As String ' nome condizione elementare
    Public LoadCase(,,) As Single   'saddles sella base,iCond,LoadCase
    Public LoadCond(,) As String 'nome condizione
    Public NormeVento As String
    Public NumParamV As Short
    Public ParamV() As Single
    Public NormeSisma As String
    Public NumParamS As Short
    Public ParamS() As Single
    Public iCompresso() As Short
    Public IgnoreOutOfRoundness As Boolean
    Public ReadOnly Property NumCondBocch() As Short
        Get
            Dim i, n As Short
            For i = 1 To Problem.NumCondElem
                If Problem.Condiz(i).ToUpper.IndexOf("NOZZLE") > -1 Then n = CShort(n + 1)
            Next
            Return n
        End Get
    End Property
    Public Sub initialize()
        ReDim Preserve Condiz(NumCondElem)
        ReDim Preserve LoadCase(3, 8, NumCondElem)
    End Sub
    Public Sub New()
        ReDim NCond(3)
        ReDim LoadCond(3, 8)
        ReDim ParamV(10)
        ReDim ParamS(10)
        ReDim iCompresso(11)
        ClientPlant = ""
        Item = ""
        Author = ""
        Doc = ""
        Me.IgnoreOutOfRoundness = True
        initialize()
    End Sub

End Class
<Serializable()> Class typSaddlesLoad
    Public DesPress As Single
    Public DesTemp As Single
    Public PesoTot As Single
    Public PesoS(2) As Single
    Public MomS(2) As Single
    Public AmmShell(2) As Single
    Public Young(2) As Single
    Public AmmSadd(2) As Single
    Public AmmHead(2) As Single
    Public AmmHeadTens(2) As Single
End Class
<Serializable()> Class typSaddlesItemN
    Public Item As String
    Public Simple As String
    Public IndMatShell As Integer
    Public TipoChius(2) As Short
    Public TipoMat As Short
    Public Diam As Single
    Public Spess(2) As Single
    Public SpessHead(2) As Single
    Public HeadHeight As Single
    Public Lungh(2) As Single
    Public GeomSadd(2) As typGeomSadd
    Public OutDia(3) As Single
    Public MeanR(3) As Single
    Public w(3) As Single
    Public RHead(2) As Single
    Public LT As Single
    Public LTT As Single
    Public CGdistFromFixed As Single
    Public CGHeight As Single
    Public frictionfactor As Single
    Public bundlefactor As Single
    Public bundleCGheight As Single
    Public VesselOD As Single
    Public InsulThk As Single
    Public VesselLength As Single
    Public EquivVesselOD As Single
    Public SaddleBaseWidth As Single
    Public Heightbtwsaddles As Single
    Public NumBocch As Short
    Public ReadOnly Property NumCondBocch() As Short
        Get
            Dim i, n As Short
            For i = 1 To Problem.NumCondElem
                If Problem.Condiz(i).ToUpper.IndexOf("NOZZLE") > -1 Then n = CShort(n + 1)
            Next
            Return n
        End Get
    End Property
    Public ReadOnly Property NumCondBocchT() As Short
        Get
            Dim i, n As Short
            For i = 1 To Problem.NumCondElem
                If Problem.Condiz(i).ToUpper.IndexOf("NOZZLE") > -1 Then n = CShort(n + 1)
            Next
            Return n
        End Get
    End Property
    Public Sub New()
        Dim i As Short
        For i = 0 To 2
            GeomSadd(i) = New typGeomSadd
        Next
    End Sub
End Class
<Serializable()> Class typSadDesign
    Public K9(2) As Single
    Public h(2) As Single
    Public HSD(2) As Single
    Public FSD(2) As Single
    Public Pz(2) As Single
End Class
<Serializable()> Class typShearSaddle
    Public K3(2) As Single
    Public K4(2) As Single
    Public SQ(2) As Single
    Public SQE(2) As Single
    Public TANGS(2) As Single
    Public TANGH(2) As Single
End Class
<Serializable()> Class typCircSaddle
    Public ZETS(2) As Single
    Public b2(2) As Single
    Public K5(2) As Single
    Public K6(2) As Single
    Public K6S(2) As Single
    Public TT(2) As Single
    Public F5(2) As Single
    Public F6(2) As Single
    Public F6S(2) As Single
End Class
<Serializable()> Class typTensSaddle
    Public K1(2, 1) As Single
    Public k2(2, 1) As Single
    Public M4(2) As Single
    Public F3(2, 1) As Single
    Public F4(2, 1) As Single
    Public ROUND(2, 1) As Short
End Class
<Serializable()> Class typTensMiddle
    Public M3PS As Single
    Public M3NG As Single
    Public F1PS(1) As Single
    Public F2PS(1) As Single
    Public F1NG(1) As Single
    Public F2NG(1) As Single
End Class
<Serializable()> Class typAreaLav
    Public Q As Single 'carico distribuito
    Public React(2) As Single
    Public Momen(2) As Single
    Public Taglio(2) As Single
    Public SFAT As Single
    Public PYSS(2) As Single
    Public KFAT(2) As Single
    Public PE(2) As Single
    Public DEL(2) As Single
    Public FALC(2) As Single
    Public SAL(2) As Single
    Public SALH(2) As Single
    Public TensMiddle As New typTensMiddle
    Public TensSaddle As New typTensSaddle
    Public ShearSaddle As New typShearSaddle
    Public CircSaddle As New typCircSaddle
    Public SadDesign As New typSadDesign
End Class
<Serializable()> Class typSforzifromTop
    Public SforziFromTop(2, 12, 4) As Single
End Class
'=========================================================
Module saddles
    Public EliminatoVento, EliminatoSisma As Boolean
    Public CambiataNormaVento, CambiataNormaSisma As Boolean
    Private Titoli As String() = {"", "Fx [N]", "Fy [N]", "Fz [N]", "Mx [Nm]", "My [Nm]", "Mz [Nm]"}
    Public Const NumMaxCombCond As Integer = 11
    Public Const FormInt As String = "######"
    Public Const FormInt8 As String = "########"
    Public Const FormSng0 As String = "######."
    Public Const FormSng1 As String = "#.#"
    Public Const FormSng2 As String = "####.##"
    Public Const IDH_ZICK_PD352_NODIAM As Integer = 1000
    Public Const IDH_ZICK_PD352_NOSPESS As Integer = 1001
    Public Const IDH_ZICK_PD352_NOFILE As Integer = 1002
    Public Const IDH_ZICK_PD352_NONCONS As Integer = 1003
    Public Const IDH_DEVIINCHIAVARDARE As Integer = 1004
    Public Const IDH_MAXCONDELEM As Integer = 1005
    Public Const IDH_NIENTEDASTAMPARE As Integer = 1006
    Public Const IDH_ERR_BADSERIAL As Integer = 2022
    '==========================================================
    Friend sonda As Boolean
    Friend NumCondElemIniz As Short
    Friend Form3 As frmFonda
    Friend Interrompi As Boolean
    Friend TabSize, dgSize As Size
    Friend dgLocation As Point
    Friend Espressionep, EspressioneF As String
    Friend Inizializzando As Boolean
    Friend Const Par As String = "\par "
    Friend Tokensp, TokensF, TokensS As Queue
    Friend Calc As New FormulaParser.mcCalc
    Public BSDD As clsBSDD
    Public LCshell, LCsadd, LCfond As DataTable
    Public LCelem As DataTable
    Public CarBocch, CarBocchT As ArrayList
    Public CarBocchR, CarBocchRT As DataTable
    Public WithEvents CarFond, CarFondT, CarDaSopra As DataTable
    Public WithEvents tbListaBocchelli, tbListaBocchelliT As DataTable
    Public RigaLista As Short
    Public ContrNome, ContrFile, gencommes As String
    Public job As RoutBase1.clsjob
    Public myAssembly As System.Reflection.Assembly
    Public rmHelpStrings As Resources.ResourceManager
    Public rmHelpTopics As Resources.ResourceManager
    Friend GlobalRoutines As RoutBase1.clsTrigon
    Public kSt(8, 2) As Single
    Public MatShell, MatShellT As LibMat.MaterialeNew1
    Public Stub As StubW2000.clsSW2000
    Public Monitor As clsMonitor
    Public RadiceHelp As String
    Public iCondMax(3) As Short
    Public Problem As typProblem
    Public SforziFromTop As New typSforzifromTop
    Public AreaLav(), AreaLavT() As typAreaLav
    Public SaddlesItem, SaddlesItemT As New typSaddlesItemN
    Public SaddlesLoad(), SaddlesLoadT() As typSaddlesLoad
    Public xSupport(2), xSupportT(2) As typxSupportItem
    Public xSupportData(,), xSupportDataT(,) As typxSupportData
    Public xSupportResult(,), xSupportResultT(,) As typxSupportResult
    Public GGD() As String
    Public GG1() As String
    Public GG2() As String ',TIT$()
    Public KK1() As Single
    Public KK2() As Single
    Public ANG() As Single
    Public mioContr, mioContr1, mioContr2, mioContr3 As ControlArray
    Public mioContrT, mioContr1T, mioContr2T, mioContr3T As ControlArray
    Public iPagina, iSottoPagina, iSottoSottoPagina, Ncontr As Short
    Public iPaginaT, iSottoPaginaT, iSottoSottoPaginaT, NcontrT As Short
    Public FileData As String
    Public NomeFileSt As String
    Public Const PSI As Double = 145.038
    Public XPS, XNG As Single
    Public nDist As Short
    Public SelleCalcolate, SaddlesCalcolate, FondaCalcolate As Boolean
    Public SelleCalcolateT, SaddlesCalcolateT As Boolean
    Public LoadsCalcolate As Boolean
    Public iSadd, iCond As Short
    Public LoadFoundData, LoadFoundDataT As New typLoadFoundDataN
    Public NozzleData, NozzleDataT As New typNozzleData
    Public xFondaData(,) As typxFondaData
    Public xFondaItem(2) As typxFondaItem
    Public FileExcel, FinalCommentFinal As String
    'Public StampaTutto As Integer
    Public FinalComment(,) As String
    Public DoveEccede(2, 6, NumMaxCombCond) As String
    Public DoveEccedes(14) As String
    Public FactUs(14, NumMaxCombCond) As Single
    Public pag As Integer
    Public form1 As frmResultSaddles
    Private b, l2, cs As Single
    Private d1, d, R As Single
    Private f, be As Single
    Public ReadOnly Property pxSupport(ByVal iSadd As Short, ByVal iBtmTop As Short) As typxSupportItem
        Get
            Select Case iBtmTop
                Case 1 : Return xSupport(iSadd)
                Case 2 : Return xSupportT(iSadd)
                Case Else : Return Nothing
            End Select
        End Get
    End Property
    Public ReadOnly Property pxSupportData(ByVal iSadd As Short, ByVal iCond As Short, ByVal iBtmTop As Short) As typxSupportData
        Get
            Select Case iBtmTop
                Case 1 : Return xSupportData(iSadd, iCond)
                Case 2 : Return xSupportDataT(iSadd, iCond)
                Case Else : Return Nothing
            End Select
        End Get
    End Property
    Public ReadOnly Property pAreaLav(ByVal iC As Short, ByVal i As Short) As typAreaLav
        Get
            Select Case i
                Case 1 : Return AreaLav(iCond)
                Case 2 : Return AreaLavT(iCond)
                Case Else : Return Nothing
            End Select
        End Get
    End Property
    Public ReadOnly Property pSaddlesItem(ByVal i As Short) As typSaddlesItemN
        Get
            Select Case i
                Case 1 : Return SaddlesItem
                Case 2 : Return SaddlesItemT
                Case Else : Return Nothing
            End Select
        End Get
    End Property
    Public ReadOnly Property pSaddlesLoad(ByVal iCond As Short, ByVal i As Short) As typSaddlesLoad
        Get
            Select Case i
                Case 1 : Return SaddlesLoad(iCond)
                Case 2 : Return SaddlesLoadT(iCond)
                Case Else : Return Nothing
            End Select
        End Get
    End Property
    Public Sub ChiudiExcel()
        SelleCalcolate = False
        SaddlesCalcolate = False
        SelleCalcolateT = False
        SaddlesCalcolateT = False
        FondaCalcolate = False
        LoadsCalcolate = False
    End Sub
    Friend Sub SetNormeVento(ByVal visual As Boolean)
        Dim strFile As String = Monitor.Motore.Inizio.Archdir & "\WR\NormeVento.INI"
        Dim Names() As String = Nothing
        Dim i, iQ As Integer
        Dim n As Integer = Monitor.Motore.Inizio.ReadProfileSectionNames(strFile, Names)
        For i = n - 1 To 0 Step -1
            Names(i + 1) = Names(i)
            If Problem.NormeVento = Names(i + 1) Then iQ = i + 1
        Next
        Names(0) = ""
        If iQ = 0 Then iQ = 2
        If visual Then
            Dim Tit As String = rmHelpStrings.GetString("CodVento")
            Dim Aiuto As String = ""
            i = Monitor.Motore.Quale(CShort(n), Tit, Names, Aiuto, CShort(iQ))
            CambiataNormaVento = i <> iQ
            Problem.NormeVento = Names(i)
            Problem.NormeVento = Names(i)
        Else
            Problem.NormeVento = Names(iQ)
            Problem.NormeVento = Names(iQ)
        End If
        IniziaVento()
        IniziaVentoT()
        If i = 1 And iQ > 1 Or i > 1 And iQ = 1 Then
            IniziaLC(True) : NozzleData.Initialize(False)
            IniziaLCT(True) : NozzleDataT.Initialize(False)
        End If
        RicalcolaVento()
        RicalcolaVentoT()
    End Sub
    Friend Sub SetNormeSisma(ByVal visual As Boolean)
        Dim strFile As String = Monitor.Motore.Inizio.Archdir & "\WR\NormeSisma.INI"
        Dim Names() As String = Nothing
        Dim i, iQ As Integer
        Dim n As Integer = Monitor.Motore.Inizio.ReadProfileSectionNames(strFile, Names)
        For i = n - 1 To 0 Step -1
            Names(i + 1) = Names(i)
            If Problem.NormeSisma = Names(i + 1) Then iQ = i + 1
        Next
        Names(0) = ""
        If iQ = 0 Then iQ = 2
        If visual Then
            Dim Tit As String = rmHelpStrings.GetString("CodSisma")
            Dim Aiuto As String = ""
            i = Monitor.Motore.Quale(CShort(n), Tit, Names, Aiuto, CShort(iQ))
            CambiataNormaSisma = i <> iQ
            Problem.NormeSisma = Names(i)
            Problem.NormeSisma = Names(i)
        Else
            Problem.NormeSisma = Names(iQ)
            Problem.NormeSisma = Names(iQ)
        End If
        IniziaSisma()
        IniziaSismaT()
        If i = 1 And iQ > 1 Or i > 1 And iQ = 1 Then
            IniziaLC(True) : NozzleData.Initialize(False) : RinfrescaTabelleNozzles()
            IniziaLCT(True) : NozzleDataT.Initialize(False) : RinfrescaTabelleNozzlesT()
        End If
        RicalcolaSisma()
        RicalcolaSismaT()
    End Sub
    Friend Sub IniziaVento()
        Dim strFile As String = Monitor.Motore.Inizio.Archdir & "\WR\NormeVento.INI"
        If Problem.NormeVento Is Nothing Then SetNormeVento(False)
        If Problem.NormeVento = "" Then Problem.NormeVento = "not applicable" : SetNormeVento(False)
        With frmSaddles.DefInstance
            If Problem.NormeVento = "not applicable" Then
                Inizializzando = True
                .TabCarFondDown.Controls.Remove(.PagCarichiFinali)
                Try
                    .TabCarFondDown.Controls.Remove(.PagVento)
                Catch
                End Try
                .TabCarFondDown.Controls.Add(.PagCarichiFinali)
                EliminatoVento = True
                Inizializzando = False
                Exit Sub
            Else
                If EliminatoVento Then
                    Inizializzando = True
                    .TabCarFondDown.Controls.Remove(.PagCarichiFinali)
                    If Not EliminatoSisma Then .TabCarFondDown.Controls.Remove(.PagSisma)
                    .TabCarFondDown.Controls.Add(.PagVento)
                    If Not EliminatoSisma Then .TabCarFondDown.Controls.Add(.PagSisma)
                    .TabCarFondDown.Controls.Add(.PagCarichiFinali)
                    Inizializzando = False
                End If
                EliminatoVento = False
            End If
            Dim strp As String = Monitor.Motore.Inizio.ReadIniFile(strFile, Problem.NormeVento, "p")
            Dim strpsplit() As String = strp.Split(CChar(","))
            Dim strF As String = Monitor.Motore.Inizio.ReadIniFile(strFile, Problem.NormeVento, "F")
            Dim strFormula As String = Monitor.Motore.Inizio.ReadIniFile(strFile, Problem.NormeVento, "Formula")
            Dim strFsplit() As String = strF.Split(CChar(","))
            Dim strV As String
            Dim strVsplit() As String
            Dim Variabile As String
            Dim i As Integer
            Inizializzando = True
            Try
                .lVento.RemoveAll(1)
                .lsVento.RemoveAll(1)
                .rtfVento.RemoveAll(1)
                .tVento.RemoveAll(1)
                .rtfFormulaVento.Rtf = strFormula
                Espressionep = GlobalRoutines.ConvertiPunto(strpsplit(0))
                Calc.calc_scan(Espressionep, Tokensp)
                'Calc.calc_scan(strpsplit(0), Tokensp)
                Dim Enumerator As IEnumerator = Tokensp.GetEnumerator
                While Enumerator.MoveNext
                    If CType(Enumerator.Current, FormulaParser.mcSymbol).Cls = FormulaParser.mcCalc.TOKENCLASS.IDENTIFIER Then
                        Variabile = CType(Enumerator.Current, FormulaParser.mcSymbol).Token
                        strV = Monitor.Motore.Inizio.ReadIniFile(strFile, Problem.NormeVento, Variabile)
                        strVsplit = strV.Split(CChar(","))
                        If i > 0 Then .lVento.Load(i)
                        .lVento(i).Text = strVsplit(0)
                        .lVento(i).Visible = True
                        If i > 0 Then .lVento(i).Top = .lVento(i - 1).Top + .lVento(i).Height
                        If i > 0 Then .lsVento.Load(i)
                        .lsVento(i).Text = Variabile
                        .lsVento(i).Visible = True
                        If i > 0 Then .lsVento(i).Top = .lsVento(i - 1).Top + .lsVento(i).Height
                        If i > 0 Then .rtfVento.Load(i)
                        If strVsplit(1).IndexOf("rtf1") = -1 Then
                            .rtfVento(i).Text = strVsplit(1)
                        Else
                            .rtfVento(i).Rtf = strVsplit(1)
                        End If
                        .rtfVento(i).Visible = True
                        If i > 0 Then .rtfVento(i).Top = .rtfVento(i - 1).Top + .rtfVento(i).Height
                        If i > 0 Then .tVento.Load(i)
                        If CambiataNormaVento Or Problem.ParamV(i) = 0 Then
                            .tVento(i).Text = GlobalRoutines.ConvertiPunto(strVsplit(2))
                            Problem.ParamV(i) = GlobalRoutines.ValVir(.tVento(i).Text)
                            CambiataNormaVento = False
                        Else
                            .tVento(i).Text = GlobalRoutines.FormatS(FormSng2, Problem.ParamV(i))
                        End If
                        .tVento(i).Visible = True
                        If i > 0 Then .tVento(i).Top = .tVento(i - 1).Top + .tVento(i).Height
                        i += 1
                    End If
                End While
                EspressioneF = GlobalRoutines.ConvertiPunto(strFsplit(0))
                Calc.calc_scan(EspressioneF, TokensF)
                Enumerator = TokensF.GetEnumerator
                If strFsplit(1).IndexOf("rtf1") = -1 Then
                    .rtfLateralForce.Text = strFsplit(1)
                    .rtfFrontForce.Text = strFsplit(1)
                Else
                    .rtfLateralForce.Rtf = strFsplit(1)
                    .rtfFrontForce.Rtf = strFsplit(1)
                End If
                While Enumerator.MoveNext
                    If CType(Enumerator.Current, FormulaParser.mcSymbol).Cls = FormulaParser.mcCalc.TOKENCLASS.IDENTIFIER Then
                        Variabile = CType(Enumerator.Current, FormulaParser.mcSymbol).Token
                        strV = Monitor.Motore.Inizio.ReadIniFile(strFile, Problem.NormeVento, Variabile)
                        strVsplit = strV.Split(CChar(","))
                        If Variabile = "A" Then
                            .rtfLateralArea.Rtf = strVsplit(1)
                            .rtfFrontArea.Rtf = strVsplit(1)
                        ElseIf Variabile = "p" Then
                            .rtfPressure.Rtf = strVsplit(1)
                        Else
                            .lVento.Load(i)
                            .lVento(i).Text = strVsplit(0)
                            .lVento(i).Top = .lVento(i - 1).Top + .lVento(i).Height
                            .lVento(i).Visible = True
                            .lsVento.Load(i)
                            .lsVento(i).Text = Variabile
                            .lsVento(i).Top = .lsVento(i - 1).Top + .lsVento(i).Height
                            .lsVento(i).Visible = True
                            .rtfVento.Load(i)
                            If strVsplit(1).IndexOf("rtf1") = -1 Then
                                .rtfVento(i).Text = strVsplit(1)
                            Else
                                .rtfVento(i).Rtf = strVsplit(1)
                            End If
                            .rtfVento(i).Top = .rtfVento(i - 1).Top + .rtfVento(i).Height
                            .rtfVento(i).Visible = True
                            .tVento.Load(i)
                            .tVento(i).Text = GlobalRoutines.ConvertiPunto(strVsplit(2))
                            .tVento(i).Top = .tVento(i - 1).Top + .tVento(i).Height
                            .tVento(i).Visible = True
                        End If
                        i += 1
                    End If
                End While
                .lblCodiceVento.Text = Problem.NormeVento
                Problem.NumParamV = CShort(i - 2)
                '                For i = Problem.NumParamV To .tVento.Count - 1
                '               .tVento(i).Visible = False
                '              .rtfVento(i).Visible = False
                '             .lsVento(i).Visible = False
                '            .lVento(i).Visible = False
                '           Next
                Inizializzando = False
            Catch e As Exception
                MsgBox(e.Message + vbCrLf + e.StackTrace)
            End Try
        End With
    End Sub
    Friend Sub IniziaVentoT()
        Dim strFile As String = Monitor.Motore.Inizio.Archdir & "\WR\NormeVento.INI"
        If Problem.NormeVento Is Nothing Then SetNormeVento(False)
        If Problem.NormeVento = "" Then Problem.NormeVento = "not applicable" : SetNormeVento(False)
        With frmSaddles.DefInstance
            If Problem.NormeVento = "not applicable" Then
                Inizializzando = True
                .TabCarFondUp.Controls.Remove(.PagCarichifinaliT)
                Try
                    .TabCarFondUp.Controls.Remove(.PagVentoT)
                Catch
                End Try
                .TabCarFondUp.Controls.Add(.PagCarichifinaliT)
                EliminatoVento = True
                Inizializzando = False
                Exit Sub
            Else
                If EliminatoVento Then
                    Inizializzando = True
                    .TabCarFondUp.Controls.Remove(.PagCarichifinaliT)
                    If Not EliminatoSisma Then .TabCarFondUp.Controls.Remove(.PagSismaT)
                    .TabCarFondUp.Controls.Add(.PagVentoT)
                    If Not EliminatoSisma Then .TabCarFondUp.Controls.Add(.PagSismaT)
                    .TabCarFondUp.Controls.Add(.PagCarichifinaliT)
                    Inizializzando = False
                End If
                EliminatoVento = False
            End If
            Dim strp As String = Monitor.Motore.Inizio.ReadIniFile(strFile, Problem.NormeVento, "p")
            Dim strpsplit() As String = strp.Split(CChar(","))
            Dim strF As String = Monitor.Motore.Inizio.ReadIniFile(strFile, Problem.NormeVento, "F")
            Dim strFormula As String = Monitor.Motore.Inizio.ReadIniFile(strFile, Problem.NormeVento, "Formula")
            Dim strFsplit() As String = strF.Split(CChar(","))
            Dim strV As String
            Dim strVsplit() As String
            Dim Variabile As String
            Dim i As Integer
            Inizializzando = True
            Try
                .lVentoT.RemoveAll(1)
                .lsVentoT.RemoveAll(1)
                .rtfVentoT.RemoveAll(1)
                .tVentoT.RemoveAll(1)
                .rtfFormulaVentoT.Rtf = strFormula
                Espressionep = GlobalRoutines.ConvertiPunto(strpsplit(0))
                Calc.calc_scan(Espressionep, Tokensp)
                'Calc.calc_scan(strpsplit(0), Tokensp)
                Dim Enumerator As IEnumerator = Tokensp.GetEnumerator
                While Enumerator.MoveNext
                    If CType(Enumerator.Current, FormulaParser.mcSymbol).Cls = FormulaParser.mcCalc.TOKENCLASS.IDENTIFIER Then
                        Variabile = CType(Enumerator.Current, FormulaParser.mcSymbol).Token
                        strV = Monitor.Motore.Inizio.ReadIniFile(strFile, Problem.NormeVento, Variabile)
                        strVsplit = strV.Split(CChar(","))
                        If i > 0 Then .lVentoT.Load(i)
                        .lVentoT(i).Text = strVsplit(0)
                        .lVentoT(i).Visible = True
                        If i > 0 Then .lVentoT(i).Top = .lVentoT(i - 1).Top + .lVentoT(i).Height
                        If i > 0 Then .lsVentoT.Load(i)
                        .lsVentoT(i).Text = Variabile
                        .lsVentoT(i).Visible = True
                        If i > 0 Then .lsVentoT(i).Top = .lsVentoT(i - 1).Top + .lsVentoT(i).Height
                        If i > 0 Then .rtfVentoT.Load(i)
                        If strVsplit(1).IndexOf("rtf1") = -1 Then
                            .rtfVentoT(i).Text = strVsplit(1)
                        Else
                            .rtfVentoT(i).Rtf = strVsplit(1)
                        End If
                        .rtfVentoT(i).Visible = True
                        If i > 0 Then .rtfVentoT(i).Top = .rtfVentoT(i - 1).Top + .rtfVentoT(i).Height
                        If i > 0 Then .tVentoT.Load(i)
                        If CambiataNormaVento Or Problem.ParamV(i) = 0 Then
                            .tVentoT(i).Text = GlobalRoutines.ConvertiPunto(strVsplit(2))
                            Problem.ParamV(i) = GlobalRoutines.ValVir(.tVentoT(i).Text)
                            CambiataNormaVento = False
                        Else
                            .tVentoT(i).Text = GlobalRoutines.FormatS(FormSng2, Problem.ParamV(i))
                        End If
                        .tVentoT(i).Visible = True
                        If i > 0 Then .tVentoT(i).Top = .tVentoT(i - 1).Top + .tVentoT(i).Height
                        i += 1
                    End If
                End While
                EspressioneF = GlobalRoutines.ConvertiPunto(strFsplit(0))
                Calc.calc_scan(EspressioneF, TokensF)
                Enumerator = TokensF.GetEnumerator
                If strFsplit(1).IndexOf("rtf1") = -1 Then
                    .rtfLateralForceT.Text = strFsplit(1)
                    .rtfFrontForceT.Text = strFsplit(1)
                Else
                    .rtfLateralForceT.Rtf = strFsplit(1)
                    .rtfFrontForceT.Rtf = strFsplit(1)
                End If
                While Enumerator.MoveNext
                    If CType(Enumerator.Current, FormulaParser.mcSymbol).Cls = FormulaParser.mcCalc.TOKENCLASS.IDENTIFIER Then
                        Variabile = CType(Enumerator.Current, FormulaParser.mcSymbol).Token
                        strV = Monitor.Motore.Inizio.ReadIniFile(strFile, Problem.NormeVento, Variabile)
                        strVsplit = strV.Split(CChar(","))
                        If Variabile = "A" Then
                            .rtfLateralAreaT.Rtf = strVsplit(1)
                            .rtfFrontAreaT.Rtf = strVsplit(1)
                        ElseIf Variabile = "p" Then
                            .rtfPressureT.Rtf = strVsplit(1)
                        Else
                            .lVentoT.Load(i)
                            .lVentoT(i).Text = strVsplit(0)
                            .lVentoT(i).Top = .lVentoT(i - 1).Top + .lVentoT(i).Height
                            .lVentoT(i).Visible = True
                            .lsVentoT.Load(i)
                            .lsVentoT(i).Text = Variabile
                            .lsVentoT(i).Top = .lsVentoT(i - 1).Top + .lsVentoT(i).Height
                            .lsVentoT(i).Visible = True
                            .rtfVentoT.Load(i)
                            If strVsplit(1).IndexOf("rtf1") = -1 Then
                                .rtfVentoT(i).Text = strVsplit(1)
                            Else
                                .rtfVentoT(i).Rtf = strVsplit(1)
                            End If
                            .rtfVentoT(i).Top = .rtfVentoT(i - 1).Top + .rtfVentoT(i).Height
                            .rtfVentoT(i).Visible = True
                            .tVentoT.Load(i)
                            .tVentoT(i).Text = GlobalRoutines.ConvertiPunto(strVsplit(2))
                            .tVentoT(i).Top = .tVentoT(i - 1).Top + .tVentoT(i).Height
                            .tVentoT(i).Visible = True
                        End If
                        i += 1
                    End If
                End While
                .lblCodiceVentoT.Text = Problem.NormeVento
                Problem.NumParamV = CShort(i - 2)
                Inizializzando = False
            Catch e As Exception
                MsgBox(e.Message + vbCrLf + e.StackTrace)
            End Try
        End With
    End Sub
    Friend Sub IniziaSisma()
        Dim strFile As String = Monitor.Motore.Inizio.Archdir & "\WR\NormeSisma.INI"
        If Problem.NormeSisma Is Nothing Then SetNormeSisma(False)
        If Problem.NormeSisma = "" Then Problem.NormeSisma = "not applicable" : SetNormeSisma(False)
        With frmSaddles.DefInstance
            If Problem.NormeSisma = "not applicable" Then
                Inizializzando = True
                .TabCarFondDown.Controls.Remove(.PagCarichiFinali)
                Try
                    .TabCarFondDown.Controls.Remove(.PagSisma)
                Catch
                End Try
                .TabCarFondDown.Controls.Add(.PagCarichiFinali)
                Inizializzando = False
                EliminatoSisma = True
                Exit Sub
            Else
                If EliminatoSisma Then
                    Inizializzando = True
                    .TabCarFondDown.Controls.Remove(.PagCarichiFinali)
                    .TabCarFondDown.Controls.Add(.PagSisma)
                    .TabCarFondDown.Controls.Add(.PagCarichiFinali)
                    Inizializzando = False
                End If
                EliminatoSisma = False
            End If
            Dim strF As String = Monitor.Motore.Inizio.ReadIniFile(strFile, Problem.NormeSisma, "F")
            Dim strFormula As String = Monitor.Motore.Inizio.ReadIniFile(strFile, Problem.NormeSisma, "Formula")
            Dim strFsplit() As String = strF.Split(CChar(","))
            Dim strV As String
            Dim strVsplit() As String
            Dim Variabile As String
            Dim i As Integer
            Inizializzando = True
            Try
                .lSisma.RemoveAll(1)
                .lsSisma.RemoveAll(1)
                .rtfSisma.RemoveAll(1)
                .tSisma.RemoveAll(1)
                .rtfFormulaSisma.Rtf = strFormula
                Espressionep = GlobalRoutines.ConvertiPunto(strFsplit(0))
                Calc.calc_scan(Espressionep, TokensS)
                If strFsplit(1).IndexOf("rtf1") = -1 Then
                    .rtfForceSeism.Text = strFsplit(1)
                Else
                    .rtfForceSeism.Rtf = strFsplit(1)
                End If
                Dim Enumerator As IEnumerator = TokensS.GetEnumerator
                While Enumerator.MoveNext
                    If CType(Enumerator.Current, FormulaParser.mcSymbol).Cls = FormulaParser.mcCalc.TOKENCLASS.IDENTIFIER Then
                        Variabile = CType(Enumerator.Current, FormulaParser.mcSymbol).Token
                        If Variabile = "Wp" Then
                        Else
                            strV = Monitor.Motore.Inizio.ReadIniFile(strFile, Problem.NormeSisma, Variabile)
                            strVsplit = strV.Split(CChar(","))
                            If i > 0 Then .lSisma.Load(i)
                            .lSisma(i).Text = strVsplit(0)
                            .lSisma(i).Visible = True
                            If i > 0 Then .lSisma(i).Top = .lSisma(i - 1).Top + .lSisma(i).Height
                            If i > 0 Then .lsSisma.Load(i)
                            .lsSisma(i).Text = Variabile
                            .lsSisma(i).Visible = True
                            If i > 0 Then .lsSisma(i).Top = .lsSisma(i - 1).Top + .lsSisma(i).Height
                            If i > 0 Then .rtfSisma.Load(i)
                            If strVsplit(1).IndexOf("rtf1") = -1 Then
                                .rtfSisma(i).Text = strVsplit(1)
                            Else
                                .rtfSisma(i).Rtf = strVsplit(1)
                            End If
                            .rtfSisma(i).Visible = True
                            If i > 0 Then .rtfSisma(i).Top = .rtfSisma(i - 1).Top + .rtfSisma(i).Height
                            If i > 0 Then .tSisma.Load(i)
                            If CambiataNormaSisma Or Problem.ParamS(i) = 0 Then
                                .tSisma(i).Text = GlobalRoutines.ConvertiPunto(strVsplit(2))
                                Problem.ParamS(i) = GlobalRoutines.ValVir(.tSisma(i).Text)
                                CambiataNormaSisma = False
                            Else
                                .tSisma(i).Text = GlobalRoutines.FormatS(FormSng2, Problem.ParamS(i))
                            End If
                            .tSisma(i).Visible = True
                            If i > 0 Then .tSisma(i).Top = .tSisma(i - 1).Top + .tSisma(i).Height
                            i += 1
                        End If
                    End If
                End While
                .lblCodiceSisma.Text = Problem.NormeSisma
                Problem.NumParamS = CShort(i)
                '                For i = Problem.NumParamS To .tSisma.Count - 1
                '                .tSisma(i).Visible = False
                '                .rtfSisma(i).Visible = False
                '                .lsSisma(i).Visible = False
                '                .lSisma(i).Visible = False
                '                Next
                Inizializzando = False
            Catch e As Exception
                MsgBox(e.Message + vbCrLf + e.StackTrace)
            End Try
        End With
    End Sub
    Friend Sub IniziaSismaT()
        Dim strFile As String = Monitor.Motore.Inizio.Archdir & "\WR\NormeSisma.INI"
        If Problem.NormeSisma Is Nothing Then SetNormeSisma(False)
        If Problem.NormeSisma = "" Then Problem.NormeSisma = "not applicable" : SetNormeSisma(False)
        With frmSaddles.DefInstance
            If Problem.NormeSisma = "not applicable" Then
                Inizializzando = True
                .TabCarFondUp.Controls.Remove(.PagCarichifinaliT)
                Try
                    .TabCarFondUp.Controls.Remove(.PagSismaT)
                Catch
                End Try
                .TabCarFondUp.Controls.Add(.PagCarichifinaliT)
                Inizializzando = False
                EliminatoSisma = True
                Exit Sub
            Else
                If EliminatoSisma Then
                    Inizializzando = True
                    .TabCarFondUp.Controls.Remove(.PagCarichifinaliT)
                    .TabCarFondUp.Controls.Add(.PagSismaT)
                    .TabCarFondUp.Controls.Add(.PagCarichifinaliT)
                    Inizializzando = False
                End If
                EliminatoSisma = False
            End If
            Dim strF As String = Monitor.Motore.Inizio.ReadIniFile(strFile, Problem.NormeSisma, "F")
            Dim strFormula As String = Monitor.Motore.Inizio.ReadIniFile(strFile, Problem.NormeSisma, "Formula")
            Dim strFsplit() As String = strF.Split(CChar(","))
            Dim strV As String
            Dim strVsplit() As String
            Dim Variabile As String
            Dim i As Integer
            Inizializzando = True
            Try
                .lSismaT.RemoveAll(1)
                .lsSismaT.RemoveAll(1)
                .rtfSismaT.RemoveAll(1)
                .tSismaT.RemoveAll(1)
                .rtfFormulaSismaT.Rtf = strFormula
                Espressionep = GlobalRoutines.ConvertiPunto(strFsplit(0))
                Calc.calc_scan(Espressionep, TokensS)
                If strFsplit(1).IndexOf("rtf1") = -1 Then
                    .rtfForceSeismT.Text = strFsplit(1)
                Else
                    .rtfForceSeismT.Rtf = strFsplit(1)
                End If
                Dim Enumerator As IEnumerator = TokensS.GetEnumerator
                While Enumerator.MoveNext
                    If CType(Enumerator.Current, FormulaParser.mcSymbol).Cls = FormulaParser.mcCalc.TOKENCLASS.IDENTIFIER Then
                        Variabile = CType(Enumerator.Current, FormulaParser.mcSymbol).Token
                        If Variabile = "Wp" Then
                        Else
                            strV = Monitor.Motore.Inizio.ReadIniFile(strFile, Problem.NormeSisma, Variabile)
                            strVsplit = strV.Split(CChar(","))
                            If i > 0 Then .lSismaT.Load(i)
                            .lSismaT(i).Text = strVsplit(0)
                            .lSismaT(i).Visible = True
                            If i > 0 Then .lSismaT(i).Top = .lSismaT(i - 1).Top + .lSismaT(i).Height
                            If i > 0 Then .lsSismaT.Load(i)
                            .lsSismaT(i).Text = Variabile
                            .lsSismaT(i).Visible = True
                            If i > 0 Then .lsSismaT(i).Top = .lsSismaT(i - 1).Top + .lsSismaT(i).Height
                            If i > 0 Then .rtfSismaT.Load(i)
                            If strVsplit(1).IndexOf("rtf1") = -1 Then
                                .rtfSismaT(i).Text = strVsplit(1)
                            Else
                                .rtfSismaT(i).Rtf = strVsplit(1)
                            End If
                            .rtfSismaT(i).Visible = True
                            If i > 0 Then .rtfSismaT(i).Top = .rtfSismaT(i - 1).Top + .rtfSismaT(i).Height
                            If i > 0 Then .tSismaT.Load(i)
                            If CambiataNormaSisma Or Problem.ParamS(i) = 0 Then
                                .tSismaT(i).Text = GlobalRoutines.ConvertiPunto(strVsplit(2))
                                Problem.ParamS(i) = GlobalRoutines.ValVir(.tSismaT(i).Text)
                                CambiataNormaSisma = False
                            Else
                                .tSismaT(i).Text = GlobalRoutines.FormatS(FormSng2, Problem.ParamS(i))
                            End If
                            .tSismaT(i).Visible = True
                            If i > 0 Then .tSismaT(i).Top = .tSismaT(i - 1).Top + .tSismaT(i).Height
                            i += 1
                        End If
                    End If
                End While
                .lblCodiceSismaT.Text = Problem.NormeSisma
                Inizializzando = False
            Catch e As Exception
                MsgBox(e.Message + vbCrLf + e.StackTrace)
            End Try
        End With
    End Sub
    Friend Sub RicalcolaVento()
        Dim i As Short
        Dim p, F As Double
        If EliminatoVento Then Exit Sub
        With frmSaddles.DefInstance
            For i = 0 To CShort(.tVento.Count - 1)
                AggiornaToken(i)
            Next
            Try
                p = Calc.level0(CType(Tokensp.Clone, Queue))  'evaluate(Espressionep)
                F = Calc.level0(CType(TokensF.Clone, Queue)) * p
            Catch e As Exception
                MsgBox(e.Message + e.StackTrace)
            End Try
            .txtPressure.Text = GlobalRoutines.FormatS(FormSng2, p)
            If .txtLateralArea.Text = "" Then .txtLateralArea.Text = "0"
            If .txtFrontArea.Text = "" Then .txtFrontArea.Text = "0"
            .txtLateralForce.Text = GlobalRoutines.FormatS(FormSng2, F * CSng(.txtLateralArea.Text))
            .txtFrontForce.Text = GlobalRoutines.FormatS(FormSng2, F * CSng(.txtFrontArea.Text))
        End With
    End Sub
    Friend Sub RicalcolaVentoT()
        Dim i As Short
        Dim p, F As Double
        If EliminatoVento Then Exit Sub
        With frmSaddles.DefInstance
            For i = 0 To CShort(.tVentoT.Count - 1)
                AggiornaTokenT(i)
            Next
            Try
                p = Calc.level0(CType(Tokensp.Clone, Queue))  'evaluate(Espressionep)
                F = Calc.level0(CType(TokensF.Clone, Queue)) * p
            Catch e As Exception
                MsgBox(e.Message + e.StackTrace)
            End Try
            .txtPressureT.Text = GlobalRoutines.FormatS(FormSng2, p)
            If .txtLateralAreaT.Text = "" Then .txtLateralAreaT.Text = "0"
            If .txtFrontAreaT.Text = "" Then .txtFrontAreaT.Text = "0"
            .txtLateralForceT.Text = GlobalRoutines.FormatS(FormSng2, F * CSng(.txtLateralAreaT.Text))
            .txtFrontForceT.Text = GlobalRoutines.FormatS(FormSng2, F * CSng(.txtFrontAreaT.Text))
        End With
    End Sub
    Friend Sub RicalcolaSisma()
        Dim i As Short
        Dim F As Double
        If EliminatoSisma Then Exit Sub
        With frmSaddles.DefInstance
            For i = 0 To CShort(.tSisma.Count - 1)
                AggiornaTokenS(i)
            Next
            Try
                F = Calc.level0(CType(TokensS.Clone, Queue))
            Catch e As Exception
                MsgBox(e.Message + e.StackTrace)
            End Try
            .txtForceSeism.Text = GlobalRoutines.FormatS(FormSng2, F * LoadFoundData.Pesi(1))
        End With
    End Sub
    Friend Sub RicalcolaSismaT()
        Dim i As Short
        Dim F As Double
        If EliminatoSisma Then Exit Sub
        With frmSaddles.DefInstance
            For i = 0 To CShort(.tSismaT.Count - 1)
                AggiornaTokenST(i)
            Next
            Try
                F = Calc.level0(CType(TokensS.Clone, Queue))
            Catch e As Exception
                MsgBox(e.Message + e.StackTrace)
            End Try
            .txtForceSeismT.Text = GlobalRoutines.FormatS(FormSng2, F * LoadFoundDataT.Pesi(1))
        End With
    End Sub
    Private Sub AggiornaToken(ByVal i As Short)
        Dim Variabile As String
        Dim Symbol As FormulaParser.mcSymbol
        Dim Enumerator As IEnumerator = Tokensp.GetEnumerator
        Try
            While Enumerator.MoveNext
                Symbol = CType(Enumerator.Current, FormulaParser.mcSymbol)
                If Symbol.Cls = FormulaParser.mcCalc.TOKENCLASS.IDENTIFIER Then
                    Variabile = Symbol.Token
                    If Variabile = frmSaddles.DefInstance.lsVento(i).Text Then
                        Symbol.Value = GlobalRoutines.ValVir(frmSaddles.DefInstance.tVento(i).Text)
                        Exit Sub
                    End If
                End If
            End While
            Enumerator = TokensF.GetEnumerator
            While Enumerator.MoveNext
                Symbol = CType(Enumerator.Current, FormulaParser.mcSymbol)
                If Symbol.Cls = FormulaParser.mcCalc.TOKENCLASS.IDENTIFIER Then
                    Variabile = Symbol.Token
                    If Variabile = frmSaddles.DefInstance.lsVento(i).Text Then
                        Symbol.Value = GlobalRoutines.ValVir(frmSaddles.DefInstance.tVento(i).Text)
                        Exit Sub
                    End If
                End If
            End While
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Private Sub AggiornaTokenT(ByVal i As Short)
        Dim Variabile As String
        Dim Symbol As FormulaParser.mcSymbol
        Dim Enumerator As IEnumerator = Tokensp.GetEnumerator
        Try
            While Enumerator.MoveNext
                Symbol = CType(Enumerator.Current, FormulaParser.mcSymbol)
                If Symbol.Cls = FormulaParser.mcCalc.TOKENCLASS.IDENTIFIER Then
                    Variabile = Symbol.Token
                    If Variabile = frmSaddles.DefInstance.lsVentoT(i).Text Then
                        Symbol.Value = GlobalRoutines.ValVir(frmSaddles.DefInstance.tVentoT(i).Text)
                        Exit Sub
                    End If
                End If
            End While
            Enumerator = TokensF.GetEnumerator
            While Enumerator.MoveNext
                Symbol = CType(Enumerator.Current, FormulaParser.mcSymbol)
                If Symbol.Cls = FormulaParser.mcCalc.TOKENCLASS.IDENTIFIER Then
                    Variabile = Symbol.Token
                    If Variabile = frmSaddles.DefInstance.lsVentoT(i).Text Then
                        Symbol.Value = GlobalRoutines.ValVir(frmSaddles.DefInstance.tVentoT(i).Text)
                        Exit Sub
                    End If
                End If
            End While
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Private Sub AggiornaTokenS(ByVal i As Short)
        Dim Variabile As String
        Dim Symbol As FormulaParser.mcSymbol
        Dim Enumerator As IEnumerator = TokensS.GetEnumerator
        While Enumerator.MoveNext
            Symbol = CType(Enumerator.Current, FormulaParser.mcSymbol)
            If Symbol.Cls = FormulaParser.mcCalc.TOKENCLASS.IDENTIFIER Then
                Variabile = Symbol.Token
                If Variabile = frmSaddles.DefInstance.lsSisma(i).Text Then
                    Symbol.Value = GlobalRoutines.ValVir(frmSaddles.DefInstance.tSisma(i).Text)
                    Exit Sub
                End If
            End If
        End While
    End Sub
    Private Sub AggiornaTokenST(ByVal i As Short)
        Dim Variabile As String
        Dim Symbol As FormulaParser.mcSymbol
        Dim Enumerator As IEnumerator = TokensS.GetEnumerator
        While Enumerator.MoveNext
            Symbol = CType(Enumerator.Current, FormulaParser.mcSymbol)
            If Symbol.Cls = FormulaParser.mcCalc.TOKENCLASS.IDENTIFIER Then
                Variabile = Symbol.Token
                If Variabile = frmSaddles.DefInstance.lsSismaT(i).Text Then
                    Symbol.Value = GlobalRoutines.ValVir(frmSaddles.DefInstance.tSismaT(i).Text)
                    Exit Sub
                End If
            End If
        End While
    End Sub
    Friend Sub ControllaDati2()
        Dim Uguale As Boolean
        Dim FixSli(2) As String
        Dim Forze(6) As Single
        Dim i As Short
        Dim Msgg As String
        FixSli(1) = "fissa" : FixSli(2) = "mobile"
        'SaddlesItem.GeomSadd(iSadd).SaddHeight
        'xSupportItem(iSadd).RibsThk,material
        If iSadd = 2 Then
            If xSupport(iSadd).SaddlLength = 0 Then xSupport(iSadd).SaddlLength = xSupport(1).SaddlLength
            If xSupportData(iSadd, iCond).Allow = 0 Then xSupportData(iSadd, iCond).Allow = xSupportData(1, iCond).Allow
            If Len(RTrim(xSupport(iSadd).material)) = 0 Then xSupport(iSadd).material = xSupport(1).material
            If xSupport(iSadd).NumeroRibs = 0 Then xSupport(iSadd).NumeroRibs = xSupport(1).NumeroRibs
            If xSupport(iSadd).NumeroRibs = xSupport(1).NumeroRibs Then
                For i = 1 To CShort(xSupport(iSadd).NumeroRibs \ 2)
                    If xSupport(iSadd).Dist(i) = 0 Then xSupport(iSadd).Dist(i) = xSupport(1).Dist(i)
                Next
            End If
        End If
        Uguale = True
        Try
            If xSupport(iSadd).SaddlWidth > 0 Then Uguale = Uguale And System.Math.Abs(SaddlesItem.GeomSadd(iSadd).AxialWidth - xSupport(iSadd).SaddlWidth) / xSupport(iSadd).SaddlWidth < 0.01
            If xSupport(iSadd).SaddlThk > 0 Then Uguale = Uguale And (System.Math.Abs(SaddlesItem.GeomSadd(iSadd).SaddlThk - xSupport(iSadd).SaddlThk) / xSupport(iSadd).SaddlThk < 0.01)
            '   Uguale = Uguale And (Abs(SaddlesItem.GeomSadd(iSadd).PlateWidth - xSupport(iSadd).SaddlLength) / xSupport(iSadd).SaddlLength < 0.01)
            '   Uguale = Uguale And (Abs(SaddlesLoad(iCond).AmmSadd(iSadd) - xSupportData(iSadd, iCond).Allow) / xSupportData(iSadd, iCond).Allow < 0.01)
            If Not Uguale Then
                If Problem.LoadCond(2, iCond + 1).Trim = "" Then Problem.LoadCond(2, iCond + 1) = "Senza nome"
                Msgg = "Condizione di carico: " & RTrim(Problem.LoadCond(2, iCond + 1)) & ". Sella " & FixSli(iSadd) & vbCrLf
                Msgg = Msgg & "Alcuni dati non sono congruenti tra calcolo 'Zick' e calcolo delle selle." & vbCrLf
                Msgg = Msgg & "Vuoi correggere i dati relativi al calcolo selle in conformità ai dati del calcolo 'Zick'?"
                If MsgBox(Msgg, MsgBoxStyle.Question Or MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then Trasfer(1)
            End If
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
        If Not LoadsCalcolate Then Exit Sub
        Call CalcForze(Forze, 2)
        Uguale = True
        Try
            With xSupportData(iSadd, iCond)
                If .NormalForce <> 0 Then Uguale = Uguale And System.Math.Abs(System.Math.Abs(Forze(3) - .NormalForce) / .NormalForce) < 0.01
                If .ShearLong <> 0 Then Uguale = Uguale And (System.Math.Abs(System.Math.Abs(Forze(1) - .ShearLong) / .ShearLong) < 0.01)
                If .ShearTrasv <> 0 Then Uguale = Uguale And (System.Math.Abs(System.Math.Abs(Forze(2) - .ShearTrasv) / .ShearTrasv) < 0.01)
                If .MomTrasv <> 0 Then Uguale = Uguale And (System.Math.Abs(System.Math.Abs(Forze(4) - .MomTrasv) / .MomTrasv) < 0.01)
                If iSadd = 1 Then
                    If .MomLong <> 0 Then Uguale = Uguale And (System.Math.Abs(System.Math.Abs(Forze(5) - .MomLong) / .MomLong) < 0.01)
                Else
                    If .MomLong <> 0 Then Uguale = Uguale And System.Math.Abs(.MomLong) < 0.01
                End If
                If Not Uguale Then
                    If Problem.LoadCond(2, iCond + 1).Trim = "" Then Problem.LoadCond(2, iCond + 1) = "Senza nome"
                    Msgg = "Condizione di carico: " & RTrim(Problem.LoadCond(2, iCond + 1)) & ". Sella " & FixSli(iSadd) & vbCrLf
                    Msgg = Msgg & "I dati di carico non sono congruenti con i carichi sulle fondazioni." & vbCrLf
                    Msgg = Msgg & "Vuoi correggere i dati relativi al calcolo selle in conformità ai carichi sulle fondazioni?"
                    If MsgBox(Msgg, MsgBoxStyle.Question Or MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then Trasfer1(Forze, 1)
                ElseIf .NormalForce = 0 And .ShearLong = 0 And .ShearTrasv = 0 Then
                    Trasfer1(Forze, 1)
                End If
            End With
        Catch e As Exception
            MsgBox(e.message + vbCrLf + e.stacktrace)
        End Try
    End Sub
    Friend Sub ControllaDati2T()
        Dim Uguale As Boolean
        Dim FixSli(2) As String
        Dim Forze(6) As Single
        Dim i As Short
        Dim Msgg As String
        FixSli(1) = "fissa" : FixSli(2) = "mobile"
        If iSadd = 2 Then
            If xSupportT(iSadd).SaddlLength = 0 Then xSupportT(iSadd).SaddlLength = xSupportT(1).SaddlLength
            If xSupportDataT(iSadd, iCond).Allow = 0 Then xSupportDataT(iSadd, iCond).Allow = xSupportDataT(1, iCond).Allow
            If Len(RTrim(xSupportT(iSadd).material)) = 0 Then xSupportT(iSadd).material = xSupportT(1).material
            If xSupportT(iSadd).NumeroRibs = 0 Then xSupportT(iSadd).NumeroRibs = xSupportT(1).NumeroRibs
            If xSupportT(iSadd).NumeroRibs = xSupportT(1).NumeroRibs Then
                For i = 1 To CShort(xSupportT(iSadd).NumeroRibs \ 2)
                    If xSupportT(iSadd).Dist(i) = 0 Then xSupportT(iSadd).Dist(i) = xSupportT(1).Dist(i)
                Next
            End If
        End If
        Uguale = True
        Try
            If xSupportT(iSadd).SaddlWidth > 0 Then Uguale = Uguale And System.Math.Abs(SaddlesItemT.GeomSadd(iSadd).AxialWidth - xSupportT(iSadd).SaddlWidth) / xSupportT(iSadd).SaddlWidth < 0.01
            If xSupportT(iSadd).SaddlThk > 0 Then Uguale = Uguale And (System.Math.Abs(SaddlesItemT.GeomSadd(iSadd).SaddlThk - xSupportT(iSadd).SaddlThk) / xSupportT(iSadd).SaddlThk < 0.01)
            If Not Uguale Then
                If Problem.LoadCond(2, iCond + 1).Trim = "" Then Problem.LoadCond(2, iCond + 1) = "Senza nome"
                Msgg = "Condizione di carico: " & RTrim(Problem.LoadCond(2, iCond + 1)) & ". Sella " & FixSli(iSadd) & vbCrLf
                Msgg = Msgg & "Alcuni dati non sono congruenti tra calcolo 'Zick' e calcolo delle selle." & vbCrLf
                Msgg = Msgg & "Vuoi correggere i dati relativi al calcolo selle in conformità ai dati del calcolo 'Zick'?"
                If MsgBox(Msgg, MsgBoxStyle.Question Or MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then Trasfer(2)
            End If
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
        If Not LoadsCalcolate Then Exit Sub
        Call CalcForzeT(Forze, 2)
        Uguale = True
        Try
            With xSupportDataT(iSadd, iCond)
                If .NormalForce <> 0 Then Uguale = Uguale And System.Math.Abs(System.Math.Abs(Forze(3) - .NormalForce) / .NormalForce) < 0.01
                If .ShearLong <> 0 Then Uguale = Uguale And (System.Math.Abs(System.Math.Abs(Forze(1) - .ShearLong) / .ShearLong) < 0.01)
                If .ShearTrasv <> 0 Then Uguale = Uguale And (System.Math.Abs(System.Math.Abs(Forze(2) - .ShearTrasv) / .ShearTrasv) < 0.01)
                If .MomTrasv <> 0 Then Uguale = Uguale And (System.Math.Abs(System.Math.Abs(Forze(4) - .MomTrasv) / .MomTrasv) < 0.01)
                If iSadd = 1 Then
                    If .MomLong <> 0 Then Uguale = Uguale And (System.Math.Abs(System.Math.Abs(Forze(5) - .MomLong) / .MomLong) < 0.01)
                Else
                    If .MomLong <> 0 Then Uguale = Uguale And System.Math.Abs(.MomLong) < 0.01
                End If
                If Not Uguale Then
                    If Problem.LoadCond(2, iCond + 1).Trim = "" Then Problem.LoadCond(2, iCond + 1) = "Senza nome"
                    Msgg = "Condizione di carico: " & RTrim(Problem.LoadCond(2, iCond + 1)) & ". Sella " & FixSli(iSadd) & vbCrLf
                    Msgg = Msgg & "I dati di carico non sono congruenti con i carichi sulle fondazioni." & vbCrLf
                    Msgg = Msgg & "Vuoi correggere i dati relativi al calcolo selle in conformità ai carichi sulle fondazioni?"
                    If MsgBox(Msgg, MsgBoxStyle.Question Or MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then Trasfer1(Forze, 2)
                ElseIf .NormalForce = 0 And .ShearLong = 0 And .ShearTrasv = 0 Then
                    Trasfer1(Forze, 2)
                End If
            End With
        Catch e As Exception
            MsgBox(e.message + vbCrLf + e.stacktrace)
        End Try
    End Sub
    Private Sub Trasfer1(ByVal Forze() As Single, ByVal iBtmTop As Short)
        pxSupportData(iSadd, iCond, iBtmTop).NormalForce = Forze(3)
        pxSupportData(iSadd, iCond, iBtmTop).ShearLong = Forze(1)
        pxSupportData(iSadd, iCond, iBtmTop).ShearTrasv = Forze(2)
        If iSadd = 1 Then
            pxSupportData(iSadd, iCond, iBtmTop).MomLong = Forze(5)
        Else
            pxSupportData(iSadd, iCond, iBtmTop).MomLong = 0
        End If
        pxSupportData(iSadd, iCond, iBtmTop).MomTrasv = Forze(4)
    End Sub
    Private Sub Trasfer(ByVal iBtmTop As Short)
        pxSupport(iSadd, iBtmTop).SaddlWidth = pSaddlesItem(iBtmTop).GeomSadd(iSadd).AxialWidth
        pxSupport(iSadd, iBtmTop).SaddlThk = pSaddlesItem(iBtmTop).GeomSadd(iSadd).SaddlThk
    End Sub
    Public Function CalcForze(ByRef Forze() As Single, ByRef TipCalc As Short) As Boolean
        'vero se bisogna riversare i dati
        Dim j, k As Short
        Dim Forze1(6) As Single
        Dim Tuttozero, Diverso As Boolean
        Dim n1 As Short
        Tuttozero = True
        Diverso = False
        n1 = 6 : If TipCalc = 3 Then n1 = 5
        For j = 1 To n1
            For k = 1 To Problem.NumCondElem
                If j = 5 Then
                    Forze1(j) = Forze1(j) + LoadFoundData.Sforzi(iSadd).f(k, 1) * Problem.LoadCase(TipCalc, iCond + 1, k) * SaddlesItem.GeomSadd(iSadd).SaddHeight / 1000
                Else
                    If j = 1 And iSadd = 2 And TipCalc = 3 Then
                        Forze1(j) = 0
                    Else
                        Forze1(j) = Forze1(j) + LoadFoundData.Sforzi(iSadd).f(k, j) * Problem.LoadCase(TipCalc, iCond + 1, k)
                    End If
                End If
            Next k
            Tuttozero = Tuttozero And Forze(j) = 0
            Diverso = Diverso Or Forze(j) <> Forze1(j)
        Next j
        For j = 1 To n1
            Forze(j) = Forze1(j)
        Next
        If Not Diverso Or Not Tuttozero Then Return False Else Return True
    End Function
    Public Function CalcForzeT(ByRef Forze() As Single, ByRef TipCalc As Short) As Boolean
        'vero se bisogna riversare i dati
        Dim j, k As Short
        Dim Forze1(6) As Single
        Dim Tuttozero, Diverso As Boolean
        Dim n1 As Short
        Tuttozero = True
        Diverso = False
        n1 = 6 : If TipCalc = 3 Then n1 = 5
        For j = 1 To n1
            For k = 1 To Problem.NumCondElem
                If j = 5 Then
                    Forze1(j) = Forze1(j) + LoadFoundDataT.Sforzi(iSadd).f(k, 1) * Problem.LoadCase(TipCalc, iCond + 1, k) * SaddlesItemT.GeomSadd(iSadd).SaddHeight / 1000
                Else
                    If j = 1 And iSadd = 2 And TipCalc = 3 Then
                        Forze1(j) = 0
                    Else
                        Forze1(j) = Forze1(j) + LoadFoundDataT.Sforzi(iSadd).f(k, j) * Problem.LoadCase(TipCalc, iCond + 1, k)
                    End If
                End If
            Next k
            Tuttozero = Tuttozero And Forze(j) = 0
            Diverso = Diverso Or Forze(j) <> Forze1(j)
        Next j
        For j = 1 To n1
            Forze(j) = Forze1(j)
        Next
        If Not Diverso Or Not Tuttozero Then Return False Else Return True
    End Function

    Public Sub ControllaDati3()
        Dim Uguale As Boolean
        Dim FixSli(2) As String
        Dim Forze(7) As Single
        Dim i As Short
        Dim A1 As Single
        Dim Msgg As String
        Dim w As Single
        Dim Ans As Integer
        FixSli(1) = "fissa" : FixSli(2) = "mobile"
        Try
            If xSupport(iSadd).Dist(1) > 0 Then
                For i = 1 To CShort(xSupport(iSadd).NumeroRibs \ 2)
                    If i = 1 Then
                        A1 = xSupport(iSadd).Dist(1)
                        If xSupport(iSadd).NumeroRibs Mod 2 = 0 Then A1 = A1 * 2
                    Else
                        If (xSupport(iSadd).Dist(i) - xSupport(iSadd).Dist(i - 1)) > A1 Then A1 = xSupport(iSadd).Dist(i) - xSupport(iSadd).Dist(i - 1)
                    End If
                Next
                A1 = A1 - xSupport(iSadd).RibsThk
                w = xSupport(iSadd).SaddlWidth - xSupport(iSadd).RibsThk
                If xSupport(iSadd).Tipo = "I" Then w = w / 2
                If Problem.Verbose Then
                    If (A1 <> xFondaItem(iSadd).A1 Or w <> xFondaItem(iSadd).B1) And iCond = 0 Then
                        Msgg = "Sella " & FixSli(iSadd) & "  --------------------------------------------------" & vbCrLf
                        Msgg = Msgg & "Le dimensioni delle luci attorno ai bulloni non sono congruenti." & vbCrLf
                        Msgg = Msgg & "Luce trasversale (risp. asse apparecchio):" & Chr(9) & Chr(9) & "'Support' : " & GlobalRoutines.FormatS("####", A1) & Chr(9) & " 'Fonda' : " & GlobalRoutines.FormatS("####", xFondaItem(iSadd).A1) & vbCrLf
                        Msgg = Msgg & "Luce longitudinale (risp. asse apparecchio):" & Chr(9) & "'Support' : " & GlobalRoutines.FormatS("####", xSupport(iSadd).SaddlWidth) & Chr(9) & " 'Fonda' : " & GlobalRoutines.FormatS("####", xFondaItem(iSadd).B1) & vbCrLf
                        Msgg = Msgg & "Vuoi riportare in 'Fonda' i valori di 'Support' ?"
                        If MsgBox(Msgg, MsgBoxStyle.Question Or MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                            xFondaItem(iSadd).A1 = A1
                            xFondaItem(iSadd).B1 = w
                        End If
                    End If
                End If
            End If
            If xFondaItem(iSadd).Rm = 0 Then xFondaItem(iSadd).Rm = 10
            If xFondaItem(iSadd).nc = 0 Then xFondaItem(iSadd).nc = 2
            If xFondaData(iSadd, iCond).alc = 0 Then xFondaData(iSadd, iCond).alc = 5
            If xFondaItem(iSadd).a = 0 Then xFondaItem(iSadd).a = xSupport(iSadd).SaddlLength
            If xFondaItem(iSadd).b = 0 Then xFondaItem(iSadd).b = xSupport(iSadd).SaddlWidth
            If xFondaItem(iSadd).SP = 0 Then xFondaItem(iSadd).SP = xSupport(iSadd).SaddlThk
            If xSupport(iSadd).material Is Nothing Then xSupport(iSadd).material = ""
            If xFondaItem(iSadd).BaseMat Is Nothing Then xFondaItem(iSadd).BaseMat = xSupport(iSadd).material
            If xFondaItem(iSadd).BaseMat.Trim.Length = 0 Then xFondaItem(iSadd).BaseMat = xSupport(iSadd).material
            Try
                If xFondaData(iSadd, iCond).albp = 0 Then xFondaData(iSadd, iCond).albp = xSupportData(iSadd, iCond).Allow
            Catch e As Exception
                MsgBox(e.Message)
            End Try
            If iSadd = 2 Then
                If xFondaItem(iSadd).A1 = 0 Then xFondaItem(iSadd).A1 = xFondaItem(1).A1
                If xFondaItem(iSadd).B1 = 0 Then xFondaItem(iSadd).B1 = xFondaItem(1).B1
                If xFondaItem(iSadd).an = 0 Then xFondaItem(iSadd).an = xFondaItem(1).an
                If xFondaItem(iSadd).ag = 0 Then xFondaItem(iSadd).ag = xFondaItem(1).ag
                If xFondaItem(iSadd).nt = 0 Then xFondaItem(iSadd).nt = xFondaItem(1).nt
                If xFondaData(iSadd, iCond).alb = 0 Then xFondaData(iSadd, iCond).alb = xFondaData(1, iCond).alb
                If xFondaData(iSadd, iCond).albs = 0 Then xFondaData(iSadd, iCond).albs = xFondaData(1, iCond).albs
                If xFondaItem(iSadd).BoltMat Is Nothing Then xFondaItem(iSadd).BoltMat = ""
                If iSadd > 1 Then If xFondaItem(iSadd).BoltMat.Trim.Length = 0 Then xFondaItem(iSadd).BoltMat = xFondaItem(1).BoltMat
                If xFondaItem(iSadd).BoltSize Is Nothing Then xFondaItem(iSadd).BoltSize = ""
                If iSadd > 1 Then If xFondaItem(iSadd).BoltSize.Trim.Length = 0 Then xFondaItem(iSadd).BoltSize = xFondaItem(1).BoltSize
                If xFondaItem(iSadd).nt = xFondaItem(1).nt Then
                    For i = 1 To xFondaItem(iSadd).nt
                        If xFondaItem(iSadd).xQuota(i) = 0 Then xFondaItem(iSadd).xQuota(i) = xFondaItem(1).xQuota(i)
                        If xFondaItem(iSadd).yQuota(i) = 0 Then xFondaItem(iSadd).yQuota(i) = xFondaItem(1).yQuota(i)
                    Next
                End If
            End If
            If Not LoadsCalcolate Then Exit Sub
            Forze(1) = xFondaData(iSadd, iCond).sfx
            Forze(2) = xFondaData(iSadd, iCond).sfy
            Forze(3) = xFondaData(iSadd, iCond).n
            Forze(5) = xFondaData(iSadd, iCond).my
            Forze(4) = xFondaData(iSadd, iCond).mx
            Call CalcForze(Forze, 3)
            Uguale = True
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
        Try
            Uguale = True
            If xFondaData(iSadd, iCond).n <> 0 Then Uguale = Uguale And System.Math.Abs(System.Math.Abs(Forze(3) - xFondaData(iSadd, iCond).n) / xFondaData(iSadd, iCond).n) < 0.01
            If xFondaData(iSadd, iCond).sfy <> 0 Then Uguale = Uguale And (System.Math.Abs(System.Math.Abs(Forze(2) - xFondaData(iSadd, iCond).sfy) / xFondaData(iSadd, iCond).sfy) < 0.01)
            If xFondaData(iSadd, iCond).sfx <> 0 Then Uguale = Uguale And (System.Math.Abs(System.Math.Abs(Forze(1) - xFondaData(iSadd, iCond).sfx) / xFondaData(iSadd, iCond).sfx) < 0.01)
            If iSadd = 1 Then
                If xFondaData(iSadd, iCond).my <> 0 Then Uguale = Uguale And (System.Math.Abs(System.Math.Abs(Forze(5) - xFondaData(iSadd, iCond).my) / xFondaData(iSadd, iCond).my) < 0.01)
            Else
                If xFondaData(iSadd, iCond).my <> 0 Then Uguale = Uguale And System.Math.Abs(xFondaData(iSadd, iCond).my) < 0.01
            End If
            If xFondaData(iSadd, iCond).mx <> 0 Then Uguale = Uguale And (System.Math.Abs(System.Math.Abs(Forze(4) - xFondaData(iSadd, iCond).mx) / xFondaData(iSadd, iCond).mx) < 0.01)
            If Not Uguale Then
                If Problem.LoadCond(3, iCond + 1).Trim.Length = 0 Then Problem.LoadCond(3, iCond + 1) = "Senza nome"
                Msgg = "Condizione di carico: " & RTrim(Problem.LoadCond(3, iCond + 1)) & ". Sella " & FixSli(iSadd) & vbCrLf
                Msgg = Msgg & "I dati di carico non sono congruenti con i carichi sulle fondazioni." & vbCrLf
                Msgg = Msgg & "Vuoi correggere i dati relativi al calcolo selle in conformità ai carichi sulle fondazioni?"
                If Problem.Verbose Then
                    Ans = MsgBox(Msgg, MsgBoxStyle.Question Or MsgBoxStyle.YesNo)
                Else
                    Ans = MsgBoxResult.Yes
                End If
                If Ans = MsgBoxResult.Yes Then Trasfer3(Forze)
            End If
        Catch e As Exception
            MsgBox(e.message + vbCrLf + e.stacktrace)
        End Try
    End Sub
    Friend Sub Trasfer3(ByVal Forze() As Single)
        xFondaData(iSadd, iCond).n = Forze(3)
        xFondaData(iSadd, iCond).sfy = Forze(2)
        xFondaData(iSadd, iCond).sfx = Forze(1)
        If iSadd = 1 Then
            xFondaData(iSadd, iCond).my = Forze(5)
        Else
            xFondaData(iSadd, iCond).my = 0
        End If
        xFondaData(iSadd, iCond).mx = Forze(4)
    End Sub
    Sub CalcK(ByRef i As Short, ByRef K1(,) As Single, ByRef k2(,) As Single, _
              ByVal iBtmTop As Short)
        Dim IDG1, IDG, k As Short
        For k = 0 To 1
3270:       If pSaddlesItem(iBtmTop).Lungh(i) > pSaddlesItem(iBtmTop).MeanR(i) / 2 Then
3350:           If pSaddlesItem(iBtmTop).GeomSadd(i).IncluAngle > ANG(1) Then GoTo 3370
3360:           K1(i, k) = 0.107 : k2(i, k) = 0.192 : GoTo 3291
3370:           If pSaddlesItem(iBtmTop).GeomSadd(i).IncluAngle >= ANG(3) Then
3460:               K1(i, k) = 0.161 : k2(i, k) = 0.279
                Else
3380:               For IDG = 2 To 3
3390:                   If pSaddlesItem(iBtmTop).GeomSadd(i).IncluAngle < ANG(IDG) Then
3400:                       IDG1 = CShort(IDG - 1)
3410:                       K1(i, k) = KK1(IDG1) + (pSaddlesItem(iBtmTop).GeomSadd(i).IncluAngle - ANG(IDG1)) / (ANG(IDG) - ANG(IDG1)) * (KK1(IDG) - KK1(IDG1))
3420:                       k2(i, k) = KK2(IDG1) + (pSaddlesItem(iBtmTop).GeomSadd(i).IncluAngle - ANG(IDG1)) / (ANG(IDG) - ANG(IDG1)) * (KK2(IDG) - KK2(IDG1))
3430:                       Exit For
                        End If
3440:               Next IDG
                End If
            Else
3280:           K1(i, k) = 1 : k2(i, k) = 1
3290:       End If
3291:   Next k
    End Sub

    Sub CalcK34(ByRef i As Short, ByRef K3() As Single, ByRef K4() As Single, _
                ByVal iBtmTop As Short)
        Dim Testo As String
3580:   If pSaddlesItem(iBtmTop).Lungh(i) > pSaddlesItem(iBtmTop).MeanR(i) / 2 Then GoTo 3770
3590:   If pSaddlesItem(iBtmTop).GeomSadd(i).IncluAngle > 120 Then GoTo 3620
3600:   K3(i) = 0.88 : K4(i) = 0.88
3610:   If pSaddlesItem(iBtmTop).Lungh(i) > pSaddlesItem(iBtmTop).GeomSadd(i).AxialWidth Then K4(i) = 0.401 : GoTo 3730
3620:   If pSaddlesItem(iBtmTop).GeomSadd(i).IncluAngle > 135 Then GoTo 3670
3630:   K3(i) = CSng(0.88 + (pSaddlesItem(iBtmTop).GeomSadd(i).IncluAngle - 120) / 15 * (0.654 - 0.88))
3640:   K4(i) = CSng(0.88 + (pSaddlesItem(iBtmTop).GeomSadd(i).IncluAngle - 120) / 15 * (0.654 - 0.88))
3650:   If pSaddlesItem(iBtmTop).Lungh(i) > pSaddlesItem(iBtmTop).GeomSadd(i).AxialWidth Then K4(i) = CSng(0.401 + (pSaddlesItem(iBtmTop).GeomSadd(i).IncluAngle - 120) / 15 * (0.344 - 0.401))
3660:   GoTo 3730
3670:   If pSaddlesItem(iBtmTop).GeomSadd(i).IncluAngle > 150 Then GoTo 3720
3680:   K3(i) = CSng(0.654 + (pSaddlesItem(iBtmTop).GeomSadd(i).IncluAngle - 135) / 15 * (0.485 - 0.654))
3690:   K4(i) = CSng(0.654 + (pSaddlesItem(iBtmTop).GeomSadd(i).IncluAngle - 135) / 15 * (0.485 - 0.654))
3700:   If pSaddlesItem(iBtmTop).Lungh(i) > pSaddlesItem(iBtmTop).GeomSadd(i).AxialWidth Then K4(i) = CSng(0.344 + (pSaddlesItem(iBtmTop).GeomSadd(i).IncluAngle - 135) / 15 * (0.295 - 0.344))
3710:   GoTo 3730
3720:   K3(i) = 0.485 : K4(i) = 0.485
        If pSaddlesItem(iBtmTop).Lungh(i) > pSaddlesItem(iBtmTop).GeomSadd(i).AxialWidth Then K4(i) = 0.295
3730:   pAreaLav(iCond, iBtmTop).ShearSaddle.SQ(i) = K3(i) * pAreaLav(iCond, iBtmTop).React(i) / (pSaddlesItem(iBtmTop).MeanR(i) * pSaddlesItem(iBtmTop).Spess(i))
        pAreaLav(iCond, iBtmTop).ShearSaddle.SQE(i) = 0
        If pSaddlesItem(iBtmTop).TipoChius(i) >= 1 Then
            If pSaddlesItem(iBtmTop).SpessHead(i) = 0 Then
                MsgBox("Non è stato definito lo spessore del fondo lato sella n°" & Str(i), MsgBoxStyle.Exclamation)
                Exit Sub
            End If
            pAreaLav(iCond, iBtmTop).ShearSaddle.SQE(i) = K4(i) * pAreaLav(iCond, iBtmTop).React(i) / (pSaddlesItem(iBtmTop).RHead(i) * pSaddlesItem(iBtmTop).SpessHead(i))
        End If
3760:   GoTo 3870
3770:   If pSaddlesItem(iBtmTop).GeomSadd(i).IncluAngle > 120 Then GoTo 3790
3780:   K3(i) = 1.171 : GoTo 3860
3790:   If pSaddlesItem(iBtmTop).GeomSadd(i).IncluAngle > 135 Then GoTo 3820
3800:   K3(i) = CSng(1.171 + (pSaddlesItem(iBtmTop).GeomSadd(i).IncluAngle - 120) / 15 * (0.958 - 1.171))
3810:   GoTo 3860
3820:   If pSaddlesItem(iBtmTop).GeomSadd(i).IncluAngle > 150 Then GoTo 3850
3830:   K3(i) = CSng(0.958 + (pSaddlesItem(iBtmTop).GeomSadd(i).IncluAngle - 135) / 15 * (0.799 - 0.958))
3840:   GoTo 3860
3850:   K3(i) = 0.799
3860:   pAreaLav(iCond, iBtmTop).ShearSaddle.SQ(i) = K3(i) * pAreaLav(iCond, iBtmTop).Taglio(i) / (pSaddlesItem(iBtmTop).MeanR(i) * pSaddlesItem(iBtmTop).Spess(i))
3870:   pAreaLav(iCond, iBtmTop).ShearSaddle.TANGS(i) = CSng(0.06 * pSaddlesLoad(iCond, iBtmTop).Young(i) * pSaddlesItem(iBtmTop).Spess(i) / pSaddlesItem(iBtmTop).MeanR(i))
        If pAreaLav(iCond, iBtmTop).ShearSaddle.TANGS(i) > 0.8 * pSaddlesLoad(iCond, iBtmTop).AmmShell(i) Then pAreaLav(iCond, iBtmTop).ShearSaddle.TANGS(i) = CSng(0.8 * pSaddlesLoad(iCond, iBtmTop).AmmShell(i))
3880:   pAreaLav(iCond, iBtmTop).ShearSaddle.TANGH(i) = CSng(1.25 * pSaddlesLoad(iCond, iBtmTop).AmmHead(i) - pSaddlesLoad(iCond, iBtmTop).AmmHeadTens(i))
        If pAreaLav(iCond, iBtmTop).ShearSaddle.TANGH(i) <= 0 And pSaddlesItem(iBtmTop).TipoChius(i) >= 1 Then
            Testo = "Il calcolo dell'ammissibile allo sforzo di taglio" & vbCrLf
            Testo = Testo & "nel fondo relativo alla sella n°" & Str(i) & "ha dato" & vbCrLf
            Testo = Testo & "un valore inaccettabile: " & GlobalRoutines.FormatS(FormSng2, pAreaLav(iCond, iBtmTop).ShearSaddle.TANGH(i)) & vbCrLf
            Testo = Testo & "Controllare i dati forniti per gli ammissibili relativi" & vbCrLf
            Testo = Testo & "alla condizione di carico" & Str(iCond)
            MsgBox(Testo, MsgBoxStyle.Critical)
        End If
        pAreaLav(iCond, iBtmTop).ShearSaddle.SQE(i) = 0
        If pSaddlesItem(iBtmTop).TipoChius(i) >= 1 And pSaddlesItem(iBtmTop).Lungh(i) <= pSaddlesItem(iBtmTop).MeanR(i) / 2 Then pAreaLav(iCond, iBtmTop).ShearSaddle.SQE(i) = K4(i) * pAreaLav(iCond, iBtmTop).React(i) / (pSaddlesItem(iBtmTop).RHead(i) * pSaddlesItem(iBtmTop).SpessHead(i))
    End Sub
    Public Sub StShearSaddles(ByVal iBtmTop As Short)
        Dim l2, R, h As Single
        Dim d1, d, f As Single
        Dim ls, l1, tau As Single
        h = 0
        If pSaddlesItem(iBtmTop).TipoChius(iSadd) >= 1 Then h = pSaddlesItem(iBtmTop).MeanR(iSadd) / 2
        R = pSaddlesItem(iBtmTop).MeanR(iSadd)
        l2 = pSaddlesItem(iBtmTop).Lungh(iSadd)
        d = pSaddlesItem(iBtmTop).Spess(iSadd)
        d1 = pSaddlesItem(iBtmTop).GeomSadd(iSadd).PlateThk
        l1 = pSaddlesItem(iBtmTop).LT
        ls = pSaddlesItem(iBtmTop).Lungh(0)
        f = pAreaLav(iCond, iBtmTop).React(iSadd)
        With pAreaLav(iCond, iBtmTop).ShearSaddle
            .K3(iSadd) = kSt(2, iSadd)
            If l2 > R / 2 Then
                .SQ(iSadd) = CSng(.K3(iSadd) * f / R / d * ls / (l1 + 1.33 * h))
            Else
                tau = CSng(f / (Math.PI * R * d))
                If .K3(iSadd) * f / (d + d1) > tau Then tau = .K3(iSadd) * f / (d + d1)
                .SQ(iSadd) = tau
            End If
        End With
    End Sub
    Sub CalcK56(ByRef i As Short, ByRef ZETS() As Single, ByRef b2() As Single, _
                ByRef K5() As Single, ByRef K6() As Single, ByRef TT() As Single, _
                ByRef K6S() As Single, ByRef F5() As Single, ByRef F6() As Single, _
                ByRef F6S() As Single, ByVal iBtmTop As Short)
        Dim I150, I120, I135, I165 As Single
        Dim REDS As Short
4230:   REDS = 0
4240:   ZETS(i) = pSaddlesItem(iBtmTop).GeomSadd(i).IncluAngle + 12
4250:   b2(i) = pSaddlesItem(iBtmTop).GeomSadd(i).AxialWidth + 10 * pSaddlesItem(iBtmTop).Spess(i)
4260:   If pSaddlesItem(iBtmTop).GeomSadd(i).IncluAngle > 120 Then GoTo 4320
4270:   K5(i) = 0.76
4280:   K6(i) = 0.0132 : If pSaddlesItem(iBtmTop).Lungh(i) / pSaddlesItem(iBtmTop).MeanR(i) > 0.5 Then GoTo 4290 Else GoTo 4620
4290:   If pSaddlesItem(iBtmTop).Lungh(i) / pSaddlesItem(iBtmTop).MeanR(i) > 1 Then GoTo 4310
4300:   K6(i) = CSng(0.0132 + (pSaddlesItem(iBtmTop).Lungh(i) / pSaddlesItem(iBtmTop).MeanR(i) - 0.5) / 0.5 * (0.0528 - 0.0132)) : GoTo 4620
4310:   K6(i) = 0.0528 : GoTo 4620
4320:   If pSaddlesItem(iBtmTop).GeomSadd(i).IncluAngle > 135 Then GoTo 4410
4330:   K5(i) = CSng(0.76 + (pSaddlesItem(iBtmTop).GeomSadd(i).IncluAngle - 120) / 15 * (0.711 - 0.76))
4340:   K6(i) = CSng(0.0132 + (pSaddlesItem(iBtmTop).GeomSadd(i).IncluAngle - 120) / 15 * (0.0103 - 0.0132))
4350:   If pSaddlesItem(iBtmTop).Lungh(i) / pSaddlesItem(iBtmTop).MeanR(i) > 0.5 Then GoTo 4360 Else GoTo 4620
4360:   If pSaddlesItem(iBtmTop).Lungh(i) / pSaddlesItem(iBtmTop).MeanR(i) > 1 Then GoTo 4400
4370:   I120 = CSng(0.0132 + (pSaddlesItem(iBtmTop).Lungh(i) / pSaddlesItem(iBtmTop).MeanR(i) - 0.5) / 0.5 * (0.0528 - 0.0132))
4380:   I135 = CSng(0.0103 + (pSaddlesItem(iBtmTop).Lungh(i) / pSaddlesItem(iBtmTop).MeanR(i) - 0.5) / 0.5 * (0.0413 - 0.0103))
4390:   K6(i) = I120 + (pSaddlesItem(iBtmTop).GeomSadd(i).IncluAngle - 120) / 15 * (I135 - I120) : GoTo 4620
4400:   K6(i) = CSng(0.0528 + (pSaddlesItem(iBtmTop).GeomSadd(i).IncluAngle - 120) / 15 * (0.0413 - 0.0528)) : GoTo 4620
4410:   If pSaddlesItem(iBtmTop).GeomSadd(i).IncluAngle > 150 Then GoTo 4490
4420:   K5(i) = CSng(0.711 + (pSaddlesItem(iBtmTop).GeomSadd(i).IncluAngle - 135) / 15 * (0.673 - 0.711))
4430:   K6(i) = CSng(0.0103 + (pSaddlesItem(iBtmTop).GeomSadd(i).IncluAngle - 135) / 15 * (0.0079 - 0.0103))
4440:   If pSaddlesItem(iBtmTop).Lungh(i) / pSaddlesItem(iBtmTop).MeanR(i) > 0.5 Then GoTo 4450 Else GoTo 4620
4450:   If pSaddlesItem(iBtmTop).Lungh(i) / pSaddlesItem(iBtmTop).MeanR(i) > 1 Then GoTo 4480
4460:   I150 = CSng(0.0079 + (pSaddlesItem(iBtmTop).Lungh(i) / pSaddlesItem(iBtmTop).MeanR(i) - 0.5) / 0.5 * (0.0316 - 0.0079))
4470:   K6(i) = I135 + (pSaddlesItem(iBtmTop).GeomSadd(i).IncluAngle - 135) / 15 * (I150 - I135) : GoTo 4620
4480:   K6(i) = CSng(0.0413 + (pSaddlesItem(iBtmTop).GeomSadd(i).IncluAngle - 135) / 15 * (0.0316 - 0.0413)) : GoTo 4620
4490:   If pSaddlesItem(iBtmTop).GeomSadd(i).IncluAngle > 165 Then GoTo 4570
4500:   K5(i) = CSng(0.673 + (pSaddlesItem(iBtmTop).GeomSadd(i).IncluAngle - 150) / 15 * (0.645 - 0.673))
4510:   K6(i) = CSng(0.0079 + (pSaddlesItem(iBtmTop).GeomSadd(i).IncluAngle - 150) / 15 * (0.0059 - 0.0079))
4520:   If pSaddlesItem(iBtmTop).Lungh(i) / pSaddlesItem(iBtmTop).MeanR(i) > 0.5 Then GoTo 4530 Else GoTo 4620
4530:   If pSaddlesItem(iBtmTop).Lungh(i) / pSaddlesItem(iBtmTop).MeanR(i) > 1 Then GoTo 4560
4540:   I165 = CSng(0.0059 + (pSaddlesItem(iBtmTop).Lungh(i) / pSaddlesItem(iBtmTop).MeanR(i) - 0.5) / 0.5 * (0.0238 - 0.0059))
4550:   K6(i) = I150 + (pSaddlesItem(iBtmTop).GeomSadd(i).IncluAngle - 150) / 15 * (I165 - I150) : GoTo 4620
4560:   K6(i) = CSng(0.0316 + (pSaddlesItem(iBtmTop).GeomSadd(i).IncluAngle - 150) / 15 * (0.0238 - 0.0316)) : GoTo 4620
4570:   K5(i) = 0.645
4580:   K6(i) = 0.0059 : If pSaddlesItem(iBtmTop).Lungh(i) / pSaddlesItem(iBtmTop).MeanR(i) > 0.5 Then GoTo 4590 Else GoTo 4620
4590:   If pSaddlesItem(iBtmTop).Lungh(i) / pSaddlesItem(iBtmTop).MeanR(i) > 1 Then GoTo 4610
4600:   K6(i) = CSng(0.0059 + (pSaddlesItem(iBtmTop).Lungh(i) / pSaddlesItem(iBtmTop).MeanR(i) - 0.5) / 0.5 * (0.0238 - 0.0059)) : GoTo 4620
4610:   K6(i) = 0.0238
4620:   K5(i) = K5(i) / 10.0!
4630:   TT(i) = pSaddlesItem(iBtmTop).Spess(i)
4640:   If pSaddlesItem(iBtmTop).GeomSadd(i).PlateWidth < b2(i) Then GoTo 4990
4650:   If pSaddlesItem(iBtmTop).GeomSadd(i).PlateAngle < pSaddlesItem(iBtmTop).GeomSadd(i).IncluAngle + 12 Then GoTo 4990
4660:   TT(i) = pSaddlesItem(iBtmTop).Spess(i) + pSaddlesItem(iBtmTop).GeomSadd(i).PlateThk
4670:   REDS = 1
4680:   If ZETS(i) > 120 Then GoTo 4730
4690:   K6S(i) = 0.0132 : If pSaddlesItem(iBtmTop).Lungh(i) / pSaddlesItem(iBtmTop).MeanR(i) > 0.5 Then GoTo 4700 Else GoTo 4990
4700:   If pSaddlesItem(iBtmTop).Lungh(i) / pSaddlesItem(iBtmTop).MeanR(i) > 1 Then GoTo 4720
4710:   K6S(i) = CSng(0.0132 + (pSaddlesItem(iBtmTop).Lungh(i) / pSaddlesItem(iBtmTop).MeanR(i) - 0.5) / 0.5 * (0.0528 - 0.0132)) : GoTo 4990
4720:   K6S(i) = 0.0528 : GoTo 4990
4730:   If ZETS(i) > 135 Then GoTo 4810
4740:   K6S(i) = CSng(0.0132 + (ZETS(i) - 120) / 15 * (0.0103 - 0.0132))
4750:   If pSaddlesItem(iBtmTop).Lungh(i) / pSaddlesItem(iBtmTop).MeanR(i) > 0.5 Then GoTo 4760 Else GoTo 4990
4760:   If pSaddlesItem(iBtmTop).Lungh(i) / pSaddlesItem(iBtmTop).MeanR(i) > 1 Then GoTo 4800
4770:   I120 = CSng(0.0132 + (pSaddlesItem(iBtmTop).Lungh(i) / pSaddlesItem(iBtmTop).MeanR(i) - 0.5) / 0.5 * (0.0528 - 0.0132))
4780:   I135 = CSng(0.0103 + (pSaddlesItem(iBtmTop).Lungh(i) / pSaddlesItem(iBtmTop).MeanR(i) - 0.5) / 0.5 * (0.0413 - 0.0103))
4790:   K6S(i) = I120 + (ZETS(i) - 120) / 15 * (I135 - I120) : GoTo 4990
4800:   K6S(i) = CSng(0.0528 + (ZETS(i) - 120) / 15 * (0.0413 - 0.0528)) : GoTo 4990
4810:   If ZETS(i) > 150 Then GoTo 4880
4820:   K6S(i) = CSng(0.0103 + (ZETS(i) - 135) / 15 * (0.0079 - 0.0103))
4830:   If pSaddlesItem(iBtmTop).Lungh(i) / pSaddlesItem(iBtmTop).MeanR(i) > 0.5 Then GoTo 4850 Else GoTo 4990
4840:   If pSaddlesItem(iBtmTop).Lungh(i) / pSaddlesItem(iBtmTop).MeanR(i) > 1 Then GoTo 4870
4850:   I150 = CSng(0.0079 + (pSaddlesItem(iBtmTop).Lungh(i) / pSaddlesItem(iBtmTop).MeanR(i) - 0.5) / 0.5 * (0.0316 - 0.0079))
4860:   K6S(i) = I135 + (ZETS(i) - 135) / 15 * (I150 - I135) : GoTo 4990
4870:   K6S(i) = CSng(0.0413 + (ZETS(i) - 135) / 15 * (0.0316 - 0.0413)) : GoTo 4990
4880:   If ZETS(i) > 165 Then GoTo 4950
4890:   K6S(i) = CSng(0.0079 + (ZETS(i) - 150) / 15 * (0.0059 - 0.0079))
4900:   If pSaddlesItem(iBtmTop).Lungh(i) / pSaddlesItem(iBtmTop).MeanR(i) > 0.5 Then GoTo 4920 Else GoTo 4990
4910:   If pSaddlesItem(iBtmTop).Lungh(i) / pSaddlesItem(iBtmTop).MeanR(i) > 1 Then GoTo 4940
4920:   I165 = CSng(0.0059 + (pSaddlesItem(iBtmTop).Lungh(i) / pSaddlesItem(iBtmTop).MeanR(i) - 0.5) / 0.5 * (0.0238 - 0.0059))
4930:   K6S(i) = I150 + (ZETS(i) - 150) / 15 * (I165 - I150) : GoTo 4990
4940:   K6S(i) = CSng(0.0316 + (ZETS(i) - 150) / 15 * (0.0238 - 0.0316)) : GoTo 4990
4950:   K6S(i) = 0.0059 : If pSaddlesItem(iBtmTop).Lungh(i) / pSaddlesItem(iBtmTop).MeanR(i) > 0.5 Then GoTo 4960 Else GoTo 4990
4960:   If pSaddlesItem(iBtmTop).Lungh(i) / pSaddlesItem(iBtmTop).MeanR(i) > 1 Then GoTo 4980
4970:   K6S(i) = CSng(0.0059 + (pSaddlesItem(iBtmTop).Lungh(i) / pSaddlesItem(iBtmTop).MeanR(i) - 0.5) / 0.5 * (0.0238 - 0.0059)) : GoTo 4990
4980:   K6S(i) = 0.0238
4990:   F5(i) = -K5(i) * pAreaLav(iCond, iBtmTop).React(1) / (TT(i) * b2(i))
5000:   If pSaddlesItem(iBtmTop).LT / pSaddlesItem(iBtmTop).MeanR(i) < 8 Then GoTo 5020
5010:   F6(i) = CSng(-pAreaLav(iCond, iBtmTop).React(i) / (4 * TT(i) * b2(i)) - 3 * K6(i) * pAreaLav(iCond, iBtmTop).React(i) / (2 * TT(i) ^ 2)) : GoTo 5030
5020:   F6(i) = CSng(-pAreaLav(iCond, iBtmTop).React(i) / (4 * TT(i) * b2(i)) - 12 * K6(i) * pAreaLav(iCond, iBtmTop).React(i) * pSaddlesItem(iBtmTop).MeanR(i) / (pSaddlesItem(iBtmTop).LT * TT(i) ^ 2))
5030:   If REDS = 0 Then Exit Sub
5040:   If pSaddlesItem(iBtmTop).LT / pSaddlesItem(iBtmTop).MeanR(i) < 8 Then GoTo 5060
5050:   F6S(i) = CSng(-pAreaLav(iCond, iBtmTop).React(i) / (4 * pSaddlesItem(iBtmTop).Spess(i) * b2(i)) - 3 * K6S(i) * pAreaLav(iCond, iBtmTop).React(i) / (2 * pSaddlesItem(iBtmTop).Spess(i) ^ 2)) : Exit Sub
5060:   F6S(i) = CSng(-pAreaLav(iCond, iBtmTop).React(i) / (4 * pSaddlesItem(iBtmTop).Spess(i) * b2(i)) - 12 * K6S(i) * pAreaLav(iCond, iBtmTop).React(i) * pSaddlesItem(iBtmTop).MeanR(i) / (pSaddlesItem(iBtmTop).LT * pSaddlesItem(iBtmTop).Spess(i) ^ 2))
    End Sub
    Sub Compress()
        Dim i As Short
        For i = 0 To 2
            Call LegTabella(RTrim(Monitor.Motore.Inizio.Archdir) & "\WR\BS363B.DAT", 1, 5, AreaLav(iCond).KFAT(i), AreaLav(iCond).DEL(i))
        Next
    End Sub
    Sub ForzeComplex(ByVal iBtmTop As Short)
        Dim S2S, S1S, S1D, S2D As Single
1999:   pAreaLav(iCond, iBtmTop).Momen(1) = -(pSaddlesLoad(iCond, iBtmTop).PesoS(1) * 1000 * pSaddlesItem(iBtmTop).Lungh(1) + _
                            pAreaLav(iCond, iBtmTop).Q * pSaddlesItem(iBtmTop).Lungh(1) * pSaddlesItem(iBtmTop).Lungh(1) / 2 + _
                            pSaddlesLoad(iCond, iBtmTop).MomS(1) * 1000000.0!)
2000:   pAreaLav(iCond, iBtmTop).Momen(2) = -(pSaddlesLoad(iCond, iBtmTop).PesoS(2) * 1000 * pSaddlesItem(iBtmTop).Lungh(2) + _
                            pAreaLav(iCond, iBtmTop).Q * pSaddlesItem(iBtmTop).Lungh(2) * pSaddlesItem(iBtmTop).Lungh(2) / 2 + _
                            pSaddlesLoad(iCond, iBtmTop).MomS(2) * 1000000.0!)
2010:   pAreaLav(iCond, iBtmTop).React(1) = pAreaLav(iCond, iBtmTop).Q * pSaddlesItem(iBtmTop).Lungh(0) / 2 + _
                            pAreaLav(iCond, iBtmTop).Q * pSaddlesItem(iBtmTop).Lungh(1) * (pSaddlesItem(iBtmTop).Lungh(1) / 2 + _
                            pSaddlesItem(iBtmTop).Lungh(0)) / pSaddlesItem(iBtmTop).Lungh(0) - pAreaLav(iCond, iBtmTop).Q * pSaddlesItem(iBtmTop).Lungh(2) * pSaddlesItem(iBtmTop).Lungh(2) / 2 / pSaddlesItem(iBtmTop).Lungh(0) + pSaddlesLoad(iCond, iBtmTop).PesoS(1) * 1000 - pAreaLav(iCond, iBtmTop).Momen(1) / pSaddlesItem(iBtmTop).Lungh(0) + pAreaLav(iCond, iBtmTop).Momen(2) / pSaddlesItem(iBtmTop).Lungh(0)
2020:   pAreaLav(iCond, iBtmTop).React(2) = pAreaLav(iCond, iBtmTop).Q * pSaddlesItem(iBtmTop).Lungh(0) / 2 - pAreaLav(iCond, iBtmTop).Q * pSaddlesItem(iBtmTop).Lungh(1) * pSaddlesItem(iBtmTop).Lungh(1) / 2 / pSaddlesItem(iBtmTop).Lungh(0) + _
                            pAreaLav(iCond, iBtmTop).Q * pSaddlesItem(iBtmTop).Lungh(2) * (pSaddlesItem(iBtmTop).Lungh(2) / 2 + _
                            pSaddlesItem(iBtmTop).Lungh(0)) / pSaddlesItem(iBtmTop).Lungh(0) + pAreaLav(iCond, iBtmTop).Momen(1) / pSaddlesItem(iBtmTop).Lungh(0) + pSaddlesLoad(iCond, iBtmTop).PesoS(2) * 1000 - pAreaLav(iCond, iBtmTop).Momen(2) / pSaddlesItem(iBtmTop).Lungh(0)
2030:   S1S = System.Math.Abs(pSaddlesLoad(iCond, iBtmTop).PesoS(1) * 1000 + pAreaLav(iCond, iBtmTop).Q * pSaddlesItem(iBtmTop).Lungh(1))
        S1D = System.Math.Abs(pAreaLav(iCond, iBtmTop).React(1) - S1S)
2040:   S2D = System.Math.Abs(pSaddlesLoad(iCond, iBtmTop).PesoS(2) * 1000 + pAreaLav(iCond, iBtmTop).Q * pSaddlesItem(iBtmTop).Lungh(2))
        S2S = System.Math.Abs(pAreaLav(iCond, iBtmTop).React(2) - S2D)
2050:   pAreaLav(iCond, iBtmTop).Taglio(1) = S1S : If pAreaLav(iCond, iBtmTop).Taglio(1) < S1D Then pAreaLav(iCond, iBtmTop).Taglio(1) = S1D
2060:   pAreaLav(iCond, iBtmTop).Taglio(2) = S2D : If pAreaLav(iCond, iBtmTop).Taglio(2) < S2S Then pAreaLav(iCond, iBtmTop).Taglio(2) = S2S
    End Sub
    Sub ForzeSimple(ByVal iBtmTop As Short)
        Dim i As Short
        Dim XSI1, XSI2 As Single
        For i = 1 To 2
1982:       AreaLav(iCond).React(i) = CSng(0.5 * pSaddlesLoad(iCond, iBtmTop).PesoTot * 1000)
1983:       XSI1 = CSng(1 - pSaddlesItem(iBtmTop).Lungh(i) / pSaddlesItem(iBtmTop).LT + (pSaddlesItem(iBtmTop).MeanR(i) ^ 2 - pSaddlesItem(iBtmTop).HeadHeight ^ 2) / (2 * pSaddlesItem(iBtmTop).Lungh(i) * pSaddlesItem(iBtmTop).LT))
1984:       XSI2 = 1 + 4 * pSaddlesItem(iBtmTop).HeadHeight / (3 * pSaddlesItem(iBtmTop).LT)
1985:       AreaLav(iCond).Momen(i) = -AreaLav(iCond).React(i) * pSaddlesItem(iBtmTop).Lungh(i) * (1 - XSI1 / XSI2)
1989:       AreaLav(iCond).Taglio(i) = AreaLav(iCond).React(i) * ((pSaddlesItem(iBtmTop).LT - 2 * pSaddlesItem(iBtmTop).Lungh(i)) / (pSaddlesItem(iBtmTop).LT + 4 * pSaddlesItem(iBtmTop).HeadHeight / 3))
        Next
    End Sub
    Function Geom(ByVal iBtmTop As Short) As Boolean
        Dim i As Short
        Geom = True
        Try
            For i = 0 To 2
                pSaddlesItem(iBtmTop).OutDia(i) = pSaddlesItem(iBtmTop).Diam + 2 * pSaddlesItem(iBtmTop).Spess(i)
                pSaddlesItem(iBtmTop).MeanR(i) = (pSaddlesItem(iBtmTop).Diam + pSaddlesItem(iBtmTop).Spess(i)) / 2
                If i > 0 Then pSaddlesItem(iBtmTop).RHead(i) = (pSaddlesItem(iBtmTop).Diam + pSaddlesItem(iBtmTop).SpessHead(i)) / 2
                pSaddlesItem(iBtmTop).w(i) = CSng(Math.PI / 32 * (pSaddlesItem(iBtmTop).OutDia(i) ^ 4 - pSaddlesItem(iBtmTop).Diam ^ 4) / pSaddlesItem(iBtmTop).OutDia(i))
            Next
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
            Geom = False
        End Try
    End Function
    Function LeggiData() As Boolean
        Dim iCalc As Short
        Dim i As Short
        LeggiData = False
        If Not File.Exists(FileData) Then Exit Function
        For iCalc = 1 To 3
            If Problem.NCond(iCalc) = 0 Then Problem.NCond(iCalc) = 1
        Next
        Dim fs As New FileStream(FileData, FileMode.Open)
        Dim bf As New Lancio.Legacy.Serialization.LegacyBinarySerializer
        LeggiData = True
        Try
            Problem = CType(bf.Deserialize(fs), typProblem)
            If sonda Then
                fs.Close()
                Exit Function
            End If
            NozzleData.Initialize(False)
            Call AggRedim()
            With frmSaddles.DefInstance
                .mnuStacked.Checked = Not Problem.Stacked
                .mnuStacked_Click(Nothing, New System.EventArgs)
            End With
            SaddlesItem = CType(bf.Deserialize(fs), typSaddlesItemN)
            For i = 0 To CShort(Problem.NCond(1) - 1)
                SaddlesLoad(i) = CType(bf.Deserialize(fs), typSaddlesLoad)
                AreaLav(i) = CType(bf.Deserialize(fs), typAreaLav)
            Next
            xSupport(1) = CType(bf.Deserialize(fs), typxSupportItem)
            xSupport(2) = CType(bf.Deserialize(fs), typxSupportItem)
            For i = 0 To CShort(Problem.NCond(2) - 1)
                xSupportData(1, i) = CType(bf.Deserialize(fs), typxSupportData)
                xSupportData(2, i) = CType(bf.Deserialize(fs), typxSupportData)
                xSupportResult(1, i) = CType(bf.Deserialize(fs), typxSupportResult)
                xSupportResult(2, i) = CType(bf.Deserialize(fs), typxSupportResult)
            Next
            xFondaItem(1) = CType(bf.Deserialize(fs), typxFondaItem)
            xFondaItem(2) = CType(bf.Deserialize(fs), typxFondaItem)
            For i = 0 To CShort(Problem.NCond(3) - 1)
                xFondaData(1, i) = CType(bf.Deserialize(fs), typxFondaData)
                xFondaData(2, i) = CType(bf.Deserialize(fs), typxFondaData)
            Next
            LoadFoundData = CType(bf.Deserialize(fs), typLoadFoundDataN)
            NozzleData = CType(bf.Deserialize(fs), typNozzleData)
            If Problem.Stacked Then
                NozzleDataT.Initialize(False)
                SaddlesItemT = CType(bf.Deserialize(fs), typSaddlesItemN)
                For i = 0 To CShort(Problem.NCond(1) - 1)
                    SaddlesLoadT(i) = CType(bf.Deserialize(fs), typSaddlesLoad)
                    AreaLavT(i) = CType(bf.Deserialize(fs), typAreaLav)
                Next
                xSupportT(1) = CType(bf.Deserialize(fs), typxSupportItem)
                xSupportT(2) = CType(bf.Deserialize(fs), typxSupportItem)
                For i = 0 To CShort(Problem.NCond(2) - 1)
                    xSupportDataT(1, i) = CType(bf.Deserialize(fs), typxSupportData)
                    xSupportDataT(2, i) = CType(bf.Deserialize(fs), typxSupportData)
                    xSupportResultT(1, i) = CType(bf.Deserialize(fs), typxSupportResult)
                    xSupportResultT(2, i) = CType(bf.Deserialize(fs), typxSupportResult)
                Next
                LoadFoundDataT = CType(bf.Deserialize(fs), typLoadFoundDataN)
                NozzleDataT = CType(bf.Deserialize(fs), typNozzleData)
                SforziFromTop = CType(bf.Deserialize(fs), typSforzifromTop)
            End If
        Catch e As Exception
            gencommes = ""
            LeggiData = False
            fs.Close()
            If MostraAiuto(IDH_ERR_BADSERIAL, _
            ChiaviMess.MessQuestion Or ChiaviMess.MessYesNo, _
            GlobalRoutines.FormatS(Helpstringa(IDH_ERR_BADSERIAL), FileData, e.Message)) _
            = ChiaviMess.MessSi Then
                Kill(FileData)
                Monitor.Motore.Problem.OrdineFile -= 1
            End If
            Exit Function
        End Try
        fs.Close()
        frmSaddles.DefInstance.mnuVerb.Checked = Problem.Verbose
    End Function
    ' Public Sub AggiornaVento()
    '     Dim i As Integer
    '     For i = 0 To Problem.NumParamV - 1
    '         If Problem.ParamV(i) <> 0 Then frmSaddles.DefInstance.tVento(i).Text = GlobalRoutines.FormatS(Problem.ParamV(i), FormSng2)
    '     Next
    ' End Sub
    ' Public Sub AggiornaSisma()
    '     Dim i As Integer
    '     For i = 0 To Problem.NumParamS - 1
    '         If Problem.Params(i) <> 0 Then frmSaddles.DefInstance.tSisma(i).Text = GlobalRoutines.FormatS(Problem.Params(i), FormSng2)
    '     Next
    ' End Sub
    Sub LegTabella(ByRef File As String, ByRef n As Short, ByRef i6 As Short, ByRef TDes As Single, ByRef Pmax As Single)
        Dim ifl1, i As Short
        Dim Riga As String = ""
        Dim Te0, Temp, Te1 As Single
        Dim Pr0, Pr, Pr1 As Single
        Dim l1, l, k As Short
        ifl1 = CShort(FreeFile())
        FileOpen(ifl1, File, OpenMode.Input, , OpenShare.Shared)
        For i = 1 To 4 : Riga = LineInput(ifl1) : Next
        Temp = 0
        Do
            Te0 = Temp : Riga = Riga
            Riga = LineInput(ifl1) : Riga = LTrim(Riga)
            Temp = CSng(Riga.Substring(1, i6)) ' GlobaLroutines.ValVir(Mid(Riga, 2, i6))
            If Temp > TDes Then Exit Do
            If EOF(ifl1) Then Exit Do
        Loop
        FileClose(ifl1)
        l1 = 5
        For k = 1 To n
            l = CShort(Riga.IndexOf(CChar("³"), l1 - 1))
            l1 = CShort(l + 1)
        Next
        Pr = CSng(Riga.Substring(l1 - 1, 6)) ' GlobaLroutines.ValVir(Mid(Riga, l1, 6))
        If Te0 > 0 Then
            Pr1 = Pr : Te1 = Temp : Riga = Riga
            l1 = 5
            For k = 1 To n
                l = CShort(Riga.IndexOf(CChar("³"), l1 - 1)) ' InStr(l1, Riga, "³")
                l1 = CShort(l + 1)
            Next
            Pr = CSng(Riga.Substring(l1 - 1, 6)) ' GlobaLroutines.ValVir(Mid(Riga, l1, 6))
            Pr0 = Pr
            Pmax = (TDes - Te0) / (Te1 - Te0) * (Pr1 - Pr0) + Pr0
        Else
            Pmax = Pr
        End If
    End Sub
    Public Function PrimaPagina() As Boolean
        Ncontr = 0 '4
        If Monitor.Motore.Inizio.LavoriSciolti Then
            PrimaPagina = Monitor.Motore.Mostra(myAssembly, 2)
        Else
            job = Monitor.Motore.Sceglijob(ContrNome, ContrFile)
            If Len(ContrFile) = 0 Then Exit Function
            If Not job.Selezione Then FileData = "" : Exit Function
            With job.Comm
                If .indice > 0 Then
                    FileData = Monitor.Motore.Inizio.Workdir & "\A" & .Arch & "\" & .Ind.Item(.indice).Data.File & Monitor.Motore.Problem.Extension
                Else
                    FileData = ""
                    Exit Function
                End If
            End With
            gencommes = FileData.Substring(0, FileData.Length - 4)
            PrimaPagina = LeggiData()
        End If
    End Function
    Sub QuartaPagina()
        Dim i, Delty As Short
        With frmSaddles.DefInstance
            Try
                If .Text41.Count > 1 Then Exit Sub
                Ncontr = 23
                mioContr1(0) = .Text41(0)
                For i = 1 To Ncontr
                    .Label42.Load(i)
                    .Label42(i).Text = "mm"
                    .Label42(i).BringToFront()
                    .Label41.Load(i)
                    .Text41.Load(i)
                    mioContr1(i) = .Text41(i)
                Next
                Ncontr = 25
                For i = 24 To Ncontr
                    .Check1.Load(i)
                    mioContr1(i) = .Check1(i)
                Next
                Ncontr = 33
                For i = 26 To Ncontr
                    .Label42.Load(i)
                    .Label42(i).Text = "mm"
                    .Label42(i).BringToFront()
                    .Label41.Load(i)
                    .Label41(i).Width = CInt(GlobalRoutines.TwipsToPixelsX(1400))
                    .Text41.Load(i)
                    mioContr1(i) = .Text41(i)
                Next
                .Label42(9).Text = "deg"
                .Label42(10).Text = "deg"
                .Label42(13).Text = "deg"
                .Label42(14).Text = "deg"
                .Label41(0).Text = "Shell inside diameter (corroded)      "
                .Label41(1).Text = "Shell corroded thk : - away from the saddles "
                .Label41(2).Text = "                  - on the left saddle  "
                .Label41(3).Text = "                  - on the right saddle "
                .Label41(4).Text = "Distance : - between saddles          "
                .Label41(5).Text = "           - from left saddle to left end/tangent"
                .Label41(6).Text = "           - from right saddle to right end/tangent"
                .Label41(7).Text = "Saddle axial width : - left support        "
                .Label41(8).Text = "                     - right support       "
                .Label41(9).Text = "Saddle included angle : - left support     "
                .Label41(10).Text = "                        - right support   "
                .Label41(11).Text = "Saddle plate width : - left support       "
                .Label41(12).Text = "                     - right support      "
                .Label41(13).Text = "Saddle plate incl. angle : - left support "
                .Label41(14).Text = "                           - right support "
                .Label41(15).Text = "Saddle plate thickness : - left support   "
                .Label41(16).Text = "                         - right support "
                .Label41(17).Text = "Saddle thickness : - left support       "
                .Label41(18).Text = "                   - right support      "
                .Label41(19).Text = "Saddle minimum height : - left support  "
                .Label41(20).Text = "                        - right support "
                .Label41(21).Text = "Dished head thickness at left end (corroded)"
                .Label41(22).Text = "Dished head thickness at right end (corroded)"
                .Label41(23).Text = "Dished heads height              "
                .Text41(23).Text = Str(SaddlesItem.HeadHeight)
                .Label41(26).Text = "Ring inertia (left)"
                .Label41(27).Text = "Ring inertia(right)"
                For i = 26 To 27
                    .Label42(i).Text = "mm4"
                Next
                .Label41(28).Text = "Outer dim.(left)"
                .Label41(29).Text = "Outer dim.(right)"
                For i = 28 To 29
                    .Label42(i).Text = "mm"
                Next
                .Label41(30).Text = "Inner dim.(left)"
                .Label41(31).Text = "Inner dim.(right)"
                For i = 30 To 31
                    .Label42(i).Text = "mm"
                Next
                .Label41(32).Text = "Cross area(left)"
                .Label41(33).Text = "Cross area(right)"
                For i = 32 To 33
                    .Label42(i).Text = "mm2"
                Next
                For i = 0 To 23
                    .Label41(i).Left = 0
                    .Label41(i).Top = i * .Label41(i).Height
                    .Label41(i).BringToFront()
                    .Label42(i).Left = .Label41(i).Width
                    .Label42(i).Top = i * .Label41(i).Height
                    mioContr1(i).Left = .Label42(0).Left + .Label42(0).Width
                    mioContr1(i).Top = i * .Label41(0).Height
                    mioContr1(i).TabIndex = i : mioContr1(i).Visible = True
                    .Label41(i).Visible = True
                    .Label42(i).Visible = True
                    mioContr1(i).Enabled = True
                    .Label41(i).Enabled = True
                    .Label42(i).Enabled = True
                Next
                For i = 24 To 25
                    mioContr1(i).Enabled = True
                    mioContr1(i).TabIndex = i : mioContr1(i).Visible = True
                    mioContr1(i).Left = CInt(mioContr1(0).Left + mioContr1(0).Width + SystemInformation.Border3DSize.Width)
                    mioContr1(i).Top = mioContr1(i - 15).Top
                Next
                For i = 26 To 33
                    .Label41(i).Left = CInt(mioContr1(0).Left + mioContr1(0).Width + SystemInformation.Border3DSize.Width)
                    .Label41(i).Top = mioContr1(i - 15).Top
                    .Label41(i).BringToFront()
                    .Label42(i).Left = .Label41(i).Left + .Label41(i).Width
                    .Label42(i).Top = mioContr1(i - 15).Top
                    mioContr1(i).Left = .Label42(i).Left + .Label42(i).Width
                    mioContr1(i).Top = mioContr1(i - 15).Top
                    mioContr1(i).TabIndex = i
                    mioContr1(i).Visible = True
                    VisRing()
                Next
                Delty = CShort(24 * .Label41(0).Height + .TabTensMantDown.GetTabRect(0).Height + 4 * SystemInformation.Border3DSize.Height)
                .TabTensMantDown.Height = Math.Max(.TabTensMantDown.Height, Delty)
                .cmdCalcMant.Top = .PagCalcMantDim.Height - .cmdCalcMant.Height
                .cmdCalcMant.Left = .PagCalcMantDim.Width - .cmdCalcMant.Width
            Catch e As Exception
                MsgBox(e.Message + vbCrLf + e.StackTrace)
            End Try
        End With
    End Sub
    Sub QuartaPaginaT()
        Dim i, Delty As Short
        With frmSaddles.DefInstance
            Try
                If .Text41T.Count > 1 Then Exit Sub
                Ncontr = 23
                mioContr1T(0) = .Text41T(0)
                For i = 1 To Ncontr
                    .Label42T.Load(i)
                    .Label42T(i).Text = "mm"
                    .Label42T(i).BringToFront()
                    .Label41T.Load(i)
                    .Text41T.Load(i)
                    mioContr1T(i) = .Text41T(i)
                Next
                Ncontr = 25
                For i = 24 To Ncontr
                    .Check1T.Load(i)
                    mioContr1T(i) = .Check1T(i)
                Next
                Ncontr = 33
                For i = 26 To Ncontr
                    .Label42T.Load(i)
                    .Label42T(i).Text = "mm"
                    .Label42T(i).BringToFront()
                    .Label41T.Load(i)
                    .Label41T(i).Width = CInt(GlobalRoutines.TwipsToPixelsX(1400))
                    .Text41T.Load(i)
                    mioContr1T(i) = .Text41T(i)
                Next
                .Label42T(9).Text = "deg"
                .Label42T(10).Text = "deg"
                .Label42T(13).Text = "deg"
                .Label42T(14).Text = "deg"
                .Label41T(0).Text = "Shell inside diameter (corroded)      "
                .Label41T(1).Text = "Shell corroded thk : - away from the saddles "
                .Label41T(2).Text = "                  - on the left saddle  "
                .Label41T(3).Text = "                  - on the right saddle "
                .Label41T(4).Text = "Distance : - between saddles          "
                .Label41T(5).Text = "           - from left saddle to left end/tangent"
                .Label41T(6).Text = "           - from right saddle to right end/tangent"
                .Label41T(7).Text = "Saddle axial width : - left support        "
                .Label41T(8).Text = "                     - right support       "
                .Label41T(9).Text = "Saddle included angle : - left support     "
                .Label41T(10).Text = "                        - right support   "
                .Label41T(11).Text = "Saddle plate width : - left support       "
                .Label41T(12).Text = "                     - right support      "
                .Label41T(13).Text = "Saddle plate incl. angle : - left support "
                .Label41T(14).Text = "                           - right support "
                .Label41T(15).Text = "Saddle plate thickness : - left support   "
                .Label41T(16).Text = "                         - right support "
                .Label41T(17).Text = "Saddle thickness : - left support       "
                .Label41T(18).Text = "                   - right support      "
                .Label41T(19).Text = "Saddle minimum height : - left support  "
                .Label41T(20).Text = "                        - right support "
                .Label41T(21).Text = "Dished head thickness at left end (corroded)"
                .Label41T(22).Text = "Dished head thickness at right end (corroded)"
                .Label41T(23).Text = "Dished heads height              "
                .Text41T(23).Text = Str(SaddlesItem.HeadHeight)
                .Label41T(26).Text = "Ring inertia (left)"
                .Label41T(27).Text = "Ring inertia(right)"
                For i = 26 To 27
                    .Label42T(i).Text = "mm4"
                Next
                .Label41T(28).Text = "Outer dim.(left)"
                .Label41T(29).Text = "Outer dim.(right)"
                For i = 28 To 29
                    .Label42T(i).Text = "mm"
                Next
                .Label41T(30).Text = "Inner dim.(left)"
                .Label41T(31).Text = "Inner dim.(right)"
                For i = 30 To 31
                    .Label42T(i).Text = "mm"
                Next
                .Label41T(32).Text = "Cross area(left)"
                .Label41T(33).Text = "Cross area(right)"
                For i = 32 To 33
                    .Label42T(i).Text = "mm2"
                Next
                For i = 0 To 23
                    .Label41T(i).Left = 0
                    .Label41T(i).Top = i * .Label41T(i).Height
                    .Label41T(i).BringToFront()
                    .Label42T(i).Left = .Label41T(i).Width
                    .Label42T(i).Top = i * .Label41T(i).Height
                    mioContr1T(i).Left = .Label42T(0).Left + .Label42T(0).Width
                    mioContr1T(i).Top = i * .Label41T(0).Height
                    mioContr1T(i).TabIndex = i : mioContr1T(i).Visible = True
                    .Label41T(i).Visible = True
                    .Label42T(i).Visible = True
                    mioContr1T(i).Enabled = True
                    .Label41T(i).Enabled = True
                    .Label42T(i).Enabled = True
                Next
                For i = 24 To 25
                    mioContr1T(i).Enabled = True
                    mioContr1T(i).TabIndex = i : mioContr1T(i).Visible = True
                    mioContr1T(i).Left = CInt(mioContr1T(0).Left + mioContr1T(0).Width + SystemInformation.Border3DSize.Width)
                    mioContr1T(i).Top = mioContr1T(i - 15).Top
                Next
                For i = 26 To 33
                    .Label41T(i).Left = CInt(mioContr1T(0).Left + mioContr1T(0).Width + SystemInformation.Border3DSize.Width)
                    .Label41T(i).Top = mioContr1T(i - 15).Top
                    .Label41T(i).BringToFront()
                    .Label42T(i).Left = .Label41T(i).Left + .Label41T(i).Width
                    .Label42T(i).Top = mioContr1T(i - 15).Top
                    mioContr1T(i).Left = .Label42T(i).Left + .Label42T(i).Width
                    mioContr1T(i).Top = mioContr1T(i - 15).Top
                    mioContr1T(i).TabIndex = i
                    mioContr1T(i).Visible = True
                    VisRingT()
                Next
                Delty = CShort(24 * .Label41T(0).Height + .TabTensMantUp.GetTabRect(0).Height + 4 * SystemInformation.Border3DSize.Height)
                .TabTensMantUp.Height = Math.Max(.TabTensMantUp.Height, Delty)
                .cmdCalcMant.Top = .PagCalcMantDim.Height - .cmdCalcMant.Height
                .cmdCalcMant.Left = .PagCalcMantDim.Width - .cmdCalcMant.Width
            Catch e As Exception
                MsgBox(e.Message + vbCrLf + e.StackTrace)
            End Try
        End With
    End Sub
    Function SadDes(ByRef i As Short, ByRef K9() As Single, ByRef h() As Single, _
                    ByRef HSD() As Single, ByRef FSD() As Single, ByVal iBtmTop As Short) As Boolean
5930:   If pSaddlesItem(iBtmTop).GeomSadd(i).IncluAngle > 120 Then GoTo 5950
5940:   K9(i) = 0.204 : GoTo 6020
5950:   If pSaddlesItem(iBtmTop).GeomSadd(i).IncluAngle > 135 Then GoTo 5970
5960:   K9(i) = CSng(0.204 + (pSaddlesItem(iBtmTop).GeomSadd(i).IncluAngle - 120) / 15 * (0.231 - 0.204)) : GoTo 6020
5970:   If pSaddlesItem(iBtmTop).GeomSadd(i).IncluAngle > 150 Then GoTo 5990
5980:   K9(i) = CSng(0.231 + (pSaddlesItem(iBtmTop).GeomSadd(i).IncluAngle - 135) / 15 * (0.259 - 0.231)) : GoTo 6020
5990:   If pSaddlesItem(iBtmTop).GeomSadd(i).IncluAngle > 165 Then GoTo 6010
6000:   K9(i) = CSng(0.259 + (pSaddlesItem(iBtmTop).GeomSadd(i).IncluAngle - 150) / 15 * (0.288 - 0.259)) : GoTo 6020
6010:   K9(i) = 0.288
6020:   h(i) = K9(i) * pAreaLav(iCond, iBtmTop).React(i)
6030:   HSD(i) = pSaddlesItem(iBtmTop).MeanR(i) / 3
6040:   If HSD(i) > pSaddlesItem(iBtmTop).GeomSadd(i).SaddHeight Then HSD(i) = pSaddlesItem(iBtmTop).GeomSadd(i).SaddHeight
        If HSD(i) <= 0 Then
            MsgBox("Valore non valido per l'altezza delle selle.", MsgBoxStyle.Critical Or MsgBoxStyle.OKOnly, "BSDD")
            SadDes = False
        Else
6050:       FSD(i) = h(i) / (pSaddlesItem(iBtmTop).GeomSadd(i).SaddlThk * HSD(i))
            SadDes = True
        End If
    End Function
    Sub SaddlesCalc(ByVal iBtmTop As Short)
        Dim i, k As Short
        Dim SinDes As String
2920:   '--------------------------Left saddle----------------------
        If Problem.Codice = 1 Then StSaddlesCalc(iBtmTop) : Exit Sub
        SinDes = "left"
        With pAreaLav(iCond, iBtmTop).TensSaddle
            For i = 1 To 2
                iSadd = i
                If Not pSaddlesItem(iBtmTop).GeomSadd(i).SupRing Then
                    Call CalcK(i, .K1, .k2, iBtmTop)
                    .M4(i) = pAreaLav(iCond, iBtmTop).Momen(i)
                    For k = 0 To 1 'pressure no-pressure
                        .ROUND(i, k) = 0
                        .F3(i, k) = pSaddlesLoad(iCond, iBtmTop).DesPress * k * _
                                          pSaddlesItem(iBtmTop).MeanR(i) / (2 * pSaddlesItem(iBtmTop).Spess(i)) - .M4(i) / pSaddlesItem(iBtmTop).w(i)
                        .F4(i, k) = pSaddlesLoad(iCond, iBtmTop).DesPress * k * _
                                          pSaddlesItem(iBtmTop).MeanR(i) / (2 * pSaddlesItem(iBtmTop).Spess(i)) + .M4(i) / pSaddlesItem(iBtmTop).w(i)
                        If Problem.LoadCond(2, iCond + 1) Is Nothing Then Problem.LoadCond(2, iCond + 1) = "(without name)"
                        If Problem.IgnoreOutOfRoundness And Problem.Codice = 0 And .F3(i, k) > 0 And .F4(i, k) > 0 Then
                            ' Mess = "Load condition: " & Problem.LoadCond(1, iCond + 1).Trim & ". Saddle n° " & iSadd.ToString & "." & vbCrLf
                            ' Mess = Mess & "With reference to BS G.3.3.2.3, the longitudinal stresses at " & SinDes & " saddle are both tensile."
                            ' Mess = Mess & " It is so acceptable to ignore the out of roundness under load of the shell section."
                            ' Mess = Mess & " Do you want to do so, and then take K1=K2=1 ?"
                            .K1(i, k) = 1
                            .k2(i, k) = 1 : .ROUND(i, k) = 1
                        End If
                        .F3(i, k) = .F3(i, k) / .K1(i, k)
                        .F4(i, k) = .F4(i, k) / .k2(i, k)
                    Next k
                End If
                SinDes = "right"
            Next
        End With
    End Sub
    Sub SaveData()
        Dim i, iCalc As Short
        Dim Logic As Boolean
        For iCalc = 1 To 3
            If Problem.NCond(iCalc) = 0 Then Problem.NCond(iCalc) = 1 : Logic = True
        Next
        Try
            NozzleData.Initialize(False)
            Call AggRedim()
            Dim fs As New FileStream(FileData, FileMode.OpenOrCreate)
            Dim bf As New Lancio.Legacy.Serialization.LegacyBinarySerializer
            Problem.Versione = 2
            bf.Serialize(fs, Problem)
            bf.Serialize(fs, SaddlesItem)
            For i = 0 To CShort(Problem.NCond(1) - 1)
                bf.Serialize(fs, SaddlesLoad(i))
                bf.Serialize(fs, AreaLav(i))
            Next
            bf.Serialize(fs, xSupport(1))
            bf.Serialize(fs, xSupport(2))
            For i = 0 To CShort(Problem.NCond(2) - 1)
                bf.Serialize(fs, xSupportData(1, i))
                bf.Serialize(fs, xSupportData(2, i))
                bf.Serialize(fs, xSupportResult(1, i))
                bf.Serialize(fs, xSupportResult(2, i))
            Next
            bf.Serialize(fs, xFondaItem(1))
            bf.Serialize(fs, xFondaItem(2))
            For i = 0 To CShort(Problem.NCond(3) - 1)
                bf.Serialize(fs, xFondaData(1, i))
                bf.Serialize(fs, xFondaData(2, i))
            Next
            bf.Serialize(fs, LoadFoundData)
            bf.Serialize(fs, NozzleData)
            If Problem.Stacked Then
                NozzleDataT.Initialize(True)
                bf.Serialize(fs, SaddlesItemT)
                For i = 0 To CShort(Problem.NCond(1) - 1)
                    bf.Serialize(fs, SaddlesLoadT(i))
                    bf.Serialize(fs, AreaLavT(i))
                Next
                bf.Serialize(fs, xSupportT(1))
                bf.Serialize(fs, xSupportT(2))
                For i = 0 To CShort(Problem.NCond(2) - 1)
                    bf.Serialize(fs, xSupportDataT(1, i))
                    bf.Serialize(fs, xSupportDataT(2, i))
                    bf.Serialize(fs, xSupportResultT(1, i))
                    bf.Serialize(fs, xSupportResultT(2, i))
                Next
                bf.Serialize(fs, LoadFoundDataT)
                bf.Serialize(fs, NozzleDataT)
                bf.Serialize(fs, SforziFromTop)
            End If
            fs.Close()
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Sub SecondaPagina()
        Dim i, Delty As Short
        If Inizializzando Then Exit Sub
        If iCond > Problem.NCond(1) - 1 Then iCond = 0
        With frmSaddles.DefInstance
            Try
                If .Text1.Count > 1 Then
                    .Combo2(28).Items.Clear()
                    Call DispCond(.Combo2(28), 1)
                    Exit Sub
                End If
                .Cursor = Cursors.WaitCursor
                Ncontr = 22
                For i = 1 To Ncontr
                    .Label2.Load(i)
                    .Label2(i).Text = ""
                    .Label2(i).BringToFront()
                Next
                .Label1(0).Text = "Simple Vessel with symmetrical saddles ?"
                .Combo2(0).Width = CInt(GlobalRoutines.TwipsToPixelsX(1065))
                .Combo2(0).Items.Clear()
                .Combo2(0).Items.Add("Simple")
                .Combo2(0).Items.Add("Complex")
                mioContr(0) = .Combo2(0)
                '-------------------------------------------
                .Label1.Load(1)
                .Label1(1).Text = "Design data : - pressure ( - sign if external)"
                .Label2(1).Text = "MPa"
                .Text1.Load(1)
                mioContr(1) = .Text1(1)
                '---------------------------------
                .Label1.Load(2)
                .Label1(2).Text = "Design data : - temperature"
                .Label2(2).Text = "°C"
                .Text1.Load(2)
                mioContr(2) = .Text1(2)
                '------------------------------------------------
                .Label1.Load(3)
                .Label1(3).Text = "Exchanger/Vessel total weight"
                .Label2(3).Text = "kN"
                .Text1.Load(3)
                mioContr(3) = .Text1(3)
                '------------------------------------------------
                .Label1.Load(4)
                .Label1(4).Text = "Concentrated weight : - on left end"
                .Label2(4).Text = "kN"
                .Text1.Load(4)
                mioContr(4) = .Text1(4)
                '------------------------------------------------
                .Label1.Load(5)
                .Label1(5).Text = "Concentrated weight : - on right end"
                .Label2(5).Text = "kN"
                .Text1.Load(5)
                mioContr(5) = .Text1(5)
                '-----------------------------------------------
                .Label1.Load(6)
                .Label1(6).Text = "Moment : - at left end  ( + if counterclockwise)"
                .Label2(6).Text = "kN.m"
                .Text1.Load(6)
                mioContr(6) = .Text1(6)
                '-----------------------------------------------
                .Label1.Load(7)
                .Label1(7).Text = "Moment : - at right end ( + if clockwise )"
                .Label2(7).Text = "kN.m"
                .Text1.Load(7)
                mioContr(7) = .Text1(7)
                '-----------------------------------------------
                '(0(D)=tubesheet, 1 dished head)
                .Label1.Load(8)
                .Label1(8).Text = "End closure  : - at left     "
                .Combo2.Load(8)
                .Combo2(8).Items.Clear()
                .Combo2(8).Items.Add("TubeSheet")
                .Combo2(8).Items.Add("Hemispherical Head")
                .Combo2(8).Items.Add("2:1 elliptical Head")
                '  SendMessage(.Combo2(8).hwnd, CB_SETDROPPEDWIDTH, 200, 0)
                mioContr(8) = .Combo2(8)
                '-----------------------------------------------
                '(0(D)=tubesheet, 1 dished head)
                .Label1.Load(9)
                .Label1(9).Text = "End closure  : - at right    "
                .Combo2.Load(9)
                .Combo2(9).Items.Clear()
                .Combo2(9).Items.Add("TubeSheet")
                .Combo2(9).Items.Add("Hemispherical Head")
                .Combo2(9).Items.Add("2:1 elliptical Head")
                ' SendMessage(.Combo2(9).hwnd, CB_SETDROPPEDWIDTH, 200, 0)
                mioContr(9) = .Combo2(9)
                '-----------------------------------------------
                '   "Shell material : ((0) carbon steel , 1 stainless steel)     "
                .Label1.Load(10)
                .Label1(10).Text = "Shell Material  : Type  "
                .Combo2.Load(10)
                .Combo2(10).Items.Clear()
                .Combo2(10).Items.Add("carbon steel")
                .Combo2(10).Items.Add("stainless steel")
                .Combo2(10).SelectedIndex = SaddlesItem.TipoMat
                mioContr(10) = .Combo2(10)
                '----------------------------------------------------
                .Label1.Load(11)
                .Label1.Load(12)
                .Label1.Load(13)
                If Problem.Codice = 0 Then
                    .Label1(11).Text = "Shell allowable stress : - away from saddles"
                    .Label1(12).Text = "                               - on left saddle   "
                    .Label1(13).Text = "                               - on right saddle  "
                Else
                    .Label1(11).Text = "Yield stress at temperature"
                    .Label1(12).Text = "Tensile stress at room"
                    .Label1(13).Text = "Allowable stress (f or f1)"
                End If
                For i = 11 To 13
                    .Label2(i).Text = "MPa"
                    .Text1.Load(i)
                    .Text1(i).Text = GlobalRoutines.myStr(SaddlesLoad(iCond).AmmShell(i - 11), 5, 2, 0)
                    mioContr(i) = .Text1(i)
                Next
                '--------------------------------------
                .Label1.Load(14)
                .Label1.Load(15)
                .Label1.Load(16)
                If Problem.Codice = 0 Then
                    .Label1(14).Text = "Shell Young Modulus: - away from the saddles "
                    .Label1(15).Text = "                           - on left saddle  "
                    .Label1(16).Text = "                           - on right saddle  "
                Else
                    .Label1(14).Text = "Shell Young Modulus at temperature"
                    .Label1(15).Text = "Shell strength reduction coeff. z"
                    .Label1(16).Text = "Head strength reduction coeff. z"
                End If
                For i = 14 To 16
                    .Label2(i).Text = "MPa"
                    If i > 14 And Problem.Codice = 1 Then .Label2(i).Text = "--"
                    .Text1.Load(i)
                    mioContr(i) = .Text1(i)
                Next
                '--------------------------------------
                .Label1.Load(17)
                .Label1(17).Text = "Allowable stress on saddle : - left support"
                .Label1.Load(18)
                .Label1(18).Text = "                                             - right support"
                For i = 17 To 18
                    .Label2(i).Text = "MPa"
                    .Text1.Load(i)
                    mioContr(i) = .Text1(i)
                Next
                '--------------------------------------
                .Label1.Load(19)
                .Label1(19).Text = "Left head : - allowable stress  "
                .Label1.Load(20)
                .Label1(20).Text = "            - maximum tensile stress "
                .Label1.Load(21)
                .Label1(21).Text = "Right head : - allowable stress "
                .Label1.Load(22)
                .Label1(22).Text = "            - maximum tensile stress "
                .Text1.Load(19)
                .Text1.Load(20)
                .Text1.Load(21)
                .Text1.Load(22)
                If Problem.Codice = 1 Then
                    .Label1(20).Text = ""
                    .Label1(22).Text = ""
                    .Text1(20).Enabled = False
                    .Text1(22).Enabled = False
                End If
                'Call AggSaddlesPagina()
                For i = 19 To 22
                    .Label2(i).Text = "MPa"
                    mioContr(i) = .Text1(i)
                Next
                '----------------------------------------------------
                For i = 0 To Ncontr
                    .Label1(i).Left = 0
                    .Label1(i).Top = i * .Label1(i).Height
                    .Label1(i).BringToFront()
                    .Label2(i).Left = .Label1(i).Width
                    .Label2(i).Top = i * .Label2(i).Height
                    mioContr(i).Left = .Label2(0).Left + .Label2(0).Width
                    mioContr(i).Top = i * .Label1(0).Height
                    mioContr(i).TabIndex = i : mioContr(i).Visible = True
                    .Label1(i).Visible = True
                    .Label2(i).Visible = True
                    mioContr(i).Enabled = True
                    .Label1(i).Enabled = True
                    .Label2(i).Enabled = True
                Next
                Ncontr = CShort(Ncontr + 5)
                For i = 23 To Ncontr
                    .Label1.Load(i)
                    .Label1(i).Top = .Label1(i - 20).Top
                    .Label1(i).Left = mioContr(i - 20).Left + mioContr(i - 20).Width
                    .Label1(i).Text = "NOTE:  including the weight of the head"
                    .Label1(i).Visible = True
                Next
                .Label1(23).Text = "NOTE:  including the weight of the head(s)"
                Ncontr = CShort(Ncontr + 1) ' cioè 28
                .Label1.Load(Ncontr)
                .Label1(Ncontr).Top = .Label1(0).Top
                .Label1(Ncontr).Left = mioContr(0).Left + mioContr(0).Width
                .Label1(Ncontr).Text = "Caso di carico"
                .Label1(Ncontr).Width = CInt(GlobalRoutines.TwipsToPixelsX(1200))
                .Combo2.Load(Ncontr)
                .Combo2(Ncontr).Items.Clear()
                Call DispCond(.Combo2(Ncontr), 1)
                mioContr(Ncontr) = .Combo2(Ncontr)
                mioContr(Ncontr).Top = mioContr(0).Top
                mioContr(Ncontr).Left = .Label1(Ncontr).Left + .Label1(Ncontr).Width
                mioContr(Ncontr).Width = .PagCalcMantProg.Width - mioContr(Ncontr).Left
                .Label1(Ncontr).Visible = True : mioContr(Ncontr).Visible = True : mioContr(Ncontr).Enabled = True
                Delty = CShort(23 * .Label1(0).Height + .TabTensMantDown.GetTabRect(0).Height + 4 * SystemInformation.Border3DSize.Height)
                .TabTensMantDown.Height = Math.Max(.TabTensMantDown.Height, Delty)
                Ncontr = CShort(Ncontr + 1) 'cioè 29
                .Label1.Load(Ncontr)
                .Label1(Ncontr).Width = CInt(GlobalRoutines.TwipsToPixelsX(1000))
                .Label1(Ncontr).Text = "Materiale"
                .Text1.Load(Ncontr)
                '.Text1(Ncontr).Alignment = 0
                .Text1(Ncontr).Enabled = False
                .Label1(Ncontr).Top = .Label1(10).Top
                .Label1(Ncontr).Left = CInt(.Combo2(10).Left + .Combo2(10).Width + SystemInformation.Border3DSize.Width)
                .Text1(Ncontr).Top = .Label1(Ncontr).Top
                .Text1(Ncontr).Left = .Label1(Ncontr).Left + .Label1(Ncontr).Width
                .Text1(Ncontr).Width = CInt(GlobalRoutines.TwipsToPixelsX(1700))
                .cmdMat.Visible = True
                .cmdMat.Top = .Label1(Ncontr).Top
                .cmdMat.Left = CInt(.Text1(Ncontr).Left + .Text1(Ncontr).Width + SystemInformation.Border3DSize.Width)
                .cmdAmmiss.Visible = True
                .cmdAmmiss.Top = .Label1(11).Top
                .cmdAmmiss.Left = CInt(.Text1(11).Left + .Text1(11).Width + 2 * SystemInformation.Border3DSize.Width)
                .Label1(Ncontr).Visible = True
                .Text1(Ncontr).Visible = True
                .Text1(Ncontr).Enabled = True
                mioContr(Ncontr) = .Text1(Ncontr)
                .ApplicaCodice(Problem.Codice)
            Catch e As Exception
                MsgBox(e.Message + vbCrLf + e.StackTrace)
            End Try
            .Cursor = Cursors.Default
        End With
    End Sub
    Sub SecondaPaginaT()
        Dim i, Delty As Short
        If Inizializzando Then Exit Sub
        If iCond > Problem.NCond(1) - 1 Then iCond = 0
        With frmSaddles.DefInstance
            Try
                If .Text1T.Count > 1 Then
                    .Combo2T(28).Items.Clear()
                    Call DispCondT(.Combo2T(28), 1)
                    Exit Sub
                End If
                .Cursor = Cursors.WaitCursor
                Ncontr = 22
                For i = 1 To Ncontr
                    .Label2T.Load(i)
                    .Label2T(i).Text = ""
                    .Label2T(i).BringToFront()
                Next
                .Label1T(0).Text = "Simple Vessel with symmetrical saddles ?"
                .Combo2T(0).Width = CInt(GlobalRoutines.TwipsToPixelsX(1065))
                .Combo2T(0).Items.Clear()
                .Combo2T(0).Items.Add("Simple")
                .Combo2T(0).Items.Add("Complex")
                mioContrT(0) = .Combo2T(0)
                '-------------------------------------------
                .Label1T.Load(1)
                .Label1T(1).Text = "Design data : - pressure ( - sign if external)"
                .Label2T(1).Text = "MPa"
                .Text1T.Load(1)
                mioContrT(1) = .Text1T(1)
                '---------------------------------
                .Label1T.Load(2)
                .Label1T(2).Text = "Design data : - temperature"
                .Label2T(2).Text = "°C"
                .Text1T.Load(2)
                mioContrT(2) = .Text1T(2)
                '------------------------------------------------
                .Label1T.Load(3)
                .Label1T(3).Text = "Exchanger/Vessel total weight"
                .Label2T(3).Text = "kN"
                .Text1T.Load(3)
                mioContrT(3) = .Text1T(3)
                '------------------------------------------------
                .Label1T.Load(4)
                .Label1T(4).Text = "Concentrated weight : - on left end"
                .Label2T(4).Text = "kN"
                .Text1T.Load(4)
                mioContrT(4) = .Text1T(4)
                '------------------------------------------------
                .Label1T.Load(5)
                .Label1T(5).Text = "Concentrated weight : - on right end"
                .Label2T(5).Text = "kN"
                .Text1T.Load(5)
                mioContrT(5) = .Text1T(5)
                '-----------------------------------------------
                .Label1T.Load(6)
                .Label1T(6).Text = "Moment : - at left end  ( + if counterclockwise)"
                .Label2T(6).Text = "kN.m"
                .Text1T.Load(6)
                mioContrT(6) = .Text1T(6)
                '-----------------------------------------------
                .Label1T.Load(7)
                .Label1T(7).Text = "Moment : - at right end ( + if clockwise )"
                .Label2T(7).Text = "kN.m"
                .Text1T.Load(7)
                mioContrT(7) = .Text1T(7)
                '-----------------------------------------------
                '(0(D)=tubesheet, 1 dished head)
                .Label1T.Load(8)
                .Label1T(8).Text = "End closure  : - at left     "
                .Combo2T.Load(8)
                .Combo2T(8).Items.Clear()
                .Combo2T(8).Items.Add("TubeSheet")
                .Combo2T(8).Items.Add("Hemispherical Head")
                .Combo2T(8).Items.Add("2:1 elliptical Head")
                '  SendMessage(.Combo2T(8).hwnd, CB_SETDROPPEDWIDTH, 200, 0)
                mioContrT(8) = .Combo2T(8)
                '-----------------------------------------------
                '(0(D)=tubesheet, 1 dished head)
                .Label1T.Load(9)
                .Label1T(9).Text = "End closure  : - at right    "
                .Combo2T.Load(9)
                .Combo2T(9).Items.Clear()
                .Combo2T(9).Items.Add("TubeSheet")
                .Combo2T(9).Items.Add("Hemispherical Head")
                .Combo2T(9).Items.Add("2:1 elliptical Head")
                ' SendMessage(.Combo2T(9).hwnd, CB_SETDROPPEDWIDTH, 200, 0)
                mioContrT(9) = .Combo2T(9)
                '-----------------------------------------------
                '   "Shell material : ((0) carbon steel , 1 stainless steel)     "
                .Label1T.Load(10)
                .Label1T(10).Text = "Shell Material  : Type  "
                .Combo2T.Load(10)
                .Combo2T(10).Items.Clear()
                .Combo2T(10).Items.Add("carbon steel")
                .Combo2T(10).Items.Add("stainless steel")
                .Combo2T(10).SelectedIndex = SaddlesItem.TipoMat
                mioContrT(10) = .Combo2T(10)
                '----------------------------------------------------
                .Label1T.Load(11)
                .Label1T.Load(12)
                .Label1T.Load(13)
                If Problem.Codice = 0 Then
                    .Label1T(11).Text = "Shell allowable stress : - away from saddles"
                    .Label1T(12).Text = "                               - on left saddle   "
                    .Label1T(13).Text = "                               - on right saddle  "
                Else
                    .Label1T(11).Text = "Yield stress at temperature"
                    .Label1T(12).Text = "Tensile stress at room"
                    .Label1T(13).Text = "Allowable stress (f or f1)"
                End If
                For i = 11 To 13
                    .Label2T(i).Text = "MPa"
                    .Text1T.Load(i)
                    .Text1T(i).Text = GlobalRoutines.myStr(SaddlesLoadT(iCond).AmmShell(i - 11), 4, 2, 0)
                    mioContrT(i) = .Text1T(i)
                Next
                '--------------------------------------
                .Label1T.Load(14)
                .Label1T.Load(15)
                .Label1T.Load(16)
                If Problem.Codice = 0 Then
                    .Label1T(14).Text = "Shell Young Modulus: - away from the saddles "
                    .Label1T(15).Text = "                           - on left saddle  "
                    .Label1T(16).Text = "                           - on right saddle  "
                Else
                    .Label1T(14).Text = "Shell Young Modulus at temperature"
                    .Label1T(15).Text = "Shell strength reduction coeff. z"
                    .Label1T(16).Text = "Head strength reduction coeff. z"
                End If
                For i = 14 To 16
                    .Label2T(i).Text = "MPa"
                    If i > 14 And Problem.Codice = 1 Then .Label2T(i).Text = "--"
                    .Text1T.Load(i)
                    mioContrT(i) = .Text1T(i)
                Next
                '--------------------------------------
                .Label1T.Load(17)
                .Label1T(17).Text = "Allowable stress on saddle : - left support"
                .Label1T.Load(18)
                .Label1T(18).Text = "                                             - right support"
                For i = 17 To 18
                    .Label2T(i).Text = "MPa"
                    .Text1T.Load(i)
                    mioContrT(i) = .Text1T(i)
                Next
                '--------------------------------------
                .Label1T.Load(19)
                .Label1T(19).Text = "Left head : - allowable stress  "
                .Label1T.Load(20)
                .Label1T(20).Text = "            - maximum tensile stress "
                .Label1T.Load(21)
                .Label1T(21).Text = "Right head : - allowable stress "
                .Label1T.Load(22)
                .Label1T(22).Text = "            - maximum tensile stress "
                .Text1T.Load(19)
                .Text1T.Load(20)
                .Text1T.Load(21)
                .Text1T.Load(22)
                If Problem.Codice = 1 Then
                    .Label1T(20).Text = ""
                    .Label1T(22).Text = ""
                    .Text1T(20).Enabled = False
                    .Text1T(22).Enabled = False
                End If
                'Call AggSaddlesPagina()
                For i = 19 To 22
                    .Label2T(i).Text = "MPa"
                    mioContrT(i) = .Text1T(i)
                Next
                '----------------------------------------------------
                For i = 0 To Ncontr
                    .Label1T(i).Left = 0
                    .Label1T(i).Top = i * .Label1T(i).Height
                    .Label1T(i).BringToFront()
                    .Label2T(i).Left = .Label1T(i).Width
                    .Label2T(i).Top = i * .Label2T(i).Height
                    mioContrT(i).Left = .Label2T(0).Left + .Label2T(0).Width
                    mioContrT(i).Top = i * .Label1T(0).Height
                    mioContrT(i).TabIndex = i : mioContrT(i).Visible = True
                    .Label1T(i).Visible = True
                    .Label2T(i).Visible = True
                    mioContrT(i).Enabled = True
                    .Label1T(i).Enabled = True
                    .Label2T(i).Enabled = True
                Next
                Ncontr = CShort(Ncontr + 5)
                For i = 23 To Ncontr
                    .Label1T.Load(i)
                    .Label1T(i).Top = .Label1T(i - 20).Top
                    .Label1T(i).Left = mioContrT(i - 20).Left + mioContrT(i - 20).Width
                    .Label1T(i).Text = "NOTE:  including the weight of the head"
                    .Label1T(i).Visible = True
                Next
                .Label1T(23).Text = "NOTE:  including the weight of the head(s)"
                Ncontr = CShort(Ncontr + 1) ' cioè 28
                .Label1T.Load(Ncontr)
                .Label1T(Ncontr).Top = .Label1T(0).Top
                .Label1T(Ncontr).Left = mioContrT(0).Left + mioContrT(0).Width
                .Label1T(Ncontr).Text = "Caso di carico"
                .Label1T(Ncontr).Width = CInt(GlobalRoutines.TwipsToPixelsX(1200))
                .Combo2T.Load(Ncontr)
                .Combo2T(Ncontr).Items.Clear()
                Call DispCond(.Combo2T(Ncontr), 1)
                mioContrT(Ncontr) = .Combo2T(Ncontr)
                mioContrT(Ncontr).Top = mioContrT(0).Top
                mioContrT(Ncontr).Left = .Label1T(Ncontr).Left + .Label1T(Ncontr).Width
                mioContrT(Ncontr).Width = .PagCalcMantProgT.Width - mioContrT(Ncontr).Left
                .Label1T(Ncontr).Visible = True : mioContrT(Ncontr).Visible = True : mioContrT(Ncontr).Enabled = True
                Delty = CShort(23 * .Label1T(0).Height + .TabTensMantUp.GetTabRect(0).Height + 4 * SystemInformation.Border3DSize.Height)
                .TabTensMantUp.Height = Math.Max(.TabTensMantUp.Height, Delty)
                Ncontr = CShort(Ncontr + 1) 'cioè 29
                .Label1T.Load(Ncontr)
                .Label1T(Ncontr).Width = CInt(GlobalRoutines.TwipsToPixelsX(1000))
                .Label1T(Ncontr).Text = "Materiale"
                .Text1T.Load(Ncontr)
                '.Text1T(Ncontr).Alignment = 0
                .Text1T(Ncontr).Enabled = False
                .Label1T(Ncontr).Top = .Label1T(10).Top
                .Label1T(Ncontr).Left = CInt(.Combo2T(10).Left + .Combo2T(10).Width + SystemInformation.Border3DSize.Width)
                .Text1T(Ncontr).Top = .Label1T(Ncontr).Top
                .Text1T(Ncontr).Left = .Label1T(Ncontr).Left + .Label1T(Ncontr).Width
                .Text1T(Ncontr).Width = CInt(GlobalRoutines.TwipsToPixelsX(1700))
                .cmdMatT.Visible = True
                .cmdMatT.Top = .Label1T(Ncontr).Top
                .cmdMatT.Left = CInt(.Text1T(Ncontr).Left + .Text1T(Ncontr).Width + SystemInformation.Border3DSize.Width)
                .cmdAmmissT.Visible = True
                .cmdAmmissT.Top = .Label1T(11).Top
                .cmdAmmissT.Left = CInt(.Text1T(11).Left + .Text1T(11).Width + 2 * SystemInformation.Border3DSize.Width)
                .Label1T(Ncontr).Visible = True
                .Text1T(Ncontr).Visible = True
                .Text1T(Ncontr).Enabled = True
                mioContrT(Ncontr) = .Text1T(Ncontr)
                .ApplicaCodiceT(Problem.Codice)
            Catch e As Exception
                MsgBox(e.Message + vbCrLf + e.StackTrace)
            End Try
            .Cursor = Cursors.Default
        End With
    End Sub
    Function TensAmm(ByVal iBtmTop As Short) As Boolean
        Dim i As Integer
        Dim Msgg As String
        TensAmm = True
2070:   '--------Calculation of allowable stresses -----------------
2090:   '--------Compressive stresses-------------------------------
2100:   pAreaLav(iCond, iBtmTop).SFAT = 1.4 : If pSaddlesItem(iBtmTop).TipoMat = 1 Then pAreaLav(iCond, iBtmTop).SFAT = 1.1
        For i = 0 To 2
            pAreaLav(iCond, iBtmTop).PYSS(i) = 2 * pAreaLav(iCond, iBtmTop).SFAT * pSaddlesLoad(iCond, iBtmTop).AmmShell(i) * pSaddlesItem(iBtmTop).Spess(i) / pSaddlesItem(iBtmTop).MeanR(i)
            If pAreaLav(iCond, iBtmTop).PYSS(i) = 0 Then
                Msgg = "Ci sono dei dati mancanti per la condizione di carico "
                Msgg = Msgg & RTrim(Problem.LoadCond(1, iCond + 1))
                MsgBox(Msgg, MsgBoxStyle.Exclamation Or MsgBoxStyle.OKOnly)
                TensAmm = False
                Exit Function
            End If
            pAreaLav(iCond, iBtmTop).PE(i) = CSng(1.21 * pSaddlesLoad(iCond, iBtmTop).Young(i) * pSaddlesItem(iBtmTop).Spess(i) ^ 2 / pSaddlesItem(iBtmTop).MeanR(i) ^ 2)
            pAreaLav(iCond, iBtmTop).KFAT(i) = pAreaLav(iCond, iBtmTop).PE(i) / pAreaLav(iCond, iBtmTop).PYSS(i)
        Next
2250:   If pSaddlesLoad(iCond, iBtmTop).DesTemp > 350 And pSaddlesLoad(iCond, iBtmTop).DesPress < 0 Then Call Compress() Else Call Tension(iBtmTop) 'gOTO 2370
2610:   For i = 0 To 2
            pAreaLav(iCond, iBtmTop).FALC(i) = pAreaLav(iCond, iBtmTop).DEL(i) * pAreaLav(iCond, iBtmTop).SFAT * pSaddlesLoad(iCond, iBtmTop).AmmShell(i)
            '---------------Allowable tangential shearing stresses -----
            pAreaLav(iCond, iBtmTop).SAL(i) = CSng(0.06 * pSaddlesLoad(iCond, iBtmTop).Young(i) * pSaddlesItem(iBtmTop).Spess(i) / pSaddlesItem(iBtmTop).MeanR(i))
            If pAreaLav(iCond, iBtmTop).SAL(i) > 0.8 * pSaddlesLoad(iCond, iBtmTop).AmmShell(i) Then pAreaLav(iCond, iBtmTop).SAL(i) = CSng(0.8 * pSaddlesLoad(iCond, iBtmTop).AmmShell(i))
            If i > 0 Then
                If pSaddlesItem(iBtmTop).TipoChius(i) > 0 Then pAreaLav(iCond, iBtmTop).SALH(i) = CSng(1.25 * pSaddlesLoad(iCond, iBtmTop).AmmHead(i) - pSaddlesLoad(iCond, iBtmTop).AmmHeadTens(i))
            End If
        Next
    End Function

    Sub Tension(ByVal iBtmTop As Short)
        Dim i As Short
        For i = 0 To 2
2270:       If pAreaLav(iCond, iBtmTop).KFAT(i) > 24 Then
                pAreaLav(iCond, iBtmTop).DEL(i) = 0.6
2280:       ElseIf pAreaLav(iCond, iBtmTop).KFAT(i) < 8 Then
                pAreaLav(iCond, iBtmTop).DEL(i) = CSng(0.5 * (1 - (1 - 0.125 * pAreaLav(iCond, iBtmTop).KFAT(i)) ^ 2))
            Else
2290:           pAreaLav(iCond, iBtmTop).DEL(i) = CSng(0.45 + 0.00625 * pAreaLav(iCond, iBtmTop).KFAT(i))
            End If
        Next
        'ERRATA? VEDI BS Fig. 3.6(3) curva (b)
    End Sub
    Sub TMComplex(ByVal iBtmTop As Short)
        Dim M3X, X As Single
        Dim k As Short
        Dim XX As Single
        Dim Ix, Ix1 As Short
        Dim i1 As Short
        Dim kk, Dummy As Single
        i1 = Problem.Codice
        If Problem.Codice = 0 Then
            kk = 1
        Else
            Select Case iCond
                Case 1, 3 : kk = CSng(System.Math.Sqrt(pSaddlesItem(iBtmTop).MeanR(0) / pSaddlesItem(iBtmTop).Lungh(0) * System.Math.Sqrt(pSaddlesItem(iBtmTop).MeanR(0) / pSaddlesItem(iBtmTop).Spess(0))))
                    If kk < 1 Then kk = 1
                Case 0, 2 : kk = 1
            End Select
        End If
        With pAreaLav(iCond, iBtmTop).TensMiddle
            For k = i1 To 1
                XX = pSaddlesItem(iBtmTop).Lungh(0) / 100
                .M3NG = 1.0E+20
                .M3PS = -1.0E+20
                For Ix = 1 To 101
                    Ix1 = CShort(Ix - 1)
                    X = Ix1 * XX
                    M3X = CSng(pAreaLav(iCond, iBtmTop).Q * pSaddlesItem(iBtmTop).Lungh(0) / 2 * (X - X ^ 2 / pSaddlesItem(iBtmTop).Lungh(0)) + pAreaLav(iCond, iBtmTop).Momen(1) * (1 - X / pSaddlesItem(iBtmTop).Lungh(0)) + pAreaLav(iCond, iBtmTop).Momen(2) * X / pSaddlesItem(iBtmTop).Lungh(0))
                    If M3X < .M3NG Then .M3NG = M3X : XNG = X
                    If M3X > .M3PS Then .M3PS = M3X : XPS = X
                Next Ix
                .F1NG(k - i1) = pSaddlesLoad(iCond, iBtmTop).DesPress * k * pSaddlesItem(iBtmTop).MeanR(0) / (2 * pSaddlesItem(iBtmTop).Spess(0)) - kk * .M3NG / pSaddlesItem(iBtmTop).w(0)
                .F2NG(k - i1) = pSaddlesLoad(iCond, iBtmTop).DesPress * k * pSaddlesItem(iBtmTop).MeanR(0) / (2 * pSaddlesItem(iBtmTop).Spess(0)) + kk * .M3NG / pSaddlesItem(iBtmTop).w(0)
                .F1PS(k - i1) = pSaddlesLoad(iCond, iBtmTop).DesPress * k * pSaddlesItem(iBtmTop).MeanR(0) / (2 * pSaddlesItem(iBtmTop).Spess(0)) - kk * .M3PS / pSaddlesItem(iBtmTop).w(0)
                .F2PS(k - i1) = pSaddlesLoad(iCond, iBtmTop).DesPress * k * pSaddlesItem(iBtmTop).MeanR(0) / (2 * pSaddlesItem(iBtmTop).Spess(0)) + kk * .M3PS / pSaddlesItem(iBtmTop).w(0)
            Next k
            If Problem.Codice = 0 Then Exit Sub
            .F1PS(1) = pSaddlesLoad(iCond, iBtmTop).DesPress * pSaddlesItem(iBtmTop).MeanR(0) / pSaddlesItem(iBtmTop).Spess(0)
            .F1NG(1) = pSaddlesLoad(iCond, iBtmTop).DesPress * pSaddlesItem(iBtmTop).MeanR(0) / pSaddlesItem(iBtmTop).Spess(0)
            .F2PS(1) = CSng(System.Math.Sqrt(.F1PS(0) ^ 2 + .F1PS(1) ^ 2 - .F1PS(0) * .F1PS(1)))
            Dummy = CSng(System.Math.Sqrt(.F2PS(0) ^ 2 + .F1PS(1) ^ 2 - .F2PS(0) * .F1PS(1)))
            If Dummy > .F2PS(1) Then .F2PS(1) = Dummy
            .F2NG(1) = CSng(System.Math.Sqrt(.F1NG(0) ^ 2 + .F1NG(1) ^ 2 - .F1NG(0) * .F1NG(1)))
            Dummy = CSng(System.Math.Sqrt(.F2NG(0) ^ 2 + .F1NG(1) ^ 2 - .F2NG(0) * .F1NG(1)))
            If Dummy > .F2NG(1) Then .F2NG(1) = Dummy
        End With
    End Sub
    Sub TMSimple(ByVal iBtmTop As Short)
        Dim k As Short
        Dim XSI1, XSI2 As Single
        For k = 0 To 1
            XSI1 = CSng(1 + 2 * (pSaddlesItem(iBtmTop).MeanR(0) ^ 2 - pSaddlesItem(iBtmTop).HeadHeight ^ 2) / pSaddlesItem(iBtmTop).LT ^ 2)
            XSI2 = 1 + 4 * pSaddlesItem(iBtmTop).HeadHeight / (3 * pSaddlesItem(iBtmTop).LT)
            pAreaLav(iCond, iBtmTop).TensMiddle.M3PS = AreaLav(iCond).React(1) * pSaddlesItem(iBtmTop).LT / 4 * (XSI1 / XSI2 - 4 * pSaddlesItem(iBtmTop).Lungh(1) / pSaddlesItem(iBtmTop).LT)
            pAreaLav(iCond, iBtmTop).TensMiddle.F1PS(k) = pSaddlesLoad(iCond, iBtmTop).DesPress * pSaddlesItem(iBtmTop).MeanR(0) / (2 * pSaddlesItem(iBtmTop).Spess(0)) - pAreaLav(iCond, iBtmTop).TensMiddle.M3PS / pSaddlesItem(iBtmTop).w(0)
            pAreaLav(iCond, iBtmTop).TensMiddle.F2PS(k) = pSaddlesLoad(iCond, iBtmTop).DesPress * pSaddlesItem(iBtmTop).MeanR(0) / (2 * pSaddlesItem(iBtmTop).Spess(0)) + pAreaLav(iCond, iBtmTop).TensMiddle.M3PS / pSaddlesItem(iBtmTop).w(0)
        Next k
    End Sub
    Public Sub StampaSaddles(ByVal iBtmTop As Short)
        Dim SIGMAC, SIGMAT, Factor As Single
        Dim FALLS1 As Single
        Dim i As Short
        Dim FONDO1 As String = ""
        Dim FONDO2 As String = ""
        Dim ifl, j As Short
        Dim ChangTab2, ChangTab1, ChangTab3 As String
        Dim Brack3, Brack1, Brack2, Brack4 As String
50:     Dim GU1(32) As String
        Dim GU2(34) As String
        Dim RIS(50) As String
        Dim FAL61 As Single
        Dim Mode As Short
        With Monitor.Motore.Problem
            ifl = CShort(FreeFile())
            If Problem.Codice = 0 Then
                FileOpen(ifl, Monitor.Motore.Inizio.Archdir.Trim & "\WR\SADD01.SDD", OpenMode.Input, , OpenShare.Shared)
            Else
                FileOpen(ifl, Monitor.Motore.Inizio.Archdir.Trim & "\WR\SADD31.SDD", OpenMode.Input, , OpenShare.Shared)
            End If
            For i = 1 To 24 : GU1(i) = LineInput(ifl) : Next
            For i = 1 To 30 : GU2(i) = LineInput(ifl) : Next
            FileClose(ifl)
6760:       .Printa("Client and Plant        " & Problem.ClientPlant & Par)
6770:       .Printa("Item                    " & Problem.Item & Par)
            Call StLoadC(1)
6790:       .Printa("---------------------------------------------------------------" & Par)
6800:       .Printa("Analysis according to " & frmSaddles.DefInstance.Codice & Par)
6810:       .Printa("INPUT DATA              " & Par)
6820:       .Printa("---------------------------------------------------------------" & Par)
6830:       .Printa(GlobalRoutines.FormatS(GU1(1), pSaddlesLoad(iCond, iBtmTop).DesPress) & Par)
6840:       .Printa(GlobalRoutines.FormatS(GU1(2), pSaddlesLoad(iCond, iBtmTop).DesTemp) & Par)
6850:       .Printa(GlobalRoutines.FormatS(GU1(3), pSaddlesLoad(iCond, iBtmTop).PesoTot) & Par)
6851:       If pSaddlesItem(iBtmTop).Simple = "N" Then GoTo 6860 Else GoTo 6910
6860:       .Printa(GlobalRoutines.FormatS(GU1(4), pSaddlesLoad(iCond, iBtmTop).PesoS(1)) & Par)
6870:       .Printa(GlobalRoutines.FormatS(GU1(5), pSaddlesLoad(iCond, iBtmTop).PesoS(2)) & Par)
6880:       .Printa(GU1(6) & Par)
6890:       .Printa(GlobalRoutines.FormatS(GU1(7), pSaddlesLoad(iCond, iBtmTop).MomS(1)) & Par)
6900:       .Printa(GlobalRoutines.FormatS(GU1(8), pSaddlesLoad(iCond, iBtmTop).MomS(2)) & Par)
6910:       Select Case pSaddlesItem(iBtmTop).TipoChius(1)
                Case 0 : FONDO1 = "Tubesheet"
                Case 1 : FONDO1 = "Hemisph.head"
                Case 2 : FONDO1 = "2:1 ell. head"
            End Select
            Select Case pSaddlesItem(iBtmTop).TipoChius(2)
                Case 0 : FONDO2 = "Tubesheet"
                Case 1 : FONDO2 = "Hemisph.head"
                Case 2 : FONDO2 = "2:1 ell. head"
            End Select
6930:       .Printa(GU1(9) & FONDO1 & Par)
6940:       .Printa(GU1(10) & FONDO2 & Par)
6950:       If pSaddlesItem(iBtmTop).TipoMat = 0 Then .Printa(GU1(11) & "Carbon Steel" & Par)
6960:       If pSaddlesItem(iBtmTop).TipoMat = 1 Then .Printa(GU1(11) & "Stainless Steel" & Par)
6970:       .Printa(GU1(12) & Par)
6980:       .Printa(GlobalRoutines.FormatS(GU1(13), pSaddlesLoad(iCond, iBtmTop).AmmShell(0)) & Par)
6990:       .Printa(GlobalRoutines.FormatS(GU1(14), pSaddlesLoad(iCond, iBtmTop).AmmShell(1)) & Par)
7000:       .Printa(GlobalRoutines.FormatS(GU1(15), pSaddlesLoad(iCond, iBtmTop).AmmShell(2)) & Par)
7010:       .Printa(GlobalRoutines.FormatS(GU1(16), pSaddlesLoad(iCond, iBtmTop).Young(0)) & Par)
7020:       .Printa(GlobalRoutines.FormatS(GU1(17), pSaddlesLoad(iCond, iBtmTop).Young(1)) & Par)
7030:       .Printa(GlobalRoutines.FormatS(GU1(18), pSaddlesLoad(iCond, iBtmTop).Young(2)) & Par)
7040:       .Printa(GlobalRoutines.FormatS(GU1(19), pSaddlesLoad(iCond, iBtmTop).AmmSadd(1)) & Par)
7050:       .Printa(GlobalRoutines.FormatS(GU1(20), pSaddlesLoad(iCond, iBtmTop).AmmSadd(2)) & Par)
7060:       If pSaddlesItem(iBtmTop).TipoChius(1) = 0 Then GoTo 7090
7070:       .Printa(GlobalRoutines.FormatS(GU1(21), pSaddlesLoad(iCond, iBtmTop).AmmHead(1)) & Par)
7080:       .Printa(GlobalRoutines.FormatS(GU1(22), pSaddlesLoad(iCond, iBtmTop).AmmHeadTens(1)) & Par)
7090:       If pSaddlesItem(iBtmTop).TipoChius(2) = 0 Then GoTo 7120
7100:       .Printa(GlobalRoutines.FormatS(GU1(23), pSaddlesLoad(iCond, iBtmTop).AmmHead(2)) & Par)
7110:       .Printa(GlobalRoutines.FormatS(GU1(24), pSaddlesLoad(iCond, iBtmTop).AmmHeadTens(2)) & Par)
7120:       .Printa(GlobalRoutines.FormatS(GU2(1), pSaddlesItem(iBtmTop).Diam) & Par)
7130:       .Printa(GlobalRoutines.FormatS(GU2(2), pSaddlesItem(iBtmTop).Spess(0)) & Par)
7140:       .Printa(GlobalRoutines.FormatS(GU2(3), pSaddlesItem(iBtmTop).Spess(1)) & Par)
7150:       .Printa(GlobalRoutines.FormatS(GU2(4), pSaddlesItem(iBtmTop).Spess(2)) & Par)
7160:       .Printa(GU2(5) & Par)
7170:       .Printa(GlobalRoutines.FormatS(GU2(6), pSaddlesItem(iBtmTop).Lungh(0)) & Par)
7180:       .Printa(GlobalRoutines.FormatS(GU2(7), pSaddlesItem(iBtmTop).Lungh(1)) & Par)
7190:       .Printa(GlobalRoutines.FormatS(GU2(8), pSaddlesItem(iBtmTop).Lungh(2)) & Par)
7200:       .Printa(GlobalRoutines.FormatS(GU2(9), pSaddlesItem(iBtmTop).GeomSadd(1).AxialWidth) & Par)
7210:       .Printa(GlobalRoutines.FormatS(GU2(10), pSaddlesItem(iBtmTop).GeomSadd(2).AxialWidth) & Par)
7220:       .Printa(GlobalRoutines.FormatS(GU2(11), pSaddlesItem(iBtmTop).GeomSadd(1).IncluAngle) & Par)
7230:       .Printa(GlobalRoutines.FormatS(GU2(12), pSaddlesItem(iBtmTop).GeomSadd(2).IncluAngle) & Par)
7240:       .Printa(GlobalRoutines.FormatS(GU2(13), pSaddlesItem(iBtmTop).GeomSadd(1).PlateWidth) & Par)
7250:       .Printa(GlobalRoutines.FormatS(GU2(14), pSaddlesItem(iBtmTop).GeomSadd(2).PlateWidth) & Par)
7260:       .Printa(GlobalRoutines.FormatS(GU2(15), pSaddlesItem(iBtmTop).GeomSadd(1).PlateAngle) & Par)
7270:       .Printa(GlobalRoutines.FormatS(GU2(16), pSaddlesItem(iBtmTop).GeomSadd(2).PlateAngle) & Par)
7280:       .Printa(GlobalRoutines.FormatS(GU2(17), pSaddlesItem(iBtmTop).GeomSadd(1).PlateThk) & Par)
7290:       .Printa(GlobalRoutines.FormatS(GU2(18), pSaddlesItem(iBtmTop).GeomSadd(2).PlateThk) & Par)
7300:       .Printa(GlobalRoutines.FormatS(GU2(19), pSaddlesItem(iBtmTop).GeomSadd(1).SaddlThk) & Par)
7310:       .Printa(GlobalRoutines.FormatS(GU2(20), pSaddlesItem(iBtmTop).GeomSadd(2).SaddlThk) & Par)
            If pSaddlesItem(iBtmTop).GeomSadd(1).SupRing Then .Printa(GlobalRoutines.FormatS(GU2(25), "YES") & Par) Else .Printa(GlobalRoutines.FormatS(GU2(25), "NO") & Par)
            If pSaddlesItem(iBtmTop).GeomSadd(1).SupRing Then
                iSadd = 1
                PrintRing(GU2, iBtmTop)
            End If
            If pSaddlesItem(iBtmTop).GeomSadd(2).SupRing Then .Printa(GlobalRoutines.FormatS(GU2(26), "YES") & Par) Else .Printa(GlobalRoutines.FormatS(GU2(26), "NO") & Par)
            If pSaddlesItem(iBtmTop).GeomSadd(2).SupRing Then
                iSadd = 2
                PrintRing(GU2, iBtmTop)
            End If
            .Printa(GlobalRoutines.FormatS(GU2(21), pSaddlesItem(iBtmTop).GeomSadd(1).SaddHeight) & Par)
7330:       .Printa(GlobalRoutines.FormatS(GU2(22), pSaddlesItem(iBtmTop).GeomSadd(2).SaddHeight) & Par)
7340:       If pSaddlesItem(iBtmTop).TipoChius(1) >= 1 Then .Printa(GlobalRoutines.FormatS(GU2(23), pSaddlesItem(iBtmTop).SpessHead(1)) & Par)
7350:       If pSaddlesItem(iBtmTop).TipoChius(2) >= 1 Then .Printa(GlobalRoutines.FormatS(GU2(24), pSaddlesItem(iBtmTop).SpessHead(2)) & Par)
            Call Monitor.Motore.Testata()
            Call SubTesta(1)
            .Printa("---------------------------------------------------------------" & Par)
            .Printa("Analysis according to " & frmSaddles.DefInstance.Codice & Par)
7420:       .Printa("CALCULATIONS RESULTS    " & Par)
7430:       .Printa("---------------------------------------------------------------" & Par)
            FileOpen(ifl, RTrim(Monitor.Motore.Inizio.Archdir) & "\WR\SADD02.SDD", OpenMode.Input, , OpenShare.Shared)
            For i = 1 To 32 : GU1(i) = LineInput(ifl) : Next
            For i = 1 To 34 : GU2(i) = LineInput(ifl) : Next
            FileClose(ifl)
7431:       If pSaddlesItem(iBtmTop).Simple = "N" Then GoTo 7440
7432:       RIS(1) = GU1(1)
7433:       GoTo 7450
7440:       RIS(1) = GU2(1)
7450:       For i = 2 To 17 : RIS(i) = GU1(i) : Next
7600:       If pSaddlesItem(iBtmTop).Simple = "N" Then GoTo 7619
7601:       For i = 18 To 31 : RIS(i) = GU1(i) : Next
7618:       GoTo 7760
7619:       For i = 18 To 32 : RIS(i) = GU2(i) : Next
7760:       .Printa(GU2(33) & Par) ' "Geometrical Parameters  "+Par
7770:       .Printa(GlobalRoutines.FormatS(RIS(1), pSaddlesItem(iBtmTop).LTT) & Par)
7780:       .Printa(RIS(2) & Par)
7790:       .Printa(GlobalRoutines.FormatS(RIS(3), pSaddlesItem(iBtmTop).OutDia(0)) & Par)
7800:       .Printa(GlobalRoutines.FormatS(RIS(4), pSaddlesItem(iBtmTop).OutDia(1)) & Par)
7810:       .Printa(GlobalRoutines.FormatS(RIS(5), pSaddlesItem(iBtmTop).OutDia(2)) & Par)
7820:       .Printa(RIS(6) & Par)
7830:       .Printa(GlobalRoutines.FormatS(RIS(7), pSaddlesItem(iBtmTop).MeanR(0)) & Par)
7840:       .Printa(GlobalRoutines.FormatS(RIS(8), pSaddlesItem(iBtmTop).MeanR(1)) & Par)
7850:       .Printa(GlobalRoutines.FormatS(RIS(9), pSaddlesItem(iBtmTop).MeanR(2)) & Par)
7860:       If pSaddlesItem(iBtmTop).TipoChius(1) > 0 Or pSaddlesItem(iBtmTop).TipoChius(2) > 0 Then .Printa(RIS(10) & Par)
7870:       If pSaddlesItem(iBtmTop).TipoChius(1) > 0 Then .Printa(GlobalRoutines.FormatS(RIS(11), pSaddlesItem(iBtmTop).RHead(1)) & Par)
7880:       If pSaddlesItem(iBtmTop).TipoChius(2) > 0 Then .Printa(GlobalRoutines.FormatS(RIS(12), pSaddlesItem(iBtmTop).RHead(2)) & Par)
7890:       .Printa(RIS(13) & Par)
7900:       .Printa(GlobalRoutines.FormatS(RIS(14), pSaddlesItem(iBtmTop).w(0)) & Par)
7910:       .Printa(GlobalRoutines.FormatS(RIS(15), pSaddlesItem(iBtmTop).w(1)) & Par)
7920:       .Printa(GlobalRoutines.FormatS(RIS(16), pSaddlesItem(iBtmTop).w(2)) & Par)
7930:       .Printa(Par)
7940:       .Printa(GU2(34) & Par) '"Loads , Forces and Moments       "+Par
7950:       .Printa(GlobalRoutines.FormatS(RIS(17), pAreaLav(iCond, iBtmTop).Q) & Par)
7951:       If pSaddlesItem(iBtmTop).Simple = "N" Then GoTo 7969
7952:       .Printa(GlobalRoutines.FormatS(RIS(18), pSaddlesItem(iBtmTop).LT) & Par)
7953:       .Printa(RIS(19) & Par)
7954:       .Printa(GlobalRoutines.FormatS(RIS(20), pAreaLav(iCond, iBtmTop).React(1)) & Par)
7955:       .Printa(GlobalRoutines.FormatS(RIS(21), pAreaLav(iCond, iBtmTop).React(2)) & Par)
7956:       .Printa(RIS(22) & Par)
7957:       .Printa(RIS(23) & Par)
7958:       .Printa(GlobalRoutines.FormatS(RIS(24), pAreaLav(iCond, iBtmTop).Momen(1)) & Par)
7959:       .Printa(RIS(25) & Par)
7960:       .Printa(RIS(26) & Par)
7961:       .Printa(GlobalRoutines.FormatS(RIS(27), pAreaLav(iCond, iBtmTop).Momen(2)) & Par)
7962:       .Printa(RIS(28) & Par)
7963:       If pSaddlesItem(iBtmTop).Lungh(1) < pSaddlesItem(iBtmTop).MeanR(1) / 2 Or pSaddlesItem(iBtmTop).Lungh(1) = pSaddlesItem(iBtmTop).MeanR(1) / 2 Then GoTo 7968
7964:       .Printa(RIS(29) & Par)
7965:       .Printa(GlobalRoutines.FormatS(RIS(30), pAreaLav(iCond, iBtmTop).Taglio(1)) & Par)
7967:       .Printa(GlobalRoutines.FormatS(RIS(31), pAreaLav(iCond, iBtmTop).Taglio(2)) & Par)
7968:       GoTo 8110
7969:       .Printa(RIS(18) & Par)
7970:       .Printa(GlobalRoutines.FormatS(RIS(19), pAreaLav(iCond, iBtmTop).Momen(1)) & Par)
7980:       .Printa(GlobalRoutines.FormatS(RIS(20), pAreaLav(iCond, iBtmTop).Momen(2)) & Par)
7990:       .Printa(RIS(21) & Par)
8000:       .Printa(RIS(22) & Par)
8010:       .Printa(GlobalRoutines.FormatS(RIS(23), pAreaLav(iCond, iBtmTop).React(1)) & Par)
8020:       .Printa(RIS(24) & Par)
8030:       .Printa(RIS(25) & Par)
8040:       .Printa(GlobalRoutines.FormatS(RIS(26), pAreaLav(iCond, iBtmTop).React(2)) & Par)
8050:       .Printa(RIS(27) & Par)
8060:       .Printa(RIS(28) & Par)
8070:       .Printa(GlobalRoutines.FormatS(RIS(29), pAreaLav(iCond, iBtmTop).Taglio(1)) & Par)
8080:       '          .Printa RIS$(30)+Par
8090:       .Printa(GlobalRoutines.FormatS(RIS(31), pAreaLav(iCond, iBtmTop).Taglio(2)) & Par)
8100:       '          .Printa RIS$(32)+Par
8110:       '-------------------------------------------------------------------------
8120:       .Printa(Par)
            FileOpen(ifl, RTrim(Monitor.Motore.Inizio.Archdir) & "\WR\SADD03.SDD", OpenMode.Input, , OpenShare.Shared)
            For i = 1 To 18 : RIS(i) = LineInput(ifl) : Next
            ChangTab1 = LineInput(ifl)
            ChangTab2 = LineInput(ifl)
            ChangTab3 = LineInput(ifl)
            FileClose(ifl)
            If Problem.Codice = 0 Then
8310:           .Printa(RIS(1) & Par)
8320:           .Printa(GlobalRoutines.FormatS(RIS(2), pAreaLav(iCond, iBtmTop).PYSS(0)) & Par)
8330:           .Printa(GlobalRoutines.FormatS(RIS(3), pAreaLav(iCond, iBtmTop).PE(0)) & Par)
8340:           .Printa(GlobalRoutines.FormatS(RIS(4), pAreaLav(iCond, iBtmTop).KFAT(0)) & Par)
8350:           .Printa(GlobalRoutines.FormatS(RIS(5), pAreaLav(iCond, iBtmTop).DEL(0)) & Par)
8360:           .Printa(GlobalRoutines.FormatS(RIS(6), pAreaLav(iCond, iBtmTop).FALC(0)) & Par)
8370:           .Printa(GlobalRoutines.FormatS(RIS(7), pAreaLav(iCond, iBtmTop).PYSS(1)) & Par)
8380:           .Printa(GlobalRoutines.FormatS(RIS(8), pAreaLav(iCond, iBtmTop).PE(1)) & Par)
8390:           .Printa(GlobalRoutines.FormatS(RIS(9), pAreaLav(iCond, iBtmTop).KFAT(1)) & Par)
8400:           .Printa(GlobalRoutines.FormatS(RIS(10), pAreaLav(iCond, iBtmTop).DEL(1)) & Par)
8410:           .Printa(GlobalRoutines.FormatS(RIS(11), pAreaLav(iCond, iBtmTop).FALC(1)) & Par)
8420:           .Printa(GlobalRoutines.FormatS(RIS(12), pAreaLav(iCond, iBtmTop).PYSS(2)) & Par)
8430:           .Printa(GlobalRoutines.FormatS(RIS(13), pAreaLav(iCond, iBtmTop).PE(2)) & Par)
8440:           .Printa(GlobalRoutines.FormatS(RIS(14), pAreaLav(iCond, iBtmTop).KFAT(2)) & Par)
8450:           .Printa(GlobalRoutines.FormatS(RIS(15), pAreaLav(iCond, iBtmTop).DEL(2)) & Par)
8460:           .Printa(GlobalRoutines.FormatS(RIS(16), pAreaLav(iCond, iBtmTop).FALC(2)) & Par)
8470:           If pSaddlesItem(iBtmTop).TipoMat = 0 Then .Printa(GlobalRoutines.FormatS(RIS(17), pAreaLav(iCond, iBtmTop).SFAT) & Par)
8480:           If pSaddlesItem(iBtmTop).TipoMat = 1 Then .Printa(GlobalRoutines.FormatS(RIS(18), pAreaLav(iCond, iBtmTop).SFAT) & Par)
8490:           '-------------------------------------------------------------------------
            End If
            Call Monitor.Motore.Testata()
            Call SubTesta(1)
            .Printa("---------------------------------------------------------------" & Par)
            .Printa("Analysis according to " & frmSaddles.DefInstance.Codice & Par)
8560:       .Printa("CALCULATIONS RESULTS" & Par)
8570:       .Printa("---------------------------------------------------------------" & Par)
8571:       If pSaddlesItem(iBtmTop).Simple = "N" Then
                If Problem.Codice = 0 Then
                    FileOpen(ifl, RTrim(Monitor.Motore.Inizio.Archdir) & "\WR\SADD04.SDD", OpenMode.Input, , OpenShare.Shared)
                    For i = 28 To 46 : RIS(i) = LineInput(ifl) : Next
                Else
                    FileOpen(ifl, RTrim(Monitor.Motore.Inizio.Archdir) & "\WR\SADD34.SDD", OpenMode.Input, , OpenShare.Shared)
                    For i = 28 To 49 : RIS(i) = LineInput(ifl) : Next
                End If
            Else
                If Problem.Codice = 0 Then
                    FileOpen(ifl, RTrim(Monitor.Motore.Inizio.Archdir) & "\WR\SADD05.SDD", OpenMode.Input, , OpenShare.Shared)
                    For i = 28 To 40 : RIS(i) = LineInput(ifl) : Next
                Else
                    FileOpen(ifl, RTrim(Monitor.Motore.Inizio.Archdir) & "\WR\SADD35.SDD", OpenMode.Input, , OpenShare.Shared)
                    For i = 28 To 41 : RIS(i) = LineInput(ifl) : Next
                End If
            End If
            FileClose(ifl)
8750:       .Printa(Par)
8760:       .Printa(RIS(28) & Par) '"Stresses in the span between the saddles"+Par
            If pSaddlesItem(iBtmTop).Simple = "Y" Then
8762:           .Printa(RIS(29) & Par)
8763:           .Printa(RIS(30) & Par)
8764:           .Printa(GlobalRoutines.FormatS(RIS(31), pAreaLav(iCond, iBtmTop).TensMiddle.M3PS) & Par)
8765:           .Printa(RIS(32) & Par)
8766:           .Printa(RIS(33) & Par)
                .Printa(ChangTab1)
                .Printa(GlobalRoutines.FormatS(RIS(34), pAreaLav(iCond, iBtmTop).TensMiddle.F1PS(0)) & GlobalRoutines.FormatS(Right(RIS(34), 35), pAreaLav(iCond, iBtmTop).TensMiddle.F1PS(1)) & Par)
                .Printa(GlobalRoutines.FormatS(RIS(35), pAreaLav(iCond, iBtmTop).TensMiddle.F2PS(0)) & GlobalRoutines.FormatS(Right(RIS(35), 35), pAreaLav(iCond, iBtmTop).TensMiddle.F2PS(1)) & Par)
                .Printa(ChangTab2)
            Else
                .Printa(RIS(30) & Par)
                .Printa(GlobalRoutines.FormatS(RIS(31), pAreaLav(iCond, iBtmTop).TensMiddle.M3PS) & Par)
                .Printa(GlobalRoutines.FormatS(RIS(32), XPS) & Par)
                .Printa(RIS(33) & Par)
                If Problem.Codice = 0 Then
                    .Printa(ChangTab1)
                    .Printa(GlobalRoutines.FormatS(RIS(34), pAreaLav(iCond, iBtmTop).TensMiddle.F1PS(0)) & GlobalRoutines.FormatS(Right(RIS(34), 35), pAreaLav(iCond, iBtmTop).TensMiddle.F1PS(1)) & Par)
                    .Printa(GlobalRoutines.FormatS(RIS(35), pAreaLav(iCond, iBtmTop).TensMiddle.F2PS(0)) & GlobalRoutines.FormatS(Right(RIS(35), 35), pAreaLav(iCond, iBtmTop).TensMiddle.F2PS(1)) & Par)
                    .Printa(ChangTab2)
                Else
                    .Printa(GlobalRoutines.FormatS(RIS(34), pAreaLav(iCond, iBtmTop).TensMiddle.F1PS(0)) & Par)
                    .Printa(GlobalRoutines.FormatS(RIS(35), pAreaLav(iCond, iBtmTop).TensMiddle.F2PS(0)) & Par)
                    .Printa(GlobalRoutines.FormatS(RIS(36), pAreaLav(iCond, iBtmTop).TensMiddle.F1PS(1)) & Par)
                    .Printa(GlobalRoutines.FormatS(RIS(37), pAreaLav(iCond, iBtmTop).TensMiddle.F2PS(1)) & Par)
                End If
                .Printa(RIS(41 + Problem.Codice) & Par)
                .Printa(GlobalRoutines.FormatS(RIS(42 + Problem.Codice), pAreaLav(iCond, iBtmTop).TensMiddle.M3NG) & Par)
                .Printa(GlobalRoutines.FormatS(RIS(43 + Problem.Codice), XNG) & Par)
                .Printa(RIS(44 + Problem.Codice) & Par)
                If Problem.Codice = 0 Then
                    .Printa(ChangTab1)
                    .Printa(GlobalRoutines.FormatS(RIS(45), pAreaLav(iCond, iBtmTop).TensMiddle.F1NG(0)) & GlobalRoutines.FormatS(Right(RIS(45), 35), pAreaLav(iCond, iBtmTop).TensMiddle.F1NG(1)) & Par)
                    .Printa(GlobalRoutines.FormatS(RIS(46), pAreaLav(iCond, iBtmTop).TensMiddle.F2NG(0)) & GlobalRoutines.FormatS(Right(RIS(46), 35), pAreaLav(iCond, iBtmTop).TensMiddle.F2NG(1)) & Par)
                    .Printa(ChangTab2)
                Else
                    .Printa(GlobalRoutines.FormatS(RIS(46), pAreaLav(iCond, iBtmTop).TensMiddle.F1NG(0)) & Par)
                    .Printa(GlobalRoutines.FormatS(RIS(47), pAreaLav(iCond, iBtmTop).TensMiddle.F2NG(0)) & Par)
                    .Printa(GlobalRoutines.FormatS(RIS(48), pAreaLav(iCond, iBtmTop).TensMiddle.F1NG(1)) & Par)
                    .Printa(GlobalRoutines.FormatS(RIS(49), pAreaLav(iCond, iBtmTop).TensMiddle.F2NG(1)) & Par)
                End If
                .Printa(GlobalRoutines.FormatS(RIS(36 + 2 * Problem.Codice), pSaddlesLoad(iCond, iBtmTop).AmmShell(0 + 2 * Problem.Codice)) & Par)
                If Problem.Codice = 0 Then .Printa(GlobalRoutines.FormatS(RIS(37), pAreaLav(iCond, iBtmTop).FALC(0)) & Par)
            End If
            Call FactMiddle(SIGMAT, SIGMAC, Factor, iBtmTop)
8990:       If SIGMAT > pSaddlesLoad(iCond, iBtmTop).AmmShell(0 + 2 * Problem.Codice) Or (SIGMAC > pAreaLav(iCond, iBtmTop).FALC(0) And Problem.Codice = 0) Then .Printa(RIS(38 + Problem.Codice) & Par)
9000:       If SIGMAT > pSaddlesLoad(iCond, iBtmTop).AmmShell(0 + 2 * Problem.Codice) Then .Printa(RIS(39 + Problem.Codice) & Par)
9010:       If SIGMAC > pAreaLav(iCond, iBtmTop).FALC(0) And Problem.Codice = 0 Then .Printa(RIS(40) & Par)
            '-------------------------------------------------------------------------
            If Problem.Codice = 0 Or iCond = 1 Or iCond = 3 Then
                If Problem.Codice = 0 Then
                    FileOpen(ifl, RTrim(Monitor.Motore.Inizio.Archdir) & "\WR\SADD06.SDD", OpenMode.Input, , OpenShare.Shared)
                Else
                    FileOpen(ifl, RTrim(Monitor.Motore.Inizio.Archdir) & "\WR\SADD36.SDD", OpenMode.Input, , OpenShare.Shared)
                End If
                For i = 1 To 24 : RIS(i) = LineInput(ifl) : Next
                FileClose(ifl)
                If Not pSaddlesItem(iBtmTop).GeomSadd(1).SupRing Then
9220:               .Printa(Par)
9230:               .Printa(RIS(20) & Par) '"Longitudinal stresses at the saddles"+Par
9240:               .Printa(RIS(21) & Par & Par) ' "Left saddle                         "+Par
                    iSadd = 1 : Mode = 1
                    StampSadd(RIS, ChangTab1, ChangTab2, ChangTab3, Mode, iBtmTop)
                    If Problem.Codice = 1 And pAreaLav(iCond, iBtmTop).TensSaddle.F3(iSadd, 1) > 0 Then
                        .Printa(RIS(6) & Par)
                        Mode = 2
                        StampSadd(RIS, ChangTab1, ChangTab2, ChangTab3, Mode, iBtmTop)
                    End If
                    Call FactSaddle(SIGMAC, SIGMAT, Factor, iBtmTop)
                    StampSaddFinal(RIS, SIGMAT, SIGMAC, iBtmTop)
                End If
                If Not pSaddlesItem(iBtmTop).GeomSadd(2).SupRing Then
9450:               .Printa(RIS(22) & Par & Par) ' "Right saddle                        "+Par
                    iSadd = 2 : Mode = 1
                    StampSadd(RIS, ChangTab1, ChangTab2, ChangTab3, Mode, iBtmTop)
                    If Problem.Codice = 1 And pAreaLav(iCond, iBtmTop).TensSaddle.F3(iSadd, 1) > 0 Then
                        .Printa(RIS(6) & Par)
                        Mode = 2
                        StampSadd(RIS, ChangTab1, ChangTab2, ChangTab3, Mode, iBtmTop)
                    End If
                    Call FactSaddle(SIGMAC, SIGMAT, Factor, iBtmTop)
                    StampSaddFinal(RIS, SIGMAT, SIGMAC, iBtmTop)
                End If
9660:           '--------------------------------------------------------------------------
                If Problem.Codice = 0 Then
                    FileOpen(ifl, RTrim(Monitor.Motore.Inizio.Archdir) & "\WR\SADD07.SDD", OpenMode.Input, , OpenShare.Shared)
                Else
                    FileOpen(ifl, RTrim(Monitor.Motore.Inizio.Archdir) & "\WR\SADD37.SDD", OpenMode.Input, , OpenShare.Shared)
                End If
                For i = 1 To 31 : RIS(i) = LineInput(ifl) : Next
                FileClose(ifl)
9950:           .Printa(Par)
9960:           .Printa(RIS(29) & Par) '"Tangential shearing stresses        "+Par
9980:           .Printa(RIS(30) & Par & Par) '"Left saddle                         "+Par
                iSadd = 1
                StampShear(RIS, iBtmTop)
10250:          .Printa(RIS(31) & Par & Par) '"Right saddle                        "+Par
                iSadd = 2
                StampShear(RIS, iBtmTop)
10520:          '--------------------------------------------------------------------------
                Call Monitor.Motore.Testata()
                Call SubTesta(1)
                .Printa("---------------------------------------------------------------" & Par)
                .Printa("Analysis according to " & frmSaddles.DefInstance.Codice & Par)
10590:          .Printa("CALCULATIONS RESULTS" & Par)
10600:          .Printa("---------------------------------------------------------------" & Par)
            End If
            If Problem.Codice = 0 Then
                FileOpen(ifl, RTrim(Monitor.Motore.Inizio.Archdir) & "\WR\SADD08.SDD", OpenMode.Input, , OpenShare.Shared)
                For i = 1 To 32 : RIS(i) = LineInput(ifl) : Next
            Else
                FileOpen(ifl, RTrim(Monitor.Motore.Inizio.Archdir) & "\WR\SADD38.SDD", OpenMode.Input, , OpenShare.Shared)
                For i = 1 To 38 : RIS(i) = LineInput(ifl) : Next
            End If
            FileClose(ifl)
            For j = 1 To 2
                iSadd = j
10890:          FAL61 = CSng(1.25 * pSaddlesLoad(iCond, iBtmTop).AmmShell(j))
10900:          .Printa(Par)
                If j = 1 Then
                    i = 29 : If pSaddlesItem(iBtmTop).GeomSadd(iSadd).SupRing Then i = 33
10910:              .Printa(RIS(i) & Par) '"Circumferential stresses            "+Par
10920:              .Printa(Par)
10930:              .Printa(RIS(30) & Par & Par) '"Left saddle                         "+Par
                End If
                If Problem.Codice = 0 Then
                    .Printa(GlobalRoutines.FormatS(RIS(37), pAreaLav(iCond, iBtmTop).CircSaddle.b2(j)) & Par)
                    .Printa(GlobalRoutines.FormatS(RIS(2), pAreaLav(iCond, iBtmTop).CircSaddle.ZETS(j)) & Par)
                    If pSaddlesItem(iBtmTop).GeomSadd(j).PlateWidth < pAreaLav(iCond, iBtmTop).CircSaddle.b2(j) Or pSaddlesItem(iBtmTop).GeomSadd(j).PlateAngle < pAreaLav(iCond, iBtmTop).CircSaddle.ZETS(j) Then
Stamp1:
11190:                  .Printa(RIS(4) & Par)
11200:                  .Printa(GlobalRoutines.FormatS(RIS(5), pAreaLav(iCond, iBtmTop).CircSaddle.TT(j)) & Par)
11210:                  .Printa(GlobalRoutines.FormatS(RIS(9), pAreaLav(iCond, iBtmTop).CircSaddle.K5(j)) & Par)
11220:                  .Printa(GlobalRoutines.FormatS(RIS(10), pAreaLav(iCond, iBtmTop).CircSaddle.K6(j)) & Par)
11230:                  .Printa(GlobalRoutines.FormatS(RIS(13), pAreaLav(iCond, iBtmTop).CircSaddle.F5(j)) & Par)
11240:                  If pSaddlesItem(iBtmTop).LT / pSaddlesItem(iBtmTop).MeanR(j) < 8 Then GoTo 11280
11250:                  .Printa(RIS(14) & Par)
11260:                  .Printa(GlobalRoutines.FormatS(RIS(15), pAreaLav(iCond, iBtmTop).CircSaddle.F6(j)) & Par)
11270:                  GoTo 11300
11280:                  .Printa(RIS(16) & Par)
11290:                  .Printa(GlobalRoutines.FormatS(RIS(17), pAreaLav(iCond, iBtmTop).CircSaddle.F6(j)) & Par)
11300:                  .Printa(GlobalRoutines.FormatS(RIS(12), pSaddlesLoad(iCond, iBtmTop).AmmShell(j)) & Par)
11310:                  .Printa(GlobalRoutines.FormatS(RIS(28), FAL61) & Par)
11320:                  If System.Math.Abs(pAreaLav(iCond, iBtmTop).CircSaddle.F5(j)) > pSaddlesLoad(iCond, iBtmTop).AmmShell(j) Then
                            .Printa(RIS(26) & Par)
                            .Printa(RIS(27) & Par)
                        End If
                        If System.Math.Abs(pAreaLav(iCond, iBtmTop).CircSaddle.F6(j)) > 1.25 * pSaddlesLoad(iCond, iBtmTop).AmmShell(j) Then
                            .Printa(RIS(26) & Par)
                            .Printa(RIS(27) & Par)
                        End If
                    Else
                        .Printa(RIS(3))
10970:                  .Printa(RIS(32) & Par)
10980:                  .Printa(RIS(6) & Par)
10990:                  .Printa(GlobalRoutines.FormatS(RIS(7), pAreaLav(iCond, iBtmTop).CircSaddle.TT(j)) & Par)
11000:                  .Printa(GlobalRoutines.FormatS(RIS(8), pSaddlesItem(iBtmTop).Spess(j)) & Par)
11010:                  .Printa(GlobalRoutines.FormatS(RIS(9), pAreaLav(iCond, iBtmTop).CircSaddle.K5(j)) & Par)
11020:                  .Printa(GlobalRoutines.FormatS(RIS(10), pAreaLav(iCond, iBtmTop).CircSaddle.K6(j)) & Par)
11030:                  .Printa(GlobalRoutines.FormatS(RIS(11), pAreaLav(iCond, iBtmTop).CircSaddle.K6S(j)) & Par) '??????????
11040:                  .Printa(GlobalRoutines.FormatS(RIS(13), pAreaLav(iCond, iBtmTop).CircSaddle.F5(j)) & Par)
11050:                  If pSaddlesItem(iBtmTop).LT / pSaddlesItem(iBtmTop).MeanR(j) < 8 Then GoTo 11110
11060:                  .Printa(RIS(18) & Par)
11070:                  .Printa(GlobalRoutines.FormatS(RIS(19), pAreaLav(iCond, iBtmTop).CircSaddle.F6(j)) & Par)
11080:                  .Printa(RIS(22) & Par)
11090:                  .Printa(GlobalRoutines.FormatS(RIS(23), pAreaLav(iCond, iBtmTop).CircSaddle.F6S(j)) & Par)
11100:                  GoTo 11150
11110:                  .Printa(RIS(20) & Par)
11120:                  .Printa(GlobalRoutines.FormatS(RIS(21), pAreaLav(iCond, iBtmTop).CircSaddle.F6(j)) & Par)
11130:                  .Printa(RIS(24) & Par)
11140:                  .Printa(GlobalRoutines.FormatS(RIS(25), pAreaLav(iCond, iBtmTop).CircSaddle.F6S(j)) & Par)
11150:                  .Printa(GlobalRoutines.FormatS(RIS(12), pSaddlesLoad(iCond, iBtmTop).AmmShell(j)) & Par)
11160:                  .Printa(GlobalRoutines.FormatS(RIS(28), FAL61) & Par)
                        If System.Math.Abs(pAreaLav(iCond, iBtmTop).CircSaddle.F6S(j)) > 1.25 * pSaddlesLoad(iCond, iBtmTop).AmmShell(j) Then
11340:                      .Printa(RIS(26) & Par)
11350:                      .Printa(RIS(27) & Par)
                        End If
                    End If
                Else
                    If pSaddlesItem(iBtmTop).GeomSadd(iSadd).SupRing Then
                        .Printa(GlobalRoutines.FormatS(RIS(34), pAreaLav(iCond, iBtmTop).CircSaddle.K6(j)) & Par)
                        .Printa(GlobalRoutines.FormatS(RIS(35), pAreaLav(iCond, iBtmTop).CircSaddle.K6S(j)) & Par)
                        .Printa(GlobalRoutines.FormatS(RIS(36), pAreaLav(iCond, iBtmTop).CircSaddle.F6(j)) & Par)
                        .Printa(GlobalRoutines.FormatS(RIS(37), pAreaLav(iCond, iBtmTop).CircSaddle.ZETS(j)) & Par)
                        .Printa(GlobalRoutines.FormatS(RIS(38), pAreaLav(iCond, iBtmTop).CircSaddle.F6S(j)) & Par)
                        FactSupRing(Factor, iBtmTop)
                    Else
                        .Printa(GlobalRoutines.FormatS(RIS(1), pAreaLav(iCond, iBtmTop).CircSaddle.K5(j)) & Par)
                        .Printa(GlobalRoutines.FormatS(RIS(2), pAreaLav(iCond, iBtmTop).CircSaddle.F5(j)) & Par)
                        .Printa(GlobalRoutines.FormatS(RIS(3), pSaddlesLoad(iCond, iBtmTop).AmmShell(2)) & Par)
                        FactCircum(Factor, iBtmTop)
                    End If
                    If Factor > 1 Then
                        .Printa(RIS(26) & Par)
                        .Printa(RIS(27) & Par)
                    End If
                End If
11360:          '---------------------------------------------------------------------
                If j = 1 Then
11370:              .Printa(Par)
11380:              .Printa(RIS(31) & Par & Par) '"Right saddle                        "+Par
                End If
                If Problem.Codice = 0 Then
                    FileOpen(ifl, RTrim(Monitor.Motore.Inizio.Archdir) & "\WR\SADD09.SDD", OpenMode.Input, , OpenShare.Shared)
                    For i = 1 To 32 : RIS(i) = LineInput(ifl) : Next
                    FileClose(ifl)
                End If
            Next
            If Problem.Codice = 1 Then
                If (pSaddlesItem(iBtmTop).TipoChius(1) >= 1 And Not pSaddlesItem(iBtmTop).GeomSadd(1).SupRing) Or (pSaddlesItem(iBtmTop).TipoChius(2) >= 1 And Not pSaddlesItem(iBtmTop).GeomSadd(2).SupRing) Then
                    .Printa(RIS(9) & Par & Par) '"Stresses in the heads"+Par
                End If
                For iSadd = 1 To 2
                    If pSaddlesItem(iBtmTop).TipoChius(iSadd) >= 1 And Not pSaddlesItem(iBtmTop).GeomSadd(iSadd).SupRing Then
                        .Printa(RIS(29 + iSadd) & Par & Par) '"Left saddle                         "+Par
                        .Printa(GlobalRoutines.FormatS(RIS(10), pAreaLav(iCond, iBtmTop).CircSaddle.K6S(iSadd)) & Par)
                        .Printa(GlobalRoutines.FormatS(RIS(11), pAreaLav(iCond, iBtmTop).CircSaddle.ZETS(iSadd)) & Par)
                        .Printa(GlobalRoutines.FormatS(RIS(12), pAreaLav(iCond, iBtmTop).ShearSaddle.K3(iSadd)) & Par)
                        .Printa(GlobalRoutines.FormatS(RIS(13), pAreaLav(iCond, iBtmTop).CircSaddle.K6(iSadd)) & Par)
                        .Printa(GlobalRoutines.FormatS(RIS(14), pAreaLav(iCond, iBtmTop).CircSaddle.F6(iSadd)) & Par)
                        .Printa(GlobalRoutines.FormatS(RIS(15), pAreaLav(iCond, iBtmTop).CircSaddle.F6S(iSadd)) & Par)
                        .Printa(GlobalRoutines.FormatS(RIS(16), 0.8 * pSaddlesLoad(iCond, iBtmTop).AmmHead(iSadd)) & Par)
                        If iCond > 1 Then
                            .Printa(GlobalRoutines.FormatS(RIS(18), 1.33 * pSaddlesLoad(iCond, iBtmTop).AmmHead(iSadd)) & Par)
                        Else
                            .Printa(GlobalRoutines.FormatS(RIS(17), pSaddlesLoad(iCond, iBtmTop).AmmHead(iSadd)) & Par)
                        End If
                        FactFondo(Factor, iBtmTop)
                        If Factor > 1 Then
                            .Printa(RIS(26) & Par)
                            .Printa(RIS(25) & Par)
                        End If
                    End If
                Next
            End If
            '------------------------------------------------------------------------
            Call Monitor.Motore.Testata()
            Call SubTesta(1)
            FileOpen(ifl, RTrim(Monitor.Motore.Inizio.Archdir) & "\WR\SADD10.SDD", OpenMode.Input, , OpenShare.Shared)
            For i = 1 To 11 : RIS(i) = LineInput(ifl) : Next
            FileClose(ifl)
12150:      .Printa("CALCULATIONS RESULTS" & Par)
12160:      .Printa("---------------------------------------------------------------")
12250:      .Printa(Par)
            For j = 1 To 2
12280:          If j = 1 Then
12260:              .Printa(RIS(9) & Par) ' "Check of saddle minimum section     "+Par
12270:              .Printa(Par)
                    .Printa(RIS(10) & Par & Par) '"Left saddle                         "+Par
                End If
12290:          .Printa(GlobalRoutines.FormatS(RIS(1), pAreaLav(iCond, iBtmTop).SadDesign.K9(j)) & Par)
12300:          .Printa(GlobalRoutines.FormatS(RIS(2), pAreaLav(iCond, iBtmTop).SadDesign.HSD(j)) & Par)
12320:          If pSaddlesItem(iBtmTop).GeomSadd(j).SaddHeight > pSaddlesItem(iBtmTop).MeanR(j) / 3 Then .Printa(RIS(3) & Par)
12330:          .Printa(GlobalRoutines.FormatS(RIS(4), pAreaLav(iCond, iBtmTop).SadDesign.h(j)) & Par)
12340:          .Printa(GlobalRoutines.FormatS(RIS(5), pAreaLav(iCond, iBtmTop).SadDesign.FSD(j)) & Par)
12350:          FALLS1 = CSng(2 / 3 * pSaddlesLoad(iCond, iBtmTop).AmmSadd(j))
                .Printa(GlobalRoutines.FormatS(RIS(6), FALLS1) & Par)
12360:          If System.Math.Abs(pAreaLav(iCond, iBtmTop).SadDesign.FSD(j)) > FALLS1 Then GoTo 12370 Else GoTo 12390
12370:          .Printa(RIS(7) & Par)
12380:          .Printa(RIS(8) & Par)
12390:          '------------------------------------------------------------------------
                If j = 1 Then .Printa(RIS(11) & Par & Par)
                FileOpen(ifl, RTrim(Monitor.Motore.Inizio.Archdir) & "\WR\SADD11.SDD", OpenMode.Input, , OpenShare.Shared)
                For i = 1 To 11 : RIS(i) = LineInput(ifl) : Next
                FileClose(ifl)
            Next
            If Problem.Codice = 1 Then 'buckling
                FileOpen(ifl, RTrim(Monitor.Motore.Inizio.Archdir) & "\WR\SADD39.SDD", OpenMode.Input, , OpenShare.Shared)
                For i = 1 To 32 : RIS(i) = LineInput(ifl) : Next
                FileClose(ifl)
                .Printa(Par)
                .Printa(RIS(29) & Par) '"Stability
                .Printa(GlobalRoutines.FormatS(RIS(2), pAreaLav(iCond, iBtmTop).CircSaddle.b2(1)) & Par)
                .Printa(GlobalRoutines.FormatS(RIS(3), pAreaLav(iCond, iBtmTop).CircSaddle.b2(2)) & Par)
                .Printa(GlobalRoutines.FormatS(RIS(4), pAreaLav(iCond, iBtmTop).CircSaddle.TT(1)) & Par)
                FactBuckling(Factor, iBtmTop)
                If Factor > 1 Then
                    .Printa(RIS(26) & Par)
                    .Printa(RIS(27) & Par)
                End If
            End If
            If Problem.Codice = 0 Then
                FileOpen(ifl, RTrim(Monitor.Motore.Inizio.Archdir) & "\WR\SADD12.SDD", OpenMode.Input, , OpenShare.Shared)
                For i = 0 To 6 : RIS(i) = LineInput(ifl) : Next
            Else
                FileOpen(ifl, RTrim(Monitor.Motore.Inizio.Archdir) & "\WR\SADD42.SDD", OpenMode.Input, , OpenShare.Shared)
                For i = 0 To 9 : RIS(i) = LineInput(ifl) : Next
            End If
            FileClose(ifl)
            .Printa(Par)
            .Printa("SUMMARY OF THE RESULTS: USAGE FACTORS" & Par)
            .Printa("---------------------------------------------------------------")
            .Printa(RIS(0) & Par)
            .Printa(RIS(1) & Par)
            If FactUs(1, iCond) > 1 Then Brack1 = "{\b " : Brack2 = "}" Else Brack1 = "" : Brack2 = ""
            .Printa(RIS(2) & "\tab " & Brack1 & GlobalRoutines.FormatS("#0.0000", FactUs(1, iCond)) & Brack2 & Par)
            If Not pSaddlesItem(iBtmTop).GeomSadd(1).SupRing Or Not pSaddlesItem(iBtmTop).GeomSadd(2).SupRing Then
                If FactUs(2, iCond) > 1 Then Brack1 = "{\b " : Brack2 = "}" Else Brack1 = "" : Brack2 = ""
                If FactUs(3, iCond) > 1 Then Brack3 = "{\b " : Brack4 = "}" Else Brack3 = "" : Brack4 = ""
                .Printa(RIS(3) & Brack1 & GlobalRoutines.FormatS("#0.0000", FactUs(2, iCond)) & Brack2 & "\tab \tab " & Brack3 & GlobalRoutines.FormatS("#0.0000", FactUs(3, iCond)) & Brack4 & Par)
            End If
            If FactUs(4, iCond) > 1 Then Brack1 = "{\b " : Brack2 = "}" Else Brack1 = "" : Brack2 = ""
            If FactUs(5, iCond) > 1 Then Brack3 = "{\b " : Brack4 = "}" Else Brack3 = "" : Brack4 = ""
            .Printa(RIS(4) & Brack1 & GlobalRoutines.FormatS("#0.0000", FactUs(4, iCond)) & Brack2 & "\tab \tab " & Brack3 & GlobalRoutines.FormatS("#0.0000", FactUs(5, iCond)) & Brack4 & Par)
            If FactUs(6, iCond) > 1 Then Brack1 = "{\b " : Brack2 = "}" Else Brack1 = "" : Brack2 = ""
            If FactUs(7, iCond) > 1 Then Brack3 = "{\b " : Brack4 = "}" Else Brack3 = "" : Brack4 = ""
            .Printa(RIS(5) & Brack1 & GlobalRoutines.FormatS("#0.0000", FactUs(6, iCond)) & Brack2 & "\tab \tab " & Brack3 & GlobalRoutines.FormatS("#0.0000", FactUs(7, iCond)) & Brack4 & Par)
            If Problem.Codice = 0 Then
                If FactUs(8, iCond) > 1 Then Brack1 = "{\b " : Brack2 = "}" Else Brack1 = "" : Brack2 = ""
                If FactUs(9, iCond) > 1 Then Brack3 = "{\b " : Brack4 = "}" Else Brack3 = "" : Brack4 = ""
                .Printa(RIS(6) & Brack1 & GlobalRoutines.FormatS("#0.0000", FactUs(8, iCond)) & Brack2 & "\tab \tab " & Brack3 & GlobalRoutines.FormatS("#0.0000", FactUs(9, iCond)) & Brack4 & Par)
            Else
                If Not pSaddlesItem(iBtmTop).GeomSadd(1).SupRing Or Not pSaddlesItem(iBtmTop).GeomSadd(2).SupRing Then
                    If FactUs(10, iCond) > 1 Then Brack1 = "{\b " : Brack2 = "}" Else Brack1 = "" : Brack2 = ""
                    If FactUs(11, iCond) > 1 Then Brack3 = "{\b " : Brack4 = "}" Else Brack3 = "" : Brack4 = ""
                    .Printa(RIS(6) & Brack1 & GlobalRoutines.FormatS("#0.0000", FactUs(10, iCond)) & Brack2 & "\tab \tab " & Brack3 & GlobalRoutines.FormatS("#0.0000", FactUs(11, iCond)) & Brack4 & Par)
                End If
                If pSaddlesItem(iBtmTop).GeomSadd(1).SupRing Or pSaddlesItem(iBtmTop).GeomSadd(2).SupRing Then
                    If FactUs(13, iCond) > 1 Then Brack1 = "{\b " : Brack2 = "}" Else Brack1 = "" : Brack2 = ""
                    If FactUs(14, iCond) > 1 Then Brack3 = "{\b " : Brack4 = "}" Else Brack3 = "" : Brack4 = ""
                    .Printa(RIS(7) & Brack1 & GlobalRoutines.FormatS("#0.0000", FactUs(13, iCond)) & Brack2 & "\tab \tab " & Brack3 & GlobalRoutines.FormatS("#0.0000", FactUs(14, iCond)) & Brack4 & Par)
                End If
                If FactUs(8, iCond) > 1 Then Brack1 = "{\b " : Brack2 = "}" Else Brack1 = "" : Brack2 = ""
                If FactUs(9, iCond) > 1 Then Brack3 = "{\b " : Brack4 = "}" Else Brack3 = "" : Brack4 = ""
                .Printa(RIS(8) & Brack1 & GlobalRoutines.FormatS("#0.0000", FactUs(8, iCond)) & Brack2 & "\tab \tab " & Brack3 & GlobalRoutines.FormatS("#0.0000", FactUs(9, iCond)) & Brack4 & Par)
                If FactUs(12, iCond) > 1 Then Brack1 = "{\b " : Brack2 = "}" Else Brack1 = "" : Brack2 = ""
                .Printa(RIS(9) & Brack1 & GlobalRoutines.FormatS("#0.0000", FactUs(12, iCond)) & Brack2 & "\tab \tab " & Par)
            End If
            .Printa(Par & "{\b " & FinalCommentFinal & "}" & Par)
            Exit Sub
        End With
    End Sub
    Private Sub PrintRing(ByVal GU2() As String, ByVal iBtmTop As Short)
        With Monitor.Motore.Problem
            .Printa(GlobalRoutines.FormatS(GU2(27), pSaddlesItem(iBtmTop).GeomSadd(iSadd).Ax) & Par)
            .Printa(GlobalRoutines.FormatS(GU2(28), pSaddlesItem(iBtmTop).GeomSadd(iSadd).Ix) & Par)
            .Printa(GlobalRoutines.FormatS(GU2(29), pSaddlesItem(iBtmTop).GeomSadd(iSadd).rCrown) & Par)
            .Printa(GlobalRoutines.FormatS(GU2(30), pSaddlesItem(iBtmTop).GeomSadd(iSadd).rBottom) & Par)
        End With
    End Sub
    Private Sub StampSaddFinal(ByVal RIS() As String, ByVal SIGMAT As Single, _
                               ByVal SIGMAC As Single, ByVal iBtmTop As Short)
        With Monitor.Motore.Problem
            If Problem.Codice = 0 Then
                If SIGMAT > pSaddlesLoad(iCond, iBtmTop).AmmShell(iSadd) Or SIGMAC > pAreaLav(iCond, iBtmTop).FALC(iSadd) Then .Printa(RIS(13) & Par)
                If SIGMAT > pSaddlesLoad(iCond, iBtmTop).AmmShell(iSadd) Then .Printa(RIS(14) & Par)
                If SIGMAC > pAreaLav(iCond, iBtmTop).FALC(iSadd) Then .Printa(RIS(15) & Par)
            Else
                .Printa(GlobalRoutines.FormatS(RIS(5), 1.5 * pSaddlesLoad(iCond, iBtmTop).AmmShell(2)) & Par)
                If SIGMAT > 1.5 * pSaddlesLoad(iCond, iBtmTop).AmmShell(2) Then
                    .Printa(RIS(13) & Par)
                    .Printa(RIS(14) & Par)
                End If
            End If
        End With
    End Sub
    Private Sub StampShear(ByVal RIS() As String, ByVal iBtmTop As Short)
        Dim Factor As Single
        With Monitor.Motore.Problem
            If Problem.Codice = 1 Then
                .Printa(GlobalRoutines.FormatS(RIS(12), pAreaLav(iCond, iBtmTop).ShearSaddle.K3(iSadd)) & Par)
                .Printa(GlobalRoutines.FormatS(RIS(14), pAreaLav(iCond, iBtmTop).ShearSaddle.SQ(iSadd)) & Par)
                .Printa(GlobalRoutines.FormatS(RIS(15), 0.8 * pSaddlesLoad(iCond, iBtmTop).AmmShell(2)) & Par)
                Call FactShear(Factor, iBtmTop)
                If Factor > 1 Then
                    .Printa(RIS(17) & Par)
                    .Printa(RIS(18) & Par)
                End If
                Exit Sub
            End If
9990:       If pSaddlesItem(iBtmTop).Lungh(iSadd) > pSaddlesItem(iBtmTop).MeanR(iSadd) / 2 Then GoTo 10170
10000:      If pSaddlesItem(iBtmTop).Lungh(iSadd) > pSaddlesItem(iBtmTop).GeomSadd(iSadd).AxialWidth Then GoTo 10030
10010:      .Printa(GlobalRoutines.FormatS(RIS(1 + (iSadd - 1) * 9), pAreaLav(iCond, iBtmTop).ShearSaddle.K3(iSadd)) & Par)
10020:      GoTo 10040
10030:      .Printa(GlobalRoutines.FormatS(RIS(2 + (iSadd - 1) * 9), pAreaLav(iCond, iBtmTop).ShearSaddle.K3(iSadd)) & Par)
10040:      .Printa(GlobalRoutines.FormatS(RIS(3), pAreaLav(iCond, iBtmTop).ShearSaddle.K4(iSadd)) & Par)
10050:      .Printa(RIS(6) & Par)
10060:      .Printa(GlobalRoutines.FormatS(RIS(7 + (iSadd - 1) * 7), pAreaLav(iCond, iBtmTop).ShearSaddle.SQ(iSadd)) & Par)
10070:      .Printa(GlobalRoutines.FormatS(RIS(8 + (iSadd - 1) * 7), pAreaLav(iCond, iBtmTop).ShearSaddle.SQE(iSadd)) & Par)
10080:      .Printa(GlobalRoutines.FormatS(RIS(20), pAreaLav(iCond, iBtmTop).ShearSaddle.TANGS(iSadd)) & Par)
10090:      .Printa(RIS(21) & Par)
10100:      .Printa(GlobalRoutines.FormatS(RIS(22), pAreaLav(iCond, iBtmTop).ShearSaddle.TANGH(iSadd)) & Par)
10110:      .Printa(RIS(23) & Par)
10120:      If System.Math.Abs(pAreaLav(iCond, iBtmTop).ShearSaddle.SQ(iSadd)) > pAreaLav(iCond, iBtmTop).ShearSaddle.TANGS(iSadd) Or System.Math.Abs(pAreaLav(iCond, iBtmTop).ShearSaddle.SQE(iSadd)) > pAreaLav(iCond, iBtmTop).ShearSaddle.TANGH(iSadd) Then GoTo 10130 Else GoTo 10160
10130:      .Printa(RIS(17) & Par)
10140:      If System.Math.Abs(pAreaLav(iCond, iBtmTop).ShearSaddle.SQ(iSadd)) > pAreaLav(iCond, iBtmTop).ShearSaddle.TANGS(iSadd) Then .Printa(RIS(18) & Par)
10150:      If System.Math.Abs(pAreaLav(iCond, iBtmTop).ShearSaddle.SQE(iSadd)) > pAreaLav(iCond, iBtmTop).ShearSaddle.TANGH(iSadd) Then .Printa(RIS(19) & Par)
10160:      Exit Sub
10170:      .Printa(GlobalRoutines.FormatS(RIS(4 + (iSadd - 1) * 8), pAreaLav(iCond, iBtmTop).ShearSaddle.K3(iSadd)) & Par)
10180:      .Printa(GlobalRoutines.FormatS(RIS(5 + (iSadd - 1) * 8), pAreaLav(iCond, iBtmTop).Taglio(iSadd)) & Par)
10190:      .Printa(GlobalRoutines.FormatS(RIS(9 + (iSadd - 1) * 7), pAreaLav(iCond, iBtmTop).ShearSaddle.SQ(iSadd)) & Par)
10200:      .Printa(GlobalRoutines.FormatS(RIS(20), pAreaLav(iCond, iBtmTop).ShearSaddle.TANGS(iSadd)) & Par)
10210:      .Printa(RIS(21) & Par)
10220:      If System.Math.Abs(pAreaLav(iCond, iBtmTop).ShearSaddle.SQ(iSadd)) > pAreaLav(iCond, iBtmTop).ShearSaddle.TANGS(iSadd) Then
                GoTo 10230
            Else
                Exit Sub
            End If
10230:      .Printa(RIS(17) & Par)
10240:      .Printa(RIS(18) & Par)
        End With
    End Sub
    Private Sub StampSadd(ByVal RIS() As String, ByVal ChangTab1 As String, _
                          ByVal ChangTab2 As String, ByVal ChangTab3 As String, _
                          ByVal Mode As Integer, ByVal iBtmTop As Short)
        With Monitor.Motore.Problem
            If Problem.Codice = 0 Then
                .Printa(ChangTab3)
9250:           If pSaddlesItem(iBtmTop).Lungh(iSadd) > pSaddlesItem(iBtmTop).MeanR(iSadd) / 2 Then GoTo 9270
9260:           .Printa(GlobalRoutines.FormatS(RIS(1 + (iSadd - 1) * 7), pAreaLav(iCond, iBtmTop).TensSaddle.K1(iSadd, 0), pAreaLav(iCond, iBtmTop).TensSaddle.K1(iSadd, 1)) & Par) : GoTo 9280
9270:           .Printa(GlobalRoutines.FormatS(RIS(2 + (iSadd - 1) * 7), pAreaLav(iCond, iBtmTop).TensSaddle.K1(iSadd, 0), pAreaLav(iCond, iBtmTop).TensSaddle.K1(iSadd, 1)) & Par)
9280:           .Printa(GlobalRoutines.FormatS(RIS(3 + (iSadd - 1) * 21), pAreaLav(iCond, iBtmTop).TensSaddle.k2(iSadd, 0), pAreaLav(iCond, iBtmTop).TensSaddle.k2(iSadd, 1)) & Par)
9290:           If pAreaLav(iCond, iBtmTop).TensSaddle.ROUND(iSadd, 0) = 0 And pAreaLav(iCond, iBtmTop).TensSaddle.ROUND(iSadd, 1) = 0 Then GoTo 9320
9300:           .Printa(RIS(17) & Par)
9310:           .Printa(RIS(18 + iSadd - 1) & Par) : .Printa(RIS(23) & Par)
9320:           .Printa(GlobalRoutines.FormatS(RIS(4 + (iSadd - 1) * 6), pAreaLav(iCond, iBtmTop).Momen(iSadd)) & Par)
9330:           .Printa(RIS(5) & Par)
                .Printa(ChangTab1)
9340:           .Printa(GlobalRoutines.FormatS(RIS(6 + (iSadd - 1) * 5), pAreaLav(iCond, iBtmTop).TensSaddle.F3(iSadd, 0)) & GlobalRoutines.FormatS("\tab " & Right(RIS(6), 30), pAreaLav(iCond, iBtmTop).TensSaddle.F3(iSadd, 1)) & Par)
9350:           .Printa(GlobalRoutines.FormatS(RIS(7 + (iSadd - 1) * 5), pAreaLav(iCond, iBtmTop).TensSaddle.F4(iSadd, 0)) & GlobalRoutines.FormatS("\tab " & Right(RIS(7), 30), pAreaLav(iCond, iBtmTop).TensSaddle.F4(iSadd, 1)) & Par)
                .Printa(ChangTab2)
            Else
                .Printa(GlobalRoutines.FormatS(RIS(1), pAreaLav(iCond, iBtmTop).TensSaddle.K1(iSadd, Mode - 1)) & Par)
                .Printa(GlobalRoutines.FormatS(RIS(2), pAreaLav(iCond, iBtmTop).TensSaddle.k2(iSadd, Mode - 1)) & Par)
                .Printa(GlobalRoutines.FormatS(RIS(3), pAreaLav(iCond, iBtmTop).TensSaddle.F3(iSadd, Mode - 1)) & Par)
                .Printa(GlobalRoutines.FormatS(RIS(4), pAreaLav(iCond, iBtmTop).TensSaddle.F4(iSadd, Mode - 1)) & Par)
            End If
        End With
    End Sub
    Public Sub StFondo(ByVal iBtmTop As Short)
        Dim De, d3, f As Single
        Dim c1, R, c2 As Single
        Dim Pd, k2 As Single
        R = pSaddlesItem(iBtmTop).MeanR(iSadd)
        d3 = pSaddlesItem(iBtmTop).SpessHead(iSadd)
        De = 2 * (R + pSaddlesItem(iBtmTop).Spess(0))
        f = pAreaLav(iCond, iBtmTop).React(iSadd)
        Pd = pSaddlesLoad(iCond, iBtmTop).DesPress
        k2 = pAreaLav(iCond, iBtmTop).ShearSaddle.K3(iSadd)
        With pAreaLav(iCond, iBtmTop).CircSaddle
            .K6(iSadd) = kSt(4, iSadd)
            If d3 = 0 Then
                MsgBox("Non è stato definito lo spessore del fondo lato sella n°" & Str(iSadd), MsgBoxStyle.Exclamation)
                Exit Sub
            End If
            .F6(iSadd) = k2 * f / R / d3 'log(2.71)
            c1 = CSng(10 ^ (1.125 * (1.6 - System.Math.Log(100 * 0.16 / 0.85) / 2.30259) * (1 - d3 / 1.1 / 0.16 / De)))
            c2 = CSng(1 + 0.305 / 2.30259 * System.Math.Log(1 + d3 / 0.16 / De) + 0.1574 * (System.Math.Log(1 + d3 / 0.16 / De) / 2.30259) ^ 2)
            .K6S(iSadd) = c1
            .ZETS(iSadd) = c2
            .F6S(iSadd) = .K6(iSadd) * f / R / d3 + Pd * De * c1 * c2 / 2 / d3
        End With

    End Sub
    Public Sub SellaPagina()
        Dim i, Delty As Short
        If Inizializzando Then Exit Sub
        Try
            With frmSaddles.DefInstance
                If .Text51.Count > 1 And Not .Combo52(27) Is Nothing Then
                    .Combo52(27).Items.Clear()
                    Call DispCond(.Combo52(27), 2)
                    Exit Sub
                End If
                .Label51(0).Text = "Sella"
                .Combo52(0).Width = CInt(GlobalRoutines.TwipsToPixelsX(1065))
                .Combo52(0).Items.Clear()
                .Combo52(0).Items.Add("Fissa ")
                .Combo52(0).Items.Add("Mobile")
                mioContr2(0) = .Combo52(0)
                .Combo52.Load(1)
                .Label51.Load(1)
                .Combo52(1).Width = CInt(GlobalRoutines.TwipsToPixelsX(1065))
                .Label51(1).Text = "Sella rinforzata a C o a I ?"
                .Combo52(1).Items.Clear()
                .Combo52(1).Items.Add("Rinf.C")
                .Combo52(1).Items.Add("Rinf.I")
                mioContr2(1) = .Combo52(1)
                .Label52.Load(1)
                .Label52(1).Text = ""
                .Label52(0).Text = ""
                .Label52(0).BringToFront()
                .Label52(1).BringToFront()
                For i = 2 To 19
                    .Label52.Load(i)
                    .Label52(i).Text = "mm"
                    .Label52(i).BringToFront()
                    .Label51.Load(i)
                    If i = 7 Then
                        .Text52.Load(i)
                        mioContr2(i) = .Text52(i)
                    Else
                        .Text51.Load(i)
                        mioContr2(i) = .Text51(i)
                    End If
                Next
                Ncontr = 26
                .Label51(2).Text = "Numero dei rinforzi"
                .Label52(2).Text = ""
                .Label51(3).Text = "Lunghezza della sella (nervatura principale)"
                .Label51(4).Text = "Larghezza della sella (larghezza totale)"
                .Label51(5).Text = "Spessore  della sella (nervatura principale)"
                .Label51(6).Text = "Spessore dei rinforzi"
                .Label51(7).Text = "Materiale"
                .Label52(7).Text = ""
                .Label51(8).Text = "Tensione ammissibile"
                .Label52(8).Text = "MPa"
                .Label51(9).Text = "Sforzo verticale"
                .Label52(9).Text = "N"
                .Label51(10).Text = "Taglio longitudinale"
                .Label52(10).Text = "N"
                .Label51(11).Text = "Taglio trasversale"
                .Label52(11).Text = "N"
                .Label51(12).Text = "Momento longitudinale"
                .Label52(12).Text = "N.m"
                .Label51(13).Text = "Momento trasversale"
                .Label52(13).Text = "N.m"
                .Label51(14).Text = "Momento torcente"
                .Label52(14).Text = "N.m"
                For i = 15 To 15 + 4
                    .Label51(i).Text = "Distanza coppia di rinforzi n°" & Str(i - 14)
                    .Label51.Load(i + 5)
                    .Label51(i + 5).Text = "Nota: distanze da asse trasversale sella"
                Next
                .Label51.Load(25)
                .Label51(25).Text = "La direzione longitudinale è l'asse del vettore"
                .Label51.Load(26)
                .Label51(26).Text = "La direzione trasversa è l'asse del vettore"
                For i = 0 To 14
                    .Label51(i).Left = 0
                    .Label51(i).Top = i * .Label51(i).Height
                    .Label51(i).BringToFront()
                    .Label52(i).Left = .Label51(i).Width
                    .Label52(i).Top = i * .Label52(i).Height
                    mioContr2(i).Left = .Label52(0).Left + .Label52(0).Width
                    mioContr2(i).Top = i * .Label51(0).Height
                    mioContr2(i).TabIndex = i : mioContr2(i).Visible = True
                    .Label51(i).Visible = True
                    .Label52(i).Visible = True
                    mioContr2(i).Enabled = True
                    .Label51(i).Enabled = True
                    .Label52(i).Enabled = True
                Next
                nDist = CShort(xSupport(iSadd).NumeroRibs \ 2)
                For i = 15 To 19
                    .Label51(i).Left = 0
                    .Label51(i).Top = i * .Label51(i).Height
                    .Label52(i).BringToFront()
                    .Label52(i).Left = .Label51(i).Width
                    .Label52(i).Top = i * .Label52(i).Height
                    mioContr2(i).Left = .Label52(0).Left + .Label52(0).Width
                    mioContr2(i).Top = i * .Label51(0).Height
                    mioContr2(i).TabIndex = i
                    mioContr2(i).Visible = (i < 15 + nDist)
                    .Label51(i).Visible = (i < 15 + nDist)
                    .Label52(i).Visible = (i < 15 + nDist)
                    .Label51(i + 5).Top = .Label51(i).Top
                    .Label51(i + 5).Left = .Text51(i).Left + .Text51(i).Width
                    .Label51(i + 5).Enabled = True
                    .Label51(i + 5).Visible = (i < 15 + nDist)
                    mioContr2(i).Enabled = True
                    .Label51(i).Enabled = True
                    .Label52(i).Enabled = True
                Next
                For i = 12 To 13
                    .Label51(i + 13).Top = .Label51(i).Top
                    .Label51(i + 13).Left = .Text51(i).Left + .Text51(i).Width
                    .Label51(i + 13).Enabled = True
                    .Label51(i + 13).Visible = True
                Next
                Ncontr = CShort(Ncontr + 1) ' cioè 27
                .Label51.Load(Ncontr)
                .Label51(Ncontr).Top = .Label51(0).Top
                .Label51(Ncontr).Left = mioContr2(0).Left + mioContr2(0).Width
                .Label51(Ncontr).Text = "Caso di carico"
                .Label51(Ncontr).Width = CInt(GlobalRoutines.TwipsToPixelsX(1200))
                .Combo52.Load(Ncontr)
                .Combo52(Ncontr).Items.Clear()
                Call DispCond(.Combo52(Ncontr), 2)
                mioContr2(Ncontr) = .Combo52(Ncontr)
                mioContr2(Ncontr).Top = mioContr2(0).Top
                mioContr2(Ncontr).Left = .Label51(Ncontr).Left + .Label51(Ncontr).Width
                mioContr2(Ncontr).Width = .PagCalcMant.Width - mioContr2(Ncontr).Left - SystemInformation.Border3DSize.Width
                .Label51(Ncontr).Visible = True : mioContr2(Ncontr).Visible = True : mioContr2(Ncontr).Enabled = True
                Delty = CShort((14 + nDist + 1) * .Label51(0).Height + 4 * SystemInformation.Border3DSize.Height)
                .TabPrimoLivDown.Height = Math.Max(.TabPrimoLivDown.Height, Delty)
                .cmdCalcMant5.Top = .PagCalcMant.Height - .cmdCalcMant5.Height
                .cmdCalcMant5.Left = .PagCalcMant.Width - .cmdCalcMant5.Width
            End With
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Public Sub SellaPaginaT()
        Dim i, Delty As Short
        If Inizializzando Then Exit Sub
        Try
            With frmSaddles.DefInstance
                If .Text51T.Count > 1 And Not .Combo52T(27) Is Nothing Then
                    .Combo52T(27).Items.Clear()
                    Call DispCondT(.Combo52T(27), 2)
                    Exit Sub
                End If
                .Label51T(0).Text = "Sella"
                .Combo52T(0).Width = CInt(GlobalRoutines.TwipsToPixelsX(1065))
                .Combo52T(0).Items.Clear()
                .Combo52T(0).Items.Add("Fissa ")
                .Combo52T(0).Items.Add("Mobile")
                mioContr2T(0) = .Combo52T(0)
                .Combo52T.Load(1)
                .Label51T.Load(1)
                .Combo52T(1).Width = CInt(GlobalRoutines.TwipsToPixelsX(1065))
                .Label51T(1).Text = "Sella rinforzata a C o a I ?"
                .Combo52T(1).Items.Clear()
                .Combo52T(1).Items.Add("Rinf.C")
                .Combo52T(1).Items.Add("Rinf.I")
                mioContr2T(1) = .Combo52T(1)
                .Label52.Load(1)
                .Label52(1).Text = ""
                .Label52(0).Text = ""
                .Label52(0).BringToFront()
                .Label52(1).BringToFront()
                For i = 2 To 19
                    .Label52.Load(i)
                    .Label52(i).Text = "mm"
                    .Label52(i).BringToFront()
                    .Label51T.Load(i)
                    If i = 7 Then
                        .Text52T.Load(i)
                        mioContr2T(i) = .Text52T(i)
                    Else
                        .Text51T.Load(i)
                        mioContr2T(i) = .Text51T(i)
                    End If
                Next
                Ncontr = 26
                .Label51T(2).Text = "Numero dei rinforzi"
                .Label52(2).Text = ""
                .Label51T(3).Text = "Lunghezza della sella (nervatura principale)"
                .Label51T(4).Text = "Larghezza della sella (larghezza totale)"
                .Label51T(5).Text = "Spessore  della sella (nervatura principale)"
                .Label51T(6).Text = "Spessore dei rinforzi"
                .Label51T(7).Text = "Materiale"
                .Label52(7).Text = ""
                .Label51T(8).Text = "Tensione ammissibile"
                .Label52(8).Text = "MPa"
                .Label51T(9).Text = "Sforzo verticale"
                .Label52(9).Text = "N"
                .Label51T(10).Text = "Taglio longitudinale"
                .Label52(10).Text = "N"
                .Label51T(11).Text = "Taglio trasversale"
                .Label52(11).Text = "N"
                .Label51T(12).Text = "Momento longitudinale"
                .Label52(12).Text = "N.m"
                .Label51T(13).Text = "Momento trasversale"
                .Label52(13).Text = "N.m"
                .Label51T(14).Text = "Momento torcente"
                .Label52(14).Text = "N.m"
                For i = 15 To 15 + 4
                    .Label51T(i).Text = "Distanza coppia di rinforzi n°" & Str(i - 14)
                    .Label51T.Load(i + 5)
                    .Label51T(i + 5).Text = "Nota: distanze da asse trasversale sella"
                Next
                .Label51T.Load(25)
                .Label51T(25).Text = "La direzione longitudinale è l'asse del vettore"
                .Label51T.Load(26)
                .Label51T(26).Text = "La direzione trasversa è l'asse del vettore"
                For i = 0 To 14
                    .Label51T(i).Left = 0
                    .Label51T(i).Top = i * .Label51T(i).Height
                    .Label51T(i).BringToFront()
                    .Label52(i).Left = .Label51T(i).Width
                    .Label52(i).Top = i * .Label52(i).Height
                    mioContr2T(i).Left = .Label52(0).Left + .Label52(0).Width
                    mioContr2T(i).Top = i * .Label51T(0).Height
                    mioContr2T(i).TabIndex = i : mioContr2T(i).Visible = True
                    .Label51T(i).Visible = True
                    .Label52(i).Visible = True
                    mioContr2T(i).Enabled = True
                    .Label51T(i).Enabled = True
                    .Label52(i).Enabled = True
                Next
                nDist = CShort(xSupportT(iSadd).NumeroRibs \ 2)
                For i = 15 To 19
                    .Label51T(i).Left = 0
                    .Label51T(i).Top = i * .Label51T(i).Height
                    .Label52(i).BringToFront()
                    .Label52(i).Left = .Label51T(i).Width
                    .Label52(i).Top = i * .Label52(i).Height
                    mioContr2T(i).Left = .Label52(0).Left + .Label52(0).Width
                    mioContr2T(i).Top = i * .Label51T(0).Height
                    mioContr2T(i).TabIndex = i
                    mioContr2T(i).Visible = (i < 15 + nDist)
                    .Label51T(i).Visible = (i < 15 + nDist)
                    .Label52(i).Visible = (i < 15 + nDist)
                    .Label51T(i + 5).Top = .Label51T(i).Top
                    .Label51T(i + 5).Left = .Text51T(i).Left + .Text51T(i).Width
                    .Label51T(i + 5).Enabled = True
                    .Label51T(i + 5).Visible = (i < 15 + nDist)
                    mioContr2T(i).Enabled = True
                    .Label51T(i).Enabled = True
                    .Label52(i).Enabled = True
                Next
                For i = 12 To 13
                    .Label51T(i + 13).Top = .Label51T(i).Top
                    .Label51T(i + 13).Left = .Text51T(i).Left + .Text51T(i).Width
                    .Label51T(i + 13).Enabled = True
                    .Label51T(i + 13).Visible = True
                Next
                Ncontr = CShort(Ncontr + 1) ' cioè 27
                .Label51T.Load(Ncontr)
                .Label51T(Ncontr).Top = .Label51T(0).Top
                .Label51T(Ncontr).Left = mioContr2T(0).Left + mioContr2T(0).Width
                .Label51T(Ncontr).Text = "Caso di carico"
                .Label51T(Ncontr).Width = CInt(GlobalRoutines.TwipsToPixelsX(1200))
                .Combo52T.Load(Ncontr)
                .Combo52T(Ncontr).Items.Clear()
                Call DispCondT(.Combo52T(Ncontr), 2)
                mioContr2T(Ncontr) = .Combo52T(Ncontr)
                mioContr2T(Ncontr).Top = mioContr2T(0).Top
                mioContr2T(Ncontr).Left = .Label51T(Ncontr).Left + .Label51T(Ncontr).Width
                mioContr2T(Ncontr).Width = .PagCalcMant.Width - mioContr2T(Ncontr).Left - SystemInformation.Border3DSize.Width
                .Label51T(Ncontr).Visible = True : mioContr2T(Ncontr).Visible = True : mioContr2T(Ncontr).Enabled = True
                Delty = CShort((14 + nDist + 1) * .Label51T(0).Height + 4 * SystemInformation.Border3DSize.Height)
                .TabPrimoLivUp.Height = Math.Max(.TabPrimoLivUp.Height, Delty)
                .cmdCalcMant5T.Top = .PagCalcMantT.Height - .cmdCalcMant5T.Height
                .cmdCalcMant5T.Left = .PagCalcMantT.Width - .cmdCalcMant5T.Width
            End With
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Private Sub SubTesta(ByVal caso As Integer)
        With Monitor.Motore.Problem.FileStream
            Select Case caso
                Case 0
                    .WriteLine("                   Calculation of the foundation loads\par \par")
                Case 1
                    .WriteLine("                   Check of the shell stresses      \par \par")
                Case 2
                    .WriteLine("                   Check of the saddle structure    \par \par")
                Case 3
                    .WriteLine("                   Check of baseplate/bolts/concrete\par \par")
                Case -1
            End Select
        End With
    End Sub
    Public Function Stampa(ByVal iBtmTop As Short) As Boolean
        Dim iSaddV As Short
        Stampa = True
        NomeFileSt = Left(FileData, Len(FileData) - 3) & "SDO"
        iSaddV = iSadd
        If Not Monitor.Motore.PrepRapp(NomeFileSt) Then Return False
        '-------------------------------------------------
        If LoadsCalcolate Then
            Call Monitor.Motore.Testata()
            SubTesta(0)
            Call Monitor.Motore.Problem.Printa(GlobalRoutines.SegnaLibro("LoadsCalcolate", True) & "\par ")
        End If
        If SaddlesCalcolate Then
            If Monitor.Motore.Problem.StampaTutto > 0 Then
                For iCond = 0 To CShort(Problem.NCond(1) - 1)
                    Call Monitor.Motore.Testata()
                    Call SubTesta(1)
                    Call StampaSaddles(iBtmTop)
                Next
            Else
                iCond = iCondMax(1)
                Call Monitor.Motore.Testata()
                Call SubTesta(1)
                Call StampaSaddles(iBtmTop)
            End If
            iSadd = iSaddV
        End If
        If SelleCalcolate Then
            If Monitor.Motore.Problem.StampaTutto > 0 Then
                For iCond = 0 To CShort(Problem.NCond(2) - 1)
                    For iSadd = 1 To 2
                        Call Monitor.Motore.Testata()
                        Call SubTesta(2)
                        Call StampaSelle(iBtmTop)
                    Next
                Next
            Else
                iCond = iCondMax(2)
                For iSadd = 1 To 2
                    Call Monitor.Motore.Testata()
                    Call SubTesta(2)
                    Call StampaSelle(iBtmTop)
                Next
            End If
            iSadd = iSaddV
        End If
        If FondaCalcolate Then
            If Monitor.Motore.Problem.StampaTutto > 0 Then
                For iCond = 0 To CShort(Problem.NCond(3) - 1)
                    For iSadd = 1 To 2
                        Monitor.Motore.Testata()
                        Call SubTesta(3)
                        Call StampaFonda()
                    Next
                Next
            Else
                iCond = iCondMax(3)
                For iSadd = 1 To 2
                    Monitor.Motore.Testata()
                    Call SubTesta(3)
                    Call StampaFonda()
                Next
            End If
            iSadd = iSaddV
        End If
        '-------------------------------------------------
12580:  Monitor.Motore.Problem.FineRapp()
    End Function

    Public Sub AggSellaPagina()
        Dim i As Short
        If Inizializzando Then Exit Sub
        Try
            If Not (xSupport(iSadd).Tipo = "I" Or xSupport(iSadd).Tipo = "C") Then xSupport(iSadd).Tipo = xSupport(1).Tipo
            If Not (xSupport(iSadd).Tipo = "I" Or xSupport(iSadd).Tipo = "C") Then xSupport(iSadd).Tipo = "I"
            If xSupport(iSadd).SaddlThk = 0 Then xSupport(iSadd).SaddlThk = SaddlesItem.GeomSadd(iSadd).SaddlThk
            If xSupport(iSadd).RibsThk = 0 Then xSupport(iSadd).RibsThk = SaddlesItem.GeomSadd(iSadd).SaddlThk
            If xSupport(iSadd).NumeroRibs < 2 Then xSupport(iSadd).NumeroRibs = 2
            If xSupport(iSadd).NumeroRibs > 11 Then xSupport(iSadd).NumeroRibs = 11
            If xSupport(iSadd).SaddlWidth = 0 Then xSupport(iSadd).SaddlWidth = SaddlesItem.GeomSadd(iSadd).AxialWidth
            With frmSaddles.DefInstance
                .Text51(2).Text = GlobalRoutines.myStr(CSng(xSupport(iSadd).NumeroRibs), 3, 0, -1)
                .Text51(3).Text = GlobalRoutines.myStr(xSupport(iSadd).SaddlLength, 5, 2, 0)
                .Text51(4).Text = GlobalRoutines.myStr(xSupport(iSadd).SaddlWidth, 5, 2, 0)
                .Text51(5).Text = GlobalRoutines.myStr(xSupport(iSadd).SaddlThk, 5, 2, 0)
                .Text51(6).Text = GlobalRoutines.myStr(xSupport(iSadd).RibsThk, 5, 2, 0)
                If xSupport(iSadd).material Is Nothing Then xSupport(iSadd).material = ""
                .Text52(7).Text = xSupport(iSadd).material
                .Text51(8).Text = GlobalRoutines.myStr(xSupportData(iSadd, iCond).Allow, 5, 2, 0)
                .Text51(9).Text = GlobalRoutines.myStr(xSupportData(iSadd, iCond).NormalForce, 5, 2, 0)
                .Text51(10).Text = GlobalRoutines.myStr(xSupportData(iSadd, iCond).ShearLong, 5, 2, 0)
                .Text51(11).Text = GlobalRoutines.myStr(xSupportData(iSadd, iCond).ShearTrasv, 5, 2, 0)
                .Text51(12).Text = GlobalRoutines.myStr(xSupportData(iSadd, iCond).MomLong, 5, 2, 0)
                .Text51(13).Text = GlobalRoutines.myStr(xSupportData(iSadd, iCond).MomTrasv, 5, 2, 0)
                .Text51(14).Text = GlobalRoutines.myStr(xSupportData(iSadd, iCond).MomTorc, 5, 2, 0)
                For i = 1 To CShort(xSupport(iSadd).NumeroRibs \ 2)
                    .Text51(14 + i).Text = GlobalRoutines.myStr(xSupport(iSadd).Dist(i), 5, 2, 0)
                Next
                If xSupport(iSadd).Tipo = "C" Then .Combo52(1).SelectedIndex = 0 Else .Combo52(1).SelectedIndex = 1
                .Check2.Visible = False
                .Combo52(0).SelectedIndex = iSadd - 1
                .Combo52(27).SelectedIndex = iCond
            End With
        Catch e As Exception
            MsgBox(e.Message & vbCrLf & e.StackTrace)
        End Try
    End Sub
    Public Sub AggSellaPaginaT()
        Dim i As Short
        If Inizializzando Then Exit Sub
        Try
            If Not (xSupportT(iSadd).Tipo = "I" Or xSupportT(iSadd).Tipo = "C") Then xSupportT(iSadd).Tipo = xSupportT(1).Tipo
            If Not (xSupportT(iSadd).Tipo = "I" Or xSupportT(iSadd).Tipo = "C") Then xSupportT(iSadd).Tipo = "I"
            If xSupportT(iSadd).SaddlThk = 0 Then xSupportT(iSadd).SaddlThk = SaddlesItemT.GeomSadd(iSadd).SaddlThk
            If xSupportT(iSadd).RibsThk = 0 Then xSupportT(iSadd).RibsThk = SaddlesItemT.GeomSadd(iSadd).SaddlThk
            If xSupportT(iSadd).NumeroRibs < 2 Then xSupportT(iSadd).NumeroRibs = 2
            If xSupportT(iSadd).NumeroRibs > 11 Then xSupportT(iSadd).NumeroRibs = 11
            If xSupportT(iSadd).SaddlWidth = 0 Then xSupportT(iSadd).SaddlWidth = SaddlesItemT.GeomSadd(iSadd).AxialWidth
            With frmSaddles.DefInstance
                .Text51T(2).Text = GlobalRoutines.myStr(CSng(xSupportT(iSadd).NumeroRibs), 3, 0, -1)
                .Text51T(3).Text = GlobalRoutines.myStr(xSupportT(iSadd).SaddlLength, 5, 2, 0)
                .Text51T(4).Text = GlobalRoutines.myStr(xSupportT(iSadd).SaddlWidth, 5, 2, 0)
                .Text51T(5).Text = GlobalRoutines.myStr(xSupportT(iSadd).SaddlThk, 5, 2, 0)
                .Text51T(6).Text = GlobalRoutines.myStr(xSupportT(iSadd).RibsThk, 5, 2, 0)
                If xSupportT(iSadd).material Is Nothing Then xSupportT(iSadd).material = ""
                .Text52T(7).Text = xSupportT(iSadd).material
                .Text51T(8).Text = GlobalRoutines.myStr(xSupportDataT(iSadd, iCond).Allow, 5, 2, 0)
                .Text51T(9).Text = GlobalRoutines.myStr(xSupportDataT(iSadd, iCond).NormalForce, 5, 2, 0)
                .Text51T(10).Text = GlobalRoutines.myStr(xSupportDataT(iSadd, iCond).ShearLong, 5, 2, 0)
                .Text51T(11).Text = GlobalRoutines.myStr(xSupportDataT(iSadd, iCond).ShearTrasv, 5, 2, 0)
                .Text51T(12).Text = GlobalRoutines.myStr(xSupportDataT(iSadd, iCond).MomLong, 5, 2, 0)
                .Text51T(13).Text = GlobalRoutines.myStr(xSupportDataT(iSadd, iCond).MomTrasv, 5, 2, 0)
                .Text51T(14).Text = GlobalRoutines.myStr(xSupportDataT(iSadd, iCond).MomTorc, 5, 2, 0)
                For i = 1 To CShort(xSupportT(iSadd).NumeroRibs \ 2)
                    .Text51T(14 + i).Text = GlobalRoutines.myStr(xSupportT(iSadd).Dist(i), 5, 2, 0)
                Next
                If xSupportT(iSadd).Tipo = "C" Then .Combo52T(1).SelectedIndex = 0 Else .Combo52T(1).SelectedIndex = 1
                '.Check2.Visible = False
                .Combo52T(0).SelectedIndex = iSadd - 1
                .Combo52T(27).SelectedIndex = iCond
            End With
        Catch e As Exception
            MsgBox(e.Message & vbCrLf & e.StackTrace)
        End Try
    End Sub

    Public Sub StampaSelle(ByVal iBtmTop As Short)
        Dim RIS(50) As String
        Dim ifl, i As Short
        With Monitor.Motore.Problem
            ifl = CShort(FreeFile())
            FileOpen(ifl, RTrim(Monitor.Motore.Inizio.Archdir) & "\WR\SADD20.SDD", OpenMode.Input, , OpenShare.Shared)
            For i = 1 To 37 : RIS(i) = LineInput(ifl) : Next
            FileClose(ifl)
            .Printa("Client and Plant        " & .ClientPlant & Par)
            .Printa("Item                    " & .Item & Par)
            Call StLoadC(2)
            .Printa("---------------------------------------------------------------" & Par)
            .Printa("Analysis of the stresses in the saddles" & Par)
            If iSadd = 1 Then
                .Printa("INPUT DATA FOR FIXED SADDLE " & Par)
            Else
                .Printa("INPUT DATA FOR SLIDING SADDLE " & Par)
            End If
            .Printa("---------------------------------------------------------------" & Par)
            If pxSupport(iSadd, iBtmTop).Tipo = "C" Then
                .Printa(GlobalRoutines.FormatS(RIS(1), 9423) & Par)
            Else
                .Printa(GlobalRoutines.FormatS(RIS(2), 9423) & Par)
            End If
            .Printa(GlobalRoutines.FormatS(RIS(3), pxSupport(iSadd, iBtmTop).SaddlLength) & Par)
            .Printa(GlobalRoutines.FormatS(RIS(4), pxSupport(iSadd, iBtmTop).SaddlWidth) & Par)
            .Printa(GlobalRoutines.FormatS(RIS(5), pxSupport(iSadd, iBtmTop).SaddlThk) & Par)
            .Printa(GlobalRoutines.FormatS(RIS(6), pxSupport(iSadd, iBtmTop).RibsThk) & Par)
            For i = 1 To CShort(pxSupport(iSadd, iBtmTop).NumeroRibs \ 2)
                .Printa(RIS(7) & "{\sub" & Str(i) & "}")
                .Printa(GlobalRoutines.FormatS(RIS(8), pxSupport(iSadd, iBtmTop).Dist(i)) & Par)
            Next
            .Printa(GlobalRoutines.FormatS(RIS(9), pxSupport(iSadd, iBtmTop).NumeroRibs) & Par)
            .Printa(RIS(10) & pxSupport(iSadd, iBtmTop).material & Par)
            .Printa(GlobalRoutines.FormatS(RIS(11), pxSupportData(iSadd, iCond, iBtmTop).Allow) & Par)
            .Printa(RIS(12) & Par)
            .Printa(GlobalRoutines.FormatS(RIS(13), pxSupportData(iSadd, iCond, iBtmTop).NormalForce) & Par)
            .Printa(GlobalRoutines.FormatS(RIS(14), pxSupportData(iSadd, iCond, iBtmTop).ShearTrasv) & Par)
            .Printa(GlobalRoutines.FormatS(RIS(15), pxSupportData(iSadd, iCond, iBtmTop).ShearLong) & Par)
            .Printa(GlobalRoutines.FormatS(RIS(16), pxSupportData(iSadd, iCond, iBtmTop).MomTorc) & Par)
            .Printa(GlobalRoutines.FormatS(RIS(17), pxSupportData(iSadd, iCond, iBtmTop).MomTrasv) & Par)
            .Printa(GlobalRoutines.FormatS(RIS(18), pxSupportData(iSadd, iCond, iBtmTop).MomLong) & Par)
            .Printa("---------------------------------------------------------------" & Par)
            .Printa("CALCULATIONS RESULTS    " & Par)
            .Printa("---------------------------------------------------------------" & Par)
            .Printa(RIS(19) & Par)
            .Printa(GlobalRoutines.FormatS(RIS(20), xSupportResult(iSadd, iCond).a) & Par)
            .Printa(GlobalRoutines.FormatS(RIS(21), xSupportResult(iSadd, iCond).Ay) & Par)
            .Printa(GlobalRoutines.FormatS(RIS(22), xSupportResult(iSadd, iCond).Az) & Par)
            .Printa(GlobalRoutines.FormatS(RIS(23), xSupportResult(iSadd, iCond).j) & Par)
            .Printa(GlobalRoutines.FormatS(RIS(24), xSupportResult(iSadd, iCond).Iy) & Par)
            .Printa(GlobalRoutines.FormatS(RIS(25), xSupportResult(iSadd, iCond).Iz) & Par)
            .Printa(RIS(26) & Par)
            .Printa(GlobalRoutines.FormatS(RIS(27), xSupportResult(iSadd, iCond).sfx) & Par)
            .Printa(GlobalRoutines.FormatS(RIS(28), xSupportResult(iSadd, iCond).SMy) & Par)
            .Printa(GlobalRoutines.FormatS(RIS(29), xSupportResult(iSadd, iCond).SMz) & Par)
            .Printa(GlobalRoutines.FormatS(RIS(30), xSupportResult(iSadd, iCond).TMx) & Par)
            .Printa(GlobalRoutines.FormatS(RIS(31), xSupportResult(iSadd, iCond).TFy) & Par)
            .Printa(GlobalRoutines.FormatS(RIS(32), xSupportResult(iSadd, iCond).TFz) & Par)
            .Printa(RIS(33) & Par)
            .Printa(GlobalRoutines.FormatS(RIS(34), xSupportResult(iSadd, iCond).Stress) & Par)
            .Printa(GlobalRoutines.FormatS(RIS(35), pxSupportData(iSadd, iCond, iBtmTop).Allow) & Par)
            If xSupportResult(iSadd, iCond).Stress < pxSupportData(iSadd, iCond, iBtmTop).Allow Then
                .Printa(RIS(36) & Par)
            Else
                .Printa(RIS(37) & Par)
            End If
        End With
    End Sub

    Public Sub FondaPagina()
        Dim Delty, i As Short
        If Inizializzando Then Exit Sub
        Try
            With frmSaddles.DefInstance
                If .Label61.Count > 1 Then
                    .Combo62(0).Items.Clear()
                    Call DispCond(.Combo62(0), 3)
                    Exit Sub
                End If
                .Label61(0).Text = "Caso di carico"
                .Combo62(0).Items.Clear()
                Call DispCond(.Combo62(0), 3)
                mioContr3(0) = .Combo62(0)
                .Label62(0).BringToFront()
                For i = 1 To 22
                    .Label62.Load(i)
                    .Label62(i).Text = "mm"
                    .Label62(i).BringToFront()
                    .Label61.Load(i)
                    If i = 8 Or i = 11 Or i = 13 Then
                        .Text62.Load(i)
                        mioContr3(i) = .Text62(i)
                    Else
                        .Text61.Load(i)
                        mioContr3(i) = .Text61(i)
                    End If
                Next
                Ncontr = 23
                .Label61(1).Text = "Lunghezza piastra di base"
                .Label61(2).Text = "Larghezza piastra di base"
                .Label61(3).Text = "Spessore piastra di base"
                '  .Label61(4).text = "Distanza bulloni tesi dal bordo compresso"
                .Label61(4).Text = "Luce trasversale  (secondo y)"
                .Label61(5).Text = "Luce longitudinale (secondo x)"
                .Label61(6).Text = "Numero costole adiacenti ad ogni bullone"
                .Label62(6).Text = ""
                .Label61(7).Text = "Numero totale bulloni"
                .Label62(7).Text = ""
                '  .Label61(9).text = "Numero bulloni tesi": .Label62(9).text = ""
                .Label61(8).Text = "Diametro nominale bulloni"
                .Label62(8).Text = ""
                .Label61(9).Text = "Area gambo bulloni"
                .Label62(9).Text = "mm2"
                .Label61(10).Text = "Area nocciolo bulloni"
                .Label62(10).Text = "mm2"
                .Label61(11).Text = "Materiale piastra di base"
                .Label62(11).Text = ""
                .Label61(12).Text = "Ammissibile piastra di base"
                .Label62(12).Text = "MPa"
                .Label61(13).Text = "Materiale bulloni di fondazione"
                .Label62(13).Text = ""
                .Label61(14).Text = "Ammissibile a trazione"
                .Label62(14).Text = "MPa"
                .Label61(15).Text = "Ammissibile a taglio"
                .Label62(15).Text = "MPa"
                .Label61(16).Text = "Ammissibile calcestruzzo a compressione"
                .Label62(16).Text = "MPa"
                .Label61(17).Text = "Rapporto moduli elastici"
                .Label62(17).Text = ""
                .Label61(18).Text = "Sforzo normale"
                .Label62(18).Text = "N"
                .Label61(19).Text = "Momento alla base x"
                .Label62(19).Text = "N.m"
                .Label61(20).Text = "Taglio            x"
                .Label62(20).Text = "N"
                .Label61(21).Text = "Momento alla base y"
                .Label62(21).Text = "N.m"
                .Label61(22).Text = "Taglio            y"
                .Label62(22).Text = "N"
                .Label61.Load(23)
                .Label61(23).Text = "Sella"
                .Label61(23).Width = CInt(GlobalRoutines.TwipsToPixelsX(1065))
                .Combo62.Load(23)
                .Combo62(23).Width = CInt(GlobalRoutines.TwipsToPixelsX(1065))
                mioContr3(23) = .Combo62(23)
                .Combo62(23).Items.Clear()
                .Combo62(23).Items.Add("Fissa ")
                .Combo62(23).Items.Add("Mobile")
                If xFondaItem(iSadd).nt < 1 Then xFondaItem(iSadd).nt = 4
                .Label61.Load(24)
                .Label61(24).Text = "Quota x          Quota y"
                For i = 0 To 23
                    If i < 23 Then
                        .Label61(i).Left = 0
                        .Label61(i).Top = i * .Label61(i).Height
                        .Label61(i).BringToFront()
                        .Label62(i).Left = .Label61(i).Width
                        .Label62(i).Top = i * .Label62(i).Height
                        mioContr3(i).Left = .Label62(0).Left + .Label62(0).Width
                        mioContr3(i).Top = i * .Label61(0).Height
                        .Label62(i).Visible = True
                        .Label62(i).Enabled = True
                    End If
                    mioContr3(i).TabIndex = i : mioContr3(i).Visible = True
                    .Label61(i).Visible = True
                    mioContr3(i).Enabled = True
                    .Label61(i).Enabled = True
                Next
                .cmdLibrTir.Top = .Label61(9).Top
                .cmdLibrTir.Left = mioContr3(9).Left + mioContr3(9).Width
                .Combo62(0).Width = .PagCalcFonda.Width - .Combo62(0).Left - SystemInformation.Border3DSize.Width
                .Label61(23).Top = .Label61(1).Top
                .Label61(23).Left = mioContr3(1).Left + mioContr3(1).Width
                .Combo62(23).Top = .Label61(23).Top
                .Combo62(23).Left = .Label61(23).Left + .Label61(23).Width
                .Label61(24).Top = .Label61(2).Top
                .Label61(24).Left = mioContr3(23).Left
                .Label61(24).Width = 2 * mioContr3(23).Width
                .Label61(24).Visible = True
                .Label61(24).Enabled = True
                Delty = CShort(23 * .Label51(0).Height + 4 * SystemInformation.Border3DSize.Height)
                .TabPrimoLivDown.Height = Math.Max(.TabPrimoLivDown.Height, Delty)
                .Picture2.Top = .PagCalcMant.Height - .Picture2.Height
                .Picture2.Left = .PagCalcMant.Width - .Picture2.Width
                .Picture2.Visible = True
                .cmdCalcMant6.Top = .PagCalcFonda.Height - .cmdCalcMant6.Height
                .cmdCalcMant6.Left = .PagCalcFonda.Width - .cmdCalcMant6.Width
            End With
            Call LeggiRoark()
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub

    Public Sub AggFondaPagina()
        Dim j, i, k As Short
        Try
            With frmSaddles.DefInstance
                .Text61(1).Text = GlobalRoutines.myStr(xFondaItem(iSadd).a, 5, 2, 0)
                .Text61(2).Text = GlobalRoutines.myStr(xFondaItem(iSadd).b, 5, 2, 0)
                .Text61(3).Text = GlobalRoutines.myStr(xFondaItem(iSadd).SP, 5, 2, 0)
                ' .Text61(4).Text = LTrim$(Str$(xFondaItem(iSadd).h,5,2,0)
                .Text61(4).Text = GlobalRoutines.myStr(xFondaItem(iSadd).A1, 5, 2, 0)
                .Text61(5).Text = GlobalRoutines.myStr(xFondaItem(iSadd).B1, 5, 2, 0)
                .Text61(6).Text = GlobalRoutines.myStr(CSng(xFondaItem(iSadd).nc), 3, 0, -1)
                .Text61(7).Text = GlobalRoutines.myStr(CSng(xFondaItem(iSadd).nt), 3, 0, -1)
                ' .Text61(9).Text = LTrim$(Str$(xFondaItem(iSadd).nb,5,2,0)
                .Text62(8).Text = xFondaItem(iSadd).BoltSize.Trim
                .Text61(9).Text = GlobalRoutines.myStr(xFondaItem(iSadd).ag, 5, 2, 0)
                .Text61(10).Text = GlobalRoutines.myStr(xFondaItem(iSadd).an, 5, 2, 0)
                .Text62(11).Text = xFondaItem(iSadd).BaseMat.Trim
                .Text61(12).Text = GlobalRoutines.myStr(xFondaData(iSadd, iCond).albp, 5, 2, 0)
                .Text62(13).Text = xFondaItem(iSadd).BoltMat.Trim
                .Text61(14).Text = GlobalRoutines.myStr(xFondaData(iSadd, iCond).alb, 5, 2, 0)
                .Text61(15).Text = GlobalRoutines.myStr(xFondaData(iSadd, iCond).albs, 5, 2, 0)
                .Text61(16).Text = GlobalRoutines.myStr(xFondaData(iSadd, iCond).alc, 5, 2, 0)
                .Text61(17).Text = GlobalRoutines.myStr(xFondaItem(iSadd).Rm, 5, 2, 0)
                .Text61(18).Text = GlobalRoutines.myStr(xFondaData(iSadd, iCond).n, 5, 2, 0)
                .Text61(19).Text = GlobalRoutines.myStr(xFondaData(iSadd, iCond).mx, 5, 2, 0)
                .Text61(20).Text = GlobalRoutines.myStr(xFondaData(iSadd, iCond).sfx, 5, 2, 0)
                .Text61(21).Text = GlobalRoutines.myStr(xFondaData(iSadd, iCond).my, 5, 2, 0)
                .Text61(22).Text = GlobalRoutines.myStr(xFondaData(iSadd, iCond).sfy, 5, 2, 0)
                .Combo62(0).SelectedIndex = iCond
                .Combo62(23).SelectedIndex = iSadd - 1
                .Check2.Visible = False
                For i = 1 To xFondaItem(iSadd).nt
                    For k = 1 To 2
                        j = CShort(25 + 2 * (i - 1) + k - 1)
                        If mioContr3(j) Is Nothing Then
                            .Label61.Load(j) : .Label61(j).Text = "Bullone" & Str(i)
                            .Text61.Load(j) : mioContr3(j) = .Text61(j)
                        End If
                    Next
                Next
                Do
                    For k = 1 To 2
                        j = CShort(25 + 2 * (i - 1) + k - 1)
                        If Not mioContr3(j) Is Nothing Then
                            .Label1(j).Visible = False
                            .Text61(j).Visible = False
                            .Label1.UnLoad(j)
                            .Text61.UnLoad(j)
                            mioContr3(j) = Nothing
                        Else
                            Exit Do
                        End If
                    Next
                    i = CShort(i + 1)
                Loop
                For i = 1 To xFondaItem(iSadd).nt
                    For k = 1 To 2
                        j = CShort(25 + 2 * (i - 1) + k - 1)
                        If k = 1 Then
                            .Text61(j).Text = GlobalRoutines.myStr(xFondaItem(iSadd).xQuota(i), 5, 2, 0)
                        Else
                            .Text61(j).Text = GlobalRoutines.myStr(xFondaItem(iSadd).yQuota(i), 5, 2, 0)
                        End If
                    Next
                Next
                For i = 1 To xFondaItem(iSadd).nt
                    For k = 1 To 2
                        j = CShort(25 + 2 * (i - 1) + k - 1)
                        .Label61(j).Width = CInt(GlobalRoutines.TwipsToPixelsX(1065))
                        .Label61(j).Left = mioContr3(i + 2).Left + mioContr3(i + 2).Width
                        .Label61(j).Top = .Label61(i + 2).Top
                        If k = 1 Then
                            .Label61(j).BringToFront() : .Label61(j).Visible = True
                            .Label61(j).Enabled = True
                            .Text61(j).Top = .Label61(j).Top
                            .Text61(j).Left = .Label61(j).Left + .Label61(j).Width
                        Else
                            .Label61(j).Visible = False
                            .Text61(j).Top = .Label61(j).Top
                            .Text61(j).Left = .Text61(j - 1).Left + .Text61(j - 1).Width
                        End If
                        .Text61(j).Visible = True : .Text61(j).Enabled = True
                    Next
                Next
                If iSadd = 2 Then
                    .Check2.Visible = True
                    j = CShort(25 + 2 * (xFondaItem(iSadd).nt - 1))
                    .Check2.Top = .Label61(j).Top + .Label61(j).Height
                    .Check2.Left = .Label61(j).Left
                    If xFondaItem(2).Inchiavard Then .Check2.CheckState = System.Windows.Forms.CheckState.Checked Else .Check2.CheckState = System.Windows.Forms.CheckState.Unchecked
                End If
                Ncontr = CShort(25 + (xFondaItem(iSadd).nt - 1) * 2 + 1)
            End With
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Public Sub AggQuartaPagina()
        Dim i As Integer
        With frmSaddles.DefInstance
            For i = 24 To 25
                If SaddlesItem.GeomSadd(i - 23).SupRing Then
                    .Check1(i).Checked = True
                Else
                    .Check1(i).Checked = False
                End If
            Next
            .Text41(0).Text = GlobalRoutines.myStr(SaddlesItem.Diam, 5, 2, 0)
            For i = 1 To 3
                .Text41(i).Text = GlobalRoutines.myStr(SaddlesItem.Spess(i - 1), 5, 2, 0)
            Next
            For i = 4 To 6
                .Text41(i).Text = GlobalRoutines.myStr(SaddlesItem.Lungh(i - 4), 5, 2, 0)
            Next
            For i = 7 To 8
                .Text41(i).Text = GlobalRoutines.myStr(SaddlesItem.GeomSadd(i - 6).AxialWidth, 5, 2, 0)
            Next
            For i = 9 To 10
                .Text41(i).Text = GlobalRoutines.myStr(SaddlesItem.GeomSadd(i - 8).IncluAngle, 5, 2, 0)
            Next
            For i = 11 To 12
                .Text41(i).Text = GlobalRoutines.myStr(SaddlesItem.GeomSadd(i - 10).PlateWidth, 5, 2, 0)
            Next
            For i = 13 To 14
                .Text41(i).Text = GlobalRoutines.myStr(SaddlesItem.GeomSadd(i - 12).PlateAngle, 5, 2, 0)
            Next
            For i = 15 To 16
                .Text41(i).Text = GlobalRoutines.myStr(SaddlesItem.GeomSadd(i - 14).PlateThk, 5, 2, 0)
            Next
            For i = 17 To 18
                .Text41(i).Text = GlobalRoutines.myStr(SaddlesItem.GeomSadd(i - 16).SaddlThk, 5, 2, 0)
            Next
            For i = 19 To 20
                .Text41(i).Text = GlobalRoutines.myStr(SaddlesItem.GeomSadd(i - 18).SaddHeight, 5, 2, 0)
            Next
            For i = 21 To 22
                .Text41(i).Text = GlobalRoutines.myStr(SaddlesItem.SpessHead(i - 20), 5, 2, 0)
            Next
            For i = 26 To 27
                .Text41(i).Text = GlobalRoutines.myStr(SaddlesItem.GeomSadd(i - 25).Ix, 5, 2, 0)
            Next
            For i = 28 To 29
                .Text41(i).Text = GlobalRoutines.myStr(SaddlesItem.GeomSadd(i - 27).rCrown, 5, 2, 0)
            Next
            For i = 30 To 31
                .Text41(i).Text = GlobalRoutines.myStr(SaddlesItem.GeomSadd(i - 29).rBottom, 5, 2, 0)
            Next
            For i = 32 To 33
                .Text41(i).Text = GlobalRoutines.myStr(SaddlesItem.GeomSadd(i - 31).Ax, 5, 2, 0)
            Next
            For i = 21 To 23
                If (i = 21 Or i = 22) Then
                    If SaddlesItem.TipoChius(i - 20) = 0 Then
                        mioContr1(i).Enabled = False
                        .Label41(i).Enabled = False
                        .Label42(i).Enabled = False
                        SaddlesItem.SpessHead(i - 20) = 0
                        .Text41(i).Text = "0"
                    End If
                End If
                If i = 23 And SaddlesItem.TipoChius(1) >= 1 And SaddlesItem.TipoChius(2) >= 1 Then
                    mioContr1(i).Enabled = False
                    .Label41(i).Enabled = False
                    .Label42(i).Enabled = False
                    SaddlesItem.HeadHeight = 0
                End If
            Next
            If SaddlesItem.Simple = "N" Then
                mioContr1(23).Enabled = False
                .Label41(23).Enabled = False
                .Label42(23).Enabled = False
                SaddlesItem.HeadHeight = 0
            End If
        End With
    End Sub
    Public Sub AggQuartaPaginaT()
        Dim i As Integer
        With frmSaddles.DefInstance
            For i = 24 To 25
                If SaddlesItem.GeomSadd(i - 23).SupRing Then
                    .Check1T(i).Checked = True
                Else
                    .Check1T(i).Checked = False
                End If
            Next
            .Text41T(0).Text = GlobalRoutines.myStr(SaddlesItemT.Diam, 5, 2, 0)
            For i = 1 To 3
                .Text41T(i).Text = GlobalRoutines.myStr(SaddlesItemT.Spess(i - 1), 5, 2, 0)
            Next
            For i = 4 To 6
                .Text41T(i).Text = GlobalRoutines.myStr(SaddlesItemT.Lungh(i - 4), 5, 2, 0)
            Next
            For i = 7 To 8
                .Text41T(i).Text = GlobalRoutines.myStr(SaddlesItemT.GeomSadd(i - 6).AxialWidth, 5, 2, 0)
            Next
            For i = 9 To 10
                .Text41T(i).Text = GlobalRoutines.myStr(SaddlesItemT.GeomSadd(i - 8).IncluAngle, 5, 2, 0)
            Next
            For i = 11 To 12
                .Text41T(i).Text = GlobalRoutines.myStr(SaddlesItemT.GeomSadd(i - 10).PlateWidth, 5, 2, 0)
            Next
            For i = 13 To 14
                .Text41T(i).Text = GlobalRoutines.myStr(SaddlesItemT.GeomSadd(i - 12).PlateAngle, 5, 2, 0)
            Next
            For i = 15 To 16
                .Text41T(i).Text = GlobalRoutines.myStr(SaddlesItemT.GeomSadd(i - 14).PlateThk, 5, 2, 0)
            Next
            For i = 17 To 18
                .Text41T(i).Text = GlobalRoutines.myStr(SaddlesItemT.GeomSadd(i - 16).SaddlThk, 5, 2, 0)
            Next
            For i = 19 To 20
                .Text41T(i).Text = GlobalRoutines.myStr(SaddlesItemT.GeomSadd(i - 18).SaddHeight, 5, 2, 0)
            Next
            For i = 21 To 22
                .Text41T(i).Text = GlobalRoutines.myStr(SaddlesItemT.SpessHead(i - 20), 5, 2, 0)
            Next
            For i = 26 To 27
                .Text41T(i).Text = GlobalRoutines.myStr(SaddlesItemT.GeomSadd(i - 25).Ix, 5, 2, 0)
            Next
            For i = 28 To 29
                .Text41T(i).Text = GlobalRoutines.myStr(SaddlesItemT.GeomSadd(i - 27).rCrown, 5, 2, 0)
            Next
            For i = 30 To 31
                .Text41T(i).Text = GlobalRoutines.myStr(SaddlesItemT.GeomSadd(i - 29).rBottom, 5, 2, 0)
            Next
            For i = 32 To 33
                .Text41T(i).Text = GlobalRoutines.myStr(SaddlesItemT.GeomSadd(i - 31).Ax, 5, 2, 0)
            Next
            For i = 21 To 23
                If (i = 21 Or i = 22) Then
                    If SaddlesItemT.TipoChius(i - 20) = 0 Then
                        mioContr1T(i).Enabled = False
                        .Label41T(i).Enabled = False
                        .Label42T(i).Enabled = False
                        SaddlesItemT.SpessHead(i - 20) = 0
                        .Text41T(i).Text = "0"
                    End If
                End If
                If i = 23 And SaddlesItemT.TipoChius(1) >= 1 And SaddlesItemT.TipoChius(2) >= 1 Then
                    mioContr1T(i).Enabled = False
                    .Label41T(i).Enabled = False
                    .Label42T(i).Enabled = False
                    SaddlesItemT.HeadHeight = 0
                End If
            Next
            If SaddlesItemT.Simple = "N" Then
                mioContr1T(23).Enabled = False
                .Label41T(23).Enabled = False
                .Label42T(23).Enabled = False
                SaddlesItemT.HeadHeight = 0
            End If
        End With
    End Sub
    Public Sub AggSaddlesPagina()
        Dim i As Short
        If Inizializzando Then Exit Sub
        Try
            If MatShell Is Nothing Then
                MatShell = New LibMat.MaterialeNew1
            End If
            MatShell.Indmat = CShort(SaddlesItem.IndMatShell)
            If MatShell.Indmat > 0 Then MatShell.RecupMat(Monitor.Motore.Inizio.Archdir.Trim)
            With frmSaddles.DefInstance
                .Text1(1).Text = GlobalRoutines.myStr(SaddlesLoad(iCond).DesPress, 5, 2, 0)
                .Text1(2).Text = GlobalRoutines.myStr(SaddlesLoad(iCond).DesTemp, 5, 2, 0)
                .Text1(3).Text = GlobalRoutines.myStr(SaddlesLoad(iCond).PesoTot, 5, 2, 0)
                .Text1(4).Text = GlobalRoutines.myStr(SaddlesLoad(iCond).PesoS(1), 5, 2, 0)
                .Text1(5).Text = GlobalRoutines.myStr(SaddlesLoad(iCond).PesoS(2), 5, 2, 0)
                .Text1(6).Text = GlobalRoutines.myStr(SaddlesLoad(iCond).MomS(1), 5, 2, 0)
                .Text1(7).Text = GlobalRoutines.myStr(SaddlesLoad(iCond).MomS(2), 5, 2, 0)
                For i = 11 To 13
                    .Text1(i).Text = GlobalRoutines.myStr(SaddlesLoad(iCond).AmmShell(i - 11), 5, 2, 0)
                Next
                For i = 14 To 16
                    .Text1(i).Text = GlobalRoutines.myStr(SaddlesLoad(iCond).Young(i - 14), 5, 2, 0)
                Next
                For i = 17 To 18
                    .Text1(i).Text = GlobalRoutines.myStr(SaddlesLoad(iCond).AmmSadd(i - 16), 5, 2, 0)
                Next
                .Text1(19).Text = GlobalRoutines.myStr(SaddlesLoad(iCond).AmmHead(1), 5, 2, 0)
                .Text1(20).Text = GlobalRoutines.myStr(SaddlesLoad(iCond).AmmHeadTens(1), 5, 2, 0)
                .Text1(21).Text = GlobalRoutines.myStr(SaddlesLoad(iCond).AmmHead(2), 5, 2, 0)
                .Text1(22).Text = GlobalRoutines.myStr(SaddlesLoad(iCond).AmmHeadTens(2), 5, 2, 0)
                If MatShell.Indmat > 0 Then .Text1(29).Text = MatShell.MatStr
                .Check2.Visible = False
                If SaddlesItem.Simple = "Y" Then
                    .Combo2(0).SelectedIndex = 0
                Else
                    .Combo2(0).SelectedIndex = 1
                End If
                .Combo2(8).SelectedIndex = SaddlesItem.TipoChius(1)
                .Combo2(9).SelectedIndex = SaddlesItem.TipoChius(2)
                .Combo2(28).Tag = "-1"
                If iCond < .Combo2(28).Items.Count Then .Combo2(28).SelectedIndex = iCond
                .Combo2(28).Tag = "0"
            End With
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Public Sub AggSaddlesPaginaT()
        Dim i As Short
        If Inizializzando Then Exit Sub
        Try
            If MatShellT Is Nothing Then
                MatShellT = New LibMat.MaterialeNew1
            End If
            MatShellT.Indmat = CShort(SaddlesItemT.IndMatShell)
            If MatShellT.Indmat > 0 Then MatShellT.RecupMat(Monitor.Motore.Inizio.Archdir.Trim)
            With frmSaddles.DefInstance
                .Text1T(1).Text = GlobalRoutines.myStr(SaddlesLoadT(iCond).DesPress, 5, 2, 0)
                .Text1T(2).Text = GlobalRoutines.myStr(SaddlesLoadT(iCond).DesTemp, 5, 2, 0)
                .Text1T(3).Text = GlobalRoutines.myStr(SaddlesLoadT(iCond).PesoTot, 5, 2, 0)
                .Text1T(4).Text = GlobalRoutines.myStr(SaddlesLoadT(iCond).PesoS(1), 5, 2, 0)
                .Text1T(5).Text = GlobalRoutines.myStr(SaddlesLoadT(iCond).PesoS(2), 5, 2, 0)
                .Text1T(6).Text = GlobalRoutines.myStr(SaddlesLoadT(iCond).MomS(1), 5, 2, 0)
                .Text1T(7).Text = GlobalRoutines.myStr(SaddlesLoadT(iCond).MomS(2), 5, 2, 0)
                For i = 11 To 13
                    .Text1T(i).Text = GlobalRoutines.myStr(SaddlesLoadT(iCond).AmmShell(i - 11), 5, 2, 0)
                Next
                For i = 14 To 16
                    .Text1T(i).Text = GlobalRoutines.myStr(SaddlesLoadT(iCond).Young(i - 14), 5, 2, 0)
                Next
                For i = 17 To 18
                    .Text1T(i).Text = GlobalRoutines.myStr(SaddlesLoadT(iCond).AmmSadd(i - 16), 5, 2, 0)
                Next
                .Text1T(19).Text = GlobalRoutines.myStr(SaddlesLoadT(iCond).AmmHead(1), 5, 2, 0)
                .Text1T(20).Text = GlobalRoutines.myStr(SaddlesLoadT(iCond).AmmHeadTens(1), 5, 2, 0)
                .Text1T(21).Text = GlobalRoutines.myStr(SaddlesLoadT(iCond).AmmHead(2), 5, 2, 0)
                .Text1T(22).Text = GlobalRoutines.myStr(SaddlesLoadT(iCond).AmmHeadTens(2), 5, 2, 0)
                If MatShellT.Indmat > 0 Then .Text1T(29).Text = MatShell.MatStr
                '.Check2T.Visible = False
                If SaddlesItemT.Simple = "Y" Then
                    .Combo2T(0).SelectedIndex = 0
                Else
                    .Combo2T(0).SelectedIndex = 1
                End If
                .Combo2T(8).SelectedIndex = SaddlesItemT.TipoChius(1)
                .Combo2T(9).SelectedIndex = SaddlesItemT.TipoChius(2)
                .Combo2T(28).Tag = "-1"
                If iCond < .Combo2T(28).Items.Count Then .Combo2T(28).SelectedIndex = iCond
                .Combo2T(28).Tag = "0"
            End With
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Public Sub AggRedim()
        Dim i, j As Integer
        ReDim Preserve AreaLav(Problem.NCond(1))
        ReDim Preserve SaddlesLoad(Problem.NCond(1))
        ReDim Preserve AreaLavT(Problem.NCond(1))
        ReDim Preserve SaddlesLoadT(Problem.NCond(1))
        For i = 0 To Problem.NCond(1)
            If AreaLav(i) Is Nothing Then AreaLav(i) = New typAreaLav
            If SaddlesLoad(i) Is Nothing Then SaddlesLoad(i) = New typSaddlesLoad
            If AreaLavT(i) Is Nothing Then AreaLavT(i) = New typAreaLav
            If SaddlesLoadT(i) Is Nothing Then SaddlesLoadT(i) = New typSaddlesLoad
        Next
        ReDim Preserve xSupport(2)
        ReDim Preserve xSupportData(2, Problem.NCond(2))
        ReDim Preserve xSupportResult(2, Problem.NCond(2))
        ReDim Preserve xFondaItem(2)
        ReDim Preserve xSupportDataT(2, Problem.NCond(2))
        ReDim Preserve xSupportResultT(2, Problem.NCond(2))
        ReDim Preserve xFondaData(2, Problem.NCond(3))
        For j = 0 To 2
            For i = 0 To Problem.NCond(2)
                If xSupportData(j, i) Is Nothing Then xSupportData(j, i) = New typxSupportData
                If xSupportDataT(j, i) Is Nothing Then xSupportDataT(j, i) = New typxSupportData
                If xSupportResult(j, i) Is Nothing Then xSupportResult(j, i) = New typxSupportResult
                If xSupportResultT(j, i) Is Nothing Then xSupportResultT(j, i) = New typxSupportResult
            Next
            For i = 0 To Problem.NCond(3)
                If xFondaData(j, i) Is Nothing Then xFondaData(j, i) = New typxFondaData
            Next
        Next
        ReDim FinalComment(Problem.NCond(3), 2)
        SaddlesLoad.Initialize()
        SaddlesLoadT.Initialize()
    End Sub

    Public Sub FactMiddle(ByRef SIGMAT As Single, ByRef SIGMAC As Single, ByRef Factor As Single, ByVal iBtmTop As Short)
        Dim k As Short
        Dim Facto1 As Single
        SIGMAC = 1.0E+20 : SIGMAT = -1.0E+20
        With pAreaLav(iCond, iBtmTop).TensMiddle
            If Problem.Codice = 0 Then
                For k = 0 To 1
                    If .F1PS(k) > SIGMAT Then SIGMAT = .F1PS(k)
                    If .F2PS(k) > SIGMAT Then SIGMAT = .F2PS(k)
                    If .F1NG(k) > SIGMAT Then SIGMAT = .F1NG(k)
                    If .F2NG(k) > SIGMAT Then SIGMAT = .F2NG(k)
                    If .F1PS(k) < SIGMAC Then SIGMAC = .F1PS(k)
                    If .F2PS(k) < SIGMAC Then SIGMAC = .F2PS(k)
                    If .F1NG(k) < SIGMAC Then SIGMAC = .F1NG(k)
                    If .F2NG(k) < SIGMAC Then SIGMAC = .F2NG(k)
                Next
            Else
                SIGMAC = 0
                SIGMAT = .F2PS(1)
                If .F2NG(1) > SIGMAT Then SIGMAT = .F2NG(1)
            End If
        End With
        If SIGMAC > 0 Then SIGMAC = 0
        If SIGMAT < 0 Then SIGMAT = 0
        SIGMAC = -SIGMAC
        Factor = SIGMAT / pSaddlesLoad(iCond, iBtmTop).AmmShell(0 + 2 * Problem.Codice)
        If Problem.Codice = 0 Then Facto1 = SIGMAC / pAreaLav(iCond, iBtmTop).FALC(0)
        If Facto1 > Factor Then Factor = Facto1
    End Sub

    Public Sub FactSaddle(ByRef SIGMAC As Single, ByRef SIGMAT As Single, ByRef Factor As Single, _
                          ByVal iBtmTop As Short)
        Dim k As Short
        Dim Facto1, Fact As Single
        Dim iSadd1 As Short
        SIGMAC = 1.0E+20 : SIGMAT = -1.0E+20
        With pAreaLav(iCond, iBtmTop).TensSaddle
            If Problem.Codice = 0 Then
                Fact = 1 : iSadd1 = iSadd
                For k = 0 To 1
9380:               If .F3(iSadd, k) > SIGMAT Then SIGMAT = .F3(iSadd, k)
                    If .F4(iSadd, k) > SIGMAT Then SIGMAT = .F4(iSadd, k)
                    If .F3(iSadd, k) < SIGMAC Then SIGMAC = .F3(iSadd, k)
                    If .F4(iSadd, k) < SIGMAC Then SIGMAC = .F4(iSadd, k)
                Next
            Else
                iSadd1 = 2
                SIGMAT = .F3(iSadd, 0) + .F4(iSadd, 0)
                If .F3(iSadd, 1) + .F4(iSadd, 1) > SIGMAT Then SIGMAT = .F3(iSadd, 1) + .F4(iSadd, 1)
                SIGMAC = 0
                Fact = 1.5
            End If
        End With
        If SIGMAC > 0 Then SIGMAC = 0
        If SIGMAT < 0 Then SIGMAT = 0
        SIGMAC = -SIGMAC
        Factor = SIGMAT / pSaddlesLoad(iCond, iBtmTop).AmmShell(iSadd1) / Fact
        If Problem.Codice = 0 Then Facto1 = SIGMAC / pAreaLav(iCond, iBtmTop).FALC(iSadd)
        If Facto1 > Factor Then Factor = Facto1
    End Sub

    Public Sub FactShear(ByRef Factor As Single, ByVal iBtmTop As Short)
        On Error GoTo ErrFS
        Dim Facto1 As Single
        Dim Msgg As String
        If Problem.Codice = 0 Then
            Factor = System.Math.Abs(pAreaLav(iCond, iBtmTop).ShearSaddle.SQ(iSadd) / pAreaLav(iCond, iBtmTop).ShearSaddle.TANGS(iSadd))
            If SaddlesItem.TipoChius(iSadd) >= 1 Then
                Facto1 = System.Math.Abs(pAreaLav(iCond, iBtmTop).ShearSaddle.SQE(iSadd) / pAreaLav(iCond, iBtmTop).ShearSaddle.TANGH(iSadd))
                If Facto1 > Factor Then Factor = Facto1
            End If
        Else
            Factor = CSng(pAreaLav(iCond, iBtmTop).ShearSaddle.SQ(iSadd) / (0.8 * pSaddlesLoad(iCond, iBtmTop).AmmShell(2)))
        End If
ES:     On Error GoTo 0
        Exit Sub
ErrFS:
        Msgg = "Ci sono probabilmente dei dati mancanti relativamente aggli ammissibili"
        MsgBox(Msgg, MsgBoxStyle.Exclamation Or MsgBoxStyle.OKOnly)
        Factor = 0
        Resume ES
    End Sub

    Public Sub FactCircum(ByRef Factor As Single, ByVal iBtmTop As Short)
        Dim Facto1 As Single
        If Problem.Codice = 1 Then
            Factor = System.Math.Abs(pAreaLav(iCond, iBtmTop).CircSaddle.F5(iSadd) / pSaddlesLoad(iCond, iBtmTop).AmmShell(2))
            Exit Sub
        End If
10960:  If pSaddlesItem(iBtmTop).GeomSadd(iSadd).PlateWidth < pAreaLav(iCond, iBtmTop).CircSaddle.b2(iSadd) Or pSaddlesItem(iBtmTop).GeomSadd(iSadd).PlateAngle < pAreaLav(iCond, iBtmTop).CircSaddle.ZETS(iSadd) Then
            Factor = System.Math.Abs(pAreaLav(iCond, iBtmTop).CircSaddle.F5(iSadd) / pSaddlesLoad(iCond, iBtmTop).AmmShell(iSadd))
            Facto1 = CSng(System.Math.Abs(pAreaLav(iCond, iBtmTop).CircSaddle.F6(iSadd) / (1.25 * pSaddlesLoad(iCond, iBtmTop).AmmShell(iSadd))))
            If Facto1 > Factor Then Factor = Facto1
        Else
            Factor = CSng(System.Math.Abs(pAreaLav(iCond, iBtmTop).CircSaddle.F6S(iSadd) / (1.25 * pSaddlesLoad(iCond, iBtmTop).AmmShell(iSadd))))
        End If 'GoSub Stamp1 Else GoSub Stamp2
    End Sub
    Public Sub FactDesign(ByRef Factor As Single, ByVal iBtmTop As Short)
        Dim FALLS1, Facto1 As Single
        If Problem.Codice = 0 Then
            FALLS1 = CSng(2 / 3 * pSaddlesLoad(iCond, iBtmTop).AmmSadd(iSadd))
            Factor = System.Math.Abs(pAreaLav(iCond, iBtmTop).SadDesign.FSD(iSadd)) / FALLS1
        Else
            Factor = System.Math.Abs(pAreaLav(iCond, iBtmTop).SadDesign.FSD(iSadd)) / pSaddlesLoad(iCond, iBtmTop).AmmShell(iSadd) / 2
            Facto1 = CSng(System.Math.Abs(pAreaLav(iCond, iBtmTop).SadDesign.Pz(iSadd)) / 7.5)
            If Facto1 > Factor Then Factor = Facto1
        End If
    End Sub
    Public Sub DispCond(ByRef iContr As arrCombo, ByRef iCalc As Short)
        Dim i As Short
        Try
            With frmSaddles.DefInstance
                iContr.Items.Clear()
                If LoadsCalcolate Then
                    For i = 0 To 7
                        If Not Problem.LoadCond(iCalc, i + 1) Is Nothing Then _
                        If Problem.LoadCond(iCalc, i + 1).Trim.Length > 0 Then _
                        iContr.Items.Add(Problem.LoadCond(iCalc, i + 1).Trim)
                    Next
                Else
                    For i = 0 To CShort(Problem.NCond(iCalc) - 1)
                        If iCalc > 1 Or Problem.Codice = 0 Then
                            If Problem.LoadCond(iCalc, i + 1) Is Nothing Then Problem.LoadCond(iCalc, i + 1) = ""
                            If Problem.LoadCond(1, i + 1) Is Nothing Then Problem.LoadCond(1, i + 1) = ""
                            If Problem.LoadCond(1, i + 1).Trim.Length = 0 Then Problem.LoadCond(1, i + 1) = "Senza Nome"
                        End If
                        iContr.Items.Add(Problem.LoadCond(iCalc, i + 1).Trim)
                    Next
                End If
            End With
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Public Sub DispCondT(ByRef iContr As arrCombo, ByRef iCalc As Short)
        Dim i As Short
        Try
            With frmSaddles.DefInstance
                iContr.Items.Clear()
                If LoadsCalcolate Then
                    For i = 0 To 7
                        If Not Problem.LoadCond(iCalc, i + 1) Is Nothing Then _
                        If Problem.LoadCond(iCalc, i + 1).Trim.Length > 0 Then _
                        iContr.Items.Add(Problem.LoadCond(iCalc, i + 1).Trim)
                    Next
                Else
                    For i = 0 To CShort(Problem.NCond(iCalc) - 1)
                        If iCalc > 1 Or Problem.Codice = 0 Then
                            If Problem.LoadCond(iCalc, i + 1) Is Nothing Then Problem.LoadCond(iCalc, i + 1) = ""
                            If Problem.LoadCond(1, i + 1) Is Nothing Then Problem.LoadCond(1, i + 1) = ""
                            If Problem.LoadCond(1, i + 1).Trim.Length = 0 Then Problem.LoadCond(1, i + 1) = "Senza Nome"
                        End If
                        iContr.Items.Add(Problem.LoadCond(iCalc, i + 1).Trim)
                    Next
                End If
            End With
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Public Sub StLoadC(ByRef ii As Short)
        Dim i As Short
        If Problem.NCond(ii) > 1 Then
            Monitor.Motore.Problem.Printa("Specified loading cases:" & Par)
            For i = 0 To CShort(Problem.NCond(ii) - 1)
                Monitor.Motore.Problem.Printa(Space(20) & Str(i + 1) & ") " & Problem.LoadCond(ii, i + 1) & Par)
            Next
        End If
6780:   Monitor.Motore.Problem.Printa("Loading case            " & RTrim(Problem.LoadCond(ii, iCond + 1)) & Par)
        If Not Monitor.Motore.Problem.StampaTutto = 1 Then
            Monitor.Motore.Problem.Printa("    Note: This case is the most severe among the" & Str(Problem.NCond(ii)) & " cases analyzed." & Par)
        End If
    End Sub

    Public Sub StoomAux(ByRef Mode As Short, ByVal iBtmTop As Short)
        Dim b As Single
        Dim a(15) As Single
        Dim Num, Den As Single
        Dim l2, R, Alfa As Single
        Dim i As Short
        Dim Delta As Single
        For i = 1 To 2
            R = pSaddlesItem(iBtmTop).Diam / 2
            l2 = pSaddlesItem(iBtmTop).Lungh(i)
            If Mode = 1 Then
                b = CSng(Math.PI - Math.PI / 180 * pSaddlesItem(iBtmTop).GeomSadd(i).IncluAngle / 2)
            Else
                b = CSng(Math.PI - Math.PI / 180 * pSaddlesItem(iBtmTop).GeomSadd(i).PlateAngle / 2)
            End If
            If b < Math.PI / 2 Then b = Math.PI / 2
            Alfa = CSng(0.95 * b)
            Delta = CSng(-8.0379 + 12.021 * b - 5.0831 * b * b + 0.73932 * b * b * b)
            a(3) = CSng(System.Math.Sin(Alfa) / (Math.PI - Alfa + System.Math.Sin(Alfa) * System.Math.Cos(Alfa)))
            a(4) = CSng(System.Math.Sin(Alfa) / Math.PI * (Alfa - System.Math.Sin(Alfa) * System.Math.Cos(Alfa)) / (Math.PI - Alfa + System.Math.Sin(Alfa) * System.Math.Cos(Alfa)))
            a(5) = CSng(0.375 * System.Math.Sin(Alfa) ^ 2 / (Math.PI - Alfa + System.Math.Sin(Alfa) * System.Math.Cos(Alfa)))
            a(6) = CSng((1 + System.Math.Cos(Alfa)) / (Alfa - Math.PI - System.Math.Sin(Alfa) * System.Math.Cos(Alfa)))
            Num = CSng(b * b + 2 * b * b * System.Math.Cos(b) * System.Math.Cos(b) - 3 * b * System.Math.Sin(b) * System.Math.Cos(b))
            Den = CSng(b * b + b * System.Math.Sin(b) * System.Math.Cos(b) - 2 * System.Math.Sin(b) * System.Math.Sin(b))
            a(7) = CSng((2 * b * System.Math.Sin(b) + (System.Math.Cos(b) - System.Math.Sin(b) / b) * Num / Den) / 4 / Math.PI)
            a(8) = CSng(1 / 4 / Math.PI * (2 * Delta * System.Math.Sin(Delta) + (3 + 2 * (Math.PI - b) / System.Math.Tan(b)) * System.Math.Cos(Delta) - 2 * (Math.PI - b) / System.Math.Sin(b)))
            Num = CSng(System.Math.Cos(b) * (4 * b * b - b * b * System.Math.Cos(2 * b) + 9 * b * System.Math.Sin(b) * System.Math.Cos(b) - 12 * System.Math.Sin(b) ^ 2))
            Den = CSng(4 * System.Math.Sin(b) ^ 2 - 2 * b * b - b * System.Math.Sin(2 * b))
            a(9) = CSng(1 / 2 / Math.PI * (Num / Den + b * System.Math.Sin(b)))
            a(10) = CSng(1 / 2 / Math.PI * (((Math.PI - b) / System.Math.Tan(b) - 0.5) * System.Math.Cos(Delta) + Delta * System.Math.Sin(Delta)))
            a(11) = CSng((1 + System.Math.Cos(b) - 0.5 * System.Math.Sin(b) ^ 2) / (Math.PI - b + System.Math.Sin(b) * System.Math.Cos(b)))
            a(14) = (a(3) - a(4)) * (2 * l2 - R) / R + a(4)
            a(15) = CSng(-0.75 * a(7) * (2 * l2 - R) / R - 0.25 * a(7))
            a(11) = CSng((1 + System.Math.Cos(b) - 0.5 * System.Math.Sin(b) * System.Math.Sin(b)) / (Math.PI - b + System.Math.Sin(b) * System.Math.Cos(b)))
            kSt(5, i) = a(6)
            kSt(8, i) = a(11)
            If l2 <= R / 2 Then
                kSt(2, i) = a(4)
                kSt(3, i) = -a(7) / 4
                kSt(4, i) = a(5)
            ElseIf l2 > R Then
                kSt(2, i) = a(3)
                kSt(3, i) = -a(7)
                kSt(4, i) = 0
            Else
                kSt(2, i) = a(14)
                kSt(3, i) = a(15)
                kSt(4, i) = 0
            End If
            kSt(6, i) = a(7)
            kSt(7, i) = a(9)
        Next
    End Sub

    Public Sub StSaddlesCalc(ByVal iBtmTop As Short)
        Dim Mode As Short
        For iSadd = 1 To 2
            If Not pSaddlesItem(iBtmTop).GeomSadd(iSadd).SupRing Then
                Mode = 1
                StoomAux(Mode, iBtmTop)
                Calcolo(Mode, iBtmTop)
                If pSaddlesItem(iBtmTop).GeomSadd(iSadd).PlateThk > 0 And pSaddlesItem(iBtmTop).GeomSadd(iSadd).PlateAngle < 180 Then
                    Mode = 2
                    StoomAux(Mode, iBtmTop)
                    Calcolo(Mode, iBtmTop)
                Else
                    pAreaLav(iCond, iBtmTop).TensSaddle.F3(iSadd, 1) = 0
                    pAreaLav(iCond, iBtmTop).TensSaddle.F4(iSadd, 1) = 0
                End If
            Else
                pAreaLav(iCond, iBtmTop).TensSaddle.F3(iSadd, 1) = 0
                pAreaLav(iCond, iBtmTop).TensSaddle.F4(iSadd, 1) = 0
            End If
        Next
        StoomAux(1, iBtmTop)
        Exit Sub
    End Sub
    Private Sub Calcolo(ByVal Mode As Integer, ByVal iBtmTop As Short)
        With pAreaLav(iCond, iBtmTop).TensSaddle
            Select Case iCond
                Case 1, 3
                    l2 = pSaddlesItem(iBtmTop).Lungh(iSadd)
                    b = pSaddlesItem(iBtmTop).GeomSadd(iSadd).AxialWidth
                    cs = 1 - (b - 300) / l2
                    If cs > 1 Then cs = 1
                    If cs < 0.4 Then cs = 0.4
                    .k2(iSadd, 0) = cs
                    d = pSaddlesItem(iBtmTop).Spess(iSadd)
                    If Mode = 1 Then
                        d1 = pSaddlesItem(iBtmTop).GeomSadd(iSadd).PlateThk
                    Else
                        d1 = 0
                    End If
                    R = pSaddlesItem(iBtmTop).MeanR(iSadd)
                    be = 4 * R
                    If pSaddlesItem(iBtmTop).LT / 2 < be Then be = pSaddlesItem(iBtmTop).LT / 2
                    f = pAreaLav(iCond, iBtmTop).React(iSadd)
                    .K1(iSadd, Mode - 1) = kSt(3, iSadd)
                    .F3(iSadd, Mode - 1) = CSng(cs * f / (4 * (d + d1) * (b + 1.6 * System.Math.Sqrt(R * d)))) 'sigma tg,m
                    .F4(iSadd, Mode - 1) = cs * .K1(iSadd, Mode - 1) * 6 * f * R / be / (d * d + d1 * d1)
                Case 0, 2
                    .F3(iSadd, Mode - 1) = 0
                    .F4(iSadd, Mode - 1) = 0
            End Select
        End With
    End Sub
    Public Sub CompressBott(ByVal iBtmTop As Short)
        Dim d1, d, f As Single
        Dim b, R As Single
        R = pSaddlesItem(iBtmTop).MeanR(iSadd)
        d = pSaddlesItem(iBtmTop).Spess(iSadd)
        d1 = pSaddlesItem(iBtmTop).GeomSadd(iSadd).PlateThk
        b = pSaddlesItem(iBtmTop).GeomSadd(iSadd).AxialWidth
        f = pAreaLav(iCond, iBtmTop).React(iSadd)
        With pAreaLav(iCond, iBtmTop).CircSaddle
            .K5(iSadd) = kSt(5, iSadd)
            .F5(iSadd) = CSng(.K5(iSadd) * f / (d + d1) / (b + 1.6 * System.Math.Sqrt(R * d)))
        End With
    End Sub

    Public Sub FactFondo(ByRef Factor As Single, ByVal iBtmTop As Short)
        Dim Fact, Facto1 As Single
        Fact = 1 : If iCond > 1 Then Fact = 1.33
        With pAreaLav(iCond, iBtmTop).CircSaddle
            Factor = CSng(.F6(iSadd) / 0.8 / pSaddlesLoad(iCond, iBtmTop).AmmHead(iSadd))
            Facto1 = .F6S(iSadd) / Fact / pSaddlesLoad(iCond, iBtmTop).AmmHead(iSadd)
            If Facto1 > Factor Then Factor = Facto1
        End With
    End Sub

    Public Sub StSadDes(ByVal iBtmTop As Short)
        Dim R, b, fi As Single
        Dim f, h As Single
        b = pSaddlesItem(iBtmTop).GeomSadd(iSadd).AxialWidth
        R = pSaddlesItem(iBtmTop).MeanR(iSadd)
        f = pAreaLav(iCond, iBtmTop).React(iSadd)
        fi = CSng(Math.PI / 180 * pSaddlesItem(iBtmTop).GeomSadd(iSadd).IncluAngle)
        With pAreaLav(iCond, iBtmTop).SadDesign
            .Pz(iSadd) = CSng(f / 2 / b / R / System.Math.Sin(fi / 2))
            .K9(iSadd) = kSt(8, iSadd)
            .h(iSadd) = .K9(iSadd) * f
            h = pSaddlesItem(iBtmTop).GeomSadd(iSadd).SaddHeight
            .HSD(iSadd) = R / 3
            If .HSD(iSadd) > h Then .HSD(iSadd) = h
            .FSD(iSadd) = .h(iSadd) / (pSaddlesItem(iBtmTop).GeomSadd(iSadd).SaddlThk * .HSD(iSadd))
        End With
    End Sub

    Public Sub StBuckling(ByVal iBtmTop As Short)
        Dim E, Min, sk As Single
        Dim d, R, Lim As Single
        R = pSaddlesItem(iBtmTop).MeanR(iSadd)
        d = pSaddlesItem(iBtmTop).Spess(iSadd)
        E = pSaddlesLoad(iCond, iBtmTop).Young(0)
        Min = 0
        With pAreaLav(iCond, iBtmTop).TensMiddle
            If .F1NG(0) < Min Then Min = .F1NG(0)
            If .F2NG(0) < Min Then Min = .F2NG(0)
            If .F1PS(0) < Min Then Min = .F1PS(0)
            If .F2PS(0) < Min Then Min = .F2PS(0)
            pAreaLav(iCond, iBtmTop).CircSaddle.b2(1) = Min
        End With
        If Min = 0 Then Exit Sub
        sk = CSng(E * 0.8 * (d / R) ^ 2 / (4.5 * d / R + 0.003))
        pAreaLav(iCond, iBtmTop).CircSaddle.b2(2) = sk
        If pAreaLav(iCond, iBtmTop).CircSaddle.b2(2) <= 1.5 * pSaddlesLoad(iCond, iBtmTop).AmmShell(0) Then
            Lim = CSng(0.33 * sk)
        ElseIf pAreaLav(iCond, iBtmTop).CircSaddle.b2(2) > 7.5 * pSaddlesLoad(iCond, iBtmTop).AmmShell(0) Then
            Lim = CSng(0.9 * pSaddlesLoad(iCond, iBtmTop).AmmShell(0))
        Else
            Lim = CSng(0.067 * sk + 0.4 * pSaddlesLoad(iCond, iBtmTop).AmmShell(0))
        End If
        pAreaLav(iCond, iBtmTop).CircSaddle.TT(1) = Lim
    End Sub

    Public Sub FactBuckling(ByRef Factor As Single, ByVal iBtmTop As Short)
        Factor = 0
        If pAreaLav(iCond, iBtmTop).CircSaddle.b2(1) = 0 Then Exit Sub
        Factor = System.Math.Abs(pAreaLav(iCond, iBtmTop).CircSaddle.b2(1) / pAreaLav(iCond, iBtmTop).CircSaddle.TT(1))
    End Sub

    Public Sub StSupRing(ByVal iBtmTop As Short)
        Dim f As Single
        Dim R As Single
        Dim sb1, sb2 As Single
        f = pAreaLav(iCond, iBtmTop).React(iSadd)
        R = pSaddlesItem(iBtmTop).MeanR(iSadd)
        With pAreaLav(iCond, iBtmTop).CircSaddle
            .K6(iSadd) = kSt(6, iSadd)
            .K6S(iSadd) = kSt(7, iSadd)
            .F6(iSadd) = -.K6S(iSadd) * f / pSaddlesItem(iBtmTop).GeomSadd(iSadd).Ax
            sb1 = .K6(iSadd) * f * R * pSaddlesItem(iBtmTop).GeomSadd(iSadd).rCrown / pSaddlesItem(iBtmTop).GeomSadd(iSadd).Ix
            sb2 = .K6(iSadd) * f * R * pSaddlesItem(iBtmTop).GeomSadd(iSadd).rBottom / pSaddlesItem(iBtmTop).GeomSadd(iSadd).Ix
            .ZETS(iSadd) = sb1
            .F6S(iSadd) = sb2
        End With
    End Sub
    Public Sub FactSupRing(ByRef Factor As Single, ByVal iBtmTop As Short)
        Dim sb1, sb2 As Single
        Dim sigma, sigma1 As Single
        With pAreaLav(iCond, iBtmTop).CircSaddle
            sb1 = .ZETS(iSadd)
            sb2 = .F6S(iSadd)
            sigma = System.Math.Abs(.F6(iSadd) + sb1)
            sigma1 = System.Math.Abs(.F6(iSadd) - sb2)
            If sigma1 > sigma Then sigma = sigma1
            Factor = sigma / pSaddlesLoad(iCond, iBtmTop).AmmShell(2)
        End With
    End Sub
    Public Sub VisRing()
        Dim j, i, k As Short
        On Error Resume Next
        With frmSaddles.DefInstance
            For i = 1 To 2
                For k = 1 To 4
                    j = CShort(25 + i + 2 * (k - 1))
                    If SaddlesItem.GeomSadd(i).SupRing Then
                        .Label41(j).Visible = True : .Label42(j).Visible = True
                        mioContr1(j).Visible = True : mioContr1(j).Enabled = True
                        .Label41(j).Enabled = True : .Label42(j).Enabled = True
                    Else
                        .Label41(j).Visible = False : .Label42(j).Visible = False
                        mioContr1(j).Visible = False : mioContr1(j).Enabled = False
                        .Label41(j).Enabled = False : .Label42(j).Enabled = False
                    End If
                Next
            Next
        End With
    End Sub
    Public Sub VisRingT()
        Dim j, i, k As Short
        On Error Resume Next
        With frmSaddles.DefInstance
            For i = 1 To 2
                For k = 1 To 4
                    j = CShort(25 + i + 2 * (k - 1))
                    If SaddlesItemT.GeomSadd(i).SupRing Then
                        .Label41T(j).Visible = True : .Label42T(j).Visible = True
                        mioContr1T(j).Visible = True : mioContr1T(j).Enabled = True
                        .Label41T(j).Enabled = True : .Label42T(j).Enabled = True
                    Else
                        .Label41T(j).Visible = False : .Label42T(j).Visible = False
                        mioContr1T(j).Visible = False : mioContr1T(j).Enabled = False
                        .Label41T(j).Enabled = False : .Label42T(j).Enabled = False
                    End If
                Next
            Next
        End With
    End Sub
    Public Function Calc352(ByRef ic As typSaddlesLoad, ByRef i As Short, ByVal SI As typSaddlesItemN) As Single
        Dim File As String
        Dim esD, psf, esD1 As Single
        Dim Para1, xxx1, xxx2, Para2 As Single
        Dim Stress As Single
        Dim icount As Short
        Dim Testo As String
        If SI.TipoChius(i) = 0 Then Exit Function
        If SI.Diam = 0 Then
            MostraAiuto(IDH_ZICK_PD352_NODIAM)
            Exit Function
        End If
        If SI.SpessHead(i) = 0 Then
            Testo = GlobalRoutines.FormatS(Monitor.Motore.Inizio.ConvertiCr(Helpstringa(IDH_ZICK_PD352_NOSPESS)), i)
            MostraAiuto(IDH_ZICK_PD352_NOSPESS, ChiaviMess.MessCritical Or ChiaviMess.MessHelpButton Or ChiaviMess.MessOkOnly, Testo)
            Exit Function
        End If
        With ic
            esD = SI.SpessHead(i) / SI.Diam * 1000
            Select Case SI.TipoChius(i)
                Case 1 'hemi
                    psf = esD / 295
                Case 2 '2:1
                    File = Monitor.Motore.Inizio.Archdir & "\WR\PD352.DAT"
                    If Not IO.File.Exists(File) Then
                        MostraAiuto(IDH_ZICK_PD352_NOFILE)
                        Exit Function
                    End If
                    psf = 0.005
                    Do
                        GlobalRoutines.LegFig(File, psf, 0.25, Para1, Para2, xxx1, xxx2, 1)
                        esD1 = CSng(System.Math.Exp(System.Math.Log(xxx1) + System.Math.Log(xxx2 / xxx1) * (psf - Para1) / (Para2 - Para1)))
                        If System.Math.Abs((esD - esD1) / esD) < 0.01 Then Exit Do
                        psf = psf * esD / esD1
                        icount = CShort(icount + 1)
                    Loop While icount < 50
            End Select
            Stress = .DesPress / psf
            If Stress >= 1.25 * .AmmHead(i) Then
                Testo = GlobalRoutines.FormatS(Monitor.Motore.Inizio.ConvertiCr(Helpstringa(IDH_ZICK_PD352_NONCONS)), i)
                MostraAiuto(IDH_ZICK_PD352_NONCONS, ChiaviMess.MessCritical Or ChiaviMess.MessHelpButton Or ChiaviMess.MessOkOnly, Testo)
                Stress = .AmmHead(i)
            End If
            Calc352 = Stress
        End With
    End Function
    Public Function MostraAiuto(ByRef id As Integer, Optional ByRef Informa As ChiaviMess = _
                        ChiaviMess.MessCritical Or ChiaviMess.MessOkOnly, _
                        Optional ByRef mioTesto As String = "", Optional ByRef mioTitolo As String = "") _
                        As ChiaviMess
        Dim Testo, Tit As String
        If id > 0 Then
            If Len(mioTesto) = 0 Then
                Testo = Monitor.Motore.Inizio.ConvertiCr(Helpstringa(id)) ' "Il gruppo di items da montare su ventilatore a comune non è stato definito correttamente"
            Else
                Testo = Monitor.Motore.Inizio.ConvertiCr(mioTesto)
            End If
            If Len(mioTitolo) = 0 Then
                Tit = "BSDD - Messaggi di errore"
                If Not CBool(Informa And ChiaviMess.MessCritical) Then Tit = "BSDD"
            Else
                Tit = mioTitolo
            End If
            Dim Topic As String = HelpTopic(id)
            If Topic = "" Then
                MostraAiuto = Monitor.Motore.Messaggio(Testo, Informa, Tit, RadiceHelp, Topic)
            Else
                MostraAiuto = Monitor.Motore.Messaggio(Testo, Informa Or ChiaviMess.MessHelpButton, Tit, RadiceHelp, Topic)
            End If
        Else
            MsgBox("Errore sconosciuto", MsgBoxStyle.Information, "BSDD")
        End If
    End Function
    Public Function Helpstringa(ByVal id As Integer) As String
        Dim Nome As String = "str" + id.ToString.Trim
        Helpstringa = rmHelpStrings.GetString(Nome).Replace("|", vbCrLf)
    End Function
    Public Function HelpTopic(ByVal id As Integer) As String
        Dim Nome As String = "str" + id.ToString.Trim
        Dim Stringa As String
        Try
            Stringa = rmHelpTopics.GetString(Nome)
            If Stringa Is Nothing Then
                Stringa = ""
            End If
        Catch e As Exception
            'MsgBox(e.Message + vbCrLf + e.StackTrace)
            Stringa = ""
        End Try
        Return Stringa
    End Function
    Private Function FileLC() As String
        If EliminatoSisma And EliminatoVento Then
            Return "\WR\SADDLCsWS.TXT"
        ElseIf EliminatoSisma Then
            Return "\WR\SADDLCsS.TXT"
        ElseIf EliminatoVento Then
            Return "\WR\SADDLCsW.TXT"
        Else
            Return "\WR\SADDLC.TXT"
        End If
    End Function
    Friend Sub RiprBocch()
        Dim Riga As String
        Dim i, j, dummy As Short
        Dim ifl As Integer = FreeFile()
        Try
            FileOpen(ifl, Monitor.Motore.Inizio.Archdir.Trim & FileLC(), OpenMode.Input, , OpenShare.Shared)
            Riga = LeggiRigaLC(ifl)
            Problem.NumCondElem = CShort(Riga)
            NumCondElemIniz = CShort(Riga)
            For i = 1 To Problem.NumCondElem
                Riga = LineInput(ifl)
            Next
            For i = 1 To 11
                Input(ifl, Problem.iCompresso(i))
            Next
            For i = 1 To 3
                dummy = CShort(LeggiRigaLC(ifl))
                For j = 1 To dummy
                    Riga = LineInput(ifl)
                    Riga = LineInput(ifl)
                Next
            Next
            SaddlesItem.NumBocch = CShort(LeggiRigaLC(ifl))
            NozzleData.Initialize(False)
            For i = 1 To SaddlesItem.NumBocch
                Input(ifl, NozzleData.NozzleNames(i))
                Input(ifl, NozzleData.PositionX(i))
                Input(ifl, NozzleData.PositionZ(i))
            Next
            FileClose(ifl)
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Friend Sub RiprBocchT()
        Dim Riga As String
        Dim i, j, dummy As Short
        Dim ifl As Integer = FreeFile()
        Try
            FileOpen(ifl, Monitor.Motore.Inizio.Archdir.Trim & FileLC(), OpenMode.Input, , OpenShare.Shared)
            Riga = LeggiRigaLC(ifl)
            Problem.NumCondElem = CShort(Riga)
            NumCondElemIniz = CShort(Riga)
            For i = 1 To Problem.NumCondElem
                Riga = LineInput(ifl)
            Next
            For i = 1 To 11
                Input(ifl, Problem.iCompresso(i))
            Next
            For i = 1 To 3
                dummy = CShort(LeggiRigaLC(ifl))
                For j = 1 To dummy
                    Riga = LineInput(ifl)
                    Riga = LineInput(ifl)
                Next
            Next
            SaddlesItemT.NumBocch = CShort(LeggiRigaLC(ifl))
            NozzleDataT.Initialize(True)
            For i = 1 To SaddlesItemT.NumBocch
                Input(ifl, NozzleDataT.NozzleNames(i))
                Input(ifl, NozzleDataT.PositionX(i))
                Input(ifl, NozzleDataT.PositionZ(i))
            Next
            FileClose(ifl)
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Friend Sub RiprLC(ByVal n As Short)
        Dim Riga As String
        Dim i, j, k, dummy As Short
        Dim ifl As Integer = FreeFile()
        Try
            FileOpen(ifl, Monitor.Motore.Inizio.Archdir.Trim & FileLC(), OpenMode.Input, , OpenShare.Shared)
            Riga = LeggiRigaLC(ifl)
            Problem.NumCondElem = CShort(Riga)
            NumCondElemIniz = CShort(Riga)
            For i = 1 To Problem.NumCondElem
                Riga = LineInput(ifl)
            Next
            For i = 1 To CShort(n - 1)
                dummy = CShort(LeggiRigaLC(ifl))
                For j = 1 To dummy
                    Riga = LineInput(ifl)
                    Riga = LineInput(ifl)
                Next
            Next
            Problem.NCond(n) = CShort(LeggiRigaLC(ifl))
            For j = 1 To Problem.NCond(n)
                Problem.LoadCond(n, j) = LineInput(ifl)
            Next
            For j = 1 To Problem.NCond(n)
                For k = 1 To Problem.NumCondElem
                    Input(ifl, Problem.LoadCase(n, j, k))
                Next
            Next
            FileClose(ifl)
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Friend Sub IniziaLC(ByVal senzabocchelli As Boolean)
        Dim Riga As String
        Dim i, j, k As Short
        Dim ifl As Integer = FreeFile()
        Try
            FileOpen(ifl, Monitor.Motore.Inizio.Archdir.Trim & FileLC(), OpenMode.Input, , OpenShare.Shared)
            Riga = LeggiRigaLC(ifl)
            Problem.NumCondElem = CShort(Riga)
            NumCondElemIniz = CShort(Riga)
            Problem.Initialize()
            For i = 1 To Problem.NumCondElem
                Problem.Condiz(i) = LineInput(ifl)
            Next
            For i = 1 To 11
                Input(ifl, Problem.iCompresso(i))
            Next
            For i = 1 To 3
                Problem.NCond(i) = CShort(LeggiRigaLC(ifl))
                For j = 1 To Problem.NCond(i)
                    Problem.LoadCond(i, j) = LineInput(ifl)
                Next
                For j = 1 To Problem.NCond(i)
                    For k = 1 To Problem.NumCondElem
                        Input(ifl, Problem.LoadCase(i, j, k))
                    Next
                Next
            Next
            If Not senzabocchelli Then
                SaddlesItem.NumBocch = CShort(LeggiRigaLC(ifl))
                NozzleData.Initialize(False)
                For i = 1 To SaddlesItem.NumBocch
                    Input(ifl, NozzleData.NozzleNames(i))
                    Input(ifl, NozzleData.PositionX(i))
                    Input(ifl, NozzleData.PositionZ(i))
                Next
            End If
            FileClose(ifl)
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
        AggRedim()
        InitTables()
    End Sub
    Friend Sub IniziaLCT(ByVal senzabocchelli As Boolean)
        Dim Riga As String
        Dim i, j, k As Short
        Dim ifl As Integer = FreeFile()
        Try
            FileOpen(ifl, Monitor.Motore.Inizio.Archdir.Trim & FileLC(), OpenMode.Input, , OpenShare.Shared)
            Riga = LeggiRigaLC(ifl)
            Problem.NumCondElem = CShort(Riga)
            NumCondElemIniz = CShort(Riga)
            For i = 1 To Problem.NumCondElem
                Problem.Condiz(i) = LineInput(ifl)
            Next
            For i = 1 To 11
                Input(ifl, Problem.iCompresso(i))
            Next
            For i = 1 To 3
                Problem.NCond(i) = CShort(LeggiRigaLC(ifl))
                For j = 1 To Problem.NCond(i)
                    Problem.LoadCond(i, j) = LineInput(ifl)
                Next
                For j = 1 To Problem.NCond(i)
                    For k = 1 To Problem.NumCondElem
                        Input(ifl, Problem.LoadCase(i, j, k))
                    Next
                Next
            Next
            If Not senzabocchelli Then
                SaddlesItemT.NumBocch = CShort(LeggiRigaLC(ifl))
                NozzleDataT.Initialize(False)
                For i = 1 To SaddlesItemT.NumBocch
                    Input(ifl, NozzleDataT.NozzleNames(i))
                    Input(ifl, NozzleDataT.PositionX(i))
                    Input(ifl, NozzleDataT.PositionZ(i))
                Next
            End If
            FileClose(ifl)
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
        ' AggRedim()
        '  InitTables()
    End Sub
    Friend Sub TrasfLCtoTable(ByVal i As Short)
        Dim drv As DataRowView
        Dim dv As New DataView
        Dim j, k As Short
        Select Case i
            Case 1 : dv = New DataView(LCshell)
            Case 2 : dv = New DataView(LCsadd)
            Case 3 : dv = New DataView(LCfond)
        End Select
        Try
            For j = 1 To Problem.NCond(i)
                If j <= dv.Count Then
                    drv = dv(j - 1)
                    drv.BeginEdit()
                Else
                    drv = dv.AddNew
                End If
                drv(0) = Problem.LoadCond(i, j)
                For k = 1 To Problem.NumCondElem
                    drv(k) = Problem.LoadCase(i, j, k)
                Next
                drv.EndEdit()
            Next
            For j = CShort(Problem.NCond(i) + 1) To CShort(dv.Count)
                dv(j - 1).Delete()
            Next
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Friend Sub invTrasfLCtoTable(ByVal i As Short)
        Dim drv As DataRowView
        Dim dv As DataView
        Dim j, k As Short
        Select Case i
            Case 1 : dv = New DataView(LCshell)
            Case 2 : dv = New DataView(LCsadd)
            Case 3 : dv = New DataView(LCfond)
            Case Else : Exit Sub
        End Select
        Try
            Problem.NCond(i) = CShort(dv.Count)
            For j = 1 To Problem.NCond(i)
                drv = dv(j - 1)
                Problem.LoadCond(i, j) = CStr(drv(0))
                For k = 1 To Problem.NumCondElem
                    Problem.LoadCase(i, j, k) = CSng(drv(k))
                Next
            Next
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Friend Sub CalcolaRisultante()
        Dim i, j, k As Short
        Dim sum As Single
        For j = 1 To SaddlesItem.NumCondBocch
            For k = 1 To 3
                sum = 0
                For i = 1 To SaddlesItem.NumBocch
                    sum = sum + NozzleData.NozzleForces(i, j, k)
                Next
                NozzleData.NozzleForcesR(j, k) = sum
            Next
            For k = 4 To 6
                sum = 0
                For i = 1 To SaddlesItem.NumBocch
                    Select Case k
                        Case 4
                            sum = sum + NozzleData.NozzleForces(i, j, k) + _
                            NozzleData.NozzleForces(i, j, 2) * NozzleData.PositionZ(i) / 1000
                        Case 5
                            sum = sum + NozzleData.NozzleForces(i, j, k) + _
                            NozzleData.NozzleForces(i, j, 1) * NozzleData.PositionZ(i) / 1000 + _
                            NozzleData.NozzleForces(i, j, 3) * NozzleData.PositionX(i) / 1000
                        Case 6
                            sum = sum + NozzleData.NozzleForces(i, j, k) + _
                            NozzleData.NozzleForces(i, j, 2) * NozzleData.PositionX(i) / 1000
                    End Select
                Next
                NozzleData.NozzleForcesR(j, k) = sum
            Next
        Next
    End Sub
    Friend Sub CalcolaRisultanteT()
        Dim i, j, k As Short
        Dim sum As Single
        For j = 1 To SaddlesItemT.NumCondBocchT
            For k = 1 To 3
                sum = 0
                For i = 1 To SaddlesItemT.NumBocch
                    sum = sum + NozzleDataT.NozzleForces(i, j, k)
                Next
                NozzleDataT.NozzleForcesR(j, k) = sum
            Next
            For k = 4 To 6
                sum = 0
                For i = 1 To SaddlesItemT.NumBocch
                    Select Case k
                        Case 4
                            sum = sum + NozzleDataT.NozzleForces(i, j, k) + _
                            NozzleDataT.NozzleForces(i, j, 2) * NozzleDataT.PositionZ(i) / 1000
                        Case 5
                            sum = sum + NozzleDataT.NozzleForces(i, j, k) + _
                            NozzleDataT.NozzleForces(i, j, 1) * NozzleDataT.PositionZ(i) / 1000 + _
                            NozzleDataT.NozzleForces(i, j, 3) * NozzleDataT.PositionX(i) / 1000
                        Case 6
                            sum = sum + NozzleDataT.NozzleForces(i, j, k) + _
                            NozzleDataT.NozzleForces(i, j, 2) * NozzleDataT.PositionX(i) / 1000
                    End Select
                Next
                NozzleDataT.NozzleForcesR(j, k) = sum
            Next
        Next
    End Sub
    Friend Sub invIniziaBocchelli()
        Dim i, j, k As Short
        Dim dv, dv1 As DataView
        Try
            dv = New DataView(tbListaBocchelli)
            SaddlesItem.NumBocch = CShort(dv.Count)
            For j = 1 To SaddlesItem.NumBocch
                NozzleData.NozzleNames(j) = CStr(dv(j - 1)(0))
                NozzleData.PositionX(j) = CSng(dv(j - 1)(1))
                NozzleData.PositionZ(j) = CSng(dv(j - 1)(2))
                dv1 = New DataView(CType(CarBocch(j - 1), DataTable))
                For i = 1 To SaddlesItem.NumCondBocch
                    For k = 1 To 6
                        NozzleData.NozzleForces(j, i, k) = CSng(dv1(i - 1)(k))
                    Next
                Next
            Next
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Friend Sub invIniziaBocchelliT()
        Dim i, j, k As Short
        Dim dv, dv1 As DataView
        Try
            dv = New DataView(tbListaBocchelliT)
            SaddlesItemT.NumBocch = CShort(dv.Count)
            For j = 1 To SaddlesItemT.NumBocch
                NozzleDataT.NozzleNames(j) = CStr(dv(j - 1)(0))
                NozzleDataT.PositionX(j) = CSng(dv(j - 1)(1))
                NozzleDataT.PositionZ(j) = CSng(dv(j - 1)(2))
                dv1 = New DataView(CType(CarBocchT(j - 1), DataTable))
                For i = 1 To SaddlesItemT.NumCondBocchT
                    For k = 1 To 6
                        NozzleDataT.NozzleForces(j, i, k) = CSng(dv1(i - 1)(k))
                    Next
                Next
            Next
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Friend Sub IniziaBocchelli()
        Dim j As Short
        Dim drv As DataRowView
        Dim dv As DataView
        Dim Griglia As DataGrid
        Dim t As DataGridTableStyle
        Dim c As DataGridTextBoxColumn
        tbListaBocchelli = New DataTable("ListaBocchelli")
        Try
            tbListaBocchelli.Columns.Add("Bocchello", GetType(String))
            tbListaBocchelli.Columns.Add("Posx", GetType(Single))
            tbListaBocchelli.Columns.Add("Posz", GetType(Single))
            dv = New DataView(tbListaBocchelli)
            For j = 1 To SaddlesItem.NumBocch
                drv = dv.AddNew
                drv(0) = NozzleData.NozzleNames(j)
                drv(1) = NozzleData.PositionX(j)
                drv(2) = NozzleData.PositionZ(j)
                drv.EndEdit()
            Next
            Griglia = frmSaddles.DefInstance.dgListaBocchelli
            Griglia.TableStyles.Clear()
            t = New DataGridTableStyle
            t.RowHeadersVisible = True
            t.ColumnHeadersVisible = True
            t.MappingName = tbListaBocchelli.TableName
            c = New DataGridTextBoxColumn
            c.Width = Griglia.Width - 6 - 60 - 60 - Griglia.RowHeaderWidth
            c.MappingName = "Bocchello"
            AddHandler c.TextBox.TextChanged, AddressOf dgTextChanged
            t.GridColumnStyles.Add(c)
            c = New DataGridTextBoxColumn
            c.Width = 60
            c.HeaderText = "CG-x [mm]"
            c.MappingName = "Posx"
            t.GridColumnStyles.Add(c)
            c = New DataGridTextBoxColumn
            c.Width = 60
            c.HeaderText = "CG-z [mm]"
            c.MappingName = "Posz"
            t.GridColumnStyles.Add(c)
            Griglia.TableStyles.Add(t)
            Griglia.SetDataBinding(dv, "")
            Griglia.Name = "miaGriglia"
            With frmSaddles.DefInstance
                .PagListaBocchelli.Controls.Add(Griglia)
                If Not CarBocch Is Nothing Then
                    For j = 0 To CShort(CarBocch.Count - 1)
                        CType(CarBocch(j), DataTable).Dispose()
                    Next
                End If
                CarBocch = New ArrayList
                For j = 1 To CShort(.TabBocchDown.TabPages.Count - 1)
                    .TabBocchDown.TabPages.RemoveAt(1)
                Next
            End With
        Catch ex As Exception
            MsgBox(ex.Message + vbCrLf + ex.StackTrace)
        End Try
    End Sub
    Friend Sub IniziaBocchelliT()
        Dim j As Short
        Dim drv As DataRowView
        Dim dv As DataView
        Dim Griglia As DataGrid
        Dim t As DataGridTableStyle
        Dim c As DataGridTextBoxColumn
        tbListaBocchelliT = New DataTable("ListaBocchelli")
        Try
            tbListaBocchelliT.Columns.Add("Bocchello", GetType(String))
            tbListaBocchelliT.Columns.Add("Posx", GetType(Single))
            tbListaBocchelliT.Columns.Add("Posz", GetType(Single))
            dv = New DataView(tbListaBocchelliT)
            For j = 1 To SaddlesItemT.NumBocch
                drv = dv.AddNew
                drv(0) = NozzleDataT.NozzleNames(j)
                drv(1) = NozzleDataT.PositionX(j)
                drv(2) = NozzleDataT.PositionZ(j)
                drv.EndEdit()
            Next
            Griglia = frmSaddles.DefInstance.dgListaBocchelliT
            Griglia.TableStyles.Clear()
            t = New DataGridTableStyle
            t.RowHeadersVisible = True
            t.ColumnHeadersVisible = True
            t.MappingName = tbListaBocchelliT.TableName
            c = New DataGridTextBoxColumn
            c.Width = Griglia.Width - 6 - 60 - 60 - Griglia.RowHeaderWidth
            c.MappingName = "Bocchello"
            AddHandler c.TextBox.TextChanged, AddressOf dgTextChangedT
            t.GridColumnStyles.Add(c)
            c = New DataGridTextBoxColumn
            c.Width = 60
            c.HeaderText = "CG-x [mm]"
            c.MappingName = "Posx"
            t.GridColumnStyles.Add(c)
            c = New DataGridTextBoxColumn
            c.Width = 60
            c.HeaderText = "CG-z [mm]"
            c.MappingName = "Posz"
            t.GridColumnStyles.Add(c)
            Griglia.TableStyles.Add(t)
            Griglia.SetDataBinding(dv, "")
            Griglia.Name = "miaGrigliaT"
            With frmSaddles.DefInstance
                .PagListaBocchelliT.Controls.Add(Griglia)
                If Not CarBocchT Is Nothing Then
                    For j = 0 To CShort(CarBocchT.Count - 1)
                        CType(CarBocchT(j), DataTable).Dispose()
                    Next
                End If
                CarBocchT = New ArrayList
                For j = 1 To CShort(.TabBocchUp.TabPages.Count - 1)
                    .TabBocchUp.TabPages.RemoveAt(1)
                Next
            End With
        Catch ex As Exception
            MsgBox(ex.Message + vbCrLf + ex.StackTrace)
        End Try
    End Sub
    Friend Sub CalcolaCarichiT()
        Dim f1, f2, f3 As Single
        Dim i, iC As Short
        f1 = SaddlesItemT.CGdistFromFixed / SaddlesItem.Lungh(0)
        f2 = 1 - f1
        f3 = Math.Min(f1, f2)
        With LoadFoundDataT
            Try
                'UNIT
                .Sforzi(1).f(1, 3) = .Pesi(0) * f1
                .Sforzi(2).f(1, 3) = .Pesi(0) * f2
                'OPERATING
                .Sforzi(1).f(2, 3) = .Pesi(1) * f1
                .Sforzi(2).f(2, 3) = .Pesi(1) * f2
                'FULL OF WATER
                .Sforzi(1).f(3, 3) = .Pesi(2) * f1
                .Sforzi(2).f(3, 3) = .Pesi(2) * f2
                'VENTO
                iC = Problem.iCompresso(4)
                If iC > 0 Then
                    .Sforzi(2).f(iC, 1) = Math.Min(.FrontForce / 2, .Pesi(1) * f2 * SaddlesItem.frictionfactor)
                    .Sforzi(1).f(iC, 1) = .FrontForce - .Sforzi(2).f(4, 1)
                    .Sforzi(1).f(iC, 3) = -.FrontForce * SaddlesItem.CGHeight / SaddlesItem.Lungh(0)
                    .Sforzi(2).f(iC, 3) = .FrontForce * SaddlesItem.CGHeight / SaddlesItem.Lungh(0)
                    .Sforzi(1).f(iC, 2) = .LateralForce * f1
                    .Sforzi(2).f(iC, 2) = .LateralForce * f2
                    .Sforzi(1).f(iC, 4) = -.LateralForce * SaddlesItem.CGHeight / 1000 / 2
                    .Sforzi(2).f(iC, 4) = -.LateralForce * SaddlesItem.CGHeight / 1000 / 2
                End If
                'SISMA X
                iC = Problem.iCompresso(5)
                If iC > 0 Then
                    .Sforzi(2).f(iC, 1) = Math.Min(.FrontForceS / 2, .Pesi(1) * f2 * SaddlesItem.frictionfactor)
                    .Sforzi(1).f(iC, 1) = .FrontForceS - .Sforzi(2).f(5, 1)
                    .Sforzi(1).f(iC, 3) = -.FrontForceS * SaddlesItem.CGHeight / SaddlesItem.Lungh(0)
                    .Sforzi(2).f(iC, 3) = .FrontForceS * SaddlesItem.CGHeight / SaddlesItem.Lungh(0)
                End If
                'SISMA Y
                iC = Problem.iCompresso(6)
                If iC > 0 Then
                    .Sforzi(1).f(iC, 2) = .LateralForceS * f1
                    .Sforzi(2).f(iC, 2) = .LateralForceS * f2
                    .Sforzi(1).f(iC, 4) = -.LateralForceS * SaddlesItem.CGHeight / 1000 / 2
                    .Sforzi(2).f(iC, 4) = -.LateralForceS * SaddlesItem.CGHeight / 1000 / 2
                End If
                'BUNDLE EXTRACTION
                iC = Problem.iCompresso(7)
                If iC > 0 Then
                    .Sforzi(1).f(iC, 1) = .Pesi(3) * SaddlesItemT.bundlefactor / 2
                    .Sforzi(2).f(iC, 1) = .Pesi(3) * SaddlesItemT.bundlefactor / 2
                    .Sforzi(1).f(iC, 3) = -.Pesi(3) * SaddlesItemT.bundlefactor * SaddlesItemT.bundleCGheight / SaddlesItem.Lungh(0)
                    .Sforzi(2).f(iC, 3) = .Pesi(3) * SaddlesItemT.bundlefactor * SaddlesItemT.bundleCGheight / SaddlesItem.Lungh(0)
                End If
                'BUNDLE EXTRACTION
                'NOZZLES
                Dim n As Short = Problem.NumCondElem - SaddlesItemT.NumCondBocchT
                For i = CShort(n + 1) To Problem.NumCondElem
                    .Sforzi(1).f(i, 3) = NozzleDataT.NozzleForcesR(i - n, 3) * f1
                    .Sforzi(2).f(i, 3) = NozzleDataT.NozzleForcesR(i - n, 3) * f2
                    .Sforzi(2).f(i, 1) = NozzleDataT.NozzleForcesR(i - n, 1) / 2
                    .Sforzi(1).f(i, 1) = NozzleDataT.NozzleForcesR(i - n, 1) / 2
                    .Sforzi(1).f(i, 3) = .Sforzi(2).f(i, 3) - NozzleDataT.NozzleForcesR(i - n, 1) * SaddlesItemT.CGHeight / SaddlesItem.Lungh(0)
                    .Sforzi(2).f(i, 3) = .Sforzi(2).f(i, 3) + NozzleDataT.NozzleForcesR(i - n, 1) * SaddlesItemT.CGHeight / SaddlesItem.Lungh(0)
                    .Sforzi(1).f(i, 2) = NozzleDataT.NozzleForcesR(i - n, 2) * f1
                    .Sforzi(2).f(i, 2) = NozzleDataT.NozzleForcesR(i - n, 2) * f2
                    .Sforzi(1).f(i, 4) = NozzleDataT.NozzleForcesR(i - n, 2) * SaddlesItemT.CGHeight / 1000 / 2 + NozzleDataT.NozzleForcesR(i - n, 4) / 2
                    .Sforzi(2).f(i, 4) = NozzleDataT.NozzleForcesR(i - n, 2) * SaddlesItemT.CGHeight / 1000 / 2 + NozzleDataT.NozzleForcesR(i - n, 4) / 2
                    .Sforzi(1).f(i, 3) = .Sforzi(1).f(i, 3) - NozzleDataT.NozzleForcesR(i - n, 5) / SaddlesItem.Lungh(0) * 1000
                    .Sforzi(2).f(i, 3) = .Sforzi(2).f(i, 3) + NozzleDataT.NozzleForcesR(i - n, 5) / SaddlesItem.Lungh(0) * 1000
                    .Sforzi(1).f(i, 2) = .Sforzi(1).f(i, 2) + NozzleDataT.NozzleForcesR(i - n, 6) / SaddlesItem.Lungh(0) * 1000
                    .Sforzi(2).f(i, 2) = .Sforzi(2).f(i, 2) - NozzleDataT.NozzleForcesR(i - n, 6) / SaddlesItem.Lungh(0) * 1000
                Next
            Catch e As Exception
                MsgBox(e.Message + vbCrLf + e.StackTrace)
            End Try
        End With

    End Sub
    Friend Sub CalcolaCarichi()
        Dim f1, f2, f3 As Single
        Dim i, iC As Short
        f1 = SaddlesItem.CGdistFromFixed / SaddlesItem.Lungh(0)
        f2 = 1 - f1
        f3 = Math.Min(f1, f2)
        With LoadFoundData
            Try
                'UNIT
                .Sforzi(1).f(1, 3) = .Pesi(0) * f1
                .Sforzi(2).f(1, 3) = .Pesi(0) * f2
                'OPERATING
                .Sforzi(1).f(2, 3) = .Pesi(1) * f1
                .Sforzi(2).f(2, 3) = .Pesi(1) * f2
                .Sforzi(1).f(2, 1) = -.Pesi(1) * f3 * SaddlesItem.frictionfactor
                .Sforzi(2).f(2, 1) = .Pesi(1) * f3 * SaddlesItem.frictionfactor
                'FULL OF WATER
                .Sforzi(1).f(3, 3) = .Pesi(2) * f1
                .Sforzi(2).f(3, 3) = .Pesi(2) * f2
                'VENTO
                iC = Problem.iCompresso(4)
                If iC > 0 Then
                    .Sforzi(2).f(iC, 1) = Math.Min(.FrontForce / 2, .Pesi(1) * f2 * SaddlesItem.frictionfactor)
                    .Sforzi(1).f(iC, 1) = .FrontForce - .Sforzi(2).f(4, 1)
                    .Sforzi(1).f(iC, 3) = -.FrontForce * SaddlesItem.CGHeight / SaddlesItem.Lungh(0)
                    .Sforzi(2).f(iC, 3) = .FrontForce * SaddlesItem.CGHeight / SaddlesItem.Lungh(0)
                    .Sforzi(1).f(iC, 2) = .LateralForce * f1
                    .Sforzi(2).f(iC, 2) = .LateralForce * f2
                    .Sforzi(1).f(iC, 4) = -.LateralForce * SaddlesItem.CGHeight / 1000 / 2
                    .Sforzi(2).f(iC, 4) = -.LateralForce * SaddlesItem.CGHeight / 1000 / 2
                End If
                'SISMA X
                iC = Problem.iCompresso(5)
                If iC > 0 Then
                    .Sforzi(2).f(iC, 1) = Math.Min(.FrontForceS / 2, .Pesi(1) * f2 * SaddlesItem.frictionfactor)
                    .Sforzi(1).f(iC, 1) = .FrontForceS - .Sforzi(2).f(5, 1)
                    .Sforzi(1).f(iC, 3) = -.FrontForceS * SaddlesItem.CGHeight / SaddlesItem.Lungh(0)
                    .Sforzi(2).f(iC, 3) = .FrontForceS * SaddlesItem.CGHeight / SaddlesItem.Lungh(0)
                End If
                'SISMA Y
                iC = Problem.iCompresso(6)
                If iC > 0 Then
                    .Sforzi(1).f(iC, 2) = .LateralForceS * f1
                    .Sforzi(2).f(iC, 2) = .LateralForceS * f2
                    .Sforzi(1).f(iC, 4) = -.LateralForceS * SaddlesItem.CGHeight / 1000 / 2
                    .Sforzi(2).f(iC, 4) = -.LateralForceS * SaddlesItem.CGHeight / 1000 / 2
                End If
                'BUNDLE EXTRACTION
                iC = Problem.iCompresso(7)
                If iC > 0 Then
                    .Sforzi(1).f(iC, 1) = .Pesi(3) * SaddlesItem.bundlefactor
                    .Sforzi(1).f(iC, 3) = -.Pesi(3) * SaddlesItem.bundlefactor * SaddlesItem.bundleCGheight / SaddlesItem.Lungh(0)
                    .Sforzi(2).f(iC, 3) = .Pesi(3) * SaddlesItem.bundlefactor * SaddlesItem.bundleCGheight / SaddlesItem.Lungh(0)
                End If
                'NOZZLES
                Dim n As Short = Problem.NumCondElem - SaddlesItem.NumCondBocch
                For i = CShort(n + 1) To Problem.NumCondElem
                    .Sforzi(1).f(i, 3) = NozzleData.NozzleForcesR(i - n, 3) * f1
                    .Sforzi(2).f(i, 3) = NozzleData.NozzleForcesR(i - n, 3) * f2
                    .Sforzi(2).f(i, 1) = Math.Min(NozzleData.NozzleForcesR(i - n, 1) / 2, .Pesi(1) * f2 * SaddlesItem.frictionfactor)
                    .Sforzi(1).f(i, 1) = NozzleData.NozzleForcesR(i - n, 1) - .Sforzi(2).f(i, 1)
                    .Sforzi(1).f(i, 3) = .Sforzi(2).f(i, 3) - NozzleData.NozzleForcesR(i - n, 1) * SaddlesItem.CGHeight / SaddlesItem.Lungh(0)
                    .Sforzi(2).f(i, 3) = .Sforzi(2).f(i, 3) + NozzleData.NozzleForcesR(i - n, 1) * SaddlesItem.CGHeight / SaddlesItem.Lungh(0)
                    .Sforzi(1).f(i, 2) = NozzleData.NozzleForcesR(i - n, 2) * f1
                    .Sforzi(2).f(i, 2) = NozzleData.NozzleForcesR(i - n, 2) * f2
                    .Sforzi(1).f(i, 4) = NozzleData.NozzleForcesR(i - n, 2) * SaddlesItem.CGHeight / 1000 / 2 + NozzleData.NozzleForcesR(i - n, 4) / 2
                    .Sforzi(2).f(i, 4) = NozzleData.NozzleForcesR(i - n, 2) * SaddlesItem.CGHeight / 1000 / 2 + NozzleData.NozzleForcesR(i - n, 4) / 2
                    .Sforzi(1).f(i, 3) = .Sforzi(1).f(i, 3) - NozzleData.NozzleForcesR(i - n, 5) / SaddlesItem.Lungh(0) * 1000
                    .Sforzi(2).f(i, 3) = .Sforzi(2).f(i, 3) + NozzleData.NozzleForcesR(i - n, 5) / SaddlesItem.Lungh(0) * 1000
                    .Sforzi(1).f(i, 2) = .Sforzi(1).f(i, 2) + NozzleData.NozzleForcesR(i - n, 6) / SaddlesItem.Lungh(0) * 1000
                    .Sforzi(2).f(i, 2) = .Sforzi(2).f(i, 2) - NozzleData.NozzleForcesR(i - n, 6) / SaddlesItem.Lungh(0) * 1000
                Next
                If Problem.Stacked Then
                    For i = 1 To Problem.NumCondElem
                        SforziFromTop.SforziFromTop(1, i, 3) = LoadFoundDataT.Sforzi(1).f(i, 3) - (LoadFoundDataT.Sforzi(1).f(i, 1) + LoadFoundDataT.Sforzi(2).f(i, 1)) * SaddlesItemT.Heightbtwsaddles / SaddlesItem.Lungh(0)
                        SforziFromTop.SforziFromTop(2, i, 3) = LoadFoundDataT.Sforzi(2).f(i, 3) + (LoadFoundDataT.Sforzi(1).f(i, 1) + LoadFoundDataT.Sforzi(2).f(i, 1)) * SaddlesItemT.Heightbtwsaddles / SaddlesItem.Lungh(0)
                        SforziFromTop.SforziFromTop(1, i, 2) = LoadFoundDataT.Sforzi(1).f(i, 2)
                        SforziFromTop.SforziFromTop(2, i, 2) = LoadFoundDataT.Sforzi(2).f(i, 2)
                        SforziFromTop.SforziFromTop(1, i, 1) = LoadFoundDataT.Sforzi(1).f(i, 1)
                        SforziFromTop.SforziFromTop(2, i, 1) = LoadFoundDataT.Sforzi(2).f(i, 1)
                        SforziFromTop.SforziFromTop(1, i, 4) = -LoadFoundDataT.Sforzi(1).f(i, 2) * SaddlesItemT.Heightbtwsaddles / 1000 + LoadFoundDataT.Sforzi(1).f(i, 4)
                        SforziFromTop.SforziFromTop(2, i, 4) = -LoadFoundDataT.Sforzi(2).f(i, 2) * SaddlesItemT.Heightbtwsaddles / 1000 + LoadFoundDataT.Sforzi(2).f(i, 4)
                    Next
                End If
            Catch e As Exception
                MsgBox(e.Message + vbCrLf + e.StackTrace)
            End Try
        End With
    End Sub
    Public Sub CarDaSopraTextChanged(ByVal s As Object, ByVal e As EventArgs)
        Dim Griglia As DataGrid = frmSaddles.DefInstance.dgCarSopra
        Dim RigaLista As Integer = Griglia.CurrentRowIndex + 1
        If RigaLista < NumCondElemIniz Then
            Problem.NumCondElem += CShort(1)
        Else
            MostraAiuto(IDH_MAXCONDELEM)
            frmSaddles.DefInstance.TabCarFondDown_SelectedIndexChanged(frmSaddles.DefInstance, New System.EventArgs)
        End If
    End Sub
    Public Sub CarFondTextChanged(ByVal s As Object, ByVal e As EventArgs)
        Dim Griglia As DataGrid = frmSaddles.DefInstance.dgCarFond
        Dim RigaLista As Integer = Griglia.CurrentRowIndex + 1
        If RigaLista < NumCondElemIniz Then
            Problem.NumCondElem += CShort(1)
        Else
            MostraAiuto(IDH_MAXCONDELEM)
            frmSaddles.DefInstance.TabCarFondDown_SelectedIndexChanged(frmSaddles.DefInstance, New System.EventArgs)
        End If
    End Sub
    Public Sub CarFondTTextChanged(ByVal s As Object, ByVal e As EventArgs)
        Dim Griglia As DataGrid = frmSaddles.DefInstance.dgCarFondT
        Dim RigaLista As Integer = Griglia.CurrentRowIndex + 1
        If RigaLista < NumCondElemIniz Then
            Problem.NumCondElem += CShort(1)
        Else
            MostraAiuto(IDH_MAXCONDELEM)
            frmSaddles.DefInstance.TabCarFondUp_SelectedIndexChanged(frmSaddles.DefInstance, New System.EventArgs)
        End If
    End Sub
    Public Sub dgTextChanged(ByVal s As Object, ByVal e As EventArgs)
        Dim Griglia As DataGrid = frmSaddles.DefInstance.dgListaBocchelli
        If Griglia.CurrentCell.ColumnNumber = 1 Then Exit Sub
        Dim t As TextBox = CType(Griglia.TableStyles(0).GridColumnStyles(0), DataGridTextBoxColumn).TextBox
        Dim ss As String = t.Text
        If ss = "(null)" Then Exit Sub
        RigaLista = CShort(Griglia.CurrentRowIndex + 1)
        Dim i As Integer = ss.ToUpper.IndexOf("NOZZLES")
        If i > -1 Then
            ss = ss.Substring(i + 7).Trim
        Else
            i = ss.ToUpper.IndexOf("NOZZLE")
            If i > -1 Then ss = ss.Substring(i + 6).Trim
        End If
        If RigaLista > frmSaddles.DefInstance.TabBocchDown.TabPages.Count - 1 Then
            dgAggiungiTab(ss)
        Else
            dgModificaTab(ss)
        End If
    End Sub
    Public Sub dgTextChangedT(ByVal s As Object, ByVal e As EventArgs)
        Dim Griglia As DataGrid = frmSaddles.DefInstance.dgListaBocchelliT
        If Griglia.CurrentCell.ColumnNumber = 1 Then Exit Sub
        Dim t As TextBox = CType(Griglia.TableStyles(0).GridColumnStyles(0), DataGridTextBoxColumn).TextBox
        Dim ss As String = t.Text
        If ss = "(null)" Then Exit Sub
        RigaLista = CShort(Griglia.CurrentRowIndex + 1)
        Dim i As Integer = ss.ToUpper.IndexOf("NOZZLES")
        If i > -1 Then
            ss = ss.Substring(i + 7).Trim
        Else
            i = ss.ToUpper.IndexOf("NOZZLE")
            If i > -1 Then ss = ss.Substring(i + 6).Trim
        End If
        If RigaLista > frmSaddles.DefInstance.TabBocchUp.TabPages.Count - 1 Then
            dgAggiungiTabT(ss)
        Else
            dgModificaTabT(ss)
        End If
    End Sub
    Private Function InitTabellaNozzle(ByVal p As Integer) As DataView
        Dim i, j, k As Short
        Dim dv As DataView
        Dim drv As DataRowView
        CarBocch.Add(New DataTable("CarBocch" & p.ToString))
        With CType(CarBocch(p - 1), DataTable)
            .Columns.Add("Condizione", GetType(String))
            For k = 1 To 6
                .Columns.Add(Titoli(k), GetType(Single))
            Next
        End With
        dv = New DataView(CType(CarBocch(p - 1), DataTable))
        For j = 1 To Problem.NumCondElem
            If Problem.Condiz(j).ToUpper.IndexOf("NOZZLES") > -1 Then
                i = CShort(i + 1)
                drv = dv.AddNew
                drv(0) = Problem.Condiz(j).Substring(8)
                For k = 1 To 6
                    drv(k) = NozzleData.NozzleForces(p, i, k)
                Next
                drv.EndEdit()
            End If
        Next
        Return dv
    End Function
    Private Function InitTabellaNozzleT(ByVal p As Integer) As DataView
        Dim i, j, k As Short
        Dim dv As DataView
        Dim drv As DataRowView
        CarBocchT.Add(New DataTable("CarBocchT" & p.ToString))
        With CType(CarBocchT(p - 1), DataTable)
            .Columns.Add("Condizione", GetType(String))
            For k = 1 To 6
                .Columns.Add(Titoli(k), GetType(Single))
            Next
        End With
        dv = New DataView(CType(CarBocchT(p - 1), DataTable))
        For j = 1 To Problem.NumCondElem
            If Problem.Condiz(j).ToUpper.IndexOf("NOZZLES") > -1 Then
                i = CShort(i + 1)
                drv = dv.AddNew
                drv(0) = Problem.Condiz(j).Substring(8)
                For k = 1 To 6
                    drv(k) = NozzleDataT.NozzleForces(p, i, k)
                Next
                drv.EndEdit()
            End If
        Next
        Return dv
    End Function
    Friend Sub InitTables1(ByVal p As Integer)
        Dim k As Short
        Dim dv As DataView
        Dim t As DataGridTableStyle
        Dim c As DataGridTextBoxColumn
        Dim Griglia As DataGrid
        Dim r As Rectangle
        Try
            dv = InitTabellaNozzle(p)
            Griglia = New DataGrid
            Griglia.Size = dgSize ' New Size(544, 312) ' frmSaddles.DefInstance.dgCarBocch1.Size
            Griglia.Location = dgLocation ' New Point(8, 8) 'frmSaddles.DefInstance.dgCarBocch1.Location
            frmSaddles.DefInstance.TabBocchDown.TabPages(p).Controls.Add(Griglia)
            Griglia.CaptionVisible = False
            t = New DataGridTableStyle
            t.MappingName = CType(CarBocch(p - 1), DataTable).TableName
            c = New DataGridTextBoxColumn
            c.Width = 140
            c.MappingName = "Condizione"
            c.HeaderText = c.MappingName
            t.GridColumnStyles.Add(c)
            For k = 1 To 6
                c = New DataGridTextBoxColumn
                c.Width = 60
                c.MappingName = Titoli(k)
                c.HeaderText = c.MappingName
                t.GridColumnStyles.Add(c)
            Next
            Griglia.TableStyles.Add(t)
            Griglia.SetDataBinding(dv, "")
            If p = 1 Then
                r = Griglia.GetCellBounds(SaddlesItem.NumCondBocch - 1, 6)
                Griglia.Width = r.Left + r.Width + Griglia.RowHeaderWidth + 6
            End If
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Friend Sub RinfrescaTabelleNozzles()
        Dim i As Short
        Dim dv As DataView
        Dim Griglia As DataGrid
        If CarBocch.Count = 0 Then Exit Sub
        CarBocch.Clear()
        For i = 1 To SaddlesItem.NumBocch
            dv = InitTabellaNozzle(i)
            Griglia = CType(frmSaddles.DefInstance.TabBocchDown.TabPages(i).Controls(0), DataGrid)
            Griglia.SetDataBinding(dv, "")
        Next
    End Sub
    Friend Sub RinfrescaTabelleNozzlesT()
        Dim i As Short
        Dim dv As DataView
        Dim Griglia As DataGrid
        If CarBocchT.Count = 0 Then Exit Sub
        CarBocchT.Clear()
        For i = 1 To SaddlesItem.NumBocch
            dv = InitTabellaNozzleT(i)
            Griglia = CType(frmSaddles.DefInstance.TabBocchUp.TabPages(i).Controls(0), DataGrid)
            Griglia.SetDataBinding(dv, "")
        Next
    End Sub
    Friend Sub InitTables1T(ByVal p As Integer)
        Dim k As Short
        Dim dv As DataView
        Dim t As DataGridTableStyle
        Dim c As DataGridTextBoxColumn
        Dim Griglia As DataGrid
        Dim r As Rectangle
        Dim Titoli As String() = {"", "Fx [N]", "Fy [N]", "Fz [N]", "Mx [Nm]", "My [Nm]", "Mz [Nm]"}
        Try
            dv = InitTabellaNozzleT(p)
            Griglia = New DataGrid
            Griglia.Size = dgSize ' New Size(544, 312) ' frmSaddles.DefInstance.dgCarBocch1.Size
            Griglia.Location = dgLocation ' New Point(8, 8) 'frmSaddles.DefInstance.dgCarBocch1.Location
            frmSaddles.DefInstance.TabBocchUp.TabPages(p).Controls.Add(Griglia)
            Griglia.CaptionVisible = False
            t = New DataGridTableStyle
            t.MappingName = CType(CarBocchT(p - 1), DataTable).TableName
            c = New DataGridTextBoxColumn
            c.Width = 140
            c.MappingName = "Condizione"
            c.HeaderText = c.MappingName
            t.GridColumnStyles.Add(c)
            For k = 1 To 6
                c = New DataGridTextBoxColumn
                c.Width = 60
                c.MappingName = Titoli(k)
                c.HeaderText = c.MappingName
                t.GridColumnStyles.Add(c)
            Next
            Griglia.TableStyles.Add(t)
            Griglia.SetDataBinding(dv, "")
            If p = 1 Then
                r = Griglia.GetCellBounds(SaddlesItemT.NumCondBocchT - 1, 6)
                Griglia.Width = r.Left + r.Width + Griglia.RowHeaderWidth + 6
            End If
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Private Sub dgAggiungiTab(ByVal t As String)
        Dim Tab As TabControl = frmSaddles.DefInstance.TabBocchDown
        If Not Inizializzando Then
            SaddlesItem.NumBocch = CShort(SaddlesItem.NumBocch + 1)
            NozzleData.Initialize(False)
        End If
        Dim PagCarichi As TabPage = New TabPage
        PagCarichi.Size = TabSize ' New Size(560, 326)
        Tab.TabPages.Add(PagCarichi)
        InitTables1(RigaLista)
        dgModificaTab(t)
    End Sub
    Private Sub dgAggiungiTabT(ByVal t As String)
        Dim Tab As TabControl = frmSaddles.DefInstance.TabBocchUp
        If Not Inizializzando Then
            SaddlesItemT.NumBocch = CShort(SaddlesItemT.NumBocch + 1)
            NozzleDataT.Initialize(True)
        End If
        Dim PagCarichiT As TabPage = New TabPage
        PagCarichiT.Size = TabSize ' New Size(560, 326)
        Tab.TabPages.Add(PagCarichiT)
        InitTables1T(RigaLista)
        dgModificaTabT(t)
    End Sub
    Private Sub dgModificaTab(ByVal t As String)
        Dim Tab As TabControl = frmSaddles.DefInstance.TabBocchDown
        Tab.TabPages(RigaLista).Text = t
    End Sub
    Private Sub dgModificaTabT(ByVal t As String)
        Dim Tab As TabControl = frmSaddles.DefInstance.TabBocchUp
        Tab.TabPages(RigaLista).Text = t
    End Sub
    Private Sub dgDistruggiTab(ByVal t As String)
        Dim Tab As TabControl = frmSaddles.DefInstance.TabBocchDown
        Dim i As Short
        For i = 1 To CShort(Tab.TabPages.Count - 1)
            If t.IndexOf(Tab.TabPages(i).Text) > -1 Then
                Tab.TabPages(i).Controls.RemoveAt(0)
                Tab.TabPages.RemoveAt(i)
                CarBocch.RemoveAt(i - 1)
                Exit For
            End If
        Next
        SaddlesItem.NumBocch = CShort(SaddlesItem.NumBocch - 1)
    End Sub
    Private Sub dgDistruggiTabT(ByVal t As String)
        Dim Tab As TabControl = frmSaddles.DefInstance.TabBocchUp
        Dim i As Short
        For i = 1 To CShort(Tab.TabPages.Count - 1)
            If t.IndexOf(Tab.TabPages(i).Text) > -1 Then
                Tab.TabPages(i).Controls.RemoveAt(0)
                Tab.TabPages.RemoveAt(i)
                CarBocchT.RemoveAt(i - 1)
                Exit For
            End If
        Next
        SaddlesItemT.NumBocch = CShort(SaddlesItemT.NumBocch - 1)
    End Sub
    Friend Sub InitTables()
        Dim drv As DataRowView
        Dim dv, dvd As DataView
        Dim t As DataGridTableStyle
        Dim c As DataGridTextBoxColumn
        Dim r As Rectangle
        Dim tavola As DataTable
        Dim Griglia, Grigliad As DataGrid
        Dim i, ii, j, k As Short
        LCshell = New DataTable("LCshell")
        LCsadd = New DataTable("LCsadd")
        LCfond = New DataTable("LCfond")
        LCelem = New DataTable("LCelem")
        Try
            With LCelem
                .Columns.Add("Numero", GetType(Integer))
                .Columns.Add("Descrizione", GetType(String))
            End With
            dvd = New DataView(LCelem)
            For j = 1 To Problem.NumCondElem
                drv = dvd.AddNew
                drv(0) = j
                drv(1) = Problem.Condiz(j)
                drv.EndEdit()
            Next
            dvd.AllowDelete = False
            dvd.AllowEdit = False
            dvd.AllowNew = False
            For i = 1 To 3
                Select Case i
                    Case 1 : dv = New DataView(LCshell)
                        tavola = LCshell
                        Griglia = frmSaddles.DefInstance.dgCombMant
                        Grigliad = frmSaddles.DefInstance.dgElemMant
                    Case 2 : dv = New DataView(LCsadd)
                        tavola = LCsadd
                        Griglia = frmSaddles.DefInstance.dgCombsadd
                        Grigliad = frmSaddles.DefInstance.dgElemSadd
                    Case 3 : dv = New DataView(LCfond)
                        tavola = LCfond
                        Griglia = frmSaddles.DefInstance.dgCombfond
                        Grigliad = frmSaddles.DefInstance.dgElemfond
                    Case Else
                        Exit Sub
                End Select
                With tavola
                    .Columns.Add("Combinazione", Type.GetType("System.String"))
                    For ii = 1 To Problem.NumCondElem
                        .Columns.Add(ii.ToString, Type.GetType("System.Single"))
                    Next
                End With
                t = New DataGridTableStyle
                t.MappingName = tavola.TableName
                c = New DataGridTextBoxColumn
                c.Width = 140
                c.MappingName = "Combinazione"
                c.HeaderText = c.MappingName
                t.GridColumnStyles.Add(c)
                For ii = 1 To Problem.NumCondElem
                    c = New DataGridTextBoxColumn
                    c.Width = 20
                    c.MappingName = ii.ToString
                    c.HeaderText = c.MappingName
                    t.GridColumnStyles.Add(c)
                Next
                Griglia.TableStyles.Clear()
                Griglia.TableStyles.Add(t)
                For j = 1 To Problem.NCond(i)
                    drv = dv.AddNew
                    drv(0) = Problem.LoadCond(i, j)
                    For k = 1 To Problem.NumCondElem
                        drv(k) = Problem.LoadCase(i, j, k)
                    Next
                    drv.EndEdit()
                Next
                Griglia.SetDataBinding(dv, "")
                t = New DataGridTableStyle
                t.MappingName = LCelem.TableName
                t.RowHeadersVisible = False
                t.BackColor = Color.Yellow
                t.AlternatingBackColor = Color.Yellow
                c = New DataGridTextBoxColumn
                c.Width = 20
                c.MappingName = "Numero"
                c.HeaderText = "" ' c.MappingName
                t.GridColumnStyles.Add(c)
                c = New DataGridTextBoxColumn
                c.Width = 140
                c.MappingName = "Descrizione"
                c.HeaderText = c.MappingName
                t.GridColumnStyles.Add(c)
                Grigliad.TableStyles.Clear()
                Grigliad.TableStyles.Add(t)
                Grigliad.SetDataBinding(dvd, "")
                r = Griglia.GetCellBounds(Problem.NCond(i), Problem.NumCondElem)
                Griglia.Width = r.Left + r.Width + Griglia.RowHeaderWidth + 6
                Grigliad.Left = Griglia.Left + Griglia.Width + 8
                Grigliad.Width = Grigliad.Parent.Width - Grigliad.Left - 8
            Next
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Private Function LeggiRigaLC(ByVal ifl As Integer) As String
        Dim r As String
        Do
            r = LineInput(ifl)
            If Not r.Substring(0, 1) = "*" Then Return r
        Loop
    End Function
    Private Sub tbListaBocchelli_RowDeleting(ByVal sender As Object, ByVal e As System.Data.DataRowChangeEventArgs) Handles tbListaBocchelli.RowDeleting
        dgDistruggiTab(CStr(e.Row.Item(0)))
    End Sub
    Private Sub tbListaBocchelli_RowDeleted(ByVal sender As Object, ByVal e As System.Data.DataRowChangeEventArgs) Handles tbListaBocchelli.RowDeleted
        frmSaddles.DefInstance.TabBocchDown.SelectedIndex = 0
    End Sub
    Private Sub CarFondT_RowDeleting(ByVal sender As Object, ByVal e As System.Data.DataRowChangeEventArgs) Handles CarFondT.RowDeleting
        Problem.NumCondElem = CShort(Problem.NumCondElem - 1)
    End Sub
    Private Sub CarFond_RowDeleting(ByVal sender As Object, ByVal e As System.Data.DataRowChangeEventArgs) Handles CarFond.RowDeleting
        Problem.NumCondElem = CShort(Problem.NumCondElem - 1)
    End Sub
    Private Sub tbListaBocchelliT_RowDeleting(ByVal sender As Object, ByVal e As System.Data.DataRowChangeEventArgs) Handles tbListaBocchelliT.RowDeleting
        dgDistruggiTabT(CStr(e.Row.Item(0)))
    End Sub
    Private Sub tbListaBocchelliT_RowDeleted(ByVal sender As Object, ByVal e As System.Data.DataRowChangeEventArgs) Handles tbListaBocchelliT.RowDeleted
        frmSaddles.DefInstance.TabBocchUp.SelectedIndex = 0
    End Sub
End Module