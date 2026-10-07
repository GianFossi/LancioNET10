Option Strict Off
Option Explicit On
Imports System.IO
Imports System.Runtime.Serialization
Imports System.Runtime.Serialization.Formatters.Binary
Imports RoutBase1
Friend Class wn_PT
    Public lKlato, lJinvolucr As Short
    Public Verboso As Short
    Public TipoPT As Short
    Public Piastra As Object
    Public RulesAA As wn_AA
    Public PrimaVolta As Boolean
    Public PiastraAB As Short
    Private IndObj As Short
    Public Indprobl1 As Short
    Public IndProbl2 As Short
    Public IndProbl As Short
    Private ptUL As Single
    Private ptOTL As Single
    Private ptRules As Short '0 TEMA 1 AA 2 both
    Private ptTipoAA As Short
    '   0 nessuno 1 Fig AA-1.4.1 U bifl. non estesa
    '             2 Fig.AA-1.5.1 U integrale
    '             3 Fig.AA-1.6.1(a) U flangiata lato mantello
    '             4 Fig.AA-1.6.1(b) U flangiata lato cassa
    '             5 Fig.AA-2.0(a) f integrale
    '             6 Fig.AA-2.0(b) f flangiata lato cassa
    '             7 Fig.AA-2.0(c) f flangiata non estesa lato cassa
    '             8 Fig.AA-2.0(d) f bifl. non estesa
    Private ptMatPias(2) As String
    Private ptMatBull(2) As String
    Private ptTipoPias(2) As String
    Private ptTubSpess As Single
    Private ptXFil(2) As Short
    Private ptIndAccopp(4) As Short
    Private ptIndAccopp2(4) As Short
    Private ptProgDiffPr As Boolean
    Private ptVacuumTS As Boolean
    Private ptVacuumSS As Boolean
    Private ptFullBolt As Short
    Private ptTipCalc As Short
    Private ptVerbose As Boolean
    Private ptSicBullp(2) As Single
    Private ptFattBoltSy(2) As Single
    Private ptDiffPIese(2) As Boolean
    Private ptCRUSH(2) As Boolean
    Private ptFLEX As Boolean
    Private ptmart As Boolean
    Private ptRapporto(2) As Single
    Private ptDiNBull(2) As String
    Private ptNumBolt(2) As Short
    Private ptBoltCiD(2) As Single
    Private ptAreBolt(2) As Single
    Private ptBSpcMin(2) As Single
    Private ptBRadMin(2) As Single
    Private ptNumColl(2) As Short
    Private ptAllFRoo As Single
    Private ptAllFhyd As Single
    Private ptAllFOpe As Single
    Private ptAllBRoo(2) As Single
    Private ptAllBOpe(2) As Single
    Private ptTSheDes As Single 'diametro
    Private ptTSheThk As Single 'xxxspessore
    Private ptTExtThk As Single 'xxxspess ext
    Private ptTubDiam As Single 'xxxdiametro esterno tubi
    Private ptTubPass As Single 'xxxpasso tubi
    Private ptEquDiam As Single 'xxxDL
    Private ptCavChan As Single 'xxxprof cava T.S.
    Private ptCavShel As Single 'xxxprof cava S.S.
    Private ptGrvChan As Single 'xxxprof cava circonf. T.S.
    Private ptGrvShel As Single 'xxxprof cava circonf. S.S.
    Private ptTipPass As Short
    Private ptPDesChan As Single
    Private ptPDesShel As Single
    Private ptPHTChan As Single
    Private ptPHTShel As Single
    Private ptCorChan As Single
    Private ptCorShel As Single
    Private ptDiffPress As Single
    Private ptDiffPressHT As Single
    Private ptDesTemp As Single
    Private ptFlChanNome As String
    Private ptFlShelNome As String
    Private ptSlChanNome As String
    Private ptSlShelNome As String
    Private ptFlChan(30) As Object
    Private ptFlShel(30) As Object
    Private ptSlChan(30) As Object
    Private ptSlShel(30) As Object
    Private ptFlChanS(2) As String
    Private ptFlShelS(2) As String
    Private ptSlChanS(2) As String
    Private ptSlShelS(2) As String
    Private ptPHI(2) As Single
    Private ptwn(2) As Single
    Private ptIndFac(2) As Short
    Private ptTipGsk(2) As Short
    Private ptClassGsk(2) As Short
    Private ptBullDistinti As Boolean
    Private ptBullIndip As Boolean
    Private ptSpessMant As Single
    Public Property PHI(ByVal i As Short) As Single
        Get
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.PHI. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            PHI = Piastra.PHI(i)
        End Get
        Set(ByVal Value As Single)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.PHI. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            Piastra.PHI(i) = Value
            ptPHI(i) = Value
        End Set
    End Property
    Public Property wn(ByVal i As Short) As Single
        Get
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.wn. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            wn = Piastra.wn(i)
        End Get
        Set(ByVal Value As Single)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.wn. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            Piastra.wn(i) = Value
            ptwn(i) = Value
        End Set
    End Property
    Public Property IndAccopp(ByVal i As Short) As Short
        Get
            Select Case PiastraAB
                Case 0, 1
                    IndAccopp = ptIndAccopp(i)
                Case 2
                    IndAccopp = ptIndAccopp2(i)
            End Select
        End Get
        Set(ByVal Value As Short)
            Select Case PiastraAB
                Case 0, 1
                    ptIndAccopp(i) = Value
                Case 2
                    ptIndAccopp2(i) = Value
            End Select
        End Set
    End Property
    Public Property IndFac(ByVal i As Short) As Short
        Get
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.IndFac. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            IndFac(i) = Piastra.IndFac(i)
        End Get
        Set(ByVal Value As Short)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.IndFac. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            Piastra.IndFac(i) = Value
            ptIndFac(i) = Value
        End Set
    End Property
    Public Property SpessMant() As Single
        Get
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.SpessMant. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            SpessMant = Piastra.SpessMant
        End Get
        Set(ByVal Value As Single)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.SpessMant. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            Piastra.SpessMant = Value
            ptSpessMant = Value
        End Set
    End Property
    Public Property TipGsk(ByVal i As Short) As Short
        Get
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.TipGsk. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            TipGsk = Piastra.TipGsk(i)
        End Get
        Set(ByVal Value As Short)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.TipGsk. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            Piastra.TipGsk(i) = Value
            ptTipGsk(i) = Value
        End Set
    End Property
    Public Property ClassGsk(ByVal i As Short) As Short
        Get
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.ClassGsk. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            ClassGsk = Piastra.ClassGsk(i)
        End Get
        Set(ByVal Value As Short)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.ClassGsk. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            Piastra.ClassGsk(i) = Value
            ptClassGsk(i) = Value
        End Set
    End Property
    Public Property DiNBull(ByVal i As Short) As String
        Get
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.DiNBull. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            DiNBull = Piastra.DiNBull(i)
        End Get
        Set(ByVal Value As String)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.DiNBull. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            Piastra.DiNBull(i) = Value
            ptDiNBull(i) = Value
        End Set
    End Property
    Public Property FlChanNome() As String
        Get
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.FlChanNome. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            FlChanNome = Piastra.FlChanNome
        End Get
        Set(ByVal Value As String)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.FlChanNome. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            Piastra.FlChanNome = Value
            ptFlChanNome = Value
        End Set
    End Property
    Public Property FlShelNome() As String
        Get
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.FlShelNome. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            FlShelNome = Piastra.FlShelNome
        End Get
        Set(ByVal Value As String)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.FlShelNome. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            Piastra.FlShelNome = Value
            ptFlShelNome = Value
        End Set
    End Property
    Public Property SlChanNome() As String
        Get
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.SlChanNome. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            SlChanNome = Piastra.SlChanNome
        End Get
        Set(ByVal Value As String)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.SlChanNome. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            Piastra.SlChanNome = Value
            ptSlChanNome = Value
        End Set
    End Property
    Public Property SlShelNome() As String
        Get
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.SlShelNome. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            SlShelNome = Piastra.SlShelNome
        End Get
        Set(ByVal Value As String)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.SlShelNome. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            Piastra.SlShelNome = Value
            ptSlShelNome = Value
        End Set
    End Property
    Public Property FullBolt() As Short
        Get
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.FullBolt. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            FullBolt = Piastra.FullBolt
        End Get
        Set(ByVal Value As Short)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.FullBolt. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            Piastra.FullBolt = Value
            ptFullBolt = Value
        End Set
    End Property
    Public Property XFil(ByVal i As Short) As Short
        Get
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.XFil. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            XFil = Piastra.XFil(i)
        End Get
        Set(ByVal Value As Short)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.XFil. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            Piastra.XFil(i) = Value
            ptXFil(i) = Value
        End Set
    End Property
    Public Property TipPass() As Short
        Get
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.TipPass. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            TipPass = Piastra.TipPass
        End Get
        Set(ByVal Value As Short)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.TipPass. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            Piastra.TipPass = Value
            ptTipPass = Value
        End Set
    End Property
    Public Property TipCalc() As Short
        Get
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.TipCalc. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            TipCalc = Piastra.TipCalc
        End Get
        Set(ByVal Value As Short)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.TipCalc. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            Piastra.TipCalc = Value
            ptTipCalc = Value
        End Set
    End Property
    Public Property NumBolt(ByVal i As Short) As Short
        Get
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.NumBolt. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            NumBolt = Piastra.NumBolt(i)
        End Get
        Set(ByVal Value As Short)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.NumBolt. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            Piastra.NumBolt(i) = Value
            ptNumBolt(i) = Value
        End Set
    End Property
    Public Property NumColl(ByVal i As Short) As Short
        Get
            NumColl = Piastra.NumColl(i)
        End Get
        Set(ByVal Value As Short)
            Piastra.NumColl(i) = Value
            ptNumColl(i) = Value
        End Set
    End Property
    Public Property Verbose() As Boolean
        Get
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.Verbose. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            Verboso = Piastra.Verbose
            Verbose = Verboso
        End Get
        Set(ByVal Value As Boolean)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.Verbose. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            Piastra.Verbose = Value
            ptVerbose = Value
        End Set
    End Property
    Public Property ProgDiffPr() As Boolean
        Get
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.ProgDiffPr. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            ProgDiffPr = Piastra.ProgDiffPr
        End Get
        Set(ByVal Value As Boolean)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.ProgDiffPr. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            Piastra.ProgDiffPr = Value
            ptProgDiffPr = Value
        End Set
    End Property
    Public Property BiFlangiata() As Boolean
        Get
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.BiFlangiata. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            BiFlangiata = Piastra.BiFlangiata
        End Get
        Set(ByVal Value As Boolean)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.BiFlangiata. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            Piastra.BiFlangiata = Value
        End Set
    End Property
    Public Property VacuumTS() As Boolean
        Get
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.VacuumTS. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            VacuumTS = Piastra.VacuumTS
        End Get
        Set(ByVal Value As Boolean)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.VacuumTS. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            Piastra.VacuumTS = Value
            ptVacuumTS = Value
        End Set
    End Property
    Public Property VacuumSS() As Boolean
        Get
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.VacuumSS. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            VacuumSS = Piastra.VacuumSS
        End Get
        Set(ByVal Value As Boolean)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.VacuumSS. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            Piastra.VacuumSS = Value
            ptVacuumSS = Value
        End Set
    End Property
    Public Property SicBullp(ByVal i As Short) As Single
        Get
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.SicBullp. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            SicBullp = Piastra.SicBullp(i)
        End Get
        Set(ByVal Value As Single)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.SicBullp. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            Piastra.SicBullp(i) = Value
            ptSicBullp(i) = Value
        End Set
    End Property
    Public Property UL() As Single
        Get
            UL = ptUL
        End Get
        Set(ByVal Value As Single)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.UL. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            Piastra.UL = Value
            ptUL = Value
        End Set
    End Property
    Public Property TSheDes() As Single
        Get
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.TSheDes. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            TSheDes = Piastra.TSheDes
        End Get
        Set(ByVal Value As Single)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.TSheDes. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            Piastra.TSheDes = Value
            ptTSheDes = Value
        End Set
    End Property
    Public Property TSheThk() As Single
        Get
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.TSheThk. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            TSheThk = Piastra.TSheThk
        End Get
        Set(ByVal Value As Single)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.TSheThk. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            Piastra.TSheThk = Value
            ptTSheThk = Value
        End Set
    End Property
    Public WriteOnly Property UniMis() As Short
        Set(ByVal Value As Short)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.UniMis. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            Piastra.UniMis = Value
        End Set
    End Property
    Public Property TExtThk() As Single
        Get
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.TExtThk. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            TExtThk = Piastra.TExtThk
        End Get
        Set(ByVal Value As Single)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.TExtThk. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            Piastra.TExtThk = Value
            ptTExtThk = Value
        End Set
    End Property
    Public Property TubSpess() As Single
        Get
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.TubSpess. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            TubSpess = Piastra.TubSpess
        End Get
        Set(ByVal Value As Single)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.TubSpess. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            Piastra.TubSpess = Value
            ptTubSpess = Value
        End Set
    End Property
    Public Property TubDiam() As Single
        Get
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.TubDiam. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            TubDiam = Piastra.TubDiam
        End Get
        Set(ByVal Value As Single)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.TubDiam. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            Piastra.TubDiam = Value
            ptTubDiam = Value
        End Set
    End Property
    Public Property TubPass() As Single
        Get
            Select Case TipoPT
                Case 1
                    TubPass = CType(Piastra, wn_UTEMA).TubPass
                Case 2
                    TubPass = CType(Piastra, wn_FTC).TubPass
            End Select
        End Get
        Set(ByVal Value As Single)
            Select Case TipoPT
                Case 1
                    CType(Piastra, wn_UTEMA).TubPass = Value
                Case 2
                    CType(Piastra, wn_FTC).TubPass = Value
            End Select
            ptTubPass = Value
        End Set
    End Property
    Public Property MatPias(ByVal i As Short) As String
        Get
            Select Case TipoPT
                Case 1
                    MatPias = CType(Piastra, wn_UTEMA).MatPias(i)
                Case 2
                    MatPias = CType(Piastra, wn_FTC).MatPias(i)
            End Select
        End Get
        Set(ByVal Value As String)
            Select Case TipoPT
                Case 1
                    CType(Piastra, wn_UTEMA).MatPias(i) = Value
                Case 2
                    CType(Piastra, wn_FTC).MatPias(i) = Value
            End Select
            ptMatPias(i) = Value
        End Set
    End Property
    Public Property ltxperc() As Boolean
        Get
            ltxperc = Problem(IndProbl).ltxperc
        End Get
        Set(ByVal Value As Boolean)
            Problem(IndProbl).ltxperc = Value
        End Set
    End Property
    Public Property ltx() As Single
        Get
            ltx = Problem(IndProbl).ltx
        End Get
        Set(ByVal Value As Single)
            Problem(IndProbl).ltx = Value
        End Set
    End Property
    Public Property MatBull(ByVal i As Short) As String
        Get
            Select Case TipoPT
                Case 1
                    MatBull = CType(Piastra, wn_UTEMA).MatBull(i)
                Case 2
                    MatBull = CType(Piastra, wn_FTC).MatBull(i)
            End Select
        End Get
        Set(ByVal Value As String)
            Select Case TipoPT
                Case 1
                    CType(Piastra, wn_UTEMA).MatBull(i) = Value
                Case 2
                    CType(Piastra, wn_FTC).MatBull(i) = Value
            End Select
            ptMatBull(i) = Value
        End Set
    End Property
    Public Property TipoPias(ByVal i As Short) As String
        Get
            Select Case TipoPT
                Case 1
                    TipoPias = CType(Piastra, wn_UTEMA).TipoPias(i)
                Case 2
                    TipoPias = CType(Piastra, wn_FTC).TipoPias(i)
            End Select
        End Get
        Set(ByVal Value As String)
            Select Case TipoPT
                Case 1
                    CType(Piastra, wn_UTEMA).TipoPias(i) = Value
                Case 2
                    CType(Piastra, wn_FTC).TipoPias(i) = Value
            End Select
            ptTipoPias(i) = Value
        End Set
    End Property
    Public Property EquDiam() As Single
        Get
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.EquDiam. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            EquDiam = Piastra.EquDiam
        End Get
        Set(ByVal Value As Single)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.EquDiam. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            Piastra.EquDiam = Value
            ptEquDiam = Value
        End Set
    End Property
    Public Property CavChan() As Single
        Get
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.CavChan. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            CavChan = Piastra.CavChan
        End Get
        Set(ByVal Value As Single)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.CavChan. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            Piastra.CavChan = Value
            ptCavChan = Value
        End Set
    End Property
    Public Property CavShel() As Single
        Get
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.CavShel. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            CavShel = Piastra.CavShel
        End Get
        Set(ByVal Value As Single)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.CavShel. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            Piastra.CavShel = Value
            ptCavShel = Value
        End Set
    End Property
    Public Property GrvChan() As Single
        Get
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.GrvChan. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            GrvChan = Piastra.GrvChan
        End Get
        Set(ByVal Value As Single)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.GrvChan. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            Piastra.GrvChan = Value
            ptGrvChan = Value
        End Set
    End Property
    Public Property GrvShel() As Single
        Get
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.GrvShel. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            GrvShel = Piastra.GrvShel
        End Get
        Set(ByVal Value As Single)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.GrvShel. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            Piastra.GrvShel = Value
            ptGrvShel = Value
        End Set
    End Property
    Public Property CavChan1() As Single
        Get
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.CavChan1. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            CavChan1 = Piastra.CavChan1
        End Get
        Set(ByVal Value As Single)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.CavChan1. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            Piastra.CavChan1 = Value
            ptCavChan = Value
        End Set
    End Property
    Public Property CavShel1() As Single
        Get
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.CavShel1. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            CavShel1 = Piastra.CavShel1
        End Get
        Set(ByVal Value As Single)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.CavShel1. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            Piastra.CavShel1 = Value
            ptCavShel = Value
        End Set
    End Property
    '------------------------------------------
    Public Property BoltCiD(ByVal i As Short) As Single
        Get
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.BoltCiD. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            BoltCiD = Piastra.BoltCiD(i)
        End Get
        Set(ByVal Value As Single)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.BoltCiD. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            Piastra.BoltCiD(i) = Value
            ptBoltCiD(i) = Value
        End Set
    End Property
    Public Property AreBolt(ByVal i As Short) As Single
        Get
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.AreBolt. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            AreBolt = Piastra.AreBolt(i)
        End Get
        Set(ByVal Value As Single)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.AreBolt. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            Piastra.AreBolt(i) = Value
            ptAreBolt(i) = Value
        End Set
    End Property
    Public Property BSpcMin(ByVal i As Short) As Single
        Get
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.BSpcMin. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            BSpcMin = Piastra.BSpcMin(i)
        End Get
        Set(ByVal Value As Single)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.BSpcMin. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            Piastra.BSpcMin(i) = Value
            ptBSpcMin(i) = Value
        End Set
    End Property
    Public Property BRadMin(ByVal i As Short) As Single
        Get
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.BRadMin. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            BRadMin = Piastra.BRadMin(i)
        End Get
        Set(ByVal Value As Single)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.BRadMin. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            Piastra.BRadMin(i) = Value
            ptBRadMin(i) = Value
        End Set
    End Property
    Public Property FattBoltSy(ByVal i As Short) As Single
        Get
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.FattBoltSy. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            FattBoltSy = Piastra.FattBoltSy(i)
        End Get
        Set(ByVal Value As Single)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.FattBoltSy. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            Piastra.FattBoltSy(i) = Value
            ptFattBoltSy(i) = Value
        End Set
    End Property
    Public Property DiffPIese(ByVal i As Short) As Boolean
        Get
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.DiffPIese. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            DiffPIese = Piastra.DiffPIese(i)
        End Get
        Set(ByVal Value As Boolean)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.DiffPIese. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            Piastra.DiffPIese(i) = Value
            ptDiffPIese(i) = Value
        End Set
    End Property
    Public Property CRUSH(ByVal i As Short) As Boolean
        Get
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.CRUSH. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            CRUSH = Piastra.CRUSH(i)
        End Get
        Set(ByVal Value As Boolean)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.CRUSH. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            Piastra.CRUSH(i) = Value
            ptCRUSH(i) = Value
        End Set
    End Property
    Public Property FLEX() As Boolean
        Get
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.FLEX. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            FLEX = Piastra.FLEX
        End Get
        Set(ByVal Value As Boolean)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.FLEX. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            Piastra.FLEX = Value
            ptFLEX = Value
        End Set
    End Property
    Public Property mart() As Boolean
        Get
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.mart. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            mart = Piastra.mart
        End Get
        Set(ByVal Value As Boolean)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.mart. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            Piastra.mart = Value
            ptmart = Value
        End Set
    End Property
    Public Property BullDistinti() As Boolean
        Get
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.BullDistinti. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            BullDistinti = Piastra.BullDistinti
        End Get
        Set(ByVal Value As Boolean)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.BullDistinti. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            Piastra.BullDistinti = Value
            ptBullDistinti = Value
        End Set
    End Property

    Public Property BullIndip() As Boolean
        Get
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.BullIndip. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            BullIndip = Piastra.BullIndip
        End Get
        Set(ByVal Value As Boolean)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.BullIndip. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            Piastra.BullIndip = Value
            ptBullIndip = Value
        End Set
    End Property
    Public Property Rapporto(ByVal i As Short) As Single
        Get
            Dim R As Single
            On Error GoTo ErrPr
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.Rapporto. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            R = Piastra.Rapporto(i)
            If Not (R >= 0 And R <= 1) Then R = 0
