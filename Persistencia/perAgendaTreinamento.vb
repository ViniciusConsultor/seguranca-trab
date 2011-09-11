Public Class perAgendaTreinamento
    Inherits AcessoBd

#Region "Variáveis"
    Private objProximoID As New ProximoID
#End Region

#Region "Propriedades"

    ReadOnly Property sqlConsulta(ByVal iIdEmpresa As Integer) As String
        Get
            Dim sSql As String
            sSql = "  SELECT Agenda.IDAgendamento as Código,  "
            sSql &= "   Treinamento.Descricao as Treinamento, "
            sSql &= "   Data "
            sSql &= " FROM "
            sSql &= "   Agenda "
            sSql &= " INNER JOIN Treinamento ON Agenda.IDTreinamento = Treinamento.IDTreinamento "
            sSql &= " WHERE "
            sSql &= "   Agenda.IDEmpresa = " & iIdEmpresa
            Return sSql
        End Get
    End Property

    ReadOnly Property sqlConsulta(ByVal sIdsEmpresa As String) As String
        Get
            Dim sSql As String
            sSql = "  SELECT Agenda.IDAgendamento,  "
            sSql &= "   Treinamento.Descricao as Treinamento, "
            sSql &= "   Data "
            sSql &= " FROM "
            sSql &= "   Agenda "
            sSql &= " INNER JOIN Treinamento ON Agenda.IDTreinamento = Treinamento.IDTreinamento "
            If sIdsEmpresa <> String.Empty Then
                sSql &= " WHERE "
                sSql &= "   Agenda.IDEmpresa IN ( " & sIdsEmpresa & " ) "
            End If
            Return sSql
        End Get
    End Property

#End Region

