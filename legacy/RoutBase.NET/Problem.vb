Option Strict On
Option Explicit On
Imports System.io
<Serializable()> Public Class clsProblem
    Public Problema As String
    Public Author As String
    Public Info As String
    Public ClientPlant As String
    Public Item As String
    Public Doc As String
    Public StampaTutto As Short
    Public Intest As Short
    Public Extension As String
    Public Commessa As String
    <NonSerialized()> Public FileStream As StreamWriter
    Public TipoFile As String
    Public nonSciolto As Boolean
    Public pag As Integer
    Public OrdineFile As Integer
    Private Const Par As String = "\par "
    Public Sub Printa(ByRef Riga As String)
        FileStream.WriteLine(Riga)
    End Sub
    Public Sub Print(ByRef Riga As String)
        FileStream.Write(Riga)
    End Sub
    Public Sub copia(ByRef File As String)
        Dim ifl As Short
        Dim Riga As String
        ifl = CShort(FreeFile())
        FileOpen(ifl, File, OpenMode.Input)
        Do
            Riga = LineInput(ifl)
            If Riga = "Fine" Then Exit Do
            FileStream.Write(Riga)
        Loop Until EOF(ifl)
        FileClose(ifl)
    End Sub
    Public Sub FineRapp()
        FileStream.WriteLine("}")
        ChiudiRapp()
    End Sub
    Public Sub ChiudiRapp()
        If FileStream Is Nothing Then Exit Sub
        FileStream.Close()
        FileStream = Nothing
    End Sub
    Public Sub New()
        Problema = ""
        Author = ""
        Info = ""
        ClientPlant = ""
        Item = ""
        Doc = ""
        Extension = ""
        Commessa = ""
        TipoFile = ""
    End Sub
End Class