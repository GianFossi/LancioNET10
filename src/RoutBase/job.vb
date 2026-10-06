Option Strict On
Option Explicit On 
Imports System.io
Imports System.Runtime.Serialization
Imports System.Runtime.Serialization.Formatters.Binary
Imports RoutBase1
<Serializable()> Public Class clsjob
    <NonSerialized()> Public Motore As clsMotore
    Public Coll As LinkedList
    Public Comm As clsComm
    Public Contratto As String
    Public Sub New(ByVal m As clsMotore)
        MyBase.New()
        Coll = New LinkedList(1)
        Comm = New clsComm
        Comm.Padre = Me
        Motore = m
    End Sub
    Protected Overrides Sub Finalize()
        Comm = Nothing
        Coll = Nothing
        MyBase.Finalize()
    End Sub
    Public ReadOnly Property Njobs() As Integer
        Get
            Njobs = Coll.Count()
        End Get
    End Property
    Public ReadOnly Property Arch(ByVal i As Short) As String
        Get
            Arch = Coll.Item(i).TextData
        End Get
    End Property
    Public Sub Aggiungi(ByRef Commessa As String)
        Coll.Add(Commessa)
    End Sub
    Public Sub Rimuovi(ByRef Commessa As String)
        Dim i As Integer
        For i = 1 To Coll.Count()
            If Coll.Item(i).TextData = Commessa Then Coll.remove(i)
        Next
    End Sub
    Public Sub Salva()
        Try
            Dim Nome As String = Motore.Inizio.Workdir & "\" & Contratto & ".JOB"
            Dim myFileStream As Stream = File.OpenWrite(Nome)
            Dim serializer As New BinaryFormatter
            Try
                serializer.Serialize(myFileStream, Me)
            Catch e As SerializationException
                MsgBox("Failed to serialize" & Nome & ControlChars.CrLf & "Reason:" & e.Message)
            Finally
                myFileStream.Close()
            End Try
        Catch e1 As Exception
            MsgBox(e1.Message + vbCrLf + e1.StackTrace)
        End Try
    End Sub
    Public Function Selezione(Optional ByRef Comm As String = "", Optional ByRef Item As String = "", Optional ByRef Visual As Boolean = True) As Boolean
        Dim Dialogo As New frmCommessa
        With Dialogo
            .job = Me
            .propComm = Comm
            .propItem = Item
            .Visual = Visual
            .Inizializza()
            .ShowDialog()
            Selezione = Not .Cancel
        End With
    End Function
    Public Sub RetrieveCom(ByRef i As Short)
        Comm = Motore.RetrieveComS(Coll.Item(i).TextData)
        Comm.Padre = Me
    End Sub
    Public Sub AggiungiCom(ByRef Nome As String)
        Coll.Add(Nome)
        Comm.Arch = Trim(Nome)
        Comm.SalvaCom()
        Comm.CheckPath()
    End Sub
End Class