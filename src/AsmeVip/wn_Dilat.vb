Option Strict Off
Option Explicit On
Imports System.Runtime.InteropServices
Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary 'Namespace for BinaryFormatter
Friend Class wn_Dilat
    Private Structure strCiclo
        Dim s As Single
        Dim Cond1 As Short
        Dim Cond2 As Short
        Dim nCicli As Short
        Dim Danno As Single
    End Structure
    Private Structure Graf
        <VBFixedArray(13)> Dim Valor() As Single
        Public Sub Initialize()
            ReDim Valor(13)
        End Sub
    End Structure
    <Serializable(), StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> Private Structure DilGeom
        Dim TE As Single
        Dim ra As Single
        Dim rb As Single
        Dim g As Single
        Dim id As Single
        Dim ts As Single
        'UPGRADE_NOTE: to è stato aggiornato a to_Renamed. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1061"'
        Dim to_Renamed As Single
        Dim fa As Single
        Dim fb As Single
        Dim li As Single
        Dim lo As Single
        Dim nOnde As Short
        Dim nPli As Short
    End Structure
    <Serializable(), StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> Private Structure DilEqui
        Dim ta As Single
        Dim tb As Single
        Dim a As Single
        Dim b As Single
        Dim la As Single
        Dim lb As Single
        Dim ya As Single
        Dim yb As Single
        Dim W As Single
    End Structure
    <Serializable(), StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> Private Structure DilProg
        Dim temp As Single
        Dim Classe As Short
        Dim Sigma As Single
        Dim sY As Single
        Dim PT As Single
        Dim Ptp As Single
        Dim Ps As Single
        Dim PSP As Single
        Dim Pd As Single
        Dim ES As Single
        Dim Eo As Single
        Dim Ea As Single
        Dim Eb As Single
        Dim EE As Single
        Dim Corr As Single
    End Structure
    <Serializable(), StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> Private Structure DilFlex
        Dim betaa As Single
        Dim betab As Single
        Dim Da As Single
        Dim db As Single
        Dim DE As Single
        <VBFixedArray(1), MarshalAs(UnmanagedType.ByValArray, SizeConst:=2)> Dim Omega() As Single
        <VBFixedArray(1, 1), MarshalAs(UnmanagedType.ByValArray, SizeConst:=4)> Dim j(,) As Single
        <VBFixedArray(1), MarshalAs(UnmanagedType.ByValArray, SizeConst:=2)> Dim Z() As Single
        <VBFixedArray(3, 1), MarshalAs(UnmanagedType.ByValArray, SizeConst:=8)> Dim k(,) As Single
        <VBFixedArray(1), MarshalAs(UnmanagedType.ByValArray, SizeConst:=2)> Dim E() As Single
        <VBFixedArray(1), MarshalAs(UnmanagedType.ByValArray, SizeConst:=2)> Dim y() As Single
        <VBFixedArray(7), MarshalAs(UnmanagedType.ByValArray, SizeConst:=8)> Dim x() As Single
        Dim xx As Single
        Dim g As Single
        Dim c As Single
        Dim d As Single
        Dim q1 As Single
        Dim q2 As Single
        Dim q3 As Single
        Dim m1 As Single
        Dim m2 As Single
        Dim m3 As Single
        Dim Sj As Single
        Public Sub Initialize()
            ReDim Omega(1)
            ReDim j(2, 2)
            ReDim Z(1)
            ReDim k(3, 1)
            ReDim E(1)
            ReDim y(1)
            ReDim x(7)
        End Sub
    End Structure
    <Serializable(), StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> Private Structure DilStre
        <VBFixedArray(8), MarshalAs(UnmanagedType.ByValArray, SizeConst:=9)> Dim Fax() As Single
        Dim Ma As Single
        Dim Mb As Single
        Dim sb As Single
        Dim Sm As Single
        Dim Scl As Single
        Public Sub Initialize()
            ReDim Fax(8)
        End Sub
    End Structure
    Private Structure strIntermStress
        Dim Za As Single
        Dim Zb As Single
        Dim thetaa As Single
        Dim thetab As Single
        Dim R() As Single
        Dim Smm() As Single
        Dim Scm() As Single
        Dim Smb() As Single
        Dim chi(,) As Single
        Dim delta() As Single
        Dim B1() As Single
        Dim B2() As Single
        Dim v1(,) As Single
        Dim v2(,) As Single
        Dim Sm(,) As Single
        Dim v2s(,) As Single
        Dim sb(,) As Single
        Dim t(,) As Single
        Dim T1() As Single
        Dim Scl() As Single
        Dim Ciclallow As Single
        Public Sub Initialize()
            ReDim R(3)
            ReDim Smm(7)
            ReDim Scm(7)
            ReDim Smb(7)
            ReDim chi(2, 2)
            ReDim delta(2)
            ReDim B1(2)
            ReDim B2(2)
            ReDim v1(2, 2)
            ReDim v2(2, 2)
            ReDim Sm(2, 2)
            ReDim v2s(2, 2)
            ReDim sb(2, 2)
            ReDim t(2, 2)
            ReDim T1(2)
            ReDim Scl(2)
        End Sub
    End Structure
    <Serializable(), StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> Private Structure Risult
        <VBFixedArray(6), MarshalAs(UnmanagedType.ByValArray, SizeConst:=7)> Dim Sm() As Single
        <VBFixedArray(6), MarshalAs(UnmanagedType.ByValArray, SizeConst:=7)> Dim sb() As Single
        <VBFixedArray(6), MarshalAs(UnmanagedType.ByValArray, SizeConst:=7)> Dim Smmp() As Single
        <VBFixedArray(6), MarshalAs(UnmanagedType.ByValArray, SizeConst:=7)> Dim Scmp() As Single
        <VBFixedArray(6), MarshalAs(UnmanagedType.ByValArray, SizeConst:=7)> Dim Smbp() As Single
        <VBFixedArray(6), MarshalAs(UnmanagedType.ByValArray, SizeConst:=7)> Dim Fmmp() As Single
        <VBFixedArray(6), MarshalAs(UnmanagedType.ByValArray, SizeConst:=7)> Dim Fcmp() As Single
        <VBFixedArray(6), MarshalAs(UnmanagedType.ByValArray, SizeConst:=7)> Dim Fmbp() As Single
        Dim Salt As Single
        Public Sub Initialize()
            ReDim Sm(6)
            ReDim sb(6)
            ReDim Smmp(6)
            ReDim Scmp(6)
            ReDim Smbp(6)
            ReDim Fmmp(6)
            ReDim Fcmp(6)
            ReDim Fmbp(6)
        End Sub
    End Structure
    <Serializable(), StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> Private Structure strDilat
        <MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef:=GetType(DilProg))> Dim DilProg As DilProg
        <MarshalAs(UnmanagedType.CustomMarshaler, marshaltyperef:=GetType(DilGeom))> Dim DilGeom As DilGeom
        <MarshalAs(UnmanagedType.CustomMarshaler, marshaltyperef:=GetType(DilEqui))> Dim DilEqui As DilEqui
        <MarshalAs(UnmanagedType.CustomMarshaler, marshaltyperef:=GetType(DilFlex))> Dim DilFlex As DilFlex
        <MarshalAs(UnmanagedType.CustomMarshaler, marshaltyperef:=GetType(DilStre))> Dim DilStre As DilStre
        <MarshalAs(UnmanagedType.CustomMarshaler, marshaltyperef:=GetType(Risult))> Dim Risult1 As Risult
        <MarshalAs(UnmanagedType.CustomMarshaler, marshaltyperef:=GetType(Risult))> Dim Risult2 As Risult
        <MarshalAs(UnmanagedType.CustomMarshaler, marshaltyperef:=GetType(Risult))> Dim Risult3 As Risult
        <MarshalAs(UnmanagedType.CustomMarshaler, marshaltyperef:=GetType(Risult))> Dim Risult4 As Risult
        <MarshalAs(UnmanagedType.CustomMarshaler, marshaltyperef:=GetType(Risult))> Dim Risult5 As Risult
        <MarshalAs(UnmanagedType.CustomMarshaler, marshaltyperef:=GetType(Risult))> Dim Risult6 As Risult
        <MarshalAs(UnmanagedType.CustomMarshaler, marshaltyperef:=GetType(Risult))> Dim Risult7 As Risult
        <MarshalAs(UnmanagedType.CustomMarshaler, marshaltyperef:=GetType(Risult))> Dim Risult8 As Risult
        <MarshalAs(UnmanagedType.CustomMarshaler, marshaltyperef:=GetType(Risult))> Dim Risult9 As Risult
        <MarshalAs(UnmanagedType.CustomMarshaler, marshaltyperef:=GetType(Risult))> Dim Risult10 As Risult
        <MarshalAs(UnmanagedType.CustomMarshaler, marshaltyperef:=GetType(Risult))> Dim Risult11 As Risult
        <MarshalAs(UnmanagedType.CustomMarshaler, marshaltyperef:=GetType(Risult))> Dim Risult12 As Risult
        <MarshalAs(UnmanagedType.CustomMarshaler, marshaltyperef:=GetType(Risult))> Dim Risult13 As Risult
        <MarshalAs(UnmanagedType.CustomMarshaler, marshaltyperef:=GetType(Risult))> Dim Risult14 As Risult
        <MarshalAs(UnmanagedType.CustomMarshaler, marshaltyperef:=GetType(Risult))> Dim Risult15 As Risult
        <MarshalAs(UnmanagedType.CustomMarshaler, marshaltyperef:=GetType(Risult))> Dim Risult16 As Risult
        '<VBFixedArray(16)> Dim Risult() As Risult
        Dim k As Single 'stiffness multiplier per 8.5
        Dim gammaa As Single
        Dim gammab As Single
        Dim rule8 As Short
        Dim m As Single
        Dim mo As Single
        Dim mo1 As Single
        Dim mo2 As Single
        Dim lambda As Single
        Dim alpha As Single
        <VBFixedString(190), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=190)> Dim Pad As String
        Public Property Risult(ByVal i As Short) As Risult
            Get
                Select Case i
                    Case 1 : Return Risult1
                    Case 2 : Return Risult2
                    Case 3 : Return Risult3
                    Case 4 : Return Risult4
                    Case 5 : Return Risult5
                    Case 6 : Return Risult6
                    Case 7 : Return Risult7
                    Case 8 : Return Risult8
                    Case 9 : Return Risult9
                    Case 10 : Return Risult10
                    Case 11 : Return Risult11
                    Case 12 : Return Risult12
                    Case 13 : Return Risult13
                    Case 14 : Return Risult14
                    Case 15 : Return Risult15
                    Case 16 : Return Risult16
                    Case Else : Return Nothing
                End Select
            End Get
            Set(ByVal Value As Risult)
                Select Case i
                    Case 1 : Risult1 = Value
                    Case 2 : Risult2 = Value
                    Case 3 : Risult3 = Value
                    Case 4 : Risult4 = Value
                    Case 5 : Risult5 = Value
                    Case 6 : Risult6 = Value
                    Case 7 : Risult7 = Value
                    Case 8 : Risult8 = Value
                    Case 9 : Risult9 = Value
                    Case 10 : Risult10 = Value
                    Case 11 : Risult11 = Value
                    Case 12 : Risult12 = Value
                    Case 13 : Risult13 = Value
                    Case 14 : Risult14 = Value
                    Case 15 : Risult15 = Value
                    Case 16 : Risult16 = Value
                End Select

            End Set
        End Property
        Public Sub Initialize()
            DilFlex.Initialize()
            DilStre.Initialize()
            Risult1.Initialize()
            Risult2.Initialize()
            Risult3.Initialize()
            Risult4.Initialize()
            Risult5.Initialize()
            Risult6.Initialize()
            Risult7.Initialize()
            Risult8.Initialize()
            Risult9.Initialize()
            Risult10.Initialize()
            Risult11.Initialize()
            Risult12.Initialize()
            Risult13.Initialize()
            Risult14.Initialize()
            Risult15.Initialize()
            Risult16.Initialize()
            Pad = New String(" "c, 190)
        End Sub
    End Structure
    Public OptimDil As Boolean
    Public lKlato, lJinvolucr As Short
    Private IndObj As Short
    Private c(8, 2, 4) As Single
    Private Dilat(6) As strDilat
    Private IntermStress(6, 8) As strIntermStress
    Private Ciclo(2, 16) As strCiclo
    Private nCicli(2) As Short
    Private rac, rau, rbu, rbc As Single
    Private SpessCB As Single
    Private cc, Ome, Dbeta, d As Single
    Private gstar, g, rx As Single
    Private Para1, rst, rsh, Para2 As Single
    Private xxx1, xxx2 As Single
    Private File, Testo As String
    Private Sigma As Single
    Private iX, k, iy As Short
    Private K2, kk As Short
    Private a, Ak As Single
    Private i, ii As Short
    Private iEnd, iStart, Ind1, Ind2 As Short
    Private Rig, Rig1 As String
    Private O As wn_FTC
    Private TIMA As String
    Private rstv(4) As Single
    Private rshv(4) As Single
    Public Function EjmaGraf(ByRef iDilat As Short, ByRef iCod As Short) As Single
        Dim Grafprima, GrafZ1, Grafdopo As Graf
        Dim j, ifl, k, i As Short
        Dim ya, Z0, Z1, yb As Single
        Dim a As String
        Dim y1, x1, x2, y2 As Single
        Grafprima.Initialize()
        GrafZ1.Initialize()
        Grafdopo.Initialize()
        Z0 = Dilat(iDilat).DilEqui.ya
        Z1 = Dilat(iDilat).DilEqui.yb
        If Z0 > 1 Or Z0 < 0 Or Z1 > 4 Or Z1 < 0.2 Then
            a = " Parametri geometrici fuori curva"
            'a$ = a$ + " una lista dei valori possibili. Cio' | vale in particolare per i materiali.|"
            MessageBox.Show(a)
            EjmaGraf = 0 : Exit Function
        End If
        ifl = FreeFile()
        FileOpen(ifl, RTrim(Monitor.Motore.Inizio.Archdir) & "\WN5\EJMAGRAF.FTC", OpenMode.Random, , OpenShare.Shared, Len(GrafZ1))
        FileGet(ifl, GrafZ1, 1)
        k = 11 - Int(10 * Z0) : If k = 1 Then k = 2
        j = 1 + (iCod - 1) * 11 + k
        FileGet(ifl, Grafprima, j)
        FileGet(ifl, Grafdopo, j - 1)
        FileClose(ifl)
        For i = 1 To 13
            If GrafZ1.Valor(i) < Z1 Then
                x1 = GrafZ1.Valor(i) : x2 = GrafZ1.Valor(i - 1)
                y1 = Grafprima.Valor(i) : y2 = Grafprima.Valor(i - 1)
                If iCod = 1 Then
                    ya = y1 + (Z1 - x1) / (x2 - x1) * (y2 - y1)
                Else
                    ya = GlobalRoutines.InterLogar(Z1, x1, x2, y1, y2)
                End If
                y1 = Grafdopo.Valor(i) : y2 = Grafdopo.Valor(i - 1)
                If iCod = 1 Then
                    yb = y1 + (Z1 - x1) / (x2 - x1) * (y2 - y1)
                Else
                    yb = GlobalRoutines.InterLogar(Z1, x1, x2, y1, y2)
                End If
                EjmaGraf = (ya + (Z0 - (11 - k) / 10) * (yb - ya) / 0.1) / 1000
                Exit Function
            End If
        Next
    End Function
    Sub FlexDilat(ByRef TipoDilat As Short)
        Dim i2, i1, ii As Short
        Dim i As Short
        Dim ifl As Short
        On Error GoTo ErrDilat
        O = CType(CType(objMemb(Involucr(kLato, jInvolucr).IndObject), wn_PT).Piastra, wn_FTC)
        If TipoDilat > 2 And TipoDilat < 6 Then
            Call FlexEjma(TipoDilat)
            Exit Sub
        ElseIf TipoDilat = 7 Then
            Dilat(1).DilFlex.Sj = O.Zp(0, 36)
            Dilat(2).DilFlex.Sj = O.Zp(0, 37)
            Exit Sub
        End If
        i1 = 1 : i2 = 2
        CalcFlex(i1, i2)
        If TipoDilat > 1 Or Dilat(1).DilGeom.nOnde = 1 Then Exit Sub
        For ii = 1 To 2 : Dilat(ii).DilFlex.Sj = Dilat(ii).DilFlex.Sj * Dilat(ii).DilGeom.nOnde : Next
        i1 = 3 : i2 = 4
        CalcFlex(i1, i2)
        For ii = 3 To 4
            Dilat(ii).DilFlex.Sj = Dilat(ii).DilFlex.Sj * Dilat(ii).DilGeom.nOnde
            Dilat(ii - 2).DilFlex.Sj = 1 / (1 / Dilat(ii - 2).DilFlex.Sj + 1 / Dilat(ii).DilFlex.Sj * (Dilat(ii - 2).DilGeom.nOnde - 1))
        Next
        Exit Sub
