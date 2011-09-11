Imports Persistencia
Public Class ctrCheckList
    Inherits ctrPadrao

#Region "Enumerações"

    Public Enum eMensagens As Byte
        PERIODO_INVÁLIDO = 0
        ITENS_EM_FALTA = 1
        STATUS_IMPEDITIVO = 2
    End Enum

#End Region

#Region "Variáveis"
    Private iPrvIDCheckList As Integer

    Private sMensagens() As String = {"Período informado conflita com outro check-list. Verifique.", _
                                      "NR sem itens a serem checados.", _
                                      "O status definido para o check-list não permite exclusão."}

    Private objCheckList As New perCheckList
    Private objDocumento As New Persistencia.perDocumento
    Private objArquivo As New Persistencia.perArquivo

#End Region

#Region "Propriedades"

    ReadOnly Property sqlConsulta()
        Get
            Return objCheckList.sqlConsulta()
        End Get
    End Property

    ReadOnly Property sqlConsulta_Concluidos()
        Get
            Return objCheckList.sqlConsulta_Concluidos()
        End Get
    End Property

    ReadOnly Property IDCheckList()
        Get
            Return iPrvIDCheckList
        End Get
    End Property

#End Region

    Private Function seBemFormado(ByVal iIDNR As Integer, _
                                  ByVal iIDEmpresa As Integer, _
                                  ByVal dsCheckList As DataSet) As Boolean

        Dim bBemFormado As Boolean = True
        Try

            If (dsCheckList.Tables(0).Rows.Count = 0) Then
                MyBase.adicionarMensagensValidacao(eMensagens.ITENS_EM_FALTA, _
                                                Me.sMensagens(eMensagens.ITENS_EM_FALTA))
                bBemFormado = False
            End If

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao validar os dados do check-list. " & Environment.NewLine & ex.Message)
        End Try

        Return bBemFormado

    End Function

    Private Function Validar_Exclusao(ByVal iStatus As Integer) As Boolean
        Dim bResultado As Boolean = True

        If (iStatus <> perCheckList.eStatusCheckList.Cadastrado) Then
            MyBase.adicionarMensagensValidacao(eMensagens.STATUS_IMPEDITIVO, _
                                            Me.sMensagens(eMensagens.STATUS_IMPEDITIVO))
            bResultado = False
        End If

        Return bResultado

    End Function

    Public Function Excluir_CheckList(ByVal iIDCheckList As Integer, ByVal iIDStatus As Integer) As Boolean
        Dim bResultado As Boolean = True

        Try

            If (Validar_Exclusao(iIDStatus)) Then
                objCheckList.Excluir_Item_CheckList(iIDCheckList)
                objCheckList.Excluir_CheckList(iIDCheckList)
            Else
                bResultado = False
            End If

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao excluir o check-list. " & Environment.NewLine & ex.Message)
        End Try

        Return bResultado

    End Function

    Public Function Salvar(ByVal iIDCheckList As Integer, ByVal iIDNR As Integer, ByVal iIDEmpresa As Integer, _
                           ByVal dtData As Date, ByVal dsCheckList As DataSet, ByVal iStatus As Integer) As Boolean

        Dim bResultado As Boolean = True
        Dim iIDQuestao As Integer
        Dim iSituacao As Integer
        Dim sJustificativa As String
        Dim iItemCheckList As Integer = 0
        Dim iIdDocumento As Integer = 0

        Try

            iPrvIDCheckList = iIDCheckList

            If (seBemFormado(iIDNR, iIDEmpresa, dsCheckList)) Then

                If (iPrvIDCheckList = 0) Then
                    iPrvIDCheckList = objCheckList.Inserir_CheckList(iIDEmpresa, iIDNR, dtData, iStatus)
                End If

                If (iPrvIDCheckList > 0) Then

                    If (iStatus = perCheckList.eStatusCheckList.Concluido) Then
                        Me.objCheckList.Alterar_Status_CheckList(iPrvIDCheckList, iStatus)
                    End If

                    objCheckList.Excluir_Item_CheckList(iPrvIDCheckList)

                    For Each drDados As DataRow In dsCheckList.Tables(0).Rows
                        Select Case drDados.Item("Situação").ToString.ToUpper.Trim
                            Case ""
                                iSituacao = perCheckList.eSituacaoItem.SemResposta
                            Case "OK"
                                iSituacao = perCheckList.eSituacaoItem.Ok
                            Case "NÃO OK"
                                iSituacao = perCheckList.eSituacaoItem.NaoOk
                            Case Else

                        End Select

                        If (iSituacao = perCheckList.eSituacaoItem.Ok Or iSituacao = perCheckList.eSituacaoItem.NaoOk) Then
                            iIDQuestao = Conversao.nuloParaZero(drDados.Item("IDQuestao"))
                            sJustificativa = Conversao.nuloParaVazio(drDados.Item("Justificativa"))
                            iItemCheckList = objCheckList.Inserir_Item_CheckList(iPrvIDCheckList, iIDQuestao, iSituacao, sJustificativa)

                            If Conversao.ToInt32(drDados.Item("IDArquivo")) > 0 Then

                                If Not String.IsNullOrEmpty(Conversao.ToString(drDados.Item("Evidência"))) Then

                                    Me.objDocumento.atualizarDocumento(drDados.Item("IDDocumento"), _
                                                                       Globais.iIDEmpresa, _
                                                                       drDados.Item("DescricaoDocumento"), _
                                                                       drDados.Item("Evidência"), _
                                                                       Globais.eTipoArquivo.Evidência, _
                                                                       iItemCheckList)

                                    Me.objArquivo.atualizarArquivo(drDados.Item("IDDocumento"), _
                                                                   drDados.Item("Arquivo"))

                                Else
                                    Me.objArquivo.excluirArquivo(drDados.Item("IDDocumento"))
                                    Me.objDocumento.excluirDocumento(drDados.Item("IDDocumento"))
                                End If

                            Else
                                If Not String.IsNullOrEmpty(Conversao.ToString(drDados.Item("Evidência"))) Then
                                    iIdDocumento = Me.objDocumento.inserirDocumento(Globais.iIDEmpresa, _
                                                                                drDados.Item("DescricaoDocumento"), _
                                                                                drDados.Item("Evidência"), _
                                                                                Globais.eTipoArquivo.Evidência, _
                                                                                iItemCheckList)
                                    Me.objArquivo.inserirArquivo(iIdDocumento, _
                                                                 drDados.Item("Arquivo"))

                                End If
                                
                            End If

                        End If
                    Next

                End If

            Else
                bResultado = False
            End If

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao salvar os dados do check-list. " & Environment.NewLine & ex.Message)
        End Try

        Return bResultado

    End Function

    Public Function Retornar_Dados_CheckList(ByVal iIDCheckList As Integer) As DataTable
        Try

            Return objCheckList.Retornar_Dados_CheckList(iIDCheckList)

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao retornar os dados do check-list. " & Environment.NewLine & ex.Message)
        End Try

    End Function

    Public Function Validar_Exclusao_CheckList(ByVal iIDCheckList As Integer) As Boolean

    End Function

    Public Function Retornar_NRs_Atrasados(ByVal iIDEmpresa As Integer, ByVal dtDataBase As Date) As DataTable
        Try
            Return objCheckList.Retornar_CheckList_Atrasados(iIDEmpresa, dtDataBase)
        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao retornar os dados do check-list. " & Environment.NewLine & ex.Message)
        End Try
    End Function

End Class
