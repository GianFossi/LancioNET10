Option Strict Off
Option Explicit On
Public Class Auto_CAD
    'Evento per la gestione degli errori
    Event Errore(ByRef numero As Errori, ByRef Codice As String)
    'Struttura per la gestione degli errori
    Public Enum Errori
        AutoCAD_Non_Trovato = 0
        AutoCAD_Impossibile_Chiudere = 1
        AutoCAD_Metodo_non_Disponibile = 2
        AutoCAD_File_Non_Trovato = 3
        AutoCAD_Errore_interno = 4
        AutoCAD_Impossibile_Creare_Nuovo_File = 5
        AutoCAD_Impossibile_Creare_il_Layer = 6
        AutoCAD_Impossibile_Rigenerare = 7
        AutoCAD_Impossibile_Zoom = 8
        AutoCAD_Impossibile_Creare_Arco = 9
        AutoCAD_Impossibile_Assegnare_Layer = 10
        AutoCAD_Impossibile_Creare_Linea = 11
        AutoCAD_Impossibile_Creare_Cerchio = 12
        AutoCAD_Oggetto_Non_valido = 13
        AutoCAD_Impossibile_Quotare = 14
        AutoCAD_Impossibile_Creare_Oggetto_Utility = 15
        AutoCAD_Impossibile_Spostare = 16
        AutoCAD_Impossibile_Specchiare = 17
        AutoCAD_Impossibile_Cancellare = 18
        AutoCAD_Impossibile_Trovare_File = 19
        AutoCAD_Impossibile_Ruotare = 20
        AutoCAD_Impossibile_Creare_Gruppo = 21
        AutoCAD_Impossibile_Aggiungere_al_Gruppo = 22 'era 21
        AutoCAD_Impossibile_Copiare = 23 'era 21
    End Enum
    Public Enum Tipi_Linee
        Bordo = 0
        Centro = 1
        TrattoPunto = 2
        Tratteggiata = 3
        Dividi = 4
        Punto = 5
        Nascosta = 6
        Fantasma = 7
        Continua = 8
    End Enum

    Public Enum Colori
        ByBlock = 0
        ByLayer = 256
        Rosso = 1
        Giallo = 2
        Verde = 3
        Ciano = 4
        Blu = 5
        Magenta = 6
        Bianco = 7
    End Enum

    Const PiGreco_Rad As Double = Math.PI / 180

    'Nomi delle linee
    Dim Nomi_Linee As New Collection

    'Definizione Punti
    Private Punto1(2) As Double
    Private Punto2(2) As Double
    Private Punto3(2) As Double
    Private Punto4(2) As Double

    'Variabili per la gestione di Xdata
    Private DataType(9) As Short
    'FIXIT: Dichiarare "Data" con un tipo di dati ad associazione anticipata                   FixIT90210ae-R1672-R1B8ZE
    Private Data(9) As Object


    Private cls_App_Obj As AutoCAD.AcadApplication
    Private cls_Doc_Obj As AutoCAD.AcadDocument
    Private cls_Layer As AutoCAD.AcadLayer
    Private cls_ViewPort As AutoCAD.AcadViewport
    Private cls_Utility As AutoCAD.AcadUtility
    Private cls_Entita As AutoCAD.AcadEntity
    Private cls_Gruppo As AutoCAD.AcadGroup
    'Viariabili locali
    Private mvarLunghezza As Integer 'Copia locale.
    Private mvarAltezza As Integer 'Copia locale.
    Private mvarVisibile As Boolean 'Copia locale.
    Private mvarVersione As String 'Copia locale.
    Private mvarCaption As String 'Copia locale.
    'FIXIT: Dichiarare "ObjGruppo" con un tipo di dati ad associazione anticipata              FixIT90210ae-R1672-R1B8ZE
    Private ObjGruppo() As Object
    Private ContoObj As Short
    'FIXIT: Dichiarare "Punto" con un tipo di dati ad associazione anticipata                  FixIT90210ae-R1672-R1B8ZE
    Public Function GetEntity(ByRef Punto As Object) As AutoCAD.AcadEntity
        'FIXIT: Dichiarare "sset" con un tipo di dati ad associazione anticipata                   FixIT90210ae-R1672-R1B8ZE
        Dim sset As Object
        Dim Punto1(2) As Double
        'FIXIT: Dichiarare "V1" con un tipo di dati ad associazione anticipata                     FixIT90210ae-R1672-R1B8ZE
        Dim V1 As Object
        'FIXIT: Dichiarare "V2" con un tipo di dati ad associazione anticipata                     FixIT90210ae-R1672-R1B8ZE
        Dim V2 As Object
        'AppActivate Me.Caption
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Punto(). Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
        Punto1(0) = Punto(0) + 2
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Punto(). Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
        Punto1(1) = Punto(1) + 2
        Punto1(2) = 0
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto V1. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
        V1 = VB6.CopyArray(Punto1)
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Punto(). Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
        Punto1(0) = Punto(0) - 2
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Punto(). Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
        Punto1(1) = Punto(1) - 2
        Punto1(2) = 0
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto V2. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
        V2 = VB6.CopyArray(Punto1)
        sset = cls_Doc_Obj.SelectionSets.Add("zxisd")
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto sset.Select. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
        sset.Select(AutoCAD.AcSelect.acSelectionSetCrossing, V2, V1)
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto sset.Item. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
        If Not sset.Item(0) Is Nothing Then
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto sset.Item. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            GetEntity = sset.Item(0)
        Else
            GetEntity = Nothing
        End If
    End Function
    Public Sub inserisciBlocco(ByRef Nome As String, ByRef numero As Integer, ByVal P0 As clsVec2, ByVal P1 As clsVec2, ByVal RecoRaggio As Double)
        Dim Punto1(2) As Double
        Dim Punto1a(2) As Double
        Dim Punto2(2) As Double
        Dim Puntob1(2) As Double
        Dim Puntob2(2) As Double
        Dim insPnt(2) As Double
        Dim Temp As Double
        Dim angolo As Double
        Dim angolob As Double
        Dim Ent As AutoCAD.AcadEntity
        Dim Beta As Double
        Dim Raggio As Double

        'If numero = 225 Then Stop

        'punto di partenza
        Punto1(0) = P0.X
        Punto1(1) = P0.y
        Punto1(2) = 0
        'Punto Finale
        Punto2(0) = P1.X
        Punto2(1) = P1.y
        Punto2(2) = 0
        Punto1(0) = P0.X
        Punto2(0) = P1.X
        Punto1(0) = P0.X
        Punto2(0) = P1.X
        angolo = cls_Utility.AngleFromXAxis(Punto1, Punto2)
        angolo = (angolo / (Math.PI / 180))

        Punto1(0) = P1.X

        Punto1(1) = P1.y
        Punto1(2) = 0
        'Punto Finale
        Punto2(0) = P0.X
        Punto2(1) = P0.y

        Punto2(2) = 0
        angolob = cls_Utility.AngleFromXAxis(Punto1, Punto2)
        angolob = (angolob / (Math.PI / 180))
        angolo = angolo - angolob
        ' solo per controllare se i raggi sono uguali
        Raggio = System.Math.Sqrt((P1.X - P0.X) ^ 2 + (P1.y - P0.y) ^ 2)
        Raggio = Raggio / 2
        If System.Math.Abs(Raggio - RecoRaggio) >= 1.5 Then
            Stop 'Print #NumFile, numero & "   -   " & Raggio & "   -   " & RecoRb2.Raggio & "   -   " & Raggio - RecoRb2.Raggio
        Else
            'Print #NumFile, numero & "   -   " & Raggio & "   -   " & RecoRb2.Raggio
        End If
        'inverte i valori y e z
        Temp = Punto1(2)
        Punto1(2) = Punto1(1)
        Punto1(1) = Temp
        Temp = Punto2(2)
        Punto2(2) = Punto2(1)
        Punto2(1) = Temp
        'Set Ent = Cad.cls_Doc_Obj.ModelSpace.InsertBlock(Punto1, nome, 1#, 1#, 0)
        Punto1a(0) = P0.X
        Punto1a(2) = P0.y
        Punto1a(1) = 0
        Ent = CType(cls_Doc_Obj.ModelSpace.InsertBlock(Punto1a, Nome, 1.0#, 1.0#, 1.0#, 0), AutoCAD.AcadEntity)
        Punto1a(0) = Punto2(0)
        Punto1a(1) = Punto2(1) - 10
        Punto1a(2) = Punto2(2)
        If P1.X <> P0.X Then
            Beta = System.Math.Atan((P1.y - P0.y) / (P1.X - P0.X))
        Else
            If P1.y < P0.y Then
                Beta = -90 * (Math.PI / 180)
            Else
                Beta = 90 * (Math.PI / 180)
            End If
        End If
        angolo = Beta / (Math.PI / 180)
        If P1.X < P0.X Then
            Beta = Beta - Math.PI
        End If
        Ent.Rotate3D(Punto2, Punto1a, Beta)
        cls_Doc_Obj.Application.Update()
    End Sub
    Public Sub GeneraTubo(ByRef posizione As String, ByRef SubPos As String, ByRef Lunghezza As Single, ByRef Raggio As Single, ByVal dtubo As Single)
        Dim Percorso As AutoCAD.AcadPolyline
        Dim Punto(2) As Double
        Dim ObjBlocco As AutoCAD.AcadBlock ' Object
        'Per la rotazioone sull'asse
        Dim Punto1(2) As Double
        Dim Punto2(2) As Double
        Dim lstvrt(11) As Double
        Dim ObjList(0) As AutoCAD.AcadEntity
        Dim Rgn() As Object 'AutoCAD.AcadRegion
        Dim RgnObj As Object
        Try
            ObjList(0) = CType(Me.Cerchio(0, 0, CSng(dtubo / 2), "0"), AutoCAD.AcadEntity)
            Punto1(0) = -10
            Punto1(1) = 0
            Punto1(2) = 0
            Punto2(0) = 10
            Punto2(1) = 0
            Punto2(2) = 0
            ObjList(0).Rotate3D(Punto1, Punto2, -Math.PI / 2)
            RgnObj = cls_Doc_Obj.ModelSpace.AddRegion(ObjList)
            Rgn = CType(RgnObj, System.Object())
            lstvrt(0) = 0 'lstvrt 0,0,0
            lstvrt(1) = 0 'lstvrt 0,0,0
            lstvrt(2) = 0 'lstvrt 0,0,0
            lstvrt(3) = 0 'lstvrt 0,0,lunghezza
            lstvrt(4) = Lunghezza 'lstvrt 0,0,lunghezza
            lstvrt(5) = 0 'lstvrt 0,0,lunghezza
            lstvrt(6) = Raggio * 2 'lstvrt 0, - raggio * 2,lunghezza
            lstvrt(7) = Lunghezza 'lstvrt 0,- raggio * 2,lunghezza
            lstvrt(8) = 0 'lstvrt 0,- raggio * 2,lunghezza
            lstvrt(9) = Raggio * 2 'lstvrt finale
            lstvrt(10) = 0 'lstvrt finale
            lstvrt(11) = 0 'lstvrt finale

            'ListaVertici = GlobalRoutines.CopyArray(lstvrt)
            Percorso = cls_Doc_Obj.ModelSpace.AddPolyline(CType(lstvrt, Object)) ' ListaVertici)
            Percorso.SetBulge(1, -1)
            Punto1(0) = 0
            Punto1(1) = 0
            Punto1(2) = 0
            Punto2(0) = 0
            Punto2(1) = 0
            Punto2(2) = 0

            ObjBlocco = cls_Doc_Obj.Blocks.Add(Punto1, posizione.Trim)
            ObjBlocco.AddExtrudedSolidAlongPath(CType(Rgn(0), AutoCAD.AcadRegion), Percorso)
            'Elimina gli oggetti temporanei
            ObjList(0).Erase()
            Percorso.Erase()
            CType(Rgn(0), AutoCAD.AcadRegion).Erase()
        Catch e As Exception
            MsgBox(e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub
    Public Function GetGruppo(ByRef Nome As String) As AutoCAD.AcadGroup
        GetGruppo = cls_Doc_Obj.Groups.Item(Nome)
    End Function
    'FIXIT: Dichiarare "GetObjectByHandle" con un tipo di dati ad associazione anticipata      FixIT90210ae-R1672-R1B8ZE
    Public Function GetObjectByHandle(ByRef Handle As String) As Object
        'Restituisce un oggetto in base all'handle
        Dim X As Object = Nothing
        For Each X In cls_Doc_Obj.ModelSpace
            If X.Handle = Trim(Handle) Then
                Exit For
            End If
        Next X
        GetObjectByHandle = X
    End Function
    Public Sub PreparaXData(ByRef Conto As Short, ByRef Data_Type As Short, ByRef Xdata As String)
        DataType(Conto) = Data_Type
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Data(Conto). Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
        Data(Conto) = Xdata
    End Sub
    'FIXIT: Dichiarare "GetXdata' and 'Oggetto" con un tipo di dati ad associazione anticipata     FixIT90210ae-R1672-R1B8ZE
    Public Function GetXdata(ByRef Applicazione As String, ByRef Oggetto As Object) As Object
        Dim XData1 As Object = Nothing
        Dim XData2 As Object = Nothing
        If (cls_App_Obj Is Nothing) Or (cls_Doc_Obj Is Nothing) Or (Oggetto Is Nothing) Then
            RaiseEvent Errore(Errori.AutoCAD_Metodo_non_Disponibile, "Metodo non Disponibile")
            Return Nothing
        End If
        Err.Clear()
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Oggetto.GetXdata. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
        Oggetto.GetXdata(Applicazione, XData1, XData2)
        If Err.Number Then
            RaiseEvent Errore(Errori.AutoCAD_Errore_interno, "Impossibile ottenere XData")
            Return Nothing
        End If
        GetXdata = XData2
    End Function
    'FIXIT: Dichiarare "Oggetto" con un tipo di dati ad associazione anticipata                FixIT90210ae-R1672-R1B8ZE
    Public Sub SetXdata(ByRef Oggetto As Object)
        If (cls_App_Obj Is Nothing) Or (cls_Doc_Obj Is Nothing) Or (Oggetto Is Nothing) Then
            RaiseEvent Errore(Errori.AutoCAD_Metodo_non_Disponibile, "Metodo non Disponibile")
            Exit Sub
        End If
        Err.Clear()
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Oggetto.SetXdata. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
        Oggetto.SetXdata(DataType, Data)
        If Err.Number Then
            RaiseEvent Errore(Errori.AutoCAD_Errore_interno, "Impossibile assegnare XData")
            Exit Sub
        End If
    End Sub
    Public Sub SalvaGruppo()
        'FIXIT: Dichiarare "Temp" con un tipo di dati ad associazione anticipata                   FixIT90210ae-R1672-R1B8ZE
        Dim Temp As Object
        If (cls_App_Obj Is Nothing) Or (cls_Doc_Obj Is Nothing) Or (cls_Gruppo Is Nothing) Then
            RaiseEvent Errore(Errori.AutoCAD_Metodo_non_Disponibile, "Metodo non Disponibile")
            Exit Sub
        End If
        Err.Clear()
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Temp. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
        Temp = VB6.CopyArray(ObjGruppo)
        cls_Gruppo.AppendItems(Temp)
        ContoObj = 0
        ReDim ObjGruppo(0)
        'UPGRADE_NOTE: È possibile che l'oggetto cls_Gruppo non venga eliminato finché non venga raccolto nel Garbage Collector. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1029"'
        cls_Gruppo = Nothing
        If Err.Number Then
            RaiseEvent Errore(Errori.AutoCAD_Impossibile_Aggiungere_al_Gruppo, "Problemi nell'aggiunta dell'oggetto al gruppo")
            Exit Sub
        End If
    End Sub
    'FIXIT: Dichiarare "cosa" con un tipo di dati ad associazione anticipata                   FixIT90210ae-R1672-R1B8ZE
    Public Sub AggiungiAlgruppo(ByRef cosa As Object)
        If (cls_App_Obj Is Nothing) Or (cls_Doc_Obj Is Nothing) Or (cls_Gruppo Is Nothing) Or (cosa Is Nothing) Then
            RaiseEvent Errore(Errori.AutoCAD_Metodo_non_Disponibile, "Metodo non Disponibile")
            Exit Sub
        End If
        Err.Clear()
        ReDim Preserve ObjGruppo(ContoObj)
        ObjGruppo(ContoObj) = cosa
        ContoObj = ContoObj + 1
        If Err.Number Then
            RaiseEvent Errore(Errori.AutoCAD_Impossibile_Aggiungere_al_Gruppo, "Problemi nell'aggiunta dell'oggetto al gruppo")
            Exit Sub
        End If
    End Sub
    Public Sub Crea_gruppo(ByRef Nome As String)
        If (cls_App_Obj Is Nothing) Or (cls_Doc_Obj Is Nothing) Then
            RaiseEvent Errore(Errori.AutoCAD_Metodo_non_Disponibile, "Metodo non Disponibile")
            Exit Sub
        End If
        Err.Clear()
        cls_Gruppo = cls_Doc_Obj.Groups.Add(Nome)
        If Err.Number Then
            RaiseEvent Errore(Errori.AutoCAD_Impossibile_Creare_Gruppo, "Errori nella creazione del gruppo")
            'UPGRADE_NOTE: È possibile che l'oggetto cls_Gruppo non venga eliminato finché non venga raccolto nel Garbage Collector. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1029"'
            cls_Gruppo = Nothing
            Exit Sub
        End If
    End Sub
    Public Function Ruota(ByRef obj As AutoCAD.AcadEntity, ByRef x1 As Double, ByRef y1 As Double, ByRef angolo As Double) As AutoCAD.AcadEntity
        If (cls_App_Obj Is Nothing) Or (obj Is Nothing) Or (cls_Doc_Obj Is Nothing) Then
            RaiseEvent Errore(Errori.AutoCAD_Metodo_non_Disponibile, "Metodo non Disponibile")
            'UPGRADE_NOTE: È possibile che l'oggetto Ruota non venga eliminato finché non venga raccolto nel Garbage Collector. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1029"'
            Ruota = Nothing
            Exit Function
        End If
        'Controlla il tipo di oggetto
        Select Case obj.EntityType
            Case Is = AutoCAD.AcEntityName.acArc
            Case Is = AutoCAD.AcEntityName.acCircle
            Case Is = AutoCAD.AcEntityName.acDimAligned
            Case Is = AutoCAD.AcEntityName.acDimAngular
            Case Is = AutoCAD.AcEntityName.acDimDiametric
            Case Is = AutoCAD.AcEntityName.acDimOrdinate
            Case Is = AutoCAD.AcEntityName.acDimRadial
            Case Is = AutoCAD.AcEntityName.acDimRotated
            Case Is = AutoCAD.AcEntityName.acEllipse
            Case Is = AutoCAD.AcEntityName.acHatch
            Case Is = AutoCAD.AcEntityName.acLeader
            Case Is = AutoCAD.AcEntityName.acLine
            Case Is = AutoCAD.AcEntityName.acMtext
            Case Is = AutoCAD.AcEntityName.acPoint
            Case Is = AutoCAD.AcEntityName.acPolyline
            Case Is = AutoCAD.AcEntityName.acRegion
            Case Is = AutoCAD.AcEntityName.acText
            Case Is = AutoCAD.AcEntityName.acTolerance
            Case Else
                RaiseEvent Errore(Errori.AutoCAD_Errore_interno, "Oggetto non valido")
                'UPGRADE_NOTE: È possibile che l'oggetto Ruota non venga eliminato finché non venga raccolto nel Garbage Collector. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1029"'
                Ruota = Nothing
                Exit Function
        End Select
        Punto1(0) = x1
        Punto1(1) = y1
        Punto1(2) = 0
        Err.Clear()
        obj.Rotate(Punto1, angolo * PiGreco_Rad)
        If Err.Number Then
            RaiseEvent Errore(Errori.AutoCAD_Impossibile_Ruotare, "Impossibile Ruotare l'oggetto")
            Ruota = obj
            Exit Function
        End If
        Ruota = obj
    End Function
    Public Function Carica_Linee() As Boolean
        Dim Percorso As String
        Dim f As Integer
        Dim Temp As String
        Dim Nome As String
        If (cls_App_Obj Is Nothing) Then
            RaiseEvent Errore(Errori.AutoCAD_Metodo_non_Disponibile, "Metodo non Disponibile")
            Exit Function
        End If
        Percorso = cls_App_Obj.Path & "\support\acadiso.lin"
        'UPGRADE_WARNING: Dir ha un nuovo comportamento. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1041"'
        If Dir(Percorso) = vbNullString Then
            RaiseEvent Errore(Errori.AutoCAD_Impossibile_Trovare_File, "File AcadIso.lin non trovato")
            Carica_Linee = False
            Exit Function
        End If
        f = FreeFile()
        FileOpen(f, Percorso, OpenMode.Input)
        Do
            Temp = LineInput(f)
            'Salvate nella collection come Nome_AutoCAD, Nome_Interno
            If Left(Temp, 1) = "*" Then
                Nome = Mid(Temp, 2, InStr(1, Temp, ",") - 2)
                'FIXIT: Sostituire la funzione "UCase" con la funzione "UCase$"                            FixIT90210ae-R9757-R1B8ZE
                Nome = UCase(Nome)
                If Nome = "BORDER" Then
                    Nomi_Linee.Add("BORDER", "BORDO")
                End If
                If Nome = "BORDO" Then
                    Nomi_Linee.Add("BORDO", "BORDO")
                End If

                If Nome = "CENTER" Then
                    Nomi_Linee.Add("CENTER", "CENTRO")
                End If
                If Nome = "CENTRO" Then
                    Nomi_Linee.Add("CENTRO", "CENTRO")
                End If

                If Nome = "DASHDOT" Then
                    Nomi_Linee.Add("DASHDOT", "TRATTOPUNTO")
                End If
                If Nome = "TRATTOPUNTO" Then
                    Nomi_Linee.Add("TRATTOPUNTO", "TRATTOPUNTO")
                End If

                If Nome = "DASHED" Then
                    Nomi_Linee.Add("DASHED", "TRATTEGGIATA")
                End If
                If Nome = "TRATTEGGIATA" Then
                    Nomi_Linee.Add("TRATTEGGIATA", "TRATTEGGIATA")
                End If

                If Nome = "DIVIDE" Then
                    Nomi_Linee.Add("DIVIDE", "DIVIDI")
                End If
                If Nome = "DIVIDI" Then
                    Nomi_Linee.Add("DIVIDI", "DIVIDI")
                End If

                If Nome = "DOT" Then
                    Nomi_Linee.Add("DOT", "PUNTO")
                End If
                If Nome = "PUNTO" Then
                    Nomi_Linee.Add("PUNTO", "PUNTO")
                End If

                If Nome = "HIDDEN" Then
                    Nomi_Linee.Add("HIDDEN", "NASCOSTA")
                End If
                If Nome = "NASCOSTA" Then
                    Nomi_Linee.Add("NASCOSTA", "NASCOSTA")
                End If

                If Nome = "PHANTOM" Then
                    Nomi_Linee.Add("PHANTOM", "FANTASMA")
                End If
                If Nome = "FANTASMA" Then
                    Nomi_Linee.Add("FANTASMA", "FANTASMA")
                End If
            End If
        Loop Until EOF(f)
        Nomi_Linee.Add("CONTINUOUS", "CONTINUOUS")
        FileClose(f)
    End Function
    'FIXIT: Dichiarare "obj" con un tipo di dati ad associazione anticipata                    FixIT90210ae-R1672-R1B8ZE
    Public Function Setta_Tipo_Linea(ByRef obj As Object, ByRef Nome_Linea As Tipi_Linee, ByRef Colore As Colori) As Boolean
        On Error Resume Next
        Dim Nome As String = ""
        If (cls_App_Obj Is Nothing) Or (obj Is Nothing) Then
            RaiseEvent Errore(Errori.AutoCAD_Metodo_non_Disponibile, "Metodo non Disponibile")
            Setta_Tipo_Linea = False
            Exit Function
        End If
        Select Case Nome_Linea
            Case Is = Tipi_Linee.Bordo
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Nomi_Linee(). Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                Nome = Nomi_Linee.Item("BORDO")
            Case Is = Tipi_Linee.Centro
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Nomi_Linee(). Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                Nome = Nomi_Linee.Item("CENTRO")
            Case Is = Tipi_Linee.Dividi
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Nomi_Linee(). Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                Nome = Nomi_Linee.Item("DIVIDI")
            Case Is = Tipi_Linee.Fantasma
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Nomi_Linee(). Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                Nome = Nomi_Linee.Item("FANTASMA")
            Case Is = Tipi_Linee.Nascosta
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Nomi_Linee(). Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                Nome = Nomi_Linee.Item("NASCOSTA")
            Case Is = Tipi_Linee.Punto
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Nomi_Linee(). Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                Nome = Nomi_Linee.Item("PUNTO")
            Case Is = Tipi_Linee.Tratteggiata
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Nomi_Linee(). Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                Nome = Nomi_Linee.Item("TRATTEGGIATA")
            Case Is = Tipi_Linee.TrattoPunto
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Nomi_Linee(). Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                Nome = Nomi_Linee.Item("TRATTOPUNTO")
            Case Is = Tipi_Linee.Continua
                'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Nomi_Linee(). Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                Nome = Nomi_Linee.Item("CONTINUOUS")
        End Select
        'Controlla il tipo di oggetto
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto obj.EntityType. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
        Select Case obj.EntityType
            Case Is = AutoCAD.AcEntityName.acArc
            Case Is = AutoCAD.AcEntityName.acCircle
            Case Is = AutoCAD.AcEntityName.acDimAligned
            Case Is = AutoCAD.AcEntityName.acDimAngular
            Case Is = AutoCAD.AcEntityName.acDimDiametric
            Case Is = AutoCAD.AcEntityName.acDimOrdinate
            Case Is = AutoCAD.AcEntityName.acDimRadial
            Case Is = AutoCAD.AcEntityName.acDimRotated
            Case Is = AutoCAD.AcEntityName.acEllipse
            Case Is = AutoCAD.AcEntityName.acHatch
            Case Is = AutoCAD.AcEntityName.acLeader
            Case Is = AutoCAD.AcEntityName.acLine
            Case Is = AutoCAD.AcEntityName.acMtext
            Case Is = AutoCAD.AcEntityName.acPoint
            Case Is = AutoCAD.AcEntityName.acPolyline
            Case Is = AutoCAD.AcEntityName.acRegion
            Case Is = AutoCAD.AcEntityName.acText
            Case Is = AutoCAD.AcEntityName.acTolerance
            Case Else
                RaiseEvent Errore(Errori.AutoCAD_Errore_interno, "Oggetto non valido")
                Setta_Tipo_Linea = False
                Exit Function
        End Select
        Err.Clear()
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto obj.Linetype. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
        obj.Linetype = Nome
        If Err.Number Then
            RaiseEvent Errore(Errori.AutoCAD_Errore_interno, "Impossibile assegnare il tipo di linea")
            Setta_Tipo_Linea = False
            Exit Function
        End If
        Err.Clear()
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto obj.Color. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
        obj.Color = Colore
        If Err.Number Then
            RaiseEvent Errore(Errori.AutoCAD_Errore_interno, "Impossibile assegnare il colore")
            Setta_Tipo_Linea = False
            Exit Function
        End If
        Setta_Tipo_Linea = True
    End Function
    Public Property Caption() As String
        Get
            'Utilizzato per recuperare il valore di una proprietà, a destra dell'assegnazione.
            'Syntax: Debug.Print X.Caption
            On Error Resume Next
            Err.Clear()
            Caption = cls_App_Obj.Caption
            If Err.Number Then Caption = "errore"

        End Get
        Set(ByVal Value As String)
            'Utilizzato per l'assegnazione di un valore alla proprietà, a sinistra di un'assegnazione.
            'Syntax: X.Caption = 5
            mvarCaption = Value
        End Set
    End Property
    Public ReadOnly Property Versione() As String
        Get
            'Utilizzato per recuperare il valore di una proprietà, a destra dell'assegnazione.
            'Syntax: Debug.Print X.Versione
            Versione = mvarVersione
        End Get
    End Property


    Public Property Visibile() As Boolean
        Get
            'Utilizzato per recuperare il valore di una proprietà, a destra dell'assegnazione.
            'Syntax: Debug.Print X.Visibile
            Visibile = mvarVisibile
        End Get
        Set(ByVal Value As Boolean)
            'Utilizzato per l'assegnazione di un valore alla proprietà, a sinistra di un'assegnazione.
            'Syntax: X.Visibile = 5
            On Error Resume Next
            mvarVisibile = Value
            cls_App_Obj.Visible = Value
        End Set
    End Property





    Public Property Altezza() As Integer
        Get
            'Utilizzato per recuperare il valore di una proprietà, a destra dell'assegnazione.
            'Syntax: Debug.Print X.Altezza
            Altezza = mvarAltezza
        End Get
        Set(ByVal Value As Integer)
            'Utilizzato per l'assegnazione di un valore alla proprietà, a sinistra di un'assegnazione.
            'Syntax: X.Altezza = 5
            mvarAltezza = Value
            cls_App_Obj.Height = Value
        End Set
    End Property





    Public Property Lunghezza() As Integer
        Get
            'Utilizzato per recuperare il valore di una proprietà, a destra dell'assegnazione.
            'Syntax: Debug.Print X.Lunghezza
            Lunghezza = mvarLunghezza
        End Get
        Set(ByVal Value As Integer)
            'Utilizzato per l'assegnazione di un valore alla proprietà, a sinistra di un'assegnazione.
            'Syntax: X.Lunghezza = 5
            mvarLunghezza = Value
            cls_App_Obj.Width = Value
        End Set
    End Property
    'FIXIT: Dichiarare "Quota1" con un tipo di dati ad associazione anticipata                 FixIT90210ae-R1672-R1B8ZE
    Public Function Quota1(ByRef x1 As Double, ByRef y1 As Double, ByRef x2 As Double, ByRef y2 As Double, ByRef Distanza As Double, ByRef Layer As String) As Object
        Dim puntoM(2) As Double
        Dim Beta As Double
        Dim a1 As Double
        Dim B1 As Double
        On Error Resume Next
        If (cls_App_Obj Is Nothing) Or (cls_Doc_Obj Is Nothing) Then
            RaiseEvent Errore(Errori.AutoCAD_Metodo_non_Disponibile, "Metodo non Disponibile")
            Return Nothing
        End If
        cls_Entita = Nothing
        Punto1(0) = x1
        Punto1(1) = y1
        Punto1(2) = 0
        Punto2(0) = x2
        Punto2(1) = y2
        Punto2(2) = 0
        'Calcolo del punto medio della linea
        puntoM(0) = ((Punto2(0) - Punto1(0)) / 2) + Punto1(0)
        puntoM(1) = ((Punto2(1) - Punto1(1)) / 2) + Punto1(1)
        puntoM(2) = 0
        'Calcolo del beta
        Beta = System.Math.Atan((Punto2(0) - Punto1(0)) / ((Punto2(1) - Punto1(1))))
        'Calcolo Delta della posizione finale della linea
        a1 = Distanza * System.Math.Cos(System.Math.Abs(Beta))
        B1 = Distanza * System.Math.Sin(System.Math.Abs(Beta))
        'Controlla l'orientamento
        If Beta > 0 Then
            Punto3(0) = puntoM(0) - a1
            Punto3(1) = puntoM(1) + B1
        ElseIf Beta < 0 Then
            Punto3(0) = puntoM(0) + a1
            Punto3(1) = puntoM(1) + B1
        End If
        'Crea l'entità
        Err.Clear()
        cls_Entita = cls_Doc_Obj.ModelSpace.AddDimAligned(Punto1, Punto2, Punto3)
        If Err.Number Then
            RaiseEvent Errore(Errori.AutoCAD_Impossibile_Quotare, "Impossibile Quotare l'oggetto")
            Quota1 = cls_Entita
            Exit Function
        End If
        Err.Clear()
        cls_Entita.Layer = Layer
        If Err.Number Then
            RaiseEvent Errore(Errori.AutoCAD_Impossibile_Assegnare_Layer, "Impossibile Assegnare il layer all'oggetto Testo")
            Quota1 = cls_Entita
            Exit Function
        End If
        Quota1 = cls_Entita
    End Function
    Public Sub Zoom_Oggetto(ByRef Oggetto As Object)
        Dim Pt1 As Object = Nothing
        Dim Pt2 As Object = Nothing
        If (cls_App_Obj Is Nothing) Or (cls_Doc_Obj Is Nothing) Then
            RaiseEvent Errore(Errori.AutoCAD_Metodo_non_Disponibile, "Metodo non Disponibile")
            Exit Sub
        End If
        If Oggetto Is Nothing Then
            RaiseEvent Errore(Errori.AutoCAD_Oggetto_Non_valido, "oggetto da spostare non valido")
            Exit Sub
        End If
        Err.Clear()
        Oggetto.GetBoundingBox(Pt1, Pt2)
        Zoom_Finestra(CDbl(Pt1(0)), CDbl(Pt1(1)), CDbl(Pt2(0)), CDbl(Pt2(1)))
    End Sub
    'FIXIT: Dichiarare "Oggetto" con un tipo di dati ad associazione anticipata                FixIT90210ae-R1672-R1B8ZE
    Public Function Cancella(ByRef Oggetto As Object) As Boolean
        If (cls_App_Obj Is Nothing) Or (cls_Doc_Obj Is Nothing) Then
            RaiseEvent Errore(Errori.AutoCAD_Metodo_non_Disponibile, "Metodo non Disponibile")
            Cancella = False
            Exit Function
        End If
        If Oggetto Is Nothing Then
            RaiseEvent Errore(Errori.AutoCAD_Oggetto_Non_valido, "oggetto da spostare non valido")
            Cancella = False
            Exit Function
        End If
        Err.Clear()
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Oggetto.Erase. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
        Oggetto.Erase()
        If Err.Number Then
            RaiseEvent Errore(Errori.AutoCAD_Impossibile_Cancellare, "Impossibile Cancellare l'oggetto")
            Cancella = False
            Exit Function
        End If
        Cancella = True
    End Function
    'FIXIT: Dichiarare "Specchia' and 'Oggetto" con un tipo di dati ad associazione anticipata     FixIT90210ae-R1672-R1B8ZE
    Public Function Specchia(ByRef Oggetto As Object, ByRef x1 As Double, ByRef y1 As Double, ByRef x2 As Double, ByRef y2 As Double) As Object
        If (cls_App_Obj Is Nothing) Or (cls_Doc_Obj Is Nothing) Then
            RaiseEvent Errore(Errori.AutoCAD_Metodo_non_Disponibile, "Metodo non Disponibile")
            Return Nothing
        End If
        If Oggetto Is Nothing Then
            RaiseEvent Errore(Errori.AutoCAD_Oggetto_Non_valido, "oggetto da spostare non valido")
            Return Nothing
        End If
        Punto1(0) = x1
        Punto1(1) = y1
        Punto1(2) = 0
        Punto2(0) = x2
        Punto2(1) = y2
        Punto2(2) = 0
        Err.Clear()
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Oggetto.Mirror. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
        cls_Entita = Oggetto.Mirror(Punto1, Punto2)
        If Err.Number Then
            RaiseEvent Errore(Errori.AutoCAD_Impossibile_Specchiare, "Impossibile Specchiare l'Oggetto")
            Return Nothing
        End If
        Specchia = cls_Entita
    End Function
    'FIXIT: Dichiarare "Muovi' and 'Oggetto" con un tipo di dati ad associazione anticipata     FixIT90210ae-R1672-R1B8ZE
    Public Function Muovi(ByRef Oggetto As Object, ByRef Delta_X As Double, ByRef Delta_Y As Double) As Object
        If (cls_App_Obj Is Nothing) Or (cls_Doc_Obj Is Nothing) Then
            RaiseEvent Errore(Errori.AutoCAD_Metodo_non_Disponibile, "Metodo non Disponibile")
            Return Nothing
        End If
        If Oggetto Is Nothing Then
            RaiseEvent Errore(Errori.AutoCAD_Oggetto_Non_valido, "oggetto da spostare non valido")
            Return Nothing
        End If
        Punto1(0) = 0
        Punto1(1) = 0
        Punto1(2) = 0
        Punto2(0) = Delta_X
        Punto2(1) = Delta_Y
        Punto1(2) = 0
        Err.Clear()
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Oggetto.Move. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
        Oggetto.Move(Punto1, Punto2)
        If Err.Number Then
            RaiseEvent Errore(Errori.AutoCAD_Impossibile_Spostare, "Impossibile spostare l'oggetto")
            Return Nothing
        End If
        Muovi = Oggetto
    End Function
    'FIXIT: Dichiarare "Get_Punto" con un tipo di dati ad associazione anticipata              FixIT90210ae-R1672-R1B8ZE
    Public Function Get_Punto() As Object
        On Error Resume Next
        If (cls_App_Obj Is Nothing) Or (cls_Doc_Obj Is Nothing) Then
            RaiseEvent Errore(Errori.AutoCAD_Metodo_non_Disponibile, "Metodo non Disponibile")
            Return Nothing
        End If
        'Crea l'oggetto
        Err.Clear()
        AppActivate(cls_App_Obj.Caption)
        If Err.Number Then
            RaiseEvent Errore(Errori.AutoCAD_Impossibile_Creare_Oggetto_Utility, "Impossibile Inizializzare l'oggetto Utility")
            Return Nothing
        End If
        Get_Punto = cls_Utility.GetPoint
    End Function
    'FIXIT: Dichiarare "Oggetto" con un tipo di dati ad associazione anticipata                FixIT90210ae-R1672-R1B8ZE
    Public Function Quota(ByRef Oggetto As Object, ByRef Distanza_testo As Double, Optional ByRef Testo_Forzato As String = "") As Boolean
        Dim puntoM(2) As Double
        Dim Beta As Double
        Dim a1 As Double
        Dim B1 As Double
        On Error Resume Next
        If (cls_App_Obj Is Nothing) Or (cls_Doc_Obj Is Nothing) Then
            RaiseEvent Errore(Errori.AutoCAD_Metodo_non_Disponibile, "Metodo non Disponibile")
            Exit Function
        End If
        'UPGRADE_NOTE: È possibile che l'oggetto cls_Entita non venga eliminato finché non venga raccolto nel Garbage Collector. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1029"'
        cls_Entita = Nothing
        'Controlla l'oggetto passato alla funzione
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Oggetto.EntityType. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
        If Oggetto.EntityType = AutoCAD.AcEntityName.acLine Then
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Oggetto.startPoint. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            Punto1(0) = Oggetto.startPoint(0)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Oggetto.startPoint. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            Punto1(1) = Oggetto.startPoint(1)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Oggetto.startPoint. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            Punto1(2) = Oggetto.startPoint(2)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Oggetto.endPoint. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            Punto2(0) = Oggetto.endPoint(0)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Oggetto.endPoint. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            Punto2(1) = Oggetto.endPoint(1)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Oggetto.endPoint. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            Punto2(2) = Oggetto.endPoint(2)
            'Calcolo del punto medio della linea
            puntoM(0) = ((Punto2(0) - Punto1(0)) / 2) + Punto1(0)
            puntoM(1) = ((Punto2(1) - Punto1(1)) / 2) + Punto1(1)
            puntoM(2) = 0
            'Calcolo del beta
            Beta = System.Math.Atan((Punto2(0) - Punto1(0)) / ((Punto2(1) - Punto1(1))))
            'Calcolo Delta della posizione finale della linea
            a1 = Distanza_testo * System.Math.Cos(System.Math.Abs(Beta))
            B1 = Distanza_testo * System.Math.Sin(System.Math.Abs(Beta))
            'Controlla l'orientamento
            If Beta > 0 Then
                Punto3(0) = puntoM(0) - a1
                Punto3(1) = puntoM(1) + B1
            ElseIf Beta < 0 Then
                Punto3(0) = puntoM(0) + a1
                Punto3(1) = puntoM(1) + B1
            End If
            'Crea l'entità
            Err.Clear()
            cls_Entita = cls_Doc_Obj.ModelSpace.AddDimAligned(Punto1, Punto2, Punto3)
            If Err.Number Then
                RaiseEvent Errore(Errori.AutoCAD_Impossibile_Quotare, "Impossibile Quotare l'oggetto")
                Exit Function
            End If
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Oggetto.EntityType. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
        ElseIf Oggetto.EntityType = AutoCAD.AcEntityName.acArc Or Oggetto.EntityType = AutoCAD.AcEntityName.acCircle Then
            'Centro dell'arco (o del cerchio)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Oggetto.Center. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            Punto1(0) = Oggetto.Center(0)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Oggetto.Center. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            Punto1(1) = Oggetto.Center(1)
            Punto1(2) = 0
            'Calcolo del punto d'inserimento della Quota
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Oggetto.Radius. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            Punto2(0) = Oggetto.Radius * System.Math.Cos(45 * PiGreco_Rad)
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Oggetto.Radius. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            Punto2(1) = Oggetto.Radius * System.Math.Sin(45 * PiGreco_Rad)
            Punto2(2) = 0
            'Crea l'entità
            Err.Clear()
            cls_Entita = cls_Doc_Obj.ModelSpace.AddDimRadial(Punto1, Punto2, Distanza_testo)
            If Err.Number Then
                RaiseEvent Errore(Errori.AutoCAD_Impossibile_Quotare, "Impossibile Quotare l'oggetto")
                Exit Function
            End If
        Else
            RaiseEvent Errore(Errori.AutoCAD_Oggetto_Non_valido, "Impossibile Quotare : Oggetto non valido")
            Quota = False
            Exit Function
        End If
        Quota = True
    End Function
    'FIXIT: Dichiarare "Testo" con un tipo di dati ad associazione anticipata                  FixIT90210ae-R1672-R1B8ZE
    Public Function Testo(ByRef Stringa As String, ByRef x_ins As Double, ByRef y_ins As Double, ByRef Altezza As Double, ByRef Layer As String) As Object
        On Error Resume Next
        If (cls_App_Obj Is Nothing) Or (cls_Doc_Obj Is Nothing) Then
            RaiseEvent Errore(Errori.AutoCAD_Metodo_non_Disponibile, "Metodo non Disponibile")
            Return ""
        End If
        'UPGRADE_NOTE: È possibile che l'oggetto cls_Entita non venga eliminato finché non venga raccolto nel Garbage Collector. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1029"'
        cls_Entita = Nothing
        Punto1(0) = x_ins
        Punto1(1) = y_ins
        Punto1(2) = 0
        Err.Clear()
        cls_Entita = cls_Doc_Obj.ModelSpace.AddText(Stringa, Punto1, Altezza)
        If Err.Number Then
            RaiseEvent Errore(Errori.AutoCAD_Impossibile_Creare_Cerchio, "Impossibile Creare il Cerchio")
            Return ""
        End If
        Err.Clear()
        cls_Entita.Layer = Layer
        If Err.Number Then
            RaiseEvent Errore(Errori.AutoCAD_Impossibile_Assegnare_Layer, "Impossibile Assegnare il layer all'oggetto Testo")
            Testo = cls_Entita
            Return ""
        End If
        Testo = cls_Entita
    End Function

    'FIXIT: Dichiarare "Cerchio" con un tipo di dati ad associazione anticipata                FixIT90210ae-R1672-R1B8ZE
    Public Function Cerchio(ByRef X As Double, ByRef y As Double, ByRef Raggio As Double, ByRef Layer As String) As Object
        On Error Resume Next
        If (cls_App_Obj Is Nothing) Or (cls_Doc_Obj Is Nothing) Then
            RaiseEvent Errore(Errori.AutoCAD_Metodo_non_Disponibile, "Metodo non Disponibile")
            Return Nothing
        End If
        'UPGRADE_NOTE: È possibile che l'oggetto cls_Entita non venga eliminato finché non venga raccolto nel Garbage Collector. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1029"'
        cls_Entita = Nothing
        Punto1(0) = X
        Punto1(1) = y
        Punto1(2) = 0
        Err.Clear()
        cls_Entita = cls_Doc_Obj.ModelSpace.AddCircle(Punto1, Raggio)
        If Err.Number Then
            RaiseEvent Errore(Errori.AutoCAD_Impossibile_Creare_Cerchio, "Impossibile Creare il Cerchio")
            Return Nothing
        End If
        Err.Clear()
        cls_Entita.Layer = Layer
        If Err.Number Then
            RaiseEvent Errore(Errori.AutoCAD_Impossibile_Assegnare_Layer, "Impossibile Assegnare il layer all'Arco")
            Cerchio = cls_Entita
            Return Nothing
        End If
        Cerchio = cls_Entita
    End Function
    'FIXIT: Dichiarare "Linea" con un tipo di dati ad associazione anticipata                  FixIT90210ae-R1672-R1B8ZE
    Public Function Linea(ByRef x1 As Double, ByRef y1 As Double, ByRef x2 As Double, ByRef y2 As Double, ByRef Layer As String) As Object
        On Error Resume Next
        If (cls_App_Obj Is Nothing) Or (cls_Doc_Obj Is Nothing) Then
            RaiseEvent Errore(Errori.AutoCAD_Metodo_non_Disponibile, "Metodo non Disponibile")
            Return Nothing
        End If
        'UPGRADE_NOTE: È possibile che l'oggetto cls_Entita non venga eliminato finché non venga raccolto nel Garbage Collector. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1029"'
        cls_Entita = Nothing
        Punto1(0) = x1
        Punto1(1) = y1
        Punto1(2) = 0
        Punto2(0) = x2
        Punto2(1) = y2
        Punto2(2) = 0
        Err.Clear()
        cls_Entita = cls_Doc_Obj.ModelSpace.AddLine(Punto1, Punto2)
        If Err.Number Then
            RaiseEvent Errore(Errori.AutoCAD_Impossibile_Creare_Linea, "Impossibile Creare la Linea")
            Return Nothing
        End If
        Err.Clear()
        cls_Entita.Layer = Layer
        If Err.Number Then
            RaiseEvent Errore(Errori.AutoCAD_Impossibile_Assegnare_Layer, "Impossibile Assegnare il layer all'oggetto Linea")
            Linea = cls_Entita
            Exit Function
        End If
        Linea = cls_Entita
    End Function
    'FIXIT: Dichiarare "arco" con un tipo di dati ad associazione anticipata                   FixIT90210ae-R1672-R1B8ZE
    Public Function arco(ByRef X As Double, ByRef y As Double, ByRef Raggio As Double, ByRef Start_Angolo As Double, ByRef End_Angolo As Double, ByRef Layer As String) As Object
        On Error Resume Next
        If (cls_App_Obj Is Nothing) Or (cls_Doc_Obj Is Nothing) Then
            RaiseEvent Errore(Errori.AutoCAD_Metodo_non_Disponibile, "Metodo non Disponibile")
            Return Nothing
        End If
        'UPGRADE_NOTE: È possibile che l'oggetto cls_Entita non venga eliminato finché non venga raccolto nel Garbage Collector. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1029"'
        cls_Entita = Nothing
        Punto1(0) = X
        Punto1(1) = y
        Punto1(2) = 0
        Err.Clear()
        cls_Entita = cls_Doc_Obj.ModelSpace.AddArc(Punto1, Raggio, Start_Angolo * PiGreco_Rad, End_Angolo * PiGreco_Rad)
        If Err.Number Then
            RaiseEvent Errore(Errori.AutoCAD_Impossibile_Creare_Arco, "Impossibile Creare l'arco")
            Return Nothing
        End If
        Err.Clear()
        cls_Entita.Layer = Layer
        If Err.Number Then
            RaiseEvent Errore(Errori.AutoCAD_Impossibile_Assegnare_Layer, "Impossibile Assegnare il layer all'Arco")
            arco = cls_Entita
            Return Nothing
        End If
        arco = cls_Entita
    End Function
    Public Sub Zoom_Finestra(ByRef x1 As Double, ByRef y1 As Double, ByRef x2 As Double, ByRef y2 As Double)
        On Error Resume Next
        If (cls_App_Obj Is Nothing) Or (cls_Doc_Obj Is Nothing) Or (cls_ViewPort Is Nothing) Then
            RaiseEvent Errore(Errori.AutoCAD_Metodo_non_Disponibile, "Metodo non Disponibile")
            Exit Sub
        End If
        Err.Clear()
        Punto1(0) = x1
        Punto1(1) = y1
        Punto1(2) = 0
        Punto2(0) = x2
        Punto2(1) = y2
        Punto2(2) = 0
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto cls_ViewPort.ZoomWindow. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
        cls_ViewPort.ZoomWindow(Punto1, Punto2)
        If Err.Number Then
            RaiseEvent Errore(Errori.AutoCAD_Impossibile_Zoom, "Impossibile completare l'operazione : Zoom Finestra")
        End If
    End Sub
    Public Sub Zoom_Estensione()
        On Error Resume Next
        If (cls_App_Obj Is Nothing) Or (cls_Doc_Obj Is Nothing) Or (cls_ViewPort Is Nothing) Then
            RaiseEvent Errore(Errori.AutoCAD_Metodo_non_Disponibile, "Metodo non Disponibile")
            Exit Sub
        End If
        Err.Clear()
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto cls_ViewPort.ZoomExtents. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
        cls_ViewPort.ZoomExtents()
        If Err.Number Then
            RaiseEvent Errore(Errori.AutoCAD_Impossibile_Zoom, "Impossibile completare l'operazione : Zoom Estensione")
        End If
    End Sub

    Public Sub ZoomAll()
        On Error Resume Next
        If (cls_App_Obj Is Nothing) Or (cls_Doc_Obj Is Nothing) Or (cls_ViewPort Is Nothing) Then
            RaiseEvent Errore(Errori.AutoCAD_Metodo_non_Disponibile, "Metodo non Disponibile")
            Exit Sub
        End If
        Err.Clear()
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto cls_ViewPort.ZoomAll. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
        cls_ViewPort.ZoomAll()
        If Err.Number Then
            RaiseEvent Errore(Errori.AutoCAD_Impossibile_Zoom, "Impossibile completare l'operazione : Zoom All")
        End If
    End Sub

    Public Sub Rigenera()
        On Error Resume Next
        If (cls_App_Obj Is Nothing) Or (cls_Doc_Obj Is Nothing) Then
            RaiseEvent Errore(Errori.AutoCAD_Metodo_non_Disponibile, "Metodo non Disponibile")
            Exit Sub
        End If
        Err.Clear()
        cls_Doc_Obj.Regen(AutoCAD.AcRegenType.acAllViewports)
        If Err.Number Then
            RaiseEvent Errore(Errori.AutoCAD_Impossibile_Rigenerare, "Impossibile Rigenerare il disegno")
        End If
    End Sub
    'FIXIT: Dichiarare "Crea_Layer" con un tipo di dati ad associazione anticipata             FixIT90210ae-R1672-R1B8ZE
    Public Function Crea_Layer(ByRef Nome As String, ByRef Colore As Integer) As Object
        On Error Resume Next
        If (cls_App_Obj Is Nothing) Or (cls_Doc_Obj Is Nothing) Then
            RaiseEvent Errore(Errori.AutoCAD_Metodo_non_Disponibile, "Metodo non Disponibile")
            Return Nothing
        End If
        Err.Clear()
        cls_Layer = cls_Doc_Obj.Layers.Add(Nome)
        If Err.Number Then
            RaiseEvent Errore(Errori.AutoCAD_Impossibile_Creare_il_Layer, "Problemi nella creazione del Layer")
            Return Nothing
        End If
        cls_Layer.Color = Colore
        cls_Layer.Linetype = "Continuous"
        Return cls_Layer
    End Function
    Public Function Nuovo_Disegno(ByRef template As String) As Object
        On Error Resume Next
        If cls_App_Obj Is Nothing Then
            RaiseEvent Errore(Errori.AutoCAD_Metodo_non_Disponibile, "Metodo non Disponibile")
            Return Nothing
        End If
        Err.Clear()
        cls_Doc_Obj = cls_App_Obj.ActiveDocument.New(template)
        If Err.Number Then
            RaiseEvent Errore(Errori.AutoCAD_Impossibile_Creare_Nuovo_File, "Impossibile Creare un nuovo file")
            Return Nothing
        End If
        Nuovo_Disegno = cls_Doc_Obj
        cls_ViewPort = cls_Doc_Obj.ActiveViewport
    End Function
    Public Function Apri_Disegno(ByRef Nome_File As String) As Object
        'Apre un disegno nella sessione corrente di AutoCad
        On Error Resume Next
        If cls_App_Obj Is Nothing Then
            RaiseEvent Errore(Errori.AutoCAD_Metodo_non_Disponibile, "Metodo non Disponibile")
            Return Nothing
        End If
        'Controlla l'esistenza del file da Aprire
        'UPGRADE_WARNING: Dir ha un nuovo comportamento. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1041"'
        If Dir(Nome_File) = vbNullString Then
            RaiseEvent Errore(Errori.AutoCAD_File_Non_Trovato, "File Specificato non trovato")
        End If
        Err.Clear()
        cls_Doc_Obj = cls_App_Obj.ActiveDocument.Open(Nome_File)
        If Err.Number Then
            RaiseEvent Errore(Errori.AutoCAD_Errore_interno, Err.Description)
            Return Nothing
        End If
        Apri_Disegno = cls_Doc_Obj
        cls_ViewPort = cls_Doc_Obj.ActiveViewport
    End Function

    'FIXIT: Dichiarare "Chiudi_AutoCAD" con un tipo di dati ad associazione anticipata         FixIT90210ae-R1672-R1B8ZE
    Public Function Chiudi_AutoCAD() As Object
        On Error Resume Next
        'Chiude la seesione di autocad aperta dalla classe
        Err.Clear()
        cls_App_Obj.Quit()
        If Err.Number Then
            RaiseEvent Errore(Errori.AutoCAD_Impossibile_Chiudere, "Impossibile Chiudere AutoCAD")
        End If
        cls_App_Obj = Nothing
        cls_Doc_Obj = Nothing
        cls_Layer = Nothing
        cls_ViewPort = Nothing
        cls_Utility = Nothing
        cls_Entita = Nothing
        Return Nothing
    End Function
    Public Sub New()
        MyBase.New()
        Dim Real(2) As Double
        ContoObj = 0
        'Azzera i valori
        Data(0) = ""
        Data(1) = ""
        Data(2) = "0"
        Data(3) = 0.0#
        Data(4) = 0
        Data(5) = 0
        Data(6) = 0
        Data(7) = 0

        Real(0) = 0
        Real(1) = 0
        Real(2) = 0
        Data(8) = VB6.CopyArray(Real)
        Data(9) = VB6.CopyArray(Real)

        DataType(0) = 1001
        DataType(1) = 1000
        DataType(2) = 1003
        DataType(3) = 1040
        DataType(4) = 1041
        DataType(5) = 1070
        DataType(6) = 1071
        DataType(7) = 1042
        DataType(8) = 1010
        DataType(9) = 1011
        If gInizio.LanciaAutoCAD(cls_Doc_Obj) = 0 Then
            cls_App_Obj = cls_Doc_Obj.Application
            cls_ViewPort = cls_Doc_Obj.ActiveViewport
            mvarVersione = cls_App_Obj.Version
            Carica_Linee()
            cls_Utility = cls_Doc_Obj.Utility
        Else
            cls_Doc_Obj = Nothing
        End If
    End Sub
    Protected Overrides Sub Finalize()
        'Distrugge tutte le variabili allocate
        cls_App_Obj = Nothing
        cls_Doc_Obj = Nothing
        cls_Layer = Nothing
        cls_ViewPort = Nothing
        cls_Utility = Nothing
        cls_Entita = Nothing
        MyBase.Finalize()
    End Sub
    'FIXIT: Dichiarare "copia' and 'Oggetto" con un tipo di dati ad associazione anticipata     FixIT90210ae-R1672-R1B8ZE
    Public Function copia(ByRef Oggetto As Object, ByRef x1 As Double, ByRef y1 As Double, ByRef x2 As Double, ByRef y2 As Double) As Object
        If (cls_App_Obj Is Nothing) Or (cls_Doc_Obj Is Nothing) Then
            RaiseEvent Errore(Errori.AutoCAD_Metodo_non_Disponibile, "Metodo non Disponibile")
            Return Nothing
        End If
        If Oggetto Is Nothing Then
            RaiseEvent Errore(Errori.AutoCAD_Oggetto_Non_valido, "oggetto da copiare non valido")
            Return Nothing
        End If
        Punto1(0) = x1
        Punto1(1) = y1
        Punto1(2) = 0
        Punto2(0) = x2 - x1
        Punto2(1) = y2 - y1
        Punto1(2) = 0
        Err.Clear()
        'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Oggetto.Copy. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
        cls_Entita = Oggetto.Copy()
        If Err.Number Then
            RaiseEvent Errore(Errori.AutoCAD_Impossibile_Copiare, "Impossibile copiare l'oggetto")
            Return Nothing
        End If
        cls_Entita = Muovi(cls_Entita, Punto2(0), Punto2(1))
        copia = Oggetto
    End Function
    'FIXIT: Dichiarare "GetGruppoDalPunto' and 'Punto" con un tipo di dati ad associazione anticipata     FixIT90210ae-R1672-R1B8ZE
    Public Function GetGruppoDalPunto(ByRef Punto As Object) As Object
        'FIXIT: Dichiarare "sset" con un tipo di dati ad associazione anticipata                   FixIT90210ae-R1672-R1B8ZE
        Dim sset As Object
        Dim Punto1(2) As Double
        'FIXIT: Dichiarare "Ent" con un tipo di dati ad associazione anticipata                    FixIT90210ae-R1672-R1B8ZE
        Dim Ent As Object
        'FIXIT: Dichiarare "Ent1" con un tipo di dati ad associazione anticipata                   FixIT90210ae-R1672-R1B8ZE
        Dim Ent1 As Object = Nothing
        'FIXIT: Dichiarare "obj" con un tipo di dati ad associazione anticipata                    FixIT90210ae-R1672-R1B8ZE
        Dim obj As Object
        'FIXIT: Dichiarare "XD" con un tipo di dati ad associazione anticipata                     FixIT90210ae-R1672-R1B8ZE
        Dim XD As Object
        'FIXIT: Dichiarare "V1" con un tipo di dati ad associazione anticipata                     FixIT90210ae-R1672-R1B8ZE
        Dim V1 As Object
        'FIXIT: Dichiarare "V2" con un tipo di dati ad associazione anticipata                     FixIT90210ae-R1672-R1B8ZE
        Dim V2 As Object
        'AppActivate Me.Caption
        Punto1(0) = Punto(0) + 2
        Punto1(1) = Punto(1) + 2
        Punto1(2) = 0
        V1 = VB6.CopyArray(Punto1)
        Punto1(0) = Punto(0) - 2
        Punto1(1) = Punto(1) - 2
        Punto1(2) = 0
        V2 = VB6.CopyArray(Punto1)

        sset = cls_Doc_Obj.SelectionSets.Add("zxisd")
        sset.Clear()
        sset.Select(AutoCAD.AcSelect.acSelectionSetCrossing, V1, V2)

        'Cicla in tutti i gruppi del disegno, ottiene XDATA
        'e quindi controlla se l'handle dell'entità cliccata è contenuta
        'nell'xdata
        'Cicla attraverso tutti gli oggetti selezionati (che fanno parte del gruppo, però non ho nessun
        'riferimento al nome del gruppo,quindi :
        '1.  Ciclo tra tutti gli oggetti in cerca di uno che appartenga al Layer "Pallini" o "testo_Pallini"
        '2. Salvo l'handle
        '3. Ciclo tra tutti i gruppi del disegno ,recupero i loro XDATA e controllo se l'handle dell'oggetto trovato al punto 2
        '    è nell'xdata.
        '4. A quel punto so a quale gruppo è riferito il mio pallino e riesco anche a sapere gli altri Handle del
        '    pallino.

        For Each Ent In sset
            'FIXIT: Sostituire la funzione "UCase" con la funzione "UCase$"                            FixIT90210ae-R9757-R1B8ZE
            'FIXIT: Sostituire la funzione "UCase" con la funzione "UCase$"                            FixIT90210ae-R9757-R1B8ZE
            'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Ent.Layer. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            If UCase(Ent.Layer) = "PALLINI" Or UCase(Ent.Layer) = "TESTOPALLINI" Then
                Ent1 = Ent
                Exit For
            End If
        Next Ent
        If Ent1 = VariantType.Empty Then Return Nothing
        For Each Ent In cls_Doc_Obj.Groups
            obj = Ent
            XD = GetXdata("Disegni", obj)
            V1 = Split(XD(1), Chr(135))
            If InStr(XD(1), Ent1.Handle) Then
                GetGruppoDalPunto = obj
                Return Nothing
            End If
        Next Ent
        GetGruppoDalPunto = Nothing
    End Function
End Class