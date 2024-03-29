﻿Public Class perCheckList
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

#Region "Variáveis "
    Private objProximoID As New ProximoID
#End Region

#Region "Propriedades "
    ReadOnly Property sqlConsulta()
        Get
            Dim sSql As String
            sSql = "SELECT CL.IDCheckList as ID, CL.IDNR as NR,  "
            sSql &= "       CASE WHEN CL.StatusCheckList = 0 THEN 'Cadastrado' ELSE 'Concluído' END AS Status, "
            sSql &= "       CL.Data AS Data "
            sSql &= "  FROM CheckList CL "
            sSql &= " WHERE CL.IDEmpresa =  " & Persistencia.Globais.iIDEmpresa

            Return sSql
        End Get
    End Property

    ReadOnly Property sqlConsulta_Concluidos()
        Get
            Dim sSql As String
            sSql = "SELECT CL.IDCheckList as ID, CL.IDNR as NR,  "
            sSql &= "       CL.Data AS Data "
            sSql &= "  FROM CheckList CL "
            sSql &= " WHERE CL.IDEmpresa =  " & Persistencia.Globais.iIDEmpresa
            sSql &= "   AND CL.StatusCheckList =  " & perCheckList.eStatusCheckList.Concluido

            Return sSql
        End Get
    End Property
