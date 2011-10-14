Public Class perConfig
    Inherits AcessoBd
    Public Function Retornar_Configuracao(ByVal sCampo As String) As DataTable
        Dim sSql As String
        Dim dtConfig As New DataTable

        sSql = "Select  " & sCampo
        sSql &= "From Configuracoes "

        Return MyBase.executarConsulta(sSql)

    End Function
    Public Function Retornar_Versao() As Integer
        Dim sSql As String
        Dim dtConfig As New DataTable

        sSql = "Select Versao "
        sSql &= "From Configuracoes "
        Try
            dtConfig = MyBase.executarConsulta(sSql)
            If (dtConfig.Rows.Count > 0) Then
                Return dtConfig.Rows(0).Item("Versao")
            Else
                Return 0
            End If

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao retornar a versão do banco de dados.  " & _
                                 Environment.NewLine & ex.Message)
        End Try

    End Function
    Public Sub Setar_Versao(ByVal iVersao As Integer)
        Dim sSql As String

        Try
            sSql = "Update Configuracoes Set Versao = @Versao "

            With MyBase.SQLCmd.Parameters
                .Clear()
                .AddWithValue("Versao ", iVersao)
            End With

            MyBase.executarAcao(sSql)

        Catch ex As Exception

        End Try

    End Sub

End Class
