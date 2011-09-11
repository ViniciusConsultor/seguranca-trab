Imports Persistencia
Public Class ctrEmpresa
    Inherits ctrPadrao

#Region " Enumerações "

    Public Enum eMensagens As Byte
        NOME_FANTASIA_OBRIGATORIO = 0
        RAZAO_SOCIAL_OBRIGATORIO = 1
        SIGLA_OBRIGATORIO = 2
    End Enum

    Public Enum eGridEmpresa As Byte
        eMarcar = 0
        eIdDocumento = 1
        eNome = 2
        eDescricao = 3
        eDocumento = 4
    End Enum

#End Region

#Region "Variáveis"

    Private objEmpresa As New Persistencia.perEmpresa
    Private objUsuarioEmpresa As New Persistencia.perUsuarioEmpresa
    Private objUsuario As New Controle.ctrUsuario
    Private objArquivo As New Persistencia.perArquivo
    Private objDocumento As New Persistencia.perDocumento

    Private sMensagens() As String = {"Nome fantasia obrigatório. ", _
                                      "Razão social obrigatório. ", _
                                      "Sigla obrigatório."}

    Private iIdEmpresa As Integer

#End Region

#Region "Propriedades"

    Public Property IDEmpresa() As Integer
        Get
            Return Me.iIdEmpresa
        End Get
        Set(ByVal value As Integer)
            Me.iIdEmpresa = value
        End Set
    End Property

    Private bResultado As Boolean = False

    ReadOnly Property sqlConsulta(ByVal iIdEmpresa As Integer, _
                                  ByVal iIdUsuario As Integer) As String
        Get
            Return Me.objEmpresa.sqlConsulta(iIdEmpresa, _
                                             iIdUsuario)
        End Get
    End Property

#End Region

