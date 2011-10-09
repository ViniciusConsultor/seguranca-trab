Imports Persistencia
Public Class relNR
    Inherits DSPadraoRelatorio.relPadrao

#Region "Variáveis"

    Private objEmpresa As New Persistencia.perEmpresa
    Private objNR As New Persistencia.perNR
    Private iIdEmpresa As Integer
    Private iIDNR As Integer
    Private sIdsEmpresa As String
    Private dtData As Date
    Public Event Acompanhamento()
    Private iTipoRelatorio As eTipoRelatorioNR

#End Region

#Region "Enumerações"

    Public Enum eTipoRelatorioNR
        eCheckList = 0
        eCadNR = 1
    End Enum

#End Region

#Region "Propriedades"

    Public Property IDNR As Integer
        Get
            Return Me.iIDNR
        End Get
        Set(ByVal value As Integer)
            Me.iIDNR = value
        End Set
    End Property

    Public Property TipoRelatorio() As eTipoRelatorioNR
        Get
            Return Me.iTipoRelatorio
        End Get
        Set(ByVal value As eTipoRelatorioNR)
            Me.iTipoRelatorio = value
        End Set
    End Property

    Public Property Data() As Date
        Get
            Return Me.dtData
        End Get
        Set(ByVal value As Date)
            Me.dtData = value
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

    Private Sub relNR_carregaDados(ByRef dsRPT As Object) Handles Me.carregaDados

        Dim drNR As dsNR.NRRow
        Dim dsDadosNR As New DataSet
        Dim iContador As Integer = 0
        Dim iTotalItens As Integer = 0

        Dim dOK As Decimal = 0
        Dim dNOK As Decimal = 0
        Dim dNConcluido As Decimal = 0

        Dim iOK As Integer = 0
        Dim iNOK As Integer = 0

        Try

            If Me.TipoRelatorio = eTipoRelatorioNR.eCheckList Then

                dsDadosNR = Me.objNR.selecionarNRRelatorio(Me.IDEmpresa,
                                                           Me.IdsEmpresaAcesso,
                                                           Me.Data,
                                                           Me.IDNR)
            Else
                dsDadosNR = Me.objNR.selecionarNRAuditoriaRelatorio(Me.IDEmpresa,
                                                                    Me.IdsEmpresaAcesso,
                                                                    Me.Data,
                                                                    Me.IDNR)
            End If


            If dsDadosNR.Tables(0).Rows.Count > 0 Then

                For Each drDadosNR As DataRow In dsDadosNR.Tables(0).Rows

                    iContador += 1

                    iTotalItens = Conversao.ToInt32(drDadosNR.Item("Total"))
                    iOK = Conversao.ToInt32(drDadosNR.Item("OK"))
                    iNOK = Conversao.ToInt32(drDadosNR.Item("NOK"))

                    If iTotalItens > 0 Then
                        dOK = (iOK * 100) / iTotalItens
                        dNOK = (iNOK * 100) / iTotalItens
                        dNConcluido = ((iTotalItens - iOK - iNOK) * 100) / iTotalItens
                    End If

                    drNR = DirectCast(dsRPT, dsNR).NR.NewNRRow
                    With drNR
                        .IDEmpresa = Conversao.ToInt32(drDadosNR.Item("IDEmpresa"))
                        .Empresa = Conversao.ToString(Me.objEmpresa.selecionarCampo(drDadosNR.Item("IDEmpresa"), "NomeFantasia"))
                        .IDNR = Conversao.ToInt32(drDadosNR.Item("IDNR"))
                        .NConcluido = dNConcluido
                        .OK = dOK
                        .NOK = dNOK
                    End With
                    DirectCast(dsRPT, dsNR).NR.AddNRRow(drNR)

                Next

            End If

        Catch ex As Exception
            Throw New Exception("Exceção no método 'carregaDados'." & Environment.NewLine & ex.Message)
        End Try

    End Sub

    Private Sub relClientes_carregaFormulas(ByRef crRPT As Object) Handles Me.carregaFormulas

        Dim sSubTitulo As String = ""

        With crRPT.DataDefinition.formulaFields
            .item("SubTitle").text = "'" & "Validade: " & Me.Data & "'"
        End With

    End Sub


#End Region

#Region "Métodos públicos"

    Public Function imprime(ByVal byDispositivoSaida As eDispositivoSaida) As Boolean

        Dim dsRPT As DataSet
        Dim crRPT As CrystalDecisions.CrystalReports.Engine.ReportClass
        Dim bProcesso As Boolean = False

        Try
            dsRPT = New dsNR
            crRPT = New rptNR

            If Me.TipoRelatorio = eTipoRelatorioNR.eCheckList Then
                crRPT.SummaryInfo.ReportTitle = "NR CheckList"
            Else
                crRPT.SummaryInfo.ReportTitle = "NR Auditoria"
            End If

            bProcesso = objRelatorio.processa(byDispositivoSaida = eDispositivoSaida.impressora, dsRPT, crRPT)

            Return bProcesso
        Catch ex As Exception
            Throw New Exception("Exceção no método 'imprime'. " & Environment.NewLine & Environment.NewLine & ex.Message)
        End Try

    End Function

#End Region

End Class
