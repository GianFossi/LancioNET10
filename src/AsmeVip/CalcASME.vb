Option Strict Off
Option Explicit On 
Imports System.Windows.Forms
Public Class CalcASME
    Public Out As Boolean
    Private ReadOnly startupTimer As System.Diagnostics.Stopwatch = System.Diagnostics.Stopwatch.StartNew()
    Private ReadOnly startupStages As New System.Collections.Generic.List(Of String)
    Public Sub New()
        MyBase.New()
        Monitor = New clsMonitor
        MaxNozAct = 2 * MAXNOZZ
        RidimensionaTutto()
        myAssembly = Me.GetType.Assembly
        ' rmTestiAsmeVip = New _
        '  System.Resources.ResourceManager("AsmeVip.TestiAsmeVip", myAssembly)
        rmHelpStrings = New _
          System.Resources.ResourceManager("AsmeVip.ProjectResources", myAssembly)
        rmHelpTopics = New _
          System.Resources.ResourceManager("AsmeVip.HelpTopics", myAssembly)
        GlobalRoutines = New RoutBase1.clsTrigon
        objASME = Me
        RecordStartupStage("costruttore")
    End Sub
    Public Sub Dispose()
        myAssembly = Nothing
        rmHelpStrings = Nothing
        rmHelpTopics = Nothing
        GlobalRoutines = Nothing
        clsInizio = Nothing
        inizio = Nothing
        objASME = Nothing
        If Not Monitor Is Nothing Then Monitor.Motore = Nothing
        clsProblem = Nothing
        Routines = Nothing
        Libgra = Nothing
        Monitor = Nothing
        RadiceHelp = Nothing
    End Sub
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
    Public WriteOnly Property DoveRoutines() As RoutBase1.Routines
        Set(ByVal Value As RoutBase1.Routines)
            Routines = Value
        End Set
    End Property
    Public WriteOnly Property DoveFunzioni() As Grafica.LibGra
        Set(ByVal Value As Grafica.LibGra)
            Libgra = Value
        End Set
    End Property
    Public WriteOnly Property DoveMotore() As RoutBase1.clsMotore
        Set(ByVal Value As RoutBase1.clsMotore)
            Monitor.Motore = Value
            Monitor.Motore.InitProb("ASME")
            clsProblem = Monitor.Motore.Problem
            clsInizio = Monitor.Motore.Inizio
            inizio = Monitor.Motore.Inizio
            RadiceHelp = inizio.AppLancio & rmHelpStrings.GetString("Helpfile") '"\BIN\AsmeVip.chm"
            Dim InitLibmat As LibMat.clsInitLibMat = New LibMat.clsInitLibMat(Monitor.Motore)
            RecordStartupStage("dipendenze")
        End Set
    End Property
    Public Sub EseguiSciolto()
        Dim i As Short
        AddDistinta = 0
        job = New RoutBase1.clsjob(Monitor.Motore)
        job.Comm.NumAs = 1
        For i = 1 To job.Comm.Ind.Count
            job.Comm.Ind(i).Data.pag = 0 : job.Comm.Ind(i).Data.File = Chr(32) ' "   ":
            job.Comm.Ind(i).Data.Assieme = New String(" ", 30) : job.Comm.Ind(i).Data.Qta = 0
        Next i
        job.Comm.Ind(1).Data.File = "$"
        job.Comm.peso = 0.0!
        job.AggiungiCom("Sciolt")
        RecordStartupStage("commessa iniziale")
        'Monitor.Motore.inizio.LavoriSciolti = True
        mioApert = New Apert
        RecordStartupStage("costruzione finestra")
        mioApert.Show()
        RecordStartupStage("visualizzazione finestra")
        WriteStartupReport()
    End Sub
    Private Sub RecordStartupStage(name As String)
        startupStages.Add(name & "=" & startupTimer.ElapsedMilliseconds.ToString() & "ms")
    End Sub
    Private Sub WriteStartupReport()
        Try
            Dim reportDirectory = IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "LancioNET10-Debug")
            IO.Directory.CreateDirectory(reportDirectory)
            Dim reportPath = IO.Path.Combine(reportDirectory, "asme-startup.log")
            Dim line = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & " " & String.Join("; ", startupStages)
            IO.File.AppendAllText(reportPath, line & Environment.NewLine)
            System.Diagnostics.Trace.WriteLine("AsmeVip startup: " & line)
        Catch ex As Exception
            System.Diagnostics.Trace.WriteLine("AsmeVip startup diagnostics: " & ex.Message)
        End Try
    End Sub
    Public Sub EseguiAutom()
        Dim Res As Short
        Dim Testo As String
        Dim k As Short
        Dim KL As Short
        AddDistinta = 1
        '            CALCOLO AUTOMATICO
        For KL = 1 To Config(0).NumeroLati
            'Classe1(0) = 13
            ModifiedData = True
