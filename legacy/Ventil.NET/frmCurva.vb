Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class frmCurva
	Inherits System.Windows.Forms.Form
    Private miaBitMap As Bitmap
    Private Inizializzando As Boolean
    Public glocPic As System.Drawing.Graphics
    Public locPen As Pen
    Private Sub cmdDWG_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdDWG.Click
        Dim FileDWG As String
        Dim InsertPoint(2) As Double
        Dim scalefactor, rotationAngle As Double
        Dim rasterObj As Autodesk.AutoCAD.Interop.Common.AcadRasterImage
        Dim imageName As String
        Dim Lung As Single
        Dim minext, maxext As Object
        Dim Testo As String
        Modulo()
        If GeneraPRI() Then makepri(True)
        On Error GoTo ErrH
10:     InsertPoint(0) = 0.0# : InsertPoint(1) = 0.0# : InsertPoint(2) = 0.0#
        scalefactor = 1.0#
        FileDWG = VB.Left(FilePRI, Len(FilePRI) - 4) & ".DWG"
        Disegno = AcadApp
        If Disegno Is Nothing Then Exit Sub
20:     AcadApp = Disegno.Application
        imageName = Monitor.Motore.Inizio.Archdir & "\" & Monitor.Motore.Inizio.ReadIniFile("", "Azienda", "Logo")
        InsertPoint(0) = 15 : InsertPoint(1) = 2430 : InsertPoint(2) = 0
        scalefactor = 570
29:     rotationAngle = 0
30:     rasterObj = Disegno.ModelSpace.AddRaster(imageName, InsertPoint, scalefactor, rotationAngle)
31:     rasterObj.GetBoundingBox(minext, maxext)
        ' Lung = maxext(0) - minext(0)
32:     rasterObj.Update()
33:     'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto AcadApp.ZoomAll. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        AcadApp.ZoomAll()
34:     Disegno.Save() 'As FileDWG, acNative
        Exit Sub
ErrH:
        Testo = "Si è prodotto l'errore seguente durante la generazione" & vbCrLf
        Testo = Testo & "su AutoCAD delle curve di funzionamento." & vbCrLf
        Testo = Testo & Err.Description & vbCrLf & "(n°" & Str(Err.Number) & ", linea n°" & Str(Erl()) & ")"
        MsgBox(Testo, MsgBoxStyle.Critical)
        If Erl() = 30 Then Resume 33 Else Resume Next
    End Sub

    Private Sub cmdSalva_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdSalva.Click
        Dim File As String
        File = VB.Left(FilePRI, Len(FilePRI) - 5) & "P.PSW"
        'UPGRADE_WARNING: SavePicture è stato aggiornato a System.Drawing.Image.Save e ha un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
        Picture1.Image.Save(File)
    End Sub

    Private Sub cmdWord_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdWord.Click
        Dim File, NewF As String
        Dim FileP As String
        File = IO.Path.GetFileNameWithoutExtension(FilePRI) & "W.PSW"
        FileP = IO.Path.GetFileNameWithoutExtension(FilePRI) & "P.PSW"
        'UPGRADE_WARNING: SavePicture è stato aggiornato a System.Drawing.Image.Save e ha un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
        Picture1.Image.Save(FileP)
        IO.File.Delete(File)
        If Monitor.Motore.Inizio.VersOffice < 11 Then
            stub9.SuperStampa(File, Monitor.Motore.Inizio.VersOffice)
            If stub9 Is Nothing Then Exit Sub
            NewF = FileVEN()
            If IO.File.Exists(NewF) Then
                stub9.WaldInsert(NewF, 0)
                stub9.VaiInizio("\EndOfDoc")
                stub9.sBreak()
            End If
            stub9.VentilPict(FileP)
        Else
            Stub2000.SuperStampa(File, Monitor.Motore.Inizio.VersOffice)
            Stub2000.SuperStampa(File, Monitor.Motore.Inizio.VersOffice)
            If Stub2000 Is Nothing Then Exit Sub
            NewF = FileVEN()
            If IO.File.Exists(NewF) Then
                Stub2000.WaldInsert(NewF, 0)
                Stub2000.VaiInizio("\EndOfDoc")
                Stub2000.sBreak()
            End If
            Stub2000.VentilPict(FileP)
        End If
        Exit Sub
ErrW:
        Resume Warn
