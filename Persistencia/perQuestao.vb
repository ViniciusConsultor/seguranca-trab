Public Class perQuestao
    Inherits AcessoBd

#Region "Variáveis"
    Private objProximoID As New ProximoID
#End Region

    Public Function Inserir_Questoes(ByVal iIDArtigo As Integer, _
                                     ByVal sQuestao As String, _
                                     ByVal sAcao As String) As Integer

        Dim sSql As String
        Dim iIDQuestao As Integer

        sSql = " INSERT INTO Questao " & vbCrLf
        sSql &= "  ( " & vbCrLf
        sSql &= "       IDQuestao, " & vbCrLf
        sSql &= "       IDArtigo, " & vbCrLf
        sSql &= "       Questao, " & vbCrLf
        sSql &= "       Acao"
        sSql &= "  ) " & vbCrLf
        sSql &= " VALUES " & vbCrLf
        sSql &= "  ( " & vbCrLf
        sSql &= "       @IDQuestao, " & vbCrLf
        sSql &= "       @IDArtigo, " & vbCrLf
        sSql &= "       @Questao," & vbCrLf
        sSql &= "       @Acao"
        sSql &= "  ) "

        iIDQuestao = objProximoID.BuscaID("IDQuestao", "Questao")

        With MyBase.SQLCmd.Parameters
            .Clear()
            .AddWithValue("@IDQuestao", iIDQuestao)
            .AddWithValue("@IDArtigo", iIDArtigo)
            .AddWithValue("@Questao", sQuestao)
            .AddWithValue("@Acao", sAcao)
        End With

        MyBase.executarAcao(sSql)

        Return iIDQuestao

    End Function

    Public Sub Excluir_Questao_Por_NR(ByVal iIDNR As Integer)

        Dim sSql As String

        sSql = "  DELETE FROM " & vbCrLf
        sSql &= "   Questao " & vbCrLf
        sSql &= " WHERE IDArtigo IN ( " & vbCrLf
        sSql &= "                  SELECT IDArtigo" & vbCrLf
        sSql &= "                    FROM Artigo" & vbCrLf
        sSql &= "                   WHERE IDNR = @IDNR)" & vbCrLf

        With MyBase.SQLCmd.Parameters
            .Clear()
            .AddWithValue("@IDNR", iIDNR)
        End With

        MyBase.executarAcao(sSql)

    End Sub

    Public Function Selecionar_Questoes_NR(ByVal iIDNR As Integer) As DataTable
        Dim sSql As String

        sSql = "  SELECT "
        sSql &= "	A.CodArtigo, Q.Questao, Q.Acao,"
        sSql &= "	D.NomeArquivo, D.IDTipo as IDArquivo, "
        sSql &= "    D.Descricao as DescricaoArquivo, Ar.Arquivo, D.IDDocumento "
        sSql &= " FROM Questao Q"
        sSql &= "    INNER JOIN Artigo A ON Q.IDArtigo = A.IDArtigo"
        sSql &= "	LEFT JOIN Documento D On D.IDTipo = Q.IDQuestao AND D.Tipo = @Tipo"
        sSql &= "	LEFT JOIN Arquivo Ar On D.IDDocumento = Ar.IDDocumento "
        sSql &= " WHERE A.IDNR = @IDNR "
        sSql &= " ORDER BY Q.IDQuestao"

        With MyBase.SQLCmd.Parameters
            .Clear()
            .AddWithValue("@Tipo", Globais.eTipoArquivo.NRQuestao.GetHashCode)
            .AddWithValue("@IDNR", iIDNR)
        End With

        Return MyBase.executarConsulta(sSql)

    End Function

End Class
