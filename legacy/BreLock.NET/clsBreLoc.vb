Option Strict Off
Option Explicit On
Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary 'Namespace for BinaryFormatter
Imports System.math
<Serializable()> Public Class clsBreLoc
    Public Guarn As LibMat.clsGuarn
    Public Guarn2 As LibMat.clsGuarn
    Public Tir0, Tir1, Tir2 As LibMat.clsTira
    Public Sciolto As Boolean
    Public ClientPlant As String
    Public Author As String
    Public Commessa As String
    Public Item As String
    Public Gasket As String
    Public GskChan As String
    Public TipoBL As TipiBL
    Public Ipres As Short
    Public iPasso As Short
    Public NumScr As Short
    Public NExtScr As Short
    Public NumScr2 As Integer
    Public NmaxFiletti As Short
    Public TipoCassonetto As TipiCassonetto
    '---------------------dati di progetto
    Public DesTempSS As Single
    Public DesTempTS As Single
    Public DesPresSS As Single
    Public DesPresTS As Single
    Public DiffPres As Single 'pressione differenziale
    Public EffDiff As Single 'pressione differenziale dal lato mantello
    Public DiffPresHT As Single 'pressione differenziale di prova idraulica
    Public P2idr As Single 'pressione di prova idraulica lato tubi
    Public Corr As Single
    Public CorrSh As Single
    Public CorrTSCh As Single
    Public CorrTSSh As Single
    Public CorrCono As Single
    Public CorrCh As Single
    '----------------------dimensioni
    Public ThkAdpSh As Single
    Public ThkAdpTransition As Single
    Public HemRadius As Single
    Public IDShell As Single
    Public ThkAdpHe As Single
    Public G1out As Single
    Public G1N As Single
    Public G1AnExt As Single
    Public G1AnInt As Single
    Public G1dente As Single
    Public G2out As Single
    Public offG2out As Single
    Public G2N As Single
    Public G2AnExt As Single
    Public G2AnInt As Single
    Public G2dente As Single
    Public Nubbin As Single
    Public NubGskChan As Single
    Public TubeDout As Single
    Public Passo As Single
    Public Cava As Single 'della piastra tubiera
    Public ThkAdpTS As Single
    Public ThkAdpTSext As Single
    Public DNIntScr As Single
    Friend au_BCIntScr As Boolean
    Public BCIntScr As Single
    Public DNIntPushBar2 As Single
    Public DNBltScr2 As Single
    Public BCIntScr2 As Single
    Public IDChan As Single
    Friend au_IDChan As Boolean
    Public DiamIntGola As Single
    Friend au_DiamIntGola As Boolean
    Public ODChanFilettato As Single
    Public ODChanNonFilettato As Single
    Public IDbox As Single
    Public ODbox As Single
    Public Lbox As Single
    Public IDSplitRing As Single
    Friend au_IDSplitRing As Boolean
    Public ODSplitRing As Single
    Friend au_IDInnerRing As Boolean
    Public IDInnerRing As Single
    Friend au_ODInnerRing As Boolean
    Public ODInnerRing As Single
    Public MDCompRing As Single
    Public ThkCasson As Single
    Public AltCasson As Single
    Public MaxDCasson As Single
    Public MinDCasson As Single
    Public au_MaxDCasson As Boolean
    Public au_MinDCasson As Boolean
    Public DiamApCono As Single
    Public MDLocCono As Single
    Public AreaCono As Single
    Public NoApCono As Single
    Public DIAnelCono As Single
    Public DOAnelCono As Single
    Public ThkAdpFC As Single
    Friend au_ThkAdpFC As Boolean
    Public ThkAdpCh As Single
    Public BCExtScr As Single
    Public OffBCextScr As Single
    Public AreExtScr As Single
    Public DPushBars As Single
    Public DNExtScr As Single
    Public IDExtComprRing As Single
    Public ODExtComprRing As Single
    Public DNLockR As Single
    Public IDLockR As Single
    Public ODCover As Single
    Friend au_ThkAdpLR As Boolean
    Public ThkAdpLR As Single
    Public ThrEndAdpLength As Single
    Public ThrAdpMinThk As Single
    Public ExtCrwAdpThk As Single
    Public ThkAdpCv As Single
    Public OptFiletto As Integer
    Public SpessDiaf As Single
    Public AreExtension As Single 'sezione dell'estensione viti interne
    Public Filetto As Filettatura
    Public CavaSplitRing As Single
    Public Norme As LibMat.Codes
    Public UniMis As Short
    '---------------------
    Public Formula As Short
    Public FormulaS As String
    Public CodReturn As Short
    Public NreqFiletti As Short
    Public iStampa As Short
    Public Formula2 As Short
    Public Formula2S As Short 'obsoleto
    Public Formula2Sp As String
    Public ThkMinSh As Single
    Public ThkMinHe As Single
    Public G1eff As Single
    Public G2eff As Single
    Public m As Single
    Public Y As Single
    Public ThkMinTS As Single
    Public AreBltScr As Single
    Public ODChanRequired As Single
    Friend SChanLongMemb As Single
    Friend SChanLongBend As Single
    Friend SChanLongMembSeating As Single
    Friend SChanLongBendSeating As Single
    Friend SChanLongMembAccident As Single
    Friend SChanLongBendAccident As Single
    Friend ThrEndPm, ThrEndPmb As Single
    Friend deltaRChanNormal As Single
    Friend deltaRChanAccident As Single
    Friend GskODbox As Single 'obsoleto
    Friend GskIDbox As Single 'obsoleto
    Friend GskThkbox As Single 'obsoleto
    Friend GskYbox As Single 'obsoleto
    Friend ThkReqSRdesign As Single
    Friend ThkReqSRseating As Single
    Friend ThkReqSRtest As Single
    Friend ThkReqSplitRing As Single
    Friend au_ThkAdpSplitRing As Boolean
    Public ThkAdpSplitRing As Single
    Friend S1shearSR As Single
    Friend S2shearSR As Single
    Friend SoshearSR As Single
    Friend S1bearSR As Single
    Friend S2bearSR As Single
    Friend SobearSR As Single
    Friend ThkReqIRdesign As Single
    Friend ThkReqIRseating As Single
    Friend ThkReqIRtest As Single
    Friend ThkReqInnerRing As Single
    Friend au_ThkAdpInnerRing As Boolean
    Public ThkAdpInnerRing As Single
    Friend RotDes As Single
    Friend RotBolt As Single
    Friend RotTest As Single
    Friend S1bearIR As Single
    Friend S2bearIR As Single
    Friend SobearIR As Single
    Friend ComprCdesign As Single
    Friend ComprCseating As Single
    Friend ComprCtest As Single
    Friend EulerCtemp As Single
    Friend EulerCroom As Single
    Friend mGskChan As Single
    Friend YGskChan As Single
    Friend Sbearingdesign As Single
    Friend Sbearingseating As Single
    Friend Sbearingtest As Single
    Friend ThkMinFCdesign As Single
    Friend ThkMinFCseating As Single
    Friend ThkMinFCtest As Single
    Friend ThkMinFC As Single
    Friend RadiusCh As Single
    Friend ThkMinCh As Single
    Friend B2max As Single
    Friend ThkMinLRoperating As Single
    Friend ThkMinLRroom As Single
    Friend ThkMinLR As Single
    Friend BearStressLR As Single
    Friend ThrShearDesign, ThrShearAccident, ThrShearSeating As Single
    Friend ThrBendingDesign, ThrBendingAccident, ThrBendingSeating As Single
    Friend ThrBearingDesign, ThrBearingAccident, ThrBearingSeating As Single
    Friend ThrEndReqThkDesign, ThrEndReqThkAccident, ThrEndReqThkSeating As Single
    Friend ThrEndReqLength As Single
    Friend ThrEndLongStress As Single
    Friend ThrEndLongStressSeating As Single
    Friend ThrEndLongStressAccident As Single
    Friend ThrEndMinThk As Single
    Friend ExtCrwMinThk As Single
    Friend ExtCrwShear As Single
    Friend ExtCrwMembrane As Single
    Friend ExtCrwSideal As Single
    Friend ExtCrwBearing As Single
    Public ClasGuarn1 As Short
    Public TipoGuarn1 As Short
    Public ClasGuarn2 As Short
    Public TipoGuarn2 As Short
    Public Face1 As Short
    Public Face2 As Short
    Public B1 As Single
    Public B2 As Single
    Public Wdesign As Single
    Public Wseating As Single
    Public Wtest As Single
    Public WplasticBox As Single
    Public Fascia As Single
    Public VerificaCono As Integer
    Public VerificaRotaz As Integer
    Public VerificaBearing As Integer
    Public NmaxFilettiPoss As Integer
    Public AreBltScr2 As Single
    Public AreqScr2 As Single
    Public TotAreaScr2 As Single
    Public TotAreaPushBar2 As Single
    Public AreaAdpScrews As Single
    Public AreaAdpPushBars As Single
    Public AreaReqScrPushDesign As Single
    Public AreaReqScrPushRoom As Single
    Public AreaReqScrPush As Single
    Public WdesignCh As Single
    Public WtestCh As Single
    Public WseatingCh As Single
    Public WdesignThr As Single
    Public WtestThr As Single
    Public WseatingThr As Single
    Public WaccidentThr As Single
    Public WdesignPl As Single
    Public ThkMinCv As Single
    Public EngagedDesign, EngagedAccident As Single
    Public TempTransCh As Single
    Public TempTransLR As Single
    Public DeltaT As Single
    Public CalcDeltaT As Integer
    Public SpostDiaf1 As Single
    Public SpostDiaf2 As Single
    Public Wadd1 As Single
    Public Wadd2 As Single
    Public Considera As Integer
    Public xFil1 As Short
    Public xFil2 As Short
    Public xFil3 As Short
    Public padd1 As Short
    Public DNStr1 As String
    Public DNStr2 As String
    Public DNStr3 As String
    Friend BSmin1 As Single
    Friend BSmin2 As Single
    Friend BSmin3 As Single
    Public Mater(16) As MaterialF
    Friend LarghFlex1 As Single
    Friend LarghFlex2 As Single
    Friend Sbd1 As Single
    Friend Sbd2 As Single
    Friend AReqScrTest, AReqScrTestExtension, AreqScrDesign, _
           AreqScrSeating, AreqScr, AactScr As Single
    Friend BucklCassondesign, BucklCassonseating, BucklCassontest As Single 'obsoleto
    Public SuperSafe, NonCalcolaFondo As Boolean
    Friend AmmissAccident As Single
    Friend ExtraDistBCIntExt As Single
    Public ReadOnly Property LunghezzaFiletti() As Single
        Get
            Return CInt(Filetto.Passo * NmaxFiletti + 0.49)
        End Get
    End Property

    Public ReadOnly Property ThkExtComprRing() As Single
        Get
            Return (Me.ODExtComprRing - Me.IDExtComprRing) / 2
        End Get
    End Property
    Public ReadOnly Property IDIntComprRing() As Single
        Get
            Return Me.MDCompRing - Me.ThkIntComprRing
        End Get
    End Property
    Public ReadOnly Property ODIntComprRing() As Single
        Get
            Return Me.MDCompRing + Me.ThkIntComprRing
        End Get
    End Property
    Public ReadOnly Property ThkIntComprRing() As Single
        Get
            Return Me.DNBltScr2 + 10
        End Get
    End Property
    Public ReadOnly Property LarghezzaSR() As Single
        Get
            Return (Me.ODSplitRing - Me.IDSplitRing) / 2
        End Get
    End Property
    Public Function ImpilaggioFinale() As Single
        Dim Somma As Single = ImpilaggioPianoGsk()
        Somma += 3
        Somma += lbSpessMaxDiaf
        Somma += Me.lbAltezzaSpallaSottoCava
        Somma += Me.lbAltzCavaThreadedEnd
        Somma += Me.LunghezzaFiletti
        Return Somma
    End Function
    Public Sub Rapporto()
        stampa(True)
    End Sub
    Public Function ImpilaggioPianoGsk() As Single
        Dim Somma As Single = ImpilaggioSottoSR()
        Somma += Me.ThkAdpSplitRing
        Dim Altezza1 As Single = Me.lbSopralzoTestaVitiInterne + _
                                 CInt(Me.DNIntScr + 0.49) + _
                                 Me.lbAria_TestaViti_Diaframma - _
                                 (Me.lbSpessMaxDiaf - Me.lbSpessMinDiaf) - _
                                  3 'spessore guarnizione
        'con ciò si arriva al piano di appoggio della guarnizione
        Somma += Max(Altezza1, Me.ThkAdpSplitRing)
        Return Somma
    End Function
    Public Function ImpilaggioSottoSR() As Single
        Dim Somma As Single = ImpilaggioSopraFC()
        Somma += Me.lbAria_FlangiaCAssonetto_AnelloInterno
        Somma += Me.ThkAdpInnerRing - Me.lbSpessGradinoAnelloInterno
        Return Somma
    End Function
    Public Function ImpilaggioSopraFC() As Single
        Dim Somma As Single = 3 ' Guarn.Spessore
        Somma += Max(Me.lbSpessoreEstensionePiastra, Me.ThkAdpTSext)
        Somma += Me.AltCasson
        Somma += Me.ThkAdpFC
        Return Somma
    End Function
    Public Function EseguiDaASME() As clsBreLoc
        DaASME = True
        'Azzera()
        FormApert = New frmApert
        FormApert.CheckAutomatismi()
        FormApert.ShowDialog()
        Return objBre
    End Function
    Public Sub EseguiSciolto()
        Try
            Sciolto = True
            DaASME = False
            FormApert = New frmApert
            FormApert.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message + vbCrLf + ex.StackTrace)
        End Try
    End Sub
    Public WriteOnly Property DoveMotore() As RoutBase1.clsMotore
        Set(ByVal Value As RoutBase1.clsMotore)
            If Monitor Is Nothing Then
                Monitor = New clsMonitor
                objBre = Me
                myAssembly = Me.GetType.Assembly
                rmHelpStrings = New _
                  System.Resources.ResourceManager("BreLock.ProjectResources", myAssembly)
                rmHelpTopics = New _
                  System.Resources.ResourceManager("BreLock.HelpTopics", myAssembly)
                GlobalRoutines = New RoutBase1.clsTrigon
            End If
            Monitor.Motore = Value
            Monitor.Motore.InitProb("BREL")
            RadiceHelp = Value.Inizio.AppLancio & rmHelpStrings.GetString("Helpfile") '"\Bin\AiutoBre.chm"
            Radix = Value.Inizio.AppLancio & "\Bin\Lancio.chm"
        End Set
    End Property
    Public WriteOnly Property DoveRoutines() As RoutBase1.Routines
        Set(ByVal Value As RoutBase1.Routines)
            Monitor.Routines = Value
        End Set
    End Property
    Public Sub New()
        MyBase.New()
        Monitor = New clsMonitor
        objBre = Me
        Inizializza()
        myAssembly = Me.GetType.Assembly
        rmHelpStrings = New _
          System.Resources.ResourceManager("BreLock.ProjectResources", myAssembly)
        rmHelpTopics = New _
          System.Resources.ResourceManager("BreLock.HelpTopics", myAssembly)
        GlobalRoutines = New RoutBase1.clsTrigon
        '        Guarn = New LibMat.clsGuarn
        '        Guarn2 = New LibMat.clsGuarn
        '        Tir0 = New LibMat.clsTira
        '        Tir1 = New LibMat.clsTira
        '        Tir2 = New LibMat.clsTira
    End Sub
    Public Sub Salva(ByVal fs As FileStream)
        Dim bf As New BinaryFormatter
        bf.Serialize(fs, Me)
    End Sub
    Public Function Leggi(ByVal fs As FileStream) As Boolean
        Dim bf As New BinaryFormatter
        Dim obj As clsBreLoc = CType(bf.Deserialize(fs), clsBreLoc)
        With obj
            Sciolto = .Sciolto
            ClientPlant = .ClientPlant
            Author = .Author
            Commessa = .Commessa
            Item = .Item
            Gasket = .Gasket
            GskChan = .GskChan
            TipoBL = .TipoBL
            Ipres = .Ipres
            iPasso = .iPasso
            NumScr = .NumScr
            NExtScr = .NExtScr
            NumScr2 = .NumScr2
            NmaxFiletti = .NmaxFiletti
            DesTempSS = .DesTempSS
            DesTempTS = .DesTempTS
            DesPresSS = .DesPresSS
            DesPresTS = .DesPresTS
            DiffPres = .DiffPres
            EffDiff = .EffDiff
            DiffPresHT = .DiffPresHT
            P2idr = .P2idr
            Corr = .Corr
            CorrSh = .CorrSh
            CorrTSCh = .CorrTSCh
            CorrTSSh = .CorrTSSh
            CorrCono = .CorrCono
            CorrCh = .CorrCh
            ThkAdpSh = .ThkAdpSh
            HemRadius = .HemRadius
            IDShell = .IDShell
            ThkAdpHe = .ThkAdpHe
            G1out = .G1out
            G1N = .G1N
            G1AnExt = .G1AnExt
            G1AnInt = .G1AnInt
            G1dente = .G1dente
            G2out = .G2out
            G2N = .G2N
            G2AnExt = .G2AnExt
            G2AnInt = .G2AnInt
            G2dente = .G2dente
            Nubbin = .Nubbin
            NubGskChan = .NubGskChan
            TubeDout = .TubeDout
            Passo = .Passo
            Cava = .Cava
            ThkAdpTS = .ThkAdpTS
            DNIntScr = .DNIntScr
            BCIntScr = .BCIntScr
            DNIntPushBar2 = .DNIntPushBar2
            DNBltScr2 = .DNBltScr2
            BCIntScr2 = .BCIntScr2
            IDChan = .IDChan
            DiamIntGola = .DiamIntGola
            ODChanFilettato = .ODChanFilettato
            ODChanNonFilettato = .ODChanNonFilettato
            IDbox = .IDbox
            ODbox = .ODbox
            Lbox = .Lbox
            IDSplitRing = .IDSplitRing
            ODSplitRing = .ODSplitRing
            IDInnerRing = .IDInnerRing
            ODInnerRing = .ODInnerRing
            MDCompRing = .MDCompRing
            ThkCasson = .ThkCasson
            AltCasson = .AltCasson
            MaxDCasson = .MaxDCasson
            MinDCasson = .MinDCasson
            DiamApCono = .DiamApCono
            MDLocCono = .MDLocCono
            AreaCono = .AreaCono
            NoApCono = .NoApCono
            DIAnelCono = .DIAnelCono
            DOAnelCono = .DOAnelCono
            ThkAdpFC = .ThkAdpFC
            ThkAdpCh = .ThkAdpCh
            BCExtScr = .BCExtScr
            AreExtScr = .AreExtScr
            DPushBars = .DPushBars
            DNExtScr = .DNExtScr
            IDExtComprRing = .IDExtComprRing
            ODExtComprRing = .ODExtComprRing
            DNLockR = .DNLockR
            IDLockR = .IDLockR
            ODCover = .ODCover
            ThkAdpLR = .ThkAdpLR
            ThrEndAdpLength = .ThrEndAdpLength
            ThrAdpMinThk = .ThrAdpMinThk
            ExtCrwAdpThk = .ExtCrwAdpThk
            ThkAdpCv = .ThkAdpCv
            OptFiletto = .OptFiletto
            SpessDiaf = .SpessDiaf
            AreExtension = .AreExtension
            Filetto = .Filetto
            CavaSplitRing = .CavaSplitRing
            Norme = .Norme
            UniMis = .UniMis
            Formula = .Formula
            FormulaS = .FormulaS
            CodReturn = .CodReturn
            NreqFiletti = .NreqFiletti
            iStampa = .iStampa
            Formula2 = .Formula2
            Formula2S = .Formula2S
            Formula2Sp = .Formula2Sp
            ThkMinSh = .ThkMinSh
            ThkMinHe = .ThkMinHe
            G1eff = .G1eff
            G2eff = .G2eff
            m = .m
            Y = .Y
            ThkMinTS = .ThkMinTS
            AreBltScr = .AreBltScr
            ODChanRequired = .ODChanRequired
            SChanLongMemb = .SChanLongMemb
            SChanLongBend = .SChanLongBend
            SChanLongMembSeating = .SChanLongMembSeating
            SChanLongBendSeating = .SChanLongBendSeating
            SChanLongMembAccident = .SChanLongMembAccident
            SChanLongBendAccident = .SChanLongBendAccident
            ThrEndPm = .ThrEndPm
            ThrEndPmb = .ThrEndPmb
            deltaRChanNormal = .deltaRChanNormal
            deltaRChanAccident = .deltaRChanAccident
            GskODbox = .GskODbox
            GskIDbox = .GskIDbox
            GskThkbox = .GskThkbox
            GskYbox = .GskYbox
            ThkReqSRdesign = .ThkReqSRdesign
            ThkReqSRseating = .ThkReqSRseating
            ThkReqSRtest = .ThkReqSRtest
            ThkReqSplitRing = .ThkReqSplitRing
            ThkAdpSplitRing = .ThkAdpSplitRing
            S1shearSR = .S1shearSR
            S2shearSR = .S2shearSR
            SoshearSR = .SoshearSR
            S1bearSR = .S1bearSR
            S2bearSR = .S2bearSR
            SobearSR = .SobearSR
            ThkReqIRdesign = .ThkReqIRdesign
            ThkReqIRseating = .ThkReqIRseating
            ThkReqIRtest = .ThkReqIRtest
            ThkReqInnerRing = .ThkReqInnerRing
            ThkAdpInnerRing = .ThkAdpInnerRing
            RotDes = .RotDes
            RotBolt = .RotBolt
            RotTest = .RotTest
            S1bearIR = .S1bearIR
            S2bearIR = .S2bearIR
            SobearIR = .SobearIR
            ComprCdesign = .ComprCdesign
            ComprCseating = .ComprCseating
            ComprCtest = .ComprCtest
            EulerCtemp = .EulerCtemp
            EulerCroom = .EulerCroom
            mGskChan = .mGskChan
            YGskChan = .YGskChan
            Sbearingdesign = .Sbearingdesign
            Sbearingseating = .Sbearingseating
            Sbearingtest = .Sbearingtest
            ThkMinFCdesign = .ThkMinFCdesign
            ThkMinFCseating = .ThkMinFCseating
            ThkMinFCtest = .ThkMinFCtest
            ThkMinFC = .ThkMinFC
            RadiusCh = .RadiusCh
            ThkMinCh = .ThkMinCh
            B2max = .B2max
            ThkMinLRoperating = .ThkMinLRoperating
            ThkMinLRroom = .ThkMinLRroom
            ThkMinLR = .ThkMinLR
            BearStressLR = .BearStressLR
            ThrShearDesign = .ThrShearDesign
            ThrShearAccident = .ThrShearAccident
            ThrShearSeating = .ThrShearSeating
            ThrBendingDesign = .ThrBendingDesign
            ThrBendingAccident = .ThrBendingAccident
            ThrBendingSeating = .ThrBendingSeating
            ThrBearingDesign = .ThrBearingDesign
            ThrBearingAccident = .ThrBearingAccident
            ThrBearingSeating = .ThrBearingSeating
            ThrEndReqThkDesign = .ThrEndReqThkDesign
            ThrEndReqThkAccident = .ThrEndReqThkAccident
            ThrEndReqThkSeating = .ThrEndReqThkSeating
            ThrEndReqLength = .ThrEndReqLength
            ThrEndLongStress = .ThrEndLongStress
            ThrEndLongStressSeating = .ThrEndLongStressSeating
            ThrEndLongStressAccident = .ThrEndLongStressAccident
            ThrEndMinThk = .ThrEndMinThk
            ExtCrwMinThk = .ExtCrwMinThk
            ExtCrwShear = .ExtCrwShear
            ExtCrwMembrane = .ExtCrwMembrane
            ExtCrwSideal = .ExtCrwSideal
            ExtCrwBearing = .ExtCrwBearing
            ClasGuarn1 = .ClasGuarn1
            TipoGuarn1 = .TipoGuarn1
            ClasGuarn2 = .ClasGuarn2
            TipoGuarn2 = .TipoGuarn2
            Face1 = .Face1
            Face2 = .Face2
            B1 = .B1
            B2 = .B2
            Wdesign = .Wdesign
            Wseating = .Wseating
            Wtest = .Wtest
            WplasticBox = .WplasticBox
            Fascia = .Fascia
            VerificaCono = .VerificaCono
            VerificaRotaz = .VerificaRotaz
            VerificaBearing = .VerificaBearing
            NmaxFilettiPoss = .NmaxFilettiPoss
            AreBltScr2 = .AreBltScr2
            AreqScr2 = .AreqScr2
            TotAreaScr2 = .TotAreaScr2
            TotAreaPushBar2 = .TotAreaPushBar2
            AreaAdpScrews = .AreaAdpScrews
            AreaAdpPushBars = .AreaAdpPushBars
            AreaReqScrPushDesign = .AreaReqScrPushDesign
            AreaReqScrPushRoom = .AreaReqScrPushRoom
            AreaReqScrPush = .AreaReqScrPush
            WdesignCh = .WdesignCh
            WtestCh = .WtestCh
            WseatingCh = .WseatingCh
            WdesignThr = .WdesignThr
            WtestThr = .WtestThr
            WseatingThr = .WseatingThr
            WaccidentThr = .WaccidentThr
            WdesignPl = .WdesignPl
            ThkMinCv = .ThkMinCv
            EngagedDesign = .EngagedDesign
            EngagedAccident = .EngagedAccident
            TempTransCh = .TempTransCh
            TempTransLR = .TempTransLR
            DeltaT = .DeltaT
            CalcDeltaT = .CalcDeltaT
            SpostDiaf1 = .SpostDiaf1
            SpostDiaf2 = .SpostDiaf2
            Wadd1 = .Wadd1
            Wadd2 = .Wadd2
            Considera = .Considera
            xFil1 = .xFil1
            xFil2 = .xFil2
            xFil3 = .xFil3
            padd1 = .padd1
            DNStr1 = .DNStr1
            DNStr2 = .DNStr2
            DNStr3 = .DNStr3
            BSmin1 = .BSmin1
            BSmin2 = .BSmin2
            BSmin3 = .BSmin3
            Dim i As Integer
            For i = 1 To 16
                Mater(i) = .Mater(i)
            Next
            LarghFlex1 = .LarghFlex1
            LarghFlex2 = .LarghFlex2
            Sbd1 = .Sbd1
            Sbd2 = .Sbd2
            AReqScrTest = .AReqScrTest
            AReqScrTestExtension = .AReqScrTestExtension
            AreqScrDesign = .AreqScrDesign
            AreqScrSeating = .AreqScrSeating
            AreqScr = .AreqScr
            AactScr = .AactScr
            BucklCassondesign = .BucklCassondesign
            BucklCassonseating = .BucklCassonseating
            BucklCassontest = .BucklCassontest
            SuperSafe = .SuperSafe
            NonCalcolaFondo = .NonCalcolaFondo
            AmmissAccident = .AmmissAccident
            ExtraDistBCIntExt = .ExtraDistBCIntExt
        End With
        Return True
    End Function
    Public Sub Dispose()
        If Not Monitor Is Nothing Then Monitor.Motore = Nothing
        Monitor = Nothing
        objBre = Nothing
    End Sub
    Public Sub Inizializza()
        Dim i As Short
        For i = 0 To NumCalc
            Calcolato(i) = False
        Next
        TipoBL = 1
        iPasso = 1
        iStampa = 1
        Filetto = New Filettatura
        Filetto.Precision = 7
        For i = 1 To 16
            Mater(i) = New MaterialF
        Next
        Norme = LibMat.Codes.div1MPa
        Guarn = New LibMat.clsGuarn
        Guarn2 = New LibMat.clsGuarn
        Tir0 = New LibMat.clsTira
        Tir1 = New LibMat.clsTira
        Tir2 = New LibMat.clsTira
    End Sub
    Public ReadOnly Property AltezzaAnelliSuperiori() As Single
        Get
            Return Me.lbAltezzaSpallaSottoCava + Me.lbAltzCavaThreadedEnd - 2 * Me.lbRadialGap
        End Get
    End Property
    Public Property lbThkCompRing() As Single
        Get
            Return Getlb("ThkCompRing", IDShell)
        End Get
        Set(ByVal value As Single)

        End Set
    End Property
    Public Property lbRadialGap() As Single
        Get
            Return Getlb("RadialGap", IDShell)
        End Get
        Set(ByVal value As Single)

        End Set
    End Property
    Public Property lbSpessDenteInternoGskChan() As Single
        Get
            Return Getlb("SpessDenteInternoGskChan", IDShell)
        End Get
        Set(ByVal value As Single)

        End Set
    End Property
    Public Property lbSpessGradinoAnelloInterno() As Single
        Get
            Return Getlb("SpessGradinoAnelloInterno", IDShell)
        End Get
        Set(ByVal value As Single)

        End Set
    End Property
    Public Property lbSpessDenteInternoGskShel() As Single
        Get
            Return Getlb("SpessDenteInternoGskShel", IDShell)
        End Get
        Set(ByVal value As Single)

        End Set
    End Property
    Public Property lbNGskChan() As Single
        Get
            Return Getlb("G2N", IDShell)
        End Get
        Set(ByVal value As Single)

        End Set
    End Property
    Public Property lbNGskPT() As Single
        Get
            Return Getlb("NGskPT", IDShell)
        End Get
        Set(ByVal value As Single)

        End Set
    End Property
    Public Property lbSporgenzaSplitRing() As Single
        Get
            Return Getlb("SporgenzaSplitRing", IDShell)
        End Get
        Set(ByVal value As Single)

        End Set
    End Property
    Public Property lbThkSplitRing() As Single
        Get
            Return Getlb("ThkSplitRing", IDShell)
        End Get
        Set(ByVal value As Single)

        End Set
    End Property
    Public Property lbLunghNasello() As Single
        Get
            Return Getlb("LunghNasello", IDShell)
        End Get
        Set(ByVal value As Single)

        End Set
    End Property
    Public Property lbSpazioIntScrCompRing() As Single
        Get
            Return Getlb("SpazioIntScrCompRing", IDShell)
        End Get
        Set(ByVal value As Single)

        End Set
    End Property
    Public Property lbSporgenzaAnelCono() As Single
        Get
            Return Getlb("SporgenzaAnelCono", IDShell)
        End Get
        Set(ByVal value As Single)

        End Set
    End Property
    Public Property lbThkCasson() As Single
        Get
            Return Getlb("ThkCasson", IDShell)
        End Get
        Set(ByVal value As Single)

        End Set
    End Property
    Public Property lbThkMinFlangiaCasson() As Single
        Get
            Return Getlb("ThkMinFlangiaCasson", IDShell)
        End Get
        Set(ByVal value As Single)

        End Set
    End Property
    Public Property lbCarneRadialeEsternoIR() As Single
        Get
            Return Getlb("CarneRadialeEsternoIR", IDShell)
        End Get
        Set(ByVal value As Single)

        End Set
    End Property
    Public Property lbProfCavaThreadedEnd() As Single
        Get
            Return Getlb("ProfCavaThreadedEnd", IDShell)
        End Get
        Set(ByVal value As Single)

        End Set
    End Property
    Public Property lbAria_FlangiaCAssonetto_AnelloInterno() As Single
        Get
            Return Getlb("Aria_FlangiaCAssonetto_AnelloInterno", IDShell)
        End Get
        Set(ByVal value As Single)

        End Set
    End Property
    Public Property lbRadialGap_ExtComprRing_Thread() As Single
        Get
            Return Getlb("RadialGap_ExtComprRing_Thread", IDShell)
        End Get
        Set(ByVal value As Single)

        End Set
    End Property
    Public Property lbAria_TestaViti_Diaframma() As Single
        Get
            Return Getlb("Aria_TestaViti_Diaframma", IDShell)
        End Get
        Set(ByVal value As Single)

        End Set
    End Property
    Public Property lbAltezzaSpallaSottoCava() As Single
        Get
            Return Getlb("AltezzaSpallaSottoCava", IDShell)
        End Get
        Set(ByVal value As Single)

        End Set
    End Property
    Public Property lbIstmoIRconSR() As Single
        Get
            Return Getlb("IstmoIRconSR", IDShell)
        End Get
        Set(ByVal value As Single)

        End Set
    End Property
    Public Property lbAltzCavaThreadedEnd() As Single
        Get
            Return Getlb("AltzCavaThreadedEnd", IDShell)
        End Get
        Set(ByVal value As Single)

        End Set
    End Property
    Public Property lbSpessoreEstensionePiastra() As Single
        Get
            Return Getlb("SpessoreEstensionePiastra", IDShell)
        End Get
        Set(ByVal value As Single)

        End Set
    End Property
    Public Property lbIstmoMinimoIntExt() As Single
        Get
            Return Getlb("IstmoMinimoIntExt", IDShell)
        End Get
        Set(ByVal value As Single)

        End Set
    End Property
    Public Property lbSopralzoTestaVitiInterne() As Single
        Get
            Return Getlb("SopralzoTestaVitiInterne", IDShell)
        End Get
        Set(ByVal value As Single)

        End Set
    End Property
    Public Property lbSpessMaxDiaf() As Single
        Get
            Return Getlb("SpessMaxDiaf", IDShell)
        End Get
        Set(ByVal value As Single)

        End Set
    End Property
    Public Property lbSpessMinDiaf() As Single
        Get
            Return Getlb("SpessMinDiaf", IDShell)
        End Get
        Set(ByVal value As Single)

        End Set
    End Property
End Class