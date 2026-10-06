Option Strict Off
Option Explicit On
Imports System.Math
Imports RoutBase1.clsTrigon
Module GenVentil
    Public Structure BufMath
        <VBFixedArray(2, 6)> Dim Matrix(,) As Single
        'UPGRADE_WARNING: La dimensione della stringa di lunghezza fissa deve essere contenuta nel buffer. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(64), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=64)> Public St() As Char
        Dim STDERR As Integer
        'UPGRADE_WARNING: La dimensione della stringa di lunghezza fissa deve essere contenuta nel buffer. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(64), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=64)> Public StOut() As Char
        Dim STDOUT As Integer
        Dim Tipo As Integer '  1: NEQNJ  2: NEQBJ
        <VBFixedArray(2)> Dim Xguess() As Single
        Dim ErrRel As Single
        Dim ItMax As Integer
        <VBFixedArray(2)> Dim Sol() As Single
        Dim Fnorm As Single
        <VBFixedArray(2)> Dim Fvec() As Single
        Dim ErrCode As Integer

        'UPGRADE_TODO: "Initialize" deve essere chiamato per inizializzare istanze di questa struttura. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="B4BFF9E0-8631-45CF-910E-62AB3970F27B"'
        Public Sub Initialize()
            'UPGRADE_WARNING: Il limite inferiore della matrice Matrix è stato cambiato da 1,1 a 0,0. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
            ReDim Matrix(2, 6)
            'UPGRADE_WARNING: Il limite inferiore della matrice Xguess è stato cambiato da 1 a 0. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
            ReDim Xguess(2)
            'UPGRADE_WARNING: Il limite inferiore della matrice Sol è stato cambiato da 1 a 0. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
            ReDim Sol(2)
            'UPGRADE_WARNING: Il limite inferiore della matrice Fvec è stato cambiato da 1 a 0. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
            ReDim Fvec(2)
        End Sub
    End Structure
    Private Structure RecAERFIB
        Dim Numeri() As String
        Public Sub Initialize()
            ReDim Numeri(80)
        End Sub
    End Structure
    Public myAssembly As System.Reflection.Assembly
    Public GlobalRoutines As RoutBase1.clsTrigon
    Public Stub2000 As StubW2000.clsSW2000
    Public stub9 As StubW9.clsSW9
    Public DAOEngine As New dao.DBEngine
    Private Currentx, Currenty As Single
    Private Record As RecAERFIB
    Private objDatBase As RoutBase1.DatBase
    Private Pale() As String
    '=================================Ventilat==========================
    Private iF3, i As Short
    Private Riga As String
    Private Help, Unit As String
    Private x As Integer
    Private iC As Short
    Private U, itp As String
    Private HPFan, HPMot As Single
    Private Risp(50) As String
    Private iQ As Short
    Private Dom(50) As String
    Private Tit As String
    Private Archiv(50) As Short
    Private dAiu(50) As String
    Private Testo As String
    Private NewF As String
    Private Esito, Blank As Boolean
    Private iF4, j As Short
    Private RPM, nPale As Short
    Private Angol As Single
    Private Tipo As String
    Private nPaleV, daDove As Short
    Private TipoV As String
    Private nVen As Short
    '==================================================================
    Structure DATIVENT
        Dim MO As Integer
        Dim Draft As Integer
        Dim GiocoDiam As Single
        Dim ACFM As Single
        Dim StaticPress As Single
        Dim TARPAL As Single
        Dim Elevazione As Single
        Dim DiamVent As Single
        Dim GiriVent As Single
        Dim AltezzaDiv As Single
        Dim CodImbocco As Integer
        Dim AirDensity As Single
        'UPGRADE_WARNING: La dimensione della stringa di lunghezza fissa deve essere contenuta nel buffer. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(4), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=4)> Public Sigla() As Char
        Dim Calett As Single
        Dim HP As Single
        Dim EtaTot As Single
        Dim PWL As Single
        Dim SPL As Single
        Dim PSCP As Single
        Dim PCSPA As Single
        Dim CorrRd As Single
        <VBFixedArray(6)> Dim Padding() As Single
        Dim Pddin1 As Short
        Dim Lingua As Short
        Dim PFUN As Short
        Dim PEFF As Short
        Dim pr As Short
        Dim Npal As Short
        Dim Scelta As Short
        Dim UNITA As Short
        'UPGRADE_WARNING: La dimensione della stringa di lunghezza fissa deve essere contenuta nel buffer. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(19), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=19)> Public Item() As Char

        'UPGRADE_TODO: "Initialize" deve essere chiamato per inizializzare istanze di questa struttura. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="B4BFF9E0-8631-45CF-910E-62AB3970F27B"'
        Public Sub Initialize()
            'UPGRADE_WARNING: Il limite inferiore della matrice Padding è stato cambiato da 1 a 0. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
            ReDim Padding(6)
        End Sub
    End Structure
    Structure tpRISULT
        <VBFixedArray(13)> Dim AP() As Single
        <VBFixedArray(13)> Dim BP() As Single
        <VBFixedArray(13)> Dim CP() As Single
        <VBFixedArray(13)> Dim AR() As Single
        <VBFixedArray(13)> Dim BR() As Single
        <VBFixedArray(13)> Dim CR() As Single
        <VBFixedArray(13, 2)> Dim AB(,) As Single
        <VBFixedArray(13, 2)> Dim AC(,) As Single
        Dim MaxI As Integer
        Dim Basic As Integer
        Dim Esito As Integer

        'UPGRADE_TODO: "Initialize" deve essere chiamato per inizializzare istanze di questa struttura. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="B4BFF9E0-8631-45CF-910E-62AB3970F27B"'
        Public Sub Initialize()
            'UPGRADE_WARNING: Il limite inferiore della matrice AP è stato cambiato da 1 a 0. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
            ReDim AP(13)
            'UPGRADE_WARNING: Il limite inferiore della matrice BP è stato cambiato da 1 a 0. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
            ReDim BP(13)
            'UPGRADE_WARNING: Il limite inferiore della matrice CP è stato cambiato da 1 a 0. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
            ReDim CP(13)
            'UPGRADE_WARNING: Il limite inferiore della matrice AR è stato cambiato da 1 a 0. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
            ReDim AR(13)
            'UPGRADE_WARNING: Il limite inferiore della matrice BR è stato cambiato da 1 a 0. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
            ReDim BR(13)
            'UPGRADE_WARNING: Il limite inferiore della matrice CR è stato cambiato da 1 a 0. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
            ReDim CR(13)
            'UPGRADE_WARNING: Il limite inferiore della matrice AB è stato cambiato da 1,1 a 0,0. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
            ReDim AB(13, 2)
            'UPGRADE_WARNING: Il limite inferiore della matrice AC è stato cambiato da 1,1 a 0,0. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
            ReDim AC(13, 2)
        End Sub
    End Structure
    'UPGRADE_WARNING: La struttura BufMath potrebbe richiedere attributi di marshalling da passare come argomento a questa istruzione Declare. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
    Declare Sub SOLVEQUAD2 Lib "MathVentil.DLL" (ByRef D As BufMath)
    'UPGRADE_WARNING: La struttura Str40 potrebbe richiedere attributi di marshalling da passare come argomento a questa istruzione Declare. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
    'UPGRADE_WARNING: La struttura Str40 potrebbe richiedere attributi di marshalling da passare come argomento a questa istruzione Declare. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
    'UPGRADE_WARNING: La struttura Str40 potrebbe richiedere attributi di marshalling da passare come argomento a questa istruzione Declare. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
    'UPGRADE_WARNING: La struttura Str40 potrebbe richiedere attributi di marshalling da passare come argomento a questa istruzione Declare. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
    Declare Sub DOAPAI Lib "HtriLib.DLL" (ByRef Base As Str40, ByRef Work As Str40, ByRef f As Str40, ByRef H As Str40, ByRef iErr As Short)
    'UPGRADE_WARNING: La struttura Str6 potrebbe richiedere attributi di marshalling da passare come argomento a questa istruzione Declare. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
    Declare Sub APRIPR Lib "HtriLib.DLL" (ByRef iIn As Short, ByRef iOut As Short, ByRef NP As Str6, ByRef iErr As Short)
    Declare Sub HTRI8 Lib "HtriSub.DLL" (ByRef i As Short)
    Declare Sub HTR9A Lib "HtriSub.DLL" ()
    'UPGRADE_WARNING: La struttura tpRISULT potrebbe richiedere attributi di marshalling da passare come argomento a questa istruzione Declare. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
    'UPGRADE_WARNING: La struttura DATIVENT potrebbe richiedere attributi di marshalling da passare come argomento a questa istruzione Declare. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
    Declare Sub HTR9B Lib "HtriSub.DLL" (ByRef daDove As Short, ByRef D As DATIVENT, ByRef tp As tpRISULT, ByRef n As Short, ByRef v As Short, ByRef ISA As Short)
    Declare Sub HTR9A1 Lib "HtriSub.DLL" (ByRef i As Short)
    'Declare Sub HTR9B1 Lib "HtriSub.DLL" (D As DATIVENT, Dove As Integer, i As Integer)
    'UPGRADE_WARNING: La struttura Str40 potrebbe richiedere attributi di marshalling da passare come argomento a questa istruzione Declare. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
    Declare Sub APRIMDB Lib "DAO36.dll" (ByRef b As Str40, ByRef s As Integer)
    'UPGRADE_WARNING: La struttura Str512 potrebbe richiedere attributi di marshalling da passare come argomento a questa istruzione Declare. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
    'Declare Sub APRITABLE Lib "DAO36.dll" (ByRef b As Str512, ByRef i As Short, ByRef s As Integer)
    'UPGRADE_WARNING: La struttura Str40 potrebbe richiedere attributi di marshalling da passare come argomento a questa istruzione Declare. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
    Declare Sub CAMPO Lib "DAO36.dll" (ByRef C As Str40, ByRef r As Object)
    'UPGRADE_WARNING: La struttura tpRISULT potrebbe richiedere attributi di marshalling da passare come argomento a questa istruzione Declare. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
    Declare Sub FPARABOLE Lib "HtriSub.DLL" (ByRef idPala As Integer, ByRef H As Single, ByRef n As Short, ByRef i As Short, ByRef tp As tpRISULT)
    '------------------------------------------------------
    Public finCurva As frmCurva
    Public Archdir As String
    '===============HTMLHelp=================================
    Declare Function HtmlHelp Lib "hhctrl.ocx" Alias "HtmlHelpA" (ByVal hwndCaller As Integer, ByVal pszFile As String, ByVal uCommand As Integer, ByVal dwData As Integer) As Integer
    Public Const HH_DISPLAY_TOPIC As Short = &H0S
    Public Const HH_SET_WIN_TYPE As Short = &H4S
    Public Const HH_GET_WIN_TYPE As Short = &H5S
    Public Const HH_GET_WIN_HANDLE As Short = &H6S
    Public Const HH_DISPLAY_TEXT_POPUP As Short = &HES ' Display string resource ID or
    ' text in a pop-up window.
    Public Const HH_HELP_CONTEXT As Short = &HFS ' Display mapped numeric value in
    ' dwData.
    Public Const HH_TP_HELP_CONTEXTMENU As Short = &H10S ' Text pop-up help, similar to
    ' WinHelp's HELP_CONTEXTMENU.
    Public Const HH_TP_HELP_WM_HELP As Short = &H11S ' text pop-up help, similar to
    ' WinHelp's HELP_WM_HELP.
    Private Const HH_HELP_FINDER As Short = &H0S ' WinHelp equivalent
    Public Const HH_DISPLAY_TOC As Short = &H1S ' WinHelp equivalent
    Private Const HH_DISPLAY_INDEX As Short = &H2S ' WinHelp equivalent
    Public RadiceHelp As String '= "C:\BASE\ESEGUI\BIN\AiutoISA.chm"
    '==============================================================
    Public Disegno As Autodesk.AutoCAD.Interop.AcadDocument
    Public AcadApp As Object
    Public Const IDH_VEN_NOCALC As Short = 1260
    Public Const IDH_STR_AT13 As Integer = 1313
    Public Const IDH_STR_AT17 As Integer = 1317
    Public Const IDH_STR_AT20 As Integer = 1320
    Public Const IDH_STR_AT21 As Integer = 1321
    Public Const IDH_STR_AT35 As Integer = 1335
    Public Const IDH_STR_AT36 As Integer = 1336
    Public Const IDH_STR_AT37 As Integer = 1337
    Public Const IDH_STR_AT39 As Integer = 1339
    Public Const RadOutP As String = "\CF\OUTP"
    Public Const RadTextv As String = "TEXV"
    Public Const RadText As String = "TEXT"
    '------------------------------------------------------------------
    'UPGRADE_WARNING: È possibile che si debba inizializzare le matrici nella struttura Risult prima di poterle utilizzare. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
    Public Risult As tpRISULT
    Public Lin(3) As String
    Public Base As String
    Public CorrDB, CorrRd As Single
    Public nprofil As Short
    Public Sigla As String
    Public nuovePar, daISA, Cambiato As Boolean
    Public FilePRI As String
    'UPGRADE_WARNING: È possibile che si debba inizializzare le matrici nella struttura Dati prima di poterle utilizzare. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
    Public FileVE1 As String
    Public Dati As DATIVENT
    Public MaxEta As Single
    Public QMaxEta As Single
    Public iMaxEta As Short
    Public secondo As Boolean
    Public FileDB As String
    Public r770, d1524 As Single
    Public AddDistinta, MaxAngles As Short
    'UPGRADE_NOTE: Monitor è stato aggiornato a Monitor. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
    Public Monitor As clsMonitor
    Public O As clsTeor
    'UPGRADE_WARNING: È possibile che si debba inizializzare le matrici nella struttura tabella prima di poterle utilizzare. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
    Public myDataBase As dao.Database
    Public tabella As dao.Recordset
    Public Grafico As RoutBase1.clsGrafico
    Public Torcit As Single
    Public ModifiedData As Boolean
    Public Lav() As Identif
    'UPGRADE_WARNING: È possibile che si debba inizializzare le matrici nella struttura BufBuf prima di poterle utilizzare. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
    Public at1() As String
    'Public BufBuf As tipoBuf
    Public Nrdit, n As Short 'numero alternativa
    Public FaseDati As Short
    Public OKDati As Boolean
    Public Problem As RoutBase1.clsProblem
    Public About As RoutBase1.clsAbout
    Public TabDati As dao.Recordset
    '-----------------------------------------------------------------
    Public Const Grav As Single = 9.80655
    Public Const DensRif As Single = 1.2 'Densità di riferimento dell'aria in kg/m3
    Public Const CoeffPD As Single = Grav * 2 / DensRif
    Public Const LbFt3 As Single = 16.0329
    Public Const Inch As Single = 25.4
    Public Const Foot As Single = 304.8
    Public PFUN, PEFF As Short
    Public PlotRecup, PlotEta1 As Boolean
    Function CheckLog() As Boolean
        Dim ifl, i As Short
        Dim Riga As String = ""
        Dim r As String = ""
        Dim Testo As String
        ifl = FreeFile()
        'UPGRADE_WARNING: Dir ha un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
        If Len(Dir(RadOutP & RTrim(Lav(0).Arch))) = 0 Then CheckLog = True : Exit Function
        FileOpen(ifl, RadOutP & RTrim(Lav(0).Arch), OpenMode.Input)
        Do
            Riga = LineInput(ifl)
            If Mid(Riga, 13, 5) = "GRAPH" Then
                CheckLog = True
                FileClose(ifl)
                Exit Function
            ElseIf Left(Riga, 10) = "Input past" And Mid(Riga, 34, 3) = "CF-" Then
                r = Riga
            End If
            If EOF(ifl) Then Exit Do
        Loop
        FileClose(ifl)
        FileOpen(ifl, RadOutP & RTrim(Lav(0).Arch), OpenMode.Input)
        Do
            Riga = LineInput(ifl)
            If Left(Riga, 6) = " FINAL" Then
                If Len(r) = 0 Then
                    For i = 1 To 6 : Riga = LineInput(ifl) : Next
                    Testo = LineInput(ifl)
                    Riga = Riga & "|" & Testo
                Else
                    Riga = Left(r, 42)
                End If
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.Inizio.ConvertiCr(). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Riga = Monitor.Motore.Inizio.ConvertiCr(Riga)
                MsgBox(Riga, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
                CheckLog = False
                FileClose(ifl)
                Exit Function
            End If
            If EOF(ifl) Then Exit Do
        Loop
        CheckLog = True
    End Function

    Function CheckLogC() As Boolean
        Dim ifl As Short
        Dim Riga, Riga1 As String
        CheckLogC = True
        ifl = FreeFile()
        FileOpen(ifl, RadTextv & RTrim(Lav(0).Arch), OpenMode.Input)
        Do
            Riga = LineInput(ifl)
            If Left(LTrim(Riga), 6) = "NO SOL" Then
                CheckLogC = False
                Do
                    Riga1 = LineInput(ifl)
                    Riga = Riga & "|" & Riga1
                    If EOF(ifl) Then Exit Do
                Loop
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.Inizio.ConvertiCr(). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Riga = Monitor.Motore.Inizio.ConvertiCr(Riga)
                MsgBox(Riga, MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                Exit Function
            End If
            If EOF(ifl) Then Exit Do
        Loop
        FileClose(ifl)
    End Function

    Function CheckLogM() As Boolean
        Dim ifl, i As Short
        Dim Risp(50) As String
        CheckLogM = False
        ifl = FreeFile()
        FileOpen(ifl, RadTextv & Trim(Lav(0).Arch), OpenMode.Input)
        i = 0
        Do
            i = i + 1
            Risp(i) = LineInput(ifl)
            If i = 1 And Left(Risp(1), 10) = "The M O O " Then CheckLogM = True : Exit Function
            If i > 50 Or EOF(ifl) Then Exit Do
        Loop
        FileClose(ifl)
        'XV = myListBox(WindowNext, 1, 1, Risp$(), i, maxOld, at1(41), True)
    End Function

    Sub Cofimco()
        Dim Testo, NewF As String
        On Error GoTo ErrCof
        Testo = GlobalRoutines.myStr(CSng(Nrdit \ 2), 2, 0, True)
        If Left(Testo, 1) = Chr(32) Then Testo = Chr(48) & Right(Testo, 1)
        NewF = Monitor.Motore.Inizio.Workdir & Chr(92) & Left(Lav(0).Arch, 4) & Testo & ".SVI"
451:    ChDir("\COFIMCO")
452:    ChDir(Monitor.Motore.Inizio.Basedir)
        ' IUNP = Nrdit
        ' Nomi$(1, 1) = NewF$
        ' AddDistinta = 106
        ' SALVA
        ' CLOSPREV
        ' Catena "COFIMCO"
461:    Exit Sub
ErrCof:
        If Erl() = 451 Then
            'Testo = Monitor.Motore.Inizio.ConvertiCr(at1(35))
            '        Help$ = "Non Š stata trovata la directory \COFIMCO |"
            'Help$ = Help$ + "del programma MEGAC.  Il file dei    |"
            'Help$ = Help$ + "dati (.SVI) non Š stato generato.    |"
            'MsgBox Testo
            MostraAiuto(IDH_STR_AT35)
            Resume 461
        Else
            Debug.Print("Err Cofimco" & Err.Number & Erl()) : Stop
        End If
    End Sub

    Sub Moore()
        Dim Testo As String
        On Error GoTo ErrMor
651:    ChDir("\MOORE")
652:    ChDir(Monitor.Motore.Inizio.Basedir)
        ' IUNP = Nrdit
        ' AddDistinta = 107
        ' SALVA
        ' CLOSPREV
        ' Catena "MOORE"
661:    Exit Sub
ErrMor:
        If Erl() = 651 Then
            '        Help$ = "Non Š stata trovata la directory \MOORE   |"
            'Help$ = Help$ + "del programma MFL.    Il file dei    |"
            'Help$ = Help$ + "dati        non Š stato generato.    |"
            'Testo = Monitor.Motore.Inizio.ConvertiCr(at1(36))
            'MsgBox Testo
            MostraAiuto(IDH_STR_AT36)
            Resume 661
        Else
            Debug.Print("Errore in Cofimco" & Err.Number & Erl()) : Stop
        End If
    End Sub
    Public Function TrapErrFortran() As Boolean
        Dim s As Single
        Dim Testo As String
        On Error GoTo ErrFor
        s = 1 + 1.0#
        TrapErrFortran = False
        Exit Function
ExFor:
        ' Testo = "Attenzione!" + vbCrLf
        ' Testo = Testo + "Uno o più dati di input sono errati."
        ' MsgBox Testo, vbCritical + vbOKOnly
        Err.Clear()
        TrapErrFortran = True
        Exit Function
ErrFor:
        Resume ExFor
    End Function

    Sub GeneraCAL(ByRef NewF As String, ByRef Arch As String)
        Dim A As String
        A = GlobalRoutines.myStr(CSng(Nrdit \ 2), 2, 0, True)
        If Left(A, 1) = Space(1) Then A = Chr(48) & Right(A, 1)
        NewF = Monitor.Motore.Inizio.Workdir & Chr(92) & Arch & A & ".CAL"
        'UPGRADE_WARNING: Dir ha un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
        If Len(Dir(NewF)) > 0 Then Kill(NewF)
        FileCopy(RadText & Arch, NewF)
        'Open at1(55) + RTrim$(Lav(0).Arch) For Input As #3
        'Open NewF$ For Output As #4
        'Do
        '   Line Input #3, Riga$
        '   Print #4, Riga$
        '   If EOF(3) Then Exit Do
        'Loop
        'Close #3: Close #4
        Kill(RadText & Arch)
    End Sub

    Sub Sirocco()
        Dim Testo, NewF As String
        On Error GoTo ErrSir
        Testo = GlobalRoutines.myStr(CSng(Nrdit \ 2), 2, 0, True)
        If Left(Testo, 1) = Chr(32) Then Testo = Chr(48) & Right(Testo, 1)
        NewF = Monitor.Motore.Inizio.Workdir & Chr(92) & Left(Lav(0).Arch, 4) & Testo & ".INV"
351:    ChDir("\CF")
352:    ChDir(Monitor.Motore.Inizio.Basedir)
        ' IUNP = Nrdit
        ' Nomi$(1, 1) = NewF$
        ' AddDistinta = 105
        ' SALVA
        ' CLOSPREV
        ' Catena "SIROCCO"
361:    Exit Sub
ErrSir:
        If Erl() = 351 Then
            '        Help$ = "Non Š stata trovata la directory \CF |"
            'Help$ = Help$ + "del programma CF-P15. Il file dei    |"
            'Help$ = Help$ + "dati (.INV) Š stato comunque salvato |"
            'Testo = Monitor.Motore.Inizio.ConvertiCr(at1(37))
            'MsgBox Testo
            MostraAiuto(IDH_STR_AT37)
            Resume 361
        Else
            Debug.Print("Err Sirocco" & Err.Number & Erl()) : Stop
        End If
    End Sub

    Public Function Ventilat(ByRef Arch As String, ByRef DisplayOnly As Boolean, Optional ByRef Silent As Boolean = False) As Boolean
        ', Risult As tpRISULT
        Ventilat = True
        If AddDistinta = 105 Or AddDistinta = 106 Or AddDistinta = 107 Then
            Visual(Arch, DisplayOnly)
            Exit Function
        End If
        Dim TipoVe As String
        If daISA Then
            n = Val(Lav(0).Assieme(2))
            If n < 1 Or n > 5 Then n = 1
            TipoVe = Monitor.objDatBase.DatBase(4, 10, Nrdit \ 2, n, itp, 0)
            daDove = 1 ' -1
        Else
            n = 1
            TipoVe = "FH" ' Girante
            Arch = ""
            daDove = 0
        End If
        IO.File.Delete(RadText & Arch)
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        If TipoVe = "FH" Or TipoVe = "SH" Or TipoVe = "CF" Or TipoVe = "MR" Then
            Risult.Basic = -1
            Dati.CorrRd = CorrRd
            nVen = 0 : If DisplayOnly Then nVen = -1
            HTR9B(daDove, Dati, Risult, nVen, 0, Int(CDbl(daISA)))
        Else
            HTR9A()
        End If
        'UPGRADE_WARNING: Screen proprietà Screen.MousePointer presenta un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        If TipoVe = "FH" Or TipoVe = "AX" Then
            'UPGRADE_WARNING: Dir ha un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
            If Len(Dir(RadText & Arch)) = 0 Then GoTo dinu
            iF3 = FreeFile()
            FileOpen(iF3, RadText & Arch, OpenMode.Input)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Dove.ListItems. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            If Not Monitor.Dove Is Nothing Then Monitor.Dove.ListItems.Clear()
            For i = 1 To 22
                Riga = LineInput(iF3)
                If Len(Riga) > 3 Then Riga = Right(Riga, Len(Riga) - 3)
                If Not Silent Then
                    If Monitor.Dove Is Nothing Then
                        If i = 5 Then
                            Help = Riga
                        ElseIf i > 5 Then
                            Help = Help & "|" & Riga
                        End If
                    Else
                        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Dove.ListItems. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        If i > 7 Then Monitor.Dove.ListItems.Add(, , Riga)
                    End If
                End If
                If EOF(iF3) Then Exit For
            Next
            If Not Silent Then
                If Monitor.Dove Is Nothing Then
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.Inizio.ConvertiCr(). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Help = Monitor.Motore.Inizio.ConvertiCr(Help)
                    x = MsgBox(Help, MsgBoxStyle.OkCancel + MsgBoxStyle.Question)
                    If x = MsgBoxResult.Cancel Then FileClose(iF3) : Ventilat = False : Exit Function
                Else
                    If DisplayOnly Then
                        FileClose(iF3)
                        On Error Resume Next
                        Kill(RadText & Arch)
                        Exit Function
                    End If
                End If
            End If
            iC = 0
            If daISA Then
                With Monitor.objDatBase
                    nPaleV = .CVI(.DatBase(4, 27, Nrdit \ 2, n, itp, 0))
                    TipoV = .DatBase(4, 13, Nrdit \ 2, n, itp, 0)
                End With
            End If
            Do
                Riga = LineInput(iF3)
                If Mid(Riga, 6, 2) = ">>" Then
                    'Help$ = at1(13)
                    'Help = Monitor.Motore.Inizio.ConvertiCr(Help)
                    '           Help$ = "Non esiste un ventilatore adatto. |"
                    '   Help$ = Help$ + "Cambiare i dati di progetto.      |"
                    'MsgBox Help, vbOKOnly + vbInformation
                    MostraAiuto(IDH_STR_AT13)
                    FileClose(iF3)
                    Display(Arch, DisplayOnly)
                    Ventilat = False
                    Exit Function
                ElseIf Mid(Riga, 7, 5) = "ERROR" Then
                    Help = "Il programma HTR9B ha riportato il seguente errore:" & vbCrLf
                    Help = Help & Right(Riga, Len(Riga) - 15)
                    MsgBox(Help, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ISA")
                    FileClose(iF3)
                    Ventilat = False
                    Exit Function
                End If
                Help = ""
                If Len(Riga) > 0 Then
                    Riga = Right(Riga, Len(Riga) - 5)
                    If Val(Right(Riga, Len(Riga) - 1)) > 0 Then
                        iC = iC + 1
                        Risp(iC) = Riga
                        Tipo = Mid(Riga, 7, 2)
                        nPale = Val(Mid(Riga, 12, 4))
                        If Trim(Tipo) = Trim(TipoV) And nPale = nPaleV Then iQ = iC
                    ElseIf iC = 0 Then
                        Testo = Testo & Space(5) & Riga & vbCrLf
                    End If
                End If
                If EOF(iF3) Then Exit Do
            Loop
dinu:
            If Silent And daISA Then
                If iQ = 0 Then
                    MsgBox("Errore Ventilatore")
                    Ventilat = False
                    FileClose(iF3)
                    Exit Function
                End If
            Else
                If Not daISA And Dati.Scelta <= iC Then iQ = Dati.Scelta
                If iQ = 0 Then iQ = 1
                If iC > 0 Then
                    'UPGRADE_WARNING: Screen proprietà Screen.MousePointer presenta un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
                    System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
                    iQ = Monitor.Motore.Quale(iC, "Scelta ventilatore", Risp, "", iQ, Testo, 1)
                    If iQ = 0 Then FileClose(iF3) : Ventilat = False : Exit Function
                    If Not daISA Then Dati.Scelta = iQ
                End If
            End If
            If iC > 0 Then
                nVen = Val(Mid(Risp(iQ), 2, 2)) 'scelta
            Else
                nVen = 0
            End If
            ' If Not daISA Then
            Npal = Val(Mid(Risp(iQ), 12, 4))
            Tippal = Mid(Risp(iQ), 6, 5)
            Sigla = Trim(Tippal)
            SelezPala()
            ' End If
            If Npal = 0 Then
                ' Help = Monitor.Motore.Inizio.ConvertiCr(at1(39))
                '            Help$ = "Non e' stata scelto un ventilatore|"
                '    Help$ = Help$ + "in modo valido : prego rifare.    |"
                'MsgBox Help, vbOKOnly + vbCritical
                MostraAiuto(IDH_STR_AT39)
                If Silent Then
                    FileClose(iF3)
                    Ventilat = False
                    Exit Function
                Else
                    GoTo dinu
                End If
            End If
            If daISA Then
                RivsuFile()
                If TipoVe = "FH" Then
                    Risult.Basic = 0
                    Dati.CorrRd = CorrRd
                    HTR9B(-1, Dati, Risult, nVen, 1, Int(CDbl(daISA)))
                    If Silent Then FileClose(iF3) : Exit Function
                Else
                    HTR9A1(nVen)
                End If
            End If
            FileClose(iF3)
401:        FileOpen(iF3, RadText & Arch, OpenMode.Append)
            PrintLine(iF3)
            PrintLine(iF3, "  E' STATO SCELTO IL TIPO " & Str(nVen))
            FileClose(iF3)
            Visual(Arch, DisplayOnly)
        ElseIf TipoVe = "SH" Then
            'Call Sirocco
        ElseIf TipoVe = "CF" Then
            'Call Cofimco
        ElseIf TipoVe = "MR" Then
            'Call Moore
        Else
            iF3 = FreeFile()
            FileOpen(iF3, RadText & Arch, OpenMode.Input)
            Riga = LineInput(iF3)
            Riga = LineInput(iF3)
            iC = 0
            Do
                Riga = LineInput(iF3)
                If Mid(Riga, 6, 2) = "PO" Then Exit Do
                iC = iC + 1
                If iC < 5 Then
                    Dom(iC) = Right(Riga, Len(Riga) - 5)
                    Risp(iC) = Space(0)
                Else
                    Dom(iC) = Mid(Riga, 6, 16)
                    Risp(iC) = Mid(Riga, 22, 12)
                End If
            Loop
            FileClose(iF3)
            Kill(RadText & Arch)
            If Asc(TipoVe) < 32 Then TipoVe = "XX"
            Tit = "Dati Ventilatori " & TipoVe
            'UPGRADE_WARNING: Screen proprietà Screen.MousePointer presenta un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            If Not DisplayOnly Then Monitor.Motore.InputDati(iC, Tit, Dom, Risp, "", Archiv, dAiu)
            FileOpen(iF3, RadText & Arch, OpenMode.Output)
            For i = 5 To iC : PrintLine(iF3, Risp(i)) : Next i
            FileClose(iF3)
            HTR9A1(0)
            Display(Arch, DisplayOnly)
        End If
        If Not Silent And Not DisplayOnly Then Monitor.Ogg.Riscrivi(NewF, Nrdit, Arch)
        Exit Function
ErrVentil:
        If Erl() = 404 And Err.Number = 53 Then
            Resume Next
        Else
            Debug.Print("Err Venilat" & Err.Number & Erl()) : Stop
        End If
    End Function
    Private Sub EndCofimco(ByVal Arch As String)
        FileOpen(iF3, RadTextv & Arch, OpenMode.Input)
        Do
            Riga = LineInput(iF3)
            If Left(LTrim(Riga), 5) = "15. R" Then
                RPM = Val(Mid(Riga, 27, 4))
            ElseIf Left(LTrim(Riga), 5) = "11. N" Then  'nPale
                nPale = Val(Mid(Riga, 27, 4))
            ElseIf Left(LTrim(Riga), 5) = "19. B" Then  'Angol!
                Angol = Val(Mid(Riga, 27, 4))
            ElseIf Left(LTrim(Riga), 5) = "13. B" Then  'Profilo
                Tipo = Mid(Riga, 28, 3)
            ElseIf EOF(iF3) Then
                Exit Do
            End If
            If Mid(Riga, 40, 5) = "20. A" Then 'HPFan!
                HPFan = Val(Mid(Riga, 64, 4))
                HPMot = HPFan * 1.07
            End If
        Loop
        FileClose(iF3)
        Registra()
    End Sub
    Private Sub EndSirocco(ByVal Arch As String)
        FileOpen(iF3, RadTextv & Arch, OpenMode.Input)
        Do
            Riga = LineInput(iF3)
            If Left(LTrim(Riga), 3) = "RPM" Then
                RPM = Val(Mid(Riga, 33, 7))
            ElseIf Left(LTrim(Riga), 7) = "Blade n" Then  'nPale
                nPale = Val(Mid(Riga, 38, 2))
            ElseIf Left(LTrim(Riga), 7) = "Blade t" Then  'Angol!
                Angol = Val(Mid(Riga, 36, 4))
            ElseIf Left(LTrim(Riga), 7) = "Fan sha" Then  'HPFan!
                HPFan = Val(Mid(Riga, 36, 4))
                HPMot = HPFan * 1.07
            ElseIf Left(LTrim(Riga), 7) = "Fan typ" Then  'Profilo
                Tipo = Mid(Riga, 38, 1)
            ElseIf EOF(iF3) Then
                Exit Do
            End If
        Loop
        FileClose(iF3)
        Registra()
    End Sub
    Private Sub Registra()
        With Monitor.objDatBase
            Unit = .Readreco(1, 41, 2)
            If Unit <> "BR" Then
                HPFan = HPFan / 0.746
                HPMot = HPMot / 0.746
            End If
            n = Val(Lav(0).Assieme(2))
            U = .PutBasCh(4, 27, Nrdit \ 2, n, .MKI(nPale), 0)
            U = .PutBasCh(7, 45, Nrdit \ 2, n, .MKS(Angol), 0) 'DG(56)
            U = .PutBasCh(7, 23, Nrdit \ 2, n, .MKS(HPFan), 0) 'DG(54)
            U = .PutBasCh(7, 22, Nrdit \ 2, n, .MKS(HPMot), 0) 'DG(38)
            U = .PutBasCh(4, 13, Nrdit \ 2, n, Tipo, 0) 'NIBDIT(16;17)
            U = .PutBasCh(4, 9, Nrdit \ 2, n, .MKI(RPM), 0) 'NIBDIT(16;17)
            'REGISTRAZIONE
        End With
    End Sub
    Private Sub Display(ByRef Arch As String, ByRef DisplayOnly As Boolean)
        Testo = GlobalRoutines.myStr(CSng(Nrdit \ 2), 2, 0, True)
        If Left(Testo, 1) = Space(1) Then Testo = Chr(48) & Right(Testo, 1)
        NewF = Monitor.Motore.Inizio.Workdir & Chr(92) & Arch & Testo & ".VEN"
        IO.File.Delete(NewF)
        FileCopy(RadText & Arch, NewF)
        Kill(RadText & Arch)
        If Not DisplayOnly Then Shell("NotePad " & NewF, AppWinStyle.NormalFocus)
    End Sub
    Private Sub Visual(ByRef Arch As String, ByRef DisplayOnly As Boolean)
Visual:
        Archdir = Arch
        NewF = FileVEN()
        'UPGRADE_WARNING: Dir ha un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
        If Len(Dir(NewF)) > 0 Then Kill(NewF)
        If AddDistinta = 105 Then
            Esito = CheckLog()
433:        If Not Esito Then Exit Sub
            If Not IO.File.Exists(RadTextv & Arch) Then Exit Sub
            EndSirocco(Arch)
            iF3 = FreeFile()
            FileOpen(iF3, RadTextv & Arch, OpenMode.Input)
            iF4 = FreeFile()
            FileOpen(iF4, NewF, OpenMode.Output)
            PrintLine(iF4, "1")
        ElseIf AddDistinta = 106 Then
434:        Esito = CheckLogC()
            If Not Esito Then Exit Sub
            If Not IO.File.Exists(RadTextv & Arch) Then Exit Sub
            EndCofimco(Arch)
            iF3 = FreeFile()
435:        FileOpen(iF3, RadTextv & Arch, OpenMode.Input)
            iF4 = FreeFile()
            FileOpen(iF4, NewF, OpenMode.Output)
            PrintLine(iF4, "1")
        ElseIf AddDistinta = 107 Then
            If Not IO.File.Exists(RadTextv & Arch) Then Exit Sub
            Esito = CheckLogM()
            If Not Esito Then Exit Sub
            iF3 = FreeFile()
            FileOpen(iF3, RadTextv & Arch, OpenMode.Input)
            iF4 = FreeFile()
            FileOpen(iF4, NewF, OpenMode.Output)
            PrintLine(iF4, "1")
        Else
            iF3 = FreeFile()
            FileOpen(iF3, RadText & Arch, OpenMode.Input)
            iF4 = FreeFile()
            FileOpen(iF4, NewF, OpenMode.Output)
        End If
        Do
            Riga = LineInput(iF3)
            If Len(Riga) = 0 Then Riga = Chr(32)
            If AddDistinta = 106 Then
                'Cofimco    ------------------------
                Do
                    If Len(Riga) = 1 And Asc(Riga) < 32 Then
                        Riga = Chr(32)
                        Exit Do
                    End If
                    If Asc(Riga) < 32 Then
                        Riga = Right(Riga, Len(Riga) - 1)
                        Do
                            If Len(Riga) > 0 Then
                                If Asc(Riga) > 32 Then Riga = Right(Riga, Len(Riga) - 1) Else Exit Do
                            Else
                                Riga = Space(1)
                                Exit Do
                            End If
                        Loop
                    Else
                        Exit Do
                    End If
                Loop
                If Asc(Riga) = 12 Then Riga = "1"
                If Left(LTrim(Riga), 7) = "SEE ENC" Then Riga = Space(1)
                If Len(Riga) > 15 Then
                    Blank = True
                    For j = 1 To 13
                        If Mid(Riga, j, 1) <> Space(1) Then Blank = False
                    Next
                    If Blank Then Riga = Right(Riga, Len(Riga) - 12)
                End If
                '---------------------------------------------------
            Else
                If Len(Riga) < 40 And Asc(Riga) <> 49 Then Riga = Space(5) & Riga
            End If
            PrintLine(iF4, Riga)
            If EOF(iF3) Then Exit Do
        Loop
        FileClose(iF3) : FileClose(iF4) : Kill(RadText & Arch)
        Shell("NotePad " & NewF, AppWinStyle.NormalFocus)
404:    'UPGRADE_WARNING: Dir ha un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
        If Len(Dir(RadTextv & Arch)) > 0 Then Kill(RadTextv & Arch)
    End Sub
    Public Function MostraAiuto(ByRef iD As Integer, Optional ByRef Informa As RoutBase1.ChiaviMess = RoutBase1.ChiaviMess.MessCritical Or RoutBase1.ChiaviMess.MessOkOnly, Optional ByRef mioTesto As String = "") As RoutBase1.ChiaviMess
        Dim Testo, Tit As String
        If iD > 0 Then
            If Len(mioTesto) = 0 Then
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.Inizio.ConvertiCr(). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Testo = Monitor.Motore.Inizio.ConvertiCr(My.Resources.ResourceManager.GetString("str" + CStr(iD))) ' "Il gruppo di items da montare su ventilatore a comune non è stato definito correttamente"
            Else
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.Inizio.ConvertiCr(). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Testo = Monitor.Motore.Inizio.ConvertiCr(mioTesto)
            End If
            Tit = "Ventil - Messaggi di errore"
            If Not Informa And RoutBase1.ChiaviMess.MessCritical Then Tit = "Ventil"
            MostraAiuto = Monitor.Motore.Messaggio(Testo, Informa Or RoutBase1.ChiaviMess.MessHelpButton, Tit, RadiceHelp, iD)
        Else
            MsgBox("Errore sconosciuto", MsgBoxStyle.Information, "Ventil")
        End If
    End Function
    Sub Progetto()
        Dim Testo As String = ""
        If Asc(LTrim(Lav(0).Assieme(2))) < 33 Or Val(Lav(0).Assieme(2)) = 0 Then
            'Testo = RTrim$(at1(17))
            '     Testo = "Prima di eseguire un calcolo biso-|"
            'Testo = Testo + "gna identificare un'alternativa.  |"
            MostraAiuto(IDH_STR_AT17)
            MsgBox(Testo)
            Exit Sub
        End If
        IO.File.Delete(RadText & RTrim(Lav(0).Arch))
        HTRI8(0)
        Stop
    End Sub
    Sub Apri(ByRef File As String)
        Dim Nome As Str6
        Dim iErr As Short
        Nome.St = GlobalRoutines.Adjust(RTrim(File), 6)
        APRIPR(0, 0, Nome, iErr)
    End Sub
    Public Sub ApriVE1()
        Dim ifl As Short
        Prev = ""
        With finCurva.CommonDialog1Open
            'UPGRADE_WARNING: Filter ha un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
            .Filter = "Dati progetto ventilatore (*.VE1)|*.VE1"
            .InitialDirectory = Monitor.Motore.Inizio.Workdir
            .ShowDialog()
            FileVE1 = .FileName
            If Len(FileVE1) = 0 Then Exit Sub
            FilePRI = Left(FileVE1, Len(FileVE1) - 3) & "PSW"
            Prev = ""
            'UPGRADE_WARNING: Dir ha un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
            If Len(Dir(FileVE1)) = 0 Then Exit Sub
            ifl = FreeFile()
            FileOpen(ifl, FileVE1, OpenMode.Random, , , Len(Dati))
            'UPGRADE_WARNING: Get è stato aggiornato a FileGet e ha un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
            FileGet(ifl, Dati, 1)
            FileClose(ifl)
            RivdaFile()
        End With
    End Sub
    Public Sub RivdaFile()
        Select Case Dati.MO
            Case 1 : Dati.UNITA = 5
                UNITA = Dati.UNITA
                Altit = Dati.Elevazione
                ACFM = Dati.ACFM
                Tin = Dati.TARPAL
                Diam = Dati.DiamVent
                StatP = Dati.StaticPress
                Dens = Dati.AirDensity
            Case Else : UNITA = Dati.UNITA
                Altit = Dati.Elevazione * 0.3048
                ACFM = Dati.ACFM * 1.69901
                If UNITA = 1 Or UNITA = 2 Then ACFM = ACFM / 3600
                Tin = (Dati.TARPAL - 32) / 1.8
                Diam = Dati.DiamVent * Foot
                Dens = Dati.AirDensity * LbFt3
                Select Case UNITA
                    Case 1, 3 : StatP = Dati.StaticPress * Inch
                    Case 2, 4 : StatP = Dati.StaticPress * Inch * Grav '/ 0.1033 * 0.985
                End Select
        End Select
        z1 = 0
        With Dati
            RPM = .GiriVent
            kImboc = .CodImbocco - 1
            Altit = .Elevazione
            If .GiocoDiam = 0.005 Then TipoGap = 1 Else TipoGap = 2
            UNITA = .UNITA
            pr = .pr
            Npal = .Npal
            Item = .Item
            iDraft = .Draft
            PFUN = .PFUN
            PEFF = .PEFF
            iLingua = .Lingua
            If PFUN < 0 Or PFUN > 1 Then PFUN = 0
            If PEFF < 0 Or PEFF > 1 Then PEFF = 0
            If iLingua < 1 Or iLingua > 4 Then iLingua = 1
        End With
    End Sub
    Public Sub RivsuFile()
        With Dati
            Select Case UNITA
                Case 5 : .MO = 1 'british
                    .Elevazione = Altit
                    .ACFM = ACFM
                    .TARPAL = Tin
                    .DiamVent = Diam
                    .StaticPress = StatP
                    If z1 = 1 Then
                        .AirDensity = Dens
                    Else
                        .AirDensity = 0
                    End If
                Case Else : .MO = 2
                    .Elevazione = Altit / 0.3048
                    .ACFM = ACFM / 1.69901 ' (=60/.3048^3/3600)
                    If UNITA = 1 Or UNITA = 2 Then .ACFM = .ACFM * 3600
                    .TARPAL = 1.8 * Tin + 32
                    .DiamVent = Diam / Foot
                    If z1 = 1 Then
                        .AirDensity = Dens / LbFt3
                    Else
                        .AirDensity = 0
                    End If
                    Select Case UNITA
                        Case 1, 3 : .StaticPress = StatP / Inch
                        Case 2, 4 : .StaticPress = StatP / Inch / Grav ' * 0.1033 / 0.985
                    End Select
            End Select
            .GiriVent = RPM
            .CodImbocco = kImboc + 1
            .Elevazione = Altit
            If TipoGap = 1 Then .GiocoDiam = 0.005 Else .GiocoDiam = 0.003
            .UNITA = UNITA
            .pr = pr
            .Npal = Npal
            .Item = Item
            .Sigla = Sigla
            .Draft = iDraft
            .PFUN = PFUN
            .PEFF = PEFF
            .Lingua = iLingua
        End With
    End Sub
    Public Sub SalvVE1()
        Dim ifl As Short
        RivsuFile()
        ifl = FreeFile()
        FileOpen(ifl, FileVE1, OpenMode.Random, , , Len(Dati))
        'UPGRADE_WARNING: Put è stato aggiornato a FilePut e ha un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
        FilePut(ifl, Dati, 1)
        FileClose(ifl)
        ModifiedData = False
    End Sub
    Sub makepri(ByRef stampa As Boolean)
        Dim Riga, Ftesta As String
        Dim xx0, yy0 As Single
        Dim Text As String
        Dim Size, xx, yy, Spess As Single
        Dim Nome As String = ""
        Dim Number As Integer
        'UPGRADE_WARNING: Screen proprietà Screen.MousePointer presenta un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        Ftesta = "TESDXF2.DXF"
        Angle = 0
        Iniziaroutines()
        ipr = FreeFile()
220:    FileOpen(ipr, FilePRI, OpenMode.Input)
        If stampa Then
            GlobalRoutines.FormatS("non|")
            'UPGRADE_NOTE: È possibile che l'oggetto AcadApp non venga eliminato in modo permanente finché non venga raccolto nel Garbage Collector. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
            AcadApp = Nothing
            Monitor.Routines.ApriPri(Left(FilePRI, Len(FilePRI) - 4), "DWG", 0, 3, Ftesta, AcadApp)
            If AcadApp Is Nothing Then
                Monitor.Routines.ChiudiPRI()
                GoTo Fine
            End If
        End If
        With Monitor.Routines
            .Scala(-200, 1900, -200, 2770)
            Do
                Riga = LineInput(ipr)
                Select Case Left(Riga, 1)
                    Case "M"
                        Riga = Right(Riga, Len(Riga) - 1)
                        xx0 = Val(Left(Riga, InStr(Riga, ",") - 1))
                        yy0 = Val(Right(Riga, Len(Riga) - InStr(Riga, ",")))
                    Case "P"
                        IniziaBlocco(Nome, Number)
                        Text = Right(Riga, Len(Riga) - 1)
                        ' .texts xx0, yy0 + 40, Text$, Size! * 9, Angle!, Size!
                        .texts(xx0, yy0, Text, Size * 9, Angle, 0)
                        .FinisciBlocco(Nome)
                        Nome = ""
                    Case "D"
                        Riga = Right(Riga, Len(Riga) - 1)
                        IniziaBlocco(Nome, Number)
Rif:
                        xx = Val(Left(Riga, InStr(Riga, ",") - 1))
                        yy = Val(Right(Riga, Len(Riga) - InStr(Riga, ",")))
                        .tratto(xx0, yy0, xx, yy, 0.0!, 0)
                        xx0 = xx : yy0 = yy
                        Riga = Right(Riga, Len(Riga) - InStr(Riga, ","))
                        If InStr(Riga, ",") > 0 Then
                            Riga = Right(Riga, Len(Riga) - 1)
                            Riga = Right(Riga, Len(Riga) - InStr(Riga, ","))
                            If InStr(Riga, ",") > 0 Then GoTo Rif
                        End If
                        .FinisciBlocco(Nome)
                        Nome = ""
                    Case "S"
                        Size = Val(Right(Riga, Len(Riga) - 1))
                    Case "Q"
                        Angle = Val(Right(Riga, Len(Riga) - 1)) * PI / 2.0! '0 h; 1 V
                    Case "J"
                        Spess = Val(Right(Riga, Len(Riga) - 1)) / 10.0!
                        .tiplin(Spess, 0)
                End Select
                If EOF(ipr) Then Exit Do
            Loop
            If stampa Then .ChiudiPRI()
        End With
Fine:
        FileClose(ipr)
        'UPGRADE_WARNING: Screen proprietà Screen.MousePointer presenta un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        Exit Sub
    End Sub
    Private Sub IniziaBlocco(ByRef Nome As String, ByRef Number As Integer)
        With Monitor.Routines
            If Not Nome = "" Then
                .FinisciBlocco(Nome)
                Nome = ""
            End If
            Number = Number + 1
            Nome = "LP" & Trim(Str(Number))
            Stop
            '.IniziaBlocco(Nome)
        End With
    End Sub
    Public Function FileVEN() As String
        Dim Testo As String
        If daISA Then
            Testo = GlobalRoutines.Str2Cifre(Nrdit \ 2)
        Else
            Testo = Trim(Dati.Item)
        End If
        FileVEN = Monitor.Motore.Inizio.Workdir & Chr(92) & Archdir & Testo & ".VEN"
    End Function
    Public Sub LeggiAERFIB()
        Dim ifl As Short
        Dim File As String
        Dim i, j As Integer
        Dim k, solid As Short
        Dim Rec1 As RecAERFIB = New RecAERFIB
        Dim xP1(13, 3) As Single
        Dim xR1(13, 3) As Single
        Dim yP1(13, 3) As Single
        Dim yR1(13, 3) As Single
        Dim xSolid(7) As Single
        Rec1.Initialize()
        xSolid(1) = 0.3
        xSolid(2) = 0.354
        xSolid(3) = 0.531
        xSolid(4) = 0.709
        xSolid(5) = 1.063
        xSolid(6) = 1.417
        xSolid(7) = 1.7
        ifl = FreeFile()
        File = Monitor.Motore.Inizio.Archdir & "\AERFIB.DAT"
        FileDB = Monitor.Motore.Inizio.Archdir & "\AERFIB.mdb"
        myDataBase = DAOEngine.OpenDatabase(FileDB)
        objDatBase = New RoutBase1.DatBase(Monitor.Motore)
        objDatBase.objInizio = Monitor.Motore.Inizio
        tabella = myDataBase.OpenRecordset("SELECT * FROM Parabole")
        With tabella
            FileOpen(ifl, File, OpenMode.Random, , , Len(Record))
            For solid = 1 To 7
                FileGet(1, Record, 2 * solid - 1)
                FileGet(1, Rec1, 2 * solid)
                For i = 1 To 13
                    For j = 1 To 3
                        k = 6 * i + 2 * j - 7
                        xP1(i, j) = objDatBase.CVI(Record.Numeri(k)) / 100.0#
                        xR1(i, j) = objDatBase.CVI(Rec1.Numeri(k)) / 100.0#
                        yP1(i, j) = objDatBase.CVI(Record.Numeri(k + 1)) / 100.0#
                        yR1(i, j) = objDatBase.CVI(Rec1.Numeri(k + 1)) / 100.0#
                    Next j
                    .AddNew()
                    .Fields("idPala").Value = 1
                    .Fields("Solidity").Value = xSolid(solid)
                    .Fields("Angolo").Value = i
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto i. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    .Fields("xPm").Value = xP1(i, 1)
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto i. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    .Fields("xpmin").Value = xP1(i, 2)
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto i. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    .Fields("xpmax").Value = xP1(i, 3)
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto i. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    .Fields("yPm").Value = yP1(i, 1)
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto i. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    .Fields("yPmin").Value = yP1(i, 2)
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto i. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    .Fields("yPmax").Value = yP1(i, 3)
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto i. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    .Fields("xRm").Value = xR1(i, 1)
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto i. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    .Fields("xRmin").Value = xR1(i, 2)
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto i. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    .Fields("xRmax").Value = xR1(i, 3)
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto i. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    .Fields("yRm").Value = yR1(i, 1)
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto i. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    .Fields("yRmin").Value = yR1(i, 2)
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto i. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    .Fields("yRmax").Value = yR1(i, 3)
                    .Update()
                Next i
            Next
        End With
    End Sub
    Public Sub SalvAs()
        'UPGRADE_WARNING: La variabile CommonDialog non è stata aggiornata Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="671167DC-EA81-475D-B690-7A40C7BF4A23"'
        With finCurva.CommonDialog1Save
            'UPGRADE_WARNING: Filter ha un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
            .Filter = "Dati progetto ventilatore (*.VE1)|*.VE1"
            .InitialDirectory = Monitor.Motore.Inizio.Workdir
            .ShowDialog()
            FileVE1 = .FileName
        End With
        If FileVE1 = "" Then Exit Sub
        FilePRI = Left(FileVE1, Len(FileVE1) - 3) & "PSW"
        SalvVE1()
    End Sub
    Public Function SelezPala() As Boolean
        Dim i As Short
        Dim Descr As String
        Dim ii As Short
        Dim Pala As String
        SelezPala = True
        ii = InStr(Tippal, "-")
        If ii > 0 Then
            Pala = Trim(Left(Tippal, ii - 2))
        Else
            Pala = Trim(Tippal)
        End If
        For i = 1 To nprofil
            ii = InStr(Profil(i), "-")
            If ii > 0 Then
                Sigla = Left(Profil(i), ii - 2)
            Else
                Sigla = Trim(Profil(i))
            End If
            If Trim(Sigla) = Pala Then
                pr = i
                Exit For
            End If
        Next
        If nuovePar Then
            i = InStr(Tippal, "-")
            If i > 0 Then
                Sigla = Trim(Left(Tippal, i - 1))
                Descr = Right(Tippal, Len(Tippal) - i - 1)
            Else
                Sigla = Trim(Tippal)
            End If
            Dati.Sigla = Sigla
            tabella.FindFirst("Sigla='" & Sigla & "'") ' AND Descrizione='" + Descr + "'"
            Descr = tabella.Fields("Descrizione").Value
            idPala = tabella.Fields("idPala").Value
            corda = tabella.Fields("corda").Value
            r770 = tabella.Fields("RPM").Value
            d1524 = tabella.Fields("Diametro").Value
            '   End If
        Else
            Select Case pr
                Case 1 : corda = 270
                Case 2 : corda = 360
                Case 3 : corda = 530 'nuova pala
                Case 4 : corda = 180
                Case Else
                    MsgBox("Questo tipo di pala non può essere trattato tramite le correlazioni storiche")
                    SelezPala = False
            End Select
            r770 = 770
            d1524 = 1524
        End If
    End Function
    Public Sub AprimyDb()
        FileDB = Monitor.Motore.Inizio.Archdir & "\AERFIB.mdb"
        myDataBase = DAOEngine.OpenDatabase(FileDB)
        tabella = myDataBase.OpenRecordset("SELECT * FROM Pale")
    End Sub
    Public Sub ChiudimyDb()
        tabella.Close()
        tabella = Nothing
        myDataBase.Close()
        myDataBase = Nothing
    End Sub

    Public Sub GeneraGrafico()
        Dim Titolo As String
        Dim x() As Single
        Dim y() As Single
        Dim Stmin, Qmin, Qmax, Stmax As Single
        Dim Angoli() As Single
        Dim iQ As Short
        Dim n1, i, n, i1 As Short
        TabDati = myDataBase.OpenRecordset("SELECT DISTINCT nPale FROM DatiCalcolati")
        With TabDati
            .MoveLast()
            n = .RecordCount
            .MoveFirst()
            ReDim Pale(n)
            Do Until .EOF
                i = i + 1
                Pale(i) = Str(.Fields("nPale").Value)
                .MoveNext()
            Loop
        End With
        iQ = Monitor.Motore.Quale(n, "Serie su n° pale", Pale, "", 2)
        If iQ = 0 Then Exit Sub
        TabDati = myDataBase.OpenRecordset("SELECT DISTINCT Calett FROM DatiCalcolati WHERE nPale=" & Str(CDbl(Pale(iQ))))
        Npal = Val(Pale(iQ))
        i = 0
        With TabDati
            .MoveLast()
            n = .RecordCount
            ReDim Angoli(n)
            .MoveFirst()
            Do Until .EOF
                i = i + 1
                Angoli(i) = .Fields("Calett").Value
                .MoveNext()
            Loop
            .Close()
        End With
        Grafico = New RoutBase1.clsGrafico
        Grafico.Motore = Monitor.Motore
        finCurva.glocPic.Clear(Color.White)
        Titolo = Str(Npal) & " Pale" & Str(idPala) & " D." & Str(Diam) & Str(RPM) & "RPM" & Str(Torcit) & "°/m"
        TrovaEstremi(Qmin, Qmax, Stmin, Stmax)
        Qmin = Int(Qmin / 10) * 10
        Qmax = (Int(Qmax / 10) + 1) * 10
        Stmin = Int(Stmin / 10) * 10
        Stmax = (Int(Stmax / 10) + 1) * 10 ' / 2
        Grafico.Inizializza(Stmax, Stmin, Qmax, Qmin, "Q (m3/s)", "StP (Pa)", Titolo, finCurva.Picture1)
        For i = 1 To n
            TabDati = myDataBase.OpenRecordset("SELECT * FROM DatiCalcolati WHERE Calett=" & Str(Angoli(i)) & "AND nPale=" & Str(Npal) & " ORDER BY pstat")
            With TabDati
                .MoveLast()
                n1 = .RecordCount
                .MoveFirst()
                ReDim x(n1)
                ReDim y(n1)
                i1 = 1
                Do Until .EOF
                    x(i1) = .Fields("Q").Value
                    y(i1) = .Fields("pstat").Value
                    i1 = i1 + 1
                    .MoveNext()
                Loop
                .Close()
            End With
            Grafico.DisCurva(x, y, 1, n1, Str(Angoli(i)), Drawing2D.DashStyle.Solid)
        Next
    End Sub

    Public Sub TrovaEstremi(ByRef Qmin As Single, ByRef Qmax As Single, ByRef Stmin As Single, ByRef Stmax As Single)
        TabDati = myDataBase.OpenRecordset("SELECT * FROM DatiCalcolati WHERE nPale=" & Str(Npal))
        Qmin = Infinito : Stmin = Infinito
        Qmax = -Infinito : Stmax = -Infinito
        With TabDati
            Do Until .EOF
                If .Fields("Q").Value > Qmax Then Qmax = .Fields("Q").Value
                If .Fields("Q").Value < Qmin Then Qmin = .Fields("Q").Value
                If .Fields("pstat").Value > Stmax Then Stmax = .Fields("pstat").Value
                If .Fields("pstat").Value < Stmin Then Stmin = .Fields("pstat").Value
                .MoveNext()
            Loop
            .Close()
        End With
    End Sub
    Public Sub AggiungiParab()
        Dim Qmax, Qmin, Q As Single
        Dim k As Short
        Dim dQ, p As Single
        Dim Q0, P0 As Single
        'Dati sperimentali senza pinna best-fittati
        '5° y = -0.0119x2 - 0.1308x + 174.77;min 51 max114
        '8° y = -0.0115x2 - 0.1039x + 192.09;min 56 max120
        '11° y = -0.0135x2 + 0.5638x + 166.86;min 56 max120
        '14° y = -0.0173x2 + 1.5175x + 142.99;min 56 max120
        With finCurva
            .locPen.Width = 4
            .locPen.DashStyle = Drawing2D.DashStyle.Dash
            For k = 1 To 4
                Select Case k
                    Case 1 : Qmin = 51 : Qmax = 114
                    Case Else : Qmin = 56 : Qmax = 120
                End Select
                dQ = (Qmax - Qmin) / 10
                For Q = Qmin To Qmax Step dQ
                    Select Case k
                        Case 1 : p = -0.0119 * Q ^ 2 - 0.1308 * Q + 174.77
                        Case 2 : p = -0.0115 * Q ^ 2 - 0.1039 * Q + 192.09
                        Case 3 : p = -0.0135 * Q ^ 2 + 0.5638 * Q + 166.86
                        Case 4 : p = -0.0173 * Q ^ 2 + 1.5175 * Q + 142.99
                    End Select
                    p = p * Npal / 5
                    If Q = Qmin Then
                        P0 = p
                        Q0 = Q
                    ElseIf Q = Qmin + dQ Then
                        .glocPic.DrawLine(.locPen, Q0, P0, Q, p)
                        Currentx = Q
                        Currenty = p
                    Else
                        .glocPic.DrawLine(.locPen, Currentx, Currenty, Q, p)
                    End If
                Next
            Next
        End With
    End Sub
    Public Sub AggiungiFib()
        'UPGRADE_WARNING: È possibile che si debba inizializzare le matrici nella struttura TabFIB prima di poterle utilizzare. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
        Dim Angoli() As Single
        Dim n As Short
        Dim TabFIB As dao.Recordset
        Dim U, Qav, pdyn As Single
        Dim i As Short
        Dim iQ As Short
        Dim idPala As String
        Dim p As Single
        TabDati = myDataBase.OpenRecordset("SELECT DISTINCT idPala FROM DatiCalcolati")
        With TabDati
            .MoveLast()
            n = .RecordCount
            .MoveFirst()
            Dim Pale(n) As String
            Do Until .EOF
                i = i + 1
                Pale(i) = Str(.Fields("idPala").Value)
                .MoveNext()
            Loop
        End With
        iQ = Monitor.Motore.Quale(n, "Serie su id pala", Pale, "", 1)
        If iQ = 0 Then Exit Sub
        idPala = Str(CDbl(Pale(iQ)))
        TabDati = myDataBase.OpenRecordset("SELECT DISTINCT nPale FROM DatiCalcolati WHERE idPala=" & idPala)
        With TabDati
            .MoveLast()
            n = .RecordCount
            .MoveFirst()
            ReDim Pale(n)
            i = 0
            Do Until .EOF
                i = i + 1
                Pale(i) = Str(.Fields("nPale").Value)
                .MoveNext()
            Loop
        End With
        iQ = Monitor.Motore.Quale(n, "Serie su n° pale", Pale, "", 1)
        If iQ = 0 Then Exit Sub
        TabDati = myDataBase.OpenRecordset("SELECT DISTINCT Calett FROM DatiCalcolati WHERE nPale=" & Str(CDbl(Pale(iQ))) & " AND idPala=" & idPala)
        Npal = Val(Pale(iQ))
        i = 0
        With TabDati
            .MoveLast()
            n = .RecordCount
            ReDim Angoli(n)
            .MoveFirst()
            Do Until .EOF
                i = i + 1
                Angoli(i) = .Fields("Calett").Value
                .MoveNext()
            Loop
            .Close()
        End With
        TabFIB = myDataBase.OpenRecordset("SELECT * FROM Parabole")
        Diam = 4267 'XXXXXXXXXXXXXXXXXXXXXXXXXXXX
        With TabFIB
            For i = 1 To n
                .AddNew()
                .Fields("idPala").Value = Val(idPala)
                .Fields("nPale").Value = Npal
                .Fields("Indiceang").Value = i
                .Fields("Angolo").Value = Angoli(i)
                'corda = 530: Diam = 4267
                .Fields("Solidity").Value = Npal * 530 / Diam 'corda / Diam
                TabDati = myDataBase.OpenRecordset("SELECT * FROM DatiCalcolati WHERE Calett=" & Str(Angoli(i)) & " AND nPale=" & Str(CDbl(Pale(iQ))) & " AND idPala=" & idPala & " ORDER BY Q")
                TabDati.MoveFirst()
                .Fields("xpmin").Value = TabDati.Fields("Q").Value
                .Fields("yPmin").Value = TabDati.Fields("pstat").Value / Grav
                .Fields("xRmin").Value = TabDati.Fields("Q").Value
                U = TabDati.Fields("Q").Value / (PI * (Diam / 1000) ^ 2 / 4)
                pdyn = 1.2 * U * U / 2
                .Fields("yRmin").Value = TabDati.Fields("etastat").Value * (TabDati.Fields("pstat").Value + pdyn) / TabDati.Fields("pstat").Value * 100
                TabDati.MoveLast()
                .Fields("xpmax").Value = TabDati.Fields("Q").Value
                .Fields("yPmax").Value = TabDati.Fields("pstat").Value / Grav
                .Fields("xRmax").Value = TabDati.Fields("Q").Value
                U = TabDati.Fields("Q").Value / (PI * (Diam / 1000) ^ 2 / 4)
                pdyn = 1.2 * U * U / 2
                .Fields("yRmax").Value = TabDati.Fields("etastat").Value * (TabDati.Fields("pstat").Value + pdyn) / TabDati.Fields("pstat").Value * 100
                TabDati.MoveFirst()
                TabDati.MoveNext()
                If (TabDati.Fields("pstat").Value / Grav > .Fields("yPmin").Value) Then 'vuol dire che c'è un massimo
                    Do
                        p = TabDati.Fields("pstat").Value / Grav
                        TabDati.MoveNext()
                        If TabDati.Fields("pstat").Value / Grav < p Then Exit Do
                    Loop
                Else
                    Qav = (.Fields("xpmax").Value + .Fields("xpmin").Value) / 2
                    Do
                        If TabDati.Fields("Q").Value > Qav Then Exit Do
                        TabDati.MoveNext()
                    Loop
                End If
                .Fields("xPm").Value = TabDati.Fields("Q").Value
                .Fields("yPm").Value = TabDati.Fields("pstat").Value / Grav
                .Fields("xRm").Value = TabDati.Fields("Q").Value
                U = TabDati.Fields("Q").Value / (PI * (Diam / 1000) ^ 2 / 4)
                pdyn = 1.2 * U * U / 2
                .Fields("yRm").Value = TabDati.Fields("etastat").Value * (TabDati.Fields("pstat").Value + pdyn) / TabDati.Fields("pstat").Value * 100
                .Update()
            Next
        End With
    End Sub
End Module