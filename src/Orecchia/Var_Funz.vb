Option Strict Off
Option Explicit On
Imports System.IO
Imports System.Windows.Forms.Application
Imports System.Runtime.Serialization.Formatters.Binary
Imports RoutBase1
Module Var_Funz
    <Serializable()> Structure typProblem
        Public ClientPlant As String
        Public Item As String
        Public Author As String
        Public Doc As String
        Dim Codice As Short '0 BS 1 Stoomwezen
        Dim Versione As Short '1 dimensioni ampliate
        Dim Verbose As Boolean
        Public Sub Initialize()

        End Sub
    End Structure
    <Serializable()> Public Structure typOrecchia
        Public Sigla As String
        Public di As Double
        Public ts As Double
        Public t As Double
        Public H As Double
        Public a As Double
        Public R As Double
        Public d1 As Double
        Public d As Double
        Public t1 As Double
        Public l6 As Double
        Public l2 As Double
        Public F As Double
        Public E As Double
        Public G As Double
        Public k As Double
        Public t3 As Double
        Public l7 As Double
        Public l As Double
        Public t2 As Double
        Public wl As Double
        Public we As Double
        Public alpha As Double
        Public theta1 As Double
        Public theta2 As Double
        Public W As Double
        Public li As Double
        Public ll As Double
        Public t4 As Double
        Public L10 As Double
        Public R11 As Double
        Public dff As Double
        Public We2 As Double
        Public mat1 As String
        Public mat2 As String
        Public mat3 As String
        Public mat4 As String
        Public mat5 As String
        Public sy1 As Double
        Public sa1 As Double
        Public sy2 As Double
        Public sa2 As Double
        Public sy3 As Double
        Public sa3 As Double
        Public sy4 As Double
        Public sa4 As Double
        Public sy5 As Double
        Public sa5 As Double
        Public Indmat1 As Integer
        Public Indmat2 As Integer
        Public Indmat3 As Integer
        Public Indmat4 As Integer
        Public Indmat5 As Integer
        Public Sub initialize()
            Sigla = ""
            mat1 = ""
            mat2 = ""
            mat3 = ""
            mat4 = ""
            mat5 = ""
        End Sub
    End Structure
    Public GlobalRoutines As RoutBase1.clsTrigon
    Public Monitor As clsMonitor
    Public Orecchia As typOrecchia
    Public Problem As typProblem
    Public myAssembly As System.Reflection.Assembly
    Public rmHelpStrings As Resources.ResourceManager
    Public rmHelpTopics As Resources.ResourceManager
    Public RadiceHelp As String
    Public Interrompi As Boolean
    '==========================================================
    Public Const IDH_ERR_BADSERIAL As Integer = 2022
    '==========================================================
    Private Const F3p2 As String = "{0,6:##0.##}"
    Private Const F4p1 As String = "{0,6:###0.#}"
    Private Const F4p2 As String = "{0,7:###0.##}"
    Private Const F4p3 As String = "{0,8:###0.###}"
    Private Const F5p1 As String = "{0,7:####0.#}"
    Private Const F5p2 As String = "{0,8:####0.##}"
    Private Const F5p3 As String = "{0,9:####0.###}"
    Private Const F6p2 As String = "{0,9:#####0.##}"
    Private Const F6p3 As String = "{0,10:#####0.###}"
    Private Const F7p1 As String = "{0,9:######0.#}"
    Private Const F7p2 As String = "{0,10:######0.##}"
    Private Const F7p3 As String = "{0,11:######0.###}"
    Private Const F8p1 As String = "{0,10:#######0.#}"
    Public Const Formmm As String = "####0.#"
    Public Const Formpsi As String = "#####0."
    '===========================================================
    Public path As String
    Public stamp As Short
    Public sel As String
    Public dd As Double
    Public Q As Double
    Public nomefile As String
    Public resoc As String
    Public sta2 As Double
    Public sta1 As Double
    Public rx As Double
    Public tx As Double
    Public ten As Double
    Public hb As Double
    Public ten1 As Double
    Public te As Double
    Public shea As Double
    Public bend As Double
    Public ff As Double
    Public Y As Double
    Public wh As Double
    Public p2 As Double
    Public thetaa1 As Double
    Public fh As Double
    Public spr As Double
    Public ss As Double
    Public mh As Double
    Public zh As Double
    Public hlb As Double
    Public h1 As Double
    Public ih As Double
    Public hcom As Double
    Public wv As Double
    Public thetaa2 As Double
    Public mv1 As Double
    Public fv1 As Double
    Public zv As Double
    Public vb1 As Double
    Public vt As Double
    Public vcom As Double
    Public mv2 As Double
    Public zv1 As Double
    Public vb2 As Double
    Public alpha1 As Double
    Public fc As Double
    Public sc As Double
    Public ab As Double
    Public mc As Double
    Public zc As Double
    Public sc2 As Double
    Public sccom As Double
    Public vt2 As Double
    Public vcom2 As Double
    Public sina As Double
    Public ws As Double
    Public u As Double
    Public aw As Double
    Public e1 As Double
    Public l5 As Double
    Public az As Double
    Public i1 As Double
    Public i2 As Double
    Public rg As Double
    Public zz As Double
    Public fhs As Double
    Public mt1 As Double
    Public ssp As Double
    Public ars As Double
    Public stp1 As Double
    Public stp2 As Double
    Public stcom As Double
    Public ww As Double
    Public ars2 As Double
    Public stp3 As Double
    Public stp4 As Double
    Public fvs As Double
    Public ftp As Double
    Public ftp2 As Double
    Public ftcom As Double
    Public sta4 As Double
    Public sta3 As Double
    Public sytl As Double
    Public sy22 As Double
    Public arr As Double
    Public sha2 As Double
    Public arrr As Double
    Public sha3 As Double
    Public temp As Short
    Public scrit As Short
    Public torn As Short
    Public cambio As String
    Public per As Short
    Public Matdim(4) As LibMat.MaterialeNew1
    '0 mantello 1 orecchia sup. 2 nervatura 3 rinforzo 4 orecchia inferiore
    Public user_doc As StubW2000.clsSW2000
    Public user_doc9 As StubW9.clsSW9
    Public Sub calcolaOrec()
        Dim Testo As String
        temp = 0
        With Orecchia
            Y = (.R + .l2 + .l6 + .F) - .H
            If Y < 0 Then
                Testo = "Errore nei dati. Il valore calcolato Y (" & Y.ToString & " non può essere negativo: vedi figura sulla seconda scheda dati" & vbCrLf
                Testo = Testo & "Cambiare il valore di R, l2, l6, F o H"
                MsgBox(Testo)
                Exit Sub
            End If
            If .F = 0 Then Y = 0
            If .we <= 0 Or .we > 1 Then
                MsgBox("Errore nei dati: l'efficienza di saldatura deve essere maggiore di zero e minore o uguale a uno")
                Exit Sub
            End If
            If .theta1 > 45 Or .theta2 > 45 Then
                MsgBox("Errore nei dati: gli angoli theta1 e theta2 non possono essere superiori a 45°")
                Exit Sub
            End If
            Try
                sta2 = (.sy2 * clsTrigon.MPA)
                sta1 = (.sa2 * clsTrigon.MPA)
                rx = .R
                tx = .t

                per = 1

                If .t1 > 0 Then
                    rx = .d1 / 2
                    tx = .t + (2 * .t1)
                End If

                '************************** SYSTEM ALLOWANCE *****************************
                ten = sta1 / 4
                ten1 = sta2 / 1.5

                te = ten

                If te > ten1 Then te = ten1
                shea = te * 0.85
                bend = te * 1.5

                ff = 1.25 'IMPACT FACTOR
                Dim l As ListBox.ObjectCollection = InserDati_1.DefInstance.List_err.Items
                '*************** CHECK OF STRENGHT - HORIZONTAL CONDITION ****************
                wh = .W * ff * (.ll / (2 * .li)) * clsTrigon.GRAV
                p2 = ff * .W * clsTrigon.GRAV - (2 * wh)
                thetaa1 = Math.PI * .theta1 / 180
                fh = wh * System.Math.Tan(thetaa1)
                l.Add("CHECK OF STRENGTH - HORIZONTAL CONDITION")
                '******** SEZ. A - A *********
                spr = ((2 * wh) / (2 * rx - .d)) / shea
                If spr > .t Then
                    l.Add("Spessore insufficiente Sezione A - A  " & spr.ToString(Formmm) & "  >  " & .t.ToString(Formmm) & " mm")
                    temp = 1
                End If
                ss = ((2 * wh) / (2 * rx - .d)) / tx

                '******** SEZ. B - B *********
                mh = wh * .l6
                spr = (mh / .l ^ 2) * 6 / bend
                If spr > .t Then
                    l.Add("Spessore insufficiente al bending, sezione B - B  " & spr.ToString(Formmm) & "  >  " & .t.ToString(Formmm) & " mm")
                    temp = 1
                End If
                zh = (.l ^ 2 * .t) / 6
                hb = mh / zh
                spr = fh / (.l * shea)
                If spr > .t Then
                    l.Add("Spessore insufficiente al taglio, sezione B - B  " & spr.ToString(Formmm) & "  >  " & .t.ToString(Formmm) & " mm")
                    temp = 1
                End If
                h1 = fh / (.l * .t)

                '*************************** COMBINED STRESS *****************************
                hcom = hb / 2 + System.Math.Sqrt((hb / 2) ^ 2 + h1 ^ 2)
                If hcom > bend Then
                    l.Add("Tensione combinata inaccettabile, sezione C - C  " & hcom.ToString(Formmm) & "  >  " & bend.ToString(Formmm) & " MPa")

                End If
                '************************* VERTICAL CONDITION ****************************
                wv = (ff * .W) / 2 * clsTrigon.GRAV
                thetaa2 = Math.PI * .theta2 / 180
                fv1 = wv * System.Math.Tan(thetaa2)
                l.Add("CHECK OF STRENGTH - VERTICAL CONDITION")

                '******** SEZ. A - A *********
                mv1 = fv1 * .d * 0.5
                zv = (2 * rx - .d) / 6
                zv = zv * tx ^ 2
                vb1 = mv1 / zv
                If vb1 > bend Then
                    l.Add("Tensione bending inaccettabile Sezione A - A  " & vb1.ToString(Formmm) & "  >  " & bend.ToString(Formmm) & " MPa")
                    temp = 1
                End If

                spr = wv / (2 * .R - .d) * shea
                vt = wv / ((2 * rx - .d) * tx)
                vcom = vb1 + vt
                If vcom > bend Then
                    l.Add("Tensione membrana+bending inaccettabile Sezione A - A  " & vcom.ToString(Formmm) & "  >  " & bend.ToString(Formmm) & " MPa")
                    temp = 1
                End If

                '******** SEZ. B - B *********
                mv2 = fv1 * (.l6 + (.d / 2))
                zv1 = (.l * .t ^ 2) / 6
                vb2 = mv2 / zv1
                spr = mv2 / ((.l / 6) * bend)
                If vb2 > bend Then
                    l.Add("Tensione bending insufficiente Sezione B - B  " & vb2.ToString(Formmm) & "  >  " & bend.ToString(Formmm) & " MPa")
                    temp = 1
                End If

                '******** SEZ. D - D *********
                alpha1 = Math.PI * .alpha / 180
                fc = fv1 * System.Math.Cos(alpha1)
                ab = .l * .t3
                sc = fc / (ab * .we)
                mc = fc * .l7 * System.Math.Sin(alpha1)

                zc = (.t3 ^ 2 * .l) / 6
                sc2 = mc / (zc * .we)
                sccom = sc + sc2
                If sccom > te Then
                    l.Add("Spessore insufficiente sez. D - D " & sccom.ToString(Formmm) & " > " & te.ToString(Formmm) & " mm")
                    temp = 1
                End If
                '*************************** TENSILE STRESS *****************************
                vt2 = wv / (.l * .t)
                spr = wv / (.l * shea)
                If spr > .t Then
                    l.Add("Spessore insufficiente Sezione B - B  " & spr.ToString(Formmm) & "  >  " & .t.ToString(Formmm) & " mm")
                    temp = 1
                End If

                vcom2 = vb2 + vt2
                If vcom2 > bend Then
                    l.Add("Tensione di bending inaccettabile Sezione B - B  " & vcom2.ToString(Formmm) & " > " & bend.ToString(Formmm) & " MPa")
                    temp = 1
                End If
                '************************* STRENGTH WELD PART *************************
                sina = 0.70710678
                ws = sina * .wl
                u = (.F - Y) + ws

                If .F = 0 Then
                    u = .H - (rx + .l6 + .l2) + ws
                End If
                aw = (ws * 2) + .a
                e1 = (aw * ws ^ 2 + 2 * ws * (u - ws) * (2 * ws + (u - ws))) / (2 * (ws * aw + 2 * ws * (u - ws)))
                l5 = (.l2 + .l6 + u) - e1
                dd = u - ws
                az = ws * aw + 2 * ws * dd
                i1 = (aw / 3) * u ^ 3 - (dd ^ 3 / 3) * (aw - 2 * ws) - az * (u - e1) ^ 2
                i2 = ((u * aw ^ 3) / 12) - ((dd * (aw - 2 * ws) ^ 3) / 12)
                rg = ((u - e1) ^ 2 + ((aw / 2) ^ 2)) ^ 0.5
                zz = (i1 + i2) / rg
                fhs = ((.l6 + 0.5 * .d) * fh) / (l5 + 0.5 * .d)

                '**************** SHEARING STRESS DUE TO TORSIONAL MOMENT *******************
                mt1 = wh * l5 * 0.8
                ssp = mt1 / (zz * .we)
                If ssp > shea Then
                    l.Add("Sezione saldatura insufficiente  " & ssp.ToString(Formmm) & "  >  " & shea.ToString(Formmm) & " MPa")
                    temp = 1
                End If
                ars = 2 * u * ws + aw * ws
                stp1 = fhs / (ars * .we)
                If stp1 > shea Then
                    l.Add("Sezione saldatura insufficiente  " & stp1.ToString(Formmm) & "  >  " & shea.ToString(Formmm) & " MPa")
                    temp = 1
                End If

                stp2 = wh / (ars * .we)
                If stp2 > shea Then
                    l.Add("Sezione saldatura insufficiente  " & stp2.ToString(Formmm) & "  >  " & shea.ToString(Formmm) & " MPa")
                    temp = 1
                End If

                stcom = ssp + stp1 + stp2
                If stcom > shea Then
                    l.Add("Sezione saldatura insufficiente  " & stcom.ToString(Formmm) & "  >  " & shea.ToString(Formmm) & " MPa")
                    temp = 1
                End If
                '******** SEZ. C - C saldatura al fondo *********
                ww = (.l ^ 2 * .t3) / 6
                ars2 = .l * .t3
                stp3 = wh * .l7 / (ww * .we)
                If stp3 > bend Then
                    l.Add("Sezione saldatura fondo nerv. insufficiente  ")
                    temp = 1
                End If

                stp4 = wh / (ars2 * .we)
                If stp4 > bend Then
                    l.Add("Sezione saldatura fondo nerv. insufficiente  ")
                    temp = 1
                End If
                '************************** VERTICAL CONDITION *************************
                fvs = ((.l6 + 0.5 * .d) * fv1) / (l5 + 0.5 * .d)
                ftp = wv / (ars * .we)
                If ftp > shea Then
                    l.Add("Sezione saldatura insufficiente  " & ftp.ToString(Formmm) & "  >  " & shea.ToString(Formmm) & " Kg / mm²")
                    temp = 1
                End If
                ftp2 = fvs / (ars * .we)
                ftcom = ftp + ftp2
                If ftcom > shea Then
                    l.Add("Sezione saldatura insufficiente  " & ftcom.ToString(Formmm) & "  >  " & shea.ToString(Formmm) & " Kg / mm²")
                    temp = 1
                End If
                '************************ TAILING LUG *************************
                If .We2 = 0 Then
                    temp = 0
                    Exit Sub
                End If
                sta4 = (.sy5 * clsTrigon.MPA)
                sta3 = (.sa5 * clsTrigon.MPA)
                sytl = sta3 / 4

                If sytl > sta4 / 1.5 Then sytl = sta4 / 1.5

                sy22 = sytl * 0.85
                arr = ((.We2 * 0.70710678) * .L10) * 2
                sha2 = p2 / arr

                If sha2 > sy22 Then
                    l.Add("Sezione sald. insuff. ORECCHIA DI TRATTENUTA  " & sha2.ToString(Formmm) & "  >  " & sy22.ToString(Formmm) & " Kg / mm²")

                    temp = 1

                End If
                arrr = (.R11 - (.dff / 2)) * .t4
                sha3 = (p2 / (arrr * 2))

                If sha3 > sy22 Then
                    l.Add("Spessore insuff. ORECCHIA DI TRATTENUTA  " & sha3.ToString(Formmm) & "  >  " & sy22.ToString(Formmm) & " Kg / mm²")

                    temp = 1

                End If
                If temp <> 0 Then InserDati_1.DefInstance.Resoconto.Text = "ORECCHIE DI SOLLEVAMENTO NON IDONEE"
            Catch e As Exception
                MsgBox(e.Message + vbCrLf + e.StackTrace)
            End Try
        End With
    End Sub
    Private Function StringFormat(ByVal s As Single, ByVal f As String) As String
        Return String.Format(f, s)
    End Function
    Public Sub Segnalibri()
        Dim FileSt As String = IO.Path.GetDirectoryName(nomefile) & "\" & IO.Path.GetFileNameWithoutExtension(nomefile) & ".DOC"
        Dim Templ As String = "HEADER"
        Dim Comm As String = GlobalRoutines.Adjust(Monitor.Motore.Inizio.CommPulita(nomefile), 6)
        If InserDati_1.DefInstance.CheckBox1.Checked Then Templ = "HEADNOTNOZ"
        If Not Monitor.Motore.PrepRapp(FileSt, Templ) Then Exit Sub
        Monitor.Motore.Testata()
        Monitor.Motore.Problem.FineRapp()
        Dim nomefile2 As String = Monitor.Motore.Inizio.Archdir & "\CALCOREC.DOC"
        'LIFTING LUG DIMENSION
        Monitor.Motore.ProgrInizio("Attendere la compilazione del rapporto di calcolo", "OREC")
        InserDati_1.DefInstance.Cursor = System.Windows.Forms.Cursors.WaitCursor
        InserDati_1.DefInstance.Enabled = False
        user_doc = New StubW2000.clsSW2000
        user_doc.SuperStampa(FileSt, Monitor.Motore.Inizio.VersOffice)
        Monitor.Motore.Avanzamento = 2
        DoEvents()
        If Interrompi Then GoTo ExitSub
        If InserDati_1.DefInstance.CheckBox1.Checked Then
            Monitor.Motore.Avanzamento = 20
            DoEvents()
            If Interrompi Then GoTo ExitSub
            Dim LogoFile As String = Monitor.Motore.Inizio.Archdir + "\" + Monitor.Motore.Inizio.ReadIniFile("", "Azienda", "Logo")
            Dim indirFile As String = Monitor.Motore.Inizio.Archdir + "\" + Monitor.Motore.Inizio.ReadIniFile("", "Azienda", "Indirizzo")
            If indirFile.Length > 0 Then
                If Not File.Exists(indirFile) Then indirFile = ""
            End If
            If LogoFile.Length > 0 Then
                If File.Exists(LogoFile) Then
                    If Not user_doc.Shapes7(LogoFile, indirFile) Then GoTo ExitSub
                End If
            End If
            Monitor.Motore.Avanzamento = 25
            DoEvents()
            If Interrompi Then GoTo ExitSub
            With user_doc
                .SubstitBookM("Fornitore", Monitor.Motore.Inizio.Firma) 'Config(0).Item
                '.SubstitBookM("OrdineCliente", "?") 'Config(0).Item
                .SubstitBookM("Cliente", Problem.ClientPlant)
                '.SubstitBookM("Progetto", "???")
                '.SubstitBookM("Codice", "CCC")
                '.SubstitBookM("Impianto", job.Comm.Impianto)
                '.SubstitBookM("Apparecchio", "App")
                .SubstitBookM("Item", Problem.Item)
                .SubstitBookM("Titolo", "Lifting lugs Calculations")
                '.SubstitBookM("NoForn", Comm & "SL001 Rev.0")
                '.SubstitBookM("NoClie", "??")
                .SubstitBookM("Scopo", "For approval")
                Monitor.Motore.Inizio.Immatricolazione(user_doc, Comm, "SL001")
                Monitor.Motore.Avanzamento = 30
                DoEvents()
                If Interrompi Then GoTo ExitSub
            End With
        End If
        With user_doc
            .sShowAll(True, True)
            .sOpen(nomefile2, True, 1)
            .VaiInizio("", 1)
            .Copia(1)
            .sClose(, 1)
            Monitor.Motore.Avanzamento = 35
            DoEvents()
            If Interrompi Then GoTo ExitSub
            .VaiInizio("\EndOfDoc")
            .ASMEPI()
        End With
        With Orecchia
            user_doc.SubstitBookM("mat1", .mat1.Trim, True)
            user_doc.SubstitBookM("sy1_07", StringFormat(.sy1 * clsTrigon.MPA, F5p1), True)
            user_doc.SubstitBookM("sy1", StringFormat(.sy1, F4p1), True)
            user_doc.SubstitBookM("sa1_07", StringFormat(.sa1 * clsTrigon.MPA, F5p1), True)
            user_doc.SubstitBookM("sa1", StringFormat(.sa1, F4p1), True)
            Monitor.Motore.Avanzamento = 75 / 2
            DoEvents()
            If Interrompi Then GoTo ExitSub
            user_doc.SubstitBookM("mat2", .mat1.Trim, True)
            user_doc.SubstitBookM("sy2_07", StringFormat(.sy2 * clsTrigon.MPA, F5p1), True)
            user_doc.SubstitBookM("sy2", StringFormat(.sy2, F4p1), True)
            user_doc.SubstitBookM("sa2_07", StringFormat(.sa2 * clsTrigon.MPA, F5p1), True)
            user_doc.SubstitBookM("sa2", StringFormat(.sa2, F4p1), True)
            Monitor.Motore.Avanzamento = 77 / 2
            DoEvents()
            If Interrompi Then GoTo ExitSub
            user_doc.SubstitBookM("mat3", .mat3.Trim, True)
            user_doc.SubstitBookM("sy3_07", StringFormat(.sy3 * clsTrigon.MPA, F5p1), True)
            user_doc.SubstitBookM("sy3", StringFormat(.sy3, F4p1), True)
            user_doc.SubstitBookM("sa3_07", StringFormat(.sa3 * clsTrigon.MPA, F5p1), True)
            user_doc.SubstitBookM("sa3", StringFormat(.sa3, F4p1), True)
            Monitor.Motore.Avanzamento = 80 / 2
            DoEvents()
            If Interrompi Then GoTo ExitSub
            user_doc.SubstitBookM("mat4", .mat4.Trim, True)
            user_doc.SubstitBookM("sy4_07", StringFormat(.sy4 * clsTrigon.MPA, F5p1), True)
            user_doc.SubstitBookM("sy4", StringFormat(.sy4, F4p1), True)
            user_doc.SubstitBookM("sa4_07", StringFormat(.sa4 * clsTrigon.MPA, F5p1), True)
            user_doc.SubstitBookM("sa4", StringFormat(.sa4, F4p1), True)
            Monitor.Motore.Avanzamento = 82 / 2
            DoEvents()
            If Interrompi Then GoTo ExitSub
            user_doc.SubstitBookM("mat5", .mat5.Trim, True)
            user_doc.SubstitBookM("sy5_07", StringFormat(.sy5 * clsTrigon.MPA, F5p1), True)
            user_doc.SubstitBookM("sy5", StringFormat(.sy5, F4p1), True)
            user_doc.SubstitBookM("sa5_07", StringFormat(.sa5 * clsTrigon.MPA, F5p1), True)
            user_doc.SubstitBookM("sa5", StringFormat(.sa5, F4p1), True)
            Monitor.Motore.Avanzamento = 84 / 2
            DoEvents()
            If Interrompi Then GoTo ExitSub
            'LUG DIMESION
            user_doc.SubstitBookM("di", StringFormat(.di, F5p1), True)
            user_doc.SubstitBookM("di_254", StringFormat(.di / clsTrigon.INC, F5p2), True)
            user_doc.SubstitBookM("ts", StringFormat(.ts, F5p1), True)                    '?
            user_doc.SubstitBookM("ts_254", StringFormat(.ts / clsTrigon.INC, F5p2), True)
            user_doc.SubstitBookM("t", StringFormat(.t, F5p1), True)
            user_doc.SubstitBookM("t_254", StringFormat(.t / clsTrigon.INC, F5p2), True)
            Monitor.Motore.Avanzamento = 86 / 2
            DoEvents()
            If Interrompi Then GoTo ExitSub
            user_doc.SubstitBookM("r", StringFormat(.R, F5p1), True)
            user_doc.SubstitBookM("r_254", StringFormat(.R / clsTrigon.INC, F5p2), True)
            user_doc.SubstitBookM("a", StringFormat(.a, F5p1), True)
            user_doc.SubstitBookM("a_254", StringFormat(.a / clsTrigon.INC, F5p2), True)
            user_doc.SubstitBookM("h", StringFormat(.H, F5p1), True)
            user_doc.SubstitBookM("h_254", StringFormat(.H / clsTrigon.INC, F5p2), True)
            Monitor.Motore.Avanzamento = 88 / 2
            DoEvents()
            If Interrompi Then GoTo ExitSub
            user_doc.SubstitBookM("d1", StringFormat(.d1, F5p1), True)
            user_doc.SubstitBookM("d1_254", StringFormat(.d1 / clsTrigon.INC, F5p2), True)
            user_doc.SubstitBookM("d", StringFormat(.d, F5p1), True)             '?
            user_doc.SubstitBookM("d_254", StringFormat(.d / clsTrigon.INC, F5p2), True)
            user_doc.SubstitBookM("t1", StringFormat(.t1, F5p1), True) '?
            user_doc.SubstitBookM("t1_254", StringFormat(.t1 / clsTrigon.INC, F5p2), True)
            Monitor.Motore.Avanzamento = 90 / 2
            DoEvents()
            If Interrompi Then GoTo ExitSub
            user_doc.SubstitBookM("f", StringFormat(.F, F5p1), True)
            user_doc.SubstitBookM("f_254", StringFormat(.F / clsTrigon.INC, F5p2), True)
            user_doc.SubstitBookM("e", StringFormat(.E, F5p1), True)               '?   
            user_doc.SubstitBookM("e_254", StringFormat(.E / clsTrigon.INC, F5p2), True)
            user_doc.SubstitBookM("t2", StringFormat(.t2, F5p1), True)             '?
            user_doc.SubstitBookM("t2_254", StringFormat(.t2 / clsTrigon.INC, F5p2), True)
            Monitor.Motore.Avanzamento = 92 / 2
            DoEvents()
            If Interrompi Then GoTo ExitSub
            user_doc.SubstitBookM("l7", StringFormat(.l7, F5p1), True)
            user_doc.SubstitBookM("l7_254", StringFormat(.l7 / clsTrigon.INC, F5p2), True)
            user_doc.SubstitBookM("l", StringFormat(.l, F5p1), True)
            user_doc.SubstitBookM("l_254", StringFormat(.l / clsTrigon.INC, F5p2), True)
            user_doc.SubstitBookM("t3", StringFormat(.t3, F5p1), True)
            user_doc.SubstitBookM("t3_254", StringFormat(.t3 / clsTrigon.INC, F5p2), True)
            Monitor.Motore.Avanzamento = 94 / 2
            DoEvents()
            If Interrompi Then GoTo ExitSub
            user_doc.SubstitBookM("g", StringFormat(.G, F5p1), True)
            user_doc.SubstitBookM("g_254", StringFormat(.G / clsTrigon.INC, F5p2), True)
            user_doc.SubstitBookM("h2", StringFormat(.H, F5p1), True)
            user_doc.SubstitBookM("h2_254", StringFormat(.H / clsTrigon.INC, F5p2), True)
            user_doc.SubstitBookM("l6", StringFormat(.l6, F5p1), True)
            user_doc.SubstitBookM("l6_254", StringFormat(.l6 / clsTrigon.INC, F5p2), True)
            Monitor.Motore.Avanzamento = 96 / 2
            DoEvents()
            If Interrompi Then GoTo ExitSub
            user_doc.SubstitBookM("l3", StringFormat(.l2, F5p1), True)
            user_doc.SubstitBookM("l3_254", StringFormat(.l2 / clsTrigon.INC, F5p2), True)
            user_doc.SubstitBookM("wl", StringFormat(.wl, F5p1), True)
            user_doc.SubstitBookM("wl_254", StringFormat(.wl / clsTrigon.INC, F5p2), True)
            user_doc.SubstitBookM("we", StringFormat(.we * 100, F5p1), True)
            user_doc.SubstitBookM("alpha", StringFormat(.alpha, F5p1), True)
            Monitor.Motore.Avanzamento = 98 / 2
            DoEvents()
            If Interrompi Then GoTo ExitSub
            user_doc.SubstitBookM("theta1", StringFormat(.theta1, F5p1), True)
            user_doc.SubstitBookM("theta2", StringFormat(.theta2, F5p1), True)
            user_doc.SubstitBookM("l1", StringFormat(.li, F5p1), True)
            user_doc.SubstitBookM("l1_254", StringFormat(.li / clsTrigon.INC, F5p2), True)
            user_doc.SubstitBookM("l2", StringFormat(.ll, F5p1), True)
            user_doc.SubstitBookM("l2_254", StringFormat(.ll / clsTrigon.INC, F5p2), True)
            Monitor.Motore.Avanzamento = 100 / 2
            DoEvents()
            If Interrompi Then GoTo ExitSub
            user_doc.SubstitBookM("w", StringFormat(.W, F5p1), True)
            user_doc.SubstitBookM("w_2", StringFormat(.W * clsTrigon.GRAV * clsTrigon.lb, F5p2), True)
            user_doc.SubstitBookM("ff", StringFormat(ff, F5p2), True)              '?

            'SYSTEM ALLOWANCE
            user_doc.SubstitBookM("te", StringFormat(te, F4p2), True)
            user_doc.SubstitBookM("te_07", StringFormat(te / clsTrigon.MPA, F5p2), True)
            user_doc.SubstitBookM("shea", StringFormat(shea, F4p2), True)
            Monitor.Motore.Avanzamento = 102 / 2
            DoEvents()
            If Interrompi Then GoTo ExitSub
            user_doc.SubstitBookM("shea_07", StringFormat(shea / clsTrigon.MPA, F5p2), True)
            user_doc.SubstitBookM("bend", StringFormat(bend, F4p2), True)
            user_doc.SubstitBookM("bend_07", StringFormat(bend / clsTrigon.MPA, F5p2), True)

            'CHECK OF STRENGTH
            user_doc.SubstitBookM("wh", StringFormat(wh, F6p2), True)
            user_doc.SubstitBookM("wh_2", StringFormat(wh * clsTrigon.lb, F7p2), True)
            user_doc.SubstitBookM("p2", StringFormat(p2, F6p2), True)
            Monitor.Motore.Avanzamento = 104 / 2
            DoEvents()
            If Interrompi Then GoTo ExitSub
            user_doc.SubstitBookM("p2_2", StringFormat(p2 * clsTrigon.lb, F7p2), True)
            user_doc.SubstitBookM("fh", StringFormat(fh, F6p2), True)
            user_doc.SubstitBookM("fh_2", StringFormat(fh * clsTrigon.lb, F7p2), True)


            'SECTION A - A
            'user_doc.SubstitBookM("wh1", StringFormat(wh, F6p2),True)
            'user_doc.SubstitBookM("wh1_2", StringFormat(wh * clsTrigon.lb, F7p2),True)
            user_doc.SubstitBookM("rx", StringFormat(rx, F4p2), True)
            Monitor.Motore.Avanzamento = 106 / 2
            DoEvents()
            If Interrompi Then GoTo ExitSub
            user_doc.SubstitBookM("rx_254", StringFormat(rx / clsTrigon.INC, F4p2), True)
            user_doc.SubstitBookM("tx", StringFormat(tx, F4p2), True)
            user_doc.SubstitBookM("tx_254", StringFormat(tx / clsTrigon.INC, F5p3), True)
            user_doc.SubstitBookM("ss", StringFormat(ss, F5p1), True)
            user_doc.SubstitBookM("ss_07", StringFormat(ss / clsTrigon.MPA, F5p2), True)

            'SECTION C - C
            user_doc.SubstitBookM("mh", StringFormat(mh, F8p1), True)
            Monitor.Motore.Avanzamento = 108 / 2
            DoEvents()
            If Interrompi Then GoTo ExitSub
            user_doc.SubstitBookM("mh_B", StringFormat(mh * clsTrigon.MomToBS, F8p1), True)
            'user_doc.SubstitBookM("mh1", StringFormat(mh, F8p1),True)   '?

            'Section modulus
            user_doc.SubstitBookM("zh", StringFormat(zh, F7p1), True)
            user_doc.SubstitBookM("zh_254", StringFormat(zh / (25.3 ^ 3), F5p2), True)
            user_doc.SubstitBookM("hb", StringFormat(hb, F5p2), True)
            user_doc.SubstitBookM("hb_07", StringFormat(hb / clsTrigon.MPA, F6p2), True)
            Monitor.Motore.Avanzamento = 110 / 2
            DoEvents()
            If Interrompi Then GoTo ExitSub
            'user_doc.SubstitBookM("fh1", StringFormat(fh, F6p2),True)
            'user_doc.SubstitBookM("fh1_2", StringFormat(fh * clsTrigon.lb, F7p2),True)
            user_doc.SubstitBookM("h1", StringFormat(h1, F4p3), True)
            user_doc.SubstitBookM("h1_07", StringFormat(h1 / clsTrigon.MPA, F5p2), True)

            'Combined stress
            user_doc.SubstitBookM("hcom", StringFormat(hcom, F4p3), True)
            user_doc.SubstitBookM("hcom_07", StringFormat(hcom / clsTrigon.MPA, F5p2), True)
            Monitor.Motore.Avanzamento = 112 / 2
            DoEvents()
            If Interrompi Then GoTo ExitSub
            user_doc.SubstitBookM("ww", StringFormat(ww, F7p1), True)
            user_doc.SubstitBookM("ww_254", StringFormat(ww / (clsTrigon.INC ^ 3), F5p2), True)
            user_doc.SubstitBookM("ars2", StringFormat(ars2, F6p3), True)
            user_doc.SubstitBookM("ars2_254", StringFormat(ars2 / (clsTrigon.INC ^ 2), F5p3), True)
            user_doc.SubstitBookM("stp3", StringFormat(stp3, F5p3), True)
            user_doc.SubstitBookM("stp3_07", StringFormat(stp3 / clsTrigon.MPA, F5p2), True)
            Monitor.Motore.Avanzamento = 114 / 2
            DoEvents()
            If Interrompi Then GoTo ExitSub
            user_doc.SubstitBookM("stp31", StringFormat(stp3, F5p3), True)
            user_doc.SubstitBookM("stp31_07", StringFormat(stp3 / clsTrigon.MPA, F5p2), True)
            user_doc.SubstitBookM("wv", StringFormat(wv, F6p2), True)
            user_doc.SubstitBookM("wv_2", StringFormat(wv * clsTrigon.lb, F7p2), True)
            user_doc.SubstitBookM("fv", StringFormat(fv1, F6p2), True)
            user_doc.SubstitBookM("fv_2", StringFormat(fv1 * clsTrigon.lb, F7p2), True)
            Monitor.Motore.Avanzamento = 116 / 2
            DoEvents()
            If Interrompi Then GoTo ExitSub
            'SECTION A - A
            user_doc.SubstitBookM("mv1", StringFormat(mv1, F8p1), True)
            user_doc.SubstitBookM("mv1_B", StringFormat(mv1 * clsTrigon.MomToBS, F8p1), True)
            'user_doc.SubstitBookM("mv11", StringFormat(mv1, F8p1),True)
            user_doc.SubstitBookM("zv", StringFormat(zv, F7p2), True)
            user_doc.SubstitBookM("zv_254", StringFormat(zv / (clsTrigon.INC ^ 3), F5p2), True)
            user_doc.SubstitBookM("vb", StringFormat(vb1, F4p3), True)
            Monitor.Motore.Avanzamento = 118 / 2
            DoEvents()
            If Interrompi Then GoTo ExitSub
            user_doc.SubstitBookM("vb_07", StringFormat(vb1 / (clsTrigon.MPA), F5p2), True)
            user_doc.SubstitBookM("vt", StringFormat(vt, F4p3), True)
            user_doc.SubstitBookM("vt_07", StringFormat(vt / clsTrigon.MPA, F5p2), True)
            user_doc.SubstitBookM("vcom", StringFormat(vcom, F4p3), True)
            user_doc.SubstitBookM("vcom_07", StringFormat(vcom / clsTrigon.MPA, F5p2), True)
            Monitor.Motore.Avanzamento = 120 / 2
            DoEvents()
            If Interrompi Then GoTo ExitSub
            'SECTION C - C
            user_doc.SubstitBookM("mv2", StringFormat(mv2, F8p1), True)
            Monitor.Motore.Avanzamento = 121 / 2
            DoEvents()
            If Interrompi Then GoTo ExitSub
            user_doc.SubstitBookM("mv2_B", StringFormat(mv2 * clsTrigon.MomToBS, F8p1), True)
            '   user_doc.SubstitBookM("mv21", StringFormat(mv2, F8p1),True)
            user_doc.SubstitBookM("zv1", StringFormat(zv1, F7p1), True)
            user_doc.SubstitBookM("zv1_254", StringFormat(zv1 / (clsTrigon.INC ^ 3), F5p2), True)
            user_doc.SubstitBookM("vb2", StringFormat(vb2, F4p3), True)
            user_doc.SubstitBookM("vb2_07", StringFormat(vb2 / clsTrigon.MPA, F5p2), True)
            Monitor.Motore.Avanzamento = 122 / 2
            DoEvents()
            If Interrompi Then GoTo ExitSub
            user_doc.SubstitBookM("vt2", StringFormat(vt2, F4p3), True)
            user_doc.SubstitBookM("vt2_07", StringFormat(vt2 / clsTrigon.MPA, F5p2), True)
            user_doc.SubstitBookM("vcom2", StringFormat(vcom2, F4p3), True)
            user_doc.SubstitBookM("vcom2_07", StringFormat(vcom2 / clsTrigon.MPA, F5p2), True)
            Monitor.Motore.Avanzamento = 123 / 2
            DoEvents()
            If Interrompi Then GoTo ExitSub
            'SECTION D - D
            user_doc.SubstitBookM("fc", StringFormat(fc, F7p3), True)
            user_doc.SubstitBookM("fc_2", StringFormat(fc * clsTrigon.lb, F7p3), True)
            Monitor.Motore.Avanzamento = 125 / 2
            DoEvents()
            If Interrompi Then GoTo ExitSub
            user_doc.SubstitBookM("ab", StringFormat(ab, F6p3), True)
            user_doc.SubstitBookM("ab_254", StringFormat(ab / (clsTrigon.INC ^ 2), F5p3), True)
            user_doc.SubstitBookM("sc", StringFormat(sc, F7p3), True)
            user_doc.SubstitBookM("sc_07", StringFormat(sc / clsTrigon.MPA, F7p3), True)
            user_doc.SubstitBookM("mc", StringFormat(mc, F8p1), True)
            user_doc.SubstitBookM("mc_B", StringFormat(mc * clsTrigon.MomToBS, F8p1), True)
            Monitor.Motore.Avanzamento = 130 / 2
            DoEvents()
            If Interrompi Then GoTo ExitSub
            user_doc.SubstitBookM("zc", StringFormat(zc, F7p1), True)
            user_doc.SubstitBookM("zc_254", StringFormat(zc / (clsTrigon.INC ^ 3), F5p2), True)
            user_doc.SubstitBookM("sc2", StringFormat(sc2, F7p3), True)
            user_doc.SubstitBookM("sc2_07", StringFormat(sc2 / clsTrigon.MPA, F7p3), True)
            user_doc.SubstitBookM("sccom", StringFormat(sccom, F5p3), True)
            user_doc.SubstitBookM("sccom_07", StringFormat(sccom / clsTrigon.MPA, F5p3), True)
            Monitor.Motore.Avanzamento = 135 / 2
            DoEvents()
            If Interrompi Then GoTo ExitSub
            'CHECK OF STRENGHT AT WELD PART
            user_doc.SubstitBookM("ws", StringFormat(ws, F4p2), True)
            user_doc.SubstitBookM("ws_254", StringFormat(ws / clsTrigon.INC, F4p3), True)
            user_doc.SubstitBookM("l5", StringFormat(l5, F5p2), True)
            user_doc.SubstitBookM("l5_254", StringFormat(l5 / clsTrigon.INC, F5p3), True)
            user_doc.SubstitBookM("Y", StringFormat(Y, F5p2), True)
            user_doc.SubstitBookM("Y_254", StringFormat(Y / clsTrigon.INC, F5p3), True)
            user_doc.SubstitBookM("U", StringFormat(u, F5p2), True)
            user_doc.SubstitBookM("U_254", StringFormat(u / clsTrigon.INC, F5p3), True)
            Monitor.Motore.Avanzamento = 140 / 2
            DoEvents()
            If Interrompi Then GoTo ExitSub
            user_doc.SubstitBookM("fhs", StringFormat(fhs, F6p2), True)
            user_doc.SubstitBookM("fhs_2", StringFormat(fhs * clsTrigon.lb, F7p2), True)
            user_doc.SubstitBookM("e1", StringFormat(e1, F4p1), True)
            user_doc.SubstitBookM("e1_254", StringFormat(e1 / clsTrigon.INC, F3p2), True)
            user_doc.SubstitBookM("az", StringFormat(az, F5p2), True)
            user_doc.SubstitBookM("az_254", StringFormat(az / (clsTrigon.INC ^ 2), F5p3), True)
            user_doc.SubstitBookM("i1", StringFormat(i1, F8p1), True)
            user_doc.SubstitBookM("i1_254", StringFormat(i1 / (clsTrigon.INC ^ 4), F7p2), True)
            user_doc.SubstitBookM("i2", StringFormat(i2, F8p1), True)
            Monitor.Motore.Avanzamento = 145 / 2
            DoEvents()
            If Interrompi Then GoTo ExitSub
            user_doc.SubstitBookM("i2_254", StringFormat(i2 / (clsTrigon.INC ^ 4), F7p2), True)
            user_doc.SubstitBookM("rg", StringFormat(rg, F4p1), True)
            user_doc.SubstitBookM("rg_254", StringFormat(rg / clsTrigon.INC, F3p2), True)
            user_doc.SubstitBookM("zz", StringFormat(zz, F8p1), True)
            user_doc.SubstitBookM("zz_254", StringFormat(zz / (clsTrigon.INC ^ 3), F7p2), True)
            user_doc.SubstitBookM("mt1", StringFormat(mt1, F8p1), True)
            Monitor.Motore.Avanzamento = 150 / 2
            DoEvents()
            If Interrompi Then GoTo ExitSub
            user_doc.SubstitBookM("mt1_B", StringFormat(mt1 * clsTrigon.MomToBS, F8p1), True)
            user_doc.SubstitBookM("ssp", StringFormat(ssp, F4p3), True)
            user_doc.SubstitBookM("ssp_07", StringFormat(ssp / clsTrigon.MPA, F5p2), True)
            'user_doc.SubstitBookM("fhs1", StringFormat(fhs, F6p2),True)
            'user_doc.SubstitBookM("fhs1_2", StringFormat(fhs * clsTrigon.lb, F7p2),True)
            user_doc.SubstitBookM("ars", StringFormat(ars, F5p1), True)
            Monitor.Motore.Avanzamento = 155 / 2
            DoEvents()
            If Interrompi Then GoTo ExitSub
            user_doc.SubstitBookM("ars_254", StringFormat(ars / (clsTrigon.INC ^ 2), F5p2), True)
            user_doc.SubstitBookM("stp1", StringFormat(stp1, F4p3), True)
            user_doc.SubstitBookM("stp1_07", StringFormat(stp1 / clsTrigon.MPA, F5p2), True)
            'user_doc.SubstitBookM("wh2", StringFormat(wh, F6p2),True)
            'user_doc.SubstitBookM("wh2_2", StringFormat(wh * clsTrigon.lb, F7p2),True)
            user_doc.SubstitBookM("stp2", StringFormat(stp2, F4p3), True)
            Monitor.Motore.Avanzamento = 160 / 2
            DoEvents()
            If Interrompi Then GoTo ExitSub
            user_doc.SubstitBookM("stp2_07", StringFormat(stp2 / clsTrigon.MPA, F5p2), True)
            user_doc.SubstitBookM("stcom", StringFormat(stcom, F4p3), True)
            user_doc.SubstitBookM("stcom_07", StringFormat(stcom / clsTrigon.MPA, F5p2), True)
            user_doc.SubstitBookM("fvs", StringFormat(fvs, F6p2), True)
            user_doc.SubstitBookM("fvs_2", StringFormat(fvs * clsTrigon.lb, F7p2), True)
            'user_doc.SubstitBookM("wv1", StringFormat(wv, F6p2),True)
            Monitor.Motore.Avanzamento = 165 / 2
            DoEvents()
            If Interrompi Then GoTo ExitSub
            'user_doc.SubstitBookM("wv1_2", StringFormat(wv * clsTrigon.lb, F7p2),True)
            user_doc.SubstitBookM("ftp", StringFormat(ftp, F4p3), True)
            user_doc.SubstitBookM("ftp_07", StringFormat(ftp / clsTrigon.MPA, F5p2), True)
            'user_doc.SubstitBookM("fvs1", StringFormat(fvs, F6p2),True)
            'user_doc.SubstitBookM("fvs1_2", StringFormat(fvs * clsTrigon.lb, F7p2),True)
            user_doc.SubstitBookM("ftp2", StringFormat(ftp2, F4p3), True)
            user_doc.SubstitBookM("ftp2_07", StringFormat(ftp2 / clsTrigon.MPA, F5p2), True)
            user_doc.SubstitBookM("ftcom", StringFormat(ftcom, F4p3), True)
            user_doc.SubstitBookM("ftcom_07", StringFormat(ftcom / clsTrigon.MPA, F5p2), True)
            Monitor.Motore.Avanzamento = 175 / 2
            DoEvents()
            If Interrompi Then GoTo ExitSub
            'TAILING LUG CALCULATION
            'LUG DIMENSION
            user_doc.SubstitBookM("r11", StringFormat(.R11, F5p1), True)
            user_doc.SubstitBookM("r11_254", StringFormat(.R11 / clsTrigon.INC, F5p2), True)
            user_doc.SubstitBookM("t4", StringFormat(.t4, F5p1), True)
            user_doc.SubstitBookM("t4_254", StringFormat(.t4 / clsTrigon.INC, F5p2), True)
            user_doc.SubstitBookM("l10", StringFormat(.L10, F5p1), True)
            user_doc.SubstitBookM("l10_254", StringFormat(.L10 / clsTrigon.INC, F5p2), True)
            Monitor.Motore.Avanzamento = 180 / 2
            DoEvents()
            If Interrompi Then GoTo ExitSub
            user_doc.SubstitBookM("dff", StringFormat(.dff, F5p1), True)
            user_doc.SubstitBookM("dff_254", StringFormat(.dff / clsTrigon.INC, F5p2), True)
            user_doc.SubstitBookM("we2", StringFormat(.We2, F5p1), True)
            user_doc.SubstitBookM("we2_254", StringFormat(.We2 / clsTrigon.INC, F5p2), True)

            'SYSTEM ALLOWANCE
            'LIFTING LUG
            user_doc.SubstitBookM("sytl", StringFormat(sytl, F4p2), True)
            user_doc.SubstitBookM("sytl_07", StringFormat(sytl / clsTrigon.MPA, F5p2), True)
            Monitor.Motore.Avanzamento = 185 / 2
            DoEvents()
            If Interrompi Then GoTo ExitSub
            user_doc.SubstitBookM("sy22", StringFormat(sy22, F4p2), True)
            user_doc.SubstitBookM("sy22_07", StringFormat(sy22 / clsTrigon.MPA, F5p2), True)
            user_doc.SubstitBookM("arr", StringFormat(arr, F6p3), True)
            user_doc.SubstitBookM("arr_254", StringFormat(arr / (clsTrigon.INC ^ 2), F5p3), True)
            user_doc.SubstitBookM("sha2", StringFormat(sha2, F5p2), True)
            Monitor.Motore.Avanzamento = 190 / 2
            DoEvents()
            If Interrompi Then GoTo ExitSub
            user_doc.SubstitBookM("sha2_07", StringFormat(sha2 / clsTrigon.MPA, F6p2), True)
            user_doc.SubstitBookM("arrr", StringFormat(arrr, F6p3), True)
            user_doc.SubstitBookM("arrr_254", StringFormat(arrr / (clsTrigon.INC ^ 2), F5p3), True)
            user_doc.SubstitBookM("sha3", StringFormat(sha3, F5p2), True)
            user_doc.SubstitBookM("sha3_07", StringFormat(sha3 / clsTrigon.MPA, F6p2), True)
            Monitor.Motore.Avanzamento = 200 / 2
            DoEvents()
            If Interrompi Then GoTo ExitSub
        End With
