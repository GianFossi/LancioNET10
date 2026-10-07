Option Strict Off
Option Explicit On
Imports System.IO 'Namespace for Filestreams
Imports System.Runtime.Serialization.Formatters.Binary 'Namespace for BinaryFormatter
Imports System.Runtime.InteropServices
Imports Microsoft.Office.Interop
Module GenSurr
    Structure typRegolaz
        Dim Bypass() As Single
        Dim Tgprima() As Single
        Dim Tgdopo() As Single
        Dim Tvap() As Single
        Dim Angolo() As Single
        Public Sub Initialize()
            ReDim Bypass(50)
            ReDim Tgprima(50)
            ReDim Tgdopo(50)
            ReDim Tvap(50)
            ReDim Angolo(50)
        End Sub
    End Structure
    Structure typStandard
        Dim OverOTL As Single
        Dim SpessCieco As Single
        Dim Lane As Single 'distanza tra le corone (al netto OverOTL)
        Dim SpessTuboCentrale As Single
        Dim SpessFasciameExt As Single
    End Structure
    Structure Zona
        Dim Q As Single
        Dim Ui As Single 'ingresso vapore
        Dim Uo As Single
        Dim Tvapi As Single
        Dim Tvapo As Single
        Dim Tgasi As Single
        Dim Tgaso As Single
        Dim Lungh As Single
        Dim LMTD As Single
        Dim FT As Single
        Dim MTD As Single
        Dim dp As Single
        Dim ugas As Single
        Dim interno As Boolean
        Dim Rex As Single
        Dim TWinti As Single
        Dim TWexti As Single
        Dim Twinto As Single
        Dim Twexto As Single
    End Structure
    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> Structure TempMors
        Dim Tvin As Single
        Dim Tvout As Single
        Dim Tgasin As Single
        Dim Tgasout As Single
    End Structure
    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> Structure typGeom
        Dim DiamExtTubi As Single
        Dim SpessTubi As Single
        Dim PassoTubiInt As Single
        Dim PassoTubiExt As Single
        Dim TipoPassoInt As Short '0 triangolare 1 quadrato
        Dim TipoPassoExt As Short
        Dim ITLint As Single
        Dim OTLint As Single
        Dim ITLout As Single
        Dim OTLout As Single
        Dim LungDiritta As Single
        Dim LungCieca As Single
        Dim NumeroTubi As Short
        Dim DiamCentrale As Single
        Dim DiamFasciameInt As Single
        Dim DiamFasciameExt As Single
        Dim SpesFasciameExt As Single
        Dim DiamIntMant As Single
        Dim NumeroFileInt As Single
        Dim NumeroFileOut As Single
        Dim DropVap As Single
        Dim DropGas As Single
        Dim BWGTubi As Short
        Dim padding1 As Short
        Dim Area As Single
        Dim SteamInlet As Single
        Dim SteamOutlet As Single
        Dim GasOutlet As Single
        Dim IndMatTubi As Short
        Dim IndMatShell As Short
        Dim IndMatTS As Short
        Dim IndMatCassa As Short
        Dim RMinTubi As Single
        Dim DiamMantello As Single
        Dim FiValv As Single
        Dim AreaForiValv As Single
        <VBFixedString(134), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=134)> Public padding As String
    End Structure
    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> Structure typProblem
        <VBFixedString(40), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=40)> Public Fluido As String
        <VBFixedString(20), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=20)> Public Cliente As String
        <VBFixedString(10), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=10)> Public Item As String
        <VBFixedString(3), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=3)> Public Author As String
        Dim Temp As TempMors
        Dim PressGasIn As Single
        Dim PressVapIn As Single
        Dim Qgas As Single
        Dim Qvap As Single
        Dim VelVapMax As Single
        Dim VelGasMaxCen As Single
        Dim VelGasMaxCieco As Single
        Dim Rinside As Single
        Dim Routside As Single
        Dim tmin As Single
        Dim Tmax As Single
        Dim VolMin As Single
        Dim VolMax As Single
        Dim ViscoMin As Single
        Dim ViscoMax As Single
        Dim CpMin As Single
        Dim CpMax As Single
        Dim kMin As Single
        Dim kMax As Single
        Dim Smooth As Boolean
        Dim Funz As TempMors
        Dim Watt As Single
        Dim UAll As Single
        Dim LMDT As Single
        Dim MDT As Single
        Dim dpAllGas As Single
        Dim dpAllVap As Single
        Dim UAllC As Single
        Dim kHigh As Single 'conducibilità tubi a Tgasin
        Dim kLow As Single '                   a Tvout
        Dim FluidiInvertiti As Boolean
        Dim QminReg As Single
        <VBFixedString(47), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=47)> Public padding As String
    End Structure
    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> Structure typConfig
        Dim VariabIndProg As Short '1 portata gas 2 portata vapore 3 tgasout 4 tgasin
        Dim TipoCalc As Short '1 a 3 zone 2 a 2 zone 3 a 6 zone 4 a 8 zone
        Dim Progetto As Short '0 progetto (area ignota) 1 temp out ignote
        Dim Autom As Boolean
        Dim Tipo As Short '1 1 passo,2 1 passo con cieco ,3 2 passi
        Dim NCross As Short
        Dim NCrossCieco As Short
        Dim VapPpgas As Boolean
        Dim Nuovo As Boolean
        <VBFixedString(88), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=88)> Public DescrAlt As String
    End Structure
    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> Structure typDesignData
        Dim PShell As Single
        Dim PTubi As Single
        Dim PTS As Single
        Dim PCassa As Single
        Dim TShell As Single
        Dim TTubi As Single
        Dim TTS As Single
        Dim TCassa As Single
        Dim cShell As Single
        Dim cTubi As Single
        Dim cTS As Single
        Dim cCassa As Single
    End Structure
    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> Structure typTuttiDati
        Dim c As typConfig
        Dim p As typProblem
        Dim g As typGeom
        Dim d As typDesignData
    End Structure
    Private QtotFunz As Single
    Private ho, Ro, Rio, sk, hio As Single
    Friend myAssembly As System.Reflection.Assembly
    Friend FormTubi As frmTubi
    Friend mioApert As Apert
    Friend Funzioni As New RoutBase1.clsTrigon
    Public dpgastot As Single
    Public Angoli(12) As Single
    Public kFarfalle(14, 1) As Single
    Public Surr As clsSurrisc
    Public fi As Single
    Public Altern, nAlt As Short
    Public Schiavo As Boolean
    Public savProbl As typProblem
    Public Reg(1) As typRegolaz '17/01/01
    Public ErroreGenerale As Boolean
    Public Critical As Boolean
    Public job As RoutBase1.clsjob
    Public DaTos As traccia.clsTracciatura.typDaTos
    Public MatTubi As New LibMat.MaterialeNew1
    Public Fase As Short
    Public Problem As typProblem
    Public Geom As typGeom
    Public Config As typConfig
    Public DesignData As typDesignData
    Public Standard As typStandard
    Public Nzone As Short
    Public FileData As String
    Public Gas As Ppgas.clsPpg
    Public Vap As VapAcqua.clsVapAcqua
    Public Prop As Proprietà
    Public Monitor As clsMonitor
    Public Zone() As Zona
    Public OrdGas() As Short
    Public PrecGas() As Short
    Public SuccGas() As Short
    Public Atot As Single
    Public Qtot As Single
    Public yv As Single
    Public xg As Single
    Public y As Single
    'Public LunghTot As Single, LungCieca As Single
    'Public DiamTubExt As Single, NumTubi As Integer
    'Public U1 As Single, U2 As Single, U3 As Single, U4 As Single
    Public Gvcv, Ggcg As Single
    Public nReg As Short
    Public Const PI As Double = 3.14159265

    Public Function CercaTempInt() As Boolean
        Dim Q2, Q1, Q3 As Single
        Dim Qtot1 As Single
        Dim x1g, y1v, y1 As Single
        'UPGRADE_NOTE: Err è stato aggiornato a Err_Renamed. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
        Dim Err_Renamed, Err1 As Single
        Dim icont As Short
        CercaTempInt = True
        Do
            Q1 = Geom.LungCieca / (2 * Geom.LungDiritta) * Atot * Dtln1()
            Q2 = (Geom.LungDiritta - Geom.LungCieca) / (2 * Geom.LungDiritta) * Atot * Dtln2()
            Q3 = (Geom.LungDiritta - Geom.LungCieca) / (2 * Geom.LungDiritta) * Atot * Dtln3()
            Qtot1 = Q1 + Q2 + Q3
            Atot = Atot * Gvcv / Qtot1
            If Config.Progetto = 0 Then
                Geom.LungDiritta = Geom.LungDiritta * Gvcv / Qtot1
                y1v = Surr.TempLTf + Q1 / Gvcv * Qtot / Qtot1
                y1 = Surr.TempLTc - Q3 / Gvcv * Qtot / Qtot1
                x1g = Surr.TempLMc - (Q2 + Q3) / Ggcg * Qtot / Qtot1
            Else
                Stop
            End If
            Err_Renamed = 0
            Err1 = System.Math.Abs(y1v - yv) / yv
            If Err1 > Err_Renamed Then Err_Renamed = Err1
            Err1 = System.Math.Abs(y1 - y) / y
            If Err1 > Err_Renamed Then Err_Renamed = Err1
            Err1 = System.Math.Abs(x1g - xg) / xg
            If Err1 > Err_Renamed Then Err_Renamed = Err1
            Err1 = System.Math.Abs(Gvcv - Qtot1) / Gvcv
            If Err1 > Err_Renamed Then Err_Renamed = Err1
            If Err_Renamed < 0.0001 Or icont > 50 Then Exit Do
            yv = y1v ' (y1v + yv) / 2
            y = y1 ' (y + y1) / 2
            xg = x1g '(xg + x1g) / 2
            If xg <= Surr.TempLTc + 0.0001 Then xg = Surr.TempLTc + 0.5 + (Surr.TempLTc - xg) / (icont + 1)
            If yv > xg Then yv = xg - 0.5 + (xg - yv) / (icont + 1)
            If y > Surr.TempLMc Then y = Surr.TempLMc - 0.5 - (y - Surr.TempLMc) / (icont + 1)
            icont = icont + 1
            '   Debug.Print icont, Err, Qtot1, Qtot, yv, y, xg
        Loop
        If icont > 50 Then CercaTempInt = False
        Exit Function
    End Function
    Public Function CercaTempInt1() As Boolean
        Dim Q1, Q2 As Single
        Dim Qtot1 As Single
        Dim y1v, x1g As Single
        'UPGRADE_NOTE: Err è stato aggiornato a Err_Renamed. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
        Dim Err_Renamed, Err1 As Single
        Dim icont As Short
        CercaTempInt1 = True
        Do
            Q1 = Geom.LungCieca / (2 * Geom.LungDiritta) * Atot * Dtln1()
            Q2 = 2 * (Geom.LungDiritta - Geom.LungCieca) / (2 * Geom.LungDiritta) * Atot * Dtln4()
            Q2 = Q2 * FT4()
            Qtot1 = Q1 + Q2
            If Config.Progetto = 0 Then
                Atot = Atot * Gvcv / Qtot1
                Geom.LungDiritta = Geom.LungDiritta * Gvcv / Qtot1
                y1v = Surr.TempLTf + Q1 / Gvcv * Qtot / Qtot1
                x1g = Surr.TempLMc - Q2 / Ggcg * Qtot / Qtot1
            Else
                Stop
            End If
            Err_Renamed = 0
            Err1 = System.Math.Abs(y1v - yv) / yv
            If Err1 > Err_Renamed Then Err_Renamed = Err1
            Err1 = System.Math.Abs(x1g - xg) / xg
            If Err1 > Err_Renamed Then Err_Renamed = Err1
            Err1 = System.Math.Abs(Gvcv - Qtot1) / Gvcv
            If Err1 > Err_Renamed Then Err_Renamed = Err1
            If Err_Renamed < 0.0001 Or icont > 50 Then Exit Do
            yv = y1v ' (y1v + yv) / 2
            xg = x1g '(xg + x1g) / 2
            If xg < Surr.TempLTc Or xg >= Surr.TempLMc Then xg = Surr.TempLTc + 0.5 + (Surr.TempLTc - xg) / (icont + 1)
            If yv > xg Then yv = xg - 0.5 + (xg - yv) / (icont + 1)
            icont = icont + 1
            '   Debug.Print icont, Err, Qtot1, Qtot, yv, y, xg
        Loop
        If icont > 50 Then CercaTempInt1 = False
        Exit Function
    End Function
    Public Function CercaTempInt2() As Boolean
        Dim Qtot1 As Single
        Dim i, j As Short
        Dim Err1, Err_Renamed, Err2 As Single
        Dim icont As Short
        Dim CpG, Fact As Single
        Dim Regime As Boolean
        Dim Procedi As Boolean
        Dim icontmax, iErr As Short
        Static QtotV As Single
        Dim tvzout(Nzone) As Single
        Dim tgaszout(Nzone) As Single
        Dim tvzout1(Nzone) As Single
        Dim tgaszout1(Nzone) As Single
        icontmax = 100
        CercaTempInt2 = True
        Do
            If icont = 0 Or Config.Progetto = 0 Then Lunghezze()
            CalcolaCalori()
            Qtot1 = 0
            For i = 1 To Nzone
                Qtot1 = Qtot1 + Zone(i).Q
            Next
            If Config.Progetto = 0 Then
                If Qtot1 = 0 Then
                    MsgBox("Ripassare il Bilancio", MsgBoxStyle.Critical)
                    CercaTempInt2 = False
                    Critical = True
                    Exit Function
                End If
                If ((Qtot1 < 0 And Not Problem.FluidiInvertiti) Or (Qtot1 > 0 And Problem.FluidiInvertiti)) And Not Config.Nuovo Then
                    Qtot1 = Gvcv
                    CercaTempInt2 = False
                    Exit Do 'Qtot1 = Gvcv * 2
                End If
                ' Nuovo = True
                If Not Config.Nuovo Or Procedi Then Geom.LungDiritta = Geom.LungDiritta * System.Math.Abs(Gvcv / Qtot1)
                If Config.Tipo = 2 And Geom.LungCieca > 0.7 * Geom.LungDiritta Then Geom.LungCieca = 0.7 * Geom.LungDiritta
                Atot = 2 * Geom.LungDiritta * PI * Geom.DiamExtTubi * 0.001 * Geom.NumeroTubi
                'If Config.TipoCalc = 3 Then Geom.LungCieca = Geom.LungCieca * Gvcv / Qtot1
                Fact = System.Math.Abs(Gvcv / Qtot1)
                'If Config.Nuovo Then Fact = 1
            Else
                'Fact = Gvcv / Qtot1
                Fact = 1
                'If icont > 0 Then Fact = (Qtot1 + QtotV) / 2 / Qtot1
                ' Debug.Print Qtot1, QtotV
                NuoveTemp(System.Math.Abs(Qtot1) * Fact, iErr)
                If iErr = 1 Then
                    CercaTempInt2 = False : Exit Function
                End If
            End If
            tvzout(0) = Surr.TempLTf
            tgaszout(0) = Surr.TempLMc
            '   Fact = 0.5
            For i = 1 To Nzone
                CpG = Surr.PortLT * Prop.CpVap((Zone(i).Tvapi + Zone(i).Tvapo) / 2)
                'da sistemare nel caso di VapAcq
                tvzout(i) = tvzout(i - 1) + Zone(i).Q / CpG * Fact * (2 * CShort(Problem.FluidiInvertiti) + 1) '??????????????
                j = OrdGas(i)
                CpG = Surr.PortLM * Prop.CpGas((Zone(j).Tgasi + Zone(j).Tgaso) / 2)
                tgaszout(i) = tgaszout(i - 1) - Zone(j).Q / CpG * Fact * (2 * CShort(Problem.FluidiInvertiti) + 1)
                If tgaszout(i) < Surr.TempLMf Then tgaszout(i) = Surr.TempLMf
            Next
            '   Debug.Print tvzout(0); tvzout(1); tvzout(2); tvzout(3); tvzout(4); tvzout(5); tvzout(6)
            '   Debug.Print tgaszout(0); tgaszout(1); tgaszout(2); tgaszout(3); tgaszout(4); tgaszout(5); tgaszout(6)
            For i = 1 To Nzone
                If tvzout1(i) > 0 Then tvzout(i) = (tvzout(i) + tvzout1(i)) / 2
                If tgaszout1(i) > 0 Then tgaszout(i) = (tgaszout(i) + tgaszout1(i)) / 2
                tvzout1(i) = tvzout(i)
                tgaszout1(i) = tgaszout(i)
            Next
            Err_Renamed = 0
            ' If Config.Progetto = 0 Then
            For i = 1 To Nzone
                Err1 = System.Math.Abs(tvzout(i) - Zone(i).Tvapo) / Zone(i).Tvapo
                If Err1 > Err_Renamed Then Err_Renamed = Err1
                j = OrdGas(i)
                Err1 = System.Math.Abs(tgaszout(i) - Zone(j).Tgaso) / Zone(j).Tgaso
                If Err1 > Err_Renamed Then Err_Renamed = Err1
            Next
            ' End If
            If Not Config.Nuovo Or Procedi Or Config.Progetto = 1 Then
                If Config.Progetto = 0 Then
                    Err1 = System.Math.Abs(Gvcv - System.Math.Abs(Qtot1)) / Gvcv
                    If Err1 > Err_Renamed Then Err_Renamed = Err1
                Else
                    If QtotV > 0 Then Err2 = System.Math.Abs((QtotV - Qtot1) / QtotV)
                    '  Debug.Print QtotV, Qtot1
                    If Err2 > Err_Renamed Then Err_Renamed = Err2
                End If
            End If
            Regime = icont > 60
            If Err_Renamed < 0.00001 Or icont > icontmax Then
                If Config.Nuovo Or Config.Progetto = 1 Then
                    If Not Procedi And Config.Progetto = 0 Then
                        icont = 0
                        Procedi = True
                    Else
                        Exit Do
                    End If
                Else
                    Exit Do
                End If
            Else
                Procedi = False
            End If
            '   If Config.Progetto = 0 Then
            For i = 1 To Nzone
                Zone(i).Tvapo = (tvzout(i) + Zone(i).Tvapo) / 2
                If i < Nzone Then Zone(i + 1).Tvapi = (tvzout(i) + Zone(i + 1).Tvapi) / 2
                j = OrdGas(i)
                Zone(j).Tgaso = (tgaszout(i) + Zone(j).Tgaso) / 2
                If i < Nzone Then Zone(OrdGas(i + 1)).Tgasi = (tgaszout(i) + Zone(OrdGas(i + 1)).Tgasi) / 2
            Next
            '   End If
            If Not Regime Then Aggiusta(iErr)
            If iErr > 0 Then
                CercaTempInt2 = False
                Exit Function
            End If
            If Config.Tipo = 2 Then
                yv = Zone(Config.NCrossCieco).Tvapo
                y = Zone(Config.NCross + Config.NCrossCieco).Tvapo
                xg = Zone(Nzone).Tgaso
            End If
            icont = icont + 1
            ' Debug.Print icont, Err, Qtot1, Qtot, yv, y, xg
            QtotV = Qtot1
        Loop
        QtotFunz = Qtot1
        If icont > icontmax Then CercaTempInt2 = False
        Exit Function
    End Function
    Public Function Dtln1() As Single
        Dim Um As Single
        Dim Dm, Tw, Tvap, Tgas, l As Single
        Tvap = (Surr.TempLTf + yv) / 2
        Tgas = (Surr.TempLMf + xg) / 2
        Tw = (Tvap + Tgas) / 2
        Dm = (Geom.ITLout + Geom.OTLout) / 2
        l = Geom.LungCieca : If l = 0 Then l = 1
        Um = u(Tvap, Tw, Tgas, Dm, l, False)
        If System.Math.Abs((-Surr.TempLTf + Surr.TempLMf) / (-yv + xg) - 1) < 0.001 Then
            Dtln1 = Um * ((-Surr.TempLTf + Surr.TempLMf) + (-yv + xg)) / 2
        Else
            Dtln1 = Um * ((-Surr.TempLTf + Surr.TempLMf) - (-yv + xg)) / System.Math.Log((-Surr.TempLTf + Surr.TempLMf) / (-yv + xg))
        End If
    End Function
    Public Function Dtln3() As Single
        Dim Um As Single
        Dim Dm, Tw, Tvap, Tgas, l As Single
        Tvap = (yv + y) / 2
        Tgas = (Surr.TempLMc + xg) / 2
        Tw = (Tvap + Tgas) / 2
        Dm = (Geom.ITLint + Geom.OTLint) / 2
        l = Geom.LungDiritta - Geom.LungCieca
        Um = u(Tvap, Tw, Tgas, Dm, l, True)
        If Um = 0 Then Exit Function
        If System.Math.Abs((-yv + xg) / (-y + Surr.TempLMc) - 1) < 0.001 Then
            Dtln3 = Um * ((-yv + xg) + (-y + Surr.TempLMc)) / 2
        Else
            Dtln3 = Um * ((-yv + xg) - (-y + Surr.TempLMc)) / System.Math.Log((-yv + xg) / (-y + Surr.TempLMc))
        End If
    End Function
    Public Function Dtln2() As Single
        Dim Um As Single
        Dim Dm, Tw, Tvap, Tgas, l As Single
        Tvap = (Surr.TempLTc + y) / 2
        Tgas = (Surr.TempLMc + xg) / 2
        Tw = (Tvap + Tgas) / 2
        Dm = (Geom.ITLout + Geom.OTLout) / 2
        l = Geom.LungDiritta - Geom.LungCieca
        Um = u(Tvap, Tw, Tgas, Dm, l, False)
        Dtln2 = Um * ((-Surr.TempLTc + xg) - (-y + Surr.TempLMc)) / System.Math.Log((-Surr.TempLTc + xg) / (-y + Surr.TempLMc))
    End Function
    Public Function Dtln4() As Single
        Dim Um As Single
        Dim Dm, Tw, Tvap, Tgas, l As Single
        Tvap = (Surr.TempLTc + y) / 2
        Tgas = (Surr.TempLMc + xg) / 2
        Tw = (Tvap + Tgas) / 2
        Dm = (Geom.OTLout + Geom.ITLint) / 2
        l = 2 * (Geom.LungDiritta - Geom.LungCieca)
        Um = u(Tvap, Tw, Tgas, Dm, l, False)
        If System.Math.Abs((-Surr.TempLTc + Surr.TempLMc) / (-yv + xg)) - 1 < 0.001 Then
            Dtln4 = Um * ((-Surr.TempLTc + Surr.TempLMc) + (-yv + xg)) / 2
        Else
            Dtln4 = Um * ((-Surr.TempLTc + Surr.TempLMc) - (-yv + xg)) / System.Math.Log((-Surr.TempLTc + Surr.TempLMc) / (-yv + xg))
        End If
    End Function
    Public Sub CercaCieca()
        'UPGRADE_NOTE: Step è stato aggiornato a Step_Renamed. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
        Dim Step_Renamed As Single
        Dim OK As Boolean
        Dim icont As Short
        Step_Renamed = 10
