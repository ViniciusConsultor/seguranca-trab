Imports Persistencia
Public Class frmRelEPIEntregaAnalitico
#Region "Variáveis"

    Private WithEvents objRelEPIAnalitico As New Relatorio.relEntregaEPIAnalitico
    Private objEmpresa As New Controle.ctrEmpresa
    Private objEmpresaUsuario As New Controle.ctrUsuarioEmpresa
    Private objEPI As New Controle.ctrEPI
    Private iIdEmpresa As Integer = 0
    Private iIdEPI As Integer = 0
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

    Public Property IDEPI() As Integer
        Get
            Return Me.iIdEPI
        End Get
        Set(ByVal value As Integer)
            Me.iIdEPI = value
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

        If Not Me.chkTodosEPI.Checked AndAlso Me.iIdEmpresa = 0 Then
            Me.epRelatorio.SetError(Me.chkTodosEPI, "Informe o EPI")
            bRetorno = False
        Else
            Me.epRelatorio.SetError(Me.chkTodosEPI, "")
        End If

        Return bRetorno

    End Function

    Private Sub imprimirRelatorio()

        Dim bRetorno As Boolean

        Try

            If Me.validaFormulario Then

                With Me.objRelEPIAnalitico

                    If iIdEmpresa = 0 Then
                        .IdsEmpresaAcesso = Me.sIdsEmpresaAcesso
                        .IDEmpresa = 0
                    Else
                        .IDEmpresa = Me.iIdEmpresa
                        .IdsEmpresaAcesso = String.Empty
                    End If

                    .IDEPI = Me.iIdEmpresa

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

    Private Sub frmRelTreinamento_Load(ByVal sender As Object, ByVal e As System.EventArgs)

        Me.sIdsEmpresaAcesso = Conversao.ToString(Me.objEmpresaUsuario.selecionarEmpresasAcesso(Globais.iIDUsuario))
        Me.chkTodasEmpresas.Checked = False

        If Me.IDEmpresa > 0 Then
            Me.preencheDescricaoEmpresa()
        Else
            Me.iIdEmpresa = Globais.iIDEmpresa
            Me.txtEmpresa.Text = Conversao.ToString(Me.objEmpresa.selecionarCampo(Me.iIdEmpresa, "NomeFantasia"))
        End If

        If Me.IDEPI > 0 Then
            Me.chkTodosEPI.Checked = False
            Me.preencheDescricaoEPI()
        End If

    End Sub

    Private Sub frmRelEPI_visualizar(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.visualizar
        Me.imprimirRelatorio()
    End Sub

    Private Sub cmdEmpresa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

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

    Private Sub cmdEPI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim sSql As String
        Dim frmDialogo As New frmPesquisa

        sSql = Me.objEPI.sqlConsulta(0)

        With frmDialogo
            .Sql = sSql
            .Titulo = "Pesquisa EPI"
            .CarregaTela()
            If .DS.Tables(0).Rows.Count > 0 Then
                .ShowDialog()
                If (.DialogResult = Windows.Forms.DialogResult.OK) Then
                    Me.iIdEPI = .ID
                    Me.preencheDescricaoEPI()
                End If
            Else
                MsgBox("Registro não encontrado", MsgBoxStyle.Exclamation, Me.Text)
                Exit Sub
            End If
        End With

    End Sub

    Private Sub preencheDescricaoEPI()

        If Me.iIdEPI > 0 Then
            Me.txtEPI.Text = Conversao.ToString(Me.objEPI.selecionarCampo(Me.iIdEPI, "Descricao"))
        Else
            Me.txtEPI.Text = String.Empty
        End If

    End Sub

    Private Sub chkTodosEPI_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If sender.checked Then
            Me.txtEPI.Enabled = False
            Me.cmdEPI.Enabled = False
            Me.iIdEPI = 0
            Me.txtEPI.Text = String.Empty
        Else
            Me.txtEPI.Enabled = True
            Me.cmdEPI.Enabled = True
        End If

    End Sub

    Private Sub chkTodasEmpresas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If sender.checked Then
            Me.txtEPI.Enabled = False
            Me.cmdEmpresa.Enabled = False
            Me.iIdEmpresa = 0
            Me.txtEmpresa.Text = String.Empty
        Else
            Me.txtEmpresa.Enabled = True
            Me.cmdEmpresa.Enabled = True
        End If

    End Sub

    Private Sub cmdSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSair.Click
        Me.Close()
    End Sub

#End Region


End Class