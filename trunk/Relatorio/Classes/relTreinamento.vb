Imports Persistencia
Public Class relTreinamento
    Inherits DSPadraoRelatorio.relPadrao

#Region "Variáveis"

    Private objEmpresa As New Persistencia.perEmpresa
    Private objAgendaTreinamento As New Persistencia.perAgendaTreinamento
    Private iIdTipoTreinamento As Integer
    Private iIdAgendaTreinamento As Integer
    Private iIdEmpresa As Integer
    Private dtDataInicial As Date
    Private dtDataFinal As Date
    Private sIdsEmpresa As String
    Private sAnaliseCritica As String
    Private sAprovacao As String
    Private iTotalRegistros As Integer
    Public Event Acompanhamento()

#End Region

#Region "Propriedades"

    Public Property TotalRegistros()
        Get
            Return Me.iTotalRegistros
        End Get
        Set(ByVal value)
            Me.iTotalRegistros = value
        End Set
    End Property

    Public Property Aprovacao() As String
        Get
            Return Me.sAprovacao
        End Get
        Set(ByVal value As String)
            Me.sAprovacao = value
        End Set
    End Property

    Public Property AnaliseCritica() As String
        Get
            Return Me.sAnaliseCritica
        End Get
        Set(ByVal value As String)
            Me.sAnaliseCritica = value
        End Set
    End Property

    Public Property IdsEmpresaAcesso() As String
        Get
            Return Me.sIdsEmpresa
        End Get
        Set(ByVal value As String)
            Me.sIdsEmpresa = value
        End Set
    End Property

    Public Property IDTipoTreinamento() As Integer
        Get
            Return Me.iIdTipoTreinamento
        End Get
        Set(ByVal value As Integer)
            Me.iIdTipoTreinamento = value
        End Set
    End Property

    Public Property IDAgendaTreinamento() As Integer
        Get
            Return Me.iIdAgendaTreinamento
        End Get
        Set(ByVal value As Integer)
            Me.iIdAgendaTreinamento = value
        End Set
    End Property

    Public Property IDEmpresa() As Integer
        Get
            Return Me.iIdEmpresa
        End Get
        Set(ByVal value As Integer)
            Me.iIdEmpresa = value
        End Set
    End Property

    Public Property DataInicial() As Date
        Get
            Return Me.dtDataInicial
        End Get
        Set(ByVal value As Date)
            Me.dtDataInicial = value
        End Set
    End Property

    Public Property DataFinal() As Date
        Get
            Return Me.dtDataFinal
        End Get
        Set(ByVal value As Date)
            Me.dtDataFinal = value
        End Set
    End Property

#End Region

#Region "Métodos privados"

    Private Sub relTreinamento_Acompanhamento() Handles Me.Acompanhamento

    End Sub

    Private Sub relClientes_carregaDados(ByRef dsRPT As Object) Handles Me.carregaDados

        Dim drTreinamento As dsParticipantesTreinamento.TreinamentoRow
        Dim dsDadosTreinamento As New DataSet
        Dim iContador As Integer = 0
        Try

            dsDadosTreinamento = Me.objAgendaTreinamento.selecionarParticipantesTreinamento(Me.IDEmpresa, _
                                                                                            Me.IDTipoTreinamento, _
                                                                                            Me.IDAgendaTreinamento, _
                                                                                            Me.DataInicial, _
                                                                                            Me.DataFinal, _
                                                                                            Me.IdsEmpresaAcesso)

            If dsDadosTreinamento.Tables(0).Rows.Count > 0 Then

                Me.TotalRegistros = dsDadosTreinamento.Tables(0).Rows.Count

                For Each drDadosTreinamento As DataRow In dsDadosTreinamento.Tables(0).Rows

                    iContador += 1

                    drTreinamento = DirectCast(dsRPT, dsParticipantesTreinamento).Treinamento.NewTreinamentoRow
                    With drTreinamento
                        .IDEmpresa = Conversao.ToInt32(drDadosTreinamento.Item("IDEmpresa"))
                        .IDTipoTreinamento = Conversao.ToInt32(drDadosTreinamento.Item("IDTreinamento"))
                        .IDAgendamento = Conversao.ToInt32(drDadosTreinamento.Item("IDAgendamento"))
                        .Data = Conversao.ToDateTime(drDadosTreinamento.Item("Data"))
                        .Empresa = Conversao.ToString(drDadosTreinamento.Item("NomeFantasia"))
                        .Funcionario = Conversao.ToString(drDadosTreinamento.Item("Nome"))
                        .Ministrante = Conversao.ToString(drDadosTreinamento.Item("Ministrante"))
                        .TipoTreinamento = Conversao.ToString(drDadosTreinamento.Item("TipoTreinamento"))
                        .Treinamento = Conversao.ToString(drDadosTreinamento.Item("Treinamento"))
                        .CpfFuncionario = String.Format("{0:000\.000\.000\-00}", Convert.ToDouble(Conversao.ToString(drDadosTreinamento.Item("CPF"))))
                        If Not drDadosTreinamento.Item("Logomarca") Is DBNull.Value Then
                            .Logomarca = drDadosTreinamento.Item("Logomarca")
                        End If
                    End With
                    DirectCast(dsRPT, dsParticipantesTreinamento).Treinamento.AddTreinamentoRow(drTreinamento)

                Next

            End If

        Catch ex As Exception
            Throw New Exception("Exceção no método 'carregaDados'." & Environment.NewLine & ex.Message)
        End Try

    End Sub

    Private Sub relClientes_carregaFormulas(ByRef crRPT As Object) Handles Me.carregaFormulas

        Dim sSubTitulo As String = ""

        With crRPT.DataDefinition.formulaFields
            .item("SubTitle").text = "'" & sSubTitulo & "'"
            .item("AnaliseCritica").text = "'" & Me.AnaliseCritica & "'"
            .item("Aprovacao").text = "'" & Me.Aprovacao & "'"
        End With

    End Sub

#End Region

#Region "Métodos públicos"

    Public Function imprime(ByVal byDispositivoSaida As eDispositivoSaida) As Boolean

        Dim dsRPT As DataSet
        Dim crRPT As CrystalDecisions.CrystalReports.Engine.ReportClass
        Dim bProcesso As Boolean = False

        Try
            dsRPT = New dsParticipantesTreinamento
            crRPT = New rptTreinamento

            crRPT.SummaryInfo.ReportTitle = "Participantes do Treinamento"

            bProcesso = objRelatorio.processa(byDispositivoSaida = eDispositivoSaida.impressora, dsRPT, crRPT)

            Return bProcesso
        Catch ex As Exception
            Throw New Exception("Exceção no método 'imprime'. " & Environment.NewLine & Environment.NewLine & ex.Message)
        End Try

    End Function

#End Region

End Class
