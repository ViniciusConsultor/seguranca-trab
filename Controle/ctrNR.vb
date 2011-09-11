Imports Persistencia
Public Class ctrNR
    Inherits ctrPadrao

#Region " Enumerações "

    Public Enum eMensagens As Byte
        DESCRICAO_OBRIGATORIO = 0
        NR_OBRIGATORIO = 1
    End Enum

    Public Enum eMensagensAssociacao As Byte
        VALIDADE_OBRIGATORIO = 0
    End Enum

#End Region

#Region "Variáveis"

    Private objArquivo As New Persistencia.perArquivo
    Private objArtigo As New Persistencia.perArtigo
    Private objCheckList As New Persistencia.perCheckList
    Private objDocumento As New Persistencia.perDocumento
    Private objNR As New Persistencia.perNR
    Private objQuestao As New Persistencia.perQuestao

    Private sMensagens() As String = {"Descrição obrigatória.", _
                                      "Número da NR obrigatório. "}
    Private sMensagensAssociacao() As String = {"A validade da NR não pode ser zero. Insira um valor em meses."}

    Private iPrvIDNR As Integer
    Private bResultado As Boolean = False

#End Region

#Region "Propriedades"


    Public ReadOnly Property IDNR()
        Get
            Return iPrvIDNR
        End Get
    End Property

    ReadOnly Property sqlConsulta() As String
        Get
            Return Me.objNR.sqlConsulta()
        End Get
    End Property

    ReadOnly Property sqlNRCheckList(ByVal iIDEmpresa As Integer, ByVal dtData As Date) As String
        Get
            Return Me.objCheckList.Retornar_NR_CheckList(iIDEmpresa, dtData)
        End Get
    End Property

    ReadOnly Property MensagemErroAssociacao()
        Get
            Return sMensagensAssociacao(0)
        End Get
    End Property

#End Region

