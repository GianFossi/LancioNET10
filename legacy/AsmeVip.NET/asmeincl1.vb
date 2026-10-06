Option Strict Off
Option Explicit On
Imports System.Runtime.InteropServices
Module inclASME
    Public Structure typROTFL
        Public Arch As String
        Public Membr As String
        Public Mater As String
        Dim temp As Single
        Dim DiamInt As Single
        Dim DiamExt As Single
        Dim Spess As Single
        Dim g0 As Single
        Dim g1 As Single
        Dim hub As Single
        Dim E0 As Single
        Dim E1 As Single
        Dim W As Single
        Dim Press As Single
        Dim BC As Single
        Dim BoltL As Single
        Dim BoltN As Single
        Dim BoltA As Single
        Dim gef As Single
        Dim b0 As Single
        Dim n As Single
        Dim EE As Single
        Dim SpGuar As Single
        Public DiscoRam As String
        Public ArchDir As String
        Public Intest As String
        Public Norma As String
        Dim rapp As Single
        Dim J1 As Single
        Dim wm2 As Single
        Dim Estar As Single
        Dim nistar As Single
        Dim ts As Single
        Dim Thet0 As Single
        Dim Thet1 As Single
        Dim SpExt As Single
    End Structure
    Structure ASMERES
        Dim a As Single
        Dim Aa As Single
        Dim a1 As Single
        Dim AA1 As Single
        Dim a2 As Single
        Dim A2PROT As Single
        Dim A3 As Single
        Dim AA3 As Single
        Dim A4 As Single
        Dim SR As Single 'spess min a press ext.
        Dim AExt As Single
        Dim AAExt As Single
        Dim AllN As Single
        Public MatN As String
        Dim SpCop As Single 'spess min cop
        Dim SpCopA As Single 'spess adopted cop
        Dim Diam As Single 'diam cop vessel
        Dim CorrCop As Single
        Dim AllCop As Single
        Dim VerificandoPI As Short
        Public Pad As String
    End Structure
    Structure Str50
        Public Str_Renamed As String
    End Structure
    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.ANSI)> Structure asConfig
        Dim LatoProgetto As Short
        Dim TipCalc As Short
        Dim Verbose As Short
        Dim Ninvolucri As Short
        Dim DC As Short
        Dim US As Short
        Public DNjob As String
        Public lkStr As String
        Dim ms As Short
        Dim mv As Short
        Dim dogg As Single
        Dim di As Single
        Dim dns As Single
        Dim ES As Single
        Dim TNS As Single 'spessore dell'elemento longilineo
        Dim p0x As Single
        Dim tdx As Single
        Dim Vacuum As Short 'TRUE sotto vuoto
        Dim Intest As Short
        Dim tdxMDMT() As Single
        Dim pdxMDMT() As Single
        Dim pxExt As Single
        Dim txExt As Single
        Dim DensFluido As Single
        Dim NMWDT As Short
        Dim Versione As Short
        Public Item As String
        Dim CalcMAWP As Short
        Dim NumeroLati As Short
        Dim pxTest As Single
        Dim Corr As Single
        Dim CalcPI As Short
        Dim DiverseTemp As Short
        Dim SpecialRinf As Short
        Dim HTTestVert As Short '0 orizzontale 1 verticale
        Dim MetodoPI As Short '0 UG-99(b) 1 UG-99(c)
        Dim SistCoorCop As Short '0 polare 1 cartesiano
        Dim Efficienza As Single
        Dim VerifPI As Short '0 non si verifica; 1 si verifica
        Dim VerificandoPI As Short
        Public Pad As String
        Public Sub Initialize()
            ReDim tdxMDMT(2)
            ReDim pdxMDMT(2)
        End Sub
    End Structure
    Structure Nozzle '431
        Dim indice As Short 'pro NO sivo nei Record() materiale tronch.
        Dim InvolucroSU As Short
        Dim RecInd As Short
        Public Mark As String 'MK$
        Public Tipo As String
        Public MATE As String 'mn$
        Dim Rati As Short 'rtg
        Dim DiaN As Single 'dnn
        Dim DiOn As Single 'don
        Dim DiIn As Single 'din
        Dim Spess As Single 'tnn
        Dim EffN As Single 'en
        Dim ONn As Single 'ONn
        Dim CorrA As Single 'CN
        Dim AllN As Single 'sn
        Dim DCL As Single 'dcl
        Dim DTL As Single 'DTL
        Dim beta As Single 'beta
        Public Xacc As String 'x$
        Dim MUN As Single
        Dim LX As Single
        Dim HX As Single
        Dim LSDisp As Single
        Dim Padd As Single
        Dim PadT As Single
        Dim SWR As Short
        Dim MNT As Single
        Dim MAWP() As Single
        Dim inizio As Short
        Dim Fine As Short 'MAWPs(1 TO 1) AS SINGLE
        Dim Alfa As Single 'per bocchelli su fondi
        Dim LXdisp As Single
        Dim AllPad As Single
        Dim indiceF As Short 'tabella flange standard
        Dim RecIndF As Short 'indice materiale flangia
        Dim IndexF As Short 'Matdim e RecAPR
        Dim Risult As Short 'da ASME2
        Dim TransitionAngle As Single
        Dim R2 As Single 'PER DIV.2
        Dim IndiceP As Short
        Dim RecIndP As Short
        Dim Anomal As Single
        Dim ShThkNozArea As Single
        Dim DiamExt As Single
        Dim Altezza As Single
        Dim Spessore As Single
        Dim IndObject As Short
        Dim IndiceB As Short
        Dim RecIndB As Short
        Dim R1 As Single 'per div.2
        Dim Tdes As Single 'British
        Dim Pdes As Single 'British
        Public MateCop As String
        Dim alfaShell As Single
        Dim alfaNoz As Single
        Dim alfaPad As Single ' NON USATO
        Dim dtAD550f As Single
        Dim FlanNonStd As Short
        Dim AllNPI As Single
        Dim AllPadPI As Single
        Dim BNoRinf As Short
        Dim FactVicini As Single
        Public Pad As String
        Public Sub Initialize()
            ReDim MAWP(4)
        End Sub
    End Structure
    Structure NozzAd '166
        Dim TipAbutt As Short '1 through groove,2 through fillet,3 abutting groove 4 abutting fillet,5 intermedio
        Dim Protusion As Single
        Dim UW16 As Short '1(a)2(a-1)3(a-2)4(a-3)5(b)6(c)7(d)8(e)
        '9(f-1)10(f-2)11(f-3)12(f-4)13(g)14(h)
        '15(i)16(j)17(k)18(l)19(m)20(n)21(o)
        '22(p)23(q)24(r)25(s)26(t)27(u)
        Dim Gola41 As Single 'outward nozzle   min code
        Dim Gola42 As Single 'pad              min code
        Dim Gola43 As Single 'inward nozzle    min code
        Dim Leg41 As Single
        Dim Leg42 As Single
        Dim Leg43 As Single
        Dim Leg44 As Single 'groove nozzle/pad per sketch 23 e 24
        Dim W As Single
        Dim W11 As Single
        Dim W22 As Single
        Dim W33 As Single
        Dim WCompV As Single 'non usato
        Dim Fillets As Single
        Dim GrooTen As Single
        Dim GrooShe As Single
        Dim NozzShe As Single
        Dim Str_Renamed() As Single
        Dim i(,) As Short
        Dim Paths() As Single
        Dim Wcomp() As Single
        Public Sub Initialize()
            ReDim i(3, 3)
            ReDim Paths(3)
            ReDim Wcomp(3)
        End Sub
    End Structure
    Structure Involucro
        Dim indice() As Short 'prog NO ivo nei Record() (dimensionato per il
        'caso di cilindri in più virole)
        'per flangioni: 1 materiale flangia,2 materiale bulloni, 3 materiale g.
        Dim Tipo As Short '0 cilindro 1 fondo 2 cono 3 conoide 4 belt 5 flangione
        Public Mark As String
        Public MATE As String
        Dim Spess As Single 'tnn
        Dim ES As Single 'en
        Dim OS As Single 'ONn
        Dim cs As Single 'CN
        Dim SU As Single
        Dim S0 As Single
        Dim St As Single
        Dim inizio As Short
        Dim Fine As Short
        Dim ms As Short 'shell product  |tipo di fondo  (HT)|per i tubi tipo di giunto
        Dim xs As Short 'shell type     |per i tubi AW/MW
        Dim di As Single '                                |diametro grande  |diametro grande  |per i tubi tipo UW-20
        Dim dns As Single 'diametro pipe  |                |diametro piccolo |diametro piccolo
        Dim H0 As Single '               |inside depth    | R               |spessore fianchi
        Dim L0 As Single 'lunghezza cil  |Crown/sph.radius| R1              |lunghezza interna
        Dim R0 As Single 'lungh.eq.buckl.|knuckle radius  | ALFACON
        Public Suffix As String
        Dim RecInd() As Short
        Dim MAWP() As Single
        Public MWDTrule As String
        Public MWDTclause As String
        Dim MWDTtemp As Single
        Dim Escluso As Short
        Dim jmemb1 As Short 'cilindro lato grande di un cono| per i tubi numero di tipi di tubo
        Dim jmemb2 As Short 'cilindro lato piccolo di un cono
        Dim HydrDepth As Single
        Dim IndObject As Short
        Dim AccoppK As Short
        Dim AccoppJ As Short
        Dim DensFluido As Single
        Dim Destemp As Single
        Dim HydrDepth2 As Single
        Dim IndAccopp() As Short 'per PT (1 flangiato LT 2 flangiato LM 3 saldato LT 4 saldato LM)
        Dim PressInt As Single
        Dim PressExt As Single
        Dim TubeMinT As Single 'per cilindri Ips
        Dim TubeAdopt As Single 'per cilindri Id
        Dim MAWP2() As Single
        Dim SottoTipo As Short 'per cilindri n° di anelli
        Dim Dati1 As Single 'per cilindri altezza anelli | per tubi percentuale di forza | per coni altezza
        Dim Dati2 As Single '             spessore anelli|          fillet leg
        Dim Dati3 As Single '                            |          groove leg
        Dim Norma As Short 'per dilat EJMA o TEMA       |per i tubi divisione automatica
        Public File As String
        Dim IndAccopp2() As Short 'per PT B (1 flangiato LT 2 flangiato LM 3 saldato LT 4 saldato LM)
        Dim UW20St As Single 'tubi: ammiss.piastra
        Dim UW20Sa As Single '      ammiss.trazione
        Dim Dati() As Single 'tubi: tens.ax.prim.pr.int. 'fondi: fb EUronorm
        'Dati5  As Single          'tubi: tens.ax.p+sec.pr.int.'fondi: 1 se cold spun
        'Dati6  As Single          'tubi: tens.ax.prim.pr.est.
        'Dati7  As Single          'tubi: tens.ax.p+sec.pr.est.
        Dim Shydr As Single 'tensione ammissibile in HT
        Dim EUTestGroup As Short
        Public PadUlt As String
        Public Sub Initialize()
            ReDim indice(8)
            ReDim RecInd(8)
            ReDim MAWP(4)
            ReDim IndAccopp(4)
            ReDim MAWP2(4)
            ReDim IndAccopp2(4)
            ReDim Dati(7)
        End Sub
    End Structure
    Structure Addit1
        Dim RP As Single
        Dim Rpp As Single
        Dim akm() As Single
        Dim akt() As Single
        Dim t0th() As Single
        Public Sub Initialize()
            ReDim akm(2)
            ReDim akt(2)
            ReDim t0th(2)
        End Sub
    End Structure
    Structure AdditCon
        Dim indice() As Short 'prog NO ivo nei Record() (dimensionato per il
        'caso di cilindri in più virole
        Dim Tipo As Short '0 cilindro 1 fondo 2 cono 3 conoide
        Dim MATE() As String
        Dim matind() As Short
        Dim Spess() As Single 'tnn
        Dim E() As Single 'en
        Dim S0() As Single
        Dim St() As Single
        Dim f(,) As Single
        Dim eff() As Single
        Dim delta() As Single
        Dim PSE() As Single
        Dim AeL() As Single
        Dim ArL() As Single
        Dim k() As Single
        Dim Necess() As Single
        Dim Rinf() As Single
        Dim Contr() As Short '1 cono 2 toro 3 rinf grande 4 rinf piccolo
        Dim Shydr() As Single
        Dim E1() As Single 'spess richiesto nella giunzione grande e piccola secondo EU
        Dim EM() As Single 'lo stesso per il calcolo delle MAWP
        Dim l(,) As Single  'grande piccolo,cilindro cono
        Dim Sploc(,) As Single  'grande piccolo,cilindro cono
        Public Sub Initialize()
            ReDim indice(5)
            ReDim matind(2)
            ReDim Spess(2)
            ReDim E(2)
            ReDim S0(2)
            ReDim St(2)
            ReDim f(2, 2)
            ReDim eff(2)
            ReDim delta(2)
            ReDim PSE(2)
            ReDim AeL(2)
            ReDim ArL(2)
            ReDim k(2)
            ReDim Necess(2)
            ReDim Rinf(2)
            ReDim Contr(4)
            ReDim Shydr(2)
            ReDim E1(2)
            ReDim EM(2)
            ReDim l(2, 2)
            ReDim Sploc(2, 2)
            ReDim MATE(2)
        End Sub
    End Structure
    Structure Stiff
        Dim Dist As Single
        Dim Spess As Single
        Dim Alt As Single
    End Structure
End Module