ExPr:       On Error GoTo 0
            Rapporto = R 'Piastra.Rapporto
            Exit Property
ErrPr:      R = 0
            Resume ExPr
        End Get
        Set(ByVal Value As Single)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.Rapporto. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            Piastra.Rapporto(i) = Value
            ptRapporto(i) = Value
        End Set
    End Property
    Public Property AllFRoo() As Single
        Get
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.AllFRoo. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            AllFRoo = Piastra.AllFRoo
        End Get
        Set(ByVal Value As Single)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.AllFRoo. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            Piastra.AllFRoo = Value
            ptAllFRoo = Value
        End Set
    End Property
    Public Property AllFOpe() As Single
        Get
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.AllFOpe. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            AllFOpe = Piastra.AllFOpe
        End Get
        Set(ByVal Value As Single)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.AllFOpe. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            Piastra.AllFOpe = Value
            ptAllFOpe = Value
        End Set
    End Property
    Public Property AllBRoo(ByVal i As Short) As Single
        Get
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.AllBRoo. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            AllBRoo = Piastra.AllBRoo(i)
        End Get
        Set(ByVal Value As Single)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.AllBRoo. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            Piastra.AllBRoo(i) = Value
            ptAllBRoo(i) = Value
        End Set
    End Property
    Public Property Calc7133() As Boolean
        Get
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.Calc7133. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            Calc7133 = Piastra.Calc7133
        End Get
        Set(ByVal Value As Boolean)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.Calc7133. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            Piastra.Calc7133 = Value
        End Set
    End Property
    Public Property AllBOpe(ByVal i As Short) As Single
        Get
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.AllBOpe. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            AllBOpe = Piastra.AllBOpe(i)
        End Get
        Set(ByVal Value As Single)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.AllBOpe. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            Piastra.AllBOpe(i) = Value
            ptAllBOpe(i) = Value
        End Set
    End Property
    Public Property OTL() As Single
        Get
            OTL = Piastra.OTL
        End Get
        Set(ByVal Value As Single)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.OTL. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            Piastra.OTL = Value
            ptOTL = Value
        End Set
    End Property
    Public Property TipoGiunto() As Short
        Get
            If TipoPT = 2 Then TipoGiunto = CType(Piastra, wn_FTC).TipoGiunto
        End Get
        Set(ByVal Value As Short)
            If TipoPT = 2 Then CType(Piastra, wn_FTC).TipoGiunto = Value
        End Set
    End Property
    Public Property PDesChan() As Single
        Get
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.PDesChan. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            PDesChan = Piastra.PDesChan
        End Get
        Set(ByVal Value As Single)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.PDesChan. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            Piastra.PDesChan = Value
            ptPDesChan = Value
        End Set
    End Property
    Public Property PDesShel() As Single
        Get
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.PDesShel. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            PDesShel = Piastra.PDesShel
        End Get
        Set(ByVal Value As Single)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.PDesShel. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            Piastra.PDesShel = Value
            ptPDesShel = Value
        End Set
    End Property
    Public Property PHTChan() As Single
        Get
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.PHTChan. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            PHTChan = Piastra.PHTChan
        End Get
        Set(ByVal Value As Single)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.PHTChan. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            Piastra.PHTChan = Value
            ptPHTChan = Value
        End Set
    End Property
    Public Property PHTShel() As Single
        Get
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.PHTShel. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            PHTShel = Piastra.PHTShel
        End Get
        Set(ByVal Value As Single)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.PHTShel. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            Piastra.PHTShel = Value
            ptPHTShel = Value
        End Set
    End Property
    Public Property CorChan() As Single
        Get
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.CorChan. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            CorChan = Piastra.CorChan
        End Get
        Set(ByVal Value As Single)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.CorChan. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            Piastra.CorChan = Value
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.CorChan. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            ptCorChan = Piastra.CorChan
        End Set
    End Property
    Public Property CorShel() As Single
        Get
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.CorShel. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            CorShel = Piastra.CorShel
        End Get
        Set(ByVal Value As Single)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.CorShel. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            Piastra.CorShel = Value
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.CorShel. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            ptCorShel = Piastra.CorShel
        End Set
    End Property
    Public Property DiffPress() As Single
        Get
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.DiffPress. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            DiffPress = Piastra.DiffPress
        End Get
        Set(ByVal Value As Single)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.DiffPress. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            Piastra.DiffPress = Value
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.DiffPress. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            ptDiffPress = Piastra.DiffPress
        End Set
    End Property
    Public Property DiffPressHT() As Single
        Get
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.DiffPressHT. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            DiffPressHT = Piastra.DiffPressHT
        End Get
        Set(ByVal Value As Single)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.DiffPressHT. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            Piastra.DiffPressHT = Value
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.DiffPressHT. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            ptDiffPressHT = Piastra.DiffPressHT
        End Set
    End Property
    Public Property Destemp() As Single
        Get
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.Destemp. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            Destemp = Piastra.Destemp
        End Get
        Set(ByVal Value As Single)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.Destemp. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            Piastra.Destemp = Value
            ptDesTemp = Value
        End Set
    End Property
    Public Property FlChanDati(ByVal i As Short) As Object
        Get
            FlChanDati = Piastra.FlChanDati(i)
        End Get
        Set(ByVal Value As Object)
            Piastra.FlChanDati(i) = Value
            If i < 7 Or i > 8 Then
                ptFlChan(i) = Value
            Else
                ptFlChanS(i - 6) = Value
            End If
        End Set
    End Property
    Public ReadOnly Property bdice() As Short
        Get
            bdice = DatiInt(IndProbl).bdice
        End Get
    End Property
    Public Property SlChanDati(ByVal i As Short) As Object
        Get
            SlChanDati = Piastra.SlChanDati(i)
        End Get
        Set(ByVal Value As Object)
            Piastra.SlChanDati(i) = Value
            If i < 7 Or i > 8 Then
                ptSlChan(i) = Value
            Else
                ptSlChanS(i - 6) = Value
            End If
        End Set
    End Property
    Public Property FlShelDati(ByVal i As Short) As Object
        Get
            FlShelDati = Piastra.FlShelDati(i)
        End Get
        Set(ByVal Value As Object)
            Piastra.FlShelDati(i) = Value
            If i < 7 Or i > 8 Then
                ptFlShel(i) = Value
            Else
                ptFlShelS(i - 6) = Value
            End If
        End Set
    End Property
    Public Property SlShelDati(ByVal i As Short) As Object
        Get
            SlShelDati = Piastra.SlShelDati(i)
        End Get
        Set(ByVal Value As Object)
            Piastra.SlShelDati(i) = Value
            If i < 7 Or i > 8 Then
                ptSlShel(i) = Value
            Else
                ptSlShelS(i - 6) = Value
            End If
        End Set
    End Property
    Public Property TipoAA() As Short
        Get
            TipoAA = ptTipoAA
        End Get
        Set(ByVal Value As Short)
            Dim Visibile, VisTEMA As Boolean
            ptTipoAA = Value
            Problem(IndProbl).TipoAA = Value
            Visibile = True 'vNewValue > 0
            If mioPT Is Nothing Then mioPT = New frmPT
            With mioPT
                .LabelCil(115).Visible = Visibile
                .cmbCil(12).Visible = Visibile
                VisTEMA = ptRules <> 1
                Visibile = ptRules > 0
                .TEMAAA(Visibile, VisTEMA)
            End With
        End Set
    End Property
    Public Property Rules() As Short
        Get
            Rules = ptRules
        End Get
        Set(ByVal Value As Short)
            Dim VisAA, VisTEMA As Boolean
            ptRules = Value
            Piastra.Rules = Value
            If RulesAA Is Nothing And Value > 0 Then
                RulesAA = New wn_AA
                RulesAA.Padre = Me
            End If
            VisAA = Value > 0
            VisTEMA = Value <> 1
            If Not mioPT Is Nothing Then mioPT.TEMAAA(VisAA, VisTEMA)
        End Set
    End Property
    Public Property SPHT() As Short
        Get
            SPHT = Problem(IndProbl).SPHT
        End Get
        Set(ByVal Value As Short)
            Problem(IndProbl).SPHT = Value
        End Set
    End Property
    Public ReadOnly Property BoltSpc() As Single
        Get
            BoltSpc = DatiInt(IndProbl).BoltSpc
        End Get
    End Property
    Public ReadOnly Property fSicBul(ByVal i As Short) As Single
        Get
            fSicBul = Problem(IndProbl).Tiranti(i).fSicBul
        End Get
    End Property
    Public ReadOnly Property FlDatik(ByVal i As Short) As Single
        Get
            Select Case i
                Case 1 To 6, 13, 14, 19 : Return kLength
                Case 10, 12 : Return kPress
                Case 15, 18, 21, 22 : Return kForce
                Case Else : Return 1
            End Select
        End Get
    End Property
    Public Property FlDati(ByVal i As Short) As Object
        Get
            If kLato = 1 Then
                FlDati = FlShelDati(i)
            Else
                FlDati = FlChanDati(i)
            End If
        End Get
        Set(ByVal Value As Object)
            If kLato = 1 Then
                FlShelDati(i) = Value
            Else
                FlChanDati(i) = Value
            End If

        End Set
    End Property
    Public Property IBW() As Boolean
        Get
            IBW = Piastra.IBW
        End Get
        Set(ByVal Value As Boolean)
            Piastra.IBW = Value
        End Set
    End Property
    Public Property RadialExp() As Boolean
        Get
            Select Case TipoPT
                Case 1 : Return CType(Piastra, wn_UTEMA).RadialExp
                Case 2 : Return CType(Piastra, wn_FTC).RadialExp
            End Select
        End Get
        Set(ByVal Value As Boolean)
            Select Case TipoPT
                Case 1 : CType(Piastra, wn_UTEMA).RadialExp = Value
                Case 2 : CType(Piastra, wn_FTC).RadialExp = Value
            End Select
        End Set
    End Property
    Public Property diamIBW() As Single
        Get
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.diamIBW. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            diamIBW = Piastra.diamIBW
        End Get
        Set(ByVal Value As Single)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Piastra.diamIBW. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            Piastra.diamIBW = Value
        End Set
    End Property
    Public Sub Recover()
        Dim i As Short
        With Problem(IndProbl)
            .TipoAA = ptTipoAA
        End With
        Select Case TipoPT
            Case 1
                With CType(Piastra, wn_UTEMA)
                    .TubSpess = ptTubSpess
                    If VerificandoPI Then
                        .AllFRoo = ptAllFhyd
                    Else
                        .AllFRoo = ptAllFRoo
                    End If
                    .AllFOpe = ptAllFOpe
                    .OTL = ptOTL
                    .UL = ptUL
                    .CavChan = ptCavChan
                    .CavShel = ptCavShel
                    .CorChan = ptCorChan
                    .CorShel = ptCorShel
                    .DiffPress = ptDiffPress
                    .DiffPressHT = ptDiffPressHT
                    .Destemp = ptDesTemp
                    .EquDiam = ptEquDiam
                    .FlChanNome = ptFlChanNome
                    .FlShelNome = ptFlShelNome
                    .SlChanNome = ptSlChanNome
                    .SlShelNome = ptSlShelNome
                    .FLEX = ptFLEX
                    .FullBolt = ptFullBolt
                    For i = 1 To 4 : Involucr(kLato, jInvolucr).IndAccopp(i) = ptIndAccopp(i) : Next
                    For i = 1 To 4 : Involucr(kLato, jInvolucr).IndAccopp2(i) = ptIndAccopp2(i) : Next
                    .mart = ptmart
                    .PHTChan = ptPHTChan
                    .PHTShel = ptPHTShel
                    .PDesChan = ptPDesChan
                    .PDesShel = ptPDesShel
                    .ProgDiffPr = ptProgDiffPr
                    For i = 1 To 2
                        .CRUSH(i) = ptCRUSH(i)
                        .DiffPIese(i) = ptDiffPIese(i)
                        .DiNBull(i) = ptDiNBull(i)
                        .SicBullp(i) = ptSicBullp(i)
                        .FattBoltSy(i) = ptFattBoltSy(i)
                        .Rapporto(i) = ptRapporto(i)
                        .NumBolt(i) = ptNumBolt(i)
                        .NumColl(i) = ptNumColl(i)
                        .XFil(i) = ptXFil(i)
                        .AllBRoo(i) = ptAllBRoo(i)
                        .AllBOpe(i) = ptAllBOpe(i)
                        .AreBolt(i) = ptAreBolt(i)
                        .BoltCiD(i) = ptBoltCiD(i)
                        .BRadMin(i) = ptBRadMin(i)
                        .BSpcMin(i) = ptBSpcMin(i)
                    Next
                    .TipCalc = ptTipCalc
                    .TipPass = ptTipPass
                    .TSheDes = ptTSheDes
                    .TExtThk = ptTExtThk
                    .TubDiam = ptTubDiam
                    .TubPass = ptTubPass
                    .Verbose = ptVerbose
                    .VacuumTS = ptVacuumTS
                    .VacuumSS = ptVacuumSS
                    .BullDistinti = ptBullDistinti
                    .BullIndip = ptBullIndip
                    For i = 1 To 30
                        If i < 7 Or i > 8 Then
                            .FlChanDati(i) = ptFlChan(i)
                            .FlShelDati(i) = ptFlShel(i)
                            .SlChanDati(i) = ptSlChan(i)
                            .SlShelDati(i) = ptSlShel(i)
                        Else
                            .FlChanDati(i) = ptFlChanS(i - 6)
                            .FlShelDati(i) = ptFlShelS(i - 6)
                            .SlChanDati(i) = ptSlChanS(i - 6)
                            .SlShelDati(i) = ptSlShelS(i - 6)
                        End If
                    Next
                    For i = 1 To 2
                        .PHI(i) = ptPHI(i)
                        .wn(i) = ptwn(i)
                        .IndFac(i) = ptIndFac(i)
                        .TipGsk(i) = ptTipGsk(i)
                        .ClassGsk(i) = ptClassGsk(i)
                        .MatPias(i) = ptMatPias(i)
                        .MatBull(i) = ptMatBull(i)
                    Next
                End With
            Case 2
                With CType(Piastra, wn_FTC)
                    .TubSpess = ptTubSpess
                    If VerificandoPI Then
                        .AllFRoo = ptAllFhyd
                    Else
                        .AllFRoo = ptAllFRoo
                    End If
                    .AllFOpe = ptAllFOpe
                    .OTL = ptOTL
                    .UL = ptUL
                    .CavChan = ptCavChan
                    .CavShel = ptCavShel
                    .CorChan = ptCorChan
                    .CorShel = ptCorShel
                    .DiffPress = ptDiffPress
                    .DiffPressHT = ptDiffPressHT
                    .Destemp = ptDesTemp
                    .EquDiam = ptEquDiam
                    .FlChanNome = ptFlChanNome
                    .FlShelNome = ptFlShelNome
                    .SlChanNome = ptSlChanNome
                    .SlShelNome = ptSlShelNome
                    .FLEX = ptFLEX
                    .FullBolt = ptFullBolt
                    For i = 1 To 4 : Involucr(kLato, jInvolucr).IndAccopp(i) = ptIndAccopp(i) : Next
                    For i = 1 To 4 : Involucr(kLato, jInvolucr).IndAccopp2(i) = ptIndAccopp2(i) : Next
                    .mart = ptmart
                    .PHTChan = ptPHTChan
                    .PHTShel = ptPHTShel
                    .PDesChan = ptPDesChan
                    .PDesShel = ptPDesShel
                    .ProgDiffPr = ptProgDiffPr
                    For i = 1 To 2
                        .CRUSH(i) = ptCRUSH(i)
                        .DiffPIese(i) = ptDiffPIese(i)
                        .DiNBull(i) = ptDiNBull(i)
                        .SicBullp(i) = ptSicBullp(i)
                        .FattBoltSy(i) = ptFattBoltSy(i)
                        .Rapporto(i) = ptRapporto(i)
                        .NumBolt(i) = ptNumBolt(i)
                        .NumColl(i) = ptNumColl(i)
                        .XFil(i) = ptXFil(i)
                        .AllBRoo(i) = ptAllBRoo(i)
                        .AllBOpe(i) = ptAllBOpe(i)
                        .AreBolt(i) = ptAreBolt(i)
                        .BoltCiD(i) = ptBoltCiD(i)
                        .BRadMin(i) = ptBRadMin(i)
                        .BSpcMin(i) = ptBSpcMin(i)
                    Next
                    .TipCalc = ptTipCalc
                    .TipPass = ptTipPass
                    .TSheDes = ptTSheDes
                    .TExtThk = ptTExtThk
                    .TubDiam = ptTubDiam
                    .TubPass = ptTubPass
                    .Verbose = ptVerbose
                    .VacuumTS = ptVacuumTS
                    .VacuumSS = ptVacuumSS
                    .BullDistinti = ptBullDistinti
                    .BullIndip = ptBullIndip
                    For i = 1 To 30
                        If i < 7 Or i > 8 Then
                            .FlChanDati(i) = ptFlChan(i)
                            .FlShelDati(i) = ptFlShel(i)
                            .SlChanDati(i) = ptSlChan(i)
                            .SlShelDati(i) = ptSlShel(i)
                        Else
                            .FlChanDati(i) = ptFlChanS(i - 6)
                            .FlShelDati(i) = ptFlShelS(i - 6)
                            .SlChanDati(i) = ptSlChanS(i - 6)
                            .SlShelDati(i) = ptSlShelS(i - 6)
                        End If
                    Next
                    For i = 1 To 2
                        .PHI(i) = ptPHI(i)
                        .wn(i) = ptwn(i)
                        .IndFac(i) = ptIndFac(i)
                        .TipGsk(i) = ptTipGsk(i)
                        .ClassGsk(i) = ptClassGsk(i)
                        .MatPias(i) = ptMatPias(i)
                        .MatBull(i) = ptMatBull(i)
                    Next
                End With
        End Select
    End Sub
    Public Sub Store()
        Dim i As Short
        With Problem(IndProbl)
            ptTipoAA = .TipoAA
        End With
        With Piastra
            ptRules = .Rules
            ptTubSpess = .TubSpess
            If VerificandoPI Then
                ptAllFRoo = .AllFRoo
            Else
                ptAllFRoo = .AllFRoo
            End If
            ptAllFOpe = .AllFOpe
            ptOTL = .OTL
            ptUL = .UL
            ptCavChan = .CavChan
            ptCavShel = .CavShel
            ptCorChan = .CorChan
            ptCorShel = .CorShel
            ptDiffPress = .DiffPress
            ptDiffPressHT = .DiffPressHT
            ptDesTemp = .Destemp
            ptEquDiam = .EquDiam
            ptFlChanNome = .FlChanNome
            ptFlShelNome = .FlShelNome
            ptSlChanNome = .SlChanNome
            ptSlShelNome = .SlShelNome
            ptFLEX = .FLEX
            ptFullBolt = .FullBolt
            For i = 1 To 4 : ptIndAccopp(i) = Involucr(kLato, jInvolucr).IndAccopp(i) : Next
            For i = 1 To 4 : ptIndAccopp2(i) = Involucr(kLato, jInvolucr).IndAccopp2(i) : Next
            ptmart = .mart
            ptPHTChan = .PHTChan
            ptPHTShel = .PHTShel
            ptPDesChan = .PDesChan
            ptPDesShel = .PDesShel
            ptProgDiffPr = .ProgDiffPr
            For i = 1 To 2
                ptCRUSH(i) = .CRUSH(i)
                ptDiffPIese(i) = .DiffPIese(i)
                ptSicBullp(i) = .SicBullp(i)
                ptFattBoltSy(i) = .FattBoltSy(i)
                ptRapporto(i) = .Rapporto(i)
                ptNumBolt(i) = .NumBolt(i)
                ptNumColl(i) = .NumColl(i)
                ptAllBRoo(i) = .AllBRoo(i)
                ptAllBOpe(i) = .AllBOpe(i)
                ptAreBolt(i) = .AreBolt(i)
                ptBoltCiD(i) = .BoltCiD(i)
                ptBRadMin(i) = .BRadMin(i)
                ptBSpcMin(i) = .BSpcMin(i)
                ptDiNBull(i) = .DiNBull(i)
                ptXFil(i) = .XFil(i)
            Next
            ptTipCalc = .TipCalc
            ptTipPass = .TipPass
            ptTSheDes = .TSheDes
            ptTExtThk = .TExtThk
            ptTubDiam = .TubDiam
            ptTubPass = .TubPass
            ptVerbose = .Verbose
            ptVacuumTS = .VacuumTS
            ptVacuumSS = .VacuumSS
            ptBullDistinti = .BullDistinti
            ptBullIndip = .BullIndip
            For i = 1 To 30
                If i < 7 Or i > 8 Then
                    ptFlChan(i) = .FlChanDati(i)
                    ptFlShel(i) = .FlShelDati(i)
                    ptSlChan(i) = .SlChanDati(i)
                    ptSlShel(i) = .SlShelDati(i)
                Else
                    ptFlChanS(i - 6) = .FlChanDati(i)
                    ptFlShelS(i - 6) = .FlShelDati(i)
                    ptSlChanS(i - 6) = .SlChanDati(i)
                    ptSlShelS(i - 6) = .SlShelDati(i)
                End If
            Next
            For i = 1 To 2
                ptPHI(i) = .PHI(i)
                ptwn(i) = .wn(i)
                ptIndFac(i) = .IndFac(i)
                ptTipGsk(i) = .TipGsk(i)
                ptClassGsk(i) = .ClassGsk(i)
                ptMatPias(i) = .MatPias(i)
                ptMatBull(i) = .MatBull(i)
            Next
        End With
    End Sub
    Public Sub Salva(ByVal fs As FileStream)
        Dim bf As New Lancio.Legacy.Serialization.LegacyBinarySerializer
        bf.Serialize(fs, TipoPT)
        Select Case TipoPT
            Case 1
                CType(Piastra, wn_UTEMA).Salva(fs)
            Case 2
                CType(Piastra, wn_FTC).Salva(fs)
        End Select
        Store()
    End Sub
    Public Overloads Function Leggi(ByVal ifl As Short) As Boolean
        Dim i As Short
        Dim R As Boolean
        Select Case TipoPT
            Case 1 : R = CType(Piastra, wn_UTEMA).Leggi(ifl)
            Case 2 : R = CType(Piastra, wn_FTC).Leggi(ifl)
        End Select
        If Not R Then Exit Function
        Leggi = True
        For i = 1 To 4
            ptIndAccopp(i) = Involucr(kLato, jInvolucr).IndAccopp(i)
            ptIndAccopp2(i) = Involucr(kLato, jInvolucr).IndAccopp2(i)
        Next
        Store()
    End Function
    Public Overloads Function Leggi(ByVal fs As FileStream) As Boolean
        Dim i As Short
        Dim R As Boolean
        Select Case TipoPT
            Case 1 : R = CType(Piastra, wn_UTEMA).Leggi(fs)
            Case 2 : R = CType(Piastra, wn_FTC).Leggi(fs)
        End Select
        If Not R Then Exit Function
        Leggi = True
        For i = 1 To 4
            ptIndAccopp(i) = Involucr(kLato, jInvolucr).IndAccopp(i)
            ptIndAccopp2(i) = Involucr(kLato, jInvolucr).IndAccopp2(i)
        Next
        Store()
    End Function
    Public Function Calcola() As Short
        Dim Res1, Res, i As Short
        Dim OK As Boolean
        Dim nLegami As Short
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        If Not VerificandoPI Then
            For i = 1 To 4
                Involucr(kLato, jInvolucr).MAWP(i - 1) = clsTrigon.Infinito
                Involucr(kLato, jInvolucr).MAWP2(i - 1) = clsTrigon.Infinito
            Next
        End If
        OK = True
        nLegami = 0
        If GetPiastra() = 1 Then
            With Involucr(kLato, jInvolucr)
                For i = 1 To 4
                    If .IndAccopp(i) <> CType(objMemb(.IndObject), wn_PT).IndAccopp(i) Then OK = False
                    If .IndAccopp(i) > 0 Then nLegami = nLegami + 1
                Next
            End With
            If Not OK And Not ContinuoAuto Then
                If MostraAiuto(IDH_PT_LEGAMI1, RoutBase1.ChiaviMess.MessHelpButton + RoutBase1.ChiaviMess.MessQuestion + RoutBase1.ChiaviMess.MessYesNo) = RoutBase1.ChiaviMess.Messno Then Exit Function
            End If
            'SlChanDati(1) = -2 significa PT avvitata sul fondo della cassa
            If nLegami < 2 And SlChanDati(1) > -2 Or nLegami < 1 And SlChanDati(1) = -2 And Not ContinuoAuto Then '030506
                If MostraAiuto(IDH_PT_LEGAMI2, RoutBase1.ChiaviMess.MessHelpButton + RoutBase1.ChiaviMess.MessQuestion + RoutBase1.ChiaviMess.MessYesNo) = RoutBase1.ChiaviMess.Messno Then Exit Function
            End If
        End If
        OK = True
        Calcola = True
        InterrompiMAWP = False
        Res = True
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        If TipoPT = 2 Then mioRis = New frmRis
        If ptRules = 0 Or ptRules = 2 Then
            CalcoloInCorso = 0
            Res = CalcTEMA()
        End If
        Res1 = True
        Dim Risp As String = ""
        If TipoPT = 2 Then Risp = mioRis.Risposta
        If ptRules = 1 Or ptRules = 2 And Not Risp = "Annulla" Then
            CalcoloInCorso = 1
            If RulesAA Is Nothing Then
                RulesAA = New wn_AA
                RulesAA.Padre = Me
            End If
            RulesAA.InizPlas = False
            Select Case TipoAA
                Case 0 To 4, 30, 40 'tubi a U
                    Res1 = RulesAA.Calcola
                Case 5 To 8 'teste fisse
                    Res1 = CalcTEMA()
                Case 101 To 106 'AA-3.1(b)(1) to (6)
                    Res1 = CalcTEMA()
            End Select
        End If
        Calcola = Not (Res * Res1 = 0)
        If TipoPT = 2 Then mioRis.Dispose()
    End Function
    Public Function geomguar(ByRef mode As Short, Optional ByRef Lato As Short = 0, Optional ByRef pression As Single = 0) As Boolean
        'Public Function geomguar(Problem(IndProbl) As DatiGeneral, Fl As datiFlangia, DatiInt(IndProbl) As DatiCalc, Mode As Integer) As Boolean
        Dim bo, boinc As Single
        Dim junk As Short
        Dim B1, gef, HGY As Single
        Dim prpr As Single
        Dim Testo As String
        Dim Stringa(3) As String
        Dim Nmin As Short
        Dim Gmin, ctt, DBul As Single
        Dim HTM, HDM, HGM As Single
        Dim CBmin As Single
        geomguar = True
        If Problem(IndProbl).mart = 2 Then Exit Function
        If Lato > 0 Then
            Select Case Lato
                Case 1
                    Fl = FlShel(IndProbl)
                Case 2
                    Fl = FlChan(IndProbl)
            End Select
            prpr = pression
            Bulloni = Problem(IndProbl).Tiranti(1)
        Else
            If Problem(IndProbl).PDIFF = 0 Then '12-1-99
                prpr = Problem(IndProbl).DiffPress '11-1-99
            Else
                prpr = (Fl.PresDes * Problem(IndProbl).SPHT + (1 - Problem(IndProbl).SPHT) * Fl.PresHyT)
            End If
        End If
        If Fl.LargGua <= 0 Then
            MostraAiuto(IDH_PT_GUAR_N)
            geomguar = False
            Exit Function
        End If
        If Fl.DmedGua <= 0 Then
            MostraAiuto(IDH_PT_GUAR_D)
            geomguar = False
            Exit Function
        End If
        On Error GoTo ErrgeomG
