Option Strict On
Option Explicit On 
Imports System.Reflection
Imports System.Threading
Public Class NoSuchDecimalSeparator
    Inherits System.Exception
    Sub New(ByVal message As String)
        MyBase.New(message)
    End Sub
End Class
Public Class clsTrigon
    Public Shared MPA As Single = 0.006894757
    Public Shared psi As Single = 145.0377439
    Public Shared NIUT As Single = 4.448222
    Public Shared GRAV As Single = 9.80655
    Public Shared MomToBS As Single = 0.008850748
    Public Shared INC As Single = 25.4
    Public Shared lb As Single = 1 / NIUT
    Public Shared TOLER As Single = 0.0001
    Public Shared Infinito As Single = 10000000000.0#
    Private Declare Auto Function PlaySound Lib "winmm.dll" (ByVal name _
       As String, ByVal hmod As Integer, ByVal flags As Integer) As Integer
    ' name specifies the sound file when the SND_FILENAME flag is set.
    ' hmod specifies an executable file handle.
    ' hmod must be Nothing if the SND_RESOURCE flag is not set.
    ' flags specifies which flags are set. 
    Private SeparatoreDecimale As String
    Private Const SND_SYNC As Integer = &H0           ' play synchronously
    Private Const SND_ASYNC As Integer = &H1          ' play asynchronously
    Private Const SND_FILENAME As Integer = &H20000   ' name is file name
    Private Const SND_RESOURCE As Integer = &H40004   ' name is resource name or atom
    Public Sub DuplicaTableDef(ByVal vTesta As DataTable, ByVal tabTesta As String, ByVal StringConnection As String)
        Lancio.Data.Access.AccessDatabase.CloneTableDefinition(vTesta, tabTesta, StringConnection)
    End Sub
    Public Sub TableDelete(ByVal Nome As String, ByVal StringConnection As String)
        Lancio.Data.Access.AccessDatabase.DeleteTable(Nome, StringConnection)
    End Sub
    Public Function TwipsToPixelsX(ByVal t As Double) As Double
        Return ScreenUnits.TwipsToPixels(t, True)
    End Function
    Public Function TwipsToPixelsY(ByVal t As Double) As Double
        Return ScreenUnits.TwipsToPixels(t, False)
    End Function
    Public Sub PlaySoundFile(ByVal filename As String)
        ' Plays a sound from filename.
        PlaySound(filename, Nothing, SND_FILENAME Or SND_ASYNC)
    End Sub
    Public Function StringaInformativaProgramma(ByVal a As Reflection.Assembly) As String
        Dim Fi As IO.FileInfo = New IO.FileInfo(a.Location)
        Dim data As String = Format(Fi.LastWriteTime, "d MMM yy")
        Dim Vers As String = a.GetName.Version.Major.ToString & "." & a.GetName.Version.Minor.ToString
        Dim aTitleAttr As AssemblyTitleAttribute() = CType(AssemblyTitleAttribute.GetCustomAttributes _
                            (a, GetType(AssemblyTitleAttribute)), AssemblyTitleAttribute())
        Return aTitleAttr(0).Title & " (Vers." & Vers & " " & data & ") "
    End Function
    Public Sub CenterForm(ByRef frm As Form)
        '-----------------------------------------------------------
        ' SUB: CenterForm
        '
        ' Centers the passed form just above center on the screen
        '-----------------------------------------------------------
        '
        frm.Top = CType((System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height * 0.85), Integer) \ 2 - frm.Height \ 2
        frm.Left = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width \ 2 - frm.Width \ 2
    End Sub
    Public Function Str2Cifre(ByRef i As Short) As String
        Dim St As String
        St = Str(i)
        If Len(St) = 2 Then
            Mid(St, 1, 1) = "0"
        Else
            St = Trim(St)
        End If
        Str2Cifre = St
    End Function
    Public Function acos(ByRef coseno As Single) As Single
        acos = CType(System.Math.Acos(coseno), Single)
    End Function
    Public Function asin(ByRef seno As Single) As Single
        asin = CType(System.Math.Asin(seno), Single)
    End Function
    Public Function Adjust(ByRef Strin As String, ByRef L2 As Short) As String
        Dim l2abs As Integer
        If Strin Is Nothing Then Strin = ""
        l2abs = Math.Abs(L2)
        If l2abs <= Strin.Length Then
            Return Strin.Substring(0, l2abs)
        ElseIf L2 > 0 Then
            Return Strin.PadRight(L2)
        Else
            Return Strin.PadLeft(-L2)
        End If
    End Function
    Public Function myStr(ByRef Singolo As Single, ByRef NSpazP As Short, ByRef NSpazD As Short, ByRef SwIntero As Short) As String
        Dim NSpaz, i As Integer
        Dim Form As String = ""
        If SwIntero > 0 Then
            NSpaz = NSpazP
            Form = New String(CType("#", Char), NSpaz - 1) & "0"
            Form = String.Format(Form, Singolo)
            If NSpaz > Len(Form) Then Form = Space(NSpaz - Len(Form)) & Form
            myStr = Form
            Exit Function
        Else
            NSpaz = NSpazP + NSpazD + 1
            Try
                Dim Assoluto As Double = Math.Abs(Singolo)
                If (Assoluto >= 10 ^ NSpazP Or Assoluto < 10 ^ -NSpazD) And Not Singolo = 0 Then
                    'Form = "{0," & NSpaz.ToString & ":E}"
                    Dim Esponente As Double = Math.Floor(Math.Log10(Assoluto))
                    Dim Mantissa As Double = Singolo / 10 ^ Esponente
                    If NSpaz > 7 Then
                        If Singolo >= 0 Then
                            Form = "#." & New String(CType("0", Char), NSpaz - 6) & "E+00"
                        Else
                            Form = "-#." & New String(CType("0", Char), NSpaz - 7) & "E+00"
                        End If
                    Else
                        Form = "#.E+00"
                    End If
                    myStr = Format(Singolo, Form)
                    Exit Function
                Else
                    Form = New String(CType("#", Char), NSpazP - 1) & "0." & New String(CType("0", Char), NSpazD)
                    Form = FormatS(Form, Singolo)
                End If
            Catch
            End Try
        End If
        For i = 1 To Len(Form) - 1
            If Mid(Form, i, 1) = SeparatoreDecimale Then
                Exit For
            ElseIf Mid(Form, i, 1) = "0" And Not Mid(Form, i + 1, 1) = SeparatoreDecimale Then
                Mid(Form, i, 1) = " "
            Else
                If Not (Mid(Form, i, 1) = "-" Or Mid(Form, i, 1) = " ") Then Exit For
            End If
        Next
        myStr = Form
    End Function
    Public Function TogliBlank(ByRef S As String) As String
        Dim i As Integer
        Dim SottoStr As String
        Dim SS As String = S.Trim
        For i = 1 To SS.Length
            SottoStr = SS.Substring(i - 1, 1)
            If SottoStr = " " Or SottoStr = "." Or SottoStr = "-" Then
                SS = SS.Substring(0, i - 1) & "_" & SS.Substring(i)
            End If
        Next
        TogliBlank = SS
    End Function

    Public Function SegnaLibro(ByVal Nome As String, ByVal Nascosto As Boolean) As String
        Dim v As String = ""
        If Nascosto Then v = "_\v "
        Return FormatS("{" & v & "{_\*_\bkmkstart &}&{_\*_\bkmkend &}}", Nome, Nome, Nome)
    End Function
    Public Function Massimo(ByVal ParamArray a() As Single) As Single
        Dim nParam As Short = CShort(UBound(a))
        Dim i As Short
        Dim m As Single = a(0)
        For i = 1 To nParam
            m = Math.Max(m, a(i))
        Next
        Return m
    End Function
    Public Function Minimo(ByVal ParamArray a() As Single) As Single
        Dim nParam As Short = CShort(UBound(a))
        Dim i As Short
        Dim m As Single = a(0)
        For i = 1 To nParam
            m = Math.Min(m, a(i))
        Next
        Return m
    End Function
    Public Function FormatS(ByVal Form As String, ByVal ParamArray a() As Object) As String
        Dim k As Integer
        Dim ifl As Integer
        Dim n, n1, n2 As Integer
        Dim Des As String
        Dim Risul As String = ""
        Dim Risul0 As String = ""
        Dim Risul1 As String = ""
        Dim Risul2 As String = ""
        Dim nIniz, nFine As Integer
        Dim nParam As Integer, alfa As Integer ' 0 numerico 1 alfa \\ 2 alfa &
        Dim Ritorno As String = ""
        Static nonPul As Boolean
        nParam = UBound(a)
        If nParam = -1 Then
            Select Case Form
                Case "non|" : nonPul = True
                Case "|" : nonPul = False
            End Select
            Return ""
        Else
        End If
        Des = Form
        If Not nonPul Then
            For k = 0 To nParam
                Risul = Pulisci(a(k), Form)
                If Risul = "" Then GoTo Cont
                Form = Risul
            Next
            nParam = -1
            Des = ""
        End If
