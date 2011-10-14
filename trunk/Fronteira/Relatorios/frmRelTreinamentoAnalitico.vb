Imports Persistencia
Public Class frmRelTreinamentoAnalitico

#Region "Variáveis"

    Private WithEvents objRelTreinamentoAnalitico As New Relatorio.relTreinamentoAnalitico
    Private objEmpresa As New Controle.ctrEmpresa
    Private objTipoTreinamento As New Controle.ctrTreinamento
    Private objAgendaTreinamento As New Controle.ctrAgendaTreinamento
    Private objUsuarioEmpresa As New Controle.ctrUsuarioEmpresa
    Private iIdEmpresa As Integer = 0
    Private iIdTipoTreinamento As Integer = 0
    Private iIdAgendaTreinamento As Integer = 0
    Private sIdsEmpresaAcesso As String = String.Empty
    Private dtDataInicial As Date = Nothing
    Private dtDataFinal As Date = Nothing

#End Region

#Region " Propriedades públicas "

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

    Public Property IDEmpresa() As Integer
        Get
            Return Me.iIdEmpresa
        End Get
        Set(ByVal value As Integer)
            Me.iIdEmpresa = value
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

#End Region

#Region "Métodos"

    Private Function validaFormulario() As Boolean

        Dim bRetorno As Boolean = True
        Dim sMensagemValidacao As String = ""

        If Not Me.chkTodasEmpresas.Checked AndAlso Me.iIdEmpresa = 0 Then
            Me.epRelatorio.SetError(Me.chkTodasEmpresas, "Informe a empresa")
            bRetorno = False
        Else
            Me.epRelatorio.SetError(Me.chkTodasEmpresas, "")
        End If

        If Not Me.chkTodosTiposTreinamentos.Checked AndAlso Me.iIdTipoTreinamento = 0 Then
            Me.epRelatorio.SetError(Me.chkTodosTiposTreinamentos, "Informe o tipo do treinamento")
            bRetorno = False
        Else
            Me.epRelatorio.SetError(Me.chkTodosTiposTreinamentos, "")
        End If

        If Not Me.chkTodosTreinamentos.Checked AndAlso Me.iIdAgendaTreinamento = 0 Then
            Me.epRelatorio.SetError(Me.chkTodosTreinamentos, "Informe o treinamento")
            bRetorno = False
        Else
            Me.epRelatorio.SetError(Me.chkTodosTreinamentos, "")
        End If

        Return bRetorno

    End Function

    Private Sub imprimirRelatorio()

        Dim bRetorno As Boolean

        Try

            If Me.validaFormulario Then

                With Me.objRelTreinamentoAnalitico

                    If iIdEmpresa = 0 Then
                        .IdsEmpresaAcesso = Me.sIdsEmpresaAcesso
                        .IDEmpresa = 0
                    Else
                        .IDEmpresa = Me.iIdEmpresa
                        .IdsEmpresaAcesso = String.Empty
                    End If

                    .IDAgendaTreinamento = Me.iIdAgendaTreinamento
                    .IDTipoTreinamento = Me.iIdTipoTreinamento

                    If Me.chkTodasDatas.Checked Then
                        .DataInicial = Nothing
                        .DataFinal = Nothing
                    Else
                        .DataInicial = Me.dtpDataInicial.Value
                        .DataFinal = Me.dtpDataFinal.Value
                    End If

                    .MostrarFuncionarios = Me.chkMostrarFuncionarios.Checked

                    bRetorno = .imprime(Globais.eDispositivoSaida.tela)

                    If Not bRetorno Then
                        MsgBox("Não existem registros com os dados selecionados", MsgBoxStyle.Information, Me.Text)
                    End If

                End With

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try

    End Sub

    Private Sub frmRelClientes_imprimir(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.imprimir
        Me.imprimirRelatorio()
    End Sub

    Private Sub frmRelTreinamento_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.sIdsEmpresaAcesso = Conversao.ToString(Me.objUsuarioEmpresa.selecionarEmpresasAcesso(Globais.iIDUsuario))
        Me.chkTodasEmpresas.Checked = False

        If Me.IDEmpresa > 0 Then
            Me.preencheDescricaoEmpresa()
        Else
            Me.iIdEmpresa = Globais.iIDEmpresa
            Me.txtEmpresa.Text = Conversao.ToString(Me.objEmpresa.selecionarCampo(Me.iIdEmpresa, "NomeFantasia"))
        End If

        If Me.IDTipoTreinamento > 0 Then
            Me.chkTodosTiposTreinamentos.Checked = False
            Me.preencheDescricaoTipoTreinamento()
        End If

        If Me.IDAgendaTreinamento > 0 Then
            Me.chkTodosTreinamentos.Checked = False
            Me.preencheDescricaoTreinamento()
        End If

        If Not (Me.DataInicial = Nothing AndAlso Me.DataFinal = Nothing) Then
            Me.chkTodasDatas.Checked = False
            Me.dtpDataInicial.Value = Me.DataInicial
            Me.dtpDataFinal.Value = Me.DataFinal
        End If


    End Sub

    Private Sub frmRelClientes_visualizar(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.visualizar
        Me.imprimirRelatorio()
    End Sub

    Private Sub cmdEmpresa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEmpresa.Click

        Dim sSql As String
        Dim frmDialogo As New frmPesquisa

        sSql = Me.objEmpresa.sqlConsulta(0, _
                                         Globais.iIDUsuario)

        With frmDialogo
            .Sql = sSql
            .Titulo = "Pesquisa Empresa"
            .CarregaTela()
            If .DS.Tables(0).Rows.Count > 0 Then
                .ShowDialog()
                If (.DialogResult = Windows.Forms.DialogResult.OK) Then
                    Me.iIdEmpresa = .ID
                    Me.preencheDescricaoEmpresa()
                End If
            Else
                MsgBox("Registro não encontrado", MsgBoxStyle.Exclamation, Me.Text)
                Exit Sub
            End If
        End With

    End Sub

    Private Sub preencheDescricaoEmpresa()

        If Me.iIdEmpresa > 0 Then
            Me.txtEmpresa.Text = Conversao.ToString(Me.objEmpresa.selecionarCampo(Me.iIdEmpresa, "NomeFantasia"))
        Else
            Me.txtEmpresa.Text = String.Empty
        End If

    End Sub

    Private Sub cmdTipoTreinamento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTipoTreinamento.Click

        Dim sSql As String
        Dim frmDialogo As New frmPesquisa

        sSql = Me.objTipoTreinamento.sqlConsulta()

        With frmDialogo
            .Sql = sSql
            .Titulo = "Pesquisa Tipo de Treinamento"
            .CarregaTela()
            If .DS.Tables(0).Rows.Count > 0 Then
                .ShowDialog()
                If (.DialogResult = Windows.Forms.DialogResult.OK) Then
                    Me.iIdTipoTreinamento = .ID
                    Me.preencheDescricaoTipoTreinamento()
                End If
            Else
                MsgBox("Registro não encontrado", MsgBoxStyle.Exclamation, Me.Text)
                Exit Sub
            End If
        End With

    End Sub

    Private Sub preencheDescricaoTipoTreinamento()

        If Me.iIdTipoTreinamento > 0 Then
            Me.txtTipoTreinamento.Text = Conversao.ToString(Me.objTipoTreinamento.selecionarCampo(Me.iIdTipoTreinamento, "Descricao"))
        Else
            Me.txtTipoTreinamento.Text = String.Empty
        End If

    End Sub

    Private Sub cmdTreinamento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTreinamento.Click

        Dim sSql As String
        Dim frmDialogo As New frmPesquisa

        sSql = Me.objAgendaTreinamento.sqlConsulta(Me.sIdsEmpresaAcesso)

        With frmDialogo
            .Sql = sSql
            .Titulo = "Pesquisa Treinamento"
            .CarregaTela()
            If .DS.Tables(0).Rows.Count > 0 Then
                .ShowDialog()
                If (.DialogResult = Windows.Forms.DialogResult.OK) Then
                    Me.iIdAgendaTreinamento = .ID
                    Me.preencheDescricaoTreinamento()
                End If
            Else
                MsgBox("Registro não encontrado", MsgBoxStyle.Exclamation, Me.Text)
                Exit Sub
            End If
        End With

    End Sub

    Private Sub preencheDescricaoTreinamento()

        If Me.iIdAgendaTreinamento > 0 Then
            Me.txtTreinamento.Text = Conversao.ToString(Me.objAgendaTreinamento.selecionarCampo(Me.iIdAgendaTreinamento, "Descricao"))
        Else
            Me.txtTreinamento.Text = String.Empty
        End If

    End Sub

    Private Sub chkTodasEmpresas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTodasEmpresas.CheckedChanged

        If sender.checked Then
            Me.txtEmpresa.Enabled = False
            Me.cmdEmpresa.Enabled = False
            Me.iIdEmpresa = 0
            Me.txtEmpresa.Text = String.Empty
        Else
            Me.txtEmpresa.Enabled = True
            Me.cmdEmpresa.Enabled = True
        End If

    End Sub

    Private Sub chkTodosTipos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTodosTiposTreinamentos.CheckedChanged

        If sender.checked Then
            Me.txtTipoTreinamento.Enabled = False
            Me.cmdTipoTreinamento.Enabled = False
            Me.iIdTipoTreinamento = 0
            Me.txtTipoTreinamento.Text = String.Empty
        Else
            Me.txtTipoTreinamento.Enabled = True
            Me.cmdTipoTreinamento.Enabled = True
        End If

    End Sub

    Private Sub chkTodosTreinamentos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTodosTreinamentos.CheckedChanged

        If sender.checked Then
            Me.txtTreinamento.Enabled = False
            Me.cmdTreinamento.Enabled = False
            Me.iIdAgendaTreinamento = 0
            Me.txtTreinamento.Text = String.Empty
        Else
            Me.txtTreinamento.Enabled = True
            Me.cmdTreinamento.Enabled = True
        End If

    End Sub

    Private Sub chkTodasDatas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTodasDatas.CheckedChanged

        If sender.checked Then
            Me.dtpDataInicial.Enabled = False
            Me.dtpDataFinal.Enabled = False
            Me.dtpDataInicial.Value = Date.Now
            Me.dtpDataFinal.Value = Date.Now
        Else
            Me.dtpDataFinal.Enabled = True
            Me.dtpDataInicial.Enabled = True
        End If

    End Sub

    Private Sub cmdSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSair.Click
        Me.Close()
    End Sub

#End Region
End Class