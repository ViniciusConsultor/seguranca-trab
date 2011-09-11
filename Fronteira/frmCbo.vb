Imports Controle
Imports Persistencia

Public Class frmCbo

#Region "Variáveis"

    Private iPrvIDCbo As Integer
    Private objCBO As New ctrCBO

#End Region

#Region "Métodos"

    Private Sub frmCbo_alteraModo(ByVal eModoAtual As DSFronteiraPadrao.frmPadrao.eModo) Handles Me.alteraModo
        If (eModoAtual = eModo.eAguardando) Then
            Me.fraPrincipal.Enabled = False
            cmdSelecionarCBO.Enabled = True
        Else
            Me.fraPrincipal.Enabled = True
            cmdSelecionarCBO.Enabled = False
        End If
    End Sub

    Private Sub frmCbo_alterar(ByRef bCancel As Boolean) Handles Me.alterar

        MyBase.modoAtual = eModo.eAlterando

    End Sub

    Private Sub frmCbo_carregaDados() Handles Me.carregaDados
        Dim dtbCBO As New DataTable

        Try
            If (Me.iPrvIDCbo > 0) Then
                dtbCBO = objCBO.Selecionar_CBO(iPrvIDCbo)

                If (dtbCBO.Rows.Count > 0) Then
                    With dtbCBO.Rows(0)
                        txtCodCBO.Text = Conversao.nuloParaVazio(.Item("CodCbo"))
                        txtDescricao.Text = Conversao.nuloParaVazio(.Item("Descricao"))
                    End With
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try

    End Sub

    Private Sub frmCbo_excluir(ByRef bCancel As Boolean) Handles Me.excluir
        Try
            bCancel = True
            If MsgBox("Deseja excluir o registro atual?", MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.Yes Then
                If Not Me.objCBO.Excluir(Me.iPrvIDCbo) Then
                    MsgBox("Exclusão cancelada. Existem registros vinculados ao CBO que impedem sua exclusão.", MsgBoxStyle.Critical, Me.Text)
                Else
                    bCancel = False
                    MyBase.chave = 0
                    Me.iPrvIDCbo = 0
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub frmCbo_gravar(ByRef bCancel As Boolean) Handles Me.gravar
        Dim bRetorno As Boolean

        Try
            bCancel = True
            bRetorno = objCBO.Salvar_CBO(iPrvIDCbo, _
                                        txtDescricao.Text.Trim, _
                                        txtCodCBO.Text.Trim)

            If (bRetorno) Then
                bCancel = False
                Me.iPrvIDCbo = objCBO.IDCBO
                MyBase.chave = Me.iPrvIDCbo
            Else
                MyBase.Mensagens = objCBO.retornaMensagensValidacao
            End If

        Catch ex As Exception

            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)

        End Try
    End Sub

    Private Sub frmCbo_inserir(ByRef bCancel As Boolean) Handles Me.inserir

        Me.iPrvIDCbo = 0
        Me.txtCodCBO.Focus()

    End Sub

    Private Sub frmCbo_limpaCampo() Handles Me.limpaCampo

        MyBase.limpaCampos(Me)

    End Sub

    Private Sub frmCbo_limpaProvedorDeErros() Handles Me.limpaProvedorDeErros

        Me.epPadrao.Clear()

    End Sub

    Private Sub frmCbo_setarProvedorDeErros() Handles Me.setarProvedorDeErros
        Dim iContadorMensagens As Int32
        Dim sMensagem As String

        For iContadorMensagens = 0 To MyBase.Mensagens(DSFronteiraPadrao.frmPadrao.eMensagem.Codigo).Count - 1

            sMensagem = MyBase.Mensagens(DSFronteiraPadrao.frmPadrao.eMensagem.Mensagem).item(iContadorMensagens)

            Select Case MyBase.Mensagens(DSFronteiraPadrao.frmPadrao.eMensagem.Codigo).item(iContadorMensagens)
                Case Controle.ctrCBO.eMensagens.CODIGO_OBRIGATORIO
                    Me.epPadrao.SetError(Me.txtCodCBO, sMensagem)
                Case Controle.ctrCBO.eMensagens.DESCRICAO_OBRIGATORIO
                    Me.epPadrao.SetError(Me.txtDescricao, sMensagem)
            End Select

        Next
    End Sub

    Private Sub cmdSelecionarCBO_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSelecionarCBO.Click
        Dim sSql As String
        Dim frmDialogo As New frmPesquisa

        sSql = Me.objCBO.sqlConsulta()

        With frmDialogo
            .Campos = "iIDCbo,sCodCbo,sDescricao"
            .Descricoes = "Código,CBO,Descrição"
            .Larguras = "50,50,250"
            .Sql = sSql
            .Titulo = "Pesquisa Função"
            .CarregaTela()
            If .DS.Tables(0).Rows.Count > 0 Then
                .ShowDialog()
                If (.DialogResult = Windows.Forms.DialogResult.OK) Then
                    MyBase.chave = Conversao.ToString(.ID)
                    Me.iPrvIDCbo = MyBase.chave
                    frmCbo_carregaDados()
                    MyBase.alteraModopadrao(eModo.eAguardando)
                End If
            Else
                MsgBox("Registro não encontrado", MsgBoxStyle.Exclamation, Me.Text)
                Exit Sub
            End If
        End With
    End Sub

#End Region

End Class