ExitSub:
        Monitor.Motore.ProgrAmmazza()
        InserDati_1.DefInstance.Enabled = True
        If Not user_doc Is Nothing Then user_doc.Massimizza()
        InserDati_1.DefInstance.Cursor = System.Windows.Forms.Cursors.Default
    End Sub
    Public Sub Segnalibri9()
        Dim FileSt As String = IO.Path.GetDirectoryName(nomefile) & "\" & IO.Path.GetFileNameWithoutExtension(nomefile) & ".DOC"
        Dim Templ As String = "HEADER"
        Dim Comm As String = GlobalRoutines.Adjust(Monitor.Motore.Inizio.CommPulita(nomefile), 6)
        If InserDati_1.DefInstance.CheckBox1.Checked Then Templ = "HEADNOTNOZ"
        If Not Monitor.Motore.PrepRapp(FileSt, Templ) Then Exit Sub
        Monitor.Motore.Testata()
        Monitor.Motore.Problem.FineRapp()
        Dim nomefile2 As String = Monitor.Motore.Inizio.Archdir & "\CALCOREC.DOC"
        'LIFTING LUG DIMENSION
        Monitor.Motore.ProgrInizio("Attendere la compilazione del rapporto di calcolo", "OREC")
        InserDati_1.DefInstance.Cursor = System.Windows.Forms.Cursors.WaitCursor
        InserDati_1.DefInstance.Enabled = False
        user_doc9 = New StubW9.clsSW9
        user_doc9.SuperStampa(FileSt, Monitor.Motore.Inizio.VersOffice)
        Monitor.Motore.Avanzamento = 2
        DoEvents()
        If Interrompi Then GoTo ExitSub
        If InserDati_1.DefInstance.CheckBox1.Checked Then
            Monitor.Motore.Avanzamento = 20
            DoEvents()
            If Interrompi Then GoTo ExitSub
            Dim LogoFile As String = Monitor.Motore.Inizio.Archdir + "\" + Monitor.Motore.Inizio.ReadIniFile("", "Azienda", "Logo")
            Dim indirFile As String = Monitor.Motore.Inizio.Archdir + "\" + Monitor.Motore.Inizio.ReadIniFile("", "Azienda", "Indirizzo")
            If indirFile.Length > 0 Then
                If Not File.Exists(indirFile) Then indirFile = ""
            End If
            If LogoFile.Length > 0 Then
                If File.Exists(LogoFile) Then
                    If Not user_doc9.Shapes7(LogoFile, indirFile) Then GoTo ExitSub
                End If
            End If
            Monitor.Motore.Avanzamento = 25
            DoEvents()
            If Interrompi Then GoTo ExitSub
            With user_doc9
                .SubstitBookM("Fornitore", Monitor.Motore.Inizio.Firma) 'Config(0).Item
                '.SubstitBookM("OrdineCliente", "?") 'Config(0).Item
                .SubstitBookM("Cliente", Problem.ClientPlant)
                '.SubstitBookM("Progetto", "???")
                '.SubstitBookM("Codice", "CCC")
                '.SubstitBookM("Impianto", job.Comm.Impianto)
                '.SubstitBookM("Apparecchio", "App")
                .SubstitBookM("Item", Problem.Item)
                .SubstitBookM("Titolo", "Lifting lugs Calculations")
                '.SubstitBookM("NoForn", Comm & "SL001 Rev.0")
                '.SubstitBookM("NoClie", "??")
                .SubstitBookM("Scopo", "For approval")
                Monitor.Motore.Inizio.Immatricolazione(user_doc9, Comm, "SL001")
                Monitor.Motore.Avanzamento = 30
                DoEvents()
                If Interrompi Then GoTo ExitSub
            End With
        End If
        With user_doc9
            .sShowAll(True, True)
            .sOpen(nomefile2, True, 1)
            .VaiInizio("", 1)
            .Copia(1)
            .sClose(, 1)
            Monitor.Motore.Avanzamento = 35
            DoEvents()
            If Interrompi Then GoTo ExitSub
            .VaiInizio("\EndOfDoc")
            .ASMEPI()
        End With
        With Orecchia
            user_doc9.SubstitBookM("mat1", .mat1.Trim, True)
            user_doc9.SubstitBookM("sy1_07", StringFormat(.sy1 * clsTrigon.MPA, F5p1), True)
            user_doc9.SubstitBookM("sy1", StringFormat(.sy1, F4p1), True)
            user_doc9.SubstitBookM("sa1_07", StringFormat(.sa1 * clsTrigon.MPA, F5p1), True)
            user_doc9.SubstitBookM("sa1", StringFormat(.sa1, F4p1), True)
            Monitor.Motore.Avanzamento = 75 / 2
            DoEvents()
            If Interrompi Then GoTo ExitSub
            user_doc9.SubstitBookM("mat2", .mat1.Trim, True)
            user_doc9.SubstitBookM("sy2_07", StringFormat(.sy2 * clsTrigon.MPA, F5p1), True)
            user_doc9.SubstitBookM("sy2", StringFormat(.sy2, F4p1), True)
            user_doc9.SubstitBookM("sa2_07", StringFormat(.sa2 * clsTrigon.MPA, F5p1), True)
            user_doc9.SubstitBookM("sa2", StringFormat(.sa2, F4p1), True)
            Monitor.Motore.Avanzamento = 77 / 2
            DoEvents()
            If Interrompi Then GoTo ExitSub
            user_doc9.SubstitBookM("mat3", .mat3.Trim, True)
            user_doc9.SubstitBookM("sy3_07", StringFormat(.sy3 * clsTrigon.MPA, F5p1), True)
            user_doc9.SubstitBookM("sy3", StringFormat(.sy3, F4p1), True)
            user_doc9.SubstitBookM("sa3_07", StringFormat(.sa3 * clsTrigon.MPA, F5p1), True)
            user_doc9.SubstitBookM("sa3", StringFormat(.sa3, F4p1), True)
            Monitor.Motore.Avanzamento = 80 / 2
            DoEvents()
            If Interrompi Then GoTo ExitSub
            user_doc9.SubstitBookM("mat4", .mat4.Trim, True)
            user_doc9.SubstitBookM("sy4_07", StringFormat(.sy4 * clsTrigon.MPA, F5p1), True)
            user_doc9.SubstitBookM("sy4", StringFormat(.sy4, F4p1), True)
            user_doc9.SubstitBookM("sa4_07", StringFormat(.sa4 * clsTrigon.MPA, F5p1), True)
            user_doc9.SubstitBookM("sa4", StringFormat(.sa4, F4p1), True)
            Monitor.Motore.Avanzamento = 82 / 2
            DoEvents()
            If Interrompi Then GoTo ExitSub
            user_doc9.SubstitBookM("mat5", .mat5.Trim, True)
            user_doc9.SubstitBookM("sy5_07", StringFormat(.sy5 * clsTrigon.MPA, F5p1), True)
            user_doc9.SubstitBookM("sy5", StringFormat(.sy5, F4p1), True)
            user_doc9.SubstitBookM("sa5_07", StringFormat(.sa5 * clsTrigon.MPA, F5p1), True)
            user_doc9.SubstitBookM("sa5", StringFormat(.sa5, F4p1), True)
            Monitor.Motore.Avanzamento = 84 / 2
            DoEvents()
            If Interrompi Then GoTo ExitSub
            'LUG DIMESION
            user_doc9.SubstitBookM("di", StringFormat(.di, F5p1), True)
            user_doc9.SubstitBookM("di_254", StringFormat(.di / clsTrigon.INC, F5p2), True)
            user_doc9.SubstitBookM("ts", StringFormat(.ts, F5p1), True)                    '?
            user_doc9.SubstitBookM("ts_254", StringFormat(.ts / clsTrigon.INC, F5p2), True)
            user_doc9.SubstitBookM("t", StringFormat(.t, F5p1), True)
            user_doc9.SubstitBookM("t_254", StringFormat(.t / clsTrigon.INC, F5p2), True)
            Monitor.Motore.Avanzamento = 86 / 2
            DoEvents()
            If Interrompi Then GoTo ExitSub
            user_doc9.SubstitBookM("r", StringFormat(.R, F5p1), True)
            user_doc9.SubstitBookM("r_254", StringFormat(.R / clsTrigon.INC, F5p2), True)
            user_doc9.SubstitBookM("a", StringFormat(.a, F5p1), True)
            user_doc9.SubstitBookM("a_254", StringFormat(.a / clsTrigon.INC, F5p2), True)
            user_doc9.SubstitBookM("h", StringFormat(.H, F5p1), True)
            user_doc9.SubstitBookM("h_254", StringFormat(.H / clsTrigon.INC, F5p2), True)
            Monitor.Motore.Avanzamento = 88 / 2
            DoEvents()
            If Interrompi Then GoTo ExitSub
            user_doc9.SubstitBookM("d1", StringFormat(.d1, F5p1), True)
            user_doc9.SubstitBookM("d1_254", StringFormat(.d1 / clsTrigon.INC, F5p2), True)
            user_doc9.SubstitBookM("d", StringFormat(.d, F5p1), True)             '?
            user_doc9.SubstitBookM("d_254", StringFormat(.d / clsTrigon.INC, F5p2), True)
            user_doc9.SubstitBookM("t1", StringFormat(.t1, F5p1), True) '?
            user_doc9.SubstitBookM("t1_254", StringFormat(.t1 / clsTrigon.INC, F5p2), True)
            Monitor.Motore.Avanzamento = 90 / 2
            DoEvents()
            If Interrompi Then GoTo ExitSub
            user_doc9.SubstitBookM("f", StringFormat(.F, F5p1), True)
            user_doc9.SubstitBookM("f_254", StringFormat(.F / clsTrigon.INC, F5p2), True)
            user_doc9.SubstitBookM("e", StringFormat(.E, F5p1), True)               '?   
            user_doc9.SubstitBookM("e_254", StringFormat(.E / clsTrigon.INC, F5p2), True)
            user_doc9.SubstitBookM("t2", StringFormat(.t2, F5p1), True)             '?
            user_doc9.SubstitBookM("t2_254", StringFormat(.t2 / clsTrigon.INC, F5p2), True)
            Monitor.Motore.Avanzamento = 92 / 2
            DoEvents()
            If Interrompi Then GoTo ExitSub
            user_doc9.SubstitBookM("l7", StringFormat(.l7, F5p1), True)
            user_doc9.SubstitBookM("l7_254", StringFormat(.l7 / clsTrigon.INC, F5p2), True)
            user_doc9.SubstitBookM("l", StringFormat(.l, F5p1), True)
            user_doc9.SubstitBookM("l_254", StringFormat(.l / clsTrigon.INC, F5p2), True)
            user_doc9.SubstitBookM("t3", StringFormat(.t3, F5p1), True)
            user_doc9.SubstitBookM("t3_254", StringFormat(.t3 / clsTrigon.INC, F5p2), True)
            Monitor.Motore.Avanzamento = 94 / 2
            DoEvents()
            If Interrompi Then GoTo ExitSub
            user_doc9.SubstitBookM("g", StringFormat(.G, F5p1), True)
            user_doc9.SubstitBookM("g_254", StringFormat(.G / clsTrigon.INC, F5p2), True)
            user_doc9.SubstitBookM("h2", StringFormat(.H, F5p1), True)
            user_doc9.SubstitBookM("h2_254", StringFormat(.H / clsTrigon.INC, F5p2), True)
            user_doc9.SubstitBookM("l6", StringFormat(.l6, F5p1), True)
            user_doc9.SubstitBookM("l6_254", StringFormat(.l6 / clsTrigon.INC, F5p2), True)
            Monitor.Motore.Avanzamento = 96 / 2
            DoEvents()
            If Interrompi Then GoTo ExitSub
            user_doc9.SubstitBookM("l3", StringFormat(.l2, F5p1), True)
            user_doc9.SubstitBookM("l3_254", StringFormat(.l2 / clsTrigon.INC, F5p2), True)
            user_doc9.SubstitBookM("wl", StringFormat(.wl, F5p1), True)
            user_doc9.SubstitBookM("wl_254", StringFormat(.wl / clsTrigon.INC, F5p2), True)
            user_doc9.SubstitBookM("we", StringFormat(.we * 100, F5p1), True)
            user_doc9.SubstitBookM("alpha", StringFormat(.alpha, F5p1), True)
            Monitor.Motore.Avanzamento = 98 / 2
            DoEvents()
            If Interrompi Then GoTo ExitSub
            user_doc9.SubstitBookM("theta1", StringFormat(.theta1, F5p1), True)
            user_doc9.SubstitBookM("theta2", StringFormat(.theta2, F5p1), True)
            user_doc9.SubstitBookM("l1", StringFormat(.li, F5p1), True)
            user_doc9.SubstitBookM("l1_254", StringFormat(.li / clsTrigon.INC, F5p2), True)
            user_doc9.SubstitBookM("l2", StringFormat(.ll, F5p1), True)
            user_doc9.SubstitBookM("l2_254", StringFormat(.ll / clsTrigon.INC, F5p2), True)
            Monitor.Motore.Avanzamento = 100 / 2
            DoEvents()
            If Interrompi Then GoTo ExitSub
            user_doc9.SubstitBookM("w", StringFormat(.W, F5p1), True)
            user_doc9.SubstitBookM("w_2", StringFormat(.W * clsTrigon.GRAV * clsTrigon.lb, F5p2), True)
            user_doc9.SubstitBookM("ff", StringFormat(ff, F5p2), True)              '?

            'SYSTEM ALLOWANCE
            user_doc9.SubstitBookM("te", StringFormat(te, F4p2), True)
            user_doc9.SubstitBookM("te_07", StringFormat(te / clsTrigon.MPA, F5p2), True)
            user_doc9.SubstitBookM("shea", StringFormat(shea, F4p2), True)
            Monitor.Motore.Avanzamento = 102 / 2
            DoEvents()
            If Interrompi Then GoTo ExitSub
            user_doc9.SubstitBookM("shea_07", StringFormat(shea / clsTrigon.MPA, F5p2), True)
            user_doc9.SubstitBookM("bend", StringFormat(bend, F4p2), True)
            user_doc9.SubstitBookM("bend_07", StringFormat(bend / clsTrigon.MPA, F5p2), True)

            'CHECK OF STRENGTH
            user_doc9.SubstitBookM("wh", StringFormat(wh, F6p2), True)
            user_doc9.SubstitBookM("wh_2", StringFormat(wh * clsTrigon.lb, F7p2), True)
            user_doc9.SubstitBookM("p2", StringFormat(p2, F6p2), True)
            Monitor.Motore.Avanzamento = 104 / 2
            DoEvents()
            If Interrompi Then GoTo ExitSub
            user_doc9.SubstitBookM("p2_2", StringFormat(p2 * clsTrigon.lb, F7p2), True)
            user_doc9.SubstitBookM("fh", StringFormat(fh, F6p2), True)
            user_doc9.SubstitBookM("fh_2", StringFormat(fh * clsTrigon.lb, F7p2), True)


            'SECTION A - A
            'user_doc9.SubstitBookM("wh1", StringFormat(wh, F6p2),True)
            'user_doc9.SubstitBookM("wh1_2", StringFormat(wh * clsTrigon.lb, F7p2),True)
            user_doc9.SubstitBookM("rx", StringFormat(rx, F4p2), True)
            Monitor.Motore.Avanzamento = 106 / 2
            DoEvents()
            If Interrompi Then GoTo ExitSub
            user_doc9.SubstitBookM("rx_254", StringFormat(rx / clsTrigon.INC, F4p2), True)
            user_doc9.SubstitBookM("tx", StringFormat(tx, F4p2), True)
            user_doc9.SubstitBookM("tx_254", StringFormat(tx / clsTrigon.INC, F5p3), True)
            user_doc9.SubstitBookM("ss", StringFormat(ss, F5p1), True)
            user_doc9.SubstitBookM("ss_07", StringFormat(ss / clsTrigon.MPA, F5p2), True)

            'SECTION C - C
            user_doc9.SubstitBookM("mh", StringFormat(mh, F8p1), True)
            Monitor.Motore.Avanzamento = 108 / 2
            DoEvents()
            If Interrompi Then GoTo ExitSub
            user_doc9.SubstitBookM("mh_B", StringFormat(mh * clsTrigon.MomToBS, F8p1), True)
            'user_doc9.SubstitBookM("mh1", StringFormat(mh, F8p1),True)   '?

            'Section modulus
            user_doc9.SubstitBookM("zh", StringFormat(zh, F7p1), True)
            user_doc9.SubstitBookM("zh_254", StringFormat(zh / (25.3 ^ 3), F5p2), True)
            user_doc9.SubstitBookM("hb", StringFormat(hb, F5p2), True)
            user_doc9.SubstitBookM("hb_07", StringFormat(hb / clsTrigon.MPA, F6p2), True)
            Monitor.Motore.Avanzamento = 110 / 2
            DoEvents()
            If Interrompi Then GoTo ExitSub
            'user_doc9.SubstitBookM("fh1", StringFormat(fh, F6p2),True)
            'user_doc9.SubstitBookM("fh1_2", StringFormat(fh * clsTrigon.lb, F7p2),True)
            user_doc9.SubstitBookM("h1", StringFormat(h1, F4p3), True)
            user_doc9.SubstitBookM("h1_07", StringFormat(h1 / clsTrigon.MPA, F5p2), True)

            'Combined stress
            user_doc9.SubstitBookM("hcom", StringFormat(hcom, F4p3), True)
            user_doc9.SubstitBookM("hcom_07", StringFormat(hcom / clsTrigon.MPA, F5p2), True)
            Monitor.Motore.Avanzamento = 112 / 2
            DoEvents()
            If Interrompi Then GoTo ExitSub
            user_doc9.SubstitBookM("ww", StringFormat(ww, F7p1), True)
            user_doc9.SubstitBookM("ww_254", StringFormat(ww / (clsTrigon.INC ^ 3), F5p2), True)
            user_doc9.SubstitBookM("ars2", StringFormat(ars2, F6p3), True)
            user_doc9.SubstitBookM("ars2_254", StringFormat(ars2 / (clsTrigon.INC ^ 2), F5p3), True)
            user_doc9.SubstitBookM("stp3", StringFormat(stp3, F5p3), True)
            user_doc9.SubstitBookM("stp3_07", StringFormat(stp3 / clsTrigon.MPA, F5p2), True)
            Monitor.Motore.Avanzamento = 114 / 2
            DoEvents()
            If Interrompi Then GoTo ExitSub
            user_doc9.SubstitBookM("stp31", StringFormat(stp3, F5p3), True)
            user_doc9.SubstitBookM("stp31_07", StringFormat(stp3 / clsTrigon.MPA, F5p2), True)
            user_doc9.SubstitBookM("wv", StringFormat(wv, F6p2), True)
            user_doc9.SubstitBookM("wv_2", StringFormat(wv * clsTrigon.lb, F7p2), True)
            user_doc9.SubstitBookM("fv", StringFormat(fv1, F6p2), True)
            user_doc9.SubstitBookM("fv_2", StringFormat(fv1 * clsTrigon.lb, F7p2), True)
            Monitor.Motore.Avanzamento = 116 / 2
            DoEvents()
            If Interrompi Then GoTo ExitSub
            'SECTION A - A
            user_doc9.SubstitBookM("mv1", StringFormat(mv1, F8p1), True)
            user_doc9.SubstitBookM("mv1_B", StringFormat(mv1 * clsTrigon.MomToBS, F8p1), True)
            'user_doc9.SubstitBookM("mv11", StringFormat(mv1, F8p1),True)
            user_doc9.SubstitBookM("zv", StringFormat(zv, F7p2), True)
            user_doc9.SubstitBookM("zv_254", StringFormat(zv / (clsTrigon.INC ^ 3), F5p2), True)
            user_doc9.SubstitBookM("vb", StringFormat(vb1, F4p3), True)
            Monitor.Motore.Avanzamento = 118 / 2
            DoEvents()
            If Interrompi Then GoTo ExitSub
            user_doc9.SubstitBookM("vb_07", StringFormat(vb1 / (clsTrigon.MPA), F5p2), True)
            user_doc9.SubstitBookM("vt", StringFormat(vt, F4p3), True)
            user_doc9.SubstitBookM("vt_07", StringFormat(vt / clsTrigon.MPA, F5p2), True)
            user_doc9.SubstitBookM("vcom", StringFormat(vcom, F4p3), True)
            user_doc9.SubstitBookM("vcom_07", StringFormat(vcom / clsTrigon.MPA, F5p2), True)
            Monitor.Motore.Avanzamento = 120 / 2
            DoEvents()
            If Interrompi Then GoTo ExitSub
            'SECTION C - C
            user_doc9.SubstitBookM("mv2", StringFormat(mv2, F8p1), True)
            Monitor.Motore.Avanzamento = 121 / 2
            DoEvents()
            If Interrompi Then GoTo ExitSub
            user_doc9.SubstitBookM("mv2_B", StringFormat(mv2 * clsTrigon.MomToBS, F8p1), True)
            '   user_doc9.SubstitBookM("mv21", StringFormat(mv2, F8p1),True)
            user_doc9.SubstitBookM("zv1", StringFormat(zv1, F7p1), True)
            user_doc9.SubstitBookM("zv1_254", StringFormat(zv1 / (clsTrigon.INC ^ 3), F5p2), True)
            user_doc9.SubstitBookM("vb2", StringFormat(vb2, F4p3), True)
            user_doc9.SubstitBookM("vb2_07", StringFormat(vb2 / clsTrigon.MPA, F5p2), True)
            Monitor.Motore.Avanzamento = 122 / 2
            DoEvents()
            If Interrompi Then GoTo ExitSub
            user_doc9.SubstitBookM("vt2", StringFormat(vt2, F4p3), True)
            user_doc9.SubstitBookM("vt2_07", StringFormat(vt2 / clsTrigon.MPA, F5p2), True)
            user_doc9.SubstitBookM("vcom2", StringFormat(vcom2, F4p3), True)
            user_doc9.SubstitBookM("vcom2_07", StringFormat(vcom2 / clsTrigon.MPA, F5p2), True)
            Monitor.Motore.Avanzamento = 123 / 2
            DoEvents()
            If Interrompi Then GoTo ExitSub
            'SECTION D - D
            user_doc9.SubstitBookM("fc", StringFormat(fc, F7p3), True)
            user_doc9.SubstitBookM("fc_2", StringFormat(fc * clsTrigon.lb, F7p3), True)
            Monitor.Motore.Avanzamento = 125 / 2
            DoEvents()
            If Interrompi Then GoTo ExitSub
            user_doc9.SubstitBookM("ab", StringFormat(ab, F6p3), True)
            user_doc9.SubstitBookM("ab_254", StringFormat(ab / (clsTrigon.INC ^ 2), F5p3), True)
            user_doc9.SubstitBookM("sc", StringFormat(sc, F7p3), True)
            user_doc9.SubstitBookM("sc_07", StringFormat(sc / clsTrigon.MPA, F7p3), True)
            user_doc9.SubstitBookM("mc", StringFormat(mc, F8p1), True)
            user_doc9.SubstitBookM("mc_B", StringFormat(mc * clsTrigon.MomToBS, F8p1), True)
            Monitor.Motore.Avanzamento = 130 / 2
            DoEvents()
            If Interrompi Then GoTo ExitSub
            user_doc9.SubstitBookM("zc", StringFormat(zc, F7p1), True)
            user_doc9.SubstitBookM("zc_254", StringFormat(zc / (clsTrigon.INC ^ 3), F5p2), True)
            user_doc9.SubstitBookM("sc2", StringFormat(sc2, F7p3), True)
            user_doc9.SubstitBookM("sc2_07", StringFormat(sc2 / clsTrigon.MPA, F7p3), True)
            user_doc9.SubstitBookM("sccom", StringFormat(sccom, F5p3), True)
            user_doc9.SubstitBookM("sccom_07", StringFormat(sccom / clsTrigon.MPA, F5p3), True)
            Monitor.Motore.Avanzamento = 135 / 2
            DoEvents()
            If Interrompi Then GoTo ExitSub
            'CHECK OF STRENGHT AT WELD PART
            user_doc9.SubstitBookM("ws", StringFormat(ws, F4p2), True)
            user_doc9.SubstitBookM("ws_254", StringFormat(ws / clsTrigon.INC, F4p3), True)
            user_doc9.SubstitBookM("l5", StringFormat(l5, F5p2), True)
            user_doc9.SubstitBookM("l5_254", StringFormat(l5 / clsTrigon.INC, F5p3), True)
            user_doc9.SubstitBookM("Y", StringFormat(Y, F5p2), True)
            user_doc9.SubstitBookM("Y_254", StringFormat(Y / clsTrigon.INC, F5p3), True)
            user_doc9.SubstitBookM("U", StringFormat(u, F5p2), True)
            user_doc9.SubstitBookM("U_254", StringFormat(u / clsTrigon.INC, F5p3), True)
            Monitor.Motore.Avanzamento = 140 / 2
            DoEvents()
            If Interrompi Then GoTo ExitSub
            user_doc9.SubstitBookM("fhs", StringFormat(fhs, F6p2), True)
            user_doc9.SubstitBookM("fhs_2", StringFormat(fhs * clsTrigon.lb, F7p2), True)
            user_doc9.SubstitBookM("e1", StringFormat(e1, F4p1), True)
            user_doc9.SubstitBookM("e1_254", StringFormat(e1 / clsTrigon.INC, F3p2), True)
            user_doc9.SubstitBookM("az", StringFormat(az, F5p2), True)
            user_doc9.SubstitBookM("az_254", StringFormat(az / (clsTrigon.INC ^ 2), F5p3), True)
            user_doc9.SubstitBookM("i1", StringFormat(i1, F8p1), True)
            user_doc9.SubstitBookM("i1_254", StringFormat(i1 / (clsTrigon.INC ^ 4), F7p2), True)
            user_doc9.SubstitBookM("i2", StringFormat(i2, F8p1), True)
            Monitor.Motore.Avanzamento = 145 / 2
            DoEvents()
            If Interrompi Then GoTo ExitSub
            user_doc9.SubstitBookM("i2_254", StringFormat(i2 / (clsTrigon.INC ^ 4), F7p2), True)
            user_doc9.SubstitBookM("rg", StringFormat(rg, F4p1), True)
            user_doc9.SubstitBookM("rg_254", StringFormat(rg / clsTrigon.INC, F3p2), True)
            user_doc9.SubstitBookM("zz", StringFormat(zz, F8p1), True)
            user_doc9.SubstitBookM("zz_254", StringFormat(zz / (clsTrigon.INC ^ 3), F7p2), True)
            user_doc9.SubstitBookM("mt1", StringFormat(mt1, F8p1), True)
            Monitor.Motore.Avanzamento = 150 / 2
            DoEvents()
            If Interrompi Then GoTo ExitSub
            user_doc9.SubstitBookM("mt1_B", StringFormat(mt1 * clsTrigon.MomToBS, F8p1), True)
            user_doc9.SubstitBookM("ssp", StringFormat(ssp, F4p3), True)
            user_doc9.SubstitBookM("ssp_07", StringFormat(ssp / clsTrigon.MPA, F5p2), True)
            'user_doc9.SubstitBookM("fhs1", StringFormat(fhs, F6p2),True)
            'user_doc9.SubstitBookM("fhs1_2", StringFormat(fhs * clsTrigon.lb, F7p2),True)
            user_doc9.SubstitBookM("ars", StringFormat(ars, F5p1), True)
            Monitor.Motore.Avanzamento = 155 / 2
            DoEvents()
            If Interrompi Then GoTo ExitSub
            user_doc9.SubstitBookM("ars_254", StringFormat(ars / (clsTrigon.INC ^ 2), F5p2), True)
            user_doc9.SubstitBookM("stp1", StringFormat(stp1, F4p3), True)
            user_doc9.SubstitBookM("stp1_07", StringFormat(stp1 / clsTrigon.MPA, F5p2), True)
            'user_doc9.SubstitBookM("wh2", StringFormat(wh, F6p2),True)
            'user_doc9.SubstitBookM("wh2_2", StringFormat(wh * clsTrigon.lb, F7p2),True)
            user_doc9.SubstitBookM("stp2", StringFormat(stp2, F4p3), True)
            Monitor.Motore.Avanzamento = 160 / 2
            DoEvents()
            If Interrompi Then GoTo ExitSub
            user_doc9.SubstitBookM("stp2_07", StringFormat(stp2 / clsTrigon.MPA, F5p2), True)
            user_doc9.SubstitBookM("stcom", StringFormat(stcom, F4p3), True)
            user_doc9.SubstitBookM("stcom_07", StringFormat(stcom / clsTrigon.MPA, F5p2), True)
            user_doc9.SubstitBookM("fvs", StringFormat(fvs, F6p2), True)
            user_doc9.SubstitBookM("fvs_2", StringFormat(fvs * clsTrigon.lb, F7p2), True)
            'user_doc9.SubstitBookM("wv1", StringFormat(wv, F6p2),True)
            Monitor.Motore.Avanzamento = 165 / 2
            DoEvents()
            If Interrompi Then GoTo ExitSub
            'user_doc9.SubstitBookM("wv1_2", StringFormat(wv * clsTrigon.lb, F7p2),True)
            user_doc9.SubstitBookM("ftp", StringFormat(ftp, F4p3), True)
            user_doc9.SubstitBookM("ftp_07", StringFormat(ftp / clsTrigon.MPA, F5p2), True)
            'user_doc9.SubstitBookM("fvs1", StringFormat(fvs, F6p2),True)
            'user_doc9.SubstitBookM("fvs1_2", StringFormat(fvs * clsTrigon.lb, F7p2),True)
            user_doc9.SubstitBookM("ftp2", StringFormat(ftp2, F4p3), True)
            user_doc9.SubstitBookM("ftp2_07", StringFormat(ftp2 / clsTrigon.MPA, F5p2), True)
            user_doc9.SubstitBookM("ftcom", StringFormat(ftcom, F4p3), True)
            user_doc9.SubstitBookM("ftcom_07", StringFormat(ftcom / clsTrigon.MPA, F5p2), True)
            Monitor.Motore.Avanzamento = 175 / 2
            DoEvents()
            If Interrompi Then GoTo ExitSub
            'TAILING LUG CALCULATION
            'LUG DIMENSION
            user_doc9.SubstitBookM("r11", StringFormat(.R11, F5p1), True)
            user_doc9.SubstitBookM("r11_254", StringFormat(.R11 / clsTrigon.INC, F5p2), True)
            user_doc9.SubstitBookM("t4", StringFormat(.t4, F5p1), True)
            user_doc9.SubstitBookM("t4_254", StringFormat(.t4 / clsTrigon.INC, F5p2), True)
            user_doc9.SubstitBookM("l10", StringFormat(.L10, F5p1), True)
            user_doc9.SubstitBookM("l10_254", StringFormat(.L10 / clsTrigon.INC, F5p2), True)
            Monitor.Motore.Avanzamento = 180 / 2
            DoEvents()
            If Interrompi Then GoTo ExitSub
            user_doc9.SubstitBookM("dff", StringFormat(.dff, F5p1), True)
            user_doc9.SubstitBookM("dff_254", StringFormat(.dff / clsTrigon.INC, F5p2), True)
            user_doc9.SubstitBookM("we2", StringFormat(.We2, F5p1), True)
            user_doc9.SubstitBookM("we2_254", StringFormat(.We2 / clsTrigon.INC, F5p2), True)

            'SYSTEM ALLOWANCE
            'LIFTING LUG
            user_doc9.SubstitBookM("sytl", StringFormat(sytl, F4p2), True)
            user_doc9.SubstitBookM("sytl_07", StringFormat(sytl / clsTrigon.MPA, F5p2), True)
            Monitor.Motore.Avanzamento = 185 / 2
            DoEvents()
            If Interrompi Then GoTo ExitSub
            user_doc9.SubstitBookM("sy22", StringFormat(sy22, F4p2), True)
            user_doc9.SubstitBookM("sy22_07", StringFormat(sy22 / clsTrigon.MPA, F5p2), True)
            user_doc9.SubstitBookM("arr", StringFormat(arr, F6p3), True)
            user_doc9.SubstitBookM("arr_254", StringFormat(arr / (clsTrigon.INC ^ 2), F5p3), True)
            user_doc9.SubstitBookM("sha2", StringFormat(sha2, F5p2), True)
            Monitor.Motore.Avanzamento = 190 / 2
            DoEvents()
            If Interrompi Then GoTo ExitSub
            user_doc9.SubstitBookM("sha2_07", StringFormat(sha2 / clsTrigon.MPA, F6p2), True)
            user_doc9.SubstitBookM("arrr", StringFormat(arrr, F6p3), True)
            user_doc9.SubstitBookM("arrr_254", StringFormat(arrr / (clsTrigon.INC ^ 2), F5p3), True)
            user_doc9.SubstitBookM("sha3", StringFormat(sha3, F5p2), True)
            user_doc9.SubstitBookM("sha3_07", StringFormat(sha3 / clsTrigon.MPA, F6p2), True)
            Monitor.Motore.Avanzamento = 200 / 2
            DoEvents()
            If Interrompi Then GoTo ExitSub
        End With
