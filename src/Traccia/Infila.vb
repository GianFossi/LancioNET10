Option Strict On
Option Explicit On 
Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary
Imports RoutBase1
<Serializable()> Public Class typManici
    Public nCOO As Short
    Public nDGE As Short
    Public nRES As Short
    Public nPAS As Short
    Public nMTO As Short
    Public nRB1 As OggList
    Public nRB2 As OggList
End Class
<Serializable()> Public Class typrecB1
    Public LI As Integer 'indice sinistro
    Public RI As Integer 'indice destro
    Public Sigla As String
    Public Utubo As New RoutBase1.clsLinea2 'Proiezione in pianta del tubo ad U
    Public Cd As New RoutBase1.clsVec2 'Coseni direttori di Utubo
    Public Lungh As Single 'Lunghezza di Utubo
    Public Function Clone() As typrecB1
        Dim n As New typrecB1
        n.LI = LI
        n.RI = RI
        n.Sigla = Sigla
        Utubo.Copia(n.Utubo)
        Cd.copia(n.Cd)
        n.Lungh = Lungh
        Return n
    End Function
End Class
<Serializable()> Public Class typrecB2
    Public LI As Integer 'indice sinistro
    Public RI As Integer 'indice destro
    Public Raggio As Single
    Public Altezza As Single
    Public Sigla As String
    Public Utubo As New RoutBase1.clsLinea2
    Public Cd As New RoutBase1.clsVec2
    Public Lungh As Single
    Public SiglaMin As String 'Sigla tubo +vicino
    Public posizione As Short 'posizione in RM
    Public Function Clone() As typrecB2
        Dim n As New typrecB2
        n.LI = LI
        n.RI = RI
        n.Raggio = Raggio
        n.Altezza = Altezza
        n.Sigla = CStr(Sigla.Clone)
        Utubo.Copia(n.Utubo)
        Cd.copia(n.Cd)
        n.Lungh = Lungh
        n.SiglaMin = CStr(SiglaMin.Clone)
        n.posizione = posizione
        Return n
    End Function
End Class
<Serializable()> Public Class typFranco
    Public recB1 As New typrecB1
    Public recB2 As New typrecB2
    Public recB3 As New typrecB2
    Public iRecB1 As Short
    Public iRecB2 As Short
    Public Manici As New typManici
    Public NumLin As Integer
    Public NumErr As Short
    Public lApri As Integer
    Public iChiu As Short
    Public CalcolaTutto As Boolean
    Public Nuguali As Short 'contatore per stampa dati finali
    Public Utub As New RoutBase1.clsLinea2
    Public Utub1 As New RoutBase1.clsLinea2
    Public Lun As Single
    Public Lun1 As Single
    Public Raggio As Single
    Public Raggio1 As Single
    Public CC As New RoutBase1.clsVec2
    Public CC1 As New RoutBase1.clsVec2
    Public Diametro As Single
    Public SovrAlt As Single
    Public Interf As Single
    Public AltMin As Single 'lunghezza "MINALTO" diritta minima dei tubi
    Public Preciso As Single 'precisione nel calcolo distanza fra tubi
    Public Hmax As Single
    Public HCalc As Single
    Public CosAlfa As Single
    Public SinAlfa As Single
    Public dx As Single
    Public dy As Single
    Public Alt As Single
    Public Alt1 As Single
    Public GapCurve As Single
    Public Sub New()
        Alt = 0
        AltMin = 0
        Hmax = 0
    End Sub
