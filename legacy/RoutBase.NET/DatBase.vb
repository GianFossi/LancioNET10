Option Strict On
Option Explicit On
Public Class DatBase
    Private Structure rrec
        Dim Iniz As Short
        Dim luni As Short
        <VBFixedString(2), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst:=2)> Public Itip As String
        <VBFixedString(2), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst:=2)> Public narc As String
        Dim rarc As Short
        <VBFixedString(34), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst:=34)> Public Desc As String
    End Structure
    Public objInizio As clsInizio
    Public Arch As String
    Private recr As rrec
    Public Function Misur(ByRef UniM As String, ByRef iC As Short) As String
        Select Case iC
            Case 1
                Select Case UniM
                    Case "ME", "SI" : Misur = " [°C]"
                    Case "BR" : Misur = " [°F]"
                    Case Else : Misur = " [??]"
                End Select
            Case 2
                Select Case UniM
                    Case "ME" : Misur = " [Kg/cm2]"
                    Case "BR" : Misur = " [psi]"
                    Case "SI" : Misur = " [kPa]"
                    Case Else : Misur = " [??]"
                End Select
            Case 3
                Select Case UniM
                    Case "ME", "SI" : Misur = " [mm]"
                    Case "BR" : Misur = " [in]"
                    Case Else : Misur = " [??]"
                End Select
            Case Else : Misur = " [?]"
        End Select
    End Function
    Function DatBase(ByRef nre As Short, ByRef ndat As Short, ByRef Item As Short, ByRef Ialt As Short, ByRef itp As String, ByRef ilsi As Short) As String
        Dim Nitems, NrecMax As Short
        Dim Stringa3(5) As String
        Dim Help As String
        Dim i As Short
        Dim Buf, arar As String
        Dim nreb, nrec, u As Short
        Dim npos, il1rec, ilf As Short
        Dim iboo, iuno, nrecu, lenrec As Short
        Dim Buf18 As New VB6.FixedLengthString(18)
        For i = 1 To 5 ': Line Input #ifl, Stringa3(i): Next
            Stringa3(i) = HelpStringa(clsInizio.IDHS.IDH_BASE_HTRI06 + 5 + i)
        Next
        Nitems = CVI(Readreco(1, 43, 1))
        NrecMax = CVI(Readreco(1, 45, 1))
        If Nitems = 0 And nre = 1 Then GoTo Jump
        If Item > Nitems Or Item < 1 Then
            DatBase = Space(0)
            Help = Stringa3(1) & Str(Item) ' "Nø Item errato In DatBase:"
            MsgBox(Help, CType(MsgBoxStyle.OKOnly + MsgBoxStyle.Critical, MsgBoxStyle), "ISA - Grstione PRV")
            Exit Function
        End If
        If nre < 1 Or nre > 7 Then
            DatBase = Space(0)
            Help = Stringa3(2) & Str(nre) ' "Nø Record errato In DatBase"
            MsgBox(Help, CType(MsgBoxStyle.OKOnly + MsgBoxStyle.Critical, MsgBoxStyle), "ISA - Grstione PRV")
            Exit Function
        End If
        If Ialt < 1 Or Ialt > 5 Then
            DatBase = Space(0)
            Help = Stringa3(3) & Str(Ialt) ' "Nø Alternativa errata In DatBase:"
            MsgBox(Help, CType(MsgBoxStyle.OKOnly + MsgBoxStyle.Critical, MsgBoxStyle))
            Exit Function
        End If