998:
        If Fl.PHI = 0 Then Exit Function
        If Fl.PHI = 1 Then bo = Fl.LargGua / 2
        If Fl.PHI = 2 Then bo = (Fl.wn + Fl.LargGua) / 4
        If Fl.PHI = 3 Then bo = (Fl.wn + 3 * Fl.LargGua) / 8
        If Fl.PHI = 4 Then bo = Fl.LargGua / 4
        If Fl.PHI = 5 Then bo = 3 * Fl.LargGua / 8
        If Fl.PHI = 6 Then bo = 7 * Fl.LargGua / 16
        If Fl.PHI = 7 Then bo = Fl.LargGua / 8
        boinc = bo / inc
        Fl.bo = bo
        If boinc < 0.25 Then
997:        B1 = boinc
            gef = Fl.DmedGua
        Else
            B1 = 0.5 * System.Math.Sqrt(boinc)
            gef = Fl.DmedGua + Fl.LargGua - 2 * B1 * inc
        End If
999:
        Fl.gefinc = gef / inc
        Fl.b1inc = B1
        '------------------------------------------------------------------------
        Fl.wmt = Fl.btrav * Fl.ltrav / inc / inc * Fl.ytrav
        HGY = (pi * B1 * gef / inc * Fl.y) + Fl.wmt
        'If pression = 0 Then prpr = (Fl.PresDes * Problem(IndProbl).SPHT + (1 - Problem(IndProbl).SPHT) * Fl.PresHyT) Else prpr = pression
        Fl.HGP = (2 * (pi * B1 * gef / inc * Fl.mguar + Fl.btrav / 2 * Fl.ltrav * Fl.mtrav / inc / inc) * prpr)
        Fl.H = ((pi / 4) * (gef / inc) ^ 2 * prpr)
        If Problem(IndProbl).mart < 2 Then
            Fl.wm1 = Fl.H + Fl.HGP '---Required bolt load operating (or H.T.)
            Fl.wm2 = HGY '---Required bolt load seating
        End If
