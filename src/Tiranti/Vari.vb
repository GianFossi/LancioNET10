Option Strict On
Option Explicit On
Imports System
Imports System.Collections
Imports Microsoft.VisualBasic
Public Class UnitCollection
    Inherits CollectionBase
    Default Public ReadOnly Property Item(ByVal Index As Integer) As Double
        Get
            Return CType(List.Item(Index), Double)
        End Get
    End Property
    Public Sub add(ByVal n As Double)
        list.Add(n)
    End Sub
End Class
Public Class UnitConversionDictionary
    Inherits DictionaryBase
    Default Public Property Item(ByVal key As [String]) As Object
        Get
            Return CType(Dictionary(key), Object)
        End Get
        Set(ByVal Value As Object)
            Dictionary(key) = Value
        End Set
    End Property
    Public ReadOnly Property Keys() As ICollection
        Get
            Return Dictionary.Keys
        End Get
    End Property
    Public ReadOnly Property Values() As ICollection
        Get
            Return Dictionary.Values
        End Get
    End Property
    Public Overloads Sub Add(ByVal value As [String], ByVal key As [String])
        Dictionary.Add(key, value)
    End Sub 'Add
    Public Overloads Sub Add(ByVal value As UnitCollection, ByVal key As [String])
        Dictionary.Add(key, value)
    End Sub 'Add
    Public Function Contains(ByVal key As [String]) As Boolean
        Return Dictionary.Contains(key)
    End Function 'Contains
    Public Sub Remove(ByVal key As [String])
        Dictionary.Remove(key)
    End Sub 'Remove
    Protected Overrides Sub OnInsert(ByVal key As [Object], ByVal value As [Object])
        '   If Not key.GetType() Is Type.GetType("System.String") Then
        '   Throw New ArgumentException("key must be of type String.", "key")
        '   Else
        '       Dim strKey As [String] = CType(key, [String])
        '       If strKey.Length > 5 Then
        '   Throw New ArgumentException("key must be no more than 5 characters in length.", "key")
        '       End If
        '   End If
        '   If Not value.GetType() Is Type.GetType("System.String") Then
        '   Throw New ArgumentException("value must be of type String.", "value")
        '   Else
        '       Dim strValue As [String] = CType(value, [String])
        '       If strValue.Length > 5 Then
        '   Throw New ArgumentException("value must be no more than 5 characters in length.", "value")
        '       End If
        '   End If
    End Sub 'OnInsert

    Protected Overrides Sub OnRemove(ByVal key As [Object], ByVal value As [Object])
        '  If Not key.GetType() Is Type.GetType("System.String") Then
        '  Throw New ArgumentException("key must be of type String.", "key")
        '  Else
        '      Dim strKey As [String] = CType(key, [String])
        '      If strKey.Length > 5 Then
        '  Throw New ArgumentException("key must be no more than 5 characters in length.", "key")
        '      End If
        '  End If
    End Sub 'OnRemove

    Protected Overrides Sub OnSet(ByVal key As [Object], ByVal oldValue As [Object], ByVal newValue As [Object])
        ' If Not key.GetType() Is Type.GetType("System.String") Then
        ' Throw New ArgumentException("key must be of type String.", "key")
        ' Else
        '     Dim strKey As [String] = CType(key, [String])
        '     If strKey.Length > 5 Then
        ' Throw New ArgumentException("key must be no more than 5 characters in length.", "key")
        '     End If
        ' End If
        ' If Not newValue.GetType() Is Type.GetType("System.String") Then
        ' Throw New ArgumentException("newValue must be of type String.", "newValue")
        ' Else
        '     Dim strValue As [String] = CType(newValue, [String])
        '     If strValue.Length > 5 Then
        ' Throw New ArgumentException("newValue must be no more than 5 characters in length.", "newValue")
        '     End If
        ' End If
    End Sub 'OnSet

    Protected Overrides Sub OnValidate(ByVal key As [Object], ByVal value As [Object])
        ' If Not key.GetType() Is Type.GetType("System.String") Then
        ' Throw New ArgumentException("key must be of type String.", "key")
        ' Else
        '     Dim strKey As [String] = CType(key, [String])
        '     If strKey.Length > 5 Then
        ' Throw New ArgumentException("key must be no more than 5 characters in length.", "key")
        '     End If
        ' End If
        ' If Not value.GetType() Is Type.GetType("System.String") Then
        ' Throw New ArgumentException("value must be of type String.", "value")
        ' Else
        '     Dim strValue As [String] = CType(value, [String])
        '     If strValue.Length > 5 Then
        ' Throw New ArgumentException("value must be no more than 5 characters in length.", "value")
        '     End If
        ' End If
    End Sub 'OnValidate 