Jump:
        Select Case nre
            Case 1 : nrec = 1
            Case 2 : nrec = CShort(2 * Item)
            Case 3 : nrec = CShort(2 * Item + 1)
            Case Is > 3
                u = DatRecbase(2, CShort(57 + (Ialt - 1) * 2))
                nreb = CShort(2 * Item)
                il1rec = CVI(Readreco(nreb, recr.Iniz, recr.luni))
                nrec = CShort(il1rec + nre - 4)
        End Select
        u = DatRecbase(nre, ndat)
        If nrec > 0 Then
            Buf = Readreco(nrec, recr.Iniz, recr.luni)
        Else
            Buf = New String(CType(" ", Char), 2 * recr.luni)
        End If
        itp = LTrim(RTrim(recr.Itip))
        If Val(recr.narc) > 10 And Val(recr.narc) < 70 And ilsi = 1 Then
            npos = CVI(Buf)
            If npos < 2 Then
                npos = 2
                Buf = PutReco(nrec, recr.Iniz, recr.luni, MKI(npos), itp)
            End If
            ilf = CShort(FreeFile()) : arar = "arch" & recr.narc & ".dat"
            Try
                FileOpen(ilf, RTrim(objInizio.Archdir) & Chr(92) & arar, OpenMode.Input, , OpenShare.Shared)
            Catch e As Exception
                MsgBox(e.Message & vbCrLf & e.StackTrace & vbCrLf & "(File: " & RTrim(objInizio.Archdir) & Chr(92) & arar & ")")
                Return ""
            End Try
            Input(ilf, iuno)
            Input(ilf, nrecu)
            Input(ilf, iboo)
            Input(ilf, lenrec)
            FileClose(ilf)
            Try
                FileOpen(ilf, RTrim(objInizio.Archdir) & Chr(92) & arar, OpenMode.Random, OpenAccess.Read, OpenShare.Shared, lenrec * 2 + 2)
            Catch e As Exception
                MsgBox(e.Message & vbCrLf & e.StackTrace & vbCrLf & "(File: " & RTrim(objInizio.Archdir) & "\datprv.dat" & ")")
                Return ""
            End Try
            Select Case lenrec
                Case 8, 16
                    FileGet(ilf, Buf18.Value, npos)
                    Buf = Left(Buf18.Value, lenrec)
                    'Case 16
                Case Else
                    Stop
            End Select
            'FIELD #ilf, iuno * 2 AS b$
            'GET #ilf, npos
            itp = "S"
            FileClose(ilf)
        End If
        DatBase = Buf
    End Function
    Public Sub Rigenera()
        Dim ifl, nscheda As Integer
        Dim Progr, progrv As Short
        Dim Stringa As String = ""
        Dim j, ifl1 As Integer
        Dim Riga As String
        ifl = FreeFile()
        If Trigon Is Nothing Then Trigon = New clsTrigon
        Try
            FileOpen(ifl, RTrim(objInizio.Archdir) & "\datprv.dat", OpenMode.Random, , OpenShare.Shared, Len(recr))
        Catch e As Exception
            MsgBox(e.Message & vbCrLf & e.StackTrace & vbCrLf & "(File: " & RTrim(objInizio.Archdir) & "\datprv.dat" & ")")
            Exit Sub
        End Try
        ifl1 = FreeFile()
        Try
            FileOpen(ifl1, RTrim(objInizio.Archdir) & "\datiprev", OpenMode.Input)
        Catch e As Exception
            MsgBox(e.Message & vbCrLf & e.StackTrace & vbCrLf & "(File: " & RTrim(objInizio.Archdir) & "\datiprev" & ")")
            Exit Sub
        End Try
        Riga = LineInput(ifl1)
        j = 1
        Do
            Riga = LineInput(ifl1)
            If Len(Riga) = 0 Then Exit Do
            nscheda = CInt(Val(Mid(Riga, 8, 2)))
            If nscheda = 0 Then Exit Do
            Progr = CShort(Val(Mid(Riga, 13, 2)))
            If Progr <= progrv Then
                Stringa = Stringa & Trigon.Str2Cifre(progrv)
            End If
            progrv = Progr
            recr.Iniz = CShort(Val(Mid(Riga, 18, 3)))
            recr.luni = CShort(Val(Mid(Riga, 24, 3)))
            recr.Itip = Mid(Riga, 30, 2)
            recr.narc = Mid(Riga, 35, 2)
            recr.Desc = Right(Riga, Len(Riga) - 45)
            j = j + 1
            FilePut(ifl, recr, j)
        Loop Until EOF(ifl1)
        Stringa = Stringa & Trigon.Str2Cifre(Progr)
        recr.Iniz = 0
        recr.luni = 0
        recr.Itip = ""
        recr.narc = ""
        recr.Desc = Stringa
        FilePut(ifl, recr, 1)
        FileClose(ifl, ifl1)
    End Sub
    Function DatRecbase(ByRef nre As Short, ByRef ndat As Short) As Short
        Dim ifl, ndati As Integer
        Dim j As Integer
        ifl = FreeFile()
        Try
            FileOpen(ifl, RTrim(objInizio.Archdir) & "\datprv.dat", OpenMode.Random, , OpenShare.Shared, Len(recr))
        Catch e As Exception
            MsgBox(e.Message & vbCrLf & e.StackTrace & vbCrLf & "(File: " & RTrim(objInizio.Archdir) & "\datprv.dat" & ")")
            Exit Function
        End Try
        FileGetObject(ifl, CType(recr, Object), 1)
        ndati = 1
        For j = 1 To nre - 1
            ndati = CInt(ndati + Val(Mid(recr.Desc, (j - 1) * 2 + 1, 2)))
        Next
        ndati = ndati + ndat
        'ndati = 219
        FileGetObject(ifl, CType(recr, Object), ndati)
        FileClose(ifl)
        DatRecbase = 0 ' Dati   '??????????
    End Function
    Function PutBasCh(ByRef nre As Short, ByRef ndat As Short, ByRef Item As Short, ByRef Ialt As Short, ByRef inp As String, ByRef ilsi As Short) As Object
        'On Local Error GoTo ErrPut
        Dim Stringa3(5) As String
        Dim u As Short
        Dim Help As String
        Dim Nitems, i, NrecMax As Short
        Dim Buf, itp As String
        Dim nrec As Short
        Dim nreb, il1rec As Short
        For i = 1 To 5
            Stringa3(i) = HelpStringa(clsInizio.IDHS.IDH_BASE_HTRI06 + i)
        Next
        Nitems = CVI(Readreco(1, 43, 1))
        NrecMax = CVI(Readreco(1, 45, 1))
        If Nitems = 0 And nre = 1 Then GoTo Jump
        If Item > Nitems Or Item < 1 Then
            PutBasCh = Space(0)
            Help = Stringa3(1) & Str(Item) ' "Nø Item errato In PutBasCh:"
            MsgBox(Help, CType(MsgBoxStyle.OKOnly + MsgBoxStyle.Critical, MsgBoxStyle))
            Exit Function
        End If
        If nre < 1 Or nre > 7 Then
            PutBasCh = Space(0)
            Help = Stringa3(2) & Str(nre) ' "Nø Record errato In PutBasCh:"
            MsgBox(Help, CType(MsgBoxStyle.OKOnly + MsgBoxStyle.Critical, MsgBoxStyle))
            Exit Function
        End If
        If Ialt < 1 Or Ialt > 5 Then
            PutBasCh = Space(0)
            Help = Stringa3(3) & Str(Ialt) ' "Nø Alternativa errata In PutBasCh:"
            MsgBox(Help, CType(MsgBoxStyle.OKOnly + MsgBoxStyle.Critical, MsgBoxStyle))
            Exit Function
        End If
