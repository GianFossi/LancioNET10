Option Strict Off
Option Explicit On
Imports System.Math
Imports RoutBase1
<Serializable()> Public Class Raggrupp
    '----------------------
    Inherits Membratura
    Public Tipo As Short 'codice delle membrature raggruppate
    'Public TipoMat As Short
    Private prDiamExt As Single
    Private prLarghezza As Single
    Private prLunghezza As Single
    Private prSpessore As Single
    Public Numero As Short ' nel caso 37: 1 setti di testa 2 setti di coda
    Public iQ As Short
    'Public GenMem As clsGenMem
    'Public Variato As Boolean
    Private Padre As Membratura
    <NonSerialized()> Private O, q As Membratura
    <NonSerialized()> Private PT As Piastrone
    <NonSerialized()> Private Fondo As Fondo
    <NonSerialized()> Private Coperchio As Piastrone
    <NonSerialized()> Private Calotta As CalDisc
    <NonSerialized()> Private Cassa As Cilindro
    <NonSerialized()> Private Guarn As clsGuarniz
    <NonSerialized()> Private Direz, Piede As RoutBase1.clsVec2
    <NonSerialized()> Private Linea1 As RoutBase1.clsLinea2
    <NonSerialized()> Private jt As Short
    <NonSerialized()> Private Alfa, dist2, apot As Single
    <NonSerialized()> Private nf1, nf2 As Short
    <NonSerialized()> Private R As Membratura
    <NonSerialized()> Private Y, X, Z As Single
    <NonSerialized()> Private p As Membratura
    <NonSerialized()> Private Raggio As Single
    <NonSerialized()> Private Diam, dist As Single
    <NonSerialized()> Private i As Short
    <NonSerialized()> Private i1 As Short
    <NonSerialized()> Private Largh As Single
    <NonSerialized()> Private Aiuto As String
    <NonSerialized()> Private Strin(2) As String
    <NonSerialized()> Private Vert As Boolean
    <NonSerialized()> Private rr As Single
    <NonSerialized()> Private z1, z2 As Single
    <NonSerialized()> Private npassi As Short
    <NonSerialized()> Private y1, dr As Single
    <NonSerialized()> Private Rcurv As Single
    Public Overrides Property Spessore() As Single
        Get
            Return prSpessore
        End Get
        Set(ByVal Value As Single)
            prSpessore = Value
        End Set
    End Property
    Public Overrides Property Lunghezza() As Single
        Get
            Return prLunghezza
        End Get
        Set(ByVal Value As Single)
            prLunghezza = Value
        End Set
    End Property
    Public Overrides Property Larghezza() As Single
        Get
            Return prLarghezza
        End Get
        Set(ByVal Value As Single)
            prLarghezza = Value
        End Set
    End Property
    Public Overrides Property Diamext() As Single
        Get
            Return prDiamExt
        End Get
        Set(ByVal Value As Single)
            prDiamExt = Value
        End Set
    End Property
    Public Overloads Sub leggi(ByVal DiscoR As String, ByVal Mode As Short)
        'Mode=0 ricalcolo,=1 editaggio
        Select Case Mode
            Case 0
                If Not Variato Then Exit Sub
                Call Aggancio(DiscoR)
                Pesi()
                StringMATE()
                GenMem.Leggiprezzi(Spessore, 0, 0)
                Appendi()
                CalcGrezzi()
                Variato = False
            Case 1
                Membro = Me
                FormDati.ShowDialog()
        End Select
    End Sub
    Public Overloads Sub CalcGrezzi()
        Dim O As Membratura
        Dim i As Short
        For i = 0 To GenMem.Appesi.Count
            O = GenMem.Appesi(i)
            O.CalcGrezzi()
        Next i
    End Sub
    Public Overloads Sub Pesi()
        Dim Obj As Membratura
        Dim i As Short
        GenMem.LeggiMat(TipoMat)
        GenMem.PesiSp(TipoMat)
        If GenMem.Tipo = 37 Then GeneraSetti()
        GenMem.Pnet0 = 0
        GenMem.plor0 = 0
        For i = 0 To GenMem.Appesi.Count - 1
            Obj = GenMem.Appesi(i)
            Obj.GenMem.Indmat1 = GenMem.Indmat1
            Obj.Pesi()
            GenMem.Pnet0 = GenMem.Pnet0 + Obj.GenMem.PNET
            GenMem.plor0 = GenMem.plor0 + Obj.GenMem.plor0
        Next i
    End Sub
    Public Overrides Sub StringMATE()
        Dim M0 As String = GenMem.MaterNome(1).Trim
        If M0 = "" Then M0 = GenMem.Materiale.Trim
        GenMem.Materiale = M0
    End Sub
    Public Sub New()
        MyBase.New()
        GenMem = New clsGenMem
        GenMem.Parent = Me
        TipoMat = 1
        Variato = True
    End Sub
    Protected Overrides Sub Finalize()
        GenMem = Nothing
        MyBase.Finalize()
    End Sub
    Public WriteOnly Property Base() As Membratura
        Set(ByVal Value As Membratura)
            Padre = Value
        End Set
    End Property
    Public Overrides Property Diametro() As Single
        Get
            Diametro = Diamext
        End Get
        Set(ByVal Value As Single)
            Diamext = Value
        End Set
    End Property

    Public Property TestaCoda() As Short
        Get
            Select Case DataSheet.DatiSh0.TEMALetter(3)
                Case "U"
                    TestaCoda = 0
                Case "L", "M", "N"
                    TestaCoda = 1
                Case "P", "S", "T", "W"
                    TestaCoda = 1
                Case "U"
                    TestaCoda = 1
                Case Else
                    MostraAiuto(IDHG.IDH_ERR_NOTEMALETTER)
                    TestaCoda = 1
            End Select
        End Get
        Set(ByVal Value As Short)

        End Set
    End Property
    Private Sub Appendi()
        Dim i As Short
        If GenMem.Appesi.Count() > 0 Then Exit Sub
        For i = 0 To Apparecchio.Elementi.Count() - 1
            If Apparecchio.Elementi(i).GenMem.Tipo = Tipo Then
                If Apparecchio.Elementi(i).GenMem.posizione.SuChi Is Me Then
                    GenMem.AppesiAddk(Apparecchio.Elementi(i))
                End If
            End If
        Next
    End Sub

    Public Sub GeneraSetti()
        If Not Caricamento And Editing Then
            GenMem.ClearAppesi(True)
        Else
            Exit Sub
        End If
        Dim n As OggList.NodeP = Apparecchio.Elementi.nodeHead.Next
        While Not n Is Nothing
            O = n.TextData
            If O.GenMem.Tipo = 26 Then GoTo Cont
            n = n.Next
        End While
        Exit Sub
