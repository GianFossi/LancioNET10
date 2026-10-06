Option Strict On
Option Explicit On
<Serializable()> Public Class clsPipe
    Public DN As String
    Public Diam As Single
    Public Schedula As String
    Public Spess As Single
    Public Standard As Short
    <NonSerialized()> Private FormPipe As frmPipe
    Public Sub Cerca(Optional ByRef Arch As String = "", Optional ByRef DiscoT As String = "")
        If Len(Arch) > 0 Then Archdir = Arch
        If Len(DiscoT) > 0 Then DiscoTem = DiscoT
        FormPipe = New frmPipe
        FormPipe.cmdOK_Click(FormPipe.cmdOK, New System.EventArgs)
        FormPipe.Dispose()
    End Sub
    Public Sub Scelta(Optional ByRef Arch As String = "", Optional ByRef DiscoT As String = "")
        If Len(Arch) > 0 Then Archdir = Arch
        If Len(DiscoT) > 0 Then DiscoTem = DiscoT
        FormPipe = New frmPipe
        FormPipe.ShowDialog()
        FormPipe.Dispose()
    End Sub
    Public WriteOnly Property DoveMotore() As RoutBase1.clsMotore
        Set(ByVal Value As RoutBase1.clsMotore)
            Dim strS As String
            If Monitor Is Nothing Then Monitor = New clsMonitor
            If Monitor.Motore Is Nothing Then Monitor.Motore = Value
            Archdir = Value.Inizio.Archdir
            DiscoTem = Value.Inizio.DiscoTem
            strS = Monitor.Motore.Inizio.ReadIniFile("", "Parametri", "StandardPiping")
            Standard = CShort(Val(strS))
        End Set
    End Property
    Public Sub New()
        MyBase.New()
        Tubo = Me
    End Sub
End Class