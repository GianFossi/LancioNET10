Option Strict Off
Option Explicit On
Imports System.Runtime.InteropServices
Module modMain
    Structure Risultati
        Dim Temperatura As Single
        Dim Pressione As Single
        Dim VapMolFraction As Single
        Dim VapMasFraction As Single
        <VBFixedArray(5)> Dim Entalpie() As Single
        <VBFixedArray(5)> Dim Entropie() As Single
        <VBFixedArray(3)> Dim PesiMol() As Single
        <VBFixedArray(2)> Dim Density() As Single
        <VBFixedArray(2)> Dim TCrit() As Single
        <VBFixedArray(2)> Dim PCrit() As Single
        Dim CpGas As Single
        Dim CvGas As Single
        Dim SurfTens As Single
        <VBFixedArray(2)> Dim Visco() As Single
        <VBFixedArray(2)> Dim Conduc() As Single
        <VBFixedArray(2)> Dim CompressF() As Single
        Dim HAcqLiq As Single
        Dim MolAcqLiq As Single
        Dim MasAcqLiq As Single
        Dim kConv As Short
        Dim indice As Short

        'UPGRADE_TODO: "Initialize" deve essere chiamato per inizializzare istanze di questa struttura. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="B4BFF9E0-8631-45CF-910E-62AB3970F27B"'
        Public Sub Initialize()
            'UPGRADE_WARNING: Il limite inferiore della matrice Entalpie è stato cambiato da 1 a 0. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
            ReDim Entalpie(5)
            'UPGRADE_WARNING: Il limite inferiore della matrice Entropie è stato cambiato da 1 a 0. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
            ReDim Entropie(5)
            'UPGRADE_WARNING: Il limite inferiore della matrice PesiMol è stato cambiato da 1 a 0. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
            ReDim PesiMol(3)
            'UPGRADE_WARNING: Il limite inferiore della matrice Density è stato cambiato da 1 a 0. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
            ReDim Density(2)
            'UPGRADE_WARNING: Il limite inferiore della matrice TCrit è stato cambiato da 1 a 0. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
            ReDim TCrit(2)
            'UPGRADE_WARNING: Il limite inferiore della matrice PCrit è stato cambiato da 1 a 0. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
            ReDim PCrit(2)
            'UPGRADE_WARNING: Il limite inferiore della matrice Visco è stato cambiato da 1 a 0. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
            ReDim Visco(2)
            'UPGRADE_WARNING: Il limite inferiore della matrice Conduc è stato cambiato da 1 a 0. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
            ReDim Conduc(2)
            'UPGRADE_WARNING: Il limite inferiore della matrice CompressF è stato cambiato da 1 a 0. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
            ReDim CompressF(2)
        End Sub
    End Structure
    Structure St2
        <VBFixedString(2), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=2)> Public St As String
    End Structure
    Structure St40
        <VBFixedString(40), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=40)> Public St As String
    End Structure
    Structure Stream
        <VBFixedString(80), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=80)> Public Sk() As String
        Public Sub initialize()
            ReDim Sk(100)
        End Sub
    End Structure
    Structure CondCurva
        <VBFixedString(1), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=1)> Public Tipo As String
        <VBFixedString(1), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=1)> Public PadS As String
        Dim Npun As Short
        Dim Temp As Single '1
        Dim Pres As Single '2
        Dim Xgas As Single '3
        Dim Entl As Single '4
        Dim Hliq As Single '5
        Dim Hgas As Single '6
        Dim Cgas As Single '7
        Dim Visg As Single '8
        Dim Visl As Single '9
        Dim Cong As Single '10
        Dim Conl As Single '11
        Dim Cfac As Single '12
        Dim Cliq As Single '13
        Dim DenV As Single '14
        Dim Sgra As Single '15
        Dim MolT As Single '16
        Dim MolL As Single '17
        Dim MolG As Single '18
        Dim XAcq As Single
        Dim HAcq As Single
        <VBFixedArray(10)> Dim Pad() As Single

        'UPGRADE_TODO: "Initialize" deve essere chiamato per inizializzare istanze di questa struttura. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="B4BFF9E0-8631-45CF-910E-62AB3970F27B"'
        Public Sub Initialize()
            'UPGRADE_WARNING: Il limite inferiore della matrice Pad è stato cambiato da 1 a 0. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
            ReDim Pad(10)
        End Sub
    End Structure
    Structure CondParen
        'UPGRADE_WARNING: La dimensione della stringa di lunghezza fissa deve essere contenuta nel buffer. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(1), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=1)> Public Tipo() As Char
        <VBFixedArray(18)> Dim Vall() As Single

        'UPGRADE_TODO: "Initialize" deve essere chiamato per inizializzare istanze di questa struttura. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="B4BFF9E0-8631-45CF-910E-62AB3970F27B"'
        Public Sub Initialize()
            'UPGRADE_WARNING: Il limite inferiore della matrice Vall è stato cambiato da 1 a 0. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
            ReDim Vall(18)
        End Sub
    End Structure
    'UPGRADE_WARNING: La struttura St40 potrebbe richiedere attributi di marshalling da passare come argomento a questa istruzione Declare. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
    'UPGRADE_WARNING: La struttura St40 potrebbe richiedere attributi di marshalling da passare come argomento a questa istruzione Declare. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
    'UPGRADE_WARNING: La struttura St40 potrebbe richiedere attributi di marshalling da passare come argomento a questa istruzione Declare. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
    'UPGRADE_WARNING: La struttura Stream potrebbe richiedere attributi di marshalling da passare come argomento a questa istruzione Declare. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
    Declare Sub SELVA Lib "WaldLib.dll" (ByRef S As Stream, ByRef f As St40, ByRef firma As St40, ByRef i As Short, ByRef arch As St40)
    'UPGRADE_WARNING: La struttura Risultati potrebbe richiedere attributi di marshalling da passare come argomento a questa istruzione Declare. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
    Declare Sub RECUPERA Lib "WaldLib.dll" (ByRef r As Risultati, ByRef n As Short)
    Public Const Conn As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source="
    Public RadiceHelp As String '= "C:\BASE\ESEGUI\BIN\AiutoISA.chm"
    Public Const IDH_ERRFORTRAN As Short = 1000
    Public Const IDH_LIMITAZIONI As Short = 1010
    Public Const IDH_SPECNONIMPL As Short = 1020
    Public Const IDH_NONACQUA As Short = 1030
    Public Const IDH_NONTXT As Short = 1040
    Public Const IDH_TEXTNULL As Short = 1050
    Public Const IDH_MF_MOLPOND As Short = 2000
    Public Const IDH_MF_OPTEQUIL As Short = 2010
    Public Const IDH_MF_ENTENTR As Short = 2020
    Public Const IDH_MF_PROCEDI As Short = 2030
    Public Const IDH_MF_RAPPORTO As Short = 2040
    Public Const IDH_MF_DIAGNOSI As Short = 2050
    Public Const IDH_MF_CONTROLITER As Short = 2060
    Public Const IDH_MF_HCLIQ As Short = 2070
    Public Const IDH_MF_ACQUALIQ As Short = 2080
    Public Const IDH_MF_COSTCRIT As Short = 2090
    Public Const IDH_MF_BINARY As Short = 2100
    Public Const IDH_MF_UNIMIS As Short = 2110
    Public Const IDH_MF_RELABS As Short = 2120
    Public Const IDH_MF_DATIINIZIALI As Short = 2130
    Public Const IDH_MF_DI_DaCalcPrec As Short = 2131
    Public Const IDH_MF_DI_Portata As Short = 2132
    Public Const IDH_MF_DI_Temp As Short = 2133
    Public Const IDH_MF_DI_Press As Short = 2134
    Public Const IDH_MF_DI_xVap As Short = 2135
    Public Const IDH_MF_DI_xHCliq As Short = 2136
    Public Const IDH_MF_DI_xAcqua As Short = 2137
    Public Const IDH_MF_DI_H As Short = 2138
    Public Const IDH_MF_DI_Q As Short = 2139
    Public Const IDH_MF_DI_S As Short = 22139
    Public Const IDH_MF_RISLIQ As Short = 2140
    Public Const IDH_MF_RISAER As Short = 2150
    Public Const IDH_MF_CONDEVAP As Short = 2200
    Public Const IDH_MF_ASSEGNAPUNTI As Short = 2201
    Public Const IDH_MF_cmbTIPCALC As Short = 2300
    Public Const IDH_MF_cmbTRASF As Short = 2302
    Public Const IDH_MF_cmbVARIAB As Short = 2304
    Public Const IDH_MF_cmbZ As Short = 2306
    Public Const IDH_MF_cmdLISTACOMP As Short = 2308
    Public Stub As StubW2000.clsSW2000
    Public Stub9 As StubW9.clsSW9
    Public Routines As RoutBase1.Routines
    Public iQuale As Short
    Public myAssembly As System.Reflection.Assembly
    'UPGRADE_WARNING: È possibile che si debba inizializzare le matrici nella struttura ProblWLD prima di poterle utilizzare. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
    Public ProblWLD As prbWald
    Public RadiceISA As String
    Public DaIsa As Short ' 1 da ISA 2 da PPG
    'UPGRADE_WARNING: È possibile che si debba inizializzare le matrici nella struttura Schede prima di poterle utilizzare. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
    Public Schede As Stream
    Public iScheda As Short
    Public Titoli(12) As String
    Public Formati(18) As String
    Public FF(34) As String
    Public Monitor As wldMonitor
    Public job As RoutBase1.clsjob
    Public AcquaPresente As Boolean
    Public NomiComponenti As Collection
    Public Nomi(100) As String
    Public Tpun() As Single
    Public Ppun() As Single
    Public Hpun() As Single
    Public Tipo() As String
    Public AddRigaCurva As Boolean
    Public FaseDati As Short
    Public mioApert As frmApert
    Public FormDB As frmDB
    Public rmHelpStrings As Resources.ResourceManager
    Friend Funzioni As New RoutBase1.clsTrigon
    Friend FileDataBase As String
    Friend Adapter As CondCurvaDataSetTableAdapters.CondCurvaTableAdapter
    Friend t As CondCurvaDataSet.CondCurvaDataTable
    Friend cmd As OleDb.OleDbDataAdapter
    Friend Connection As OleDb.OleDbConnection
    'COMMON SHARED /Bdata/ Nit AS St2, Ncom AS INTEGER, Scelta() AS INTEGER, Sceltaf() AS INTEGER, Nome$()
    'COMMON SHARED /Bdata/ Dom$(), Risp$(), LungSt() AS INTEGER, Monitor.motore.problem.ClientPlant, Monitor.motore.problem.Commessa, Monitor.motore.problem.Problema, Monitor.motore.problem.Author, FF$()
    'COMMON SHARED /Bdata/ Tpun() AS SINGLE, Ppun() AS SINGLE, ProblWLD.Npun AS INTEGER
    'COMMON SHARED /Bdata/ Compos() AS SINGLE, Tipo() AS STRING * 1, Hpun() AS SINGLE
    'COMMON SHARED /Bdata/ ProblWLD.Tequi$, IntT AS SINGLE, ProblWLD.Pequi$, IntP AS SINGLE
    'COMMON SHARED /Bdata/ ProblWLD.iUnit AS INTEGER, ProblWLD.iEquil AS INTEGER, ProblWLD.iIdeal AS INTEGER
    'COMMON SHARED /Bdata/ ProblWLD.iCost AS INTEGER, ProblWLD.iAcqua AS INTEGER, ProblWLD.iHc    AS INTEGER
    'COMMON SHARED /Bdata/ ProblWLD.x AS INTEGER, y AS INTEGER, Z AS INTEGER, iF2 AS INTEGER
    'COMMON SHARED /Bdata/ Titoli(), Formati(), iF1 AS INTEGER, Variab1 AS SINGLE, Variab2 AS SINGLE
    'COMMON SHARED /Bdata/ Tzone()  AS SINGLE, Hzone() AS SINGLE, Tipzone() AS STRING * 4, Nzone AS INTEGER
    'Dim Scelta(110) As Integer, Sceltaf(50) As Integer
    'Dim Nome$(110), Dom$(10), Risp$(10), LungSt(10) As Integer
    'Dim Tpun(40) As Single, Ppun(40) As Single, Tipo(40) As String * 1, Hpun(40) As Single
    'Dim Compos(50) As Single
    'Dim Tzone(13) As Single, Hzone(13) As Single, Tipzone(13) As String * 4
    '-------------------------------------------------------------
    'Dim Stringa(1 To 20) As String
    'DiNu:
    '   Lav(0).Assieme(4 - 1 + Lav(0).IndG) = Str$(Alert(4, a$, 4, 3, 17, 68, "1", "2", "3") - 1)
    'Rifa: ' If AddDistinta > 0 Then Retri
    '!!!!!Shell "MOLLHC " + FileDat$ + " " + FileOut$ + " >NUL"
    'Req:
    '    ic = 1
    '    Do
    '      Line Input #4, Stringa(ic)
    '      If EOF(4) Then Exit Do
    '      If Len(LTrim$(Stringa(ic))) = 0 Then Exit Do
    '      ic = ic + 1
    '    Loop
    '    ic = ic - 1
    'Return

    Sub Aggior(ByRef As1 As Single, ByRef jcode As Short)
        Dim i, j As Short
        Dim t, H As Single
        Dim St, St1 As Single
        With ProblWLD
            If jcode <= 4 Then
                'converti da H a T
                For i = 1 To .Npun
                    If Hpun(i) < As1 Then
                        If i > 1 And Hpun(i) <> Hpun(i - 1) Then
                            t = Tpun(i - 1) + (Tpun(i) - Tpun(i - 1)) * (As1 - Hpun(i - 1)) / (Hpun(i) - Hpun(i - 1))
                            H = As1
                        Else
                            t = Tpun(i)
                            H = As1
                        End If
                        Exit For
                    End If
                Next
            Else
                For i = 1 To .Npun
                    If Tpun(i) < As1 Then
                        If i > 1 And Tpun(i) <> Tpun(i - 1) Then
                            H = Hpun(i - 1) + (Hpun(i) - Hpun(i - 1)) * (As1 - Tpun(i - 1)) / (Tpun(i) - Tpun(i - 1))
                            t = As1
                        Else
                            H = Hpun(i)
                            t = As1
                        End If
                        Exit For
                    End If
                Next
            End If
            If .NZONE = 13 Then
                St = 1.0E+20
                For i = 1 To .NZONE
                    St1 = System.Math.Abs(.Tzone(i) - As1)
                    If St1 < St Then St = St1 : j = i
                Next
                For i = j To .NZONE - 1
                    .Tzone(i) = .Tzone(i + 1)
                    .Hzone(i) = .Hzone(i + 1)
                    .TipZone(i) = .TipZone(i + 1)
                Next
                .NZONE = 12
                'elimina il piu' vicino a As
            End If
            .NZONE = .NZONE + 1
            .Tzone(.NZONE) = t
            .Hzone(.NZONE) = H
        End With
        'sorta
        SortaZ()
    End Sub
    Sub Entalpie(ByRef File As String)
        'UPGRADE_WARNING: È possibile che si debba inizializzare le matrici nella struttura Curva1 prima di poterle utilizzare. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
        'UPGRADE_WARNING: È possibile che si debba inizializzare le matrici nella struttura Curva prima di poterle utilizzare. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
        Dim Curva, Curva1 As New CondCurva
        Dim iF3, i As Short
        Dim Entl, Entg As Single
        iF3 = FreeFile()
        FileOpen(iF3, File, OpenMode.Random, , , Len(Curva))
        i = 1
        Entl = False : Entg = False
        'UPGRADE_WARNING: Get è stato aggiornato a FileGet e ha un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
        FileGet(iF3, Curva, 2)
        If Curva.Hliq = 0.0! Then Entl = True
        If Curva.Hgas = 0.0! Then Entg = True
        Do
            'UPGRADE_WARNING: Get è stato aggiornato a FileGet e ha un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
            FileGet(iF3, Curva, i)
            If EOF(iF3) Then Exit Do
            'UPGRADE_WARNING: Get è stato aggiornato a FileGet e ha un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
            FileGet(iF3, Curva1, i + 1)
            If EOF(iF3) Then Exit Do
            If Entl Then
                If i = 1 Then Curva.Hliq = 0.0!
                Curva1.Hliq = Curva.Hliq + (Curva.Cliq + Curva1.Cliq) / 2.0! * (Curva1.Temp - Curva.Temp)
            End If
            If Entg Then
                If i = 1 Then Curva.Hgas = 0.0!
                Curva1.Hgas = Curva.Hgas + (Curva.Cgas + Curva1.Cgas) / 2.0! * (Curva1.Temp - Curva.Temp)
            End If
            'UPGRADE_WARNING: Put è stato aggiornato a FilePut e ha un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
            FilePut(iF3, Curva1, i + 1)
            i = i + 1
        Loop
        FileClose(iF3)
    End Sub
    Sub Finale()
        Dim i, j As Short
        With ProblWLD
            If .NZONE = 0 Then Exit Sub
            For i = 1 To .NZONE
                .TipZone(i) = "N"
                For j = 1 To .Npun - 1
                    If Hpun(j) >= .Hzone(i) And Hpun(j + 1) <= .Hzone(i) And (Tipo(j) = "D" Or Tipo(j) = "F" Or Tipo(j) = "B") And (Tipo(j + 1) = "D" Or Tipo(j + 1) = "F" Or Tipo(j + 1) = "B") Then .TipZone(i) = "C"
                    If Hpun(j) >= .Hzone(i + 1) And Hpun(j + 1) <= .Hzone(i + 1) And (Tipo(j) = "D" Or Tipo(j) = "F" Or Tipo(j) = "B") And (Tipo(j + 1) = "D" Or Tipo(j + 1) = "F" Or Tipo(j + 1) = "B") Then .TipZone(i) = "C"
                Next j
            Next i
        End With
    End Sub

    Function iConvert2(ByRef a As String) As Short
        'Nit.St = a$
        'iFile = FreeFile
        'Open "DUM" For Random As #iFile Len = 2
        'Put #iFile, 1, Nit
        'FIELD #iFile, 2 AS Check$
        'GET #iFile, 1
        'iConvert2 = CVI(Check$)
        'Close #iFile
        'Kill "DUM"
    End Function

    Sub Iniziale()
        Dim i As Short
        With ProblWLD
            For i = 1 To .Npun
                If Tipo(i) = "D" Or Tipo(i) = "B" Then
                    .NZONE = .NZONE + 1
                    .Tzone(.NZONE) = Tpun(i)
                    .Hzone(.NZONE) = Hpun(i)
                End If
            Next
        End With
    End Sub

    Sub miomenu()
        'LOCATE 1, 40: Print "NEXT";
        'LOCATE 1, 45: Print "PREV";
        'LOCATE 1, 50: Print "REDO";
        'LOCATE 1, 55: Print "GO  ";
        'LOCATE 1, 60: Print "HELP";
    End Sub

    Function Punto(ByRef a As String) As String
        Dim i, l As Short
        Dim a1 As String
        i = InStr(1, a, ".")
        If i > 0 Then Punto = a : Exit Function
        l = Len(a)
        a1 = Trim(a)
        If Len(a1) < l Then
            Punto = Funzioni.Adjust(a1 & ".", l)
        Else
            Punto = New String("?", l)
        End If
    End Function

    Sub Putzone()
        Dim i As Short
        Dim Colore As Color
        FormDB.mypen.DashStyle = Drawing2D.DashStyle.Dash
        With ProblWLD
            If .NZONE = 0 Then Exit Sub
            For i = 0 To .NZONE
                If .PassZone(i) = 0 Then Colore = Color.Red Else Colore = Color.Blue
                FormDB.mypen.Color = Colore
                FormDB.mygraphics.DrawLine(FormDB.mypen, .Tzone(i), FormDB.yBot, .Tzone(i), FormDB.yTop)
            Next
        End With
        FormDB.mypen.DashStyle = Drawing2D.DashStyle.Solid
    End Sub

    Sub Retri()
        'n = Val(Lav(0).Assieme(2))
        'If n < 1 Or n > 5 Then Print "Errore in Retri": Stop
        'File$ = RTrim$(Workdir) + "\" + Monitor.Motore.Problem.Commessa + Right$(Str$(n), 1) + ".RA3"
        'If Len(Dir$(File$)) = 0 Then Exit Sub
        'iF2 = FreeFile
        'Open File$ For Input As #iF2
        'Input #iF2, Ncom
        'For i = 1 To Ncom: Input #iF2, Compos(i): Next
        'For i = 1 To 100: Input #iF2, Scelta(i): Next
        'Input #iF2, ProblWLD.Npun
        'For i = 1 To ProblWLD.Npun: Input #iF2, Tpun(i), Ppun(i): Next
        'Input #iF2, Variab1, Variab2
        'Input #iF2, ProblWLD.Tequi$, ProblWLD.Pequi$, IntT, IntP
        'Input #iF2, ProblWLD.iUnit, ProblWLD.iEquil, ProblWLD.iIdeal, ProblWLD.iCost, ProblWLD.iAcqua, ProblWLD.iHc
        'Close #iF2
    End Sub

    Sub Salva()
        Dim File As String
        Dim iF2, i As Short
        'Dim n As Integer
        'n = Monitor.Ogg.NumAltern 'Val(Lav(0).Assieme(2))
        'If n < 1 Or n > 5 Then Print "Errore in Salva": Stop
        File = Monitor.Motore.Problem.Commessa '+ Right$(Str$(n), 1) + ".RA3"
        'File = Left(File, Len(File) - 3) + ".RA3"
        'UPGRADE_WARNING: Dir ha un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
        If Len(Dir(File)) > 0 Then Kill(File)
        iF2 = FreeFile()
        FileOpen(iF2, File, OpenMode.Binary)
        'UPGRADE_WARNING: Put è stato aggiornato a FilePut e ha un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
        FilePut(iF2, ProblWLD)
        Ridimensiona()
        For i = 1 To ProblWLD.Npun
            'UPGRADE_WARNING: Put è stato aggiornato a FilePut e ha un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
            FilePut(iF2, Tpun(i))
            'UPGRADE_WARNING: Put è stato aggiornato a FilePut e ha un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
            FilePut(iF2, Ppun(i))
            'UPGRADE_WARNING: Put è stato aggiornato a FilePut e ha un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
            FilePut(iF2, Hpun(i))
            'UPGRADE_WARNING: Put è stato aggiornato a FilePut e ha un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
            FilePut(iF2, Tipo(i))
        Next
        FileClose(iF2)
    End Sub

    Sub SK10(ByRef Res As Short)
        Dim i1, i, i2 As Short
        Dim Riga As String
        Dim j As Short
        With ProblWLD
            For i = 1 To .Ncom Step 5
                i1 = i : i2 = i1 + 4 : If i2 > .Ncom Then i2 = .Ncom
                Riga = ""
                For j = i1 To i2
                    Riga = Riga & Funzioni.Adjust(Funzioni.myStr(CSng(.Sceltaf(j)), 4, 0, True), -4) & Funzioni.Adjust(Funzioni.myStr(.Compos(j), 3, 3, False), -10)
                Next j
                Schede.Sk(iScheda) = Riga
                iScheda = iScheda + 1
            Next i
        End With
    End Sub

    Sub SK2()
        Dim Riga As String
        With ProblWLD
            .iH2 = 0
            If .Sceltaf(1) = 1 Then .iH2 = 1
            Riga = Funzioni.Adjust(Funzioni.myStr(CSng(.Ncom), 7, 0, True), -7) & Funzioni.Adjust(Funzioni.myStr(0.0!, 6, 0, True), -6)
            Riga = Riga & Funzioni.myStr(CSng(.iUnit - 1), 5, 0, True) & Funzioni.myStr(CSng(ProblWLD.iEquil - 1), 5, 0, True)
            Riga = Riga & Funzioni.myStr(CSng(.iIdeal), 5, 0, True)
            Riga = Riga & Funzioni.myStr(0.0!, 5, 0, True) 'numero di costanti binarie
            Riga = Riga & Funzioni.myStr(CSng(.kwrt), 5, 0, True) '0 -ris.finali,1 anche conv.,2 - anche altro
            Riga = Riga & Funzioni.myStr(CSng(.iCost - 1), 5, 0, True)
            Riga = Riga & Funzioni.myStr(CSng(.nIter), 5, 0, True) 'numero iterazioni
            Riga = Riga & Funzioni.myStr(CSng(.iPrecis), 5, 0, True) 'precisione 0-media, 1 alta, 2 bassa
            Riga = Riga & New String(" ", 15) & Funzioni.myStr(CSng(.iH2), 4, 0, True)
            Schede.Sk(iScheda) = Riga
            iScheda = 3
        End With
    End Sub

    Sub SK3()
        Dim Riga As String
        With ProblWLD
            If .Variab(0) = 0 Then .Variab(0) = 100
            Riga = Funzioni.Adjust(VB6.Format(.Variab(0), "#.####E+##"), -10)
            Riga = Riga & Trim(Str(.iPond))
            '.Variab(1) = 0
            Riga = Riga & Funzioni.Adjust(VB6.Format(.Variab(1), "####.##"), 6) 'T
            Riga = Riga & Funzioni.Adjust(VB6.Format(.Variab(2), "#.####E+##"), -10) & Trim(Str(.iAbs)) 'P
            Riga = Riga & Funzioni.Adjust(VB6.Format(.Variab(3), "#.####"), 5) 'V/F
            If .iCode < 8 Or .iCode > 32 Then
                .Variab(6) = 0
                .Variab(8) = 0
            End If
            '.Variab(4) = 1
            Riga = Riga & Funzioni.Adjust(VB6.Format(.Variab(4), "#.####"), 5) 'LH/F
            Riga = Riga & Funzioni.Adjust(VB6.Format(.Variab(5), "#.####"), 5) 'LW/F
            Riga = Riga & Funzioni.Adjust(VB6.Format(.Variab(6) * .Variab(0), "#.####E+##"), -10) 'Entalpia
            If ProblWLD.precEntalp Then Riga = Riga & "1" Else Riga = Riga & "0"
            Riga = Riga & Funzioni.Adjust(VB6.Format(.Variab(7), "#.####E+##"), -10) 'Q
            Riga = Riga & Funzioni.Adjust(VB6.Format(.Variab(8) * .Variab(0), "#.####E+##"), -10) 'Entropia
            If .precEntrop Then Riga = Riga & "1" Else Riga = Riga & "0"
            Schede.Sk(iScheda) = Riga
            iScheda = 4
        End With
    End Sub

    Sub SK4()
        Dim Riga As String
        Dim j, i, k As Short
        Riga = Funzioni.Adjust(Str(ProblWLD.Npun), -5)
        Riga = Riga & Funzioni.Adjust(Str(ProblWLD.Tequi), -5) & Funzioni.Adjust(Funzioni.myStr(ProblWLD.deltaT, 2, 2, False), -5)
        Riga = Riga & Funzioni.Adjust(Str(ProblWLD.Pequi), -5) & Funzioni.Adjust(Funzioni.myStr(ProblWLD.deltaP, 2, 2, False), -5)
        Schede.Sk(iScheda) = Riga
        iScheda = iScheda + 1
        If ProblWLD.Tequi = 1 Then
            For i = 2 To ProblWLD.Npun Step 9
                j = i + 8 : If j > ProblWLD.Npun Then j = ProblWLD.Npun
                Riga = ""
                For k = i To j
                    Riga = Riga & Funzioni.Adjust(Funzioni.myStr(Tpun(k), 3, 3, False), -8)
                Next
                Schede.Sk(iScheda) = Riga
                iScheda = iScheda + 1
            Next
        End If
        If ProblWLD.Pequi = 1 Then
            For i = 2 To ProblWLD.Npun Step 9
                j = i + 8 : If j > ProblWLD.Npun Then j = ProblWLD.Npun
                Riga = ""
                For k = i To j
                    Riga = Riga & Funzioni.Adjust(Funzioni.myStr(Ppun(k), 3, 3, False), -8)
                Next
                Schede.Sk(iScheda) = Riga
                iScheda = iScheda + 1
            Next
        End If
    End Sub

    Sub SortaZ()
        Dim i, j As Short
        i = 0
        With ProblWLD
            Do
                i = i + 1
                If i + 1 > .NZONE Then Exit Do
                For j = i + 1 To .NZONE
                    If .Tzone(i) < .Tzone(j) Then
                        Funzioni.SWAP(.Tzone(i), .Tzone(j))
                        Funzioni.SWAP(.Hzone(i), .Hzone(j))
                        Funzioni.SWAP(.TipZone(i), .TipZone(j))
                    End If
                Next
            Loop
        End With
    End Sub
    Sub CaricaFile(ByRef icome As String, ByRef Ext As String)
        Dim Contr As String = ""
        If Monitor.Motore.Inizio.LavoriSciolti Then
            With mioApert.CommonDialog1Open
                .Filter = "Proprietà fluidi petroliferi (*.WLD)|*.WLD"
                .InitialDirectory = Monitor.Motore.Inizio.Datidir
                .ShowDialog()
                icome = .FileName
            End With
        Else
            job = New RoutBase1.clsjob(Monitor.Motore)
            Monitor.Motore.Sceglijob(Contr) ' = job.Scelto
            If Len(Contr) = 0 Then Exit Sub
            If Not job.Selezione Then icome = "" : Exit Sub
            With job.Comm
                If .indice > 0 Then
                    icome = Monitor.Motore.Inizio.Workdir & "\" & .Arch & "\" + .Ind.Item(.indice).Data.File + ".VIP"
                    Monitor.Motore.Problem.Item = .Ind.Item(.indice).Data.Assieme
                Else
                    icome = ""
                    Monitor.Motore.Problem.Item = ""
                End If
            End With
            '       Aggiorna
        End If
        If Len(icome) = 0 Then Exit Sub
        ' n = InStr(icome, ".")
        ' If n > 0 Then icome = Left(icome, n - 1)
        ' icome = icome + ".WLD"
        Exit Sub