1000:
        If Bulloni.fSicBul = 0 Then Bulloni.fSicBul = 1
        If Bulloni.AllBOpe * Bulloni.AllBRoo = 0 Then
            MessageBox.Show("L'ammissibile dei tiranti inerenti alla piastra tubiera non è definito")
            geomguar = False : Exit Function
        End If
        Fl.am1 = Fl.wm1 / (Bulloni.AllBOpe * Bulloni.fSicBul)
        Fl.am2 = Fl.wm2 / (Bulloni.AllBRoo * Bulloni.fSicBul)
1010:   If Fl.am1 > Fl.am2 Then Fl.am = Fl.am1 Else Fl.am = Fl.am2 '---Required bolt area
        DatiInt(IndProbl).AreaBol = Bulloni.NumBolt * Bulloni.AreBolt * inc * inc
        Fl.AreaBol = DatiInt(IndProbl).AreaBol
        If Fl.AreaBol < Fl.am Then
            Testo = "La sezione bulloni prevista e' insufficiente|"
            If Fl.PresDes = Problem(IndProbl).PEsChan Or mode > 0 Then
                Testo = Testo & " per la tenuta lato cassa.|"
            Else
                Testo = Testo & " per la tenuta lato mantello.|"
            End If
            Testo = Testo & "Sba = " & GlobalRoutines.myStr(Bulloni.AllBRoo, 6, 2, False) & " psi      Sbo =" & GlobalRoutines.myStr(Bulloni.AllBOpe, 6, 2, False) & " psi"
            Testo = Testo & "|N° " & Str(Bulloni.NumBolt) & " tiranti da " & Bulloni.DiNBull
            If mode = 0 And DatiInt(IndProbl).bdice = 0 And Fl.PresDes = Problem(IndProbl).PEsShel Then
                Testo = Testo & "|di cui " & Str(System.Math.Abs(Bulloni.NumColl)) & " con collare."
            End If
            Testo = Testo & "|          area totale   = " & GlobalRoutines.myStr(Fl.AreaBol, 8, 2, False) & " inches2"
            Testo = Testo & "|  area minima richiesta = " & GlobalRoutines.myStr(Fl.am, 8, 2, False) & " inches2"
            Testo = Testo & "|       Cosa vuoi fare ? "
            Stringa(1) = "Modificare i bulloni"
            Stringa(2) = "Confermare i dati impostati"
            If mode < 2 Then
                junk = Monitor.Motore.Quale(2, "Controllo area tiranti", Stringa, "", 1, Testo)
            Else
                junk = 2
            End If
            Select Case junk
                Case 1
                    mioPT = New frmPT
                    mioPT.ShowDialog() ' If Not DatiBull(Problem(IndProbl), "Tiranti", Mode) Then Fl.SWITCH = 1
                    mioPT.Dispose()
                    mioPT = Nothing
                Case 2
                    Fl.SWITCH_Renamed = 1
                Case Else : geomguar = False : Exit Function
            End Select
        End If
        Fl.AreaCrs = 2 * pi * Fl.y * Fl.gefinc * Fl.LargGua / (inc * Bulloni.AllBRoo)
