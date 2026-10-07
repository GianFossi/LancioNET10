Option Strict On
Imports System.Globalization

Module Program
    Private checks As Integer
    Sub Main(args As String())
        If args.Length > 0 AndAlso args(0) = "--check" Then
            Characterize()
            Console.WriteLine($"PASS: {checks} original ASME cylinder routine characterization checks.")
            Return
        End If
        If args.Length <> 0 AndAlso args.Length <> 5 Then
            Throw New ArgumentException("Pass pressure radius stress efficiency radiusConvention, or --check, or omit all arguments.")
        End If
        Dim values As Single() = {2.0F, 500.0F, 138.0F, 0.85F, 0.0F}
        For i = 0 To args.Length - 1
            values(i) = Single.Parse(args(i), CultureInfo.InvariantCulture)
        Next
        Dim pressure = values(0), radius = values(1), stress = values(2), efficiency = values(3), convention = values(4)
        Dim temperature As Single = 20, thickness As Single = 0, kz As Single = 0
        LegacyAsmeSlice.Configure(convention)
        Console.WriteLine("Original legacy ASME cylinder routines. Demonstration only, not a design approval.")
        Console.WriteLine(FormattableString.Invariant($"Inputs (consistent MPa/mm for this example): P={pressure}, R={radius}, S={stress}, E={efficiency}, SWR={convention}"))
        ' Break here and press F11: PDB maps to legacy/AsmeVip.NET/Calcoli.vb.
        LegacyAsmeSlice.CylThk(pressure, temperature, thickness, radius, kz, stress, efficiency, convention)
        Dim thicknessClause = LegacyAsmeSlice.USStr(0)
        Dim calculatedPressure As Single = 0, z As Single = 0
        ' Configure sets the module SWR separately: ASME1 uses that global, not the CylPres parameter.
        LegacyAsmeSlice.CylPres(calculatedPressure, thickness, radius, z, stress, efficiency, convention)
        Console.WriteLine(FormattableString.Invariant($"Outputs: t={thickness:R}, thickness branch={thicknessClause}, pressure={calculatedPressure:R}, pressure branch={LegacyAsmeSlice.USStr(1)}, Z={z:R}"))
        Console.WriteLine("Captured legacy errors: " & String.Join(",", LegacyAsmeSlice.ErrorCodes))
        For Each message In LegacyAsmeSlice.Messages
            Console.WriteLine("Captured UI error: " & message)
        Next
    End Sub

    Private Sub Characterize()
        ' Independent inverse checks for representative thin/thick and radius branches.
        For Each convention In {0.0F, 1.0F}
            For Each inputPressure In {2.0F, 60.0F}
                LegacyAsmeSlice.Configure(convention)
                Dim pressure = inputPressure, radius As Single = 500, stress As Single = 138
                Dim efficiency As Single = 0.85F, temperature As Single = 20, thickness As Single = 0, kz As Single = 0
                LegacyAsmeSlice.CylThk(pressure, temperature, thickness, radius, kz, stress, efficiency, convention)
                Dim se = CDbl(stress) * efficiency
                Dim expected As Double
                If pressure > 0.385 * se Then
                    Dim ratio = Math.Sqrt((se + pressure) / (se - pressure))
                    expected = If(convention > 0, radius * (ratio - 1) / ratio, radius * (ratio - 1))
                    Equal("1-2", LegacyAsmeSlice.USStr(0).Trim())
                Else
                    expected = If(convention > 0, pressure * radius / (se + 0.4 * pressure), pressure * radius / (se - 0.6 * pressure))
                    Equal(If(convention > 0, "1-1", "UG-27(c)"), LegacyAsmeSlice.USStr(0).Trim())
                End If
                Near(expected, thickness, 0.0002)
                Dim inverse As Single = 0, z As Single = 0
                LegacyAsmeSlice.CylPres(inverse, thickness, radius, z, stress, efficiency, convention)
                Near(inputPressure, inverse, 0.00005)
                Equal("0", LegacyAsmeSlice.ErrorCodes.Count.ToString(CultureInfo.InvariantCulture))
            Next
        Next
        LegacyAsmeSlice.Configure(0)
        Dim p As Single = 2, td As Single = 20, t As Single = 0, r As Single = 500, k As Single = 0, s As Single = 138, e As Single = 0, swr As Single = 0
        LegacyAsmeSlice.CylThk(p, td, t, r, k, s, e, swr)
        Near(1, e, 0) ' Original E=0 default is a side effect, not input validation.
        LegacyAsmeSlice.Configure(0)
        p = 138 : e = 1 : t = -1
        LegacyAsmeSlice.CylThk(p, td, t, r, k, s, e, swr)
        Near(0, t, 0)
        Equal("20", String.Join(",", LegacyAsmeSlice.ErrorCodes))
        LegacyAsmeSlice.Configure(0, mawpMode:=1)
        p = 138 : e = 1
        LegacyAsmeSlice.CylThk(p, td, t, r, k, s, e, swr)
        Near(1.8, p, 0.00001) ' Suspicious historical reset retained for investigation.
        ' Preserve and expose the hidden-global dependency rather than silently fixing it.
        LegacyAsmeSlice.Configure(0)
        Dim out1 As Single = 0, z1 As Single = 0, out2 As Single = 0, z2 As Single = 0
        t = 10 : e = 0.85F : swr = 0
        LegacyAsmeSlice.CylPres(out1, t, r, z1, s, e, swr)
        swr = 1
        LegacyAsmeSlice.CylPres(out2, t, r, z2, s, e, swr)
        Near(out1, out2, 0) ' CylPres argument SWR does not update the module's SWR.
    End Sub
    Private Sub Near(expected As Double, actual As Double, tolerance As Double)
        If Not Double.IsFinite(actual) OrElse Math.Abs(expected - actual) > tolerance Then
            Throw New Exception($"Expected {expected}, got {actual}, tolerance {tolerance}.")
        End If
        checks += 1
    End Sub
    Private Sub Equal(expected As String, actual As String)
        If expected <> actual Then Throw New Exception($"Expected '{expected}', got '{actual}'.")
        checks += 1
    End Sub
End Module
