Imports System.Collections
Imports System.Globalization
Imports FormulaParser

Module Program
    Sub Main()
        Dim count As Integer = 0
        Dim original = CultureInfo.CurrentCulture
        Try
            For Each culture In {"it-IT", "en-US"}
                CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo(culture)
                Dim cases As (Expression As String, Expected As Double)() = {
                    ("1+2*3", 7), ("(1+2)*3", 9), ("10-4", 6),
                    ("12/3", 4), ("2^3", 8), ("sqrt(9)", 3),
                    ("abs(-4)", 4), ("5!", 120), ("sin(0)", 0),
                    ("pi", Math.PI)
                }
                For Each item In cases
                    Check(item.Expression, item.Expected)
                    count += 1
                Next
                Dim separator = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator
                Check("1" & separator & "5+2", 3.5)
                count += 1
            Next
        Finally
            CultureInfo.CurrentCulture = original
        End Try
        Console.WriteLine($"PASS: {count} FormulaParser checks (it-IT, en-US).")
    End Sub

    Private Sub Check(expression As String, expected As Double)
        ' Do not use evaluate's legacy MsgBox catch: expose parser errors to CI.
        Dim parser As New mcCalc()
        Dim tokens As Queue = Nothing
        If Not parser.calc_scan(expression, tokens) Then
            Throw New Exception($"Tokenization failed: {expression}")
        End If
        Dim actual = parser.level0(tokens)
        If Double.IsNaN(actual) OrElse Double.IsInfinity(actual) OrElse
           Math.Abs(actual - expected) > 0.0000000001 OrElse tokens.Count <> 0 Then
            Throw New Exception($"{CultureInfo.CurrentCulture.Name}: {expression}: expected {expected}, actual {actual}, remaining tokens {tokens.Count}")
        End If
    End Sub
End Module
