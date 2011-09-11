Imports Persistencia
Public Class relEPI
    Inherits DSPadraoRelatorio.relPadrao

#Region "Variáveis"

    Private objEPI As New Persistencia.perEPI
    Private objEmpresa As New Persistencia.perEmpresa
    Private objFuncaoFuncionario As New Persistencia.perFuncaoFuncionario
    Private objFuncao As New Persistencia.perFuncao
    Private iIdFuncionario As Integer
    Private iTotalRegistros As Integer
    Private iIdEmpresa As Integer
    Private sIdsEmpresa As String
    Private dtDataInicial As Date
    Private dtDataFinal As Date
    Public Event Acompanhamento()

#End Region

#Region "Propriedades"

    Public Property IDFuncionario() As Integer
        Get
            Return Me.iIdFuncionario
        End Get
        Set(ByVal value As Integer)
            Me.iIdFuncionario = value
        End Set
    End Property

    Public Property TotalRegistros()
        Get
            Return Me.iTotalRegistros
        End Get
        Set(ByVal value)
            Me.iTotalRegistros = value
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

    Private Sub relEPI_carregaDados(ByRef dsRPT As Object) Handles Me.carregaDados

        Dim drEPI As dsEntregaEPI.EPIRow
        Dim datDadosEPI As New DataTable
        Dim iContador As Integer = 0
        Dim iIdFuncao As Integer
        Dim dsFuncao As New DataSet

        Try

            datDadosEPI = Me.objEPI.selecionarEPIRelatorio(Me.IDFuncionario, _
                                                           Me.IdsEmpresaAcesso, _
                                                           Me.IDEmpresa)

            If datDadosEPI.Rows.Count > 0 Then

                Me.TotalRegistros = datDadosEPI.Rows.Count

                For Each drDadosEPI As DataRow In datDadosEPI.Rows


                    iContador += 1

                    drEPI = DirectCast(dsRPT, dsEntregaEPI).EPI.NewEPIRow
                    With drEPI
                        .IDEmpresa = Conversao.ToInt32(drDadosEPI.Item("IDEmpresa"))
                        .Empresa = Conversao.ToString(drDadosEPI.Item("NomeFantasia"))
                        If Not drDadosEPI.Item("Logomarca") Is DBNull.Value Then
                            .Logomarca = drDadosEPI.Item("Logomarca")
                        End If
                        .IDFuncionario = Conversao.ToInt32(drDadosEPI.Item("IDFuncionario"))
                        .Funcionario = Conversao.ToString(drDadosEPI.Item("Nome"))
                        .Admissao = Conversao.ToDateTime(drDadosEPI.Item("Admissao"))
                        .CA = Conversao.ToString(drDadosEPI.Item("CA"))
                        .EntregaEPI = Conversao.ToDateTime(drDadosEPI.Item("DataEntrega"))
                        .EPI = Conversao.ToString(drDadosEPI.Item("Descricao"))
                        iIdFuncao = Me.objFuncaoFuncionario.Retorna_Funcao_Vigente(Conversao.ToInt32(drDadosEPI.Item("IDFuncionario")))
                        dsFuncao = Me.objFuncao.selecionarFuncao(iIdFuncao)
                        .Funcao = dsFuncao.Tables(0).Rows(0).Item("Descricao")
                        .Quantidade = Conversao.ToInt32(drDadosEPI.Item("Quantidade"))
                        .Registro = Conversao.ToString(drDadosEPI.Item("Registro"))
                        .Unidade = Conversao.ToInt32(drDadosEPI.Item("Unidade"))
                        If (Not IsDBNull(drDadosEPI.Item("Devolucao"))) Then
                            .Devolucao = drDadosEPI.Item("Devolucao")
                        End If
                    End With
                    DirectCast(dsRPT, dsEntregaEPI).EPI.AddEPIRow(drEPI)

                Next

            End If

        Catch ex As Exception
            Throw New Exception("Exceção no método 'carregaDados'." & Environment.NewLine & ex.Message)
        End Try

    End Sub

#End Region

#Region "Métodos públicos"

    Public Function imprime(ByVal byDispositivoSaida As eDispositivoSaida) As Boolean

        Dim dsRPT As DataSet
        Dim crRPT As CrystalDecisions.CrystalReports.Engine.ReportClass
        Dim bProcesso As Boolean = False

        Try
            dsRPT = New dsEntregaEPI
            crRPT = New rptEPI

            crRPT.SummaryInfo.ReportTitle = "Entrega de EPI's"

            bProcesso = objRelatorio.processa(byDispositivoSaida = eDispositivoSaida.impressora, dsRPT, crRPT)

            Return bProcesso
        Catch ex As Exception
            Throw New Exception("Exceção no método 'imprime'. " & Environment.NewLine & Environment.NewLine & ex.Message)
        End Try

    End Function

#End Region

End Class
