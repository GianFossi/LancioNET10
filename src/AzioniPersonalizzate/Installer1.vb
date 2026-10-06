Imports System.ComponentModel
Imports System.Configuration.Install
Imports System.io

<RunInstaller(True)> Public Class Installer1
    Inherits System.Configuration.Install.Installer

#Region " Codice generato da Progettazione componenti "

    Public Sub New()
        MyBase.New()

        'Chiamata richiesta da Progettazione componenti.
        InitializeComponent()

        'Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent()

    End Sub

    'Il programma di installazione esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Richiesto da Progettazione componenti
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura che segue è richiesta da Progettazione componenti.
    'Può essere modificata in Progettazione componenti.  
    'Non modificarla nell'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        components = New System.ComponentModel.Container()
    End Sub

#End Region
    Private AssemblyPath As String
    Public Overrides Sub Install(ByVal stateSaver As System.Collections.IDictionary)
        MyBase.Install(stateSaver)
        ' Gets the parameter passed across in the CustomActionData.
        'Dim myStringDictionary As StringDictionary = Context.Parameters
        'Dim sr As StreamWriter = File.CreateText("C:\Testo.txt")
        'If Context.Parameters.Count > 0 Then
        'Console.WriteLine("Context Property : ")
        'Dim myString As String
        'For Each myString In Context.Parameters.Keys
        'sr.WriteLine(myString & " : " & Context.Parameters(myString))
        'Next myString
        'End If
        'sr.Close()
        'Exit Sub
        AssemblyPath = Me.Context.Parameters.Item("AssemblyPath")
        If AssemblyPath = "" Then
            Throw New InstallException("No AssemblyPath argument specified")
        End If
        'MsgBox("AssemblyPath " & AssemblyPath)

        ' Uses reflection to find the location of the config file.
        'Dim Asm As System.Reflection.Assembly = System.Reflection.Assembly.GetExecutingAssembly
        'MsgBox(Asm.Location)
        'Dim FileInfo As System.IO.FileInfo = New System.IO.FileInfo(Asm.Location + ".config")
        'If Not FileInfo.Exists Then
        'Throw New InstallException("Missing config file")
        'End If

        ' Loads the config file into the XML DOM.
        'Dim XmlDocument As New System.Xml.XmlDocument
        'XmlDocument.Load(FileInfo.FullName)

        ' Finds the right node and change it to the new value.
        'Dim Node As System.Xml.XmlNode
        'Dim FoundIt As Boolean = False
        'For Each Node In XmlDocument.Item("configuration").Item("appSettings")
        'If Node.Name = "add" Then ' skip any comments
        'If Node.Attributes.GetNamedItem("key").Value = "ServerName" Then
        'Node.Attributes.GetNamedItem("value").Value = ProvidedName
        'FoundIt = True
        'End If
        'End If
        'Next Node

        'If Not FoundIt Then
        'Throw New InstallException("Config file did not contain a ServerName section")
        'End If

        ' Write out the new config file.
        'XmlDocument.Save(FileInfo.FullName)
    End Sub

    Public Overrides Sub Commit(ByVal savedState As System.Collections.IDictionary)
        MyBase.Commit(savedState)
        Dim Asm As System.Reflection.Assembly = System.Reflection.Assembly.GetExecutingAssembly
        AssemblyPath = Path.GetDirectoryName(Asm.Location)
        AggiornaINI(AssemblyPath)
    End Sub

End Class