ErrDilat:
        Testo = "Si è prodotto l'errore '" & Err.Description & "' in FlexDilat" & vbCrLf
        Testo = Testo & "Generalmente ciò accade quanto i dati relativi al dilatatore" & vbCrLf
        Testo = Testo & "non sono completi, o non si è indicato nei dati del fascio tubiero" & vbCrLf
        Testo = Testo & "il dilatatore ad esso accoppiato."
        MessageBox.Show(Testo, "AsmeVip", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Dilat(1).DilFlex.Sj = 0
        Dilat(2).DilFlex.Sj = 0
    End Sub
    Private Sub RCB852(ByVal ii As Integer)
        rx = Dilat(ii).DilGeom.g / Dilat(ii).DilGeom.TE
        If rx < 160 Then
            Dilat(ii).alpha = 4.3 * rx ^ -0.287
        Else
            Dilat(ii).alpha = 2.92 * rx ^ -0.211
        End If
    End Sub
    Private Sub RCB854(ByVal ii As Integer)
        rx = Dilat(ii).DilGeom.g / Dilat(ii).DilGeom.TE
        If rx < 160 Then
            Dilat(ii).lambda = 2.13 * rx ^ -0.149
        Else
            Dilat(ii).lambda = 1.86 * rx ^ -0.122
        End If
    End Sub
    Private Sub CalcFlex(ByVal i1 As Integer, ByVal i2 As Integer)
        rau = Dilat(1).DilGeom.ra
        rbu = Dilat(1).DilGeom.rb
        rac = Dilat(2).DilGeom.ra
        rbc = Dilat(2).DilGeom.rb
        Dim ii As Integer
        For ii = i1 To i2
            With Dilat(ii)
                .DilProg.Ea = .DilProg.EE
                If .DilGeom.ra = 0 Then .DilProg.Ea = .DilProg.ES
                .DilProg.Eb = .DilProg.EE
                If .DilGeom.rb = 0 Then .DilProg.Eb = .DilProg.Eo
100:            .DilFlex.betaa = 1.285 / System.Math.Sqrt(.DilEqui.a * .DilEqui.ta) * inc
                .DilFlex.betab = 1.285 / System.Math.Sqrt(.DilEqui.b * .DilEqui.tb) * inc
                .DilFlex.Da = 0.0916 * .DilProg.Ea * (.DilEqui.ta / inc) ^ 3
                .DilFlex.db = 0.0916 * .DilProg.Eb * (.DilEqui.tb / inc) ^ 3
                .DilFlex.DE = 0.0916 * .DilProg.EE * (.DilGeom.TE / inc) ^ 3
                '    .DilFlex.Omega(1) = 2 * .DilFlex.betaa * .DilEqui.ya / inc
                '    .DilFlex.Omega(2) = 2 * .DilFlex.betab * .DilEqui.yb / inc
                .DilFlex.Omega(1 - 1) = .DilFlex.betaa * .DilEqui.ya / inc 'ed8th
                .DilFlex.Omega(2 - 1) = .DilFlex.betab * .DilEqui.yb / inc 'ed8th
                Dim i As Integer
                For i = 1 To 2
200:                Ome = .DilFlex.Omega(i - 1)
                    .DilFlex.j(1 - 1, i - 1) = System.Math.Sin(Ome) * (System.Math.Exp(Ome) - System.Math.Exp(-Ome)) / 2 'ed8th
                    .DilFlex.j(2 - 1, i - 1) = System.Math.Cos(Ome) * (System.Math.Exp(Ome) + System.Math.Exp(-Ome)) / 2 'ed8th
                    .DilFlex.Z(i - 1) = .DilFlex.j(1 - 1, i - 1) ^ 2 + .DilFlex.j(2 - 1, i - 1) ^ 2
                    .DilFlex.k(0, i - 1) = (System.Math.Exp(Ome) - System.Math.Exp(-Ome)) / 2 + System.Math.Sin(Ome)
                    .DilFlex.k(1, i - 1) = ((System.Math.Exp(Ome) + System.Math.Exp(-Ome)) / 2 + System.Math.Cos(Ome)) / .DilFlex.k(0, i - 1)
                    .DilFlex.k(2, i - 1) = ((System.Math.Exp(Ome) - System.Math.Exp(-Ome)) / 2 - System.Math.Sin(Ome)) / .DilFlex.k(0, i - 1)
                    .DilFlex.k(3, i - 1) = ((System.Math.Exp(Ome) + System.Math.Exp(-Ome)) / 2 - System.Math.Cos(Ome)) / .DilFlex.k(0, i - 1)
                    If i = 1 Then
                        c(1, i, ii) = .DilEqui.la / System.Math.Sqrt(.DilEqui.a * .DilEqui.ta)
                        c(2, i, ii) = .DilGeom.ts / .DilEqui.ta
                        c(3, i, ii) = .DilProg.Ea / .DilProg.ES
                        'If .DilGeom.li = 0 Then c(2, i, ii) = 1: c(3, i, ii) = 1
                    Else
                        c(1, i, ii) = .DilEqui.lb / System.Math.Sqrt(.DilEqui.b * .DilEqui.tb)
                        c(2, i, ii) = .DilGeom.to_Renamed / .DilEqui.tb
                        c(3, i, ii) = .DilProg.Eb / .DilProg.Eo
                        'If .DilGeom.lo = 0 Then c(2, i, ii) = 1: c(3, i, ii) = 1
                    End If
                    If c(2, i, ii) = 1.0! And c(3, i, ii) = 1.0! Then
                        .DilFlex.E(i - 1) = 1
                    Else
300:                    If c(1, i, ii) < 0.4 Then c(1, i, ii) = 0.4
                        'Stop
                        If c(2, i, ii) < 1 Then
310:                        c(4, i, ii) = -0.364661 + 0.338172 / c(2, i, ii) - 0.0366351 / c(2, i, ii) ^ 2
                            c(5, i, ii) = -1.06871 + 1.01164 / c(2, i, ii) - 0.122627 / c(2, i, ii) ^ 2
                            c(6, i, ii) = 0.0696709 + 1.76415 * c(2, i, ii) - 5.46103 * c(2, i, ii) ^ 3
                            c(7, i, ii) = -0.142734 + 0.918656 * c(2, i, ii) - 2.00749 * c(2, i, ii) ^ 3
                        Else
320:                        c(4, i, ii) = (3.3731 - 1.707962 * c(2, i, ii) + 0.226216 * c(2, i, ii) ^ 2) / 1000
                            c(5, i, ii) = -0.403287 + 0.320037 * c(2, i, ii) - 0.0307508 * c(2, i, ii) ^ 2
                            c(6, i, ii) = -0.684978 + 0.582549 * c(2, i, ii) - 0.0547812 * c(2, i, ii) ^ 2
                            c(7, i, ii) = -0.201334 + 0.168201 * c(2, i, ii) - 0.015728 * c(2, i, ii) ^ 2
                        End If
330:                    c(8, i, ii) = (c(5, i, ii) / c(1, i, ii) ^ 2 - c(6, i, ii) / c(1, i, ii) ^ 3 + c(7, i, ii) / c(1, i, ii) ^ 4 - c(4, i, ii)) / c(3, i, ii) ^ 0.2
331:                    .DilFlex.E(i - 1) = System.Math.Exp(c(8, i, ii))
332:                    If c(2, i, ii) <= 1 Then If .DilFlex.E(i - 1) < 1 Then .DilFlex.E(i - 1) = 1
                        If c(2, i, ii) > 1 Then If .DilFlex.E(i - 1) > 1 Then .DilFlex.E(i - 1) = 1
                    End If
                    On Error GoTo 0
                    If i = 1 Then Dbeta = .DilFlex.Da * .DilFlex.betaa Else Dbeta = .DilFlex.db * .DilFlex.betab
340:                .DilFlex.y(i - 1) = .DilFlex.E(i - 1) / Dbeta * (.DilFlex.k(3, i - 1) - .DilFlex.k(2, i - 1) ^ 2 / 2 / .DilFlex.k(1, i - 1))
                Next
400:            cc = .DilEqui.a ^ 2 / (.DilEqui.b ^ 2 - .DilEqui.a ^ 2)
                d = .DilEqui.b / .DilEqui.a
                .DilFlex.x(1 - 1) = -.DilEqui.a * cc * (0.769 + 1.428 * d ^ 2) / .DilFlex.DE / inc
                .DilFlex.x(2 - 1) = 2.2 * .DilEqui.a * cc * d ^ 2 / .DilFlex.DE / inc
                .DilFlex.x(3 - 1) = -(.DilEqui.a / inc) ^ 2 * (1.538 + System.Math.Log(d) * (2 + cc * (2 + 3.71 * d * d))) / 4 / .DilFlex.DE
                .DilFlex.x(4 - 1) = -2.2 * .DilEqui.b * cc / .DilFlex.DE / inc
                .DilFlex.x(5 - 1) = .DilEqui.b * cc * (0.769 * d * d + 1.428) / .DilFlex.DE / inc
                .DilFlex.x(6 - 1) = -.DilEqui.a * .DilEqui.b * (1.538 + 5.714 * cc * System.Math.Log(d)) / 4 / .DilFlex.DE / inc / inc
450:            .DilFlex.xx = (.DilFlex.x(1 - 1) - .DilFlex.y(1 - 1)) * (.DilFlex.x(5 - 1) + .DilFlex.y(2 - 1)) - .DilFlex.x(2 - 1) * .DilFlex.x(4 - 1)
                .DilFlex.x(7 - 1) = (.DilFlex.x(2 - 1) * .DilFlex.x(6 - 1) - .DilFlex.x(3 - 1) * .DilFlex.x(5 - 1) - .DilFlex.x(3 - 1) * .DilFlex.y(2 - 1)) / .DilFlex.xx
                .DilFlex.x(8 - 1) = (.DilFlex.x(3 - 1) * .DilFlex.x(4 - 1) - .DilFlex.x(1 - 1) * .DilFlex.x(6 - 1) + .DilFlex.x(6 - 1) * .DilFlex.y(1 - 1)) / .DilFlex.xx
                .DilFlex.q1 = (0.385 * .DilEqui.a ^ 2 + 1.429 * .DilEqui.b ^ 2 * cc * System.Math.Log(d)) / inc / inc
                .DilFlex.q2 = -(0.385 * .DilEqui.b ^ 2 + 1.429 * .DilEqui.b ^ 2 * cc * System.Math.Log(d)) / inc / inc
                .DilFlex.q3 = 0.25 * .DilEqui.a * .DilEqui.b ^ 2 * (1.269 / cc / d / d + 3.714 * cc * System.Math.Log(d) ^ 2) / inc ^ 3
500:            g = .DilEqui.a / .DilEqui.b
                gstar = g ^ 4 / (1 - g ^ 2) * System.Math.Log(g)
                .DilFlex.m1 = 0.51 - 0.635 * g * g + gstar
                .DilFlex.m2 = 0.635 * (1 - g * g) + gstar
                .DilFlex.m3 = 2.357 * g * g + 3.714 * gstar
                .DilFlex.g = g
                .DilFlex.c = cc
                .DilFlex.d = d
                rx = .DilEqui.ya / .DilGeom.g
                If rx >= 0.075 Then
                    .gammaa = 1
                Else
                    .gammaa = 0.961 - 11.293 * rx + 450.903 * rx * rx - 5647 * rx * rx * rx + 23140 * rx * rx * rx * rx
                End If
                rx = .DilEqui.yb / .DilGeom.g
                If rx >= 0.075 Then
                    .gammab = 1
                Else
                    .gammab = 0.961 - 11.293 * rx + 450.903 * rx * rx - 5647 * rx * rx * rx + 23140 * rx * rx * rx * rx
                End If
                .m = 0 : .mo = 0 : .mo1 = 0 : .mo2 = 0 : .alpha = 0 : .lambda = 0
                If .DilGeom.ra = 0 And .DilGeom.rb = 0 Then
                    .rule8 = 56
                    .k = .gammaa * .gammab
                ElseIf .DilGeom.ra > 0 And .DilGeom.rb = 0 Then
                    .rule8 = 55
                    File = RTrim(Monitor.Motore.Inizio.Archdir) & "\WR\RCB851.DAT"
                    rst = (.DilGeom.ra + .DilGeom.TE / 2) / .DilEqui.ta
                    rsh = (.DilGeom.ra + .DilGeom.TE / 2) / (.DilEqui.b - .DilEqui.a)
                    Call GlobalRoutines.LegFig(File, rst, rsh, Para1, Para2, xxx1, xxx2, 3)
                    .m = xxx1 + (xxx2 - xxx1) * (rst - Para1) / (Para2 - Para1)
                    RCB852(ii)
                    File = RTrim(Monitor.Motore.Inizio.Archdir) & "\WR\RCB852.DAT"
                    Call GlobalRoutines.LegFig(File, rst, rsh, Para1, Para2, xxx1, xxx2, 3)
                    .mo = xxx1 + (xxx2 - xxx1) * (rst - Para1) / (Para2 - Para1)
                    RCB854(ii)
                    .k = (.alpha * .m * .lambda * .mo * .gammaa * .gammab) / (.lambda * .mo - .alpha * .m + .alpha * .m * .lambda * .mo)
                ElseIf .DilGeom.ra = 0 And .DilGeom.rb > 0 Then
                    .rule8 = 54
                    File = RTrim(Monitor.Motore.Inizio.Archdir) & "\WR\RCB852.DAT"
                    rst = (.DilGeom.rb + .DilGeom.TE / 2) / .DilEqui.tb
                    rsh = (.DilGeom.rb + .DilGeom.TE / 2) / (.DilEqui.b - .DilEqui.a)
                    Call GlobalRoutines.LegFig(File, rst, rsh, Para1, Para2, xxx1, xxx2, 3)
                    .m = xxx1 + (xxx2 - xxx1) * (rst - Para1) / (Para2 - Para1)
                    RCB854(ii)
                    .k = .lambda * .m * .gammaa * .gammab
                ElseIf .DilGeom.ra > 0 And .DilGeom.rb > 0 And rac = rbc And rau = rbu Then
                    .rule8 = 52
                    File = RTrim(Monitor.Motore.Inizio.Archdir) & "\WR\RCB851.DAT"
                    rst = (.DilGeom.rb + .DilGeom.TE / 2) / .DilEqui.tb
                    rsh = (.DilGeom.rb + .DilGeom.TE / 2) / (.DilEqui.b - .DilEqui.a)
                    If rst <> rstv(ii) Or rsh <> rshv(ii) Then
                        Call GlobalRoutines.LegFig(File, rst, rsh, Para1, Para2, xxx1, xxx2, 3)
                        .m = xxx1 + (xxx2 - xxx1) * (rst - Para1) / (Para2 - Para1)
                    End If
                    RCB852(ii)
                    .k = .alpha * .m * .gammaa * .gammab
                Else
                    .rule8 = 53
                    File = RTrim(Monitor.Motore.Inizio.Archdir) & "\WR\RCB852.DAT"
                    rst = (.DilGeom.rb + .DilGeom.TE / 2) / .DilEqui.tb
                    rsh = (.DilGeom.rb + .DilGeom.TE / 2) / (.DilEqui.b - .DilEqui.a)
                    Call GlobalRoutines.LegFig(File, rst, rsh, Para1, Para2, xxx1, xxx2, 3)
                    .mo1 = xxx1 + (xxx2 - xxx1) * (rst - Para1) / (Para2 - Para1)
                    File = RTrim(Monitor.Motore.Inizio.Archdir) & "\WR\RCB851.DAT"
                    rst = (.DilGeom.ra + .DilGeom.TE / 2) / .DilEqui.ta
                    rsh = (.DilGeom.ra + .DilGeom.TE / 2) / (.DilEqui.b - .DilEqui.a)
                    Call GlobalRoutines.LegFig(File, rst, rsh, Para1, Para2, xxx1, xxx2, 3)
                    .m = xxx1 + (xxx2 - xxx1) * (rst - Para1) / (Para2 - Para1)
                    File = RTrim(Monitor.Motore.Inizio.Archdir) & "\WR\RCB852.DAT"
                    rst = (.DilGeom.ra + .DilGeom.TE / 2) / .DilEqui.ta
                    rsh = (.DilGeom.ra + .DilGeom.TE / 2) / (.DilEqui.b - .DilEqui.a)
                    Call GlobalRoutines.LegFig(File, rst, rsh, Para1, Para2, xxx1, xxx2, 3)
                    .mo2 = xxx1 + (xxx2 - xxx1) * (rst - Para1) / (Para2 - Para1)
                    RCB852(ii)
                    .k = .alpha * .m * .mo1 * .gammaa * .gammab / .mo2
                End If
                'Sj in lb/in
                .DilFlex.Sj = .k * 2 * pi * .DilEqui.a * .DilFlex.DE / (.DilFlex.x(7 - 1) * .DilFlex.q1 + .DilFlex.x(8 - 1) * .DilFlex.q2 + .DilFlex.q3) / inc / 2 / .DilGeom.nOnde
            End With
        Next ii
    End Sub
    Sub FlexEjma(ByRef TipoDilat As Short)
        Dim ii As Short
        Dim Cf, Dm, Cr As Single
        Dim Q As Single
        With CType(CType(objMemb(Involucr(kLato, jInvolucr).IndObject), wn_PT).Piastra, wn_FTC)
            For ii = 1 To 2
                Dilat(ii).DilProg.Ps = .Zp(0, 1)
1000:           Dm = (Dilat(ii).DilGeom.g + Dilat(ii).DilEqui.W + Dilat(ii).DilGeom.TE * Dilat(ii).DilGeom.nPli) / inc
                Cf = EjmaGraf(ii, 2)
                If Cf = 0 Then Dilat(ii).DilFlex.Sj = 0 : Exit Sub
                If TipoDilat < 4 Then
1020:               Dilat(ii).DilFlex.Sj = 1.7 * Dm * Dilat(ii).DilProg.EE * (Dilat(ii).DilGeom.TE / Dilat(ii).DilEqui.W) ^ 3 * Dilat(ii).DilGeom.nPli / Cf / Dilat(ii).DilGeom.nOnde
                Else
                    Cr = 0.3 - (100 / (0.6 * System.Math.Abs(Dilat(ii).DilProg.Ps) ^ 1.5 + 32)) ^ 2
878:                Q = 2 * (Dilat(ii).DilGeom.ra + Dilat(ii).DilGeom.ra + Dilat(ii).DilEqui.ta * Dilat(ii).DilGeom.nPli)
                    Dilat(ii).DilFlex.Sj = 1.7 * Dm * Dilat(ii).DilProg.EE * (Dilat(ii).DilEqui.ta / (Dilat(ii).DilEqui.W - Cr * Q)) ^ 3 * Dilat(ii).DilGeom.nPli / Cf / Dilat(ii).DilGeom.nOnde
                End If
            Next
        End With
        Exit Sub
    End Sub
    Function LeggiDilat(ByRef mode As Short, ByRef WWW As Short, ByRef TipoDilat As Short, ByRef SoloDilat As Short) As Short
        Dim jDilat, i, Res, kDilat As Short
        Dim MAT7 As Short
        If TipoDilat = 7 Then
            'messagebox.show "E' stato impostato un dilatatore con imputazione manuale della costante elastica", vbInformation
            Exit Function
        End If
        If SoloDilat Then
            jDilat = jInvolucr
            kDilat = kLato
        Else
            jDilat = CType(CType(objMemb(Involucr(kLato, jInvolucr).IndObject), wn_PT).Piastra, wn_FTC).IndiceDilat
            kDilat = 1
        End If
        With CType(CType(objMemb(Involucr(kLato, jInvolucr).IndObject), wn_PT).Piastra, wn_FTC)
            Select Case WWW
                Case 26, 19
                    If Not OptimDil Then
                        If .Zp(0, 26) = 0 Or mode = 1 Then
                            If mode = 0 Then
10590:                          Res = DatiDilat(kDilat, jDilat)
                            End If
                            .Zp(0, 26) = Involucr(kDilat, jDilat).dns
10600:                      Call GeomDilat(Dilatatore, TipoDilat)
10610:                      Call GeomEquiv(TipoDilat)
                        Else
10620:                      For i = 1 To 8
                                .Zp(i, 26) = 0
                                .Zp(i, 36) = 0
                                .Zp(i, 37) = 0
                            Next
                        End If
                    End If
                Case 36, 37
                    If Not OptimDil Then
                        Call GeomDilat(Dilatatore, TipoDilat)
                        Call GeomEquiv(TipoDilat)
                    End If
                    If .Zp(0, 26) > 0 Then
10625:                  MAT7 = Matdim(Involucr(kDilat, jDilat).indice(1 - 1)).ElasCod
                        If MAT7 < 1 Then
                            If mode = 0 Then
                                LeggiDilat = 34 : Exit Function
                            Else
                                '             Z(iCond, 36) = 0
                                'If Not SoloDilat Then Exit Function
                            End If
                        End If
                        Dilat(1).DilProg.temp = .Zp(0, 5)
                        Dilat(2).DilProg.temp = .Zp(0, 5)
                        If .Zp(0, 287) = 0 Then
                            .Zp(0, 287) = Matdim(Involucr(kDilat, jDilat).indice(1 - 1)).EmodAlt(Dilat(1).DilProg.temp) * psi
                        End If
                        If .Zp(0, 287) = 0 Then LeggiDilat = 34 : Exit Function
                        Dilat(1).DilProg.EE = .Zp(0, 287)
                        Dilat(2).DilProg.EE = Dilat(1).DilProg.EE
                        If .Zp(0, 8) = 0 Then 'mantello
                            If Matdim(Involucr(kDilat, jDilat).indice(5 - 1)).Indmat = 0 And Matdim(Involucr(kDilat, jDilat).indice(5 - 1)).Agganciato Then
                                'messagebox.show "Non è noto il materiale della membratura a cui è collegato il dilatatore"
                                MostraAiuto(IDH_MANCAMANTDIL)
                            Else
                                .Zp(0, 8) = Matdim(Involucr(kDilat, jDilat).indice(5 - 1)).EmodAlt(Dilat(1).DilProg.temp) * psi
                            End If
                        End If
                        Dilat(1).DilProg.ES = .Zp(0, 8)
                        Dilat(2).DilProg.ES = Dilat(1).DilProg.ES
                        Dilat(1).DilProg.Eo = Dilat(1).DilProg.EE
                        Dilat(2).DilProg.Eo = Dilat(1).DilProg.EE
                        If TipoDilat > 2 And TipoDilat < 6 Then
                            For i = 1 To 2
                                Dilat(i).DilProg.Ea = Matdim(Involucr(kDilat, jDilat).indice(2 - 1)).EmodAlt(Dilat(1).DilProg.temp) 'mat collare
                                Dilat(i).DilProg.Eb = Matdim(Involucr(kDilat, jDilat).indice(1 - 1)).EmodAlt(20) 'soffietto a temp.ambiente
                            Next
                        End If
                        Dilat(3).DilProg = Dilat(1).DilProg
                        Dilat(4).DilProg = Dilat(2).DilProg
10630:                  Call FlexDilat(TipoDilat)
                        .Zp(0, 36) = Dilat(1).DilFlex.Sj
                        .Zp(0, 37) = Dilat(2).DilFlex.Sj
                    End If
            End Select 'i
        End With
        Exit Function
    End Function
    Sub StressDilat(ByRef ii As Short, ByRef Smm() As Single, ByRef Smb() As Single, ByRef Scm() As Single, ByRef TipoDilat As Short, ByRef iCond As Short)
        Dim am2, Zb, p1, Za, am1, am3 As Single
        Dim g, thetab, thetaa, Psstar, cc As Single
        Dim term20, term1, term2 As Single
        Dim A3, a1, a, a2, A4 As Single
        Dim d, det1, b, det2 As Single
        Dim i As Short
        Dim Fax, PSP As Single
        Dim E, chi2, chi1, R, am As Single
        Dim T1, beta, y, T2 As Single
        Dim B1, Al, delta, B2 As Single
        Dim j As Short
        Dim chi, t As Single
        Dim v2, Scl, Sbl, v1, v2s As Single
        Dim F2 As Single
        If TipoDilat = 7 Then Exit Sub
600:    p1 = Dilat(ii).DilProg.PT - Dilat(ii).DilProg.Ptp
        Psstar = p1 + Dilat(ii).DilProg.PSP - Dilat(ii).DilProg.Pd
        Dilat(ii).DilStre.Fax(iCond - 1) = Dilat(ii).DilEqui.a / inc * Psstar / 2
        If TipoDilat > 2 And TipoDilat < 6 Then
602:        Call StressEjma(ii, iCond, Smm, Smb, Scm, TipoDilat)
            Exit Sub
        End If 'i
        'RCB-8.71
604:    Za = (Dilat(ii).DilProg.Ps * (Dilat(ii).DilEqui.a / inc) ^ 2 - 0.3 * (Dilat(ii).DilEqui.a / inc) * Dilat(ii).DilStre.Fax(iCond - 1)) / Dilat(ii).DilProg.Ea / Dilat(ii).DilEqui.ta * inc
        Zb = (Dilat(ii).DilProg.Ps * (Dilat(ii).DilEqui.b / inc) ^ 2 - 0.3 * ((Dilat(ii).DilEqui.a / inc) * Dilat(ii).DilStre.Fax(iCond - 1) + (Dilat(ii).DilEqui.b ^ 2 - Dilat(ii).DilEqui.a ^ 2) / 2 / inc ^ 2 * Dilat(ii).DilProg.Ps)) / Dilat(ii).DilProg.Ea / Dilat(ii).DilEqui.ta * inc
        IntermStress(ii, iCond).Za = Za
        IntermStress(ii, iCond).Zb = Zb
        g = Dilat(ii).DilFlex.g
        am1 = Dilat(ii).DilFlex.m1
        am2 = Dilat(ii).DilFlex.m2
        am3 = Dilat(ii).DilFlex.m3
610:    thetaa = Dilat(ii).DilProg.Ps * (Dilat(ii).DilEqui.b / inc) ^ 3 / 8 / Dilat(ii).DilFlex.DE * (-2 * g * am2 - am3 / g - g ^ 3 / 2 - 2 * g ^ 3 * System.Math.Log(g))
        thetab = Dilat(ii).DilProg.Ps * (Dilat(ii).DilEqui.b / inc) ^ 3 / 8 / Dilat(ii).DilFlex.DE * (-2 * am2 - am3 + 0.5 - g ^ 2)
        IntermStress(ii, iCond).thetaa = thetaa
        IntermStress(ii, iCond).thetab = thetab
        term1 = (-thetaa - Dilat(ii).DilStre.Fax(iCond - 1) * Dilat(ii).DilFlex.x(3 - 1) - Dilat(ii).DilFlex.betaa * Za)
        term20 = Dilat(ii).DilFlex.betab * Dilat(ii).DilFlex.k(2, 2 - 1) * Zb / Dilat(ii).DilFlex.k(1, 2 - 1)
        term2 = Dilat(ii).DilStre.Fax(iCond - 1) * Dilat(ii).DilFlex.x(6 - 1) + thetab - term20
        Dilat(ii).DilStre.Ma = ((Dilat(ii).DilFlex.x(5 - 1) + Dilat(ii).DilFlex.y(2 - 1)) * term1 + Dilat(ii).DilFlex.x(2 - 1) * term2) / Dilat(ii).DilFlex.xx
        Dilat(ii).DilStre.Mb = ((Dilat(ii).DilFlex.y(1 - 1) - Dilat(ii).DilFlex.x(1 - 1)) * term2 - Dilat(ii).DilFlex.x(4 - 1) * term1) / Dilat(ii).DilFlex.xx
        'RCB-8.72
620:    a = Dilat(ii).DilEqui.a / inc : b = Dilat(ii).DilEqui.b / inc
        cc = Dilat(ii).DilFlex.c : d = Dilat(ii).DilFlex.d
        a1 = -cc * Dilat(ii).DilStre.Ma + cc * d * d * Dilat(ii).DilStre.Mb + 0.65 * a * cc * Dilat(ii).DilStre.Fax(iCond - 1) * System.Math.Log(g) - Dilat(ii).DilProg.Ps * (0.325 * am2 * b * b + 0.4125 * a * a)
        a2 = b * b * (cc * Dilat(ii).DilStre.Ma - cc * Dilat(ii).DilStre.Mb - 0.65 * a * cc * Dilat(ii).DilStre.Fax(iCond - 1) * System.Math.Log(g) + 0.0875 * am3 * Dilat(ii).DilProg.Ps * b * b)
        A3 = 0.206 * Dilat(ii).DilProg.Ps
        A4 = 0.65 * a * (Dilat(ii).DilStre.Fax(iCond - 1) - 0.5 * a * Dilat(ii).DilProg.Ps)
        IntermStress(ii, iCond).R(1) = a : IntermStress(ii, iCond).R(3) = b : IntermStress(ii, iCond).R(2) = 0
630:    If Dilat(ii).DilProg.Ps <> 0 Then
            det1 = A4 * A4 + 16 * A3 * a2
            If det1 > 0 Then
                det2 = (-A4 + System.Math.Sqrt(det1)) / A3
                If det2 > 0 Then
                    IntermStress(ii, iCond).R(2) = System.Math.Sqrt((det2) / 4)
                    If IntermStress(ii, iCond).R(2) < a Or IntermStress(ii, iCond).R(2) > b Then IntermStress(ii, iCond).R(2) = 0
                End If 'h
            End If 'k
640:        det1 = A4 * A4 - 16 * A3 * a2
            If det1 > 0 Then
                det2 = (-A4 + System.Math.Sqrt(det1)) / A3
                If det2 > 0 Then
                    IntermStress(ii, iCond).R(2) = System.Math.Sqrt((det2) / 4)
                    If IntermStress(ii, iCond).R(2) < a Or IntermStress(ii, iCond).R(2) > b Then IntermStress(ii, iCond).R(2) = 0
                End If 'l
            End If
            det1 = A4 * A4 + 16 * A3 * a2
            If det1 > 0 Then
                det2 = (-A4 - System.Math.Sqrt(det1)) / A3
                If det2 > 0 Then
                    IntermStress(ii, iCond).R(2) = System.Math.Sqrt((det2) / 4)
                    If IntermStress(ii, iCond).R(2) < a Or IntermStress(ii, iCond).R(2) > b Then IntermStress(ii, iCond).R(2) = 0
                End If
            End If
            det1 = A4 * A4 - 16 * A3 * a2
            If det1 > 0 Then
                det2 = (-A4 - System.Math.Sqrt(det1)) / A3
                If det2 > 0 Then
                    IntermStress(ii, iCond).R(2) = System.Math.Sqrt((det2) / 4)
                    If IntermStress(ii, iCond).R(2) < a Or IntermStress(ii, iCond).R(2) > b Then IntermStress(ii, iCond).R(2) = 0
                End If
            End If
        End If
650:    If IntermStress(ii, iCond).R(2) = 0 Then IntermStress(ii, iCond).R(2) = (a + b) / 2
        Dilat(ii).DilStre.sb = 0
        For i = 1 To 3
            sb = 6 / (Dilat(ii).DilGeom.TE / inc) ^ 2 * (a1 + a2 / IntermStress(ii, iCond).R(i) ^ 2 + A3 * IntermStress(ii, iCond).R(i) ^ 2 + A4 * System.Math.Log(IntermStress(ii, iCond).R(i) / b))
            If System.Math.Abs(sb) > System.Math.Abs(Dilat(ii).DilStre.sb) Then Dilat(ii).DilStre.sb = sb
            Smb(i + 2) = sb
        Next
        Smm(4) = 0
        Fax = Dilat(ii).DilStre.Fax(iCond - 1)
        Smm(3) = Fax / (Dilat(ii).DilGeom.TE / inc)
        Smm(1) = Fax / (Dilat(ii).DilGeom.to_Renamed / inc)
        Smm(2) = Fax / (Dilat(ii).DilGeom.TE / inc)
        PSP = Dilat(ii).DilProg.PSP
        Fax = Fax - PSP * a
        Smm(5) = Fax / (Dilat(ii).DilGeom.TE / inc) * a / b
        Smm(7) = Fax / (Dilat(ii).DilGeom.ts / inc) * a / b
        Smm(6) = Fax / (Dilat(ii).DilGeom.TE / inc) * a / b
        'RCB-8.73
680:    Dilat(ii).DilStre.Sm = 0
        Dilat(ii).DilStre.Scl = 0
        For i = 1 To 2
            If i = 1 Then
                chi1 = Dilat(ii).DilEqui.la / inc : chi2 = Dilat(ii).DilEqui.ya / inc
                R = a
                E = Dilat(ii).DilProg.Ea
                am = Dilat(ii).DilStre.Ma
                'gp = 1
                d = Dilat(ii).DilFlex.Da
                beta = Dilat(ii).DilFlex.betaa
                y = Dilat(ii).DilEqui.ya / inc
                T1 = Dilat(ii).DilEqui.ta / inc
                T2 = Dilat(ii).DilGeom.ts / inc
                Al = Dilat(ii).DilGeom.li / inc
            Else
                chi1 = Dilat(ii).DilEqui.lb / inc : chi2 = Dilat(ii).DilEqui.yb / inc
                R = b
                E = Dilat(ii).DilProg.Eb
                am = Dilat(ii).DilStre.Mb
                'gp = b / a
                d = Dilat(ii).DilFlex.db
                beta = Dilat(ii).DilFlex.betab
                y = Dilat(ii).DilEqui.yb / inc
                T1 = Dilat(ii).DilEqui.tb / inc
                T2 = Dilat(ii).DilGeom.to_Renamed / inc
                Al = Dilat(ii).DilGeom.lo / inc
            End If
            For j = 1 To 2
                If j = 1 Then chi = chi1 Else chi = chi2
                IntermStress(ii, iCond).chi(i, 1) = chi1 : IntermStress(ii, iCond).chi(i, 2) = chi2
                Select Case y - chi
                    Case Is < Al : t = T2
                    Case Is > Al : t = T1
                    Case Is = Al : t = T1 : If t > T2 Then t = T2
                End Select
                IntermStress(ii, iCond).t(i, j) = t
                If i = 1 Then
                    F2 = Dilat(ii).DilStre.Fax(iCond - 1)
                Else
                    F2 = (Dilat(ii).DilStre.Fax(iCond - 1) * a / b + Dilat(ii).DilProg.Ps * (b * b - a * a) / 2 / b)
                End If
                delta = R / E / t * (Dilat(ii).DilProg.Ps * R - 0.3 * F2)
                IntermStress(ii, iCond).delta(i) = delta
752:            B1 = (Dilat(ii).DilFlex.j(2 - 1, i - 1) * am / 2 / beta ^ 2 / Dilat(ii).DilFlex.E(i - 1) / d - Dilat(ii).DilFlex.j(1 - 1, i - 1) * delta) / Dilat(ii).DilFlex.Z(i - 1)
                IntermStress(ii, iCond).B1(i) = B1
                B2 = (-Dilat(ii).DilFlex.j(1 - 1, i - 1) * am / 2 / beta ^ 2 / Dilat(ii).DilFlex.E(i - 1) / d - Dilat(ii).DilFlex.j(2 - 1, i - 1) * delta) / Dilat(ii).DilFlex.Z(i - 1)
                IntermStress(ii, iCond).B2(i) = B2
                T1 = Dilat(ii).DilGeom.TE : If Dilat(ii).DilEqui.ta < T1 Then T1 = Dilat(ii).DilEqui.ta
                T1 = T1 / inc
                IntermStress(ii, iCond).T1(i) = T1
                Sbl = 6 * System.Math.Abs(am) / T1 ^ 2
756:            Scl = (Sbl + System.Math.Abs(F2) / T1)
                IntermStress(ii, iCond).Scl(i) = Scl
750:            v1 = beta * (y - chi)
                IntermStress(ii, iCond).v1(i, j) = v1
754:            v2 = B1 * System.Math.Sin(v1) * (System.Math.Exp(v1) - System.Math.Exp(-v1)) / 2 + B2 * System.Math.Cos(v1) * (System.Math.Exp(v1) + System.Math.Exp(-v1)) / 2
                IntermStress(ii, iCond).v2(i, j) = v2
760:            v2s = 2 * beta * beta * (B1 * System.Math.Cos(v1) * (System.Math.Exp(v1) + System.Math.Exp(-v1)) / 2 - B2 * System.Math.Sin(v1) * (System.Math.Exp(v1) - System.Math.Exp(-v1)) / 2)
                IntermStress(ii, iCond).v2s(i, j) = v2s
761:            Sm = System.Math.Abs(E * (delta + v2) / R)
                IntermStress(ii, iCond).Sm(i, j) = Sm
                If Sm > Dilat(ii).DilStre.Sm Then Dilat(ii).DilStre.Sm = Sm
                sb = 6 * System.Math.Abs(d * v2s) / t / t
                IntermStress(ii, iCond).sb(i, j) = sb
                If i = 1 And j = 2 Then
                    Scm(1) = Sm : Smb(1) = sb
                ElseIf i = 1 And j = 1 Then
                    Scm(2) = Sm : Smb(2) = sb
                ElseIf i = 2 And j = 1 Then
                    Scm(6) = Sm : Smb(6) = sb
                Else
                    Scm(7) = Sm : Smb(7) = sb
                End If
                If System.Math.Abs(Scl) > System.Math.Abs(Dilat(ii).DilStre.Scl) Then Dilat(ii).DilStre.Scl = System.Math.Abs(Scl)
            Next j
            'RCB-8.74
        Next i
        Scm(3) = 0 : Scm(4) = 0 : Scm(5) = 0
670:    For i = 1 To 7 : Smb(i) = System.Math.Abs(Smb(i)) + System.Math.Abs(Smm(i)) : Next
    End Sub
    Sub StressEjma(ByRef i As Short, ByRef iCond As Short, ByRef Smm() As Single, ByRef Smb() As Single, ByRef Scm() As Single, ByRef TipoDilat As Short)
        Dim Db1, Alt, db, DC As Single
        Dim Dm, Ak, Den, ac As Single
        Dim Cp, Cf, Q, Cd, fiu As Single
        Dim delta, sY, Tpipe As Single
        Dim R, Cz, aLb, H, R1 As Single
        Dim LunTira, R2, Cr As Single
        O = CType(CType(objMemb(Involucr(kLato, jInvolucr).IndObject), wn_PT).Piastra, wn_FTC)
        Alt = Dilat(i).DilGeom.li / inc
        db = Dilat(i).DilGeom.g / inc
        Db1 = (Dilat(i).DilGeom.g + Dilat(i).DilGeom.TE * Dilat(i).DilGeom.nPli) / inc
        DC = (Dilat(i).DilGeom.g + 2 * Dilat(i).DilGeom.TE * Dilat(i).DilGeom.nPli + Dilat(i).DilGeom.to_Renamed) / inc
        Ak = Alt / 1.5 / System.Math.Sqrt(db * Dilat(i).DilGeom.TE / inc) : If Ak > 1 Then Ak = 1
        Den = 2 * (Dilat(i).DilGeom.TE * Dilat(i).DilGeom.nPli / inc * Dilat(i).DilProg.EE * Alt * Db1 + Dilat(i).DilProg.Ea * Dilat(i).DilGeom.to_Renamed * Ak * Dilat(i).DilGeom.lo * DC / inc / inc)
        If Den > 0 Then
            Scm(1) = System.Math.Abs(Dilat(i).DilProg.Ps * Db1 * Db1 * Alt * Dilat(i).DilProg.EE * Ak / Den)
            Scm(2) = System.Math.Abs(Dilat(i).DilProg.Ps * DC * DC * Alt * Dilat(i).DilProg.Ea * Ak / Den)
        End If
        Dm = (Dilat(i).DilGeom.g + Dilat(i).DilEqui.W + Dilat(i).DilGeom.TE * Dilat(i).DilGeom.nPli)
778:    Q = 2 * (Dilat(i).DilGeom.ra + Dilat(i).DilGeom.ra + Dilat(i).DilGeom.TE * Dilat(i).DilGeom.nPli) / inc
780:    ac = (0.571 * Q + 2 * Dilat(i).DilEqui.W / inc) * Dilat(i).DilEqui.ta / inc * Dilat(i).DilGeom.nPli
        Cp = EjmaGraf(i, 1)
        delta = Dilat(i).DilStre.Fax(iCond - 1) * 2 * pi * Dilat(i).DilEqui.a / Dilat(i).DilFlex.Sj / inc
        Cf = EjmaGraf(i, 2)
        Cd = EjmaGraf(i, 3)
        fiu = Dilat(i).DilFlex.Sj * Dilat(i).DilGeom.nOnde
        sY = Dilat(i).DilProg.sY
        Select Case TipoDilat
            Case 3
                Scm(3) = System.Math.Abs(Dilat(i).DilProg.Ps * Dm / (2 * Dilat(i).DilEqui.ta * Dilat(i).DilGeom.nPli) / (0.571 + 1 / Dilat(i).DilEqui.ya))
                Scm(4) = 0 : Scm(5) = 0
770:            Smm(1) = System.Math.Abs(Dilat(i).DilProg.Ps * Dilat(i).DilEqui.W / (2 * Dilat(i).DilEqui.ta * Dilat(i).DilGeom.nPli))
772:            Smb(1) = System.Math.Abs(Dilat(i).DilProg.Ps / (2 * Dilat(i).DilGeom.nPli) * (Dilat(i).DilEqui.W / Dilat(i).DilEqui.ta) ^ 2 * Cp)
776:            Smm(2) = System.Math.Abs(Dilat(i).DilProg.Ea * (Dilat(i).DilEqui.ta / inc) ^ 2 * delta / 2 / (Dilat(i).DilEqui.W / inc) ^ 3 / Cf) / Dilat(i).DilGeom.nOnde
779:            Smb(2) = System.Math.Abs(5 * Dilat(i).DilProg.Ea * (Dilat(i).DilEqui.ta / inc) * delta / 3 / (Dilat(i).DilEqui.W / inc) ^ 2 / Cd) / Dilat(i).DilGeom.nOnde
784:            aLb = Q * Dilat(i).DilGeom.nOnde
                Cz = System.Math.Sqrt(4.72 * fiu * aLb * Q / (sY * db * ac * Dilat(i).DilGeom.nOnde))
781:            IntermStress(i, iCond).Za = Cz
                If aLb / db >= Cz Then
                    Smb(4) = 0.34 * pi * fiu / Dilat(i).DilGeom.nOnde ^ 2 / Q 'pressione critica Psc
                Else
                    Smb(4) = 0.58 * ac * sY / db / Q * (1 - 0.6 * aLb / Cz / db) 'pressione critica Psc
                End If
782:            Smb(5) = 1.4 * Dilat(i).DilGeom.nPli * (Dilat(i).DilEqui.ta / Dilat(i).DilEqui.W) ^ 2 * sY / Cp
                IntermStress(i, iCond).thetaa = aLb * Tpipe ^ 3 / 12
                IntermStress(i, iCond).thetab = Dilat(i).DilGeom.nOnde * Dilat(i).DilEqui.ta / inc * Dilat(i).DilGeom.nPli * ((2 * Dilat(i).DilEqui.W / inc - Q) ^ 3 / 48 + 0.4 * Q * (Dilat(i).DilEqui.W / inc - 0.2 * Q) ^ 2)
            Case 4, 5
783:            H = Dilat(i).DilProg.Ps * Dm / inc * Q
                R1 = ac * Dilat(i).DilProg.EE / Dilat(i).DilGeom.fa / O.Zp(iCond, 277) * inc * inc
                R = R1
                If TipoDilat = 5 Then
                    R2 = ac * Dilat(i).DilProg.EE / Dm * inc * (LunTira * inc / Dilat(i).DilGeom.fb / O.Zp(iCond, 279) + Dm * inc / Dilat(i).DilGeom.fa / O.Zp(iCond, 277))
                    R = R2
                End If
                Scm(3) = System.Math.Abs(H) / 2 / ac * R / (R + 1) 'bellows
                Scm(4) = System.Math.Abs(H) / 2 / Dilat(i).DilGeom.fa * inc * inc / (R1 + 1)
                Scm(5) = 0
                If TipoDilat = 5 Then Scm(5) = System.Math.Abs(H) / 2 / Dilat(i).DilGeom.fb * inc * inc / (R2 + 1)
                Cr = 0.3 - (100 / (0.6 * System.Math.Abs(Dilat(i).DilProg.Ps) ^ 1.5 + 32)) ^ 2
                Smm(1) = 0.85 * System.Math.Abs(Dilat(i).DilProg.Ps * (Dilat(i).DilEqui.W / inc - Cr * Q) / (2 * Dilat(i).DilEqui.ta / inc * Dilat(i).DilGeom.nPli))
                Smb(1) = 0.85 * System.Math.Abs(Dilat(i).DilProg.Ps / (2 * Dilat(i).DilGeom.nPli) * ((Dilat(i).DilEqui.W - Cr * Q * inc) / Dilat(i).DilEqui.ta) ^ 2 * Cp)
                Smm(2) = System.Math.Abs(Dilat(i).DilProg.Ea * (Dilat(i).DilEqui.ta / inc) ^ 2 * delta / 2 / (Dilat(i).DilEqui.W / inc - Cr * Q) ^ 3 / Cf) / Dilat(i).DilGeom.nOnde
                Smb(2) = System.Math.Abs(5 * Dilat(i).DilProg.Ea * (Dilat(i).DilEqui.ta / inc) * delta / 3 / (Dilat(i).DilEqui.W / inc - Cr * Q) ^ 2 / Cd) / Dilat(i).DilGeom.nOnde
                Smb(4) = 0.3 * pi * fiu / Dilat(i).DilGeom.nOnde ^ 2 / Q 'pressione critica Psc
        End Select
        Smb(1) = Smm(1) + Smb(1)
        Smb(2) = Smm(2) + Smb(2)
    End Sub
    Sub AmmissDilat(ByRef iiCond As Short)
        ' If Config.TipoDilat = 7 Then Exit Sub
        ' Esp(-1) = -1: Esp(-2) = -2: Esp(-3) = -3
        ' Stringa1$(1) = "Temperatura di progetto [øF]": Risult$(1) = myStr(CSng(Z(iiCond, 5)), 4, 2, False)
        ' Stringa1$(2) = "Ammissibile dilatatore [psi]": Risult$(2) = myStr(CSng(Z(iiCond, 274)), 6, 2, False)
        ' Stringa1$(3) = "Mod.el.     dilatatore [ksi]": Risult$(3) = myStr(CSng(Z(iiCond, 287) / 1000), 6, 2, False)
        ' Stringa1$(4) = "Snervamento dilatatore [psi]": Risult$(4) = myStr(CSng(Z(iiCond, 275)), 6, 2, False)
        ' Stringa1$(5) = "Ammissibile collare    [psi]": Risult$(5) = myStr(CSng(Z(iiCond, 276)), 6, 2, False)
        ' Stringa1$(6) = "Ammissibile an.rinforzo[psi]": Risult$(6) = myStr(CSng(Z(iiCond, 278)), 6, 2, False)
        ' Stringa1$(7) = "Mod.el. an.rinforzo    [ksi]": Risult$(7) = myStr(CSng(Z(iiCond, 277) / 1000), 8, 2, False)
        ' Stringa1$(8) = "Ammissibile tiranti    [psi]": Risult$(8) = myStr(CSng(Z(iiCond, 280)), 6, 2, False)
        ' Stringa1$(9) = "Mod.el. tiranti        [ksi]": Risult$(9) = myStr(CSng(Z(iiCond, 279) / 1000), 8, 2, False)
        ' Nfield = 9
        ' Select Case Config.TipoDilat
        ' Case 1, 2, 6
        '   For i = 4 To 9: Stringa1$(i) = Chr$(45): Next
        ' Case 3 'Multistrato senza anelli        .
        '   For i = 5 To 9: Stringa1$(i) = Chr$(45): Next
        ' Case 4 'Multistrato con anelli integrali.
        '   For i = 8 To 9: Stringa1$(i) = Chr$(45): Next
        ' Case 5 'Multistrato con anelli bullonati.
        ' End Select
        ' j = 0
        ' For i = 1 To Nfield
        '   If (Stringa1$(i)) = Chr$(45) Then
        '     Compr(i) = 0
        '   Else
        '     j = j + 1
        '     Compr(i) = j
        '     Esp(j) = i
        '   End If 'e
        ' Next i '1
140:    ' Nfield = j
        'For i = 1 To Nfield
        '   Stringa1$(i) = Stringa1$(Esp(i))
        '   Risult$(i) = Risult$(Esp(i))
        'Next i ' a
        '   LungStr(1) = Len(Risult$(1)): For i = 2 To Nfield: LungStr(i) = -Len(Risult$(i)): Next
        'Tit$ = "Condizione nø" + Str$(iiCond)
        'y = InputDati%(2, Nfield, Tit$, Stringa1$(), Risult$(), LungStr())
        'Do
        'Select Case Esp(y)
        '    Case -3
        '               'a$ = " Clickando su alcuni dei campi della | finestra sottostante si otiene |"
        '               'a$ = a$ + " una lista dei valori possibili. Cio' | vale in particolare per i materiali.|"
        '               junk = Alert(4, at1(59), 4, 3, 11, 48, at1(33), "", "")
        '    Case -2
        '               WindowClose 2: Exit Sub
        '    Case -1
        '               WindowClose 2: Exit Do
        '    Case 1: 'Temperatura
        '    Case 2: 'amm.dil
        '     Call AmmissDil
        '     Risult$(y) = myStr(CSng(Z(iiCond, 274)), 6, 2, False)
        ''     PRINT y; Esp(y); Risult$(y); Z(iiCond, 274): u$ = INPUT$(1)
        '    Case 3
        '     Call ElasDil(1)
        '     Risult$(y) = myStr(CSng(Z(iiCond, 287) / 1000), 6, 2, False)
        ''     PRINT y; Esp(y); Risult$(y); Z(iiCond, 287): u$ = INPUT$(1)
        '    Case 4: 'snerv.dil
        '     Call SnervDil(1)
        '     Risult$(y) = myStr(CSng(Z(iiCond, 275)), 6, 2, False)
        ''     PRINT y; Esp(y); Risult$(y); Z(iiCond, 275): u$ = INPUT$(1)
        '    Case 5: 'amm.collare
        '     Call AmmissColl
        '     Risult$(y) = myStr(CSng(Z(iiCond, 276)), 6, 2, False)
        '    Case 6: 'amm.anelli
        '     Call AmmissRinf
        '     Risult$(y) = myStr(CSng(Z(iiCond, 278)), 6, 2, False)
        '    Case 7: 'E anelli
        '     Call ElasRinf(1)
        '     Risult$(y) = myStr(CSng(Z(iiCond, 277) / 1000), 8, 2, False)
        '    Case 8: 'amm.tiranti
        '     Call AmmissTir
        '     Risult$(y) = myStr(CSng(Z(iiCond, 280)), 6, 2, False)
        '    Case 9: 'E tiranti
        '     Call ElasTir(1)
        '     Risult$(y) = myStr(CSng(Z(iiCond, 279) / 1000), 8, 2, False)
        'End Select
        'y = InputDati%(0, Nfield, Tit$, Stringa1$(), Risult$(), LungStr())
        'Loop
        'Z(iiCond, 5) = GlobaLroutines.ValVir(Risult$(1))
        'Z(iiCond, 274) = GlobaLroutines.ValVir(Risult$(2))
        'Z(iiCond, 287) = GlobaLroutines.ValVir(Risult$(3)) * 1000
        'Z(iiCond, 275) = GlobaLroutines.ValVir(Risult$(4))
        'Z(iiCond, 276) = GlobaLroutines.ValVir(Risult$(5))
        'Z(iiCond, 278) = GlobaLroutines.ValVir(Risult$(6))
        'Z(iiCond, 277) = GlobaLroutines.ValVir(Risult$(7)) * 1000
        'Z(iiCond, 280) = GlobaLroutines.ValVir(Risult$(8))
        'Z(iiCond, 279) = GlobaLroutines.ValVir(Risult$(9)) * 1000
        '     Sfo = Z(iiCond, 274)
        '     Dilat(1).DilProg.Sigma = Sfo: Dilat(2).DilProg.Sigma = Sfo
        '     SYD = Z(iiCond, 275)
        '     Dilat(1).DilProg.Sy = SYD: Dilat(2).DilProg.Sy = SYD
    End Sub
    Sub AppCC(ByRef iCond As Short, ByRef SoloDilat As Short, ByRef TipoDilat As Short)
        Dim k, ii, kk As Short
        Dim Ptp As Single
        Dim PT, PSP, Ps, Pd As Single
        Dim i3, i1, i2, kk1 As Short
        Dim Salt As Single
        Dim j, fact, rhos As Single
        Dim QZ1, Ksvt, QZ2 As Single
        Try
            O = CType(CType(objMemb(Involucr(kLato, jInvolucr).IndObject), wn_PT).Piastra, wn_FTC)
            For ii = 1 To 2
                For k = 1 To 7
3000:               Dilat(ii).Risult(iCond).Sm(k - 1) = 0
                    Dilat(ii).Risult(iCond).sb(k - 1) = 0
                Next
                For kk = 1 To 7
3010:               Dilat(ii).Risult(iCond).Scmp(kk - 1) = 0
                    Dilat(ii).Risult(iCond).Smmp(kk - 1) = 0
                    Dilat(ii).Risult(iCond).Smbp(kk - 1) = 0
                Next
                Dim r As Risult = Dilat(ii).Risult(iCond)
                r.Salt = 0
                Dilat(ii).Risult(iCond) = r
            Next
            For ii = 1 To 2
                Ps = O.Zp(iCond, 1)
                If SoloDilat Then
                    If TipoDilat < 3 Or TipoDilat = 6 Then
3021:                   PSP = -0.5 * ((Dilat(ii).DilGeom.id / Dilat(ii).DilGeom.g) ^ 2 - 1) * Ps
                        O.Zp(iCond, 67 + ii - 1) = PSP
                        O.Zp(iCond, 2) = 0
                    Else
                        PSP = 0
                    End If
                    PT = 0 : Ptp = 0
                    Pd = -Dilat(ii).DilFlex.Sj * O.Zp(iCond, 284) / pi / (Dilat(ii).DilEqui.a / inc) ^ 2 / inc
                    O.Zp(iCond, 59 + ii - 1) = Pd
                Else
                    If O.CalcoloInCorso = 1 Then
                        j = O.Zp(iCond, 57 + ii - 1)
                        rhos = O.Zp(iCond + O.Offset, 385 + ii - 1)
                        Ksvt = O.Zp(iCond, 47 + ii - 1)
                        QZ1 = O.Zp(iCond + O.Offset, 416 + ii - 1)
                        QZ2 = O.Zp(iCond + O.Offset, 418 + ii - 1)
                        fact = j * Ksvt / (1 + j * Ksvt * (QZ1 + (rhos - 1) * QZ2))
                    Else
                        fact = 1
                    End If
                    PSP = O.Zp(iCond, 67 + ii - 1) * fact
                    PT = O.Zp(iCond, 2)
                    Ptp = O.Zp(iCond, 97 + ii - 1) * fact
                    Pd = O.Zp(iCond, 59 + ii - 1) * fact 'ATTENZIONE: non annullare per J
                    If O.CalcoloInCorso = 1 Then
                        Pd = -Pd
                        'PSP = -PSP
                    End If
                End If
                For k = 1 To 7
                    Select Case k
                        Case 1 : i1 = 0 : i2 = 0 : i3 = 1
                        Case 2 : i1 = 0 : i2 = 1 : i3 = 0
                        Case 3 : i1 = 1 : i2 = 0 : i3 = 0
                        Case 4 : i1 = 1 : i2 = 1 : i3 = 0
                        Case 5 : i1 = 0 : i2 = 1 : i3 = 1
                        Case 6 : i1 = 1 : i2 = 0 : i3 = 1
                        Case 7 : i1 = 1 : i2 = 1 : i3 = 1
                    End Select 'a
                    With Dilat(ii).DilProg
                        .PT = PT * i1
                        If SoloDilat Then .PT = 0
                        .Ps = Ps * i2
                        .Ptp = Ptp * i1
                        If SoloDilat Then .Ptp = 0
                        .PSP = PSP * i2
                        If TipoDilat > 2 And TipoDilat < 6 Then .PSP = 0
                        .Pd = Pd * i3
                    End With
                    If (O.Zp(iCond, 3) > 0 Or SoloDilat) And (k = 3 Or k = 6) Then
                        For kk = 1 To 7
                            IntermStress(ii, iCond).Smm(kk) = 0 : IntermStress(ii, iCond).Smb(kk) = 0 : IntermStress(ii, iCond).Scm(kk) = 0
                        Next
                        GoTo contS
                    End If
3040:               Call StressDilat(ii, IntermStress(ii, iCond).Smm, IntermStress(ii, iCond).Smb, IntermStress(ii, iCond).Scm, TipoDilat, iCond)
                    Select Case TipoDilat
                        Case 1, 2, 6
3041:                       For kk = 1 To 7
                                'modificona                    k
                                If Dilat(ii).Risult(iCond).Sm(k - 1) < IntermStress(ii, iCond).Scm(kk) Then Dilat(ii).Risult(iCond).Sm(k - 1) = IntermStress(ii, iCond).Scm(kk - 1)
                                If Dilat(ii).Risult(iCond).sb(k - 1) < System.Math.Abs(IntermStress(ii, iCond).Smb(kk)) - System.Math.Abs(IntermStress(ii, iCond).Smm(kk)) Then Dilat(ii).Risult(iCond).sb(k - 1) = System.Math.Abs(IntermStress(ii, iCond).Smb(kk - 1)) - System.Math.Abs(IntermStress(ii, iCond).Smm(kk - 1))
                            Next
                            Select Case k
                                Case 2, 3, 4 'pressione
                                    For kk = 1 To 7
3050:                                   If Dilat(ii).Risult(iCond).Scmp(kk - 1) < IntermStress(ii, iCond).Scm(kk) Then Dilat(ii).Risult(iCond).Scmp(kk - 1) = IntermStress(ii, iCond).Scm(kk)
                                        If Dilat(ii).Risult(iCond).Smmp(kk - 1) < System.Math.Abs(IntermStress(ii, iCond).Smm(kk)) Then Dilat(ii).Risult(iCond).Smmp(kk - 1) = System.Math.Abs(IntermStress(ii, iCond).Smm(kk))
                                        If Dilat(ii).Risult(iCond).Smbp(kk - 1) < System.Math.Abs(IntermStress(ii, iCond).Smb(kk)) Then Dilat(ii).Risult(iCond).Smbp(kk - 1) = System.Math.Abs(IntermStress(ii, iCond).Smb(kk))
                                    Next
                                Case Else 'pressione + dilatazione
                                    If Dilat(ii).Risult(iCond).Salt < Dilat(ii).DilStre.Scl Then
                                        Dim ris As Risult = Dilat(ii).Risult(iCond)
                                        ris.Salt = Dilat(ii).DilStre.Scl
                                        Dilat(ii).Risult(iCond) = ris
                                    End If
                                    For kk = 1 To 7
                                        If System.Math.Abs(Dilat(ii).Risult(iCond).Salt) < System.Math.Abs(IntermStress(ii, iCond).Smb(kk)) Then
                                            Dim ris As Risult = Dilat(ii).Risult(iCond)
                                            ris.Salt = System.Math.Abs(IntermStress(ii, iCond).Smb(kk))
                                            Dilat(ii).Risult(iCond) = ris
                                        End If
                                    Next
                                    Dim r As Risult = Dilat(ii).Risult(iCond)
                                    r.Salt = Dilat(ii).Risult(iCond).Salt * System.Math.Sign(Dilat(ii).DilStre.Fax(iCond - 1))
                                    Dilat(ii).Risult(iCond) = r
                            End Select 'u
                        Case Else
                            If Dilat(1).DilFlex.Sj * Dilat(2).DilFlex.Sj = 0 Then Exit Sub
                            For kk = 1 To 3 Step 2
3070:                           If Dilat(ii).Risult(iCond).Sm(k - 1) < IntermStress(ii, iCond).Scm(kk - 1) Then Dilat(ii).Risult(iCond).Sm(k - 1) = IntermStress(ii, iCond).Scm(3 - 1) 'bellow meridion. pressure
                            Next
                            If Dilat(ii).Risult(iCond).Sm(k - 1) < IntermStress(ii, iCond).Smm(1 - 1) + IntermStress(ii, iCond).Smm(2 - 1) Then Dilat(ii).Risult(iCond).Sm(k - 1) = IntermStress(ii, iCond).Smm(1 - 1) + IntermStress(ii, iCond).Smm(2 - 1) 'bellow meridion. pressure
                            If Dilat(ii).Risult(iCond).sb(k - 1) < IntermStress(ii, iCond).Smb(1 - 1) + IntermStress(ii, iCond).Smb(2 - 1) Then Dilat(ii).Risult(iCond).sb(k - 1) = IntermStress(ii, iCond).Smb(1 - 1) + IntermStress(ii, iCond).Smb(2 - 1) 'bellow meridion. pressure
                            Select Case k
                                Case 2, 3, 4 'pressione
                                    For kk = 1 To 3 'tangent,collar,bellows
                                        kk1 = kk + 1 : If kk1 = 4 Then kk1 = 1
                                        If Dilat(ii).Risult(iCond).Scmp(kk1 - 1) < IntermStress(ii, iCond).Scm(kk) Then Dilat(ii).Risult(iCond).Scmp(kk1 - 1) = IntermStress(ii, iCond).Scm(kk)
                                    Next
                                    For kk = 4 To 5 'tangent,collar,bellows
                                        If Dilat(ii).Risult(iCond).Scmp(kk - 1) < IntermStress(ii, iCond).Scm(kk) Then Dilat(ii).Risult(iCond).Scmp(kk - 1) = IntermStress(ii, iCond).Scm(kk)
                                    Next
3080:                               If Dilat(ii).Risult(iCond).Smmp(1 - 1) < IntermStress(ii, iCond).Smm(1) Then Dilat(ii).Risult(iCond).Smmp(1 - 1) = IntermStress(ii, iCond).Smm(1)
                                    If Dilat(ii).Risult(iCond).Smbp(1 - 1) < IntermStress(ii, iCond).Smb(1) Then Dilat(ii).Risult(iCond).Smbp(1 - 1) = IntermStress(ii, iCond).Smb(1)
                                    If Dilat(ii).Risult(iCond).Smbp(2 - 1) < IntermStress(ii, iCond).Smb(4) Then Dilat(ii).Risult(iCond).Smbp(2 - 1) = IntermStress(ii, iCond).Smb(4) 'Psc
                                    If Dilat(ii).Risult(iCond).Smbp(3 - 1) < IntermStress(ii, iCond).Smb(5) Then Dilat(ii).Risult(iCond).Smbp(3 - 1) = IntermStress(ii, iCond).Smb(5) 'psi
                                    Dilat(ii).Risult(iCond).Smbp(4 - 1) = Dilat(ii).DilProg.Ps
                                Case Else 'pressione + dilatazione
                                    Salt = 0.7 * Dilat(ii).Risult(iCond).Smbp(1 - 1) + IntermStress(ii, iCond).Smb(2)
                                    If System.Math.Abs(Dilat(ii).Risult(iCond).Salt) < Salt Then
                                        Dim ris As Risult = Dilat(ii).Risult(iCond)
                                        ris.Salt = Salt
                                        Dilat(ii).Risult(iCond) = ris
                                    End If
                                    Dim r As Risult = Dilat(ii).Risult(iCond)
                                    r.Salt = Dilat(ii).Risult(iCond).Salt * System.Math.Sign(Dilat(ii).DilStre.Fax(iCond - 1))
                                    Dilat(ii).Risult(iCond) = r
                            End Select 'c
                    End Select 't
contS:          Next k
            Next ii
3060:       Call DisplayDilat(0, iCond, TipoDilat)
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Public Sub CiClall(ByRef TipoDilat As Short, ByRef Ricotto As Boolean)
        Dim NumEv(8) As Short
        Dim Cost3, Cost1, Akg, Cost2, Cost4 As Single
        Dim ii As Short
        Dim Amax, Amin As Single
        Dim iMin, i, IMAX As Short
        Dim Num As Short
        Dim Danno As Single
        Dim Sn As Single
        Dim iElas As Short
        Dim Testo As String
        Dim iCond1, iCond2 As Short
        Dim ZZ As Single
        Dim Param As Single
        Dim Dummy As strCiclo
        O = CType(CType(objMemb(Involucr(kLato, jInvolucr).IndObject), wn_PT).Piastra, wn_FTC)
        If TipoDilat = 7 Then Exit Sub
        Akg = 1 : If Dilat(1).DilGeom.ra = 0 Or Dilat(1).DilGeom.rb = 0 Then Akg = 4
        Select Case TipoDilat
            Case 1, 2, 6
                'Appendix 26
                '1200     Cost1 = .03: Cost2 = 2.2: Cost3 = 14.12: Cost4 = 2.17
                '         IF Dilat(1).DilProg.Mat.Classe = 1 THEN Cost1 = .011: Cost2 = 2: Cost3 = 15
                'Appendix CC
                Cost1 = 47.11 : Cost2 = 28300000.0# : Cost3 = 14.12 : Cost4 = 1.023
                If Dilat(1).DilProg.Classe = 2 Then Cost1 = 12.26 : Cost2 = 30000000.0# : Cost3 = 15.18 : Cost4 = 2.317
            Case 3
                '         Cost1 = 54000: Cost2 = 1860000!: Cost3 = 1: Cost4 = 3.4
                Cost1 = 0.02 : Cost2 = 2.5 : Cost3 = 14.2 : Cost4 = 2
                'valido solo per Nickel!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            Case 4, 5
                Cost1 = 41800 : Cost2 = 5180000.0! : Cost3 = 1 : Cost4 = 2.9
        End Select 'd
        For ii = 1 To 2
            nCicli(ii) = 0
            For i = 1 To O.Zp(1, 261)
                NumEv(i) = O.Neventip(i)
            Next
            Do
                Amax = -10000000000.0# : Amin = 10000000000.0# : iMin = 0 : IMAX = 0
                For i = 1 To O.Zp(1, 261)
                    If Dilat(ii).Risult(i).Salt > Amax And NumEv(i) > 0 Then Amax = Dilat(ii).Risult(i).Salt : IMAX = i
                    If Dilat(ii).Risult(i).Salt < Amin And NumEv(i) > 0 Then Amin = Dilat(ii).Risult(i).Salt : iMin = i
                Next
1220:           If IMAX = 0 And iMin = 0 Then Exit Do
                nCicli(ii) = nCicli(ii) + 1
                If Amin * Amax < 0 Then
                    If NumEv(IMAX) < NumEv(iMin) Then Num = NumEv(IMAX) Else Num = NumEv(iMin)
                    With Ciclo(ii, nCicli(ii))
                        .s = System.Math.Abs(Amin - Amax)
                        .Cond1 = iMin
                        .Cond2 = IMAX
                        .nCicli = Num
                    End With
                    NumEv(IMAX) = NumEv(IMAX) - Num
                    NumEv(iMin) = NumEv(iMin) - Num
                Else
                    With Ciclo(ii, nCicli(ii))
                        .s = System.Math.Abs(Amax)
                        .Cond1 = IMAX
                        .Cond2 = 0
                        .nCicli = NumEv(IMAX)
                    End With
                    NumEv(IMAX) = 0
                    If iMin <> IMAX Then
                        nCicli(ii) = nCicli(ii) + 1
                        With Ciclo(ii, nCicli(ii))
                            .s = System.Math.Abs(Amin)
                            .Cond1 = iMin
                            .Cond2 = 0
                            .nCicli = NumEv(iMin)
                        End With
                        NumEv(iMin) = 0
                    End If
                End If
            Loop
1230:   Next ii
        Danno = 0 : iElas = 287
        For ii = 1 To 2
            For i = 1 To nCicli(ii)
1232:           Sn = Ciclo(ii, i).s
                iCond1 = Ciclo(ii, i).Cond1
                iCond2 = Ciclo(ii, i).Cond2
                If ((iCond1 > 0 And O.Zp(iCond1, iElas) = 0) Or (iCond2 > 0 And O.Zp(iCond2, iElas) = 0)) And iElas = 287 Then iElas = 8
                If ((iCond1 > 0 And O.Zp(iCond1, iElas) = 0) Or (iCond2 > 0 And O.Zp(iCond2, iElas) = 0)) And iElas = 8 Then
                    Testo = Monitor.Motore.Inizio.ConvertiCr(" Il modulo elastico del dilatatore  | non è stato impostato.")
                    MessageBox.Show(Testo, "AsmeVip", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If
                If iCond1 > 0 Then
                    ZZ = O.Zp(iCond1, iElas)
                    If O.Zp(iCond2, iElas) < ZZ And iCond2 > 0 Then ZZ = O.Zp(iCond2, iElas)
                Else
                    ZZ = O.Zp(iCond2, iElas)
                End If
                Select Case TipoDilat
                    Case 1, 2, 6
                        '         Param = Sn * Cost2 / Dilat(1).DilProg.EE / 145.038
                        Param = Sn * Cost2 / ZZ
1236:                   If Param > 0 Then IntermStress(ii, i).Ciclallow = Cost1 * System.Math.Exp((System.Math.Log(Param) - Cost3) ^ 2 / Cost4) Else IntermStress(ii, i).Ciclallow = 1000000.0!
                    Case 3
                        Akg = 1 : If Not Ricotto Then Akg = 2
                        Param = Cost3 * Akg * Sn / ZZ
1237:                   If Param > Cost1 Then
                            IntermStress(ii, i).Ciclallow = (Cost2 / (Param - Cost1)) ^ Cost4
                            If IntermStress(ii, i).Ciclallow > 1000000.0! Then IntermStress(ii, i).Ciclallow = 1000000.0!
                        Else
                            IntermStress(ii, i).Ciclallow = 1000000.0!
                        End If
                    Case 4, 5
                        Param = Sn * O.Zp(0, iElas) / ZZ
                        If Param > Cost1 Then
                            IntermStress(ii, i).Ciclallow = (Cost2 / (Param - Cost1)) ^ Cost4
                        Else
                            IntermStress(ii, i).Ciclallow = 1000000.0#
                        End If
                End Select 'ea
1238:           Ciclo(ii, i).Danno = Ciclo(ii, i).nCicli / 2 / IntermStress(ii, i).Ciclallow
                Danno = Danno + Ciclo(ii, i).Danno
            Next
        Next
        For ii = 1 To 2
            For i = 1 To nCicli(ii) - 1
                For iMin = i + 1 To nCicli(ii)
                    If Ciclo(ii, iMin).Danno > Ciclo(ii, i).Danno Then
                        Dummy = Ciclo(ii, iMin)
                        Ciclo(ii, iMin) = Ciclo(ii, i)
                        Ciclo(ii, i) = Dummy
                    End If
                Next
            Next
        Next
    End Sub
    Sub DisplayDilat(ByRef mode As Short, ByRef iCond As Short, ByRef TipoDilat As Short)
        Dim Syd_Renamed As Single
        O = CType(CType(objMemb(Involucr(kLato, jInvolucr).IndObject), wn_PT).Piastra, wn_FTC)
        If TipoDilat = 7 Then Exit Sub
        With mioRis
            If Not OptimDil Then
                If mode = 1 Then '  On Error Resume Next
                    .TabStrip1.SelectedTab.Tag = setmiotag(.TabStrip1.SelectedTab.Tag, "No", 1)
                    i = 3
                    If TipoDilat > 2 And TipoDilat < 6 Then i = 4
                    Call O.RisPAGINA(i)
                    ' .Cls
                    For i = 1 To 7
                        For ii = 1 To 2
                            .Scrivi(GlobalRoutines.FormatS("#######.00", Dilat(ii).Risult(iCond).Sm(i - 1)), 8 + i, 19 + 29 * (ii - 1))
                            .Scrivi(GlobalRoutines.FormatS("#######.00", Dilat(ii).Risult(iCond).sb(i - 1)), 8 + i, 35 + 29 * (ii - 1))
                        Next
                    Next
                End If
            End If
            Sigma = O.Zp(0, 274)
            Syd_Renamed = O.Zp(0, 275)
            For k = 1 To 7
                For kk = 1 To 2
                    Dilat(kk).Risult(iCond).Fcmp(k - 1) = 0
                    Dilat(kk).Risult(iCond).Fmmp(k - 1) = 0
                    Dilat(kk).Risult(iCond).Fmbp(k - 1) = 0
                Next kk
            Next
            For i = 1 To 3
                K2 = 7
                If TipoDilat > 2 And TipoDilat < 6 Then
                    Select Case i
                        Case 1 : K2 = 5
                        Case 2 : K2 = 1
                        Case 3 : K2 = 3
                    End Select
                End If
                For k = 1 To K2
                    Select Case i
                        Case 1
                            a = Dilat(1).Risult(iCond).Scmp(k - 1) : If Dilat(2).Risult(iCond).Scmp(k - 1) > a Then a = Dilat(2).Risult(iCond).Scmp(k - 1)
                            If TipoDilat > 2 And TipoDilat < 6 Then
                                If k = 3 Then Sigma = O.Zp(iCond, 276) ' ammiss rinf. collare
                                If k = 4 Then Sigma = O.Zp(iCond, 278) ' ammiss anelli
                                If k = 5 Then Sigma = O.Zp(iCond, 280) ' ammiss bulloni
                            End If
                            If mode = 1 Then
                                '   If a > Sigma Then
                                'Color 16, 7
                                '      .Scrivi ">", 17 + i, 27 + (k - 1) * 11, 1
                                'Color 7, 0
                                '   End If
                            End If
                            If Sigma = 0 Then Sigma = 1
                            Dilat(1).Risult(iCond).Fcmp(k - 1) = Dilat(1).Risult(iCond).Scmp(k - 1) / Sigma
                            Dilat(2).Risult(iCond).Fcmp(k - 1) = Dilat(2).Risult(iCond).Scmp(k - 1) / Sigma
                            Ak = 1
                            PrintVal(mode, TipoDilat)
                            Sigma = O.Zp(iCond, 274)
                        Case 2
                            a = Dilat(1).Risult(iCond).Smmp(k - 1) : If Dilat(2).Risult(iCond).Smmp(k - 1) > a Then a = Dilat(2).Risult(iCond).Smmp(k - 1)
                            '      IF Mode = 1 THEN IF a > Sigma THEN LOCATE 17 + i, 30 + (k - 1) * 11: COLOR 16, 7: PRINT ">"; : COLOR 7, 0
                            Dilat(1).Risult(iCond).Fmmp(k - 1) = Dilat(1).Risult(iCond).Smmp(k - 1) / Sigma
                            Dilat(2).Risult(iCond).Fmmp(k - 1) = Dilat(2).Risult(iCond).Smmp(k - 1) / Sigma
                            Ak = 1
                            PrintVal(mode, TipoDilat)
                        Case 3
                            If TipoDilat > 2 And TipoDilat < 6 Then
                                If k = 2 Then Sigma = Dilat(1).Risult(iCond).Smbp(4 - 1)
                                If k = 3 Then k = 4 : Sigma = 1000 * Dilat(1).Risult(iCond).Smbp(4 - 1)
                            End If
                            a = Dilat(1).Risult(iCond).Smbp(k - 1) : If Dilat(2).Risult(iCond).Smbp(k - 1) > a Then a = Dilat(2).Risult(iCond).Smbp(k - 1)
                            If TipoDilat < 3 Or TipoDilat = 6 Then
                                Ak = 1.5
                                If Dilat(1).DilGeom.ra > 0 Then
                                    If (k = 3 Or k = 5) Then Ak = 3
                                    If k = 4 And (Dilat(1).DilGeom.id - (Dilat(1).DilGeom.g + 2 * Dilat(1).DilGeom.TE)) / 2 - 2 * Dilat(1).DilGeom.ra < 6 * Dilat(1).DilGeom.TE Then Ak = 3
                                End If
                            Else
                                Ak = 3
                                If Problem(O.IndProbl).mart Then Ak = 1.5
                                If k > 1 Then Ak = 1
                            End If
                            '      IF Mode = 1 THEN IF a > Sigma * ak THEN LOCATE 17 + i, 30 + (k - 1) * 11: COLOR 16, 7: PRINT ">"; : COLOR 7, 0
                            If Not (TipoDilat > 2 And TipoDilat < 6 And k > 1) Then
                                Dilat(1).Risult(iCond).Fmbp(k - 1) = Dilat(1).Risult(iCond).Smbp(k - 1) / Sigma / Ak
                                Dilat(2).Risult(iCond).Fmbp(k - 1) = Dilat(2).Risult(iCond).Smbp(k - 1) / Sigma / Ak
                            End If
                            If TipoDilat > 2 And TipoDilat < 6 Then
                                Select Case k
                                    Case 1
                                        PrintVal(mode, TipoDilat)
                                    Case 2, 4
                                        PrintVal1(mode, TipoDilat)
                                    Case 5 : For kk = 2 To 5
                                            Dilat(1).Risult(iCond).Fmbp(kk - 1) = 0
                                            Dilat(2).Risult(iCond).Fmbp(kk - 1) = 0
                                        Next
                                        GoTo Conti
                                End Select 'f
                                Sigma = O.Zp(iCond, 274)
                            Else
                                PrintVal(mode, TipoDilat)
                            End If
                    End Select 'g
Contk:          Next k
Conti:      Next i
            If OptimDil Then Exit Sub
            If mode = 1 Then
                'If TipoDilat > 2 And TipoDilat < 6 Then
                '   iX = 18: iy = 21
                'Else
                iX = 18 : iy = 21 '25
                'End If
                a = Dilat(1).Risult(iCond).Salt
                If Dilat(2).Risult(iCond).Salt > a Then a = Dilat(2).Risult(iCond).Salt
                .Scrivi(GlobalRoutines.FormatS("#######.", System.Math.Abs(a)), iy, iX)
                .Scrivi(GlobalRoutines.FormatS("######.", Sigma), 17, 5)
                If TipoDilat > 2 And TipoDilat < 6 Then
                    i = 4
                    Sigma = Dilat(1).Risult(iCond).Smbp(4 - 1)
                    For k = 2 To 3
                        a = Dilat(1).Risult(iCond).Smbp(k + 1 - 1) : If Dilat(2).Risult(iCond).Smbp(k + 1 - 1) > a Then a = Dilat(2).Risult(iCond).Smbp(k + 1 - 1)
                        PrintVal1(mode, TipoDilat)
                    Next
                End If
                '    frmRis.Show
            End If
        End With
    End Sub
    Private Sub PrintVal1(ByVal mode As Short, ByVal TipoDilat As Short)
        If OptimDil Then Exit Sub
        With mioRis
            If mode = 1 Then
                If k = 2 Then
                    If a < Sigma Then
                        'Color 16, 7
                        .TabStrip1.SelectedTab.Tag = "rosso"
                        .Scrivi("<", 17 + i, 45, 1)
                        'Color 7, 0
                    End If
                    iy = 17 + i : iX = 36
                Else
                    iy = 17 + i : iX = 46
                End If
                Select Case TipoDilat
                    Case 3
                        If a < 999999.0! Then .Scrivi(GlobalRoutines.FormatS("######.", a), iy, iX) Else .Scrivi("$$$$$$", iy, iX)
                    Case 4
                        If i = 3 Then
                            If a < 999999.0! Then .Scrivi(GlobalRoutines.FormatS("######.", a), iy, iX) Else .Scrivi("$$$$$$", iy, iX)
                        Else
                            iy = 17 + i : iX = 36
                            .Scrivi(Space(25), iy, iX)
                        End If
                    Case 5
                        iy = 17 + i : iX = 36
                        .Scrivi(Space(25), iy, iX)
                End Select 'h
            End If
        End With
    End Sub
    Private Sub PrintVal(ByVal mode As Short, ByVal TipoDilat As Short)
        If OptimDil Then Exit Sub
        With mioRis
            If mode = 1 Then
                If TipoDilat > 2 And TipoDilat < 6 Then
                    kk = k
                Else
                    If k = 1 Or k = 7 Then Exit Sub
                    kk = k - 1
                End If
                If a > Sigma * Ak Then
                    .TabStrip1.SelectedTab.Tag = "rosso"
                    .Scrivi(">", 17 + i, 27 + (kk - 1) * 11, 1)
                End If
                iy = 17 + i : iX = 19 + (kk - 1) * 11
                If a < 999999.0! Then .Scrivi(GlobalRoutines.FormatS("######.", a), iy, iX) Else .Scrivi("$$$$$$", iy, iX)
            End If
        End With
    End Sub
    Sub GeomDilat(ByRef MembDilat As Grafica.Dilat, ByRef TipoDilat As Short)
        Dim i1, i2 As Short
        O = CType(CType(objMemb(Involucr(kLato, jInvolucr).IndObject), wn_PT).Piastra, wn_FTC)
        With MembDilat
            Dilat(1).DilProg.Corr = 0
            Dilat(2).DilProg.Corr = 0
            If .SottoTipo < 3 Or .SottoTipo = 6 Then Dilat(2).DilProg.Corr = O.Zp(1, 19)
            i1 = 1 : i2 = 2 : SpessCB = .SpesCol
            Geom(i1, i2, MembDilat, TipoDilat)
            If TipoDilat > 1 Or .nOnde = 1 Then Exit Sub
            Dilat(3).DilProg.Corr = Dilat(1).DilProg.Corr
            Dilat(4).DilProg.Corr = Dilat(2).DilProg.Corr
            i1 = 3 : i2 = 4 : SpessCB = 0
            Geom(i1, i2, MembDilat, TipoDilat)
        End With
        Exit Sub
    End Sub
    Private Sub Geom(ByVal i1 As Short, ByVal i2 As Short, ByRef MembDilat As Grafica.Dilat, ByVal TipoDilat As Short)
        Dim i As Integer
        With MembDilat
            For i = i1 To i2
                Dilat(i).DilGeom.TE = .Spess - Dilat(i).DilProg.Corr
                If .SottoTipo = 2 Then
                    Dilat(i).DilGeom.ra = 0
                    Dilat(i).DilGeom.rb = 0
                Else
                    Dilat(i).DilGeom.ra = .Raggio
                    Dilat(i).DilGeom.rb = .Raggio
                End If
                If .SottoTipo = 1 Then Dilat(i).DilGeom.rb = .SezRinf
                If Dilat(i).DilGeom.rb > 0 Then Dilat(i).DilGeom.rb = Dilat(i).DilGeom.rb + Dilat(i).DilProg.Corr
                Dilat(i).DilGeom.g = .DIMIN + 2 * Dilat(i).DilProg.Corr
                Dilat(i).DilGeom.id = .DIMAX + 2 * Dilat(i).DilProg.Corr
                If TipoDilat = 1 Or TipoDilat = 6 Then
                    Dilat(i).DilGeom.fa = .Colletto
                    Dilat(i).DilGeom.fb = .Colletto '/ 2 'ATT.
                    If .SezRinf > 0 Then
                        Dilat(i).DilGeom.lo = .SezTira ' .AlungC
                    Else
                        Dilat(i).DilGeom.lo = 0
                    End If
                    'Dilat(i).DilGeom.lo = 0
                Else
                    Dilat(i).DilGeom.fa = 0
                    Dilat(i).DilGeom.fb = 0
                    Dilat(i).DilGeom.li = .Colletto
                    Dilat(i).DilGeom.lo = .Colletto '/ 2 'ATT.
                End If
                If TipoDilat = 1 Then
                    Dilat(i).DilGeom.to_Renamed = .Spess - Dilat(i).DilProg.Corr
                    If SpessCB > 0 Then
                        Dilat(i).DilGeom.ts = SpessCB - Dilat(i).DilProg.Corr
                    Else
                        Dilat(i).DilGeom.ts = .Spess - Dilat(i).DilProg.Corr
                    End If
                ElseIf TipoDilat < 6 Then
                    Dilat(i).DilGeom.ts = Dilat(i).DilGeom.TE
                    Dilat(i).DilGeom.to_Renamed = Dilat(i).DilGeom.TE
                Else
                    Dilat(i).DilGeom.li = .LungCol
                    Dilat(i).DilGeom.ts = SpessCB - Dilat(i).DilProg.Corr
                    Dilat(i).DilGeom.to_Renamed = .SezRinf - Dilat(i).DilProg.Corr
                End If
                Dilat(i).DilGeom.nOnde = .nOnde
                Dilat(i).DilGeom.nPli = .nPli
                If TipoDilat > 2 And TipoDilat < 6 Then
                    Dilat(i).DilGeom.to_Renamed = SpessCB
                    Dilat(i).DilGeom.lo = .LungCol
                    Dilat(i).DilGeom.fa = .SezRinf
                    Dilat(i).DilGeom.fb = .SezTira
                End If
            Next
        End With
    End Sub
    Sub GeomEquiv(ByRef TipoDilat As Short)
        Dim i As Short
        Dim Dm, Q, Sq As Single
        If TipoDilat > 2 And TipoDilat < 6 Then
            For i = 1 To 2
                With Dilat(i)
                    '   .DilEqui.w = (.DilGeom.ID - .DilGeom.g - .DilGeom.tE * .DilGeom.nPli) / 2
                    .DilEqui.W = (.DilGeom.id - .DilGeom.g) / 2
                    Dm = .DilGeom.g + .DilEqui.W + .DilGeom.TE * .DilGeom.nPli
                    Q = 2 * (.DilGeom.ra + .DilGeom.ra + .DilGeom.TE * .DilGeom.nPli)
                    .DilEqui.ya = Q / 2 / .DilEqui.W
                    .DilEqui.yb = Q / 2.2 / System.Math.Sqrt(Dm * .DilGeom.TE)
                    .DilEqui.a = (.DilGeom.g + .DilGeom.TE) / 2
                    .DilEqui.ta = .DilGeom.TE * System.Math.Sqrt(.DilGeom.g / Dm)
                End With
            Next
            Exit Sub
        End If
        For i = 1 To 4
            With Dilat(i)
                If .DilGeom.ra > 0 Then
                    .DilEqui.ta = .DilGeom.TE
                Else
                    .DilEqui.ta = .DilGeom.ts
                End If
                If .DilGeom.rb > 0 Then
                    .DilEqui.tb = .DilGeom.TE
                Else
                    .DilEqui.tb = .DilGeom.to_Renamed
                End If
                .DilEqui.a = (.DilGeom.g + .DilEqui.ta) / 2
                .DilEqui.b = (.DilGeom.id + 2 * .DilGeom.to_Renamed - .DilEqui.tb) / 2 '- (4 - pi) * (.DilGeom.ra + .DilGeom.rb) / 4 ed8th
                .DilEqui.la = .DilGeom.fa + .DilGeom.ra + .DilGeom.TE / 2 'ed8th
                .DilEqui.lb = .DilGeom.fb + .DilGeom.rb + .DilGeom.TE / 2 'ed8th
                .DilEqui.ya = .DilEqui.la + .DilGeom.li
                .DilEqui.yb = .DilEqui.lb + .DilGeom.lo
                Sq = 2 * System.Math.Sqrt(.DilEqui.a * .DilEqui.ta)
                Sq = 2 * System.Math.Sqrt(.DilEqui.b * .DilEqui.tb)
            End With
        Next
    End Sub
    Sub SintDil(ByRef nn As Short, ByRef TipoDilat As Short, ByRef iStartSint As Short)
        Dim ifl, i As Short
        Dim s As Single
        Dim kk, ii, n As Short
        Dim Cod As String
        Dim d As Single
        Dim iy, iX, iColor As Short
        Dim DannoMantello As Single
        O = CType(CType(objMemb(Involucr(kLato, jInvolucr).IndObject), wn_PT).Piastra, wn_FTC)
        iStart = iStartSint
        iEnd = nn : If iEnd > 4 And iStart = 1 Then iEnd = 4
Rif:    'Color 7, 0
        With mioRis
            .mygraphics.Clear(Color.White)
            .TabStrip1.SelectedTab.Tag = setmiotag(.TabStrip1.SelectedTab.Tag, "No", 1)
            On Error GoTo 0
            ifl = FreeFile()
            If TipoDilat < 3 Or TipoDilat = 6 Then
                FileOpen(ifl, RTrim(Monitor.Motore.Inizio.Archdir) & "\WN5\SINTDIL.FTC", OpenMode.Input, , OpenShare.Shared)
            Else
                FileOpen(ifl, RTrim(Monitor.Motore.Inizio.Archdir) & "\WN5\SINTDEJ.FTC", OpenMode.Input, , OpenShare.Shared)
            End If
            GlobalRoutines.FormatS("non|")
            For i = 1 To 3
                Rig = LineInput(ifl)
                iy = iy + 1
                .Scrivi(Rig, iy)
            Next
            '---------------------------------------------
            Rig = LineInput(ifl)
            iy = iy + 1
            .Scrivi(Left(Rig, 23), iy)
            For i = iStart To iEnd
                Rig1 = Mid(Rig, 24 + 2 * (i - iStart) * 7, 7)
                .Scrivi(GlobalRoutines.FormatS(Rig1, i), -1)
                Rig1 = Mid(Rig, 24 + (2 * (i - iStart) + 1) * 7, 7)
                .Scrivi(GlobalRoutines.FormatS(Rig1, i), -1)
            Next
            CompletaDil()
            '---------------------------------------
            Rig = LineInput(ifl)
            iy = iy + 1
            .Scrivi(Rig, iy, 0)
            Rig = LineInput(ifl)
            iy = iy + 1
            .Scrivi(Rig, iy)
            '----------------------------------------------------
            For k = 1 To 5 'k=5 fasteners
                Rig = LineInput(ifl)
                iy = iy + 1
                .Scrivi(Left(Rig, 23), iy)
                For i = iStart To iEnd
                    For ii = 1 To 2
                        iColor = 0
                        If TipoDilat < 3 Or TipoDilat = 6 Then
                            kk = k + 1
                            s = Dilat(ii).Risult(i).Smmp(kk - 1) : If Dilat(ii).Risult(i).Scmp(kk - 1) > s Then s = Dilat(ii).Risult(i).Scmp(kk - 1)
                            If Dilat(ii).Risult(i).Fmmp(kk - 1) > 1 Or Dilat(ii).Risult(i).Fcmp(kk - 1) > 1 Then iColor = 1
                        Else
                            s = Dilat(ii).Risult(i).Scmp(k - 1)
                            If Dilat(ii).Risult(i).Fcmp(k - 1) > 1 Then iColor = 1
                        End If
                        Rig1 = Mid(Rig, 24 + (2 * (i - iStart) + ii - 1) * 7, 7)
                        If iColor = 1 Then .TabStrip1.SelectedTab.Tag = setmiotag(.TabStrip1.SelectedTab.Tag, "rosso", 1)
                        .Scrivi(GlobalRoutines.FormatS(Rig1, s), -1, , iColor)
                        iColor = 0
                    Next ii
                Next i
                CompletaDil()
                Rig = LineInput(ifl)
                iy = iy + 1
                .Scrivi(Left(Rig, 23), iy)
                If TipoDilat < 3 Or TipoDilat = 6 Then kk = k + 1 Else kk = k
                For i = iStart To iEnd
                    For ii = 1 To 2
                        s = Dilat(ii).Risult(i).Smbp(kk - 1)
                        Rig1 = Mid(Rig, 24 + (2 * (i - iStart) + ii - 1) * 7, 7)
                        If TipoDilat < 3 Or TipoDilat = 6 Or k = 1 Then
                            iColor = 0
                            If Dilat(ii).Risult(i).Fmbp(kk - 1) > 1 Then iColor = 1
                            If iColor = 1 Then .TabStrip1.SelectedTab.Tag = setmiotag(.TabStrip1.SelectedTab.Tag, "rosso", 1)
                            .Scrivi(GlobalRoutines.FormatS(Rig1, s), -1, , iColor)
                            iColor = 0
                        Else
                            Call O.Pulisci(Rig1)
                            .Scrivi(Rig1, -1)
                        End If
                    Next ii
                Next i
                CompletaDil()
            Next k
            If TipoDilat > 2 And TipoDilat < 5 Then
                iy = 14 : iX = 1
                .Scrivi("Critical pr.Psc [psi]", iy, iX)
                For i = iStart To iEnd
                    For ii = 1 To 2
                        s = Dilat(ii).Risult(i).Smbp(2 - 1) 'critical pressure??
                        iColor = 0
                        If System.Math.Abs(s) < System.Math.Abs(Dilat(ii).Risult(i).Smbp(4 - 1)) Then iColor = 1
                        If iColor = 1 Then .TabStrip1.SelectedTab.Tag = setmiotag(.TabStrip1.SelectedTab.Tag, "rosso", 1)
                        iy = 14 : iX = 23 + 7 * ((i - iStart) * 2 + ii - 1)
                        .Scrivi(GlobalRoutines.FormatS("######", s), iy, iX, iColor)
                        iColor = 0
                    Next ii
                Next i
            End If
            iy = 16 : iX = 1
            If TipoDilat = 3 Then
                .Scrivi("Critical pr.psi [psi]", iy, iX)
                For i = iStart To iEnd
                    For ii = 1 To 2
                        s = Dilat(ii).Risult(i).Smbp(3 - 1)
                        iColor = 0
                        If System.Math.Abs(s) < System.Math.Abs(Dilat(ii).Risult(i).Smbp(4 - 1)) Then iColor = 1
                        If iColor = 1 Then .TabStrip1.SelectedTab.Tag = setmiotag(.TabStrip1.SelectedTab.Tag, "rosso", 1)
                        iy = 16 : iX = 23 + 7 * ((i - iStart) * 2 + ii - 1)
                        .Scrivi(GlobalRoutines.FormatS("######", s), iy, iX, iColor)
                        iColor = 0
                    Next ii
                Next i
            End If
            '----------------------------------------------
            Rig = LineInput(ifl)
            iy = iy + 1
            .Scrivi(Rig, iy)
            Rig = LineInput(ifl)
            iy = iy + 1
            .Scrivi(Left(Rig, 23), iy)
            For i = iStart To iEnd
                For ii = 1 To 2
                    s = Math.Abs(Dilat(ii).Risult(i).Salt / 1000)
                    Rig1 = Mid(Rig, 24 + (2 * (i - iStart) + ii - 1) * 7, 7)
                    .Scrivi(GlobalRoutines.FormatS(Rig1, s), -1)
                Next ii
            Next i
            CompletaDil()
            '----------------------------------------------
            Rig = LineInput(ifl)
            iy = iy + 1
            .Scrivi(Left(Rig, 23), iy)
            For i = iStart To iEnd
                For ii = 1 To 2
                    n = O.Neventip(i)
                    Rig1 = Mid(Rig, 24 + (2 * (i - iStart) + ii - 1) * 7, 7)
                    .Scrivi(GlobalRoutines.FormatS(Rig1, n), -1)
                Next ii
            Next i
            CompletaDil()
            '----------------------------------------------
            Rig = LineInput(ifl)
            iy = iy + 1
            .Scrivi(Left(Rig, 23), iy)
            For i = iStart To iEnd
                For ii = 1 To 2
                    If Ciclo(ii, i).nCicli > 0 Then
                        Cod = "(" & LTrim(Str(Ciclo(ii, i).Cond1)) & "-" & LTrim(Str(Ciclo(ii, i).Cond2)) & ")"
                    Else
                        Cod = Space(6)
                    End If
                    Rig1 = Mid(Rig, 24 + (2 * (i - iStart) + ii - 1) * 7, 7)
                    .Scrivi(GlobalRoutines.FormatS(Rig1, Cod), -1)
                Next ii
            Next i
            CompletaDil()
            '----------------------------------------------
            Rig = LineInput(ifl)
            iy = iy + 1
            .Scrivi(Left(Rig, 23), iy)
            For i = iStart To iEnd
                For ii = 1 To 2
                    n = Ciclo(ii, i).nCicli / 2
                    Rig1 = Mid(Rig, 24 + (2 * (i - iStart) + ii - 1) * 7, 7)
                    .Scrivi(GlobalRoutines.FormatS(Rig1, n), -1)
                Next ii
            Next i
            CompletaDil()
            '----------------------------------------------
            Rig = LineInput(ifl)
            iy = iy + 1
            .Scrivi(Left(Rig, 23), iy)
            For i = iStart To iEnd
                For ii = 1 To 2
                    d = Ciclo(ii, i).Danno
                    If d > 0.99999 Then d = 0.99999
                    'Color 0, 7
                    Rig1 = Mid(Rig, 24 + (2 * (i - iStart) + ii - 1) * 7, 7)
                    .Scrivi(GlobalRoutines.FormatS(Rig1, d), -1)
                    'Color 7, 0
                Next ii
            Next i
            CompletaDil()
            Do
                Rig1 = LineInput(ifl)
                If GlobalRoutines.ValVir(Rig1) = -1 Then Exit Do
                iy = iy + 1
                .Scrivi(Rig1, iy)
            Loop
            '----------------------------------------------------
        End With
        FileClose(ifl)
        'FormatS "|"
        For ii = 1 To 2
            For i = iStart To iEnd
                With Dilat(ii).Risult(i)
                    If .Fcmp(1 - 1) > DannoMantello Then DannoMantello = .Fcmp(1 - 1)
                    If .Fmbp(1 - 1) > DannoMantello Then DannoMantello = .Fmbp(1 - 1)
                    If .Fmmp(1 - 1) > DannoMantello Then DannoMantello = .Fmmp(1 - 1)
                    For kk = 2 To 7
                        If .Fcmp(k - 1) > 1 Then DannoMantello = 0
                        If .Fmbp(k - 1) > 1 Then DannoMantello = 0
                        If .Fmmp(k - 1) > 1 Then DannoMantello = 0
                    Next
                End With
            Next i
        Next ii
        If DannoMantello > 1 Then
            MostraAiuto(IDH_DIL_DANNOMANTELLO, RoutBase1.ChiaviMess.MessInformation + RoutBase1.ChiaviMess.MessHelpButton + RoutBase1.ChiaviMess.MessOkOnly)
        End If
        Exit Sub
RedoDil:
        '   frmRis.Show
        Select Case mioRis.Risposta
            Case "F1" '59, 60: GoTo Rif 'F1
                GoTo Rif
            Case "F8" '66: 'F8
                Call O.StampaSp()
                Exit Sub
            Case "F3" '61: Exit Sub 'F3
                Exit Sub
            Case Else : GoTo RedoDil
        End Select 'k
    End Sub
    Private Sub CompletaDil()
        If iEnd - iStart + 1 < 4 Then
            For i = 2 * (iEnd - iStart + 1) + 1 To 8
                Rig1 = Mid(Rig, 24 + (i - 1) * 7, 7)
                Call O.Pulisci(Rig1)
                mioRis.Scrivi(Rig1, -1)
            Next
        End If
        mioRis.x = 0
    End Sub
    Public Overloads Function Leggi(ByVal ifl As Short) As Boolean
        Leggi = True
        FileGet(ifl, Dilat(1))
        FileGet(ifl, Dilat(2))
    End Function
    Public Overloads Function Leggi(ByVal fs As FileStream) As Boolean
        Lancio.Legacy.Serialization.LegacyBinarySerializer.EnsureEnabled()
        Dim bf As New Lancio.Legacy.Serialization.LegacyBinarySerializer
        Leggi = True
        Dilat(1) = CType(bf.Deserialize(fs), strDilat)
        Dilat(2) = CType(bf.Deserialize(fs), strDilat)
    End Function
    Public Sub Scrivi(ByVal fs As FileStream)
        Lancio.Legacy.Serialization.LegacyBinarySerializer.EnsureEnabled()
        Dim bf As New Lancio.Legacy.Serialization.LegacyBinarySerializer
        bf.Serialize(fs, Dilat(1))
        bf.Serialize(fs, Dilat(2))
    End Sub
    Public Sub Decodif(ByRef Posi As Short, ByRef Decoded As Single, ByRef Decode1 As Single, ByRef Decode2 As Single, ByRef Decode3 As Single, Optional ByRef iCond As Short = 1, Optional ByRef Decode4 As Single = 0, Optional ByRef Decode5 As Single = 0)
        Dim g As Single
        Dim kkk As Short
        Dim Fax, PSP As Single
        O = CType(CType(objMemb(Involucr(kLato, jInvolucr).IndObject), wn_PT).Piastra, wn_FTC)
        Select Case Posi
            Case 900 : Decoded = Dilat(1).DilGeom.id
            Case 901 : Decoded = Dilat(1).DilGeom.g
            Case 902 : Decoded = Dilat(1).DilGeom.TE
            Case 903 : Decoded = Dilat(1).DilGeom.rb
            Case 904 : Decoded = Dilat(1).DilGeom.ra
            Case 905 : Decoded = Dilat(1).DilGeom.fb
            Case 906 : Decoded = Dilat(1).DilGeom.fa
            Case 907 : Decoded = Dilat(1).DilGeom.lo
            Case 908 : Decoded = Dilat(1).DilGeom.to_Renamed
            Case 909 : Decoded = Dilat(1).DilGeom.li
            Case 910 : Decoded = Dilat(1).DilGeom.ts
            Case 911 : Decoded = Dilat(2).DilProg.Corr
            Case 912 : Decoded = Dilat(1).DilGeom.nOnde
            Case 913 : Decoded = Dilat(1).DilEqui.ta : Decode1 = Dilat(2).DilEqui.ta
            Case 914 : Decoded = Dilat(1).DilEqui.tb : Decode1 = Dilat(2).DilEqui.tb
            Case 915 : Decoded = Dilat(1).DilEqui.a : Decode1 = Dilat(2).DilEqui.a
            Case 916 : Decoded = Dilat(1).DilEqui.b : Decode1 = Dilat(2).DilEqui.b
            Case 917 : Decoded = Dilat(1).DilEqui.la : Decode1 = Dilat(2).DilEqui.la
            Case 918 : Decoded = Dilat(1).DilEqui.lb : Decode1 = Dilat(2).DilEqui.lb
            Case 919 : Decoded = Dilat(1).DilEqui.ya : Decode1 = Dilat(2).DilEqui.ya
            Case 920 : Decoded = Dilat(1).DilEqui.yb : Decode1 = Dilat(2).DilEqui.yb
            Case 921 : Decoded = Dilat(1).DilFlex.betaa : Decode1 = Dilat(2).DilFlex.betaa
            Case 922 : Decoded = Dilat(1).DilFlex.betab : Decode1 = Dilat(2).DilFlex.betab
            Case 923 : Decoded = Dilat(1).DilFlex.Da : Decode1 = Dilat(2).DilFlex.Da
            Case 924 : Decoded = Dilat(1).DilFlex.db : Decode1 = Dilat(2).DilFlex.db
            Case 925 : Decoded = Dilat(1).DilFlex.DE : Decode1 = Dilat(2).DilFlex.DE
            Case 926 : Decoded = Dilat(1).DilFlex.Omega(1 - 1) : Decode1 = Dilat(2).DilFlex.Omega(1 - 1)
            Case 927 : Decoded = Dilat(1).DilFlex.Omega(2 - 1) : Decode1 = Dilat(2).DilFlex.Omega(2 - 1)
            Case 928 : Decoded = Dilat(1).DilFlex.j(1 - 1, 1 - 1) : Decode1 = Dilat(2).DilFlex.j(1 - 1, 1 - 1) : Decode2 = Dilat(1).DilFlex.j(1 - 1, 2 - 1) : Decode3 = Dilat(2).DilFlex.j(1 - 1, 2 - 1)
            Case 929 : Decoded = Dilat(1).DilFlex.j(2 - 1, 1 - 1) : Decode1 = Dilat(2).DilFlex.j(2 - 1, 1 - 1) : Decode2 = Dilat(1).DilFlex.j(2 - 1, 2 - 1) : Decode3 = Dilat(2).DilFlex.j(2 - 1, 2 - 1)
            Case 930 : Decoded = Dilat(1).DilFlex.Z(1 - 1) : Decode1 = Dilat(2).DilFlex.Z(1 - 1) : Decode2 = Dilat(1).DilFlex.Z(2 - 1) : Decode3 = Dilat(2).DilFlex.Z(2 - 1)
            Case 931 : Decoded = Dilat(1).DilFlex.k(0, 1 - 1) : Decode1 = Dilat(2).DilFlex.k(0, 1 - 1) : Decode2 = Dilat(1).DilFlex.k(0, 2 - 1) : Decode3 = Dilat(2).DilFlex.k(0, 2 - 1)
            Case 932 : Decoded = Dilat(1).DilFlex.k(1, 1 - 1) : Decode1 = Dilat(2).DilFlex.k(1, 1 - 1) : Decode2 = Dilat(1).DilFlex.k(1, 2 - 1) : Decode3 = Dilat(2).DilFlex.k(1, 2 - 1)
            Case 933 : Decoded = Dilat(1).DilFlex.k(2, 1 - 1) : Decode1 = Dilat(2).DilFlex.k(2, 1 - 1) : Decode2 = Dilat(1).DilFlex.k(2, 2 - 1) : Decode3 = Dilat(2).DilFlex.k(2, 2 - 1)
            Case 934 : Decoded = Dilat(1).DilFlex.k(3, 1 - 1) : Decode1 = Dilat(2).DilFlex.k(3, 1 - 1) : Decode2 = Dilat(1).DilFlex.k(3, 2 - 1) : Decode3 = Dilat(2).DilFlex.k(3, 2 - 1)
            Case 935 To 942
                kkk = Posi - 934
                Decoded = c(kkk, 1, 1) : Decode1 = c(kkk, 1, 2) : Decode2 = c(kkk, 2, 1) : Decode3 = c(kkk, 2, 2)
            Case 943 : Decoded = Dilat(1).DilFlex.E(1 - 1) : Decode1 = Dilat(2).DilFlex.E(1 - 1) : Decode2 = Dilat(1).DilFlex.E(2 - 1) : Decode3 = Dilat(2).DilFlex.E(2 - 1)
            Case 944 : Decoded = Dilat(1).DilFlex.y(1 - 1) : Decode1 = Dilat(2).DilFlex.y(2 - 1)
            Case 945 : Decoded = Dilat(1).DilFlex.y(2 - 1) : Decode1 = Dilat(2).DilFlex.y(2 - 1)
            Case 946 : Decoded = Dilat(1).DilEqui.a ^ 2 / (Dilat(1).DilEqui.b ^ 2 - Dilat(1).DilEqui.a ^ 2) : Decode1 = Dilat(2).DilEqui.a ^ 2 / (Dilat(2).DilEqui.b ^ 2 - Dilat(2).DilEqui.a ^ 2)
            Case 947 : Decoded = Dilat(1).DilEqui.b / Dilat(1).DilEqui.a : Decode1 = Dilat(2).DilEqui.b / Dilat(2).DilEqui.a
            Case 948 To 955
                kkk = Posi - 947
                Decoded = Dilat(1).DilFlex.x(kkk - 1) : Decode1 = Dilat(2).DilFlex.x(kkk - 1)
            Case 956 : Decoded = Dilat(1).DilFlex.xx : Decode1 = Dilat(2).DilFlex.xx
            Case 957 : Decoded = Dilat(1).DilFlex.q1 : Decode1 = Dilat(2).DilFlex.q1
            Case 958 : Decoded = Dilat(1).DilFlex.q2 : Decode1 = Dilat(2).DilFlex.q2
            Case 959 : Decoded = Dilat(1).DilFlex.q3 : Decode1 = Dilat(2).DilFlex.q3
            Case 960
                g = Dilat(1).DilEqui.a / Dilat(1).DilEqui.b : Decoded = g
                g = Dilat(2).DilEqui.a / Dilat(2).DilEqui.b : Decode1 = g
            Case 961
                g = Dilat(1).DilEqui.a / Dilat(1).DilEqui.b
                Decoded = g ^ 4 / (1 - g ^ 2) * System.Math.Log(g)
                g = Dilat(2).DilEqui.a / Dilat(2).DilEqui.b : Decode1 = g
                Decode1 = g ^ 4 / (1 - g ^ 2) * System.Math.Log(g)
            Case 962 : Decoded = Dilat(1).DilFlex.m1 : Decode1 = Dilat(2).DilFlex.m1
            Case 963 : Decoded = Dilat(1).DilFlex.m2 : Decode1 = Dilat(2).DilFlex.m2
            Case 964 : Decoded = Dilat(1).DilFlex.m3 : Decode1 = Dilat(2).DilFlex.m3
            Case 965 : Decoded = Dilat(1).DilFlex.Sj : Decode1 = Dilat(2).DilFlex.Sj
            Case 966 To 972
                Decode2 = Dilat(Decode4).DilEqui.a / inc * Decoded / 2
            Case 973
                Decoded = IntermStress(1, iCond).Za
                Decode1 = IntermStress(2, iCond).Za
            Case 974
                Decoded = IntermStress(1, iCond).Zb
                Decode1 = IntermStress(2, iCond).Zb
            Case 975
                Decoded = IntermStress(1, iCond).thetaa
                Decode1 = IntermStress(2, iCond).thetaa
            Case 976
                Decoded = IntermStress(1, iCond).thetab
                Decode1 = IntermStress(2, iCond).thetab
            Case 977 : Decoded = Dilat(1).DilStre.Ma : Decode1 = Dilat(2).DilStre.Ma
            Case 978 : Decoded = Dilat(1).DilStre.Mb : Decode1 = Dilat(2).DilStre.Mb
            Case 979
                Decoded = IntermStress(1, iCond).R(1) * inc
                Decode1 = IntermStress(1, iCond).R(2) * inc
                Decode2 = IntermStress(1, iCond).R(3) * inc
            Case 981
                Decoded = IntermStress(2, iCond).R(1) * inc
                Decode1 = IntermStress(2, iCond).R(2) * inc
                Decode2 = IntermStress(2, iCond).R(3) * inc
            Case 980
                Decoded = IntermStress(1, iCond).Smb(3) - IntermStress(1, iCond).Smm(3)
                Decode1 = IntermStress(1, iCond).Smb(4) - IntermStress(1, iCond).Smm(4)
                Decode2 = IntermStress(1, iCond).Smb(5) - IntermStress(1, iCond).Smm(5)
            Case 982
                Decoded = IntermStress(2, iCond).Smb(3) - IntermStress(1, iCond).Smm(3)
                Decode1 = IntermStress(2, iCond).Smb(4) - IntermStress(1, iCond).Smm(4)
                Decode2 = IntermStress(2, iCond).Smb(5) - IntermStress(1, iCond).Smm(5)
            Case 983
                Decoded = IntermStress(1, iCond).Smm(3)
                Decode1 = IntermStress(1, iCond).Smm(4)
                Decode2 = IntermStress(1, iCond).Smm(5)
            Case 984
                Decoded = IntermStress(2, iCond).Smm(3)
                Decode1 = IntermStress(2, iCond).Smm(4)
                Decode2 = IntermStress(2, iCond).Smm(5)
            Case 985 : Decoded = Dilat(1).DilEqui.a / inc : Decode1 = Dilat(2).DilEqui.a / inc : Decode2 = Dilat(1).DilEqui.b / inc : Decode3 = Dilat(2).DilEqui.b / inc
            Case 986 : Decoded = Dilat(1).DilProg.Ea : Decode1 = Dilat(2).DilProg.Ea : Decode2 = Dilat(1).DilProg.Eb : Decode3 = Dilat(2).DilProg.Eb
            Case 987 : Decoded = Dilat(1).DilStre.Ma : Decode1 = Dilat(2).DilStre.Ma : Decode2 = Dilat(1).DilStre.Mb : Decode3 = Dilat(2).DilStre.Mb
            Case 988 : Decoded = Dilat(1).DilFlex.betaa : Decode1 = Dilat(2).DilFlex.betaa : Decode2 = Dilat(1).DilFlex.betab : Decode3 = Dilat(2).DilFlex.betab
            Case 989 : Decoded = Dilat(1).DilFlex.E(1 - 1) : Decode1 = Dilat(2).DilFlex.E(1 - 1) : Decode2 = Dilat(1).DilFlex.E(2 - 1) : Decode3 = Dilat(2).DilFlex.E(2 - 1)
            Case 990 : Decoded = Dilat(1).DilFlex.Da : Decode1 = Dilat(2).DilFlex.Da : Decode2 = Dilat(1).DilFlex.db : Decode3 = Dilat(2).DilFlex.db
            Case 991 : Decoded = 1 : Decode1 = 1 : Decode2 = Dilat(1).DilEqui.a / Dilat(1).DilEqui.b : Decode3 = Dilat(2).DilEqui.a / Dilat(2).DilEqui.b
            Case 992
                Decoded = IntermStress(1, iCond).delta(1)
                Decode1 = IntermStress(2, iCond).delta(1)
                Decode2 = IntermStress(1, iCond).delta(2)
                Decode3 = IntermStress(2, iCond).delta(2)
            Case 993
                Decoded = IntermStress(1, iCond).B1(1)
                Decode1 = IntermStress(2, iCond).B1(1)
                Decode2 = IntermStress(1, iCond).B1(2)
                Decode3 = IntermStress(2, iCond).B1(2)
            Case 994
                Decoded = IntermStress(1, iCond).B2(1)
                Decode1 = IntermStress(2, iCond).B2(1)
                Decode2 = IntermStress(1, iCond).B2(2)
                Decode3 = IntermStress(2, iCond).B2(2)
            Case 995
                Decoded = IntermStress(1, iCond).chi(1, 1)
                Decode1 = IntermStress(2, iCond).chi(2, 1)
            Case 996
                Decoded = IntermStress(1, iCond).chi(1, 2)
                Decode1 = IntermStress(2, iCond).chi(2, 2)
            Case 997 To 998
                Decoded = IntermStress(1, iCond).v1(1, Posi - 996)
                Decode1 = IntermStress(2, iCond).v1(1, Posi - 996)
                Decode2 = IntermStress(1, iCond).v1(2, Posi - 996)
                Decode3 = IntermStress(2, iCond).v1(2, Posi - 996)
            Case 800 To 801
                Decoded = IntermStress(1, iCond).v2(1, Posi - 799)
                Decode1 = IntermStress(2, iCond).v2(1, Posi - 799)
                Decode2 = IntermStress(1, iCond).v2(2, Posi - 799)
                Decode3 = IntermStress(2, iCond).v2(2, Posi - 799)
            Case 802 To 803
                Decoded = IntermStress(1, iCond).Sm(1, Posi - 801)
                Decode1 = IntermStress(2, iCond).Sm(1, Posi - 801)
                Decode2 = IntermStress(1, iCond).Sm(2, Posi - 801)
                Decode3 = IntermStress(2, iCond).Sm(2, Posi - 801)
            Case 835 To 836
                Decoded = IntermStress(1, iCond).v2s(1, Posi - 834)
                Decode1 = IntermStress(2, iCond).v2s(1, Posi - 834)
                Decode2 = IntermStress(1, iCond).v2s(2, Posi - 834)
                Decode3 = IntermStress(2, iCond).v2s(2, Posi - 834)
            Case 805 To 806
                Decoded = IntermStress(1, iCond).sb(1, Posi - 804 - 1)
                Decode1 = IntermStress(2, iCond).sb(1, Posi - 804 - 1)
                Decode2 = IntermStress(1, iCond).sb(2, Posi - 804 - 1)
                Decode3 = IntermStress(2, iCond).sb(2, Posi - 804 - 1)
            Case 807 To 808
                Decoded = IntermStress(1, iCond).t(1, Posi - 806)
                Decode1 = IntermStress(2, iCond).t(1, Posi - 806)
                Decode2 = IntermStress(1, iCond).t(2, Posi - 806)
                Decode3 = IntermStress(2, iCond).t(2, Posi - 806)
            Case 802 To 803
                Decoded = IntermStress(1, iCond).Sm(1, Posi - 801)
                Decode1 = IntermStress(2, iCond).Sm(1, Posi - 801)
                Decode2 = IntermStress(1, iCond).Sm(2, Posi - 801)
                Decode3 = IntermStress(2, iCond).Sm(2, Posi - 801)
            Case 809
                Decoded = IntermStress(1, iCond).T1(1)
                Decode1 = IntermStress(2, iCond).T1(1)
                Decode2 = IntermStress(1, iCond).T1(2)
                Decode3 = IntermStress(2, iCond).T1(2)
            Case 810
                Decoded = IntermStress(1, iCond).Scl(1) / 1000
                Decode1 = IntermStress(2, iCond).Scl(1) / 1000
                Decode2 = IntermStress(1, iCond).Scl(2) / 1000
                Decode3 = IntermStress(2, iCond).Scl(2) / 1000
            Case 811 To 817
                kkk = Posi - 810
                Decoded = IntermStress(1, iCond).Smm(kkk)
                Decode1 = IntermStress(1, iCond).Scm(kkk)
                Decode2 = IntermStress(1, iCond).Smb(kkk) - IntermStress(1, iCond).Smm(kkk)
                Decode3 = IntermStress(2, iCond).Smm(kkk)
                Decode4 = IntermStress(2, iCond).Scm(kkk)
                Decode5 = IntermStress(2, iCond).Smb(kkk) - IntermStress(2, iCond).Smm(kkk)
            Case 818 To 824
                Decoded = Dilat(1).Risult(iCond).Sm(Posi - 817 - 1)
                Decode1 = Dilat(1).Risult(iCond).sb(Posi - 817 - 1)
                Decode2 = Dilat(2).Risult(iCond).Sm(Posi - 817 - 1)
                Decode3 = Dilat(2).Risult(iCond).sb(Posi - 817 - 1)
            Case 825 To 831
                kkk = Posi - 824
                Decoded = Dilat(1).Risult(iCond).Smmp(kkk - 1)
                Decode1 = Dilat(1).Risult(iCond).Scmp(kkk - 1)
                Decode2 = Dilat(1).Risult(iCond).Smbp(kkk - 1)
                Decode3 = Dilat(2).Risult(iCond).Smmp(kkk - 1)
                Decode4 = Dilat(2).Risult(iCond).Scmp(kkk - 1)
                Decode5 = Dilat(2).Risult(iCond).Smbp(kkk - 1)
            Case 832
                Decoded = IntermStress(1, iCond).Scl(1) / 1000
                If IntermStress(1, iCond).Scl(2) / 1000 > Decoded Then Decoded = IntermStress(1, iCond).Scl(2) / 1000
                Decode1 = IntermStress(2, iCond).Scl(1) / 1000
                If IntermStress(2, iCond).Scl(2) / 1000 > Decode1 Then Decode1 = IntermStress(2, iCond).Scl(2) / 1000
            Case 833
                Decoded = Dilat(1).Risult(iCond).Salt / 1000
                Decode1 = Dilat(2).Risult(iCond).Salt / 1000
            Case 834
                Decoded = IntermStress(1, iCond).Ciclallow
                Decode1 = IntermStress(2, iCond).Ciclallow
            Case 837
                Decoded = Ciclo(1, iCond).s / 1000
                Decode1 = Ciclo(2, iCond).s / 1000
                Decode2 = Ciclo(1, iCond).Cond1
                Decode3 = Ciclo(1, iCond).Cond2
            Case 850 : Decoded = Dilat(1).DilGeom.nPli
            Case 851 : Decoded = Dilat(1).DilEqui.W
            Case 852 : Decoded = 2 * (Dilat(1).DilGeom.ra + Dilat(1).DilGeom.ra + Dilat(1).DilGeom.TE * Dilat(1).DilGeom.nPli)
            Case 853 'axial elongation
                If O.SoloDilat Then
                    Decoded = Decode5 / Dilat(1).DilGeom.nOnde
                Else
                    PSP = O.Zp(iCond, 66 + 1)
                    Fax = Dilat(1).DilStre.Fax(iCond - 1) - PSP * Dilat(1).DilEqui.a / 2 / inc
                    If O.TipoDilatp < 3 Or O.TipoDilatp = 6 Then Fax = Dilat(1).DilStre.Fax(iCond - 1)
                    Decoded = 2 * pi * Fax * Dilat(1).DilEqui.a / Dilat(1).DilFlex.Sj / Dilat(1).DilGeom.nOnde
                End If
            Case 854 : Decoded = Dilat(1).DilProg.Ea
            Case 856 : Decoded = Dilat(1).DilGeom.g + 2 * Dilat(1).DilGeom.TE * Dilat(1).DilGeom.nPli + Dilat(1).DilGeom.to_Renamed
            Case 857 : Decoded = Dilat(1).DilGeom.nOnde * 2 * (Dilat(1).DilGeom.ra + Dilat(1).DilGeom.ra + Dilat(1).DilGeom.TE * Dilat(1).DilGeom.nPli)
            Case 858 : Decoded = Dilat(1).DilGeom.li / 1.5 / System.Math.Sqrt(Dilat(1).DilGeom.g * Dilat(1).DilGeom.TE)
                If Decoded > 1 Then Decoded = 1
            Case 859 : Decoded = (Dilat(1).DilGeom.g + Dilat(1).DilEqui.W + Dilat(1).DilGeom.TE * Dilat(1).DilGeom.nPli)
            Case 860 : Decoded = Dilat(1).DilEqui.yb
            Case 861 : Decoded = Dilat(1).DilEqui.ya
            Case 862 To 864
                Decoded = EjmaGraf(1, Posi - 861)
            Case 865 To 867
                Decoded = IntermStress(1, iCond).Scm(Posi - 864)
                Decode1 = IntermStress(2, iCond).Scm(Posi - 864)
                Decode2 = O.Zp(iCond, 274)
            Case 868
                Decoded = IntermStress(1, iCond).Smm(1)
                Decode1 = IntermStress(2, iCond).Smm(1)
            Case 870
                Decoded = IntermStress(1, iCond).Smb(1) - IntermStress(1, iCond).Smm(1)
                Decode1 = IntermStress(2, iCond).Smb(1) - IntermStress(2, iCond).Smm(1)
            Case 871
                Decoded = IntermStress(1, iCond).Smb(1)
                Decode1 = IntermStress(2, iCond).Smb(1)
            Case 872
                Decoded = IntermStress(1, iCond).Smm(2)
                Decode1 = IntermStress(2, iCond).Smm(2)
            Case 873
                Decoded = IntermStress(1, iCond).Smb(2) - IntermStress(1, iCond).Smm(2)
                Decode1 = IntermStress(2, iCond).Smb(2) - IntermStress(2, iCond).Smm(2)
            Case 874
                Decoded = Dilat(1).Risult(iCond).Salt
                Decode1 = Dilat(2).Risult(iCond).Salt
            Case 875, 876
                Decoded = IntermStress(1, iCond).Smb(Posi - 875 + 4)
                Decode1 = IntermStress(2, iCond).Smb(Posi - 875 + 4)
            Case 877
                Decoded = IntermStress(1, iCond).Za
                Decode1 = IntermStress(2, iCond).Za
            Case 879
                Decoded = IntermStress(1, iCond).thetaa
                Decode1 = IntermStress(2, iCond).thetaa
            Case 878
                Decoded = IntermStress(1, iCond).thetab
                Decode1 = IntermStress(2, iCond).thetab
            Case 880 : Decoded = Dilat(1).DilEqui.ya / Dilat(1).DilGeom.g : Decode1 = Dilat(2).DilEqui.ya / Dilat(2).DilGeom.g
            Case 881 : Decoded = Dilat(1).gammaa : Decode1 = Dilat(2).gammaa
            Case 882 : Decoded = Dilat(1).DilEqui.yb / Dilat(1).DilGeom.g : Decode1 = Dilat(2).DilEqui.yb / Dilat(2).DilGeom.g
            Case 883 : Decoded = Dilat(1).gammab : Decode1 = Dilat(2).gammab
            Case 884 : Decoded = (Dilat(1).DilGeom.ra + Dilat(1).DilGeom.TE / 2) / Dilat(1).DilEqui.ta
                Decode1 = (Dilat(2).DilGeom.ra + Dilat(2).DilGeom.TE / 2) / Dilat(2).DilEqui.ta
                Decode2 = (Dilat(1).DilGeom.rb + Dilat(1).DilGeom.TE / 2) / Dilat(1).DilEqui.tb
                Decode3 = (Dilat(2).DilGeom.rb + Dilat(2).DilGeom.TE / 2) / Dilat(2).DilEqui.tb
            Case 885 : Decoded = (Dilat(1).DilGeom.ra + Dilat(1).DilGeom.TE / 2) / (Dilat(1).DilEqui.b - Dilat(1).DilEqui.a)
                Decode1 = (Dilat(2).DilGeom.ra + Dilat(2).DilGeom.TE / 2) / (Dilat(2).DilEqui.b - Dilat(2).DilEqui.a)
                Decode2 = (Dilat(1).DilGeom.rb + Dilat(1).DilGeom.TE / 2) / (Dilat(1).DilEqui.b - Dilat(1).DilEqui.a)
                Decode3 = (Dilat(2).DilGeom.rb + Dilat(2).DilGeom.TE / 2) / (Dilat(2).DilEqui.b - Dilat(2).DilEqui.a)
            Case 886 : Decoded = Dilat(1).m : Decode1 = Dilat(2).m
            Case 887 : Decoded = Dilat(1).mo : Decode1 = Dilat(2).mo
            Case 888 : Decoded = Dilat(1).mo1 : Decode1 = Dilat(2).mo1
            Case 889 : Decoded = Dilat(1).mo2 : Decode1 = Dilat(2).mo2
            Case 890 : Decoded = Dilat(1).DilGeom.g / Dilat(1).DilGeom.TE : Decode1 = Dilat(2).DilGeom.g / Dilat(2).DilGeom.TE
            Case 891 : Decoded = Dilat(1).alpha : Decode1 = Dilat(2).alpha
            Case 892 : Decoded = Dilat(1).lambda : Decode1 = Dilat(2).lambda
            Case 893 : Decoded = Dilat(1).k : Decode1 = Dilat(2).k
        End Select
    End Sub
    Public Sub Assumi(ByRef ifl As Short)
        Dim Valor(8) As Single
        Dim CodCod(8) As String
        Dim Cod As String
        Dim Thkk, ThkExt As Single
        Dim Piastra As String = ""
        Dim u As String
        Dim indice As Short
        Dim i As Short ', iout1 As Integer
        Dim k, j As Short
        Dim Fax, PSP, s As Single
        Dim Contarig, kk As Short
        Dim d As Single
        Dim iii, ii As Short
        Dim ij As Short
        Dim ZZ As Single
        O = CType(CType(objMemb(Involucr(kLato, jInvolucr).IndObject), wn_PT).Piastra, wn_FTC)
        Do
            If EOF(ifl) Then Exit Do
            TIMA = LineInput(ifl)
            If Len(RTrim(LTrim(TIMA))) = 0 Then Exit Do
            TIMA = RTrim(TIMA)
            Cod = Right(TIMA, 3)
            If Left(Cod, 1) = "A" Or Left(Cod, 1) = "F" Then
1:              TIMA = Left(TIMA, Len(TIMA) - 3)
                If Left(Cod, 1) = "F" Then Exit Do
                Monitor.Motore.Problem.Printa(TIMA) : Contarig = Contarig + 1
            ElseIf Left(Cod, 1) = "E" Then
                Call O.ValoriPiastra(Thkk, ThkExt, Piastra)
                TIMA = Left(TIMA, Len(TIMA) - 3)
                If Math.Abs(O.Flangiata(1)) = 1 Then
                    u = "(Extension: " & GlobalRoutines.myStr(ThkExt * kLength, 3, 2, False) & UnitLength & " "
                Else
                    u = ""
                End If
5:              Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(TIMA, Thkk * kLength, UnitLength, u, Piastra))
            ElseIf Left(Cod, 1) = "G" Or Left(Cod, 1) = "H" Or Left(Cod, 1) = "J" Then
                TIMA = Left(TIMA, Len(TIMA) - 3)
                indice = GlobalRoutines.ValVir(Right(TIMA, 3))
                If (indice = 32 Or indice = 33) Then
                    If O.Flangiata(1) = 0 Then GoTo Salto1
                End If
                If (indice = 269 Or indice = 270) Then
                    If O.Flangiata(2) = 0 Then GoTo Salto1
                End If
                If (indice = 36 Or indice = 37) And O.Zp(1, 26) = 0 Then GoTo Salto1
7:              TIMA = Left(TIMA, Len(TIMA) - 3)
                If Left(Cod, 1) = "J" Then
                    Monitor.Motore.Problem.Printa(TIMA)
                Else
                    For i = 1 To 4
                        If i + O.iCondp - 1 > O.Zp(1, 261) Then
                            Valor(i) = 0.0!
                        Else
                            ZZ = O.Zp(i + O.iCondp - 1, indice)
                            If Left(Cod, 1) = "H" Then
                                Valor(i) = O.Convert(ZZ, indice, 1)
                            Else
9:                              Valor(i) = ZZ
                            End If
                        End If
                    Next
                    Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(TIMA, Valor(1), Valor(2), Valor(3), Valor(4)))
                    Contarig = Contarig + 2
                End If
            ElseIf Left(Cod, 1) = "k" Or Left(Cod, 1) = "l" Then
                LegTIMA()
                j = Ind1
                For i = 1 To 4
                    ij = i + O.iCondp - 1
                    If ij > O.Zp(1, 261) Then
                        Valor(2 * i - 1) = 0.0! : Valor(2 * i) = 0.0!
                    Else
                        For k = 2 To 1 Step -1
                            If j > 6 And j < 23 And O.TipoDilatp > 2 And O.TipoDilatp < 6 Then j = j + 100
                            Select Case j
                                Case 6 'delta
                                    PSP = O.Zp(ij, 66 + k)
                                    Fax = Dilat(k).DilStre.Fax(ij - 1) - PSP * Dilat(k).DilEqui.a / 2 / inc
                                    If O.TipoDilatp < 3 Or O.TipoDilatp = 6 Then Fax = Dilat(k).DilStre.Fax(ij - 1)
                                    s = 2 * pi * Fax * Dilat(k).DilEqui.a / Dilat(k).DilFlex.Sj
                                Case 8, 11, 14, 17, 20, 23, 26 'Scmp,Smmp
                                    kk = (j - 5) \ 3
                                    s = Dilat(k).Risult(ij).Smmp(kk - 1)
                                    If Dilat(k).Risult(ij).Scmp(kk - 1) > s Then s = Dilat(k).Risult(ij).Scmp(kk - 1)
                                Case 9, 12, 15, 18, 21, 24, 27 'Smbp
                                    kk = (j - 6) \ 3
                                    s = Dilat(k).Risult(ij).Smbp(kk - 1)
                                Case 10, 13, 16, 19, 22, 25, 28 'All
                                    kk = (j - 7) \ 3
                                    If Dilat(k).Risult(ij).Fmbp(kk - 1) > 0 Then s = Dilat(k).Risult(ij).Smbp(kk - 1) / Dilat(k).Risult(ij).Fmbp(kk - 1) Else s = 0
                                Case 30 'Sn
                                    s = Dilat(k).Risult(O.Offset + ij).Salt
                                    If s = 0 Then s = Dilat(k).Risult(ij).Salt
                                Case 31 'Nø of events
                                    s = O.Neventip(ij)
                                Case 32
                                    If Ciclo(k, ij).nCicli > 0 Then
                                        Cod = "(" & LTrim(Str(Ciclo(k, ij).Cond1)) & "-" & LTrim(Str(Ciclo(k, ij).Cond2)) & ")"
                                    Else
                                        Cod = Space(6)
                                    End If
                                Case 33
                                    s = Ciclo(k, ij).nCicli / 2
                                Case 34
                                    s = Ciclo(k, ij).Danno
                                    If s > 0.99999 Then s = 0.99999
                                Case 37 'danno totale
                                    If i > 1 Or k = 1 Then GoTo Salto1
                                    d = 0
                                    For iii = 1 To O.Zp(1, 261) : For ii = 1 To 2
                                            d = d + Ciclo(ii, iii).Danno
                                        Next
                                    Next iii
                                    Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(TIMA, d))
                                    GoTo Salto1
                                Case 108 : s = Dilat(k).Risult(ij).Scmp(1 - 1)
                                Case 109 : s = Dilat(k).Risult(ij).Smmp(1 - 1)
                                Case 110 : s = Dilat(k).Risult(ij).Smbp(1 - 1)
                                Case 111, 114 : s = Dilat(k).Risult(ij).Smmp(1 - 1) / Dilat(k).Risult(ij).Fmmp(1 - 1)
                                Case 112 : s = Dilat(k).Risult(ij).Smbp(1 - 1) / Dilat(k).Risult(ij).Fmbp(1 - 1)
                                Case 113 : s = Dilat(k).Risult(ij).Scmp(2 - 1)
                                Case 115 : s = Dilat(k).Risult(ij).Scmp(3 - 1)
                                Case 117 : s = Dilat(k).Risult(ij).Scmp(4 - 1)
                                    If O.TipoDilatp < 4 Then s = 0
                                Case 119 : s = Dilat(k).Risult(ij).Scmp(5 - 1)
                                    If O.TipoDilatp < 5 Then s = 0
                                Case 116
                                    s = O.Zp(ij, 276)
                                Case 118
                                    s = O.Zp(ij, 278)
                                    If O.TipoDilatp < 4 Then s = 0
                                Case 120
                                    s = O.Zp(ij, 280)
                                    If O.TipoDilatp < 5 Then s = 0
                                Case 121 : s = Dilat(k).Risult(ij).Smbp(2 - 1)
                                    If O.TipoDilatp = 5 Then s = 0
                                Case 122 : s = Dilat(k).Risult(ij).Smbp(3 - 1)
                                    If O.TipoDilatp > 3 Then s = 0
                            End Select
                            If Left(Cod, 1) = "l" And Not (j = 6 Or Ind1 > 30) Then s = O.Convert(s, 1, 2)
                            If j = 32 Then
                                CodCod(2 * i - (k - 1)) = Cod
                            Else
                                Valor(2 * i - (k - 1)) = s
                            End If
                        Next
                    End If
                Next
                If j = 32 Then
                    Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(TIMA, CodCod(1), CodCod(2), CodCod(3), CodCod(4), CodCod(5), CodCod(6), CodCod(7), CodCod(8))) : Contarig = Contarig + 2
                Else
                    Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(TIMA, Valor(1), Valor(2), Valor(3), Valor(4), Valor(5), Valor(6), Valor(7), Valor(8))) : Contarig = Contarig + 2
                End If
            ElseIf Left(Cod, 1) = "K" Or Left(Cod, 1) = "L" Or Left(Cod, 1) = "M" Then
                LegTIMA()
                If Ind1 = 290 And O.Flangiata(1) = 0 Then GoTo Salto1
                If Left(Cod, 1) = "M" Then
                    Monitor.Motore.Problem.Printa(TIMA)
                Else
                    For i = 1 To 4
                        ij = i + O.iCondp - 1
                        If ij > O.Zp(1, 261) Then
