VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
  Persistable = 0  'NotPersistable
  DataBindingBehavior = 0  'vbNone
  DataSourceBehavior  = 0  'vbNone
  MTSTransactionMode  = 0  'NotAnMTSObject
END
Attribute VB_Name = "Anello"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = True
Option Explicit
Public DiamExt As Single
Public DiamInt As Single
Public Spess   As Single
Public Dmant   As Single
Public TipoMat As Integer
Public TipoS   As Integer
'Stringa1$(1) = " Cilindratura laminato"
'Stringa1$(2) = " Anello a settori     "
'Stringa1$(3) = " Da quadrotto         "
'Stringa1$(4) = " Da quadr. con recup. "
'          5    Pads ?
Public diGran  As Single
Public deGran  As Single 'per pads
'----------------------
Public GenMem     As GenMem
Public Variato    As Boolean
Public NumSpicchi As Integer
Public Spicchi    As Spicchi
Public TipOPT     As Integer
'Public TAGLIO     As Single
Private Sviluppo  As Single
Private Altezza   As Single
Private x         As Single
Public Sub StringMATE()
   On Error Resume Next
   GenMem.Materiale = RTrim$(GenMem.MaterNome(1))
   On Error GoTo 0
End Sub
Public Sub leggi(DiscoR As String, Mode As Integer)
   Select Case Mode
     Case 0
   If Not Variato Then Exit Sub
   Call Aggancio(DiscoR)
   GenMem.LeggiMat (TipoMat)
   GenMem.PesiSp (TipoMat)
 '  SovraMet
   GenMem.TAGLIO = GenMem.MargTag(Spess)
   Calcoli
   Pesi
   GenMem.Leggiprezzi Int(Spess), 0, 0
   StringDIME
   StringMATE
   If IUNL < 5 Then CalcGrezzi
   Variato = False
     Case 1
        Set Membro = Me
        frmDati.Show vbModal
   End Select
   SalvaLav
End Sub

Private Sub Class_Initialize()
   Set GenMem = New GenMem
   Set GenMem.Parent = Me
   TipoMat = 1
   Variato = True
End Sub

Private Sub Class_Terminate()
   Set GenMem = Nothing
   Set Spicchi = Nothing
End Sub

Private Sub Calcoli()
Dim DiamMed As Single
Dim y As Single, Z As Single
Dim Alfa As Single, Ris As Integer
On Error GoTo ErrCal
Altezza = (DiamExt - DiamInt) / 2 'altezza anello
DiamMed = (DiamExt + DiamInt) / 2 'diametro medio
If GenMem.TAGLIO >= (Altezza / 2) Then x = (DiamMed / 2) - (GenMem.TAGLIO - (Altezza / 2)) Else x = DiamMed / 2
If GenMem.TAGLIO = 0 Then x = DiamExt / 2: y = DiamExt / 2: Alfa = Pi * 2 ': GoTo 1670
y = DiamMed / 2: Z = Sqr(y * y - x * x)
Alfa = Atn(Z / x)
If Alfa > 0 Then Alfa = (Pi - Alfa) * 2
If Alfa < 0 Then Alfa = Abs(Alfa) * 2
If Alfa = 0 Then Alfa = (Pi * 2)
Sviluppo = (DiamMed / 2) * Alfa 'sviluppo anello
'*************************************************************
If Dmant > 0 Then '  anello per pad
'      If Dmant <= DiamInt And AddDistinta <= 102 Then
'           junk = Alert(4, Stringa1$(7), 4, 3, 11, 65, at1(33), "", "")
'           Diametro mantello inferiore diametro bocchello
'           Gia = True
'           GoTo RifaiDil
'      End If
    diGran = Dmant * asin(DiamInt / Dmant)
    deGran = diGran + 2 * Altezza
Else
    diGran = DiamInt
    deGran = DiamExt
End If
Select Case TipoS
     Case 2
        SpicAn 0
      End Select
ExSub: Exit Sub
ErrCal: Resume ExSub
End Sub
Public Function NumSpic(NumSpicchi As Integer) As Integer
     NumSpicchi = NumSpicGen(False, "Anelli", 0!, NumSpicchi)
     NumSpic = NumSpicchi
End Function
Private Sub SpicAn(Mode As Integer) '(Sp() As LamSpicchi, SPESS As Integer)
Dim nset As Integer, Ris As Integer, Nrisp As Integer
        If Editing And Not Caricamento Then
           nset = NumSpicGen(False, "Anelli", 0!, NumSpicchi)
           If nset < 2 Then nset = 2
           NumSpicchi = nset
        Else
           nset = NumSpicchi
        End If
        Set Spicchi = New Spicchi
