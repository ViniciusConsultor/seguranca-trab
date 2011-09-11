Public Class perTreinamento
    Inherits AcessoBd

#Region "Variáveis"
    Private objProximoID As New ProximoID
#End Region

#Region "Propriedades"

    ReadOnly Property sqlConsulta(ByVal iIDEmpresa As Integer) As String

        Get
            Dim sSql As String

            sSql = "    SELECT Treinamento.IDTreinamento as Código, Treinamento.Descricao as Treinamento " & vbCrLf
            sSql &= "     FROM Treinamento" & vbCrLf
            sSql &= "          LEFT JOIN Treinamento_Empresa ON Treinamento.IDTreinamento = Treinamento_Empresa.IDTreinamento" & vbCrLf
            sSql &= "    WHERE (Treinamento_Empresa.IDEmpresa = " & iIDEmpresa & ")" & vbCrLf
            sSql &= " ORDER BY Treinamento.Descricao" & vbCrLf

            Return sSql

        End Get

    End Property

#End Region

#Region "Métodos públicos"

    Public Function Inserir_Treinamento(ByVal sDescricaoTreinamento As String, _
                                        ByVal sCargaHoraria As String) As Integer

        Dim sSql As String
        Dim iIDTreinamento As Integer

        Try

            sSql = " INSERT INTO Treinamento "
            sSql &= "  ( "
            sSql &= "       IDTreinamento, "
            sSql &= "       Descricao, "
            sSql &= "       CargaHoraria"
            sSql &= "  ) "
            sSql &= " VALUES "
            sSql &= "  ( "
            sSql &= "       @IDTreinamento, "
            sSql &= "       @Descricao, "
            sSql &= "       @CargaHoraria"
            sSql &= "  ) "

            iIDTreinamento = objProximoID.BuscaID("IDTreinamento", "Treinamento")

            With MyBase.SQLCmd.Parameters
                .Clear()
                .AddWithValue("@IDTreinamento", iIDTreinamento)
                .AddWithValue("@Descricao", sDescricaoTreinamento)
                .AddWithValue("@CargaHoraria", sCargaHoraria)
            End With

            MyBase.executarAcao(sSql)

            Return iIDTreinamento

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao tentar inserir os dados do Treinamento." & Environment.NewLine & ex.Message)
        End Try

    End Function

    Public Sub Atualizar_Treinamento(ByVal iIdTreinamento As Integer, _
                                     ByVal sDescricaoTreinamento As String, _
                                     ByVal sCargaHoraria As String)

        Dim sSql As String

        Try

            sSql = "  UPDATE Treinamento SET "
            sSql &= "   Descricao = @Descricao, "
            sSql &= "   CargaHoraria = @CargaHoraria "
            sSql &= " WHERE "
            sSql &= "   IDTreinamento = @IDTreinamento "

            With MyBase.SQLCmd.Parameters
                .Clear()
                .AddWithValue("@Descricao", sDescricaoTreinamento)
                .AddWithValue("@IDTreinamento", iIdTreinamento)
                .AddWithValue("@CargaHoraria", sCargaHoraria)
            End With

            MyBase.executarAcao(sSql)

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao tentar atualizar os dados do Treinamento." & Environment.NewLine & ex.Message)
        End Try

    End Sub

    Public Sub Excluir_Treinamento(ByVal iIdTreinamento As Integer)

        Dim sSql As String

        Try

            sSql = "  DELETE FROM "
            sSql &= "   Treinamento "
            sSql &= " WHERE "
            sSql &= "   IDTreinamento = @IDTreinamento "

            With MyBase.SQLCmd.Parameters
                .Clear()
                .AddWithValue("@IDTreinamento", iIdTreinamento)
            End With

            MyBase.executarAcao(sSql)

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao tentar excluir os dados do Treinamento." & Environment.NewLine & ex.Message)
        End Try

    End Sub

    Public Function Selecionar_Treinamento(ByVal iIdTreinamento As Integer, ByVal iIDEmpresa As Integer) As System.Data.DataSet

        Dim sSql As String
        Dim dsDados As New DataSet

        Try

            sSql = "  SELECT Treinamento.* "
            sSql &= "   FROM Treinamento "
            sSql &= "        INNER JOIN Treinamento_Empresa ON Treinamento.IDTreinamento = Treinamento_Empresa.IDTreinamento" & vbCrLf
            sSql &= " WHERE (1=1)"

            If iIdTreinamento > 0 Then
                sSql &= "   AND (Treinamento.IDTreinamento = @IDTreinamento)"
            End If
            If (iIDEmpresa > 0) Then
                sSql &= "   AND (Treinamento_Empresa.IDEmpresa = @IDEmpresa OR Treinamento_Empresa.IDEmpresa IS NULL)"
            End If

            With MyBase.SQLCmd.Parameters
                .Clear()
                If (iIdTreinamento > 0) Then
                    .AddWithValue("@IDTreinamento", iIdTreinamento)
                End If
                If (iIDEmpresa > 0) Then
                    .AddWithValue("@IDEmpresa", iIDEmpresa)
                End If
            End With

            dsDados = MyBase.executarConsulta(sSql, "Treinamento")

            Return dsDados

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao tentar selecionar os dados do Treinamento." & Environment.NewLine & ex.Message)
        End Try

    End Function

    Public Function Retornar_Validade_Treinamento(ByVal iIDTreinamento As Integer, ByVal iIDEmpresa As Integer) As Integer
        Dim sSql As String
        Dim dsDados As DataSet
        Dim Validade As Integer

        Try
            Validade = 0

            sSql = "Select Validade" & vbCrLf
            sSql &= "From Treinamento_Empresa" & vbCrLf
            sSql &= "Where IDTreinamento = @IDTreinamento" & vbCrLf
            sSql &= "  And IDEmpresa = @IDEmpresa"

            With MyBase.SQLCmd.Parameters
                .Clear()
                .AddWithValue("@IDTreinamento", iIDTreinamento)
                .AddWithValue("@IDEmpresa", iIDEmpresa)
            End With

            dsDados = MyBase.executarConsulta(sSql, "Treinamento")

            If (dsDados.Tables("Treinamento").Rows.Count > 0) Then
                Validade = dsDados.Tables("Treinamento").Rows(0).Item("Validade")
            End If

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao selecionar os dados do Treinamento " & Environment.NewLine & ex.Message)
        End Try

        Return Validade

    End Function

    Public Sub Atualizar_Validade(ByVal iIDTreinamento As Integer, _
                                  ByVal iIDEmpresa As Integer, _
                                  ByVal iValidade As Integer)
        Dim sSql As String
        Try
            sSql = "Update Treinamento_Empresa "
            sSql &= "   Set Validade = @Validade"
            sSql &= " Where IDTreinamento = @IDTreinamento"
            sSql &= "   And IDEmpresa = @IDEmpresa"

            With MyBase.SQLCmd.Parameters
                .Clear()
                .AddWithValue("@Validade", IIf(iValidade = 0, DBNull.Value, iValidade))
                .AddWithValue("@IDTreinamento", iIDTreinamento)
                .AddWithValue("@IDEmpresa", IIf(iIDEmpresa = 0, System.DBNull.Value, iIDEmpresa))
            End With

            MyBase.executarAcao(sSql)

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao atualizar os dados de Validade " & Environment.NewLine & ex.Message)
        End Try

    End Sub

    Public Sub Excluir_Validade(ByVal iIDTreinamento As Integer, _
                                ByVal iIDEmpresa As Integer)

        Dim sSql As String

        Try
            sSql = "Delete Treinamento_Empresa "
            sSql &= "Where IDTreinamento = @IDTreinamento"
            sSql &= "  And IDEmpresa = @IDEmpresa"

            With MyBase.SQLCmd.Parameters
                .Clear()
                .AddWithValue("@IDTreinamento", iIDTreinamento)
                .AddWithValue("@IDEmpresa", iIDEmpresa)
            End With

            MyBase.executarAcao(sSql)

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao excluir os dados de Validade " & Environment.NewLine & ex.Message)
        End Try

    End Sub

    Public Sub Inserir_Validade(ByVal iIDTreinamento As Integer, _
                                ByVal iIDEmpresa As Integer, _
                                ByVal iValidade As Integer)
        Dim sSql As String

        Try
            sSql = "Insert Into Treinamento_Empresa(" & vbCrLf
            sSql &= "           IDTreinamento," & vbCrLf
            sSql &= "           IDEmpresa," & vbCrLf
            sSql &= "           Validade)" & vbCrLf
            sSql &= "    Values" & vbCrLf
            sSql &= "(" & vbCrLf
            sSql &= "@IDTreinamento," & vbCrLf
            sSql &= "@IDEmpresa," & vbCrLf
            sSql &= "@Validade" & vbCrLf
            sSql &= ")"

            With MyBase.SQLCmd.Parameters
                .Clear()
                .AddWithValue("@IDTreinamento", iIDTreinamento)
                .AddWithValue("@IDEmpresa", IIf(iIDEmpresa = 0, System.DBNull.Value, iIDEmpresa))
                .AddWithValue("Validade", iValidade)
            End With

            MyBase.executarAcao(sSql)

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao inserir os dados de Validade " & Environment.NewLine & ex.Message)
        End Try
    End Sub

    Public Function Retornar_Treinamentos_Atrasados() As DataTable
        Dim sSql As String

        sSql = "  SELECT FT.IDTreinamento, T.Descricao as Treinamento, F.IDFuncionario, F.Nome as Funcionario, " & vbCrLf
        sSql &= "        CONVERT(VARCHAR, P.Data,103) AS Data, " & vbCrLf
        sSql &= "        CONVERT(VARCHAR, ISNULL(DATEADD(M, P.Validade, P.Data), @DataServidor),103) AS Validade" & vbCrLf
        sSql &= "   FROM Funcionario F" & vbCrLf
        sSql &= "        INNER JOIN Funcao_Funcionario FF ON FF.IDFuncionario = F.IDFuncionario" & vbCrLf
        sSql &= "        INNER JOIN Funcao_Treinamento FT ON FF.IDFuncao = FT.IDFuncao" & vbCrLf
        sSql &= "        INNER JOIN Treinamento T ON FT.IDTreinamento = T.IDTreinamento" & vbCrLf
        sSql &= "        LEFT JOIN Funcionarios_Treinamento P ON P.IDFuncionario = F.IDFuncionario" & vbCrLf
        sSql &= "                                            AND P.IDTreinamento = T.IDTreinamento" & vbCrLf
        sSql &= "   WHERE(FF.DataFim Is NULL)" & vbCrLf
        sSql &= "     AND F.IDEmpresa = @IDEmpresa " & vbCrLf
        sSql &= "     AND (P.Data is null or P.Data = (SELECT MAX(DATA)" & vbCrLf
        sSql &= "                                        FROM Agenda" & vbCrLf
        sSql &= "                                       WHERE Agenda.idtreinamento = P.idtreinamento" & vbCrLf
        sSql &= "                                    GROUP BY IDTREINAMENTO))" & vbCrLf
        sSql &= "     AND ISNULL(DATEADD(M, P.Validade, P.Data), @DataServidor) <= @DataServidor " & vbCrLf
        sSql &= "ORDER BY T.Descricao"

        With MyBase.SQLCmd.Parameters
            .Clear()
            .AddWithValue("@DataServidor", MyBase.Data_Servidor)
            .AddWithValue("@IDEmpresa", Globais.iIDEmpresa)
        End With

        Return MyBase.executarConsulta(sSql)

    End Function

    Public Function Selecionar_Lista_Treinamento(ByVal sIdTreinamento As String, ByVal iIDEmpresa As Integer) As System.Data.DataSet

        Dim sSql As String
        Dim dsDados As New DataSet

        Try

            sSql = "  SELECT Treinamento.* " & vbCrLf
            sSql &= "   FROM Treinamento " & vbCrLf
            sSql &= "        INNER JOIN Treinamento_Empresa ON Treinamento.IDTreinamento = Treinamento_Empresa.IDTreinamento" & vbCrLf
            sSql &= " WHERE (1=1)" & vbCrLf

            If (sIdTreinamento <> String.Empty) Then
                sSql &= "   AND (Treinamento.IDTreinamento in (" & sIdTreinamento & "))" & vbCrLf
            End If
            If (iIDEmpresa > 0) Then
                sSql &= "   AND (Treinamento_Empresa.IDEmpresa = @IDEmpresa OR Treinamento_Empresa.IDEmpresa IS NULL)" & vbCrLf
            End If

            With MyBase.SQLCmd.Parameters
                .Clear()
                If (iIDEmpresa > 0) Then
                    .AddWithValue("@IDEmpresa", iIDEmpresa)
                End If
            End With

            dsDados = MyBase.executarConsulta(sSql, "Treinamento")

            Return dsDados

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao tentar selecionar os dados do Treinamento." & Environment.NewLine & ex.Message)
        End Try

    End Function

    Public Function selecionarCampo(ByVal iIdTreinamento As Integer, _
                                    ByVal sCampo As String) As Object

        Dim sSql As String

        Try

            sSql = "  SELECT " & sCampo
            sSql &= "   FROM Treinamento "
            sSql &= " WHERE  "
            sSql &= "   IDTreinamento = @IDTreinamento "

            With MyBase.SQLCmd.Parameters
                .Clear()
                .AddWithValue("@IDTreinamento", iIdTreinamento)
            End With

            Return MyBase.executarConsultaCampo(sSql)

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao tentar selecionar os dados do Treinamento." & Environment.NewLine & ex.Message)
        End Try

    End Function

    Public Function Validar_Exclusao_Treinamento(ByVal iIDTreinamento As Integer) As Boolean
        Dim sSql As String
        Dim dtRegistros As New DataTable
        Dim bRetorno As Boolean = False

        Try
            sSql = "SELECT COUNT(*) as NRegistros" & vbCrLf
            sSql &= " FROM Agenda " & vbCrLf
            sSql &= "WHERE IDTreinamento = @IDTreinamento"

            With MyBase.SQLCmd.Parameters
                .Clear()
                .AddWithValue("@IDTreinamento", iIDTreinamento)
            End With

            dtRegistros = MyBase.executarConsulta(sSql)

            With dtRegistros
                If (.Rows.Count > 0) Then
                    bRetorno = (.Rows(0).Item("NRegistros") = 0)
                End If
            End With

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao tentar " & _
                                "selecionar os dados de agenda de treinamentos." & _
                                Environment.NewLine & ex.Message)
        End Try

        Return bRetorno

    End Function

#End Region

End Class
