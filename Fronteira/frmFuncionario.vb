Imports Controle
Imports Persistencia
Imports System.IO

Public Class frmFuncionario

#Region "Variáveis"

    Dim iPrvIDFuncao As Integer
    Dim iPrvIDFuncaoAnt As Integer
    Dim iPrvCodCBO As Integer
    Dim iPrvIDFuncionario As Integer

    Dim objCBO As New ctrCBO
    Dim objFuncionario As New ctrFuncionario
    Dim objFuncao As New ctrFuncao
    Private objTreinamentos As New ctrAgendaTreinamento
    Private objEPIs As New ctrEPI
    Private objDocumentos As New ctrDocumento
    Private dsFuncoes As New DataSet
    Private dsTreinamentos As New DataSet
    Private dsEPIs As New DataSet
    Private dsDocumentos As New DataSet

#End Region

#Region "Enumerações"

    Private Enum eFuncoes
        Descricao = 0
        DataInicio = 1
        DataFim = 2
    End Enum

    Private Enum eTreinamentos
        Descricao = 0
        Data = 1
        CargaHoraria = 2
        Ministrante = 3
    End Enum

    Private Enum eEPI
        CA = 0
        Descricao = 1
        DataEntrega = 2
        DataDevolucao = 3
        Status = 4
    End Enum

#End Region