1001:   Fl.SWCRUS = 0
        If DatiInt(IndProbl).AreaBol > Fl.AreaCrs And Fl.AreaCrs > 0 Then
1002:       Nmin = Int(Fl.LargGua * DatiInt(IndProbl).AreaBol / Fl.AreaCrs) + 1 'larghezza "non crushing"
            ctt = Problem(IndProbl).CavChan : If Problem(IndProbl).CorChan > Problem(IndProbl).CavChan Then ctt = Problem(IndProbl).CorChan
            Gmin = Int(Fl.DintFla + 2 * ctt + Nmin) + 1 'diam int.flangia+2*corr
1004:       DBul = 4 / pi * System.Math.Sqrt(Bulloni.AreBolt * inc * inc)
            CBmin = Int(Gmin + 15 + DBul) + 1
            If Bulloni.BoltCiD > CBmin Then CBmin = Bulloni.BoltCiD
            If Fl.gefinc * inc > Gmin Then Gmin = Fl.gefinc * inc
            Testo = "Pericolo di schiacciamento della guarnizione."
            Testo = Testo & "|per la flangia" & RTrim(Fl.Identif)
            Testo = Testo & "|       Cosa vuoi fare ? "
            Testo = Testo & "|N guarnizione (impostato) = " & GlobalRoutines.myStr(Fl.LargGua, 6, 2, False) & "      N minimo = " & GlobalRoutines.myStr(CSng(Nmin), 6, 2, False)
            Testo = Testo & "|G guarnizione (impostato) = " & GlobalRoutines.myStr(Fl.gefinc * inc, 6, 2, False) & "      G minimo = " & GlobalRoutines.myStr(CSng(Gmin), 6, 2, False)
            Testo = Testo & "|CB            (impostato) = " & GlobalRoutines.myStr(Bulloni.BoltCiD, 6, 2, False) & "     CB minimo = " & GlobalRoutines.myStr(CSng(CBmin), 6, 2, False)
            Testo = Testo & "|       Cosa vuoi fare ? "
            Stringa(1) = "Modificare i dati"
            Stringa(2) = "Confermare i dati minimi calcolati"
            Stringa(3) = "Confermare i dati impostati"
            If Problem(IndProbl).CRUSH = 0 Then junk = Monitor.Motore.Quale(3, "Controllo dati guarnizione", Stringa, "", 1, Testo) Else junk = 3
            Select Case junk
                Case 1
                    If mode = 0 Then
                        If Not DatiFlange() Then Fl.SWCRUS = 1
                    Else
                        If Not datiFlangia("Flangia cassa") Then Fl.SWCRUS = 1
                    End If
                Case 2
                    Bulloni.BoltCiD = CBmin
                    Fl.gefinc = Gmin / inc
                    Fl.LargGua = Nmin
                Case 3
                    Fl.SWCRUS = 1
                Case Else : geomguar = False : Exit Function
            End Select
        End If
        '-----------------------------------------------------------------------
        If Lato > 0 And mode = 0 Then
            Select Case Lato
                Case 1
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto FlShel(IndProbl). Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                    FlShel(IndProbl) = Fl
                Case 2
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto FlChan(IndProbl). Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                    FlChan(IndProbl) = Fl
            End Select
        End If
        If mode = 0 Then Exit Function
