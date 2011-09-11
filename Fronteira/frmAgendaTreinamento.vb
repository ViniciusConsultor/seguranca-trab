Imports Persistencia
Public Class frmAgendaTreinamento

#Region "Variáveis "

    Private WithEvents objRelTreinamento As New Relatorio.relTreinamento
    Private objAgendaTreinamento As New Controle.ctrAgendaTreinamento
    Private objTreinamento As New Controle.ctrTreinamento

    Private iPrvValidade As Integer = 0
    Private bPrvResultado As Boolean = False
    Private iPrvAgendamento As Integer
    Private iPrvIdTreinamento As Integer = 0
    Private dsFuncionariosParticipantes As New DataSet
    Private iLinhaDataSet As Integer = 0

    Public Property Resultado() As Boolean
        Get
            Return Me.bPrvResultado
        End Get
        Set(ByVal value As Boolean)
            Me.bPrvResultado = value
        End Set
    End Property

    Public Property iIdAgendamento() As Integer
        Get
            Return Me.iPrvAgendamento
        End Get
        Set(ByVal value As Integer)
            Me.iPrvAgendamento = value
        End Set
    End Property

#End Region

#Region " Enumerações "

    Private Enum eColunasGrid
        Marcar = 0
        IDFuncionario = 1
        Funcionario = 2
    End Enum

#End Region