Jump:
        Select Case nre
            Case 1 : nrec = 1
            Case 2 : nrec = CShort(2 * Item)
            Case 3 : nrec = CShort(2 * Item + 1)
            Case Is > 3
10:             u = DatRecbase(2, CShort(57 + (Ialt - 1) * 2))
                nreb = CShort(2 * Item)
20:             il1rec = CVI(Readreco(nreb, recr.Iniz, recr.luni))
                nrec = CShort(il1rec + nre - 4)
        End Select
30:     u = DatRecbase(nre, ndat)
        itp = LTrim(RTrim(recr.Itip))
40:     Buf = PutReco(nrec, recr.Iniz, recr.luni, inp, itp)
        PutBasCh = Buf
    End Function

    Function PutReco(ByRef nrec As Short, ByRef ipos As Short, ByRef ilu As Short, ByRef inp As String, ByRef itp As String) As String
        Dim Dati As New VB6.FixedLengthString(256)
        Dim ifl As Integer
        Dim File1 As String
        Dim ibyte As Integer
140:    ifl = FreeFile()
        File1 = RTrim(objInizio.Workdir) & Chr(92) & Left(Arch, 4) & ".PRV"
        On Error GoTo ErrAut
        FileOpen(ifl, File1, OpenMode.Binary, OpenAccess.ReadWrite)
        On Error GoTo 0
        ibyte = (nrec - 1) * 256 + 1
        FileGet(ifl, Dati.Value, ibyte)
        Mid(Dati.Value, (ipos - 1) * 2 + 1, ilu * 2) = Left(inp, ilu * 2)
        FilePut(ifl, Dati.Value, ibyte)
        FileClose(ifl)
