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
        Dim wrcbType = System.Reflection.Assembly.Load("Wrcb").GetType("Wrcb.Apert", throwOnError:=True)
        Using form = DirectCast(Activator.CreateInstance(wrcbType, nonPublic:=True), Form)
            Dim status = DirectCast(wrcbType.GetField("StatusBar1", Reflection.BindingFlags.Instance Or Reflection.BindingFlags.NonPublic).GetValue(form), StatusStrip)
            If status.Items.Count <> 3 OrElse Not form.Controls.Contains(status) Then Throw New Exception("WRCB status fields missing")
            If Not DirectCast(status.Items(0), ToolStripStatusLabel).Spring Then Throw New Exception("WRCB workspace panel must fill available space")
            status.Items(1).Text = "Prev.: smoke"
            If status.Items(1).Text <> "Prev.: smoke" Then Throw New Exception("WRCB status text update failed")
        End Using
        Console.WriteLine("Main and ASME menu construction checks passed (forms not shown, calculations not executed).")
    End Sub
End Module
