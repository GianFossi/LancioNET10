Option Strict Off
Option Explicit On
Imports System.Math
Module ShowForm
    Private offx, offy As Single
    Private Scal As Single
    Structure RecPRG
        Dim SP As Short
        Dim Ind As Short
    End Structure
    Sub Disposiz(ByRef S As Spicchi, ByRef n As Short, ByRef xMin As Single, ByRef xMax As Single, ByRef yMin As Single, ByRef yMax As Single)
        Dim i, j As Short
        If n > 0 Then
            offx = S.SP(2).Rettn.LARG / 2
            yMax = S.SP(2).Rettn.y(3)
            If S.SP(2).Nspicchi = 0 Then offx = 0 : yMax = 0
            For i = 2 To n
                If S.SP(i + 1).Nspicchi > 0 Then
                    offx = offx + 50 + S.SP(i + 1).Rettn.LARG / 2
                    For j = 1 To 4
                        S.SP(i + 1).Rettn.x(j) += offx
                    Next j
                    For j = 1 To S.SP(i + 1).Nspicchi
                        S.SP(i + 1).LamSp(j - 1).Origin.X += offx
                    Next j
                    offx = offx + S.SP(i + 1).Rettn.LARG / 2
                End If
                If S.SP(i + 1).Rettn.y(3) > yMax Then yMax = S.SP(i + 1).Rettn.y(3)
            Next i
            xMin = S.SP(2).Rettn.x(1)
            For j = n To 2 Step -1
                If S.SP(j + 1).Nspicchi > 0 Then
                    xMax = S.SP(j + 1).Rettn.x(3)
                    Exit For
                End If
            Next
            yMin = S.SP(2).Rettn.y(1)
        Else
            offx = S.SP(1).Rettn.LARG / 2 + 50
            yMax = S.SP(1).Rettn.y(3)
            For j = 1 To 4
                S.SP(1).Rettn.x(j) = S.SP(1).Rettn.x(j) + offx
            Next j
            For j = 1 To S.SP(1).Nspicchi
                S.SP(1).LamSp(j - 1).Origin.X += offx
            Next j
            xMin = S.SP(1).Rettn.x(1)
            xMax = S.SP(1).Rettn.x(3) * 2
            yMin = S.SP(1).Rettn.y(1)
        End If
    End Sub
    Public Sub ShowLam(ByRef S As Spicchi, ByRef NLam As Short, ByRef TipOPT As Short)
        Dim ySmin, xSmin, xSmax, ySmax As Single
        Dim iLam, i As Short
        Dim xt, yt As Single
        Dim txt As String, txtheight As Single
        Dim Alf, ht, Spess As Single
        Dim Punti0 As New RoutBase1.clsPunti
        Dim Punti1 As New RoutBase1.clsPunti
        'ShowLamS sp, NLam, TipOPT
        Disposiz(S, NLam, xSmin, xSmax, ySmin, ySmax)
        Funzioni.DisRut.Scala(xSmin - (xSmax - xSmin) / 20, xSmax + (xSmax - xSmin) / 20, ySmin - (ySmax - ySmin) / 20, ySmax + (ySmax - ySmin) / 20)
        Dim gDove As Drawing.Graphics = Graphics.FromHwnd(Funzioni.DisRut.DoveDisegno.Handle)
        txtheight = gDove.MeasureString("A", Funzioni.DisRut.DoveDisegno.Font).Height
        gDove.Dispose()
        If NLam > 0 Then
            For iLam = 1 To NLam
                If S.SP(iLam + 1).Nspicchi > 0 Then
                    S.SP(iLam + 1).Rettn.RettGraf(Funzioni.DisRut, 1)
                    For i = 1 To S.SP(iLam + 1).Nspicchi
                        S.SP(iLam + 1).LamSp(i - 1).SpicGraf(2, Punti0, Punti1)
                    Next i
                    yt = S.SP(iLam + 1).Rettn.y(3) - 1.2 * txtheight
                    xt = 2 + S.SP(iLam + 1).Rettn.x(1)
                    txt = "Tipo" & Str(iLam)
                    Funzioni.DisRut.texts(xt, yt, txt, ht, Alf, Spess)
                End If
            Next iLam
        Else
            S.SP(1).Rettn.RettGraf(Funzioni.DisRut, 1)
            S.SP(1).LamSp(1 - 1).SpicGraf(2, Punti0, Punti1)
            yt = S.SP(1).Rettn.y(3) - 1.2 * txtheight
            xt = 2 + S.SP(1).Rettn.x(1)
            txt = "Tipo 0"
            Funzioni.DisRut.texts(xt, yt, txt, ht, Alf, Spess)
        End If
    End Sub
    Sub ShowLamS(ByRef Spv As Spicchi, ByRef NLam As Short, ByRef TipOPT As Short)
        Dim SP As New Spicchi
        Dim Tipo As Short
        Dim Ftesta As String = ""
        Dim iLam, i As Short
        Dim ySmin, xSmin, xSmax, ySmax As Single
        Dim boxy, boxyM As Single
