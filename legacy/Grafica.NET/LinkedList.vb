Option Strict On
Option Explicit On 
Imports System.Text
<Serializable()> Public Class LinkedList
    Friend nodeHead As NodeP
    Friend nodeActual As NodeP
    Public Sub New()
        nodeHead = New NodeP
    End Sub 'New
    Public Overrides Function ToString() As String
        ' Represent the LinkedList as a string
        Dim list As New StringBuilder("List:" & ControlChars.CrLf)
        Dim index As Integer = 0
        Dim iterator As NodeP = nodeHead.Next
        While Not (iterator Is Nothing)
            list.Append(("Node #" & index.ToString() & ControlChars.CrLf & iterator.ToString() & ControlChars.CrLf))
            index = index + 1
            iterator = iterator.Next
        End While
        Return list.ToString()
    End Function
    Public Sub Add(ByVal point As Object, Optional ByRef key As String = "", Optional ByVal Before As String = "", Optional ByVal After As String = "")
        Dim node As New NodeP
        Dim nBefore, nAfter As NodeP
        Dim duplicato As Object = Item(key)
        key = key.Trim
        If Not duplicato Is Nothing Then
            If key.Length < 4 Then key = key & New String(CChar("A"), 4 - key.Length)
            If IsNumeric(key.Substring(key.Length - 3)) Then key = key.Substring(0, key.Length - 3)
            Dim i As Integer = 1
            Do
                key = key & String.Format("000", i)
                i += 1
            Loop Until IsNothing(Item(key))
        End If
        If key = "" Then key = "A" & String.Format("000", Count() + 1)
        If Before.Length > 0 Then
            nBefore = Item(Before)
        ElseIf After.Length > 0 Then
            nAfter = Item(After)
        End If
        node.key = key
        node.TextData = point
        node.Add(nodeHead, nBefore, nAfter)
        nodeActual = node
    End Sub
    Public Function Count() As Integer
        Dim index As Integer = 0
        Dim iterator As NodeP = nodeHead.Next
        While Not (iterator Is Nothing)
            index = index + 1
            iterator = iterator.Next
        End While
        Return index
    End Function
    Public Overloads ReadOnly Property Item(ByVal i As Integer) As NodeP
        Get
            Dim iterator As NodeP = nodeHead.Next
            Dim index As Integer = 0
            While Not (iterator Is Nothing) And i <> index
                index = index + 1
                iterator = iterator.Next
            End While
            Return iterator
        End Get
    End Property
    Public Overloads ReadOnly Property Item(ByVal k As String) As NodeP
        Get
            Dim iterator As NodeP = nodeHead.Next
            While Not (iterator Is Nothing)
                If iterator.key.Equals(k) Then Exit While
                iterator = iterator.Next
            End While
            Return iterator
        End Get
    End Property
    Default Public Overloads ReadOnly Property ItemAt(ByVal i As Integer) As Object
        Get
            Dim n As NodeP = Item(i)
            If IsNothing(n) Then Return Nothing
            Return n.TextData
        End Get
    End Property
    Default Public Overloads ReadOnly Property ItemAt(ByVal k As String) As Object
        Get
            Dim n As NodeP = Item(k)
            If IsNothing(n) Then Return Nothing
            Return n.TextData
        End Get
    End Property
    Public Sub remove(ByVal i As Integer)
        If i = 1 Then
            If Not nodeHead.Next Is Nothing Then
                nodeHead = nodeHead.Next
            End If
        Else
            Item(i - 1).Next = Item(i + 1)
        End If
    End Sub
    <Serializable()> Public Class NodeP
        ' Private field referencing the next node in the list
        Private nextField As NodeP
        ' Private fields containing node data
        Private prevField As NodeP
        Private DataField As Object
        Friend key As String
        Public Sub New()
            ' Construct a Node object
            nextField = Nothing
        End Sub 'New
        Public Sub Add(ByVal nodeHead As NodeP, ByVal nBefore As NodeP, ByVal nAfter As NodeP)
            ' Add a node object to a list
            If Not nBefore Is Nothing Then
                Dim n As NodeP = nBefore.prevField
                n.nextField = Me
                nBefore.prevField = Me
                Me.nextField = nBefore
                Me.prevField = n
            ElseIf Not nAfter Is Nothing Then
                Dim n As NodeP = nAfter.nextField
                nAfter.nextField = Me
                n.prevField = Me
                Me.nextField = n
                Me.prevField = nAfter
            Else
                Dim iterator As NodeP = nodeHead
                While Not (iterator.nextField Is Nothing)
                    iterator = iterator.Next
                End While
                iterator.nextField = Me
                Me.prevField = iterator
                nextField = Nothing
            End If
        End Sub 'Add
        Public Property TextData() As Object
            Get
                Return DataField
            End Get
            Set(ByVal Value As Object)
                DataField = Value
            End Set
        End Property
        Public Property [Next]() As NodeP
            Get
                Return nextField
            End Get
            Set(ByVal Value As NodeP)
                nextField = Value
            End Set
        End Property
        Public Property Previous() As NodeP
            Get
                Return prevField
            End Get
            Set(ByVal Value As NodeP)
                prevField = Value
            End Set
        End Property

        Public Overrides Function ToString() As String
            ' Represent the node as a string
            Return ControlChars.Tab & "TextData   " & ChrW(61) & " """ & TextData.ToString
        End Function 'ToString
    End Class 'Node
End Class