#Region "Métodos"

    Private Sub configuraGridEPIs()

        Try
            With Me.dgvEPIs

                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                .AutoGenerateColumns = False
                .AllowUserToAddRows = False
                .RowHeadersVisible = False
                .Columns.Clear()

                Dim Col1 As New DataGridViewTextBoxColumn
                Col1.HeaderText = "CA"
                Col1.Width = 70
                Col1.Frozen = True
                Col1.ReadOnly = True
                Col1.FillWeight = 100
                Col1.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                Col1.SortMode = DataGridViewColumnSortMode.NotSortable
                Col1.Visible = True
                Col1.ValueType = System.Type.GetType("System.String")
                .Columns.Add(Col1)

                Dim Col2 As New DataGridViewTextBoxColumn()
                Col2.HeaderText = "Descrição"
                Col2.Width = 150
                Col2.Frozen = True
                Col2.ReadOnly = True
                Col2.FillWeight = 100
                Col2.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                Col2.SortMode = DataGridViewColumnSortMode.Automatic
                Col2.Visible = True
                Col2.ValueType = System.Type.GetType("System.String")
                .Columns.Add(Col2)

                Dim Col3 As New DataGridViewTextBoxColumn()
                Col3.HeaderText = "Data Entrega"
                Col3.Width = 100
                Col3.Frozen = True
                Col3.ReadOnly = True
                Col3.FillWeight = 100
                Col3.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                Col3.SortMode = DataGridViewColumnSortMode.Automatic
                Col3.Visible = True
                Col3.ValueType = System.Type.GetType("System.DateTime")
                .Columns.Add(Col3)

                Dim Col4 As New DataGridViewTextBoxColumn()
                Col4.HeaderText = "Data Devolução"
                Col4.Width = 110
                Col4.Frozen = True
                Col4.ReadOnly = True
                Col4.FillWeight = 100
                Col4.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                Col4.SortMode = DataGridViewColumnSortMode.Automatic
                Col4.Visible = True
                Col4.ValueType = System.Type.GetType("System.DateTime")
                .Columns.Add(Col4)


                Dim Col5 As New DataGridViewCheckBoxColumn()
                Col5.HeaderText = "Inativo"
                Col5.Width = 70
                Col5.Frozen = True
                Col5.ReadOnly = True
                Col5.FillWeight = 100
                Col5.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                Col5.SortMode = DataGridViewColumnSortMode.Automatic
                Col5.Visible = True
                Col5.ValueType = System.Type.GetType("System.Boolean")
                .Columns.Add(Col5)

                .Refresh()

            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try

    End Sub

    Private Sub configuraGridTreinamentos()

        Try
            With Me.dgvTreinamentos

                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                .AutoGenerateColumns = False
                .AllowUserToAddRows = False
                .RowHeadersVisible = False
                .Columns.Clear()

                Dim Col1 As New DataGridViewTextBoxColumn
                Col1.HeaderText = "Descricao"
                Col1.Width = 200
                Col1.Frozen = True
                Col1.ReadOnly = True
                Col1.FillWeight = 100
                Col1.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                Col1.SortMode = DataGridViewColumnSortMode.NotSortable
                Col1.Visible = True
                Col1.ValueType = System.Type.GetType("System.String")
                .Columns.Add(Col1)

                Dim Col2 As New DataGridViewTextBoxColumn()
                Col2.HeaderText = "Data"
                Col2.Width = 100
                Col2.Frozen = True
                Col2.ReadOnly = True
                Col2.FillWeight = 100
                Col2.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                Col2.SortMode = DataGridViewColumnSortMode.Automatic
                Col2.Visible = True
                Col2.ValueType = System.Type.GetType("System.DateTime")
                .Columns.Add(Col2)

                Dim Col3 As New DataGridViewTextBoxColumn()
                Col3.HeaderText = "Carga Horária"
                Col3.Width = 100
                Col3.Frozen = True
                Col3.ReadOnly = True
                Col3.FillWeight = 100
                Col3.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                Col3.SortMode = DataGridViewColumnSortMode.Automatic
                Col3.Visible = True
                Col3.ValueType = System.Type.GetType("System.String")
                .Columns.Add(Col3)

                Dim Col4 As New DataGridViewTextBoxColumn()
                Col4.HeaderText = "Ministrante"
                Col4.Width = 100
                Col4.Frozen = True
                Col4.ReadOnly = True
                Col4.FillWeight = 100
                Col4.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                Col4.SortMode = DataGridViewColumnSortMode.Automatic
                Col4.Visible = True
                Col4.ValueType = System.Type.GetType("System.String")
                .Columns.Add(Col4)

                .Refresh()

            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try

    End Sub

    Private Sub configuraGridFuncoes()

        Try
            With Me.dgvFuncoes

                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                .AutoGenerateColumns = False
                .AllowUserToAddRows = False
                .RowHeadersVisible = False
                .Columns.Clear()

                Dim Col1 As New DataGridViewTextBoxColumn
                Col1.HeaderText = "Cargo"
                Col1.Width = 300
                Col1.Frozen = True
                Col1.ReadOnly = True
                Col1.FillWeight = 100
                Col1.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                Col1.SortMode = DataGridViewColumnSortMode.NotSortable
                Col1.Visible = True
                Col1.ValueType = System.Type.GetType("System.String")
                .Columns.Add(Col1)

                Dim Col2 As New DataGridViewTextBoxColumn()
                Col2.HeaderText = "Data início"
                Col2.Width = 100
                Col2.Frozen = True
                Col2.ReadOnly = True
                Col2.FillWeight = 100
                Col2.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                Col2.SortMode = DataGridViewColumnSortMode.Automatic
                Col2.Visible = True
                Col2.ValueType = System.Type.GetType("System.DateTime")
                .Columns.Add(Col2)

                Dim Col3 As New DataGridViewTextBoxColumn()
                Col3.HeaderText = "Data fim"
                Col3.Width = 100
                Col3.Frozen = True
                Col3.ReadOnly = True
                Col3.FillWeight = 100
                Col3.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                Col3.SortMode = DataGridViewColumnSortMode.Automatic
                Col3.Visible = True
                Col3.ValueType = System.Type.GetType("System.DateTime")
                .Columns.Add(Col3)

                .Refresh()

            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try

    End Sub

    Private Sub Altera_Modo(ByVal eModoAtual As DSFronteiraPadrao.frmPadrao.eModo) Handles Me.alteraModo
        If (eModoAtual = eModo.eAguardando) Then
            Me.fraPrincipal.Enabled = False
            Me.cmdAdicionarDocumentos.Enabled = False
            Me.cmdExcluirDocumento.Enabled = False
        Else
            Me.fraPrincipal.Enabled = True
            Me.fraDocumentos.Enabled = True
            Me.cmdAdicionarDocumentos.Enabled = True
            Me.cmdExcluirDocumento.Enabled = (Me.dsDocumentos.Tables(0).Rows.Count > 0)
        End If

        Me.cmdSelecionarFuncionario.Enabled = Not Me.fraPrincipal.Enabled
        Me.cmdSelecionarTodos.Enabled = (Me.dsDocumentos.Tables(0).Rows.Count > 0)
        Me.cmdExportarSelecionados.Enabled = (Me.dsDocumentos.Tables(0).Rows.Count > 0)
        Me.dgvDocumentos.Enabled = (Me.dsDocumentos.Tables(0).Rows.Count > 0)

    End Sub

    Private Sub frmFuncionario_CarregaDados() Handles Me.carregaDados
        Dim objDtAccess As New Persistencia.AcessoBd
        Dim dsFuncionario As New DataSet
        Dim Data_Servidor As Date
        Dim dtImportacao As Date

        If iPrvIDFuncionario > 0 Then
            Try
                Data_Servidor = objDtAccess.Data_Servidor
                dsFuncionario = Me.objFuncionario.selecionar(iPrvIDFuncionario)

                Me.dsFuncoes = Me.objFuncao.selecionarFuncoesFuncionario(iPrvIDFuncionario)
                Me.preencherGridFuncoes()

                Me.dsTreinamentos = Me.objTreinamentos.selecionarTreinamentosFuncionario(iPrvIDFuncionario)
                Me.preencherGridTreinamentos()

                Me.dsEPIs = Me.objEPIs.selecionarEPIsFuncionario(iPrvIDFuncionario)
                Me.preencherGridEPIs()

                If dsFuncionario.Tables(0).Rows.Count > 0 Then
                    With dsFuncionario.Tables(0).Rows(0)
                        Me.txtNome.Text = Persistencia.Conversao.ToString(.Item("Nome"))
                        Me.txtCpf.Text = Persistencia.Conversao.ToString(.Item("CPF"))
                        Me.txtRG.Text = Persistencia.Conversao.ToString(.Item("RG"))
                        Me.txtOrgao.Text = Persistencia.Conversao.ToString(.Item("OrgaoEmissor"))
                        If (IsDBNull(.Item("DataEmissao"))) Then
                            Me.txtDataEmissao.Checked = False
                        Else
                            Me.txtDataEmissao.Text = Persistencia.Conversao.ToDateTime(.Item("DataEmissao"))
                        End If
                        Me.txtCTPS.Text = Persistencia.Conversao.ToString(.Item("CTPS"))
                        Me.txtNascimento.Text = Persistencia.Conversao.ToString(.Item("dtNascimento"))
                        If (Not Persistencia.Conversao.nuloParaBoleano(.Item("sexo"))) Then
                            optFeminino.Checked = True
                        Else
                            optMasculino.Checked = True
                        End If
                        Me.txtLogradouro.Text = Persistencia.Conversao.ToString(.Item("Rua"))
                        Me.txtNumero.Text = Persistencia.Conversao.nuloParaVazio(.Item("Numero"))
                        Me.txtComplemento.Text = Persistencia.Conversao.ToString(.Item("Complemento"))
                        Me.txtBairro.Text = Persistencia.Conversao.ToString(.Item("Bairro"))
                        Me.txtCidade.Text = Persistencia.Conversao.ToString(.Item("Cidade"))
                        Me.txtCep.Text = Persistencia.Conversao.ToString(.Item("CEP"))
                        If Persistencia.Conversao.ToString(.Item("Estado")) <> String.Empty Then
                            Me.cboEstado.SelectedIndex = Persistencia.Conversao.ToInt32(.Item("Estado"))
                        End If

                        Me.txtTelefone.Text = Persistencia.Conversao.ToString(.Item("Telefone"))
                        Me.txtCelular.Text = Persistencia.Conversao.ToString(.Item("Celular"))
                        Me.txtEmail.Text = Persistencia.Conversao.ToString(.Item("Email"))

                        'Dados da empresa
                        Me.txtRegistro.Text = Persistencia.Conversao.ToString(.Item("Registro"))
                        If (IsDBNull(.Item("Admissao"))) Then
                            Me.txtAdmissao.Checked = False
                        Else
                            Me.txtAdmissao.Text = Persistencia.Conversao.ToDateTime(.Item("Admissao"))
                        End If

                        If (IsDBNull(.Item("Rescisao"))) Then
                            Me.txtRescisao.Checked = False
                        Else
                            Me.txtRescisao.Text = Persistencia.Conversao.ToDateTime(.Item("Rescisao"))
                        End If

                        If (Persistencia.Conversao.nuloParaZero(.Item("IDCBO")) > 0) Then

                        End If
                        iPrvIDFuncao = objFuncionario.Retorna_Funcao_Vigente(iPrvIDFuncionario)
                        iPrvIDFuncaoAnt = iPrvIDFuncao
                        If (iPrvIDFuncao > 0) Then
                            Me.txtFuncao.Text = Persistencia.Conversao.nuloParaVazio( _
                                                objFuncao.Selecionar(iPrvIDFuncao).Tables(0).Rows(0).Item("Descricao"))
                        End If
                        dtImportacao = Conversao.nuloParaData(.Item("DataImportacao"))
                        If (dtImportacao <> Date.MinValue) Then
                            lblRegImportado.Visible = True
                        Else
                            lblRegImportado.Visible = False
                        End If

                    End With

                    'Carrega o grid de documentos
                    Me.dsDocumentos = Me.objDocumentos.selecionarDocumento(iPrvIDFuncionario, Globais.eTipoArquivo.Funcionário)
                    Me.preencheGridDocumentos()

                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
            End Try

        End If

    End Sub

    Private Sub frmFuncionario_Inserir() Handles Me.inserir
        Me.txtAdmissao.Checked = False
        Me.txtRescisao.Checked = False
        Me.iPrvIDFuncionario = 0
        Me.iPrvIDFuncao = 0
        Me.iPrvIDFuncaoAnt = 0
    End Sub

    Private Sub frmFuncionario_alterar(ByRef bCancel As Boolean) Handles Me.alterar
        MyBase.modoAtual = eModo.eAlterando
    End Sub

    Private Sub frmFuncionario_Gravar(ByRef bCancel As Boolean) Handles Me.gravar
        Dim bRetorno As Boolean
        Dim iSexo As Integer = -1
        Dim dtNascimento As Date
        Dim dtAdmissao As Date = Date.MinValue
        Dim dtRescisao As Date = Date.MinValue
        Dim dtEmissao As Date = Date.MinValue

        Try
            bCancel = True

            dtNascimento = txtNascimento.Text

            dtAdmissao = txtAdmissao.Text

            If (txtDataEmissao.Checked) Then
                dtEmissao = txtDataEmissao.Text
            End If

            If (txtRescisao.Checked) Then
                dtRescisao = txtRescisao.Text
            End If

            If (optFeminino.Checked) Then
                iSexo = 0
            ElseIf (optMasculino.Checked) Then
                iSexo = 1
            End If

            bRetorno = objFuncionario.Salvar(iPrvIDFuncionario, _
                                             Persistencia.Globais.iIDEmpresa, _
                                             txtNome.Text.Trim, _
                                             txtCpf.Text.Trim, _
                                             txtRG.Text.Trim, _
                                             dtNascimento, _
                                             iSexo, _
                                             txtLogradouro.Text.Trim, _
                                             Val(txtNumero.Text), _
                                             txtComplemento.Text.Trim, _
                                             txtBairro.Text.Trim, _
                                             txtCidade.Text.Trim, _
                                             IIf(Me.cboEstado.SelectedIndex > -1, Me.cboEstado.SelectedIndex, -1), _
                                             txtCep.Text.Trim, _
                                             txtEmail.Text.Trim, _
                                             txtTelefone.Text.Trim, _
                                             txtCelular.Text.Trim, _
                                             txtRegistro.Text.Trim, _
                                             dtAdmissao, _
                                             dtRescisao, _
                                             iPrvCodCBO, _
                                             iPrvIDFuncaoAnt, _
                                             iPrvIDFuncao, _
                                             txtOrgao.Text, _
                                             dtEmissao, _
                                             txtCTPS.Text, _
                                             Me.dsDocumentos)

            If (bRetorno) Then
                bCancel = False
                Me.iPrvIDFuncionario = objFuncionario.IDFuncionario
                MyBase.chave = Me.iPrvIDFuncionario
            Else
                MyBase.Mensagens = objFuncionario.retornaMensagensValidacao
            End If

        Catch ex As Exception

            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)

        End Try

    End Sub

    Private Sub frmFuncionario_Excluir(ByRef bCancel As Boolean) Handles Me.excluir

        Try
            bCancel = True
            If MsgBox("Deseja excluir o registro atual?", MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.Yes Then
                If Not Me.objFuncionario.Excluir(Me.iPrvIDFuncionario) Then
                    MsgBox("Exclusão cancelada. Existem registros vinculados ao funcionário que impedem sua exclusão.", MsgBoxStyle.Critical, Me.Text)
                Else
                    bCancel = False
                    MyBase.chave = 0
                    Me.iPrvIDFuncionario = 0
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub frmFuncionario_limparCampos() Handles Me.limpaCampo
        MyBase.limpaCampos(Me)

        txtCep.Clear()
        txtNascimento.Text = Date.Now
        txtAdmissao.Text = Date.Now
        txtDataEmissao.Text = Date.Now
        txtDataEmissao.Checked = False

    End Sub

    Private Sub preencherGridEPIs()

        Dim iLinha As Integer

        Try

            Me.configuraGridEPIs()

            If Me.dsEPIs.Tables(0).Rows.Count > 0 Then

                iLinha = 0

                With Me.dgvEPIs
                    .Rows.Clear()
                    .RowCount = Me.dsEPIs.Tables(0).Rows.Count

                    For Each drDados As DataRow In Me.dsEPIs.Tables(0).Rows
                        .Item(eEPI.Descricao, iLinha).Value = Conversao.ToString(drDados.Item("Descricao"))
                        .Item(eEPI.CA, iLinha).Value = Conversao.ToString(drDados.Item("CA"))
                        .Item(eEPI.DataEntrega, iLinha).Value = Conversao.ToDateTime(drDados.Item("DataEntrega")).ToString("dd/MM/yyyy")
                        If Conversao.ToDateTime(drDados.Item("Devolucao")) <> Nothing Then
                            .Item(eEPI.DataDevolucao, iLinha).Value = Conversao.ToDateTime(drDados.Item("Devolucao")).ToString("dd/MM/yyyy")
                        End If
                        If Conversao.ToString(drDados.Item("Inativo")) <> String.Empty Then
                            .Item(eEPI.Status, iLinha).Value = True
                        End If
                        iLinha += 1
                    Next

                End With

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try

    End Sub

    Private Sub preencherGridFuncoes()

        Dim iLinha As Integer

        Try

            Me.configuraGridFuncoes()

            If Me.dsFuncoes.Tables(0).Rows.Count > 0 Then

                iLinha = 0

                With Me.dgvFuncoes
                    .Rows.Clear()
                    .RowCount = Me.dsFuncoes.Tables(0).Rows.Count

                    For Each drDados As DataRow In Me.dsFuncoes.Tables(0).Rows
                        .Item(eFuncoes.Descricao, iLinha).Value = Conversao.ToString(drDados.Item("Descricao"))
                        .Item(eFuncoes.DataInicio, iLinha).Value = Conversao.ToDateTime(drDados.Item("DataInicio")).ToString("dd/MM/yyyy")
                        If Conversao.nuloParaData(drDados.Item("DataFim")) <> Nothing Then
                            .Item(eFuncoes.DataFim, iLinha).Value = Conversao.ToDateTime(drDados.Item("DataFim")).ToString("dd/MM/yyyy")
                        End If

                        iLinha += 1
                    Next

                End With

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try

    End Sub

    Private Sub preencherGridTreinamentos()

        Dim iLinha As Integer

        Try

            Me.configuraGridTreinamentos()

            If Me.dsTreinamentos.Tables(0).Rows.Count > 0 Then

                iLinha = 0

                With Me.dgvTreinamentos
                    .Rows.Clear()
                    .RowCount = Me.dsTreinamentos.Tables(0).Rows.Count

                    For Each drDados As DataRow In Me.dsTreinamentos.Tables(0).Rows
                        .Item(eTreinamentos.Descricao, iLinha).Value = Conversao.ToString(drDados.Item("Descricao"))
                        .Item(eTreinamentos.Data, iLinha).Value = Conversao.ToDateTime(drDados.Item("Data")).ToString("dd/MM/yyyy")
                        .Item(eTreinamentos.CargaHoraria, iLinha).Value = Conversao.ToString(drDados.Item("CargaHoraria"))
                        .Item(eTreinamentos.Ministrante, iLinha).Value = Conversao.ToString(drDados.Item("Ministrante"))
                        iLinha += 1
                    Next

                End With

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try

    End Sub

    Private Sub configuraGrids()
        Me.configuraGridFuncoes()
        Me.configuraGridEPIs()
        Me.configuraGridTreinamentos()
        Me.configuraGridDocumentos()
    End Sub

    Private Sub limparGrids()
        Me.dsFuncoes = Nothing
        Me.dsFuncoes = Nothing
        Me.dsTreinamentos = Nothing
        Me.dsDocumentos = Me.objDocumentos.selecionarDocumento(0, Globais.eTipoArquivo.Funcionário)
    End Sub

    Private Sub frmFuncionario_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.cboEstado.Items.AddRange(Persistencia.Globais.sEstados)
        Me.dsFuncoes = Me.objFuncao.selecionarFuncoesFuncionario(0)
        Me.dsEPIs = Me.objEPIs.selecionarEPIsFuncionario(0)
        Me.dsTreinamentos = Me.objTreinamentos.selecionarTreinamentosFuncionario(0)
        Me.dsDocumentos = Me.objDocumentos.selecionarDocumento(0, Globais.eTipoArquivo.Funcionário)
        Me.configuraGrids()
    End Sub

    Private Sub cmdSelecionarFuncao_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelecionarFuncao.Click
        Dim frmDialogo As New frmPesquisa

        Try

            With frmDialogo
                .Sql = objFuncao.sqlConsulta(0, Persistencia.Globais.iIDEmpresa)
                .Titulo = "Pesquisa Função"
                .CarregaTela()
                If (.DS.Tables(0).Rows.Count > 0) Then
                    .ShowDialog()
                    If (.DialogResult = Windows.Forms.DialogResult.OK) Then
                        Me.iPrvIDFuncao = .ID
                        Me.txtFuncao.Text = Persistencia.Conversao.nuloParaVazio( _
                                            objFuncao.Selecionar(Me.iPrvIDFuncao).Tables(0).Rows(0).Item("Descricao"))

                        MyBase.alteraModopadrao(eModo.eAlterando)
                    End If
                Else
                    MsgBox("Registro não encontrado", MsgBoxStyle.Exclamation, Me.Text)
                    Exit Sub
                End If
            End With

        Catch ex As Exception

            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)

        End Try

    End Sub

    Private Sub frmFuncionario_setarProvedorDeErros() Handles Me.setarProvedorDeErros

        Dim iContadorMensagens As Int32
        Dim sMensagem As String

        For iContadorMensagens = 0 To MyBase.Mensagens(DSFronteiraPadrao.frmPadrao.eMensagem.Codigo).Count - 1

            sMensagem = MyBase.Mensagens(DSFronteiraPadrao.frmPadrao.eMensagem.Mensagem).item(iContadorMensagens)

            Select Case MyBase.Mensagens(DSFronteiraPadrao.frmPadrao.eMensagem.Codigo).item(iContadorMensagens)
                Case ctrFuncionario.eMensagens.NOME
                    Me.epPadrao.SetError(Me.cmdSelecionarFuncionario, sMensagem)
                Case ctrFuncionario.eMensagens.IDFUNCAO
                    Me.epPadrao.SetError(Me.cmdLimparFuncao, sMensagem)
                Case ctrFuncionario.eMensagens.DATA_NASCIMENTO
                    Me.epPadrao.SetError(Me.txtNascimento, sMensagem)
                Case ctrFuncionario.eMensagens.SEXO
                    Me.epPadrao.SetError(Me.optFeminino, sMensagem)
                Case ctrFuncionario.eMensagens.DATA_ADMISSAO_INVALIDA
                    Me.epPadrao.SetError(Me.txtAdmissao, sMensagem)
                Case ctrFuncionario.eMensagens.CPF
                    Me.epPadrao.SetError(Me.txtCpf, sMensagem)
                Case ctrFuncionario.eMensagens.CTPS
                    Me.epPadrao.SetError(txtCTPS, sMensagem)
            End Select

        Next

    End Sub

    Private Sub frmFuncionario_limparProvedorDeErros() Handles Me.limpaProvedorDeErros

        Me.epPadrao.Clear()
        'Me.epPadrao.SetError(Me.cmdSelecionarFuncionario, String.Empty)
        'Me.epPadrao.SetError(Me.cmdLimparFuncao, String.Empty)
        'Me.epPadrao.SetError(Me.txtNascimento, String.Empty)
        'Me.epPadrao.SetError(Me.optFeminino, String.Empty)

    End Sub

    Private Sub frmFuncionario_LimpaCampo() Handles Me.limpaCampo
        MyBase.limpaCampos(Me)
        txtTelefone.Clear()
        txtCpf.Clear()
        txtCep.Clear()
        txtCelular.Clear()
        Me.limparGrids()
        Me.configuraGrids()
    End Sub

    Private Sub cmdSelecionarFuncionario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelecionarFuncionario.Click
        Dim frmDialogo As New frmPesquisa

        Try

            With frmDialogo
                .Sql = objFuncionario.sqlConsulta(0, Persistencia.Globais.iIDEmpresa)
                .Campos = "iIDFuncionario,sNome"
                .Descricoes = "Código,Nome"
                .Larguras = "50,300"
                .Titulo = "Pesquisa Funcionário"
                .CarregaTela()
                If (.DS.Tables(0).Rows.Count > 0) Then
                    .ShowDialog()
                    If (.DialogResult = Windows.Forms.DialogResult.OK) Then
                        MyBase.chave = Persistencia.Conversao.ToString(.ID)
                        Me.iPrvIDFuncionario = MyBase.chave
                        frmFuncionario_CarregaDados()
                        MyBase.alteraModopadrao(eModo.eAguardando)
                        Altera_Modo(eModo.eAguardando)
                    End If
                Else
                    MsgBox("Registro não encontrado", MsgBoxStyle.Exclamation, Me.Text)
                    Exit Sub
                End If
            End With

        Catch ex As Exception

            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)

        End Try

    End Sub

