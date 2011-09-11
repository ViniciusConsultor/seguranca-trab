Public Class ctrAgendaTreinamento
    Inherits ctrPadrao

#Region " Enumerações "

    Public Enum eMensagens As Byte
        NOME_TREINAMENTO_OBRIGATORIO = 0
        CARGA_HORARIA = 1
    End Enum

#End Region

#Region "Variáveis"

    Private objAgendaTreinamento As New Persistencia.perAgendaTreinamento
    Private objParticipantes As New Persistencia.perParticipantesTreinamento

    Private sMensagens() As String = {"Descrição obrigatório.", _
                                      "Carga horária obrigatória."}
    Private iIdAgendamento As Integer
#End Region

#Region "Propriedades"

    Public Property IDAgendamento() As Integer
        Get
            Return Me.iIdAgendamento
        End Get
        Set(ByVal value As Integer)
            Me.iIdAgendamento = value
        End Set
    End Property

    Private bResultado As Boolean = False

    ReadOnly Property sqlConsulta(ByVal iIdEmpresa As Integer) As String
        Get
            Return Me.objAgendaTreinamento.sqlConsulta(iIdEmpresa)
        End Get
    End Property

    ReadOnly Property sqlConsulta(ByVal sIdsEmpresa As String) As String
        Get
            Return Me.objAgendaTreinamento.sqlConsulta(sIdsEmpresa)
        End Get
    End Property

#End Region

#Region "Métodos públicos"

    Private Function seBemFormado(ByVal sDescricao As String, _
                                  ByVal sCargaHoraria As String) As Boolean

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

        Return bBemFormado

    End Function

    Public Function salvar(ByVal iIdAgendamento As Integer, _
                           ByVal iIdTreinamento As Integer, _
                           ByVal iIdEmpresa As Integer, _
                           ByVal dtData As Date, _
                           ByVal sDescricao As String, _
                           ByVal sMinistrante As String, _
                           ByVal dsParticipantesTreinamento As DataSet, _
                           ByVal sCargaHoraria As String) As Boolean
        Try

            MyBase.limparMensagensValidacao()

            If seBemFormado(sDescricao, sCargaHoraria) Then

                If iIdAgendamento > 0 Then

                    Me.objAgendaTreinamento.Atualizar_Agendamento(iIdTreinamento, _
                                                                  iIdAgendamento, _
                                                                  dtData, _
                                                                  sDescricao, _
                                                                  sMinistrante, _
                                                                  sCargaHoraria)

                    Me.IDAgendamento = iIdAgendamento

                    Me.objParticipantes.excluirParticipantesTreinamento(Me.IDAgendamento, _
                                                                        0)
                    Me.bResultado = True
                Else

                    Me.IDAgendamento = Me.objAgendaTreinamento.Inserir_Agendamento(iIdTreinamento, _
                                                                                   iIdEmpresa, _
                                                                                   dtData, _
                                                                                   sDescricao, _
                                                                                   sMinistrante, _
                                                                                   sCargaHoraria)

                    Me.bResultado = True
                End If

                If dsParticipantesTreinamento.Tables(0).Rows.Count > 0 Then

                    For Each drDados As DataRow In dsParticipantesTreinamento.Tables(0).Rows
                        Me.objParticipantes.inserirParticipantesTreinamento(Me.IDAgendamento, _
                                                                            drDados.Item("IDFuncionario"))
                    Next

                End If

            Else
                Me.bResultado = False
            End If

        Catch ex As Exception
            Me.bResultado = False
            Throw New Exception("Ocorreu um erro ao salvar os dados da Agenda de Treinamento. " & Environment.NewLine & ex.Message)
        Finally

        End Try

        Return Me.bResultado

    End Function

    Public Function excluir(ByVal iIdAgendamento As Integer) As Boolean

        Dim bResultado As Boolean = True

        Try
            Me.objParticipantes.excluirParticipantesTreinamento(iIdAgendamento, 0)
            Me.objAgendaTreinamento.Excluir_Agendamento(iIdAgendamento)

            bResultado = True

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao excluir os dados da Agenda de Treinamento " & Environment.NewLine & ex.Message)
        End Try

        Return bResultado

    End Function

    Public Function selecionar(ByVal iIdAgendamento As Integer) As DataSet

        Try

            Return Me.objAgendaTreinamento.Selecionar_Agendamento(iIdAgendamento)

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao selecionar os dados da Agenda de Treinamento " & Environment.NewLine & ex.Message)
        End Try

    End Function

    Public Function selecionarParticipantes(ByVal iIdAgendamento As Integer) As DataSet

        Try

            Return Me.objParticipantes.selecionarParticipantesTreinamento(iIdAgendamento)

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao selecionar os dados da Agenda de Treinamento " & Environment.NewLine & ex.Message)
        End Try

    End Function

    Public Function selecionarCampo(ByVal iIdAgendamento As Integer, _
                                    ByVal sCampo As String) As Object

        Try
            Return Me.objAgendaTreinamento.selecionarCampo(iIdAgendamento, sCampo)
        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao selecionar os dados da Agenda de Treinamento " & Environment.NewLine & ex.Message)
        End Try

    End Function

    Public Function selecionarParticipantesTreinamento(ByVal iIdEmpresa As Integer, _
                                                   ByVal iIdTreinamento As Integer, _
                                                   ByVal iIdAgendamento As Integer, _
                                                   ByVal dtDataInicial As Date, _
                                                   ByVal dtDataFinal As Date, _
                                                   ByVal sIdsEmpresasAcesso As String) As DataSet
        Return Me.objAgendaTreinamento.selecionarParticipantesTreinamento(iIdEmpresa, _
                                                                          iIdTreinamento, _
                                                                          iIdAgendamento, _
                                                                          dtDataInicial, _
                                                                          dtDataFinal, _
                                                                          sIdsEmpresasAcesso)
    End Function

    Public Function selecionarTreinamentosFuncionario(ByVal iIdFuncionario As Integer) As DataSet
        Return Me.objAgendaTreinamento.selecionarTreinamentosFuncionario(iIdFuncionario)
    End Function
#End Region

End Class