15:                         Valor(2 * i - 1) = 0.0! : Valor(2 * i) = 0.0!
                        Else
                            If Left(Cod, 1) = "K" Then
                                Valor(2 * i - 1) = O.Convert(O.Zp(ij, Ind1), Ind1, 1)
                                Valor(2 * i) = O.Convert(O.Zp(ij, Ind2), Ind2, 1)
                            Else
                                Valor(2 * i - 1) = O.Zp(ij, Ind1)
                                Valor(2 * i) = O.Zp(ij, Ind2)
                            End If
                        End If
                    Next
                    Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(TIMA, Valor(1), Valor(2), Valor(3), Valor(4), Valor(5), Valor(6), Valor(7), Valor(8))) : Contarig = Contarig + 2
                End If
            ElseIf Left(Cod, 1) = "I" Then
19:             TIMA = Left(TIMA, Len(TIMA) - 3)
                Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(TIMA, O.iCondp, O.iCondp + 1, O.iCondp + 2, O.iCondp + 3))
            ElseIf Left(Cod, 1) = "i" Then
                TIMA = Left(TIMA, Len(TIMA) - 3)
                Monitor.Motore.Problem.Printa(GlobalRoutines.FormatS(TIMA, O.iCondp, O.iCondp, O.iCondp + 1, O.iCondp + 1, O.iCondp + 2, O.iCondp + 2, O.iCondp + 3, O.iCondp + 3))
            ElseIf Left(Cod, 1) = "T" Then
                Call O.Testatap(Val(Right(Cod, 1)))
            Else
                Monitor.Motore.Problem.Printa(TIMA) : Contarig = Contarig + 1
            End If
