Option Strict Off
Option Explicit On
Module Rettang
	
	'Function DistPunLinea(Pun As Vec2, Lin As Linea2)
	'If Abs(Lin.P0.X - Lin.P1.X) < TOLER Then
	'   DistPunLinea = Abs(Pun.X - Lin.P0.X)
	'ElseIf Abs(Lin.P0.Y - Lin.P1.Y) < TOLER Then
	'   DistPunLinea = Abs(Pun.Y - Lin.P0.Y)
	'Else
	'   Dim Ret As Vec3
	'   Ret.X = -1 / (Lin.P1.X - Lin.P0.X)
	'   Ret.Y = 1 / (Lin.P1.Y - Lin.P0.Y)
	'   Ret.Z = -Lin.P0.Y * Ret.Y - Lin.P0.X * Ret.X
	'   DistPunLinea = DistPunRet(Pun, Ret)
	'End If
	'End Function
	
    Function DistPunRet(ByRef Pun As RoutBase1.clsVec2, ByRef Ret As RoutBase1.clsVec3) As Single
        DistPunRet = System.Math.Abs(Ret.X * Pun.X + Ret.y * Pun.Y + Ret.Z) / System.Math.Sqrt(Ret.X ^ 2 + Ret.y ^ 2)
    End Function
    Sub MakeCorners(ByRef Rett As RoutBase1.clsRectang, ByRef Lu As Single, ByRef La As Single)
        Rett.Corners(1).X = -La / 2
        Rett.Corners(2).X = La / 2
        Rett.Corners(3).X = La / 2
        Rett.Corners(4).X = -La / 2
        Rett.Corners(1).y = 0
        Rett.Corners(2).y = 0
        Rett.Corners(3).y = Lu
        Rett.Corners(4).y = Lu
        Rett.Lung = Lu
        Rett.LARG = La
    End Sub
    Sub Rota90(ByRef SP As SpicLam)
        Dim i As Short
        Dim Dum As Single
        Dum = SP.Rettn.Lung
        SP.Rettn.Lung = SP.Rettn.LARG
        SP.Rettn.LARG = Dum
        SP.Rettn.MakeCorners(SP.Rettn.Lung, SP.Rettn.LARG)
        For i = 1 To SP.Nspicchi
            Dum = SP.LamSp(i - 1).Origin.X
            SP.LamSp(i - 1).Origin.X = SP.LamSp(i - 1).Origin.y
            SP.LamSp(i - 1).Origin.y = Dum
            SP.LamSp(i - 1).Origin.X -= SP.Rettn.LARG / 2
            SP.LamSp(i - 1).Origin.y += SP.Rettn.Lung / 2
            Dum = SP.LamSp(i - 1).Direct.X
            SP.LamSp(i - 1).Direct.X = SP.LamSp(i - 1).Direct.y
            SP.LamSp(i - 1).Direct.y = Dum
        Next i
    End Sub
    Sub RotRett(ByRef Rett As RoutBase1.clsRectang, ByRef X As Single, ByRef Y As Single, ByRef Alfa As Single)
        'ruota intorno a (x,y)
        Dim Origin As New RoutBase1.clsVec2
        Dim Direz As New RoutBase1.clsVec2
        Dim i As Short
        Dim Vec As New RoutBase1.clsVec2
        Origin.X = X : Origin.y = Y
        Direz.X = System.Math.Cos(Alfa) : Direz.y = System.Math.Sin(Alfa)
        For i = 1 To 4
            Vec.X = Rett.Corners(i).X
            Vec.y = Rett.Corners(i).y
            TraslRot(Vec, Origin, Direz)
            Rett.Corners(i).X = Vec.X
            Rett.Corners(i).y = Vec.y
        Next
    End Sub
    Sub TrasfRett(ByRef Rett As RoutBase1.clsRectang, ByRef Scalb As Single, ByRef offx As Single, ByRef offy As Single)
        Dim i As Short
        For i = 1 To 4
            Rett.Corners(i).X = offx + Scalb * Rett.Corners(i).X
            Rett.Corners(i).y = offy + Scalb * Rett.Corners(i).y
        Next i
    End Sub

    'Sub TrasfSp(Spi As LamSpicchi, Scalb As Single, offx As Single, offy As Single)
    'Dim i As Integer
    'TrasfRett Spi.Rett, Scalb, offx, offy
    'For i = 1 To Spi.NSpicchi
    '  Trasfspicchio Spi.Spicchi(i), Scalb, offx, offy
    'Next i
    'End Sub

    'Sub Trasfspicchio(sp As spicchio, Scalb As Single, offx As Single, offy As Single)
    '  sp.RP = sp.RP * Scalb
    '  sp.RG = sp.RG * Scalb
    '  sp.Origin.X = sp.Origin.X * Scalb + offx
    '  sp.Origin.Y = sp.Origin.Y * Scalb + offy
    'End Sub


    Sub TraslRot(ByRef p As RoutBase1.clsVec2, ByRef Origin As RoutBase1.clsVec2, ByRef Direz As RoutBase1.clsVec2)
        'UPGRADE_NOTE: Dir è stato aggiornato a Dir_Renamed. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1061"'
        Dim Dir_Renamed As New RoutBase1.clsVec2
        Dim Y, yp, xp, X, dist As Single
        Dim dy, dx, Alfa0 As Single
        xp = p.X : yp = p.y
        X = Origin.X : Y = Origin.y
        dx = xp - X : dy = yp - Y
        dist = System.Math.Sqrt(dx * dx + dy * dy)
        If dist > 0.01 Then
            Dir_Renamed.X = dx / dist : Dir_Renamed.y = dy / dist
            Alfa0 = GlobalRoutines.arco((Dir_Renamed.X), (Dir_Renamed.y)) + GlobalRoutines.arco((Direz.X), (Direz.y))
            p.X = X + dist * System.Math.Cos(Alfa0)
            p.y = Y + dist * System.Math.Sin(Alfa0)
        End If
    End Sub
End Module