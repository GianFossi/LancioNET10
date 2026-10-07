Option Strict Off
Option Explicit On
Imports System.IO
Imports System.Runtime.Serialization
Imports System.Runtime.Serialization.Formatters.Binary
Imports RoutBase1
Module modSezioni
    Public ySez As Short
    Private y1, NumIt As Short
    Private junk As Integer
    Private Stringa(6) As String
    Private Tit, Help As String
    Private j, ifl As Short
    Private Tit1 As String
    Private Stringa1(6) As String
    Private Item(6) As String
    Private NumIt1 As Short
    Private i As Short
    Private OK As Boolean
    Private Archiv(6) As Short
    Private dAiu(6) As String
    Public Function UgSez(ByRef s1 As clsSezioni, ByRef s2 As clsSezioni) As Boolean
        Dim i As Short
        UgSez = True
        If s1.Nsezioni <> s2.Nsezioni Then UgSez = False : Exit Function
        For i = 1 To s1.Nsezioni
            If s1.Tipo(i) <> s2.Tipo(i) Then UgSez = False : Exit Function
            If s1.Quota(i) <> s2.Quota(i) Then UgSez = False : Exit Function
            If s1.Spost(i).X <> s2.Spost(i).X Then UgSez = False : Exit Function
            If s1.Spost(i).y <> s2.Spost(i).y Then UgSez = False : Exit Function
            If s1.Verso(i) <> s2.Verso(i) Then UgSez = False : Exit Function
        Next
    End Function
    Sub EditSezioni1(ByRef ixo As Single)
        Try
            If EditingSezioni Then
300:            ySez = sezvec.Nsezioni
                sezvec.Nsezioni = sezvec.Nsezioni + 1
                sezvec.Tipo(ySez + 1) = 2
                sezvec.Verso(ySez + 1) = 1
                sezvec.Quota(ySez + 1) = ixo ' (ixo - offx!) / Scalb!
                RifaiW1()
                'ElseIf sezvec.Nsezioni <= 1 Then
                '   LungPre = 72 'posiziona una nuova sezione
                '   GoTo FineW
            Else
