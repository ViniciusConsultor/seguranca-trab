Imports Persistencia
Public Class relTreinamentoAnalitico
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
    Private bMostrarFuncionarioas As Boolean

#End Region

#Region "Propriedades"

    Public Property MostrarFuncionarios As Boolean
        Get
            Return Me.bMostrarFuncionarioas
        End Get
        Set(ByVal value As Boolean)
            Me.bMostrarFuncionarioas = value
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

    Private Sub relClientes_carregaDados(ByRef dsRPT As Object) Handles Me.carregaDados

        Dim drTreinamento As dsTreinamentoAnalitico.TreinamentoRow
        Dim dsDadosTreinamento As New DataSet
        Dim iContador As Integer = 0
        Try

            dsDadosTreinamento = Me.objAgendaTreinamento.selecionarParticipantesTreinamento(Me.IDEmpresa,
                                                                                            Me.IDTipoTreinamento,
                                                                                            Me.IDAgendaTreinamento,
                                                                                            Me.DataInicial,
                                                                                            Me.DataFinal,
                                                                                            Me.IdsEmpresaAcesso)

            If dsDadosTreinamento.Tables(0).Rows.Count > 0 Then

                For Each drDadosTreinamento As DataRow In dsDadosTreinamento.Tables(0).Rows

                    iContador += 1

                    drTreinamento = DirectCast(dsRPT, dsTreinamentoAnalitico).Treinamento.NewTreinamentoRow
                    With drTreinamento
                        .IDEmpresa = Conversao.ToInt32(drDadosTreinamento.Item("IDEmpresa"))
                        .IDTipoTreinamento = Conversao.ToInt32(drDadosTreinamento.Item("IDTreinamento"))
                        .IDAgendamento = Conversao.ToInt32(drDadosTreinamento.Item("IDAgendamento"))
                        .Data = Conversao.ToDateTime(drDadosTreinamento.Item("Data"))
                        .Empresa = Conversao.ToString(drDadosTreinamento.Item("NomeFantasia"))
                        .Ministrante = Conversao.ToString(drDadosTreinamento.Item("Ministrante"))
                        .TipoTreinamento = Conversao.ToString(drDadosTreinamento.Item("TipoTreinamento"))
                        .Treinamento = Conversao.ToString(drDadosTreinamento.Item("Treinamento"))
                        If Not drDadosTreinamento.Item("Logomarca") Is DBNull.Value Then
                            .Logomarca = drDadosTreinamento.Item("Logomarca")
                        End If
                        .IDFuncionario = Conversao.ToInt32(drDadosTreinamento.Item("IDFuncionario"))
                        .Funcionario = Conversao.ToString(drDadosTreinamento.Item("Funcionario"))
                    End With
                    DirectCast(dsRPT, dsTreinamentoAnalitico).Treinamento.AddTreinamentoRow(drTreinamento)

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
            .item("MostrarFuncionarios").text = Me.MostrarFuncionarios
        End With

    End Sub

#End Region

#Region "Métodos públicos"

    Public Function imprime(ByVal byDispositivoSaida As eDispositivoSaida) As Boolean

        Dim dsRPT As DataSet
        Dim crRPT As CrystalDecisions.CrystalReports.Engine.ReportClass
        Dim bProcesso As Boolean = False

        Try
            dsRPT = New dsTreinamentoAnalitico
            crRPT = New rptTreinamentoAnalitico

            crRPT.SummaryInfo.ReportTitle = "Relatório Treinamento Analítico"

            bProcesso = objRelatorio.processa(byDispositivoSaida = eDispositivoSaida.impressora, dsRPT, crRPT)

            Return bProcesso
        Catch ex As Exception
            Throw New Exception("Exceção no método 'imprime'. " & Environment.NewLine & Environment.NewLine & ex.Message)
        End Try

    End Function

#End Region

End Class