Warn:   MsgBox("Il file " & File & " è probabilmente in uso di WinWord. Chiuderlo", MsgBoxStyle.Information, "ISA")
    End Sub

    'UPGRADE_WARNING: Form evento frmCurva.Activate presenta un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
    Private Sub frmCurva_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
        _mnuFile_0.Enabled = Not daISA
        _mnuFile_1.Enabled = Not daISA
        _mnuFile_2.Enabled = Not daISA
        _mnuAzioni_3.Enabled = Not daISA
        _mnuAzioni_4.Enabled = Not daISA
        _mnuAzioni_5.Enabled = Not daISA
    End Sub
    Private Sub frmCurva_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        miaBitMap = New Bitmap(Picture1.ClientRectangle.Width, Picture1.ClientRectangle.Height, Picture1.CreateGraphics)
        Picture1.Image = miaBitMap
        glocPic = Graphics.FromImage(miaBitMap)
        locPen = New Pen(Color.Black)
        Top = 0 : Left = 130
        Height = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height - 60
        Width = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width - 260
        If _Option1_1.Checked Then ITOTAL = 1 Else ITOTAL = 0
        Me._mnpref_0.Checked = nuovePar
        _mnpref_1.Visible = nuovePar
        _mnpref_2.Visible = nuovePar
    End Sub
    Private Sub frmCurva_FormClosing(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim Cancel As Boolean = eventArgs.Cancel
        Dim UnloadMode As System.Windows.Forms.CloseReason = eventArgs.CloseReason
        eventArgs.Cancel = Cancel
    End Sub
    Private Sub frmCurva_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        finCurva = Nothing
        Monitor.Motore.Ammazza("Vent")
    End Sub
    Public Sub mnPref_Click(ByVal index As Integer)
        Dim Testo As String
        Dim Strin1(1) As String
        Dim Ris1(1) As String
        Dim Arch(1) As Short
        Dim dAiu(1) As String
        Dim Help As String = ""
        Dim UltAiu As String = ""
        Select Case Index
            Case 0
                nuovePar = Not nuovePar
                If nuovePar Then
                    Testo = "Si"
                    AprimyDb()
                Else
                    Testo = "No"
                    ChiudimyDb()
                End If
                Monitor.Motore.Inizio.WriteIniFile("", "Preferenze Ventil", "NuoveParabole", Testo)
                _mnpref_0.Checked = nuovePar
                _mnpref_1.Visible = nuovePar
                _mnpref_2.Visible = nuovePar
            Case 1
                UltAiu = "Fornire la correzione" & vbCrLf & "da applicare in detrazione"
                Strin1(1) = "Correzione [dB]"
                Ris1(1) = Format(CorrDB, "##.#")
                If Not Monitor.Motore.InputDati(1, "Correzione rumore", Strin1, Ris1, Help, Arch, dAiu, UltAiu) Then Exit Sub
                CorrDB = Val(Ris1(1))
                Monitor.Motore.Inizio.WriteIniFile("", "Preferenze Ventil", "CorrezioneRumore", Ris1(1))
                Cambiato = True
                Modulo()
                If GeneraPRI() Then makepri(False)
            Case 2
                UltAiu = "Fornire il fattore correttivo" & vbCrLf & "moltiplicativo del valore" & vbCrLf & "di rendimento calcolato"
                Strin1(1) = "Fattore [--]"
                Ris1(1) = Format(CorrRd, "##.###")
                If Not Monitor.Motore.InputDati(1, "Correzione rendimento", Strin1, Ris1, Help, Arch, dAiu, UltAiu) Then Exit Sub
                CorrRd = Val(Ris1(1))
                Monitor.Motore.Inizio.WriteIniFile("", "Preferenze Ventil", "CorrezioneRendimento", Ris1(1))
                Cambiato = True
                Modulo()
                If GeneraPRI() Then makepri(False)
        End Select
    End Sub

    Public Sub mnuAzioni_Click(ByVal Index As Integer)
        Dim ris As Boolean
        Dim i As Short
        Select Case Index
            Case 0
                secondo = True
                Monitor.Ogg.MainCurva()
            Case 1 'selezione ventilatori
                'UPGRADE_WARNING: Screen proprietà Screen.MousePointer presenta un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
                RivsuFile()
                ris = Ventilat(Monitor.Motore.Inizio.Archdir, False, True)
                Modulo()
                If GeneraPRI() Then makepri(False)
                'UPGRADE_WARNING: Screen proprietà Screen.MousePointer presenta un nuovo comportamento. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            Case 2
                RivsuFile()
                Modulo()
                If GeneraPRI() Then makepri(False)
            Case 3
                If O Is Nothing Then O = New clsTeor
                If RPM = 0 Then
                    MsgBox("Mancano dati di progetto")
                    Exit Sub
                End If
                O.SubDati()
                TabDati = myDataBase.OpenRecordset("SELECT * FROM DatiCalcolati")
                i = O.SupCalcolaN1
                TabDati.Close()
            Case 4
                GeneraGrafico()
                AggiungiParab()
            Case 5
                AggiungiFib()
        End Select
    End Sub
    Public Sub mnuFile_Click(ByVal Index As Integer)
        Dim Testo As String
        Select Case Index
            Case 0 : ApriVE1() ' nuovo
                Monitor.Ogg.MainCurva()
            Case 1 : ApriVE1() 'apri
                Monitor.Ogg.MainCurva()
            Case 2 : SalvVE1() 'salva
            Case 3 : SalvAs() 'salva con nome
            Case 4 'esci
                If ModifiedData Then
                    Testo = "Vuoi salvare i dati dell'item " & Item & " ?"
                    If MsgBox(Testo, MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.Yes Then SalvVE1()
                End If
                Hide()
                Me.Close()
        End Select
    End Sub

    Public Sub mnuHelp_Click(ByVal Index As Integer)
        Dim hwndHelp As Integer
        Select Case Index
            Case 0
                hwndHelp = HtmlHelp(Handle.ToInt32, RadiceHelp, HH_DISPLAY_TOC, 0)
        End Select
    End Sub
    Private Sub Option1_CheckedChanged(ByVal Index As Integer)
        If Inizializzando Then Exit Sub
        If Option1(Index).Checked Then
            'If Not LeggiDati Then Exit Sub
            If Option1(1).Checked Then ITOTAL = 1 Else ITOTAL = 0
            Modulo()
            If GeneraPRI() Then makepri(False)
        End If
    End Sub

    Private Sub _Option1_0_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Option1_0.CheckedChanged
        Option1_CheckedChanged(0)
    End Sub

    Private Sub _Option1_1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Option1_1.CheckedChanged
        Option1_CheckedChanged(1)
    End Sub
    Private ReadOnly Property Option1(ByVal i As Integer) As RadioButton
        Get
            Select Case I
                Case 0 : Return _Option1_0
                Case 1 : Return _Option1_1
                Case Else : Return Nothing
            End Select
        End Get
    End Property

    Private Sub _mnpref_0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _mnpref_0.Click
        mnPref_Click(0)
    End Sub

    Private Sub _mnpref_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _mnpref_1.Click
        mnPref_Click(1)
    End Sub

    Private Sub _mnpref_2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _mnpref_2.Click
        mnPref_Click(2)
    End Sub

    Private Sub _mnuAzioni_0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _mnuAzioni_0.Click
        mnuAzioni_Click(0)
    End Sub

    Private Sub _mnuAzioni_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _mnuAzioni_1.Click
        mnuAzioni_Click(1)
    End Sub

    Private Sub _mnuAzioni_2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _mnuAzioni_2.Click
        mnuAzioni_Click(2)
    End Sub

    Private Sub _mnuAzioni_3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _mnuAzioni_3.Click
        mnuAzioni_Click(3)
    End Sub

    Private Sub _mnuAzioni_4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _mnuAzioni_4.Click
        mnuAzioni_Click(4)
    End Sub

    Private Sub _mnuAzioni_5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _mnuAzioni_5.Click
        mnuAzioni_Click(5)
    End Sub

    Private Sub _mnuFile_0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _mnuFile_0.Click
        mnuFile_Click(0)
    End Sub

    Private Sub _mnuFile_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _mnuFile_1.Click
        mnuFile_Click(1)
    End Sub

    Private Sub _mnuFile_2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _mnuFile_2.Click
        mnuFile_Click(2)
    End Sub

    Private Sub _mnuFile_3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _mnuFile_3.Click
        mnuFile_Click(3)
    End Sub

    Private Sub _mnuFile_4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _mnuFile_4.Click
        mnuFile_Click(4)
    End Sub

    Private Sub _mnuHelp_0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _mnuHelp_0.Click
        mnuHelp_Click(0)
    End Sub
End Class