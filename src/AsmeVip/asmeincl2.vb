Option Strict Off
Option Explicit On 
Imports System.Runtime.InteropServices
Module asmeincl2
    '            VARIABILI RELATIVE A CALCOLI INTERMEDI
    <Serializable(), StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> Public Structure DatiCalc
        Dim FattoNi As Single 'Fattore eta da TEMA-Table RCB-7.132
        Dim FPiastr As Single 'Fattore F   da TEMA-RCB-7.132
        Dim bdice As Short '=0:sandwitch;=1 flangia testata;=2 fl.mantello
        Dim AreaBol As Single 'Area effettiva bulloni                  [in2]
        Dim BoltSpc As Single 'Spaziatura effettiva bulloni             [mm]
        Dim gef As Single 'valore di G [mm] come da TABLE RCB-7.132
        Dim SWITCH_Renamed As Short '0:tutto OK; 1:spaziatura bulloni insufficiente
        Dim HGP As Single 'Carico su guarnizione per tenuta (max)  [lb]
        Dim H As Single 'Effetto di fondo (max)                  [lb]
        Dim wm1 As Single 'Carico bulloni per esercizio (max)      [lb]
        Dim wm2 As Single 'Carico bulloni per seating   (max)      [lb]
        Dim am1 As Single
        Dim am2 As Single
        Dim am As Single
        Dim rrr As Single ' "R"
        Dim hHm As Single 'Braccio fino all'iperstatica            [in]
        Dim hHd As Single 'Braccio fino alla forza del cil.saldato [in]
        Dim hHt As Single 'Braccio fino alla pressione anulare     [in]
        Dim hHg As Single 'Braccio fino alla guarnizione           [in]
        Dim ThkShe As Single 'Spessore parte saldata                  [mm]
        Dim IMAX As Short 'Indice del caso dimensionante
        Dim Corroso As Short
        Dim wot As Single
        Dim wm1H As Single
        Dim wm2H As Single
        Dim wotH As Single
        <VBFixedString(84), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=84)> Dim Pad As String
    End Structure
    '==========================================================================
    '                 DATI del PROBLEMA
    <Serializable(), StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> Public Structure DatiBull
        <VBFixedString(34), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=34)> Public MatBull As String 'Materiale bulloni
        <VBFixedString(34), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=34)> Public DiNBull As String 'Diametro nominale bulloni
        Dim XFil As Short '1 MET 2 ANS 3 MET-PIL 4 ANS-PIL
        Dim AllBRoo As Single 'Tens.ammiss.bulloni        @room     [psi]
        Dim AllBOpe As Single 'Tens.ammiss.bulloni        @temp     [psi]
        Dim fSicBul As Single 'Fattore addiz. sicurezza bulloni     [--]
        Dim NumBolt As Short 'Numero di bulloni
        Dim NumColl As Short 'Numero dei detti con collare
        Dim BoltCiD As Single 'Diametro impianto bulloni            [mm]
        Dim AreBolt As Single 'Sezione retta bulloni                [in2]
        Dim BSpcMin As Single 'Passo minimo ammiss. bulloni         [mm]
        Dim BRadMin As Single 'Spazoatura esterna
        Dim SPHT As Short
        Dim CRUSH As Short
        <VBFixedString(76), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=76)> Dim Pad As String
        Public Sub Initialize()
            MatBull = "not defined"
            DiNBull = ""
        End Sub
    End Structure
    <Serializable(), StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> Public Structure DatiGeneral
        <VBFixedString(34), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=34)> Public Commess As String 'Identificazione comm./rapporto di calcolo
        <VBFixedString(34), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=34)> Dim TipPias1 As String  'Tipo di piastra tubiera
        <VBFixedString(34), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=34)> Dim TipPias2 As String  'Tipo di piastra tubiera
        <VBFixedString(34), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=34)> Dim MatPias1 As String  'Tipo di piastra tubiera
        <VBFixedString(34), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=34)> Dim MatPias2 As String  'Tipo di piastra tubiera
        Dim AllFRoo As Single 'Tens.ammiss.flangi/piastra @room     [psi]
        Dim AllFOpe As Single 'Tens.ammiss.flangia/piastra @temp    [psi]
        Dim PEsChan As Single 'Pressione esercizio lato cassa       [psi]
        Dim PEsShel As Single 'Pressione esercizio lato mantello    [psi]
        Dim PHTChan As Single 'Press prova idraulica lato cassa     [psi]
        Dim PHTShel As Single 'Press prova idraulica lato mantello  [psi]
        Dim Destemp As Single 'Temperatura di progetto              [deg.C]
        Dim TSheDes As Single 'Diametro esterno piastra tubiera     [mm]
        Dim TSheThk As Single 'Spessore         piastra tubiera     [mm]
        Dim TExtThk As Single 'Spessore         estensione          [mm]
        Dim TubDiam As Single 'Diametro tubi scambiatori            [mm]
        Dim TubPass As Single 'Passo foratura                       [mm]
        Dim TipPass As Short '1=passo quadrato; 2=passo triangolare
        Dim EquDiam As Single 'Dl secondo Table RCB-7.133           [mm]
        Dim CorChan As Single 'corrosione lato cassa                [mm]
        Dim CorShel As Single 'corrosione lato mantello             [mm]
        Dim CavChan As Single 'profondita cava per partition plates [mm]
        Dim SERRA As Short '-----------------------------------------
        Dim mart As Short '|                                       |
        Dim SPHT As Short '|     Interruttori per opzioni di       |
        Dim PDIFF As Short '|       calcolo. Vedi file              |
        Dim FLEX As Short '|          PIASTRA.EXT                  |
        Dim CRUSH As Short '|                                       |
        Dim NOGRAF As Short '|                                       |
        Dim Vacuum As Short '-----------------------------------------
        Dim TipCalc As Short '1 ottim.,2 verifica
        Dim rappSin As Single
        Dim FattBoltSy As Single
        Dim DiffPress As Single
        Dim CavShel As Single 'profondità cava su PT lato shell
        Dim Rules As Short
        Dim OTL As Single
        Dim UL As Single
        Dim ltxperc As Boolean
        Dim ltx As Single
        Dim TipoAA As Short
        Dim TubSpess As Single
        Dim AllFHyd As Single
        Dim TipoFF As Short
        Dim Flottante As Short
        Dim hr As Single
        Dim IndiceFlanF As Short
        Dim IndiceChanF As Short
        Dim IndiceFondo As Short
        Dim BullDistinti As Short
        <MarshalAs(UnmanagedType.CustomMarshaler, marshaltyperef:=GetType(DatiBull))> Dim Tiranti1 As DatiBull
        <MarshalAs(UnmanagedType.CustomMarshaler, marshaltyperef:=GetType(DatiBull))> Dim Tiranti2 As DatiBull
        Dim DiffPressHT As Single
        Dim IndiceSplitR As Short
        Dim GrvChan As Single
        Dim GrvShel As Single
        Dim IBW As Boolean
        Dim diamIBW As Single
        Dim RadialExp As Boolean
        <VBFixedString(78), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=78)> Dim Pad As String
        Public Property TipPias(ByVal i As Short) As String
            Get
                Select Case i
                    Case 1 : Return TipPias1
                    Case 2 : Return TipPias2
                    Case Else : Return ""
                End Select
            End Get
            Set(ByVal Value As String)
                Select Case i
                    Case 1 : TipPias1 = Value
                    Case 2 : TipPias2 = Value
                End Select
            End Set
        End Property
        Public Property MatPias(ByVal i As Short) As String
            Get
                Select Case i
                    Case 1 : Return MatPias1
                    Case 2 : Return MatPias2
                    Case Else : Return ""
                End Select
            End Get
            Set(ByVal Value As String)
                Select Case i
                    Case 1 : MatPias1 = Value
                    Case 2 : MatPias2 = Value
                End Select
            End Set
        End Property
        Public Property Tiranti(ByVal i As Short) As DatiBull
            Get
                Select Case i
                    Case 1 : Return Tiranti1
                    Case 2 : Return Tiranti2
                    Case Else : Return Nothing
                End Select
            End Get
            Set(ByVal Value As DatiBull)
                Select Case i
                    Case 1 : Tiranti1 = Value
                    Case 2 : Tiranti2 = Value
                End Select
            End Set
        End Property
        Public Sub Initialize()
            Commess = ""
            TipPias1 = "" : TipPias2 = ""
            MatPias1 = "not defined" : MatPias2 = "not defined"
            Pad = ""
            Tiranti1.Initialize()
            Tiranti2.Initialize()
        End Sub
    End Structure
    <Serializable(), StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> Public Structure datiFlangia
        <VBFixedString(34), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=34)> Public Identif As String 'Nominativo
        <VBFixedString(34), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=34)> Public TipGuar As String 'Tipo di guarnizione
        <VBFixedString(34), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=34)> Public MatGuar As String 'Materiale della guarnizione
        Dim DextFla As Single 'Diametro esterno della flangia          [mm]
        Dim DintFla As Single 'Diametro interno della flangia         [mm]
        Dim CodoMax As Single 'Spessore codolo massimo                [mm]
        Dim CodoMin As Single 'Spessore codolo minimo                 [mm]
        Dim DmedGua As Single 'Diametro mdio guarnizione              [mm]
        Dim LargGua As Single 'Larghezza guarnizione                  [mm]
        Dim mguar As Single ' "m"                                   [--]
        Dim y As Single ' "y"                                   [psi]
        Dim PHI As Single 'Tipo di faccia (ASME VIIIdiv.1 App.2)  [--]
        Dim wn As Single 'Altezza nubbin                         [mm]
        Dim ClassGsk As Short
        Dim TipGsk As Short
        Dim IndFac As Short
        '----------------------dati calcolati---------------------------------
        Dim PresDes As Single 'Pressione di progetto                  [psi]
        Dim PresHyT As Single 'Pressione di prova idraulica           [psi]
        Dim gefinc As Single 'Gef della guarnizione                  [in]
        Dim bo As Single 'Basic gasket seating width             [mm]
        Dim b1inc As Single 'Effective gasket seating width         [in]
        Dim HGP As Single 'Carico sulla guarnizione per la tenuta [in]
        Dim H As Single 'Effetto di fondo                       [in]
        Dim ytrav As Single ' "y"                                   [psi]
        Dim btrav As Single 'largh.eff traversini                   [mm]
        Dim ltrav As Single 'lungh traversini                       [mm]
        Dim wmt As Single 'Carico traversini                      [lb]
        Dim wm1 As Single 'Carico bulloni per esercizio           [lb]
        Dim wm2 As Single 'Carico bulloni per seating             [lb]
        Dim am1 As Single 'Area bulloni per esercizio             [in2]
        Dim am2 As Single 'Area bulloni per seating               [in2]
        Dim am As Single 'Area bulloni necessaria                [in2]
        Dim AreaBol As Single 'Area effettiva bulloni                 [in2]
        Dim AreaCrs As Single 'Area bulloni che schiaccia la guarnizione
        Dim rrr As Single ' "R"                                   [in]
        Dim hHg As Single 'braccio bulloni-guarnizione            [in]
        Dim hHd As Single 'braccio con forza da hub               [in]
        Dim hHt As Single 'braccio con forza da pressione su anello [in]
        Dim fHd As Single 'Forza esercitata dal codolo            [lb]
        Dim fHt As Single 'Effetto pressione su area anulare      [lb]
        Dim fHg As Single 'Forza sulla guarnizione                [lb]
        Dim m1 As Single 'Momento di flangia in operating        [lb.in]
        Dim m2 As Single 'Momento di flangia in seating          [lb,in]
        Dim SWITCH_Renamed As Short '=0:tutto OK; =1 area bulloni insufficiente
        Dim SWCRUS As Short '=1:guarnizione stressata;=0 tutto OK
        Dim wot As Single 'design bolt load in operating
        Dim mtrav As Single
        Dim wm1H As Single 'Carico bulloni per esercizio in P.I.   [lb]
        Dim wm2H As Single 'Carico bulloni per seating   in P.I.?? [lb]
        Dim wotH As Single
        <VBFixedString(84), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=84)> Dim Pad As String
        Public Sub Initialize()
            Identif = "without name"
            TipGuar = "not defined"
            MatGuar = "not defined"
            Pad = ""
        End Sub
    End Structure
    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> Public Structure typROTFL
        <VBFixedString(6), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=6)> Public Arch As String
        <VBFixedString(18), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=18)> Public Membr As String
        <VBFixedString(18), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=18)> Public Mater As String
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
        <VBFixedString(40), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=40)> Public DiscoRam As String
        <VBFixedString(40), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=40)> Public ArchDir As String
        <VBFixedString(70), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=70)> Public Intest As String
        <VBFixedString(70), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=70)> Public Norma As String
        Dim rapp As Single
        Dim J1 As Single
        Dim wm2 As Single
        Dim Estar As Single
        Dim nistar As Single
        Dim ts As Single
        Dim Thet0 As Single
        Dim Thet1 As Single
        Dim SpExt As Single
        '  Public Sub initialize()
        '      DiscoRam = New String(" ", 40)
        '      ArchDir = New String(" ", 40)
        '      Intest = New String(" ", 70)
        '      Norma = New String(" ", 70)
        '      Arch = New String(" ", 6)
        '      Membr = New String(" ", 18)
        '      Mater = New String(" ", 18)
        '  End Sub
    End Structure
    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> Structure ASMERES
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
        <VBFixedString(80), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=80)> Public MatN As String
        Dim SpCop As Single 'spess min cop
        Dim SpCopA As Single 'spess adopted cop
        Dim Diam As Single 'diam cop vessel
        Dim CorrCop As Single
        Dim AllCop As Single
        Dim VerificandoPI As Short
        <VBFixedString(10), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=10)> Public Pad As String
    End Structure
    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> Structure Str50
        <VBFixedString(50), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=50)> Public Str_Renamed As String
    End Structure
    <Serializable(), StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> Structure asConfig
        Dim LatoProgetto As Short
        Dim TipCalc As Short
        Dim Verbose As Short
        Dim Ninvolucri As Short
        Dim DC As Short
        Dim US As Short
        <VBFixedString(13), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=13)> Public DNjob As String
        <VBFixedString(25), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=25)> Public lkStr As String
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
        <VBFixedArray(1), MarshalAs(UnmanagedType.ByValArray, SizeConst:=2)> Dim tdxMDMT() As Single
        <VBFixedArray(1), MarshalAs(UnmanagedType.ByValArray, SizeConst:=2)> Dim pdxMDMT() As Single
        Dim pxExt As Single
        Dim txExt As Single
        Dim DensFluido As Single
        Dim NMWDT As Short
        Dim Versione As Short
        <VBFixedString(12), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=12)> Public Item As String
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
        <VBFixedString(4), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=4)> Public Pad As String
        Public Sub Initialize()
            DNjob = ""
            lkStr = ""
            ReDim tdxMDMT(1)
            ReDim pdxMDMT(1)
        End Sub
    End Structure
    <Serializable(), StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> Structure Nozzle '431
        Dim indice As Short 'pro NO sivo nei Record() materiale tronch.
        Dim InvolucroSU As Short
        Dim RecInd As Short
        <VBFixedString(30), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=30)> Public Mark As String 'MK$
        <VBFixedString(4), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=4)> Public Tipo As String
        <VBFixedString(80), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=80)> Public MATE As String 'mn$
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
        <VBFixedString(1), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=1)> Public Xacc As String 'x$
        Dim MUN As Single
        Dim LX As Single
        Dim HX As Single
        Dim LSDisp As Single
        Dim Padd As Single
        Dim PadT As Single
        Dim SWR As Short
        Dim MNT As Single
        <VBFixedArray(3), MarshalAs(UnmanagedType.ByValArray, SizeConst:=4)> Dim MAWP() As Single
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
        <VBFixedString(15), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=15)> Public MateCop As String
        Dim alfaShell As Single
        Dim alfaNoz As Single
        Dim alfaPad As Single ' NON USATO
        Dim dtAD550f As Single
        Dim FlanNonStd As Short
        Dim AllNPI As Single
        Dim AllPadPI As Single
        Dim BNoRinf As Short
        Dim FactVicini As Single
        <VBFixedString(97), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=97)> Public Pad As String
        Public Sub Initialize()
            ReDim MAWP(3)
            Mark = ""
            MATE = ""
            Tipo = ""
            Xacc = ""
            MateCop = ""
        End Sub
    End Structure
    <Serializable(), StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> Structure NozzleN '431
        Dim indice As Short 'pro NO sivo nei Record() materiale tronch.
        Dim InvolucroSU As Short
        Dim RecInd As Short
        <VBFixedString(30), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=30)> Public Mark As String 'MK$
        <VBFixedString(5), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=5)> Public Tipo As String
        <VBFixedString(80), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=80)> Public MATE As String 'mn$
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
        <VBFixedString(1), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=1)> Public Xacc As String 'x$
        Dim MUN As Single '0, 1 non passa, passa su un giunto di categoria A
        Dim LX As Single
        Dim HX As Single
        Dim LSDisp As Single
        Dim Padd As Single
        Dim PadT As Single
        Dim SWR As Short
        Dim MNT As Single 'undertolerance %
        <VBFixedArray(3), MarshalAs(UnmanagedType.ByValArray, SizeConst:=4)> Dim MAWP() As Single
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
        <VBFixedString(15), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=15)> Public MateCop As String
        Dim alfaShell As Single
        Dim alfaNoz As Single
        Dim alfaPad As Single ' NON USATO
        Dim dtAD550f As Single
        Dim FlanNonStd As Short
        Dim AllNPI As Single
        Dim AllPadPI As Single
        Dim BNoRinf As Short
        Dim FactVicini As Single
        <VBFixedString(97), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=97)> Public Pad As String
        Public Sub Initialize()
            ReDim MAWP(3)
            Mark = ""
            MATE = ""
            Tipo = ""
            Xacc = ""
            MateCop = ""
        End Sub
    End Structure
    <Serializable(), StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> Structure NozzAdN  '166
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
        <VBFixedArray(8), MarshalAs(UnmanagedType.ByValArray, SizeConst:=9)> Dim Str_Renamed() As Single
        <VBFixedArray(8), MarshalAs(UnmanagedType.ByValArray, SizeConst:=9)> Dim i() As Short
        <VBFixedArray(2), MarshalAs(UnmanagedType.ByValArray, SizeConst:=3)> Dim Paths() As Single
        <VBFixedArray(2), MarshalAs(UnmanagedType.ByValArray, SizeConst:=3)> Dim Wcomp() As Single
        'Dim Pad(16) As String*1
        <VBFixedString(16), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=16)> Dim Pad As String
        Public Sub Initialize()
            ReDim i(8)
            ReDim Paths(2)
            ReDim Wcomp(2)
            ReDim Str_Renamed(8)
        End Sub
    End Structure
    <Serializable(), StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> Structure NozzAd  '166
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
        <VBFixedArray(8), MarshalAs(UnmanagedType.ByValArray, SizeConst:=9)> Dim Str_Renamed() As Single
        <VBFixedArray(2, 2), MarshalAs(UnmanagedType.ByValArray, SizeConst:=9)> Dim i(,) As Short
        <VBFixedArray(2), MarshalAs(UnmanagedType.ByValArray, SizeConst:=3)> Dim Paths() As Single
        <VBFixedArray(2), MarshalAs(UnmanagedType.ByValArray, SizeConst:=3)> Dim Wcomp() As Single
        'Dim Pad(16) As String*1
        <VBFixedString(16), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=16)> Dim Pad As String
        Public Sub Initialize()
            ReDim i(2, 2)
            ReDim Paths(2)
            ReDim Wcomp(2)
            ReDim Str_Renamed(8)
        End Sub
    End Structure
    <Serializable(), StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> Structure Involucro
        <VBFixedArray(7), MarshalAs(UnmanagedType.ByValArray, SizeConst:=8)> Dim indice() As Short  'prog NO ivo nei Record() (dimensionato per il
        'caso di cilindri in più virole)
        'per flangioni: 1 materiale flangia,2 materiale bulloni, 3 materiale g.
        Dim Tipo As Short '0 cilindro 1 fondo 2 cono 3 conoide 4 belt 5 flangione
        <VBFixedString(30), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=30)> Public Mark As String
        <VBFixedString(80), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=80)> Public MATE As String
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
        <VBFixedString(3), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=3)> Public Suffix As String
        <VBFixedArray(7), MarshalAs(UnmanagedType.ByValArray, SizeConst:=8)> Dim RecInd() As Short
        <VBFixedArray(3), MarshalAs(UnmanagedType.ByValArray, SizeConst:=4)> Dim MAWP() As Single
        <VBFixedString(10), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=10)> Public MWDTrule As String
        <VBFixedString(1), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=1)> Public MWDTclause As String
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
        <VBFixedArray(4), MarshalAs(UnmanagedType.ByValArray, SizeConst:=5)> Dim IndAccopp() As Short 'per PT (1 flangiato LT 2 flangiato LM 3 saldato LT 4 saldato LM)
        Dim PressInt As Single
        Dim PressExt As Single
        Dim TubeMinT As Single 'per cilindri Ips
        Dim TubeAdopt As Single 'per cilindri Id
        <VBFixedArray(3), MarshalAs(UnmanagedType.ByValArray, SizeConst:=4)> Dim MAWP2() As Single
        Dim SottoTipo As Short 'per cilindri n° di anelli
        Dim Dati1 As Single 'per cilindri altezza anelli | per tubi percentuale di forza | per coni altezza
        Dim Dati2 As Single '             spessore anelli|          fillet leg
        Dim Dati3 As Single '                            |          groove leg
        Dim Norma As Short 'per dilat EJMA o TEMA       |per i tubi divisione automatica
        <VBFixedString(50), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=50)> Public File As String
        <VBFixedArray(4), MarshalAs(UnmanagedType.ByValArray, SizeConst:=5)> Dim IndAccopp2() As Short 'per PT B (1 flangiato LT 2 flangiato LM 3 saldato LT 4 saldato LM)
        Dim UW20St As Single 'tubi: ammiss.piastra
        Dim UW20Sa As Single '      ammiss.trazione
        <VBFixedArray(3), MarshalAs(UnmanagedType.ByValArray, SizeConst:=4)> Dim Dati() As Single 'tubi: tens.ax.prim.pr.int. 'fondi: fb EUronorm
        'Dati5  As Single          'tubi: tens.ax.p+sec.pr.int.'fondi: 1 se cold spun
        'Dati6  As Single          'tubi: tens.ax.prim.pr.est.
        'Dati7  As Single          'tubi: tens.ax.p+sec.pr.est.
        Dim Shydr As Single 'tensione ammissibile in HT
        Dim EUTestGroup As Short
        <VBFixedString(21), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=21)> Public PadUlt As String
        Public Sub Initialize()
            ReDim indice(7)
            ReDim RecInd(7)
            ReDim MAWP(3)
            ReDim IndAccopp(4)
            ReDim MAWP2(3)
            ReDim IndAccopp2(4)
            ReDim Dati(3)
            Suffix = "   "
            MWDTrule = "          "
            MWDTclause = " "
            Mark = ""
            MATE = ""
            Dim i As Integer
            For i = 0 To 3
                IndAccopp(i) = -1
                IndAccopp2(i) = -1
            Next
        End Sub
    End Structure
    <Serializable(), StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> Structure Addit1
        Dim RP As Single
        Dim Rpp As Single
        <VBFixedArray(1), MarshalAs(UnmanagedType.ByValArray, SizeConst:=2)> Dim akm() As Single
        <VBFixedArray(1), MarshalAs(UnmanagedType.ByValArray, SizeConst:=2)> Dim akt() As Single
        <VBFixedArray(1), MarshalAs(UnmanagedType.ByValArray, SizeConst:=2)> Dim t0th() As Single
        Public Sub Initialize()
            ReDim akm(1)
            ReDim akt(1)
            ReDim t0th(2)
        End Sub
    End Structure
    <Serializable(), StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> Structure AdditCon
        <VBFixedArray(4), MarshalAs(UnmanagedType.ByValArray, SizeConst:=5)> Dim indice() As Short 'prog NO ivo nei Record() (dimensionato per il
        'caso di cilindri in pi— virole
        Dim Tipo As Short '0 cilindro 1 fondo 2 cono 3 conoide
        'Dim MATE(2) As String*15
        <VBFixedString(15), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=15)> Dim MATE1 As String
        <VBFixedString(15), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=15)> Dim MATE2 As String
        <VBFixedArray(1), MarshalAs(UnmanagedType.ByValArray, SizeConst:=2)> Dim matind() As Short
        <VBFixedArray(1), MarshalAs(UnmanagedType.ByValArray, SizeConst:=2)> Dim Spess() As Single 'tnn
        <VBFixedArray(1), MarshalAs(UnmanagedType.ByValArray, SizeConst:=2)> Dim E() As Single 'en
        <VBFixedArray(1), MarshalAs(UnmanagedType.ByValArray, SizeConst:=2)> Dim S0() As Single
        <VBFixedArray(1), MarshalAs(UnmanagedType.ByValArray, SizeConst:=2)> Dim St() As Single
        <VBFixedArray(1, 1), MarshalAs(UnmanagedType.ByValArray, SizeConst:=4)> Dim f(,) As Single
        <VBFixedArray(1), MarshalAs(UnmanagedType.ByValArray, SizeConst:=2)> Dim eff() As Single
        <VBFixedArray(1), MarshalAs(UnmanagedType.ByValArray, SizeConst:=2)> Dim delta() As Single
        <VBFixedArray(1), MarshalAs(UnmanagedType.ByValArray, SizeConst:=2)> Dim PSE() As Single
        <VBFixedArray(1), MarshalAs(UnmanagedType.ByValArray, SizeConst:=2)> Dim AeL() As Single
        <VBFixedArray(1), MarshalAs(UnmanagedType.ByValArray, SizeConst:=2)> Dim ArL() As Single
        <VBFixedArray(1), MarshalAs(UnmanagedType.ByValArray, SizeConst:=2)> Dim k() As Single
        <VBFixedArray(1), MarshalAs(UnmanagedType.ByValArray, SizeConst:=2)> Dim Necess() As Single
        <VBFixedArray(1), MarshalAs(UnmanagedType.ByValArray, SizeConst:=2)> Dim Rinf() As Single
        <VBFixedArray(3), MarshalAs(UnmanagedType.ByValArray, SizeConst:=4)> Dim Contr() As Short '1 cono 2 toro 3 rinf grande 4 rinf piccolo
        <VBFixedArray(1), MarshalAs(UnmanagedType.ByValArray, SizeConst:=2)> Dim Shydr() As Single
        <VBFixedArray(1), MarshalAs(UnmanagedType.ByValArray, SizeConst:=2)> Dim E1() As Single 'spess richiesto nella giunzione grande e piccola secondo EU
        <VBFixedArray(1), MarshalAs(UnmanagedType.ByValArray, SizeConst:=2)> Dim EM() As Single 'lo stesso per il calcolo delle MAWP
        <VBFixedArray(1, 1), MarshalAs(UnmanagedType.ByValArray, SizeConst:=4)> Dim l(,) As Single  'grande piccolo,cilindro cono
        <VBFixedArray(1, 1), MarshalAs(UnmanagedType.ByValArray, SizeConst:=4)> Dim Sploc(,) As Single  'grande piccolo,cilindro cono
        <VBFixedString(80), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=80)> Public Pad As String
        Public Sub Initialize()
            ReDim indice(4)
            ReDim matind(1)
            ReDim Spess(1)
            ReDim E(1)
            ReDim S0(1)
            ReDim St(1)
            ReDim f(1, 1)
            ReDim eff(1)
            ReDim delta(1)
            ReDim PSE(1)
            ReDim AeL(1)
            ReDim ArL(1)
            ReDim k(1)
            ReDim Necess(1)
            ReDim Rinf(1)
            ReDim Contr(3)
            ReDim Shydr(1)
            ReDim E1(1)
            ReDim EM(1)
            ReDim l(1, 1)
            ReDim Sploc(1, 1)
            matind(0) = -1
            matind(1) = -1
        End Sub
    End Structure
    <Serializable(), StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> Structure AdditConN
        <VBFixedArray(4), MarshalAs(UnmanagedType.ByValArray, SizeConst:=5)> Dim indice() As Short 'prog NO ivo nei Record() (dimensionato per il
        'caso di cilindri in pi— virole
        Dim Tipo As Short '0 cilindro 1 fondo 2 cono 3 conoide
        'Dim MATE(2) As String*15
        <VBFixedString(15), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=15)> Dim MATE1 As String
        <VBFixedString(15), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=15)> Dim MATE2 As String
        <VBFixedArray(1), MarshalAs(UnmanagedType.ByValArray, SizeConst:=2)> Dim matind() As Short
        <VBFixedArray(1), MarshalAs(UnmanagedType.ByValArray, SizeConst:=2)> Dim Spess() As Single 'tnn
        <VBFixedArray(1), MarshalAs(UnmanagedType.ByValArray, SizeConst:=2)> Dim E() As Single 'en
        <VBFixedArray(1), MarshalAs(UnmanagedType.ByValArray, SizeConst:=2)> Dim S0() As Single
        <VBFixedArray(1), MarshalAs(UnmanagedType.ByValArray, SizeConst:=2)> Dim St() As Single
        <VBFixedArray(1, 1), MarshalAs(UnmanagedType.ByValArray, SizeConst:=4)> Dim f(,) As Single
        <VBFixedArray(1), MarshalAs(UnmanagedType.ByValArray, SizeConst:=2)> Dim eff() As Single
        <VBFixedArray(1), MarshalAs(UnmanagedType.ByValArray, SizeConst:=2)> Dim delta() As Single
        <VBFixedArray(1), MarshalAs(UnmanagedType.ByValArray, SizeConst:=2)> Dim PSE() As Single
        <VBFixedArray(1), MarshalAs(UnmanagedType.ByValArray, SizeConst:=2)> Dim AeL() As Single
        <VBFixedArray(1), MarshalAs(UnmanagedType.ByValArray, SizeConst:=2)> Dim ArL() As Single
        <VBFixedArray(1), MarshalAs(UnmanagedType.ByValArray, SizeConst:=2)> Dim k() As Single
        <VBFixedArray(1), MarshalAs(UnmanagedType.ByValArray, SizeConst:=2)> Dim Necess() As Single
        <VBFixedArray(1), MarshalAs(UnmanagedType.ByValArray, SizeConst:=2)> Dim Rinf() As Single
        <VBFixedArray(3), MarshalAs(UnmanagedType.ByValArray, SizeConst:=4)> Dim Contr() As Short '1 cono 2 toro 3 rinf grande 4 rinf piccolo
        <VBFixedArray(1), MarshalAs(UnmanagedType.ByValArray, SizeConst:=2)> Dim Shydr() As Single
        <VBFixedArray(1), MarshalAs(UnmanagedType.ByValArray, SizeConst:=2)> Dim E1() As Single 'spess richiesto nella giunzione grande e piccola secondo EU
        <VBFixedArray(1), MarshalAs(UnmanagedType.ByValArray, SizeConst:=2)> Dim EM() As Single 'lo stesso per il calcolo delle MAWP
        <VBFixedArray(1, 1), MarshalAs(UnmanagedType.ByValArray, SizeConst:=4)> Dim l(,) As Single  'grande piccolo,cilindro cono
        <VBFixedArray(1, 1), MarshalAs(UnmanagedType.ByValArray, SizeConst:=4)> Dim Sploc(,) As Single  'grande piccolo,cilindro cono
        <MarshalAs(UnmanagedType.CustomMarshaler, marshaltyperef:=GetType(Stiff))> Dim Stiff1 As Stiff
        <MarshalAs(UnmanagedType.CustomMarshaler, marshaltyperef:=GetType(Stiff))> Dim Stiff2 As Stiff
        Public Sub Initialize()
            ReDim indice(4)
            ReDim matind(1)
            ReDim Spess(1)
            ReDim E(1)
            ReDim S0(1)
            ReDim St(1)
            ReDim f(1, 1)
            ReDim eff(1)
            ReDim delta(1)
            ReDim PSE(1)
            ReDim AeL(1)
            ReDim ArL(1)
            ReDim k(1)
            ReDim Necess(1)
            ReDim Rinf(1)
            ReDim Contr(3)
            ReDim Shydr(1)
            ReDim E1(1)
            ReDim EM(1)
            ReDim l(1, 1)
            ReDim Sploc(1, 1)
            matind(0) = -1
            matind(1) = -1
        End Sub
        Public Property Stiff_Renamed(ByVal i As Short) As Stiff
            Get
                Select Case i
                    Case 1 : Return Stiff1
                    Case 2 : Return Stiff2
                    Case Else : Return Nothing
                End Select
            End Get
            Set(ByVal Value As Stiff)
                Select Case i
                    Case 1 : Stiff1 = Value
                    Case 2 : Stiff2 = Value
                End Select
            End Set
        End Property
    End Structure
    <Serializable()> Structure Stiff
        Dim Dist As Single
        Dim Spess As Single 'spessore rib
        Dim Alt As Single   'altezza rib
        Dim SpessAla As Single 'spessore ala
        Dim LungAla As Single 'Lunghezza ala
    End Structure

End Module
