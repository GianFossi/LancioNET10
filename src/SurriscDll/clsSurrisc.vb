Option Strict Off
Option Explicit On
Public Class clsSurrisc
    Public Sub EseguiSchiavo(ByRef g As Ppgas.clsPpg, ByRef v As VapAcqua.clsVapAcqua, ByRef f As String, ByRef a As Short, ByRef Vecchio As Boolean)
        Fase = 0
        Schiavo = True
        Gas = g
        Vap = v
        FileData = Left(f, Len(f) - 3) & "SUR"
        Config.Autom = True
        Apri(a + 1, Vecchio)
    End Sub
    Public Sub Show()
        mioApert = New Apert
        mioApert.Show()
    End Sub
    Public Sub EseguiSciolto()
        Fase = 0
        Schiavo = False
        Gas = New Ppgas.clsPpg
        Gas.Acqua = False
        Gas.Schiavo = True
        IniziaVap()
        Gas.DoveMotore = Monitor.Motore
        Gas.Inizia()
        With Monitor.Motore.About
            .ProgName = "SURR"
            Monitor.Motore.About.ProgVers = myAssembly.GetName.Version.Major.ToString & "." & myAssembly.GetName.Version.Minor.ToString
            Dim Fi As IO.FileInfo = New IO.FileInfo(myAssembly.Location)
            Monitor.Motore.About.ProgDate = Format(Fi.CreationTime, "dd/MM/yy")
            .ProgDesc = "Calcolo Termico Surriscaldatori con gas di combustione"
        End With
        Monitor.Motore.Problem.Extension = ".SUR"
        mioApert = New Apert
        mioApert.Show()
    End Sub
    Public WriteOnly Property DoveMotore() As RoutBase1.clsMotore
        Set(ByVal Value As RoutBase1.clsMotore)
            Monitor = New clsMonitor
            Monitor.Motore = Value
            Dim InitLibmat As LibMat.clsInitLibMat = New LibMat.clsInitLibMat(Monitor.Motore)
        End Set
    End Property
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
    Public Property prDescrizione() As String
        Get
            prDescrizione = Config.DescrAlt
        End Get
        Set(ByVal Value As String)
            If InStr(Config.DescrAlt, "Ness") > 0 Then
                Config.DescrAlt = Value
                mioApert.txtDescr.Text = Config.DescrAlt
            End If
        End Set
    End Property
    Public Sub New()
        MyBase.New()
        Surr = Me
        IniziaFarf()
        nReg = 10
        myAssembly = Me.GetType.Assembly
        Reg(0).Initialize()
        Reg(1).Initialize()
    End Sub
    Protected Overrides Sub Finalize()
        Dispose()
        MyBase.Finalize()
    End Sub
    Public Sub Dispose()
        If Not Schiavo Then
            If Not Gas Is Nothing Then
                Monitor.Motore.Ammazza("PPGS")
                Gas = Nothing
            End If
            If Not Vap Is Nothing Then
                Monitor.Motore.Ammazza("VAPQ")
                Vap = Nothing
            End If
        End If
        If Not Monitor Is Nothing Then Monitor.Motore = Nothing
        Monitor = Nothing
        Surr = Nothing
    End Sub
End Class