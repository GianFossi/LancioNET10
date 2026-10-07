Option Strict On

Friend Module ScreenUnits
    Public Function TwipsToPixels(value As Double, horizontal As Boolean) As Double
        Using graphics = System.Drawing.Graphics.FromHwnd(IntPtr.Zero)
            Return value * If(horizontal, graphics.DpiX, graphics.DpiY) / 1440.0
        End Using
    End Function
End Module