'        Alfaa! = Alfa!
'        PesoSp1 = Matdim(0).PSP * EXP9: TF = SPESS
   With Spicchi
      .TAGLIO = GenMem.TAGLIO
      .RG = DiamExt / 2
      .RP = DiamInt / 2
      '.Rcal = Rcal + SpessPar / 2
      '.Rtoro = Rtoro + SpessPar / 2
      '.TipFon = GenMem.Tipo
      '.Piedritto = Piedritto
      '.DM = DM
      .AlfaSvilCon = 2 * Pi
      .Dcal = 0
      .SpessPar = Spess
      .Tcal = 0
      .NumSpicchi = NumSpicchi
      .PesoSp1 = GenMem.PesoSp1
      If Mode = 1 Then
         Ris = .Spicchiatura(nset, TipOPT)
      Else
         .ConEq
         If TipOPT = 0 Then TipOPT = 2
         .ForLam .RG, .RP, .AlfaSvilCon / nset, .TAGLIO, (nset), job.Comm.LargM, job.Comm.LungM, Nrisp, .SP(TipOPT + 1), TipOPT
         .PesoSpicchi
         '.Ottimizza nset, TipOPT
      End If
    End With
End Sub

Private Sub StringDIME()
Dim i As Integer, ifl As Integer, Stringa1(11) As String
Dim DIMR1 As String, NOTE1 As String, DIMR2 As String
ifl = FreeFile
Open RTrim$(Inizio.Archdir) + "\STAM14.DAT" For Input Shared As #ifl
For i = 1 To 11: Line Input #ifl, Stringa1(i): Next
Close #ifl
Select Case TipoS
    Case 1
       DIMR1 = Stringa1(1) + Str$(DiamExt) + Stringa1(2) + LTrim$(Str$(DiamInt)) + Stringa1(3) + LTrim$(Str$(Sviluppo))
       NOTE1 = Stringa1(4) + Str$(Int(Sviluppo + 20)) + Stringa1(5) + Str$(Int(Altezza + 20)) + Stringa1(5) + Str$(Spess)
    Case 2
       DIMR1 = Stringa1(6) + Str$(NumSpicchi) + Stringa1(7) + LTrim$(Str$(Int(DiamExt))) + Stringa1(2) + Mid$(Str$(DiamInt), 2, Len(Str$(DiamInt)) - 1) + Stringa1(3) + LTrim$(Str$(Int(Sviluppo)))
       NOTE1 = Stringa1(8) + Str$(Int(Spicchi.SP(TipOPT + 1)("Rett").Lung)) + Stringa1(5) + Str$(Int(Spicchi.SP(TipOPT + 1)("Rett").LARG)) + Stringa1(5) + Str$(Spess)
    Case 3, 4
       If Dmant > 0 Then
         DIMR1 = Stringa1(9) + Str$(DiamInt) + Stringa1(10) + LTrim$(Str$(Altezza))
         NOTE1 = Stringa1(8) + Str$(Int(DiamExt + 20)) + Stringa1(5) + Str$(Int(deGran + 20)) + Stringa1(5) + Str$(Spess)
       Else 'e
         DIMR1 = Stringa1(1) + Str$(DiamExt) + Stringa1(2) + LTrim$(Str$(DiamInt))
         NOTE1 = Stringa1(8) + Str$(Int(DiamExt + 20)) + Stringa1(5) + Str$(Int(DiamExt + 20)) + Stringa1(5) + Str$(Spess)
       End If
End Select
DIMR2 = Stringa1(11) + LTrim$(Str$(Spess))
GenMem.Dimensioni = DIMR1 + DIMR2
GenMem.Note = NOTE1
End Sub

Public Sub CalcGrezzi()
   Dim grezzo As clsGrezzo1
   GenMem.ClearGrezzi
   GenMem.IniziaGrezzo grezzo
   If grezzo Is Nothing Then Exit Sub
   Select Case TipoS
       Case 1 'cilindrato
          grezzo.Vartxt(1) = "PL  "
          grezzo.Variab(1) = Spess
       Case 2 'a settori
          grezzo.Variab(1) = Spess
          grezzo.Variab(2) = Spicchi.RG
          grezzo.Variab(3) = Spicchi.RP
          grezzo.Dimens(4) = Spicchi.AlfaSvilCon / Spicchi.NumSpicchi
          grezzo.Vartxt(1) = "SP  "
          grezzo.Variab(4) = TipoS
          grezzo.Variab(5) = NumSpicchi
          grezzo.Dimens(1) = Spicchi.SP(TipOPT + 1)("Rett").Lung
          grezzo.Dimens(2) = Spicchi.SP(TipOPT + 1)("Rett").LARG
          grezzo.Dimens(3) = 1 'N. quadri
       Case 3, 4, 5 'da quadrotto
          grezzo.Variab(1) = Spess
          grezzo.Vartxt(1) = "AN  "
          grezzo.Dimens(1) = DiamExt + GenMem.TAGLIO
          If Dmant > 0 Then
            grezzo.Dimens(2) = deGran + GenMem.TAGLIO
          Else 'g
            grezzo.Dimens(2) = grezzo.Dimens(1)
          End If
          grezzo.Dimens(3) = 1 'N.quadri
          grezzo.Dimens(4) = DiamInt
