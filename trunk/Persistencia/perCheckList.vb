Public Class perCheckList
    Inherits AcessoBd

    Public Enum eStatusCheckList
        Cadastrado = 0
        Concluido = 1
    End Enum

    Public Enum eSituacaoItem
        SemResposta = 0
        Ok = 1
        NaoOk = 2
    End Enum

#Region "Variáveis"
    Private objProximoID As New ProximoID
#End Region

#Region "Propriedades"
    ReadOnly Property sqlConsulta()
        Get
            Dim sSql As String
            sSql = "SELECT CL.IDCheckList as ID, CL.IDNR as NR, " & vbCrLf
            sSql &= "       CASE WHEN CL.StatusCheckList = 0 THEN 'Cadastrado' ELSE 'Concluído' END AS Status," & vbCrLf
            sSql &= "       CL.Data AS Data" & vbCrLf
            sSql &= "  FROM CheckList CL" & vbCrLf
            sSql &= " WHERE CL.IDEmpresa = " & Persistencia.Globais.iIDEmpresa

            Return sSql
        End Get
    End Property

    ReadOnly Property sqlConsulta_Concluidos()
        Get
            Dim sSql As String
            sSql = "SELECT CL.IDCheckList as ID, CL.IDNR as NR, " & vbCrLf
            sSql &= "       CL.Data AS Data" & vbCrLf
            sSql &= "  FROM CheckList CL" & vbCrLf
            sSql &= " WHERE CL.IDEmpresa = " & Persistencia.Globais.iIDEmpresa
            sSql &= "   AND CL.StatusCheckList = " & perCheckList.eStatusCheckList.Concluido

            Return sSql
        End Get
    End Property
