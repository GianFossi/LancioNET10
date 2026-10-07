Option Strict On
Imports System.Collections.Generic
Imports System.Windows.Forms

' Storage is a normal Dictionary; event subscriptions belong to the form.
Friend Module IndexedControls
    Public Function IndexOf(Of T As Class)(controls As Dictionary(Of Integer, T), sender As Object) As Short
        For Each pair In controls
            If Object.ReferenceEquals(pair.Value, sender) Then Return CShort(pair.Key)
        Next
        Throw New ArgumentException("The event sender is not registered in this control collection.")
    End Function

    Public Sub AddClone(Of T As {Control, New})(controls As Dictionary(Of Integer, T), index As Integer)
        If controls.ContainsKey(index) Then Throw New ArgumentException("Duplicate control index: " & index)
        Dim template = controls(0)
        If template.Parent Is Nothing Then Throw New InvalidOperationException("The template control has no parent.")
        Dim child As New T With {
            .Name = template.Name & "_" & index.ToString(Globalization.CultureInfo.InvariantCulture),
            .Size = template.Size, .Location = template.Location,
            .Font = template.Font, .ForeColor = template.ForeColor,
            .BackColor = template.BackColor, .Enabled = template.Enabled,
            .TabStop = template.TabStop, .TabIndex = template.TabIndex,
            .Anchor = template.Anchor, .Dock = template.Dock,
            .Cursor = template.Cursor, .RightToLeft = template.RightToLeft,
            .Padding = template.Padding, .Margin = template.Margin, .Tag = template.Tag,
            .Text = template.Text, .Visible = False}
        If TypeOf template Is TextBox Then
            Dim source = DirectCast(DirectCast(template, Control), TextBox)
            Dim target = DirectCast(DirectCast(child, Control), TextBox)
            target.Multiline = source.Multiline
            target.MaxLength = source.MaxLength
            target.ReadOnly = source.ReadOnly
            target.ScrollBars = source.ScrollBars
            target.TextAlign = source.TextAlign
            target.BorderStyle = source.BorderStyle
            target.CharacterCasing = source.CharacterCasing
        ElseIf TypeOf template Is ComboBox Then
            Dim source = DirectCast(DirectCast(template, Control), ComboBox)
            Dim target = DirectCast(DirectCast(child, Control), ComboBox)
            target.DropDownStyle = source.DropDownStyle
            target.MaxLength = source.MaxLength
            target.Sorted = source.Sorted
            target.Items.AddRange(source.Items.Cast(Of Object)().ToArray())
        ElseIf TypeOf template Is ButtonBase Then
            Dim source = DirectCast(DirectCast(template, Control), ButtonBase)
            Dim target = DirectCast(DirectCast(child, Control), ButtonBase)
            target.FlatStyle = source.FlatStyle
            target.TextAlign = source.TextAlign
            target.Image = source.Image
            target.ImageAlign = source.ImageAlign
            target.UseVisualStyleBackColor = source.UseVisualStyleBackColor
            target.UseMnemonic = source.UseMnemonic
            If TypeOf template Is CheckBox Then
                Dim sourceCheck = DirectCast(DirectCast(template, Control), CheckBox)
                Dim targetCheck = DirectCast(DirectCast(child, Control), CheckBox)
                targetCheck.ThreeState = sourceCheck.ThreeState
                targetCheck.AutoCheck = sourceCheck.AutoCheck
                targetCheck.CheckAlign = sourceCheck.CheckAlign
                targetCheck.CheckState = sourceCheck.CheckState
            ElseIf TypeOf template Is RadioButton Then
                Dim sourceRadio = DirectCast(DirectCast(template, Control), RadioButton)
                Dim targetRadio = DirectCast(DirectCast(child, Control), RadioButton)
                targetRadio.AutoCheck = sourceRadio.AutoCheck
                targetRadio.CheckAlign = sourceRadio.CheckAlign
                ' A newly loaded choice starts unchecked; selection is assigned by the form.
                targetRadio.Checked = False
            End If
        ElseIf TypeOf template Is Label Then
            Dim source = DirectCast(DirectCast(template, Control), Label)
            Dim target = DirectCast(DirectCast(child, Control), Label)
            target.AutoSize = source.AutoSize
            target.BorderStyle = source.BorderStyle
            target.TextAlign = source.TextAlign
        End If
        controls.Add(index, child)
        template.Parent.Controls.Add(child)
    End Sub
End Module
