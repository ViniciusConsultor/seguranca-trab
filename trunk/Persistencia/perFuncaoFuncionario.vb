Public Class perFuncaoFuncionario
    Inherits AcessoBd

    Public Sub inserirFuncaoFuncionario(ByVal iIDFuncionario As Integer, _
                                        ByVal iIDFuncao As Integer, _
                                        ByVal dtDataRescisao As Date)
        Dim sSql As String
        Dim dtData As Date

        Try
            dtData = MyBase.Data_Servidor

            sSql = "INSERT INTO Funcao_Funcionario" & vbCrLf
            sSql &= "("
            sSql &= "  IDFuncao," & vbCrLf
            sSql &= "  IDFuncionario," & vbCrLf
            sSql &= "  DataInicio, " & vbCrLf
            sSql &= "  DataFim " & vbCrLf
            sSql &= ")" & vbCrLf
            sSql &= "VALUES" & vbCrLf
            sSql &= "(" & vbCrLf
            sSql &= "   @IDFuncao," & vbCrLf
            sSql &= "   @IDFuncionario," & vbCrLf
            sSql &= "   @DataInicio, " & vbCrLf
            sSql &= "   @DataFim" & vbCrLf
            sSql &= ")"

            With MyBase.SQLCmd.Parameters
                .Clear()
                .AddWithValue("@IDFuncao", iIDFuncao)
                .AddWithValue("@IDFuncionario", iIDFuncionario)
                .AddWithValue("@DataInicio", dtData)
                .AddWithValue("@DataFim", IIf(dtDataRescisao = Nothing, DBNull.Value, dtDataRescisao))
            End With

            MyBase.executarAcao(sSql)

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao tentar inserir os dados do Funcionário." & Environment.NewLine & ex.Message)
        End Try

    End Sub

    Public Function Retorna_Funcao_Vigente(ByVal iIDFuncionario As Integer) As Integer
        Dim sSql As String
        Dim iIDFuncao As Integer

        Try
            sSql = " SELECT IDFuncao" & vbCrLf
            sSql &= " FROM Funcao_Funcionario " & vbCrLf
            sSql &= " WHERE IDFuncionario = @IDFuncionario" & vbCrLf
            sSql &= " AND DataInicio = (SELECT MAX(DataInicio) FROM Funcao_Funcionario WHERE IDFuncionario = @IDFuncionario) "

            With MyBase.SQLCmd.Parameters
                .Clear()
                .AddWithValue("@IDFuncionario", iIDFuncionario)
            End With

            iIDFuncao = MyBase.executarConsultaCampo(sSql)

            Return iIDFuncao

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao tentar selecionar os dados do Funcionário." & Environment.NewLine & ex.Message)
        End Try

    End Function

    Public Sub atualizarDataFimFuncaoFuncionario(ByVal iIDFuncionario As Integer, _
                                                 ByVal iIDFuncao As Integer, _
                                                 ByVal dtDataRescisao As Date)
        Dim sSql As String

        Try

            sSql = "UPDATE Funcao_Funcionario" & vbCrLf
            sSql &= "  SET DataFim = @Data" & vbCrLf
            sSql &= "WHERE IDFuncionario = @IDFuncionario" & vbCrLf
            sSql &= "  AND IDFuncao = @IDFuncao" & vbCrLf

            With MyBase.SQLCmd.Parameters
                .Clear()
                .AddWithValue("@Data", IIf(dtDataRescisao = Nothing, DBNull.Value, dtDataRescisao))
                .AddWithValue("@IDFuncionario", iIDFuncionario)
                .AddWithValue("@IDFuncao", iIDFuncao)
            End With

            MyBase.executarAcao(sSql)

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao tentar atualizar os dados do Funcionário." & Environment.NewLine & ex.Message)
        End Try

    End Sub

End Class
