Public Class perEPI
    Inherits AcessoBd

#Region "Variáveis"
    Private objProximoID As New ProximoID
#End Region

#Region "Propriedades"

    ReadOnly Property sqlConsulta(ByVal iIdEmpresa As Integer) As String
        Get
            Dim sSql As String
            sSql = "  SELECT   "
            sSql &= "    EPI.IDEPI, "
            sSql &= "    EPI.Descricao as Descrição, "
            sSql &= "    EPI.CA,"
            sSql &= "    EPI.Fornecedor"
            sSql &= " FROM EPI "
            sSql &= " WHERE "
            sSql &= "   EPI.IDEmpresa = " & iIdEmpresa & " OR EPI.IDEmpresa IS NULL "
            sSql &= " ORDER BY EPI.Descricao "
            Return sSql
        End Get
    End Property

#End Region

#Region "Métodos públicos"

    Public Function inserirEPI(ByVal iIDEmpresa As Integer, _
                               ByVal sDescricao As String, _
                               ByVal sCA As String, _
                               ByVal sFornecedor As String, _
                               ByVal iValidade As Integer, _
                               ByVal bDevolucaoObrigatoria As Boolean) As Integer

        Dim sSql As String
        Dim iIDEPI As Integer


        sSql = " INSERT INTO EPI " & vbCrLf
        sSql &= "  ( " & vbCrLf
        sSql &= "       IDEPI, " & vbCrLf
        sSql &= "       IDEmpresa, " & vbCrLf
        sSql &= "       Descricao, " & vbCrLf
        sSql &= "       CA, " & vbCrLf
        sSql &= "       Fornecedor,  " & vbCrLf
        sSql &= "       Validade, " & vbCrLf
        sSql &= "       DevolucaoObrigatoria" & vbCrLf
        sSql &= "  ) " & vbCrLf
        sSql &= " VALUES " & vbCrLf
        sSql &= "  ( " & vbCrLf
        sSql &= "       @IDEPI, " & vbCrLf
        sSql &= "       @IDEmpresa," & vbCrLf
        sSql &= "       @Descricao, " & vbCrLf
        sSql &= "       @CA, " & vbCrLf
        sSql &= "       @Fornecedor, " & vbCrLf
        sSql &= "       @Validade," & vbCrLf
        sSql &= "       @DevolucaoObrigatoria" & vbCrLf
        sSql &= "  ) "

        iIDEPI = objProximoID.BuscaID("IDEPI", "EPI")

        With MyBase.SQLCmd.Parameters
            .Clear()
            .AddWithValue("@IDEPI", iIDEPI)
            .AddWithValue("@IDEmpresa", iIDEmpresa)
            .AddWithValue("@Descricao", sDescricao)
            .AddWithValue("@CA", sCA)
            .AddWithValue("@Fornecedor", sFornecedor)
            .AddWithValue("@Validade", iValidade)
            .AddWithValue("@DevolucaoObrigatoria", bDevolucaoObrigatoria)
        End With

        MyBase.executarAcao(sSql)

        Return iIDEPI

    End Function

    Public Function Retornar_Descricao_EPI(ByVal iIDEPI As Integer) As String

        Dim sSql As String
        Dim dtbDados As New DataTable

        sSql = "SELECT Descricao" & vbCrLf
        sSql &= " FROM EPI" & vbCrLf
        sSql &= "WHERE IDEPI = @IDEpi"
        sSql &= "  AND IDEmpresa = @IDEmpresa"

        With MyBase.SQLCmd.Parameters
            .Clear()
            .AddWithValue("@IDEpi", iIDEPI)
            .AddWithValue("@IDEmpresa", Globais.iIDEmpresa)
        End With

        dtbDados = MyBase.executarConsulta(sSql)

        If (dtbDados.Rows.Count > 0) Then
            Return Conversao.nuloParaVazio(dtbDados.Rows(0).Item("Descricao"))
        Else
            Return ""
        End If

    End Function

    Public Sub atualizarEPI(ByVal iIdEPI As Integer, _
                            ByVal sDescricao As String, _
                            ByVal sCA As String, _
                            ByVal sFornecedor As String, _
                            ByVal iValidade As Integer, _
                            ByVal bDevolucaoObrigatoria As Boolean)

        Dim sSql As String

        sSql = "  UPDATE EPI SET "
        sSql &= "   Descricao = @Descricao, "
        sSql &= "   CA = @CA, "
        sSql &= "   Fornecedor = @Fornecedor, "
        sSql &= "   Validade = @Validade,"
        sSql &= "   DevolucaoObrigatoria = @DevolucaoObrigatoria"
        sSql &= " WHERE "
        sSql &= "   IDEPI = @IDEPI "

        With MyBase.SQLCmd.Parameters
            .Clear()
            .AddWithValue("@Descricao", sDescricao)
            .AddWithValue("@CA", sCA)
            .AddWithValue("@Fornecedor", sFornecedor)
            .AddWithValue("@Validade", iValidade)
            .AddWithValue("@DevolucaoObrigatoria", bDevolucaoObrigatoria)
            .AddWithValue("@IDEPI", iIdEPI)
        End With

        MyBase.executarAcao(sSql)

    End Sub

    Public Sub excluirEPI(ByVal iIDEPI As Integer)

        Dim sSql As String

        sSql = "  DELETE FROM "
        sSql &= "   EPI "
        sSql &= " WHERE "
        sSql &= "   IDEPI = @IDEPI "

        With MyBase.SQLCmd.Parameters
            .Clear()
            .AddWithValue("@IDEPI", iIDEPI)
        End With

        MyBase.executarAcao(sSql)

    End Sub

    Public Function Selecionar_EPI(ByVal iIDEPI As Integer, ByVal sListaEPI As String, ByVal iIDEmpresa As Integer) As DataTable

        Dim sSql As String
        Dim dtbDados As New DataTable

        sSql = "  SELECT EPI.* "
        sSql &= " FROM EPI "
        sSql &= " WHERE 1=1 "
        If iIDEPI > 0 Then
            sSql &= "   AND EPI.IDEPI = @IDEPI "
        ElseIf sListaEPI <> String.Empty Then
            sSql &= "   AND EPI.IDEPI IN(" & sListaEPI & ")"
        End If

        If iIDEmpresa > 0 Then
            sSql &= "   AND EPI.IDEmpresa = @IDEmpresa"
        End If

        With MyBase.SQLCmd.Parameters
            .Clear()
            If iIDEPI > 0 Then
                .AddWithValue("@IDEPI", iIDEPI)
            End If

            If iIDEmpresa > 0 Then
                .AddWithValue("@IDEmpresa", iIDEmpresa)
            End If

        End With

        dtbDados = MyBase.executarConsulta(sSql)

        Return dtbDados

    End Function

    Public Function Selecionar_EPI_Funcionario(ByVal iIDFuncionario As Integer, ByVal dtDataEntrega As Date, _
                                               ByVal btFiltro As Byte) As DataTable
        Dim sSql As String = ""
        Dim dtbDados As New DataTable

        If (btFiltro = 0 Or btFiltro = 1) Then
            sSql = "SELECT E.IDEpi," & vbCrLf
            sSql &= "      E.Descricao, " & vbCrLf
            sSql &= "      E.CA, " & vbCrLf
            sSql &= "      E.Fornecedor, " & vbCrLf
            sSql &= "      NULL AS ExpiraEm" & vbCrLf
            sSql &= " FROM EPI E" & vbCrLf
            sSql &= "      Inner Join Funcao_EPI FE On E.IDEpi = FE.IDEPI" & vbCrLf
            sSql &= "      Inner Join Funcao_Funcionario FF On FF.IDFuncao = FE.IDFuncao" & vbCrLf
            sSql &= " WHERE(FF.IDFuncionario = @IDFuncionario)" & vbCrLf
            sSql &= "   AND(FF.DataInicio <=@DataEntrega)" & vbCrLf
            sSql &= "   AND(FF.DataFim >@DataEntrega OR FF.DataFim IS NULL) " & vbCrLf
            sSql &= "   AND(E.IDEPI Not In(SELECT IDEPI" & vbCrLf
            sSql &= "                        FROM Funcionario_EPI" & vbCrLf
            sSql &= "                       WHERE Funcionario_EPI.IDFuncionario = FF.IDFuncionario))" & vbCrLf
            If (btFiltro = 0) Then
                sSql &= "UNION ALL" & vbCrLf & vbCrLf
            End If
        End If
        'Todos os equipamentos
        If (btFiltro = 0 Or btFiltro = 2 Or btFiltro = 3) Then
            sSql &= "SELECT EPI.IDEPI," & vbCrLf
            sSql &= "       EPI.Descricao," & vbCrLf
            sSql &= "       EPI.CA," & vbCrLf
            sSql &= "       EPI.Fornecedor," & vbCrLf
            sSql &= "       CASE WHEN ISNULL(EPI.VALIDADE,0) >0 " & vbCrLf
            sSql &= "            THEN DATEADD(mm,EPI.Validade, MAX(FE.DataEntrega)) " & vbCrLf
            sSql &= "            ELSE NULL END as ExpiraEm" & vbCrLf
            sSql &= "  FROM EPI as EPI" & vbCrLf
            sSql &= "       INNER JOIN Funcao_EPI FEPI ON EPI.IDEPI = FEPI.IDEPI" & vbCrLf
            sSql &= "       INNER JOIN Funcao_Funcionario FF ON FEPI.IDFuncao = FF.IDFuncao" & vbCrLf
            sSql &= "       INNER JOIN Funcionario_EPI FE ON FE.IDEPI = EPI.IDEPI" & vbCrLf
            sSql &= "                                    AND FE.IDFuncionario = @IDFuncionario" & vbCrLf
            sSql &= " GROUP BY EPI.IDEPI, EPI.DESCRICAO,Epi.CA, Epi.Fornecedor, EPI.VALIDADE" & vbCrLf

            If (btFiltro = 2 Or btFiltro = 0) Then
                sSql &= "HAVING DATEADD(mm,EPI.VALIDADE,Max(FE.DataEntrega)) < Convert(datetime,@DataEntrega) "
            ElseIf (btFiltro = 3) Then
                sSql &= "HAVING DATEADD(mm,EPI.VALIDADE,Max(FE.DataEntrega)) >= Convert(datetime,@DataEntrega) "
            End If
        End If

        With MyBase.SQLCmd.Parameters
            .Clear()
            .AddWithValue("@IDFuncionario", iIDFuncionario)
            .AddWithValue("@DataEntrega", dtDataEntrega)
        End With

        dtbDados = MyBase.executarConsulta(sSql)

        Return dtbDados

    End Function

    Public Sub Inserir_EPI_Funcionario(ByVal iIDFuncionario As Integer, _
                                       ByVal iIDEPI As Integer, _
                                       ByVal dtDataEntrega As Date, _
                                       ByVal iQuantidade As Integer)

        Dim sSql As String

        sSql = " INSERT INTO Funcionario_EPI " & vbCrLf
        sSql &= "  ( " & vbCrLf
        sSql &= "       IDEPI, " & vbCrLf
        sSql &= "       IDFuncionario, " & vbCrLf
        sSql &= "       DataEntrega, " & vbCrLf
        sSql &= "       Quantidade"
        sSql &= "  ) " & vbCrLf
        sSql &= " VALUES " & vbCrLf
        sSql &= "  ( " & vbCrLf
        sSql &= "       @IDEPI, " & vbCrLf
        sSql &= "       @IDFuncionario," & vbCrLf
        sSql &= "       @DataEntrega, " & vbCrLf
        sSql &= "       @Quantidade"
        sSql &= "  ) "


        With MyBase.SQLCmd.Parameters
            .Clear()
            .AddWithValue("@IDEPI", iIDEPI)
            .AddWithValue("@IDFuncionario", iIDFuncionario)
            .AddWithValue("@DataEntrega", dtDataEntrega.ToString("dd/MM/yyyy"))
            .AddWithValue("@Quantidade", iQuantidade)
        End With

        MyBase.executarAcao(sSql)

    End Sub

    Public Sub Excluir_Entrega_EPI(ByVal iIDEPI As Integer, ByVal iIDFuncionario As Integer, _
                                   ByVal dtDataEntrega As Date)
        Dim sSql As String = ""

        sSql = " DELETE Funcionario_EPI " & vbCrLf
        sSql &= " WHERE IDEPI = @IDEPI" & vbCrLf
        sSql &= "   AND IDFuncionario = @IDFuncionario" & vbCrLf
        sSql &= "   AND DataEntrega = @DataEntrega"

        With MyBase.SQLCmd.Parameters
            .Clear()
            .AddWithValue("@IDEPI", iIDEPI)
            .AddWithValue("@IDFuncionario", iIDFuncionario)
            .AddWithValue("@DataEntrega", dtDataEntrega.ToString("dd/MM/yyyy"))
        End With

        MyBase.executarAcao(sSql)

    End Sub

    Public Function selecionarEPIRelatorio(ByVal iIdFuncionario As Integer, _
                                           ByVal sIdsEmpresaAcesso As String, _
                                           ByVal iIdEmpresa As Integer) As DataTable

        Dim sSql As String = String.Empty
        Dim dsDados As New DataSet

        Try

            sSql = ""
            sSql &= " SELECT" & vbCrLf
            sSql &= "   Empresa.IDEmpresa, " & vbCrLf
            sSql &= "   Empresa.NomeFantasia, " & vbCrLf
            sSql &= "   Empresa.Logomarca, " & vbCrLf
            sSql &= "   FE.IDFuncionario, " & vbCrLf
            sSql &= "   F.Nome, " & vbCrLf
            sSql &= "   F.Admissao, " & vbCrLf
            sSql &= "   F.Registro, " & vbCrLf
            sSql &= "   E.Descricao, " & vbCrLf
            sSql &= "   E.CA, " & vbCrLf
            sSql &= "   E.Unidade, " & vbCrLf
            sSql &= "   FE.DataEntrega, " & vbCrLf
            sSql &= "   FE.Quantidade, " & vbCrLf
            sSql &= "   FE.Devolucao" & vbCrLf
            sSql &= " FROM Funcionario_EPI FE " & vbCrLf
            sSql &= "   INNER JOIN Funcionario F ON FE.IDFuncionario = F.IDFuncionario " & vbCrLf
            sSql &= "   INNER JOIN Empresa ON F.IDEmpresa = Empresa.IDEmpresa " & vbCrLf
            sSql &= "   INNER JOIN EPI E ON FE.IDEpi = E.IDEpi " & vbCrLf
            sSql &= " WHERE(ISNULL(FE.Inativo, 0) <> 1) " & vbCrLf
            'sSql &= "   AND (ISNULL(FE.Devolucao, '31/12/2050')> getdate()) " & vbCrLf
            If iIdFuncionario > 0 Then
                sSql &= "   AND (FE.IDFuncionario = @IDFuncionario) " & vbCrLf
            End If

            If iIdEmpresa > 0 Then
                sSql &= " AND F.IDEmpresa = @IDEmpresa " & vbCrLf
            ElseIf sIdsEmpresaAcesso <> String.Empty Then
                sSql &= " AND F.IDEmpresa IN ( " & sIdsEmpresaAcesso & " ) " & vbCrLf
            End If

            sSql &= " ORDER BY F.Nome "

            With MyBase.SQLCmd.Parameters
                .Clear()
                If iIdFuncionario > 0 Then
                    .AddWithValue("@IDFuncionario", iIdFuncionario)
                End If
                If iIdEmpresa > 0 Then
                    .AddWithValue("@IDEmpresa", iIdEmpresa)
                End If
            End With

            dsDados = MyBase.executarConsulta(sSql, "EPI")

            Return dsDados.Tables(0)

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao executar a consulta de EPI. " & Environment.NewLine & ex.Message)
        End Try

    End Function

    Public Function Selecionar_Epi_Entregue(ByVal iIDFuncionario As Integer, ByVal dtDataEntrega As Date, _
                                            ByVal iIDEpi As Integer) As DataTable
        Dim sSql As String
        Dim dtbDados As New DataTable

        sSql = "SELECT FE.IDEpi, E.Descricao, E.CA, " & vbCrLf
        sSql &= "      FE.DataEntrega, FE.Quantidade,"
        sSql &= "      FE.Devolucao, FE.Inativo"
        sSql &= " FROM Funcionario_EPI FE" & vbCrLf
        sSql &= "      INNER JOIN EPI E ON E.IDEpi = FE.IDEpi" & vbCrLf
        sSql &= "WHERE 1=1"
        'sSql &= "  AND ISNULL(Inativo, 0) = 0" & vbCrLf
        'sSql &= "  AND Devolucao IS NULL" & vbCrLf

        If (iIDFuncionario > 0) Then
            sSql &= "  AND IDFuncionario = @IDFuncionario" & vbCrLf
        End If

        If (dtDataEntrega <> Date.MinValue) Then
            sSql &= "  AND DataEntrega = '" & dtDataEntrega.ToString("dd/MM/yyyy") & "'" & vbCrLf
        End If

        If (iIDEpi > 0) Then
            sSql &= "  AND IDEpi = @IDEpi" & vbCrLf
        End If

        sSql &= "ORDER BY DataEntrega Desc"

        With MyBase.SQLCmd.Parameters
            .Clear()
            If (iIDFuncionario > 0) Then
                .AddWithValue("@IDFuncionario", iIDFuncionario)
            End If
            If (iIDEpi > 0) Then
                .AddWithValue("@IDEpi", iIDEpi)
            End If
        End With

        Return MyBase.executarConsulta(sSql)

    End Function

    Public Sub Inativar_EPI_Funcionario(ByVal iIDEpi As Integer, ByVal iIDFuncionario As Integer, ByVal dtDataEntrega As Date)
        Dim sSql As String

        sSql = "UPDATE Funcionario_EPI" & vbCrLf
        sSql &= "  SET Inativo = -1" & vbCrLf
        sSql &= "WHERE IDEpi = @IDEpi" & vbCrLf
        sSql &= "  AND IDFuncionario = @IDFuncionario" & vbCrLf
        sSql &= "  AND DataEntrega = @DataEntrega" & vbCrLf

        With MyBase.SQLCmd.Parameters
            .Clear()
            .AddWithValue("@IDEpi", iIDEpi)
            .AddWithValue("@IDFuncionario", iIDFuncionario)
            .AddWithValue("@DataEntrega", dtDataEntrega)
        End With

        MyBase.executarAcao(sSql)

    End Sub

    Public Sub Devolver_EPI(ByVal iIDFuncionario As Integer, ByVal iIDEpi As Integer, _
                            ByVal dtEntrega As Date, ByVal dtDevolucao As Date)

        Dim sSql As String

        sSql = "UPDATE Funcionario_EPI" & vbCrLf
        sSql &= "  SET Devolucao = @Devolucao" & vbCrLf
        sSql &= "WHERE IDFuncionario = @IDFuncionario" & vbCrLf
        sSql &= "  AND IDEpi = @IDEpi" & vbCrLf
        sSql &= "  AND DataEntrega = @DataEntrega" & vbCrLf

        With MyBase.SQLCmd.Parameters
            .Clear()
            .AddWithValue("@Devolucao", dtDevolucao)
            .AddWithValue("@IDFuncionario", iIDFuncionario)
            .AddWithValue("@IDEpi", iIDEpi)
            .AddWithValue("@DataEntrega", dtEntrega)
        End With

        MyBase.executarAcao(sSql)

    End Sub

    Public Function selecionarEPIsFuncionario(ByVal iIdFuncionario As Integer) As DataSet

        Dim sSql As String
        Dim dsDados As New DataSet

        Try

            sSql = "  SELECT "
            sSql &= "   EPI.CA, "
            sSql &= "   EPI.Descricao, "
            sSql &= "   Funcionario_EPI.DataEntrega, "
            sSql &= "   Funcionario_EPI.Devolucao, "
            sSql &= "   Funcionario_EPI.Inativo "
            sSql &= " FROM "
            sSql &= "   EPI "
            sSql &= " INNER JOIN Funcionario_EPI ON EPI.IDEPI = Funcionario_EPI.IDEPI "
            sSql &= " WHERE "
            sSql &= "   Funcionario_EPI.IDFuncionario = @IDFuncionario "

            With MyBase.SQLCmd.Parameters
                .Clear()
                .AddWithValue("@IDFuncionario", iIdFuncionario)
            End With

            dsDados = MyBase.executarConsulta(sSql, "EPI")

            Return dsDados
        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao executar a consulta de EPI. " & Environment.NewLine & ex.Message)
        End Try

    End Function

    Public Function Retornar_EPI_Atrasados() As DataTable
        Dim sSql As String

        sSql = "   SELECT F.IDFuncionario, F.Nome as Funcionario, FF.IDFuncao, FE.IDEpi, EPI.Descricao as EPI, EPI.CA, FEPI.Devolucao, FEPI.DataEntrega as Entrega, " & vbCrLf
        sSql &= "         CONVERT(VARCHAR,ISNULL(DATEADD(M, EPI.VALIDADE, FEPI.DataEntrega), getdate()),103) AS Validade" & vbCrLf
        sSql &= "    FROM Funcionario F" & vbCrLf
        sSql &= "         INNER JOIN Funcao_Funcionario FF ON FF.IDFuncionario = F.IDFuncionario" & vbCrLf
        sSql &= "         INNER JOIN Funcao_Epi FE ON FF.IDFuncao = FE.IDFuncao" & vbCrLf
        sSql &= "         INNER JOIN EPI ON FE.IDEPI = EPI.IDEPI" & vbCrLf
        sSql &= "         LEFT JOIN Funcionario_EPI FEPI ON FEPI.IDFuncionario = F.IDFuncionario" & vbCrLf
        sSql &= "                                       AND FEPI.IDEPI = FE.IDEPI" & vbCrLf
        sSql &= "   WHERE FF.DataFim IS NULL" & vbCrLf
        sSql &= "     AND F.IDEmpresa = @IDEmpresa" & vbCrLf
        sSql &= "     AND (FEPI.DataEntrega = (SELECT MAX(DataEntrega)" & vbCrLf
        sSql &= "                              FROM Funcionario_EPI " & vbCrLf
        sSql &= "                             WHERE IDFuncionario = F.IDFuncionario" & vbCrLf
        sSql &= "                               AND IDEPI = FE.IDEPI" & vbCrLf
        sSql &= "                               AND Devolucao IS NULL)" & vbCrLf
        sSql &= "      OR FEPI.DataEntrega IS NULL) " & vbCrLf
        sSql &= "     AND CONVERT(DATETIME,ISNULL(DATEADD(M, EPI.VALIDADE, FEPI.DataEntrega), @DataServidor),103) <= @DataServidor" & vbCrLf
        sSql &= "ORDER BY F.Nome, EPI.Descricao"

        With MyBase.SQLCmd.Parameters
            .Clear()
            .AddWithValue("@IDEmpresa", Globais.iIDEmpresa)
            .AddWithValue("@DataServidor", MyBase.Data_Servidor)
        End With

        Return MyBase.executarConsulta(sSql)

    End Function

    Public Function Validar_Exclusao_EPI_Func(ByVal iIdEPI As Integer) As Boolean
        Dim sSql As String
        Dim dtRegistros As New DataTable
        Dim bRetorno As Boolean = False

        Try
            sSql = "SELECT COUNT(*) as NRegistros" & vbCrLf
            sSql &= " FROM Funcionario_EPI " & vbCrLf
            sSql &= "WHERE IDEPI = @IDEPI"

            With MyBase.SQLCmd.Parameters
                .Clear()
                .AddWithValue("@IDEPI", iIdEPI)
            End With

            dtRegistros = MyBase.executarConsulta(sSql)

            With dtRegistros
                If (.Rows.Count > 0) Then
                    bRetorno = (.Rows(0).Item("NRegistros") = 0)
                End If
            End With

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao " & _
                                "selecionar os dados de EPI." & _
                                Environment.NewLine & ex.Message)
        End Try

        Return bRetorno

    End Function

    Public Function Validar_Exclusao_EPI_Empresa(ByVal iIdEPI As Integer) As Boolean
        Dim sSql As String
        Dim dtRegistros As New DataTable
        Dim bRetorno As Boolean = False

        Try
            sSql = "SELECT COUNT(*) as NRegistros" & vbCrLf
            sSql &= " FROM EPI_Empresa " & vbCrLf
            sSql &= "WHERE IDEPI = @IDEPI"

            With MyBase.SQLCmd.Parameters
                .Clear()
                .AddWithValue("@IDEPI", iIdEPI)
            End With

            dtRegistros = MyBase.executarConsulta(sSql)

            With dtRegistros
                If (.Rows.Count > 0) Then
                    bRetorno = (.Rows(0).Item("NRegistros") = 0)
                End If
            End With

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao " & _
                                "selecionar os dados de EPI." & _
                                Environment.NewLine & ex.Message)
        End Try

        Return bRetorno

    End Function

#End Region

End Class
