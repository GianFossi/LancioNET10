Option Strict On
Option Explicit On
<Serializable()> Public Class clsMatCompos
    Public Classe As ClasseMateriale
    Public TipoCompos As TipoRivestimento
    Friend Ind As RoutBase1.LinkListSh
    Public Mat(3) As MaterialeNew1
    Public Sub Scelta(ByVal Clas As Short, Optional ByRef Arch As String = "", Optional ByRef Capt As String = "", Optional ByRef Tipo As TipoRivestimento = TipoRivestimento.Nessuno)
        Dim i As Short
        Dim frmMaterP As frmMater
        Dim Mat As New clsMat
        If Len(Arch) > 0 Then Archdir = Arch
        frmMaterP = New frmMater
        Mat.frm = frmMaterP
        frmMaterP.Mat = Mat
        FormMat.Add(Mat) 'frmMaterP
        With frmMaterP
            .Text = Capt
            If FormMat.Count() > 1 Then
                ._cmdEdit_0.Visible = False
                ._cmdEdit_1.Visible = False
                ._cmdEdit_2.Visible = False
                ._cmdEdit_3.Visible = False
                .cmdStampaListino.Visible = False
                .cmdLE.Visible = False
            End If
            Select Case Tipo
                Case TipoRivestimento.Nessuno, TipoRivestimento.Placcato
                    .Frame3D2.Visible = True
                    .Check3D1.Visible = True
                    For i = 0 To 2
                        .Option3D2(i).Visible = False : Next
                    .Check3D2.Visible = False
                Case TipoRivestimento.WO
                    .Frame3D2.Visible = False
                Case TipoRivestimento.Lining
                    .Frame3D2.Visible = True
                    .Check3D1.Visible = True
                    For i = 0 To 2
                        .Option3D2(i).Visible = True : Next
                    .Check3D2.Visible = True
            End Select
        End With
        With Mat
            .MatCompos = Me
            .Compos = CShort(True)
            .MatSolo = Nothing
            '.MatCompos.Classe = 0 '????Clas
            .Editato = 0 'False
        End With
        frmMaterP.ShowDialog()
    End Sub

    Public WriteOnly Property DoveMotore() As RoutBase1.clsMotore
        Set(ByVal Value As RoutBase1.clsMotore)
            If Monitor Is Nothing Then Monitor = New clsMonitor
            If Monitor.Motore Is Nothing Then Monitor.Motore = Value
            Archdir = Value.Inizio.Archdir
            DiscoTem = Value.Inizio.DiscoTem
        End Set
    End Property
    Public ReadOnly Property Indmat() As Short
        Get
            If Mat(1) Is Nothing Then Exit Property
            Indmat = Mat(1).Indmat
        End Get
    End Property
    Public Sub New()
        MyBase.New()
        Ind = New RoutBase1.LinkListSh
        Mat(1) = New MaterialeNew1
        Mat(2) = New MaterialeNew1
        Mat(3) = New MaterialeNew1
        Mat(1).Agganciato = True
        Mat(2).Agganciato = True
        Mat(3).Agganciato = True
    End Sub
    Public Sub IndAdd(ByVal i As Short, ByVal j As Short)
        If j + 1 <= Ind.Count() Then
            Ind.Item(j + 1).TextData = i
        Else
            Ind.Add(i)
        End If
    End Sub
    Public Function testo() As String
        Dim Cod As String = ""
        If TipoCompos = TipoRivestimento.Nessuno Then  'Bas = 0 Then
            testo = Mat(1).MatStr 'Mat$
        Else
            Select Case TipoCompos
                Case TipoRivestimento.Placcato : Cod = " + PL "
                Case TipoRivestimento.WO : Cod = " + WO "
                Case TipoRivestimento.Lining : Cod = " + Lin "
                Case TipoRivestimento.biPlaccato : Cod = " + 2 x PL "
                Case TipoRivestimento.biWO : Cod = " + 2 x WO "
                Case TipoRivestimento.biLining : Cod = " + 2 x Lin "
            End Select
            testo = Trim(Mat(1).MatStr) & Cod & Trim(Mat(2).MatStr) 'Mat$
        End If
    End Function
End Class