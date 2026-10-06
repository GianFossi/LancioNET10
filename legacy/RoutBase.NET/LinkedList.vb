Imports System.Text
' Note that this type is attributed as serializable
<Serializable()> Public Class LinkedList
    ' Reference to the empty head node
    Friend nodeHead As Node
    Friend nodeActual As Node
    <NonSerialized()> Public BaseZero As Short = 1
    ' Construct an empty LinkedList
    Public Sub New(ByVal zero As Short)
        nodeHead = New Node
        BaseZero = zero
    End Sub 'New
    ' Represent the LinkedList as a string
    Public Overrides Function ToString() As String
        Dim list As New StringBuilder("List:" & ControlChars.CrLf)
        Dim index As Integer = 0
        Dim iterator As Node = nodeHead.Next
        While Not (iterator Is Nothing)
            list.Append(("Node #" & index.ToString() & ControlChars.CrLf & iterator.ToString() & ControlChars.CrLf))
            index = index + 1
            iterator = iterator.Next
        End While
        Return list.ToString()
    End Function 'ToString
    ' Add a node
    Public Sub Add(ByVal [text] As [String])
        Dim node As New Node
        node.TextData = [text]
        node.Add(nodeHead)
        nodeActual = node
    End Sub 'Add
    Public Sub AddSingolo(ByVal [text] As [String])
        If Not Exists([text]) Then
            Dim node As New Node
            node.TextData = [text]
            node.Add(nodeHead)
            nodeActual = node
        End If
    End Sub 'Add
    Public Function Count() As Integer
        Dim index As Integer = 0
        Dim iterator As Node = nodeHead.Next
        While Not (iterator Is Nothing)
            index = index + 1
            iterator = iterator.Next
        End While
        Return index
    End Function
    Default Public ReadOnly Property Elem(ByVal i) As String
        Get
            Return Item(i).TextData
        End Get
    End Property
    Public Function Item(ByVal i As Integer) As Node
        Dim iterator As Node = nodeHead.Next
        Dim index As Integer = BaseZero
        While Not (iterator Is Nothing) And i <> index
            index = index + 1
            iterator = iterator.Next
        End While
        Return iterator
    End Function
    Public Function Exists(ByVal s As String) As Boolean
        Dim iterator As Node = nodeHead.Next
        Dim index As Integer = BaseZero
        While True
            If iterator Is Nothing Then Exit While
            If s.Equals(iterator.TextData) Then Exit While
            index = index + 1
            iterator = iterator.Next
        End While
        Return Not iterator Is Nothing
    End Function
    Public Sub remove(ByVal i As Integer)
        If i = BaseZero Then
            If Not nodeHead.Next Is Nothing Then
                nodeHead = nodeHead.Next
            End If
        ElseIf i < BaseZero Then
            Throw New Exception("Tentativo di rimuovere l'elemento 0 di una lista a base 1")
        Else
            Item(i - 1).Next = Item(i + 1)
        End If
    End Sub
    ' This nested type is also attributed as serializable
    <Serializable()> Public Class Node
        ' Private field referencing the next node in the list
        Private nextField As Node
        ' Private fields containing node data
        Private textDataField As String
        ' Construct a Node object
        Public Sub New()
            nextField = Nothing
        End Sub 'New
        ' Add a node object to a list
        Public Sub Add(ByVal nodeHead As Node)
            Dim iterator As Node = nodeHead
            While Not (iterator.nextField Is Nothing)
                iterator = iterator.Next
            End While
            iterator.nextField = Me
            nextField = Nothing
        End Sub 'Add
        ' Accessor property for textData private field
        Public Property TextData() As String
            Get
                Return textDataField
            End Get
            Set(ByVal Value As String)
                textDataField = Value
            End Set
        End Property
        ' Read-only property for next private field
        Public Property [Next]() As Node
            Get
                Return nextField
            End Get
            Set(ByVal Value As Node)
                nextField = Value
            End Set
        End Property
        ' Represent the node as a string
        Public Overrides Function ToString() As String
            Return ControlChars.Tab & "TextData   " & ChrW(61) & " """ & TextData
        End Function 'ToString
    End Class 'Node
