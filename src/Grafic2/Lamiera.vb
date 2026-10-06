Option Strict Off
Option Explicit On
Imports RoutBase1
Friend Class Lamiera
    'Private Declare Sub CopyMemory Lib "kernel32" Alias "RtlMoveMemory" (destinazione As Any, sorgente As Any, ByVal Lungh As Long)
    Public Vertici As RoutBase1.clsPunti
    Public Centri As RoutBase1.clsPunti
    Public Raggi As OggList
    Public Spessore As Single
    Public Alt As Single
    Public Alung As Single
    Public Materiale As String
    Public PesoSpec As Single
    Public Piano As Short
    Public Xpos As Single
    Public Ypos As Single
    Public Zpos As Single
    Public DistPiano As Single
    Public LatoDelPiano As Integer
    'Public GenMem   As clsGenMem
    'Public Rifer    As Integer '1 terza perpendicolare
    Public Name As String
    '0 diritta perpendicolare
    'UPGRADE_NOTE: Class_Initialize è stato aggiornato a Class_Initialize_Renamed. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1061"'
    Private Sub Class_Initialize_Renamed()
        'Set GenMem = new clsGenmem
        'Set GenMem.Parent = Me
        'TipoMat = 1
        'GenMem.Tipo = 96
        Vertici = New RoutBase1.clsPunti
        Centri = New RoutBase1.clsPunti
        Raggi = New OggList(0)
    End Sub
    Public Sub New()
        MyBase.New()
        Class_Initialize_Renamed()
    End Sub


    Public Property Npunti() As Short
        Get
            Npunti = Vertici.Punti.Count
        End Get
        Set(ByVal Value As Short)
            Dim i As Short
            Vertici.Inizia(Value)
            Centri.Inizia(Value)
            For i = 1 To Value
                Raggi.Add(0)
            Next
        End Set
    End Property
    Public Sub RimuoviPunti() 'era private
        Dim i As Short
        For i = 1 To Raggi.Count()
            Raggi.Remove(1)
        Next
        'UPGRADE_NOTE: È possibile che l'oggetto Vertici.Punti non venga eliminato finché non venga raccolto nel Garbage Collector. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1029"'
        Vertici.Punti = Nothing
        'UPGRADE_NOTE: È possibile che l'oggetto Centri.Punti non venga eliminato finché non venga raccolto nel Garbage Collector. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1029"'
        Centri.Punti = Nothing
    End Sub
    'UPGRADE_NOTE: Class_Terminate è stato aggiornato a Class_Terminate_Renamed. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1061"'
    Private Sub Class_Terminate_Renamed()
        'UPGRADE_NOTE: È possibile che l'oggetto Vertici non venga eliminato finché non venga raccolto nel Garbage Collector. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1029"'
        Vertici = Nothing
        'UPGRADE_NOTE: È possibile che l'oggetto Centri non venga eliminato finché non venga raccolto nel Garbage Collector. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1029"'
        Centri = Nothing
        'UPGRADE_NOTE: È possibile che l'oggetto Raggi non venga eliminato finché non venga raccolto nel Garbage Collector. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1029"'
        Raggi = Nothing
        'Set Me = Nothing

    End Sub
    Protected Overrides Sub Finalize()
        Class_Terminate_Renamed()
        MyBase.Finalize()
    End Sub
    Public Sub Converti(ByRef jRec As Short)
        'Dim R As RecAPRm, i As Integer
        'GenMem.ConvertiPos jRec
        'CopyMemory R, RecordD(jRec), LenB(R)
        'Npunti = R.Npunti
        'For i = 1 To R.Npunti
        '   Vertici.Punti(i).X = R.Vertici(i).X
        '   Vertici.Punti(i).Y = R.Vertici(i).Y
        '   Centri.Punti(i).X = R.Centri(i).X
        '   Centri.Punti(i).Y = R.Centri(i).Y
        '   SubStit Raggi, R.Raggi(i), i
        'Next
        'Spessore = R.Dati(1)
    End Sub
    Public Sub sConverti(ByRef j As Short)
        'Dim R As RecAPRm, i As Integer
        'GenMem.sConverti j
        'CopyMemory R, RecordD(j), LenB(R)
        'R.Npunti = Npunti
        '       For i = 1 To R.Npunti
        '          R.Vertici(i).X = Vertici.Punti(i).X
        '          R.Vertici(i).Y = Vertici.Punti(i).Y
        '          R.Centri(i).X = Centri.Punti(i).X
        '          R.Centri(i).Y = Centri.Punti(i).Y
        '          R.Raggi(i) = Raggi(i)
        '       Next
        'R.Dati(1) = Spessore
        'CopyMemory RecordD(j), R, LenB(R)

    End Sub
End Class