Rif:
        Do
            If Geom.LungCieca > Geom.LungDiritta Then
                Geom.LungCieca = Geom.LungDiritta
                Step_Renamed = -Step_Renamed * 10
            End If
            OK = CercaTemp()
            If Critical Then Exit Sub
            If icont > 20 Then
                MsgBox("Non convergenza nella ricerca della cieca minima")
                Exit Sub
            End If
            'If Geom.LungDiritta > 20 Then Geom.LungDiritta = 20
            Geom.LungCieca = Geom.LungCieca + Geom.LungDiritta / Step_Renamed
            icont = icont + 1
        Loop While Not OK
        Geom.LungCieca = Geom.LungCieca - Geom.LungDiritta / Step_Renamed
        If OK And Step_Renamed = 10 And Geom.LungCieca >= Geom.LungDiritta / Step_Renamed Then
            Step_Renamed = -Step_Renamed * 10
            Do
                Geom.LungCieca = Geom.LungCieca + Geom.LungDiritta / Step_Renamed
            Loop While CercaTemp() And Geom.LungCieca > -Geom.LungDiritta / Step_Renamed
            Geom.LungCieca = Geom.LungCieca - Geom.LungDiritta / Step_Renamed
            'If Abs(Geom.LungCieca) < 0.1 Then Geom.LungCieca = 0
            mioApert.txtTemp(24).Text = Funzioni.myStr(Geom.LungCieca * 1000, 4, 2, False)
        End If
    End Sub
    Public Sub CercaOttimo()
        Dim Step_Renamed, AtotOpt As Single
        Dim LungCmin, LungCOpt, Lungh As Single
        Dim AtotMin As Single
        AtotOpt = Atot
        AtotMin = Atot
        LungCmin = Geom.LungCieca
        LungCOpt = Geom.LungCieca
        Step_Renamed = 100
        Do
            'Debug.Print Atot / (2 * Geom.LungDiritta - Geom.LungCieca), Geom.LungCieca, xg, yv
            Geom.LungCieca = Geom.LungCieca + Geom.LungDiritta / Step_Renamed
            If Geom.LungCieca >= Geom.LungDiritta Then Exit Do
            If Atot <= AtotOpt Then
                AtotOpt = Atot
                LungCOpt = Geom.LungCieca
                Lungh = Geom.LungDiritta
            Else
                Exit Do
            End If
        Loop While CercaTemp() And Geom.LungCieca < Geom.LungDiritta
        'Debug.Print LungCmin, AtotMin, LungCOpt, AtotOpt, Problem.Temp.Tgasin, Problem.Temp.Tgasout, Problem.Temp.Tvin, Problem.Temp.Tvout
        If System.Math.Abs(LungCOpt) < 0.1 Then LungCOpt = 0
        Geom.LungDiritta = Lungh
        Geom.LungCieca = LungCOpt
        With mioApert
            .Label1(26).Visible = True
            .txtTemp(24).Visible = True
            .Label3(24).Visible = True
            .Label1(25).Visible = True
            .txtTemp(23).Visible = True
            .Label3(23).Visible = True
            .Aggiorna()
        End With
    End Sub

    Public Function FT4() As Single
        Dim a, R, S, B As Single
        'Kern pag.144
        R = (Surr.TempLMc - xg) / (Surr.TempLTc - yv)
        S = (Surr.TempLTc - yv) / (Surr.TempLMc - yv)
        B = System.Math.Sqrt(1 + R * R)
        If System.Math.Abs(R - 1) < 0.01 Then
            a = B * S / (1 - R * S) / (1 - S)
            On Error GoTo ErrFT
            a = a / System.Math.Log((2 - S * (R + 1 - B)) / (2 - S * (R + 1 + B)))
        Else
            a = B * System.Math.Log((1 - S) / (1 - R * S))
            a = a / (R - 1)
            On Error GoTo ErrFT
            a = a / System.Math.Log((2 - S * (R + 1 - B)) / (2 - S * (R + 1 + B)))
        End If
        If a > 1 Then a = 1 'Stop
        FT4 = a
        Exit Function
ErrFT:  a = 1
        Resume Next
    End Function

    Public Function CercaTemp() As Boolean
        Select Case Config.Tipo
            Case -1 : CercaTemp = CercaTempInt()
            Case -2 : CercaTemp = CercaTempInt1()
            Case Else : CercaTemp = CercaTempInt2()
        End Select
    End Function

    Public Sub CalcolaCalori()
        Dim Dt2, Dt1, i As Single
        Dim R, k, S, l As Single
        Dim Tgas, Tvap, Tw, Dm As Single
        Dim deltat As Single
        For i = 1 To Nzone
            With Zone(i)
                Tvap = .Tvapi
                Tgas = (.Tgasi + .Tgaso) / 2
                Tw = .TWinti
                If Tw < Tvap Or Tw > Tgas Then Tw = (Tvap + Tgas) / 2
                If .interno Then
                    Dm = (Geom.ITLint + Geom.OTLint) / 2
                Else
                    Dm = (Geom.ITLout + Geom.OTLout) / 2
                End If
                l = .Lungh : If l <= 0 Then l = 1
                .Ui = u(Tvap, Tw, Tgas, Dm, l, .interno, .Rex)
                deltat = Tgas - Tvap
                .TWinti = Tvap + deltat * .Ui * (1 / hio + Rio)
                .TWexti = Tgas - deltat * .Ui * (1 / ho + Ro)
                Tvap = .Tvapo
                Tw = .Twinto
                If Tw < Tvap Or Tw > Tgas Then Tw = (Tvap + Tgas) / 2
                .Uo = u(Tvap, Tw, Tgas, Dm, l, .interno)
                deltat = Tgas - Tvap
                .Twinto = Tvap + deltat * .Uo * (1 / hio + Rio)
                .Twexto = Tgas - deltat * .Uo * (1 / ho + Ro)
                Dt1 = (.Tgaso - .Tvapi) * .Uo
                Dt2 = (.Tgasi - .Tvapo) * .Ui
                If Dt1 * Dt2 <= 0 Then
                    .LMTD = -1
                ElseIf System.Math.Abs(Dt1 / Dt2 - 1) < 0.001 Then
                    .LMTD = (Dt1 + Dt2) / 2
                Else
                    .LMTD = (Dt1 - Dt2) / System.Math.Log(Dt1 / Dt2)
                End If
                'kern pag.550
                If (.Tgasi - .Tvapi) = 0 Or (.Tgasi - .Tvapi) = 0 Then
                    .MTD = 0
                Else
                    k = (.Tgasi - .Tgaso) / (.Tgasi - .Tvapi)
                    S = (.Tvapo - .Tvapi) / (.Tgasi - .Tvapi)

                    If System.Math.Abs(k) < 0.001 Or System.Math.Abs(S) < 0.001 Then
                        .MTD = .LMTD
                    ElseIf k >= 1 Then
                        .MTD = 0
                    ElseIf (1 - S / k * System.Math.Log(1 / (1 - k))) < 0 Then
                        .MTD = .LMTD
                    Else
                        R = S / System.Math.Log(1 / (1 - S / k * System.Math.Log(1 / (1 - k))))
                        If R < 0 Then Stop
                        .MTD = R * (.Tgasi - .Tvapi) * (.Uo + .Ui) / 2
                        ' R = -S / Log(1 / (1 - S / k * Log(1 / (1 + k))))
                        ' R = R * (.Tgaso - .Tvapo) * (.Uo + .Ui) / 2
                    End If
                End If
                If .LMTD = -1 Then
                    .FT = -1
                Else
                    .FT = .MTD / .LMTD
                End If
                ' .Q = .Lungh * Atot / 2 / Geom.LungDiritta * .MTD
                .Q = .Lungh * PI * Geom.DiamExtTubi / 1000 * Geom.NumeroTubi * .MTD
                ' If .Q < 0 Then Stop
                .dp = dpgas(Tgas, Dm, Tw, l, .ugas, .interno)
            End With
        Next
    End Sub

    Public Sub Aggiusta(ByRef iErr As Short)
        Dim Goodi, Goodo As Boolean
        Dim i, j As Short
        Dim k As Short
        If Config.Nuovo Then Exit Sub
        i = 1
        Do
            If Zone(i).Tvapo < Zone(i).Tvapi Then
                If i < Nzone Then
                    For j = i + 1 To Nzone
                        If Zone(j).Tvapi > Zone(i).Tvapi Then
                            For k = i To j - 1
                                Zone(k).Tvapi = Zone(i).Tvapi + (Zone(j).Tvapi - Zone(i).Tvapi) / (j - k)
                                If k > 1 Then Zone(k - 1).Tvapo = Zone(k).Tvapi
                                If Zone(k).Tvapi > 1000 Or Zone(k).Tvapi < 0 Then iErr = 1 : Exit Sub
                            Next
                            Exit For
                        Else
                            If i < Nzone Then
                                Zone(i).Tvapo = Zone(i).Tvapi + 1
                                Zone(i + 1).Tvapi = Zone(i).Tvapo
                            Else
                                Zone(i).Tvapi = Zone(i).Tvapo - 1
                                Zone(i - 1).Tvapo = Zone(i).Tvapi
                            End If
                            Exit For
                        End If
                    Next
                Else
                    Zone(i).Tvapi = Zone(i).Tvapo - 1
                    Zone(i - 1).Tvapo = Zone(i).Tvapi
                End If
            End If
            If Zone(i).Tgaso > Zone(i).Tgasi Then
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto k. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                k = 1
                Do
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto k. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    If Success(i, -k) = 0 Then i = i + 1 : GoTo CL
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto k. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Zone(Success(i, -k + 1)).Tgasi = (Zone(Success(i, -k + 1)).Tgaso + Zone(Success(i, -k)).Tgasi) / 2 ' - Zone(Success(i, -k)).Tgaso) / 2
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto k. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    If Zone(Success(i, -k + 1)).Tgasi > 1000 Or Zone(Success(i, -k + 1)).Tgasi < 0 Then iErr = 1 : Exit Sub
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto k. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    If Zone(Success(i, -k + 1)).Tgaso > Zone(Success(i, -k + 1)).Tgasi Then Zone(Success(i, -k + 1)).Tgasi = Zone(Success(i, -k + 1)).Tgaso + 1
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto k. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Zone(Success(i, -k)).Tgaso = Zone(Success(i, -k + 1)).Tgasi
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto k. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    If Zone(Success(i, -k)).Tgaso < Zone(Success(i, -k)).Tgasi Then Exit Do
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto k. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    k = k + 1
                Loop
                i = 1
                GoTo CL
            End If
            Goodi = Zone(i).Tvapi <= Zone(i).Tgasi And Zone(i).Tvapi <= Zone(i).Tgaso
            Goodo = Zone(i).Tvapo <= Zone(i).Tgasi And Zone(i).Tvapo <= Zone(i).Tgaso
            '      With Zone(i)
            '        k = (.Tgasi - .Tgaso) / (.Tgasi - .Tvapi)
            '        S = (.Tvapo - .Tvapi) / (.Tgasi - .Tvapi)
            '        If k < 1 And k > 0 Then
            '          Goodo = S / k * Log(1 / (1 - k)) < 1
            '        End If
            '      End With
            If Not Goodi And Goodo Then
                If i = 1 Then
                    Stop
                Else
                    Zone(i).Tvapi = Zone(i).Tgaso + 0.5 * (Zone(i).Tgaso - Zone(i).Tvapo) '(Zone(i).Tvapo + Zone(i).Tgaso) / 2
                    If Zone(i).Tvapi > 1000 Or Zone(i).Tvapi < 0 Then iErr = 1 : Exit Sub
                    Zone(i - 1).Tvapo = Zone(i).Tvapi
                    i = i - 1
                End If
            ElseIf Not Goodo And Goodi Then
                If i = Nzone And Success(i, -1) > 0 Then
                    Zone(i).Tgaso = Zone(i).Tvapo + 1
                    Zone(i).Tgasi = (Zone(i).Tgaso + Zone(Success(i, -1)).Tgasi) / 2
                    If Zone(i).Tgasi > 1000 Or Zone(i).Tgasi < 0 Then iErr = 1 : Exit Sub
                    Zone(Success(i, -1)).Tgaso = Zone(i).Tgasi
                    Zone(Success(i, 1)).Tgasi = Zone(i).Tgaso
                    i = i - 1
                Else
                    If Zone(i).Tvapo > Zone(i).Tgaso And Zone(i).Tvapo > Zone(i).Tgasi And i < Nzone Then
                        Zone(i).Tvapo = Zone(i).Tgaso - 0.5 * (Zone(i).Tgaso - Zone(i).Tvapi)
                        If Zone(i).Tvapo > 1000 Or Zone(i).Tvapo < 0 Then iErr = 1 : Exit Sub
                        Zone(i + 1).Tvapi = Zone(i).Tvapo
                        If i > 1 Then i = i - 1
                    Else
                        Zone(i).Tgaso = (Zone(i).Tgasi + Zone(i).Tvapo) / 2
                        If Success(i, 1) > 0 Then Zone(Success(i, 1)).Tgasi = Zone(i).Tgaso
                    End If
                End If
            ElseIf Not Goodi And Not Goodo Then
                If Zone(i).Tvapo = Zone(i).Tvapi Then
                    Zone(i).Tvapo = Zone(i).Tvapi + 0.1
                    If i < Nzone Then Zone(i + 1).Tvapi = Zone(i).Tvapo
                End If
                Zone(i).Tgasi = Zone(i).Tvapo + 2 * (Zone(i).Tvapo - Zone(i).Tvapi) * (Surr.TempLMc - Surr.TempLMf) / (Surr.TempLTc - Surr.TempLTf)
                If Zone(i).Tgasi > 1000 Or Zone(i).Tgasi < 0 Then iErr = 1 : Exit Sub
                Zone(i).Tgaso = Zone(i).Tvapo + (Zone(i).Tvapo - Zone(i).Tvapi) * (Surr.TempLMc - Surr.TempLMf) / (Surr.TempLTc - Surr.TempLTf)
                If Zone(i).Tgaso > 1000 Or Zone(i).Tgaso < 0 Then iErr = 1 : Exit Sub
                j = SuccGas(i) ' OrdGas(i + 1)
                If j > 0 Then Zone(j).Tgasi = Zone(i).Tgaso
                j = PrecGas(i) 'OrdGas(i - 1)
                If j > 0 Then Zone(j).Tgaso = Zone(i).Tgasi
                i = 1
            Else
                i = i + 1
            End If
