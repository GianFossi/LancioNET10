Option Strict On
Imports System.Reflection
Imports System.Runtime.ExceptionServices

' Keep the original API and delegate every calculation to the supplied library.
' No approximation of steam properties is introduced here.
Namespace Global.XSteam
    Public NotInheritable Class clsXSteam
        Public Shared Function XSteam(functionName As String, ParamArray inputs As Double()) As Double
            Dim path = Environment.GetEnvironmentVariable("LANCIO_XSTEAM_DLL")
            If String.IsNullOrWhiteSpace(path) OrElse Not IO.File.Exists(path) Then
                Throw New IO.FileNotFoundException("La libreria originale XSteam manca. Impostare LANCIO_XSTEAM_DLL sul percorso della DLL verificata; nessuna proprieta' del vapore viene approssimata.", path)
            End If
            Dim assembly = Reflection.Assembly.LoadFrom(IO.Path.GetFullPath(path))
            If assembly Is GetType(clsXSteam).Assembly Then Throw New InvalidOperationException("LANCIO_XSTEAM_DLL deve indicare la libreria originale, non l'adapter.")
            Dim libraryType = assembly.GetType("XSteam.clsXSteam", throwOnError:=True)
            Dim arguments As New List(Of Object) From {functionName}
            arguments.AddRange(inputs.Select(Function(value) DirectCast(value, Object)))
            Try
                Dim result = libraryType.InvokeMember("XSteam", BindingFlags.Public Or BindingFlags.Static Or BindingFlags.InvokeMethod Or BindingFlags.OptionalParamBinding,
                    binder:=Nothing, target:=Nothing, args:=arguments.ToArray(), culture:=Globalization.CultureInfo.InvariantCulture)
                If Not TypeOf result Is Double AndAlso Not TypeOf result Is Single Then Throw New InvalidOperationException("La libreria XSteam non restituisce il tipo numerico originale previsto.")
                Return System.Convert.ToDouble(result, Globalization.CultureInfo.InvariantCulture)
            Catch ex As TargetInvocationException When ex.InnerException IsNot Nothing
                ExceptionDispatchInfo.Capture(ex.InnerException).Throw()
                Throw
            End Try
        End Function
    End Class
End Namespace