Salto1: Loop
    End Sub
    Private Sub LegTIMA()
        TIMA = Left(TIMA, Len(TIMA) - 3)
        Ind2 = GlobalRoutines.ValVir(Right(TIMA, 3))
        TIMA = Left(TIMA, Len(TIMA) - 3)
        Ind1 = GlobalRoutines.ValVir(Right(TIMA, 3))
        TIMA = Left(TIMA, Len(TIMA) - 3)
    End Sub
    Public Sub Cerca(ByRef ic As Short, ByRef s As Single, ByRef TipoDilat As Short)
        With Dilat(1)
            Select Case ic
                Case 1 : s = .DilGeom.g
                Case 2 : s = .DilGeom.id
                Case 3 : s = .DilGeom.ra 'ginocchio
                    If TipoDilat = 2 Then s = 0
                Case 4 : s = .DilGeom.TE 'tE
                Case 5 : s = Dilat(2).DilProg.Corr 'corr
                Case 6 : s = .DilGeom.nOnde 'n.
                Case 7 : s = .DilGeom.li
                    If TipoDilat = 6 Then s = 0 'L
                Case 8 : s = .DilGeom.nPli
                Case 9 : s = .DilGeom.lo
                Case 10 : s = .DilGeom.to_Renamed
                Case 11 : s = .DilGeom.ts
                    If TipoDilat = 1 Then s = .DilGeom.TE
                Case 13 : s = .DilGeom.to_Renamed
                    If TipoDilat = 1 Then s = .DilGeom.TE
                Case 12
                    Select Case TipoDilat
                        Case 2, 6 : s = .DilGeom.li
                        Case Else : s = .DilGeom.fa
                    End Select
                Case 14
                    Select Case TipoDilat
                        Case 2, 6 : s = .DilGeom.lo
                        Case Else : s = .DilGeom.fb
                    End Select
                Case 15 : s = .DilEqui.a
                Case 16 : s = .DilEqui.b
                Case 17 : s = .DilEqui.ta
                Case 18 : s = .DilEqui.tb
                Case 19 : s = .DilEqui.la
                Case 20 : s = .DilEqui.lb
                Case 21 : s = .DilEqui.ya
                Case 22 : s = .DilEqui.yb
                Case 23 : s = .DilGeom.rb 'ginocchio
                    If TipoDilat = 2 Then s = 0
            End Select 's
        End With
    End Sub
    Public Sub Cerca1(ByRef k As Short, ByRef i As Short, ByRef PSP As Single, ByRef Fax As Single, ByRef m As Short, ByRef TipoDilat As Short)
        Select Case m
            Case 1 : Fax = Dilat(k).DilStre.Fax(i - 1) - PSP * Dilat(k).DilEqui.a / 2 / inc
                If TipoDilat < 3 Or TipoDilat = 6 Then Fax = Dilat(k).DilStre.Fax(i - 1)
            Case 2 : PSP = 2 * pi * Fax * Dilat(k).DilEqui.a / Dilat(k).DilFlex.Sj
        End Select
    End Sub
    Public Sub Cerca2(ByRef i As Short, ByRef k As Short, ByRef j As Short, ByRef s As Single, ByRef Cod As String, ByRef n As Short, ByRef Offset As Short)
        Dim kk As Short
        With Dilat(k).Risult(i)
            Select Case j
                Case 8, 11, 14, 17, 20, 23, 26 'Scmp,Smmp