CL:     Loop While i <= Nzone

    End Sub

    Public Function Success(ByRef i As Short, ByRef n As Short) As Short
        If n = -1 Then
            Success = PrecGas(i)
        ElseIf n < -1 Then
            If PrecGas(i) = 0 Then
                Success = 0
            Else
                Success = Success(PrecGas(i), n + 1)
            End If
        ElseIf n = 0 Then
            Success = i
        ElseIf n = 1 Then
            Success = SuccGas(i)
        Else
            If SuccGas(i) = 0 Then
                Success = 0
            Else
                Success = Success(SuccGas(i), n - 1)
            End If
        End If
    End Function

    Public Sub Apri(Optional ByRef al As Short = -1, Optional ByRef Vecchio As Boolean = False)
        Dim ff As String = ""
        Dim ifl As Short
        Dim tt As typTuttiDati = New typTuttiDati
        If Not Schiavo And Len(Trim(Monitor.Motore.Problem.Commessa)) = 0 Then Exit Sub
        If al > -1 Then
            Altern = al
        Else
            Altern = 1
        End If
        ifl = FreeFile()
        FileOpen(ifl, FileData, OpenMode.Random, , , Len(tt))
        nAlt = LOF(ifl) \ Len(tt)
        If Altern <= nAlt Then
            Vecchio = True
            FileGet(ifl, tt, Altern)
            Config = tt.c
            Problem = tt.p
            Geom = tt.g
            DesignData = tt.d
        Else
            Vecchio = False
            FilePut(ifl, tt, Altern)
        End If
        FileClose(ifl)
        mioApert.AggAltern()
        With mioApert
            .cmbAltern.Enabled = False
            .cmbAltern.SelectedIndex = Altern - 1
            .cmbAltern.Enabled = True
        End With
        If Len(Trim(Config.DescrAlt)) = 0 Then
            Config.DescrAlt = "Nessuna descrizione"
        ElseIf Asc(Config.DescrAlt) < 32 Then
            Config.DescrAlt = "Nessuna descrizione"
        End If
        mioApert.txtDescr.Text = Config.DescrAlt
        With Monitor.Motore.Problem
            If Not Schiavo Then
                .Author = Problem.Author
                .ClientPlant = Problem.Cliente
                .Item = Problem.Item
            Else
                Problem.Author = .Author
                Problem.Item = .Item
                Problem.Cliente = .ClientPlant
            End If
        End With
        Gas.Manuale = Not Config.Autom
        Gas.Accedi(Left(FileData, Len(FileData) - 4) & Funzioni.Str2Cifre(Altern - 1) & ".PPG", ff)
        Problem.Fluido = ff
        Fase = 1
        If Not Config.Autom Then Prop.Transfer() : Prop.Inizia(False)
        If Geom.IndMatTubi > 0 Then
            MatTubi.Indmat = Geom.IndMatTubi
            MatTubi.RecupMat(Monitor.Motore.Inizio.Archdir)
        End If
        mioApert.Aggiorna()
    End Sub
    Public Sub Salva()
        Dim ifl As Short
        Dim tt As typTuttiDati = New typTuttiDati
        Try
            If Not Schiavo Then
                If Len(Trim(Monitor.Motore.Problem.Commessa)) = 0 Then Exit Sub
                With Monitor.Motore.Problem
                    Problem.Author = .Author
                    Problem.Cliente = .ClientPlant
                    Problem.Item = .Item
                End With
            End If
            ifl = FreeFile()
            FileOpen(ifl, FileData, OpenMode.Random, , , Len(tt))
            tt.c = Config
            tt.p = Problem
            tt.g = Geom
            tt.d = DesignData
            If Altern = 0 Then Altern = 1
            FilePut(ifl, tt, Altern)
            FileClose(ifl)
        Catch ex As Exception
            MessageBox.Show(ex.Message + vbCrLf + ex.StackTrace)
        End Try
    End Sub
    Public Function IniziaCalcolo(ByRef iErr As Short, ByRef Verboso As Boolean) As Boolean '17/01/01
        Dim DTm As Single
        Dim OK As Boolean
        '=============TipoCalc=1====================
        'Zona 1 gambe in ingresso
        '     Problem.Temp.Tvin As Single, yv As Single
        '     Tgout As Single, xg As Single
        'Zona 2 gambe esterne
        '     yv As Single, y As Single
        '     xg As Single, Tgasin As Single
        'Zona 3 gambe interne
        '     Tvout As Single, y As Single
        '     xg As Single, Tgasin As Single
        'Problem.Temp.Tvin = 320: Tvout = 380
        'Tgasin = 400: Tgasout = 360
        '===========================================
        If Problem.kHigh <= 0 Or Problem.kLow <= 0 Then
            MsgBox("Non è stata fornita la conducibilità del materiale del tubo", MsgBoxStyle.Critical)
            iErr = 2
            Exit Function
        End If
        IniziaCalcolo = True
        If Config.Progetto = 0 Then
            Geom.LungDiritta = 6 : Geom.LungCieca = 0
            If Config.Tipo = 2 Then Geom.LungCieca = 3 '09/12/2004
        End If
        If Config.NCross = 0 Then Config.NCross = 4
        Problem.Funz = Problem.Temp
        Select Case Config.Tipo
            Case -1, -2 : Inizia12(DTm)
            Case 2
                Select Case Config.NCross
                    Case 2
                        Select Case Config.NCrossCieco
                            Case 2 : Inizia3(DTm)
                            Case Else : IniziaCieco(DTm)
                        End Select
                    Case 4
                        Select Case Config.NCrossCieco
                            Case 4 : Inizia5(DTm)
                            Case Else : IniziaCieco(DTm)
                        End Select
                    Case Else : IniziaCieco(DTm)
                End Select
                TempInt()
                Aggiusta(iErr)
                If iErr > 0 Then Exit Function
                If Config.Progetto = 0 Then
                    Atot = Gvcv / DTm
                    Geom.LungDiritta = Atot / 2 / Geom.NumeroTubi / (PI * Geom.DiamExtTubi * 0.001)
                    CercaCieca()
                    If Critical Then iErr = 2 : Exit Function
                    CercaOttimo()
                Else
                    OK = CercaTemp()
                    If OK Then
                        With mioApert
                            .txtTemp(27).Text = Funzioni.myStr(Problem.Temp.Tgasout, 3, 2, False)
                            .txtTemp(28).Text = Funzioni.myStr(Problem.Temp.Tvout, 3, 2, False)
                            .txtTemp(29).Text = Funzioni.myStr(Problem.Funz.Tgasout, 3, 2, False)
                            .txtTemp(30).Text = Funzioni.myStr(Problem.Funz.Tvout, 3, 2, False)
                            .txtTemp(31).Text = Funzioni.myStr(System.Math.Abs(QtotFunz) / 1000, 7, 2, False)
                            .txtTemp(32).Text = Funzioni.myStr((System.Math.Abs(QtotFunz) - Problem.Watt) / Problem.Watt * 100, 4, 2, False)
                        End With
                    Else
                        If Config.Progetto = 1 And Config.Tipo = 2 Then
                        Else
                            If Verboso Then MsgBox("Soluzione non trovata")
                        End If
                        iErr = 1
                    End If
                End If
            Case 1
                Select Case Config.NCross
                    Case 4
                        If Not Inizia4(DTm) Then
                            IniziaCalcolo = False
                            iErr = 3
                            Exit Function
                        End If
                    Case Else
                        Inizia6(DTm, 2 * Config.NCross)
                End Select
                TempInt()
                Aggiusta(iErr)
                If iErr > 0 Then Exit Function
                If Config.Progetto = 0 Then
                    Atot = Gvcv / DTm
                    Geom.LungDiritta = Atot / 2 / Geom.NumeroTubi / (PI * Geom.DiamExtTubi * 0.001)
                    If CercaTemp() Then
                        With mioApert
                            .Label1(26).Visible = False
                            .txtTemp(24).Visible = False
                            .Label3(24).Visible = False
                            .Label1(25).Visible = False
                            .txtTemp(23).Visible = False
                            .Label3(23).Visible = False
                            .Aggiorna()
                        End With
                    Else
                        MsgBox("Non c'è soluzione")
                        iErr = 1
                    End If
                Else
                    OK = CercaTemp()
                    If OK Then
                        With mioApert
                            .txtTemp(27).Text = Funzioni.myStr(Problem.Temp.Tgasout, 3, 2, False)
                            .txtTemp(28).Text = Funzioni.myStr(Problem.Temp.Tvout, 3, 2, False)
                            .txtTemp(29).Text = Funzioni.myStr(Problem.Funz.Tgasout, 3, 2, False)
                            .txtTemp(30).Text = Funzioni.myStr(Problem.Funz.Tvout, 3, 2, False)
                            .txtTemp(31).Text = Funzioni.myStr(System.Math.Abs(QtotFunz) / 1000, 7, 2, False)
                            .txtTemp(32).Text = Funzioni.myStr((System.Math.Abs(QtotFunz) - Problem.Watt) / Problem.Watt * 100, 4, 2, False)
                        End With
                    Else
                        If Verboso Then MsgBox("Soluzione non trovata")
                        iErr = 1
                    End If
                End If
            Case 3 : IniziaBorsig(DTm, 2 * Config.NCross)
                TempInt()
                Aggiusta(iErr)
                If iErr > 0 Then Exit Function
                If Config.Progetto = 0 Then
                    Atot = Gvcv / DTm
                    Geom.LungDiritta = Atot / 2 / Geom.NumeroTubi / (PI * Geom.DiamExtTubi * 0.001)
                    If CercaTemp() Then
                        With mioApert
                            .Label1(26).Visible = False
                            .txtTemp(24).Visible = False
                            .Label3(24).Visible = False
                            .Label1(25).Visible = False
                            .txtTemp(23).Visible = False
                            .Label3(23).Visible = False
                            .Aggiorna()
                        End With
                    Else
                        MsgBox("Non c'è soluzione")
                        iErr = 1
                    End If
                Else
                    OK = CercaTemp()
                    If OK Then
                        With mioApert
                            .txtTemp(27).Text = Funzioni.myStr(Problem.Temp.Tgasout, 3, 2, False)
                            .txtTemp(28).Text = Funzioni.myStr(Problem.Temp.Tvout, 3, 2, False)
                            .txtTemp(29).Text = Funzioni.myStr(Problem.Funz.Tgasout, 3, 2, False)
                            .txtTemp(30).Text = Funzioni.myStr(Problem.Funz.Tvout, 3, 2, False)
                            .txtTemp(31).Text = Funzioni.myStr(System.Math.Abs(QtotFunz) / 1000, 7, 2, False)
                            .txtTemp(32).Text = Funzioni.myStr((System.Math.Abs(QtotFunz) - Problem.Watt) / Problem.Watt * 100, 4, 2, False)
                        End With
                    Else
                        If Verboso Then MsgBox("Soluzione non trovata")
                        iErr = 1
                    End If
                End If
        End Select
    End Function
    Public Sub Bilancio()
        Dim Cp1, Cp0, Excess As Single
        Dim ic As Short
        Select Case Config.VariabIndProg
            '1 portata gas 2 portata vapore 3 tgasout 4 tgasin
            Case 1
                If Problem.Qvap <= 0 Then
                    MsgBox("non è stata definita la portata del vapore.", MsgBoxStyle.Critical)
                    Exit Sub
                End If
                EntalpVap(Qtot)
                Gvcv = Qtot * Problem.Qvap
                EntalpGas(Qtot)
                Problem.Qgas = Gvcv / Qtot
                Ggcg = Gvcv
                mioApert.txtTemp(6).Text = Funzioni.myStr(Problem.Qgas, 4, 2, False)
            Case 2
                If Problem.Qgas <= 0 Then
                    MsgBox("Non è stata definita la portata dei fumi.", MsgBoxStyle.Critical)
                    Exit Sub
                End If
                EntalpGas(Qtot)
                Ggcg = Qtot * Problem.Qgas
                EntalpVap(Qtot)
                Problem.Qvap = Ggcg / Qtot
                Gvcv = Ggcg
                mioApert.txtTemp(7).Text = Funzioni.myStr(Problem.Qvap, 4, 2, False)
            Case 3
                If Problem.Qvap <= 0 Then
                    MsgBox("Non è stata definita la portata del vapore.", MsgBoxStyle.Critical)
                    Exit Sub
                End If
                EntalpVap(Qtot)
                Gvcv = Qtot * Problem.Qvap
                Problem.Temp.Tgasout = Problem.Temp.Tgasin - (Problem.Temp.Tvout - Problem.Temp.Tvin)
                Do
                    EntalpGas(Qtot)
                    Ggcg = Qtot * Problem.Qgas
                    Excess = Ggcg - Gvcv
                    Cp0 = Prop.CpGasV(Problem.Temp.Tgasin)
                    Cp1 = Prop.CpGasV(Problem.Temp.Tgasout)
                    Problem.Temp.Tgasout = Problem.Temp.Tgasout + Excess / Problem.Qgas / ((Cp0 + Cp1) / 2)
                    ic = ic + 1
                    If ic > 20 Then
                        MsgBox("Non raggiunta convergebza in Bilancio")
                        Exit Do
                    End If
                Loop While System.Math.Abs(Excess) / Gvcv > 0.0001
                mioApert.txtTemp(1).Text = Funzioni.myStr(Problem.Temp.Tgasout, 4, 2, False)
            Case 4
                If Problem.Qgas <= 0 Then
                    MsgBox("Non è stata definita la portata dei fumi.", MsgBoxStyle.Critical)
                    Exit Sub
                End If
                EntalpGas(Qtot)
                Ggcg = Qtot * Problem.Qgas
                Problem.Temp.Tvout = Problem.Temp.Tvin - (Problem.Temp.Tgasout - Problem.Temp.Tgasin)
                Do
                    EntalpVap(Qtot)
                    Gvcv = Qtot * Problem.Qvap
                    Excess = Ggcg - Gvcv
                    Cp0 = Prop.CpVapV(Problem.Temp.Tvin)
                    Cp1 = Prop.CpVapV(Problem.Temp.Tvout)
                    Problem.Temp.Tvout = Problem.Temp.Tvout + Excess / Problem.Qvap / ((Cp0 + Cp1) / 2)
                Loop While System.Math.Abs(Excess) / Gvcv > 0.0001
                mioApert.txtTemp(3).Text = Funzioni.myStr(Problem.Temp.Tvout, 4, 2, False)
        End Select
        With mioApert
            .Label1(7).Visible = True
            .txtDuty.Visible = True
            .Label3(8).Visible = True
            .txtDuty.Text = Funzioni.myStr(Gvcv / 1000, 8, 2, False)
            .Command2.Enabled = True
        End With
        Problem.Watt = Gvcv
        Exit Sub
    End Sub
    Public Sub CalcDiamInt()
        Dim Area, DiamCentrale As Single
        If Config.Progetto = 1 Then Exit Sub
        On Error GoTo ErrCNT
        Area = Surr.PortLM * Prop.VolGas((Surr.TempLMc)) / Problem.VelGasMaxCen
        DiamCentrale = System.Math.Sqrt(4 / PI * Area) * 1000
        'DiamCentrale = 620
        mioApert.txtTemp(13).Text = Str(Int(DiamCentrale + 0.5))
        CalcCieco()
ExCNT:  Exit Sub
ErrCNT:
        Resume ExCNT
    End Sub
    Public Sub CalcDintermedio()
        Dim Area, DiamIntExt As Single
        If Config.Progetto = 1 Then Exit Sub
        On Error GoTo ErrCNT
        Select Case Config.Tipo
            Case 2, 3
                Area = Surr.PortLM * Prop.VolGas((Surr.TempLMf)) / Problem.VelGasMaxCieco
                Area = 1000000.0# * Area + PI / 4 * (Geom.DiamFasciameInt + 2 * Standard.SpessCieco) ^ 2
                mioApert.txtTemp(17).Text = Str(Int(System.Math.Sqrt(4 / PI * Area) + 2 * Standard.OverOTL + 0.5))
            Case 1
                mioApert.txtTemp(17).Text = Str(Int(Geom.OTLint + 2 * Standard.Lane + 0.5))
        End Select
        CalcFasciame()
ExCNT:  Exit Sub
ErrCNT:
        Resume ExCNT
    End Sub
    Public Sub CalcFasciame()
        If Config.Progetto = 1 Then Exit Sub
        On Error GoTo ErrCNT
        Dim AreaAnul, Areola, AreaPiena As Single
        Dim CentriTubiExt, CentriTubiInt As Single
        Dim AreaGas, DiamFasciame As Single
        CentriTubiInt = Geom.ITLout + Geom.DiamExtTubi
        Select Case Geom.TipoPassoExt
            Case 0 : Areola = Geom.PassoTubiExt ^ 2 * System.Math.Sqrt(3) / 2
            Case 1 : Areola = Geom.PassoTubiExt ^ 2
        End Select
        AreaAnul = Areola * Geom.NumeroTubi
        AreaPiena = AreaAnul + PI / 4 * CentriTubiInt ^ 2
        CentriTubiExt = System.Math.Sqrt(4 / PI * AreaPiena)
        Geom.OTLout = CentriTubiExt + Geom.DiamExtTubi '+ Geom.PassoTubiExt
        mioApert.txtTemp(38).Text = Funzioni.myStr(Geom.OTLout, 4, 2, False)
        Geom.NumeroFileOut = (CentriTubiExt - CentriTubiInt) / 2 / Xl(False) / 1000
        AreaGas = Surr.PortLM * Prop.VolGas((Surr.TempLMf)) / Problem.VelGasMaxCen * 1000000.0#
        AreaPiena = AreaGas + PI / 4 * (Geom.OTLout + 2 * Standard.OverOTL) ^ 2
        DiamFasciame = System.Math.Sqrt(4 / PI * AreaPiena)
        mioApert.txtTemp(19).Text = Str(Int(DiamFasciame + 0.5))
        CalcMantello()
ExCNT:  Exit Sub
ErrCNT:
        Resume ExCNT
    End Sub
    Public Sub CalcCieco()
        Dim CentriTubiInt, CentriTubiExt As Single
        Dim Areola, AreaAnul As Single
        Dim AreaPiena, Area As Single
        Dim DiamCentrale As Single
        If Config.Progetto = 1 Then Exit Sub
        On Error GoTo ErrCNT
        If Geom.NumeroTubi = 0 Then Exit Sub
        If Geom.DiamCentrale = 0 Then Exit Sub
        If Geom.DiamExtTubi = 0 Then Exit Sub
        If Geom.PassoTubiInt <= Geom.DiamExtTubi Then
            'MsgBox "Errore: il passo dei tubi è inferiore al diametro", vbExclamation
            'Geom.OTLint = 0
            mioApert.txtTemp(37).Text = "0"
            mioApert.txtTemp(37).BackColor = System.Drawing.Color.Red
            Exit Sub
        Else
            mioApert.txtTemp(37).BackColor = System.Drawing.Color.White
        End If
        Select Case Config.Tipo
            Case 1, 2
                Geom.ITLint = Geom.DiamCentrale + 2 * Standard.OverOTL
                mioApert.txtTemp(33).Text = Funzioni.myStr(Geom.ITLint, 4, 2, False)
            Case 3
                CalcITLint()
        End Select
        CentriTubiInt = Geom.ITLint + Geom.DiamExtTubi
        Select Case Geom.TipoPassoInt
            Case 0 : Areola = Geom.PassoTubiInt ^ 2 * System.Math.Sqrt(3) / 2
            Case 1 : Areola = Geom.PassoTubiInt ^ 2
        End Select
        AreaAnul = Areola * Geom.NumeroTubi
        AreaPiena = AreaAnul + PI / 4 * CentriTubiInt ^ 2
        CentriTubiExt = System.Math.Sqrt(4 / PI * AreaPiena)
        Geom.OTLint = CentriTubiExt + Geom.DiamExtTubi ' + Geom.PassoTubiInt
        mioApert.txtTemp(37).Text = Funzioni.myStr(Geom.OTLint, 4, 2, False)
        Geom.NumeroFileInt = (CentriTubiExt - CentriTubiInt) / 2 / Xl(True) / 1000
        Select Case Config.Tipo
            Case 1, 2
                mioApert.txtTemp(15).Text = Str(Int(Geom.OTLint + 2 * Standard.OverOTL + 0.5))
            Case 3
                Area = 1000000.0# * Surr.PortLM * Prop.VolGas((Surr.TempLMc)) / Problem.VelGasMaxCen
                DiamCentrale = Int(System.Math.Sqrt((Geom.OTLint + 2 * Standard.OverOTL) ^ 2 + 4 / PI * Area) + 0.5)
                mioApert.txtTemp(15).Text = Str(DiamCentrale)
        End Select
        CalcDintermedio()
ExCNT:  Exit Sub
ErrCNT:
        'Debug.Print Err.Description
        Resume ExCNT
    End Sub
    Public Sub CalcNumTubi()
        Dim Atubo, n As Single
        If Config.Progetto = 1 Then Exit Sub
        On Error GoTo ErrCNT
        Atubo = PI / 4 * (Geom.DiamExtTubi - 2 * Geom.SpessTubi) ^ 2 * 0.000001
        n = Surr.PortLT * Prop.VolVap((Surr.TempLTc)) / Problem.VelVapMax / Atubo
        'n = 1279.5
        mioApert.txtTemp(11).Text = Str(Int(n + 0.5))
        CalcDiamInt()
ExCNT:  Exit Sub
ErrCNT:
        Resume ExCNT
    End Sub
    Public Function CheckNumTubi() As Boolean
        Dim Atubo, n As Single
        Dim testo As String
        CheckNumTubi = True
        On Error GoTo ErrCNT
        Atubo = PI / 4 * (Geom.DiamExtTubi - 2 * Geom.SpessTubi) ^ 2 * 0.000001
        n = Surr.PortLT * Prop.VolVap((Surr.TempLTf)) / Problem.VelVapMax / Atubo
        If Geom.NumeroTubi < n Then
            testo = "E' stato scelto un numero di tubi troppo basso." & vbCrLf
            testo = testo & "Il numero minimo è" & Str(Int(n + 0.99))
            MsgBox(testo, MsgBoxStyle.Information)
            CheckNumTubi = False
        End If
ExCNT:  Exit Function
ErrCNT:
        Resume ExCNT
    End Function
    Public Function CheckDiamInt() As Boolean
        Dim Area, DiamCentrale As Single
        CheckDiamInt = True
        On Error GoTo ErrCNT
        Area = Surr.PortLM * Prop.VolGas((Surr.TempLMc)) / Problem.VelGasMaxCen
        DiamCentrale = System.Math.Sqrt(4 / PI * Area) * 1000
        If Geom.DiamCentrale < DiamCentrale - 1 And Config.Progetto = 0 Then
            MsgBox("E' stato scelto un diametro del foro centrale troppo basso", MsgBoxStyle.Information)
            CheckDiamInt = False
        End If
ExCNT:  Exit Function
ErrCNT:
        Resume ExCNT
    End Function

    Public Function ValidaFase() As Boolean
        Dim OK As Boolean
        OK = True
        Select Case Fase
            Case 1
            Case 3
                OK = CheckNumTubi()
                OK = OK And CheckDiamInt()
        End Select
        ValidaFase = OK
    End Function

    Public Function hvap(ByRef Tvap As Single, ByRef Tw As Single, Optional ByRef p As Single = 0) As Single
        Dim Visco, k, Cp, rho As Single
        Dim Re, u, Area, Pr As Single
        Dim Nu, fih, Di As Single
        Di = (Geom.DiamExtTubi - 2 * Geom.SpessTubi) / 1000
        If p = 0 Then
            k = Prop.kVap(Tvap)
            Cp = Prop.CpVap(Tvap)
            Visco = Prop.ViscoVap(Tvap)
            If k = 0 Or Cp = 0 Or Visco = 0 Then
                MsgBox("Non è Non è possibile calcolare le proprietà termodinamiche del vapor d'acqua.", MsgBoxStyle.Critical)
                Exit Function
            End If
            rho = 1 / Prop.VolVap(Tvap)
        Else
            Stop
        End If
        Area = PI / 4 * Di ^ 2
        u = Surr.PortLT / Geom.NumeroTubi / rho / Area
        Re = rho * u * Di / Visco
        Pr = Cp * Visco / k
        fih = System.Math.Sqrt((Tvap + 273) / (Tw + 273))
        Nu = 0.025 * Re ^ 0.79 * Pr ^ 0.42 * fih
        hvap = Nu * k / Di
    End Function

    Public Function Sx(ByRef Dm As Single, ByRef l As Single, ByRef interno As Boolean) As Single
        Dim Stri, Pt, d, Squa As Single
        Dim Smt60, Smt30, Smt90, Smt45 As Single
        Dim Xt60, Xt30, Xt90, Xt45 As Single
        If interno Then Pt = Geom.PassoTubiInt / 1000 Else Pt = Geom.PassoTubiExt / 1000
        d = Geom.DiamExtTubi / 1000
        Smt30 = (Pt - d)
        Xt30 = Pt
        Smt90 = (Pt - d)
        Xt90 = Pt
        Smt60 = (Pt - d)
        Xt60 = 0.866 * Pt
        If Pt / d < 1.7 Then
            Smt45 = Pt - d
            Xt45 = 0.707 * Pt
        Else
            Smt45 = 1.414 * Pt - d
            Xt45 = 1.414 * Pt
        End If
        Stri = PI * Dm / 1000 * l * (Smt30 / Xt30 + Smt60 / Xt60) / 2
        Squa = PI * Dm / 1000 * l * (Smt90 / Xt90 + Smt45 / Xt45) / 2
        If interno Then
            Select Case Geom.TipoPassoInt
                Case 0 : Sx = Stri
                Case 1 : Sx = Squa
            End Select
        Else
            Select Case Geom.TipoPassoExt
                Case 0 : Sx = Stri
                Case 1 : Sx = Squa
            End Select
        End If
    End Function
    Public Function Xl(ByRef interno As Boolean) As Single
        Dim Stri, Pt, Squa As Single
        Dim Xl60, Xl30, Xl90, Xl45 As Single
        If interno Then Pt = Geom.PassoTubiInt / 1000 Else Pt = Geom.PassoTubiExt / 1000
        Xl30 = 0.866 * Pt
        Xl90 = Pt
        Xl60 = 0.5 * Pt
        Xl45 = 0.707 * Pt
        Stri = (Xl30 + Xl60) / 2
        Squa = (Xl90 + Xl45) / 2
        If interno Then
            Select Case Geom.TipoPassoInt
                Case 0 : Xl = Stri
                Case 1 : Xl = Squa
            End Select
        Else
            Select Case Geom.TipoPassoExt
                Case 0 : Xl = Stri
                Case 1 : Xl = Squa
            End Select
        End If
    End Function
    Public Function hgas(ByRef Tgas As Single, ByRef Dm As Single, ByRef l As Single, ByRef interno As Boolean, ByRef Re As Single, Optional ByRef p As Single = 0) As Single
        Dim Visco, k, Cp, rho As Single
        Dim Gx, Pr As Single
        Dim d, Nu, Ntr As Single
        'HTRI B3.2-28
        On Error GoTo Errh
        If p = 0 Then
            k = Prop.kGas(Tgas)
            Cp = Prop.CpGas(Tgas)
            Visco = Prop.ViscoGas(Tgas)
            rho = 1 / Prop.VolGas(Tgas)
        Else
            Stop
        End If
        d = Geom.DiamExtTubi / 1000
        Gx = Surr.PortLM / Sx(Dm, l, interno)
        Re = Gx * d / Visco
        'If Re < 4000 Then Stop
        Pr = Cp * Visco / k
        Geom.NumeroFileInt = ((Geom.OTLint - Geom.DiamExtTubi) - (Geom.ITLint + Geom.DiamExtTubi)) / 2 / Xl(True) / 1000
        Geom.NumeroFileOut = ((Geom.OTLout - Geom.DiamExtTubi) - (Geom.ITLout + Geom.DiamExtTubi)) / 2 / Xl(True) / 1000
        'Geom.NumeroFileOut = ((Geom.OTLout - Geom.DiamExtTubi) - (Geom.ITLout + Geom.DiamExtTubi)) / 2 / Xl(True) / 1000
        If interno Then Ntr = Geom.NumeroFileInt Else Ntr = Geom.NumeroFileOut
        If Ntr = 0 Then
            MsgBox("Non è definito il numero di file", MsgBoxStyle.Critical)
            Exit Function
        End If
        Nu = 0.38 * Re ^ 0.6 * Pr ^ 0.33 * (1.073 - 0.744 / Ntr + 0.351 / Ntr ^ 3)
        hgas = Nu * k / d