End Class
Module Vari
    Public colTec, colSI, colBR As UnitConversionDictionary
    Public colPrima, colDopo As UnitConversionDictionary
    Public colConv As UnitConversionDictionary
    Public Monitor As clsMonitor
    Public NormalColor As Integer
    Public ModifiedData As Boolean
    Public ClickManuale As Boolean
    <Serializable()> Structure friction
        Dim Coeff As Single
        Dim Nome As String
    End Structure
    <Serializable()> Structure typProblem
        Dim Version As Short
        Dim intestazione As String
        Dim unmi As Short '1 SI 2 tecnico 3 british
        Dim cod As Short ' 1 ASME 2 ISPESL
        Dim t As Single
        Dim p As Single
        Dim phydr As Single
        Dim DiamExtGuar As Single
        Dim N As Single
        Dim wnubbin As Single
        Dim sa1 As Single
        Dim sa2 As Single
        Dim nb As Integer
        Dim ClasseGuarnizione As Short
        Dim TipoGuarnizione As Short
        Dim strClasseGuarnizione As String
        Dim strTipoGuarnizione As String
        Dim m As Single
        Dim yy As Single
        Dim y1 As Single '1/4 in
        Dim Face As Short
        Dim b As Single
        Dim Gef As Single
        Dim MatTira As String
        Dim DN As String
        Dim indMat As Short
        Dim xfil As Short '1 metrico 2 british
        Dim Diam As Single 'diametro cresta
        Dim Dnoc As Single 'diametro nocciolo
        Dim Chiave As Single
        Dim diammed As Single
        Dim passofil As Single
        Dim Area As Single 'Area di un bullone
        Dim alf As Single 'semiapertura al vertice in gradi
        Dim coeffindexD As Short '0 secco 1 ordinario 2 molycote 3 custom
        Dim fDado As Single
        Dim fFil As Single
        Dim wm1 As Single
        Dim wm2 As Single
        Dim wm As Single 'max(wm1,wm2)
        Dim am1 As Single
        Dim am2 As Single
        Dim am As Single
        Dim ab As Single
        Dim w0 As Single 'carico di progetto
        Dim v As Single 'wm/nb per P.I.
        Dim vobb As Single
        Dim vPilgrim As Single
        Dim areaPist As Single
        Dim presPist As Single
        Dim alfa As Single
        Dim beta As Single
        Dim torque As Single
        Dim k1 As Single 'fatt.rilass.pressione
        Dim k2Pilgrim As Single
        Dim k2Torque As Single
        Dim k3 As Single
        Dim fGlob As Single
        Dim coefft() As friction
        Dim coeffindexF As Short
        Dim Padding As String
        Public Sub Initialize()
            ReDim coefft(3)
        End Sub
    End Structure
    Public Problem As typProblem
    Public objMat As LibMat.MaterialeNew1
    Public objTir As LibMat.clsTira
    Public Guarn As LibMat.clsGuarn
    Public nomefile As String
    Public Stub As StubW2000.clsSW2000
    Friend RoutBase1clsTrigon_definst As New RoutBase1.clsTrigon
    'Public ran As Word.Range
    '*************VARIABILI RELATIVE AL CALCOLO*****************
    Public Const PI As Double = 3.14159265358979
    Public Const PSI As Single = 145.0377439
    Public Const NIUT As Single = 4.448222
    Public Const GRAV As Single = 9.80655
    Public Const INC As Single = 25.4
    Public intestazione As String = "/Tiranti/"
    Public Const Version As Short = 1
    Public RadiceHelp As String '= "C:\BASE\ESEGUI\BIN\AsmeVIP.chm"
    Public Sub calcolo()
        Dim wm1hydr, vteor As Single
        With Problem
            If Problem.cod = 1 Then
                Problem.y1 = 6.35
            Else
                Problem.y1 = 6.25
            End If
            If Problem.unmi = 3 Then Problem.y1 = Problem.y1 / INC
            .b = .N / 2

            If .b > .y1 Then
                .b = CSng(System.Math.Sqrt(.y1 * .b))
            End If
            .Gef = .DiamExtGuar - 2 * .b
            .wm1 = CSng(PI / 4 * .Gef ^ 2 * .p + (2 * PI * .m * .b * .Gef * .p))
            If .unmi = 2 Then .wm1 = .wm1 / 100
            .wm2 = CSng(PI * .b * .Gef * .yy)
            .wm = .wm1 : If .wm2 > .wm Then .wm = .wm2
            If .sa1 <= 0 Or .sa2 <= 0 Then
                NotOK()
                Tir1.DefInstance.CommentoC = "La tensione ammissibile dei bulloni non è specificata "
                Exit Sub
            Else
                OK()
                Tir1.DefInstance.CommentoC = ""
            End If
            .am1 = .wm1 / .sa1
            .am2 = .wm2 / .sa2

            .am = .am1

            If .am2 > .am Then
                .am = .am2
            End If
            .Area = CSng(PI / 4 * .Dnoc * .Dnoc)
            .ab = .nb * .Area

            If .ab < .am Then
                NotOK()
                Tir1.DefInstance.CommentoC = "La sezione dei bulloni installata è insufficiente " & " - Ab " & .ab & " < Am " & .am
                Exit Sub
            Else
                OK()
                Tir1.DefInstance.CommentoC = ""
            End If
            .w0 = (.ab + .am) / 2 * .sa2
            'w = wm

            'If w0 > w Then
            '    w = w0
            'End If
            If .phydr <= .p Then
                NotOK()
                Tir1.DefInstance.CommentoC = "La pressione di prova idraulica non è definita correttamente"
                Tir1.DefInstance.Frame2.Enabled = True
                Exit Sub
            Else
                OK()
                Tir1.DefInstance.CommentoC = ""
            End If
            wm1hydr = .wm1 * .phydr / .p
            vteor = wm1hydr : If .wm2 > vteor Then vteor = .wm2
            .v = vteor / .nb
        End With
        calcol1()
    End Sub
    Private Sub NotOK()
        With Tir1.DefInstance
            .Frame2.BackColor = System.Drawing.Color.Red
            .Frame3.BackColor = System.Drawing.Color.Red
            .Frame4.BackColor = System.Drawing.Color.Red
            .Frame2.Enabled = False
            .Frame3.Enabled = False
            .Frame4.Enabled = False
        End With
    End Sub
    Private Sub OK()
        With Tir1.DefInstance
            .Frame2.BackColor = System.Drawing.ColorTranslator.FromOle(NormalColor)
            .Frame3.BackColor = System.Drawing.ColorTranslator.FromOle(NormalColor)
            .Frame4.BackColor = System.Drawing.ColorTranslator.FromOle(NormalColor)
            .Frame2.Enabled = True
            .Frame3.Enabled = True
            .Frame4.Enabled = True
        End With
    End Sub
    Public Sub calcol1()
        With Problem
            If .k1 < 1 Then .k1 = 1
            .vobb = .v * .k1
        End With
        Calcol2()
        Calcol3()
    End Sub
    Public Sub Calcol3()
        With Problem
            If .k2Torque < 1 Then .k2Torque = 1.3
            .diammed = (.Diam + .Dnoc) / 2 ' - (3 * Sqr(3)) / 8 * .passofil
            If .diammed <= 0 Then
                Tir1.DefInstance.CommentoC = "Le caratteristiche dimensionali dei bulloni non sono state specificate "
                Tir1.DefInstance.Frame4.BackColor = System.Drawing.Color.Red
                Exit Sub
            Else
                Tir1.DefInstance.CommentoC = ""
                Tir1.DefInstance.Frame4.BackColor = System.Drawing.ColorTranslator.FromOle(NormalColor)
            End If
            .alfa = CSng(System.Math.Atan(.passofil / (PI * .diammed)))
            .alf = 30
            .beta = CSng(System.Math.Atan(.fFil / System.Math.Cos(.alf * PI / 180)))
            .fGlob = CSng((.fDado * (.Chiave / 2) + .diammed / 2 * System.Math.Tan(.alfa + .beta)) / .diammed)
            .torque = .vobb * .k2Torque * .fGlob * .diammed
            If .unmi < 3 Then .torque = .torque / 1000
        End With
    End Sub
    Public Sub Calcol2()
        With Problem
            If .k2Pilgrim < 1 Then .k2Pilgrim = 1.1
            If .k3 < 1 Then .k3 = 1.3
            .vPilgrim = .vobb * .k2Pilgrim * .k3
            If .areaPist <= 0 Then
                Tir1.DefInstance.Frame3.BackColor = System.Drawing.Color.Red
                Tir1.DefInstance.CommentoC = "La sezione retta del pistone del martinetto idraulico non è definita."
            Else
                Tir1.DefInstance.Frame3.BackColor = System.Drawing.ColorTranslator.FromOle(NormalColor)
                Tir1.DefInstance.CommentoC = ""
                .presPist = .vPilgrim / .areaPist
            End If
        End With
    End Sub
    Public Sub StampaRapp()
        Dim tempunmi1, nomefile2 As String
        Dim FileStampa, testo As String
        nomefile2 = Monitor.Motore.Inizio.Archdir & "\Tiranti.doc"
        If Not IO.File.Exists(nomefile2) Then
            MsgBox("Il file " & nomefile2 & " non esiste.")
            Exit Sub
        End If
        Monitor.Motore.Inizio.SuperStampa(nomefile2, Stub) 'user_doc
        FileStampa = nomefile.Substring(0, nomefile.Length - 4) & "TIR.DOC"
        Try
            Stub.sSaveAs(FileStampa)
        Catch e As Exception
            Select Case Err.Number
                Case 5153
                    testo = "Si è generato il seguente errore:" & vbCrLf
                    testo = testo & Err.Description & vbCrLf & vbCrLf
                    testo = testo & "E' probabile che sia necessario accedere a" & vbCrLf
                    testo = testo & "Winword per liberare il file e poi riprovare."
                    If MsgBox(testo, MsgBoxStyle.RetryCancel, "Errore da WinWord") = MsgBoxResult.Retry Then
                        StampaRapp()
                    End If
                    Exit Sub
                Case 5825
                    testo = "Si è generato il seguente errore:" & vbCrLf
                    testo = testo & Err.Description & vbCrLf & vbCrLf
                    testo = testo & "E' possibile che l'utente abbia interagito" & vbCrLf
                    testo = testo & "in modo improprio con WinWord." & vbCrLf
                    testo = testo & "La generazione del rapporto viene terminata."
                    MsgBox(testo, CType(MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, MsgBoxStyle))
                    Exit Sub
                Case Else
                    MsgBox(Err.Description & Str(Err.Number) & vbCrLf & e.StackTrace)
            End Select
        End Try
        Dim logo As String = Monitor.Motore.Inizio.Archdir & "\" & Monitor.Motore.Inizio.ReadIniFile("", "Azienda", "Logo")
        Stub.IntestLogo(logo, 0.9)

        If Problem.unmi = 1 Then
            tempunmi1 = "MPa"
        Else
            tempunmi1 = "Kg/cm²"
        End If

        With Problem
            Monitor.inserisci("data", Today)
            Monitor.inserisci("Pe", tempunmi1)
            Monitor.inserisci("P", .p)
            Monitor.inserisci("De", .DiamExtGuar)
            Monitor.inserisci("N", .N)
            Monitor.inserisci("m", .m)

            If .unmi = 1 Then
                tempunmi1 = "N/mm²"
            Else
                tempunmi1 = "Kg/mm²"
            End If

            Monitor.inserisci("U1", tempunmi1)
            Monitor.inserisci("yyy", .yy)
            Monitor.inserisci("U2", tempunmi1)
            Monitor.inserisci("sa1", .sa1)

            Monitor.inserisci("U3", tempunmi1)
            Monitor.inserisci("sa2", .sa2)
            Monitor.inserisci("nb", .nb)
            Monitor.inserisci("fDado", .fDado)

            Monitor.inserisci("fFil", .fFil)
            Monitor.inserisci("passofil", .passofil)
            Monitor.inserisci("AL", .alf)
            Monitor.inserisci("Chiave", .Chiave)

            Monitor.inserisci("DM", .diammed)
            Monitor.inserisci("A", .Area)
            Monitor.inserisci("DN", .Diam)

            If .unmi = 1 Then
                tempunmi1 = "N"
            Else
                tempunmi1 = "Kg"
            End If

            Monitor.inserisci("wm1", .wm1)
            Monitor.inserisci("U4", tempunmi1)
            Monitor.inserisci("wm2", .wm2)
            Monitor.inserisci("U5", tempunmi1)
            Monitor.inserisci("am1", .am1)
            Monitor.inserisci("am2", .am2)

            Monitor.inserisci("ab", .ab)
            Monitor.inserisci("U6", tempunmi1)
            Monitor.inserisci("V", .v)
            Monitor.inserisci("U8", tempunmi1)
            If .unmi = 1 Then
                tempunmi1 = "N*mm"
            Else
                tempunmi1 = "Kg*mm"
            End If
            Monitor.inserisci("xx", RoutBase1clsTrigon_definst.myStr(CSng(180 / PI * .alfa), 2, 2, 0))
            Monitor.inserisci("yy", RoutBase1clsTrigon_definst.myStr(CSng(180 / PI * .beta), 2, 2, 0))
            Monitor.inserisci("U7", tempunmi1)
            Monitor.inserisci("zs", .torque)

        End With
        'wrd.Visible = True
        'wrd.WindowState = wdWindowStateMaximize
        'AppActivate wrd.Caption
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Stub.Massimizza. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
        Stub.Massimizza()
    End Sub
    Public Sub SetUnitStrings()
        Dim Num As UnitCollection
        colSI = New UnitConversionDictionary
        colTec = New UnitConversionDictionary
        colBR = New UnitConversionDictionary
        colPrima = New UnitConversionDictionary
        colDopo = New UnitConversionDictionary
        colConv = New UnitConversionDictionary

        colSI.Add("MPa", "p")
        colSI.Add("MPa", "pamm")
        colSI.Add("°C", "t")
        colSI.Add("mm", "l")
        colSI.Add("N", "f")
        colSI.Add("N.m", "fl")
        colSI.Add("mm²", "l2")
        colSI.Add("mm", "passo")
        colTec.Add("bar", "p")
        colTec.Add("kg/mm²", "pamm")
        colTec.Add("°C", "t")
        colTec.Add("mm", "l")
        colTec.Add("kg", "f")
        colTec.Add("kg.m", "fl")
        colTec.Add("mm²", "l2")
        colTec.Add("mm", "passo")
        colBR.Add("psi", "p")
        colBR.Add("psi", "pamm")
        colBR.Add("°F", "t")
        colBR.Add("in", "l")
        colBR.Add("lb", "f")
        colBR.Add("lb.in", "fl")
        colBR.Add("in²", "l2")
        colBR.Add("in", "passo")
        '----------------------------------
        Num = New UnitCollection
        Num.add(0)
        Num.add(3) : Num.add(2) : Num.add(4)
        colPrima.Add(Num, "p")
        Num = New UnitCollection
        Num.add(0)
        Num.add(4) : Num.add(3) : Num.add(6)
        colPrima.Add(Num, "pamm")
        Num = New UnitCollection
        Num.add(0)
        Num.add(4) : Num.add(4) : Num.add(4)
        colPrima.Add(Num, "t")
        Num = New UnitCollection
        Num.add(0)
        Num.add(4) : Num.add(4) : Num.add(3)
        colPrima.Add(Num, "l")
        Num = New UnitCollection
        Num.add(0)
        Num.add(7) : Num.add(7) : Num.add(7)
        colPrima.Add(Num, "f")
        Num = New UnitCollection
        Num.add(0)
        Num.add(7) : Num.add(7) : Num.add(7)
        colPrima.Add(Num, "fl")
        Num = New UnitCollection
        Num.add(0)
        Num.add(7) : Num.add(7) : Num.add(4)
        colPrima.Add(Num, "l2")
        Num = New UnitCollection
        Num.add(0)
        Num.add(4) : Num.add(4) : Num.add(3)
        colPrima.Add(Num, "passo")
        '-----------------------------------
        Num = New UnitCollection
        Num.add(0)
        Num.add(4) : Num.add(4) : Num.add(1)
        colDopo.Add(Num, "p")
        Num = New UnitCollection
        Num.add(0)
        Num.add(2) : Num.add(3) : Num.add(1)
        colDopo.Add(Num, "pamm")
        Num = New UnitCollection
        Num.add(0)
        Num.add(2) : Num.add(2) : Num.add(2)
        colDopo.Add(Num, "t")
        Num = New UnitCollection
        Num.add(0)
        Num.add(1) : Num.add(1) : Num.add(3)
        colDopo.Add(Num, "l")
        Num = New UnitCollection
        Num.add(0)
        Num.add(1) : Num.add(1) : Num.add(1)
        colDopo.Add(Num, "f")
        Num = New UnitCollection
        Num.add(0)
        Num.add(1) : Num.add(1) : Num.add(1)
        colDopo.Add(Num, "fl")
        Num = New UnitCollection
        Num.add(0)
        Num.add(1) : Num.add(1) : Num.add(1)
        colDopo.Add(Num, "l2")
        Num = New UnitCollection
        Num.add(0)
        Num.add(1) : Num.add(1) : Num.add(3)
        colDopo.Add(Num, "passo")
        '----------------------------------
        Num = New UnitCollection
        Num.add(0)
        Num.add(1) : Num.add(100 / GRAV) : Num.add(PSI)
        colConv.Add(Num, "p")
        Num = New UnitCollection
        Num.add(0)
        Num.add(1) : Num.add(1.0# / GRAV) : Num.add(PSI)
        colConv.Add(Num, "pamm")
        Num = New UnitCollection
        Num.add(0)
        Num.add(1) : Num.add(1) : Num.add(1.0# / INC)
        colConv.Add(Num, "l")
        Num = New UnitCollection
        Num.add(0)
        Num.add(1) : Num.add(1.0# / GRAV) : Num.add(1.0# / NIUT)
        colConv.Add(Num, "f")
        Num = New UnitCollection
        Num.add(0)
        Num.add(1) : Num.add(1.0# / GRAV) : Num.add(1.0# / NIUT / INC)
        colConv.Add(Num, "fl")
        Num = New UnitCollection
        Num.add(0)
        Num.add(1) : Num.add(1) : Num.add(1.0# / INC / INC)
        colConv.Add(Num, "l2")
        Num = New UnitCollection
        Num.add(0)
        Num.add(1) : Num.add(1) : Num.add(1.0# / INC)
        colConv.Add(Num, "passo")
        '-----------------------------------
    End Sub

    Public Sub SigmaAmm()
        Dim Sfo, t, Sfa As Single
        With objMat
            If .Indmat = 0 Then Exit Sub
            t = Problem.t
            If Problem.unmi < 3 Then t = CSng(t * 1.8 + 32)
            .SigmaAmm(Problem.cod, t, Sfa, Sfo)
            Select Case Problem.unmi
                Case 1
                Case 2
                    Sfa = Sfa / GRAV
                    Sfo = Sfo / GRAV
                Case 3
                    Sfa = Sfa * PSI
                    Sfo = Sfo * PSI
            End Select
            Problem.sa1 = Sfo
            Problem.sa2 = Sfa
        End With
    End Sub

    Public Sub Azzera()
        With Problem
            .t = 0
            .p = 0
            .phydr = 0
            .DiamExtGuar = 0
            .N = 0
            .wnubbin = 0
            .sa1 = 0
            .sa2 = 0
            .nb = 0
            .ClasseGuarnizione = 0
            .TipoGuarnizione = 0
            .strClasseGuarnizione = ""
            .strTipoGuarnizione = ""
            .m = 0
            .yy = 0
            .y1 = 0
            .Face = 1
            .b = 0
            .Gef = 0
            .MatTira = ""
            .DN = ""
            .indMat = 0
            .Diam = 0
            .Dnoc = 0
            .Chiave = 0
            .diammed = 0
            .passofil = 0
            .Area = 0
            .alf = 30
            .coeffindexD = 2 '0 secco 1 ordinario 2 molycote 3 custom
            .coeffindexF = 2 '0 secco 1 ordinario 2 molycote 3 custom
            .fDado = 0
            .fFil = 0
            .wm1 = 0
            .wm2 = 0
            .wm = 0
            .am1 = 0
            .am2 = 0
            .am = 0
            .ab = 0
            .w0 = 0
            .v = 0
            .vobb = 0
            .vPilgrim = 0
            .areaPist = 0
            .presPist = 0
            .alfa = 0
            .beta = 0
            .torque = 0
            .k1 = 0
            .k2Pilgrim = 0
            .k2Torque = 0
            .k3 = 0
            .fGlob = 0
        End With
        Monitor.Oggetto.Inizializza()
    End Sub
End Module