Option Strict On
Option Explicit On 
Imports RoutBase1.clsInizio
Imports System.Data
Imports System.Data.OleDb
Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary 'Namespace for BinaryFormatter
Class clsUtente
    Public Nome As String
    Public Password As String
End Class
Module GenLancio
    Public Const gstrFeatures As String = "Features"
    Public Const gstrSi As String = "Si"
    Public Const gstrNo As String = "No"
    '------------------------------------------------
    Public RadiceHelp As String '= "Lancio.chm"
    Public ErrCommesse As Boolean
    Public UltimoAggiornamento As Short
    Public Utente As clsUtente
    Public Programma(30) As Integer
    Public NomeProg(30) As String
    Public GiaFatto, GiafattoB As Boolean
    Public Abilitato As Boolean
    Public Convalidato As Short
    Public NonValido As Boolean
    '1 WRCB
    '2 Flange
    '3 ASME-VIP
    '4 PTFF
    '5 UTEMA
    '6 HTRI
    '7 FBM
    '8  Sketch
    '9 PHILLIPS
    '10 BSDD
    '11 SELVA
    '12 DataSheet
    '13 PANDA
    '14 HTRI vb
    Public MyDatabase As OleDbConnection
    Public cmd As OleDbDataAdapter
    Public CB As OleDbCommandBuilder
    Public MyTable As DataTable
    Public MyFile As String
    Public Routines As RoutBase1.Routines
    Public Libgra As Grafica.LibGra
    '1 WRCB 2 FLANGE 3 ASME_VIP 4 PTFF 5 UTEMA
    '6 HTRI 7 FBM 8 SKETCH 9 GO.BAT
    Public Nojobs As Short
    Public ProtoTyp As String
    ''''Public WPS As Sald.clsWPS
    'Public Util As FBMUtil.clsUtil
    '''' Public objGest As Gest.clsGest
    Public Monitor As clsMonitor
    Public objTraccia As traccia.clsTracciatura
    Public objBSDD As Saddles.clsBSDD
    Public objASME As AsmeVip.CalcASME
    Public objDataSheet As DataSheet.clsDataSheet
    'Public objSURR As Surrisc.clsSurrisc
    'Public objBabC As BabCock.Calcoli
    Public objWRCB As Wrcb.clsWrcb
    ''''   Public objDiap As OreLav.clsDiap
    'Public objventil As Ventil.clsVentil
    'Public objLigTem As LigTem.clsLigTemp
    'Public objWallT As Fire.clsWallT
    'Public objPPSM As PPSM.clsPPSM
    Public orec As Orecchia.Calc_Orecchia
    Public objSerraggio As Tiranti.Serraggio
    'Public Bre As BreLock.clsBreLoc
    'Public con As PrgConi.calcConi
    Public EsitoStd As Short
    Public Const Conn As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source="
    Public Const ConnFine As String = ";Persist Security Info=False"
    <Serializable()> Structure Licenza
        Dim Provvisorio As Boolean
        Dim DataScad As Date
        Public QuestoComputer As String
    End Structure
    <System.STAThread()>
    Public Sub Main()
        LegacyTextLayoutAudit.StartFromEnvironment()
        Dim i, prgsingolo As Short
        Dim strU As String
        Threading.Thread.CurrentThread.CurrentCulture = New _
        System.Globalization.CultureInfo(Threading.Thread.CurrentThread.CurrentCulture.Name, False)
        Monitor = New Lancio.clsMonitor
        With Monitor.Motore.Inizio
            i = LegacyStartupConfiguration.Initialize(Monitor.Motore.Inizio)
            EsitoStd = i
            If i = 3 Then
                .InRete = False
            ElseIf i = 1 Then
                NonValido = True
                MsgBox("Non e' stato selezionato un INI valido. Selezionare la propria copia configurata di LancioNET.ini oppure impostare LANCIO_INI. Il programma sara' arrestato.", MsgBoxStyle.Critical)
                Exit Sub
            ElseIf i > 0 Then
                NonValido = True
                MsgBox("Si sono determinati errori durante l'inizializzazione. Programma arrestato", MsgBoxStyle.Critical)
                Exit Sub
            End If
            '   If Not .CheckDir Then NonValido = True: Exit Sub
            If Not .ReadIniFile("", "Avvio", "CheckLicenza") = "No" Then
                Dim licensed As Boolean
                Try
                    licensed = Licenza_Renamed()
                Catch ex As System.Runtime.Serialization.SerializationException
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "Avvio Lancion: formato originale disabilitato")
                    NonValido = True
                    Exit Sub
                End Try
                If Not licensed Then
                    NonValido = True
                    Monitor = Nothing
                    Exit Sub
                End If
                MyFile = .Basedir & "\HELICH.EXE"
                If System.IO.File.Exists(MyFile) Then Kill(MyFile)
            End If
            GiaFatto = False : GiafattoB = False
            RadiceHelp = .AppLancio & "\BIN\Lancio.chm"
            If Not .ReadIniFile("", "Avvio", "CheckSystem") = "No" Then
                Monitor.CheckSystem()
                Form1.DefInstance.mnuAvvio.Checked = True
            Else
                Form1.DefInstance.mnuAvvio.Checked = False
            End If
            .ImmedStam = 1
            .TipoStam = 3
            ' .BrtSet()
            strU = .ReadIniFile("", "Parametri", "UltimoAggiornamento")
            If strU = "" Then
                strU = " 1"
                .WriteIniFile("", "Parametri", "UltimoAggiornamento", strU)
            End If
            UltimoAggiornamento = CShort(Val(strU))
            strU = .ReadIniFile("", "Avvio", "LanciaProg")
            If Len(strU) = 0 Then strU = "0"
            prgsingolo = CShort(Val(strU))
        End With
        Routines = New RoutBase1.Routines
        Routines.DoveInizio = Monitor.Motore.Inizio
        Libgra = New Grafica.LibGra
        Libgra.DoveMotore = Monitor.Motore
        Libgra.DoveRoutines = Routines
        Try
            If prgsingolo = 0 Then
                Form1.DefInstance.ShowDialog()
            Else
                Form1.DefInstance.LanciaProg(prgsingolo)
            End If
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Public Function Licenza_Renamed() As Boolean
        Lancio.Legacy.Serialization.LegacyBinarySerializer.EnsureEnabled()
        Dim File As String
        Dim Lic As Licenza ', Lic0 As ValueType
        Dim Scad As Date
        Dim n As Long
        Dim Testo As String
        Licenza_Renamed = True
        File = Monitor.Motore.Inizio.Basedir & "\HELICG.EXE"
        'ifl = FreeFile()
        Dim Esiste As Boolean = IO.File.Exists(File)
        Dim fs As New FileStream(File, FileMode.OpenOrCreate)
        Dim bf As New Lancio.Legacy.Serialization.LegacyBinarySerializer
        If Not Esiste Then
            Lic.Provvisorio = True
            Scad = DateAdd(Microsoft.VisualBasic.DateInterval.Month, 1, Now)
            Lic.DataScad = Scad
            Lic.QuestoComputer = CStr(Monitor.Motore.Inizio.QuestoComputer)
            bf.Serialize(fs, Lic)
            fs.Close()
        Else
            Lic = CType(bf.Deserialize(fs), Licenza)
            fs.Close()
            If Lic.Provvisorio Then
                n = DateDiff(Microsoft.VisualBasic.DateInterval.Day, Now, Lic.DataScad)
                If n <= 0 Then
                    Testo = Monitor.Motore.HelpStringaG(IDHS.LIC_MSG1)
                    MsgBox(Testo, MsgBoxStyle.Critical, "Lancio")
                    Licenza_Renamed = False
                End If
            Else
                If Not Trim(Lic.QuestoComputer) = Trim(CStr(Monitor.Motore.Inizio.QuestoComputer)) Then
                    Testo = Monitor.Motore.HelpStringaG(IDHS.LIC_MSG2)
                    MsgBox(Testo, MsgBoxStyle.Critical, "Lancio")
                    Licenza_Renamed = False
                End If
            End If
        End If
    End Function
End Module