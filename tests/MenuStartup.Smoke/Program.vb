Imports System.Windows.Forms
Module Program
    <STAThread>
    Sub Main()
        Dim mainType = System.Reflection.Assembly.Load("Lancio").GetType("Lancio.Form1", throwOnError:=True)
        Using form = DirectCast(Activator.CreateInstance(mainType, nonPublic:=True), Form)
            If form.MainMenuStrip Is Nothing OrElse form.MainMenuStrip.Items.Count = 0 Then Throw New Exception("Main menu missing")
            If Not form.Controls.Contains(form.MainMenuStrip) Then Throw New Exception("Menu not attached")
            Dim commands = DirectCast(mainType.GetField("mnuTerm").GetValue(form), System.Collections.IDictionary)
            If commands.Count <> 6 Then Throw New Exception("Indexed commands changed")
            If Not Object.ReferenceEquals(commands(0), mainType.GetField("_mnuTerm_0").GetValue(form)) Then Throw New Exception("Menu identity changed")
        End Using
        Dim asmeType = System.Reflection.Assembly.Load("AsmeVip").GetType("AsmeVip.Apert", throwOnError:=True)
        Using form = DirectCast(Activator.CreateInstance(asmeType, nonPublic:=True), Form)
            If form.MainMenuStrip Is Nothing OrElse form.MainMenuStrip.Items.Count = 0 Then Throw New Exception("ASME menu missing")
        End Using
        Console.WriteLine("Main and ASME menu construction checks passed (forms not shown, calculations not executed).")
    End Sub
End Module