1000:   Funzioni.DisRut.ApriPri(Inizio.Workdir & "\" & RTrim(job.Comm.Arch), ".PRL", 0, Tipo, Ftesta)
        CopiaSP(Spv, SP)
        'For i = 0 To 5: Sp(i) = SpV(i): Next
1010:   Disposiz(SP, NLam, xSmin, xSmax, ySmin, ySmax)
        '1020 Scala 0, 20, 210, 277, xSmin!, xSmax!, ySmin!, ySmax!, Scal!, offx, offy
        If NLam > 0 Then
            For iLam = 1 To NLam
                If SP.SP(iLam).Nspicchi > 0 Then
                    '1030   TrasfSp Sp(iLam), Scal!, offx, offy
                    SP.SP(iLam).Rettn.RettGraf(Funzioni.DisRut, 2)
                    For i = 1 To SP.SP(iLam).Nspicchi
                        '1050      SpicGrafS Sp(iLam).Spicchi(i), 0
1050:                   IUNL = 3
                        'SpicGraf Sp(iLam).Spicchi(i), 0
                        IUNL = 0
                    Next i
                    boxy = SP.SP(iLam).Rettn.y(3)
                    Funzioni.DisRut.texts(SP.SP(iLam).Rettn.x(1) + 5.0!, boxy + 20, "Tipo " & Str(iLam), 8.0!, 0.0!, 0.1)
                End If
            Next iLam
        Else
            'TrasfSp Sp(0), Scal!, offx, offy
            SP.SP(1).Rettn.RettGraf(Funzioni.DisRut, 2)
            IUNL = 3
            'SpicGraf Sp(0).Spicchi(1), 0
            IUNL = 0
            boxyM = SP.SP(1).Rettn.y(3)
            Funzioni.DisRut.texts(SP.SP(1).Rettn.x(1) + 5.0!, boxyM + 20, "Tipo 0", 8.0!, 0.0!, 0.1)
        End If
        Funzioni.DisRut.texts(10.0!, 0.0!, "LAMIERAMENTO CONI/FONDI A SETTORI  (per informazione)", 10.0!, 0.0!, 0.1)
        Funzioni.DisRut.texts(10.0!, 10.0!, "Tipo scelto:" & Str(TipOPT), 5.0!, 0.0!, 0.1)
        Funzioni.DisRut.ChiudiPRI()
    End Sub
    Sub ShowPad(ByRef de As Single, ByRef di As Single, ByRef Dmant As Single)
        Dim Rett As New RoutBase1.clsRectang
        Dim Al As Single
        Dim diGran, deGran As Single
        Dim DS1(36) As Single
        Dim DS0(36) As Single
        Dim dist0(65) As Single
        Dim dist1(65) As Single
        Dim ySmin, xSmin, xSmax, ySmax As Single
        Dim Cx, Cy As Single
        Dim i As Short
        Dim Theta As Single
        Dim y, Alfa As Single
        Dim cost, dd, sint As Single
        Al = (de - di) / 2 'altezza anello
        diGran = Dmant * GlobalRoutines.asin(CSng(di) / Dmant)
        deGran = diGran + 2 * Al
        MakeCorners(Rett, CSng(deGran + 40), CSng(de + 40))
        xSmin = Rett.Corners(1).X
        ySmin = Rett.Corners(1).y
        xSmax = Rett.Corners(3).X
        ySmax = Rett.Corners(3).y
        Cx = (Rett.Corners(1).X + Rett.Corners(3).X) / 2
        Cy = (Rett.Corners(1).y + Rett.Corners(3).y) / 2
        For i = 1 To 32
            Theta = (i - 1) * Pi / 2 / 31
            DS0(i) = Cx + di / 2.0! * System.Math.Cos(Theta)
            y = di / 2.0! * System.Math.Sin(Theta)
            Alfa = GlobalRoutines.asin(y / Dmant * 2)
            DS1(i) = Cy + Dmant / 2.0! * Alfa
        Next
        dist0(1) = DS0(1) + Al
        dist1(1) = DS1(1)
        dist0(32) = DS0(32)
        dist1(32) = DS1(32) + Al
        For i = 2 To 31
            dd = System.Math.Sqrt((DS1(i + 1) - DS1(i - 1)) ^ 2 + (DS0(i + 1) - DS0(i - 1)) ^ 2)
            cost = (DS0(i + 1) - DS0(i - 1)) / dd
            sint = (DS1(i + 1) - DS1(i - 1)) / dd
            dist0(i) = DS0(i) + Al * sint
            dist1(i) = DS1(i) - Al * cost
        Next
        'Scala 2, 32, pxmax - 4, pymax - 80, xSmin!, xSmax!, ySmin!, ySmax!, Scal!, offx!, offy!
        For i = 1 To 4
            Rett.Corners(i).X = offx + Scal * Rett.Corners(i).X
            Rett.Corners(i).y = offy + Scal * Rett.Corners(i).y
        Next i
        For i = 1 To 32
            DS0(i) = offx + Scal * DS0(i)
            DS1(i) = offy + Scal * DS1(i)
            dist0(i) = offx + Scal * dist0(i)
            dist1(i) = offy + Scal * dist1(i)
        Next
        'AltaRis
        RettGraf(Rett, 1)
        'primo
        'PSet (Int(DS0(1)), Int(DS1(1)))
        For i = 2 To 32
            'Line -(Int(DS0(i)), Int(DS1(i)))
        Next
        'PSet (Int(dist0(1)), Int(dist1(1)))
        For i = 2 To 32
            'Line -(Int(dist0(i)), Int(dist1(i)))
        Next
        'secondo
        'PSet (Int(DS0(1)), Int(DS1(1)))
        For i = 2 To 32
            'Line -(Int(DS0(i)), Int(DS1(1) - (DS1(i) - DS1(1))))
        Next
        'PSet (Int(dist0(1)), Int(dist1(1)))
        For i = 2 To 32
            'Line -(Int(dist0(i)), Int(dist1(1) - (dist1(i) - dist1(1))))
        Next
        'terzo
        'PSet (Int(DS0(32) - (DS0(1) - DS0(32))), Int(DS1(1)))
        For i = 2 To 32
            'Line -(Int(DS0(32) - (DS0(i) - DS0(32))), Int(DS1(i)))
        Next
        'PSet (Int(dist0(32) - (dist0(1) - dist0(32))), Int(dist1(1)))
        For i = 2 To 32
            'Line -(Int(dist0(32) - (dist0(i) - dist0(32))), Int(dist1(i)))
        Next
        'quarto
        'PSet (Int(DS0(32) - (DS0(1) - DS0(32))), Int(DS1(1)))
        For i = 2 To 32
            'Line -(Int(DS0(32) - (DS0(i) - DS0(32))), Int(DS1(1) - (DS1(i) - DS1(1))))
        Next
        'PSet (Int(dist0(32) - (dist0(1) - dist0(32))), Int(dist1(1)))
        For i = 2 To 32
            'Line -(Int(dist0(32) - (dist0(i) - dist0(32))), Int(dist1(1) - (dist1(i) - dist1(1))))
        Next
        'LOCATE 1, 10: Print " Tracciatura rinforzo bocchello (per informazione)";
        'LOCATE 59, 20: Print "<press any key>";
        'u$ = INPUT$(1)
        'Screen 0
        'UPGRADE_NOTE: Erase è stato aggiornato a System.Array.Clear. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1061"'
        System.Array.Clear(DS1, 0, DS1.Length)
        'UPGRADE_NOTE: Erase è stato aggiornato a System.Array.Clear. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1061"'
        System.Array.Clear(DS0, 0, DS0.Length)
        'UPGRADE_NOTE: Erase è stato aggiornato a System.Array.Clear. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1061"'
        System.Array.Clear(dist0, 0, dist0.Length)
        'UPGRADE_NOTE: Erase è stato aggiornato a System.Array.Clear. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1061"'
        System.Array.Clear(dist1, 0, dist1.Length)
        'MenuInit
        'WindowInit
        'MouseShow
    End Sub
    Public Function NumSpicGen(ByRef Formafuori As Boolean, ByRef Tit As String, ByRef IncrAlfa As Single, ByRef NSPI As Short) As Short
        Dim Risult(2) As String
        Dim Dom(3) As String
        Dim Nfield As Short
        Dim dAiu(2) As String
        Dim Archiv(2) As Short
        Dim Help As String = ""
        Dim Testo As String = ""
        Dim Num As Short
        Dom(1) = "N° spicchi"
        Dom(2) = "Sovraapert.Cono [°]"
        Dom(3) = "Sovrametallo Min [mm]"
        Select Case System.Math.Abs(CType(Membro.GenMem, clsGenMem).Tipo)
            Case 3, 4, 5
                Help = RadiceHelp & "::/Fondi.htm#FormSpicchi"
            Case 7
                Help = RadiceHelp & "::/Coni.htm#ConiSpicchi"
            Case 17
                Help = RadiceHelp & "::/Anelli.htm#AnSpicchi"
        End Select
        If Not Formafuori Then
            Nfield = 1
            Risult(2) = GlobalRoutines.myStr(IncrAlfa, 3, 2, False)
            Select Case CType(Membro.GenMem, clsGenMem).Tipo
                Case 3, 4 : Nfield = 2
                Case 5 : Nfield = 2 : Dom(2) = Dom(3)
            End Select
            If NSPI = -1 Then
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto ctype(Membro.Genmem,clsGenmem). Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                Select Case Membro.GenMem.Tipo
                    Case 7 : Risult(1) = Str(1)
                    Case 17 : Risult(1) = Str(2)
                    Case Else : Risult(1) = Str(0)
                End Select
            Else
                Risult(1) = Str(NSPI)
            End If
            If Not Monitor.Motore.InputDati(Nfield, Tit, Dom, Risult, Help, Archiv, dAiu) Then
                NumSpicGen = -1
                Exit Function
            End If
            '               a$ = Stringa1$(4) '" Zero spicchi significa un sol pezzo.|"
            '               Select Case AddMembrat
            '                 Case 3, 4: a$ = a$ + Stringa1$(6)
            '                 Case 5: a$ = a$ + Stringa1$(5)
            '               End Select
            '               junk = Alert(4, a$, 4, 3, 11, 58, at1(33), "", "")
            Num = Val(Risult(1))
            If Num > 16 Then
                Testo = " Si assume il valore 16  | pari al massimo previsto|"
                MsgBox(Testo)
                Num = 16
            End If
            NumSpicGen = Num
            IncrAlfa = Val(Risult(2))
            IncrAlfa = Int(10 * IncrAlfa) / 10.0!
        Else
            NumSpicGen = 0
        End If
    End Function
End Module