Cont:   Try
            For k = 0 To nParam
                If a(k) Is Nothing Then a(k) = ""
                If a(k).GetType Is GetType(String) Then alfa = 1 Else alfa = 0
                nIniz = Cercanum(Des, 1, alfa)
                nFine = CercaNumFine(Des, nIniz, alfa)
                If nFine - nIniz < 0 Then Return Des
                If nIniz > 1 Then Risul = Risul & Des.Substring(0, nIniz - 1)
                Select Case alfa
                    Case 0 'numerico
                        Dim Strin As String = Des.Substring(nIniz - 1, nFine - nIniz + 1)
                        If Strin.IndexOf("0"c) < 0 Then
                            n = Strin.IndexOf("."c)
                            If n > 1 Then
                                Strin = Strin.Substring(0, n - 1) + "0" + Strin.Substring(n)
                            ElseIf n = 1 Then
                                Strin = "0" + Strin.Substring(n)
                            ElseIf n = 0 Then
                                Strin = ".0" + Strin.Substring(2)
                            Else
                                Strin = Strin.Substring(0, Strin.Length - 1) + "0"
                            End If
                        End If
                        If Strin.Length > 4 Then
                            If Strin.Substring(Strin.Length - 4) = "^^^^" Then
                                Strin = Strin.Substring(0, Strin.Length - 4) & "E+00"
                            ElseIf Strin.Substring(Strin.Length - 3) = "^^^" Then
                                Strin = Strin.Substring(0, Strin.Length - 3) & "E+0"
                            End If
                        End If
                        Risul = Risul & "_{" & k.ToString.Trim & "," & (nFine - nIniz + 1).ToString & ":" & Strin & "_}"
                    Case 1 '\    \
                        Risul = Risul & "_{" & k.ToString.Trim & "," & (-(nFine - nIniz + 1)).ToString & "_}"
                    Case 2 ' &
                        Risul = Risul & "_{" & k.ToString.Trim & "_}"
                End Select
                Des = Des.Substring(nFine, Des.Length - nFine)  ' Right(Des, Len(Des) - nFine)
            Next k
            Risul = Risul & Des
            n1 = 0
            Do
                n = Risul.IndexOf(CChar("}"), n1)
                If n < 0 Then Exit Do
                If Risul.Substring(n - 1, 1) = "_" Then
                    'Risul = Risul.Substring(0, n - 1) & Risul.Substring(n + 1)
                    n1 = n + 1
                Else
                    Risul = Risul.Substring(0, n + 1) & "}" & Risul.Substring(n + 1)
                    n1 = n + 2
                End If
            Loop
            n1 = 0
            Do
                n = Risul.IndexOf(CChar("{"), n1)
                If n < 0 Then Exit Do
                If n > 0 Then
                    If Risul.Substring(n - 1, 1) = "_" Then
                        '     Risul = Risul.Substring(0, n - 1) & Risul.Substring(n + 1)
                        n1 = n + 1
                    Else
                        Risul = Risul.Substring(0, n + 1) & "{" & Risul.Substring(n + 1)
                        n1 = n + 2
                    End If
                Else
                    Risul = "{" & Risul
                    n1 = 2
                End If
            Loop
            Pul(Risul)
            n = Risul.IndexOf("><") + 1 ' InStr(Risul, "><")
            If n > 0 Then
                n1 = Risul.IndexOf("><", n + 1) + 1 ' InStr(n + 2, Risul, "><")
                If n1 > 0 Then
                    Risul0 = Risul.Substring(0, n - 1) ' Left(Risul, n - 1)
                    n2 = Risul.Length - n1 - 1
                    Risul2 = Risul.Substring(n1 + 1, n2) ' Right(Risul, Len(Risul) - n1 - 1)
                    Risul1 = Risul.Substring(n + 1, n1 - n - 2) ' Mid(Risul, n + 2, n1 - n - 2)
                    ifl = FreeFile()
                    Try
                        FileOpen(ifl, RTrim(gInizio.Archdir) & Risul1, OpenMode.Input, , OpenShare.Shared)
                    Catch e1 As Exception
                        MsgBox(e1.Message + vbCrLf + "Errore nella lettura di una figura" + vbCrLf + e1.StackTrace)
                        Ritorno = Risul
                        Return Ritorno
                    End Try
                    Risul = Risul0
                    Do
                        If EOF(ifl) Then Exit Do
                        Risul = Risul & LineInput(ifl)
                    Loop
                    FileClose(ifl)
                    Risul = Risul & Risul2
                End If
            End If
            If nParam > -1 Then
                Ritorno = String.Format(Risul, a)
            Else
                Ritorno = Risul
            End If
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
        Return Ritorno
    End Function
    Public Overloads Sub SWAP(ByRef a As Object, ByRef b As Object)
        Dim c As Object
        c = a
        a = b
        b = c
    End Sub
    Public Overloads Sub SWAP(ByRef a As IO.StreamWriter, ByRef b As IO.StreamWriter)
        Dim c As IO.StreamWriter
        c = a
        a = b
        b = c
    End Sub
    Public Overloads Sub SWAP(ByRef a As Short, ByRef b As Short)
        Dim c As Short
        c = a
        a = b
        b = c
    End Sub
    Public Overloads Sub SWAP(ByRef a As Single, ByRef b As Single)
        Dim c As Single
        c = a
        a = b
        b = c
    End Sub
    Private Function Pulisci(ByRef a As Object, ByRef Form As String) As String
        Dim n1, n, n2 As Integer
        n2 = 1
