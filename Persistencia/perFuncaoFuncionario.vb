Public Class perFuncaoFuncionario
    Inherits AcessoBd

    Public Sub inserirFuncaoFuncionario(ByVal iIDFuncionario As Integer, _
                                        ByVal iIDFuncao As Integer, _
                                        ByVal dtDataRescisao As Date)
        Dim sSql As String
        Dim dtData As Date

        Try
            dtData = MyBase.Data_Servidor

            sSql = "INSERT INTO Funcao_Funcionario "
            sSql &= "( "
            sSql &= "  IDFuncao, "
            sSql &= "  IDFuncionario, "
            sSql &= "  DataInicio,  "
            sSql &= "  DataFim  "
            sSql &= ") "
            sSql &= "VALUES "
            sSql &= "( "
            sSql &= "   @IDFuncao, "
            sSql &= "   @IDFuncionario, "
            sSql &= "   @DataInicio,  "
            sSql &= "   @DataFim "
            sSql &= ") "

            With MyBase.SQLCmd.Parameters
                .Clear()
                .AddWithValue("@IDFuncao ", iIDFuncao)
                .AddWithValue("@IDFuncionario ", iIDFuncionario)
                .AddWithValue("@DataInicio ", dtData)
                .AddWithValue("@DataFim ", IIf(dtDataRescisao = Nothing, DBNull.Value, dtDataRescisao))
            End With

            MyBase.executarAcao(sSql)

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao tentar inserir os dados do Funcionário. " & Environment.NewLine & ex.Message)
        End Try

    End Sub

    Public Function Retorna_Funcao_Vigente(ByVal iIDFuncionario As Integer) As Integer
        Dim sSql As String
        Dim iIDFuncao As Integer

        Try
            sSql = " SELECT IDFuncao "
            sSql &= " FROM Funcao_Funcionario  "
            sSql &= " WHERE IDFuncionario = @IDFuncionario "
            sSql &= " AND DataInicio = (SELECT MAX(DataInicio) FROM Funcao_Funcionario WHERE IDFuncionario = @IDFuncionario)  "

            With MyBase.SQLCmd.Parameters
                .Clear()
                .AddWithValue("@IDFuncionario ", iIDFuncionario)
            End With

            iIDFuncao = MyBase.executarConsultaCampo(sSql)

            Return iIDFuncao

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao tentar selecionar os dados do Funcionário. " & Environment.NewLine & ex.Message)
        End Try

    End Function

    Public Sub atualizarDataFimFuncaoFuncionario(ByVal iIDFuncionario As Integer, _
                                                 ByVal iIDFuncao As Integer, _
                                                 ByVal dtDataRescisao As Date)
        Dim sSql As String

        Try

            sSql = "UPDATE Funcao_Funcionario "
            sSql &= "  SET DataFim = @Data "
            sSql &= "WHERE IDFuncionario = @IDFuncionario "
            sSql &= "  AND IDFuncao = @IDFuncao "

            With MyBase.SQLCmd.Parameters
                .Clear()
                .AddWithValue("@Data ", IIf(dtDataRescisao = Nothing, DBNull.Value, dtDataRescisao))
                .AddWithValue("@IDFuncionario ", iIDFuncionario)
                .AddWithValue("@IDFuncao ", iIDFuncao)
            End With

            MyBase.executarAcao(sSql)

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao tentar atualizar os dados do Funcionário. " & Environment.NewLine & ex.Message)
        End Try

    End Sub

End Class