Cont:
        jt = CType(O, Fascio).jt
        p = O.GenMem.posizione.SuChi
        If p Is Nothing Then
            MostraAiuto(IDHG.IDH_ERR_NOPT)
            Exit Sub
        End If
        If p.GenMem.Tipo <> 12 Then
            MostraAiuto(IDHG.IDH_ERR_NOPT)
            Exit Sub
        End If
        If Numero = 2 Then
            For i = 0 To Apparecchio.Elementi.Count - 1
                O = Apparecchio.Elementi(i)
                If O.GenMem.Tipo = 12 And Not O Is p Then
                    PT = O
                    GoTo ContPT
                End If
            Next i
            MostraAiuto(IDHG.IDH_ERR_NO2PT)
            Exit Sub
        End If
        PT = p
ContPT:
        GenMem.posizione.SuChi = PT
        If Numero = 0 Then Numero = 1 'Exit Sub
        Dim iq, ir As Short
        For i = 0 To Apparecchio.Elementi.Count - 1
            O = Apparecchio.Elementi(i)
            If (O.GenMem.posizione.SuChi Is PT And Mid(O.GenMem.posizione.Quota, 6, 1) = "C") Or (PT.GenMem.posizione.SuChi Is O And Mid(PT.GenMem.posizione.Quota, 6, 1) = "C") Then
                If O.GenMem.Tipo = 1 Then
                    Cassa = O
                    GoTo Cont1
                ElseIf O.GenMem.Tipo = 28 Then
                    Guarn = O
                    For iq = 0 To Apparecchio.Elementi.Count - 1
                        q = Apparecchio.Elementi(iq)
                        If ((q.GenMem.posizione.SuChi Is Guarn) Or (Guarn.GenMem.posizione.SuChi Is q)) And Not PT Is q Then
                            If q.GenMem.Tipo = 11 Then
                                For ir = 0 To Apparecchio.Elementi.Count - 1
                                    R = Apparecchio.Elementi(ir)
                                    If (q.GenMem.posizione.SuChi Is R) Or (R.GenMem.posizione.SuChi Is q) Then
                                        If R.GenMem.Tipo = 1 Then
                                            Cassa = R
                                            GoTo Cont1
                                        ElseIf R.GenMem.Tipo = 16 Then
                                            Calotta = R
                                            GoTo Cont1
                                        End If
                                    End If
                                Next ir
                            End If
                        End If
                    Next iq
                End If
            End If
        Next i
        MostraAiuto(IDHG.IDH_ERR_NOCASSA)
        Exit Sub
