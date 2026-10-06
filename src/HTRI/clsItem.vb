Imports routbase1
<Serializable()> Public Class clsItem
    Public NumALt As Integer
    Public Alterns As OggList
    '---------------------------------------------------------------------------------------
    Public Sigla As String = "" '            2    1     1    10    S,  00,   0   ,Sigla item
    Public Banco As String = "" '            2    2    11     2    S,  00,   0   ,Banco
    Public Servizio As String = "" '         2    3    13    20    S,  00,   0   ,Servizio
    Public Fluido As String = "" '           2    4    33    10    S,  00,   0   ,Fluido circolante
    Public codMontaggio As Integer '    2    5    43     1    I,  11,   0   ,Codice montaggio
    Public codTelaio As Integer '       2    6    44     1    I,  12,   0   ,Codice telaio
    Public codStutture As Integer '      2    7    45     1    I,  12,   0   ,Codice strutture
    Public codCamereAria As Integer '   2    8    46     1    I,  12,   0   ,Codice camere aria
    Public codTestate As Integer '      2    9    47     1    I,  13,   0   ,Codice testate
    Public codMaterTestate As Integer ' 2   10    48     1    I,  14,   0   ,Cod. materiale testate
    Public codmaterTappi As Integer '   2   11    49     1    I,  15,   0   ,Cod. materiale tappi
    '                                   2   12    50     1    I,  00,   0   ,-----
    Public codRatingFlange As Integer ' 2   13    51     1    I,  16,   0   ,Rating flange
    Public codCollaudi As Integer '     2   14    52     1    I,  17,   0   ,Cod. collaudi
    Public codPasserelle As Integer '   2   15    53     1    I,  18,   0   ,Cod. passerelle
    '                                   2   16    54     1    I,  00,   0   ,-----
    Public codIsolamentoMotore As Integer '    2   17    55     1    I,  19,   0   ,Cod. isolamento motore
    Public codTipoMotore As Integer '   2   18    56     1    I,  27,   0   ,Cod. tipo motore
    Public codRicircolo As Integer '    2   19    57     1    I,  21,   0   ,Cod. ricircolo
    Public codPersiane As Integer '     2   20    58     1    I,  22,   0   ,Cod. persiane
    Public codSpecifiche As Integer '   2   21    59     1    I,  17,   0   ,Cod. specifiche
    Public codMaterialeGuarnizioni As Integer '    2   22    60     1    I,  24,   0   ,Cod. materiale guarnizioni
    Public codMaterTubiSC As Integer '  2   23    61     1    I,  23,   0   ,Cod. mat. tubi st. coil
    Public codVoltCicliFase As Integer '2   24    62     1    I,  26,   0   ,Cod. volt-cicli-fasi motore
    Public codRatingFlangeSC As Integer '2   25    63     1    I,  16,   0   ,Cod. rating flange st. coil
    '                                   2   26    64     1    I,  00,   0   ,-----
    Public codScalePioli As Integer '   2   27    65     1    I,  29,   0   ,Cod. scale pioli
    Public codScaleGradini As Integer ' 2   28    66     1    I,  29,   0   ,Cod. scale gradini
    Public codInterrVibrazioni As Integer '2   29    67     1    I,  29,   0   ,Cod. interr. vibrazioni
    Public codmaterAlette As Integer '  2   30    73     1    I,  00,   0   ,Cod. materiale alette
    Public BWGtubiSC As Integer '       2   31    74     1    I,  00,   0   ,BWG tubi steam coil
    Public TipoBWGSC As String = "" '       2   32    75     2    S,  00,   0   ,Tipo BWG tubi s.c.
    Public TipoAletteSC As Integer '    2   33    77     1    I,  00,   0   ,Tipo alette st. coil
    Public NAlettexPollice As Single '  2   34    81     2    R,  00,   0   ,N. alette 1" St. coil
    Public PressInSC As Single '        2   35    83     2    R,  00,   0   ,Pressione ingresso st. coil
    Public PressDesSC As Single '       2   36    85     2    R,  00,   0   ,Pressione progetto st. coil
    Public TempInSC As Single '         2   37    87     2    R,  00,   0   ,Temperat. ingresso st. coil
    Public TempDesSC As Single '        2   38    89     2    R,  00,   0   ,Temperat. progetto st. coil
    Public DiamInSC As Single '         2   39    91     2    R,  00,   0   ,Dia. boc. ingresso st. coil
    Public DiamOutSC As Single '        2   40    93     2    R,  00,   0   ,Dia. boc. uscita st. coil
    Public Corrosione As Single '       2   41    95     2    R,  00,   0   ,Corrosione
    Public Banco2 As String = "" '           2   42    97     2    S,  00,   0   ,Banco 2
    Public Banco3 As String = "" '           2   43    99     2    S,  00,   0   ,Banco 3
    Public Banco4 As String = "" '           2   44   101     2    S,  00,   0   ,Banco 4
    Public codProprietaLiquido As Integer '2   45   103     1    I,  00,   0   ,Codice proprieta' liquido
    Public codproprietaVapore As Integer ' 2   46   104     1    I,  00,   0   ,Codice proprieta' vapore
    Public NumRev As Integer '          2   47   105     1    I,  00,   0   ,N. revisione
    Public indNote(5) As Integer '        2   48   106     1    I,  00,   0   ,N. rec. note 1ø alternativa
    'Public indNote2 As Integer '        2   49   107     1    I,  00,   0   ,N. rec. note 2ø alternativa
    'Public indNote3 As Integer '        2   50   108     1    I,  00,   0   ,N. rec. note 3ø alternativa
    'Public indNote4 As Integer '        2   51   109     1    I,  00,   0   ,N. rec. note 4ø alternativa
    'Public indNote5 As Integer '        2   52   110     1    I,  00,   0   ,N. rec. note 5ø alternativa
    Public DatiManuali As Integer '     2   53   113     1    I,  00,   0   ,Dati manuali ..............
    Public SteamCoil As String = "" '        2   54   114     1    S,  00,   0   ,Steam coil (YE NO)
    Public ChiaveDatiItem As Integer '  2   55   117     1    I,  00,   0   ,Chiave dati item
    Public NumTotCalcReg As Integer '   2   56   118     1    I,  00,   0   ,N. totale calcoli registrati
    Public indRecDati(5) As Integer '     2   57   119     1    I,  00,   0   ,N. 1ø rec. dati
    Public ChiaveVali(5) As Integer '     2   58   120     1    I,  00,   0   ,N. 1ø chiave validita'
    'Public indRecDati2 As Integer '     2   59   121     1    I,  00,   0   ,N. 2ø rec. dati
    'Public ChiaveVali2 As Integer '     2   60   122     1    I,  00,   0   ,N. 2ø chiave validita'
    'Public indRecDati3 As Integer '     2   61   123     1    I,  00,   0   ,N. 3ø rec. dati
    'Public ChiaveVali3 As Integer '     2   62   124     1    I,  00,   0   ,N. 3ø chiave validita'
    'Public indRecDati4 As Integer '     2   63   125     1    I,  00,   0   ,N. 4ø rec. dati
    'Public ChiaveVali4 As Integer '     2   64   126     1    I,  00,   0   ,N. 4ø chiave validita'
    'Public indRecDati5 As Integer '     2   65   127     1    I,  00,   0   ,N. 5ø rec. dati
    'Public ChiaveVali5 As Integer '     2   66   128     1    I,  00,   0   ,N. 5ø chiave validita'
    Public VENT As String = "" '             2   67    68     1    S,  00,   0   ,VENT       (n.tot size)
    Public DRAIN As String = "" '            2   68    69     1    S,  00,   0   ,DRAIN      (n.tot size)
    Public THERMOWELL As String = "" '       2   69    70     1    S,  00,   0   ,THERMOWELL (n.tot size)
    Public PRESSGAUGES As String = "" '      2   70    71     1    S,  00,   0   ,PRESS.G.   (n.tot size)
    Public Automatico As Integer '      2   71   115     1    I,  00,   0   ,Automatico 0 NO 1 SI
    Public Nrepliche As Integer '       2   72   116     1    I,  00,   0   ,N° repliche
    Public DutyRDIT As Single '         3    1     1     2    R,  00,   0   ,Duty totale
    Public TempIn As Single '           3    2     3     2    R,  00,   0   ,Temp. in
    Public TempOut As Single '          3    3     5     2    R,  00,   0   ,Temp. out
    Public LiqHCIn As Single '          3    4     7     2    R,  00,   0   ,Liq. HC in
    Public VapHCIn As Single '          3    5     9     2    R,  00,   0   ,Vap. HC in
    Public NonCondIn As Single '        3    6    11     2    R,  00,   0   ,Non-Cond in
    Public SteamIn As Single '          3    7    13     2    R,  00,   0   ,Steam in
    Public WaterIn As Single '          3    8    15     2    R,  00,   0   ,Water in
    Public PressIn As Single '          3    9    17     2    R,  00,   0   ,Pressione in
    Public dpAllowable As Single '      3   10    19     2    R,  00,   0   ,D.P allowable
    Public TempAirIn As Single '        3   11    21     2    R,  00,   0   ,Temp. air in
    Public Fouling As Single '          3   12    23     2    R,  00,   0   ,Fouling
    Public MWNonCond As Single '        3   13    25     2    R,  00,   0   ,MW incond.
    Public MWVapIn As Single '          3   14    27     2    R,  00,   0   ,MW vap. in
    Public MWVapOut As Single '         3   15    29     2    R,  00,   0   ,MW vap out
    Public vLiq1 As Single '            3   16    31     2    R,  00,   0   ,Visc. liq. HC
    Public T_vLiq1 As Single '          3   17    33     2    R,  00,   0   ,Temp.
    Public vLiq2 As Single '            3   18    35     2    R,  00,   0   ,Visc. liq. HC
    Public T_vLiq2 As Single '          3   19    37     2    R,  00,   0   ,Temp.
    Public kLiq1 As Single '            3   20    39     2    R,  00,   0   ,Cond. liq.
    Public T_kLiq1 As Single '          3   21    41     2    R,  00,   0   ,Temp.
    Public kLiq2 As Single '            3   22    43     2    R,  00,   0   ,Cond. liq.
    Public T_kLiq2 As Single '          3   27    45     2    R,  00,   0   ,Temp.
    Public Grav1 As Single '            3   28    47     2    R,  00,   0   ,Gravità sp. liq
    Public T_Grav1 As Single '          3   29    49     2    R,  00,   0   ,Temp.
    Public Grav2 As Single '            3   30    51     2    R,  00,   0   ,Gravità sp. liq
    Public T_Grav2 As Single '          3   31    53     2    R,  00,   0   ,Temp.
    Public SpLiq1 As Single '           3   32    55     2    R,  00,   0   ,Calore sp. liq.
    Public T_SpLiq1 As Single '         3   33    57     2    R,  00,   0   ,Temp.
    Public SpLiq2 As Single '           3   34    59     2    R,  00,   0   ,Calore sp. liq.
    Public T_SpLiq2 As Single '         3   35    61     2    R,  00,   0   ,Temp.
    Public SpNonCond1 As Single '       3   36    63     2    R,  00,   0   ,Cal. sp. NC  
    Public T_SpNonCond1 As Single '     3   37    65     2    R,  00,   0   ,Temp.
    Public SpNonCond2 As Single '       3   38    67     2    R,  00,   0   ,Cal. sp. NC  
    Public T_SpNonCond2 As Single '     3   39    69     2    R,  00,   0   ,Temp.
    Public vVap1 As Single '            3   40    71     2    R,  00,   0   ,           
    Public T_vVap1 As Single '          3   41    73     2    R,  00,   0   ,Temp.
    Public vVap2 As Single '            3   42    75     2    R,  00,   0   ,             
    Public T_vVap2 As Single '          3   43    77     2    R,  00,   0   ,Temp.
    Public kVap1 As Single '            3   44    79     2    R,  00,   0   ,               
    Public T_kVap1 As Single '          3   45    81     2    R,  00,   0   ,Temp.
    Public kVap2 As Single '            3   46    83     2    R,  00,   0   ,                
    Public T_kVap2 As Single '          3   47    85     2    R,  00,   0   ,Temp.
    Public SpVap1 As Single '           3   48    87     2    R,  00,   0   ,
    Public T_SpVap1 As Single '         3   49    89     2    R,  00,   0   ,Temp.
    Public SpVap2 As Single '           3   50    91     2    R,  00,   0   ,               
    Public T_SpVap2 As Single '         3   51    93     2    R,  00,   0   ,Temp.
    Public ComprFactor1 As Single '     3   52    95     2    R,  00,   0   ,
    Public T_ComprFactor1 As Single '   3   53    97     2    R,  00,   0   ,Temp.
    Public ComprFactor2 As Single '     3   54    99     2    R,  00,   0   ,                
    Public T_ComprFactor2 As Single '   3   55   101     2    R,  00,   0   ,Temp.
    Public DesignPressure As Single '   3   25   103     2    R,  00,   0   ,Design Pressure
    Public TestPressure As Single '     3   26   105     2    R,  00,   0   ,Test Pressure
    Public Provvisorio3 As Single '     3   24   107     2    R,  00,   0   ,Design Temperature
    Public CaloreLatente As Single '    3   56   109     2    R,  00,   0   ,
    Public Provvisorio4 As Single '     3   57   111     2    R,  00,   0   ,
    Public TempMinAria As Single '      3   23   113     2    R,  00,   0   ,Temp min.aria
    Public Provvisorio1 As Single '     3   58   115     2    R,  00,   0   ,
    Public Provvisorio2 As Single '     3   59   117     2    R,  00,   0   ,
    Public CondenHC As Single '         3   60   119     2    R,  00,   0   ,
    Public CondSteam As Single '        3   61   121     2    R,  00,   0   ,
    Public Elevaz As Single '           3   62   123     2    R,  00,   0   ,
    Public vLiq3 As Single '            3   63   125     2    R,  00,   0   ,Visc. liq. HC
    Public T_vLiq3 As Single '          3   64   127     2    R,  00,   0   ,Temp.
    Public Property RDIT(ByVal i As Integer) As Single
        Get
            Select Case i
                Case 1 : Return DutyRDIT   '         3    1     1     2    R,  00,   0   ,Duty totale
                Case 2 : Return TempIn   '           3    2     3     2    R,  00,   0   ,Temp. in
                Case 3 : Return TempOut   '          3    3     5     2    R,  00,   0   ,Temp. out
                Case 4 : Return LiqHCIn   '          3    4     7     2    R,  00,   0   ,Liq. HC in
                Case 5 : Return VapHCIn   '          3    5     9     2    R,  00,   0   ,Vap. HC in
                Case 6 : Return NonCondIn   '        3    6    11     2    R,  00,   0   ,Non-Cond in
                Case 7 : Return SteamIn   '          3    7    13     2    R,  00,   0   ,Steam in
                Case 8 : Return WaterIn   '          3    8    15     2    R,  00,   0   ,Water in
                Case 9 : Return PressIn   '          3    9    17     2    R,  00,   0   ,Pressione in
                Case 10 : Return dpAllowable   '      3   10    19     2    R,  00,   0   ,D.P allowable
                Case 11 : Return TempAirIn   '        3   11    21     2    R,  00,   0   ,Temp. air in
                Case 12 : Return Fouling   '          3   12    23     2    R,  00,   0   ,Fouling
                Case 13 : Return MWNonCond   '        3   13    25     2    R,  00,   0   ,MW incond.
                Case 14 : Return MWVapIn   '          3   14    27     2    R,  00,   0   ,MW vap. in
                Case 15 : Return MWVapOut   '         3   15    29     2    R,  00,   0   ,MW vap out
                Case 16 : Return vLiq1   '            3   16    31     2    R,  00,   0   ,Visc. liq. HC
                Case 17 : Return T_vLiq1   '          3   17    33     2    R,  00,   0   ,Temp.
                Case 18 : Return vLiq2   '            3   18    35     2    R,  00,   0   ,Visc. liq. HC
                Case 19 : Return T_vLiq2   '          3   19    37     2    R,  00,   0   ,Temp.
                Case 20 : Return kLiq1   '            3   20    39     2    R,  00,   0   ,Cond. liq.
                Case 21 : Return T_kLiq1   '          3   21    41     2    R,  00,   0   ,Temp.
                Case 22 : Return kLiq2   '            3   22    43     2    R,  00,   0   ,Cond. liq.
                Case 23 : Return T_kLiq2   '          3   27    45     2    R,  00,   0   ,Temp.
                Case 24 : Return Grav1   '            3   28    47     2    R,  00,   0   ,Gravità sp. liq
                Case 25 : Return T_Grav1   '          3   29    49     2    R,  00,   0   ,Temp.
                Case 26 : Return Grav2   '            3   30    51     2    R,  00,   0   ,Gravità sp. liq
                Case 27 : Return T_Grav2   '          3   31    53     2    R,  00,   0   ,Temp.
                Case 28 : Return SpLiq1   '           3   32    55     2    R,  00,   0   ,Calore sp. liq.
                Case 20 : Return T_SpLiq1   '         3   33    57     2    R,  00,   0   ,Temp.
                Case 30 : Return SpLiq2   '           3   34    59     2    R,  00,   0   ,Calore sp. liq.
                Case 31 : Return T_SpLiq2   '         3   35    61     2    R,  00,   0   ,Temp.
                Case 32 : Return SpNonCond1   '       3   36    63     2    R,  00,   0   ,Cal. sp. NC  
                Case 33 : Return T_SpNonCond1   '     3   37    65     2    R,  00,   0   ,Temp.
                Case 34 : Return SpNonCond2   '       3   38    67     2    R,  00,   0   ,Cal. sp. NC  
                Case 35 : Return T_SpNonCond2   '     3   39    69     2    R,  00,   0   ,Temp.
                Case 36 : Return vVap1   '            3   40    71     2    R,  00,   0   ,           
                Case 37 : Return T_vVap1   '          3   41    73     2    R,  00,   0   ,Temp.
                Case 38 : Return vVap2   '            3   42    75     2    R,  00,   0   ,             
                Case 39 : Return T_vVap2   '          3   43    77     2    R,  00,   0   ,Temp.
                Case 40 : Return kVap1   '            3   44    79     2    R,  00,   0   ,               
                Case 41 : Return T_kVap1   '          3   45    81     2    R,  00,   0   ,Temp.
                Case 42 : Return kVap2   '            3   46    83     2    R,  00,   0   ,                
                Case 43 : Return T_kVap2   '          3   47    85     2    R,  00,   0   ,Temp.
                Case 44 : Return SpVap1   '           3   48    87     2    R,  00,   0   ,
                Case 45 : Return T_SpVap1   '         3   49    89     2    R,  00,   0   ,Temp.
                Case 46 : Return SpVap2   '           3   50    91     2    R,  00,   0   ,               
                Case 47 : Return T_SpVap2   '         3   51    93     2    R,  00,   0   ,Temp.
                Case 48 : Return ComprFactor1   '     3   52    95     2    R,  00,   0   ,
                Case 49 : Return T_ComprFactor1   '   3   53    97     2    R,  00,   0   ,Temp.
                Case 50 : Return ComprFactor2   '     3   54    99     2    R,  00,   0   ,                
                Case 51 : Return T_ComprFactor2   '   3   55   101     2    R,  00,   0   ,Temp.
                Case 52 : Return DesignPressure   '   3   25   103     2    R,  00,   0   ,Design Pressure
                Case 53 : Return TestPressure   '     3   26   105     2    R,  00,   0   ,Test Pressure
                Case 54 : Return Provvisorio3   '     3   24   107     2    R,  00,   0   ,Design Temperature
                Case 55 : Return CaloreLatente   '    3   56   109     2    R,  00,   0   ,
                Case 56 : Return Provvisorio4   '     3   57   111     2    R,  00,   0   ,
                Case 57 : Return TempMinAria   '      3   23   113     2    R,  00,   0   ,Temp min.aria
                Case 58 : Return Provvisorio1   '     3   58   115     2    R,  00,   0   ,
                Case 59 : Return Provvisorio2   '     3   59   117     2    R,  00,   0   ,
                Case 60 : Return CondenHC   '         3   60   119     2    R,  00,   0   ,
                Case 61 : Return CondSteam   '        3   61   121     2    R,  00,   0   ,
                Case 62 : Return Elevaz   '           3   62   123     2    R,  00,   0   ,
                Case 63 : Return vLiq3   '            3   63   125     2    R,  00,   0   ,Visc. liq. HC
                Case 64 : Return T_vLiq3   '          3   64   127     2    R,  00,   0   ,Temp.
            End Select
        End Get
        Set(ByVal value As Single)
            Select Case i
                Case 1 : DutyRDIT = value '         3    1     1     2    R,  00,   0   ,Duty totale
                Case 2 : TempIn = value '           3    2     3     2    R,  00,   0   ,Temp. in
                Case 3 : TempOut = value '          3    3     5     2    R,  00,   0   ,Temp. out
                Case 4 : LiqHCIn = value '          3    4     7     2    R,  00,   0   ,Liq. HC in
                Case 5 : VapHCIn = value '          3    5     9     2    R,  00,   0   ,Vap. HC in
                Case 6 : NonCondIn = value '        3    6    11     2    R,  00,   0   ,Non-Cond in
                Case 7 : SteamIn = value '          3    7    13     2    R,  00,   0   ,Steam in
                Case 8 : WaterIn = value '          3    8    15     2    R,  00,   0   ,Water in
                Case 9 : PressIn = value '          3    9    17     2    R,  00,   0   ,Pressione in
                Case 10 : dpAllowable = value '      3   10    19     2    R,  00,   0   ,D.P allowable
                Case 11 : TempAirIn = value '        3   11    21     2    R,  00,   0   ,Temp. air in
                Case 12 : Fouling = value '          3   12    23     2    R,  00,   0   ,Fouling
                Case 13 : MWNonCond = value '        3   13    25     2    R,  00,   0   ,MW incond.
                Case 14 : MWVapIn = value '          3   14    27     2    R,  00,   0   ,MW vap. in
                Case 15 : MWVapOut = value '         3   15    29     2    R,  00,   0   ,MW vap out
                Case 16 : vLiq1 = value '            3   16    31     2    R,  00,   0   ,Visc. liq. HC
                Case 17 : T_vLiq1 = value '          3   17    33     2    R,  00,   0   ,Temp.
                Case 18 : vLiq2 = value '            3   18    35     2    R,  00,   0   ,Visc. liq. HC
                Case 19 : T_vLiq2 = value '          3   19    37     2    R,  00,   0   ,Temp.
                Case 20 : kLiq1 = value '            3   20    39     2    R,  00,   0   ,Cond. liq.
                Case 21 : T_kLiq1 = value '          3   21    41     2    R,  00,   0   ,Temp.
                Case 22 : kLiq2 = value '            3   22    43     2    R,  00,   0   ,Cond. liq.
                Case 23 : T_kLiq2 = value '          3   27    45     2    R,  00,   0   ,Temp.
                Case 24 : Grav1 = value '            3   28    47     2    R,  00,   0   ,Gravità sp. liq
                Case 25 : T_Grav1 = value '          3   29    49     2    R,  00,   0   ,Temp.
                Case 26 : Grav2 = value '            3   30    51     2    R,  00,   0   ,Gravità sp. liq
                Case 27 : T_Grav2 = value '          3   31    53     2    R,  00,   0   ,Temp.
                Case 28 : SpLiq1 = value '           3   32    55     2    R,  00,   0   ,Calore sp. liq.
                Case 20 : T_SpLiq1 = value '         3   33    57     2    R,  00,   0   ,Temp.
                Case 30 : SpLiq2 = value '           3   34    59     2    R,  00,   0   ,Calore sp. liq.
                Case 31 : T_SpLiq2 = value '         3   35    61     2    R,  00,   0   ,Temp.
                Case 32 : SpNonCond1 = value '       3   36    63     2    R,  00,   0   ,Cal. sp. NC  
                Case 33 : T_SpNonCond1 = value '     3   37    65     2    R,  00,   0   ,Temp.
                Case 34 : SpNonCond2 = value '       3   38    67     2    R,  00,   0   ,Cal. sp. NC  
                Case 35 : T_SpNonCond2 = value '     3   39    69     2    R,  00,   0   ,Temp.
                Case 36 : vVap1 = value '            3   40    71     2    R,  00,   0   ,           
                Case 37 : T_vVap1 = value '          3   41    73     2    R,  00,   0   ,Temp.
                Case 38 : vVap2 = value '            3   42    75     2    R,  00,   0   ,             
                Case 39 : T_vVap2 = value '          3   43    77     2    R,  00,   0   ,Temp.
                Case 40 : kVap1 = value '            3   44    79     2    R,  00,   0   ,               
                Case 41 : T_kVap1 = value '          3   45    81     2    R,  00,   0   ,Temp.
                Case 42 : kVap2 = value '            3   46    83     2    R,  00,   0   ,                
                Case 43 : T_kVap2 = value '          3   47    85     2    R,  00,   0   ,Temp.
                Case 44 : SpVap1 = value '           3   48    87     2    R,  00,   0   ,
                Case 45 : T_SpVap1 = value '         3   49    89     2    R,  00,   0   ,Temp.
                Case 46 : SpVap2 = value '           3   50    91     2    R,  00,   0   ,               
                Case 47 : T_SpVap2 = value '         3   51    93     2    R,  00,   0   ,Temp.
                Case 48 : ComprFactor1 = value '     3   52    95     2    R,  00,   0   ,
                Case 49 : T_ComprFactor1 = value '   3   53    97     2    R,  00,   0   ,Temp.
                Case 50 : ComprFactor2 = value '     3   54    99     2    R,  00,   0   ,                
                Case 51 : T_ComprFactor2 = value '   3   55   101     2    R,  00,   0   ,Temp.
                Case 52 : DesignPressure = value '   3   25   103     2    R,  00,   0   ,Design Pressure
                Case 53 : TestPressure = value '     3   26   105     2    R,  00,   0   ,Test Pressure
                Case 54 : Provvisorio3 = value '     3   24   107     2    R,  00,   0   ,Design Temperature
                Case 55 : CaloreLatente = value '    3   56   109     2    R,  00,   0   ,
                Case 56 : Provvisorio4 = value '     3   57   111     2    R,  00,   0   ,
                Case 57 : TempMinAria = value '      3   23   113     2    R,  00,   0   ,Temp min.aria
                Case 58 : Provvisorio1 = value '     3   58   115     2    R,  00,   0   ,
                Case 59 : Provvisorio2 = value '     3   59   117     2    R,  00,   0   ,
                Case 60 : CondenHC = value '         3   60   119     2    R,  00,   0   ,
                Case 61 : CondSteam = value '        3   61   121     2    R,  00,   0   ,
                Case 62 : Elevaz = value '           3   62   123     2    R,  00,   0   ,
                Case 63 : vLiq3 = value '            3   63   125     2    R,  00,   0   ,Visc. liq. HC
                Case 64 : T_vLiq3 = value '          3   64   127     2    R,  00,   0   ,Temp.
            End Select
        End Set
    End Property
    Public Sub New()
        Alterns = New OggList(1)
    End Sub
    Public Sub Copia(ByVal Out As clsItem)
        Dim i As Integer
        Out.Banco = Banco
        Out.Servizio = Servizio
        Out.Fluido = Fluido
        Out.codMontaggio = codMontaggio
        Out.codTelaio = codTelaio
        Out.codStutture = codStutture
        Out.codCamereAria = codCamereAria
        Out.codTestate = codTestate
        Out.codMaterTestate = codMaterTestate
        Out.codmaterTappi = codmaterTappi
        Out.codRatingFlange = codRatingFlange
        Out.codCollaudi = codCollaudi
        Out.codPasserelle = codPasserelle
        Out.codIsolamentoMotore = codIsolamentoMotore
        Out.codTipoMotore = codTipoMotore
        Out.codRicircolo = codRicircolo
        Out.codPersiane = codPersiane
        Out.codSpecifiche = codSpecifiche
        Out.codMaterialeGuarnizioni = codMaterialeGuarnizioni
        Out.codMaterTubiSC = codMaterTubiSC
        Out.codVoltCicliFase = codVoltCicliFase
        Out.codRatingFlangeSC = codRatingFlangeSC
        Out.codScalePioli = codScalePioli
        Out.codScaleGradini = codScaleGradini
        Out.codInterrVibrazioni = codInterrVibrazioni
        Out.codmaterAlette = codmaterAlette
        Out.BWGtubiSC = BWGtubiSC
        Out.TipoBWGSC = TipoBWGSC
        Out.TipoAletteSC = TipoAletteSC
        Out.NAlettexPollice = NAlettexPollice
        Out.PressInSC = PressInSC
        Out.PressDesSC = PressDesSC
        Out.TempInSC = TempInSC
        Out.TempDesSC = TempDesSC
        Out.DiamInSC = DiamInSC
        Out.DiamOutSC = DiamOutSC
        Out.Corrosione = Corrosione
        Out.Banco2 = Banco2
        Out.Banco3 = Banco3
        Out.Banco4 = Banco4
        Out.codProprietaLiquido = codProprietaLiquido
        Out.codproprietaVapore = codproprietaVapore
        Out.NumRev = NumRev
        'Out.indNote(5) As Integer '        2   48   106     1    I,  00,   0   ,N. rec. note 1ø alternativa
        Out.DatiManuali = DatiManuali
        Out.SteamCoil = SteamCoil
        Out.ChiaveDatiItem = ChiaveDatiItem
        Out.NumTotCalcReg = NumTotCalcReg
        'Out.indRecDati(5) As Integer '     2   57   119     1    I,  00,   0   ,N. 1ø rec. dati
        For i = 1 To 5
            Out.ChiaveVali(i) = ChiaveVali(i)
        Next 'Out.indRecDati2 As Integer '     2   59   121     1    I,  00,   0   ,N. 2ø rec. dati
        Out.VENT = VENT
        Out.DRAIN = DRAIN
        Out.THERMOWELL = THERMOWELL
        Out.PRESSGAUGES = PRESSGAUGES
        Out.Automatico = Automatico
        Out.Nrepliche = Nrepliche
        Out.DutyRDIT = DutyRDIT
        Out.TempIn = TempIn
        Out.TempOut = TempOut
        Out.LiqHCIn = LiqHCIn
        Out.VapHCIn = VapHCIn
        Out.NonCondIn = NonCondIn
        Out.SteamIn = SteamIn
        Out.WaterIn = WaterIn
        Out.PressIn = PressIn
        Out.dpAllowable = dpAllowable
        Out.TempAirIn = TempAirIn
        Out.Fouling = Fouling
        Out.MWNonCond = MWNonCond
        Out.MWVapIn = MWVapIn
        Out.MWVapOut = MWVapOut
        Out.vLiq1 = vLiq1
        Out.T_vLiq1 = T_vLiq1
        Out.vLiq2 = vLiq2
        Out.T_vLiq2 = T_vLiq2
        Out.kLiq1 = kLiq1
        Out.T_kLiq1 = T_kLiq1
        Out.kLiq2 = kLiq2
        Out.T_kLiq2 = T_kLiq2
        Out.Grav1 = Grav1
        Out.T_Grav1 = T_Grav1
        Out.Grav2 = Grav2
        Out.T_Grav2 = T_Grav2
        Out.SpLiq1 = SpLiq1
        Out.T_SpLiq1 = T_SpLiq1
        Out.SpLiq2 = SpLiq2
        Out.T_SpLiq2 = T_SpLiq2
        Out.SpNonCond1 = SpNonCond1
        Out.T_SpNonCond1 = T_SpNonCond1
        Out.SpNonCond2 = SpNonCond2
        Out.T_SpNonCond2 = T_SpNonCond2
        Out.vVap1 = vVap1
        Out.T_vVap1 = T_vVap1
        Out.vVap2 = vVap2
        Out.T_vVap2 = T_vVap2
        Out.kVap1 = kVap1
        Out.T_kVap1 = T_kVap1
        Out.kVap2 = kVap2
        Out.T_kVap2 = T_kVap2
        Out.SpVap1 = SpVap1
        Out.T_SpVap1 = T_SpVap1
        Out.SpVap2 = SpVap2
        Out.T_SpVap2 = T_SpVap2
        Out.ComprFactor1 = ComprFactor1
        Out.T_ComprFactor1 = T_ComprFactor1
        Out.ComprFactor2 = ComprFactor2
        Out.T_ComprFactor2 = T_ComprFactor2
        Out.DesignPressure = DesignPressure
        Out.TestPressure = TestPressure
        Out.Provvisorio3 = Provvisorio3
        Out.CaloreLatente = CaloreLatente
        Out.Provvisorio4 = Provvisorio4
        Out.TempMinAria = TempMinAria
        Out.Provvisorio1 = Provvisorio1
        Out.Provvisorio2 = Provvisorio2
        Out.CondenHC = CondenHC
        Out.CondSteam = CondSteam
        Out.Elevaz = Elevaz
        Out.vLiq3 = vLiq3
        Out.T_vLiq3 = T_vLiq3
        For i = 1 To Alterns.Count
            CType(Alterns(i), clsAltern).Copia(Out.Alterns(i))
        Next
    End Sub
End Class