200:        Res = ApriLeggiU()
            If Res Then Res = EscludiElementi(k)
            If Res Then Res = EscludiBocchelli(k)
210:        If Res Then Res = DatiInputC(2)
            If Res Then Res = CheckCianfr(0)
220:        If Res Then Res = CalcolaTutto()
221:        If Res Then Res = CheckCianfr(1)
222:        If Res Then
                ' If Classe1(0) < 13 Then
                ' i = 1
                ' Do
                ' For k = 1 To Config(0).NumeroLati
                ' For j = 1 To NumBocch(k)
                ' If Record(Nozzles(k, j).indice).Ind = Classe1(i) Then
                ' ''                IF LEFT$(Nozzles(j).Mark, 1) = "-" THEN
                ' ''                   FOR k = i TO Classe1(0) - 1: Classe1(k) = Classe1(k + 1): NEXT
                ' ''                   Classe1(0) = Classe1(0) - 1
                ' ''                   i = i - 1
                ' ''                END IF
                ' Exit For
                'End If
                'Next
                'Next
                'i = i + 1
                'Loop Until i > Classe1(0)
            End If
            'If Classe1(0) > 0 And Classe1(0) < 13 Then
            Testo = " A seguito della presenza di flange    |"
            Testo = Testo & "fuori standard ANSI B16.5, è possibile |"
            Testo = Testo & "passare direttamente al programma WNLJ |"
            Testo = Testo & "per il loro dimensionamento.         |"
            Testo = Testo & "    Vuoi procedere in tal senso ?      |"
            Testo = clsInizio.ConvertiCr(Testo)
            Dim junk As DialogResult = MessageBox.Show(Testo, "AsmeVip", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If junk = DialogResult.Yes Then
                Call ChiudeFileU()
                Monitor.Motore.Problem.ChiudiRapp()
            End If
        Next
    End Sub
    Public Sub Trasferisci(ByRef j As RoutBase1.clsjob)
        Monitor.Motore.Problem = Monitor.Motore.Problems("ASME").Problem
        Monitor.Motore.About = Monitor.Motore.Problems("ASME").About
        AddDistinta = 1
        job = j
        Monitor.Motore.Inizio.LavoriSciolti = False
        objASME = Me
        StoCalcolando = True
        mioApert = New Apert
        mioApert.Show()
        Do
            System.Windows.Forms.Application.DoEvents()
        Loop While StoCalcolando
    End Sub
    Public Sub SpesCil(ByRef P0 As Single, ByRef td As Single, ByRef T0 As Single, ByRef R As Single, ByRef s As Single, ByRef E As Single, ByRef codice As Short)
        Dim lSWR, lZSS, lZES, lTrs As Single
        Dim luu As String = ""
        Select Case codice
            Case 1 : Config(0).DC = 0 '0 div1; 3 div 2
            Case 2 : Config(0).DC = 3
            Case 3 : Config(0).DC = 6 'EURONORM + Tresca
            Case 4 : Config(0).DC = 6 'EURONORM + von Mises
        End Select
        Ridimensiona(0)
        Involucr(1, 1).St = s
        Involucr(1, 1).di = 2 * R
        Involucr(1, 1).cs = 0
        Involucr(1, 1).ES = E
        lSWR = 0
        Call SuperCylThk(P0, td, T0, R, lZSS, lZES, s, E, luu, lSWR, lTrs, Involucr(1, 1), Config(0))
    End Sub
    Public Sub PextCil(ByRef DE As Single, ByRef t As Single, ByRef td As Single, ByRef Indmat As Short, ByRef codice As Short, ByRef pext As Single, Optional ByRef Carta As String = "", Optional ByRef silente As Boolean = False)
        Dim psig1, psig, psig2 As Single
        Dim L0 As Single
        Select Case codice
            Case 1 : Config(0).DC = 0 '0 div1; 3 div 2
            Case 2 : Config(0).DC = 3
            Case 3 : Config(0).DC = 6 'EURONORM + Tresca
            Case 4 : Config(0).DC = 6 'EURONORM + von Mises
        End Select
        On Error GoTo ErrH
        If Matdim(0) Is Nothing Then Matdim(0) = New LibMat.MaterialeNew1
        On Error GoTo 0
        L0 = 10000
        Matdim(0).Indmat = Indmat
        Matdim(0).RecupMat(Monitor.Motore.Inizio.Archdir)
        If Matdim(0).Indmat = 0 Then Exit Sub
        Matdim(0).Zitto = silente
        PressExtCil(DE, t, L0, td, 0, psig, psig1, psig2, Carta)
        If psig = -2 Then pext = -2 : Exit Sub
        pext = psig1
        If psig2 < pext And psig2 > 0 Then pext = psig2
        Exit Sub
ErrH:
        Ridimensiona(0)
        Resume
    End Sub
    'Public Sub Rapporto(ByRef lFileSt As String, ByRef liGia As Boolean, Optional ByRef Template As String = "", Optional ByRef lst As Object = Nothing, Optional ByRef Tipo As String = "", Optional ByRef Elemento As String = "")
    '    If Template = "" Then Template = "HEADER"
    '    iGia = liGia
    '    FileSt = lFileSt
    '    If Not Monitor.Motore.Problem.FileStream Is Nothing Then Monitor.Motore.Problem.FileStream = New IO.StreamWriter(FileSt, True)
    '    PrepRapp(Template, Tipo, Elemento, FileSt, iGia, lst)
    '    liGia = iGia
    'End Sub
    Public Sub gTestata()
        If Monitor.Motore.Problem.FileStream Is Nothing Then Exit Sub
        Monitor.Motore.Testata()
        Monitor.Motore.Problem.FileStream.Close() 'FileClose(iout)
    End Sub
    Public Sub WinWord()
        Visualizza()
        'iout = 0
    End Sub
    Public Sub ClearRapporto(Optional ByRef lst As Object = Nothing)
        CloseioutS(lst)
    End Sub
    Public Function ExternalPressure(ByRef DE As Single, ByRef t As Single, ByRef L0 As Single, ByRef td As Single, ByRef Mat As LibMat.MaterialeNew1, ByRef psig As Single, ByRef psig1 As Single, ByRef psig2 As Single, ByRef Carta As String, ByRef Cod As Short, Optional ByRef AsmeA As Object = Nothing, Optional ByRef AsmeB As Object = Nothing) As Short
        Ridimensiona(0)
        Select Case Cod
            Case 2 : Config(0).DC = 3
            Case Else : Config(0).DC = 0
        End Select
        Matdim(0) = Mat
        PressExtCil(DE, t, L0, td, 0, psig, psig1, psig2, Carta, AsmeA, AsmeB)
    End Function
End Class
