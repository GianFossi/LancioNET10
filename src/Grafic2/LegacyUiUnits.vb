Option Strict On
Friend Module LegacyUiUnits
    Public Function TwipsToPixelsX(value As Double) As Double
        Using graphics = System.Drawing.Graphics.FromHwnd(IntPtr.Zero)
            Return value * graphics.DpiX / 1440.0
        End Using
    End Function
    Public Function TwipsToPixelsY(value As Double) As Double
        Using graphics = System.Drawing.Graphics.FromHwnd(IntPtr.Zero)
            Return value * graphics.DpiY / 1440.0
        End Using
    End Function
    Public Function PixelsToTwipsX(value As Double) As Double
        Using graphics = System.Drawing.Graphics.FromHwnd(IntPtr.Zero)
            Return value * 1440.0 / graphics.DpiX
        End Using
    End Function
    Public Function PixelsToTwipsY(value As Double) As Double
        Using graphics = System.Drawing.Graphics.FromHwnd(IntPtr.Zero)
            Return value * 1440.0 / graphics.DpiY
        End Using
    End Function
    ' These calls are diagnostic output only, not calculation inputs.
    Public Function TabLayout(ParamArray values As Object()) As String
        Return String.Join(vbTab, values.Select(Function(value) System.Convert.ToString(value, Globalization.CultureInfo.CurrentCulture)))
    End Function
End Module
