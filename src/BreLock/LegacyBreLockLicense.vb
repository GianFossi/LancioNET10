Option Strict Off
Imports System.Reflection
Friend Module LegacyBreLockLicense
    Public Function ValidateLicense(parameters As String, licenseFile As String, Optional applicationName As String = "BreLock", Optional variableName As String = "LANCIO_BRELOCK_LICENSE_DLL") As Boolean
        Dim path = Environment.GetEnvironmentVariable(variableName)
        If String.IsNullOrWhiteSpace(path) OrElse Not IO.File.Exists(path) Then
            MessageBox.Show("Manca il provider originale Infralution.Licensing. Impostare " & variableName & " sulla DLL della propria installazione. La licenza non puo' essere verificata.", applicationName)
            Return False
        End If
        Try
            Dim assembly = Reflection.Assembly.LoadFrom(IO.Path.GetFullPath(path))
            Dim provider = Activator.CreateInstance(assembly.GetType("Infralution.Licensing.EncryptedLicenseProvider", throwOnError:=True))
            Dim license As Object = provider.GetLicense(parameters, licenseFile)
            If license Is Nothing Then
                Dim form = Activator.CreateInstance(assembly.GetType("Infralution.Licensing.LicenseInstallForm", throwOnError:=True))
                Try
                    license = form.ShowDialog(applicationName, "www.ssap.biz", licenseFile)
                Finally
                    If TypeOf form Is IDisposable Then DirectCast(form, IDisposable).Dispose()
                End Try
            End If
            Return license IsNot Nothing
        Catch ex As Exception
            MessageBox.Show("Errore del provider di licenza originale: " & ex.Message, applicationName)
            Return False
        End Try
    End Function
End Module