1110:   Fl.wot = 0.5 * (Fl.am + DatiInt(IndProbl).AreaBol) * Bulloni.AllBRoo
        If Problem(IndProbl).SERRA = 0 Then Fl.wot = DatiInt(IndProbl).AreaBol * Bulloni.AllBRoo
        '   wot: design bolt load in operating
        '-----------------------------------------------------------------
        BracFla()
        '1150            Fl.fHd = pression * (PI * (Fl.DintFla / inc) ^ 2 / 4)
        '                Fl.fHt = pression * PI / 4 * (Fl.gefinc ^ 2 - (Fl.DintFla / inc) ^ 2)
1150:   Fl.fHd = prpr * (pi * (Fl.DintFla / inc) ^ 2 / 4)
        Fl.fHt = prpr * pi / 4 * (Fl.gefinc ^ 2 - (Fl.DintFla / inc) ^ 2)
        Fl.fHg = Fl.wot - Fl.fHd - Fl.fHt
        HDM = Fl.hHd * Fl.fHd
        HTM = Fl.hHt * Fl.fHt
        HGM = Fl.hHg * Fl.fHg
        Fl.m1 = HDM + HTM + HGM
        Fl.m2 = Fl.wot * Fl.hHg
ExitGeom:
        If Lato > 0 Then
            Select Case Lato
                Case 1
                    FlShel(IndProbl) = Fl
                Case 2
                    FlChan(IndProbl) = Fl
            End Select
        End If