ResCD:
        If icome = "" Then
            icome = NewLav()
            If Len(icome) = 0 Then Exit Sub
            icome = Trim(Monitor.Motore.Inizio.Datidir) & "\" & Trim(icome) & "." & Ext
            Exit Sub
        End If 'dd
        Exit Sub
ErrCD:  Resume ResCD
    End Sub
    Function NewLav() As String
        Dim Stringa(1) As String
        Dim Risult(1) As String
        Dim arch(1) As Short
        Dim dAiu(1) As String
        Dim Ris As Boolean
        Risult(1) = Space(6)
        Stringa(1) = "Nuovo lavoro"
        Ris = Monitor.Motore.InputDati(1, "Inserimento", Stringa, Risult, "", arch, dAiu)
        If Not Ris Then NewLav = "" : Exit Function
        NewLav = Risult(1)
    End Function
    Public Sub Ripet1(ByRef File1 As String)
        'Dim Res As Integer
        'Ripet1:
        '  Nzone = 0
        '  Iniziale
        '  Res = Grafix(File1)
        '  If Res = 3 Then
        '     ' If Monitor.Ogg.TipCalc = 2 Then GoTo Rifa
        '      Manuale File1: GoTo Ripet1
        '  End If
        '  Finale
        '  Entalpie File1
        '  Res = Controlla(File1, 1)
        '  If Res = 1 Then GoTo Ripet1
    End Sub
    Public Sub Lancia()
        Dim Riga As String
        Dim Res, ifl As Short
        Dim File As St40
        Dim Ris As Risultati = New Risultati
        Dim iPun As Short
        Dim FirmaAz As St40
        Dim Archdir As St40
        '*******************************************************
        mioApert.lstDiagn.Items.Clear()
        If ProblWLD.Ncom = 0 Then
            mioApert.lstDiagn.Items.Add("NON SONO STATI SELEZIONATI I COMPONENTI DELLA MISCELA")
            Exit Sub
        End If
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        Riga = Funzioni.Adjust(Monitor.Motore.Problem.ClientPlant, 16) & Funzioni.Adjust(Monitor.Motore.Problem.Commessa, 6) & Funzioni.Adjust(Monitor.Motore.Problem.Author, 12) & DateString
        Riga = Riga & Funzioni.Adjust(Monitor.Motore.Problem.Problema, 16) & Funzioni.myStr(CSng(ProblWLD.iCode), 4, 0, True)
        '**********************************************************
        '--------------------------------------------------
        With ProblWLD
            .ABC = " " '????????
            Select Case .iCode
                Case 0
                    mioApert.lstDiagn.Items.Add("NON E' STATO SCELTO IL TIPO DI CALCOLO")
                    'UPGRADE_WARNING: Screen proprietà Screen.MousePointer presenta un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
                    System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
                    Exit Sub
                Case 3, 6
                    If AcquaPresente Then
                        .ABC = Chr(64 + .Y)
                    Else
                        .ABC = " "
                    End If
                Case 12, 17, 22
                    If AcquaPresente Then
                        .ABC = Chr(64 + .Z - 2)
                    Else
                        .ABC = " "
                    End If
                Case Else
                    If AcquaPresente Then
                        If .iAcqua = 2 Then
                            .ABC = "D"
                        Else
                            .ABC = "W"
                        End If
                    End If
            End Select
            Riga = Riga & "   " & .ABC
            '---i campi 69,70,71,72 hanno il significato seguente---------
            Riga = Riga & Trim(Str(.iSetCost)) & "0"
            Riga = Riga & Trim(Str(.iStLib)) & "0"
            '69 n° set precablato di costanti di interazione (0=nessuno)
            '70 codice di slimentazione (0 da scheda, 1 calcolo prec.,2 vap. prec.,
            '                            3 liq. HC prec.,4 bifase precedente)
            '71 0: esecuzione senza stampa librerie, 1: con stampa librerie
            '                           (completa se .ind=0, del problema se .ind>0)
            '72 0: formato A3, 1 formato A4 (è valido solo lo 0)
            '-------------------------------------------------------------
            Schede.Sk(1) = Riga
            iScheda = 2
            '----------------------------------sk1
            Call SK2()
            If AcquaPresente And (.Ncom = 1 Or .Ncom = 2 And .iH2 = 1) Then
                'UPGRADE_WARNING: Screen proprietà Screen.MousePointer presenta un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
                If MostraAiuto(IDH_LIMITAZIONI, RoutBase1.ChiaviMess.MessInformation + RoutBase1.ChiaviMess.MessOKCancel + RoutBase1.ChiaviMess.MessHelpButton) = RoutBase1.ChiaviMess.MessCancel Then
                    Exit Sub
                End If
                'UPGRADE_WARNING: Screen proprietà Screen.MousePointer presenta un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
            End If
            '------------------------------------sk2
            Call SK3()
            '-----------------------------------sk4
            If .iCode = 35 Or .iCode = 36 Then Call SK4()
            '----------------------------------sk4,5,6
            If .iCode > 17 And .iCode < 25 Then
                '----------------------------------sk7,8
                Stop
            End If
        End With
        Call SK10(Res)
        'If Res = 1 Then GoTo Fine
        '----------------------------------------------sk10
        Schede.Sk(iScheda) = "FINE"
        File.St = Monitor.Motore.Inizio.DiscoRam & "WALD1.TXT"
        ifl = FreeFile()
        FileOpen(ifl, Monitor.Motore.Inizio.DiscoRam & "SELVAINP.DAT", OpenMode.Output)
        iScheda = 1
        Do
            PrintLine(ifl, Schede.Sk(iScheda))
            If Left(Schede.Sk(iScheda), 4) = "FINE" Then Exit Do
            iScheda = iScheda + 1
        Loop
        FileClose(ifl)
        FirmaAz.St = Monitor.Motore.Inizio.firma
        Archdir.St = Monitor.Motore.Inizio.Archdir
        SELVA(Schede, File, FirmaAz, ProblWLD.iDebug, Archdir)
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        If Diagnosi(File.St) Then
            Exit Sub
        End If
        Select Case ProblWLD.iCode
            Case 35, 36
                FormDB = New frmDB
                CreaDB(True)
                iPun = 1
                Do
                    RECUPERA(Ris, iPun)
                    If Ris.indice = 0 Then Exit Do
                    Inietta(Ris, t)
                    iPun = iPun + 1
                Loop
                Adapter.Connection.Close()
                If iPun >= ProblWLD.Npun Then FormDB.ShowDialog()
                FormDB.Dispose()
                If DaIsa > 0 Then CreaRA1(FileDataBase)
            Case Else
                RECUPERA(Ris, 1)
                If Ris.kConv = 1 And Not (ProblWLD.iCode = 33 Or ProblWLD.iCode = 34) Then
                    AggRis(Ris)
                    mioApert.Frame2(0).Visible = ProblWLD.iCode = 33
                    mioApert.Frame2(1).Visible = ProblWLD.iCode = 34
                Else
                    mioApert.Frame2(0).Visible = False
                    mioApert.Frame2(1).Visible = False
                End If
        End Select
    End Sub

    Public Sub Leggi()
        Dim ifl, i As Short
        ifl = FreeFile()
        If Len(Trim(Monitor.Motore.Problem.Commessa)) = 0 Then Exit Sub
        'UPGRADE_WARNING: Dir ha un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
        If Len(Dir(Monitor.Motore.Problem.Commessa)) = 0 Then Exit Sub
        FileOpen(ifl, Monitor.Motore.Problem.Commessa, OpenMode.Binary)
        If LOF(ifl) = 0 Then FileClose(ifl) : Exit Sub
        'UPGRADE_WARNING: Get è stato aggiornato a FileGet e ha un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
        FileGet(ifl, ProblWLD)
        Ridimensiona()
        For i = 1 To ProblWLD.Npun
            'UPGRADE_WARNING: Get è stato aggiornato a FileGet e ha un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
            FileGet(ifl, Tpun(i))
            'UPGRADE_WARNING: Get è stato aggiornato a FileGet e ha un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
            FileGet(ifl, Ppun(i))
            'UPGRADE_WARNING: Get è stato aggiornato a FileGet e ha un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
            FileGet(ifl, Hpun(i))
            'UPGRADE_WARNING: Get è stato aggiornato a FileGet e ha un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
            FileGet(ifl, Tipo(i))
        Next
        If DaIsa = 0 Then
            With ProblWLD
                Monitor.Motore.Problem.ClientPlant = .ClientPlant
                Monitor.Motore.Problem.Item = .Item
                Monitor.Motore.Problem.Problema = .Problema
                Monitor.Motore.Problem.Author = .Author
                Dim FormProblem As frmProblem = New frmProblem
                FormProblem.ShowDialog()
            End With
        End If
        FileClose(ifl)
        If Monitor.Ogg.TipCalc = 3 Then
            With mioApert
                .cmbTrasf.SelectedIndex = ProblWLD.X - 1
                .AggTesti()
                .AggOption()
                .AggUnit()
                .AggCostanti()
            End With
            AggAcqua()
        End If
    End Sub

    Public Sub Scrivi()
        Dim ifl, i As Short
        ifl = FreeFile()
        FileOpen(ifl, Monitor.Motore.Problem.Commessa, OpenMode.Binary)
        With Monitor.Motore.Problem
            ProblWLD.ClientPlant = .ClientPlant
            ProblWLD.Item = .Item
            ProblWLD.Problema = .Problema
            ProblWLD.Author = .Author
        End With
        'UPGRADE_WARNING: Put è stato aggiornato a FilePut e ha un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
        FilePut(ifl, ProblWLD)
        Ridimensiona()
        For i = 1 To ProblWLD.Npun
            'UPGRADE_WARNING: Put è stato aggiornato a FilePut e ha un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
            FilePut(ifl, Tpun(i))
            'UPGRADE_WARNING: Put è stato aggiornato a FilePut e ha un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
            FilePut(ifl, Ppun(i))
            'UPGRADE_WARNING: Put è stato aggiornato a FilePut e ha un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
            FilePut(ifl, Hpun(i))
            'UPGRADE_WARNING: Put è stato aggiornato a FilePut e ha un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
            FilePut(ifl, Tipo(i))
        Next
        FileClose(ifl)
    End Sub
    Public Function Diagnosi(ByRef File As String) As Boolean
        Dim ifl As Short
        Dim Riga As String
        Diagnosi = TrapErrFortran(0)
        ifl = FreeFile()
        FileOpen(ifl, File, OpenMode.Input)
        If LOF(ifl) = 0 Then
            FileClose(ifl)
            Diagnosi = True
            MostraAiuto(IDH_TEXTNULL)
            Exit Function
        End If
        Riga = LineInput(ifl)
        With mioApert.lstDiagn
            .Items.Clear()
            Do Until EOF(ifl)
                If Left(Riga, 1) = "*" Then
                    Do
                        Riga = LineInput(ifl)
                        If Len(Riga) > 0 Then
                            If EOF(ifl) Or (Left(Riga, 1) = "1" And Len(Riga) > 1) Then Exit Do
                            If Len(Riga) > 1 Then .Items.Add(Riga)
                        End If
                    Loop
                    Exit Do
                End If
                Riga = LineInput(ifl)
            Loop
            FileClose(ifl)
        End With
    End Function
    Public Function TrapErrFortran(ByRef m As Short) As Boolean
        Dim S As Single
        Dim Testo As String
        On Error GoTo ErrFor
        S = 1 + 1.0#
        TrapErrFortran = False
        Exit Function
