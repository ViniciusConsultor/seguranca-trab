Imports Persistencia
Imports System.IO
Public Class frmTreinamento

#Region " Variáveis "

    Private bResultado As Boolean

    Public Property Resultado() As Boolean
        Get
            Return Me.bResultado
        End Get
        Set(ByVal value As Boolean)
            Me.bResultado = value
        End Set
    End Property

    Private objTreinamento As New Controle.ctrTreinamento
    Public iIDTreinamento As Integer
    Private iPrvValidadeAnt As Integer

#End Region

#Region " Métodos "

    Private Sub frmTreinamento_alteraModo(ByVal eModoAtual As DSFronteiraPadrao.frmPadrao.eModo) Handles Me.alteraModo

        If eModoAtual = eModo.eAguardando Then
            Me.fraPrincipal.Enabled = False
            Me.cmdSelecionarTreinamento.Enabled = True
        Else
            Me.fraPrincipal.Enabled = True
            Me.cmdSelecionarTreinamento.Enabled = False
        End If

    End Sub

    Private Sub frmTreinamento_carregaDados(ByVal iChave As Integer) Handles Me.carregaDados

        Dim dsTreinamento As New DataSet

        If (iChave > 0) Then

            dsTreinamento = Me.objTreinamento.selecionar(iChave, "", 0)

            If dsTreinamento.Tables(0).Rows.Count > 0 Then
                With dsTreinamento.Tables(0).Rows(0)
                    Me.iIDTreinamento = Conversao.ToInt32(.Item("IDTreinamento"))
                    Me.txtTreinamento.Text = Conversao.ToString(.Item("Descricao"))
                    txtCargaHoraria.Clear()
                    Me.txtCargaHoraria.Text = Conversao.nuloParaVazio(.Item("CargaHoraria"))
                End With
                iPrvValidadeAnt = Me.objTreinamento.Retornar_Validade_Treinamento(iChave, Globais.iIDEmpresa)
                txtValidade.Text = iPrvValidadeAnt
            End If

        End If

    End Sub

    Private Sub frmTreinamento_gravar(ByRef bCancel As Boolean) Handles Me.gravar

        Dim bRetorno As Boolean
        Dim iValidadeAtual As Integer

        Try
            bCancel = True

            iValidadeAtual = Val(txtValidade.Text)
            bRetorno = Me.objTreinamento.salvar(Me.iIDTreinamento, _
                                                Me.txtTreinamento.Text, _
                                                Me.iPrvValidadeAnt, _
                                                iValidadeAtual, _
                                                Me.chkPadrao.Checked, _
                                                Me.txtCargaHoraria.Text)
            If Not bRetorno Then

                MyBase.Mensagens = Me.objTreinamento.retornaMensagensValidacao

            Else
                bCancel = False
                Me.iIDTreinamento = Me.objTreinamento.IDTreinamento
                MyBase.chave = Me.objTreinamento.IDTreinamento
                Me.bResultado = True
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try

    End Sub

    Private Sub frmTreinamento_excluir(ByRef bCancel As Boolean) Handles Me.excluir

        Try
            bCancel = True
            If MsgBox("Deseja excluir o registro atual?", MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.Yes Then
                If Not Me.objTreinamento.excluir(Me.iIDTreinamento) Then
                    MsgBox("Exclusão cancelada. Existem registros vinculados ao treinamento que impedem sua exclusão.", MsgBoxStyle.Critical, Me.Text)
                    bCancel = True
                Else
                    bCancel = False
                    Me.iIDTreinamento = 0
                End If
            Else
                MyBase.Mensagens = Me.objTreinamento.retornaMensagensValidacao
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try

    End Sub

    Private Sub frmTreinamento_setarProvedorDeErros() Handles Me.setarProvedorDeErros

        Dim iContadorMensagens As Int32
        Dim sMensagem As String

        For iContadorMensagens = 0 To MyBase.Mensagens(DSFronteiraPadrao.frmPadrao.eMensagem.Codigo).Count - 1

            sMensagem = MyBase.Mensagens(DSFronteiraPadrao.frmPadrao.eMensagem.Mensagem).item(iContadorMensagens)

            Select Case MyBase.Mensagens(DSFronteiraPadrao.frmPadrao.eMensagem.Codigo).item(iContadorMensagens)
                Case Controle.ctrTreinamento.eMensagens.NOME_TREINAMENTO_OBRIGATORIO
                    Me.epPadrao.SetError(Me.cmdSelecionarTreinamento, sMensagem)
                Case Controle.ctrTreinamento.eMensagens.CARGA_HORARIA
                    Me.epPadrao.SetError(Me.lblCargaHoraria, sMensagem)
                Case Controle.ctrTreinamento.eMensagens.VALIDADE_OBRIGATORIA
                    Me.epPadrao.SetError(Me.lblMeses, sMensagem)
            End Select

        Next

    End Sub

    Private Sub frmTreinamento_limpaProvedorDeErros() Handles Me.limpaProvedorDeErros
        Me.epPadrao.SetError(Me.cmdSelecionarTreinamento, String.Empty)
        Me.epPadrao.SetError(Me.lblCargaHoraria, String.Empty)
        Me.epPadrao.SetError(Me.lblMeses, String.Empty)
    End Sub

    Private Sub frmTreinamento_limpaCampo() Handles Me.limpaCampo
        MyBase.limpaCampos(Me)
        txtCargaHoraria.Clear()
    End Sub

    Private Sub frmTreinamentoa_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.txtTreinamento.Focus()
    End Sub

    Private Sub frmTreinamento_inserir(ByRef bCancel As Boolean) Handles Me.inserir
        Me.iIDTreinamento = 0
    End Sub

    Private Sub cmdSelecionarTreinamento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelecionarTreinamento.Click

        Dim sSql As String
        Dim frmDialogo As New frmPesquisa

        sSql = Me.objTreinamento.sqlConsulta()

        With frmDialogo
            .Sql = sSql
            .Titulo = "Pesquisa Treinamento"
            .CarregaTela()
            If .DS.Tables(0).Rows.Count > 0 Then
                .ShowDialog()
                If (.DialogResult = Windows.Forms.DialogResult.OK) Then
                    MyBase.chave = Conversao.ToString(.ID)
                    Me.iIDTreinamento = MyBase.chave
                    frmTreinamento_carregaDados(MyBase.chave)
                    MyBase.alteraModopadrao(eModo.eAguardando)
                End If
            Else
                MsgBox("Registro não encontrado", MsgBoxStyle.Exclamation, Me.Text)
                Exit Sub
            End If
        End With
    End Sub

    Private Sub frmTreinamento_alterar(ByRef bCancel As Boolean) Handles Me.alterar
        MyBase.modoAtual = eModo.eAlterando
    End Sub

    Private Sub txtTreinamento_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        txtTreinamento.SelectAll()
    End Sub


#End Region

    

End Class