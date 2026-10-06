Option Strict Off
Option Explicit On
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Runtime.Serialization.Formatters.Binary
Friend Class wn_Part
    <Serializable(), StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> Private Structure typProblem
        Dim pass_partition As Short
        <VBFixedString(20), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=20)> Public Materiale As String
        Dim design_pressure As Single
        Dim design_Temperature As Single
        Dim allowable_stress As Single
        Dim corrosion As Single
        Dim Shell_Diameter As Single
        Dim dimensione_a As Single
        Dim dimensione_b As Single
        Dim sistema As Short
        Dim tipo_Materiale As Short
        Dim longdim As Single
        Dim transvdim As Single
        <VBFixedString(92), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=92)> Public Pad As String
    End Structure
    Public lKlato, lJinvolucr As Short
    Public t_tema As Single
    Public tmp_shell_diameter As Single
    Public t As Single
    Public t_inc As Single

    Private Problem As typProblem
    'Dichirazione costanti riguardanti le
    'immagini d'aiuto per l'inserimento dati
    Public Three_sides_fixed As Short
    Public Long_Sides_Fixed As Short
    Public Short_Sides_Fixed As Short
    Public longdim, transvdim As Single

    'Variabile che conterrà il nome della tabella da aprire
    Public tabella As String
    Public TreLati As Boolean

    'Dimensiona una variabile per il rconoscimento del tipo
    'di Pass Partition scelto per il calcolo
    Public pass_partition As Short

    'Dimensiona una variabile per contenere i vari valori
    'necessari per il calcolo dei Pass Partition
    Public Valore_b As Single
    Public Valore_asub As Single
    Public Materiale As String
    Public design_pressure As Single
    Public design_Temperature As Single
    Public allowable_stress As Single
    Public corrosion As Single
    Public Shell_Diameter As Single
    Public dimensione_a As Single
    Public dimensione_b As Single


    'Dimensiona una variabile cisibile a tutti i moduli per
    'indicare se il valore di B scelto è stato scelto dalla tabella o
    'tramite l'inserimento di valori personalizati
    Public nessuno As Short
    Public Standard As Short
    Public personalizzato As Short
    Public inserimento As Short

    'Dimensiona una variabile per l'indicazione del tipo di materiale
    Public tipo_Materiale As Short
    Public Carbon_Steel As Short
    Public Alloy_Material As Short
    Public Sub New()
        MyBase.New()
        Three_sides_fixed = 0
        Long_Sides_Fixed = 1
        Short_Sides_Fixed = 2
        nessuno = -1
        Standard = 0
        personalizzato = 1
        Carbon_Steel = 0
        Alloy_Material = 1
        inserimento = personalizzato
        lKlato = kLato
        lJinvolucr = jInvolucr
    End Sub
    Public Overloads Function Leggi(ByRef ifl As Short) As Boolean
        Leggi = True
        FileGet(ifl, Problem)
        Transfer()
    End Function
    Public Overloads Function Leggi(ByRef fs As FileStream) As Boolean
        Leggi = True
        Dim bf As New BinaryFormatter
        Problem = CType(bf.Deserialize(fs), typProblem)
        Transfer()
    End Function
    Private Sub Transfer()
        With Problem
            pass_partition = .pass_partition
            Materiale = .Materiale
            design_pressure = .design_pressure
            design_Temperature = .design_Temperature
            allowable_stress = .allowable_stress
            corrosion = .corrosion
            Shell_Diameter = .Shell_Diameter
            dimensione_a = .dimensione_a
            dimensione_b = .dimensione_b
            tipo_Materiale = .tipo_Materiale
            longdim = .longdim
            transvdim = .transvdim
        End With
    End Sub
    Public Sub Salva(ByRef fs As FileStream)
        With Problem
            .pass_partition = pass_partition
            .Materiale = Materiale
            .design_pressure = design_pressure
            .design_Temperature = design_Temperature
            .allowable_stress = allowable_stress
            .corrosion = corrosion
            .Shell_Diameter = Shell_Diameter
            .dimensione_a = dimensione_a
            .dimensione_b = dimensione_b
            .tipo_Materiale = tipo_Materiale
            .longdim = longdim
            .transvdim = transvdim
        End With
        Dim bf As New BinaryFormatter
        bf.Serialize(fs, Problem)
    End Sub

    Public Sub Stampa()
        Dim t_modificato As Boolean
        Dim ifl As Short
        Dim TIMA As String = ""
        Dim Stringa(2) As String
        'Dim Data As String = ""
        'Dim Data1 As String = ""
        Dim Stringa1(1) As String
        t_modificato = False
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        Stringa(0) = "Three Sides Fixed"
        Stringa(1) = "Long sides fixed"
        Stringa(2) = "Short sides fixed"
        Stringa1(0) = "Carbon Steel"
        Stringa1(1) = "Alloy Material"
        If Not PrepRapp(Template, "Pass partitions", Involucr(kLato, jInvolucr).Mark, FileSt, mioApert.lstRapp) Then Exit Sub
        Monitor.Motore.Testata()
        ifl = FreeFile()
        FileOpen(ifl, RTrim(Monitor.Motore.Inizio.Archdir) & "\RTF\PASS.RTF", OpenMode.Input, , OpenShare.Shared)
        'Call Assumi(ifl, TIMA)
        With Monitor.Motore.Problem
            '  .Printa(GlobalRoutines.FormatS(TIMA, Monitor.Motore.About.ProgName, Monitor.Motore.About.ProgVers))
            ' Data = DateString
            ' Data1 = Data
            ' Mid(Data1, 1, 2) = Mid(Data, 4, 2)
            ' Mid(Data1, 4, 2) = Mid(Data, 1, 2)
            'Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, job.Comm.Arch, job.Comm.Ind(job.Comm.NumAs).Data.Assieme, job.Comm.Comp, Data1))
            'Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, job.Comm.Clie))
            'Aggiornamento campo del materiale
            Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, Materiale))
            Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, design_pressure, "Mpa", design_pressure * psi, "psi"))
            'End If
            'Aggiornamento Campo Design Temperature
            'If sistema = Inglese Then
            Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, design_Temperature, "°C", design_Temperature * 1.8 + 32, "°F"))
            'Aggiornamento campo Allowable Stress
            'If sistema = Inglese Then
            Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, allowable_stress, "MPa", allowable_stress * psi, "psi"))
            Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, corrosion, "mm", corrosion / inc, "in"))
            'Aggiornamento campo Shell_Diameter
            Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, Shell_Diameter, "mm", Shell_Diameter / inc, "in"))
            'Aggiornameno Campo Dimension a
            Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, dimensione_a, "mm", dimensione_a / inc, "in"))
            'Aggiornamento campo Dimension b
            Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, dimensione_b, "mm", dimensione_b / inc, "in"))
            Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, Stringa(pass_partition)))
            Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, dimensione_a / dimensione_b))
            Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, Valore_b))
            If Config(0).US = 2 Then
                Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, t * inc, "mm", t, "in"))
                t_inc = t
            Else
                Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, t, "mm", t / inc, "in"))
                'user_doc.Fields(14).Code.Text = "Macrobutton nomacro " & t & "  mm     -     " & mm2inc(t) & " inc"
                t_inc = t / inc
            End If
            'Questa sezione corrisponde ad una letura della tabella RCB-9.132 delle TEMA
            Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, Stringa1(tipo_Materiale)))
            Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, t_inc * inc, "mm", t_inc, "in"))
            Call Assumi(ifl, TIMA) : .Printa(GlobalRoutines.FormatS(TIMA, Involucr(kLato, jInvolucr).Spess, "mm", Involucr(kLato, jInvolucr).Spess / inc, "in"))
            Call Assumi(ifl, TIMA) : FileClose(ifl)
        End With
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
    End Sub
    Public Sub AggTAbelle()
        If TreLati Then
            pass_partition = Three_sides_fixed
            tabella = "ThreeSidesFixed"
            dimensione_a = transvdim
            dimensione_b = longdim
        Else
            If longdim > transvdim Then
                pass_partition = Long_Sides_Fixed
                tabella = "LongSidesFixed"
                dimensione_b = transvdim
                dimensione_a = longdim
            Else
                pass_partition = Short_Sides_Fixed
                tabella = "ShortSidesFixed"
                dimensione_a = transvdim
                dimensione_b = longdim
            End If
        End If
    End Sub
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