#Region "Métodos públicos"

    Public Function Inserir_Agendamento(ByVal iIdTreinamento As Integer, _
                                        ByVal iIdEmpresa As Integer, _
                                        ByVal dtData As Date, _
                                        ByVal sDescricao As String, _
                                        ByVal sMinistrante As String, _
                                        ByVal sCargaHoraria As String) As Integer

        Dim sSql As String
        Dim iIdAgendamento As Integer

        Try

            sSql = " INSERT INTO Agenda "
            sSql &= "  ( "
            sSql &= "       IDAgendamento, "
            sSql &= "       IDTreinamento, "
            sSql &= "       IDEmpresa, "
            sSql &= "       Data, "
            sSql &= "       Descricao, "
            sSql &= "       Ministrante, "
            sSql &= "       CargaHoraria"
            sSql &= "  ) "
            sSql &= " VALUES "
            sSql &= "  ( "
            sSql &= "       @IDAgendamento, "
            sSql &= "       @IDTreinamento, "
            sSql &= "       @IDEmpresa, "
            sSql &= "       @Data, "
            sSql &= "       @Descricao, "
            sSql &= "       @Ministrante,"
            sSql &= "       @CargaHoraria"
            sSql &= "  ) "

            iIdAgendamento = objProximoID.BuscaID("IDAgendamento", "Agenda")

            With MyBase.SQLCmd.Parameters
                .Clear()
                .AddWithValue("@IDAgendamento", iIdAgendamento)
                .AddWithValue("@IDTreinamento", iIdTreinamento)
                .AddWithValue("@IDEmpresa", iIdEmpresa)
                .AddWithValue("@Data", Conversao.ToDateTime(dtData).ToString("dd/MM/yyyy HH:mm"))
                .AddWithValue("@Descricao", sDescricao)
                .AddWithValue("@Ministrante", sMinistrante)
                .AddWithValue("@CargaHoraria", sCargaHoraria)
            End With

            MyBase.executarAcao(sSql)

            Return iIdAgendamento

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao tentar inserir os dados da Agenda de Treinamento." & Environment.NewLine & ex.Message)
        End Try

    End Function

    Public Sub Atualizar_Agendamento(ByVal iIdTreinamento As Integer, _
                                     ByVal iIdAgendamento As Integer, _
                                     ByVal dtData As Date, _
                                     ByVal sDescricao As String, _
                                     ByVal sMinistrante As String, _
                                     ByVal sCargaHoraria As String)

        Dim sSql As String

        Try

            sSql = "  UPDATE Agenda SET "
            sSql &= "   IDTreinamento = @IDTreinamento, "
            sSql &= "   Data = @Data, "
            sSql &= "   Descricao = @Descricao, "
            sSql &= "   Ministrante = @Ministrante, "
            sSql &= "   CargaHoraria = @CargaHoraria"
            sSql &= " WHERE "
            sSql &= "   IDAgendamento = @IDAgendamento "

            With MyBase.SQLCmd.Parameters
                .Clear()
                .AddWithValue("@IDTreinamento", iIdTreinamento)
                .AddWithValue("@Data", Conversao.ToDateTime(dtData).ToString("dd/MM/yyyy HH:mm"))
                .AddWithValue("@Descricao", sDescricao)
                .AddWithValue("@Ministrante", sMinistrante)
                .AddWithValue("@IDAgendamento", iIdAgendamento)
                .AddWithValue("@CargaHoraria", sCargaHoraria)
            End With

            MyBase.executarAcao(sSql)

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao tentar atualizar os dados da Agenda de Treinamento." & Environment.NewLine & ex.Message)
        End Try

    End Sub

    Public Sub Excluir_Agendamento(ByVal iIdAgendamento As Integer)

        Dim sSql As String

        Try

            sSql = "  DELETE FROM "
            sSql &= "   Agenda "
            sSql &= " WHERE "
            sSql &= "   IDAgendamento = @IDAgendamento "

            With MyBase.SQLCmd.Parameters
                .Clear()
                .AddWithValue("@IDAgendamento", iIdAgendamento)
            End With

            MyBase.executarAcao(sSql)

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao tentar excluir os dados da Agenda de Treinamento." & Environment.NewLine & ex.Message)
        End Try

    End Sub

    Public Function Selecionar_Agendamento(ByVal iIdAgendamento As Integer) As System.Data.DataSet

        Dim sSql As String
        Dim dsDados As New DataSet

        Try

            sSql = "  SELECT  " & vbCrLf
            sSql &= "   Agenda.*, " & vbCrLf
            sSql &= "   T.Descricao as Treinamento, " & vbCrLf
            sSql &= "   TE.Validade " & vbCrLf
            sSql &= " FROM " & vbCrLf
            sSql &= "   Agenda " & vbCrLf
            sSql &= " INNER JOIN Treinamento T ON T.IDTreinamento = Agenda.IdTreinamento " & vbCrLf
            sSql &= " INNER JOIN Treinamento_Empresa TE ON TE.IDTreinamento = T.IDTreinamento" & vbCrLf
            sSql &= "                                  AND TE.IDEmpresa = @IDEmpresa" & vbCrLf
            If iIdAgendamento > 0 Then
                sSql &= " WHERE  "
                sSql &= "   IDAgendamento = @IdAgendamento "
            End If

            With MyBase.SQLCmd.Parameters
                .Clear()
                If iIdAgendamento > 0 Then
                    .AddWithValue("@IDEmpresa", Globais.iIDEmpresa)
                    .AddWithValue("@IdAgendamento", iIdAgendamento)
                End If
            End With

            dsDados = MyBase.executarConsulta(sSql, "Agenda")

            Return dsDados

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao tentar selecionar os dados da Agenda de Treinamento." & Environment.NewLine & ex.Message)
        End Try

    End Function

    Public Function selecionarCampo(ByVal iIdAgendamento As Integer, _
                                    ByVal sCampo As String) As Object

        Dim sSql As String

        Try

            sSql = "  SELECT " & sCampo
            sSql &= "   FROM Agenda "
            sSql &= " WHERE  "
            sSql &= "   IDAgendamento = @IDAgendamento "

            With MyBase.SQLCmd.Parameters
                .Clear()
                .AddWithValue("@IDAgendamento", iIdAgendamento)
            End With

            Return MyBase.executarConsultaCampo(sSql)

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao tentar selecionar os dados da Agenda de Treinamento." & Environment.NewLine & ex.Message)
        End Try

    End Function

    Public Function selecionarParticipantesTreinamento(ByVal iIdEmpresa As Integer, _
                                                       ByVal iIdTreinamento As Integer, _
                                                       ByVal iIdAgendamento As Integer, _
                                                       ByVal dtDataInicial As Date, _
                                                       ByVal dtDataFinal As Date, _
                                                       ByVal sIdsEmpresasAcesso As String) As DataSet

        Dim sSql As String

        Try

            sSql = "  SELECT "
            sSql &= "   Empresa.IDEmpresa, "
            sSql &= "   Empresa.NomeFantasia, "
            sSql &= "   Empresa.Logomarca,"
            sSql &= "   Treinamento.IDTreinamento, "
            sSql &= "   Treinamento.Descricao as TipoTreinamento, "
            sSql &= "   Agenda.IDAgendamento, "
            sSql &= "   Agenda.Descricao as Treinamento, "
            sSql &= "   Agenda.Ministrante, "
            sSql &= "   Agenda.Data, "
            sSql &= "   Funcionario.Nome, "
            sSql &= "   Funcionario.CPF "
            sSql &= " FROM  "
            sSql &= "   Agenda "
            sSql &= " INNER JOIN Empresa ON Empresa.IDEmpresa = Agenda.IDEmpresa "
            sSql &= " INNER JOIN Treinamento ON Treinamento.IDTreinamento = Agenda.IDTreinamento "
            sSql &= " INNER JOIN Participantes ON Agenda.IDAgendamento = Participantes.IDAgendamento "
            sSql &= " INNER JOIN Funcionario ON Participantes.IDFuncionario = Funcionario.IDFuncionario"
            sSql &= " WHERE  "
            sSql &= "   1 = 1 "

            If iIdEmpresa > 0 Then
                sSql &= " AND Empresa.IDEmpresa = @IDEmpresa "
            ElseIf sIdsEmpresasAcesso <> String.Empty Then
                sSql &= " AND Empresa.IDEmpresa IN ( " & sIdsEmpresasAcesso & " ) "
            End If

            If iIdTreinamento > 0 Then
                sSql &= " AND  Treinamento.IDTreinamento = @IDTreinamento "
            End If

            If iIdAgendamento > 0 Then
                sSql &= " AND  Agenda.IDAgendamento = @IDAgendamento "
            End If

            If dtDataInicial <> Nothing AndAlso dtDataFinal <> Nothing Then
                sSql &= " AND  Agenda.Data BETWEEN @DataInicial AND @DataFinal "
            End If

            With MyBase.SQLCmd.Parameters

                .Clear()

                If iIdEmpresa > 0 Then
                    .AddWithValue("@IDEmpresa", iIdEmpresa)
                End If

                If iIdTreinamento > 0 Then
                    .AddWithValue("@IDTreinamento", iIdTreinamento)
                End If

                If iIdAgendamento > 0 Then
                    .AddWithValue("@IDAgendamento", iIdAgendamento)
                End If

                If dtDataInicial <> Nothing AndAlso dtDataFinal <> Nothing Then
                    .AddWithValue("@DataInicial", Conversao.ToDateTime(dtDataInicial).Date & " 00:00 ")
                    .AddWithValue("@DataFinal", Conversao.ToDateTime(dtDataFinal).Date & " 23:59 ")
                End If

            End With

            Return MyBase.executarConsulta(sSql, "Empresa")

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao tentar selecionar os dados da Empresa." & Environment.NewLine & ex.Message)
        End Try

    End Function

    Public Function selecionarTreinamentosFuncionario(ByVal iIdFuncionario As Integer) As DataSet

        Dim sSql As String
        Dim dsDados As New DataSet

        Try

            sSql = "  SELECT "
            sSql &= "   Agenda.Descricao, "
            sSql &= "   Agenda.Data, "
            sSql &= "   Agenda.CargaHoraria, "
            sSql &= "   Agenda.Ministrante "
            sSql &= " FROM "
            sSql &= "   Agenda "
            sSql &= "   INNER JOIN Participantes ON Agenda.IDAgendamento = Participantes.IDAgendamento"
            sSql &= " WHERE"
            sSql &= "   Participantes.IDFuncionario = @IDFuncionario "

            With MyBase.SQLCmd.Parameters
                .Clear()
                .AddWithValue("@IDFuncionario", iIdFuncionario)
            End With

            Return MyBase.executarConsulta(sSql, "Treinamento")

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao tentar selecionar os dados da Empresa." & Environment.NewLine & ex.Message)
        End Try

    End Function

#End Region

End Class