#Region "Métodos"

    Private Function seBemFormado(ByVal iIDNr As Integer, ByVal sDescricao As String) As Boolean

        Dim bBemFormado As Boolean = True

        If (sDescricao = String.Empty) Then
            MyBase.adicionarMensagensValidacao(eMensagens.DESCRICAO_OBRIGATORIO, _
                                            Me.sMensagens(eMensagens.DESCRICAO_OBRIGATORIO))
            bBemFormado = False
        End If

        If (iIDNr = 0) Then
            MyBase.adicionarMensagensValidacao(eMensagens.NR_OBRIGATORIO, _
                                            Me.sMensagens(eMensagens.NR_OBRIGATORIO))
            bBemFormado = False
        End If

        Return bBemFormado

    End Function

    Private Function seBemFormadoAssociacao(ByVal dsAssociacao As DataSet) As Boolean

        Dim bBemFormado As Boolean = True
        Dim bMarcado As Boolean
        Dim iValidade As Integer

        If (dsAssociacao.Tables(0).Rows.Count > 0) Then

            For Each drAssoc In dsAssociacao.Tables(0).Rows
                bMarcado = CBool(drAssoc.Item(2))
                If (bMarcado) Then
                    iValidade = Conversao.nuloParaZero(drAssoc.Item(3))

                    If (iValidade = 0) Then
                        MyBase.adicionarMensagensValidacao(eMensagensAssociacao.VALIDADE_OBRIGATORIO, _
                       Me.sMensagens(eMensagensAssociacao.VALIDADE_OBRIGATORIO))
                        bBemFormado = False
                    End If

                End If

            Next

        End If

        Return bBemFormado

    End Function

    Private Function sePermiteExcluirNR(ByVal iIDNR As Integer) As Boolean

        Return Me.objNR.Validar_ExclusaoNR(iIDNR)

    End Function

    Public Function Salvar(ByVal iIdNR As Integer, _
                           ByVal sDescricao As String, _
                           ByVal dsArtigos As DataSet, _
                           ByVal dsPerguntas As DataSet) As Boolean

        Dim iIDArtigo As Integer = 0
        Dim iIDQuestao As Integer = 0
        Dim drArtigos As DataRow
        Dim sCodArtigo As String = ""
        Dim sTexto As String = ""
        Dim sPenalidade As String = ""
        Dim sLetra As String = ""
        Dim iIdDocumento As Integer = 0
        Dim drQuestoes As DataRow
        Dim sQuestao As String = ""
        Dim sAcao As String = ""

        Try

            Me.bResultado = True

            If seBemFormado(Val(iIdNR), sDescricao.Trim) Then

                'MyBase.limparMensagensValidacao()
                'MyBase.iniciarControleTransacional()

                'Me.objNR.TransacaoOrigem = MyBase.ControleTransacional
                'Me.objArtigo.TransacaoOrigem = MyBase.ControleTransacional
                'Me.objQuestao.TransacaoOrigem = MyBase.ControleTransacional
                'Me.objDocumento.TransacaoOrigem = MyBase.ControleTransacional
                'Me.objArquivo.TransacaoOrigem = MyBase.ControleTransacional

                If (objNR.Validar_CodNR(iIdNR)) Then
                    Me.iPrvIDNR = objNR.Inserir_NR(iIdNR, sDescricao)
                Else
                    Me.objNR.Atualizar_NR(iIdNR, sDescricao)
                    Me.iPrvIDNR = iIdNR
                End If

                If (Me.iPrvIDNR > 0) Then
                    'Artigos NR
                    'Exclui todos as questões e artigos daquela NR 
                    'para inserí-los novamente
                    Me.objQuestao.Excluir_Questao_Por_NR(iPrvIDNR)
                    Me.objArtigo.Excluir_Artigos_NR(iIdNR)

                    If (dsArtigos.Tables(0).Rows.Count > 0) Then

                        For Each drArtigos In dsArtigos.Tables(0).Rows
                            sCodArtigo = drArtigos.Item(1).ToString
                            sLetra = drArtigos.Item(2).ToString
                            sTexto = drArtigos.Item(3).ToString
                            sPenalidade = drArtigos.Item(4).ToString


                            iIDArtigo = objArtigo.Inserir_Artigo(Me.iPrvIDNR, _
                                                                 sCodArtigo, _
                                                                 sLetra, _
                                                                 sTexto, _
                                                                 sPenalidade)

                            If (iIDArtigo > 0) Then

                                For Each drQuestoes In dsPerguntas.Tables(0).Rows

                                    If (sCodArtigo = drQuestoes.Item(1)) Then
                                        sQuestao = drQuestoes.Item(2)
                                        sAcao = drQuestoes.Item(3)

                                        iIDQuestao = objQuestao.Inserir_Questoes(iIDArtigo, sQuestao, sAcao)

                                        If Conversao.ToInt32(drQuestoes.Item("IDArquivo")) > 0 Then

                                            If Not String.IsNullOrEmpty(Conversao.ToString(drQuestoes.Item("Evidência"))) Then

                                                Me.objDocumento.atualizarDocumento(drQuestoes.Item("IDDocumento"), _
                                                                                   Globais.iIDEmpresa, _
                                                                                   drQuestoes.Item("DescricaoDocumento"), _
                                                                                   drQuestoes.Item("Evidência"), _
                                                                                   Globais.eTipoArquivo.NRQuestao, _
                                                                                   iIDQuestao)

                                                Me.objArquivo.atualizarArquivo(drQuestoes.Item("IDDocumento"), _
                                                                               drQuestoes.Item("Arquivo"))

                                            Else
                                                Me.objArquivo.excluirArquivo(drQuestoes.Item("IDDocumento"))
                                                Me.objDocumento.excluirDocumento(drQuestoes.Item("IDDocumento"))
                                            End If

                                        Else
                                            If Not String.IsNullOrEmpty(Conversao.ToString(drQuestoes.Item("Evidência"))) Then
                                                iIdDocumento = Me.objDocumento.inserirDocumento(Globais.iIDEmpresa, _
                                                                                            drQuestoes.Item("DescricaoDocumento"), _
                                                                                            drQuestoes.Item("Evidência"), _
                                                                                            Globais.eTipoArquivo.NRQuestao, _
                                                                                            iIDQuestao)
                                                Me.objArquivo.inserirArquivo(iIdDocumento, _
                                                                             drQuestoes.Item("Arquivo"))

                                            End If

                                        End If

                                    End If
                                Next

                            End If

                        Next

                    End If

                End If

            Else
                Me.bResultado = False
            End If

        Catch ex As Exception
            Me.bResultado = False
            Throw New Exception("Ocorreu um erro ao salvar os dados da NR. " & Environment.NewLine & ex.Message)
        Finally

            'If Me.bResultado Then
            '    MyBase.finalizarControleTransacional(eFinalizacaoTransacao.Commit)
            'Else
            '    MyBase.finalizarControleTransacional(eFinalizacaoTransacao.Rollback)
            'End If

            'Me.objNR.TransacaoOrigem = Nothing
            'Me.objArtigo.TransacaoOrigem = Nothing
            'Me.objQuestao.TransacaoOrigem = Nothing
            'Me.objArquivo.TransacaoOrigem = Nothing
            'Me.objDocumento.TransacaoOrigem = Nothing
        End Try

        Return Me.bResultado

    End Function

    Public Function Excluir_NR(ByVal iIDNR As Integer) As Boolean

        Dim bResultado As Boolean = True

        Try
            If (sePermiteExcluirNR(iIDNR)) Then
                Me.objNR.Excluir_NR(iIDNR)
                Me.objQuestao.Excluir_Questao_Por_NR(iIDNR)
                Me.objArtigo.Excluir_Artigos_NR(iIDNR)
            Else
                bResultado = False
            End If

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao excluir os dados da NR. " & Environment.NewLine & ex.Message)
        End Try

        Return bResultado

    End Function

    Public Function selecionarCampo(ByVal iIDNR As Integer, _
                                ByVal sCampo As String) As Object
        Try
            Return Me.objNR.selecionarCampo(iIDNR, sCampo)

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao selecionar os dados da NR. " & Environment.NewLine & ex.Message)
        End Try

    End Function

    Public Function Selecionar_Artigos_NR(ByVal iIDNR As Integer) As DataTable
        Try

            Return Me.objArtigo.Selecionar_Artigos_NR(iIDNR)

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao selecionar os artigos da NR. " & Environment.NewLine & ex.Message)
        End Try

    End Function

    Public Function Selecionar_Questoes_NR(ByVal iIDNR As Integer) As DataTable

        Try

            Return Me.objQuestao.Selecionar_Questoes_NR(iIDNR)

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao selecionar as questões relacionadas a NR. " & Environment.NewLine & ex.Message)
        End Try

    End Function

    Public Function Retornar_NR_Empresa(ByVal iIDEmpresa As Integer) As DataTable

        Try
            Return Me.objNR.Retornar_NR_Empresa(iIDEmpresa)

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao selecionar os dados da NR. " & Environment.NewLine & ex.Message)
        End Try

    End Function

    Public Function Salvar_NR_Empresa(ByVal iIDEmpresa As Integer, _
                                      ByVal dsAssociacao As DataSet) As Boolean

        Dim drAssoc As DataRow
        Dim bMarcado As Boolean
        Dim iIDNR As Integer
        Dim iValidade As Integer
        Try

            Me.bResultado = False

            If (iIDEmpresa > 0) Then

                If seBemFormadoAssociacao(dsAssociacao) Then
                    'Exclui todos as associações para inserí-las novamente
                    Me.objNR.Excluir_Associacao_NR_Empresa(iIDEmpresa)

                    If (dsAssociacao.Tables(0).Rows.Count > 0) Then

                        For Each drAssoc In dsAssociacao.Tables(0).Rows
                            bMarcado = CBool(drAssoc.Item(2))
                            If (bMarcado) Then
                                iIDNR = drAssoc.Item(0)
                                iValidade = Conversao.nuloParaZero(drAssoc.Item(3))

                                If (iIDNR > 0) Then
                                    objNR.Inserir_Associacao_NR_Empresa(iIDEmpresa, iIDNR, iValidade)
                                End If
                            End If

                        Next

                    End If
                    bResultado = True
                End If

            End If

        Catch ex As Exception
            Me.bResultado = False
            Throw New Exception("Ocorreu um erro ao salvar os dados da NR. " & Environment.NewLine & ex.Message)
        End Try

        Return Me.bResultado

    End Function

    Public Function Retornar_CheckList(ByVal iIDEmpresa As Integer, ByVal iIDCheckList As Integer, _
                                       ByVal iIDNR As Integer) As DataTable

        Try

            Return objNR.Retornar_CheckList(iIDEmpresa, iIDCheckList, iIDNR)

        Catch ex As Exception

            Throw New Exception("Ocorreu um erro ao recuperar os dados do checklist. " & Environment.NewLine & ex.Message)

        End Try

    End Function

    Public Function Retornar_Descricao_NR(ByVal iIDNR As Integer) As String
        Try

            Return objNR.Retornar_Descricao_NR(iIDNR)

        Catch ex As Exception

            Throw New Exception("Ocorreu um erro ao recuperar os dados da NR. " & Environment.NewLine & ex.Message)

        End Try
    End Function

#End Region

End Class
