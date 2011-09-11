Public Class ctrUsuario
    Inherits ctrPadrao

#Region " Enumerações "

    Public Enum eMensagens As Byte
        NOME_OBRIGATORIO = 0
        LOGIN_OBRIGATORIO = 1
        SENHA_OBRIGATORIA = 2
        LOGIN_EXISTENTE = 3
        GRUPO_ACESSO_OBRIGATORIO = 4
    End Enum

    Public Enum eColEmpresas
        eAcesso = 0
        eIdEmpresa = 1
        eEmpresa = 2
    End Enum

#End Region

#Region "Variáveis"

    Private objUsuario As New Persistencia.perUsuario
    Private objSeguranca As New Controle.ctrSeguranca
    Private objUsuarioEmpresa As New Persistencia.perUsuarioEmpresa

    Private sMensagens() As String = {"Nome obrigatório. ", _
                                      "Login obrigatório. ", _
                                      "Senha obrigatória.", _
                                      "Login existente.", _
                                      "Grupo de acesso obrigatório."}

    Private iIdUsuario As Integer

#End Region

#Region "Propriedades"

    Public Property IDUsuario() As Integer
        Get
            Return Me.iIdUsuario
        End Get
        Set(ByVal value As Integer)
            Me.iIdUsuario = value
        End Set
    End Property

    Private bResultado As Boolean = False

    ReadOnly Property sqlConsulta(ByVal iIdUsuario As Integer) As String
        Get
            Return Me.objUsuario.sqlConsulta(iIdUsuario)
        End Get
    End Property

#End Region

