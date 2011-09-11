Public Class AcessoBd

#Region "Enumerações"

    Public Enum eFinalizacaoTransacao As Byte
        Commit = 1
        Rollback = 2
    End Enum

#End Region

#Region "Campos de Instância "

    Private SQLCnn As New System.Data.SqlClient.SqlConnection
    Public SQLCmd As New System.Data.SqlClient.SqlCommand
    Private SQLDa As New System.Data.SqlClient.SqlDataAdapter
    Private SQLTr As System.Data.SqlClient.SqlTransaction

#End Region

#Region "Propriedades"

    Public Property TransacaoOrigem() As Object
        Get
            Return Me.SQLTr
        End Get
        Set(ByVal Value As Object)
            Me.SQLTr = DirectCast(Value, System.Data.SqlClient.SqlTransaction)
        End Set
    End Property

#End Region

#Region "Métodos privados"

    Public Sub New(ByVal sStringConexaoBD As String)
        Me.SQLCnn.ConnectionString = sStringConexaoBD
        Me.SQLCmd.Connection = Me.SQLCnn
        Me.SQLCmd.CommandType = CommandType.Text
    End Sub

    Private Sub abrirConexao()

        If Me.SQLTr Is Nothing Then
            If Me.SQLCnn.State = ConnectionState.Closed Then
                Me.SQLCmd.Connection = Me.SQLCnn
                Me.SQLCmd.CommandType = CommandType.Text
                Me.SQLCnn.Open()
                Me.SQLCmd.Connection = Me.SQLCnn
            End If
        Else
            Me.SQLCmd.Transaction = Me.SQLTr
            Me.SQLCmd.Connection = Me.SQLTr.Connection
        End If

    End Sub

    Private Sub fecharConexao()
        If Me.SQLTr Is Nothing Then
            If Me.SQLCnn.State <> ConnectionState.Closed Then
                Me.SQLCnn.Close()
            End If
        End If
    End Sub

#End Region

#Region " Métodos Protegidos "

    Private Sub iniciarControleTransacional()
        If Me.SQLTr Is Nothing Then
            Me.abrirConexao()
            Me.SQLTr = Me.SQLCnn.BeginTransaction()
        End If
    End Sub

    Private Sub finalizarControleTransacional(ByVal iFinalizacaoTransacao As eFinalizacaoTransacao)
        If Not Me.SQLTr Is Nothing Then
            If iFinalizacaoTransacao = eFinalizacaoTransacao.Commit Then
                Me.SQLTr.Commit()
            Else
                Me.SQLTr.Rollback()
            End If
            Me.SQLTr = Nothing
            Me.fecharConexao()
        End If
    End Sub

#End Region

#Region "Métodos públicos"

    Public Function executarAcao(ByRef sSql As String) As Int32
        Dim iRetorno As Int32
        Try
            Me.abrirConexao()
            Me.SQLCmd.CommandType = CommandType.Text
            Me.SQLCmd.CommandText = sSql
            iRetorno = Me.SQLCmd.ExecuteNonQuery()
            Return iRetorno
        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao tentar executar a sentença SQL de ação no Banco de Dados." & Environment.NewLine & Environment.NewLine & ex.Message)
        Finally
            Me.fecharConexao()
        End Try

    End Function

    Public Function executarConsulta(ByRef sSql As String, _
                                        ByVal sNomeTabela As String) As DataSet
        Dim dsRetorno As New DataSet

        Try
            Me.abrirConexao()
            Me.SQLCmd.CommandType = CommandType.Text
            Me.SQLCmd.CommandText = sSql
            Me.SQLDa.SelectCommand = Me.SQLCmd
            Me.SQLDa.Fill(dsRetorno, sNomeTabela)
            Return dsRetorno
        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao tentar executar a sentença SQL de consulta no Banco de Dados." & Environment.NewLine & Environment.NewLine & ex.Message)
        Finally
            Me.fecharConexao()
        End Try

    End Function

    Public Function executarConsulta(ByRef sSql As String) As DataTable
        Dim dsRetorno As New DataSet

        Try
            Me.abrirConexao()
            Me.SQLCmd.CommandType = CommandType.Text
            Me.SQLCmd.CommandText = sSql
            Me.SQLDa.SelectCommand = Me.SQLCmd
            Me.SQLDa.Fill(dsRetorno, "Tabela")
            Return dsRetorno.Tables(0)
        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao tentar executar a sentença SQL de consulta no Banco de Dados." & Environment.NewLine & Environment.NewLine & ex.Message)
        Finally
            Me.fecharConexao()
        End Try
    End Function

    Public Function executarConsultaCampo(ByRef sSql As String) As Object

        Dim objRetorno As Object

        Try
            Me.abrirConexao()
            Me.SQLCmd.CommandType = CommandType.Text
            Me.SQLCmd.CommandText = sSql
            objRetorno = Me.SQLCmd.ExecuteScalar
            If objRetorno Is DBNull.Value Then
                objRetorno = 0
            End If
            Return objRetorno
        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao tentar executar a sentença SQL de consulta de campo no Banco de Dados." & Environment.NewLine & Environment.NewLine & ex.Message)
        Finally
            Me.fecharConexao()
        End Try
    End Function

    Public Function Data_Servidor() As Date

        Dim sSql As String
        Dim Data As String

        Try
            sSql = "SELECT GETDATE() as Data_Servidor"

            Data = executarConsultaCampo(sSql)

            If (IsDate(Data)) Then
                Return Data
            Else
                Return Date.MinValue
            End If

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao realizar a consulta de dada no banco de dados." & Environment.NewLine & ex.Message)
        End Try

    End Function

#End Region
End Class