End Class 'LinkedListPublic Class LinkedList
<Serializable()> Public Class LinkedListV
    ' Reference to the empty head node
    Friend nodeHeadV As NodeV
    Friend nodeActualV As NodeV
    ' Construct an empty LinkedList
    Public Sub New()
        nodeHeadV = New NodeV
    End Sub 'New
    ' Represent the LinkedList as a string
    Public Overrides Function ToString() As String
        Dim list As New StringBuilder("List:" & ControlChars.CrLf)
        Dim index As Integer = 0
        Dim iterator As NodeV = nodeHeadV.Next
        While Not (iterator Is Nothing)
            list.Append(("Node #" & index.ToString() & ControlChars.CrLf & iterator.ToString() & ControlChars.CrLf))
            index = index + 1
            iterator = iterator.Next
        End While
        Return list.ToString()
    End Function 'ToString
    ' Add a node
    Public Sub Add(ByVal V As ValoriComm)
        Dim node As New NodeV
        node.Data = V
        node.Add(nodeHeadV)
        nodeActualV = node
    End Sub 'Add
    Public Function Count() As Integer
        Dim index As Integer = 0
        Dim iterator As NodeV = nodeHeadV.Next
        While Not (iterator Is Nothing)
            index = index + 1
            iterator = iterator.Next
        End While
        Return index
    End Function
    Default Public ReadOnly Property Item(ByVal i As Integer) As NodeV
        Get
            Dim iterator As NodeV = nodeHeadV.Next
            Dim index As Integer = 1
            While Not (iterator Is Nothing) And i <> index
                index = index + 1
                iterator = iterator.Next
            End While
            Return iterator
        End Get
    End Property
    Public Sub remove(ByVal i As Integer)
        If i = 1 Then
            If Not nodeHeadV.Next Is Nothing Then
                nodeHeadV = nodeHeadV.Next
            End If
        Else
            Item(i - 1).Next = Item(i + 1)
        End If
    End Sub
    ' This nested type is also attributed as serializable
    <Serializable()> Public Class NodeV
        ' Private field referencing the next node in the list
        Private nextField As NodeV
        ' Private fields containing node data
        Private DataField As ValoriComm
        ' Construct a Node object
        Public Sub New()
            nextField = Nothing
        End Sub 'New
        ' Add a node object to a list
        Public Sub Add(ByVal nodeHead As NodeV)
            Dim iterator As NodeV = nodeHead
            While Not (iterator.nextField Is Nothing)
                iterator = iterator.Next
            End While
            iterator.nextField = Me
            nextField = Nothing
        End Sub 'Add
        ' Accessor property for textData private field
        Public Property Data() As ValoriComm
            Get
                Return DataField
            End Get
            Set(ByVal Value As ValoriComm)
                DataField = Value
            End Set
        End Property
        ' Read-only property for next private field
        Public Property [Next]() As NodeV
            Get
                Return nextField
            End Get
            Set(ByVal Value As NodeV)
                nextField = Value
            End Set
        End Property
        ' Represent the node as a string
        Public Overrides Function ToString() As String
            Return ControlChars.Tab & "Data   " & ChrW(61) & " """ & Data.Assieme
        End Function 'ToString
    End Class 'Node
