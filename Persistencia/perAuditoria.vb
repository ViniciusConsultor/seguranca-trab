Public Class perAuditoria
    Inherits perAcessoBD

#Region "Enumerações "

    Public Enum eStatusAuditoria
        Cadastrado = 0
        Concluido = 1
    End Enum

    Public Enum eSituacaoItem
        SemResposta = 0
        Ok = 1
        NaoOk = 2
    End Enum

#End Region

#Region "Variáveis "
    Private objProximoID As New ProximoID
#End Region

#Region "Propriedades "
    ReadOnly Property sqlConsulta()
        Get
            Dim sSql As String
            sSql = "SELECT AU.IDAuditoria as Auditoria, CL.IDNR as NR,  "
            sSql &= "      CASE WHEN AU.Status = 0 THEN 'Iniciado' ELSE 'Concluído' END AS Status, "
            sSql &= "      AU.Data AS Data "
            sSql &= "  FROM Auditoria AU "
            sSql &= "       INNER JOIN CheckList CL On Au.IDCheckList =  CL.IDCheckList "
            sSql &= "              AND CL.IDEmpresa =  " & Persistencia.Globais.iIDEmpresa

            Return sSql
        End Get
    End Property
#End Region


    Public Function Retorna_Itens_Auditoria(ByVal iIDCheckList As Integer,
                                            ByVal iIDAuditoria As Integer) As DataTable

        Dim sSql As String

        sSql = "SELECT A.CodArtigo + A.Letra as Artigo, "
        sSql &= "      Q.Questao, CI.StatusItem, "
        sSql &= "      CI.Justificativa,   "
        sSql &= "      AUI.Status_Item, AUI.Justificativa as Auditoria, CI.IDItem,  "
        sSql &= "      D.NomeArquivo, D.IDTipo as IDArquivo,  "
        sSql &= "      D.Descricao as DescricaoArquivo, Ar.Arquivo, D.IDDocumento  "
        sSql &= " FROM CheckList_Itens CI "
        sSql &= "      INNER JOIN Questao Q On CI.IDQuestao = Q.IDQuestao "
        sSql &= "      INNER JOIN Artigo A On Q.IDArtigo = A.IDArtigo "
        sSql &= "      LEFT JOIN Auditoria_Itens AUI ON AUI.IDItem = CI.IDItem  "

        If (iIDAuditoria > 0) Then
            sSql &= "               AND AUI.IDAuditoria = @IDAuditoria  "
            sSql &= "      LEFT JOIN Documento D On D.IDTipo = AUI.IDItem AND D.Tipo = @TipoDocumento  "
            sSql &= "      LEFT JOIN Arquivo Ar On D.IDDocumento = Ar.IDDocumento  "
        Else
            sSql &= "               AND AUI.IDAuditoria IS NULL "
            sSql &= "      LEFT JOIN Documento D On D.IDTipo = AUI.IDItem AND D.Tipo IS NULL  "
            sSql &= "      LEFT JOIN Arquivo Ar On D.IDDocumento = Ar.IDDocumento  "
        End If

        sSql &= "WHERE CI.IDCheckList = @IDCheckList "

        With MyBase.SQLCmd.Parameters
            .Clear()
            .AddWithValue("@IDAuditoria ", iIDAuditoria)
            .AddWithValue("@TipoDocumento ", Globais.eTipoArquivo.Auditoria)
            .AddWithValue("@IDCheckList ", iIDCheckList)
        End With

        Return MyBase.executarConsulta(sSql)

    End Function

    Public Sub Alterar_Status_Auditoria(ByVal iIDAuditoria As Integer, ByVal iStatus As Integer)
        Dim sSql As String

        sSql = "UPDATE Auditoria "
        sSql &= "  SET Status = @Status "
        sSql &= "WHERE IDAuditoria = @IDAuditoria "

        With MyBase.SQLCmd.Parameters
            .Clear()
            .AddWithValue("@Status ", iStatus)
            .AddWithValue("@IDAuditoria ", iIDAuditoria)
        End With

        MyBase.executarAcao(sSql)
    End Sub

    Public Sub Excluir_Auditoria(ByVal iIDAuditoria As Integer)
        Dim sSql As String

        sSql = "DELETE Auditoria "
        sSql &= "WHERE IDAuditoria = @IDAuditoria "

        With MyBase.SQLCmd.Parameters
            .Clear()
            .AddWithValue("@IDAuditoria ", iIDAuditoria)
        End With

        MyBase.executarAcao(sSql)

    End Sub

    Public Sub Excluir_Item_Auditoria(ByVal iIDAuditoria As Integer)
        Dim sSql As String

        sSql = "DELETE Auditoria_Itens "
        sSql &= "WHERE IDAuditoria = @IDAuditoria "

        With MyBase.SQLCmd.Parameters
            .Clear()
            .AddWithValue("@IDAuditoria ", iIDAuditoria)
        End With

        MyBase.executarAcao(sSql)

    End Sub

    Public Function Inserir_Auditoria(ByVal iIDEmpresa As Integer, ByVal iIDCheckList As Integer, _
                                      ByVal dtData As Date, ByVal iStatus As Integer) As Integer
        Dim sSql As String
        Dim iIDAuditoria As Integer

        sSql = "INSERT INTO Auditoria( "
        sSql &= "           IDAuditoria,  "
        sSql &= "           IDCheckList, "
        sSql &= "           Data, "
        sSql &= "           Status "
        sSql &= ")  "
        sSql &= "           VALUES( "
        sSql &= "           @IDAuditoria, "
        sSql &= "           @IDChecklist,  "
        sSql &= "           @Data, "
        sSql &= "           @Status "
        sSql &= ") "

        iIDAuditoria = objProximoID.BuscaID("IDAuditoria ", "Auditoria ")

        With MyBase.SQLCmd.Parameters
            .Clear()
            .AddWithValue("@IDAuditoria ", iIDAuditoria)
            .AddWithValue("@IDCheckList ", iIDCheckList)
            .AddWithValue("@Data ", dtData)
            .AddWithValue("@Status ", iStatus)
        End With

        MyBase.executarAcao(sSql)

        Return iIDAuditoria

    End Function

    Public Function Inserir_Item_Auditoria(ByVal iIDAuditoria As Integer, ByVal iIDCheckList As Integer, _
                                           ByVal iIDItem As Integer, ByVal iSituacao As Integer, _
                                           ByVal sJustificativa As String) As Integer
        Dim sSql As String

        sSql = "INSERT INTO Auditoria_Itens( "
        sSql &= "           IDAuditoria,  "
        sSql &= "           IDCheckList,  "
        sSql &= "           IDItem, "
        sSql &= "           Status_Item, "
        sSql &= "           Justificativa "
        sSql &= ")  "
        sSql &= "           VALUES( "
        sSql &= "           @IDAuditoria, "
        sSql &= "           @IDCheckList, "
        sSql &= "           @IDItem,  "
        sSql &= "           @Status_Item, "
        sSql &= "           @Justificativa "
        sSql &= ") "

        With MyBase.SQLCmd.Parameters
            .Clear()
            .AddWithValue("@IDAuditoria ", iIDAuditoria)
            .AddWithValue("@IDCheckList ", iIDCheckList)
            .AddWithValue("@IDItem ", iIDItem)
            .AddWithValue("@Status_Item ", iSituacao)
            .AddWithValue("@Justificativa ", sJustificativa)
        End With

        MyBase.executarAcao(sSql)

    End Function

    Public Function Retornar_Dados_Auditoria(ByVal iIDAuditoria As Integer) As DataTable
        Dim sSql As String = " "

        sSql = "SELECT AU.IDAuditoria, AU.Data as DataAuditoria, AU.Status, "
        sSql &= "      Cl.IDCheckList, CL.IDNr, CL.Data as DataCheck, NR.Descricao "
        sSql &= " FROM Auditoria AU "
        sSql &= "      INNER JOIN CheckList CL ON AU.IDCheckList = CL.IDCheckList "
        sSql &= "      INNER JOIN NR ON CL.IDNR = NR.IDNR "
        sSql &= "WHERE AU.IDAuditoria = @IDAuditoria "

        With MyBase.SQLCmd.Parameters
            .Clear()
            .AddWithValue("@IDAuditoria ", iIDAuditoria)
        End With

        Return MyBase.executarConsulta(sSql)

    End Function

End Class
