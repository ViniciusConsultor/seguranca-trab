Imports Persistencia
Public Class ctrTreinamento
    Inherits ctrPadrao

#Region " Enumerações "

    Public Enum eMensagens As Byte
        NOME_TREINAMENTO_OBRIGATORIO = 0
        CARGA_HORARIA = 1
        VALIDADE_OBRIGATORIA = 2
    End Enum

#End Region

#Region "Variáveis"

    Private objTreinamento As New Persistencia.perTreinamento
    Private objFuncao As New Persistencia.perFuncao
    Private sMensagens() As String = {"Nome do treinamento obrigatório.", _
                                      "Carga horária obrigatória.", _
                                      "Validade obrigatória."}
    Private iprvIdTreinamento As Integer
#End Region

#Region "Propriedades"

    Public Property IDTreinamento() As Integer
        Get
            Return Me.iprvIdTreinamento
        End Get
        Set(ByVal value As Integer)
            Me.iprvIdTreinamento = value
        End Set
    End Property

    Private bResultado As Boolean = False

    ReadOnly Property sqlConsulta() As String
        Get
            Return Me.objTreinamento.sqlConsulta(Persistencia.Globais.iIDEmpresa)
        End Get
    End Property

#End Region

#Region "Métodos públicos"

    Private Function seBemFormado(ByVal sDescricao As String, _
                                  ByVal sCargaHoraria As String, _
                                  ByVal iValidadeAtu As Integer) As Boolean

        Dim bBemFormado As Boolean = True

        If sDescricao = String.Empty Then

            MyBase.adicionarMensagensValidacao(eMensagens.NOME_TREINAMENTO_OBRIGATORIO, _
                                               Me.sMensagens(eMensagens.NOME_TREINAMENTO_OBRIGATORIO))

            bBemFormado = False
        End If

        If sCargaHoraria = String.Empty Then

            MyBase.adicionarMensagensValidacao(eMensagens.CARGA_HORARIA, _
                                               Me.sMensagens(eMensagens.CARGA_HORARIA))

            bBemFormado = False
        End If

        If iValidadeAtu = 0 Then

            MyBase.adicionarMensagensValidacao(eMensagens.VALIDADE_OBRIGATORIA, _
                                               Me.sMensagens(eMensagens.VALIDADE_OBRIGATORIA))

            bBemFormado = False
        End If

        Return bBemFormado

    End Function

    Public Function salvar(ByVal iIdTreinamento As Integer, _
                           ByVal sDescricaoTreinamento As String, _
                           ByVal iValidadeAnt As Integer, _
                           ByVal iValidadeAtu As Integer, _
                           ByVal bPadrao As Boolean, _
                           ByVal sCargaHoraria As String) As Boolean
        Try

            Dim dsUsuarios As New DataSet
            Dim iIDEmpresa As Integer
            

            MyBase.limparMensagensValidacao()
            MyBase.iniciarControleTransacional()

            Me.objTreinamento.TransacaoOrigem = MyBase.ControleTransacional
    
            iIDEmpresa = IIf(bPadrao, 0, Persistencia.Globais.iIDEmpresa)

            If seBemFormado(sDescricaoTreinamento, sCargaHoraria, iValidadeAtu) Then

                If iIdTreinamento > 0 Then
                    Me.objTreinamento.Atualizar_Treinamento(iIdTreinamento, _
                                                            sDescricaoTreinamento, _
                                                            sCargaHoraria)
                    Me.IDTreinamento = iIdTreinamento


                    Me.bResultado = True
                Else

                    Me.IDTreinamento = Me.objTreinamento.Inserir_Treinamento(sDescricaoTreinamento, _
                                                                             sCargaHoraria)
                    objTreinamento.Inserir_Validade(Me.IDTreinamento, iIDEmpresa, iValidadeAtu)

                    Me.bResultado = True
                End If

                If (iValidadeAnt <> iValidadeAtu) Then
                    If (iValidadeAtu = 0) Then
                        objTreinamento.Atualizar_Validade(Me.IDTreinamento, iIDEmpresa, 0)
                    Else
                        objTreinamento.Atualizar_Validade(Me.IDTreinamento, iIDEmpresa, iValidadeAtu)
                    End If
                End If

            Else
                Me.bResultado = False
            End If

        Catch ex As Exception
            Me.bResultado = False
            Throw New Exception("Ocorreu um erro ao salvar os dados do Treinamento. " & Environment.NewLine & ex.Message)
        Finally

            If Me.bResultado Then
                MyBase.finalizarControleTransacional(eFinalizacaoTransacao.Commit)
            Else
                MyBase.finalizarControleTransacional(eFinalizacaoTransacao.Rollback)
            End If

            Me.objTreinamento.TransacaoOrigem = Nothing
            

        End Try

        Return Me.bResultado

    End Function

    Public Function excluir(ByVal iIdTreinamento As Integer) As Boolean

        Dim bResultado As Boolean = True

        Try

            If objTreinamento.Validar_Exclusao_Treinamento(iIdTreinamento) AndAlso _
             Me.objFuncao.seTreinamentoExisteFuncao(iIdTreinamento) Then
                Me.objTreinamento.Excluir_Treinamento(iIdTreinamento)
                bResultado = True
            Else
                bResultado = False
            End If

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao excluir os dados do Treinamento " & Environment.NewLine & ex.Message)
        End Try

        Return bResultado

    End Function

    Public Function selecionar(ByVal iIdTreinamento As Integer, ByVal sListaTreinamento As String, ByVal iIDEmpresa As Integer) As DataSet

        Try
            If (sListaTreinamento = String.Empty) Then
                Return Me.objTreinamento.Selecionar_Treinamento(iIdTreinamento, iIDEmpresa)
            Else
                Return Me.objTreinamento.Selecionar_Lista_Treinamento(sListaTreinamento, iIDEmpresa)
            End If


        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao selecionar os dados do Treinamento " & Environment.NewLine & ex.Message)
        End Try

    End Function

    Public Function Retornar_Validade_Treinamento(ByVal iIDTreinamento As Integer, ByVal iIDEmpresa As Integer) As Integer

        Try
            Return Me.objTreinamento.Retornar_Validade_Treinamento(iIDTreinamento, iIDEmpresa)
        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao selecionar os dados do Treinamento " & Environment.NewLine & ex.Message)
        End Try

    End Function

    Public Function selecionarCampo(ByVal iIdTreinamento As Integer, _
                                ByVal sCampo As String) As Object
        Try
            Return Me.objTreinamento.selecionarCampo(iIdTreinamento, sCampo)
        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao selecionar os dados do Treinamento " & Environment.NewLine & ex.Message)
        End Try
    End Function

    Public Function Retornar_Treinamentos_Atrasados() As DataTable
        Try
            Return objTreinamento.Retornar_Treinamentos_Atrasados

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao selecionar os dados do Treinamento " & Environment.NewLine & ex.Message)
        End Try
    End Function

#End Region

End Class
