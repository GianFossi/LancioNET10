Option Strict On
Option Explicit On
Module incWrcb
    <Serializable()> Structure wrcConfig
        Dim UnitSis As Short '0 SI 1 tecn 2 BR
        Dim Analisi As Short 'solo shell 1 tutte 2 solo nozzle
        Public Docu As String
        Dim Casi As Short
        Dim Unit() As String
        Dim NBocch As Short
        Dim Chart As Short
        Dim WRC297 As Short
        Dim ConvSumm As Short
        Dim Reduced As Short '1: tagli riportati alla base bocchello
        Dim Verbose As Short
        Dim Note As Short
        Dim Ammiss As Short
        Dim Versione As Short
        Public Item As String
        Dim EndEffect As Boolean
        Public DC As Integer 'Design Code
        Public Sub initialize()
            ReDim Preserve Unit(7)
            Docu = ""
            Item = ""
            ' NBocch = 0
        End Sub
    End Structure
    <Serializable()> Structure typCarichi
        Public CaseDescription As String
        Dim DesPress As Single
        Dim DesTemp As Single
        Dim AllowShe As Single
        Dim AllowNoz As Single
        Dim YieldNoz As Single
        Dim UTSNoz As Single
        Dim fYield As Single
        Dim fUTS As Single
        Dim AllowSheBr As Single
        Dim fBuc As Single
        Dim Load(,) As Single  '0: forza radiale comprensiva della pressione
        Dim WLoad(,) As Single
        Dim TLoad(,) As Single
        Public Sub Initialize(ByVal canc As Boolean)
            If Not canc Then
                ReDim Preserve Load(6, 2)
                ReDim Preserve WLoad(6, 2)
                ReDim Preserve TLoad(6, 2)
            Else
                ReDim Load(6, 2)
                ReDim WLoad(6, 2)
                ReDim TLoad(6, 2)
            End If
        End Sub
    End Structure
    <Serializable()> Structure typGeom
        Public Mark As String
        Public Size As String
        Dim Asa As Short '1,2,3,4,5,6,7
        Dim ShellType As Short '0Cyl 1 Sphe
        Dim Buco As Short '0Hollow 1 Rigid
        Dim Forma As Short '0 rotondo 1 rettangolare
        Dim di As Single
        Dim ShellT As Single
        Dim PadT As Single
        Dim Padd As Single
        Dim R0 As Single
        Dim RX As Single
        Dim RC As Single
        Dim D1 As Single
        Dim D2 As Single
        Dim T0 As Single
        Dim TX As Single
        Dim Corr As Single
        Public ShellMat As String
        Public NozzMat As String
        Dim kS As Single
        Dim T As Single
        Dim RI As Single
        Dim R As Single
        Dim RO As Single
        Dim RM As Single
        Dim RN As Single
        Dim Carichi() As typCarichi
        Dim Lato As Short '1 lato tubi 2 lato mantello
        Dim Ind As Short 'ind di RecAPR
        Dim Incluso As Short
        Dim DiaN As Single
        Dim CylL As Single
        Dim Cyld As Single
        Dim Sporg As Single
        Dim Rinforzo As Short
        Dim BS35434 As Short
        Dim D1Rinf As Single
        Dim D2Rinf As Single
        Dim Casi As Short
        Dim IndiceB As Short
        Dim IndiceC As Short 'indice in RecAPR
        Dim iB() As Short 'nearest nozzles in Q1,Q2,Q3,Q4
        Dim Dist() As Single
        Dim CorrN As Single
        Public Sub Initialize(ByVal canc As Boolean)
            If canc Then
                ReDim Carichi(6)
                ReDim iB(4)
                ReDim Dist(4)
            Else
                ReDim Preserve Carichi(6)
                ReDim Preserve iB(4)
                ReDim Preserve Dist(4)
            End If
            Mark = ""
            Size = ""
            ShellMat = ""
            NozzMat = ""
            Dim i As Integer
            For i = 1 To 6
                Carichi(i).Initialize(canc)
            Next
        End Sub
    End Structure
    <Serializable()> Structure typStressLim
        Dim ASL() As Single
        Dim ASQ() As Single
        Dim ANM As Single
        Dim ANL As Single
        Dim ANQ As Single
        Public Sub Initialize()
            ReDim Preserve ASL(2)
            ReDim Preserve ASQ(2)
        End Sub
    End Structure
    <Serializable()> Structure typResult
        Dim SP As Single
        Dim Sq As Single
        Dim SMA As Single
        Dim SMB As Single
        Dim SLA As Single
        Dim SLB As Single
        Dim SQA As Single
        Dim SQB As Single
        Dim SMM As Single
        Dim SLM As Single
        Dim SQM As Single
        Dim Bu As Single
    End Structure
End Module