#Region "Métodos públicos"

    Private Function seBemFormado(ByVal sNomeFantasia As String, _
                                  ByVal sRazaoSocial As String, _
                                  ByVal sSigla As String) As Boolean

        Dim bBemFormado As Boolean = True

        If sNomeFantasia = String.Empty Then

            MyBase.adicionarMensagensValidacao(eMensagens.NOME_FANTASIA_OBRIGATORIO, _
                                               Me.sMensagens(eMensagens.NOME_FANTASIA_OBRIGATORIO))

            bBemFormado = False
        End If

        If sRazaoSocial = String.Empty Then

            MyBase.adicionarMensagensValidacao(eMensagens.RAZAO_SOCIAL_OBRIGATORIO, _
                                               Me.sMensagens(eMensagens.RAZAO_SOCIAL_OBRIGATORIO))

            bBemFormado = False
        End If

        If sSigla = String.Empty Then

            MyBase.adicionarMensagensValidacao(eMensagens.SIGLA_OBRIGATORIO, _
                                               Me.sMensagens(eMensagens.SIGLA_OBRIGATORIO))

            bBemFormado = False
        End If

        Return bBemFormado

    End Function

    Private Function sePermiteExcluirEmpresa(ByVal iIdEmpresa) As Boolean

        Dim bPermiteExclusao As Boolean = True

        If Me.objUsuarioEmpresa.seEmpresaVinculada(iIdEmpresa) Then

            bPermiteExclusao = False
        End If

        Return bPermiteExclusao

    End Function

    Public Function salvar(ByVal iIDEmpresa As Integer, _
                           ByVal sNomeFantasia As String, _
                           ByVal sRazaoSocial As String, _
                           ByVal sSigla As String, _
                           ByVal sLogradouro As String, _
                           ByVal iNumero As Integer, _
                           ByVal sBairro As String, _
                           ByVal sCidade As String, _
                           ByVal iEstado As Integer, _
                           ByVal sCEP As String, _
                           ByVal sCNPJ As String, _
                           ByVal sEmail As String, _
                           ByVal sTelefone As String, _
                           ByVal sFax As String, _
                           ByVal byLogo() As Byte, _
                           ByVal dsDocumentos As DataSet, _
                           ByVal iDuracaoCheckList As Integer, _
                           ByVal iAlertaTreinamento As Integer, _
                           ByVal iAlertaEPI As Integer, _
                           ByVal iAlertaDocumento As Integer, _
                           ByVal iAlertaAuditoria As Integer) As Boolean
        Try

            Dim dsUsuarios As New DataSet
            Dim iIdDocumento As Integer
            Dim dsDocumentosAux As New DataSet

            MyBase.limparMensagensValidacao()
            MyBase.iniciarControleTransacional()

            Me.objEmpresa.TransacaoOrigem = MyBase.ControleTransacional
            Me.objUsuarioEmpresa.TransacaoOrigem = MyBase.ControleTransacional
            Me.objArquivo.TransacaoOrigem = MyBase.ControleTransacional
            Me.objDocumento.TransacaoOrigem = MyBase.ControleTransacional

            If seBemFormado(sNomeFantasia, _
                            sRazaoSocial, _
                            sSigla) Then

                sCNPJ = sCNPJ.Replace(".", "")
                sCNPJ = sCNPJ.Replace("-", "")
                sCNPJ = sCNPJ.Replace(",", "")
                sCNPJ = sCNPJ.Replace("/", "")

                sCEP = sCEP.Replace(".", "")
                sCEP = sCEP.Replace("-", "")
                sCEP = sCEP.Replace(",", "")


                sTelefone = sTelefone.Replace(".", "")
                sTelefone = sTelefone.Replace("-", "")
                sTelefone = sTelefone.Replace(",", "")


                sFax = sFax.Replace(".", "")
                sFax = sFax.Replace("-", "")
                sFax = sFax.Replace(",", "")

                If iIDEmpresa > 0 Then
                    Me.objEmpresa.atualizarEmpresa(iIDEmpresa, _
                                                    sNomeFantasia, _
                                                    sRazaoSocial, _
                                                    sSigla, _
                                                    sLogradouro, _
                                                    iNumero, _
                                                    sBairro, _
                                                    sCidade, _
                                                    iEstado, _
                                                    sCep, _
                                                    sCNPJ, _
                                                    sEmail, _
                                                    sTelefone, _
                                                    sFax, _
                                                    byLogo, _
                                                    iDuracaoCheckList, _
                                                    iAlertaTreinamento, _
                                                    iAlertaEPI, _
                                                    iAlertaDocumento, _
                                                    iAlertaAuditoria)
                    Me.IDEmpresa = iIDEmpresa

                    dsDocumentosAux = Me.objDocumento.selecionarDocumento(Me.IDEmpresa, Globais.eTipoArquivo.Empresa)

                    For Each drDadosDocs As DataRow In dsDocumentosAux.Tables(0).Rows
                        If dsDocumentos.Tables(0).Select("IDDocumento = " & drDadosDocs.Item("IDDocumento")).Length = 0 Then
                            Me.objArquivo.excluirArquivo(drDadosDocs.Item("IDDocumento"))
                            Me.objDocumento.excluirDocumento(drDadosDocs.Item("IDDocumento"))
                        End If
                    Next

                    If dsDocumentos.Tables(0).Rows.Count > 0 Then

                        For Each drDados As DataRow In dsDocumentos.Tables(0).Rows

                            If drDados.Item("IDDocumento") > 0 Then

                                Me.objDocumento.atualizarDocumento(drDados.Item("IDDocumento"), _
                                                                   Me.IDEmpresa, _
                                                                   Conversao.ToString(drDados.Item("Descricao")), _
                                                                   Conversao.ToString(drDados.Item("NomeArquivo")), _
                                                                   Persistencia.Globais.eTipoArquivo.Empresa, _
                                                                   Me.IDEmpresa)

                                Me.objArquivo.atualizarArquivo(drDados.Item("IDDocumento"), _
                                                               drDados.Item("Arquivo"))

                            Else

                                iIdDocumento = Me.objDocumento.inserirDocumento(Me.IDEmpresa, _
                                                                                Conversao.ToString(drDados.Item("Descricao")), _
                                                                                Conversao.ToString(drDados.Item("NomeArquivo")), _
                                                                                Persistencia.Globais.eTipoArquivo.Empresa, _
                                                                                Me.IDEmpresa)

                                Me.objArquivo.inserirArquivo(iIdDocumento, _
                                                             drDados.Item("Arquivo"))

                            End If
                        Next

                    End If

                    Me.bResultado = True
                Else

                    Me.IDEmpresa = Me.objEmpresa.inserirEmpresa(sNomeFantasia, _
                                                                sRazaoSocial, _
                                                                sSigla, _
                                                                sLogradouro, _
                                                                iNumero, _
                                                                sBairro, _
                                                                sCidade, _
                                                                iEstado, _
                                                                sCep, _
                                                                sCNPJ, _
                                                                sEmail, _
                                                                sTelefone, _
                                                                sFax, _
                                                                byLogo, _
                                                                iDuracaoCheckList, _
                                                                iAlertaTreinamento, _
                                                                iAlertaEPI, _
                                                                iAlertaDocumento, _
                                                                iAlertaAuditoria)

                    dsUsuarios = Me.objUsuario.Selecionar

                    If dsUsuarios.Tables(0).Rows.Count > 0 Then
                        For Each drDados As DataRow In dsUsuarios.Tables(0).Rows
                            Me.objUsuarioEmpresa.insereAcessoEmpresa(Me.IDEmpresa, _
                                                                     drDados.Item("IDUsuario"))
                        Next
                    End If

                    If dsDocumentos.Tables(0).Rows.Count > 0 Then

                        For Each drDados As DataRow In dsDocumentos.Tables(0).Rows

                            iIdDocumento = Me.objDocumento.inserirDocumento(Me.IDEmpresa, _
                                                                            Conversao.ToString(drDados.Item("Descricao")), _
                                                                            Conversao.ToString(drDados.Item("NomeArquivo")), _
                                                                            Persistencia.Globais.eTipoArquivo.Empresa, _
                                                                            Me.IDEmpresa)

                            Me.objArquivo.inserirArquivo(iIdDocumento, _
                                                         drDados.Item("Arquivo"))


                        Next

                    End If

                    Me.bResultado = True
                End If

            Else
                Me.bResultado = False
            End If

        Catch ex As Exception
            Me.bResultado = False
            Throw New Exception("Ocorreu um erro ao salvar os dados da empresa. " & Environment.NewLine & ex.Message)
        Finally

            If Me.bResultado Then
                MyBase.finalizarControleTransacional(eFinalizacaoTransacao.Commit)
            Else
                MyBase.finalizarControleTransacional(eFinalizacaoTransacao.Rollback)
            End If

            Me.objEmpresa.TransacaoOrigem = Nothing
            Me.objUsuarioEmpresa.TransacaoOrigem = Nothing
            Me.objArquivo.TransacaoOrigem = Nothing
            Me.objDocumento.TransacaoOrigem = Nothing

        End Try

        Return Me.bResultado

    End Function

    Public Function excluir(ByVal iIdEmpresa As Integer) As Boolean

        Dim bResultado As Boolean = True

        Try

            If Me.sePermiteExcluirEmpresa(iIdEmpresa) Then
                Me.objEmpresa.excluirEmpresa(iIdEmpresa)
                bResultado = True
            Else
                bResultado = False
            End If

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao excluir os dados da empresa " & Environment.NewLine & ex.Message)
        End Try

        Return bResultado

    End Function

    Public Function selecionarDadosEmpresa(ByVal iIdEmpresa As Integer) As System.Data.DataSet
        Return Me.objEmpresa.selecionarDadosEmpresa(iIdEmpresa)
    End Function

    Public Function selecionar(ByVal iIdEmpresa As Integer) As DataSet

        Try

            Return Me.objEmpresa.selecionarEmpresa(iIdEmpresa)

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao selecionar os dados da empresa " & Environment.NewLine & ex.Message)
        End Try

    End Function

    Public Function retornarTotalEmpresasCadastradas(ByVal iIDUsuario As Integer) As Integer
        Return Me.objEmpresa.retornarTotalEmpresasCadastradas(iIDUsuario)
    End Function

    Public Function selecionarCampo(ByVal iIdEmpresa As Integer, _
                                    ByVal sCampo As String) As Object
        Return Me.objEmpresa.selecionarCampo(iIdEmpresa, _
                                             sCampo)
    End Function

    Public Function Retornar_Campo_Empresa(ByVal iIDEmpresa As Integer, ByVal sCampo As String)
        Try

            Return Me.objEmpresa.selecionarCampo(iIdEmpresa, sCampo)

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao selecionar os dados da empresa " & Environment.NewLine & ex.Message)
        End Try
    End Function

#End Region

End Class