Rif:    n = Form.IndexOf("|", n2 - 1) + 1 ' InStr(n2, Form, "|")
        If n = 0 Then
            Pulisci = "" 'Formato(a, Form)
        Else
            If n > 1 Then
                If Form.Substring(n - 2, 1) = "_" Then
                    n2 = n + 1
                    GoTo Rif
                End If
            End If
            n1 = Form.IndexOf("|", n) + 1 ' InStr(n + 1, Form, "|")
            If n1 = 0 Then
                Pulisci = ""
            Else
                Dim s As String = Form.Substring(0, n - 1) & Adjust(FormatS(Form.Substring(n, n1 - n - 1), a), CShort(-n1 + n + 1))
                If Form.Length > n1 Then s = s & Form.Substring(n1)
                Pulisci = s
            End If
        End If
    End Function
    Public Sub New()
        MyBase.New()
        Trigon = Me
        SeparatoreDecimale = Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator
    End Sub
    Function arco(ByVal DirX As Single, ByVal DirY As Single) As Single
        Dim Alfa As Single
        If System.Math.Abs(DirX) < TOLER And System.Math.Abs(DirY) < TOLER Then arco = 0 : Exit Function '22-3-99
        '-----
        If System.Math.Abs(1 - System.Math.Sqrt(DirX * DirX + DirY * DirY)) > TOLER Then
            '   MsgBox "Errore impossibile in TRIGON/arco" + Str$(DirX) + Str$(DirY)
            arco = Math.PI / 2
            Exit Function
        End If
        If System.Math.Abs(DirX) < 0.5 Then
            Alfa = acos(DirX)
            If DirY < 0 Then Alfa = CSng(2 * Math.PI - Alfa)
        Else
            Alfa = CSng(System.Math.Asin(DirY))
            If DirX < 0 Then Alfa = CSng(Math.PI - Alfa)
        End If
        If Alfa < 0 Then Alfa = CSng(2 * Math.PI + Alfa)
        arco = Alfa
    End Function
    Public Function InterLogar(ByRef X As Single, ByRef x1 As Single, ByRef x2 As Single, ByRef y1 As Single, ByRef y2 As Single) As Single
        Dim Ris As Single
        If y1 = y2 Then
            Ris = y1
        ElseIf x2 = 0 Then
            Ris = y1 + (y2 - y1) * (X - x1) / (x2 - x1)
        ElseIf x1 = x2 Then
            If X > x1 Then Ris = y2 Else Ris = y1
        Else
            Ris = CType(System.Math.Exp(System.Math.Log(y1) + System.Math.Log(y2 / y1) * System.Math.Log(X / x1) / System.Math.Log(x2 / x1)), Single)
        End If
        InterLogar = Ris
    End Function
    Public Function ValVir(ByVal s As String) As Single
        If s Is Nothing Then
            Return 0
        Else
            Return CSng(Val(ConvertiVirgola(s)))
        End If
    End Function
    Public Function ConvertiVirgola(ByVal s As String) As String
        Select Case SeparatoreDecimale
            Case "."
            Case ","
                s = s.Replace(",", ".")
            Case Else
                Throw New NoSuchDecimalSeparator("Il separatore decimale '" & SeparatoreDecimale & "'non è stato considerato.")
        End Select
        Return s
    End Function
    Public Function ConvertiPunto(ByVal s As String) As String
        Select Case SeparatoreDecimale
            Case "."
            Case ","
                s = s.Replace(".", ",")
            Case Else
                Throw New NoSuchDecimalSeparator("Il separatore decimale '" & SeparatoreDecimale & "'non è stato considerato.")
        End Select
        Return s
    End Function
    Public Function ConvPoll(ByRef d As String) As Single
        Dim n, n1 As Integer
        Dim R As Single
        Try
            d = d.TrimStart ' LTrim(d)
            n = d.IndexOf("/") + 1 ' InStr(d, "/")
            If n = 0 Then
                ConvPoll = CType(Val(d), Single)
            Else
                n1 = d.IndexOf(" ") + 1 ' InStr(d, " ")
                If n1 > 0 Then R = CType(Val(Left(d, n1)), Single)
                d = d.Substring(n1, d.Length - n1) ' Right(d, Len(d) - n1)
                n = d.IndexOf("/") + 1 ' InStr(d, "/")
                R = CType(R + Val(d.Substring(0, n - 1)) / _
                              Val(d.Substring(n, d.Length - n)), Single)
                ConvPoll = R
            End If
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Function
    Public Sub Proietta(ByRef PunPIa As clsVec3, ByRef NorPIa As clsVec3, ByRef Punto As clsVec3, ByRef PunPro As clsVec3)
        Dim Vec As New clsVec3
        Dim Proiez As Single
        Vec.X = Punto.X - PunPIa.X
        Vec.y = Punto.y - PunPIa.y
        Vec.Z = Punto.Z - PunPIa.Z
        Proiez = Vec.ProdScalar(NorPIa)
        'Proiez=distanza del punto dal PIano
        PunPro.X = Punto.X - Proiez * NorPIa.X
        PunPro.y = Punto.y - Proiez * NorPIa.y
        PunPro.Z = Punto.Z - Proiez * NorPIa.Z
        'Punto Proiettato
    End Sub
    Sub CoorPIa(ByRef Origine As clsVec3, ByRef Ausil As clsVec3, ByRef Punto As clsVec3, ByRef Coor As clsVec2, ByRef NorPIa As clsVec3)
        Dim Vec1 As New clsVec3
        Dim Vec2 As New clsVec3
        Dim Vec3 As New clsVec3
        Dim Dist1 As Single
        Vec1.X = Ausil.X - Origine.X
        Vec1.y = Ausil.y - Origine.y
        Vec1.Z = Ausil.Z - Origine.Z
        Dist1 = CType(System.Math.Sqrt(Vec1.ProdScalar(Vec1)), Single)
        If Dist1 = 0 Then Exit Sub
        Vec1.X = Vec1.X / Dist1
        Vec1.y = Vec1.y / Dist1
        Vec1.Z = Vec1.Z / Dist1
        Vec1.DirAlpha(NorPIa, Vec3, Math.PI / 2)
        Vec2.X = Punto.X - Origine.X
        Vec2.y = Punto.y - Origine.y
        Vec2.Z = Punto.Z - Origine.Z
        Coor.X = Vec2.ProdScalar(Vec1)
        Coor.y = Vec2.ProdScalar(Vec3)
    End Sub
    Sub ComposDir(ByRef d1 As clsVec2, ByRef D2 As clsVec2)
        Dim Alfa1, Alfa2 As Single
        Alfa1 = arco((d1.X), (d1.y))
        Alfa2 = arco((D2.X), (D2.y))
        d1.X = CType(System.Math.Cos(Alfa1 + Alfa2), Single)
        d1.y = CType(System.Math.Sin(Alfa1 + Alfa2), Single)
    End Sub
    Sub ProdVect(ByRef V1 As clsVec3, ByRef V2 As clsVec3, ByRef V3 As clsVec3)
        V3.X = V1.y * V2.Z - V1.Z * V2.y
        V3.y = V1.Z * V2.X - V1.y * V2.Z
        V3.Z = V1.X * V2.y - V1.y * V2.X
    End Sub
    Sub RotateX(ByRef Vec As clsVec3, ByRef Alpha As Single)
        Dim cosa, sina As Single
        Dim NewY, NewZ As Single
        cosa = CType(System.Math.Cos(Alpha), Single)
        sina = CType(System.Math.Sin(Alpha), Single)
        NewY = Vec.y * cosa - Vec.Z * sina
        NewZ = Vec.y * sina + Vec.Z * cosa
        Vec.y = NewY
        Vec.Z = NewZ
    End Sub

    Sub RotateY(ByRef Vec As clsVec3, ByRef Alpha As Single)
        Dim cosa, sina As Single
        Dim NewX, NewZ As Single
        cosa = CType(System.Math.Cos(Alpha), Single)
        sina = CType(System.Math.Sin(Alpha), Single)
        NewZ = Vec.Z * cosa - Vec.X * sina
        NewX = Vec.Z * sina + Vec.X * cosa
        Vec.X = NewX
        Vec.Z = NewZ
    End Sub

    Sub RotateZ(ByRef Vec As clsVec3, ByRef Alpha As Single)
        Dim cosa, sina As Single
        Dim NewY, NewX As Single
        cosa = CType(System.Math.Cos(Alpha), Single)
        sina = CType(System.Math.Sin(Alpha), Single)
        NewX = Vec.X * cosa - Vec.y * sina
        NewY = Vec.X * sina + Vec.y * cosa
        Vec.X = NewX
        Vec.y = NewY
    End Sub
    Public Function myVal(ByRef a As String) As Single
        Dim Sep As String
        Dim n As Integer
        Sep = SeparatoreDecimale
        Select Case Sep
            Case "."
                n = InStr(a, ",")
                If n > 0 Then Mid(a, n, 1) = Sep
            Case ","
                n = InStr(a, ".")
                If n > 0 Then Mid(a, n, 1) = Sep
        End Select
        myVal = CType(Val(a), Single)
    End Function
    Public Function Formato(ByRef f As String, ByRef a As Object) As String
        Dim Ris As String
        Dim n, n1 As Integer
        Ris = Microsoft.VisualBasic.Strings.Format(a, f)
        If InStr(f, ",") = 0 Then
            n = InStr(Ris, ",")
            If n > 0 Then Mid(Ris, n, 1) = "."
        End If
        Select Case VarType(a)
            Case VariantType.Short, VariantType.Integer, VariantType.Single, VariantType.Double
                If CType(a, Double) = 0 Or Len(Ris) = 0 Then
                    n = InStr(Ris, ".")
                    Select Case n
                        Case 0
                            If Len(Ris) > 0 Then
                                Mid(Ris, Len(Ris), 1) = "0"
                            ElseIf Len(f) > 0 Then
                                Ris = "0"
                            End If
                        Case 1
                            n1 = InStr(f, ".")
                            Select Case n1
                                Case 0
                                Case Else
                                    Ris = "0" & Ris
                            End Select
                        Case Else
                            Mid(Ris, n - 1, 1) = "0"
                    End Select
                End If
        End Select
        Formato = Ris
    End Function
    Public Sub LegFig(ByRef f As String, ByRef Tsut As Single, ByRef Alam As Single, _
                      ByRef Para1 As Single, ByRef Para2 As Single, ByRef xxx1 As Single, _
                      ByRef xxx2 As Single, ByRef TiPInt As Short)
        Dim iParam As Integer
        Dim Riga As String
        Dim Fact As Single
        Dim xx12, xx22 As Single
        Dim icount As Integer
        Dim xx11, xx21 As Single
        Dim yy21, yy22 As Single
        Dim yy11, yy12 As Single
        Dim xvec1, yvec1 As Single
        Dim xvec2, yvec2 As Single
        Dim CopPIa1 As String = ""
        Dim CopPIa2 As String = ""
        Dim x1, y1 As Single
        Dim x2, y2 As Single
        Dim ifl As Integer
        Try
            ifl = FreeFile()
            FileOpen(ifl, f, OpenMode.Input, , OpenShare.Shared)
            Call LeggiParam(ifl, Tsut, Para1, Para2, iParam)
            Riga = LineInput(ifl)
            Fact = CType(Val(Riga), Single) : If Fact = 0 Then Fact = 1
            xx12 = 0 : xx22 = 0 : icount = 0
            Do
                icount = icount + 1
