Imports Persistencia
Public Class frmUsuario

#Region " Variáveis "

    Private objUsuario As New Controle.ctrUsuario
    Private objUsuarioEmpresa As New Controle.ctrUsuarioEmpresa
    Private objSeguranca As New Controle.ctrSeguranca
    Private objEmpresa As New Controle.ctrEmpresa
    Private objGrupoAcesso As New Controle.ctrGrupoAcesso
    Private iIDUsuario As Integer
    Private iIDGrupoAcesso As Integer

#End Region

#Region " Métodos "

    Private Sub formataDtGrid()

        Try
            With Me.dgvAcessoEmpresas

                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                .AutoGenerateColumns = False
                .AllowUserToAddRows = False
                .RowHeadersVisible = False
                .Columns.Clear()

                Dim Col1 As New DataGridViewCheckBoxColumn
                Col1.HeaderText = "Acesso"
                Col1.Width = 50
                Col1.Frozen = True
                Col1.ReadOnly = False
                Col1.FillWeight = 100
                Col1.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                Col1.SortMode = DataGridViewColumnSortMode.NotSortable
                Col1.Visible = True
                Col1.ValueType = System.Type.GetType("System.Boolean")
                .Columns.Add(Col1)

                Dim Col2 As New DataGridViewTextBoxColumn()
                Col2.HeaderText = "IDEmpresa"
                Col2.Width = 70
                Col2.Frozen = True
                Col2.ReadOnly = True
                Col2.FillWeight = 100
                Col2.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                Col2.SortMode = DataGridViewColumnSortMode.Automatic
                Col2.Visible = True
                Col2.ValueType = System.Type.GetType("System.Int32")
                .Columns.Add(Col2)

                Dim Col3 As New DataGridViewTextBoxColumn()
                Col3.HeaderText = "Empresa"
                Col3.Width = 240
                Col3.Frozen = True
                Col3.ReadOnly = True
                Col3.FillWeight = 100
                Col3.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                Col3.SortMode = DataGridViewColumnSortMode.Automatic
                Col3.Visible = True
                Col3.ValueType = System.Type.GetType("System.String")
                .Columns.Add(Col3)

                .Refresh()

            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try

    End Sub

    Private Sub PreencherDtGrid()

        Dim dsEmpresas As New DataSet
        Dim dsUsuarioEmpresa As New DataSet
        Dim iLinha As Integer

        Try

            Me.formataDtGrid()

            dsEmpresas = Me.objEmpresa.selecionar(0)
            dsUsuarioEmpresa = Me.objUsuarioEmpresa.selecionarUsuarioEmpresa(Me.iIDUsuario, _
                                                                             True)

            If dsEmpresas.Tables(0).Rows.Count > 0 Then

                iLinha = 0

                With Me.dgvAcessoEmpresas
                    .Rows.Clear()
                    .RowCount = dsEmpresas.Tables(0).Rows.Count

                    For Each drDados As DataRow In dsEmpresas.Tables(0).Rows
                        .Item(Controle.ctrUsuario.eColEmpresas.eAcesso, iLinha).Value = True
                        .Item(Controle.ctrUsuario.eColEmpresas.eIdEmpresa, iLinha).Value = Conversao.ToString(drDados.Item("IDEmpresa"))
                        .Item(Controle.ctrUsuario.eColEmpresas.eEmpresa, iLinha).Value = Conversao.ToString(drDados.Item("NomeFantasia"))

                        iLinha += 1
                    Next

                End With

            End If

            If dsUsuarioEmpresa.Tables(0).Rows.Count > 0 Then

                For iContador As Integer = 0 To Me.dgvAcessoEmpresas.Rows.Count - 1

                    For Each drDados As DataRow In dsUsuarioEmpresa.Tables(0).Rows

                        If Me.dgvAcessoEmpresas.Item(Controle.ctrUsuario.eColEmpresas.eIdEmpresa, iContador).Value = drDados.Item("IDEmpresa") Then
                            Me.dgvAcessoEmpresas.Item(Controle.ctrUsuario.eColEmpresas.eAcesso, iContador).Value = Conversao.ToBoolean(drDados.Item("Acesso"))
                        End If

                    Next

                Next

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try

    End Sub

    Private Sub frmUsuario_alteraModo(ByVal eModoAtual As DSFronteiraPadrao.frmPadrao.eModo) Handles Me.alteraModo

        Try
            If eModoAtual = eModo.eAguardando Then
                Me.fraUsuario.Enabled = False
                Me.fraAcessoEmpresas.Enabled = False
                Me.cmdSelecionarUsuario.Enabled = True
            Else
                Me.fraUsuario.Enabled = True
                Me.fraAcessoEmpresas.Enabled = True
                Me.cmdSelecionarUsuario.Enabled = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try

    End Sub

    Private Sub frmUsuario_carregaDados(ByVal iChave As Integer) Handles Me.carregaDados

        Dim dsUsuario As New DataSet
        Try

            If (iChave > 0) Then

                dsUsuario = Me.objUsuario.Selecionar(iChave)

                If dsUsuario.Tables(0).Rows.Count > 0 Then
                    With dsUsuario.Tables(0).Rows(0)
                        Me.iIDUsuario = Conversao.ToInt32(.Item("IDUsuario"))
                        Me.txtNome.Text = Me.objSeguranca.descriptografar(Conversao.ToString(.Item("Nome")))
                        Me.txtLogin.Text = Me.objSeguranca.descriptografar(Conversao.ToString(.Item("Login")))
                        Me.txtSenha.Text = Me.objSeguranca.descriptografar(Conversao.ToString(.Item("Senha")))
                        Me.iIDGrupoAcesso = Conversao.ToInt32(.Item("IDGrupoAcesso"))
                        Me.txtGrupoAcesso.Text = Conversao.ToString(.Item("GrupoAcesso"))
                    End With
                End If

                Me.PreencherDtGrid()

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try

    End Sub

    Private Sub frmUsuario_gravar(ByRef bCancel As Boolean) Handles Me.gravar

        Dim bRetorno As Boolean
        Dim dsUsuarioEmpresa As New DataSet

        Try
            bCancel = True
            dsUsuarioEmpresa = MyBase.converteGridParaDataset(Me.dgvAcessoEmpresas, "UsuarioEmpresa")

            bRetorno = Me.objUsuario.salvar(Me.iIDGrupoAcesso, _
                                            Me.iIDUsuario, _
                                            Me.txtNome.Text, _
                                            Me.txtLogin.Text, _
                                            Me.txtSenha.Text, _
                                            dsUsuarioEmpresa)

            If Not bRetorno Then

                MyBase.Mensagens = Me.objUsuario.retornaMensagensValidacao

            Else
                bCancel = False
                Me.iIDUsuario = Me.objUsuario.IDUsuario
                MyBase.chave = Me.objUsuario.IDUsuario

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try

    End Sub

    Private Sub frmUsuario_excluir(ByRef bCancel As Boolean) Handles Me.excluir
        Try
            If MsgBox("Deseja excluir o registro atual?", MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.Yes Then
                Me.objUsuario.excluir(Me.iIDUsuario)
            Else
                bCancel = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub frmUsuario_setarProvedorDeErros() Handles Me.setarProvedorDeErros

        Dim iContadorMensagens As Int32
        Dim sMensagem As String
        Try
            For iContadorMensagens = 0 To MyBase.Mensagens(DSFronteiraPadrao.frmPadrao.eMensagem.Codigo).Count - 1

                sMensagem = MyBase.Mensagens(DSFronteiraPadrao.frmPadrao.eMensagem.Mensagem).item(iContadorMensagens)

                Select Case MyBase.Mensagens(DSFronteiraPadrao.frmPadrao.eMensagem.Codigo).item(iContadorMensagens)
                    Case Controle.ctrUsuario.eMensagens.NOME_OBRIGATORIO
                        Me.epPadrao.SetError(Me.cmdSelecionarUsuario, sMensagem)
                    Case Controle.ctrUsuario.eMensagens.LOGIN_OBRIGATORIO
                        Me.epPadrao.SetError(Me.txtLogin, sMensagem)
                    Case Controle.ctrUsuario.eMensagens.SENHA_OBRIGATORIA
                        Me.epPadrao.SetError(Me.txtSenha, sMensagem)
                    Case Controle.ctrUsuario.eMensagens.LOGIN_EXISTENTE
                        Me.epPadrao.SetError(Me.txtLogin, sMensagem)
                    Case Controle.ctrUsuario.eMensagens.GRUPO_ACESSO_OBRIGATORIO
                        Me.epPadrao.SetError(Me.cmdSelecionarGrupoAcesso, sMensagem)
                End Select

            Next
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub frmUsuario_limpaProvedorDeErros() Handles Me.limpaProvedorDeErros
        Try
            Me.epPadrao.SetError(Me.cmdSelecionarUsuario, String.Empty)
            Me.epPadrao.SetError(Me.txtLogin, String.Empty)
            Me.epPadrao.SetError(Me.txtSenha, String.Empty)
            Me.epPadrao.SetError(Me.cmdSelecionarGrupoAcesso, String.Empty)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub frmUsuario_limpaCampo() Handles Me.limpaCampo
        Try
            MyBase.limpaCampos(Me)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub frmUsuario_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Me.PreencherDtGrid()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub frmUsuario_inserir(ByRef bCancel As Boolean) Handles Me.inserir
        Try
            Me.iIDUsuario = 0
            Me.iIDGrupoAcesso = 0
            MyBase.chave = 0
            Me.PreencherDtGrid()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub frmUsuario_cancelar(ByRef bCancel As Boolean) Handles Me.cancelar
        Try
            Me.PreencherDtGrid()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub cmdSelecionarUsuario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelecionarUsuario.Click
        Try
            Dim sSql As String
            Dim frmDialogo As New frmPesquisa

            sSql = Me.objUsuario.sqlConsulta(0)

            With frmDialogo
                .DadosCriptografados = True
                .Sql = sSql
                .Titulo = "Pesquisa Usuários"
                .CarregaTela()
                If .DS.Tables(0).Rows.Count > 0 Then
                    .ShowDialog()
                    If (.DialogResult = Windows.Forms.DialogResult.OK) Then
                        MyBase.chave = Conversao.ToString(.ID)
                        Me.iIDUsuario = MyBase.chave
                        frmUsuario_carregaDados(MyBase.chave)
                        MyBase.alteraModopadrao(eModo.eAguardando)
                    End If
                Else
                    MsgBox("Registro não encontrado", MsgBoxStyle.Exclamation, Me.Text)
                    Exit Sub
                End If
            End With
        Catch ex As Exception
            MsgBox("Erro: " & ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try

    End Sub

    Private Sub cmdSelecionarGrupoAcesso_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelecionarGrupoAcesso.Click
        Try
            Dim sSql As String
            Dim frmDialogo As New frmPesquisa

            sSql = Me.objGrupoAcesso.sqlConsulta

            With frmDialogo
                .Sql = sSql
                .Titulo = "Pesquisa Grupo de Acesso"
                .CarregaTela()
                If .DS.Tables(0).Rows.Count > 0 Then
                    .ShowDialog()
                    If (.DialogResult = Windows.Forms.DialogResult.OK) Then
                        Me.iIDGrupoAcesso = Conversao.ToString(.ID)
                        Me.txtGrupoAcesso.Text = Conversao.ToString(Me.objGrupoAcesso.selecionarCampo(Me.iIDGrupoAcesso, "Descricao"))
                    End If
                Else
                    MsgBox("Registro não encontrado", MsgBoxStyle.Exclamation, Me.Text)
                    Exit Sub
                End If
            End With
        Catch ex As Exception
            MsgBox("Erro: " & ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

#End Region

End Class