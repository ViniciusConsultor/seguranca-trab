Imports System.ComponentModel
Imports System.Configuration.Install
Imports System.IO
Imports System.Reflection
Imports System.Data.SqlClient

Public Class VbDeployInstaller
    Dim masterConnection As New System.Data.SqlClient.SqlConnection

    Public Sub New()
        MyBase.New()

        'This call is required by the Component Designer.
        InitializeComponent()

        'Add initialization code after the call to InitializeComponent

    End Sub

    Private Function GetSql(ByVal Name As String) As String
        Try

            ' Gets the current assembly.
            Dim Asm As [Assembly] = [Assembly].GetExecutingAssembly()

            ' Resources are named using a fully qualified name.
            Dim strm As Stream = Asm.GetManifestResourceStream( _
              Asm.GetName().Name + "." + Name)

            ' Reads the contents of the embedded file.
            Dim reader As StreamReader = New StreamReader(strm)
            Return reader.ReadToEnd()

        Catch ex As Exception
            MsgBox("In GetSQL: " & ex.Message)
            Throw ex
        End Try
    End Function

    Private Sub ExecuteSql(ByVal DatabaseName As String, ByVal Sql As String)
        Dim Command As New SqlClient.SqlCommand(Sql, masterConnection)

        ' Initialize the connection, open it, and set it to the "master" database
        masterConnection.ConnectionString = My.Settings.masterConnectionString
        Command.Connection.Open()
        Command.Connection.ChangeDatabase(DatabaseName)
        Try
            Command.ExecuteNonQuery()
        Finally
            ' Closing the connection should be done in a Finally block
            Command.Connection.Close()
        End Try
    End Sub

    Protected Sub AddDBTable(ByVal strDBName As String)
        Try
            ' Creates the tables.
            ExecuteSql(strDBName, GetSql("sql.txt"))

        Catch ex As Exception
            ' Reports any errors and abort.
            MsgBox("In exception handler: " & ex.Message)
            Throw ex
        End Try
    End Sub

    Public Overrides Sub Install(ByVal stateSaver As  _
      System.Collections.IDictionary)

        MyBase.Install(stateSaver)
        AddDBTable(Me.Context.Parameters.Item("dbname"))
    End Sub

End Class
