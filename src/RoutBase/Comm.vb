Option Strict On
Option Explicit On
Imports System.IO
Imports System.Runtime.Serialization
Imports System.Runtime.Serialization.Formatters.Binary
<Serializable()> Public Class clsComm
    Public Padre As clsjob
    Public Oggetto As String
    Public Arch As String 'sottocommessa
    Public job As String
    Public Prev As String 'commessa
    Public Item As String 'titolo
    Public Impianto As String
    Public Clie As String
    Public Comp As String 'compilatore                         88
    Public NBank As Short
    Public Ind As LinkedListV 'indice in APR del record corrente   22
    Public IndG As Short
    Public NumAs As Short 'numero assieme attuale
    Public Asse As String 'H o V                               '  1
    Public Baric As clsVec3 ' 12
    Public peso As Single
    Public CalcBaric As Short '  6
    Public LungM As Short 'Lunghezza max formati lamiera
    Public LargM As Short 'Larghezza max formati lamiera          '  4
    Public indice As Short
    Public NumeroLati As Short
    Public Sub New()
        MyBase.New()
        Dim V As ValoriComm
        Ind = New LinkedListV
        V = New ValoriComm
        Ind.Add(V)
        job = "____"
        Prev = "______"
        Item = "__________"
        Impianto = Item
        Clie = Item
        Comp = "XX"
    End Sub
    Public Sub SalvaCom(Optional ByRef Nome As String = "")
        Dim n As String
        Dim FileTem As String
        Try
            If Nome.Length = 0 Then n = Arch Else n = Nome
            FileTem = Padre.Motore.Inizio.Workdir & "\" & n & ".TEM"
            Dim myFileStream As Stream = File.OpenWrite(FileTem)
            Dim deserializer As New Lancio.Legacy.Serialization.LegacyBinarySerializer
            Try
                deserializer.Serialize(myFileStream, Me)
            Catch e As SerializationException
                MsgBox("Failed to serialize" & FileTem & ControlChars.CrLf & "Reason:" & e.Message)
            Finally
                myFileStream.Close()
            End Try
        Catch e1 As Exception
            MsgBox(e1.Message + vbCrLf + e1.StackTrace)
        End Try
    End Sub
    Public Sub CheckPath()
        Dim Path As String
        Path = Trim(Padre.Motore.Inizio.Workdir) & "\" & Trim(Arch)
        Try
            ChDir(Path)
        Catch
            MkDir(Path)
        End Try
        ChDir(Padre.Motore.Inizio.Basedir)
    End Sub
End Class