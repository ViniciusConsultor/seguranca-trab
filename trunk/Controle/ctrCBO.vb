Public Class ctrCBO
    Inherits ctrPadrao

#Region "Variáveis"
    Private iPrvIDCbo As Integer
    Private prvbResultado As Boolean

    Private sMensagens() As String = {"Código obrigatório.", "Descrição obrigatório."}

    Private objCBO As New Persistencia.perCBO

#End Region

#Region " Enumerações "

    Public Enum eMensagens As Byte
        CODIGO_OBRIGATORIO = 0
        DESCRICAO_OBRIGATORIO = 1
    End Enum

#End Region

#Region "Propriedades"

    ReadOnly Property sqlConsulta() As String
        Get
            Return Me.objCBO.sqlConsulta()
        End Get
    End Property

    ReadOnly Property IDCBO()
        Get
            Return Me.iPrvIDCbo
        End Get
    End Property

#End Region

#Region "Métodos públicos"

    Private Function seBemInformado(ByVal sCodigo As String, _
                                    ByVal sDescricao As String) As Boolean

        Dim bBemFormado As Boolean = True

        Try

            If (sDescricao = String.Empty) Then
                MyBase.adicionarMensagensValidacao(eMensagens.DESCRICAO_OBRIGATORIO, _
                                       Me.sMensagens(eMensagens.DESCRICAO_OBRIGATORIO))

                bBemFormado = False
            End If

            If (sCodigo = String.Empty) Then
                MyBase.adicionarMensagensValidacao(eMensagens.CODIGO_OBRIGATORIO, _
                                       Me.sMensagens(eMensagens.CODIGO_OBRIGATORIO))

                bBemFormado = False
            End If

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao validar os dados de CBO. " & Environment.NewLine & ex.Message)
        End Try

        Return bBemFormado

    End Function

    Public Function Salvar_CBO(ByVal iIDCBO As Integer, _
                               ByVal sDescricao As String, _
                               ByVal sCodigo As String) As Boolean

        MyBase.limparMensagensValidacao()

        MyBase.iniciarControleTransacional()
        Me.objCBO.TransacaoOrigem = MyBase.ControleTransacional
        prvbResultado = True

        Try
            If (seBemInformado(sCodigo, sDescricao)) Then

                If (iIDCBO > 0) Then
                    Me.objCBO.Atualizar_CBO(iIDCBO, sDescricao, sCodigo)
                    Me.iPrvIDCbo = iIDCBO
                Else
                    Me.iPrvIDCbo = objCBO.Inserir_CBO(sCodigo, sDescricao)
                End If

            Else
                prvbResultado = False

            End If

        Catch ex As Exception
            prvbResultado = False
            Throw New Exception("Ocorreu um erro ao salvar os dados de CBO. " & Environment.NewLine & ex.Message)

        Finally

            If (Me.prvbResultado) Then
                MyBase.finalizarControleTransacional(eFinalizacaoTransacao.Commit)
            Else
                MyBase.finalizarControleTransacional(eFinalizacaoTransacao.Rollback)
            End If

            objCBO.TransacaoOrigem = Nothing

        End Try

        Return prvbResultado

    End Function

    Public Function Excluir(ByVal iIDCbo As Integer) As Boolean

        prvbResultado = True

        Try
            MyBase.iniciarControleTransacional()
            Me.objCBO.TransacaoOrigem = MyBase.ControleTransacional

            If (Me.objCBO.Validar_Exclusao_CBO(iIDCbo)) Then
                Me.objCBO.Excluir_CBO(iIDCbo)
            Else
                prvbResultado = False
            End If

        Catch ex As Exception
            prvbResultado = False
            Throw New Exception("Ocorreu um erro ao excluir os dados de CBO. " & Environment.NewLine & ex.Message)
        Finally

            If (prvbResultado) Then
                MyBase.finalizarControleTransacional(eFinalizacaoTransacao.Commit)
            Else
                MyBase.finalizarControleTransacional(eFinalizacaoTransacao.Rollback)
            End If

            objCBO.TransacaoOrigem = Nothing

        End Try

        Return prvbResultado

    End Function

    Public Function Selecionar_CBO(ByVal iIDCbo As Integer) As DataTable

        Try

            Return Me.objCBO.Selecionar_CBO(iIDCbo)

        Catch ex As Exception

            Throw New Exception("Ocorreu um erro ao selecionar os dados de CBO." & Environment.NewLine & ex.Message)

        End Try

    End Function

#End Region

End Class