#Region "Métodos públicos"

    Private Function seBemFormado(ByVal sNome As String, _
                                  ByVal sLogin As String, _
                                  ByVal sSenha As String, _
                                  ByVal iIdUsuario As Integer, _
                                  ByVal iIdGrupoAcesso As Integer) As Boolean

        Dim bBemFormado As Boolean = True
        Dim sLoginCriptografado As String
        Dim sLoginRetorno As String

        Try
            If sNome = String.Empty Then

                MyBase.adicionarMensagensValidacao(eMensagens.NOME_OBRIGATORIO, _
                                                   Me.sMensagens(eMensagens.NOME_OBRIGATORIO))

                bBemFormado = False
            End If

            If sLogin = String.Empty Then

                MyBase.adicionarMensagensValidacao(eMensagens.LOGIN_OBRIGATORIO, _
                                                   Me.sMensagens(eMensagens.LOGIN_OBRIGATORIO))

                bBemFormado = False
            End If

            If sLogin <> String.Empty Then
                sLoginCriptografado = Me.objSeguranca.criptografar(sLogin)
                sLoginRetorno = Persistencia.Conversao.ToString(Me.objUsuario.selecionarLogin(sLoginCriptografado, iIdUsuario))

                If sLoginRetorno <> String.Empty Then

                    If sLogin = Me.objSeguranca.descriptografar(sLoginRetorno) Then

                        MyBase.adicionarMensagensValidacao(eMensagens.LOGIN_EXISTENTE, _
                                                           Me.sMensagens(eMensagens.LOGIN_EXISTENTE))

                        bBemFormado = False

                    End If
                End If
            End If

            If sSenha = String.Empty Then

                MyBase.adicionarMensagensValidacao(eMensagens.SENHA_OBRIGATORIA, _
                                                   Me.sMensagens(eMensagens.SENHA_OBRIGATORIA))

                bBemFormado = False
            End If

            If iIdGrupoAcesso = 0 Then

                MyBase.adicionarMensagensValidacao(eMensagens.GRUPO_ACESSO_OBRIGATORIO, _
                                                   Me.sMensagens(eMensagens.GRUPO_ACESSO_OBRIGATORIO))

                bBemFormado = False
            End If


        Catch ex As Exception
            bBemFormado = False
            Throw New Exception("Ocorreu um erro ao validar os dados do usuário " & Environment.NewLine & ex.Message)
        End Try

        Return bBemFormado

    End Function

    Public Function salvar(ByVal iIdGrupoAcesso As Integer, _
                           ByVal iIdUsuario As Integer, _
                           ByVal sNome As String, _
                           ByVal sLogin As String, _
                           ByVal sSenha As String, _
                           ByVal dsUsuarioEmpresa As DataSet) As Boolean

        Dim sLoginCriptografado As String
        Dim sSenhaCriptografada As String
        Dim sNomeCriptografado As String

        Try

            MyBase.limparMensagensValidacao()
            MyBase.iniciarControleTransacional()

            Me.objUsuario.TransacaoOrigem = MyBase.ControleTransacional
            Me.objUsuarioEmpresa.TransacaoOrigem = MyBase.ControleTransacional

            If seBemFormado(sNome, _
                            sLogin.ToLower, _
                            sSenha, _
                            iIdUsuario, _
                            iIdGrupoAcesso) Then

                sLoginCriptografado = Me.objSeguranca.criptografar(sLogin.ToLower.Trim)
                sSenhaCriptografada = Me.objSeguranca.criptografar(sSenha.Trim)
                sNomeCriptografado = Me.objSeguranca.criptografar(sNome.Trim)

                If iIdUsuario > 0 Then

                    Me.objUsuario.atualizarUsuario(iIdUsuario, _
                                                   sNomeCriptografado, _
                                                   sLoginCriptografado, _
                                                   sSenhaCriptografada, _
                                                   iIdGrupoAcesso)

                    Me.IDUsuario = iIdUsuario

                    If dsUsuarioEmpresa.Tables(0).Rows.Count > 0 Then

                        Me.objUsuarioEmpresa.excluirUsuarioEmpresa(Me.IDUsuario)

                        For Each drDados As DataRow In dsUsuarioEmpresa.Tables(0).Rows

                            Me.objUsuarioEmpresa.inserirUsuarioEmpresa(Persistencia.Conversao.ToInt32(drDados.Item(eColEmpresas.eIdEmpresa)), _
                                                                       Me.IDUsuario, _
                                                                       Persistencia.Conversao.ToBoolean(drDados.Item(eColEmpresas.eAcesso)))
                        Next

                    End If

                    Me.bResultado = True

                Else

                    Me.IDUsuario = Me.objUsuario.inserirUsuario(sNomeCriptografado, _
                                                                sLoginCriptografado, _
                                                                sSenhaCriptografada, _
                                                                iIdGrupoAcesso)

                    If dsUsuarioEmpresa.Tables(0).Rows.Count > 0 Then

                        For Each drDados As DataRow In dsUsuarioEmpresa.Tables(0).Rows

                            Me.objUsuarioEmpresa.inserirUsuarioEmpresa(Persistencia.Conversao.ToInt32(drDados.Item(eColEmpresas.eIdEmpresa)), _
                                                                       Me.IDUsuario, _
                                                                       Persistencia.Conversao.ToBoolean(drDados.Item(eColEmpresas.eAcesso)))
                        Next

                    End If

                    Me.bResultado = True
                End If

            Else
                Me.bResultado = False

            End If

        Catch ex As Exception
            Me.bResultado = False
            Throw New Exception("Ocorreu um erro ao salvar os dados do usuário " & Environment.NewLine & ex.Message)
        Finally

            If Me.bResultado Then
                MyBase.finalizarControleTransacional(eFinalizacaoTransacao.Commit)
            Else
                MyBase.finalizarControleTransacional(eFinalizacaoTransacao.Rollback)
            End If

            Me.objUsuario.TransacaoOrigem = Nothing
            Me.objUsuarioEmpresa.TransacaoOrigem = Nothing

        End Try

        Return Me.bResultado

    End Function

    Public Function excluir(ByVal iIdUsuario As Integer) As Boolean

        Try

            MyBase.iniciarControleTransacional()

            Me.objUsuario.TransacaoOrigem = MyBase.ControleTransacional
            Me.objUsuarioEmpresa.TransacaoOrigem = MyBase.ControleTransacional

            Me.objUsuarioEmpresa.excluirUsuarioEmpresa(iIdUsuario)
            Me.objUsuario.excluirUsuario(iIdUsuario)

            Me.bResultado = True

        Catch ex As Exception
            Me.bResultado = False
            Throw New Exception("Ocorreu um erro ao excluir os dados do Usuário " & Environment.NewLine & ex.Message)
        Finally

            If Me.bResultado Then
                MyBase.finalizarControleTransacional(eFinalizacaoTransacao.Commit)
            Else
                MyBase.finalizarControleTransacional(eFinalizacaoTransacao.Rollback)
            End If

            Me.objUsuario.TransacaoOrigem = Nothing
            Me.objUsuarioEmpresa.TransacaoOrigem = Nothing

        End Try

        Return Me.bResultado

    End Function

    Public Function selecionar(ByVal iIdUsuario As Integer) As DataSet

        Try

            Return Me.objUsuario.selecionarUsuario(iIdUsuario)

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao selecionar os dados do usuário " & Environment.NewLine & ex.Message)
        End Try

    End Function

    Public Function Selecionar() As System.Data.DataSet

        Try

            Return Me.objUsuario.selecionarUsuario

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao selecionar os dados do usuário " & Environment.NewLine & ex.Message)
        End Try

    End Function

    Public Function verificaUsuarioExiste(ByVal sLogin As String, _
                                          ByVal sSenha As String) As Integer


        Try

            Return Me.objUsuario.verificaUsuarioExiste(Me.objSeguranca.criptografar(sLogin), _
                                                     Me.objSeguranca.criptografar(sSenha))

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao verificar os dados do usuário " & Environment.NewLine & ex.Message)
        End Try

    End Function

    Public Function selecionarCampo(ByVal sCampo As String, _
                                    ByVal iIdUsuario As Integer) As Object
        Try
            Return Me.objUsuario.selecionarCampo(sCampo, _
                                                 iIdUsuario)
        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao selecionar os dados do usuário " & Environment.NewLine & ex.Message)
        End Try

    End Function

#End Region

End Class