End Class 'LinkedListPublic Class LinkedList
<Serializable()> Public Class LinkedListP3
    ' Reference to the empty head node
    Friend nodeHead As NodeP
    Friend nodeActual As NodeP
    ' Construct an empty LinkedList
    Public Sub New()
        nodeHead = New NodeP
    End Sub 'New
    ' Represent the LinkedList as a string
    Public Overrides Function ToString() As String
        Dim list As New StringBuilder("List:" & ControlChars.CrLf)
        Dim index As Integer = 0
        Dim iterator As NodeP = nodeHead.Next
        While Not (iterator Is Nothing)
            list.Append(("Node #" & index.ToString() & ControlChars.CrLf & iterator.ToString() & ControlChars.CrLf))
            index = index + 1
            iterator = iterator.Next
        End While
        Return list.ToString()
    End Function 'ToString
    ' Add a node
    Public Sub Add(ByVal point As clsVec3)
        Dim node As New NodeP
        node.TextData = point
        node.Add(nodeHead)
        nodeActual = node
    End Sub 'Add
    Public Function Count() As Integer
        Dim index As Integer = 0
        Dim iterator As NodeP = nodeHead.Next
        While Not (iterator Is Nothing)
            index = index + 1
            iterator = iterator.Next
        End While
        Return index
    End Function
    Public Function Item(ByVal i As Integer) As NodeP
        Dim iterator As NodeP = nodeHead.Next
        Dim index As Integer = 1
        While Not (iterator Is Nothing) And i <> index
            index = index + 1
            iterator = iterator.Next
        End While
        Return iterator
    End Function
    Public Sub remove(ByVal i As Integer)
        If i = 1 Then
            If Not nodeHead.Next Is Nothing Then
                nodeHead = nodeHead.Next
            End If
        Else
            Item(i - 1).Next = Item(i + 1)
        End If
    End Sub
    ' This nested type is also attributed as serializable
    <Serializable()> Public Class NodeP
        ' Private field referencing the next node in the list
        Private nextField As NodeP
        ' Private fields containing node data
        Private DataField As clsVec3
        ' Construct a Node object
        Public Sub New()
            nextField = Nothing
        End Sub 'New
        ' Add a node object to a list
        Public Sub Add(ByVal nodeHead As NodeP)
            Dim iterator As NodeP = nodeHead
            While Not (iterator.nextField Is Nothing)
                iterator = iterator.Next
            End While
            iterator.nextField = Me
            nextField = Nothing
        End Sub 'Add
        ' Accessor property for textData private field
        Public Property TextData() As clsVec3
            Get
                Return DataField
            End Get
            Set(ByVal Value As clsVec3)
                DataField = Value
            End Set
        End Property
        ' Read-only property for next private field
        Public Property [Next]() As NodeP
            Get
                Return nextField
            End Get
            Set(ByVal Value As NodeP)
                nextField = Value
            End Set
        End Property
        ' Represent the node as a string
        Public Overrides Function ToString() As String
            Return ControlChars.Tab & "TextData   " & ChrW(61) & " """ & TextData.ToString
        End Function 'ToString
    End Class 'Node
End Class 'LinkedListPublic Class LinkedList
<Serializable()> Public Class LinkedListP
    ' Reference to the empty head node
    Friend nodeHead As NodeP2
    Friend nodeActual As NodeP2
    Friend BaseZero As Short
    Public Sub New(ByVal b As Short)
        nodeHead = New NodeP2
        BaseZero = b
    End Sub 'New
    ' Represent the LinkedList as a string
    Public Overrides Function ToString() As String
        Dim list As New StringBuilder("List:" & ControlChars.CrLf)
        Dim index As Integer = 0
        Dim iterator As NodeP2 = nodeHead.Next
        While Not (iterator Is Nothing)
            list.Append(("Node #" & index.ToString() & ControlChars.CrLf & iterator.ToString() & ControlChars.CrLf))
            index = index + 1
            iterator = iterator.Next
        End While
        Return list.ToString()
    End Function 'ToString
    ' Add a node
    Public Sub Add(ByVal point As clsVec2)
        Dim node As New NodeP2
        node.TextData = point
        node.Add(nodeHead)
        nodeActual = node
    End Sub 'Add
    Public Function Count() As Integer
        Dim index As Integer = 0
        Dim iterator As NodeP2 = nodeHead.Next
        While Not (iterator Is Nothing)
            index = index + 1
            iterator = iterator.Next
        End While
        Return index
    End Function
    Default Public ReadOnly Property ItemAt(ByVal i As Integer) As clsVec2
        Get
            Return Item(i).TextData
        End Get
    End Property
    Public Function Item(ByVal i As Integer) As NodeP2
        Dim iterator As NodeP2 = nodeHead.Next
        Dim index As Integer = BaseZero
        While Not (iterator Is Nothing) And i <> index
            index = index + 1
            iterator = iterator.Next
        End While
        Return iterator
    End Function
    Public Sub remove(ByVal i As Integer)
        If i = BaseZero Then
            If Not nodeHead.Next Is Nothing Then
                nodeHead = nodeHead.Next
            End If
        ElseIf i < BaseZero Then
            Throw New Exception("Tentativo di rimuovere l'elemento 0 di una lista a base 1")
        Else
            Item(i - 1).Next = Item(i + 1)
        End If
    End Sub
    ' This nested type is also attributed as serializable
    <Serializable()> Public Class NodeP2
        ' Private field referencing the next node in the list
        Private nextField As NodeP2
        ' Private fields containing node data
        Private DataField As clsVec2
        ' Construct a Node object
        Public Sub New()
            nextField = Nothing
        End Sub 'New
        ' Add a node object to a list
        Public Sub Add(ByVal nodeHead As NodeP2)
            Dim iterator As NodeP2 = nodeHead
            While Not (iterator.nextField Is Nothing)
                iterator = iterator.Next
            End While
            iterator.nextField = Me
            nextField = Nothing
        End Sub 'Add
        ' Accessor property for textData private field
        Public Property TextData() As clsVec2
            Get
                Return DataField
            End Get
            Set(ByVal Value As clsVec2)
                DataField = Value
            End Set
        End Property
        ' Read-only property for next private field
        Public Property [Next]() As NodeP2
            Get
                Return nextField
            End Get
            Set(ByVal Value As NodeP2)
                nextField = Value
            End Set
        End Property
        ' Represent the node as a string
        Public Overrides Function ToString() As String
            Return ControlChars.Tab & "TextData   " & ChrW(61) & " """ & TextData.ToString
        End Function 'ToString
    End Class 'Node