ExitSub:
        Monitor.Motore.ProgrAmmazza()
        InserDati_1.DefInstance.Enabled = True
        If Not user_doc9 Is Nothing Then user_doc9.Massimizza()
        InserDati_1.DefInstance.Cursor = System.Windows.Forms.Cursors.Default
    End Sub
    Public Sub CaricaCommessa()
        Monitor.Motore.Mostra(myAssembly, 2)
    End Sub

    Public Sub Salva()
        'Dim i As Short
        If Len(nomefile) = 0 Then nomefile = Monitor.Motore.Inizio.Datidir & "\" & Orecchia.Sigla & ".ORE"
        Dim fs As New FileStream(nomefile, FileMode.OpenOrCreate)
        Dim bf As New BinaryFormatter
        Problem.Versione = 1
        Orecchia.Indmat1 = Matdim(0).Indmat
        Orecchia.Indmat2 = Matdim(1).Indmat
        Orecchia.Indmat3 = Matdim(2).Indmat
        Orecchia.Indmat4 = Matdim(3).Indmat
        Orecchia.Indmat5 = Matdim(4).Indmat
        bf.Serialize(fs, Problem)
        bf.Serialize(fs, Orecchia)
        fs.Close()
    End Sub

    Public Function Leggi() As Boolean
        Leggi = False
        If Not File.Exists(nomefile) Then Exit Function
        Dim fs As New FileStream(nomefile, FileMode.Open)
        Dim bf As New BinaryFormatter
        Leggi = True
        Try
            Problem = CType(bf.Deserialize(fs), typProblem)
            Orecchia = CType(bf.Deserialize(fs), typOrecchia)
        Catch e As Exception
            Leggi = False
            fs.Close()
            If MostraAiuto(IDH_ERR_BADSERIAL, _
            ChiaviMess.MessQuestion Or ChiaviMess.MessYesNo, _
            GlobalRoutines.FormatS(Helpstringa(IDH_ERR_BADSERIAL), nomefile, e.Message)) _
            = ChiaviMess.MessSi Then
                Kill(nomefile)
                Monitor.Motore.Problem.OrdineFile -= 1
            End If
            nomefile = ""
            Exit Function
        End Try
        fs.Close()
        Monitor.Motore.Problem.ClientPlant = Problem.ClientPlant
        Monitor.Motore.Problem.Doc = Problem.Doc
        Monitor.Motore.Problem.Item = Problem.Item
        Monitor.Motore.Problem.Author = Problem.Author
        Matdim(0).Indmat = Orecchia.Indmat1
        Matdim(1).Indmat = Orecchia.Indmat2
        Matdim(2).Indmat = Orecchia.Indmat3
        Matdim(3).Indmat = Orecchia.Indmat4
        Matdim(4).Indmat = Orecchia.Indmat5
        Dim i As Integer
        For i = 0 To 4
            If Matdim(i).Indmat > 0 Then Matdim(i).RecupMat(Monitor.Motore.Inizio.Archdir)
        Next
    End Function
    Public Sub SelMat(ByRef indice As Short)
        Matdim(indice).Classe = 1
        Matdim(indice).Scelta(0, Monitor.Motore.Inizio.Archdir, Monitor.Motore.Inizio.DiscoTem)
    End Sub
    Public Function MostraAiuto(ByRef id As Integer, Optional ByRef Informa As ChiaviMess = _
                        ChiaviMess.MessCritical Or ChiaviMess.MessOkOnly, _
                        Optional ByRef mioTesto As String = "", Optional ByRef mioTitolo As String = "") _
                        As ChiaviMess
        Dim Testo, Tit As String
        If id > 0 Then
            If Len(mioTesto) = 0 Then
                Testo = Monitor.Motore.Inizio.ConvertiCr(Helpstringa(id)) ' "Il gruppo di items da montare su ventilatore a comune non è stato definito correttamente"
            Else
                Testo = Monitor.Motore.Inizio.ConvertiCr(mioTesto)
            End If
            If Len(mioTitolo) = 0 Then
                Tit = "BSDD - Messaggi di errore"
                If Not CBool(Informa And ChiaviMess.MessCritical) Then Tit = "BSDD"
            Else
                Tit = mioTitolo
            End If
            Dim Topic As String = HelpTopic(id)
            If Topic = "" Then
                MostraAiuto = Monitor.Motore.Messaggio(Testo, Informa, Tit, RadiceHelp, Topic)
            Else
                MostraAiuto = Monitor.Motore.Messaggio(Testo, Informa Or ChiaviMess.MessHelpButton, Tit, RadiceHelp, Topic)
            End If
        Else
            MsgBox("Errore sconosciuto", MsgBoxStyle.Information, "BSDD")
        End If
    End Function
    Public Function Helpstringa(ByVal id As Integer) As String
        Dim Nome As String = "str" + id.ToString.Trim
        Helpstringa = rmHelpStrings.GetString(Nome).Replace("|", vbCrLf)
    End Function
    Public Function HelpTopic(ByVal id As Integer) As String
        Dim Nome As String = "str" + id.ToString.Trim
        Dim Stringa As String
        Try
            Stringa = rmHelpTopics.GetString(Nome)
            If Stringa Is Nothing Then
                Stringa = ""
            End If
        Catch e As Exception
            'MsgBox(e.Message + vbCrLf + e.StackTrace)
            Stringa = ""
        End Try
        Return Stringa
    End Function
End Module