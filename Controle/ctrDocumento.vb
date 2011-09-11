Public Class ctrDocumento
    Inherits ctrPadrao

#Region " Enumerações "

    Public Enum eMensagens As Byte
        DESCRICAO_OBRIGATORIO = 0
        NOME_ARQUIVO_OBRIGATORIO = 1
    End Enum

#End Region

#Region "Variáveis"

    Private objDocumento As New Persistencia.perDocumento

    Private sMensagens() As String = {"Descrição obrigatório. ", _
                                      "Nome do arquivo obrigatório. "}

    Private iIdDocumento As Integer

#End Region

#Region "Propriedades"

    Public Property IDDocumento() As Integer
        Get
            Return Me.iIdDocumento
        End Get
        Set(ByVal value As Integer)
            Me.iIdDocumento = value
        End Set
    End Property

    Private bResultado As Boolean = False

    ReadOnly Property sqlConsulta(ByVal iIdEmpresa As Integer, _
                                  ByVal iIdDocumento As Integer) As String
        Get
            Return Me.objDocumento.sqlConsulta(iIdEmpresa, _
                                               iIdDocumento)
        End Get
    End Property

#End Region

#Region "Métodos públicos"

    Private Function seBemFormado(ByVal sDescricao As String, _
                                  ByVal sNomeArquivo As String) As Boolean

        Dim bBemFormado As Boolean = True

        If sDescricao = String.Empty Then

            MyBase.adicionarMensagensValidacao(eMensagens.DESCRICAO_OBRIGATORIO, _
                                               Me.sMensagens(eMensagens.DESCRICAO_OBRIGATORIO))

            bBemFormado = False
        End If

        If sNomeArquivo = String.Empty Then

            MyBase.adicionarMensagensValidacao(eMensagens.NOME_ARQUIVO_OBRIGATORIO, _
                                               Me.sMensagens(eMensagens.NOME_ARQUIVO_OBRIGATORIO))

            bBemFormado = False
        End If

        Return bBemFormado

    End Function

    Private Function sePermiteExcluirDocumento(ByVal iIdDocumento) As Boolean

        Dim bPermiteExclusao As Boolean = True

        Return bPermiteExclusao

    End Function

    Public Function salvar(ByVal iIDDocumento As Integer, _
                           ByVal iIdEmpresa As Integer, _
                           ByVal sDescricao As String, _
                           ByVal sNomeArquivo As String, _
                           ByVal eTipo As Persistencia.Globais.eTipoArquivo, _
                           ByVal iIdTipo As Integer) As Boolean
        Try

            Dim dsUsuarios As New DataSet

            If seBemFormado(sDescricao, _
                            sNomeArquivo) Then

                If iIDDocumento > 0 Then

                    Me.objDocumento.atualizarDocumento(iIDDocumento, _
                                                       iIdEmpresa, _
                                                       sDescricao, _
                                                       sNomeArquivo, _
                                                       eTipo, _
                                                       iIdTipo)
                    Me.IDDocumento = iIDDocumento
                    Me.bResultado = True
                Else

                    Me.IDDocumento = Me.objDocumento.inserirDocumento(iIdEmpresa, _
                                                                      sDescricao, _
                                                                      sNomeArquivo, _
                                                                      eTipo, _
                                                                      iIdTipo)

                    Me.bResultado = True
                End If

            Else
                Me.bResultado = False
            End If

        Catch ex As Exception
            Me.bResultado = False
            Throw New Exception("Ocorreu um erro ao salvar os dados do documento. " & Environment.NewLine & ex.Message)
        End Try

        Return Me.bResultado

    End Function

    Public Function excluir(ByVal iIdDocumento As Integer) As Boolean

        Dim bResultado As Boolean = True

        Try

            If Me.sePermiteExcluirDocumento(iIdDocumento) Then
                Me.objDocumento.excluirDocumento(iIdDocumento)
                bResultado = True
            Else
                bResultado = False
            End If

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao excluir os dados do documento " & Environment.NewLine & ex.Message)
        End Try

        Return bResultado

    End Function

    Public Function selecionarDocumento(ByVal iIdTipo As Integer, _
                                        ByVal eTipo As Persistencia.Globais.eTipoArquivo) As DataSet

        Try
            Return Me.objDocumento.selecionarDocumento(iIdTipo, _
                                                       eTipo)
        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao selecionar os dados do documento " & Environment.NewLine & ex.Message)
        End Try

    End Function

    Public Function selecionarCampo(ByVal iIdDocumento As Integer, _
                                    ByVal sCampo As String) As Object

        Return Me.objDocumento.selecionarCampo(iIdDocumento, _
                                               sCampo)
    End Function

#End Region
End Class
