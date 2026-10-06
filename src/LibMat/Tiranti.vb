Option Strict On
Option Explicit On
Imports System.Data
Imports System.Data.OleDb
<Serializable()> Public Class clsTira
    Public DN As String
    Public Diam As Single 'diametro nocciolo mm
    Public Chia As Single
    Public BSmin As Single
    Public Rmin As Single 'spaziatura interna
    Public Emin As Single 'spaziatura esterna
    Public foro As Single
    Public Dnom As Single 'diametro nominale mm
    Public Xfil As Short '1 metr 2 brit 3 met pil 4 brit pil
    Public Passo As Single 'mm per M;UNC per ANSI
    <NonSerialized()> Private Lista As DataTable
    <NonSerialized()> Friend Tipi As DataTable
    <NonSerialized()> Private cmdL, cmdT As OleDbDataAdapter
    <NonSerialized()> Friend ListaR As DataView
    <NonSerialized()> Friend drv As DataRowView
    Private iCurr As Short
    Public Sub New()
        MyBase.New()
        DN = "1"
        Apri()
    End Sub
    Public Sub Scelta(ByRef Arch As String, ByRef DiscoT As String)
        If Len(Archdir) = 0 Then
            Archdir = Arch
            DiscoTem = DiscoT
        End If
        Tirante = Me
        FormTirante = New frmTira
        FormTirante.ShowDialog()
        FormTirante.Dispose()
    End Sub
    Public Sub Scelfil(ByRef Arch As String, ByRef DiscoT As String)
        Archdir = Arch
        DiscoTem = DiscoT
        Tirante = Me
        frmTirFil.DefInstance.ShowDialog()
    End Sub
    Public Function CercaDN(Optional ByRef Arch As String = "", Optional ByRef DiscoT As String = "", Optional ByVal f As frmTira = Nothing) As Boolean
        Dim j As Integer
        Dim strDN As String
        If Len(Archdir) = 0 And Not DiscoT = "" Then
            Archdir = Arch
            DiscoTem = DiscoT
        End If
        DN = DN.Replace(".", " ")
        For j = 0 To CShort(ListaR.Count - 1)
            strDN = CStr(ListaR(j)("DN")).Trim
            If strDN.Substring(0, strDN.Length - 2).Trim = DN.Trim Or strDN = DN.Trim Then Exit For
        Next
        If j > CShort(ListaR.Count - 1) Then CercaDN = False : Exit Function
        iCurr = CShort(j + 1)
        If f Is Nothing Then f = New frmTira
        f.iCurr = iCurr
        CercaDN = True
        drv = ListaR(j)
        Transfer()
    End Function
    Public Function Preleva(ByRef i As Short) As Boolean
        Tirante = Me
        FormTirante = New frmTira
        Dim Res As Boolean = FormTirante.Preleva(i)
        FormTirante.Dispose()
        Return Res
    End Function
    Protected Overrides Sub Finalize()
        If Not Lista Is Nothing Then Lista.Dispose()
        Tirante = Nothing
        MyBase.Finalize()
    End Sub
    Private Sub Inizia()
        Lista = New DataTable
        Tipi = New DataTable
        Tirante = Me
        If Not IniziaBase() Then Exit Sub
        cmdL = New OleDbDataAdapter("SELECT * FROM Tiranti ORDER BY Diam", MatBase)
        cmdL.Fill(Lista)
        cmdT = New OleDbDataAdapter("SELECT * FROM tipiTiranti", MatBase)
        cmdT.Fill(Tipi)
    End Sub
    Public Sub Apri()
        Inizia()
        If Xfil = 0 Then Xfil = 2
        ListaR = New DataView(Lista)
        ListaR.RowFilter = "Xfil =" & Str(Xfil)
    End Sub
    Public Sub Transfer()
        DN = CStr(drv("DN"))
        Diam = CSng(drv("Diam"))
        Dnom = CSng(drv("Dnom"))
        Chia = CSng(drv("Chia"))
        BSmin = CSng(drv("BSmin"))
        Rmin = CSng(drv("Rmin"))
        Emin = CSng(drv("Emin"))
        foro = CSng(drv("foro"))
        Passo = CSng(drv("Passo"))
    End Sub
    Public Sub Cerca(ByVal cosa As String)
        Dim i As Short
        Dim Infinito As Single, dist As Single
        Infinito = 10000000000.0#
        If ListaR Is Nothing Then Apri()
        i = 0
        Do Until i > ListaR.Count - 1
            Select Case cosa
                Case "Diam" : dist = Diam - Funzioni.ValVir(CStr(ListaR(i)("Diam")))
                Case "Dnom" : dist = Dnom - Funzioni.ValVir(CStr(ListaR(i)("Dnom")))
            End Select
            If dist ^ 2 < Infinito Then
                Infinito = CSng(dist ^ 2)
                iCurr = CShort(i + 1)
            End If
            i = CShort(i + 1)
        Loop
        drv = ListaR(iCurr - 1)
        Transfer()
    End Sub
    Public Sub Copia(ByRef A As clsTira)
        If A Is Nothing Then A = New clsTira
        A.DN = DN
        A.Diam = Diam
        A.Chia = Chia
        A.BSmin = BSmin
        A.Rmin = Rmin
        A.Emin = Emin
        A.foro = foro
        A.Dnom = Dnom
        A.Xfil = Xfil
        A.Passo = Passo
    End Sub
End Class