End Class
Module Infila
    Private Const Ugu As Short = 0
    Private Const Mag As Short = 1
    Private Const Min As Short = -1
    Private Const Uno As Short = 1
    Private Const Due As Short = 2
    Private Const Tre As Short = 3
    Private Const Dieci As Short = 10
    Private Const AGiro As Double = 2 * Math.PI
    Private Const piMez As Double = Math.PI / 2
    Private Const cos30 As Double = 0.8660254
    Private Const Zero As Single = 0.0!
    Private Const SUno As Single = 1.0!
    Private Const SDue As Single = 2.0!
    Private Const STre As Single = 3.0!
    Private Const SQuattro As Single = 4.0!
    Private Const SDieci As Single = 10.0!
    Private Const SVenti As Single = 20.0!
    Private Const SCento As Single = 100.0!
    Private Const MSUno As Single = -1.0!
    Private Const LZero As Short = 0
    Private Const LUno As Short = 1
    Private Const LDue As Short = 2
    Private Const Star As String = "*"
    Private Const Dot As String = "."
    Private Const Blank As String = " "
    Private Const Slash As String = "/"
    Private Const InvSlash As String = "\"
    Private Const Nul As String = ""
    Private Const Areso As Double = 0.01 'Risoluzione per calcolo intersezione linee
    Private Const C3 As String = "###"
    Private Const CZero As String = "  0"
    Private Const VarDiametro As String = "DIAMETRO"
    Private Const VarSovrAlto As String = "SOVRALTO"
    Private Const VarInterf As String = "INTERF"
    Private Const VarMinAlto As String = "MINALTO"
    Private Const VarEkstPaso As String = "EKSTPASO"
    Private Const VarIntPaso As String = "INTPASO"
    Private Const VarPreciso As String = "PRECISO"

    Private Const ExtDGE As String = ".DGE" 'Estensioni files ASCII:dati generali
    Private Const ExtCOO As String = ".COO" 'Coordinate metriche su tracciatura
    Private Const ExtPAS As String = ".PAS" 'Coordinate in passi del reticolo
    Private Const ExtRES As String = ".RES" 'Risultati del calcolo
    Private Const ExtMTO As String = ".MTO" 'Distinta tubi
    Private Const ExtDXF As String = ".DXF"
    Private Const ExtB1 As String = ".$B1" 'Estensioni files interni
    Private Const ExtB2 As String = ".$B2"
    Private Const DimBuffer As Short = 1000 'N.B.:dimensione del buffer dei files temporanei
    'Diminuire questo valore se si ha messaggio di memoria
    'esaurita - Inutile aumentarlo oltre il massimo
    'numero di tubi per scambiatore, ma pu• essere inferiore
    Public Franco As typFranco

    Function ACADLunTXT(ByRef a As String) As Single
        ACADLunTXT = CSng(4 * Len(a) * 0.8)
    End Function

    Function Altezza() As Single
        'Ritorna l'altezza del secondo tubo che fornisce la distanza
        'minima fra i due tubi pari a Diametro
        'inizialmente Alt Š calcolata per avere certamente il tubo da montare sopra
        'Se con questo Alt Š < -SovrAlt esce subito senza altre verifiche
        'e Altezza=0
        'altrimenti calcola DistMin che deve necessariamente essere >=Diametro
        'poi abbassa per tentativi a passi pari a Diametro il tubo da montare
        'fino a trovare DistMin<Diametro
        'da l trova l'altezza che fornisce DistMin=Diametro con Newton-Raphson
        Dim Dist1, Dist0, DD As Single
        Dim H00, H11 As Single
        Dim b1, a1, a2, b2 As Single
        Dim c2, c1, D As Single
        Dim PP As New RoutBase1.clsVec2
        Dim AF1, AF2 As Single
        'altezza iniziale stimata
        Franco.Alt = Franco.Alt1 + Franco.Raggio1 - Franco.Raggio + Franco.GapCurve
        'qui determina se i segmenti proiettati si incrociano
        a2 = Franco.Utub.p1.y - Franco.Utub.P0.y : b2 = Franco.Utub.P0.X - Franco.Utub.p1.X
        If System.Math.Abs(a2 * Franco.CC1.X + b2 * Franco.CC1.y) > Areso Then
            'Condizione di NON parallelismo
            c2 = -b2 * Franco.Utub.P0.y - a2 * Franco.Utub.P0.X
            a1 = Franco.Utub1.p1.y - Franco.Utub1.P0.y : b1 = Franco.Utub1.P0.X - Franco.Utub1.p1.X : c1 = -b1 * Franco.Utub1.P0.y - a1 * Franco.Utub1.P0.X
            D = a1 * b2 - a2 * b1 'determinante
            PP.X = (b1 * c2 - b2 * c1) / D
            PP.y = (a2 * c1 - a1 * c2) / D
            AF1 = (PP.X - Franco.Utub1.P0.X) * Franco.CC1.X + (PP.y - Franco.Utub1.P0.y) * Franco.CC1.y
            AF2 = (PP.X - Franco.Utub.P0.X) * Franco.CC.X + (PP.y - Franco.Utub.P0.y) * Franco.CC.y
            If AF1 > Zero And AF1 < Franco.Lun1 Then
                'e ridefinisce l'altezza iniziale di tentativo
                Franco.Alt = CSng(Franco.Alt1 + Franco.GapCurve + System.Math.Sqrt(Franco.Raggio1 ^ 2 - (Franco.Raggio1 - AF1) ^ 2))
                Franco.Alt = CSng(Franco.Alt - System.Math.Sqrt(Franco.Raggio ^ 2 - (Franco.Raggio - AF2) ^ 2))
            End If
        End If

        Dist0 = DistMin()
        Do While Dist0 < Franco.GapCurve
            Franco.Alt = Franco.Alt + Franco.GapCurve
            Dist0 = DistMin()
        Loop
        Altezza = Zero
        If Franco.Alt < Franco.Hmax - Franco.SovrAlt Then Exit Function
        Do
            Dist0 = DistMin()
            Select Case Dist0
                Case Is > Franco.GapCurve + Franco.Preciso
                    If Franco.Alt < Franco.Hmax - Franco.SovrAlt Then Exit Function
                    Dist1 = Dist0
                    H11 = Franco.Alt
                    Franco.Alt = Franco.Alt - Franco.GapCurve
                Case Is < Franco.GapCurve - Franco.Preciso
                    H00 = Franco.Alt
                    Do
                        Franco.Alt = H00 + (Franco.GapCurve - Dist0) * (H11 - H00) / (Dist1 - Dist0)
                        DD = DistMin()
                        Select Case DD
                            Case Is > Franco.GapCurve + Franco.Preciso
                                Dist1 = DD
                                H11 = Franco.Alt
                            Case Is < Franco.GapCurve - Franco.Preciso
                                Dist0 = DD
                                H00 = Franco.Alt
                            Case Else
                                'qui ha trovato un valore abbastanza vicino
                                If Franco.Alt + Franco.SovrAlt > Zero Then Altezza = Franco.Alt + Franco.SovrAlt
                                Exit Function
                        End Select
                    Loop
                Case Else
                    'qui ha trovato un valore abbastanza vicino
                    If Franco.Alt + Franco.SovrAlt > Zero Then Altezza = Franco.Alt + Franco.SovrAlt
                    Exit Function
            End Select
        Loop
    End Function
    Function AppeB1() As Boolean
        Franco.iRecB1 = CShort(Franco.Manici.nRB1.Count + 1)
        Franco.recB1.Utubo = Franco.Utub
        Franco.recB1.Lungh = CSng(System.Math.Sqrt((Franco.recB1.Utubo.P0.X - Franco.recB1.Utubo.p1.X) ^ 2 + (Franco.recB1.Utubo.P0.y - Franco.recB1.Utubo.p1.y) ^ 2))
        Franco.recB1.Cd.X = (Franco.recB1.Utubo.p1.X - Franco.recB1.Utubo.P0.X) / Franco.recB1.Lungh
        Franco.recB1.Cd.y = (Franco.recB1.Utubo.p1.y - Franco.recB1.Utubo.P0.y) / Franco.recB1.Lungh
        Franco.Manici.nRB1.Add(Franco.recB1.Clone)
        AppeB1 = True
    End Function
    Function AppeB2() As Short
        Franco.recB2.Raggio = Franco.Raggio
        Franco.recB2.Altezza = Franco.Hmax
        Franco.recB2.Utubo = Franco.Utub
        Franco.recB2.Cd = Franco.CC
        Franco.recB2.Lungh = Franco.Lun
        Franco.recB2.Sigla = Franco.recB1.Sigla
        Franco.iRecB2 = CShort(Franco.Manici.nRB2.Count + 1)
        Franco.Manici.nRB2.Add(Franco.recB2.Clone)
        Return 0
    End Function
    Function ApriB1() As Short
        Franco.Manici.nRB1 = New OggList(1)
    End Function
    Function ApriB2(ByRef zap As Boolean) As Short
        Franco.Manici.nRB2 = New OggList(1)
    End Function
    Function ChiuB1() As Short
        Franco.Manici.nRB1.RemoveAll()
    End Function
    Function ChiuB2() As Short
        Lancio.Legacy.Serialization.LegacyBinarySerializer.EnsureEnabled()
        Dim FileRB2 As String = gencommes.Trim & ".RB2"
        File.Delete(FileRB2)
        Dim fs As New FileStream(gencommes.Trim & ".RB2", FileMode.Create)
        Dim bf As New Lancio.Legacy.Serialization.LegacyBinarySerializer
        bf.Serialize(fs, Franco.Manici.nRB2)
        fs.Close()
        Franco.Manici.nRB2.RemoveAll()
    End Function
    Function DerDerDist(ByRef CosTh As Single) As Single
        'Calcola la derivata seconda del quadrato della distanza fra i due tubi
        'per il valore CosTh
        Dim i As Short
        Dim PP As New clsVec3
        Dim p As New clsVec3
        Dim PPP As New RoutBase1.clsVec3
        Dim Tmp1, Tmp, DD As Single
        i = XYZ(p, CosTh)
        i = XYZpr(PP, CosTh)
        i = XYZse(PPP, CosTh)
        Tmp = CSng(System.Math.Sqrt(p.y * p.y + p.Z * p.Z))
        Tmp1 = SUno - Franco.Raggio1 / Tmp
        Tmp1 = Tmp1 * (PP.Z * PP.Z + p.Z * PPP.Z + PP.y * PP.y + p.y * PPP.y)
        Tmp1 = Tmp1 + PP.X * PP.X + p.X * PPP.X
        DD = CSng(SDue * (Tmp1 + Franco.Raggio1 * (p.y * PP.y + p.Z * PP.Z) ^ 2 / Tmp ^ 3))
        DerDerDist = DD
    End Function

    Function DerDist(ByRef CosTh As Single) As Single
        'Calcola la derivata del quadrato della distanza fra i due tubi
        'per il valore CosTh
        Dim i As Short
        Dim Tmp As Single
        Dim p As New RoutBase1.clsVec3
        Dim Ppr As New RoutBase1.clsVec3
        i = XYZ(p, CosTh)
        i = XYZpr(Ppr, CosTh)
        Tmp = CSng(SUno - Franco.Raggio1 / System.Math.Sqrt(p.y * p.y + p.Z * p.Z))
        DerDist = SDue * (p.X * Ppr.X + Tmp * (p.Z * Ppr.Z + p.y * Ppr.y))
    End Function

    Sub DisegnoCAD(ByRef Diametro As Single, ByRef Pext As Single, ByRef Pint As Single, ByRef FileCAD As String)
        Dim xle, xli As Single
        Dim File As String
        Dim nDGE As Short
        Dim ifl As Short
        Dim Riga As String
        Dim Form As String
        Dim Fact As Single
        Dim nCOO, NumLin As Short
        Dim xe, ye As Single
        Dim xi, yi As Single
        Dim Cy, Cx, xl As Single
        Dim Text As String
        Dim LungFile, LungAct As Integer
        Dim Stringa As String = ""
        Dim Sigla As String
        'On Local Error GoTo ErrCAD
        xle = CSng(1.5 * (Pext - Diametro)) : If xle < Zero Then xle = Diametro / 4
        xli = CSng(1.5 * (Pint - Diametro)) : If xli < Zero Then xli = Diametro / 4
        'Lunghezza segmentini tangenti di ausilio alla lettura
        File = RTrim(gencommes)
        FileCAD = File & ExtDXF
        If IO.File.Exists(FileCAD) Then
            If MsgBox("Esiste il risultato di una registrazione precedente. Vuoi sovrascriverla ?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question) = MsgBoxResult.No Then Exit Sub
        End If
        Text = "Il file DXF viene registrato sotto" & vbCrLf
        Text = Text & "il nome " & RTrim(FileCAD)
        Monitor.Motore.ProgrInizio(Text)
        nDGE = CShort(FreeFile())
        FileOpen(nDGE, FileCAD, OpenMode.Output)
        ifl = CShort(FreeFile())
        FileOpen(ifl, RTrim(Monitor.Motore.Inizio.Archdir) & "\HEADDX.DAT", OpenMode.Input, , OpenShare.Shared)
        Do
            If EOF(ifl) Then Exit Do
            Riga = LineInput(ifl)
            If InStr(Riga, "fine") > 0 Then Exit Do
            If Len(Riga) = 0 Then Exit Do
            If Asc(Riga) = 35 Then
3005:           Form = Left(Riga, 10)
                Fact = CSng(GlobalRoutines.ValVir(Right(Riga, Len(Riga) - 10)))
                PrintLine(nDGE, GlobalRoutines.FormatS(Form, Fact * Diametro))
            ElseIf Asc(Riga) = 33 Then
                PrintLine(nDGE)
            Else
                PrintLine(nDGE, Riga)
            End If
        Loop
        FileClose(ifl)

        nCOO = CShort(FreeFile())
3010:   FileOpen(nCOO, File & ExtCOO, OpenMode.Input)
        Riga = LineInput(nCOO)
        NumLin = LZero
        LungFile = CInt(LOF(nCOO))
        LungAct = Len(Riga)
        Do Until EOF(nCOO)
            If Monitor.InterrompiTrasferimento Then
                FileClose(nCOO, nDGE)
                Exit Sub
            End If
            Riga = LineInput(nCOO)
            LungAct = LungAct + Len(Riga)
            Monitor.Motore.Avanzamento = CSng(100 * LungAct / LungFile)
            Sigla = prossimo(Riga)
            If Len(Sigla) > 0 Then
                NumLin = NumLin + LUno
3030:           Stringa = prossimo(Riga) : If Len(Stringa) > 0 Then xe = CSng(GlobalRoutines.ValVir(Stringa)) Else Exit Do
                Stringa = prossimo(Riga) : If Len(Stringa) > 0 Then ye = CSng(GlobalRoutines.ValVir(Stringa)) Else Exit Do
                Stringa = prossimo(Riga) : If Len(Stringa) > 0 Then xi = CSng(GlobalRoutines.ValVir(Stringa)) Else Exit Do
                Stringa = prossimo(Riga) : If Len(Stringa) > 0 Then yi = CSng(GlobalRoutines.ValVir(Stringa)) Else Exit Do
                If Int(NumLin \ Dieci) * Dieci = NumLin Then
                    '   LOCATE 1, 38: Print Sigla;
                End If
                xl = CSng(System.Math.Sqrt((xe - xi) * (xe - xi) + (ye - yi) * (ye - yi)))
                Cx = (xe - xi) / xl : Cy = (ye - yi) / xl
3040:           PrintLine(nDGE, CZero) : PrintLine(nDGE, "INSERT")
                PrintLine(nDGE, GlobalRoutines.FormatS(C3, 8)) : PrintLine(nDGE, "0")
                PrintLine(nDGE, GlobalRoutines.FormatS(C3, 66)) : PrintLine(nDGE, "1")
                PrintLine(nDGE, GlobalRoutines.FormatS(C3, 2)) : PrintLine(nDGE, "TUBO")
                PrintLine(nDGE, GlobalRoutines.FormatS(C3, 10)) : PrintLine(nDGE, Str(xe))
                PrintLine(nDGE, GlobalRoutines.FormatS(C3, 20)) : PrintLine(nDGE, Str(ye))
                PrintLine(nDGE, CZero) : PrintLine(nDGE, "ATTRIB")
                PrintLine(nDGE, GlobalRoutines.FormatS(C3, 8)) : PrintLine(nDGE, "1")
                PrintLine(nDGE, GlobalRoutines.FormatS(C3, 10)) : PrintLine(nDGE, Str(xe - ACADLunTXT(Mid(Sigla, 2)) * Diametro * 0.09))
                PrintLine(nDGE, GlobalRoutines.FormatS(C3, 20)) : PrintLine(nDGE, Str(ye + 0.09 * Diametro))
                PrintLine(nDGE, GlobalRoutines.FormatS(C3, 40)) : PrintLine(nDGE, Str(0.18 * Diametro))
                PrintLine(nDGE, GlobalRoutines.FormatS(C3, 1)) : PrintLine(nDGE, Sigla)
                PrintLine(nDGE, GlobalRoutines.FormatS(C3, 2)) : PrintLine(nDGE, "NN")
                PrintLine(nDGE, GlobalRoutines.FormatS(C3, 70)) : PrintLine(nDGE, "0")
                PrintLine(nDGE, GlobalRoutines.FormatS(C3, 7)) : PrintLine(nDGE, "STANDARD")
                PrintLine(nDGE, GlobalRoutines.FormatS(C3, 72)) : PrintLine(nDGE, "2")
3090:           PrintLine(nDGE, GlobalRoutines.FormatS(C3, 11)) : PrintLine(nDGE, Str(xe))
                PrintLine(nDGE, GlobalRoutines.FormatS(C3, 21)) : PrintLine(nDGE, Str(ye - 0.09 * Diametro))
                PrintLine(nDGE, CZero) : PrintLine(nDGE, "SEQEND")
                PrintLine(nDGE, GlobalRoutines.FormatS(C3, 8)) : PrintLine(nDGE, "0")
                PrintLine(nDGE, CZero) : PrintLine(nDGE, "INSERT")
                PrintLine(nDGE, GlobalRoutines.FormatS(C3, 8)) : PrintLine(nDGE, "0")
                PrintLine(nDGE, GlobalRoutines.FormatS(C3, 66)) : PrintLine(nDGE, "1")
                PrintLine(nDGE, GlobalRoutines.FormatS(C3, 2)) : PrintLine(nDGE, "TUBO")
                PrintLine(nDGE, GlobalRoutines.FormatS(C3, 10)) : PrintLine(nDGE, Str(xi))
                PrintLine(nDGE, GlobalRoutines.FormatS(C3, 20)) : PrintLine(nDGE, Str(yi))
                PrintLine(nDGE, CZero) : PrintLine(nDGE, "ATTRIB")
                PrintLine(nDGE, GlobalRoutines.FormatS(C3, 8)) : PrintLine(nDGE, "1")
3140:           PrintLine(nDGE, GlobalRoutines.FormatS(C3, 10)) : PrintLine(nDGE, Str(xi - ACADLunTXT(Mid(Sigla, 2)) * Diametro * 0.175))
                PrintLine(nDGE, GlobalRoutines.FormatS(C3, 20)) : PrintLine(nDGE, Str(yi - 0.331677 * Diametro))
                PrintLine(nDGE, GlobalRoutines.FormatS(C3, 40)) : PrintLine(nDGE, Str(0.35 * Diametro))
                PrintLine(nDGE, GlobalRoutines.FormatS(C3, 1)) : PrintLine(nDGE, Mid(Sigla, 2))
                PrintLine(nDGE, GlobalRoutines.FormatS(C3, 2)) : PrintLine(nDGE, "NN")
                PrintLine(nDGE, GlobalRoutines.FormatS(C3, 70)) : PrintLine(nDGE, "0")
                PrintLine(nDGE, GlobalRoutines.FormatS(C3, 7)) : PrintLine(nDGE, "STANDARD")
                PrintLine(nDGE, GlobalRoutines.FormatS(C3, 72)) : PrintLine(nDGE, "4")
                PrintLine(nDGE, GlobalRoutines.FormatS(C3, 11)) : PrintLine(nDGE, Str(xi))
                PrintLine(nDGE, GlobalRoutines.FormatS(C3, 21)) : PrintLine(nDGE, Str(yi - 0.156873 * Diametro))
                PrintLine(nDGE, CZero) : PrintLine(nDGE, "ATTRIB")
                PrintLine(nDGE, GlobalRoutines.FormatS(C3, 8)) : PrintLine(nDGE, "1")
                PrintLine(nDGE, GlobalRoutines.FormatS(C3, 10)) : PrintLine(nDGE, Str(xi - ACADLunTXT(Left(Sigla, 1)) * Diametro * 0.175))
                PrintLine(nDGE, GlobalRoutines.FormatS(C3, 20)) : PrintLine(nDGE, Str(yi + 0.076196 * Diametro))
                PrintLine(nDGE, GlobalRoutines.FormatS(C3, 40)) : PrintLine(nDGE, Str(0.35 * Diametro))
                PrintLine(nDGE, GlobalRoutines.FormatS(C3, 1)) : PrintLine(nDGE, Left(Sigla, 1))
                PrintLine(nDGE, GlobalRoutines.FormatS(C3, 2)) : PrintLine(nDGE, "L")
                PrintLine(nDGE, GlobalRoutines.FormatS(C3, 70)) : PrintLine(nDGE, "0")
                PrintLine(nDGE, GlobalRoutines.FormatS(C3, 7)) : PrintLine(nDGE, "STANDARD")
                PrintLine(nDGE, GlobalRoutines.FormatS(C3, 72)) : PrintLine(nDGE, "4")
                PrintLine(nDGE, GlobalRoutines.FormatS(C3, 11)) : PrintLine(nDGE, Str(xi))
                PrintLine(nDGE, GlobalRoutines.FormatS(C3, 21)) : PrintLine(nDGE, Str(yi + 0.251 * Diametro))
                PrintLine(nDGE, CZero) : PrintLine(nDGE, "SEQEND")
                PrintLine(nDGE, GlobalRoutines.FormatS(C3, 8)) : PrintLine(nDGE, "0")
3190:           PrintLine(nDGE, CZero) : PrintLine(nDGE, "LINE")
                PrintLine(nDGE, GlobalRoutines.FormatS(C3, 8)) : PrintLine(nDGE, "0")
                PrintLine(nDGE, GlobalRoutines.FormatS(C3, 10)) : PrintLine(nDGE, Str(xi - Diametro * Cy / 2))
                PrintLine(nDGE, GlobalRoutines.FormatS(C3, 20)) : PrintLine(nDGE, Str(yi + Diametro * Cx / 2))
                PrintLine(nDGE, GlobalRoutines.FormatS(C3, 11)) : PrintLine(nDGE, Str(xi - Diametro * Cy / 2 + xli * Cx))
                PrintLine(nDGE, GlobalRoutines.FormatS(C3, 21)) : PrintLine(nDGE, Str(yi + Diametro * Cx / 2 + xli * Cy))
                PrintLine(nDGE, CZero) : PrintLine(nDGE, "LINE")
                PrintLine(nDGE, GlobalRoutines.FormatS(C3, 8)) : PrintLine(nDGE, "0")
                PrintLine(nDGE, GlobalRoutines.FormatS(C3, 10)) : PrintLine(nDGE, Str(xi + Diametro * Cy / 2))
                PrintLine(nDGE, GlobalRoutines.FormatS(C3, 20)) : PrintLine(nDGE, Str(yi - Diametro * Cx / 2))
                PrintLine(nDGE, GlobalRoutines.FormatS(C3, 11)) : PrintLine(nDGE, Str(xi + Diametro * Cy / 2 + xli * Cx))
                PrintLine(nDGE, GlobalRoutines.FormatS(C3, 21)) : PrintLine(nDGE, Str(yi - Diametro * Cx / 2 + xli * Cy))
                PrintLine(nDGE, CZero) : PrintLine(nDGE, "LINE")
                PrintLine(nDGE, GlobalRoutines.FormatS(C3, 8)) : PrintLine(nDGE, "0")
                PrintLine(nDGE, GlobalRoutines.FormatS(C3, 10)) : PrintLine(nDGE, Str(xe - Diametro * Cy / 2))
                PrintLine(nDGE, GlobalRoutines.FormatS(C3, 20)) : PrintLine(nDGE, Str(ye + Diametro * Cx / 2))
                PrintLine(nDGE, GlobalRoutines.FormatS(C3, 11)) : PrintLine(nDGE, Str(xe - Diametro * Cy / 2 - xle * Cx))
                PrintLine(nDGE, GlobalRoutines.FormatS(C3, 21)) : PrintLine(nDGE, Str(ye + Diametro * Cx / 2 - xle * Cy))
                PrintLine(nDGE, CZero) : PrintLine(nDGE, "LINE")
                PrintLine(nDGE, GlobalRoutines.FormatS(C3, 8)) : PrintLine(nDGE, "0")
                PrintLine(nDGE, GlobalRoutines.FormatS(C3, 10)) : PrintLine(nDGE, Str(xe + Diametro * Cy / 2))
3240:           PrintLine(nDGE, GlobalRoutines.FormatS(C3, 20)) : PrintLine(nDGE, Str(ye - Diametro * Cx / 2))
                PrintLine(nDGE, GlobalRoutines.FormatS(C3, 11)) : PrintLine(nDGE, Str(xe + Diametro * Cy / 2 - xle * Cx))
                PrintLine(nDGE, GlobalRoutines.FormatS(C3, 21)) : PrintLine(nDGE, Str(ye - Diametro * Cx / 2 - xle * Cy))
            End If
        Loop
        FileClose(nCOO)
        If Len(Stringa) > 0 Then
            '        IF NumLin THEN
            '                PRINT #nscreen, "   Trovati"; NumLin; "tubi"
            '        ELSE
            '                PRINT #nscreen, "ERRORE:nessun tubo trovato!": END
            '        END IF
        Else
            '        PRINT #nscreen, "ERRORE:dati insufficienti in riga"; NumLin; "di "; Nome; ExtCOO: END
        End If
        Call LinAX(nDGE, CSng(-0.55 * DaTos(iDat).OTL), 0, CSng(0.55 * DaTos(iDat).OTL), 0)
        Call LinAX(nDGE, 0, CSng(-0.55 * DaTos(iDat).OTL), 0, CSng(0.55 * DaTos(iDat).OTL))
        Call RaggAx(nDGE, DaTos(1).cinter)
        Call RaggAx(nDGE, DaTos(1).OTL / 2)
        Call RaggAx(nDGE, DaTos(iDat).cinter)
        Call RaggAx(nDGE, DaTos(iDat).OTL / 2)
        PrintLine(nDGE, CZero) : PrintLine(nDGE, "ENDSEC")
        PrintLine(nDGE, CZero) : PrintLine(nDGE, "EOF")
        FileClose(nDGE)
        Monitor.Motore.Avanzamento = 101
        Monitor.Motore.ProgrAmmazza()
    End Sub

    Function Dist(ByRef CosTh As Single) As Single
        'Calcola la distanza al quadrato del punto del secondo tubo individuato dal
        'CosTh compreso fra -1 e 1 all'asse del primo tubo
        'se il punto del secondo tubo Š a quota inferiore rispetto al primo
        'ritorna un valore negativo
        Dim Aux As Single
        Dim i As Short
        Dim p As New RoutBase1.clsVec3
        i = XYZ(p, CosTh)
        Aux = CSng(System.Math.Sqrt(p.y * p.y + p.Z * p.Z))
        Dist = CSng(System.Math.Sqrt((Aux - Franco.Raggio1) ^ 2 + p.X * p.X))
    End Function

    Function DistMin() As Single
        'trova la minima distanza fra i due tubi
        Dim th, DMin As Single
        Dim DD0, D, DD, DD1 As Single
        Dim th1, th0, SQ As Single
        th = SUno
        DMin = Dist(th)
        Do
            DD0 = DerDist(th) : th0 = th
            Do
                DD = Dist(th)
                DD = CSng((SUno - th * th) / (DerDerDist(th) / DD - DD0 * DD0 / SDue / DD ^ 3))
                DD = CSng(Franco.Preciso * System.Math.Sqrt(System.Math.Abs(DD)))
                If DD > 0.1 Then
                    DD = 0.1
                ElseIf DD = Zero Then
                    DD = 0.01
                End If
                th = th - DD
                If th < MSUno Then th = MSUno
                DD = DerDist(th)
                If System.Math.Sign(DD) <> System.Math.Sign(DD0) Then Exit Do
                If th = MSUno Then th = -1.01 : Exit Do
                DD0 = DD : th0 = th
            Loop
            If th < MSUno Then Exit Do
            If DD0 < Zero Then
                DD1 = DD : th1 = th
            Else
                DD1 = DD0 : DD0 = DD : th1 = th0 : th0 = th
            End If
            Do
                th = th0 - DD0 * (th1 - th0) / (DD1 - DD0)
                DD = DerDist(th)
                If System.Math.Abs(th) - SUno <> 0 Then
                    SQ = CSng(System.Math.Sqrt(SUno - th * th))
                Else
                    SQ = SUno
                End If
                Select Case DD * System.Math.Abs(th1 - th0) / SDue / Franco.Diametro / SQ
                    Case Is > Franco.Preciso
                        DD1 = DD : th1 = th
                    Case Is < -Franco.Preciso
                        DD0 = DD : th0 = th
                    Case Else
                        D = Dist(th)
                        If DMin > D Then DMin = D
                        Exit Do
                End Select
            Loop
            th = th0 : If th1 < th0 Then th = th1
        Loop Until th <= MSUno
        D = Dist(MSUno)
        If D < DMin Then DistMin = D Else DistMin = DMin
    End Function
    Function GoTopB1(ByRef Direzione As Boolean) As Boolean
        GoTopB1 = True
        If Direzione Then Franco.iRecB1 = 1 Else Franco.iRecB1 = CShort(Franco.Manici.nRB1.Count)
        If Franco.Manici.nRB1.Count = 0 Then
            Franco.iRecB1 = 0
            GoTopB1 = False
        End If
    End Function
    Function GoTopB2(ByRef Direzione As Boolean) As Boolean
        GoTopB2 = True
        If Direzione Then Franco.iRecB2 = 1 Else Franco.iRecB2 = CShort(Franco.Manici.nRB2.Count)
        If Franco.Manici.nRB2.Count = 0 Then
            Franco.iRecB2 = 0
            GoTopB2 = False
        End If
    End Function
    Function Incrocio() As Short
        'Ritorna Min se il primo segmento ha un estremo a distanza<Diametro-Interf dal secondo
        'Ritorna Mag se il secondo segmento ha un estremo a distanza<Diametro-Interf dal primo
        'Ritorna Min se i due segmenti si intersecano al loro interno
        'Altrimenti ritorna Ugu
        'AF1=ordinata curvilinea su linea1
        'AF2=ordinata curvilinea su linea2
        Dim b1, a1, c1 As Single
        Dim b2, a2, c2 As Single
        Dim AF1, D, AF2 As Single
        Dim PP As New RoutBase1.clsVec2

        'Prima verifica che ogni estremo dei due segmenti non sia a distanza<diametro tubo-Franco.Interf
        'dall'altro segmento(purche' la normale intersechi il segmento)
        Incrocio = Mag
        If Interno((Franco.Utub.P0.X - Franco.Utub1.P0.X) * Franco.CC1.X + (Franco.Utub.P0.y - Franco.Utub1.P0.y) * Franco.CC1.y, Franco.Lun1) Then
            If System.Math.Abs((Franco.Utub1.P0.X - Franco.Utub.P0.X) * Franco.CC1.y - (Franco.Utub1.P0.y - Franco.Utub.P0.y) * Franco.CC1.X) < Franco.Diametro - Franco.Interf Then
                Exit Function
            End If
        End If
        If Interno((Franco.Utub.p1.X - Franco.Utub1.P0.X) * Franco.CC1.X + (Franco.Utub.p1.y - Franco.Utub1.P0.y) * Franco.CC1.y, Franco.Lun1) Then
            If System.Math.Abs((Franco.Utub1.P0.X - Franco.Utub.p1.X) * Franco.CC1.y - (Franco.Utub1.P0.y - Franco.Utub.p1.y) * Franco.CC1.X) < Franco.Diametro - Franco.Interf Then
                Exit Function
            End If
        End If
        Incrocio = Min
        If Interno((Franco.Utub1.P0.X - Franco.Utub.P0.X) * Franco.CC.X + (Franco.Utub1.P0.y - Franco.Utub.P0.y) * Franco.CC.y, Franco.Lun) Then
            If System.Math.Abs((Franco.Utub.P0.X - Franco.Utub1.P0.X) * Franco.CC.y - (Franco.Utub.P0.y - Franco.Utub1.P0.y) * Franco.CC.X) < Franco.Diametro - Franco.Interf Then Exit Function
        End If
        If Interno((Franco.Utub1.p1.X - Franco.Utub.P0.X) * Franco.CC.X + (Franco.Utub1.p1.y - Franco.Utub.P0.y) * Franco.CC.y, Franco.Lun) Then
            If System.Math.Abs((Franco.Utub.P0.X - Franco.Utub1.p1.X) * Franco.CC.y - (Franco.Utub.P0.y - Franco.Utub1.p1.y) * Franco.CC.X) < Franco.Diametro - Franco.Interf Then Exit Function
        End If
        'poi verifica se le due rette si intersecano all'interno dei segmenti
        Incrocio = Min
        a2 = Franco.Utub.p1.y - Franco.Utub.P0.y : b2 = Franco.Utub.P0.X - Franco.Utub.p1.X
        If System.Math.Abs(a2 * Franco.CC1.X + b2 * Franco.CC1.y) > Areso Then
            'Condizione di NON parallelismo
            c2 = -b2 * Franco.Utub.P0.y - a2 * Franco.Utub.P0.X
            a1 = Franco.Utub1.p1.y - Franco.Utub1.P0.y : b1 = Franco.Utub1.P0.X - Franco.Utub1.p1.X : c1 = -b1 * Franco.Utub1.P0.y - a1 * Franco.Utub1.P0.X
            D = a1 * b2 - a2 * b1 'determinante
            PP.X = (b1 * c2 - b2 * c1) / D
            PP.y = (a2 * c1 - a1 * c2) / D
            AF1 = (PP.X - Franco.Utub1.P0.X) * Franco.CC1.X + (PP.y - Franco.Utub1.P0.y) * Franco.CC1.y
            AF2 = (PP.X - Franco.Utub.P0.X) * Franco.CC.X + (PP.y - Franco.Utub.P0.y) * Franco.CC.y
            If Interno(AF1, Franco.Lun1) Then
                If Interno(AF2, Franco.Lun) Then
                    Exit Function
                End If
            End If
        End If
        Incrocio = Ugu
    End Function
    Sub Infilaggio(ByRef Sw As String, ByRef Diametro As Single, ByRef SovrAlt As Single, ByRef Interf As Single, ByRef AltMin As Single, ByRef Preciso As Single, ByRef GapCurve As Single)
        Lancio.Legacy.Serialization.LegacyBinarySerializer.EnsureEnabled()
        Dim File As String
        Dim Risposta As Short
        Dim Riga As String
        Dim NumLin As Short
        Dim Riga1 As String = ""
        Dim i As Short
        Dim iPosMTO As Integer
        Dim NumErr As Short
        Franco = New typFranco
        If UCase(Sw) = "V" Then
            Franco.CalcolaTutto = False
        Else
            Franco.CalcolaTutto = True
        End If
        File = gencommes.Trim
        Dim FileRB2 As String = File & ".RB2"
        If IO.File.Exists(File & ExtRES) And IO.File.Exists(File & ExtMTO) And IO.File.Exists(FileRB2) Then
            Risposta = CShort(MsgBox("Esiste il risultato di un calcolo precedente. Vuoi usarlo ?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question))
            If Risposta = MsgBoxResult.Yes Then
                Dim fs As New FileStream(FileRB2, FileMode.Open)
                Dim bf As New Lancio.Legacy.Serialization.LegacyBinarySerializer
                Franco.Manici.nRB2 = CType(bf.Deserialize(fs), OggList)
                fs.Close()
                Exit Sub
            End If
        End If
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        Franco.Manici.nCOO = CShort(FreeFile())
        FileOpen(Franco.Manici.nCOO, File & ExtCOO, OpenMode.Input)
        Riga = LineInput(Franco.Manici.nCOO)
        NumLin = LZero
        Franco.lApri = ApriB1()
        Do Until EOF(Franco.Manici.nCOO)
            System.Windows.Forms.Application.DoEvents()
            If iAgg = 1 Then
                Franco.iChiu = ChiuB1() : Exit Sub
            End If
            Riga = LineInput(Franco.Manici.nCOO)
            Franco.recB1.Sigla = prossimo(Riga)
            If Len(RTrim(Franco.recB1.Sigla)) > 0 Then
                NumLin = NumLin + LUno
                Riga1 = prossimo(Riga) : If Len(Riga1) > 0 Then Franco.Utub.P0.X = CSng(GlobalRoutines.ValVir(Riga1)) Else Exit Do
                Riga1 = prossimo(Riga) : If Len(Riga1) > 0 Then Franco.Utub.P0.y = CSng(GlobalRoutines.ValVir(Riga1)) Else Exit Do
                Riga1 = prossimo(Riga) : If Len(Riga1) > 0 Then Franco.Utub.p1.X = CSng(GlobalRoutines.ValVir(Riga1)) Else Exit Do
                Riga1 = prossimo(Riga) : If Len(Riga1) > 0 Then Franco.Utub.p1.y = CSng(GlobalRoutines.ValVir(Riga1)) Else Exit Do
                If Int(NumLin \ Dieci) * Dieci = NumLin Then
                    MainForm.StatusBar1.Items(0).Text = "Leggo coordinate.   Tubo: " & Franco.recB1.Sigla
                End If
                If Not AppeB1() Then
                    MsgBox("ERRORE:identificativo " & Franco.recB1.Sigla & " ripetuto.")
                    FileClose(Franco.Manici.nCOO)
                    i = ChiuB1()
                    Exit Sub
                End If
            End If
        Loop
        If Len(Riga1) > 0 Then
300:        FileClose(Franco.Manici.nCOO)
            If NumLin > 0 Then
                MainForm.StatusBar1.Items(0).Text = "Trovati" & Str(NumLin) & " tubi"
            Else
                MainForm.StatusBar1.Items(0).Text = "ERRORE:nessun tubo trovato!"
                i = ChiuB1()
                Exit Sub
            End If
        Else
            MainForm.StatusBar1.Items(0).Text = "ERRORE:dati insufficienti in riga" & Str(NumLin)
            i = ChiuB1()
            FileClose(Franco.Manici.nCOO)
            Exit Sub
        End If
        Franco.Diametro = Diametro
        Franco.SovrAlt = SovrAlt
        Franco.Interf = Interf
        Franco.AltMin = AltMin
        Franco.Preciso = Preciso
        Franco.GapCurve = GapCurve + Franco.Diametro
        If Franco.Diametro <= Zero Then
            MainForm.StatusBar1.Items(0).Text = "ERRORE:diametro non definito o illegale "
            GoTo Prematuro1
        ElseIf Franco.SovrAlt < Zero Then
            GoTo Prematuro1
        ElseIf Franco.Interf < Zero Then
            GoTo Prematuro1
        ElseIf Franco.AltMin < Zero Then
            GoTo Prematuro1
        ElseIf Franco.Preciso < Zero Then
            GoTo Prematuro1
        End If
        If Franco.Interf > Franco.Diametro / SDue Then Franco.Interf = Franco.Diametro / SDue
        If Franco.SovrAlt > 0 Then
        Else
            Franco.SovrAlt = Franco.Diametro / SDieci
        End If
        If Franco.Preciso > 0 Then
            If Franco.Preciso > Franco.Diametro / SDieci Then
                Franco.Preciso = Franco.Diametro / SDieci
            ElseIf Franco.Preciso < Franco.Diametro / SCento Then
                Franco.Preciso = Franco.Diametro / SCento
            End If
        Else
            Franco.Preciso = Franco.Diametro / SVenti
        End If
        Franco.iChiu = CShort(GoTopB1(True))
410:    Franco.lApri = ApriB2(True) 'con ZAP
        If Franco.CalcolaTutto Then
            Riga = "Determino sovraltezze.  "
        Else
            Riga = "Verifico sequenza.      "
        End If
        NumErr = 0
        Try
            Do
                System.Windows.Forms.Application.DoEvents()
                If iAgg = 1 Then
                    Franco.iChiu = ChiuB1()
                    Franco.iChiu = ChiuB2() : Exit Sub
                End If
                Franco.recB1 = CType(Franco.Manici.nRB1.ItemAt(Franco.iRecB1), typrecB1)
                Franco.Utub = Franco.recB1.Utubo
                Franco.CC = Franco.recB1.Cd
                Franco.Lun = Franco.recB1.Lungh
                Riga1 = Riga & "Tubo: " & Franco.recB1.Sigla
                MainForm.StatusBar1.Items(0).Text = Riga1
                Franco.Raggio = Franco.Lun / SDue
                Franco.Hmax = Zero : Franco.recB2.SiglaMin = Nul
                If GoTopB2(False) Then
                    Do
                        If iAgg = 1 Then
                            Franco.iChiu = ChiuB1()
                            Franco.iChiu = ChiuB2() : Exit Sub
                        End If
                        Franco.recB2 = CType(Franco.Manici.nRB2.ItemAt(Franco.iRecB2), typrecB2).Clone
                        Franco.Raggio1 = Franco.recB2.Raggio
                        Franco.Alt1 = Franco.recB2.Altezza
                        Franco.Utub1 = Franco.recB2.Utubo
                        Franco.CC1 = Franco.recB2.Cd
                        Franco.Lun1 = Franco.recB2.Lungh
600:                    Select Case Incrocio()
                            Case Mag
                                MsgBox("ERRORE:tubo " & Str(CDbl(Franco.recB1.Sigla)) & " non si monta su " & Str(CDbl(Franco.recB2.Sigla)), MsgBoxStyle.Critical)
                                NumErr = NumErr + Uno
                                If Franco.CalcolaTutto Then
                                    Franco.iChiu = ChiuB1()
                                    Franco.iChiu = ChiuB2() : Exit Sub
                                End If
                            Case Min
                                If Franco.CalcolaTutto Then
                                    Franco.CosAlfa = Franco.CC1.X * Franco.CC.X + Franco.CC1.y * Franco.CC.y
                                    Franco.SinAlfa = Franco.CC.X * Franco.CC1.y - Franco.CC1.X * Franco.CC.y
                                    'sin,cos dell'angolo in pianta fra i due tubi
                                    Franco.dx = ((Franco.Utub.P0.X + Franco.Utub.p1.X) / SDue - Franco.Utub1.P0.X) * Franco.CC1.y - ((Franco.Utub.P0.y + Franco.Utub.p1.y) / 2 - Franco.Utub1.P0.y) * Franco.CC1.X
                                    'Distanza in pianta del centro di Utub dalla retta di Utub1(asse x di rif.)
                                    Franco.dy = ((Franco.Utub.P0.X + Franco.Utub.p1.X) / SDue - Franco.Utub1.P0.X) * Franco.CC1.X + ((Franco.Utub.P0.y + Franco.Utub.p1.y) / 2 - Franco.Utub1.P0.y) * Franco.CC1.y - Franco.Raggio1
                                    'Distanza in pianta del centro di Utub dall'asse y di rif.
                                    Franco.HCalc = Altezza()
                                    If Franco.HCalc > 0 Or Franco.recB2.SiglaMin = Nul Then
                                        MainForm.StatusBar1.Items(0).Text = Riga1 & " sovrapposto a tubo: " & Str(CDbl(Franco.recB2.Sigla)) & " sovralt.: " & GlobalRoutines.myStr(CSng(Franco.HCalc + 0.4999), 4, 0, 0)
                                        '  Print USING; "####"; Franco.HCalc + 0.4999
                                        '   era già    PRINT SPACE$(LEN(Riga));
                                    End If
                                    If Franco.HCalc > Franco.Hmax Then
                                        Franco.Hmax = Franco.HCalc
                                        Franco.recB2.SiglaMin = Franco.recB2.Sigla
                                    ElseIf Franco.recB2.SiglaMin = Nul Then
                                        Franco.recB2.SiglaMin = Franco.recB2.Sigla
                                    End If
                                End If
                        End Select
700:                Loop While SkipB2(False) 'SKIP -1
                End If
                Franco.lApri = AppeB2()
            Loop While SkipB1(True) 'SKIP +1
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
        Franco.iChiu = ChiuB1()
        If Franco.CalcolaTutto Then
            System.Windows.Forms.Application.DoEvents()
            If iAgg = 1 Then
                Franco.iChiu = ChiuB2() : Exit Sub
            End If
            Franco.iChiu = CShort(GoTopB2(True)) 'GO TOP

            '        LOCATE 1, 1: PRINT "Trascrivo dati calcolati nel file "; File; ExtRES
            MainForm.StatusBar1.Items(0).Text = "   Altezza diritta minima:" & Str(Franco.AltMin)
            '            MainForm.StatusBar1.CtlRefresh()
            '   LOCATE 1, 1: Print Space$(79)
            '  LOCATE 2, 1: Print Space$(79)
            '--------------------------riordino----------------------
            Do
                Franco.recB2 = CType(Franco.Manici.nRB2.ItemAt(Franco.iRecB2), typrecB2)
                Franco.recB2.Raggio = CShort(Franco.recB2.Raggio)
                Franco.recB2.Altezza = CShort(Franco.recB2.Altezza + 0.4999)
                If Not SkipB2(True) Then Exit Do
                Franco.recB3 = CType(Franco.Manici.nRB2.ItemAt(Franco.iRecB2), typrecB2)
                Franco.recB3.Raggio = CShort(Franco.recB3.Raggio)
                Franco.recB3.Altezza = CShort(Franco.recB3.Altezza + 0.4999)
                If Franco.recB2.Raggio > Franco.recB3.Raggio Or (Franco.recB2.Raggio = Franco.recB3.Raggio And Franco.recB2.Altezza > Franco.recB3.Altezza) Then
                    Franco.Manici.nRB2.ItemAt(CShort(Franco.iRecB2) - 1) = Franco.recB3
                    Franco.Manici.nRB2.ItemAt(Franco.iRecB2) = Franco.recB2
                    i = CShort(SkipB2(False))
                    i = CShort(SkipB2(False))
                End If
            Loop
            '--------------------------------------------------------
            Franco.iChiu = CShort(GoTopB2(True)) 'GO TOP
            Franco.Manici.nRES = CShort(FreeFile())
740:        FileOpen(Franco.Manici.nRES, File & ExtRES, OpenMode.Output)
            PrintLine(Franco.Manici.nRES, "Sigla         N.uguali  R    Sovr.  L.diritta L.totale")
            Franco.Manici.nMTO = CShort(FreeFile())
            iPosMTO = 1
750:        FileOpen(Franco.Manici.nMTO, File & ExtMTO, OpenMode.Output)
            PrintLine(Franco.Manici.nMTO, "Pos. N.ug    R    L.diritta L.tot. Extralun.")
            Franco.Nuguali = 0 : Franco.Raggio = Zero : Franco.Alt = Zero
            Do
                Franco.recB2 = CType(Franco.Manici.nRB2.ItemAt(Franco.iRecB2), typrecB2) ' CType(cosa, typrecB2)
                If Int(CShort(Franco.iRecB2) \ Dieci) * Dieci = CShort(Franco.iRecB2) Then
                    MainForm.StatusBar1.Items(0).Text = "Registro risultati.   Tubo: " & Str(Franco.iRecB2)
                    'MainForm.StatusBar1.CtlRefresh()
                End If
                Franco.Raggio1 = CShort(Franco.recB2.Raggio)
                Franco.Alt1 = Franco.recB2.Altezza
                Franco.Utub1 = Franco.recB2.Utubo
                Franco.CC1 = Franco.recB2.Cd
                Franco.Lun1 = Franco.recB2.Lungh
                Franco.Alt1 = CShort(Franco.Alt1 + 0.4999) 'Arrotonda all'intero superiore
                If (Franco.Raggio1 = Franco.Raggio And Franco.Alt1 = Franco.Alt) Then
                    PrintLine(Franco.Manici.nRES)
                Else
                    If Franco.Raggio > 0 Then
                        Stamp(iPosMTO)
                        Franco.Nuguali = 0
                    End If
                End If
                Print(Franco.Manici.nRES, Franco.recB2.Sigla & " (" & Franco.recB2.SiglaMin & ") ")
                Franco.Raggio = Franco.Raggio1
                Franco.Alt = Franco.Alt1
                Franco.Nuguali = Franco.Nuguali + Uno
                Franco.recB2.posizione = CShort(iPosMTO)
                Franco.Manici.nRB2.ItemAt(Franco.iRecB2) = Franco.recB2
            Loop While SkipB2(True)
            Stamp(iPosMTO)
            FileClose(Franco.Manici.nRES)
            FileClose(Franco.Manici.nMTO)
        End If

        Franco.iChiu = ChiuB2()

        If Franco.CalcolaTutto Then
        Else
            '  LOCATE 2, 1: Print ". Trovati"; NumErr; "errori di sequenza"
        End If
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        MainForm.StatusBar1.Items(0).Text = ""
        ' MainForm.StatusBar1.Style = MSComctlLib.SbarStyleConstants.sbrNormal
        Exit Sub
Prematuro1:
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        'MainForm.StatusBar1.CtlRefresh()
        Franco.iChiu = ChiuB1()
    End Sub
    Private Sub Stamp(ByVal iPosMTO As Integer)
        Dim Stringa As String
        Print(Franco.Manici.nRES, GlobalRoutines.Adjust(Str(Franco.Nuguali), 6) & Franco.Raggio)
        PrintLine(Franco.Manici.nRES, GlobalRoutines.myStr(Franco.Alt, 10, 0, 0) & Franco.AltMin & SDue * (Franco.Alt + Franco.AltMin) + Math.PI * Franco.Raggio)
        Stringa = GlobalRoutines.myStr(CSng(Franco.Nuguali), 8, 0, -1)
        Print(Franco.Manici.nMTO, Stringa)
        Stringa = GlobalRoutines.myStr(Franco.Raggio, 8, 0, -1)
        Print(Franco.Manici.nMTO, Stringa)
        Stringa = GlobalRoutines.myStr(Franco.Alt + Franco.AltMin, 8, 0, -1)
        Print(Franco.Manici.nMTO, Stringa)
        Stringa = GlobalRoutines.myStr(CSng(SDue * (Franco.Alt + Franco.AltMin) + Math.PI * Franco.Raggio), 8, 0, -1)
        Print(Franco.Manici.nMTO, Stringa)
        Stringa = GlobalRoutines.myStr(Franco.Alt + Franco.AltMin + Franco.Raggio, 8, 0, -1)
        PrintLine(Franco.Manici.nMTO, Stringa)
        iPosMTO = iPosMTO + 1
    End Sub

    Function Interno(ByRef a As Single, ByRef L As Single) As Boolean
        Interno = False
        If a > -Areso And a < L + Areso Then Interno = True
    End Function


    Function prossimo(ByRef Riga As String) As String
        Dim n As Short
        Riga = LTrim(Riga)
        If Len(Riga) = 0 Then
            prossimo = ""
            Exit Function
        End If
        n = CShort(InStr(Riga, Space(1)))
        If n > 0 Then
            prossimo = Left(Riga, n - 1)
            Riga = Right(Riga, Len(Riga) - n)
        Else
            prossimo = Riga
            Riga = ""
        End If
    End Function
    Function SkipB1(ByRef Direzione As Boolean) As Boolean
        If Direzione Then Franco.iRecB1 = CShort(Franco.iRecB1 + 1) Else Franco.iRecB1 = CShort(Franco.iRecB1 - 1)
        If Franco.iRecB1 > Franco.Manici.nRB1.Count Then
            SkipB1 = False
        Else
            SkipB1 = True
        End If
    End Function
    Function SkipB2(ByRef Direzione As Boolean) As Boolean
        If Direzione Then Franco.iRecB2 = CShort(Franco.iRecB2 + 1) Else Franco.iRecB2 = CShort(Franco.iRecB2 - 1)
        If Franco.iRecB2 > Franco.Manici.nRB2.Count Then SkipB2 = False Else SkipB2 = True
        If Franco.iRecB2 = 0 Then Franco.iRecB2 = 1 : SkipB2 = False
    End Function
    Function XYZ(ByRef p As RoutBase1.clsVec3, ByRef t As Single) As Short
        'Calcola le coordinate x,y,z relative al sistema di riferimento
        'del primo tubo di un punto del secondo tubo individuato dal parametro
        't compreso fra -1 e 1 e pari al coseno dell'angolo theta
        Try
            p.X = Franco.dx - Franco.Raggio * Franco.SinAlfa * t
            p.y = Franco.dy - Franco.Raggio * Franco.CosAlfa * t
            p.Z = CSng((Franco.Alt - Franco.Alt1) + Franco.Raggio * System.Math.Sqrt(SUno - t * t))
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Function
    Function XYZpr(ByRef p As RoutBase1.clsVec3, ByRef t As Single) As Short
        'Calcola le derivate prime x',y',z' relative al sistema di riferimento
        'del primo tubo di un punto del secondo tubo individuato dal parametro
        't compreso fra -1 e 1 e pari al coseno dell'angolo theta
        Dim tt As Single
        tt = CSng(System.Math.Sqrt(SUno - t * t))
        p.X = Franco.Raggio * Franco.SinAlfa * tt
        p.y = Franco.Raggio * Franco.CosAlfa * tt
        p.Z = Franco.Raggio * t
    End Function
    Function XYZse(ByRef p As RoutBase1.clsVec3, ByRef t As Single) As Short
        'Calcola le derivate seconde x",y",z" relative al sistema di riferimento
        'del primo tubo di un punto del secondo tubo individuato dal parametro
        't compreso fra -1 e 1 e pari al coseno dell'angolo theta
        p.X = Franco.Raggio * Franco.SinAlfa * t
        p.y = Franco.Raggio * Franco.CosAlfa * t
        p.Z = CSng(-Franco.Raggio * System.Math.Sqrt(SUno - t * t))
    End Function
    Private Sub LinAX(ByRef n As Short, ByRef x1 As Single, ByRef y1 As Single, ByRef x2 As Single, ByRef y2 As Single)
        PrintLine(n, "0")
        PrintLine(n, "LINE")
        PrintLine(n, "100")
        PrintLine(n, "AcDbEntity")
        PrintLine(n, "8")
        PrintLine(n, "0")
        PrintLine(n, "6")
        PrintLine(n, "BYBLOCK")
        PrintLine(n, "62")
        PrintLine(n, "0")
        PrintLine(n, "100")
        PrintLine(n, "AcDbLine")
        PrintLine(n, "10")
        PrintLine(n, Str(x1))
        PrintLine(n, "20")
        PrintLine(n, Str(y1))
        PrintLine(n, "30")
        PrintLine(n, "0.0")
        PrintLine(n, "11")
        PrintLine(n, Str(x2))
        PrintLine(n, "21")
        PrintLine(n, Str(y2))
        PrintLine(n, "31")
        PrintLine(n, "0.0")
    End Sub

    Private Sub RaggAx(ByRef n As Short, ByRef R As Single)
        PrintLine(n, "0")
        PrintLine(n, "CIRCLE")
        PrintLine(n, "100")
        PrintLine(n, "AcDbEntity")
        PrintLine(n, "8")
        PrintLine(n, "0")
        PrintLine(n, "6")
        PrintLine(n, "CONTINUOUS")
        PrintLine(n, "100")
        PrintLine(n, "AcDbCircle")
        PrintLine(n, "10")
        PrintLine(n, "0.0")
        PrintLine(n, "20")
        PrintLine(n, "0.0")
        PrintLine(n, "30")
        PrintLine(n, "0.0")
        PrintLine(n, "40")
        PrintLine(n, Str(R))
    End Sub
    Sub ControllaRMT()
        Dim j1, j, ks, j2 As Short
        Dim Stringa As String
        Dim Diritta As Integer
        Dim sequ As String
        Dim NumTubu As Short
        Dim rag, DZETA As Single
        Dim FIN, INI, NumSequ As Short
        Dim nomfileREPO As String
        Dim fre1, fre5 As Short
        Dim nomfileRMT, nomfileSEQ As String
        Dim MaxUguali, kConta, CurPos As Short
        Dim nomfileCHK As String = ""
        Dim Risult(5) As Boolean
        Dim NoCheck As Boolean
        Dim Riga As String
        Dim Ntubes As Short
        Dim DiaTubo, PitchInt As Single
        Dim Repo, k, Seq As Short
        Dim DwgName As String = ""
        nomfileRMT = Trim(gencommes) & ".RMT"
        If Not IO.File.Exists(nomfileRMT) Then
ExRMT:      AppActivate(MainForm.Text)
            sequ = "   La Richiesta Materiali (.RMT) non è stata ancora elaborata," & vbCrLf
            sequ = sequ & "o è illeggibile." & vbCrLf
            sequ = sequ & "   Non è quindi possibile verificare la congruenza tra distinta" & vbCrLf
            sequ = sequ & "piegatura e sequenza di montaggio. Inoltre non è possibile elabo-" & vbCrLf
            sequ = sequ & "la tabella dei riferimenti incrociati (.CHK)" & vbCrLf
            sequ = sequ & "   Si consiglia di ripassare il calcolo delle sequenze dopo avere" & vbCrLf
            sequ = sequ & "elaborato la RM"
            MsgBox(sequ, MsgBoxStyle.Information)
            Exit Sub
        End If
        fre1 = CShort(FreeFile())
        Ntubes = 0 : DiaTubo = 0
        On Error GoTo ErrRMT
        FileOpen(fre1, nomfileRMT, OpenMode.Input)
        Do
            sequ = LineInput(fre1)
            NumSequ = CShort(InStr(sequ, ")") + 1)
            j = CShort(InStr(sequ, "U-Tubes"))
            j1 = CShort(InStr(sequ, "PITCH :"))
            If j > 0 Then
                j = CShort(InStr(sequ, "N°"))
                If j = 0 Then j = CShort(InStr(sequ, "b0"))
                If j = 0 Then Stop
                Ntubes = CShort(GlobalRoutines.ValVir(Mid(sequ, j + 2)))
            End If
            If j1 > 0 Then
                j1 = CShort(InStr(sequ, "OD."))
                DiaTubo = CSng(GlobalRoutines.ValVir(Mid(sequ, j1 + 3)))
                j1 = CShort(InStr(sequ, ":"))
                PitchInt = CSng(GlobalRoutines.ValVir(Mid(sequ, j1 + 1)))
            End If
        Loop While DiaTubo = 0
        Do
            sequ = LineInput(fre1)
            NumSequ = CShort(InStr(sequ, ")") + 1)
        Loop While InStr(sequ, "Sfrido") = 0
        k = 0 : MaxUguali = 0
        Stringa = ""
        Do
            sequ = LineInput(fre1)
            If InStr(sequ, "TOTALE") <> 0 Then
                Exit Do
            End If
            sequ = Stringa & sequ
            Stringa = sequ
            j1 = CShort(InStr(sequ, Trim(Str(k + 1)) & "\cell"))
            While j1 = 0
                sequ = LineInput(fre1)
                If InStr(sequ, "TOTALE") <> 0 Then
                    Exit Do
                End If
                sequ = Stringa & sequ
                Stringa = sequ
                j1 = CShort(InStr(sequ, Trim(Str(k + 1)) & "\cell"))
            End While
            Stringa = Mid(Stringa, j1)
            While Len(Stringa) < 130
                sequ = LineInput(fre1)
                sequ = Stringa & sequ
                Stringa = sequ
            End While
            j = 0 : j2 = 0
            While j < 9
                j2 = CShort(InStr(j2 + 1, Stringa, "\cell"))
                If j2 > 1 Then j = CShort(j + 1) Else Stop
            End While
            sequ = Mid(Stringa, 1, j2 + 4) 'contiene i dati
            Stringa = Mid(Stringa, j2 + 5)
            k = CShort(k + 1)
            ks = CShort(GlobalRoutines.ValVir(Mid(sequ, InStr(sequ, "\cell") + 5)))
            If ks = 0 Then Stop
            If ks > MaxUguali Then MaxUguali = ks
        Loop While InStr(Stringa, "TOTALE") = 0
        On Error GoTo 0
        Dim TipiCurve(k, 3) As Short
        Dim QuanteCurve(k, MaxUguali) As Short
        FileClose(fre1)
        fre1 = CShort(FreeFile())
        FileOpen(fre1, nomfileRMT, OpenMode.Input)
        Do
            sequ = LineInput(fre1)
            NumSequ = CShort(InStr(sequ, ")") + 1)
        Loop While InStr(sequ, "Sfrido") = 0
        k = 0
        Stringa = ""
        Do
            sequ = LineInput(fre1)
            If InStr(sequ, "TOTALE") <> 0 Then
                Exit Do
            End If
            sequ = Stringa & sequ
            Stringa = sequ
            j1 = CShort(InStr(sequ, Trim(Str(k + 1)) & "\cell")) 'InStr(sequ, "}")
            While j1 = 0
                sequ = LineInput(fre1)
                If InStr(sequ, "TOTALE") <> 0 Then
                    Exit Do
                End If
                sequ = Stringa & sequ
                Stringa = sequ
                j1 = CShort(InStr(sequ, Trim(Str(k + 1)) & "\cell"))
            End While
            Stringa = Mid(Stringa, j1)
            While Len(Stringa) < 130
                sequ = LineInput(fre1)
                sequ = Stringa & sequ
                Stringa = sequ
            End While
            j = 0 : j2 = 0
            While j < 9
                j2 = CShort(InStr(j2 + 1, Stringa, "\cell"))
                If j2 > 1 Then j = CShort(j + 1) Else Stop
            End While
            sequ = Mid(Stringa, 1, j2 + 4) 'contiene i dati
            Stringa = Mid(Stringa, j2 + 5)
            k = CShort(k + 1)
            j1 = CShort(InStr(sequ, "\cell") + 5)
            TipiCurve(k, 0) = 0
            TipiCurve(k, 1) = CShort(GlobalRoutines.ValVir(Mid(sequ, j1)))
            j1 = CShort(InStr(j1, sequ, "\cell") + 5)
            TipiCurve(k, 2) = CShort(GlobalRoutines.ValVir(Mid(sequ, j1))) 'RAGGIO
            j1 = CShort(InStr(j1, sequ, "\cell") + 5)
            TipiCurve(k, 3) = CShort(GlobalRoutines.ValVir(Mid(sequ, j1))) 'LDIRITTA
            If k = 1 Then Diritta = TipiCurve(k, 3)
        Loop While InStr(Stringa, "TOTALE") = 0
        FileClose(fre1)

        nomfileREPO = Trim(gencommes) & ".REP" 'InputBox("Conferma il nome file Report : ", "Scelta file", Pathh & "\" & DwgName & ".rep")
        FileClose(Repo)
        Repo = CShort(FreeFile())
        If IO.File.Exists(nomfileREPO) Then Kill(nomfileREPO)
        FileOpen(Repo, nomfileREPO, OpenMode.Output)
        j2 = 3
        PrintLine(Repo, "") : PrintLine(Repo, "")
        PrintLine(Repo, Space(j2) & "Co: " & DwgName, Format(Today, "dd-mm-yyyy"))
        PrintLine(Repo, "")
        PrintLine(Repo, Space(j2) & "Report Anomalie riscontrate nel controllo del Riferimento POS. della")
        PrintLine(Repo, Space(j2) & "Richiesta materiali con Sigla Forcelle in Sequenza di montaggio")
        nomfileSEQ = Trim(gencommes) & ".SEQ"
        'While nomfileSEQ = ""
        '    nomfileSEQ = InputBox("Conferma il nome file sequenza : ", "Scelta file", Pathh & "\" & DwgName & ".SEQ")
        '    If Dir(nomfileSEQ) = "" Then
        '        MsgBox "NON ESISTE IL FILE " & nomfileSEQ
        '        nomfileSEQ = ""
        '    End If
        'Wend
        Seq = CShort(FreeFile())
        FileOpen(Seq, nomfileSEQ, OpenMode.Input)
        PrintLine(Repo, Space(j2) & nomfileRMT)
        PrintLine(Repo, Space(j2) & nomfileSEQ)
        PrintLine(Repo, Space(j2) & "(Verifica raggio tra *.COO e *.SEQ, raggio tra *.RMT e *.SEQ,")
        PrintLine(Repo, Space(j2) & " verifica N° pezzi, verifica lunghezze tra *.SEQ ed *.RMT)")
        kConta = 0
        Do
            Do
                If EOF(Seq) Then Exit Do
                sequ = LineInput(Seq)
                NumSequ = CShort(InStr(sequ, ")\tab"))
            Loop While NumSequ < 4
            If EOF(Seq) Then Exit Do
            j1 = NumSequ
            Do
                j1 = CShort(j1 - 1)
            Loop While IsNumeric(Mid(sequ, j1, 1))
            j1 = CShort(j1 + 1)
            NumSequ = CShort(GlobalRoutines.ValVir(Mid(sequ, j1)))
            INI = CShort(InStr(sequ, "\tab") + 4) : FIN = CShort(InStr(INI, sequ, "\tab") + 4) 'per .seq
            NumTubu = CShort(GlobalRoutines.ValVir(Mid(sequ, INI, FIN - INI)))
            INI = FIN
            FIN = CShort(InStr(INI, sequ, "\tab") + 4)
            rag = CShort(GlobalRoutines.ValVir(Mid(sequ, INI, FIN - INI)))
            INI = FIN
            DZETA = CShort(GlobalRoutines.ValVir(Mid(sequ, FIN)))
            FIN = CShort(InStr(INI, sequ, "\tab") + 4)
            INI = FIN
            CurPos = CShort(GlobalRoutines.ValVir(Mid(sequ, INI)))
            kConta = CShort(kConta + 1)
            Franco.recB2 = CType(Franco.Manici.nRB2.ItemAt(NumTubu), typrecB2)
            If CurPos > UBound(TipiCurve, 1) Then
                PrintLine(Repo, Space(j2) & "Tubo " & NumTubu & " ( LA POSIZIONE " & Str(CurPos) & " NON ESISTE NELLA RMT )")
                Risult(0) = True : NoCheck = True
            Else
                If Diritta + DZETA > TipiCurve(CurPos, 3) + 0.5 And Diritta + DZETA < TipiCurve(CurPos, 3) - 0.5 Then
                    PrintLine(Repo, Space(j2) & "Tubo " & NumTubu & " ( Lunghezza " & Str(Diritta + DZETA) & " <> " & TipiCurve(CurPos, 3) & ")  POS. " & CurPos)
                    Risult(1) = True : NoCheck = True
                End If
                If TipiCurve(CurPos, 2) <> rag Then
                    Risult(2) = True : NoCheck = True
                    PrintLine(Repo, Space(j2) & "Tubo " & NumTubu & " ( Raggi " & Str(rag) & " <> " & TipiCurve(CurPos, 2) & " )  POS. " & Str(CurPos))
                End If
                TipiCurve(CurPos, 0) = CShort(TipiCurve(CurPos, 0) + 1)
                If TipiCurve(CurPos, 0) > TipiCurve(CurPos, 1) Then
                    Risult(3) = True : NoCheck = True
                    PrintLine(Repo, Space(j2) & "Tubo " & NumTubu & " ( N° " & Str(TipiCurve(CurPos, 0)) & " <> N° max )  POS. " & CurPos)
                End If
                If TipiCurve(CurPos, 0) > MaxUguali Then
                    NoCheck = True : GoTo NoCh
                End If
                QuanteCurve(CurPos, TipiCurve(CurPos, 0)) = NumTubu
                If ((Franco.recB2.Raggio < rag - 0.5 Or Franco.recB2.Raggio > rag + 0.5)) Then
                    Risult(4) = True : NoCheck = True
                    PrintLine(Repo, Space(j2) & "Tubo " & NumTubu & " ( Raggio tubo reale " & Str(Franco.recB2.Raggio) & " <> " & TipiCurve(CurPos, 2) & " )  POS. " & CurPos)
                End If
            End If
        Loop While Not EOF(Seq) And kConta < Ntubes
        For j = 1 To CShort(UBound(TipiCurve, 1))
            If TipiCurve(j, 0) < TipiCurve(j, 1) Then
                Risult(5) = True : NoCheck = True
                PrintLine(Repo, Space(j2) & "N° tubi " & Str(TipiCurve(j, 0)) & " < N° richiesto )  POS. " & j)
            End If
        Next
        FileClose(Repo)
        If Ntubes <> kConta Then
            MsgBox("Il numero tubi non corrisponde con i tubi controllati!")
        End If
        FileClose(Seq)
        On Error Resume Next
        Kill(Monitor.Motore.Inizio.DiscoTem & "\RB2.RB2")
        On Error GoTo 0
        nomfileCHK = Trim(gencommes) & ".CHK" 'InputBox("Conferma il nome file output : ", "Scelta file", Pathh & "\" & DwgName & ".RmCk")
        fre1 = CShort(FreeFile())
        On Error GoTo ErrSRMT
        FileOpen(fre1, nomfileCHK, OpenMode.Output)
        On Error GoTo 0
        kConta = 1
        PrintLine(fre1, "") : PrintLine(fre1, "")
        PrintLine(fre1, Space(j2) & "Co. : " & DwgName & Space(j2) & Format(Today, "dd-mm-yyyy"), Space(3), "Pag. " & kConta & " di ") '; CInt(UBound(TipiCurve, 1) / 57 + 1)
        PrintLine(fre1, "")
        PrintLine(fre1, Space(2 * j2) & "Riferimento POS. Richiesta materiali con")
        PrintLine(fre1, Space(2 * j2) & "Sigla Forcelle in Sequenza di montaggio (" & Ntubes & " tubi)")
        PrintLine(fre1, Space(2 * j2), nomfileRMT)
        PrintLine(fre1, Space(2 * j2), nomfileSEQ)
        PrintLine(fre1, "") : PrintLine(fre1, "")
        ks = 0
        For j = 1 To CShort(UBound(TipiCurve, 1))
            ks = CShort(ks + 1)
            Print(fre1, Space(j2) & Format(j, "@@@@ )"))
            For k = 1 To TipiCurve(j, 0)
                Print(fre1, Format(QuanteCurve(j, k), " @@@@"))
                If k Mod 13 = 0 Then
                    ks = CShort(ks + 1)
                    PrintLine(fre1, "")
                    Print(fre1, Space(j2 + 6))
                End If
            Next k
            PrintLine(fre1, "")
            If ks Mod 50 = 0 Then
                kConta = CShort(kConta + 1)
                'Print #fre1, Chr$(12);
                PrintLine(fre1, "") : PrintLine(fre1, "")
                PrintLine(fre1, Space(j2) & "Co. : " & DwgName & Space(j2) & Format(Today, "dd-mm-yyyy"), Space(3), "Pag. " & kConta & " di ") '; CInt(UBound(TipiCurve, 1) / 57 + 1)
                PrintLine(fre1, "")
                PrintLine(fre1, Space(2 * j2) & "Riferimento POS. Richiesta materiali con")
                PrintLine(fre1, Space(2 * j2) & "Sigla Forcelle in Sequenza di montaggio (" & Ntubes & " tubi)")
                PrintLine(fre1, Space(2 * j2), nomfileRMT)
                PrintLine(fre1, Space(2 * j2), nomfileSEQ)
                PrintLine(fre1, "") : PrintLine(fre1, "")
            End If
        Next
        'Print #fre1, Chr$(12);
        If NoCheck Then
            Repo = CShort(FreeFile())
            FileOpen(Repo, nomfileREPO, OpenMode.Input)
            ks = 0
            While Not EOF(Repo)
                Stringa = LineInput(Repo)
                ks = CShort(ks + 1)
                PrintLine(fre1, Stringa)
                If ks Mod 55 = 0 Then
                    PrintLine(fre1, "") ': Print #Repo, ""
                    PrintLine(fre1, Space(j2) & "Co: " & DwgName, Format(Today, "dd-mm-yyyy"))
                    PrintLine(fre1, "")
                    PrintLine(fre1, Space(j2) & "Report Anomalie riscontrate nel controllo del Riferimento POS. della")
                    PrintLine(fre1, Space(j2) & "Richiesta materiali con Sigla Forcelle in Sequenza di montaggio")
                    PrintLine(fre1, Space(j2) & "(Verifica raggio tra *.COO e *.SEQ, raggio tra *.RMT e *.SEQ,")
                    PrintLine(fre1, Space(j2) & " verifica N° pezzi, verifica lunghezze tra *.SEQ ed *.RMT)")
                    PrintLine(fre1, Space(2 * j2), nomfileRMT)
                    PrintLine(fre1, Space(2 * j2), nomfileSEQ)
                    PrintLine(fre1, "") : PrintLine(fre1, "")
                End If
            End While
            If InStr(Stringa, nomfileSEQ) <> 0 And ks < 55 Then
                PrintLine(fre1, "") : PrintLine(fre1, "")
                PrintLine(fre1, Space(30) & "NESSUNA")
            End If
            FileClose(Repo)
        Else
            PrintLine(fre1, "Nota: non è stata rilevata alcuna incongruenza")
            PrintLine(fre1, "")
        End If
NoCh:   FileClose(fre1)
        On Error Resume Next
        StubWord.sOpen(nomfileCHK)
        On Error GoTo 0
        Kill(nomfileREPO)
        If NoCheck Then
            AppActivate(MainForm.Text)
            sequ = "La soluzione descritta nei files:" & vbCrLf
            sequ = sequ & "Richiesta Materiali    (.RMT)" & vbCrLf
            sequ = sequ & "Sequenza di montaggio  (.SEQ)" & vbCrLf
            sequ = sequ & "Cross-reference        (.CHK)" & vbCrLf
            sequ = sequ & "non è coerente. (Vedi rapporto" & vbCrLf
            sequ = sequ & "dettagliato in .CHK)" & vbCrLf
            sequ = sequ & "Si consiglia di ripassare tutti i calcoli"
            MsgBox(sequ, MsgBoxStyle.Critical)
        End If
        'MsgBox "Puoi proseguire"
        Exit Sub
ErrRMT:
        FileClose(fre1)
        Resume ExRMT
ErrSRMT:
        If Err.Number = 70 Then
            Riga = "AuDistSuSettoHorzazione negata ad aprire in scrittura" & vbCrLf
            Riga = Riga & "il file di stampa " & nomfileCHK & "." & vbCrLf
            Riga = Riga & "Controllare se è occupato da Winword"
            Err.Clear()
            If MsgBox(Riga, MsgBoxStyle.RetryCancel) = MsgBoxResult.Retry Then Resume
            FileClose(fre1)
            Resume ExRMT
        Else
            If MsgBox(Err.Description & Str(Err.Number) & vbCrLf & "in apertura di " & nomfileCHK, MsgBoxStyle.RetryCancel) = MsgBoxResult.Retry Then Resume
            FileClose(fre1)
            Resume ExRMT
        End If
    End Sub
End Module