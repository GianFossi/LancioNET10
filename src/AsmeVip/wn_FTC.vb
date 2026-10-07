Option Strict Off
Option Explicit On
Imports RoutBase1
Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary 'Namespace for BinaryFormatter
Imports System.Runtime.InteropServices
Friend Class wn_FTC
	' per cambiare la visibilità: gosub Azioni
	'                    1                  pressione lato shell
	'                    2                  pressione lato tubi
	'                    3                  pressione differenziale
	'                    4                  Temperatura media piastra A
	'                    5                  Temp shell media
	'                    6                  Temp tubi media
	'                    7                  modulo elast. PT
	'                    8                  modulo mantello
	'                    9                  modulo tubi
	'                   12                  ammiss. mant.
	'                   13                  ammiss. tubi primario
	'                   14                  alfa shell
	'                   15                  alfa tubi
	'                   19                  corrosione dilatatore
	'                   20                  somma delle grooves
	'                   21,22               D int mant, cassa
    '                   23,24               spessore mant, cassa
    '                   25,26                       ,diametro esterno dilat 
    '                   27,28               diametro, spessore tubi
    '                   29                  numero tubi
	'                   30                  Lunghezza tubi
	'                   32-33               momenti M1 e M2
	'                   35                  ammiss. piastra
	'                   36-37               KJ (rigigezza dilatatore)
    '                   38-39               snervamento tubi, kl lunghezza libera
    '                   45-46               fattore F nuvo e corroso
    '                   47-48               Fattore K
	'                   57-58               J
	'                   59-60               Pd       59-60 P gamma
	'                   61-62               Pbt      61-62 P gamma star
	'                   63-64               Pbs      63-64 P W
	'                   65-66               Fs
	'                   67-68               Ps'      67-80 Ps'
	'                   69-80               load cond.
	'                   81-82               Ps'max
	'                   93-106
	'                  107-108              P tube  107-108 P t '
	'                  133-134              P diff  133-134 P rim
	'                  135-144              load cases per eff.diff.press for shear
	'                  145-146              eff.diff.press. for shear                   145-158      Fq
	'                  159-160              spess richiesto in mm  | same
	'                  160-161              spess richiesto in in. | same
	'                  147-158              spessori elementari
	'                                               171-184 Q2
	'                                               187-200 sigma sigma m+b mantello
	'                                               201-202-203-204 massimi e minimi
	'                  209-222              Pressioni assiali
	'                  223-236                      223-236   sigma t,0 tensione tubi esterni
	'                                               237-238-239-240 massimi e minimi
	'                  241-243              Cc, r, kl per buckling tubi
	'                  245-250              Ptj1,Ptj2,Ptj3
	'                  251-256              Wj1,Wj2,Wj3
	'                  257                  Carico giunto T.P.nuovo
	'                  258                  Carico giunto T.P.corroso
	'                  259                  Amm.compr.mantello nuovo
	'                  260                  Amm.compr.mantello corroso
	'                  261                  Nø cond di carico
	'                  262                  Spessore nominale piastra B
	'                  263                  Profondità cava B
	'                  264                  Corrosione mantello B
	'                  265                  Corrosione cassa B
	'                  266                  Ammiss piastra B
	'                  267                  E piastra B
	'                  268                  Temp media piastra B
    '                  269                  Mom.flangia esercizio B
    '                  270                  Mom.flangia serraggio B
	'                  271                  eta
	'                  272                  Min temp 1  mant
	'                  273                  Min temp 1  tubi
	'                  274                  Ammiss.dilatatore
	'                  275                  snervamento dilatatore
	'                  276                  Ammiss.collare
	'                  277                  mod.elastico anelli
	'                  278                  amm.anelli
	'                  279                  mod.elas.tiranti
	'                  280                  ammiss.tiranti
	'                  281                  Cross section of reinforcing members
	'                  282                  Cross section of fasteners
	'                  283                  Effect.length of fasteners
	'                  284                  Elongazione dilatatore
	'                  285                  Carico ammiss. giunto T.P.
	'                  286                  snervamento piastra
	'                  287                  mod.elastico dilatatore
	'                  288                  spessore estensione  assunto
	'                  289                  spessore estensione B assunto
	'                  290                  spessore estensione   calcolato
	'                  291                  spessore estensione B calcolato
	'                  292                  diam guarn lato shell (mm) A
	'                  293                  diam guarn lato chann (mm) A
	'                  294                  G lato shell       (mm)    A diametro di calcolo
	'                  295                  G lato chann       (mm)    A
	'                  296 299              effective bending/shear thk
	'                  300                  shell pressure 1
	'                  301                  shell pressure 2
	'                  302                  tube pressure 1
	'                  303                  tube pressure 2
	'                  304                  Min Des Met Temp 2 mant
	'                  305                  Min Des Met Temp 2 tubi
	'                  306                  Fs RCB-7.24
	'                  307                  Diametro Kettle
	'                  308                  Diametro esterno estensione
	'                  309                  Diametro esterno estensione B
	'                  310                  F  B
	'                  311                  FC B
	'                  312                  Diametro cassa B
	'                  313                  Spessore cassa B
	'                  314                  Diametro mant. B
	'                  315                  diam guarn lato shell (mm) B
	'                  316                  diam guarn lato chann (mm) B
	'                  317                  Amm room piastra A
	'                  318                  Amm room piastra B
	'                  319                  Mon flangia A usato nel calcolo)
	'                  320                  Mom Flangia B usato nel calcolo)
	'                  321                  alfa materiale piastra (A)
	'                  322                  Temp des. del channel
	'                  323                  modulo Young del channel
	'                  324                  alfa del channel
	'                  325                  S del channel
	'                  326                  Yield del channel
	'                  330-343              Peff
	'                  344-357              sigma c,m
	'                  358-371              sigma c
	'                  372-373-374-375
	'                  376-377              a0
	'                  378-379              as
	'                  380-381              ac
	'                  382,383,384          dstar,pstar,mistar
	'                  385,386              rhos
	'                  387,388              rhoc
	'                  389,390              xt,xs
	'                  391,392              Ks maiuscolo
	'                  393,394              Kc maiuscolo
	'                  395,396              betas
	'                  397,398              betac
	'                  399,400,401          h/p,nistar,EstarE
	'                  402,403              Xa
	'                  404,405              F
	'                  406,407              Zv
	'                  408,409              Zm
	'                  410,411              Zd
	'                  412,413              phi
	'                  414,415              Q1
	'                  416,417              QZ1
	'                  418,419              QZ2
	'                  420,421              U
	'                  422,423              gammass
	'                  424,425              gammas
	'                  426,427              gammacs
	'                  428,429              gammac
	'                  430,431              hj
	'                  432,433,434,435      gamma,Tr,Tsstar,Tcstar
	'                  436,449              Q3
	'                  450,463              Fm
	'                  464,477              sigma
	'                  478,491              tau
	'                  492,493,494,495      StPos1,StcPos1,StPos2,StcPOs2
	'                  496,497              1.5 Ss, 3.0 Ss
	'                  498                  Yield dello shell
    '                  499                  Sss (AA-2.6) (min Sy Sps/2)
    '                  500                  Scs (AA-2.6) (min Sy Sps/2)
	'                  501-514              sigmasvm
	'                  515-528              sigmacvb
	'                  529-534              stpos1,2 1.5 Sc
	'                  535-536              gammab
	'                  537-538              fattori d'uso piastra elastici
	'                  539-544              facts (539,540,541) kks (542,543,544)
	'                  545                  somma grooves circonferenz. A
	'                  546-551              facts (546,547,548) kks (549,550,551)
	'                  552                  somma grooves circonferenz. B
	'                  553-566              factc (553,554,555) kkt (556,557,558)
	'                  567-580              sigmasvb
	'                  581-582              Escorr.Eccorr
	'                   583                  lungh. cilindro kettle
	'                   584                  lunghezza coni Kettle
	'                   585                  spessore coni Kettle
	'                   586                  spessore ports
	'                   587                  lunghezza ports
	'                   588                  diametro ports
	'                   589,590       fattore RCB-7.161 (3)
	'                   591                 SPS: limite 2Sy per la PT
	'                  592                  Dc secondo RCB-7.1411
	'                  593                  G per piastra flottante
	'                  594-595-596          T',Ts',Tc' temp
	'                  597-598              Pressss,Presscs
	'                  599-612              Fs safety factor buckling tubes
	'                  613-626              Ammiss tubo a compress secondo AA
	'                  627-628              Ss, SPs (ammissibili shell AA)
	'                  629-630              Ammiss PT in PI per testa e coda
	'                  631-632              Ammiss mantello-tubi in PI
	'                  633         Switch: 1 inserite le tre condizioni per pdiff
	'                  634-635       Carico [lb] bulloni di progetto SS-TS
	'                  637-638     ks
	'                  639-640     kc
	'                  641-642     lambdas
	'                  643-644     lambdac
	'                  645-658     QZ2s
	'                  659-660     Spessore shell adiacente
	'                  661-662     Lunghezze shells adiacenti
	'                  663-676     lambdas plastico (663,664,665) lambdac plastico (666,667,668)
	'                  669,676     K
	'                  677-690     F plastico (677,678,679) phig plastico (680,681,682)
	'                  691-704     Q1 plastico (691,692,693) QZ1 plastico (694,695,696)
	'                  705-718     QZ2         (705,706,707) U            (708...
    '                  705-718     QZ2         (712,713,714) U            (715...
    '                  719-732     PressW      (719,720,721) Prim         (722...
	'                  733-739     ammissibile bending piastra
	'                  740         ammissibile TAGLIO piastra
	'                  741-746     sigma plastico (741,742,743) tau (744,745,746)
	'                  747         T des PT A (con offset PT B)
	'                  748-753     sigma plastico (748,749,750) tau (751,752,753) corroso
	'                  754         UL; dopo il 2004 AL
	'                  755-756     tau max piastra
	'                  757-758     deltas
	'                  759-760     deltac
    '                  762-763     libero
	'                  764         T des tubi
	'                  765-766     fattori d'uso tubi
	'                  767-768     fattori d'uso giunto
	'                  769-770     fattori d'uso piastra plastici
	'                  771-784     Pe plastico (771,772,773)
	'                  774-776     Q2 (774,775,776)
	'                  777         T des shell
	'                  785-798     Q3 plastico (785,786,787) Fm (788,789,790)
	'                  747-764-777 T, Tt, Ts temp design TS, tube, shell
	'                  683-690     ammissibile tubi secondario - StPos1 Piastra
    '                  697-704-711     StcPos1, Stpos2,StcPos2
    '                  761         corrosione tubi
    '                  718-725-732 dstar,pstar,mstar corrosi
    '                  792-799 xt,xs corrosi 
    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> Private Structure Identif
        <VBFixedString(8), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=8)> Dim Arch As String   '* 8   'sottocommessa
        <VBFixedString(4), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=4)> Dim job As String    '* 4
        <VBFixedString(20), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=20)> Dim Prev As String   '* 20  'commessa
        <VBFixedString(20), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=20)> Dim Item As String   '* 20  'titolo
        <VBFixedString(20), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=20)> Dim Clie As String  ' * 20
        <VBFixedString(20), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=20)> Dim Comp As String   '* 20  'compilatore                         88
        <VBFixedArray(97), MarshalAs(UnmanagedType.ByValArray, SizeConst:=98)> Dim Ind() As Short     'indice in APR del record corrente   22
        Dim NBank As Short
        Dim IndG As Short
        Dim NumTot As Short       'Numero totale assiemi
        <VBFixedArray(99), MarshalAs(UnmanagedType.ByValArray, SizeConst:=100)> Dim pag() As Short     'indice pagina                       22
        Dim NumAs As Short        'numero assieme attuale
        <VBFixedString(300), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=300)> Dim File As String '(99) As String * 3  'nome file APR                       35
        <VBFixedString(2000), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=2000)> Dim Assieme As String '(99) As String * 20 'denominazioni                    220
        <VBFixedArray(99), MarshalAs(UnmanagedType.ByValArray, SizeConst:=100)> Dim Qta() As Short                                       ' 387+22
        <VBFixedString(1), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=1)> Dim Asse As String '* 1 'H o V                               '  1
        Dim Baric1 As Single 'Vec3                                              ' 12
        Dim Baric2 As Single
        Dim Baric3 As Single
        Dim peso As Single
        Dim CalcBaric As Short                                       '  6
        Dim LungM As Short   'Lunghezza max formati lamiera
        Dim LargM As Short   'Larghezza max formati lamiera          '  4
        Dim NumeroLati As Short
        <VBFixedString(100), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=100)> Dim Pad As String '(1 To 100) As String * 1
        Public Sub Initialize()
            ReDim Ind(97)
            ReDim pag(99)
            ReDim Qta(99)
        End Sub
    End Structure              'LungTEM=450
    <Serializable(), StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> Private Structure ptConfig
        Dim Differing As Short
        Dim Documented As Short
        Dim LatoProgetto As Short
        Dim CorrProva As Short
        Dim DC As Short
        Dim US As Short
        Dim Square As Short
        Dim Side As Short
        Dim nCicli As Short
        Dim Rear As Short
        <VBFixedArray(1), MarshalAs(UnmanagedType.ByValArray, SizeConst:=2)> Dim Gasketed() As Short
        <VBFixedArray(1), MarshalAs(UnmanagedType.ByValArray, SizeConst:=2)> Dim Flangiata() As Short '-1 flangiata lato cassa, 0 integr. 1 flangiata lato sh 2 ???
        Dim Verbose As Short
        Dim TipoDilat As Short '1 TEMA bellows,2 TEMA flanged, 3 EJMA unreinf, 4 rings, 5 equaliz
        Dim Ricotto As Boolean 'valido solo per EJMA
        Dim SoloDilat As Short
        Dim TipoGiunto As Short
        Dim fr As Single
        Dim fe As Single
        Dim fy As Single
        Dim SaldMand As Short
        Dim LungMand As Single
        Dim Flottante As Short
        Dim Calc7133 As Boolean
        Dim IndiceDilat As Short
        Dim IndiceShell As Short
        Dim mart As Boolean
        Dim TipoFF As Short
        Dim IndiceFondo As Short
        Dim IndiceFlanF As Short
        Dim hr As Single
        Dim CalcFBM As Boolean
        Dim IndiceChanF As Short
        Dim IndiceSplitR As Short
        <VBFixedArray(37), MarshalAs(UnmanagedType.ByValArray, SizeConst:=38)> Public Pad() As Short
        Public Sub Initialize()
            ReDim Gasketed(1)
            ReDim Flangiata(1)
            ReDim Pad(37)
        End Sub
    End Structure
    <Serializable()> Private Structure typMemoryBank
        Dim Z(,) As Single
        <VBFixedString(35), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=35)> Dim Condizio0 As String
        <VBFixedString(35), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=35)> Dim Condizio1 As String
        <VBFixedString(35), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=35)> Dim Condizio2 As String
        <VBFixedString(35), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=35)> Dim Condizio3 As String
        <VBFixedString(35), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=35)> Dim Condizio4 As String
        <VBFixedString(35), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=35)> Dim Condizio5 As String
        <VBFixedString(35), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=35)> Dim Condizio6 As String
        <VBFixedString(35), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=35)> Dim Condizio7 As String
        <VBFixedString(35), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=35)> Dim Condizio8 As String
        <VBFixedString(35), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=35)> Dim Condizio9 As String
        <VBFixedArray(8), MarshalAs(UnmanagedType.ByValArray, SizeConst:=9)> Dim Neventi() As Short
        Dim LoadCase, DimeCase As Short
        Public Property Condizio(ByVal i As Short) As String
            Get
                Select Case i
                    Case 0 : Return Condizio0
                    Case 1 : Return Condizio1
                    Case 2 : Return Condizio2
                    Case 3 : Return Condizio3
                    Case 4 : Return Condizio4
                    Case 5 : Return Condizio5
                    Case 6 : Return Condizio6
                    Case 7 : Return Condizio7
                    Case 8 : Return Condizio8
                    Case 9 : Return Condizio9
                    Case Else : Return ""
                End Select
            End Get
            Set(ByVal Value As String)
                Select Case i
                    Case 0 : Condizio0 = Value
                    Case 1 : Condizio1 = Value
                    Case 2 : Condizio2 = Value
                    Case 3 : Condizio3 = Value
                    Case 4 : Condizio4 = Value
                    Case 5 : Condizio5 = Value
                    Case 6 : Condizio6 = Value
                    Case 7 : Condizio7 = Value
                    Case 8 : Condizio8 = Value
                    Case 9 : Condizio9 = Value
                End Select
            End Set
        End Property
        Public Sub Initialize()
            ReDim Z(16, 800)
            ReDim Neventi(8)
            Dim i As Short
            For i = 0 To 9
                Condizio(i) = New String(" "c, 35)
            Next
        End Sub
    End Structure
    <VBFixedString(14), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=14)> Private DOCU As String = New String(" "c, 14)
    <VBFixedString(9), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=9)> Private Dwg As String = New String(" "c, 9)
    <VBFixedString(35), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=35)> Private buffer As String = New String(" "c, 35)
    Public lKlato, lJinvolucr As Short
    Private SaltaPag As Short
    Private T2T2, T3 As String
    Private s2, s1, s As Single
    Private Ptp, PSP, Psstar As Single
    Private Rtf As String
    Private z5, z4, z6 As Single
    Private z322, z322B As Single
    Private z268, z268B As Single
    Private z594, z594B As Single
    Private z595, z595B As Single
    Private z596, z596B As Single
    Private All, All2 As Single
    Private cc, Cm, Cd As Single
    Private Pd, Pm, Pc, pp As Single
    Private TP, Tm, Ttub, TpB As Single
    Private Test As Single
    Private ii, jj As Short
    Private Nulla, Par, Spec As String
    Private Stringa1(9) As String
    Private Stringa3(6) As String
    Private Stringa5(3) As String
    Private Stringa4(3) As String
    Private Stringa6(9) As String
    Private Stringa7(4) As String
    Private Stringa(3) As String
    Private Risult(3) As String
    Private Arch(3) As Short
    Private dAiu(3) As String
    Private iTubi As Short
    Private kDilat, jDilat As Short
    Private Dil, Fascio As String
    Private Decoded As Single
    Private Decode2, Decode1, Decode3 As Single
    Private Nome, Nome1 As String
    Private Decode4, Decode5 As Single
    Private Posi, Posi2, Posin As Short
    Private Posi3, Posi4 As Short
    Private am1, am2 As Single
    Private i3, i1, i2, indice As Short
    Private ic As Short
    Private FilePTF As String
    Private Rig, Rig1 As String
    Private iEnd, iStart, ifl As Short
    Private AltezzaRiga As Single
    Private KC, k, THKminim As Single
    Private fc, f, GG As Single
    Private t, Temp As Single
    Private ktkf, ktkfC, DS1 As Single
    Private SJM, SJMC As Single
    Private LTfq1, LTCfq1 As Single
    Private j, JC As Single
    Private MinOpt(2) As Single
	Private MinOptExt(2) As Single
    Private Sigma As Single
	Private Sigmac As Single ', MAiter As Integer
    Private Tau As Single
	Private tauc As Single
    Private iSigma As Short
	Private iSigmac As Short
    Private iTau As Short
	Private iTauc As Short
	Private NonDet As Boolean
    Private THKMIN0, THKMIN1 As Single
    Private iAggiustaC As Short
	Public CalcoloInCorso As Short '0 TEMA, 1 AA
	Public tfmax, temax As Single
	Public IndProbl As Short
	Public Padre As wn_PT
	Private OptimDil, EscludiSez1 As Boolean
	Private Indprobl1, IndProbl2 As Short
	Private ptCavChan, ptCavShel As Single
	Private ptCavChan2, ptCavShel2 As Single
    Private ptGrvChan(2) As Single
	Private ptGrvShel(2) As Single
	Public Offset As Short
	Public THKMIN As Single
	Public Ricalcola As Boolean
	Private PT, Ps, PDE As Single
    Private PS1, PT1 As Single
	Private PS1C, PT1C, PDC As Single
	Private xs, XP, xt As Single
	Private ES, Eptf, Et As Single
	Private Eptf2 As Single
	Private PA, DL, SAS As Single
	Private ASS, SAT, AT As Single
	Private CT, cs, CJ As Single
	Private Ds, Cptf, DC As Single
	Private tc, ts, DJ As Single
	Private tt, DOO, Nptf As Single
	Private M1ptf, LT, M2ptf As Single
	Private Sptf, thk, Sj As Single
	Private sY, SJC, KL As Single
	Private Fq, FT, FS As Single
	Private GUARC, FQC, FTC, FSC, GUARS As Single
	Private GS, P2ptf, g, COR, P3ptf, GC As Single
	Private P2C, P3C As Single
	Public Chiave As Short
    Private pt_Config As ptConfig
    Private Mem As typMemoryBank
    Private tdim(32) As String
	Private TVARI() As String
	Private PosVARI() As Short
	Private NVARI() As String
	Private IndVar(32, 2) As Short
	Private ContrInd(2000) As Short
	Private Progetto As Single
	Private WWW, FFF, kkk As Short
	Private codice, File, TIR, CODICETIR As String
	Private Gasket, GasMat As String
	Private pagina, paginaS As Short
	Private VERIFICA As Short
	Private Conforme As String
    Private COMA, TIMA, FLID, FLMA, COID, NOID As String
	Private NOMA, LAMA As String
	Private Contarig, ContaPag As Short
	Private Direc As Short
    Private Ind, Calcolo As Short
	Private Modifica, NonVal As Short
	Private iStartSint As Short
    Private pagpag, Suffix, Ext As String
	Private THKPreced(2) As Single
	Private EroA, GiaFatto, RigaA As Short
    Public Globale As Short
	Private Itera As Short
	Public iCond As Short
	Private iCol As Short
	Private Danno As Single
    ' Private Flangia As datiFlangia
    Private fatt(10) As Single
	Private Nf As Short
	Private MAWP(4, 3) As Single
	Private FattMax(4, 2) As Short
	Private icMAWP As Short
	Private iCondMax(4, 2) As Short
	Private Condit As Short
    Private Const INCQ As Double = 645.16
    Public objDilat As wn_Dilat
	Private TipoPT As Short
    Private Tool1(32) As String
    Private Tool2(32) As String
    Public Overloads Function Leggi(ByRef ifl As Short) As Boolean
        Dim NumCond As Short
        Leggi = True
        FileGet(ifl, pt_Config)
        Dim Lav As New Identif
        Lav.Initialize()
        FileGet(ifl, Lav)
        FileGet(ifl, DOCU)
        FileGet(ifl, Dwg)
        If pt_Config.Rear = 1 Or pt_Config.SoloDilat Then
            If objDilat Is Nothing Then objDilat = New wn_Dilat
            objDilat.Leggi(ifl)
        End If
        FileGet(ifl, Problem(Indprobl1))
        FileGet(ifl, FlChan(Indprobl1))
        FileGet(ifl, FlShel(Indprobl1))
        FileGet(ifl, DatiInt(Indprobl1))
        FileGet(ifl, Problem(IndProbl2))
        FileGet(ifl, FlChan(IndProbl2))
        FileGet(ifl, FlShel(IndProbl2))
        FileGet(ifl, DatiInt(IndProbl2))
        Dim Off, i, j, j1 As Short
        For Off = 0 To 8 Step 8
            j1 = 1
            j = 1 + Off
            LegLeg(j, j1, ifl)
            If Off = 0 Then NumCond = Mem.Z(1, 261)
            For j = 2 + Off To Mem.Z(1, 261) + Off
                j1 = j - Off
                LegLeg(j, j1, ifl)
            Next
        Next Off
        FileGet(ifl, Mem.DimeCase)
        For i = 301 To 320
            FileGet(ifl, Mem.Z(1, i))
        Next i
        FileGet(ifl, Mem.LoadCase)
    End Function
    Private Function LegLeg(ByVal j As Short, ByVal j1 As Short, ByVal ifl As Short) As Short
        Dim i As Short
        For i = 1 To 39
            FileGet(ifl, Mem.Z(j, i))
        Next i
        For i = 262 To 300
            FileGet(ifl, Mem.Z(j, i))
        Next i
        FileGet(ifl, Mem.Z(j, 259))
        Mem.Z(j, 259) = Math.Abs(Mem.Z(j, 259))
        FileGet(ifl, Mem.Z(j, 260))
        Mem.Z(j, 260) = Math.Abs(Mem.Z(j, 260))
        FileGet(ifl, Mem.Z(j, 261))
        FileGet(ifl, buffer)
        Mem.Condizio(j1) = buffer
        FileGet(ifl, Mem.Neventi(j1))
        For i = 321 To 799
            FileGet(ifl, Mem.Z(j, i))
        Next i
        Return 0
    End Function
    Public Overloads Function Leggi(ByRef fs As FileStream) As Boolean
        Dim NumCond As Short
        Leggi = True
        Dim bf As New Lancio.Legacy.Serialization.LegacyBinarySerializer
        pt_Config = CType(bf.Deserialize(fs), ptConfig)
		pt_Config.Side = 1
        If pt_Config.Rear = 1 Or pt_Config.SoloDilat Then
            If objDilat Is Nothing Then objDilat = New wn_Dilat
            objDilat.Leggi(fs)
        End If
        Problem(Indprobl1) = CType(bf.Deserialize(fs), DatiGeneral)
        FlChan(Indprobl1) = CType(bf.Deserialize(fs), datiFlangia)
        FlShel(Indprobl1) = CType(bf.Deserialize(fs), datiFlangia)
        DatiInt(Indprobl1) = CType(bf.Deserialize(fs), DatiCalc)
        Problem(IndProbl2) = CType(bf.Deserialize(fs), DatiGeneral)
        FlChan(IndProbl2) = CType(bf.Deserialize(fs), datiFlangia)
        FlShel(IndProbl2) = CType(bf.Deserialize(fs), datiFlangia)
        DatiInt(IndProbl2) = CType(bf.Deserialize(fs), DatiCalc)
        Mem = CType(bf.Deserialize(fs), typMemoryBank)
        NumCond = Mem.Z(1, 261)
    End Function
    Public Sub Salva(ByRef fs As FileStream)
        Dim bf As New Lancio.Legacy.Serialization.LegacyBinarySerializer
        '---------------------------- e la piastra B?
        Try
            Problem(Indprobl1).TExtThk = Mem.Z(1, 288)
            '----------------------------
            bf.Serialize(fs, pt_Config)
            If pt_Config.Rear = 1 Or pt_Config.SoloDilat Then objDilat.Scrivi(fs)
            bf.Serialize(fs, Problem(Indprobl1))
            bf.Serialize(fs, FlChan(Indprobl1))
            bf.Serialize(fs, FlShel(Indprobl1))
            bf.Serialize(fs, DatiInt(Indprobl1))
            bf.Serialize(fs, Problem(IndProbl2))
            bf.Serialize(fs, FlChan(IndProbl2))
            bf.Serialize(fs, FlShel(IndProbl2))
            bf.Serialize(fs, DatiInt(IndProbl2))
            bf.Serialize(fs, Mem)
        Catch e As Exception
            MessageBox.Show(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Public Sub New()
        MyBase.New()
        Dim i As Short
        TipoPT = 2
        pt_Config.Initialize()
        pt_Config.US = Config(0).US
        pt_Config.DC = Config(3).DC
        pt_Config.Differing = 1
        pt_Config.Rear = 1
        pt_Config.Side = 1
        Mem.Initialize()
        For i = 1 To 9 : Mem.Condizio(i) = "" : Next
        pt_Config.IndiceDilat = -1
        pt_Config.IndiceShell = -1
        pt_Config.IndiceFondo = -1
        pt_Config.IndiceFlanF = -1
        pt_Config.IndiceSplitR = -1
        pt_Config.IndiceChanF = -1
        Indprobl1 = CType(objMemb(Involucr(kLato, jInvolucr).IndObject), wn_PT).Indprobl1
        IndProbl2 = CType(objMemb(Involucr(kLato, jInvolucr).IndObject), wn_PT).IndProbl2
        IndProbl = Indprobl1
        lKlato = kLato
        lJinvolucr = jInvolucr
        Ricalcola = True
        iCond = 1
    End Sub
    Public WriteOnly Property UniMis() As Short
        Set(ByVal Value As Short)
            pt_Config.US = Value
        End Set
    End Property
    Public Property Flottante() As Short
        Get
            Flottante = pt_Config.Flottante
        End Get
        Set(ByVal Value As Short)
            pt_Config.Flottante = Value
        End Set
    End Property
    Public Property TipoFF() As Short
        Get
            TipoFF = pt_Config.TipoFF
        End Get
        Set(ByVal Value As Short)
            pt_Config.TipoFF = Value
        End Set
    End Property
    Public Property hr() As Single
        Get
            hr = pt_Config.hr
        End Get
        Set(ByVal Value As Single)
            pt_Config.hr = Value
        End Set
    End Property
    Public Property Rear() As Short
        Get
            Rear = pt_Config.Rear
        End Get
        Set(ByVal Value As Short)
            pt_Config.Rear = Value
            If Value = 1 Or pt_Config.SoloDilat Then
                If objDilat Is Nothing Then objDilat = New wn_Dilat
            Else
                'UPGRADE_NOTE: È possibile che l'oggetto objDilat non venga eliminato finché non venga raccolto nel Garbage Collector. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1029"'
                objDilat = Nothing
            End If
            If Value = 3 Then TipCalc = 0
        End Set
    End Property
    Public Property Flangiata(ByVal i As Short) As Short
        Get
            Flangiata = pt_Config.Flangiata(i - 1)
        End Get
        Set(ByVal Value As Short)
            pt_Config.Flangiata(i - 1) = Value
            If i = 1 And pt_Config.Differing = 2 And pt_Config.Rear = 1 Then pt_Config.Flangiata(2 - 1) = Value
        End Set
    End Property
    Public Property Ricotto() As Boolean
        Get
            Ricotto = pt_Config.Ricotto
        End Get
        Set(ByVal Value As Boolean)
            pt_Config.Ricotto = Value
        End Set
    End Property
    Public Property SoloDilat() As Boolean
        Get
            SoloDilat = pt_Config.SoloDilat
        End Get
        Set(ByVal Value As Boolean)
            pt_Config.SoloDilat = Value
            If Value Then
                If objDilat Is Nothing Then objDilat = New wn_Dilat
            End If
        End Set
    End Property
    Public Property Gasketed(ByVal i As Short) As Short
        Get
            Gasketed = pt_Config.Gasketed(i - 1)
        End Get
        Set(ByVal Value As Short)
            pt_Config.Gasketed(i - 1) = Value
            If i = 1 And pt_Config.Differing = 2 And pt_Config.Rear = 1 Then pt_Config.Gasketed(2 - 1) = Value
        End Set
    End Property
    Public Property Differing() As Short
        Get
            Differing = pt_Config.Differing
        End Get
        Set(ByVal Value As Short)
            pt_Config.Differing = Value
        End Set
    End Property
    Public Property Documented() As Short
        Get
            Documented = pt_Config.Documented
        End Get
        Set(ByVal Value As Short)
            pt_Config.Documented = Value
        End Set
    End Property
    Public Property NumColl(ByVal i As Short) As Short
        Get
            NumColl = Problem(IndProbl).Tiranti(i).NumColl
        End Get
        Set(ByVal Value As Short)
            Dim t As DatiBull = Problem(IndProbl).Tiranti(i)
            t.NumColl = Value
            Problem(IndProbl).Tiranti(i) = t
        End Set
    End Property
    Public Property TipoPias(ByVal i As Short) As String
        Get
            TipoPias = Problem(IndProbl).TipPias(i)
        End Get
        Set(ByVal Value As String)
            Problem(IndProbl).TipPias(i) = Value
        End Set
    End Property
    Public Property MatPias(ByVal i As Short) As String
        Get
            MatPias = Problem(IndProbl).MatPias(i)
        End Get
        Set(ByVal Value As String)
            Problem(IndProbl).MatPias(i) = Value
        End Set
    End Property
    Public Property TipoPiastra() As Short
        Get
            TipoPiastra = TipoPT
        End Get
        Set(ByVal Value As Short)

        End Set
    End Property
    Public Property FattBoltSy(ByVal i As Short) As Single
        Get
            FattBoltSy = Problem(IndProbl).FattBoltSy
        End Get
        Set(ByVal Value As Single)
            Problem(IndProbl).FattBoltSy = Value
        End Set
    End Property
    Public Property NumBolt(ByVal i As Short) As Short
        Get
            NumBolt = Problem(IndProbl).Tiranti(i).NumBolt
        End Get
        Set(ByVal Value As Short)
            Dim t As DatiBull = Problem(IndProbl).Tiranti(i)
            t.NumBolt = Value
            Problem(IndProbl).Tiranti(i) = t
        End Set
    End Property
    Public Property Rules() As Short
        Get
            Rules = Problem(IndProbl).Rules
        End Get
        Set(ByVal Value As Short)
            Problem(IndProbl).Rules = Value
        End Set
    End Property
    Public Property MatBull(ByVal i As Short) As String
        Get
            MatBull = TIMA
        End Get
        Set(ByVal Value As String)
            TIMA = Value
        End Set
    End Property
    Public Property FullBolt() As Short
        Get

        End Get
        Set(ByVal Value As Short)

        End Set
    End Property
    Public Property TipCalc() As Short
        Get
            TipCalc = Mem.LoadCase - 1
        End Get
        Set(ByVal Value As Short)
            Mem.LoadCase = Value + 1
            If Mem.LoadCase = 2 Then pt_Config.Documented = 2
        End Set
    End Property
    Public Property Verbose() As Boolean
        Get

        End Get
        Set(ByVal Value As Boolean)

        End Set
    End Property
    Public Property SicBullp(ByVal i As Short) As Single
        Get

        End Get
        Set(ByVal Value As Single)

        End Set
    End Property
    Public Property DiffPIese(ByVal i As Short) As Boolean
        Get

        End Get
        Set(ByVal Value As Boolean)

        End Set
    End Property
    Public Property CRUSH(ByVal i As Short) As Boolean
        Get

        End Get
        Set(ByVal Value As Boolean)

        End Set
    End Property
    Public Property CalcFBM() As Boolean
        Get
            CalcFBM = pt_Config.CalcFBM
        End Get
        Set(ByVal Value As Boolean)
            pt_Config.CalcFBM = Value
        End Set
    End Property
    Public Property Calc7133() As Boolean
        Get
            Calc7133 = pt_Config.Calc7133
        End Get
        Set(ByVal Value As Boolean)
            pt_Config.Calc7133 = Value
        End Set
    End Property
    Public Property FLEX() As Boolean
        Get

        End Get
        Set(ByVal Value As Boolean)

        End Set
    End Property
    Public Property mart() As Boolean
        Get
            '      mart = pt_Config.mart
            mart = Problem(IndProbl).mart = 1
        End Get
        Set(ByVal Value As Boolean)
            '     pt_Config.mart = vNewValue
            Problem(IndProbl).mart = 2
            If Value Then Problem(IndProbl).mart = 1
        End Set
    End Property
    Public Property Rapporto(ByVal i As Short) As Single
        Get

        End Get
        Set(ByVal Value As Single)

        End Set
    End Property
    Public Property DiNBull(ByVal i As Short) As String
        Get
            DiNBull = Problem(IndProbl).Tiranti(i).DiNBull
        End Get
        Set(ByVal Value As String)
            Dim t As DatiBull = Problem(IndProbl).Tiranti(i)
            t.DiNBull = Value
            Problem(IndProbl).Tiranti(i) = t
        End Set
    End Property
    Public Property BoltCiD(ByVal i As Short) As Single
        Get
            Dim ij As Short = IndProbl
            ' If pt_Config.Differing = 1 Then ij = 1 Else ij = IndProbl
            If pt_Config.Flangiata(pt_Config.Side - 1) = 0 And pt_Config.Gasketed(pt_Config.Side - 1) <= 0 Then
                Dim t As DatiBull = Problem(ij).Tiranti(i)
                t.BoltCiD = 0
                Problem(IndProbl).Tiranti(ij) = t
            End If
            BoltCiD = Problem(ij).Tiranti(i).BoltCiD
        End Get
        Set(ByVal Value As Single)
            Dim t As DatiBull = Problem(IndProbl).Tiranti(i)
            t.BoltCiD = Value
            Problem(IndProbl).Tiranti(i) = t
        End Set
    End Property
    Public Property AreBolt(ByVal i As Short) As Single
        Get
            AreBolt = Problem(IndProbl).Tiranti(i).AreBolt
        End Get
        Set(ByVal Value As Single)
            Dim t As DatiBull = Problem(IndProbl).Tiranti(i)
            t.AreBolt = Value
            Problem(IndProbl).Tiranti(i) = t
        End Set
    End Property
    Public Property BSpcMin(ByVal i As Short) As Single
        Get
            BSpcMin = Problem(IndProbl).Tiranti(i).BSpcMin
        End Get
        Set(ByVal Value As Single)
            Dim t As DatiBull = Problem(IndProbl).Tiranti(i)
            t.BSpcMin = Value
            Problem(IndProbl).Tiranti(i) = t
        End Set
    End Property
    Public Property BRadMin(ByVal i As Short) As Single
        Get
            BRadMin = Problem(IndProbl).Tiranti(i).BRadMin
        End Get
        Set(ByVal Value As Single)
            Dim t As DatiBull = Problem(IndProbl).Tiranti(i)
            t.BRadMin = Value
            Problem(IndProbl).Tiranti(i) = t
        End Set
    End Property
    Public Property AllFRoo() As Single
        Get
            If VerificandoPI Then
                AllFRoo = Mem.Z(1, 629)
            Else
                AllFRoo = Mem.Z(1, 317)
            End If
        End Get
        Set(ByVal Value As Single)
            If VerificandoPI Then
                Mem.Z(1, 629) = Value
            Else
                Mem.Z(1, 317) = Value
            End If
        End Set
    End Property
    Public Property AllFRoo2() As Single
        Get
            If VerificandoPI Then
                AllFRoo2 = Mem.Z(1, 630)
            Else
                AllFRoo2 = Mem.Z(1, 318)
            End If
        End Get
        Set(ByVal Value As Single)
            If VerificandoPI Then
                Mem.Z(1, 630) = Value
            Else
                Mem.Z(1, 318) = Value
            End If
        End Set
    End Property
    Public Property AllBRoo(ByVal i As Short) As Single
        Get
            AllBRoo = Problem(IndProbl).Tiranti(i).AllBRoo
        End Get
        Set(ByVal Value As Single)
            Dim t As DatiBull = Problem(IndProbl).Tiranti(i)
            t.AllBRoo = Value
            Problem(IndProbl).Tiranti(i) = t
        End Set
    End Property
    Public Property AllFOpe() As Single
        Get
            AllFOpe = Mem.Z(1, 35)
        End Get
        Set(ByVal Value As Single)
            Mem.Z(1, 35) = Value
        End Set
    End Property
    Public Property AllFOpe2() As Single
        Get
            AllFOpe2 = Mem.Z(1, 266)
        End Get
        Set(ByVal Value As Single)
            Mem.Z(1, 266) = Value
        End Set
    End Property
    Public Property AllBOpe(ByVal i As Short) As Single
        Get
            AllBOpe = Problem(IndProbl).Tiranti(i).AllBOpe
        End Get
        Set(ByVal Value As Single)
            Dim t As DatiBull = Problem(IndProbl).Tiranti(i)
            t.AllBOpe = Value
            Problem(IndProbl).Tiranti(i) = t
        End Set
    End Property
    Public Property UL() As Single
        Get
            UL = Problem(IndProbl).UL
        End Get
        Set(ByVal Value As Single)
            Problem(IndProbl).UL = Value
        End Set
    End Property
    Public Property OTL() As Single
        Get
            OTL = Problem(IndProbl).OTL
            If OTL = 0 And IndProbl = 2 Then OTL = Problem(1).OTL
        End Get
        Set(ByVal Value As Single)
            Problem(IndProbl).OTL = Value
        End Set
    End Property
    Public Property PDesChan() As Single
        Get
            PDesChan = Mem.Z(1, 2)
        End Get
        Set(ByVal Value As Single)
            Mem.Z(1, 2) = Value
        End Set
    End Property
    Public Property PDesShel() As Single
        Get
            PDesShel = Mem.Z(1, 1)
        End Get
        Set(ByVal Value As Single)
            Mem.Z(1, 1) = Value
        End Set
    End Property
    Public Property PHTChan() As Single
        Get
            PHTChan = Problem(IndProbl).PHTChan
        End Get
        Set(ByVal Value As Single)
            Problem(IndProbl).PHTChan = Value
        End Set
    End Property
    Public Property PHTShel() As Single
        Get
            PHTShel = Problem(IndProbl).PHTShel
        End Get
        Set(ByVal Value As Single)
            Problem(IndProbl).PHTShel = Value
        End Set
    End Property
    Public Property CorChan() As Single
        Get
            CorChan = Mem.Z(1, 18)
        End Get
        Set(ByVal Value As Single)
            Mem.Z(1, 18) = Value
        End Set
    End Property
    Public Property CorShel() As Single
        Get
            CorShel = Mem.Z(1, 17)
        End Get
        Set(ByVal Value As Single)
            Mem.Z(1, 17) = Value
        End Set
    End Property
    Public Property DiffPress() As Single
        Get
            DiffPress = Mem.Z(1, 3)
        End Get
        Set(ByVal Value As Single)
            Mem.Z(1, 3) = Value
            Problem(IndProbl).DiffPress = Problem(IndProbl).DiffPressHT ' vNewValue
        End Set
    End Property
    Public Property DiffPressHT() As Single
        Get
            DiffPressHT = Problem(IndProbl).DiffPressHT
        End Get
        Set(ByVal Value As Single)
            Problem(IndProbl).DiffPressHT = Value
        End Set
    End Property
    Public Property Destemp() As Single
        Get
            Select Case pt_Config.Side
                Case 0, 1
                    Destemp = Mem.Z(1, 747)
                Case 2
                    Destemp = Mem.Z(9, 747)
            End Select
        End Get
        Set(ByVal Value As Single)
            Select Case pt_Config.Side
                Case 0, 1
                    Mem.Z(1, 747) = Value
                    Involucr(kLato, jInvolucr).Destemp = Value
                Case 2
                    Mem.Z(9, 747) = Value
            End Select
        End Set
    End Property
    Public Property TSheThk() As Single
        Get
            Select Case pt_Config.Side
                Case 0, 1
                    TSheThk = Mem.Z(1, 34)
                Case 2
                    TSheThk = Mem.Z(1, 262)
            End Select
        End Get
        Set(ByVal Value As Single)
            Select Case pt_Config.Side
                Case 0, 1
                    Mem.Z(1, 34) = Value
                Case 2
                    Mem.Z(1, 262) = Value
            End Select
        End Set
    End Property
    Public Property TExtThk() As Single
        Get
            Select Case pt_Config.Side
                Case 0, 1
                    TExtThk = Mem.Z(1, 288)
                Case 2
                    TExtThk = Mem.Z(1, 289)
            End Select
        End Get
        Set(ByVal Value As Single)
            Select Case pt_Config.Side
                Case 0, 1
                    Mem.Z(1, 288) = Value
                Case 2
                    Mem.Z(1, 289) = Value
            End Select
        End Set
    End Property
    Public Property TubDiam() As Single
        Get
            TubDiam = Mem.Z(1, 27)
        End Get
        Set(ByVal Value As Single)
            Mem.Z(1, 27) = Value
        End Set
    End Property
    Public Property TubPass() As Single
        Get
            TubPass = Mem.Z(1, 11)
        End Get
        Set(ByVal Value As Single)
            Mem.Z(1, 11) = Value
        End Set
    End Property
    Public Property TubSpess() As Single
        Get
            TubSpess = Mem.Z(1, 28)
        End Get
        Set(ByVal Value As Single)
            Mem.Z(1, 28) = Value
        End Set
    End Property
    Public Property EquDiam() As Single
        Get
            EquDiam = Mem.Z(1, 10)
        End Get
        Set(ByVal Value As Single)
            Mem.Z(1, 10) = Value
        End Set
    End Property
    Public Property CavChan1() As Single
        Get
            ptCavChan = Problem(Indprobl1).CavChan
            CavChan1 = ptCavChan 'Mem.Z(1, 20)
        End Get
        Set(ByVal Value As Single)
            ptCavChan = Value
            Mem.Z(1, 20) = ptCavChan + ptCavShel
            Problem(Indprobl1).CavChan = ptCavChan
        End Set
    End Property
    Public Property CavShel1() As Single
        Get
            ptCavShel = Problem(Indprobl1).CavShel
            CavShel1 = ptCavShel
        End Get
        Set(ByVal Value As Single)
            ptCavShel = Value
            Mem.Z(1, 20) = ptCavChan + ptCavShel
            Problem(Indprobl1).CavShel = ptCavShel
        End Set
    End Property
    Public Property CavChan() As Single
        Get
            ptCavChan = Problem(IndProbl).CavChan
            CavChan = ptCavChan 'Mem.Z(1, 20)
        End Get
        Set(ByVal Value As Single)
            ptCavChan = Value
            Select Case pt_Config.Side
                Case 1 : Mem.Z(1, 20) = ptCavChan + ptCavShel
                Case 2 : Mem.Z(1, 263) = ptCavChan + ptCavShel
            End Select
            Problem(IndProbl).CavChan = ptCavChan
        End Set
    End Property
    Public Property CavShel() As Single
        Get
            ptCavShel = Problem(IndProbl).CavShel
            CavShel = ptCavShel
        End Get
        Set(ByVal Value As Single)
            ptCavShel = Value
            Select Case pt_Config.Side
                Case 1 : Mem.Z(1, 20) = ptCavChan + ptCavShel
                Case 2 : Mem.Z(1, 263) = ptCavChan + ptCavShel
            End Select
            Problem(IndProbl).CavShel = ptCavShel
        End Set
    End Property
    Public Property GrvChan() As Single
        Get
            ptGrvChan(pt_Config.Side) = Problem(IndProbl).GrvChan
            GrvChan = ptGrvChan(pt_Config.Side)
        End Get
        Set(ByVal Value As Single)
            ptGrvChan(pt_Config.Side) = Value
            Select Case pt_Config.Side
                Case 1 : Mem.Z(1, 545) = ptGrvChan(pt_Config.Side) + ptGrvShel(pt_Config.Side)
                Case 2 : Mem.Z(1, 552) = ptGrvChan(pt_Config.Side) + ptGrvShel(pt_Config.Side)
            End Select
            Problem(IndProbl).GrvChan = ptGrvChan(pt_Config.Side)
        End Set
    End Property
    Public Property GrvShel() As Single
        Get
            ptGrvShel(pt_Config.Side) = Problem(IndProbl).GrvShel
            GrvShel = ptGrvShel(pt_Config.Side)
        End Get
        Set(ByVal Value As Single)
            ptGrvShel(pt_Config.Side) = Value
            Select Case pt_Config.Side
                Case 1 : Mem.Z(1, 545) = ptGrvChan(pt_Config.Side) + ptGrvShel(pt_Config.Side)
                Case 2 : Mem.Z(1, 552) = ptGrvChan(pt_Config.Side) + ptGrvShel(pt_Config.Side)
            End Select
            Problem(IndProbl).GrvShel = ptGrvShel(pt_Config.Side)
        End Set
    End Property
    Public Property CavChan2() As Single
        Get
            ptCavChan2 = Problem(IndProbl2).CavChan
            CavChan2 = ptCavChan2 'Mem.Z(1, 20)
        End Get
        Set(ByVal Value As Single)
            ptCavChan2 = Value
            Mem.Z(1, 263) = ptCavChan2 + ptCavShel2
            Problem(IndProbl2).CavChan = ptCavChan2
        End Set
    End Property
    Public Property CavShel2() As Single
        Get
            ptCavShel2 = Problem(IndProbl2).CavShel
            CavShel2 = ptCavShel2
        End Get
        Set(ByVal Value As Single)
            ptCavShel2 = Value
            Mem.Z(1, 263) = ptCavChan2 + ptCavShel2
            Problem(IndProbl2).CavShel = ptCavShel2
        End Set
    End Property
    Public Property TipPass() As Short
        Get
            Select Case pt_Config.Square
                Case 1 : TipPass = 1
                Case 2 : TipPass = 0
            End Select
        End Get
        Set(ByVal Value As Short)
            Select Case Value
                Case 0 : pt_Config.Square = 2
                Case 1 : pt_Config.Square = 1
            End Select
        End Set
    End Property
    Public Property TSheDes() As Single
        Get
            TSheDes = Mem.Z(1, 308 + pt_Config.Side - 1)
        End Get
        Set(ByVal Value As Single)
            Mem.Z(1, 308 + pt_Config.Side - 1) = Value
        End Set
    End Property
    Public Property ProgDiffPr() As Boolean
        Get
            ProgDiffPr = Problem(IndProbl).PDIFF = 0
        End Get
        Set(ByVal Value As Boolean)
            If Value Then
                Problem(IndProbl).PDIFF = 0
            Else
                Problem(IndProbl).PDIFF = 1
            End If
            If IndProbl2 > 0 Then Problem(IndProbl2).PDIFF = Problem(IndProbl).PDIFF
        End Set
    End Property
    Public Property VacuumTS() As Boolean
        Get
            VacuumTS = Problem(IndProbl).Vacuum > 1
        End Get
        Set(ByVal Value As Boolean)
            If Value Then
                If VacuumSS Then Problem(IndProbl).Vacuum = 3 Else Problem(IndProbl).Vacuum = 2
            Else
                If VacuumSS Then Problem(IndProbl).Vacuum = 1 Else Problem(IndProbl).Vacuum = 0
            End If
        End Set
    End Property
    Public Property VacuumSS() As Boolean
        Get
            VacuumSS = Problem(IndProbl).Vacuum = 1 Or Problem(IndProbl).Vacuum = 3
        End Get
        Set(ByVal Value As Boolean)
            If Value Then
                If VacuumTS Then Problem(IndProbl).Vacuum = 3 Else Problem(IndProbl).Vacuum = 1
            Else
                If VacuumTS Then Problem(IndProbl).Vacuum = 2 Else Problem(IndProbl).Vacuum = 0
            End If
        End Set
    End Property
    Public Property FlChanNome() As String
        Get
            If pt_Config.Differing = 1 Then  'perché?????
                FlChanNome = FlChan(1).Identif
            Else
                FlChanNome = FlChan(IndProbl).Identif
            End If
        End Get
        Set(ByVal Value As String)
            If pt_Config.Differing = 1 Then  'perché?????
                FlChan(1).Identif = Value
            Else
                FlChan(IndProbl).Identif = Value
            End If
        End Set
    End Property
    Public Property FlShelNome() As String
        Get
            FlShelNome = FlShel(IndProbl).Identif
        End Get
        Set(ByVal Value As String)
            FlShel(IndProbl).Identif = Value
        End Set
    End Property
    Public Property SlChanNome() As String
        Get
            SlChanNome = FlChan(IndProbl).Identif
        End Get
        Set(ByVal Value As String)
            FlChan(IndProbl).Identif = Value
        End Set
    End Property
    Public Property SlShelNome() As String
        Get
            SlShelNome = FlShel(IndProbl).Identif
        End Get
        Set(ByVal Value As String)
            FlShel(IndProbl).Identif = Value
        End Set
    End Property
    Public Property pCondizio(ByVal i As Short) As String
        Get
            pCondizio = Mem.Condizio(i)
        End Get
        Set(ByVal Value As String)
            Mem.Condizio(i) = Value
        End Set
    End Property
    Public Property pNeventi(ByVal i As Short) As Short
        Get
            pNeventi = Mem.Neventi(i)
        End Get
        Set(ByVal Value As Short)
            Mem.Neventi(i) = Value
        End Set
    End Property
    Public Property FlChanDati(ByVal i As Short) As Object
        Get
            Select Case i
                Case 1
                    FlChanDati = FlChan(IndProbl).DextFla 'De Fl A
                Case 2
                    FlChanDati = FlChan(IndProbl).DintFla 'Di Fl A
                    Select Case pt_Config.Side
                        Case 1 : FlChanDati = Mem.Z(1, 22)
                        Case 2 : FlChanDati = Mem.Z(1, 312)
                    End Select
                Case 3
                    FlChanDati = FlChan(IndProbl).CodoMax 'g1 Fl A
                Case 4
                    FlChanDati = FlChan(IndProbl).CodoMin 'g0 Fl A
                Case 5
                    FlChanDati = FlChan(IndProbl).DmedGua 'Dmed gua A
                Case 6
                    FlChanDati = FlChan(IndProbl).LargGua 'N     A
                Case 7 : FlChanDati = Trim(FlChan(IndProbl).TipGuar) 'Tip gua  A
                Case 8 : FlChanDati = Trim(FlChan(IndProbl).MatGuar) 'Mat gua  A
                Case 9
                    FlChanDati = FlChan(IndProbl).mguar 'm        A
                Case 10
                    FlChanDati = FlChan(IndProbl).y 'Y     A
                Case 11
                    FlChanDati = FlChan(IndProbl).mtrav 'm trav   A
                Case 12
                    FlChanDati = FlChan(IndProbl).ytrav 'Y trav   A
                Case 13
                    FlChanDati = FlChan(IndProbl).ltrav 'l trav   A
                Case 14
                    FlChanDati = FlChan(IndProbl).btrav 'b trav   A
                Case 15
                    FlChanDati = FlChan(IndProbl).wm1 'Wm1      A
                Case 16
                    FlChanDati = FlChan(IndProbl).wm2 'Wm2      A
                Case 17
                    FlChanDati = FlChan(IndProbl).wm1H 'Wm1 HT   A
                Case 18
                    FlChanDati = FlChan(IndProbl).wm2H 'Wm2 HT   A
                Case 19
                    If FlChan(IndProbl).gefinc > 0 Then
                        FlChanDati = FlChan(IndProbl).gefinc * inc 'Gef  FlA()
                    Else
                        FlChanDati = FlChan(IndProbl).DmedGua 'Dmed gua A
                    End If
                Case 20
                    FlChanDati = FlChan(IndProbl).PHI
                Case 21
                    FlChanDati = FlChan(IndProbl).wot 'Wm1 HT   A
                Case 22
                    FlChanDati = FlChan(IndProbl).wotH 'Wm2 HT   A
                Case Else
                    FlChanDati = 0
            End Select
        End Get
        Set(ByVal Value As Object)
            Dim vNew As Single
            Dim j As Short
            Dim W As Single
            Select Case i
                Case 1
                    FlChan(IndProbl).DextFla = Value 'De Fl A
                    If pt_Config.Gasketed(1 - 1) = 2 Then
                        FlChan(IndProbl).DmedGua = Value - FlChan(IndProbl).LargGua
                        FlChan(IndProbl).PHI = 0
                    End If
                Case 2
                    FlChan(IndProbl).DintFla = Value 'Di Fl A
                    If Value > 0 Then
                        Select Case pt_Config.Side
                            Case 1
                                Mem.Z(1, 22) = Value
                            Case 2
                                Mem.Z(1, 312) = Value
                        End Select
                    End If
                Case 3
                    FlChan(IndProbl).CodoMax = Value 'g1 Fl A
                    If pt_Config.Gasketed(1 - 1) = 2 Then
                        FlChan(IndProbl).LargGua = Value
                        FlChan(IndProbl).DmedGua = FlChan(IndProbl).DextFla - FlChan(IndProbl).LargGua
                    End If
                Case 4
                    FlChan(IndProbl).CodoMin = Value 'g0 Fl A
                Case 5
                    FlChan(IndProbl).DmedGua = Value 'Dmed gua A
                Case 6
                    FlChan(IndProbl).LargGua = Value 'N     A
                Case 7
                    FlChan(IndProbl).TipGuar = Value 'Tip gua  A
                Case 8
                    FlChan(IndProbl).MatGuar = Value 'Mat gua  A
                Case 9
                    FlChan(IndProbl).mguar = Value 'm        A
                Case 10
                    FlChan(IndProbl).y = Value 'Y     A
                Case 11
                    FlChan(IndProbl).mtrav = Value 'm trav   A
                Case 12
                    FlChan(IndProbl).ytrav = Value 'Y trav   A
                Case 13
                    FlChan(IndProbl).ltrav = Value 'l trav   A
                Case 14
                    FlChan(IndProbl).btrav = Value 'b trav   A
                Case 15
                    FlChan(IndProbl).wm1 = Value 'Wm1      A
                    If Mem.Z(1, 264) = 0 Then Mem.Z(1, 264) = 1
                    For j = 1 To Mem.Z(1, 264)
                        Select Case pt_Config.Side
                            Case 0, 1
                                Mem.Z(j, 32) = Value * Braccio(1) '/ inc
                                vNew = FlShel(IndProbl).wm1 * Braccio(1) '/ inc
                                If vNew > Mem.Z(j, 32) Then Mem.Z(j, 32) = vNew
                            Case 2
                                Mem.Z(j, 269) = Value * Braccio(2) '/ inc
                                vNew = FlShel(IndProbl).wm1 * Braccio(2) '/ inc
                                If vNew > Mem.Z(j, 269) Then Mem.Z(j, 269) = vNew
                        End Select
                        TrasfW()
                    Next
                Case 16
                    FlChan(IndProbl).wm2 = Value 'Wm2      A
                    If Mem.Z(1, 264) = 0 Then Mem.Z(1, 264) = 1
                    For j = 1 To Mem.Z(1, 264)
                        Select Case pt_Config.Side
                            Case 0, 1
                                Mem.Z(j, 33) = Value * Braccio(1) '/ inc
                                vNew = FlShel(IndProbl).wm2 * Braccio(1) ' / inc
                                If vNew > Mem.Z(j, 33) Then Mem.Z(j, 33) = vNew
                            Case 2
                                Mem.Z(j, 270) = Value * Braccio(2) '/ inc
                                vNew = FlShel(IndProbl).wm2 * Braccio(2) ' / inc
                                If vNew > Mem.Z(j, 270) Then Mem.Z(j, 270) = vNew
                        End Select
                        TrasfW()
                    Next
                Case 17
                    FlChan(IndProbl).wm1H = Value 'Wm1 HT   A
                Case 18
                    FlChan(IndProbl).wm2H = Value 'Wm2 HT   A
                Case 19
                    FlChan(IndProbl).gefinc = Value / inc 'Gef  Fl A
                    Select Case pt_Config.Side
                        Case 0, 1
                            Mem.Z(1, 293) = Value
                        Case 2
                            Mem.Z(1, 316) = Value
                    End Select
                Case 20
                    FlChan(IndProbl).PHI = Value
                Case 21
                    FlChan(IndProbl).wot = Value
                    W = FlChanDati(21)
                    Mem.Z(iCond + Offset, 635) = W
                    W = FlShelDati(21)
                    Mem.Z(iCond + Offset, 634) = W
                Case 22
                    FlChan(IndProbl).wotH = Value
            End Select
        End Set
    End Property
    Public Property SlChanDati(ByVal i As Short) As Single
        Get
            Select Case pt_Config.Side
                Case 1
                    Select Case i
                        Case 1 : SlChanDati = Mem.Z(1, 22)
                        Case 2 : SlChanDati = Mem.Z(1, 24)
                    End Select
                Case 2
                    Select Case i
                        Case 1 : SlChanDati = Mem.Z(1, 312)
                        Case 2 : SlChanDati = Mem.Z(1, 313)
                    End Select
            End Select
        End Get
        Set(ByVal Value As Single)
            Select Case pt_Config.Side
                Case 1
                    Select Case i
                        Case 1
                            Mem.Z(1, 22) = Value
                        Case 2
                            Mem.Z(1, 24) = Value
                    End Select
                Case 2
                    Select Case i
                        Case 1
                            Mem.Z(1, 312) = Value
                        Case 2
                            Mem.Z(1, 313) = Value
                    End Select
            End Select
        End Set
    End Property
    Public Property FlShelDati(ByVal i As Short) As Object
        Get
            Select Case i
                Case 1
                    FlShelDati = FlShel(IndProbl).DextFla 'De Fl A
                Case 2
                    FlShelDati = FlShel(IndProbl).DintFla 'Di Fl A
                Case 3
                    FlShelDati = FlShel(IndProbl).CodoMax 'g1 Fl A
                Case 4
                    FlShelDati = FlShel(IndProbl).CodoMin 'g0 Fl A
                Case 5
                    FlShelDati = FlShel(IndProbl).DmedGua 'Dmed gua A
                Case 6
                    FlShelDati = FlShel(IndProbl).LargGua 'N     A
                Case 7 : FlShelDati = Trim(FlShel(IndProbl).TipGuar) 'Tip gua  A
                Case 8 : FlShelDati = Trim(FlShel(IndProbl).MatGuar) 'Mat gua  A
                Case 9
                    FlShelDati = FlShel(IndProbl).mguar 'm        A
                Case 10
                    FlShelDati = FlShel(IndProbl).y 'Y     A
                Case 11
                    FlShelDati = FlShel(IndProbl).mtrav 'm trav   A
                Case 12
                    FlShelDati = FlShel(IndProbl).ytrav 'Y trav   A
                Case 13
                    FlShelDati = FlShel(IndProbl).ltrav 'l trav   A
                Case 14
                    FlShelDati = FlShel(IndProbl).btrav 'b trav   A
                Case 15
                    FlShelDati = FlShel(IndProbl).wm1 'Wm1      A
                Case 16
                    FlShelDati = FlShel(IndProbl).wm2 'Wm2      A
                Case 17
                    FlShelDati = FlShel(IndProbl).wm1H 'Wm1 HT   A
                Case 18
                    FlShelDati = FlShel(IndProbl).wm2H 'Wm2 HT   A
                Case 19
                    If FlShel(IndProbl).gefinc > 0 Then
                        FlShelDati = FlShel(IndProbl).gefinc * inc 'Gef  FlA()
                    Else
                        FlShelDati = FlShel(IndProbl).DmedGua 'Dmed gua A
                    End If
                Case 20
                    FlShelDati = FlShel(IndProbl).PHI
                Case 21
                    FlShelDati = FlShel(IndProbl).wot 'Wm1 HT   A
                Case 22
                    FlShelDati = FlShel(IndProbl).wotH 'Wm2 HT   A
                Case Else
                    FlShelDati = 0
            End Select
        End Get
        Set(ByVal Value As Object)
            Dim vNew, W As Single
            Dim j As Short
            If Len(Value) = 0 Then Value = 0
            Select Case i
                Case 1
                    FlShel(IndProbl).DextFla = Value 'De Fl A
                Case 2
                    FlShel(IndProbl).DintFla = Value 'Di Fl A
                Case 3
                    FlShel(IndProbl).CodoMax = Value 'g1 Fl A
                Case 4
                    FlShel(IndProbl).CodoMin = Value 'g0 Fl A
                Case 5
                    FlShel(IndProbl).DmedGua = Value 'Dmed gua A
                Case 6
                    FlShel(IndProbl).LargGua = Value 'N     A
                Case 7
                    FlShel(IndProbl).TipGuar = Value 'Tip gua  A
                Case 8
                    FlShel(IndProbl).MatGuar = Value 'Mat gua  A
                Case 9
                    FlShel(IndProbl).mguar = Value 'm        A
                Case 10
                    FlShel(IndProbl).y = Value 'Y     A
                Case 11
                    FlShel(IndProbl).mtrav = Value 'm trav   A
                Case 12
                    FlShel(IndProbl).ytrav = Value 'Y trav   A
                Case 13
                    FlShel(IndProbl).ltrav = Value 'l trav   A
                Case 14
                    FlShel(IndProbl).btrav = Value 'b trav   A
                Case 15
                    FlShel(IndProbl).wm1 = Value 'Wm1      A
                    For j = 1 To Mem.Z(1, 264)
                        Select Case pt_Config.Side
                            Case 0, 1
                                Mem.Z(j, 32) = Value * Braccio(1) '/ inc
                                vNew = FlChan(IndProbl).wm1 * Braccio(1) ' / inc
                                If vNew > Mem.Z(j, 32) Then Mem.Z(j, 32) = vNew
                            Case 2
                                Mem.Z(j, 269) = Value * Braccio(2) '/ inc
                                vNew = FlChan(IndProbl).wm1 * Braccio(2) ' / inc
                                If vNew > Mem.Z(j, 269) Then Mem.Z(j, 269) = vNew
                        End Select
                        TrasfW()
                    Next
                Case 16
                    FlShel(IndProbl).wm2 = Value 'Wm2      A
                    For j = 1 To Mem.Z(1, 264)
                        Select Case pt_Config.Side
                            Case 0, 1
                                Mem.Z(j, 33) = Value * Braccio(1) '/ inc
                                vNew = FlChan(IndProbl).wm2 * Braccio(1) '/ inc
                                If vNew > Mem.Z(j, 33) Then Mem.Z(j, 33) = vNew
                            Case 2
                                Mem.Z(j, 270) = Value * Braccio(2) '/ inc
                                vNew = FlChan(IndProbl).wm2 * Braccio(2) '/ inc
                                If vNew > Mem.Z(j, 270) Then Mem.Z(j, 270) = vNew
                        End Select
                        TrasfW()
                    Next
                Case 17
                    FlShel(IndProbl).wm1H = Value 'Wm1 HT   A
                Case 18
                    FlShel(IndProbl).wm2H = Value 'Wm2 HT   A
                Case 19
                    FlShel(IndProbl).gefinc = Value / inc 'Gef  Fl A
                    Select Case pt_Config.Side
                        Case 0, 1
                            Mem.Z(1, 292) = Value
                        Case 2
                            Mem.Z(1, 315) = Value
                    End Select
                Case 20
                    FlShel(IndProbl).PHI = Value
                Case 21
                    FlShel(IndProbl).wot = Value 'Wm1 HT   A
                    W = FlChanDati(21)
                    Mem.Z(iCond + Offset, 635) = W
                    W = FlShelDati(21)
                    Mem.Z(iCond + Offset, 634) = W
                Case 22
                    FlShel(IndProbl).wotH = Value 'Wm2 HT   A
            End Select
            Exit Property
        End Set
    End Property
    Private Sub TrasfW()
        Dim W As Single = FlChanDati(15) '  .Zp(iCond + Offset, 32)
        If FlChanDati(16) > W Then W = FlChanDati(16)
        Mem.Z(j + Offset, 635) = W
        W = FlShelDati(15)
        If FlShelDati(16) > W Then W = FlShelDati(16)
        Mem.Z(j + Offset, 634) = W
    End Sub
    Public Property SlShelDati(ByVal i As Short) As Single
        Get
            Select Case pt_Config.Side
                Case 1
                    Select Case i
                        Case 1 : SlShelDati = Mem.Z(1, 21)
                        Case 2 : SlShelDati = Mem.Z(1, 659)
                        Case 3 : SlShelDati = Mem.Z(1, 661)
                    End Select
                Case 2
                    Select Case i
                        Case 1 : SlShelDati = Mem.Z(1, 314)
                        Case 2 : SlShelDati = Mem.Z(1, 660)
                        Case 3 : SlShelDati = Mem.Z(1, 662)
                    End Select
            End Select
        End Get
        Set(ByVal Value As Single)
            Select Case pt_Config.Side
                Case 1
                    Select Case i
                        Case 1
                            Mem.Z(1, 21) = Value
                        Case 2
                            Mem.Z(1, 659) = Value
                        Case 3
                            Mem.Z(1, 661) = Value
                    End Select
                Case 2
                    Select Case i
                        Case 1
                            Mem.Z(1, 314) = Value
                        Case 2
                            Mem.Z(1, 660) = Value
                        Case 3
                            Mem.Z(1, 662) = Value
                    End Select
            End Select
        End Set
    End Property
    Public Property SpessMant() As Single
        Get
            SpessMant = Mem.Z(1, 23)
        End Get
        Set(ByVal Value As Single)
            Mem.Z(1, 23) = Value
        End Set
    End Property
    Public Property PHI(ByVal i As Short) As Single
        Get
            Select Case i
                Case 1 : PHI = FlShel(IndProbl).PHI
                Case 2 : PHI = FlChan(IndProbl).PHI
            End Select
        End Get
        Set(ByVal Value As Single)
            Select Case i
                Case 1 : FlShel(IndProbl).PHI = Value
                Case 2 : FlChan(IndProbl).PHI = Value
            End Select
        End Set
    End Property
    Public Property wn(ByVal i As Short) As Single
        Get
            Select Case i
                Case 1 : wn = FlShel(IndProbl).wn
                Case 2 : wn = FlChan(IndProbl).wn
            End Select
        End Get
        Set(ByVal Value As Single)
            Select Case i
                Case 1 : FlShel(IndProbl).wn = Value
                Case 2 : FlChan(IndProbl).wn = Value
            End Select
        End Set
    End Property
    Public Property IndFac(ByVal i As Short) As Short
        Get
            Select Case i
                Case 1 : IndFac = FlShel(IndProbl).IndFac
                Case 2 : IndFac = FlChan(IndProbl).IndFac
            End Select
        End Get
        Set(ByVal Value As Short)
            Select Case i
                Case 1 : FlShel(IndProbl).IndFac = Value
                Case 2 : FlChan(IndProbl).IndFac = Value
            End Select
        End Set
    End Property
    Public Property TipGsk(ByVal i As Short) As Short
        Get
            Select Case i
                Case 1 : TipGsk = FlShel(IndProbl).TipGsk
                Case 2 : TipGsk = FlChan(IndProbl).TipGsk
            End Select
        End Get
        Set(ByVal Value As Short)
            Select Case i
                Case 1 : FlShel(IndProbl).TipGsk = Value
                Case 2 : FlChan(IndProbl).TipGsk = Value
            End Select
        End Set
    End Property
    Public Property ClassGsk(ByVal i As Short) As Short
        Get
            Select Case i
                Case 1 : ClassGsk = FlShel(IndProbl).ClassGsk
                Case 2 : ClassGsk = FlChan(IndProbl).ClassGsk
            End Select
        End Get
        Set(ByVal Value As Short)
            Select Case i
                Case 1 : FlShel(IndProbl).ClassGsk = Value
                Case 2 : FlChan(IndProbl).ClassGsk = Value
            End Select
        End Set
    End Property
    Public Property XFil(ByVal i As Short) As Short
        Get
            ' XFil = Piastra.XFil
        End Get
        Set(ByVal Value As Short)
            '  Piastra.XFil = vNewValue
        End Set
    End Property
    Public Property Zp(ByVal i As Short, ByVal j As Short) As Single
        Get
            Select Case j
                Case 594
                    If Mem.Z(i, j) = 0 Then Mem.Z(i, j) = Mem.Z(4, j)
                Case 595
                    If Mem.Z(i, j) = 0 Then Mem.Z(i, j) = Mem.Z(5, j)
                Case 596
                    If Mem.Z(i, j) = 0 Then Mem.Z(i, j) = Mem.Z(6, j)
            End Select
            If i = 0 And Not j = 287 Then i = iCond
            Zp = Mem.Z(i, j)
        End Get
        Set(ByVal Value As Single)
            If i = 0 And Not j = 287 Then i = iCond 'mod elastico a freddo bellows
            Mem.Z(i, j) = Value
        End Set
    End Property
    Public Property Neventip(ByVal i As Short) As Short
        Get
            Neventip = Mem.Neventi(i)
        End Get
        Set(ByVal Value As Short)
            Mem.Neventi(i) = Value
        End Set
    End Property
    Public Property iCondp() As Short
        Get
            iCondp = iCond
        End Get
        Set(ByVal Value As Short)
            iCond = Value
        End Set
    End Property
    Public Property TipoDilatp() As Short
        Get
            TipoDilatp = pt_Config.TipoDilat
        End Get
        Set(ByVal Value As Short)
            pt_Config.TipoDilat = Value
        End Set
    End Property
    Public Property TipoGiunto() As Short
        Get
            TipoGiunto = pt_Config.TipoGiunto
        End Get
        Set(ByVal Value As Short)
            pt_Config.TipoGiunto = Value
        End Set
    End Property
    Public Property IndiceFlanF() As Short
        Get
            IndiceFlanF = pt_Config.IndiceFlanF
        End Get
        Set(ByVal Value As Short)
            pt_Config.IndiceFlanF = Value
        End Set
    End Property
    Public Property IndiceSplitR() As Short
        Get
            IndiceSplitR = pt_Config.IndiceSplitR
        End Get
        Set(ByVal Value As Short)
            pt_Config.IndiceSplitR = Value
        End Set
    End Property
    Public Property IndiceChanF() As Short
        Get
            IndiceChanF = pt_Config.IndiceChanF
        End Get
        Set(ByVal Value As Short)
            pt_Config.IndiceChanF = Value
        End Set
    End Property
    Public Property IndiceFondo() As Short
        Get
            IndiceFondo = pt_Config.IndiceFondo
        End Get
        Set(ByVal Value As Short)
            pt_Config.IndiceFondo = Value
        End Set
    End Property
    Public Property IndiceDilat() As Short
        Get
            IndiceDilat = pt_Config.IndiceDilat
        End Get
        Set(ByVal Value As Short)
            pt_Config.IndiceDilat = Value
        End Set
    End Property
    Public Property IndiceShell() As Short
        Get
            IndiceShell = pt_Config.IndiceShell
        End Get
        Set(ByVal Value As Short)
            pt_Config.IndiceShell = Value
        End Set
    End Property
    Public Property BiFlangiata() As Boolean
        Get
            If pt_Config.Side = 0 Then pt_Config.Side = 1
            BiFlangiata = Gasketed(pt_Config.Side) = -1
        End Get
        Set(ByVal Value As Boolean)

        End Set
    End Property
    Public Property IBW() As Boolean
        Get
            IBW = Problem(IndProbl).IBW
        End Get
        Set(ByVal Value As Boolean)
            Problem(IndProbl).IBW = Value
        End Set
    End Property
    Public Property RadialExp() As Boolean
        Get
            RadialExp = Problem(IndProbl).RadialExp
        End Get
        Set(ByVal Value As Boolean)
            Problem(Indprobl1).RadialExp = Value
            Problem(IndProbl2).RadialExp = Value
        End Set
    End Property
    Public Property BullDistinti() As Boolean
        Get
            BullDistinti = Problem(IndProbl).BullDistinti <> 0
        End Get
        Set(ByVal Value As Boolean)
            If Value Then Problem(IndProbl).BullDistinti = 1 Else Problem(IndProbl).BullDistinti = 0
        End Set
    End Property
    Public Property BullIndip() As Boolean
        Get
            BullIndip = Problem(IndProbl).BullDistinti = 1
        End Get
        Set(ByVal Value As Boolean)
            If Value And Problem(IndProbl).BullDistinti < 1 Then
                Problem(IndProbl).BullDistinti = 1
            ElseIf Not Value Then
                Problem(IndProbl).BullDistinti = 0
            End If
        End Set
    End Property
    Public Property diamIBW() As Single
        Get
            diamIBW = Problem(IndProbl).diamIBW
        End Get
        Set(ByVal Value As Single)
            Problem(IndProbl).diamIBW = Value
        End Set
    End Property
    Public Sub Testatap(Optional ByRef mode As Short = 0)
        Dim ifl, i As Short
        Dim StriSt(19) As String
        Dim Ext As String = ""
        Dim Nome As String = ""
        ifl = FreeFile()
        Select Case CalcoloInCorso
            Case 0 : Ext = ".FTC"
            Case 1
                If UltimoAggiornamento = 2 Then
                    Ext = "AA.FTC"
                ElseIf UltimoAggiornamento >= 3 Then
                    If pt_Config.Rear = 2 Then
                        Ext = "UHX.FTC"
                    Else
                        Ext = "UHXFX.FTC"
                    End If
                End If
        End Select
        Nome = RTrim(Monitor.Motore.Inizio.Archdir) & "\RTF\PTFF01" & Ext
900:    If Not OpenFile(Nome, ifl) Then Exit Sub
        For i = 1 To 19 : StriSt(i) = LineInput(ifl) : Next
        FileClose(ifl)
        With Monitor.Motore.Problem
            .pag += 1
            If .pag > 1 Then .Printa("\par \page ")
            .Printa(GlobalRoutines.FormatS(StriSt(3), clsInizio.Firma))
            .Printa(StriSt(4))
            If Not pt_Config.SoloDilat Or pt_Config.Rear = 2 Then
920:            Contarig = 13
                '            PRINT #iout, "           TUBULAR EXCHANGER MANUFACTURER ASSOCIATION 1988 7th ed. + add.92"
                '            PRINT #iout, "           ----------------------------------------------------------------"
                '            PRINT #iout, "                             RCB-7.132 RCB-7.16 RCB-8"
                '            PRINT #iout, "                  FIXED-FLOATING TUBESHEETS WITH-WITHOUT EXTENSION "
                '            PRINT #iout, "            U TUBE TUBESHEETS WITHOUT EXTENSION  -  FLEXIBLE SHELL ELEMENTS"
                '            PRINT #iout, "            ---------------------------------------------------------------"
                If mode = 0 Then For i = 5 To 10 : .Printa(StriSt(i)) : Next
            Else
                If pt_Config.TipoDilat < 3 Or pt_Config.TipoDilat = 6 Then
                    Contarig = 10
930:                .Printa(StriSt(5))  ' "           TUBULAR EXCHANGER MANUFACTURER ASSOCIATION 1988 7th ed. + add.92"
                    .Printa(StriSt(6))  ' "           ----------------------------------------------------------------"
                    .Printa(StriSt(11))  ' "                             RCB-8 FLEXIBLE SHELL ELEMENTS"
                Else
                    Contarig = 9
                    .Printa(StriSt(12))  ' "             EXPANSION JOINTS MANUFACTURERS ASSOCIATION 1993 6th edition"
                    .Printa(StriSt(13))  '"             -----------------------------------------------------------"
                End If
            End If
            '      If mode = 0 Then Print #iout, StriSt$(14)
            .Printa(GlobalRoutines.FormatS(StriSt(15), Monitor.Motore.About.ProgName, Monitor.Motore.About.ProgVers))  '"         Program name: \                                                \ Vers. \  \ "
            .Printa(GlobalRoutines.FormatS(StriSt(19), Monitor.Motore.About.Code))
            '      Print #iout, StriSt$(14)
            .Printa(GlobalRoutines.FormatS(StriSt(16), job.Comm.Arch, _
                      job.Comm.Ind.Item(job.Comm.NumAs).Data.Assieme, _
                      job.Comm.Ind.Item(job.Comm.NumAs).Data.File))  '"                                FBM Job Nø \  \  Item \        \  Dwg Nø \        \"
            .Printa(GlobalRoutines.FormatS(StriSt(17), job.Comm.Clie, job.Comm.Comp))  '"                                Customer   \                   \  Designer \      \"
        End With
    End Sub
    Public Sub LegScr(ByRef ifl As Short, ByRef SaltaPag As Short, ByRef Stringa3() As String, ByRef Stringa4() As String, ByRef Stringa5() As String, ByRef Stringa6() As String, ByRef Stringa7() As String)
        Dim Stringa8(2) As String
        Dim Stringa9(5) As String
        Dim Nulla As String
        Dim Condi As String
        Dim Rig1 As String = ""
        Dim Rig As String = ""
        Dim T2 As String = ""
        Dim T3 As String = ""
        Dim a As String = ""
        Dim i As Short
        Dim Posi4, Posi3, n As Short
        Dim B1, B2 As Single
        Dim Nome, Nome1 As String
        Dim Classe, Class1 As String
        Dim R1, fe, Par, strfy, R2 As String
        Dim Car, Corr, Car1 As String
        Dim ZZ, ZZSI As Single
        If Contarig > 50 And SaltaPag Then Call FinePag(1)
        Nulla = "\par "
        Stringa9(1) = "P - Outside packed   "
        Stringa9(2) = "S - with back-ring   "
        Stringa9(3) = "T - Flanged          "
        Stringa9(4) = "T - Integral         "
        Stringa9(5) = "W - internally sealed"
        Stringa8(2) = "(Triangular)"
        Stringa8(1) = "(Square)    "
        Try
            With Mem
                Do
10540:              If EOF(ifl) Or RTrim(Rig) = "Fine" Then
                        FileClose(ifl)
                        Exit Sub
                    End If
                    Contarig = Contarig + 1
                    Rig = LineInput(ifl)
                    Rig1 = Mid(Rig, 1, 1)
                    If Rig1 = "B" Then Monitor.Motore.Problem.Printa(Nulla) : Contarig = Contarig + 1 : GoTo 10540
                    If Rig1 = "F" Then FileClose(ifl) : Exit Sub
                    If Rig1 = "H" And VerificandoPI Then FileClose(ifl) : Exit Sub
                    If Rig1 = "T" Then Call Testatap() : GoTo 10540
10545:              T2 = Mid(Rig, 2, 3)
10546:              Posi = GlobalRoutines.ValVir(T2)
                    If GlobalRoutines.ValVir(Rig1) = 6 Or GlobalRoutines.ValVir(Rig1) = 9 Or Rig1 = "P" Or Rig1 = "D" Then
10547:                  Posi2 = GlobalRoutines.ValVir(Mid(Rig, 5, 3))
                        T3 = Right(Rig, Len(Rig) - 7)
                    ElseIf Rig1 = "d" Or Rig1 = "f" Or Rig1 = "U" Or Rig1 = "W" Then
                        Posi2 = GlobalRoutines.ValVir(Mid(Rig, 5, 3))
                        T3 = Right(Rig, Len(Rig) - 7)
                    ElseIf GlobalRoutines.ValVir(Rig1) = 8 Then
10548:                  Posi2 = GlobalRoutines.ValVir(Mid(Rig, 5, 3))
                        Posi3 = GlobalRoutines.ValVir(Mid(Rig, 8, 3))
                        T3 = Right(Rig, Len(Rig) - 10)
                    ElseIf GlobalRoutines.ValVir(Rig1) = 7 Or Rig1 = "Q" Then
10549:                  Posi2 = GlobalRoutines.ValVir(Mid(Rig, 5, 3))
                        Posi3 = GlobalRoutines.ValVir(Mid(Rig, 8, 3))
                        Posi4 = GlobalRoutines.ValVir(Mid(Rig, 11, 3))
                        T3 = Right(Rig, Len(Rig) - 13)
                        '      ElseIf Rig1$ = "0" And Mid$(Rig$, 2, 3) = "   " Then
                        '10560    Posi2% = 0
                        '         T3$ = Right$(Rig$, Len(Rig$) - 4)
                    Else
                        Posi2 = 0
                        T3 = Right(Rig, Len(Rig) - 4)
                        '         T3$ = Rig$
                    End If
                    Select Case Rig1
                        Case "0", "H"
                            n = InStr(T3, "MAWP")
                            If n > 0 Then
                                If Config(0).CalcMAWP Then Monitor.Motore.Problem.Printa(T3)
                            Else
                                n = InStr(T3, "MAWP's")
                                If n > 0 And Problem(IndProbl).PDIFF = 0 And Not pt_Config.Rear = 1 Then
                                    T3 = Left(T3, n + 4) & " differential" & "\par"
                                End If
                                If n = 0 Or Config(0).CalcMAWP Then Monitor.Motore.Problem.Printa(T3)
                            End If
                        Case "1"
                            If Posi < 800 Then
                                Select Case Posi
                                    Case 251 To 258, 285
                                        Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(T3, .Z(iCond, Posi) / NIUT))
                                    Case 29, 39, 145 To 158, 171 To 184, 271, 436 To 463, 599 To 612, 761
                                        Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(T3, .Z(iCond, Posi)))
                                        'un altro modo e di mettere codice "g" invece che "1"
                                    Case Else
                                        Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(T3, .Z(iCond, Posi) * psi))
                                End Select
                            ElseIf Posi = 13 Then
                                If CalcoloInCorso = 1 And iCond > 3 Then
                                    Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(T3, 2 * .Z(iCond, Posi)))
                                Else
                                    Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(T3, .Z(iCond, Posi)))
                                End If
                            Else
                                Decode()
                                Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(T3, Decoded))
                            End If
                        Case "2"
                            If Posi = 241 Or (Posi >= 147 And Posi <= 158) Or (Posi >= 376 And Posi <= 381) Then
                                Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(T3, .Z(iCond + Offset, Posi), .Z(iCond + Offset, Posi) / inc))
                            ElseIf Posi = 754 Then
                                Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(T3, .Z(iCond + Offset, Posi), .Z(iCond + Offset, Posi) / inc / inc))
                            ElseIf Posi < 800 Then
                                Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(T3, .Z(iCond, Posi), .Z(iCond, Posi) / inc))
                            Else
                                Decode()
                                If Posi = 854 Then
                                    Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(T3, Decoded, Decoded * psi))
                                Else
                                    Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(T3, Decoded, Decoded / inc))
                                End If
                            End If
                        Case "3"
                            If Posi < 800 Then
                                'If Posi% = 14 Then Print #iout, FormatS(T3$, .Z(iCond, Posi%), MAT4S$)
                                'If Posi% = 15 Then Print #iout, FormatS(T3$, .Z(iCond, Posi%), MAT5S$)
                            Else
                                Decode()
                                Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(T3, Decoded, Decode1, Decode2))
                            End If
                        Case "4" : Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(T3, .Z(iCond, Posi), .Z(iCond, Posi + 1), .Z(iCond, 12), 6))
                        Case "5" : Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(T3, .Z(iCond, Posi), .Z(iCond, Posi + 1), .Z(iCond, 13)))
                        Case "6"
                            If Posi < 5 And Posi2 < 5 Then
                                UnitMis(T3, Posi, Posi2)
                                If VerificandoPI Then
                                    If Posi = 1 Then
                                        Monitor.Motore.Problem.Printa("    Hydrotest conditions:\par")
                                        Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(T3, Ps, PT))
                                    Else
                                        Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(T3, PDE, 20))
                                    End If
                                Else
                                    Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(T3, .Z(iCond, Posi), .Z(iCond, Posi2)))
                                End If
                            ElseIf Posi2 = 35 Then
                                If VerificandoPI Then Posi2 = 629
                                Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(T3, .Z(iCond, Posi), .Z(iCond, Posi2)))
                            ElseIf Posi < 800 Then
                                Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(T3, .Z(iCond, Posi), .Z(iCond, Posi2)))
                            Else
                                Decode()
                                If Posi2 = 0 Then
                                    Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(T3, Decoded, Decode1))
                                Else
                                    Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(T3, Decoded, Decode1, Decode2))
                                End If
                            End If
                        Case "7"
                            If Posi < 800 Then
                                Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(T3, .Z(iCond, Posi), .Z(iCond, Posi2), .Z(iCond, Posi3), .Z(iCond, Posi4)))
                            Else
                                Decode()
                                If Posi2 = 0 Then
                                    Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(T3, Decoded, Decode1, Decode2, Decode3))
                                Else
                                    Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(T3, Decoded, Decode1, Decode2, Decode3, Decode4, Decode5))
                                End If
                            End If
                        Case "8" : Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(T3, .Z(iCond, Posi), .Z(iCond, Posi2), .Z(iCond, Posi3)))
                        Case "9" : Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(T3, .Z(iCond, Posi), Stringa8(pt_Config.Square), .Z(iCond, Posi2)))
                        Case "A"
                            If Posi = 51 Then
                                If pt_Config.Differing > 1 Then
                                    Car = "A"
                                    If pt_Config.Side = 2 Then Car = "B"
                                    Corr = "Read L{_\sub " & Car & "} per RCB-7.166 in formula for F{_\sub q}_\par "
                                    i = InStr(T3, "T")
                                    T3 = Left(T3, i - 1) & Corr
                                End If
                            End If
                            Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(T3, .Z(iCond, Posi), .Z(iCond, Posi + 1)))
                        Case "a" : Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(T3, .Z(iCond, Posi), .Z(iCond, Posi + 1)))
                        Case "C" : Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(T3, .Z(iCond, Posi), .Z(iCond, Posi + 1))) 'era * inc tutti e due
                        Case "c"
                            For i = 1 To .Z(1, 261)
                                Condi = .Condizio(i)
                                If Len(Trim(Condi)) = 0 Then Condi = "Untitled"
                                Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(T3, i, Condi))
                            Next
                            Contarig = Contarig + .Z(1, 261) - 1
                        Case "D"
                            If .Z(iCond, Posi) > 0 Then
                                Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(T3, .Z(iCond, Posi), .Z(iCond, Posi2))) 'era * inc tutti e due
                            End If
                        Case "d"
                            If .Z(iCond + 8, Posi) > 0 Then
                                Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(T3, .Z(iCond + 8, Posi), .Z(iCond + 8, Posi2)))  'era * inc tutti e due
                            End If
                        Case "E"
                            If Posi < 33 Then
                                Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(T3, .Z(iCond, Posi), .Z(iCond, Posi) * psi))
                            Else
                                Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(T3, .Z(iCond + Offset, Posi), .Z(iCond + Offset, Posi) * psi))
                            End If
                        Case "e" 'lunghezza di mandrinatura
                            If pt_Config.TipoGiunto < 9 Then
                                If Padre.ltxperc Then
                                    Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(T3, Padre.ltx, "%"))
                                Else
                                    Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(T3, Padre.ltx, "mm"))
                                End If
                            Else
                                T3 = "  TubeSheet   Grooves Depth  ####.#  [mm]   TubeSheet   Nom.Thickness    ##.###  [in]_\par"
                                Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(T3, diamIBW, diamIBW / inc))
                            End If
                        Case "f" : Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(T3, .Z(iCond + 8, Posi), .Z(iCond + 8, Posi2)))
                        Case "G"
                            If Posi = 32 Or Posi = 33 Then
                                ' ZZ = .Z(iCond + 8, Posi) * Braccio(pt_Config.Side)
                                ZZSI = .Z(iCond + 8, Posi) * Braccio(pt_Config.Side)
                                Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(T3, ZZSI, ZZSI / NIUT / inc * 1000))
                            ElseIf Posi = 434 Then
                                Car = "N.A." : Car1 = "N.A."
                                Select Case Padre.TipoAA
                                    Case 5, 6, 7
                                        Car1 = Format(Convert(.Z(iCond, Posi), Posi, 1), FormTemp)
                                        Car = Format(.Z(iCond, Posi), FormTemp)
                                End Select
                                Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(T3, Car, Car1))
                            ElseIf Posi = 435 Then
                                Car = "N.A." : Car1 = "N.A."
                                Select Case Padre.TipoAA
                                    Case 5
                                        Car1 = Format(Convert(.Z(iCond, Posi), Posi, 1), FormTemp)
                                        Car = Format(.Z(iCond, Posi), FormTemp)
                                End Select
                                Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(T3, Car, Car1))
                            ElseIf Posi = 537 Or Posi = 538 Then
                                Car = " " : Car1 = " "
                                If .Z(iCond, 537) > 1 Or .Z(iCond, 538) > 1 Then
                                    Car = "NOT" : Car1 = "NO"
                                End If
                                Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(T3, Car, Car1))
                            ElseIf Posi = 765 Or Posi = 766 Then
                                Car = " " : Car1 = " "
                                If .Z(iCond, 765) > 1 Or .Z(iCond, 766) > 1 Then
                                    Car = "NOT" : Car1 = "NO"
                                End If
                                Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(T3, Car, Car1))
                            ElseIf Posi = 767 Or Posi = 768 Then
                                Car = " " : Car1 = " "
                                If .Z(iCond, 767) > 1 Or .Z(iCond, 768) > 1 Then
                                    Car = "NOT" : Car1 = "NO"
                                End If
                                Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(T3, Car, Car1))
                            Else
                                Select Case Posi
                                    '  Case 777, 595 ' temperature Ts e Ts' (UHX)
                                    '     If Padre.TipoAA < 8 Then Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(T3, .Z(iCond, Posi), Convert(.Z(iCond, Posi), Posi, 1)))
                                    'Case 322, 596 ' temperatura Tc (UHX)
                                    '       If Padre.TipoAA < 6 Then Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(T3, .Z(iCond, Posi), Convert(.Z(iCond, Posi), Posi, 1)))
                                Case Else
                                        Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(T3, .Z(iCond, Posi), Convert(.Z(iCond, Posi), Posi, 1)))
                                End Select
                            End If
                        Case "g" : Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(T3, .Z(iCond, Posi)))
                        Case "I"
                            If .Z(iCond, Posi) < 0 Then
                                Car = Format(.Z(iCond, Posi), "#####.#")
                            Else
                                Car = "N.A."
                            End If
                            Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(T3, Car))
                        Case "i"
                            Select Case UltimoAggiornamento
                                Case 1, 2 : a = "AA-3.1"
                                Case Else : a = "UHX-14"
                            End Select
                            Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(T3, a))
                        Case "J" : Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(T3, Convert(.Z(iCond, Posi), Posi, 1), Convert(.Z(iCond, Posi), Posi, 1)))
                        Case "j" : Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(T3, .Z(iCond, Posi), .Z(iCond, Posi)))
                            If Posi = 285 Then
                                T3 = "_\par Note.: the above value has been obtained (see App.A) with "
                                If pt_Config.fy = 10 Then
                                    T3 = T3 & "f{_\sub r}=#.## _\par"
                                    Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(T3, pt_Config.fr))
                                Else
                                    T3 = T3 & "f{_\sub r}=#.##, f{_\sub e}=#.##, f{_\sub y}=#.## _\par"
                                    Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(T3, pt_Config.fr, pt_Config.fe, fy(iCond)))
                                End If
                            End If
                        Case "K", "k" : a = .Condizio(iCond)
                            If pt_Config.Differing > 1 And Rig1 = "K" Then
                                If pt_Config.Side = 1 Then a = a & " ({\b front tubesheet})" Else a = a & " ({\b rear tubesheet})"
                            End If
                            Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(T3, iCond, a))
                        Case "L"
                            If pt_Config.Rear = 1 And pt_Config.Differing < 3 Then
                                Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(T3, Int(.Z(1, 261)), Stringa3(pt_Config.Differing)))
                            ElseIf pt_Config.Differing = 3 Then
                                Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(T3, Int(.Z(1, 261))))
                            Else
                                Contarig = Contarig - 1
                            End If
                        Case "q"
                            Nome = ""
                            Select Case Posi
                                Case 1, 2 : SetPiastra(1)
                                    Select Case Posi
                                        Case 1 : If pt_Config.Flangiata(1 - 1) = -1 Or pt_Config.Flangiata(1 - 1) = 2 Then Nome = FlChanNome
                                        Case 2 : If pt_Config.Flangiata(1 - 1) = 1 Or pt_Config.Flangiata(1 - 1) = 2 Then Nome = FlShelNome
                                    End Select
                                Case 3, 4 : SetPiastra(2)
                                    Select Case Posi
                                        Case 3 : If pt_Config.Flangiata(2 - 1) = -1 Or pt_Config.Flangiata(2 - 1) = 2 Then Nome = FlChanNome
                                        Case 4 : If pt_Config.Flangiata(2 - 1) = 1 Or pt_Config.Flangiata(2 - 1) = 2 Then Nome = FlShelNome
                                    End Select
                            End Select
                            If Len(Nome) > 0 Then Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(T3, Trim(Nome)))
                        Case "$"
                            Select Case Posi
                                Case 1
                                    SetPiastra(1) : B1 = BoltCiD(1) ' da vedere il caso di piastra biflangiata con due file
                                    SetPiastra(2) : B2 = BoltCiD(1)
                                    SetPiastra(1)
                                Case 2
                                    B1 = Braccio(1) ' * inc
                                    If pt_Config.Differing = 1 Then
                                        B2 = B1
                                    Else
                                        B2 = Braccio(2) '* inc
                                        SetPiastra(1)
                                    End If
                            End Select
                            Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(T3, B1, B2))
                        Case "M"
                            Nome = ""
                            Nome1 = ""
                            Select Case Posi
                                Case 1 : Nome = Problem(IndProbl).TipPias(1) : Posin = 1
                                Case 5 : Nome = Problem(IndProbl).TipPias(2) : Posin = 3
                                    If pt_Config.Differing < 2 Then Posin = -1
                                Case 2
                                    If IndiceShell > 0 Then
                                        Nome = Involucr(1, IndiceShell).Mark.Trim
                                        Nome1 = Matdim(Involucr(1, IndiceShell).indice(0)).MatStr
                                    Else
                                        Nome = FlShel(Indprobl1).Identif
                                        Posin = 4 'Shell
                                    End If
                                Case 3 : Posin = 0 'Tubi
                                    For i = 1 To Config(3).Ninvolucri
                                        If Involucr(3, i).Tipo = 7 Then
                                            Nome = Involucr(3, i).Mark
                                            Nome1 = Matdim(Involucr(3, i).indice(1 - 1)).MatStr
                                            Exit For
                                        End If
                                    Next
                                Case 4 'Channel A, flangiatura
                                    Nome = FlChan(Indprobl1).Identif
                                Case 5 'Channel B
                                    Nome = FlChan(IndProbl2).Identif
                                Case 6 'integral channel
                                    Nome = FlChan(Indprobl1).Identif
                                    Recup()
                                    If Matdim(indice) Is Nothing Then
                                        Nome1 = "NOT DEFINED"
                                    Else
                                        Nome1 = Matdim(indice).MatStr
                                    End If
                                Case 7 ' Shell adj.
                                    Nome = FlShel(Indprobl1).Identif
                                    Posin = 4
                            End Select
                            If Len(Trim(Nome)) = 0 Then
                                Nome = "NOT DEFINED"
                            ElseIf Asc(Nome) < 32 Then
                                Nome = "NOT DEFINED"
                            End If
                            If Posin >= 0 Then
                                If Posin > 0 Then
                                    If Involucr(kLato, jInvolucr).indice(Posin - 1) > 0 Then
                                        Nome1 = Matdim(Involucr(kLato, jInvolucr).indice(Posin - 1)).MatStr
                                    End If
                                End If
                                If Len(RTrim(Nome1)) = 0 Then
                                    Nome1 = "NOT DEFINED"
                                ElseIf Asc(Nome1) < 32 Then
                                    Nome1 = "NOT DEFINED"
                                End If
                                Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(T3, Nome, Nome1))
                            End If
                        Case "m"
                            Recup()
                            Classe = ""
                            If Not Matdim(indice) Is Nothing Then Classe = Matdim(indice).EmodAltNome
                            If Trim(Classe) = "" Then
                                Classe = "not defined (manual entry)"
                            End If
                            Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(T3, Classe))
                        Case "n"
                            Recup()
                            Classe = ""
                            If Not Matdim(indice) Is Nothing Then Classe = Matdim(indice).EmodAltNome
                            If Trim(Classe) = "" Then
                                Classe = "not defined (manual entry)"
                            End If
                            Class1 = ""
                            If Not Matdim(indice) Is Nothing Then Class1 = Matdim(indice).AlfaTerNome
                            If Trim(Class1) = "" Then
                                Class1 = "not defined (manual entry)"
                            End If
                            Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(T3, Classe, Class1))
                        Case "N"
                            ii = pt_Config.Flangiata(1 - 1) : If pt_Config.Gasketed(1 - 1) Then ii = 2
                            Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(T3, Stringa5(pt_Config.Rear), Stringa4(ii + 1)))
                        Case "l"
                            Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(T3, Stringa9(pt_Config.Flottante)))
                        Case "o"
                            Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(T3, Stringa5(pt_Config.Rear)))
                        Case "O"
                            If pt_Config.Rear = 1 And pt_Config.TipoGiunto > 0 Then
                                Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(T3, Stringa6(pt_Config.TipoGiunto)))
                                Par = "\par "
                                If pt_Config.SaldMand > 0 Then Monitor.Motore.Problem.Printa(New String(CChar(" "), 38) & Stringa7(pt_Config.SaldMand) & Par) Else Contarig = Contarig - 1
                            Else
                                Contarig = Contarig - 2
                            End If
                        Case "P"
                            Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(T3, MAWP(Posi, Posi2), Stringa6(FattMax(Posi, Posi2)), iCondMax(Posi, Posi2)))
                        Case "p"
                            ii = pt_Config.Flangiata(1 - 1) : jj = pt_Config.Flangiata(2 - 1)
                            Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(T3, Stringa4(ii + 1), Stringa4(jj + 1)))
                        Case "Q"
                            If Config(0).CalcMAWP Then
                                Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(T3, MAWP(Posi, Posi2) * psi, MAWP(Posi, Posi2), MAWP(Posi3, Posi4) * psi, MAWP(Posi3, Posi4)))
                            End If
                        Case "R" : If pt_Config.fe = 10 Then fe = "N.A." : strfy = "N.A." Else fe = GlobalRoutines.myStr(pt_Config.fe, 1, 2, False) : strfy = GlobalRoutines.myStr(pt_Config.fy, 1, 2, False)
                            If pt_Config.TipoGiunto < 9 Then Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(T3, pt_Config.fr, strfy, fe))
                        Case "r"
                            Select Case CalcoloInCorso
                                Case 0 : Rig1 = "TEMA + ASME VIII div.1"
                                Case 1
                                    Select Case UltimoAggiornamento
                                        Case 2 : Rig1 = "ASME VIII div.1, App. AA"
                                        Case Else : Rig1 = "ASME VIII div.1, Part UHX"
                                    End Select
                            End Select
                            Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(T3, Rig1))
                        Case "S" : If pt_Config.Calc7133 Then Monitor.Motore.Problem.Printa(T3) Else Contarig = Contarig - 1
                        Case "s" : If .Z(1, 307) > .Z(1, 21) Then Monitor.Motore.Problem.Printa(T3) Else Contarig = Contarig - 1
                        Case "t" : R1 = "NO" : R2 = "NO"
                            Select Case Problem(IndProbl).Vacuum
                                Case 1 : R1 = "YES" : R2 = "NO"
                                Case 2 : R1 = "NO" : R2 = "YES"
                                Case 3 : R1 = "YES" : R2 = "YES"
                            End Select
                            Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(T3, R1, R2))
                        Case "U"
                            If pt_Config.Flangiata(1 - 1) <> 0 And pt_Config.Differing < 3 Then
                                Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(T3, .Z(iCond, Posi), .Z(iCond, Posi2)))
                            ElseIf pt_Config.Differing = 3 Then
                                If Posi > 0 And Posi2 > 0 Then
                                    Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(T3, .Z(iCond, Posi), .Z(iCond, Posi2)))
                                ElseIf Posi > 0 Then
                                    Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(T3, .Z(iCond, Posi)))
                                Else
                                    Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(T3, .Z(iCond, Posi2)))
                                End If
                            Else
                                Contarig = Contarig - 1
                            End If
                        Case "x"
                            If Problem(IndProbl).PDIFF = 0 Then R1 = "YES" Else R1 = "NO"
                            Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(T3, R1))
                        Case "v"
                            If RadialExp Then a = "YES" Else a = "NO"
                            Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(T3, a))
                        Case "V"
                            If SlShelDati(2) > 0 And SlShelDati(3) > 0 Then
                                Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(T3, SlShelDati(2), SlShelDati(3)))
                            End If
                        Case "W"
                            Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(T3, .Z(iCond, Posi), .Z(iCond, Posi2)))
                    End Select
                Loop
            End With
        Catch e As Exception
            MessageBox.Show(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Private Sub Recup()
        Dim i As Integer
        Select Case Posi
            Case 1 : Posin = 1
                indice = Involucr(kLato, jInvolucr).indice(Posin - 1)
            Case 5 : Posin = 3
                indice = Involucr(kLato, jInvolucr).indice(Posin - 1)
            Case 2 : Posin = 4 'Shell
                indice = Involucr(kLato, jInvolucr).indice(Posin - 1)
            Case 3 : Posin = 0 'Tubi
                For i = 1 To Config(3).Ninvolucri
                    If Involucr(3, i).Tipo = 7 Then
                        indice = Involucr(3, i).indice(1 - 1)
                        Exit For
                    End If
                Next
            Case 4 'Channel A
            Case 5 'Channel B
            Case 6 'integral channel
                indice = Involucr(kLato, jInvolucr).IndAccopp(3)
                indice = Involucr(2, indice).indice(1 - 1)
        End Select
        If indice < 0 Then indice = 0
    End Sub
    Private Sub Decode()
        With Mem
            Select Case Posi
                Case 900 To 942 : objDilat.Decodif(Posi, Decoded, Decode1, Decode2, Decode3)
                Case 943 To 965 : objDilat.Decodif(Posi, Decoded, Decode1, Decode2, Decode3)
                Case 966 To 972
                    kkk = Posi - 965 : ii = Posi2
                    Select Case kkk
                        Case 1 : i1 = 0 : i2 = 0 : i3 = 1
                        Case 2 : i1 = 0 : i2 = 1 : i3 = 0
                        Case 3 : i1 = 1 : i2 = 0 : i3 = 0
                        Case 4 : i1 = 1 : i2 = 1 : i3 = 0
                        Case 5 : i1 = 0 : i2 = 1 : i3 = 1
                        Case 6 : i1 = 1 : i2 = 0 : i3 = 1
                        Case 7 : i1 = 1 : i2 = 1 : i3 = 1
                    End Select 'a
                    Ps = .Z(iCond, 1) * i2
                    PSP = .Z(iCond, 67 + ii - 1) * i2
                    PT = .Z(iCond, 2) * i1
                    Ptp = .Z(iCond, 97 + ii - 1) * i1
                    Pd = .Z(iCond, 59 + ii - 1) * i3
                    Psstar = PT - Ptp + PSP - Pd
                    Decoded = Psstar : Decode1 = Ps
                    Decode4 = ii
                    objDilat.Decodif(Posi, Decoded, Decode1, Decode2, Decode3, iCond, Decode4)
                Case 973 To 998 : objDilat.Decodif(Posi, Decoded, Decode1, Decode2, Decode3, iCond)
                Case 800 To 831 : objDilat.Decodif(Posi, Decoded, Decode1, Decode2, Decode3, iCond, Decode4, Decode5)
                Case 832 To 852 : objDilat.Decodif(Posi, Decoded, Decode1, Decode2, Decode3, iCond)
                Case 853 : Decode5 = .Z(iCond, 284)
                    objDilat.Decodif(Posi, Decoded, Decode1, Decode2, Decode3, iCond, Decode4, Decode5)
                Case 854 : objDilat.Decodif(Posi, Decoded, Decode1, Decode2, Decode3)
                Case 855 : If Problem(IndProbl).mart = 1 Then Decoded = 1.5 Else Decoded = 3.0!
                Case 856 To 870 : objDilat.Decodif(Posi, Decoded, Decode1, Decode2, Decode3, iCond)
                Case 871 : objDilat.Decodif(Posi, Decoded, Decode1, Decode2, Decode3, iCond)
                    If Problem(IndProbl).mart = 1 Then Decode2 = 1.5 Else Decode2 = 3.0!
                    Decode2 = Decode2 * .Z(iCond, 274)
                Case 872 To 878 : objDilat.Decodif(Posi, Decoded, Decode1, Decode2, Decode3, iCond)
                Case 880 To 893 : objDilat.Decodif(Posi, Decoded, Decode1, Decode2, Decode3)
            End Select
        End With
    End Sub
    Function Calcoli() As Short
        Static Fi, FIC As Single
        Dim Global1 As Boolean
        Dim iSide, IndThk As Short
        Dim Z310, Z45, Z46, Z311 As Single
        Dim THK1A, THK0A, THK0B, THK1B As Single
        Dim CA1, FQB, FQCB, CA2 As Single
        Dim Ottimo, Preced As Boolean
        Dim i As Short
        Dim segnoC, segno, ii As Short
        Dim passo, passoC As Single
        Dim iX, iy As Short
        Dim jB, ja, JCA, JCB As Single
        Dim IndExt As Short
        Dim ac As Short
        Dim kThk As String = ""
        Dim kEst As String = ""
        Dim THK1, THK0, LTC As Single
        Dim FQA, LTfq, LTCfq, FQCA As Single
        Dim LTAC, LTA, LTB, LTBC As Single
        Dim PBT, PBTC As Single
        Dim pbs, PBSC As Single
        Dim P5S, P3S, P1S, P2S, P4S, P6S As Single
        Dim PSSEFF, PSEFF, x, PSEFFC, PSSEFFC As Single
        Dim P5SC, P3SC, P1SC, P2SC, P4SC, P6SC As Single
        Dim P5SS, P3SS, P1SS, P2SS, P4SS, P6SS As Single
        Dim P5SSC, P3SSC, P1SSC, P2SSC, P4SSC, P6SSC As Single
        Dim PTSEFF, PTEFF, PTEFFC, PTSEFFC As Single
        Dim P3T, P1T, P2T, P4T As Single ', P5S As Single, P6S As Single
        Dim P3TC, P1TC, P2TC, P4TC As Single ', P5S As Single, P6S As Single
        Dim P3TS, P1TS, P2TS, P4TS As Single ', P5S As Single, P6S As Single
        Dim P3TSC, P1TSC, P2TSC, P4TSC As Single ', P5S As Single, P6S As Single
        Dim PDEFF, PDEFFC As Single
        Dim P6D, P4D, P2D, P1D, P3D, P5D, P7D As Single
        Dim P6DC, P4DC, P2DC, P1DC, P3DC, P5DC, P7DC As Single
        Dim P6DS, P4DS, P2DS, P1DS, P3DS, P5DS, P7DS As Single
        Dim PDSEFF, PDSEFFC As Single
        Dim P6DSC, P4DSC, P2DSC, P1DSC, P3DSC, P5DSC, P7DSC As Single
        Dim eta, y As Single
        Dim THKMIN2, THKMIN3 As Single
        Dim THK2BC, THK3B, THK2B, THK1BC, THK3BC As Single
        Dim THK2SC, THK3S, THK1S, THK2S, THK1SC, THK3SC As Single
        Dim aFQB, aFQA, aFQCA, aFQCB As Single
        Dim Dvec, DvecC As Single
        Dim giro As Short
        Dim Res As Boolean
        Dim ktTc, ktLc, ktTp As Single
        Dim ktDp, ktLp, ktLk As Single
        Dim ktDk, Gcorretto As Single
        'Teste fisse -----------------------------------------------
        ktkf = 1 : ktkfC = 1
        If Fi < 0 Then Fi = 0
        Calcoli = False
        GlobalRoutines.FormatS("non|")
        If pt_Config.SoloDilat Then
            Calcoli = True
            Exit Function
        End If
        Try
4829:       Global1 = Globale Or Itera
            iSide = pt_Config.Side
            If iSide = 2 Then
                IndThk = 262 : IndExt = 289
            Else
                IndThk = 34 : IndExt = 288
            End If
            'trasformazione misure da [mm] a [in]
            'DL = DL / inc : PA = PA / inc : cs = cs / inc : CT = CT / inc : CJ = CJ / inc
            'Cptf = Cptf / inc : Ds = Ds / inc : DC = DC / inc : ts = ts / inc : tc = tc / inc
            'DJ = DJ / inc : DOO = DOO / inc : tt = tt / inc
            'LT = LT / inc : thk = thk / inc
            'KL = KL / inc
            With Mem
                If CalcoloInCorso = 1 Then
                    Padre = objMemb(Involucr(kLato, jInvolucr).IndObject)
                    'Padre.RulesAA.InizPlas = False
                    Res = Padre.RulesAA.AA24(iCond, Offset, icMAWP = 0 And VERIFICA = 0)
                    If Not Res Then Calcoli = False : Exit Function
                    If icMAWP = 0 Then
                        THKMIN0 = .Z(iCond + Offset, 161)
                        THKMIN1 = .Z(iCond + Offset, 162)
                        If THKMIN0 > THKMIN1 Then THKMIN = THKMIN0 Else THKMIN = THKMIN1
                    End If
                    GoTo 7241
                End If
                'calcolo diametro,spessore fasciame,corrosione da inserire nel calcolo
4830:           'calcolo fattore F  (RCB-7.132)
                g = Ds
                If pt_Config.Differing < 3 Then
                    If pt_Config.Gasketed(pt_Config.Side - 1) <> 0 Then
                        f = 1 : fc = 1
                    Else
                        If pt_Config.Flangiata(pt_Config.Side - 1) = -1 Then 'flangiata lato cassa
                            GG = Ds : t = ts : COR = cscod(pt_Config.Side)
                        ElseIf pt_Config.Flangiata(pt_Config.Side - 1) = 1 Then
                            GG = DC : t = tc : COR = ctcod(pt_Config.Side)
                        Else
                            If ts / Ds > tc / DC Then
                                GG = Ds : t = ts : COR = cscod(pt_Config.Side)
                            Else
                                GG = DC : t = tc : COR = ctcod(pt_Config.Side)
                            End If
                        End If
                        kkC()
                    End If
                Else
                    ac = pt_Config.Flangiata(pt_Config.Side - 1) ' \ 10 - 2
                    If ac = 2 Then
                        f = 1 : fc = 1
                    Else
                        If ac = -1 Then
                            GG = Ds : t = ts : COR = cscod(pt_Config.Side)
                        ElseIf ac = 1 Then
                            GG = DC : t = tc : COR = ctcod(pt_Config.Side)
                        Else
                            If ts / Ds > tc / DC Then
                                GG = Ds : t = ts : COR = cscod(pt_Config.Side)
                            Else
                                GG = DC : t = tc : COR = ctcod(pt_Config.Side)
                            End If
                        End If
                        kkC()
                    End If
                End If
                'calcolo fattore K   (RCB-7.161)
                ' If pt_Config.CalcFBM Then
                '    DS1 = Ds * .Z(1, 307) / .Z(1, 21)
                ' Else
                DS1 = Ds
                If .Z(1, 307) > .Z(1, 21) Then
                    ktLc = .Z(1, 584) '/ inc
                    ktTc = .Z(1, 585) '/ inc
                    ktTp = .Z(1, 586) '/ inc
                    ktLp = .Z(1, 587) '/ inc
                    ktDp = .Z(1, 588) + ktTp
                    ktLk = .Z(1, 583) '/ inc
                    ktDk = .Z(1, 307) + ts
                    ktkf = LT / (2 * ktLp + 4 * ktLc * ktTp * ktDp / (ktDp + ktDk) / ktTc + ktLk * ktTp * ktDp / ktDk / ts)
                    ktkfC = (LT + 2 * cs) / (2 * ktLp + 4 * ktLc * (ktTp - cs) * ktDp / (ktDp + ktDk) / (ktTc - cs) + ktLk * (ktTp - cs) * ktDp / ktDk / (ts - cs))
                End If
                ' End If
                .Z(1, 589) = ktkf : .Z(1, 590) = ktkfC
                For i = 589 To 590
                    For j = 2 To .Z(1, 261)
                        .Z(j, i) = .Z(1, i)
                    Next
                Next
                k = (ktkf * ES * ts * (DS1 + ts)) / (Et * tt * Nptf * (DOO - tt)) : .Z(iCond, 47) = k
                KC = (ktkfC * ES * (ts - cs) * ((DS1 + 2 * cs) + (ts - cs))) / (Et * tt * Nptf * (DOO - tt)) : .Z(iCond, 48) = KC
                'calcolo spessore minimo piastra
                THKminim = SpessMin()
                If thk < THKminim Then thk = THKminim : VERIFICA = 0
                If thk = 0 Then thk = 1 : VERIFICA = 0
                THK0 = thk - Cptf : .Z(iCond, 49) = THK0
                THK1 = thk - (cs + CT * -CShort(CT > Cptf) + Cptf * -CShort(CT <= Cptf)) : .Z(iCond, 50) = THK1
                'calcolo lunghezza interna tubi scambiatori
4850:           LT = .Z(iCond, 30) - 2 * thk : .Z(iCond, 51) = LT
                LTC = LT + 2 * cs : .Z(iCond, 52) = LTC
                LTfq = LT : LTCfq = LTC
                If pt_Config.nCicli = 0 Then LTA = LT : LTB = LT : LTAC = LTC : LTBC = LTC
                '     IF pt_Config.Differing = 3 AND pt_Config.Ncicli ???> 0 THEN
                If pt_Config.Differing > 1 And pt_Config.nCicli > 0 Then
                    'Special:
                    CA1 = .Z(1, 20) : CA2 = .Z(1, 263)
                    If .Z(1, 17) > CA1 Then CA1 = .Z(1, 17)
                    If .Z(1, 264) > CA2 Then CA2 = .Z(1, 264)
                    CA1 = CA1 + .Z(1, 18) : CA2 = CA2 + .Z(1, 265)
                    THK0A = (.Z(1, 34) - .Z(1, 20)) ' / inc
                    THK1A = (.Z(1, 34) - CA1) ' / inc
                    THK0B = (.Z(1, 262) - .Z(1, 263)) '/ inc
                    THK1B = (.Z(1, 262) - CA2) '/ inc
                    LT = (.Z(iCond, 30) - .Z(iCond, 34) - .Z(iCond, 262)) ' / inc
                    LTC = LT + 2 * (.Z(iCond, 17) + .Z(iCond, 264)) ' / inc
                    If Fi = 0 Then
                        'Fi = 0.1: FIC = 0.1
                        Fi = 1 / (1 + (THK1B / THK1A) ^ 3)
                        FIC = Fi
                    Else
                        Fi = 1 / Fi : FIC = 1 / FIC
                    End If
                    i = 0 : segno = 1 : segnoC = 1 : passo = 0.05 : passoC = 0.05
                    Z45 = .Z(iCond, 45) : Z46 = .Z(iCond, 46)
                    Z310 = .Z(iCond, 310) : Z311 = .Z(iCond, 311)
                    If Z310 = 0 Then Z310 = 1 : Z311 = 1
                    Eptf = .Z(iCond, 7) : Eptf2 = .Z(iCond, 267)
                    If pt_Config.Side = 2 Then
                        GlobalRoutines.SWAP(Z45, Z310) : GlobalRoutines.SWAP(Z46, Z311) : GlobalRoutines.SWAP(THK0A, THK0B) : GlobalRoutines.SWAP(THK1A, THK1B)
                        GlobalRoutines.SWAP(Eptf, Eptf2)
                    End If
                    Do
                        i = i + 1
                        LTB = 2 * LT / (1 + Fi)
                        LTA = 2 * LT - LTB
                        LTBC = 2 * LTC / (1 + FIC)
                        LTAC = 2 * LTC - LTBC
                        'CalcFq3:
                        FQA = 0.25 + (Z45 - 0.6) * (((300 * ts * ktkf * ES) * DS1 / Ds / (k * LTA * Eptf)) * (g / THK0A) ^ 3) ^ 0.25
                        FQCA = 0.25 + (Z46 - 0.6) * (((300 * (ts - cs) * ktkfC * ES) * DS1 / Ds / (KC * LTAC * Eptf)) * ((g + 2 * COR) / THK1A) ^ 3) ^ 0.25
                        If FQA < 1 Then FQA = 1
                        If FQCA < 1 Then FQCA = 1
                        FQB = 0.25 + (Z310 - 0.6) * (((300 * ts * ktkf * ES) * DS1 / Ds / (k * LTB * Eptf2)) * (g / THK0B) ^ 3) ^ 0.25
                        FQCB = 0.25 + (Z311 - 0.6) * (((300 * (ts - cs) * ktkfC * ES) * DS1 / Ds / (KC * LTBC * Eptf2)) * ((g + 2 * COR) / THK1B) ^ 3) ^ 0.25
                        If FQB < 1 Then FQB = 1
                        If FQCB < 1 Then FQCB = 1
                        LTfq1 = LTA : LTCfq1 = LTAC
                        Calcj()
                        ja = j : JCA = JC
                        LTfq1 = LTB : LTCfq1 = LTBC
                        Calcj()
                        jB = j : JCB = JC
                        '          aFQA = JA * FQA: aFQB = JB * FQB: aFQCA = JCA * FQCA: aFQCB = JCB * FQCB
                        aFQA = FQA : aFQB = FQB : aFQCA = FQCA : aFQCB = FQCB
                        If System.Math.Abs(aFQA - aFQB) / aFQA < 0.00001 And System.Math.Abs(aFQCA - aFQCB) / aFQCA < 0.00001 Then Exit Do
                        If (System.Math.Abs(aFQA - aFQB) > System.Math.Abs(Dvec) Or (aFQA - aFQB) * Dvec < 0) And i > 1 Then segno = -segno : passo = passo * 0.5
                        If (System.Math.Abs(aFQCA - aFQCB) > System.Math.Abs(DvecC) Or (aFQCA - aFQCB) * DvecC < 0) And i > 1 Then segnoC = -segnoC : passoC = passoC * 0.5
                        Dvec = aFQA - aFQB
                        DvecC = aFQCA - aFQCB
                        If System.Math.Abs(aFQA - aFQB) / aFQA > 0.00001 Then
                            Fi = Fi + passo * segno
                            If Fi < 0 Then Fi = -Fi / 2
                        End If
                        If System.Math.Abs(aFQCA - aFQCB) / aFQCA > 0.00001 Then
                            FIC = FIC + passoC * segnoC
                            If FIC < 0 Then FIC = -FIC / 2
                        End If
                        If i > 10000 Then
                            MessageBox.Show("Convergenza non raggiunta in Calcoli")
                            Exit Do
                        End If
                        '          IF i% > 1000 THEN END'EXIT DO
                    Loop
                    LTfq = LTA : .Z(iCond, 51) = LTfq
                    LTCfq = LTAC : .Z(iCond, 52) = LTCfq
                    Fq = FQA
                    FQC = FQCA
                Else
                    'CalcFq:
                    Fq = 0.25 + (f - 0.6) * (((300 * ts * ktkf * ES) * DS1 / Ds / (k * LTfq * Eptf)) * (g / THK0) ^ 3) ^ 0.25
                    FQC = 0.25 + (fc - 0.6) * (((300 * (ts - cs) * ktkfC * ES) * DS1 / Ds / (KC * LTCfq * Eptf)) * ((g + 2 * COR) / THK1) ^ 3) ^ 0.25
                    If Fq < 1 Then Fq = 1
                    If FQC < 1 Then FQC = 1
                End If
                '   PRINT #22, LTA; LTB; "LTA,LTB"
                'calcolo fattore Fq  (RCB-7.161)
                .Z(iCond, 53) = Fq : .Z(iCond, 54) = FQC
                'calcolo Sj massimo per avere J=0
4880:           SJM = (DS1 + ts) * ts * ktkf * ES / (10 * LT) : .Z(iCond, 55) = SJM
                SJMC = (DS1 + 2 * cs + ts - cs) * (ts - cs) * ktkfC * ES / (10 * LTC) : .Z(iCond, 56) = SJMC
                'calcolo fattore J   (R-7.191)
                LTfq1 = LT : LTCfq1 = LTC
                Calcj()
5170:           .Z(iCond, 57) = j : .Z(iCond, 58) = JC
                'calcolo pressione differenziale Pd  (R-7.193)
                Pd = (4 * j * ktkf * ES * ts * (ASS * (xs - 70) - AT * (xt - 70))) / (((Ds + 2 * ts) - 3 * ts) * (1 + j * k * Fq))
                .Z(iCond, 59) = Pd
                PDC = (4 * JC * ktkfC * ES * (ts - cs) * (ASS * (xs - 70) - AT * (xt - 70))) / (((Ds + 2 * ts) - 3 * (ts - cs)) * (1 + JC * KC * FQC))
                .Z(iCond, 60) = PDC
                Pd = Pd * DS1 / Ds ' .Z(1, 307) / .Z(1, 21)
                PDC = PDC * DS1 / Ds ' .Z(1, 307) / .Z(1, 21)
                'calcolo pressione equivalente dei bulloni   (R-7.192)
                PBT = (6.2 / f ^ 2) * (M1ptf / g ^ 3) : .Z(iCond, 61) = PBT
                PBTC = (6.2 / fc ^ 2) * (M1ptf / (g + 2 * COR) ^ 3) : .Z(iCond, 62) = PBTC
                pbs = (6.2 / f ^ 2) * (M2ptf / g ^ 3) : .Z(iCond, 63) = pbs
                PBSC = (6.2 / fc ^ 2) * (M2ptf / (g + 2 * COR) ^ 3) : .Z(iCond, 64) = PBSC
                'pressione effettiva lato shell
                FS = 1 - Nptf * (DOO / g) ^ 2 : .Z(iCond, 65) = FS
                FSC = 1 - Nptf * (DOO / (g + 2 * COR)) ^ 2 : .Z(iCond, 66) = FSC
                Gcorretto = g
                If .Z(1, 307) > .Z(1, 21) And DJ > .Z(1, 307) Then Gcorretto = .Z(1, 307) ' / inc
                PS1 = Ps * ((0.4 * j * (1.5 + k * (1.5 + FS)) - (((1 - j) / 2) * ((DJ ^ 2 / Gcorretto ^ 2) - 1))) / (1 + j * k * Fq))
                .Z(iCond, 67) = PS1
                PS1C = Ps * ((0.4 * JC * (1.5 + KC * (1.5 + FSC)) - (((1 - JC) / 2) * (((DJ + 2 * CJ) ^ 2 / (Gcorretto + 2 * COR) ^ 2) - 1))) / (1 + JC * KC * FQC))
                .Z(iCond, 68) = PS1C
                P1S = (PS1 - Pd) / 2 : .Z(iCond, 69) = P1S
                P2S = PS1 : .Z(iCond, 71) = P2S
                P3S = pbs : .Z(iCond, 73) = P3S
                P4S = (PS1 - Pd - pbs) / 2 : .Z(iCond, 75) = P4S
                P5S = (pbs + Pd) / 2 : .Z(iCond, 77) = P5S
                P6S = (PS1 - pbs) : .Z(iCond, 79) = P6S
                If System.Math.Abs(P1S) > System.Math.Abs(P2S) Then x = P1S Else x = P2S
                If System.Math.Abs(x) > System.Math.Abs(P3S) Then x = x Else x = P3S
                If System.Math.Abs(x) > System.Math.Abs(P4S) Then x = x Else x = P4S
                If System.Math.Abs(x) > System.Math.Abs(P5S) Then x = x Else x = P5S
                If System.Math.Abs(x) > System.Math.Abs(P6S) Then x = x Else x = P6S
                'If .Z(iCond, 3) <> 0 Then x = 0
                If Problem(IndProbl).PDIFF = 0 Then x = 0
                PSEFF = System.Math.Abs(x) : .Z(iCond, 81) = PSEFF
                P1SC = (PS1C - PDC) / 2 : .Z(iCond, 70) = P1SC
                P2SC = PS1C : .Z(iCond, 72) = P2SC
                P3SC = PBSC : .Z(iCond, 74) = P3SC
                P4SC = (PS1C - PDC - PBSC) / 2 : .Z(iCond, 76) = P4SC
                P5SC = (PBSC + PDC) / 2 : .Z(iCond, 78) = P5SC
                P6SC = (PS1C - PBSC) : .Z(iCond, 80) = P6SC
                If System.Math.Abs(P1SC) > System.Math.Abs(P2SC) Then x = P1SC Else x = P2SC
                If System.Math.Abs(x) > System.Math.Abs(P3SC) Then x = x Else x = P3SC
                If System.Math.Abs(x) > System.Math.Abs(P4SC) Then x = x Else x = P4SC
                If System.Math.Abs(x) > System.Math.Abs(P5SC) Then x = x Else x = P5SC
                If System.Math.Abs(x) > System.Math.Abs(P6SC) Then x = x Else x = P6SC
                'If .Z(iCond, 3) <> 0 Then x = 0
                If Problem(IndProbl).PDIFF = 0 Then x = 0
                PSEFFC = System.Math.Abs(x) : .Z(iCond, 82) = PSEFFC
                P1SS = (PS1 - Pd) / 2 : .Z(iCond, 83) = P1SS
                P2SS = PS1 : .Z(iCond, 85) = P2SS
                P3SS = 0
                P4SS = (PS1 - Pd) / 2 : .Z(iCond, 87) = P4SS
                P5SS = (Pd) / 2 : .Z(iCond, 89) = P5SS
                P6SS = (PS1) : .Z(iCond, 91) = P6SS
                If System.Math.Abs(P1SS) > System.Math.Abs(P2SS) Then x = P1SS Else x = P2SS
                If System.Math.Abs(x) > System.Math.Abs(P3SS) Then x = x Else x = P3SS
                If System.Math.Abs(x) > System.Math.Abs(P4SS) Then x = x Else x = P4SS
                If System.Math.Abs(x) > System.Math.Abs(P5SS) Then x = x Else x = P5SS
                If System.Math.Abs(x) > System.Math.Abs(P6SS) Then x = x Else x = P6SS
                'If .Z(iCond, 3) <> 0 Then x = 0
                If Problem(IndProbl).PDIFF = 0 Then x = 0
                PSSEFF = System.Math.Abs(x) : .Z(iCond, 93) = PSSEFF
                P1SSC = (PS1C - PDC) / 2 : .Z(iCond, 84) = P1SSC
                P2SSC = PS1C : .Z(iCond, 86) = P2SSC
                P3SSC = 0
                P4SSC = (PS1C - PDC) / 2 : .Z(iCond, 88) = P4SSC
                P5SSC = (PDC) / 2 : .Z(iCond, 90) = P5SSC
                P6SSC = (PS1C) : .Z(iCond, 92) = P6SSC
                If System.Math.Abs(P1SSC) > System.Math.Abs(P2SSC) Then x = P1SSC Else x = P2SSC
                If System.Math.Abs(x) > System.Math.Abs(P3SSC) Then x = x Else x = P3SSC
                If System.Math.Abs(x) > System.Math.Abs(P4SSC) Then x = x Else x = P4SSC
                If System.Math.Abs(x) > System.Math.Abs(P5SSC) Then x = x Else x = P5SSC
                If System.Math.Abs(x) > System.Math.Abs(P6SSC) Then x = x Else x = P6SSC
                'If .Z(iCond, 3) <> 0 Then x = 0
                If Problem(IndProbl).PDIFF = 0 Then x = 0
                PSSEFFC = System.Math.Abs(x) : .Z(iCond, 94) = PSSEFFC
                'pressione effettiva lato tubi
                FT = 1 - Nptf * ((DOO - 2 * tt) / g) ^ 2 : .Z(iCond, 95) = FT
                FTC = 1 - Nptf * ((DOO - 2 * tt) / (g + 2 * COR)) ^ 2 : .Z(iCond, 96) = FTC
                PT1 = PT * ((1 + 0.4 * j * k * (1.5 + FT)) / (1 + j * k * Fq))
                .Z(iCond, 97) = PT1
                PT1C = PT * ((1 + 0.4 * JC * KC * (1.5 + FTC)) / (1 + JC * KC * FQC))
                .Z(iCond, 98) = PT1C
                P1T = (PT1 + PBT + Pd) / 2 : .Z(iCond, 99) = P1T
                P2T = PT1 + PBT : .Z(iCond, 101) = P2T
                P3T = (PT1 - PS1 + PBT + Pd) / 2 : .Z(iCond, 103) = P3T
                P4T = PT1 - PS1 + PBT : .Z(iCond, 105) = P4T
                If System.Math.Abs(P1T) > System.Math.Abs(P2T) Then x = P1T Else x = P2T
                If PS1 > 0 Then PTEFF = System.Math.Abs(x) : .Z(iCond, 107) = PTEFF : GoTo 5970
                If System.Math.Abs(P3T) > System.Math.Abs(P4T) Then x = P3T Else x = P4T
                If ProgDiffPr Then x = 0
                PTEFF = System.Math.Abs(x) : .Z(iCond, 107) = PTEFF
                'PTEFF = Abs(P1T)
                'If Abs(P2T) > PTEFF Then PTEFF = Abs(P2T)
                'If Abs(P3T) > PTEFF Then PTEFF = Abs(P3T)
                'If Abs(P4T) > PTEFF Then PTEFF = Abs(P4T)
                '.Z(iCond, 107) = PTEFF
5970:           P1TC = (PT1C + PBTC + PDC) / 2 : .Z(iCond, 100) = P1TC
                P2TC = PT1C + PBTC : .Z(iCond, 102) = P2TC
                P3TC = (PT1C - PS1C + PBTC + PDC) / 2 : .Z(iCond, 104) = P3TC
                P4TC = PT1C - PS1C + PBTC : .Z(iCond, 106) = P4TC
                If System.Math.Abs(P1TC) > System.Math.Abs(P2TC) Then x = P1TC Else x = P2TC
                If PS1C > 0 Then PTEFFC = System.Math.Abs(x) : .Z(iCond, 108) = PTEFFC : GoTo 6060
                If System.Math.Abs(P3TC) > System.Math.Abs(P4TC) Then x = P3TC Else x = P4TC
                If ProgDiffPr Then x = 0
                PTEFFC = System.Math.Abs(x) : .Z(iCond, 108) = PTEFFC
                '     PTEFFC = Abs(P1TC)
                '     If Abs(P2TC) > PTEFFC Then PTEFFC = Abs(P2TC)
                '     If Abs(P3TC) > PTEFFC Then PTEFFC = Abs(P3TC)
                '     If Abs(P4TC) > PTEFFC Then PTEFFC = Abs(P4TC)
                '     .Z(iCond, 108) = PTEFFC
6060:           P1TS = (PT1 + Pd) / 2 : .Z(iCond, 109) = P1TS
                P2TS = PT1 : .Z(iCond, 111) = P2TS
                P3TS = (PT1 - PS1 + Pd) / 2 : .Z(iCond, 113) = P3TS
                P4TS = PT1 - PS1 : .Z(iCond, 115) = P4TS
                If System.Math.Abs(P1TS) > System.Math.Abs(P2TS) Then x = P1TS Else x = P2TS
                If PS1 > 0 Then PTSEFF = System.Math.Abs(x) : .Z(iCond, 117) = PTSEFF : GoTo 6150
                If System.Math.Abs(P3TS) > System.Math.Abs(P4TS) Then x = P3TS Else x = P4TS
                'If .Z(iCond, 3) <> 0 Then x = 0
                If Problem(IndProbl).PDIFF = 0 Then x = 0
                PTSEFF = System.Math.Abs(x) : .Z(iCond, 117) = PTSEFF
6150:           P1TSC = (PT1C + PDC) / 2 : .Z(iCond, 110) = P1TSC
                P2TSC = PT1C : .Z(iCond, 112) = P2TSC
                P3TSC = (PT1C - PS1C + PDC) / 2 : .Z(iCond, 114) = P3TSC
                P4TSC = PT1C - PS1C : .Z(iCond, 116) = P4TSC
                If System.Math.Abs(P1TSC) > System.Math.Abs(P2TSC) Then x = P1TSC Else x = P2TSC
                If PS1C > 0 Then PTSEFFC = System.Math.Abs(x) : .Z(iCond, 118) = PTSEFFC : GoTo 6320
                If System.Math.Abs(P3TSC) > System.Math.Abs(P4TSC) Then x = P3TSC Else x = P4TSC
                'If .Z(iCond, 3) <> 0 Then x = 0
                If Problem(IndProbl).PDIFF = 0 Then x = 0
                PTSEFFC = System.Math.Abs(x) : .Z(iCond, 118) = PTSEFFC
                'controllo nota 2
                'If .Z(iCond, 3) <> 0 Then GoTo 6320
                If Problem(IndProbl).PDIFF = 0 Then GoTo 6320
                If j = 0 And Ps > 0 And PT > 0 Then GoTo 6270 Else GoTo 6290
6270:           PTEFF = PT + (Ps / 2) * ((DJ / g) ^ 2 - 1) + PBT : .Z(iCond, 107) = PTEFF
                PTSEFF = PT + (Ps / 2) * ((DJ / g) ^ 2 - 1) : .Z(iCond, 117) = PTSEFF
6290:           If JC = 0 And Ps > 0 And PT > 0 Then GoTo 6300 Else GoTo 6320
6300:           PTEFFC = PT + (Ps / 2) * (((DJ + 2 * CJ) / (g + 2 * COR)) ^ 2 - 1) + PBT : .Z(iCond, 108) = PTEFFC
                PTSEFFC = PT + (Ps / 2) * (((DJ + 2 * CJ) / (g + 2 * COR)) ^ 2 - 1) : .Z(iCond, 118) = PTSEFFC
6320:           'pressione differenziale effettiva
                'If .Z(iCond, 3) <> 0 Then
                If Problem(IndProbl).PDIFF = 0 Then
                    PTEFF = 0 : PTEFFC = 0 : PTSEFF = 0 : PTSEFFC = 0 : .Z(iCond, 107) = 0 : .Z(iCond, 108) = 0 : .Z(iCond, 117) = 0 : .Z(iCond, 118) = 0
                End If
                P1D = PT1 - PS1 + PBT : .Z(iCond, 119) = P1D
                P2D = (PT1 - PS1 + PBT + Pd) / 2 : .Z(iCond, 121) = P2D
                P3D = pbs : .Z(iCond, 123) = P3D
                P4D = (pbs + Pd) / 2 : .Z(iCond, 125) = P4D
                P5D = PT1 - PS1 : .Z(iCond, 127) = P5D
                P6D = (PT1 - PS1 + Pd) / 2 : .Z(iCond, 129) = P6D
                P7D = PBT : .Z(iCond, 131) = P7D
                If System.Math.Abs(P1D) > System.Math.Abs(P2D) Then x = P1D Else x = P2D
                If System.Math.Abs(x) > P3D Then x = x Else x = P3D
                If System.Math.Abs(x) > P4D Then x = x Else x = P4D
                If System.Math.Abs(x) > P5D Then x = x Else x = P5D
                If System.Math.Abs(x) > P6D Then x = x Else x = P6D
                If System.Math.Abs(x) > P7D Then x = x Else x = P7D
                PDEFF = System.Math.Abs(x) : .Z(iCond, 133) = PDEFF
                P1DC = PT1C - PS1C + PBTC : .Z(iCond, 120) = P1DC
                P2DC = (PT1C - PS1C + PBTC + PDC) / 2 : .Z(iCond, 122) = P2DC
                P3DC = PBSC : .Z(iCond, 124) = P3DC
                P4DC = (PBSC + PDC) / 2 : .Z(iCond, 126) = P4DC
                P5DC = PT1C - PS1C : .Z(iCond, 128) = P5DC
                P6DC = (PT1C - PS1C + PDC) / 2 : .Z(iCond, 130) = P6DC
                P7DC = PBTC : .Z(iCond, 132) = P7DC
                If System.Math.Abs(P1DC) > System.Math.Abs(P2DC) Then x = P1DC Else x = P2DC
                If System.Math.Abs(x) > P3DC Then x = x Else x = P3DC
                If System.Math.Abs(x) > P4DC Then x = x Else x = P4DC
                If System.Math.Abs(x) > P5DC Then x = x Else x = P5DC
                If System.Math.Abs(x) > P6DC Then x = x Else x = P6DC
                If System.Math.Abs(x) > P7DC Then x = x Else x = P7DC
                PDEFFC = System.Math.Abs(x) : .Z(iCond, 134) = PDEFFC
                'effective differential pressure for shear
                P1DS = PT1 - PS1 : .Z(iCond, 135) = P1DS
                P2DS = (PT1 - PS1 + Pd) / 2 : .Z(iCond, 137) = P2DS
                P3DS = 0
                P4DS = (Pd) / 2 : .Z(iCond, 139) = P4DS
                P5DS = PT1 - PS1 : .Z(iCond, 141) = P5DS
                P6DS = (PT1 - PS1 + Pd) / 2 : .Z(iCond, 143) = P6DS
                P7DS = 0
                If System.Math.Abs(P1DS) > System.Math.Abs(P2DS) Then x = P1DS Else x = P2DS
                If System.Math.Abs(x) > P3DS Then x = x Else x = P3DS
                If System.Math.Abs(x) > P4DS Then x = x Else x = P4DS
                If System.Math.Abs(x) > P5DS Then x = x Else x = P5DS
                If System.Math.Abs(x) > P6DS Then x = x Else x = P6DS
                If System.Math.Abs(x) > P7DS Then x = x Else x = P7DS
                PDSEFF = System.Math.Abs(x) : .Z(iCond, 145) = PDSEFF
                P1DSC = PT1C - PS1C : .Z(iCond, 136) = P1DSC
                P2DSC = (PT1C - PS1C + PDC) / 2 : .Z(iCond, 138) = P2DSC
                P3DSC = 0
                P4DSC = (PDC) / 2 : .Z(iCond, 140) = P4DSC
                P5DSC = PT1C - PS1C : .Z(iCond, 142) = P5DSC
                P6DSC = (PT1C - PS1C + PDC) / 2 : .Z(iCond, 144) = P6DSC
                P7DSC = 0
                If System.Math.Abs(P1DSC) > System.Math.Abs(P2DSC) Then x = P1DSC Else x = P2DSC
                If System.Math.Abs(x) > P3DSC Then x = x Else x = P3DSC
                If System.Math.Abs(x) > P4DSC Then x = x Else x = P4DSC
                If System.Math.Abs(x) > P5DSC Then x = x Else x = P5DSC
                If System.Math.Abs(x) > P6DSC Then x = x Else x = P6DSC
                If System.Math.Abs(x) > P7DSC Then x = x Else x = P7DSC
                PDSEFFC = System.Math.Abs(x) : .Z(iCond, 146) = PDSEFFC
                'calcolo efficienza di legamento
                eta = Ligament(PA, DOO)
                If eta = 0 Then Exit Function
                .Z(iCond, 271) = eta
                'calcolo spessore per bending  (R-7.132)
                THK1B = (f * g / 3) * System.Math.Sqrt(PSEFF / Sptf / eta)
                .Z(iCond + Offset, 147) = THK1B
                THK2B = (f * g / 3) * System.Math.Sqrt(PTEFF / Sptf / eta)
                .Z(iCond + Offset, 149) = THK2B
                THK3B = (f * g / 3) * System.Math.Sqrt(PDEFF / Sptf / eta)
                .Z(iCond + Offset, 151) = THK3B : .Z(iCond + Offset, 163) = .Z(iCond + Offset, 151)
                THK1BC = ((fc * (g + 2 * COR)) / 3) * System.Math.Sqrt(PSEFFC / Sptf / eta)
                .Z(iCond + Offset, 148) = THK1BC
                THK2BC = ((fc * (g + 2 * COR)) / 3) * System.Math.Sqrt(PTEFFC / Sptf / eta)
                .Z(iCond + Offset, 150) = THK2BC
                THK3BC = ((fc * (g + 2 * COR)) / 3) * System.Math.Sqrt(PDEFFC / Sptf / eta)
                .Z(iCond + Offset, 152) = THK3BC : .Z(iCond + Offset, 164) = .Z(iCond + Offset, 152)
                'calcolo spessore al taglio    (R-7.133)
                THK1S = ((0.31 * DL) / (1 - (DOO / PA))) * (PSSEFF / Sptf)
                .Z(iCond + Offset, 153) = THK1S
                THK2S = ((0.31 * DL) / (1 - (DOO / PA))) * (PTSEFF / Sptf)
                .Z(iCond + Offset, 155) = THK2S
                THK3S = ((0.31 * DL) / (1 - (DOO / PA))) * (PDSEFF / Sptf)
                .Z(iCond + Offset, 157) = THK3S : .Z(iCond + Offset, 165) = .Z(iCond + Offset, 157)
                THK1SC = ((0.31 * DL) / (1 - (DOO / PA))) * (PSSEFFC / Sptf)
                .Z(iCond + Offset, 154) = THK1SC
                THK2SC = ((0.31 * DL) / (1 - (DOO / PA))) * (PTSEFFC / Sptf)
                .Z(iCond + Offset, 156) = THK2SC
                THK3SC = ((0.31 * DL) / (1 - (DOO / PA))) * (PDSEFFC / Sptf)
                .Z(iCond + Offset, 158) = THK3SC : .Z(iCond + Offset, 166) = .Z(iCond + Offset, 158)
                'calcolo spessore massimo
                If THK1B > THK2B Then x = THK1B Else x = THK2B
                If x < THK3B Then x = THK3B
                .Z(iCond + Offset, 296) = x  'min.for bending
                If THK1S > THK2S Then y = THK1S Else y = THK2S
                If y < THK3S Then y = THK3S
                .Z(iCond + Offset, 298) = y  'min for shear
                THKMIN0 = x : If y > THKMIN0 Then THKMIN0 = y
                THKMIN0 = THKMIN0 + Cptf : x = 0
                .Z(iCond + Offset, 159) = THKMIN0
                .Z(iCond + Offset, 161) = THKMIN0  'minimo in condizioni nuove
                If THK1BC > THK2BC Then x = THK1BC Else x = THK2BC
                If x < THK3BC Then x = THK3BC
                .Z(iCond + Offset, 297) = x
                If THK1SC > THK2SC Then y = THK1SC Else y = THK2SC
                If y < THK3SC Then y = THK3SC
                .Z(iCond + Offset, 299) = y
                THKMIN1 = x : If y > THKMIN1 Then THKMIN1 = y
                THKMIN1 = THKMIN1 + cs + CT * -CShort(CT > Cptf) + Cptf * -CShort(CT <= Cptf)
                .Z(iCond + Offset, 160) = THKMIN1
                .Z(iCond + Offset, 162) = THKMIN1  'minimo in condizioni corrose
                If THKMIN0 > THKMIN1 Then THKMIN = THKMIN0 Else THKMIN = THKMIN1
                'If .Z(iCond, 3) <> 0 Then
                If Problem(IndProbl).PDIFF = 0 Then
                    'x = 0: GoTo 7190 Else GoTo 7240
                    If THK3B > THK3S Then x = THK3B Else x = THK3S
                    'solo per caso differenziale
                    THKMIN2 = x + Cptf : x = 0
                    .Z(iCond + Offset, 167) = THKMIN2 : .Z(iCond + Offset, 169) = THKMIN2
                    If THK3BC > THK3SC Then x = THK3BC Else x = THK3SC
                    THKMIN3 = x + cs + CT * -CShort(CT > Cptf) + Cptf * -CShort(CT <= Cptf)
                    .Z(iCond + Offset, 168) = THKMIN3 : .Z(iCond + Offset, 170) = THKMIN3
                    If THKMIN2 > THKMIN3 Then THKMIN = THKMIN2 Else THKMIN = THKMIN3
                    ' For i = 0 To 3
                    '     .Z(iCond + Offset, 159 + i) = .Z(iCond + Offset, 167 + i)
                    ' Next
                End If
                If pt_Config.Differing > 1 Then
                    MinOpt(iSide) = THKMIN
                End If
7240:           x = 0
                If giro = 1 Then giro = 0 : GoTo 7350
                'controllo spessore calcolato con quello imposto
                '?If .Z(1, IndThk) = 0 Then GoTo 7280 Else GoTo 7350
                If VERIFICA = 0 Then 'GoTo 7280 Else GoTo 7350
7280:               'IF THK=THKMIN THEN 7300
                    If thk < THKMIN * 0.985 Then thk = (THKMIN + thk) / 2 : GoTo 4830
7300:               If thk > THKMIN * 1.015 Then thk = (THKMIN + thk) / 2 : GoTo 4830
                    giro = 1 : thk = THKMIN : GoTo 4830
                End If
7350:           If pt_Config.Flangiata(pt_Config.Side - 1) <> 0 Then
7351:               Call Extension(Test)
7352:               .Z(iCond, IndExt + 2) = Test
                End If
7241:           If OptimDil Then Calcoli = True : Exit Function
            End With
            With mioRis
                ._Label1_0.Visible = False
                ._Text1_0.Visible = False
                ._Label1_1.Visible = False
                ._Text1_1.Visible = False
                If Not Global1 And icMAWP < 1 Then
                    Call RisPAGINA(1)
                    If CalcoloInCorso = 0 Then
                        iy = 9 : iX = 29
                        .Scrivi(GlobalRoutines.FormatS(FormInch, THK1B * kLength) & " " & UnitLength, iy, iX)
                        iy = 9 : iX = 58
                        .Scrivi(GlobalRoutines.FormatS(FormInch, THK1BC * kLength) & " " & UnitLength, iy, iX)
                        iy = 10 : iX = 29
                        .Scrivi(GlobalRoutines.FormatS(FormInch, THK2B * kLength) & " " & UnitLength, iy, iX)
                        iy = 10 : iX = 58
                        .Scrivi(GlobalRoutines.FormatS(FormInch, THK2BC * kLength) & " " & UnitLength, iy, iX)
                        iy = 11 : iX = 29
                        .Scrivi(GlobalRoutines.FormatS(FormInch, THK3B * kLength) & " " & UnitLength, iy, iX)
                        iy = 11 : iX = 58
                        .Scrivi(GlobalRoutines.FormatS(FormInch, THK3BC * kLength) & " " & UnitLength, iy, iX)
                        iy = 13 : iX = 29
                        .Scrivi(GlobalRoutines.FormatS(FormInch, THK1S * kLength) & " " & UnitLength, iy, iX)
                        iy = 13 : iX = 58
                        .Scrivi(GlobalRoutines.FormatS(FormInch, THK1SC * kLength) & " " & UnitLength, iy, iX)
                        iy = 14 : iX = 29
                        .Scrivi(GlobalRoutines.FormatS(FormInch, THK2S * kLength) & " " & UnitLength, iy, iX)
                        iy = 14 : iX = 58
                        .Scrivi(GlobalRoutines.FormatS(FormInch, THK2SC * kLength) & " " & UnitLength, iy, iX)
                    End If
                    If CalcoloInCorso = 0 Then
                        iy = 15 : iX = 29
                        .Scrivi(GlobalRoutines.FormatS(FormInch, THK3S * kLength) & " " & UnitLength, iy, iX)
                        iy = 15 : iX = 58
                        .Scrivi(GlobalRoutines.FormatS(FormInch, THK3SC * kLength) & " " & UnitLength, iy, iX)
                        iy = 17 : iX = 58
                        NonDet = False
                        If CalcoloInCorso = 1 Then
                            If Padre.TipoAA > 4 And Padre.RulesAA.hr = 0 Then NonDet = True
                        End If
                        If NonDet Then
                            .Scrivi("(N.D.)", iy, iX)
                        Else
                            .Scrivi(GlobalRoutines.FormatS(FormInch, THKMIN * kLength) & " " & UnitLength, iy, iX)
                        End If
                        iy = 12 : iX = 3
                        .Scrivi("Extension", iy, iX)
                        iy = 12 : iX = 30
                        .Scrivi(GlobalRoutines.FormatS(FormInch, Test * kLength) & " " & UnitLength, iy, iX)
                        iy = 12 : iX = 59 : .Scrivi(GlobalRoutines.FormatS(FormInch, Test * kLength) & " " & UnitLength, iy, iX)
                        If Math.Abs(pt_Config.Flangiata(pt_Config.Side - 1)) = 1 Then
                            iy = 19 : iX = 61
                            .Scrivi(GlobalRoutines.FormatS("(Est. ###.## " & UnitLength, Mem.Z(1, IndExt) * kLength), iy, iX)
                        End If
                    Else
                        Call frmPrintAA()
                    End If
                End If
            End With
            With Mem
                kThk = GlobalRoutines.myStr(.Z(1, IndThk) * kLength, 4, 3, 0)
                If pt_Config.Flangiata(pt_Config.Side - 1) <> 0 And CalcoloInCorso = 0 Then kEst = GlobalRoutines.myStr(.Z(1, IndExt) * kLength, 4, 3, 0)
                If VERIFICA = -1 Then GoTo 7551
                If VERIFICA = 1 And Not Globale Then GoTo 7480
                Ottimo = THKMIN < .Z(1, IndThk) And THKMIN > .Z(1, IndThk) - 1
                Preced = THKMIN < THKPreced(iSide)
                If Ottimo Or (Preced And Global1) Then GoTo 7550
7480:           If Not Globale And VERIFICA = 1 Then
                    AcqThk(kThk, kEst, THKMIN)
                Else
                    kThk = "" : kEst = ""
                End If
                If kThk = "" Then kThk = GlobalRoutines.myStr(THKMIN * kLength, 4, 3, 0)
                If pt_Config.Flangiata(pt_Config.Side - 1) <> 0 And kEst = "" Then kEst = GlobalRoutines.myStr(Test * kLength, 4, 3, 0)
Uno:            .Z(1, IndThk) = GlobalRoutines.ValVir(kThk) / kLength
                thk = .Z(1, IndThk) '/ inc
                If pt_Config.Differing > 1 And VERIFICA = 0 Then
                    If iSide = 1 Then
                        .Z(1, 262) = Int(MinOpt(2) + 0.5)
                    Else
                        .Z(1, 34) = Int(MinOpt(1) + 0.5)
                    End If
                End If
                If Not Globale And VERIFICA = 1 Then
                    Problem(Indprobl1).TSheThk = .Z(1, 34)
                    Problem(IndProbl2).TSheThk = .Z(1, 262)
                    THKPreced(1) = .Z(1, 34)
                    THKPreced(2) = .Z(1, 262)
                End If
                If pt_Config.Flangiata(pt_Config.Side - 1) <> 0 Then
                    Problem(IndProbl).TExtThk = GlobalRoutines.ValVir(kEst) / kLength
                    .Z(1, IndExt) = GlobalRoutines.ValVir(kEst) / kLength
                End If
                If thk < THKminim Then .Z(1, IndThk) = Int(THKminim) : thk = .Z(1, IndThk) ' / inc
                '    VERIFICA = 1
                '    GoTo 4830
7551:           i = 0 : ii = 0
                If CalcoloInCorso = 0 Then
                    If GlobalRoutines.ValVir(kThk) / kLength < THKMIN Then
                        i = 1
                        If Global1 Or VERIFICA <> 0 Then GoTo 7550
                        GoTo 7480
                    End If
                    If pt_Config.Flangiata(pt_Config.Side - 1) <> 0 Then
                        If GlobalRoutines.ValVir(kEst) / kLength < Test Then
                            ii = 1
                            If Not Global1 And VERIFICA <> 0 Then GoTo 7550
                            GoTo 7480
                        End If
                    End If
                Else
                    Call FattUs(NonMostrare:=True)
                    If .Z(iCond + Offset, 537) > 1 Or .Z(iCond + Offset, 538) > 1 Then
                        i = 1
                        If Global1 Or VERIFICA <> 0 Then GoTo 7550
                        GoTo 7480
                    End If
                End If
7550:           If icMAWP < 1 Then
                    Dim Tit As String = mioRis.TabStrip1.SelectedTab.Tag
                    Tit = setmiotag(Tit, "No", 1)
                    mioRis.TabStrip1.SelectedTab.Tag = Tit
                End If
                If (i = 1 Or ii = 1) And icMAWP < 1 Then
                    Dim Tit As String = mioRis.TabStrip1.SelectedTab.Tag
                    Tit = setmiotag(Tit, "rosso", 1)
                    mioRis.TabStrip1.SelectedTab.Tag = Tit
                End If
                If Global1 Then
                    If THKPreced(iSide) < .Z(1, IndThk) Then THKPreced(iSide) = .Z(1, IndThk)
                    If Preced Then .Z(1, IndThk) = THKPreced(iSide)
                Else
                    iy = 21 : iX = 3
                    mioRis.Scrivi(rmHelpStrings.GetString("spessorecentro") & GlobalRoutines.FormatS("  #####.## ", .Z(1, IndThk) * kLength) & UnitLength, iy, iX, i)
                    If Math.Abs(pt_Config.Flangiata(pt_Config.Side - 1)) = 1 Then
                        iy = 22 : iX = 3
                        mioRis.Scrivi(rmHelpStrings.GetString("spessoreestens") & GlobalRoutines.FormatS(" #####.## ", .Z(1, IndExt) * kLength) & UnitLength, iy, iX, ii)
                    End If
                End If
            End With
            Calcoli = True
        Catch e As Exception
            MessageBox.Show(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Function
    Private Sub kkC()
        With Mem
            .Z(iCond, 40) = GG '* inc
            .Z(iCond, 41) = t '* inc
            .Z(iCond, 42) = COR '* inc
            k = t / GG : KC = (t - COR) / (GG + 2 * COR)
            .Z(iCond, 43) = k : .Z(iCond, 44) = KC
            If k <= 0.02 Then f = 1
            If KC <= 0.02 Then fc = 1
            If k >= 0.05 Then f = 0.8
            If KC >= 0.05 Then fc = 0.8
            If (k > 0.02 And k < 0.05) Then f = (17 - 100 * k) / 15
            If (KC > 0.02 And KC < 0.05) Then fc = (17 - 100 * KC) / 15
            If pt_Config.Differing >= 2 Then
                If pt_Config.Side = 2 Then
                    .Z(iCond, 310) = f : .Z(iCond, 311) = fc
                    '.Z(iCond , 45) = f: .Z(iCond , 46) = fc
                Else
                    .Z(iCond, 45) = f : .Z(iCond, 46) = fc
                End If
            Else
4840:           .Z(iCond, 45) = f : .Z(iCond, 46) = fc
            End If
        End With
    End Sub
    Private Sub Calcj()
        With Mem
            If .Z(iCond, 26) = 0 Then
                j = 1 : JC = 1 : DJ = g : CJ = COR
                Exit Sub
            End If
            Sj = .Z(iCond, 36) : SJC = .Z(iCond, 37)
            If Sj = 0 Then Sj = SJM : .Z(iCond, 36) = Sj
            If SJC = 0 Then SJC = SJMC : .Z(iCond, 37) = SJC
            j = 1 / (1 + (pi * (DS1 + ts) * ts * ktkf * ES) / (Sj * LTfq1))
            JC = 1 / (1 + (pi * ((DS1 + 2 * cs) + (ts - cs)) * (ts - cs) * ktkfC * ES) / (SJC * LTCfq1))
        End With
    End Sub
    Function Calcoli2() As Short
        Dim IndThk, iSide, IndExt As Short
        Dim i As Short
        Dim eta, THKminim, x As Single
        Dim pbs, PBT, PBTC, PBSC As Single
        Dim k, GG, Test, t, KC As Single
        Dim fc, THK1, THK0, f, d As Single
        Dim THK2BC, THK3B, THK1B, THK2B, THK1BC, THK3BC As Single
        Dim THK2SC, THK3S, THK1S, THK2S, THK1SC, THK3SC As Single
        Dim PTEFFC, PDEFF, PSEFF, PTEFF, PSEFFC, PDEFFC As Single
        Dim PTSEFFC, PDSEFF, PSSEFF, PTSEFF, PSSEFFC, PDSEFFC As Single
        Dim Ottimo, Res, Preced As Boolean
        Dim THKMIN3, THKMIN2, Dcc As Single
        Dim kThk As String = ""
        Dim kEst As String = ""
        Dim iX, iy As Short
        Dim ii As Short
        On Error GoTo Err2
        If pt_Config.SoloDilat Then Calcoli2 = True : Exit Function
        iSide = pt_Config.Side
        If iSide = 2 Then
            IndThk = 262 : IndExt = 289
        Else
            IndThk = 34 : IndExt = 288
        End If
        'calcolo diametro,spessore fasciame,corrosione da inserire nel calcolo
        If Not CalcFK(iSide, t, GG, f, fc, k, KC) Then Calcoli2 = False : Exit Function
        With Mem
            If CalcoloInCorso = 1 Then
                Padre = objMemb(Involucr(kLato, jInvolucr).IndObject)
                Res = Padre.RulesAA.AA24(iCond, Offset, icMAWP = 0 And VERIFICA = 0)
                If Not Res Then Calcoli2 = False : Exit Function
                If icMAWP = 0 Then
                    THKMIN0 = .Z(iCond + Offset, 161)
                    THKMIN1 = .Z(iCond + Offset, 162)
                    If THKMIN0 > THKMIN1 Then THKMIN = THKMIN0 Else THKMIN = THKMIN1
                End If
                GoTo 7241
            End If
            'calcolo spessore minimo piastra
            THKminim = SpessMin()
            If thk < THKminim Then thk = THKminim : VERIFICA = 0
            THK0 = thk - Cptf : .Z(iCond, 49) = THK0
            THK1 = thk - (cs + CT * -CShort(CT > Cptf) + Cptf * -CShort(CT <= Cptf)) : .Z(iCond, 50) = THK1
            'calcolo pressione equivalente dei bulloni   (R-7.192)
            'CalcMom:
            If iSide = 1 Then
                If (System.Math.Abs(pt_Config.Flangiata(1 - 1)) = 1 Or pt_Config.Gasketed(1 - 1) = -1) And Not (pt_Config.Gasketed(1 - 1) = 1 Or pt_Config.Gasketed(1 - 1) = 2) Then
                    PBT = 0 : PBTC = 0 : pbs = 0 : PBSC = 0
                    'CalcPBT:
                    '               PBT = (6.2 / f ^ 2) * (M1ptf / g ^ 3)
                    '              PBTC = (6.2 / fc ^ 2) * (M1ptf / (g + 2 * COR) ^ 3)
                    '             pbs = (6.2 / f ^ 2) * (M2ptf / g ^ 3)
                    '            PBSC = (6.2 / fc ^ 2) * (M2ptf / (g + 2 * COR) ^ 3)
                Else
                    PBT = 0 : PBTC = 0 : pbs = 0 : PBSC = 0
                End If
            ElseIf iSide = 2 Then
                If pt_Config.Flangiata(1 - 1) = 2 Or pt_Config.Flangiata(2 - 1) = 3 Then
                    PBT = 0 : PBTC = 0 : pbs = 0 : PBSC = 0
                    'CalcPBT:
                    '               PBT = (6.2 / f ^ 2) * (M1ptf / g ^ 3)
                    '              PBTC = (6.2 / fc ^ 2) * (M1ptf / (g + 2 * COR) ^ 3)
                    '             pbs = (6.2 / f ^ 2) * (M2ptf / g ^ 3)
                    '            PBSC = (6.2 / fc ^ 2) * (M2ptf / (g + 2 * COR) ^ 3)
                Else
                    PBT = 0 : PBTC = 0 : pbs = 0 : PBSC = 0
                End If
            End If
            .Z(iCond, 61) = PBT : .Z(iCond, 62) = PBTC : .Z(iCond, 63) = pbs : .Z(iCond, 64) = PBSC
            'CalcPeff:
            If iSide = 1 Or Not (pt_Config.Flottante = 1 Or pt_Config.Flottante = 5) Then
                'pressione effettiva lato shell
730:            PSEFF = Ps + pbs : PSEFFC = Ps + PBSC
                If Problem(IndProbl).Vacuum >= 2 Then PSEFF = PSEFF + 15 : PSEFFC = PSEFFC + 15
                'pressione effettiva lato tubi
                PTEFF = PT + PBT : PTEFFC = PT + PBTC
                If Problem(IndProbl).Vacuum = 1 Or Problem(IndProbl).Vacuum = 3 Then PTEFF = PTEFF + 15 : PTEFFC = PTEFFC + 15
                'pressione differenziale effettiva
                If Problem(IndProbl).PDIFF = 0 Then 'differenziale
                    PTEFF = 0 : PTEFFC = 0 : PTSEFF = 0 : PTSEFFC = 0
                    PSEFF = 0 : PSEFFC = 0 : PSSEFF = 0 : PSSEFFC = 0
                    .Z(iCond + Offset, 107) = 0 : .Z(iCond + Offset, 108) = 0
                    .Z(iCond, 117 + Offset) = 0 : .Z(iCond, 118 + Offset) = 0
                    .Z(iCond, 81 + Offset) = 0 : .Z(iCond, 82 + Offset) = 0
                    .Z(iCond, 93 + Offset) = 0 : .Z(iCond, 94 + Offset) = 0
                    PDEFF = PDE + pbs + PBT : .Z(iCond, 133 + Offset) = PDEFF
                    PDEFFC = PDE + PBSC + PBTC : .Z(iCond, 134 + Offset) = PDEFFC
                End If
            Else
                If pt_Config.Flottante = 1 Then 'RCB 7.141
                    PSEFF = 0 : PSEFFC = 0
                    d = .Z(1, 309) : Dcc = .Z(1, 592)
                    If d * Dcc = 0 Then
                        MessageBox.Show("Mancano dati geometrici relativi alla piastra flottante")
                        Calcoli2 = False
                        Exit Function
                    End If
                    PTEFF = PT + Ps * 1.25 * (d ^ 2 - Dcc ^ 2) * (d - Dcc) / d / f ^ 2 / GG ^ 2
                    PTEFFC = PT + Ps * 1.25 * (d ^ 2 - Dcc ^ 2) * (d - Dcc) / d / fc ^ 2 / GG ^ 2
                ElseIf pt_Config.Flottante = 5 Then  'RCB 7.142
                    PSEFF = 0 : PSEFFC = 0
                    PTEFF = PT
                    If Problem(IndProbl).Vacuum = 1 Or Problem(IndProbl).Vacuum = 3 Then PTEFF = PTEFF + 15
                    PTEFFC = PTEFF
                End If
            End If
            .Z(iCond, 81 + Offset) = PSEFF : .Z(iCond, 82 + Offset) = PSEFFC
            .Z(iCond, 107 + Offset) = PTEFF : .Z(iCond, 108 + Offset) = PTEFFC
            'calcolo efficienza di legamento
            If PA = 0 Or DOO = 0 Then
                MessageBox.Show("Dati sui tubi incompleti")
                Calcoli2 = False
                Exit Function
            End If
            eta = Ligament(PA, DOO)
            If eta = 0 Then Exit Function
            .Z(iCond, 271) = eta
            'calcolo spessore per bending  (R-7.132)
            If Sptf = 0 Then
                MessageBox.Show("Non è stato definito l'ammissibile della piastra tubiera")
                Calcoli2 = False
                Exit Function
            End If
740:        THK1B = (f * GS / 3) * System.Math.Sqrt(PSEFF / Sptf / eta) : .Z(iCond + Offset, 147) = THK1B
            THK2B = (f * GC / 3) * System.Math.Sqrt(PTEFF / Sptf / eta) : .Z(iCond + Offset, 149) = THK2B
            THK3B = (f * g / 3) * System.Math.Sqrt(PDEFF / Sptf / eta) : .Z(iCond + Offset, 151) = THK3B
            .Z(iCond + Offset, 163) = .Z(iCond + Offset, 151)
            THK1BC = ((fc * (GS + 2 * COR)) / 3) * System.Math.Sqrt(PSEFFC / Sptf / eta) : .Z(iCond + Offset, 148) = THK1BC
            THK2BC = ((fc * (GC + 2 * COR)) / 3) * System.Math.Sqrt(PTEFFC / Sptf / eta) : .Z(iCond + Offset, 150) = THK2BC
            THK3BC = ((fc * (g + 2 * COR)) / 3) * System.Math.Sqrt(PDEFFC / Sptf / eta) : .Z(iCond + Offset, 152) = THK3BC
            .Z(iCond + Offset, 164) = .Z(iCond + Offset, 152)
            'CalcPseff:
            If iSide = 1 Or Not pt_Config.Flottante = 1 Then
                PSSEFF = PSEFF : PTSEFF = PTEFF : PDSEFF = PDEFF
                PSSEFFC = PSEFFC : PTSEFFC = PTEFFC : PDSEFFC = PDEFFC
            Else
                PSSEFF = 0 : PSSEFFC = 0 : PDSEFF = 0
                PTSEFF = PT + Ps * (d ^ 2 - Dcc ^ 2) / Dcc ^ 2
                PTSEFFC = PTSEFF
                .Z(iCond + Offset, 93) = PSSEFF
                .Z(iCond + Offset, 117) = PTSEFF
                .Z(iCond + Offset, 145) = PDSEFF
            End If
            'calcolo spessore al taglio    (R-7.133)
            THK1S = ((0.31 * DL) / (1 - (DOO / PA))) * (PSSEFF / Sptf) : .Z(iCond + Offset, 153) = THK1S
            THK2S = ((0.31 * DL) / (1 - (DOO / PA))) * (PTSEFF / Sptf) : .Z(iCond + Offset, 155) = THK2S
            THK3S = ((0.31 * DL) / (1 - (DOO / PA))) * (PDSEFF / Sptf) : .Z(iCond + Offset, 157) = THK3S
            .Z(iCond + Offset, 165) = .Z(iCond + Offset, 157)
            THK1SC = ((0.31 * DL) / (1 - (DOO / PA))) * (PSSEFFC / Sptf) : .Z(iCond + Offset, 154) = THK1SC
            THK2SC = ((0.31 * DL) / (1 - (DOO / PA))) * (PTSEFFC / Sptf) : .Z(iCond + Offset, 156) = THK2SC
            THK3SC = ((0.31 * DL) / (1 - (DOO / PA))) * (PDSEFFC / Sptf) : .Z(iCond + Offset, 158) = THK3SC
            .Z(iCond + Offset, 166) = .Z(iCond + Offset, 158)
            'calcolo spessore massimo
750:        If THK1B > THK2B Then x = THK1B Else x = THK2B
            If x > THK3B Then x = x Else x = THK3B
            If x > THK1S Then x = x Else x = THK1S
            If x > THK2S Then x = x Else x = THK2S
            If x > THK3S Then x = x Else x = THK3S
            THKMIN0 = x + Cptf : x = 0 : .Z(iCond + Offset, 159) = THKMIN0
            .Z(iCond + Offset, 161) = THKMIN0
            If THK1BC > THK2BC Then x = THK1BC Else x = THK2BC
            If x > THK3BC Then x = x Else x = THK3BC
            If x > THK1SC Then x = x Else x = THK1SC
            If x > THK2SC Then x = x Else x = THK2SC
            If x > THK3SC Then x = x Else x = THK3SC
            THKMIN1 = x + cs + CT * -CShort(CT > Cptf) + Cptf * -CShort(CT <= Cptf)
            .Z(iCond + Offset, 160) = THKMIN1 : .Z(iCond + Offset, 162) = THKMIN1
            If THKMIN0 > THKMIN1 Then THKMIN = THKMIN0 Else THKMIN = THKMIN1
            If Problem(IndProbl).PDIFF = 0 Then x = 0 : GoTo a7190 Else GoTo a7240
a7190:      If THK3B > THK3S Then x = THK3B Else x = THK3S
            'solo per caso differenziale
            THKMIN2 = x + Cptf : x = 0 : .Z(iCond + Offset, 167) = THKMIN2
            .Z(iCond + Offset, 169) = THKMIN2
            If THK3BC > THK3SC Then x = THK3BC Else x = THK3SC
            THKMIN3 = x + cs + CT * -CShort(CT > Cptf) + Cptf * -CShort(CT <= Cptf)
            .Z(iCond + Offset, 168) = THKMIN3 : .Z(iCond + Offset, 170) = THKMIN3
            If THKMIN2 > THKMIN3 Then THKMIN = THKMIN2 Else THKMIN = THKMIN3
a7240:      x = 0
            'controllo spessore calcolato con quello imposto
7241:       'CalcExt:
            If Not (pt_Config.Rear = 3 Or CalcoloInCorso = 1) Then
                If iSide = 1 Then
                    If pt_Config.Flangiata(1 - 1) <> 0 Then
752:                    Call Extension(Test)
                        If Test = -1 Then Calcoli2 = False : Exit Function
                        .Z(iCond, IndExt + 2) = Test
                    End If
                Else
                    Select Case pt_Config.Flottante
                        Case 1, 5
                        Case 2 'tipo S con backing
                        Case 3 'Tipo T con flangia
                            If Not pt_Config.Gasketed(2 - 1) = 1 Then
                                Call Extension(Test) '???????????
                                .Z(iCond, IndExt + 2) = Test
                            End If
                        Case 4 'Tipo T saldato
                    End Select
                End If
            End If
        End With
        If CalcoloInCorso = 0 Then
            mioRis._Command3_0.Visible = False
            mioRis._Command3_1.Visible = False
        End If
        mioRis.cmdDilat.Visible = False
        If icMAWP = 0 Then
            With mioRis
                If CalcoloInCorso = 0 Then
                    .TabStrip1.Visible = False
                    ._Text1_0.Visible = True
                    ._Label1_0.Visible = True
                    ._Text1_1.Visible = True
                    ._Label1_1.Visible = True
                End If
                '   .Picture2.Visible = False
                .Panel1.Visible = True
                .cmdFattUs.Visible = True
760:            Call RisPAGINA(1)
                .Command4.Visible = pt_Config.Rear < 3
                If CalcoloInCorso = 0 Then
                    iy = 9 : iX = 29
                    .Scrivi(GlobalRoutines.FormatS(FormInch, THK1B * kLength) & " " & UnitLength, iy, iX)
                    iy = 9 : iX = 58
                    .Scrivi(GlobalRoutines.FormatS(FormInch, THK1BC * kLength) & " " & UnitLength, iy, iX)
                    iy = 10 : iX = 29
                    .Scrivi(GlobalRoutines.FormatS(FormInch, THK2B * kLength) & " " & UnitLength, iy, iX)
                    iy = 10 : iX = 58
                    .Scrivi(GlobalRoutines.FormatS(FormInch, THK2BC * kLength) & " " & UnitLength, iy, iX)
                    iy = 11 : iX = 29
                    .Scrivi(GlobalRoutines.FormatS(FormInch, THK3B * kLength) & " " & UnitLength, iy, iX)
                    iy = 11 : iX = 58
                    .Scrivi(GlobalRoutines.FormatS(FormInch, THK3BC * kLength) & " " & UnitLength, iy, iX)
                    iy = 13 : iX = 29
                    .Scrivi(GlobalRoutines.FormatS(FormInch, THK1S * kLength) & " " & UnitLength, iy, iX)
                    iy = 13 : iX = 58
                    .Scrivi(GlobalRoutines.FormatS(FormInch, THK1SC * kLength) & " " & UnitLength, iy, iX)
                    iy = 14 : iX = 29
                    .Scrivi(GlobalRoutines.FormatS(FormInch, THK2S * kLength) & " " & UnitLength, iy, iX)
                    iy = 14 : iX = 58
                    .Scrivi(GlobalRoutines.FormatS(FormInch, THK2SC * kLength) & " " & UnitLength, iy, iX)
                    iy = 15 : iX = 29
                    .Scrivi(GlobalRoutines.FormatS(FormInch, THK3S * kLength) & " " & UnitLength, iy, iX)
                    iy = 15 : iX = 58
                    .Scrivi(GlobalRoutines.FormatS(FormInch, THK3SC * kLength) & " " & UnitLength, iy, iX)
                    iy = 17 : iX = 58
                    .Scrivi(GlobalRoutines.FormatS(FormInch, THKMIN * kLength) & " " & UnitLength, iy, iX)
                Else
                    Call frmPrintAA()
                End If
                If pt_Config.Flangiata(1 - 1) <> 0 And Test > 0 Then
                    iy = 19 : iX = 45
                    .Scrivi(GlobalRoutines.FormatS("(Spessore minimo Est. ###.## " & UnitLength & ")", Test * kLength), iy, iX)
                End If
                ._Label1_0.Text = "Spessore assunto (centro)"
                If Mem.Z(1, IndThk) = 0 Then Mem.Z(1, IndThk) = THKMIN
                ._Text1_0.Text = GlobalRoutines.myStr(Mem.Z(1, IndThk) * kLength, 4, 2, False)
                If Math.Abs(pt_Config.Flangiata(pt_Config.Side - 1)) = 1 And Not (Rear = 2 And (Flottante < 2 Or Flottante > 3)) Then
                    ._Label1_1.Text = "Spessore assunto (estensione)"
                    ._Text1_1.Text = GlobalRoutines.myStr(Mem.Z(1, IndExt) * kLength, 4, 2, False)
                Else
                    ._Label1_1.Visible = False
                    ._Text1_1.Visible = False
                End If
                If pt_Config.Differing > 1 Then
                    If pt_Config.Side = 1 Then
                        .Scrivi(rmHelpStrings.GetString("PIASTRA_DI_TESTA"), 3, 20)
                    Else
                        If CalcoloInCorso = 0 Then
                            .Scrivi(rmHelpStrings.GetString("PIASTRA_DI_CODA"), 3, 20)
                        Else
                            .Scrivi(rmHelpStrings.GetString("PIASTRA_FLOTTANTE"), 3, 20)
                        End If
                    End If
                End If
                If CalcoloInCorso = 0 Then
                    If Not ContinuoAuto Then .ShowDialog()
                    kThk = ._Text1_0.Text
                    kEst = ._Text1_1.Text
                    Mem.Z(1, IndThk) = GlobalRoutines.ValVir(kThk) / kLength
                    Mem.Z(1 + Offset, IndThk) = GlobalRoutines.ValVir(kThk) / kLength
                    Mem.Z(iCond + Offset, 159) = THKMIN '* inc
                    If pt_Config.Flangiata(1 - 1) <> 0 Then
                        Problem(IndProbl).TExtThk = GlobalRoutines.ValVir(kEst) / kLength
                        Mem.Z(1, IndExt) = GlobalRoutines.ValVir(kEst) / kLength
                    End If
                Else
                    If VERIFICA = -1 Then
                        kThk = GlobalRoutines.myStr(Mem.Z(1, IndThk) * kLength, 4, 4, 0)
                        If pt_Config.Flangiata(pt_Config.Side - 1) <> 0 Then kEst = GlobalRoutines.myStr(Mem.Z(1, IndExt) * kLength, 4, 4, 0)
                        GoTo 7551
                    End If
                    If VERIFICA = 1 And Not Globale Then GoTo 7480
                    Ottimo = THKMIN < Mem.Z(1, IndThk) And THKMIN > Mem.Z(1, IndThk) - 1
                    Preced = THKMIN < THKPreced(iSide)
                    If Ottimo Or (Preced And Globale) Then GoTo 7550
7480:               If Not Globale And VERIFICA = 1 Then
                        AcqThk(kThk, kEst, THKMIN)
                    Else
                        kThk = "" : kEst = ""
                    End If
                    If kThk = "" Then kThk = GlobalRoutines.myStr(THKMIN * kLength, 4, 1, 0)
                    If pt_Config.Flangiata(pt_Config.Side - 1) <> 0 And kEst = "" Then kEst = GlobalRoutines.myStr(Test * kLength, 4, 3, 0)
Uno:                Mem.Z(1, IndThk) = GlobalRoutines.ValVir(kThk) / kLength
                    thk = Mem.Z(1, IndThk)
                    If pt_Config.Differing > 1 And VERIFICA = 0 Then
                        If iSide = 1 Then
                            Mem.Z(1, 262) = Int(MinOpt(2) + 0.5)
                        Else
                            Mem.Z(1, 34) = Int(MinOpt(1) + 0.5)
                        End If
                    End If
                    If Not Globale And VERIFICA = 1 Then
                        Problem(Indprobl1).TSheThk = Mem.Z(1, 34)
                        Problem(IndProbl2).TSheThk = Mem.Z(1, 262)
                        THKPreced(1) = Mem.Z(1, 34)
                        THKPreced(2) = Mem.Z(1, 262)
                    End If
                    If pt_Config.Flangiata(pt_Config.Side - 1) <> 0 Then
                        Problem(IndProbl).TExtThk = GlobalRoutines.ValVir(kEst) / kLength
                        Mem.Z(1, IndExt) = GlobalRoutines.ValVir(kEst) / kLength
                    End If
                    If thk < THKminim Then Mem.Z(1, IndThk) = Int(THKminim + 0.5) : thk = Mem.Z(1, IndThk)
7551:               i = 0 : ii = 0
                    If CalcoloInCorso = 0 Then
                        If GlobalRoutines.ValVir(kThk) / kLength < THKMIN Then
                            i = 1
                            If Globale Or VERIFICA <> 0 Then GoTo 7550
                            GoTo 7480
                        End If
                        If pt_Config.Flangiata(pt_Config.Side - 1) <> 0 Then
                            If GlobalRoutines.ValVir(kEst) / kLength < Test And Test > 0 Then
                                ii = 1
                                If Not Globale And VERIFICA <> 0 Then GoTo 7550
                                GoTo 7480
                            End If
                        End If
                    Else
                        Call FattUs(NonMostrare:=True)
                        If Mem.Z(iCond + Offset, 537) > 1 Or Mem.Z(iCond + Offset, 538) > 1 Then
                            i = 1
                            If Globale Or VERIFICA <> 0 Then GoTo 7550
                            GoTo 7480
                        End If
                    End If
7550:               '    On Error Resume Next
                    If icMAWP < 1 Then
                        Dim Tit As String = .TabStrip1.SelectedTab.Tag
                        Tit = setmiotag(Tit, "No", 1)
                    End If
                    If (i = 1 Or ii = 1) And icMAWP < 1 Then
                        Dim Tit As String = .TabStrip1.SelectedTab.Tag
                        Tit = setmiotag(Tit, "rosso", 1)
                    End If
                    On Error GoTo 0
                    If Globale Then
                        If THKPreced(iSide) < Mem.Z(1, IndThk) Then THKPreced(iSide) = Mem.Z(1, IndThk)
                        If Preced Then Mem.Z(1, IndThk) = THKPreced(iSide)
                    Else
                        iy = 21 : iX = 3 : .Scrivi(GlobalRoutines.FormatS(rmHelpStrings.GetString("spessorecentro") & " #####.##", Mem.Z(1, IndThk) * kLength) & " " & UnitLength, iy, iX, i)
                        If Math.Abs(pt_Config.Flangiata(pt_Config.Side - 1)) = 1 Then
                            iy = 22 : iX = 3
                            .Scrivi(GlobalRoutines.FormatS(rmHelpStrings.GetString("spessoreestens") & " #####.##", Mem.Z(1, IndExt) * kLength) & " " & UnitLength, iy, iX, ii)
                        End If
                    End If
                End If
            End With
        End If
        ' iCond = 1
        Calcoli2 = True
        Exit Function
Err2:   MessageBox.Show("Err Calcoli2" & Err.Description & Str(Erl()))
        'Stop
        'Resume
    End Function
    Function Esegui() As Short
        Dim TKASav, TKBSav As Single
        Dim Res As Short
        Dim D1, D2 As Single
        Dim i As Short
        On Error GoTo ErrEseg
        If iCond = 0 Then iCond = 1
        pt_Config.nCicli = 0
        If Not mioRis.PiastraB And Not mioRis.Risposta = "Scambia" Then SetPiastra(1)
        If pt_Config.Differing > 1 And pt_Config.Rear = 1 And Not pt_Config.SoloDilat Then
            Itera = True : TKASav = 0 : TKBSav = 0
        Else
            Itera = False
        End If
        Esegui = 0
        With Mem
            Do
                Res = RifaiInt()
                If Res >= 2 Then
                    Esegui = -Res
                    Call WarnT(-Res)
                    Exit Function
                End If
                Res = ContInput()
                If (Res < 0 And Not pt_Config.SoloDilat) Or (pt_Config.SoloDilat And .Z(1, 26) = 0) Then
                    If pt_Config.SoloDilat And .Z(1, 26) = 0 Then Res = -102
                    pagina = 1 : Call WarnT(Res)
                    Esegui = 3 : Exit Function
                    ': GOTO 1850
                End If
4660:           '***ESECUZIONE CALCOLO***
4680:           If pt_Config.Rear = 1 Then
                    Res = Calcoli()
                Else
                    Res = Calcoli2()
                End If
                If Not Res Then Esegui = 3 : Exit Function
                If pt_Config.Differing < 2 Or pt_Config.SoloDilat Then
                    Exit Do
                ElseIf pt_Config.Rear = 1 Or pt_Config.Rear = 2 And CalcoloInCorso = 1 Then
                    If mioRis.Risposta = "Annulla" Then Exit Function
                    If mioRis.Risposta = "Scelta" And pt_Config.Side = 2 Then
                        mioRis.Command4.Text = "vedi LATO B"
                        Exit Do
                    End If
                    If pt_Config.nCicli > 0 Or pt_Config.Rear = 2 And pt_Config.Side = 2 Or mioRis.Risposta = "Scambia" Then
                        If pt_Config.Rear = 1 Then
                            D1 = System.Math.Abs((.Z(iCond, 34) - TKASav) / .Z(iCond, 34))
                            D2 = System.Math.Abs((.Z(iCond, 262) - TKBSav) / .Z(iCond, 262))
                            If mioRis.Risposta = "Scambia" Then D1 = 0 : D2 = 0
                        Else
                            D1 = 0
                            D2 = 0
                        End If
                        If D1 < 0.01 And D2 < 0.01 Then
                            Itera = False
                            Res = ContInput()
                            If pt_Config.Rear = 1 Then Res = Calcoli() Else Res = Calcoli2()
                            If Not Res Then Esegui = 3 : Exit Function
                            With mioRis
                                If Not Globale And InStr(.TabStrip1.SelectedTab.Text, "Pias") > 0 Then
                                    .Command4.Visible = True
                                End If
                            End With
                            Call MediumAxial()
                            'salvataggio
                            If pt_Config.Side = 1 Then
                                For i = 1 To 310
                                    Select Case i
                                        Case 147 To 170, 296 To 299
                                        Case Else
                                            .Z(iCond + 8, i) = .Z(iCond, i)
                                    End Select
                                Next
                            End If
                            If mioRis.Risposta = "Scambia" Then Exit Do
                            If pt_Config.Side = 1 Then SetPiastra(2) Else SetPiastra(1)
                            Res = ContInput()
                            If pt_Config.Rear = 1 Then Res = Calcoli() Else Res = Calcoli2()
                            If Not Res Then Esegui = 3 : Exit Function
                            Call MediumAxial()
                            '.Z(iCond, 45) = .Z(iCond, 310): .Z(iCond, 46) = .Z(iCond, 311)
                            '.Z(iCond, 45) = 0.8: .Z(iCond, 46) = 0.8
                            Exit Do
                        End If
                    End If
                    TKASav = .Z(iCond, 34) : TKBSav = .Z(iCond, 262)
                    If pt_Config.Side = 2 Then
                        pt_Config.nCicli = pt_Config.nCicli + 1
                        SetPiastra(1)
                    Else
                        SetPiastra(2)
                    End If
                Else 'floating
                    If mioRis.Risposta = "Annulla" Then Exit Function
                    SetPiastra(2)
                    Res = RifaiInt()
                    If Res >= 2 Then
                        Esegui = -Res
                        WarnT(-Res)
                        Exit Function
                    End If
                    Res = ContInput()
                    If Res = 0 Then
                        Res = Calcoli2()
                    Else
                        WarnT(Res)
                        Esegui = Res
                        Exit Function
                    End If
                    If Not Res Then Esegui = 3 : Exit Function
                    If mioRis.Risposta = "Sw" Then
                        SetPiastra(1)
                    Else
                        Exit Do
                    End If
                End If
            Loop
        End With
        Exit Function
ErrEseg: MessageBox.Show("Errore in Esegui" & Err.Description & Str(Erl()))
    End Function
    Private Function SpessMin() As Single
        Dim Spess, Dmin As Single
        Select Case pt_Config.DC Mod 3
            Case 0
                Spess = DOO + cs + CT * -CShort(CT > Cptf) + Cptf * -CShort(CT <= Cptf)
                If Spess < 0.75 * inc Then Spess = 0.75 * inc
            Case 1
                If DOO <= inc Then
                    Dmin = 0.75 * DOO
                ElseIf DOO <= 1.25 Then
                    Dmin = 7 / 8 * inc
                ElseIf DOO <= 1.5 Then
                    Dmin = inc
                Else
                    Dmin = 1.25 * inc
                End If
                Spess = Dmin + cs + CT * -CShort(CT > Cptf) + Cptf * -CShort(CT <= Cptf)
            Case 2
                If DOO <= inc Then
                    Dmin = 0.75 * DOO
                ElseIf DOO <= 1.25 Then
                    Dmin = 7 / 8 * inc
                ElseIf DOO <= 1.5 Then
                    Dmin = inc
                Else
                    Dmin = 1.25 * inc
                End If
                Spess = Dmin + cs + CT * -CShort(CT > Cptf) + Cptf * -CShort(CT <= Cptf)
                If Spess < 0.75 * inc Then Spess = 0.75 * inc
        End Select
        SpessMin = Spess
    End Function
    Private Sub SuperAxial()
        Dim Res, i As Short
        Dim tmax As Single
7621:   Call MediumAxial()
        'maschera dei confronti
        If Not Globale Then
            If Not pt_Config.SoloDilat Then
                Call RisPAGINA(2)
                Call confro()
            Else
                Call objDilat.DisplayDilat(1, iCond, pt_Config.TipoDilat)
                Exit Sub
            End If
        Else
            If iCond < Mem.Z(1, 261) Then
                iCond = iCond + 1 : Res = Esegui() : GoTo 7621
            Else
                If icMAWP = 0 Then
                    'calcolo DimeCase
                    tmax = 0
                    For i = 1 To Mem.Z(1, 261)
                        If Mem.Z(i, 162) > tmax Then tmax = Mem.Z(i, 162) : Mem.DimeCase = i
                        If Mem.Z(i, 161) > tmax Then tmax = Mem.Z(i, 161) : Mem.DimeCase = i
                    Next
                    Call SuperSintesi()
                End If
                pagina = 1 : iCond = 1 : Chiave = 0
            End If
        End If
    End Sub
    Private Sub SuperSintesi()
        If Not pt_Config.SoloDilat Then
            If mioRis.PiastraB Then SetPiastra(2) Else SetPiastra(1)
            If Not OptimDil Then Sintesi(0)
        Else
            Sintesi(1)
        End If
        If Mem.Z(1, 26) > 0 And pt_Config.Rear = 1 Then
            objDilat.CiClall(pt_Config.TipoDilat, pt_Config.Ricotto)
        End If
    End Sub

    Private Sub Table7132(ByRef t As Single)
        If pt_Config.Rear = 3 Then
            If pt_Config.Gasketed(1 - 1) Then
                GS = GUARS : GC = GUARC
            Else
                GS = Ds : GC = DC
                If g = GS Then t = ts : COR = cscod(pt_Config.Side) Else t = tc : COR = ctcod(pt_Config.Side)
            End If
        Else
            If pt_Config.Flangiata(1 - 1) = -1 Then 'flangiata lato cassa    caso 4
                If FlChan(IndProbl).gefinc > GUARC Then GUARC = FlChan(IndProbl).gefinc
                If GUARC > 0 Then GC = GUARC
                GS = Ds
                COR = cscod(pt_Config.Side)
                t = ts
            ElseIf pt_Config.Flangiata(1 - 1) = 1 Then
                If FlShel(IndProbl).gefinc > GUARS Then GUARS = FlShel(IndProbl).gefinc
                If GUARS > 0 Then GS = GUARS
                GC = DC
                COR = ctcod(pt_Config.Side)
                t = tc
            Else
                If pt_Config.Gasketed(1 - 1) Then 'flangiata ambo i lati  caso 1
                    COR = 0 : t = 0
                    If GUARC > 0 Then GC = GUARC
                    If GUARS > 0 Then GS = GUARS
                Else 'saldata ambo i lati    caso 5
                    GS = Ds : GC = DC
                    If g = GS Then t = ts : COR = cscod(pt_Config.Side) Else t = tc : COR = ctcod(pt_Config.Side)
                End If
            End If
        End If
        If GS > GC Then g = GS Else g = GC
        With Mem
            .Z(iCond, 294) = GS : .Z(iCond, 295) = GC
            .Z(iCond, 40) = g '* inc
            .Z(iCond, 41) = t '* inc
            .Z(iCond, 42) = COR ' * inc
        End With
    End Sub
    Sub Axial()
        Dim P1C, P1ptf, Fqloc As Single
        Dim ST6, ST4, St2, ST1, ST3, ST5, ST7 As Single
        Dim ST6C, ST4C, ST2C, ST1C, ST3C, ST5C, ST7C As Single
        Dim PSH6, PSH4, PSH2, PSH1, PSH3, PSH5, PSH7 As Single
        Dim PTH6, PTH4, PTH2, PTH1, PTH3, PTH5, PTH7 As Single
        Dim PTH6C, PTH4C, PTH2C, PTH1C, PTH3C, PTH5C, PTH7C As Single
        Dim PSH6C, PSH4C, PSH2C, PSH1C, PSH3C, PSH5C, PSH7C As Single
        Dim SS6, SS4, SS2, SS1, SS3, SS5, SS7 As Single
        Dim SS6C, SS4C, SS2C, SS1C, SS3C, SS5C, SS7C As Single
        Dim X6, X4, x2, x1, X3, X5, X7 As Single
        Dim SSCPOS, x, SSPOS, SSNEG As Single
        Dim StNeg, StPos, SSCNEG, StcPos, StcNeg As Single
        Dim Safety, R, cc, Sc As Single
        Dim SafetyC, Fsaf As Single
        Dim iload As Short
        Dim PTJ2C, PTJ3, PTJ1, PTJ2, PTJ1C, PTJ3C As Single
        Dim WJ2C, WJ3, WJ1, WJ2, WJ1C, WJ3C As Single
        Dim WJC, WJ, Gsav As Single
        Dim tabtab, tabta1 As TabPage
        Dim b, a, ac, BC As Single
        Dim Corroso As Short
        Dim calcZd, Xa, calcZv, PressEff As Single
        Dim q3 As Single
        Try
            If pt_Config.SoloDilat Then
                objDilat.AppCC(iCond, pt_Config.SoloDilat, pt_Config.TipoDilat)
                Exit Sub
            End If
            With Mem
                If CalcoloInCorso = 0 Then
10:                 P1ptf = PT - PT1 : .Z(iCond, 171) = P1ptf
                    PSH1 = P1ptf : .Z(iCond, 173) = PSH1
                    PSH2 = PS1 : .Z(iCond, 175) = PSH2
                    PSH3 = -(Pd) : .Z(iCond, 177) = PSH3
                    PSH4 = P1ptf + PS1 : .Z(iCond, 179) = PSH4
                    PSH5 = P1ptf - Pd : .Z(iCond, 181) = PSH5
                    PSH6 = PS1 - Pd : .Z(iCond, 183) = PSH6
                    PSH7 = P1ptf + PS1 - Pd : .Z(iCond, 185) = PSH7
20:                 P1C = PT - PT1C : .Z(iCond, 172) = P1C
                    PSH1C = P1C : .Z(iCond, 174) = PSH1C
                    PSH2C = PS1C : .Z(iCond, 176) = PSH2C
                    PSH3C = -(PDC) : .Z(iCond, 178) = PSH3C
                    PSH4C = P1C + PS1C : .Z(iCond, 180) = PSH4C
                    PSH5C = P1C - PDC : .Z(iCond, 182) = PSH5C
                    PSH6C = PS1C - PDC : .Z(iCond, 184) = PSH6C
                    PSH7C = P1C + PS1C - PDC : .Z(iCond, 186) = PSH7C
                    'calcolo stress massimo nello shell
                    If Problem(IndProbl).PDIFF = 0 Then
                        SS1 = 0
                        SS2 = 0
                    Else
                        SS1 = ((Ds + ts) * PSH1) / (4 * ts)
                        SS2 = ((Ds + ts) * PSH2) / (4 * ts)
                    End If
                    SS3 = ((Ds + ts) * PSH3) / (4 * ts) : If PSH3 > 0 Then SS3 = SS3 / 2
                    SS4 = ((Ds + ts) * PSH4) / (4 * ts)
                    SS5 = ((Ds + ts) * PSH5) / (4 * ts) : If PSH5 > 0 Then SS5 = SS5 / 2
                    SS6 = ((Ds + ts) * PSH6) / (4 * ts) : If PSH6 > 0 Then SS6 = SS6 / 2
                    SS7 = ((Ds + ts) * PSH7) / (4 * ts) : If PSH7 > 0 Then SS7 = SS7 / 2
                    If Problem(IndProbl).PDIFF = 0 Then
                        SS1C = 0
                        SS2C = 0
                        SS5 = 0
                        SS6 = 0
                        SS5C = 0
                        SS6C = 0
                    Else
                        SS1C = (((Ds + 2 * cs) + (ts - cs)) * PSH1C) / (4 * (ts - cs))
                        SS2C = (((Ds + 2 * cs) + (ts - cs)) * PSH2C) / (4 * (ts - cs))
                        SS5C = (((Ds + 2 * cs) + (ts - cs)) * PSH5C) / (4 * (ts - cs)) : If PSH5C > 0 Then SS5C = SS5C / 2
                        SS6C = (((Ds + 2 * cs) + (ts - cs)) * PSH6C) / (4 * (ts - cs)) : If PSH6C > 0 Then SS6C = SS6C / 2
                    End If
                    SS3C = (((Ds + 2 * cs) + (ts - cs)) * PSH3C) / (4 * (ts - cs)) : If PSH3C > 0 Then SS3C = SS3C / 2
                    SS4C = (((Ds + 2 * cs) + (ts - cs)) * PSH4C) / (4 * (ts - cs))
40:                 SS7C = (((Ds + 2 * cs) + (ts - cs)) * PSH7C) / (4 * (ts - cs)) : If PSH7C > 0 Then SS7C = SS7C / 2
                    .Z(iCond, 187) = SS1 : .Z(iCond, 188) = SS1C
                    .Z(iCond, 189) = SS2 : .Z(iCond, 190) = SS2C
                    .Z(iCond, 191) = SS3 : .Z(iCond, 192) = SS3C
                    .Z(iCond, 193) = SS4 : .Z(iCond, 194) = SS4C
                    .Z(iCond, 195) = SS5 : .Z(iCond, 196) = SS5C
                    .Z(iCond, 197) = SS6 : .Z(iCond, 198) = SS6C
                    .Z(iCond, 199) = SS7 : .Z(iCond, 200) = SS7C
                    If SS1 > 0 Then x1 = SS1 Else x1 = 0
                    If SS2 > 0 Then x2 = SS2 Else x2 = 0
                    If SS3 > 0 Then X3 = SS3 Else X3 = 0
                    If SS4 > 0 Then X4 = SS4 Else X4 = 0
                    If SS5 > 0 Then X5 = SS5 Else X5 = 0
                    If SS6 > 0 Then X6 = SS6 Else X6 = 0
                    If SS7 > 0 Then X7 = SS7 Else X7 = 0
                    If x1 > x2 Then x = x1 Else x = x2
                    If x > X3 Then x = x Else x = X3
                    If x > X4 Then x = x Else x = X4
                    If x > X5 Then x = x Else x = X5
                    If x > X6 Then x = x Else x = X6
                    If x > X7 Then x = x Else x = X7
50:                 SSPOS = x : .Z(iCond, 201) = SSPOS
                    If SS1C > 0 Then x1 = SS1C Else x1 = 0
                    If SS2C > 0 Then x2 = SS2C Else x2 = 0
                    If SS3C > 0 Then X3 = SS3C Else X3 = 0
                    If SS4C > 0 Then X4 = SS4C Else X4 = 0
                    If SS5C > 0 Then X5 = SS5C Else X5 = 0
                    If SS6C > 0 Then X6 = SS6C Else X6 = 0
                    If SS7C > 0 Then X7 = SS7C Else X7 = 0
                    If x1 > x2 Then x = x1 Else x = x2
                    If x > X3 Then x = x Else x = X3
                    If x > X4 Then x = x Else x = X4
                    If x > X5 Then x = x Else x = X5
                    If x > X6 Then x = x Else x = X6
                    If x > X7 Then x = x Else x = X7
                    SSCPOS = x : .Z(iCond, 202) = SSCPOS
                    If SS1 < 0 Then x1 = SS1 Else x1 = 0
                    If SS2 < 0 Then x2 = SS2 Else x2 = 0
                    If SS3 < 0 Then X3 = SS3 Else X3 = 0
                    If SS4 < 0 Then X4 = SS4 Else X4 = 0
                    If SS5 < 0 Then X5 = SS5 Else X5 = 0
                    If SS6 < 0 Then X6 = SS6 Else X6 = 0
                    If SS7 < 0 Then X7 = SS7 Else X7 = 0
                    If x1 < x2 Then x = x1 Else x = x2
                    If x < X3 Then x = x Else x = X3
                    If x < X4 Then x = x Else x = X4
                    If x < X5 Then x = x Else x = X5
                    If x < X6 Then x = x Else x = X6
                    If x < X7 Then x = x Else x = X7
60:                 SSNEG = x : .Z(iCond, 203) = SSNEG
                    If SS1C < 0 Then x1 = SS1C Else x1 = 0
                    If SS2C < 0 Then x2 = SS2C Else x2 = 0
                    If SS3C < 0 Then X3 = SS3C Else X3 = 0
                    If SS4C < 0 Then X4 = SS4C Else X4 = 0
                    If SS5C < 0 Then X5 = SS5C Else X5 = 0
                    If SS6C < 0 Then X6 = SS6C Else X6 = 0
                    If SS7C < 0 Then X7 = SS7C Else X7 = 0
                    If x1 < x2 Then x = x1 Else x = x2
                    If x < X3 Then x = x Else x = X3
                    If x < X4 Then x = x Else x = X4
                    If x < X5 Then x = x Else x = X5
                    If x < X6 Then x = x Else x = X6
                    If x < X7 Then x = x Else x = X7
                    SSCNEG = x : .Z(iCond, 204) = SSCNEG
                Else
                    With Padre
                        .RulesAA.AA249(iCond, Offset)
                        .RulesAA.AA2410(iCond, Offset)
                    End With
                End If
                'tube longitudinal stress (R-7.23)
                If CalcoloInCorso = 0 Then
65:                 P2ptf = PT1 - ((FT / Fq) * PT) : .Z(iCond, 205) = P2ptf
                    P3ptf = PS1 - ((FS / Fq) * Ps) : .Z(iCond, 207) = P3ptf
                    PTH1 = P2ptf : .Z(iCond, 209) = PTH1
                    PTH2 = -P3ptf : .Z(iCond, 211) = PTH2
                    PTH3 = Pd : .Z(iCond, 213) = PTH3
                    PTH4 = P2ptf - P3ptf : .Z(iCond, 215) = PTH4
                    PTH5 = P2ptf + Pd : .Z(iCond, 217) = PTH5
                    PTH6 = -P3ptf + Pd : .Z(iCond, 219) = PTH6
                    PTH7 = P2ptf - P3ptf + Pd : .Z(iCond, 221) = PTH7
                    P2C = PT1C - ((FTC / FQC) * PT) : .Z(iCond, 206) = P2C
                    P3C = PS1C - ((FSC / FQC) * Ps) : .Z(iCond, 208) = P3C
                    PTH1C = P2C : .Z(iCond, 210) = PTH1C
                    PTH2C = -P3C : .Z(iCond, 212) = PTH2C
                    PTH3C = PDC : .Z(iCond, 214) = PTH3C
                    PTH4C = P2C - P3C : .Z(iCond, 216) = PTH4C
                    PTH5C = P2C + PDC : .Z(iCond, 218) = PTH5C
                    PTH6C = -P3C + PDC : .Z(iCond, 220) = PTH6C
                    PTH7C = P2C - P3C + PDC : .Z(iCond, 222) = PTH7C
                    'calcolo stress massimo nei tubi
                    If Problem(IndProbl).PDIFF = 0 Then
                        ST1 = 0
                        St2 = 0
                        ST3 = 0
                        ST5 = 0
                        ST6 = 0
                        ST1C = 0
                        ST2C = 0
                        ST3C = 0
                        ST5C = 0
                        ST6C = 0
                    Else
                        ST1 = (Fq * PTH1 * g ^ 2) / (4 * Nptf * tt * (DOO - tt))
                        St2 = (Fq * PTH2 * g ^ 2) / (4 * Nptf * tt * (DOO - tt))
                        ST3 = (Fq * PTH3 * g ^ 2) / (4 * Nptf * tt * (DOO - tt)) : If PTH3 > 0 Then ST3 = ST3 / 2
                        ST5 = (Fq * PTH5 * g ^ 2) / (4 * Nptf * tt * (DOO - tt)) : If PTH5 > 0 Then ST5 = ST5 / 2
                        ST6 = (Fq * PTH6 * g ^ 2) / (4 * Nptf * tt * (DOO - tt)) : If PTH6 > 0 Then ST6 = ST6 / 2
                        ST1C = (FQC * PTH1C * (g + 2 * COR) ^ 2) / (4 * Nptf * tt * (DOO - tt))
                        ST2C = (FQC * PTH2C * (g + 2 * COR) ^ 2) / (4 * Nptf * tt * (DOO - tt))
                        ST3C = (FQC * PTH3C * (g + 2 * COR) ^ 2) / (4 * Nptf * tt * (DOO - tt)) : If PTH3C > 0 Then ST3C = ST3C / 2
                        ST5C = (FQC * PTH5C * (g + 2 * COR) ^ 2) / (4 * Nptf * tt * (DOO - tt)) : If PTH5C > 0 Then ST5C = ST5C / 2
                        ST6C = (FQC * PTH6C * (g + 2 * COR) ^ 2) / (4 * Nptf * tt * (DOO - tt)) : If PTH6C > 0 Then ST6C = ST6C / 2
                    End If
                    ST4 = (Fq * PTH4 * g ^ 2) / (4 * Nptf * tt * (DOO - tt))
                    ST7 = (Fq * PTH7 * g ^ 2) / (4 * Nptf * tt * (DOO - tt))
                    If PTH7 > 0 Then ST7 = ST7 / 2
                    ST4C = (FQC * PTH4C * (g + 2 * COR) ^ 2) / (4 * Nptf * tt * (DOO - tt))
                    ST7C = (FQC * PTH7C * (g + 2 * COR) ^ 2) / (4 * Nptf * tt * (DOO - tt))
                    If PTH7C > 0 Then ST7C = ST7C / 2
80:                 .Z(iCond, 223) = ST1 : .Z(iCond, 224) = ST1C
                    .Z(iCond, 225) = St2 : .Z(iCond, 226) = ST2C
                    .Z(iCond, 227) = ST3 : .Z(iCond, 228) = ST3C
                    .Z(iCond, 229) = ST4 : .Z(iCond, 230) = ST4C
                    .Z(iCond, 231) = ST5 : .Z(iCond, 232) = ST5C
                    .Z(iCond, 233) = ST6 : .Z(iCond, 234) = ST6C
                    .Z(iCond, 235) = ST7 : .Z(iCond, 236) = ST7C
                    If ST1 > 0 Then x1 = ST1 Else x1 = 0
                    If St2 > 0 Then x2 = St2 Else x2 = 0
                    If ST3 > 0 Then X3 = ST3 Else X3 = 0
                    If ST4 > 0 Then X4 = ST4 Else X4 = 0
                    If ST5 > 0 Then X5 = ST5 Else X5 = 0
                    If ST6 > 0 Then X6 = ST6 Else X6 = 0
                    If ST7 > 0 Then X7 = ST7 Else X7 = 0
                    If x1 > x2 Then x = x1 Else x = x2
                    If x > X3 Then x = x Else x = X3
                    If x > X4 Then x = x Else x = X4
                    If x > X5 Then x = x Else x = X5
                    If x > X6 Then x = x Else x = X6
                    If x > X7 Then x = x Else x = X7
90:                 StPos = x : .Z(iCond, 237) = StPos
                    If ST1C > 0 Then x1 = ST1C Else x1 = 0
                    If ST2C > 0 Then x2 = ST2C Else x2 = 0
                    If ST3C > 0 Then X3 = ST3C Else X3 = 0
                    If ST4C > 0 Then X4 = ST4C Else X4 = 0
                    If ST5C > 0 Then X5 = ST5C Else X5 = 0
                    If ST6C > 0 Then X6 = ST6C Else X6 = 0
                    If ST7C > 0 Then X7 = ST7C Else X7 = 0
                    If x1 > x2 Then x = x1 Else x = x2
                    If x > X3 Then x = x Else x = X3
                    If x > X4 Then x = x Else x = X4
                    If x > X5 Then x = x Else x = X5
                    If x > X6 Then x = x Else x = X6
                    If x > X7 Then x = x Else x = X7
                    StcPos = x : .Z(iCond, 238) = StcPos
                    If ST1 < 0 Then x1 = ST1 Else x1 = 0
                    If St2 < 0 Then x2 = St2 Else x2 = 0
                    If ST3 < 0 Then X3 = ST3 Else X3 = 0
                    If ST4 < 0 Then X4 = ST4 Else X4 = 0
                    If ST5 < 0 Then X5 = ST5 Else X5 = 0
                    If ST6 < 0 Then X6 = ST6 Else X6 = 0
                    If ST7 < 0 Then X7 = ST7 Else X7 = 0
                    If x1 < x2 Then x = x1 Else x = x2
                    If x < X3 Then x = x Else x = X3
                    If x < X4 Then x = x Else x = X4
                    If x < X5 Then x = x Else x = X5
                    If x < X6 Then x = x Else x = X6
                    If x < X7 Then x = x Else x = X7
100:                StNeg = x : .Z(iCond, 239) = StNeg
                    If ST1C < 0 Then x1 = ST1C Else x1 = 0
                    If ST2C < 0 Then x2 = ST2C Else x2 = 0
                    If ST3C < 0 Then X3 = ST3C Else X3 = 0
                    If ST4C < 0 Then X4 = ST4C Else X4 = 0
                    If ST5C < 0 Then X5 = ST5C Else X5 = 0
                    If ST6C < 0 Then X6 = ST6C Else X6 = 0
                    If ST7C < 0 Then X7 = ST7C Else X7 = 0
                    If x1 < x2 Then x = x1 Else x = x2
                    If x < X3 Then x = x Else x = X3
                    If x < X4 Then x = x Else x = X4
                    If x < X5 Then x = x Else x = X5
                    If x < X6 Then x = x Else x = X6
                    If x < X7 Then x = x Else x = X7
102:                StcNeg = x : .Z(iCond, 240) = StcNeg
                Else
                    Padre.RulesAA.AA248(iCond + Offset)
                    If pt_Config.Side = 2 Then Exit Sub
                    Fq = clsTrigon.Infinito : FQC = clsTrigon.Infinito
                    If Padre.TipoAA < 99 Then
                        For iload = 1 To 7
                            If .Z(iCond, 145 + iload - 1) < Fq Then Fq = .Z(iCond, 145 + iload - 1)
                            If .Z(iCond, 145 + iload - 1 + 7) < FQC Then FQC = .Z(iCond, 145 + iload - 1 + 7)
                        Next
                    End If
                    For Corroso = 0 To 1
                        Xa = .Z(iCond, 402 + Corroso)
                        calcZv = .Z(iCond, 406 + Corroso)
                        calcZd = .Z(iCond, 410 + Corroso)
                        For iload = 1 To 7
                            PressEff = .Z(iCond, 330 + iload - 1 + 7 * Corroso)
                            q3 = .Z(iCond, 436 + iload - 1 + 7 * Corroso)
                            Fqloc = 0.5 * (calcZd + q3 * calcZv) * Xa ^ 4
                            If PressEff = 0 Then Fqloc = 4
                            If Fqloc < 2.5 Then Fqloc = 2.5
                            If Fqloc < Fq And Corroso = 0 Then Fq = Fqloc
                            If Fqloc < FQC And Corroso = 1 Then FQC = Fqloc
                            Fsaf = 3.25 - 0.5 * Fqloc
                            If Fsaf < 1.25 Then Fsaf = 1.25
                            .Z(iCond, 599 + iload - 1 + 7 * Corroso) = Fsaf
                        Next
                    Next Corroso
                    ' End If
                End If
                'allowable tube compressive stress (R-7.24)
103:            R = 0.25 * System.Math.Sqrt(DOO ^ 2 + (DOO - 2 * tt) ^ 2) : .Z(iCond, 241) = R
104:            cc = System.Math.Sqrt((2 * pi ^ 2 * Et) / sY) : .Z(iCond, 242) = cc
105:            x = KL / R : .Z(iCond, 243) = x
                If CalcoloInCorso = 0 Then
                    Safety = 3.25 - 0.5 * Fq
                    If Safety < 1.25 Then Safety = 1.25
                    If Safety > 2 Then Safety = 2
                    SafetyC = 3.25 - 0.5 * FQC
                    If SafetyC < 1.25 Then SafetyC = 1.25
                    If SafetyC > 2 Then SafetyC = 2
                    If Safety < SafetyC Then Safety = SafetyC
                    .Z(iCond, 306) = Safety
107:                If cc <= x Then
                        Sc = (pi ^ 2 * Et) / (Safety * x ^ 2)
                    Else
                        Sc = (sY / Safety) * (1 - (x / (2 * cc)))
                    End If
                    .Z(iCond, 244) = Sc
                Else
                    .Z(iCond, 244) = clsTrigon.Infinito
                    For Corroso = 0 To 1
                        For iload = 1 To 7
                            Safety = .Z(iCond, 599 + iload - 1 + 7 * Corroso)
                            If cc <= x Then
                                Sc = (pi ^ 2 * Et) / (Safety * x ^ 2)
                            Else
                                Sc = (sY / Safety) * (1 - (x / (2 * cc)))
                            End If
                            .Z(iCond, 613 + iload - 1 + 7 * Corroso) = Sc
                            If .Z(iCond, 244) > Sc Then .Z(iCond, 244) = Sc
                        Next
                    Next Corroso
                End If
                'tube-to-tubesheet joint loads  (R-7.25)
                If CalcoloInCorso = 0 Then
110:                PTJ1 = P2ptf : .Z(iCond, 245) = PTJ1
                    PTJ2 = -P3ptf : .Z(iCond, 247) = PTJ2
                    PTJ3 = P2ptf - P3ptf : .Z(iCond, 249) = PTJ3
                    PTJ1C = P2C : .Z(iCond, 246) = PTJ1C
                    PTJ2C = -P3C : .Z(iCond, 248) = PTJ2C
                    PTJ3C = P2C - P3C : .Z(iCond, 250) = PTJ3C
                    WJ1 = (pi / (4 * Nptf)) * Fq * PTJ1 * g ^ 2
                    If Problem(IndProbl).PDIFF = 0 Then WJ1 = 0
                    WJ2 = (pi / (4 * Nptf)) * Fq * PTJ2 * g ^ 2
                    If Problem(IndProbl).PDIFF = 0 Then WJ2 = 0
                    WJ3 = (pi / (4 * Nptf)) * Fq * PTJ3 * g ^ 2
                    WJ1C = (pi / (4 * Nptf)) * FQC * PTJ1C * (g + 2 * COR) ^ 2
                    If Problem(IndProbl).PDIFF = 0 Then WJ1C = 0
                    WJ2C = (pi / (4 * Nptf)) * FQC * PTJ2C * (g + 2 * COR) ^ 2
                    If Problem(IndProbl).PDIFF = 0 Then WJ2C = 0
                    WJ3C = (pi / (4 * Nptf)) * FQC * PTJ3C * (g + 2 * COR) ^ 2
                Else
                    WJ1 = .Z(iCond, 223) * pi * (DOO ^ 2 - (DOO - 2 * tt) ^ 2) / 4
                    WJ2 = .Z(iCond, 224) * pi * (DOO ^ 2 - (DOO - 2 * tt) ^ 2) / 4
                    WJ3 = .Z(iCond, 225) * pi * (DOO ^ 2 - (DOO - 2 * tt) ^ 2) / 4
                    WJ1C = .Z(iCond, 230) * pi * (DOO ^ 2 - (DOO - 2 * tt) ^ 2) / 4
                    WJ2C = .Z(iCond, 231) * pi * (DOO ^ 2 - (DOO - 2 * tt) ^ 2) / 4
                    WJ3C = .Z(iCond, 232) * pi * (DOO ^ 2 - (DOO - 2 * tt) ^ 2) / 4
                End If
                .Z(iCond, 251) = WJ1 : .Z(iCond, 252) = WJ1C
                .Z(iCond, 253) = WJ2 : .Z(iCond, 254) = WJ2C
                .Z(iCond, 255) = WJ3 : .Z(iCond, 256) = WJ3C
                .Z(iCond + 8, 251) = WJ1 : .Z(iCond + 8, 252) = WJ1C
                .Z(iCond + 8, 253) = WJ2 : .Z(iCond + 8, 254) = WJ2C
                .Z(iCond + 8, 255) = WJ3 : .Z(iCond + 8, 256) = WJ3C
                If System.Math.Abs(WJ1) > System.Math.Abs(WJ2) Then x = WJ1 Else x = WJ2
                If System.Math.Abs(x) > System.Math.Abs(WJ3) Then x = x Else x = WJ3
120:            WJ = x : .Z(iCond, 257) = WJ : .Z(iCond + 8, 257) = WJ
                If System.Math.Abs(WJ1C) > System.Math.Abs(WJ2C) Then x = WJ1C Else x = WJ2C
                If System.Math.Abs(x) > System.Math.Abs(WJ3C) Then x = x Else x = WJ3C
                WJC = x : .Z(iCond, 258) = WJC : .Z(iCond + 8, 258) = WJC
                'confronti sugli stress a compressione
                'calcolo stress a compressione secondo ASME VIII div.1 UG-23(b)
                '130  If .Z(iCond, 36) > 0 Then ????????????????????????????????????????
130:            If .Z(iCond, 26) > 0 And pt_Config.Rear = 1 Then
                    Gsav = g
                    objDilat.AppCC(iCond, pt_Config.SoloDilat, pt_Config.TipoDilat)
                    g = Gsav
                End If
                If .Z(iCond, 203) = 0 And .Z(iCond, 204) = 0 Then Exit Sub
                a = 0.125 / ((Ds / 2) / ts)
                ac = 0.125 / (((Ds + 2 * cs) / 2) / (ts - cs))
                If .Z(iCond, 259) = 0 Or .Z(iCond, 260) = 0 Then
10020:              If b = 0 Then b = a * ES / 2
                    If BC = 0 Then BC = ac * ES / 2
                    .Z(iCond, 259) = b
                    .Z(iCond, 260) = BC
                End If
            End With
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Sub confro()
        Dim iX, i, iy As Short
        Dim MaxSig, fact, MaxSigC As Single
        Dim Tit As String
        If CalcoloInCorso = 1 Then
            fact = 3
            MaxSig = Math.Max(Mem.Z(iCond, 492), Mem.Z(iCond, 494))
            MaxSigC = Math.Max(Mem.Z(iCond, 493), Mem.Z(iCond, 495))
        Else
            fact = 1
            MaxSig = Mem.Z(iCond, 201)
            MaxSigC = Mem.Z(iCond, 202)
        End If
        GlobalRoutines.FormatS("non|")
        With mioRis
            If icMAWP = 0 Then
                Tit = .TabStrip1.SelectedTab.Tag
                Tit = setmiotag(Tit, "No", 1)
                .TabStrip1.SelectedTab.Tag = Tit
            End If
            i = 0
            If icMAWP = 0 And System.Math.Abs(MaxSig) > Mem.Z(iCond, 12) * fact Then
                i = 1
                Tit = .TabStrip1.SelectedTab.Tag
                Tit = setmiotag(Tit, "rosso", 1)
                .TabStrip1.SelectedTab.Tag = Tit
            End If
            i = 0
            iy = 4 : iX = 49
            .Scrivi(UnitPress, iy, iX, i)
            iy = 8 : iX = 22
            .Scrivi(GlobalRoutines.FormatS("#######.##", MaxSig * kPress), iy, iX, i)
            If icMAWP = 0 And System.Math.Abs(MaxSigC) > Mem.Z(iCond, 12) * fact Then
                i = 1
                Tit = .TabStrip1.SelectedTab.Tag
                Tit = setmiotag(Tit, "rosso", 1)
                .TabStrip1.SelectedTab.Tag = Tit
            End If
            iy = 8 : iX = 51 : .Scrivi(GlobalRoutines.FormatS("#######.##", MaxSigC * kPress), iy, iX, i)
            iy = 8 : iX = 36 : .Scrivi(GlobalRoutines.FormatS("#######.##", Mem.Z(iCond, 12) * fact * kPress), iy, iX, i)
            iy = 8 : iX = 65 : .Scrivi(GlobalRoutines.FormatS("#######.##", Mem.Z(iCond, 12) * fact * kPress), iy, iX, i)
            i = 0
            If icMAWP = 0 And (System.Math.Abs(Mem.Z(iCond, 203)) > Mem.Z(iCond, 12) Or System.Math.Abs(Mem.Z(iCond, 203)) > System.Math.Abs(Mem.Z(iCond, 259))) Then
                i = 1
                Tit = .TabStrip1.SelectedTab.Tag
                Tit = setmiotag(Tit, "rosso", 1)
                .TabStrip1.SelectedTab.Tag = Tit
            End If
            iy = 11 : iX = 22 : .Scrivi(GlobalRoutines.FormatS("#######.##", Mem.Z(iCond, 203) * kPress), iy, iX, i)
            i = 0
            If icMAWP = 0 And (System.Math.Abs(Mem.Z(iCond, 204)) > Mem.Z(iCond, 12) Or System.Math.Abs(Mem.Z(iCond, 204)) > System.Math.Abs(Mem.Z(iCond, 260))) Then
                i = 1
                Tit = .TabStrip1.SelectedTab.Tag
                Tit = setmiotag(Tit, "rosso", 1)
                .TabStrip1.SelectedTab.Tag = Tit
            End If
            iy = 11 : iX = 51 : .Scrivi(GlobalRoutines.FormatS("#######.##", Mem.Z(iCond, 204) * kPress), iy, iX, i)
            iy = 10 : iX = 36 : .Scrivi(GlobalRoutines.FormatS("#######.##", Mem.Z(iCond, 12) * kPress), iy, iX, i)
            iy = 10 : iX = 65 : .Scrivi(GlobalRoutines.FormatS("#######.##", Mem.Z(iCond, 12) * kPress), iy, iX, i)
            iy = 12 : iX = 36 : .Scrivi(GlobalRoutines.FormatS("#######.##", System.Math.Abs(Mem.Z(iCond, 259)) * kPress), iy, iX, i)
            iy = 12 : iX = 65 : .Scrivi(GlobalRoutines.FormatS("#######.##", System.Math.Abs(Mem.Z(iCond, 260)) * kPress), iy, iX, i)
            i = 0
            If icMAWP = 0 And (System.Math.Abs(Mem.Z(iCond, 237)) > Mem.Z(iCond, 13)) Then
                i = 1
                Tit = .TabStrip1.SelectedTab.Tag
                Tit = setmiotag(Tit, "rosso", 1)
                .TabStrip1.SelectedTab.Tag = Tit
            End If
            iy = 15 : iX = 22 : .Scrivi(GlobalRoutines.FormatS("#######.##", Mem.Z(iCond, 237) * kPress), iy, iX, i)
            i = 0
            If icMAWP = 0 And (System.Math.Abs(Mem.Z(iCond, 238)) > Mem.Z(iCond, 13)) Then
                i = 1
                Tit = .TabStrip1.SelectedTab.Tag
                Tit = setmiotag(Tit, "rosso", 1)
                .TabStrip1.SelectedTab.Tag = Tit
            End If
            iy = 15 : iX = 51 : .Scrivi(GlobalRoutines.FormatS("#######.##", Mem.Z(iCond, 238) * kPress), iy, iX, i)
            iy = 15 : iX = 36 : .Scrivi(GlobalRoutines.FormatS("#######.##", Mem.Z(iCond, 13) * kPress), iy, iX, i)
            iy = 15 : iX = 65 : .Scrivi(GlobalRoutines.FormatS("#######.##", Mem.Z(iCond, 13) * kPress), iy, iX, i)
            i = 0
            If icMAWP = 0 And (System.Math.Abs(Mem.Z(iCond, 239)) > Mem.Z(iCond, 13) Or System.Math.Abs(Mem.Z(iCond, 239)) > System.Math.Abs(Mem.Z(iCond, 244))) Then
                i = 1
                Tit = .TabStrip1.SelectedTab.Tag
                Tit = setmiotag(Tit, "rosso", 1)
                .TabStrip1.SelectedTab.Tag = Tit
            End If
            iy = 18 : iX = 22 : .Scrivi(GlobalRoutines.FormatS("#######.##", Mem.Z(iCond, 239) * kPress), iy, iX, i)
            i = 0
            If icMAWP = 0 And (System.Math.Abs(Mem.Z(iCond, 240)) > Mem.Z(iCond, 13) Or System.Math.Abs(Mem.Z(iCond, 240)) > System.Math.Abs(Mem.Z(iCond, 244))) Then
                i = 1
                Tit = .TabStrip1.SelectedTab.Tag
                Tit = setmiotag(Tit, "rosso", 1)
                .TabStrip1.SelectedTab.Tag = Tit
            End If
            iy = 18 : iX = 51 : .Scrivi(GlobalRoutines.FormatS("#######.##", Mem.Z(iCond, 240) * kPress), iy, iX, i)
            iy = 17 : iX = 36 : .Scrivi(GlobalRoutines.FormatS("#######.##", Mem.Z(iCond, 13) * kPress), iy, iX, i)
            iy = 17 : iX = 65 : .Scrivi(GlobalRoutines.FormatS("#######.##", Mem.Z(iCond, 13) * kPress), iy, iX, i)
            iy = 19 : iX = 36 : .Scrivi(GlobalRoutines.FormatS("#######.##", Mem.Z(iCond, 244) * kPress), iy, iX, i)
            iy = 19 : iX = 65 : .Scrivi(GlobalRoutines.FormatS("#######.##", Mem.Z(iCond, 244) * kPress), iy, iX, i)
            i = 0
            If icMAWP = 0 And System.Math.Abs(Mem.Z(iCond, 257)) > Mem.Z(iCond, 285) Then
                i = 1
                Tit = .TabStrip1.SelectedTab.Tag
                Tit = setmiotag(Tit, "rosso", 1)
                .TabStrip1.SelectedTab.Tag = Tit
            End If
            iy = 21 : iX = 22 : .Scrivi(GlobalRoutines.FormatS("#######.##", Mem.Z(iCond, 257) * kForce), iy, iX, i)
            i = 0
            If icMAWP = 0 And System.Math.Abs(Mem.Z(iCond, 258)) > Mem.Z(iCond, 285) Then
                i = 1
                Tit = .TabStrip1.SelectedTab.Tag
                Tit = setmiotag(Tit, "rosso", 1)
                .TabStrip1.SelectedTab.Tag = Tit
            End If
            iy = 21 : iX = 51 : .Scrivi(GlobalRoutines.FormatS("#######.##", Mem.Z(iCond, 258) * kForce), iy, iX, i)
            iy = 21 : iX = 36 : .Scrivi(GlobalRoutines.FormatS("#######.##", Mem.Z(iCond, 285) * kForce), iy, iX, i)
            iy = 21 : iX = 65 : .Scrivi(GlobalRoutines.FormatS("#######.##", Mem.Z(iCond, 285) * kForce), iy, iX, i)
            iy = 21 : iX = 15 : .Scrivi(UnitForce, iy, iX, i)
        End With
    End Sub
    Sub Extension(ByRef TestMin As Single)
        Dim Ratio, Amom As Single
        'RCB-7.1341
        If g = 0 Then
            MessageBox.Show("I dati geometrici (diametri guarnizioni e/o interno casse/mantelli) sono incompleti")
            TestMin = -1
            Exit Sub
        End If
        Ratio = Problem(IndProbl).TSheDes / g
        Amom = Math.Max(Math.Abs(M1ptf), Math.Abs(M2ptf))
        If Amom < 0 Then Amom = 0
        Mem.Z(1, 318 + pt_Config.Side) = Amom
        If Ratio = 0 Then Exit Sub
        TestMin = 0.98 * System.Math.Sqrt(Amom / Sptf * (Ratio * Ratio - 1 + 3.72 * Ratio * Ratio * System.Math.Log(Ratio)) / (Problem(IndProbl).TSheDes - g) / (1 + 1.8 * Ratio * Ratio))
        '    Addenda '94
    End Sub

    Sub FinePag(ByRef mode As Short)
        Dim Nulla, pag As String
        Dim i As Short
        Nulla = "\par " : pag = "\page "
        ContaPag = ContaPag + 1
        With Monitor.Motore.Problem
            For i = Contarig + 1 To 72 : Contarig = Contarig + 1 : .Printa(Nulla) : Next
            If mode < 2 Then Contarig = Contarig + 1 : .Printa(GlobalRoutines.FormatS _
            ("       \pard\plain \s18\qj\widctlpar\tx4536 \f2\fs18 tubesheet calculation page ##&", ContaPag, Nulla))
            Contarig = 0
            If mode = 1 Then Call Testatap() Else .Printa(pag)
            .pag = 0
        End With
    End Sub
    Function RifaiInt() As Short
        Dim i As Short
        Dim Sfa, Sfo As Single
        RifaiInt = 0
        'If icMAWP > 1 Or Not Ricalcola Then Exit Function
        If icMAWP > 1 Then Exit Function
        Ricalcola = False
        'rifacimento interpolazioni solo se era stata fatta la scelta
        With Involucr(kLato, jInvolucr)
            If pt_Config.nCicli = 0 Then
                If pt_Config.Differing = 1 And pt_Config.Rear = 1 Then
                    If (Matdim(.indice(1 - 1)).Indmat <> 0 Or Not Matdim(.indice(1 - 1)).Agganciato) And pt_Config.Rear < 2 Then
                        WWW = 7 'E PT
                        Mem.Z(iCond, WWW) = 0
                        If LeggiTab(1) = RoutBase1.ChiaviMess.MessCancel Then RifaiInt = 2 : Exit Function
                        Eptf = Mem.Z(iCond, WWW)
                        If Mem.Z(iCond, WWW) <= 0 Then RifaiInt = 2 : Exit Function
                    End If
                    WWW = 35 'ammiss PT
                    Mem.Z(iCond, WWW) = 0
                    If LeggiSigma(1) = RoutBase1.ChiaviMess.MessCancel Then RifaiInt = 2 : Exit Function
                    If Mem.Z(iCond, WWW) <= 0 Then RifaiInt = 2 : Exit Function
                ElseIf pt_Config.Rear < 3 Then 'testa flottante
                    If .indice(3 - 1) < 0 Then RifaiInt = 33 : Exit Function 'materiale seconda PT
                    If Matdim(.indice(3 - 1)).Indmat <> 0 Or Not Matdim(.indice(3 - 1)).Agganciato Then
                        WWW = 267 'E piastra B
                        Mem.Z(iCond, WWW) = 0
                        If LeggiTab(1) = RoutBase1.ChiaviMess.MessCancel Then RifaiInt = WWW : Exit Function
                        Eptf2 = Mem.Z(iCond, WWW)
                        If Mem.Z(iCond, WWW) <= 0 Then RifaiInt = WWW : Exit Function
                    End If
                    WWW = 266 'ammiss PT B
                    Mem.Z(iCond, WWW) = 0
                    If LeggiSigma(1) = RoutBase1.ChiaviMess.MessCancel Then RifaiInt = WWW : Exit Function
                    If Mem.Z(iCond, WWW) <= 0 Then RifaiInt = WWW : Exit Function
                    If Matdim(.indice(1 - 1)).Indmat <> 0 Or Not Matdim(.indice(1 - 1)).Agganciato Then
                        WWW = 7 'modelas PT A
                        Mem.Z(iCond, WWW) = 0
                        If LeggiTab(1) = RoutBase1.ChiaviMess.MessCancel Then RifaiInt = 4 : Exit Function
                        Eptf = Mem.Z(iCond, WWW)
                        If Mem.Z(iCond, WWW) <= 0 Then RifaiInt = 4 : Exit Function
                    End If
                    WWW = 35 'ammiss PT A
                    Mem.Z(iCond, WWW) = 0
                    If LeggiSigma(1) = RoutBase1.ChiaviMess.MessCancel Then RifaiInt = 5 : Exit Function
                    If Mem.Z(iCond, WWW) <= 0 Then RifaiInt = 5 : Exit Function
                End If
                If pt_Config.Gasketed(1 - 1) = 2 Then
                    'PT spinta tipo BL
                End If
                If (pt_Config.Flangiata(pt_Config.Side - 1) <> 0 Or pt_Config.Gasketed(pt_Config.Side - 1) > 0) And Problem(IndProbl).Tiranti(1).BoltCiD > 0 Then
                    Problem(IndProbl).Destemp = Destemp '(Mem.Z(iCond, 4) - 32) / 1.8
                    If .indice(2 - 1) > 0 Then
                        If Matdim(.indice(2 - 1)).Indmat > 0 Or Not Matdim(.indice(2 - 1)).Agganciato Then
                            Matdim(.indice(2 - 1)).SigmaAmm(CodiceStress, Mem.Z(1, 747), Sfa, Sfo)
                            Dim t As DatiBull = Problem(IndProbl).Tiranti(1)
                            t.AllBOpe = Sfo
                            t.AllBRoo = Sfa
                            Problem(IndProbl).Tiranti(1) = t
                        Else
                            RifaiInt = 31
                            Exit Function
                        End If
                    End If
                    If .indice(7 - 1) > 0 And BullDistinti Then
                        If Matdim(.indice(7 - 1)).Indmat > 0 Or Not Matdim(.indice(7 - 1)).Agganciato Then
                            Matdim(.indice(7 - 1)).SigmaAmm(CodiceStress, Mem.Z(iCond, 747), Sfa, Sfo)
                            Dim t As DatiBull = Problem(IndProbl).Tiranti(2)
                            t.AllBOpe = Sfo
                            t.AllBRoo = Sfa
                            Problem(IndProbl).Tiranti(2) = t
                        Else
                            RifaiInt = 31
                            Exit Function
                        End If
                    End If
                    WWW = 32
                    Mem.Z(iCond, WWW) = 0
                    Call LeggiTab(1)
                    If Mem.Z(iCond, WWW) < 0 Then
                        RifaiInt = 32
                        Exit Function
                    End If
                End If
                If pt_Config.Rear = 1 Or pt_Config.Rear = 2 And pt_Config.Flangiata(0) < 1 Then
                    WWW = 8 'E mantello
                    Mem.Z(iCond, WWW) = 0
                    Call LeggiTab(1) : ES = Mem.Z(iCond, WWW) : If Mem.Z(iCond, WWW) <= 0 Then RifaiInt = 6 : Exit Function
                    WWW = 12 ' amm. mantello
                    Mem.Z(iCond, WWW) = 0
                    Call LeggiSigma(1) : If Mem.Z(iCond, WWW) <= 0 Then RifaiInt = 12 : Exit Function
                End If
                WWW = 9 'E tubi
                Mem.Z(iCond, WWW) = 0
                Call LeggiTab(1) : Et = Mem.Z(iCond, WWW) : If Mem.Z(iCond, WWW) <= 0 Then RifaiInt = 7 : Exit Function
                WWW = 13 ' amm. tubi primario
                Mem.Z(iCond, WWW) = 0
                Call LeggiSigma(1) : If Mem.Z(iCond, WWW) <= 0 Then RifaiInt = 13 : Exit Function
                WWW = 38 ' snervamento tubi
                Mem.Z(iCond, WWW) = 0
                Call LeggiSigma(1) : If Mem.Z(iCond, WWW) <= 0 Then RifaiInt = 14 : Exit Function
                WWW = 285 'carico amm giunto
                Mem.Z(iCond, WWW) = 0
                Call LeggiSigma(1)
                If pt_Config.Rear = 1 Then
                    WWW = 15 'alfa tubi
                    Mem.Z(iCond, WWW) = 0
                    Call LeggiTab(1) : AT = Mem.Z(iCond, WWW) : If Mem.Z(iCond, WWW) <= 0 Then RifaiInt = 9 : Exit Function
                End If
                If pt_Config.Rear = 1 Or pt_Config.Rear = 2 And RadialExp And pt_Config.Flangiata(0) < 1 Then
                    WWW = 14 ' alfa mantello
                    Mem.Z(iCond, WWW) = 0
                    Call LeggiTab(1) : ASS = Mem.Z(iCond, WWW) : If Mem.Z(iCond, WWW) <= 0 Then RifaiInt = 8 : Exit Function
                End If
                If pt_Config.Rear = 1 Then
                    WWW = 259 'amm compr mantello nuovo
                    If Mem.Z(iCond, WWW) >= 0 Then
                        Mem.Z(iCond, WWW) = 0
                        Call LeggiSigma(1) : If Mem.Z(iCond, WWW) = 0 Then RifaiInt = 9999 : Exit Function
                    End If
                    WWW = 260 'amm compr mantello corroso
                    If Mem.Z(iCond, WWW) >= 0 Then
                        Mem.Z(iCond, WWW) = 0
                        Call LeggiSigma(1) : If Mem.Z(iCond, WWW) = 0 Then RifaiInt = 9999 : Exit Function
                    End If
                End If
                If Mem.Z(iCond, 26) > 0 And pt_Config.Rear = 1 Then 'c'Š il dilatatore
                    WWW = 287
                    Mem.Z(iCond, WWW) = 0
                    Call LeggiTab(1)
                    WWW = 274
                    Mem.Z(iCond, WWW) = 0
                    If pt_Config.TipoDilat < 7 Then
                        Call LeggiSigma(1) : If Mem.Z(iCond, WWW) <= 0 Then RifaiInt = 15 : Exit Function
                    End If
                    If Not OptimDil Then
                        If pt_Config.TipoDilat < 7 Then
                            WWW = 26
                            Mem.Z(iCond, WWW) = 0
                            Call objDilat.LeggiDilat(1, WWW, pt_Config.TipoDilat, pt_Config.SoloDilat)
                        End If
                    End If
                    WWW = 36
                    If pt_Config.TipoDilat < 7 Then
                        Mem.Z(iCond, WWW) = 0
                        Call objDilat.LeggiDilat(1, WWW, pt_Config.TipoDilat, pt_Config.SoloDilat) : If Mem.Z(iCond, WWW) <= 0 Then RifaiInt = 34 : Exit Function
                        If Mem.Z(iCond, WWW) <= 0 And Mem.Z(iCond, 287) <= 0 Then RifaiInt = 16 : Exit Function
                    End If
                    If pt_Config.TipoDilat > 2 And pt_Config.TipoDilat < 6 Then
                        WWW = 275
                        Mem.Z(iCond, WWW) = 0
                        Call LeggiSigma(1) : If Mem.Z(iCond, WWW) <= 0 Then RifaiInt = 17 : Exit Function
                        WWW = 276
                        Mem.Z(iCond, WWW) = 0
                        Call LeggiSigma(1) : If Mem.Z(iCond, WWW) <= 0 Then RifaiInt = 18 : Exit Function
                        If pt_Config.TipoDilat > 3 And pt_Config.TipoDilat < 6 Then
                            WWW = 277
                            Mem.Z(iCond, WWW) = 0
                            Call LeggiTab(1) : If Mem.Z(iCond, WWW) <= 0 Then RifaiInt = 19 : Exit Function
                            Mem.Z(iCond, WWW) = 0
                            WWW = 278
                            Mem.Z(iCond, WWW) = 0
                            Call LeggiSigma(1) : If Mem.Z(iCond, WWW) <= 0 Then RifaiInt = 20 : Exit Function
                            If pt_Config.TipoDilat > 4 And pt_Config.TipoDilat < 6 Then
                                WWW = 279
                                Mem.Z(iCond, WWW) = 0
                                Call LeggiTab(1) : If Mem.Z(iCond, WWW) <= 0 Then RifaiInt = 21 : Exit Function
                                WWW = 280
                                Mem.Z(iCond, WWW) = 0
                                Call LeggiSigma(1) : If Mem.Z(iCond, WWW) <= 0 Then RifaiInt = 22 : Exit Function
                            End If
                        End If
                    End If
                End If
            End If
        End With
    End Function
    Private Sub SintesiSp()
        Dim Rtf, Nulla As String
        Dim ifl As Short
        Dim iStart, iEnd As Short
        Dim Rig, Rig1 As String
        Dim Thkk, ThkExt As Single
        Dim Piastra As String = ""
        Dim k, i, j, indice As Short
        Dim l As Short
        Dim IndVar(2) As Short
        Dim Nome As String
        Offset = 0
        Call ValoriPiastra(Thkk, ThkExt, Piastra)
        Rtf = "\RTF" : Nulla = "\par "
        iStart = 1 : iEnd = Mem.Z(1, 261) : If iEnd > 4 Then iEnd = 4
RifSp:  ifl = FreeFile()
        Nome = RTrim(Monitor.Motore.Inizio.Archdir) & Rtf & "\SINTSTA.FTC"
        If Not OpenFile(Nome, ifl) Then Exit Sub
        Rig = LineInput(ifl)
        With Monitor.Motore.Problem
            Contarig = Contarig + 1 : .Printa("  " & Rig)
            Rig = LineInput(ifl)
            If pt_Config.Flangiata(pt_Config.Side - 1) <> 0 Then
                Mid(Rig, 47, 16) = "(Ext.:###.## mm)"
                Contarig = Contarig + 1 : .Printa("  " & GlobalRoutines.FormatS(Rig, Thkk, ThkExt, Piastra))
            Else
                Contarig = Contarig + 1 : .Printa("  " & GlobalRoutines.FormatS(Rig, Thkk, Piastra))
            End If
            Rig = LineInput(ifl)
            Contarig = Contarig + 1 : .Printa("  " & Rig)
            '---------------------------------------------
            Rig = LineInput(ifl)
            .Print("  " & Left(Rig, 23))
            For i = iStart To iEnd
                Rig1 = Mid(Rig, 24 + 2 * (i - iStart) * 7, 7)
                .Printa(GlobalRoutines.FormatS(Rig1, i))
                Rig1 = Mid(Rig, 24 + (2 * (i - iStart) + 1) * 7, 7)
                .Printa(GlobalRoutines.FormatS(Rig1, i))
            Next
            CompletaSp()
            '---------------------------------------
            Rig = LineInput(ifl)
            Contarig = Contarig + 1 : .Printa("  " & Rig)
            Rig = LineInput(ifl)
            Contarig = Contarig + 1 : .Printa("  " & Rig)
            '----------------------------------------------------
            For j = 1 To 15
                Input(ifl, Rig)
                Input(ifl, IndVar(1))
                Input(ifl, IndVar(2))
                If j <> 12 Or pt_Config.Flangiata(pt_Config.Side - 1) <> 0 Then
                    If j <> 13 Then
                        .Print("  " & Left(Rig, 23))
                        For i = iStart To iEnd
                            For k = 1 To 2
                                Rig1 = Mid(Rig, 24 + (2 * (i - iStart) + k - 1) * 7, 7)
                                .Printa(GlobalRoutines.FormatS(Rig1, Mem.Z(Offset + i, IndVar(k))))
                            Next k
                        Next i
                    Else
                        .Print("  " & Left(Rig, 23))
                        For i = iStart To iEnd
                            Select Case Problem(IndProbl).PDIFF
                                Case 1 : indice = 161 'no pdiff
                                Case Else : indice = 169
                            End Select
                            Rig1 = Mid(Rig, 24 + 2 * (i - iStart) * 7, 7)
                            .Printa(GlobalRoutines.FormatS(Rig1, Mem.Z(Offset + i, indice + 1)))
                            Rig1 = Mid(Rig, 24 + (2 * (i - iStart) + 1) * 7, 7)
                            .Printa(GlobalRoutines.FormatS(Rig1, Mem.Z(Offset + i, indice)))
                        Next
                    End If
                    CompletaSp()
                End If
            Next j
            '----------------------------------------------------
            Rig = LineInput(ifl)
            Contarig = Contarig + 1 : .Printa("  " & Rig)
            '----------------------------------------------------
            For l = 1 To 5
                For j = 1 To 2
                    Input(ifl, Rig)
                    Input(ifl, IndVar(1))
                    Input(ifl, IndVar(2))
                    .Print("  " & Left(Rig, 23))
                    For i = iStart To iEnd
                        For k = 1 To 2
                            Rig1 = Mid(Rig, 24 + (2 * (i - iStart) + k - 1) * 7, 7)
                            .Printa(GlobalRoutines.FormatS(Rig1, Mem.Z(Offset + i, IndVar(k))))
                        Next k
                    Next i
                    CompletaSp()
                Next j
                Rig = LineInput(ifl)
                Contarig = Contarig + 1 : .Printa("  " & Rig)
            Next l
        End With
        FileClose(ifl)
        If iEnd < Mem.Z(1, 261) Then
            iStart = 5 : iEnd = Mem.Z(1, 261)
            Call FinePag(1)
            GoTo RifSp
        End If
        Exit Sub
    End Sub
    Private Sub CompletaSp()
        Dim i As Integer
        If iEnd - iStart + 1 < 4 Then
            For i = 2 * (iEnd - iStart + 1) + 1 To 8
                Rig1 = Mid(Rig, 24 + (i - 1) * 7, 7)
                Call Pulisci(Rig1)
                Monitor.Motore.Problem.Print(Rig1)
            Next
            Contarig = Contarig + 1 : Monitor.Motore.Problem.Printa(Nulla)
        Else
            Contarig = Contarig + 1 : Monitor.Motore.Problem.Printa(Nulla)
        End If
    End Sub
    Private Sub StamMAWPFTC()
        Dim Stringa3(2) As String
        Dim ifl, i As Short
        Dim Stringa5(1) As String
        Dim Stringa4(3) As String
        Dim Stringa6(8) As String
        Dim Stringa7(1) As String
        Dim Nome As String
        Stringa6(0) = "Main flange bolts"
        Stringa6(1) = "TubeSheet stresses"
        Stringa6(2) = "Tubes in tension"
        Stringa6(3) = "Tubes in compression"
        Stringa6(4) = "Shell in tension"
        Stringa6(5) = "Shell in compression"
        Stringa6(6) = "Tube-to-TubeSheet joint load"
        Stringa6(7) = "Expansion joint primary stresses"
        If Not pt_Config.SoloDilat Then
            ifl = FreeFile()
            Nome = RTrim(Monitor.Motore.Inizio.Archdir) & "\RTF\STAMAW.FTC"
            If Not OpenFile(Nome, ifl) Then Exit Sub
            Call LegScr(ifl, False, Stringa3, Stringa4, Stringa5, Stringa6, Stringa7)
            FileClose(ifl)
        Else
            For i = 1 To 4
                Involucr(kLato, jInvolucr).MAWP(i - 1) = MAWP(i, kLato)
            Next
            StamMAWP(jInvolucr)
        End If
    End Sub
    Public Sub StampaSp()
        Dim ii, jj As Short
        Dim ifl As Short
        Dim i As Short
        Dim Nome As String
        Dim Avanz As Short
        Dim Ext1 As String = ""
        Dim Ext As String = ""
        Stringa3(1) = " NO" : Stringa3(2) = "YES" : Stringa3(0) = " NN"
        If InterrompiMAWP Then InterrompiMAWP = False : Exit Sub
        Stringa5(1) = "Fixed TubeSheets" : Stringa5(2) = "Floating head" : Stringa5(3) = "U-tube without extension"
        Stringa4(0) = "Flanged channel-side"
        Stringa4(1) = "Integral both sides"
        Stringa4(2) = "Flanged shell-side"
        Stringa4(3) = "Flanged both sides"
        'Stringa7$(1) = "Expanded with >=2 grooves"
        'Stringa7$(2) = "Expanded with 1 groove"
        'Stringa7$(3) = "Strongly expanded without grooves"
        'Stringa7$(4) = "Ligth expanded"
        ifl = FreeFile()
        Nome = RTrim(Monitor.Motore.Inizio.Archdir) & "\GIUNTO.DAT"
        If Not OpenFile(Nome, ifl) Then Exit Sub
        For i = 1 To 9 : Stringa6(i) = LineInput(ifl) : Next
        For i = 1 To 4 : Stringa7(i) = LineInput(ifl) : Next
        FileClose(ifl)
        '    Stringa6$(1) = "Welded with a>=1.4t"
        '    Stringa6$(2) = "Welded with t<=a<1.4t"
        '    Stringa6$(3) = "Tightening weld"
        '    Stringa6$(4) = "Brazed 100% examined"
        '    Stringa6$(5) = "Brazed <100% examined"
        '    Stringa6$(6) = "Expanded, with >=2 grooves"
        '    Stringa6$(7) = "Expanded, with 1  groove"
        '    Stringa6$(8) = "Expanded, without grooves"
        SaltaPag = True : Monitor.Motore.Problem.pag = 0
        iCond = 1
        ContaPag = 0 : Contarig = 0
        SetPiastra(1)
        If Not pt_Config.SoloDilat Then
            Select Case pt_Config.Rear
                Case 1 : Fascio = "Fascio a teste fisse"
                Case 2 : Fascio = "Fascio a testa flottante"
                Case 3 : Fascio = "Fascio ad U"
            End Select
            If Not ContinuoAuto Then Monitor.Motore.ProgrInizio("Preparazione stampa risultati fascio tubiero", "AsmeVip")
            Dim Titolo As String
            Select Case CalcoloInCorso
                Case 0 : Titolo = Involucr(kLato, jInvolucr).Mark.Trim + " (TEMA)"
                Case 1 : Titolo = Involucr(kLato, jInvolucr).Mark.Trim + " (UHX)"
            End Select
            If Not PrepRapp(Template, Fascio, Titolo, FileSt, mioApert.lstRapp) Then GoTo ExS
            If pt_Config.Differing = 2 And pt_Config.Rear = 1 Then
                FilePTF = RTrim(Monitor.Motore.Inizio.Archdir) & "\RTF\STAINP.FTC"
            ElseIf pt_Config.Differing = 3 And pt_Config.Rear = 1 Then
                ii = pt_Config.Flangiata(1 - 1) + 2 : jj = pt_Config.Flangiata(2 - 1) + 2 ' - 10 * ii%
                FilePTF = RTrim(Monitor.Motore.Inizio.Archdir) & "\RTF\SPD" & LTrim(Str(ii)) & LTrim(Str(jj)) & ".FTC"
            Else
                Select Case pt_Config.Rear
                    Case 1
                        Select Case CalcoloInCorso
                            Case 0 : FilePTF = RTrim(Monitor.Motore.Inizio.Archdir) & "\RTF\STAINPS.FTC"
                            Case 1
                                Padre.RulesAA.ResetAmm()
                                Select Case Padre.TipoAA
                                    Case 5 : FilePTF = RTrim(Monitor.Motore.Inizio.Archdir) & "\RTF\STAINPSAA1.FTC"
                                    Case 6 : FilePTF = RTrim(Monitor.Motore.Inizio.Archdir) & "\RTF\STAINPSAA2.FTC"
                                    Case Else
                                        MessageBox.Show("Tipo" & Str(Padre.TipoAA) & " non previsto in StampaSp")
                                        Exit Sub
                                End Select
                        End Select
                    Case 2
                        Select Case CalcoloInCorso
                            Case 0 : Ext = ".FTC"
                            Case 1 : Ext = "AA2.FTC"
                        End Select
                        Select Case pt_Config.Flottante
                            Case 1 'P - outside packed
                                FilePTF = RTrim(Monitor.Motore.Inizio.Archdir) & "\RTF\STAINPFP" & Ext
                            Case 2 'S - with back ring
                                FilePTF = RTrim(Monitor.Motore.Inizio.Archdir) & "\RTF\STAINPF" & Ext
                            Case 3 'T - flanged
                                FilePTF = RTrim(Monitor.Motore.Inizio.Archdir) & "\RTF\STAINPFT" & Ext
                            Case 4 'T - integral
                                FilePTF = RTrim(Monitor.Motore.Inizio.Archdir) & "\RTF\STAINPFTI" & Ext
                            Case 5 'W
                                FilePTF = RTrim(Monitor.Motore.Inizio.Archdir) & "\RTF\STAINPFW" & Ext
                        End Select
                    Case 3
                        If pt_Config.Gasketed(1 - 1) = 2 Then
                            FilePTF = RTrim(Monitor.Motore.Inizio.Archdir) & "\RTF\STAINPUbl.FTC"
                        Else
10703:                      FilePTF = RTrim(Monitor.Motore.Inizio.Archdir) & "\RTF\STAINPU.FTC"
                        End If
                End Select
            End If
            ifl = FreeFile()
            FileOpen(ifl, FilePTF, OpenMode.Input, , OpenShare.Shared)
10771:      Call LegScr(ifl, SaltaPag, Stringa3, Stringa4, Stringa5, Stringa6, Stringa7)
            FileClose(ifl)
            Avanz = 10
            If Not ContinuoAuto Then Monitor.Motore.Avanzamento = Avanz
            If pt_Config.Rear < 3 And (pt_Config.Flangiata(1 - 1) <> 0 Or (pt_Config.Flangiata(2 - 1) <> 0 And pt_Config.Differing > 1)) Then
                If CalcoloInCorso = 0 Then
                    If Not (Mem.Z(1, 288) = 0 And Mem.Z(1, 289) = 0 And pt_Config.Rear = 2) Then
                        If Not (Mem.Z(1, 32) = 0 And Mem.Z(1, 33) = 0 And Mem.Z(1, 269) = 0 And Mem.Z(1, 270) = 0 And pt_Config.Rear = 2) Then
                            FilePTF = RTrim(Monitor.Motore.Inizio.Archdir) & "\RTF\STAEXT.FTC"
                            FileOpen(ifl, FilePTF, OpenMode.Input, , OpenShare.Shared)
                            If pt_Config.Differing = 1 Then
                                For i = 1 To Mem.Z(1, 261)
                                    Mem.Z(i, 315) = Mem.Z(i, 292) : Mem.Z(i, 316) = Mem.Z(i, 293)
                                    Mem.Z(i, 291) = Mem.Z(i, 290) : Mem.Z(i, 320) = Mem.Z(i, 319)
                                Next
                            End If
                            Call LegScr(ifl, SaltaPag, Stringa3, Stringa4, Stringa5, Stringa6, Stringa7)
                            FileClose(ifl)
                        End If
                    End If
                End If
            End If
            Avanz = 20
            If Not ContinuoAuto Then Monitor.Motore.Avanzamento = Avanz
            If pt_Config.Rear = 1 Or pt_Config.Rear = 2 And CalcoloInCorso = 1 Then
                Select Case CalcoloInCorso
                    Case 0
                        If pt_Config.Differing < 2 Then FilePTF = "\PTFF02" Else FilePTF = "\PTFF22"
                        Ext = ".FTC"
                    Case 1
                        Select Case Padre.TipoAA
                            Case 5 : FilePTF = "\PTFF02AA1" 'ci sono i dati relativi al channel
                            Case 6 : FilePTF = "\PTFF02AA2" 'non ci sono
                            Case 101 : FilePTF = "\PTFF02AA1"
                            Case 102, 103 : FilePTF = "\PTFF02AA2"
                            Case 104 : FilePTF = "\PTFF02AA3" ' né channel né shell
                            Case 105, 106 : FilePTF = "\PTFF02AA4" 'senza shell
                            Case Else : FilePTF = ""
                        End Select
                        If Padre.TipoAA < 100 Then
                            Ext = "AA.FTC"
                            If UltimoAggiornamento > 2 Then Ext = "A02.FTC"
                        Else
                            Ext = "AAf.FTC"
                        End If
                End Select
                If Len(FilePTF) > 0 Then
                    If Mem.Z(1, 26) > 0 And pt_Config.Rear = 1 And CalcoloInCorso = 1 Then Ext1 = "d.FTC" Else Ext1 = ".FTC"
                    FilePTF = RTrim(Monitor.Motore.Inizio.Archdir) & "\RTF" & FilePTF & Ext1
337:                StampTab()
                    FilePTF = "\PTFF03" & Ext
                    If pt_Config.US = 0 Then
                        FilePTF = "\PTFF04" & Ext
                    End If
                    FilePTF = RTrim(Monitor.Motore.Inizio.Archdir) & "\RTF" & FilePTF
                    If pt_Config.Differing < 2 Then
                        SetPiastra(1)
                        StampTab()
                    Else
                        SetPiastra(1)
                        StampTab()
335:                    SwapPiastra()
                        SetPiastra(2)
336:                    StampTab()
                        SwapPiastra()
                    End If
                End If
            End If
        End If
        Avanz = 30
        If Not ContinuoAuto Then Monitor.Motore.Avanzamento = Avanz
        If Mem.Z(1, 26) > 0 And pt_Config.Rear = 1 Then
            If Not pt_Config.TipoDilat = 7 Then StampaDil(False)
        End If
        Avanz = 40
        SaltaPag = False
        If Config(0).CalcMAWP And (pt_Config.Rear = 1 Or pt_Config.Rear = 2 And CalcoloInCorso = 1) And InStr(mioRis.Risposta, "Non valido") = 0 Then Call StamMAWPFTC()
        If (Config(1).NMWDT > 0 Or Config(2).NMWDT > 0) Then
            Call Testatap()
            Call MinTempP()
        End If
        Avanz = 50
        If Not ContinuoAuto Then Monitor.Motore.Avanzamento = Avanz
        If pt_Config.Documented = 2 Then
            If pt_Config.Rear = 1 And Not pt_Config.SoloDilat Then
                'stampa documentata
                If pt_Config.Differing < 2 Then
                    StampaCompleta()
                    Avanz = 75
                    If Not ContinuoAuto Then Monitor.Motore.Avanzamento = Avanz
                Else
                    SetPiastra(1)
                    StampaCompleta()
                    SwapPiastra()
                    SetPiastra(2)
                    StampaCompleta()
                    SwapPiastra()
                End If
            ElseIf pt_Config.Rear = 2 Then
                SetPiastra(1)
                StampaCompletaF()
                Avanz = 75
                If Not ContinuoAuto Then Monitor.Motore.Avanzamento = Avanz
                ' SwapPiastra()
                SetPiastra(2)
                StampaCompletaF()
                ' SwapPiastra()
            End If
            Avanz = 90
            If Not ContinuoAuto Then Monitor.Motore.Avanzamento = Avanz
            If Mem.Z(1, 26) > 0 And pt_Config.Rear = 1 Then
                Select Case pt_Config.TipoDilat
                    Case 1, 2, 6
                        StampaCD1()
                    Case 3 : Dil = "\DIEJ03.FTC"
                        StampaCD2()
                    Case 4 : Dil = "\DIEJ04.FTC"
                        StampaCD2()
                    Case 5 : Dil = "\DIEJ05.FTC"
                        StampaCD2()
                End Select
            End If
        End If
ExS:
        If Not ContinuoAuto Then Monitor.Motore.ProgrAmmazza()
ExSub:
        Exit Sub
    End Sub
    Private Sub StampaCD1()
        Dim Num As String
        With Mem
            For iCond = 1 To .Z(1, 261)
                If .LoadCase = 2 And iCond <> .DimeCase Then GoTo Salto5
                ifl = FreeFile()
                For j = 1 To 10
                    If j < 5 Then
                        Num = "0" & LTrim(j.ToString)
                    ElseIf j > 5 Then
                        Num = "0" & LTrim(Str(j - 1))
                    Else
                        Num = "04" & Trim(Str(objDilat.prule8))
                    End If
                    FilePTF = RTrim(Monitor.Motore.Inizio.Archdir) & "\RTF\DILA" & Num & ".FTC"
346:                If Not OpenFile(FilePTF, ifl) Then Exit Sub
                    Call LegScr(ifl, SaltaPag, Stringa3, Stringa4, Stringa5, Stringa6, Stringa7)
                    FileClose(ifl)
                Next
Salto5:
            Next iCond
        End With
    End Sub
    Private Sub StampaCD2()
        For iCond = 1 To Mem.Z(1, 261)
            If Mem.LoadCase = 2 And iCond <> Mem.DimeCase Then GoTo Salto6
            ifl = FreeFile()
            FilePTF = RTrim(Monitor.Motore.Inizio.Archdir) & "\RTF" & Dil
347:        If Not OpenFile(FilePTF, ifl) Then Exit Sub
            Call LegScr(ifl, SaltaPag, Stringa3, Stringa4, Stringa5, Stringa6, Stringa7)
            FileClose(ifl)
Salto6:
        Next iCond
    End Sub
    Private Sub StampaCompletaF()
        Dim Apice As String
        Select Case CalcoloInCorso
            Case 0 'Ext = ".FTC"
                If Offset = 0 Then stamptrac() 'qui va la stampa della tracciatura
            Case 1 'Ext = "AA2.FTC"
                If UltimoAggiornamento = 3 Then
                    Apice = "2.FTC"
                ElseIf UltimoAggiornamento > 3 Then
                    If pt_Config.Side = 1 Then
                        Apice = "3F1.FTC"
                    Else
                        Apice = "3F2.FTC"
                    End If
                Else
                    Apice = ".FTC"
                End If
                FilePTF = "\RTF\FULL01AA" & Apice
                FileApri()
                Padre.RulesAA.StampaFl(iCond, Offset)
        End Select
    End Sub
    Private Sub SwapPiastra()
        Dim i, j As Integer
        For j = 1 To Mem.Z(1, 261)
            For i = 1 To 700
                Select Case i
                    Case 4, 7, 20, 17, 18, 22 To 24, 32 To 35, 261 To 270, 292, 293, 312, 313
                    Case Else
                        'If i = 385 Then Stop
                        GlobalRoutines.SWAP(Mem.Z(j + 8, i), Mem.Z(j, i))
                End Select
            Next
        Next
    End Sub
    Private Sub StampaCompleta()
        Dim Apice As String
        Dim i As Integer
        If Mem.DimeCase = 0 Then Mem.DimeCase = 1
        For iCond = 1 To Mem.Z(1, 261)
            If Mem.LoadCase = 2 And iCond <> Mem.DimeCase Then GoTo Salto4
            ifl = FreeFile()
            If CalcoloInCorso = 1 Then
                If UltimoAggiornamento = 3 Then
                    Apice = "2.FTC"
                ElseIf UltimoAggiornamento > 3 Then
                    If pt_Config.Side = 1 Then
                        Apice = "3.FTC"
                    Else
                        Apice = "32.FTC"
                    End If
                Else
                    Apice = ".FTC"
                End If
                FilePTF = "\RTF\FULL01AA" & Apice
                FileApri()
                FilePTF = "\RTF\FULL02AA" & Apice
                If UltimoAggiornamento = 3 And Padre.RulesAA.ThkAdjacent Then FilePTF = "\RTF\FULL02AA2s.FTC"
                If UltimoAggiornamento > 3 And Padre.RulesAA.ThkAdjacent Then FilePTF = "\RTF\FULL02AA3s.FTC"
                If IBW Then FilePTF = Left(FilePTF, Len(FilePTF) - 4) & "w.FTC"
                FileApri()
                FilePTF = "\RTF\FULL03AA" & Apice
                FileApri()
                If UltimoAggiornamento > 3 And Not RadialExp Then
                    FilePTF = "\RTF\FULL04AA3RE.ftc"
                Else
                    FilePTF = "\RTF\FULL04AA" & Apice
                End If
                FileApri()
                FilePTF = "\RTF\FULL05AA" & Apice
                FileApri()
                FilePTF = "\RTF\FULL06AA" & Apice
                FileApri()
                FilePTF = "\RTF\FULL07AA" & Apice
                FileApri()
                FilePTF = "\RTF\FULL08AA" & Apice
                FileApri()
                If UltimoAggiornamento > 2 Then
                    If Padre.TipoAA = 8 Then
                        For i = 1 To 32
                            Monitor.Motore.Problem.Print("\par ")
                        Next
                    End If
                    Padre.RulesAA.ContaPagAgg = 0
                    Padre.RulesAA.printAA359(1, iCond, 0)
                    Padre.RulesAA.printAA359(2, iCond, 0)
                    Padre.RulesAA.printPlast(iCond, Offset)
                Else
                    FilePTF = "\RTF\FULL09AA" & Apice
                    If UltimoAggiornamento = 2 Then FilePTF = "\RTF\FULL09AA02.FTC"
                    If Padre.TipoAA = 5 Then
                        FilePTF = "\RTF\FULL10AA" & Apice
                        If UltimoAggiornamento = 2 Then FilePTF = "\RTF\FULL10AA02.FTC"
                        FileApri()
                    End If
                    If Mem.Z(iCond, 8) > Mem.Z(iCond, 581) Or Padre.TipoAA = 5 And Mem.Z(iCond, 323) > Mem.Z(iCond, 582) Then
                        FilePTF = "\RTF\FULL11AA1" & Apice
                        FileApri()
                    Else
                        FilePTF = "\RTF\FULL11AA" & Apice
                        FileApri()
                    End If
                End If
            Else
                If Mem.Z(1, 307) > Mem.Z(1, 21) Then
                    If pt_Config.CalcFBM Then
                        Spec = "A"
                    Else
                        Spec = "B"
                    End If
                Else
                    Spec = ""
                End If
340:            If Problem(IndProbl).PDIFF = 1 Then
                    FilePTF = "\RTF\FULL01" & Spec & ".FTC"
                    FileApri()
                    If Spec = "B" Then
                        FilePTF = "\RTF\FULL02" & Spec & ".FTC"
                        FileApri()
                    Else
341:                    FilePTF = "\RTF\FULL021" & Spec & ".FTC"
                        FileApri()
                        FilePTF = "\RTF\FULL022" & Spec & ".FTC"
                        FileApri()
                    End If
                    FilePTF = "\RTF\FULL031.FTC"
                    FileApri()
                    FilePTF = "\RTF\FULL032.FTC"
                    FileApri()
                    FilePTF = "\RTF\FULL033.FTC"
                    FileApri()
342:                FilePTF = "\RTF\FULL041.FTC"
                    FileApri()
                    FilePTF = "\RTF\FULL042.FTC"
                    FileApri()
                    FilePTF = "\RTF\FULL043.FTC"
                    FileApri()
                    FilePTF = "\RTF\FULL05.FTC"
                    FileApri()
                    FilePTF = "\RTF\FULL061.FTC"
                    FileApri()
343:                FilePTF = "\RTF\FULL062.FTC"
                    FileApri()
                    FilePTF = "\RTF\FULL063.FTC"
                    FileApri()
                    FilePTF = "\RTF\FULL071.FTC"
                    FileApri()
                    FilePTF = "\RTF\FULL072.FTC"
                    FileApri()
                    FilePTF = "\RTF\FULL081.FTC"
                    FileApri()
344:                FilePTF = "\RTF\FULL082.FTC"
                    FileApri()
                Else
                    FilePTF = "\RTF\PDIF01" & Spec & ".FTC"
                    FileApri()
                    If Spec = "B" Then
                        FilePTF = "\RTF\FULL02" & Spec & ".FTC"
                        FileApri()
                    Else
                        FilePTF = "\RTF\FULL021" & Spec & ".FTC"
                        FileApri()
                        FilePTF = "\RTF\FULL022" & Spec & ".FTC"
                        FileApri()
                    End If
                    FilePTF = "\RTF\PDIF03.FTC"
                    FileApri()
                    FilePTF = "\RTF\PDIF04.FTC"
                    FileApri()
                    FilePTF = "\RTF\FULL061.FTC"
                    FileApri()
                    FilePTF = "\RTF\FULL062.FTC"
                    FileApri()
                    FilePTF = "\RTF\PDIF053.FTC"
                    FileApri()
                    FilePTF = "\RTF\FULL071.FTC"
                    FileApri()
                    FilePTF = "\RTF\PDIF062.FTC"
                    FileApri()
                    FilePTF = "\RTF\FULL081.FTC"
                    FileApri()
                    FilePTF = "\RTF\PDIF072.FTC"
                    FileApri()
                End If
            End If
Salto4:
        Next iCond
    End Sub
    Private Sub StampTab()
330:    Call FinePag(0)
        FileOpen(ifl, FilePTF, OpenMode.Input, , OpenShare.Shared)
        iCond = 1
        If objDilat Is Nothing Then objDilat = New wn_Dilat
        objDilat.Assumi(ifl)
        Contarig = 70
        If Mem.Z(1, 261) > 4 Then
            Call FinePag(3)
332:        FileClose(ifl)
            '                FilePTF = RTrim$(Monitor.Motore.inizio.ArchDir) + "\RTF" + FilePTF
            FileOpen(ifl, FilePTF, OpenMode.Input, , OpenShare.Shared)
            iCond = 5
333:        objDilat.Assumi(ifl)
            Contarig = 70
        End If
334:    FileClose(ifl)
    End Sub
    Private Function FileApri() As Boolean
        FilePTF = Trim(Monitor.Motore.Inizio.Archdir) & FilePTF
        Try
            FileOpen(ifl, FilePTF, OpenMode.Input, , OpenShare.Shared)
        Catch e As Exception
            MessageBox.Show("Errore durante l'apertura di " & FilePTF & vbCrLf & "Riportare questo errore al gruppo di sviluppo." & vbCrLf & Err.Description)
            Return False
        End Try
        Call LegScr(ifl, SaltaPag, Stringa3, Stringa4, Stringa5, Stringa6, Stringa7)
        FileClose(ifl)
        Return True
    End Function
    Sub Action1()
        Dim k, j As Short
        If pt_Config.Side < 1 And pt_Config.Differing > 1 Then SetPiastra(1)
2220:   If kkk = 0 Then
            If pt_Config.Rear = 1 Then Exit Sub
        End If
2260:   mioRis.ShowDialog()
        Select Case mioRis.Risposta 'Menua
            Case "F1" '27, 59: 'F1
                Chiave = 0 : Exit Sub
            Case "F2", "F3" '60, 61 'F2 F3
                If mioRis.Risposta = "F2" Then VERIFICA = 1 Else VERIFICA = 0
                If pagina > 1 Then
                    Globale = False
                Else
                    Globale = True : iCond = 1
                    THKPreced(1) = 0 : THKPreced(2) = 0
                    Call Espandi()
                End If
                Chiave = 2 : Exit Sub
            Case "F4" '62: 'F4
                If iCond > 1 Then
2592:               For k = 1 To 2
                        For j = 1 To 32
                            If IndVar(j, k) > 0 Then
                                Mem.Z(iCond, IndVar(j, k)) = Mem.Z(iCond - 1, IndVar(j, k))
                            End If
                        Next
                    Next
2593:               Chiave = 11 : Exit Sub
                Else
                    GoTo 2260
                End If
            Case "F8" '66: 'F8
2594:           Call LeggiTab(0) 'teste fisse
2595:           Call LeggiSigma(0)
                Exit Sub
            Case "F9" '67: 'F9
                pagina = 1 : iCond = 1
                Chiave = 11 : Exit Sub
            Case "F10" '68: 'F10
                If pt_Config.Rear = 3 Then
                ElseIf pt_Config.Differing < 2 Or pt_Config.Rear > 1 Or pt_Config.SoloDilat Then
                    If pt_Config.Rear = 1 Then
                        pagpiu()
                    Else
                        pagina = pt_Config.Side
                    End If
                Else
                    If pt_Config.Side < 2 And pagina > 1 Then
                        SetPiastra(2)
                    Else
                        SetPiastra(1)
                        pagpiu()
                    End If
                End If
                Chiave = 11 : Exit Sub
            Case CStr(75) : If iCol = 2 Then iCol = 1 : GoTo 2220 Else GoTo 2260 'sin
            Case CStr(77) : If iCol = 1 And IndVar(kkk, 2) > 0 Then iCol = 2 : GoTo 2220 Else GoTo 2260 'des
            Case Else : GoTo 2220
        End Select
        WWW = IndVar(kkk, iCol)
        If WWW = 10 Then pt_Config.Calc7133 = False
        If IndVar(kkk, 2) > 0 And iCol = 1 Then
            iCol = 2
            GoTo 2220
        End If
        iCol = 1
        GoTo 2220
    End Sub
    Private Sub pagpiu()
        If Mem.Z(1, 26) > 0 And pagina = 1 Then
            '                                Dilat(2).DilProg.Corr = Z(1, 19)
            '2598                            Call GeomDilat(Record(7).Dati())
            '2599                            Call GeomEquiv
        End If
        If (pt_Config.TipoDilat < 3 Or pt_Config.TipoDilat = 6) Or pagina = 1 Then
            pagina = pagina + 1
            paginaS = 0
        Else
            If paginaS = 1 Then paginaS = 0 : pagina = pagina + 1 Else paginaS = 1
        End If
    End Sub
    Sub Espandi()
        Try
            pagpag = "A"
            Call PagVideo(0)
            Esp()
            pagpag = "B"
            Call PagVideo(0)
            Esp()
            If pt_Config.Differing < 2 And pt_Config.Rear = 1 Or pt_Config.SoloDilat Then Exit Sub
            If pt_Config.Rear = 2 And CalcoloInCorso = 0 Then Exit Sub
            pagpag = "2"
            Call PagVideo(0)
            Esp()
        Catch e As Exception
            MessageBox.Show(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Private Sub Esp()
        Dim i, j, k As Integer
        For i = 1 To 32
            For j = 1 To Mem.Z(1, 261)
                For k = 1 To 2
                    If IndVar(i, k) > 0 And Not (IndVar(i, k) = 288) And Not (IndVar(i, k) = 289) And IndVar(i, k) < 800 Then
                        If j > 1 Then Mem.Z(j, IndVar(i, k)) = Mem.Z(1, IndVar(i, k))
                        Mem.Z(j + 8, IndVar(i, k)) = Mem.Z(1, IndVar(i, k))
                    End If
                Next k
            Next j
        Next i
        For i = 244 To 244 'amm.compr.tubi
            For j = 1 To Mem.Z(1, 261)
                If j > 1 Then Mem.Z(j, i) = Mem.Z(1, i)
                Mem.Z(j + 8, i) = Mem.Z(1, i)
            Next
        Next
        For i = 285 To 285 ' carico ammissibile giunto
            For j = 1 To Mem.Z(1, 261)
                If j > 1 Then Mem.Z(j, i) = Mem.Z(1, i)
                Mem.Z(j + 8, i) = Mem.Z(1, i)
            Next
        Next
        For i = 583 To 588
            For j = 1 To Mem.Z(1, 261)
                If j > 1 Then Mem.Z(j, i) = Mem.Z(1, i)
                Mem.Z(j + 8, i) = Mem.Z(1, i)
            Next
        Next
    End Sub
    Private Sub PagVideo(ByRef mode As Short)
        Dim i, kt As Short
        Dim tb As TabPage
        Try
            If Not mioRis.TabStrip1.SelectedTab Is Nothing Then
                kt = mioRis.TabStrip1.SelectedIndex
            End If
            LegPagina()
            If mode = 1 Then
                With mioRis
                    ._Label1_0.Visible = False
                    ._Label1_1.Visible = False
                    ._Text1_0.Visible = False
                    ._Text1_1.Visible = False
                    .Panel1.Visible = False
                    .TabStrip1.TabPages.Clear()
                    For i = 1 To Mem.Z(1, 261)
                        tb = New TabPage("Dati" & i.ToString)
                        tb.Tag = tb.Text
                        '   tb.Controls.Add(.Picture2)
                        .TabStrip1.TabPages.Add(tb)
                        tb = New TabPage("Altri D." & i.ToString)
                        tb.Tag = tb.Text
                        '  tb.Controls.Add(.Picture3)
                        .TabStrip1.TabPages.Add(tb)
                    Next
                    tb = New TabPage("Sintesi")
                    tb.Tag = "Sint"
                    .TabStrip1.TabPages.Add(tb)
                    If Mem.Z(1, 261) > 4 Then
                        tb.Text = "Sintesi 1-4"
                        tb = New TabPage("Sintesi 5-" & Trim(Str(Int(Mem.Z(1, 261)))))
                        tb.Tag = "Sint2"
                        .TabStrip1.TabPages.Add(tb)
                    End If
                    If pt_Config.SoloDilat Then
                        For i = 1 To Mem.Z(1, 261)
                            tb = New TabPage("Ris." & i.ToString)
                            tb.Tag = "Ris" & i.ToString
                            .TabStrip1.TabPages.Add(tb)
                        Next
                    Else
                        If pt_Config.TipoDilat <> 7 And Mem.Z(1, 26) > 0 And pt_Config.Rear = 1 Then
                            tb = New TabPage("SintDil")
                            tb.Tag = "SiDi"
                            .TabStrip1.TabPages.Add(tb)
                            If Mem.Z(1, 261) > 4 Then
                                tb.Text = "SintDil 1-4"
                                tb = New TabPage("SintDil 5-" & Trim(Str(Int(Mem.Z(1, 261)))))
                                tb.Tag = "SiDi2"
                                .TabStrip1.TabPages.Add(tb)
                            End If
                        End If
                        For i = 1 To Mem.Z(1, 261)
                            tb = New TabPage("Piastra" & i.ToString)
                            tb.Tag = "Ris" & i.ToString
                            .TabStrip1.TabPages.Add(tb)
                        Next
                        If pt_Config.Rear = 1 Then
                            For i = 1 To Mem.Z(1, 261)
                                tb = New TabPage("Mant." & i.ToString)
                                tb.Tag = "Man" & i.ToString
                                .TabStrip1.TabPages.Add(tb)
                            Next
                        End If
                        If Mem.Z(1, 26) > 0 And pt_Config.Rear = 1 And pt_Config.TipoDilat < 7 Then
                            For i = 1 To Mem.Z(1, 261)
                                tb = New TabPage("Dilat." & i.ToString)
                                tb.Tag = "Giu" & i.ToString
                                .TabStrip1.TabPages.Add(tb)
                            Next
                        End If
                    End If
                    .TabStrip1.Visible = True
                    .TabStrip1.SelectedTab = .TabStrip1.TabPages(0)
                    Try
                        If kt > 0 Then
                            .TabStrip1.SelectedTab = .TabStrip1.TabPages(kt - 1)
                            .TabStrip1_ClickEvent(mioRis.TabStrip1, New System.EventArgs)
                        End If
                    Catch e As Exception
                        .TabStrip1.SelectedTab = .TabStrip1.TabPages(0)
                    End Try
                    If ContinuoAuto Then
                        .Command1_Click(mioRis.Command1, New System.EventArgs)
                    Else
                        '    .Chiusa = False
                        .ShowDialog()
                        '     Do
                        '     System.Windows.Forms.Application.DoEvents()
                        '     If Not .Visible Then Exit Do
                        '     Loop Until .Chiusa
                    End If
                End With
            End If
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Public Sub RefreshVideo(ByRef iPag As Short)
        Dim i As Short
        If iPag > 0 Then iCond = iPag : pagina = iCond + 1
        SetPag()
        LegPagina()
        With mioRis
            .ResetBoxes()
            If pagpag = "4" Or pagpag = "5" Then
                .Descrizione(16).Visible = False : .Dimensioni(16).Visible = False : .Valore(16).Visible = False
                .Dimensioni(0).Visible = False
                .Valore(0).Width = .Valore(16).Left + .Valore(16).Width - .Valore(0).Left
                .Descrizione(0).Text = "Condizione"
                .Valore(0).Text = Mem.Condizio(iCond)
                .Valore(0).Tag = "Cond"
                .HelpProvider1.SetHelpNavigator(.Valore(0), HelpNavigator.Topic)
                .HelpProvider1.SetHelpKeyword(.Valore(0), Monitor.HelpTopic(IDH_XR_BASECONDIZIONE))
                .HelpProvider1.SetShowHelp(.Valore(0), True)
                .HelpProvider1.SetHelpNavigator(.Descrizione(0), HelpNavigator.Topic)
                .HelpProvider1.SetHelpKeyword(.Descrizione(0), Monitor.HelpTopic(IDH_XR_BASECONDIZIONE))
                .HelpProvider1.SetShowHelp(.Descrizione(0), True)
            Else
                If Not .AltriDati Then
                    .Descrizione(16).Visible = True : .Dimensioni(16).Visible = False : .Valore(16).Visible = True
                    .Dimensioni(0).Visible = False
                    .Valore(16).Width = .Valore(16).Width / 2
                    .Valore(16).Left = .Valore(16).Left + .Valore(16).Width
                    .Descrizione(16).Width = .Descrizione(16).Width / 2
                    .Descrizione(16).Left = .Valore(16).Left - .Descrizione(16).Width
                    .Valore(0).Width = .Descrizione(16).Left - .Valore(0).Left + .Dimensioni(0).Width
                    .Valore(0).Left = .Valore(0).Left - .Dimensioni(0).Width
                    .Descrizione(0).Text = "Condizione"
                    .Valore(0).Text = Mem.Condizio(iCond)
                    .Valore(0).Tag = "Cond"
                    .Descrizione(16).Text = "N° eventi"
                    .Valore(16).Text = Str(Mem.Neventi(iCond))
                    .Valore(16).Tag = "Even"
                    .HelpProvider1.SetHelpNavigator(.Valore(16), HelpNavigator.Topic)
                    .HelpProvider1.SetHelpKeyword(.Valore(16), Monitor.HelpTopic(IDH_XR_BASEEVENTI))
                    .HelpProvider1.SetShowHelp(.Valore(16), True)
                    .HelpProvider1.SetHelpNavigator(.Descrizione(16), HelpNavigator.Topic)
                    .HelpProvider1.SetHelpKeyword(.Descrizione(16), Monitor.HelpTopic(IDH_XR_BASEEVENTI))
                    .HelpProvider1.SetShowHelp(.Descrizione(16), True)
                End If
            End If
            iAggiustaC = 0
            If Not .AltriDati Then
                For i = 1 To FFF
                    If IndVar(i, 1) <> 0 Or IndVar(i, 2) <> 0 Then
                        AggiustaC((i))
                    End If
                Next
            Else
                For i = 17 To 16 + FFF
                    If IndVar(i, 1) <> 0 Or IndVar(i, 2) <> 0 Then
                        AggiustaC((i))
                    End If
                Next
            End If
            Visibili()
        End With
    End Sub
    Public Sub Pulisci(ByRef Rig1 As String)
        Dim Car As String
        Dim ll As Short
        For ll = 1 To Len(Rig1)
            Car = Mid(Rig1, ll, 1)
            If Car = "#" Or Car = "." Or Car = gstrSEP_DIR Then Mid(Rig1, ll, 1) = " "
        Next
    End Sub
    Private Function SelAction(Optional ByRef c As Single = -9999) As Short
        Dim Res As Short
        Dim k As String = ""
        mioRis.TabStrip1.Visible = False
        mioRis.Picture2.Visible = False
        If Not c = -9999 Then Chiave = c
        If Chiave < 2 Then
            If pt_Config.Differing < 1 Or pt_Config.Differing > 3 Or pt_Config.Square < 1 Or pt_Config.Square > 2 Or pt_Config.Rear < 1 Or pt_Config.Rear > 3 Then
                ' Res = DatiContrP
            End If
        End If
        Do
            Select Case Chiave
                Case 0 : Exit Function
                Case 1
                    'inizio programma richiesta dati di input
1850:               pagina = 1
                    If Mem.Z(1, 261) = 0 Then Mem.Z(1, 261) = 1
                    Chiave = 11
                Case 5
                    '   Call ApriScriviP
                    Chiave = 1
                Case 6
                    '   Res% = ApriLeggiP
                    Chiave = 1
                Case 11
2020:               Call SetPagFix()
                    iCol = 1
                    Chiave = 12
                Case 12
2225:               Call Action1()
                    ' Stop
                Case 2
2227:               Res = Esegui()
                    Select Case Res
                        Case 3 : Chiave = 1 'dati incompleti
                        Case Is < 0 ' GOTO 3630      'problemi con le tabelle
                            Chiave = 0
                            Call WarnT(Res)
                            SelAction = Res
                        Case 0
                            If pt_Config.SoloDilat Then
2229:                           Call SuperAxial()
                                Chiave = 1 : If icMAWP > 0 Then Chiave = 0
                            Else
                                If Not (pt_Config.Rear = 1 Or pt_Config.Rear = 2 And CalcoloInCorso = 1) Then
                                    Chiave = 0
7570:                           ElseIf Globale Or icMAWP > 0 Then
                                    Call SuperAxial()
                                    If icMAWP > 0 Then Chiave = 0
                                Else
Rifa:                               '     Do
                                    '        k$ = INKEY$
                                    '     Loop While Len(k$) < 2
7575:                               '     k$ = Right$(k$, 1)
                                    Select Case Asc(k) 'Menub
                                        Case 59 'F1
                                            Chiave = 0
                                        Case 63 'F5
                                            Chiave = 5
                                        Case 64 'F6
                                            If pagina = 1 Then
                                                Chiave = 6
                                            Else
                                                GoTo Rifa
                                            End If
                                        Case 66 'F8
7620:                                       Call SuperAxial() ': RETURN 1850
                                        Case 67 'F9
                                            If pagina > 1 Then
                                                pagina = 1 : iCond = 1
                                                Chiave = 11
                                            Else
                                                GoTo Rifa
                                            End If
                                        Case 68 'F10
                                            If iCond < Mem.Z(1, 261) Or pagina = 1 And pt_Config.Rear < 3 Then
                                                pagina = iCond + 1
                                                Chiave = 11
                                            Else
                                                GoTo Rifa
                                            End If
                                        Case Else : GoTo Rifa
                                    End Select
                                End If
                            End If
                    End Select
            End Select
        Loop
    End Function
    Public Sub SetPagFix()
        Dim Ncond, ii As Short
        Dim Salva1(2, 320) As Single
        Dim cc, Cm, Cd As Single
        Dim Pd, Pm, Pc As Single
        Dim TP, Tm, Ttub, TpB As Single
        Dim TPD, TmD, TtubD, TpBD As Single
        Dim am1, am2 As Single
        Dim Condiz As String
        Dim Events As Short
        Try
            With Mem
                If .Z(1, 261) = 0 Then .Z(1, 261) = 1
                If Not VerificandoPI Then
                    Call Espandi()
                Else
                    Ncond = .Z(1, 261) : Condiz = .Condizio(1) : Events = .Neventi(1)
                    Cm = .Z(1, 17) : cc = .Z(1, 18) : Cd = .Z(1, 19)
                    Pm = .Z(1, 1) : Pc = .Z(1, 2) : Pd = .Z(1, 3)
                    Tm = .Z(1, 5) : Ttub = .Z(1, 6) : TP = .Z(1, 4) : TpB = .Z(1, 268)
                    TmD = .Z(1, 777) : TtubD = .Z(1, 764) : TPD = .Z(1, 747) : TpBD = .Z(9, 747)
                    am1 = .Z(1, 32) : am2 = .Z(1, 33)
                    For ii = 1 To 320
                        Salva1(1, ii) = .Z(1, ii)
                        Salva1(2, ii) = .Z(1 + 8, ii)
                    Next
                    .Z(1, 12) = .Z(1, 631) : .Z(1, 13) = .Z(1, 632) 'ammiss mant.tubi
                    .Z(1, 35) = .Z(1, 629) : .Z(1, 266) = .Z(1, 630)
                    .Z(1, 1) = Config(1).pxTest
                    .Z(1, 2) = Config(2).pxTest
                    '             --------------------------------
                    .Z(1, 261) = 1
                    .Z(1, 17) = 0 : .Z(1, 18) = 0 : .Z(1, 19) = 0
                    .Z(1, 5) = 20 : .Z(1, 6) = 20
                    .Z(1, 4) = 20 : .Z(1, 268) = 20
                    .Z(1, 777) = 20 : .Z(1, 764) = 20
                    .Z(1, 747) = 20 : .Z(9, 747) = 20
                    .Condizio(1) = "Verifica in prova idraulica"
                    .Neventi(1) = 1 : iCond = 1
                End If
                If pagina < 2 Then pagina = 2
                If pagina > .Z(1, 261) + 1 Then pagina = .Z(1, 261) + 1
                SetPag()
                iCond = pagina - 1
                Call PagVideo(1)
                If VerificandoPI Then
                    .Z(1, 261) = Ncond
                    .Z(1, 32) = am1 : .Z(1, 33) = am2
                    .Z(1, 17) = Cm : .Z(1, 18) = cc : .Z(1, 19) = Cd
                    .Z(1, 1) = Pm : .Z(1, 2) = Pc
                    .Z(1, 5) = Tm : .Z(1, 6) = Ttub : .Z(1, 4) = TP : .Z(1, 268) = TpB
                    .Z(1, 777) = TmD : .Z(1, 764) = TtubD : .Z(1, 747) = TPD : .Z(9, 747) = TpBD
                    For ii = 1 To 320
                        .Z(1, ii) = Salva1(1, ii)
                        .Z(1 + 8, ii) = Salva1(2, ii)
                    Next
                End If
            End With
        Catch e As Exception
            MessageBox.Show(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Public Sub Sintesi(ByRef Caso As Short)
        Dim thk, ThkExt As Single
        Dim l, indice, i, j As Short
        Dim k, iColor As Short
        Dim IndVar(2, 2) As Short
        Dim Rig2(2) As String
        Dim Riga2, Testo As String
        Dim NonDet As Boolean
        Dim factPrim, StressMant, factSecond As Single
        Dim AmmissMant As Single
        Dim kCorr, nDati As Short
        Dim NomFile As String
        GlobalRoutines.FormatS("non|")
        With mioRis
            AltezzaRiga = .mygraphics.MeasureString("M", .myfont).Height
            iStart = iStartSint : iEnd = Mem.Z(1, 261) : If iEnd > 4 And iStartSint = 1 Then iEnd = 4
            'Offset = 0
            thk = Mem.Z(1, 34)
            If pt_Config.Differing > 1 Then
                If pt_Config.Side = 1 Then
                    thk = Mem.Z(1, 34)
                    ThkExt = Mem.Z(1, 288)
                Else
                    thk = Mem.Z(1, 262)
                    ThkExt = Mem.Z(1, 289)
                End If
            Else
                thk = Mem.Z(1, 34) : ThkExt = Mem.Z(1, 288)
            End If
Rif:        .Rinnova()
            .TabStrip1.SelectedTab.Tag = setmiotag(.TabStrip1.SelectedTab.Tag, "No", 1)
            ifl = FreeFile()
            Select Case Caso
                Case 0
                    If CalcoloInCorso = 0 Then
                        nDati = 5
                        NomFile = RTrim(Monitor.Motore.Inizio.Archdir) & "\WN5\SINTESI.FTC"
                    Else
                        If UltimoAggiornamento > 2 Then
                            nDati = 10
                            NomFile = RTrim(Monitor.Motore.Inizio.Archdir) & "\WN5\SINTESIF2.FTC"
                        Else
                            nDati = 7
                            NomFile = RTrim(Monitor.Motore.Inizio.Archdir) & "\WN5\SINTESIF.FTC"
                        End If
                    End If
                    If Not OpenFile(NomFile, ifl) Then Exit Sub
                Case 1
                    NomFile = RTrim(Monitor.Motore.Inizio.Archdir) & "\WN5\SINTESJ.FTC"
                    If Not OpenFile(NomFile, ifl) Then Exit Sub
            End Select
            Rig = LineInput(ifl)
            .mygraphics.DrawString(Rig, .myfont, .mybrush, .x, .y)
            .y = .y + AltezzaRiga
            Rig = LineInput(ifl)
            Select Case Caso
                Case 0
                    .mygraphics.DrawString(GlobalRoutines.FormatS(Rig, thk * kLength, UnitLength), .myfont, .mybrush, .x, .y)
                    If pt_Config.Flangiata(pt_Config.Side - 1) <> 0 Then
                        .Scrivi(GlobalRoutines.FormatS("|" & New String(" ", 60) & "(Est.:###.## \  \) |", ThkExt * kLength, UnitLength), .x, .y)
                    End If
                    .y = .y + AltezzaRiga
                Case 1
                    .mygraphics.DrawString(Rig, .myfont, .mybrush, .x, .y)
                    .y = .y + AltezzaRiga
            End Select
            Rig = LineInput(ifl)
            .mygraphics.DrawString(Rig, .myfont, .mybrush, .x, .y)
            .y = .y + AltezzaRiga
            '---------------------------------------------
            Rig = LineInput(ifl)
            Select Case Caso
                Case 0
                    Testo = Rig.Substring(0, 23)
                    .mygraphics.DrawString(Testo, .myfont, .mybrush, .x, .y)
                    .x = .MisuraStringa(Testo).Width
                    For i = iStart To iEnd
                        Rig1 = Mid(Rig, 24 + 2 * (i - iStart) * 7, 7)
                        Testo = GlobalRoutines.FormatS(Rig1, i)
                        .mygraphics.DrawString(Testo, .myfont, .mybrush, .x, .y)
                        .x += .MisuraStringa(Testo).Width
                        Rig1 = Mid(Rig, 24 + (2 * (i - iStart) + 1) * 7, 7)
                        Testo = GlobalRoutines.FormatS(Rig1, i)
                        .mygraphics.DrawString(Testo, .myfont, .mybrush, .x, .y)
                        .x += .MisuraStringa(Testo).Width
                    Next
                    Completa()
                Case 1
                    .mygraphics.DrawString(Rig, .myfont, .mybrush, .x, .y)
                    .y = .y + AltezzaRiga
            End Select
            .x = 0
            '---------------------------------------
            Rig = LineInput(ifl)
            .mygraphics.DrawString(Rig, .myfont, .mybrush, .x, .y)
            .y = .y + AltezzaRiga
            Rig = LineInput(ifl)
            .mygraphics.DrawString(Rig, .myfont, .mybrush, .x, .y)
            .y = .y + AltezzaRiga
            '----------------------------------------------------
            If nDati < 10 Then
                Rig = LineInput(ifl)
                Select Case Caso
                    Case 0
                        Testo = Rig.Substring(0, 23)
                        Testo = GlobalRoutines.FormatS(Testo, UnitLength)
                        .mygraphics.DrawString(Testo, .myfont, .mybrush, .x, .y)
                        .x = .MisuraStringa(Testo).Width
                        NonDet = False
                        If CalcoloInCorso = 1 Then
                            If Padre.TipoAA > 4 And Padre.RulesAA.hr = 0 Then NonDet = True
                        End If
                        If NonDet Then
                            Riga2 = "(N.D.)|"
                            For i = iStart To iEnd
                                .mygraphics.DrawString(Riga2, .myfont, .mybrush, .x, .y)
                                .x += .MisuraStringa(Riga2).Width
                                .mygraphics.DrawString(Riga2, .myfont, .mybrush, .x, .y)
                                .x += .MisuraStringa(Riga2).Width
                            Next
                        Else
                            For i = iStart To iEnd
                                Select Case Problem(IndProbl).PDIFF
                                    Case 1 : indice = 161 'no pdiff
                                    Case Else : indice = 169
                                End Select
                                Rig1 = Mid(Rig, 24 + 2 * (i - iStart) * 7, 7)
                                If Config(0).US > 1 Then Rig1 = "##.###|"
                                Riga2 = GlobalRoutines.FormatS(Rig1, Mem.Z(Offset + i, indice + 1))
                                .mygraphics.DrawString(Riga2, .myfont, .mybrush, .x, .y)
                                .x += .MisuraStringa(Riga2).Width
                                Rig1 = Mid(Rig, 24 + (2 * (i - iStart) + 1) * 7, 7)
                                Riga2 = GlobalRoutines.FormatS(Rig1, Mem.Z(Offset + i, indice))
                                .mygraphics.DrawString(Riga2, .myfont, .mybrush, .x, .y)
                                .x += .MisuraStringa(Riga2).Width
                            Next
                        End If
                        Completa()
                    Case 1
                        .mygraphics.DrawString(Rig, .myfont, .mybrush, .x, .y)
                        .y = .y + AltezzaRiga
                End Select
                '----------------------------------------------
                Rig = LineInput(ifl)
                .mygraphics.DrawString(Rig, .myfont, .mybrush, .x, .y)
                .y = .y + AltezzaRiga
            End If
            .x = 0
            '----------------------------------------------------
            Select Case Caso
                Case 0
                    Dim kUnit As Single
                    For l = 1 To nDati
                        If l < nDati Then kUnit = kPress Else kUnit = kForce
                        For j = 1 To 2
                            Input(ifl, Rig2(j))
                            Input(ifl, IndVar(1, j))
                            Input(ifl, IndVar(2, j))
                            Rig = Rig2(j)
                        Next
                        For j = 1 To 2
                            Testo = Rig2(j).Substring(0, 23)
                            If j = 1 Then
                                If l < nDati Then
                                    Testo = GlobalRoutines.FormatS(Testo, UnitPress)
                                Else
                                    Testo = GlobalRoutines.FormatS(Testo, UnitForce)
                                End If
                            End If
                            .mygraphics.DrawString(Testo, .myfont, .mybrush, .x, .y)
                            .x = .MisuraStringa(Testo).Width
                            For i = iStart To iEnd
                                If CalcoloInCorso = 0 Or l > 1 Or pt_Config.Rear = 2 Then
                                    For k = 1 To 2
                                        Rig1 = Mid(Rig2(j), 24 + (2 * (i - iStart) + k - 1) * 7, 7)
                                        If Config(0).US = 0 And l > nDati Then Mid(Rig1, 4, 1) = "."
                                        If j = 1 And System.Math.Abs(Mem.Z(Offset + i, IndVar(k, 1))) > System.Math.Abs(Mem.Z(Offset + i, IndVar(k, 2))) Then iColor = 1 Else iColor = 0
                                        Riga2 = GlobalRoutines.FormatS(Rig1, Mem.Z(Offset + i, IndVar(k, j)) * kUnit)
                                        If iColor = 1 Then
                                            .TabStrip1.SelectedTab.Tag = setmiotag(.TabStrip1.SelectedTab.Tag, "rosso", 1)
                                            .Scrivi(Riga2, , , 1, 1)
                                        Else
                                            .mygraphics.DrawString(Riga2, .myfont, .mybrush, .x, .y)
                                        End If
                                        .x += .MisuraStringa(Riga2).Width
                                    Next k
                                Else
                                    For k = 1 To 2
                                        If k = 1 Then kCorr = 1 Else kCorr = 0
                                        Rig1 = Mid(Rig2(j), 24 + (2 * (i - iStart) + k - 1) * 7, 7)
                                        If Config(0).US = 0 Then Mid(Rig1, 4, 1) = "."
                                        If j = 1 And nDati < 10 Then
                                            factPrim = System.Math.Abs(Mem.Z(Offset + i, 492 + kCorr) / Mem.Z(Offset + i, 496))
                                            factSecond = System.Math.Abs(Mem.Z(Offset + i, 494 + kCorr) / Mem.Z(Offset + i, 497))
                                            If factPrim > 1 Or factSecond > 1 Then iColor = 1 Else iColor = 0
                                            If factPrim > factSecond Then
                                                StressMant = Mem.Z(Offset + i, 492 + kCorr)
                                                AmmissMant = Mem.Z(Offset + i, 496)
                                            Else
                                                StressMant = Mem.Z(Offset + i, 494 + kCorr)
                                                AmmissMant = Mem.Z(Offset + i, 497)
                                            End If
                                        ElseIf nDati < 10 Then
                                            iColor = 0
                                        ElseIf j Mod 2 = 1 Then
                                            StressMant = Mem.Z(Offset + i, IndVar(k, j))
                                            AmmissMant = Mem.Z(Offset + i, IndVar(k, j + 1))
                                            factPrim = System.Math.Abs(StressMant / AmmissMant)
                                            If factPrim > 1 Then iColor = 1 Else iColor = 0
                                        Else
                                            iColor = 0
                                        End If
                                        If iColor = 1 Then
                                            .TabStrip1.SelectedTab.Tag = setmiotag(.TabStrip1.SelectedTab.Tag, "rosso", 1)
                                            .Scrivi(GlobalRoutines.FormatS(Rig1, StressMant * kUnit), , , 1, 1)
                                            .x += .MisuraStringa(Rig1).Width
                                        Else
                                            If j = 1 Then
                                                Riga2 = GlobalRoutines.FormatS(Rig1, StressMant * kUnit)
                                                .mygraphics.DrawString(Riga2, .myfont, .mybrush, .x, .y)
                                                .x += .MisuraStringa(Riga2).Width
                                            Else
                                                Riga2 = GlobalRoutines.FormatS(Rig1, AmmissMant * kUnit)
                                                .mygraphics.DrawString(Riga2, .myfont, .mybrush, .x, .y)
                                                .x += .MisuraStringa(Riga2).Width
                                            End If
                                        End If
                                    Next k
                                End If
                            Next i
                            Completa()
                        Next j
                        If nDati < 10 Then
                            Rig = LineInput(ifl)
                            .mygraphics.DrawString(Rig, .myfont, .mybrush, .x, .y)
                            .y = .y + AltezzaRiga
                            .x = 0
                        End If
                    Next l
                Case 1
                    For l = 1 To 15
                        Rig = LineInput(ifl)
                        .mygraphics.DrawString(Rig, .myfont, .mybrush, .x, .y)
                        .y = .y + AltezzaRiga
                    Next l
            End Select
            If nDati = 10 Then
                Rig = LineInput(ifl)
                .mygraphics.DrawString(Rig, .myfont, .mybrush, .x, .y)
                .y = .y + AltezzaRiga
            End If
            FileClose(ifl)
            If pt_Config.Differing > 1 Or pt_Config.Rear = 2 Then
                .Command4.Visible = True
                ' frmRis.Command4.Left = 64 - frmRis.cmdFattUs.Width
                If pt_Config.Side = 1 Then
                    .Scrivi(rmHelpStrings.GetString("PIASTRA_A"), 1, 63)
                    .Command4.Text = rmHelpStrings.GetString("vedi_LATO_B")
                Else
                    .Scrivi(rmHelpStrings.GetString("PIASTRA_B"), 1, 63)
                    .Command4.Text = rmHelpStrings.GetString("vedi_LATO_A")
                End If
            Else
                .Command4.Visible = False
            End If
        End With
        Exit Sub
    End Sub
    Private Sub Completa()
        Dim i As Integer
        With mioRis
            If iEnd - iStart + 1 < 4 Then
                For i = 2 * (iEnd - iStart + 1) + 1 To 8
                    Rig1 = Mid(Rig, 24 + (i - 1) * 7, 7)
                    Call Pulisci(Rig1)
                    .mygraphics.DrawString(Rig1, .myfont, .mybrush, .x, .y)
                    .x += .MisuraStringa(Rig1).Width
                Next
            End If
            .y = .y + AltezzaRiga
            .x = 0
        End With
    End Sub
    Private Function ContInput() As Short
        Dim i As Short
        Dim Log1, Log2 As Boolean
        Dim Log5, Log3, Log4 As Boolean
        Dim Log7, Log8, Log9 As Boolean
        ContInput = 0
        With Mem
            Problem(IndProbl).TSheDes = .Z(1, 307 + pt_Config.Side)
            If pt_Config.Gasketed(pt_Config.Side - 1) < 1 And Problem(IndProbl).TSheDes <= 0.0# And pt_Config.Flangiata(pt_Config.Side - 1) <> 0 And pt_Config.Differing < 3 And Not pt_Config.SoloDilat Then
                '        IF pt_Config.Differing = 2 THEN
                '-----------------------provvisorio
                '        .Z(1, 308) = 1710
                '        Problem(IndObj).TSheDes = 1710
                '------------------------------
                '        ELSE
                ContInput = -100 : Exit Function
                '        END IF
            End If
            'controllo input
            SetPiastra(pt_Config.Side)
            If VerificandoPI Then
                Ps = Problem(IndProbl).PHTShel
                PT = Problem(IndProbl).PHTChan
                PDE = Problem(IndProbl).DiffPressHT
            Else
                Ps = .Z(iCond, 1)
                PT = .Z(iCond, 2)
                PDE = .Z(iCond, 3)
                If PDE = 0 Then PDE = System.Math.Abs(Ps - PT) : .Z(iCond, 3) = PDE
            End If
            CercaTubi()
            .Z(iCond, 761) = Involucr(3, iTubi).cs
            xs = .Z(iCond, 5)
            xt = .Z(iCond, 6)
            ES = .Z(iCond, 8)
            Et = .Z(iCond, 9)
            DL = .Z(iCond, 10)
            PA = .Z(iCond, 11)
            SAS = .Z(iCond, 12)
            SAT = .Z(iCond, 13)
            ASS = .Z(iCond, 14)
            AT = .Z(iCond, 15)
            '
            CJ = .Z(iCond, 19)
            Ds = .Z(iCond, 21)
            DC = .Z(iCond, 22)
            ts = .Z(iCond, 23)
            tc = .Z(iCond, 24)
            '
            DJ = .Z(iCond, 26)
            DOO = .Z(iCond, 27)
            tt = .Z(iCond, 28)
            Nptf = .Z(iCond, 29)
            LT = .Z(iCond, 30)
            If pt_Config.Side = 1 Then
                M1ptf = .Z(iCond, 32) ' * Braccio(1)
                M2ptf = .Z(iCond, 33) ' * Braccio(1)
            End If
            thk = .Z(1, 34)
            Sj = .Z(iCond, 36)
            SJC = .Z(iCond, 37)
            sY = .Z(iCond, 38)
            KL = .Z(iCond, 39)
            GUARS = .Z(iCond, 292)
            GUARC = .Z(iCond, 293)
            If pt_Config.Side = 2 Then
                XP = .Z(iCond, 268)
                cs = .Z(iCond, 264)
                CT = .Z(iCond, 265)
                '.Z(1, 263) = 0
                Cptf = .Z(iCond, 263)
                If VerificandoPI Then
                    Sptf = .Z(iCond, 630)
                Else
                    Sptf = .Z(iCond, 266)
                End If
                Eptf = .Z(iCond, 267)
                .Z(iCond + 8, 4) = XP
                .Z(iCond + 8, 17) = cs
                .Z(iCond + 8, 18) = CT
                .Z(iCond + 8, 20) = Cptf
                .Z(iCond + 8, 35) = Sptf
                .Z(iCond + 8, 7) = Eptf
                M1ptf = .Z(iCond, 269) '* Braccio(2)
                M2ptf = .Z(iCond, 270) '* Braccio(2)
                .Z(iCond + 8, 32) = .Z(iCond, 269)
                .Z(iCond + 8, 33) = .Z(iCond, 270)
                GUARS = .Z(iCond, 315)
                GUARC = .Z(iCond, 316)
                .Z(iCond + 8, 292) = GUARS
                .Z(iCond + 8, 293) = GUARC
                thk = .Z(1, 262)
                .Z(9, 34) = thk
                If pt_Config.Differing = 3 Or pt_Config.Differing = 2 And pt_Config.Rear = 2 Then
                    If .Z(1, 314) = 0 Then .Z(1, 314) = .Z(1, 21)
                    Ds = .Z(1, 314)
                    DC = .Z(1, 312)
                    tc = .Z(1, 313)
                    .Z(9, 21) = Ds
                    .Z(9, 22) = DC
                    .Z(9, 24) = tc
                End If
                If Eptf * Sptf = 0 And pt_Config.Rear = 1 Then ContInput = -101 : Exit Function
            Else
                XP = .Z(iCond, 4)
                cs = .Z(iCond, 17)
                CT = .Z(iCond, 18)
                Cptf = .Z(iCond, 20)
                If VerificandoPI Then
                    Sptf = .Z(iCond, 629)
                Else
                    Sptf = .Z(iCond, 35)
                End If
                Eptf = .Z(iCond, 7)
                M1ptf = .Z(iCond, 32) '* Braccio(1)
                M2ptf = .Z(iCond, 33) '* Braccio(1)
                thk = .Z(1, 34)
            End If
            If pt_Config.Rear < 3 Then
                For i = 1 To 39
                    '.Z(1, 20) = 0
                    If .Z(iCond, i) = 0 Then
                        Log1 = (i < 9 Or (i > 15 And i < 21) Or i = 24 Or i = 25 Or i = 26 Or (i > 30 And i < 35) Or i = 36 Or i = 37)
                        If i = 22 Or i = 23 And pt_Config.Rear = 1 And pt_Config.Flangiata(1 - 1) = -1 Then Log1 = True
                        Log2 = pt_Config.Rear = 2 And (i = 21 Or i = 22 Or i = 23) And pt_Config.Gasketed(1 - 1) <> 0 And pt_Config.Side = 1
                        Log4 = pt_Config.Rear = 2 And (i = 21 Or i = 22 Or i = 23) And pt_Config.Side = 2
                        Log3 = pt_Config.Rear = 2 And i = 29 And CalcoloInCorso = 0
                        Log5 = (pt_Config.Rear = 2 And (i = 39) And CalcoloInCorso = 0) 'lungh libera inflessione tubi
                        Log7 = (i = 10) And CalcoloInCorso = 1
                        Log8 = i = 12 And (CalcoloInCorso = 0 Or pt_Config.Flangiata(1 - 1) > 0 And pt_Config.Flangiata(2 - 1) > 0)
                        Log9 = pt_Config.Rear = 2 And (i = 14 Or i = 15)
                        If Not Log1 And Not (i = 32 Or i = 33) And Not Log2 And Not Log3 And Not Log4 And Not Log5 And Not Log7 And Not Log8 And Not Log9 Then
                            ContInput = -i : Exit Function
                        End If
                    End If
                Next i
                If pt_Config.Rear = 2 And pt_Config.Side = 2 And CalcoloInCorso = 0 Then
                    If DC = 0 And (pt_Config.Flottante = 4 Or pt_Config.Flottante = 1) Then ContInput = -314 : Exit Function
                End If
                If pt_Config.Rear = 2 And pt_Config.Side = 2 And CalcoloInCorso = 1 Then
                    If DC = 0 And (pt_Config.Flottante = 4 Or pt_Config.Flottante = 1) Then ContInput = -314 : Exit Function
                End If
                If pt_Config.Differing > 1 And pt_Config.Rear = 1 Then
                    If .Z(iCond, 262) = 0 Then ContInput = -262 : Exit Function
                End If
            End If
            If pt_Config.Differing < 2 And pt_Config.Rear < 3 Then
                .Z(iCond, 262) = .Z(iCond, 34) 'spessore assunto
                .Z(iCond, 263) = .Z(iCond, 20) 'cava
                .Z(iCond, 264) = .Z(iCond, 17) 'corr mant
                .Z(iCond, 265) = .Z(iCond, 18) 'corr cassa
                .Z(iCond, 266) = .Z(iCond, 35) 'amm.P.T.
                .Z(iCond, 267) = .Z(iCond, 7) 'Young
                .Z(iCond, 268) = .Z(iCond, 4) 'Temp.
                .Z(iCond, 269) = .Z(iCond, 32) 'M1
                .Z(iCond, 270) = .Z(iCond, 33) 'M2
            End If
        End With
    End Function
    Public Function Braccio(ByRef j As Short) As Single
        Dim Braccio2, Braccio1, b As Single
        Dim jvec As Short
        jvec = pt_Config.Side
        If j <> jvec Then SetPiastra(j)
        Select Case pt_Config.Flangiata(j - 1)
            Case -1 'cassa
                b = (BoltCiD(1) - FlChanDati(19)) / 2
            Case 0 'no
                b = 0
            Case 1 'shell
                b = (BoltCiD(1) - FlShelDati(19)) / 2
            Case 2 'both
                Braccio1 = (BoltCiD(1) - FlChanDati(19)) / 2
                Braccio2 = (BoltCiD(1) - FlShelDati(19)) / 2
                b = Braccio1 - Braccio2
        End Select
        Braccio = b '/ inc
        If j <> jvec Then SetPiastra(jvec)
    End Function
    Public Function LeggiSigma(ByRef mode As Short, Optional ByRef WWX As Integer = 0) As Integer
        Dim t, Diam, a, b As Single
        Dim Sfo, Sfa As Single
        Dim kDilat, jDilat, indice As Short
        Dim i As Short
        Dim Chart As String = ""
        Try
            'Mode=2 imposto
            If Not WWX = 0 Then WWW = WWX
            If pt_Config.SoloDilat Then
                jDilat = jInvolucr
                kDilat = kLato
            Else
                jDilat = pt_Config.IndiceDilat
                kDilat = 1
            End If
            With Mem
                If mode = 0 Then WWW = IndVar(kkk, iCol)
                If mode = 1 And pt_Config.SoloDilat And WWW < 274 Then
                    If .Z(iCond, WWW) = 0 Then .Z(iCond, WWW) = 1
                    Exit Function
                End If
                If mode = 1 And .Z(iCond, WWW) > 0 Then
                    Select Case WWW
                        Case 275, 274
20:                         objDilat.Transfer((WWW))
                    End Select
                End If
                '    If icMAWP > 1 Or icMAWP = 1 And (Condit = 2 Or Condit = 4) Then Exit Sub
                'If icMAWP > 0 Then Exit Sub '???????????????
                If icMAWP < 1 And .Z(iCond, WWW) > 0 And mode = 1 Then Exit Function
                Select Case WWW
                    Case 285 ' carico ammissibile giunto
30:                     Call CarGiunto(mode)
                    Case 259 ' compr. mantello nuovo
                        indice = Involucr(3, jInvolucr).indice(4 - 1)
                        If .Z(1, 307) = 0 Then Diam = .Z(1, 21) Else Diam = .Z(1, 307)
                        If Diam = 0 Then WarnT(-21) : Exit Function
                        If .Z(1, 23) = 0 Then WarnT(-23) : Exit Function
2300:                   a = 0.125 / ((Diam / 2) / .Z(1, 23))
2301:                   't = Textdes
                        t = .Z(1, 777)
                        If .Z(iCond, WWW) < 1 Then
                            If iCond = 1 Then
                                b = Matdim(indice).BValor(a, t, 0, CodiceStress, Chart, 0)
2303:                           .Z(iCond, WWW) = b
                            Else
                                .Z(iCond, WWW) = .Z(1, WWW)
                            End If
                        End If
                    Case 260 ' compr. mantello corroso
                        indice = Involucr(3, jInvolucr).indice(4 - 1)
                        If .Z(1, 307) = 0 Then Diam = .Z(1, 21) Else Diam = .Z(1, 307)
                        If .Z(1, 23) = 0 Then WarnT(-23) : Exit Function
                        a = 0.125 / (((Diam + 2 * .Z(iCond, 17)) / 2) / (.Z(1, 23) - .Z(iCond, 17)))
                        '     t = Textdes
                        t = .Z(1, 777)
                        If .Z(iCond, WWW) < 1 Then
                            If iCond = 1 Then
2310:                           b = Matdim(indice).BValor(a, t, 0, CodiceStress, Chart, 0)
                                .Z(iCond, WWW) = b
                            Else
                                .Z(iCond, WWW) = .Z(1, WWW)
                            End If
                        End If
                    Case 38 'snervamento tubi
                        If iCond = 1 Then
                            indice = -1
                            For i = 1 To Config(3).Ninvolucri
                                If Involucr(3, i).Tipo = 7 Then
                                    indice = Involucr(3, i).indice(1 - 1)
                                    Exit For
                                End If
                            Next
                            If indice = -1 Then
2320:                           MancaTubi()
                            Else
                                t = .Z(1, 764) '.Z(iCond, 6)
2330:                           Matdim(indice).YieldTemp(CodiceStress, t, Sfa, Sfo)
                                .Z(iCond, WWW) = Sfo
                            End If
                        Else
                            .Z(iCond, WWW) = .Z(1, WWW)
                        End If
                    Case 275 'snervamento dilatatore
                        If jDilat = -1 Then Exit Function
                        If iCond = 1 Then
                            indice = Involucr(kDilat, jDilat).indice(1 - 1)
                            t = .Z(1, 777) ' .Z(iCond, 5)
2340:                       Matdim(indice).YieldTemp(CodiceStress, t, Sfa, Sfo)
                            .Z(iCond, WWW) = Sfo
                        Else
                            .Z(iCond, WWW) = .Z(1, WWW)
                        End If
                        objDilat.Transfer(WWW)
                    Case 12 'mantello
                        indice = Involucr(3, jInvolucr).indice(4 - 1)
                        t = .Z(1, 777) ' .Z(iCond, 5)
                        If iCond = 1 Then
2350:                       If indice >= 0 Then
                                If VerificandoPI Then
                                    Sfo = Matdim(indice).Yield() * FractSyPI
                                Else
                                    Matdim(indice).SigmaAmm(CodiceStress, t, Sfa, Sfo)
                                End If
                                .Z(iCond, WWW) = Sfo
                            Else
                                If pt_Config.Rear = 1 Or (pt_Config.Rear = 2 And pt_Config.Flangiata(1 - 1) < 1) Then
                                    LeggiSigma = MostraAiuto(IDH_PT_NOMANTELLO, RoutBase1.ChiaviMess.MessExclamation + RoutBase1.ChiaviMess.MessHelpButton + RoutBase1.ChiaviMess.MessIgnoraAnnulla)
                                Else
                                    .Z(iCond, WWW) = 1
                                End If
                            End If
                        Else
                            .Z(iCond, WWW) = .Z(1, WWW)
                        End If
                    Case 274 'dilatatore
                        If jDilat = -1 Then Exit Function
                        If iCond = 1 Then
                            indice = Involucr(kDilat, jDilat).indice(1 - 1)
                            t = .Z(1, 777) ' .Z(iCond, 5)
                            If VerificandoPI Then
                                Sfo = Matdim(indice).Yield() * FractSyPI
                                Involucr(kDilat, jDilat).Shydr = Sfo
                            Else
2360:                           Matdim(indice).SigmaAmm(CodiceStress, t, Sfa, Sfo)
                                Involucr(kDilat, jDilat).St = Sfo
                            End If
                            .Z(iCond, WWW) = Sfo
                        Else
                            .Z(iCond, WWW) = .Z(1, WWW)
                        End If
                        objDilat.Transfer(WWW)
                    Case 276 'rinforzo collare
                        If jDilat = -1 Then Exit Function
                        If iCond = 1 Then
                            indice = Involucr(kDilat, jDilat).indice(2 - 1)
                            t = .Z(1, 777) ' .Z(iCond, 5)
2370:                       If Matdim(indice).Indmat > 0 Or Not Matdim(indice).Agganciato Then
                                If VerificandoPI Then
                                    Sfo = Matdim(indice).Yield() * FractSyPI
                                Else
                                    Matdim(indice).SigmaAmm(CodiceStress, t, Sfa, Sfo)
                                End If
                                .Z(iCond, WWW) = Sfo
                            Else
                                .Z(iCond, WWW) = 1
                            End If
                        Else
                            .Z(iCond, WWW) = .Z(1, WWW)
                        End If
                        ' Call AmmissColl
                    Case 278 'anelli di rinforzo
                        indice = Involucr(kDilat, jDilat).indice(3 - 1)
                        If iCond = 1 Then
                            t = .Z(1, 777) ' .Z(iCond, 5)
                            If VerificandoPI Then
                                Sfo = Matdim(indice).Yield() * FractSyPI
                            Else
2380:                           Matdim(indice).SigmaAmm(CodiceStress, t, Sfa, Sfo)
                            End If
                            .Z(iCond, WWW) = Sfo
                        Else
                            .Z(iCond, WWW) = .Z(1, WWW)
                        End If
                    Case 280 'tiranti di rinforzo
                        If iCond = 1 Then
                            indice = Involucr(kDilat, jDilat).indice(4 - 1)
                            t = .Z(1, 777) ' .Z(iCond, 5)
                            If VerificandoPI Then
                                Sfo = Matdim(indice).Yield() * FractSyPI
                            Else
2390:                           Matdim(indice).SigmaAmm(CodiceStress, t, Sfa, Sfo)
                            End If
                            .Z(iCond, WWW) = Sfo
                        Else
                            .Z(iCond, WWW) = .Z(1, WWW)
                        End If
                    Case 13 'tubi
                        If iCond = 1 Or .Z(1, WWW) = 0 Then
                            indice = -1
                            For i = 1 To Config(3).Ninvolucri
                                If Involucr(3, i).Tipo = 7 Then
                                    indice = Involucr(3, i).indice(1 - 1)
                                    Exit For
                                End If
                            Next
2400:                       If indice = -1 Then
                                MancaTubi()
                            Else
                                t = .Z(1, 764) ' .Z(iCond, 6)
                                If VerificandoPI Then
                                    Sfo = Matdim(indice).Yield() * FractSyPI
                                Else
                                    Matdim(indice).SigmaAmm(CodiceStress, t, Sfa, Sfo)
                                End If
                                .Z(iCond, WWW) = Sfo
                            End If
                        Else
                            .Z(iCond, WWW) = .Z(1, WWW)
                        End If
                    Case 35 'piastra
                        With Involucr(3, jInvolucr)
                            If iCond > 1 Or .St = 0 Or .S0 = 0 Or .Shydr = 0 And VerificandoPI Or icMAWP > 0 Then
2410:                           If Matdim(.indice(1 - 1)).Indmat = 0 And Matdim(.indice(1 - 1)).Agganciato Then
                                    MatdimScelta(.indice(1 - 1), 0, kLato, jInvolucr)
                                    If Matdim(.indice(1 - 1)).Editato Then Uniforma(.indice(1 - 1))
                                End If
                                t = Mem.Z(1, 747) ' .Z(iCond, 4)
                                If VerificandoPI Then
                                    Sfo = Matdim(.indice(1 - 1)).Yield() * FractSyPI
                                Else
                                    Matdim(.indice(1 - 1)).SigmaAmm(CodiceStress, t, Sfa, Sfo)
                                    Mem.Z(iCond, 317) = Sfa
                                End If
                                Mem.Z(iCond, WWW) = Sfo
                            Else
                                If VerificandoPI Then
                                    Mem.Z(iCond, WWW) = .Shydr
                                Else
2420:                               Mem.Z(iCond, WWW) = .St
                                    Mem.Z(iCond, 317) = .S0
                                End If
                            End If
                        End With
                    Case 266 'piastraB
                        indice = Involucr(3, jInvolucr).indice(3 - 1)
                        If indice < 0 Then Exit Function
                        If iCond = 1 Then
                            t = .Z(9, 747) ' .Z(iCond, 268)
                            If VerificandoPI Then
                                Sfo = Matdim(indice).Yield() * FractSyPI
                            Else
2430:                           Matdim(indice).SigmaAmm(CodiceStress, t, Sfa, Sfo)
                                .Z(iCond, 318) = Sfa
                            End If
                            .Z(iCond, WWW) = Sfo
                            If VerificandoPI Then
                                If Sfo = 0 Then WarnT(-266)
                            Else
                                If Sfo * Sfa = 0 Then WarnT(-266)
                            End If
                        Else
                            .Z(iCond, WWW) = .Z(1, WWW)
                        End If
                    Case Else : Exit Function
                End Select
            End With
            Exit Function
        Catch e As Exception
            MessageBox.Show(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Function
    Private Sub MancaTubi()
        Dim Chart As String = "Non è stato trovato l'elemento 'Tubi'" & vbCrLf
        Chart = Chart & "e quindi non possono essere calcolate" & vbCrLf
        Chart = Chart & "le caratteristiche del materiale." & vbCrLf
        Chart = Chart & "Comunque si possono inserire i dati" & vbCrLf & "manualmente"
        MessageBox.Show(Chart)
    End Sub
    Public Function LeggiTab(ByRef mode As Short, Optional ByRef WWX As Short = -9999) As Integer
        Dim Modef, locW As Short
        Dim pression As Single
        Dim t, fattore As Single
        Dim i As Short
        Dim kDilat, jDilat, indice As Short
        Dim IndP, iSide As Short
        Dim j As Single
        Dim ZW, W, ZWp1 As Single
        If Not WWX = -9999 Then WWW = WWX
        If pt_Config.SoloDilat Then
            jDilat = jInvolucr
            kDilat = kLato
        Else
            jDilat = pt_Config.IndiceDilat
            kDilat = 1
        End If
        With Mem
2720:       If mode = 0 Then WWW = IndVar(kkk, iCol)
            If mode = 1 And .Z(iCond, WWW) > 0 And (icMAWP = 0 Or (icMAWP > 0 And (WWW < 32 Or WWW > 33))) Then Exit Function
            If mode = 1 And pt_Config.SoloDilat And WWW < 277 Then
                If .Z(iCond, WWW) = 0 Then .Z(iCond, WWW) = 1
                Exit Function
            End If
            If WWW = 32 Or WWW = 33 Or WWW = 269 Or WWW = 270 Then 'CASE 32, 33'momenti flangia
                If WWW <= 33 Then
                    IndP = Indprobl1
                    locW = 32
                    iSide = 1
                Else
                    IndP = IndProbl2
                    locW = 269
                    iSide = 2
                End If
                'si considera che non possono esistere flangiature lato shell per
                'scambiatori a teste fisse
                If pt_Config.Flangiata(iSide - 1) <> 0 Or pt_Config.Gasketed(iSide - 1) > 0 Then
                    fattore = 1
                    If iCond > 1 And .Z(1, 2) > 0 Then fattore = .Z(iCond, 2) / .Z(1, 2)
                    If iSide = 1 Then
                        j = AllFRoo / AllFOpe
                    ElseIf iSide = 2 Then
                        If AllFOpe2 = 0 Then Exit Function
                        j = AllFRoo2 / AllFOpe2
                    End If
                    If j < 1 Then j = 1
                    'XXXXIpotesi di fasci a teste fisse (e flottante?) con flangiatura solo lato channel
                    If Not Problem(IndP).mart = 1 Then
                        .Z(iCond, locW) = FlChan(IndP).wm1 * Braccio(iSide) * fattore ' * (Problem(IndProbl).BoltCiD / inc - FlChan(IndProbl).gefinc) / 2
                        W = FlChan(IndP).wot
                        If FlChan(IndP).wm2 > FlChan(IndP).wot Then W = FlChan(IndP).wm2
                        .Z(iCond, locW + 1) = W * Braccio(iSide) ' * j '* (Problem(IndP).BoltCiD / inc - FlChan(IndP).gefinc) / 2  'serraggio
                        'tolta la correzione sull'ammissibile
                        If icMAWP > 0 And FlChan(IndP).AreaBol > 0 Then fatt(0) = FlChan(IndP).am / FlChan(IndP).AreaBol * 100
                    Else
                        'CALCOLO AUTOMATICO
                        If Problem(IndP).Tiranti(1).BoltCiD > 0 Then
                            pression = .Z(iCond, 2)
                            If Problem(IndProbl).PDIFF = 0 Then pression = .Z(iCond, 3)
                            If FlChan(IndP).PHI > 0 Then
                                Modef = 1 : If icMAWP > 0 Then Modef = 2
                                If Not CType(objMemb(Involucr(3, jInvolucr).IndObject), wn_PT).geomguar(Modef, 2, pression) Then .Z(iCond, locW) = -1 : Exit Function
                                .Z(iCond, locW) = FlChan(IndP).m1 * fattore 'esercizio
                                .Z(iCond, locW + 1) = FlChan(IndP).m2 * j 'serraggio
                                If icMAWP > 0 Then fatt(0) = FlChan(IndP).am / FlChan(IndP).AreaBol * 100
                            Else
                                .Z(iCond, locW) = 0 : .Z(iCond, locW + 1) = 0
                            End If
                        Else
                            .Z(iCond, WWW) = 0
                        End If
                    End If
                    'XXXXXXXX
                    If pt_Config.Rear = 3 And pt_Config.Gasketed(1 - 1) <> 0 Then
                        '              caso tubi a U senza estensione
                        If Not Problem(IndP).mart = 1 Then
                            ZW = FlShel(IndP).wm1 * Braccio(iSide) * fattore ' * (Problem(IndProbl).BoltCiD / inc - FlChan(IndProbl).gefinc) / 2
                            W = FlShel(IndP).wot
                            If FlShel(IndP).wm2 > FlShel(IndP).wot Then W = FlShel(IndP).wm2
                            ZWp1 = W * Braccio(iSide) * j '* (Problem(IndP).BoltCiD / inc - FlChan(IndP).gefinc) / 2  'serraggio
                            If icMAWP > 0 And FlShel(IndP).AreaBol > 0 Then fatt(0) = FlShel(IndP).am / FlShel(IndP).AreaBol * 100
                        Else
                            'CALCOLO AUTOMATICO
                            If Problem(IndP).Tiranti(1).BoltCiD > 0 Then
                                pression = .Z(iCond, 1)
                                If Problem(IndProbl).PDIFF = 0 Then pression = .Z(iCond, 3)
                                Modef = 1 : If icMAWP > 0 Then Modef = 2
                                If Not CType(objMemb(Involucr(3, jInvolucr).IndObject), wn_PT).geomguar(Modef, 1, pression) Then .Z(iCond, locW) = -1 : Exit Function
                                ZW = FlShel(IndP).m1 * fattore 'esercizio
                                ZWp1 = FlShel(IndP).m2 * j 'serraggio
                                If icMAWP > 0 Then fatt(0) = FlShel(IndP).am / FlShel(IndP).AreaBol * 100
                            Else
                                .Z(iCond, WWW) = 0
                            End If
                        End If
                        If ZW > .Z(iCond, locW) Then .Z(iCond, locW) = ZW
                        If ZWp1 > .Z(iCond, locW + 1) Then .Z(iCond, locW + 1) = ZWp1
                    End If
                End If
            End If
            '     If icMAWP > 1 Or icMAWP = 1 And (Condit = 2 Or Condit = 4) Then Exit Function
            If icMAWP > 1 Then Exit Function
            Select Case WWW
                Case 7 'piastra
                    indice = Involucr(3, jInvolucr).indice(1 - 1)
                    If CalcoloInCorso = 0 Then
                        t = .Z(iCond, 4)
                        .Z(iCond, WWW) = Matdim(indice).EmodAlt(t)
                    Else
                        If iCond = 1 Or iCond = 9 Then
                            t = .Z(iCond, 747)
                            .Z(iCond, WWW) = Matdim(indice).EmodAlt(t)
                        Else
                            .Z(iCond, WWW) = .Z(1, WWW)
                        End If
                    End If
                Case 8 'mantello
                    If pt_Config.SoloDilat Then
                        indice = Involucr(kDilat, jDilat).indice(5 - 1)
                    Else
                        indice = Involucr(3, jInvolucr).indice(4 - 1)
                        If indice = -1 Then Exit Function
                    End If
                    If CalcoloInCorso = 0 Then
                        t = .Z(iCond, 5)
                        .Z(iCond, WWW) = Matdim(indice).EmodAlt(t)
                    Else
                        If iCond = 1 Then
                            t = .Z(iCond, 777)
                            .Z(iCond, WWW) = Matdim(indice).EmodAlt(t)
                        Else
                            .Z(iCond, WWW) = .Z(1, WWW)
                        End If
                    End If
                Case 287 'dilatatore
                    If jDilat = -1 Then Exit Function
                    If .Z(1, 26) > 0 Then
                        indice = Involucr(kDilat, jDilat).indice(1 - 1)
                        If CalcoloInCorso = 0 Then
                            t = .Z(iCond, 5)
                            .Z(iCond, WWW) = Matdim(indice).EmodAlt(t)
                        Else
                            If iCond = 1 Then
                                t = .Z(iCond, 777)
                                .Z(iCond, WWW) = Matdim(indice).EmodAlt(t)
                            Else
                                .Z(iCond, WWW) = .Z(1, WWW)
                            End If
                        End If
                        .Z(0, WWW) = Matdim(indice).EmodAlt(20)
                    End If
                Case 9 'tubi
                    indice = -1
                    For i = 1 To Config(3).Ninvolucri
                        If Involucr(3, i).Tipo = 7 Then
                            indice = Involucr(3, i).indice(1 - 1)
                        End If
                    Next
                    If indice > -1 Then
                        If CalcoloInCorso = 0 Then
                            t = .Z(iCond, 6)
                            .Z(iCond, WWW) = Matdim(indice).EmodAlt(t)
                        Else
                            If iCond = 1 Then
                                t = .Z(iCond, 764)
                                .Z(iCond, WWW) = Matdim(indice).EmodAlt(t)
                            Else
                                .Z(iCond, WWW) = .Z(1, WWW)
                            End If
                        End If
                    End If
                Case 14 'mantello
                    indice = Involucr(3, jInvolucr).indice(4 - 1)
                    t = .Z(iCond, 5)
                    If indice >= 0 Then
                        .Z(iCond, WWW) = Matdim(indice).AlfaTer(t)
                    Else
                        If pt_Config.Rear = 1 Then
                            LeggiTab = MostraAiuto(IDH_PT_NOMANTELLO, RoutBase1.ChiaviMess.MessExclamation + RoutBase1.ChiaviMess.MessHelpButton + RoutBase1.ChiaviMess.MessIgnoraAnnulla)
                        Else
                            .Z(iCond, WWW) = 1
                        End If
                    End If
                Case 15 'tubi
                    If pt_Config.Rear = 1 Then
                        indice = -1
                        For i = 1 To Config(3).Ninvolucri
                            If Involucr(3, i).Tipo = 7 Then
                                indice = Involucr(3, i).indice(1 - 1)
                                Exit For
                            End If
                        Next
                        If indice > -1 Then
                            t = .Z(iCond, 6)
                            .Z(iCond, WWW) = Matdim(indice).AlfaTer(t)
                        End If
                    End If
                Case 267 'piastra B
                    indice = Involucr(3, jInvolucr).indice(3 - 1)
                    If indice < 0 Then Exit Function
                    t = .Z(iCond, 268)
                    .Z(iCond, WWW) = Matdim(indice).EmodAlt(t)
                Case 277 'anelli rinforzo dilatatore
                    indice = Involucr(kDilat, jDilat).indice(3 - 1)
                    t = .Z(iCond, 5)
                    .Z(iCond, WWW) = Matdim(indice).EmodAlt(t)
                Case 279 'tiranti rinforzo dilatatore
                    indice = Involucr(kDilat, jDilat).indice(4 - 1)
                    t = .Z(iCond, 5)
                    .Z(iCond, WWW) = Matdim(indice).EmodAlt(t)
                Case 324, 1324
                    MessageBox.Show("Lanciare il calcolo: questi valori saranno calcolati automaticamente")
                    Exit Function
                Case Else : Exit Function
            End Select
            If WWW < 32 And WWW > 33 Then
                If .Z(iCond, WWW) <= 0 Then Call WarnT(1)
            End If
        End With
        Chiave = 12
    End Function
    Public Sub MAWPcalc()
        Dim FattVec() As Single
        Dim Salva1(2, 320) As Single
        Dim Stringa1(7) As String
        Dim NSav, ns As Short
        Dim ii, i, k As Short
        Dim Testo As String
        Dim fattore, fattorev As Single
        Dim kk, K0, kkmax As Short
        Dim Res, kAltra, kDil As Short
        Dim Press As Single
        InterrompiMAWP = False
        'If frmRis.Risposta = "Ammazza" Then Exit Sub
        Stringa1(0) = " Bulloni"
        Stringa1(1) = " Piastra"
        Stringa1(2) = "Traz.Tub"
        Stringa1(3) = "Comp.Tub"
        Stringa1(4) = "Traz.Man"
        Stringa1(5) = "Comp.Man"
        Stringa1(6) = "  Giunto"
        Stringa1(7) = "  Dilat."
        With Mem
            If .Z(1, 26) > 0 Then objDilat.SaveDilat()
            NSav = .Z(1, 261) : .Z(1, 261) = 0
            ns = NSav
            Testo = "|Prego attendere... ||Calcolo delle MAWP in corso"
            If Not ContinuoAuto Then Monitor.Motore.ProgrInizio(Monitor.Motore.Inizio.ConvertiCr(Testo), "MAWP calculations")
            For ic = 1 To ns
                iCond = ic
500:            Cm = .Z(ic, 17) : cc = .Z(ic, 18) : Cd = .Z(ic, 19)
                Pm = .Z(ic, 1) : Pc = .Z(ic, 2) : Pd = .Z(ic, 3)
                Tm = .Z(ic, 777) : Ttub = .Z(ic, 764) : TP = .Z(ic, 747) : TpB = .Z(ic + 8, 747)
                All = .Z(ic, 35) : All2 = .Z(ic, 266)
                Registra()
                am1 = .Z(ic, 32) : am2 = .Z(ic, 33)
510:            For i = 1 To 4
                    Condit = i
                    For ii = 1 To 320
                        Salva1(1, ii) = .Z(ic, ii)
                        Salva1(2, ii) = .Z(ic + 8, ii)
                    Next
                    Select Case i
                        Case 1
512:                        .Z(ic, 17) = 0 : .Z(ic, 18) = 0 : .Z(ic, 19) = 0
                            Freddo()
                        Case 2
                            Caldo()
                        Case 3
514:                        .Z(ic, 17) = Cm : .Z(ic, 18) = cc : .Z(ic, 19) = Cd
                            Freddo()
                        Case 4
516:                        Caldo()
                    End Select
                    For k = 1 To 3
519:                    If .Z(ic, k) <= 0 Then GoTo Contk
                        If pt_Config.Rear = 1 And k = 3 Then GoTo Contk
                        If Not pt_Config.SoloDilat And Problem(IndProbl).PDIFF = 0 And Not pt_Config.Rear = 1 And k < 3 Then
                            'If pt_Config.SoloDilat Then Stop
                            GoTo Contk
                        End If
                        If Problem(IndProbl).PDIFF = 1 And Not pt_Config.Rear = 1 And k = 3 Then GoTo Contk
                        If pt_Config.SoloDilat And k = 2 Then GoTo Contk
                        If k = 1 And Problem(IndProbl).PDIFF = 1 Then .Z(ic, 2) = 0
                        If k = 2 And Problem(IndProbl).PDIFF = 1 Then .Z(ic, 1) = 0
520:                    icMAWP = 1
                        'UPGRADE_ISSUE: La clausola As Single è stata rimossa dall'istruzione ReDim FattVec(10). Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1056"'
                        ReDim FattVec(10)
                        Do
                            Select Case pt_Config.Rear
                                Case 1
                                    Chiave = 2
                                    Res = SelAction() 'CalcoliP
                                    If Res < 0 Then
                                        If Not ContinuoAuto Then Monitor.Motore.ProgrAmmazza()
                                        Restore()
                                        GoTo 560
                                    End If
                                Case Else
                                    Res = Esegui()
                                    If Res < 0 Then
                                        If Not ContinuoAuto Then Monitor.Motore.ProgrAmmazza()
                                        Restore()
                                        GoTo 560
                                    End If
                            End Select
                            iCond = ic
523:                        Call FattUs()
524:                        fattore = 0
                            K0 = 1 : If k = 2 Then K0 = 0
                            kDil = 0 : If pt_Config.SoloDilat Then kDil = 6
                            '                      K0 = 0
                            For kk = K0 To Nf
                                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto FattVec(kk). Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                                If fatt(kk) > fattore And (fatt(kk) <> FattVec(kk) Or pt_Config.Rear > 1) Then
                                    fattore = fatt(kk) : kkmax = kk
                                End If
                                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto FattVec(). Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                                FattVec(kk) = fatt(kk)
                            Next
                            If fattore = 0 Then
                                For kk = K0 To Nf
                                    If fatt(kk) > fattore Then fattore = fatt(kk) : kkmax = kk
                                Next
                            End If
                            '                      IF ABS(Fattore - 100) < .1 OR .Z(iC, 1) = 0 OR .Z(iC, 2) = 0 THEN EXIT DO
                            'DoEvents
                            If System.Math.Abs(fattorev - fattore) / fattore < clsTrigon.TOLER Then Exit Do
                            If System.Math.Abs(fattore - 100) < 0.1 Then Exit Do
                            If fattore >= 100 And fattore < 100.01 Then Exit Do
                            '                      IF icMAWP = 1 AND Fattore > 99.9 THEN EXIT DO
                            .Z(ic, k) = .Z(ic, k) / (fattore / 100) ^ (2 * (-icMAWP + 203) / 202 / 1.5)
                            fattorev = fattore
                            kAltra = 1
                            pp = Pm
                            If k = 1 Then
                                kAltra = 2
                                pp = Pc
                            End If
                            'If pt_Config.Rear > 1 And Problem(IndProbl).PDIFF = 1 And .Z(ic, k) < pp * 0.9 Then .Z(ic, k) = pp * 0.9
527:                        icMAWP = icMAWP + 1
                            If icMAWP > 100 Then Exit Do
                            System.Windows.Forms.Application.DoEvents()
                            If InterrompiMAWP Then
                                Res = -1
                                Restore()
                                If Not ContinuoAuto Then Monitor.Motore.ProgrAmmazza()
                                GoTo 560
                            End If
                        Loop
                        If Not ContinuoAuto Then Monitor.Motore.Avanzamento = (k + (i - 1) * 2 + (ic - 1) * 8) * 100.0# / (8 * ns)
                        Select Case k
                            Case 1
                                Press = .Z(ic, 1)
                                If Problem(IndProbl).Vacuum >= 2 Then Press -= Config(2).pxExt
                                If MAWP(i, k) > Press And Press > 0 Or ic = 1 Then
                                    FattMax(i, k) = kkmax + kDil
                                    MAWP(i, k) = Press
                                    iCondMax(i, k) = ic
                                End If
                            Case 2
                                Press = .Z(ic, 2)
                                If Problem(IndProbl).Vacuum = 1 Or Problem(IndProbl).Vacuum = 3 Then Press -= Config(1).pxExt
                                If MAWP(i, k) > Press And Press > 0 Or ic = 1 Then
                                    FattMax(i, k) = kkmax + kDil
                                    MAWP(i, k) = Press
                                    iCondMax(i, k) = ic
                                End If
                            Case 3
                                If MAWP(i, 1) > .Z(ic, 3) And Problem(IndProbl).PDIFF = 0 Or ic = 1 Then
                                    FattMax(i, 1) = kkmax + kDil
                                    MAWP(i, 1) = .Z(ic, 3)
                                    iCondMax(i, 1) = ic
                                End If
                        End Select
Contk:                  .Z(ic, 1) = Pm : .Z(ic, 2) = Pc : .Z(ic, 3) = Pd
                        System.Windows.Forms.Application.DoEvents()
                        If InterrompiMAWP Then
                            Res = -1
                            Restore()
                            If Not ContinuoAuto Then Monitor.Motore.ProgrAmmazza()
                            GoTo 560
                        End If
                    Next k
Conti:
                    '                IF i = 1 OR i = 3 THEN
                    For ii = 1 To 320
                        .Z(ic, ii) = Salva1(1, ii)
                        'If ic = 1 Then .Z(2, ii) = Salva1(2, ii)
                        .Z(ic + 8, ii) = Salva1(2, ii)
                    Next
                    '                END IF
                Next i
                Restore()
            Next ic
            If Not ContinuoAuto Then Monitor.Motore.ProgrAmmazza()
            If .Z(1, 26) > 0 Then objDilat.RetrDilat()
            For i = 1 To 4
                If Problem(IndProbl).PDIFF = 1 Then
                    Involucr(kLato, jInvolucr).MAWP(i - 1) = MAWP(i, 1)
                    Involucr(kLato, jInvolucr).MAWP2(i - 1) = MAWP(i, 2)
                Else
                    If pt_Config.Rear = 1 Then
                        Involucr(kLato, jInvolucr).MAWP(i - 1) = MAWP(i, 1)
                        Involucr(kLato, jInvolucr).MAWP2(i - 1) = MAWP(i, 2)
                    Else
                        Involucr(kLato, jInvolucr).MAWP(i - 1) = MAWP(i, 1)
                        Involucr(kLato, jInvolucr).MAWP2(i - 1) = 0
                    End If
                End If
            Next
560:        icMAWP = 0
            .Z(1, 261) = NSav
        End With
        If Res < 0 Then
            Testo = "  Non è stato possibile completare il calcolo|       delle MAWP"
            GoTo 561
        End If
        If ContinuoAuto Then Exit Sub
        Testo = "                Risultati del calcolo MAWP " & UnitPress & "|"
        Testo = Testo & "                ================================|"
        Testo = Testo & "     Nuovo Freddo    Nuovo Caldo     Corr. Freddo    Corr. Caldo  |"
        If pt_Config.SoloDilat Then
        ElseIf Problem(IndProbl).PDIFF = 1 Or pt_Config.Rear = 1 Then
            Testo = Testo & "     Mant.   Tubi    Mant.   Tubi    Mant.   Tubi    Mant.   Tubi | "
        Else
            Testo = Testo & "     Differenziale   Differenziale   Differenziale   Differenziale| "
        End If
        For i = 1 To 4
            If (Problem(IndProbl).PDIFF = 1 Or pt_Config.Rear = 1) And Not pt_Config.SoloDilat Then
                For k = 1 To 2
                    Testo = Testo & GlobalRoutines.myStr(MAWP(i, k) * kPress, 6 - IncrVirgola, 1 + IncrVirgola, 0)
                Next k
            Else
                Testo = Testo & GlobalRoutines.myStr(MAWP(i, 1) * kPress, 6 + 8 - IncrVirgola, 1 + IncrVirgola, 0)
            End If
        Next i
        Testo = Testo & "| "
        For i = 1 To 4
            For k = 1 To 2
                If pt_Config.SoloDilat Then
                    If Not (k = 2 Or Problem(IndProbl).PDIFF = 0) Then
                        Testo = Testo & "Dilatatore" ' Stringa1$(FattMax(i, k))
                    Else
                        Testo = Testo & Space(4)
                    End If
                ElseIf pt_Config.Rear > 1 And CalcoloInCorso = 0 Then
                    If Not (k = 2 Or Problem(IndProbl).PDIFF = 0) Then
                        Testo = Testo & "    Piastra " ' Stringa1$(FattMax(i, k))
                    Else
                        Testo = Testo & Space(5)
                    End If
                Else
                    Testo = Testo & Stringa1(FattMax(i, k))
                End If
            Next k
        Next i
561:    Testo = Monitor.Motore.Inizio.ConvertiCr(Testo)
        With mioRis
            .Rinnova()
            .Command4.Visible = False
            .cmdDilat.Visible = False
            .cmdFattUs.Visible = False
            .Picture1.Visible = True
            .Picture2.Visible = False
            .TabStrip1.Visible = False
            ._Text1_0.Visible = False : ._Label1_0.Visible = False
            ._Text1_1.Visible = False : ._Label1_1.Visible = False
            .mygraphics.DrawString(Testo, .myfont, .mybrush, .x, .y)
            ' .Chiusa = False
            .ShowDialog() 'al
            '  Do
            '  System.Windows.Forms.Application.DoEvents()
            '  Loop Until .Chiusa
        End With
        Condit = 0
        Exit Sub
    End Sub
    Private Sub Registra()
        With Mem
            z5 = .Z(ic, 5) : z6 = .Z(ic, 6) : z4 = .Z(ic, 4) : z268 = .Z(ic, 268) : z268B = .Z(ic + 8, 268)
            z322 = .Z(ic, 322) : z322B = .Z(ic + 8, 322)
            z594 = .Z(ic, 594) : z594B = .Z(ic + 8, 594)
            z595 = .Z(ic, 595) : z595B = .Z(ic + 8, 595)
            z596 = .Z(ic, 596) : z596B = .Z(ic + 8, 596)
        End With
    End Sub
    Private Sub Caldo()
        With Mem
            .Z(ic, 5) = z5 : .Z(ic, 6) = z6 : .Z(ic, 4) = z4 : .Z(ic, 268) = z268 : .Z(ic + 8, 268) = z268B
            .Z(ic, 322) = z322 : .Z(ic + 8, 322) = z322B
            .Z(ic, 594) = z594 : .Z(ic + 8, 594) = z594B
            .Z(ic, 595) = z595 : .Z(ic + 8, 595) = z595B
            .Z(ic, 596) = z596 : .Z(ic + 8, 596) = z596B
            .Z(ic, 777) = Tm : .Z(ic, 764) = Ttub : .Z(ic, 747) = TP
            .Z(ic + 8, 747) = TpB
            .Z(ic, 35) = All
            .Z(ic, 266) = All2
        End With
    End Sub
    Private Sub Freddo()
        With Mem
            .Z(ic, 5) = 20 : .Z(ic, 6) = 20 : .Z(ic, 4) = 20 : .Z(ic, 268) = 20 : .Z(ic + 8, 268) = 20
            .Z(ic, 322) = 20 : .Z(ic + 8, 322) = 20
            .Z(ic, 594) = 20 : .Z(ic + 8, 594) = 20
            .Z(ic, 595) = 20 : .Z(ic + 8, 595) = 20
            .Z(ic, 596) = 20 : .Z(ic + 8, 596) = 20
            .Z(ic, 777) = 20 : .Z(ic, 764) = 20
            .Z(ic, 747) = 20 : .Z(ic + 8, 747) = 20
            .Z(ic, 35) = .Z(ic, 317)
            .Z(ic, 266) = .Z(ic, 318)
        End With
    End Sub
    Private Sub Restore()
        With Mem
            .Z(ic, 32) = am1 : .Z(ic, 33) = am2
            .Z(ic, 17) = Cm : .Z(ic, 18) = cc : .Z(ic, 19) = Cd
            .Z(ic, 1) = Pm : .Z(ic, 2) = Pc
        End With
        Caldo()
    End Sub
    Public Sub CarGiunto(ByRef mode As Short)
        Dim ifl, i As Short
        Dim YieldM As Single
        Dim Testo As String
        Dim iQ As Short
        Dim nDati As Short
        ' Dim Testo1 As String
        Dim Nome As String
        If pt_Config.SoloDilat Then Exit Sub
        ' MouseShow
        If Mem.Z(iCond, 13) = 0 Then LeggiSigma(2, 13)
        If Mem.Z(iCond, 38) = 0 Then LeggiSigma(2, 38)
Rifai:
        ifl = FreeFile()
        Nome = RTrim(Monitor.Motore.Inizio.Archdir) & "\GIUNTO.DAT"
        If Not OpenFile(Nome, ifl) Then Exit Sub
        For i = 1 To 9 : Stringa1(i) = LineInput(ifl) : Next
        For i = 1 To 6 : Stringa3(i) = LineInput(ifl) : Next
        FileClose(ifl)
        '   Stringa1$(1) = "Saldato a>=1.4t"
        '   Stringa1$(2) = "Saldato t<=a<1.4t"
        '   Stringa1$(3) = "Con saldatura di tenuta"
        '   Stringa1$(4) = "Brasato, esaminato 100%"
        '   Stringa1$(5) = "Brasato, non esam. 100%"
        '   Stringa1$(6) = "Mandrinato >=2 canalini"
        '   Stringa1$(7) = "Mandrinato con 1 canalino"
        '   Stringa1$(8) = "Mandrinato senza canalini"
        '   Stringa3$(1) = "Mandrinato di forza >=2 can."
        '   Stringa3$(2) = "Mandrinato di forza 1 canal."
        '   Stringa3$(3) = "Mandrinato di forza senza c."
        '   Stringa3$(4) = "Mandrinato d'accostaggio"
        If mode = 1 And pt_Config.TipoGiunto > 0 And pt_Config.fr > 0 Then GoTo Salto
        CercaTubi()
        Dim iSalva As Integer
        If iTubi > 0 Then
            iSalva = pt_Config.TipoGiunto
            pt_Config.TipoGiunto = Involucr(3, iTubi).ms
        End If
        If pt_Config.TipoGiunto < 1 Then
            If iSalva = 0 Then iSalva = 1
            pt_Config.TipoGiunto = Monitor.Motore.Quale(8, Stringa3(5), Stringa1, "", iSalva)
            If iTubi > 0 Then Involucr(3, iTubi).ms = pt_Config.TipoGiunto
        End If
        Select Case pt_Config.TipoGiunto
            Case 1
                If pt_Config.fr = 0 Or pt_Config.fr > 1 Then pt_Config.fr = 0.8
                pt_Config.fe = 10
                pt_Config.fy = 10 'saldati super
                pt_Config.SaldMand = 0
            Case 2 'saldati medi
                pt_Config.SaldMand = Monitor.Motore.Quale(4, Stringa3(6), Stringa3, "", pt_Config.SaldMand)
100:            Select Case pt_Config.SaldMand
                    Case 1 : If pt_Config.fr = 0 Or pt_Config.fr > 1 Then pt_Config.fr = 0.75
                    Case 2 : If pt_Config.fr = 0 Or pt_Config.fr > 1 Then pt_Config.fr = 0.65
                    Case 3 : If pt_Config.fr = 0 Or pt_Config.fr > 1 Then pt_Config.fr = 0.5
                    Case 4 : If pt_Config.fr = 0 Or pt_Config.fr > 1 Then pt_Config.fr = 0.55
                End Select
                SaldMand()
            Case 3 'saldati di tenuta
                pt_Config.SaldMand = Monitor.Motore.Quale(3, Stringa3(6), Stringa3, "", pt_Config.SaldMand)
120:            Select Case pt_Config.SaldMand
                    Case 1 : If pt_Config.fr = 0 Or pt_Config.fr > 1 Then pt_Config.fr = 0.75
                    Case 2 : If pt_Config.fr = 0 Or pt_Config.fr > 1 Then pt_Config.fr = 0.65
                    Case 3 : If pt_Config.fr = 0 Or pt_Config.fr > 1 Then pt_Config.fr = 0.5
                End Select
                SaldMand()
            Case 4 : If pt_Config.fr = 0 Or pt_Config.fr > 1 Then pt_Config.fr = 0.8
                pt_Config.fe = 10 : pt_Config.fy = 10 : pt_Config.SaldMand = 0
            Case 5 : If pt_Config.fr = 0 Or pt_Config.fr > 1 Then pt_Config.fr = 0.4
                pt_Config.fe = 10 : pt_Config.fy = 10 : pt_Config.SaldMand = 0
            Case 6 : If pt_Config.fr = 0 Or pt_Config.fr > 1 Then pt_Config.fr = 0.7
                pt_Config.fe = 1 : pt_Config.fy = 0 : pt_Config.SaldMand = 0
            Case 7 : If pt_Config.fr = 0 Or pt_Config.fr > 1 Then pt_Config.fr = 0.65
                pt_Config.fe = 1 : pt_Config.fy = 0 : pt_Config.SaldMand = 0
            Case 8 : If pt_Config.fr = 0 Or pt_Config.fr > 1 Then pt_Config.fr = 0.5
                LungMand()
                pt_Config.SaldMand = 0
        End Select
        If pt_Config.fy = 0 Then
140:        YieldPias()
            If YieldM <= 0 Then
                Testo = "La tensione di snervamento della P.T. non è nota.|"
                Testo = Testo & "Di conseguenza il carico ammissibile sul giunto|"
                Testo = Testo & "non può essere calcolato con precisione.|"
                Testo = Testo & "Controllare i dati del materiale. Il calcolo continua."
                Testo = Monitor.Motore.Inizio.ConvertiCr(Testo)
                MessageBox.Show(Testo)
                pt_Config.fy = 1
            ElseIf Mem.Z(iCond, 38) <= 0 Then
                Testo = "La tensione di snervamento dei tubi non è nota.|"
                Testo = Testo & "Di conseguenza il carico ammissibile sul giunto|"
                Testo = Testo & "non può essere calcolato con precisione.|"
                Testo = Testo & "Controllare i dati del materiale. Il calcolo continua."
                Testo = Monitor.Motore.Inizio.ConvertiCr(Testo)
                MessageBox.Show(Testo)
                pt_Config.fy = 1
            Else
                pt_Config.fy = YieldM / Mem.Z(iCond, 38)
                If pt_Config.fy > 1 Then pt_Config.fy = 1
            End If
        End If
Salto:
        '  Testo1 = "|(N.B.: se viene esposto un valore nullo è"
        '  Testo1 = Testo1 & "|possibile che non sia stata ancora determi-"
        '  Testo1 = Testo1 & "|nata la tensione ammissibile dei tubi)."
        If pt_Config.fe = 10 Or pt_Config.fy = 10 Then
150:        Mem.Z(iCond, 285) = Mem.Z(iCond, 13) * pi / 4 * (Mem.Z(1, 27) ^ 2 - (Mem.Z(1, 27) - 2 * Mem.Z(1, 28)) ^ 2) * pt_Config.fr ' / inc / inc
            Testo = "Carico ammiss. giunto  " & UnitForce & ": " & GlobalRoutines.myStr(CSng(Mem.Z(iCond, 285) * kForce), 7, 2, False)
            'Testo = Testo & Testo1
            Testo = Testo & "|Appendix A: fr              " & GlobalRoutines.myStr(pt_Config.fr, 2, 2, False)
        Else
            Mem.Z(iCond, 285) = Mem.Z(iCond, 13) * pi / 4 * (Mem.Z(1, 27) ^ 2 - (Mem.Z(1, 27) - 2 * Mem.Z(1, 28)) ^ 2) * pt_Config.fr * pt_Config.fe * pt_Config.fy ' / inc / inc
            Testo = "Carico ammiss. giunto  [lb]:" & GlobalRoutines.myStr(CSng(Mem.Z(iCond, 285)), 7, 2, False)
            'Testo = Testo & Testo1
            Testo = Testo & "|Appendix A: fr              " & GlobalRoutines.myStr(pt_Config.fr, 2, 2, False)
            Testo = Testo & "|Appendix A: fe              " & GlobalRoutines.myStr(pt_Config.fe, 2, 2, False)
            Testo = Testo & "|Appendix A: fy              " & GlobalRoutines.myStr(pt_Config.fy, 2, 2, False)
        End If
        If Mem.Z(iCond, 285) = 0 And Mem.Z(iCond, 13) > 0 Then
            MessageBox.Show(Monitor.Motore.Inizio.ConvertiCr("La geometria dei tubi non è definita.|Controllare i dati della piastra"))
            Exit Sub
        End If
        Testo = Testo & "|      Che cosa decidi?      "
        Testo = Monitor.Motore.Inizio.ConvertiCr(Testo)
        Stringa(1) = "Accetto  "
        Stringa(2) = "Modifico il giunto"
        Stringa(3) = "Modifico i coefficienti"
        If mode = 0 Then
            iQ = Monitor.Motore.Quale(3, "Efficienza per giunto " & Stringa1(pt_Config.TipoGiunto), Stringa, "", 1, Testo)
            Select Case iQ
                Case 1 : GoTo Fin
                Case 2 : If iTubi > 0 Then Involucr(3, iTubi).ms = 0 Else pt_Config.TipoGiunto = 0
                    GoTo Rifai
                Case 3
                    nDati = 1
                    If Not pt_Config.fe = 10 Then nDati = nDati + 1
                    If Not pt_Config.fy = 10 Then nDati = nDati + 1
                    Stringa(1) = "Appendix A: fr"
                    Risult(1) = GlobalRoutines.myStr(pt_Config.fr, 2, 2, False)
                    Stringa(2) = "Appendix A: fe"
                    Risult(2) = GlobalRoutines.myStr(pt_Config.fe, 2, 2, False)
                    Stringa(3) = "Appendix A: fy"
                    Risult(3) = GlobalRoutines.myStr(pt_Config.fy, 2, 2, False)
                    If Monitor.Motore.InputDati(nDati, "Coefficienti di giunto", Stringa, Risult, "", Arch, dAiu) Then
                        pt_Config.fr = GlobalRoutines.ValVir(Risult(1))
                        If nDati > 1 Then pt_Config.fe = GlobalRoutines.ValVir(Risult(2))
                        If nDati > 2 Then pt_Config.fy = GlobalRoutines.ValVir(Risult(3))
                        GoTo Salto
                    End If
            End Select
        End If
Fin:
        For i = 1 To Mem.Z(1, 261)
            If i <> iCond Then
                If pt_Config.fe = 10 Or pt_Config.fy = 10 Then
                    Mem.Z(i, 285) = Mem.Z(i, 13) * pi / 4 * (Mem.Z(1, 27) ^ 2 - (Mem.Z(1, 27) - 2 * Mem.Z(1, 28)) ^ 2) * pt_Config.fr '/ inc / inc
                Else
                    Mem.Z(i, 285) = Mem.Z(i, 13) * pi / 4 * (Mem.Z(1, 27) ^ 2 - (Mem.Z(1, 27) - 2 * Mem.Z(1, 28)) ^ 2) * pt_Config.fr * pt_Config.fe * fy(i) '/ inc / inc
                End If
            End If
        Next
    End Sub
    Private Sub CercaTubi()
        Dim i As Integer
        For i = 1 To Config(3).Ninvolucri
            If Involucr(3, i).Tipo = 7 Then iTubi = i : Exit For
        Next
    End Sub
    Private Sub LungMand()
        pt_Config.fy = 0
190:    Stringa(1) = "Diametro esterno tubo  [mm]"
        Stringa(2) = "Lunghezza di mandrinat.[mm]"
192:    Risult(1) = GlobalRoutines.myStr(Mem.Z(1, 27), 3, 3, False)
        Risult(2) = GlobalRoutines.myStr(pt_Config.LungMand, 3, 3, False)
195:    Dim i As Integer = Monitor.Motore.InputDati(2, "Mandrinatura", Stringa, Risult, "", Arch, dAiu)
196:    pt_Config.LungMand = GlobalRoutines.ValVir(Risult(2))
        If pt_Config.LungMand > Mem.Z(1, 39) Then pt_Config.LungMand = Mem.Z(1, 39)
        pt_Config.fe = pt_Config.LungMand / Mem.Z(1, 27)
        If pt_Config.fe > 1 Then pt_Config.fe = 1
    End Sub
    Private Sub YieldPias()
        Dim YieldM, Sya, Syo As Single
        If Mem.Z(iCond, 286) Then
            YieldM = Mem.Z(iCond, 286)
        Else
            Matdim(Involucr(kLato, jInvolucr).indice(1 - 1)).YieldTemp(CodiceStress, Mem.Z(iCond, 4), Sya, Syo)
            YieldM = Syo
            Mem.Z(iCond, 286) = YieldM
        End If
    End Sub
    Private Sub SaldMand()
        Select Case pt_Config.SaldMand
            Case 4
170:            pt_Config.fe = 10 : pt_Config.fy = 10
            Case 1, 2
                pt_Config.fy = 0 : pt_Config.fe = 1
            Case 3
                LungMand()
        End Select
    End Sub
    Public Function Convert(ByRef ZZ As Single, ByRef i As Short, ByRef mode As Short) As Single
        'Mode 0 da psi a Mpa 1 inverso 
        Convert = ZZ
        Select Case mode
            Case 0, 2
                Select Case i
                    Case 1, 2, 3, 7, 8, 9, 59 To 64, 67, 68, 81, 82, 97, 98, 107, 108, 133, 134, 201 To 204, 237, 238, 239, 240, 267, _
                         287, 277 To 280, 286, 287, 300 To 303, 323, 325, 330 To 343, 372 To 375, 492 To 534, 597, 598, 683, 690, 697, 704, 711, 733 To 746 'pressione
                        Convert = ZZ / psi
                    Case 12, 13, 35, 38, 244, 259, 260, 266, 274, 275, 276, 278, 280, 629, 630 'ammiss
                        Convert = System.Math.Abs(ZZ) / psi
                    Case 36, 37, 391 To 394 'kappa
                        Convert = ZZ * NIUT / inc
                    Case 4, 5, 6, 268, 272, 273, 304, 305, 322, 433 To 435, 594 To 596, 683, 690, 697, 704, 747, 764, 777 'temp
                        Convert = (ZZ - 32) / 1.8
                    Case 32, 33, 269, 270, 319, 320 'momento
                        Convert = ZZ * NIUT * inc / 1000
                    Case 14, 15, 321, 324 'alfa
                        Convert = ZZ * 1.8
                    Case 257, 258, 285, 634, 635 'forza
                        Convert = ZZ * NIUT
                    Case 19 To 28, 30, 262 To 265, 283, 284, 288, 295, 307 To 309, 312 To 316 'lungh
                        Convert = ZZ * inc
                    Case 281, 282, 754 'area
                        Convert = ZZ * inc * inc
                End Select
            Case 1
                Select Case i
                    Case 1, 2, 3, 7, 8, 9, 59 To 64, 67, 68, 81, 82, 97, 98, 107, 108, 133, 134, 201 To 204, 237, 238, 239, 240, 267, _
                         287, 277 To 280, 286, 287, 300 To 303, 323, 325, 330 To 343, 372 To 375, 492 To 534, 597, 598, 683, 690, 697, 704, 711, 733 To 746 'pressione
                        Convert = ZZ * psi
                    Case 12, 13, 35, 38, 244, 259, 260, 266, 274, 275, 276, 278, 280, 629, 630 'ammiss
                        Convert = System.Math.Abs(ZZ) * psi
                    Case 36, 37, 391 To 394 'kappa
                        Convert = ZZ / NIUT * inc
                    Case 4, 5, 6, 268, 272, 273, 304, 305, 322, 433 To 435, 594 To 596, 683, 690, 697, 704, 747, 764, 777 'temp
                        Convert = ZZ * 1.8 + 32
                    Case 32, 33, 269, 270, 319, 320 'momento
                        Convert = ZZ / NIUT / inc * 1000
                    Case 14, 15, 321, 324 'alfa
                        Convert = ZZ / 1.8
                    Case 257, 258, 285, 634, 635 'forza
                        Convert = ZZ / NIUT
                    Case 19 To 28, 30, 262 To 265, 283, 284, 288, 295, 307 To 309, 312 To 316 'lungh
                        Convert = ZZ / inc
                    Case 281, 282, 754 'area
                        Convert = ZZ / inc / inc
                End Select
        End Select
    End Function
    Private Function kDimension(ByVal i As Short) As String
        Select Case i
            Case 1, 2, 3, 7, 8, 9, 59 To 64, 67, 68, 81, 82, 97, 98, 107, 108, 133, 134, 201 To 204, 237, 238, 239, 240, 267, 287, 277 To 280, 286, 287, 300 To 303, 323, 330 To 343, 372 To 375, 492 To 534, 597, 598, 683, 690, 697, 704, 711, 733 To 746 'pressione
                Return UnitPress.Substring(1, UnitPress.Length - 2)
            Case 12, 13, 35, 38, 244, 259, 260, 266, 274, 275, 276, 278, 280, 629, 630 'ammiss
                Return UnitPress.Substring(1, UnitPress.Length - 2)
            Case 36, 37, 391 To 394 'kappa
                Return Unitkappa.Substring(1, Unitkappa.Length - 2)
            Case 4, 5, 6, 268, 272, 273, 304, 305, 322, 433 To 435, 594 To 596, 683, 690, 697, 704, 747, 764, 777 'temp
                Return UnitTemp.Substring(1, UnitTemp.Length - 2)
            Case 32, 33, 269, 270, 319, 320 'momento
                Return UnitMomF.Substring(1, UnitMomF.Length - 2)
            Case 14, 15, 321, 324 'alfa
                Return UnitTemp.Substring(1, UnitTemp.Length - 2)
            Case 257, 258, 285, 634, 635 'forza
                Return UnitForce.Substring(1, UnitForce.Length - 2)
            Case 19 To 28, 30, 262 To 265, 283, 284, 288, 295, 307 To 309, 312 To 316 'lungh
                Return UnitLength.Substring(1, UnitLength.Length - 2)
            Case 281, 282 'area
        End Select
    End Function
    Public Function kConvert(ByVal ZZ As Single, ByVal i As Short) As Single
        kConvert = ZZ
        Select Case i
            Case 1, 2, 3, 7, 8, 9, 59 To 64, 67, 68, 81, 82, 97, 98, 107, 108, 133, 134, 201 To 204, 237, 238, 239, 240, 267, 287, 277 To 280, 286, 287, 300 To 303, 323, 330 To 343, 372 To 375, 492 To 534, 597, 598, 683, 690, 697, 704, 711, 733 To 746 'pressione
                kConvert = ZZ / kPress
            Case 12, 13, 35, 38, 244, 259, 260, 266, 274, 275, 276, 278, 280, 629, 630 'ammiss
                kConvert = System.Math.Abs(ZZ) / kPress
            Case 36, 37, 391 To 394 'kappa
                kConvert = ZZ / kkappa
            Case 4, 5, 6, 268, 272, 273, 304, 305, 322, 433 To 435, 594 To 596, 683, 690, 697, 704, 747, 764, 777 'temp
                kConvert = (ZZ - kTemp32) / kTemp
            Case 32, 33, 269, 270, 319, 320 'momento
                kConvert = ZZ / kMomF
            Case 14, 15, 321, 324 'alfa
                kConvert = ZZ / kTemp
            Case 257, 258, 285, 634, 635 'forza
                kConvert = ZZ / kForce
            Case 19 To 28, 30, 262 To 265, 283, 284, 288, 295, 307 To 309, 312 To 316 'lungh
                kConvert = ZZ / kLength
            Case 281, 282 'area
        End Select
    End Function
    Public Function Convertk(ByRef ZZ As Single, ByRef i As Short) As Single
        Convertk = ZZ
        Select Case i
            Case 1, 2, 3, 7, 8, 9, 59 To 64, 67, 68, 81, 82, 97, 98, 107, 108, 133, 134, 201 To 204, 237, 238, 239, 240, 267, 287, 277 To 280, 286, 287, 300 To 303, 323, 330 To 343, 372 To 375, 492 To 534, 597, 598, 683, 690, 697, 704, 711, 733 To 746 'pressione
                Convertk = ZZ * kPress
            Case 12, 13, 35, 38, 244, 259, 260, 266, 274, 275, 276, 278, 280, 629, 630 'ammiss
                Convertk = System.Math.Abs(ZZ) * kPress
            Case 36, 37, 391 To 394 'kappa
                Convertk = ZZ * kkappa
            Case 4, 5, 6, 268, 272, 273, 304, 305, 322, 433 To 435, 594 To 596, 683, 690, 697, 704, 747, 764, 777 'temp
                Convertk = ZZ * kTemp + kTemp32
            Case 32, 33, 269, 270, 319, 320 'momento
                Convertk = ZZ * kMomF
            Case 14, 15, 321, 324 'alfa
                Convertk = ZZ * kTemp
            Case 257, 258, 285, 634, 635 'forza
                Convertk = ZZ * kForce
            Case 19 To 28, 30, 262 To 265, 283, 284, 288, 295, 307 To 309, 312 To 316 'lungh
                Convertk = ZZ * kLength
            Case 281, 282 'area
        End Select
    End Function
    Private Sub MinTempP()
        Dim StriSt(20) As String
        Dim i, iMat As Short
        Dim tgov, tgov1 As Single
        Dim Aspp, R, R2 As Single
        Dim jmemb As Short
        Dim tgov2, Aspp2 As Single
        Dim MWDTrule As String = ""
        Dim MWDTclause As String = ""
        Dim MWDTtemp As Single
        Dim YieldMWDT As Single
        Dim PNumber As String = ""
        Dim iGr As Short
        Dim Temper(2) As Single
        '1 piastra tubiera
        iMat = Involucr(kLato, jInvolucr).indice(1 - 1)
        With Mem
            If pt_Config.SoloDilat Then
                tgov = Involucr(kLato, jInvolucr).Spess / inc
                jmemb = 1
            Else
                tgov = .Z(1, 34) / 4 / inc : R = 0 : jmemb = -1
                If Not pt_Config.Gasketed(1 - 1) Or pt_Config.Rear = 3 Then
                    jmemb = 1
                    tgov1 = .Z(1, 23) / inc
                    If tgov1 > tgov And Config(1).NMWDT > 0 Then
                        tgov = tgov1 : R = .Z(1, 21) / 2 / inc : Aspp = .Z(1, 17) / inc
                        jmemb = 2 'lato shell
                    End If
                    If pt_Config.Flangiata(pt_Config.Side - 1) = 0 Or pt_Config.Rear = 3 And Config(2).NMWDT > 0 Then
                        tgov2 = .Z(1, 24) / inc
                        If tgov2 > .Z(1, 34) / inc / 4 Then
                            R2 = .Z(1, 22) / 2 / inc : Aspp2 = .Z(1, 18) / inc
                            jmemb = 3 'lato cassa
                        Else
                            tgov2 = .Z(1, 34) / inc / 4
                        End If
                    End If
                Else
                    jmemb = -1
                End If
            End If
            For i = 1 To Matdim(iMat).Caract.Count
                If Matdim(iMat).Caract.Item(i).TextData.Codice = CodiceStress() Then
                    MWDTrule = Matdim(iMat).Caract.Item(i).TextData.MWDTrule
                    MWDTclause = Matdim(iMat).Caract.Item(i).TextData.MWDTclause
                    MWDTtemp = Matdim(iMat).Caract.Item(i).TextData.MWDTtemp
                    YieldMWDT = Matdim(iMat).Caract.Item(i).TextData.Yield
                    PNumber = Matdim(iMat).Caract.Item(i).TextData.PNumber
                    iGr = GlobalRoutines.ValVir(Matdim(iMat).Caract.Item(i).TextData.Group)
                    GoTo ContMT
                End If
            Next
ContMT:     If NotApplicable(MWDTrule, StriSt) Then Exit Sub
            If InStr(MWDTrule, "CS") Then
                Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(StriSt(5), RTrim(MWDTrule), MWDTclause))  '"Low Temperature Operation. Rules: "
            ElseIf InStr(MWDTrule, "HA") Or InStr(MWDTrule, "NF") Or InStr(MWDTrule, "UHT") Or InStr(MWDTrule, "AQT") Then
                Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(StriSt(6), RTrim(MWDTrule)))  '"xxxxxxxxxxxx"
            Else
                Monitor.Motore.Problem.Printa(StriSt(7))
            End If
            .Z(1, 272) = Config(1).tdxMDMT(0) : .Z(1, 273) = Config(2).tdxMDMT(0)
            .Z(1, 304) = Config(1).tdxMDMT(1) : .Z(1, 305) = Config(2).tdxMDMT(1)
            .Z(1, 300) = Config(1).pdxMDMT(0) : .Z(1, 302) = Config(2).pdxMDMT(0)
            .Z(1, 301) = Config(2).pdxMDMT(1) : .Z(1, 303) = Config(2).pdxMDMT(1)
            If System.Math.Abs(jmemb) = 1 Then
                Temper(1) = .Z(1, 273) : Temper(2) = .Z(1, 305)
                If .Z(1, 272) < Temper(1) Then Temper(1) = .Z(1, 272)
                If .Z(1, 304) < Temper(2) Then Temper(2) = .Z(1, 304)
                '            Call MinTempCalc(1, (jInvolucr), R, (jmemb), Aspp, MWDTrule$, MWDTclause$, MWDTtemp!, tgov, YieldMWDT, PNumber$, iGr, " ", Temper())
                'e anche i seguenti
                Call MinTempCalc(0, (jInvolucr), R, (jmemb), Aspp, MWDTrule, MWDTclause, MWDTtemp, tgov, YieldMWDT, PNumber, iGr, " ", Temper)
            ElseIf jmemb = 2 Then
                Temper(1) = .Z(1, 272) : Temper(2) = .Z(1, 304)
                Call MinTempCalc(0, (jInvolucr), R, (jmemb), Aspp, MWDTrule, MWDTclause, MWDTtemp, tgov, YieldMWDT, PNumber, iGr, " ", Temper)
            Else
                Temper(1) = .Z(1, 272) : Temper(2) = .Z(1, 304)
                Call MinTempCalc(0, (jInvolucr), R, (jmemb), Aspp, MWDTrule, MWDTclause, MWDTtemp, tgov, YieldMWDT, PNumber, iGr, " ", Temper)
                jmemb = 4
                Temper(1) = .Z(1, 273) : Temper(2) = .Z(1, 305)
                Call MinTempCalc(0, (jInvolucr), R2, (jmemb), Aspp2, MWDTrule, MWDTclause, MWDTtemp, tgov2, YieldMWDT, PNumber, iGr, " ", Temper)
            End If
        End With
    End Sub
    Private Sub UnitMis(ByRef Forma As String, ByRef i1 As Short, ByRef i2 As Short)
        Dim i As Short
        If pt_Config.US = 2 Then Exit Sub '0 SI 1 bastardo 2 BR
        i = i1
        iStart = InStr(23, Forma, "[")
        If iStart = 0 Then
            iStart = InStr(23, Forma, "³")
            iEnd = InStr(iStart + 1, Forma, "³") - 1
        Else
            iEnd = InStr(iStart + 1, Forma, "]") - 1
        End If
        i3 = iEnd - iStart
        iStart = iStart + 1
        If iStart > 1 And i3 > 2 Then Riscri(i, Forma)
        i = i2
        iStart = InStr(62, Forma, "[")
        If iStart = 0 Then
            iStart = InStr(62, Forma, "³")
            iEnd = InStr(iStart + 1, Forma, "³") - 1
        Else
            iEnd = InStr(iStart + 1, Forma, "]") - 1
        End If
        i3 = iEnd - iStart
        iStart = iStart + 1
        If iStart > 1 And i3 > 2 Then Riscri(i, Forma)
    End Sub
    Private Sub Riscri(ByVal i As Integer, ByRef Forma As String)
        Dim nt As String = ""
        Select Case i
            Case 1, 2, 3, 7, 8, 9, 59, 60, 61, 62, 63, 64, 81, 82, 107, 108, 133, 134, 201, 202, 203, 204, 237, 238, 239, 240, 267, 287, 277, 279, 300, 301, 302, 303 'pressione
                nt = "MPa"
            Case 12, 13, 35, 38, 244, 259, 260, 266, 274, 275, 276, 278, 280 'ammiss
                If pt_Config.US = 1 Then nt = "" Else nt = "MPa"
            Case 36, 37 'kappa
                nt = "N/mm"
            Case 4, 5, 6, 268, 272, 273, 304, 305, 594, 595, 596, 1594, 1595, 1596, 747, 1747, 322, 1322, 777, 764 'temp
                nt = "°C "
            Case 32, 33, 269, 270 'momento
                nt = "Nm "
            Case 14, 15 'alfa
                nt = "1/C"
            Case 285 'forza
                nt = "N  "
            Case 19 To 28, 30, 262 To 265, 283, 284, 288, 295, 307 To 309, 312 To 316 'lungh
                nt = "mm"
        End Select
        If Len(nt) > 0 Then Forma = Left(Forma, iStart - 1) & nt & Right(Forma, Len(Forma) - iEnd)
    End Sub
    Sub ValoriPiastra(ByRef Thkk As Single, ByRef ThkExt As Single, ByRef Piastra As String)
        Thkk = Mem.Z(1, 34)
        If pt_Config.Differing < 2 Then
            Piastra = " "
            Thkk = Mem.Z(1, 34) : ThkExt = Mem.Z(1, 288)
        Else
            If pt_Config.Side = 2 Then
                Piastra = "TUBESHEET B"
                Thkk = Mem.Z(1, 262) : ThkExt = Mem.Z(1, 289)
            Else
                Piastra = "TUBESHEET A"
                Thkk = Mem.Z(1, 34) : ThkExt = Mem.Z(1, 288)
            End If
        End If
    End Sub
    Public Sub RisPAGINA(ByRef i As Short)
        Dim ifl, ii As Short
        Dim Piastra As String = ""
        Dim Rig As String
        Dim ifin, iRig As Short
        Dim Ext As String = ""
        Dim Nome As String = ""
        Select Case CalcoloInCorso
            Case 0 : Ext = ".FTC"
            Case 1
                Select Case Padre.TipoAA
                    Case Is < 5
                        Ext = "AA.FTC"
                    Case Else
                        If i = 1 Then
                            Ext = "AA5.FTC"
                        Else
                            Ext = "AA.FTC"
                            If UltimoAggiornamento > 2 And i < 3 Then Ext = "AA2.FTC"
                        End If
                End Select
        End Select
        ifl = FreeFile()
        Select Case i
            Case 1
                If pt_Config.Differing < 2 Then
                    Piastra = "       "
                Else
                    If pt_Config.Side = 1 Then Piastra = " LATO A" Else Piastra = " LATO B"
                End If
                Nome = RTrim(Monitor.Motore.Inizio.Archdir) & "\WN5\PAG1" & Ext
                ifin = 4
            Case 2
                Piastra = " "
                Nome = RTrim(Monitor.Motore.Inizio.Archdir) & "\WN5\PAG2" & Ext
                ifin = 3
            Case 3
                Piastra = " "
                Nome = RTrim(Monitor.Motore.Inizio.Archdir) & "\WN5\PAG3" & Ext
                ifin = 4
            Case 4
                Piastra = " "
                Nome = RTrim(Monitor.Motore.Inizio.Archdir) & "\WN5\PAG4" & Ext
                ifin = 4
        End Select
        If Not OpenFile(Nome, ifl) Then Exit Sub
        With mioRis
            .Rinnova()
            For ii = 1 To ifin
                Rig = LineInput(ifl)
                iRig = iRig + 1
                .Scrivi(Rig, iRig)
            Next
            Rig = LineInput(ifl)
            iRig = iRig + 1
            '  FormatS "non|"
            .Scrivi(GlobalRoutines.FormatS(Rig, Piastra), iRig)
            Do
                Rig = LineInput(ifl)
                If GlobalRoutines.ValVir(Rig) = -1 Then Exit Do
                iRig = iRig + 1
                .Scrivi(Rig, iRig)
            Loop
        End With
        FileClose(ifl)
    End Sub
    Sub FattUs(Optional ByRef Super As Boolean = False, Optional ByRef NonMostrare As Boolean = False, Optional ByRef f As Single = 0)
        Dim i, iCorr As Short
        Dim Stringa(14) As String
        Dim Rig As String
        Dim j As Short
        Dim fact As Single
        Dim TrazT, FattP, TrazM As Single
        Dim CompM, CompT, Giunt As Single
        Dim kkn, kk As Short
        Dim DilaI1, DilaI2 As Single
        Dim DilaF, DilaP As Single
        Dim kk1 As Short
        Dim Testo As String
        Dim s As Single
        Dim inizio, Fine As Short
        Dim Radice As Single
        Dim NonDet As Boolean
        Try
            With Mem
                If .Z(1, 261) = 0 Then i = iCond Else i = 1
                inizio = i : Fine = i
                If Super Then inizio = 1 : Fine = .Z(1, 261)
                If .Z(1, 26) > 0 And pt_Config.Rear = 1 Then Danno = objDilat.Danno(.Z(1, 261))
                For i = inizio To Fine
599:                For iCorr = 0 To 1
                        If icMAWP = 0 Or Condit < 3 And iCorr = 0 Or Condit > 2 And iCorr = 1 Then
                            If Not pt_Config.SoloDilat Then
                                If Problem(IndProbl).PDIFF = 1 Then j = 0 Else j = 8
                                fact = 1
                                If CalcoloInCorso = 1 Then
                                    If Padre.TipoAA > 4 Then NonDet = True
                                    fact = 3
                                End If
                                If pt_Config.Differing > 1 Then
                                    If .Z(i, 161 + iCorr + j) > 0 And Not CalcoloInCorso = 1 Then
                                        If .Z(i, 161 + iCorr + j) / .Z(1, 34) > FattP Then FattP = .Z(i, 161 + iCorr + j) / .Z(1, 34)
                                        If .Z(i + 8, 161 + iCorr + j) / .Z(1, 262) > FattP Then FattP = .Z(i + 8, 161 + iCorr + j) / .Z(1, 262)
                                    Else
                                        If .Z(i, 537 + iCorr) > FattP Then FattP = .Z(i, 537 + iCorr)
                                        If .Z(i + 8, 537 + iCorr) > FattP Then FattP = .Z(i + 8, 537 + iCorr)
                                    End If
                                Else
                                    NonDet = False
                                    '   If NonDet Then
                                    If CalcoloInCorso = 1 Then
                                        If .Z(i, 537 + iCorr) > FattP Then FattP = .Z(i, 537 + iCorr)
                                        If .Z(i, 769 + iCorr) > FattP Then FattP = .Z(i, 769 + iCorr)
                                    Else
600:                                    If .Z(1, 34) > 0 Then
                                            If .Z(i, 161 + iCorr + j) / .Z(1, 34) > FattP Then FattP = .Z(i, 161 + iCorr + j) / .Z(1, 34)
                                        End If
                                    End If
                                End If
                                If pt_Config.Rear = 1 Or pt_Config.Rear = 2 And CalcoloInCorso = 1 Then
                                    Radice = .Z(i, 237 + iCorr) / .Z(i, 13)
610:                                If Radice > TrazT Then TrazT = Radice
                                    If .Z(i, 244) > 0 Then
                                        Radice = Math.Abs(.Z(i, 239 + iCorr) / .Z(i, 244))
                                        If Radice > CompT Then CompT = Radice
                                    End If
                                    .Z(i, 765 + iCorr) = Math.Max(TrazT, CompT)
                                    If CalcoloInCorso = 0 Then
                                        Radice = .Z(i, 201 + iCorr) / .Z(i, 12)
                                        If Radice > TrazM Then TrazM = Radice
                                    Else
                                        If .Z(i, 496) > 0 Then
                                            Radice = .Z(i, 492 + iCorr) / .Z(i, 496)
                                            If Radice > TrazM Then TrazM = Radice
                                        End If
                                        If .Z(i, 497) > 0 Then
                                            Radice = .Z(i, 494 + iCorr) / .Z(i, 497)
                                        Else
                                            Radice = 0
                                        End If
                                        If Radice > TrazM Then TrazM = Radice
                                    End If
                                    If System.Math.Abs(.Z(i, 259)) > 0 Then
                                        Radice = System.Math.Abs(.Z(i, 203 + iCorr) / .Z(i, 259))
                                        If Radice > CompM Then CompM = Radice
                                    End If
                                    If .Z(i, 285) > 0 Then
                                        Radice = System.Math.Abs(.Z(i, 257 + iCorr)) / .Z(i, 285)
                                        If Radice > Giunt Then Giunt = Radice
                                    End If
                                    .Z(i, 767 + iCorr) = Giunt
                                End If
                            End If
                        End If
                    Next iCorr
                    If .Z(1, 26) > 0 And pt_Config.TipoDilat < 7 And pt_Config.Rear = 1 Then
                        For iCorr = 1 To 2
                            If icMAWP = 0 Or Condit < 3 And iCorr = 1 Or Condit > 2 And iCorr = 2 Then
                                If pt_Config.SoloDilat < 3 Or pt_Config.SoloDilat = 6 Then kkn = 7 Else kkn = 5
                                kk1 = 1 : If EscludiSez1 Then kk1 = 2
                                For kk = kk1 To kkn
                                    objDilat.FattUs(iCorr, i, kk, DilaP, s)
                                Next kk
                                s = s / .Z(i, 274) : If s > DilaP Then DilaP = s
                            End If
                        Next iCorr
                    End If
                    If pt_Config.TipoDilat > 2 And pt_Config.TipoDilat < 6 And pt_Config.Rear = 1 Then
                        objDilat.FattUs1(i, icMAWP, Condit, DilaI1, DilaI2)
                    End If
                Next i
            End With
630:        If icMAWP = 0 Then DilaF = Danno Else DilaF = 0
            fatt(1) = FattP * 100
            fatt(2) = TrazT * 100
            fatt(3) = CompT * 100
            fatt(4) = TrazM * 100
            fatt(5) = CompM * 100
            fatt(6) = Giunt * 100
            fatt(7) = DilaP * 100
            fatt(8) = DilaF * 100
            fatt(9) = DilaI1 * 100
            fatt(10) = DilaI2 * 100
            f = 0
            For i = 1 To 10
                If fatt(i) > f Then f = fatt(i)
            Next
            f = f / 100
            If OptimDil Or NonMostrare Then Exit Sub
            For i = 1 To 3
                Rig = Helpstringa(4999 + i)
                Stringa(i) = vbCrLf & Rig
            Next
            For i = 1 To 10
                Rig = Helpstringa(5002 + i)
                If i = 1 And pt_Config.Differing > 1 Then
                    Rig = Helpstringa(5002 + 12)
                End If
                Stringa(i + 3) = vbCrLf & Rig.Substring(0, 25) & GlobalRoutines.myStr(fatt(i), 4, 1, False) & Rig.Substring(Rig.Length - 1, 1)
            Next
            Stringa(14) = vbCrLf & Helpstringa(5002 + 11)
            Nf = 14
            If Mem.Z(1, 26) > 0 Then
                Comprimi(Stringa)
            Else
                If pt_Config.Rear = 1 Or pt_Config.Rear = 2 And CalcoloInCorso = 1 Then Nf = 10 Else Nf = 5
                Stringa(Nf) = Stringa(14)
            End If
            If icMAWP = 0 Then
                Testo = ""
                For i = 1 To Nf
                    Testo = Testo & Stringa(i)
                Next
                GlobalRoutines.FormatS("|")
                With frmFattUs.DefInstance
                    .mygraphics.DrawString(Testo, .myfont, .mybrush, .x, .y)
                    .ShowDialog()
                    .Dispose()
                End With
            End If
            Nf = Nf - 4
            If pt_Config.Rear = 3 Then Nf = 1
            GlobalRoutines.FormatS("non|")
        Catch e As Exception
            MessageBox.Show(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Private Sub Comprimi(ByRef Stringa() As String)
        Dim i As Integer
        If pt_Config.SoloDilat Then
            For i = 1 To 5
                Stringa(i + 3) = Stringa(i + 9)
                If i < 5 Then fatt(i) = fatt(i + 6)
            Next
            Nf = Nf - 6
        End If
        Select Case pt_Config.TipoDilat
            Case 4 : Stringa(Nf - 1) = Stringa(Nf) : Nf = Nf - 1
            Case 1, 2, 5, 6 : Stringa(Nf - 2) = Stringa(Nf) : Nf = Nf - 2
        End Select
    End Sub
    Public Sub StampaDil(ByRef Capitolo As Boolean)
        Dim Tipo As String = ""
        Dim Rtf As String = ""
        Dim ifl As Short
        If Capitolo Then If Not PrepRapp(Template, "Dilatatore", Trim(Involucr(kLato, jInvolucr).Mark), FileSt, mioApert.lstRapp) Then Exit Sub
        Stringa(1) = "Annealed condition (without cold work)"
        Stringa(2) = "As-formed condition (with cold work)"
        Stringa1(1) = "UNREINFORCED BELLOWS"
        Stringa1(2) = "BELLOWS WITH INTEGRAL REINFORCING RINGS"
        Stringa1(3) = "BELLOWS WITH EQUALIZING RINGS JOINED BY FASTENERS"
        If pt_Config.SoloDilat Then
            jDilat = jInvolucr
            kDilat = kLato
        Else
            jDilat = pt_Config.IndiceDilat
            kDilat = 1
        End If
        indice = Involucr(kDilat, jDilat).indice(1 - 1)
        Select Case pt_Config.TipoDilat
            Case 3, 4, 5
                Tipo = Stringa1(pt_Config.TipoDilat - 2)
            Case 1
                Tipo = "FLUED, OF UNIFORM THICKNESS"
            Case 2
                Tipo = "FLANGED"
            Case 6
                Tipo = "FLUED, OF DIFFERING THICKNESSES"
        End Select
        iCond = 1
        ifl = FreeFile()
        Rtf = "\RTF"
        If pt_Config.TipoDilat < 3 Or pt_Config.TipoDilat = 6 Then
            Nome = RTrim(Monitor.Motore.Inizio.Archdir) & Rtf & "\STAINPDI.FTC"
        Else
            Nome = RTrim(Monitor.Motore.Inizio.Archdir) & Rtf & "\STAINPEJ.FTC"
        End If 'a
        If Not OpenFile(Nome, ifl) Then Exit Sub
5020:   LegScrDil(Tipo)
        FileClose(ifl)
        If pt_Config.SoloDilat Then
            For iCond = 1 To Mem.Z(1, 261)
                If pt_Config.SoloDilat Then
                    Nome = RTrim(Monitor.Motore.Inizio.Archdir) & Rtf & "\STAINP3E.FTC"
                Else
                    Nome = RTrim(Monitor.Motore.Inizio.Archdir) & Rtf & "\STAINP3.FTC"
                End If 'b
                If Not OpenFile(Nome, ifl) Then Exit Sub
5030:           LegScrDil(Tipo)
                FileClose(ifl)
            Next
        Else
            Monitor.Motore.Problem.Printa("\par      Please report to the tubesheet calculation\par")
            Contarig = Contarig + 4
        End If 'c
5040:   Call SintSpDil()
    End Sub
    Private Sub LegScrDil(ByVal Tipo As String)
        If Contarig > 68 Then Call FinePag(0)
        Do
10540:      If EOF(ifl) Then
                FileClose(ifl)
                Exit Sub
            End If
            Rig = LineInput(ifl)
            Rig1 = Mid(Rig, 1, 1)
            If Rig1 = "B" Then
                Contarig = Contarig + 1
                Par = "\par "
                Monitor.Motore.Problem.Printa(Par)
                GoTo 10540
            End If 'd
            If Rig1 = "F" Then
                FileClose(ifl)
                Exit Sub
            End If
            If Rig1 = "T" Then
                Call Testatap() : GoTo 10540
            End If
            T2T2 = Mid(Rig, 2, 3)
            Posi = GlobalRoutines.ValVir(T2T2)
            If GlobalRoutines.ValVir(Rig1) = 6 Or Rig1 = "D" Then
                Posi2 = GlobalRoutines.ValVir(Mid(Rig, 5, 3))
                T3 = Right(Rig, Len(Rig) - 7)
            ElseIf GlobalRoutines.ValVir(Rig1) = 7 Then
                Posi2 = GlobalRoutines.ValVir(Mid(Rig, 5, 3))
                Posi3 = GlobalRoutines.ValVir(Mid(Rig, 8, 3))
                Posi4 = GlobalRoutines.ValVir(Mid(Rig, 11, 3))
                T3 = Right(Rig, Len(Rig) - 13)
            Else
                Posi2 = 0
                T3 = Right(Rig, Len(Rig) - 4)
            End If 'e
            With Mem
                Select Case Rig1
                    Case "0"
                        If Posi < 15 Or pt_Config.TipoDilat = 1 Then
                            Monitor.Motore.Problem.Printa("    " & T3)
                        Else
                            Contarig = Contarig - 1
                        End If 'f
                    Case "1"
                        If Posi = 281 And pt_Config.TipoDilat = 3 Then GoTo ContL
                        Monitor.Motore.Problem.Printa(Space(4) & GlobalRoutines.FormatS(T3, .Z(Offset + iCond, Posi)))
                    Case "2" : Monitor.Motore.Problem.Printa(Space(4) & GlobalRoutines.FormatS(T3, .Z(Offset + iCond, Posi), .Z(Offset + iCond, Posi) / inc))
                    Case "4" : Monitor.Motore.Problem.Printa(Space(4) & GlobalRoutines.FormatS(T3, .Z(Offset + iCond, Posi), .Z(Offset + iCond, Posi + 1), .Z(Offset + iCond, 12)))
                    Case "5" : Monitor.Motore.Problem.Printa(Space(4) & GlobalRoutines.FormatS(T3, .Z(Offset + iCond, Posi), .Z(Offset + iCond, Posi + 1), .Z(Offset + iCond, 13)))
                    Case "6"
                        If Posi = 282 And pt_Config.TipoDilat < 5 Then GoTo ContL
                        Monitor.Motore.Problem.Printa(Space(4) & GlobalRoutines.FormatS(T3, .Z(Offset + iCond, Posi), .Z(Offset + iCond, Posi2)))
                    Case "7" : Monitor.Motore.Problem.Printa(Space(4) & GlobalRoutines.FormatS(T3, .Z(Offset + iCond, Posi), .Z(Offset + iCond, Posi2), .Z(Offset + iCond, Posi3), .Z(Offset + iCond, Posi4)))
                    Case "A" : Monitor.Motore.Problem.Printa(Space(4) & GlobalRoutines.FormatS(T3, .Z(Offset + iCond, Posi), .Z(Offset + iCond, Posi + 1)))
                    Case "C" : Monitor.Motore.Problem.Printa(Space(4) & GlobalRoutines.FormatS(T3, .Z(Offset + iCond, Posi) * inc, .Z(Offset + iCond, Posi + 1) * inc))
                    Case "D"
                        ic = Posi
                        objDilat.Cerca(ic, s, pt_Config.TipoDilat)
                        s1 = s
                        ic = Posi2
                        objDilat.Cerca(ic, s, pt_Config.TipoDilat)
                        s2 = s
                        If ic < 15 Or pt_Config.TipoDilat < 3 Or pt_Config.TipoDilat = 6 Then
                            If s1 <> 0 Or s2 <> 0 Then Monitor.Motore.Problem.Printa(Space(4) & GlobalRoutines.FormatS(T3, s1, s2)) Else Contarig = Contarig - 1
                        Else
                            Contarig = Contarig - 1
                        End If 'g
                    Case "E"
                        ic = Posi
                        objDilat.Cerca(ic, s, pt_Config.TipoDilat)
                        If s <> 0 Then Monitor.Motore.Problem.Printa(Space(4) & GlobalRoutines.FormatS(T3, s)) Else Contarig = Contarig - 1
                    Case "K" : Monitor.Motore.Problem.Printa(Space(4) & GlobalRoutines.FormatS(T3, iCond, Mem.Condizio(iCond)))
                    Case "L" : Monitor.Motore.Problem.Printa(Space(4) & GlobalRoutines.FormatS(T3, Int(.Z(1, 261))))
                    Case "M"
                        If Posi > 7 Then '!!!!!!!!!!!!!!!!!!!!!!!!
                            Nome = "  "
                            If Posi = 9 And pt_Config.TipoDilat = 3 Then GoTo ContL
                            If Posi = 10 And pt_Config.TipoDilat < 5 Then GoTo ContL
                            'Else
                            indice = Involucr(kDilat, jDilat).indice(Posi - 6 - 1)
                        Else
                            Nome = Involucr(kDilat, jDilat).Mark
                            If Asc(Nome) < 32 Then Nome = "NOT DEFINED"
                            If Len(RTrim(Nome)) = 0 Then Nome = "NOT DEFINED"
                        End If 'h
                        Nome1 = Matdim(indice).MatStr
                        If Asc(Nome) < 32 Then Nome = "NOT DEFINED"
                        If Len(RTrim(Nome1)) = 0 Then Nome1 = "NOT DEFINED"
                        Monitor.Motore.Problem.Printa(Space(4) & GlobalRoutines.FormatS(T3, Nome, Nome1))
                    Case "N" : Monitor.Motore.Problem.Printa(Space(4) & GlobalRoutines.FormatS(T3, Tipo))
                    Case "O"
                        Dim i As Integer
                        If pt_Config.Ricotto Then i = 1 Else i = 2
                        Monitor.Motore.Problem.Printa(Space(4) & GlobalRoutines.FormatS(T3, Stringa(i)))
                End Select 'r
            End With
            Contarig = Contarig + 1
ContL:  Loop
    End Sub
    Sub SintSpDil()
        Dim IndVar(2) As Short
        If pt_Config.TipoDilat = 7 Then Exit Sub
        Try
            GlobalRoutines.FormatS("non|")
            Rtf = "\RTF"
            If pt_Config.TipoDilat < 3 Or pt_Config.TipoDilat = 6 Then
                FilePTF = "\PTFF05.FTC" 'psi
                If pt_Config.US = 0 Then FilePTF = "\PTFF06.FTC" 'MPa
            Else
                FilePTF = "\PTFFEJ.FTC"
                If pt_Config.US = 0 Then FilePTF = "\PTFFEK.FTC"
            End If
            StampTab2()
            GlobalRoutines.FormatS("|")
        Catch e As Exception
            MessageBox.Show(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    '            Exit Sub
    'PrTab1:
    '            '----------------------------------------------------
    '            For j = 1 To 50
    '            Input(ifl, Rig)
    '            Input(ifl, IndVar(1))
    '            Input(ifl, IndVar(2))
    '            Input(ifl, iRig)
    '            Select Case j
    '                Case Is > 37, 36, 35, 29, 7 : Contarig = Contarig + 1 : Monitor.Motore.Problem.Printa(Rig)
    '                Case 37 'danno totale
    '            ' Danno = objDilat.Danno((Z(1, 261)))
    '            Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(Rig, Danno))
    '                Case Else
    '            Monitor.Motore.Problem.Print(Left(Rig, 30))
    '            For i = iStart To iEnd
    '            For k = 1 To 2
    '            Rig1 = Mid(Rig, 31 + (2 * (i - iStart) + k - 1) * 7, 7)
    '            If IndVar(k) > 0 Then
    '            s = Mem.Z(Offset + i, IndVar(k))
    '            Else
    '                Select Case j
    '                    Case 6 'delta
    '            PSP = Mem.Z(i, 66 + k)
    '            objDilat.Cerca1(k, i, PSP, Fax, 1, pt_Config.TipoDilat)
    '            objDilat.Cerca1(k, i, s, Fax, 2, pt_Config.TipoDilat)
    '                    Case 31 'Nø of events
    '            n = Mem.Neventi(i)
    '                    Case Else 'Scmp,Smmp
    '            objDilat.Cerca2(i, k, j, s, Cod, n, Offset)
    '                End Select 'l
    '            End If
    '            Select Case j
    '                Case 31, 33
    '            Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(Rig1, n))
    '                Case 32
    '            Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(Rig1, Cod))
    '                Case Else
    '900:        Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(Rig1, s))
    '            End Select 'm
    '            Next k
    '            Next i
    '            CompletaSpDil()
    '            End Select 'n
    '            Next j
    '            '----------------------------------------------------
    '            'UPGRADE_WARNING: Return ha un nuovo comportamento. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1041"'
    '            Return
    'PrTab2:
    '            '----------------------------------------------------
    '            For j = 1 To 29
    '            Input(ifl, Rig)
    '            Input(ifl, IndVar(1))
    '            Input(ifl, IndVar(2))
    '            Select Case j
    '                Case 2, 29, 23, 7 : Contarig = Contarig + 1 : Monitor.Motore.Problem.Printa(Rig)
    '                Case Else
    '            Monitor.Motore.Problem.Print(Left(Rig, 30))
    '            For i = iStart To iEnd
    '            For k = 1 To 2
    '820:        Rig1 = Mid(Rig, 31 + (2 * (i - iStart) + k - 1) * 7, 7)
    '            If IndVar(k) > 0 Then
    '825:        s = Mem.Z(Offset + i, IndVar(k))
    '            Else
    '                Select Case j
    '                    Case 25 'Nø of events
    '            n = Mem.Neventi(i)
    '                    Case 16 : s = Mem.Z(i, 276)
    '                    Case 18 : s = Mem.Z(i, 278)
    '850:        If pt_Config.TipoDilat < 4 Then s = 0
    '                    Case 20 : s = Mem.Z(i, 280)
    '            If pt_Config.TipoDilat < 5 Then s = 0
    '                    Case Else
    '            objDilat.Cerca4(j, s, k, i, pt_Config.TipoDilat, Cod, n)
    '                End Select 'o
    '            End If
    '            Select Case j
    '                Case 25, 27
    '            Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(Rig1, n))
    '                Case 26
    '            Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(Rig1, Cod))
    '                Case Else
    '901:        If System.Math.Abs(s) > 0 Then
    '            Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(Rig1, s))
    '            Else
    '                Call Pulisci(Rig1)
    '                Monitor.Motore.Problem.Print(Rig1)
    '            End If
    '            End Select 'p
    '            Next k
    '            Next i
    '            CompletaSpDil()
    '            End Select 'q
    '            Next j
    '            '----------------------------------------------------
    '            'UPGRADE_WARNING: Return ha un nuovo comportamento. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1041"'
    '            Return
    '    Private Sub CompletaSpDil()
    '        If iEnd - iStart + 1 < 4 Then
    '            For ii = 2 * (iEnd - iStart + 1) + 1 To 8
    '                Rig1 = Mid(Rig, 31 + (ii - 1) * 7, 7)
    '                Call Pulisci(Rig1)
    '                Monitor.Motore.Problem.Print(Rig1)
    '            Next
    '            Contarig = Contarig + 1 : Monitor.Motore.Problem.Printa(Nulla)
    '        Else
    '            Contarig = Contarig + 1 : Monitor.Motore.Problem.Printa(Nulla)
    '        End If
    '    End Sub
    Private Sub StampTab2()
330:    Call FinePag(0)
        ifl = FreeFile()
        Nome = RTrim(Monitor.Motore.Inizio.Archdir) & Rtf & FilePTF
        If Not OpenFile(Nome, ifl) Then Exit Sub
        iCond = 1
        Call objDilat.Assumi(ifl)
        If Mem.Z(1, 261) > 4 Then
            Call FinePag(3)
            FileClose(ifl)
            Nome = RTrim(Monitor.Motore.Inizio.Archdir) & Rtf & FilePTF
            If Not OpenFile(Nome, ifl) Then Exit Sub
            iCond = 5
            Call objDilat.Assumi(ifl)
        End If
        FileClose(ifl)
    End Sub
    Private Function CalcFK(ByRef iSide As Short, ByRef t As Single, ByRef GG As Single, ByRef f As Single, ByRef fc As Single, ByRef k As Single, ByRef KC As Single) As Boolean
        Dim Log1, Log2 As Boolean 'non teste fisse
        Dim wn As wn_flan
        On Error GoTo errCFK
        CalcFK = True
        If iSide = 1 Then
            Call Table7132(t)
            'calcolo fattore F
            If pt_Config.Gasketed(1 - 1) = 0 Then
                If pt_Config.Rear < 3 Then
                    Log1 = (Ds = 0 Or DC = 0)
                    If Not Log1 Then Log2 = ts / Ds > tc / DC
                    If pt_Config.Flangiata(1 - 1) = -1 Then
                        GG = Ds
                        t = ts
                        COR = cscod(iSide)
                    ElseIf pt_Config.Flangiata(1 - 1) = 1 Then
                        GG = DC
                        t = tc
                        COR = ctcod(iSide)
                    Else
                        If Log1 Then
                            MessageBox.Show(mioRis, "I diametri lato cassa e/o lato mantello" & vbCrLf & "non sono stati definiti")
                            CalcFK = False
                            Exit Function
                        End If
                        If Log2 Then
                            GG = Ds
                            t = ts
                            COR = cscod(iSide)
                        Else
                            GG = DC
                            t = tc
                            COR = ctcod(iSide)
                        End If
                    End If
                    kkC2()
                    Mem.Z(iCond, 40) = GG '* inc
                    Mem.Z(iCond, 41) = t '* inc
                    Mem.Z(iCond, 42) = COR '* inc
                    Mem.Z(iCond, 43) = k
                    Mem.Z(iCond, 44) = KC
                End If
710:            If pt_Config.Rear = 3 Then 'U-tube
                    f = f * 1.25
                    fc = fc * 1.25
                    If f = 0 Then f = 1.25 : fc = 1.25
                Else
                    If pt_Config.Gasketed(1 - 1) <> 0 Then
                        f = 1
                        fc = 1
                    End If
                End If
            Else 'biflangiata
                If pt_Config.Rear = 3 Then 'U-tube
                    f = 1.25
                    fc = 1.25
                Else
                    f = 1
                    fc = 1
                End If
            End If
            Mem.Z(iCond, 45) = f
            Mem.Z(iCond, 46) = fc
        Else
            Select Case pt_Config.Flottante
                Case 1 'P - outside packed
                    f = 1
                    fc = 1
                    GG = Mem.Z(1, 40) ' / inc
                Case 2 'S - with back-ring
                    f = 1
                    fc = 1
                    GG = Mem.Z(1, 40) ' / inc
                Case 3 'T - Flanged
                    f = 1
                    fc = 1
                    GG = Mem.Z(1, 40)
                    If pt_Config.IndiceFlanF > 0 Then
                        wn = objMemb(Involucr(3, pt_Config.IndiceFlanF).IndObject)
                        If Not wn Is Nothing Then If wn.Mp(37) > GG Then GG = wn.Mp(37)
                    End If
                    GG = GG '/ inc
                Case 4 'T - integral
                    If DC = 0 Then
                        MessageBox.Show(mioRis, "Il diametro interno lato tubi del flottante" & vbCrLf & "non è stati definito")
                        CalcFK = False
                        Exit Function
                    End If
                    GG = DC
                    t = tc
                    COR = ctcod(iSide)
                    kkC2()
                Case 5 'W - internally sealed
                    f = 1
                    fc = 1
                    GG = Mem.Z(1, 40) ' / inc
            End Select
            Mem.Z(iCond, 310) = f
            Mem.Z(iCond, 311) = fc
            Mem.Z(1, 310) = f
            Mem.Z(1, 311) = fc
            Mem.Z(1, 593) = GG '* inc
        End If
        Exit Function
errCFK: MessageBox.Show(Err.Description & Str(Err.Number))
        'Stop
        'Resume
    End Function
    Private Sub kkC2()
        k = t / GG
        KC = (t - COR) / (GG + 2 * COR)
        If k <= 0.02 Then f = 1
        If KC <= 0.02 Then fc = 1
        If k >= 0.05 Then f = 0.8
        If KC >= 0.05 Then fc = 0.8
        If (k > 0.02 And k < 0.05) Then f = (17 - 100 * k) / 15
        If (KC > 0.02 And KC < 0.05) Then fc = (17 - 100 * KC) / 15
    End Sub
    Private Sub AggiustaC(ByRef i As Short)
        Dim R As String
        Dim n As Short
        Dim Ind, Off As Short
        With mioRis
            If .AltriDati Then
                If iAggiustaC < 100 Then iAggiustaC = 100
                If i - 16 + 100 < iAggiustaC Then iAggiustaC = 100
            Else
                If iAggiustaC = 0 Then iAggiustaC = 1
                If i < iAggiustaC Then iAggiustaC = 1
            End If
            R = Right(tdim(i), Len(tdim(i)) - 1)
            n = InStr(R, "³")
            .Descrizione(iAggiustaC).Text = Left(R, n - 1)
            If Not Tool1(i) Is Nothing Then
                If Tool1(i).Trim.Length > 0 Then
                    .ToolTip1.SetToolTip(.Descrizione(iAggiustaC), Tool1(i))
                    .ToolTip1.SetToolTip(.Dimensioni(iAggiustaC), Tool1(i))
                    .ToolTip1.SetToolTip(.Valore(iAggiustaC), Tool1(i))
                End If
            End If
            .Valore(iAggiustaC).Tag = Str(IndVar(i, 1))
            If IndVar(i, 1) > 0 Then
                R = Right(R, Len(R) - n)
                n = InStr(R, "³")
                Ind = GlobalRoutines.ValVir(.Valore(iAggiustaC).Tag)
                If Ind > 1000 Then
                    Ind = Ind - 1000
                    Off = 8
                End If
                .Dimensioni(iAggiustaC).Text = kDimension(Ind) ' Left(R, n - 1)
                If InStr(R, "N/mm") > 0 Then
                    .Dimensioni(iAggiustaC).Width = GlobalRoutines.TwipsToPixelsX(650)
                End If
                R = Right(R, Len(R) - n)
                n = InStr(R, "³")
                .Descrizione(iAggiustaC).Tag = Left(R, n - 1)
                ContrInd(IndVar(i, 1)) = iAggiustaC
                AggTxt(IndVar(i, 1))
                .Descrizione(iAggiustaC).BackColor = System.Drawing.Color.Yellow
            Else
                .Descrizione(iAggiustaC).BackColor = System.Drawing.Color.Red
                R = Right(R, Len(R) - n)
                n = InStr(R, "³")
                R = Right(R, Len(R) - n)
                n = InStr(R, "³")
            End If
            If IndVar(i, 1) = 0 Then .Valore(iAggiustaC).Tag = ""
            R = Right(R, Len(R) - n)
            n = InStr(R, "³")
            If n = 0 Then n = Len(R)
            .Descrizione(iAggiustaC + 16).Text = Left(R, n - 1)
            If Not Tool2(i) Is Nothing Then
                If Tool2(i).Trim.Length > 0 Then
                    .ToolTip1.SetToolTip(.Descrizione(iAggiustaC + 16), Tool2(i))
                    .ToolTip1.SetToolTip(.Dimensioni(iAggiustaC + 16), Tool2(i))
                    .ToolTip1.SetToolTip(.Valore(iAggiustaC + 16), Tool2(i))
                End If
            End If
            If InStr(R, "N/mm") > 0 Then
                .Dimensioni(iAggiustaC + 16).Width = GlobalRoutines.TwipsToPixelsX(650)
            End If
            .Valore(iAggiustaC + 16).Tag = Str(IndVar(i, 2))
            If IndVar(i, 2) > 0 Then
                R = Right(R, Len(R) - n)
                n = InStr(R, "³")
                Ind = GlobalRoutines.ValVir(.Valore(iAggiustaC + 16).Tag)
                If Ind > 1000 Then
                    Ind = Ind - 1000
                    Off = 8
                End If
                .Dimensioni(iAggiustaC + 16).Text = kDimension(Ind) ' Left(R, n - 1)
                R = Right(R, Len(R) - n)
                n = InStr(R, "³")
                If n = 0 Then n = Len(R)
                .Descrizione(iAggiustaC + 16).Tag = Left(R, n - 1)
                ContrInd(IndVar(i, 2)) = iAggiustaC + 16
                AggTxt(IndVar(i, 2))
                .Descrizione(iAggiustaC + 16).BackColor = System.Drawing.Color.Yellow
            Else
                .Descrizione(iAggiustaC + 16).BackColor = System.Drawing.Color.Red
                R = Right(R, Len(R) - n)
                n = InStr(R, "³")
                R = Right(R, Len(R) - n)
                n = InStr(R, "³")
                If n = 0 Then n = Len(R)
            End If
            If IndVar(i, 2) = 0 Then .Valore(iAggiustaC + 16).Tag = ""
        End With
        iAggiustaC = iAggiustaC + 1
    End Sub

    Private Sub Visibili()
        Dim Ind, i As Short
        Dim V As Boolean
        Dim i0, i1 As Short
        With mioRis
            .Opt.RemoveAll(1)
            .Opt(0).Visible = False
            .nOpt = 1
            If .AltriDati Then
                i0 = 100 : i1 = 131
            Else
                i0 = 0 : i1 = 31
            End If
            For i = i0 To i1
                V = CStr(.Valore(i).Tag).Trim.Length > 0
                If Not V Then
                    .Valore(i).Visible = False
                    .Descrizione(i).Visible = False
                    .Dimensioni(i).Visible = False
                Else
                    .Valore(i).Visible = True
                    .Descrizione(i).Visible = True
                    .Dimensioni(i).Visible = True
                    Ind = GlobalRoutines.ValVir(.Valore(i).Tag)
                    .Valore(i).Visible = Ind >= 0
                    .Dimensioni(i).Visible = Ind >= 0
                    'if Ind=-2 and objMemb(Involucr(kLato, jInvolucr).IndObject).Piastra.
                    Select Case Ind
                        Case 12, 13, 35, 38, 266 'amm mant tubi piastra
                            SetOpt(i)
                        Case 7, 8, 9, 14, 15, 267 'E alfa
                            SetOpt(i)
                        Case 8, 36, 37, 274 To 280, 287 'Sj
                            SetOpt(i)
                        Case 259, 260 'compr mantello
                            SetOpt(i)
                        Case 285 'amm giunto
                            SetOpt(i)
                        Case 32, 33, 269, 270 'momenti fl
                            SetOpt(i)
                        Case Else
                            If Ind > 0 Then SetOpt(i)
                    End Select
                End If
            Next
        End With
    End Sub
    Private Sub SetOpt(ByVal i As Integer)
        Try
            With mioRis
                Dim n As Integer = .nOpt
                .Opt.Load(n)
                Dim inn As Integer = CShort(.Valore(i).Tag)
                If InStr(.TabStrip1.SelectedTab.Tag, "Altri") > 0 Then
                    .Opt(n).Parent = .Picture3
                End If
                .Opt(n).Tag = inn
                .Opt(n).Top = .Valore(i).Top
                .Opt(n).Left = .Valore(i).Left + .Valore(i).Width
                Select Case inn
                    Case 594, 595, 596, 1594, 1595, 1596
                        .Opt(n).Visible = False
                    Case Else
                        .Opt(n).Visible = True
                End Select
                SetHelp(i, n)
                .nOpt += 1
            End With
        Catch e As Exception
            MessageBox.Show(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Private Sub SetHelp(ByVal i As Integer, ByVal n As Integer)
        With mioRis
            Dim HelpContext As Integer = GlobalRoutines.ValVir(.Valore(i).Tag) + IDH_XR_BASEPIASTRA
            Dim Topic As String = Monitor.HelpTopic(HelpContext)
            .HelpProvider1.SetHelpNavigator(.Valore(i), HelpNavigator.Topic)
            .HelpProvider1.SetHelpKeyword(.Valore(i), Topic)
            .HelpProvider1.SetShowHelp(.Valore(i), True)
            .HelpProvider1.SetHelpNavigator(.Descrizione(i), HelpNavigator.Topic)
            .HelpProvider1.SetHelpKeyword(.Descrizione(i), Topic)
            .HelpProvider1.SetShowHelp(.Descrizione(i), True)
            .HelpProvider1.SetHelpNavigator(.Dimensioni(i), HelpNavigator.Topic)
            .HelpProvider1.SetHelpKeyword(.Dimensioni(i), Topic)
            .HelpProvider1.SetShowHelp(.Dimensioni(i), True)
            .HelpProvider1.SetHelpNavigator(.Opt(n), HelpNavigator.Topic)
            .HelpProvider1.SetHelpKeyword(.Opt(n), Topic)
            .HelpProvider1.SetShowHelp(.Opt(n), True)
        End With
    End Sub
    Public Sub AggValori(ByRef i As Short)
        Dim j, Ind, Off As Short
        With mioRis
            If InStr(.Valore(i).Tag, "Cond") > 0 Then
                Mem.Condizio(iCond) = .Valore(i).Text
            ElseIf InStr(.Valore(i).Tag, "Even") > 0 Then
                Mem.Neventi(iCond) = GlobalRoutines.ValVir(.Valore(i).Text)
            Else
                Ind = GlobalRoutines.ValVir(.Valore(i).Tag)
                If Ind > 1000 Then
                    Ind = Ind - 1000
                    Off = 8
                End If
                Mem.Z(iCond + Off, Ind) = kConvert(GlobalRoutines.ValVir(.Valore(i).Text), Ind)
                If Ind = 36 Or Ind = 37 And pt_Config.TipoDilat = 7 Then
                    For j = 1 To Mem.Z(1, 261)
                        If j <> iCond Then Mem.Z(j, Ind) = Mem.Z(iCond, Ind)
                    Next
                End If
            End If
        End With
    End Sub
    Public Function F2F3(ByRef iPag As Short, ByRef iStart As Short, Optional ByRef SoloPiastra As Boolean = False) As Short
        Dim Res As Short
        iCond = iPag : pagina = iCond + 1
        If Chiave = 1 Then Exit Function
        If iStart = -1 Then SuperAxial() : Exit Function
        iStartSint = iStart
        If Not (pt_Config.Rear = 1 Or pt_Config.Rear = 2 And CalcoloInCorso = 1) Then
            mioRis.Hide()
        Else
            Call Espandi()
        End If
        '                        Case "F2", "F3" '60, 61 'F2 F3
        Select Case mioRis.Risposta
            Case "Ottimizza" : VERIFICA = 0
            Case "Scelta" : VERIFICA = 1
            Case "Visualizza", "Scambia" : VERIFICA = -1
                icMAWP = 0
        End Select
        If pagina > 1 Then
            Globale = False
        Else
            Globale = True : iCond = 1
            icMAWP = 0
            THKPreced(1) = 0 : THKPreced(2) = 0
        End If
2227:   Res = Esegui()
        Select Case Res
            Case 3 : Chiave = 1 'dati incompleti
            Case Is < 0 ' GOTO 3630      'problemi con le tabelle
                Chiave = 1
                ' If Res > -9999 Then Call WarnT(Res)
            Case 0
                If pt_Config.SoloDilat Then
2229:               Call SuperAxial()
                    Chiave = 1 : If icMAWP > 0 Then Chiave = 0
                Else
                    If pt_Config.Rear > 1 And Not (pt_Config.Rear = 2 And CalcoloInCorso = 1) Then
                        Chiave = 0
7570:               Else
                        If Not SoloPiastra Then
                            Call SuperAxial()
                            If icMAWP > 0 Then Chiave = 0
                        End If
                    End If
                End If
        End Select
        F2F3 = Res
    End Function

    Public Sub SjCalc(ByRef Ind As Short)
        Dim Res As Short
        Res = objDilat.LeggiDilat(0, Ind, pt_Config.TipoDilat, pt_Config.SoloDilat)
        If Res > 0 Then WarnT(-Res)
    End Sub
    Public Sub AggTxt(ByVal Ind As Short)
        Dim ZZ As Single
        Dim f As String
        Dim ic As Short
        Dim Off As Short
        ic = ContrInd(Ind)
        If Ind > 1000 Then
            Ind = Ind - 1000
            Off = 8
        End If
        ZZ = Convertk(Zp(iCond + Off, Ind), Ind)
        f = mioRis.Descrizione(ic).Tag
        mioRis.Valore(ic).Text = GlobalRoutines.FormatS(f, ZZ)
        If GlobalRoutines.ValVir(mioRis.Valore(ic).Tag) = 31 Then mioRis.Valore(ic).Enabled = False
    End Sub
    Private Sub SetPag()
        If Not pt_Config.SoloDilat Then
            If paginaS = 1 Then
                pagpag = "5"
            Else
                pagpag = "B"
            End If 'dd
        Else
            pagpag = "B"
        End If 'bb
    End Sub

    Private Sub LegPagina()
        Dim ifl As Short
        Dim Prefix As String = ""
        Dim Rig As String = ""
        Dim i, NRIGHE, idum As Short
        Dim Nome As String
        NRIGHE = 13
        ifl = FreeFile()
        If pt_Config.SoloDilat Then
            If pagpag = "A" Then
                Prefix = "\WN5\XINPUT_"
            Else
                Select Case pt_Config.TipoDilat
                    Case 3 : Prefix = "\WN5\XKNPUT_"
                    Case 4 : Prefix = "\WN5\XJNPUT_"
                    Case 5 : Prefix = "\WN5\XINPUT_"
                    Case Else : Prefix = "\WN5\XLNPUT_"
                End Select
            End If
        Else
            Select Case pt_Config.Rear
                Case 1 : Prefix = "\WN5\EINPUT_" 'fisse
                    If pagpag = "B" Then NRIGHE = 15
                Case 2
                    If pagpag = "A" Or pagpag = "B" Then
                        If pagpag = "B" Then NRIGHE = 15
                        ' If pt_Config.Gasketed(1-1) = 0 Then
                        Prefix = "\WN5\FINPUT_"
                        ' Else
                        '    Prefix$ = "\WN5\FGASKT_"
                        ' End If
                        'GoSub PrepInput
                    Else
                        Select Case pt_Config.Flottante
                            Case 1 : Prefix = "\WN5\FTIPOP_"
                            Case 2 : Prefix = "\WN5\FTIPOS_"
                            Case 3 : Prefix = "\WN5\FTIPTF_"
                            Case 4 : Prefix = "\WN5\FTIPTI_"
                            Case 5 : Prefix = "\WN5\FTIPOW_"
                        End Select
                    End If
                Case 3 'U-tube
                    Exit Sub
            End Select
        End If
        Nome = RTrim(Monitor.Motore.Inizio.Archdir) & Prefix & pagpag & ".FTC"
        If Not OpenFile(Nome, ifl) Then Exit Sub
        If pagpag = "A" Or pagpag = "2" Then 'pagina = 1 Or
            FFF = 16 ': RIGAb = 5
            For i = 1 To 5
                Rig = LineInput(ifl)
            Next
        Else
            FFF = NRIGHE ': RIGAb = 8
            For i = 1 To 8
                Rig = LineInput(ifl)
            Next
        End If
        For i = 1 To FFF
            Input(ifl, tdim(i))
            Input(ifl, IndVar(i, 1))
            Input(ifl, IndVar(i, 2))
            Input(ifl, idum)
            Input(ifl, idum)
            Input(ifl, idum)
            Input(ifl, idum)
            Input(ifl, Tool1(i))
            Input(ifl, Tool2(i))
            If IndVar(i, 1) > 0 Or IndVar(i, 2) > 0 Then
                Azioni(i)
            End If
        Next
        FileClose(ifl)
        Select Case pt_Config.Rear
            Case 1
                Prefix = "\WN5\E2INPUT_"
            Case 2
                Prefix = "\WN5\F2INPUT_"
        End Select
        If pagpag = "B" Then
            Nome = RTrim(Monitor.Motore.Inizio.Archdir) & Prefix & pagpag & ".FTC"
            If Not OpenFile(Nome, ifl) Then Exit Sub
            For i = 1 To 8
                Rig = LineInput(ifl)
            Next
            For i = 17 To 16 + FFF
                Input(ifl, tdim(i))
                Input(ifl, IndVar(i, 1))
                Input(ifl, IndVar(i, 2))
                Input(ifl, idum)
                Input(ifl, idum)
                Input(ifl, idum)
                Input(ifl, idum)
                If IndVar(i, 1) > 0 Or IndVar(i, 2) > 0 Then
                    Azioni(i)
                End If
            Next
            FileClose(ifl)
        End If
    End Sub
    Private Sub Azioni(ByVal i As Integer)
        If pt_Config.SoloDilat Then
            Call UnitMis(tdim(i), IndVar(i, 1), IndVar(i, 2))
        Else
            For k = 1 To 2
                Select Case IndVar(i, k)
                    Case 5, 8, 14, 12 'T mantello
                        If pt_Config.Rear = 2 Then IndVar(i, k) = 0
                        '    If pt_Config.Flangiata(1 - 1) > 0 Then IndVar(i, k) = 0
                        '   End If
                    Case 4 'T piastra A
                        If pt_Config.Rear = 2 Then IndVar(i, k) = 0
                    Case 6 'T tubi
                        If pt_Config.Rear = 2 Then IndVar(i, k) = 0
                    Case 8 ' E mantello
                        If pt_Config.Rear = 2 Then
                            If Not RadialExp Or pt_Config.Flangiata(0) > 0 Then IndVar(i, k) = 0
                        End If
                    Case 9 ' E tubi
                        If pt_Config.Rear = 2 Then IndVar(i, k) = 0
                    Case 14 ' alfa mantello
                        If pt_Config.Rear = 2 Then
                            If Not RadialExp Or pt_Config.Flangiata(0) > 0 Then IndVar(i, k) = 0
                        End If
                    Case 15 ' alfa tubi
                        If pt_Config.Rear = 2 Then IndVar(i, k) = 0
                    Case 35 'amm piastra A
                    Case 7 ' alfa piastra A
                        If pt_Config.Rear = 2 Then
                            If Not RadialExp Or pt_Config.Flangiata(0) = -1 Or pt_Config.Flangiata(0) = 2 Then IndVar(i, k) = 0
                        End If
                    Case 39 ' snerv.tubi
                    Case 287, 36, 37, 274, 275 'dilat
                        If Mem.Z(1, 26) = 0 Or pt_Config.Rear = 2 Then IndVar(i, k) = 0
                        Select Case IndVar(i, k)
                            Case 274, 275, 287
                                If pt_Config.TipoDilat = 7 Then IndVar(i, k) = 0
                        End Select
                    Case -3 'pdiff
                        If Problem(IndProbl).PDIFF = 0 Then IndVar(i, k) = 0
                    Case 259, 260 'amm. a compressione mantello
                        If pt_Config.Rear = 2 Then IndVar(i, k) = 0
                    Case 266, 267, 268 'piastra B
                        If pt_Config.Differing < 2 And pt_Config.Rear = 1 Then IndVar(i, k) = 0
                    Case 32, 33 'mom A
                        If pt_Config.Flangiata(1 - 1) = 0 Then IndVar(i, k) = 0
                    Case 269, 270 'mom B
                        If pt_Config.Flangiata(2 - 1) = 0 Or (pt_Config.Differing < 2 And pt_Config.Rear = 1) Then IndVar(i, k) = 0
                    Case 594 'Trim piastra A
                        If pt_Config.Flangiata(1 - 1) = 2 Or Not RadialExp Or CalcoloInCorso = 0 Then IndVar(i, k) = 0
                    Case 747 'Tdesign piastra A
                        '   If pt_Config.Flangiata(1-1) = 2 Then IndVar(i, k) = 0
                    Case 595 'Tshell at rim A
                        If pt_Config.Flangiata(1 - 1) = 2 Or pt_Config.Flangiata(1 - 1) = 1 Or Not RadialExp Or CalcoloInCorso = 0 Then IndVar(i, k) = 0
                    Case 777 'T des. shell
                        If pt_Config.Flangiata(1 - 1) = 2 Or pt_Config.Flangiata(1 - 1) = 1 Then IndVar(i, k) = 0
                    Case 596 'Tchan at rim A
                        If pt_Config.Flangiata(1 - 1) = 2 Or pt_Config.Flangiata(1 - 1) = -1 Or Not RadialExp Or CalcoloInCorso = 0 Then IndVar(i, k) = 0
                    Case 322 'T des channel A
                        If pt_Config.Flangiata(1 - 1) = 2 Or pt_Config.Flangiata(1 - 1) = -1 Or CalcoloInCorso = 0 Then IndVar(i, k) = 0
                    Case 1594 'Trim B
                        If Rear = 1 Then
                            If pt_Config.Flangiata(2 - 1) = 2 Or pt_Config.Differing < 2 Or Not RadialExp Or CalcoloInCorso = 0 Then IndVar(i, k) = 0
                        Else
                            If (Not (Flottante = 1 Or Flottante = 4)) And Not RadialExp Or CalcoloInCorso = 0 Then IndVar(i, k) = 0
                        End If
                    Case 1747 'T des. piastra B
                        If Rear = 1 Then
                            If pt_Config.Flangiata(2 - 1) = 2 Or pt_Config.Differing < 2 Then IndVar(i, k) = 0
                        Else
                            If (Not (Flottante = 1 Or Flottante = 4)) Then IndVar(i, k) = 0
                        End If
                    Case 1595 'Tshell at rim B
                        If Rear = 1 Then
                            If pt_Config.Flangiata(2 - 1) = 2 Or pt_Config.Flangiata(2 - 1) = 1 Or pt_Config.Differing < 2 Or Not RadialExp Or CalcoloInCorso = 0 Then IndVar(i, k) = 0
                        Else
                            IndVar(i, k) = 0
                        End If
                    Case 1322 'T des channel B
                        If pt_Config.Flangiata(2 - 1) = 2 Or pt_Config.Flangiata(2 - 1) = -1 Or pt_Config.Differing < 2 Or CalcoloInCorso = 0 Then IndVar(i, k) = 0
                    Case 1596 'Tchan at rim B
                        If Rear = 1 Then
                            If pt_Config.Flangiata(2 - 1) = 2 Or pt_Config.Flangiata(2 - 1) = -1 Or pt_Config.Differing < 2 Or Not RadialExp Or CalcoloInCorso = 0 Then IndVar(i, k) = 0
                        Else
                            If (Not (Flottante = 1 Or Flottante = 4)) And Not RadialExp Or CalcoloInCorso = 0 Then IndVar(i, k) = 0
                        End If
                    Case 324 ' alfa channel A
                        If pt_Config.Flangiata(1 - 1) = 2 Or pt_Config.Flangiata(1 - 1) = -1 Or Not RadialExp Or CalcoloInCorso = 0 Then IndVar(i, k) = 0
                    Case 1324 'alfa channel B
                        If Rear = 1 Then
                            If pt_Config.Flangiata(2 - 1) = 2 Or pt_Config.Differing < 2 Or Not RadialExp Or CalcoloInCorso = 0 Then IndVar(i, k) = 0
                        Else
                            If (Not (Flottante = 1 Or Flottante = 4)) And Not RadialExp Or CalcoloInCorso = 0 Then IndVar(i, k) = 0
                        End If
                End Select
            Next
            Call UnitMis(tdim(i), IndVar(i, 1), IndVar(i, 2))
        End If
    End Sub
    Private Sub AcqThk(ByRef kThk As String, ByRef kEst As String, ByRef THKMIN As Single)
        Dim Ninput As Short
        Dim Strin1(2) As String
        Dim Ris1(2) As String
        Dim Archiv(2) As Short
        Dim dAiu(2) As String
        Dim Res As Boolean
        Dim Tit As String
        Ninput = 1
        Strin1(1) = "Spessore assunto (centro) " & UnitLength
        Ris1(1) = GlobalRoutines.myStr(THKMIN, 5, 3, False)
        If THKMIN = 0 Then Ris1(1) = GlobalRoutines.myStr(TSheThk, 4, 2, False)
        If pt_Config.Flangiata(pt_Config.Side - 1) <> 0 Then
            Strin1(2) = "Spessore assunto (estensione) " & UnitLength
            Ris1(2) = GlobalRoutines.myStr(Int(Test * kLength * 100 + 0.5) / 100, 5, 3, False)
            Ninput = 2
        End If
        ' Debug.Print Padre.TSheThk
        If icMAWP < 1 Then
            Tit = "Scelta spessori piastra tubiera"
            If pt_Config.Side = 2 Then Tit = Tit & " di coda"
            Res = Monitor.Motore.InputDati(Ninput, Tit, Strin1, Ris1, "", Archiv, dAiu)
            If Not Res Then mioRis.Risposta = "Annulla" : mioRis.Hide()
        End If
        kThk = Ris1(1) / kLength
        kEst = Ris1(2) / kLength
        VERIFICA = -1
    End Sub
    Public Function GetPiastra() As Short
        GetPiastra = pt_Config.Side
    End Function
    Public Sub SetPiastra(ByRef iP As Short, Optional ByRef controlla As Boolean = False)
        pt_Config.Side = iP
        If Not Padre Is Nothing Then Padre.PiastraAB = iP
        Select Case iP
            Case 0, 1 : IndProbl = Indprobl1
                Offset = 0
                If Not mioRis Is Nothing Then
                    mioRis.Command4.Text = "vedi LATO B"
                    mioRis.PiastraB = False
                End If
            Case 2 : IndProbl = IndProbl2
                Offset = 8
                If Not mioRis Is Nothing Then
                    mioRis.Command4.Text = "vedi LATO A"
                    mioRis.PiastraB = True
                End If
        End Select
        If controlla Then ContInput()
    End Sub

    Private Function Ligament(ByRef PA As Single, ByRef DOO As Single) As Single
        Dim Testo As String
        Dim eta As Single
        If DOO <= 0 Or PA <= DOO Then
            Testo = "I dati relativi al passo e al diametro" & vbCrLf
            Testo = Testo & "dei tubi scambiatori sono incongruenti."
            MessageBox.Show(Testo)
            Ligament = 0
        Else
            If pt_Config.Square = 1 Then
                eta = 1 - 0.785 / (PA / DOO) ^ 2
            Else
                eta = 1 - 0.907 / (PA / DOO) ^ 2
            End If
            Ligament = eta
        End If
    End Function

    Public Function OttimDilat(ByRef f As Single) As Short
        Dim Res As Short
        Espandi()
        Globale = True : iCond = 1
        icMAWP = 0
        THKPreced(1) = 0 : THKPreced(2) = 0
        Res = Esegui()
        If Not Res = 0 Then OttimDilat = Res : Exit Function
        SuperAxial()
        FattUs(True, False, f)
    End Function
    Public Sub SuperOtt()
        Dim R, R1, R0, Ri, Ro As Single
        Dim c, c1, c0, ci, co As Single
        Dim n, N1, N0, ni, No As Single
        Dim H, H1, H0, hi, ho As Single
        Dim s, s1, S0, Si, SO As Single
        Dim f, fmax As Single
        Dim Dati(11) As Single
        Dim kDilat, jDilat, i As Short
        Dim frm As String
        frm = "#####.#"
        '-------------------------
        jDilat = CType(CType(objMemb(Involucr(kLato, jInvolucr).IndObject), wn_PT).Piastra, wn_FTC).IndiceDilat
        kDilat = 1
        Select Case Dilatatore.SottoTipo
            Case 1
                R0 = Dilatatore.Raggio - 5 : R1 = Dilatatore.Raggio + 5 : Ri = 5
                If R0 > 0 Then R0 = R0 + 5 : R1 = R1 + 5
                c0 = Dilatatore.Colletto : c1 = 3 * Dilatatore.Colletto : ci = Dilatatore.Colletto
                N0 = Dilatatore.nOnde : N1 = N0 : ni = 1
                H0 = (Dilatatore.DIMAX - Dilatatore.DIMIN) / 2 - 2 * Dilatatore.Raggio - Dilatatore.Spess
                H1 = 3 * H0 : hi = H0
                S0 = Dilatatore.Spess : s1 = Dilatatore.Spess + 3 : Si = 1
            Case 2
                R0 = 0 : R1 = 0 : Ri = 1
                c0 = Dilatatore.Colletto : c1 = 3 * Dilatatore.Colletto : ci = Dilatatore.Colletto
                N0 = Dilatatore.nOnde : N1 = N0 : ni = 1
                H0 = (Dilatatore.DIMAX - Dilatatore.DIMIN) / 2 - Dilatatore.Spess
                H1 = 3 * H0 : hi = H0
                S0 = Dilatatore.Spess : s1 = Dilatatore.Spess + 3 : Si = 1
                With frmOptim.DefInstance
                    .txtMin(0).Visible = False
                    .txtMax(0).Visible = False
                    .txtIncr(0).Visible = False
                    ._Label2_0.Visible = False
                    ._Label3_0.Visible = False
                    ._Label2_9.Visible = False
                    ._Label3_7.Visible = False
                    .txtMin(9).Visible = False
                    .txtIncr(9).Visible = False
                End With
            Case Else
                MessageBox.Show("Funzione non disponibile per questo tipo di dilatatore")
                Exit Sub
        End Select
        '----------------------------
        mioRis.Hide()
        With frmOptim.DefInstance
            .txtMin(0).Text = Format(R0, frm) : .txtMax(0).Text = Format(R1, frm) : .txtIncr(0).Text = Format(Ri, frm)
            .txtMin(1).Text = Format(c0, frm) : .txtMax(1).Text = Format(c1, frm) : .txtIncr(1).Text = Format(ci, frm)
            .txtMin(2).Text = Format(N0, frm) : .txtMax(2).Text = Format(N1, frm) : .txtIncr(2).Text = Format(ni, frm)
            .txtMin(3).Text = Format(H0, frm) : .txtMax(3).Text = Format(H1, frm) : .txtIncr(3).Text = Format(hi, frm)
            .txtMin(4).Text = Format(S0, frm) : .txtMax(4).Text = Format(s1, frm) : .txtIncr(4).Text = Format(Si, frm)
            .chkEscludiSez1.Visible = pt_Config.TipoDilat < 3 Or pt_Config.TipoDilat > 6
            .ShowDialog()
            EscludiSez1 = .chkEscludiSez1.CheckState = 1
            R0 = GlobalRoutines.ValVir(.txtMin(0).Text) : R1 = GlobalRoutines.ValVir(.txtMax(0).Text) : Ri = GlobalRoutines.ValVir(.txtIncr(0).Text)
            c0 = GlobalRoutines.ValVir(.txtMin(1).Text) : c1 = GlobalRoutines.ValVir(.txtMax(1).Text) : ci = GlobalRoutines.ValVir(.txtIncr(1).Text)
            N0 = GlobalRoutines.ValVir(.txtMin(2).Text) : N1 = GlobalRoutines.ValVir(.txtMax(2).Text) : ni = GlobalRoutines.ValVir(.txtIncr(2).Text)
            H0 = GlobalRoutines.ValVir(.txtMin(3).Text) : H1 = GlobalRoutines.ValVir(.txtMax(3).Text) : hi = GlobalRoutines.ValVir(.txtIncr(3).Text)
            S0 = GlobalRoutines.ValVir(.txtMin(4).Text) : s1 = GlobalRoutines.ValVir(.txtMax(4).Text) : Si = GlobalRoutines.ValVir(.txtIncr(4).Text)
            For i = 0 To 4
                .txtMin(i).Enabled = False
                .txtMax(i).Enabled = False
                .txtIncr(i).Enabled = False
            Next
            If .Cancellato Then GoTo Breack
            .cmdVai.Enabled = False
            .cmdCancel.Enabled = False
            .Show()
            .Break.Enabled = True
            fmax = 1000
            OptimDil = True
            objDilat.OptimDil = True
            Espandi()
            VERIFICA = -1
            If ci <= 0 Then ci = 1
            If Ri <= 0 Then Ri = 1
            If ni <= 0 Then ni = 1
            If Si <= 0 Then Si = 1
            If hi <= 0 Then hi = 1
            Globale = True
            iCond = 1
            icMAWP = 0
            'UPGRADE_WARNING: Screen proprietà Screen.MousePointer presenta un nuovo comportamento. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup2065"'
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.AppStarting
            For n = N0 To N1 Step ni
                Dilatatore.nOnde = n
                For s = S0 To s1 Step Si
                    Dilatatore.Spess = s
                    For R = R0 To R1 Step Ri
                        If R >= 3 * s Or Dilatatore.SottoTipo = 2 Then
                            Dilatatore.Raggio = R
                            If Dilatatore.SottoTipo = 1 Then Dilatatore.SezRinf = R
                            For c = c0 To c1 Step ci
                                Dilatatore.Colletto = c
                                For H = H0 To H1 Step hi
                                    Dilatatore.DIMAX = Dilatatore.DIMIN + 2 * (2 * R + H + s)
                                    With Involucr(kDilat, jDilat)
                                        .Spess = s ' Dilatatore.t '
                                        '.di = Dilatatore.DIMIN '
                                        .dns = Dilatatore.DIMAX '
                                        Mem.Z(1, 26) = Dilatatore.DIMAX
                                        .R0 = R
                                        .Dati2 = Ro
                                        '.L0 = Dilat.Lunghezza
                                        .H0 = c
                                        .ms = n
                                        '.xs = Dilat.nPli
                                        '.TubeAdopt = Dilat.LungCol 'Look.AlungC
                                        '.TubeMinT = Dilat.LunTira
                                    End With
                                    Call objDilat.GeomDilat(Dilatatore, pt_Config.TipoDilat)
                                    Call objDilat.GeomEquiv(pt_Config.TipoDilat)
                                    OttimDilat(f)
                                    If f < fmax And f > 0 Then
                                        fmax = f
                                        Ro = R
                                        co = c
                                        No = n
                                        ho = H
                                        SO = s
                                    End If
                                    .txtMin(7).Text = CStr(n)
                                    .txtMin(5).Text = CStr(s)
                                    .txtMin(9).Text = CStr(R)
                                    .txtMin(8).Text = CStr(c)
                                    .txtMin(6).Text = CStr(H)
                                    .txtMin(10).Text = GlobalRoutines.myStr(fmax, 3, 5, False)
                                    .txtMin(11).Text = GlobalRoutines.myStr(f, 3, 5, False)
                                    .Refresh()
                                    System.Windows.Forms.Application.DoEvents()
                                    If .Breackato Then GoTo Breack
                                Next H
                            Next c
                        End If
                    Next R
                Next s
            Next n
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            .Hide()
            .txtMin(9).Text = CStr(Ro)
            .txtMin(8).Text = CStr(co)
            .txtMin(7).Text = CStr(No)
            .txtMin(6).Text = CStr(ho)
            .txtMin(5).Text = CStr(SO)
            If No = 0 Then
                MostraAiuto(IDH_PT_NOOPTIM)
                'messagebox.show "Calcolo non effettuato"
                GoTo Breack
            End If
            ._cmdScelta_0.Enabled = True
            .Annulla.Enabled = True
            .Break.Enabled = False
            .ShowDialog()
            Select Case .Scelta
                Case -1
                Case 0 'prima selezione
                    Dilatatore.nOnde = No
                    Dilatatore.Spess = SO
                    Dilatatore.Colletto = co
                    Select Case Dilatatore.SottoTipo
                        Case 1
                            Dilatatore.Raggio = Ro : Dilatatore.SezRinf = Ro
                            Dilatatore.DIMAX = Dilatatore.DIMIN + 2 * (2 * Ro + ho + SO)
                        Case 2
                            Dilatatore.DIMAX = Dilatatore.DIMIN + 2 * (ho + SO)
                    End Select
                    Involucr(kDilat, jDilat).Spess = SO
                    Involucr(kDilat, jDilat).dns = Dilatatore.DIMAX
                    Mem.Z(1, 26) = Dilatatore.DIMAX
                    Involucr(kDilat, jDilat).R0 = Ro
                    Involucr(kDilat, jDilat).H0 = co
                    Involucr(kDilat, jDilat).ms = No
                    Involucr(kDilat, jDilat).Dati2 = Ro ' Dilatatore.SezRinf
                    Call objDilat.GeomDilat(Dilatatore, pt_Config.TipoDilat)
                    Call objDilat.GeomEquiv(pt_Config.TipoDilat)
                    OttimDilat(f)
                Case 1 'seconda selezione
            End Select
Breack:
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            .Hide()
        End With
        OptimDil = False
        objDilat.OptimDil = False
        frmOptim.DefInstance.Dispose()
    End Sub
    Public Sub CurvaSj()
        Dim OldTipo As Short
        If SoloDilat Then Exit Sub
        If pt_Config.TipoDilat < 7 Then
            'Case 1 'manuale
            OldTipo = pt_Config.TipoDilat
            pt_Config.TipoDilat = 7
            If Mem.Z(1, 26) = 0 Then
                '.Zp(1, 26) = 1000
            End If
            ' GoSub Stacca
        End If
        If OldTipo > 0 Then 'dilat
            pt_Config.TipoDilat = OldTipo
        End If
    End Sub
    Private Function cscod(ByRef i As Short) As Single
        Dim c As Single
        Dim j As Short
        c = cs
        Select Case i
            Case 1
                j = Involucr(kLato, jInvolucr).IndAccopp(4)
            Case 2
                j = Involucr(kLato, jInvolucr).IndAccopp2(4)
        End Select
        If j > 0 Then
            c = Involucr(1, j).cs
            If Involucr(1, j).OS > Involucr(1, j).cs Then c = Involucr(1, j).OS
            ' c = c' / inc
        End If
        cscod = c
    End Function
    Private Function ctcod(ByRef i As Short) As Single
        Dim c As Single
        Dim j As Short
        c = CT
        Select Case i
            Case 1
                j = Involucr(kLato, jInvolucr).IndAccopp(3)
            Case 2
                j = Involucr(kLato, jInvolucr).IndAccopp2(3)
        End Select
        If j > 0 Then
            c = Involucr(2, j).cs
            If Involucr(2, j).OS > Involucr(2, j).cs Then c = Involucr(1, j).OS
            ' c = c / inc
        End If
        ctcod = c
    End Function
    Private Function fy(ByRef i As Short) As Single
        Dim YieldM, f As Single
        YieldM = Mem.Z(i, 286)
        If YieldM <= 0 Or Mem.Z(i, 38) <= 0 Then
            f = 1
        Else
            If Mem.Z(i, 38) > 0 Then
                f = YieldM / Mem.Z(i, 38)
                If f > 1 Then f = 1
            Else
                f = 1
            End If
        End If
        fy = f
    End Function
    Private Sub frmPrintAA()
        Dim iX, i, iy As Short
        With mioRis
            If Padre.TipoAA < 5 Then
                iy = 15 : iX = 29
                .Scrivi(GlobalRoutines.FormatS(FormInch, THKMIN0 * kLength), iy, iX)
                iy = 15 : iX = 58
                .Scrivi(GlobalRoutines.FormatS(FormInch, THKMIN1 * kLength), iy, iX)
            Else
                iy = 9 : iX = 23
                .Scrivi(GlobalRoutines.FormatS(FormTemp, Mem.Z(iCond + Offset, 690) * kPress) & " " & UnitPress, iy, iX)
                iy = 9 : iX = 53
                .Scrivi(GlobalRoutines.FormatS(FormTemp, Mem.Z(iCond + Offset, 697) * kPress) & " " & UnitPress, iy, iX)
                iy = 10 : iX = 23
                .Scrivi(GlobalRoutines.FormatS(FormTemp, Mem.Z(iCond + Offset, 704) * kPress) & " " & UnitPress, iy, iX)
                iy = 10 : iX = 53
                .Scrivi(GlobalRoutines.FormatS(FormTemp, Mem.Z(iCond + Offset, 711) * kPress) & " " & UnitPress, iy, iX)
                Tau = 0
                For i = 478 To 484
                    If System.Math.Abs(Mem.Z(iCond + Offset, i)) > Tau Then
                        Tau = System.Math.Abs(Mem.Z(iCond + Offset, i))
                        iTau = i - 477
                    End If
                    If System.Math.Abs(Mem.Z(iCond + Offset, i + 7)) > tauc Then tauc = System.Math.Abs(Mem.Z(iCond + Offset, i + 7)) : iTauc = i - 477
                Next
                iy = 11 : iX = 23
                .Scrivi(GlobalRoutines.FormatS(FormTemp, Tau * kPress) & " " & UnitPress, iy, iX)
                iy = 11 : iX = 46
                .Scrivi(GlobalRoutines.FormatS("##", iTau), iy, iX)
                iy = 11 : iX = 53
                .Scrivi(GlobalRoutines.FormatS(FormTemp, tauc * kPress) & " " & UnitPress, iy, iX)
                iy = 11 : iX = 75
                .Scrivi(GlobalRoutines.FormatS("##", iTauc), iy, iX)
                iy = 12 : iX = 23
                .Scrivi(GlobalRoutines.FormatS(FormTemp, Mem.Z(iCond + Offset, 733) * kPress) & " " & UnitPress, iy, iX)
                iy = 12 : iX = 53
                .Scrivi(GlobalRoutines.FormatS(FormTemp, Mem.Z(iCond + Offset, 736) * kPress) & " " & UnitPress, iy, iX)
                iy = 13 : iX = 23
                .Scrivi(GlobalRoutines.FormatS(FormTemp, Mem.Z(iCond + Offset, 740) * kPress) & " " & UnitPress, iy, iX)
                iy = 15 : iX = 29
            End If
        End With
    End Sub
    Private Sub MediumAxial()
        Dim Res As Short
        Call Axial()
        '      MAiter = 0
        If CalcoloInCorso = 1 Then
            Do While Padre.RulesAA.retcods = 1 Or Padre.RulesAA.retcodc = 1
                Padre.RulesAA.InizPlas = True
                Padre.RulesAA.retcods = 0
                Padre.RulesAA.retcodc = 0
                Res = ContInput()
                If pt_Config.Rear = 1 Then Call Calcoli() Else Call Calcoli2()
                '   Call Axial
                Exit Do
                '  MAiter = MAiter + 1
                '  If MAiter > 5 Then Exit Do
            Loop
        End If
    End Sub
    Public Sub stamptrac()
        Dim i, Res As Short
        Dim File As String
        Dim objTraccia As traccia.clsTracciatura
        For i = 1 To Config(3).Ninvolucri
            If Involucr(3, i).Tipo = 7 Then
                If Len(Trim(Involucr(3, i).File)) > 0 Then GoTo Cont
            End If
        Next
        Exit Sub
Cont:
        File = Trim(Involucr(3, i).File)
        If Asc(File) < 33 Then Exit Sub
        objTraccia = New traccia.clsTracciatura
        objTraccia.DoveMotore = Monitor.Motore
        Res = objTraccia.Esegui(1, File)
        If Res > 0 Then Exit Sub
        FinePag(1)
        Monitor.Motore.Problem.FileStream.Close()
        objTraccia.Calc4SsP(File, 0)
        objTraccia.ScriviTraccia(FileSt, "Attendere la generazione della stampa della tracciatura", "", 1, 4, Monitor.Motore.Problem.FileStream)
        objTraccia.Dispose()
        objTraccia = Nothing
        Monitor.Motore.Problem.FileStream = New IO.StreamWriter(FileSt, True)
        FinePag(0)
    End Sub
End Class