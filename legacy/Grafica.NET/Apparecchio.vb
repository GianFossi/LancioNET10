Option Strict Off
Option Explicit On
Imports RoutBase1
Imports System.IO
Imports System.Runtime.Serialization
Imports System.Runtime.Serialization.Formatters.Binary
<Serializable()> Public Class clsApparecchio
    Public Elementi As OggList
    Public Spots As OggList
    Public Baric As RoutBase1.clsVec3
    Public peso As Single
    Public CostoMat As Single
    Public Asse As String
    Public NumeroLati As Short
    <NonSerialized()> Public Salvato As Boolean
    Public Sub New()
        MyBase.New()
        Elementi = New OggList(0)
        Baric = New RoutBase1.clsVec3
    End Sub
    Protected Overrides Sub Finalize()
        Dim i, j As Short
        Dim g As clsGenMem
        If Not Elementi Is Nothing Then
            For i = 1 To Elementi.Count()
                If Not Elementi(0) Is Nothing Then
                    g = Elementi(0).GenMem
                    If Not g Is Nothing Then
                        If Not g.Segnalini Is Nothing Then
                            For j = 1 To g.Segnalini.Count()
                                g.Segnalini.remove(0)
                            Next
                        End If
                    End If
                    Elementi.remove(0)
                End If
            Next
        End If
        Baric = Nothing
        Elementi = Nothing
        MyBase.Finalize()
    End Sub
    Public Sub LeggiApparecchio(ByRef nonregistrato As Boolean)
        Dim j As Short
        Dim Foro As Foratura
        Apparecchio = Me
        j = 0
        Dim n As OggList.NodeP = Elementi.nodeHead.Next
        While Not n Is Nothing
            Membro = n.TextData
            j = j + 1
            Monitor.Motore.Avanzamento = 100 * j / Elementi.Count()
            System.Windows.Forms.Application.DoEvents()
            If Monitor.Smetti Then Exit Sub
            If Membro.GenMem.Tipo > 0 Then MembroLeggi(Membro, "", 0)
            If Not NonDisegnare Then
                If Not Membro.GenMem.posizione.SuChi Is Nothing Then
                    If nonregistrato Then
                        FormDati.GenMemInText()
                        FormDati.SuperPosN(True)
                    End If
                    TrasfCoordN(Membro.GenMem, Membro.GenMem.posizione.SuChi.GenMem)
                    If Membro.GenMem.Tipo = 97 Then
                        Foro = Membro
                        Buco(Foro.GenMem.posizione.SuChi.GenMem, (Foro.GenMem.PNET), (Foro.Quota), (Foro.Raggio), (Foro.anom))
                    End If
                End If
            End If
            n = n.Next
        End While
        LeggiSezioni()
        Editing = False : Caricamento = False
        If nonregistrato Then ResetFori()
    End Sub
    Public Sub Add(ByRef m As Membratura, Optional ByRef After As String = "")
        Dim Nome As String
        Dim gm As clsGenMem = m.GenMem
        Nome = gm.Denom.Trim
        gm.Ind = Elementi.Count()
        If Nome.Length = 0 Then Nome = "ELEM" & Trim(Str(gm.Ind))
        Elementi.Add(m, Nome, , After)
        gm.Denom = Nome
        gm.keyG = Nome
    End Sub
    Public Sub BaricGen()
        Dim peso1 As Single
        Dim n As OggList.NodeP = Elementi.nodeHead.Next
        Dim O As clsGenMem
        Baric.X = 0
        Baric.y = 0
        Baric.Z = 0
        peso = 0 : CostoMat = 0
        While Not n Is Nothing
            O = n.TextData.GenMem
            If O.Tipo > 0 And O.Tipo < 97 Then
                Select Case System.Math.Abs(CType(O.posizione.SuChi.GenMem, clsGenMem).Tipo)
                    Case 19, 31, 32, 33, 35, 37, 38
                    Case Else
100:                    peso1 = O.PNET
                        Baric.X = Baric.X + peso1 * O.posizione.BaricAss.X
                        Baric.y = Baric.y + peso1 * O.posizione.BaricAss.y
                        Baric.Z = Baric.Z + peso1 * O.posizione.BaricAss.Z
