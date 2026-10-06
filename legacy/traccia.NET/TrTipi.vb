Option Strict Off
Option Explicit On 
Namespace traccia
    Module trTipi
        Public Structure buc
            <VBFixedArray(200)> Dim bu() As Char
            Dim ici As Short
            Public Sub Initialize()
                ReDim bu(200)
            End Sub
        End Structure
        '------------------------------------------------------------------------
        Public Structure typDaTos
            Dim bu As buc
            <VBFixedArray(12)> Dim hsym() As Short
            <VBFixedArray(12)> Dim icontr() As Short
            <VBFixedArray(12)> Dim isett() As Short
            <VBFixedArray(300)> Dim ntub() As Short
            <VBFixedArray(300)> Dim ntus() As Short
            <VBFixedArray(12)> Dim inrow() As Short
            <VBFixedArray(12)> Dim iFrow() As Short
            Dim hin As Short
            Dim Hout As Short
            Dim idout As Short
            Dim idigia As Short
            Dim Elimin As Short
            Dim ntubi As Short
            Dim kymax As Short
            Dim ips1 As Short
            Dim Ips2 As Short
            'Ips2vec As Integer 'non più usato
            'LINDE
            Dim jt6iutu As Short
            Dim JP As Short ' 60ø 30ø 45ø 90ø (1-4)
            Dim jt As Short 'tipo tracciatura (1-10) passi 1,2,3,4,4,4,6,6,8,8
            Dim JSHELL As Short '1 FIX,2 FLOAT, 3 UTUBE,4 fontana
            Dim Nrod As Short
            Dim ntira As Short
            Dim ICDIA As Short
            Dim ISEAL As Short
            Dim Interf As Single 'interferenza ammessa al montaggio dei fasci a fontana
            Dim nset As Short 'numero settori
            Dim ktotal As Short
            <VBFixedArray(300)> Dim x() As Single
            <VBFixedArray(300)> Dim xs() As Single
            <VBFixedArray(300)> Dim xf() As Single
            <VBFixedArray(300)> Dim y() As Single
            <VBFixedArray(50)> Dim dt() As Single
            <VBFixedArray(5)> Dim URTY() As Single
            <VBFixedArray(10)> Dim tagli() As Single
            <VBFixedArray(3, 60)> Dim td(,) As Single
            <VBFixedArray(10, 60)> Dim seal(,) As Single
            <VBFixedArray(4, 60)> Dim runn(,) As Single
            Dim dxv As Single
            Dim Didia As Single
            Dim fsc As Single 'non più usato
            Dim Gap As Single
            Dim frs As Single 'non più usato
            Dim GapCurve As Single 'aria nelle curve dei fasci a fontana
            Dim ILFINAL As Short
            Dim radius As Single
            Dim VPASSO As Single
            Dim cinter As Single
            Dim di1 As Single
            Dim dy As Single
            Dim OPASSO As Single
            Dim OTL As Single
            Dim Primafi As Single
            Dim Passo As Single
            Dim passoint As Single 'passo corona interna
            Dim otimp As Single
            Dim otlmax As Single
            Dim Tagl As Single
            Dim yin As Single
            Dim yout As Single
            Dim ymaxd As Single
            <VBFixedArray(9)> Dim Pad0() As Single
            <VBFixedArray(4)> Dim Pad1() As Short
            Dim icin As Short 'serviva in trk2 :non pi— usato
            <VBFixedArray(6)> Dim Pad3() As Single
            Dim coriext As Single 'diametro esterno corona interna
            Dim coriint As Single 'diametro interno corona interna
            <VBFixedArray(3)> Dim Pad4() As Short
            Dim idfra As Short
            Dim toriz As Single
            Dim tover As Single
            Dim Varco As Single 'varco senza pause RX su fasci a fontana
            Dim di0 As Single
            Dim dtin As Single
            Dim dtout As Single
            Dim roin As Single
            Dim win As Single
            Dim roout As Single
            Dim wout As Single
            Dim y0in As Single
            Dim y0out As Single
            Dim dtubo As Single
            Dim pdiaf As Single
            Dim p1 As Single
            Dim radiu As Single
            Dim tcava As Single
            Dim Spmm As Single
            Dim Spbwg As Single
            Dim Tublu As Single
            Dim Tipo As Single
            Dim cori As Single
            Dim jincr As Short
            Dim jsdis As Short
            Dim kdati As Short
            Dim matub As Short
            Dim js As Short
            Dim rtubo As Single
            Dim xmind As Single
            Dim xcsi As Single
            Dim XSC2 As Single
            Dim XSC1 As Single
            Dim otvec As Single
            Dim Ycentro As Single
            Dim ypsi As Single
            Dim Ysc2 As Single
            Dim Ysc1 As Single
            Dim Anomal0 As Short 'angolo medio del varco
            Dim ips20 As Short 'non più usato
            Dim rr As Single
            Dim raotl As Single
            Dim rtu As Single
            Dim Rtus As Single
            Dim delcl As Single
            Dim iutu As Short
            Dim nrgnpu As Short
            Dim ncinpU As Short
            Dim idf As Short
            Dim ice As Short
            Dim icu As Short
            Dim istra As Short
            Dim ldato As Short
            Dim icf As Short
            Dim isci As Short
            Dim asci As Short
            Dim istam As Short 'non pi— usato
            Dim Pad5() As Byte
            Dim idt As Short
            <VBFixedArray(100)> Dim ntx() As Short
            Dim itro As Short
            Dim DELTAP As Single
            Dim dx As Single
            Dim starty As Single
            Dim Diadif As Single
            Dim Epsilo As Single
            Dim Epsil1 As Single
            Dim idyi As Short
            Dim ivpas As Short
            Dim Index As Short
            Dim jsect As Short
            Dim kwrite As Short
            Dim kteor As Short
            <VBFixedArray(12)> Dim DELTAX() As Single
            Dim NDV As Short
            Dim ndvp As Short
            Dim ntub2 As Short
            Dim Ntot As Short
            Dim nstart As Short
            Dim Ni As Short
            Dim nteor As Short
            Dim NONCI As Short
            Dim OTC As Single 'Otl -diametro tubo
            Dim XYBLOK As Single
            Dim youtfix As Single
            Dim ifxtu As Short
            Dim imi0 As Short
            Dim ideljt As Short
            Dim idelp As Short
            <VBFixedArray(5, 2)> Dim delp(,) As Single
            <VBFixedArray(4)> Dim alfajp() As Single
            <VBFixedArray(4)> Dim PUNP() As Single
            <VBFixedArray(4)> Dim PUNM() As Single
            Dim SRC As Short
            <VBFixedString(40), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst:=40)> Public TESTOX As String
            Dim nfi As Short
            Dim nfo As Short
            Public Sub Initialize()
                bu.Initialize()
                ReDim Pad5(699)
                ReDim hsym(12)
                ReDim icontr(12)
                ReDim isett(12)
                ReDim ntub(300)
                ReDim ntus(300)
                ReDim inrow(12)
                ReDim iFrow(12)
                ReDim x(300)
                ReDim xs(300)
                ReDim xf(300)
                ReDim y(300)
                ReDim dt(50)
                ReDim URTY(5)
                ReDim tagli(10)
                ReDim td(3, 60)
                ReDim seal(10, 60)
                ReDim runn(4, 60)
                ReDim Pad0(8)
                ReDim Pad1(3)
                ReDim Pad3(5)
                ReDim Pad4(2)
                ReDim ntx(100)
                ReDim DELTAX(12)
                ReDim delp(5, 2)
                ReDim alfajp(4)
                ReDim PUNP(4)
                ReDim PUNM(4)
            End Sub
        End Structure
    End Module
End Namespace