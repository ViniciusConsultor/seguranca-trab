Imports Persistencia
Public Class relEntregaEPIAnalitico
    Inherits DSPadraoRelatorio.relPadrao

#Region "Variáveis"

    Private objEPI As New Persistencia.perEPI
    Private objEmpresa As New Persistencia.perEmpresa
    Private objFuncaoFuncionario As New Persistencia.perFuncaoFuncionario
    Private objFuncao As New Persistencia.perFuncao
    Private iIdEPI As Integer
    Private iIdEmpresa As Integer
    Private sIdsEmpresa As String
    Private bMostrarFuncionarios As Boolean

#End Region

#Region "Propriedades"

    Public Property MostrarFuncionarios As Boolean
        Get
            Return Me.bMostrarFuncionarios
        End Get
        Set(ByVal value As Boolean)
            Me.bMostrarFuncionarios = value
        End Set
    End Property

    Public Property IDEPI() As Integer
        Get
            Return Me.iIdEPI
        End Get
        Set(ByVal value As Integer)
            Me.iIdEPI = value
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

#End Region

#Region "Métodos privados"

    Private Sub relEPI_carregaDados(ByRef dsRPT As Object) Handles Me.carregaDados

        Dim drEPI As dsEntregaEPIAnalitico.EPIRow
        Dim datDadosEPI As New DataTable
        Dim iContador As Integer = 0

        Try

            datDadosEPI = Me.objEPI.selecionarEPIRelatorioAnalitico(Me.IDEPI,
                                                                    Me.IdsEmpresaAcesso,
                                                                    Me.IDEmpresa)

            If datDadosEPI.Rows.Count > 0 Then

                For Each drDadosEPI As DataRow In datDadosEPI.Rows

                    iContador += 1

                    drEPI = DirectCast(dsRPT, dsEntregaEPIAnalitico).EPI.NewEPIRow
                    With drEPI
                        .IDEmpresa = Conversao.ToInt32(drDadosEPI.Item("IDEmpresa"))
                        .Empresa = Conversao.ToString(drDadosEPI.Item("NomeFantasia"))
                        If Not Me.objEmpresa.selecionarCampo(drDadosEPI.Item("IDEmpresa"), "Logomarca") Is DBNull.Value Then
                            .Logomarca = Me.objEmpresa.selecionarCampo(drDadosEPI.Item("IDEmpresa"), "Logomarca")
                        End If
                        .EntregaEPI = Conversao.ToDateTime(drDadosEPI.Item("DataEntrega"))
                        .Descricao = Conversao.ToString(drDadosEPI.Item("Descricao"))
                        .Quantidade = Conversao.ToInt32(drDadosEPI.Item("Quantidade"))
                        If (Not IsDBNull(drDadosEPI.Item("Devolucao"))) Then
                            .Devolucao = drDadosEPI.Item("Devolucao")
                        End If
                        .IDFuncionario = Conversao.ToInt32(drDadosEPI.Item("IDFuncionario"))
                        .Funcionario = Conversao.ToString(drDadosEPI.Item("Funcionario"))
                        .IDEPI = Conversao.ToInt32(drDadosEPI.Item("IDEPI"))
                    End With
                    DirectCast(dsRPT, dsEntregaEPIAnalitico).EPI.AddEPIRow(drEPI)

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
            dsRPT = New dsEntregaEPIAnalitico
            crRPT = New rptEntregaEPIAnalitico

            crRPT.SummaryInfo.ReportTitle = "Relatório EPI Analítico"

            bProcesso = objRelatorio.processa(byDispositivoSaida = eDispositivoSaida.impressora, dsRPT, crRPT)

            Return bProcesso
        Catch ex As Exception
            Throw New Exception("Exceção no método 'imprime'. " & Environment.NewLine & Environment.NewLine & ex.Message)
        End Try

    End Function

    Private Sub relEntregaEPIAnalitico_carregaFormulas(ByRef crRPT As Object) Handles Me.carregaFormulas
        Dim sSubTitulo As String = ""

        With crRPT.DataDefinition.formulaFields
            .item("SubTitle").text = "'" & sSubTitulo & "'"
            .item("MostrarFuncionarios").text = Me.MostrarFuncionarios
        End With
    End Sub

#End Region

End Class