Cont1:
        If Not Cassa Is Nothing Then
            Diam = Cassa.Diametro
            CercaFondo(Cassa, PT, Fondo, Coperchio)
            If Not Coperchio Is Nothing Then
                Tipo = 1
                dist = PT.GenMem.posizione.Origine.DistPunPun((Coperchio.GenMem.posizione.Origine))
            ElseIf Not Fondo Is Nothing Then
                Select Case Fondo.GenMem.Tipo
                    Case 3, 4
                        MsgBox("da programmare in GeneraSetti")
                        Exit Sub
                    Case 5
                        Tipo = 2
                        Raggio = Fondo.Diametro / 2
                        dist = PT.GenMem.posizione.Origine.DistPunPun((Fondo.GenMem.posizione.Origine))
                End Select
            End If
        ElseIf Not Calotta Is Nothing Then
            If Calotta.RaggioCal > 0 Then
                Tipo = 2
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto q.DiamInt. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                Diam = q.Diamint
                Raggio = Calotta.RaggioCal
                dist = PT.GenMem.posizione.Origine.DistPunPun((Calotta.GenMem.posizione.Origine))
            Else
                MsgBox("Errore calotta in GeneraSetti")
                Exit Sub
            End If
        End If
        Vert = False
        Y = 0
        Select Case Numero
            Case 1
                Select Case jt
                    Case 0
                        MostraAiuto(IDHG.IDH_ERR_NOFILETRAC)
                        Exit Sub
                    Case 1
                        MostraAiuto(IDHG.IDH_ERR_UNSOLOPASSO)
                        Exit Sub
                    Case 2 '2 passi U
                        nf1 = DaTos.FilaFinale(1)
                        nf2 = DaTos.FilaIniziale(2)
                        Z = (DaTos.y(nf1) + DaTos.y(nf2)) / 2
                        Largh = 2 * System.Math.Sqrt((Diam / 2) ^ 2 - Z ^ 2)
                        SetStriscia()
                    Case 3 '3 passi
                        nf1 = DaTos.FilaFinale(2)
                        nf2 = DaTos.FilaIniziale(3)
                        Z = (DaTos.y(nf1) + DaTos.y(nf2)) / 2
                        Largh = 2 * System.Math.Sqrt((Diam / 2) ^ 2 - Z ^ 2)
                        SetStriscia()
                    Case 4 '4 passi
                        nf1 = DaTos.FilaFinale(1)
                        nf2 = DaTos.FilaIniziale(2)
                        Z = (DaTos.y(nf1) + DaTos.y(nf2)) / 2
                        Largh = 2 * System.Math.Sqrt((Diam / 2) ^ 2 - Z ^ 2)
                        'UPGRADE_ISSUE: L'istruzione GoSub non è supportata. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1014"'
                        SetStriscia()
                        nf1 = DaTos.FilaFinale(3)
                        nf2 = DaTos.FilaIniziale(4)
                        Z = (DaTos.y(nf1) + DaTos.y(nf2)) / 2
                        Largh = 2 * System.Math.Sqrt((Diam / 2) ^ 2 - Z ^ 2)
                        'UPGRADE_ISSUE: L'istruzione GoSub non è supportata. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1014"'
                        SetStriscia()
                    Case 5 '4 passi con setto verticale
                        nf1 = DaTos.FilaFinale(1)
                        nf2 = DaTos.FilaIniziale(2)
                        Z = (DaTos.y(nf1) + DaTos.y(nf2)) / 2
                        Largh = 2 * System.Math.Sqrt((Diam / 2) ^ 2 - Z ^ 2)
                        'UPGRADE_ISSUE: L'istruzione GoSub non è supportata. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1014"'
                        SetStriscia()
                        nf1 = DaTos.FilaFinale(2)
                        nf2 = DaTos.FilaIniziale(4)
                        Z = (DaTos.y(nf1) + DaTos.y(nf2)) / 2
                        Largh = 2 * System.Math.Sqrt((Diam / 2) ^ 2 - Z ^ 2)
                        'UPGRADE_ISSUE: L'istruzione GoSub non è supportata. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1014"'
                        SetStriscia()
                    Case 6 '4 passi U con setto verticale
                        Strin(1) = HelpStringa(IDHG.IDH_STR_4PASSI1) 'uscita dall'alto 1/2 setto verticale 1 orizzontale
                        Strin(2) = HelpStringa(IDHG.IDH_STR_4PASSI2) 'uscita dal basso 1/2 setto orizzontale 1 verticale
                        Aiuto = RadiceHelp & "::/SettiP.htm#4passi"
                        iq = Monitor.Motore.Quale(2, "Disposizione connessioni", Strin, Aiuto, 1)
                        nf1 = DaTos.FilaFinale(1)
                        nf2 = DaTos.FilaIniziale(3)
                        z1 = (DaTos.y(nf1) + DaTos.y(nf2)) / 2
                        Select Case iq
                            Case 1
                                Z = z1
                                Largh = 2 * System.Math.Sqrt((Diam / 2) ^ 2 - Z ^ 2)
                                'UPGRADE_ISSUE: L'istruzione GoSub non è supportata. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1014"'
                                SetStriscia()
                                Vert = True
                                Largh = Diam / 2 - Z - Spessore / 2
                                Z = Diam / 2 - Largh / 2
                                nf1 = DaTos.FilaFinale(3)
                                nf2 = DaTos.FilaIniziale(4)
                                Y = (DaTos.xf(nf1) + DaTos.xf(nf2)) / 2
                                'UPGRADE_ISSUE: L'istruzione GoSub non è supportata. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1014"'
                                SetStriscia()
                            Case 2
                                nf2 = DaTos.FilaIniziale(2)
                                Y = (DaTos.xf(nf1) + DaTos.xs(nf2)) / 2
                                Largh = 2 * System.Math.Sqrt((Diam / 2) ^ 2 - Y ^ 2)
                                Vert = True
                                Z = 0
                                'UPGRADE_ISSUE: L'istruzione GoSub non è supportata. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1014"'
                                SetStriscia()
                                Vert = False
                                Z = z1
                                Largh = System.Math.Sqrt((Diam / 2) ^ 2 - Z ^ 2) + Y - Spessore / 2
                                Y = Y - Largh / 2
                                'UPGRADE_ISSUE: L'istruzione GoSub non è supportata. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1014"'
                                SetStriscia()
                            Case Else
                                Exit Sub
                        End Select
                    Case 7, 9, 11, 13 '6 8 10 12 passi
                        npassi = jt - 1
                        For i = 2 To npassi Step 2
                            nf1 = DaTos.FilaFinale(i - 1)
                            nf2 = DaTos.FilaIniziale(i)
                            Z = (DaTos.y(nf1) + DaTos.y(nf2)) / 2
                            Largh = 2 * System.Math.Sqrt((Diam / 2) ^ 2 - Z ^ 2)
                            'UPGRADE_ISSUE: L'istruzione GoSub non è supportata. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1014"'
                            SetStriscia()
                        Next
                    Case 8, 10, 12, 14 '6 8 10 12 passi U
                        npassi = jt - 2
                        nf1 = DaTos.FilaFinale(1)
                        nf2 = DaTos.FilaIniziale(2)
                        Z = 0
                        Y = (DaTos.xf(nf1) + DaTos.xs(nf2)) / 2
                        Largh = 2 * System.Math.Sqrt((Diam / 2) ^ 2 - Y ^ 2)
                        Vert = True
                        'UPGRADE_ISSUE: L'istruzione GoSub non è supportata. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1014"'
                        SetStriscia()
                        Vert = False
                        For i = 2 To npassi Step 4
                            nf1 = DaTos.FilaFinale(i)
                            nf2 = DaTos.FilaIniziale(i + 2)
                            Z = (DaTos.y(nf1) + DaTos.y(nf2)) / 2
                            nf2 = DaTos.FilaIniziale(i - 1)
                            Y = (DaTos.xf(nf1) + DaTos.xf(nf2)) / 2
                            Largh = System.Math.Sqrt((Diam / 2) ^ 2 - Z ^ 2) - Y - Spessore / 2
                            Y = Y + Largh / 2
                            'UPGRADE_ISSUE: L'istruzione GoSub non è supportata. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1014"'
                            SetStriscia()
                        Next
                        For i = 3 To npassi Step 4
                            nf1 = DaTos.FilaFinale(i)
                            nf2 = DaTos.FilaIniziale(i + 2)
                            Z = (DaTos.y(nf1) + DaTos.y(nf2)) / 2
                            nf2 = DaTos.FilaIniziale(i - 1)
                            Y = (DaTos.xf(nf1) + DaTos.xf(nf2)) / 2
                            Largh = System.Math.Sqrt((Diam / 2) ^ 2 - Z ^ 2) + Y - Spessore / 2
                            Y = Y - Largh / 2
                            'UPGRADE_ISSUE: L'istruzione GoSub non è supportata. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1014"'
                            SetStriscia()
                        Next
                End Select
            Case 2
                Select Case jt
                    Case 0
                        MostraAiuto(IDHG.IDH_ERR_NOFILETRAC)
                        Exit Sub
                    Case 1
                        MostraAiuto(IDHG.IDH_ERR_UNSOLOPASSO)
                        Exit Sub
                    Case 2 '2 passi U
                        'If Numero = 1 Then
                        MostraAiuto(IDHG.IDH_ERR_INCONGRUENZA)
                        Exit Sub
                        'End If
                    Case 3 '3 passi
                        nf1 = DaTos.FilaFinale(1)
                        nf2 = DaTos.FilaIniziale(2)
                        Z = (DaTos.y(nf1) + DaTos.y(nf2)) / 2
                        Largh = 2 * System.Math.Sqrt((Diam / 2) ^ 2 - Z ^ 2)
                        'UPGRADE_ISSUE: L'istruzione GoSub non è supportata. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1014"'
                        SetStriscia()
                    Case 4 '4 passi
                        nf1 = DaTos.FilaFinale(2)
                        nf2 = DaTos.FilaIniziale(3)
                        Z = (DaTos.y(nf1) + DaTos.y(nf2)) / 2
                        Largh = 2 * System.Math.Sqrt((Diam / 2) ^ 2 - Z ^ 2)
                        'UPGRADE_ISSUE: L'istruzione GoSub non è supportata. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1014"'
                        SetStriscia()
                    Case 5 '4 passi con setto verticale
                        nf1 = DaTos.FilaFinale(1)
                        nf2 = DaTos.FilaIniziale(2)
                        z1 = (DaTos.y(nf1) + DaTos.y(nf2)) / 2 - Spessore / 2
                        nf1 = DaTos.FilaFinale(2)
                        nf2 = DaTos.FilaIniziale(4)
                        z2 = (DaTos.y(nf1) + DaTos.y(nf2)) / 2 + Spessore / 2
                        'nf1 = DaTos.FilaFinale(2)
                        'nf2 = DaTos.FilaIniziale(3)
                        Y = 0 '(DaTos.xf(nf1) + DaTos.xf(nf2)) / 2
                        Largh = z2 - z1
                        Vert = True
                        Z = (z1 + z2) / 2
                        'UPGRADE_ISSUE: L'istruzione GoSub non è supportata. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1014"'
                        SetStriscia()
                        Vert = False
                        Y = Y - Spessore / 2
                        Largh = System.Math.Sqrt((Diam / 2) ^ 2 - z1 ^ 2) + Y
                        Y = Y - Largh / 2
                        Z = z1
                        'UPGRADE_ISSUE: L'istruzione GoSub non è supportata. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1014"'
                        SetStriscia()
                        Y = Y + Spessore
                        Largh = System.Math.Sqrt((Diam / 2) ^ 2 - z2 ^ 2) - Y
                        Y = Y + Largh / 2
                        Z = z2
                        'UPGRADE_ISSUE: L'istruzione GoSub non è supportata. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1014"'
                        SetStriscia()
                    Case 6 '4 passi U con setto verticale
                        Strin(1) = HelpStringa(IDHG.IDH_STR_4PASSI1)
                        Strin(2) = HelpStringa(IDHG.IDH_STR_4PASSI2)
                        Aiuto = RadiceHelp & "::/SettiP.htm#4passi"
                        iq = Monitor.Motore.Quale(2, "Disposizione connessioni", Strin, Aiuto, 1)
                        Select Case iq
                            Case 1
                                nf1 = DaTos.FilaFinale(1)
                                nf2 = DaTos.FilaIniziale(3)
                                Z = (DaTos.y(nf1) + DaTos.y(nf2)) / 2
                                Largh = 2 * System.Math.Sqrt((Diam / 2) ^ 2 - Z ^ 2)
                                'UPGRADE_ISSUE: L'istruzione GoSub non è supportata. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1014"'
                                SetStriscia()
                            Case 2
                                nf1 = DaTos.FilaFinale(1)
                                nf2 = DaTos.FilaIniziale(2)
                                Y = (DaTos.xf(nf1) + DaTos.xf(nf2)) / 2
                                Z = 0
                                Largh = 2 * System.Math.Sqrt((Diam / 2) ^ 2 - Y ^ 2)
                                Vert = True
                                'UPGRADE_ISSUE: L'istruzione GoSub non è supportata. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1014"'
                                SetStriscia()
                        End Select
                    Case 7, 9, 11, 13 '6 8 10 12 passi
                        npassi = jt - 1
                        nf1 = DaTos.FilaFinale(2)
                        nf2 = DaTos.FilaFinale(3)
                        y1 = (DaTos.xf(nf1) + DaTos.xs(nf2)) / 2 + Spessore / 2
                        Largh = System.Math.Sqrt((Diam / 2) ^ 2 - y1 ^ 2)
                        nf1 = DaTos.FilaFinale(2)
                        nf2 = DaTos.FilaFinale(1)
                        z1 = (DaTos.y(nf1) + DaTos.y(nf2)) / 2
                        Y = y1 + Largh / 2
                        Z = z1
                        'UPGRADE_ISSUE: L'istruzione GoSub non è supportata. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1014"'
                        SetStriscia()
                        For i = 5 To npassi Step 4
                            nf1 = DaTos.FilaFinale(i)
                            nf2 = DaTos.FilaFinale(i - 1)
                            y1 = (DaTos.xf(nf1) + DaTos.xs(nf2)) / 2 + Spessore / 2
                            Largh = System.Math.Sqrt((Diam / 2) ^ 2 - y1 ^ 2)
                            nf1 = DaTos.FilaFinale(i + 1)
                            nf2 = DaTos.FilaFinale(i - 1)
                            z1 = (DaTos.y(nf1) + DaTos.y(nf2)) / 2
                            Y = y1 + Largh / 2
                            Z = z1
                            'UPGRADE_ISSUE: L'istruzione GoSub non è supportata. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1014"'
                            SetStriscia()
                        Next
                        For i = 2 To npassi Step 4
                            nf1 = DaTos.FilaFinale(i)
                            nf2 = DaTos.FilaFinale(i + 2)
                            y1 = (DaTos.xf(nf1) + DaTos.xs(nf2)) / 2 - Spessore / 2
                            Largh = System.Math.Sqrt((Diam / 2) ^ 2 - y1 ^ 2)
                            z1 = (DaTos.y(nf1) + DaTos.y(nf2)) / 2
                            Y = y1 - Largh / 2
                            Z = z1
                            'UPGRADE_ISSUE: L'istruzione GoSub non è supportata. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1014"'
                            SetStriscia()
                        Next
                        Vert = True
                        nf1 = DaTos.FilaFinale(1)
                        nf2 = DaTos.FilaIniziale(npassi)
                        z1 = DaTos.y(nf1) - Spessore / 2
                        z2 = DaTos.y(nf2) + Spessore / 2
                        nf1 = DaTos.FilaFinale(2)
                        nf2 = DaTos.FilaFinale(3)
                        Y = (DaTos.xf(nf1) + DaTos.xs(nf2)) / 2
                        Largh = z2 - z1
                        Z = (z1 + z2) / 2
                        'UPGRADE_ISSUE: L'istruzione GoSub non è supportata. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1014"'
                        SetStriscia()
                    Case 8, 10, 12, 14 '6 8 10 12 passi U
                        npassi = jt - 2
                        For i = 1 To npassi - 2 Step 2
                            nf1 = DaTos.FilaFinale(i)
                            nf2 = DaTos.FilaIniziale(i + 2)
                            Y = 0
                            Z = (DaTos.y(nf1) + DaTos.y(nf2)) / 2
                            Largh = 2 * System.Math.Sqrt((Diam / 2) ^ 2 - Z ^ 2)
                            'UPGRADE_ISSUE: L'istruzione GoSub non è supportata. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1014"'
                            SetStriscia()
                        Next
                End Select
        End Select
        'Funzioni.AggiornaApparecchio Me
        Exit Sub
    End Sub
    Private Sub SetStriscia()
        Dim SS As Membratura
        Select Case Tipo
            Case 1 : SS = New Striscia
            Case 2 : SS = New clsPolig
            Case Else : Exit Sub
        End Select
        i = i + 1
        GenMem.Copia(SS.GenMem)
        SS.GenMem.Parent = Me
        Select Case Tipo
            Case 1
                With CType(SS, Striscia)
                    .GenMem.Tipo = -15
                    .Larghezza = Largh
                    .Lunghezza = dist
                End With
            Case 2
                With CType(SS, clsPolig)
                    .GenMem.Tipo = -96
                    .Npunti = 4
                    .Rifer = 1
                    .Vertici.Punti(1).X = Largh / 2
                    .Vertici.Punti(1).y = 0
                    .Centri.Punti(1).X = 0
                    .Centri.Punti(1).y = 0
                    .Raggi(1).TextData = 0
                    .Vertici.Punti(2).X = Largh / 2
                    rr = System.Math.Sqrt((Y + Largh / 2) ^ 2 + Z ^ 2)
                    dr = System.Math.Sqrt(Raggio ^ 2 - rr ^ 2) - System.Math.Sqrt(Raggio ^ 2 - (Diam / 2) ^ 2)
                    .Vertici.Punti(2).y = dist + dr
                    .Vertici.Punti(3).X = -Largh / 2
                    rr = System.Math.Sqrt((Y - Largh / 2) ^ 2 + Z ^ 2)
                    dr = System.Math.Sqrt(Raggio ^ 2 - rr ^ 2) - System.Math.Sqrt(Raggio ^ 2 - (Diam / 2) ^ 2)
                    .Vertici.Punti(3).y = dist + dr
                    .Centri.Punti(3).X = 0
                    .Centri.Punti(3).y = 0
                    .Raggi(3).TextData = 0
                    .Vertici.Punti(4).X = -Largh / 2
                    .Vertici.Punti(4).y = 0
                    .Centri.Punti(4).X = 0
                    .Centri.Punti(4).y = 0
                    .Raggi(4).TextData = 0
                    Rcurv = System.Math.Sqrt(Raggio ^ 2 - Z ^ 2)
                    i = 2
                    .Raggi(i).TextData = Rcurv
                    i1 = i + 1
                    If i1 > .Npunti Then i1 = 1
                    dist2 = .Vertici.Punti(i).DistPunPun(.Vertici.Punti(i1))
                    Alfa = GlobalRoutines.asin(dist2 / 2 / System.Math.Abs(Rcurv))
                    apot = Rcurv * System.Math.Cos(Alfa)
                    Linea1 = New RoutBase1.clsLinea2
                    Linea1.P0 = New RoutBase1.clsVec2
                    Linea1.P0.X = .Vertici.Punti(i).X
                    Linea1.P0.y = .Vertici.Punti(i).y
                    Linea1.p1 = New RoutBase1.clsVec2
                    Linea1.p1.X = .Vertici.Punti(i1).X
                    Linea1.p1.y = .Vertici.Punti(i1).y
                    Linea1.CalcolaDir()
                    Direz = New RoutBase1.clsVec2
                    Direz.X = -Linea1.Direz.y
                    Direz.y = Linea1.Direz.X
                    '        Linea1.Direz.x = Direz.x
                    '        Linea1.Direz.y = Direz.y
                    Piede = New RoutBase1.clsVec2
                    Piede.X = (.Vertici.Punti(i).X + .Vertici.Punti(i1).X) / 2
                    Piede.y = (.Vertici.Punti(i).y + .Vertici.Punti(i1).y) / 2
                    .Centri.Punti(i).X = Piede.X + Direz.X * apot
                    .Centri.Punti(i).y = Piede.y + Direz.y * apot
                End With
        End Select
        With SS
            .GenMem.Denom = "SettoT" & Trim(Str(i))
            .GenMem.PosDis = 0 ' SealStrips.GenMem.PosDis
            .GenMem.posizione.SuChi = Me
            .GenMem.Qta = 1
            .GenMem.posizione.DirDiritta = "=+"
            .GenMem.posizione.Quota = "Ne"
            .Spessore = Spessore
            .GenMem.posizione.Raggio = System.Math.Abs(Z)
            If Y = 0 Then
                If Z > 0 Then
                    .GenMem.posizione.Anomal = "+N"
                Else
                    .GenMem.posizione.Anomal = "-N"
                End If
            Else
                rr = System.Math.Sqrt(Y ^ 2 + Z ^ 2)
                Alfa = GlobalRoutines.arco(Y / rr, Z / rr) * 180 / PI
                .GenMem.posizione.Anomal = Str(Alfa)
                .GenMem.posizione.Raggio = rr
            End If
            If Vert Then
                .GenMem.posizione.DirTraversa = "+N"
            Else
                .GenMem.posizione.DirTraversa = "Up"
            End If
            GenMem.AppesiAdd(SS)
            AggCoordN(.GenMem)
        End With
    End Sub
    Public Overloads Sub Copia(ByRef A As Raggrupp)
        Dim O As Membratura = Nothing
        Dim Oc As Membratura = Nothing
        If A Is Nothing Then A = New Raggrupp
        A.Tipo = Tipo
        A.TipoMat = TipoMat
        A.Diamext = Diamext
        A.Larghezza = Larghezza
        A.Lunghezza = Lunghezza
        A.Spessore = Spessore
        A.Numero = Numero
        A.iQ = iQ
        GenMem.Copia(A.GenMem)
        A.GenMem.Parent = A
        Dim n As OggList.NodeP = GenMem.Appesi.nodeHead.Next
        While Not n Is Nothing
            O = n.TextData
            O.Copia(Oc)
            Oc.GenMem.posizione.SuChi = A
            A.GenMem.AppesiAdd(Oc)
            n = n.Next
        End While
    End Sub
End Class