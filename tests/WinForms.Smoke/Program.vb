Imports System.Collections.Generic
Imports System.Windows.Forms

Module Program
    Private count As Integer
    <STAThread>
    Sub Main()
        Using parent As New Panel(), template As New TextBox() With {.Text = "base", .Multiline = True, .MaxLength = 24}
            parent.Controls.Add(template)
            Dim controls As New Dictionary(Of Integer, TextBox) From {{0, template}}
            IndexedControls.AddClone(controls, 7)
            Check(controls(7).Text = "base" AndAlso controls(7).Multiline AndAlso controls(7).MaxLength = 24)
            Check(Object.ReferenceEquals(parent, controls(7).Parent))
            Check(IndexedControls.IndexOf(controls, controls(7)) = 7)
            Dim events As New List(Of Short)()
            AddHandler controls(7).TextChanged, Sub(sender, e) events.Add(IndexedControls.IndexOf(controls, sender))
            controls(7).Text = "edited"
            Check(events.Count = 1 AndAlso events(0) = 7)
            Try
                IndexedControls.AddClone(controls, 7)
                Throw New Exception("Duplicate index accepted.")
            Catch ex As ArgumentException
                Check(controls.Count = 2 AndAlso parent.Controls.Count = 2)
            End Try
        End Using
        Using form As New RoutBase1.frmInput()
            Check(form.Text1.ContainsKey(0) AndAlso form.Command1.Count = 3)
        End Using
        Using form As New RoutBase1.frmQuale()
            Check(form.Option1.ContainsKey(0) AndAlso form.Command1.Count = 3)
        End Using
        Using form As New RoutBase1.frmCheck()
            Check(form.Check1.ContainsKey(0))
        End Using
        Dim aboutType = GetType(RoutBase1.frmInput).Assembly.GetType("RoutBase1.frmAbout", throwOnError:=True)
        Using form = DirectCast(Activator.CreateInstance(aboutType, nonPublic:=True), Form)
            Dim lines = DirectCast(aboutType.GetField("Line1").GetValue(form), Dictionary(Of Integer, Label))
            Check(lines.Count > 0)
        End Using
        Dim folder = IO.Path.Combine(IO.Path.GetTempPath(), "LancioWinFormsSmoke-" & Guid.NewGuid().ToString("N"))
        IO.Directory.CreateDirectory(IO.Path.Combine(folder, "child"))
        IO.File.WriteAllText(IO.Path.Combine(folder, "sample.txt"), "test")
        Try
            Dim optionsType = GetType(RoutBase1.frmInput).Assembly.GetType("RoutBase1.frmOpzioni", throwOnError:=True)
            Using form = DirectCast(Activator.CreateInstance(optionsType, nonPublic:=True), Form)
                optionsType.GetMethod("ShowDirectory", Reflection.BindingFlags.NonPublic Or Reflection.BindingFlags.Instance).Invoke(form, {folder})
                Dim directories = DirectCast(optionsType.GetProperty("dirList").GetValue(form), ListBox)
                Dim files = DirectCast(optionsType.GetProperty("filList").GetValue(form), ListBox)
                Check(directories.Items.Contains(IO.Path.Combine(folder, "child")))
                Check(files.Items.Contains("sample.txt"))
            End Using
        Finally
            IO.Directory.Delete(folder, recursive:=True)
        End Try
        Console.WriteLine($"PASS: {count} Windows control collection/form construction checks.")
        Console.WriteLine("NOT RUN: full application workflows, Office/AutoCAD or real database operations.")
    End Sub
    Private Sub Check(condition As Boolean)
        If Not condition Then Throw New Exception("WinForms check failed.")
        count += 1
    End Sub
End Module
