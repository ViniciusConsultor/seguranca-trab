Imports Persistencia
Public Class ctrAuditoria
    Inherits ctrPadrao

#Region "Enumerações"
    Public Enum eMensagens
        DATA_INVALIDA = 0
    End Enum
#End Region

#Region "Variáveis"

    Private iPrvIDAuditoria As Integer
    Private bResultado As Boolean = False

    Private objAuditoria As New perAuditoria

    Private sMensagens() As String = {"Data da auditoria inferior a data do check-list."}

#End Region

#Region "Propriedades"
    Public ReadOnly Property IDAuditoria()
        Get
            Return iPrvIDAuditoria
        End Get
    End Property

    ReadOnly Property sqlConsulta()
        Get
            Return objAuditoria.sqlConsulta
        End Get
    End Property
#End Region

    Private Function seBemFormado(ByVal dtAuditoria As Date, _
                                  ByVal dtCheckList As Date) As Boolean

        Dim bBemFormado As Boolean = True
        Try

            If (dtAuditoria < dtCheckList) Then
                MyBase.adicionarMensagensValidacao(eMensagens.DATA_INVALIDA, _
                                                Me.sMensagens(eMensagens.DATA_INVALIDA))
                bBemFormado = False
            End If

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao validar os dados da auditoria. " & Environment.NewLine & ex.Message)
        End Try

        Return bBemFormado

    End Function

    Public Function Retornar_Dados_Auditoria(ByVal iIDAuditoria As Integer) As DataTable

        Try

            Return Me.objAuditoria.Retornar_Dados_Auditoria(iIDAuditoria)

        Catch ex As Exception

            Throw New Exception("Ocorreu um erro ao selecionar os dados da auditoria selecionada. " & Environment.NewLine & ex.Message)

        End Try

    End Function

    Public Function Retornar_Itens_Auditoria(ByVal iIDCheckList As Integer, ByVal iIDAuditoria As Integer) As DataTable
        Try

            Return Me.objAuditoria.Retorna_Itens_Auditoria(iIDCheckList, iIDAuditoria)

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao selecionar os itens relacionados a auditoria. " & Environment.NewLine & ex.Message)
        End Try

    End Function

    Public Function Excluir_Auditoria(ByVal iIDAuditoria As Integer) As Boolean
        Dim bResultado As Boolean = True

        Try

            objAuditoria.Excluir_Item_Auditoria(iIDAuditoria)
            objAuditoria.Excluir_Auditoria(iIDAuditoria)

        Catch ex As Exception
            bResultado = False
            Throw New Exception("Ocorreu um erro ao excluir a auditoria selecionada. " & Environment.NewLine & ex.Message)
        End Try

        Return bResultado

    End Function

    Public Function Salvar_Auditoria(ByVal iIDAuditoria As Integer, ByVal iIDCheckList As Integer, _
                                     ByVal dtDataAuditoria As Date, ByVal iStatus As Integer, _
                                     ByVal dsAuditoria As DataSet, ByVal dtCheckList As Date) As Integer

        Dim drItens As DataRow
        Dim iIDItem As Integer
        Dim sJustificativa As String
        Dim iSituacao As Integer

        Try

            Me.bResultado = True

            If seBemFormado(dtDataAuditoria, dtCheckList) Then

                If (iIDAuditoria = 0) Then

                    Me.iPrvIDAuditoria = objAuditoria.Inserir_Auditoria(Persistencia.Globais.iIDEmpresa, _
                                                                        iIDCheckList, dtDataAuditoria, iStatus)
                Else
                    Me.iPrvIDAuditoria = iIDAuditoria
                    objAuditoria.Alterar_Status_Auditoria(iIDAuditoria, iStatus)
                End If

                If (iPrvIDAuditoria > 0) Then

                    objAuditoria.Excluir_Item_Auditoria(iIDAuditoria)

                    If (dsAuditoria.Tables(0).Rows.Count > 0) Then

                        For Each drItens In dsAuditoria.Tables(0).Rows

                            iIDItem = drItens.Item("IDItem")
                            sJustificativa = drItens.Item("Argumento")
                            Select Case drItens.Item("Auditoria").ToString.ToUpper.Trim
                                Case ""
                                    iSituacao = perAuditoria.eSituacaoItem.SemResposta
                                Case "OK"
                                    iSituacao = perAuditoria.eSituacaoItem.Ok
                                Case "NÃO OK"
                                    iSituacao = perAuditoria.eSituacaoItem.NaoOk
                            End Select

                            objAuditoria.Inserir_Item_Auditoria(iPrvIDAuditoria, iIDCheckList, _
                                                                iIDItem, iSituacao, sJustificativa)

                        Next

                    End If

                End If

            Else
                Me.bResultado = False
            End If

        Catch ex As Exception
            Me.bResultado = False
            Throw New Exception("Ocorreu um erro ao salvar a auditoria. " & Environment.NewLine & ex.Message)
        End Try

        Return Me.bResultado

    End Function

End Class