250:            If EOF(ifl) Then
275:                If xx12 = 0 Then
                        xx12 = xx11 : yy12 = yy11
                        xx11 = xvec1 : yy11 = yvec1
                    End If 'k
                    If xx22 = 0 Then
                        xx22 = xx21 : yy22 = yy21
                        xx21 = xvec2 : yy21 = yvec2
                    End If 'l
                    Exit Do
                End If 'm
280:            Riga = LineInput(ifl)
                If Len(RTrim(Riga)) = 0 Then GoTo 275
                Call EstraiCopPIa(Riga, CopPIa1, CopPIa2, CShort(iParam))
320:            x1 = CType(Val(Left(CopPIa1, 5)), Single)
                y1 = CType(Val(Right(CopPIa1, 5)), Single)
                If xx12 = 0 Then
                    If x1 > Alam And icount > 1 Then
                        xx12 = x1 : yy12 = y1
                    ElseIf x1 > 0 Then
                        xvec1 = xx11 : yvec1 = yy11
                        xx11 = x1 : yy11 = y1
                    Else 'f
                        xx12 = xx11 : yy12 = yy11
                        xx11 = xvec1 : yy11 = yvec1
                    End If 'p
                End If 'q
360:            x2 = CType(Val(Left(CopPIa2, 5)), Single)
                y2 = CType(Val(Right(CopPIa2, 5)), Single)
                If xx22 = 0 Then
                    If x2 > Alam And icount > 1 Then
                        xx22 = x2 : yy22 = y2
                    ElseIf x2 > 0 Then
                        xvec2 = xx21 : yvec2 = yy21
                        xx21 = x2 : yy21 = y2
                    Else 'h
                        xx22 = xx21 : yy22 = yy21
                        xx21 = xvec2 : yy21 = yvec2
                    End If 'r
                End If 's
