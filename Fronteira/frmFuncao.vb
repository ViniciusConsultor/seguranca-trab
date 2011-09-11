Imports Persistencia
Public Class frmFuncao

#Region "Variáveis"

    Private iPrvIDFuncao As Integer
    Private sPrvTreinamentos As String = ""
    Private dtbPrvTreinamentos As New DataTable
    Private sPrvEPI As String = ""
    Private dtbPrvEPI As New DataTable

    Private objEpi As New Controle.ctrEPI
    Private objFuncao As New Controle.ctrFuncao
    Private objTreinamento As New Controle.ctrTreinamento

    Private prvILinhaDataSet As Integer

#End Region

#Region "Métodos"
    Private Sub Formatar_dgvEPI()
        Try

            Me.dtbPrvEPI = Nothing

            With Me.dgvEPI
                .DataSource = Nothing

                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                .AutoGenerateColumns = False
                .AllowUserToAddRows = False
                .RowHeadersVisible = False
                .Columns.Clear()
                .Rows.Clear()

                Dim Col1 As New DataGridViewTextBoxColumn()
                Col1.HeaderText = "IDEPI"
                Col1.DataPropertyName = "IDEPI"
                Col1.Width = 80
                Col1.Frozen = False
                Col1.ReadOnly = True
                Col1.FillWeight = 100
                Col1.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                Col1.SortMode = DataGridViewColumnSortMode.Automatic
                Col1.Visible = False
                Col1.ValueType = System.Type.GetType("System.Int32")
                .Columns.Add(Col1)

                Dim Col2 As New DataGridViewTextBoxColumn()
                Col2.HeaderText = "EPI"
                Col2.DataPropertyName = "Descricao"
                Col2.Width = 320
                Col2.Frozen = False
                Col2.ReadOnly = True
                Col2.FillWeight = 100
                Col2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                Col2.SortMode = DataGridViewColumnSortMode.Automatic
                Col2.Visible = True
                Col2.ValueType = System.Type.GetType("System.String")
                .Columns.Add(Col2)

                .Refresh()

            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try

    End Sub
    Private Sub Formatar_dgvTreinamentos()
        Try

            Me.dtbPrvTreinamentos = Nothing

            With Me.dgvTreinamentos
                .DataSource = Nothing

                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                .AutoGenerateColumns = False
                .AllowUserToAddRows = False
                .RowHeadersVisible = False
                .Columns.Clear()
                .Rows.Clear()

                Dim Col1 As New DataGridViewTextBoxColumn()
                Col1.HeaderText = "IDTreinamento"
                Col1.DataPropertyName = "IDTreinamento"
                Col1.Width = 80
                Col1.Frozen = False
                Col1.ReadOnly = True
                Col1.FillWeight = 100
                Col1.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                Col1.SortMode = DataGridViewColumnSortMode.Automatic
                Col1.Visible = False
                Col1.ValueType = System.Type.GetType("System.Int32")
                .Columns.Add(Col1)

                Dim Col2 As New DataGridViewTextBoxColumn()
                Col2.HeaderText = "Treinamento"
                Col2.DataPropertyName = "Descricao"
                Col2.Width = 320
                Col2.Frozen = False
                Col2.ReadOnly = True
                Col2.FillWeight = 100
                Col2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                Col2.SortMode = DataGridViewColumnSortMode.Automatic
                Col2.Visible = True
                Col2.ValueType = System.Type.GetType("System.String")
                .Columns.Add(Col2)

                .Refresh()

            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try

    End Sub

    Private Sub Atualizar_Treinamentos_Selecionados()
        Dim cont As Integer

        Me.sPrvTreinamentos = String.Empty

        For cont = 0 To dtbPrvTreinamentos.Rows.Count - 1
            If (Me.sPrvTreinamentos <> String.Empty) Then
                Me.sPrvTreinamentos &= ","
            End If
            Me.sPrvTreinamentos &= dtbPrvTreinamentos.Rows(cont).Item("IDTreinamento")
        Next

    End Sub
    Private Sub Atualizar_EPI_Selecionados()
        Dim cont As Integer

        Me.sPrvEPI = String.Empty

        For cont = 0 To dtbPrvEPI.Rows.Count - 1
            If (Me.sPrvEPI <> String.Empty) Then
                Me.sPrvEPI &= ","
            End If
            Me.sPrvEPI &= dtbPrvEPI.Rows(cont).Item("IDEPI")
        Next

    End Sub
    Private Sub frmFuncao_Altera_Modo(ByVal eModoatual As DSFronteiraPadrao.frmPadrao.eModo) Handles Me.alteraModo

        If (eModoatual = eModo.eAguardando) Then
            Me.fraPrincipal.Enabled = False
            cmdSelecionarFuncao.Enabled = True

            Me.cmdAdicionarTreinamento.Enabled = False
            Me.cmdExcluirTreinamento.Enabled = False

            Me.cmdAdicionarEPI.Enabled = False
            Me.cmdExcluirEPI.Enabled = False

        Else
            Me.fraPrincipal.Enabled = True
            cmdSelecionarFuncao.Enabled = False

            Me.cmdAdicionarTreinamento.Enabled = True
            Me.cmdExcluirTreinamento.Enabled = True

            Me.cmdAdicionarEPI.Enabled = True
            Me.cmdExcluirEPI.Enabled = True
        End If

    End Sub

    Private Sub frmFuncao_Carrega_Dados() Handles Me.carregaDados
        Dim DsFuncao As New DataSet

        Try
            If (Me.iPrvIDFuncao > 0) Then
                DsFuncao = objFuncao.Selecionar(iPrvIDFuncao)

                If (DsFuncao.Tables(0).Rows.Count > 0) Then
                    With DsFuncao.Tables(0).Rows(0)
                        txtDescricao.Text = Conversao.nuloParaVazio(.Item("Descricao"))
                    End With
                End If

                dtbPrvTreinamentos = objFuncao.Retornar_Funcao_Treinamento(iPrvIDFuncao)
                Me.Preenche_Treinamentos()

                dtbPrvEPI = objFuncao.Retornar_Funcao_EPI(iPrvIDFuncao)
                Me.Preenche_EPI()

            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try

    End Sub
    Private Sub Preenche_EPI()
        Try
            dgvEPI.DataSource = Nothing
            If (Me.dtbPrvEPI Is Nothing) Then
                If (Me.sPrvEPI <> String.Empty) Then
                    dtbPrvEPI = objEpi.Selecionar_EPI(0, Me.sPrvEPI, Globais.iIDEmpresa)
                Else
                    dtbPrvEPI = objEpi.Selecionar_EPI(0, "-1", Globais.iIDEmpresa)
                End If
            End If

            dgvEPI.DataSource = dtbPrvEPI

            Me.Atualizar_EPI_Selecionados()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try

    End Sub
    Private Sub Preenche_Treinamentos()

        Try
            dgvTreinamentos.DataSource = Nothing
            If (Me.dtbPrvTreinamentos Is Nothing) Then
                If (Me.sPrvTreinamentos <> String.Empty) Then
                    dtbPrvTreinamentos = objTreinamento.selecionar(0, Me.sPrvTreinamentos, Globais.iIDEmpresa).Tables(0)
                Else
                    dtbPrvTreinamentos = objTreinamento.selecionar(0, "-1", Globais.iIDEmpresa).Tables(0)
                End If
            End If
            dgvTreinamentos.DataSource = dtbPrvTreinamentos
            Me.Atualizar_Treinamentos_Selecionados()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub frmFuncao_Gravar(ByRef bCancel As Boolean) Handles Me.gravar
        Dim bRetorno As Boolean

        Try
            bCancel = True
            bRetorno = objFuncao.Salvar(iPrvIDFuncao, _
                                        Globais.iIDEmpresa, _
                                        txtDescricao.Text.Trim, _
                                        Me.sPrvTreinamentos, _
                                        Me.sPrvEPI)

            If (bRetorno) Then
                bCancel = False
                Me.iPrvIDFuncao = objFuncao.IDFuncao
                MyBase.chave = Me.iPrvIDFuncao
            Else
                MyBase.Mensagens = objFuncao.retornaMensagensValidacao
            End If

        Catch ex As Exception

            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)

        End Try

    End Sub

    Private Sub frmFuncao_Excluir(ByRef bCancel As Boolean) Handles Me.excluir

        Try
            bCancel = True
            If MsgBox("Deseja excluir o registro atual?", MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.Yes Then
                If Not Me.objFuncao.Excluir(Me.iPrvIDFuncao, _
                                            Me.sPrvTreinamentos, _
                                            Me.sPrvEPI) Then
                    MsgBox("Exclusão cancelada. Existem registros vinculados a função que impedem sua exclusão.", MsgBoxStyle.Critical, Me.Text)
                Else
                    bCancel = False
                    MyBase.chave = 0
                    Me.iPrvIDFuncao = 0
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub frmFuncao_setarProvedorDeErros() Handles Me.setarProvedorDeErros

        Dim iContadorMensagens As Int32
        Dim sMensagem As String

        For iContadorMensagens = 0 To MyBase.Mensagens(DSFronteiraPadrao.frmPadrao.eMensagem.Codigo).Count - 1

            sMensagem = MyBase.Mensagens(DSFronteiraPadrao.frmPadrao.eMensagem.Mensagem).item(iContadorMensagens)

            Select Case MyBase.Mensagens(DSFronteiraPadrao.frmPadrao.eMensagem.Codigo).item(iContadorMensagens)
                Case Controle.ctrFuncao.eMensagens.DESCRICAO
                    Me.epPadrao.SetError(Me.txtDescricao, sMensagem)
            End Select

        Next

    End Sub

    Private Sub frmFuncao_limparProvedorDeErros() Handles Me.limpaProvedorDeErros

        Me.epPadrao.SetError(Me.txtDescricao, String.Empty)

    End Sub

    Private Sub frmFuncao_limpaCampo() Handles Me.limpaCampo

        MyBase.limpaCampos(Me)
        Me.sPrvTreinamentos = String.Empty
        Me.dtbPrvTreinamentos = Nothing

        Me.sPrvEPI = String.Empty
        Me.dtbPrvEPI = Nothing
        Me.Formatar_dgvTreinamentos()
        Me.Formatar_dgvEPI()

    End Sub

    Private Sub frmFuncao_inserir(ByRef bCancel As Boolean) Handles Me.inserir
        Me.iPrvIDFuncao = 0
        Me.Formatar_dgvTreinamentos()
    End Sub

    Private Sub frmFuncao_alterar(ByRef bCancel As Boolean) Handles Me.alterar
        MyBase.modoAtual = eModo.eAlterando
    End Sub

    Private Sub cmdAdicionarTreinamento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdicionarTreinamento.Click
        Dim frmSelecao As New frmSelecionarItens

        With frmSelecao
            .SqlPesquisa = objTreinamento.sqlConsulta
            .Marcados = sPrvTreinamentos
            .Titulo = "Selecionar Treinamento"
            .Carregar_Tela()
            Me.sPrvTreinamentos = .Marcados
            Me.dtbPrvTreinamentos = Nothing
            Me.Preenche_Treinamentos()
        End With

        frmSelecao = Nothing

    End Sub

    Private Sub frmFuncao_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Formatar_dgvTreinamentos()
    End Sub

    Private Sub cmdSelecionarFuncao_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelecionarFuncao.Click
        Dim sSql As String
        Dim frmDialogo As New frmPesquisa

        sSql = Me.objFuncao.sqlConsulta(0, Globais.iIDEmpresa)

        With frmDialogo
            .Campos = "iIDFuncao,sDescricao"
            .Descricoes = "Código,Função"
            .Larguras = "50,300"
            .Sql = sSql
            .Titulo = "Pesquisa Função"
            .CarregaTela()
            If .DS.Tables(0).Rows.Count > 0 Then
                .ShowDialog()
                If (.DialogResult = Windows.Forms.DialogResult.OK) Then
                    MyBase.chave = Conversao.ToString(.ID)
                    Me.iPrvIDFuncao = MyBase.chave
                    frmFuncao_Carrega_Dados()
                    MyBase.alteraModopadrao(eModo.eAguardando)
                End If
            Else
                MsgBox("Registro não encontrado", MsgBoxStyle.Exclamation, Me.Text)
                Exit Sub
            End If
        End With
    End Sub

    Private Sub cmdExcluirTreinamento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExcluirTreinamento.Click
        Dim Selecionadas As DataGridViewSelectedRowCollection
        Dim iIDTreinamentoExcluido As Integer
        Dim rowSelected() As DataRow

        Try
            If (dgvTreinamentos.SelectedRows.Count > 0) Then
                Selecionadas = dgvTreinamentos.SelectedRows
                For cont = 0 To dgvTreinamentos.SelectedRows.Count - 1
                    iIDTreinamentoExcluido = Selecionadas.Item(cont).Cells(0).Value
                    rowSelected = dtbPrvTreinamentos.Select("IDTreinamento=" & iIDTreinamentoExcluido)
                    dtbPrvTreinamentos.Rows.Remove(rowSelected(0))
                Next

                Me.Preenche_Treinamentos()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try

    End Sub

    Private Sub dgvTreinamentos_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvTreinamentos.CellClick
        Me.prvILinhaDataSet = 0

        For Each drdados As DataRow In Me.dtbPrvTreinamentos.Rows
            If Conversao.ToInt32(drdados.Item("IDTreinamento")) <> Conversao.ToInt32(Me.dgvTreinamentos.Item(0, e.RowIndex).Value) Then
                Me.prvILinhaDataSet += 1
            End If
        Next
    End Sub

#End Region

    Private Sub cmdAdicionarEPI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdicionarEPI.Click

        Dim frmSelecao As New frmSelecionarItens

        With frmSelecao
            .SqlPesquisa = objEpi.sqlConsulta(Globais.iIDEmpresa)
            .Marcados = sPrvEPI
            .Titulo = "Selecionar EPI"
            .Carregar_Tela()
            Me.sPrvEPI = .Marcados
            Me.dtbPrvEPI = Nothing
            Me.Preenche_EPI()
        End With

        frmSelecao = Nothing

    End Sub

    Private Sub cmdExcluirEPI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExcluirEPI.Click
        Dim Selecionadas As DataGridViewSelectedRowCollection
        Dim iIDEPIExcluido As Integer
        Dim rowSelected() As DataRow

        Try
            If (dgvEPI.SelectedRows.Count > 0) Then
                Selecionadas = dgvEPI.SelectedRows
                For cont = 0 To dgvEPI.SelectedRows.Count - 1
                    iIDEPIExcluido = Selecionadas.Item(cont).Cells(0).Value
                    rowSelected = dtbPrvEPI.Select("IDEPI=" & iIDEPIExcluido)
                    dtbPrvEPI.Rows.Remove(rowSelected(0))
                Next

                Me.Preenche_EPI()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try

    End Sub

End Class