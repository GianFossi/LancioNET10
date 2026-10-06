Option Strict Off
Option Explicit On
Module mainPT
    Public Fl As datiFlangia
    Public Bulloni As DatiBull
    Public DatiInt() As DatiCalc
    Public Problem() As DatiGeneral 'strutture dati e azzeramento
    Public FlChan() As datiFlangia
    Public FlShel() As datiFlangia
    Public Sub Aggdestemp(ByRef Forza As Boolean, Optional ByRef ic As Short = 0)
        Dim i, j As Short
        'If TipoPiastra = 1 Then Exit Sub
        i = Involucr(kLato, jInvolucr).IndObject
        If objMemb(i).TipoPT = 1 Then Exit Sub
        Select Case ic
            Case 0
                Sub1(i, j, Forza)
                Sub2(i, j, Forza)
                Sub3(i, j, Forza)
                Sub4(i, j, Forza)
            Case 1
                Sub1(i, j, Forza)
            Case 2
                Sub2(i, j, Forza)
            Case 3
                Sub3(i, j, Forza)
            Case 4
                Sub4(i, j, Forza)
        End Select
    End Sub
    Public Sub Aggdespres(ByRef Forza As Boolean, Optional ByRef ic As Short = 0)
        Dim i, j As Short
        i = Involucr(kLato, jInvolucr).IndObject
        If objMemb(i).TipoPT = 1 Then Exit Sub
        Select Case ic
            Case 0
                Suc1(i, j, Forza)
                Suc2(i, j, Forza)
            Case 1
                Suc1(i, j, Forza)
            Case 2
                Suc2(i, j, Forza)
        End Select
    End Sub
    Friend Function getmiotag(ByVal s As String, ByVal i As Integer) As String
        Dim dividi As String() = s.Split(",")
        If UBound(dividi) = 0 Then Return s
        Return dividi(i)
    End Function
    Friend Function setmiotag(ByVal tag As String, ByVal s As String, ByVal i As Integer) As String
        Dim dividi As String() = tag.Split(",")
        setmiotag = ""
        If UBound(dividi) = 0 Then
            ReDim dividi(1)
            dividi(0) = tag
            dividi(1) = tag
        End If
        Select Case i
            Case 0
                Return s & "," & dividi(1)
            Case 1
                Return dividi(0) & "," & s
        End Select
    End Function
    Private Sub Sub4(ByVal i As Short, ByVal j As Short, ByVal Forza As Boolean)
        '---channel B
        With objMemb(i)
            .SetPiastra(2, False)
            j = .IndAccopp(3)
            If j > 0 Then
                If .Piastra.Zp(9, 322) = 0 Or Forza Then
                    Dim temp As Single = Involucr(2, j).Destemp
                    If temp = 0 Then temp = Config(2).tdx
                    .Piastra.Zp(9, 322) = temp
                End If
            End If
            .SetPiastra(1, False)
        End With
        '      .Piastra.iCondp = 1
        '      .Piastra.LeggiSigma 0, 35
        '      .Piastra.LeggiSigma 0, 266
        'T               Tubesheet design temperature 747 /1747
        'Tm  =           Tubesheet metal Temperature 4 / 268
        'T'  =           Tubesheet temperature at the rim 594 /1594
        'Ts,m    =       Mean shell metal Temperature  5
        'Tt  =           Tube design Temperature  764
        'Tt,m    =       Mean tube metal Temperature   6
        'Ts  =           Shell design temperature 777
        'Ts' =           Shell temperature at the tubesheet 595/1595
        'Tc  =           Channel design temperature 322/1322
        'Tc' =           Channel temperature at the TS 596/1596

    End Sub
    Private Sub Sub3(ByVal i As Short, ByVal j As Short, ByVal Forza As Boolean)
        '---channel A
        With objMemb(i)
            j = .IndAccopp(3)
            If j > 0 Then
                Dim p As wn_FTC = .Piastra
                If p.Zp(p.iCond, 322) = 0 Or Forza Then
                    Dim temp As Single = Involucr(2, j).Destemp
                    If temp = 0 Then temp = Config(2).tdx
                    p.Zp(p.iCond, 322) = temp
                End If
            End If
        End With
    End Sub
    Private Sub Sub2(ByVal i As Short, ByVal j As Short, ByVal Forza As Boolean)
        '---tubi
        With objMemb(i)
            Dim p As wn_FTC = .Piastra
            For j = 1 To Config(3).Ninvolucri
                If Involucr(3, j).Tipo = 7 Then
                    If p.Zp(p.iCond, 764) = 0 Or Forza Then
                        p.Zp(p.iCond, 764) = Involucr(3, j).Destemp
                    End If
                    Exit For
                End If
            Next
        End With
    End Sub
    Private Sub Sub1(ByVal i As Short, ByVal j As Short, ByVal Forza As Boolean)
        '---shell
        With objMemb(i)
            Dim p As wn_FTC = .Piastra
            j = p.IndiceShell
            If j > 0 Then
                If p.Zp(p.iCond, 777) = 0 Or Forza Then
                    Dim temp As Single = Involucr(1, j).Destemp
                    If temp = 0 Then temp = Config(1).tdx
                    p.Zp(p.iCond, 777) = temp
                End If
            End If
        End With
    End Sub
    Private Sub Suc2(ByVal i As Short, ByVal j As Short, ByVal Forza As Boolean)
        '---tubi
        With objMemb(i)
            Dim p As wn_FTC = .Piastra
            For j = 1 To Config(3).Ninvolucri
                If Involucr(3, j).Tipo = 7 Then
                    If p.Zp(p.iCond, 2) = 0 Or Forza Then
                        p.Zp(p.iCond, 2) = PressDes(2, j)
                    End If
                    Exit For
                End If
            Next
        End With
    End Sub
    Private Sub Suc1(ByVal i As Short, ByVal j As Short, ByVal Forza As Boolean)
        '---shell
        With objMemb(i)
            Dim p As wn_FTC = .Piastra
            j = p.IndiceShell
            If j > 0 Then
                If p.Zp(p.iCond, 1) = 0 Or Forza Then
                    p.Zp(p.iCond, 1) = PressDes(1, j)
                End If
            End If
        End With
    End Sub
End Module