#Region " Métodos "

    Private Sub configuraGrid()

        Try
            With Me.dgvParticipantes
                .DataSource = Nothing
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                .AutoGenerateColumns = False
                .AllowUserToAddRows = False
                .RowHeadersVisible = False
                .Columns.Clear()

                Dim Col1 As New DataGridViewTextBoxColumn()
                Col1.HeaderText = "Código"
                Col1.DataPropertyName = "IDFuncionario"
                Col1.Width = 80
                Col1.Frozen = False
                Col1.ReadOnly = True
                Col1.FillWeight = 100
                Col1.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                Col1.SortMode = DataGridViewColumnSortMode.Automatic
                Col1.Visible = True
                Col1.ValueType = System.Type.GetType("System.Int32")
                .Columns.Add(Col1)

                Dim Col2 As New DataGridViewTextBoxColumn()
                Col2.HeaderText = "Funcionario"
                Col2.DataPropertyName = "Nome"
                Col2.Width = 240
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
            cmdAdicionarParticipante.Enabled = False
            cmdExcluirParticipante.Enabled = False

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try

    End Sub

    Private Sub preencheGrid()
        Dim datTreinamento As Date
        Try
            datTreinamento = Me.dtpData.Text
            With dgvParticipantes
                .DataSource = Nothing
                .DataSource = dsFuncionariosParticipantes.Tables(0)
            End With

            cmdExcluirParticipante.Enabled = (dgvParticipantes.RowCount > 0)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try

    End Sub

    Private Sub frmAgendaTreinamento_alteraModo(ByVal eModoAtual As DSFronteiraPadrao.frmPadrao.eModo) Handles Me.alteraModo

        If eModoAtual = eModo.eAguardando Then
            Me.fraDados.Enabled = False
            Me.fraParticipantes.Enabled = False
            Me.cmdImpressao.Enabled = Me.iIdAgendamento > 0
        Else
            Me.fraDados.Enabled = True
            Me.fraParticipantes.Enabled = True
            Me.cmdAdicionarParticipante.Enabled = (Me.iPrvIdTreinamento > 0)
            Me.cmdImpressao.Enabled = False
        End If

    End Sub

    Private Sub frmAgendaTreinamento_carregaDados(ByVal ichave As Integer) Handles Me.carregaDados

        Dim dsAgendaTreinamento As New DataSet
        Dim sCarga As String
        Try
            If (ichave > 0) Then

                dsAgendaTreinamento = Me.objAgendaTreinamento.selecionar(ichave)
                Me.dsFuncionariosParticipantes = Me.objAgendaTreinamento.selecionarParticipantes(ichave)

                If dsAgendaTreinamento.Tables(0).Rows.Count > 0 Then
                    With dsAgendaTreinamento.Tables(0).Rows(0)
                        Me.iIdAgendamento = Conversao.ToInt32(.Item("IDAgendamento"))
                        Me.dtpData.Value = Conversao.ToDateTime(.Item("Data"))
                        Me.txtDescricao.Text = Conversao.ToString(.Item("Descricao"))
                        Me.txtTreinamento.Text = Conversao.ToString(.Item("Treinamento"))
                        Me.iPrvIdTreinamento = Conversao.ToInt32(.Item("IDTreinamento"))
                        Me.txtMinistrante.Text = Conversao.nuloParaVazio(.Item("Ministrante"))
                        sCarga = Conversao.nuloParaVazio(.Item("CargaHoraria"))
                        Me.txtCargaHoraria.Text = sCarga
                        Me.iPrvValidade = Conversao.nuloParaVazio(.Item("Validade"))
                    End With
                End If

                Me.preencheGrid()

                Me.cmdImpressao.Enabled = True

            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try

    End Sub

    Private Sub frmAgendaTreinamento_gravar(ByRef bCancel As Boolean) Handles Me.gravar

        Dim bRetorno As Boolean

        Try
            bCancel = True

            bRetorno = Me.objAgendaTreinamento.salvar(Me.iIdAgendamento, _
                                                      Me.iPrvIdTreinamento, _
                                                      Globais.iIDEmpresa, _
                                                      Me.dtpData.Value, _
                                                      Me.txtDescricao.Text.Trim, _
                                                      Me.txtMinistrante.Text.Trim, _
                                                      dsFuncionariosParticipantes, _
                                                      Me.txtCargaHoraria.Text)

            If Not bRetorno Then

                MyBase.Mensagens = Me.objAgendaTreinamento.retornaMensagensValidacao

            Else
                bCancel = False
                Me.iIdAgendamento = Me.objAgendaTreinamento.IDAgendamento
                MyBase.chave = Me.objAgendaTreinamento.IDAgendamento
                Me.bPrvResultado = True

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try

    End Sub

    Private Sub frmAgendaTreinamento_excluir(ByRef bCancel As Boolean) Handles Me.excluir

        Try

            If MsgBox("Deseja excluir o registro atual?", MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.Yes Then
                If Not Me.objAgendaTreinamento.excluir(Me.iIdAgendamento) Then
                    bCancel = True
                Else
                    Me.iIdAgendamento = 0
                    Me.iPrvIdTreinamento = 0
                End If
            Else
                bCancel = True
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try

    End Sub

    Private Sub frmAgendaTreinamento_setarProvedorDeErros() Handles Me.setarProvedorDeErros

        Dim iContadorMensagens As Int32
        Dim sMensagem As String

        For iContadorMensagens = 0 To MyBase.Mensagens(DSFronteiraPadrao.frmPadrao.eMensagem.Codigo).Count - 1

            sMensagem = MyBase.Mensagens(DSFronteiraPadrao.frmPadrao.eMensagem.Mensagem).item(iContadorMensagens)

            Select Case MyBase.Mensagens(DSFronteiraPadrao.frmPadrao.eMensagem.Codigo).item(iContadorMensagens)
                Case Controle.ctrAgendaTreinamento.eMensagens.NOME_TREINAMENTO_OBRIGATORIO
                    Me.epPadrao.SetError(Me.txtDescricao, sMensagem)
                Case Controle.ctrAgendaTreinamento.eMensagens.CARGA_HORARIA
                    Me.epPadrao.SetError(Me.txtCargaHoraria, sMensagem)
            End Select

        Next

    End Sub

    Private Sub frmAgendaTreinamento_limpaProvedorDeErros() Handles Me.limpaProvedorDeErros
        Me.epPadrao.SetError(Me.cmdSelecionarTreinamento, String.Empty)
        Me.epPadrao.SetError(Me.txtCargaHoraria, String.Empty)
        Me.epPadrao.SetError(Me.txtDescricao, String.Empty)
    End Sub

    Private Sub frmAgendaTreinamento_limpaCampo() Handles Me.limpaCampo
        MyBase.limpaCampos(Me)
        Me.configuraGrid()
    End Sub

    Private Sub frmAgendaTreinamento_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.dsFuncionariosParticipantes = Me.objAgendaTreinamento.selecionarParticipantes(0)
        Me.configuraGrid()
    End Sub

    Private Sub frmAgendaTreinamento_inserir(ByRef bCancel As Boolean) Handles Me.inserir
        Me.iIdAgendamento = 0
        Me.iPrvIdTreinamento = 0
    End Sub

    Private Sub frmAgendaTreinamento_alterar(ByRef bCancel As Boolean) Handles Me.alterar
        MyBase.modoAtual = eModo.eAlterando
    End Sub

    Private Sub cmdSelecionarTreinamento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelecionarTreinamento.Click

        Dim sSql As String
        Dim frmDialogo As New frmPesquisa
        Dim dsTreinamento As New DataSet

        If (MyBase.modoAtual = eModo.eAlterando) Then
            sSql = Me.objTreinamento.sqlConsulta()

            With frmDialogo
                .Sql = sSql
                .Titulo = "Pesquisa Treinamento"
                .CarregaTela()
                If .DS.Tables(0).Rows.Count > 0 Then
                    .ShowDialog()
                    If (.DialogResult = Windows.Forms.DialogResult.OK) Then
                        Me.iPrvIdTreinamento = Conversao.ToInt32(.ID)
                        dsTreinamento = Me.objTreinamento.selecionar(Me.iPrvIdTreinamento, "", 0)
                        Me.txtTreinamento.Text = dsTreinamento.Tables(0).Rows(0).Item("Descricao")
                        Me.txtCargaHoraria.Text = Conversao.nuloParaVazio(dsTreinamento.Tables(0).Rows(0).Item("CargaHoraria"))
                        Me.iPrvValidade = objTreinamento.Retornar_Validade_Treinamento(Me.iPrvIdTreinamento, Globais.iIDEmpresa)
                        configuraGrid()
                        cmdAdicionarParticipante.Enabled = True
                    End If
                Else
                    MsgBox("Registro não encontrado", MsgBoxStyle.Exclamation, Me.Text)
                    Exit Sub
                End If
            End With
        ElseIf (MyBase.modoAtual = eModo.eAguardando) Then

            sSql = Me.objAgendaTreinamento.sqlConsulta(Persistencia.Globais.iIDEmpresa)

            With frmDialogo
                .Sql = sSql
                .Larguras = "6,10,10"
                .Titulo = "Pesquisa Agendamento de Treinamento"
                .CarregaTela()
                If .DS.Tables(0).Rows.Count > 0 Then
                    .ShowDialog()
                    If (.DialogResult = Windows.Forms.DialogResult.OK) Then
                        MyBase.chave = .ID
                        Me.iIdAgendamento = MyBase.chave
                        frmAgendaTreinamento_carregaDados(MyBase.chave)
                        MyBase.alteraModopadrao(eModo.eAguardando)
                        cmdAdicionarParticipante.Enabled = True
                    End If
                Else
                    MsgBox("Registro não encontrado", MsgBoxStyle.Exclamation, Me.Text)
                    Exit Sub
                End If
            End With
        End If
    End Sub

    Private Sub cmdAdicionarParticipante_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdicionarParticipante.Click

        Dim frm As New frmParticipantesTreinamento
        frm.IdsFuncionario = Me.retornarIdsFuncionariosParticipantes
        frm.Treinamento = Me.iPrvIdTreinamento
        frm.DataTreinamento = Me.dtpData.Text
        frm.ShowDialog()

        If frm.Resultado Then

            dsFuncionariosParticipantes = Nothing
            dsFuncionariosParticipantes = frm.dsFuncionariosSelecionados
            Me.preencheGrid()

        End If

    End Sub

    Private Function retornarIdsFuncionariosParticipantes() As String

        Dim sIdsParticipantes As String = String.Empty

        For iContador As Integer = 0 To Me.dgvParticipantes.Rows.Count - 1
            sIdsParticipantes &= Conversao.ToInt32(Me.dgvParticipantes.Item(0, iContador).Value) & ","
        Next

        If sIdsParticipantes <> String.Empty Then
            Return sIdsParticipantes.Substring(0, sIdsParticipantes.Length - 1)
        Else
            Return String.Empty
        End If

    End Function

    Private Sub dgvParticipantes_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvParticipantes.CellClick

        Me.iLinhaDataSet = 0

        For Each drdados As DataRow In Me.dsFuncionariosParticipantes.Tables(0).Rows
            If Conversao.ToInt32(drdados.Item("IDFuncionario")) <> Conversao.ToInt32(Me.dgvParticipantes.Item(eColunasGrid.IDFuncionario, e.RowIndex).Value) Then
                Me.iLinhaDataSet += 1
            End If
        Next

    End Sub

    Private Sub cmdExcluirParticipante_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExcluirParticipante.Click
        Dim Selecionadas As DataGridViewSelectedRowCollection
        Dim iIDFuncionarioExcluido As Integer
        Dim rowSelected() As DataRow

        Try
            If (dgvParticipantes.SelectedRows.Count > 0) Then
                Selecionadas = dgvParticipantes.SelectedRows
                For cont = 0 To dgvParticipantes.SelectedRows.Count - 1
                    iIDFuncionarioExcluido = Selecionadas.Item(cont).Cells(0).Value
                    rowSelected = dsFuncionariosParticipantes.Tables(0).Select("IDFuncionario=" & iIDFuncionarioExcluido)
                    dsFuncionariosParticipantes.Tables(0).Rows.Remove(rowSelected(0))
                Next

                Me.preencheGrid()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub frmAgendaTreinamento_cancelar(ByRef bCancel As Boolean) Handles Me.cancelar
        Me.configuraGrid()
    End Sub
#End Region

    Private Sub cmdSelecionarAgendamento_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim sSql As String
        Dim frmDialogo As New frmPesquisa

        sSql = Me.objAgendaTreinamento.sqlConsulta(Persistencia.Globais.iIDEmpresa)

        With frmDialogo
            .Sql = sSql
            .Titulo = "Pesquisa Agendamento de Treinamento"
            .CarregaTela()
            If .DS.Tables(0).Rows.Count > 0 Then
                .ShowDialog()
                If (.DialogResult = Windows.Forms.DialogResult.OK) Then
                    MyBase.chave = .ID
                    Me.iIdAgendamento = MyBase.chave
                    frmAgendaTreinamento_carregaDados(MyBase.chave)
                    MyBase.alteraModopadrao(eModo.eAguardando)
                End If
            Else
                MsgBox("Registro não encontrado", MsgBoxStyle.Exclamation, Me.Text)
                Exit Sub
            End If
        End With

    End Sub

    Private Sub cmdImpressao_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdImpressao.Click

        Dim frmRelTreinamento As New frmRelTreinamento

        With frmRelTreinamento
            .IDEmpresa = Globais.iIDEmpresa
            .IDAgendaTreinamento = Me.iIdAgendamento
            .IDTipoTreinamento = Me.iPrvIdTreinamento
            .DataInicial = Me.dtpData.Value
            .DataFinal = Me.dtpData.Value
            .Show()
        End With

    End Sub

End Class