160:    PutReco = Mid(Dati.Value, (ipos - 1) * 2 + 1, ilu * 2)
ExAut:
        Exit Function
ErrAut: Resume ExAut
    End Function
    Function Readreco(ByRef nrec As Short, ByRef ipos As Short, ByRef ilu As Short) As String
        Dim Dati As New VB6.FixedLengthString(256)
        Dim ifl As Integer
        Dim File1 As String
        Dim ibyte As Integer
240:    ifl = FreeFile()
        File1 = RTrim(objInizio.Workdir) & Chr(92) & Left(Arch, 4) & ".PRV"
        FileOpen(ifl, File1, OpenMode.Binary, OpenAccess.Read)
        ibyte = (nrec - 1) * 256 + 1
        FileGet(ifl, Dati.Value, ibyte)
        FileClose(ifl)
260:    Readreco = Mid(Dati.Value, (ipos - 1) * 2 + 1, ilu * 2)
    End Function
    Public Function CVI(ByRef a As String) As Short
        Dim i, ifl As Integer
        Dim a1 As New VB6.FixedLengthString(2)
        Dim Nome As String
        ifl = FreeFile()
        a1.Value = Left(a, 2)
        If objInizio Is Nothing Then
            Nome = "TEMP"
        Else
            Nome = objInizio.DiscoTem & "TEMP"
        End If
        FileOpen(ifl, Nome, OpenMode.Binary)
        FilePut(ifl, a1.Value, 1)
        FileGet(ifl, i, 1)
        FileClose(ifl)
        Kill(Nome)
        CVI = CShort(i)
    End Function
    Public Function CVS(ByRef a As String) As Single
        Dim i As Single
        Dim ifl As Integer
        Dim a1 As New VB6.FixedLengthString(4)
        Dim Nome As String
        ifl = FreeFile()
        a1.Value = Left(a, 4)
        If objInizio Is Nothing Then
            Nome = "TEMP"
        Else
            Nome = objInizio.DiscoTem & "TEMP"
        End If
        FileOpen(ifl, Nome, OpenMode.Binary)
        FilePut(ifl, a1.Value, 1)
        FileGet(ifl, i, 1)
        FileClose(ifl)
        Kill(Nome)
        CVS = i
    End Function
    Public Function MKI(ByRef a As Short) As String
        Dim i As New VB6.FixedLengthString(2)
        Dim ifl As Integer
        ifl = FreeFile()
        FileOpen(ifl, objInizio.DiscoTem & "TEMP", OpenMode.Binary)
        FilePut(ifl, a, 1)
        FileGet(ifl, i.Value, 1)
        FileClose(ifl)
        Kill(objInizio.DiscoTem & "TEMP")
        MKI = i.Value
    End Function
    Public Function MKS(ByRef a As Single) As String
        Dim i As New VB6.FixedLengthString(4)
        Dim ifl As Integer
        ifl = FreeFile()
        FileOpen(ifl, objInizio.DiscoTem & "TEMP", OpenMode.Binary)
        FilePut(ifl, a, 1)
        FileGet(ifl, i.Value, 1)
        FileClose(ifl)
        Kill(objInizio.DiscoTem & "TEMP")
        MKS = i.Value
    End Function
End Class