#End Region

    Private Sub cmdSelecionarCBO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frmDialogo As New frmPesquisa

        Try

            With frmDialogo
                .Sql = objCBO.sqlConsulta()
                .Titulo = "Pesquisa CBO"
                .CarregaTela()
                If (.DS.Tables(0).Rows.Count > 0) Then
                    .ShowDialog()
                    If (.DialogResult = Windows.Forms.DialogResult.OK) Then
                        Me.iPrvCodCBO = .ID

                        MyBase.alteraModopadrao(eModo.eAlterando)
                    End If
                Else
                    MsgBox("Registro não encontrado", MsgBoxStyle.Exclamation, Me.Text)
                    Exit Sub
                End If
            End With

        Catch ex As Exception

            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)

        End Try

    End Sub

    Private Sub cmdLimparFuncao_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLimparFuncao.Click
        Me.iPrvIDFuncao = 0
        Me.txtFuncao.Text = String.Empty
    End Sub

    Private Sub txtNome_Enter(ByVal sender As Object, ByVal e As System.EventArgs)
        txtNome.SelectAll()
    End Sub

    Private Sub txtCPF_Enter(ByVal sender As Object, ByVal e As System.EventArgs)
        txtCpf.SelectAll()
    End Sub

    Private Sub txtRG_Enter(ByVal sender As Object, ByVal e As System.EventArgs)
        txtRG.SelectAll()
    End Sub

    Private Sub txtLogradouro_Enter(ByVal sender As Object, ByVal e As System.EventArgs)
        txtLogradouro.SelectAll()
    End Sub

    Private Sub txtNumero_Enter(ByVal sender As Object, ByVal e As System.EventArgs)
        txtNumero.SelectAll()
    End Sub

    Private Sub txtComplemento_Enter(ByVal sender As Object, ByVal e As System.EventArgs)
        txtComplemento.SelectAll()
    End Sub

    Private Sub txtBairro_Enter(ByVal sender As Object, ByVal e As System.EventArgs)
        txtBairro.SelectAll()
    End Sub

    Private Sub txtCep_Enter(ByVal sender As Object, ByVal e As System.EventArgs)
        txtCep.SelectAll()
    End Sub

    Private Sub txtCidade_Enter(ByVal sender As Object, ByVal e As System.EventArgs)
        txtCidade.SelectAll()
    End Sub

    Private Sub txtEmail_Enter(ByVal sender As Object, ByVal e As System.EventArgs)
        txtEmail.SelectAll()
    End Sub

    Private Sub txttelefone_Enter(ByVal sender As Object, ByVal e As System.EventArgs)
        txtTelefone.SelectAll()
    End Sub

    Private Sub txtCelular_Enter(ByVal sender As Object, ByVal e As System.EventArgs)
        txtCelular.SelectAll()
    End Sub

    Private Sub txtRegistro_Enter(ByVal sender As Object, ByVal e As System.EventArgs)
        txtRegistro.SelectAll()
    End Sub

    Private Sub configuraGridDocumentos()

        Try
            With Me.dgvDocumentos

                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                .AutoGenerateColumns = False
                .AllowUserToAddRows = False
                .RowHeadersVisible = False
                .AllowUserToResizeColumns = False
                .AllowUserToResizeRows = False
                .ScrollBars = ScrollBars.Vertical

                .Columns.Clear()

                Dim Col1 As New DataGridViewCheckBoxColumn
                Col1.HeaderText = ""
                Col1.Name = "Marcar"
                Col1.Width = 30
                Col1.Frozen = True
                Col1.ReadOnly = False
                Col1.FillWeight = 100
                Col1.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                Col1.SortMode = DataGridViewColumnSortMode.NotSortable
                Col1.Visible = True
                Col1.ValueType = System.Type.GetType("System.Boolean")
                .Columns.Add(Col1)

                Dim Col2 As New DataGridViewTextBoxColumn
                Col2.HeaderText = "IDDocumento"
                Col2.Width = 50
                Col2.Frozen = True
                Col2.ReadOnly = True
                Col2.FillWeight = 100
                Col2.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                Col2.SortMode = DataGridViewColumnSortMode.NotSortable
                Col2.Visible = False
                Col2.ValueType = System.Type.GetType("System.Int32")
                .Columns.Add(Col2)

                Dim Col3 As New DataGridViewTextBoxColumn()
                Col3.HeaderText = "Nome"
                Col3.Width = 250
                Col3.Frozen = True
                Col3.ReadOnly = True
                Col3.FillWeight = 100
                Col3.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                Col3.SortMode = DataGridViewColumnSortMode.Automatic
                Col3.Visible = True
                Col3.ValueType = System.Type.GetType("System.String")
                .Columns.Add(Col3)

                Dim Col4 As New DataGridViewTextBoxColumn()
                Col4.HeaderText = "Descrição"
                Col4.Width = 350
                Col4.Frozen = True
                Col4.ReadOnly = True
                Col4.FillWeight = 100
                Col4.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                Col4.SortMode = DataGridViewColumnSortMode.Automatic
                Col4.Visible = True
                Col4.ValueType = System.Type.GetType("System.String")
                .Columns.Add(Col4)

                Dim Col5 As New DataGridViewTextBoxColumn()
                Col5.HeaderText = "Documento"
                Col5.Width = 150
                Col5.Frozen = True
                Col5.ReadOnly = True
                Col5.FillWeight = 100
                Col5.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                Col5.SortMode = DataGridViewColumnSortMode.Automatic
                Col5.Visible = False
                Col5.ValueType = System.Type.GetType("System.Byte()")
                .Columns.Add(Col5)

                .Refresh()

            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try

    End Sub

    Private Sub preencheGridDocumentos()

        Dim iLinha As Integer

        Try

            Me.configuraGridDocumentos()

            If Me.dsDocumentos.Tables(0).Rows.Count > 0 Then

                iLinha = 0

                With Me.dgvDocumentos
                    .Rows.Clear()
                    .RowCount = Me.dsDocumentos.Tables(0).Rows.Count

                    For Each drDados As DataRow In Me.dsDocumentos.Tables(0).Rows

                        .Item(Controle.ctrEmpresa.eGridEmpresa.eMarcar, iLinha).Value = False
                        .Item(Controle.ctrEmpresa.eGridEmpresa.eIdDocumento, iLinha).Value = drDados.Item("IDDocumento")
                        .Item(Controle.ctrEmpresa.eGridEmpresa.eNome, iLinha).Value = drDados.Item("NomeArquivo")
                        .Item(Controle.ctrEmpresa.eGridEmpresa.eDescricao, iLinha).Value = drDados.Item("Descricao")
                        .Item(Controle.ctrEmpresa.eGridEmpresa.eDocumento, iLinha).Value = drDados.Item("Arquivo")

                        iLinha += 1
                    Next

                End With

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try

    End Sub

    Private Sub cmdAdicionarDocumentos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdicionarDocumentos.Click

        Dim frm As New frmDocumento

        frm.Documentos = Me.dsDocumentos
        frm.modoInsercao = True
        frm.ShowDialog()

        Me.dsDocumentos = frm.Documentos
        Me.preencheGridDocumentos()
        Me.cmdExcluirDocumento.Enabled = Me.dsDocumentos.Tables(0).Rows.Count

    End Sub

    Private Sub cmdExcluirDocumento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExcluirDocumento.Click

        For Each SelectedRow As DataGridViewRow In Me.dgvDocumentos.Rows
            If Conversao.ToBoolean(SelectedRow.Cells(Controle.ctrEmpresa.eGridEmpresa.eMarcar).Value) = True Then
                Me.dsDocumentos.Tables(0).Rows(SelectedRow.Cells(Controle.ctrEmpresa.eGridEmpresa.eMarcar).RowIndex).Delete()
            End If
        Next

        Me.dsDocumentos.AcceptChanges()
        Me.preencheGridDocumentos()
    End Sub

    Private Sub dgvDocumentos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDocumentos.DoubleClick

        Dim frm As New frmDocumento

        frm.Index = Me.dgvDocumentos.CurrentRow.Cells(Controle.ctrEmpresa.eGridEmpresa.eIdDocumento.GetHashCode).RowIndex
        frm.Documentos = Me.dsDocumentos
        frm.modoInsercao = False
        frm.ShowDialog()

        Me.dsDocumentos = frm.Documentos
        Me.preencheGridDocumentos()

    End Sub

    Private Sub selecaoGrid(ByVal bMarcar As Boolean)

        For iContador As Integer = 0 To Me.dgvDocumentos.Rows.Count - 1
            Me.dgvDocumentos.Item(Controle.ctrEmpresa.eGridEmpresa.eMarcar, iContador).Value = bMarcar
        Next

    End Sub

    Private Sub cmdSelecionarTodos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelecionarTodos.Click

        If Me.cmdSelecionarTodos.Text = "Selecionar todos" Then
            Me.selecaoGrid(True)
            Me.cmdSelecionarTodos.Text = "Desmarcar todos"
        Else
            Me.selecaoGrid(False)
            Me.cmdSelecionarTodos.Text = "Selecionar todos"
        End If

    End Sub

    Private Sub cmdExportarSelecionados_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExportarSelecionados.Click

        Dim fs As FileStream
        Dim sCaminhoSelecionado As String
        Dim sNomeArquivo As String
        Dim bits As Byte() = {0}
        Dim memorybits As MemoryStream

        Try
            Dim openDlg As FolderBrowserDialog = New FolderBrowserDialog
            openDlg.ShowNewFolderButton = True

            If (openDlg.ShowDialog() = Windows.Forms.DialogResult.OK) Then

                sCaminhoSelecionado = openDlg.SelectedPath

                For Each SelectedRow As DataGridViewRow In Me.dgvDocumentos.Rows
                    If Conversao.ToBoolean(SelectedRow.Cells(Controle.ctrEmpresa.eGridEmpresa.eMarcar).Value) = True Then

                        bits = CType(SelectedRow.Cells(Controle.ctrEmpresa.eGridEmpresa.eDocumento).Value, Byte())
                        sNomeArquivo = SelectedRow.Cells(Controle.ctrEmpresa.eGridEmpresa.eNome).Value
                        memorybits = New MemoryStream(bits)

                        fs = New FileStream(sCaminhoSelecionado & "\" & sNomeArquivo, FileMode.Create, FileAccess.Write)
                        fs.Write(bits, 0, bits.Length)
                        fs.Close()

                    End If
                Next

                MsgBox("Os documentos foram exportados com sucesso.", MsgBoxStyle.Information, Me.Text)

            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try

    End Sub


End Class