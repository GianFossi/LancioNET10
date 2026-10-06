VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
  Persistable = 0  'NotPersistable
  DataBindingBehavior = 0  'vbNone
  DataSourceBehavior  = 0  'vbNone
  MTSTransactionMode  = 0  'NotAnMTSObject
END
Attribute VB_Name = "DatBase"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = True
Option Explicit
Private Const IDH_BASE_HTRI06 As Long = 12000
Private Type rrec
   Iniz As Integer
   luni As Integer
   Itip As String * 2
   narc As String * 2
   rarc As Integer
   Desc As String * 34
End Type
Public objInizio As Inizio
Public Arch As String
Private recr As rrec
Public Function Misur(UniM As String, iC As Integer) As String
Select Case iC
  Case 1
   Select Case UniM
     Case "ME", "SI": Misur = " [°C]"
     Case "BR": Misur$ = " [°F]"
     Case Else: Misur$ = " [??]"
   End Select
  Case 2
   Select Case UniM
      Case "ME": Misur = " [Kg/cm2]"
      Case "BR": Misur = " [psi]"
      Case "SI": Misur = " [kPa]"
      Case Else: Misur = " [??]"
   End Select
  Case 3
   Select Case UniM
     Case "ME", "SI": Misur = " [mm]"
     Case "BR": Misur = " [in]"
     Case Else: Misur = " [??]"
   End Select
  Case Else: Misur = " [?]"
End Select
End Function
Function DatBase(nre As Integer, ndat As Integer, Item As Integer, Ialt As Integer, itp As String, ilsi As Integer) As String
Dim Nitems As Integer, NrecMax As Integer
Dim Stringa3(5) As String, Help As String, i As Integer
Dim Buf As String, arar As String, ifl As Integer
Dim nrec As Integer, nreb As Integer, u As Integer
Dim il1rec As Integer, npos As Integer, ilf As Integer
Dim iuno As Integer, nrecu As Integer, iboo As Integer, lenrec As Integer
Dim Buf18 As String * 18
'ifl = FreeFile
'Open RTrim$(objInizio.Archdir) + "\HTRI06.DAT" For Input Shared As #ifl
'For i = 1 To 5: Line Input #ifl, Stringa3(i): Next
For i = 1 To 5 ': Line Input #ifl, Stringa3(i): Next
  Stringa3(i) = LoadResString(IDH_BASE_HTRI06 + 5 + i)
Next
'Close #ifl
Nitems = CVI(Readreco(1, 43, 1))
NrecMax = CVI(Readreco(1, 45, 1))
If Nitems = 0 And nre = 1 Then GoTo Jump
If Item > Nitems Or Item < 1 Then
      DatBase = Space$(0)
      Help = Stringa3(1) + str$(Item) ' "Nø Item errato In DatBase:"
      MsgBox Help, vbOK + vbCritical, "ISA - Grstione PRV"
      Exit Function
End If
If nre < 1 Or nre > 7 Then
      DatBase = Space$(0)
      Help = Stringa3$(2) + str$(nre) ' "Nø Record errato In DatBase"
      MsgBox Help, vbOK + vbCritical, "ISA - Grstione PRV"
      Exit Function
End If
If Ialt < 1 Or Ialt > 5 Then
      DatBase = Space$(0)
      Help = Stringa3(3) + str$(Ialt) ' "Nø Alternativa errata In DatBase:"
      MsgBox Help, vbOK + vbCritical
      Exit Function
End If
Jump:
Select Case nre
      Case 1: nrec = 1
      Case 2: nrec = 2 * Item
      Case 3: nrec = 2 * Item + 1
      Case Is > 3
      u = DatRecbase(2, 57 + (Ialt - 1) * 2)
      nreb = 2 * Item
      il1rec = CVI(Readreco(nreb, recr.Iniz, recr.luni))
      nrec = il1rec + nre - 4
End Select
u = DatRecbase(nre, ndat)
If nrec > 0 Then
   Buf = Readreco(nrec, recr.Iniz, recr.luni)
Else
'FIXIT: Sostituire la funzione "String" con la funzione "String$"                          FixIT90210ae-R9757-R1B8ZE
   Buf = String$(2 * recr.luni, " ")
