Imports System
Imports System.Data
Imports System.Data.OleDb
Imports Microsoft.VisualBasic
Module ADONET

    Public Class Sample

        Public Shared Sub Main()
            Dim nwindConn As OleDbConnection = New OleDbConnection("Provider=SQLOLEDB;Data Source=localhost;" & _
                                                                   "Integrated Security=SSPI;Initial Catalog=northwind")

            Dim catCMD As OleDbCommand = nwindConn.CreateCommand()
            catCMD.CommandText = "SELECT CategoryID, CategoryName FROM Categories"

            nwindConn.Open()

            Dim myReader As OleDbDataReader = catCMD.ExecuteReader()

            Do While myReader.Read()
                Console.WriteLine(vbTab & "{0}" & vbTab & "{1}", myReader.GetInt32(0), myReader.GetString(1))
            Loop

            myReader.Close()
            nwindConn.Close()
        End Sub
        Sub main1()
            'creazione del recordset
            Dim nwindConn As OleDbConnection = New OleDbConnection("Provider=SQLOLEDB;Data Source=localhost;" & _
                                                                   "Integrated Security=SSPI;Initial Catalog=northwind")

            Dim selectCMD As OleDbCommand = New OleDbCommand("SELECT CustomerID, CompanyName FROM Customers", nwindConn)
            selectCMD.CommandTimeout = 30

            Dim custDA As OleDbDataAdapter = New OleDbDataAdapter
            custDA.SelectCommand = selectCMD

            Dim custDS As DataSet = New DataSet
            custDA.Fill(custDS, "Customers")
            'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
            Dim catDA As OleDbDataAdapter = New OleDbDataAdapter("SELECT CategoryID, CategoryName FROM Categories", nwindConn)

            catDA.UpdateCommand = New OleDbCommand("UPDATE Categories SET CategoryName = ? " & _
                                                   "WHERE CategoryID = ?", nwindConn)

            catDA.UpdateCommand.Parameters.Add("@CategoryName", OleDbType.VarChar, 15, "CategoryName")

            Dim workParm As OleDbParameter = catDA.UpdateCommand.Parameters.Add("@CategoryID", OleDbType.Integer)
            workParm.SourceColumn = "CategoryID"
            workParm.SourceVersion = DataRowVersion.Original

            Dim catDS As DataSet = New DataSet
            catDA.Fill(catDS, "Categories")

            Dim cRow As DataRow = catDS.Tables("Categories").Rows(0)
            cRow("CategoryName") = "New Category"

            catDA.Update(catDS)

        End Sub
    End Class

End Module
