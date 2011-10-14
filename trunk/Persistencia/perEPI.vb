Public Class perEPI
    Inherits AcessoBd

#Region "Variáveis "
    Private objProximoID As New ProximoID
#End Region

#Region "Propriedades "

    ReadOnly Property sqlConsulta(ByVal iIdEmpresa As Integer) As String
        Get
            Dim sSql As String
            sSql = "  SELECT    "
            sSql &= "    EPI.IDEPI,  "
            sSql &= "    EPI.Descricao as Descrição,  "
            sSql &= "    EPI.CA, "
            sSql &= "    EPI.Fornecedor "
            sSql &= " FROM EPI  "
            sSql &= " WHERE  "
            sSql &= "   EPI.IDEmpresa =  " & iIdEmpresa & " OR EPI.IDEmpresa IS NULL  "
            sSql &= " ORDER BY EPI.Descricao  "
            Return sSql
        End Get
    End Property

#End Region

#Region "Métodos públicos "

    Public Function inserirEPI(ByVal iIDEmpresa As Integer, _
                               ByVal sDescricao As String, _
                               ByVal sCA As String, _
                               ByVal sFornecedor As String, _
                               ByVal iValidade As Integer, _
                               ByVal bDevolucaoObrigatoria As Boolean) As Integer

        Dim sSql As String
        Dim iIDEPI As Integer


        sSql = " INSERT INTO EPI  "
        sSql &= "  (  "
        sSql &= "       IDEPI,  "
        sSql &= "       IDEmpresa,  "
        sSql &= "       Descricao,  "
        sSql &= "       CA,  "
        sSql &= "       Fornecedor,   "
        sSql &= "       Validade,  "
        sSql &= "       DevolucaoObrigatoria "
        sSql &= "  )  "
        sSql &= " VALUES  "
        sSql &= "  (  "
        sSql &= "       @IDEPI,  "
        sSql &= "       @IDEmpresa, "
        sSql &= "       @Descricao,  "
        sSql &= "       @CA,  "
        sSql &= "       @Fornecedor,  "
        sSql &= "       @Validade, "
        sSql &= "       @DevolucaoObrigatoria "
        sSql &= "  )  "

        iIDEPI = objProximoID.BuscaID("IDEPI ", "EPI ")

        With MyBase.SQLCmd.Parameters
            .Clear()
            .AddWithValue("@IDEPI ", iIDEPI)
            .AddWithValue("@IDEmpresa ", iIDEmpresa)
            .AddWithValue("@Descricao ", sDescricao)
            .AddWithValue("@CA ", sCA)
            .AddWithValue("@Fornecedor ", sFornecedor)
            .AddWithValue("@Validade ", iValidade)
            .AddWithValue("@DevolucaoObrigatoria ", bDevolucaoObrigatoria)
        End With

        MyBase.executarAcao(sSql)

        Return iIDEPI

    End Function

    Public Function Retornar_Descricao_EPI(ByVal iIDEPI As Integer) As String

        Dim sSql As String
        Dim dtbDados As New DataTable

        sSql = "SELECT Descricao "
        sSql &= " FROM EPI "
        sSql &= "WHERE IDEPI = @IDEpi "
        sSql &= "  AND IDEmpresa = @IDEmpresa "

        With MyBase.SQLCmd.Parameters
            .Clear()
            .AddWithValue("@IDEpi ", iIDEPI)
            .AddWithValue("@IDEmpresa ", Globais.iIDEmpresa)
        End With

        dtbDados = MyBase.executarConsulta(sSql)

        If (dtbDados.Rows.Count > 0) Then
            Return Conversao.nuloParaVazio(dtbDados.Rows(0).Item("Descricao"))
        Else
            Return " "
        End If

    End Function

    Public Sub atualizarEPI(ByVal iIdEPI As Integer, _
                            ByVal sDescricao As String, _
                            ByVal sCA As String, _
                            ByVal sFornecedor As String, _
                            ByVal iValidade As Integer, _
                            ByVal bDevolucaoObrigatoria As Boolean)

        Dim sSql As String

        sSql = "  UPDATE EPI SET  "
        sSql &= "   Descricao = @Descricao,  "
        sSql &= "   CA = @CA,  "
        sSql &= "   Fornecedor = @Fornecedor,  "
        sSql &= "   Validade = @Validade, "
        sSql &= "   DevolucaoObrigatoria = @DevolucaoObrigatoria "
        sSql &= " WHERE  "
        sSql &= "   IDEPI = @IDEPI  "

        With MyBase.SQLCmd.Parameters
            .Clear()
            .AddWithValue("@Descricao ", sDescricao)
            .AddWithValue("@CA ", sCA)
            .AddWithValue("@Fornecedor ", sFornecedor)
            .AddWithValue("@Validade ", iValidade)
            .AddWithValue("@DevolucaoObrigatoria ", bDevolucaoObrigatoria)
            .AddWithValue("@IDEPI ", iIdEPI)
        End With

        MyBase.executarAcao(sSql)

    End Sub

    Public Sub excluirEPI(ByVal iIDEPI As Integer)

        Dim sSql As String

        sSql = "  DELETE FROM  "
        sSql &= "   EPI  "
        sSql &= " WHERE  "
        sSql &= "   IDEPI = @IDEPI  "

        With MyBase.SQLCmd.Parameters
            .Clear()
            .AddWithValue("@IDEPI ", iIDEPI)
        End With

        MyBase.executarAcao(sSql)

    End Sub

    Public Function Selecionar_EPI(ByVal iIDEPI As Integer, ByVal sListaEPI As String, ByVal iIDEmpresa As Integer) As DataTable

        Dim sSql As String
        Dim dtbDados As New DataTable

        sSql = "  SELECT EPI.*  "
        sSql &= " FROM EPI  "
        sSql &= " WHERE 1=1  "
        If iIDEPI > 0 Then
            sSql &= "   AND EPI.IDEPI = @IDEPI  "
        ElseIf sListaEPI <> String.Empty Then
            sSql &= "   AND EPI.IDEPI IN( " & sListaEPI & ") "
        End If

        If iIDEmpresa > 0 Then
            sSql &= "   AND EPI.IDEmpresa = @IDEmpresa "
        End If

        With MyBase.SQLCmd.Parameters
            .Clear()
            If iIDEPI > 0 Then
                .AddWithValue("@IDEPI ", iIDEPI)
            End If

            If iIDEmpresa > 0 Then
                .AddWithValue("@IDEmpresa ", iIDEmpresa)
            End If

        End With

        dtbDados = MyBase.executarConsulta(sSql)

        Return dtbDados

    End Function

    Public Function Selecionar_EPI_Funcionario(ByVal iIDFuncionario As Integer, ByVal dtDataEntrega As Date, _
                                               ByVal btFiltro As Byte) As DataTable
        Dim sSql As String = " "
        Dim dtbDados As New DataTable

        If (btFiltro = 0 Or btFiltro = 1) Then
            sSql = "SELECT E.IDEpi,  "
            sSql &= "      E.Descricao,  "
            sSql &= "      E.CA,  "
            sSql &= "      E.Fornecedor,  "
            sSql &= "      NULL AS ExpiraEm  "
            sSql &= " FROM EPI E  "
            sSql &= "      Inner Join Funcao_EPI FE On E.IDEpi = FE.IDEPI  "
            sSql &= "      Inner Join Funcao_Funcionario FF On FF.IDFuncao = FE.IDFuncao  "
            sSql &= " WHERE(FF.IDFuncionario = @IDFuncionario)  "
            sSql &= "   AND(FF.DataInicio <=@DataEntrega)  "
            sSql &= "   AND(FF.DataFim >@DataEntrega OR FF.DataFim IS NULL)  "
            sSql &= "   AND(E.IDEPI Not In(SELECT IDEPI  "
            sSql &= "                        FROM Funcionario_EPI  "
            sSql &= "                       WHERE Funcionario_EPI.IDFuncionario = FF.IDFuncionario AND Devolucao IS NULL))  "
            If (btFiltro = 0) Then
                sSql &= "UNION ALL  "
            End If
        End If
        'Todos os equipamentos
        If (btFiltro = 0 Or btFiltro = 2 Or btFiltro = 3) Then
            sSql &= "SELECT EPI.IDEPI,  "
            sSql &= "       EPI.Descricao,  "
            sSql &= "       EPI.CA,  "
            sSql &= "       EPI.Fornecedor,  "
            sSql &= "       CASE WHEN ISNULL(EPI.VALIDADE,0) >0  "
            sSql &= "            THEN DATEADD(mm,EPI.Validade, MAX(FE.DataEntrega))  "
            sSql &= "            ELSE NULL END as ExpiraEm  "
            sSql &= "  FROM EPI as EPI  "
            sSql &= "       INNER JOIN Funcao_EPI FEPI ON EPI.IDEPI = FEPI.IDEPI  "
            sSql &= "       INNER JOIN Funcao_Funcionario FF ON FEPI.IDFuncao = FF.IDFuncao  "
            sSql &= "       INNER JOIN Funcionario_EPI FE ON FE.IDEPI = EPI.IDEPI  "
            sSql &= "                                    AND FE.IDFuncionario = @IDFuncionario  "
            sSql &= " GROUP BY EPI.IDEPI, EPI.DESCRICAO,Epi.CA, Epi.Fornecedor, EPI.VALIDADE  "


            If (btFiltro = 2 Or btFiltro = 0) Then
                sSql &= "HAVING DATEADD(mm,EPI.VALIDADE,Max(FE.DataEntrega)) < Convert(datetime,@DataEntrega)  "
            ElseIf (btFiltro = 3) Then
                sSql &= "HAVING DATEADD(mm,EPI.VALIDADE,Max(FE.DataEntrega)) >= Convert(datetime,@DataEntrega)  "
            End If
        End If

        With MyBase.SQLCmd.Parameters
            .Clear()
            .AddWithValue("@IDFuncionario ", iIDFuncionario)
            .AddWithValue("@DataEntrega ", dtDataEntrega)
        End With

        dtbDados = MyBase.executarConsulta(sSql)

        Return dtbDados

    End Function

    Public Sub Inserir_EPI_Funcionario(ByVal iIDFuncionario As Integer, _
                                       ByVal iIDEPI As Integer, _
                                       ByVal dtDataEntrega As Date, _
                                       ByVal iQuantidade As Integer)

        Dim sSql As String

        sSql = " INSERT INTO Funcionario_EPI  "
        sSql &= "  (  "
        sSql &= "       IDEPI,  "
        sSql &= "       IDFuncionario,  "
        sSql &= "       DataEntrega,  "
        sSql &= "       Quantidade "
        sSql &= "  )  "
        sSql &= " VALUES  "
        sSql &= "  (  "
        sSql &= "       @IDEPI,  "
        sSql &= "       @IDFuncionario, "
        sSql &= "       @DataEntrega,  "
        sSql &= "       @Quantidade "
        sSql &= "  )  "


        With MyBase.SQLCmd.Parameters
            .Clear()
            .AddWithValue("@IDEPI ", iIDEPI)
            .AddWithValue("@IDFuncionario ", iIDFuncionario)
            .AddWithValue("@DataEntrega ", dtDataEntrega.ToString("dd/MM/yyyy "))
            .AddWithValue("@Quantidade ", iQuantidade)
        End With

        MyBase.executarAcao(sSql)

    End Sub

    Public Sub Excluir_Entrega_EPI(ByVal iIDEPI As Integer, ByVal iIDFuncionario As Integer, _
                                   ByVal dtDataEntrega As Date)
        Dim sSql As String = " "

        sSql = " DELETE Funcionario_EPI  "
        sSql &= " WHERE IDEPI = @IDEPI "
        sSql &= "   AND IDFuncionario = @IDFuncionario "
        sSql &= "   AND DataEntrega = @DataEntrega "

        With MyBase.SQLCmd.Parameters
            .Clear()
            .AddWithValue("@IDEPI ", iIDEPI)
            .AddWithValue("@IDFuncionario ", iIDFuncionario)
            .AddWithValue("@DataEntrega ", dtDataEntrega.ToString("dd/MM/yyyy "))
        End With

        MyBase.executarAcao(sSql)

    End Sub

    Public Function selecionarEPIRelatorio(ByVal iIdFuncionario As Integer, _
                                           ByVal sIdsEmpresaAcesso As String, _
                                           ByVal iIdEmpresa As Integer) As DataTable

        Dim sSql As String = String.Empty
        Dim dsDados As New DataSet

        Try

            sSql = " "
            sSql &= " SELECT "
            sSql &= "   Empresa.IDEmpresa,  "
            sSql &= "   Empresa.NomeFantasia,  "
            sSql &= "   Empresa.Logomarca,  "
            sSql &= "   FE.IDFuncionario,  "
            sSql &= "   F.Nome,  "
            sSql &= "   F.Admissao,  "
            sSql &= "   F.Registro,  "
            sSql &= "   E.Descricao,  "
            sSql &= "   E.CA,  "
            sSql &= "   E.Unidade,  "
            sSql &= "   FE.DataEntrega,  "
            sSql &= "   FE.Quantidade,  "
            sSql &= "   FE.Devolucao "
            sSql &= " FROM Funcionario_EPI FE  "
            sSql &= "   INNER JOIN Funcionario F ON FE.IDFuncionario = F.IDFuncionario  "
            sSql &= "   INNER JOIN Empresa ON F.IDEmpresa = Empresa.IDEmpresa  "
            sSql &= "   INNER JOIN EPI E ON FE.IDEpi = E.IDEpi  "
            sSql &= " WHERE(ISNULL(FE.Inativo, 0) <> 1)  "

            If iIdFuncionario > 0 Then
                sSql &= "   AND (FE.IDFuncionario = @IDFuncionario)  "
            End If

            If iIdEmpresa > 0 Then
                sSql &= " AND F.IDEmpresa = @IDEmpresa  "
            ElseIf sIdsEmpresaAcesso <> String.Empty Then
                sSql &= " AND F.IDEmpresa IN (  " & sIdsEmpresaAcesso & " )  "
            End If

            sSql &= " ORDER BY E.Descricao  "

            With MyBase.SQLCmd.Parameters
                .Clear()
                If iIdFuncionario > 0 Then
                    .AddWithValue("@IDFuncionario ", iIdFuncionario)
                End If
                If iIdEmpresa > 0 Then
                    .AddWithValue("@IDEmpresa ", iIdEmpresa)
                End If
            End With

            dsDados = MyBase.executarConsulta(sSql, "EPI ")

            Return dsDados.Tables(0)

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao executar a consulta de EPI.  " & Environment.NewLine & ex.Message)
        End Try

    End Function

    Public Function selecionarEPIRelatorioAnalitico(ByVal iIdEPI As Integer,
                                                    ByVal sIdsEmpresaAcesso As String,
                                                    ByVal iIdEmpresa As Integer) As DataTable

        Dim sSql As String = String.Empty
        Dim dsDados As New DataSet

        Try

            sSql = "  SELECT "
            sSql &= "   Empresa.IDEmpresa,  "
            sSql &= "   Empresa.NomeFantasia,  "
            sSql &= "   E.IDEPI,  "
            sSql &= "   Descricao,  "
            sSql &= "   CA,  "
            sSql &= "   DATAENTREGA,  "
            sSql &= "   SUM(Quantidade) AS QUANTIDADE,  "
            sSql &= "   FUN.IDFuncionario, "
            sSql &= "   FUN.Nome AS Funcionario, "
            sSql &= "   F.Devolucao "
            sSql &= " FROM EPI E  "
            sSql &= "   INNER JOIN Funcionario_EPI F ON E.IDEPI = F.IDEPI  "
            sSql &= "   INNER JOIN Empresa ON E.IDEmpresa = Empresa.IDEmpresa  "
            sSql &= "   INNER JOIN Funcionario FUN ON F.IDFuncionario = FUN.IDFuncionario "
            sSql &= " WHERE  1=1"

            If iIdEmpresa > 0 Then
                sSql &= "  AND F.IDEmpresa = @IDEmpresa  "
            ElseIf sIdsEmpresaAcesso <> String.Empty Then
                sSql &= "  AND F.IDEmpresa IN (  " & sIdsEmpresaAcesso & " )  "
            End If

            If iIdEPI > 0 Then
                sSql &= "   AND (E.IDEPI = @IDEPI)  "
            End If

            sSql &= " GROUP BY  "
            sSql &= "   E.IDEPI,  "
            sSql &= "   Descricao,  "
            sSql &= "   DATAENTREGA,  "
            sSql &= "   CA,  "
            sSql &= "   Empresa.IDEmpresa,  "
            sSql &= "   Empresa.NomeFantasia,  "
            sSql &= "   FUN.IDFuncionario, "
            sSql &= "   FUN.Nome, "
            sSql &= "   F.Devolucao "

            sSql &= " ORDER BY E.Descricao  "

            With MyBase.SQLCmd.Parameters
                .Clear()
                If iIdEmpresa > 0 Then
                    .AddWithValue("@IDEmpresa ", iIdEmpresa)
                End If
                If iIdEPI > 0 Then
                    .AddWithValue("@IDEPI ", iIdEPI)
                End If
            End With

            dsDados = MyBase.executarConsulta(sSql, "EPI ")

            Return dsDados.Tables(0)

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao executar a consulta de EPI.  " & Environment.NewLine & ex.Message)
        End Try

    End Function

    Public Function Selecionar_Epi_Entregue(ByVal iIDFuncionario As Integer, ByVal dtDataEntrega As Date, _
                                            ByVal iIDEpi As Integer) As DataTable
        Dim sSql As String
        Dim dtbDados As New DataTable

        sSql = "SELECT FE.IDEpi, E.Descricao, E.CA,  "
        sSql &= "      FE.DataEntrega, FE.Quantidade,  "
        sSql &= "      FE.Devolucao, FE.Inativo  "
        sSql &= " FROM Funcionario_EPI FE  "
        sSql &= "      INNER JOIN EPI E ON E.IDEpi = FE.IDEpi  "
        sSql &= "WHERE 1=1  "

        If (iIDFuncionario > 0) Then
            sSql &= "  AND IDFuncionario = @IDFuncionario  "
        End If

        If (dtDataEntrega <> Date.MinValue) Then
            sSql &= "  AND DataEntrega = ' " & dtDataEntrega.ToString("dd/MM/yyyy ") & "' "
        End If

        If (iIDEpi > 0) Then
            sSql &= "  AND IDEpi = @IDEpi  "
        End If

        sSql &= "ORDER BY DataEntrega Desc "

        With MyBase.SQLCmd.Parameters
            .Clear()
            If (iIDFuncionario > 0) Then
                .AddWithValue("@IDFuncionario ", iIDFuncionario)
            End If
            If (iIDEpi > 0) Then
                .AddWithValue("@IDEpi ", iIDEpi)
            End If
        End With

        Return MyBase.executarConsulta(sSql)

    End Function

    Public Sub Inativar_EPI_Funcionario(ByVal iIDEpi As Integer, ByVal iIDFuncionario As Integer, ByVal dtDataEntrega As Date)
        Dim sSql As String

        sSql = "UPDATE Funcionario_EPI "
        sSql &= "  SET Inativo = -1 "
        sSql &= "WHERE IDEpi = @IDEpi "
        sSql &= "  AND IDFuncionario = @IDFuncionario "
        sSql &= "  AND DataEntrega = @DataEntrega "

        With MyBase.SQLCmd.Parameters
            .Clear()
            .AddWithValue("@IDEpi ", iIDEpi)
            .AddWithValue("@IDFuncionario ", iIDFuncionario)
            .AddWithValue("@DataEntrega ", dtDataEntrega)
        End With

        MyBase.executarAcao(sSql)

    End Sub

    Public Sub Devolver_EPI(ByVal iIDFuncionario As Integer, ByVal iIDEpi As Integer, _
                            ByVal dtEntrega As Date, ByVal dtDevolucao As Date)

        Dim sSql As String

        sSql = "UPDATE Funcionario_EPI "
        sSql &= "  SET Devolucao = @Devolucao "
        sSql &= "WHERE IDFuncionario = @IDFuncionario "
        sSql &= "  AND IDEpi = @IDEpi "
        sSql &= "  AND DataEntrega = @DataEntrega "

        With MyBase.SQLCmd.Parameters
            .Clear()
            .AddWithValue("@Devolucao ", dtDevolucao)
            .AddWithValue("@IDFuncionario ", iIDFuncionario)
            .AddWithValue("@IDEpi ", iIDEpi)
            .AddWithValue("@DataEntrega ", dtEntrega)
        End With

        MyBase.executarAcao(sSql)

    End Sub

    Public Function selecionarEPIsFuncionario(ByVal iIdFuncionario As Integer,
                                              ByVal iIdEmpresa As Integer,
                                              ByVal sIdsEmpresasAcesso As String) As DataSet

        Dim sSql As String
        Dim dsDados As New DataSet

        Try

            sSql = "  SELECT  "
            sSql &= "   EPI.CA,  "
            sSql &= "   EPI.Descricao,  "
            sSql &= "   Funcionario_EPI.DataEntrega,  "
            sSql &= "   Funcionario_EPI.Devolucao,  "
            sSql &= "   Funcionario_EPI.Inativo,  "
            sSql &= "   Funcionario_EPI.IDFuncionario, "
            sSql &= "   Funcionario_EPI.Quantidade, "
            sSql &= "   EPI.IDEPI "
            sSql &= " FROM  "
            sSql &= "   EPI  "
            sSql &= " INNER JOIN Funcionario_EPI ON EPI.IDEPI = Funcionario_EPI.IDEPI  "
            sSql &= " INNER JOIN EMPRESA EM ON EPI.IDEMPRESA = EM.IDEMPRESA  "
            sSql &= " WHERE  1=1"

            If iIdEmpresa > 0 Then
                sSql &= " AND EM.IDEmpresa = @IDEmpresa  "
            ElseIf sIdsEmpresasAcesso <> String.Empty Then
                sSql &= " AND EM.IDEmpresa IN (  " & sIdsEmpresasAcesso & " )  "
            End If

            If iIdFuncionario > 0 Then
                sSql &= " AND  Funcionario_EPI.IDFuncionario = @IDFuncionario  "
            End If

            With MyBase.SQLCmd.Parameters
                .Clear()
                If iIdEmpresa > 0 Then
                    .AddWithValue("@IDEmpresa ", iIdEmpresa)
                End If
                If iIdFuncionario > 0 Then
                    .AddWithValue("@IDFuncionario ", iIdFuncionario)
                End If
            End With

            dsDados = MyBase.executarConsulta(sSql, "EPI")

            Return dsDados
        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao executar a consulta de EPI.  " & Environment.NewLine & ex.Message)
        End Try

    End Function

    Public Function Retornar_EPI_Atrasados() As DataTable
        Dim sSql As String

        sSql = "   SELECT F.IDFuncionario, F.Nome as Funcionario, FF.IDFuncao, FE.IDEpi, EPI.Descricao as EPI, EPI.CA, FEPI.Devolucao, FEPI.DataEntrega as Entrega,  "
        sSql &= "         CONVERT(VARCHAR,ISNULL(DATEADD(M, EPI.VALIDADE, FEPI.DataEntrega), getdate()),103) AS Validade  "
        sSql &= "    FROM Funcionario F  "
        sSql &= "         INNER JOIN Funcao_Funcionario FF ON FF.IDFuncionario = F.IDFuncionario  "
        sSql &= "         INNER JOIN Funcao_Epi FE ON FF.IDFuncao = FE.IDFuncao  "
        sSql &= "         INNER JOIN EPI ON FE.IDEPI = EPI.IDEPI  "
        sSql &= "         LEFT JOIN Funcionario_EPI FEPI ON FEPI.IDFuncionario = F.IDFuncionario  "
        sSql &= "                                       AND FEPI.IDEPI = FE.IDEPI  "
        sSql &= "   WHERE FF.DataFim IS NULL  "
        sSql &= "     AND F.IDEmpresa = @IDEmpresa  "
        sSql &= "     AND (FEPI.DataEntrega = (SELECT MAX(DataEntrega)  "
        sSql &= "                              FROM Funcionario_EPI  "
        sSql &= "                             WHERE IDFuncionario = F.IDFuncionario  "
        sSql &= "                               AND IDEPI = FE.IDEPI  "
        sSql &= "                               AND Devolucao IS NULL)  "
        sSql &= "      OR FEPI.DataEntrega IS NULL)  "
        sSql &= "     AND CONVERT(DATETIME,ISNULL(DATEADD(M, EPI.VALIDADE, FEPI.DataEntrega), @DataServidor),103) <= @DataServidor  "
        sSql &= "ORDER BY F.Nome, EPI.Descricao  "

        With MyBase.SQLCmd.Parameters
            .Clear()
            .AddWithValue("@IDEmpresa ", Globais.iIDEmpresa)
            .AddWithValue("@DataServidor ", MyBase.Data_Servidor)
        End With

        Return MyBase.executarConsulta(sSql)

    End Function

    Public Function Validar_Exclusao_EPI_Func(ByVal iIdEPI As Integer) As Boolean
        Dim sSql As String
        Dim dtRegistros As New DataTable
        Dim bRetorno As Boolean = False

        Try
            sSql = "SELECT COUNT(*) as NRegistros "
            sSql &= " FROM Funcionario_EPI  "
            sSql &= "WHERE IDEPI = @IDEPI "

            With MyBase.SQLCmd.Parameters
                .Clear()
                .AddWithValue("@IDEPI ", iIdEPI)
            End With

            dtRegistros = MyBase.executarConsulta(sSql)

            With dtRegistros
                If (.Rows.Count > 0) Then
                    bRetorno = (.Rows(0).Item("NRegistros") = 0)
                End If
            End With

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao  " & _
                                 "selecionar os dados de EPI. " & _
                                Environment.NewLine & ex.Message)
        End Try

        Return bRetorno

    End Function

    Public Function Validar_Exclusao_EPI_Empresa(ByVal iIdEPI As Integer) As Boolean
        Dim sSql As String
        Dim dtRegistros As New DataTable
        Dim bRetorno As Boolean = False

        Try
            sSql = "SELECT COUNT(*) as NRegistros "
            sSql &= " FROM EPI_Empresa  "
            sSql &= "WHERE IDEPI = @IDEPI "

            With MyBase.SQLCmd.Parameters
                .Clear()
                .AddWithValue("@IDEPI ", iIdEPI)
            End With

            dtRegistros = MyBase.executarConsulta(sSql)

            With dtRegistros
                If (.Rows.Count > 0) Then
                    bRetorno = (.Rows(0).Item("NRegistros") = 0)
                End If
            End With

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao  " & _
                                 "selecionar os dados de EPI. " & _
                                Environment.NewLine & ex.Message)
        End Try

        Return bRetorno

    End Function

    Public Function selecionarCampo(ByVal iIdEPI As Integer,
                                    ByVal sCampo As String) As Object

        Dim sSql As String

        Try

            sSql = "  SELECT  " & sCampo
            sSql &= "   FROM EPI  "
            sSql &= " WHERE   "
            sSql &= "   IDEPI = @IDEPI  "

            With MyBase.SQLCmd.Parameters
                .Clear()
                .AddWithValue("@IDEPI ", iIdEPI)
            End With

            Return MyBase.executarConsultaCampo(sSql)

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao tentar selecionar os dados do EPI. " & Environment.NewLine & ex.Message)
        End Try

    End Function


#End Region

End Class