End Class 'LinkedListPublic Class LinkedList
<Serializable()> Public Class LinkListSh
    ' Reference to the empty head node
    Friend nodeHead As NodeP
    Friend nodeActual As NodeP
    Private PrimoMembro As Boolean
    ' Construct an empty LinkedList
    Public Sub New()
        nodeHead = New NodeP
        PrimoMembro = False
    End Sub 'New
    ' Represent the LinkedList as a string
    Public Overrides Function ToString() As String
        Dim list As New StringBuilder("List:" & ControlChars.CrLf)
        Dim index As Integer = 0
        Dim iterator As NodeP = nodeHead.Next
        While Not (iterator Is Nothing)
            list.Append(("Node #" & index.ToString() & ControlChars.CrLf & iterator.ToString() & ControlChars.CrLf))
            index = index + 1
            iterator = iterator.Next
        End While
        Return list.ToString()
    End Function 'ToString
    ' Add a node
    Public Sub Add(ByVal point As Short)
        If Not PrimoMembro Then
            nodeHead.TextData = point
            nodeActual = nodeHead
            PrimoMembro = True
        Else
            Dim node As New NodeP
            node.TextData = point
            node.Add(nodeHead)
            nodeActual = node
        End If
    End Sub 'Add
    Public Function Count() As Integer
        Dim index As Integer = 1
        Dim iterator As NodeP = nodeHead.Next
        If Not PrimoMembro Then
            Return 0
        Else
            While Not (iterator Is Nothing)
                index = index + 1
                iterator = iterator.Next
            End While
            Return index
        End If
    End Function
    Default Public ReadOnly Property Item(ByVal i As Integer) As NodeP
        Get
            Dim iterator As NodeP = nodeHead
            Dim index As Integer = 1
            While Not (iterator Is Nothing) And i <> index
                index = index + 1
                iterator = iterator.Next
            End While
            Return iterator
        End Get
    End Property
    Public Sub RemoveAll()
        nodeHead.Next = Nothing
        nodeHead.TextData = 0
        PrimoMembro = False
    End Sub
    Public Sub Remove(ByVal i As Integer)
        If i = 1 Then
            If Not nodeHead.Next Is Nothing Then
                nodeHead = nodeHead.Next
            Else
                nodeHead.TextData = 0
                PrimoMembro = False
            End If
        Else
            Item(i - 1).Next = Item(i + 1)
        End If
    End Sub
    Public Sub RemoveValue(ByVal i As Integer)
        Dim j As Short
        For j = 1 To Count()
            If Item(j).TextData = i Then
                Remove(j)
                Exit Sub
            End If
        Next
    End Sub
    <Serializable()> Public Class NodeP
        Private nextField As NodeP
        Private DataField As Short
        Public Sub New()
            nextField = Nothing
        End Sub 'New
        Public Sub Add(ByVal nodeHead As NodeP)
            Dim iterator As NodeP = nodeHead
            While Not (iterator.nextField Is Nothing)
                iterator = iterator.Next
            End While
            iterator.nextField = Me
            nextField = Nothing
        End Sub 'Add
        Public Property TextData() As Short
            Get
                Return DataField
            End Get
            Set(ByVal Value As Short)
                DataField = Value
            End Set
        End Property
        ' Read-only property for next private field
        Public Property [Next]() As NodeP
            Get
                Return nextField
            End Get
            Set(ByVal Value As NodeP)
                nextField = Value
            End Set
        End Property
        ' Represent the node as a string
        Public Overrides Function ToString() As String
            Return ControlChars.Tab & "TextData   " & ChrW(61) & " """ & TextData.ToString
        End Function 'ToString
    End Class 'Node
