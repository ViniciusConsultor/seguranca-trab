Public Class ctrConexaoBD

    Public Function conexaoBancoDados(ByVal sServidor As String, _
                                      ByVal sBancoDados As String, _
                                      ByVal sLogin As String, _
                                      ByVal sSenha As String) As String

        Return Persistencia.Globais.montaStringConexao(sSenha.ToLower, _
                                                       sBancoDados.ToLower, _
                                                       sServidor.ToLower, _
                                                       sLogin.ToLower)


    End Function

    Public Function testarConexao(ByVal sStringConexao As String) As Boolean

        Dim cnn As New SqlClient.SqlConnection

        Try

            cnn.ConnectionString = sStringConexao

            cnn.Open()

            Return True
        Catch
            Return False
        Finally
            cnn.Close()
        End Try

    End Function
End Class
