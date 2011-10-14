Public Class perNR
    Inherits AcessoBd

#Region "Variáveis "
    Private objProximoID As New ProximoID
#End Region

#Region "Propriedades "

    ReadOnly Property sqlConsulta() As String
        Get
            Dim sSql As String
            sSql = "SELECT IDNR, Descricao "
            sSql &= " FROM NR "
            sSql &= " ORDER BY IDNR "
            Return sSql
        End Get
    End Property

#End Region

    Public Function Inserir_NR(ByVal iIDNR As Integer, _
                               ByVal sDescricao As String) As Integer

        Dim sSql As String

        sSql = " INSERT INTO NR  "
        sSql &= "  (  "
        sSql &= "       IDNR,  "
        sSql &= "       Descricao  "
        sSql &= "  )  "
        sSql &= " VALUES  "
        sSql &= "  (  "
        sSql &= "       @IDNR,  "
        sSql &= "       @Descricao "
        sSql &= "  )  "

        With MyBase.SQLCmd.Parameters
            .Clear()
            .AddWithValue("@IDNR ", iIDNR)
            .AddWithValue("@Descricao ", sDescricao)
        End With

        MyBase.executarAcao(sSql)

        Return iIDNR

    End Function

    Public Sub Atualizar_NR(ByVal iIDNR As Integer, _
                           ByVal sDescricao As String)

        Dim sSql As String

        sSql = "  UPDATE NR SET  "
        sSql &= "   Descricao = @Descricao  "
        sSql &= " WHERE  "
        sSql &= "   IDNR = @IDNR  "

        With MyBase.SQLCmd.Parameters
            .Clear()
            .AddWithValue("@Descricao ", sDescricao.Trim)
            .AddWithValue("@IDNR ", iIDNR)
        End With

        MyBase.executarAcao(sSql)

    End Sub

    Public Sub Excluir_NR(ByVal iIDNR As Integer)

        Dim sSql As String

        sSql = "  DELETE FROM  "
        sSql &= "   NR  "
        sSql &= " WHERE  "
        sSql &= "   IDNR = @IDNR  "

        With MyBase.SQLCmd.Parameters
            .Clear()
            .AddWithValue("@IDNR ", iIDNR)
        End With

        MyBase.executarAcao(sSql)

    End Sub

    Public Function selecionarCampo(ByVal iIDNR As Integer, _
                                    ByVal sCampo As String) As Object

        Dim sSql As String

        sSql = "  SELECT  " & sCampo
        sSql &= "   FROM NR  "
        sSql &= " WHERE   "
        sSql &= "   IDNR = @IDNR "

        With MyBase.SQLCmd.Parameters
            .Clear()
            .AddWithValue("@IDNR ", iIDNR)
        End With

        Return MyBase.executarConsultaCampo(sSql)

    End Function

    Public Function Validar_CodNR(ByVal iIDNR As Integer) As Boolean
        Dim sSql As String
        Dim dtbDados As New DataTable

        sSql = " "
        sSql &= "SELECT IDNR "
        sSql &= "  FROM NR "
        sSql &= " WHERE IDNR = @IDNR "

        With MyBase.SQLCmd.Parameters
            .Clear()
            .AddWithValue("@IDNR ", iIDNR)
        End With

        dtbDados = MyBase.executarConsulta(sSql)

        Return (dtbDados.Rows.Count = 0)

    End Function

    Public Function Validar_ExclusaoNR(ByVal iIDNR As Integer) As Boolean
        Dim sSql As String
        Dim dtbDados As New DataTable

        sSql = " "
        sSql &= "SELECT IDNR "
        sSql &= "  FROM CheckList "
        sSql &= " WHERE IDNR = @IDNR "

        With MyBase.SQLCmd.Parameters
            .Clear()
            .AddWithValue("@IDNR ", iIDNR)
        End With

        dtbDados = MyBase.executarConsulta(sSql)

        Return (dtbDados.Rows.Count = 0)

    End Function

    Public Function Retornar_NR_Empresa(ByVal iIDEmpresa As Integer) As DataTable
        Dim sSql As String

        sSql = "SELECT NR.IDNR, NR.Descricao, NRE.Validade,  "
        sSql &= "      CASE WHEN NRE.IDNR IS NULL THEN 0 ELSE 1 END AS [Aplicavel] "
        sSql &= " FROM NR "
        sSql &= "      LEFT JOIN NR_Empresa NRE ON NR.IDNR = NRE.IDNR OR NRE.IDNR IS NULL  "
        sSql &= "WHERE ISNULL(NRE.IDEmpresa, @IDEmpresa) = @IDEmpresa "

        With MyBase.SQLCmd.Parameters
            .AddWithValue("@IDEmpresa ", iIDEmpresa)
        End With

        Return MyBase.executarConsulta(sSql)

    End Function

    Public Sub Excluir_Associacao_NR_Empresa(ByVal iIDEmpresa As Integer)
        Dim sSql As String

        sSql = "DELETE NR_Empresa  "
        sSql &= "WHERE IDEmpresa = @IDEmpresa "

        MyBase.SQLCmd.Parameters.Clear()
        MyBase.SQLCmd.Parameters.AddWithValue("@IDEmpresa ", iIDEmpresa)
        MyBase.executarAcao(sSql)

    End Sub

    Public Sub Inserir_Associacao_NR_Empresa(ByVal iIDEmpresa As Integer, _
                                             ByVal iIDNR As Integer, _
                                             ByVal iValidade As Integer)
        Dim sSql As String

        sSql = " INSERT INTO NR_Empresa(IDEmpresa, IDNR, Validade) "
        sSql &= "                VALUES(@IDEmpresa, @IDNR, @Validade)  "

        With MyBase.SQLCmd.Parameters
            .Clear()
            .AddWithValue("@IDEmpresa ", iIDEmpresa)
            .AddWithValue("@IDNR ", iIDNR)
            .AddWithValue("@Validade ", iValidade)
        End With
        MyBase.executarAcao(sSql)

    End Sub

    Public Sub excluirAssociacaoArtigosNREmpresa(ByVal iIDEmpresa As Integer)
        Dim sSql As String

        sSql = "DELETE FROM  " &
                 "   NR_Artigo_Empresa  " &
                "WHERE  " &
                "    IDEmpresa = @IDEmpresa "

        With MyBase.SQLCmd.Parameters
            .Clear()
            .AddWithValue("@IDEmpresa ", iIDEmpresa)
        End With

        MyBase.executarAcao(sSql)

    End Sub

    Public Sub inserirAssociacaoArtigosNREmpresa(ByVal iIDEmpresa As Integer,
                                                 ByVal iIDNR As Integer,
                                                 ByVal iIDArtigo As Integer)
        Dim sSql As String

        sSql = " INSERT INTO  " &
                "   NR_Artigo_Empresa(  " &
                "     IDEmpresa,  " &
                "     IDNR,  " &
                "     IDArtigo )  " &
                " VALUES (  " &
                "     @IDEmpresa,  " &
                "     @IDNR,  " &
                "     @IDArtigo )  "

        With MyBase.SQLCmd.Parameters
            .Clear()
            .AddWithValue("@IDEmpresa ", iIDEmpresa)
            .AddWithValue("@IDNR ", iIDNR)
            .AddWithValue("@IDArtigo ", iIDArtigo)
        End With

        MyBase.executarAcao(sSql)

    End Sub

    Public Function selecionarAssociacaoArtigosNREmpresa() As DataSet

        Dim sSql As String

        sSql = " SELECT  " &
                "   NR_Artigo_Empresa.*  " &
                " FROM  " &
                "   NR_Artigo_Empresa  " &
                " WHERE  " &
                "   IDEmpresa =  @IDEmpresa  "

        With MyBase.SQLCmd.Parameters
            .Clear()
            .AddWithValue("@IDEmpresa ", Globais.iIDEmpresa)
        End With

        Return MyBase.executarConsulta(sSql, "NR_Artigo_Empresa ")

    End Function

    Public Function Retornar_CheckList(ByVal iIDEmpresa As Integer,
                                       ByVal iIDCheckList As Integer,
                                       ByVal iIDNR As Integer) As DataTable
        Dim sSql As String

        sSql = "SELECT NR.IDNR,A.CodArtigo + A.Letra as Artigo, A.Penalidade,  "
        sSql &= "      Q.IDQuestao, Q.Questao, CI.StatusItem, CI.Justificativa, D.NomeArquivo, D.IDTipo as IDArquivo,  "
        sSql &= "      D.Descricao as DescricaoArquivo, Ar.Arquivo, D.IDDocumento  "
        sSql &= " FROM NR "
        sSql &= "      INNER JOIN NR_Empresa NRE ON NR.IDNR = NRE.IDNR  "
        sSql &= "      INNER JOIN Artigo A On A.IDNR = NR.IDNR "
        sSql &= "      LEFT JOIN Questao Q On A.IDArtigo = Q.IDARtigo "
        sSql &= "      LEFT JOIN CheckList_Itens CI On Q.IDQuestao = CI.IDQuestao  "
        If (iIDCheckList > 0) Then
            sSql &= "                                 AND CI.IDCheckList = @IDCheckList "
            sSql &= "      LEFT JOIN Documento D On D.IDTipo = CI.IDItem AND D.Tipo = @TipoDocumento  "
            sSql &= "      LEFT JOIN Arquivo Ar On D.IDDocumento = Ar.IDDocumento  "
        Else
            sSql &= "                                 AND CI.IDCheckList IS NULL "
            sSql &= "      LEFT JOIN Documento D On D.IDTipo = CI.IDItem AND D.Tipo IS NULL  "
            sSql &= "      LEFT JOIN Arquivo Ar On D.IDDocumento = Ar.IDDocumento  "
        End If

        sSql &= " WHERE ISNULL(NRE.IDEmpresa, @IDEmpresa) = @IDEmpresa "

        If (iIDNR > 0) Then
            sSql &= "  AND NRE.IDNR = @IDNR "
        End If

        With MyBase.SQLCmd.Parameters
            .Clear()

            If (iIDCheckList > 0) Then
                .AddWithValue("@IDCheckList ", iIDCheckList)
            End If
            .AddWithValue("@TipoDocumento ", Persistencia.Globais.eTipoArquivo.Evidência)
            .AddWithValue("@IDEmpresa ", iIDEmpresa)
            If (iIDNR > 0) Then
                .AddWithValue("@IDNR ", iIDNR)
            End If
        End With

        Return MyBase.executarConsulta(sSql)

    End Function

    Public Function Retornar_Descricao_NR(ByVal iIDNR As Integer) As String
        Dim sSql As String
        Dim dtDados As New DataTable

        sSql = "SELECT Descricao "
        sSql &= " FROM NR "
        sSql &= "WHERE IDNR = @IDNR "

        With MyBase.SQLCmd.Parameters
            .Clear()
            .AddWithValue("@IDNR ", iIDNR)
        End With

        Return MyBase.executarConsultaCampo(sSql)

    End Function

    Public Function selecionarNRRelatorio(ByVal iIdEmpresa As Integer,
                                          ByVal sIdsEmpresasAcesso As String,
                                          ByVal dtData As Date,
                                          ByVal iIdNR As Integer) As DataSet

        Dim sSql As String

        Try

            sSql = "  SELECT  "
            sSql &= "   IDNR,  "
            sSql &= "   SUM(Total) AS Total,  "
            sSql &= "   SUM(ISNULL(A,0))AS OK, "
            sSql &= "   SUM(ISNULL(B,0))AS NOk,  "
            sSql &= "   IDEMPRESA  "
            sSql &= " FROM   "
            sSql &= "   (SELECT NRE.IDNR,  NRE.IDEMPRESA, COUNT(CI.IDCheckList) AS Total,   "
            sSql &= "       CASE WHEN StatusItem = 1 THEN COUNT(CI.IDCheckList) END AS A,   "
            sSql &= "       CASE WHEN StatusItem = 2 THEN COUNT(CI.IDCheckList) END AS B  "
            sSql &= " FROM NR_Empresa NRE  "
            sSql &= "   LEFT JOIN CheckList C ON (C.IDNR = NRE.IDNR  "
            sSql &= "   AND (NOT C.Data IS NULL AND CONVERT(DATETIME, DATEADD(mm,NRE.Validade,C.Data),103)> @Data))   "
            sSql &= "       OR C.IDNR IS NULL  "
            sSql &= "   LEFT JOIN CheckList_Itens CI ON C.IDCheckList = CI.IDCheckList  "
            sSql &= " WHERE 1=1 "

            If iIdEmpresa > 0 Then
                sSql &= " AND (NRE.IDEmpresa = @IDEmpresa)  "
            ElseIf sIdsEmpresasAcesso <> String.Empty Then
                sSql &= " AND (NRE.IDEmpresa IN (  " & sIdsEmpresasAcesso & " ))  "
            End If

            If iIdNR > 0 Then
                sSql &= " AND NRE.IDNR = @IDNR "
            End If

            sSql &= " GROUP BY CI.StatusItem,NRE.IDNR,NRE.IDEMPRESA) AS Tabela "
            sSql &= " GROUP BY IDNR, IDEMPRESA  "

            With MyBase.SQLCmd.Parameters

                .Clear()

                .AddWithValue("@Data ", dtData)

                If iIdEmpresa > 0 Then
                    .AddWithValue("@IDEmpresa ", iIdEmpresa)
                End If

                If iIdNR > 0 Then
                    .AddWithValue("@IDNR ", iIdNR)
                End If

            End With

            Return MyBase.executarConsulta(sSql, "Empresa ")

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao tentar selecionar os dados da Empresa. " & Environment.NewLine & ex.Message)
        End Try

    End Function

    Public Function selecionarNRAuditoriaRelatorio(ByVal iIdEmpresa As Integer,
                                                   ByVal sIdsEmpresasAcesso As String,
                                                   ByVal dtData As Date,
                                                   ByVal iIdNR As Integer) As DataSet

        Dim sSql As String

        Try

            sSql = "  SELECT  "
            sSql &= "   IDNR,  "
            sSql &= "   SUM(Total) AS Total,  "
            sSql &= "   SUM(ISNULL(A,0))AS OK, "
            sSql &= "   SUM(ISNULL(B,0))AS NOk,  "
            sSql &= "   IDEMPRESA  "
            sSql &= " FROM   "
            sSql &= "   (SELECT NRE.IDNR,  NRE.IDEMPRESA, COUNT(AI.IDCheckList) AS Total,   "
            sSql &= "       CASE WHEN Status_Item = 1 THEN COUNT(AI.IDCheckList) END AS A,   "
            sSql &= "       CASE WHEN Status_Item = 2 THEN COUNT(AI.IDCheckList) END AS B  "
            sSql &= " FROM NR_Empresa NRE  "
            sSql &= "   LEFT JOIN CheckList C ON C.IDNR = NRE.IDNR  "
            sSql &= "    LEFT JOIN Auditoria A ON (A.IDCheckList = C.IDCheckList  "
            sSql &= "   AND (NOT A.Data IS NULL AND CONVERT(DATETIME, DATEADD(mm,NRE.Validade,A.Data),103)> @Data))   "
            sSql &= "       OR C.IDNR IS NULL  "
            sSql &= "   LEFT JOIN Auditoria_Itens AI ON A.IDAuditoria = AI.IDAuditoria  "
            sSql &= " WHERE 1=1 "

            If iIdEmpresa > 0 Then
                sSql &= " AND (NRE.IDEmpresa = @IDEmpresa)  "
            ElseIf sIdsEmpresasAcesso <> String.Empty Then
                sSql &= " AND (NRE.IDEmpresa IN (  " & sIdsEmpresasAcesso & " ))  "
            End If

            If iIdNR > 0 Then
                sSql &= " AND NRE.IDNR = @IDNR "
            End If

            sSql &= " GROUP BY AI.Status_Item,NRE.IDNR,NRE.IDEMPRESA) AS Tabela "
            sSql &= " GROUP BY IDNR, IDEMPRESA  "

            With MyBase.SQLCmd.Parameters

                .Clear()

                .AddWithValue("@Data ", dtData)

                If iIdEmpresa > 0 Then
                    .AddWithValue("@IDEmpresa ", iIdEmpresa)
                End If

                If iIdNR > 0 Then
                    .AddWithValue("@IDNR ", iIdNR)
                End If

            End With

            Return MyBase.executarConsulta(sSql, "Empresa ")

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao tentar selecionar os dados da Empresa. " & Environment.NewLine & ex.Message)
        End Try

    End Function

    Public Function sePermiteExcluirArtigo(ByVal iIdArtigo As Integer) As Boolean
        Dim sSql As String
        Dim dtbDados As New DataTable

        sSql = "SELECT IDArtigo "
        sSql &= "  FROM NR_Artigo_Empresa "
        sSql &= " WHERE IDArtigo = @IDArtigo "

        With MyBase.SQLCmd.Parameters
            .Clear()
            .AddWithValue("@IDArtigo ", iIdArtigo)
        End With

        dtbDados = MyBase.executarConsulta(sSql)

        Return (dtbDados.Rows.Count = 0)

    End Function

End Class