800:                kk = (j - 5) \ 3
                    s = .Smmp(kk - 1)
                    If .Scmp(kk - 1) > s Then s = .Scmp(kk - 1)
                Case 9, 12, 15, 18, 21, 24, 27 'Smbp
                    kk = (j - 6) \ 3
                    s = .Smbp(kk - 1)
                Case 10, 13, 16, 19, 22, 25, 28 'All
                    kk = (j - 7) \ 3
                    If .Fmbp(kk - 1) > 0 Then
                        s = .Smbp(kk - 1) / .Fmbp(kk - 1)
                    Else
                        s = 0
                    End If
                Case 30 'Sn
                    s = Dilat(k).Risult(Offset + i).Salt / 1000
                Case 32
                    If Ciclo(k, i).nCicli > 0 Then
                        Cod = "(" & LTrim(Str(Ciclo(k, i).Cond1)) & "-" & LTrim(Str(Ciclo(k, i).Cond2)) & ")"
                    Else
                        Cod = Space(6)
                    End If
                Case 33
                    n = Ciclo(k, i).nCicli / 2
                Case 34
                    s = Ciclo(k, i).Danno
                    If s > 0.99999 Then s = 0.99999
            End Select
        End With
    End Sub
    Public Sub Cerca4(ByRef j As Short, ByRef s As Single, ByRef k As Short, ByRef i As Short, ByRef TipoDilat As Short, ByRef Cod As String, ByRef n As Short)
        With Dilat(k).Risult(i)
            Select Case j
                Case 6 'delta
