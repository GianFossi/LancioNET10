Option Strict Off
Option Explicit On
Friend Class wn_Tub
	Public UW20ac As Single
	Public UW20af As Single
	Public UW20ag As Single
	Public UW20ar As Single
	Public UW20Fdstrength As Single
	Public UW20Fdratio As Single
	Public UW20Ffstrength As Single
	Public UW20Ffratio As Single
	Public UW20Fgstrength As Single
	Public UW20Ftstrength As Single
	Public UW20fw As Single
	Public UW20Sw As Single
	Public Calcolato As Boolean
	Public lKlato, lJinvolucr As Short
    Public Sub New()
        MyBase.New()
        lKlato = kLato
        lJinvolucr = jInvolucr
    End Sub
    Public Function Calcola() As Single
        Dim Testo As String
        Dim Ris As Short
        Dim ac As Single
        Try
            With Involucr(kLato, jInvolucr)
                UW20Sw = .UW20Sa
                If .UW20St < UW20Sw Then UW20Sw = .UW20St
                If .UW20St = 0 Then
                    Testo = "L'ammissibile della piastra non è stato definito.|"
                    Testo = Testo + "Non è quindi possibile eseguire il calcolo della|"
                    Testo = Monitor.Motore.Inizio.ConvertiCr(Testo + "saldatura tubo/piastra.")
                    If ContinuoAuto Then
                        nIndent = 6
                        PrintlstRes(Testo)
                        nIndent = 0
                    Else
                        MessageBox.Show(Testo, Involucr(kLato, jInvolucr).Mark, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End If
                    Calcola = 0
                    Exit Function
                End If
                UW20fw = .UW20Sa / UW20Sw
                UW20Fdratio = .Dati1
                UW20Ftstrength = pi * .Spess * (.dns - .Spess) * .UW20Sa * mpa
                UW20af = .Dati2
                UW20ag = .Dati3
                Select Case .di
                    Case 1
                        UW20ar = System.Math.Sqrt((0.75 * .dns) ^ 2 + 2.73 * .Spess * (.dns - .Spess) * UW20fw * UW20Fdratio) - 0.75 * .dns
                        If UW20ar > UW20af Then UW20af = UW20ar
                        If UW20Fdratio = 1 And .Spess > UW20af Then UW20af = .Spess
                        If UW20af <> .Dati2 Then UW20af = Int(10 * UW20af + 0.91) / 10
                        UW20Ffstrength = 0.55 * pi * UW20af * (.dns + 0.67 * UW20af) * UW20Sw * mpa
                        Calcola = UW20Ffstrength / (UW20Ftstrength * UW20Fdratio)
                        .Dati2 = UW20af
                    Case 2
                        UW20ar = System.Math.Sqrt((0.75 * .dns) ^ 2 + 1.76 * .Spess * (.dns - .Spess) * UW20fw * UW20Fdratio) - 0.75 * .dns
                        If UW20ar > UW20ag Then UW20ag = UW20ar
                        If UW20Fdratio = 1 And .Spess > UW20ag Then UW20ag = .Spess
                        If UW20ag <> .Dati3 Then UW20ag = Int(10 * UW20ag + 0.99) / 10
                        UW20Fgstrength = 0.85 * pi * UW20ag * (.dns + 0.67 * UW20ag) * UW20Sw * mpa
                        Calcola = UW20Fgstrength / (UW20Ftstrength * UW20Fdratio)
                        .Dati3 = UW20ag
                    Case 3
                        UW20ar = 2 * (System.Math.Sqrt((0.75 * .dns) ^ 2 + 1.07 * .Spess * (.dns - .Spess) * UW20fw * UW20Fdratio) - 0.75 * .dns)
                        If UW20ar > UW20ag + UW20af Or UW20ag <> UW20af Then
                            UW20ag = UW20ar / 2
                            UW20af = UW20ar / 2
                        End If
                        If UW20Fdratio = 1 And .Spess > 2 * UW20ag Then
                            UW20ag = .Spess / 2
                            UW20af = .Spess / 2
                        End If
                        If UW20ag <> .Dati3 Then UW20ag = Int(10 * UW20ag + 0.99) / 10
                        If UW20af <> .Dati2 Then UW20af = Int(10 * UW20af + 0.99) / 10
                        UW20Ffstrength = 1.001 * 0.55 * pi * UW20af * (.dns + 0.67 * UW20af) * UW20Sw * mpa
                        UW20Fgstrength = 1.001 * 0.85 * pi * UW20ag * (.dns + 0.67 * UW20ag) * UW20Sw * mpa
                        Calcola = (UW20Fgstrength + UW20Ffstrength) / (UW20Ftstrength * UW20Fdratio)
                        .Dati2 = UW20af
                        .Dati3 = UW20ag
                    Case 4
                        If UW20ag <= 0 Then
                            Testo = "Il valore di ag (groove weld leg) deve essere assegnato dal progettista" & vbCrLf
                            Testo = Testo & "e non può essere calcolato dalla procedura. Inserire quindi un valore" & vbCrLf
                            Testo = Testo & "non nullo."
                            If ContinuoAuto Then
                                nIndent = 6
                                PrintlstRes(Testo)
                                nIndent = 0
                            Else
                                MessageBox.Show(Testo, Involucr(kLato, jInvolucr).Mark, MessageBoxButtons.OK, MessageBoxIcon.Information)
                            End If
                            Calcola = 0
                            Exit Function
                        End If
                        UW20Fgstrength = 1.001 * 0.85 * pi * UW20ag * (.dns + 0.67 * UW20ag) * UW20Sw * mpa
                        UW20Ffratio = 1 - UW20Fgstrength / (UW20Fdratio * UW20Ftstrength)
                        UW20ar = System.Math.Sqrt((0.75 * .dns) ^ 2 + 2.73 * .Spess * (.dns - .Spess) * UW20fw * UW20Fdratio * UW20Ffratio) - 0.75 * .dns
                        ac = Int(10 * (UW20ar + UW20ag) + 0.99) / 10
                        If UW20Fdratio = 1 And .Spess > ac Then ac = .Spess
                        '        If UW20af = 0 Then
                        If UW20af <= 0 Then UW20af = ac - UW20ag
                        '        ElseIf UW20ag = 0 Then
                        '        UW20ag = ac - UW20af
                        '        End If
                        'If UW20af <> .Dati2 Then UW20af = Int(10 * UW20af + 0.99) / 10
                        UW20Ffstrength = 1.001 * 0.55 * pi * UW20af * (.dns + 0.67 * UW20af) * UW20Sw * mpa
                        Calcola = (UW20Fgstrength + UW20Ffstrength) / (UW20Ftstrength * UW20Fdratio)
                        .Dati2 = UW20af
                        .Dati3 = UW20ag
                End Select
            End With
        Catch e As Exception
            Testo = "Si è prodotto l'errore " & e.Message & vbCrLf
            Testo = Testo & "durante le verifiche secondo UW20." & vbCrLf
            Testo = Testo & "E' probabile che vi siano dei dati mancanti."
            If ContinuoAuto Then
                nIndent = 6
                PrintlstRes(Testo)
                nIndent = 0
            Else
                MessageBox.Show(Testo, Involucr(kLato, jInvolucr).Mark, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
            Return 0
        End Try
        Calcolato = True
    End Function
    Public Property Verbose() As Boolean
        Get

        End Get
        Set(ByVal Value As Boolean)

        End Set
    End Property
    Public WriteOnly Property UniMis() As Short
        Set(ByVal Value As Short)
        End Set
    End Property
End Class