120:                    peso = peso + peso1
                        CostoMat = CostoMat + O.LireTot
                End Select
            End If
            n = n.Next
        End While
        If peso > TOLER Then
            Baric.X = Baric.X / peso
            Baric.y = Baric.y / peso
            Baric.Z = Baric.Z / peso
        End If
    End Sub
    Public Sub AddSpot(ByRef s As spot)
        Spots.Add(s)
    End Sub

    Public Sub RemoveElem(ByRef n As String)
        Dim i As Short
        i = 0
        Do While i < Elementi.Count
            If Trim(Elementi(i).GenMem.Denom) = Trim(n) Then
                Elementi.remove(i)
                Exit Sub
            End If
            i = i + 1
        Loop
    End Sub
    Public Function CercaBul(ByRef Oggetto As Membratura, Optional ByRef Diam As Single = 0, Optional ByRef DBul As Single = 0) As clsTirante
        Dim Log2, Log1, Log3 As Boolean
        Dim gm As clsGenMem
        Try
            Dim gmOgg As clsGenMem = Oggetto.GenMem
            Diam = 0 : DBul = 0
            If Oggetto Is Nothing Then Return Nothing
            Dim n As OggList.NodeP = Elementi.nodeHead.Next
            While Not n Is Nothing
                gm = n.TextData.GenMem
                If System.Math.Abs(gm.Tipo) = 13 Then
                    Log1 = (gm.posizione.SuChi Is Oggetto) Or (gmOgg.posizione.SuChi Is n.TextData)
                    Log2 = (gm.posizione.ForoSecondario Is Oggetto) Or (gmOgg.posizione.ForoSecondario Is n.TextData)
                    Log3 = (gm.posizione.ForoTerziario Is Oggetto) Or (gmOgg.posizione.ForoTerziario Is n.TextData)
                    If Log1 Or Log2 Or Log3 Then
                        Diam = n.TextData.Dinst
                        DBul = n.TextData.Standard.Dnom
                        Exit While
                    End If
                End If
                n = n.Next
            End While
            If n Is Nothing Then Return Nothing
            Return n.TextData
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Function 'a'i
    Public Function CercaGuar(ByRef O As Membratura) As clsGuarniz
        Dim g As Membratura = Nothing
        Dim SuChi As Membratura
        SuChi = O.GenMem.posizione.SuChi
        If Not SuChi Is Nothing Then
            If SuChi.GenMem.Tipo = 28 Then
                CercaGuar = O.GenMem.posizione.SuChi
                Exit Function
            End If
        End If
        Dim n As OggList.NodeP = Elementi.nodeHead.Next
        While Not n Is Nothing
            g = n.TextData
            If g.GenMem.Tipo = 28 Then
                If g.GenMem.posizione.SuChi Is O Then
                    Exit While
                End If
            End If
            n = n.Next
        End While
        If n Is Nothing Then Return Nothing
        Return g
    End Function
    Public Function CercaFlan(ByRef O As Membratura) As Flangione
        Dim g As Membratura = Nothing
        If CType(CType(O.GenMem, clsGenMem).posizione.SuChi.GenMem, clsGenMem).Tipo = 11 Then
            CercaFlan = O.GenMem.posizione.SuChi
        Else
            Dim n As OggList.NodeP = Elementi.nodeHead.Next
            While Not n Is Nothing
                g = n.TextData
                If CType(g.GenMem, clsGenMem).Tipo = 11 Then
                    If CType(g.GenMem, clsGenMem).posizione.SuChi Is O Then
                        Exit While
                    End If
                End If
                n = n.Next
            End While
        End If
        Return g
    End Function
    Public Function CercaTubi() As Tubi
        Dim t As Membratura
        Dim n As OggList.NodeP = Elementi.nodeHead.Next
        While Not n Is Nothing
            t = n.TextData
            If System.Math.Abs(t.GenMem.Tipo) = 8 Or System.Math.Abs(t.GenMem.Tipo) = 9 Then
                Return t
            End If
            n = n.Next
        End While
        Return Nothing
    End Function
    Public Function CercaFascio(Optional ByRef Tubi As Tubi = Nothing) As Fascio
        Dim t As Membratura
        If Not Tubi Is Nothing Then
            CercaFascio = Tubi.GenMem.posizione.SuChi
        Else
            Dim n As OggList.NodeP = Elementi.nodeHead.Next
            While Not n Is Nothing
                t = n.TextData
                If t.GenMem.Tipo = 26 Then
                    Return t
                End If
                n = n.Next
            End While
        End If
        Return Nothing
    End Function
    Public Function CercaForiPiastra(ByRef t As Piastrone) As Foratura
        Dim f As Foratura = Nothing
        Dim O As Membratura
        Dim Tubi As Tubi
        Dim Fascio As Fascio
        Tubi = CercaTubi()
        If Tubi Is Nothing Then Return f
        If CType(Tubi.GenMem.posizione.SuChi.GenMem, clsGenMem).Tipo = 26 Then Fascio = Tubi.GenMem.posizione.SuChi
        Dim n As OggList.NodeP = Elementi.nodeHead.Next
        While Not n Is Nothing
            O = n.TextData
            If O.GenMem.Tipo = 97 Then
                f = O
                If f.GenMem.posizione.SuChi Is t Then
                    If f.Bucante Is Tubi Then
                        Exit While
                    End If
                End If
            End If
            n = n.Next
        End While
        Return f
    End Function
    Public Sub ScaricaApparecchio(Optional ByVal final As Boolean = True)
        If Elementi.Count() = 0 Then Exit Sub
        IUNL = 0
        ScaricaGrezzi()
        Try
            Funzioni.iAPRn = New FileStream(FileAPR, FileMode.OpenOrCreate, FileAccess.Write)
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
        Dim bf As New BinaryFormatter
        bf.Serialize(Funzioni.iAPRn, Me)
        If final Then
            Funzioni.iAPRn.Close()
            Funzioni.iAPRn = Nothing
        End If
        Salvato = True
    End Sub
    Public Function CercaAltraFlangia(ByRef Fl1 As Flangione, Optional ByRef Bul As clsTirante = Nothing) As Flangione
        If Fl1 Is Nothing Then Return Nothing
        If Bul Is Nothing Then
            Bul = CercaBul(Fl1)
            If Bul Is Nothing Then Return Nothing
        End If
        If Bul.GenMem.posizione.SuChi Is Fl1 Then
            CercaAltraFlangia = Bul.GenMem.posizione.ForoSecondario
        Else
            CercaAltraFlangia = Bul.GenMem.posizione.SuChi
        End If
    End Function
    Public Function CercaForo(ByRef Record As clsGenMem, ByRef Recordv As clsGenMem) As Foratura
        Dim f As Foratura = Nothing
        Dim O As Membratura
        Dim n As OggList.NodeP = Elementi.nodeHead.Next
        While Not n Is Nothing
            O = n.TextData
            If O.GenMem.Tipo = 97 Then
                f = O
                If f.GenMem.posizione.SuChi Is Recordv.Parent Then
                    If f.Bucante Is Record.Parent Then
                        Return f
                    End If
                End If
            End If
            n = n.Next
        End While
        Return Nothing
    End Function
    Public Function CercaElemento(ByRef Nome As String) As Membratura
        'On Error Resume Next
        CercaElemento = Elementi(Nome)
        'Err.Clear()
    End Function

    Public Sub Delete()
        Dim i, n As Short
        Dim O As Membratura
        i = 0
        Try
            Do
                With CType(Elementi(i).GenMem, clsGenMem)
                    .posizione.SuChi = Nothing
                    .posizione.ForoSecondario = Nothing
                    .posizione.ForoTerziario = Nothing
                    .Superiore = Nothing
                    .Parent = Nothing
                End With
                If Elementi(i).GenMem.Tipo = 97 Then
                    Elementi(i).Bucante = Nothing
                ElseIf Elementi(i).GenMem.Tipo = 10 Then
                    With Elementi(i)
                        If .Standard Is Nothing Then i = i + 1 : GoTo Cont
                        .Standard = Nothing
                        .Tronchetto = Nothing
                        .Tirante = Nothing
                        .Guarniz = Nothing
                        .ControFlangia = Nothing
                        .Pad = Nothing
                    End With
                ElseIf Elementi(i).GenMem.Tipo = 14 Then
                    With Elementi(i)
                        If .Standard Is Nothing Then i = i + 1 : GoTo Cont
                        .Standard = Nothing
                        .Pipe = Nothing
                        .Tirante = Nothing
                        .Guarniz = Nothing
                        .ControFlangia = Nothing
                        .Pad = Nothing
                    End With
                End If
                n = Elementi.Count()
                CType(Elementi(i).GenMem, clsGenMem).ClearAppesi(True)
                If Elementi.Count() < n Then i = 1 Else i = i + 1
Cont:
            Loop Until i > Elementi.Count - 1
            Elementi.RemoveAll()
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
End Class