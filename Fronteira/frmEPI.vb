Imports Controle
Imports Persistencia
Public Class frmEPI

#Region "Variáveis"

    Private iPrvEPI As Integer
    Private objEPI As New ctrEPI

#End Region

#Region "Métodos"

#End Region

#Region "Eventos"

    Private Sub cmdSelecionarEPI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelecionarEPI.Click
        Dim frmDialogo As New frmPesquisa

        With frmDialogo
            .Campos = "iIDEPI,sDescricao, iCA, sFornecedor"
            .Descricoes = "Código,EPI, CA, Fornecedor"
            .Larguras = "50,150,50,100"
            .Sql = Me.objEPI.sqlConsulta(Globais.iIDEmpresa)
            .Titulo = "Pesquisa EPI"
            .CarregaTela()
            If .DS.Tables(0).Rows.Count > 0 Then
                .ShowDialog()
                If (.DialogResult = Windows.Forms.DialogResult.OK) Then
                    MyBase.chave = Conversao.ToString(.ID)
                    Me.iPrvEPI = MyBase.chave
                    frmEPI_carregaDados()
                    MyBase.alteraModopadrao(eModo.eAguardando)
                End If
            Else
                MsgBox("Registro não encontrado.", MsgBoxStyle.Exclamation, Me.Text)
                Exit Sub
            End If
        End With
    End Sub

    Private Sub frmEPI_alteraModo(ByVal eModoAtual As DSFronteiraPadrao.frmPadrao.eModo) Handles Me.alteraModo
        If (eModoAtual = eModo.eAguardando) Then
            Me.fraPrincipal.Enabled = False
            Me.cmdSelecionarEPI.Enabled = True
        Else
            Me.fraPrincipal.Enabled = True
            Me.cmdSelecionarEPI.Enabled = False
        End If
    End Sub

    Private Sub frmEPI_carregaDados() Handles Me.carregaDados
        Dim dtbEPI As New DataTable

        Try
            If (Me.iPrvEPI > 0) Then
                dtbEPI = objEPI.Selecionar_EPI(iPrvEPI, "", 0)

                If (dtbEPI.Rows.Count > 0) Then
                    With dtbEPI.Rows(0)
                        txtEPI.Text = Conversao.nuloParaVazio(.Item("Descricao"))
                        txtFornecedor.Text = Conversao.nuloParaVazio(.Item("Fornecedor"))
                        txtCA.Text = Conversao.nuloParaVazio(.Item("CA"))
                        txtValidade.Text = Conversao.nuloParaVazio(.Item("Validade"))
                        chkDevolucaoObrigatoria.Checked = Conversao.nuloParaBoleano(.Item("DevolucaoObrigatoria"))
                    End With
                End If

            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub frmEPI_excluir(ByRef bCancel As Boolean) Handles Me.excluir
        Try
            bCancel = True
            If MsgBox("Deseja excluir o registro atual?", MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.Yes Then
                If Not Me.objEPI.excluir(Me.iPrvEPI) Then
                    MsgBox("Exclusão cancelada. Existem registros vinculados a EPI que impedem sua exclusão.", MsgBoxStyle.Critical, Me.Text)
                Else
                    bCancel = False
                    MyBase.chave = 0
                    Me.iPrvEPI = 0
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub frmEPI_gravar(ByRef bCancel As Boolean) Handles Me.gravar
        Dim bRetorno As Boolean
        Try
            bCancel = True
            bRetorno = Me.objEPI.salvar(Me.iPrvEPI, _
                                        Globais.iIDEmpresa, _
                                        txtEPI.Text.Trim, _
                                        txtCA.Text.Trim, _
                                        txtFornecedor.Text.Trim, _
                                        Val(txtValidade.Text), _
                                        chkDevolucaoObrigatoria.Checked)


            If (bRetorno) Then
                bCancel = False
                Me.iPrvEPI = Me.objEPI.IDEPI
                MyBase.chave = Me.iPrvEPI
            Else
                MyBase.Mensagens = objEPI.retornaMensagensValidacao
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try

    End Sub

    Private Sub frmEPI_inserir(ByRef bCancel As Boolean) Handles Me.inserir
        Me.iPrvEPI = 0
        txtEPI.Focus()
    End Sub

    Private Sub frmEPI_limpaCampo() Handles Me.limpaCampo
        MyBase.limpaCampos(Me)
    End Sub

    Private Sub frmEPI_limpaProvedorDeErros() Handles Me.limpaProvedorDeErros
        epPadrao.Clear()
    End Sub

    Private Sub frmEPI_setarProvedorDeErros() Handles Me.setarProvedorDeErros

        Dim iContadorMensagens As Int32
        Dim sMensagem As String

        For iContadorMensagens = 0 To MyBase.Mensagens(DSFronteiraPadrao.frmPadrao.eMensagem.Codigo).Count - 1

            sMensagem = MyBase.Mensagens(DSFronteiraPadrao.frmPadrao.eMensagem.Mensagem).item(iContadorMensagens)

            Select Case MyBase.Mensagens(DSFronteiraPadrao.frmPadrao.eMensagem.Codigo).item(iContadorMensagens)
                Case ctrEPI.eMensagens.CA_OBRIGATORIO
                    Me.epPadrao.SetError(Me.txtCA, sMensagem)
                Case ctrEPI.eMensagens.NOME_EPI_OBRIGATORIO
                    Me.epPadrao.SetError(Me.cmdSelecionarEPI, sMensagem)
                Case ctrEPI.eMensagens.VALIDADE_OBRIGATORA
                    Me.epPadrao.SetError(Me.lblMeses, sMensagem)
            End Select

        Next
    End Sub

#End Region

    Private Sub txtEPI_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEPI.Enter
        txtEPI.SelectAll()
    End Sub

    Private Sub txtCA_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCA.Enter
        txtCA.SelectAll()
    End Sub

    Private Sub txtFornecedor_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFornecedor.Enter
        txtFornecedor.SelectAll()
    End Sub

    Private Sub txtValidade_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtValidade.Enter
        txtValidade.SelectAll()
    End Sub

End Class