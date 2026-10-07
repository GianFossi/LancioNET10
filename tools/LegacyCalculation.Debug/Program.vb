Imports System.Globalization
Imports RoutBase1

' Windows-only debug entry point into the actual legacy implementation.
Module Program
    <STAThread>
    Sub Main(args As String())
        If args.Length <> 0 AndAlso args.Length <> 5 Then
            Throw New ArgumentException("Pass X x1 x2 y1 y2 using a decimal point, or omit all arguments.")
        End If
        Dim values As Single() = {10.0F, 1.0F, 100.0F, 100.0F, 400.0F}
        For i = 0 To args.Length - 1
            values(i) = Single.Parse(args(i), CultureInfo.InvariantCulture)
        Next
        Dim routines As New clsTrigon()
        Dim x = values(0), x1 = values(1), x2 = values(2), y1 = values(3), y2 = values(4)
        Console.WriteLine("Legacy clsTrigon.InterLogar: place a breakpoint on the call below, then use Step Into.")
        Console.WriteLine(FormattableString.Invariant($"Inputs: X={x}, x1={x1}, x2={x2}, y1={y1}, y2={y2}"))
        ' Break here; the debugger enters src/RoutBase/clsTrigon.vb unchanged math.
        Dim result = routines.InterLogar(x, x1, x2, y1, y2)
        Console.WriteLine(FormattableString.Invariant($"Legacy result (Single): {result:R}"))
        If args.Length = 0 AndAlso Math.Abs(result - 200.0F) > 0.001F Then
            Throw New Exception("The demonstration interpolation did not match its known mathematical midpoint.")
        End If
        Console.WriteLine("This is a calculation harness, not the complete application or an engineering design validation.")
    End Sub
End Module