830:                s = Dilat(k).DilStre.Fax(i - 1) * 2 * pi * Dilat(k).DilEqui.a / Dilat(k).DilFlex.Sj
                Case 8 : s = .Smmp(1 - 1)
                Case 9 : s = .Scmp(1 - 1)
                Case 10 : s = .Smbp(1 - 1)
                Case 11, 14 : s = .Smmp(1 - 1) / .Fmmp(1 - 1)
                Case 12 : s = .Smbp(1 - 1) / .Fmbp(1 - 1)
                Case 13 : s = .Scmp(2 - 1)
                Case 15 : s = .Scmp(3 - 1)
                Case 17 : s = .Scmp(4 - 1)
840:                If TipoDilat < 4 Then s = 0
                Case 19 : s = .Scmp(5 - 1)
                    If TipoDilat < 5 Then s = 0
                Case 21 : s = .Smbp(2 - 1)
                    If TipoDilat = 5 Then s = 0
                Case 22 : s = .Smbp(3 - 1)
                    If TipoDilat > 3 Then s = 0
                Case 24 'Sn
860:                s = .Salt / 1000
                Case 26
                    If Ciclo(k, i).nCicli > 0 Then
                        Cod = "(" & LTrim(Str(Ciclo(k, i).Cond1)) & "-" & LTrim(Str(Ciclo(k, i).Cond2)) & ")"
                    Else
                        Cod = Space(6)
                    End If
                Case 27
                    n = Ciclo(k, i).nCicli / 2
                Case 28
                    s = Ciclo(k, i).Danno
                    If s > 0.99999 Then s = 0.99999
            End Select
        End With
    End Sub
    Public Function Danno(ByVal n As Short) As Single
        Dim i, ii As Short
        Dim d As Single
        d = 0
        For i = 1 To n
            For ii = 1 To 2
                d = d + Ciclo(ii, i).Danno
            Next ii
        Next i
        Danno = d
    End Function
    Public Sub Transfer(ByRef WWW As Short, Optional ByRef p As wn_FTC = Nothing)
        If p Is Nothing Then
            O = CType(CType(objMemb(Involucr(3, jInvolucr).IndObject), wn_PT).Piastra, wn_FTC)
        Else
            O = p
        End If
        Select Case WWW
            Case 275
                Dilat(1).DilProg.sY = O.Zp(0, WWW)
                Dilat(2).DilProg.sY = O.Zp(0, WWW)
            Case 274
                Dilat(1).DilProg.Sigma = O.Zp(0, WWW)
                Dilat(2).DilProg.Sigma = O.Zp(0, WWW)
        End Select
    End Sub
    Public Sub FattUs(ByRef iCorr As Short, ByRef i As Short, ByRef kk As Short, ByRef DilaP As Single, ByRef s As Single)
        With Dilat(iCorr).Risult(i)
            If .Fcmp(kk - 1) > DilaP Then DilaP = .Fcmp(kk - 1)
            If .Fmbp(kk - 1) > DilaP Then DilaP = .Fmbp(kk - 1)
            If .Fmmp(kk - 1) > DilaP Then DilaP = .Fmmp(kk - 1)
            s = .Smmp(kk - 1)
            If .Scmp(kk - 1) > s Then s = .Scmp(kk - 1)
        End With
    End Sub
    Public Sub FattUs1(ByRef i As Short, ByRef icMAWP As Short, ByRef Condit As Short, ByRef DilaI1 As Single, ByRef DilaI2 As Single)
        Dim DilaI3 As Single
        If System.Math.Abs(Dilat(1).Risult(i).Smbp(2 - 1)) > 0 Then
            If icMAWP = 0 Or Condit < 3 Then DilaI1 = System.Math.Abs(Dilat(1).Risult(i).Smbp(4 - 1) / Dilat(1).Risult(i).Smbp(2 - 1)) Else DilaI1 = 0
            If icMAWP = 0 Or Condit > 2 Then DilaI2 = System.Math.Abs(Dilat(2).Risult(i).Smbp(4 - 1) / Dilat(2).Risult(i).Smbp(2 - 1)) Else DilaI2 = 0
            If DilaI2 > DilaI1 Then DilaI1 = DilaI2
        Else
            DilaI1 = 0
        End If
        If System.Math.Abs(Dilat(1).Risult(i).Smbp(3 - 1)) > 0 Then
            If icMAWP = 0 Or Condit < 3 Then DilaI2 = System.Math.Abs(Dilat(1).Risult(i).Smbp(4 - 1) / Dilat(1).Risult(i).Smbp(3 - 1)) Else DilaI2 = 0
            If icMAWP = 0 Or Condit > 2 Then DilaI3 = System.Math.Abs(Dilat(2).Risult(i).Smbp(4 - 1) / Dilat(2).Risult(i).Smbp(3 - 1)) Else DilaI3 = 0
            If DilaI3 > DilaI2 Then DilaI2 = DilaI3
        Else
            DilaI2 = 0
        End If
    End Sub
    Public Sub RetrDilat()
        Dim i As Short
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Dilat(1). Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
        Dilat(1) = Dilat(5)
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Dilat(2). Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
        Dilat(2) = Dilat(6)
        For i = 1 To 8
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto IntermStress(1, i). Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            IntermStress(1, i) = IntermStress(5, i)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto IntermStress(2, i). Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            IntermStress(2, i) = IntermStress(6, i)
        Next
    End Sub
    Public Sub SaveDilat()
        Dim i As Short
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Dilat(5). Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
        Dilat(5) = Dilat(1)
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Dilat(6). Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
        Dilat(6) = Dilat(2)
        For i = 1 To 8
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto IntermStress(5, i). Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            IntermStress(5, i) = IntermStress(1, i)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto IntermStress(6, i). Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            IntermStress(6, i) = IntermStress(2, i)
        Next
    End Sub
    Public Sub New()
        MyBase.New()
        lKlato = kLato
        lJinvolucr = jInvolucr
        IndObj = CType(objMemb(Involucr(kLato, jInvolucr).IndObject), wn_PT).Indprobl1
        Dim i, j As Short
        For i = 0 To 6
            Dilat(i).Initialize()
            For j = 0 To 8
                IntermStress(i, j).Initialize()
            Next
        Next
    End Sub
    Public ReadOnly Property prule8() As Short
        Get
            If Dilat(1).rule8 > 0 Then
                prule8 = Dilat(1).rule8
            Else
                prule8 = 52
            End If
        End Get
    End Property
    Public Property Verbose() As Boolean
        Get

        End Get
        Set(ByVal Value As Boolean)

        End Set
    End Property
    Public WriteOnly Property UniMis() As Short
        Set(ByVal Value As Short)
        End Set
    End Property
End Class