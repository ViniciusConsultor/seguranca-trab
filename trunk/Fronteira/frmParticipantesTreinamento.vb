Imports Persistencia
Public Class frmParticipantesTreinamento

#Region " Enumerações "

    Private Enum eColunasGrid
        Marcar = 0
        IDFuncionario = 1
        Funcionario = 2
        ExpiraEm = 3
    End Enum

#End Region

#Region "Variáveis"

    Private objFuncionario As New Controle.ctrFuncionario
    Private dsFuncionarios As New DataSet
    Private dsDados As New DataSet
    Private sIdsFuncionarios As String
    Private iPrvIDFuncionario As Integer
    Private iPrvIDTreinamento As Integer
    Private iPrvValidade As Integer
    Private btPrvFiltro As Byte
    Private bResultado As Boolean
    Private datPrvDataTreinamento As Date

#End Region

#Region " Propriedades"

    Public Property dsFuncionariosSelecionados() As DataSet
        Get
            Return Me.dsDados
        End Get
        Set(ByVal value As DataSet)
            Me.dsDados = value
        End Set
    End Property
    Public WriteOnly Property Treinamento()
        Set(ByVal value)
            iPrvIDTreinamento = value
        End Set
    End Property
    Public WriteOnly Property Validade()
        Set(ByVal value)
            iPrvValidade = value
        End Set
    End Property

    Public Property DataTreinamento()
        Set(ByVal value)
            datPrvDataTreinamento = value
        End Set
        Get
            Return Me.datPrvDataTreinamento
        End Get
    End Property

    Public Property IdsFuncionario() As String
        Get
            Return Me.sIdsFuncionarios
        End Get
        Set(ByVal value As String)
            Me.sIdsFuncionarios = value
        End Set
    End Property

    Public Property Resultado() As Boolean
        Get
            Return Me.bResultado
        End Get
        Set(ByVal value As Boolean)
            Me.bResultado = value
        End Set
    End Property

#End Region

