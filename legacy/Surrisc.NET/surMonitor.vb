Option Strict Off
Option Explicit On
Friend Class clsMonitor
    Public WithEvents Motore As RoutBase1.clsMotore
    Public Sub New()
        MyBase.New()
    End Sub
    Protected Overrides Sub Finalize()
        If Not Schiavo Then
            'Motore.Class_Terminate
            'UPGRADE_NOTE: È possibile che l'oggetto Motore non venga eliminato in modo permanente finché non venga raccolto nel Garbage Collector. Fare clic per ulteriori informazioni: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
            Motore = Nothing
        End If
        MyBase.Finalize()
    End Sub
    Private Sub Motore_Cambiofile(ByRef f As String) Handles Motore.Cambiofile
        If Not Right(f, 4) = ".SUR" Then Exit Sub
        FileData = f
        Apri()
    End Sub
    Private Sub Motore_SalvaData(ByRef f As String) Handles Motore.SalvaData
        If Not Right(f, 4) = ".SUR" Then Exit Sub
        FileData = f
        Salva()
    End Sub
    Public Property PortLM() As Single
        Get
            With Problem
                Select Case .FluidiInvertiti
                    Case False : PortLM = .Qgas
                    Case True : PortLM = .Qvap
                End Select
            End With
        End Get
        Set(ByVal Value As Single)
            With Problem
                Select Case .FluidiInvertiti
                    Case False : .Qgas = Value
                    Case True : .Qvap = Value
                End Select
            End With
        End Set
    End Property
    Public Property PortLT() As Single
        Get
            With Problem
                Select Case .FluidiInvertiti
                    Case False : PortLT = .Qvap
                    Case True : PortLT = .Qgas
                End Select
            End With
        End Get
        Set(ByVal Value As Single)
            With Problem
                Select Case .FluidiInvertiti
                    Case False : .Qvap = Value
                    Case True : .Qgas = Value
                End Select
            End With
        End Set
    End Property
    Public Property TempLTf() As Single
        Get
            With Problem
                Select Case .FluidiInvertiti
                    Case False : TempLTf = .Temp.Tvin
                    Case True : TempLTf = .Temp.Tgasout
                End Select
            End With
        End Get
        Set(ByVal Value As Single)
            With Problem
                Select Case .FluidiInvertiti
                    Case False : .Temp.Tvin = Value
                    Case True : .Temp.Tgasout = Value
                End Select
            End With
        End Set
    End Property
    Public Property TempLTc() As Single
        Get
            With Problem
                Select Case .FluidiInvertiti
                    Case False : TempLTc = .Temp.Tvout
                    Case True : TempLTc = .Temp.Tgasin
                End Select
            End With
        End Get
        Set(ByVal Value As Single)
            With Problem
                Select Case .FluidiInvertiti
                    Case False : .Temp.Tvout = Value
                    Case True : .Temp.Tgasin = Value
                End Select
            End With
        End Set
    End Property
    Public Property TempLMf() As Single
        Get
            With Problem
                Select Case .FluidiInvertiti
                    Case True : TempLMf = .Temp.Tvin
                    Case False : TempLMf = .Temp.Tgasout
                End Select
            End With
        End Get
        Set(ByVal Value As Single)
            With Problem
                Select Case .FluidiInvertiti
                    Case True : .Temp.Tvin = Value
                    Case False : .Temp.Tgasout = Value
                End Select
            End With
        End Set
    End Property
    Public Property TempLMc() As Single
        Get
            With Problem
                Select Case .FluidiInvertiti
                    Case True : TempLMc = .Temp.Tvout
                    Case False : TempLMc = .Temp.Tgasin
                End Select
            End With
        End Get
        Set(ByVal Value As Single)
            With Problem
                Select Case .FluidiInvertiti
                    Case True : .Temp.Tvout = Value
                    Case False : .Temp.Tgasin = Value
                End Select
            End With
        End Set
    End Property
    Public Property PressLM() As Single
        Get
            With Problem
                Select Case .FluidiInvertiti
                    Case False : PressLM = .PressGasIn
                    Case True : PressLM = .PressVapIn
                End Select
            End With
        End Get
        Set(ByVal Value As Single)
            With Problem
                Select Case .FluidiInvertiti
                    Case False : .PressGasIn = Value
                    Case True : .PressVapIn = Value
                End Select
            End With
        End Set
    End Property
    Public Property PressLT() As Single
        Get
            With Problem
                Select Case .FluidiInvertiti
                    Case False : PressLT = .PressVapIn
                    Case True : PressLT = .PressGasIn
                End Select
            End With
        End Get
        Set(ByVal Value As Single)
            With Problem
                Select Case .FluidiInvertiti
                    Case False : .PressVapIn = Value
                    Case True : .PressGasIn = Value
                End Select
            End With
        End Set
    End Property
End Class