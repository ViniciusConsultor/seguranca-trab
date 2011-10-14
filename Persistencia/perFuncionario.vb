Public Class perFuncionario
    Inherits AcessoBd

#Region "Variáveis "
    Private objProximoID As New ProximoID
#End Region

#Region "Propriedades "

    ReadOnly Property sqlConsulta(ByVal iIDFuncionario As Long, ByVal iIDEmpresa As Long) As String
        Get
            Dim sSql As String
            sSql = "SELECT IDFuncionario as Código, Nome  "
            sSql &= " FROM Funcionario "

            sSql &= " WHERE IDEmpresa =  " & iIDEmpresa

            If iIDFuncionario > 0 Then
                sSql &= " AND IDFuncionario =  " & iIDFuncionario
            End If
            sSql &= " ORDER BY Nome "

            Return sSql
        End Get
    End Property

#End Region

#Region "Métodos públicos "

    Public Function inserirFuncionario(ByVal iIDEmpresa As Long, _
                                       ByVal sNomeFuncionario As String, _
                                       ByVal sCPF As String, _
                                       ByVal sRG As String, _
                                       ByVal dtDataNascimento As Date, _
                                       ByVal iSexo As Byte, _
                                       ByVal sRua As String, _
                                       ByVal sComplemento As String, _
                                       ByVal iNumero As Integer, _
                                       ByVal sBairro As String, _
                                       ByVal sCidade As String, _
                                       ByVal iEstado As Integer, _
                                       ByVal sCEP As String, _
                                       ByVal sEmail As String, _
                                       ByVal sTelefone As String, _
                                       ByVal sCelular As String, _
                                       ByVal iCodCBO As Integer, _
                                       ByVal sRegistro As String, _
                                       ByVal dtAdmissao As Date, _
                                       ByVal dtRescisao As Date, _
                                       ByVal sOrgao As String, _
                                       ByVal dtEmissao As Date, _
                                       ByVal sCTPS As String, _
                                       ByVal dtImportacao As Date) As Integer

        Dim sSql As String
        Dim iIDFuncionario As Long

        sSql = " INSERT INTO Funcionario "
        sSql &= "  (  "
        sSql &= "       IDFuncionario,  "
        sSql &= "       IDEmpresa,  "
        sSql &= "       Nome,  "
        sSql &= "       CPF,  "
        sSql &= "       RG,  "
        sSql &= "       dtNascimento,  "
        sSql &= "       Sexo,  "
        sSql &= "       Rua,  "
        sSql &= "       Numero,  "
        sSql &= "       Complemento,  "
        sSql &= "       Bairro,  "
        sSql &= "       Cidade,  "
        sSql &= "       Estado,  "
        sSql &= "       CEP,  "
        sSql &= "       Telefone,  "
        sSql &= "       Celular,  "
        sSql &= "       Email,  "
        sSql &= "       IDCBO,  "
        sSql &= "       Registro,  "
        sSql &= "       Admissao,  "
        sSql &= "       Rescisao,  "
        sSql &= "       OrgaoEmissor,  "
        sSql &= "       DataEmissao,  "
        sSql &= "       CTPS,  "
        sSql &= "       DataImportacao "
        sSql &= "  )  "
        sSql &= " VALUES  "
        sSql &= "  (  "
        sSql &= "       @IDFuncionario,  "
        sSql &= "       @IDEmpresa,  "
        sSql &= "       @Nome,  "
        sSql &= "       @CPF,  "
        sSql &= "       @RG,  "
        sSql &= "       @DtNascimento,  "
        sSql &= "       @Sexo,  "
        sSql &= "       @Rua,  "
        sSql &= "       @Numero,  "
        sSql &= "       @Complemento,  "
        sSql &= "       @Bairro,  "
        sSql &= "       @Cidade,  "
        sSql &= "       @Estado,  "
        sSql &= "       @CEP,  "
        sSql &= "       @Telefone,  "
        sSql &= "       @Celular,  "
        sSql &= "       @Email,  "
        sSql &= "       @CodCBO,  "
        sSql &= "       @Registro, "
        sSql &= "       @Admissao, "
        sSql &= "       @Rescisao, "
        sSql &= "       @Orgao, "
        sSql &= "       @DataEmissao,  "
        sSql &= "       @CTPS, "
        sSql &= "       GetDate() "
        sSql &= "  )  "

        iIDFuncionario = objProximoID.BuscaID("IDFuncionario ", "Funcionario ")

        With MyBase.SQLCmd.Parameters
            .Clear()
            .AddWithValue("@IDFuncionario ", iIDFuncionario)
            .AddWithValue("@IDEmpresa ", iIDEmpresa)
            .AddWithValue("@Nome ", sNomeFuncionario)
            .AddWithValue("@Sexo ", iSexo)
            .AddWithValue("@CPF ", sCPF)
            .AddWithValue("@RG ", sRG)
            .AddWithValue("@DtNascimento ", dtDataNascimento)
            .AddWithValue("@Rua ", sRua)
            .AddWithValue("@Numero ", Conversao.zeroParaNulo(iNumero))
            .AddWithValue("@Complemento ", sComplemento)
            .AddWithValue("@Bairro ", sBairro)
            .AddWithValue("@Cidade ", sCidade)
            .AddWithValue("@Estado ", IIf(iEstado < 0, System.DBNull.Value, iEstado))
            .AddWithValue("@CEP ", sCEP)
            .AddWithValue("@Telefone ", sTelefone)
            .AddWithValue("@Celular ", sCelular)
            .AddWithValue("@Email ", sEmail)
            .AddWithValue("@CodCbo ", Conversao.zeroParaNulo(iCodCBO))
            .AddWithValue("@Registro ", sRegistro)
            .AddWithValue("@Admissao ", IIf(dtAdmissao = Date.MinValue, System.DBNull.Value, dtAdmissao))
            .AddWithValue("@Rescisao ", IIf(dtRescisao = Date.MinValue, System.DBNull.Value, dtRescisao))
            .AddWithValue("@Orgao ", sOrgao)
            .AddWithValue("@DataEmissao ", IIf(dtEmissao = Date.MinValue, System.DBNull.Value, dtEmissao))
            .AddWithValue("@CTPS ", sCTPS)
            '.AddWithValue( "@Importacao ", IIf(dtImportacao = Date.MinValue, System.DBNull.Value, dtImportacao))
        End With

        MyBase.executarAcao(sSql)

        Return iIDFuncionario

    End Function

    Public Sub atualizarFuncionario(ByVal iIDFuncionario As Long, _
                                    ByVal iIDEmpresa As Long, _
                                    ByVal sNomeFuncionario As String, _
                                    ByVal sCPF As String, _
                                    ByVal sRG As String, _
                                    ByVal dtDataNascimento As Date, _
                                    ByVal iSexo As Byte, _
                                    ByVal sRua As String, _
                                    ByVal sComplemento As String, _
                                    ByVal iNumero As Integer, _
                                    ByVal sBairro As String, _
                                    ByVal sCidade As String, _
                                    ByVal iEstado As Integer, _
                                    ByVal sCEP As String, _
                                    ByVal sEmail As String, _
                                    ByVal sTelefone As String, _
                                    ByVal sCelular As String, _
                                    ByVal iCodCBO As Integer, _
                                    ByVal sRegistro As String, _
                                    ByVal dtAdmissao As Date, _
                                    ByVal dtRescisao As Date, _
                                    ByVal sOrgao As String, _
                                    ByVal dtEmissao As Date, _
                                    ByVal sCTPS As String)

        Dim sSql As String

        Try

            sSql = "  UPDATE Funcionario SET  "
            sSql &= "   Nome = @Nome,  "
            sSql &= "   CPF = @CPF,  "
            sSql &= "   RG = @RG,  "
            sSql &= "   dtNascimento = @dtNascimento, "
            sSql &= "   Sexo = @Sexo, "
            sSql &= "   Rua = @Rua,  "
            sSql &= "   Numero = @Numero,  "
            sSql &= "   Complemento = @Complemento,  "
            sSql &= "   Bairro = @Bairro,  "
            sSql &= "   Cidade = @Cidade,  "
            sSql &= "   Estado = @Estado,  "
            sSql &= "   CEP = @CEP,  "
            sSql &= "   Email = @Email,  "
            sSql &= "   Telefone = @Telefone,  "
            sSql &= "   Celular = @Celular,  "
            sSql &= "   IDCBO = @CodCBO, "
            sSql &= "   Registro = @Registro, "
            sSql &= "   Admissao = @Admissao, "
            sSql &= "   Rescisao = @Rescisao,  "
            sSql &= "   OrgaoEmissor = @Orgao,  "
            sSql &= "   DataEmissao = @DataEmissao,  "
            sSql &= "   CTPS = @CTPS "
            sSql &= " WHERE  "
            sSql &= "   IDFuncionario = @IDFuncionario  "

            With MyBase.SQLCmd.Parameters
                .Clear()
                .AddWithValue("@Nome ", sNomeFuncionario)
                .AddWithValue("@CPF ", sCPF)
                .AddWithValue("@RG ", sRG)
                .AddWithValue("@DtNascimento ", dtDataNascimento)
                .AddWithValue("@Sexo ", iSexo)
                .AddWithValue("@Rua ", sRua)
                .AddWithValue("@Numero ", Conversao.zeroParaNulo(iNumero))
                .AddWithValue("@Complemento ", sComplemento)
                .AddWithValue("@Bairro ", sBairro)
                .AddWithValue("@Cidade ", sCidade)
                .AddWithValue("@Estado ", IIf(iEstado < 0, System.DBNull.Value, iEstado))
                .AddWithValue("@CEP ", sCEP)
                .AddWithValue("@Email ", sEmail)
                .AddWithValue("@Telefone ", sTelefone)
                .AddWithValue("@Celular ", sCelular)
                .AddWithValue("@CodCBO ", IIf(iCodCBO = 0, System.DBNull.Value, iCodCBO))
                .AddWithValue("@Registro ", sRegistro)
                .AddWithValue("@Admissao ", IIf(dtAdmissao = Date.MinValue, System.DBNull.Value, dtAdmissao))
                .AddWithValue("@Rescisao ", IIf(dtRescisao = Date.MinValue, System.DBNull.Value, dtRescisao))
                .AddWithValue("@Orgao ", sOrgao)
                .AddWithValue("@DataEmissao ", IIf(dtEmissao = Date.MinValue, System.DBNull.Value, dtEmissao))
                .AddWithValue("@CTPS ", sCTPS)
                .AddWithValue("@IDFuncionario ", iIDFuncionario)
            End With

            MyBase.executarAcao(sSql)

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao tentar atualizar os dados do Funcionário. " & Environment.NewLine & ex.Message)
        End Try

    End Sub

    Public Sub excluirFuncionario(ByVal iIDFuncionario As Long)

        Dim sSql As String

        Try

            sSql = "  DELETE FROM  "
            sSql &= "   Funcionario  "
            sSql &= " WHERE  "
            sSql &= "   IDFuncionario = @IDFuncionario  "

            With MyBase.SQLCmd.Parameters
                .Clear()
                .AddWithValue("@IDFuncionario ", iIDFuncionario)
            End With

            MyBase.executarAcao(sSql)

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao tentar excluir os dados do Funcionário. " & Environment.NewLine & ex.Message)
        End Try

    End Sub

    Public Function selecionarFuncionario(ByVal iIDFuncionario As Integer, ByVal iIDEmpresa As Integer) As System.Data.DataSet

        Dim sSql As String
        Dim dsDados As New DataSet

        Try

            sSql = "  SELECT * FROM  "
            sSql &= "   Funcionario  "

            If (iIDFuncionario > 0) Then
                sSql &= " WHERE   "
                sSql &= "   Funcionario.IDFuncionario = @IDFuncionario "
            ElseIf (iIDEmpresa > 0) Then
                sSql &= " WHERE   "
                sSql &= "   Funcionario.IDEmpresa = @IDEmpresa "
            End If

            With MyBase.SQLCmd.Parameters
                .Clear()
                .AddWithValue("@IDFuncionario ", iIDFuncionario)
                .AddWithValue("@IDEmpresa ", iIDEmpresa)
            End With

            dsDados = MyBase.executarConsulta(sSql, "Empresa ")

            Return dsDados

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao tentar selecionar os dados do Funcionário. " & Environment.NewLine & ex.Message)
        End Try

    End Function

    Public Function selecionarFuncionariosTreinamento(ByVal iIDTreinamento As Integer, _
                                                      ByVal datDataTreinamento As Date, _
                                                      ByVal sListaFuncionarios As String, _
                                                      ByVal eFiltro As Byte) As System.Data.DataSet

        Dim sSql As String = " "
        Dim dsDados As New DataSet
        Dim sData As String

        'Isso é para pegar os funcionários que foram contratados no dia do treinamento
        sData = datDataTreinamento.ToString("dd/MM/yyyy ")
        sData = sData & " 23:59"

        datDataTreinamento = CDate(sData)
        Try
            'Todos os funcionários ou que nunca tiveram treinamento
            If (eFiltro = 0 Or eFiltro = 1) Then
                sSql = " SELECT F.IDFuncionario, "
                sSql &= "       F.Nome, NULL AS ExpiraEm, "
                sSql &= "       '' As [em_dia] "
                sSql &= "  FROM Funcionario F "
                sSql &= "       INNER JOIN Funcao_Funcionario FF ON F.IDFuncionario = FF.IDFuncionario "
                sSql &= "       INNER JOIN Funcao_Treinamento FT ON FF.IDFuncao = FT.IDFuncao "
                sSql &= " WHERE FT.IDTreinamento = @IDTreinamento "
                sSql &= "   AND (FF.DataInicio < @DataTreinamento AND FF.DataFim IS NULL)  "
                sSql &= "   AND F.IDFuncionario Not in ( "
                sSql &= "                  				SELECT P.IDFuncionario "
                sSql &= "   							  FROM Participantes P "
                sSql &= "                					   INNER JOIN Agenda AG ON P.IDAgendamento = AG.IDAgendamento "
                sSql &= "                                WHERE AG.IDTreinamento =  " & iIDTreinamento & ") "
                If (eFiltro = 0) Then
                    sSql &= " UNION ALL "
                End If
            End If
            'Todos os funcionários ou que já tiveram treinamento
            If (eFiltro = 0 Or eFiltro = 2 Or eFiltro = 3) Then
                sSql &= " SELECT F.IDFuncionario, "
                sSql &= "        F.Nome,DATEADD(mm,t.VALIDADE,Max(AG.Data)) as ExpiraEm, "
                sSql &= "        Case When DATEADD(mm,t.VALIDADE,Max(AG.Data)) >= Convert(datetime,@DataTreinamento)  "
                sSql &= "             Then 'x' Else '' End As [em_dia] "
                sSql &= "   FROM Funcionario F "
                sSql &= "        INNER JOIN Funcao_Funcionario FF ON F.IDFuncionario = FF.IDFuncionario "
                sSql &= "        INNER JOIN Funcao_Treinamento FT ON FF.IDFuncao = FT.IDFuncao "
                sSql &= "        INNER JOIN Participantes P ON F.IDFuncionario = P.IDFuncionario  "
                sSql &= "        INNER JOIN Agenda AG ON P.IDAgendamento = AG.IDAgendamento and AG.IDTreinamento = FT.IDTreinamento "
                sSql &= "        INNER JOIN Treinamento_Empresa T ON AG.IDtreinamento = T.IDTreinamento "
                sSql &= "   WHERE(FT.IDTreinamento = @IDTreinamento) "
                sSql &= "     AND(FF.DataInicio < @DataTreinamento) "
                sSql &= "     AND(F.Rescisao <@DataTreinamento OR F.Rescisao IS NULL) "
                sSql &= "GROUP BY F.IDFuncionario, F.Nome, T.Validade "
                If (eFiltro = 2) Then
                    sSql &= "HAVING DATEADD(mm,t.VALIDADE,Max(AG.Data)) < Convert(datetime,@DataTreinamento)  "
                ElseIf (eFiltro = 3) Then
                    sSql &= "HAVING DATEADD(mm,t.VALIDADE,Max(AG.Data)) >= Convert(datetime,@DataTreinamento)  "
                End If

            End If

            If (sListaFuncionarios <> String.Empty) Then
                sSql &= "  UNION ALL "
                sSql &= "SELECT F.IDFuncionario, "
                sSql &= "       F.Nome, NULL as ExpiraEm, "
                sSql &= "       '' As [em_dia] "
                sSql &= "  FROM Funcionario F "

                sSql &= "  WHERE F.IDFuncionario in( " & sListaFuncionarios & ") "
            End If
            sSql &= "ORDER BY ExpiraEm  "

            With MyBase.SQLCmd.Parameters
                .Clear()
                .AddWithValue("@IDTreinamento", iIDTreinamento)
                .AddWithValue("@DataTreinamento", datDataTreinamento)
            End With

            dsDados = MyBase.executarConsulta(sSql, "Funcionarios")

            Return dsDados

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao tentar selecionar os dados do Funcionário. " & Environment.NewLine & ex.Message)
        End Try

    End Function

    Public Function Retornar_Nome_Funcionario(ByVal iIDFuncionario As Integer) As String
        Dim sSql As String = " "
        Dim dsRegistros As New DataTable
        Dim bRetorno As String = " "
        Try
            sSql = " SELECT Nome  "
            sSql &= " FROM Funcionario  "
            sSql &= "WHERE IDFuncionario = @IDFuncionario  "

            With MyBase.SQLCmd.Parameters
                .Clear()
                .AddWithValue("@IDFuncionario ", iIDFuncionario)
            End With

            dsRegistros = MyBase.executarConsulta(sSql)

            If (dsRegistros.Rows.Count > 0) Then
                bRetorno = dsRegistros.Rows(0).Item("Nome")
            End If

            Return bRetorno

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao selecionar o nome do funcionário. " & Environment.NewLine & ex.Message)
        End Try

    End Function

    Public Function Validar_Exclusao_Funcionario(ByVal iIDFuncionario As Integer) As Boolean
        Dim sSql As String = " "
        Dim dsRegistros As New DataTable
        Dim bRetorno As Boolean = False

        Try
            sSql = "SELECT *  "
            sSql &= " FROM Participantes "
            sSql &= "WHERE IDFuncionario = @IDFuncionario "

            With MyBase.SQLCmd.Parameters
                .Clear()
                .AddWithValue("@IDFuncionario ", iIDFuncionario)
            End With

            dsRegistros = MyBase.executarConsulta(sSql)
            bRetorno = (dsRegistros.Rows.Count = 0)

            Return bRetorno

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao tentar selecionar os dados do Funcionário. " & Environment.NewLine & ex.Message)
        End Try

    End Function

    Public Function selecionarCampo(ByVal iIdFuncionario As Integer, _
                                   ByVal sCampo As String) As Object

        Dim sSql As String

        Try

            sSql = "  SELECT  " & sCampo
            sSql &= "   FROM Funcionario  "
            sSql &= " WHERE   "
            sSql &= "   IDFuncionario = @IDFuncionario  "

            With MyBase.SQLCmd.Parameters
                .Clear()
                .AddWithValue("@IDFuncionario ", iIdFuncionario)
            End With

            Return MyBase.executarConsultaCampo(sSql)

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao tentar selecionar os dados do Funcionário. " & Environment.NewLine & ex.Message)
        End Try

    End Function

    Public Function Validar_Funcionario_Cadastrado(ByVal sNome As String, ByVal sCpf As String) As Boolean
        Dim sSql As String
        Dim dtbDados As New DataTable

        sSql = "SELECT IDFuncionario "
        sSql &= " FROM Funcionario  "
        sSql &= "WHERE IDEmpresa = @IDEmpresa AND ( "

        If (sNome <> " ") Then
            sSql &= "Nome = @Nome OR "
        End If
        If (sCpf <> " ") Then
            sSql &= " Cpf = @Cpf "
        Else
            sSql &= " 1 > 2 "
        End If
        sSql &= ") "

        With MyBase.SQLCmd.Parameters
            .Clear()
            .AddWithValue("@IDEmpresa ", Globais.iIDEmpresa)
            .AddWithValue("@Nome ", sNome.Trim)
            If (sCpf <> " ") Then
                .AddWithValue("@Cpf ", sCpf.Trim)
            End If
        End With

        dtbDados = MyBase.executarConsulta(sSql)

        Return (dtbDados.Rows.Count > 0)

    End Function

    Public Function selecionarFuncionariosRelatorio(ByVal iIdEmpresa As Integer,
                                                    ByVal sIdsEmpresasAcesso As String,
                                                    ByVal iIdFuncionario As Integer) As DataTable

        Dim sSql As String

        Try

            sSql = "  SELECT  "
            sSql &= "   F.Nome,  "
            sSql &= "   F.IDFuncionario, "
            sSql &= "   EM.IDEmpresa, "
            sSql &= "   EM.NomeFantasia, "
            sSql &= "   EM.Logomarca "
            sSql &= " FROM   "
            sSql &= "   Funcionario F  "
            sSql &= " INNER JOIN EMPRESA EM ON EM.IDEmpresa = F.IDEmpresa  "
            sSql &= " WHERE   "
            sSql &= "   1 = 1  "

            If iIdEmpresa > 0 Then
                sSql &= " AND EM.IDEmpresa = @IDEmpresa  "
            ElseIf sIdsEmpresasAcesso <> String.Empty Then
                sSql &= " AND EM.IDEmpresa IN (  " & sIdsEmpresasAcesso & " )  "
            End If

            If iIdFuncionario > 0 Then
                sSql &= " AND  F.IDFuncionario = @IDFuncionario  "
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

            Return MyBase.executarConsulta(sSql, "Funcionario").Tables(0)

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao tentar selecionar os dados do Relatório de Funcionários. " & Environment.NewLine & ex.Message)
        End Try

    End Function

#End Region

End Class