ExF:
        Exit Function
ErrgeomG:
        If Err.Number = 6 And Erl() = 1000 Then
            Testo = " Non sono stati calcolati correttamente|"
            Testo = Testo & "gli ammissibili dei tiranti, oppure non|"
            Testo = Testo & "è stato fonito il fattore di sicurezza.|"
            MessageBox.Show(Monitor.Motore.Inizio.ConvertiCr(Testo))
            geomguar = False
            Resume ExitGeom
        End If
        'Resume
        MessageBox.Show("Errore in geomguar " & Err.Description)
        Resume
        geomguar = False
        Resume ExF
    End Function
    Function DatiFlange() As Boolean
        Dim Ris As Boolean
        DatiFlange = True
        Select Case DatiInt(IndProbl).bdice
            Case 1 : Ris = datiFlangia("Flangia lato cassa   ")
                If Not Ris Then DatiFlange = Ris : Exit Function
                DatiFlange = DatiSaldato("Saldatura al mantello")
            Case 2 : Ris = datiFlangia("Flangia lato mantello")
                If Not Ris Then DatiFlange = Ris : Exit Function
                DatiFlange = DatiSaldato("Saldatura alla cassa")
            Case 0
                Ris = datiFlangia("Flangia lato tubi")
                If Not Ris Then DatiFlange = Ris : Exit Function
                DatiFlange = datiFlangia("Flangia lato mant")
        End Select
    End Function
    Private Function datiFlangia(ByRef Titolo As String) As Boolean
        mioPT = New frmPT
        mioPT.ShowDialog()
        mioPT.Dispose()
        mioPT = Nothing
    End Function
    Public Sub BracFla()
        Dim HG, rrr As Single
        HG = 0.5 * (Bulloni.BoltCiD - Fl.gefinc * inc)
        Fl.hHg = HG / inc
        If Fl.CodoMax > 0 Then
            rrr = ((Bulloni.BoltCiD - Fl.DintFla) / 2 - Fl.CodoMax) / inc
            Fl.hHd = rrr + 0.5 * Fl.CodoMax / inc
            Fl.hHt = (rrr + Fl.CodoMax / inc + Fl.hHg) / 2
            Fl.rrr = rrr
        Else
            Fl.hHt = Fl.hHg
            Fl.hHd = (Bulloni.BoltCiD - Fl.DintFla) / 2 / inc
            Fl.rrr = 0.0!
        End If
    End Sub
    Private Function DatiSaldato(ByRef Titolo As String) As Boolean
        mioPT = New frmPT
        mioPT.ShowDialog()
        mioPT.Dispose()
        mioPT = Nothing
    End Function
    Public Sub New()
        MyBase.New()
        IndObj = Involucr(kLato, jInvolucr).IndObject
        Indprobl1 = NuovoIndProbl()
        IndProbl2 = NuovoIndProbl()
        lKlato = kLato
        lJinvolucr = jInvolucr
        Dim i As Short
        For i = 0 To 4
            ptIndAccopp(i) = -1
            ptIndAccopp2(i) = -1
        Next
    End Sub
    Public Sub SetPiastra(ByRef iP As Short, Optional ByRef controlla As Boolean = True)
        If TipoPT = 2 Then CType(Piastra, wn_FTC).SetPiastra(iP, controlla)
        PiastraAB = iP
        Select Case iP
            Case 0, 1 : IndProbl = Indprobl1
            Case 2 : IndProbl = IndProbl2
        End Select
    End Sub
    Public Function GetPiastra() As Short
        Select Case PiastraAB
            Case 0, 1 : GetPiastra = 1
            Case 2 : GetPiastra = 2
        End Select
    End Function
    Public Function CalcTEMA() As Short
        Dim Res As Short
        Dim PT As wn_FTC
        Select Case TipoPT
            Case 1
                With CType(Piastra, wn_UTEMA)
                    .Corrodi()
                    Res = .Esecuzione
                    If Res Then Res = .ScelSpes
                    .sCorrodi() '030506
                    If Res Then .Stampe()
                End With
            Case 2
                PT = CType(Piastra, wn_FTC)
                With PT
                    Select Case .CalcoloInCorso
                        Case 0 : mioRis.Text = "Calcolo fasci tubieri / piastre tubiere - Norme TEMA"
                        Case 1 : mioRis.Text = "Calcolo fasci tubieri / piastre tubiere - Norme UHX"
                    End Select
                    If .SoloDilat Then
                        .DiffPress = 0 : .Rear = 1
                        .SetPagFix()
                        If .Chiave = 1 Then Exit Function
                        If Not mioRis.Risposta = "Annulla" Then
                            If Config(0).CalcMAWP And Not VerificandoPI Then .MAWPcalc()
                            InterrompiMAWP = False
                            .StampaSp()
                        End If
                    ElseIf .Rear = 1 Or .Rear = 2 And .CalcoloInCorso = 1 Then
