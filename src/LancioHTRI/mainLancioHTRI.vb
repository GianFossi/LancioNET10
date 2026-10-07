Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary
Module mainLancioHTRI
    Friend Monitor As clsMonitor
    Friend EsitoStd As Short
    Friend NonValido As Boolean
    Friend MyFile As String
    Friend objHTRI As HTRI.clsHTRI
    Friend Routines As RoutBase1.Routines
    Friend LibGra As Grafica.LibGra
    <Serializable()> Structure Licenza
        Dim Provvisorio As Boolean
        Dim DataScad As Date
        Public QuestoComputer As String
    End Structure
    <System.STAThread()>
    Public Sub Main()
        Threading.Thread.CurrentThread.CurrentCulture = New _
        System.Globalization.CultureInfo(Threading.Thread.CurrentThread.CurrentCulture.Name, False)
        Monitor = New clsMonitor
        With Monitor.Motore.Inizio
            EsitoStd = LegacyStartup.Initialize(Monitor.Motore.Inizio)
            If EsitoStd = 3 Then
                .InRete = False
            ElseIf EsitoStd = 1 Then
                NonValido = True
                MsgBox("Non è stato trovato il file di inizializzazione, che dovrebbe trovarsi nella directory di sistema. Il programma sarà arrestato.", MsgBoxStyle.Critical)
                Exit Sub
            ElseIf EsitoStd > 0 Then
                NonValido = True
                MsgBox("Si sono determinati errori durante l'inizializzazione. Programma arrestato", MsgBoxStyle.Critical)
                Exit Sub
            End If
            '   If Not .CheckDir Then NonValido = True: Exit Sub
            If Not .ReadIniFile("", "Avvio", "CheckLicenza") = "No" Then
                If Not CheckLicenza() Then
                    NonValido = True
                    If Not Monitor Is Nothing Then Monitor.Motore = Nothing
                    Monitor = Nothing
                    Exit Sub
                End If
                MyFile = .Basedir & "\HELICH.EXE"
                If System.IO.File.Exists(MyFile) Then Kill(MyFile)
            End If
            If Not .ReadIniFile("", "Avvio", "CheckSystem") = "No" Then
                Monitor.CheckSystem()
            End If
            .ImmedStam = 1
            .TipoStam = 3
            ' .BrtSet()
        End With
        Routines = New RoutBase1.Routines
        Routines.DoveInizio = Monitor.Motore.Inizio
        Libgra = New Grafica.LibGra
        Libgra.DoveMotore = Monitor.Motore
        Libgra.DoveRoutines = Routines
        If (UBound(Diagnostics.Process.GetProcessesByName(Diagnostics.Process.GetCurrentProcess.ProcessName)) > 0) Then
            MsgBox("Esiste già un'istanza in esecuzione di Lancio", MsgBoxStyle.Critical, "Lancio")
            Exit Sub
        End If
        If Not objHTRI Is Nothing Then
            MsgBox("Esiste già un'istanza di ISA in esecuzione")
            Exit Sub
        End If
        objHTRI = New HTRI.clsHTRI
        objHTRI.DoveMotore = Monitor.Motore
        objHTRI.DoveRoutines = Routines
        objHTRI.DoveFunzioni = Libgra
        objHTRI.Esegui()
    End Sub
    Public Function CheckLicenza() As Boolean
        Lancio.Legacy.Serialization.LegacyBinarySerializer.EnsureEnabled()
        Dim File As String
        Dim Lic As Licenza ', Lic0 As ValueType
        Dim Scad As Date
        Dim n As Long
        Dim Testo As String
        CheckLicenza = True
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
                    Testo = "Errore" ' Monitor.Motore.HelpStringaG(IDHS.LIC_MSG1)
                    MsgBox(Testo, MsgBoxStyle.Critical, "Lancio")
                    CheckLicenza = False
                End If
            Else
                If Not Trim(Lic.QuestoComputer) = Trim(CStr(Monitor.Motore.Inizio.QuestoComputer)) Then
                    Testo = "Errore" ' Monitor.Motore.HelpStringaG(IDHS.LIC_MSG2)
                    MsgBox(Testo, MsgBoxStyle.Critical, "Lancio")
                    CheckLicenza = False
                End If
            End If
        End If
    End Function
End Module
