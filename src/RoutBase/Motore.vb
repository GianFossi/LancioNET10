Option Strict On
Option Explicit On
Imports System.IO
Imports System.Windows.Forms
Imports System.Reflection
Imports System.Data
Imports System.Data.OleDb
Imports System.Runtime.Serialization
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Collections
Public Class clsProblems
    Inherits DictionaryBase
    Default Public Property Item(ByVal key As String) As clsProblAbout
        Get
            Return CType(Dictionary(key), clsProblAbout)
        End Get
        Set(ByVal Value As clsProblAbout)
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

    Public Sub Add(ByVal key As String, ByVal value As clsProblAbout)
        Dictionary.Add(key, value)
    End Sub 'Add

    Public Function Contains(ByVal key As String) As Boolean
        Return Dictionary.Contains(key)
    End Function 'Contains

    Public Sub Remove(ByVal key As String)
        Dictionary.Remove(key)
    End Sub 'Remove
End Class
Public Class clsProblAbout
    Public Problem As clsProblem
    Public About As clsAbout
End Class
Public Class clsMotore
    Public Const Conn As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source="
    Public Const ConnFine As String = ";Persist Security Info=False"
    Public Const ConnFineExcel As String = ";Extended Properties=excel 8.0;Persist Security Info=False"
    Public Chiamante As Object
    Public AssemblyOriginale As Reflection.Assembly
    Public RadiceHelp As String
    Public RispostaMessaggio As ChiaviMess
    Public Problems As clsProblems
    Public Problem As clsProblem
    Public About As clsAbout
    Public Inizio As clsInizio
    Public Modo As Short
    Private WithEvents mioForm As frmProblem
    Private NonMostrare As Boolean
    Private Ogg As Form
    Public InputForms As IFCollection
    Private WithEvents formMess As frmMessaggio
    Private WithEvents InputForm1 As frmInput
    Private WithEvents InputForm2 As frmInput
    Private WithEvents InputForm3 As frmInput
    Private WithEvents InputForm4 As frmInput
    Private WithEvents QualeForm1 As frmQuale
    Private WithEvents QualeForm2 As frmQuale
    Private WithEvents QualeForm3 As frmQuale
    Private WithEvents QualeForm4 As frmQuale
    Private WithEvents CheckForm1 As frmCheck
    Private WithEvents CheckForm2 As frmCheck
    Private WithEvents CheckForm3 As frmCheck
    Private WithEvents CheckForm4 As frmCheck
    Private WithEvents Progresso As frmProgress
    Private Ris() As String
    Event Cambiofile(ByRef f As String)
    Event SondaFile(ByVal f As String)
    Event SalvaData(ByRef f As String)
    'Event ProgrFine(b As Boolean)
    Event Finito(ByRef s As String)
    Event Uccidi(ByVal f As String)
    Event Rifiuto()
    Event ProgrCancella()
    Event NuovoLav(ByRef f As String)
    Event OkInput(ByRef f As Short)
    Event CancelInput(ByRef f As Short)
    Event OptClick(ByRef f As Short, ByRef i As Short)
    Event ComboClick1(ByRef Index As Short)
    Event ComboClick2(ByRef Index As Short)
    Event ComboClick3(ByRef Index As Short)
    Event ComboClick4(ByRef Index As Short)
    Event CheckClick1(ByRef Index As Short)
    Event CheckClick2(ByRef Index As Short)
    Event CheckClick3(ByRef Index As Short)
    Event CheckClick4(ByRef Index As Short)
    Event dAiuClick(ByRef n As Short, ByRef Index As Short)
    Event TestoCambia1(ByRef Index As Short)
    Event TestoCambia2(ByRef Index As Short)
    Event TestoCambia3(ByRef Index As Short)
    Event TestoCambia4(ByRef Index As Short)
    Private Sub CheckForm1_CancelClick() Handles CheckForm1.CancelClick
        RaiseEvent CancelInput(1)
    End Sub

    Private Sub CheckForm1_CheckClick(ByRef indice As Short) Handles CheckForm1.CheckClick
        RaiseEvent CheckClick1(indice)
    End Sub

    Private Sub CheckForm1_OKClick() Handles CheckForm1.OKClick
        RaiseEvent OkInput(1)
    End Sub

    Private Sub CheckForm2_CancelClick() Handles CheckForm2.CancelClick
        RaiseEvent CancelInput(2)
    End Sub

    Private Sub CheckForm2_CheckClick(ByRef indice As Short) Handles CheckForm2.CheckClick
        RaiseEvent CheckClick2(indice)
    End Sub

    Private Sub CheckForm2_OKClick() Handles CheckForm2.OKClick
        RaiseEvent OkInput(2)
    End Sub

    Private Sub CheckForm3_CancelClick() Handles CheckForm3.CancelClick
        RaiseEvent CancelInput(3)
    End Sub

    Private Sub CheckForm3_CheckClick(ByRef indice As Short) Handles CheckForm3.CheckClick
        RaiseEvent CheckClick3(indice)
    End Sub

    Private Sub CheckForm3_OKClick() Handles CheckForm3.OKClick
        RaiseEvent OkInput(3)
    End Sub

    Private Sub CheckForm4_CancelClick() Handles CheckForm4.CancelClick
        RaiseEvent CancelInput(4)
    End Sub

    Private Sub CheckForm4_CheckClick(ByRef indice As Short) Handles CheckForm4.CheckClick
        RaiseEvent CheckClick4(indice)
    End Sub

    Private Sub CheckForm4_OKClick() Handles CheckForm4.OKClick
        RaiseEvent OkInput(4)
    End Sub
    Public Sub InitProb(ByVal key As String)
        If Problems(key) Is Nothing Then
            Dim p As clsProblAbout = New clsProblAbout
            About = New clsAbout
            Problem = New clsProblem
            p.About = About
            p.Problem = Problem
            Problems.Add(key, p)
        End If
    End Sub
    Public Sub New(ByVal key As String)
        MyBase.New()
        Problems = New clsProblems
        Inizio = New RoutBase1.clsInizio
        InitProb(key)
        Inizio.Motore = Me
        gInizio = Inizio
        myAssembly = Me.GetType.Assembly
        rmHelpStrings = New _
           System.Resources.ResourceManager("RoutBase1.ProjectResources", myAssembly)
    End Sub
    Public Function Aree(ByRef Abile As Boolean) As Boolean
        Abilitato = Abile
        frmOpzioni.DefInstance.Motore = Me
        frmOpzioni.DefInstance.ShowDialog()
        Aree = frmOpzioni.DefInstance.EsitoPrintInizio
        frmOpzioni.DefInstance.Close()
    End Function
    Public Sub SetLavoriSciolti(Optional ByRef Mode As Short = 0)
        frmLavoriSciolti.DefInstance.Motore = Me
        If Mode = 1 Then frmLavoriSciolti.DefInstance.NonCambia = True
        frmLavoriSciolti.DefInstance.ShowDialog()
        Inizio.PrintInizio()
    End Sub
    Public Sub Testata(Optional ByVal Test As String = "    ", _
    Optional ByVal PrimaPagina As Boolean = False)
        Dim i As Integer
        Dim StriSt(8) As String
        Dim Firma As String = Inizio.Firma.Trim
        Problem.pag = CShort(Problem.pag + 1)
        Try
            Dim r As StreamReader = New StreamReader(Inizio.Archdir.Trim & "\RTF\ASME18.DAT")
            For i = 1 To 8
                StriSt(i) = r.ReadLine()
            Next
            r.Close()
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
            Exit Sub
        End Try
        Try
            With Problem.FileStream
                If Problem.pag > 1 And Not PrimaPagina Then .Write("\par \page ")
                Dim DAT As String = Format(Now, "Short Date")
                .WriteLine(StriSt(8))
                .WriteLine(Trigon.FormatS(StriSt(1), Test, Firma, DAT))
                .WriteLine(StriSt(2))
                .WriteLine(Trigon.FormatS(StriSt(5), About.ProgName, " " & About.ProgVers))
                .WriteLine(Trigon.FormatS(StriSt(7), About.ProgDesc))
                .WriteLine(StriSt(6))
            End With
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
            Exit Sub
        End Try
    End Sub
    Public Function PrepRapp(ByRef NomRapp As String, Optional ByVal Templ As String = "HEADER", Optional ByVal Tipo As String = "", _
    Optional ByVal Elemento As String = "", Optional ByVal lstRapp As ListView = Nothing, Optional ByVal livello As Short = 0, _
    Optional ByVal wordPanel As Lancio.Office.Word.WinForms.WordReportPanel = Nothing) As Boolean
        'Dim ifl As Short
        Dim Testo As String
        Dim Riga As String
        Dim Risp As MsgBoxResult
        PrepRapp = True
        Try
            If Not lstRapp Is Nothing Then
                Dim lst As ListViewItem
                lst = lstRapp.Items.Add(Tipo)
                lst.SubItems.Add(Elemento)
                System.Windows.Forms.Application.DoEvents()
                If livello >= 2 Then Exit Function
            End If
            With Problem
                If Not .FileStream Is Nothing Then
                    If Templ = "HEADER" Then Exit Function
                    Call Capitolo(Elemento)
                    Exit Function
                End If
                .pag = 0
                'If File.Exists(NomRapp) Then Kill(NomRapp)
                Do
                    Try
                        Risp = MsgBoxResult.OK
                        If Not wordPanel Is Nothing Then wordPanel.CloseDocument()
                        .FileStream = File.CreateText(NomRapp)
                    Catch e As Exception
                        Testo = "Accesso negato al file " & NomRapp & "." & vbCrLf
                        Testo = Testo & " Verificare se esso è in uso presso Winword" & vbCrLf
                        Testo = Testo & "(" & e.Message & ")"
                        Risp = MsgBox(Testo, CType(MsgBoxStyle.Exclamation + MsgBoxStyle.RetryCancel, MsgBoxStyle), "LancioNET - Servizi di base")    ' = MsgBoxResult.Retry Then
                    End Try
                Loop While Risp = MsgBoxResult.Retry
                If Risp = MsgBoxResult.Cancel Then Return False
                Dim r As StreamReader = New StreamReader(Inizio.Archdir.Trim & "\" & Templ & ".RTF")
                Do
                    Riga = r.ReadLine
                    If Riga Is Nothing Then Exit Do
                    If Riga.Length > 1 Then
                        If Not Riga.Substring(0, 2) = "??" Then
                            If Riga.IndexOf("company") > 0 Then
                                Riga = Trigon.FormatS(Riga, Inizio.Firma)
                            End If
                        End If
                    End If
                    .FileStream.WriteLine(Riga)
                Loop
                r.Close()
                If Not Templ = "HEADER" Then Call Capitolo(Elemento)
            End With
        Catch ex As Exception
            MsgBox(ex.Message + vbCrLf + ex.StackTrace)
        End Try
    End Function
    Private Sub Capitolo(ByRef Elemento As String)
        Problem.Printa("\pard\plain")
        If Problem.pag > 0 Then Problem.Printa("\par \page ")
        If Trigon Is Nothing Then Trigon = New clsTrigon
        Problem.Print("{\*\bkmkstart " & Trigon.TogliBlank(Elemento) & "}")
        Problem.Printa("{\listtext\pard\plain\s2 \b\i\f1\cgrid \hich\af1\dbch\af0\loch\f1 5.1\tab}")
        Problem.Print("\pard\plain \s2\fi-578\li1145\sb60\sa60\keepn\nowidctlpar\widctlpar")
        Problem.Printa("\jclisttab\tx576\ls10\ilvl1\outlinelevel1\adjustright \b\i\f1\lang1040\cgrid {" & Elemento)
        Problem.Printa("{\*\bkmkend " & Trigon.TogliBlank(Elemento) & "}\par }")
    End Sub
    Private Sub InputForm1_CancelClick() Handles InputForm1.CancelClick
        RaiseEvent CancelInput(1)
    End Sub
    Private Sub InputForm1_dAiuClick(ByRef indice As Short) Handles InputForm1.dAiuClick
        RaiseEvent dAiuClick(1, indice)
    End Sub
    Private Sub InputForm2_dAiuClick(ByRef indice As Short) Handles InputForm2.dAiuClick
        RaiseEvent dAiuClick(2, indice)
    End Sub
    Private Sub InputForm3_dAiuClick(ByRef indice As Short) Handles InputForm3.dAiuClick
        RaiseEvent dAiuClick(3, indice)
    End Sub
    Private Sub InputForm4_dAiuClick(ByRef indice As Short) Handles InputForm4.dAiuClick
        RaiseEvent dAiuClick(4, indice)
    End Sub
    Private Sub InputForm2_CancelClick() Handles InputForm2.CancelClick
        RaiseEvent CancelInput(2)
    End Sub
    Private Sub InputForm3_CancelClick() Handles InputForm3.CancelClick
        RaiseEvent CancelInput(3)
    End Sub
    Private Sub InputForm4_CancelClick() Handles InputForm4.CancelClick
        RaiseEvent CancelInput(4)
    End Sub
    Private Sub QualeForm1_CancelClick() Handles QualeForm1.CancelClick
        RaiseEvent CancelInput(1)
    End Sub
    Private Sub QualeForm1_OptClick(ByRef n As Short, ByRef indice As Short) Handles QualeForm1.OptClick
        RaiseEvent OptClick(n, indice)
    End Sub
    Private Sub QualeForm2_OptClick(ByRef n As Short, ByRef indice As Short) Handles QualeForm2.OptClick
        RaiseEvent OptClick(n, indice)
    End Sub
    Private Sub QualeForm3_OptClick(ByRef n As Short, ByRef indice As Short) Handles QualeForm3.OptClick
        RaiseEvent OptClick(n, indice)
    End Sub
    Private Sub QualeForm4_OptClick(ByRef n As Short, ByRef indice As Short) Handles QualeForm4.OptClick
        RaiseEvent OptClick(n, indice)
    End Sub
    Private Sub QualeForm2_CancelClick() Handles QualeForm2.CancelClick
        RaiseEvent CancelInput(2)
    End Sub
    Private Sub QualeForm3_CancelClick() Handles QualeForm3.CancelClick
        RaiseEvent CancelInput(3)
    End Sub
    Private Sub QualeForm4_CancelClick() Handles QualeForm4.CancelClick
        RaiseEvent CancelInput(4)
    End Sub
    Private Sub InputForm1_ComboClick(ByRef indice As Short) Handles InputForm1.ComboClick
        RaiseEvent ComboClick1(indice)
    End Sub
    Private Sub InputForm2_ComboClick(ByRef indice As Short) Handles InputForm2.ComboClick
        RaiseEvent ComboClick2(indice)
    End Sub
    Private Sub InputForm3_ComboClick(ByRef indice As Short) Handles InputForm3.ComboClick
        RaiseEvent ComboClick3(indice)
    End Sub
    Private Sub InputForm4_ComboClick(ByRef indice As Short) Handles InputForm4.ComboClick
        RaiseEvent ComboClick4(indice)
    End Sub
    Private Sub InputForm1_TestoCambia(ByRef indice As Short) Handles InputForm1.TestoCambia
        RaiseEvent TestoCambia1(indice)
    End Sub
    Private Sub InputForm2_TestoCambia(ByRef indice As Short) Handles InputForm2.TestoCambia
        RaiseEvent TestoCambia2(indice)
    End Sub
    Private Sub InputForm3_TestoCambia(ByRef indice As Short) Handles InputForm3.TestoCambia
        RaiseEvent TestoCambia3(indice)
    End Sub
    Private Sub InputForm4_TestoCambia(ByRef indice As Short) Handles InputForm4.TestoCambia
        RaiseEvent TestoCambia4(indice)
    End Sub
    Private Sub InputForm1_OKClick() Handles InputForm1.OKClick
        RaiseEvent OkInput(1)
    End Sub
    Private Sub InputForm2_OKClick() Handles InputForm2.OKClick
        RaiseEvent OkInput(2)
    End Sub
    Private Sub InputForm3_OKClick() Handles InputForm3.OKClick
        RaiseEvent OkInput(3)
    End Sub
    Private Sub InputForm4_OKClick() Handles InputForm4.OKClick
        RaiseEvent OkInput(4)
    End Sub
    Private Sub QualeForm1_OKClick() Handles QualeForm1.OKClick
        RaiseEvent OkInput(1)
    End Sub
    Private Sub QualeForm2_OKClick() Handles QualeForm2.OKClick
        RaiseEvent OkInput(2)
    End Sub
    Private Sub QualeForm3_OKClick() Handles QualeForm3.OKClick
        RaiseEvent OkInput(3)
    End Sub
    Private Sub QualeForm4_OKClick() Handles QualeForm4.OKClick
        RaiseEvent OkInput(4)
    End Sub
    Private Sub mioForm_Cambio(ByRef f As String) Handles mioForm.Cambio
        RaiseEvent Cambiofile(f)
        If f = "" Then Rifai()
    End Sub
    Private Sub mioForm_Lost(ByRef f As String) Handles mioForm.Lost
        RaiseEvent Cambiofile(f)
        If f = "" Then Rifai()
    End Sub
    Private Sub mioForm_NuovoLav(ByRef f As String) Handles mioForm.NuovoLav
        RaiseEvent NuovoLav(f)
    End Sub
    Private Sub mioForm_Rifiuto() Handles mioForm.Rifiuto
        RaiseEvent Rifiuto()
    End Sub
    Private Sub mioForm_SaveData(ByRef f As String) Handles mioForm.SaveData
        RaiseEvent SalvaData(f)
    End Sub
    Private Sub Rifai()
        mioForm.ScegliIlPrimo()
        mioForm.CambioFile()
    End Sub
    Public Function Mostra(ByVal a As Reflection.Assembly, Optional ByVal Mode As Short = 0) As Boolean
        'Mode 1 da HTRI 2 traccia 3 UPM
        Try
            Modo = Mode
            mioForm = New frmProblem
            mioForm.Motore = Me
            AssemblyOriginale = a
            Problem.OrdineFile = 0
            mioForm.ShowDialog()
            Mostra = mioForm.OK
            mioForm.Close()
            mioForm.Dispose()
            mioForm = Nothing
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Function
    Public Function Quale(ByRef Ninput As Short, ByRef Tit As String, ByRef Strin1() As String, ByRef Aiuto As String, _
    ByRef iQ As Short, Optional ByRef Testo As String = "", Optional ByVal Chiavi As Integer = 0, _
    Optional ByVal IDH As Integer = 0, Optional ByVal strIDH As String = "") As Short
        Dim i As Short
        With frmQuale.DefInstance
            If Testo = "" Then
                .Testo = ""
            Else
                If Chiavi = 1 Then
                    .Testo = Testo
                    .CarFissi = True
                Else
                    .Testo = Inizio.ConvertiCr(Testo)
                End If
            End If
            .IDH = IDH
            .strIDH = strIDH
            .Motore = Me
            .pNinput = Ninput
            .Tit = Tit
            .Aiuto = Inizio.ConvertiCr(Aiuto)
            .iQ = iQ
            For i = 1 To Ninput
                .pStrin(i) = Strin1(i)
            Next
            .Costruisci()
            If ProgrVisible Then
                .StartPosition = FormStartPosition.Manual
                .Top = Progresso.Top + Progresso.Height
                .Left = Progresso.Left
            End If
            .ShowDialog()
            Quale = .iQuale
        End With
        frmQuale.DefInstance.Dispose()
    End Function
    Public Function QualeM(ByRef Nfin1 As Short, ByRef Ninput As Short, ByRef Tit As String, ByRef Strin1() As String, _
    ByRef Aiuto As String, ByRef iQ As Short, Optional ByRef Testo As String = "") As Short
        Dim i, Nfin As Short
        Dim InputForm As frmQuale
        Dim vWidth, vTop, vLeft, vHeight As Single
        Nfin = System.Math.Abs(Nfin1)
        NonMostrare = Nfin1 < 0
        Select Case Nfin
            Case 1
                InputForms = New IFCollection
                QualeForm1 = New frmQuale
                InputForms.Add(QualeForm1)
                InputForm = QualeForm1
            Case 2
                QualeForm2 = New frmQuale
                InputForms.Add(QualeForm2)
                InputForm = QualeForm2
            Case 3
                QualeForm3 = New frmQuale
                InputForms.Add(QualeForm3)
                InputForm = QualeForm3
            Case 4
                QualeForm4 = New frmQuale
                InputForms.Add(QualeForm4)
                InputForm = QualeForm4
            Case Else
                Return 0
        End Select
        With InputForm
            If InputForms.Count() > 1 Then
                CType(InputForms.Item(InputForms.Count() - 1), frmQuale)._Command1_0.Visible = False
                CType(InputForms.Item(InputForms.Count() - 1), frmQuale)._Command1_1.Visible = False
            End If
            .Motore = Me
            If Testo = "" Then
                .Testo = ""
            Else
                .Testo = Inizio.ConvertiCr(Testo)
            End If
            .Nfin = Nfin
            .pNinput = Ninput
            .Tit = Tit
            .Aiuto = Inizio.ConvertiCr(Aiuto)
            .iQ = iQ
            For i = 1 To Ninput
                .pStrin(i) = Strin1(i)
            Next
            InputForm.NonMostrare = NonMostrare
            '      InputForm.Form_Activate
            InputForm.Costruisci()
            If Nfin > 1 Then
                vTop = CType(InputForms.Item(InputForms.Count() - 1), Form).Top
                vLeft = CType(InputForms.Item(InputForms.Count() - 1), Form).Left
                vHeight = CType(InputForms.Item(InputForms.Count() - 1), Form).Height
                vWidth = CType(InputForms.Item(InputForms.Count() - 1), Form).Width
                If .Height + vTop + vHeight < System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height Then
                    .Top = CInt(vTop + vHeight)
                    .Left = CInt(vLeft)
                Else
                    If Nfin = 2 Then
                        .Top = CInt(vTop)
                        .Left = CInt(vLeft + vWidth)
                    Else
                        If vTop > 600 Then
                            vTop = CType(InputForms.Item(InputForms.Count() - 2), Form).Top
                            vLeft = CType(InputForms.Item(InputForms.Count() - 2), Form).Left
                            vHeight = CType(InputForms.Item(InputForms.Count() - 2), Form).Height
                            vWidth = CType(InputForms.Item(InputForms.Count() - 2), Form).Width
                            .Top = CInt(vTop)
                            .Left = CInt(vLeft + vWidth)
                        Else
                            .Top = CInt(vTop)
                            .Left = CInt(vLeft + vWidth)
                        End If
                    End If
                End If
            End If
        End With
        If Not NonMostrare Then InputForm.Show()
        InputForm.Visible = Not NonMostrare
    End Function
    Public Function CheckQuale(ByRef Ninput As Short, ByRef Tit As String, ByRef Strin1() As String, _
                               ByRef Ris1() As Boolean, ByRef Aiuto As String, _
                               Optional ByRef X As Single = -1, Optional ByRef y As Single = -1, _
                               Optional ByRef IDH As Integer = 0, Optional ByVal strIDH As String = "") As Boolean
        Dim i As Short
        Dim mioForm As New frmCheck
        With mioForm
            .Motore = Me
            .pNinput = Ninput
            .Tit = Tit
            .Aiuto = Aiuto
            .IDH = IDH
            .strIDH = strIDH
            ReDim Strin(Ninput), Risult(Ninput)
            For i = 1 To Ninput
                .pStrin(i) = Strin1(i)
                .pRisult(i) = Ris1(i)
            Next
            .Aggiorna()
            .ShowDialog()
            If Not .chkCancel Then
                CheckQuale = True
                For i = 1 To Ninput
                    Ris1(i) = .pRisult(i)
                Next
            Else
                CheckQuale = False
            End If
            .Close()
            .Dispose()
        End With
    End Function
    Public Function CheckQualeM(ByRef Nfin As Short, ByRef Ninput As Short, ByRef Tit As String, ByRef Strin1() As String, ByRef Ris1() As Boolean, ByRef Aiuto As String) As Boolean
        Dim i As Short
        Dim InputForm As frmCheck
        Dim vWidth, vTop, vLeft, vHeight As Integer
        Select Case Nfin
            Case 1
                InputForms = New IFCollection
                CheckForm1 = New frmCheck
                InputForms.Add(CheckForm1)
                InputForm = CheckForm1
            Case 2
                CheckForm2 = New frmCheck
                InputForms.Add(CheckForm2)
                InputForm = CheckForm2
            Case 3
                CheckForm3 = New frmCheck
                InputForms.Add(CheckForm3)
                InputForm = CheckForm3
            Case 4
                CheckForm4 = New frmCheck
                InputForms.Add(CheckForm4)
                InputForm = CheckForm4
            Case Else
                Return False
        End Select
        With InputForm
            If InputForms.Count() > 1 Then
                CType(InputForms.Item(InputForms.Count() - 1), frmCheck).Command1(0).Visible = False
                CType(InputForms.Item(InputForms.Count() - 1), frmCheck).Command1(1).Visible = False
            End If
            .Motore = Me
            .pNinput = Ninput
            .Nfin = Nfin
            .Tit = Tit
            .Aiuto = Inizio.ConvertiCr(Aiuto)
            ReDim Strin(Ninput), Risult(Ninput)
            For i = 1 To Ninput
                .pStrin(i) = Strin1(i)
                .pRisult(i) = Ris1(i)
            Next
            InputForm.Activate()
            If Nfin > 1 Then
                With CType(InputForms.Item(InputForms.Count() - 1), Form)
                    vTop = .Top
                    vLeft = .Left
                    vHeight = .Height
                    vWidth = .Width
                    If .Height + vTop + vHeight < System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height Then
                        .Top = vTop + vHeight
                        .Left = vLeft
                    Else
                        If Nfin = 2 Then
                            .Top = vTop
                            .Left = vLeft + vWidth
                        Else
                            If vTop > 600 Then
                                With CType(InputForms.Item(InputForms.Count() - 2), Form)
                                    vTop = .Top
                                    vLeft = .Left
                                    vHeight = .Height
                                    vWidth = .Width
                                End With
                                .Top = vTop
                                .Left = vLeft + vWidth
                            Else
                                .Top = vTop
                                .Left = vLeft + vWidth
                            End If
                        End If
                    End If
                End With
            End If
        End With
        InputForm.Show()
    End Function
    Public Function InputDati(ByRef Ninput As Short, ByRef Tit As String, ByRef Strin1() As String, ByRef Ris1() As String, _
    ByRef Aiuto As String, ByRef Archiv() As Short, ByRef dAiuto() As String, Optional ByRef UltAiuloc As String = "", _
    Optional ByRef X As Single = -1, Optional ByRef y As Single = -1, _
    Optional ByVal IDH As Integer = 0, Optional ByVal strIDH As String = "", _
    Optional ByVal CarFissi As Boolean = False) As Boolean
        Dim i As Short
        With frmInput.DefInstance
            .CarFissi = CarFissi
            .Motore = Me
            .Ncol = 1
            .FinX = X
            .FinY = y
            .pNinput = Ninput
            .Tit = Tit
            .Aiuto = Inizio.ConvertiCr(Aiuto)
            .IDH = IDH
            .strIDH = strIDH
            For i = 1 To Ninput
                .pStrin(i) = Strin1(i)
                .pRisposte(i) = Ris1(i)
                .pArchivio(i) = Archiv(i)
                .pHelp(i) = dAiuto(i)
            Next
            UltAiu = UltAiuloc
            frmInput.DefInstance.ShowDialog()
            If Not frmInput.DefInstance.chkCancel Then
                For i = 1 To Ninput
                    Ris1(i) = .pRisposte(i)
                Next
                InputDati = True
            Else
                InputDati = False
            End If
            frmInput.DefInstance.Dispose()
        End With
    End Function
    Public Function InputDatiM(ByRef Nfin1 As Short, ByRef Ninput As Short, ByRef Tit As String, ByRef Strin1() As String, _
    ByRef Ris1() As String, ByRef Aiuto As String, ByRef Archiv() As Short, ByRef dAiuto() As String, _
    Optional ByRef UltAiuloc As String = "", Optional ByRef Ncol As Short = 1) As Boolean
        Dim i As Short
        Dim InputForm As frmInput
        Dim Nfin, k As Short
        Dim vWidth, vTop, vLeft, vHeight As Single
        Nfin = System.Math.Abs(Nfin1)
        NonMostrare = Nfin1 < 0
        Select Case Nfin
            Case 1
                InputForms = New IFCollection
                InputForm1 = New frmInput
                InputForms.Add(InputForm1)
                InputForm = InputForm1
            Case 2
                InputForm2 = New frmInput
                InputForms.Add(InputForm2)
                InputForm = InputForm2
            Case 3
                InputForm3 = New frmInput
                InputForms.Add(InputForm3)
                InputForm = InputForm3
            Case 4
                InputForm4 = New frmInput
                InputForms.Add(InputForm4)
                InputForm = InputForm4
            Case Else
                Return False
        End Select
        With InputForm
            ' .Visible = Not NonMostrare
            If InputForms.Count() > 1 Then
                CType(InputForms.Item(InputForms.Count() - 1), frmInput).Command1(0).Visible = False
                CType(InputForms.Item(InputForms.Count() - 1), frmInput).Command1(1).Visible = False
            End If
            .Motore = Me
            .Nfin = Nfin
            .Ncol = Ncol
            .pNinput = Ninput
            .Tit = Tit
            .Aiuto = Inizio.ConvertiCr(Aiuto)
            For i = 1 To Ninput
                .pStrin(i) = Strin1(i)
                For k = 1 To Ncol
                    .pRisposte(CShort((k - 1) * Ninput + i)) = Ris1((k - 1) * Ninput + i)
                Next
                .pArchivio(i) = Archiv(i)
                .pHelp(i) = dAiuto(i)
            Next
            If Not UltAiuloc = "" Then
                UltAiu = UltAiuloc
            Else
                UltAiu = ""
            End If
            InputForm.NonMostrare = NonMostrare
            InputForm.Activate()
            If Nfin > 1 Then
                With CType(InputForms.Item(InputForms.Count() - 1), Form)
                    vTop = .Top
                    vLeft = .Left
                    vHeight = .Height
                    vWidth = .Width
                End With
                If .Height + vTop + vHeight < Screen.PrimaryScreen.Bounds.Height Then
                    .Top = CInt(vTop + vHeight)
                    .Left = CInt(vLeft)
                Else
                    If Nfin = 2 Then
                        .Top = CInt(vTop)
                        .Left = CInt(vLeft + vWidth)
                    Else
                        If vTop > 600 Then
                            With CType(InputForms.Item(InputForms.Count() - 2), Form)
                                vTop = .Top
                                vLeft = .Left
                                vHeight = .Height
                                vWidth = .Width
                            End With
                            .Top = CInt(vTop)
                            .Left = CInt(vLeft + vWidth)
                        Else
                            .Top = CInt(vTop)
                            .Left = CInt(vLeft + vWidth)
                        End If
                    End If
                End If
            End If
        End With
        If Not NonMostrare Then InputForm.Show()
        InputForm.Visible = Not NonMostrare
    End Function
    Public Property ProgrVisible() As Boolean
        Get
            If Not Progresso Is Nothing Then
                Return Progresso.Visible
            Else
                Return False
            End If
        End Get
        Set(ByVal Value As Boolean)
            If Not Progresso Is Nothing Then
                Progresso.Visible = Value
                If Value Then Progresso.Refresh()
            End If
        End Set
    End Property
    Public Sub ProgrInizio(ByRef Text As String, Optional ByRef Titolo As String = "", Optional ByRef O As System.Windows.forms.Form = Nothing)
        Progresso = frmProgress.DefInstance
        Trigon.CenterForm(CType(Progresso, Form))
        If O Is Nothing Then
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.AppStarting
            Ogg = Nothing
        Else
            O.Cursor = System.Windows.Forms.Cursors.AppStarting
            Ogg = O
        End If
        With Progresso
            If Not Titolo = "" Then
                .Text = Titolo
            End If
            Dim g As Graphics = .Label1.CreateGraphics
            Dim Testo As String = Inizio.ConvertiCr(Text)
            Dim layout As SizeF = g.MeasureString(Testo, .Label1.Font, .Label1.Width)
            .Label1.Text = Testo
            If layout.Height > .Label1.Height Then .Label1.Height = CInt(layout.Height)
            .Frame1.Height = .Label1.Height + 25
            .Label1.Top = CInt((.Frame1.Height - .Label1.Height) / 2)
            .Label1.Left = CInt((.Frame1.Width - .Label1.Width) / 2)
            .Command1.Top = .Frame1.Top + .Frame1.Height + 8
            .ProgressBar1.Top = .Command1.Top
            .Height = .Command1.Top + .Command1.Height + SystemInformation.CaptionHeight + 6 * SystemInformation.Border3DSize.Height
            g.Dispose()
            Try
                .Show()
                .Refresh()
            Catch e As Exception
                MsgBox(e.Message + vbCrLf + e.StackTrace)
            End Try
        End With
        System.Windows.Forms.Application.DoEvents()
    End Sub
    Public Property Avanzamento() As Single
        Get
            Avanzamento = Progresso.ProgressBar1.Value
        End Get
        Set(ByVal Value As Single)
            If Progresso Is Nothing Then Exit Property
            With Progresso
                If Value > .ProgressBar1.Maximum Then Value = .ProgressBar1.Maximum
                .ProgressBar1.Value = CInt(Value)
                If Value > .ProgressBar1.Maximum Then
                    .Command1.Text = "OK"
                    .Finito = True
                End If
            End With
        End Set
    End Property
    Public WriteOnly Property AvanzTesto() As String
        Set(ByVal Value As String)
            With Progresso
                If Len(Value) > 0 Then
                    .Label1.Text = Inizio.ConvertiCr(Value)
                    .Label1.Top = CInt((.Frame1.Height - .Label1.Height) / 2)
                    .Label1.Left = CInt((.Frame1.Width - .Label1.Width) / 2)
                End If
            End With
        End Set
    End Property
    Public Sub Ammazza(ByRef Progr As String)
        Problems.Remove(Progr)
        Problem = Nothing
        About = Nothing
        RaiseEvent Finito(Progr)
    End Sub
    Public Function ScegliFile(ByRef Tit As String, ByRef Base As String, ByRef Ext As String, ByRef Aiuto As String, ByRef Logic As Boolean) As String
        Dim File As String
        Dim i, n As Integer
        ReDim Strin(50)
        Dim di As New DirectoryInfo(Base)
        Dim fi() As FileInfo = di.GetFiles("*." & Ext)
        n = UBound(fi)
        If fi(0) Is Nothing Then
            ScegliFile = "" : Exit Function
        End If
        For i = 0 To n
            Strin(i + 1) = fi(i).Name
            If i > UBound(Strin) Then ReDim Preserve Strin(2 * UBound(Strin))
        Next
        File = Base & "\*." & Ext
        With frmQuale.DefInstance
            .pNinput = CShort(i)
            .Tit = Tit
            .Aiuto = Inizio.ConvertiCr(Aiuto)
            .iQ = 0
            For i = 1 To .pNinput
                .pStrin(CShort(i)) = Strin(i)
            Next
            frmQuale.DefInstance.ShowDialog()
            ScegliFile = Strin(frmQuale.DefInstance.iQuale)
            frmQuale.DefInstance.Close()
        End With
    End Function
    Public Sub ProgrAmmazza()
        On Error Resume Next
        Progresso.Hide()
        Progresso.Close()
        If Ogg Is Nothing Then
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        Else
            Ogg.Cursor = System.Windows.Forms.Cursors.Default
        End If
        On Error GoTo 0
    End Sub
    Public Overloads Sub RetrHelp(ByRef Aiuto As String, ByVal hwnd As Control, _
                                  ByVal Origine As String, ByVal IDH As String)
        If Not IDH Is Nothing Then
            If IDH.Trim.Length > 0 Then
                Help.ShowHelp(hwnd, Aiuto, HelpNavigator.Topic, IDH)
                Exit Sub
            End If
        End If
        If Not Aiuto Is Nothing Then
            If Aiuto.IndexOf("\") > -1 Then
                Help.ShowHelp(hwnd, Aiuto, HelpNavigator.TableOfContents)
            Else
                Help.ShowPopup(hwnd, Inizio.ConvertiCr(Aiuto), New Point(12, 12))
            End If
        End If
    End Sub
    Public Overloads Sub RetrHelp(ByRef Aiuto As String, ByVal hwnd As Control, _
                                  ByVal Origine As String, ByVal IDH As Integer)
        If IDH > 0 Then
            Help.ShowHelp(hwnd, Aiuto, HelpNavigator.Topic, HelptopicG(IDH))
        ElseIf Aiuto.IndexOf("\") > -1 Then
            Help.ShowHelp(hwnd, Aiuto, HelpNavigator.TableOfContents)
        Else
            Help.ShowPopup(hwnd, Inizio.ConvertiCr(Aiuto), New Point(12, 12))
        End If
    End Sub
    Public Function Autorizzazione(ByRef Oper As String, ByRef Sigla As String) As Boolean
        Dim i, j As Short
        Dim Testo As String
        Dim Autorizz As Boolean
        'Dim cString As String = "Jet OLEDB:Global Partial Bulk Ops=2;" & _
        '"Jet OLEDB:Database Password=4647;Data Source=" & Inizio.Archdir & _
        '"\Commesse.mdb;Provider=Microsoft.Jet.OLEDB.4.0;"
        Dim cString As String = Conn & Inizio.Archdir & "\Gestione\Commesse.mdb" & ConnFine
        Dim cnConn As OleDbConnection = New OleDbConnection(cString)
        Autorizzazione = True
        If Not Inizio.InRete Then
            Sigla = Environment.MachineName.Substring(0, 3)
            Exit Function
        End If
        Dim cmd As OleDbDataAdapter = New OleDbDataAdapter("SELECT * from Autorizz WHERE Operazione = '" & Oper & "'", cnConn)
        Dim MyTable1 As DataTable = New DataTable("Autorizz")
        cmd.Fill(MyTable1)
        If MyTable1.Rows.Count = 0 Then
            MyTable1.Dispose()
            cmd.Dispose()
            Exit Function
        End If
        Dim cmd1 As OleDbDataAdapter = New OleDbDataAdapter("SELECT * from Utenti WHERE Utente = '" & Inizio.Utente & "'", cnConn)
        Dim MyTable2 As DataTable = New DataTable("Utenti")
        cmd1.Fill(MyTable2)
        If MyTable2.Rows.Count = 0 Then
            MyTable1.Dispose()
            MyTable2.Dispose()
            cmd.Dispose()
            cmd1.Dispose()
            Autorizz = False
            If Inizio.Utente.Length = 0 Then Inizio.Utente = "Utente sconosciuto"
            GoTo ju
        End If
        Autorizz = False
        Sigla = CStr(MyTable2.Rows(0)("Sigla"))
        For i = 3 To 5
            For j = 2 To 10
                If CStr(MyTable1.Rows(0)(j)) = CStr(MyTable2.Rows(0)(i)) Then Autorizz = True : Exit For
            Next j
        Next i
        MyTable1.Dispose()
        MyTable2.Dispose()
        cmd.Dispose()
        cmd1.Dispose()
ju:     If Not Autorizz Then
            Testo = "Sig. " & Trim(Inizio.Utente) & ",| Lei non ha le autorizzazioni"
            Testo = Testo & "|per questa operazione."
            MsgBox(Inizio.ConvertiCr(Testo), MsgBoxStyle.Critical)
        End If
        Autorizzazione = Autorizz
    End Function

    Private Sub Progresso_Cancella() Handles Progresso.Cancella
        RaiseEvent ProgrCancella()
    End Sub
    Public Function Creajob() As RoutBase1.clsjob
        Dim job As RoutBase1.clsjob
        job = New clsjob(Me)
        Creajob = job
    End Function
    Public Function MisuraStringa(ByVal t As String, ByVal g As Graphics, ByVal f As Font) As SizeF
        Dim characterRanges As CharacterRange() = _
        {New CharacterRange(0, t.Length)}
        Dim layoutRect As RectangleF = New RectangleF(0, 0, 5000, 200)
        Dim stringFormat As New StringFormat
        'stringFormat.FormatFlags = StringFormatFlags.DirectionVertical
        stringFormat.SetMeasurableCharacterRanges(characterRanges)
        Dim stringRegions(0) As [Region]
        stringRegions = g.MeasureCharacterRanges(t, _
        f, layoutRect, stringFormat)
        Dim Rect As RectangleF = stringRegions(0).GetBounds(g)
        Dim s As New SizeF(Rect.Width + 16, Rect.Height)
        Return s
    End Function
    Public Function Messaggio(ByVal Testo As String, Optional ByVal Chiavi As ChiaviMess = ChiaviMess.MessInformation Or ChiaviMess.MessOkOnly, _
                              Optional ByVal Tit As String = "", _
                              Optional ByVal chm As String = "", Optional ByVal id As String = "", _
                              Optional ByVal Proportional As Boolean = False) As ChiaviMess
        Dim MWidth, MHeight As Single
        Dim cmd(3) As Boolean
        Dim Figura As Short
        Dim M As Single
        Dim Cursore As System.Windows.Forms.Cursor
        Dim DefButton As Short
        Cursore = System.Windows.Forms.Cursor.Current
        If chm.Length = 0 Then chm = "Lancio.chm"
        If Tit.Length = 0 Then Tit = System.Reflection.Assembly.GetExecutingAssembly.GetName.Name
        cmd(0) = True
        If (Chiavi And ChiaviMess.messDef1) > 0 Then DefButton = 0
        If (Chiavi And ChiaviMess.MessDef2) > 0 Then DefButton = 1
        If (Chiavi And ChiaviMess.messDef3) > 0 Then DefButton = 2
        formMess = New frmMessaggio
        With formMess
            If CBool(Chiavi And ChiaviMess.MessYesNo) Then
                ._Command1_0.Text = "Si"
                ._Command1_1.Text = "No"
                cmd(1) = True
                ._Command1_1.Visible = True
            ElseIf CBool(Chiavi And ChiaviMess.MessIgnoraAnnulla) Then
                ._Command1_0.Text = "Ignora"
                ._Command1_1.Text = "Annulla"
                cmd(1) = True
                ._Command1_1.Visible = True
            ElseIf CBool(Chiavi And ChiaviMess.MessOKCancel) Then
                ._Command1_0.Text = "OK"
                ._Command1_1.Text = "Annulla"
                cmd(1) = True
                ._Command1_1.Visible = True
            ElseIf CBool(Chiavi And ChiaviMess.MessYesNoCancel) Then
                ._Command1_0.Text = "Si"
                ._Command1_1.Text = "No"
                cmd(1) = True
                ._Command1_1.Visible = True
                ._Command1_2.Text = "Annulla"
                cmd(2) = True
                ._Command1_2.Visible = True
            Else
            End If
            If CBool(Chiavi And ChiaviMess.MessHelpButton) Then
                cmd(3) = True
                ._Command1_3.Text = "Help"
                ._Command1_3.Visible = True
                .chm = chm
                .id = id
            End If
            Select Case DefButton
                Case 0
                    ._Command1_0.NotifyDefault(True)
                    .AcceptButton = ._Command1_0
                Case 1
                    ._Command1_1.NotifyDefault(True)
                    .AcceptButton = ._Command1_1
                Case 2
                    ._Command1_2.NotifyDefault(True)
                    .AcceptButton = ._Command1_2
                Case 3
                    ._Command1_3.NotifyDefault(True)
                    .AcceptButton = ._Command1_3
            End Select
            Figura = 1
            If CBool(Chiavi And ChiaviMess.MessCritical) Then
                Figura = 3
            ElseIf CBool(Chiavi And ChiaviMess.MessExclamation) Then
                Figura = 2
            ElseIf CBool(Chiavi And ChiaviMess.MessInformation) Then
                Figura = 1
            ElseIf CBool(Chiavi And ChiaviMess.MessQuestion) Then
                Figura = 4
            End If
            If Proportional Then
                .Label1.Font = New Font("Courier New", 10)
            End If
            Dim b As Bitmap = New Bitmap(1, 1, Imaging.PixelFormat.Format24bppRgb)
            Dim g As Graphics = Graphics.FromImage(b)
            .Text = Tit
            MWidth = CSng(g.MeasureString(Tit, .Font).Width + Trigon.TwipsToPixelsX(50))
            Dim MinWidth As Integer = CInt(g.MeasureString(Tit, .Font).Width + 2 * SystemInformation.CaptionButtonSize.Width + 4 * SystemInformation.BorderSize.Width)
            If MinWidth < 200 Then MinWidth = 200
            Dim quadro As SizeF = MisuraStringa(Testo, g, .Label1.Font)
            Dim txtWidth As Integer = CInt(quadro.Width)
            Dim txtHeight As Integer = CInt(quadro.Height)
            .Label1.Height = txtHeight
            .Label1.Width = txtWidth
            .Label1.Text = Testo
            .Label1.Top = CInt(Trigon.TwipsToPixelsY(20))
            M = .Label1.Left + .Label1.Width
            If MWidth < M Then MWidth = M
            Select Case Figura
                Case 1
                    ._Picture1_0.Top = CInt((.Label1.Top + .Label1.Height - ._Picture1_0.Height) / 2)
                    ._Picture1_0.Visible = True
                    If ._Picture1_0.Top < 0 Then ._Picture1_0.Top = 0
                Case 2
                    ._Picture1_1.Top = CInt((.Label1.Top + .Label1.Height - ._Picture1_1.Height) / 2)
                    ._Picture1_1.Visible = True
                    If ._Picture1_1.Top < 0 Then ._Picture1_1.Top = 0
                Case 3
                    ._Picture1_2.Top = CInt((.Label1.Top + .Label1.Height - ._Picture1_2.Height) / 2)
                    ._Picture1_2.Visible = True
                    If ._Picture1_2.Top < 0 Then ._Picture1_2.Top = 0
                Case 4
                    ._Picture1_3.Top = CInt((.Label1.Top + .Label1.Height - ._Picture1_3.Height) / 2)
                    ._Picture1_3.Visible = True
                    If ._Picture1_3.Top < 0 Then ._Picture1_3.Top = 0
            End Select
            If cmd(0) Then ._Command1_0.Top = .Label1.Top + .Label1.Height + CInt(Trigon.TwipsToPixelsY(100))
            If cmd(1) Then ._Command1_1.Top = .Label1.Top + .Label1.Height + CInt(Trigon.TwipsToPixelsY(100))
            If cmd(2) Then ._Command1_2.Top = .Label1.Top + .Label1.Height + CInt(Trigon.TwipsToPixelsY(100))
            If cmd(3) Then ._Command1_3.Top = .Label1.Top + .Label1.Height + CInt(Trigon.TwipsToPixelsY(100))
            If Trigon Is Nothing Then Trigon = New clsTrigon
            MHeight = ._Command1_0.Top + ._Command1_0.Height + SystemInformation.CaptionHeight + 6 * SystemInformation.Border3DSize.Height
            MWidth = .Label1.Left + .Label1.Width + 4 * SystemInformation.Border3DSize.Width
            M = CInt(Trigon.TwipsToPixelsX(200))
            If cmd(0) Then M = M + ._Command1_0.Width
            If cmd(1) Then M = M + ._Command1_1.Width
            If cmd(2) Then M = M + ._Command1_2.Width
            If cmd(3) Then M = M + ._Command1_3.Width
            If MWidth < M Then MWidth = M
            .Width = CInt(MWidth)
            .Height = CInt(MHeight)
            M = .ClientRectangle.Width - 5
            If cmd(3) Then
                M = M - ._Command1_3.Width
                ._Command1_3.Left = CInt(M)
            End If
            If cmd(2) Then
                M = M - ._Command1_2.Width
                ._Command1_2.Left = CInt(M)
            End If
            If cmd(1) Then
                M = M - ._Command1_1.Width
                ._Command1_1.Left = CInt(M)
            End If
            If cmd(0) Then
                M = M - ._Command1_0.Width
                ._Command1_0.Left = CInt(M)
            End If
            .Motore = Me
            Cursor.Current = Cursors.Default
            If ProgrVisible Then
                .StartPosition = FormStartPosition.Manual
                .Top = Progresso.Top + Progresso.Height
                .Left = Progresso.Left
            End If
            .ShowDialog()
            System.Windows.Forms.Cursor.Current = Cursore
            Messaggio = RispostaMessaggio
        End With
        formMess.Close()
    End Function
    Public Function MostraAiuto(ByRef id As Integer, Optional ByRef Informa As ChiaviMess = ChiaviMess.MessCritical Or ChiaviMess.MessOkOnly, Optional ByRef mioTesto As String = "", Optional ByRef mioTitolo As String = "") As ChiaviMess
        Dim Testo, Tit As String, Formato As String
        Dim Codici As ChiaviMess
        If Len(mioTitolo) = 0 Then
            Tit = "Lancio - Messaggi di errore"
            If Not CBool(Informa And ChiaviMess.MessCritical) Then Tit = "LancioNET"
        Else
            Tit = mioTitolo
        End If
        If id > 0 Then
            If Len(mioTesto) = 0 Then
                Testo = Inizio.ConvertiCr(HelpStringa(id)) ' "Il gruppo di items da montare su ventilatore a comune non è stato definito correttamente"
            Else
                Testo = Inizio.ConvertiCr(mioTesto)
            End If
            Codici = Informa
            If (Codici And ChiaviMess.MessHelpButton) = 0 Then Codici = Codici Or ChiaviMess.MessHelpButton
            MostraAiuto = Messaggio(Testo, Codici, Tit, RadiceHelp, Helptopic(id))
        ElseIf id < 0 Then
            Formato = Inizio.ConvertiCr(HelpStringa(-id))
            Trigon.FormatS("non|")
            Testo = Trigon.FormatS(Formato, mioTesto)
            Codici = Informa
            If (Codici And ChiaviMess.MessHelpButton) = 0 Then Codici = Codici Or ChiaviMess.MessHelpButton
            MostraAiuto = Messaggio(Testo, Codici, Tit, RadiceHelp, Helptopic(-id))
        Else
            MsgBox("Errore sconosciuto", MsgBoxStyle.Information, "Lancio")
        End If
    End Function
    Public Function MostraAiuto2(ByRef id As Integer, ByRef Informa As ChiaviMess, ByRef mioTitolo As String, ByVal ParamArray mioTesto() As String) As ChiaviMess
        Dim Testo, Tit As String, Formato As String
        Dim Codici As ChiaviMess
        If Len(mioTitolo) = 0 Then
            Tit = "Lancio - Messaggi di errore"
            If Not CBool(Informa And ChiaviMess.MessCritical) Then Tit = "Lancio"
        Else
            Tit = mioTitolo
        End If
        If id > 0 Then
            Formato = Inizio.ConvertiCr(HelpStringa(id))
            Trigon.FormatS("non|")
            Testo = Trigon.FormatS(Formato, mioTesto)
            MostraAiuto2 = Messaggio(Testo, Codici, Tit, RadiceHelp, Helptopic(id))
        Else
            MsgBox("Errore sconosciuto", MsgBoxStyle.Information, "Lancio")
        End If
    End Function
    Public Sub Informazioni(ByRef s As Form, ByRef a As Reflection.Assembly)
        Dim aTitleAttr As AssemblyTitleAttribute() = CType(AssemblyTitleAttribute.GetCustomAttributes _
                            (a, GetType(AssemblyTitleAttribute)), AssemblyTitleAttribute())
        Dim aDescrAttr As AssemblyDescriptionAttribute() = CType(AssemblyDescriptionAttribute.GetCustomAttributes _
                            (a, GetType(AssemblyDescriptionAttribute)), AssemblyDescriptionAttribute())
        Dim Vers As String = a.GetName.Version.Major.ToString & "." & a.GetName.Version.Minor.ToString
        With frmAbout.DefInstance
            .Motore = Me
            .picIcon.Image = s.Icon.ToBitmap
            .Titolo = aTitleAttr(0).Title
            .Versione = Vers
            .Desc = aDescrAttr(0).Description
            .Disc = "Copyright SSAP, Presciuttini" & vbCrLf & "No warranty of any kind"
            .ShowDialog()
            .Close()
            .Dispose()
        End With
    End Sub
    Public Function CheckQualeF(ByRef Ninput As Integer, ByRef FirstStr As StringheF, ByRef Tit As String, ByRef Aiuto As String) As Boolean
        Dim i As Short
        Dim SF As StringheF
        Dim Strin1(Ninput) As String
        Dim Ris1(Ninput) As Boolean
        SF = FirstStr
        For i = 1 To CShort(Ninput)
            Strin1(i) = SF.Strin1
            Ris1(i) = SF.Ris1
            SF = SF.nextS
        Next
        CheckQualeF = CheckQuale(CShort(Ninput), Tit, Strin1, Ris1, Aiuto)
        SF = FirstStr
        For i = 1 To CShort(Ninput)
            SF.Ris1 = Ris1(i)
            SF = SF.nextS
        Next
    End Function
    Public Function QualeF(ByRef Ninput As Integer, ByRef FirstStr As StringheF, ByRef Tit As String, ByRef Aiuto As String, ByRef iQ As Integer, Optional ByRef Testo As String = "", Optional ByRef Chiavi As Integer = 0, Optional ByRef IDH As Integer = 0) As Short
        Dim i As Short
        Dim SF As StringheF
        Dim Strin1(Ninput) As String
        SF = FirstStr
        For i = 1 To CShort(Ninput)
            Strin1(i) = SF.Strin1
            SF = SF.nextS
        Next
        QualeF = Quale(CShort(Ninput), Tit, Strin1, Aiuto, CShort(iQ), Testo, Chiavi, IDH)
    End Function
    Public Function MatFile() As String
        Dim strKey As String
        Dim n As Short
        Dim UltimoAggiornamento As Short
        Dim MyFile As String
        If UltimoAggiornamento = 0 Then
            UltimoAggiornamento = CShort(Val(Inizio.ReadIniFile("", "Parametri", "UltimoAggiornamento")))
            If UltimoAggiornamento = 0 Then UltimoAggiornamento = 1
        End If
        strKey = "Agg" & Trim(Str(UltimoAggiornamento))
        MyFile = Inizio.ReadIniFile("", "Aggiornamenti", strKey)
        n = CShort(InStr(MyFile, "|"))
        If Len(MyFile) = 0 Or n = 0 Then
No:         MyFile = Trim(Inizio.Archdir) & "\Mat200400.MDB"
        Else
            MyFile = Trim(Inizio.Archdir) & "\" & Right(MyFile, Len(MyFile) - n)
        End If
        If Not System.IO.File.Exists(MyFile) And InStr(MyFile, "Mat200400.MDB") = 0 Then
            GoTo No
        ElseIf Not System.IO.File.Exists(MyFile) Then
            MyFile = ""
        End If
        MatFile = MyFile
    End Function
    Public Function Sceglijob(Optional ByRef ContrNome As String = "", Optional ByRef ContrFile As String = "") As clsjob
        Dim job As clsjob = New clsjob(Me)
        mioForm = New frmProblem
        With mioForm.OpenFileDialog1
            mioForm.Motore = Me
            .Filter = "Contratti (*.JOB)|*.JOB"
            .InitialDirectory = Inizio.Workdir
            .DefaultExt = ".JOB"
            If ContrNome = "" Then ContrNome = "*"
            .FileName = Inizio.Workdir & "\" & ContrNome & ".JOB"
            .CheckFileExists = False
            .AddExtension = True
            If .ShowDialog() = System.Windows.Forms.DialogResult.Cancel Then
                ContrNome = ""
                ContrFile = ""
                Return job
            End If
            ContrFile = .FileName
        End With
        If Len(ContrFile) > 0 Then
            If System.IO.File.Exists(ContrFile) Then
                job = Retrievejob(ContrNome, ContrFile)
            Else
                job.Contratto = Inizio.CommPulita(ContrFile)
            End If
        End If
        Return job
    End Function
    Public Function Retrievejob(ByVal ContrNome As String, ByVal ContrFile As String) As clsjob
        Dim myFileStream As Stream
        Dim job As clsjob = New clsjob(Me)
        Try
            myFileStream = File.OpenRead(ContrFile)
        Catch e As Exception
            MsgBox("Failed to open file " & ContrFile & vbCrLf & "Reason:" & e.Message & vbCrLf & e.StackTrace)
            Exit Function
        End Try
        Try
            Dim deserializer As New BinaryFormatter
            job = CType(deserializer.Deserialize(myFileStream), clsjob)
            job.Coll.BaseZero = 1
            job.Motore = Me
        Catch e As Exception
            MsgBox("Failed to deserialize " & ContrNome & vbCrLf & "Reason:" & e.Message & vbCrLf & e.StackTrace)
        Finally
            myFileStream.Close()
        End Try
        Return job
    End Function
    Public Function RetrieveComS(ByRef Nome As String) As clsComm
        Dim FileTem As String
        Dim Comm As New clsComm
        FileTem = Inizio.Workdir & "\" + Nome + ".TEM"
        If File.Exists(FileTem) Then
            Dim myFileStream As Stream = File.OpenRead(FileTem)
            Dim deserializer As New BinaryFormatter
            Try
                Comm = CType(deserializer.Deserialize(myFileStream), clsComm)
                With Comm
                    If .NumeroLati = 0 Then .NumeroLati = 2
                    If .NumAs = 0 Then .NumAs = 1
                End With
                Return Comm
            Catch e As SerializationException
                MsgBox("Failed to deserialize" & Nome & ControlChars.CrLf & "Reason:" & e.Message)
            Finally
                myFileStream.Close()
            End Try
        Else
            MsgBox("Il file " + FileTem + "non esiste")
        End If
        Return Comm
    End Function
    Public Overloads Function HelpStringaG(ByVal id As Integer) As String
        HelpStringaG = HelpStringa(id)
    End Function
    Public Overloads Function HelpStringaG(ByVal id As String) As String
        HelpStringaG = rmHelpStrings.GetString(id).Replace("|", vbCrLf)
    End Function
    Public Function HelptopicG(ByVal id As Integer) As String
        HelptopicG = Helptopic(id)
    End Function
    Private Sub mioForm_Uccidi(ByRef f As String) Handles mioForm.Uccidi
        RaiseEvent Uccidi(f)
    End Sub

    Private Sub mioForm_Sonda(ByRef f As String) Handles mioForm.Sonda
        RaiseEvent SondaFile(f)
    End Sub
End Class
