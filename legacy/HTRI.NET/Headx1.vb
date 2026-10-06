Option Strict Off
Option Explicit On
Imports System.Math
Module modHeadx
    Public NomeDAT As String
    Private DirDir, Form As String
    Private NFASCI As Short
    Private che() As String
    Private ch1ch1() As String
    Private bbbb() As Single
    Private cccc() As Single
    Private nline As Short
    Private InLinea As Boolean ', inspoint(2) As Double
    Private eMan(,) As Single
    Private aMan(,) As Single
    Private PMan() As Single
    Private Nfile As Short
    Private iiset() As Short
    Private yyset(,) As Single
    Private n2, n1, N3 As Short
    Private N6, N4, N5, N7 As Short
    Private N8, N9 As Short
    '      COMMON SHARED /GEO1/ N5 AS INTEGER, KB() AS INTEGER, ED(), AD(), CH9() AS STRING * 39
    '      COMMON SHARED /GEO1/ N4 AS INTEGER, ka() AS INTEGER, EC(), AC(), Nrinf() AS INTEGER
    '      COMMON SHARED /GEO1/ N3 AS INTEGER, EB(), AB()
    Private CH3 As New String(" ", 80)
    '      COMMON SHARED /GEO1/ N1 AS INTEGER, ch1() AS STRING * 21, CH2() AS STRING * 21, CH3 AS STRING * 80
    '      COMMON SHARED /GEO1/ N2 AS INTEGER, CH4() AS STRING * 50, CH5() AS STRING * 50, CH6() AS STRING, CH7()  AS STRING * 50, CH8() AS STRING * 50
    '      COMMON SHARED /GEO1/ N6 AS INTEGER, N7 AS INTEGER, N10() AS INTEGER, EF(), AF(), ch13() AS STRING * 12
    '      COMMON SHARED /GEO1/ CH16() AS STRING * 8, X0(), Y0()
    '      COMMON SHARED /GEO1/ N8 AS INTEGER, N9 AS INTEGER
    '      COMMON SHARED /GEO1/ LED() AS INTEGER
    '      COMMON SHARED /GEO1/ CH14() AS STRING * 40
    '      COMMON SHARED /GEO1/ CH15() AS STRING * 40, JPOS()', CH AS STRING * 6
    '      COMMON SHARED /GEO1/ inn$(), form$, nline AS INTEGER, riga$, IFL1 AS INTEGER, IFL2 AS INTEGER
    Private CH2N As New String(" ", 7)
    Private CH3N As New String(" ", 5)
    Private ANoz() As Single
    Private eNoz() As Single
    Private EE(,) As Single
    Private CCov() As Single
    Private AE(,) As Single
    Private Passi(,) As Short
    Private Nsetti() As Short
    Private EFCov() As Single
    Private AFCov() As Single
    Private Const MFILE As Short = 16
    Private Const MBOCCH As Short = 20
    Private Const MSETTI As Short = 60
    Private Const MTARGA As Short = 2
    Private Const MPOS As Short = 55
    Private Const MNOTE As Short = 12
    Private inn() As String
    Private ch11(,) As String
    Private e(704) As Single
    Private A(704) As Single
    Private peso(10) As Single
    Private C(30) As Single
    Private PA(4, 30) As Single ', FORO(200, 3)  ', Scalb
    Private ch10(33) As String
    Private Scalb As Single
    Private EA(,) As Single
    Private AA(,) As Single
    Private Ntubi(,) As Short
    Private Senso() As String
    Private KB(,) As Short
    Private ED(,) As Single
    Private AD(,) As Single
    Private CH9() As String
    Private ka(,) As Short
    Private EC(,) As Single
    Private AC(,) As Single
    Private Nrinf(4) As Short
    Private EB(,) As Single
    Private AB(,) As Single ', CH3 AS STRING
    Private ch1(2, 7) As String
    Private CH2(,) As String
    Private CH4(4) As String
    Private CH5(,) As String
    Private CH6(9, 2) As String
    Private CH7(9, 4) As String
    Private CH8(12, 3) As String
    Private N10(3, 10) As Short
    Private EF(3, 10) As Single
    Private AF(3, 10) As Single
    Private ch13(10) As String
    Private CH16(40) As String
    Private x0(40) As Single
    Private y0(40) As Single
    Private LED(50) As Short
    Private CH14(50, 3) As String
    Private CH15(50, 7) As String
    Private JPOS(50) As Short
    Private CH4N(12) As String
    Private P(15) As Single
    Private xtab(12) As Single
    Private Titol(12) As String
    Private eMon(110) As Single
    Private PAMon(14) As Single
    Private PBMon(14) As Single
    Private ifl1 As Short
    Private iTipo As Short
    Private Sub InizHeadx()
        ReDim EA(MFILE, 7)
        ReDim AA(MFILE, 7)
        ReDim Ntubi(MFILE, 7)
        ReDim Senso(MFILE)
        ReDim KB(MBOCCH, 3)
        ReDim ED(MBOCCH, 3)
        ReDim AD(MBOCCH, 3)
        ReDim CH9(MBOCCH)
        ReDim ka(MSETTI, 5)
        ReDim EC(MSETTI, 5)
        ReDim AC(MSETTI, 5)
        ReDim EB(MTARGA + 1, 9)
        ReDim AB(MTARGA + 1, 9) ', CH3 AS STRING
        ReDim CH2(MPOS, 7)
        ReDim CH5(MNOTE * 2, 3)
        xtab(1) = 62.0#
        xtab(2) = 70.0#
        xtab(3) = 95.0#
        xtab(4) = 109.5
        xtab(5) = 121.5
        xtab(6) = 134.5
        xtab(7) = 147.5
        xtab(8) = 159.0#
        xtab(9) = 172.0#
        xtab(10) = 184.5
        xtab(11) = 197.0#
        xtab(12) = 210.0#
        Titol(1) = "Tag"
        Titol(2) = "Service"
        Titol(3) = "Q.ta"
        Titol(4) = "DN"
        Titol(5) = "Rtg."
        Titol(6) = "Htot"
        Titol(7) = "Hfl"
        Titol(8) = "Htr"
        Titol(9) = " N"
        Titol(10) = " L "
        Titol(11) = "De.tr"
        Titol(12) = " "
        Scalb = 1
    End Sub

    Public Sub EseguiHeadX(ByRef ik As Short)
        Dim Nome2, Nome3 As String
        Dim iDis As Short
        Dim Testo As String
        Dim X As Integer
        If Not PreliminItem() Then Exit Sub
        InizHeadx()
Uno:
70:     ReDim inn(100)
        ifl1 = FreeFile()
        DirDir = Monitor.Motore.Inizio.Workdir + "\" + job.Comm.Arch
        NomeDAT = DirDir & "\" & job.Comm.Ind.Item(job.Comm.indice).Data.File & ".DAT"
80:     FileOpen(ifl1, NomeDAT, OpenMode.Input) ', Nome1$
90:     sez01()
1100:   sez02()
1110:   sez03()
1120:   sez04()
1130:   sez05()
1140:   sez06()
1150:   sez07()
1160:   sez08()
1170:   sez09()
1180:   sez10()
1190:   sez11()
        sez12()
        sez13()
        If iTipo = 3 Or iTipo = 4 Then
            sez14()
        End If
1200:   FileClose(ifl1)
        Erase inn
        Nome2 = Monitor.Motore.Inizio.Workdir + "\" + job.Comm.Arch + "\" + job.Comm.Ind.Item(job.Comm.indice).Data.File
        'End If
        Nome3 = Nome2
        iDis = 1
1230:   If Not SetScala() Then Exit Sub
        IniziaRoutines()
        Monitor.routines.DoveDisegno.Font = New Font("MS Sans Serif", 8)
        DisHeadX(iDis)
        If (iTipo = 3 Or iTipo = 4) And iDis = 1 Then
            Testo = "Vuoi eseguire i  disegni dei   |"
            Testo = Testo & "coperchi  e delle guarnizioni? |"
            Testo = Monitor.Motore.Inizio.ConvertiCr(Testo)
            X = MsgBox(Testo, MsgBoxStyle.Question + MsgBoxStyle.YesNo, "ISA")
            If X = MsgBoxResult.Yes Then
                iDis = 2
                Call CercaNome(iDis, Nome2, Nome3) : If Len(Nome2) = 0 Then Exit Sub
                GoTo 1230
            End If
        ElseIf (iTipo = 3 Or iTipo = 4) And iDis > 1 Then
            iDis = iDis + 1
            Call CercaNome(iDis, Nome2, Nome3) : If Len(Nome2) = 0 Then Exit Sub
            GoTo 1230
        End If
    End Sub
    Private Sub CercaNome(ByRef iDis As Short, ByRef Nome2 As String, ByRef Nome3 As String)
        Dim iDis1 As Short
        Dim iPar, jpar As Short
CercaNome:
        iDis1 = iDis - 1
        iPar = 2 - (iDis1 Mod 2) : jpar = (iDis1 + 1) \ 2
        If Len(LTrim(RTrim(ch11(iPar, jpar)))) = 0 Then
            iDis = iDis + 1
            If iDis > 9 Then
                Nome2 = ""
                Exit Sub
            End If
            GoTo CercaNome
        End If
        Nome2 = Left(Nome3, Len(Nome3) - 3) & Right(RTrim(ch11(iPar, jpar)), 3)
    End Sub
    Private Sub HEADER()
        Dim p1 As Single
        Dim i As Short
        Dim x1, ytab, y1 As Single
        Dim X, AlfaH, y As Single
        Dim ICODE3, ii As Short
        Dim y2 As Single
        Dim dx As Single
        Dim nome As String
        '      On Local Error GoTo HeadErr
        '                       INIZIALIZZAZIONE VARIABILI
        '

        Call DEFINE(1)
        '
        '    CALCOLO DIMENSIONI CENTRAGGIO DISEGNO
        '
        'C(3) = 495!
        C(3) = 300.0!
        C(4) = 175.0!
        C(5) = 160.0! * Scalb / 0.1
        'C(2) = 370! + C(5) / 2!
        C(2) = 150.0! + C(5) / 2.0!
        C(6) = C(3) - C(4)
        C(7) = C(5) + A(1)
        '
        '    COSTRUZIONE TRACCIATURA PIASTRA TUBIERA
        '
        With Monitor.routines
            '            If Monitor.routines.Dove Is Printer And Apert.cmdZoom.Value Then
            ' .Scala(Apert.xTop, Apert.xBot, Apert.yTop, Apert.yBot)
            ' ElseIf Not Apert.cmdZoom.Value Then
            .Scala(0, 594 + 27, 0, 420 + 21)
            ' End If
            Call .refere(C(2), C(3), 0)
            p1 = .poynt(0.0!, 0.0!)
            Call TRACER()
            Call .refabs()
            '
            '    COSTRUZIONE CASSA 1
            '
