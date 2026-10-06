Imports System.Windows.forms
Public Class arrRTF
    Inherits System.Windows.Forms.RichTextBox
    Private ReadOnly HostForm As Object
    Public ReadOnly Insieme As Object
    Public Dummy As Boolean
    Public Sub New(ByVal host As Object, ByVal Padre As Object)
        MyBase.new()
        HostForm = host
        Insieme = Padre
    End Sub
End Class
Public Class rtfArray
    Inherits System.Collections.CollectionBase
    Private ReadOnly HostForm As Object
    Private ReadOnly PrefixName As String
    Private ReadOnly Quadro As Object
    Public Sub New(ByVal host As Object, ByVal q As Object, ByVal P As String)
        MyBase.New()
        HostForm = host
        PrefixName = P
        Quadro = q
        Dim i As Integer
        For i = 0 To q.Controls.Count - 1
            If q.Controls(i).Name = PrefixName & "_0" Then
                Dim l As RichTextBox = CType(q.Controls(i), RichTextBox)
                Dim al As arrRTF = New arrRTF(host, Me)
                al.Tag = 0
                al.Name = l.Name
                al.Size = l.Size
                al.Location = l.Location
                al.Font = l.Font
                al.BackColor = l.BackColor
                al.ForeColor = l.ForeColor
                al.Dummy = False
                al.Visible = l.Visible
                List.Add(al)
                Quadro.Controls.Add(al)
                l.Visible = False
                Exit Sub
            End If
        Next
    End Sub
    Default Public ReadOnly Property Item(ByVal Index As Integer) As arrRTF
        Get
            If Index < List.Count Then
                Return CType(List.Item(Index), arrRTF)
            Else
                Return Nothing
            End If
        End Get
    End Property
    Public Sub UnLoad(ByVal Index As Integer)
        If Index > Count - 1 Then Exit Sub
        Me.Item(Index).Dispose()
        Quadro.Controls.Remove(Me(Index))
        Me.List.RemoveAt(Index)
    End Sub
    Public Sub Remove()
        ' Check to be sure there is a button to remove.
        If Me.Count > 0 Then
            Me.Item(Me.Count - 1).Dispose()
            Quadro.Controls.Remove(Me(Me.Count - 1))
            Me.List.RemoveAt(Me.Count - 1)
        End If
    End Sub
    Public Sub RemoveAll(Optional ByVal i As Integer = 0)
        Do While Count > i
            Remove()
        Loop
    End Sub
    Public Function Load(ByVal Index As Integer) As arrRTF
        Dim i As Integer
        If Index >= Count Then
            For i = Count To Index - 1
                AddNewTextBox(True)
            Next
            Return AddNewTextBox(False)
        Else
            CType(list(Index), arrRTF).Visible = True
            Return CType(list(Index), arrRTF)
        End If
    End Function
    Public Function AddNewTextBox(ByVal d As Boolean) As arrRTF
        Dim aButton As New arrRTF(HostForm, Me)
        Me.List.Add(aButton)
        Quadro.Controls.Add(aButton)
        aButton.Tag = Me.Count - 1
        aButton.Name = PrefixName & "_" & CStr(aButton.Tag).Trim
        aButton.Visible = False
        aButton.Size = CType(list(0), arrRTF).Size
        aButton.Location = CType(list(0), arrRTF).Location
        aButton.Font = CType(list(0), arrRTF).Font
        aButton.BackColor = CType(list(0), arrRTF).BackColor
        aButton.ForeColor = CType(list(0), arrRTF).ForeColor
        aButton.ScrollBars = CType(list(0), arrRTF).ScrollBars
        aButton.Dummy = d
        Return aButton
    End Function
