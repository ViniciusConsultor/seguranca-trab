Imports Persistencia

Public Class frmRelEPI

#Region "Variáveis"

    Private WithEvents objRelEPI As New Relatorio.relEPI
    Private objEmpresa As New Controle.ctrEmpresa
    Private objEmpresaUsuario As New Controle.ctrUsuarioEmpresa
    Private objFuncionario As New Controle.ctrFuncionario
    Private iIdEmpresa As Integer = 0
    Private iIdFuncionario As Integer = 0
    Private sIdsEmpresaAcesso As String = String.Empty

#End Region

#Region " Propriedades públicas "

    Public Property IDEmpresa() As Integer
        Get
            Return Me.iIdEmpresa
        End Get
        Set(ByVal value As Integer)
            Me.iIdEmpresa = value
        End Set
    End Property

    Public Property IDFuncionario() As Integer
        Get
            Return Me.iIdFuncionario
        End Get
        Set(ByVal value As Integer)
            Me.iIdFuncionario = value
        End Set
    End Property

#End Region

#Region "Métodos"

    Private Function validaFormulario() As Boolean

        Dim bRetorno As Boolean = True
        Dim sMensagemValidacao As String = ""

        If Not Me.chkTodasEmpresas.Checked AndAlso Me.iIdEmpresa = 0 Then
            Me.epPadrao.SetError(Me.chkTodasEmpresas, "Informe a empresa")
            bRetorno = False
        Else
            Me.epPadrao.SetError(Me.chkTodasEmpresas, "")
        End If

        If Not Me.chkTodosFuncionarios.Checked AndAlso Me.iIdFuncionario = 0 Then
            Me.epPadrao.SetError(Me.chkTodosFuncionarios, "Informe o funcionário")
            bRetorno = False
        Else
            Me.epPadrao.SetError(Me.chkTodosFuncionarios, "")
        End If

        Return bRetorno

    End Function

    Private Sub imprimirRelatorio()

        Dim bRetorno As Boolean

        Try

            If Me.validaFormulario Then

                With Me.objRelEPI

                    If iIdEmpresa = 0 Then
                        .IdsEmpresaAcesso = Me.sIdsEmpresaAcesso
                        .IDEmpresa = 0
                    Else
                        .IDEmpresa = Me.iIdEmpresa
                        .IdsEmpresaAcesso = String.Empty
                    End If

                    .IDFuncionario = Me.iIdFuncionario

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

        Me.sIdsEmpresaAcesso = Conversao.ToString(Me.objEmpresaUsuario.selecionarEmpresasAcesso(Globais.iIDUsuario))
        Me.chkTodasEmpresas.Checked = False

        If Me.IDEmpresa > 0 Then
            Me.preencheDescricaoEmpresa()
        Else
            Me.iIdEmpresa = Globais.iIDEmpresa
            Me.txtEmpresa.Text = Conversao.ToString(Me.objEmpresa.selecionarCampo(Me.iIdEmpresa, "NomeFantasia"))
        End If

        If Me.IDFuncionario > 0 Then
            Me.chkTodosFuncionarios.Checked = False
            Me.preencheDescricaoFuncionario()
        End If

    End Sub

    Private Sub frmRelEPI_visualizar(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.visualizar
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

    Private Sub cmdFuncionario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFuncionario.Click

        Dim sSql As String
        Dim frmDialogo As New frmPesquisa

        sSql = Me.objFuncionario.sqlConsulta(0, Me.iIdEmpresa)

        With frmDialogo
            .Sql = sSql
            .Titulo = "Pesquisa Funcionários"
            .CarregaTela()
            If .DS.Tables(0).Rows.Count > 0 Then
                .ShowDialog()
                If (.DialogResult = Windows.Forms.DialogResult.OK) Then
                    Me.iIdFuncionario = .ID
                    Me.preencheDescricaoFuncionario()
                End If
            Else
                MsgBox("Registro não encontrado", MsgBoxStyle.Exclamation, Me.Text)
                Exit Sub
            End If
        End With

    End Sub

    Private Sub preencheDescricaoFuncionario()

        If Me.iIdFuncionario > 0 Then
            Me.txtFuncionario.Text = Conversao.ToString(Me.objFuncionario.selecionarCampo(Me.iIdFuncionario, "Nome"))
        Else
            Me.txtFuncionario.Text = String.Empty
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

    Private Sub chkTodosFuncionarios_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTodosFuncionarios.CheckedChanged

        If sender.checked Then
            Me.txtFuncionario.Enabled = False
            Me.cmdFuncionario.Enabled = False
            Me.iIdFuncionario = 0
            Me.txtFuncionario.Text = String.Empty
        Else
            Me.txtFuncionario.Enabled = True
            Me.cmdFuncionario.Enabled = True
        End If

    End Sub

    Private Sub cmdSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSair.Click
        Me.Close()
    End Sub

#End Region

End Class