1232:       'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.refere. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .refere(C(2), C(3) - A(15), 0)
            nome = "PLUG1_1"
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.IniziaBlocco. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .IniziaBlocco(nome)
            '               If .SwIUNpri = 3 Then
            '                 ACADobj.Application.Update
            '                 Set block = ACADobj.Blocks.Add(inspoint(), nome)
            '                .InitAcad block
            '               End If
            Call PLUG1(1)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.FinisciBlocco. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .FinisciBlocco(nome)
            nome = "PLUG2_1_1"
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.IniziaBlocco. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .IniziaBlocco(nome)
            '              If .SwIUNpri = 3 Then
            '                 Set BlockRef = ACADobj.ModelSpace.InsertBlock(inspoint(), nome, 1, 1, 0)
            '                 ACADobj.Application.Update
            '                 Set block = ACADobj.Blocks.Add(inspoint(), nome)
            '                .InitAcad block
            '              End If
            'CALL refere(-C(7) + A(402), 0!, 0)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.refere. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .refere(C(7) + A(402), 0.0!, 0)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.ctrait. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .ctrait(0, 0.4)
            Call PLUG2(1, 1)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.refere. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .refere(-A(10) / 2.0!, A(15) + AA(N8, 3), 0)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.FinisciBlocco. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .FinisciBlocco(nome)
            nome = "PLUG2_A_1"
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.IniziaBlocco. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .IniziaBlocco(nome)
            Call PLUG(AA(N8, 1), 1) 'il secondo parametro A7?
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.FinisciBlocco. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .FinisciBlocco(nome)
            nome = "TUBEA_1_1"
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.IniziaBlocco. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .IniziaBlocco(nome)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.refere. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .refere(A(10), 0.0!, 0)
            Call TUBE(AA(N8, 1), 1.0#, 1) '?????A7
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.FinisciBlocco. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .FinisciBlocco(nome)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.refabs. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .refabs()
            '
            '    COSTRUZIONE CASSA 2
            '
1233:       If (A(17) <> 0.0!) Then
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.refere. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .refere(C(2), C(3) + AA(N8 + 1, 3) - A(17), 0)
                nome = "PLUG1_2"
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.IniziaBlocco. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .IniziaBlocco(nome)
                Call PLUG1(2)
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.FinisciBlocco. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .FinisciBlocco(nome)
                nome = "PLUG2_2_1"
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.IniziaBlocco. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .IniziaBlocco(nome)
                '            CALL refere(-C(7) + A(403), 0!, 0)
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.refere. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .refere(C(7) + A(403), 0.0!, 0)
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.ctrait. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .ctrait(0, 0.4)
                Call PLUG2(2, 1)
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.FinisciBlocco. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .FinisciBlocco(nome)
                nome = "PLUGB_1"
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.IniziaBlocco. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .IniziaBlocco(nome)
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.refere. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .refere(-A(11) / 2.0!, A(17) + AA(Nfile, 3) - AA(N8 + 1, 3), 0)
                Call PLUG(AA(Nfile, 1), 1) '???? A7
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.FinisciBlocco. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .FinisciBlocco(nome)
                nome = "TUBEB_1_1"
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.IniziaBlocco. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .IniziaBlocco(nome)
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.refere. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .refere(A(11), 0.0!, 0)
                Call TUBE(AA(Nfile, 1), 1.0#, 1) '????A7
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.refabs. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .refabs()
            End If
            '
            '    COSTRUZIONE CASSA 3

            '
1234:       'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.refere. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .refere(C(2), C(6) - A(19), 0)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.FinisciBlocco. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .FinisciBlocco(nome)
            nome = "PLUG1_3"
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.IniziaBlocco. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .IniziaBlocco(nome)
            Call PLUG1(3)
            'CALL refere(C(7) + A(404), 0!, 0)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.refabs. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .refabs()
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.refere. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .refere(C(2) + 40, C(3) - A(19), 0)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.refere. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .refere(C(7) + 40 + A(404), 0.0!, 0)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.ctrait. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .ctrait(0, 0.4)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.FinisciBlocco. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .FinisciBlocco(nome)
            nome = "PLUG2_3_1"
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.IniziaBlocco. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .IniziaBlocco(nome)
            Call PLUG2(3, 1) 'sezione laterale cassa 3 ----------------
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.refere. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .refere(A(12) / 2.0!, A(19) + AA(N9, 4), 0)
            'CALL refere(A(10) / 2!, A(15) + AA(N8, 3), 0)   'scambiato
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.FinisciBlocco. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .FinisciBlocco(nome)
            nome = "PLUGC_1"
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.IniziaBlocco. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .IniziaBlocco(nome)
            Call PLUG(-AA(N9, 1), 1) 'A7?????????
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.refere. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .refere(-A(12), 0.0!, 0)
            'CALL refere(-A(10), 0!, 0)     'scambiato
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.FinisciBlocco. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .FinisciBlocco(nome)
            nome = "TUBEC_1_1"
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.IniziaBlocco. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .IniziaBlocco(nome)
            Call TUBE(AA(N9, 1), 1.0#, -1) 'A7?????
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.FinisciBlocco. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .FinisciBlocco(nome)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.refabs. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .refabs()
            '
            '    COSTRUZIONE CASSA 4
            '
1235:       If (A(21) <> 0.0!) Then
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.refere. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .refere(C(2), C(6) + AA(N9 + 1, 4) - A(21), 0)
                nome = "PLUG1_4"
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.IniziaBlocco. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .IniziaBlocco(nome)
                Call PLUG1(4)
                '            CALL refere(-C(7) + A(405), 0!, 0)
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.refabs. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .refabs()
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.refere. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .refere(C(2) + 40, C(3) + AA(N9 + 1, 4) - A(21), 0)
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.refere. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .refere(C(7) + 40 + A(405), 0.0!, 0)
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.ctrait. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .ctrait(0, 0.4)
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.FinisciBlocco. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .FinisciBlocco(nome)
                nome = "PLUG2_4_1"
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.IniziaBlocco. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .IniziaBlocco(nome)
                Call PLUG2(4, 1)
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.refere. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .refere(A(13) / 2.0!, A(21) + AA(Nfile, 4) - AA(N9 + 1, 4), 0)
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.FinisciBlocco. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .FinisciBlocco(nome)
                nome = "PLUGD_1"
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.IniziaBlocco. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .IniziaBlocco(nome)
                Call PLUG(-AA(Nfile, 1), 1) '??????a7
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.refere. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .refere(-A(13), 0.0!, 0)
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.FinisciBlocco. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .FinisciBlocco(nome)
                nome = "TUBED_1_1"
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.IniziaBlocco. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .IniziaBlocco(nome)
                Call TUBE(AA(Nfile, 1), 1.0#, -1) '??????A7
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.refabs. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .refabs()
            End If
            '-- COSTRUZIONE SETTO IN PIANTA
1236:       For i = 1 To 4
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.FinisciBlocco. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .FinisciBlocco(nome)
                nome = "Rin_" & Trim(Str(i))
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.IniziaBlocco. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .IniziaBlocco(nome)
                If Nrinf(i) > 0 Then Call Rinforz(i)
            Next
            '-- COSTRUZIONE FERMI CASSA E PIASTRE PER TEFLON SU CASSA ANDATA ------
            '      IF ( E(7)=0. ) THEN
            '      CALL FRMCSS(1, 1, 1, 4, SY1)
            '      ELSE
            '      CALL FRMCSS(1, 1, 2, 4, SY1)
            '      END IF
            '-- COSTRUZIONE FERMI CASSA E PIASTRE PER TEFLON SU CASSA RITORNO -----
            '      IF ( E(9)=0. ) THEN
            '      CALL FRMCSS(3, 1, 3, 4, SY1)
            '      ELSE
            '      CALL FRMCSS(3, 1, 4, 4, SY1)
            '      END IF
            '--------------------   COSTRUZIONI  BOCCHELLI    ---------------------
1237:       ytab = 162.5 : x1 = -1000.0! : y1 = -1000.0!
            For i = 1 To N5
                If (KB(i, 2) <= 2) Then AlfaH = 180.0!
                If (KB(i, 2) > 2) Then AlfaH = 0.0!
                '    COSTRUZIONE BOCCHELLO VISTA LONGITUDINALE
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.refabs. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .refabs()
                Select Case KB(i, 1)
                    Case 1
                        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.refere. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .refere(C(2), C(3) - A(15), 0)
                    Case 2
                        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.refere. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .refere(C(2), C(3) + AA(N8 + 1, 3) - A(17), 0)
                    Case 3
                        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.refere. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .refere(C(2), C(6) - A(19), 0)
                    Case 4
                        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.refere. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .refere(C(2), C(6) + AA(N9 + 1, 4) - A(21), 0)
                End Select
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.xcoord. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                X = .xcoord(PA(KB(i, 1), 13)) + AD(i, 1)
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.ycoord. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                y = .ycoord(PA(KB(i, 1), 12 + KB(i, 2)))
                ICODE3 = 0
                If i = 1 Then
                    ICODE3 = 1
                Else
                    ICODE3 = 1
                    For ii = 1 To i - 1
                        If (Mid(CH9(i), 1, 3) = Mid(CH9(ii), 1, 3)) Then ICODE3 = 0
                    Next
                End If
                If ICODE3 = 1 Then
                    For ii = 1 To N5
                        If (Mid(CH9(i), 1, 3) = Mid(CH9(ii), 1, 3)) Then ICODE3 = ICODE3 + 1
                    Next
                    ICODE3 = ICODE3 - 1
                End If
                If y = y1 And x1 > -1000 And y = y1 And KB(i, 1) = KB(i - 1, 1) Then
                    y2 = 30 : If AlfaH = 180.0! Then y2 = -30
                    Call .ql1(.poynt(X, y), .poynt(x1, y1), 1, y2, "")
                End If
                x1 = X : y1 = y
                Call .ctrait(0, 0.4)
                Call .FinisciBlocco(nome)
                nome = "nozzle_" & Trim(Str(i))
                Call .IniziaBlocco(nome)
                Call NOZZLE(CH9(i), X, y, 0.0!, AlfaH, ED(i, 2), 1, 1, ICODE3, ytab)
                '    COSTRUZIONE BOCCHELLO SEZIONE
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.refabs. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .refabs()
                Select Case KB(i, 1)
                    Case 3
                        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.refere. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .refere(C(2) + 40, C(3) - A(19), 0)
                        dx = C(7) + 40 + A(404)
                        If iTipo = 3 Or iTipo = 4 Then dx = dx - A(404) - A(12) / 2 + A(24) + AD(i, 3)
                        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.refere. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .refere(dx, 0.0!, 0)
                    Case 4
                        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.refere. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .refere(C(2) + 40, C(3) + AA(N9 + 1, 4) - A(21), 0)
                        dx = C(7) + 40 + A(405)
                        If iTipo = 3 Or iTipo = 4 Then dx = dx - A(405) - A(13) / 2 + A(25) + AD(i, 3)
                        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.refere. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .refere(dx, 0.0!, 0)
                    Case 1
                        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.refere. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .refere(C(2), C(3) - A(15), 0)
                        dx = C(7) + A(402)
                        If iTipo = 3 Or iTipo = 4 Then dx = dx - A(402) + A(10) / 2 - A(22) - AD(i, 3)
                        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.refere. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .refere(dx, 0.0!, 0)
                    Case 2
                        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.refere. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .refere(C(2), C(3) + AA(N8 + 1, 3) - A(17), 0)
                        dx = C(7) + A(403)
                        If iTipo = 3 Or iTipo = 4 Then dx = dx - A(403) + A(11) / 2 - A(23) - AD(i, 3)
                        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.refere. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .refere(dx, 0.0!, 0)
                End Select
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.xcoord. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                X = .xcoord(PA(KB(i, 1), 8))
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.ycoord. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                y = .ycoord(PA(KB(i, 1), 4 + KB(i, 2)))
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.ctrait. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .ctrait(0, 0.4)
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.FinisciBlocco. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .FinisciBlocco(nome)
                nome = "nozzlea_" & Trim(Str(i))
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.IniziaBlocco. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .IniziaBlocco(nome)
                Call NOZZLE(CH9(i), X, y, 0.0!, AlfaH, ED(i, 2), 2, KB(i, 3), 0, ytab)
130:        Next
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.FinisciBlocco. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .FinisciBlocco(nome)
            nome = "Tabella"
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.IniziaBlocco. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .IniziaBlocco(nome)
1238:       Call FinTabNoz(ytab)
            '---------------------  COSTRUZIONE   SETTI    ------------------------
1239:       'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.refabs. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .refabs()
            If N4 > 0 Then
                If MSETTI < N4 Then Debug.Print("DIM setti (" & MSETTI & ") insufficiente: " & N4) : Stop
                For i = 1 To N4
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.FinisciBlocco. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .FinisciBlocco(nome)
                    nome = "setti_" & Trim(Str(i))
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.IniziaBlocco. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .IniziaBlocco(nome)
                    Call SETTI(i)
140:            Next
                Call QuotSet()
            End If
            '---------------------  COSTRUZIONE   TARGHE   ------------------------
            '      CALL REFABS
            '      DO 150 I=1,N3
            'for I=1  to N3
            '      X = (XCOORD(PA(INT(EB(I, 1)), 3)) + XCOORD(PA(INT(EB(I, 1)), 4))) / 2!
            '      Y = YCOORD(PA(INT(EB(I, 1)), 3))
            '      CALL REFERE(X + AB(I, 2), Y,0)
            '      CALL TARGA(I)
            '      CALL REFABS
            '150   next ''
            '---------------  COSTRUZIONE TABELLA   -------------------------------
1240:       'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.refabs. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .refabs()
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.FinisciBlocco. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .FinisciBlocco(nome)
            nome = "TAB"
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.IniziaBlocco. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .IniziaBlocco(nome)
            Call TABELL()
            '---------------  COSTRUZIONE ASSIEME MONTAGGIO   ---------------------
1241:       'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.refabs. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .refabs()
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.refere. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .refere(C(2) - 150, 130, 0)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.refere. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .refere(C(7), 0.0!, 0)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.FinisciBlocco. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .FinisciBlocco(nome)
            nome = "Montag" & Trim(Str(i))
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.IniziaBlocco. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .IniziaBlocco(nome)
            Call MONTAG(Nfile)
            '---------------  COSTRUZIONE FORMATO   -------------------------------
            '      CALL REFABS
            '      CALL A1
            '      CALL TAB2
            '      CALL TAB5
            '      CALL REFABS
            '      CALL ZOOM(440!, 330!, .33)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.FinisciBlocco. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .FinisciBlocco(nome)
            nome = "FORMA2"
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.IniziaBlocco. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .IniziaBlocco(nome)
1242:       Call FORMA2(1, 1)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.FinisciBlocco. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .FinisciBlocco(nome)
        End With
        Exit Sub
        'HeadErr:
        'PRINT "Errore in HEADER:"; ERR; ERL: u$ = INPUT$(1)
        'Resume Next
    End Sub
    Private Sub NOZZLE(ByRef cg As String, ByRef X As Single, ByRef y As Single, ByRef y1 As Single, ByRef AlfaH As Single, ByRef H As Single, ByRef ICODE1 As Short, ByRef ICODE2 As Short, ByRef ICODE3 As Short, ByRef ytab As Single)
        '     On Local Error GoTo NozzErr
        Dim Cod As String
        Dim ii, iRec As Short
        Dim Dvec As Single
        Dim l, j, k As Short
        Dim Dia As Single
        Dim Sagom As Boolean
        Dim i As Short
        Dim x0, xt, p1, x1 As Single
        Dim EE3, EE1, EE2, a1 As Single
        ReDim ANoz(47)
        ReDim eNoz(47)
        ReDim inn(100)
        InitNozzle()
        CH4N(1) = Mid(cg, 1, 3)
        Cod = LTrim(RTrim(CH4N(1)))
        ii = Val(Right(Cod, 1)) 'T+ii:tag del bocchello
        If Mid(cg, 9, 5) = "MANIC" Then
1020:       Call MANIC(cg, X, y, AlfaH, ICODE1, ICODE2)
1021:       GoTo TabMan
        End If
        '----------------------------------------------------------------------
        '    APERTURA E LETTURA DATI DA FILE ESTERNO
        '----------------------------------------------------------------------
        'ifl1 = FreeFile
        'Open Monitor.Motore.Inizio.Archdir + "\NOZZLE.DAT" For Input Shared As #ifl1
        'Form$ = SKIPPA1(6)
        '1023  If EOF(ifl1) Then
        '          Debug.Print "errore 1"; Mid$(cg$, 33, 7)
        '          'BEEP
        '          Stop
        '          Close #ifl1
        '          Exit Sub
        '      End If
        '      Form$ = SKIPPA1(1)
        '1024  LEGFORM "(8X,A7)", inn$(), 1, 30
        iRec = CercaRec(Mid(cg, 33, 7), CStr(Val(Mid(cg, 9, 7))))
        If iRec = 0 Then
            MsgBox("Errore nella lettura della libreria standard da NOZZLE")
            Exit Sub
        End If
        CH2N = Str(ReadLib(iRec, 2)) ' inn$(1) 'rating
        '      If Val(Mid$(CH2N, 1, 7)) = Val(Mid$(cg$, 33, 7)) Then
        '2023        If EOF(ifl1) Then
        '               'BEEP
        '               Debug.Print "Errore 2"; Mid$(cg$, 9, 7)
        '               Stop
        '               Close #ifl1: Exit Sub
        '            End If
        '            Form$ = SKIPPA1(1)
        '            LEGFORM "(A5,25(F6.1))", inn$(), 26, 31
        CH3N = Str(ReadLib(iRec, 1)) ' inn$(1)
        '            If Val(CH3N) = 0 And Dvec > 0 Then
        '               Debug.Print "Errore 3"; CH3N
        '               Stop
        '               Close #ifl1: Exit Sub
        '            End If
        '            Dvec = Val(CH3N)
        '            If Dvec = Val(Mid$(cg$, 9, 7)) Then
        For j = 2 To 11
            eNoz(j - 1) = ReadLib(iRec, j + 1) ' Val(inn$(j))
        Next
        For j = 12 To 14
            eNoz(j) = ReadLib(iRec, j + 1)
        Next
        For j = 15 To 26
            eNoz(j) = ReadLib(iRec + 10, j - 14) ' Val(inn$(j))
        Next
        '  GoTo 3023
        '            End If
        '            GoTo 2023
        '      End If
        '      GoTo 1023
        '3023  Close #ifl1
        '----------------------------------------------------------------------
        '    INIZIALIZZAZIONE E RIDEFINIZIONE VARIABILI
        '----------------------------------------------------------------------
        Dia = Val(Mid(cg, 12, 4))
        eNoz(27) = 20.0!
        If Mid(cg, 22, 1) = "S" Then Sagom = True Else Sagom = False
        If (Mid(cg, 25, 2) = "RF") Then l = 0
        If (Mid(cg, 25, 2) = "RJ") Then l = 1
        If (Mid(cg, 23, 2) = "SE") Then k = 2 : l = 0
        If (Mid(cg, 23, 2) = "SO") Then k = 0
        If (Mid(cg, 23, 2) = "LJ") Then k = 1
        If (Mid(cg, 23, 2) = "WN") Then k = 2
        If (H <> 0.0!) Then eNoz(25 + l) = H
        If (Mid(cg, 23, 2) = "LJ") Then
            eNoz(3) = eNoz(3) + 1.6
            eNoz(23 + l) = 0.0!
        End If
        eNoz(6 + k) = eNoz(6 + k) + eNoz(23 + l)
        '----------------------------------------------------------------------
        '     CALCOLO DELLE DIMENSIONI IN SCALA
        '----------------------------------------------------------------------
        For i = 1 To 47
            If (i = 13 Or i = 14) Then GoTo 50
            ANoz(i) = eNoz(i) * Scalb
50:     Next
        '----------------------------------------------------------------------
        '    COSTRUZIONE DELLA FLANGIA
        '----------------------------------------------------------------------
        With Monitor.routines
            If (AlfaH = 0.0!) Then y = y + ANoz(25 + l) - ANoz(6 + k)
            If (AlfaH = 180.0!) Then y = y - ANoz(25 + l) + ANoz(6 + k)
            Call .refere(X, y, AlfaH)
            If (ICODE2 = 1) Then
                P(1) = .poynt(0.0!, 0.0!)
                P(2) = .poynt(-ANoz(MAX(4, 3 + k)) / 2.0!, 0.0!)
                P(3) = .poynt(-ANoz(MAX(4, 3 + k)) / 2.0!, ANoz(27))
                P(4) = .poynt(-ANoz(4) / 2.0!, ANoz(6 + k) - ANoz(23 + l) - ANoz(3))
                P(5) = .poynt(-ANoz(2) / 2.0!, ANoz(6 + k) - ANoz(23 + l) - ANoz(3))
                'provvisorio
                If ICODE1 = 1 Then
                    Call .ECRIR("T" & Right(Str(ii), 1))
                    xt = System.Math.Abs(.xcoord(P(5))) + 3.0!
                    If AlfaH = 180.0! Then xt = -xt
                    Call .texte0(xt, .ycoord(P(5)), 0.0!, 4.0!, 0.6)
                End If
                '---------------
                P(6) = .poynt(-ANoz(2) / 2.0!, ANoz(6 + k) - ANoz(23 + l))
                P(7) = .poynt(-ANoz(18 + l) / 2.0!, ANoz(6 + k) - ANoz(23 + l))
                P(8) = .poynt(-ANoz(18 + l) / 2.0!, ANoz(6 + k))
                P(9) = .poynt(0.0!, ANoz(6 + k))
                P(10) = .poynt(-ANoz(12) / 2.0!, ANoz(6 + k) + 1.0!)
                P(11) = .poynt(-ANoz(12) / 2.0!, ANoz(6 + k) - ANoz(23 + l) - ANoz(3) - 1.0!)
                If (Mid(cg, 23, 2) = "SE") Then GoTo Tronc
                For i = 1 To 10
                    If (i = 9.0!) Then GoTo 100
                    Call .seg1(P(i), P(i + 1))
                    Call .segm(-.xcoord(P(i)), .ycoord(P(i)), -.xcoord(P(i + 1)), .ycoord(P(i + 1)))
100:            Next
                Call .seg2(P(4), ANoz(4), 0.0!)
                If (ANoz(23 + l) <> 0.0!) Then Call .seg2(P(7), ANoz(18 + l), 0.0!)
                If (ANoz(Max(4, 3 + k)) <> ANoz(4)) Then Call .seg2(P(3), ANoz(5), 0.0!)
            End If
            '----------------------------------------------------------------------
            '    COSTRUZIONE DELLA TRONCHETTO FINO A 4" COMPRESI
            '----------------------------------------------------------------------
Tronc:      If ((eNoz(1) <= 114.3 Or Not Sagom) And ICODE2 = 1) Then
                p1 = .poynt(-ANoz(1) / 2.0!, 0.0!)
                Call .seg2(p1, -ANoz(25 + l) + ANoz(6 + k), 90.0!)
                Call .seg2(.poynt(-.xcoord(p1), .ycoord(p1)), -ANoz(25 + l) + ANoz(6 + k), 90.0!)
                If (Mid(cg, 23, 2) = "SE") Then Call .segm(-.xcoord(p1), .ycoord(p1), .xcoord(p1), .ycoord(p1))
            ElseIf (ICODE2 = 1) Then
                '----------------------------------------------------------------------
                '    COSTRUZIONE DELLA TRONCHETTO OLTRE I  4"
                '----------------------------------------------------------------------
                '      IF (eNoz(1) > 114.3) THEN
                Dia = Val(Mid(cg, 12, 4))
                If (ICODE1 = 1) Then
                    Call .segm(-ANoz(1) / 2.0!, 0.0!, -ANoz(1) / 2.0!, -ANoz(Int(Dia) / 2 + 33))
                    Call .segm(-ANoz(1) / 2.0!, -ANoz(Int(Dia) / 2 + 33), -ANoz(Int(Dia) / 2 + 25) / 2.0!, -ANoz(25 + l) + ANoz(6 + k))
                    Call .segm(-ANoz(1) / 2.0!, -ANoz(Int(Dia) / 2 + 33), ANoz(1) / 2.0!, -ANoz(Int(Dia) / 2 + 33))
                    Call .segm(ANoz(1) / 2.0!, -ANoz(Int(Dia) / 2 + 33), ANoz(Int(Dia) / 2 + 25) / 2.0!, -ANoz(25 + l) + ANoz(6 + k))
                End If
                If (ICODE2 = 1) Then
                    x0 = ANoz(1) / 2.0! : x1 = ANoz(Int(Dia) / 2 + 29) / 2.0!
                    y1 = -ANoz(25 + l) + ANoz(6 + k) + ANoz(Int(Dia) / 2 + 37)
                    Call .segm(-x0, 0.0!, -x0, -ANoz(Int(Dia) / 2 + 33))
                    Call .segm(-x0, -ANoz(Int(Dia) / 2 + 33), -ANoz(Int(Dia) / 2 + 29) / 2.0!, -ANoz(25 + l) + ANoz(6 + k) + ANoz(Int(Dia) / 2 + 37))
                    Call .segm(-x1, y1, -x1, -ANoz(25 + l) + ANoz(6 + k))
                    Call .segm(-x0, -ANoz(Int(Dia) / 2 + 33), x0, -ANoz(Int(Dia) / 2 + 33))
                    Call .segm(x0, 0.0!, x0, -ANoz(Int(Dia) / 2 + 33))
                    Call .segm(x0, -ANoz(Int(Dia) / 2 + 33), ANoz(Int(Dia) / 2 + 29) / 2.0!, -ANoz(25 + l) + ANoz(6 + k) + ANoz(Int(Dia) / 2 + 37))
                    Call .segm(x1, y1, x1, -ANoz(25 + l) + ANoz(6 + k))
                    If (Mid(cg, 23, 2) = "SE") Then Call .segm(-x0, 0.0!, x0, 0.0!)
                End If
            End If
            If ICODE2 = 1 Then
                Call .ctrait(2, 0.1)
                Call .segm(0.0!, ANoz(6 + k) + 3.0!, 0.0!, -ANoz(25 + l) + ANoz(6 + k))
            End If
            Call .refere(X, y, -AlfaH)
        End With
        '----------------------------------------------------------------------
        '                      COSTRUZIONE DEI TESTI
        '----------------------------------------------------------------------
TabMan:
        With Monitor.routines
            If (ICODE3 >= 1) Then
                Call .refabs()
                Call .refere(180, -100, 0)
                If ytab = 162.5 Then
                    Call .ctrait(0, 0.2)
                    For i = 1 To 12
                        Call .segm(xtab(i) - 2.0!, ytab + 3.5, xtab(i) - 2.0!, ytab - 1.5)
                        Call .ECRIR(Titol(i))
                        Call .texte0(xtab(i), ytab, 0.0!, 2.0!, 0.2)
                    Next
                    Call .refabs()
                    Call .refere(180, -100, 0)
                    Call .segm(xtab(1) - 2.0!, ytab + 3.5, xtab(12) + 12.0!, ytab + 3.5)
                    Call .segm(xtab(12) + 12.0!, ytab + 3.5, xtab(12) + 12.0!, ytab - 1.5)
                    ytab = ytab - 5.0!
                End If
                EE1 = 0.0!
                EE2 = 0.0!
                EE3 = 0.0!
                Select Case ii
                    Case 1 : CH4N(2) = "INLET"
                    Case 2 : CH4N(2) = "OUTLET"
                    Case 3 : CH4N(2) = "VENT "
                    Case 4 : CH4N(2) = "DRAIN"
                    Case 5 : CH4N(2) = "TEMP."
                    Case 6 : CH4N(2) = "PRESS"
                End Select
                CH4N(3) = Str(ICODE3)
                CH4N(4) = Mid(cg, 11, 6) 'DN
                If Left(CH4N(4), 1) = "N" Then
                    k = Val(Mid(CH4N(4), 6, 1))
                    Select Case k
                        Case 4 : CH4N(4) = "1/2" & Chr(34)
                            CH4N(6) = Str(48)
                        Case 5 : CH4N(4) = "3/4" & Chr(34)
                            CH4N(6) = Str(51)
                        Case 6 : CH4N(4) = "1" & Chr(34)
                            CH4N(6) = Str(60)
                        Case 7 : CH4N(4) = "1 1/4" & Chr(34)
                            CH4N(6) = Str(67)
                        Case 8 : CH4N(4) = "1 1/2" & Chr(34)
                            CH4N(6) = Str(79)
                    End Select
                    CH4N(5) = "6000"
                    CH4N(7) = Chr(32)
                    CH4N(8) = Chr(32)
                    CH4N(9) = Chr(32)
                    CH4N(10) = Chr(32)
                    CH4N(11) = Chr(32)
                Else
                    CH4N(5) = CH2N 'Rtg
                    CH4N(6) = Str(Int(eNoz(25 + l))) 'Htot
                    CH4N(7) = Str(Int(eNoz(6 + k) + 0.5)) 'Hfl
                    CH4N(8) = Str(Int(eNoz(25 + l)) - Int(eNoz(6 + k) + 0.5)) 'Htr
                    If (eNoz(1) > 114.3 And Sagom) Then EE1 = eNoz(Int(Dia) / 2 + 33)
                    CH4N(9) = Str(Int(EE1)) 'N
                    If (eNoz(1) > 114.3 And Sagom) Then EE2 = eNoz(Int(Dia) / 2 + 41)
                    CH4N(10) = Str(Int(EE2)) 'L
                    If (eNoz(1) <= 114.3 Or Not Sagom) Then EE3 = eNoz(1)
                    CH4N(11) = Str(EE3) 'De.tr
                End If
                CH4N(12) = "000"
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.ctrait. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .ctrait(0, 0.2)
                For i = 1 To 12
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .segm(xtab(i) - 2.0!, ytab + 3.5, xtab(i) - 2.0!, ytab - 1.5)
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.ECRIR. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .ECRIR(CH4N(i))
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.texte0. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .texte0(xtab(i), ytab, 0.0!, 2.0!, 0.2)
150:            Next
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.ctrait. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .ctrait(0, 0.2)
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .segm(xtab(12) + 12.0!, ytab + 3.5, xtab(12) + 12.0!, ytab - 1.5)
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .segm(xtab(1) - 2.0!, ytab + 3.5, xtab(12) + 12.0!, ytab + 3.5)
                ytab = ytab - 5.0!
            End If
            If Mid(cg, 9, 5) = "MANIC" Then Exit Sub
            '
            '    COSTRUZIONE DELLA PIANTA BOCCHELLO
            '
            If (y1 <> 0.0!) Then
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.refabs. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .refabs()
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.refere. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .refere(X, y1, 0)
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.ctrait. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .ctrait(1, 0.1)
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.poynt. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                p1 = .poynt(0.0!, 0.0!)
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.cerc. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                a1 = .cerc(0.0!, 0.0!, ANoz(1) / 2.0!)
                For i = 90 To 360 Step 90
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.seg2. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .seg2(p1, ANoz(1) / 3.0!, i * 1.0!)
10001:          Next
            End If
            Erase ANoz
            Erase eNoz
            Erase inn
        End With
        Exit Sub
        'NozzErr: Print "Errore in HEADX2/NOZZLE"; Err; Erl
        'Resume Next
    End Sub
    Private Sub FinTabNoz(ByRef ytab As Single)
        With Monitor.routines
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.refabs. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .refabs()
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.refere. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .refere(180, -100, 0)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.ctrait. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .ctrait(0, 0.6)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .segm(xtab(1) - 2.0!, ytab + 3.5, xtab(12) + 12.0!, ytab + 3.5)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.ECRIR. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .ECRIR("        BOCCHELLI     -      NOZZLES !")
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .segm(xtab(1) - 2.0!, 175.0!, xtab(12) + 12.0!, 175.0!)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .segm(xtab(1) - 2.0!, 175.0!, xtab(1) - 2.0!, ytab + 3.5)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .segm(xtab(12) + 12.0!, 175.0!, xtab(12) + 12.0!, ytab + 3.5)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.texte0. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .texte0(xtab(1), 168.0!, 0.0!, 4.0!, 0.3)
        End With
    End Sub

    Private Sub Freccia(ByRef p1 As Single, ByRef p2 As Single, ByRef S As String)
        Dim X, y As Single
        With Monitor.routines
            If S = "D" Or S = "A" Then
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.xcoord. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                X = .xcoord(p1) + (.xcoord(p2) - .xcoord(p1)) / 3.0! * 2
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.ycoord. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                y = .ycoord(p1) + (.ycoord(p2) - .ycoord(p1)) / 3.0! * 2
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .segm(X, y, X - 1, y + 1)
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .segm(X, y, X - 1, y - 1)
            End If
            If S = "S" Or S = "A" Then
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.xcoord. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                X = .xcoord(p1) + (.xcoord(p2) - .xcoord(p1)) / 3.0!
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.ycoord. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                y = .ycoord(p1) + (.ycoord(p2) - .ycoord(p1)) / 3.0!
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .segm(X, y, X + 1, y + 1)
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .segm(X, y, X + 1, y - 1)
            End If
        End With
    End Sub

    Sub INPUTA(ByRef IERCOD As Integer)
        '     --------------------      S E Z   12    --------------------------
        '
        '1014  FORMAT ( 5(/),10(59X,A12/),70X,I1/,4(66X,F6.0/),61X,I2,3X,F6.0/,
        '     &         8(66X,F6.0/),3(27X,10(I3,1X,F5.0)/) )
        'A1014$ = "( 5(/),10(59X,A12/),70X,I1/,4(66X,F6.0/),61X,I2,3X,F6.0/,8(66X,F6.0/),3(27X,10(I3,1X,F5.0)/) )"

        '      READ ( 7,1014 ) (CH13(I),I=1,10),N6,(E(I),I=150,153),N7,
        '     &                (E(I),I=154,162),
        '     &                ((  N10(I,J),EF(I,J)  ,J=1,10),I=1,3)
        '      LEGFORM A1014$, INN$(), 85
        '      FOR I = 1 TO 10: CH13(I) = INN$(I): NEXT
        '      N6=VAL(INN$(11))
        '      FOR I = 12 TO 15: E(138+I) = VAL(INN$((I)): NEXT
        '      N7=VAL(INN$(16))
        '      FOR I = 17 TO 25: E(137+I) = VAL(INN$(I)): NEXT
        '      FOR I = 1 TO 3: FOR J = 1 TO 10: N10(I, J) = VAL(INN$((I - 1) * 10 + J+25): NEXT:NEXT
        '      FOR I = 1 TO 3: FOR J = 1 TO 10: EF(I, J) = VAL(INN$((I - 1) * 10 + J+55): NEXT:NEXT

        'PRINT "FINE LETTURA SEZ12- TELAIO                          ."
        '
        '     --------------------      S E Z   13    --------------------------
        '
        '1015  FORMAT ( 3(/),8(15(F7.1,1X)/) )
        'A1015$ = "( 3(/),8(15(F7.1,1X)/) )"
        'READ ( 7,1015 ) (E(I),I=200,319)
        '      LEGFORM A1015$, INN$(),  120
        '      FOR I = 1 TO 120: E(200 + I) = VAL(INN$(I)): NEXT
        '      PRINT "FINE LETTURA SEZ13- DIMENSIONI STANDARD TELAIO      ."
        '-----------------------------------------------------------------------
        '                          F I N E
        '-----------------------------------------------------------------------
        '      CLOSE (1)
        '9998  'CONTINUE
    End Sub

    Private Sub MANIC(ByRef uu As String, ByRef X As Single, ByRef y As Single, ByRef AlfaH As Single, ByRef ICODE1 As Short, ByRef ICODE2 As Short)
        Dim j, ii, i, k As Short
        Dim g, C, B, D, f As Single
        Dim yt, xt, H As Single
        InitManic()
        If (ICODE2 = 0) Then Exit Sub
        ii = Val(Mid(uu, 3, 1)) 'T+ii:tag del bocchello
        '----------------------------------------------------------------------
        '              CALCOLO DELLE DIMENSIONI IN SCALA
        '----------------------------------------------------------------------
        For i = 1 To 12 : For j = 1 To 2
                aMan(i, j) = eMan(i, j) * Scalb
            Next : Next  ''
        '
        '-----------------------------------------------------------------------
        '              SCELTA DEL MANICOTTO DA COSTRUIRE
        '-----------------------------------------------------------------------
        k = Val(Mid(uu, 15, 2))
        '-----------------------------------------------------------------------
        '              CALCOLO APPROSSIMATO DIMENSIONI
        '-----------------------------------------------------------------------
        B = aMan(k, 1) * 0.1
        C = aMan(k, 1) * 0.25
        D = aMan(k, 1) * 0.9
        f = aMan(k, 1) * 0.8
        g = D / 4.0!
        '-----------------------------------------------------------------------
        '               COSTRUZIONE GEOMETRICA
        '----------------------------------------------------------------------
        With Monitor.routines
            Call .refere(X, y, AlfaH)
            PMan(1) = .poynt(-aMan(k, 1) / 2.0!, 0.0!)
            PMan(2) = .poynt(-aMan(k, 1) / 2.0!, aMan(k, 2))
            PMan(3) = .poynt(aMan(k, 1) / 2.0!, aMan(k, 2))
            PMan(4) = .poynt(aMan(k, 1) / 2.0!, 0.0!)
            'provvisorio
            If ICODE1 = 1 Then
                Call .ECRIR("T" & Right(Str(ii), 1))
                xt = System.Math.Abs(.xcoord(PMan(3))) + 3.0!
                yt = .ycoord(PMan(3))
                If AlfaH = 180.0! Then xt = -xt ': yt = -yt
                Call .texte0(xt, yt, 0.0!, 4.0!, 0.6)
            End If
            '---------------
            Call .ctrait(0, 0.4)
            Call .refere(0.0!, aMan(k, 2), 0)
            '----------------    COSTRUZIONE MANICOTTO NORMALE     -----------------
            If (Mid(uu, 19, 8) <> "        ") Then GoTo 1000 'LWNRF
            PMan(5) = .poynt(-D / 2.0!, B)
            PMan(6) = .poynt(-D / 2.0!, B + C)
            PMan(7) = .poynt(D / 2.0!, B + C)
            PMan(8) = .poynt(D / 2.0!, B)
            PMan(9) = .poynt(-D / 2.0!, B)
            Call .segm(-f / 2.0!, 0.0!, -f / 2.0!, B)
            Call .segm(f / 2.0!, 0.0!, f / 2.0!, B)
            Call .segm(-g, B, -g, B + C)
            Call .segm(g, B, g, B + C)
            Call .ctrait(2, 0.1)
            Call .segm(0.0!, -2.0!, 0.0!, aMan(k, 2) + B + C + 2.0!)
            GoTo 9011
            '----------------    COSTRUZIONE MANICOTTO LUNGO       -----------------
1000:       '
            'READ ( uu$(19:27),'(5X,F4.0)' ) H
            H = Val(Mid(uu, 19, 9))
            H = H * Scalb
            D = aMan(k, 1) * 0.7
            f = aMan(k, 1) * 0.6
            PMan(5) = .poynt(-D / 2.0!, B)
            PMan(6) = .poynt(-D / 2.0!, H)
            PMan(7) = .poynt(D / 2.0!, H)
            PMan(8) = .poynt(D / 2.0!, B)
            PMan(9) = .poynt(-D / 2.0!, B)
            Call .segm(-f / 2.0!, 0.0!, -f / 2.0!, B)
            Call .segm(f / 2.0!, 0.0!, f / 2.0!, B)
            Call .refere(0.0!, -aMan(k, 2), 0)
            Call .ctrait(2, 0.1)
            Call .segm(0.0!, -2.0!, 0.0!, aMan(k, 2) + B + H + 2.0!)
            '----------------    COSTRUZIONE SEGMENTI COMUNI       -----------------
9011:       'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.ctrait. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .ctrait(0, 0.4)
            'DO 30 I=1,8
            For i = 1 To 8
                If (i = 4) Then GoTo 30
                Call .seg1(PMan(i), PMan(i + 1))
30:         Next  '
            Call .refere(-AlfaH, 0, 0)
        End With
    End Sub

    Private Sub MONTAG(ByRef Nfile As Short)
        Dim a1, B1 As Single
        Dim botBdl, basFl, basCas As Single
        Dim topFl, topBdl, hfascA As Single
        Dim supA, hfascB, supB As Single
        Dim splitA, splitB As Single
        Dim i As Short
        Dim P3, p1, p24, p23 As Single
        Dim p6, p4, p5, p61 As Single
        Dim p9, p7, p8, p10 As Single
        Dim p13, p11, p12, p26 As Single
        Dim p52, p51, p81, p2 As Single
        Dim xSin, xdes As Single
        Dim S As String
        InitMontag()
        '----------------------------------------------------------------------
        '    CALCOLO DELLE DIMENSIONI FITTIZIE PER LA RAPPRESENTAZIONE
        '----------------------------------------------------------------------
        '      IF LEFT$(CH16(40), 1) <> "S" THEN
        '       IF (eMon(102) + e(28)) > (eMon(101) + e(26)) THEN a1 = 3! ELSE a1 = 0!'FiloInfB>FiloInfA
        '       IF (eMon(102) + e(28)) < (eMon(101) + e(26)) THEN b1 = 3! ELSE b1 = 0!
        If EA(1, 3) > EA(1, 4) + 10 Then a1 = 3.0! Else a1 = 0.0! 'FiloInfB>FiloInfA
        If EA(1, 4) > EA(1, 3) + 10 Then B1 = 3.0! Else B1 = 0.0!
        '      ELSE
        '     a1 = 0!: b1 = 0!
        '      END IF
        '----------------------------------------------------------------------
        '    CALCOLO DELLE DIMENSIONI FITTIZIE PER LA RAPPRESENTAZIONE
        '----------------------------------------------------------------------
        basFl = 60.0!
        botBdl = 65.0!
        basCas = 72.0!
        topBdl = 102.0! + a1 + B1
        topFl = 107.0! + a1 + B1
        With Monitor.routines
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.refabs. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .refabs()
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.refere. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .refere(-40, -30, 0)
            'CALL REFERE(C(7) + A(402), 0!, 0)
            '---------------    COSTRUZIONE   CASSA   'A'       -------------------
            'DO 10 I=1,NFILE
            hfascA = 18.0! : hfascB = 18.0! : supA = 96 : supB = 96
            If EA(Nfile, 3) > EA(Nfile, 4) + 10 Then
                hfascA = 22.0! : supA = 100
                hfascB = EA(Nfile, 4) / EA(Nfile, 3) * hfascA
                supB = basCas + EA(Nfile, 3) / EA(Nfile, 4) * (supA - basCas)
            End If
            If EA(Nfile, 4) > EA(Nfile, 3) + 10 Then
                hfascB = 22.0! : supB = 100
                hfascA = EA(Nfile, 3) / EA(Nfile, 4) * hfascB
                supA = basCas + EA(Nfile, 3) / EA(Nfile, 4) * (supB - basCas)
            End If
            splitA = 0.0! : splitB = 0.0!
            For i = 1 To Nfile
                '      PAMon(i) = poynt(122!, 75! + b1 + (i - 1) * 18! / (NFILE - 1))
                '      PBMon(i) = poynt(182!, 75! + a1 + (i - 1) * 18! / (NFILE - 1))
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.poynt. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                PAMon(i) = .poynt(122.0!, 75.0! + B1 + EA(i, 3) * hfascA / EA(Nfile, 3))
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.ycoord. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                If i > 1 And e(27) > 0 And EA(i, 3) - EA(i - 1, 3) > Val(CH7(5, 4)) * 1.2 Then splitA = (.ycoord(PAMon(i)) + .ycoord(PAMon(i - 1))) / 2
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.poynt. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                PBMon(i) = .poynt(182.0!, 75.0! + a1 + EA(i, 4) * hfascB / EA(Nfile, 4))
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.ycoord. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                If i > 1 And e(29) > 0 And EA(i, 4) - EA(i - 1, 4) > Val(CH7(5, 4)) * 1.2 Then splitB = (.ycoord(PBMon(i)) + .ycoord(PBMon(i - 1))) / 2
110:        Next  '
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.poynt. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            p1 = .poynt(109.5, topFl + B1)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.poynt. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            p2 = .poynt(100.0!, botBdl)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.poynt. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            p24 = .poynt(109.5, botBdl)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.poynt. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            P3 = .poynt(107.0!, basCas + B1)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.poynt. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            p23 = .poynt(107.0!, botBdl)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.poynt. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            p4 = .poynt(114.5, topBdl + 3.0!)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.poynt. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            p5 = .poynt(205.0!, botBdl)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.poynt. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            p6 = .poynt(109.5, 68.5)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.poynt. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            p61 = .poynt(110.0!, 68.5)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.poynt. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            p7 = .poynt(109.5, basFl)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.poynt. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            p8 = .poynt(197.0!, basCas + B1)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.poynt. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            p9 = .poynt(189.5, topBdl + 3.0!)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.poynt. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            p10 = .poynt(194.5, topFl + a1)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.ctrait. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .ctrait(0, 0.6)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .segm(100.0!, botBdl, 205.0!, botBdl) 'bottom bundle frame
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .segm(100.0!, topBdl, 205.0!, topBdl) 'top bundle frame
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .segm(107.0!, supA + B1, 122.0!, supA + B1) 'top cassa A
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .segm(107.0!, basCas + B1, 122.0!, basCas + B1) 'bottom cassa A
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            If splitA > 0.0! Then Call .segm(107.0!, splitA, 122.0!, splitA)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .segm(107.0!, supA + B1, 107.0!, basCas + B1)
            '???  S5 = segm(107!, supA! + b1, 107!, basCas! + b1)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .segm(122.0!, supA + B1, 122.0!, basCas + B1)
            xSin = 225.0! : xdes = 260.0!
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.poynt. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            p11 = .poynt(xSin, botBdl)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.poynt. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            p12 = .poynt(xSin, topBdl)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.seg1. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .seg1(p11, p12) 'fiancata sinistra
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .segm(xSin, botBdl, xSin + 3.0!, botBdl)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .segm(xSin, topBdl, xSin + 3.0!, topBdl)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.poynt. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            p13 = .poynt(xdes, topBdl)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.ycoord. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.xcoord. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .segm(xdes, botBdl, .xcoord(p13), .ycoord(p13)) 'fiancata destra
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .segm(xdes, botBdl, xdes - 3.0!, botBdl)
            Call .segm(xdes, topBdl, xdes - 7.0!, topBdl)
            Call .ECRIR("BUNDLE X-SECTION !")
            Call .texte0(xSin + 2.0!, 62.0!, 0.0!, 2.0!, 0.2)
            Call .ql1(p11, p12, 0, 8.0!, Str(eMon(108)) & " ext.") 'altezza
            Call .ql1(p12, p13, 0, 8.0!, Str(eMon(107)) & " int.") 'larghezza
            If (a1 <> 0.0! Or B1 <> 0.0!) Then
                Call .ql1(P3, p23, 2, -8.0!, Str(eMon(101))) '8 era 10   0,0 era -2,-2
            End If
            Call .ctrait(0, 0.6)
            If (eMon(103) <> 0.0!) Then 'QUOTA A1
                Call .segm(109.5, topFl + B1, 119.5, topFl + B1) 'bocch T1
                Call .segm(114.5, topFl + B1, 114.5, supA + B1)
                Call .ql1(p1, p24, 2, -18.0!, Str(eMon(103))) '16 era -16
            End If
            Call .ctrait(0, 0.6)
            If (eMon(104) < 0.0!) Then
                Call .segm(114.5, basCas, 114.5, 68.5)
                Call .segm(109.5, 68.5, 119.5, 68.5)
                p26 = .poynt(110.0!, botBdl)
                Call .ql1(p61, p26, 2, -8.0!, Str(-eMon(104)))
            End If
            Call .ctrait(0, 0.6)
            If (eMon(104) > 0.0!) Then
                Call .segm(114.5, basCas + B1, 114.5, basFl)
                Call .segm(109.5, basFl, 119.5, basFl)
                Call .ql1(p24, p7, 2, -16.0!, Str(eMon(104)))
            End If
            Call .ctrait(2, 0.1)
            Call .segm(114.5, 68.0!, 114.5, 100.0!)
            '    SCRITTURA TESTI
            Call .ECRIR("INLET !")
            Call .texte0(110.5, 110.5, 0.0!, 2.0!, 0.2)
            Call .ECRIR("HEADER !")
            Call .texte0(92.5, 94.0!, 0.0!, 2.0!, 0.2)
            Call .ECRIR("-A- !")
            Call .texte0(95.0!, 89.5, 0.0!, 2.0!, 0.2)
            Call .ECRIR("HEADER !")
            Call .texte0(201.0!, 93.5, 0.0!, 2.0!, 0.2)
            Call .ECRIR("-B- !")
            Call .texte0(204.0!, 89.0!, 0.0!, 2.0!, 0.2)
            Call .ECRIR("BOTTOM BUNDLE FRAME !")
            Call .texte0(135.0!, botBdl + 1.0!, 0.0!, 2.0!, 0.2)
            Call .ECRIR("TOP BUNDLE FRAME !")
            Call .texte0(135.0!, topBdl - 3.0!, 0.0!, 2.0!, 0.2)
            Call .ECRIR("OUTLET !")
            If (eMon(104) <> 0.0!) Then
                Call .texte0(110.0!, 52.0!, 0.0!, 2.0!, 0.2)
            Else
                Call .texte0(184.0!, 52.0!, 0.0!, 2.0!, 0.2)
            End If
            '---------------    COSTRUZIONE   CASSA   'B'       -------------------
            Call .ctrait(0, 0.6)
            For i = 1 To Nfile
                Call .seg1(PAMon(i), PBMon(i))
                S = Senso(i)
                Call Freccia(PAMon(i), PBMon(i), S)
301:        Next  '
            Call .segm(182.0!, supB + a1, 197.0!, supB + a1) 'top    cassa B
            Call .segm(182.0!, basCas + a1, 197.0!, basCas + a1) 'bottom cassa b
            If splitB > 0.0! Then Call .segm(182.0!, splitB, 197.0!, splitB)
            Call .segm(182.0!, supB + a1, 182.0!, basCas + a1)
            Call .segm(197.0!, supB + a1, 197.0!, basCas + a1)
            p51 = .poynt(197.0!, botBdl)
            p81 = .poynt(197.0!, basCas + a1)
            Call .ql1(p51, p81, 2, -10.0!, Str(eMon(102)))
            '----------------------
            Call .ql1(p4, p9, 2, 11.0!, Str(eMon(100)))
            Call .ctrait(0, 0.6)
            p52 = .poynt(194.5, botBdl)
            If (eMon(105) <> 0.0!) Then 'Quota A3
                Call .segm(184.5, topFl + a1, 194.5, topFl + a1)
                Call .segm(189.5, topFl + a1, 189.5, supB + a1)
                Call .ql1(p52, p10, 2, -18.0!, Str(eMon(105)))
            End If
            Call .ctrait(0, 0.6)
            If (eMon(106) < 0.0!) Then
                Call .segm(189.5, 68.5 + a1, 189.5, basCas)
                Call .segm(184.5, 68.5 + a1, 194.5, 68.5 + a1)
                p11 = .poynt(194.5, 68.5 + a1)
                Call .ql1(p52, p11, 2, -8.0!, Str(-eMon(106)))
            End If
            If (eMon(106) > 0.0!) Then
                Call .segm(189.5, basFl, 189.5, basCas + a1)
                Call .segm(184.5, basFl, 194.5, basFl)
                p12 = .poynt(194.5, basFl + a1)
                Call .ql1(p12, p52, 2, -8.0!, Str(eMon(106)))
            End If
            Call .ctrait(2, 0.1)
            Call .segm(189.5, 68.0!, 189.5, 100.0!)
        End With
    End Sub
    Private Sub PLUG(ByRef A9 As Single, ByRef A7 As Single)
        If iTipo = 3 Or iTipo = 4 Then Exit Sub
        With Monitor.routines
            Call .ctrait(0, 0.1)
            Call .segm(-0.6 * A9, 0.77 * A9, 0.0!, 0.77 * A9)
            Call .segm(-0.6 * A9, -0.77 * A9, 0.0!, -0.77 * A9)
            Call .segm(-0.6 * A9, 0.4 * A9, 0.0!, 0.4 * A9)
            Call .segm(-0.6 * A9, -0.4 * A9, 0.0!, -0.4 * A9)
            Call .segm(-0.6 * A9, 0.77 * A9, -0.6 * A9, -0.77 * A9)
            Call .segm(-1.2 * A9, 0.0!, A7 + 1.5, 0.0!)
        End With
    End Sub
    Private Sub PLUG1(ByRef i As Short)
        Dim PU3, PU1, PU2, PU4 As Single
        Dim PU7z, PU7, PU8 As Single
        Dim PU9z, PU9, PU10 As Single
        Dim PU6, PU5, PU66 As Single
        Dim PU100, PU110 As Single
        Dim dist, y As Single
        '
        '     ESEGUE LA VISTA DELLA CASSA
        '
        '     INCLUDE 'TRONA.INC'
        '
        '     COSTRUZIONE DEI PUNTI DI RIFERIMENTO
        '
        With Monitor.routines
            PA(i, 1) = .poynt(-A(5 + i) / 2.0!, -A(25 + i))
            PA(i, 2) = .poynt(A(5 + i) / 2.0!, -A(25 + i))
            PA(i, 3) = .poynt(A(5 + i) / 2.0!, A(12 + i * 2) - A(25 + i))
            PA(i, 4) = .poynt(-A(5 + i) / 2.0!, A(12 + i * 2) - A(25 + i))
            PA(i, 13) = .poynt(0.0!, -A(25 + i))
            PA(i, 14) = .poynt(0.0!, 0.0!)
            PA(i, 15) = .poynt(0.0!, A(12 + i * 2) - 2 * A(25 + i))
            PA(i, 16) = .poynt(0.0!, A(12 + i * 2) - A(25 + i))
            '
            '     COSTRUZIONE DEI SEGMENTI
            '
            Call .ctrait(0, 0.4)
            Call .segm(-A(5 + i) / 2.0!, -A(25 + i), A(5 + i) / 2.0!, -A(25 + i))
            Call .segm(-A(5 + i) / 2.0!, A(12 + i * 2) - A(25 + i), A(5 + i) / 2.0!, A(12 + i * 2) - A(25 + i))
            Call .segm(-A(5 + i) / 2.0!, -A(25 + i), -A(5 + i) / 2.0!, A(12 + i * 2) - A(25 + i))
            Call .segm(A(5 + i) / 2.0!, -A(25 + i), A(5 + i) / 2.0!, A(12 + i * 2) - A(25 + i))
            Call .ctrait(1, 0.1)
            PU1 = .poynt(-A(5 + i) / 2.0!, 0.0!)
            PU2 = .poynt(A(5 + i) / 2.0!, 0.0!)
            Call .seg1(PU1, PU2)
            PU3 = .poynt(-A(5 + i) / 2.0!, A(12 + i * 2) - 2 * A(25 + i))
            PU4 = .poynt(A(5 + i) / 2.0!, A(12 + i * 2) - 2 * A(25 + i))
            Call .seg1(PU3, PU4)
            PU7 = .poynt(-A(5 + i) / 2.0! + A(29 + i), A(12 + i * 2) - A(25 + i)) 'y era 0
            PU7z = .poynt(-A(5 + i) / 2.0! + A(29 + i), 0.0!)
            PU8 = .poynt(-A(5 + i) / 2.0! + A(29 + i), A(12 + i * 2) - 2 * A(25 + i))
            Call .seg1(PU7z, PU8)
            PU9 = .poynt(A(5 + i) / 2.0! - A(29 + i), A(12 + i * 2) - A(25 + i)) 'y era 0
            PU9z = .poynt(A(5 + i) / 2.0! - A(29 + i), 0.0!)
            PU10 = .poynt(A(5 + i) / 2.0! - A(29 + i), A(12 + i * 2) - 2 * A(25 + i))
            PU100 = .poynt(A(5 + i) / 2.0! - A(29 + i), A(12 + i * 2) - A(25 + i))
            PU110 = .poynt(-(A(5 + i) / 2.0! - A(29 + i)), A(12 + i * 2) - A(25 + i))
            Call .seg1(PU9z, PU10)
            Call .ctrait(2, 0.1)
            PU5 = .poynt(-A(5 + i) / 2.0! - 5.0!, (A(12 + i * 2) - 2 * A(25 + i)) / 2.0!)
            PU6 = .poynt(A(5 + i) / 2.0! + 5.0!, (A(12 + i * 2) - 2 * A(25 + i)) / 2.0!)
            PU66 = .poynt(-A(5 + i) / 2.0!, (A(12 + i * 2) - 2 * A(25 + i)) / 2.0!)
            Call .segm(0.0!, A(12 + i * 2) - A(25 + i) + 5.0!, 0.0!, -A(25 + i) - 5.0!)
            '
            '     QUOTATURA VERTICALE    (di fianco)
            dist = -40 'era -55
            Call .ql1(PA(i, 4), PA(i, 1), 2, dist, "")
            Call .ql1(PA(i, 4), PU3, 2, dist + 8, "") 'spessore
            Call .ql1(PU3, PU1, 2, dist + 8, "")
            Call .ql1(PU1, PA(i, 1), 2, dist + 8.0!, "") 'spessore
            '
            '     QUOTATURA ORIZZONTALE
            '
            If (i = 1 And A(17) <> 0.0!) Then Exit Sub 'GO TO 1007
            If (i = 3 And A(21) <> 0.0!) Then Exit Sub 'GO TO 1007
            '
            '     Y = DISTANZA   :   CASSA - ULTIMA QUOTA
            If (i = 1 Or i = 2) Then y = 75.0!
            If (i = 3 Or i = 4) Then y = 55.0!
            Call .ql1(PA(i, 4), PA(i, 3), 1, y - 12.0!, "") 'fuori tutto
            Call .ql1(PU7, PU9, 1, y - 19, "") 'totale corto
            '------------------------
            Call .ql1(PA(i, 4), PU110, 1, y - 33.0!, "") 'spessore
            Call .ql1(PU100, PA(i, 3), 1, y - 33.0!, "") 'spessore
            Call .ql1(PU110, PA(i, 16), 1, y - 26, "") 'quota meta
            Call .ql1(PA(i, 16), PU100, 1, y - 26, "") 'quuta meta
        End With
    End Sub
    Private Sub PLUG2(ByRef i As Short, ByRef iCode As Short)
        Dim xx1, X, xx, x1 As Single
        Dim dx, dy As Single
        Dim iW As Short
        Dim ii As Short
        Dim p1, p2 As Single
        Dim p4, p5 As Single
        '
        '     ESEGUE LA SEZIONE DELLA CASSA
        '
        '     COSTRUZIONE DEI PUNTI DI RIFERIMENTO
        '
        With Monitor.routines
            PA(i, 5) = .poynt(0.0!, -A(25 + i))
            PA(i, 6) = .poynt(0.0!, 0.0!)
            PA(i, 7) = .poynt(0.0!, A(12 + i * 2) - 2 * A(25 + i))
            PA(i, 8) = .poynt(0.0!, A(12 + i * 2) - A(25 + i))
            PA(i, 9) = .poynt(-A(9 + i) / 2.0!, A(12 + i * 2) - A(25 + i))
            PA(i, 10) = .poynt(A(9 + i) / 2.0!, A(12 + i * 2) - A(25 + i))
            PA(i, 11) = .poynt(-A(9 + i) / 2.0!, -A(25 + i))
            PA(i, 12) = .poynt(A(9 + i) / 2.0!, -A(25 + i))
            '
            '     COSTRUZIONE DEI SEGMENTI
            '
            X = -A(9 + i) / 2.0! : x1 = -X
            xx = X + A(21 + i) : xx1 = x1 - A(21 + i)
            If i < 3 And (iTipo = 3 Or iTipo = 4) Then xx = X
            If i > 2 And (iTipo = 3 Or iTipo = 4) Then xx1 = x1
            Call .segm(X, -A(25 + i), x1, -A(25 + i))
            Call .segm(xx, 0.0!, xx1, 0.0!)
            Call .segm(xx, A(12 + i * 2) - 2 * A(25 + i), xx1, A(12 + i * 2) - 2 * A(25 + i))
            Call .segm(X, A(12 + i * 2) - A(25 + i), x1, A(12 + i * 2) - A(25 + i))
            If Not (i < 3 And (iTipo = 3 Or iTipo = 4)) Then Call .segm(-A(9 + i) / 2.0!, -A(25 + i), -A(9 + i) / 2.0!, A(12 + i * 2) - A(25 + i))
            If iTipo = 3 Or iTipo = 4 And i < 3 Then Call .ctrait(0, 0.1)
            Call .segm(xx, -A(25 + i), xx, A(12 + i * 2) - A(25 + i)) 'bordo cassa
            Call .ctrait(0, 0.4)
            If iTipo = 3 Or iTipo = 4 And i > 2 Then Call .ctrait(0, 0.1)
            Call .segm(xx1, -A(25 + i), xx1, A(12 + i * 2) - A(25 + i)) 'bordo cassa
            Call .ctrait(0, 0.4)
            If Not (i > 2 And (iTipo = 3 Or iTipo = 4)) Then Call .segm(A(9 + i) / 2.0!, -A(25 + i), A(9 + i) / 2.0!, A(12 + i * 2) - A(25 + i))
            If iTipo = 3 Or iTipo = 4 Then
                If i < 3 Then
                    dx = X - A(360) : iW = 1
                Else
                    dx = x1 + A(360) : iW = -1
                End If
                dy = (A(12 + i * 2) - 2 * A(25 + i)) / 2
                Call DefinCov(Int(i))
                Call .refere(dx, dy, 0.0!)
                For ii = -1 To 1 Step 2
                    Call .segm(A(360) * iW, A(12 + i * 2) / 2 * ii, A(360) * iW, A(341) / 2.0! * ii)
                    Call .segm(A(360) * iW, A(341) / 2 * ii, (A(360) + A(355 + i)) * iW, A(341) / 2.0! * ii)
                    Call .segm((A(360) + A(355 + i)) * iW, A(341) / 2 * ii, (A(360) + A(355 + i)) * iW, A(12 + i * 2) / 2 * ii)
                Next ii
                Call SezionCov(Int(i), iW)
                Call .refere(-dx, -dy, 0.0!)
            End If
            '
            '     QUOTATURA ORIZZONTALE
            '
            If (iCode = 1) Then
                If (i = 1 And A(17) <> 0.0!) Then Exit Sub
                If (i = 3 And A(21) <> 0.0!) Then Exit Sub
                p1 = .poynt(X, A(12 + i * 2) - A(25 + i) + 23.0!)
                p2 = .poynt(x1, A(12 + i * 2) - A(25 + i) + 23.0!)
                Call .ql1(p1, p2, 1, 14, "")
                p4 = .poynt(xx, A(12 + i * 2) - A(25 + i) + 23.0!)
                p5 = .poynt(xx1, A(12 + i * 2) - A(25 + i) + 23.0!)
                If Not (i < 3 And (iTipo = 3 Or iTipo = 4)) Then Call .ql1(p1, p4, 1, 6, "")
                Call .ql1(p4, p5, 1, 6, "")
                If Not (i > 2 And (iTipo = 3 Or iTipo = 4)) Then Call .ql1(p5, p2, 1, 6, "")
                '
                '     TESTI
                '
                If (i = 1) Then
                    Call .ECRIR(" HEADER 'A' ")
                    Call .texte0(-18.0!, A(14) + 50.0!, 0.0!, 5.0!, 0.5)
                End If
                If (i = 3) Then
                    Call .ECRIR(" HEADER 'B' ")
                    Call .texte0(-18.0!, A(18) + 50.0!, 0.0!, 5.0!, 0.5)
                End If
            End If
        End With
    End Sub
    Private Sub PLUG3(ByRef i As Short)
        '
        '     ESEGUE LA PIANTA DELLA CASSA
        '
        '     COSTRUZIONE DEL PERIMETRO ESTERNO DELLA CASSA
        '
        With Monitor.routines
            Call .ctrait(1, 0.1)
            Call .segm(-A(9 + i) / 2.0!, -A(5 + i) / 2.0!, -A(9 + i) / 2.0!, A(5 + i) / 2.0!)
            Call .segm(-A(9 + i) / 2.0!, A(5 + i) / 2.0!, A(9 + i) / 2.0!, A(5 + i) / 2.0!)
            Call .segm(A(9 + i) / 2.0!, A(5 + i) / 2.0!, A(9 + i) / 2.0!, -A(5 + i) / 2.0!)
            Call .segm(A(9 + i) / 2.0!, -A(5 + i) / 2.0!, -A(9 + i) / 2.0!, -A(5 + i) / 2.0!)
        End With
    End Sub
    Private Sub QuotSet()
        Dim M, i1 As Short
        Dim B As Single
        Dim p1, p2 As Single
        With Monitor.routines
            For M = 3 To 4
                Call .refabs()
                Call .refere(C(2), C(3), 0)
                Call .refere(C(7), 0.0!, 0)
                B = 0
                If M = 4 Then
                    Call .refabs()
                    Call .refere(C(2) + 40, C(3) - A(15), 0)
                    Call .refere(C(7) + 40 + A(402), A(19), 0)
                End If
                If M = 3 Then
                    p1 = .poynt(20.0! * (M - 3.5) * 2.0!, -A(15))
                Else
                    p1 = .poynt(20.0! * (M - 3.5) * 2.0!, -A(19))
                End If
                For i1 = iiset(M - 2) To 1 Step -1
                    p2 = .poynt(20.0! * (M - 3.5) * 2.0!, yyset(i1, M - 2))
                    If M = 3 Then GlobalRoutines.SWAP(p1, p2)
                    Call .ql1(p2, p1, 1, 10.0! + B, "")
                    If B = 0 Then B = 10 Else B = 0
                    If M = 3 Then p2 = p1 Else p1 = p2
                Next i1
            Next M
            Call .refabs()
        End With
    End Sub
    Private Sub Rinforz(ByRef i As Short)
        Dim j As Short
        Dim x1, Alargh, x2 As Single
        Dim p1, xt, xt1, p2 As Single
        Dim P3, p4 As Single
        Dim nb As Short
        Dim Logic As Boolean
        Dim kaprim As Short
        Dim p6, p5, Lato As Single
        Dim dist, y1, y2, Al1 As Single
        Dim kaa As Short
        For j = 1 To N4
            If ka(j, 1) = i And ka(j, 5) = 4 Then
                Alargh = 2 * System.Math.Abs(AC(j, 1))
                Al1 = 2 * System.Math.Abs(EC(j, 1))
                Exit For
            End If
        Next
        With Monitor.routines
            Call .refere(C(2), C(3) - A(15) + 1.0! / 3 * (C(6) - C(3) - A(19) + A(15)), 0)
            If i = 2 Or i = 4 Then Call .refere(0, -3 * A(9 + i), 0)
            If i < 3 Then
                x1 = -Alargh / 20.0! : x2 = -Alargh / 2.0!
                Call .ECRIR("REINFORCEMENTS FOR HEADER A (L=" & Str(Al1) & ")!")
                xt = x2 : xt1 = x2 - 40
            Else
                x1 = Alargh / 20.0! : x2 = Alargh / 2.0!
                xt = x1 : xt1 = x2 + 5
                Call .ECRIR("REINFORCEMENTS FOR HEADER B (L=" & Str(Al1) & ")!")
            End If
            Call .texte0(xt, A(9 + i), 0.0!, 2.0!, 0.2)
            Call .ctrait(0, 0.4)
            p1 = .poynt(x1, 0.0!)
            p2 = .poynt(x2, 0.0!)
            P3 = .poynt(x1, A(9 + i) - 2 * A(21 + i))
            p4 = .poynt(x2, A(9 + i) - 2 * A(21 + i))
            Call .seg1(p1, p2)
            Call .seg1(p2, p4)
            Call .seg1(P3, p4) ': s1 = seg1(P3, P1)
            nb = 0 : Logic = False
            If i < 3 Then GlobalRoutines.SWAP(x1, x2)
            For j = 1 To N4
                If ka(j, 1) = i And ka(j, 5) = 2 Then
                    If nb = 0 Then kaprim = ka(j, 3)
                    If kaprim = ka(j, 3) Then nb = nb + 1
                    If nb = 1 And i < 3 Then
                        p5 = .poynt((AC(j, 1) + AC(j, 2)) / 2, 0)
                        p6 = .poynt((AC(j + 1, 1) + AC(j + 1, 2)) / 2, 0)
                    ElseIf i > 2 And kaprim = ka(j, 3) Then
                        p6 = .poynt((AC(j - 1, 1) + AC(j - 1, 2)) / 2, 0)
                        p5 = .poynt((AC(j, 1) + AC(j, 2)) / 2, 0)
                    End If
                    If AC(j, 1) > x1 And AC(j, 2) < x2 Then
                        If ka(j, 3) <> kaa And Logic Then Exit For
                        kaa = ka(j, 3) : Logic = True
                        Lato = EC(j, 2) - EC(j, 1)
                        y1 = (.ycoord(P3) + AC(j, 2) - AC(j, 1)) / 2
                        y2 = (.ycoord(P3) - AC(j, 2) + AC(j, 1)) / 2
                        Call .segm(AC(j, 1), y1, AC(j, 1), y2)
                        Call .segm(AC(j, 1), y1, AC(j, 2), y1)
                        Call .segm(AC(j, 1), y2, AC(j, 2), y2)
                        Call .segm(AC(j, 2), y1, AC(j, 2), y2)
                    End If
                End If
            Next
            Call .ECRIR(Str(nb) & " holes" & Str(Lato) & " x" & Str(Lato) & " !")
            Call .texte0(xt1, A(9 + i) / 3, 0.0!, 2.0!, 0.2)
            dist = A(9 + i)
            If i < 3 Then dist = -dist
            If i < 3 Then GlobalRoutines.SWAP(x1, x2)
            Call .ql1(.poynt(x2, 0), p5, 2, dist, "")
            Call .ql1(p5, p6, 2, dist, "")
            Call .refabs()
        End With
    End Sub

    Private Sub SETTI(ByRef i As Short)
        Static iSW As Short
        Dim M As Short
        Dim p1, p2 As Single
        Dim x1, X, x2 As Single
        Dim zero, y1 As Single
        Dim l As Short
        Dim i1 As Short
        Dim y, y2 As Single
        If i = 1 Then
            iSW = False
            ReDim yyset(MSETTI, 2)
            ReDim iiset(2)
            iiset(1) = 0 : iiset(2) = 0
        End If
        With Monitor.routines
            If (ka(i, 1) = 1 Or ka(i, 1) = 2) Then
                Call .refere(C(2), C(3), 0)
                M = 3
            Else
                Call .refere(C(2), C(3) - C(4), 0)
                M = 4
            End If
            '-------------------   SETTI   ORIZZONTALI     ------------------------
            If (ka(i, 2) = 0) Then
                '    CALCOLO ORDINATA MEZZERIA SETTO
                '            y = (AA(ka(i, 3), M) + AA(ka(i, 3) + 1, M)) / 2!
                y = AC(i, 5)
                If y = 0.0! Then y = (AA(ka(i, 3), M) + AA(ka(i, 3) + 1, M)) / 2.0!
                For i1 = 1 To iiset(M - 2)
                    If System.Math.Abs(y - yyset(i1, M - 2)) < 0.1 Then Return
                Next
                iiset(M - 2) = iiset(M - 2) + 1
                If iiset(M - 2) > MSETTI Then Debug.Print("Errore in SETTI") : Stop
                yyset(iiset(M - 2), M - 2) = y
                If (AC(i, 4) <> 0.0!) Then
                    Call .ctrait(Int(AC(i, 4)), 0.2)
                    Call .segm(AC(i, 1), y + AC(i, 3) / 2.0!, AC(i, 2), y + AC(i, 3) / 2.0!)
                    Call .segm(AC(i, 1), y - AC(i, 3) / 2.0!, AC(i, 2), y - AC(i, 3) / 2.0!)
                    Call .segm(AC(i, 1), y + AC(i, 3) / 2.0!, AC(i, 1), y - AC(i, 3) / 2.0!)
                    Call .segm(AC(i, 2), y + AC(i, 3) / 2.0!, AC(i, 2), y - AC(i, 3) / 2.0!)
                    If Not iSW Then
                        iSW = True
                        p1 = .poynt(AC(i, 1), y + AC(i, 3) / 2.0!)
                        p2 = .poynt(AC(i, 1), y - AC(i, 3) / 2.0!)
                        Call .ql1(p2, p1, 2, 10.0!, "")
                    End If
                Else
                    Call .ctrait(0, 0.8)
                    Call .segm(AC(i, 1), y + AC(i, 3) / 2.0!, AC(i, 2), y + AC(i, 3) / 2.0!)
                    Call .segm(AC(i, 1), y - AC(i, 3) / 2.0!, AC(i, 2), y - AC(i, 3) / 2.0!)
                    Call .ctrait(0, 0.1)
                    Call .segm((AC(i, 1) + AC(i, 2)) / 2.0!, y + 2.0!, (AC(i, 1) + AC(i, 2)) / 2.0!, y - 2.0!)
                End If
                Call .refere(C(7), 0.0!, 0)
                If M = 4 Then
                    Call .refabs()
                    Call .refere(C(2) + 40, C(3) - A(15), 0)
                    Call .refere(C(7) + 40 + A(402), A(19), 0)
                End If
                If (AC(i, 4) = 0.0!) Then
                    Call .ctrait(0, 0.8)
                    X = 1.2
                    Call .segm(-X, y + AC(i, 3) / 2.0!, X, y + AC(i, 3) / 2.0!)
                    Call .segm(-X, y - AC(i, 3) / 2.0!, X, y - AC(i, 3) / 2.0!)
                    Call .ctrait(0, 0.1)
                    Call .segm(0.0!, y + 2.0!, 0.0!, y - 2.0!)
                Else
                    x1 = -(A(9 + ka(i, 1)) - 2 * A(21 + ka(i, 1))) / 2.0!
                    x2 = -x1
                    If ka(i, 1) < 3 And (iTipo = 3 Or iTipo = 4) Then
                        x1 = x1 - A(21 + ka(i, 1)) - A(361) 'profondit… canalino
                        Call .segm(x1, y - AC(i, 3) / 2.0!, x1, y + AC(i, 3) / 2.0!)
                    End If
                    If ka(i, 1) > 2 And (iTipo = 3 Or iTipo = 4) Then
                        x2 = x2 + A(21 + ka(i, 1)) + A(361)
                        Call .segm(x2, y - AC(i, 3) / 2.0!, x2, y + AC(i, 3) / 2.0!)
                    End If
                    If Not (iTipo = 3 Or iTipo = 4) Then
                        Call .ctrait(0, 0.1)
                    Else
                        Call .ctrait(1, 0.1)
                    End If
                    Call .segm(x1, y + AC(i, 3) / 2.0!, x2, y + AC(i, 3) / 2.0!)
                    Call .segm(x1, y - AC(i, 3) / 2.0!, x2, y - AC(i, 3) / 2.0!)
                End If
                Call .refabs()
            Else
                '  SETTI VERTICALI
                iCassa = ka(i, 1)
                Select Case iCassa
                    Case 1 : zero = -A(15)
                    Case 2 : zero = AA(N8 + 1, 3) - A(17)
                    Case 3 : zero = -A(19)
                    Case 4 : zero = AA(N9 + 1, 4) - A(21)
                End Select
                y1 = 0
                For l = 1 To N4
                    If ka(i, 4) = 1 Then
                        y1 = zero
                        Exit For
                    ElseIf ka(i, 4) = ka(l, 3) + 1 And ka(i, 1) = ka(l, 1) And ka(l, 2) = 0 And (ka(l, 5) = 1 Or ka(l, 5) = 4) Then
                        y1 = AC(l, 5)
                        If y1 = 0 Then y1 = (AA(ka(l, 3), M) + AA(ka(l, 3) + 1, M)) / 2.0!
                        y1 = y1 + AC(l, 3) / 2
                        Exit For
                    End If
                Next l
                If y1 = 0 Then y1 = zero
                y2 = 0
                For l = 1 To N4
                    If ka(i, 4) = Nfile Then
                        y2 = zero + A(12 + iCassa * 2) - 2 * A(25 + iCassa)
                        Exit For
                    ElseIf ka(i, 4) = ka(l, 3) And iCassa = ka(l, 1) And ka(l, 2) = 0 And (ka(l, 5) = 1 Or ka(l, 5) = 4) Then
                        y2 = AC(l, 5)
                        If y2 = 0 Then y2 = (AA(ka(l, 3), M) + AA(ka(l, 3) + 1, M)) / 2.0!
                        y2 = y2 - AC(l, 3) / 2.0!
                        Exit For
                    End If
                Next
                If y2 = 0 Then y2 = zero + A(12 + iCassa * 2) - 2 * A(25 + iCassa)
                X = -A(1) + (CSng(ka(i, 3)) - 0.5) * AA(ka(i, 4), 5) + AA(ka(i, 4), 2)
                If M = 4 Then X = -X
                x1 = X - AC(i, 3) / 2.0! : x2 = X + AC(i, 3) / 2.0!
                Call .ctrait(Int(AC(i, 4)), 0.2)
                Call .segm(x1, y1, x2, y1)
                Call .segm(x2, y1, x2, y2)
                Call .segm(x2, y2, x1, y2)
                Call .segm(x1, y2, x1, y1)
                Call .refabs()
            End If
        End With
        Exit Sub
    End Sub

    Private Sub TRACER()
        Dim l, i, j As Short
        Dim X As Single
        Dim CH, nome As String
        '
        '      T R A C C I A T U R A        P I A S T R E       T U B I E R E
        '
        'DIM CH AS STRING * 20
        'DO 10 I = 1,NFILE
        With Monitor.routines
            nome = "Traccia"
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.IniziaBlocco. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            .IniziaBlocco(nome)
            For i = 1 To Nfile
                '
                '                      COSTRUZIONE   DEI   TUBI
                '
                X = AA(i, 2) - AA(i, 5)
                'DO 30 L = 1,3
                'DO 20 J = 1,NTUBI(I,L)
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.ctrait. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .ctrait(0, 0.4)
                For l = 1 To 3
                    For j = 1 To Ntubi(i, l)

                        X = X + AA(i, l + 4)
                        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.cerc. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .cerc(-A(1) + X, AA(i, 3), AA(i, 1) / 2.0!)
                        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.cerc. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .cerc(A(1) - X, -C(4) + AA(i, 4), AA(i, 1) / 2.0!)
                    Next  '20    CONTINUE
                Next  '30    CONTINUE
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.FinisciBlocco. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                .FinisciBlocco(nome)
                nome = "TrkTesti"
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.IniziaBlocco. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                .IniziaBlocco(nome)
                '
                '                      COSTRUZIONE   DEI   TESTI
                '
                ' NTOT = NTUBI(I, 1) + NTUBI(I, 2) + NTUBI(I, 3)
                '     CALL CTRAIT ( 5.,.1 )
                ' S1 = SEGM(A(6) / 2! + 1!, AA(I, 3), A(6) / 2! + 31!, AA(I, 3))
                ' S2 = SEGM(A(6) / 2! + 1!, -C(4) + AA(I, 4), A(6) / 2! + 31!, -C(4) + AA(I, 4))
                '     WRITE ( CH(I),"(A3,I3,A8)" ) "N@ ",NTOT," TUBES !"
                '     CALL ECRIR ( CH(I) )
                ' T1 = TEXTE0(A(6) / 2! + 33!, AA(I, 3) - 1!, 0!, 2!, .2)
                '     CALL ECRIR ( CH(I) )
                ' T2 = TEXTE0(A(6) / 2! + 33!, -C(4) + AA(I, 4) - 1!, 0!, 2!, .2)
                '
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.ctrait. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .ctrait(0, 0.1)
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .segm(A(6) / 2.0! + 1.0!, AA(i, 3), A(6) / 2.0! + 31.0!, AA(i, 3))
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .segm(A(6) / 2.0! + 1.0!, -C(4) + AA(i, 4), A(6) / 2.0! + 31.0!, -C(4) + AA(i, 4))
                If (Ntubi(i, 2) = 0) Then
                    CH = "N@ " & Str(Ntubi(i, 1)) & " TUBES !"
                Else
                    CH = "N@ " & Str(Ntubi(i, 1)) & Str(Ntubi(i, 2)) & Str(Ntubi(i, 3)) & " TUBES"
                End If
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.ECRIR. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .ECRIR(CH)
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.texte0. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .texte0(A(6) / 2.0! + 33.0!, AA(i, 3) - 1.0!, 0.0!, 2.0!, 0.2)
                If (Ntubi(i, 2) = 0) Then
                    CH = "N@ " & Str(Ntubi(i, 1)) & " TUBES"
                Else
                    CH = "N@ " & Str(Ntubi(i, 2)) & Str(Ntubi(i, 3)) & Str(Ntubi(i, 1)) & " TUBES !"
                End If
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.ECRIR. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .ECRIR(CH)
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.texte0. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .texte0(A(6) / 2.0! + 33.0!, -C(4) + AA(i, 4) - 1.0!, 0.0!, 2.0!, 0.2)
            Next  '10    CONTINUE
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.FinisciBlocco. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            .FinisciBlocco(nome)
        End With
    End Sub

    Private Sub TUBE(ByRef A9 As Single, ByRef A7 As Single, ByRef mp As Short)
        With Monitor.routines
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.ctrait. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .ctrait(0, 0.1)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .segm(0.0!, A9 / 2.0!, 3.0! * mp, A9 / 2.0!)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .segm(0.0!, -A9 / 2.0!, 3.0! * mp, -A9 / 2.0!)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .segm(3.0! * mp, A9, 3.0! * mp, -A9)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .segm(3.0! * mp, A9, 7.0! * mp, A9)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .segm(3.0! * mp, -A9, 7.0! * mp, -A9)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .segm((-A7 - 1.5) * mp, 0.0!, 9.0! * mp, 0.0!)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.arc. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .arc(6.5 * mp, A9 / 2.0!, 7.0! * mp, A9, -System.Math.Atan(A9) * mp * 360.0! / 3.14)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.arc. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .arc(6.5 * mp, -A9 / 2.0!, 7.0! * mp, -A9, System.Math.Atan(A9) * mp * 360.0! / 3.14)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.arc. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .arc(7.5 * mp, -A9 / 2.0!, 7.0! * mp, -A9, -System.Math.Atan(A9) * mp * 360.0! / 3.14)
            'RE1 = REPERE(POYNT(6!, 0!), 0!, 14!, ANOTEX("6"), TYPFLE(1!))
        End With
    End Sub
    Private Sub CercaMat(ByRef i As Short)
        Dim j As Short
        Dim St As String
        For j = 1 To 2
            If Val(ch1(j, 1)) = i Then GoTo Trova
        Next
        For j = 1 To n1
            If Val(CH2(j, 1)) = i Then GoTo Trova1
        Next
        St = "  N.A. !" : GoTo Fine
Trova:  St = ch1(j, 5) : GoTo Fine
Trova1: St = CH2(j, 5)
Fine:   'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.ECRIR. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        Call Monitor.routines.ECRIR(St)
    End Sub

    Private Sub FORMA2(ByRef iCode As Short, ByRef Ntotbank As Short)
        Static ndis As Integer
        '      On Local Error GoTo ErrForma2
        Dim bbbb(35) As Single
        Dim cccc(70) As Single
        Dim ch1ch1(14) As String
        Dim che(7) As String
        Dim ifl, ie As Short
        Dim A, B As String
        Dim j, i As Short
        '      RESTORE 3000
        '3000:
        'bb
        '       Data 275#, 36.5, 0#, 5#, 0.5, 437#, 27#, 0#, 2#, 0.2
        '       Data 455#, 38#, 0#, 4#, 0.4, 295#, 50.5, 0#, 5#, 0.5
        '       Data 400#, 42#, 0#, 2#, 0.2, 420#, 41.5, 0#, 3#, 0.2
        '       Data 431#, 34.5, 0#, 2#, 0.2
        'cc
        '       Data 430#, 126#, 0#, 3#, 0.3, 430#, 121#, 0#, 3#, 0.3
        '       Data 430#, 116#, 0#, 3#, 0.3, 430#, 111#, 0#, 3#, 0.3
        '       Data 430#, 101#, 0#, 4#, 0.4, 430#, 93#, 0#, 4#, 0.4
        '       Data 430#, 85#, 0#, 4#, 0.4, 577#, 57.5, 0#, 2#, 0.2
        '       Data 555#, 57.5, 0#, 2#, 0.2, 417#, 57.5, 0#, 2#, 0.2
        '       Data 542#, 20#, 0#, 4#, 0.4, 428#, 57.5, 0#, 2#, 0.2
        '       Data 558#, 12#, 0#, 2#, 0.2, 572#, 12#, 0#, 2#, 0.2

        'che
        '       Data " ", " ", "AIR  COOLER -  PROPOSAL  DRAWING "
        '       Data " ", " ", " ", " "
        ifl = FreeFile()
        FileOpen(ifl, CStr(Monitor.Motore.Inizio.Archdir + "\FORMA2.DAT"), OpenMode.Input, , OpenShare.Shared)
100:    For j = 1 To 35 : Input(ifl, bbbb(j)) : Next
        For j = 1 To 70 : Input(ifl, cccc(j)) : Next
        For j = 1 To 7 : Input(ifl, che(j)) : Next
        FileClose(ifl)
        If iCode = 1 Then ndis = 0
        With Monitor.routines
            .refabs()
            che(1) = "" ' "che(1)"
            che(4) = "" ' "che(4)"
            che(5) = "" ' "che(5)"
110:        For i = 1 To 14
                ch1ch1(i) = "" ' "ch1(" + STR$(i) + ")"
            Next
            '      refere -40!, 40!, 0!
            ndis = ndis + 1
            Mid(che(7), 1, 3) = " 1:"
            A = ch10(1)
            B = ch10(3)
            If Len(B) > 18 Then B = RTrim(Right(B, Len(B) - 18)) Else B = ""
            che(3) = A & " / " & B & " !" 'CLIENT/SERVICE
            che(2) = ch10(9)
            che(6) = Left(ch10(5), Len(ch10(5)) - 1) 'ITEM
            ch1ch1(8) = ch10(21)
            ch1ch1(9) = DateString
            ch1ch1(10) = " 0" 'REVISIONE
112:        Mid(che(7), 4, 4) = Str(Int(1 / Scalb + 0.2))
            Mid(che(7), 8, 50) = Space(50)
            ch1ch1(11) = ch10(30) 'era ch10(30)
            ch1ch1(12) = "1ST ISSUE"
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto ndis. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            ch1ch1(13) = Str(ndis)
            ch1ch1(14) = Str(Ntotbank)
114:        For i = 1 To 35 Step 5
                If (i = 21) Then GoTo 221
                ie = (i + 4) / 5
                If (Mid(che(ie), 1, 25) = "                         ") Then GoTo 221
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.ECRIR. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .ECRIR(che(ie))
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.texte0. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .texte0(bbbb(i), bbbb(i + 1), bbbb(i + 2), bbbb(i + 3), bbbb(i + 4))
221:        Next
            For i = 1 To 70 Step 5
                ie = (i + 4) / 5
                If (Mid(ch1ch1(ie), 4, 25) = "                         ") Then GoTo 321
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.ECRIR. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .ECRIR(ch1ch1(ie))
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.texte0. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .texte0(cccc(i), cccc(i + 1), cccc(i + 2), cccc(i + 3), cccc(i + 4))
321:        Next
            'UPGRADE_NOTE: Erase è stato aggiornato a System.Array.Clear. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
            System.Array.Clear(bbbb, 0, bbbb.Length)
            'UPGRADE_NOTE: Erase è stato aggiornato a System.Array.Clear. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
            System.Array.Clear(cccc, 0, cccc.Length)
            'UPGRADE_NOTE: Erase è stato aggiornato a System.Array.Clear. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
            System.Array.Clear(ch1ch1, 0, ch1ch1.Length)
            'UPGRADE_NOTE: Erase è stato aggiornato a System.Array.Clear. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
            System.Array.Clear(che, 0, che.Length)
        End With
        Exit Sub
        'ErrForma2: PRINT "Errore in HEADX4/FORMA2"; ERR; ERL: u$ = INPUT$(1): END
    End Sub

    Private Function SetScala() As Boolean
        Dim Archiv(1) As Short
        Dim dAiu(1) As String
        Scalb = 1 / 12
        SetScala = True
        Dom(1) = " Scala rappresentazione testata : 1/"
        Risp(1) = "  " & Str(Int(1 / Scalb + 0.5))
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.Chiamante. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        Monitor.Motore.Chiamante = Monitor
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.InputDati. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        If Not Monitor.Motore.InputDati(1, "Scala", Dom, Risp, "", Archiv, dAiu) Then
            SetScala = False : Exit Function
        End If
        If Val(Risp(1)) = 0 Then SetScala = False : Exit Function
        Scalb = 1.0! / Val(Risp(1))
    End Function

    Private Function SKIPPA1(ByRef nvo As Short) As String
        Dim j As Short
        Dim k As String
        nline = nline + nvo
        If nvo = 0 Then
            Debug.Print("Errore in Skippa1")
            Stop
        End If
        For j = 1 To nvo
            k = LineInput(ifl1)
        Next
        SKIPPA1 = k
    End Function
    Private Sub TABELL()
        Dim ifl, j As Short
        Dim Pass As Single
        Dim xtab As Single
        Dim PVERT As Single
        Dim i, M As Short
        Dim P3, p1, p2, p4 As Single
        Dim X(24) As Single
        Dim y(7) As Single
        Dim Z(72) As Single
        Dim yrel As Single, ymax As Single
        '      RESTORE 3939
        '3939:
        '     SEGMENTI SP .6  - DATI DI PROGETTO -
        'DATA Z  SUB TABELL
        'Data 695#, 246#, 875#, 246#, 695#, 236#, 875#, 236#, 695#, 246#, 695#
        'Data 176#, 750#, 236#, 750#, 176#, 805#, 236#, 805#, 176#, 840#, 226#
        'Data 840#, 176#
        '    SEGMENTI SP .6  - TUBI -
        'Data 695#, 306#, 875#, 306#, 695#, 296#, 875#, 296#
        'Data 695#, 251#, 875#, 251#, 695#, 306#, 695#, 251#
        'Data 750#, 296#, 750#, 266#, 805#, 266#, 805#, 296#
        'Data 830#, 281#, 830#, 251#
        '     SEGMENTI SP .6  - SPECIFICHE -
        'Data 695#, 361#, 875#, 361#, 695#, 351#, 875#, 351#
        'Data 695#, 311#, 875#, 311#, 695#, 361#, 695#, 311#
        'Data 750#, 351#, 750#, 311#
        '      DATA X
        'Data 697#, 707#, 741.5, 776.5, 797.5, 831.2, 842#, 698#, 706#
        'Data 792#, 698#, 752#, 698#, 753#, 808#, 698#, 753#, 808#, 705#, 740#
        'Data 775#, 796#, 830#, 840#
        '      DATA Y
        'Data 621#, 619#, 611.5, 367.5, 347.5, 292.5, 232.5
        ifl = FreeFile()
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.Inizio. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        FileOpen(ifl, CStr(Monitor.Motore.Inizio.Archdir + "\TABELL.DAT"), OpenMode.Input, , OpenShare.Shared)
1250:   For j = 1 To 72 : Input(ifl, Z(j)) : Next
        For j = 1 To 24 : Input(ifl, X(j)) : Next
        For j = 1 To 7 : Input(ifl, y(j)) : Next
        FileClose(ifl)
        '     COSTRUZIONE DEGLI ARCHI RAFFIGURANTI IL PASSO
        With Monitor.routines
1251:       'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.refabs. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .refabs()
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.refere. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .refere(-281, -105, 0)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.ctrait. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .ctrait(0, 0.5)
1254:       'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.poynt. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            p1 = .poynt(842.7, 263.0!)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.poynt. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            p2 = .poynt(854.3, 263.0!)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.poynt. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            P3 = .poynt(848.5, 273.0!)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.poynt. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            p4 = .poynt(842.7, 273.0!)
1255:       'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.cerc. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .cerc(842.7, 263.0!, 2.0!)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.cerc. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .cerc(854.3, 263.0!, 2.0!)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.cerc. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .cerc(848.5, 273.0!, 2.0!)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.ctrait. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .ctrait(0, 0.1)
            Call .seg1(p1, p2)
            Call .seg1(p2, P3)
            Call .seg1(P3, p1)
1257:       Pass = Val(CH7(4, 4)) : PVERT = Val(CH7(5, 4))
            Call .ql1(p4, p1, 2, -6, Globalroutines.mystr(PVERT, 3, 2, 0))
            Call .ql1(p1, p2, 1, -8, Globalroutines.mystr(Pass, 3, 2, 0))
            '     COSTRUZIONE DEI TESTI
            GoTo finemat
1260:       For i = 1 To 2
                'DO 20
                For j = 1 To 7
                    If (ch1(i, j) = "                   ") Then GoTo 20
                    Call .ECRIR(ch1(i, j))
                    If (j = 4 Or j = 5 Or j = 7) Then
                        Call .texte0(X(j), y(1) - (i - 1) * 4.0!, 0.0!, 2.0!, 0.2)
                    Else
                        Call .texte0(X(j), y(2), 0.0!, 2.0!, 0.2)
                    End If
20:             Next  'CONTINUE
            Next  'CONTINUE
2210:
            For i = 1 To n1
                For j = 1 To 7
                    If (j = 7) Then
                        Call .ctrait(0, 0.2)
                        For M = 1 To 19
                            If (Mid(CH2(i, 7), M, 2) <> "??") Then GoTo 35
                            Mid(CH2(i, 7), M, 2) = "  "
                            Call .refere(X(7) + 1.75 * (M - 1), y(3) - (i - 1) * 5.0!, 0)
                            Call .segm(0.0!, 0.45, 2.0!, 0.45)
                            Call .segm(0.0!, 1.55, 2.0!, 1.55)
                            Call .segm(0.45, 0.0!, 0.45, 2.0!)
                            Call .segm(1.55, 0.0!, 1.55, 2.0!)
                            Call .refabs()
35:                     Next  'CONTINUE
                    End If
                    If (CH2(i, j) = "                   ") Then GoTo 40
                    Call .ECRIR(CH2(i, j))
                    Call .texte0(X(j), y(3) - (i - 1) * 5.0!, 0.0!, 2.0!, 0.2)
40:             Next  'CONTINUE
            Next  'CONTINUE
            Call .refere(-281, -105, 0)
            If (CH3 <> "                                            ") Then
                Call .ECRIR(CH3)
                Call .texte0(705.0!, 385.5 + n2 * 5.0!, 0.0!, 3.0!, 0.2)
            End If
            Call .ECRIR(CH4(1))
            Call .texte0(705.0!, 369.0! + n2 * 5.0!, 0.0!, 4.0!, 0.4)
            For i = 1 To n2
                For j = 1 To 3
                    If (CH5(i, j) = "                   ") Then GoTo 60
                    Call .ECRIR(CH5(i, j))
                    If (j = 1) Then
                        Call .texte0(X(j + 7), y(4) + (n2 - 1) * 5.0! - (i - 1) * 5.0! - 2.5, 0.0!, 2.0!, 0.2)
                    Else
                        Call .texte0(X(j + 7), y(4) + (n2 - 1) * 5.0! - (i - 1) * 5.0!, 0.0!, 2.0!, 0.2)
                    End If
60:             Next  'CONTINUE
            Next  'CONTINUE
            Call .ECRIR(CH4(2)) 'specifiche  specificatio (vedere perche' manca NS)
            Call .texte0(705.0!, 354.0!, 0.0!, 4.0!, 0.4)
finemat:
            Call .refabs()
            Call .refere(-281, -105, 0)
            GoTo finemat1
            For i = 1 To 8
                For j = 1 To 2
                    If (CH6(i, j) = "                   ") Then GoTo 80
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.ECRIR. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .ECRIR(CH6(i, j))
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.texte0. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .texte0(X(j + 10), y(5) - (i - 1) * 5.0!, 0.0!, 2.0!, 0.2)
80:             Next
            Next
finemat1:
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.ECRIR. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .ECRIR("  MATERIALI/SPECIF. - MATERIALS/SPECIF. !")
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.texte0. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .texte0(705.0!, 344.0!, 0.0!, 4.0!, 0.4) '-25
            '------------------------------------------------------
            xtab = 696.0!
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.ECRIR. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .ECRIR(" LAMIERE  (PLATES) !")
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.texte0. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .texte0(xtab, 337.0!, 0.0!, 2.0!, 0.2)
            Call CercaMat(1)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.texte0. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .texte0(xtab + 35.0!, 337.0!, 0.0!, 2.0!, 0.2)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.ECRIR. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .ECRIR(" TUBI     (PIPES)  !")
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.texte0. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .texte0(xtab, 332.0!, 0.0!, 2.0!, 0.2)
            Call CercaMat(12)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.texte0. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .texte0(xtab + 35.0!, 332.0!, 0.0!, 2.0!, 0.2)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.ECRIR. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .ECRIR(" FLANGE   (FLANGES) !")
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.texte0. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .texte0(xtab, 327.0!, 0.0!, 2.0!, 0.2)
            Call CercaMat(13)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.texte0. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .texte0(xtab + 35.0!, 327.0!, 0.0!, 2.0!, 0.2)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.ECRIR. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .ECRIR(" ATTACCHI (COUPLINGS) !")
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.texte0. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .texte0(xtab, 322.0!, 0.0!, 2.0!, 0.2)
            Call CercaMat(16) '17 18 19
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.texte0. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .texte0(xtab + 35.0!, 322.0!, 0.0!, 2.0!, 0.2)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.ECRIR. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .ECRIR(" GUARN.FL (FL.GASKET) !")
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.texte0. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .texte0(xtab, 317.0!, 0.0!, 2.0!, 0.2)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.ECRIR. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .ECRIR(" GUARN.TP (PLUG.GSKT) !")
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.texte0. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .texte0(xtab, 312.0!, 0.0!, 2.0!, 0.2)
            Call CercaMat(4)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.texte0. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .texte0(xtab + 35.0!, 312.0!, 0.0!, 2.0!, 0.2)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.ECRIR. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .ECRIR(" GUAR.COP (COVER.GSK) !")
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.texte0. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .texte0(xtab, 307.0!, 0.0!, 2.0!, 0.2)
            xtab = 786.0!
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.ECRIR. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .ECRIR(" BUL.DADI (BLTS/NUTS) !")
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.texte0. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .texte0(xtab, 337.0!, 0.0!, 2.0!, 0.2)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.ECRIR. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .ECRIR(" TAPPI    (PLUGS) !")
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.texte0. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .texte0(xtab, 332.0!, 0.0!, 2.0!, 0.2)
            Call CercaMat(5)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.texte0. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .texte0(xtab + 35.0!, 332.0!, 0.0!, 2.0!, 0.2)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.ECRIR. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .ECRIR(" FIN.FLNG (FL.FINISH) !")
            Call .texte0(xtab, 327.0!, 0.0!, 2.0!, 0.2)
            Call .ECRIR(" DESIGN CODE          !")
            Call .texte0(xtab, 322.0!, 0.0!, 2.0!, 0.2)
            Call .ECRIR(CH6(2, 2).PadRight(30))
            Call .texte0(xtab + 35.0!, 322.0!, 0.0!, 2.0!, 0.2)
            Call .ECRIR(" CONSTRUCTION CODE    !")
            Call .texte0(xtab, 317.0!, 0.0!, 2.0!, 0.2)
            Call .ECRIR(CH6(8, 2).PadRight(30))
            Call .texte0(xtab + 35.0!, 317.0!, 0.0!, 2.0!, 0.2)
            Call .ECRIR(" TUBE/T.S. JOINT      !")
            Call .texte0(xtab, 312.0!, 0.0!, 2.0!, 0.2)
            Call .ECRIR(CH6(9, 2).PadRight(30))
            Call .texte0(xtab + 35.0!, 312.0!, 0.0!, 2.0!, 0.2)
            '------------------------------
            Call .ECRIR(CH4(3)) 'TUBI - TUBES
            Call .texte0(705.0!, 299.0!, 0.0!, 4.0!, 0.4)
            'DO 90
            For i = 1 To 9
                'DO 100
                For j = 1 To 3
                    If (CH7(i, j) = "                   ") Then GoTo 109
                    Call .ECRIR(CH7(i, j))
                    Call .texte0(X(j + 12), y(6) - (i - 1) * 5.0!, 0.0!, 2.0!, 0.2)
109:            Next  'CONTINUE
            Next  'CONTINUE
            Call .ECRIR(CH4(4)) 'DATI DI PROGETTO
            Call .texte0(705.0!, 239.0!, 0.0!, 4.0!, 0.4)
            'DO 110
            For i = 1 To 12
                'DO 120
                For j = 1 To 3
                    If (CH8(i, j) = "                   ") Then GoTo 120
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.ECRIR. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .ECRIR(CH8(i, j))
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.texte0. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .texte0(X(j + 15), y(7) - (i - 1) * 5.0!, 0.0!, 2.0!, 0.2)
120:            Next  'CONTINUE
            Next  'CONTINUE
            '     COSTRUZIONE DEI SEGMENTI
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.ctrait. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .ctrait(0, 0.6)
            For i = 1 To 52 Step 4 'era 72 STEP 4
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .segm(Z(i), Z(i + 1), Z(i + 2), Z(i + 3))
            Next
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .segm(695.0!, 341.0!, 875.0!, 341.0!)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .segm(695.0!, 351.0!, 875.0!, 351.0!)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .segm(695.0!, 351.0!, 695.0!, 307.0!)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .segm(695.0! + 35.0!, 341.0!, 695.0! + 35.0!, 307.0!)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .segm(695.0! + 35.0! + 55.0!, 341.0!, 695.0! + 35.0! + 55.0!, 307.0!)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .segm(695.0! + 35.0! + 55.0! + 35.0!, 341.0!, 695.0! + 35.0! + 55.0! + 35.0!, 307.0!)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.ctrait. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .ctrait(0, 0.2)
            '     SEGMENTI MATERIALI PRINCIPALI
            For i = 0 To 6
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.poynt. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                p1 = .poynt(695.0!, i * 5.0! + 311.0!) '-25
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.seg2. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .seg2(p1, 180.0!, 0.0!)
            Next
            '     SEGMENTI SP .2  - DATI DI PROGETTO -
            For i = 0 To 10
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.poynt. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                p1 = .poynt(695.0!, i * 5.0! + 181.0!)
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.seg2. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .seg2(p1, 180.0!, 0.0!)
            Next
            '     SEGMENTI SP .2  - TUBI -
            For i = 0 To 7
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.poynt. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                p1 = .poynt(695.0!, i * 5.0! + 256.0!)
                If (i < 5) Then
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.seg2. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .seg2(p1, 135.0!, 0.0!)
                Else
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.seg2. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .seg2(p1, 180.0!, 0.0!)
                End If
            Next
            '     SEGMENTI SP .2   - SPECIFICHE
            GoTo 2211
            'DO 160
            For i = 0 To 6
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.poynt. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                p1 = .poynt(875.0!, i * 5.0! + 316.0!)
                If (i = 1 Or i = 4) Then
                    Call .seg2(p1, -125.0!, 0.0!)
                Else
                    Call .seg2(p1, -180.0!, 0.0!)
                End If
            Next  'CONTINUE
            '     COSTRUZIONE DEI SEGMENTI  - NOTE GENERALI -
            Call .ctrait(0, 0.6)
            Call .segm(695.0!, 366.0!, 875.0!, 366.0!)
            Call .segm(695.0!, 366.0! + n2 * 5.0!, 875.0!, 366.0! + n2 * 5.0!)
            Call .segm(695.0!, 376.0! + n2 * 5.0!, 875.0!, 376.0! + n2 * 5.0!)
            Call .segm(695.0!, 376.0! + n2 * 5.0!, 695.0!, 366.0!)
            Call .segm(705.0!, 366.0! + n2 * 5.0!, 705.0!, 366.0!)
            Call .segm(790.0!, 376.0! + n2 * 5.0!, 790.0!, 366.0!)
            Call .ctrait(0, 0.2)
            'DO 170
            For i = 0 To n2 / 2 - 1
                p1 = .poynt(705.0!, 371.0! + i * 10.0!)
                Call .seg2(p1, 170.0!, 0.0!)
            Next  'CONTINUE
            'DO 180
            For i = 0 To n2 / 2 - 2
                p1 = .poynt(695.0!, 376.0! + i * 10.0!)
                Call .seg2(p1, 180.0!, 0.0!)
            Next  'CONTINUE
            '     SEGMENTI DELLA LISTA MATERIALI
            '2211      CALL ctrait(0, .6)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.refere. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .refere(0, -90, 0)
            ymax = 420.0! 'era 625
            Call .segm(695.0!, 380.0! + n2 * 5.0!, 695.0!, ymax)
            Call .ctrait(0, 0.2)
            Call .segm(695.0!, 380.0! + n2 * 5.0!, 875.0!, 380.0! + n2 * 5.0!)
            Call .ctrait(0, 0.2)
            If (Mid(CH3, 1, 35) = "                                   ") Then
                yrel = 380.0! + n2 * 5.0!
            Else
                yrel = 395.0! + n2 * 5.0!
                Call .segm(695.0!, yrel, 875.0!, yrel)
            End If
            'DO 190
            For i = 19 To 24
                Call .segm(X(i), yrel, X(i), ymax)
            Next  'CONTINUE
            Do
                Call .ctrait(0, 0.2)
                yrel = yrel + 5.0!
                Call .segm(695.0!, yrel, 875.0!, yrel)
                '        IF (YREL < 615!) THEN EXIT DO 'GOTO 200
                If (yrel > ymax) Then Exit Do 'GOTO 200
                '     PARTE FINALE
            Loop
2211:       'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.refabs. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .refabs()
        End With
        '      CALL refabs
        Exit Sub
        'ErrTab:
        'PRINT "Errore TABELL "; ERR; ERL: u$ = INPUT$(1)
        'Resume Next
    End Sub

    Private Sub Blocco(ByRef iora As Short, ByRef A As String, ByRef kasci As Short, ByRef now1 As String, ByRef npar As Short, ByRef nvir As Short)
        Dim nospace, nprimo As Short
        Dim j, kdopo, kp As Short
        nospace = NonUguale(iora, 32, 46, A, now1)
        nprimo = iora
        npar = 0 : nvir = 0
        If Asc(now1) <> 40 And Asc(now1) <> 44 Then
            kdopo = Uguale(nospace, 40, 40, A, now1)
        End If
        If kdopo - nprimo > 2 Then
            For j = kdopo To nprimo Step -1
                If Mid(A, j, 1) = "," Then
                    kasci = j
                    nvir = 1
                    now1 = Mid(A, nprimo, kasci - nprimo + 1)
                    Exit Sub
                End If
            Next
        Else
            If Asc(Mid(A, nprimo, 1)) = 47 Then
                kasci = nprimo : now1 = "/" : Exit Sub
            End If
        End If
        If Asc(now1) = 40 Then
            kp = 1 : npar = 1
111:        kdopo = Uguale(nospace, 40, 41, A, now1)
            If Asc(now1) = 40 Then kp = kp + 1 : npar = npar + 1 : GoTo 111
            If Asc(now1) = 41 Then kp = kp - 1
            If kp <> 0 Then GoTo 111
            now1 = Mid(A, nprimo, kdopo - nprimo + 1)
            kasci = kdopo
            Exit Sub
        End If
        If Asc(now1) = 44 Then 'virgola
            nvir = 1
            now1 = Mid(A, nprimo, kdopo - nprimo)
            kasci = kdopo
            Exit Sub
        End If
        kasci = Len(A)
        now1 = Mid(A, nprimo, kasci - nprimo + 1) & ","
    End Sub

    Private Sub DEFINE(ByRef KODICE As Short)
        '      On Local Error GoTo ErrDefine
        Dim j, i, n As Short
        Dim Dum As Single
        Dim nPassi, l As Short
        Dim foro(200, 3) As Single
        Dim NForo As Short
        Dim w As Single
        '
        '    AZZERAMENTO ARRAY FORO
        '
        For i = 1 To 200 : For j = 1 To 3
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto foro(i, j). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                foro(i, j) = 0.0! : Next : Next
        '
        '    CALCOLO MEZZERIA CASSA
        '
420:    e(1) = 0.0!
        For i = 1 To 14
            e(1) = Max(e(1), (Ntubi(i, 1) - 1) * EA(i, 5) + Ntubi(i, 2) * EA(i, 6) + Ntubi(i, 3) * EA(i, 7) + EA(i, 2))
        Next
        e(1) = e(1) / 2.0!
        '
        '    CALCOLO QUOTE SCHIZZO  "1"  RIFERITE ALLA CASSA 1
        '
        For n = 1 To Nfile - 1
            If (EA(n + 1, 3) > e(14) - 2 * e(26)) Then Exit For
        Next
        'e(14):altz cassa 1;e(26) sp top
        N8 = n
        'e(15) = meta' eccedenza altezza cassa/ingombro file
        Dum = (e(14) - 2 * e(26) - EA(n, 3)) / 2.0!
        If Dum > e(15) Then e(15) = Dum
        If e(701) > 0 Then e(15) = e(701)
        'EA: 1 Dia;2 X;3 Y1; 4 Y2; 5 passo
        '    CALCOLO QUOTE SCHIZZO  "1"  RIFERITE ALLA CASSA 2
        '
        If (n <> Nfile) Then
            If (e(17) = 0.0!) Then e(17) = (e(16) - 2 * e(27) - EA(Nfile, 3) + EA(n + 1, 3)) / 2.0!
        End If
        '
        '    CALCOLO QUOTE SCHIZZO  "1"  RIFERITE ALLA CASSA 3
        '
430:    For n = 1 To Nfile - 1
            If (EA(n + 1, 4) > e(18) - 2 * e(28)) Then Exit For
        Next
        N9 = n
        If (e(19) = 0.0!) Then e(19) = (e(18) - 2 * e(28) - EA(n, 4)) / 2.0!
        '
        '    CALCOLO QUOTE SCHIZZO  "1"  RIFERITE ALLA CASSA 4
        '
        If (n <> Nfile) Then
            If (e(21) = 0.0!) Then e(21) = (e(20) - 2 * e(29) - EA(Nfile, 4) + EA(n + 1, 4)) / 2.0!
        End If
        '
        '    CALCOLO QUOTE SCHIZZO  "3"
        '
        '      IF iTipo = 3 OR iTipo = 4 THEN n2 = 1 ELSE n2 = 2
        e(400) = Max(e(10) - 2 * e(22), e(11) - 2 * e(23)) / 2.0!
        e(401) = Max(e(12) - 2 * e(24), e(13) - 2 * e(25)) / 2.0!
        e(402) = e(400) - (e(10) - 2 * e(22)) / 2.0! 'cassa 1
        e(403) = e(400) - (e(11) - 2 * e(23)) / 2.0! 'cassa 2
        e(404) = -(e(401) - (e(12) - 2 * e(24)) / 2.0!) 'cassa 3
        e(405) = -(e(401) - (e(13) - 2 * e(25)) / 2.0!) 'cassa 4
        '
        '    SE NON ESEGUE TELAIO FINISCE LA PARTE DI CALCOLO
        '
        If (KODICE <> 2) Then GoTo 9000
        '
        '    CALCOLO DIMENSIONI FIANCATA TELAIO
        '
440:    e(406) = Int((e(100) - e(400) - Max(e(22), e(23)) - e(401) - Max(e(24), e(25)) - 2 * e(215)) / 10.0!) * 10.0!
        e(407) = (e(100) - e(406) - e(400) - e(401) - Max(e(22), e(23)) - Max(e(24), e(25))) / 2.0!
        e(408) = Max(e(22), e(23)) + e(407)
        e(409) = Max(e(24), e(25)) + e(407)
        e(410) = e(151) + 2 * (e(216) - 2 * e(152))
        e(411) = (e(410) - e(151)) / 2.0!
        '
        '    CALCOLO COORDINATE FORI TRAVI SUPPORTO TUBI    ( DIS 4 )
        '
        e(412) = e(411) + e(101) + e(26) + e(15)
        e(413) = e(411) + e(102) + e(28) + e(19) - e(412)
        e(417) = e(408) - e(22) + e(406) + e(409) - e(24)
        e(414) = System.Math.Sqrt(e(417) ^ 2 + e(413) ^ 2)
        e(415) = e(153) + e(218) - e(217) - e(22)
        e(416) = EA(1, 5) / 2.0!
        If (e(224) <> 0.0!) Then e(416) = e(224) / 2.0!
445:    For i = 0 To N7
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto foro(i * 4 + 1, 1). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            foro(i * 4 + 1, 1) = -e(408) + e(22) + (e(415) + e(154) * i) * e(417) / e(414) + (e(416) + e(219) + e(220)) * e(413) / e(414) - e(221) * e(417) / e(414)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto foro(i * 4 + 1, 2). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            foro(i * 4 + 1, 2) = e(412) + (e(415) + e(154) * i) * e(413) / e(414) - (e(416) + e(219) + e(220)) * e(417) / e(414) - e(221) * e(413) / e(414)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto foro(i * 4 + 1, 3). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            foro(i * 4 + 1, 3) = e(200)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto foro(i * 4 + 2, 1). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            foro(i * 4 + 2, 1) = -e(408) + e(22) + (e(415) + e(154) * i) * e(417) / e(414) + (e(416) + e(219) + e(220)) * e(413) / e(414) + e(221) * e(417) / e(414)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto foro(i * 4 + 2, 2). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            foro(i * 4 + 2, 2) = e(412) + (e(415) + e(154) * i) * e(413) / e(414) - (e(416) + e(219) + e(220)) * e(417) / e(414) + e(221) * e(413) / e(414)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto foro(i * 4 + 2, 3). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            foro(i * 4 + 2, 3) = e(200)
        Next
        '
        '    CALCOLO POSIZIONE ORECCHIE
        '
        If (ch13(5) = "     SALDATE") Then
            e(418) = e(157) + e(233) + e(227)
            e(419) = e(157) - e(233) - e(227)
            e(420) = e(419)
            e(421) = e(418)
        End If
447:    If (e(234) <> 0.0!) Then e(418) = e(234)
        If (e(235) <> 0.0!) Then e(419) = e(235)
        If (e(236) <> 0.0!) Then e(420) = e(236)
        If (e(237) <> 0.0!) Then e(421) = e(237)
        '
        '    CALCOLO POSIZIONE COLONNA SX
        '
        e(422) = e(155) - e(400) - e(408)
        '
        '    CALCOLO COORDINATE FORI ATTACCO TUBE KEEPS     ( DIS 5 )
        '
        e(423) = e(411) + e(101) + e(26) + e(15) + EA(Nfile, 3)
        e(424) = e(411) + e(102) + e(28) + e(19) + EA(Nfile, 4) - e(423)
        If (e(23) = 0.0!) Then
            e(425) = e(22)
        Else
            e(425) = e(23)
        End If
        If (e(25) = 0.0!) Then
            e(426) = e(24)
        Else
            e(426) = e(25)
        End If
        e(427) = e(408) + e(406) + e(409) - e(425) - e(426)
        e(428) = System.Math.Sqrt(e(427) ^ 2 + e(424) ^ 2)
        e(429) = e(153) + e(218) - e(217) - e(425)
        e(430) = EA(Nfile, 5) / 2.0!
        If (e(238) <> 0.0!) Then e(430) = e(238) / 2.0!
        For i = 0 To N7
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto foro(i * 4 + 41, 1). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            foro(i * 4 + 41, 1) = -e(408) + e(425) + (e(429) + e(154) * i) * e(427) / e(428) - (e(430) + e(239)) * e(424) / e(428) - e(241) * e(427) / e(428)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto foro(i * 4 + 41, 2). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            foro(i * 4 + 41, 2) = e(423) + (e(429) + e(154) * i) * e(424) / e(428) + (e(430) + e(239)) * e(427) / e(428) - e(241) * e(424) / e(428)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto foro(i * 4 + 41, 3). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            foro(i * 4 + 41, 3) = e(201)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto foro(i * 4 + 42, 1). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            foro(i * 4 + 42, 1) = -e(408) + e(425) + (e(429) + e(154) * i) * e(427) / e(428) - (e(430) + e(239)) * e(424) / e(428) + e(241) * e(427) / e(428)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto foro(i * 4 + 42, 2). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            foro(i * 4 + 42, 2) = e(423) + (e(429) + e(154) * i) * e(424) / e(428) + (e(430) + e(239)) * e(427) / e(428) + e(241) * e(424) / e(428)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto foro(i * 4 + 42, 3). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            foro(i * 4 + 42, 3) = e(201)
        Next
        '
        '    CALCOLO QUOTE APERTURA FIANCATE
        '
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto foro(2, 1). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto foro(). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        e(431) = (foro(1, 1) + foro(2, 1)) / 2.0!
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto foro(N7 * 4 + 2, 1). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto foro(). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        e(432) = (foro(N7 * 4 + 1, 1) + foro(N7 * 4 + 2, 1)) / 2.0!
        '     E(433) = LARGHEZZA ALA TRAVE SUPPORTO TUBI - VEDI T1
        '     E(434) = ALTEZZA       TRAVE SUPPORTO TUBI - VEDI T1
        '
        '    FORATURA ATTACCO PANNELLI E COLONNE
        '
448:    e(435) = e(156) / (N6 - 1)
        nPassi = (e(435) - 420.0!) / 540.1 + 1
        e(436) = Int((e(435) - 421.0! + e(248)) / (nPassi * 5)) * 5.0!
        e(437) = (e(435) - e(436) * nPassi - e(248) * 2.0!) / 2.0!
        e(438) = e(216) - e(152) - e(249)
        '
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto foro(81, 1). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        foro(81, 1) = e(422) - e(248)
        NForo = 81
        '
        For i = 1 To N6 - 1
            NForo = NForo + 1
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto foro(NForo, 1). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            foro(NForo, 1) = e(422) + (i - 1) * e(435) + e(248)
            If (ch13(6) = "     FORZATA" And ch13(7) = "          NO") Then
                For j = 1 To nPassi + 1
                    NForo = NForo + 1
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto foro(NForo, 1). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    foro(NForo, 1) = e(422) + (i - 1) * e(435) + e(248) + e(437) + (j - 1) * e(436)
450:            Next
            End If
            NForo = NForo + 1
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto foro(NForo, 1). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            foro(NForo, 1) = e(422) + i * e(435) - e(248)
400:    Next
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto foro(NForo + 1, 1). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        foro(NForo + 1, 1) = e(422) + e(156) + e(248)
        '
        '    DECIDE SE ADOTTARE ASOLA O FORO
        For i = 81 To 120
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto foro(i, 1). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            If (foro(i, 1) = 0.0!) Then GoTo 500
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto foro(i, 2). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            foro(i, 2) = e(438)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto foro(N7 * 4 + 2, 1). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto foro(i, 1). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto foro(1, 1). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            If (foro(i, 1) < foro(1, 1) Or foro(i, 1) > foro(N7 * 4 + 2, 1)) Then
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto foro(i, 3). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                foro(i, 3) = e(205)
            Else
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto foro(i, 3). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                foro(i, 3) = e(204)
            End If
500:    Next
        '
        '    FORATURA ALA SUPERIORE TELAIO
        '
        j = 151
        w = -e(400) - e(408)
        For i = 1 To 10
            If (N10(1, i) = 0) Then GoTo 510
            For l = 1 To N10(1, i)
                w = w + EF(1, i)
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto foro(j, 1). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                foro(j, 1) = w
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto foro(j, 2). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                foro(j, 2) = e(410) - e(216) + e(294) + e(152)
                j = j + 1
                If (j > 200) Then GoTo 511
520:        Next
510:    Next
511:
        '    DECIDE SE ADOTTARE ASOLA O FORO
        For i = 151 To 200
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto foro(i, 1). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            If (foro(i, 1) = 0.0!) Then GoTo 530
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto foro(N7 * 4 + 2, 1). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto foro(i, 1). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto foro(1, 1). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            If (foro(i, 1) < foro(1, 1) Or foro(i, 1) > foro(N7 * 4 + 2, 1)) Then
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto foro(i, 3). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                foro(i, 3) = e(205)
            Else
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto foro(i, 3). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                foro(i, 3) = e(204)
            End If
530:    Next
        '
        '    ALTEZZA DEL SOPPORTO CASSA
        '
        For i = 0 To 1
            e(439 + i) = e(101 + i) - e(252) - e(251)
610:        If (e(439 + i) > e(253)) Then
                e(439 + i) = e(439 + i) - e(250)
                GoTo 610
            End If
600:    Next
        '
        '    POSIZIONE PRIMO FORO SULLE ASCISSE
        '
        e(441) = e(408) + (e(10) - 2 * e(22)) / 2.0!
        e(442) = e(409) + (e(12) - 2 * e(24)) / 2.0!
        For i = 0 To 1
            e(443 + i) = e(254) - e(441 + i)
651:        If (e(443 + i) < e(255)) Then
                e(443 + i) = e(443 + i) + 5.0!
                GoTo 651
            End If
            e(445 + i) = e(441 + i) + e(443 + i)
650:    Next
        '
        '    QUOTE SMUSSI
        '
        For i = 0 To 1
            e(447 + i) = e(101 + i) - e(252) - e(256) - e(257) - e(439 + i)
            e(449 + i) = e(258)
            If (e(101 + i) - e(252) - e(439 + i) = e(251)) Then e(449 + i) = e(256)
660:    Next
        '
        '    ALTEZZA SOPPORTO
        '
        For i = 0 To 1
            e(451 + i) = e(101 + i) - e(252) - e(439 + i)
670:    Next
        '
        '    COORDINATE FORI ATTACCO SOPPORTO CASSA LATO ENTRATA
        '
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto foro(121, 1). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        foro(121, 1) = e(443)
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto foro(121, 2). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        foro(121, 2) = e(439) + e(255) + e(411)
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto foro(125, 1). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        foro(125, 1) = e(443)
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto foro(125, 2). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        foro(125, 2) = e(439) + e(451) - e(255) + e(411)
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto foro(122, 1). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        foro(122, 1) = e(443) + e(259)
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto foro(122, 2). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        foro(122, 2) = e(439) + e(255) + e(411)
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto foro(126, 1). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        foro(126, 1) = e(443) + e(259)
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto foro(126, 2). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        foro(126, 2) = e(439) + e(451) - e(255) + e(411)
        If (e(451) - 2 * e(255) > e(261)) Then
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto foro(123, 1). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            foro(123, 1) = e(443)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto foro(123, 2). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            foro(123, 2) = e(439) + e(255) + (e(451) - 2 * e(255)) / 2.0! + e(411)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto foro(124, 1). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            foro(124, 1) = e(443) + e(259)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto foro(124, 2). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            foro(124, 2) = e(439) + e(255) + (e(451) - 2 * e(255)) / 2.0! + e(411)
        End If
        '
        '    COORDINATE FORI ATTACCO SOPPORTO CASSA LATO USCITA
        '
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto foro(132, 1). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        foro(132, 1) = e(406) - e(444)
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto foro(132, 2). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        foro(132, 2) = e(440) + e(255) + e(411)
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto foro(136, 1). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        foro(136, 1) = e(406) - e(444)
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto foro(136, 2). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        foro(136, 2) = e(440) + e(452) - e(255) + e(411)
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto foro(131, 1). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        foro(131, 1) = e(406) - e(444) - e(259)
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto foro(131, 2). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        foro(131, 2) = e(440) + e(255) + e(411)
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto foro(135, 1). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        foro(135, 1) = e(406) - e(444) - e(259)
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto foro(135, 2). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        foro(135, 2) = e(440) + e(452) - e(255) + e(411)
        If (e(452) - 2 * e(255) > e(261)) Then
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto foro(134, 1). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            foro(134, 1) = e(406) - e(443)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto foro(134, 2). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            foro(134, 2) = e(440) + e(255) + (e(452) - 2 * e(255)) / 2.0! + e(411)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto foro(133, 1). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            foro(133, 1) = e(406) - e(444) - e(259)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto foro(133, 2). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            foro(133, 2) = e(440) + e(255) + (e(452) - 2 * e(255)) / 2.0! + e(411)
        End If
        '
        '    DIAMETRO FORI PER SUPPORTI CASSE
        '
        For i = 121 To 140
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto foro(i, 3). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            foro(i, 3) = e(206)
700:    Next
        '
        '    POSIZIONE TRAVERSA INFERIORE
        '
        e(453) = e(422)
        e(454) = e(406) - e(422) - e(156)
        For i = 0 To 1
            e(455 + i) = (e(259) - e(262)) / 2.0!
            If (ch13(6) = "     FORZATA") Then
                If (e(453 + i) - e(443 + i) - e(455 + i) > e(291)) Then
                    e(455 + i) = e(259) - e(292) - e(262)
                End If
            End If
            e(457 + i) = e(439 + i) - e(263)
            e(459 + i) = e(457 + i) + e(451 + i)
            If (e(459 + i) > e(264)) Then e(459 + i) = e(264)
            e(461 + i) = e(443 + i) + e(455 + i) - e(274)
750:    Next
        '
        '    AER SEAL INFERIORE
        '
        For i = 0 To 1
            e(463 + i) = e(101 + i) + e(26 + i * 2) + e(15 + i * 4) - EA(1, 1) / 2.0! - e(275) - e(263) - e(265) + e(276)
            e(465 + i) = e(445 + i) + e(455 + i) - e(10 + i * 2) / 2.0! - e(274) - e(277)
            e(467 + i) = e(278)
801:        If (e(463 + i) - e(465 + i) * System.Math.Tan(e(467 + i) * 3.14159 / 180) - e(276) < e(279)) Then
                e(467 + i) = e(467 + i) - 5.0!
                GoTo 801
            End If
800:    Next
        '
        '    LUNGHEZZA TRAVERSA INFERIORE E AER SEAL
        '
        e(469) = e(431)
        e(470) = e(406) - e(432)
        For i = 0 To 1
            e(471 + i) = e(443 + i) + e(455 + i)
            e(473 + i) = e(150) + 2 * e(246 + i) - 2 * (e(246 + i) * e(471 + i) / e(469 + i) + e(267) + e(272))
            e(475 + i) = Int((e(473 + i) + 2 * e(272) - 2 * e(281)) / 2.0!)
810:    Next
        '
        '    PASSI FORATURA AER SEAL INFERIORE   ( VALIDA PER SUPERIORE
        '                                          SE LED(I+1) = 1      )
        For i = 0 To 1
            e(477 + i) = e(283)
            '     NUMERO DI PASSI E(479+I)
821:        e(479 + i) = Int((e(475 + i) - e(270) + e(281) - e(282)) / e(477 + i))
            e(481 + i) = e(475 + i) - e(270) + e(281) - e(282) - e(479 + i) * e(477 + i)
            If (e(481 + i) < e(477 + i) / 2.0!) Then
                e(477 + i) = e(477 + i) - 5.0!
                GoTo 821
            End If
820:    Next
        '
        '     QUOTA TRA SOPRA CASSA E SOMMITA' TELAIO
        '
        For i = 0 To 1
            If (i = 0) Then n = N8 + 1
            If (i = 1) Then n = N9 + 1
            '     ALTEZZA PACCO CASSE
            If (e(17 + i * 4) = 0.0!) Then
                w = e(14 + i * 4)
            Else
                w = e(26 + i * 2) + e(15 + i * 4) + EA(n, 3 + i) - e(17 + i * 4) - e(27 + i * 2) + e(16 + i * 4)
            End If
            e(483 + i) = e(151) - e(101 + i) - w
830:    Next
        '
        '     FERMO CASSA SUPERIORE
        '
        For i = 0 To 1
            If (e(11 + i * 2) = 0.0!) Then
                e(485 + i) = e(408 + i) + (e(10 + i * 2) - 2 * e(22 + i * 2)) / 2.0!
            Else
                e(485 + i) = e(408 + i) + (e(11 + i * 2) - 2 * e(23 + i * 2)) / 2.0!
            End If
            e(487 + i) = e(285) + e(485 + i) + e(443 + i) + e(259) + e(305)
            e(489 + i) = e(483 + i) - e(284) - e(288) - e(263)
            If (e(158 + i) = 0.0!) Then
                e(491 + i) = (e(259) - e(262)) / 2.0!
            Else
                ' E(491 + I) = E(158 + I) - E(485 + I) - E(443 + I) - E(263) - E(265) + E(274)
                e(491 + i) = e(158 + i) - e(485 + i) - e(443 + i) - e(303) + e(274)
            End If
840:    Next
        '
        '     COORDINATE FORI FERMO CASSA SUPERIORE
        '
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto foro(141, 1). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        foro(141, 1) = e(443)
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto foro(141, 2). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        foro(141, 2) = e(151) - e(483) + e(284) + e(289) + e(411)
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto foro(141, 3). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        foro(141, 3) = e(211)
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto foro(142, 1). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        foro(142, 1) = e(443) + e(259)
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto foro(142, 2). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        foro(142, 2) = e(151) - e(483) + e(284) + e(289) + e(411)
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto foro(142, 3). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        foro(142, 3) = e(211)
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto foro(143, 1). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        foro(143, 1) = e(406) - e(444) - e(259)
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto foro(143, 2). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        foro(143, 2) = e(151) - e(484) + e(284) + e(289) + e(411)
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto foro(143, 3). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        foro(143, 3) = e(211)
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto foro(144, 1). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        foro(144, 1) = e(406) - e(444)
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto foro(144, 2). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        foro(144, 2) = e(151) - e(484) + e(284) + e(289) + e(411)
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto foro(144, 3). Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        foro(144, 3) = e(211)
        '
        '     LUNGHEZZA ANGOLARE COLLEGAMENTO FIANCATE CORRISPONDENZA CASSE
        '
        For i = 0 To 1
            e(493 + i) = e(473 + i) + 2 * e(293)
850:    Next
        '
        '     CALCOLO LUNGHEZZE TRAVI SUPPORTO TUBI - DIAGONALE
        '
        e(495) = e(150) - e(223) * 2.0!
        e(496) = e(150) - e(244) * 2.0!
        e(497) = e(473) - e(271) * 2.0!
        e(498) = e(474) - e(271) * 2.0!
        w = 0.0!
        If (ch13(4) = "      IPE100") Then w = 4.0!
        If (ch13(4) = "      IPE120") Then w = 4.0!
        If (ch13(4) = "      IPE140") Then w = 5.0!
        If (ch13(4) = "      HEA100") Then w = 5.0!
        If (ch13(4) = "      HEA100") Then w = 5.0!
        If (w = 0.0!) Then w = 6.0!
        e(499) = e(154) - w
        e(500) = e(150) - 2.0! * (e(295) + e(296))
        e(501) = e(150) - 2.0! * e(295)
        e(502) = e(499) - 2.0! * e(299)
        e(503) = System.Math.Sqrt(e(502) ^ 2 + e(501) ^ 2) - e(300) * e(501) / e(502)
        '
        '     CALCOLO DIMENSIONI FERMI CASSA
        '
        For i = 0 To 1
            If (Mid(ch13(9 + i), 11, 2) = "SI") Then
                e(506 + i) = e(286)
            Else
                e(506 + i) = 0.0!
            End If
            e(508 + i) = e(487 + i) + e(506 + i)
            e(510 + i) = e(267) + e(272) + e(271) + e(265) - e(288)
860:    Next
        '     E(512) = PESO AL METRO LINEARE DELL'ANGOLARE DEL FERMO CASSA
        '
        '     PESO ANGOLARE COLLEGAMENTO FIANCATE
        '
        '     E(504) = PESO AL METRO LINEARE
        '
        '
        '     LUNGHEZZA ANGOLARE PER ATTACCO DIAGONALE
        '
        e(505) = 2 * e(302) + e(296)
        '
        '     AER SEAL SUPERIORE
        '
        For i = 0 To 1
            e(513 + i) = e(151) - e(101 + i) - e(26 + i * 2) - e(15 + i * 4) - EA(Nfile, 3 + i) - EA(Nfile, 1) / 2.0! - e(275) - e(263) - e(265) + e(276)
            If (e(23 + i * 2) = 0.0!) Then
                w = e(22 + i * 2)
            Else
                w = e(23 + i * 2)
            End If
            e(515 + i) = e(408 + i) + e(443 + i) + e(491 + i) - e(274) - e(277) - w
            e(517 + i) = e(309)
871:        If (e(513 + i) - e(515 + i) * System.Math.Tan(e(517 + i) * 3.14159 / 180) - e(276) < e(279)) Then
                e(517 + i) = e(517 + i) - 5.0!
                GoTo 871
            End If
            e(519 + i) = (e(513 + i) - e(276) + e(263) + e(265) - e(263) - e(489 + i)) / System.Math.Sin(e(517 + i) * 3.14159 / 180.0!) + e(312)
            e(521 + i) = Int((e(473 + i) + 2 * (e(272) + e(267)) - 2 * (e(287) + e(310))) / 2.0!)
            ' E(523 + I) = E(271) + E(272) + E(267) - E(287) - E(310) + E(311)
            e(523 + i) = e(521 + i) - e(481 + i) - e(479 + i) * e(477 + i) - e(282)
            e(525 + i) = Int((e(473 + i) + 2 * (e(272) + e(267)) - 2 * (e(288) + e(310))) / 2.0!)
870:    Next
        '
        '     PASSI FORATURA AER SEAL SUPERIORE CON LED(I+1) = 0
        '
        For i = 0 To 1
            e(529 + i) = e(314)
            '     NUMERO DI PASSI E(527+I)
881:        e(527 + i) = Int((e(525 + i) - e(313)) / e(529 + i))
            e(531 + i) = e(525 + i) - e(313) - e(527 + i) * e(529 + i)
            If (e(531 + i) < e(529 + i) / 3.0!) Then
                e(529 + i) = e(529 + i) - 5.0!
                GoTo 881
            End If
880:    Next
        '
        '     CALCOLO DELLE DIMENSIONI IN SCALA
        '
9000:   For i = 1 To MFILE : For j = 1 To 7
                AA(i, j) = EA(i, j) * Scalb
            Next : Next
9010:   For i = 1 To 700
            A(i) = e(i) * Scalb
        Next
9020:   For i = 1 To MTARGA : For j = 1 To 9
                AB(i, j) = EB(i, j) * Scalb
            Next : Next
9030:   For i = 1 To N4 : For j = 1 To 5
                AC(i, j) = EC(i, j) * Scalb
                If (j = 4) Then AC(i, j) = EC(i, j)
            Next : Next
9040:   For i = 1 To N5 : For j = 1 To 3
                AD(i, j) = ED(i, j) * Scalb
            Next : Next
        'UPGRADE_NOTE: Erase è stato aggiornato a System.Array.Clear. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
        System.Array.Clear(foro, 0, foro.Length)
        Exit Sub
        'ErrDefine: PRINT "Errore in HEADX5/DEFINE"; ERR; ERL: u$ = INPUT$(1): END
    End Sub

    Private Sub LaStringa(ByRef iora As Short, ByRef A As String, ByRef kasci As Short, ByRef now1 As String)
        Dim nprimo, nospace, kdopo As Short
        nospace = NonUguale(iora, 32, 32, A, now1)
        nprimo = iora
        If Asc(now1) > 46 Then 'era 47
            kdopo = Uguale(nospace, 40, 46, A, now1)
            now1 = Mid(A, nprimo, kdopo - nprimo)
        Else
            kdopo = NonUguale(iora, 32, 32, A, now1)
        End If
        kasci = kdopo
    End Sub

    Private Sub LEGFORM(ByRef St As String, ByRef B() As String, ByRef nq1 As Short, ByRef isez As Short)
        'On Local Error GoTo handl
        Dim A As String
        Dim kprima, kora, kdopo As Short
        Dim nq0, iPos As Short
        Dim now0, now1 As String
        Dim nvir, lst, npar, nmax As Short
        Dim j, ix, i1, il As Short
        Dim D As String
        Dim k1, nyy, ipo, idir As Short
        Dim l1, nyi, nxi, isk As Short
        Dim nx, kfine, kpoi, lora, ny As Short
        Dim iform(10, 50) As Short
        Dim ivolt(10) As Short
        Dim kfat(10) As Short
        Dim istrt(10) As Short
        A = LTrim(RTrim(Mid(St, 1, Len(St) - 1)))
        lst = Len(A) : kora = 1 : kprima = 1 : kdopo = 1 : nq0 = 0 : iPos = 1
        Do
701:        Blocco(kora, A, kdopo, now1, npar, nvir)
            kpoi = kdopo : kora = 0 : kfine = Len(now1)
            now0 = now1 : lora = Len(now0) : nx = 0 : ny = 0
703:        'Erase iform, ivolt, kfat, istrt
            ReDim iform(10, 100)
            ReDim ivolt(10)
            ReDim kfat(10)
            ReDim istrt(10)
            nmax = 0
            Do
                LaStringa(kora, now0, kdopo, now1)
                ix = InStr(now1, "X") : il = 0
705:            For j = 1 To Len(now1)
                    If Mid(now1, j, 1) = "/" Then il = il + 1
                Next
                i1 = Val(now1)
                If i1 = 0 Then
707:                i1 = Int(Val(Mid(now1, 2)))
                End If
                D = Mid(now0, kdopo, 1) ': IF ASC(d$) > 47 THEN d$ = "S": kdopo = kdopo - 1
                Select Case D
                    Case "(" : ny = ny + 1 : istrt(ny) = nx + 1 : If i1 = 0 Then i1 = 1
                        ivolt(ny) = i1 : nyy = ny
                    Case ")", "," : ipo = 0 : If ix Then ipo = 200
708:                    If D = "," And npar = 0 Then ny = 1 : istrt(ny) = 1 : ivolt(ny) = 1 : nyy = 1
                        If i1 Then nx = nx + 1 : nmax = nx : iform(ny, nx) = ipo + i1
                        For j = 1 To il : nx = nx + 1 : nmax = nx : iform(ny, nx) = 999 : Next
                        If D = ")" Then ny = ny - 1
                    Case "/"
                        ny = ny + 1 : nx = 1 : istrt(ny) = nx : If i1 = 0 Then i1 = 1
709:                    ivolt(ny) = i1 : nyy = ny : nmax = 1
                        iform(ny, nx) = 999
                End Select
                kora = kdopo
            Loop While kora < lora
            nyi = 1 : nxi = 1 : k1 = ivolt(nyi) : idir = 1
            Do
                l1 = iform(nyi, nxi)
710:            If l1 = 0 Then
                    If nyi = 1 Then
                        If nxi > nmax Then
                            kfat(nyi) = kfat(nyi) + 1
                            If kfat(nyi) < ivolt(nyi) Then nxi = 0
                        Else
                            idir = 1 : nyi = nyi + 1 : k1 = ivolt(nyi)
                            kfat(nyi) = 0 : nxi = nxi - 1
                        End If
                    Else
711:                    If nyi >= nyy Then
                            kfat(nyi) = kfat(nyi) + 1
                            If kfat(nyi) = ivolt(nyi) Then
                                idir = -1 : nyi = nyi - 1 : nxi = nxi - 1
                            Else
                                nxi = istrt(nyi) - 1
                            End If
                        End If
                    End If
                End If
712:            Select Case l1
                    Case 999
714:                    If npar = 1 And nmax = 1 Then isk = k1 : kfat(nyi) = k1 Else isk = 1
715:                    Form = SKIPPA1(isk) : iPos = 1

716:                Case Is > 200 : iPos = iPos + l1 - 200
717:                Case Is > 0 : nq0 = nq0 + 1 : B(nq0) = Mid(Form, iPos, l1)
                        '718                           PRINT #IFL2, nq0; b$(nq0); " "; ipos; L1
719:                    iPos = iPos + l1
                End Select
444:            nxi = nxi + 1
            Loop Until kfat(1) >= ivolt(1)
            kora = kpoi
        Loop Until kpoi >= lst
        Exit Sub
handl:
        Debug.Print("LEGFORM" & Err.Number & Erl()) : Stop
        Resume Next
    End Sub

    Private Function NonUguale(ByRef iora As Short, ByRef ibas As Short, ByRef Ialt As Short, ByRef l As String, ByRef now1 As String) As Short
        Dim k As Short
        If iora >= Len(l) Then
            iora = Len(l)
            now1 = Right(l, 1)
            NonUguale = iora : Exit Function
        End If
        Do
            iora = iora + 1 : now1 = Mid(l, iora, 1) : k = Asc(now1)
        Loop While k >= ibas And k <= Ialt And iora < Len(l)
        NonUguale = iora
    End Function

    Private Sub sez01()
        Dim A1000 As String
        Dim i As Short
        A1000 = "(12X,A60,14X,A2/,2(12X,A60/),2(A7,1X,A12,3X,A15,1X,A13,3X,A10,1X,A5/),6(A31,10X,A11,1X,A14/))"
        Form = SKIPPA1(6)
        LEGFORM(A1000, inn, 34, 1)
        ch10(1) = inn(1)
        iTipo = Val(inn(2))
        For i = 2 To 33
            ch10(i) = inn(i + 1)
        Next
    End Sub

    Private Sub sez02()
        Dim A1001 As String
        Dim i As Short
        Dim CH As String
        Dim j As Short
        Form = SKIPPA1(8)
        Nfile = 0
        A1001 = "(1X,A6,2X,F7.3,2X,F7.3,2(4X,F7.3),6X,I3,5X,F7.3, 2(7X,I3,5X,F7.3),5X,A1)"
100:    i = Nfile + 1
        Form = SKIPPA1(1)
        LEGFORM(A1001, inn, 11, 2)
        'CH,(EA(I,J),J=1,4),NTUBI(I,1),EA(I,5),NTUBI(I,2),EA(I,6),NTUBI(I,3),EA(I,7)
        CH = inn(1) : For j = 1 To 4 : EA(i, j) = Val(inn(j + 1)) : Next
        Ntubi(i, 1) = Val(inn(6)) : EA(i, 5) = Val(inn(7)) : Ntubi(i, 2) = Val(inn(8))
        EA(i, 6) = Val(inn(9)) : Ntubi(i, 3) = Val(inn(10)) : EA(i, 7) = Val(inn(11))
        Senso(i) = inn(12)
        If Len(Trim(CH)) = 0 Then GoTo 1101
        Nfile = Nfile + 1
        GoTo 100
1101:   Exit Sub
        'PRINT #IFL2, "FINE LETTURA SEZ2 - TRACCIATURA PIASTRA TUBIERA     ."
    End Sub

    Private Sub sez03()
        Dim A1002 As String
        Dim i As Short

        '   READ ( 7,1002 ) (E(I),I=6,33)
        Form = SKIPPA1(9)
        A1002 = "(2(15X,4(14X,F8.3)/),26X,8(3X,F8.3),/3(15X,4(14X,F8.3)/))"
        LEGFORM(A1002, inn, 28, 3)
        For i = 1 To 28 : e(i + 5) = Val(inn(i)) : Next
        For i = 1 To 4 : e(700 + i) = Val(Mid(Form, 28 + i * 22, 8)) : Next
        Form = LineInput(ifl1) 'spostato
    End Sub

    Private Sub sez04()
        'On Local Error GoTo Errsez04
        Dim A1003 As String
        Dim i As Short
        Form = SKIPPA1(7) 'era 7
        N5 = 0
        A1003 = "( 2X,A37,2(8X,I1),1X,2(4X,F7.1),10X,I1,8X,F8.2 )"
        '????  A1003$ = "( 2X,A39,6X,I1,8X,I1,1X,2(4X,F7.1),10X,I1 )"
200:    i = N5 + 1
        'READ ( 7,1003 ) CH9(I),(KB(I,J),J=1,2),(ED(I,J),J=1,2),KB(I,3)
        Form = SKIPPA1(1)

        LEGFORM(A1003, inn, 7, 4)
        CH9(i) = inn(1) : KB(i, 1) = Val(inn(2)) : KB(i, 2) = Val(inn(3))
        ED(i, 1) = Val(inn(4)) : ED(i, 2) = Val(inn(5)) : KB(i, 3) = Val(inn(6))
        ED(i, 3) = Val(inn(7))
        If (Mid(CH9(N5 + 1), 7, 1) = " " Or Len(CH9(N5 + 1)) = 0) Then GoTo 210
        N5 = N5 + 1
        GoTo 200
210:    Exit Sub
        'PRINT #IFL2, "FINE LETTURA SEZ4 - BOCCHELLI                       ."
        Exit Sub
        'Errsez04: Print "Errore in HEADX5/sez04"; Err; Erl: End
    End Sub

    Private Sub sez05()
        'On Local Error GoTo Errsez05
        Dim A1004 As String
        Dim i, j As Short
        Form = SKIPPA1(9)
        N4 = 0
        For i = 1 To 4 : Nrinf(i) = 0 : Next
        A1004 = "( 4X,I1,8X,I1,9X,I3,6X,I2,4X,2(3X,F7.1),4X,F4.1,2X,F2.0,3X,A1,12X,F8.1)"
300:    i = N4 + 1
        'READ ( 7,1004 ) (KA(I,J),J=1,4),(EC(I,J),J=1,4)
        LEGFORM(A1004, inn, 10, 5)
        For j = 1 To 4 : ka(i, j) = Val(inn(j)) : Next
        For j = 1 To 4 : EC(i, j) = Val(inn(j + 4)) : Next
        EC(i, 5) = Val(inn(10))
        Select Case inn(9)
            Case "S" 'figura del setto
                ka(i, 5) = 1
            Case "F" 'figura del Foro
                ka(i, 5) = 2
                Nrinf(ka(i, 1)) = Nrinf(ka(i, 1)) + 1
            Case "X" 'figura dello sfiato
                ka(i, 5) = 3
            Case "R"
                ka(i, 5) = 4
        End Select
        If (ka(i, 1) = 0) Then GoTo 310
        Form = SKIPPA1(1)
        N4 = N4 + 1
        If N4 > MSETTI Then Debug.Print("MSETTI insufficiente") : Stop
        GoTo 300
310:    Exit Sub
        'PRINT #IFL2, "FINE LETTURA SEZ5 - SETTI                           ."
        Exit Sub
        'Errsez05: Print "Errore in HEADX5/sez05"; Err; Erl: End
    End Sub

    Private Sub sez06()
        'On Local Error GoTo Errsez06
        Dim A1005 As String
        Dim i, j As Short
        Form = SKIPPA1(9)
        N3 = 0
        A1005 = "( 4X,F2.0,6X,F7.1,6X,3(2X,F4.1),4X,4(1X,F5.1) )"
4000:   i = N3 + 1

        'READ ( 7,1005 ) (EB(I,J),J=1,9)
        LEGFORM(A1005, inn, 9, 6)
        For j = 1 To 9 : EB(i, j) = Val(inn(j)) : Next
        If (EB(i, 1) = 0.0!) Then GoTo 410
        Form = SKIPPA1(1)
        N3 = N3 + 1
        GoTo 4000
410:    Exit Sub
        'PRINT #IFL2, "FINE LETTURA SEZ6 - TARGHE                          ."
        Exit Sub
        'Errsez06: Print "Errore in HEADX5/sez06"; Err; Erl: End
    End Sub

    Private Sub sez07()
        'On Local Error GoTo Errsez07
        Dim A1006 As String
        Dim i, j As Short
        Dim n1 As Short
        Dim A1007 As String
        Form = SKIPPA1(9)
        A1006 = "( 2(2X,A5,2(1X,A21),1X,A13,1X,A21,1X,A7,1X,A21/) )"
        'READ ( 7,1006 ) ((CH1(I,J),J=1,7),I=1,2)
        LEGFORM(A1006, inn, 14, 7)
        For j = 1 To 7 : ch1(1, j) = inn(j) : Next
        For j = 1 To 7 : ch1(2, j) = inn(j + 7) : Next
        n1 = 0
        A1007 = "( 2X,A5,2(1X,A21),1X,A13,1X,A21,1X,A7,1X,A21 )"
5000:   i = n1 + 1
        If i > MPOS Then
            Debug.Print("Posizioni MPL troppo numerose" & i & MPOS)
            Stop
        End If
        'READ ( 7,1007 ) (CH2(I,J),J=1,7)
        LEGFORM(A1007, inn, 7, 8)
        For j = 1 To 7 : CH2(i, j) = inn(j) : Next
        If (Mid(CH2(i, 1), 1, 1) = "-") Then GoTo 5100
        Form = SKIPPA1(1)
        n1 = n1 + 1
        GoTo 5000
5100:   Form = SKIPPA1(1)
        LEGFORM("(1X,A80//)", inn, 1, 9)
        CH3 = inn(1)
        '      PRINT #IFL2, "FINE LETTURA SEZ7 - LISTA MATERIALI                 ."
        Exit Sub
        'Errsez07: Print "Errore in HEADX5/sez07"; Err; Erl: End
    End Sub

    Private Sub sez08()
        'On Local Error GoTo Errsez08
        Dim A1008 As String
        Dim i, j As Short
        Dim A1010, A1009, A1011 As String
        Form = SKIPPA1(8)
        LEGFORM("(8X,A50//)", inn, 1, 10)
        CH4(1) = inn(1)
        Form = SKIPPA1(1)
        n2 = 0
        A1008 = "( 2(2X,A5,1X,A49,1X,A49/) )"
6000:   i = n2 + 1

        'READ ( 7,1008 ) (CH5(I,J),J=1,3),(CH5(I+1,J),J=1,3)
        LEGFORM(A1008, inn, 6, 11)
        If i + 1 > MNOTE * 2 Then
            Debug.Print("HEADX1,dimensionamento MNOTE insufficiente") : Stop
        End If
        For j = 1 To 3 : CH5(i, j) = inn(j) : Next
        For j = 1 To 3 : CH5(i + 1, j) = inn(j + 3) : Next
        If (Mid(CH5(i, 1), 1, 5) = "     ") Then GoTo 6100
        Form = SKIPPA1(1)
        n2 = n2 + 2
        GoTo 6000
6100:   Form = SKIPPA1(2)
        LEGFORM("(8X,A50//)", inn, 1, 12)
        CH4(2) = inn(1) 'specifiche
        A1009 = "( 8(2X,A32,1X,A73/) )"
        'READ ( 7,1009 ) ((CH6(I,J),J=1,2),I=1,8)
        Form = SKIPPA1(1)
        LEGFORM(A1009, inn, 16, 13)
        For i = 1 To 8 : For j = 1 To 2
                CH6(i, j) = inn((i - 1) * 2 + j) : Next : Next
        Form = SKIPPA1(1)
        LEGFORM("(2X,A32,1X,A73/)", inn, 0, 0)
        CH6(9, 1) = inn(1) : CH6(9, 2) = inn(2)
        LEGFORM("(3(/),8X,A50//)", inn, 1, 14)
        CH4(3) = inn(1) 'TUBI -TUBES
        A1010 = "( 9(2X,A32,1X,A32,1X,A42,1X,A10/) )"
        'READ ( 7,1010 ) ((CH7(I,J),J=1,3),I=1,9)
        Form = SKIPPA1(1)
        LEGFORM(A1010, inn, 36, 15)
        For i = 1 To 9 : For j = 1 To 4
                CH7(i, j) = inn((i - 1) * 4 + j) : Next : Next
        Form = SKIPPA1(1) 'ch7(4,4) passo ch7(5,4) passo vert
        LEGFORM("(4(/),8X,A50//)", inn, 1, 16)
        CH4(4) = inn(1)
        A1011 = "( 12(2X,A32,1X,A32,1X,A42/) )"
        'READ ( 7,1011 ) ((CH8(I,J),J=1,3),I=1,12)
        Form = SKIPPA1(1)
        LEGFORM(A1011, inn, 36, 17)
        For i = 1 To 12 : For j = 1 To 3
                CH8(i, j) = inn((i - 1) * 3 + j) : Next : Next
        '      PRINT #IFL2, "FINE LETTURA SEZ8 - NOTE-SPECIFICHE-TUBI-DATI-PROG  ."
        'PRINT ch4(1)
        'PRINT ch4(2)
        'PRINT ch4(3)
        'PRINT ch4(4)
        'PRINT ch8(12, 1); ch8(12, 2); ch8(12, 3)
        Exit Sub
        'Errsez08: Print "Errore in HEADX5/sez08"; Err; Erl: End
    End Sub

    Private Sub sez09()
        Dim A1012 As String
        Dim i, j As Short
        'On Local Error GoTo Errsez09
        A1012 = "(7(64X,F6.0,18X,F6.0,/))" 'non ha saltato
        Form = SKIPPA1(3)
        LEGFORM(A1012, inn, 7, 18)
        For j = 1 To 7 : eMon(99 + j) = Val(inn(2 * j - 1)) : Next
        eMon(107) = Val(inn(2)) : eMon(108) = Val(inn(4))
        '      PRINT #IFL2, "FINE LETTURA SEZ9 - SCHEMA MONTAGGIO                ."
        Form = LineInput(ifl1)
        CH16(40) = Mid(Form, 66, 2) ' non più usato
        Exit Sub
        'Errsez09: Print "Errore in HEADX5/sez09"; Err; Erl: End
    End Sub

    Private Sub sez10()
        Dim A1013 As String
        Dim j As Short
        Form = SKIPPA1(2)
        A1013 = "(19(F5.0))"
        LEGFORM(A1013, inn, 19, 19)
        For j = 1 To 19 : e(33 + j) = Val(inn(j)) : Next
        '      PRINT #IFL2, "FINE LETTURA SEZ10- DIMENSIONI STANDARD TESTATE     ."
    End Sub

    Private Sub sez11()
        Dim A1016 As String
        Dim i, j As Short
        Dim k As Short
        Form = SKIPPA1(6)
        A1016 = "(27X,4(3X,A8),1X,8(1X,F5.0))"
        For i = 1 To 8

            'READ ( 7,1016 ) (CH16(J),J=(I-1)*4+1,I*4) ,
            '&                ( X0(J),Y0(J) ,J=(I-1)*4+1,I*4)
            LEGFORM(A1016, inn, 12, 20)
            For k = 1 To 4 : j = (i - 1) * 4 + 1 + k : CH16(k) = inn(k) : Next
            For k = 1 To 4 : j = (i - 1) * 4 + 1 + k : x0(k) = Val(inn(k + 4)) : Next
            For k = 1 To 4 : j = (i - 1) * 4 + 1 + k : y0(k) = Val(inn(k + 8)) : Next
            Form = SKIPPA1(1)
        Next
        '      PRINT #IFL2, "FINE LETTURA SEZ11- PARTICOLARI TESTATA             ."
    End Sub

    Private Sub sez12()
        Form = SKIPPA1(31)
    End Sub

    Private Sub sez13()
        Form = SKIPPA1(12)
    End Sub

    Private Sub sez14()
        ReDim EE(20, 4)
        ReDim AE(20, 4)
        ReDim EFCov(20)
        ReDim AFCov(20)
        ReDim ch11(5, 4)
        Dim ch12(10) As String
        Dim A1000 As String
        Dim i, ii As Short
        Dim A1004, A1005 As String
        Dim n, j As Short
        ReDim CCov(20)
        ReDim Nsetti(10)
        ReDim Passi(2, 4)
        Form = SKIPPA1(9) 'form$= riga 08A
        '    A1000$ = "(8(28X,4(F13.2,9X)/)) "
        A1000 = "( 20X,4(14X,F8.3)/ )"
        LEGFORM(A1000, inn, 4, 14)
        For i = 1 To 4 : EE(1, i) = Val(inn(i)) : Next
        LEGFORM(A1000, inn, 4, 14)
        For i = 1 To 4 : Passi(1, i) = Val(inn(i)) : Next
        LEGFORM(A1000, inn, 4, 14)
        For i = 1 To 4 : EE(2, i) = Val(inn(i)) : Next
        LEGFORM(A1000, inn, 4, 14)
        For i = 1 To 4 : Passi(2, i) = Val(inn(i)) : Next
        LEGFORM(A1000, inn, 4, 14)
        For i = 1 To 4 : EE(3, i) = Val(inn(i)) : Next
        For i = 4 To 12
            LEGFORM(A1000, inn, 4, 14)
            For ii = 1 To 4 : EE(i, ii) = Val(inn(ii)) : Next
            If (EE(i, 1) = 0.0! And EE(i, 2) = 0.0! And EE(i, 3) = 0.0! And EE(i, 4) = 0.0!) Then Exit For
            For n = 1 To 4
                If (EE(i, n) <> 0.0!) Then Nsetti(n) = Nsetti(n) + 1
            Next
        Next
        A1004 = "( 2(21X,4(13X,A9)/) )  "
        LEGFORM(A1004, inn, 4, 14)
        For i = 1 To 2
            For j = 1 To 4
                ch11(i, j) = inn((i - 1) * 4 + j)
            Next j
        Next i
        Form = SKIPPA1(2)
        A1005 = "(6(55X,F8.3/),2(51X,A22/) ) "
        LEGFORM(A1005, inn, 8, 14)
        For i = 1 To 6 : e(299 + i) = Val(inn(i)) : Next  '2:profondit… canalino
        ch12(1) = inn(7) : ch12(2) = inn(8)
        Form = SKIPPA1(3)
        For i = 1 To 16 : inn(i) = Mid(Form, 1 + 7 * (i - 1), 7) : Next
        For i = 1 To 16 : e(309 + i) = Val(inn(i)) : Next
        NFASCI = Val(Mid(ch10(9), 1, 3))
        Form = SKIPPA1(2)
        e(355) = Val(Mid(Form, 56, 7)) 'spessore guarnizione
        Form = SKIPPA1(1)
        e(360) = Val(Mid(Form, 56, 7)) 'aria flangia
        Form = SKIPPA1(1)
        e(361) = Val(Mid(Form, 56, 7)) 'altezza nasello
        Form = SKIPPA1(1)
        LEGFORM(A1000, inn, 4, 14)
        For i = 1 To 4 : e(355 + i) = Val(inn(i)) : Next
    End Sub

    Private Function Uguale(ByRef iora As Short, ByRef ibas As Short, ByRef Ialt As Short, ByRef l As String, ByRef now1 As String) As Short
        Dim k As Short
        If iora = Len(l) Then Uguale = iora : Exit Function
        Do
            iora = iora + 1 : now1 = Mid(l, iora, 1) : k = Asc(now1)
        Loop While (k > Ialt Or k < ibas Or k = 46) And iora < Len(l)
        Uguale = iora
    End Function
    Private Sub COPERCHI(ByRef n As Short)
        '      FOR n = 1 TO 4
        '
        '     CONDIZIONE DI SALTO CICLO
        If (EE(1, n) = 0.0!) Then Exit Sub
        '
        '                    P A R T E         C A L C O L O
        '
        Call DefinCov(n)
        '
        '           E S E C U Z I O N E     D E I      C O P E R C H I
        '
        With Monitor.routines
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.refabs. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .refabs()
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.refere. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .refere(CCov(1) + CCov(3), CCov(4), 0)
            Call COVER(n)
            '
            '                F O R M A T O         C O P E R C H I
            '
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.refabs. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .refabs()
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.refere. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .refere(CCov(1), 0.0!, 0)
            '      PRINT "entro in SubA2": u$ = INPUT$(1)
            '      CALL SubA2
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.refere. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .refere(405.0!, 31.0!, 0)
            '     CALL TITOLO(1, N)
            '
            '       E S E C U Z I O N E     D E L L E      G U A R N I Z I O N I
            '
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.refabs. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .refabs()
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.refere. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .refere(CCov(1) + CCov(5), CCov(6), 0)
            '     CALL GASKET(N)
            '
            '                F O R M A T O         G U A R N I Z I O N I
            '
            '     CALL .refabs
            '     CALL refere(CCov(1), CCov(7), 0)
            '     CALL A3
            '     CALL STD
            '     CALL refere(232.5, 32.5, 0)
            '     CALL TITOLO(2, N)
            '
            CCov(1) = CCov(1) + CCov(2)
        End With
        '      NEXT
    End Sub

    Private Sub COVER(ByRef n As Short)
        Static X, y As Short
        Dim i, j As Short
        Dim p1 As Single
        Dim xprim, p2, yprim As Single
        Dim ysec, xsec, P3 As Single
        Dim p4 As Single
        '     COSTRUZIONE ASSI COPERCHIO
        With Monitor.routines
            Call .ctrait(2.0!, 0.1)
            Call .segm(0.0!, A(341) / 2.0! + 5.0!, 0.0!, -A(341) / 2.0! - 5.0!)
            Call .segm(-A(340) / 2.0! - 5.0!, 0.0!, A(340) / 2.0! + 5.0!, 0.0!)
            '=======================================================================
            '                      V   I   S   T   A
            '=======================================================================
            '
            '
            '      C O S T R U Z I O N E      D O P P I A     S I M M E T R I A
            '
            For X = -1 To 1 Step 2
                For y = -1 To 1 Step 2
                    '     COSTRUZIONE PERIMETRO ESTERNO COPERCHIO
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.ctrait. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .ctrait(0, 0.4)
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .segm(0.0!, A(341) / 2.0! * y, A(340) / 2.0! * X, A(341) / 2.0! * y)
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .segm(A(340) / 2.0! * X, A(341) / 2.0! * y, A(340) / 2.0! * X, 0.0!)
                    '     COSTRUZIONE PERIMETRO ESTERNO CAVA
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.ctrait. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .ctrait(0, 0.4)
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .segm(0.0!, A(343) * y, A(342) * X, A(343) * y)
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .segm(A(342) * X, A(343) * y, A(342) * X, 0.0!)
                    '     CG1 = CONGE(A(311), S3, S4)
                    '     IF ( X.EQ.-1.AND.Y.EQ.-1 ) THEN
                    '     AN5 = ANNOTA ( CG1,45.,HORIZ(7.),ANOTEX(' R=7 (TYP) !') )
                    '     CALL ELIMIN(AN5)
                    '     AN5 = ANNOTA ( CG1,45.,HORIZ(7.),ANOTEX(' R=7 (TYP) !') )
                    '     END IF
                    '     COSTRUZIONE FORATURA ORIZZONTALE
                    A(346) = A(344) - AE(2, n)
                    For i = 1 To Passi(1, n) \ 2 + 1
                        A(346) = A(346) + AE(2, n)
                        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.poynt. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        p1 = .poynt(A(346) * X, (A(341) / 2.0! - A(305)) * y)
                        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.ctrait. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .ctrait(0, 0.1)
                        For j = 90 To 360 Step 90
                            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.seg2. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                            Call .seg2(p1, 0.7 * A(300), j * 1.0!)
                        Next j
                        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.ctrait. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .ctrait(0, 0.4)
                        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.cerc. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .cerc(A(346) * X, (A(341) / 2.0! - A(305)) * y, A(300) / 2.0!)
                    Next i '50
                    '     COSTRUZIONE FORATURA VERTICALE
                    A(347) = A(345) - AE(3, n)
                    For i = 1 To Passi(2, n) \ 2 + 1
                        A(347) = A(347) + AE(3, n)
                        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.poynt. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        p2 = .poynt((A(340) / 2.0! - A(305)) * X, A(347) * y)
                        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.ctrait. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .ctrait(0, 0.1)
                        For j = 90 To 360 Step 90
                            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.seg2. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                            Call .seg2(p2, 0.7 * A(300), j * 1.0!)
                        Next j
                        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.ctrait. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .ctrait(0, 0.4)
                        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.cerc. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .cerc((A(340) / 2.0! - A(305)) * X, A(347) * y, A(300) / 2.0!)
                    Next i '70
                    If (y = 1) Then
                        '    &CL8 = COTLIN ( UPPER(CENTRE(A2),-A(347)-A(341)/2.-2.),
                        '    &               UPPER(CENTRE(A1),-A(341)+A(305)-2.),H(-28.),
                        '    &               VALUE(Scalb) , SOULIN(0.) )
                    End If
                Next y '30
            Next X '40
            '     CL1 = COTLIN ( UPPER(HAUT(S2),2.),SYMETY(HAUT(S2),2.),H(58.),
            '    &              VALUE(Scalb) , SOULIN(0.) )
            '
            '     C O S T R U Z I O N E      S E M P L I C E     S I M M E T R I A
            '
            '     COSTRUZIONE PERIMETRO INTERNO CAVA SETTI COMPRESI
            For X = -1 To 1 Step 2
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.ctrait. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .ctrait(0, 0.4)
                For i = 1 To Nsetti(n) + 1
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .segm(0.0!, AFCov(i) + A(310) / 2.0!, A(348) * X, AFCov(i) + A(310) / 2.0!)
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .segm(A(348) * X, AFCov(i) + A(310) / 2.0!, A(349) * X, AFCov(i) + A(310) / 2.0! + A(312))
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .segm(A(349) * X, AFCov(i) + A(310) / 2.0! + A(312), A(349) * X, AFCov(i + 1) - A(310) / 2.0! - A(312))
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .segm(A(349) * X, AFCov(i + 1) - A(310) / 2.0! - A(312), A(348) * X, AFCov(i + 1) - A(310) / 2.0!)
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .segm(0.0!, AFCov(i + 1) - A(310) / 2.0!, A(348) * X, AFCov(i + 1) - A(310) / 2.0!)
                    If (X = 1 And i = 1) Then
                        '    &AN6 = ANNOTA ( S11,135.,4.,180.,ANOTEX('SM 12X12 (TYP)!') )
                    End If
                Next i '110
                '120   CONTINUE
                '     COSTRUZIONE ASSE VERTICALI CAVA
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.ctrait. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .ctrait(2.0!, 0.1)
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .segm((A(342) - A(310) / 2.0!) * X, A(343) - 5.0!, (A(342) - A(310) / 2.0!) * X, 0.0!)
                '     COSTRUZIONE DELLE ORECCHIE
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.ctrait. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .ctrait(0, 0.4)
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .segm((A(353) - A(318)) * X, A(341) / 2.0!, (A(353) - A(318)) * X, A(341) / 2.0! + A(316))
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .segm((A(353) + A(318)) * X, A(341) / 2.0!, (A(353) + A(318)) * X, A(341) / 2.0! + A(316))
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.arc. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .arc(A(353) * X, A(341) / 2.0! + A(316), A(353) * X + A(318), A(341) / 2.0! + A(316), 180.0!)
                '???  a3 = arc(A(353) * X, A(341) / 2! + A(316), A(353) * X - A(318), A(341) / 2! + A(316), 180!)
                '     p3 = poynt(A(353) * X - A(318) - A(317), A(341) / 2!)
                '     p4 = poynt(A(353) * X + A(318) + A(317), A(341) / 2!)
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto PI. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                xprim = A(353) * X + A(319) * System.Math.Cos(30.0! * PI / 180.0!)
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto PI. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                yprim = A(341) / 2.0! + A(316) + A(319) * System.Math.Sin(30.0! * PI / 180.0!)
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.arc. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .arc(A(353) * X, A(341) / 2.0! + A(316), xprim, yprim, 120.0!)
                ysec = A(341) / 2.0!
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto PI. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                xsec = xprim + (yprim - ysec) * System.Math.Tan(30.0! * PI / 180.0!)
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .segm(xprim, yprim, xsec, ysec)
                xprim = xprim - 2 * (xprim - A(353) * X)
                xsec = xsec - 2 * (xsec - A(353) * X)
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .segm(xprim, yprim, xsec, ysec)
                '      C1 = cerc(A(353) * X, A(341) / 2! + A(316), A(319))
                '     D1 = DROITE(P3, GAUCHE(C1))
                '     D2 = DROITE(P4, DROIT(C1))
                '     P5 = poynt(D1, D2)
                '     S22 = SEGM(P3, P5)
                '     S23 = SEGM(P4, P5)
                '     CG2 = CONGE(S22, S23, A(319))
                '     CL3 = COTLIN ( UPPER(HAUT(S7),2.),UPPER(CENTRE(A3),-2.),
                '    &               H(-A(316)+46.),VALUE(Scalb) , SOULIN(0.) )
            Next X '100
            '     CL4 = COTLIN ( UPPER(HAUT(S9),1.),SYMETY(HAUT(S9),1.),
            '    &               H(A(341)/2.-A(343)+56.),VALUE(Scalb) ,SOULIN(0.))
            '     CL5 = COTLIN ( UPPER(BAS(S22),A(316)+A(318)+10.),
            '    &               UPPER(BAS(S23),A(316)+1.),H(-A(316)-A(318)+26.),
            '    &               VALUE(Scalb) , SOULIN(0.) )
            '     CL6 = COTLIN ( RIGTER(CENTRE(A3),-1.),RIGTER(BAS(S23),1.),
            '    &               V(10.),VALUE(Scalb) , SOULIN(0.) )
            '     CC1 = COTCIR ( CG2,135.,HORIZ(4.),PRETEX('R=!'),GAP(E(319)) ,
            '    &               SOULIN(0.) )
            '     CC2 = COTCIR (A3 ,165.,HORIZ(4.),PRETEX('R=!'),GAP(E(318)) ,
            '    &               SOULIN(0.) )
            '     CL2 = COTLIN ( UPPER ( GAUCHE(S5),-A(341)+A(305)-2. ),
            '    &               SYMETY( GAUCHE(S5),-A(341)+A(305)-2. ),H(-28.),
            '    &               PITCH(PASSI(1,N),EE(2,N)),VALUE(Scalb) ,
            '    &               SOULIN(0.) )
            '     CL17= COTLIN ( UPPER  (CENTRE(A2),-A(347)-A(341)/2.-2.),
            '    &               SYMETY (CENTRE(A2),-A(347)-A(341)/2.-2.),
            '    &               H(-36.),VALUE(Scalb) , SOULIN(0.) )
            '     CL7 = COTLIN ( RIGTER(CENTRE(A2),A(305)+2.),
            '    &               SYMETX (CENTRE(A2),A(305)+2.),V(18.),
            '    &               PITCH(PASSI(2,N),EE(3,N)),VALUE(Scalb) ,
            '    &               SOULIN(0.) )
            '     CL10= COTLIN ( RIGTER(CENTRE(A1),A(340)/2.-A(346)+2.),
            '    &               RIGTER(CENTRE(A2),A(305)+2.),V(18.),
            '    &               VALUE(Scalb) , SOULIN(0.) )
            '     CL11= COTLIN ( SYMETX(CENTRE(A1),A(340)/2.-A(346)+2.),
            '    &               SYMETX(CENTRE(A2),A(305)+2.),V(18.),
            '    &               VALUE(Scalb) , SOULIN(0.) )
            '     CL12= COTLIN ( RIGTER(DROIT(S1),2.),SYMETX(DROIT(S1),2.),
            '    &               V(34.),VALUE(Scalb) , SOULIN(0.) )
            '     CL16= COTLIN ( RIGTER(CENTRE(A1),A(340)/2.-A(346)+2.),
            '    &               SYMETX(CENTRE(A1),A(340)/2.-A(346)+2.),
            '    &               V(26.),VALUE(Scalb) , SOULIN(0.) )
            '     AN1 = ANNOTA ( SYMETY(DROIT(S1),-2.),135.,30.,180.,
            '    &               ANOTEX(' 1') )
            '     AN2 = ANNOTA ( SYMETY(GAUCHE(CG2),0.),45.,10.,0.,
            '    &               ANOTEX(' 2') )
            '     COSTRUZIONE FORI PER VITE ESTRAZIONE E SPINA
            For X = -1 To 1 Step 2
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.refere. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .refere((A(340) / 2.0! - A(305)) * X, 0.0!, 0)
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.poynt. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                P3 = .poynt(0.0!, -A(354) * X)
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.ctrait. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .ctrait(0, 0.4)
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.cerc. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .cerc(0.0!, -A(354) * X, A(321) / 2.0!)
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.ctrait. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .ctrait(0, 0.1)
                For i = 90 To 360 Step 90
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.seg2. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .seg2(P3, A(321), i * 1.0!)
                Next i '140   CONTINUE
                '     CL13 = COTLIN ( RIGTER (poynt(0.,(-A(354)-A(321)/2.)*X),.5*X),
                '    &                RIGTER (poynt(0.,(-A(354)+A(321)/2.)*X),.5*X),
                '    &                V((A(305)+5.5)*X),PRETEX('$!'),VALUE(Scalb) ,
                '    &                SOULIN(0.) )
                '     CL14 = COTLIN ( RIGTER(P3,(A(305)+8.)*X),RIGTER(poynt(0.,0.),0.),
                '    &                V(5.*X),VALUE(Scalb) , SOULIN(0.) )
                '
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.poynt. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                p4 = .poynt(0.0!, A(354) * X)
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.ctrait. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .ctrait(0, 0.4)
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.cerc. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .cerc(0.0!, A(354) * X, A(322) / 2.0!)
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.ctrait. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .ctrait(0, 0.1)
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.arc. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .arc(0.0!, A(354) * X, -A(322) / 2.0! - 0.5, A(354) * X, 270.0!)
                For i = 90 To 360 Step 90
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.seg2. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .seg2(p4, A(322), i * 1.0!)
                Next i '150
                '     CL15 = COTLIN ( RIGTER (P4,0.),RIGTER (poynt(0.,0.),0.),
                '    &                V((A(305)+13.)*X),VALUE(Scalb),TYPFLE(0.) ,
                '    &                SOULIN(0.) )
                If (X = -1) Then
                    '     AN3 = ANNOTA (RIGTER(poynt(0.,-A(354)-12.5),-A(305)-6.),90.,
                    '    &              6.5,90.,ANOTEX('"A"') )
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.ECRIR. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .ECRIR(Chr(34) & "A" & Chr(34) & " !")
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.texte0. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .texte0(-A(305) - 13.0!, -A(354) - 8.0!, 0.0!, 2.5, 0.2)
                Else
                    '     AN3 = ANNOTA ( RIGTER(poynt(0.,A(354)),A(305)+6.),90.,
                    '    &               4.,90.,ANOTEX('"A"') )
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.ECRIR. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .ECRIR(Chr(34) & "A" & Chr(34) & " !")
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.texte0. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .texte0(A(305) + 5.0!, A(354) + 10.0!, 0.0!, 2.5, 0.2)
                End If
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.refere. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .refere(-(A(340) / 2.0! - A(305)) * X, 0.0!, 0)
            Next X '130
            '
            '                SEZIONE PER FORI DI ESTRAZIONE E SPINE
            '
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.refere. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .refere(-A(340) / 2.0!, -200.0!, 0)
            '     QUESTA SEZIONE VIENE ESEGUITA IN Scalb 1:2
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.ctrait. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .ctrait(0, 0.4)
            '     CALL DEBGRP
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .segm(0.0!, 0.0!, 0.0!, EE(1, n) / 2.0!)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .segm(0.0!, EE(1, n) / 2.0!, 50.0!, EE(1, n) / 2.0!)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .segm((e(305) - e(323) / 2.0!) / 2.0!, EE(1, n) / 2.0!, (e(305) - e(323) / 2.0!) / 2.0!, e(324) / 2.0!)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .segm((e(305) - e(323) / 2.0!) / 2.0!, e(324) / 2.0!, (e(305) + e(323) / 2.0!) / 2.0!, e(324) / 2.0!)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .segm((e(305) - e(322) / 2.0!) / 2.0!, e(324) / 2.0!, (e(305) - e(322) / 2.0!) / 2.0!, 0.0!)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .segm(0.0!, 0.0!, 50.0!, 0.0!)
            '     CALL FINGRP
            '     CALL CONHAC(DROIT(S1), BAS(S2))
            '     H1 = HACHUR(45!, .1, 0!, 2!)
            '     CALL DEBGRP
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .segm((e(305) + e(323) / 2.0!) / 2.0!, EE(1, n) / 2.0!, (e(305) + e(323) / 2.0!) / 2.0!, e(324) / 2.0!)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .segm((e(305) + e(322) / 2.0!) / 2.0!, e(324) / 2.0!, (e(305) + e(322) / 2.0!) / 2.0!, 0.0!)
            '??      S9 = segm(50!, 0!, 50!, EE(1, n) / 2!)
            '     CALL RELGRP(S2, S4, S6)
            '     CALL FINGRP
            '     CALL CONHAC(HAUT(S6), GAUCHE(S9))
            '     H1 = HACHUR(45!, .1, 0!, 2!)
            '     CALL ELIMIN(S9)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.ctrait. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .ctrait(0, 0.1)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .segm((e(305) - e(323) / 2.0!) / 2.0!, 0.0!, (e(305) - e(323) / 2.0!) / 2.0!, e(324) / 2.0!)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .segm((e(305) + e(323) / 2.0!) / 2.0!, 0.0!, (e(305) + e(323) / 2.0!) / 2.0!, e(324) / 2.0!)
            '??      S13 = segm((e(305) - e(322) / 2!) / 2!, e(324) / 2!, (e(323) - e(322)) * 1.41 / 4!, 135!)
            '??      S14 = segm((e(305) + e(322) / 2!) / 2!, e(324) / 2!, (e(323) - e(322)) * 1.41 / 4!, 45!)
            '     S16 = SEGM(poynt(HAUT(S13)), poynt(HAUT(S14)))
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.ctrait. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .ctrait(2.0!, 0.1)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .segm(50.0!, -3.0!, 50.0!, EE(1, n) / 2.0! + 3.0!)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .segm(e(305) / 2.0!, -4.0!, e(305) / 2.0!, EE(1, n) / 2.0! + 4.0!)
            '     CL18 = COTLIN ( RIGTER(HAUT(S1),-2.),RIGTER(BAS(S1),-2.),V(-18.),
            '    &                VALUE(.5) , SOULIN(0.) )
            '     CL19 = COTLIN ( RIGTER(HAUT(S3),-2.),RIGTER(BAS(S3),-2.),
            '    &                V(-(E(305)-E(323)/2.)/2.-12.),VALUE(.5) ,
            '    &                SOULIN(0.) )
            '     CL20 = COTLIN ( UPPER(HAUT(S7),2.),UPPER(HAUT(S3),2.),H(20.),
            '    &                PRETEX('$ !'),VALUE(.5) , SOULIN(0.) )
            '     CL21 = COTLIN ( UPPER(BAS(S11),-2.),UPPER(BAS(S10),-2.),H(-20.),
            '    &                THEOR('3/8" 16 UNC !') , SOULIN(0.) )
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.ECRIR. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .ECRIR("SEZIONE " & Chr(34) & "A" & Chr(34) & " !")
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.texte0. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .texte0(0.0!, -40.0!, 0.0!, 4.0!, 0.4)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.ECRIR. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .ECRIR("SECTION " & Chr(34) & "A" & Chr(34) & " !")
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.texte0. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .texte0(0.0!, -48.0!, 0.0!, 4.0!, 0.4)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.refere. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .refere(A(340) / 2.0!, 200.0!, 0)
            '=======================================================================
            '                    S   E   Z   I   O   N   E
            '=======================================================================
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.refere. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .refere(A(340) / 2.0! + 75.0!, 0.0!, 0)
            Call SezionCov(n, 1)
            '
            '     COSTRUZIONE DEL PARTICOLARE DELLA SCANALATURA
            '
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.refere. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .refere(0.0!, -A(341) / 2.0! - 85.0!, 0)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.ctrait. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .ctrait(0, 0.4)
            '     CALL DEBGRP
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .segm(0.0!, 0.0!, 0.0!, 5.0!)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .segm(0.0!, 5.0!, -e(301), 5.0!)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .segm(-e(301), 5.0!, -e(301), 5.0! + e(310))
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .segm(-e(301), 5.0! + e(310), 0.0!, 5.0! + e(310))
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .segm(0.0!, 5.0! + e(310), 0.0!, 10.0! + e(310))
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .segm(0.0!, 10.0! + e(310), -10.0!, 10.0! + e(310))
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .segm(-10.0!, 10.0! + e(310), -10.0!, 0.0!)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .segm(-10.0!, 0.0!, 0.0!, 0.0!)
            '     CALL FINGRP
            '     CALL CONHAC(GAUCHE(S1), HAUT(S8))
            '     H1 = HACHUR(45!, .1, 0!, 1!)
            '     CL1 = COTLIN ( RIGTER(DROIT(S2),1.),RIGTER(DROIT(S4),1.),VER(10.),
            '    &               SOULIN(0.) )
            '     CL2 = COTLIN ( UPPER(DROIT(S4),1.), UPPER(GAUCHE(S4),1.),HOR(15.),
            '    &               SOULIN(0.) )
            '     CALL ELIMIN(S6, S7, S8)
        End With
    End Sub

    Private Sub DefinCov(ByRef n As Short)
        Dim i As Short
        '    RESTORE DataCov
        'DataCov:
        'Data 700#, 295#, 300#, 85#, 800#, 550#
        '    For i = 2 To 7: READ CCov(i): Next
        CCov(2) = 700.0#
        CCov(3) = 295.0#
        CCov(4) = 300.0#
        CCov(5) = 85.0#
        CCov(6) = 800.0#
        CCov(7) = 550.0#
        CCov(1) = 0.0!
        '                P A R T E      D I      C A L C O L O
        '
        '     CALCOLO DI DIMENSIONI GEOMETRICHE
        e(340) = e(5 + n) + 2 * e(303)
        e(341) = e(12 + 2 * n) + 2 * e(303)
        e(342) = e(340) / 2.0! - e(304) + e(310) / 2.0!
        e(343) = e(341) / 2.0! - e(304) + e(310) / 2.0!
        e(344) = (Passi(1, n) / 2.0! - Int(Passi(1, n) / 2)) * EE(2, n)
        e(345) = (Passi(2, n) / 2.0! - Int(Passi(2, n) / 2)) * EE(3, n)
        e(346) = (Passi(1, n) * EE(2, n)) / 2.0!
        e(347) = (Passi(2, n) * EE(3, n)) / 2.0!
        e(348) = e(342) - e(310) - e(312)
        e(349) = e(342) - e(310)
        e(350) = e(340) / 2.0! - e(304) + e(313) / 2.0!
        e(351) = e(341) / 2.0! - e(304) + e(313) / 2.0!
        e(352) = e(350) - e(313)
        e(353) = Int(e(340) * 0.03135) * 10.0!
        If (e(320) <> 0.0!) Then e(353) = e(320)
        e(354) = Int((Passi(2, n) / 2.0! - Int(Passi(2, n) / 2.0!) + 0.5) * EE(3, n) + 0.5)
        '     CALCOLO POSIZIONE SCANALATURE RISPETTO 1/2 RIA
        EFCov(1) = -e(341) / 2.0! + e(304)
        For i = 2 To Nsetti(n) + 1
            EFCov(i) = -e(341) / 2.0! + e(303) + EE(i + 2, n)
        Next
        EFCov(i) = e(341) / 2.0! - e(304) '??????????????????????
        '
        '                   L I S T A      M A T E R I A L I
        '
        '     POS  COPERCHIO
        '     WRITE ( CH13(1,1,1)(1:3) ,'(3H1 !)' )
        '
        '     DESCRIZIONE COPERCHIO
        '     WRITE ( CH13(1,2,1)(1:11),'(11HCOPERCHIO !)' )
        '
        '     DESCRIPTION COPERCHIO
        '     WRITE ( CH13(1,3,1)(1:13),'(13HCOVER PLATE !)' )
        '
        '     MATERIALE COPERCHIO
        '     CH13(1, 4, 1) = CH12(1)
        '
        '     NUMERO COPERCHIO
        '     WRITE ( CH13(1,5,1)(1:5) ,'(I3,2H !)' ) NFASCI
        '
        '     DIMENSIONI COPERCHIO
        '     WRITE ( CH13(1,6,1)(1:21),'(3HTHK,I3,I6,2H X,I4,2H !)' )
        '    &        INT(EE(1,N)),INT(E(340)),INT(E(341))
        '
        '     POS  ORECCHIA
        '     WRITE ( CH13(2,1,1)(1:3) ,'(3H2 !)' )
        '
        '     DESCRIZIONE ORECCHIA
        '     WRITE ( CH13(2,2,1)(1:11),'(11HORECCHIA  !)' )
        '
        '     DESCRIPTION ORECCHIA
        '     WRITE ( CH13(2,3,1)(1:13),'(13HLIFTING LUG !)' )
        '
        '     MATERIALE ORECCHIA
        '     CH13(2, 4, 1) = CH12(1)
        '
        '     NUMERO ORECCHIA
        '     WRITE ( CH13(2,5,1)(1:5) ,'(I3,2H !)' ) NFASCI*2
        '
        '     DIMENSIONI ORECCHIA
        '     WRITE ( CH13(2,6,1)(1:21),'(3HTHK,I3,I6,2H X,I4,2H !)' )
        '    &        INT(E(302)),INT((E(317)+E(318))*2.),INT(E(316)+E(319))
        '     POS  GUARNIZIONE
        '     WRITE ( CH13(1,1,2)(1:3) ,'(3H1 !)' )
        '
        '     DESCRIZIONE GUARNIZIONE
        '     WRITE ( CH13(1,2,2)(1:13),'(13HGUARNIZIONE !)' )
        '
        '     DESCRIPTION GUARNIZIONE
        '     WRITE ( CH13(1,3,2)(1:13),'(13HGASKET      !)' )
        '
        '     MATERIALE GUARNIZIONE
        '     CH13(1, 4, 2) = CH12(2)
        '
        '     NUMERO GUARNIZIONE
        '     WRITE ( CH13(1,5,2)(1:5) ,'(I3,2H !)' ) NFASCI
        '
        '     DIMENSIONI GUARNIZIONE
        '     WRITE ( CH13(1,6,2)(1:3),'(3H  !)' )
        '
        '     CH13(2,1,2)(1:5) = '     '
        For i = 300 To 400
            A(i) = e(i) * Scalb
        Next
        For i = 1 To 20
            AE(i, n) = EE(i, n) * Scalb
            AFCov(i) = EFCov(i) * Scalb
        Next
    End Sub

    Private Sub SezionCov(ByRef n As Short, ByRef iW As Short)
        Static y, X, i As Short
        With Monitor.routines
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.ctrait. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .ctrait(0, 0.4)
            For y = -1 To 1 Step 2
                '     CALL DEBGRP
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .segm(-AE(1, n) * iW, A(341) / 2.0! * y, 0.0!, A(341) / 2.0! * y)
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .segm(0.0!, A(341) / 2.0! * y, 0.0!, (A(341) / 2.0! - A(305) + A(300) / 2.0!) * y)
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .segm(0.0!, (A(341) / 2.0! - A(305) + A(300) / 2.0!) * y, -AE(1, n) * iW, (A(341) / 2.0! - A(305) + A(300) / 2.0!) * y)
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .segm(-AE(1, n) * iW, (A(341) / 2.0! - A(305) + A(300) / 2.0!) * y, -AE(1, n) * iW, A(341) / 2.0! * y)
                '     CALL FINGRP
                '     CALL CONHAC(DROIT(S1), GAUCHE(S2))
                '     H1 = HACHUR(45!, .1, 1!, 1!)
            Next y '200
            '     CALL DEBGRP
            For i = 1 To Nsetti(n) + 1
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .segm(-A(301) * iW, AFCov(i), -A(301) * iW, AFCov(i) + A(310) / 2.0!)
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .segm(-A(301) * iW, AFCov(i) + A(310) / 2.0!, 0.0!, AFCov(i) + A(310) / 2.0!)
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .segm(0.0!, AFCov(i) + A(310) / 2.0!, 0.0!, AFCov(i + 1) - A(310) / 2.0!)
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .segm(0.0!, AFCov(i + 1) - A(310) / 2.0!, -A(301) * iW, AFCov(i + 1) - A(310) / 2.0!)
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .segm(-A(301) * iW, AFCov(i + 1) - A(310) / 2.0!, -A(301) * iW, AFCov(i + 1))
                '     CL1 = COTLIN ( RIGTER(BAS(S5),-2.),RIGTER(HAUT(S9),-2.),
                '    &               V(A(301)+22.),VALUE(Scalb) , SOULIN(0.) )
                If (i = 1) Then
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.ctrait. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .ctrait(0, 0.1)
                    '     A1 = ARC(CENTRE(poynt(BAS(S5))), poynt(0!, AFCov(1) + A(310)), 240!)
                    '     AN2=ANNOTA(DROIT(A1),-45.,15.,-100.,ANOTEX('                  .'))
                    'C      CALL DELGRP ( A1,AN1 )
                    '     CALL DELGRP(A1)
                    '     CALL ELIMIN(A1)
                    'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.ctrait. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .ctrait(0, 0.4)
                End If
            Next i
            For y = -1 To 1 Step 2
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .segm(-A(301) * iW, (A(343) - A(310) / 2.0!) * y, -A(301) * iW, A(343) * y)
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .segm(-A(301) * iW, A(343) * y, 0.0!, A(343) * y)
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .segm(0.0!, A(343) * y, 0.0!, (A(341) / 2.0! - A(305) - A(300) / 2.0!) * y)
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .segm(0.0!, (A(341) / 2.0! - A(305) - A(300) / 2.0!) * y, -AE(1, n) * iW, (A(341) / 2.0! - A(305) - A(300) / 2.0!) * y)
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .segm(-AE(1, n) * iW, (A(341) / 2.0! - A(305) - A(300) / 2.0!) * y, -AE(1, n) * iW, 0.0!)
            Next y
            '     CALL FINGRP
            '     CALL CONHAC(BAS(S13), DROIT(S14))
            '     H1 = HACHUR(45!, .1, 1!, 1!)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .segm((-(AE(1, n) + A(302)) / 2.0!) * iW, A(341) / 2.0!, (-(AE(1, n) + A(302)) / 2.0!) * iW, A(341) / 2.0! + A(316) + A(319))
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .segm((-(AE(1, n) + A(302)) / 2.0!) * iW, A(341) / 2.0! + A(316) + A(319), (-(AE(1, n) - A(302)) / 2.0!) * iW, A(341) / 2.0! + A(316) + A(319))
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .segm((-(AE(1, n) - A(302)) / 2.0!) * iW, A(341) / 2.0!, (-(AE(1, n) - A(302)) / 2.0!) * iW, A(341) / 2.0! + A(316) + A(319))
            '     AN7 = ANNOTA ( BAS(S17),75.,HORIZ(23.),ANOTEX('SALD. 10X10 !') )
            For y = -1 To 1 Step 2
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.ctrait. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .ctrait(0, 0.4)
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .segm(0.0!, (A(341) / 2.0! - A(305) - A(300) / 2.0!) * y, 0.0!, (A(341) / 2.0! - A(305) + A(300) / 2.0!) * y)
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .segm(-AE(1, n) * iW, (A(341) / 2.0! - A(305) - A(300) / 2.0!) * y, -AE(1, n) * iW, (A(341) / 2.0! - A(305) + A(300) / 2.0!) * y)
                '     CL5 = COTLIN (RIGTER(HAUT(S19),-2.),RIGTER(BAS(S19),-2.),V(-8.),
                '    &              PRETEX('$!'),VALUE(Scalb) , SOULIN(0.) )
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.ctrait. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .ctrait(2.0!, 0.1)
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .segm((-AE(1, n) - 5.0!) * iW, (A(341) / 2.0! - A(305)) * y, 5.0! * iW, (A(341) / 2.0! - A(305)) * y)
            Next  '230
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.ctrait. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .ctrait(2.0!, 0.1)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .segm((-AE(1, n) - 8.0!) * iW, 0.0!, 8.0! * iW, 0.0!)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .segm(-AE(1, n) / 2.0! * iW, A(341) / 2.0! + A(316), -AE(1, n) / 2.0! * iW, A(341) / 2.0! + A(316) + A(319) + 5.0!)
            '     CL2 = COTLIN ( RIGTER(HAUT(S9),2.),RIGTER(DROIT(S21),16.),V(4.),
            '    &               VALUE(Scalb) , SOULIN(0.) )
            '     CL3 = COTLIN ( SYMETX(HAUT(S9),2.),RIGTER(DROIT(S21),16.),V(4.),
            '    &               VALUE(Scalb) , SOULIN(0.) )
            '     CL4 = COTLIN ( UPPER(GAUCHE(S1),-A(341)-2.),
            '    &               UPPER(DROIT (S1),-A(341)-2.),H(-28.),
            '    &               VALUE(Scalb) , SOULIN(0.) )
        End With
    End Sub

    Private Sub SubA2()
        Dim AA2(96) As Single
        Dim ifl, i As Short
        'RESTORE RestA2
        'RestA2:
        '     SEGMENTI SP .6
        'Data 31#, 441#, 615#, 441#, 615#, 441#, 615#, 31#
        'Data 615#, 31#, 51#, 31#, 51#, 31#, 51#, 323#
        'Data 51#, 323#, 31#, 323#, 31#, 323#, 31#, 441#
        '     SEGMENTI SP .2
        'Data 26#, 446#, 620#, 446#, 620#, 446#, 620#, 26#
        'Data 620#, 26#, 26#, 26#, 26#, 26#, 26#, 446#
        'Data 10#, 446#, 10#, 462#, 10#, 462#, 26#, 462#
        'Data 620#, 462#, 636#, 462#, 636#, 462#, 636#, 446#
        'Data 636#, 26#, 636#, 10#, 636#, 10#, 620#, 10#
        'Data 26#, 10#, 10#, 10#, 10#, 10#, 10#, 26#
        'Data 200#, 441#, 200#, 446#, 410#, 441#, 410#, 446#
        'Data 620#, 323#, 615#, 323#, 410#, 31#, 410#, 26#
        'Data 41#, 174.5, 26#, 174.5, 26#, 323#, 31#, 323#
        ifl = FreeFile()
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.Motore.Inizio. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        FileOpen(ifl, CStr(Monitor.Motore.Inizio.Archdir + "\SubA2.DAT"), OpenMode.Input, , OpenShare.Shared)
        For i = 1 To 96 : Input(ifl, AA2(i)) : Next
        FileClose(ifl)
        With Monitor.routines
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.ctrait. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .ctrait(0.0!, 0.6)
            For i = 1 To 24 Step 4
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .segm(AA2(i), AA2(i + 1), AA2(i + 2), AA2(i + 3))
            Next
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.ctrait. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .ctrait(0, 0.2)
            For i = 25 To 108 Step 4
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.segm. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .segm(AA2(i), AA2(i + 1), AA2(i + 2), AA2(i + 3))
            Next
        End With
    End Sub
    Public Sub InitNozzle()
        '      RESTORE 3333
        '3333    Data 268.7, 330.2, 423#, 461.5, 136.4, 136.4, 142.8, 200.8, 40#, 40#
        '      Data 45#, 45#, 20#, 20#, 25#, 30#, 230#, 290#, 375#, 405#
        '1019  For i = 28 To 47: READ eNoz(i): Next
        eNoz(28) = 268.7
        eNoz(29) = 330.2
        eNoz(30) = 423.0#
        eNoz(31) = 461.5
        eNoz(32) = 136.4
        eNoz(33) = 136.4
        eNoz(34) = 142.8
        eNoz(35) = 200.8
        eNoz(36) = 40.0#
        eNoz(37) = 40.0#
        eNoz(38) = 45.0#
        eNoz(39) = 45.0#
        eNoz(40) = 20.0#
        eNoz(41) = 20.0#
        eNoz(42) = 25.0#
        eNoz(43) = 30.0#
        eNoz(44) = 230.0#
        eNoz(45) = 290.0#
        eNoz(46) = 375.0#
        eNoz(47) = 405.0#

    End Sub

    Public Sub InitManic()
        ReDim eMan(12, 2)
        ReDim aMan(12, 2)
        ReDim PMan(10)
        '       RESTORE 3332
        '3332   Data 22#, 32#, 25#, 35#, 32#, 38#, 38#, 48#, 44#, 51#, 57#, 60#, 64#, 67#
        '     Data 76#, 79#, 92#, 86#, 108#, 92#, 127#, 108#, 159#, 121#
        '     For j = 1 To 2: For i = 1 To 12: READ eMan(i, j): Next: Next
        eMan(1, 1) = 22.0#
        eMan(2, 1) = 32.0#
        eMan(3, 1) = 25.0#
        eMan(4, 1) = 35.0#
        eMan(5, 1) = 32.0#
        eMan(6, 1) = 38.0#
        eMan(7, 1) = 38.0#
        eMan(8, 1) = 48.0#
        eMan(9, 1) = 44.0#
        eMan(10, 1) = 51.0#
        eMan(11, 1) = 57.0#
        eMan(12, 1) = 60.0#
        eMan(1, 2) = 64.0#
        eMan(2, 2) = 67.0#
        eMan(3, 2) = 76.0#
        eMan(4, 2) = 79.0#
        eMan(5, 2) = 92.0#
        eMan(6, 2) = 86.0#
        eMan(7, 2) = 108.0#
        eMan(8, 2) = 92.0#
        eMan(9, 2) = 127.0#
        eMan(10, 2) = 108.0#
        eMan(11, 2) = 159.0#
        eMan(12, 2) = 121.0#

    End Sub

    Public Sub InitMontag()
        '      ReDim eMon(110) As Single, PAMon(14) As Single, PBMon(14) As Single
        'FOR j = 1 TO 2: FOR i = 1 TO 12: READ e(i, j): NEXT: NEXT
        '3333    Data 268.7, 330.2, 423#, 461.5, 136.4, 136.4, 142.8, 200.8, 40#, 40#
        '      Data 45#, 45#, 20#, 20#, 25#, 30#, 230#, 290#, 375#, 405#
        '     RESTORE 3333
        '      For i = 28 To 47: READ eMon(i):   Next
        eMon(28) = 268.7
        eMon(29) = 330.2
        eMon(30) = 423.0#
        eMon(31) = 461.5
        eMon(32) = 136.4
        eMon(33) = 136.4
        eMon(34) = 142.8
        eMon(35) = 200.8
        eMon(36) = 40.0#
        eMon(37) = 40.0#
        eMon(38) = 45.0#
        eMon(39) = 45.0#
        eMon(40) = 20.0#
        eMon(41) = 20.0#
        eMon(42) = 25.0#
        eMon(43) = 30.0#
        eMon(44) = 230.0#
        eMon(45) = 290.0#
        eMon(46) = 375.0#
        eMon(47) = 405.0#

    End Sub

    Public Sub DisHeadX(ByRef iDis As Short)
        Dim Testo As String
        Dim X As Integer
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Monitor.routines.HCOTE. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        Call Monitor.routines.HCOTE(2.5)
        '           Do
        '              Call videoK("ZOOMSTAMEXITHELP", "")
        If iDis = 1 Then Call HEADER() Else Call COPERCHI(iDis - 1)
        '              MouseShowS
        '              iMenu = 0
        '              While iMenu <= 0
        '                 iMenu = MenuPickS(ixo, iyo, npick)
        '              Wend
        '              Do
        '                 MouseDrive 3, n1n3, ixo, iyo
        '              Loop While n1n3
        '              Select Case iMenu
        '              Case 1: 'zoom
        '                  RectPickS n, pix0, piy0, pix1, piy1
        '                  MouseHideS
        '                  If Zoomma(pix0, piy0, pix1, piy1) Then
        '                     Init200
        '                     GTextWindow pix0, piy0, pix1, piy1, True
        '                     If iDis = 1 Then Call HEADER Else Call COPERCHI(iDis - 1)
        '                  End If
        '                  BEEP
        '                  u$ = INPUT$(1)
        '                  Screen 0, 0, 0: Cls
        '                  GoTo 1230
        '              Case 2: ' redo
        '                  MouseHideS
        '                  Close #ifl1
        '                  Screen 0, 0, 0: Cls
        '                  DisplayF 0
        '                  GoTo Uno
        '              Case 3: 'go
        '                  MouseHideS
        '                  Exit Do
        '              Case 4: 'help'

        '              End Select
        '           Loop
        '81         Call videoK("ZOOMSTAMEXITHELP", "")
        '83         ApriPri Nome2$, ".PRK", 0
        '           If iDis = 1 Then Call HEADER Else Call COPERCHI(iDis - 1)
        '
        '       PARTE FINALE
        '          call refabs
        '101        Call legpri(RTrim$(Archdir) + "\FORMA2", ".PRI")
        '102        ChiudiPRI
        '           BEEP: u$ = INPUT$(1)
        '           Screen 0, 0, 0: Cls
        '           DisplayF 0
        '103        Drawing Nome2$ + ".PRK", "PSK"
        'Fine1:
        '        End If
        '        If AddDistinta = 1 Then Catena "FILE"
    End Sub

    Public Function CercaRec(ByRef R As String, ByRef D As String) As Short
        Dim i, j As Short
        Dim Rat, Diam As Single
        For i = 40 To 120 Step 20
            Rat = ReadLib(i, 2)
            If Rat = Val(R) Then
                For j = i To i + 9
                    Diam = ReadLib(j, 1)
                    If Diam = Val(D) Then
                        CercaRec = j
                        Exit Function
                    End If
                Next
            End If
        Next
        CercaRec = 0
    End Function
End Module