End Class
Public Class arrText
    Inherits System.Windows.Forms.TextBox
    Private ReadOnly HostForm As Object
    Public ReadOnly Insieme As Object
    Public Dummy As Boolean
    Public Sub New(ByVal host As Object, ByVal Padre As Object)
        MyBase.new()
        HostForm = host
        Insieme = Padre
    End Sub
    Protected Overrides Sub OnLeave(ByVal e As System.EventArgs)
        Try
            HostForm.Text_Leave(Name)
        Catch
        End Try
    End Sub
    Protected Overrides Sub OnTextChanged(ByVal e As System.EventArgs)
        Try
            HostForm.Text_Changed(Name)
        Catch
        End Try
    End Sub
    Protected Overrides Sub OnEnter(ByVal e As System.EventArgs)
        Try
            HostForm.Text_Enter(Name)
        Catch
        End Try
    End Sub
    Protected Overrides Sub OnKeyDown(ByVal e As System.Windows.Forms.KeyEventArgs)
        Try
            HostForm.Text_KeyDown(Name, e)
        Catch
        End Try
    End Sub
    Protected Overrides Sub OnKeyPress(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Try
            HostForm.Text_KeyPress(Name, e)
        Catch
        End Try
    End Sub
    Protected Overrides Sub OnKeyUp(ByVal e As System.Windows.Forms.KeyEventArgs)
        Try
            HostForm.Text_KeyUp(Name, e)
        Catch
        End Try
    End Sub
    Protected Overrides Sub OnMouseDown(ByVal e As System.Windows.Forms.MouseEventArgs)
        Try
            HostForm.Text_MouseDown(Name, e)
        Catch
        End Try
    End Sub
End Class
Public Class TextArray
    Inherits System.Collections.CollectionBase
    Private ReadOnly HostForm As Object
    Private ReadOnly PrefixName As String
    Private ReadOnly Quadro As Object
    Public Sub New(ByVal host As Object, ByVal q As Object, ByVal P As String)
        MyBase.New()
        HostForm = host
        PrefixName = P
        Quadro = q
        Dim i As Integer
        For i = 0 To q.Controls.Count - 1
            If q.Controls(i).Name = PrefixName & "_0" Then
                Dim l As TextBox = CType(q.Controls(i), TextBox)
                Dim al As arrText = New arrText(host, Me)
                al.Tag = 0
                Dim n As String = l.Name
                l.Name = n & "a"
                al.Name = n
                al.AutoSize = l.AutoSize
                al.Size = l.Size
                al.Location = l.Location
                al.Font = l.Font
                al.BorderStyle = l.BorderStyle
                al.TextAlign = l.TextAlign
                al.BorderStyle = l.BorderStyle
                al.BackColor = l.BackColor
                al.ForeColor = l.ForeColor
                al.Multiline = l.Multiline
                al.Dummy = False
                al.Visible = True
                List.Add(al)
                l.Visible = False
                Quadro.Controls.Add(al)
                Exit Sub
            End If
        Next
    End Sub
    Default Public ReadOnly Property Item(ByVal Index As Integer) As arrText
        Get
            If Index < List.Count Then
                Return CType(List.Item(Index), arrText)
            Else
                Return Nothing
            End If
        End Get
    End Property
    Public Sub UnLoad(ByVal Index As Integer)
        If Index > Count - 1 Then Exit Sub
        Me.Item(Index).Dispose()
        Quadro.Controls.Remove(Me(Index))
        Me.List.RemoveAt(Index)
    End Sub
    Public Sub Remove()
        ' Check to be sure there is a button to remove.
        If Me.Count > 0 Then
            Me.Item(Me.Count - 1).Dispose()
            Quadro.Controls.Remove(Me(Me.Count - 1))
            Me.List.RemoveAt(Me.Count - 1)
        End If
    End Sub
    Public Sub RemoveAll(Optional ByVal i As Integer = 0)
        Do While Count > i
            Remove()
        Loop
    End Sub
    Public Function Load(ByVal Index As Integer) As arrText
        Dim i As Integer
        If Index >= Count Then
            For i = Count To Index - 1
                AddNewTextBox(True)
            Next
            Return AddNewTextBox(False)
        Else
            CType(list(Index), arrText).Visible = True
            Return CType(list(Index), arrText)
        End If
    End Function
    Public Function AddNewTextBox(ByVal d As Boolean) As arrText
        Dim aButton As New arrText(HostForm, Me)
        Me.List.Add(aButton)
        Quadro.Controls.Add(aButton)
        aButton.Tag = Me.Count - 1
        aButton.Name = PrefixName & "_" & CStr(aButton.Tag).Trim
        aButton.AutoSize = CType(list(0), arrText).AutoSize
        aButton.Visible = CType(List(0), arrText).Visible ' False
        aButton.Size = CType(list(0), arrText).Size
        aButton.Location = CType(list(0), arrText).Location
        aButton.Font = CType(list(0), arrText).Font
        aButton.TextAlign = CType(list(0), arrText).TextAlign
        aButton.BorderStyle = CType(list(0), arrText).BorderStyle
        aButton.BackColor = CType(list(0), arrText).BackColor
        aButton.ForeColor = CType(list(0), arrText).ForeColor
        aButton.Multiline = CType(list(0), arrText).Multiline
        aButton.Dummy = d
        Return aButton
    End Function
End Class
Public Class arrButton
    Inherits System.Windows.Forms.Button
    Private ReadOnly HostForm As Object
    Public ReadOnly Insieme As Object
    Public Dummy As Boolean
    Public Sub New(ByVal host As Object, ByVal Padre As Object)
        MyBase.new()
        HostForm = host
        Insieme = Padre
    End Sub
    Protected Overrides Sub OnClick(ByVal e As System.EventArgs)
        Try
            HostForm.Button_Click(Name)
        Catch
        End Try
    End Sub
    Protected Overrides Sub OnEnter(ByVal e As System.EventArgs)
        Try
            HostForm.Button_Enter(Name)
        Catch
        End Try
    End Sub
End Class
Public Class ButtonArray
    Inherits System.Collections.CollectionBase
    Private ReadOnly HostForm As Object
    Private ReadOnly PrefixName As String
    Private ReadOnly Quadro As Object
    Public Sub New(ByVal host As Object, ByVal q As Object, ByVal P As String)
        MyBase.New()
        HostForm = host
        PrefixName = P
        Quadro = q
        Dim i As Integer
        For i = 0 To q.Controls.Count - 1
            If q.Controls(i).Name = PrefixName & "_0" Then
                Dim l As Button = CType(q.Controls(i), Button)
                Dim al As arrButton = New arrButton(host, Me)
                al.Tag = 0
                al.Name = l.Name
                al.Size = l.Size
                al.Location = l.Location
                al.Font = l.Font
                al.TextAlign = l.TextAlign
                al.BackColor = l.BackColor
                al.ForeColor = l.ForeColor
                al.Image = l.Image
                al.Dummy = False
                al.Visible = l.Visible
                List.Add(al)
                Quadro.Controls.Add(al)
                l.Visible = False
                Exit Sub
            End If
        Next
    End Sub
    Default Public ReadOnly Property Item(ByVal Index As Integer) As arrButton
        Get
            If Index < List.Count Then
                Return CType(List.Item(Index), arrButton)
            Else
                Return Nothing
            End If
        End Get
    End Property
    Public Sub UnLoad(ByVal Index As Integer)
        ' Exit Sub
        'Stop
        If Index >= Count - 1 Then Exit Sub
        Me.Item(Index).Dispose()
        Quadro.Controls.Remove(Me(Index))
        Me.List.RemoveAt(Index)
    End Sub
    Public Sub Remove()
        ' Check to be sure there is a button to remove.
        If Me.Count > 0 Then
            Me.Item(Me.Count - 1).Dispose()
            Quadro.Controls.Remove(Me(Me.Count - 1))
            Me.List.RemoveAt(Me.Count - 1)
        End If
    End Sub
    Public Sub RemoveAll(Optional ByVal i As Integer = 0)
        Do While Count > i
            Remove()
        Loop
    End Sub
    Public Function Load(ByVal Index As Integer) As arrButton
        Dim i As Integer
        If Index >= Count Then
            For i = Count To Index - 1
                AddNewTextBox(True)
            Next
            Return AddNewTextBox(False)
        Else
            CType(list(Index), arrButton).Visible = True
            Return CType(list(Index), arrButton)
        End If
    End Function
    Public Function AddNewTextBox(ByVal d As Boolean) As arrButton
        Dim aButton As New arrButton(HostForm, Me)
        Me.List.Add(aButton)
        Quadro.Controls.Add(aButton)
        aButton.Tag = Me.Count - 1
        aButton.Name = PrefixName & "_" & CStr(aButton.Tag).Trim
        aButton.Visible = False
        aButton.Size = CType(list(0), arrButton).Size
        aButton.Location = CType(list(0), arrButton).Location
        aButton.Font = CType(list(0), arrButton).Font
        aButton.TextAlign = CType(list(0), arrButton).TextAlign
        aButton.BackColor = CType(list(0), arrButton).BackColor
        aButton.ForeColor = CType(list(0), arrButton).ForeColor
        aButton.Image = CType(list(0), arrButton).Image
        aButton.Dummy = d
        Return aButton
    End Function
End Class
Public Class arrLabel
    Inherits System.Windows.Forms.Label
    Private ReadOnly HostForm As Object
    Public ReadOnly Insieme As Object
    Public Dummy As Boolean
    Public Sub New(ByVal host As Object, ByVal Padre As Object)
        MyBase.new()
        HostForm = host
        Insieme = Padre
    End Sub
End Class
Public Class LabelArray
    Inherits System.Collections.CollectionBase
    Private ReadOnly HostForm As Object
    Private ReadOnly PrefixName As String
    Private ReadOnly Quadro As Object
    Public Sub New(ByVal host As Object, ByVal q As Object, ByVal P As String)
        MyBase.New()
        Dim i As Integer
        HostForm = host
        PrefixName = P
        Quadro = q
        For i = 0 To q.Controls.Count - 1
            If q.Controls(i).Name = PrefixName & "_0" Then
                Dim l As Label = CType(q.Controls(i), Label)
                Dim al As arrLabel = New arrLabel(host, Me)
                al.Tag = 0
                al.Name = l.Name
                al.Size = l.Size
                al.Location = l.Location
                al.Font = l.Font
                al.BorderStyle = l.BorderStyle
                al.FlatStyle = l.FlatStyle
                al.BackColor = l.BackColor
                al.Dummy = False
                al.Visible = True
                List.Add(al)
                Quadro.Controls.Add(al)
                l.Visible = False
                Exit Sub
            End If
        Next
    End Sub
    Default Public ReadOnly Property Item(ByVal Index As Integer) As arrLabel
        Get
            If Index < List.Count Then
                Return CType(List.Item(Index), arrLabel)
            Else
                Return Nothing
            End If
        End Get
    End Property
    Public Sub UnLoad(ByVal Index As Integer)
        If Index > Count - 1 Then Exit Sub
        Me.Item(Index).Dispose()
        Quadro.Controls.Remove(Me(Index))
        Me.List.RemoveAt(Index)
    End Sub
    Public Sub Remove()
        ' Check to be sure there is a button to remove.
        If Me.Count > 0 Then
            Me.Item(Me.Count - 1).Dispose()
            Quadro.Controls.Remove(Me(Me.Count - 1))
            Me.List.RemoveAt(Me.Count - 1)
        End If
    End Sub
    Public Sub RemoveAll(Optional ByVal i As Integer = 0)
        Do While Count > i
            Remove()
        Loop
    End Sub
    Public Function Load(ByVal Index As Integer) As arrLabel
        Dim i As Integer
        If Index >= Count Then
            For i = Count To Index - 1
                AddNewTextBox(True)
            Next
            Return AddNewTextBox(False)
        Else
            CType(list(Index), arrLabel).Visible = True
            Return CType(list(Index), arrLabel)
        End If
    End Function
    Public Function AddNewTextBox(ByVal d As Boolean) As arrLabel
        Dim aButton As New arrLabel(HostForm, Me)
        Me.List.Add(aButton)
        Quadro.Controls.Add(aButton)
        aButton.Tag = Me.Count - 1
        aButton.Name = PrefixName & "_" & CStr(aButton.Tag).Trim
        aButton.Visible = CType(List(0), arrLabel).Visible ' False
        aButton.Size = CType(list(0), arrLabel).Size
        aButton.Location = CType(list(0), arrLabel).Location
        aButton.Font = CType(list(0), arrLabel).Font
        aButton.BorderStyle = CType(list(0), arrLabel).BorderStyle
        aButton.FlatStyle = CType(list(0), arrLabel).FlatStyle
        aButton.BackColor = CType(list(0), arrLabel).BackColor
        aButton.Dummy = d
        Return aButton
    End Function
End Class
Public Class ControlArray
    Inherits System.Collections.CollectionBase
    Default Public Property Item(ByVal Index As Integer) As Control
        Get
            If Index < List.Count Then
                Return CType(List.Item(Index), Control)
            Else
                Return Nothing
            End If
        End Get
        Set(ByVal Value As Control)
            Dim i As Short
            If Index >= Count Then
                For i = Count To Index - 1
                    Me.List.Add(New Control)
                Next
                Me.List.Add(Value)
            Else
                Me.List(Index) = Value
            End If
        End Set
    End Property
    Public Sub RemoveAll(Optional ByVal i As Integer = 0)
        While Count > i
            UnLoad(i)
        End While
    End Sub
    Public Sub UnLoad(ByVal Index As Integer)
        Select Case Item(Index).GetType.Name
            Case GetType(arrLabel).Name
                CType(CType(Item(Index), arrLabel).Insieme, LabelArray).UnLoad(Index)
            Case GetType(arrText).Name
                CType(CType(Item(Index), arrText).Insieme, TextArray).UnLoad(Index)
            Case GetType(arrCombo).Name
                CType(CType(Item(Index), arrCombo).Insieme, ComboArray).UnLoad(Index)
            Case GetType(arrCheck).Name
                CType(CType(Item(Index), arrCheck).Insieme, CheckArray).UnLoad(Index)
            Case GetType(arrRTF).Name
                CType(CType(Item(Index), arrRTF).Insieme, rtfArray).UnLoad(Index)
        End Select
        list.RemoveAt(Index)
    End Sub
End Class
Public Class arrCombo
    Inherits System.Windows.Forms.ComboBox
    Private ReadOnly HostForm As Object
    Public ReadOnly Insieme As Object
    Public Dummy As Boolean
    Public Sub New(ByVal host As Object, ByVal Padre As Object)
        MyBase.new()
        HostForm = host
        Insieme = Padre
    End Sub
    Protected Overrides Sub OnSelectedIndexChanged(ByVal e As System.EventArgs)
        Try
            HostForm.Combo_SelectedIndexChanged(Name)
        Catch ex As Exception
        End Try
    End Sub
    Protected Overrides Sub OnEnter(ByVal e As System.EventArgs)
        Try
            HostForm.Combo_Enter(Name)
        Catch
        End Try
    End Sub

    Protected Overrides Sub OnKeyPress(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Try
            HostForm.Combo_KeyPress(Name, e)
        Catch ex As Exception
        End Try
    End Sub
    Protected Overrides Sub OnMouseDown(ByVal e As System.Windows.Forms.MouseEventArgs)
        Try
            HostForm.Combo_MouseDown(Name)
        Catch
        End Try
    End Sub
    Protected Overrides Sub OnTextChanged(ByVal e As System.EventArgs)
        Try
            HostForm.Combo_TextChanged(Name)
        Catch
        End Try
    End Sub
    Protected Overrides Sub OnValidating(ByVal e As System.ComponentModel.CancelEventArgs)
        Try
            HostForm.Combo_Validating(Name, e)
        Catch
        End Try
    End Sub
    Protected Overrides Sub OnClick(ByVal e As System.EventArgs)
        Try
            HostForm.Combo_Click(Name, e)
        Catch
        End Try
    End Sub
End Class
Public Class ComboArray
    Inherits System.Collections.CollectionBase
    Private ReadOnly HostForm As Object
    Private ReadOnly PrefixName As String
    Private ReadOnly Quadro As Object
    Public Sub New(ByVal host As Object, ByVal q As Object, ByVal P As String, Optional ByVal n As String = "")
        MyBase.New()
        HostForm = host
        PrefixName = P
        Quadro = q
        Dim i As Integer
        For i = 0 To q.Controls.Count - 1
            If q.Controls(i).Name = PrefixName & "_0" Then
                Dim l As ComboBox = CType(q.Controls(i), ComboBox)
                Dim al As arrCombo = New arrCombo(host, Me)
                al.Tag = 0
                al.Size = l.Size
                al.Location = l.Location
                If n.Length > 0 Then
                    al.Name = n
                    '      al.Left += l.Width
                Else
                    al.Name = l.Name
                End If
                al.Font = l.Font
                al.DropDownStyle = l.DropDownStyle
                al.BackColor = l.BackColor
                al.ForeColor = l.ForeColor
                al.Dummy = False
                al.Visible = True
                List.Add(al)
                Quadro.Controls.Add(al)
                l.Visible = False
                Exit Sub
            End If
        Next
    End Sub
    Public Sub AddNew(ByVal l As ComboBox, Optional ByVal n As String = "")
        Dim al As arrCombo = New arrCombo(HostForm, Me)
        If n.Length > 0 Then
            al.Name = n
        Else
            al.Name = l.Name
        End If
        al.Size = l.Size
        al.Location = l.Location
        al.Font = l.Font
        al.DropDownStyle = l.DropDownStyle
        al.BackColor = l.BackColor
        al.ForeColor = l.ForeColor
        al.Dummy = False
        al.Visible = l.Visible
        List.Add(al)
        Quadro.Controls.Add(al)
        l.Visible = False
    End Sub
    Default Public ReadOnly Property Item(ByVal Index As Integer) As arrCombo
        Get
            If Index < List.Count Then
                Return CType(List.Item(Index), arrCombo)
            Else
                Return Nothing
            End If
        End Get
    End Property
    Public Sub UnLoad(ByVal Index As Integer)
        If Index > Count - 1 Then Exit Sub
        Me.Item(Index).Dispose()
        Quadro.Controls.Remove(Me(Index))
        Me.List.RemoveAt(Index)
    End Sub
    Public Sub Remove()
        ' Check to be sure there is a button to remove.
        If Me.Count > 0 Then
            Me.Item(Me.Count - 1).Dispose()
            Quadro.Controls.Remove(Me(Me.Count - 1))
            Me.List.RemoveAt(Me.Count - 1)
        End If
    End Sub
    Public Sub RemoveAll(Optional ByVal i As Integer = 0)
        Do While Count > i
            Remove()
        Loop
    End Sub
    Public Function Load(ByVal Index As Integer) As arrCombo
        Dim i As Integer
        If Index >= Count Then
            For i = Count To Index - 1
                AddNewTextBox(True)
            Next
            Return AddNewTextBox(False)
        Else
            CType(list(Index), arrCombo).Visible = True
            Return CType(list(Index), arrCombo)
        End If
    End Function
    Public Function AddNewTextBox(ByVal d As Boolean) As arrCombo
        Dim aButton As New arrCombo(HostForm, Me)
        Me.List.Add(aButton)
        Quadro.Controls.Add(aButton)
        aButton.Tag = Me.Count - 1
        aButton.Name = PrefixName & "_" & CStr(aButton.Tag).Trim
        aButton.Visible = False
        aButton.Size = CType(list(0), arrCombo).Size
        aButton.Location = CType(list(0), arrCombo).Location
        aButton.Font = CType(list(0), arrCombo).Font
        aButton.DropDownStyle = CType(list(0), arrCombo).DropDownStyle
        aButton.BackColor = CType(list(0), arrCombo).BackColor
        aButton.ForeColor = CType(list(0), arrCombo).ForeColor
        aButton.Dummy = d
        Return aButton
    End Function
End Class
Public Class arrCheck
    Inherits System.Windows.Forms.CheckBox
    Private ReadOnly HostForm As Object
    Public ReadOnly Insieme As Object
    Public Dummy As Boolean
    Public Sub New(ByVal host As Object, ByVal Padre As Object)
        MyBase.new()
        HostForm = host
        Insieme = Padre
    End Sub
    Protected Overrides Sub OnCheckStateChanged(ByVal e As System.EventArgs)
        HostForm.Check_CheckStateChanged(Name)
    End Sub
End Class
Public Class CheckArray
    Inherits System.Collections.CollectionBase
    Private ReadOnly HostForm As Object
    Private ReadOnly PrefixName As String
    Private ReadOnly Quadro As Object
    Public Sub New(ByVal host As Object, ByVal q As Object, ByVal P As String)
        MyBase.New()
        HostForm = host
        PrefixName = P
        Quadro = q
        Dim i As Integer
        For i = 0 To q.Controls.Count - 1
            If q.Controls(i).Name = PrefixName & "_0" Then
                Dim l As CheckBox = CType(q.Controls(i), CheckBox)
                Dim al As arrCheck = New arrCheck(host, Me)
                al.Tag = 0
                al.Name = l.Name
                al.Size = l.Size
                al.Location = l.Location
                al.Font = l.Font
                al.Text = l.Text
                al.BackColor = l.BackColor
                al.ForeColor = l.ForeColor
                al.Dummy = False
                al.Visible = l.Visible
                List.Add(al)
                Quadro.Controls.Add(al)
                l.Visible = False
                Exit Sub
            End If
        Next
    End Sub
    Default Public ReadOnly Property Item(ByVal Index As Integer) As arrCheck
        Get
            If Index < List.Count Then
                Return CType(List.Item(Index), arrCheck)
            Else
                Return Nothing
            End If
        End Get
    End Property
    Public Sub UnLoad(ByVal Index As Integer)
        If Index > Count - 1 Then Exit Sub
        Me.Item(Index).Dispose()
        Quadro.Controls.Remove(Me(Index))
        Me.List.RemoveAt(Index)
    End Sub
    Public Sub Remove()
        ' Check to be sure there is a button to remove.
        If Me.Count > 0 Then
            Me.Item(Me.Count - 1).Dispose()
            Quadro.Controls.Remove(Me(Me.Count - 1))
            Me.List.RemoveAt(Me.Count - 1)
        End If
    End Sub
    Public Sub RemoveAll(Optional ByVal i As Integer = 0)
        Do While Count > i
            Remove()
        Loop
    End Sub
    Public Function Load(ByVal Index As Integer) As arrCheck
        Dim i As Integer
        If Index >= Count Then
            For i = Count To Index - 1
                AddNewTextBox(True)
            Next
            Return AddNewTextBox(False)
        Else
            CType(list(Index), arrCheck).Visible = True
            Return CType(list(Index), arrCheck)
        End If
    End Function
    Public Function AddNewTextBox(ByVal d As Boolean) As arrCheck
        Dim aButton As New arrCheck(HostForm, Me)
        Me.List.Add(aButton)
        Quadro.Controls.Add(aButton)
        aButton.Tag = Me.Count - 1
        aButton.Name = PrefixName & "_" & CStr(aButton.Tag).Trim
        aButton.Visible = False
        aButton.Size = CType(list(0), arrCheck).Size
        aButton.Location = CType(list(0), arrCheck).Location
        aButton.Font = CType(list(0), arrCheck).Font
        aButton.Text = CType(list(0), arrCheck).Text
        aButton.BackColor = CType(list(0), arrCheck).BackColor
        aButton.ForeColor = CType(list(0), arrCheck).ForeColor
        aButton.Dummy = d
        Return aButton
    End Function
End Class
Public Class arrSuGiu
    Inherits System.Windows.Forms.NumericUpDown
    Private ReadOnly HostForm As Object
    Public ReadOnly Insieme As Object
    Public Dummy As Boolean
    Public Sub New(ByVal host As Object, ByVal Padre As Object)
        MyBase.new()
        HostForm = host
        Insieme = Padre
    End Sub
    Public Overrides Sub DownButton()
        Try
            HostForm.UpDown_ButtonDown(Name)
        Catch
        End Try
    End Sub
    Public Overrides Sub UpButton()
        Try
            HostForm.UpDown_ButtonUp(Name)
        Catch
        End Try
    End Sub
End Class
Public Class UpDownArray
    Inherits System.Collections.CollectionBase
    Private ReadOnly HostForm As Object
    Private ReadOnly PrefixName As String
    Private ReadOnly Quadro As Object
    Public Sub New(ByVal host As Object, ByVal q As Object, ByVal P As String)
        MyBase.New()
        HostForm = host
        PrefixName = P
        Quadro = q
        Dim i As Integer
        For i = 0 To q.Controls.Count - 1
            If q.Controls(i).Name = PrefixName & "_0" Then
                Dim l As NumericUpDown = CType(q.Controls(i), NumericUpDown)
                Dim al As arrSuGiu = New arrSuGiu(host, Me)
                al.Tag = 0
                al.Name = l.Name
                al.Size = l.Size
                al.Location = l.Location
                al.Font = l.Font
                al.Text = l.Text
                al.BackColor = l.BackColor
                al.ForeColor = l.ForeColor
                al.Dummy = False
                al.Visible = l.Visible
                List.Add(al)
                Quadro.Controls.Add(al)
                l.Visible = False
                Exit Sub
            End If
        Next
    End Sub
    Default Public ReadOnly Property Item(ByVal Index As Integer) As arrSuGiu
        Get
            If Index < List.Count Then
                Return CType(List.Item(Index), arrSuGiu)
            Else
                Return Nothing
            End If
        End Get
    End Property
    Public Sub UnLoad(ByVal Index As Integer)
        If Index > Count - 1 Then Exit Sub
        Me.Item(Index).Dispose()
        Quadro.Controls.Remove(Me(Index))
        Me.List.RemoveAt(Index)
    End Sub
    Public Sub Remove()
        ' Check to be sure there is a button to remove.
        If Me.Count > 0 Then
            Me.Item(Me.Count - 1).Dispose()
            Quadro.Controls.Remove(Me(Me.Count - 1))
            Me.List.RemoveAt(Me.Count - 1)
        End If
    End Sub
    Public Sub RemoveAll(Optional ByVal i As Integer = 0)
        Do While Count > i
            Remove()
        Loop
    End Sub
    Public Function Load(ByVal Index As Integer) As arrSuGiu
        Dim i As Integer
        If Index >= Count Then
            For i = Count To Index - 1
                AddNewUpDown(True)
            Next
            Return AddNewUpDown(False)
        Else
            CType(list(Index), arrSuGiu).Visible = True
            Return CType(list(Index), arrSuGiu)
        End If
    End Function
    Public Function AddNewUpDown(ByVal d As Boolean) As arrSuGiu
        Dim aButton As New arrSuGiu(HostForm, Me)
        Me.List.Add(aButton)
        Quadro.Controls.Add(aButton)
        aButton.Tag = Me.Count - 1
        aButton.Name = PrefixName & "_" & CStr(aButton.Tag).Trim
        aButton.Visible = False
        aButton.Size = CType(list(0), arrSuGiu).Size
        aButton.Location = CType(list(0), arrSuGiu).Location
        aButton.Font = CType(list(0), arrSuGiu).Font
        aButton.Text = CType(list(0), arrSuGiu).Text
        aButton.BackColor = CType(list(0), arrSuGiu).BackColor
        aButton.ForeColor = CType(list(0), arrSuGiu).ForeColor
        aButton.Dummy = d
        Return aButton
    End Function
End Class