#End Region

    Public Sub Alterar_Status_CheckList(ByVal iIDCheckList As Integer, ByVal iStatus As Integer)
        Dim sSql As String

        sSql = "UPDATE CheckList" & vbCrLf
        sSql &= "  SET StatusCheckList = @Status" & vbCrLf
        sSql &= "WHERE IDCheckList = @IDCheckList" & vbCrLf

        With MyBase.SQLCmd.Parameters
            .Clear()
            .AddWithValue("@Status", iStatus)
            .AddWithValue("@IDCheckList", iIDCheckList)
        End With

        MyBase.executarAcao(sSql)
    End Sub

    Public Sub Excluir_CheckList(ByVal iIDCheckList As Integer)
        Dim sSql As String

        sSql = "DELETE CheckList" & vbCrLf
        sSql &= "WHERE IDCheckList = @IDCheckList" & vbCrLf

        With MyBase.SQLCmd.Parameters
            .Clear()
            .AddWithValue("@IDCheckList", iIDCheckList)
        End With

        MyBase.executarAcao(sSql)

    End Sub

    Public Sub Excluir_Item_CheckList(ByVal iIDCheckList As Integer)
        Dim sSql As String

        sSql = "DELETE CheckList_Itens" & vbCrLf
        sSql &= "WHERE IDCheckList = @IDCheckList" & vbCrLf

        With MyBase.SQLCmd.Parameters
            .Clear()
            .AddWithValue("@IDCheckList", iIDCheckList)
        End With

        MyBase.executarAcao(sSql)

    End Sub

    Public Function Inserir_CheckList(ByVal iIDEmpresa As Integer, ByVal iIDNR As Integer, _
                                      ByVal dtData As Date, ByVal iStatus As Integer) As Integer
        Dim sSql As String
        Dim iIDCheckList As Integer

        sSql = "INSERT INTO CheckList(" & vbCrLf
        sSql &= "           IDCheckList, " & vbCrLf
        sSql &= "           IDEmpresa, " & vbCrLf
        sSql &= "           IDNR," & vbCrLf
        sSql &= "           Data," & vbCrLf
        sSql &= "           StatusCheckList" & vbCrLf
        sSql &= ") " & vbCrLf
        sSql &= "           VALUES(" & vbCrLf
        sSql &= "           @IDCheckList," & vbCrLf
        sSql &= "           @IDEmpresa," & vbCrLf
        sSql &= "           @IDNR, " & vbCrLf
        sSql &= "           @Data," & vbCrLf
        sSql &= "           @Status" & vbCrLf
        sSql &= ")"

        iIDCheckList = objProximoID.BuscaID("IDCheckList", "CheckList")

        With MyBase.SQLCmd.Parameters
            .Clear()
            .AddWithValue("@IDCheckList", iIDCheckList)
            .AddWithValue("@IDEmpresa", iIDEmpresa)
            .AddWithValue("@IDNR", iIDNR)
            .AddWithValue("@Data", dtData.ToString("dd/MM/yyyy"))
            .AddWithValue("@Status", iStatus)
        End With

        MyBase.executarAcao(sSql)

        Return iIDCheckList

    End Function

    Public Function Inserir_Item_CheckList(ByVal iIDCheckList As Integer, ByVal iIDQuestao As Integer, _
                                           ByVal iSituacao As Integer, ByVal sJustificativa As String) As Integer
        Dim sSql As String
        Dim iIDItem As Integer

        sSql = "INSERT INTO CheckList_Itens(" & vbCrLf
        sSql &= "           IDItem, " & vbCrLf
        sSql &= "           IDCheckList, " & vbCrLf
        sSql &= "           IDQuestao," & vbCrLf
        sSql &= "           StatusItem," & vbCrLf
        sSql &= "           Justificativa" & vbCrLf
        sSql &= ") " & vbCrLf
        sSql &= "           VALUES(" & vbCrLf
        sSql &= "           @IDItem," & vbCrLf
        sSql &= "           @IDCheckList," & vbCrLf
        sSql &= "           @IDQuestao, " & vbCrLf
        sSql &= "           @StatusItem," & vbCrLf
        sSql &= "           @Justificativa" & vbCrLf
        sSql &= ")"

        iIDItem = objProximoID.BuscaID("IDItem", "CheckList_Itens")

        With MyBase.SQLCmd.Parameters
            .Clear()
            .AddWithValue("@IDItem", iIDItem)
            .AddWithValue("@IDCheckList", iIDCheckList)
            .AddWithValue("@IDQuestao", Conversao.zeroParaNulo(iIDQuestao))
            .AddWithValue("@StatusItem", iSituacao)
            .AddWithValue("@Justificativa", sJustificativa)
        End With

        MyBase.executarAcao(sSql)

        Return iIDItem

    End Function

    Public Function Retornar_Dados_CheckList(ByVal iIDCheckList As Integer) As DataTable
        Dim sSql As String = ""

        sSql = "SELECT CL.IDNr,NR.Descricao as DescricaoNR, CL.Data, CL.StatusCheckList" & vbCrLf
        sSql &= " FROM CheckList CL " & vbCrLf
        sSql &= "      INNER JOIN NR ON CL.IDNr = NR.IDNR" & vbCrLf
        sSql &= "WHERE CL.IDCheckList = @IDCheckList"

        With MyBase.SQLCmd.Parameters
            .Clear()
            .AddWithValue("@IDCheckList", iIDCheckList)
        End With

        Return MyBase.executarConsulta(sSql)

    End Function

    Public Function Retornar_CheckList_Atrasados(ByVal iIDEmpresa As Integer, ByVal dtData As Date) As DataTable
        Dim sSql As String

        sSql = "SELECT NRE.IDNR, CAST(NR.Descricao AS NVARCHAR(MAX)) AS DescricaoNR," & vbCrLf
        sSql &= "      CONVERT(DATETIME, @Data,103) AS Validade," & vbCrLf
        sSql &= "      CL.IDCheckList, NULL as DataCheckList " & vbCrLf
        sSql &= " FROM NR_EMPRESA NRE " & vbCrLf
        sSql &= "      INNER JOIN NR ON NRE.IDNR = NR.IDNR" & vbCrLf
        sSql &= "      LEFT JOIN CHECKLIST CL ON CL.IDNR = NRE.IDNR" & vbCrLf
        sSql &= " WHERE(NRE.IDEMPRESA = @Empresa)" & vbCrLf
        sSql &= "   AND NRE.IDNR NOT IN (SELECT IDNR FROM CHECKLIST WHERE IDEMPRESA = @Empresa AND STATUSCHECKLIST = @StatusCheckList)"

        sSql &= " UNION ALL" & vbCrLf

        sSql &= " SELECT NRE.IDNR, CAST(NR.Descricao AS NVARCHAR(MAX)) AS DescricaoNR," & vbCrLf
        sSql &= "        CONVERT(DATETIME, DATEADD(MM, NRE.VALIDADE,MAX(DATA)),103) AS Validade," & vbCrLf
        sSql &= "        CL.IDChecklist, CL.Data as DataCheckList"
        sSql &= "   FROM CHECKLIST CL" & vbCrLf
        sSql &= "        INNER JOIN NR_EMPRESA NRE ON CL.IDNR = NRE.IDNR" & vbCrLf
        sSql &= "        INNER JOIN NR ON NRE.IDNR = NR.IDNR" & vbCrLf
        sSql &= "  WHERE STATUSCHECKLIST = @StatusCheckList" & vbCrLf
        sSql &= "    AND NRE.IDEMPRESA = " & Globais.iIDEmpresa & vbCrLf
        sSql &= "GROUP BY NRE.IDNR, NRE.VALIDADE,CAST(NR.Descricao AS NVARCHAR(MAX)), CL.IDCheckList, CL.Data" & vbCrLf
        sSql &= "  HAVING CONVERT(DATETIME, DATEADD(MM, NRE.VALIDADE,MAX(DATA)),103) < @Data" & vbCrLf
        sSql &= "ORDER BY Validade"

        With MyBase.SQLCmd.Parameters
            .Clear()
            .AddWithValue("@Data", dtData.ToString("dd/MM/yyyy"))
            .AddWithValue("@Empresa", iIDEmpresa)
            .AddWithValue("@StatusCheckList", eStatusCheckList.Concluido)
        End With

        Return MyBase.executarConsulta(sSql)

    End Function

    Public Function Retornar_NR_CheckList(ByVal iIDEmpresa As Integer, ByVal DtData As Date) As String
        Dim sSql As String

        sSql = "SELECT NRE.IDNR, CAST(NR.Descricao AS NVARCHAR(MAX)) AS Descrição," & vbCrLf
        sSql &= "      CONVERT(DATETIME, GETDATE(),103) AS Vencimento" & vbCrLf
        sSql &= " FROM NR_EMPRESA NRE " & vbCrLf
        sSql &= "      INNER JOIN NR ON NRE.IDNR = NR.IDNR" & vbCrLf
        sSql &= "      LEFT JOIN CHECKLIST CL ON CL.IDNR = NRE.IDNR" & vbCrLf
        sSql &= " WHERE(NRE.IDEMPRESA = " & Globais.iIDEmpresa & " AND CL.STATUSCHECKLIST Is NULL)" & vbCrLf

        sSql &= " UNION ALL" & vbCrLf

        sSql &= " SELECT NRE.IDNR, CAST(NR.Descricao AS NVARCHAR(MAX)) AS Descrição," & vbCrLf
        sSql &= "        CONVERT(DATETIME, DATEADD(MM, NRE.VALIDADE,MAX(DATA)),103) AS Vencimento" & vbCrLf
        sSql &= "   FROM CHECKLIST CL" & vbCrLf
        sSql &= "        INNER JOIN NR_EMPRESA NRE ON CL.IDNR = NRE.IDNR" & vbCrLf
        sSql &= "        INNER JOIN NR ON NRE.IDNR = NR.IDNR" & vbCrLf
        sSql &= "  WHERE STATUSCHECKLIST = 1" & vbCrLf
        sSql &= "    AND NRE.IDEMPRESA = " & Globais.iIDEmpresa & vbCrLf
        sSql &= "GROUP BY NRE.IDNR, NRE.VALIDADE,CAST(NR.Descricao AS NVARCHAR(MAX))" & vbCrLf
        sSql &= "ORDER BY Vencimento"

        Return sSql

    End Function

    Public Function Validar_Periodo_CheckList(ByVal dtDatainicio As Date, _
                                              ByVal iIDNR As Integer, _
                                              ByVal iIDEmpresa As Integer) As Boolean
        Dim bRetorno As Boolean = True
        Dim sSql As String
        Dim dtbDados As New DataTable

        sSql = "SELECT IDCheckList" & vbCrLf
        sSql &= " FROM CheckList" & vbCrLf
        sSql &= "WHERE @DtInicio BETWEEN DtInicio AND DtFim" & vbCrLf
        sSql &= "  AND IDNR = @IDNR" & vbCrLf
        sSql &= "  AND IDEmpresa = @IDEmpresa" & vbCrLf

        With MyBase.SQLCmd.Parameters
            .Clear()
            .AddWithValue("@DtInicio", dtDatainicio)
            .AddWithValue("@IDNR", iIDNR)
            .AddWithValue("@IDEmpresa", iIDEmpresa)
        End With

        dtbDados = MyBase.executarConsulta(sSql)

        Return (dtbDados.Rows.Count = 0)

    End Function

    Public Function Validar_Exclusao_CheckList(ByVal iIDCheckList As Integer) As Boolean

        Dim bRetorno As Boolean = True
        Dim sSql As String
        Dim dtbDados As New DataTable

        sSql = "SELECT IDCheckList" & vbCrLf
        sSql &= " FROM Auditoria" & vbCrLf
        sSql &= "WHERE " & vbCrLf
        sSql &= "  IDCheckList = @IDCheckList" & vbCrLf

        With MyBase.SQLCmd.Parameters
            .Clear()
            .AddWithValue("@IDCheckList", iIDCheckList)
        End With

        dtbDados = MyBase.executarConsulta(sSql)

        Return (dtbDados.Rows.Count = 1)

    End Function

End Class