ExFor:
        ' Testo = "Attenzione!" + vbCrLf
        ' Testo = Testo + "Uno o più dati di input sono errati."
        ' MsgBox Testo, vbCritical + vbOKOnly
        If m = 0 Then MostraAiuto(IDH_ERRFORTRAN)
        Err.Clear()
        TrapErrFortran = True
        Exit Function
ErrFor:
        Resume ExFor
    End Function
    Public Function MostraAiuto(ByRef iD As Integer, Optional ByRef Informa As RoutBase1.ChiaviMess = RoutBase1.ChiaviMess.MessCritical + RoutBase1.ChiaviMess.MessOkOnly, Optional ByRef mioTesto As String = "") As RoutBase1.ChiaviMess
        Dim Testo, Tit As String
        If iD > 0 Then
            If Len(mioTesto) = 0 Then
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.Inizio.ConvertiCr(). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Testo = Monitor.Motore.Inizio.ConvertiCr(My.Resources.ResourceManager.GetString("str" + CStr(iD))) ' "Il gruppo di items da montare su ventilatore a comune non è stato definito correttamente"
            Else
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.Inizio.ConvertiCr(). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Testo = Monitor.Motore.Inizio.ConvertiCr(mioTesto)
            End If
            Tit = "Wald - Messaggi di errore"
            If Not Informa And RoutBase1.ChiaviMess.MessCritical Then Tit = "Wald"
            MostraAiuto = Monitor.Motore.Messaggio(Testo, Informa Or RoutBase1.ChiaviMess.MessHelpButton, Tit, RadiceHelp, iD)
        Else
            MsgBox("Errore sconosciuto", MsgBoxStyle.Information, "Wald")
        End If
    End Function

    Public Sub CreaDB(ByRef Delete As Boolean)
        Dim i As Integer
        If Len(FileDataBase) = 0 Then FileDataBase = Left(Monitor.Motore.Problem.Commessa, Len(Monitor.Motore.Problem.Commessa) - 3) & "MDB"
        If Not IO.File.Exists(FileDataBase) Then
            FileCopy(Monitor.Motore.Inizio.Archdir & "\CondCurva.mdb", FileDataBase)
        End If
        Adapter = New CondCurvaDataSetTableAdapters.CondCurvaTableAdapter
        Adapter.Connection = New OleDb.OleDbConnection(Conn & FileDataBase & ";Persist Security Info=True")
        t = Adapter.GetData
        If Delete Then
            FormDB.dsCondCurva.Clear()
            For i = 0 To t.Rows.Count - 1
                t.Rows(0).Delete()
            Next
        End If
    End Sub

    Public Sub Ridimensiona()
        ReDim Preserve Tpun(ProblWLD.Npun)
        ReDim Preserve Ppun(ProblWLD.Npun)
        ReDim Preserve Hpun(ProblWLD.Npun)
        ReDim Preserve Tipo(ProblWLD.Npun)
    End Sub

    Public Sub AggAcqua()
        Dim i As Boolean
        With ProblWLD
            If .Sceltaf(.Ncom) = 72 Then
                i = .Compos(.Ncom) > 0.1
            Else
                i = False
            End If
            If i Then
                mioApert.frmoptions(4).Visible = True
                AcquaPresente = True
            Else
                mioApert.frmoptions(4).Visible = False
                AcquaPresente = False
                '.iAcqua = 2
            End If
        End With

    End Sub

    Public Sub Inietta(ByRef Ris As Risultati, ByRef t As CondCurvaDataSet.CondCurvaDataTable)
        Dim rv As DataRowView = t.DefaultView.AddNew()
        TrapErrFortran(1)
        rv.BeginEdit()
        rv("t") = Ris.Temperatura
        rv("p") = Ris.Pressione
        rv("X") = Ris.VapMasFraction
        rv("Y") = Ris.VapMolFraction
        rv("Htot") = Ris.Entalpie(1) / 100
        rv("Hliq") = Ris.Entalpie(5)
        rv("Hvap") = Ris.Entalpie(3)
        rv("Mtot") = Ris.PesiMol(1)
        rv("Mliq") = Ris.PesiMol(3)
        rv("Mvap") = Ris.PesiMol(2)
        rv("Densl") = Ris.Density(2)
        rv("Densv") = Ris.Density(1)
        rv("Cspecl") = 0
        rv("Cspecv") = Ris.CpGas
        rv("Visl") = Ris.Visco(2)
        rv("Visv") = Ris.Visco(1)
        rv("kLiq") = Ris.Conduc(2)
        rv("kvap") = Ris.Conduc(1)
        rv("Cfacl") = Ris.CompressF(2)
        rv("Cfacv") = Ris.CompressF(1)
        rv("HAcqLiq") = Ris.HAcqLiq
        rv("MasAcqLiq") = Ris.MasAcqLiq
        rv("MolAcqLiq") = Ris.MolAcqLiq
        Select Case Ris.indice
            Case 5 : rv("Tipo") = "D"
            Case 4 : rv("Tipo") = "B"
            Case 6, 7 : rv("Tipo") = "F"
            Case 33 : rv("Tipo") = "L"
            Case 34 : rv("Tipo") = "G"
            Case Else : rv("Tipo") = "?"
        End Select
        Select Case rv("X")
            Case 1
                If rv("Densl") > 0 And rv("Densv") > 0 Then
                    rv("Tipo") = "D"
                Else
                    rv("Tipo") = "G"
                End If
            Case 0
                If rv("Densl") > 0 And rv("Densv") > 0 Then
                    rv("Tipo") = "B"
                Else
                    rv("Tipo") = "L"
                End If
            Case Else
                rv("Tipo") = "F"
        End Select
        rv.EndEdit()
    End Sub
    Public Sub IniettaC(ByRef Curva As CondCurva, ByRef t As CondCurvaDataSet.CondCurvaDataTable)
        Dim rv As DataRowView = t.DefaultView.AddNew()
        rv.BeginEdit()
        rv("Tipo") = Curva.Tipo
        rv("t") = Curva.Temp + 0
        rv("p") = Curva.Pres + 0
        rv("X") = Curva.Xgas + 0
        rv("Htot") = Curva.Entl + 0
        rv("Hliq") = Curva.Hliq + 0
        rv("Hvap") = Curva.Hgas + 0
        rv("Mtot") = Curva.MolT + 0
        rv("Mliq") = Curva.MolL + 0
        rv("Mvap") = Curva.MolG + 0
        rv("Densl") = Curva.Sgra + 0
        rv("Densv") = Curva.DenV + 0
        rv("Cspecl") = Curva.Cliq + 0
        rv("Cspecv") = Curva.Cgas + 0
        rv("Visl") = Curva.Visl + 0
        rv("Visv") = Curva.Visg + 0
        rv("kLiq") = Curva.Conl + 0
        rv("kvap") = Curva.Cong + 0
        rv("Cfacl") = 0 'Ris.CompressF(2)
        rv("Cfacv") = Curva.Cfac + 0
        rv("Tipo") = CDbl(Curva.Tipo) + 0
        rv("MasAcqLiq") = Curva.XAcq + 0
        rv("HAcqLiq") = Curva.HAcq + 0
        rv.EndEdit()
    End Sub
    Public Sub CreaRA1(ByRef f As String)
        Dim FRA1 As String
        Dim Curva As New CondCurva
        Dim ifl, i As Short
        Connection = New OleDb.OleDbConnection(Conn & f & ";Persist Security Info=True")
        Dim SQL As String = "SELECT * FROM CondCurva ORDER BY T DESC"
        cmd = New OleDb.OleDbDataAdapter(SQL, Connection)
        cmd.Fill(FormDB.dsCondCurva)
        t = FormDB.dsCondCurva.CondCurva 'db.OpenRecordset("SELECT * FROM CondCurva ORDER BY T DESC")
        FRA1 = Left(f, Len(f) - 3) & "RA1"
        ifl = FreeFile()
        FileOpen(ifl, FRA1, OpenMode.Random, OpenAccess.ReadWrite, , Len(Curva))
        For i = 1 To t.Rows.Count
            Curva.Cfac = t(i - 1)("Cfacv")
            Curva.Cgas = t(i - 1)("Cspecv")
            Curva.Cliq = t(i - 1)("Cspecl")
            Curva.Cong = t(i - 1)("kvap")
            Curva.Conl = t(i - 1)("kLiq")
            Curva.DenV = t(i - 1)("Densv")
            Curva.Entl = t(i - 1)("Htot")
            Curva.Hgas = t(i - 1)("Hvap")
            Curva.Hliq = t(i - 1)("Hliq")
            Curva.MolG = t(i - 1)("Mvap")
            Curva.MolL = t(i - 1)("Mliq")
            Curva.MolT = t(i - 1)("Mtot")
            Curva.Pres = t(i - 1)("p")
            Curva.Sgra = t(i - 1)("Densl")
            Curva.Temp = t(i - 1)("t")
            If IsDBNull(t(i - 1)("Tipo")) Then
                t.DefaultView(i - 1).BeginEdit()
                t.DefaultView(i - 1)("Tipo") = "?"
                t.DefaultView(i - 1).EndEdit()
            End If
            Curva.Tipo = t(i - 1)("Tipo")
            Curva.Visg = t(i - 1)("Visv")
            Curva.Visl = t(i - 1)("Visl")
            Curva.Xgas = t(i - 1)("X")
            Curva.XAcq = t(i - 1)("MasAcqLiq")
            Curva.HAcq = t(i - 1)("HAcqLiq")
            FilePut(ifl, Curva, i)
        Next
        FileGet(ifl, Curva, 1)
        Curva.Npun = i - 1
        FilePut(ifl, Curva, 1)
        FileClose(ifl)
        ProblWLD.Npun = i - 1
        cmd.Update(t)
        Connection.Close()
    End Sub

    Public Function ApriFile(ByRef FF As String, ByRef ifl As Short) As Boolean
        Dim FRA1 As String
        If Left(FF, 1) = "\" Then
            FRA1 = Monitor.Motore.Inizio.Archdir & FF
        Else
            FRA1 = Monitor.Motore.Inizio.Archdir & "\" & FF
        End If
        On Error GoTo ErrAF
        FileOpen(ifl, FRA1, OpenMode.Input, , OpenShare.Shared)
        ApriFile = True
        Exit Function