End Class
<Serializable()> Public Class LinkListS
    ' Reference to the empty head node
    Friend nodeHead As NodeP
    Friend nodeActual As NodeP
    Private PrimoMembro As Boolean
    Public Sub New()
        nodeHead = New NodeP
        PrimoMembro = False
    End Sub 'New
    ' Represent the LinkedList as a string
    Public Overrides Function ToString() As String
        Dim list As New StringBuilder("List:" & ControlChars.CrLf)
        Dim index As Integer = 0
        Dim iterator As NodeP = nodeHead.Next
        While Not (iterator Is Nothing)
            list.Append(("Node #" & index.ToString() & ControlChars.CrLf & iterator.ToString() & ControlChars.CrLf))
            index = index + 1
            iterator = iterator.Next
        End While
        Return list.ToString()
    End Function 'ToString
    ' Add a node
    Public Sub Add(ByVal point As Single)
        If Not PrimoMembro Then
            nodeHead.TextData = point
            nodeActual = nodeHead
            PrimoMembro = True
        Else
            Dim node As New NodeP
            node.TextData = point
            node.Add(nodeHead)
            nodeActual = node
        End If
    End Sub 'Add
    Public Function Count() As Integer
        Dim index As Integer = 0
        Dim iterator As NodeP = nodeHead.Next
        If Not PrimoMembro Then
            Return 0
        Else
            While Not (iterator Is Nothing)
                index = index + 1
                iterator = iterator.Next
            End While
            Return index
        End If
    End Function
    Default Public ReadOnly Property Item(ByVal i As Integer) As NodeP
        Get
            Dim iterator As NodeP = nodeHead
            Dim index As Integer = 1
            While Not (iterator Is Nothing) And i <> index
                index = index + 1
                iterator = iterator.Next
            End While
            Return iterator
        End Get
    End Property
    Public Sub remove(ByVal i As Integer)
        If i = 1 Then
            If Not nodeHead.Next Is Nothing Then
                nodeHead = nodeHead.Next
            Else
                nodeHead.TextData = 0
                PrimoMembro = False
            End If
        Else
            Item(i - 1).Next = Item(i + 1)
        End If
    End Sub
    ' This nested type is also attributed as serializable
    <Serializable()> Public Class NodeP
        ' Private field referencing the next node in the list
        Private nextField As NodeP
        ' Private fields containing node data
        Private DataField As Single
        ' Construct a Node object
        Public Sub New()
            nextField = Nothing
        End Sub 'New
        ' Add a node object to a list
        Public Sub Add(ByVal nodeHead As NodeP)
            Dim iterator As NodeP = nodeHead
            While Not (iterator.nextField Is Nothing)
                iterator = iterator.Next
            End While
            iterator.nextField = Me
            nextField = Nothing
        End Sub 'Add
        ' Accessor property for textData private field
        Public Property TextData() As Single
            Get
                Return DataField
            End Get
            Set(ByVal Value As Single)
                DataField = Value
            End Set
        End Property
        ' Read-only property for next private field
        Public Property [Next]() As NodeP
            Get
                Return nextField
            End Get
            Set(ByVal Value As NodeP)
                nextField = Value
            End Set
        End Property
        ' Represent the node as a string
        Public Overrides Function ToString() As String
            Return ControlChars.Tab & "TextData   " & ChrW(61) & " """ & TextData.ToString
        End Function 'ToString
    End Class 'Node