End If
itp = LTrim$(RTrim$(recr.Itip))
If Val(recr.narc) > 10 And Val(recr.narc) < 70 And ilsi = 1 Then
      npos = CVI(Buf)
      If npos < 2 Then
         npos = 2
         Buf = PutReco(nrec, recr.Iniz, recr.luni, MKI(npos), itp$)
      End If
      ilf = FreeFile: arar = "arch" + recr.narc + ".dat"
      Open RTrim$(objInizio.Archdir) + Chr$(92) + arar For Input Shared As #ilf
      Input #ilf, iuno, nrecu, iboo, lenrec
      Close #ilf
      Open RTrim$(objInizio.Archdir) + Chr$(92) + arar For Random Access Read Shared As #ilf Len = lenrec * 2 + 2
      Select Case lenrec
      Case 8, 16
         Get #ilf, npos, Buf18
'FIXIT: Sostituire la funzione "Left" con la funzione "Left$"                              FixIT90210ae-R9757-R1B8ZE
         Buf = Left(Buf18, lenrec)
      'Case 16
      Case Else
         Stop
      End Select
      'FIELD #ilf, iuno * 2 AS b$
      'GET #ilf, npos
      itp = "S"
      Close #ilf
End If
DatBase = Buf
End Function
Public Sub Rigenera()
Dim ifl As Integer, ndati As Integer, nscheda As Integer
Dim Progr As Integer, progrv As Integer, Stringa As String
Dim j As Integer, ifl1 As Integer, Riga As String
ifl = FreeFile
If Trigon Is Nothing Then Set Trigon = New clsTrigon
Open RTrim$(objInizio.Archdir) + "\datprv.dat" For Random Shared As #ifl Len = Len(recr)
ifl1 = FreeFile
Open RTrim$(objInizio.Archdir) + "\datiprev" For Input As #ifl1
Line Input #ifl1, Riga
j = 1
Do
   Line Input #ifl1, Riga
   If Len(Riga) = 0 Then Exit Do
   nscheda = Val(Mid$(Riga, 8, 2))
   If nscheda = 0 Then Exit Do
   Progr = Val(Mid$(Riga, 13, 2))
   If Progr <= progrv Then
      Stringa = Stringa + Trigon.Str2Cifre(progrv)
   End If
   progrv = Progr
   recr.Iniz = Val(Mid$(Riga, 18, 3))
   recr.luni = Val(Mid$(Riga, 24, 3))
   recr.Itip = Mid$(Riga, 30, 2)
   recr.narc = Mid$(Riga, 35, 2)
   recr.Desc = Right$(Riga, Len(Riga) - 45)
   j = j + 1
   Put #ifl, j, recr
Loop Until EOF(ifl1)
Stringa = Stringa + Trigon.Str2Cifre(Progr)
recr.Iniz = 0
recr.luni = 0
recr.Itip = ""
recr.narc = ""
'stringa = "18722673270150"
recr.Desc = Stringa
Put #ifl, 1, recr
Close #ifl, #ifl1
End Sub
Function DatRecbase(nre As Integer, ndat As Integer) As Integer
Dim ifl As Integer, ndati As Integer
Dim j As Integer
ifl = FreeFile
Open RTrim$(objInizio.Archdir) + "\datprv.dat" For Random Shared As #ifl Len = Len(recr)
Get #ifl, 1, recr
ndati = 1
For j = 1 To nre - 1
      ndati = ndati + Val(Mid$(recr.Desc, (j - 1) * 2 + 1, 2))
Next
ndati = ndati + ndat
'ndati = 219
Get #ifl, ndati, recr
Close #ifl
DatRecbase = 0 ' Dati   '??????????
End Function

'FIXIT: Dichiarare "PutBasCh" con un tipo di dati ad associazione anticipata               FixIT90210ae-R1672-R1B8ZE
Function PutBasCh(nre As Integer, ndat As Integer, Item As Integer, Ialt As Integer, inp As String, ilsi As Integer)
'On Local Error GoTo ErrPut
Dim Stringa3(5) As String, ifl As Integer, Help As String, u As Integer
Dim i As Integer, Nitems As Integer, NrecMax As Integer
Dim Buf As String, itp As String, nrec As Integer
Dim nreb As Integer, il1rec As Integer
'ifl = FreeFile
'Open RTrim$(objInizio.Archdir) + "\HTRI06.DAT" For Input Shared As #ifl
For i = 1 To 5
  'Line Input #ifl, Stringa3(i)
  Stringa3(i) = LoadResString(IDH_BASE_HTRI06 + i)
Next
'Close #ifl
Nitems = CVI(Readreco(1, 43, 1))
NrecMax = CVI(Readreco(1, 45, 1))
If Nitems = 0 And nre = 1 Then GoTo Jump
If Item > Nitems Or Item < 1 Then
      PutBasCh = Space$(0)
      Help = Stringa3(1) + str$(Item) ' "Nø Item errato In PutBasCh:"
      MsgBox Help, vbOK + vbCritical
      Exit Function