Exh:    Exit Function
Errh:   hgas = 0
        Resume Exh
    End Function
    Public Function dpgas(ByRef Tgas As Single, ByRef Dm As Single, ByRef Tw As Single, ByRef l As Single, ByRef ugas As Single, ByRef interno As Boolean, Optional ByRef p As Single = 0) As Single
        Dim rho, Visco, Viscow As Single
        Dim Gx, Re, miwm As Single
        Dim Ntr, d, friction As Single
        If p = 0 Then
            Visco = Prop.ViscoGas(Tgas)
            Viscow = Prop.ViscoGas(Tw)
            rho = 1 / Prop.VolGas(Tgas)
        Else
            Stop
        End If
        d = Geom.DiamExtTubi / 1000
        Gx = Surr.PortLM / Sx(Dm, l, interno)
        ugas = Gx / rho
        Re = Gx * d / Visco
        'If Re < 4000 Then Stop
        If interno Then Ntr = Geom.NumeroFileInt Else Ntr = Geom.NumeroFileOut
        friction = fis(Re, interno)
        miwm = Viscow / Visco
        If miwm < 100 Then
            friction = friction * miwm ^ 0.167
        Else
            friction = friction * 0.682 * miwm ^ 0.25
        End If
        dpgas = 4 * friction * Ntr * Gx ^ 2 / 2 / rho
    End Function
    Public Function u(ByRef Tvap As Single, ByRef Tw As Single, ByRef Tgas As Single, ByRef Dm As Single, ByRef l As Single, ByRef interno As Boolean, Optional ByRef Rex As Single = 0, Optional ByRef pvap As Single = 0, Optional ByRef pgas As Single = 0) As Single
        Dim hi, UnosuU As Single
        Dim k As Single
        k = Problem.kHigh + (Problem.kHigh - Problem.kLow) * (Tw - Surr.TempLMc) / (Surr.TempLMc - Surr.TempLTc)
        hi = hvap(Tvap, Tw, pvap)
        If hi = 0 Then Exit Function
        ho = hgas(Tgas, Dm, l, interno, Rex, pgas)
        hio = hi / Geom.DiamExtTubi * (Geom.DiamExtTubi - 2 * Geom.SpessTubi)
        Ro = Problem.Routside
        Rio = Problem.Rinside * Geom.DiamExtTubi / (Geom.DiamExtTubi - 2 * Geom.SpessTubi)
        sk = Geom.SpessTubi * 0.001 / k * Geom.DiamExtTubi / (Geom.DiamExtTubi - Geom.SpessTubi)
        If (hio <= 0 Or ho <= 0) Then
            u = 0
            Exit Function
        End If
        UnosuU = 1 / hio + 1 / ho + Rio + Ro + sk
        u = 1 / UnosuU
    End Function

    Public Sub CoeffCorISA()
        Dim T1p As Single 'TariaIn
        Dim T2p As Single 'Tariaout
        Dim T1s As Single 'acqua in
        Dim T2s As Single 'acqua out
        Dim U2, U1, U3 As Single
        Dim x, Z As Single
        T1p = 20 : T1s = 100
        '      U1 = (RZ(5, I) - DGZ(2, I)) / (RZ(5, I) - RZ(103, I))
        'c       TacqIn   TacqOut     TacqIn    Taria in
        FileOpen(1, "C:\FACTOR", OpenMode.Output)
        For T2p = 25 To 95 Step 10
            For T2s = 25 To 95 Step 10
                U1 = (T1s - T2s) / (T1s - T1p) 'X=U1
                '      U2 = (RZ(104, I) - RZ(103, I)) / (RZ(5, I) - RZ(103, I))
                'c         Tariaout   Tariain       TacqIn  Tariain
                U2 = (T2p - T1p) / (T1s - T1p) 'Z=U2/U1
                U3 = U1 + U2
                U1 = U1 * U2
                U2 = 7.1674 * U1 ^ 3 - 6.4055 * U3 * U1 ^ 2 + 5.2187 * U1 ^ 2 - 0.070267 * U3 * U1 - 0.42592 * U1 + 1
                'c===============Fattore di correzione dell'LMTD
                '      RZ(96,I)=U2**(1./RZ(56,I))
                x = (T2s - T1s) / (T1p - T1s)
                Z = (T1p - T2p) / (T2s - T1s)
                PrintLine(1, "Temper", T2p, T2s)
                PrintLine(1, "U2=" & U2 & "SQR" & System.Math.Sqrt(U2) & "X=" & x & "Z=" & Z)
            Next T2s
        Next T2p
        FileClose(1)
        FileOpen(1, "C:\FACTOR1", OpenMode.Output)
        For Z = 0.2 To 4 Step 0.4
            For x = 0 To 1 Step 0.2
                U1 = x
                U2 = Z * x
                U3 = U1 + U2
                U1 = U1 * U2
                U2 = 7.1674 * U1 ^ 3 - 6.4055 * U3 * U1 ^ 2 + 5.2187 * U1 ^ 2 - 0.070267 * U3 * U1 - 0.42592 * U1 + 1
                PrintLine(1, Z, x, U2) 'Sqr(U2)
            Next
        Next
        FileClose(1)

    End Sub

    Public Function f(ByRef Re As Single, ByRef Tvap As Single, ByRef Tw As Single) As Single
        Dim bf, af, cf As Single
        Dim fip, fis As Single
        If Problem.Smooth Then
            af = 0.0014
            bf = 0.125
            cf = -0.32
        Else
            af = 0.0035
            bf = 0.264
            cf = -0.42
        End If
        fis = af + bf * Re ^ cf
        fip = (Prop.ViscoVap(Tw) / Prop.ViscoVap(Tvap)) ^ 0.14
        f = fis * fip
    End Function
    Private Function fis(ByRef Rex As Single, ByRef interno As Boolean) As Single
        Dim fis1, PsuD, fis2 As Single
        If interno Then
            PsuD = Geom.PassoTubiInt / Geom.DiamExtTubi
            Select Case Geom.TipoPassoInt
                Case 0
                    Call fff0(Rex, PsuD, fis1, fis2)
                Case 1
                    Call fff1(Rex, PsuD, fis1, fis2)
            End Select
        Else
            PsuD = Geom.PassoTubiExt / Geom.DiamExtTubi
            Select Case Geom.TipoPassoExt
                Case 0
                    Call fff0(Rex, PsuD, fis1, fis2)
                Case 1
                    Call fff1(Rex, PsuD, fis1, fis2)
            End Select
        End If
        fis = (fis1 + fis2) / 2
    End Function
    Private Sub fff1(ByVal Rex As Single, ByVal PsuD As Single, ByRef fis1 As Single, ByRef fis2 As Single)
        Dim Cx, C3, C1, C2, C4 As Single
        Const45(Rex, C1, C2, C3, C4)
        Cx = C1 / (1 + 0.14 * Rex ^ C2)
        fis1 = C3 * (PsuD / 1.33) ^ -Cx * Rex ^ C4
        Const90(Rex, C1, C2, C3, C4)
        Cx = C1 / (1 + 0.14 * Rex ^ C2)
        fis2 = C3 * (PsuD / 1.33) ^ -Cx * Rex ^ C4
    End Sub
    Private Sub fff0(ByVal Rex As Single, ByVal PsuD As Single, ByRef fis1 As Single, ByRef fis2 As Single)
        Dim Cx, C3, C1, C2, C4 As Single
        Const30(Rex, C1, C2, C3, C4)
        Cx = C1 / (1 + 0.14 * Rex ^ C2)
        fis1 = C3 * (PsuD / 1.33) ^ -Cx * Rex ^ C4
        Const60(Rex, C1, C2, C3, C4)
        Cx = C1 / (1 + 0.14 * Rex ^ C2)
        fis2 = C3 * (PsuD / 1.33) ^ -Cx * Rex ^ C4
    End Sub
    Public Sub DropVap()
        Dim Densin, l, Densout As Single
        Dim Twall, friction As Single
        Dim Tvapm, Re, Densm As Single
        Dim Di, Area, u, Visco As Single
        Dim Uout, Drop, Uin, Um As Single
        l = 2 * Geom.LungDiritta + PI / 2 * (Geom.OTLint + Geom.ITLout) / 1000 / 2
        Densin = 1 / Prop.VolVap((Surr.TempLTf))
        Densout = 1 / Prop.VolVap((Surr.TempLTc))
        Densm = (Densin + Densout) / 2
        Tvapm = (Surr.TempLTc + Surr.TempLTf) / 2
        Twall = (Surr.TempLMc + Surr.TempLMf + Surr.TempLTf + Surr.TempLTc) / 4
        Di = (Geom.DiamExtTubi - 2 * Geom.SpessTubi) / 1000
        Area = PI / 4 * Di ^ 2
        u = Surr.PortLT / Area / Densm / Geom.NumeroTubi
        Visco = Prop.ViscoVap(Tvapm)
        Re = Densm * u * Di / Visco
        friction = f(Re, Tvapm, Twall)
        Drop = 4 * friction * l / Di * Densm * u * u / 2
        Uin = Surr.PortLT / Area / Densin / Geom.NumeroTubi
        Drop = Drop + 0.5 * Densin * Uin * Uin / 2
        Uout = Surr.PortLT / Area / Densout / Geom.NumeroTubi
        Drop = Drop + Densout * Uout * Uout / 2
        Um = Surr.PortLT / Area / Densm / Geom.NumeroTubi
        Di = Geom.SteamInlet / 1000
        If Di = 0 Then ErroreGenerale = True : Exit Sub
        Area = PI / 4 * Di ^ 2
        u = Surr.PortLT / Area / Densin
        Drop = Drop + 0.5 * u * u / 2 * Densin
        Di = Geom.SteamOutlet / 1000
        Area = PI / 4 * Di ^ 2
        u = Surr.PortLT / Area / Densout
        Drop = Drop + u * u / 2 * Densout
        Drop = Drop + (Densout * Uout * Uout - Densin * Uin * Uin) / 2 'perdite di accelerazione
        Drop = Drop + 0.25 / 2 * Densm * Um * Um 'perdite per cambio direzione
        mioApert.txtTemp(25).Text = Funzioni.myStr(Drop / 100, 4, 2, False)
    End Sub
    Public Sub ConstA(ByRef i As Short, ByRef Rex As Single, ByRef C1 As Single, ByRef C2 As Single, ByRef C3 As Single, ByRef C4 As Single)
        Select Case i
            Case 1 : Const30(Rex, C1, C2, C3, C4)
            Case 2 : Const45(Rex, C1, C2, C3, C4)
            Case 3 : Const60(Rex, C1, C2, C3, C4)
            Case 4 : Const90(Rex, C1, C2, C3, C4)
            Case Else : Stop
        End Select
    End Sub
    Private Sub Const90(ByRef Rex As Single, ByRef C1 As Single, ByRef C2 As Single, ByRef C3 As Single, ByRef C4 As Single)
        C1 = 6.3 : C2 = 0.378
        Select Case Rex
            Case Is > 100000.0#
                C3 = 0.695 : C4 = -0.198
            Case Is > 10000.0#
                C3 = 0.391 : C4 = -0.148
            Case Is > 1000
                C3 = 0.0815 : C4 = -0.022
            Case Is > 100
                C3 = 6.09 : C4 = -0.602
            Case Is > 10
                C3 = 32.1 : C4 = -0.963
            Case Else
                C3 = 35.0# : C4 = -1
        End Select
    End Sub
    Private Sub Const60(ByRef Rex As Single, ByRef C1 As Single, ByRef C2 As Single, ByRef C3 As Single, ByRef C4 As Single)
        C1 = 12 : C2 = 0.58
        Select Case Rex
            Case Is > 100000.0#
                C3 = 0.189 : C4 = -0.089
            Case Is > 10000.0#
                C3 = 0.189 : C4 = -0.089
            Case Is > 1000
                C3 = 0.189 : C4 = -0.089
            Case Is > 100
                C3 = 2.585 : C4 = -0.468
            Case Is > 10
                C3 = 19.18 : C4 = -0.903
            Case Else
                C3 = 24.0# : C4 = -1
        End Select
    End Sub
    Private Sub Const45(ByRef Rex As Single, ByRef C1 As Single, ByRef C2 As Single, ByRef C3 As Single, ByRef C4 As Single)
        C1 = 6.59 : C2 = 0.52
        Select Case Rex
            Case Is > 100000.0#
                C3 = 0.449 : C4 = -0.16
            Case Is > 10000.0#
                C3 = 0.303 : C4 = -0.126
            Case Is > 1000
                C3 = 0.333 : C4 = -0.136
            Case Is > 100
                C3 = 3.5 : C4 = -0.476
            Case Is > 10
                C3 = 26.2 : C4 = -0.913
            Case Else
                C3 = 32.0# : C4 = -1
        End Select
    End Sub
    Private Sub Const30(ByRef Rex As Single, ByRef C1 As Single, ByRef C2 As Single, ByRef C3 As Single, ByRef C4 As Single)
        C1 = 7 : C2 = 0.5
        Select Case Rex
            Case Is > 100000.0#
                C3 = 0.197 : C4 = -0.068
            Case Is > 10000.0#
                C3 = 0.372 : C4 = -0.123
            Case Is > 1000
                C3 = 0.486 : C4 = -0.152
            Case Is > 100
                C3 = 4.57 : C4 = -0.476
            Case Is > 10
                C3 = 45.1 : C4 = -0.973
            Case Else
                C3 = 48.0# : C4 = -1
        End Select
    End Sub

    Public Sub DropGas()
        Dim dp, Area As Single
        Dim i, j As Short
        Dim internoS, interno As Boolean
        Dim rhoin, AreaExt, AreaIn, rhoout As Single
        Dim AreaExtInt, AreaIntInt, AreaIntExt, AreaExtExt As Single
        Dim AreaCieco, ugasin, ugasout, Rhom As Single
        AreaIn = PI / 4 * Geom.DiamCentrale ^ 2 * 0.000001
        AreaExt = PI / 4 * (Geom.DiamFasciameExt ^ 2 - Geom.OTLout ^ 2) * 0.000001
        If Config.Tipo = 3 Then
            DropTubo(dp)
            AreaIntInt = PI / 4 * ((Geom.ITLint - 2 * Standard.OverOTL) ^ 2 - (Geom.DiamCentrale + 2 * Standard.SpessTuboCentrale) ^ 2) / 1000000.0#
            AreaIntExt = PI / 4 * (Geom.DiamFasciameInt ^ 2 - (Geom.OTLint + 2 * Standard.OverOTL) ^ 2) / 1000000.0#
            AreaExtInt = PI / 4 * ((Geom.ITLout - 2 * Standard.OverOTL) ^ 2 - (Geom.DiamFasciameInt + 2 * Standard.SpessTuboCentrale) ^ 2) / 1000000.0#
            AreaExtExt = PI / 4 * (Geom.DiamFasciameExt ^ 2 - (Geom.OTLout + 2 * Standard.OverOTL) ^ 2) / 1000000.0#
        Else
            rhoin = 1 / Prop.VolGas((Surr.TempLMc))
            ugasin = Surr.PortLM / rhoin / AreaIn
            dp = 0.5 * rhoin * ugasin ^ 2 / 2
        End If
        AreaCieco = PI / 4 * ((Geom.ITLout - 2 * Standard.OverOTL) ^ 2 - (Geom.DiamFasciameInt + 2 * Standard.SpessTuboCentrale) ^ 2) / 1000000.0#
        For i = 1 To Nzone
            rhoin = 1 / Prop.VolGas(Zone(i).Tgasi)
            rhoout = 1 / Prop.VolGas(Zone(i).Tgaso)
            Rhom = (rhoin + rhoout) / 2
            j = Success(i, 1)
            If j > 0 Then internoS = Zone(j).interno Else internoS = False
            interno = Zone(i).interno
            dp = dp + Zone(i).dp
            Select Case Config.Tipo
                Case 1
                    If Not interno And internoS Then
                        ugasin = Surr.PortLM / rhoin / AreaExt
                        dp = dp + rhoin * ugasin ^ 2 / 2
                        dp = dp + rhoout * Zone(i).ugas ^ 2 / 2
                    ElseIf interno And internoS Then
                        ugasout = Surr.PortLM / rhoout / AreaIn
                        dp = dp + rhoout * ugasout ^ 2 / 2
                        dp = dp + rhoin * Zone(i).ugas ^ 2 / 2
                    ElseIf interno And Not internoS Then
                        ugasin = Surr.PortLM / rhoin / AreaIn
                        dp = dp + rhoout * ugasin ^ 2 / 2
                        dp = dp + rhoin * Zone(i).ugas ^ 2 / 2
                    ElseIf Not interno And Not internoS Then
                        ugasout = Surr.PortLM / rhoout / AreaExt
                        dp = dp + rhoout * ugasout ^ 2 / 2
                        dp = dp + rhoin * Zone(i).ugas ^ 2 / 2
                    End If
                Case 2
                    If i <= Config.NCrossCieco Then
                        If i Mod 2 = 1 Then
                            ugasin = Surr.PortLM / rhoin / AreaCieco
                            ugasout = Surr.PortLM / rhoout / AreaExt
                        Else
                            ugasin = Surr.PortLM / rhoin / AreaExt
                            ugasout = Surr.PortLM / rhoout / AreaCieco
                        End If
                        dp = dp + rhoin * ugasin ^ 2 / 2
                        dp = dp + rhoout * ugasout ^ 2 / 2
                        dp = dp + rhoin * Zone(i).ugas ^ 2 / 2
                    ElseIf Not interno And internoS Then
                        ugasin = Surr.PortLM / rhoin / AreaExt
                        dp = dp + rhoin * ugasin ^ 2 / 2
                        dp = dp + rhoin * Zone(i).ugas ^ 2 / 2
                    ElseIf interno And internoS Then
                        ugasout = Surr.PortLM / rhoout / AreaIn
                        dp = dp + rhoout * ugasout ^ 2 / 2
                        dp = dp + rhoout * Zone(i).ugas ^ 2 / 2
                    ElseIf interno And Not internoS Then
                        ugasin = Surr.PortLM / rhoin / AreaIn
                        dp = dp + rhoin * ugasin ^ 2 / 2
                        dp = dp + rhoout * Zone(i).ugas ^ 2 / 2
                    ElseIf Not interno And Not internoS Then
                        ugasout = Surr.PortLM / rhoout / AreaExt
                        dp = dp + rhoout * ugasout ^ 2 / 2
                        dp = dp + rhoin * Zone(i).ugas ^ 2 / 2
                    End If
                Case 3
                    If Not interno Then
                        If i Mod 2 = 1 Then
                            ugasin = Surr.PortLM / rhoin / AreaExtInt
                            ugasout = Surr.PortLM / rhoout / AreaExtExt
                        Else
                            ugasin = Surr.PortLM / rhoin / AreaExtExt
                            ugasout = Surr.PortLM / rhoout / AreaExtInt
                        End If
                        dp = dp + rhoin * ugasin ^ 2 / 2
                        dp = dp + rhoout * ugasout ^ 2 / 2
                        dp = dp + rhoin * Zone(i).ugas ^ 2 / 2
                    Else
                        If i Mod 2 = 1 Then
                            ugasin = Surr.PortLM / rhoin / AreaIntInt
                            ugasout = Surr.PortLM / rhoout / AreaIntExt
                        Else
                            ugasin = Surr.PortLM / rhoin / AreaIntExt
                            ugasout = Surr.PortLM / rhoout / AreaIntInt
                        End If
                        dp = dp + rhoin * ugasin ^ 2 / 2
                        dp = dp + rhoout * ugasout ^ 2 / 2
                        dp = dp + rhoout * Zone(i).ugas ^ 2 / 2
                    End If
            End Select
        Next
        DropAnulus(dp)
        If Geom.GasOutlet = 0 Then
            MsgBox("Non è stato fornito diametro del bocchello uscita gas per il calcolo delle perdite di carico", MsgBoxStyle.Critical)
            mioApert.txtTemp(26).Text = "?"
            Exit Sub
        End If
        'Di = (Geom.GasOutlet - Geom.FiValv) / 1000
        Area = PI / 4 * (Geom.GasOutlet ^ 2 - Geom.FiValv ^ 2) / 1000000.0#
        dp = dp + (Surr.PortLM / rhoout / Area) ^ 2 / 2 * rhoout
        mioApert.txtTemp(26).Text = Funzioni.myStr(dp / 100, 4, 2, False)
        dpgastot = dp '/ 100000#
    End Sub
    Public Sub ScriviRapporto()
        Dim Stub As StubW2000.clsSW2000
        Dim FileSt, LogoFile As String
        Dim i As Short
        Dim FilePic As String = ""
        Dim n, iErr As Short
        Dim Fil0, Fil1 As String
        Dim testo As String
        Dim j As Short
        Dim dt, T0, T1, p As Single
        If Config.Progetto = 1 And Nzone = 0 Then mioApert.Calcola_Click(Nothing, New System.EventArgs()) '17/01/01
        FileSt = Monitor.Motore.Inizio.Archdir & "\SURR01.DOC"
        Stub = New StubW2000.clsSW2000
        Stub.SuperStampa(FileSt, Monitor.Motore.Inizio.VersOffice) ' Doc
        FileSt = Left(FileData, Len(FileData) - 4) & Funzioni.Str2Cifre(Altern - 1) & "STD.DOC"
        On Error GoTo ErrCD
        Stub.sSaveAs(FileSt)
        LogoFile = Monitor.Motore.Inizio.Archdir & "\" & Monitor.Motore.Inizio.ReadIniFile("", "Azienda", "Logo")
        Stub.IntestLogo(LogoFile)
        On Error GoTo 0
        Select Case Config.Tipo
            Case 1 : FilePic = Monitor.Motore.Inizio.Archdir & "\STDSUR1.BMP"
            Case 2 : FilePic = Monitor.Motore.Inizio.Archdir & "\STDSUR2.BMP"
            Case 3 : FilePic = Monitor.Motore.Inizio.Archdir & "\STDSUR3.BMP"
        End Select
        Stub.Logo(FilePic, "\StartOfDoc")
        Stub.VaiInizio("TabSin", , True)
        With Stub 'Selection
            n = Config.NCross
            If Config.Tipo = 2 Then n = n + Config.NCrossCieco
            .sTypeText(Str(n))
            .sTypeText(Funzioni.myStr(Geom.ITLint, 4, 2, False))
            .sTypeText(Funzioni.myStr(Geom.ITLout, 4, 2, False))
            If Config.Tipo <> 2 Then
                .sTypeText("N.A.")
            Else
                .sTypeText(Funzioni.myStr(Geom.DiamFasciameInt, 4, 2, False))
            End If
            .sTypeText(Funzioni.myStr(Geom.DiamFasciameExt, 4, 2, False))
            If Config.Tipo <> 3 Then
                .sTypeText("N.A.")
            Else
                .sTypeText(Funzioni.myStr(Geom.DiamCentrale, 4, 2, False))
            End If
        End With
        Stub.VaiInizio("TabDes", , True)
        With Stub 'Selection
            If Config.Tipo <> 2 Then
                .sTypeText("N.A.")
            Else
                .sTypeText(Str(Config.NCrossCieco))
            End If
            .sTypeText(Funzioni.myStr(Geom.OTLint, 4, 2, False))
            .sTypeText(Funzioni.myStr(Geom.OTLout, 4, 2, False))
            If Config.Tipo <> 3 Then
                .sTypeText("N.A.")
            Else
                .sTypeText(Funzioni.myStr(Geom.DiamFasciameInt, 4, 2, False))
            End If
            .sTypeText(Funzioni.myStr(Geom.DiamMantello, 4, 2, False))
        End With
        Stub.VaiInizio("mbar", , True)
        With Stub 'Selection
            .SurrCopia(Nzone)
            If Config.Progetto = 1 Then
                .sBreak()
                .sOpen(Monitor.Motore.Inizio.Archdir & "\SURR02.doc", True, 1)
                .VaiInizio("\StartOfDoc", 1)
                .Copia(1)
                .sClose(, 1)
                .VaiInizio("\EndOfDoc")
                .sPaste1()
            End If
        End With
        If Config.Progetto = 1 Then
            Stub.VaiInizio("mbar1", , True)
            With Stub 'Selection
                .SurrCopia(Nzone)
            End With
        End If
        '----------------
        For j = 1 To Config.Progetto + 1 '17/01/01
            If j = 1 Then '17/01/01
                If Config.Progetto = 1 Then mioApert.Calcola_Click(Nothing, New System.EventArgs())
                Stub.VaiInizio("mbar", , True)
            Else '17/01/01
                If Config.Progetto = 1 Then mioApert.Command4_Click(Nothing, New System.EventArgs())
                Stub.VaiInizio("mbar1", , True)
            End If '17/01/01
            With Stub 'Selection
                For i = 1 To Nzone
                    .sMoveRight(, 2)
                    .sTypeText(Funzioni.myStr(Zone(i).Tgasi, 4, 2, False), True)
                    .sMoveRight()
                    .sTypeText(Funzioni.myStr(Zone(i).Twexto, 4, 2, False), True)
                    .sMoveRight(, 2)
                    .sTypeText(Str(i), True)
                    .sMoveRight()
                    .sTypeText(Funzioni.myStr(Zone(i).Tvapi, 4, 2, False), True)
                    .sMoveRight()
                    .sTypeText(Funzioni.myStr(Zone(i).Tvapo, 4, 2, False), True)
                    .sMoveRight()
                    .sTypeText(Funzioni.myStr(Zone(i).LMTD / (Zone(i).Ui + Zone(i).Uo) * 2, 4, 2, False), True)
                    .sMoveRight()
                    .sTypeText(Funzioni.myStr(Zone(i).MTD / (Zone(i).Ui + Zone(i).Uo) * 2, 4, 2, False), True)
                    .sMoveRight()
                    .sTypeText(Funzioni.myStr(Zone(i).FT, 1, 3, False), True)
                    .sMoveRight()
                    .sTypeText(Funzioni.myStr(Zone(i).Q / 1000, 5, 1, False), True)
                    .sMoveRight()
                    .sTypeText(Funzioni.myStr(Zone(i).Rex, 8, 1, False), True)
                    .sMoveRight()
                    .sTypeText(Funzioni.myStr(Zone(i).dp / 100, 4, 2, False), True)
                    .sMoveRight(, 2)
                    .sTypeText(Funzioni.myStr(Zone(i).Tgaso, 4, 2, False), True)
                    .sMoveRight()
                    .sTypeText(Funzioni.myStr(Zone(i).TWexti, 4, 2, False), True)
                    .SurrFormat()
                Next
            End With
        Next j
        Fil0 = Left(FileData, Len(FileData) - 4) & "PIC0.WMF" '17/01/01
        Fil1 = Left(FileData, Len(FileData) - 4) & "PIC1.WMF" '17/01/01
        If IO.File.Exists(Fil0) Or IO.File.Exists(Fil1) Then
            Stub.VaiInizio("\EndOfDoc", , True)
            With Stub 'Selection
                .sInsertBreak()
                mioApert.cmdReg_Click(Nothing, New System.EventArgs()) '17/01/01
                'UPGRADE_WARNING: Dir ha un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
                If IO.File.Exists(Fil0) Then
                    .Logo(Fil0, "\EndOfDoc")
                    .VaiInizio("\EndOfDoc", , True)
                    '--------------------------------17/01/01
                    .sOpen(Monitor.Motore.Inizio.Archdir & "\TabSR.doc", True, 1)
                    .VaiInizio("\StartOfDoc", 1, True)
                    .Copia(1)
                    .sClose(, 1)
                    .VaiInizio("\EndOfDoc")
                    .sTypeParagraph()
                    .sPaste1()
                    .sCollapse(Word.WdCollapseDirection.wdCollapseEnd)
                    .sMoveUp(Unit:=Word.WdUnits.wdLine, Count:=6)
                    .sMoveRight(Unit:=Word.WdUnits.wdCharacter, Count:=1)
                    For i = 10 To 1 Step -1
                        .sTypeText(Str(Reg(0).Bypass(i)), True)
                        .sMoveRight()
                    Next
                    .sMoveRight(Word.WdUnits.wdCell, 2)
                    For i = 10 To 1 Step -1
                        If Reg(0).Tvap(i) > 0 Then .sTypeText(Trim(Funzioni.myStr(Reg(0).Tvap(i), 4, 1, False)), True)
                        .sMoveRight()
                    Next
                    .sMoveRight(Word.WdUnits.wdCell, 2)
                    For i = 10 To 1 Step -1
                        If Reg(0).Tgprima(i) > 0 Then .sTypeText(Trim(Funzioni.myStr(Reg(0).Tgprima(i), 4, 1, False)), True)
                        .sMoveRight()
                    Next
                    .sMoveRight(Word.WdUnits.wdCell, 2)
                    For i = 10 To 1 Step -1
                        If Reg(0).Tgdopo(i) > 0 Then .sTypeText(Trim(Funzioni.myStr(Reg(0).Tgdopo(i), 4, 1, False)), True)
                        .sMoveRight()
                    Next
                    .sMoveRight(Word.WdUnits.wdCell, 2)
                    For i = 10 To 1 Step -1
                        .sTypeText(Trim(Funzioni.myStr(Reg(0).Angolo(i), 3, 1, False)), True)
                        .sMoveRight()
                    Next
                    .sMoveRight(Word.WdUnits.wdCharacter, 1)
                    '-------------------------------
                End If
                .sCollapse(Word.WdCollapseDirection.wdCollapseEnd)
                .sTypeParagraph()
                mioApert.cmdReg_Click(Nothing, New System.EventArgs()) '17/01/01
                If IO.File.Exists(Fil1) Then
                    .Logo(Fil1, "fermo")
                    '----------17/01/01
                    .VaiInizio("\EndOfDoc", , True)
                    .sOpen(Monitor.Motore.Inizio.Archdir & "\TabSR.doc", True, 1)
                    .VaiInizio("\StartOfDoc", 1, True)
                    .Copia(1)
                    .sClose(, 1)
                    .VaiInizio("\EndOfDoc")
                    .sTypeParagraph()
                    .sPaste1()
                    .sCollapse(Word.WdCollapseDirection.wdCollapseEnd)
                    .sMoveUp(Unit:=Word.WdUnits.wdLine, Count:=6)
                    .sMoveRight(Unit:=Word.WdUnits.wdCharacter, Count:=1)
                    For i = 10 To 1 Step -1
                        .sTypeText(Str(Reg(1).Bypass(i)), True)
                        .sMoveRight()
                    Next
                    .sMoveRight(Word.WdUnits.wdCell, 2)
                    For i = 10 To 1 Step -1
                        If Reg(1).Tvap(i) > 0 Then .sTypeText(Trim(Funzioni.myStr(Reg(1).Tvap(i), 4, 1, False)), True)
                        .sMoveRight()
                    Next
                    .sMoveRight(Word.WdUnits.wdCell, 2)
                    For i = 10 To 1 Step -1
                        If Reg(1).Tgprima(i) > 0 Then .sTypeText(Trim(Funzioni.myStr(Reg(1).Tgprima(i), 4, 1, False)), True)
                        .sMoveRight()
                    Next
                    .sMoveRight(Word.WdUnits.wdCell, 2)
                    For i = 10 To 1 Step -1
                        If Reg(1).Tgdopo(i) > 0 Then .sTypeText(Trim(Funzioni.myStr(Reg(1).Tgdopo(i), 4, 1, False)), True)
                        .sMoveRight()
                    Next
                    .sMoveRight(Word.WdUnits.wdCell, 2)
                    For i = 10 To 1 Step -1
                        .sTypeText(Trim(Funzioni.myStr(Reg(1).Angolo(i), 3, 1, False)), True)
                        .sMoveRight()
                    Next
                    .sMoveRight(Word.WdUnits.wdCharacter, 1)
                    '-----------------
                End If
            End With
            On Error Resume Next
            Stub.sClose(, 1)
            ' DocTab.Close
            ' Kill Fil0
            ' Kill Fil1
            On Error GoTo 0
        End If
        AppActivate(mioApert.Text)
        If MsgBox("Vuoi introdurre nel rapporto il prospetto delle proprietà dei fluidi?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            On Error Resume Next
            AppActivate(Stub.App.Caption)
            On Error GoTo 0
            Gas.Calcola(iErr)
            If iErr = 0 Then
                Gas.Stub.Copia()
                Gas.Stub.sClose()
                Stub.VaiInizio("\EndOfDoc", , True)
                With Stub 'Selection
                    .sTypeParagraph()
                    .sInsertBreak() 'Type:=wdPageBreak
                    .sPaste1()
                    .sCollapse(Word.WdCollapseDirection.wdCollapseEnd)
                    .sTypeParagraph()
                    .sInsertBreak() 'Type:=wdPageBreak
                    p = Problem.PressVapIn
                    T0 = Problem.Temp.Tvin
                    T1 = Problem.Temp.Tvout
                    dt = (T1 - T0) / 5
                    AppActivate(mioApert.Text)
                    T0 = T0 - 3 * dt
                    T1 = T1 + 3 * dt
                    Vap.Calcola(T0, T1, dt, p, Left(FileData, Len(FileData) - 4) & "VAP.DOC", iErr)
                    If Not iErr = 0 Then GoTo Ex
                    Vap.Stub.Copia()
                    Vap.Stub.sClose()
                    .sPaste1()
                End With
            End If
        End If
        AppActivate(Stub.App.Caption)
Ex:     Stub.sSave()
        Exit Sub
ExClose: On Error Resume Next
        Stub.sClose()
        Exit Sub
ErrCD:
        testo = "Impossibile salvare il documento Word " & FileSt & "." & vbCrLf
        testo = testo & "E' possibile che esso sia già aperto in WinWord." & vbCrLf
        testo = testo & "In tal caso attivare WinWord, chiudere il documento e poi riprovare."
        Select Case MsgBox(testo, MsgBoxStyle.RetryCancel + MsgBoxStyle.Information, "Surrisc")
            Case MsgBoxResult.Retry : Resume
            Case MsgBoxResult.Cancel : Resume ExClose
        End Select
    End Sub
    Public Sub ScriviRapporto9()
        Dim Stub As StubW9.clsSW9
        Dim FileSt, LogoFile As String
        Dim i As Short
        Dim FilePic As String = ""
        Dim n, iErr As Short
        Dim Fil0, Fil1 As String
        Dim testo As String
        Dim j As Short
        Dim dt, T0, T1, p As Single
        If Config.Progetto = 1 And Nzone = 0 Then mioApert.Calcola_Click(Nothing, New System.EventArgs()) '17/01/01
        FileSt = Monitor.Motore.Inizio.Archdir & "\SURR01.DOC"
        Stub = New StubW9.clsSW9
        Stub.SuperStampa(FileSt, Monitor.Motore.Inizio.VersOffice) ' Doc
        FileSt = Left(FileData, Len(FileData) - 4) & Funzioni.Str2Cifre(Altern - 1) & "STD.DOC"
        On Error GoTo ErrCD
        Stub.sSaveAs(FileSt)
        LogoFile = Monitor.Motore.Inizio.Archdir & "\" & Monitor.Motore.Inizio.ReadIniFile("", "Azienda", "Logo")
        Stub.IntestLogo(LogoFile)
        On Error GoTo 0
        Select Case Config.Tipo
            Case 1 : FilePic = Monitor.Motore.Inizio.Archdir & "\STDSUR1.BMP"
            Case 2 : FilePic = Monitor.Motore.Inizio.Archdir & "\STDSUR2.BMP"
            Case 3 : FilePic = Monitor.Motore.Inizio.Archdir & "\STDSUR3.BMP"
        End Select
        Stub.Logo(FilePic, "\StartOfDoc")
        Stub.VaiInizio("TabSin", , True)
        With Stub 'Selection
            n = Config.NCross
            If Config.Tipo = 2 Then n = n + Config.NCrossCieco
            .sTypeText(Str(n))
            .sTypeText(Funzioni.myStr(Geom.ITLint, 4, 2, False))
            .sTypeText(Funzioni.myStr(Geom.ITLout, 4, 2, False))
            If Config.Tipo <> 2 Then
                .sTypeText("N.A.")
            Else
                .sTypeText(Funzioni.myStr(Geom.DiamFasciameInt, 4, 2, False))
            End If
            .sTypeText(Funzioni.myStr(Geom.DiamFasciameExt, 4, 2, False))
            If Config.Tipo <> 3 Then
                .sTypeText("N.A.")
            Else
                .sTypeText(Funzioni.myStr(Geom.DiamCentrale, 4, 2, False))
            End If
        End With
        Stub.VaiInizio("TabDes", , True)
        With Stub 'Selection
            If Config.Tipo <> 2 Then
                .sTypeText("N.A.")
            Else
                .sTypeText(Str(Config.NCrossCieco))
            End If
            .sTypeText(Funzioni.myStr(Geom.OTLint, 4, 2, False))
            .sTypeText(Funzioni.myStr(Geom.OTLout, 4, 2, False))
            If Config.Tipo <> 3 Then
                .sTypeText("N.A.")
            Else
                .sTypeText(Funzioni.myStr(Geom.DiamFasciameInt, 4, 2, False))
            End If
            .sTypeText(Funzioni.myStr(Geom.DiamMantello, 4, 2, False))
        End With
        Stub.VaiInizio("mbar", , True)
        With Stub 'Selection
            .SurrCopia(Nzone)
            If Config.Progetto = 1 Then
                .sBreak()
                .sOpen(Monitor.Motore.Inizio.Archdir & "\SURR02.doc", True, 1)
                .VaiInizio("\StartOfDoc", 1)
                .Copia(1)
                .sClose(, 1)
                .VaiInizio("\EndOfDoc")
                .sPaste1()
            End If
        End With
        If Config.Progetto = 1 Then
            Stub.VaiInizio("mbar1", , True)
            With Stub 'Selection
                .SurrCopia(Nzone)
            End With
        End If
        '----------------
        For j = 1 To Config.Progetto + 1 '17/01/01
            If j = 1 Then '17/01/01
                If Config.Progetto = 1 Then mioApert.Calcola_Click(Nothing, New System.EventArgs())
                Stub.VaiInizio("mbar", , True)
            Else '17/01/01
                If Config.Progetto = 1 Then mioApert.Command4_Click(Nothing, New System.EventArgs())
                Stub.VaiInizio("mbar1", , True)
            End If '17/01/01
            With Stub 'Selection
                For i = 1 To Nzone
                    .sMoveRight(, 2)
                    .sTypeText(Funzioni.myStr(Zone(i).Tgasi, 4, 2, False), True)
                    .sMoveRight()
                    .sTypeText(Funzioni.myStr(Zone(i).Twexto, 4, 2, False), True)
                    .sMoveRight(, 2)
                    .sTypeText(Str(i), True)
                    .sMoveRight()
                    .sTypeText(Funzioni.myStr(Zone(i).Tvapi, 4, 2, False), True)
                    .sMoveRight()
                    .sTypeText(Funzioni.myStr(Zone(i).Tvapo, 4, 2, False), True)
                    .sMoveRight()
                    .sTypeText(Funzioni.myStr(Zone(i).LMTD / (Zone(i).Ui + Zone(i).Uo) * 2, 4, 2, False), True)
                    .sMoveRight()
                    .sTypeText(Funzioni.myStr(Zone(i).MTD / (Zone(i).Ui + Zone(i).Uo) * 2, 4, 2, False), True)
                    .sMoveRight()
                    .sTypeText(Funzioni.myStr(Zone(i).FT, 1, 3, False), True)
                    .sMoveRight()
                    .sTypeText(Funzioni.myStr(Zone(i).Q / 1000, 5, 1, False), True)
                    .sMoveRight()
                    .sTypeText(Funzioni.myStr(Zone(i).Rex, 8, 1, False), True)
                    .sMoveRight()
                    .sTypeText(Funzioni.myStr(Zone(i).dp / 100, 4, 2, False), True)
                    .sMoveRight(, 2)
                    .sTypeText(Funzioni.myStr(Zone(i).Tgaso, 4, 2, False), True)
                    .sMoveRight()
                    .sTypeText(Funzioni.myStr(Zone(i).TWexti, 4, 2, False), True)
                    .SurrFormat()
                Next
            End With
        Next j
        Fil0 = Left(FileData, Len(FileData) - 4) & "PIC0.WMF" '17/01/01
        Fil1 = Left(FileData, Len(FileData) - 4) & "PIC1.WMF" '17/01/01
        If IO.File.Exists(Fil0) Or IO.File.Exists(Fil1) Then
            Stub.VaiInizio("\EndOfDoc", , True)
            With Stub 'Selection
                .sInsertBreak()
                mioApert.cmdReg_Click(Nothing, New System.EventArgs()) '17/01/01
                'UPGRADE_WARNING: Dir ha un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
                If IO.File.Exists(Fil0) Then
                    .Logo(Fil0, "\EndOfDoc")
                    .VaiInizio("\EndOfDoc", , True)
                    '--------------------------------17/01/01
                    .sOpen(Monitor.Motore.Inizio.Archdir & "\TabSR.doc", True, 1)
                    .VaiInizio("\StartOfDoc", 1, True)
                    .Copia(1)
                    .sClose(, 1)
                    .VaiInizio("\EndOfDoc")
                    .sTypeParagraph()
                    .sPaste1()
                    .sCollapse(Word.WdCollapseDirection.wdCollapseEnd)
                    .sMoveUp(Unit:=Word.WdUnits.wdLine, Count:=6)
                    .sMoveRight(Unit:=Word.WdUnits.wdCharacter, Count:=1)
                    For i = 10 To 1 Step -1
                        .sTypeText(Str(Reg(0).Bypass(i)), True)
                        .sMoveRight()
                    Next
                    .sMoveRight(Word.WdUnits.wdCell, 2)
                    For i = 10 To 1 Step -1
                        If Reg(0).Tvap(i) > 0 Then .sTypeText(Trim(Funzioni.myStr(Reg(0).Tvap(i), 4, 1, False)), True)
                        .sMoveRight()
                    Next
                    .sMoveRight(Word.WdUnits.wdCell, 2)
                    For i = 10 To 1 Step -1
                        If Reg(0).Tgprima(i) > 0 Then .sTypeText(Trim(Funzioni.myStr(Reg(0).Tgprima(i), 4, 1, False)), True)
                        .sMoveRight()
                    Next
                    .sMoveRight(Word.WdUnits.wdCell, 2)
                    For i = 10 To 1 Step -1
                        If Reg(0).Tgdopo(i) > 0 Then .sTypeText(Trim(Funzioni.myStr(Reg(0).Tgdopo(i), 4, 1, False)), True)
                        .sMoveRight()
                    Next
                    .sMoveRight(Word.WdUnits.wdCell, 2)
                    For i = 10 To 1 Step -1
                        .sTypeText(Trim(Funzioni.myStr(Reg(0).Angolo(i), 3, 1, False)), True)
                        .sMoveRight()
                    Next
                    .sMoveRight(Word.WdUnits.wdCharacter, 1)
                    '-------------------------------
                End If
                .sCollapse(Word.WdCollapseDirection.wdCollapseEnd)
                .sTypeParagraph()
                mioApert.cmdReg_Click(Nothing, New System.EventArgs()) '17/01/01
                If IO.File.Exists(Fil1) Then
                    .Logo(Fil1, "fermo")
                    '----------17/01/01
                    .VaiInizio("\EndOfDoc", , True)
                    .sOpen(Monitor.Motore.Inizio.Archdir & "\TabSR.doc", True, 1)
                    .VaiInizio("\StartOfDoc", 1, True)
                    .Copia(1)
                    .sClose(, 1)
                    .VaiInizio("\EndOfDoc")
                    .sTypeParagraph()
                    .sPaste1()
                    .sCollapse(Word.WdCollapseDirection.wdCollapseEnd)
                    .sMoveUp(Unit:=Word.WdUnits.wdLine, Count:=6)
                    .sMoveRight(Unit:=Word.WdUnits.wdCharacter, Count:=1)
                    For i = 10 To 1 Step -1
                        .sTypeText(Str(Reg(1).Bypass(i)), True)
                        .sMoveRight()
                    Next
                    .sMoveRight(Word.WdUnits.wdCell, 2)
                    For i = 10 To 1 Step -1
                        If Reg(1).Tvap(i) > 0 Then .sTypeText(Trim(Funzioni.myStr(Reg(1).Tvap(i), 4, 1, False)), True)
                        .sMoveRight()
                    Next
                    .sMoveRight(Word.WdUnits.wdCell, 2)
                    For i = 10 To 1 Step -1
                        If Reg(1).Tgprima(i) > 0 Then .sTypeText(Trim(Funzioni.myStr(Reg(1).Tgprima(i), 4, 1, False)), True)
                        .sMoveRight()
                    Next
                    .sMoveRight(Word.WdUnits.wdCell, 2)
                    For i = 10 To 1 Step -1
                        If Reg(1).Tgdopo(i) > 0 Then .sTypeText(Trim(Funzioni.myStr(Reg(1).Tgdopo(i), 4, 1, False)), True)
                        .sMoveRight()
                    Next
                    .sMoveRight(Word.WdUnits.wdCell, 2)
                    For i = 10 To 1 Step -1
                        .sTypeText(Trim(Funzioni.myStr(Reg(1).Angolo(i), 3, 1, False)), True)
                        .sMoveRight()
                    Next
                    .sMoveRight(Word.WdUnits.wdCharacter, 1)
                    '-----------------
                End If
            End With
            On Error Resume Next
            Stub.sClose(, 1)
            ' DocTab.Close
            ' Kill Fil0
            ' Kill Fil1
            On Error GoTo 0
        End If
        AppActivate(mioApert.Text)
        If MsgBox("Vuoi introdurre nel rapporto il prospetto delle proprietà dei fluidi?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            ' On Error Resume Next
            ' AppActivate(Stub.App.Caption)
            ' On Error GoTo 0
            Gas.Calcola(iErr)
            If iErr = 0 Then
                Gas.Stub.Copia()
                Gas.Stub.sClose()
                Stub.VaiInizio("\EndOfDoc", , True)
                With Stub 'Selection
                    .sTypeParagraph()
                    .sInsertBreak() 'Type:=wdPageBreak
                    .sPaste1()
                    .sCollapse(Word.WdCollapseDirection.wdCollapseEnd)
                    .sTypeParagraph()
                    .sInsertBreak() 'Type:=wdPageBreak
                    p = Problem.PressVapIn
                    T0 = Problem.Temp.Tvin
                    T1 = Problem.Temp.Tvout
                    dt = (T1 - T0) / 5
                    AppActivate(mioApert.Text)
                    T0 = T0 - 3 * dt
                    T1 = T1 + 3 * dt
                    Vap.Calcola(T0, T1, dt, p, Left(FileData, Len(FileData) - 4) & "VAP.DOC", iErr)
                    If Not iErr = 0 Then GoTo Ex
                    Vap.Stub.Copia()
                    Vap.Stub.sClose()
                    .sPaste1()
                End With
            End If
        End If
        'AppActivate(Stub.App.Caption)
Ex:     Stub.sSave()
        Exit Sub
ExClose: On Error Resume Next
        Stub.sClose()
        Exit Sub
ErrCD:
        testo = "Impossibile salvare il documento Word " & FileSt & "." & vbCrLf
        testo = testo & "E' possibile che esso sia già aperto in WinWord." & vbCrLf
        testo = testo & "In tal caso attivare WinWord, chiudere il documento e poi riprovare."
        Select Case MsgBox(testo, MsgBoxStyle.RetryCancel + MsgBoxStyle.Information, "Surrisc")
            Case MsgBoxResult.Retry : Resume
            Case MsgBoxResult.Cancel : Resume ExClose
        End Select
    End Sub

    Public Sub Inizia12(ByRef DTm As Single)

        'valori di primo tentativo
        y = (Surr.TempLTf + Surr.TempLTc) / 2
        yv = Geom.LungCieca / Geom.LungDiritta * (y - Surr.TempLTf) + y
        xg = yv + 10
        If xg <= Surr.TempLTc Or xg > Surr.TempLMc Then xg = Surr.TempLTc + 10
        DTm = (Dtln1() * Geom.LungCieca + 2 * (Geom.LungDiritta - Geom.LungCieca) * (Dtln2() + Dtln3())) / (2 * Geom.LungDiritta - Geom.LungCieca)

    End Sub
    Public Sub Mem()
        ReDim Zone(Nzone)
        ReDim OrdGas(Nzone)
        ReDim SuccGas(Nzone)
        ReDim PrecGas(Nzone)
    End Sub
    Public Sub Inizia3(ByRef DTm As Single)
        Nzone = 6
        Call Mem()
        'valori di primo tentativo
        y = (Surr.TempLTf + Surr.TempLTc) / 2
        yv = Geom.LungCieca / Geom.LungDiritta * (y - Surr.TempLTf) + y
        xg = yv + 10
        If xg <= Surr.TempLTc Then xg = Surr.TempLTc + 10
        DTm = (Dtln1() * Geom.LungCieca + 2 * (Geom.LungDiritta - Geom.LungCieca) * (Dtln2() + Dtln3())) / (2 * Geom.LungDiritta - Geom.LungCieca)
        OrdGas(1) = 4 'ordine di percorrenza del gas sulle zone
        OrdGas(2) = 5
        OrdGas(3) = 6
        OrdGas(4) = 3
        OrdGas(5) = 2
        OrdGas(6) = 1
        SuccGas(4) = 5
        SuccGas(5) = 6
        SuccGas(6) = 3
        SuccGas(3) = 2
        SuccGas(2) = 1
        SuccGas(1) = 0
        PrecGas(4) = 0
        PrecGas(5) = 4
        PrecGas(6) = 5
        PrecGas(3) = 6
        PrecGas(2) = 3
        PrecGas(1) = 2

    End Sub
    Public Sub Inizia5(ByRef DTm As Single)
        Nzone = 12
        Call Mem()
        'valori di primo tentativo
        y = (Surr.TempLTf + Surr.TempLTc) / 2
        yv = Geom.LungCieca / Geom.LungDiritta * (y - Surr.TempLTf) + y
        xg = yv + 10
        If xg <= Surr.TempLTc Then xg = Surr.TempLTc + 10
        DTm = (Dtln1() * Geom.LungCieca + 2 * (Geom.LungDiritta - Geom.LungCieca) * (Dtln2() + Dtln3())) / (2 * Geom.LungDiritta - Geom.LungCieca)
        OrdGas(1) = 8 'ordine di percorrenza del gas sulle zone
        OrdGas(2) = 9
        OrdGas(3) = 10
        OrdGas(4) = 7
        OrdGas(5) = 6
        OrdGas(6) = 11
        OrdGas(7) = 12
        OrdGas(8) = 5
        OrdGas(9) = 4
        OrdGas(10) = 3
        OrdGas(11) = 2
        OrdGas(12) = 1
        SuccGas(1) = 0
        SuccGas(2) = 1
        SuccGas(3) = 2
        SuccGas(4) = 3
        SuccGas(5) = 4
        SuccGas(6) = 11
        SuccGas(7) = 6
        SuccGas(8) = 9
        SuccGas(9) = 10
        SuccGas(10) = 7
        SuccGas(11) = 12
        SuccGas(12) = 5
        PrecGas(1) = 2
        PrecGas(2) = 3
        PrecGas(3) = 4
        PrecGas(4) = 5
        PrecGas(5) = 12
        PrecGas(6) = 7
        PrecGas(7) = 10
        PrecGas(8) = 0
        PrecGas(9) = 8
        PrecGas(10) = 9
        PrecGas(11) = 6
        PrecGas(12) = 11
    End Sub
    Public Function Inizia4(ByRef DTm As Single) As Boolean
        Dim Dt2, Dt1, OverAll As Single
        Inizia4 = True
        Nzone = 8
        Call Mem()
        'valori di primo tentativo
        Dt1 = Surr.TempLMc - Surr.TempLTc
        Dt2 = Surr.TempLMf - Surr.TempLTf
        OverAll = u((Surr.TempLTf + Surr.TempLTc) / 2, (Surr.TempLTf + Surr.TempLTc) / 2, (Surr.TempLMc + Surr.TempLMf) / 2, (Geom.OTLint + Geom.ITLout) / 2, Geom.LungDiritta / Nzone * 2, False)
        If OverAll = 0 Then Inizia4 = False : Exit Function
        DTm = System.Math.Abs(Dt1 + Dt2) / 2 * OverAll
        OrdGas(1) = 4 'ordine di percorrenza del gas sulle zone
        OrdGas(2) = 5
        OrdGas(3) = 6
        OrdGas(4) = 3
        OrdGas(5) = 2
        OrdGas(6) = 7
        OrdGas(7) = 8
        OrdGas(8) = 1
        SuccGas(4) = 5
        SuccGas(5) = 6
        SuccGas(6) = 3
        SuccGas(3) = 2
        SuccGas(2) = 7
        SuccGas(7) = 8
        SuccGas(8) = 1
        SuccGas(1) = 0
        PrecGas(4) = 0
        PrecGas(5) = 4
        PrecGas(6) = 5
        PrecGas(3) = 6
        PrecGas(2) = 3
        PrecGas(7) = 2
        PrecGas(8) = 7
        PrecGas(1) = 8
    End Function
    Public Sub TempInt()
        Dim j, i, j1 As Short
        For i = 1 To Nzone
            Zone(i).Tvapi = Surr.TempLTf + (i - 1) * (Surr.TempLTc - Surr.TempLTf) / Nzone
            j = OrdGas(i)
            If fi = 0 Then fi = 1
            'Zone(j).Tgasi = Problem.Temp.Tgasin + ((j - 1) / Nzone) ^ fi * (Problem.Temp.Tgasout - Problem.Temp.Tgasin)
            Zone(j).Tgasi = Surr.TempLMc + ((i - 1) / Nzone) ^ fi * (Surr.TempLMf - Surr.TempLMc)
        Next
        For i = 1 To Nzone
            If i < Nzone Then
                Zone(i).Tvapo = Zone(i + 1).Tvapi
                j = OrdGas(i)
                j1 = OrdGas(i + 1)
                Zone(j).Tgaso = Zone(j1).Tgasi
            End If
        Next
        Zone(Nzone).Tvapo = Surr.TempLTc
        Zone(OrdGas(Nzone)).Tgaso = Surr.TempLMf
    End Sub

    Public Sub Lunghezze()
        Dim i As Short
        Select Case Config.Tipo
            Case 2
                For i = 1 To Config.NCrossCieco
                    Zone(i).Lungh = Geom.LungCieca / Config.NCrossCieco
                Next
                For i = Config.NCrossCieco + 1 To Nzone
                    Zone(i).Lungh = (Geom.LungDiritta - Geom.LungCieca) / Config.NCross
                Next
                For i = 1 To Nzone
                    Zone(i).interno = i > Config.NCrossCieco + Config.NCross
                Next
            Case 1, 3
                For i = 1 To Nzone
                    Zone(i).Lungh = Geom.LungDiritta / Config.NCross
                    Zone(i).interno = i > Config.NCross
                Next
        End Select
    End Sub
    Public Sub NuoveTemp(ByRef Watt As Single, ByRef iErr As Short)
        Dim Cp0, Excess, Cp1 As Single
        Dim delta, Ggcg, Gvcv, fract As Single
        fract = 1
        Do
            EntalpGas(Qtot)
            Ggcg = Qtot * Problem.Qgas
            Excess = Ggcg - Watt
            Cp0 = Prop.CpGasV(Problem.Temp.Tgasin)
            Cp1 = Prop.CpGasV(Problem.Temp.Tgasout)
            delta = Excess / Problem.Qgas / ((Cp0 + Cp1) / 2)
R1:         Problem.Temp.Tgasout = Problem.Temp.Tgasout + delta / fract
            If Problem.Temp.Tgasout < 0.9 * savProbl.Temp.Tgasout Or Problem.Temp.Tgasout > Problem.Temp.Tgasin Then
                Problem.Temp.Tgasout = Problem.Temp.Tgasout - delta / fract
                fract = fract * 2
                GoTo R1
            End If
            'If Problem.Temp.Tgasout < -1000 Or Problem.Temp.Tgasout > 3000 Then iErr = 1: Exit Sub
        Loop While System.Math.Abs(Excess) / Watt > 0.00001 And System.Math.Abs(Excess / Problem.Qgas / ((Cp0 + Cp1) / 2)) > 0.001 And fract = 1
        fract = 1
        Do
            EntalpVap(Qtot)
            Gvcv = Qtot * Problem.Qvap
            Excess = Watt - Gvcv
            Cp0 = Prop.CpVapV(Problem.Temp.Tvin)
            Cp1 = Prop.CpVapV(Problem.Temp.Tvout)
            delta = Excess / Problem.Qvap / ((Cp0 + Cp1) / 2)
R2:         Problem.Temp.Tvout = Problem.Temp.Tvout + delta / fract
            If Problem.Temp.Tvout < Problem.Temp.Tvin Or Problem.Temp.Tvout > Problem.Temp.Tgasin Then
                Problem.Temp.Tvout = Problem.Temp.Tvout - delta / fract
                fract = fract * 2
                GoTo R2
            End If
            'If Problem.Temp.Tvout < -1000 Or Problem.Temp.Tvout > 3000 Then iErr = 1: Exit Sub
        Loop While System.Math.Abs(Excess) / Watt > 0.00001 And System.Math.Abs(Excess / Problem.Qvap / ((Cp0 + Cp1) / 2)) > 0.001 And fract = 1
    End Sub
    Public Sub EntalpVap(ByRef Qtot As Single)
        Dim T1, T2 As Single
        Dim H2, H1 As Single
        T1 = Problem.Temp.Tvin : T2 = Problem.Temp.Tvout
        Vap.SubHPTS(T2, Problem.PressVapIn, H2)
        Vap.SubHPTS(T1, Problem.PressVapIn, H1)
        Qtot = (H2 - H1) * 1000
    End Sub

    Public Sub EntalpGas(ByRef Qtot As Single)
        Dim T1, Cp1, Cp0, T2 As Single
        Dim dt, T As Single
        Dim Npunti, i As Short
        Npunti = 10
        T1 = Problem.Temp.Tgasout : T2 = Problem.Temp.Tgasin
        dt = (T2 - T1) / Npunti
        Qtot = 0
        For i = 0 To Npunti
            T = T1 + i * dt
            If i = 0 Then
                Cp1 = Prop.CpGasV(T)
            ElseIf i > 0 Then
                Cp0 = Cp1
                Cp1 = Prop.CpGasV(T)
                Qtot = Qtot + (Cp0 + Cp1) / 2 * dt
            End If
        Next
    End Sub

    Public Sub Inizia6(ByRef DTm As Single, ByRef n As Short)
        Dim Dt1, Dt2 As Single
        Dim i As Short
        Nzone = n
        Call Mem()
        'valori di primo tentativo
        Dt1 = Surr.TempLMc - Surr.TempLTc
        Dt2 = Surr.TempLMf - Surr.TempLTf
        DTm = (Dt1 + Dt2) / 2 * u((Surr.TempLTf + Surr.TempLTc) / 2, (Surr.TempLTf + Surr.TempLTc) / 2, (Surr.TempLMc + Surr.TempLMf) / 2, (Geom.OTLint + Geom.ITLout) / 2, Geom.LungDiritta / Nzone * 2, False)
        For i = 0 To Nzone / 4 - 1
            OrdGas(1 + i * 4) = Nzone / 2 - 2 * i
            OrdGas(2 + i * 4) = Nzone / 2 + 1 + 2 * i
            OrdGas(3 + i * 4) = Nzone / 2 + 1 + 2 * i + 1
            OrdGas(4 + i * 4) = Nzone / 2 - 2 * i - 1
        Next
        For i = 1 To Nzone - 1
            SuccGas(OrdGas(i)) = OrdGas(i + 1)
        Next
        For i = 2 To Nzone
            PrecGas(OrdGas(i)) = OrdGas(i - 1)
        Next
        ' SuccGas(OrdGas(1 + i * 4)) = OrdGas(2 + i * 4)
        ' SuccGas(OrdGas(2 + i * 4)) = OrdGas(3 + i * 4)
        ' SuccGas(OrdGas(3 + i * 4)) = OrdGas(4 + i * 4)
        ' SuccGas(OrdGas(4 + i * 4)) = OrdGas(1 + i * 4)
        ' PrecGas(OrdGas(1 + i * 4)) = OrdGas(4 + i * 4)
        ' PrecGas(OrdGas(2 + i * 4)) = OrdGas(1 + i * 4)
        ' PrecGas(OrdGas(3 + i * 4)) = OrdGas(2 + i * 4)
        ' PrecGas(OrdGas(4 + i * 4)) = OrdGas(3 + i * 4)
        'Next
        SuccGas(1) = 0
        PrecGas(OrdGas(1)) = 0
        ' SuccGas(4) = 5
        ' SuccGas(5) = 6
        ' SuccGas(6) = 3
        ' SuccGas(3) = 2
        ' SuccGas(2) = 7
        ' SuccGas(7) = 8
        ' SuccGas(8) = 1
        ' SuccGas(1) = 0
        ' PrecGas(4) = 0
        ' PrecGas(5) = 4
        ' PrecGas(6) = 5
        ' PrecGas(3) = 6
        ' PrecGas(2) = 3
        ' PrecGas(7) = 2
        ' PrecGas(8) = 7
        ' PrecGas(1) = 8
    End Sub

    Public Sub IniziaBorsig(ByRef DTm As Single, ByRef n As Short)
        Dim Dt2, Dt1, DTln As Single
        Dim i As Short
        Nzone = n
        Call Mem()
        'valori di primo tentativo
        Dt1 = Surr.TempLMc - Surr.TempLTc
        Dt2 = Surr.TempLMf - Surr.TempLTf
        If System.Math.Abs(Dt1 - Dt2) / Dt1 < 0.0001 Then
            DTln = Dt1
        Else
            DTln = (Dt1 - Dt2) / System.Math.Log(Dt1 / Dt2)
        End If
        DTm = DTln * u((Surr.TempLTf + Surr.TempLTc) / 2, (Surr.TempLTf + Surr.TempLTc) / 2, (Surr.TempLMc + Surr.TempLMf) / 2, (Geom.OTLint + Geom.ITLout) / 2, Geom.LungDiritta / Nzone * 2, False)
        For i = 1 To Nzone
            OrdGas(i) = Nzone + 1 - i
            SuccGas(i) = i - 1
            PrecGas(i) = i + 1
        Next
        PrecGas(Nzone) = 0
    End Sub
    Public Sub IniziaCieco(ByRef DTm As Single)
        Dim i As Short
        Dim Dt2, Dt3 As Single
        Nzone = Config.NCrossCieco + 2 * Config.NCross
        Call Mem()
        'valori di primo tentativo
        y = (Surr.TempLTf + Surr.TempLTc) / 2
        yv = Geom.LungCieca / Geom.LungDiritta * (y - Surr.TempLTf) + y
        xg = yv + 10
        If xg <= Surr.TempLTc Then xg = Surr.TempLTc + 10
        Dt2 = Dtln2() : Dt3 = Dtln3()
        If Dt2 = 0 Or Dt3 = 0 Then ErroreGenerale = True : Exit Sub
        DTm = (Dtln1() * Geom.LungCieca + 2 * (Geom.LungDiritta - Geom.LungCieca) * (Dt2 + Dt3)) / (2 * Geom.LungDiritta - Geom.LungCieca)
        For i = 0 To Config.NCross / 2 - 1
            OrdGas(1 + i * 4) = Config.NCross + Config.NCrossCieco - 2 * i
            OrdGas(2 + i * 4) = Config.NCross + Config.NCrossCieco + 1 + 2 * i
            OrdGas(3 + i * 4) = Config.NCross + Config.NCrossCieco + 1 + 2 * i + 1
            OrdGas(4 + i * 4) = Config.NCross + Config.NCrossCieco - 2 * i - 1
        Next
        ' SuccGas(OrdGas(1 + i * 4)) = OrdGas(2 + i * 4)
        ' SuccGas(OrdGas(2 + i * 4)) = OrdGas(3 + i * 4)
        ' SuccGas(OrdGas(3 + i * 4)) = OrdGas(4 + i * 4)
        ' SuccGas(OrdGas(4 + i * 4)) = OrdGas(1 + i * 4)
        ' PrecGas(OrdGas(1 + i * 4)) = OrdGas(4 + i * 4)
        ' PrecGas(OrdGas(2 + i * 4)) = OrdGas(1 + i * 4)
        ' PrecGas(OrdGas(3 + i * 4)) = OrdGas(2 + i * 4)
        ' PrecGas(OrdGas(4 + i * 4)) = OrdGas(3 + i * 4)
        'Next
        For i = 1 To Config.NCrossCieco
            OrdGas(i + 2 * Config.NCross) = Config.NCrossCieco + 1 - i
            '  SuccGas(i) = i - 1
            '  PrecGas(i) = i + 1
        Next
        For i = 1 To Nzone - 1
            SuccGas(OrdGas(i)) = OrdGas(i + 1)
        Next
        For i = 2 To Nzone
            PrecGas(OrdGas(i)) = OrdGas(i - 1)
        Next
        SuccGas(1) = 0
        PrecGas(OrdGas(1)) = 0
    End Sub

    Public Sub CalcITLint()
        Dim DiamCExt, Area, ITLint As Single
        If Config.Progetto = 1 Then Exit Sub
        Area = PI / 4 * Geom.DiamCentrale ^ 2
        DiamCExt = Geom.DiamCentrale + 2 * Standard.SpessTuboCentrale
        ITLint = System.Math.Sqrt(DiamCExt ^ 2 + 4 / PI * Area)
        Geom.ITLint = ITLint + 2 * Standard.OverOTL
        mioApert.txtTemp(33).Text = Funzioni.myStr(Geom.ITLint, 4, 2, False)
    End Sub

    Public Sub DropTubo(ByRef dp As Single)
        Dim Densin, l, Densout As Single
        Dim Twall, friction As Single
        Dim Tvapm, Re, Densm As Single
        Dim Di, Area, u, Visco As Single
        Dim Drop As Single
        l = Geom.LungDiritta
        Densin = 1 / Prop.VolGas((Surr.TempLMc))
        Densout = Densin
        Densm = (Densin + Densout) / 2
        Tvapm = Surr.TempLMc
        Twall = Tvapm
        Di = Geom.DiamCentrale / 1000
        Area = PI / 4 * Di ^ 2
        u = Surr.PortLM / Area / Densm
        Visco = Prop.ViscoGas(Tvapm)
        Re = Densm * u * Di / Visco
        friction = f(Re, Tvapm, Twall)
        Drop = 4 * friction * l / Di * Densm * u * u / 2
        u = Surr.PortLM / Area / Densin
        Drop = Drop + 0.5 * Densin * u * u / 2
        u = Surr.PortLM / Area / Densout
        Drop = Drop + Densout * u * u / 2
        dp = Drop
    End Sub

    Public Sub OverAll()
        Dim l, UAll, LMDT As Single
        Dim Area, Dt1, Dt2, MDT As Single
        Dim i As Short
        For i = 1 To Nzone
            l = l + Zone(i).Lungh
            UAll = UAll + (Zone(i).Ui + Zone(i).Uo) / 2 * Zone(i).Lungh
        Next
        UAll = UAll / l
        Problem.UAll = UAll
        mioApert.txtTemp(34).Text = Funzioni.myStr(UAll, 5, 2, False)
        Dt1 = Problem.Temp.Tgasin - Problem.Temp.Tvout
        Dt2 = Problem.Temp.Tgasout - Problem.Temp.Tvin
        If System.Math.Abs(Dt1 - Dt2) / Dt1 < 0.0001 Then
            LMDT = (Dt1 + Dt2) / 2
        Else
            LMDT = (Dt1 - Dt2) / System.Math.Log(Dt1 / Dt2)
        End If
        Problem.LMDT = LMDT
        mioApert.txtTemp(35).Text = Funzioni.myStr(LMDT, 3, 2, False)
        Area = PI * Geom.DiamExtTubi * Geom.NumeroTubi / 1000 * l
        Geom.Area = Area
        mioApert.txtTemp(63).Text = Funzioni.myStr(Area, 4, 2, False)
        MDT = QtotFunz / Area / UAll * (2 * CShort(Problem.FluidiInvertiti) + 1)
        Problem.MDT = MDT
        mioApert.txtTemp(36).Text = Funzioni.myStr(MDT, 3, 2, False)
    End Sub

    Public Sub CalcMantello()
        Dim Diam, AreaGas, AreaPiena As Single
        If Config.Progetto = 1 Then Exit Sub
        If Problem.VelGasMaxCen = 0 Then Exit Sub
        AreaGas = Surr.PortLM * Prop.VolGas((Surr.TempLMf)) / Problem.VelGasMaxCen * 1000000.0#
        AreaPiena = PI / 4 * (Geom.DiamFasciameExt + 2 * Standard.SpessFasciameExt) ^ 2 + AreaGas
        Diam = System.Math.Sqrt(4 / PI * AreaPiena)
        mioApert.txtTemp(39).Text = Str(Int(Diam + 0.5))
    End Sub

    Public Sub DropAnulus(ByRef dp As Single)
        Dim Densin, l, Densout As Single
        Dim Twall, friction As Single
        Dim Tvapm, Re, Densm As Single
        Dim Di, Area, u, Visco As Single
        Dim Drop, Perim As Single
        l = Geom.LungDiritta
        Densin = 1 / Prop.VolGas((Surr.TempLMf))
        Densout = Densin
        Densm = (Densin + Densout) / 2
        Tvapm = Surr.TempLMf
        Twall = Tvapm
        Area = PI / 4 * (Geom.DiamMantello ^ 2 - (Geom.DiamFasciameExt + 2 * Standard.SpessFasciameExt) ^ 2) / 1000000.0#
        Perim = PI * (Geom.DiamMantello + Geom.DiamFasciameExt + 2 * Standard.SpessFasciameExt) / 1000
        Di = 4 * Area / Perim
        u = Surr.PortLM / Area / Densm
        Visco = Prop.ViscoGas(Tvapm)
        Re = Densm * u * Di / Visco
        friction = f(Re, Tvapm, Twall)
        Drop = 4 * friction * l / Di * Densm * u * u / 2
        u = Surr.PortLM / Area / Densin
        Drop = Drop + 0.5 * Densin * u * u / 2
        u = Surr.PortLM / Area / Densout
        Drop = Drop + Densout * u * u / 2
        dp = dp + Drop
    End Sub

    Public Sub ScriviDS()
        Dim Stub As StubW2000.clsSW2000
        Dim Stub9 As StubW9.clsSW9
        Dim FileSt As String
        Dim Client, Plant As String
        Dim ClientPlant, testo As String
        Dim n As Integer
        FileSt = Monitor.Motore.Inizio.Archdir & "\DSSH.DOC"
        If Monitor.Motore.Inizio.VersOffice < 11 Then
            Stub9 = New StubW9.clsSW9
            Stub9.SuperStampa(FileSt, Monitor.Motore.Inizio.VersOffice) 'Doc
            With Stub9
                .sSaveAs(FileSt)
                testo = Monitor.Motore.Inizio.ReadIniFile("", "Azienda", "logo")
                If Len(testo) > 0 Then
                    .sLogo(Monitor.Motore.Inizio.Archdir & "\" & testo)
                    .sMoveRight(Unit:=Word.WdUnits.wdCharacter, Count:=1)
                End If
                ClientPlant = Monitor.Motore.Problem.ClientPlant
                If Len(ClientPlant) > 0 Then
                    n = InStr(ClientPlant, "-")
                    If n > 0 Then
                        Client = Left(ClientPlant, n - 1)
                        Plant = Right(ClientPlant, Len(ClientPlant) - n)
                    Else
                        n = CStr(InStr(ClientPlant, " "))
                        If n > 0 Then
                            Client = Left(ClientPlant, n - 1)
                            Plant = Right(ClientPlant, Len(ClientPlant) - n)
                        Else
                            Client = ClientPlant
                            Plant = ""
                        End If
                    End If
                Else
                    Client = "" : Plant = ""
                End If
                .sInsertAfter("Case", Config.DescrAlt)
                .sInsertAfter("Customer", Client)
                .sInsertAfter("Plant", Plant)
                .sInsertAfter("Item", Monitor.Motore.Problem.Item)
                If Config.Progetto = 0 Then
                    .sInsertAfter("Service", "(Design case)")
                Else
                    .sInsertAfter("Service", "(Verif. case)")
                End If
                .sInsertAfter("Qgas", Funzioni.myStr(Problem.Qgas, 4, 2, False))
                .sInsertAfter("Qvap", Funzioni.myStr(Problem.Qvap, 4, 2, False))
                If Config.Autom Then
                    .sInsertAfter("Composition", "see  ")
                    .sInsertAfter("MolWheight", Funzioni.myStr(Gas.prPesoMoc(0), 4, 2, False))
                Else
                    .sInsertAfter("Composition", "(phys. prop. inserted manually)")
                    .FontSize(7)
                    .sInsertAfter("MolWeight", "--")
                End If
                .sInsertAfter("Tgasin", Trim(Funzioni.myStr(Problem.Temp.Tgasin, 4, 1, False)))
                .sInsertAfter("Tgasout", Trim(Funzioni.myStr(Problem.Temp.Tgasout, 4, 1, False)))
                .sInsertAfter("Tvin", Trim(Funzioni.myStr(Problem.Temp.Tvin, 4, 1, False)))
                .sInsertAfter("Tvout", Trim(Funzioni.myStr(Problem.Temp.Tvout, 4, 1, False)))
                .sInsertAfter("CpGasIn", Funzioni.myStr(Gas.Cp(Problem.Temp.Tgasin, Problem.PressGasIn), 5, 2, False))
                .sInsertAfter("CpGasOut", Funzioni.myStr(Gas.Cp(Problem.Temp.Tgasout, Problem.PressGasIn), 5, 2, False))
                .sInsertAfter("CpVIn", Funzioni.myStr(Vap.Cp(Problem.Temp.Tvin, Problem.PressVapIn), 5, 2, False))
                .sInsertAfter("CpVout", Funzioni.myStr(Vap.Cp(Problem.Temp.Tvout, Problem.PressVapIn), 5, 2, False))
                .sInsertAfter("kGasIn", Funzioni.myStr(Gas.Conduc(Problem.Temp.Tgasin, Problem.PressGasIn), 5, 2, False))
                .sInsertAfter("kGasOut", Funzioni.myStr(Gas.Conduc(Problem.Temp.Tgasout, Problem.PressGasIn), 5, 2, False))
                .sInsertAfter("kVIn", Funzioni.myStr(Vap.Conduc(Problem.Temp.Tvin, Problem.PressVapIn), 5, 2, False))
                .sInsertAfter("kVout", Funzioni.myStr(Vap.Conduc(Problem.Temp.Tvout, Problem.PressVapIn), 5, 2, False))
                .sInsertAfter("vGasIn", Funzioni.myStr(Gas.Visco(Problem.Temp.Tgasin, Problem.PressGasIn) * 100000, 2, 5, False))
                .sInsertAfter("vGasOut", Funzioni.myStr(Gas.Visco(Problem.Temp.Tgasout, Problem.PressGasIn) * 100000, 2, 5, False))
                .sInsertAfter("vVIn", Funzioni.myStr(Vap.Visco(Problem.Temp.Tvin, Problem.PressVapIn) * 100000, 2, 5, False))
                .sInsertAfter("vVout", Funzioni.myStr(Vap.Visco(Problem.Temp.Tvout, Problem.PressVapIn) * 100000, 2, 5, False))
                .sInsertAfter("dGasIn", Funzioni.myStr(Gas.Dens(Problem.Temp.Tgasin, Problem.PressGasIn), 3, 3, False))
                .sInsertAfter("dGasOut", Funzioni.myStr(Gas.Dens(Problem.Temp.Tgasout, Problem.PressGasIn), 3, 3, False))
                .sInsertAfter("dVIn", Funzioni.myStr(Vap.Dens(Problem.Temp.Tvin, Problem.PressVapIn), 3, 3, False))
                .sInsertAfter("dVout", Funzioni.myStr(Vap.Dens(Problem.Temp.Tvout, Problem.PressVapIn), 3, 3, False))
                .sInsertAfter("pGasIn", Funzioni.myStr(Problem.PressGasIn, 5, 2, False))
                .sInsertAfter("pVIn", Funzioni.myStr(Problem.PressVapIn, 5, 2, False))
                .sInsertAfter("dpAllGas", Funzioni.myStr(Problem.dpAllGas / 100, 4, 3, False))
                .sInsertAfter("dpCalGas", Funzioni.myStr(Geom.DropGas / 100, 4, 3, False))
                .sInsertAfter("dpAllVap", Funzioni.myStr(Problem.dpAllVap / 100, 4, 3, False))
                .sInsertAfter("dpCalVap", Funzioni.myStr(Geom.DropVap / 100, 4, 3, False))
                .sInsertAfter("FoulGas", Funzioni.myStr(Problem.Routside, 1, 5, False))
                .sInsertAfter("FoulVap", Funzioni.myStr(Problem.Rinside, 1, 5, False))
                .sInsertAfter("UAllS", Funzioni.myStr(Problem.UAll, 4, 3, False))
                .sInsertAfter("UAllC", Funzioni.myStr(Problem.UAllC, 4, 3, False))
                .sInsertAfter("Watt", Funzioni.myStr(Problem.Watt / 1000, 8, 0, False))
                .sInsertAfter("Area", Funzioni.myStr(Geom.Area, 5, 2, False))
                .sInsertAfter("MTD", Funzioni.myStr(Problem.MDT, 5, 2, False))
                .sInsertAfter("SteamInlet", Funzioni.myStr(Geom.SteamInlet, 4, 2, False))
                .sInsertAfter("SteamOutlet", Funzioni.myStr(Geom.SteamOutlet, 4, 2, False))
                .sInsertAfter("GasOutlet", Funzioni.myStr(Geom.GasOutlet, 4, 2, False))
                .sInsertAfter("NumeroTubi", Trim(Str(Geom.NumeroTubi)))
                .sInsertAfter("TubeOD", Trim(Funzioni.myStr(Geom.DiamExtTubi, 2, 3, False)))
                If Geom.BWGTubi > 0 Then
                    .sInsertAfter("BWG", Trim(Str(Geom.BWGTubi)))
                Else
                    .sInsertAfter("BWG", "--")
                End If
                .sInsertAfter("TubeLength", Trim(Funzioni.myStr(Geom.LungDiritta * 1000, 5, 0, False)))
                .sInsertAfter("TubeThk", Trim(Funzioni.myStr(Geom.SpessTubi, 2, 3, False)))
                testo = Trim(Funzioni.myStr(Geom.PassoTubiInt, 3, 1, False))
                If Geom.TipoPassoInt = 0 Then testo = testo & " (tr.)" Else testo = testo & " (sq.)"
                .sInsertAfter("InPitch", testo)
                testo = Trim(Funzioni.myStr(Geom.PassoTubiExt, 3, 1, False))
                If Geom.TipoPassoExt = 0 Then testo = testo & " (tr.)" Else testo = testo & " (sq.)"
                .sInsertAfter("OutPitch", testo)
                .sInsertAfter("MatTubi", MatTubi.MatStr)
                .VaiInizio("Giovanni")
                .Testo(MatTubi.MatStr)
                .sInsertAfter("DocNo", Monitor.Motore.Problem.Doc)
                .ScriviBM("DesignData", "")
                .sMoveUp()
                Select Case Config.Tipo
                    Case 1, 2
                        .sTypeText("1")
                    Case 3
                        .sTypeText("2")
                End Select
                .sTypeText(Funzioni.myStr(DesignData.TShell, 3, 2, False), True)
                .sMoveRight(Word.WdUnits.wdCell)
                .sTypeText(Funzioni.myStr(DesignData.TTubi, 3, 2, False), True)
                .sMoveRight(Word.WdUnits.wdCell)
                .sTypeText(Funzioni.myStr(DesignData.TTS, 3, 2, False), True)
                .sMoveRight(Word.WdUnits.wdCell)
                .sTypeText(Funzioni.myStr(DesignData.TCassa, 3, 2, False), True)
                .sMoveLeft(Word.WdUnits.wdCell, 3)
                .sMoveDown()
                .sTypeText(Funzioni.myStr(DesignData.PShell, 3, 2, False), True)
                .sMoveRight(Word.WdUnits.wdCell)
                .sTypeText(Funzioni.myStr(DesignData.PTubi, 3, 2, False), True)
                .sMoveRight(Word.WdUnits.wdCell)
                .sTypeText(Funzioni.myStr(DesignData.PTS, 3, 2, False), True)
                .sMoveRight(Word.WdUnits.wdCell)
                .sTypeText(Funzioni.myStr(DesignData.PCassa, 3, 2, False), True)
                .sMoveLeft(Word.WdUnits.wdCell, 3)
                .sMoveDown()
                .sTypeText(Funzioni.myStr(DesignData.cShell, 2, 3, False), True)
                .sMoveRight(Word.WdUnits.wdCell)
                .sTypeText(Funzioni.myStr(DesignData.cTubi, 2, 3, False), True)
                .sMoveRight(Word.WdUnits.wdCell)
                .sTypeText(Funzioni.myStr(DesignData.cTS, 2, 3, False), True)
                .sMoveRight(Word.WdUnits.wdCell)
                .sTypeText(Funzioni.myStr(DesignData.cCassa, 2, 3, False), True)
            End With
        Else
            Stub = New StubW2000.clsSW2000
            Stub.SuperStampa(FileSt, Monitor.Motore.Inizio.VersOffice) 'Doc
            FileSt = Left(FileData, Len(FileData) - 4) & Funzioni.Str2Cifre(Altern - 1) & "SH.DOC"
            With Stub
                .sSaveAs(FileSt)
                testo = Monitor.Motore.Inizio.ReadIniFile("", "Azienda", "logo")
                If Len(testo) > 0 Then
                    .sLogo(Monitor.Motore.Inizio.Archdir & "\" & testo)
                    .sMoveRight(Unit:=Word.WdUnits.wdCharacter, Count:=1)
                End If
                ClientPlant = Monitor.Motore.Problem.ClientPlant
                If Len(ClientPlant) > 0 Then
                    n = InStr(ClientPlant, "-")
                    If n > 0 Then
                        Client = Left(ClientPlant, n - 1)
                        Plant = Right(ClientPlant, Len(ClientPlant) - n)
                    Else
                        n = CStr(InStr(ClientPlant, " "))
                        If n > 0 Then
                            Client = Left(ClientPlant, n - 1)
                            Plant = Right(ClientPlant, Len(ClientPlant) - n)
                        Else
                            Client = ClientPlant
                            Plant = ""
                        End If
                    End If
                Else
                    Client = "" : Plant = ""
                End If
                .sInsertAfter("Case", Config.DescrAlt)
                .sInsertAfter("Customer", Client)
                .sInsertAfter("Plant", Plant)
                .sInsertAfter("Item", Monitor.Motore.Problem.Item)
                If Config.Progetto = 0 Then
                    .sInsertAfter("Service", "(Design case)")
                Else
                    .sInsertAfter("Service", "(Verif. case)")
                End If
                .sInsertAfter("Qgas", Funzioni.myStr(Problem.Qgas, 4, 2, False))
                .sInsertAfter("Qvap", Funzioni.myStr(Problem.Qvap, 4, 2, False))
                If Config.Autom Then
                    .sInsertAfter("Composition", "see  ")
                    .sInsertAfter("MolWheight", Funzioni.myStr(Gas.prPesoMoc(0), 4, 2, False))
                Else
                    .sInsertAfter("Composition", "(phys. prop. inserted manually)")
                    .FontSize(7)
                    .sInsertAfter("MolWeight", "--")
                End If
                .sInsertAfter("Tgasin", Trim(Funzioni.myStr(Problem.Temp.Tgasin, 4, 1, False)))
                .sInsertAfter("Tgasout", Trim(Funzioni.myStr(Problem.Temp.Tgasout, 4, 1, False)))
                .sInsertAfter("Tvin", Trim(Funzioni.myStr(Problem.Temp.Tvin, 4, 1, False)))
                .sInsertAfter("Tvout", Trim(Funzioni.myStr(Problem.Temp.Tvout, 4, 1, False)))
                .sInsertAfter("CpGasIn", Funzioni.myStr(Gas.Cp(Problem.Temp.Tgasin, Problem.PressGasIn), 5, 2, False))
                .sInsertAfter("CpGasOut", Funzioni.myStr(Gas.Cp(Problem.Temp.Tgasout, Problem.PressGasIn), 5, 2, False))
                .sInsertAfter("CpVIn", Funzioni.myStr(Vap.Cp(Problem.Temp.Tvin, Problem.PressVapIn), 5, 2, False))
                .sInsertAfter("CpVout", Funzioni.myStr(Vap.Cp(Problem.Temp.Tvout, Problem.PressVapIn), 5, 2, False))
                .sInsertAfter("kGasIn", Funzioni.myStr(Gas.Conduc(Problem.Temp.Tgasin, Problem.PressGasIn), 5, 2, False))
                .sInsertAfter("kGasOut", Funzioni.myStr(Gas.Conduc(Problem.Temp.Tgasout, Problem.PressGasIn), 5, 2, False))
                .sInsertAfter("kVIn", Funzioni.myStr(Vap.Conduc(Problem.Temp.Tvin, Problem.PressVapIn), 5, 2, False))
                .sInsertAfter("kVout", Funzioni.myStr(Vap.Conduc(Problem.Temp.Tvout, Problem.PressVapIn), 5, 2, False))
                .sInsertAfter("vGasIn", Funzioni.myStr(Gas.Visco(Problem.Temp.Tgasin, Problem.PressGasIn) * 100000, 2, 5, False))
                .sInsertAfter("vGasOut", Funzioni.myStr(Gas.Visco(Problem.Temp.Tgasout, Problem.PressGasIn) * 100000, 2, 5, False))
                .sInsertAfter("vVIn", Funzioni.myStr(Vap.Visco(Problem.Temp.Tvin, Problem.PressVapIn) * 100000, 2, 5, False))
                .sInsertAfter("vVout", Funzioni.myStr(Vap.Visco(Problem.Temp.Tvout, Problem.PressVapIn) * 100000, 2, 5, False))
                .sInsertAfter("dGasIn", Funzioni.myStr(Gas.Dens(Problem.Temp.Tgasin, Problem.PressGasIn), 3, 3, False))
                .sInsertAfter("dGasOut", Funzioni.myStr(Gas.Dens(Problem.Temp.Tgasout, Problem.PressGasIn), 3, 3, False))
                .sInsertAfter("dVIn", Funzioni.myStr(Vap.Dens(Problem.Temp.Tvin, Problem.PressVapIn), 3, 3, False))
                .sInsertAfter("dVout", Funzioni.myStr(Vap.Dens(Problem.Temp.Tvout, Problem.PressVapIn), 3, 3, False))
                .sInsertAfter("pGasIn", Funzioni.myStr(Problem.PressGasIn, 5, 2, False))
                .sInsertAfter("pVIn", Funzioni.myStr(Problem.PressVapIn, 5, 2, False))
                .sInsertAfter("dpAllGas", Funzioni.myStr(Problem.dpAllGas / 100, 4, 3, False))
                .sInsertAfter("dpCalGas", Funzioni.myStr(Geom.DropGas / 100, 4, 3, False))
                .sInsertAfter("dpAllVap", Funzioni.myStr(Problem.dpAllVap / 100, 4, 3, False))
                .sInsertAfter("dpCalVap", Funzioni.myStr(Geom.DropVap / 100, 4, 3, False))
                .sInsertAfter("FoulGas", Funzioni.myStr(Problem.Routside, 1, 5, False))
                .sInsertAfter("FoulVap", Funzioni.myStr(Problem.Rinside, 1, 5, False))
                .sInsertAfter("UAllS", Funzioni.myStr(Problem.UAll, 4, 3, False))
                .sInsertAfter("UAllC", Funzioni.myStr(Problem.UAllC, 4, 3, False))
                .sInsertAfter("Watt", Funzioni.myStr(Problem.Watt / 1000, 8, 0, False))
                .sInsertAfter("Area", Funzioni.myStr(Geom.Area, 5, 2, False))
                .sInsertAfter("MTD", Funzioni.myStr(Problem.MDT, 5, 2, False))
                .sInsertAfter("SteamInlet", Funzioni.myStr(Geom.SteamInlet, 4, 2, False))
                .sInsertAfter("SteamOutlet", Funzioni.myStr(Geom.SteamOutlet, 4, 2, False))
                .sInsertAfter("GasOutlet", Funzioni.myStr(Geom.GasOutlet, 4, 2, False))
                .sInsertAfter("NumeroTubi", Trim(Str(Geom.NumeroTubi)))
                .sInsertAfter("TubeOD", Trim(Funzioni.myStr(Geom.DiamExtTubi, 2, 3, False)))
                If Geom.BWGTubi > 0 Then
                    .sInsertAfter("BWG", Trim(Str(Geom.BWGTubi)))
                Else
                    .sInsertAfter("BWG", "--")
                End If
                .sInsertAfter("TubeLength", Trim(Funzioni.myStr(Geom.LungDiritta * 1000, 5, 0, False)))
                .sInsertAfter("TubeThk", Trim(Funzioni.myStr(Geom.SpessTubi, 2, 3, False)))
                testo = Trim(Funzioni.myStr(Geom.PassoTubiInt, 3, 1, False))
                If Geom.TipoPassoInt = 0 Then testo = testo & " (tr.)" Else testo = testo & " (sq.)"
                .sInsertAfter("InPitch", testo)
                testo = Trim(Funzioni.myStr(Geom.PassoTubiExt, 3, 1, False))
                If Geom.TipoPassoExt = 0 Then testo = testo & " (tr.)" Else testo = testo & " (sq.)"
                .sInsertAfter("OutPitch", testo)
                .sInsertAfter("MatTubi", MatTubi.MatStr)
                .VaiInizio("Giovanni")
                .Testo(MatTubi.MatStr)
                .sInsertAfter("DocNo", Monitor.Motore.Problem.Doc)
                .ScriviBM("DesignData", "")
                .sMoveUp()
                Select Case Config.Tipo
                    Case 1, 2
                        .sTypeText("1")
                    Case 3
                        .sTypeText("2")
                End Select
                .sTypeText(Funzioni.myStr(DesignData.TShell, 3, 2, False), True)
                .sMoveRight(Word.WdUnits.wdCell)
                .sTypeText(Funzioni.myStr(DesignData.TTubi, 3, 2, False), True)
                .sMoveRight(Word.WdUnits.wdCell)
                .sTypeText(Funzioni.myStr(DesignData.TTS, 3, 2, False), True)
                .sMoveRight(Word.WdUnits.wdCell)
                .sTypeText(Funzioni.myStr(DesignData.TCassa, 3, 2, False), True)
                .sMoveLeft(Word.WdUnits.wdCell, 3)
                .sMoveDown()
                .sTypeText(Funzioni.myStr(DesignData.PShell, 3, 2, False), True)
                .sMoveRight(Word.WdUnits.wdCell)
                .sTypeText(Funzioni.myStr(DesignData.PTubi, 3, 2, False), True)
                .sMoveRight(Word.WdUnits.wdCell)
                .sTypeText(Funzioni.myStr(DesignData.PTS, 3, 2, False), True)
                .sMoveRight(Word.WdUnits.wdCell)
                .sTypeText(Funzioni.myStr(DesignData.PCassa, 3, 2, False), True)
                .sMoveLeft(Word.WdUnits.wdCell, 3)
                .sMoveDown()
                .sTypeText(Funzioni.myStr(DesignData.cShell, 2, 3, False), True)
                .sMoveRight(Word.WdUnits.wdCell)
                .sTypeText(Funzioni.myStr(DesignData.cTubi, 2, 3, False), True)
                .sMoveRight(Word.WdUnits.wdCell)
                .sTypeText(Funzioni.myStr(DesignData.cTS, 2, 3, False), True)
                .sMoveRight(Word.WdUnits.wdCell)
                .sTypeText(Funzioni.myStr(DesignData.cCassa, 2, 3, False), True)
            End With
        End If
        Exit Sub
ExClose: On Error Resume Next
        If Monitor.Motore.Inizio.VersOffice < 11 Then
            Stub9.sClose()
        Else
            Stub.sClose()
        End If
        Exit Sub
ErrCD:
        testo = "Impossibile salvare il documento Word " & FileSt & "." & vbCrLf
        testo = testo & "E' possibile che esso sia già aperto in WinWord." & vbCrLf
        testo = testo & "In tal caso attivare WinWord, chiudere il documento e poi riprovare."
        Select Case MsgBox(testo, MsgBoxStyle.RetryCancel + MsgBoxStyle.Information, "Surrisc")
            Case MsgBoxResult.Retry : Resume
            Case MsgBoxResult.Cancel : Resume ExClose
        End Select
    End Sub

    Public Sub DesTemp()
        On Error GoTo ErrDT
10:     If DesignData.TTubi < 1 Then DesignData.TTubi = Surr.TempLMc
20:     If DesignData.TShell < 1 Then DesignData.TShell = Surr.TempLMf
30:     If DesignData.TCassa < 1 Then DesignData.TCassa = Surr.TempLTf
40:     If DesignData.TTS < 1 Then DesignData.TTS = Surr.TempLMf
50:     If DesignData.TTS < 1 Then DesignData.TTS = Surr.TempLTc
60:     If DesignData.PTubi = 0 Then DesignData.PTubi = Problem.PressVapIn - 1
70:     If DesignData.PShell = 0 Then DesignData.PShell = Problem.PressGasIn - 1
80:     If DesignData.PTS = 0 Then DesignData.PTS = Problem.PressVapIn - 1
90:     If DesignData.PCassa = 0 Then DesignData.PCassa = Problem.PressVapIn - 1
        Exit Sub
ErrDT:
        Select Case Erl()
            Case 10 : DesignData.TTubi = 0
            Case 20 : DesignData.TShell = 0
            Case 30 : DesignData.TCassa = 0
            Case 40 : DesignData.TTS = 0
            Case 50 : DesignData.TTS = 0
            Case 60 : DesignData.PTubi = 0
            Case 70 : DesignData.PShell = 0
            Case 80 : DesignData.PTS = 0
            Case 90 : DesignData.PCassa = 0
        End Select
        Resume Next
    End Sub
    Public Sub IniziaVap()
        Vap = New VapAcqua.clsVapAcqua
        Vap.DoveMotore = Monitor.Motore
        Vap.Inizia()
        If Not Prop Is Nothing Then Prop.Inizia(False)
    End Sub
    Public Function GenFileTraccia() As String
        Dim File As String = ""
        Dim Path As String
        Select Case Monitor.Motore.Inizio.LavoriSciolti
            Case False
                Path = Monitor.Motore.Inizio.Workdir & "\A" & Trim(job.Comm.Arch)
                File = Path & "\" & job.Comm.Ind.Item(job.Comm.indice).Data.File & ".INP"
            Case True
                File = Left(FileData, Len(FileData) - 4) & ".INP"
        End Select
        GenFileTraccia = File
    End Function
    Public Sub Genera(ByRef File As String)
        Dim ifl As Short
        Trasferisci()
        ifl = FreeFile()
        FileOpen(ifl, File, OpenMode.Output)
        PrintLine(ifl, Monitor.Motore.Problem.ClientPlant)
        PrintLine(ifl, Str(MatTubi.Indmat))
        Print(ifl, Left(File, Len(File) - 4) & ",")
        Print(ifl, DaTos.di0 & ",")
        Print(ifl, DaTos.dtin & ",")
        Print(ifl, DaTos.dtout & ",")
        Print(ifl, DaTos.roin & ",")
        Print(ifl, DaTos.win & ",") ' DaTos(0).dt(6)
        Print(ifl, DaTos.roout & ",") ' DaTos(0).dt(7)
        Print(ifl, DaTos.wout & ",") ' DaTos(0).dt(8)
        Print(ifl, DaTos.y0in & ",") ' DaTos(0).dt(9)
        Print(ifl, DaTos.dt(10) & ",") 'DaTos.y0out; ","; ' DaTos(0).dt(10)
        Print(ifl, DaTos.ktotal & ",") ' DaTos(0).dt(11)
        Print(ifl, DaTos.TipoPasso & ",") 'DaTos(0).dt(12)
        Print(ifl, DaTos.PassoFascio & ",") ' DaTos(0).dt(13)
        Print(ifl, DaTos.TipoFascio & ",") ' DaTos(0).dt(14)
        Print(ifl, DaTos.dtubo & ",") ' DaTos(0).dt(15)
        Print(ifl, DaTos.Passo & ",") ' DaTos(0).dt(16)
        Print(ifl, DaTos.pdiaf & ",") 'DaTos(0).dt(17)
        Print(ifl, DaTos.p1 & ",") 'DaTos(0).dt(18)
        Print(ifl, DaTos.matub & ",") 'DaTos(0).dt(19)
        Print(ifl, DaTos.dt(20) & ",") 'DaTos.js DaTos(0).dt(20)
        '        Select Case DaTos(0).jsdis
        '             Case 1 'sald+mand
        '                 DaTos(0).js = 1
        '             Case 2 'sald+mand legg
        '                 DaTos(0).js = 1
        '             Case 3 'mandrinato
        '                 DaTos(0).js = 0
        '        End Select
        Print(ifl, DaTos.radiu & ",") ' DaTos(0).dt(21)
        Print(ifl, DaTos.dt(22) & ",") ' IncrementoDiametro
        Print(ifl, DaTos.tcava & ",") ' DaTos(0).dt(23)
        Print(ifl, DaTos.Spmm & ",") ' DaTos(0).dt(24)
        Print(ifl, DaTos.Spbwg & ",") ' DaTos(0).dt(25)
        Print(ifl, DaTos.Tublu & ",") ' DaTos(0).dt(26)
        Print(ifl, DaTos.TipoTolleranza & ",") 'DaTos(0).dt(27)
        Print(ifl, DaTos.TipoGiunto & ",") 'DaTos(0).dt(28)
        Print(ifl, DaTos.dt(29) & ",") '29
        Print(ifl, DaTos.dt(30) & ",") '30
        Print(ifl, DaTos.dt(31) & ",") '31
        Print(ifl, DaTos.dt(32) & ",") '32
        Print(ifl, DaTos.dt(33) & ",") '33
        Print(ifl, DaTos.cinter & ",") ' = DaTos(1).dt(34) / 2
        Print(ifl, DaTos.ISEAL & ",") ' DaTos(0).dt(35)
        Print(ifl, DaTos.Nrod & ",") ' DaTos(0).dt(36)
        Print(ifl, DaTos.dt(37) & ",") '37
        Print(ifl, DaTos.dt(38) & ",") '38
        Print(ifl, DaTos.dt(39) & ",") '39
        Print(ifl, DaTos.dt(40) & ",") '40
        Print(ifl, DaTos.dt(41) & ",") '41
        Print(ifl, DaTos.coriint & ",") ' DaTos(0).dt(42)
        Print(ifl, DaTos.passoint & ",") ' DaTos(0).dt(43)
        Print(ifl, DaTos.coriext & ",") ' DaTos(0).dt(44)
        Print(ifl, 0 & ",") '45
        PrintLine(ifl, Monitor.Motore.Problem.ClientPlant & Space(1))
        PrintLine(ifl, Monitor.Motore.Problem.Item)
        PrintLine(ifl, Monitor.Motore.Problem.Doc)
        PrintLine(ifl, 0) 'ips2
        PrintLine(ifl, DaTos.otimp)
        PrintLine(ifl, DaTos.Interf) ' DaTos(0).dt(47)
        PrintLine(ifl, DaTos.GapCurve) ' DaTos(0).dt(48)
        PrintLine(ifl, DaTos.Varco) 'DaTos(0).dt(49)
        FileClose(ifl)
    End Sub

    Private Sub Trasferisci()
        '    DaTos.di0
        '    DaTos.dtin
        '    DaTos.dtout
        '    DaTos.roin
        '    DaTos.win ' DaTos(0).dt(6)
        '    DaTos.roout ' DaTos(0).dt(7)
        '    DaTos.wout ' DaTos(0).dt(8)
        '    DaTos.y0in ' DaTos(0).dt(9)
        '    DaTos.y0out ' DaTos(0).dt(10)
        DaTos.ktotal = Geom.NumeroTubi ' DaTos(0).dt(11)
        Select Case Geom.TipoPassoExt
            Case 0 : DaTos.TipoPasso = 1 ' Geom.TipoPassoExt  'DaTos(0).dt(12)
            Case 1 : DaTos.TipoPasso = 3
        End Select
        DaTos.PassoFascio = 2 ' DaTos(0).dt(13)'Tipo tracciatura
        DaTos.TipoFascio = 4 ' DaTos(0).dt(14)
        DaTos.dtubo = Geom.DiamExtTubi ' DaTos(0).dt(15)
        DaTos.Passo = Geom.PassoTubiExt ' DaTos(0).dt(16)
        'DaTos.pdiaf = Diaframmi.Passo 'DaTos(0).dt(17)
        'DaTos.p1 = Diaframmi.Passo1 'DaTos(0).dt(18)
        DaTos.matub = 1 '3 - Tubi.TipoMateriale 'DaTos(0).dt(19)
        '    DaTos.js 'DaTos(0).dt(20)
        '    DaTos.radiu ' DaTos(0).dt(21)
        '    DaTos.jincr ' DaTos(0).dt(22)
        '    DaTos.tcava ' DaTos(0).dt(23)
        DaTos.Spmm = Geom.SpessTubi ' DaTos(0).dt(24)
        '    DaTos.Spbwg ' DaTos(0).dt(25)
        DaTos.Tublu = 1000 * Geom.LungDiritta ' DaTos(0).dt(26)
        'DaTos.Tipo = Tubi.Tolleranza 'DaTos(0).dt(27)
        '    DaTos.jsdis 'DaTos(0).dt(28)
        DaTos.cinter = Geom.ITLout ' DaTos(1).dt(34) / 2
        '    DaTos.ISEAL ' DaTos(0).dt(35)
        '    DaTos.Nrod ' DaTos(0).dt(36)
        DaTos.dt(41) = 1 ' DatiPrg(0).NPassMant
        DaTos.coriint = Geom.ITLint ' DaTos(0).dt(42)
        DaTos.passoint = Geom.PassoTubiInt ' DaTos(0).dt(43)
        DaTos.coriext = Geom.OTLint ' DaTos(0).dt(44)
        DaTos.otimp = Geom.OTLout
        DaTos.Interf = 0 ' DaTos(0).dt(47)
        DaTos.GapCurve = 2 ' DaTos(0).dt(48)
        '    DaTos.Varco 'DaTos(0).dt(49)
    End Sub
    Public Sub LeggiDT(ByRef FileTrac As String)
        Lancio.Legacy.Serialization.LegacyBinarySerializer.EnsureEnabled()
        If FileTrac.Length = 0 Then Exit Sub
        If Not IO.File.Exists(FileTrac) Then Exit Sub
        Dim fs As New FileStream(FileTrac, FileMode.Open)
        Dim bf As New Lancio.Legacy.Serialization.LegacyBinarySerializer
        Try
            Dim p As RoutBase1.clsProblem = CType(bf.Deserialize(fs), RoutBase1.clsProblem)
            DaTos = CType(bf.Deserialize(fs), traccia.clsTracciatura.typDaTos)
        Catch e As Runtime.Serialization.SerializationException
            MsgBox(e.Message)
            Exit Sub
        End Try
        fs.Close()
        'If Val(DaTos.dts(1)) > 0 Then GenMem.Mater.Mat(1).Indmat = Val(DaTos.dts(1))
        If DaTos.dtubo > 0 Then Geom.DiamExtTubi = DaTos.dtubo
        If DaTos.Tublu > 0 Then Geom.LungDiritta = DaTos.Tublu / 1000
        If DaTos.dt(24) > 0 Then Geom.SpessTubi = DaTos.dt(24)
        If DaTos.dt(27) > 0 Then
            'Tubi.Tolleranza = DaTos.dt(27) '1 MW 2 AW
            'Tubi.TipoMateriale = 3 - DaTos.matub '1 INOX 2 NO
            'If Tubi.TipoMateriale = 3 Then Tubi.TipoMateriale = 2
        End If
        'If DaTos.JSHELL > 0 Then TipoFascio = DaTos.JSHELL
        Select Case DaTos.dt(12)
            Case 1, 2 : Geom.TipoPassoExt = 0
                Geom.TipoPassoInt = 0
            Case 3, 4 : Geom.TipoPassoExt = 1
                Geom.TipoPassoInt = 1
        End Select
        'If DaTos.dt(12) > 0 Then Geom.TipoPassoExt = DaTos.dt(12)
        Geom.OTLout = DaTos.OTL
        'Tubi.yUltimFila = Abs(DaTos.Y(1))
        'Tubi.yPrimaFila = Abs(DaTos.Y(DaTos.kymax))
        'Tubi.NumeroSettori = DaTos.nset
        If DaTos.ktotal > 0 Then Geom.NumeroTubi = DaTos.ktotal
        If DaTos.Passo > 0 Then Geom.PassoTubiExt = DaTos.Passo
        If DaTos.coriint > 0 Then Geom.ITLint = DaTos.coriint
        If DaTos.coriext > 0 Then Geom.OTLint = DaTos.coriext
        If DaTos.cinter > 0 Then Geom.ITLout = 2 * DaTos.cinter
        'If DaTos.dt(41) > 0 Then DatiPrg(0).NPassMant = DaTos.dt(41)
        'If DaTos.jt > 0 Then DatiPrg(0).NPassTubi = DaTos.jt
    End Sub
    Public Sub Propaga()
        Dim i, ifl As Short
        Dim tt As typTuttiDati = New typTuttiDati
        ifl = FreeFile()
        FileOpen(ifl, FileData, OpenMode.Random, , , Len(tt))
        For i = 1 To nAlt
            If i <> Altern Then
                FileGet(ifl, tt, i)
                With tt
                    .g = Geom
                    .p.Item = Problem.Item
                    .c.TipoCalc = Config.TipoCalc
                    .c.Tipo = Config.Tipo
                    .c.NCrossCieco = Config.NCrossCieco
                    .c.NCross = Config.NCross
                End With
                FilePut(ifl, tt, i)
            End If
        Next
        FileClose(ifl)
    End Sub
    Public Sub CalcTvapo(ByRef fi As Single)
        Dim Pow, Guess, Tv As Single
        Dim Qtot, Pow1 As Single
        Surr.PortLM = fi * Problem.Qgas
        Tv = Problem.Temp.Tvout
        Guess = Surr.TempLTf + (Tv - Surr.TempLTf) * fi
        Pow = Problem.Watt * fi
        Do
            Problem.Temp.Tvout = Guess
            EntalpVap(Qtot)
            Pow1 = Qtot * Surr.PortLT
            If System.Math.Abs(Pow - Pow1) / Pow1 < 0.001 Then Exit Do
            Guess = Guess + (Pow - Pow1) / Pow1 * (Guess - Problem.Temp.Tvin)
        Loop
        Surr.TempLTc = Guess
    End Sub
    Public Sub CalcolaFarf(ByRef Index As Short, ByRef i As Short)
        Dim T2, T1, p1, P2 As Single
        Dim AreaFori, AreaValv, kFarf As Single
        Dim dp2, rhoin, ang, dp1, dp3 As Single
        Dim ugas2, ugas1, delta As Single
        Dim segno, segnov As Single
        AreaValv = PI * (Geom.FiValv / 1000) ^ 2 / 4
        AreaFori = Geom.AreaForiValv
        If AreaValv * AreaFori <= 0 Then Exit Sub
        T1 = Surr.TempLMc
        p1 = Problem.PressGasIn
        T2 = Reg(Index).Tgprima(i)
        P2 = p1 - dpgastot / 100000
        rhoin = 1 / Prop.VolGas(T1)
        ugas1 = Problem.Qgas * (100 - Reg(Index).Bypass(i)) / 100 / rhoin / AreaValv
        If ugas1 = 0 Then ugas1 = 0.0000000001
        ugas2 = Problem.Qgas * (100 - Reg(Index).Bypass(i)) / 100 / rhoin / AreaFori
        If ugas2 = 0 Then ugas2 = 0.0000000001
        dp3 = 2 * rhoin * ugas2 ^ 2 / 2
        dp1 = dpgastot - dp3
        If dp1 <= 0 And i > 8 Then
            MsgBox("Area fori troppo piccola")
            Exit Sub
        End If
        ang = 60
        delta = 2
        Do
            kFarf = Papillon(ang, 0)
            dp2 = (2 + kFarf) * rhoin * ugas1 ^ 2 / 2
            If System.Math.Abs(dp2 - dp1) / dpgastot < 0.001 Then Exit Do
            segno = System.Math.Sign(dp2 - dp1)
            ang = ang - segno * delta
            If segno * segnov = -1 Then delta = delta / 2
            segnov = segno
            If ang >= 89 Then ang = 90 : Exit Do
            If ang <= 0 Then ang = -1 : Exit Do
        Loop
        Reg(Index).Angolo(i) = ang
    End Sub
    Public Sub IniziaFarf()
        ' da Idl'chick Chap.IX, Diagramme 9.4
        Dim i As Short
        Dim A1, A2 As Single
        Angoli(0) = 0
        Angoli(1) = 5
        Angoli(2) = 10
        Angoli(3) = 15
        Angoli(4) = 20
        Angoli(5) = 25
        Angoli(6) = 30
        Angoli(7) = 40
        Angoli(8) = 50
        Angoli(9) = 60
        Angoli(10) = 65
        Angoli(11) = 70
        Angoli(12) = 90
        kFarfalle(0, 0) = 0
        kFarfalle(1, 0) = 0.24
        kFarfalle(2, 0) = 0.52
        kFarfalle(3, 0) = 0.9
        kFarfalle(4, 0) = 1.54
        kFarfalle(5, 0) = 2.51
        kFarfalle(6, 0) = 3.91
        kFarfalle(7, 0) = 10.8
        kFarfalle(8, 0) = 32.6
        kFarfalle(9, 0) = 118
        kFarfalle(10, 0) = 256
        kFarfalle(11, 0) = 751
        kFarfalle(12, 0) = 10000000000.0#
        kFarfalle(0, 1) = 0
        kFarfalle(1, 1) = 0.28
        kFarfalle(2, 1) = 0.45
        kFarfalle(3, 1) = 0.77
        kFarfalle(4, 1) = 1.34
        kFarfalle(5, 1) = 2.16
        kFarfalle(6, 1) = 3.54
        kFarfalle(7, 1) = 9.3
        kFarfalle(8, 1) = 24.9
        kFarfalle(9, 1) = 77.4
        kFarfalle(10, 1) = 158
        kFarfalle(11, 1) = 368
        kFarfalle(12, 1) = 10000000000.0#
        For i = 0 To 1
            A1 = Angoli(10) * PI / 180
            A2 = Angoli(11) * PI / 180
            'esponente della tg
            kFarfalle(13, i) = System.Math.Log(kFarfalle(10, i) / kFarfalle(11, i)) / System.Math.Log(System.Math.Tan(A1) / System.Math.Tan(A2))
            'coefficiente della tg
            kFarfalle(14, i) = kFarfalle(10, i) / System.Math.Tan(A1) ^ kFarfalle(13, i)
        Next
    End Sub
    Public Function Papillon(ByRef a As Single, ByRef i As Short) As Single
        Dim j As Short
        Dim ar As Single
        If i < 0 Or i > 1 Then i = 0
        For j = 1 To 12
            If Angoli(j) >= a Then
                If j > 10 Then
                    If a <= 89.9 Then
                        ar = a * PI / 180
                        Papillon = kFarfalle(14, i) * System.Math.Tan(ar) ^ kFarfalle(13, i)
                    Else
                        Papillon = 1.0E+30
                    End If
                Else
                    Papillon = kFarfalle(j - 1, i) + (kFarfalle(j, i) - kFarfalle(j - 1, i)) * (a - Angoli(j - 1)) / (Angoli(j) - Angoli(j - 1))
                End If
                Exit Function
            End If
        Next
    End Function


    Public Sub Warn1()
        Dim testo As String
        testo = "Non è stato definito il tipo di apparecchio" & vbCrLf
        testo = testo & "nella prima scheda dei dati di progetto." & vbCrLf
        testo = testo & "E' necessario cliccare sul pulsante)."
        MsgBox(testo, MsgBoxStyle.Information, "Surrisc")
    End Sub
End Module