Rifa:                   .SetPagFix()
                        If .Chiave = 1 Then Exit Function
                        If InStr(mioRis.Risposta, "Non valido") > 0 Then
                            .Chiave = 1
                            If Not mioRis.Risposta = "Non valido1" Then .StampaSp()
                            Exit Function
                        End If
                        If mioRis.Risposta = "Ammazza" Then
                            mioRis.Hide()
                            .SetPagFix()
                            If mioRis.Risposta = "Annulla" Then CalcTEMA = True : Exit Function
                            If mioRis.Risposta = "F1" Then GoTo Cont
                            mioRis.TabStrip1_ClickEvent(mioRis.TabStrip1, New System.EventArgs)
                            mioRis.ShowDialog()
                            GoTo Rifa '.SetPagFix 'Set frmRis = Nothing
                        End If
Cont:                   If Not mioRis.Risposta = "Annulla" Then
                            Do While InStr(mioRis.Risposta, "Sw") > 0
                                If mioRis.PiastraB Then SetPiastra(2) Else SetPiastra(1)
                                .Calcoli2()
                                If mioRis.Risposta = "SwSi" Then .Sintesi(0)
                                mioRis.ShowDialog()
                            Loop
                            If Not mioRis.Risposta = "Annulla" Then
                                If Config(0).CalcMAWP And Not VerificandoPI Then .MAWPcalc()
                                InterrompiMAWP = False
                                .StampaSp()
                                Res = True
                            Else
                                Res = 0
                            End If
                        End If
                    Else
                        Res = (.Esegui = 0)
                        If Res = 0 Then Exit Function
                        If Not mioRis.Risposta = "Annulla" Then
                            If Config(0).CalcMAWP And Not VerificandoPI Then .MAWPcalc()
                            InterrompiMAWP = False
                            .StampaSp()
                        Else
                            Res = 0
                        End If
                    End If
                End With
        End Select
        CalcTEMA = Res ' True
    End Function
    Public Sub CopiaTiranti()
        If Not BullDistinti Then
            Problem(IndProbl).Tiranti(2) = Problem(IndProbl).Tiranti(1)
        End If
    End Sub
    Public Property CalcoloInCorso() As Short
        Get
            Select Case TipoPT
                Case 1 : Return CType(Piastra, wn_UTEMA).CalcoloInCorso
                Case 2 : Return CType(Piastra, wn_FTC).CalcoloInCorso
            End Select
        End Get
        Set(ByVal Value As Short)
            Select Case TipoPT
                Case 1 : CType(Piastra, wn_UTEMA).CalcoloInCorso = Value
                Case 2 : CType(Piastra, wn_FTC).CalcoloInCorso = Value
            End Select
        End Set
    End Property
End Class