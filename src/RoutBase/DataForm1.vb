Public Class DataFormAutorizz
    Inherits System.Windows.Forms.Form

#Region " Codice generato da Progettazione Windows Form "

    Public Sub New()
        MyBase.New()

        'Chiamata richiesta da Progettazione Windows Form.
        InitializeComponent()

        'Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent()

    End Sub

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Richiesto da Progettazione Windows Form
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura che segue è richiesta da Progettazione Windows Form.
    'Può essere modificata in Progettazione Windows Form.  
    'Non modificarla nell'editor del codice.
    Friend WithEvents OleDbSelectCommand1 As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbInsertCommand1 As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbUpdateCommand1 As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbDeleteCommand1 As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbConnection1 As System.Data.OleDb.OleDbConnection
    Friend WithEvents OleDbDataAdapter1 As System.Data.OleDb.OleDbDataAdapter
    Friend WithEvents objdsCommesse As RoutBase1.dsCommesse
    Friend WithEvents btnLoad As System.Windows.Forms.Button
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents lblID As System.Windows.Forms.Label
    Friend WithEvents lblOperazione As System.Windows.Forms.Label
    Friend WithEvents lblQualif1 As System.Windows.Forms.Label
    Friend WithEvents lblQualif2 As System.Windows.Forms.Label
    Friend WithEvents lblQualif3 As System.Windows.Forms.Label
    Friend WithEvents lblQualif4 As System.Windows.Forms.Label
    Friend WithEvents editID As System.Windows.Forms.TextBox
    Friend WithEvents editOperazione As System.Windows.Forms.TextBox
    Friend WithEvents editQualif1 As System.Windows.Forms.TextBox
    Friend WithEvents editQualif2 As System.Windows.Forms.TextBox
    Friend WithEvents editQualif3 As System.Windows.Forms.TextBox
    Friend WithEvents editQualif4 As System.Windows.Forms.TextBox
    Friend WithEvents lblQualif5 As System.Windows.Forms.Label
    Friend WithEvents lblQualif6 As System.Windows.Forms.Label
    Friend WithEvents lblQualif7 As System.Windows.Forms.Label
    Friend WithEvents lblQualif8 As System.Windows.Forms.Label
    Friend WithEvents lblQualif9 As System.Windows.Forms.Label
    Friend WithEvents editQualif5 As System.Windows.Forms.TextBox
    Friend WithEvents editQualif6 As System.Windows.Forms.TextBox
    Friend WithEvents editQualif7 As System.Windows.Forms.TextBox
    Friend WithEvents editQualif8 As System.Windows.Forms.TextBox
    Friend WithEvents editQualif9 As System.Windows.Forms.TextBox
    Friend WithEvents btnNavFirst As System.Windows.Forms.Button
    Friend WithEvents btnNavPrev As System.Windows.Forms.Button
    Friend WithEvents lblNavLocation As System.Windows.Forms.Label
    Friend WithEvents btnNavNext As System.Windows.Forms.Button
    Friend WithEvents btnLast As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.OleDbSelectCommand1 = New System.Data.OleDb.OleDbCommand
        Me.OleDbInsertCommand1 = New System.Data.OleDb.OleDbCommand
        Me.OleDbUpdateCommand1 = New System.Data.OleDb.OleDbCommand
        Me.OleDbDeleteCommand1 = New System.Data.OleDb.OleDbCommand
        Me.OleDbConnection1 = New System.Data.OleDb.OleDbConnection
        Me.OleDbDataAdapter1 = New System.Data.OleDb.OleDbDataAdapter
        Me.objdsCommesse = New RoutBase1.dsCommesse
        Me.btnLoad = New System.Windows.Forms.Button
        Me.btnUpdate = New System.Windows.Forms.Button
        Me.lblID = New System.Windows.Forms.Label
        Me.lblOperazione = New System.Windows.Forms.Label
        Me.lblQualif1 = New System.Windows.Forms.Label
        Me.lblQualif2 = New System.Windows.Forms.Label
        Me.lblQualif3 = New System.Windows.Forms.Label
        Me.lblQualif4 = New System.Windows.Forms.Label
        Me.editID = New System.Windows.Forms.TextBox
        Me.editOperazione = New System.Windows.Forms.TextBox
        Me.editQualif1 = New System.Windows.Forms.TextBox
        Me.editQualif2 = New System.Windows.Forms.TextBox
        Me.editQualif3 = New System.Windows.Forms.TextBox
        Me.editQualif4 = New System.Windows.Forms.TextBox
        Me.lblQualif5 = New System.Windows.Forms.Label
        Me.lblQualif6 = New System.Windows.Forms.Label
        Me.lblQualif7 = New System.Windows.Forms.Label
        Me.lblQualif8 = New System.Windows.Forms.Label
        Me.lblQualif9 = New System.Windows.Forms.Label
        Me.editQualif5 = New System.Windows.Forms.TextBox
        Me.editQualif6 = New System.Windows.Forms.TextBox
        Me.editQualif7 = New System.Windows.Forms.TextBox
        Me.editQualif8 = New System.Windows.Forms.TextBox
        Me.editQualif9 = New System.Windows.Forms.TextBox
        Me.btnNavFirst = New System.Windows.Forms.Button
        Me.btnNavPrev = New System.Windows.Forms.Button
        Me.lblNavLocation = New System.Windows.Forms.Label
        Me.btnNavNext = New System.Windows.Forms.Button
        Me.btnLast = New System.Windows.Forms.Button
        CType(Me.objdsCommesse, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'OleDbSelectCommand1
        '
        Me.OleDbSelectCommand1.CommandText = "SELECT ID, Operazione, Qualif1, Qualif2, Qualif3, Qualif4, Qualif5, Qualif6, Qual" & _
        "if7, Qualif8, Qualif9 FROM Autorizz"
        Me.OleDbSelectCommand1.Connection = Me.OleDbConnection1
        '
        'OleDbInsertCommand1
        '
        Me.OleDbInsertCommand1.CommandText = "INSERT INTO Autorizz(Operazione, Qualif1, Qualif2, Qualif3, Qualif4, Qualif5, Qua" & _
        "lif6, Qualif7, Qualif8, Qualif9) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?)"
        Me.OleDbInsertCommand1.Connection = Me.OleDbConnection1
        Me.OleDbInsertCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Operazione", System.Data.OleDb.OleDbType.VarWChar, 10, "Operazione"))
        Me.OleDbInsertCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Qualif1", System.Data.OleDb.OleDbType.VarWChar, 2, "Qualif1"))
        Me.OleDbInsertCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Qualif2", System.Data.OleDb.OleDbType.VarWChar, 2, "Qualif2"))
        Me.OleDbInsertCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Qualif3", System.Data.OleDb.OleDbType.VarWChar, 2, "Qualif3"))
        Me.OleDbInsertCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Qualif4", System.Data.OleDb.OleDbType.VarWChar, 2, "Qualif4"))
        Me.OleDbInsertCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Qualif5", System.Data.OleDb.OleDbType.VarWChar, 2, "Qualif5"))
        Me.OleDbInsertCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Qualif6", System.Data.OleDb.OleDbType.VarWChar, 2, "Qualif6"))
        Me.OleDbInsertCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Qualif7", System.Data.OleDb.OleDbType.VarWChar, 2, "Qualif7"))
        Me.OleDbInsertCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Qualif8", System.Data.OleDb.OleDbType.VarWChar, 2, "Qualif8"))
        Me.OleDbInsertCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Qualif9", System.Data.OleDb.OleDbType.VarWChar, 2, "Qualif9"))
        '
        'OleDbUpdateCommand1
        '
        Me.OleDbUpdateCommand1.CommandText = "UPDATE Autorizz SET Operazione = ?, Qualif1 = ?, Qualif2 = ?, Qualif3 = ?, Qualif" & _
        "4 = ?, Qualif5 = ?, Qualif6 = ?, Qualif7 = ?, Qualif8 = ?, Qualif9 = ? WHERE (ID" & _
        " = ?) AND (Operazione = ? OR ? IS NULL AND Operazione IS NULL) AND (Qualif1 = ? " & _
        "OR ? IS NULL AND Qualif1 IS NULL) AND (Qualif2 = ? OR ? IS NULL AND Qualif2 IS N" & _
        "ULL) AND (Qualif3 = ? OR ? IS NULL AND Qualif3 IS NULL) AND (Qualif4 = ? OR ? IS" & _
        " NULL AND Qualif4 IS NULL) AND (Qualif5 = ? OR ? IS NULL AND Qualif5 IS NULL) AN" & _
        "D (Qualif6 = ? OR ? IS NULL AND Qualif6 IS NULL) AND (Qualif7 = ? OR ? IS NULL A" & _
        "ND Qualif7 IS NULL) AND (Qualif8 = ? OR ? IS NULL AND Qualif8 IS NULL) AND (Qual" & _
        "if9 = ? OR ? IS NULL AND Qualif9 IS NULL)"
        Me.OleDbUpdateCommand1.Connection = Me.OleDbConnection1
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Operazione", System.Data.OleDb.OleDbType.VarWChar, 10, "Operazione"))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Qualif1", System.Data.OleDb.OleDbType.VarWChar, 2, "Qualif1"))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Qualif2", System.Data.OleDb.OleDbType.VarWChar, 2, "Qualif2"))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Qualif3", System.Data.OleDb.OleDbType.VarWChar, 2, "Qualif3"))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Qualif4", System.Data.OleDb.OleDbType.VarWChar, 2, "Qualif4"))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Qualif5", System.Data.OleDb.OleDbType.VarWChar, 2, "Qualif5"))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Qualif6", System.Data.OleDb.OleDbType.VarWChar, 2, "Qualif6"))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Qualif7", System.Data.OleDb.OleDbType.VarWChar, 2, "Qualif7"))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Qualif8", System.Data.OleDb.OleDbType.VarWChar, 2, "Qualif8"))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Qualif9", System.Data.OleDb.OleDbType.VarWChar, 2, "Qualif9"))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Operazione", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Operazione", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Operazione1", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Operazione", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Qualif1", System.Data.OleDb.OleDbType.VarWChar, 2, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Qualif1", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Qualif11", System.Data.OleDb.OleDbType.VarWChar, 2, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Qualif1", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Qualif2", System.Data.OleDb.OleDbType.VarWChar, 2, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Qualif2", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Qualif21", System.Data.OleDb.OleDbType.VarWChar, 2, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Qualif2", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Qualif3", System.Data.OleDb.OleDbType.VarWChar, 2, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Qualif3", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Qualif31", System.Data.OleDb.OleDbType.VarWChar, 2, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Qualif3", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Qualif4", System.Data.OleDb.OleDbType.VarWChar, 2, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Qualif4", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Qualif41", System.Data.OleDb.OleDbType.VarWChar, 2, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Qualif4", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Qualif5", System.Data.OleDb.OleDbType.VarWChar, 2, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Qualif5", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Qualif51", System.Data.OleDb.OleDbType.VarWChar, 2, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Qualif5", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Qualif6", System.Data.OleDb.OleDbType.VarWChar, 2, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Qualif6", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Qualif61", System.Data.OleDb.OleDbType.VarWChar, 2, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Qualif6", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Qualif7", System.Data.OleDb.OleDbType.VarWChar, 2, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Qualif7", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Qualif71", System.Data.OleDb.OleDbType.VarWChar, 2, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Qualif7", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Qualif8", System.Data.OleDb.OleDbType.VarWChar, 2, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Qualif8", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Qualif81", System.Data.OleDb.OleDbType.VarWChar, 2, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Qualif8", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Qualif9", System.Data.OleDb.OleDbType.VarWChar, 2, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Qualif9", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Qualif91", System.Data.OleDb.OleDbType.VarWChar, 2, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Qualif9", System.Data.DataRowVersion.Original, Nothing))
        '
        'OleDbDeleteCommand1
        '
        Me.OleDbDeleteCommand1.CommandText = "DELETE FROM Autorizz WHERE (ID = ?) AND (Operazione = ? OR ? IS NULL AND Operazio" & _
        "ne IS NULL) AND (Qualif1 = ? OR ? IS NULL AND Qualif1 IS NULL) AND (Qualif2 = ? " & _
        "OR ? IS NULL AND Qualif2 IS NULL) AND (Qualif3 = ? OR ? IS NULL AND Qualif3 IS N" & _
        "ULL) AND (Qualif4 = ? OR ? IS NULL AND Qualif4 IS NULL) AND (Qualif5 = ? OR ? IS" & _
        " NULL AND Qualif5 IS NULL) AND (Qualif6 = ? OR ? IS NULL AND Qualif6 IS NULL) AN" & _
        "D (Qualif7 = ? OR ? IS NULL AND Qualif7 IS NULL) AND (Qualif8 = ? OR ? IS NULL A" & _
        "ND Qualif8 IS NULL) AND (Qualif9 = ? OR ? IS NULL AND Qualif9 IS NULL)"
        Me.OleDbDeleteCommand1.Connection = Me.OleDbConnection1
        Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Operazione", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Operazione", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Operazione1", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Operazione", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Qualif1", System.Data.OleDb.OleDbType.VarWChar, 2, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Qualif1", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Qualif11", System.Data.OleDb.OleDbType.VarWChar, 2, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Qualif1", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Qualif2", System.Data.OleDb.OleDbType.VarWChar, 2, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Qualif2", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Qualif21", System.Data.OleDb.OleDbType.VarWChar, 2, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Qualif2", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Qualif3", System.Data.OleDb.OleDbType.VarWChar, 2, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Qualif3", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Qualif31", System.Data.OleDb.OleDbType.VarWChar, 2, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Qualif3", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Qualif4", System.Data.OleDb.OleDbType.VarWChar, 2, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Qualif4", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Qualif41", System.Data.OleDb.OleDbType.VarWChar, 2, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Qualif4", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Qualif5", System.Data.OleDb.OleDbType.VarWChar, 2, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Qualif5", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Qualif51", System.Data.OleDb.OleDbType.VarWChar, 2, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Qualif5", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Qualif6", System.Data.OleDb.OleDbType.VarWChar, 2, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Qualif6", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Qualif61", System.Data.OleDb.OleDbType.VarWChar, 2, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Qualif6", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Qualif7", System.Data.OleDb.OleDbType.VarWChar, 2, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Qualif7", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Qualif71", System.Data.OleDb.OleDbType.VarWChar, 2, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Qualif7", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Qualif8", System.Data.OleDb.OleDbType.VarWChar, 2, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Qualif8", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Qualif81", System.Data.OleDb.OleDbType.VarWChar, 2, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Qualif8", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Qualif9", System.Data.OleDb.OleDbType.VarWChar, 2, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Qualif9", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Qualif91", System.Data.OleDb.OleDbType.VarWChar, 2, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Qualif9", System.Data.DataRowVersion.Original, Nothing))
        '
        'OleDbConnection1
        '
        Me.OleDbConnection1.ConnectionString = "Jet OLEDB:Global Partial Bulk Ops=2;Jet OLEDB:Registry Path=;Jet OLEDB:Database L" & _
        "ocking Mode=1;Jet OLEDB:Database Password=;Data Source=""E:\Programmi\Lancio\Arch" & _
        "\Gestione\Commesse.mdb"";Password=;Jet OLEDB:Engine Type=5;Jet OLEDB:Global Bulk " & _
        "Transactions=1;Provider=""Microsoft.Jet.OLEDB.4.0"";Jet OLEDB:System database=;Jet" & _
        " OLEDB:SFP=False;Extended Properties=;Mode=Share Deny None;Jet OLEDB:New Databas" & _
        "e Password=;Jet OLEDB:Create System Database=False;Jet OLEDB:Don't Copy Locale o" & _
        "n Compact=False;Jet OLEDB:Compact Without Replica Repair=False;User ID=Admin;Jet" & _
        " OLEDB:Encrypt Database=False"
        '
        'OleDbDataAdapter1
        '
        Me.OleDbDataAdapter1.DeleteCommand = Me.OleDbDeleteCommand1
        Me.OleDbDataAdapter1.InsertCommand = Me.OleDbInsertCommand1
        Me.OleDbDataAdapter1.SelectCommand = Me.OleDbSelectCommand1
        Me.OleDbDataAdapter1.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "Autorizz", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("ID", "ID"), New System.Data.Common.DataColumnMapping("Operazione", "Operazione"), New System.Data.Common.DataColumnMapping("Qualif1", "Qualif1"), New System.Data.Common.DataColumnMapping("Qualif2", "Qualif2"), New System.Data.Common.DataColumnMapping("Qualif3", "Qualif3"), New System.Data.Common.DataColumnMapping("Qualif4", "Qualif4"), New System.Data.Common.DataColumnMapping("Qualif5", "Qualif5"), New System.Data.Common.DataColumnMapping("Qualif6", "Qualif6"), New System.Data.Common.DataColumnMapping("Qualif7", "Qualif7"), New System.Data.Common.DataColumnMapping("Qualif8", "Qualif8"), New System.Data.Common.DataColumnMapping("Qualif9", "Qualif9")})})
        Me.OleDbDataAdapter1.UpdateCommand = Me.OleDbUpdateCommand1
        '
        'objdsCommesse
        '
        Me.objdsCommesse.DataSetName = "dsCommesse"
        Me.objdsCommesse.Locale = New System.Globalization.CultureInfo("it-IT")
        '
        'btnLoad
        '
        Me.btnLoad.Location = New System.Drawing.Point(10, 10)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(84, 23)
        Me.btnLoad.TabIndex = 0
        Me.btnLoad.Text = "&Carica"
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(356, 10)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(84, 23)
        Me.btnUpdate.TabIndex = 1
        Me.btnUpdate.Text = "Aggio&rna"
        '
        'lblID
        '
        Me.lblID.Location = New System.Drawing.Point(10, 43)
        Me.lblID.Name = "lblID"
        Me.lblID.TabIndex = 2
        Me.lblID.Text = "ID"
        '
        'lblOperazione
        '
        Me.lblOperazione.Location = New System.Drawing.Point(10, 76)
        Me.lblOperazione.Name = "lblOperazione"
        Me.lblOperazione.TabIndex = 3
        Me.lblOperazione.Text = "Operazione"
        '
        'lblQualif1
        '
        Me.lblQualif1.Location = New System.Drawing.Point(10, 109)
        Me.lblQualif1.Name = "lblQualif1"
        Me.lblQualif1.TabIndex = 4
        Me.lblQualif1.Text = "Qualif1"
        '
        'lblQualif2
        '
        Me.lblQualif2.Location = New System.Drawing.Point(10, 142)
        Me.lblQualif2.Name = "lblQualif2"
        Me.lblQualif2.TabIndex = 5
        Me.lblQualif2.Text = "Qualif2"
        '
        'lblQualif3
        '
        Me.lblQualif3.Location = New System.Drawing.Point(10, 175)
        Me.lblQualif3.Name = "lblQualif3"
        Me.lblQualif3.TabIndex = 6
        Me.lblQualif3.Text = "Qualif3"
        '
        'lblQualif4
        '
        Me.lblQualif4.Location = New System.Drawing.Point(10, 208)
        Me.lblQualif4.Name = "lblQualif4"
        Me.lblQualif4.TabIndex = 7
        Me.lblQualif4.Text = "Qualif4"
        '
        'editID
        '
        Me.editID.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.objdsCommesse, "Autorizz.ID"))
        Me.editID.Location = New System.Drawing.Point(120, 43)
        Me.editID.Name = "editID"
        Me.editID.TabIndex = 8
        Me.editID.Text = ""
        '
        'editOperazione
        '
        Me.editOperazione.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.objdsCommesse, "Autorizz.Operazione"))
        Me.editOperazione.Location = New System.Drawing.Point(120, 76)
        Me.editOperazione.Name = "editOperazione"
        Me.editOperazione.TabIndex = 9
        Me.editOperazione.Text = ""
        '
        'editQualif1
        '
        Me.editQualif1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.objdsCommesse, "Autorizz.Qualif1"))
        Me.editQualif1.Location = New System.Drawing.Point(120, 109)
        Me.editQualif1.Name = "editQualif1"
        Me.editQualif1.TabIndex = 10
        Me.editQualif1.Text = ""
        '
        'editQualif2
        '
        Me.editQualif2.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.objdsCommesse, "Autorizz.Qualif2"))
        Me.editQualif2.Location = New System.Drawing.Point(120, 142)
        Me.editQualif2.Name = "editQualif2"
        Me.editQualif2.TabIndex = 11
        Me.editQualif2.Text = ""
        '
        'editQualif3
        '
        Me.editQualif3.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.objdsCommesse, "Autorizz.Qualif3"))
        Me.editQualif3.Location = New System.Drawing.Point(120, 175)
        Me.editQualif3.Name = "editQualif3"
        Me.editQualif3.TabIndex = 12
        Me.editQualif3.Text = ""
        '
        'editQualif4
        '
        Me.editQualif4.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.objdsCommesse, "Autorizz.Qualif4"))
        Me.editQualif4.Location = New System.Drawing.Point(120, 208)
        Me.editQualif4.Name = "editQualif4"
        Me.editQualif4.TabIndex = 13
        Me.editQualif4.Text = ""
        '
        'lblQualif5
        '
        Me.lblQualif5.Location = New System.Drawing.Point(230, 43)
        Me.lblQualif5.Name = "lblQualif5"
        Me.lblQualif5.TabIndex = 14
        Me.lblQualif5.Text = "Qualif5"
        '
        'lblQualif6
        '
        Me.lblQualif6.Location = New System.Drawing.Point(230, 76)
        Me.lblQualif6.Name = "lblQualif6"
        Me.lblQualif6.TabIndex = 15
        Me.lblQualif6.Text = "Qualif6"
        '
        'lblQualif7
        '
        Me.lblQualif7.Location = New System.Drawing.Point(230, 109)
        Me.lblQualif7.Name = "lblQualif7"
        Me.lblQualif7.TabIndex = 16
        Me.lblQualif7.Text = "Qualif7"
        '
        'lblQualif8
        '
        Me.lblQualif8.Location = New System.Drawing.Point(230, 142)
        Me.lblQualif8.Name = "lblQualif8"
        Me.lblQualif8.TabIndex = 17
        Me.lblQualif8.Text = "Qualif8"
        '
        'lblQualif9
        '
        Me.lblQualif9.Location = New System.Drawing.Point(230, 175)
        Me.lblQualif9.Name = "lblQualif9"
        Me.lblQualif9.TabIndex = 18
        Me.lblQualif9.Text = "Qualif9"
        '
        'editQualif5
        '
        Me.editQualif5.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.objdsCommesse, "Autorizz.Qualif5"))
        Me.editQualif5.Location = New System.Drawing.Point(340, 43)
        Me.editQualif5.Name = "editQualif5"
        Me.editQualif5.TabIndex = 19
        Me.editQualif5.Text = ""
        '
        'editQualif6
        '
        Me.editQualif6.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.objdsCommesse, "Autorizz.Qualif6"))
        Me.editQualif6.Location = New System.Drawing.Point(340, 76)
        Me.editQualif6.Name = "editQualif6"
        Me.editQualif6.TabIndex = 20
        Me.editQualif6.Text = ""
        '
        'editQualif7
        '
        Me.editQualif7.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.objdsCommesse, "Autorizz.Qualif7"))
        Me.editQualif7.Location = New System.Drawing.Point(340, 109)
        Me.editQualif7.Name = "editQualif7"
        Me.editQualif7.TabIndex = 21
        Me.editQualif7.Text = ""
        '
        'editQualif8
        '
        Me.editQualif8.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.objdsCommesse, "Autorizz.Qualif8"))
        Me.editQualif8.Location = New System.Drawing.Point(340, 142)
        Me.editQualif8.Name = "editQualif8"
        Me.editQualif8.TabIndex = 22
        Me.editQualif8.Text = ""
        '
        'editQualif9
        '
        Me.editQualif9.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.objdsCommesse, "Autorizz.Qualif9"))
        Me.editQualif9.Location = New System.Drawing.Point(340, 175)
        Me.editQualif9.Name = "editQualif9"
        Me.editQualif9.TabIndex = 23
        Me.editQualif9.Text = ""
        '
        'btnNavFirst
        '
        Me.btnNavFirst.Location = New System.Drawing.Point(195, 241)
        Me.btnNavFirst.Name = "btnNavFirst"
        Me.btnNavFirst.Size = New System.Drawing.Size(40, 23)
        Me.btnNavFirst.TabIndex = 24
        Me.btnNavFirst.Text = "<<"
        '
        'btnNavPrev
        '
        Me.btnNavPrev.Location = New System.Drawing.Point(235, 241)
        Me.btnNavPrev.Name = "btnNavPrev"
        Me.btnNavPrev.Size = New System.Drawing.Size(35, 23)
        Me.btnNavPrev.TabIndex = 25
        Me.btnNavPrev.Text = "<"
        '
        'lblNavLocation
        '
        Me.lblNavLocation.BackColor = System.Drawing.Color.White
        Me.lblNavLocation.Location = New System.Drawing.Point(270, 241)
        Me.lblNavLocation.Name = "lblNavLocation"
        Me.lblNavLocation.Size = New System.Drawing.Size(95, 23)
        Me.lblNavLocation.TabIndex = 26
        Me.lblNavLocation.Text = "Nessun record"
        Me.lblNavLocation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnNavNext
        '
        Me.btnNavNext.Location = New System.Drawing.Point(365, 241)
        Me.btnNavNext.Name = "btnNavNext"
        Me.btnNavNext.Size = New System.Drawing.Size(35, 23)
        Me.btnNavNext.TabIndex = 27
        Me.btnNavNext.Text = ">"
        '
        'btnLast
        '
        Me.btnLast.Location = New System.Drawing.Point(400, 241)
        Me.btnLast.Name = "btnLast"
        Me.btnLast.Size = New System.Drawing.Size(40, 23)
        Me.btnLast.TabIndex = 28
        Me.btnLast.Text = ">>"
        '
        'DataFormAutorizz
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(442, 292)
        Me.Controls.Add(Me.btnLoad)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.lblID)
        Me.Controls.Add(Me.lblOperazione)
        Me.Controls.Add(Me.lblQualif1)
        Me.Controls.Add(Me.lblQualif2)
        Me.Controls.Add(Me.lblQualif3)
        Me.Controls.Add(Me.lblQualif4)
        Me.Controls.Add(Me.editID)
        Me.Controls.Add(Me.editOperazione)
        Me.Controls.Add(Me.editQualif1)
        Me.Controls.Add(Me.editQualif2)
        Me.Controls.Add(Me.editQualif3)
        Me.Controls.Add(Me.editQualif4)
        Me.Controls.Add(Me.lblQualif5)
        Me.Controls.Add(Me.lblQualif6)
        Me.Controls.Add(Me.lblQualif7)
        Me.Controls.Add(Me.lblQualif8)
        Me.Controls.Add(Me.lblQualif9)
        Me.Controls.Add(Me.editQualif5)
        Me.Controls.Add(Me.editQualif6)
        Me.Controls.Add(Me.editQualif7)
        Me.Controls.Add(Me.editQualif8)
        Me.Controls.Add(Me.editQualif9)
        Me.Controls.Add(Me.btnNavFirst)
        Me.Controls.Add(Me.btnNavPrev)
        Me.Controls.Add(Me.lblNavLocation)
        Me.Controls.Add(Me.btnNavNext)
        Me.Controls.Add(Me.btnLast)
        Me.Name = "DataFormAutorizz"
        Me.Text = "DataForm1"
        CType(Me.objdsCommesse, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        Try
            'Tenta di aggiornare l'origine dati.
            Me.UpdateDataSet()
        Catch eUpdate As System.Exception
            'Aggiungere qui il codice per la gestione degli errori.
            'Visualizza gli eventuali messaggi di errore.
            System.Windows.Forms.MessageBox.Show(eUpdate.Message)
        End Try
        Me.objdsCommesse_PositionChanged()

    End Sub
    Private Sub btnLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoad.Click
        Try
            'Tenta di caricare il dataset.
            Me.LoadDataSet()
        Catch eLoad As System.Exception
            'Aggiungere qui il codice per la gestione degli errori.
            'Visualizza gli eventuali messaggi di errore.
            System.Windows.Forms.MessageBox.Show(eLoad.Message)
        End Try
        Me.objdsCommesse_PositionChanged()

    End Sub
    Private Sub btnNavFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNavFirst.Click
        Me.BindingContext(objdsCommesse, "Autorizz").Position = 0
        Me.objdsCommesse_PositionChanged()

    End Sub
    Private Sub btnLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLast.Click
        Me.BindingContext(objdsCommesse, "Autorizz").Position = (Me.objdsCommesse.Tables("Autorizz").Rows.Count - 1)
        Me.objdsCommesse_PositionChanged()

    End Sub
    Private Sub btnNavPrev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNavPrev.Click
        Me.BindingContext(objdsCommesse, "Autorizz").Position = (Me.BindingContext(objdsCommesse, "Autorizz").Position - 1)
        Me.objdsCommesse_PositionChanged()

    End Sub
    Private Sub btnNavNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNavNext.Click
        Me.BindingContext(objdsCommesse, "Autorizz").Position = (Me.BindingContext(objdsCommesse, "Autorizz").Position + 1)
        Me.objdsCommesse_PositionChanged()

    End Sub
    Private Sub objdsCommesse_PositionChanged()
        Me.lblNavLocation.Text = (((Me.BindingContext(objdsCommesse, "Autorizz").Position + 1).ToString + " di  ") _
                    + Me.BindingContext(objdsCommesse, "Autorizz").Count.ToString)

    End Sub
    Public Sub UpdateDataSet()
        'Crea un nuovo dataset per le modifiche apportate al dataset principale.
        Dim objDataSetChanges As RoutBase1.dsCommesse = New RoutBase1.dsCommesse
        'Arresta eventuali modifiche in corso.
        Me.BindingContext(objdsCommesse, "Autorizz").EndCurrentEdit()
        'Acquisisci le modifiche apportate al dataset principale.
        objDataSetChanges = CType(objdsCommesse.GetChanges, RoutBase1.dsCommesse)
        'Controlla se vi sono modifiche.
        If (Not (objDataSetChanges) Is Nothing) Then
            Try
                'Occorre apportare alcune modifiche. Tentare pertanto di aggiornare l'origine dati
                'chiamando il metodo di aggiornamento e passandovi il dataset e i parametri.
                Me.UpdateDataSource(objDataSetChanges)
                objdsCommesse.Merge(objDataSetChanges)
                objdsCommesse.AcceptChanges()
            Catch eUpdate As System.Exception
                'Aggiungere qui il codice per la gestione degli errori.
                Throw eUpdate
            End Try
            'Aggiungere codice per controllare nel dataset restituito eventuali errori
            'inseriti nell'errore dell'oggetto row.
        End If

    End Sub
    Public Sub LoadDataSet()
        'Crea un nuovo dataset per i record restituiti dalla chiamata a FillDataSet.
        'Viene utilizzato un dataset temporaneo perché il riempimento del dataset esistente potrebbe
        'richiedere la riassociazione delle associazioni dati.
        Dim objDataSetTemp As RoutBase1.dsCommesse
        objDataSetTemp = New RoutBase1.dsCommesse
        Try
            'Tenta di riempire il dataset temporaneo.
            Me.FillDataSet(objDataSetTemp)
        Catch eFillDataSet As System.Exception
            'Aggiungere qui il codice per la gestione degli errori.
            Throw eFillDataSet
        End Try
        Try
            'Rimuove i vecchi record dal dataset.
            objdsCommesse.Clear()
            'Unisce i record al dataset principale.
            objdsCommesse.Merge(objDataSetTemp)
        Catch eLoadMerge As System.Exception
            'Aggiungere qui il codice per la gestione degli errori.
            Throw eLoadMerge
        End Try

    End Sub
    Public Sub UpdateDataSource(ByVal ChangedRows As RoutBase1.dsCommesse)
        Try
            'È necessario aggiornare l'origine dati solo se vi sono modifiche in sospeso.
            If (Not (ChangedRows) Is Nothing) Then
                'Apri la connessione.
                Me.OleDbConnection1.Open()
                'Tenta di aggiornare l'origine dati.
                OleDbDataAdapter1.Update(ChangedRows)
            End If
        Catch updateException As System.Exception
            'Aggiungere qui il codice per la gestione degli errori.
            Throw updateException
        Finally
            'Chiudi la connessione indipendentemente dalla generazione dell'eccezione.
            Me.OleDbConnection1.Close()
        End Try

    End Sub
    Public Sub FillDataSet(ByVal dataSet As RoutBase1.dsCommesse)
        'Disattiva la verifica dei vincoli prima del riempimento del dataset.
        'Consente agli adattatori di riempire il dataset senza difficoltà
        'per dipendenze tra le tabelle
        dataSet.EnforceConstraints = False
        Try
            'Apri la connessione.
            Me.OleDbConnection1.Open()
            'Tenta di riempire il dataset tramite OleDbDataAdapter1.
            Me.OleDbDataAdapter1.Fill(dataSet)
        Catch fillException As System.Exception
            'Aggiungere qui il codice per la gestione degli errori.
            Throw fillException
        Finally
            'Riattivare la verifica dei vincoli.
            dataSet.EnforceConstraints = True
            'Chiudi la connessione indipendentemente dalla generazione dell'eccezione.
            Me.OleDbConnection1.Close()
        End Try

    End Sub
End Class
