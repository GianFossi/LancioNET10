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
        ' Construct representative migrated forms without triggering Load/database workflows.
        For Each assemblyAndForms In New (Reflection.Assembly, String())() {
            (GetType(LibMat.clsBWG).Assembly, {"LibMat.frmGuarn", "LibMat.frmTira", "LibMat.frmUpdate"}),
            (GetType(Grafica.LibGra).Assembly, {"Grafica.frmForature", "Grafica.frmFlange", "Grafica.FormRibs"}),
            (GetType(DataSheet.clsDataSheet).Assembly, {"DataSheet.DataShe1", "DataSheet.DataShe2", "DataSheet.DataShee"})}
            For Each name In assemblyAndForms.Item2
                Dim formType = assemblyAndForms.Item1.GetType(name, throwOnError:=True)
                Dim instance As Object
                If name.StartsWith("LibMat.", StringComparison.Ordinal) OrElse name = "Grafica.frmFlange" Then
                    instance = Activator.CreateInstance(formType, Reflection.BindingFlags.Instance Or Reflection.BindingFlags.Public Or Reflection.BindingFlags.NonPublic,
                        binder:=Nothing, args:=New Object() {False}, culture:=Nothing)
                Else
                    instance = Activator.CreateInstance(formType, nonPublic:=True)
                End If
                Using form = DirectCast(instance, Form)
                    Dim arrays = formType.GetFields().Where(Function(field) field.FieldType.IsGenericType AndAlso
                        field.FieldType.GetGenericTypeDefinition() = GetType(Dictionary(Of ,))).ToArray()
                    Check(arrays.Length > 0)
                    For Each field In arrays
                        Dim controls = DirectCast(field.GetValue(form), System.Collections.IDictionary)
                        Check(controls.Count > 0)
                        For Each control In controls.Values
                            Check(DirectCast(control, Control).Parent IsNot Nothing)
                        Next
                    Next
                End Using
            Next
        Next
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
                Dim previousSerialization = Environment.GetEnvironmentVariable("LANCIO_ENABLE_LEGACY_BINARY_FORMATTER")
                Try
                    Environment.SetEnvironmentVariable("LANCIO_ENABLE_LEGACY_BINARY_FORMATTER", Nothing)
                    Dim motore As New RoutBase1.clsMotore("file-gate-smoke")
                    motore.Inizio.Workdir = folder
                    Dim job As New RoutBase1.clsjob(motore) With {.Contratto = "must-not-create"}
                    Try
                        job.Salva()
                        Throw New Exception("Disabled serialization did not fail before job file creation.")
                    Catch ex As System.Runtime.Serialization.SerializationException
                        Check(Not IO.File.Exists(IO.Path.Combine(folder, "must-not-create.JOB")))
                    End Try
                Finally
                    Environment.SetEnvironmentVariable("LANCIO_ENABLE_LEGACY_BINARY_FORMATTER", previousSerialization)
                End Try
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