End If
If nre < 1 Or nre > 7 Then
      PutBasCh = Space$(0)
      Help = Stringa3(2) + str$(nre) ' "Nø Record errato In PutBasCh:"
      MsgBox Help, vbOK + vbCritical
      Exit Function
End If
If Ialt < 1 Or Ialt > 5 Then
      PutBasCh = Space$(0)
      Help = Stringa3(3) + str$(Ialt) ' "Nø Alternativa errata In PutBasCh:"
      MsgBox Help, vbOK + vbCritical
      Exit Function
End If
Jump:
Select Case nre
      Case 1: nrec = 1
      Case 2: nrec = 2 * Item
      Case 3: nrec = 2 * Item + 1
      Case Is > 3
10    u = DatRecbase(2, 57 + (Ialt - 1) * 2)
      nreb = 2 * Item
20    il1rec = CVI(Readreco(nreb, recr.Iniz, recr.luni))
      nrec = il1rec + nre - 4
End Select
30    u = DatRecbase(nre, ndat)
      itp = LTrim$(RTrim$(recr.Itip))
40    Buf = PutReco(nrec, recr.Iniz, recr.luni, inp, itp)
PutBasCh = Buf
'Exit Function
'ErrPut: Print Stringa3$(4); Err; Erl: Stop '"Errore in PutBasCh"
End Function

Function PutReco(nrec As Integer, ipos As Integer, ilu As Integer, inp As String, itp As String) As String
Dim Dati As String * 256, ifl As Integer
Dim File1 As String, ibyte As Long
140 ifl = FreeFile
    File1 = RTrim$(objInizio.Workdir) + Chr$(92) + Left$(Arch, 4) + ".PRV"
    On Error GoTo ErrAut
    Open File1 For Binary Access Read Write As #ifl
    On Error GoTo 0
    ibyte = (nrec - 1) * 256& + 1
    Get #ifl, ibyte, Dati
    Mid$(Dati, (ipos - 1) * 2 + 1, ilu * 2) = Left$(inp, ilu * 2)
    Put #ifl, ibyte, Dati
    Close #ifl
160 PutReco = Mid$(Dati, (ipos - 1) * 2 + 1, ilu * 2)
ExAut:
Exit Function
ErrAut: Resume ExAut
End Function

Function Readreco(nrec As Integer, ipos As Integer, ilu As Integer) As String
Dim Dati As String * 256, ifl As Integer
Dim File1 As String, ibyte As Long
240 ifl = FreeFile
    File1 = RTrim$(objInizio.Workdir) + Chr$(92) + Left$(Arch, 4) + ".PRV"
    Open File1 For Binary Access Read As #ifl
    ibyte = (nrec - 1) * 256& + 1
    Get #ifl, ibyte, Dati
    Close #ifl
260 Readreco = Mid$(Dati, (ipos - 1) * 2 + 1, ilu * 2)
End Function
Public Function CVI(a As String) As Integer
    Dim i As Integer, ifl As Integer, a1 As String * 2
    Dim Nome As String
    ifl = FreeFile
    a1 = Left$(a, 2)
    If objInizio Is Nothing Then
       Nome = "TEMP"
    Else
       Nome = objInizio.DiscoTem + "TEMP"
    End If
    Open Nome For Binary As ifl
    Put #ifl, 1, a1
    Get #ifl, 1, i
    Close #ifl
    Kill Nome
    CVI = i
End Function
Public Function CVS(a As String) As Single
    Dim i As Single, ifl As Integer, a1 As String * 4
    Dim Nome As String
    ifl = FreeFile
    a1 = Left$(a, 4)
    If objInizio Is Nothing Then
       Nome = "TEMP"
    Else
       Nome = objInizio.DiscoTem + "TEMP"
    End If
    Open Nome For Binary As ifl
    Put #ifl, 1, a1
    Get #ifl, 1, i
    Close #ifl
    Kill Nome
    CVS = i
End Function
Public Function MKI(a As Integer) As String
    Dim i As String * 2, ifl As Integer
    ifl = FreeFile
    Open objInizio.DiscoTem + "TEMP" For Binary As ifl
    Put #ifl, 1, a
    Get #ifl, 1, i
    Close #ifl
    Kill objInizio.DiscoTem + "TEMP"
    MKI = i
End Function
Public Function MKS(a As Single) As String
    Dim i As String * 4, ifl As Integer
    ifl = FreeFile
    Open objInizio.DiscoTem + "TEMP" For Binary As ifl
    Put #ifl, 1, a
    Get #ifl, 1, i
    Close #ifl
    Kill objInizio.DiscoTem + "TEMP"
    MKS = i
End Function

