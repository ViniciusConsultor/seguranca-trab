Public Class perFuncao
    Inherits AcessoBd

#Region "Variáveis"
    Private objproximoID As New ProximoID
#End Region

#Region "Propriedades"

    ReadOnly Property sqlConsulta(ByVal iIDFuncao As Integer, ByVal iIDEmpresa As Integer) As String
        Get
            Dim sSql As String

            sSql = "SELECT IDFuncao as Código," & vbCrLf
            sSql &= "      Descricao as Descrição" & vbCrLf

            sSql &= " FROM Funcao " & vbCrLf

            sSql &= "WHERE (IDEmpresa = " & iIDEmpresa & vbCrLf
            sSql &= "   OR IDEmpresa IS NULL)" & vbCrLf 'Busca também as funções padrão a todas as empresas

            If (iIDFuncao > 0) Then
                sSql &= "  AND IDFuncao = " & iIDFuncao & vbCrLf
            End If

            sSql &= " ORDER BY Funcao.Descricao"

            Return sSql

        End Get
    End Property

#End Region

#Region "Métodos Públicos"

    Public Function inserirFuncao(ByVal sDescricao As String, _
                                  ByVal iIDEmpresa As Integer) As Integer

        Dim sSql As String
        Dim iIDFuncao As Integer

        Try

            sSql = "INSERT INTO Funcao" & vbCrLf
            sSql &= "(" & vbCrLf
            sSql &= "      IDFuncao," & vbCrLf
            sSql &= "      IDEmpresa," & vbCrLf
            sSql &= "      Descricao" & vbCrLf
            sSql &= ")" & vbCrLf
            sSql &= "      VALUES" & vbCrLf
            sSql &= "(" & vbCrLf
            sSql &= "      @IDFuncao," & vbCrLf
            sSql &= "      @IDEmpresa," & vbCrLf
            sSql &= "      @Descricao" & vbCrLf
            sSql &= ")"

            iIDFuncao = objproximoID.BuscaID("IDFuncao", "Funcao")

            With MyBase.SQLCmd.Parameters
                .Clear()
                .AddWithValue("@IDFuncao", iIDFuncao)
                .AddWithValue("@IDEmpresa", IIf(iIDEmpresa = 0, System.DBNull.Value, iIDEmpresa))
                .AddWithValue("@Descricao", sDescricao)
            End With

            MyBase.executarAcao(sSql)

            Return iIDFuncao

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao inserir os dados da função." & Environment.NewLine & ex.Message)
        End Try

    End Function

    Public Sub atualizarFuncao(ByVal iIDFuncao As Integer, _
                               ByVal sDescricao As String, _
                               ByVal iIDEmpresa As Integer)

        Dim sSql As String

        Try
            sSql = "UPDATE Funcao" & vbCrLf
            sSql &= "  SET Descricao = @Descricao," & vbCrLf
            sSql &= "      IDEmpresa = @Empresa "
            sSql &= "WHERE IDFuncao = @IDFuncao"

            With MyBase.SQLCmd.Parameters
                .Clear()
                .AddWithValue("@IDFuncao", iIDFuncao)
                .AddWithValue("@Descricao", sDescricao)
                .AddWithValue("@Empresa", IIf(iIDEmpresa = 0, System.DBNull.Value, iIDEmpresa))
            End With

            MyBase.executarAcao(sSql)

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao atualizar os dados da função. " & Environment.NewLine & ex.Message)
        End Try

    End Sub

    Public Sub excluirFuncao(ByVal iIDFuncao As Integer)
        Dim sSql As String

        Try
            sSql = "DELETE Funcao " & vbCrLf
            sSql &= "WHERE IDFuncao = @IDFuncao" & vbCrLf

            With MyBase.SQLCmd.Parameters
                .Clear()
                .AddWithValue("@IDFuncao", iIDFuncao)
            End With

            MyBase.executarAcao(sSql)

        Catch ex As Exception
            Throw New Exception(" Ocorreu um erro ao excluir a Função. " & Environment.NewLine & ex.Message)
        End Try

    End Sub

    Public Function selecionarFuncoesFuncionario(ByVal iIdFuncionario As Integer) As DataSet

        Dim sSql As String
        Dim dsDados As New DataSet

        Try

            sSql = "  SELECT "
            sSql &= "   Funcao.Descricao, "
            sSql &= "   Funcao_Funcionario.DataInicio, "
            sSql &= "   Funcao_Funcionario.DataFim "
            sSql &= " FROM"
            sSql &= "   Funcao "
            sSql &= "   INNER JOIN Funcao_Funcionario ON Funcao.IDFuncao = Funcao_Funcionario.IDFuncao"
            sSql &= " WHERE"
            sSql &= "   Funcao_Funcionario.IDFuncionario = @IDFuncionario "

            With MyBase.SQLCmd.Parameters
                .Clear()
                .AddWithValue("@IDFuncionario", iIdFuncionario)
            End With

            dsDados = MyBase.executarConsulta(sSql, "Funcao")

            Return dsDados

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao selecionar os dados da Função." & Environment.NewLine & ex.Message)
        End Try

    End Function

    Public Function selecionarFuncao(ByVal iIDFuncao As Integer) As System.Data.DataSet

        Dim sSql As String
        Dim dsDados As New DataSet

        Try

            sSql = "  SELECT *  " & vbCrLf
            sSql &= "   FROM Funcao " & vbCrLf

            If (iIDFuncao > 0) Then
                sSql &= " WHERE (Funcao.IDFuncao = @IDFuncao)"
            End If

            With MyBase.SQLCmd.Parameters
                .Clear()

                If (iIDFuncao > 0) Then
                    .AddWithValue("@IDFuncao", iIDFuncao)
                End If
            End With

            dsDados = MyBase.executarConsulta(sSql, "Funcao")

            Return dsDados

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao selecionar os dados da Função." & Environment.NewLine & ex.Message)
        End Try

    End Function

    Public Function Retornar_Funcao_EPI(ByVal iIDFuncao As Integer) As DataTable
        Dim sSql As String

        sSql = "    SELECT FE.IDEPI, E.Descricao "
        sSql &= "     FROM Funcao_EPI FE" & vbCrLf
        sSql &= "          INNER JOIN EPI E ON FE.IDEPI = E.IDEPI" & vbCrLf
        sSql &= "    WHERE(FE.IDFuncao = @IDFuncao)" & vbCrLf
        sSql &= " ORDER BY E.Descricao" & vbCrLf

        With MyBase.SQLCmd.Parameters
            .Clear()
            .AddWithValue("@IDFuncao", iIDFuncao)
        End With

        Return MyBase.executarConsulta(sSql)


    End Function

    Public Function Retornar_Funcao_Treinamento(ByVal iIDFuncao As Integer) As DataTable
        Dim sSql As String

        sSql = "    SELECT T.* "
        sSql &= "     FROM Funcao_Treinamento FT" & vbCrLf
        sSql &= "          INNER JOIN Treinamento T ON FT.IDTreinamento = T.IDTreinamento" & vbCrLf
        sSql &= "    WHERE(FT.IDFuncao = @IDFuncao)" & vbCrLf
        sSql &= " ORDER BY T.Descricao" & vbCrLf

        With MyBase.SQLCmd.Parameters
            .Clear()
            .AddWithValue("@IDFuncao", iIDFuncao)
        End With

        Return MyBase.executarConsulta(sSql)

    End Function

    Public Function Retornar_Descricao_Funcao(ByVal iIDFuncao As Integer) As String
        Dim sSql As String
        Dim dtbDados As New DataTable
        Dim sRetorno As String = ""

        sSql = "Select Descricao" & vbCrLf
        sSql &= " From Funcao" & vbCrLf
        sSql &= "WHERE IDFuncao = @IDFuncao" & vbCrLf

        With MyBase.SQLCmd.Parameters
            .Clear()
            .AddWithValue("@IDFuncao", iIDFuncao)
        End With

        dtbDados = MyBase.executarConsulta(sSql)

        If (dtbDados.Rows.Count = 1) Then
            sRetorno = Conversao.nuloParaVazio(dtbDados.Rows(0).Item("Descricao")).ToString.Trim
        End If

        Return sRetorno

    End Function

    Public Sub Inserir_Funcao_EPI(ByVal iIDFuncao As Integer, _
                                  ByVal iIDEPI As Integer)
        Dim sSql As String

        sSql = "INSERT INTO Funcao_EPI" & vbCrLf
        sSql &= "("
        sSql &= "           IDFuncao," & vbCrLf
        sSql &= "           IDEPI" & vbCrLf
        sSql &= ")"
        sSql &= "     VALUES" & vbCrLf
        sSql &= "("
        sSql &= "            @IDFuncao," & vbCrLf
        sSql &= "            @IDEPI" & vbCrLf
        sSql &= ")"

        With MyBase.SQLCmd.Parameters
            .Clear()
            .AddWithValue("@IDFuncao", iIDFuncao)
            .AddWithValue("@IDEPI", iIDEPI)
        End With

        MyBase.executarAcao(sSql)

    End Sub

    Public Sub Inserir_Funcao_Treinamento(ByVal iIDFuncao As Integer, _
                                          ByVal iIDTreinamento As Integer)
        Dim sSql As String
        Try
            sSql = "INSERT INTO Funcao_Treinamento" & vbCrLf
            sSql &= "("
            sSql &= "           IDFuncao," & vbCrLf
            sSql &= "           IDTreinamento" & vbCrLf
            sSql &= ")"
            sSql &= "     VALUES" & vbCrLf
            sSql &= "("
            sSql &= "            @IDFuncao," & vbCrLf
            sSql &= "            @IDTreinamento" & vbCrLf
            sSql &= ")"

            With MyBase.SQLCmd.Parameters
                .Clear()
                .AddWithValue("@IDFuncao", iIDFuncao)
                .AddWithValue("@IDTreinamento", iIDTreinamento)
            End With

            MyBase.executarAcao(sSql)

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao inserir os treinamentos da Função." & Environment.NewLine & ex.Message)
        End Try

    End Sub

    Public Sub Excluir_Funcao_EPI(ByVal iIDFuncao As Integer)
        Dim sSql As String

        sSql = "DELETE Funcao_EPI" & vbCrLf
        sSql &= "WHERE IDFuncao = @IDFuncao" & vbCrLf

        With MyBase.SQLCmd.Parameters
            .Clear()
            .AddWithValue("@IDFuncao", iIDFuncao)
        End With

        MyBase.executarAcao(sSql)

    End Sub

    Public Sub Excluir_Funcao_Treinamento(ByVal iIDFuncao As Integer)
        Dim sSql As String
        Try
            sSql = "DELETE Funcao_Treinamento" & vbCrLf
            sSql &= "WHERE IDFuncao = @IDFuncao" & vbCrLf

            With MyBase.SQLCmd.Parameters
                .Clear()
                .AddWithValue("@IDFuncao", iIDFuncao)
            End With

            MyBase.executarAcao(sSql)

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao excluir os treinamentos da Função." & Environment.NewLine & ex.Message)
        End Try
    End Sub

    Public Function Validar_Exclusao_Funcao(ByVal iIDFuncao As Integer) As Boolean
        Dim sSql As String
        Dim dtRegistros As New DataTable
        Dim bRetorno As Boolean = False

        Try
            sSql = "SELECT COUNT(*) as NRegistros" & vbCrLf
            sSql &= " FROM Funcao_Funcionario " & vbCrLf
            sSql &= "WHERE IDFuncao = @IDFuncao"

            With MyBase.SQLCmd.Parameters
                .Clear()
                .AddWithValue("@IDFuncao", iIDFuncao)
            End With

            dtRegistros = MyBase.executarConsulta(sSql)

            With dtRegistros
                If (.Rows.Count > 0) Then
                    bRetorno = (.Rows(0).Item("NRegistros") = 0)
                End If
            End With

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao " & _
                                "selecionar os dados de Funcao_Treinamento." & _
                                Environment.NewLine & ex.Message)
        End Try

        Return bRetorno

    End Function

    Public Function Validar_Exclusao_Funcao_Treinamento(ByVal sListaTreinamento As String) As Boolean
        Dim sSql As String = ""
        Dim dtRegistros As New DataTable
        Dim bRetorno As Boolean = False

        Try

            If Not String.IsNullOrEmpty(sListaTreinamento) Then
                sSql = "SELECT COUNT(*) as NRegistros" & vbCrLf
                sSql &= " FROM Agenda " & vbCrLf
                sSql &= "WHERE IDTreinamento IN ( " & sListaTreinamento & ")"

                With MyBase.SQLCmd.Parameters
                    .Clear()
                End With

                dtRegistros = MyBase.executarConsulta(sSql)

                With dtRegistros
                    If (.Rows.Count > 0) Then
                        bRetorno = (.Rows(0).Item("NRegistros") = 0)
                    End If
                End With
            Else
                Return True
            End If

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao " & _
                                "selecionar os dados de Treinamento." & _
                                Environment.NewLine & ex.Message)
        End Try

        Return bRetorno

    End Function

    Public Function Validar_Exclusao_Funcao_EPI(ByVal sListaEPI As String) As Boolean
        Dim sSql As String
        Dim dtRegistros As New DataTable
        Dim bRetorno As Boolean = False

        Try
            If Not String.IsNullOrEmpty(sListaEPI) Then
                sSql = "SELECT COUNT(*) as NRegistros" & vbCrLf
                sSql &= " FROM Funcionario_EPI " & vbCrLf
                sSql &= "WHERE IDEPI IN ( " & sListaEPI & ")"

                With MyBase.SQLCmd.Parameters
                    .Clear()
                End With

                dtRegistros = MyBase.executarConsulta(sSql)

                With dtRegistros
                    If (.Rows.Count > 0) Then
                        bRetorno = (.Rows(0).Item("NRegistros") = 0)
                    End If
                End With
            Else
                Return True
            End If

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao " & _
                                "selecionar os dados de Treinamento." & _
                                Environment.NewLine & ex.Message)
        End Try

        Return bRetorno

    End Function

    Public Function seTreinamentoExisteFuncao(ByVal iIdTreinamento As Integer) As Boolean
        Dim sSql As String
        Dim dtRegistros As New DataTable
        Dim bRetorno As Boolean = False

        Try
            sSql = "SELECT COUNT(*) as NRegistros" & vbCrLf
            sSql &= " FROM Funcao_Treinamento " & vbCrLf
            sSql &= "WHERE IDTreinamento = @IDTreinamento"

            With MyBase.SQLCmd.Parameters
                .Clear()
                .AddWithValue("@IDTreinamento", iIdTreinamento)
            End With

            dtRegistros = MyBase.executarConsulta(sSql)

            With dtRegistros
                If (.Rows.Count > 0) Then
                    bRetorno = (.Rows(0).Item("NRegistros") = 0)
                End If
            End With

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao " & _
                                "selecionar os dados de Funcao_Treinamento." & _
                                Environment.NewLine & ex.Message)
        End Try

        Return bRetorno

    End Function

    Public Function Retornar_IDFuncao(ByVal sFuncao As String) As Integer
        Dim sSql As String
        Dim dtbDados As New DataTable
        Dim iRetorno As Integer = 0

        sSql = "SELECT IDFuncao" & vbCrLf
        sSql &= " FROM Funcao" & vbCrLf
        sSql &= "WHERE Descricao = @Funcao" & vbCrLf

        With MyBase.SQLCmd.Parameters
            .Clear()
            .AddWithValue("@Funcao", sFuncao)
        End With

        dtbDados = MyBase.executarConsulta(sSql)

        If (dtbDados.Rows.Count = 1) Then
            iRetorno = Conversao.nuloParaZero(dtbDados.Rows(0).Item("IDFuncao"))
        End If

        Return iRetorno

    End Function

#End Region

End Class