400:            If xx12 > 0 And xx22 > 0 Then Exit Do
            Loop
            Select Case TiPInt
                Case 1
420:                xxx1 = Fact * InterLogar(Alam, xx11, xx12, yy11, yy12)
440:                xxx2 = Fact * InterLogar(Alam, xx21, xx22, yy21, yy22)
                Case 2
                    xxx1 = CType(yy11 + (yy12 - yy11) * System.Math.Log(Alam / xx11) / System.Math.Log(xx12 / xx11), Single)
                    xxx2 = CType(yy21 + (yy22 - yy21) * System.Math.Log(Alam / xx21) / System.Math.Log(xx22 / xx21), Single)
                Case 3
                    xxx1 = yy11 + (yy12 - yy11) * (Alam - xx11) / (xx12 - xx11)
                    xxx2 = yy21 + (yy22 - yy21) * (Alam - xx21) / (xx22 - xx21)
            End Select
            FileClose(ifl)
        Catch e As Exception
            MessageBox.Show(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Public Sub LegFigInv(ByRef f As String, ByRef Tsut As Single, ByRef Alam As Single, ByRef Para1 As Single, ByRef Para2 As Single, ByRef xxx1 As Single, ByRef xxx2 As Single)
        Dim iParam As Integer
        Dim Riga As String
        Dim xx21, xx11, xx12, xx22 As Single
        Dim yy21, yy11, yy12, yy22 As Single
        Dim xvec1, xvec2 As Single
        Dim yvec1, yvec2 As Single
        Dim CopPIa1 As String = ""
        Dim CopPIa2 As String = ""
        Dim x1, y1 As Single
        Dim x2, y2 As Single
        Dim ifl As Integer
        ifl = FreeFile()
        FileOpen(ifl, f, OpenMode.Input, , OpenShare.Shared)
        Call LeggiParam(ifl, Tsut, Para1, Para2, iParam)
        Riga = LineInput(ifl)
        xx12 = 0 : xx22 = 0
        Do
            If EOF(ifl) Then
275:            If xx12 = 0 Then
                    xx12 = xx11 : yy12 = yy11
                    xx11 = xvec1 : yy11 = yvec1
                End If
                If xx22 = 0 Then
                    xx22 = xx21 : yy22 = yy21
                    xx21 = xvec2 : yy21 = yvec2
                End If
                Exit Do
            End If
            Riga = LineInput(ifl)
            If Len(RTrim(Riga)) = 0 Then GoTo 275
            Call EstraiCopPIa(Riga, CopPIa1, CopPIa2, CShort(iParam))
            x1 = CType(Val(Right(CopPIa1, 5)), Single)
            y1 = CType(Val(Left(CopPIa1, 5)), Single)
            If xx12 = 0 Then
                If System.Math.Abs(x1) < System.Math.Abs(Alam) Then
                    xx12 = x1 : yy12 = y1
                ElseIf x1 <> 0 Then
                    xvec1 = xx11 : yvec1 = yy11
                    xx11 = x1 : yy11 = y1
                Else 'l
                    xx12 = xx11 : yy12 = yy11
                    xx11 = xvec1 : yy11 = yvec1
                End If
            End If
            x2 = CType(Val(Right(CopPIa2, 5)), Single)
            y2 = CType(Val(Left(CopPIa2, 5)), Single)
            If xx22 = 0 Then
                If System.Math.Abs(x2) < System.Math.Abs(Alam) Then
                    xx22 = x2 : yy22 = y2
                ElseIf x2 <> 0 Then
                    xvec2 = xx21 : yvec2 = yy21
                    xx21 = x2 : yy21 = y2
                Else 'm
                    xx22 = xx21 : yy22 = yy21
                    xx21 = xvec2 : yy21 = yvec2
                End If
            End If
            If xx12 > 0 And xx22 > 0 Then Exit Do
        Loop
        FileClose(ifl)
        xxx1 = yy11 + (yy12 - yy11) * (Alam - xx11) / (xx12 - xx11)
        xxx2 = yy21 + (yy22 - yy21) * (Alam - xx21) / (xx22 - xx21)
    End Sub
    Private Sub LeggiParam(ByRef ifl As Integer, ByRef Tsut As Single, ByRef Para1 As Single, ByRef Para2 As Single, ByRef iParam As Integer)
        Dim Param(15) As Single
        Dim Riga As String
        Dim istart, i, nchar As Integer
        Dim nParam As Integer
        Riga = LineInput(ifl)
        i = 0
        Do
            i = i + 1
            istart = 4 + (i - 1) * 11
            If istart >= Len(Riga) Then Exit Do
            nchar = 11
            If istart + nchar - 1 > Len(Riga) Then nchar = Len(Riga) - istart + 1
            Param(i) = CType(Val(Mid(Riga, istart, nchar)), Single)
        Loop
        nParam = i - 1
        Dim counter As Short
        counter = CShort(nParam)
        For i = counter To 1 Step -1
            If Param(i) = 0 Then nParam = nParam - 1 Else Exit For
        Next
        For i = 1 To nParam - 1
            If (Param(i + 1) - Tsut) * (Tsut - Param(i)) >= 0 Then iParam = i : Exit For
        Next
        If i = nParam Then
            If System.Math.Abs(Param(1) - Tsut) < System.Math.Abs(Param(nParam) - Tsut) Then iParam = 1 Else iParam = nParam - 1
        End If
        Para1 = Param(iParam) : Para2 = Param(iParam + 1)
    End Sub
    Private Sub EstraiCopPIa(ByRef Riga As String, ByRef CopPIa1 As String, ByRef CopPIa2 As String, ByRef iParam As Short)
        Dim l As Integer
        Try
700:        If 4 + iParam * 11 - 1 > Len(Riga) Then
                If Len(Riga) - (4 + (iParam - 1) * 11 - 1) > 0 Then
                    CopPIa1 = Adjust(Right(Riga, Len(Riga) - (4 + (iParam - 1) * 11 - 1)), 11) ' SPACE$(11)
                Else
                    CopPIa1 = Space(11)
                End If
            Else 'd
                CopPIa1 = Mid(Riga, 4 + (iParam - 1) * 11, 11)
            End If 'n
            If 4 + (iParam + 1) * 11 - 1 > Len(Riga) Then
710:            l = Len(Riga) - (4 + (iParam) * 11 - 1)
                If l > 0 Then
                    CopPIa2 = Adjust(Right(Riga, l), 11) 'SPACE$(11)
                Else
                    CopPIa2 = Space(11)
                End If
            Else 'e
720:            CopPIa2 = Mid(Riga, 4 + (iParam) * 11, 11)
            End If 'o
        Catch e As Exception
            MessageBox.Show(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Private Function Cercanum(ByVal Des As String, ByVal j As Integer, ByRef alfa As Integer) As Integer
        Dim n, m, m1, jin, n1 As Integer
        If alfa = 0 Then
Cerca:      n = Des.IndexOf("#", j - 1) + 1 ' InStr(j, Des, "#") 
            If n = 0 Then n = Des.IndexOf(".", j - 1) + 1 ' InStr(j, Des, ".")
            If n = 0 Then n = Des.IndexOf("0", j - 1) + 1 ' InStr(j, Des, "0")
            If n = 0 Then n = Des.IndexOf("+", j - 1) + 1 ' InStr(j, Des, "+")
            If n = 0 Then n = Des.IndexOf("-", j - 1) + 1 ' InStr(j, Des, "-")
            If n > 1 Then
                If Mid(Des, n - 1, 1) = "_" Then j = n + 1 : GoTo Cerca
            End If
            If n < Des.Length And n > 0 Then
                n1 = Des.IndexOf("#", n)  ' InStr(n + 1, Des, "#")
                If n1 = 0 Or n1 > n + 1 Then n1 = Des.IndexOf("0", n) 'InStr(n + 1, Des, "0")
                If n1 = 0 Or n1 > n + 1 Then n1 = Des.IndexOf(".", n)
                If n1 = 0 Or n1 > n + 1 Then j = n + 1 : GoTo Cerca
            End If
            Return n
        End If
        jin = j
        Do
            m = Des.IndexOf("\", jin - 1) + 1 ' InStr(jin, Des, "\")
            If m > 1 Then
                If Mid(Des, m - 1, 1) = "_" Then
                    jin = m + 1
                Else
                    Exit Do
                End If
            Else
                Exit Do
            End If
        Loop
        jin = j
        Do
            m1 = Des.IndexOf("&", jin - 1) + 1 ' InStr(jin, Des, "&")
            If m1 > 1 Then
                If Mid(Des, m1 - 1, 1) = "_" Then
                    jin = m1 + 1
                Else
                    Exit Do
                End If
            Else
                Exit Do
            End If
        Loop
        If (n < m Or m = 0) And (n < m1 Or m1 = 0) And n > 0 Then
            alfa = 0
            Cercanum = n
        ElseIf (m < n Or n = 0) And (m < m1 Or m1 = 0) And m > 0 Then
            alfa = 1
            Cercanum = m
        ElseIf (m1 < n Or n = 0) And (m1 < m Or m = 0) And m1 > 0 Then
            alfa = 2
            Cercanum = m1
        Else
            alfa = -1
        End If
    End Function
    Private Function CercaNumFine(ByVal Des As String, ByVal j As Integer, ByVal alfa As Integer) As Integer
        Dim n As Integer
        Select Case alfa
            Case 0
                j -= 1
                Do
                    j += 1
                    n = InStr(j + 1, Des, "#")
                    If Not n = j + 1 Then n = InStr(j + 1, Des, ".")
                    If Not n = j + 1 Then n = InStr(j + 1, Des, "0")
                    If Not n = j + 1 Then n = InStr(j + 1, Des, "+")
                    If Not n = j + 1 Then n = InStr(j + 1, Des, "-")
                    If Not n = j + 1 Then n = InStr(j + 1, Des, "^")
                    If Not n = j + 1 Then n = InStr(j + 1, Des, "E")
                    If Not n = j + 1 Then n = InStr(j + 1, Des, "D")
                    If Not n = j + 1 Then n = InStr(j + 1, Des, "e")
                    If Not n = j + 1 Then n = InStr(j + 1, Des, "d")
                Loop While n = j + 1
                CercaNumFine = j
            Case 1
                n = InStr(j + 1, Des, "\")
                CercaNumFine = n
            Case 2
                CercaNumFine = j
        End Select
    End Function
    Private Sub Pul(ByRef Ris As String)
        Dim j As Integer, jUlt As Integer
        Dim n As Integer
        j = 0 : jUlt = 0
        Do
            j = j + 1
            n = InStr(j, Ris, "_")
            If n = 0 Then Exit Do
            If n > jUlt Then
                If n > 1 Then
                    Ris = Left(Ris, n - 1) & Right(Ris, Len(Ris) - n)
                Else
                    Ris = Right(Ris, Len(Ris) - 1)
                End If
                jUlt = n
                j = j - 1
            End If
        Loop
    End Sub
End Class