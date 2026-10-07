Imports System.Drawing
Imports System.IO
Imports System.Windows.Forms

' Diagnostic only: never changes layout or engineering data.
Friend NotInheritable Class LegacyTextLayoutAudit
    Private Shared auditTimer As Timer
    Private Shared reportPath As String
    Private Shared ReadOnly seen As New System.Collections.Generic.HashSet(Of String)

    Public Shared Sub StartFromEnvironment()
        reportPath = Environment.GetEnvironmentVariable("LANCIO_TEXT_LAYOUT_REPORT")
        If String.IsNullOrWhiteSpace(reportPath) Then Return
        Try
            reportPath = Path.GetFullPath(reportPath)
            Directory.CreateDirectory(Path.GetDirectoryName(reportPath))
            File.WriteAllText(reportPath, "Form,Control,Text,Issue,Available,Required,DPI" & Environment.NewLine)
            auditTimer = New Timer With {.Interval = 1000}
            AddHandler auditTimer.Tick, AddressOf Scan
            AddHandler Application.ApplicationExit, Sub(sender, args) auditTimer.Dispose()
            auditTimer.Start()
        Catch ex As Exception
            System.Diagnostics.Trace.WriteLine("Text layout audit: " & ex.Message)
        End Try
    End Sub

    Private Shared Sub Scan(sender As Object, args As EventArgs)
        Try
            For Each window As Form In Application.OpenForms
                Visit(window, window)
            Next
        Catch ex As Exception
            System.Diagnostics.Trace.WriteLine("Text layout audit: " & ex.Message)
        End Try
    End Sub

    Private Shared Sub Visit(window As Form, control As Control)
        If Not control.Visible Then Return
        If (TypeOf control Is Label OrElse TypeOf control Is ButtonBase) AndAlso control.Text.Length > 0 Then
            Dim required = control.GetPreferredSize(New Size(control.Width, 0))
            If required.Width > control.Width + 2 OrElse required.Height > control.Height + 2 Then
                Record(window, control.Name, control.Text, "Possible clipped text", control.Size, required)
            End If
        End If
        If control.Parent IsNot Nothing AndAlso Not TypeOf control.Parent Is ScrollableControl AndAlso
           (control.Right > control.Parent.ClientSize.Width OrElse control.Bottom > control.Parent.ClientSize.Height) Then
            Record(window, control.Name, control.Text, "Outside parent bounds", control.Size, control.GetPreferredSize(Size.Empty))
        End If
        Dim strip = TryCast(control, ToolStrip)
        If strip IsNot Nothing Then VisitItems(window, strip.Items)
        For Each child As Control In control.Controls
            Visit(window, child)
        Next
    End Sub

    Private Shared Sub VisitItems(window As Form, items As ToolStripItemCollection)
        For Each item As ToolStripItem In items
            If item.Available AndAlso item.Text.Length > 0 AndAlso
               (item.DisplayStyle And ToolStripItemDisplayStyle.Text) <> 0 Then
                Dim required = item.GetPreferredSize(Size.Empty)
                If item.Visible AndAlso (required.Width > item.Width + 2 OrElse required.Height > item.Height + 2) Then
                    Record(window, item.Name, item.Text, "Possible clipped menu text", item.Size, required)
                End If
            End If
            Dim dropdown = TryCast(item, ToolStripDropDownItem)
            If dropdown IsNot Nothing AndAlso dropdown.DropDown.Visible Then VisitItems(window, dropdown.DropDownItems)
        Next
    End Sub

    Private Shared Function Csv(value As String) As String
        Return """" & value.Replace("""", """""") & """"
    End Function

    Private Shared Sub Record(window As Form, name As String, caption As String, issue As String, available As Size, required As Size)
        Dim row = String.Join(",", {Csv(window.GetType().FullName), Csv(name), Csv(caption), Csv(issue),
                                  Csv(available.ToString()), Csv(required.ToString()), window.DeviceDpi.ToString()})
        If seen.Add(row) Then File.AppendAllText(reportPath, row & Environment.NewLine)
    End Sub
End Class