End Select
End Sub

Public Sub sConverti(j As Integer)
      GenMem.sConverti j
      RecordD(j).Dati(1) = DiamExt
      RecordD(j).Dati(2) = DiamInt
      RecordD(j).Dati(3) = Spess
      RecordD(j).Dati(4) = GenMem.TAGLIO
      RecordD(j).Dati(5) = TipoS
      RecordD(j).Dati(6) = Dmant
      RecordD(j).Dati(7) = NumSpicchi
      RecordD(j).Dati(8) = TipOPT
      RecordD(j).posspa.BaricRel.y = Spess / 2
      RecordD(j).posspa.BaricRel.x = 0
      RecordD(j).posspa.BaricRel.Z = 0
End Sub

Public Sub Pesi()
   Dim Altloc As Single
   On Error GoTo ErrP
   GenMem.Pnet0 = Altezza * Sviluppo * Spess * GenMem.PesoSp1
   If Dmant > 0 Then GenMem.Pnet0 = GenMem.Pnet0 * Sqr(diGran / DiamInt)
   Select Case TipoS
     Case 1
        If GenMem.Classe1 = 3 Then Altloc = Altezza - 20 Else Altloc = Altezza
        GenMem.plor0 = (Altloc + 20) * (Sviluppo + 20) * Spess * GenMem.PesoSp1
     Case 2
        ' LAM1 = Sp(Tipo).Rett.Larg: LAM2 = Sp(Tipo).Rett.Lung
        GenMem.plor0 = Spicchi.SP(TipOPT + 1)(peso) 'LAM1 * LAM2 * Spess * Matdim(0).PSP * EXP9
        ' NSET = NSPI
     Case 3
         If Dmant > 0 Then
            GenMem.plor0 = (DiamExt + 20) * (deGran + 20) * Spess * GenMem.PesoSp1
         Else 'd
            GenMem.plor0 = (DiamExt / 2 + x + 20) * (DiamExt + 20) * Spess * GenMem.PesoSp1
         End If
      Case 4
            GenMem.plor0 = ((DiamExt / 2 + x + 20) * (DiamExt + 20) - ((DiamInt - 20) ^ 2 * (Pi / 4))) * Spess * GenMem.PesoSp1
      Case 5
            GenMem.plor0 = (DiamExt + 20) * (deGran + 20) * Spess * GenMem.PesoSp1
      End Select
      GenMem.Pnet0 = GenMem.Pnet0 * EXP9
      GenMem.plor0 = GenMem.plor0 * EXP9
      GenMem.Psfri0 = GenMem.plor0 - GenMem.Pnet0
      'GenMem.Converti
      GenMem.PNET = GenMem.Pnet0
ExSub:      Exit Sub
ErrP:      Resume ExSub
End Sub
Public Function Convalida() As Integer
   Convalida = True
End Function
Public Sub Converti(jRec As Integer)
     GenMem.ConvertiPos jRec
     DiamExt = RecordD(jRec).Dati(1)
     DiamInt = RecordD(jRec).Dati(2)
     Spess = RecordD(jRec).Dati(3)
     GenMem.TAGLIO = RecordD(jRec).Dati(4)
     TipoS = RecordD(jRec).Dati(5)
     Dmant = RecordD(jRec).Dati(6)
     NumSpicchi = RecordD(jRec).Dati(7)
     TipOPT = RecordD(jRec).Dati(8)
End Sub

Public Sub Copia(a As Anello)
If a Is Nothing Then Set a = New Anello
a.DiamExt = DiamExt
a.DiamInt = DiamInt
a.Spess = Spess
a.Dmant = Dmant
a.TipoMat = TipoMat
a.TipoS = TipoS
a.diGran = diGran
a.deGran = deGran
a.TipOPT = TipOPT
a.GenMem.TAGLIO = GenMem.TAGLIO
a.NumSpicchi = NumSpicchi
GenMem.Copia a.GenMem
Set a.GenMem.Parent = a
Spicchi.Copia a.Spicchi
End Sub
Public Sub Mostrasviluppi()
   Select Case TipoS
     Case 2
        '   IUNL = 0
           If NumSpicchi > 1 Then ShowLam Spicchi.SP, 5, TipOPT
           If NumSpicchi = 1 Then TipOPT = 0: ShowLam Spicchi.SP, 0, TipOPT
     Case 5
     Call ShowPad(Int(DiamExt), Int(DiamInt), Dmant)
   End Select
End Sub
Public Property Get Code7() As Integer
   Code7 = 0 'If GenMem.Classe1 = 7 Then Code7 = 2 Else Code7 = 0
End Property
Public Property Let Code7(ByVal vNewValue As Integer)

End Property
Public Property Get Param1() As Single
   Param1 = Spess
End Property
Public Property Let Param1(ByVal vNewValue As Single)

End Property