#Region " Métodos "

    Private Sub configuraGrid()

        Dim estilo As New DataGridView
        Try
            With Me.dgvParticipantes

                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                .AutoGenerateColumns = False
                .AllowUserToAddRows = False
                .RowHeadersVisible = False
                .Columns.Clear()

                Dim Col1 As New DataGridViewCheckBoxColumn
                Col1.HeaderText = "Marcar"
                Col1.Width = 50
                Col1.Frozen = False
                Col1.ReadOnly = False
                Col1.FillWeight = 100
                Col1.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                Col1.SortMode = DataGridViewColumnSortMode.NotSortable
                Col1.Visible = True
                Col1.ValueType = System.Type.GetType("System.Boolean")
                .Columns.Add(Col1)

                Dim Col2 As New DataGridViewTextBoxColumn()
                Col2.HeaderText = "Código"
                Col2.DataPropertyName = "IDFuncionario"
                Col2.Width = 50
                Col2.Frozen = False
                Col2.ReadOnly = True
                Col2.FillWeight = 100
                Col2.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                Col2.SortMode = DataGridViewColumnSortMode.Automatic
                Col2.Visible = True
                Col2.ValueType = System.Type.GetType("System.Int32")
                .Columns.Add(Col2)

                Dim Col3 As New DataGridViewTextBoxColumn()
                Col3.HeaderText = "Funcionário"
                Col3.DataPropertyName = "Nome"
                Col3.Width = 260
                Col3.Frozen = False
                Col3.ReadOnly = True
                Col3.FillWeight = 100
                Col3.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                Col3.SortMode = DataGridViewColumnSortMode.Automatic
                Col3.Visible = True
                Col3.ValueType = System.Type.GetType("System.String")
                .Columns.Add(Col3)

                Dim Col4 As New DataGridViewTextBoxColumn()
                Col4.HeaderText = "Expira Em"
                Col4.DataPropertyName = "ExpiraEm"
                Col4.Width = 50
                Col4.Frozen = False
                Col4.ReadOnly = True
                Col4.FillWeight = 100
                Col4.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                Col4.SortMode = DataGridViewColumnSortMode.Automatic
                Col4.Visible = True
                Col4.ValueType = System.Type.GetType("System.Date")

                .Columns.Add(Col4)

                .Refresh()

            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try

    End Sub

    Private Function Verificar_Funcionario_Incluido(ByVal iIDFuncionario As Integer) As Boolean
        Dim bRetorno As Boolean = False

        Try
            For cont As Integer = 0 To dgvParticipantes.RowCount - 1
                If (dgvParticipantes.Item(eColunasGrid.IDFuncionario, cont).Value = iIDFuncionario) Then
                    bRetorno = True
                    Exit For
                End If
            Next

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try

        Return bRetorno

    End Function

    Private Sub preencheGrid()

        Dim iLinha As Integer = 0
        Dim bTreinamentoEmDia As Boolean = False

        Try

            Me.dsFuncionarios = Me.objFuncionario.selecionarFuncionariosTreinamento(Me.iPrvIDTreinamento, _
                                                                                    Me.DataTreinamento, _
                                                                                    Me.sIdsFuncionarios, _
                                                                                    Me.btPrvFiltro)


            If Me.dsFuncionarios.Tables(0).Rows.Count > 0 Then

                With Me.dgvParticipantes
                    .Rows.Clear()
                    .RowCount = Me.dsFuncionarios.Tables(0).Rows.Count

                    For Each drDados As DataRow In Me.dsFuncionarios.Tables(0).Rows
                        bTreinamentoEmDia = IIf(Conversao.ToString(drDados.Item("Em_dia")) = "", True, False)

                        .Item(eColunasGrid.Marcar, iLinha).Value = InStr(Me.sIdsFuncionarios, Conversao.ToString(drDados.Item("IDFuncionario"))) > 0
                        .Item(eColunasGrid.IDFuncionario, iLinha).Value = Conversao.ToString(drDados.Item("IDFuncionario"))
                        .Item(eColunasGrid.Funcionario, iLinha).Value = Conversao.ToString(drDados.Item("Nome"))
                        .Item(eColunasGrid.ExpiraEm, iLinha).Value = drDados.Item("ExpiraEm")

                        If (.Item(eColunasGrid.ExpiraEm, iLinha).Value Is DBNull.Value) Then
                            .Rows(iLinha).DefaultCellStyle.ForeColor = Color.Red
                        ElseIf (CDate(.Item(eColunasGrid.ExpiraEm, iLinha).Value) < CDate(datPrvDataTreinamento)) Then
                            .Rows(iLinha).DefaultCellStyle.ForeColor = Color.Red
                        ElseIf (DateDiff(DateInterval.Month, CDate(.Item(eColunasGrid.ExpiraEm, iLinha).Value), CDate(datPrvDataTreinamento)) = 1) Then
                            .Rows(iLinha).DefaultCellStyle.ForeColor = Color.Orange
                        End If

                        iLinha += 1
                    Next

                End With

            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try

    End Sub

    Private Sub frmParticipantesTreinamento_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.configuraGrid()
        Me.preencheGrid()
    End Sub

    Private Sub cmdSelecionar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelecionar.Click

        Me.selecaoFuncionarios()

        Me.bResultado = True

        Me.Close()

    End Sub

    Private Sub selecaoFuncionarios()

        Me.dsFuncionariosSelecionados = Me.dsFuncionarios.Clone

        For iContador As Integer = 0 To Me.dgvParticipantes.Rows.Count - 1
            If Conversao.ToBoolean(Me.dgvParticipantes.Item(eColunasGrid.Marcar, iContador).Value) = True Then
                Me.dsFuncionariosSelecionados.Tables(0).Rows.Add(New Object() {Conversao.ToInt32(Me.dgvParticipantes.Item(eColunasGrid.IDFuncionario, iContador).Value), _
                                                                               Conversao.ToString(Me.dgvParticipantes.Item(eColunasGrid.Funcionario, iContador).Value)})
            End If
        Next

    End Sub

    Private Sub cmdSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSair.Click
        Me.bResultado = False
        Me.Close()
    End Sub

    Private Sub cmdMarcarTodos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMarcarTodos.Click

        If Me.cmdMarcarTodos.Text = "Marcar todos" Then
            Me.selecaoGrid(True)
            Me.cmdMarcarTodos.Text = "Desmarcar todos"
        Else
            Me.selecaoGrid(False)
            Me.cmdMarcarTodos.Text = "Marcar todos"
        End If

    End Sub

    Private Sub selecaoGrid(ByVal bMarcar As Boolean)

        For iContador As Integer = 0 To Me.dgvParticipantes.Rows.Count - 1
            Me.dgvParticipantes.Item(eColunasGrid.Marcar, iContador).Value = bMarcar
        Next

    End Sub

    Private Sub dgvParticipantes_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvParticipantes.CellDoubleClick
        Me.dgvParticipantes.Item(eColunasGrid.Marcar, e.RowIndex).Value = Not Me.dgvParticipantes.Item(eColunasGrid.Marcar, e.RowIndex).Value
    End Sub

    Private Sub dgvParticipantes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvParticipantes.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            Me.cmdSelecionar_Click(sender, e)
        End If
    End Sub

#End Region

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
                        iPrvIDFuncionario = .ID
                        txtNome.Text = objFuncionario.Retornar_Nome_Funcionario(iPrvIDFuncionario)
                        cmdIncluir.Enabled = True
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

    Private Sub cmdIncluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdIncluir.Click

        Try
            If (Not Verificar_Funcionario_Incluido(iPrvIDFuncionario)) Then
                With Me.dgvParticipantes

                    .RowCount = .RowCount + 1
                    .Item(eColunasGrid.Marcar, .RowCount - 1).Value = True
                    .Item(eColunasGrid.IDFuncionario, .RowCount - 1).Value = iPrvIDFuncionario
                    .Item(eColunasGrid.Funcionario, .RowCount - 1).Value = txtNome.Text.Trim

                    txtNome.Clear()
                    iPrvIDFuncionario = 0
                    cmdIncluir.Enabled = False
                End With
            Else
                MsgBox("Funcionário já incluído neste treinamento.", MsgBoxStyle.Exclamation, Me.Text)
            End If

        Catch ex As Exception

            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)

        End Try

    End Sub

    Private Sub chkFiltrar_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkFiltrar.Click
        fraFiltro.Enabled = chkFiltrar.Checked
        cboStatus.SelectedIndex = 0
    End Sub

    Private Sub cmdFiltrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFiltrar.Click

        If (chkFiltrar.Checked) Then
            btPrvFiltro = cboStatus.SelectedIndex + 1
        Else
            btPrvFiltro = 0
        End If

        Me.preencheGrid()

    End Sub

End Class