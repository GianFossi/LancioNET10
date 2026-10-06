Option Strict Off
Option Explicit On
Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Runtime.InteropServices
Friend Class wn_Diaf
    <Serializable(), StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> Private Structure typProblemDF
        Dim p As Single
        Dim pHydr As Single
        Dim g As Single
        Dim b As Single
        Dim t As Single
        Dim sac As Single
        Dim nb As Short
        Dim sab As Single
        Dim saco As Single
        Dim db As Single
        Dim sabo As Single
        Dim sad As Single
        Dim sado As Single
        Dim ad As Single
        Dim ab As Single
        Dim H As Single
        Dim saw As Single
        Dim sawo As Single
        Dim hi As Single
        Dim sd As Single
        Dim sb As Single
        Dim sbo As Single
        Dim SP As Single
        Dim c As Single 'stress termico
        Dim St As Single
        Dim SO As Single
        Dim sydi As Single
        Dim sydo As Single
        Dim hti As Single
        Dim ht As Single
        Dim id As Single
        Dim isi As Single
        Dim di As Single
        Dim T2 As Single 'spessore in periferia
        Dim T1 As Single 'spessore al centro
        Dim a As Single 'dimensione saldatura
        Dim BC As Single
        Dim tc1 As Single
        Dim tc2 As Single
        Dim ed As Single
        Dim ES As Single
        Dim wts As Single
        Dim bcalc As Single
        <VBFixedString(40), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=40)> Public Cover As String
        <VBFixedString(40), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=40)> Public Flange As String
        <VBFixedString(40), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=40)> Public Bolt As String
        <VBFixedString(40), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=40)> Public Diaf As String
        <VBFixedString(40), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=40)> Public weld As String
        Dim indiceF As Short
        Dim indiceC As Short
        Dim IndiceB As Short
        Dim indiceD As Short
        Dim indiceW As Short
        Dim RecIndF As Short
        Dim RecIndC As Short
        Dim RecIndB As Short
        Dim RecIndD As Short
        Dim RecIndW As Short
        Dim wtsp As Single
        Dim sacy As Single
        Dim sacy0 As Single
        Dim sady As Single
        Dim sady0 As Single
        Dim safy As Single
        Dim safy0 As Single
        Dim sdo As Single
        Dim Corrosione As Single
        <VBFixedString(144), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=144)> Public Padding As String
    End Structure
    Public Coperchio, Flangia As wn_flan
    Private Const k As Double = 1.5
    Private Const f As Double = 0.6
    Private Const SIF As Short = 4
    Private Const nu As Double = 0.3
    Private Const eff As Double = 0.85
    Private Const ta As Integer = (20 * 9 / 5) + 32
    Public lKlato, lJinvolucr As Short
    Private Problem As typProblemDF
    Public Sub Calcolo()
        Dim msbi As String = ""
        Dim msb As String = ""
        Dim msd As String = ""
        Dim msw As String
        Dim bcalc As Single
        Try
            With Problem
                'calcolo diaframma
                .ad = pi * (.g - 2 * .b) * .b
                .ab = pi / 4 * .nb * .db ^ 2 'area bulloni
                '.H = pi / 4 * .g ^ 2 * .p 'W in esercizio
                If Not Config(0).CalcPI = 1 Then .hi = pi / 4 * .g ^ 2 * .pHydr 'W in prova idraulica
                .sd = .hi / .ad '(Abs(.hi - .H)) / .ad'pressione contatto guarnizione
                .sdo = .H / .ad '(Abs(.hi - .H)) / .ad'pressione contatto guarnizione
                .SP = System.Math.Abs(.p * (.T1 - .T2) / .a) 'tensione di pressione sulla saldatura
                .ht = f * eff * .saw 'ammissibile primario
                .c = System.Math.Abs(.ed * (.isi - .id)) * (.t - ta) 'stress da dilatazione impedita
                .St = (2 * .T2 * .b + (.g - 2 * .b) * .T1) / (1 - nu) * .c / .g / .a '(.T1 / .T2) * .c / (1 - nu)
                .hti = f * 3 * eff * .saw 'ammissibile secondario
                .wts = .SP + .St
                .wtsp = SIF * .wts / 2
                .bcalc = .hi / (.sydi * k) / (pi * (.g - 2 * .b)) * inc
                bcalc = .H / (.sydo * k) / (pi * (.g - 2 * .b)) * inc
                If bcalc > .bcalc Then .bcalc = bcalc
                'calcolo bulloni
                .sb = .H / .ab
                .sbo = .hi / .ab
                If .sb > .sab Or .sbo > .sabo Then
                    msb = "Bulloni troppo stressati"
                Else
                    msb = "Operating bolt stress =  " & LTrim(Mid(CStr(.sb), 1, 5)) & " psi"
                    msbi = "Tightening bolt stress = " & LTrim(Mid(CStr(.sbo), 1, 5)) & " psi"
                End If

                If .sd > .sydi * k Then
                    msd = "Superficie a contatto non idonea"
                Else
                    msd = LTrim(Mid(CStr(.sd), 1, 9)) & " < " & LTrim(Mid(CStr(.sydi * k), 1, 9)) & " psi"
                End If
                If .sdo > .sydo * k Then
                    msd = "Superficie a contatto non idonea"
                Else
                    msd = LTrim(Mid(CStr(.sdo), 1, 9)) & " < " & LTrim(Mid(CStr(.sydo * k), 1, 9)) & " psi"
                End If


                'calcolo saldatura

                If .SP > .ht Or .SP + .St > .hti Then
                    msw = "Saldatura stressata (" & Trim(GlobalRoutines.myStr(.SP + .St, 6, 0, False)) & " > " & GlobalRoutines.myStr(.hti, 6, 0, False) & ")"
                Else
                    msw = "Saldatura adeguata (" & Trim(GlobalRoutines.myStr(.SP + .St, 6, 0, False)) & " < " & GlobalRoutines.myStr(.hti, 6, 0, False) & ")"
                End If
            End With
            With frmMsgDiaf.DefInstance
                .Label1.Visible = True
                .Label1.Text = "Stress sul diaframma " & msd
                .Label1.ForeColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 0, 0))
                .Label2(0).Text = "Larghezza min. calcolata = " & LTrim(Mid(CStr(Problem.bcalc), 1, 5)) & " mm"
                .Label2(1).Text = "Con G. calcolato = " & LTrim(Mid(CStr(Problem.bcalc + ((Problem.g - Problem.b) * inc)), 1, 5)) & "mm"
                .Label2(2).Text = msb
                .Label2(3).Text = msbi
                .Label2(4).Text = msw
                .ShowDialog()
            End With
            frmMsgDiaf.DefInstance.Dispose()
        Catch e As Exception
            MessageBox.Show(frmMsgDiaf.DefInstance, e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Public Overloads Function Leggi(ByRef ifl As Short) As Boolean
        Leggi = True
        FileGet(ifl, Problem)
        LeggiMateriali()
    End Function
    Public Overloads Function Leggi(ByRef fs As FileStream) As Boolean
        Dim bf As New BinaryFormatter
        Leggi = True
        Problem = CType(bf.Deserialize(fs), typProblemDF)
        If Config(0).Versione > 23 Then
            Matdim(Problem.indiceD) = CType(bf.Deserialize(fs), LibMat.MaterialeNew1)
            Matdim(Problem.indiceW) = CType(bf.Deserialize(fs), LibMat.MaterialeNew1)
        Else
            Dim m1 As New LibMat.Materiale
            Dim m2 As New LibMat.Materiale
            m1 = CType(bf.Deserialize(fs), LibMat.Materiale)
            m2 = CType(bf.Deserialize(fs), LibMat.Materiale)
            Matdim(Problem.indiceD) = m1.Converti()
            Matdim(Problem.indiceW) = m2.Converti()
        End If
        LeggiMateriali()
    End Function
    Public Sub Salva(ByRef fs As FileStream)
        Dim bf As New BinaryFormatter
        bf.Serialize(fs, Problem)
        bf.Serialize(fs, Matdim(Problem.indiceD))
        bf.Serialize(fs, Matdim(Problem.indiceW))
    End Sub
    Public Property DFP() As Single
        Get
            DFP = Problem.p
        End Get
        Set(ByVal Value As Single)
            Problem.p = Value
        End Set
    End Property
    Public Property DFPHydr() As Single
        Get
            DFPHydr = Problem.pHydr
        End Get
        Set(ByVal Value As Single)
            Problem.pHydr = Value
        End Set
    End Property
    Public Property DFt() As Single
        Get
            DFt = Problem.t
        End Get
        Set(ByVal Value As Single)
            Problem.t = Value
        End Set
    End Property
    Public Property DFsab() As Single
        Get
            DFsab = Problem.sab
        End Get
        Set(ByVal Value As Single)
            Problem.sab = Value
        End Set
    End Property
    Public Property DFsabo() As Single
        Get
            DFsabo = Problem.sabo
        End Get
        Set(ByVal Value As Single)
            Problem.sabo = Value
        End Set
    End Property
    Public Property DFsac() As Single
        Get
            DFsac = Problem.sac
        End Get
        Set(ByVal Value As Single)
            Problem.sac = Value
        End Set
    End Property
    Public Property DFsaco() As Single
        Get
            DFsaco = Problem.saco
        End Get
        Set(ByVal Value As Single)
            Problem.saco = Value
        End Set
    End Property
    Public Property DFsad() As Single
        Get
            DFsad = Problem.sad
        End Get
        Set(ByVal Value As Single)
            Problem.sad = Value
        End Set
    End Property
    Public Property DFsado() As Single
        Get
            DFsado = Problem.sado
        End Get
        Set(ByVal Value As Single)
            Problem.sado = Value
        End Set
    End Property
    Public Property DFso() As Single
        Get
            DFso = Problem.SO
        End Get
        Set(ByVal Value As Single)
            Problem.SO = Value
        End Set
    End Property
    Public Property DFsb() As Single
        Get
            DFsb = Problem.sb
        End Get
        Set(ByVal Value As Single)
            Problem.sb = Value
        End Set
    End Property
    Public Property DFsaw() As Single
        Get
            DFsaw = Problem.saw
        End Get
        Set(ByVal Value As Single)
            Problem.saw = Value
        End Set
    End Property
    Public Property DFsawo() As Single
        Get
            DFsawo = Problem.sawo
        End Get
        Set(ByVal Value As Single)
            Problem.sawo = Value
        End Set
    End Property
    Public Property DFid() As Single
        Get
            DFid = Problem.id
        End Get
        Set(ByVal Value As Single)
            Problem.id = Value
        End Set
    End Property
    Public Property DFisi() As Single
        Get
            DFisi = Problem.isi
        End Get
        Set(ByVal Value As Single)
            Problem.isi = Value
        End Set
    End Property
    Public Property DFdi() As Single
        Get
            DFdi = Problem.di
        End Get
        Set(ByVal Value As Single)
            Problem.di = Value
        End Set
    End Property
    Public Property DFg() As Single
        Get
            DFg = Problem.g
        End Get
        Set(ByVal Value As Single)
            Problem.g = Value
        End Set
    End Property
    Public Property DFb() As Single
        Get
            DFb = Problem.b
        End Get
        Set(ByVal Value As Single)
            Problem.b = Value
        End Set
    End Property
    Public Property DFt2() As Single
        Get
            DFt2 = Problem.T2
        End Get
        Set(ByVal Value As Single)
            Problem.T2 = Value
        End Set
    End Property
    Public Property DFt1() As Single
        Get
            DFt1 = Problem.T1
        End Get
        Set(ByVal Value As Single)
            Problem.T1 = Value
        End Set
    End Property
    Public Property DFa() As Single
        Get
            DFa = Problem.a
        End Get
        Set(ByVal Value As Single)
            Problem.a = Value
        End Set
    End Property
    Public Property DFdb() As Single
        Get
            DFdb = Problem.db
        End Get
        Set(ByVal Value As Single)
            Problem.db = Value
        End Set
    End Property
    Public Property DFnb() As Short
        Get
            DFnb = Problem.nb
        End Get
        Set(ByVal Value As Short)
            Problem.nb = Value
        End Set
    End Property
    Public Property DFbc() As Single
        Get
            DFbc = Problem.BC
        End Get
        Set(ByVal Value As Single)
            Problem.BC = Value
        End Set
    End Property
    Public Property DFc() As Single
        Get
            DFc = Problem.Corrosione
        End Get
        Set(ByVal Value As Single)
            Problem.Corrosione = Value
        End Set
    End Property
    Public Property DFtc1() As Single
        Get
            DFtc1 = Problem.tc1
        End Get
        Set(ByVal Value As Single)
            Problem.tc1 = Value
        End Set
    End Property
    Public Property DFtc2() As Single
        Get
            DFtc2 = Problem.tc2
        End Get
        Set(ByVal Value As Single)
            Problem.tc2 = Value
        End Set
    End Property
    Public Property DFed() As Single
        Get
            DFed = Problem.ed
        End Get
        Set(ByVal Value As Single)
            Problem.ed = Value
        End Set
    End Property
    Public Property DFes() As Single
        Get
            DFes = Problem.ES
        End Get
        Set(ByVal Value As Single)
            Problem.ES = Value
        End Set
    End Property
    Public Property DFsydi() As Single
        Get
            DFsydi = Problem.sydi
        End Get
        Set(ByVal Value As Single)
            Problem.sydi = Value
        End Set
    End Property
    Public Property DFsydo() As Single
        Get
            DFsydo = Problem.sydo
        End Get
        Set(ByVal Value As Single)
            Problem.sydo = Value
        End Set
    End Property
    Public Property DFCover() As String
        Get
            DFCover = Problem.Cover
        End Get
        Set(ByVal Value As String)
            Problem.Cover = Value
        End Set
    End Property
    Public Property DFFlange() As String
        Get
            DFFlange = Problem.Flange
        End Get
        Set(ByVal Value As String)
            Problem.Flange = Value
        End Set
    End Property
    Public Property DFBolt() As String
        Get
            DFBolt = Problem.Bolt
        End Get
        Set(ByVal Value As String)
            Problem.Bolt = Value
        End Set
    End Property
    Public Property DFDiaf() As String
        Get
            DFDiaf = Problem.Diaf
        End Get
        Set(ByVal Value As String)
            Problem.Diaf = Value
        End Set
    End Property
    Public Property DFweld() As String
        Get
            DFweld = Problem.weld
        End Get
        Set(ByVal Value As String)
            Problem.weld = Value
        End Set
    End Property
    Public Property pindiceW() As Short
        Set(ByVal Value As Short)
            Problem.indiceW = Value
        End Set
        Get
            pindiceW = Problem.indiceW
        End Get
    End Property
    Public Property pindiceB() As Short
        Set(ByVal Value As Short)
            Problem.IndiceB = Value
        End Set
        Get
            pindiceB = Problem.IndiceB
        End Get
    End Property
    Public Property pindiceC() As Short
        Set(ByVal Value As Short)
            Problem.indiceC = Value
        End Set
        Get
            pindiceC = Problem.indiceC
        End Get
    End Property
    Public Property pindiceD() As Short
        Set(ByVal Value As Short)
            Problem.indiceD = Value
        End Set
        Get
            pindiceD = Problem.indiceD
        End Get
    End Property
    Public Property pindiceF() As Short
        Set(ByVal Value As Short)
            Problem.indiceF = Value
        End Set
        Get
            pindiceF = Problem.indiceF
        End Get
    End Property
    Public Property Verbose() As Boolean
        Get

        End Get
        Set(ByVal Value As Boolean)

        End Set
    End Property
    Public WriteOnly Property UniMis() As Short
        Set(ByVal Value As Short)
        End Set
    End Property
    Public Sub Stampa()
        Dim ifl As Short
        Dim Form As String = ""
        Dim CoverID As String = ""
        Dim FlangeID As String = ""
        If Not PrepRapp(Template, "Diaframma saldato", "ELASTIC DIAPHRAGM", FileSt, mioApert.lstRapp) Then Exit Sub
        Monitor.Motore.Testata()
        ifl = FreeFile()
        FileOpen(ifl, Monitor.Motore.Inizio.Archdir & "\RTF\DIAFR01.RTF", OpenMode.Input, , OpenShare.Shared)
        With Monitor.Motore.Problem
            Assumi(ifl, Form)
            .Printa(GlobalRoutines.FormatS(Form, CoverID))
            Assumi(ifl, Form)
            .Printa(GlobalRoutines.FormatS(Form, FlangeID))
            Assumi(ifl, Form)
            .Printa(GlobalRoutines.FormatS(Form, DFCover))
            Assumi(ifl, Form)
            .Printa(GlobalRoutines.FormatS(Form, DFFlange))
            Assumi(ifl, Form)
            .Printa(GlobalRoutines.FormatS(Form, DFBolt))
            Assumi(ifl, Form)
            .Printa(GlobalRoutines.FormatS(Form, DFDiaf))
            Assumi(ifl, Form)
            .Printa(GlobalRoutines.FormatS(Form, DFweld))
            Assumi(ifl, Form)
            .Printa(GlobalRoutines.FormatS(Form, DFP, DFP / psi))
            Assumi(ifl, Form)
            .Printa(GlobalRoutines.FormatS(Form, DFPHydr, DFPHydr / psi))
            Assumi(ifl, Form)
            .Printa(GlobalRoutines.FormatS(Form, DFt, (DFt - 32) / 1.8))
            Assumi(ifl, Form)
            .Printa(GlobalRoutines.FormatS(Form, ta, (ta - 32) / 1.8))
            Assumi(ifl, Form)
            .Printa(GlobalRoutines.FormatS(Form, DFsab, DFsab / psi))
            Assumi(ifl, Form)
            .Printa(GlobalRoutines.FormatS(Form, DFsabo, DFsabo / psi))
            Assumi(ifl, Form)
            .Printa(GlobalRoutines.FormatS(Form, DFsac, DFsac / psi))
            Assumi(ifl, Form)
            .Printa(GlobalRoutines.FormatS(Form, DFsaco, DFsaco / psi))
            Assumi(ifl, Form)
            .Printa(GlobalRoutines.FormatS(Form, DFso, DFso / psi))
            Assumi(ifl, Form)
            .Printa(GlobalRoutines.FormatS(Form, DFsb, DFsb / psi))
            Assumi(ifl, Form)
            .Printa(GlobalRoutines.FormatS(Form, DFsad, DFsad / psi))
            Assumi(ifl, Form)
            .Printa(GlobalRoutines.FormatS(Form, DFsado, DFsado / psi))
            Assumi(ifl, Form)
            .Printa(GlobalRoutines.FormatS(Form, DFsaw, DFsaw / psi))
            Assumi(ifl, Form)
            .Printa(GlobalRoutines.FormatS(Form, DFsawo, DFsawo / psi))
            Assumi(ifl, Form)
            .Printa(GlobalRoutines.FormatS(Form, DFed / 1000, DFed / psi))
            Assumi(ifl, Form)
            .Printa(GlobalRoutines.FormatS(Form, DFes / 1000, DFes / psi))
            Assumi(ifl, Form)
            .Printa(GlobalRoutines.FormatS(Form, DFisi, DFisi * 1.8))
            Assumi(ifl, Form)
            .Printa(GlobalRoutines.FormatS(Form, DFid, DFid * 1.8))
            Assumi(ifl, Form)
            .Printa(GlobalRoutines.FormatS(Form, nu))
            Assumi(ifl, Form)
            .Printa(GlobalRoutines.FormatS(Form, DFdi, DFdi * inc))
            Assumi(ifl, Form)
            .Printa(GlobalRoutines.FormatS(Form, DFg, DFg * inc))
            Assumi(ifl, Form)
            .Printa(GlobalRoutines.FormatS(Form, DFb, DFb * inc))
            Assumi(ifl, Form)
            .Printa(GlobalRoutines.FormatS(Form, DFt2, DFt2 * inc))
            Assumi(ifl, Form)
            .Printa(GlobalRoutines.FormatS(Form, DFt1, DFt1 * inc))
            Assumi(ifl, Form)
            .Printa(GlobalRoutines.FormatS(Form, DFa, DFa * inc))
            Assumi(ifl, Form)
            .Printa(GlobalRoutines.FormatS(Form, DFdb, DFdb * inc))
            Assumi(ifl, Form)
            .Printa(GlobalRoutines.FormatS(Form, DFnb))
            Assumi(ifl, Form)
        End With
        With Problem
            Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(Form, .sydi, .sydi / psi))
            Assumi(ifl, Form)
            Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(Form, .sydo, .sydo / psi))
            Assumi(ifl, Form)
            Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(Form, k))
            Assumi(ifl, Form)
            Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(Form, eff))
            Assumi(ifl, Form)
            Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(Form, f))
            Assumi(ifl, Form)
            Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(Form, SIF))
            Assumi(ifl, Form)
            FileClose(ifl)
            FileOpen(ifl, Monitor.Motore.Inizio.Archdir & "\RTF\DIAFR02.RTF", OpenMode.Input, , OpenShare.Shared)
            Assumi(ifl, Form)
            Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(Form, .ad, .ad * inc * inc))
            Assumi(ifl, Form)
            Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(Form, .ab, .ab * inc * inc))
            Assumi(ifl, Form)
            Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(Form, .H, .H * NIUT))
            Assumi(ifl, Form)
            Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(Form, .hi, .hi * NIUT))
            Assumi(ifl, Form)
            Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(Form, .sd, .sd / psi))
            Assumi(ifl, Form)
            Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(Form, .sdo, .sdo / psi))
            Assumi(ifl, Form)
            Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(Form, .sb, .sb / psi))
            Assumi(ifl, Form)
            Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(Form, .sbo, .sbo / psi))
            Assumi(ifl, Form)
            Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(Form, .SP, .SP / psi))
            Assumi(ifl, Form)
            Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(Form, .ht, .ht / psi))
            Assumi(ifl, Form)
            Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(Form, .c, .c / psi))
            Assumi(ifl, Form)
            Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(Form, .St, .St / psi))
            'Assumi ifl, Form
            'Print #iout, FormatS(Form, .hti, .hti / psi)
            Assumi(ifl, Form)
            Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(Form, .SP + .St, (.SP + .St) / psi))
            Assumi(ifl, Form)
            Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(Form, (.SP + .St * SIF) / 2, (.SP + .St * SIF) / 2 / psi))
        End With
        Assumi(ifl, Form)
        FileClose(ifl)
    End Sub
    Public Sub Riversa()
        Dim k, j, Dimen As Short
        Dim Syo, Sya, W As Single
        DFP = Coperchio.Zp(1) 'pressione di progetto
        DFPHydr = Config(kLato).pxTest * psi 'pressione di prova
        DFt = Coperchio.Zp(2) 'temperatura di progetto
        '  On Error Resume Next
        DFsac = Flangia.Zp(22) 'cassa
        DFsaco = Flangia.Zp(23) 'cassa
        DFso = Coperchio.Zp(23) 'coperchio
        DFsb = Coperchio.Zp(22) 'coperchio
        DFsab = Coperchio.Zp(25) 'bulloni ammissibile
        If Config(0).CalcPI = 1 Then
            DFsabo = Coperchio.Zp(171) 'bulloni ammissibile PI
        Else
            DFsabo = -1
        End If
        'DFsad = -1 'diaframma amm
        'DFsado = -1 'diaframma amm o
        'DFed = -1
        'DFes = -1
        'DFsaw = -1 'saldatura
        'DFsawo = -1 'saldatura
        DFdi = Flangia.Zp(6) 'interno cassa
        On Error GoTo 0
        DFb = Coperchio.Zp(26) 'larghezza app.diaframma
        DFg = Coperchio.Zp(5) + Coperchio.Zp(26) ' -1 'diametro ext.diaf.ela
        'DFt2 = -1 'spessore perif.diaframma
        'DFt1 = -1 'spessore al centro
        DFbc = Coperchio.Zp(4) 'diametro centro bulloni
        DFdb = Coperchio.Zp(14) 'diametro nocciolo bulloni
        DFnb = Coperchio.Zp(13) 'numero bulloni
        'DFa = -1 'dimensione saldatura
        DFc = Coperchio.Zp(120) 'corrosione
        DFtc1 = Coperchio.Zp(119) 'Spessore cop. al centro
        'DFtc2 = -1 'Spessore cop.periferia
        'DFid = -1 'coeficente dilatazione cassa
        'DFisi = -1 'coeficente dilatazione diaframma
        LeggiMateriali()
        With Problem
            W = Coperchio.Zp(40)
            If Coperchio.Zp(41) > W Then W = Coperchio.Zp(41)
            .H = W 'W in esercizio
            W = Coperchio.Zp(193)
            If Config(0).CalcPI = 1 Then
                If Coperchio.Zp(194) > W Then W = Coperchio.Zp(194)
                .hi = W '
            Else
                .hi = 0
            End If
            Matdim(.indiceC).YieldTemp(CodiceStress, TempDes, Sya, Syo)
            .sacy = Syo / mpa : .sacy0 = Sya / mpa
            Matdim(.indiceD).YieldTemp(CodiceStress, TempDes, Sya, Syo)
            .sady = Syo / mpa : .sady0 = Sya / mpa
            Matdim(.indiceF).YieldTemp(CodiceStress, TempDes, Sya, Syo)
            .safy = Syo / mpa : .safy0 = Sya / mpa
            .sydo = .sacy
            If .sydo > .sady And .sady > 0 Then .sydo = .sady
            If .sydo > .safy And .safy > 0 Then .sydo = .safy
            .sydi = .sacy0
            If .sydi > .sady0 And .sady0 > 0 Then .sydi = .sady0
            If .sydi > .safy0 And .safy0 > 0 Then .sydi = .safy0
        End With
    End Sub
    Private Sub Assumi(ByRef ifl As Short, ByRef Form As String)
        Do
            If EOF(ifl) Then Exit Do
            Form = LineInput(ifl)
            If Left(Form, 1) = "_" Then Exit Do
            Monitor.Motore.Problem.Printa(Form)
        Loop
    End Sub


    Private Sub Aggiornaweld()
        Dim AllFRoo, AllFOpe As Single
        DFweld = Matdim(Problem.indiceW).MatStr
        Matdim(Problem.indiceW).SigmaAmm(CodiceStress, TempDes, AllFRoo, AllFOpe)
        AllFRoo = AllFRoo / mpa : AllFOpe = AllFOpe / mpa
        DFsaw = AllFOpe
        DFsawo = AllFRoo
    End Sub
    Private Sub Aggiornabolt()
        Dim AllFRoo, AllFOpe As Single
        DFBolt = Matdim(Problem.IndiceB).MatStr
        Matdim(Problem.IndiceB).SigmaAmm(CodiceStress, TempDes, AllFRoo, AllFOpe)
        AllFRoo = AllFRoo / mpa : AllFOpe = AllFOpe / mpa
        DFsab = AllFOpe
        DFsabo = AllFRoo
    End Sub
    Private Sub Aggiornacover()
        Dim AllFRoo, AllFOpe As Single
        DFCover = Matdim(Problem.indiceC).MatStr
        Matdim(Problem.indiceC).SigmaAmm(CodiceStress, TempDes, AllFRoo, AllFOpe)
        AllFRoo = AllFRoo / mpa : AllFOpe = AllFOpe / mpa
        DFsac = AllFOpe
        DFsaco = AllFRoo
    End Sub
    Private Sub Aggiornadiaf()
        Dim AllFRoo, AllFOpe As Single
        DFDiaf = Matdim(Problem.indiceD).MatStr
        Matdim(Problem.indiceD).SigmaAmm(CodiceStress, TempDes, AllFRoo, AllFOpe)
        AllFRoo = AllFRoo / mpa : AllFOpe = AllFOpe / mpa
        DFsad = AllFOpe
        DFsado = AllFRoo
        DFed = Matdim(Problem.indiceD).EmodAlt(TempDes) / mpa
        DFes = Matdim(Problem.indiceD).EmodAlt(20) / mpa
        DFisi = Matdim(Problem.indiceD).AlfaTer(TempDes) / 1.8
    End Sub
    Private Sub AggiornaFlange()
        Dim AllFRoo, AllFOpe As Single
        DFFlange = Matdim(Problem.indiceF).MatStr
        Matdim(Problem.indiceF).SigmaAmm(CodiceStress, TempDes, AllFRoo, AllFOpe)
        AllFRoo = AllFRoo / mpa : AllFOpe = AllFOpe / mpa
        DFsac = AllFOpe
        DFsaco = AllFRoo
        DFid = Matdim(Problem.indiceF).AlfaTer(TempDes) / 1.8
    End Sub
    Public Sub SceltaDiaf()
        MatdimScelta(Problem.indiceD, Matdim(Problem.indiceD).Classe, kLato, , kNozzle)
        'Problem.RecIndD = Matdim(Problem.indiceD).Indmat
        Aggiornadiaf()
    End Sub
    Public Sub SceltaBolt()
        MatdimScelta(Problem.IndiceB, Matdim(Problem.IndiceB).Classe, kLato, , kNozzle)
        'Problem.RecIndB = Matdim(Problem.IndiceB).Indmat
        Aggiornabolt()
    End Sub
    Public Sub SceltaCover()
        MatdimScelta(Problem.indiceC, Matdim(Problem.indiceC).Classe, kLato, , kNozzle)
        'Problem.RecIndC = Matdim(Problem.indiceC).Indmat
        Aggiornacover()
    End Sub
    Public Sub SceltaFlange()
        MatdimScelta(Problem.indiceF, Matdim(Problem.indiceF).Classe, kLato, , kNozzle)
        'Problem.RecIndF = Matdim(Problem.indiceF).Indmat
        AggiornaFlange()
    End Sub
    Public Sub SceltaWeld()
        MatdimScelta(Problem.indiceW, Matdim(Problem.indiceW).Classe, kLato, , kNozzle)
        'Problem.RecIndW = Matdim(Problem.indiceW).Indmat
        Aggiornaweld()
    End Sub
    Public Sub LeggiMateriali()
        Dim j, k As Short
        Dim Dimen As Short
        With Problem
            .indiceC = Involucr(kLato, jInvolucr).indice(1 - 1) 'cover
            .IndiceB = Involucr(kLato, jInvolucr).indice(2 - 1) 'bulloni
            j = Involucr(kLato, jInvolucr).AccoppJ
            k = Involucr(kLato, jInvolucr).AccoppK
            If j = 0 Then
                .indiceF = -1
                '.RecIndF = 0
            Else
                .indiceF = Involucr(k, j).indice(1 - 1)
                '080706 .RecIndF = Involucr(k, j).RecInd(1 - 1)
            End If
            '080706 .RecIndC = Involucr(kLato, jInvolucr).RecInd(1 - 1)
            '080706 .RecIndB = Involucr(kLato, jInvolucr).RecInd(2 - 1)
            If .indiceC >= 0 Then
                If Not Matdim(.indiceC) Is Nothing Then DFCover = Matdim(.indiceC).MatStr
            End If
            If .IndiceB >= 0 Then
                If Not Matdim(.IndiceB) Is Nothing Then DFBolt = Matdim(.IndiceB).MatStr
            End If
            If .indiceF >= 0 Then
                If Not Matdim(.indiceF) Is Nothing Then DFFlange = Matdim(.indiceF).MatStr
            End If
            If .indiceD <= 0 Then
                .indiceD = NuovoIndice()
                indici.Add(.indiceD)
            End If
            Involucr(kLato, jInvolucr).indice(3 - 1) = .indiceD
            Dimen = UBound(Matdim)
            If .indiceD > Dimen Then
                ReDim Preserve Matdim(2 * Dimen)
            End If
            If Matdim(.indiceD) Is Nothing Then
                Matdim(.indiceD) = New LibMat.MaterialeNew1
                Matdim(.indiceD).Agganciato = True
                '                If .RecIndD > 0 Then
                '               Matdim(.indiceD).Indmat = .RecIndD
                '              Matdim(.indiceD).RecupMat(clsInizio.Archdir)
                '             .RecIndD = Matdim(.indiceD).Indmat
                '            Matdim(.indiceD).Agganciato = True
                '           Aggiornadiaf()
                '      End If
            Else
                Aggiornadiaf()
            End If
            If .indiceW > 2 * Dimen Then .indiceW = -1
            If .indiceW < 0 Then
                .indiceW = NuovoIndice()
                indici.Add(.indiceW)
            End If
            Involucr(kLato, jInvolucr).indice(4 - 1) = .indiceW
            Dimen = UBound(Matdim)
            If .indiceW > Dimen Then
                ReDim Preserve Matdim(2 * Dimen)
            End If
            If Matdim(.indiceW) Is Nothing Then
                Matdim(.indiceW) = New LibMat.MaterialeNew1
                Matdim(.indiceW).Agganciato = True
                '                If .RecIndW > 0 Then
                '               Matdim(.indiceW).Indmat = .RecIndW
                '              Matdim(.indiceW).RecupMat(clsInizio.Archdir)
                '             .RecIndW = Matdim(.indiceW).Indmat
                '            Matdim(.indiceW).Agganciato = True
                '           Aggiornaweld()
                '      End If
            Else
                Aggiornaweld()
            End If
        End With
    End Sub
    'UPGRADE_NOTE: Class_Initialize è stato aggiornato a Class_Initialize_Renamed. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1061"'
    Private Sub Class_Initialize_Renamed()
        lKlato = kLato
        lJinvolucr = jInvolucr
        Problem.indiceW = -1
        Problem.IndiceB = -1
        Problem.indiceC = -1
        Problem.indiceF = -1
        Problem.indiceD = -1
    End Sub
    Public Sub New()
        MyBase.New()
        Class_Initialize_Renamed()
    End Sub
End Class