RifaiW:         PrepString()
                sezioni = sezvec.Clone
                '      Help$ = "Help non disponibile"
                ySez = Monitor.Motore.Quale(NumIt + 1, Tit, Stringa, Help, 1)
                If ySez = 0 Then
                    NoChange(junk)
                    If Not junk = MsgBoxResult.Yes Then GoTo RifaiW
                ElseIf ySez = NumIt + 1 Then
                    EditingSezioni = True 'posiziona una nuova sezione
                Else
                    RifaiW1()
                End If
            End If
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Private Sub PrepString()
        Tit = "Editing sezioni: quale?"
        NumIt = sezvec.Nsezioni
        For j = 1 To NumIt
            Stringa(j) = "Sezione n°" & j.ToString
        Next
        Stringa(NumIt + 1) = "Nuova Sezione"
    End Sub
    Private Sub RifaiW1()
        PrepString1()
        dAiu(NumIt1) = "*"
        Monitor.Motore.InputDatiM(1, NumIt1, Tit1, Stringa1, Item, Help, Archiv, dAiu)
        '                                    100        7       30
    End Sub
    Private Sub PrepString1()
        ifl = FreeFile()
        FileOpen(ifl, RTrim(Monitor.Motore.Inizio.Archdir) & "\DIST02.DAT", OpenMode.Input, , OpenShare.Shared)
        Tit1 = LineInput(ifl)
        Tit1 = Tit1 & Str(ySez - 1)
        For i = 1 To 6 : Stringa1(i) = LineInput(ifl) : Next
        Item(6) = LineInput(ifl)
        FileClose(ifl)
        'Stringa1$(1) = "Tipo della sezione "
        Item(1) = Str(sezvec.Tipo(ySez))
        If Val(Item(1)) < 1 Or Val(Item(1)) > 3 Then Item(1) = Str(2)
        'Stringa1$(2) = "Quota su asse      "
        Item(2) = GlobalRoutines.myStr(sezvec.Quota(ySez), 6, 2, False)
        'Stringa1$(3) = "Spostamento x      "
        Item(3) = GlobalRoutines.myStr(sezvec.Spost(ySez).X, 6, 2, False)
        'Stringa1$(4) = "Spostamento ySez      "
        Item(4) = GlobalRoutines.myStr(sezvec.Spost(ySez).y, 6, 2, False)
        'Stringa1$(5) = "Verso (+/-)        "
        Item(5) = GlobalRoutines.myStr(CSng(sezvec.Verso(ySez)), 2, 0, True)
        'Stringa1$(6) = "Elimina questa sez."
        '     Item$(6) = "Clicka qui"
        NumIt1 = 6
        If EditingSezioni Then NumIt1 = 5
    End Sub
    Public Sub LeggiSezioni()
        Dim File As String
        Dim ce As Boolean
        File = FunzLibgra.FileDes("SEZ")
        ce = File.Trim.Length > 0
        If ce Then ce = IO.File.Exists(File)
        If Not ce Then
            sezioni = New clsSezioni
            SalvaSezioni()
        Else
            Dim myFileStream As Stream = IO.File.OpenRead(File)
            Dim deserializer As New Lancio.Legacy.Serialization.LegacyBinarySerializer
            Try
                sezioni = CType(deserializer.Deserialize(myFileStream), clsSezioni)
                myFileStream.Close()
            Catch e As Exception
                sezioni = New clsSezioni
                myFileStream.Close()
                SalvaSezioni()
                MsgBox(e.Message + vbCrLf + e.StackTrace)
            End Try
            If Not (sezioni.Verso(1) = -1 Or sezioni.Verso(1) = 1) Then sezioni.Verso(1) = -1
        End If
        sezvec = sezioni
    End Sub
    Public Sub SalvaSezioni()
        Dim File As String
        File = FunzLibgra.FileDes("SEZ")
        If File.Trim.Length = 0 Then Exit Sub
        Dim myFileStream As Stream = IO.File.OpenWrite(File)
        Dim deserializer As New Lancio.Legacy.Serialization.LegacyBinarySerializer
        deserializer.Serialize(myFileStream, sezioni)
        myFileStream.Close()
    End Sub
    Public Sub NoChange(ByRef junk As Integer)
        Dim Help As String
400:    Help = "Confermi di non volere cambiamenti ?"
        junk = MsgBox(Help, MsgBoxStyle.YesNo + MsgBoxStyle.Question)
    End Sub
    Public Sub CercaX(ByRef xSezMin As Single, ByRef xSezMax As Single, ByRef isez As Short)
        Dim s As spot
        Dim g As clsGenMem
        Dim i, ii As Short
        Dim O As Membratura
        Dim xMaxAct, xMinAct As Single
        xSezMax = -clsTrigon.Infinito
        xSezMin = clsTrigon.Infinito
        For ii = 0 To Apparecchio.Elementi.Count - 1
            O = Apparecchio.Elementi(ii)
            g = O.GenMem
            For i = 1 To g.Segnalini.Count()
                s = g.Segnalini(i)
                If s.Sezione = isez Then
                    xMaxAct = s.Quadro.Botrigt.X : xMinAct = s.Quadro.TopLeft.y
                    If xMaxAct < xMinAct Then GlobalRoutines.SWAP(xMaxAct, xMinAct)
                    If xMaxAct > xSezMax Then xSezMax = xMaxAct
                    If xMinAct < xSezMin Then xSezMin = xMinAct
                End If
            Next
        Next ii
        With frmDistinta.DefInstance.pictAssieme
            If xSezMax = -clsTrigon.Infinito Then xSezMax = .Left + .ClientRectangle.Width ' .ScaleLeft + LegacyUiUnits.PixelsToTwipsX(.ClientRectangle.Width)
            If xSezMin = clsTrigon.Infinito Then xSezMin = .Top ' .ScaleTop
        End With
    End Sub
End Module