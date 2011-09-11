Imports Persistencia
Public Class ctrGrupoAcesso
    Inherits ctrPadrao

#Region "Enumerações"

    Public Enum eColGrupoAcesso
        eExpandir = 0
        eMenu = 1
        eNome = 2
        eTotal = 3
        eInserir = 4
        eExcluir = 5
        eAlterar = 6
        eConsultar = 7
        eNodoPai = 8
        eNodoFilho = 9
    End Enum

    Public Enum eMensagens As Byte
        DESCRICAO_OBRIGATORIO = 0
    End Enum

#End Region

#Region " Variáveis "
    Private objGrupoAcesso As New Persistencia.perGrupoAcesso
    Private objGrupoAcessoItem As New Persistencia.perGrupoAcessoItem
    Private objUsuario As New Persistencia.perUsuario
    Private sMensagens() As String = {"Descrição obrigatória."}
    Private iIdGrupoAcesso As Integer
#End Region

#Region " Propriedades "
    Public ReadOnly Property sqlConsulta() As String
        Get
            Return Me.objGrupoAcesso.sqlConsulta
        End Get
    End Property

    Public Property IDGrupoAcesso() As Integer
        Get
            Return Me.iIdGrupoAcesso
        End Get
        Set(ByVal value As Integer)
            Me.iIdGrupoAcesso = value
        End Set
    End Property

    Private bResultado As Boolean = False
#End Region

#Region " Métodos "

    Private Function seBemFormado(ByVal sDescricao As String) As Boolean

        Dim bBemFormado As Boolean = True

        If sDescricao = String.Empty Then

            MyBase.adicionarMensagensValidacao(eMensagens.DESCRICAO_OBRIGATORIO, _
                                               Me.sMensagens(eMensagens.DESCRICAO_OBRIGATORIO))

            bBemFormado = False

        End If

        Return bBemFormado

    End Function

    Private Function sePermiteExcluirGrupoAcesso(ByVal iIdGrupoAcesso As Integer) As Boolean

        Dim bPermiteExclusao As Boolean = True

        Try
            If Me.objUsuario.seGrupoAcessoVinculadoUsuario(iIdGrupoAcesso) Then
                bPermiteExclusao = False
            Else
                bPermiteExclusao = True
            End If

            Return bPermiteExclusao

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao excluir o grupo de acesso. " & Environment.NewLine & ex.Message)
        End Try

    End Function

    Public Function salvar(ByVal iIdGrupoAcesso As Integer, _
                           ByVal sDescricao As String, _
                           ByVal dsGrupoAcesso As DataSet) As Boolean
        Try

            Dim dsUsuarios As New DataSet

            MyBase.limparMensagensValidacao()
            MyBase.iniciarControleTransacional()

            Me.objGrupoAcesso.TransacaoOrigem = MyBase.ControleTransacional
            Me.objGrupoAcessoItem.TransacaoOrigem = MyBase.ControleTransacional

            If seBemFormado(sDescricao) Then

                If iIdGrupoAcesso > 0 Then

                    Me.IDGrupoAcesso = iIdGrupoAcesso

                    Me.objGrupoAcesso.atualizarGrupoAcesso(iIdGrupoAcesso, _
                                                           sDescricao)

                    Me.objGrupoAcessoItem.excluirGrupoAcessoItem(iIdGrupoAcesso)

                    For Each drDados As DataRow In dsGrupoAcesso.Tables(0).Rows

                        Me.objGrupoAcessoItem.inserirGrupoAcessoItem(iIdGrupoAcesso, _
                                                                     Conversao.ToString(drDados.Item(eColGrupoAcesso.eNome)), _
                                                                     Conversao.ToString(drDados.Item(eColGrupoAcesso.eMenu)), _
                                                                     Conversao.ToBoolean(drDados.Item(eColGrupoAcesso.eInserir)), _
                                                                     Conversao.ToBoolean(drDados.Item(eColGrupoAcesso.eExcluir)), _
                                                                     Conversao.ToBoolean(drDados.Item(eColGrupoAcesso.eAlterar)), _
                                                                     Conversao.ToBoolean(drDados.Item(eColGrupoAcesso.eConsultar)))

                    Next

                    Me.bResultado = True
                Else

                    Me.IDGrupoAcesso = Me.objGrupoAcesso.inserirGrupoAcesso(sDescricao)

                    For Each drDados As DataRow In dsGrupoAcesso.Tables(0).Rows

                        Me.objGrupoAcessoItem.inserirGrupoAcessoItem(Me.IDGrupoAcesso, _
                                                                     Conversao.ToString(drDados.Item(eColGrupoAcesso.eNome)), _
                                                                     Conversao.ToString(drDados.Item(eColGrupoAcesso.eMenu)), _
                                                                     Conversao.ToBoolean(drDados.Item(eColGrupoAcesso.eInserir)), _
                                                                     Conversao.ToBoolean(drDados.Item(eColGrupoAcesso.eExcluir)), _
                                                                     Conversao.ToBoolean(drDados.Item(eColGrupoAcesso.eAlterar)), _
                                                                     Conversao.ToBoolean(drDados.Item(eColGrupoAcesso.eConsultar)))

                    Next

                    Me.bResultado = True
                End If

            Else
                Me.bResultado = False
            End If

        Catch ex As Exception
            Me.bResultado = False
            Throw New Exception("Ocorreu um erro ao salvar os dados do grupo de acesso. " & Environment.NewLine & ex.Message)
        Finally

            If Me.bResultado Then
                MyBase.finalizarControleTransacional(eFinalizacaoTransacao.Commit)
            Else
                MyBase.finalizarControleTransacional(eFinalizacaoTransacao.Rollback)
            End If

            Me.objGrupoAcesso.TransacaoOrigem = Nothing
            Me.objGrupoAcessoItem.TransacaoOrigem = Nothing

        End Try

        Return Me.bResultado

    End Function

    Public Function excluir(ByVal iIdGrupoAcesso As Integer) As Boolean

        Dim bResultado As Boolean = True

        Try

            If Me.sePermiteExcluirGrupoAcesso(iIdGrupoAcesso) Then
                Me.objGrupoAcessoItem.excluirGrupoAcessoItem(iIdGrupoAcesso)
                Me.objGrupoAcesso.excluirGrupoAcesso(iIdGrupoAcesso)
                bResultado = True
            Else
                bResultado = False
            End If

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao excluir os dados do grupo de acesso " & Environment.NewLine & ex.Message)
        End Try

        Return bResultado

    End Function

    Public Function selecionar(ByVal iIdGrupoAcesso As Integer) As DataSet

        Try

            Return Me.objGrupoAcesso.selecionarGrupoAcesso(iIdGrupoAcesso)

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao selecionar os dados do grupo de acesso " & Environment.NewLine & ex.Message)
        End Try

    End Function

    Public Function selecionarCampo(ByVal iIdGrupoAcesso As Integer, _
                                    ByVal sCampo As String) As Object
        Try
            Return Me.objGrupoAcesso.selecionarCampo(iIdGrupoAcesso, sCampo)
        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao selecionar os dados do grupo de acesso " & Environment.NewLine & ex.Message)
        End Try

    End Function
    Public Function retornarPermissoesUsuario(ByVal iIdGrupoAcesso As Integer, _
                                              ByVal sMenu As String) As DataRow
        Try
            Return Me.objGrupoAcesso.retornarPermissoesUsuario(iIdGrupoAcesso, _
                                                               sMenu)
        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao selecionar os dados do grupo de acesso " & Environment.NewLine & ex.Message)
        End Try

    End Function

#End Region

End Class