#End Region

    Public Sub Alterar_Status_CheckList(ByVal iIDCheckList As Integer, ByVal iStatus As Integer)
        Dim sSql As String

        sSql = "UPDATE CheckList "
        sSql &= "  SET StatusCheckList = @Status "
        sSql &= "WHERE IDCheckList = @IDCheckList "

        With MyBase.SQLCmd.Parameters
            .Clear()
            .AddWithValue("@Status ", iStatus)
            .AddWithValue("@IDCheckList ", iIDCheckList)
        End With

        MyBase.executarAcao(sSql)
    End Sub

    Public Sub Excluir_CheckList(ByVal iIDCheckList As Integer)
        Dim sSql As String

        sSql = "DELETE CheckList "
        sSql &= "WHERE IDCheckList = @IDCheckList "

        With MyBase.SQLCmd.Parameters
            .Clear()
            .AddWithValue("@IDCheckList ", iIDCheckList)
        End With

        MyBase.executarAcao(sSql)

    End Sub

    Public Sub Excluir_Item_CheckList(ByVal iIDCheckList As Integer)
        Dim sSql As String

        sSql = "DELETE CheckList_Itens "
        sSql &= "WHERE IDCheckList = @IDCheckList "

        With MyBase.SQLCmd.Parameters
            .Clear()
            .AddWithValue("@IDCheckList ", iIDCheckList)
        End With

        MyBase.executarAcao(sSql)

    End Sub

    Public Function Inserir_CheckList(ByVal iIDEmpresa As Integer, ByVal iIDNR As Integer, _
                                      ByVal dtData As Date, ByVal iStatus As Integer) As Integer
        Dim sSql As String
        Dim iIDCheckList As Integer

        sSql = "INSERT INTO CheckList( "
        sSql &= "           IDCheckList,  "
        sSql &= "           IDEmpresa,  "
        sSql &= "           IDNR, "
        sSql &= "           Data, "
        sSql &= "           StatusCheckList "
        sSql &= ")  "
        sSql &= "           VALUES( "
        sSql &= "           @IDCheckList, "
        sSql &= "           @IDEmpresa, "
        sSql &= "           @IDNR,  "
        sSql &= "           @Data, "
        sSql &= "           @Status "
        sSql &= ") "

        iIDCheckList = objProximoID.BuscaID("IDCheckList ", "CheckList ")

        With MyBase.SQLCmd.Parameters
            .Clear()
            .AddWithValue("@IDCheckList ", iIDCheckList)
            .AddWithValue("@IDEmpresa ", iIDEmpresa)
            .AddWithValue("@IDNR ", iIDNR)
            .AddWithValue("@Data ", dtData.ToString("dd/MM/yyyy "))
            .AddWithValue("@Status ", iStatus)
        End With

        MyBase.executarAcao(sSql)

        Return iIDCheckList

    End Function

    Public Function Inserir_Item_CheckList(ByVal iIDCheckList As Integer, ByVal iIDQuestao As Integer, _
                                           ByVal iSituacao As Integer, ByVal sJustificativa As String) As Integer
        Dim sSql As String
        Dim iIDItem As Integer

        sSql = "INSERT INTO CheckList_Itens( "
        sSql &= "           IDItem,  "
        sSql &= "           IDCheckList,  "
        sSql &= "           IDQuestao, "
        sSql &= "           StatusItem, "
        sSql &= "           Justificativa "
        sSql &= ")  "
        sSql &= "           VALUES( "
        sSql &= "           @IDItem, "
        sSql &= "           @IDCheckList, "
        sSql &= "           @IDQuestao,  "
        sSql &= "           @StatusItem, "
        sSql &= "           @Justificativa "
        sSql &= ") "

        iIDItem = objProximoID.BuscaID("IDItem ", "CheckList_Itens ")

        With MyBase.SQLCmd.Parameters
            .Clear()
            .AddWithValue("@IDItem ", iIDItem)
            .AddWithValue("@IDCheckList ", iIDCheckList)
            .AddWithValue("@IDQuestao ", Conversao.zeroParaNulo(iIDQuestao))
            .AddWithValue("@StatusItem ", iSituacao)
            .AddWithValue("@Justificativa ", sJustificativa)
        End With

        MyBase.executarAcao(sSql)

        Return iIDItem

    End Function

    Public Function Retornar_Dados_CheckList(ByVal iIDCheckList As Integer) As DataTable
        Dim sSql As String = " "

        sSql = "SELECT CL.IDNr,NR.Descricao as DescricaoNR, CL.Data, CL.StatusCheckList "
        sSql &= " FROM CheckList CL  "
        sSql &= "      INNER JOIN NR ON CL.IDNr = NR.IDNR "
        sSql &= "WHERE CL.IDCheckList = @IDCheckList "

        With MyBase.SQLCmd.Parameters
            .Clear()
            .AddWithValue("@IDCheckList ", iIDCheckList)
        End With

        Return MyBase.executarConsulta(sSql)

    End Function

    Public Function Retornar_CheckList_Atrasados(ByVal iIDEmpresa As Integer, ByVal dtData As Date) As DataTable
        Dim sSql As String

        sSql = "SELECT NRE.IDNR, CAST(NR.Descricao AS NVARCHAR(MAX)) AS DescricaoNR,  "
        sSql &= "      CONVERT(DATETIME, @Data,103) AS Validade,  "
        sSql &= "      CL.IDCheckList, NULL as DataCheckList  "
        sSql &= " FROM NR_EMPRESA NRE  "
        sSql &= "      INNER JOIN NR ON NRE.IDNR = NR.IDNR  "
        sSql &= "      LEFT JOIN CHECKLIST CL ON CL.IDNR = NRE.IDNR  "
        sSql &= " WHERE(NRE.IDEMPRESA = @Empresa)  "
        sSql &= "   AND NRE.IDNR NOT IN (SELECT IDNR FROM CHECKLIST WHERE IDEMPRESA = @Empresa AND STATUSCHECKLIST = @StatusCheckList)  "

        sSql &= " UNION ALL  "

        sSql &= " SELECT NRE.IDNR, CAST(NR.Descricao AS NVARCHAR(MAX)) AS DescricaoNR,  "
        sSql &= "        CONVERT(DATETIME, DATEADD(MM, NRE.VALIDADE,MAX(DATA)),103) AS Validade,  "
        sSql &= "        CL.IDChecklist, CL.Data as DataCheckList  "
        sSql &= "   FROM CHECKLIST CL  "
        sSql &= "        INNER JOIN NR_EMPRESA NRE ON CL.IDNR = NRE.IDNR  "
        sSql &= "        INNER JOIN NR ON NRE.IDNR = NR.IDNR  "
        sSql &= "  WHERE STATUSCHECKLIST = @StatusCheckList  "
        sSql &= "    AND NRE.IDEMPRESA =  " & Globais.iIDEmpresa
        sSql &= " GROUP BY NRE.IDNR, NRE.VALIDADE,CAST(NR.Descricao AS NVARCHAR(MAX)), CL.IDCheckList, CL.Data  "
        sSql &= "  HAVING CONVERT(DATETIME, DATEADD(MM, NRE.VALIDADE,MAX(DATA)),103) < @Data  "
        sSql &= " ORDER BY Validade  "

        With MyBase.SQLCmd.Parameters
            .Clear()
            .AddWithValue("@Data ", dtData.ToString("dd/MM/yyyy "))
            .AddWithValue("@Empresa ", iIDEmpresa)
            .AddWithValue("@StatusCheckList ", eStatusCheckList.Concluido)
        End With

        Return MyBase.executarConsulta(sSql)

    End Function

    Public Function Retornar_NR_CheckList(ByVal iIDEmpresa As Integer, ByVal DtData As Date) As String
        Dim sSql As String

        sSql = "SELECT NRE.IDNR, CAST(NR.Descricao AS NVARCHAR(MAX)) AS Descrição, "
        sSql &= "      CONVERT(DATETIME, GETDATE(),103) AS Vencimento "
        sSql &= " FROM NR_EMPRESA NRE  "
        sSql &= "      INNER JOIN NR ON NRE.IDNR = NR.IDNR "
        sSql &= "      LEFT JOIN CHECKLIST CL ON CL.IDNR = NRE.IDNR "
        sSql &= " WHERE(NRE.IDEMPRESA =  " & Globais.iIDEmpresa & " AND CL.STATUSCHECKLIST Is NULL) "

        sSql &= " UNION ALL "

        sSql &= " SELECT NRE.IDNR, CAST(NR.Descricao AS NVARCHAR(MAX)) AS Descrição, "
        sSql &= "        CONVERT(DATETIME, DATEADD(MM, NRE.VALIDADE,MAX(DATA)),103) AS Vencimento "
        sSql &= "   FROM CHECKLIST CL "
        sSql &= "        INNER JOIN NR_EMPRESA NRE ON CL.IDNR = NRE.IDNR "
        sSql &= "        INNER JOIN NR ON NRE.IDNR = NR.IDNR "
        sSql &= "  WHERE STATUSCHECKLIST = 1 "
        sSql &= "    AND NRE.IDEMPRESA =  " & Globais.iIDEmpresa
        sSql &= "GROUP BY NRE.IDNR, NRE.VALIDADE,CAST(NR.Descricao AS NVARCHAR(MAX)) "
        sSql &= "ORDER BY Vencimento "

        Return sSql

    End Function

    Public Function Validar_Periodo_CheckList(ByVal dtDatainicio As Date, _
                                              ByVal iIDNR As Integer, _
                                              ByVal iIDEmpresa As Integer) As Boolean
        Dim bRetorno As Boolean = True
        Dim sSql As String
        Dim dtbDados As New DataTable

        sSql = "SELECT IDCheckList "
        sSql &= " FROM CheckList "
        sSql &= "WHERE @DtInicio BETWEEN DtInicio AND DtFim "
        sSql &= "  AND IDNR = @IDNR "
        sSql &= "  AND IDEmpresa = @IDEmpresa "

        With MyBase.SQLCmd.Parameters
            .Clear()
            .AddWithValue("@DtInicio ", dtDatainicio)
            .AddWithValue("@IDNR ", iIDNR)
            .AddWithValue("@IDEmpresa ", iIDEmpresa)
        End With

        dtbDados = MyBase.executarConsulta(sSql)

        Return (dtbDados.Rows.Count = 0)

    End Function

    Public Function Validar_Exclusao_CheckList(ByVal iIDCheckList As Integer) As Boolean

        Dim bRetorno As Boolean = True
        Dim sSql As String
        Dim dtbDados As New DataTable

        sSql = "SELECT IDCheckList "
        sSql &= " FROM Auditoria "
        sSql &= "WHERE  "
        sSql &= "  IDCheckList = @IDCheckList "

        With MyBase.SQLCmd.Parameters
            .Clear()
            .AddWithValue("@IDCheckList ", iIDCheckList)
        End With

        dtbDados = MyBase.executarConsulta(sSql)

        Return (dtbDados.Rows.Count = 1)

    End Function

End Class