ErrAF:
        MsgBox("Impossibile aprire il file " & FRA1 & vbCrLf & "Esecuzione terminata", MsgBoxStyle.Critical, "Wald")

    End Function
    Function Control1() As Object
        Static j, i, iF2 As Short
        'UPGRADE_WARNING: È possibile che si debba inizializzare le matrici nella struttura Curva prima di poterle utilizzare. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
        Static Curva As CondParen
        Static indice(5) As Short
        indice(1) = 15 : indice(2) = 18 : indice(3) = 12 : indice(4) = 7 : indice(5) = 13
        'Xscr = 639
        'Yscr = 479
        'SCREEN 12: WIDTH , 60
        'Palette 1, 65536 * 63 + 256 * 63 + 63
        'Palette 2, 256 * 63 + 63
        'Palette 3, 65536 * 63 + 63
        'COLOR 3
        i = 0
        For j = 1 To 5
            '   LOCATE 3 + i, 7 + (j - 1) * 7
            '   Print FF$(29 + j)    '-------titoli
        Next
        For i = 1 To ProblWLD.Npun
            'UPGRADE_WARNING: Get è stato aggiornato a FileGet e ha un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
            FileGet(iF2, Curva, i)
            '   LOCATE 5 + i, 1: Print USING; Formati(18); i; Curva.Tipo
            For j = 1 To 5
                '   LOCATE 5 + i, 7 + (j - 1) * 7
                '    Print USING; Formati(7); Curva.Vall(indice(j))
            Next
        Next
        i = 1 : j = 1
        'iPos = 1: T$ = "xxxxxxx"
        'UPGRADE_WARNING: Get è stato aggiornato a FileGet e ha un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
        FileGet(iF2, Curva, i)
        'COLOR 2
        Call Scriv1()
        'Do
        ' Do
        '    k$ = INKEY$
        '    If Not (k$ = "") Then Exit Do
        ' Loop
        '   If Left$(k$, 1) = Chr$(0) Then
        '      COLOR 3: GoSub Scriv1
        '      If Mid$(k$, 2, 1) = Chr$(77) Then 'freccia destra
        '         GoSub Aggio1
        '         j = j + 1: If j > 5 Then j = 5
        '         iPos = 1
        '      ElseIf Mid$(k$, 2, 1) = Chr$(75) Then 'freccia sinistra
        '         GoSub Aggio1
        '         j = j - 1: If j < 1 Then j = 1
        '         iPos = 1
        '      ElseIf Mid$(k$, 2, 1) = Chr$(72) Then 'up
        '         GoSub Aggio1
        '         Put #iF2, i, Curva
        '        i = i - 1: If i = 0 Then i = 1
        '         Get #iF2, i, Curva
        '         iPos = 1
        '      ElseIf Mid$(k$, 2, 1) = Chr$(80) Then 'down
        '         GoSub Aggio1
        '         Put #iF2, i, Curva
        '         i = i + 1: If i > ProblWLD.Npun Then i = ProblWLD.Npun
        '         Get #iF2, i, Curva
        '         iPos = 1
        '      End If
        '         COLOR 2: GoSub Scriv1
        '   ElseIf k$ = Chr$(13) Or k$ = Chr$(27) Then
        '         GoSub Aggio1
        '         If k$ = Chr$(27) Then Exit Do
        '   ElseIf Asc(k$) < 32 Then
        '      Beep
        '   Else
        '      Mid$(T$, iPos, 1) = k$
        '      LOCATE 5 + i, 7 + (j - 1) * 7 + iPos - 1, 1
        '      Print k$;
        '      iPos = iPos + 1
        '      If iPos > 7 Then iPos = 1
        '   End If
        'Loop
        'UPGRADE_WARNING: Put è stato aggiornato a FilePut e ha un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
        FilePut(iF2, Curva, i)
        'LOCATE 55, 10: Print " <R> rifai <any> procedi";
        'u$ = INPUT$(1)
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Control1. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        Control1 = 0
        'If UCase$(u$) = "R" Then Control1 = 1
        FileClose(iF2)
    End Function
    Sub Aggio1()
        '         If Left$(T$, 1) <> "ProblWLD.x" Then Curva.Vall(indice(j)) = Val(T$)
        '         COLOR 3: GoSub Scriv1
        '         T$ = "xxxxxxx": If j = 0 Then T$ = "ProblWLD.x"
        'UPGRADE_WARNING: Return ha un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'

    End Sub
    Sub Scriv1()
        '         LOCATE 5 + i, 7 + (j - 1) * 7, 1
        '         Print USING; Formati(7); Curva.Vall(indice(j))
    End Sub
    Sub Manuale(ByRef File As String)
        Dim n, j, iF3 As Short
        Dim Curva As New CondCurva
        Dim File1 As String
        Dim t As CondCurvaDataSet.CondCurvaDataTable = New CondCurvaDataSet.CondCurvaDataTable
        Curva.Tipo = "?"
        'For j = 1 To 18: Curva.Vall(j) = 0!: Next
        If DaIsa = 0 Then
            'n = Val(Lav(0).Assieme(2))
            If n < 1 Or n > 5 Then MsgBox("Errore in Manuale")
            File = Monitor.Motore.Inizio.Workdir & "\" & Monitor.Motore.Problem.Commessa & Right(Str(n), 1) & ".RA1"
        End If
        File1 = File & ".RA1"
        FileDataBase = File & ".MDB"
        FormDB = New frmDB
        CreaDB(True)
        iF3 = FreeFile()
        FileOpen(iF3, File1, OpenMode.Random, OpenAccess.ReadWrite, , Len(Curva))
        If LOF(iF3) = 0 Then
            ProblWLD.Npun = 1
            IniettaC(Curva, t)
        Else
            j = 0
            Do
                j = j + 1
                'UPGRADE_WARNING: Get è stato aggiornato a FileGet e ha un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
                FileGet(iF3, Curva, j)
                If EOF(iF3) Then Exit Do
                IniettaC(Curva, t)
            Loop
            ProblWLD.Npun = j - 1
        End If
        FileClose(iF3)
        Adapter.Connection.Close()
        FormDB.ShowDialog()
        If Not FormDB.OK Then
            iQuale = 1
            FormDB.Dispose()
            Exit Sub
        End If
        FormDB.Dispose()
        CreaRA1(FileDataBase)
        'Do
        'Res = Controlla(File, 2)
        'Res = Control1
        'Loop While Res > 0
    End Sub
    Public Sub AggRis(ByRef Ris As Risultati)
        Dim i As Short
        With mioApert
            .AzzeraRisultati(False)
            With ProblWLD
                .Variab(1) = Ris.Temperatura
                .Variab(2) = Ris.Pressione
                .Variab(3) = Ris.VapMolFraction
                .Variab(4) = 1 - Ris.VapMolFraction - Ris.MolAcqLiq
                .Variab(5) = Ris.MolAcqLiq
                .Variab(6) = Ris.Entalpie(1) / .Variab(0)
                .Variab(8) = Ris.Entropie(1) / .Variab(0)
            End With
            .AggTesti()
            Select Case ProblWLD.iCode
                Case 1, 2, 3
                    .Risultati(2)
                    .Risultati(6)
                    .Risultati(8)
                Case 4, 5, 6
                    .Risultati(1)
                    .Risultati(6)
                    .Risultati(8)
                Case 8, 9, 13, 14, 18, 19
                    .Risultati(1)
                    .Risultati(2)
                Case 7
                    .Risultati(3)
                    .Risultati(4)
                    If AcquaPresente Then .Risultati(5)
                Case 10, 15, 20
                    .Risultati(2)
                    .Risultati(3)
                    .Risultati(4)
                    If AcquaPresente Then .Risultati(5)
                Case 11, 16, 21
                    .Risultati(1)
                    .Risultati(3)
                    .Risultati(4)
                    If AcquaPresente Then .Risultati(5)
                Case 12, 17, 22
                    .Risultati(1)
                    .Risultati(2)
                    Select Case ProblWLD.ABC
                        Case "A"
                            .Risultati(4)
                            If AcquaPresente Then .Risultati(5)
                        Case "B"
                            .Risultati(3)
                            If AcquaPresente Then .Risultati(5)
                        Case "C"
                            .Risultati(4)
                            .Risultati(3)
                    End Select
                Case Else
            End Select
            On Error Resume Next
            .Label2(17).Text = Funzioni.myStr(Ris.Entalpie(5), 4, 2, False) 'Hliq
            .Label2(18).Text = Funzioni.myStr(Ris.Entalpie(3), 4, 2, False) 'Hvap
            .Label2(16).Text = "?" 'Cpliq
            .Label2(19).Text = Funzioni.myStr(Ris.CpGas, 4, 2, False) '"?" 'Cpvap
            .Label2(15).Text = "?" 'vliq
            .Label2(20).Text = Str(0) ' mystr(1 / Ris.Density(2), 4, 2, False) '"?" 'vvap
            .Label2(14).Text = "?" 'dliq
            .Label2(21).Text = Funzioni.myStr(Ris.Density(2), 4, 2, False) ' "?" 'dvap
            .Label2(13).Text = Funzioni.myStr(Ris.Visco(2), 4, 2, False) '"?" 'visliq
            .Label2(22).Text = Funzioni.myStr(Ris.Visco(1), 4, 2, False) '"?" 'visvap
            .Label2(12).Text = Funzioni.myStr(Ris.Conduc(2), 4, 2, False) '"?" 'kliq
            .Label2(23).Text = Funzioni.myStr(Ris.Conduc(1), 4, 2, False) '"?" 'kvap
        End With
    End Sub
    Public Sub StampaLibrerie()
        Dim Riga As String
        Dim Res, ifl As Short
        Dim File As St40
        Dim i As Short
        Dim FirmaAz As St40
        Dim Archdir As St40
        'UPGRADE_WARNING: È possibile che si debba inizializzare le matrici nella struttura savProbl prima di poterle utilizzare. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
        Dim savProbl As prbWald
        Dim savComm As String
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto savProbl. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        savProbl = ProblWLD
        savComm = Monitor.Motore.Problem.Commessa
        Monitor.Motore.Problem.Commessa = "STANDA"
        Riga = Funzioni.Adjust(Monitor.Motore.Problem.ClientPlant, 16) & Funzioni.Adjust(Monitor.Motore.Problem.Commessa, 6) & Funzioni.Adjust(Monitor.Motore.Problem.Author, 12) & DateString
        Riga = Riga & Funzioni.Adjust(Monitor.Motore.Problem.Problema, 16) & Funzioni.myStr(CSng(0), 4, 0, True)
        '**********************************************************
        Riga = Riga & "   " & " " & " 010"
        Schede.Sk(1) = Riga
        iScheda = 2
        '----------------------------------sk1
        With ProblWLD
            .Ncom = 100
            For i = 1 To .Ncom
                .Sceltaf(i) = i
            Next
        End With
        Call SK2()
        '------------------------------------sk2
        Call SK3()
        '-----------------------------------sk4
        Call SK10(Res)
        'If Res = 1 Then GoTo Fine
        '----------------------------------------------sk10
        Schede.Sk(iScheda) = "FINE"
        File.St = Monitor.Motore.Inizio.DiscoRam & "WALD1.TXT"
        ifl = FreeFile()
        FileOpen(ifl, Monitor.Motore.Inizio.DiscoRam & "SELVAINP.DAT", OpenMode.Output)
        iScheda = 1
        Do
            PrintLine(ifl, Schede.Sk(iScheda))
            If Left(Schede.Sk(iScheda), 4) = "FINE" Then Exit Do
            iScheda = iScheda + 1
        Loop
        FileClose(ifl)
        FirmaAz.St = Monitor.Motore.Inizio.firma
        Archdir.St = Monitor.Motore.Inizio.Archdir
        SELVA(Schede, File, FirmaAz, 0, Archdir)
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto ProblWLD. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        ProblWLD = savProbl
        Rapporto(1)
        Monitor.Motore.Problem.Commessa = savComm
    End Sub

    Public Sub Rapporto(ByRef Libreria As Short)
        Dim FileStam, Testo As String
        Dim FileTxt As String ', p As Word.Paragraph
        '    Dim r As Word.Range, Primo As Boolean
        FileTxt = Monitor.Motore.Inizio.DiscoRam & "WALD1.TXT"
        'UPGRADE_WARNING: Dir ha un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
        If Len(Dir(FileTxt)) = 0 Then
            MostraAiuto(IDH_NONTXT)
            mioApert.cmdRapp.Enabled = False
            Exit Sub
        End If
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        If Monitor.Motore.Inizio.VersOffice < 11 Then
            If Not Stub9 Is Nothing Then Stub9.sClose()
            Stub9 = New StubW9.clsSW9
            Stub9.SuperStampa(Monitor.Motore.Inizio.Archdir & "\WALD.DOC", Monitor.Motore.Inizio.VersOffice)
            With Stub9
                .SuperStampa(Monitor.Motore.Inizio.Archdir & "\WALD.DOC", Monitor.Motore.Inizio.VersOffice)
                mioApert.Enabled = True
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
                If Stub Is Nothing Then Exit Sub
                FileStam = Left(Monitor.Motore.Problem.Commessa, Len(Monitor.Motore.Problem.Commessa) - 1) & "S"
                Do
                    Try
                        .sSaveAs(FileStam)
                    Catch e As Exception
                        Testo = "Impossibile salvare il documento Word " & FileStam & "." & vbCrLf
                        Testo = Testo & "E' possibile che esso sia già aperto in WinWord." & vbCrLf
                        Testo = Testo & "In tal caso attivare WinWord, chiudere il documento e poi riprovare."
                        If MessageBox.Show(Testo, "Wald", MessageBoxButtons.RetryCancel, MessageBoxIcon.Information) = DialogResult.Cancel Then Exit Do
                    End Try
                Loop
                .WaldInsert(FileTxt, Libreria)
                .sClose()
            End With
        Else
            If Not Stub Is Nothing Then Stub.sClose()
            Stub = New StubW2000.clsSW2000
            With Stub
                .SuperStampa(Monitor.Motore.Inizio.Archdir & "\WALD.DOC", Monitor.Motore.Inizio.VersOffice)
                mioApert.Enabled = True
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
                If Stub Is Nothing Then Exit Sub
                FileStam = Left(Monitor.Motore.Problem.Commessa, Len(Monitor.Motore.Problem.Commessa) - 1) & "S"
                Do
                    Try
                        .sSaveAs(FileStam)
                    Catch e As Exception
                        Testo = "Impossibile salvare il documento Word " & FileStam & "." & vbCrLf
                        Testo = Testo & "E' possibile che esso sia già aperto in WinWord." & vbCrLf
                        Testo = Testo & "In tal caso attivare WinWord, chiudere il documento e poi riprovare."
                        If MessageBox.Show(Testo, "Wald", MessageBoxButtons.RetryCancel, MessageBoxIcon.Information) = DialogResult.Cancel Then Exit Do
                    End Try
                Loop
                .WaldInsert(FileTxt, Libreria)
                .sClose()
            End With
        End If
    End Sub
End Module