Public Class perParticipantesTreinamento
    Inherits AcessoBd

#Region "Variáveis"
    Private objProximoID As New ProximoID
#End Region

#Region "Métodos públicos"

    Public Sub inserirParticipantesTreinamento(ByVal iIdAgendamento As Integer, _
                                               ByVal iIdFuncionario As Integer)

        Dim sSql As String

        Try

            sSql = " INSERT INTO Participantes "
            sSql &= "  ( "
            sSql &= "       IDAgendamento, "
            sSql &= "       IDFuncionario "
            sSql &= "  ) "
            sSql &= " VALUES "
            sSql &= "  ( "
            sSql &= "       @IDAgendamento, "
            sSql &= "       @IDFuncionario "
            sSql &= "  ) "

            With MyBase.SQLCmd.Parameters
                .Clear()
                .AddWithValue("@IDAgendamento", iIdAgendamento)
                .AddWithValue("@IDFuncionario", iIdFuncionario)
            End With

            MyBase.executarAcao(sSql)

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao tentar inserir os dados dos Participantes do Treinamento." & Environment.NewLine & ex.Message)
        End Try

    End Sub

    Public Sub excluirParticipantesTreinamento(ByVal iIdAgendamento As Integer, _
                                               ByVal iIdFuncionario As Integer)

        Dim sSql As String

        Try

            sSql = "  DELETE FROM "
            sSql &= "   Participantes "
            sSql &= " WHERE "
            sSql &= "   IDAgendamento = @IDAgendamento "
            If iIdFuncionario > 0 Then
                sSql &= "AND IDFuncionario = @IDFuncionario "
            End If

            With MyBase.SQLCmd.Parameters
                .Clear()
                .AddWithValue("@IDAgendamento", iIdAgendamento)
                .AddWithValue("@IDFuncionario", iIdFuncionario)
            End With

            MyBase.executarAcao(sSql)

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao tentar excluir os dados dos Participantes do Treinamento." & Environment.NewLine & ex.Message)
        End Try

    End Sub

    Public Function selecionarParticipantesTreinamento(ByVal iIdAgendamento As Integer) As System.Data.DataSet

        Dim sSql As String
        Dim dsDados As New DataSet

        Try

            sSql = "  SELECT  "
            sSql &= "   Participantes.IDFuncionario, "
            sSql &= "   Funcionario.Nome "
            sSql &= " FROM "
            sSql &= "   Participantes "
            sSql &= " INNER JOIN Funcionario ON Participantes.IDFuncionario = Funcionario.IDFuncionario "
            sSql &= " WHERE  "
            sSql &= "   Participantes.IDAgendamento = @IdAgendamento "

            With MyBase.SQLCmd.Parameters
                .Clear()
                .AddWithValue("@IdAgendamento", iIdAgendamento)
            End With

            dsDados = MyBase.executarConsulta(sSql, "Participantes")

            Return dsDados

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao tentar selecionar os dados dos Participantes do Treinamento." & Environment.NewLine & ex.Message)
        End Try

    End Function

#End Region

End Class
