<Serializable()> Public Class clsAltern
    Public Engineer As String = "" '        4    1     1     1    S,  00,   0   ,Engineer
    Public TipoUnita As String = "" '       4    2     2     3    S,  00,   0   ,Tipo unita'
    Public NumFasciParall As Integer '      4    3     5     1    I,  00,   0   ,N. fasci in parallelo
    Public NFPAlberoPassante As Integer '   4    4     6     1    I,  00,   0   ,N. fasci in par. con albero pass.
    Public NumTotPassi As Integer '         4    5     7     1    I,  00,   0   ,N. totale passi
    Public NbocIn As Integer '              4    6     8     1    I,  00,   0   ,N. bocchelli in
    Public NBocOut As Integer '             4    7     9     1    I,  00,   0   ,N. bocchelli out
    Public NumTipiTubi As Integer '         4    8    10     1    I,  00,   0   ,N. tipi di tubi
    Public RPMVentilatore As Integer '      4    9    11     1    I,  00,   0   ,R.P.M. Ventilatore
    Public TipoVentilatore As String = "" ' 4   10    12     1    S,  00,   0   ,Tipo Ventilatore
    Public PerCentoAV As Integer '          4   11    13     1    I,  00,   0   ,% Passo AV
    Public Positioner_Rele As String = "" ' 4   12    14     2    S,  00,   0   ,Posizion. o rele'
    Public TipoPale As String = "" '        4   13    16     2    S,  00,   0   ,Tipo pale
    Public NumZone As Integer '             4   14    18     1    I,  00,   0   ,N. Zone di calcolo
    Public RPMmotore As Integer '           4   15    19     1    I,  00,   0   ,RPM Motore
    Public codSlope As Integer '            4   16    20     1    I,  25,   0   ,Codice slope
    Public codRiduttore As Integer '        4   17    21     1    I,  00,   0   ,Codice riduttore
    Public Autom As String = "" '           4   50    22     1    S,  00,   0   ,Autom (SI/NO)
    Public codSplit As String = "" '        4   71    23     1    I,  00,   0   ,Codice split
    Public codImbocco As Integer '          4   72    24     1    I,  43,   0   ,Codice imbocco       
    Public NunitaxDS As String '            4   18    25     1    S,  00,   0   ,N. Unita' per D.S.
    Public codAsterisco As String = "" '    4   19    26     1    S,  00,   0   ,Codice asterisco
    Public NoteBocchelli As Integer '       4   20    27     1    I,  00,   0   ,Note per bocchelli
    Public NoteGenerali As Integer '        4   21    28     1    I,  00,   0   ,Note generali
    Public GiornoCalcolo As Integer '       4   22    29     1    I,  00,   0   ,Giorno
    Public MeseCalcolo As Integer '         4   23    30     1    I,  00,   0   ,Mese
    Public AnnoCalcolo As Integer '         4   24    31     1    I,  00,   0   ,Anno
    Public codTestate As Integer '          4   25    32     1    I,  00,   0   ,Codice testate
    Public codSC As Integer '               4   26    33     1    I,  00,   0   ,Codice St. Coil
    Public NumPale As Integer '             4   27    34     1    I,  00,   0   ,N. pale ventilatore
    Public PassiOrizzontali As String = "NO"   '   4   28    35     1    I,  00,   0   ,Passi orizzontali (YE,NO)
    Public NumFasciStacked As Integer '     4   29    36     1    I,  00,   0   ,N. fasci stacked
    Public NumRowsTopB As Integer '         4   30    37     1    I,  00,   0   ,N. rows (Top ... 1)
    Public NumRowsMediumB As Integer '      4   31    38     1    I,  00,   0   ,N. rows (Top ... 2)
    Public NumRowsBottomB As Integer '      4   32    39     1    I,  00,   0   ,N. rows (Top ... 3)
    Public NumFileUnitaAccopp As Integer '  4   33    40     1    I,  00,   0   ,N. file per unita' accoppiate
    Public SwitchScriviVent As Integer '    4   34    41     1    I,  00,   0   ,Chiave per Vent=1 se da scrivere
    Public NumItemsxUnita As Integer '      4   35    42     1    I,  00,   0   ,N. items su stessa unita'
    Public indRecDatiItem(6) As Integer '   4   36    43     1    I,  00,   0   ,N. 1ø record dati item 1
    '   4   37    44     1    I,  00,   0   ,N. 1ø record dati item 2
    '   4   38    45     1    I,  00,   0   ,N. 1ø record dati item 3
    '   4   39    46     1    I,  00,   0   ,N. 1ø record dati item 4
    '   4   40    47     1    I,  00,   0   ,N. 1ø record dati item 5
    '   4   41    48     1    I,  00,   0   ,N. 1ø record dati item 6
    Public NumFasciItem(6) As Integer '     4   42    49     1    I,  00,   0   ,N. fasci in comune 1ø item
    '    4   43    50     1    I,  00,   0   ,N. fasci in comune 2ø item
    '    4   44    51     1    I,  00,   0   ,N. fasci in comune 3ø item
    '    4   45    52     1    I,  00,   0   ,N. fasci in comune 4ø item
    '    4   46    53     1    I,  00,   0   ,N. fasci in comune 5ø item
    '    4   47    54     1    I,  00,   0   ,N. fasci in comune 6ø item
    Public GiuntoTP As Integer '            4   51    55     1    I,  30,   0   ,Giunto t/p. (WE/EX)
    Public switchSerpentino As Integer '    4   xx    56     1    I,  00,   0   ,1 se serpentino
    Public switchFasciAccoppiati As Integer '4   xx    57     1    I,  00,   0   ,1 se fasci accoppiati e width da non toccare
    Public switchPersianeAUt As Integer '   4   xx    58     1    I,  00,   0   ,1 se persiane automatiche
    Public AirSupplyFan As Integer '        4   xx    59     1    I,  00,   0   ,(psi)
    Public AirSupplyPers As Integer '       4   xx    60     1    I,  00,   0   ,(psi)
    Public CorrelAria As Integer '          4   73    61     1    I,  00,   0   ,Correlazioni lato aria (0=ISA; 1=HTRI)
    Public Prinop As Integer '              4   74    62     1    I,  00,   0   ,Origine proprietà fluido 0,1,2
    '          4   73    63     1    I,  00,   0  tipo tubi zona 3
    '          4   73    64     1    I,  00,   0  tipo tubi zona 4
    Public BWG(2) As Integer '              4   54    65     1    I,  00,   0   ,BWG 1.tipo
    '                                       4   61    97     1    I,  00,   0   ,BWG 2.tipo
    Public TipoBWG(2) As String '           4   55    66     2    S,  00,   0   ,Tipo bwg 1. tipo
    '                                       4   62    98     2    S,  00,   0   ,Tipo bwg 2. tipo
    Public codMater(2) As Integer '         4   56    68     1    I,  23,   0   ,Mater    1. tipo
    '                                       4   63   100     1    I,  23,   0   ,Mater    2. tipo
    Public Conduc(2) As Integer '           4   57    85     1    I,  00,   0   ,cond.    1. tipo
    '                                       4   64   117     1    I,  00,   0   ,cond.    2. tipo
    Public codAlett(2) As String '          4   58    86     1    S,  00,   0   ,CodAlett 1. tipo
    '                                       4   65   118     1    S,  00,   0   ,CodAlett 2. tipo
    Public SpAlett(2) As String '           4   59    87     2    S,  00,   0   ,SpAlett  1. tipo
    '                                       4   66   119     2    S,  00,   0   ,SpAlett  2. tipo
    Public NumFile(2) As Integer '          4   48    89     1    I,  00,   0   ,N. file tubi
    '                                       4   52   121     1    I,  00,   0   ,N. file tubi     2.tipo
    Public NumTubiFascio(2) As Integer '    4   49    90     1    I,  00,   0   ,N. tubi/fascio
    '                                       4   53   122     1    I,  00,   0   ,N. tubi/fascio   2.tipo
    Public NumTubiSC(2) As Integer '        4   60    91     1    I,  00,   0   ,N.tubi/fascio S.T.
    '                                       4   67   123     1    I,  00,   0   ,N.tubi/fascio S.T.
    Public codTurbolators(2) As Integer '   4   68    92     1    I,  10,   0   ,Turbol   1. tipo
    '                                       4   69   124     1    I,  10,   0   ,Turbol   2. tipo
    Public GiuntiTP(2) As Integer '         4   68    93     1    I,  10,   0   ,
    '                                       4   70   125     1    I,  30,   0   ,Giunto t/p 2. tipo 
    Public ChiaveCondens As Integer '       5   13     1     1    I,  00,   0   ,Chiave per condensatori
    Public TipoCalcolo As Integer '         5   14     2     1    I,  00,   0   ,1=calcolo HTRI 2=CSIN
    Public AdditStaticPr As Single '        5   15     3     2    R,  00,   0   ,Addit. static pr. per MFVC
    Public TipoTubi(12) As Integer '       5   16     5     1    I,  00,   0   ,Tipo tubi zona 1         
    '                                       5   17     6     1    I,  00,   0   ,Tipo tubi zona 2
    '                                       5   18     7     1    I,  00,   0   ,Tipo tubi zona 3
    '                                       5   19     8     1    I,  00,   0   ,Tipo tubi zona 4
    '                                       5   20     9     1    I,  00,   0   ,Tipo tubi zona 5
    '                                       5   21    10     1    I,  00,   0   ,Tipo tubi zona 6
    '                                       5   22    11     1    I,  00,   0   ,Tipo tubi zona 7
    '                                       5   23    12     1    I,  00,   0   ,Tipo tubi zona 8
    '                                       5   24    13     1    I,  00,   0   ,Tipo tubi zona 9
    '                                       5   25    14     1    I,  00,   0   ,Tipo tubi zona 10
    '                                       5   26    15     1    I,  00,   0   ,Tipo tubi zona 11
    '                                       5   27    16     1    I,  00,   0   ,Tipo tubi zona 12
    Public DiaTubo(2) As Single '           5    1    17     2    R,  00,   0   ,Dia. tubo
    '                                       5    7    41     2    R,  00,   0   ,Dia. tubo   2.
    Public Passo(2) As Single '             5    2    19     2    R,  00,   0   ,Passo tubi
    '                                       5    8    43     2    R,  00,   0   ,Passo tubi  2.
    Public DiAl(2) As Single '              5    3    21     2    R,  00,   0   ,Dia. alette
    '                                       5    9    45     2    R,  00,   0   ,Dia. alette 2.
    Public NumAlettxInch(2) As Single '     5    4    23     2    R,  00,   0   ,N.alette x 1"
    '                                       5   10    47     2    R,  00,   0   ,N.alette x 1" 2.
    Public NtotTubi(2) As Single '          5    5    25     2    R,  00,   0   ,N.tot.tubi
    '                                       5   11    49     2    R,  00,   0   ,N.tot.tubi  2.
    Public SpessInch(2) As Single '         5    6    27     2    R,  00,   0   ,Sp.tubi inch
    '                                       5   12    51     2    R,  00,   0   ,Sp.tubi inch 2.
    Public SurfRatio(2) As Single '         5    6    29     2    R,  00,   0   ,
    '                                       5   12    53     2    R,  00,   0   ,
    Public SurfRatioA(2) As Single '        5    6    31     2    R,  00,   0   ,
    '                                       5   12    55     2    R,  00,   0   ,
    Public CoeffSP_A(2) As Single '         5    6    33     2    R,  00,   0   ,Coeff Static Pressure -A
    '                                       5   12    57     2    R,  00,   0   ,
    Public CoeffSP_B(2) As Single '         5    6    35     2    R,  00,   0   ,Coeff Static Pressure -B
    '                                       5   12    59     2    R,  00,   0   ,
    Public CoeffAR_A(2) As Single '         5    6    37     2    R,  00,   0   ,Coeff Air Resistance -A
    '                                       5   12    61     2    R,  00,   0   ,
    Public CoeffAR_B(2) As Single '         5    6    39     2    R,  00,   0   ,Coeff Air Resistance -B
    '                                       5   12    63     2    R,  00,   0   ,
    Public DutyZone(12) As Single          '5   12    65     2    R,  00,   0   ,65+(i-1)*16 oppure 1+(i-5)*16 della SK 6
    Public TempOut(12) As Single           '5   12    67     2    R,  00,   0   ,
    Public MWHCOut(12) As Single           '5   12    69     2    R,  00,   0   ,
    Public CondHC(12) As Single            '5   12    71     2    R,  00,   0   ,
    Public CondST(12) As Single            '5   12    73     2    R,  00,   0   ,
    Public LunghZona(12) As Single         '5   12    75     2    R,  00,   0   ,
    Public Reserved(12) As Single          '5   12    77     2    R,  00,   0   ,
    Public codZona(12) As Single           '5   12    79     2    R,  00,   0   ,1 cond., 0 no
    '   6    1     1     2    R,  00,   0   ,dummy
    Public Nfile(16) As Single '            7    2     1     2    R,  00,   0   ,N. file 1  passo
    '                                       7    3     3     2    R,  00,   0   ,N. file 2  passo
    '                                       7    4     5     2    R,  00,   0   ,N. file 3  passo
    '                                       7    5     7     2    R,  00,   0   ,N. file 4  passo
    '                                       7    6     9     2    R,  00,   0   ,N. file 5  passo
    '                                       7    7    11     2    R,  00,   0   ,N. file 6  passo
    '                                       7    8    13     2    R,  00,   0   ,N. file 7  passo
    '                                       7    9    15     2    R,  00,   0   ,N. file 8  passo
    '                                       7   10    17     2    R,  00,   0   ,N. file 9  passo
    '                                       7   11    19     2    R,  00,   0   ,N. file 10 passo
    '                                       7   12    21     2    R,  00,   0   ,N. file 11 passo
    '                                       7   13    23     2    R,  00,   0   ,N. file 12 passo
    '                                       7   14    25     2    R,  00,   0   ,N. file 13 passo
    '                                       7   15    27     2    R,  00,   0   ,N. file 14 passo
    '                                       7   16    29     2    R,  00,   0   ,N. file 15 passo
    '                                       7   17    31     2    R,  00,   0   ,N. file 16 passo
    Public Tmedia(16) As Single '           7   25    33     2    R,  00,   0   ,T. med. 1  passo
    '                                       7   26    35     2    R,  00,   0   ,T. med. 2  passo
    '                                       7   27    37     2    R,  00,   0   ,T. med. 3  passo
    '                                       7   28    39     2    R,  00,   0   ,T. med. 4  passo
    '                                       7   29    41     2    R,  00,   0   ,T. med. 5  passo
    '                                       7   30    43     2    R,  00,   0   ,T. med. 6  passo
    '                                       7   31    45     2    R,  00,   0   ,T. med. 7  passo
    '                                       7   32    47     2    R,  00,   0   ,T. med. 8  passo
    '                                       7   33    49     2    R,  00,   0   ,T. med. 9  passo
    '                                       7   34    51     2    R,  00,   0   ,T. med. 10 passo
    '                                       7   35    53     2    R,  00,   0   ,T. med. 11 passo
    '                                       7   36    55     2    R,  00,   0   ,T. med. 12 passo
    '                                       7   37    57     2    R,  00,   0   ,T. med. 13 passo
    '                                       7   38    59     2    R,  00,   0   ,T. med. 14 passo
    '                                       7   39    61     2    R,  00,   0   ,T. med. 15 passo
    '                                       7   40    63     2    R,  00,   0   ,T. med. 16 passo
    Public WidthMFVC As Single '            7   42    65     2    R,  00,   0   ,Width x fasci sotto vent.comune
    Public AltzDivergente As Single '       7   48    67     2    R,  00,   0   ,Altezza divergente
    Public GiocosuDiametro As Single '      7   49    69     2    R,  00,   0   ,Rapporto gioco/diametro
    Public LunghFascioEff As Single '       7   50    71     2    R,  00,   0   ,Lunghezza efficace fascio
    Public Tarpal As Single '               7   xx    73     2    R,  00,   0   ,Temp aria sulle pale
    Public HPmotor As Single '              7   22    75     2    R,  00,   0   ,HP-Motor
    Public AddStaticPressure As Single '    7   47    77     2    R,  00,   0   ,Addit. static pressure
    Public UExternal As Single '            7   xx    79     2    R,  00,   0   ,U-External
    Public UBare As Single '                7   xx    81     2    R,  00,   0   ,U-Bare
    Public Vfan As Single '                 7   xx    83     2    R,  00,   0   ,V@fan
    Public NtotVentilatori As Single '      7   46    85     2    R,  00,   0   ,N. tot. ventilatori
    Public WidtheffFST As Single '          7   xx    87     2    R,  00,   0   ,width eff. con F.S.T.
    Public Widtheff As Single '             7   xx    89     2    R,  00,   0   ,width effective    
    Public percdifftot As Single '          7   xx    91     2    R,  00,   0   ,% diff tot          
    Public MTD_AVG As Single '              7   xx    93     2    R,  00,   0   ,MTD-AVG            
    Public deltaPtot As Single '            7   xx    95     2    R,  00,   0   ,deltaP totali      
    Public SupLisciaTot As Single '         7   44    97     2    R,  00,   0   ,Superficie liscia totale
    Public SupEstesaTot As Single '          7   xx    99     2    R,  00,   0   ,Superficie esterna totale
    Public SCFM As Single '                 7   xx   101     2    R,  00,   0   ,SCFM
    Public ACFM As Single '                 7   xx   103     2    R,  00,   0   ,ACFM
    Public TipSpeed As Single '             7   xx   105     2    R,  00,   0   ,Tip speed
    Public HPfan As Single  '              7   23   107     2    R,  00,   0   ,HP-Fan
    Public StaticPressure As Single '       7   xx   109     2    R,  00,   0   ,Static Pressure Tot
    Public AngoloPale As Single '           7   45   111     2    R,  00,   0   ,Angolo pale 
    Public TariaOut As Single   '           7   43   113     2    R,  00,   0   ,T aria out
    Public DiaVent As Single '              7    1   115     2    R,  00,   0   ,Dia. ventilatore
    Public DbocchOut As Single '            7   18   117     2    R,  00,   0   ,Dbocch.out
    Public DBocchIn As Single '             7   19   119     2    R,  00,   0   ,Dbocch.in
    Public FaceVelocity As Single '         7   24   121     2    R,  00,   0   ,Face Velocity
    Public LunghezzaFascio As Single '      7   20   123     2    R,  00,   0   ,Lunghezza fascio
    Public LarghezzaFascio As Single '      7   21   125     2    R,  00,   0   ,Larghezza fascio
    Public NumUnit As Single '              7   41   127     2    R,  00,   0   ,N. di unità
    Public Sub Copia(ByVal Out As clsAltern)
        Dim i As Integer
        Out.Engineer = Engineer
        Out.TipoUnita = TipoUnita
        Out.NumFasciParall = NumFasciParall
        Out.NFPAlberoPassante = NFPAlberoPassante
        Out.NumTotPassi = NumTotPassi
        Out.NbocIn = NbocIn
        Out.NBocOut = NBocOut
        Out.NumTipiTubi = NumTipiTubi
        Out.RPMVentilatore = RPMVentilatore
        Out.TipoVentilatore = TipoVentilatore
        Out.PerCentoAV = PerCentoAV
        Out.Positioner_Rele = Positioner_Rele
        Out.TipoPale = TipoPale
        Out.NumZone = NumZone
        Out.RPMmotore = RPMmotore
        Out.codSlope = codSlope
        Out.codRiduttore = codRiduttore
        Out.Autom = Autom
        Out.codSplit = codSplit
        Out.codImbocco = codImbocco
        Out.NunitaxDS = NunitaxDS
        Out.codAsterisco = codAsterisco
        Out.NoteBocchelli = NoteBocchelli
        Out.NoteGenerali = NoteGenerali
        Out.GiornoCalcolo = GiornoCalcolo
        Out.MeseCalcolo = MeseCalcolo
        Out.AnnoCalcolo = AnnoCalcolo
        Out.codTestate = codTestate
        Out.codSC = codSC
        Out.NumPale = NumPale
        Out.PassiOrizzontali = PassiOrizzontali
        Out.NumFasciStacked = NumFasciStacked
        Out.NumRowsTopB = NumRowsTopB
        Out.NumRowsMediumB = NumRowsMediumB
        Out.NumRowsBottomB = NumRowsBottomB
        Out.NumFileUnitaAccopp = NumFileUnitaAccopp
        Out.SwitchScriviVent = SwitchScriviVent
        Out.NumItemsxUnita = NumItemsxUnita
        For i = 1 To 6
            Out.indRecDatiItem(i) = indRecDatiItem(i)
            Out.NumFasciItem(i) = NumFasciItem(i)
        Next
        Out.GiuntoTP = GiuntoTP
        Out.switchSerpentino = switchSerpentino
        Out.switchFasciAccoppiati = switchFasciAccoppiati
        Out.switchPersianeAUt = switchPersianeAUt
        Out.AirSupplyFan = AirSupplyFan
        Out.AirSupplyPers = AirSupplyPers
        Out.CorrelAria = CorrelAria
        Out.Prinop = Prinop
        For i = 1 To 2
            Out.BWG(i) = BWG(i)
            Out.TipoBWG(i) = TipoBWG(i)
            Out.codMater(i) = codMater(i)
            Out.Conduc(i) = Conduc(i)
            Out.codAlett(i) = codAlett(i)
            Out.SpAlett(i) = SpAlett(i)
            Out.NumFile(i) = NumFile(i)
            Out.NumTubiFascio(i) = NumTubiFascio(i)
            Out.NumTubiSC(i) = NumTubiSC(i)
            Out.codTurbolators(i) = codTurbolators(i)
            Out.GiuntiTP(i) = GiuntiTP(i)
            Out.DiaTubo(i) = DiaTubo(i)
            Out.Passo(i) = Passo(i)
            Out.DiAl(i) = DiAl(i)
            Out.NumAlettxInch(i) = NumAlettxInch(i)
            Out.NtotTubi(i) = NtotTubi(i)
            Out.SpessInch(i) = SpessInch(i)
            Out.SurfRatio(i) = SurfRatio(i)
            Out.SurfRatioA(i) = SurfRatioA(i)
            Out.CoeffSP_A(i) = CoeffSP_A(i)
            Out.CoeffSP_B(i) = CoeffSP_B(i)
            Out.CoeffAR_A(i) = CoeffAR_A(i)
            Out.CoeffAR_B(i) = CoeffAR_B(i)
        Next
        Out.ChiaveCondens = ChiaveCondens
        Out.TipoCalcolo = TipoCalcolo
        Out.AdditStaticPr = AdditStaticPr
        For i = 1 To 12
            Out.TipoTubi(i) = TipoTubi(i)
            Out.DutyZone(i) = DutyZone(i)
            Out.TempOut(i) = TempOut(i)
            Out.MWHCOut(i) = MWHCOut(i)
            Out.CondHC(i) = CondHC(i)
            Out.CondST(i) = CondST(i)
            Out.LunghZona(i) = LunghZona(i)
            Out.Reserved(i) = Reserved(i)
            Out.codZona(i) = codZona(i)
        Next
        For i = 1 To 16
            Out.Nfile(i) = Nfile(i)
            Out.Tmedia(i) = Tmedia(i)
        Next
        Out.WidthMFVC = WidthMFVC
        Out.AltzDivergente = AltzDivergente
        Out.GiocosuDiametro = GiocosuDiametro
        Out.LunghFascioEff = LunghFascioEff
        Out.Tarpal = Tarpal
        Out.HPmotor = HPmotor
        Out.AddStaticPressure = AddStaticPressure
        Out.UExternal = UExternal
        Out.UBare = UBare
        Out.Vfan = Vfan
        Out.NtotVentilatori = NtotVentilatori
        Out.WidtheffFST = WidtheffFST
        Out.Widtheff = Widtheff
        Out.percdifftot = percdifftot
        Out.MTD_AVG = MTD_AVG
        Out.deltaPtot = deltaPtot
        Out.SupLisciaTot = SupLisciaTot
        Out.SupEstesaTot = SupEstesaTot
        Out.SCFM = SCFM
        Out.ACFM = ACFM
        Out.TipSpeed = TipSpeed
        Out.HPfan = HPfan
        Out.StaticPressure = StaticPressure
        Out.AngoloPale = AngoloPale
        Out.TariaOut = TariaOut
        Out.DiaVent = DiaVent
        Out.DbocchOut = DbocchOut
        Out.DBocchIn = DBocchIn
        Out.FaceVelocity = FaceVelocity
        Out.LunghezzaFascio = LunghezzaFascio
        Out.LarghezzaFascio = LarghezzaFascio
        Out.NumUnit = NumIt
    End Sub
End Class
