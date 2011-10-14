Imports Persistencia
Public Class relFuncionario
    Inherits DSPadraoRelatorio.relPadrao

#Region "Variáveis"

    Private objEPI As New Persistencia.perEPI
    Private objEmpresa As New Persistencia.perEmpresa
    Private objFuncionario As New Persistencia.perFuncionario
    Private objFuncao As New Persistencia.perFuncao
    Private objTreinamento As New Persistencia.perTreinamento
    Private iIdFuncionario As Integer
    Private iIdEmpresa As Integer
    Private sIdsEmpresa As String

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

        Dim drFuncionario As dsFuncionario.FUNCIONARIORow
        Dim drFuncao As dsFuncionario.FuncaoRow
        Dim drEPI As dsFuncionario.EPIRow
        Dim drTreinamento As dsFuncionario.TreinamentoRow
        Dim datDadosFuncionario As New DataTable
        Dim dsDadosFuncao As New DataSet
        Dim dsDadosEPI As New DataSet
        Dim datDadosTreinamento As New DataTable
        Dim iContador As Integer = 0

        Try

            datDadosFuncionario = Me.objFuncionario.selecionarFuncionariosRelatorio(Me.IDEmpresa,
                                                                                    Me.IdsEmpresaAcesso,
                                                                                    Me.IDFuncionario)

            dsDadosFuncao = Me.objFuncao.selecionarFuncoesFuncionario(Me.IDFuncionario,
                                                                      Me.IDEmpresa,
                                                                      Me.IdsEmpresaAcesso)

            dsDadosEPI = Me.objEPI.selecionarEPIsFuncionario(Me.IDFuncionario,
                                                             Me.IDEmpresa,
                                                             Me.IdsEmpresaAcesso)

            datDadosTreinamento = Me.objTreinamento.selecionarTreinamentosRelatorio(Me.IDFuncionario,
                                                                                    Me.IDEmpresa,
                                                                                    Me.IdsEmpresaAcesso)

            If datDadosFuncionario.Rows.Count > 0 Then

                For Each drDadosFuncionario As DataRow In datDadosFuncionario.Rows

                    iContador += 1

                    drFuncionario = DirectCast(dsRPT, dsFuncionario).FUNCIONARIO.NewFUNCIONARIORow
                    With drFuncionario
                        .Funcionario = Conversao.ToString(drDadosFuncionario.Item("Nome"))
                        .Empresa = Conversao.ToString(drDadosFuncionario.Item("NomeFantasia"))
                        If Not drDadosFuncionario.Item("Logomarca") Is DBNull.Value Then
                            .Logomarca = drDadosFuncionario.Item("Logomarca")
                        End If
                        .IDEmpresa = Conversao.ToInt32(drDadosFuncionario.Item("IDEmpresa"))
                        .IDFuncionario = Conversao.ToInt32(drDadosFuncionario.Item("IDFuncionario"))
                    End With
                    DirectCast(dsRPT, dsFuncionario).FUNCIONARIO.AddFUNCIONARIORow(drFuncionario)

                Next

                For Each drDadosFuncao As DataRow In dsDadosFuncao.Tables(0).Rows

                    iContador += 1

                    drFuncao = DirectCast(dsRPT, dsFuncionario).Funcao.NewFuncaoRow
                    With drFuncao
                        .IDFuncao = Conversao.ToInt32(drDadosFuncao.Item("IDFuncao"))
                        .Funcao = Conversao.ToString(drDadosFuncao.Item("Descricao"))
                        .DataInicio = Conversao.ToDateTime(drDadosFuncao.Item("DataInicio"))
                        If Not drDadosFuncao.Item("DataFim") Is DBNull.Value Then
                            .DataFim = Conversao.ToDateTime(drDadosFuncao.Item("DataFim"))
                        End If

                        .IDFuncionario = Conversao.ToInt32(drDadosFuncao.Item("IDFuncionario"))
                    End With
                    DirectCast(dsRPT, dsFuncionario).Funcao.AddFuncaoRow(drFuncao)

                Next

                For Each drDadosEPI As DataRow In dsDadosEPI.Tables(0).Rows

                    iContador += 1

                    drEPI = DirectCast(dsRPT, dsFuncionario).EPI.NewEPIRow
                    With drEPI
                        .IDEPI = Conversao.ToInt32(drDadosEPI.Item("IDEPI"))
                        .EPI = Conversao.ToString(drDadosEPI.Item("Descricao"))
                        .DataEntrega = Conversao.ToDateTime(drDadosEPI.Item("DataEntrega"))
                        If Not drDadosEPI.Item("Devolucao") Is DBNull.Value Then
                            .Devolucao = Conversao.ToDateTime(drDadosEPI.Item("Devolucao"))
                        End If

                        .Quantidade = Conversao.ToInt32(drDadosEPI.Item("Quantidade"))
                        .IDFuncionario = Conversao.ToInt32(drDadosEPI.Item("IDFuncionario"))
                    End With
                    DirectCast(dsRPT, dsFuncionario).EPI.AddEPIRow(drEPI)

                Next

                For Each drDadosTreinamento As DataRow In datDadosTreinamento.Rows

                    iContador += 1

                    drTreinamento = DirectCast(dsRPT, dsFuncionario).Treinamento.NewTreinamentoRow
                    With drTreinamento
                        .IDTreinamento = Conversao.ToInt32(drDadosTreinamento.Item("IDTreinamento"))
                        .Treinamento = Conversao.ToString(drDadosTreinamento.Item("Treinamento"))
                        .CargaHoraria = Conversao.ToString(drDadosTreinamento.Item("CargaHoraria"))
                        .IDFuncionario = Conversao.ToInt32(drDadosTreinamento.Item("IDFuncionario"))
                    End With
                    DirectCast(dsRPT, dsFuncionario).Treinamento.AddTreinamentoRow(drTreinamento)

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
            dsRPT = New dsFuncionario
            crRPT = New rptFuncionario

            crRPT.SummaryInfo.ReportTitle = "Relatório de Funcionários"

            bProcesso = objRelatorio.processa(byDispositivoSaida = eDispositivoSaida.impressora, dsRPT, crRPT)

            Return bProcesso
        Catch ex As Exception
            Throw New Exception("Exceção no método 'imprime'. " & Environment.NewLine & Environment.NewLine & ex.Message)
        End Try

    End Function

#End Region

End Class