End Class
<Serializable()> Public Class OggList
    Public nodeHead As NodeP
    Friend nodeActual As NodeP
    Private BaseZero As Short
    Private Const nCifreKeys As Short = 4
    Public Sub New(ByVal zero As Short)
        nodeHead = New NodeP
        BaseZero = zero
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
    Public Function Cambiakey(ByVal vecchia As String, ByVal nuova As String) As Boolean
        If nuova.Equals(vecchia) Then Return False
        Dim nodo As NodeP = Item(vecchia)
        If nodo Is Nothing Then Return True
        Dim check As NodeP = Item(nuova)
        If Not check Is Nothing Then Return False
        nodo.key = nuova
        Return True
    End Function
    Public Sub Add(ByVal point As Object, Optional ByRef key As String = "", Optional ByVal Before As String = "", Optional ByVal After As String = "")
        Dim node As New NodeP
        Dim nBefore, nAfter As NodeP
        Dim duplicato As NodeP = Item(key)
        key = key.Trim
        If Not duplicato Is Nothing Then
            If key.Length < nCifreKeys And IsNumeric(key) Then key = New String(CChar("0"), 4 - key.Length) & key
            Dim i As Integer = 1
            Do
                key = Trigon.FormatS(New String(CChar("0"), nCifreKeys), i)
                i += 1
            Loop Until IsNothing(Item(key))
        End If
        If key = "" Then key = Trigon.FormatS(New String(CChar("0"), nCifreKeys), Count() + 1)
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
            Dim index As Integer = BaseZero
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
    Default Public Overloads Property ItemAt(ByVal i As Integer) As Object
        Get
            Dim n As NodeP = Item(i)
            If IsNothing(n) Then Return Nothing
            Return n.TextData
        End Get
        Set(ByVal Value As Object)
            Dim n As NodeP = Item(i)
            If IsNothing(n) Then
                Add(Value, Trigon.FormatS(New String(CChar("0"), nCifreKeys), i))
            Else
                n.TextData = Value
            End If
        End Set
    End Property
    Default Public Overloads Property ItemAt(ByVal k As String) As Object
        Get
            Dim n As NodeP = Item(k)
            If IsNothing(n) Then Return Nothing
            Return n.TextData
        End Get
        Set(ByVal Value As Object)
            Dim n As NodeP = Item(k)
            If IsNothing(n) Then
                Add(Value, k)
            Else
                n.TextData = Value
            End If
        End Set
    End Property
    Public Overloads Sub remove(ByVal i As Integer)
        If i = BaseZero Then
            If Not nodeHead.Next.Next Is Nothing Then
                nodeHead.Next = nodeHead.Next.Next
                nodeHead.Next.Previous = nodeHead
            Else
                nodeHead.Next = Nothing
            End If
        ElseIf i < BaseZero Then
            Throw New Exception("Tentativo di rimuovere l'elemento 0 di una lista a base 1")
        ElseIf i = Count() - 1 Then
            Item(i - 1).Next = Nothing
        Else
            Item(i - 1).Next = Item(i + 1)
        End If
    End Sub
    Public Overloads Sub remove(ByVal k As String)
        Dim n As NodeP = Item(k)
        If n Is nodeHead.Next Then
            If Not nodeHead.Next.Next Is Nothing Then
                nodeHead.Next = nodeHead.Next.Next
                nodeHead.Next.Previous = nodeHead
            End If
        ElseIf n.Next Is Nothing Then
            n.Previous.Next = Nothing
        Else
            n.Previous.Next = n.Next
        End If
    End Sub
    Public Sub RemoveAll()
        If Not nodeHead Is Nothing Then nodeHead.Next = Nothing
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
                If Not n Is Nothing Then n.prevField = Me
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
                If Not Value Is Nothing Then Value.Previous = Me
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
