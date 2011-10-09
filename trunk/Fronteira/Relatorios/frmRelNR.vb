Imports Persistencia
Public Class frmRelNR

#Region "Variáveis"

    Private WithEvents objRelNR As New Relatorio.relNR
    Private objEmpresa As New Controle.ctrEmpresa
    Private objEmpresaUsuario As New Controle.ctrUsuarioEmpresa
    Private objNR As New Controle.ctrNR
    Private iIdEmpresa As Integer = 0
    Private iTipoRelatorio As Relatorio.relNR.eTipoRelatorioNR
    Private iIdNR As Integer = 0
    Private sIdsEmpresaAcesso As String = String.Empty
    Private sNomeRelatorio As String = String.Empty
#End Region

#Region " Propriedades públicas "

    Public Property NomeRelatorio() As String
        Get
            Return Me.sNomeRelatorio
        End Get
        Set(ByVal value As String)
            Me.sNomeRelatorio = value
        End Set
    End Property

    Public Property TipoRelatorio() As Relatorio.relNR.eTipoRelatorioNR
        Get
            Return Me.iTipoRelatorio
        End Get
        Set(ByVal value As Relatorio.relNR.eTipoRelatorioNR)
            Me.iTipoRelatorio = value
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

        If Not Me.chkTodasNR.Checked AndAlso Me.iIdNR = 0 Then
            Me.epPadrao.SetError(Me.chkTodasNR, "Informe a NR")
            bRetorno = False
        Else
            Me.epPadrao.SetError(Me.chkTodasNR, "Informe a NR")
        End If

        Return bRetorno

    End Function

    Private Sub imprimirRelatorio()

        Dim bRetorno As Boolean

        Try

            If Me.validaFormulario Then

                Me.epPadrao.Clear()

                With Me.objRelNR

                    If iIdEmpresa = 0 Then
                        .IdsEmpresaAcesso = Me.sIdsEmpresaAcesso
                        .IDEmpresa = 0
                    Else
                        .IDEmpresa = Me.iIdEmpresa
                        .IdsEmpresaAcesso = String.Empty
                    End If

                    .IDNR = Me.iIdNR

                    .Data = Me.dtpData.Value.Date
                    .TipoRelatorio = Me.TipoRelatorio

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

        If Me.TipoRelatorio = Relatorio.relNR.eTipoRelatorioNR.eCheckList Then
            Me.Text = "Relatório NR CheckList"
        Else
            Me.Text = "Relatório NR Auditoria"
        End If

        If Me.IDEmpresa > 0 Then
            Me.preencheDescricaoEmpresa()
        Else
            Me.iIdEmpresa = Globais.iIDEmpresa
            Me.txtEmpresa.Text = Conversao.ToString(Me.objEmpresa.selecionarCampo(Me.iIdEmpresa, "NomeFantasia"))
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

    Private Sub chkTodasEmpresas_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkTodasEmpresas.CheckedChanged
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

    Private Sub cmdNR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNR.Click

        Dim sSql As String
        Dim frmDialogo As New frmPesquisa

        sSql = Me.objNR.sqlConsulta()

        With frmDialogo
            .Sql = sSql
            .Titulo = "Pesquisa NR"
            .CarregaTela()
            If .DS.Tables(0).Rows.Count > 0 Then
                .ShowDialog()
                If (.DialogResult = Windows.Forms.DialogResult.OK) Then
                    Me.iIdNR = .ID
                    Me.preencheDescricaoNR()
                End If
            Else
                MsgBox("Registro não encontrado", MsgBoxStyle.Exclamation, Me.Text)
                Exit Sub
            End If
        End With

    End Sub

    Private Sub preencheDescricaoNR()

        If Me.iIdNR > 0 Then
            Me.txtNR.Text = Conversao.ToString(Me.objNR.selecionarCampo(Me.iIdNR, "Descricao"))
        Else
            Me.txtNR.Text = String.Empty
        End If

    End Sub

    Private Sub chkTodasNR_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkTodasNR.CheckedChanged
        If sender.checked Then
            Me.txtNR.Enabled = False
            Me.cmdNR.Enabled = False
            Me.iIdNR = 0
            Me.txtNR.Text = String.Empty
        Else
            Me.txtNR.Enabled = True
            Me.cmdNR.Enabled = True
        End If
    End Sub

    Private Sub cmdSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSair.Click
        Me.Close()
    End Sub

#End Region

    
End Class